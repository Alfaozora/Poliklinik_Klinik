Imports System.Drawing

Public Class ReportSummaryMCUOnline
    Private FindMultiple_Poliklinik As FindMultiple.TLconnect
    Private Find_Poliklinik As Find.TLconnect
    Private DB_Poliklinik As TLcon

    Dim Tstr As String = ""
    Dim thread As System.Threading.Thread

    Public Sub LoadLab(ByRef Tid As String)
        ' Set Parameter Server Online
        Dim serverOnline_IP As String = Utility.GetConfig("ServerOnline_IP")
        Dim serverOnline_UserID As String = Utility.GetConfig("ServerOnline_UserID")
        Dim serverOnline_Password As String = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerOnline_Password"), "albert")

        ' Set Find Multiple Poliklinik
        FindMultiple_Poliklinik.Tip = serverOnline_IP
        FindMultiple_Poliklinik.Tid = serverOnline_UserID
        FindMultiple_Poliklinik.Tpass = serverOnline_Password
        FindMultiple_Poliklinik.Tdb = Utility.GetConfig("ServerOnlinePoli_DB")

        ' Set Find Poliklinik
        Find_Poliklinik.Tip = serverOnline_IP
        Find_Poliklinik.Tid = serverOnline_UserID
        Find_Poliklinik.Tpass = serverOnline_Password
        Find_Poliklinik.Tdb = Utility.GetConfig("ServerOnlinePoli_DB")

        ' Set DB Poliklinik
        DB_Poliklinik.Tip = serverOnline_IP
        DB_Poliklinik.Tid = serverOnline_UserID
        DB_Poliklinik.Tpass = serverOnline_Password
        DB_Poliklinik.Tdb = Utility.GetConfig("ServerOnlinePoli_DB")

        If RadioButtonMCU.Checked = False And RadioButtonHasilLain.Checked = False Then
            MsgBox("Pilih salah satu Report yang akan ditampilkan. Hasil MCU atau Hasil Lain ( ECG,Fisik,dll)")
        End If

    End Sub

    Public Sub LoadPasien(ByRef Trow() As DataRow)
        If Trow.Length = 0 Then
            SetClear()
        Else
            Tstr = ""
            Dim Ttemp As String = "("
            For i As Integer = 0 To Trow.Length - 1
                Ttemp = Ttemp & "'" & Trow(i)("NoUrut").ToString.Trim & "',"
            Next
            Tstr = Strings.Left(Ttemp, Ttemp.Length - 1) & ")"

            Dim Tbls As New DataTable

            If cmbjenisfilter.SelectedIndex = 0 Then
                Tbls = ReadThemysql("select a.NoUrut,a.TglLab,b.nomitra,b.Nama,b.TglLahir,b.Alamat, b.sex, b.PTNIK, a.idlabinternet from transaksilab a left join masterpasien b on a.idpasien=b.nomitra where date(a.tgllab)='" & txtanggal.Text & "' and a.idtempatlab=b.cabang AND a.Nourut in " & Tstr & " AND b.PTID='" & txkodecabang.Text & "'", DB_Poliklinik)
            ElseIf cmbjenisfilter.SelectedIndex = 1 Then
                Tbls = ReadThemysql("select a.NoUrut,a.TglLab,b.nomitra,b.Nama,b.TglLahir,b.Alamat, b.sex, b.PTNIK, a.idlabinternet from transaksilab a left join masterpasien b on a.idpasien=b.nomitra where date(a.tgllab)='" & txtanggal.Text & "' and a.idtempatlab=b.cabang AND a.Nourut in " & Tstr & " AND a.idtempatlab='" & txkodecabang.Text & "'", DB_Poliklinik)
            End If
            gridpasien.DataSource = Tbls

            LoadLab(Tstr)
        End If

    End Sub

    Private Sub SetClear()
        LoadLab(Tstr)

        Dim Tbls As DataTable = ReadThemysql("select a.NoUrut,a.TglLab,b.nomitra,b.Nama,b.TglLahir,b.Alamat, a.idlabinternet from transaksilab a left join masterpasien b on a.idpasien=b.nomitra where a.Status=''", DB_Poliklinik)
        gridpasien.DataSource = Tbls

        RadioButtonMCU.Checked = False
        RadioButtonHasilLain.Checked = False
    End Sub

    Private Sub CloseToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub ReportSummaryMCU_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        NewToolStripMenuItem1.PerformClick()
        Control.CheckForIllegalCrossThreadCalls = False


    End Sub

    Private Sub NewToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem1.Click
        SetClear()
    End Sub

    Private Sub TambahPasienToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TambahPasienToolStripMenuItem.Click
        If txkodecabang.Text = "" Then
            MsgBox("Pilih Company Terlebih Dahulu.")
            Exit Sub
        ElseIf txtanggal.Text = "" Then
            MsgBox("Pilih Tanggal Terlebih Dahulu.")
            Exit Sub
        End If

        If cmbjenisfilter.SelectedIndex = 0 Then
            FindMultiple.Show()
            'FindMultiple.QueryOL("SELECT c.kodeket, a.idtempatlab, a.NoUrut,a.TglLab,b.nomitra,b.Nama,b.TglLahir,b.Alamat from transaksilab a LEFT join masterpasien b on a.idpasien=b.nomitra LEFT JOIN mastercodebarcode c ON c.kodecabang=b.cabang WHERE date(a.tgllab)='" & txtanggal.Text & "' and a.idtempatlab=b.cabang AND b.PTID='" & txkodecabang.Text & "' ", " order by a.nourut desc", "ReportMCUOnline", 2)
            FindMultiple.QueryTheMysql("SELECT c.kodeket, a.idtempatlab, a.NoUrut,a.TglLab,b.nomitra,b.Nama,b.TglLahir,b.Alamat from transaksilab a LEFT join masterpasien b on a.idpasien=b.nomitra LEFT JOIN mastercodebarcode c ON c.kodecabang=b.cabang WHERE date(a.tgllab)='" & txtanggal.Text & "' and a.idtempatlab=b.cabang AND b.PTID='" & txkodecabang.Text & "' ", " ORDER BY a.nourut desc", "ReportMCUOnline", 1, FindMultiple_Poliklinik)
        ElseIf cmbjenisfilter.SelectedIndex = 1 Then
            FindMultiple.Show()
            'FindMultiple.QueryOL("SELECT c.kodeket, a.idtempatlab, a.NoUrut,a.TglLab,b.nomitra,b.Nama,b.TglLahir,b.Alamat from transaksilab a LEFT join masterpasien b on a.idpasien=b.nomitra LEFT JOIN mastercodebarcode c ON c.kodecabang=b.cabang WHERE date(a.tgllab)='" & txtanggal.Text & "' and a.idtempatlab=b.cabang AND a.idtempatlab='" & txkodecabang.Text & "' ", " order by a.nourut desc", "ReportMCUOnline", 2)
            FindMultiple.QueryTheMysql("SELECT c.kodeket, a.idtempatlab, a.NoUrut,a.TglLab,b.nomitra,b.Nama,b.TglLahir,b.Alamat from transaksilab a LEFT join masterpasien b on a.idpasien=b.nomitra LEFT JOIN mastercodebarcode c ON c.kodecabang=b.cabang WHERE date(a.tgllab)='" & txtanggal.Text & "' and a.idtempatlab=b.cabang AND a.idtempatlab='" & txkodecabang.Text & "' ", " ORDER BY a.nourut desc", "ReportMCUOnline", 1, FindMultiple_Poliklinik)
        End If


        'FindMultiple.Show()
        'FindMultiple.QueryOL("SELECT c.kodeket, a.idtempatlab, a.NoUrut,a.TglLab,b.nomitra,b.Nama,b.TglLahir,b.Alamat from transaksilab a LEFT join masterpasien b on a.idpasien=b.nomitra LEFT JOIN mastercodebarcode c ON c.kodecabang=b.cabang WHERE a.tgllab='" & txtanggal.Text & "' and a.idtempatlab=b.cabang AND b.PTID='" & txkodecabang.Text & "' ", " order by a.nourut desc", "ReportMCUOnline", 2)
    End Sub

    Private Sub count()
        Tstr = ""
        Dim Ttemp As String = "("
        Dim Tnik As DataTable = gridpasien.DataSource

        Tnik.AcceptChanges()
        For Each Trow As DataRow In Tnik.Rows
            Ttemp = Ttemp & "'" & Trow("NoUrut").ToString.Trim & "',"
        Next
        Tstr = Strings.Left(Ttemp, Ttemp.Length - 1) & ")"

        Dim Tbls As New DataTable
        If cmbjenisfilter.SelectedIndex = 0 Then
            Tbls = ReadThemysql("select a.NoUrut,a.TglLab,b.nomitra,b.Nama,b.TglLahir,b.Alamat, b.sex, b.PTNIK, a.idlabinternet from transaksilab a left join masterpasien b on a.idpasien=b.nomitra where date(a.tgllab)='" & txtanggal.Text & "' and a.idtempatlab=b.cabang AND a.Nourut in " & Tstr & " AND b.PTID='" & txkodecabang.Text & "'", DB_Poliklinik)
        ElseIf cmbjenisfilter.SelectedIndex = 1 Then
            Tbls = ReadThemysql("select a.NoUrut,a.TglLab,b.nomitra,b.Nama,b.TglLahir,b.Alamat, b.sex, b.PTNIK, a.idlabinternet from transaksilab a left join masterpasien b on a.idpasien=b.nomitra where date(a.tgllab)='" & txtanggal.Text & "' and a.idtempatlab=b.cabang AND a.Nourut in " & Tstr & " AND a.idtempatlab='" & txkodecabang.Text & "'", DB_Poliklinik)
        End If

        Dim Ttindakan As DataTable = gridtest.DataSource
        If Ttindakan.Rows.Count <= 0 Then
            MsgBox("Pilih jenis tindakan yang akan ditampilkan")
            Exit Sub
        End If

        Ttindakan.AcceptChanges()
        Dim Rtindakan() As DataRow = Ttindakan.Select("Checked=True")
        For j As Integer = 0 To Rtindakan.Length - 1 Step 1
            insertRowToTbls(Tbls, "Typstring", Rtindakan(j)("TindakanID").ToString & "/" & Rtindakan(j)("NoUrut").ToString)
        Next

        If RadioButtonMCU.Checked = True Then

            'start column 7 diisi hasilnya 
            For Each Thasil As DataRow In Tbls.Rows
                Dim TblsN As DataTable = ReadThemysql("SELECT a.result, a.nourut, a.tindakanid from transaksilabresult a left join transaksilabdetail b on b.TransLabIDDetail=a.TransLabIDDetail and b.TindakanID=a.TindakanID where b.idlabinternet in (select idlabinternet from transaksilab where NoUrut='" & Thasil("NoUrut").ToString & "' and idlabinternet='" & Thasil("idlabinternet").ToString & "')", DB_Poliklinik)
                For Each TrowN As DataRow In TblsN.Rows
                    For j As Integer = 9 To Tbls.Columns.Count - 1 Step 1
                        Dim Tidx() As String = Tbls.Columns(j).ColumnName.ToString.Split("/")
                        If TrowN("tindakanid") = Tidx(0) And TrowN("nourut") = Tidx(1) Then
                            Thasil(j) = TrowN("result")
                        End If
                    Next
                Next
            Next

            For j As Integer = 9 To Tbls.Columns.Count - 1 Step 1
                Dim Tcol As DataColumn = Tbls.Columns(j)
                Dim Txid() As String = Tcol.ColumnName.ToString.Split("/")
                Dim Tstr As String = ReadThemysqlNIK("select DetailKet from masterlabdetail where TindakanID='" & Txid(0) & "' and NoUrut='" & Txid(1) & "'", DB_Poliklinik)
                For i As Integer = 9 To j - 1 Step 1
                    If Tbls.Columns(i).ColumnName = Tstr Then
                        Tstr = Tstr & " "
                    End If
                Next
                Tcol.ColumnName = Tstr
            Next

            GridView3.Columns.Clear()
            gridresult.DataSource = Tbls
            MsgBox("Done")

            'FISIK PERLU DIKASIH IDLABINTERNET
        ElseIf RadioButtonHasilLain.Checked = True Then
            Dim berat As String = ""
            Dim tinggi As String = ""
            'start column 7 diisi hasilnya 
            For Each Thasil As DataRow In Tbls.Rows
                Dim TblsN As DataTable = ReadThemysql("select FisikNoUrut, Result, fisikket from transaksilabfisik where NoUrut='" & Thasil("NoUrut").ToString & "' AND idlabinternet='" & Thasil("idlabinternet").ToString & "'", DB_Poliklinik)
                For Each TrowN As DataRow In TblsN.Rows
                    For j As Integer = 9 To Tbls.Columns.Count - 1 Step 1
                        Dim Tidx() As String = Tbls.Columns(j).ColumnName.ToString.Split("/")
                        If Tidx(0) = 0 And Tidx(1) = 1 Then
                            If TrowN("fisikket") = "BeratBadan" Then
                                berat = TrowN("Result")
                            End If
                            If TrowN("fisikket") = "Tinggi Badan" Then
                                tinggi = TrowN("Result")
                            End If
                            If berat <> "" And berat <> "0" And tinggi <> "" And berat <> "0" And tinggi <> "-" And berat <> "-" Then
                                Thasil(j) = Math.Round(CDbl(berat / (tinggi * tinggi) * 10000), 1)
                            Else
                                Thasil(j) = "-"
                            End If
                        ElseIf CInt(Tidx(0).ToString) > -1 Then
                            If TrowN("FisikNoUrut") = Tidx(1) Then
                                Thasil(j) = TrowN("Result")
                            End If
                        ElseIf CInt(Tidx(0).ToString) < 0 Then
                            Dim Tjensitindakan As String = ReadThemysqlNIK("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'transaksilabhasillain' and COLUMN_NAME not like '%By%' and COLUMN_NAME not like '%Date%' and COLUMN_NAME not in ('HasilID','NoUrut')", DB_Poliklinik)
                            Thasil(j) = ReadThemysqlNIK("select " & Tjensitindakan & " from transaksilabhasillain where NoUrut='" & Thasil("NoUrut").ToString & "' AND idlabinternet='" & Thasil("idlabinternet").ToString & "'", DB_Poliklinik)
                        End If
                    Next
                Next

            Next

            For j As Integer = 9 To Tbls.Columns.Count - 1 Step 1
                Dim Tcol As DataColumn = Tbls.Columns(j)
                Dim Tstr As String = ""
                Dim Txid() As String = Tcol.ColumnName.ToString.Split("/")
                If Txid(0) = 0 And Txid(1) = 1 Then
                    Tstr = "BMI"
                ElseIf CInt(Txid(0).ToString) > -1 Then
                    Tstr = ReadThemysqlNIK("select FisikKet as NamaTindakan from masterlabfisik  where FisikDeleted=0 and FisikNoUrut='" & Txid(1) & "'", DB_Poliklinik)
                ElseIf CInt(Txid(0).ToString) < 0 Then
                    Tstr = ReadThemysqlNIK("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'transaksilabhasillain' and COLUMN_NAME not like '%By%' and COLUMN_NAME not like '%Date%' and COLUMN_NAME not in ('HasilID','NoUrut') and ORDINAL_POSITION='" & Txid(1) & "'", DB_Poliklinik)
                End If

                For i As Integer = 9 To j - 1 Step 1
                    If Tbls.Columns(i).ColumnName = Tstr Then
                        Tstr = Tstr & " "
                    End If
                Next
                Tcol.ColumnName = Tstr

            Next

            GridView3.Columns.Clear()
            gridresult.DataSource = Tbls

        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim TblsAwal As DataTable = gridpasien.DataSource

        If RadioButtonHasilLain.Checked = False And RadioButtonMCU.Checked = False Then
            MsgBox("Pilih salah satu laporan summary yang dikeluarkan")
            Exit Sub
        End If

        If TblsAwal.Rows.Count <= 0 Then
            MsgBox("Pilih dahulu pasien yang akan di rekap summary-nya")
            Exit Sub
        Else
            Tstr = ""
            Dim Ttemp As String = "("
            Dim TtempTindakanID As String = "("
            Dim Ttempidlabinternet As String = "("
            Dim Tnik As DataTable = gridpasien.DataSource

            Tnik.AcceptChanges()
            For Each Trow As DataRow In Tnik.Rows
                Ttemp = Ttemp & "'" & Trow("NoUrut").ToString.Trim & "',"
            Next
            Tstr = Strings.Left(Ttemp, Ttemp.Length - 1) & ")"

            Dim Tbls As New DataTable
            If cmbjenisfilter.SelectedIndex = 0 Then
                Tbls = ReadThemysql("select a.NoUrut,a.TglLab,b.nomitra,b.Nama,b.TglLahir,b.Alamat, b.sex, b.PTNIK, a.idlabinternet from transaksilab a left join masterpasien b on a.idpasien=b.nomitra where date(a.tgllab)='" & txtanggal.Text & "' and a.idtempatlab=b.cabang AND a.Nourut in " & Tstr & " AND b.PTID='" & txkodecabang.Text & "'", DB_Poliklinik)
            ElseIf cmbjenisfilter.SelectedIndex = 1 Then
                Tbls = ReadThemysql("select a.NoUrut,a.TglLab,b.nomitra,b.Nama,b.TglLahir,b.Alamat, b.sex, b.PTNIK, a.idlabinternet from transaksilab a left join masterpasien b on a.idpasien=b.nomitra where date(a.tgllab)='" & txtanggal.Text & "' and a.idtempatlab=b.cabang AND a.Nourut in " & Tstr & " AND a.idtempatlab='" & txkodecabang.Text & "'", DB_Poliklinik)
            End If

            Dim Ttindakan As DataTable = gridtest.DataSource
            If Ttindakan.Rows.Count <= 0 Then
                MsgBox("Pilih jenis tindakan yang akan ditampilkan")
                Exit Sub
            End If

            Dim keyTindakan As Boolean = False
            Ttindakan.AcceptChanges()
            Dim Rtindakan() As DataRow = Ttindakan.Select("Checked=True")
            For j As Integer = 0 To Rtindakan.Length - 1 Step 1
                If TtempTindakanID.Contains("'" & Rtindakan(j)("TindakanID").ToString.Trim & "'") = False Then
                    TtempTindakanID = TtempTindakanID & "'" & Rtindakan(j)("TindakanID").ToString.Trim & "',"
                End If
                insertRowToTbls(Tbls, "Typstring", Rtindakan(j)("TindakanID").ToString & "/" & Rtindakan(j)("NoUrut").ToString)
                keyTindakan = True
            Next
            TtempTindakanID = Strings.Left(TtempTindakanID, TtempTindakanID.Length - 1) & ")"

            For Each Tidlabinternet As DataRow In Tbls.Rows
                If Ttempidlabinternet.Contains("'" & Tidlabinternet("idlabinternet").ToString.Trim & "'") = False Then
                    Ttempidlabinternet = Ttempidlabinternet & "'" & Tidlabinternet("idlabinternet").ToString.Trim & "',"
                End If
            Next
            Ttempidlabinternet = Strings.Left(Ttempidlabinternet, Ttempidlabinternet.Length - 1) & ")"

            If keyTindakan = False Then
                MsgBox("Pilih Tindakan Terlebih Dahulu")
                Exit Sub
            End If

            Dim key As Boolean = False
            Dim Saran As String = ""
            Dim Kesimpulan As String = ""

            If RadioButtonMCU.Checked = True Then

                'For Each Thasil As DataRow In Tbls.Rows
                '    Dim TblsN As DataTable = ReadThemysql("SELECT a.result, a.nourut, a.tindakanid from transaksilabresult a left join transaksilabdetail b on b.TransLabIDDetail=a.TransLabIDDetail and b.TindakanID=a.TindakanID LEFT JOIN transaksilab c ON b.idlabinternet=c.idlabinternet where a.tindakanid in " & TtempTindakanID & " and c.NoUrut='" & Thasil("NoUrut").ToString & "' and c.idlabinternet='" & Thasil("idlabinternet").ToString & "'", DB_Poliklinik)
                '    For Each TrowN As DataRow In TblsN.Rows
                '        key = False
                '        For j As Integer = 9 To Tbls.Columns.Count - 1 Step 1
                '            Dim Tidx() As String = Tbls.Columns(j).ColumnName.ToString.Split("/")
                '            If (Tidx(0) = "1000" Or Tidx(0) = "1001") And key = False Then
                '                Dim TempSaranKeterangan As DataTable = ReadThemysql("select Kesimpulan, Saran from transaksilab where nourut = '" & Thasil("nourut").ToString & "' and idlabinternet='" & Thasil("idlabinternet").ToString & "'", DB_Poliklinik)
                '                For Each Trow As DataRow In TempSaranKeterangan.Rows
                '                    Saran = Trow("Saran")
                '                    Kesimpulan = Trow("Kesimpulan")
                '                Next
                '                key = True
                '            End If

                '            If Tidx(0) = "1000" Then
                '                Thasil(j) = Kesimpulan
                '            ElseIf Tidx(0) = "1001" Then
                '                Thasil(j) = Saran
                '            ElseIf TrowN("tindakanid") = Tidx(0) And TrowN("nourut") = Tidx(1) Then
                '                Thasil(j) = TrowN("result")
                '            End If
                '        Next
                '    Next
                'Next

                Dim TblsN As DataTable = ReadThemysql("SELECT case when a.result <> '' then a.result ELSE '-' END AS 'result', a.nourut, a.tindakanid, a.idlabinternet from transaksilabresult a left join transaksilabdetail b on b.TransLabIDDetail=a.TransLabIDDetail and b.TindakanID=a.TindakanID and a.idlabinternet=b.idlabinternet where b.idlabinternet IN (SELECT idlabinternet FROM transaksilab WHERE a.tindakanid in " & TtempTindakanID & " and idlabinternet in " & Ttempidlabinternet & ")", DB_Poliklinik)
                Dim tempidlabinternet As Integer = 0

                For Each TrowN As DataRow In TblsN.Rows
                    For Each Thasil As DataRow In Tbls.Rows
                        If TrowN("idlabinternet") = Thasil("idlabinternet") Then
                            For j As Integer = 9 To Tbls.Columns.Count - 1 Step 1
                                Dim Tidx() As String = Tbls.Columns(j).ColumnName.ToString.Split("/")

                                If TrowN("tindakanid") = Tidx(0) And TrowN("nourut") = Tidx(1) Then
                                    Thasil(j) = TrowN("result")
                                ElseIf (Tidx(0) = "1000" Or Tidx(0) = "1001") Then
                                    If (Tidx(0) = "1000" Or Tidx(0) = "1001") And tempidlabinternet <> TrowN("idlabinternet") Then
                                        Dim TempSaranKeterangan As DataTable = ReadThemysql("select Kesimpulan, Saran from transaksilab where nourut = '" & Thasil("nourut").ToString & "' and idlabinternet='" & Thasil("idlabinternet").ToString & "'", DB_Poliklinik)
                                        For Each Trow As DataRow In TempSaranKeterangan.Rows
                                            If IsDBNull(Trow("Saran")) = True Then Trow("Saran") = "-"
                                            If IsDBNull(Trow("Kesimpulan")) = True Then Trow("Kesimpulan") = "-"
                                            Saran = Trow("Saran")
                                            Kesimpulan = Trow("Kesimpulan")
                                        Next
                                        tempidlabinternet = TrowN("idlabinternet")
                                    End If

                                    If Tidx(0) = "1000" Then
                                        Thasil(j) = Kesimpulan
                                    ElseIf Tidx(0) = "1001" Then
                                        Thasil(j) = Saran
                                    End If
                                End If
                            Next
                        End If
                    Next
                Next

                For j As Integer = 9 To Tbls.Columns.Count - 1 Step 1
                    Dim Tcol As DataColumn = Tbls.Columns(j)
                    Dim Txid() As String = Tcol.ColumnName.ToString.Split("/")
                    If Txid(0) = "1000" Then
                        Tcol.ColumnName = "Hasil"
                    ElseIf Txid(0) = "1001" Then
                        Tcol.ColumnName = "Keterangan"
                    Else
                        'Dim Tstr As String = ReadThemysqlNIK("select DetailKet from masterlabdetail where TindakanID='" & Txid(0) & "' and NoUrut='" & Txid(1) & "'", DB_Poliklinik)
                        Dim Tstr As String = ReadSQLNIK("select DetailKet from MasterLabDetail where TindakanID='" & Txid(0) & "' and NoUrut='" & Txid(1) & "'")
                        For i As Integer = 9 To j - 1 Step 1
                            If Tbls.Columns(i).ColumnName = Tstr Then
                                Tstr = Tstr & " "
                            End If
                        Next
                        Tcol.ColumnName = Tstr
                    End If
                Next

                GridView3.Columns.Clear()
                gridresult.DataSource = Tbls
                MsgBox("Done")

                'FISIK PERLU DIKASIH IDLABINTERNET
            ElseIf RadioButtonHasilLain.Checked = True Then
                Dim berat As String = ""
                Dim tinggi As String = ""
                'start column 7 diisi hasilnya 
                For Each Thasil As DataRow In Tbls.Rows
                    Dim TblsN As DataTable = ReadThemysql("select FisikNoUrut, Result, fisikket, dimana, kenapa, jenis, kapan, StatusSembuh from transaksilabfisik where NoUrut='" & Thasil("NoUrut").ToString & "' AND idlabinternet='" & Thasil("idlabinternet").ToString & "'", DB_Poliklinik)
                    For Each TrowN As DataRow In TblsN.Rows
                        For j As Integer = 9 To Tbls.Columns.Count - 1 Step 1
                            Dim Tidx() As String = Tbls.Columns(j).ColumnName.ToString.Split("/")
                            If Tidx(0) = 0 And Tidx(1) = 1 Then
                                If TrowN("fisikket") = "BeratBadan" Then
                                    berat = TrowN("Result")
                                End If
                                If TrowN("fisikket") = "Tinggi Badan" Then
                                    tinggi = TrowN("Result")
                                End If
                                If berat <> "" And berat <> "0" And tinggi <> "" And berat <> "0" And tinggi <> "-" And berat <> "-" Then
                                    Thasil(j) = Math.Round(CDbl(berat / (tinggi * tinggi) * 10000), 1)
                                Else
                                    Thasil(j) = "-"
                                End If
                            ElseIf CInt(Tidx(0).ToString) > -1 Then
                                If TrowN("FisikNoUrut") = Tidx(1) Then
                                    ' Set Status Sembuh
                                    Dim textKeteranganSembuh As String = ""
                                    If Not IsDBNull(TrowN("StatusSembuh")) AndAlso Convert.ToBoolean(TrowN("StatusSembuh")) = True Then
                                        textKeteranganSembuh = " (Sembuh)"
                                    End If

                                    ' Set Kapan
                                    Dim textKapan As String = ""
                                    If Not IsDBNull(TrowN("kapan")) AndAlso TrowN("kapan") <> "1900-01-01" Then
                                        textKapan = " " & Format(TrowN("kapan"), "yyyy")
                                    End If

                                    ' Set Dimana
                                    Dim textDimana As String = ""
                                    If Not IsDBNull(TrowN("dimana")) AndAlso TrowN("dimana") <> "" Then
                                        textDimana = " di " & TrowN("dimana")
                                    End If

                                    ' Set Kenapa
                                    Dim textKenapa As String = ""
                                    If Not IsDBNull(TrowN("kenapa")) AndAlso TrowN("kenapa") <> "" Then
                                        textKenapa = " " & TrowN("kenapa")
                                    End If

                                    ' Set Jenis
                                    Dim textJenis As String = ""
                                    If Not IsDBNull(TrowN("jenis")) AndAlso TrowN("jenis") <> "" Then
                                        textJenis = " " & TrowN("jenis")
                                    End If

                                    Dim result As String = TrowN("Result") & "," & textKapan & textJenis & textKenapa & textDimana & textKeteranganSembuh
                                    result = result.TrimEnd()
                                    If result.EndsWith(",") Then result = result.Substring(0, result.Length - 1)

                                    Thasil(j) = result
                                End If
                            ElseIf CInt(Tidx(0).ToString) < 0 Then
                                Dim Tjensitindakan As String = ReadThemysqlNIK("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'transaksilabhasillain' and COLUMN_NAME not like '%By%' and COLUMN_NAME not like '%Date%' and COLUMN_NAME not in ('HasilID','NoUrut')", DB_Poliklinik)
                                Thasil(j) = ReadThemysqlNIK("select " & Tjensitindakan & " from transaksilabhasillain where NoUrut='" & Thasil("NoUrut").ToString & "' AND idlabinternet='" & Thasil("idlabinternet").ToString & "'", DB_Poliklinik)
                            End If
GoBackthis:
                        Next
                    Next
                Next

                For j As Integer = 9 To Tbls.Columns.Count - 1 Step 1
                    Dim Tcol As DataColumn = Tbls.Columns(j)
                    Dim Tstr As String = ""
                    Dim Txid() As String = Tcol.ColumnName.ToString.Split("/")
                    If Txid(0) = 0 And Txid(1) = 1 Then
                        Tstr = "BMI"
                    ElseIf CInt(Txid(0).ToString) > -1 Then
                        Tstr = ReadThemysqlNIK("select FisikKet as NamaTindakan from masterlabfisik  where FisikDeleted=0 and FisikNoUrut='" & Txid(1) & "'", DB_Poliklinik)
                    ElseIf CInt(Txid(0).ToString) < 0 Then
                        Tstr = ReadThemysqlNIK("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'transaksilabhasillain' and COLUMN_NAME not like '%By%' and COLUMN_NAME not like '%Date%' and COLUMN_NAME not in ('HasilID','NoUrut') and ORDINAL_POSITION='" & Txid(1) & "'", DB_Poliklinik)
                    End If

                    For i As Integer = 9 To j - 1 Step 1
                        If Tbls.Columns(i).ColumnName = Tstr Then
                            Tstr = Tstr & " "
                        End If
                    Next
                    Tcol.ColumnName = Tstr

                Next

                GridView3.Columns.Clear()
                gridresult.DataSource = Tbls

            End If
        End If
    End Sub

    Function QueryData() As DataTable
        Dim Ttemp As New DataTable
        Ttemp = gridpasien.DataSource
        Dim Tdata As DataTable
        Tdata = Ttemp.Clone

        For Each Trow As DataRow In Ttemp.Rows
            Tdata.ImportRow(Trow)
        Next

        Dim Tlab As New DataTable
        Tlab = gridtest.DataSource

        Dim Rlab() As DataRow = Tlab.Select("[Checked]=True")


        If Rlab.Length > 0 Then
            For i As Integer = 0 To Rlab.Length - 1
                Dim Tdetail As DataTable = ReadThemysql(" select * from masterlab a left join masterlabdetail b on a.TindakanID=b.TindakanID where a.TindakanID='" & Rlab(i)("TindakanID").ToString & "' order by a.TindakanID,b.NoUrut", DB_Poliklinik)
                For Each Rdetail As DataRow In Tdetail.Rows
                    insertRowToTbls(Tdata, "Typstring", Rlab(i)("TindakanID").ToString & "~" & Rdetail("DetailKet"))
                Next
            Next
        End If

        For Each Tcol As DataColumn In Tdata.Columns
            Tcol.ReadOnly = False
        Next

        For Each Trow As DataRow In Tdata.Rows
            For i As Integer = 9 To Tdata.Columns.Count - 1 Step 1
                Dim Tsplit() As String = Tdata.Columns(i).ColumnName.ToString.Split("~")
                Trow(i) = ReadThemysqlNIK("select b.Result from transaksilabdetail a left join transaksilabresult b on a.TransLabIDDetail =b.TransLabIDDetail and a.TindakanID=b.TindakanID  AND a.idlabinternet = b.idlabinternet left join transaksilab c on c.idlabinternet=a.idlabinternet " & _
                                     " where c.NoUrut='" & Trow("NoUrut") & "' and date(c.TglLab)='" & Format(Trow("TglLab"), "MM/dd/yyyy") & "' and c.IDInternet='" & Trow("nomitra") & "' and a.TindakanID='" & Tsplit(0).ToString & "' and DetailKet='" & Tsplit(1).ToString & "' order by a.TransLabIDDetail,a.TindakanID,b.NoUrut,b.GroupID,b.DetailKet ", DB_Poliklinik)
            Next
        Next

        Return Tdata
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim Tbls As DataTable = gridresult.DataSource
        If Tbls.Rows.Count > 0 Then
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
                    gridresult.ExportToExcel(saveFileDialog1.FileName.ToString)
                    MsgBox("File Saved")
                End If
            End If
        End If
    End Sub

    Private Sub rdmcu_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonMCU.CheckedChanged
        If RadioButtonMCU.Checked = True And Tstr <> "" Then
            GridView2.Columns.Clear()
            Dim Tlab As New DataTable

            If cmbjenisfilter.SelectedIndex = 0 Then
                Tlab = ReadThemysql(" select distinct a.TindakanID,b.NoUrut,a.NamaTindakan,b.DetailKet from transaksilabdetail a left join transaksilabresult b on a.TransLabIDDetail =b.TransLabIDDetail and a.TindakanID=b.TindakanID  AND a.idlabinternet = b.idlabinternet " & _
                            " left join masterjenistindakan m on m.JenisTindakan=a.JenisTindakan left join transaksilab c on c.idlabinternet=a.idlabinternet LEFT JOIN masterpasien d ON c.idpasien=d.nomitra where date(c.tgllab)='" & txtanggal.Text & "' and c.NoUrut in " & Tstr & " AND d.PTID='" & txkodecabang.Text & "' AND b.nourut IS NOT null order by m.UrutanJenisID,a.Urutan,b.TindakanID,b.NoUrut,a.TransLabIDDetail,a.TindakanID,b.GroupID,b.DetailKet ", DB_Poliklinik)
            ElseIf cmbjenisfilter.SelectedIndex = 1 Then
                Tlab = ReadThemysql(" select distinct a.TindakanID,b.NoUrut,a.NamaTindakan,b.DetailKet from transaksilabdetail a left join transaksilabresult b on a.TransLabIDDetail =b.TransLabIDDetail and a.TindakanID=b.TindakanID  AND a.idlabinternet = b.idlabinternet " & _
                            " left join masterjenistindakan m on m.JenisTindakan=a.JenisTindakan left join transaksilab c on c.idlabinternet=a.idlabinternet LEFT JOIN masterpasien d ON c.idpasien=d.nomitra where date(c.tgllab)='" & txtanggal.Text & "' and c.NoUrut in " & Tstr & " AND c.idtempatlab='" & txkodecabang.Text & "' AND b.nourut IS NOT null order by m.UrutanJenisID,a.Urutan,b.TindakanID,b.NoUrut,a.TransLabIDDetail,a.TindakanID,b.GroupID,b.DetailKet ", DB_Poliklinik)
            End If

            'Add Hasil & Keterangan
            Dim Tnew2 As DataRow = Tlab.NewRow
            Tnew2("TindakanID") = "1000"
            Tnew2("NoUrut") = "0"
            Tnew2("NamaTindakan") = "Hasil"
            Tnew2("DetailKet") = "Hasil"
            Tlab.Rows.Add(Tnew2)
            Tnew2 = Tlab.NewRow
            Tnew2("TindakanID") = "1001"
            Tnew2("NoUrut") = "0"
            Tnew2("NamaTindakan") = "Keterangan"
            Tnew2("DetailKet") = "Keterangan"
            Tlab.Rows.Add(Tnew2)

            insertRowToTbls(Tlab, "typchecked", "Checked")

            Tlab.Columns("DetailKet").ReadOnly = True
            Tlab.Columns("NamaTindakan").ReadOnly = True
            Tlab.Columns("Checked").ReadOnly = False

            gridtest.DataSource = Tlab
            GridView2.Columns("TindakanID").Visible = False
            GridView2.Columns("NoUrut").Visible = False
        End If
    End Sub

    Private Sub rdlain_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonHasilLain.CheckedChanged
        If RadioButtonHasilLain.Checked = True And Tstr <> "" Then
            GridView2.Columns.Clear()
            Dim Tfisik As DataTable = ReadThemysql("select FisikID as TindakanID,FisikNoUrut as NoUrut,FisikKet as NamaTindakan,FisikKet from masterlabfisik  where FisikDeleted=0 and Titikdua=':'", DB_Poliklinik)

            Dim Tlain As DataTable = ReadThemysql("set @row = 9000; SELECT (@row:=@row+1) as TindakanID,ORDINAL_POSITION as NoUrut,COLUMN_NAME as NamaTindakan,'' as FisikKet FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'transaksilabhasillain' and COLUMN_NAME not like '%By%' and COLUMN_NAME not like '%Date%' and COLUMN_NAME not in ('HasilID','NoUrut') ", DB_Poliklinik)
            For Each Trow As DataRow In Tlain.Rows
                Dim Tadd As DataRow = Tfisik.NewRow
                For i As Integer = 0 To Tfisik.Columns.Count - 1
                    Tadd(i) = Trow(i)
                Next
                Tfisik.Rows.Add(Tadd)
            Next

            Dim Tnewadd As DataRow = Tfisik.NewRow
            Tnewadd("TindakanID") = "0"
            Tnewadd("NoUrut") = 1
            Tnewadd("NamaTindakan") = "BMI"
            Tnewadd("FisikKet") = "BMI"
            Tfisik.Rows.InsertAt(Tnewadd, 0)

            insertRowToTbls(Tfisik, "typchecked", "Checked")

            Tfisik.Columns("NamaTindakan").ReadOnly = True
            Tfisik.Columns("Checked").ReadOnly = False

            gridtest.DataSource = Tfisik
            GridView2.Columns("TindakanID").Visible = False
            GridView2.Columns("NoUrut").Visible = False

        End If
    End Sub

    Private Sub rdheader_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdheader.CheckedChanged
        If rdheader.Checked = True And Tstr <> "" Then
            GridView2.Columns.Clear()
            Dim Tlab As New DataTable

            If cmbjenisfilter.SelectedIndex = 0 Then
                Tlab = ReadThemysql(" select distinct a.TindakanID,b.NoUrut,a.NamaTindakan,b.DetailKet from transaksilabdetail a left join transaksilabresult b on a.TransLabIDDetail =b.TransLabIDDetail and a.TindakanID=b.TindakanID  AND a.idlabinternet = b.idlabinternet " & _
                            " left join transaksilab c on c.idlabinternet=a.idlabinternet LEFT JOIN masterpasien d ON c.idpasien=d.nomitra where date(c.tgllab)='" & txtanggal.Text & "' and c.NoUrut in " & Tstr & " AND d.PTID='" & txkodecabang.Text & "' order by a.TindakanID ", DB_Poliklinik)
                insertRowToTbls(Tlab, "typchecked", "Checked")
            ElseIf cmbjenisfilter.SelectedIndex = 1 Then
                Tlab = ReadThemysql(" select distinct a.TindakanID,b.NoUrut,a.NamaTindakan,b.DetailKet from transaksilabdetail a left join transaksilabresult b on a.TransLabIDDetail =b.TransLabIDDetail and a.TindakanID=b.TindakanID  AND a.idlabinternet = b.idlabinternet " & _
                            " left join transaksilab c on c.idlabinternet=a.idlabinternet LEFT JOIN masterpasien d ON c.idpasien=d.nomitra where date(c.tgllab)='" & txtanggal.Text & "' and c.NoUrut in " & Tstr & " AND c.idtempatlab='" & txkodecabang.Text & "' order by a.TindakanID ", DB_Poliklinik)
                insertRowToTbls(Tlab, "typchecked", "Checked")
            End If

            Tlab.Columns("DetailKet").ReadOnly = True
            Tlab.Columns("NamaTindakan").ReadOnly = True
            Tlab.Columns("Checked").ReadOnly = False

            gridtest.DataSource = Tlab
            GridView2.Columns("TindakanID").Visible = False
            GridView2.Columns("NoUrut").Visible = False
        End If
    End Sub

    Public Sub LoadCompany(ByRef txkode As String, ByRef txlocationket As String)
        txcompany.Text = txlocationket
        txkodecabang.Text = txkode
    End Sub

    Private Sub PilihTanggal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PilihTanggal.Click
        If txkodecabang.Text = "" Then
            MsgBox("Pilih Company Terlebih Dahulu.")
            Exit Sub
        End If

        SelectDateTime.LoadOptionDialog("TanggalReportSummaryMCUOnline", "Pilih Tanggal :")
        SelectDateTime.ShowDialog()
    End Sub

    Private Sub cmbjenisfilter_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbjenisfilter.SelectedIndexChanged
        If cmbjenisfilter.SelectedIndex = 0 Then
            Find.Show()
            Find.QueryTheMysql("select * from mastercompany a where now() between StartDate and EndDate ORDER BY a.idcompany", " ", "FindCabangSummaryOnline", 0, Find_Poliklinik)
        ElseIf cmbjenisfilter.SelectedIndex = 1 Then
            Find.Show()
            Find.QueryTheMysql("SELECT a.kodecabang, a.kodebarcode, a.kodeket FROM mastercodebarcode a GROUP BY a.kodebarcode", " ORDER BY a.kodeket ASC", "FindCabangSummaryOnline", 0, Find_Poliklinik)
        Else
            MsgBox("Pilih Jenis Filter Cabang atau Company.")
        End If
    End Sub

    Private Sub CheckBoxCheckAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxCheckAll.CheckedChanged
        ' Nonaktifkan sementara event handler untuk mencegah pemicu ulang
        RemoveHandler CheckBoxCheckAll.CheckedChanged, AddressOf CheckBoxCheckAll_CheckedChanged

        Dim tblSummary As DataTable = gridtest.DataSource

        If tblSummary IsNot Nothing AndAlso tblSummary.Rows.Count > 0 Then
            For Each Trow As DataRow In tblSummary.Rows
                If CheckBoxCheckAll.CheckState = CheckState.Checked Then
                    Trow("Checked") = True
                Else
                    Trow("Checked") = False
                End If
            Next
        Else
            MsgBox("Data tidak ditemukan.", MsgBoxStyle.Critical, "Warning")

            ' Mengembalikan checkbox ke status False tanpa memicu event lagi
            CheckBoxCheckAll.Checked = False
        End If

        ' Aktifkan kembali event handler
        AddHandler CheckBoxCheckAll.CheckedChanged, AddressOf CheckBoxCheckAll_CheckedChanged
    End Sub
End Class


