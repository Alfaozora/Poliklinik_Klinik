Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Drawing

Public Class UploadTindakanLaboratorium
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

    Private Sub updateevent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttambahpasien.Click
        Try
            If txidloc.Text = "" Then
                MsgBox("Pilih Lokasi Terlebih Dahulu.", MsgBoxStyle.Exclamation, "Warning!")
                Exit Sub
            End If

            opFileDialog.Filter = "Excel Files 2003|*.xls|Excel Files|*.xlsx"
            opFileDialog.Title = "Select a Excel File"

            If opFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Dim fi As New FileInfo(opFileDialog.FileName)
                Dim FileName As String = opFileDialog.FileName

                'Pecah Nama Excel
                'Dim splitnamefile() As String = fi.Name.Split(".")
                excel = fi.FullName

                conn = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excel + ";Extended Properties=Excel 12.0;")
                'dta = New OleDbDataAdapter("Select * From [" & splitnamefile(0).Trim & "$]", conn)
                dta = New OleDbDataAdapter("Select * From [Sheet1$]", conn)
                dts = New DataSet("NewTables")
                dta.Fill(dts)

                ' Ganti karakter pagar (#) dengan titik (.) pada nama kolom
                For Each col As DataColumn In dts.Tables(0).Columns
                    col.ColumnName = col.ColumnName.Replace("@", ".")
                Next

                gridlab.DataSource = dts.Tables(0)
                conn.Close()
            End If

            butsavemultiple.Enabled = False
            butsavelab.Enabled = True
        Catch ex As Exception
            conn.Close()
            MsgBox(ex.ToString)
        End Try
    End Sub

    Function CheckTransaksiOffline(ByRef Temp As DataTable) As Boolean
        Dim DetailNourut As String = ""
        Dim TtempNourut As String = ""
        For Each Trow As DataRow In Temp.Rows
            TtempNourut = TtempNourut & "'" & Trow("NoUrut").ToString.Trim & "', "
        Next
        DetailNourut = Strings.Left(TtempNourut, TtempNourut.Length - 2)

        Dim Tempthorax As DataTable = ReadSQL("SELECT * FROM TransaksiLab WHERE NoUrut IN (" & DetailNourut & ") AND DetailPemeriksaan NOT LIKE '%THORAX%'")

        'Cek Pemeriksaan Thorax Setiap Transaksi
        If Tempthorax.Rows.Count > 0 Then
            MsgBox("Terdapat Transaksi yang tidak ada pemeriksaan Thorax.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        'Cek Transaksi yang tidak ada dalam database
        Dim CountTransaksi As String = ReadSQLNIK("SELECT COUNT(NoUrut) as JumlahTransaksi FROM TransaksiLab WHERE NoUrut IN (" & DetailNourut & ")")
        If CountTransaksi <> Temp.Rows.Count Then
            MsgBox("Terdapat Transaksi yang tidak ada didalam Database, cek kembali nourut transaksi.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        Return True
    End Function

    Function CheckTransaksiOnline(ByRef Temp As DataTable) As Boolean
        Dim DetailNourut As String = ""
        Dim TtempNourut As String = ""
        For Each Trow As DataRow In Temp.Rows
            TtempNourut = TtempNourut & "'" & Trow("NoUrut").ToString.Trim & "', "
        Next
        DetailNourut = Strings.Left(TtempNourut, TtempNourut.Length - 2)

        Dim Tempthorax As DataTable = ReadThemysql("SELECT * FROM transaksilab a WHERE a.nourut IN (" & DetailNourut & ") AND a.DetailPemeriksaan NOT LIKE '%THORAX%' AND a.idtempatlab = '" & txidloc.Text.Trim & "'", DB_Poliklinik)

        'Cek Pemeriksaan Thorax Setiap Transaksi
        If Tempthorax.Rows.Count > 0 Then
            MsgBox("Terdapat Transaksi yang tidak ada pemeriksaan Thorax.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        'Cek Transaksi yang tidak ada dalam database
        Dim CountTransaksi As String = ReadThemysqlNIK("SELECT COUNT(a.nourut) as JumlahTransaksi FROM transaksilab a WHERE a.nourut IN (" & DetailNourut & ") AND a.idtempatlab = '" & txidloc.Text.Trim & "'", DB_Poliklinik)
        If CountTransaksi <> Temp.Rows.Count Then
            MsgBox("Terdapat Transaksi yang tidak ada didalam Database, cek kembali nourut transaksi.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        Return True
    End Function

    Private Sub SetGrid()
        gridlab.DataSource = Nothing

        ProgressBar1.Value = 0
        ProgressBar1.Visible = False
        butsavemultiple.Enabled = False
        rdOnline.Checked = True
        gridlab.DataSource = Nothing
        cmbstatustransaksi.SelectedIndex = 0
    End Sub

    Private Sub UploadTindakanLaboratorium_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
        Me.MdiParent = PoliKlinik
        Me.BringToFront()
        SetConn()
        SetGrid()
        Dim y As Integer = Screen.PrimaryScreen.Bounds.Height * 0.025
        Dim x As Integer = Screen.PrimaryScreen.Bounds.Width * 0.025
        Me.Location = New Point(x, y)
        Me.Height = Screen.PrimaryScreen.Bounds.Height * 0.8
        Me.Width = Screen.PrimaryScreen.Bounds.Width * 0.95
    End Sub

    Private Sub butsavelab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butsavelab.Click
        thread = New System.Threading.Thread(AddressOf SaveUpload)
        thread.Start()
    End Sub

    Private Sub SaveUpload()
        Dim Tbls As DataTable = gridlab.DataSource
        Dim saved As Integer = 1

        Try
            If Tbls.Rows.Count > 0 Then
                butsavelab.Enabled = False
                ProgressBar1.Visible = True
                Dim TindakanNull As Boolean = True
                Dim NamaTindakanNull As String = ""

                Dim persen As Integer = 0
                Dim jumlah As Integer = 0
                Dim TblsDetailTindakan As DataTable = New DataTable

                For Each Tdata As DataRow In Tbls.Rows
                    persen = persen + 1

                    TblsDetailTindakan = ReadThemysql("SELECT a.detailket, a.groupid, a.tindakanid, a.nourut FROM transaksilabresult a WHERE a.idlabinternet = '" & Tdata("idlabinternet") & "'", DB_Poliklinik)
                    For Each TDetailTindakan As DataRow In TblsDetailTindakan.Rows
                        Dim txDetailTindakan As String = TDetailTindakan("detailket") & "#" & TDetailTindakan("tindakanid") & "#" & TDetailTindakan("nourut")

                        If DBNull.Value Is Tdata("idlabinternet") Then
                            MsgBox("Terdapat data excel yang kosong, periksa data upload kembali.", MsgBoxStyle.Exclamation, "Warning!")
                            saved = 0
                            Exit For
                        End If

                        'If TDetailTindakan("groupid") = "Urine Lengkap" And TDetailTindakan("nourut") <> "1" And TDetailTindakan("nourut") <> "12" And TDetailTindakan("nourut") <> "20" Then
                        'If TDetailTindakan("tindakanid") = "Hematologi lengkap" Then
                        If txDetailTindakan <> "Lain-lain#36#20" And txDetailTindakan <> "SEDIMEN :#36#12" And txDetailTindakan <> "Makros#36#1" Then
                            If Tdata("" & txDetailTindakan & "").ToString.Trim = "" Or Tdata("" & txDetailTindakan & "").ToString.Trim = "-" Then
                                TindakanNull = False
                                NamaTindakanNull = TDetailTindakan("detailket")
                            End If
                        End If
                    Next

                    If TindakanNull = False Then
                        MsgBox("Terdapat data yang belum diisi, periksa data upload atas nama " & Tdata("nama") & " (Tindakan : " & NamaTindakanNull & ").", MsgBoxStyle.Exclamation, "Warning!")
                        saved = 0
                        Exit For
                    End If

                    Dim procent As Integer = persen * 100 / Tbls.Rows.Count
                    ProgressBar1.Value = procent
                Next
            Else
                MsgBox("Tidak ada data yang di Upload.", MsgBoxStyle.Exclamation, "Warning!")
                saved = 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

        If saved = 0 Then
            butsavemultiple.Enabled = False
            MsgBox("Data Gagal Upload.", MsgBoxStyle.Critical, "Failed")
        Else
            For Each Tcol As DataColumn In Tbls.Columns
                Tcol.ReadOnly = True
            Next

            butsavemultiple.Enabled = True
            MsgBox(Tbls.Rows.Count & " data berhasil disimpan, klik tombol save multiple untuk melanjutkan.", MsgBoxStyle.Information, "Success!")
        End If

        ProgressBar1.Visible = False
    End Sub

    Private Sub butsavemultiple_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butsavemultiple.Click
        thread = New System.Threading.Thread(AddressOf SaveMultiple)
        thread.Start()
    End Sub

    Private Sub SaveMultiple()
        butsavemultiple.Enabled = False
        buttambahpasien.Enabled = False

        Dim procent As Integer = 0
        Dim persen As Integer = 0

        If MsgBox("Yakin proses lanjut ?", MsgBoxStyle.YesNo, "Verifikasi Akhir") = MsgBoxResult.Yes Then
            ProgressBar1.Visible = True

            Dim Ttemp As DataTable = gridlab.DataSource
            Dim TblsDetailTindakan As DataTable = New DataTable
            Ttemp.AcceptChanges()

            For Each Tdata As DataRow In Ttemp.Rows
                persen = persen + 1
                procent = persen * 100 / Ttemp.Rows.Count
                ProgressBar1.Value = procent

                'Inisialisasi Saran/Keterangan
                Dim varResultDBString As String = ""
                Dim varResult As Double = 0
                Dim varJenisResult As String = ""
                Dim T1 As Double = 0
                Dim T2 As Double = 0
                Dim varResultDB As Double = 0
                Dim varSaranDB As String = 0
                Dim varKetDB As String = 0
                Dim varKey As String = 0
                Dim ArrayResult = New String() {}
                Dim displayKeterangan As String = ""
                Dim displayKeteranganReaktif As String = ""
                Dim displayKeteranganNonReaktif As String = ""
                Dim displaySaranReaktif As String = ""
                Dim displaySaranNonReaktif As String = ""
                Dim spasi As String = "  - "
                Dim totalKetReaktif As Integer = 0
                Dim totalKetNonReaktif As Integer = 0
                Dim totalSaranReaktif As Integer = 0
                Dim totalSaranNonReaktif As Integer = 0
                Dim tandabaca As String = ""
                Dim saranAkhir As String = ""
                Dim keteranganAkhir As String = ""
                Dim kesimpulanAkhir As String = ""
                Dim statusKesehatan As String = ""
                Dim statusUnfitSementara As Boolean = False
                Dim statusUnfit As Boolean = False

                Dim statusKesehatanThorax As Boolean = False
                Dim statusKesehatanFisik As Boolean = False

                'Manual Code
                Dim varKonversiSatuanMindray As Double = 0
                Dim varKonversiSatuanArcht As Double = 0

                TblsDetailTindakan = ReadThemysql("SELECT a.detailket, a.groupid, a.tindakanid, a.nourut FROM transaksilabresult a WHERE a.idlabinternet = '" & Tdata("idlabinternet") & "'", DB_Poliklinik)
                For Each TDetailTindakan As DataRow In TblsDetailTindakan.Rows
                    Dim txDetailTindakan As String = TDetailTindakan("detailket") & "#" & TDetailTindakan("tindakanid") & "#" & TDetailTindakan("nourut")

                    'Khusus Urine
                    'If TDetailTindakan("tindakanid") = "Urine Lengkap" And TDetailTindakan("nourut") <> "1" And TDetailTindakan("nourut") <> "12" And TDetailTindakan("nourut") <> "20" Then
                    'If TDetailTindakan("tindakanid") = "Hematologi lengkap" Then
                    If txDetailTindakan <> "Lain-lain#36#20" And txDetailTindakan <> "SEDIMEN :#36#12" And txDetailTindakan <> "Makros#36#1" Then
                        If Tdata("" & txDetailTindakan & "").ToString.Trim <> "" And Tdata("" & txDetailTindakan & "").ToString.Trim <> "-" Then

                            '====================================================================
                            'Set Status Kesehatan Thorax/Fisik
                            '====================================================================

                            'Fisik
                            If Strings.LCase(TDetailTindakan("detailket").ToString).Contains("fisik") = True And statusKesehatanFisik = False Then
                                statusKesehatanFisik = True
                            End If

                            'Thorax
                            If Strings.LCase(TDetailTindakan("detailket").ToString).Contains("thorax") = True And statusKesehatanThorax = False Then
                                statusKesehatanThorax = True
                            End If

                            '====================================================================
                            '====================================================================


                            '====================================================================
                            'Set Saran/Keterangan
                            '====================================================================

                            Dim SaranTindakan As String = ""
                            Dim KetTindakan As String = ""

                            If Tdata("sex") = "L" Then
                                ArrayResult = New String() {"PriaBatasBawah", "PriaBatasNormal", "PriaAmbangBatasTinggi", "PriaBatasAtas"}
                            ElseIf Tdata("sex") = "P" Then
                                ArrayResult = New String() {"WanitaBatasBawah", "WanitaBatasNormal", "WanitaAmbangBatasTinggi", "WanitaBatasAtas"}
                            End If

                            varJenisResult = Tdata("" & txDetailTindakan & "").ToString.Trim

                            '========== MANUAL CODE =========='

                            'SARS-COV-2 S-RBD IgG (Mindray)
                            If TDetailTindakan("DetailKet").ToString.Trim = "SARS-COV-2 S-RBD IgG" And varJenisResult <> "" And TDetailTindakan("NoUrut") = "1" Then
                                varKonversiSatuanMindray = varJenisResult / 0.8229
                            ElseIf TDetailTindakan("DetailKet").ToString.Trim = "SARS-COV-2 S-RBD IgG" And varKonversiSatuanMindray >= 0 And TDetailTindakan("NoUrut") = "2" Then
                                TDetailTindakan("Result") = Math.Round(varKonversiSatuanMindray, 2)
                            End If

                            'SARS-CoV-2 S-RBD IgG (ARCHT)
                            If TDetailTindakan("DetailKet").ToString.Trim = "SARS-CoV-2 S-RBD IgG (ARCHT)" And varJenisResult <> "" And TDetailTindakan("NoUrut") = "1" Then
                                varKonversiSatuanMindray = varJenisResult * 0.142
                            ElseIf TDetailTindakan("DetailKet").ToString.Trim = "SARS-CoV-2 S-RBD IgG (ARCHT)" And varKonversiSatuanMindray >= 0 And TDetailTindakan("NoUrut") = "2" Then
                                TDetailTindakan("Result") = Math.Round(varKonversiSatuanMindray, 2)
                            End If

                            '======== END MANUAL CODE ========'

                            'If TDetailTindakan("DetailKet").ToString.Contains("Widal") = True And varJenisResult.Contains("/") = True Then
                            If TDetailTindakan("tindakanid").ToString = "216" And varJenisResult.Contains("/") = True Then
                                Dim splitwidal() As String = varJenisResult.Split("/")
                                varJenisResult = splitwidal(1)
                            End If

                            Dim VarLebihKurang As String = ""
                            If varJenisResult.Contains(">") = True Then
                                VarLebihKurang = Strings.Replace(Strings.Replace(varJenisResult, ">", ""), " ", "")
                                varJenisResult = VarLebihKurang + 0.01
                            ElseIf varJenisResult.Contains("<") = True Then
                                VarLebihKurang = Strings.Replace(Strings.Replace(varJenisResult, "<", ""), " ", "")
                                varJenisResult = VarLebihKurang - 0.01
                            End If

                            If IsNumeric(varJenisResult) = True And varJenisResult <> "" Then
                                Dim TblsSaran As DataTable = ReadSQL("select * from MasterLabdetailBaru where TindakanID='" & TDetailTindakan("tindakanid") & "' and GroupID='" & TDetailTindakan("groupid") & "' and NoUrut='" & TDetailTindakan("nourut") & "' and (CONVERT(VARCHAR, PriaBatasBawah)<>'' or CONVERT(VARCHAR, PriaBatasNormal)<>'' or CONVERT(VARCHAR, PriaAmbangBatasTinggi)<>'' or CONVERT(VARCHAR, PriaBatasAtas)<>'')")
                                If TblsSaran.Rows.Count > 0 Then
                                    For Each Trow As DataRow In TblsSaran.Rows
                                        varResult = Strings.Replace(varJenisResult, ",", ".")
                                        For Each element As String In ArrayResult
                                            varResultDBString = ReadSQLNIK("select " + element + " from MasterLabdetailBaru where TindakanID='" & TDetailTindakan("tindakanid") & "' and GroupID='" & TDetailTindakan("groupid") & "' and NoUrut='" & TDetailTindakan("nourut") & "' and (CONVERT(VARCHAR, PriaBatasBawah)<>'' or CONVERT(VARCHAR, PriaBatasNormal)<>'' or CONVERT(VARCHAR, PriaAmbangBatasTinggi)<>'' or CONVERT(VARCHAR, PriaBatasAtas)<>'')")
                                            varKetDB = ReadSQLNIK("select " + "Ket" + element + " from MasterLabdetailBaru where TindakanID='" & TDetailTindakan("tindakanid") & "' and GroupID='" & TDetailTindakan("groupid") & "' and NoUrut='" & TDetailTindakan("nourut") & "' and (CONVERT(VARCHAR, PriaBatasBawah)<>'' or CONVERT(VARCHAR, PriaBatasNormal)<>'' or CONVERT(VARCHAR, PriaAmbangBatasTinggi)<>'' or CONVERT(VARCHAR, PriaBatasAtas)<>'')")
                                            varSaranDB = ReadSQLNIK("select " + "Saran" + element + " from MasterLabdetailBaru where TindakanID='" & TDetailTindakan("tindakanid") & "' and GroupID='" & TDetailTindakan("groupid") & "' and NoUrut='" & TDetailTindakan("nourut") & "' and (CONVERT(VARCHAR, PriaBatasBawah)<>'' or CONVERT(VARCHAR, PriaBatasNormal)<>'' or CONVERT(VARCHAR, PriaAmbangBatasTinggi)<>'' or CONVERT(VARCHAR, PriaBatasAtas)<>'')")
                                            If varResultDBString <> "" Then
                                                varResultDBString = Strings.Replace(varResultDBString, ",", ".")
                                                If varResultDBString.Contains("<") = True Then
                                                    varResultDB = Trim(Strings.Replace(Strings.Replace(varResultDBString, "<", ""), "=", ""))
                                                    If varResultDBString.Contains("=") = True Then
                                                        If varResult <= varResultDB Then
                                                            SaranTindakan = varSaranDB
                                                            KetTindakan = varKetDB
                                                            If element.Contains("BatasNormal") = False Then
                                                                totalKetReaktif = totalKetReaktif + 1
                                                                If totalKetReaktif > 1 Then
                                                                    displayKeteranganReaktif = displayKeteranganReaktif + spasi + TDetailTindakan("detailket") + " : " + varKetDB + vbCrLf
                                                                Else
                                                                    displayKeteranganReaktif = displayKeteranganReaktif + TDetailTindakan("detailket") + " : " + varKetDB + vbCrLf
                                                                End If

                                                                If displaySaranReaktif.Contains("" & varSaranDB & "") = False Then
                                                                    totalSaranReaktif = totalSaranReaktif + 1
                                                                    If totalSaranReaktif > 1 Then
                                                                        displaySaranReaktif = displaySaranReaktif + spasi + varSaranDB + vbCrLf
                                                                    Else
                                                                        displaySaranReaktif = displaySaranReaktif + varSaranDB + vbCrLf
                                                                    End If
                                                                End If
                                                            Else
                                                                totalKetNonReaktif = totalKetNonReaktif + 1
                                                                If totalKetNonReaktif > 1 Then
                                                                    displayKeteranganNonReaktif = displayKeteranganNonReaktif + spasi + TDetailTindakan("detailket") + " : " + varKetDB + vbCrLf
                                                                Else
                                                                    displayKeteranganNonReaktif = displayKeteranganNonReaktif + TDetailTindakan("detailket") + " : " + varKetDB + vbCrLf
                                                                End If

                                                                If displaySaranNonReaktif.Contains("" & varSaranDB & "") = False Then
                                                                    totalSaranNonReaktif = totalSaranNonReaktif + 1
                                                                    If totalSaranNonReaktif > 1 Then
                                                                        displaySaranNonReaktif = displaySaranNonReaktif + spasi + varSaranDB + vbCrLf
                                                                    Else
                                                                        displaySaranNonReaktif = displaySaranNonReaktif + varSaranDB + vbCrLf
                                                                    End If
                                                                End If
                                                            End If
                                                            varKey = 1
                                                            Exit For
                                                        End If
                                                    Else
                                                        If varResult < varResultDB Then
                                                            SaranTindakan = varSaranDB
                                                            KetTindakan = varKetDB
                                                            If element.Contains("BatasNormal") = False Then
                                                                totalKetReaktif = totalKetReaktif + 1
                                                                If totalKetReaktif > 1 Then
                                                                    displayKeteranganReaktif = displayKeteranganReaktif + spasi + TDetailTindakan("detailket") + " : " + varKetDB + vbCrLf
                                                                Else
                                                                    displayKeteranganReaktif = displayKeteranganReaktif + TDetailTindakan("detailket") + " : " + varKetDB + vbCrLf
                                                                End If

                                                                If displaySaranReaktif.Contains("" & varSaranDB & "") = False Then
                                                                    totalSaranReaktif = totalSaranReaktif + 1
                                                                    If totalSaranReaktif > 1 Then
                                                                        displaySaranReaktif = displaySaranReaktif + spasi + varSaranDB + vbCrLf
                                                                    Else
                                                                        displaySaranReaktif = displaySaranReaktif + varSaranDB + vbCrLf
                                                                    End If
                                                                End If
                                                            Else
                                                                totalKetNonReaktif = totalKetNonReaktif + 1
                                                                If totalKetNonReaktif > 1 Then
                                                                    displayKeteranganNonReaktif = displayKeteranganNonReaktif + spasi + TDetailTindakan("detailket") + " : " + varKetDB + vbCrLf
                                                                Else
                                                                    displayKeteranganNonReaktif = displayKeteranganNonReaktif + TDetailTindakan("detailket") + " : " + varKetDB + vbCrLf
                                                                End If

                                                                If displaySaranNonReaktif.Contains("" & varSaranDB & "") = False Then
                                                                    totalSaranNonReaktif = totalSaranNonReaktif + 1
                                                                    If totalSaranNonReaktif > 1 Then
                                                                        displaySaranNonReaktif = displaySaranNonReaktif + spasi + varSaranDB + vbCrLf
                                                                    Else
                                                                        displaySaranNonReaktif = displaySaranNonReaktif + varSaranDB + vbCrLf
                                                                    End If
                                                                End If
                                                            End If
                                                            varKey = 1
                                                            Exit For
                                                        End If
                                                    End If
                                                ElseIf varResultDBString.Contains(">") = True Then
                                                    varResultDB = Trim(Strings.Replace(Strings.Replace(varResultDBString, ">", ""), "=", ""))
                                                    If varResultDBString.Contains("=") = True Then
                                                        If varResult >= varResultDB Then
                                                            SaranTindakan = varSaranDB
                                                            KetTindakan = varKetDB
                                                            If element.Contains("BatasNormal") = False Then
                                                                totalKetReaktif = totalKetReaktif + 1
                                                                If totalKetReaktif > 1 Then
                                                                    displayKeteranganReaktif = displayKeteranganReaktif + spasi + TDetailTindakan("detailket") + " : " + varKetDB + vbCrLf
                                                                Else
                                                                    displayKeteranganReaktif = displayKeteranganReaktif + TDetailTindakan("detailket") + " : " + varKetDB + vbCrLf
                                                                End If

                                                                If displaySaranReaktif.Contains("" & varSaranDB & "") = False Then
                                                                    totalSaranReaktif = totalSaranReaktif + 1
                                                                    If totalSaranReaktif > 1 Then
                                                                        displaySaranReaktif = displaySaranReaktif + spasi + varSaranDB + vbCrLf
                                                                    Else
                                                                        displaySaranReaktif = displaySaranReaktif + varSaranDB + vbCrLf
                                                                    End If
                                                                End If
                                                            Else
                                                                totalKetNonReaktif = totalKetNonReaktif + 1
                                                                If totalKetNonReaktif > 1 Then
                                                                    displayKeteranganNonReaktif = displayKeteranganNonReaktif + spasi + TDetailTindakan("detailket") + " : " + varKetDB + vbCrLf
                                                                Else
                                                                    displayKeteranganNonReaktif = displayKeteranganNonReaktif + TDetailTindakan("detailket") + " : " + varKetDB + vbCrLf
                                                                End If

                                                                If displaySaranNonReaktif.Contains("" & varSaranDB & "") = False Then
                                                                    totalSaranNonReaktif = totalSaranNonReaktif + 1
                                                                    If totalSaranNonReaktif > 1 Then
                                                                        displaySaranNonReaktif = displaySaranNonReaktif + spasi + varSaranDB + vbCrLf
                                                                    Else
                                                                        displaySaranNonReaktif = displaySaranNonReaktif + varSaranDB + vbCrLf
                                                                    End If
                                                                End If
                                                            End If
                                                            varKey = 1
                                                            Exit For
                                                        End If
                                                    Else
                                                        If varResult > varResultDB Then
                                                            SaranTindakan = varSaranDB
                                                            KetTindakan = varKetDB
                                                            If element.Contains("BatasNormal") = False Then
                                                                totalKetReaktif = totalKetReaktif + 1
                                                                If totalKetReaktif > 1 Then
                                                                    displayKeteranganReaktif = displayKeteranganReaktif + spasi + TDetailTindakan("detailket") + " : " + varKetDB + vbCrLf
                                                                Else
                                                                    displayKeteranganReaktif = displayKeteranganReaktif + TDetailTindakan("detailket") + " : " + varKetDB + vbCrLf
                                                                End If

                                                                If displaySaranReaktif.Contains("" & varSaranDB & "") = False Then
                                                                    totalSaranReaktif = totalSaranReaktif + 1
                                                                    If totalSaranReaktif > 1 Then
                                                                        displaySaranReaktif = displaySaranReaktif + spasi + varSaranDB + vbCrLf
                                                                    Else
                                                                        displaySaranReaktif = displaySaranReaktif + varSaranDB + vbCrLf
                                                                    End If
                                                                End If
                                                            Else
                                                                If displaySaranNonReaktif.Contains("" & varSaranDB & "") = False Then
                                                                    totalSaranNonReaktif = totalSaranNonReaktif + 1
                                                                    If totalSaranNonReaktif > 1 Then
                                                                        displaySaranNonReaktif = displaySaranNonReaktif + spasi + varSaranDB + vbCrLf
                                                                    Else
                                                                        displaySaranNonReaktif = displaySaranNonReaktif + varSaranDB + vbCrLf
                                                                    End If
                                                                End If
                                                            End If
                                                            varKey = 1
                                                            Exit For
                                                        End If
                                                    End If
                                                ElseIf varResultDBString.Contains("-") = True Then
                                                    Dim Tsplit() As String = varResultDBString.ToString.Split("-")
                                                    T1 = Trim(Tsplit(0))
                                                    T2 = Trim(Tsplit(1))
                                                    If varResult >= T1 And varResult <= T2 Then
                                                        SaranTindakan = varSaranDB
                                                        KetTindakan = varKetDB
                                                        If element.Contains("BatasNormal") = False Then
                                                            totalKetReaktif = totalKetReaktif + 1
                                                            If totalKetReaktif > 1 Then
                                                                displayKeteranganReaktif = displayKeteranganReaktif + spasi + TDetailTindakan("detailket") + " : " + varKetDB + vbCrLf
                                                            Else
                                                                displayKeteranganReaktif = displayKeteranganReaktif + TDetailTindakan("detailket") + " : " + varKetDB + vbCrLf
                                                            End If

                                                            If displaySaranReaktif.Contains("" & varSaranDB & "") = False Then
                                                                totalSaranReaktif = totalSaranReaktif + 1
                                                                If totalSaranReaktif > 1 Then
                                                                    displaySaranReaktif = displaySaranReaktif + spasi + varSaranDB + vbCrLf
                                                                Else
                                                                    displaySaranReaktif = displaySaranReaktif + varSaranDB + vbCrLf
                                                                End If
                                                            End If
                                                        Else
                                                            If displaySaranNonReaktif.Contains("" & varSaranDB & "") = False Then
                                                                totalSaranNonReaktif = totalSaranNonReaktif + 1
                                                                If totalSaranNonReaktif > 1 Then
                                                                    displaySaranNonReaktif = displaySaranNonReaktif + spasi + varSaranDB + vbCrLf
                                                                Else
                                                                    displaySaranNonReaktif = displaySaranNonReaktif + varSaranDB + vbCrLf
                                                                End If
                                                            End If
                                                        End If
                                                        varKey = 1
                                                        Exit For
                                                    End If
                                                End If
                                            End If
                                        Next
                                    Next
                                End If
                            ElseIf varJenisResult <> "" Then
                                'UNTUK INPUTAN REAKTIF/NON REAKTIF DAN NEGATIF/POSITIF BUKAN ANGKA
                                Dim TblsNonAngka As DataTable = ReadSQL("select * from MasterLabdetailBaru where TindakanID='" & TDetailTindakan("tindakanid") & "' and GroupID='" & TDetailTindakan("groupid") & "' and NoUrut='" & TDetailTindakan("nourut") & "' and (CONVERT(VARCHAR, PriaReaktif)<>'' or CONVERT(VARCHAR, WanitaReaktif)<>'' or CONVERT(VARCHAR, PriaNonReaktif)<>'' or CONVERT(VARCHAR, WanitaNonReaktif)<>'')")
                                If TblsNonAngka.Rows.Count > 0 Then
                                    Dim TrowNonAngka As DataRow = TblsNonAngka.Rows(0)
                                    If Tdata("sex") = "L" Then
                                        If CheckSQL("select * from MasterLabdetailBaru where TindakanID='" & TDetailTindakan("tindakanid") & "' and GroupID='" & TDetailTindakan("groupid") & "' and NoUrut='" & TDetailTindakan("nourut") & "' and (CONVERT(VARCHAR, PriaReaktif) = '" & varJenisResult & "')") = True Then
                                            SaranTindakan = TrowNonAngka("SaranPriaReaktif").ToString
                                            KetTindakan = TrowNonAngka("KetPriaReaktif").ToString

                                            totalKetReaktif = totalKetReaktif + 1
                                            If totalKetReaktif > 1 Then
                                                displayKeteranganReaktif = displayKeteranganReaktif + spasi + TDetailTindakan("detailket") + " : " + TrowNonAngka("KetPriaReaktif").ToString + vbCrLf
                                            Else
                                                displayKeteranganReaktif = displayKeteranganReaktif + TDetailTindakan("detailket") + " : " + TrowNonAngka("KetPriaReaktif").ToString + vbCrLf
                                            End If

                                            If displaySaranReaktif.Contains("" & TrowNonAngka("SaranPriaReaktif").ToString & "") = False Then
                                                totalSaranReaktif = totalSaranReaktif + 1
                                                If totalSaranReaktif > 1 Then
                                                    displaySaranReaktif = displaySaranReaktif + spasi + TrowNonAngka("SaranPriaReaktif").ToString + vbCrLf
                                                Else
                                                    displaySaranReaktif = displaySaranReaktif + TrowNonAngka("SaranPriaReaktif").ToString + vbCrLf
                                                End If
                                            End If
                                            varKey = 1
                                        ElseIf CheckSQL("select * from MasterLabdetailBaru where TindakanID='" & TDetailTindakan("tindakanid") & "' and GroupID='" & TDetailTindakan("groupid") & "' and NoUrut='" & TDetailTindakan("nourut") & "' and (CONVERT(VARCHAR, PriaNonReaktif) = '" & varJenisResult & "')") = True Then
                                            SaranTindakan = TrowNonAngka("SaranPriaNonReaktif").ToString
                                            KetTindakan = TrowNonAngka("KetPriaNonReaktif").ToString

                                            totalKetNonReaktif = totalKetNonReaktif + 1
                                            If totalKetNonReaktif > 1 Then
                                                displayKeteranganNonReaktif = displayKeteranganNonReaktif + spasi + TDetailTindakan("detailket") + " : " + TrowNonAngka("KetPriaNonReaktif").ToString + vbCrLf
                                            Else
                                                displayKeteranganNonReaktif = displayKeteranganNonReaktif + TDetailTindakan("detailket") + " : " + TrowNonAngka("KetPriaNonReaktif").ToString + vbCrLf
                                            End If

                                            If displaySaranNonReaktif.Contains("" & TrowNonAngka("SaranPriaNonReaktif").ToString & "") = False Then
                                                totalSaranNonReaktif = totalSaranNonReaktif + 1
                                                If totalSaranNonReaktif > 1 Then
                                                    displaySaranNonReaktif = displaySaranNonReaktif + spasi + TrowNonAngka("SaranPriaNonReaktif").ToString + vbCrLf
                                                Else
                                                    displaySaranNonReaktif = displaySaranNonReaktif + TrowNonAngka("SaranPriaNonReaktif").ToString + vbCrLf
                                                End If
                                            End If
                                            varKey = 1
                                        End If
                                    ElseIf Tdata("sex") = "P" Then
                                        If CheckSQL("select * from MasterLabdetailBaru where TindakanID='" & TDetailTindakan("tindakanid") & "' and GroupID='" & TDetailTindakan("groupid") & "' and NoUrut='" & TDetailTindakan("nourut") & "' and (CONVERT(VARCHAR, WanitaReaktif) = '" & varJenisResult & "')") = True Then
                                            SaranTindakan = TrowNonAngka("SaranWanitaReaktif").ToString
                                            KetTindakan = TrowNonAngka("KetWanitaReaktif").ToString

                                            totalKetReaktif = totalKetReaktif + 1
                                            If totalKetReaktif > 1 Then
                                                displayKeteranganReaktif = displayKeteranganReaktif + spasi + TDetailTindakan("detailket") + " : " + TrowNonAngka("KetWanitaReaktif").ToString + vbCrLf
                                            Else
                                                displayKeteranganReaktif = displayKeteranganReaktif + TDetailTindakan("detailket") + " : " + TrowNonAngka("KetWanitaReaktif").ToString + vbCrLf
                                            End If

                                            If displaySaranReaktif.Contains("" & TrowNonAngka("SaranWanitaReaktif").ToString & "") = False Then
                                                totalSaranReaktif = totalSaranReaktif + 1
                                                If totalSaranReaktif > 1 Then
                                                    displaySaranReaktif = displaySaranReaktif + spasi + TrowNonAngka("SaranWanitaReaktif").ToString + vbCrLf
                                                Else
                                                    displaySaranReaktif = displaySaranReaktif + TrowNonAngka("SaranWanitaReaktif").ToString + vbCrLf
                                                End If
                                            End If
                                            varKey = 1
                                        ElseIf CheckSQL("select * from MasterLabdetailBaru where TindakanID='" & TDetailTindakan("tindakanid") & "' and GroupID='" & TDetailTindakan("groupid") & "' and NoUrut='" & TDetailTindakan("nourut") & "' and (CONVERT(VARCHAR, WanitaNonReaktif) = '" & varJenisResult & "')") = True Then
                                            SaranTindakan = TrowNonAngka("SaranWanitaNonReaktif").ToString
                                            KetTindakan = TrowNonAngka("KetWanitaNonReaktif").ToString

                                            totalKetNonReaktif = totalKetNonReaktif + 1
                                            If totalKetNonReaktif > 1 Then
                                                displayKeteranganNonReaktif = displayKeteranganNonReaktif + spasi + TDetailTindakan("detailket") + " : " + TrowNonAngka("KetWanitaNonReaktif").ToString + vbCrLf
                                            Else
                                                displayKeteranganNonReaktif = displayKeteranganNonReaktif + TDetailTindakan("detailket") + " : " + TrowNonAngka("KetWanitaNonReaktif").ToString + vbCrLf
                                            End If

                                            If displaySaranNonReaktif.Contains("" & TrowNonAngka("SaranWanitaNonReaktif").ToString & "") = False Then
                                                totalSaranNonReaktif = totalSaranNonReaktif + 1
                                                If totalSaranNonReaktif > 1 Then
                                                    displaySaranNonReaktif = displaySaranNonReaktif + spasi + TrowNonAngka("SaranWanitaNonReaktif").ToString + vbCrLf
                                                Else
                                                    displaySaranNonReaktif = displaySaranNonReaktif + TrowNonAngka("SaranWanitaNonReaktif").ToString + vbCrLf
                                                End If
                                            End If
                                            varKey = 1
                                        End If
                                    End If
                                End If
                            End If

                            'Jika HBsAg Reaktif
                            If TDetailTindakan("DetailKet").ToString.Contains("HBsAg") = True And (KetTindakan = "Positif" Or KetTindakan = "Reaktif" Or varJenisResult = "Positif" Or varJenisResult = "Reaktif") Then
                                statusUnfitSementara = True
                            End If

                            'Jika THC Reaktif
                            If (TDetailTindakan("DetailKet").ToString.Contains("THC") = True Or TDetailTindakan("DetailKet").ToString.Contains("Narkoba") = True Or TDetailTindakan("DetailKet").ToString.Contains("Metaphetamine") = True) And (KetTindakan = "Positif" Or varJenisResult = "Positif") Then
                                statusUnfit = True
                            End If

                            '====================================================================
                            '====================================================================

                            '#aktifkan jika MCU PT KAS
                            'WriteThemysql("update transaksilabresult set acc1=CONCAT('" & userUploadMCU & "',';',now()) ,acc2=CONCAT('BYPASS;',now()), result='" & Tdata("" & txDetailTindakan & "").ToString.Trim & "', Keterangan='" & KetTindakan & "', Saran='" & SaranTindakan & "' WHERE idlabinternet='" & Tdata("idlabinternet") & "' AND detailket = '" & TDetailTindakan("detailket") & "' AND groupid = '" & TDetailTindakan("groupid") & "' AND nourut = '" & TDetailTindakan("nourut") & "'", DB_Poliklinik)

                            '#aktifkan jika bukan MCU PT KAS
                            'WriteThemysql("update transaksilabresult set acc1=CONCAT('" & userUploadMCU & "',';',now()) ,acc2=CONCAT('BYPASS;',now()), result='" & Tdata("" & txDetailTindakan & "").ToString.Trim & "', Keterangan='', Saran='' WHERE idlabinternet='" & Tdata("idlabinternet") & "' AND detailket = '" & TDetailTindakan("detailket") & "' AND groupid = '" & TDetailTindakan("groupid") & "' AND nourut = '" & TDetailTindakan("nourut") & "'", DB_Poliklinik)

                            ' Update TransaksiLabResult
                            If RadioButtonKesimpulanYa.Checked = True Then
                                ' MCU PT KAS

                                ' Update Hasil TransaksiLabResult
                                WriteThemysql("UPDATE transaksilabresult SET acc1 = CONCAT('" & userUploadMCU & "',';',now()) ,acc2=CONCAT('BYPASS;',now()), result='" & Tdata("" & txDetailTindakan & "").ToString.Trim & "', Keterangan='" & KetTindakan & "', Saran='" & SaranTindakan & "' WHERE idlabinternet='" & Tdata("idlabinternet") & "' AND detailket = '" & TDetailTindakan("detailket") & "' AND groupid = '" & TDetailTindakan("groupid") & "' AND nourut = '" & TDetailTindakan("nourut") & "'", DB_Poliklinik)
                            ElseIf RadioButtonKesimpulanTidak.Checked = True Then
                                ' MCU Non PT KAS

                                ' Set Nilai Keterangan Hasil
                                Dim hasilKeterangan As String = ReadSQLNIK("SELECT KeteranganHasil FROM MasterLabDetail WHERE TindakanID = '" & TDetailTindakan("tindakanid") & "' AND DetailKet = '" & TDetailTindakan("detailket") & "' AND GroupID = '" & TDetailTindakan("groupid") & "' AND NoUrut = '" & TDetailTindakan("nourut") & "'")

                                ' Update Hasil TransaksiLabResult
                                WriteThemysql("UPDATE transaksilabresult SET acc1 = CONCAT('" & userUploadMCU & "',';',now()) ,acc2=CONCAT('BYPASS;',now()), result='" & Tdata("" & txDetailTindakan & "").ToString.Trim & "', Keterangan='" & hasilKeterangan & "', Saran='' WHERE idlabinternet='" & Tdata("idlabinternet") & "' AND detailket = '" & TDetailTindakan("detailket") & "' AND groupid = '" & TDetailTindakan("groupid") & "' AND nourut = '" & TDetailTindakan("nourut") & "'", DB_Poliklinik)
                            End If
                        End If
                    End If 'Endif Urine
                Next

                If statusUnfit = True Then
                    statusKesehatan = "UNFIT"
                ElseIf statusUnfitSementara = True Then
                    statusKesehatan = "UNFIT SEMENTARA"
                ElseIf totalKetReaktif > 0 Then
                    statusKesehatan = "FIT DENGAN CATATAN"
                Else
                    statusKesehatan = "FIT"
                End If

                If displayKeteranganNonReaktif <> "" Or displayKeteranganReaktif <> "" Or displaySaranReaktif <> "" Or displaySaranNonReaktif <> "" Then
                    If displayKeteranganNonReaktif <> "" Or displayKeteranganReaktif <> "" Then
                        If displayKeteranganReaktif <> "" Then
                            If totalKetReaktif > 1 Then
                                keteranganAkhir = spasi + displayKeteranganReaktif
                            Else
                                keteranganAkhir = displayKeteranganReaktif
                            End If
                        Else
                            If totalKetNonReaktif > 1 Then
                                keteranganAkhir = spasi + displayKeteranganNonReaktif
                            Else
                                keteranganAkhir = displayKeteranganNonReaktif
                            End If
                        End If
                    End If

                    If displaySaranReaktif <> "" Or displaySaranNonReaktif <> "" Then
                        If displaySaranReaktif <> "" Then
                            If totalSaranReaktif > 1 Then
                                saranAkhir = spasi + displaySaranReaktif
                            Else
                                saranAkhir = displaySaranReaktif
                            End If
                        Else
                            If totalSaranNonReaktif > 1 Then
                                saranAkhir = spasi + displaySaranNonReaktif
                            Else
                                saranAkhir = displaySaranNonReaktif
                            End If
                        End If
                    End If
                Else
                    keteranganAkhir = ""
                    saranAkhir = ""
                End If

                If statusKesehatan = "FIT" Then
                    kesimpulanAkhir = statusKesehatan
                Else
                    kesimpulanAkhir = statusKesehatan & vbCrLf & vbCrLf & keteranganAkhir
                End If

                ' Update Status Kesehatan Thorax/Fisik #aktifkan jika MCU PT KAS
                If RadioButtonKesimpulanYa.Checked = True Then
                    If statusKesehatanFisik = False And statusKesehatanThorax = False Then
                        WriteThemysql("update transaksilab set StatusKesehatanFisik='-', StatusKesehatanThorax='-' where idlabinternet='" & Tdata("idlabinternet") & "'", DB_Poliklinik)
                    ElseIf statusKesehatanFisik = False Then
                        WriteThemysql("update transaksilab set StatusKesehatanFisik='-' where idlabinternet='" & Tdata("idlabinternet") & "'", DB_Poliklinik)
                    ElseIf statusKesehatanThorax = False Then
                        WriteThemysql("update transaksilab set StatusKesehatanThorax='-' where idlabinternet='" & Tdata("idlabinternet") & "'", DB_Poliklinik)
                    End If
                End If

                '#Aktifkan jika MCU PT KAS
                'WriteThemysql("update transaksilab set StatusKesehatanLab='" & statusKesehatan & "',saran='" & saranAkhir & "', kesimpulan='" & kesimpulanAkhir & "', status='CETAK',  labstarttime=now(), labendtime=now(), tglinputhasil=now() where idlabinternet='" & Tdata("idlabinternet") & "'", DB_Poliklinik)

                '#Aktifkan Jika bukan MCU PT KAS
                'WriteThemysql("update transaksilab set saran='', kesimpulan='', status='CETAK',  labstarttime=now(), labendtime=now(), tglinputhasil=now() where idlabinternet='" & Tdata("idlabinternet") & "'", DB_Poliklinik)

                ' Update Saran & Keterangan
                If RadioButtonKesimpulanYa.Checked = True Then
                    WriteThemysql("UPDATE transaksilab SET StatusKesehatanLab='" & statusKesehatan & "',saran='" & saranAkhir & "', kesimpulan='" & kesimpulanAkhir & "', status='CETAK',  labstarttime=now(), labendtime=now(), tglinputhasil=now() WHERE idlabinternet='" & Tdata("idlabinternet") & "'", DB_Poliklinik)
                ElseIf RadioButtonKesimpulanTidak.Checked = True Then
                    WriteThemysql("UPDATE transaksilab SET saran='', kesimpulan='', status='CETAK',  labstarttime=now(), labendtime=now(), tglinputhasil=now() WHERE idlabinternet='" & Tdata("idlabinternet") & "'", DB_Poliklinik)
                End If
            Next

            MsgBox("Data berhasil disimpan.", MsgBoxStyle.Information, "Success!")
        Else
            MsgBox("Canceled.", MsgBoxStyle.Exclamation, "Warning!")
        End If

        buttambahpasien.Enabled = True
        ProgressBar1.Visible = False
    End Sub

    Private Sub butfindloc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butfindloc.Click
        If rdOnline.Checked = True Then
            Find.Show()
            Find.QueryTheMysql("SELECT a.kodecabang AS 'Lokasi ID', a.kodeket AS 'Keterangan Lokasi', a.kodebarcode AS 'Kode Barcode' FROM mastercodebarcode a ORDER BY a.kodeket ASC", " ", "FindCabangUploadLab", 0, Find_Poliklinik)
        End If
    End Sub

    Private Sub SetClearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SetConn()
        SetGrid()
    End Sub

    Private Sub rdOnline_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdOnline.CheckedChanged
        txloc.ResetText()
        txidloc.ResetText()
        butfindloc.Enabled = True
        gridlab.DataSource = Nothing
    End Sub

    Private Sub rdOffline_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdOffline.CheckedChanged
        txidloc.Text = ReadSQLNIK("select StrValue from MsConfig where ConfigName='NoPoli'")
        txloc.Text = ReadSQLNIK("select StrValue from MsConfig where ConfigName='NamaPoli'")
        butfindloc.Enabled = False
        gridlab.DataSource = Nothing
    End Sub

    Private Sub butfindcompany_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butfindcompany.Click
        Find.Show()
        Find.Query("select IDCompany, CompanyCode, CompanyNama, NoCompany from mastercompany a where getdate() between StartDate and EndDate", " ORDER BY a.idcompany desc", "FindCompanyUploadLab", 2)
    End Sub

    Private Sub butdownloadtransthorax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butdownloadtransthorax.Click
        Try
            If txcompanycode.Text = "" Then
                MsgBox("Pilih Company Terlebih Dahulu.", MsgBoxStyle.Exclamation, "Warning!")
                Exit Sub
            ElseIf txidloc.Text = "" Then
                MsgBox("Pilih Lokasi Terlebih Dahulu.", MsgBoxStyle.Exclamation, "Warning!")
                Exit Sub
            End If

            Dim Tbls As DataTable = New DataTable
            Dim Ttindakan As DataTable = New DataTable
            Dim statuscetak As String = ""
            Dim statuscetak2 As String = ""

            If cmbstatustransaksi.SelectedIndex = 1 Then
                statuscetak = " AND a.`status` <> 'CHECK' "
                statuscetak2 = " AND c.`status` <> 'CHECK' "
            ElseIf cmbstatustransaksi.SelectedIndex = 2 Then
                statuscetak = " AND a.`status` = 'CHECK' "
                statuscetak2 = " AND c.`status` = 'CHECK' "
            End If

            If rdOffline.Checked = True Then
                Tbls = ReadSQL("SELECT NoUrut, 'Foto thorax tak tampak kelainan' AS 'Hasil', '-' AS 'Cor', '-' AS 'Pulmo', '-' AS 'Sinus', '-' AS 'Skeletal', '-' AS 'StatusKesehatan' FROM TransaksiLab WHERE DetailPemeriksaan LIKE '%THORAX%' AND TransLabID IN (SELECT TransLabID FROM TransaksiLabBayar WHERE NoJenisBayar = '" & txcompanycode.Text & "-" & txkodecabang.Text & "' AND JenisBayar = 'TAGIHAN') AND (CONVERT(date, TglLab) BETWEEN '" & Format(dtprocess.Value, "MM-dd-yyyy") & "' AND '" & Format(dtprocessend.Value, "MM-dd-yyyy") & "')")
            ElseIf rdOnline.Checked = True Then
                Tbls = ReadThemysql("SELECT a.nourut, b.nama, b.sex, a.idlabinternet, a.idtempatlab, a.idpaket, c.nojenisbayar AS 'company'" & _
                                    " FROM transaksilab a" & _
                                    " LEFT JOIN masterpasien b ON a.idpasien = b.nomitra" & _
                                    " LEFT JOIN transaksilabbayar c ON a.idlabinternet = c.idlabinternet" & _
                                    " WHERE (DATE(a.tgllab) BETWEEN '" & Format(dtprocess.Value, "yyyy-MM-dd") & "' AND '" & Format(dtprocessend.Value, "yyyy-MM-dd") & "') AND a.idtempatlab = b.cabang AND a.idtempatlab = '" & txidloc.Text & "' " & statuscetak & " AND (c.NoJenisBayar = '" & txcompanycode.Text & "-" & txkodecabang.Text & "' AND c.JenisBayar = 'TAGIHAN')", DB_Poliklinik)

                Ttindakan = ReadThemysql("SELECT DISTINCT a.TindakanID,b.NoUrut,UPPER(a.NamaTindakan) AS 'NamaTindakan',UPPER(b.DetailKet) AS 'DetailKet' FROM transaksilabdetail a" & _
                                         " LEFT JOIN transaksilabresult b ON a.TransLabIDDetail = b.TransLabIDDetail AND a.TindakanID = b.TindakanID AND a.idlabinternet = b.idlabinternet" & _
                                         " LEFT JOIN masterjenistindakan m on m.JenisTindakan = a.JenisTindakan" & _
                                         " LEFT JOIN transaksilab c on c.idlabinternet = a.idlabinternet" & _
                                         " LEFT JOIN masterpasien d ON c.idpasien=d.nomitra" & _
                                         " WHERE (DATE(c.tgllab) BETWEEN '" & Format(dtprocess.Value, "yyyy-MM-dd") & "' AND '" & Format(dtprocessend.Value, "yyyy-MM-dd") & "') AND c.idtempatlab='" & txidloc.Text & "' " & statuscetak2 & " AND b.nourut IS NOT NULL" & _
                                         " AND c.idlabinternet IN (SELECT idlabinternet FROM transaksilabbayar WHERE NoJenisBayar = '" & txcompanycode.Text & "-" & txkodecabang.Text & "' AND JenisBayar = 'TAGIHAN')" & _
                                         " ORDER BY m.UrutanJenisID,a.Urutan,b.TindakanID,b.NoUrut,a.TransLabIDDetail,a.TindakanID,b.GroupID,b.DetailKet", DB_Poliklinik)
            End If

            If Tbls.Rows.Count <= 0 Then
                MsgBox("Tidak ada data yang ditarik.", MsgBoxStyle.Critical, "Warning")
                Exit Sub
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

            Dim Saran As String = ""
            Dim Kesimpulan As String = ""

            For Each TrowN As DataRow In TblsN.Rows
                For Each Thasil As DataRow In Tbls.Rows
                    If TrowN("idlabinternet") = Thasil("idlabinternet") Then
                        For j As Integer = 7 To Tbls.Columns.Count - 1 Step 1
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

            'Set Header
            For j As Integer = 7 To Tbls.Columns.Count - 1 Step 1
                Dim Tcol As DataColumn = Tbls.Columns(j)
                Dim Txid() As String = Tcol.ColumnName.ToString.Split("/")

                Dim Tstr As DataTable = ReadSQL("select TindakanID, DetailKet, GroupID, NoUrut from MasterLabDetail where TindakanID='" & Txid(0) & "' and NoUrut='" & Txid(1) & "' AND Deleted <> 1")
                Dim TrowLab As DataRow = Tstr.Rows(0)
                Dim Tlbl As String = TrowLab("DetailKet") & "#" & TrowLab("TindakanID") & "#" & TrowLab("NoUrut")
                For i As Integer = 7 To j - 1 Step 1
                    If Tbls.Columns(i).ColumnName = TrowLab("DetailKet") & "#" & TrowLab("TindakanID") & "#" & TrowLab("NoUrut") Then
                        Tlbl = Tlbl & " "
                    End If
                Next
                Tcol.ColumnName = Tlbl
            Next

            gridexcel.DataSource = Tbls

            ExportDataToExcel(gridexcel)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class