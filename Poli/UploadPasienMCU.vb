Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Drawing
Imports Newtonsoft.Json.Linq

Public Class UploadPasienMCU

    Dim thread As System.Threading.Thread
    Dim conn As OleDbConnection
    Dim dtr As OleDbDataReader
    Dim dta As OleDbDataAdapter
    Dim cmd As OleDbCommand
    Dim dts As DataSet
    Dim excel As String
    Dim opFileDialog As New OpenFileDialog()
    Private userUploadMCU As String = PoliKlinik.Lbluser.Text

    Function CreateTable() As DataTable
        Dim Thasil As New DataTable

        insertRowToTbls(Thasil, "Typstring", "Nama")
        insertRowToTbls(Thasil, "Typstring", "Alamat")
        insertRowToTbls(Thasil, "typdate", "TglLahir")
        insertRowToTbls(Thasil, "Typstring", "Sex")
        insertRowToTbls(Thasil, "Typstring", "Company")
        insertRowToTbls(Thasil, "typdate", "TglTrans")
        insertRowToTbls(Thasil, "Typstring", "NoPaket")
        insertRowToTbls(Thasil, "Typstring", "PTNIK")
        insertRowToTbls(Thasil, "Typstring", "NIP")
        insertRowToTbls(Thasil, "Typstring", "Email")
        insertRowToTbls(Thasil, "Typstring", "Whatsapp")
        insertRowToTbls(Thasil, "Typstring", "Kirim")
        insertRowToTbls(Thasil, "Typstring", "AmbilSendiri")

        For Each Tcol As DataColumn In Thasil.Columns
            Tcol.ReadOnly = True
        Next

        Return Thasil
    End Function

    Private Sub ButtonUploadFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonUploadFile.Click
        Try
            opFileDialog.Filter = "Excel Files 2003|*.xls|Excel Files|*.xlsx"
            opFileDialog.Title = "Select a Excel File"

            If opFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Dim fi As New FileInfo(opFileDialog.FileName)
                Dim FileName As String = opFileDialog.FileName

                excel = fi.FullName
                conn = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excel + ";Extended Properties=Excel 12.0;")
                dta = New OleDbDataAdapter("SELECT * FROM [Sheet1$]", conn)
                dts = New DataSet("NewTables")
                dta.Fill(dts)
                GridControlDataPasien.DataSource = dts.Tables(0)
                conn.Close()
            End If

            ButtonSimpanData.Enabled = False
            ButtonValidasiData.Enabled = True
        Catch ex As Exception
            conn.Close()
            MsgBox(ex.ToString)
        End Try
    End Sub

    Function DoubleCheck(ByRef Temp As DataTable) As Boolean
        For Each Trow As DataRow In Temp.Rows
            If Trow("Nama").ToString.Contains("'") = True Or Trow("Nama").ToString.Contains(",") = True Then
                MsgBox("Nama tidak boleh ada tanda petik atau koma. Pada atas nama : " & Trow("Nama").ToString & ".", MsgBoxStyle.Exclamation, "Warning!")
                Return False
            End If

            If Trow("Sex").ToString.Trim <> "L" And Trow("Sex").ToString.Trim <> "P" Then
                MsgBox("Jenis Kelamin ada yang tidak sesuai. Pada atas nama : " & Trow("Nama").ToString & ".", MsgBoxStyle.Exclamation, "Warning!")
                Return False
            End If

            If Trow("Alamat").ToString.Contains("'") = True Or Trow("Alamat").ToString.Contains(",") = True Then
                MsgBox("Alamat tidak boleh ada tanda petik atau koma. Pada atas nama : " & Trow("Nama").ToString & ".", MsgBoxStyle.Exclamation, "Warning!")
                Return False
            End If

            'If CheckSQL("SELECT * FROM MasterPasien WHERE Nama = '" & Trow("Nama").ToString & "' AND TglLahir = '" & Format(Trow("TglLahir"), "MM/dd/yyyy") & "' AND NoNIK = '" & Trow("PTNIK").ToString & "'") = True Then
            '    If MsgBox("Telah ada karyawan sama. Cek Pasien atas nama " & Trow("Nama").ToString & ". Apakah tetap dilanjutkan ?", MsgBoxStyle.YesNo, "Verifikasi Pasien.") = MsgBoxResult.No Then
            '        Return False
            '    End If
            'End If
        Next

        Return True
    End Function

    Private Sub SetGrid()
        GridControlDataPasien.DataSource = CreateTable()

        ProgressBar1.Value = 0
        ProgressBar1.Visible = False
        ButtonSimpanData.Enabled = False
    End Sub

    Private Sub UploadPasienMCU_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        Me.MdiParent = PoliKlinik
        Me.BringToFront()
        SetGrid()
        Dim y As Integer = Screen.PrimaryScreen.Bounds.Height * 0.025
        Dim x As Integer = Screen.PrimaryScreen.Bounds.Width * 0.025
        Me.Location = New Point(x, y)
        Me.Height = Screen.PrimaryScreen.Bounds.Height * 0.8
        Me.Width = Screen.PrimaryScreen.Bounds.Width * 0.95
    End Sub

    Private Sub ButtonValidasiData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonValidasiData.Click
        thread = New System.Threading.Thread(AddressOf ValidasiUploadData)
        thread.Start()
    End Sub

    Private Sub ValidasiUploadData()
        Dim tblUpload As DataTable = GridControlDataPasien.DataSource
        'Dim saved As Integer = 1
        Dim statusValidasi As Boolean = True

        Try
            If tblUpload.Rows.Count > 0 Then
                ButtonValidasiData.Enabled = False
                ProgressBar1.Visible = True
                Dim persen As Integer = 0
                Dim jumlah As Integer = 0

                For Each Trow As DataRow In tblUpload.Rows
                    persen = persen + 1

                    'Validasi Data
                    If IsDBNull(Trow("Email")) = True Then Trow("Email") = "-"
                    If IsDBNull(Trow("Whatsapp")) = True Then Trow("Whatsapp") = "-"
                    If IsDBNull(Trow("PTNIK")) = True Then Trow("PTNIK") = "-"
                    If IsDBNull(Trow("NIP")) = True Then Trow("NIP") = "-"
                    If IsDBNull(Trow("Alamat")) = True Then Trow("Alamat") = "-"
                    If IsDBNull(Trow("Kirim")) = True Then Trow("Kirim") = "-"
                    If IsDBNull(Trow("AmbilSendiri")) = True Then Trow("AmbilSendiri") = "-"

                    'Cek NIK
                    If Trow("PTNIK").ToString.Trim <> "-" And Trow("PTNIK").ToString.Length <> 16 Then
                        MsgBox("NIK harus terdiri 16 digit atau isi - jika tidak ada. (Atas nama : " & Trow("Nama") & ")", MsgBoxStyle.Exclamation, "Warning!")
                        statusValidasi = False
                        Exit For
                    End If

                    Dim TempNIK As String = Trow("PTNIK").ToString.Trim
                    Dim numbericNIK As Boolean = False

                    If TempNIK <> "-" Then
                        For Each str As Char In TempNIK
                            If IsNumeric(str) Then
                                numbericNIK = True
                            Else
                                numbericNIK = False
                                Exit For
                            End If
                        Next
                    Else
                        numbericNIK = True
                    End If

                    If numbericNIK = False Then
                        MsgBox("NIK hanya boleh berupa angka. (Atas nama : " & Trow("Nama") & ")", MsgBoxStyle.Exclamation, "Warning!")
                        statusValidasi = False
                        Exit For
                    End If

                    'Cek Paket
                    If CheckSQL("SELECT * FROM MasterLabPaket WHERE PaketID = '" & Trow("NoPaket").ToString.Trim & "' AND PaketEnd > GETDATE()") = False Then
                        MsgBox("No. Paket Tidak Terdaftar di Sistem. (Atas nama : " & Trow("Nama") & ")", MsgBoxStyle.Exclamation, "Warning!")
                        statusValidasi = False
                        Exit For
                    End If

                    'Cek Ambil Sendiri
                    If Trow("AmbilSendiri").ToString = "Ya" Or Trow("AmbilSendiri").ToString = "True" Then
                        Trow("AmbilSendiri") = True
                    ElseIf IsDBNull(Trow("AmbilSendiri")) = True Or Trow("AmbilSendiri").ToString = "Tidak" Or Trow("AmbilSendiri").ToString = "-" Or Trow("AmbilSendiri").ToString = "False" Then
                        Trow("AmbilSendiri") = False
                    Else
                        MsgBox("Pilihan Ambil Sendiri hanya Ya/Tidak. (Atas nama : " & Trow("Nama") & ")", MsgBoxStyle.Exclamation, "Warning!")
                        statusValidasi = False
                        Exit For
                    End If

                    'Cek Email
                    If Trow("Email").ToString.Trim <> "" And Trow("Email").ToString.Trim <> "-" Then
                        If validateEmail(Trow("Email").ToString) = False Then
                            MsgBox("Perhatikan penulisan email dengan benar (Atas nama : " & Trow("Nama") & ").", MsgBoxStyle.Exclamation, "Warning!")
                            statusValidasi = False
                            Exit For
                        End If
                    End If

                    'Cek No Whatsapp
                    If Trow("Whatsapp").ToString.Trim <> "" And Trow("Whatsapp").ToString.Trim <> "-" Then
                        If validateNoWhatsapp(Trow("Whatsapp").ToString) = False Then
                            statusValidasi = False
                            Exit For
                        End If
                    End If

                    'Cek Master Company
                    Dim Tcompany As DataTable = ReadSQL("SELECT * FROM mastercompany where nocompany='" & Trow("Company").ToString & "'")
                    If Tcompany.Rows.Count > 0 Then
                        Dim Trowcompany As DataRow = Tcompany.Rows(0)
                        If Trowcompany("HardcopyPerusahaan") = True And Trowcompany("TerimaHasilKaryawan") = True Then
                            If Trowcompany("AlamatPerusahaan") = True Then
                                Trow("Kirim") = Trowcompany("CompanyNama")
                            End If
                        ElseIf Trowcompany("HardcopyPerusahaan") = False And Trowcompany("TerimaHasilKaryawan") = True Then
                            'SKIP
                        ElseIf Trowcompany("HardcopyPerusahaan") = True And Trowcompany("TerimaHasilKaryawan") = False Then
                            'Softcopy
                            If Trowcompany("Whatsapp_Auto") = True Then
                                Trow("Whatsapp") = Trowcompany("No_Handphone")
                            ElseIf Trowcompany("Email_Auto") = True Then
                                Trow("Email") = Trowcompany("Email_Perusahaan")
                            End If
                            'Hardcopy
                            If Trowcompany("AlamatPerusahaan") = True Then
                                Trow("Kirim") = Trowcompany("CompanyNama")
                            End If
                        ElseIf Trowcompany("HardcopyPerusahaan") = False And Trowcompany("TerimaHasilKaryawan") = False Then
                            'Softcopy
                            If Trowcompany("Whatsapp_Auto") = True Then
                                Trow("Whatsapp") = Trowcompany("No_Handphone")
                            ElseIf Trowcompany("Email_Auto") = True Then
                                Trow("Email") = Trowcompany("Email_Perusahaan")
                            End If
                            'Hardcopy
                            Trow("Kirim") = "-"
                            Trow("AmbilSendiri") = False
                        End If
                    Else
                        MsgBox("Cek Kode Company. (Atas nama : " & Trow("Nama") & ")", MsgBoxStyle.Exclamation, "Warning!")
                        statusValidasi = False
                        Exit For
                    End If

                    'Softcopy pilih salah satu
                    If Trow("Email").ToString.Trim <> "" And Trow("Email").ToString.Trim <> "-" And Trow("Whatsapp").ToString.Trim <> "" And Trow("Whatsapp").ToString.Trim <> "-" Then
                        MsgBox("Email & Whatsapp harus dipilih salah satu, tidak bisa keduanya. (Atas nama : " & Trow("Nama") & ")", MsgBoxStyle.Exclamation, "Warning!")
                        statusValidasi = False
                        Exit For
                    End If

                    'Hardcopy pilih salah satu
                    If Trow("AmbilSendiri") <> False And Trow("Kirim").ToString.Trim <> "" And Trow("Kirim").ToString.Trim <> "-" Then
                        MsgBox("Kirim & Ambil Sendiri harus dipilih salah satu, tidak bisa keduanya. (Atas nama : " & Trow("Nama") & ")", MsgBoxStyle.Exclamation, "Warning!")
                        statusValidasi = False
                        Exit For
                    End If

                    'Harus pilih
                    If Trow("Email").ToString.Trim = "-" And Trow("Whatsapp").ToString.Trim = "-" And Trow("Kirim").ToString.Trim = "-" And Trow("AmbilSendiri") = False Then
                        MsgBox("Harus memilih antara Whatsapp/Email & Kirim/Ambil Sendiri. (Atas nama : " & Trow("Nama") & ")", MsgBoxStyle.Exclamation, "Warning!")
                        statusValidasi = False
                        Exit For
                    End If

                    Dim procent As Integer = persen * 100 / tblUpload.Rows.Count
                    ProgressBar1.Value = procent
                Next

                If statusValidasi = True Then
                    If DoubleCheck(tblUpload) = False Then statusValidasi = False
                End If
            Else
                MsgBox("Tidak ada data yang di Upload.", MsgBoxStyle.Exclamation, "Warning!")
                statusValidasi = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

        If statusValidasi = False Then
            ButtonSimpanData.Enabled = False
            MsgBox("Data Gagal Upload.", MsgBoxStyle.Critical, "Failed")
        Else
            ButtonSimpanData.Enabled = True
            MsgBox(tblUpload.Rows.Count & " data berhasil divalidasi. Klik tombol simpan data untuk melanjutkan.", MsgBoxStyle.Information, "Validasi Berhasil!")
        End If

        ProgressBar1.Visible = False
    End Sub

    Private Sub ButtonDownloadFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDownloadFile.Click
        Try
            Dim saveFileDialog1 As New SaveFileDialog
            saveFileDialog1.Filter = "Excel File|*.xlsx"
            saveFileDialog1.Title = "Save an Excel File"
            saveFileDialog1.ShowDialog()
            If saveFileDialog1.CheckPathExists = False Then
                MsgBox("Path tidak ada. Check kembali")
            Else
                If saveFileDialog1.CheckFileExists = True Then
                    MsgBox("Telah ada data dengan nama tersebut. Rubah nama save")
                Else
                    Dim varData As String = saveFileDialog1.FileName.ToString
                    varData = Strings.Replace(varData, "\", "/")
                    Dim appPath As String = Application.StartupPath()

                    My.Computer.Network.DownloadFile("" & appPath & "/FileDownload/Contoh_Format_Data_Upload.xlsx", "" & varData & "")
                    MsgBox("File Saved in " + "" & varData & "")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ButtonSimpanData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSimpanData.Click
        thread = New System.Threading.Thread(AddressOf SaveMultiple)
        thread.Start()
    End Sub

    Private Sub SendToApiInbodyFromMCU(ByVal noRM As String, _
                                   ByVal nama As String, _
                                   ByVal genderInbody As String, _
                                   ByVal tglLahirStr As String, _
                                   ByVal umur As Integer, _
                                   ByVal tinggiUserInbody As String, _
                                   ByVal orderDateStr As String, _
                                   ByVal kodeServer As String, _
                                   ByVal kodeCabang As String)
        Try
            'MsgBox("Mulai proses kirim ke API InBody", MsgBoxStyle.Information, "Debug Step 1")

            ' =========================
            ' SET PARAMETER
            ' =========================
            Dim USER_ID As String = noRM
            Dim USER_NAME As String = UCase(nama)
            Dim USER_GENDER As String = genderInbody
            Dim USER_BIRTHDAY As String = tglLahirStr
            Dim USER_AGE As Integer = umur
            Dim ORDER_DATE As String = orderDateStr
            Dim SERVER As String = kodeServer
            Dim CABANG As String = kodeCabang

            'MsgBox("Data Parameter:" & vbCrLf & _
            '       "USER_ID: " & USER_ID & vbCrLf & _
            '       "USER_NAME: " & USER_NAME & vbCrLf & _
            '       "USER_GENDER: " & USER_GENDER & vbCrLf & _
            '       "USER_BIRTHDAY: " & USER_BIRTHDAY & vbCrLf & _
            '       "USER_AGE: " & USER_AGE & vbCrLf & _
            '       "USER_HEIGHT: " & tinggiUserInbody & vbCrLf & _
            '       "ORDER_DATE: " & ORDER_DATE & vbCrLf & _
            '       "SERVER: " & SERVER & vbCrLf & _
            '       "CABANG: " & CABANG, _
            '       MsgBoxStyle.Information, "Debug Step 2")

            ' =========================
            ' VALIDASI USER_HEIGHT
            ' =========================
            Dim USER_HEIGHT_JSON As String
            If tinggiUserInbody Is Nothing OrElse Trim(tinggiUserInbody) = "" Then
                USER_HEIGHT_JSON = """" & """"
            Else
                USER_HEIGHT_JSON = Trim(tinggiUserInbody)
            End If

            'MsgBox("Nilai USER_HEIGHT_JSON: " & USER_HEIGHT_JSON, _
            '       MsgBoxStyle.Information, "Debug Step 3")

            ' =========================
            ' FORMAT JSON
            ' =========================
            Dim json As String = _
                "{" & _
                """USER_ID"":""" & USER_ID & """," & _
                """USER_NAME"":""" & USER_NAME & """," & _
                """USER_GENDER"":""" & USER_GENDER & """," & _
                """USER_BIRTHDAY"":""" & USER_BIRTHDAY & """," & _
                """USER_AGE"":" & USER_AGE & "," & _
                """USER_HEIGHT"":" & USER_HEIGHT_JSON & "," & _
                """ORDER_DATE"":""" & ORDER_DATE & """," & _
                """SERVER"":""" & SERVER & """," & _
                """CABANG"":""" & CABANG & """" & _
                "}"

            'MsgBox("JSON Request:" & vbCrLf & json, _
            '       MsgBoxStyle.Information, "Debug Step 4")

            ' =========================
            ' AMBIL URL API
            ' =========================
            Dim baseUrl As String = ReadSQLNIK( _
                "SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")

            If Trim(baseUrl) = "" Then
                MsgBox("Base URL API tidak ditemukan di MsConfig!", _
                       MsgBoxStyle.Critical, "Debug Error")
                Exit Sub
            End If

            Dim urlWebService As String = baseUrl & "api/lumiera-luzelle/inbody/create"

            'MsgBox("URL Web Service:" & vbCrLf & urlWebService, _
            '       MsgBoxStyle.Information, "Debug Step 5")

            ' =========================
            ' KIRIM KE API
            ' =========================
            Dim response As String = InsertDataAPIRM(json, urlWebService)

            If Trim(response) = "" Then
                MsgBox("Response API kosong!", _
                       MsgBoxStyle.Critical, "Debug Error")
                Exit Sub
            End If

            'MsgBox("Response API:" & vbCrLf & response, _
            '       MsgBoxStyle.Information, "Debug Step 6")

            ' =========================
            ' PARSE JSON RESPONSE
            ' =========================
            Dim result As JObject = JObject.Parse(response)
            Dim isResult As Boolean = CBool(result("IsResult").ToString())
            Dim errorMsg As String = result("ErrorMsg").ToString()

            'MsgBox("IsResult: " & isResult & vbCrLf & _
            '       "ErrorMsg: " & errorMsg, _
            '       MsgBoxStyle.Information, "Debug Step 7")

            'If isResult = True Then
            '    MsgBox("Data berhasil disimpan ke InBody.", _
            '           MsgBoxStyle.Information, "Sukses")
            'Else
            '    MsgBox("Gagal menyimpan ke InBody:" & vbCrLf & errorMsg, _
            '           MsgBoxStyle.Critical, "Error InBody")
            'End If

        Catch ex As Exception
            MsgBox("Gagal kirim ke API InBody: " & ex.Message, _
                   MsgBoxStyle.Critical, "Exception")
        End Try
    End Sub

    Private Sub SaveMultiple()
        Dim tblPasien As DataTable = GridControlDataPasien.DataSource
        tblPasien.AcceptChanges()

        ButtonSimpanData.Enabled = False
        ButtonUploadFile.Enabled = False

        Dim procent As Integer = 0
        Dim persen As Integer = 0

        If MsgBox(tblPasien.Rows.Count & " data pasien akan diproses. Yakin lanjut?", MsgBoxStyle.YesNo, "Verifikasi Akhir") = MsgBoxResult.Yes Then
            ProgressBar1.Visible = True

            Dim company As String = ""
            Dim updatePasien As Boolean = False
            Dim NomorRekamMedis As String = ""

            For Each Tdata As DataRow In tblPasien.Rows
                persen = persen + 1
                procent = persen * 100 / tblPasien.Rows.Count
                ProgressBar1.Value = procent

                updatePasien = False
                Dim statusPasienAktif As Boolean = CekPasienAktif(Tdata)

                If statusPasienAktif = False Then ' Pasien belum ada di Database
                    NomorRekamMedis = generateNomorRekamMedis()

                    WriteSQL("INSERT INTO MasterPasien (noRekamMedis, NoNIK, NoNIP, Nama, TglLahir, JenisKelamin, DomisiliAlamat, FromUpload, CreatedBy, CreatedDate) " & _
                             "VALUES('" & NomorRekamMedis & "', '" & Tdata("PTNIK") & "', '" & Tdata("NIP") & "', '" & Tdata("Nama") & "', '" & Format(Tdata("TglLahir"), "MM/dd/yyyy") & "','" & Tdata("Sex") & "', '" & Tdata("Alamat") & "', " & Convert.ToInt32(True) & ", '" & userUploadMCU & "', GETDATE())", 4)
                ElseIf statusPasienAktif = True Then ' Pasien sudah ada di Database
                    NomorRekamMedis = ReadSQLNIK("SELECT noRekamMedis FROM MasterPasien WHERE Nama = '" & Tdata("Nama") & "' AND TglLahir = '" & Format(Tdata("TglLahir"), "MM/dd/yyyy") & "' AND NoNIK = '" & Tdata("PTNIK") & "'")

                    ' Update alamat di MasterPasien
                    WriteSQL("UPDATE MasterPasien SET DomisiliAlamat = '" & Tdata("Alamat") & "', NoNIP = '" & Tdata("NIP") & "' WHERE NoRekamMedis = '" & NomorRekamMedis & "'", 4)

                    updatePasien = True
                End If

                ' Generate No Urut Transaksi
                Dim nomorUrutTransaksi As String = generateNoTransaksi("M", "LABORATORIUM", Format(Tdata("TglTrans"), "yyyyMMdd"), True)

                company = ReadSQLNIK("select CompanyNama from MasterCompany where NoCompany = '" & Tdata("Company").ToString.Trim & "'")

                ' Set Cara Ambil
                Dim CaraAmbilSoftcopy As String = ""
                Dim CaraAmbilHardcopy As String = ""
                Dim StatusSoftcopy As Integer = 0
                Dim StatusHardcopy As Integer = 0
                Dim CaraAmbil As String = ""

                If Tdata("Email").ToString.Trim <> "-" And IsDBNull(Tdata("Email")) = False Then
                    CaraAmbilSoftcopy = "Email ke " & Tdata("Email").ToString
                    If updatePasien = True Then WriteSQL("UPDATE MasterPasien SET Email = '" & Tdata("Email") & "', DomisiliAlamat = '" & Tdata("Alamat") & "' WHERE NoRekamMedis = '" & NomorRekamMedis & "'", 4)
                ElseIf Tdata("Whatsapp").ToString.Trim <> "-" And IsDBNull(Tdata("Whatsapp")) = False Then
                    CaraAmbilSoftcopy = "Whatsapp ke " & Tdata("Whatsapp").ToString
                    If updatePasien = True Then WriteSQL("UPDATE MasterPasien SET NoHandphone = '" & Tdata("Whatsapp") & "', DomisiliAlamat = '" & Tdata("Alamat") & "' WHERE NoRekamMedis = '" & NomorRekamMedis & "'", 4)
                End If

                If Tdata("Kirim").ToString <> "-" And IsDBNull(Tdata("Kirim")) = False Then
                    CaraAmbilHardcopy = "Kirim ke " & Tdata("Kirim").ToString
                ElseIf Tdata("AmbilSendiri") = True Then
                    CaraAmbilHardcopy = "Ambil Sendiri"
                End If

                If CaraAmbilHardcopy = "" And CaraAmbilSoftcopy <> "" Then
                    CaraAmbil = CaraAmbilSoftcopy
                    StatusSoftcopy = 1
                ElseIf CaraAmbilHardcopy <> "" And CaraAmbilSoftcopy = "" Then
                    CaraAmbil = CaraAmbilHardcopy
                    StatusHardcopy = 1
                ElseIf CaraAmbilHardcopy <> "" And CaraAmbilSoftcopy <> "" Then
                    CaraAmbil = CaraAmbilHardcopy & " & " & CaraAmbilSoftcopy
                    StatusHardcopy = 1
                    StatusSoftcopy = 1
                End If

                ' Insert Tabel TransaksiLab
                WriteSQL("INSERT INTO TransaksiLab (IDInternet, DokterRequest, DokterLab, TglLab, ClosedBayar,TotalTagihan,TotalDisc,Pembulatan,NettBayar,LabJenisPembayaran,ClosedTransaksi,CreateDate,CreateBy,LabJenisPasien,NoUrut,Status,LabDaftar,IDPaket,CaraAmbil, StatusSoftcopy, StatusHardcopy, SendingWhatsapp, SendingEmail) " & _
                         "VALUES('" & NomorRekamMedis & "','','','" & Format(Tdata("TglTrans"), "MM/dd/yyyy") & "',GETDATE(),0,0,0,0,'',1,GETDATE(),'" & userUploadMCU & "','','" & nomorUrutTransaksi & "','SAMPLE',getdate(),'" & Tdata("NoPaket") & "', '" & CaraAmbil & "'," & StatusSoftcopy & "," & StatusHardcopy & ", '" & Tdata("Whatsapp").ToString & "', '" & Tdata("Email").ToString & "')", 4)

                ' Kirim Ke InBody
                Try
                    'MsgBox("Debug: Proses Kirim ke InBody dijalankan.", MsgBoxStyle.Information, "Debug InBody")

                    Dim nama As String = Tdata("Nama").ToString()
                    Dim jenisKelamin As String = Tdata("Sex").ToString()
                    Dim genderInbody As String = ""

                    Select Case jenisKelamin.ToUpper()
                        Case "L"
                            genderInbody = "M"
                        Case "P"
                            genderInbody = "F"
                        Case Else
                            genderInbody = ""
                    End Select

                    Dim tglLahir As Date = CDate(Tdata("TglLahir"))
                    Dim tglLahirStr As String = CDate(Tdata("TglLahir")).ToString("yyyyMMdd")
                    Dim umur As Integer = DateDiff(DateInterval.Year, tglLahir, Date.Now)
                    Dim orderDateStr As String = CDate(Tdata("TglTrans")).ToString("yyyyMMdd")
                    Dim kodeServer As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'KodeBarcode'")
                    Dim kodeCabang As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NoPoli'")

                    ' Tinggi badan dikosongkan sesuai permintaan
                    Dim tinggiUserInbody As String = ""

                    'MsgBox("Status WS InBody: " & statusInbody, MsgBoxStyle.Information, "Debug InBody")

                    'MsgBox("Debug: Mengirim data ke API InBody.", MsgBoxStyle.Information, "Debug InBody")

                    SendToApiInbodyFromMCU( _
                        nomorUrutTransaksi, _
                        nama, _
                        genderInbody, _
                        tglLahirStr, _
                        umur, _
                        tinggiUserInbody, _
                        orderDateStr, _
                        kodeServer, _
                        kodeCabang)

                Catch ex As Exception
                    MsgBox("Gagal mengirim data ke InBody: " & ex.Message, _
                           MsgBoxStyle.Exclamation, "Warning")
                End Try

                ' Set ID Transaksi
                Dim idTransaksi As String = ReadSQLNIK("SELECT TransLabID FROM TransaksiLab WHERE IDInternet = '" & NomorRekamMedis & "' AND NoUrut = '" & nomorUrutTransaksi & "'")

                ' Set Tabel Master Paket
                Dim tblPaket As DataTable = ReadSQL("SELECT * FROM MasterLabPaket a LEFT JOIN MasterLabPaketDetail b on a.PaketID = b.PaketID  where a.PaketID = '" & Tdata("NoPaket") & "'")
                tblPaket.AcceptChanges()

                Dim ttlbruto As Double = 0
                Dim ttldisc As Double = 0
                Dim ttlbulat As Double = 0
                Dim ttlnett As Double = 0
                Dim DetailPemeriksaan As String = ""
                Dim TtempDetailPemeriksaan As String = ""

                For Each Trow As DataRow In tblPaket.Rows
                    TtempDetailPemeriksaan = TtempDetailPemeriksaan & "" & Trow("NamaTindakan").ToString.Trim & ", "
                    Dim Disc As Double = CDbl(Trow("TindakanNilai")) - CDbl(Trow("TindakanNett"))

                    ' Insert Tabel TransaksiLabDetail
                    WriteSQL("INSERT INTO TransaksiLabDetail(TransLabID,TindakanID,NamaTindakan,JenisTindakan,BiayaTindakan,DiscTindakan,NettBayar,admin,transaksitime,DiscPersenTindakan) " & _
                             "VALUES('" & idTransaksi & "','" & Trow("TindakanID") & "','" & Trow("NamaTindakan") & "','" & Trow("JenisTindakan") & "'," & CDbl(Trow("TindakanNilai")) & "," & Disc & "," & CDbl(Trow("TindakanNett")) & ",'" & userUploadMCU & "',getdate()," & CDbl(Trow("TindakanDiscount")) & ")", 4)

                    Dim Tnomber As String = ReadSQLNIK("select TransLabIDDetail from TransaksiLabDetail where TransLabID='" & idTransaksi & "' and TindakanID='" & Trow("TindakanID") & "' and NamaTindakan='" & Trow("NamaTindakan") & "' and JenisTindakan='" & Trow("JenisTindakan") & "'")
                    ttlbruto = ttlbruto + CDbl(Trow("TindakanNilai"))
                    ttlnett = ttlnett + CDbl(Trow("TindakanNett"))
                    ttldisc = ttldisc + CDbl(Trow("TindakanNilai")) - CDbl(Trow("TindakanNett"))

                    Dim Tbls2 As DataTable = ReadSQL("SELECT * FROM MasterLabDetail where TindakanID='" & Trow("TindakanID") & "' and deleted=0 order by groupid,nourut")
                    For Each Trow2 As DataRow In Tbls2.Rows
                        ' Insert Tabel TransaksiLabResult
                        WriteSQL("INSERT INTO TransaksiLabResult(TransLabIDDetail,TindakanID,GroupID,NoUrut,DetailKet,Pria,Wanita,Result,Keterangan,Satuan) " & _
                                 " values('" & Tnomber & "','" & Trow("TindakanID") & "','" & Trow2("GroupID") & "','" & Trow2("NoUrut") & "','" & Trow2("DetailKet") & "','" & Trow2("Pria") & "','" & Trow2("Wanita") & "','','" & Trow2("KeteranganHasil") & "','" & Trow2("DisplayHasil") & "') ", 4)
                    Next
                Next

                ' Set Detail Pemeriksaan
                DetailPemeriksaan = Strings.Left(TtempDetailPemeriksaan, TtempDetailPemeriksaan.Length - 2)

                ' Update Nomor Urut dan Mesin di Tabel UpdateTransLabDetail
                UpdateTransLabDetail(idTransaksi)

                ' Insert Tabel TransaksiDetail
                WriteSQL("INSERT INTO TransaksiDetail(NoUrutBPJS, NoTransaksi, JenisKunjungan, JenisRawat, JenisTransaksi, JenisPoli, TanggalTransaksi, KeluhanUtama, KeluhanTambahan, IDInternet, StatusBPJS, NoUrut, StatusHandaya, StatusLansia, StatusDifabel, StatusGawatDarurat, CreatedBy, CreatedDate) " & _
                         "VALUES(NULL, '" & idTransaksi & "', 'Kunjungan Sakit', 'Rawat Jalan', 'LAB', 'LABORATORIUM', GETDATE(), '-', '-', '" & NomorRekamMedis & "'," & Convert.ToInt32(False) & ", '" & nomorUrutTransaksi & "', " & Convert.ToInt32(False) & ", " & _
                         "" & Convert.ToInt32(False) & ", " & Convert.ToInt32(False) & ", " & Convert.ToInt32(False) & ", '" & userUploadMCU & "', GETDATE())", 4)

                ' Insert Tabel TransaksiLabBayar
                WriteSQL("INSERT INTO TransaksiLabBayar (TransLabID,JenisBayar,NoJenisBayar,JumlahBayar,admin,transaksitime,mesin,kartu) values('" & idTransaksi & "','TAGIHAN','" & company & "-" & Tdata("Company").ToString.Trim & "'," & ttlnett & ",'" & userUploadMCU & "',getdate(),'','')", 4)

                ' Update DetailPemeriksaan di Tabel Transaksilab
                WriteSQL("UPDATE Transaksilab SET DetailPemeriksaan = '" & DetailPemeriksaan & "', TotalTagihan = " & ttlbruto & " , TotalDisc=" & ttldisc & " ,  NettBayar = " & ttlnett & ", TotalBayar = " & ttlnett & " WHERE TransLabID = '" & idTransaksi & "'", 4)
            Next

            MsgBox(tblPasien.Rows.Count & "data berhasil diupload ke sistem.", MsgBoxStyle.Information, "Success!")
        Else
            MsgBox("Canceled.", MsgBoxStyle.Exclamation, "Warning!")
        End If

        ButtonUploadFile.Enabled = True
        ProgressBar1.Visible = False
    End Sub

    Private Sub UpdateTransLabDetail(ByVal idTransaksi As String)
        Try
            ' ================================================================
            ' 1) Update kolom Urutan dari MasterLab (tanpa loop)
            ' ================================================================
            Dim sqlUpdateUrutan As String = _
                "UPDATE d " & _
                "SET d.Urutan = m.Urutan " & _
                "FROM TransaksiLabDetail d " & _
                "INNER JOIN MasterLab m " & _
                "    ON d.TindakanID = m.TindakanID " & _
                "    AND d.NamaTindakan = m.NamaTindakan " & _
                "WHERE d.TransLabID = '" & idTransaksi & "'"

            WriteSQL(sqlUpdateUrutan, 4)

            ' ================================================================
            ' 2) Update Mesin (ambil dari MasterLab)
            ' ================================================================
            Dim sqlUpdateMesin As String = _
                "UPDATE d " & _
                "SET d.Mesin = ISNULL(m.Mesin, '') " & _
                "FROM TransaksiLabDetail d " & _
                "LEFT JOIN MasterLab m " & _
                "    ON d.TindakanID = m.TindakanID " & _
                "WHERE d.TransLabID = '" & idTransaksi & "'"

            WriteSQL(sqlUpdateMesin, 4)

        Catch ex As Exception
            ' Ganti sesuai mekanisme logging/handling aplikasi Anda
            MsgBox("Error UpdateTransLabDetail: " & ex.Message)
        End Try
    End Sub

    Function CekPasienAktif(ByVal Tdata As DataRow) As Boolean
        If CheckSQL("SELECT * FROM MasterPasien WHERE Nama = '" & Tdata("Nama") & "' AND TglLahir = '" & Format(Tdata("TglLahir"), "MM/dd/yyyy") & "' AND NoNIK = '" & Tdata("PTNIK") & "'") = True Then
            Return True
        Else
            Return False
        End If

        Return False
    End Function
End Class