Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Drawing
Imports Excel = Microsoft.Office.Interop.Excel
Imports Microsoft.Office
Imports Microsoft.Office.Interop

Public Class FormMasterKapitasi
    Private UserInput As String = PoliKlinik.Lbluser.Text
    Private kodeLokasi As String = ""

    Dim conn As OleDbConnection
    Dim dtr As OleDbDataReader
    Dim dta As OleDbDataAdapter
    Dim cmd As OleDbCommand
    Dim dts As DataSet
    Dim excel As String
    Dim opFileDialog As New OpenFileDialog()

    ' Set Connection
    Private DB_Poliklinik As TLcon
    Private Find_Poliklinik As Find.TLconnect

    Private Sub SetConnectionFromConfig()
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

    Private Sub SetClear()
        TextBoxKeteranganLokasi.ResetText()
        kodeLokasi = ""

        cmbbulan1.Items.Clear()
        cmbtahun.Items.Clear()
        loadcmbbulan()
        loadcmbbulan2()
        loadcmbyear()
        cmbbulan1.SelectedIndex = -1
        cmbbulan2.SelectedIndex = -1
        cmbtahun.SelectedIndex = -1
        butsavelab.Enabled = True
        rdbpjs.Checked = True
        rdklinik.Checked = True
        rdtidak.Checked = True

        'Set
        txharga2.ResetText()
        txharga1.ResetText()
    End Sub

    Private Sub loadcmbbulan()
        cmbbulan1.Items.Add("Januari")
        cmbbulan1.Items.Add("Februari")
        cmbbulan1.Items.Add("Maret")
        cmbbulan1.Items.Add("April")
        cmbbulan1.Items.Add("Mei")
        cmbbulan1.Items.Add("Juni")
        cmbbulan1.Items.Add("Juli")
        cmbbulan1.Items.Add("Agustus")
        cmbbulan1.Items.Add("September")
        cmbbulan1.Items.Add("Oktober")
        cmbbulan1.Items.Add("November")
        cmbbulan1.Items.Add("Desember")
        cmbbulan1.SelectedIndex = 0
    End Sub

    Private Sub loadcmbbulan2()
        cmbbulan2.Items.Add("Januari")
        cmbbulan2.Items.Add("Februari")
        cmbbulan2.Items.Add("Maret")
        cmbbulan2.Items.Add("April")
        cmbbulan2.Items.Add("Mei")
        cmbbulan2.Items.Add("Juni")
        cmbbulan2.Items.Add("Juli")
        cmbbulan2.Items.Add("Agustus")
        cmbbulan2.Items.Add("September")
        cmbbulan2.Items.Add("Oktober")
        cmbbulan2.Items.Add("November")
        cmbbulan2.Items.Add("Desember")
        cmbbulan2.SelectedIndex = 0
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

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        SetClear()

        ' Inisialisasi koneksi ke database MySQL
        SetConnectionFromConfig()
    End Sub

    Private Sub FormMasterKapitasi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        NewToolStripMenuItem.PerformClick()
    End Sub

    Function Checking() As Boolean
        'Cek Bulan & Tahun  
        If cmbbulan1.Text = "" Or cmbtahun.Text = "" Then
            MsgBox("Bulan & Tahun tidak boleh kosong.")
            Return False
        End If

        If rdbpjs.Checked = False And rdinhealth.Checked = False Then
            MsgBox("Pilih jenis kapitasi terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        If rdklinik.Checked = False And rdlab.Checked = False Then
            MsgBox("Pilih jenis lokasi terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        'inisialisasi
        Dim bulan As String = Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(cmbbulan1.Text, "Januari", "01"), "Februari", "02"), "Maret", "03"), "April", "04"), "Mei", "05"), "Juni", "06"), "Juli", "07"), "Agustus", "08"), "September", "09"), "Oktober", "10"), "November", "11"), "Desember", "12")
        Dim tahun As String = cmbtahun.Text
        Dim datekapitasi As DateTime = New DateTime(tahun, bulan, 1)

        Dim jeniskapitasi As String = ""
        Dim jenislokasi As String = ""

        If rdbpjs.Checked = True Then
            jeniskapitasi = rdbpjs.Text
        ElseIf rdinhealth.Checked = True Then
            jeniskapitasi = rdinhealth.Text
        End If

        If rdklinik.Checked = True Then
            jenislokasi = rdklinik.Text
        ElseIf rdlab.Checked = True Then
            jenislokasi = rdlab.Text
        End If

        If CheckThemysql("SELECT * FROM masterkapitasi a WHERE a.cabang = '" & kodeLokasi & "' AND a.jenislokasi = '" & jenislokasi & "' AND a.jeniskapitasi = '" & jeniskapitasi & "' AND a.bulan = '" & datekapitasi.Month & "' AND a.tahun = '" & datekapitasi.Year & "'", DB_Poliklinik) = True Then
            MsgBox("Master kapitasi di bulan " & cmbbulan1.Text & " tahun " & cmbtahun.Text & " sudah di input.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        If (txharga1.Text = "0" Or txharga1.Text = "") And (txharga2.Text = "0" Or txharga2.Text = "") Then
            MsgBox("Harga umum & gigi tidak boleh kosong.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        Return True
    End Function

    Private Sub butsavelab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butsavelab.Click
        If Checking() = True Then
            Dim bulan As String = Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(cmbbulan1.Text, "Januari", "01"), "Februari", "02"), "Maret", "03"), "April", "04"), "Mei", "05"), "Juni", "06"), "Juli", "07"), "Agustus", "08"), "September", "09"), "Oktober", "10"), "November", "11"), "Desember", "12")
            Dim tahun As String = cmbtahun.Text
            Dim datekapitasi As DateTime = New DateTime(tahun, bulan, 1)

            Dim jeniskapitasi As String = ""
            Dim jenislokasi As String = ""

            If rdklinik.Checked = True Then
                jenislokasi = rdklinik.Text
            ElseIf rdlab.Checked = True Then
                jenislokasi = rdlab.Text
            End If

            'Insert Log
            If rdbpjs.Checked = True Then
                jeniskapitasi = rdbpjs.Text

                WriteThemysql("insert into masterkapitasi (jenislokasi, jeniskapitasi, cabang, tahun, bulan, hargaumum, hargagigi, createdate, createby) " & _
                              "values('" & jenislokasi & "', '" & jeniskapitasi & "', '" & kodeLokasi & "', '" & datekapitasi.Year & "', " & datekapitasi.Month & ", '" & CDbl(txharga1.Text) & "', '" & CDbl(txharga2.Text) & "', NOW(), '" & UserInput & "')", DB_Poliklinik)
            ElseIf rdinhealth.Checked = True Then
                jeniskapitasi = rdinhealth.Text

                WriteThemysql("insert into masterkapitasi (jenislokasi, jeniskapitasi, cabang, tahun, bulan, hargacob, harganoncob, createdate, createby) " & _
                              "values('" & jenislokasi & "', '" & jeniskapitasi & "', '" & kodeLokasi & "', '" & datekapitasi.Year & "', " & datekapitasi.Month & ", '" & CDbl(txharga1.Text) & "', '" & CDbl(txharga2.Text) & "', NOW(), '" & UserInput & "')", DB_Poliklinik)
            End If

            MsgBox("Berhasil menyimpan data.", MsgBoxStyle.Information, "Success!")
        End If
    End Sub

    Private Sub txjumlahpasien_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub DownloadFormatUploadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DownloadFormatUploadToolStripMenuItem.Click
        Try
            Dim Tbls As DataTable = New DataTable
            Tbls = ReadThemysql("SELECT a.kodecabang, a.kodeket, '0' AS 'hargaumum', '0' AS 'hargagigi' FROM mastercodebarcode a ORDER BY ID ASC", DB_Poliklinik)

            gridexcel.DataSource = Tbls
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
                    gridexcel.ExportToExcel(saveFileDialog1.FileName.ToString)
                    MsgBox("Berhasil menyimpan file excel " & saveFileDialog1.FileName.ToString, MsgBoxStyle.Information, "Success!")
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub rdya_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdya.CheckedChanged
        If rdya.Checked = True Then
            butsavelab.Enabled = False
            butsavemultiple.Enabled = True

            lblsampai.Visible = True
            cmbbulan2.Visible = True
        Else
            butsavelab.Enabled = True
            butsavemultiple.Enabled = False

            lblsampai.Visible = False
            cmbbulan2.Visible = False
        End If
    End Sub

    Private Sub rdtidak_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdtidak.CheckedChanged
        If rdya.Checked = True Then
            butsavelab.Enabled = False
            butsavemultiple.Enabled = True

            lblsampai.Visible = True
            cmbbulan2.Visible = True
        Else
            butsavelab.Enabled = True
            butsavemultiple.Enabled = False

            lblsampai.Visible = False
            cmbbulan2.Visible = False
        End If
    End Sub

    Private Sub butsavemultiple_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butsavemultiple.Click
        If CheckingMultiple() = True Then
            Dim bulan1 As String = Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(cmbbulan1.Text, "Januari", "01"), "Februari", "02"), "Maret", "03"), "April", "04"), "Mei", "05"), "Juni", "06"), "Juli", "07"), "Agustus", "08"), "September", "09"), "Oktober", "10"), "November", "11"), "Desember", "12")
            Dim bulan2 As String = Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(cmbbulan2.Text, "Januari", "01"), "Februari", "02"), "Maret", "03"), "April", "04"), "Mei", "05"), "Juni", "06"), "Juli", "07"), "Agustus", "08"), "September", "09"), "Oktober", "10"), "November", "11"), "Desember", "12")
            Dim tahun As String = cmbtahun.Text
            Dim datekapitasi1 As DateTime = New DateTime(tahun, bulan1, 1)
            Dim datekapitasi2 As DateTime = New DateTime(tahun, bulan2, 1)

            If cmbbulan1.SelectedIndex > cmbbulan2.SelectedIndex Then
                datekapitasi2 = DateAdd(DateInterval.Year, +1, datekapitasi2.Date)
            End If

            Dim jeniskapitasi As String = ""
            Dim jenislokasi As String = ""

            If rdbpjs.Checked = True Then
                jeniskapitasi = rdbpjs.Text
            ElseIf rdinhealth.Checked = True Then
                jeniskapitasi = rdinhealth.Text
            End If

            If rdklinik.Checked = True Then
                jenislokasi = rdklinik.Text
            ElseIf rdlab.Checked = True Then
                jenislokasi = rdlab.Text
            End If

            Dim Tbls As DataTable = gridkapitasi.DataSource
            For Each Trow As DataRow In Tbls.Rows
                Dim TempDate As Date = datekapitasi1
                Do Until datekapitasi2 < TempDate
                    'MsgBox(TempDate)

                    'Insert Log
                    If rdbpjs.Checked = True Then
                        'Insert Log
                        WriteThemysql("insert into masterkapitasi (jenislokasi, jeniskapitasi, cabang, tahun, bulan, hargaumum, hargagigi, createdate, createby) " & _
                                      "values('" & jenislokasi & "', '" & jeniskapitasi & "', '" & Trow("kodecabang").ToString & "', '" & TempDate.Year & "', " & TempDate.Month & ", '" & CDbl(Trow("hargaumum")) & "', '" & CDbl(Trow("hargagigi")) & "', NOW(), '" & UserInput & "')", DB_Poliklinik)
                    ElseIf rdinhealth.Checked = True Then
                        'Insert Log
                        WriteThemysql("insert into masterkapitasi (jenislokasi, jeniskapitasi, cabang, tahun, bulan, hargacob, harganoncob, createdate, createby) " & _
                                      "values('" & jenislokasi & "', '" & jeniskapitasi & "', '" & Trow("kodecabang").ToString & "', '" & TempDate.Year & "', " & TempDate.Month & ", '" & CDbl(Trow("hargaumum")) & "', '" & CDbl(Trow("hargagigi")) & "', NOW(), '" & UserInput & "')", DB_Poliklinik)
                    End If

                    TempDate = DateAdd(DateInterval.Month, +1, TempDate.Date)
                Loop
            Next

            MsgBox("Berhasil menyimpan data.", MsgBoxStyle.Information, "Success!")
        End If
    End Sub

    Function CheckingMultiple() As Boolean
        'Cek Bulan & Tahun  
        If cmbbulan1.Text = "" Or cmbbulan2.Text = "" Or cmbtahun.Text = "" Then
            MsgBox("Bulan & Tahun tidak boleh kosong.")
            Return False
        End If

        If rdbpjs.Checked = False And rdinhealth.Checked = False Then
            MsgBox("Pilih jenis kapitasi terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        If rdklinik.Checked = False And rdlab.Checked = False Then
            MsgBox("Pilih jenis lokasi terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        Dim Tbls As DataTable = gridkapitasi.DataSource

        If Tbls Is Nothing = True Then
            MsgBox("Upload data terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        If Tbls.Rows.Count > 0 Then
            Dim bulan1 As String = Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(cmbbulan1.Text, "Januari", "01"), "Februari", "02"), "Maret", "03"), "April", "04"), "Mei", "05"), "Juni", "06"), "Juli", "07"), "Agustus", "08"), "September", "09"), "Oktober", "10"), "November", "11"), "Desember", "12")
            Dim bulan2 As String = Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(cmbbulan2.Text, "Januari", "01"), "Februari", "02"), "Maret", "03"), "April", "04"), "Mei", "05"), "Juni", "06"), "Juli", "07"), "Agustus", "08"), "September", "09"), "Oktober", "10"), "November", "11"), "Desember", "12")
            Dim tahun As String = cmbtahun.Text
            Dim datekapitasi1 As DateTime = New DateTime(tahun, bulan1, 1)
            Dim datekapitasi2 As DateTime = New DateTime(tahun, bulan2, 1)

            If cmbbulan1.SelectedIndex > cmbbulan2.SelectedIndex Then
                datekapitasi2 = DateAdd(DateInterval.Year, +1, datekapitasi2.Date)
            End If

            Dim jeniskapitasi As String = ""
            Dim jenislokasi As String = ""

            If rdbpjs.Checked = True Then
                jeniskapitasi = rdbpjs.Text
            ElseIf rdinhealth.Checked = True Then
                jeniskapitasi = rdinhealth.Text
            End If

            If rdklinik.Checked = True Then
                jenislokasi = rdklinik.Text
            ElseIf rdlab.Checked = True Then
                jenislokasi = rdlab.Text
            End If

            For Each Trow As DataRow In Tbls.Rows
                If IsDBNull(Trow("kodecabang")) = True Or Trow("kodecabang").ToString.Trim = "-" Then
                    MsgBox("Kode cabang tidak boleh ada yang kosong.", MsgBoxStyle.Exclamation, "Warning!")
                    Return False
                End If

                If (IsDBNull(Trow("hargaumum")) = True Or Trow("hargaumum").ToString.Trim = "-" Or Trow("hargaumum").ToString.Trim = "0") And (IsDBNull(Trow("hargagigi")) = True Or Trow("hargagigi").ToString.Trim = "-" Or Trow("hargagigi").ToString.Trim = "0") Then
                    MsgBox("Harga umum & gigi tidak boleh kosong keduanya.", MsgBoxStyle.Exclamation, "Warning!")
                    Return False
                End If

                Dim TempDate As Date = datekapitasi1
                Do Until datekapitasi2 < TempDate
                    If CheckThemysql("SELECT * FROM masterkapitasi a WHERE a.cabang = '" & Trow("kodecabang") & "' AND a.jenislokasi = '" & jenislokasi & "' AND a.jeniskapitasi = '" & jeniskapitasi & "' AND a.bulan = '" & TempDate.Month & "' AND a.tahun = '" & TempDate.Year & "'", DB_Poliklinik) = True Then
                        MsgBox("Master kapitasi di bulan " & TempDate.Month & " tahun " & TempDate.Year & " sudah pernah di input.", MsgBoxStyle.Exclamation, "Warning!")
                        Return False
                    End If

                    TempDate = DateAdd(DateInterval.Month, +1, TempDate.Date)
                Loop
            Next
        End If

        Return True
    End Function

    Private Sub UploadDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UploadDataToolStripMenuItem.Click
        Try
            opFileDialog.Filter = "Excel Files 2003|*.xls|Excel Files|*.xlsx"
            opFileDialog.Title = "Select a Excel File"

            If opFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Dim fi As New FileInfo(opFileDialog.FileName)
                Dim FileName As String = opFileDialog.FileName

                Excel = fi.FullName
                conn = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Excel + ";Extended Properties=Excel 12.0;")
                dta = New OleDbDataAdapter("Select * From [Sheet1$]", conn)
                dts = New DataSet("NewTables")
                dta.Fill(dts)
                gridkapitasi.DataSource = dts.Tables(0)
                conn.Close()
            End If
        Catch ex As Exception
            conn.Close()
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ButtonFindCabang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFindCabang.Click
        Find.Show()
        Find.QueryTheMysql("SELECT a.id AS 'ID', a.kodecabang AS 'Kode Lokasi', a.kodeket AS 'Keterangan Lokasi' FROM mastercodebarcode a ORDER BY ID ASC", " ", "FindCabangMasterKapitasi", 0, Find_Poliklinik)
    End Sub

    Public Sub LoadDataCompany(ByRef Trow As DataRowView)
        TextBoxKeteranganLokasi.Text = Trow("Keterangan Lokasi").ToString
        kodeLokasi = Trow("Kode Lokasi").ToString
    End Sub
End Class