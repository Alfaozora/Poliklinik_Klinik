Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Drawing
Imports Newtonsoft.Json
Imports Newtonsoft
Imports System.Security.Cryptography
Imports System.Collections.Generic
Imports Newtonsoft.Json.Linq

Public Class FormUploadGaji
    '# Setting threading
    Dim thread As System.Threading.Thread

    '# Setting Excel Upload
    Dim conn As OleDbConnection
    Dim dtr As OleDbDataReader
    Dim dta As OleDbDataAdapter
    Dim cmd As OleDbCommand
    Dim dts As DataSet
    Dim excel As String
    Dim opFileDialog As New OpenFileDialog()

    '# Setting Private Variabel
    Private userAdmin As String = PoliKlinik.Lbluser.Text
    Private namaLokasiDictionary As New Dictionary(Of String, String)()
    Private idLokasiDictionary As New Dictionary(Of String, String)()
    Private dbLokasiDictionary As New Dictionary(Of String, String)()
    Private idBankDictionary As New Dictionary(Of String, String)()

    '# Set Connection
    Private DB_Keuangan2 As TLcon
    Private DB_Poliklinik As TLcon
    Private DB_Jurnal As TLcon

    Private Sub SetConnectionFromConfig()
        ' Set Parameter Server Online
        Dim serverOnline_IP As String = Utility.GetConfig("ServerOnline_IP")
        Dim serverOnline_UserID As String = Utility.GetConfig("ServerOnline_UserID")
        Dim serverOnline_Password As String = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerOnline_Password"), "albert")

        ' Set DB Keuangan 2 (mitramed_keu2019)
        DB_Keuangan2.Tip = serverOnline_IP
        DB_Keuangan2.Tid = serverOnline_UserID
        DB_Keuangan2.Tpass = serverOnline_Password
        DB_Keuangan2.Tdb = Utility.GetConfig("ServerOnlineKeuangan2_DB")

        ' Set DB Poliklinik
        DB_Poliklinik.Tip = serverOnline_IP
        DB_Poliklinik.Tid = serverOnline_UserID
        DB_Poliklinik.Tpass = serverOnline_Password
        DB_Poliklinik.Tdb = Utility.GetConfig("ServerOnlinePoli_DB")

        ' Set DB Jurnal
        DB_Jurnal.Tip = Utility.GetConfig("ServerJurnal_IP")
        DB_Jurnal.Tid = Utility.GetConfig("ServerJurnal_UserID")
        DB_Jurnal.Tpass = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerJurnal_Password"), "albert")
        DB_Jurnal.Tdb = Utility.GetConfig("ServerJurnal_DB")
    End Sub

    Private Class varJSON
        Public result As String
        Public rows() As JSON_result

        Public Class JSON_result
            Public Sales_Office As String
            Public Kode_Admin As String
            Public Komponen As String
            Public Nilai As Double
        End Class
    End Class

    Function CreateTableDownloadFormat() As DataTable
        Dim Thasil As New DataTable

        insertRowToTbls(Thasil, "Typstring", "Sales Office")
        insertRowToTbls(Thasil, "Typstring", "Bank")
        insertRowToTbls(Thasil, "Typstring", "Coa Bank")
        insertRowToTbls(Thasil, "Typstring", "Nominal")
        insertRowToTbls(Thasil, "Typstring", "Tgl Realisasi")

        Return Thasil
    End Function

    Private Sub PanelTop_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelTop.Paint
        Try
            e.Graphics.DrawString("Upload Gaji Karyawan", New Font("Segoe UI Semibold", 15, FontStyle.Bold), Brushes.White, New Point(45, 3))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FormUploadGaji_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Control.CheckForIllegalCrossThreadCalls = False
            Me.MdiParent = PoliKlinik
            Me.Dock = DockStyle.Fill

            setClear()

            ' Inisialisasi koneksi ke database MySQL
            SetConnectionFromConfig()

            '# Hide tab header button
            TabControl1.Appearance = TabAppearance.FlatButtons
            TabControl1.ItemSize = New Size(0, 1)
            TabControl1.SizeMode = TabSizeMode.Fixed
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub setClear()
        GridView1.Columns.Clear()

        cmbbulan.Items.Clear()
        cmbtahun.Items.Clear()
        loadcmbbulan()
        loadcmbyear()
        cmbbulan.SelectedIndex = -1
        cmbtahun.SelectedIndex = -1
        txPemberitahuan.Text = "-"
        txProcent.Text = "0 %"
        btnSimpan.Enabled = False
        btnDownload.Enabled = True
        btnUpload.Enabled = True
        btnClear.Enabled = True
        cmbbulan.Enabled = True
        cmbtahun.Enabled = True

        '# Reset Dictionary
        namaLokasiDictionary.Clear()
        idLokasiDictionary.Clear()
        dbLokasiDictionary.Clear()
        idBankDictionary.Clear()
    End Sub

    Private Sub loadcmbbulan()
        cmbbulan.Items.Add("Januari")
        cmbbulan.Items.Add("Februari")
        cmbbulan.Items.Add("Maret")
        cmbbulan.Items.Add("April")
        cmbbulan.Items.Add("Mei")
        cmbbulan.Items.Add("Juni")
        cmbbulan.Items.Add("Juli")
        cmbbulan.Items.Add("Agustus")
        cmbbulan.Items.Add("September")
        cmbbulan.Items.Add("Oktober")
        cmbbulan.Items.Add("November")
        cmbbulan.Items.Add("Desember")
        cmbbulan.SelectedIndex = 0
    End Sub

    Private Sub loadcmbyear()
        Dim vartahun As Integer = Date.Today.Year
        cmbtahun.Items.Add(vartahun)
        cmbtahun.Items.Add(vartahun - 1)
        cmbtahun.Items.Add(vartahun - 2)
        cmbtahun.Items.Add(vartahun - 3)
        cmbtahun.Items.Add(vartahun - 4)
        cmbtahun.SelectedIndex = 0
    End Sub

    Private Sub btnMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMenu1.Click, btnMenu2.Click, btnMenu3.Click
        Try
            Dim myButton = DirectCast(sender, Button)

            Select Case myButton.Name
                Case "btnMenu1"
                    TabControl1.SelectedTab = TabPage1
                Case "btnMenu2"
                    TabControl1.SelectedTab = TabPage2
                Case "btnMenu3"
                    TabControl1.SelectedTab = TabPage3
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        Try
            opFileDialog.Filter = "Excel Files 2003|*.xls|Excel Files|*.xlsx"
            opFileDialog.Title = "Select a Excel File"

            If opFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Dim fi As New FileInfo(opFileDialog.FileName)
                Dim FileName As String = opFileDialog.FileName

                excel = fi.FullName
                conn = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excel + ";Extended Properties=Excel 12.0;")
                dta = New OleDbDataAdapter("Select * From [Sheet1$]", conn)
                dts = New DataSet("NewTables")
                dta.Fill(dts)
                gridGaji.DataSource = dts.Tables(0)
                conn.Close()
            End If

            'butsavemultiple.Enabled = False
            btnSimpan.Enabled = True
        Catch ex As Exception
            conn.Close()
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub btnDownload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDownload.Click
        Try
            If CheckingDownload() = True Then
                Dim KeyEmpty As Boolean = False
                Dim bulan As String = Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(cmbbulan.Text, "Januari", "01"), "Februari", "02"), "Maret", "03"), "April", "04"), "Mei", "05"), "Juni", "06"), "Juli", "07"), "Agustus", "08"), "September", "09"), "Oktober", "10"), "November", "11"), "Desember", "12")
                Dim tahun As String = cmbtahun.Text
                Dim dateawal As DateTime = New DateTime(tahun, bulan, 1)
                Dim dateakhir As DateTime = New DateTime(tahun, bulan, DateTime.DaysInMonth(tahun, bulan))
                Dim Tdata As DataTable = New DataTable

                Tdata = CreateTableDownloadFormat()
                Tdata.Rows.Clear()

                Dim uri As String = "http://103.115.164.86/api/gaji.php?tglAwal='" & Format(dateawal, "yyyyMMdd") & "'&tglAkhir='" & Format(dateakhir, "yyyyMMdd") & "'&password=GAJICMH"

                Dim rawresp As String = "[" & GetDataAPI(uri) & "]"
                Dim varses() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of varJSON())(rawresp.Replace("Sales Office", "Sales_Office").Replace("Kode Admin", "Kode_Admin"))

                For Each oneVar As varJSON In varses
                    If oneVar IsNot Nothing Then
                        For index As Integer = 0 To oneVar.rows.Count - 1
                            If oneVar.rows(index).Komponen = "@SumGaji@" Then
                                Dim Tlastnew As DataRow = Tdata.NewRow
                                Tlastnew("Sales Office") = oneVar.rows(index).Sales_Office
                                Tlastnew("Bank") = oneVar.rows(index).Kode_Admin
                                Tlastnew("Coa Bank") = "-"
                                Tlastnew("Nominal") = oneVar.rows(index).Nilai
                                Tlastnew("Tgl Realisasi") = Format(DateAndTime.Now, "yyyyMMdd")
                                Tdata.Rows.Add(Tlastnew)
                            End If
                        Next
                    End If
                Next

                gridGaji.DataSource = Tdata

                ExportDataToExcel(gridGaji)

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Function CheckingDownload() As Boolean
        '# Cek Bulan & Tahun
        If cmbbulan.Text = "" Or cmbtahun.Text = "" Then
            MsgBox("Bulan & Tahun tidak boleh kosong.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        Return True
    End Function

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        setClear()
    End Sub

    Private Sub btnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSimpan.Click
        If checkingSave() = True Then
            thread = New System.Threading.Thread(AddressOf count)
            thread.Start()
        Else
            btnSimpan.Enabled = False
        End If
    End Sub

    Private Sub count()
        Try
            btnSimpan.Enabled = False
            btnDownload.Enabled = False
            btnUpload.Enabled = False
            btnClear.Enabled = False
            cmbbulan.Enabled = False
            cmbtahun.Enabled = False

            Dim bulan As String = Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(cmbbulan.Text, "Januari", "01"), "Februari", "02"), "Maret", "03"), "April", "04"), "Mei", "05"), "Juni", "06"), "Juli", "07"), "Agustus", "08"), "September", "09"), "Oktober", "10"), "November", "11"), "Desember", "12")
            Dim tahun As String = cmbtahun.Text
            Dim jenisOutput As String = ""
            Dim jenisOutputKeterangan As String = ""

            If RadioButtonPilihanGaji.Checked = True Then
                jenisOutput = "CoaGaji"
                jenisOutputKeterangan = "GAJI"
            ElseIf RadioButtonPilihanTHR.Checked = True Then
                jenisOutput = "CoaTHR"
                jenisOutputKeterangan = "THR"
            End If

            Dim outID As String = ReadThemysqlNIK("SELECT b.outid as outid FROM mastersetting a LEFT JOIN accmasterpengeluaran b ON a.value=b.coa WHERE a.name='" & jenisOutput & "';", DB_Keuangan2)
            Dim jenisPengajuan As String = "1"
            Dim userID As String = ReadThemysqlNIK("SELECT a.bridginguser FROM users a WHERE a.username = '" & userAdmin & "'", DB_Poliklinik)
            Dim userAutoWeb As String = ""
            Dim keterangan As String = ""
            Dim noFaktur As String = ""
            Dim nilaiUang As Double = 0
            Dim supplierID As String = ""
            Dim bankTujuan As String = ""
            Dim transTgl As DateTime = New DateTime(tahun, bulan, DateTime.DaysInMonth(tahun, bulan))
            Dim bebanTgl As DateTime = New DateTime(tahun, bulan, DateTime.DaysInMonth(tahun, bulan))
            Dim realisasiTgl As DateTime
            Dim procent As Integer = 0
            Dim persen As Integer = 0

            '# Set Variabel GL
            Dim bsa As String = ""
            Dim flag As String = ""
            Dim Nourut As String = ""
            Dim coaJenis As String = ReadThemysqlNIK("SELECT b.coa as outid FROM mastersetting a LEFT JOIN accmasterpengeluaran b ON a.value=b.coa WHERE a.name='" & jenisOutput & "';", DB_Keuangan2)
            Dim coaAccruedExpense As String = ReadThemysqlNIK("SELECT b.coa AS 'a' FROM accmasterpengeluaran a LEFT JOIN accmasterpengeluarankomponen b ON a.komponen=b.komponen WHERE a.coa = '" & coaJenis & "' LIMIT 1", DB_Keuangan2)
            Dim coaPrepaidExpense As String = ""

            '# Get from master setting
            Dim TempSetting As DataTable = ReadThemysql("SELECT a.name, a.value FROM mastersetting a WHERE a.name IN ('UserAutoWeb', 'SupplierUploadGaji', 'BankTujuanUploadGaji', 'CoaPrepaidExpense')", DB_Keuangan2)
            For Each TrowSetting As DataRow In TempSetting.Rows
                If TrowSetting("name") = "UserAutoWeb" Then
                    userAutoWeb = TrowSetting("value").ToString.Trim
                ElseIf TrowSetting("name") = "SupplierUploadGaji" Then
                    supplierID = TrowSetting("value").ToString.Trim
                ElseIf TrowSetting("name") = "BankTujuanUploadGaji" Then
                    bankTujuan = TrowSetting("value").ToString.Trim
                ElseIf TrowSetting("name") = "CoaPrepaidExpense" Then
                    coaPrepaidExpense = TrowSetting("value").ToString.Trim
                End If
            Next

            Dim Tbls As DataTable = gridGaji.DataSource

            For Each Trow As DataRow In Tbls.Rows
                '# Set Keterangan
                keterangan = jenisOutputKeterangan & " " & namaLokasiDictionary("" & Trow("Sales Office") & "") & " BULAN " & cmbbulan.Text & " REK. " & Trow("Bank")
                noFaktur = jenisOutputKeterangan & " " & cmbbulan.Text & " " & cmbtahun.Text
                realisasiTgl = DateTime.ParseExact(Trow("Tgl Realisasi"), "yyyyMMdd", Nothing)

                'Set DB
                DB_Jurnal.Tdb = dbLokasiDictionary("" & Trow("Sales Office") & "")

                'Set bsa
                bsa = ReadThemysqlNIK("SELECT a.bsa as a FROM bsa a WHERE a.bsaname='" & Trow("Sales Office").ToString.Trim & "'", DB_Jurnal)

                'Set Flag
                flag = Format(transTgl, "yy") & Format(transTgl, "MM") & "GAJ"
                Nourut = ReadThemysqlNIK("SELECT concat(lpad(RIGHT(a.flag,5)+1,5,0)) FROM acctranskas a WHERE a.flag LIKE '%" & flag & "%' ORDER BY a.flag DESC LIMIT 1", DB_Keuangan2)

                If IsDBNull(Nourut) = False And Nourut <> "" And Nourut <> "-" Then
                    flag = flag & Nourut.Trim
                Else
                    flag = flag & "00001"
                End If

                '# Insert Transaksi Baru ke Program GL
                If Format(transTgl, "MM") = Format(realisasiTgl, "MM") Then
                    'KAS
                    WriteThemysql("SELECT F_MakeKAS('" & flag & "', 'out', '', '" & Trow("Tgl Realisasi") & "', '" & Trow("Coa Bank").ToString.Trim & "', '" & coaJenis & "', 'IDR', 1, " & CDbl(Trow("Nominal")) & ", '" & keterangan.ToUpper & "', '1', '1', '', '" & keterangan.ToUpper & "', '" & flag & "', '', '" & bsa & "', 3, " & CDbl(Trow("Nominal")) & ", 'D')", DB_Jurnal)
                Else
                    If Format(transTgl, "yyyy-MM-dd") < Format(realisasiTgl, "yyyy-MM-dd") Then
                        If CheckThemysql("SELECT * FROM accmasterpengeluaran a WHERE a.statusumh IS TRUE AND a.coa IN ('" & coaJenis & "')", DB_Keuangan2) = True Then
                            'UMH
                            WriteThemysql("SELECT F_MakeUMH('" & flag & "', 'out', '', '" & Format(transTgl, "yyyy-MM-dd") & "', '" & coaAccruedExpense & "', '" & coaJenis & "', 'IDR', 1, " & CDbl(Trow("Nominal")) & ", '" & keterangan.ToUpper & "', '1', '1', '', '" & keterangan.ToUpper & "', '" & flag & "', '', '" & bsa & "', 1, " & CDbl(Trow("Nominal")) & ", 'D')", DB_Jurnal)
                        End If

                        'KAS
                        WriteThemysql("SELECT F_MakeKAS('" & flag & "', 'out', '', '" & Trow("Tgl Realisasi") & "', '" & Trow("Coa Bank").ToString.Trim & "', '" & coaAccruedExpense & "', 'IDR', 1, " & CDbl(Trow("Nominal")) & ", '" & keterangan.ToUpper & "', '1', '1', '', '" & keterangan.ToUpper & "', '" & flag & "', '', '" & bsa & "', 3, " & CDbl(Trow("Nominal")) & ", 'D')", DB_Jurnal)
                    ElseIf Format(transTgl, "yyyy-MM-dd") > Format(realisasiTgl, "yyyy-MM-dd") Then
                        If CheckThemysql("SELECT * FROM accmasterpengeluaran a WHERE a.statusumh IS TRUE AND a.coa IN ('" & coaJenis & "')", DB_Jurnal) = True Then
                            'UMH
                            WriteThemysql("SELECT F_MakeUMH('" & flag & "', 'out', '', '" & Format(transTgl, "yyyy-MM-dd") & "', '" & coaPrepaidExpense & "', '" & coaJenis & "', 'IDR', 1, " & CDbl(Trow("Nominal")) & ", '" & keterangan.ToUpper & "', '1', '1', '', '" & keterangan.ToUpper & "', '" & flag & "', '', '" & bsa & "', 1, " & CDbl(Trow("Nominal")) & ", 'D')", DB_Jurnal)
                        End If

                        'KAS
                        WriteThemysql("SELECT F_MakeKAS('" & flag & "', 'out', '', '" & Trow("Tgl Realisasi") & "', '" & Trow("Coa Bank").ToString.Trim & "', '" & coaPrepaidExpense & "', 'IDR', 1, " & CDbl(Trow("Nominal")) & ", '" & keterangan.ToUpper & "', '1', '1', '', '" & keterangan.ToUpper & "', '" & flag & "', '', '" & bsa & "', 3, " & CDbl(Trow("Nominal")) & ", 'D')", DB_Jurnal)
                    End If
                End If

                '# =================================================================

                '# Insert Transaksi Baru ke Program Keuangan Web
                WriteThemysql("INSERT INTO `acctranskas` (`outid`, `pengajuan`, `transtgl`, `createdby`, `createddate`, `accuserby`, `accuserdate`, `accuserstatus`, `acc1by`, `acc1date`, `acc1status`, `acc2by`, `acc2date`, `acc2status`, `acc3by`, `acc3date`, `acc3status`, `keterangan`, `bebantgl`, `nilaiuang`, `nomorfaktur`, `supplierid`, `loc`, `realisasi`, `realisasiby`, `realisasistatus`, `realisasidate`, `closeddate`, `bankid`, `bankiddest`, `flag`, `closed`) " & _
                              "VALUES ('" & outID & "', '1', '" & Format(transTgl, "yyyyMMdd") & "', '" & userID & "', NOW(), '" & userAutoWeb & "', NOW(), '1', '" & userAutoWeb & "', NOW(), '1', '" & userAutoWeb & "', NOW(), '1', '" & userAutoWeb & "', NOW(), '1', '" & keterangan.ToUpper & "', '" & Format(bebanTgl, "yyyyMMdd") & "', '" & CDbl(Trow("Nominal")) & "', '" & noFaktur.ToUpper & "', '" & supplierID & "', '" & idLokasiDictionary("" & Trow("Sales Office")) & "', '" & CDbl(Trow("Nominal")) & "', '" & userAutoWeb & "', '1', '" & Format(realisasiTgl, "yyyyMMdd") & "', NOW(), '" & idBankDictionary("" & Trow("Coa Bank") & "") & "', '" & bankTujuan & "', '" & flag & "', '1')", DB_Keuangan2)

                persen = persen + 1
                procent = persen * 100 / Tbls.Rows.Count
                txProcent.Text = procent & " %"
                txPemberitahuan.Text = "Sending data..."
                ProgressBar1.Value = procent
            Next

            txPemberitahuan.Text = "Success..."
            MsgBox("Berhasil Upload Data.", MsgBoxStyle.Information, "Success!")
            btnClear.Enabled = True
        Catch ex As Exception
            btnClear.Enabled = True

            MsgBox(ex.Message)
        End Try
    End Sub

    Function checkingSave() As Boolean
        Try
            Dim Tbls As DataTable = gridGaji.DataSource
            Tbls.AcceptChanges()

            '# Cek Bulan & Tahun
            If cmbbulan.Text = "" Or cmbtahun.Text = "" Then
                MsgBox("Bulan & Tahun tidak boleh kosong.", MsgBoxStyle.Exclamation, "Warning!")

                Return False
            End If

            '# Cek Jumlah Data
            If Tbls.Rows.Count > 0 Then
                'Skip
            Else
                MsgBox("Tidak ada data yang di upload.", MsgBoxStyle.Exclamation, "Warning!")

                Return False
            End If

            Dim Tloc As DataTable = New DataTable
            Dim TbankID As DataTable = New DataTable

            Dim kodeLokasi As String = ""
            Dim coaBank As String = ""
            Dim tempLokasi As String = "("
            Dim tempBank As String = "("

            For Each Trow As DataRow In Tbls.Rows
                tempLokasi = tempLokasi & "'" & Trow("Sales Office").ToString.Trim & "',"
                tempBank = tempBank & "'" & Trow("Coa Bank").ToString.Trim & "',"
            Next

            kodeLokasi = Strings.Left(tempLokasi, tempLokasi.Length - 1) & ")"
            coaBank = Strings.Left(tempBank, tempBank.Length - 1) & ")"

            Tloc = ReadThemysql("SELECT a.locationcode, a.locid, a.locationket, b.db_gl FROM masterlokasi a LEFT JOIN mastergruplokasi b ON a.locgroup = b.locgroupcode WHERE a.locationcode IN " & kodeLokasi & "", DB_Keuangan2)
            For Each Trowloc As DataRow In Tloc.Rows
                '# Masukkan id dan ket lokasi ke dictionary
                idLokasiDictionary("" & Trowloc("locationcode") & "") = Trowloc("locid")
                namaLokasiDictionary("" & Trowloc("locationcode") & "") = Trowloc("locationket")
                dbLokasiDictionary("" & Trowloc("locationcode") & "") = Trowloc("db_gl")
            Next

            TbankID = ReadThemysql("SELECT a.bankid, a.coa FROM accmasterbank a WHERE a.coa IN " & coaBank & "", DB_Keuangan2)
            For Each Trowbank As DataRow In TbankID.Rows
                '# Set Bank ID
                idBankDictionary("" & Trowbank("coa") & "") = Trowbank("bankid")
            Next

            '# Check COA
            For Each Trow As DataRow In Tbls.Rows
                If idBankDictionary.ContainsKey(Trow("Coa Bank").ToString.Trim) = False Then
                    MsgBox("COA " & Trow("Coa Bank").ToString.Trim & " tidak valid.", MsgBoxStyle.Exclamation, "Warning!")

                    Return False
                End If

                If namaLokasiDictionary.ContainsKey(Trow("Sales Office").ToString.Trim) = False Then
                    MsgBox("Kode Lokasi " & Trow("Sales Office").ToString.Trim & " tidak valid.", MsgBoxStyle.Exclamation, "Warning!")

                    Return False
                End If

                If dbLokasiDictionary.ContainsValue("-") = True Then
                    MsgBox("Database " & Trow("Sales Office").ToString.Trim & " tidak valid.", MsgBoxStyle.Exclamation, "Warning!")

                    Return False
                End If
            Next

            Return True
        Catch ex As Exception
            MsgBox(ex.Message)

            Return False
        End Try
    End Function

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class