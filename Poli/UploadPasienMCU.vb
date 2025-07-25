Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Drawing

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

    Private Sub updateevent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttambahpasien.Click
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
                gridpasien.DataSource = dts.Tables(0)
                conn.Close()
            End If

            butsavemultiple.Enabled = False
            butsavelab.Enabled = True
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

            If CheckSQL("SELECT * FROM MasterPasien WHERE Nama = '" & Trow("Nama").ToString & "' AND TglLahir = '" & Format(Trow("TglLahir"), "MM/dd/yyyy") & "' AND NoNIK = '" & Trow("PTNIK").ToString & "'") = True Then
                If MsgBox("Telah ada karyawan sama. Cek Pasien atas nama " & Trow("Nama").ToString & ". Apakah tetap dilanjutkan ?", MsgBoxStyle.YesNo, "Verifikasi Pasien.") = MsgBoxResult.No Then
                    Return False
                End If
            End If
        Next

        Return True
    End Function

    Private Sub SetGrid()
        gridpasien.DataSource = CreateTable()

        ProgressBar1.Value = 0
        ProgressBar1.Visible = False
        butsavemultiple.Enabled = False
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

    Private Sub butsavelab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butsavelab.Click
        thread = New System.Threading.Thread(AddressOf SaveUpload)
        thread.Start()
    End Sub

    Private Sub SaveUpload()
        Dim Tbls As DataTable = gridpasien.DataSource
        Dim saved As Integer = 1

        Try
            If Tbls.Rows.Count > 0 Then
                butsavelab.Enabled = False
                ProgressBar1.Visible = True
                Dim persen As Integer = 0
                Dim jumlah As Integer = 0

                For Each Trow As DataRow In Tbls.Rows
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
                        saved = 0
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
                        saved = 0
                        Exit For
                    End If

                    'Cek Paket
                    If CheckSQL("SELECT * FROM MasterLabPaket WHERE PaketID = '" & Trow("NoPaket").ToString.Trim & "' AND PaketEnd > GETDATE()") = False Then
                        MsgBox("No. Paket Tidak Terdaftar di Sistem. (Atas nama : " & Trow("Nama") & ")", MsgBoxStyle.Exclamation, "Warning!")
                        saved = 0
                        Exit For
                    End If

                    'Cek Ambil Sendiri
                    If Trow("AmbilSendiri").ToString = "Ya" Or Trow("AmbilSendiri").ToString = "True" Then
                        Trow("AmbilSendiri") = True
                    ElseIf IsDBNull(Trow("AmbilSendiri")) = True Or Trow("AmbilSendiri").ToString = "Tidak" Or Trow("AmbilSendiri").ToString = "-" Or Trow("AmbilSendiri").ToString = "False" Then
                        Trow("AmbilSendiri") = False
                    Else
                        MsgBox("Pilihan Ambil Sendiri hanya Ya/Tidak. (Atas nama : " & Trow("Nama") & ")", MsgBoxStyle.Exclamation, "Warning!")
                        saved = 0
                        Exit For
                    End If

                    'Cek Email
                    If Trow("Email").ToString.Trim <> "" And Trow("Email").ToString.Trim <> "-" Then
                        If validateEmail(Trow("Email").ToString) = False Then
                            MsgBox("Perhatikan penulisan email dengan benar (Atas nama : " & Trow("Nama") & ").", MsgBoxStyle.Exclamation, "Warning!")
                            saved = 0
                            Exit For
                        End If
                    End If

                    'Cek No Whatsapp
                    If Trow("Whatsapp").ToString.Trim <> "" And Trow("Whatsapp").ToString.Trim <> "-" Then
                        If validateNoWhatsapp(Trow("Whatsapp").ToString) = False Then
                            saved = 0
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
                        saved = 0
                        Exit For
                    End If

                    'Softcopy pilih salah satu
                    If Trow("Email").ToString.Trim <> "" And Trow("Email").ToString.Trim <> "-" And Trow("Whatsapp").ToString.Trim <> "" And Trow("Whatsapp").ToString.Trim <> "-" Then
                        MsgBox("Email & Whatsapp harus dipilih salah satu, tidak bisa keduanya. (Atas nama : " & Trow("Nama") & ")", MsgBoxStyle.Exclamation, "Warning!")
                        saved = 0
                        Exit For
                    End If

                    'Hardcopy pilih salah satu
                    If Trow("AmbilSendiri") <> False And Trow("Kirim").ToString.Trim <> "" And Trow("Kirim").ToString.Trim <> "-" Then
                        MsgBox("Kirim & Ambil Sendiri harus dipilih salah satu, tidak bisa keduanya. (Atas nama : " & Trow("Nama") & ")", MsgBoxStyle.Exclamation, "Warning!")
                        saved = 0
                        Exit For
                    End If

                    'Harus pilih
                    If Trow("Email").ToString.Trim = "-" And Trow("Whatsapp").ToString.Trim = "-" And Trow("Kirim").ToString.Trim = "-" And Trow("AmbilSendiri") = False Then
                        MsgBox("Harus memilih antara Whatsapp/Email & Kirim/Ambil Sendiri. (Atas nama : " & Trow("Nama") & ")", MsgBoxStyle.Exclamation, "Warning!")
                        saved = 0
                        Exit For
                    End If

                    Dim procent As Integer = persen * 100 / Tbls.Rows.Count
                    ProgressBar1.Value = procent
                Next
                If saved <> 0 Then
                    If DoubleCheck(Tbls) = False Then saved = 0
                End If
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
            butsavemultiple.Enabled = True
            MsgBox(Tbls.Rows.Count & " data berhasil disimpan, klik tombol save multiple untuk melanjutkan.", MsgBoxStyle.Information, "Success!")
        End If

        ProgressBar1.Visible = False
    End Sub

    Private Sub butnormallab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butnormallab.Click
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

    Private Sub butsavemultiple_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butsavemultiple.Click
        thread = New System.Threading.Thread(AddressOf SaveMultiple)
        thread.Start()
    End Sub

    Private Sub SaveMultiple()
        butsavemultiple.Enabled = False
        buttambahpasien.Enabled = False

        Dim procent As Integer = 0
        Dim persen As Integer = 0
        Dim status_urine As String = Utility.GetConfig("MesinUrine")
        Dim KodeBarcode As String = ReadSQLNIK("select StrValue from MsConfig where ConfigName='KodeBarcode'")

        If MsgBox("Yakin proses lanjut ?", MsgBoxStyle.YesNo, "Verifikasi Akhir") = MsgBoxResult.Yes Then
            ProgressBar1.Visible = True

            Dim company As String = ""
            Dim updatePasien As Boolean = False
            Dim Ttemp As DataTable = gridpasien.DataSource
            Ttemp.AcceptChanges()

            Dim NomorRekamMedis As String = ""

            For Each Tdata As DataRow In Ttemp.Rows
                persen = persen + 1
                procent = persen * 100 / Ttemp.Rows.Count
                ProgressBar1.Value = procent

                'Dim butcustid As String = ""
                updatePasien = False
                Dim Tcheck As String = CekPasienAktif(Tdata)
                If Tcheck = 1 Then
                    NomorRekamMedis = generateNomorRekamMedis()

                    WriteSQL("INSERT INTO MasterPasien (noRekamMedis, NoNIK, NoNIP, Nama, TglLahir, JenisKelamin, DomisiliAlamat, FromUpload, CreatedBy, CreatedDate) " & _
                             "VALUES('" & NomorRekamMedis & "', '" & Tdata("PTNIK") & "', '" & Tdata("NIP") & "', '" & Tdata("Nama") & "', '" & Format(Tdata("TglLahir"), "MM/dd/yyyy") & "','" & Tdata("Sex") & "', '" & Tdata("Alamat") & "', " & Convert.ToInt32(True) & ", '" & userUploadMCU & "', GETDATE())", 4)
                ElseIf Tcheck = 2 Then
                    NomorRekamMedis = ReadSQLNIK("SELECT noRekamMedis FROM MasterPasien WHERE Nama = '" & Tdata("Nama") & "' AND TglLahir = '" & Format(Tdata("TglLahir"), "MM/dd/yyyy") & "' AND NoNIK = '" & Tdata("PTNIK") & "'")

                    ' Update alamat di MasterPasien
                    WriteSQL("UPDATE MasterPasien SET DomisiliAlamat = '" & Tdata("Alamat") & "' WHERE NoRekamMedis = '" & NomorRekamMedis & "'", 4)

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

                WriteSQL("INSERT INTO TransaksiLab (IDInternet, DokterRequest, DokterLab, TglLab, ClosedBayar,TotalTagihan,TotalDisc,Pembulatan,NettBayar,LabJenisPembayaran,ClosedTransaksi,CreateDate,CreateBy,LabJenisPasien,NoUrut,Status,LabDaftar,IDPaket,CaraAmbil, StatusSoftcopy, StatusHardcopy, SendingWhatsapp, SendingEmail) " & _
                         "VALUES('" & NomorRekamMedis & "','','','" & Format(Tdata("TglTrans"), "MM/dd/yyyy") & "',GETDATE(),0,0,0,0,'',1,GETDATE(),'" & userUploadMCU & "','','" & nomorUrutTransaksi & "','SAMPLE',getdate(),'" & Tdata("NoPaket") & "', '" & CaraAmbil & "'," & StatusSoftcopy & "," & StatusHardcopy & ", '" & Tdata("Whatsapp").ToString & "', '" & Tdata("Email").ToString & "')", 4)

                ' Set ID Poli
                Dim idTransaksi As String = ReadSQLNIK("SELECT TransLabID FROM TransaksiLab WHERE IDInternet = '" & NomorRekamMedis & "' AND NoUrut = '" & nomorUrutTransaksi & "'")

                Dim Tbls As DataTable = ReadSQL("SELECT * FROM MasterLabPaket a LEFT JOIN MasterLabPaketDetail b on a.PaketID=b.PaketID  where a.PaketID='" & Tdata("NoPaket") & "'")
                Tbls.AcceptChanges()

                Dim ttlbruto As Double = 0
                Dim ttldisc As Double = 0
                Dim ttlbulat As Double = 0
                Dim ttlnett As Double = 0
                Dim DetailPemeriksaan As String = ""
                Dim TtempDetailPemeriksaan As String = ""

                For Each Trow As DataRow In Tbls.Rows
                    TtempDetailPemeriksaan = TtempDetailPemeriksaan & "" & Trow("NamaTindakan").ToString.Trim & ", "
                    Dim Disc As Double = CDbl(Trow("TindakanNilai")) - CDbl(Trow("TindakanNett"))
                    WriteSQL("INSERT INTO TransaksiLabDetail(TransLabID,TindakanID,NamaTindakan,JenisTindakan,BiayaTindakan,DiscTindakan,NettBayar,admin,transaksitime,DiscPersenTindakan) " & _
                             "VALUES('" & idTransaksi & "','" & Trow("TindakanID") & "','" & Trow("NamaTindakan") & "','" & Trow("JenisTindakan") & "'," & CDbl(Trow("TindakanNilai")) & "," & Disc & "," & CDbl(Trow("TindakanNett")) & ",'" & userUploadMCU & "',getdate()," & CDbl(Trow("TindakanDiscount")) & ")", 4)
                    Dim Tnomber As String = ReadSQLNIK("select TransLabIDDetail from TransaksiLabDetail where TransLabID='" & idTransaksi & "' and TindakanID='" & Trow("TindakanID") & "' and NamaTindakan='" & Trow("NamaTindakan") & "' and JenisTindakan='" & Trow("JenisTindakan") & "'")
                    ttlbruto = ttlbruto + CDbl(Trow("TindakanNilai"))
                    ttlnett = ttlnett + CDbl(Trow("TindakanNett"))
                    ttldisc = ttldisc + CDbl(Trow("TindakanNilai")) - CDbl(Trow("TindakanNett"))

                    Dim Tbls2 As DataTable = ReadSQL("SELECT * FROM MasterLabDetail where TindakanID='" & Trow("TindakanID") & "' and deleted=0 order by groupid,nourut")
                    For Each Trow2 As DataRow In Tbls2.Rows
                        WriteSQL("INSERT INTO TransaksiLabResult(TransLabIDDetail,TindakanID,GroupID,NoUrut,DetailKet,Pria,Wanita,Result,Keterangan,Satuan) " & _
                                 " values('" & Tnomber & "','" & Trow("TindakanID") & "','" & Trow2("GroupID") & "','" & Trow2("NoUrut") & "','" & Trow2("DetailKet") & "','" & Trow2("Pria") & "','" & Trow2("Wanita") & "','','" & Trow2("KeteranganHasil") & "','" & Trow2("DisplayHasil") & "') ", 4)
                    Next
                Next

                'set nama tindakan
                DetailPemeriksaan = Strings.Left(TtempDetailPemeriksaan, TtempDetailPemeriksaan.Length - 2)

                'set no urutan
                Dim Trtemp As DataTable = ReadSQL("SELECT * FROM TransaksiLabDetail where TransLabID='" & idTransaksi & "'")
                For Each Trow As DataRow In Trtemp.Rows
                    Dim Turutan As String = ReadSQLNIK("select Urutan from MasterLab where TindakanID='" & Trow("TindakanID") & "' and NamaTindakan='" & Trow("NamaTindakan") & "'")
                    WriteSQL("update TransaksiLabDetail set Urutan='" & Turutan & "' where TransLabID='" & Trow("TransLabID") & "' and TindakanID='" & Trow("TindakanID") & "' and NamaTindakan='" & Trow("NamaTindakan") & "'", 4)
                Next

                'set mesin atau normal
                Dim TSetmesin As DataTable = ReadSQL("SELECT a.TindakanID FROM TransaksiLabDetail a " & _
                                                     "LEFT JOIN TransaksiLab b ON a.TransLabID = b.TransLabID " & _
                                                     "WHERE b.TransLabID = '" & idTransaksi & "'")
                For Each Rrow As DataRow In TSetmesin.Rows
                    If CheckSQL("SELECT * FROM MasterLab where TindakanID='" & Rrow("TindakanID") & "' and Mesin='TMS'") = True Then
                        WriteSQL("Update TransaksiLabDetail set Mesin='TMS' where TransLabID='" & idTransaksi & "' and TindakanID='" & Rrow("TindakanID") & "'", 4)
                    ElseIf CheckSQL("SELECT * FROM MasterLab where TindakanID='" & Rrow("TindakanID") & "' and Mesin='SYSMEX'") = True Then
                        WriteSQL("Update TransaksiLabDetail set Mesin='SYSMEX' where TransLabID='" & idTransaksi & "' and TindakanID='" & Rrow("TindakanID") & "'", 4)
                    ElseIf CheckSQL("SELECT * FROM masterlab where TindakanID='" & Rrow("TindakanID") & "' and Mesin='CL900'") = True Then
                        WriteSQL("Update transaksilabdetail set Mesin='CL900' where TransLabID='" & idTransaksi & "' and TindakanID='" & Rrow("TindakanID") & "'", 4)
                    ElseIf CheckSQL("SELECT * FROM masterlab where TindakanID='" & Rrow("TindakanID") & "' and Mesin='C0BAS6600'") = True Then
                        WriteSQL("Update transaksilabdetail set Mesin='C0BAS6600' where TransLabID='" & idTransaksi & "' and TindakanID='" & Rrow("TindakanID") & "'", 4)
                    ElseIf CheckSQL("SELECT * FROM masterlab where TindakanID='" & Rrow("TindakanID") & "' and Mesin='URINE'") = True Then
                        If status_urine = "Yes" Then
                            WriteSQL("Update transaksilabdetail set Mesin='URINE' where TransLabID='" & idTransaksi & "' and TindakanID='" & Rrow("TindakanID") & "'", 4)
                        End If
                    Else
                        WriteSQL("Update TransaksiLabDetail set Mesin='' where TransLabID='" & idTransaksi & "' and TindakanID='" & Rrow("TindakanID") & "'", 4)
                    End If
                Next

                'INSERT INTO detail pembayaran dan Ttl di transaksilab
                WriteSQL("INSERT INTO TransaksiLabBayar (TransLabID,JenisBayar,NoJenisBayar,JumlahBayar,admin,transaksitime,mesin,kartu) values('" & idTransaksi & "','TAGIHAN','" & company & "-" & Tdata("Company").ToString.Trim & "'," & ttlnett & ",'" & userUploadMCU & "',getdate(),'','')", 4)
                WriteSQL("update Transaksilab set DetailPemeriksaan='" & DetailPemeriksaan & "', TotalTagihan=" & ttlbruto & " , TotalDisc=" & ttldisc & " ,  NettBayar=" & ttlnett & " , TotalBayar=" & ttlnett & "  where TransLabID='" & idTransaksi & "'", 4)
            Next

            MsgBox("Data berhasil disimpan.", MsgBoxStyle.Information, "Success!")
        Else
            MsgBox("Canceled.", MsgBoxStyle.Exclamation, "Warning!")
        End If

        buttambahpasien.Enabled = True
        ProgressBar1.Visible = False
    End Sub

    Function CekPasienAktif(ByVal Tdata As DataRow) As String




        If CheckSQL("SELECT * FROM MasterPasien WHERE Nama = '" & Tdata("Nama") & "' AND TglLahir = '" & Format(Tdata("TglLahir"), "MM/dd/yyyy") & "' AND NoNIK = '" & Tdata("PTNIK") & "'") = True Then
            Return 2
        Else
            Return 1
        End If

        Return False
    End Function
End Class