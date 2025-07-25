Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Drawing

Imports Excel = Microsoft.Office.Interop.Excel
Imports Microsoft.Office
Imports Microsoft.Office.Interop
Imports System.Text

Public Class MonitoringMCU
    Private formName As String = "FORM MONITORING MCU LABORATORIUM"

    Private Find_Poliklinik As Find.TLconnect
    Private DB_Poliklinik As TLcon

    Dim thread As System.Threading.Thread
    Dim conn As OleDbConnection
    Dim dtr As OleDbDataReader
    Dim dta As OleDbDataAdapter
    Dim cmd As OleDbCommand
    Dim dts As DataSet
    Dim excel As String
    Dim opFileDialog As New OpenFileDialog()
    Private userUploadMCU As String = PoliKlinik.Lbluser.Text
    Private NoWhatsappCompany As String = ""
    Private NoWhatsappMarketing As String = ""
    Private NoWhatsappCustomer As String = ""
    Private EmailCompany As String = ""
    Private EmailCustomer As String = ""

    ' Set Default
    Private DrPelaksanaKlinik As String = ReadSQLNIK("select StrValue from MsConfig where ConfigName='DokterPK'")

    Private Sub PanelTop_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelTop.Paint
        Try
            e.Graphics.DrawString(formName, New Font("Arial", 12, FontStyle.Bold), Brushes.White, New Point(10, 10))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub SetConn()
        ' Set Parameter Server Online
        Dim serverOnline_IP As String = Utility.GetConfig("ServerOnline_IP")
        Dim serverOnline_UserID As String = Utility.GetConfig("ServerOnline_UserID")
        Dim serverOnline_Password As String = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerOnline_Password"), "albert")

        ' Set DB Poliklinik
        DB_Poliklinik.Tip = serverOnline_IP
        DB_Poliklinik.Tid = serverOnline_UserID
        DB_Poliklinik.Tpass = serverOnline_Password
        DB_Poliklinik.Tdb = Utility.GetConfig("ServerOnlinePoli_DB")

        ' Set Find Poliklinik
        Find_Poliklinik.Tip = serverOnline_IP
        Find_Poliklinik.Tid = serverOnline_UserID
        Find_Poliklinik.Tpass = serverOnline_Password
        Find_Poliklinik.Tdb = Utility.GetConfig("ServerOnlinePoli_DB")
    End Sub

    Function CreateTable() As DataTable
        Dim Thasil As New DataTable

        insertRowToTbls(Thasil, "Typstring", "nourut")
        insertRowToTbls(Thasil, "Typstring", "nama")
        insertRowToTbls(Thasil, "Typstring", "sex")
        insertRowToTbls(Thasil, "Typstring", "idlabinternet")
        insertRowToTbls(Thasil, "Typstring", "idtempatlab")
        insertRowToTbls(Thasil, "Typstring", "idpaket")
        insertRowToTbls(Thasil, "Typstring", "company")

        For Each Tcol As DataColumn In Thasil.Columns
            Tcol.ReadOnly = True
        Next

        Return Thasil
    End Function

    Private Sub SetGrid()
        gridlab.DataSource = Nothing

        ProgressBar1.Value = 0
        ProgressBar1.Visible = False
        rdOnline.Checked = True
        gridlab.DataSource = Nothing
        cmbstatustransaksi.SelectedIndex = 0
        txNoUrut1.Enabled = False
        txNoUrut2.Enabled = False
        cblab.Checked = True
        cbthorax.Checked = True
        cbfisik.Checked = True
    End Sub

    Private Sub MonitoringMCU_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
        Me.MdiParent = PoliKlinik
        Me.Dock = DockStyle.Fill

        SetConn()
        SetGrid()
    End Sub

    Private Sub SetClearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SetConn()
        SetGrid()
    End Sub

    Private Sub rdOnline_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdOnline.CheckedChanged
        txloc.ResetText()
        txidloc.ResetText()
        ButtonFindLokasi.Enabled = True
        gridlab.DataSource = Nothing
    End Sub

    Private Sub rdOffline_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdOffline.CheckedChanged
        txidloc.Text = ReadSQLNIK("select StrValue from MsConfig where ConfigName='NoPoli'")
        txloc.Text = ReadSQLNIK("select StrValue from MsConfig where ConfigName='NamaPoli'")
        ButtonFindLokasi.Enabled = False
        gridlab.DataSource = Nothing
    End Sub

    Function CreateDataRekapHasil() As DataTable
        Dim Tbls As DataTable = New DataTable
        Dim Ttindakan As DataTable = New DataTable
        Dim status As String = ""
        Dim status2 As String = ""

        If cmbstatustransaksi.SelectedIndex = 1 Then
            status = " AND (a.StatusKesehatanLab NOT IN ('UNFIT', 'UNFIT SEMENTARA', 'FIT DENGAN CATATAN') AND a.StatusKesehatanThorax NOT IN ('UNFIT', 'UNFIT SEMENTARA', 'FIT DENGAN CATATAN') AND a.StatusKesehatanFisik NOT IN ('UNFIT', 'UNFIT SEMENTARA', 'FIT DENGAN CATATAN')) AND (a.StatusKesehatanLab = 'FIT' OR a.StatusKesehatanThorax = 'FIT' OR a.StatusKesehatanFisik = 'FIT') "
            status2 = " AND (c.StatusKesehatanLab NOT IN ('UNFIT', 'UNFIT SEMENTARA', 'FIT DENGAN CATATAN') AND c.StatusKesehatanThorax NOT IN ('UNFIT', 'UNFIT SEMENTARA', 'FIT DENGAN CATATAN') AND c.StatusKesehatanFisik NOT IN ('UNFIT', 'UNFIT SEMENTARA', 'FIT DENGAN CATATAN')) AND (c.StatusKesehatanLab = 'FIT' OR c.StatusKesehatanThorax = 'FIT' OR c.StatusKesehatanFisik = 'FIT') "
        ElseIf cmbstatustransaksi.SelectedIndex = 2 Then
            status = " AND (a.StatusKesehatanLab NOT IN ('UNFIT', 'UNFIT SEMENTARA') AND a.StatusKesehatanThorax NOT IN ('UNFIT', 'UNFIT SEMENTARA') AND a.StatusKesehatanFisik NOT IN ('UNFIT', 'UNFIT SEMENTARA')) AND (a.StatusKesehatanLab = 'FIT DENGAN CATATAN' OR a.StatusKesehatanThorax = 'FIT DENGAN CATATAN' OR a.StatusKesehatanFisik = 'FIT DENGAN CATATAN') "
            status2 = " AND (c.StatusKesehatanLab NOT IN ('UNFIT', 'UNFIT SEMENTARA') AND c.StatusKesehatanThorax NOT IN ('UNFIT', 'UNFIT SEMENTARA') AND c.StatusKesehatanFisik NOT IN ('UNFIT', 'UNFIT SEMENTARA')) AND (c.StatusKesehatanLab = 'FIT DENGAN CATATAN' OR c.StatusKesehatanThorax = 'FIT DENGAN CATATAN' OR c.StatusKesehatanFisik = 'FIT DENGAN CATATAN') "
        ElseIf cmbstatustransaksi.SelectedIndex = 3 Then
            status = " AND (a.StatusKesehatanLab NOT IN ('UNFIT') AND a.StatusKesehatanThorax NOT IN ('UNFIT') AND a.StatusKesehatanFisik NOT IN ('UNFIT')) AND (a.StatusKesehatanLab = 'UNFIT SEMENTARA' OR a.StatusKesehatanThorax = 'UNFIT SEMENTARA' OR a.StatusKesehatanFisik = 'UNFIT SEMENTARA') "
            status2 = " AND (c.StatusKesehatanLab NOT IN ('UNFIT') AND c.StatusKesehatanThorax NOT IN ('UNFIT') AND c.StatusKesehatanFisik NOT IN ('UNFIT')) AND (c.StatusKesehatanLab = 'UNFIT SEMENTARA' OR c.StatusKesehatanThorax = 'UNFIT SEMENTARA' OR c.StatusKesehatanFisik = 'UNFIT SEMENTARA') "
        ElseIf cmbstatustransaksi.SelectedIndex = 4 Then
            status = " AND (a.StatusKesehatanLab = 'UNFIT' OR a.StatusKesehatanThorax = 'UNFIT' OR a.StatusKesehatanFisik = 'UNFIT') "
            status2 = " AND (c.StatusKesehatanLab = 'UNFIT' OR c.StatusKesehatanThorax = 'UNFIT' OR c.StatusKesehatanFisik = 'UNFIT') "
        End If

        Dim Number1 As String = ""
        Dim Number2 As String = ""
        Dim TrangeNumber As String = ""
        Dim TrangeNumber2 As String = ""

        'Set No Urut
        If cbNoUrut.Checked = True Then
            Number1 = txNoUrut1.Text.ToString().PadLeft(5, "0")
            Number2 = txNoUrut2.Text.ToString().PadLeft(5, "0")
            TrangeNumber = " AND (RIGHT(a.nourut, 5) BETWEEN '" & Number1 & "' and '" & Number2 & "')"
            TrangeNumber2 = " AND (RIGHT(c.nourut, 5) BETWEEN '" & Number1 & "' and '" & Number2 & "')"
        End If

        If rdOffline.Checked = True Then
            Tbls = ReadSQL("SELECT NoUrut, 'Foto toraks tak tampak kelainan' AS 'Hasil', '-' AS 'Cor', '-' AS 'Pulmo', '-' AS 'Sinus', '-' AS 'Skeletal', '-' AS 'StatusKesehatan' FROM TransaksiLab WHERE DetailPemeriksaan LIKE '%THORAX%' AND TransLabID IN (SELECT TransLabID FROM TransaksiLabBayar WHERE NoJenisBayar = '" & txcompanycode.Text & "-" & txkodecabang.Text & "' AND JenisBayar = 'TAGIHAN') AND (CONVERT(date, TglLab) BETWEEN '" & Format(dtprocess.Value, "MM-dd-yyyy") & "' AND '" & Format(dtprocessend.Value, "MM-dd-yyyy") & "')")
        ElseIf rdOnline.Checked = True Then
            Tbls = ReadThemysql("SELECT a.nourut, b.nama, b.alamat, b.NIP, b.PTNIK, DATE(b.tgllahir) AS tgllahir, b.sex, a.idpaket, c.nojenisbayar AS 'company', DATE(a.tgllab) AS tgllab, a.idtempatlab, a.idlabinternet" & _
                                " FROM transaksilab a" & _
                                " LEFT JOIN masterpasien b ON a.idpasien = b.nomitra" & _
                                " LEFT JOIN transaksilabbayar c ON a.idlabinternet = c.idlabinternet" & _
                                " WHERE (DATE(a.tgllab) BETWEEN '" & Format(dtprocess.Value, "yyyy-MM-dd") & "' AND '" & Format(dtprocessend.Value, "yyyy-MM-dd") & "') AND (a.StatusKesehatanThorax IS NOT NULL AND a.StatusKesehatanLab IS NOT NULL AND a.StatusKesehatanFisik IS NOT NULL) AND a.idtempatlab = b.cabang AND a.idtempatlab = '" & txidloc.Text & "' " & status & " AND (c.NoJenisBayar = '" & txcompanycode.Text & "-" & txkodecabang.Text & "' AND c.JenisBayar = 'TAGIHAN') " & TrangeNumber & "  ORDER BY a.nourut", DB_Poliklinik)

            Ttindakan = ReadThemysql("SELECT DISTINCT a.TindakanID, b.NoUrut, UPPER(a.NamaTindakan) AS 'NamaTindakan',UPPER(b.DetailKet) AS 'DetailKet' FROM transaksilabdetail a" & _
                                     " LEFT JOIN transaksilabresult b ON a.TransLabIDDetail = b.TransLabIDDetail AND a.TindakanID = b.TindakanID AND a.idlabinternet = b.idlabinternet" & _
                                     " LEFT JOIN masterjenistindakan m on m.JenisTindakan = a.JenisTindakan" & _
                                     " LEFT JOIN transaksilab c on c.idlabinternet = a.idlabinternet" & _
                                     " LEFT JOIN masterpasien d ON c.idpasien=d.nomitra" & _
                                     " WHERE (DATE(c.tgllab) BETWEEN '" & Format(dtprocess.Value, "yyyy-MM-dd") & "' AND '" & Format(dtprocessend.Value, "yyyy-MM-dd") & "') AND (c.StatusKesehatanThorax IS NOT NULL AND c.StatusKesehatanLab IS NOT NULL AND c.StatusKesehatanFisik IS NOT NULL) AND c.idtempatlab='" & txidloc.Text & "' " & status2 & " AND b.nourut IS NOT NULL " & TrangeNumber2 & "" & _
                                     " AND c.idlabinternet IN (SELECT idlabinternet FROM transaksilabbayar WHERE NoJenisBayar = '" & txcompanycode.Text & "-" & txkodecabang.Text & "' AND JenisBayar = 'TAGIHAN')" & _
                                     " ORDER BY m.UrutanJenisID,a.Urutan,b.TindakanID,b.NoUrut,a.TransLabIDDetail,a.TindakanID,b.GroupID,b.DetailKet", DB_Poliklinik)

            ' Tambah Kolom Hasil
            Dim Tnew2 As DataRow = Ttindakan.NewRow

            Tnew2("TindakanID") = "1000"
            Tnew2("NoUrut") = "0"
            Tnew2("NamaTindakan") = "Kesimpulan Pemeriksaan Lab"
            Tnew2("DetailKet") = "Kesimpulan Pemeriksaan Lab"
            Ttindakan.Rows.Add(Tnew2)

            ' Tambah Kolom Keterangan
            Tnew2 = Ttindakan.NewRow
            Tnew2("TindakanID") = "1001"
            Tnew2("NoUrut") = "0"
            Tnew2("NamaTindakan") = "Kesimpulan Akhir"
            Tnew2("DetailKet") = "Kesimpulan Akhir"
            Ttindakan.Rows.Add(Tnew2)

            ' Tambah Kolom Saran
            Tnew2 = Ttindakan.NewRow
            Tnew2("TindakanID") = "1002"
            Tnew2("NoUrut") = "0"
            Tnew2("NamaTindakan") = "Saran Fisik"
            Tnew2("DetailKet") = "Saran Fisik"
            Ttindakan.Rows.Add(Tnew2)
        End If

        'Set Tindakan
        Dim TtempTindakanID As String = "("
        Dim Ttempidlabinternet As String = "("
        For Each TrowTindakan As DataRow In Ttindakan.Rows
            If TtempTindakanID.Contains("'" & TrowTindakan("TindakanID").ToString.Trim & "'") = False Then
                TtempTindakanID = TtempTindakanID & "'" & TrowTindakan("TindakanID").ToString.Trim & "',"
            End If
            insertRowToTbls(Tbls, "Typstring", TrowTindakan("TindakanID").ToString & "/" & TrowTindakan("NoUrut").ToString)
        Next
        TtempTindakanID = Strings.Left(TtempTindakanID, TtempTindakanID.Length - 1) & ")"

        For Each Tidlabinternet As DataRow In Tbls.Rows
            If Ttempidlabinternet.Contains("'" & Tidlabinternet("idlabinternet").ToString.Trim & "'") = False Then
                Ttempidlabinternet = Ttempidlabinternet & "'" & Tidlabinternet("idlabinternet").ToString.Trim & "',"
            End If
        Next
        Ttempidlabinternet = Strings.Left(Ttempidlabinternet, Ttempidlabinternet.Length - 1) & ")"

        Dim TblsN As DataTable = ReadThemysql("SELECT case when a.result <> '' then a.result ELSE '-' END AS 'result', a.nourut, a.tindakanid, a.idlabinternet from transaksilabresult a left join transaksilabdetail b on b.TransLabIDDetail=a.TransLabIDDetail and b.TindakanID=a.TindakanID and a.idlabinternet=b.idlabinternet where b.idlabinternet IN (SELECT idlabinternet FROM transaksilab WHERE a.tindakanid in " & TtempTindakanID & " and idlabinternet in " & Ttempidlabinternet & ")", DB_Poliklinik)
        Dim tempidlabinternet As Integer = 0

        Dim KesimpulanLab As String = ""
        Dim KesimpulanAkhir As String = ""

        For Each TrowN As DataRow In TblsN.Rows
            For Each Thasil As DataRow In Tbls.Rows
                If TrowN("idlabinternet") = Thasil("idlabinternet") Then
                    For j As Integer = 12 To Tbls.Columns.Count - 1 Step 1
                        Dim Tidx() As String = Tbls.Columns(j).ColumnName.ToString.Split("/")

                        If TrowN("tindakanid") = Tidx(0) And TrowN("nourut") = Tidx(1) Then
                            If (Tidx(0) = "241") Then
                                ' Pemeriksaan Fisik
                                Thasil(j) = ReadThemysqlNIK("SELECT a.result FROM transaksilabfisik a WHERE a.idlabinternet = '" & TrowN("idlabinternet") & "' AND a.fisikket = 'Kesimpulan'", DB_Poliklinik)
                            ElseIf (Tidx(0) = "242") Then
                                ' Thorax
                                Thasil(j) = ReadThemysqlNIK("SELECT CONCAT (a.StatusKesehatanThorax, ' - ', b.kesimpulan) FROM transaksilab a LEFT JOIN transaksilabhasillain b ON a.idlabinternet=b.idlabinternet WHERE a.idlabinternet = '" & TrowN("idlabinternet") & "'", DB_Poliklinik)
                            Else
                                Thasil(j) = TrowN("result")
                            End If
                        ElseIf (Tidx(0) = "1000" Or Tidx(0) = "1001") Then
                            If (Tidx(0) = "1000" Or Tidx(0) = "1001") And tempidlabinternet <> TrowN("idlabinternet") Then
                                Dim TempSaranKeterangan As DataTable = ReadThemysql("SELECT a.kesimpulan, a.StatusKesehatanThorax, a.StatusKesehatanLab, a.StatusKesehatanFisik FROM transaksilab a WHERE a.idlabinternet = '" & Thasil("idlabinternet").ToString & "'", DB_Poliklinik)
                                For Each Trow As DataRow In TempSaranKeterangan.Rows
                                    If IsDBNull(Trow("StatusKesehatanThorax")) = True Then Trow("StatusKesehatanThorax") = "-"
                                    If IsDBNull(Trow("StatusKesehatanLab")) = True Then Trow("StatusKesehatanLab") = "-"
                                    If IsDBNull(Trow("StatusKesehatanFisik")) = True Then Trow("StatusKesehatanFisik") = "-"

                                    KesimpulanLab = Trow("kesimpulan")

                                    If Trow("StatusKesehatanThorax") = "UNFIT" = True Or Trow("StatusKesehatanLab") = "UNFIT" Or Trow("StatusKesehatanFisik") = "UNFIT" Then
                                        KesimpulanAkhir = "UNFIT"
                                    ElseIf Trow("StatusKesehatanThorax") = "UNFIT SEMENTARA" = True Or Trow("StatusKesehatanLab") = "UNFIT SEMENTARA" Or Trow("StatusKesehatanFisik") = "UNFIT SEMENTARA" Then
                                        KesimpulanAkhir = "UNFIT SEMENTARA"
                                    ElseIf Trow("StatusKesehatanThorax") = "FIT DENGAN CATATAN" = True Or Trow("StatusKesehatanLab") = "FIT DENGAN CATATAN" Or Trow("StatusKesehatanFisik") = "FIT DENGAN CATATAN" Then
                                        KesimpulanAkhir = "FIT DENGAN CATATAN"
                                    ElseIf Trow("StatusKesehatanThorax") = "FIT" = True Or Trow("StatusKesehatanLab") = "FIT" Or Trow("StatusKesehatanFisik") = "FIT" Then
                                        KesimpulanAkhir = "FIT"
                                    End If
                                Next

                                tempidlabinternet = TrowN("idlabinternet")
                            End If

                            If Tidx(0) = "1000" Then
                                Thasil(j) = KesimpulanLab
                            ElseIf Tidx(0) = "1001" Then
                                Thasil(j) = KesimpulanAkhir
                            End If
                        ElseIf (Tidx(0) = "1002") Then
                            ' Saran Pemeriksaan Fisik
                            Thasil(j) = ReadThemysqlNIK("SELECT a.result FROM transaksilabfisik a WHERE a.idlabinternet = '" & TrowN("idlabinternet") & "' AND a.fisikket = 'Saran'", DB_Poliklinik)
                        End If
                    Next
                End If
            Next
        Next

        'Set Header
        For j As Integer = 12 To Tbls.Columns.Count - 1 Step 1
            Dim Tcol As DataColumn = Tbls.Columns(j)
            Dim Txid() As String = Tcol.ColumnName.ToString.Split("/")
            If Txid(0) = "1000" Then
                Tcol.ColumnName = "Kesimpulan Pemeriksaan Lab"
            ElseIf Txid(0) = "1001" Then
                Tcol.ColumnName = "Kesimpulan Akhir"
            ElseIf Txid(0) = "1002" Then
                Tcol.ColumnName = "Saran"
            Else
                Dim Tstr As String = ReadSQLNIK("select DetailKet from MasterLabDetail where TindakanID='" & Txid(0) & "' and NoUrut='" & Txid(1) & "' AND Deleted <> 1")
                For i As Integer = 12 To j - 1 Step 1
                    If Tbls.Columns(i).ColumnName = Tstr Then
                        Tstr = Tstr & " "
                    End If
                Next
                Tcol.ColumnName = Tstr
            End If
        Next

        Return Tbls
    End Function

    Function CheckingData() As Boolean
        If txcompanycode.Text = "" Then
            MsgBox("Pilih Company Terlebih Dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        ElseIf txidloc.Text = "" Then
            MsgBox("Pilih Lokasi Terlebih Dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        Dim status As String = ""

        If cmbstatustransaksi.SelectedIndex = 1 Then
            status = " AND (a.StatusKesehatanLab NOT IN ('UNFIT', 'UNFIT SEMENTARA', 'FIT DENGAN CATATAN') AND a.StatusKesehatanThorax NOT IN ('UNFIT', 'UNFIT SEMENTARA', 'FIT DENGAN CATATAN') AND a.StatusKesehatanFisik NOT IN ('UNFIT', 'UNFIT SEMENTARA', 'FIT DENGAN CATATAN')) AND (a.StatusKesehatanLab = 'FIT' OR a.StatusKesehatanThorax = 'FIT' OR a.StatusKesehatanFisik = 'FIT') "
        ElseIf cmbstatustransaksi.SelectedIndex = 2 Then
            status = " AND (a.StatusKesehatanLab NOT IN ('UNFIT', 'UNFIT SEMENTARA') AND a.StatusKesehatanThorax NOT IN ('UNFIT', 'UNFIT SEMENTARA') AND a.StatusKesehatanFisik NOT IN ('UNFIT', 'UNFIT SEMENTARA')) AND (a.StatusKesehatanLab = 'FIT DENGAN CATATAN' OR a.StatusKesehatanThorax = 'FIT DENGAN CATATAN' OR a.StatusKesehatanFisik = 'FIT DENGAN CATATAN') "
        ElseIf cmbstatustransaksi.SelectedIndex = 3 Then
            status = " AND (a.StatusKesehatanLab NOT IN ('UNFIT') AND a.StatusKesehatanThorax NOT IN ('UNFIT') AND a.StatusKesehatanFisik NOT IN ('UNFIT')) AND (a.StatusKesehatanLab = 'UNFIT SEMENTARA' OR a.StatusKesehatanThorax = 'UNFIT SEMENTARA' OR a.StatusKesehatanFisik = 'UNFIT SEMENTARA') "
        ElseIf cmbstatustransaksi.SelectedIndex = 4 Then
            status = " AND (a.StatusKesehatanLab = 'UNFIT' OR a.StatusKesehatanThorax = 'UNFIT' OR a.StatusKesehatanFisik = 'UNFIT') "
        End If

        Dim Number1 As String = ""
        Dim Number2 As String = ""
        Dim TrangeNumber As String = ""

        'Set No Urut
        If cbNoUrut.Checked = True Then
            If txNoUrut1.Text.Trim = "" Or txNoUrut2.Text.Trim = "" Or txNoUrut1.Text.Trim = "0" Or txNoUrut2.Text.Trim = "0" Then
                MsgBox("No Urut tidak boleh kosong.", MsgBoxStyle.Exclamation, "Warning!")
                Return False
            ElseIf CDbl(txNoUrut1.Text) > CDbl(txNoUrut2.Text) Then
                MsgBox("Pastikan Inputan No Urut sudah benar.", MsgBoxStyle.Exclamation, "Warning!")
                Return False
            Else
                Number1 = txNoUrut1.Text.ToString().PadLeft(5, "0")
                Number2 = txNoUrut2.Text.ToString().PadLeft(5, "0")
                TrangeNumber = " AND (RIGHT(a.nourut, 5) BETWEEN '" & Number1 & "' and '" & Number2 & "')"
            End If
        End If

        Dim Tbls As DataTable = New DataTable
        Tbls = ReadThemysql("SELECT a.nourut, b.nama, b.alamat, DATE(b.tgllahir) AS tgllahir, b.sex, a.idpaket, c.nojenisbayar AS 'company', DATE(a.tgllab) AS tgllab, a.idtempatlab, a.idlabinternet" & _
                                " FROM transaksilab a" & _
                                " LEFT JOIN masterpasien b ON a.idpasien = b.nomitra" & _
                                " LEFT JOIN transaksilabbayar c ON a.idlabinternet = c.idlabinternet" & _
                                " WHERE (DATE(a.tgllab) BETWEEN '" & Format(dtprocess.Value, "yyyy-MM-dd") & "' AND '" & Format(dtprocessend.Value, "yyyy-MM-dd") & "') AND (a.StatusKesehatanThorax IS NOT NULL AND a.StatusKesehatanLab IS NOT NULL AND a.StatusKesehatanFisik IS NOT NULL) AND a.idtempatlab = b.cabang AND a.idtempatlab = '" & txidloc.Text & "' " & status & " AND (c.NoJenisBayar = '" & txcompanycode.Text & "-" & txkodecabang.Text & "' AND c.JenisBayar = 'TAGIHAN') " & TrangeNumber & "", DB_Poliklinik)

        If Tbls.Rows.Count <= 0 Then
            MsgBox("Tidak ada data yang ditarik.", MsgBoxStyle.Critical, "Warning")
            Return False
        End If

        Select Case MsgBox("Total data sebanyak " & Tbls.Rows.Count & ". Lanjutkan?", MsgBoxStyle.YesNo, "Question.")
            Case MsgBoxResult.No
                MsgBox("Batal Print.", MsgBoxStyle.Critical, "Warning")
                Return False
        End Select

        Return True
    End Function

    Public Sub CetakHasil()
        Try
            ButtonPrintHasilMCU.Enabled = False
            ProgressBar1.Visible = True
            Dim TblsPrint As DataTable = CreateDataRekapHasil()
            Dim procent As Integer = 0
            Dim persen As Integer = 0

            For Each Tdata As DataRow In TblsPrint.Rows
                persen = persen + 1
                procent = persen * 100 / TblsPrint.Rows.Count
                ProgressBar1.Value = procent

                If CheckBoxReverse.Checked = True Then
                    If cbfisik.Checked = True Then CetakLaporanFisik(Tdata("idlabinternet"), Tdata("idtempatlab"))
                    If cbthorax.Checked = True Then printthorax(Tdata("idlabinternet"), Tdata("idtempatlab"))
                    If cblab.Checked = True Then printlaboratorium(Tdata("idlabinternet"), Tdata("idtempatlab"))
                Else
                    If cblab.Checked = True Then printlaboratorium(Tdata("idlabinternet"), Tdata("idtempatlab"))
                    If cbthorax.Checked = True Then printthorax(Tdata("idlabinternet"), Tdata("idtempatlab"))
                    If cbfisik.Checked = True Then CetakLaporanFisik(Tdata("idlabinternet"), Tdata("idtempatlab"))
                End If
            Next

            MsgBox("Berhasil print sebanyak " & TblsPrint.Rows.Count & " file.", MsgBoxStyle.Information, "Success!")
            ButtonPrintHasilMCU.Enabled = True
            ProgressBar1.Visible = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub printlaboratorium(ByVal idlabinternet As String, ByVal idtempatlab As String)
        Dim TempWhatsapp As String = ""
        Dim TempEmail As String = ""
        Dim CountResultEmpty As Integer = 0

        Dim Tbls As DataTable = ReadThemysql("SELECT a.TransLabID,a.TransLabIDDetail,a.TindakanID,a.NamaTindakan,a.JenisTindakan,b.NoUrut,b.GroupID,b.DetailKet,b.Result,b.Satuan,b.Pria,b.Wanita,b.Keterangan,m.UrutanJenisID,a.Urutan, b.saran as 'Saran'" & _
                                             " FROM transaksilabdetail a" & _
                                             " LEFT JOIN transaksilabresult b on a.TransLabIDDetail =b.TransLabIDDetail AND a.TindakanID=b.TindakanID AND a.idlabinternet = b.idlabinternet" & _
                                             " LEFT JOIN masterjenistindakan m on m.JenisTindakan=a.JenisTindakan" & _
                                             " WHERE a.idlabinternet = '" & idlabinternet & "'" & _
                                             " ORDER BY m.UrutanJenisID,a.Urutan,b.TindakanID,b.NoUrut,a.TransLabIDDetail,a.TindakanID,b.GroupID,b.DetailKet", DB_Poliklinik)

        insertRowToTbls(Tbls, "typstring", "Registrasi")
        insertRowToTbls(Tbls, "typstring", "Hasil")
        insertRowToTbls(Tbls, "typstring", "Nama")
        insertRowToTbls(Tbls, "typstring", "Umur")
        insertRowToTbls(Tbls, "typstring", "Alamat")
        insertRowToTbls(Tbls, "typstring", "NoTransaksi")
        insertRowToTbls(Tbls, "typstring", "DrPelaksana")
        insertRowToTbls(Tbls, "typstring", "DrRequest")
        insertRowToTbls(Tbls, "typstring", "Standart P/W")
        insertRowToTbls(Tbls, "typstring", "Tanggal")
        insertRowToTbls(Tbls, "typstring", "barcodenotrans")
        insertRowToTbls(Tbls, "typstring", "KesimpulanAll")

        Dim Tlab As DataTable = ReadThemysql("SELECT a.StatusKesehatanThorax, a.StatusKesehatanLab, a.StatusKesehatanFisik, a.Saran, a.Kesimpulan, a.SendingWhatsapp, a.SendingEmail, b.PTNIK, b.NIP, a.caraambil, a.dokterrequest, c.nojenisbayar, b.nama, b.nomitra, a.nourut, b.sex, DATE(b.tgllahir) AS tgllahir, b.alamat, DATE(a.tgllab) AS tgllab" & _
                                             " FROM transaksilab a" & _
                                             " LEFT JOIN masterpasien b ON a.idpasien=b.nomitra AND a.idtempatlab=b.cabang" & _
                                             " LEFT JOIN transaksilabbayar c ON a.idlabinternet=c.idlabinternet" & _
                                             " WHERE a.idlabinternet='" & idlabinternet & "' AND a.idtempatlab='" & idtempatlab & "'", DB_Poliklinik)
        Dim TrowLab As DataRow = Tlab.Rows(0)
        Dim Tsimpul As String = ""
        Dim Tsaran As String = ""
        Dim ptnik As String = ""
        Dim nip As String = ""
        Dim Pengirim As String = ""
        If IsDBNull(TrowLab("PTNIK")) = False Then ptnik = TrowLab("PTNIK") Else ptnik = "-"
        If IsDBNull(TrowLab("NIP")) = False And TrowLab("NIP").ToString <> "-" And TrowLab("NIP").ToString <> "" Then nip = TrowLab("NIP") Else nip = "-"
        Dim DrRequest As String = TrowLab("dokterrequest")
        Dim caraambil As String = TrowLab("caraambil")

        Dim splitcompany() As String = TrowLab("nojenisbayar").ToString.Split("-")

        If CheckSQL("select * from mastercompany where NoCompany = '" & splitcompany(1) & "' and ReportHasilPerusahaan = 0") = True And TrowLab("nourut").ToString.Trim.Contains("M") = True Then
            Pengirim = "Atas Permintaan Sendiri"
        End If

        If IsDBNull(TrowLab("SendingWhatsapp")) = False And TrowLab("SendingWhatsapp").ToString.Trim <> "-" And TrowLab("SendingWhatsapp").ToString.Trim <> "" Then
            NoWhatsappCustomer = TrowLab("SendingWhatsapp")
            TempWhatsapp = NoWhatsappCustomer.Substring(0, 3) & "*****" & NoWhatsappCustomer.Substring(8, NoWhatsappCustomer.Length - 8)
            caraambil = caraambil.Replace(NoWhatsappCustomer, TempWhatsapp)
        Else
            NoWhatsappCustomer = "-"
        End If

        If IsDBNull(TrowLab("SendingEmail")) = False And TrowLab("SendingEmail").ToString.Trim <> "-" Then
            EmailCustomer = TrowLab("SendingEmail")
            TempEmail = EmailCustomer.Substring(0, 3) & "*****" & EmailCustomer.Substring(8, EmailCustomer.Length - 8)
            caraambil = caraambil.Replace(EmailCustomer, TempEmail)
        Else
            EmailCustomer = "-"
        End If

        If IsDBNull(TrowLab("Saran")) = False Then Tsaran = TrowLab("Saran")
        If IsDBNull(TrowLab("Kesimpulan")) = False Then Tsimpul = TrowLab("Kesimpulan")

        Dim Nama As String = TrowLab("nama").ToString.Trim
        Dim numberic As Boolean = False

        For Each str As Char In Nama
            If IsNumeric(str) Then
                numberic = True
                Exit For
            End If
        Next

        Dim Tgelar As String = Gelar(Year(Now()) - Year(TrowLab("tgllahir")), TrowLab("sex").ToString.Trim)

        For Each Trow As DataRow In Tbls.Rows
            Trow("Registrasi") = TrowLab("nomitra").ToString.Trim
            Trow("barcodenotrans") = idlabinternet
            If (TrowLab("nourut").ToString.Trim.Contains("M")) Then
                If numberic = True Then
                    Trow("Nama") = Tgelar & " " & Nama & "/(" & TrowLab("sex").ToString.Trim & ")" & vbCrLf
                Else
                    Trow("Nama") = Tgelar & " " & Nama & " / " & ptnik & " (" & TrowLab("sex").ToString.Trim & ")" & vbCrLf
                End If
            Else
                Trow("Nama") = Tgelar & " " & Nama & "/(" & TrowLab("sex").ToString.Trim & ")" & vbCrLf
            End If

            Dim Tgltemp As Date = TrowLab("tgllahir")
            If Tgltemp.Date.AddYears(120).Year < DateAndTime.Now.Year Then
                Trow("Umur") = ""
            Else
                Trow("Umur") = Format(TrowLab("tgllahir"), "dd MMM yyyy") & " / " & Umur(TrowLab("tgllahir"))
            End If

            'Penambahan NIP
            If nip <> "-" Then
                Trow("Alamat") = TrowLab("alamat") & " / " & nip
            Else
                Trow("Alamat") = TrowLab("alamat")
            End If

            Trow("NoTransaksi") = TrowLab("nourut") & " (" & idlabinternet & ")"
            Trow("DrPelaksana") = DrPelaksanaKlinik
            Trow("Hasil") = caraambil

            If Pengirim <> "" Then
                Trow("DrRequest") = Pengirim
            Else
                If IsNumeric(DrRequest.ToString.Trim) = True Or DrRequest.ToString.Trim = "" Or TrowLab("nourut").Contains("M") Then
                    Trow("DrRequest") = splitcompany(0)
                Else
                    Trow("DrRequest") = DrRequest
                End If
            End If

            Trow("Tanggal") = Format(TrowLab("tgllab"), "dd-MMM-yyyy")
            Trow("Satuan") = Trow("Satuan").ToString
            Dim Tkriteria As String = ""
            If TrowLab("sex").ToString.Trim = "L" Then
                'display hasil pria
                Tkriteria = Trow("Pria").ToString
            ElseIf TrowLab("sex").ToString.Trim = "P" Then
                'display hasil wanita
                Tkriteria = Trow("Wanita").ToString
            Else
                MsgBox("Report Tidak bisa di-Display karena Jenis Kelamin tidak terdefinisi. Update Jenis Kelamin terlebih dahulu.")
                Exit Sub
            End If
            Trow("Standart P/W") = Tkriteria

            If Tsimpul <> "" And Tsaran <> "" Then
                Trow("KesimpulanAll") = "Kesimpulan :" + vbCrLf + Tsimpul + vbCrLf + vbCrLf + "Saran :" + vbCrLf + Tsaran
            ElseIf Tsimpul <> "" Then
                Trow("KesimpulanAll") = "Kesimpulan :" + vbCrLf + Tsimpul
            ElseIf Tsaran <> "" Then
                Trow("KesimpulanAll") = "Saran :" + vbCrLf + Tsaran
            End If
        Next

        Report = New XtraReport
        Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\Hasil\HasilLabNonKop.repx", True)
        'Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\Hasil\HasilLabKop.repx", True)

        Report.Bands.Item(BandKind.ReportFooter).Controls("ttd").Visible = True
        Report.Bands.Item(BandKind.ReportFooter).Controls("ttd").Height = 134
        Report.Bands.Item(BandKind.ReportFooter).Controls("ttd").Width = 250

        'Set Desain False
        If TrowLab("StatusKesehatanThorax") = "UNFIT" = True Or TrowLab("StatusKesehatanLab") = "UNFIT" Or TrowLab("StatusKesehatanFisik") = "UNFIT" Then
            Report.Bands.Item(BandKind.ReportFooter).Controls("desainunfit").Visible = True
        ElseIf TrowLab("StatusKesehatanThorax") = "UNFIT SEMENTARA" = True Or TrowLab("StatusKesehatanLab") = "UNFIT SEMENTARA" Or TrowLab("StatusKesehatanFisik") = "UNFIT SEMENTARA" Then
            Report.Bands.Item(BandKind.ReportFooter).Controls("desainunfitsementara").Visible = True
        ElseIf TrowLab("StatusKesehatanThorax") = "FIT DENGAN CATATAN" = True Or TrowLab("StatusKesehatanLab") = "FIT DENGAN CATATAN" Or TrowLab("StatusKesehatanFisik") = "FIT DENGAN CATATAN" Then
            Report.Bands.Item(BandKind.ReportFooter).Controls("desainfitdengancatatan").Visible = True
        ElseIf TrowLab("StatusKesehatanThorax") = "FIT" = True Or TrowLab("StatusKesehatanLab") = "FIT" Or TrowLab("StatusKesehatanFisik") = "FIT" Then
            Report.Bands.Item(BandKind.ReportFooter).Controls("desainfit").Visible = True
        End If

        Report.DataSource = Tbls
        Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MM-yyyy HH:mm:ss") + " by " + userUploadMCU

        'Report.ShowPreview()
        Report.Print()

        'SavePDF
        'Dim NameFile As String = TrowLab("nourut")
        'Dim PathFolder As String = ReadSQLNIK("select StrValue from MsConfig where ConfigName='PathAutoSaveInvoice'")
        'PathFolder = PathFolder & "INVOICE_LAB" & "\" & Format(DateAndTime.Now, "yyyy") & "\" & Format(DateAndTime.Now, "MMMM") & "\" & Format(DateAndTime.Now, "dd") & ""

        'If (Not System.IO.Directory.Exists(PathFolder)) Then
        '    System.IO.Directory.CreateDirectory(PathFolder)
        'End If

        'Dim filepath As String = PathFolder & "\" & NameFile & ".pdf"
        'If File.Exists(filepath) Then
        '    My.Computer.FileSystem.DeleteFile(filepath)
        'End If
        'Report.CreatePdfDocument(filepath)

        WriteThemysql("update transaksilab set tglcetakhasil=now(), labcetak=now() , Status='TAKEIT' , usercetakhasil='" & userUploadMCU & "' ,closedinputhasil=1 where idlabinternet='" & idlabinternet & "'", DB_Poliklinik)
    End Sub

    Public Sub printthorax(ByVal idlabinternet As String, ByVal idtempatlab As String)
        Dim TempWhatsapp As String = ""
        Dim TempEmail As String = ""

        Dim Tlab As DataTable = ReadThemysql("SELECT a.SendingWhatsapp, a.SendingEmail, b.PTNIK, b.NIP, a.caraambil, a.dokterrequest, c.nojenisbayar, b.nama, b.nomitra, a.nourut, b.sex, DATE(b.tgllahir) AS tgllahir, b.alamat, DATE(a.tgllab) AS tgllab" & _
                                             " FROM transaksilab a" & _
                                             " LEFT JOIN masterpasien b ON a.idpasien=b.nomitra AND a.idtempatlab=b.cabang" & _
                                             " LEFT JOIN transaksilabbayar c ON a.idlabinternet=c.idlabinternet" & _
                                             " WHERE a.idlabinternet='" & idlabinternet & "' AND a.idtempatlab='" & idtempatlab & "'", DB_Poliklinik)

        Dim TrowLab As DataRow = Tlab.Rows(0)
        Dim ptnik As String = ""
        Dim nip As String = ""
        Dim Pengirim As String = ""
        If IsDBNull(TrowLab("PTNIK")) = False Then ptnik = TrowLab("PTNIK") Else ptnik = "-"
        If IsDBNull(TrowLab("NIP")) = False And TrowLab("NIP").ToString <> "-" And TrowLab("NIP").ToString <> "" Then nip = TrowLab("NIP") Else nip = "-"
        Dim DrRequest As String = TrowLab("dokterrequest")
        Dim caraambil As String = TrowLab("caraambil")

        Dim splitcompany() As String = TrowLab("nojenisbayar").ToString.Split("-")

        If CheckSQL("select * from mastercompany where NoCompany = '" & splitcompany(1) & "' and ReportHasilPerusahaan = 0") = True And TrowLab("nourut").ToString.Trim.Contains("M") = True Then
            Pengirim = "Atas Permintaan Sendiri"
        End If

        If IsDBNull(TrowLab("SendingWhatsapp")) = False And TrowLab("SendingWhatsapp").ToString.Trim <> "-" And TrowLab("SendingWhatsapp").ToString.Trim <> "" Then
            NoWhatsappCustomer = TrowLab("SendingWhatsapp")
            TempWhatsapp = NoWhatsappCustomer.Substring(0, 3) & "*****" & NoWhatsappCustomer.Substring(8, NoWhatsappCustomer.Length - 8)
            caraambil = caraambil.Replace(NoWhatsappCustomer, TempWhatsapp)
        Else
            NoWhatsappCustomer = "-"
        End If

        If IsDBNull(TrowLab("SendingEmail")) = False And TrowLab("SendingEmail").ToString.Trim <> "-" Then
            EmailCustomer = TrowLab("SendingEmail")
            TempEmail = EmailCustomer.Substring(0, 3) & "*****" & EmailCustomer.Substring(8, EmailCustomer.Length - 8)
            caraambil = caraambil.Replace(EmailCustomer, TempEmail)
        Else
            EmailCustomer = "-"
        End If

        Dim Nama As String = TrowLab("nama").ToString.Trim
        Dim numberic As Boolean = False

        For Each str As Char In Nama
            If IsNumeric(str) Then
                numberic = True
                Exit For
            End If
        Next

        Dim Tgelar As String = Gelar(Year(Now()) - Year(TrowLab("tgllahir")), TrowLab("sex").ToString.Trim)

        Dim Kesan As String = ""

        Dim Tempthorax As DataTable = ReadThemysql("select * from transaksilabhasillain where idlabinternet='" & idlabinternet & "'", DB_Poliklinik)
        insertRowToTbls(Tempthorax, "typstring", "Registrasi")
        insertRowToTbls(Tempthorax, "typstring", "Nama")
        insertRowToTbls(Tempthorax, "typstring", "barcodenotrans")
        insertRowToTbls(Tempthorax, "typstring", "Umur")
        insertRowToTbls(Tempthorax, "typstring", "Alamat")
        insertRowToTbls(Tempthorax, "typstring", "NoTransaksi")
        insertRowToTbls(Tempthorax, "typstring", "DrPelaksana")
        insertRowToTbls(Tempthorax, "typstring", "DrRequest")
        insertRowToTbls(Tempthorax, "typstring", "Tanggal")
        insertRowToTbls(Tempthorax, "typstring", "Hasil")
        For Each Trow As DataRow In Tempthorax.Rows
            Trow("Registrasi") = TrowLab("nomitra").ToString.Trim
            Trow("barcodenotrans") = idlabinternet
            If (TrowLab("nourut").ToString.Trim.Contains("M")) Then
                If numberic = True Then
                    Trow("Nama") = Tgelar & " " & Nama & "/(" & TrowLab("sex").ToString.Trim & ")" & vbCrLf
                Else
                    Trow("Nama") = Tgelar & " " & Nama & " / " & ptnik & " (" & TrowLab("sex").ToString.Trim & ")" & vbCrLf
                End If
            Else
                Trow("Nama") = Tgelar & " " & Nama & "/(" & TrowLab("sex").ToString.Trim & ")" & vbCrLf
            End If

            Dim Tgltemp As Date = TrowLab("tgllahir")
            If Tgltemp.Date.AddYears(120).Year < DateAndTime.Now.Year Then
                Trow("Umur") = ""
            Else
                Trow("Umur") = Format(TrowLab("tgllahir"), "dd MMM yyyy") & " / " & Umur(TrowLab("tgllahir"))
            End If

            'Penambahan NIP
            If nip <> "-" Then
                Trow("Alamat") = TrowLab("alamat") & " / " & nip
            Else
                Trow("Alamat") = TrowLab("alamat")
            End If

            Trow("NoTransaksi") = TrowLab("nourut") & " (" & idlabinternet & ")"
            Trow("DrPelaksana") = DrPelaksanaKlinik
            Trow("Hasil") = caraambil

            If Pengirim <> "" Then
                Trow("DrRequest") = Pengirim
            Else
                If IsNumeric(DrRequest.ToString.Trim) = True Or DrRequest.ToString.Trim = "" Or TrowLab("nourut").Contains("M") Then
                    Trow("DrRequest") = splitcompany(0)
                Else
                    Trow("DrRequest") = DrRequest
                End If
            End If

            Trow("Tanggal") = Format(TrowLab("tgllab"), "dd-MMM-yyyy")

            Kesan = Trow("kesimpulan")
        Next

        Report = New XtraReport
        Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\Hasil\HasilLabThoraxNonKop.repx", True)
        Report.Bands.Item(BandKind.PageHeader).Controls("ttd").Visible = True
        Report.Bands.Item(BandKind.PageHeader).Controls("ttd").Height = 134
        Report.Bands.Item(BandKind.PageHeader).Controls("ttd").Width = 250

        Dim TblsKesimpulan As DataTable = ReadSQL("SELECT StatusKesehatanThorax, Saran FROM MasterNilaiHasilThorax WHERE Kesimpulan = '" & Kesan & "'")
        If TblsKesimpulan.Rows.Count > 0 Then
            Dim Tsimpul As DataRow = TblsKesimpulan.Rows(0)

            Report.Bands.Item(BandKind.PageHeader).Controls("lblkesimpulan").Visible = True
            Report.Bands.Item(BandKind.PageHeader).Controls("titikduakesimpulan").Visible = True
            Report.Bands.Item(BandKind.PageHeader).Controls("txkesimpulan").Visible = True
            Report.Bands.Item(BandKind.PageHeader).Controls("txkesimpulan").Text = Tsimpul("StatusKesehatanThorax").ToString.Trim

            If Tsimpul("Saran").ToString.Trim <> "-" Then
                Report.Bands.Item(BandKind.PageHeader).Controls("lblsaran").Visible = True
                Report.Bands.Item(BandKind.PageHeader).Controls("titikduasaran").Visible = True
                Report.Bands.Item(BandKind.PageHeader).Controls("txsaran").Visible = True
                Report.Bands.Item(BandKind.PageHeader).Controls("txsaran").Text = Tsimpul("Saran").ToString.Trim
            End If
        End If

        If Tempthorax.Rows.Count > 0 Then
            Report.DataSource = Tempthorax
            Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MM-yyyy HH:mm:ss") + " by " + userUploadMCU

            If Kesan.Contains("Hamil") = False Then
                Report.Print()
                'Report.ShowPreview()
            End If
        End If
    End Sub

    Public Sub printfisik(ByVal idlabinternet As String, ByVal idtempatlab As String)
        Dim Tempfisik As DataTable = ReadThemysql("select HasilFisikID,FisikNoUrut,FisikKet,REPLACE(replace(result,'.',''),'~',' ') as Result from transaksilabfisik where idlabinternet='" & idlabinternet & "' and ((FisikNoUrut between 3006 AND 3028) OR FisikNoUrut = 4001) order by FisikNoUrut", DB_Poliklinik)

        insertRowToTbls(Tempfisik, "typstring", "Registrasi")
        insertRowToTbls(Tempfisik, "typstring", "Nama")
        insertRowToTbls(Tempfisik, "typstring", "Umur")
        insertRowToTbls(Tempfisik, "typstring", "Alamat")
        insertRowToTbls(Tempfisik, "typstring", "NoTransaksi")
        insertRowToTbls(Tempfisik, "typstring", "DrPelaksana")
        insertRowToTbls(Tempfisik, "typstring", "DrRequest")
        insertRowToTbls(Tempfisik, "typstring", "Tanggal")
        insertRowToTbls(Tempfisik, "typstring", "Indent1")
        insertRowToTbls(Tempfisik, "typstring", "Indent2")
        insertRowToTbls(Tempfisik, "typstring", "Titikdua")
        insertRowToTbls(Tempfisik, "typstring", "barcode")
        insertRowToTbls(Tempfisik, "typstring", "Hasil")

        Dim TempWhatsapp As String = ""
        Dim TempEmail As String = ""

        Dim Tlab As DataTable = ReadThemysql("SELECT a.SendingWhatsapp, a.SendingEmail, b.PTNIK, b.NIP, a.caraambil, a.dokterrequest, c.nojenisbayar, b.nama, b.nomitra, a.nourut, b.sex, DATE(b.tgllahir) AS tgllahir, b.alamat, DATE(a.tgllab) AS tgllab" & _
                                             " FROM transaksilab a" & _
                                             " LEFT JOIN masterpasien b ON a.idpasien=b.nomitra AND a.idtempatlab=b.cabang" & _
                                             " LEFT JOIN transaksilabbayar c ON a.idlabinternet=c.idlabinternet" & _
                                             " WHERE a.idlabinternet='" & idlabinternet & "' AND a.idtempatlab='" & idtempatlab & "'", DB_Poliklinik)

        Dim TrowLab As DataRow = Tlab.Rows(0)
        Dim ptnik As String = ""
        Dim nip As String = ""
        Dim Pengirim As String = ""
        If IsDBNull(TrowLab("PTNIK")) = False Then ptnik = TrowLab("PTNIK") Else ptnik = "-"
        If IsDBNull(TrowLab("NIP")) = False And TrowLab("NIP").ToString <> "-" And TrowLab("NIP").ToString <> "" Then nip = TrowLab("NIP") Else nip = "-"
        Dim DrRequest As String = TrowLab("dokterrequest")
        Dim caraambil As String = TrowLab("caraambil")

        Dim splitcompany() As String = TrowLab("nojenisbayar").ToString.Split("-")

        If CheckSQL("select * from mastercompany where NoCompany = '" & splitcompany(1) & "' and ReportHasilPerusahaan = 0") = True And TrowLab("nourut").ToString.Trim.Contains("M") = True Then
            Pengirim = "Atas Permintaan Sendiri"
        End If

        If IsDBNull(TrowLab("SendingWhatsapp")) = False And TrowLab("SendingWhatsapp").ToString.Trim <> "-" And TrowLab("SendingWhatsapp").ToString.Trim <> "" Then
            NoWhatsappCustomer = TrowLab("SendingWhatsapp")
            TempWhatsapp = NoWhatsappCustomer.Substring(0, 3) & "*****" & NoWhatsappCustomer.Substring(8, NoWhatsappCustomer.Length - 8)
            caraambil = caraambil.Replace(NoWhatsappCustomer, TempWhatsapp)
        Else
            NoWhatsappCustomer = "-"
        End If

        If IsDBNull(TrowLab("SendingEmail")) = False And TrowLab("SendingEmail").ToString.Trim <> "-" Then
            EmailCustomer = TrowLab("SendingEmail")
            TempEmail = EmailCustomer.Substring(0, 3) & "*****" & EmailCustomer.Substring(8, EmailCustomer.Length - 8)
            caraambil = caraambil.Replace(EmailCustomer, TempEmail)
        Else
            EmailCustomer = "-"
        End If

        Dim Nama As String = TrowLab("nama").ToString.Trim
        Dim numberic As Boolean = False

        For Each str As Char In Nama
            If IsNumeric(str) Then
                numberic = True
                Exit For
            End If
        Next

        Dim Tgelar As String = Gelar(Year(Now()) - Year(TrowLab("tgllahir")), TrowLab("sex").ToString.Trim)

        For Each Trow As DataRow In Tempfisik.Rows
            Trow("Registrasi") = TrowLab("nomitra").ToString.Trim
            If (TrowLab("nourut").ToString.Trim.Contains("M")) Then
                If numberic = True Then
                    Trow("Nama") = Tgelar & " " & Nama & "/(" & TrowLab("sex").ToString.Trim & ")" & vbCrLf
                Else
                    Trow("Nama") = Tgelar & " " & Nama & " / " & ptnik & " (" & TrowLab("sex").ToString.Trim & ")" & vbCrLf
                End If
            Else
                Trow("Nama") = Tgelar & " " & Nama & "/(" & TrowLab("sex").ToString.Trim & ")" & vbCrLf
            End If

            Dim Tgltemp As Date = TrowLab("tgllahir")
            If Tgltemp.Date.AddYears(120).Year < DateAndTime.Now.Year Then
                Trow("Umur") = ""
            Else
                Trow("Umur") = Format(TrowLab("tgllahir"), "dd MMM yyyy") & " / " & Umur(TrowLab("tgllahir"))
            End If

            'Penambahan NIP
            If nip <> "-" Then
                Trow("Alamat") = TrowLab("alamat") & " / " & nip
            Else
                Trow("Alamat") = TrowLab("alamat")
            End If

            Trow("DrPelaksana") = DrPelaksanaKlinik
            Trow("NoTransaksi") = TrowLab("nourut") & " (" & idlabinternet & ")"
            Trow("Hasil") = caraambil

            If Pengirim <> "" Then
                Trow("DrRequest") = Pengirim
            Else
                If IsNumeric(DrRequest.ToString.Trim) = True Or DrRequest.ToString.Trim = "" Or TrowLab("nourut").Contains("M") Then
                    Trow("DrRequest") = splitcompany(0)
                Else
                    Trow("DrRequest") = DrRequest
                End If
            End If

            Trow("Tanggal") = Format(TrowLab("tgllab"), "dd-MMM-yyyy")

            'edit visus mata
            If (Trow("FisikNoUrut") = "3012" Or Trow("FisikNoUrut") = "3013" Or Trow("FisikNoUrut") = "3014" Or Trow("FisikNoUrut") = "3015") And Trow("Result").ToString.Trim <> "" And Trow("Result").ToString.Contains(",") = True Then
                Dim hasil As String = ""
                Dim TsplitHasil() As String = Trow("Result").ToString.Split(",")
                If TsplitHasil(0) = TsplitHasil(1) Then
                    hasil = "ODS " & TsplitHasil(0)
                Else
                    hasil = "OD " & TsplitHasil(0).ToString & " OS " & TsplitHasil(1).ToString
                End If

                Trow("Result") = hasil
            ElseIf (Trow("FisikNoUrut") = "3012" Or Trow("FisikNoUrut") = "3013" Or Trow("FisikNoUrut") = "3014" Or Trow("FisikNoUrut") = "3015") And Trow("Result").ToString.Trim = "" Then
                Trow("Result") = "Tidak dilakukan"
            End If
        Next

        Report = New XtraReport
        Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\Hasil\HasilLabFisik.repx", True)
        Report.DataSource = Tempfisik

        Dim vartb As Double = 0
        Dim varbb As Double = 0

        Dim Tbls As DataTable = ReadThemysql("SELECT a.result, a.fisiknourut, a.dimana, a.kenapa, a.jenis, date(a.kapan) AS kapan from transaksilabfisik a, transaksilab b WHERE a.idlabinternet=b.idlabinternet AND a.nourut=b.nourut AND b.idlabinternet='" & idlabinternet & "'", DB_Poliklinik)
        For Each Trow As DataRow In Tbls.Rows
            If Trow("fisiknourut") = "3059" Then Report.Bands.Item(BandKind.PageHeader).Controls("txdrpelaksana").Text = Trow("result") : GoTo GoBackthis
            If Trow("fisiknourut") = "1401" Then
                vartb = Trow("result")
                Report.Bands.Item(BandKind.GroupHeader).Controls("txtb").Text = Trow("result") : GoTo GoBackthis
            End If
            If Trow("fisiknourut") = "1402" Then
                varbb = Trow("result")
                Report.Bands.Item(BandKind.GroupHeader).Controls("txbb").Text = Trow("result") : GoTo GoBackthis
            End If
            If Trow("fisiknourut") = "3004" Then Report.Bands.Item(BandKind.GroupHeader).Controls("txtensi").Text = Trow("result") : GoTo GoBackthis
            If Trow("fisiknourut") = "3003" Then Report.Bands.Item(BandKind.GroupHeader).Controls("txnadi").Text = Trow("result") : GoTo GoBackthis
            If Trow("fisiknourut") = "3002" Then Report.Bands.Item(BandKind.GroupHeader).Controls("txsuhu").Text = Trow("result") : GoTo GoBackthis
            If Trow("fisiknourut") = "3005" Then Report.Bands.Item(BandKind.GroupHeader).Controls("txrespirasi").Text = Trow("result") : GoTo GoBackthis
            If Trow("fisiknourut") = "3001" Then Report.Bands.Item(BandKind.GroupHeader).Controls("txriwayat").Text = Trow("result") : GoTo GoBackthis
            If Trow("fisiknourut") = "3040" Then Report.Bands.Item(BandKind.ReportFooter).Controls("txtht").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis
            If Trow("fisiknourut") = "3042" Then Report.Bands.Item(BandKind.ReportFooter).Controls("txanorexia").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis
            If Trow("fisiknourut") = "3043" Then Report.Bands.Item(BandKind.ReportFooter).Controls("txmalaria").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis
            If Trow("fisiknourut") = "3044" Then Report.Bands.Item(BandKind.ReportFooter).Controls("txkulit").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis
            If Trow("fisiknourut") = "3045" Then Report.Bands.Item(BandKind.ReportFooter).Controls("txtypoid").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis
            If Trow("fisiknourut") = "3046" Then Report.Bands.Item(BandKind.ReportFooter).Controls("txbbturun").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis
            If Trow("fisiknourut") = "3049" Then Report.Bands.Item(BandKind.ReportFooter).Controls("txambien").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis
            If Trow("fisiknourut") = "3051" Then Report.Bands.Item(BandKind.ReportFooter).Controls("txkencing").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis
            If Trow("fisiknourut") = "3052" Then Report.Bands.Item(BandKind.ReportFooter).Controls("txvertigo").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis

            If Trow("fisiknourut") = "3058" Then
                If Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") = "Ya" Then
                    Report.Bands.Item(BandKind.ReportFooter).Controls("txoperasi").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") & ", " & Format(Trow("kapan"), "yyyy") & " di " & Trow("dimana") & " karena " & Trow("kenapa") : GoTo GoBackthis
                Else
                    Report.Bands.Item(BandKind.ReportFooter).Controls("txoperasi").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis
                End If
            End If

            If Trow("fisiknourut") = "3029" Then
                If Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") = "Ya" Then
                    Report.Bands.Item(BandKind.ReportFooter).Controls("txrs").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") & ", " & Format(Trow("kapan"), "yyyy") & " di " & Trow("dimana") & " karena " & Trow("kenapa") : GoTo GoBackthis
                Else
                    Report.Bands.Item(BandKind.ReportFooter).Controls("txrs").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis
                End If
            End If

            If Trow("fisiknourut") = "3032" Then Report.Bands.Item(BandKind.ReportFooter).Controls("txsehat").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis

            If Trow("fisiknourut") = "3030" Then
                If Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") = "Ya" Then
                    Report.Bands.Item(BandKind.ReportFooter).Controls("txobat").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") & ", " & Trow("jenis") : GoTo GoBackthis
                Else
                    Report.Bands.Item(BandKind.ReportFooter).Controls("txobat").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis
                End If
            End If

            If Trow("fisiknourut") = "3031" Then
                If Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") = "Ya" Then
                    Report.Bands.Item(BandKind.ReportFooter).Controls("txnarkoba").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") & ", " & Format(Trow("kapan"), "yyyy") & " jenis " & Trow("jenis") : GoTo GoBackthis
                Else
                    Report.Bands.Item(BandKind.ReportFooter).Controls("txnarkoba").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis
                End If
            End If

            If Trow("fisiknourut") = "3039" Then
                If Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") = "Ya" Then
                    Report.Bands.Item(BandKind.ReportFooter).Controls("txhepa").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") & ", " & Format(Trow("kapan"), "yyyy") : GoTo GoBackthis
                Else
                    Report.Bands.Item(BandKind.ReportFooter).Controls("txhepa").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis
                End If
            End If

            If Trow("fisiknourut") = "3041" Then
                If Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") = "Ya" Then
                    Report.Bands.Item(BandKind.ReportFooter).Controls("txtbc").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") & ", " & Format(Trow("kapan"), "dd") & " " & BulanIndonesia(Format(Trow("kapan"), "MM")) & " " & Format(Trow("kapan"), "yyyy") : GoTo GoBackthis
                Else
                    Report.Bands.Item(BandKind.ReportFooter).Controls("txtbc").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis
                End If
            End If

            If Trow("fisiknourut") = "3047" Then
                If Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") = "Ya" Then
                    Report.Bands.Item(BandKind.ReportFooter).Controls("txhernia").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") & ", " & Format(Trow("kapan"), "yyyy") : GoTo GoBackthis
                Else
                    Report.Bands.Item(BandKind.ReportFooter).Controls("txhernia").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis
                End If
            End If

            If Trow("fisiknourut") = "3048" Then
                If Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") = "Ya" Then
                    Report.Bands.Item(BandKind.ReportFooter).Controls("txsakitjantung").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") & ", " & Format(Trow("kapan"), "yyyy") : GoTo GoBackthis
                Else
                    Report.Bands.Item(BandKind.ReportFooter).Controls("txsakitjantung").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis
                End If
            End If

            If Trow("fisiknourut") = "3050" Then
                If Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") = "Ya" Then
                    Report.Bands.Item(BandKind.ReportFooter).Controls("txhipertensi").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") & ", " & Format(Trow("kapan"), "yyyy") : GoTo GoBackthis
                Else
                    Report.Bands.Item(BandKind.ReportFooter).Controls("txhipertensi").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis
                End If
            End If

            If Trow("fisiknourut") = "3053" Then
                If Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") = "Ya" Then
                    Report.Bands.Item(BandKind.ReportFooter).Controls("txepilepsi").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") & ", " & Format(Trow("kapan"), "yyyy") : GoTo GoBackthis
                Else
                    Report.Bands.Item(BandKind.ReportFooter).Controls("txepilepsi").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis
                End If
            End If

            If Trow("fisiknourut") = "3057" Then
                If Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") = "Ya" Then
                    Report.Bands.Item(BandKind.ReportFooter).Controls("txdiabetes").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") & ", " & Format(Trow("kapan"), "yyyy") : GoTo GoBackthis
                Else
                    Report.Bands.Item(BandKind.ReportFooter).Controls("txdiabetes").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis
                End If
            End If

            If Trow("fisiknourut") = "3054" Then Report.Bands.Item(BandKind.ReportFooter).Controls("txpingsan").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis
            If Trow("fisiknourut") = "3055" Then Report.Bands.Item(BandKind.ReportFooter).Controls("txgastritis").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis
            If Trow("fisiknourut") = "3056" Then Report.Bands.Item(BandKind.ReportFooter).Controls("txpusing").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis

            If Trow("fisiknourut") = "3033" Then Report.Bands.Item(BandKind.ReportFooter).Controls("txrokok").Text = Trow("result") : GoTo GoBackthis
            If Trow("fisiknourut") = "3034" Then Report.Bands.Item(BandKind.ReportFooter).Controls("txalkohol").Text = Trow("result") : GoTo GoBackthis
            If Trow("fisiknourut") = "3035" Then Report.Bands.Item(BandKind.ReportFooter).Controls("txkopi").Text = Trow("result") : GoTo GoBackthis
            If Trow("fisiknourut") = "3036" Then Report.Bands.Item(BandKind.ReportFooter).Controls("txpolamakan").Text = Trow("result") : GoTo GoBackthis
            If Trow("fisiknourut") = "3037" Then Report.Bands.Item(BandKind.ReportFooter).Controls("txistirahat").Text = Trow("result") : GoTo GoBackthis
            If Trow("fisiknourut") = "3038" Then Report.Bands.Item(BandKind.ReportFooter).Controls("txolahraga").Text = Trow("result") : GoTo GoBackthis
            If Trow("fisiknourut") = "3060" Then Report.Bands.Item(BandKind.ReportFooter).Controls("txsimpul").Text = Trow("result") : GoTo GoBackthis

            If Trow("fisiknourut") = "3061" Then
                If Trow("result").ToString.Trim = "" Then
                    Report.Bands.Item(BandKind.ReportFooter).Controls("lblsaran").Visible = False
                    Report.Bands.Item(BandKind.ReportFooter).Controls("titikduasaran").Visible = False
                End If

                Report.Bands.Item(BandKind.ReportFooter).Controls("txsaran").Text = Trow("result") : GoTo GoBackthis
            End If

GoBackthis:
        Next

        Report.Bands.Item(BandKind.GroupHeader).Controls("txbmi").Text = Math.Round(CDbl(varbb / (vartb * vartb) * 10000), 1)
        Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MM-yyyy HH:mm:ss") + " by " + userUploadMCU
        Report.Bands.Item(BandKind.PageHeader).Controls("nomorijinklinik").Text = ReadSQLNIK("select StrValue from MsConfig where ConfigName='NomorIjinLab'")

        If Tempfisik.Rows.Count > 0 Then
            Report.Print()
            'Report.ShowPreview()
        End If
    End Sub

    Public Sub CetakLaporanFisik(ByVal idTransaksi As String, ByVal kodeLokasi As String)
        ' Set Data Transaksi Fisik
        Dim tblPemeriksaanFisik As DataTable = ReadThemysql("SELECT HasilFisikID, FisikNoUrut, FisikKet, REPLACE(result,'~',' ') AS Result FROM transaksilabfisik WHERE idlabinternet = '" & idTransaksi & "' and ((FisikNoUrut between 3006 AND 3028) OR FisikNoUrut = 4001) order by FisikNoUrut", DB_Poliklinik)
        tblPemeriksaanFisik.TableName = "DetailPemeriksaanFisik"

        ' Set Data Pasien
        Dim tblDetailPasien As DataTable = GetDataHeaderReport(idTransaksi, kodeLokasi)
        tblDetailPasien.TableName = "DetailTransaksi"

        ' Set Data Riwayat Kesehatan
        Dim tblDetailPemeriksaan As DataTable = GetDataDetailPemeriksaan(idTransaksi, kodeLokasi)
        tblDetailPemeriksaan.TableName = "DetailPemeriksaan"

        For Each Trow As DataRow In tblPemeriksaanFisik.Rows
            ' Edit Tampilan Visus Mata
            If (Trow("FisikNoUrut") = "3012" Or Trow("FisikNoUrut") = "3013" Or Trow("FisikNoUrut") = "3014" Or Trow("FisikNoUrut") = "3015") And Trow("Result").ToString.Trim <> "" And Trow("Result").ToString.Contains(",") = True Then
                Dim hasil As String = ""

                Dim TsplitHasil() As String = Trow("Result").ToString.Split(",")
                If TsplitHasil(0) = TsplitHasil(1) Then
                    hasil = "ODS: " & TsplitHasil(0)
                Else
                    hasil = "OD: " & TsplitHasil(0).ToString & ", OS: " & TsplitHasil(1).ToString
                End If

                Trow("Result") = hasil
            ElseIf (Trow("FisikNoUrut") = "3012" Or Trow("FisikNoUrut") = "3013" Or Trow("FisikNoUrut") = "3014" Or Trow("FisikNoUrut") = "3015") And Trow("Result").ToString.Trim = "" Then
                Trow("Result") = "Tidak dilakukan"
            End If
        Next

        Report = New XtraReport
        Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\Hasil\HasilLabFisikOnline.repx", True)

        Dim dataSet As New DataSet()
        dataSet.Tables.Add(tblPemeriksaanFisik.Copy())
        dataSet.Tables.Add(tblDetailPasien.Copy())
        dataSet.Tables.Add(tblDetailPemeriksaan.Copy())

        Report.DataSource = dataSet

        If tblPemeriksaanFisik.Rows.Count > 0 Then
            Report.Print()
        End If
    End Sub

    Function GetDataHeaderReport(ByVal idTransaksi As String, ByVal kodeLokasi As String) As DataTable
        Dim tblDetailPasien As New DataTable
        Dim queryBuilder As New StringBuilder()

        ' Set Table Detail Pasien
        insertRowToTbls(tblDetailPasien, "Typstring", "Registrasi")
        insertRowToTbls(tblDetailPasien, "Typstring", "Nama")
        insertRowToTbls(tblDetailPasien, "typstring", "Umur")
        insertRowToTbls(tblDetailPasien, "typstring", "Alamat")
        insertRowToTbls(tblDetailPasien, "typstring", "NoTransaksi")
        insertRowToTbls(tblDetailPasien, "typstring", "DrPelaksana")
        insertRowToTbls(tblDetailPasien, "typstring", "DrRequest")
        insertRowToTbls(tblDetailPasien, "typstring", "Tanggal")
        insertRowToTbls(tblDetailPasien, "typstring", "Hasil")
        insertRowToTbls(tblDetailPasien, "typstring", "Saran")
        insertRowToTbls(tblDetailPasien, "typstring", "Kesimpulan")
        insertRowToTbls(tblDetailPasien, "typstring", "InfoCetak")
        insertRowToTbls(tblDetailPasien, "typstring", "NomorIzinKlinik")

        ' Query Transaksi
        queryBuilder.AppendLine("SELECT a.SendingWhatsapp, a.SendingEmail, b.PTNIK, b.NIP, a.caraambil, a.dokterrequest, c.nojenisbayar, b.nama, b.nomitra, a.nourut, b.sex, DATE(b.tgllahir) AS tgllahir, b.alamat, DATE(a.tgllab) AS tgllab, a.Kesimpulan, a.Saran")
        queryBuilder.AppendLine("FROM transaksilab a")
        queryBuilder.AppendLine("     LEFT JOIN masterpasien b ON a.idpasien=b.nomitra AND a.idtempatlab=b.cabang")
        queryBuilder.AppendLine("     LEFT JOIN transaksilabbayar c ON a.idlabinternet = c.idlabinternet")
        queryBuilder.AppendLine("WHERE a.idlabinternet='" & idTransaksi & "' AND a.idtempatlab='" & kodeLokasi & "'")

        Dim tblTransaksi As DataTable = ReadThemysql(queryBuilder.ToString(), DB_Poliklinik)
        Dim rowTransaksi As DataRow = tblTransaksi.Rows(0)

        ' Set No Rekam Medis Pasien
        Dim noRekamMedisPasien As String = rowTransaksi("nomitra")

        ' Set Nama Pasien
        Dim namaPasien As String = ""

        ' Set Gelar Pasien
        Dim gelarPasien As String = Gelar(Year(Now()) - Year(rowTransaksi("tgllahir")), rowTransaksi("sex").ToString.Trim)

        If IsDBNull(rowTransaksi("PTNIK")) = False AndAlso rowTransaksi("PTNIK").ToString <> "-" And rowTransaksi("PTNIK").ToString <> "" Then
            namaPasien = gelarPasien & " " & rowTransaksi("nama") & " / " & rowTransaksi("PTNIK") & " (" & rowTransaksi("sex") & ")" & vbCrLf
        Else
            namaPasien = gelarPasien & " " & rowTransaksi("nama") & " (" & rowTransaksi("sex") & ")" & vbCrLf
        End If

        ' Set Umur Pasien
        Dim umurPasien As String = ""
        Dim Tgltemp As Date = rowTransaksi("tgllahir")
        If Tgltemp.Date.AddYears(120).Year > DateAndTime.Now.Year Then
            umurPasien = Format(rowTransaksi("tgllahir"), "dd MMM yyyy") & " / " & Umur(rowTransaksi("tgllahir"))
        End If

        ' Set Alamat Pasien
        Dim alamatPasien As String = ""
        If IsDBNull(rowTransaksi("NIP")) = False AndAlso rowTransaksi("NIP").ToString <> "-" And rowTransaksi("NIP").ToString <> "" Then
            alamatPasien = rowTransaksi("alamat") & " / " & rowTransaksi("NIP")
        Else
            alamatPasien = rowTransaksi("alamat")
        End If

        ' Set No Transaksi Pasien
        Dim noTransaksiPasien As String = rowTransaksi("nourut") & " (" & idTransaksi & ")"

        ' Set Dokter Pengirim
        Dim dokterPengirimPasien As String = ""

        Dim splitcompany() As String = rowTransaksi("nojenisbayar").ToString.Split("-")

        If CheckSQL("SELECT * FROM mastercompany WHERE NoCompany = '" & splitcompany(1) & "' AND ReportHasilPerusahaan = 0") = True And rowTransaksi("nourut").ToString.Trim.Contains("M") = True Then
            dokterPengirimPasien = "Atas Permintaan Sendiri"
        Else
            If IsNumeric(rowTransaksi("dokterrequest").ToString) = True Or rowTransaksi("dokterrequest").ToString = "" Or rowTransaksi("nourut").Contains("M") Then
                dokterPengirimPasien = splitcompany(0)
            Else
                dokterPengirimPasien = rowTransaksi("dokterrequest")
            End If
        End If

        Dim TempWhatsapp As String = ""
        Dim TempEmail As String = ""

        ' Set Metode Kirim Hasil
        Dim metodeKirimHasilPasien As String = rowTransaksi("caraambil")

        If IsDBNull(rowTransaksi("SendingWhatsapp")) = False And rowTransaksi("SendingWhatsapp").ToString.Trim <> "-" And rowTransaksi("SendingWhatsapp").ToString.Trim <> "" Then
            NoWhatsappCustomer = rowTransaksi("SendingWhatsapp")
            TempWhatsapp = NoWhatsappCustomer.Substring(0, 3) & "*****" & NoWhatsappCustomer.Substring(8, NoWhatsappCustomer.Length - 8)
            metodeKirimHasilPasien = metodeKirimHasilPasien.Replace(NoWhatsappCustomer, TempWhatsapp)
        Else
            NoWhatsappCustomer = "-"
        End If

        If IsDBNull(rowTransaksi("SendingEmail")) = False And rowTransaksi("SendingEmail").ToString.Trim <> "-" Then
            EmailCustomer = rowTransaksi("SendingEmail")
            TempEmail = EmailCustomer.Substring(0, 3) & "*****" & EmailCustomer.Substring(8, EmailCustomer.Length - 8)
            metodeKirimHasilPasien = metodeKirimHasilPasien.Replace(EmailCustomer, TempEmail)
        Else
            EmailCustomer = "-"
        End If

        ' Set Kesimpulan & Saran
        Dim saranHasilPasien As String = ""
        Dim kesimpulanHasilPasien As String = ""

        If IsDBNull(rowTransaksi("Saran")) = False Then saranHasilPasien = rowTransaksi("Saran")
        If IsDBNull(rowTransaksi("Kesimpulan")) = False Then kesimpulanHasilPasien = rowTransaksi("Kesimpulan")

        ' Add Detail Pasien
        Dim newDetail As DataRow = tblDetailPasien.NewRow
        newDetail("Registrasi") = noRekamMedisPasien
        newDetail("Nama") = namaPasien
        newDetail("Umur") = umurPasien
        newDetail("Alamat") = alamatPasien
        newDetail("NoTransaksi") = noTransaksiPasien
        newDetail("DrPelaksana") = DrPelaksanaKlinik
        newDetail("DrRequest") = dokterPengirimPasien
        newDetail("Tanggal") = Format(rowTransaksi("tgllab"), "dd-MMM-yyyy")
        newDetail("Hasil") = metodeKirimHasilPasien
        newDetail("Saran") = saranHasilPasien
        newDetail("Kesimpulan") = kesimpulanHasilPasien
        newDetail("InfoCetak") = Format(DateAndTime.Now, "dd-MM-yyyy HH:mm:ss") + " by " + userUploadMCU
        newDetail("NomorIzinKlinik") = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NomorIjinLab'")
        tblDetailPasien.Rows.Add(newDetail)

        Return tblDetailPasien
    End Function

    Function GetDataDetailPemeriksaan(ByVal idTransaksi As String, ByVal kodeLokasi As String) As DataTable
        Dim tblDetailPemeriksaan As New DataTable
        Dim queryBuilder As New StringBuilder()

        ' Set Table Detail
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PemeriksaanTinggiBadan")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PemeriksaanBeratBadan")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PemeriksaanDetakNadi")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PemeriksaanSuhu")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PemeriksaanNafas")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PemeriksaanTensi")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PemeriksaanBMI")

        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "RiwayatOperasi")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "RiwayatRumahSakit")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "RiwayatPengobatanPenyakit")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "RiwayatPenggunaanNarkoba")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "RiwayatKondisiSehat")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "RiwayatPenyakitKeluarga")

        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "KebiasaanRokok")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "KebiasaanAlkohol")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "KebiasaanKopi")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "KebiasaanPolaMakan")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "KebiasaanPolaIstirahat")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "KebiasaanOlahraga")

        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PenyakitHepatitis")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PenyakitTBC")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PenyakitHernia")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PenyakitHipertensi")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PenyakitEpilepsi")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PenyakitDiabetesMellitus")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PenyakitParuNonTBC")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PenyakitSakitJantung")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PenyakitGangguanKulit")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PenyakitMalaria")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PenyakitAmbeien")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PenyakitTHT")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PenyakitKencingBatu")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PenyakitVertigo")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PenyakitAnorexia")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PenyakitPingsan")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PenyakitGastritis")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PenyakitPusing")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PenyakitTypoidFever")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PenyakitTurunBB")

        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "KesimpulanFisik")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "SaranFisik")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "SaranFisikTitikDuaLabel")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "SaranFisikKeteranganLabel")

        ' Query Transaksi
        queryBuilder.AppendLine("SELECT a.*")
        queryBuilder.AppendLine("FROM transaksilabfisik a")
        queryBuilder.AppendLine("LEFT JOIN transaksilab b ON a.idlabinternet = b.idlabinternet AND a.nourut = b.nourut")
        queryBuilder.AppendLine("WHERE a.idlabinternet = '" & idTransaksi & "' AND b.idtempatlab = '" & kodeLokasi & "';")

        Dim tblTransaksi As DataTable = ReadThemysql(queryBuilder.ToString(), DB_Poliklinik)

        ' Set Default Pemeriksaan Fisik Pasien
        Dim pemeriksaanTinggiBadan As Double = 0
        Dim pemeriksaanBeratBadan As Double = 0
        Dim pemeriksaanDetakNadi As String = ""
        Dim pemeriksaanSuhu As String = ""
        Dim pemeriksaanNafas As String = ""
        Dim pemeriksaanTensi As String = ""
        Dim pemeriksaanBMI As String = ""

        ' Set Default Riwayat Kesehatan Pasien
        Dim riwayatOperasi As String = ""
        Dim riwayatRumahSakit As String = ""
        Dim riwayatPengobatanPenyakit As String = ""
        Dim riwayatPenggunaanNarkoba As String = ""
        Dim riwayatKondisiSehat As String = ""
        Dim riwayatPenyakitKeluarga As String = ""

        ' Set Default Kebiasaan Pasien
        Dim kebiasaanRokok As String = ""
        Dim kebiasaanAlkohol As String = ""
        Dim kebiasaanKopi As String = ""
        Dim kebiasaanPolaMakan As String = ""
        Dim kebiasaanPolaIstirahat As String = ""
        Dim kebiasaanOlahraga As String = ""

        ' Set Default Penyakit Pasien
        Dim penyakitHepatitis As String = ""
        Dim penyakitTbc As String = ""
        Dim penyakitHernia As String = ""
        Dim penyakitHipertensi As String = ""
        Dim penyakitEpilepsi As String = ""
        Dim penyakitDiabetesMellitus As String = ""
        Dim penyakitParuNonTbc As String = ""
        Dim penyakitSakitJantung As String = ""
        Dim penyakitGangguanKulit As String = ""
        Dim penyakitMalaria As String = ""
        Dim penyakitAmbeien As String = ""
        Dim penyakitTht As String = ""
        Dim penyakitKencingBatu As String = ""
        Dim penyakitVertigo As String = ""
        Dim penyakitAnorexia As String = ""
        Dim penyakitPingsan As String = ""
        Dim penyakitGastritis As String = ""
        Dim penyakitPusing As String = ""
        Dim penyakitTypoidFever As String = ""
        Dim penyakitTurunBb As String = ""

        ' Set Default Kesimpulan & Saran
        Dim kesimpulanFisik As String = ""
        Dim saranFisik As String = ""
        Dim saranFisikTitikDuaLabel As String = ""
        Dim saranFisikKeteranganLabel As String = ""

        For Each rowTransaksi As DataRow In tblTransaksi.Rows
            'Dim fisikResult As String = Strings.Replace(Strings.Replace(rowTransaksi("result"), ".", ""), "~", "")
            Dim fisikResult As String = rowTransaksi("result")

            ' ################### Pemeriksaan Fisik ################### '
            ' Tinggi Badan
            If rowTransaksi("fisiknourut") = "1401" Then pemeriksaanTinggiBadan = fisikResult : GoTo GoBackthis

            ' Berat Badan
            If rowTransaksi("fisiknourut") = "1402" Then pemeriksaanBeratBadan = fisikResult : GoTo GoBackthis

            ' Detak Nadi
            If rowTransaksi("fisiknourut") = "3003" Then pemeriksaanDetakNadi = fisikResult : GoTo GoBackthis

            ' Suhu
            If rowTransaksi("fisiknourut") = "3002" Then pemeriksaanSuhu = fisikResult : GoTo GoBackthis

            ' Nafas
            If rowTransaksi("fisiknourut") = "3005" Then pemeriksaanNafas = fisikResult : GoTo GoBackthis

            ' Tensi
            If rowTransaksi("fisiknourut") = "3004" Then pemeriksaanTensi = fisikResult : GoTo GoBackthis

            ' ################### Riwayat Kesehatan ################### '
            ' Riwayat Operasi
            If rowTransaksi("fisiknourut") = "3058" Then
                If fisikResult = "Ya" Then
                    riwayatOperasi = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " di " & rowTransaksi("dimana") & " dengan riwayat diagnosis " & rowTransaksi("kenapa") : GoTo GoBackthis
                Else
                    riwayatOperasi = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Riwayat Rumah Sakit
            If rowTransaksi("fisiknourut") = "3029" Then
                If fisikResult = "Ya" Then
                    riwayatRumahSakit = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " di " & rowTransaksi("dimana") & " dengan riwayat diagnosis " & rowTransaksi("kenapa") : GoTo GoBackthis
                Else
                    riwayatRumahSakit = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Riwayat Pengobatan Penyakit
            If rowTransaksi("fisiknourut") = "3030" Then
                If fisikResult = "Ya" Then
                    riwayatPengobatanPenyakit = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " terapi " & rowTransaksi("jenis") & " dengan riwayat diagnosis " & rowTransaksi("kenapa") : GoTo GoBackthis
                Else
                    riwayatPengobatanPenyakit = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Riwayat Penggunaan Narkoba
            If rowTransaksi("fisiknourut") = "3031" Then
                If fisikResult = "Ya" Then
                    riwayatPenggunaanNarkoba = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " jenis " & rowTransaksi("jenis") : GoTo GoBackthis
                Else
                    riwayatPenggunaanNarkoba = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Riwayat Kondisi Sehat
            If rowTransaksi("fisiknourut") = "3032" Then
                If fisikResult = "Tidak" Then
                    riwayatKondisiSehat = fisikResult & ", keluhan " & rowTransaksi("kenapa") : GoTo GoBackthis
                Else
                    riwayatKondisiSehat = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Riwayat Penyakit Keluarga
            If rowTransaksi("fisiknourut") = "4002" Then
                If fisikResult = "Ya" Then
                    riwayatPenyakitKeluarga = fisikResult & ", " & rowTransaksi("kenapa") : GoTo GoBackthis
                Else
                    riwayatPenyakitKeluarga = fisikResult : GoTo GoBackthis
                End If
            End If

            ' ################### Kebiasaan ################### '
            ' Kebiasaan Rokok
            If rowTransaksi("fisiknourut") = "3033" Then kebiasaanRokok = fisikResult : GoTo GoBackthis

            ' Kebiasaan Alkohol
            If rowTransaksi("fisiknourut") = "3034" Then kebiasaanAlkohol = fisikResult : GoTo GoBackthis

            ' Kebiasaan Kopi
            If rowTransaksi("fisiknourut") = "3035" Then kebiasaanKopi = fisikResult : GoTo GoBackthis

            ' Kebiasaan Pola Makan
            If rowTransaksi("fisiknourut") = "3036" Then kebiasaanPolaMakan = fisikResult : GoTo GoBackthis

            ' Kebiasaan Pola Istirahat
            If rowTransaksi("fisiknourut") = "3037" Then kebiasaanPolaIstirahat = fisikResult : GoTo GoBackthis

            ' Kebiasaan Olahraga
            If rowTransaksi("fisiknourut") = "3038" Then kebiasaanOlahraga = fisikResult : GoTo GoBackthis


            ' ################### Penyakit ################### '
            ' Penyakit Hepatitis
            If rowTransaksi("fisiknourut") = "3039" Then
                If fisikResult = "Ya" Then
                    If Not IsDBNull(rowTransaksi("StatusSembuh")) AndAlso Convert.ToBoolean(rowTransaksi("StatusSembuh")) = True Then
                        penyakitHepatitis = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " " & rowTransaksi("kenapa") & " (Sembuh)" : GoTo GoBackthis
                    Else
                        penyakitHepatitis = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " " & rowTransaksi("kenapa") : GoTo GoBackthis
                    End If
                Else
                    penyakitHepatitis = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Penyakit TBC
            If rowTransaksi("fisiknourut") = "3041" Then
                If fisikResult = "Ya" Then
                    If Not IsDBNull(rowTransaksi("StatusSembuh")) AndAlso Convert.ToBoolean(rowTransaksi("StatusSembuh")) = True Then
                        penyakitTbc = fisikResult & ", " & Format(rowTransaksi("kapan"), "dd") & " " & BulanIndonesia(Format(rowTransaksi("kapan"), "MM")) & " " & Format(rowTransaksi("kapan"), "yyyy") & " (Sembuh)" : GoTo GoBackthis
                    Else
                        penyakitTbc = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") : GoTo GoBackthis
                    End If
                Else
                    penyakitTbc = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Penyakit Hernia
            If rowTransaksi("fisiknourut") = "3047" Then
                If fisikResult = "Ya" Then
                    If Not IsDBNull(rowTransaksi("StatusSembuh")) AndAlso Convert.ToBoolean(rowTransaksi("StatusSembuh")) = True Then
                        penyakitHernia = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " (Sembuh)" : GoTo GoBackthis
                    Else
                        penyakitHernia = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") : GoTo GoBackthis
                    End If
                Else
                    penyakitHernia = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Penyakit Hipertensi
            If rowTransaksi("fisiknourut") = "3050" Then
                If fisikResult = "Ya" Then
                    If Not IsDBNull(rowTransaksi("StatusSembuh")) AndAlso Convert.ToBoolean(rowTransaksi("StatusSembuh")) = True Then
                        penyakitHipertensi = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " (Sembuh)" : GoTo GoBackthis
                    Else
                        penyakitHipertensi = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") : GoTo GoBackthis
                    End If
                Else
                    penyakitHipertensi = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Penyakit Epilepsi
            If rowTransaksi("fisiknourut") = "3053" Then
                If fisikResult = "Ya" Then
                    If Not IsDBNull(rowTransaksi("StatusSembuh")) AndAlso Convert.ToBoolean(rowTransaksi("StatusSembuh")) = True Then
                        penyakitEpilepsi = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " (Sembuh)" : GoTo GoBackthis
                    Else
                        penyakitEpilepsi = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") : GoTo GoBackthis
                    End If
                Else
                    penyakitEpilepsi = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Penyakit Diabetes Mellitus
            If rowTransaksi("fisiknourut") = "3057" Then
                If fisikResult = "Ya" Then
                    If Not IsDBNull(rowTransaksi("StatusSembuh")) AndAlso Convert.ToBoolean(rowTransaksi("StatusSembuh")) = True Then
                        penyakitDiabetesMellitus = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " (Sembuh)" : GoTo GoBackthis
                    Else
                        penyakitDiabetesMellitus = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") : GoTo GoBackthis
                    End If
                Else
                    penyakitDiabetesMellitus = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Penyakit Paru Non TBC
            If rowTransaksi("fisiknourut") = "4003" Then
                If fisikResult = "Ya" Then
                    If Not IsDBNull(rowTransaksi("StatusSembuh")) AndAlso Convert.ToBoolean(rowTransaksi("StatusSembuh")) = True Then
                        penyakitParuNonTbc = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " " & rowTransaksi("kenapa") & " (Sembuh)" : GoTo GoBackthis
                    Else
                        penyakitParuNonTbc = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " " & rowTransaksi("kenapa") : GoTo GoBackthis
                    End If
                Else
                    penyakitParuNonTbc = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Penyakit Sakit Jantung
            If rowTransaksi("fisiknourut") = "3048" Then
                If fisikResult = "Ya" Then
                    If Not IsDBNull(rowTransaksi("StatusSembuh")) AndAlso Convert.ToBoolean(rowTransaksi("StatusSembuh")) = True Then
                        penyakitSakitJantung = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " " & rowTransaksi("kenapa") & " (Sembuh)" : GoTo GoBackthis
                    Else
                        penyakitSakitJantung = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " " & rowTransaksi("kenapa") : GoTo GoBackthis
                    End If
                Else
                    penyakitSakitJantung = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Penyakit Gangguan Kulit
            If rowTransaksi("fisiknourut") = "3044" Then
                If fisikResult = "Ya" Then
                    If Not IsDBNull(rowTransaksi("StatusSembuh")) AndAlso Convert.ToBoolean(rowTransaksi("StatusSembuh")) = True Then
                        penyakitGangguanKulit = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " (Sembuh)" : GoTo GoBackthis
                    Else
                        penyakitGangguanKulit = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") : GoTo GoBackthis
                    End If
                Else
                    penyakitGangguanKulit = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Penyakit Malaria
            If rowTransaksi("fisiknourut") = "3043" Then
                If fisikResult = "Ya" Then
                    If Not IsDBNull(rowTransaksi("StatusSembuh")) AndAlso Convert.ToBoolean(rowTransaksi("StatusSembuh")) = True Then
                        penyakitMalaria = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " (Sembuh)" : GoTo GoBackthis
                    Else
                        penyakitMalaria = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") : GoTo GoBackthis
                    End If
                Else
                    penyakitMalaria = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Penyakit Ambeien
            If rowTransaksi("fisiknourut") = "3049" Then
                If fisikResult = "Ya" Then
                    If Not IsDBNull(rowTransaksi("StatusSembuh")) AndAlso Convert.ToBoolean(rowTransaksi("StatusSembuh")) = True Then
                        penyakitAmbeien = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " (Sembuh)" : GoTo GoBackthis
                    Else
                        penyakitAmbeien = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") : GoTo GoBackthis
                    End If
                Else
                    penyakitAmbeien = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Penyakit THT
            If rowTransaksi("fisiknourut") = "3040" Then
                If fisikResult = "Ya" Then
                    If Not IsDBNull(rowTransaksi("StatusSembuh")) AndAlso Convert.ToBoolean(rowTransaksi("StatusSembuh")) = True Then
                        penyakitTht = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " (Sembuh)" : GoTo GoBackthis
                    Else
                        penyakitTht = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") : GoTo GoBackthis
                    End If
                Else
                    penyakitTht = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Penyakit Kencing Batu
            If rowTransaksi("fisiknourut") = "3051" Then
                If fisikResult = "Ya" Then
                    If Not IsDBNull(rowTransaksi("StatusSembuh")) AndAlso Convert.ToBoolean(rowTransaksi("StatusSembuh")) = True Then
                        penyakitKencingBatu = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " (Sembuh)" : GoTo GoBackthis
                    Else
                        penyakitKencingBatu = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") : GoTo GoBackthis
                    End If
                Else
                    penyakitKencingBatu = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Penyakit Vertigo
            If rowTransaksi("fisiknourut") = "3052" Then
                If fisikResult = "Ya" Then
                    If Not IsDBNull(rowTransaksi("StatusSembuh")) AndAlso Convert.ToBoolean(rowTransaksi("StatusSembuh")) = True Then
                        penyakitVertigo = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " (Sembuh)" : GoTo GoBackthis
                    Else
                        penyakitVertigo = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") : GoTo GoBackthis
                    End If
                Else
                    penyakitVertigo = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Penyakit Anorexia
            If rowTransaksi("fisiknourut") = "3042" Then
                If fisikResult = "Ya" Then
                    If Not IsDBNull(rowTransaksi("StatusSembuh")) AndAlso Convert.ToBoolean(rowTransaksi("StatusSembuh")) = True Then
                        penyakitAnorexia = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " (Sembuh)" : GoTo GoBackthis
                    Else
                        penyakitAnorexia = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") : GoTo GoBackthis
                    End If
                Else
                    penyakitAnorexia = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Penyakit Pingsan
            If rowTransaksi("fisiknourut") = "3054" Then
                If fisikResult = "Ya" Then
                    If Not IsDBNull(rowTransaksi("StatusSembuh")) AndAlso Convert.ToBoolean(rowTransaksi("StatusSembuh")) = True Then
                        penyakitPingsan = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " (Sembuh)" : GoTo GoBackthis
                    Else
                        penyakitPingsan = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") : GoTo GoBackthis
                    End If
                Else
                    penyakitPingsan = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Penyakit Gastritis
            If rowTransaksi("fisiknourut") = "3055" Then
                If fisikResult = "Ya" Then
                    If Not IsDBNull(rowTransaksi("StatusSembuh")) AndAlso Convert.ToBoolean(rowTransaksi("StatusSembuh")) = True Then
                        penyakitGastritis = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " (Sembuh)" : GoTo GoBackthis
                    Else
                        penyakitGastritis = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") : GoTo GoBackthis
                    End If
                Else
                    penyakitGastritis = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Penyakit Pusing
            If rowTransaksi("fisiknourut") = "3056" Then
                If fisikResult = "Ya" Then
                    If Not IsDBNull(rowTransaksi("StatusSembuh")) AndAlso Convert.ToBoolean(rowTransaksi("StatusSembuh")) = True Then
                        penyakitPusing = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " (Sembuh)" : GoTo GoBackthis
                    Else
                        penyakitPusing = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") : GoTo GoBackthis
                    End If
                Else
                    penyakitPusing = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Penyakit Typoid Fever
            If rowTransaksi("fisiknourut") = "3045" Then
                If fisikResult = "Ya" Then
                    If Not IsDBNull(rowTransaksi("StatusSembuh")) AndAlso Convert.ToBoolean(rowTransaksi("StatusSembuh")) = True Then
                        penyakitTypoidFever = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " (Sembuh)" : GoTo GoBackthis
                    Else
                        penyakitTypoidFever = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") : GoTo GoBackthis
                    End If
                Else
                    penyakitTypoidFever = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Penyakit Turun BB
            If rowTransaksi("fisiknourut") = "3046" Then
                If fisikResult = "Ya" Then
                    If Not IsDBNull(rowTransaksi("StatusSembuh")) AndAlso Convert.ToBoolean(rowTransaksi("StatusSembuh")) = True Then
                        penyakitTurunBb = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " (Sembuh)" : GoTo GoBackthis
                    Else
                        penyakitTurunBb = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") : GoTo GoBackthis
                    End If
                Else
                    penyakitTurunBb = fisikResult : GoTo GoBackthis
                End If
            End If

            ' ################### Kesimpulan & Saran Fisik ################### '
            ' Kesimpulan Fisik
            If rowTransaksi("fisiknourut") = "3060" Then kesimpulanFisik = fisikResult : GoTo GoBackthis

            ' Saran Fisik
            If rowTransaksi("fisiknourut") = "3061" Then
                If fisikResult <> "" Then
                    saranFisikTitikDuaLabel = ":"
                    saranFisikKeteranganLabel = "SARAN"
                End If

                saranFisik = fisikResult : GoTo GoBackthis
            End If

GoBackthis:
        Next

        ' Set BMI
        pemeriksaanBMI = Math.Round(CDbl(pemeriksaanBeratBadan / (pemeriksaanTinggiBadan * pemeriksaanTinggiBadan) * 10000), 1)

        ' Add Detail Fisik
        Dim newDetail As DataRow = tblDetailPemeriksaan.NewRow

        newDetail("PemeriksaanTinggiBadan") = pemeriksaanTinggiBadan
        newDetail("PemeriksaanBeratBadan") = pemeriksaanBeratBadan
        newDetail("PemeriksaanDetakNadi") = pemeriksaanDetakNadi
        newDetail("PemeriksaanSuhu") = pemeriksaanSuhu
        newDetail("PemeriksaanNafas") = pemeriksaanNafas
        newDetail("PemeriksaanTensi") = pemeriksaanTensi
        newDetail("PemeriksaanBMI") = pemeriksaanBMI

        newDetail("RiwayatOperasi") = riwayatOperasi
        newDetail("RiwayatRumahSakit") = riwayatRumahSakit
        newDetail("RiwayatPengobatanPenyakit") = riwayatPengobatanPenyakit
        newDetail("RiwayatPenggunaanNarkoba") = riwayatPenggunaanNarkoba
        newDetail("RiwayatKondisiSehat") = riwayatKondisiSehat
        newDetail("RiwayatPenyakitKeluarga") = riwayatPenyakitKeluarga

        newDetail("KebiasaanRokok") = kebiasaanRokok
        newDetail("KebiasaanAlkohol") = kebiasaanAlkohol
        newDetail("KebiasaanKopi") = kebiasaanKopi
        newDetail("KebiasaanPolaMakan") = kebiasaanPolaMakan
        newDetail("KebiasaanPolaIstirahat") = kebiasaanPolaIstirahat
        newDetail("KebiasaanOlahraga") = kebiasaanOlahraga

        newDetail("PenyakitHepatitis") = penyakitHepatitis
        newDetail("PenyakitTbc") = penyakitTbc
        newDetail("PenyakitHernia") = penyakitHernia
        newDetail("PenyakitHipertensi") = penyakitHipertensi
        newDetail("PenyakitEpilepsi") = penyakitEpilepsi
        newDetail("PenyakitDiabetesMellitus") = penyakitDiabetesMellitus
        newDetail("PenyakitParuNonTbc") = penyakitParuNonTbc
        newDetail("PenyakitSakitJantung") = penyakitSakitJantung
        newDetail("PenyakitGangguanKulit") = penyakitGangguanKulit
        newDetail("PenyakitMalaria") = penyakitMalaria
        newDetail("PenyakitAmbeien") = penyakitAmbeien
        newDetail("PenyakitTht") = penyakitTht
        newDetail("PenyakitKencingBatu") = penyakitKencingBatu
        newDetail("PenyakitVertigo") = penyakitVertigo
        newDetail("PenyakitAnorexia") = penyakitAnorexia
        newDetail("PenyakitPingsan") = penyakitPingsan
        newDetail("PenyakitGastritis") = penyakitGastritis
        newDetail("PenyakitPusing") = penyakitPusing
        newDetail("PenyakitTypoidFever") = penyakitTypoidFever
        newDetail("PenyakitTurunBb") = penyakitTurunBb

        newDetail("KesimpulanFisik") = kesimpulanFisik
        newDetail("SaranFisik") = saranFisik
        newDetail("SaranFisikTitikDuaLabel") = saranFisikTitikDuaLabel
        newDetail("SaranFisikKeteranganLabel") = saranFisikKeteranganLabel

        tblDetailPemeriksaan.Rows.Add(newDetail)

        Return tblDetailPemeriksaan
    End Function

    Function CreateTableTandaTerima() As DataTable
        Dim Thasil As New DataTable

        insertRowToTbls(Thasil, "Typstring", "Tittle")
        insertRowToTbls(Thasil, "Typstring", "No")
        insertRowToTbls(Thasil, "Typstring", "Jenis Pemeriksaan")
        insertRowToTbls(Thasil, "Typstring", "Jumlah Pasien")
        insertRowToTbls(Thasil, "Typstring", "Keterangan")
        insertRowToTbls(Thasil, "Typstring", "No Paket")
        insertRowToTbls(Thasil, "Typstring", "Note")

        Return Thasil
    End Function

    Private Sub cbNoUrut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbNoUrut.CheckedChanged
        If cbNoUrut.Checked = True Then
            txNoUrut1.Enabled = True
            txNoUrut2.Enabled = True
            txNoUrut1.ResetText()
            txNoUrut2.ResetText()
        ElseIf cbNoUrut.Checked = False Then
            txNoUrut1.Enabled = False
            txNoUrut2.Enabled = False
            txNoUrut1.ResetText()
            txNoUrut2.ResetText()
        End If
    End Sub

    Private Sub txNoUrut1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txNoUrut1.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub txNoUrut2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txNoUrut2.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub ButtonFindCompany_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFindCompany.Click
        Find.Show()
        Find.Query("select IDCompany, CompanyCode, CompanyNama, NoCompany from mastercompany a where getdate() between StartDate and EndDate", " ORDER BY a.idcompany desc", "FindCompanyMonitoringMCU", 2)
    End Sub

    Private Sub ButtonFindLokasi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFindLokasi.Click
        If rdOnline.Checked = True Then
            Find.Show()
            Find.QueryTheMysql("SELECT a.kodecabang AS 'Lokasi ID', a.kodeket AS 'Keterangan Lokasi', a.kodebarcode AS 'Kode Barcode' FROM mastercodebarcode a ORDER BY a.kodeket ASC", " ", "FindCabangUploadMonitoringMCU", 0, Find_Poliklinik)
        End If
    End Sub

    Private Sub ButtonPrintHasilMCU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPrintHasilMCU.Click
        Try
            If CheckingData() = True Then
                thread = New System.Threading.Thread(AddressOf CetakHasil)
                thread.Start()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ButtonClearData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClearData.Click
        GridView1.Columns.Clear()

        ButtonTarikRekapMCU.Enabled = True
        ButtonTandaTerimaMCU.Enabled = True
    End Sub

    Private Sub ButtonTarikRekapMCU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTarikRekapMCU.Click
        Try
            If CheckingData() = True Then
                gridlab.DataSource = CreateDataRekapHasil()
                ButtonTarikRekapMCU.Enabled = False
                Dim saveFileDialog1 As New SaveFileDialog
                saveFileDialog1.Filter = "Excel File|*.xls"
                saveFileDialog1.Title = "Save an Excel File"
                saveFileDialog1.ShowDialog()
                If saveFileDialog1.CheckPathExists = False Then
                    MsgBox("Path tidak ada. Check kembali")
                Else
                    If saveFileDialog1.CheckFileExists = True Then
                        MsgBox("Telah ada data dengan nama tersebut. Rubah nama save")
                    Else
                        gridlab.ExportToExcel(saveFileDialog1.FileName.ToString)
                        MsgBox("Berhasil menyimpan file excel " & saveFileDialog1.FileName.ToString, MsgBoxStyle.Information, "Success!")
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ButtonTandaTerimaMCU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTandaTerimaMCU.Click
        Try
            If CheckingData() = True Then
                Report = New XtraReport
                Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\RekapTandaTerimaMCU.repx", True)

                Dim status As String = ""
                Dim keterangan As String = ""
                Dim varNote As String = InputBox("Masukkan note untuk tanda terima : ", "Note Tanda Terima", 2)

                If cmbstatustransaksi.SelectedIndex = 1 Then
                    status = " AND (a.StatusKesehatanLab NOT IN ('UNFIT', 'UNFIT SEMENTARA', 'FIT DENGAN CATATAN') AND a.StatusKesehatanThorax NOT IN ('UNFIT', 'UNFIT SEMENTARA', 'FIT DENGAN CATATAN') AND a.StatusKesehatanFisik NOT IN ('UNFIT', 'UNFIT SEMENTARA', 'FIT DENGAN CATATAN')) AND (a.StatusKesehatanLab = 'FIT' OR a.StatusKesehatanThorax = 'FIT' OR a.StatusKesehatanFisik = 'FIT') "
                ElseIf cmbstatustransaksi.SelectedIndex = 2 Then
                    status = " AND (a.StatusKesehatanLab NOT IN ('UNFIT', 'UNFIT SEMENTARA') AND a.StatusKesehatanThorax NOT IN ('UNFIT', 'UNFIT SEMENTARA') AND a.StatusKesehatanFisik NOT IN ('UNFIT', 'UNFIT SEMENTARA')) AND (a.StatusKesehatanLab = 'FIT DENGAN CATATAN' OR a.StatusKesehatanThorax = 'FIT DENGAN CATATAN' OR a.StatusKesehatanFisik = 'FIT DENGAN CATATAN') "
                ElseIf cmbstatustransaksi.SelectedIndex = 3 Then
                    status = " AND (a.StatusKesehatanLab NOT IN ('UNFIT') AND a.StatusKesehatanThorax NOT IN ('UNFIT') AND a.StatusKesehatanFisik NOT IN ('UNFIT')) AND (a.StatusKesehatanLab = 'UNFIT SEMENTARA' OR a.StatusKesehatanThorax = 'UNFIT SEMENTARA' OR a.StatusKesehatanFisik = 'UNFIT SEMENTARA') "
                ElseIf cmbstatustransaksi.SelectedIndex = 4 Then
                    status = " AND (a.StatusKesehatanLab = 'UNFIT' OR a.StatusKesehatanThorax = 'UNFIT' OR a.StatusKesehatanFisik = 'UNFIT') "
                End If

                Dim Number1 As String = ""
                Dim Number2 As String = ""
                Dim TrangeNumber As String = ""

                'Set No Urut
                If cbNoUrut.Checked = True Then
                    Number1 = txNoUrut1.Text.ToString().PadLeft(5, "0")
                    Number2 = txNoUrut2.Text.ToString().PadLeft(5, "0")
                    TrangeNumber = " AND (RIGHT(a.nourut, 5) BETWEEN '" & Number1 & "' and '" & Number2 & "')"
                End If

                Dim Tbls As DataTable = New DataTable
                Tbls = ReadThemysql("SELECT a.DetailPemeriksaan AS 'JENIS PEMERIKSAAN', a.idpaket AS 'No Paket', COUNT(a.idlabinternet) AS 'JUMLAH PASIEN' " & _
                                        " FROM transaksilab a" & _
                                        " LEFT JOIN masterpasien b ON a.idpasien = b.nomitra" & _
                                        " LEFT JOIN transaksilabbayar c ON a.idlabinternet = c.idlabinternet" & _
                                        " WHERE (DATE(a.tgllab) BETWEEN '" & Format(dtprocess.Value, "yyyy-MM-dd") & "' AND '" & Format(dtprocessend.Value, "yyyy-MM-dd") & "') AND (a.StatusKesehatanThorax IS NOT NULL AND a.StatusKesehatanLab IS NOT NULL AND a.StatusKesehatanFisik IS NOT NULL) AND a.idtempatlab = b.cabang AND a.idtempatlab = '" & txidloc.Text & "' " & status & " AND (c.NoJenisBayar = '" & txcompanycode.Text & "-" & txkodecabang.Text & "' AND c.JenisBayar = 'TAGIHAN') " & TrangeNumber & "" & _
                                        " GROUP BY a.DetailPemeriksaan, a.idpaket", DB_Poliklinik)

                Dim Tdata As DataTable = New DataTable
                Tdata = CreateTableTandaTerima()
                Tdata.Rows.Clear()

                Dim RowNumber As Integer = 0

                If Tbls.Rows.Count > 0 Then
                    For Each TrowData As DataRow In Tbls.Rows
                        RowNumber = RowNumber + 1

                        Dim Tlastnew As DataRow = Tdata.NewRow
                        Tlastnew("No") = RowNumber
                        Tlastnew("Jenis Pemeriksaan") = TrowData("JENIS PEMERIKSAAN").ToString.Trim.ToUpper
                        Tlastnew("Jumlah Pasien") = TrowData("JUMLAH PASIEN")
                        keterangan = InputBox("Masukkan keterangan untuk ID paket " & TrowData("No Paket") & " : ", "Note Tanda Terima", 2)
                        Tlastnew("Keterangan") = keterangan.ToUpper
                        Tlastnew("No Paket") = TrowData("No Paket")
                        Tlastnew("Note") = "Noted : " & varNote
                        Tlastnew("Tittle") = "TANDA TERIMA MCU KARYAWAN " & txcompanycode.Text & " TGL " & Format(dtprocess.Value, "dd") & " " & BulanIndonesia(Format(dtprocess.Value, "MM")).ToString.Trim.ToUpper & " " & Format(dtprocess.Value, "yyyy")
                        Tdata.Rows.Add(Tlastnew)
                    Next

                    ButtonTandaTerimaMCU.Enabled = False
                End If

                Report.DataSource = Tdata
                Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MM-yyyy HH:mm:ss") + " by " + userUploadMCU

                'Report.RunDesigner()
                Report.ShowPreview()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ButtonClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClose.Click
        Me.Close()
    End Sub
End Class