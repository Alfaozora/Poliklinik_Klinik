Imports System.Windows.Forms
Imports KASLibrary
Imports System.Globalization
Imports System.IO
Imports System.Text
Imports System.Reflection
Imports System.Windows.Forms.DataVisualization.Charting

Public Class PoliKlinik
    Dim Ttcon As TLcon
    Public dbsql As KASLibrary.SQL
    Dim TObat As DataTable

    Private Sub DisabledAllMenu()
        MasterToolStripMenuItem1.Visible = False
        PendaftaranToolStripMenuItem.Visible = False
        PoliToolStripMenuItem1.Visible = False
        ReportToolStripMenuItem1.Visible = False
        SettingToolStripMenuItem.Visible = False
        LabToolStripMenuItem.Visible = False
        ToolToolStripMenuItem.Visible = False
        MiscToolStripMenuItem.Visible = False
        KeuanganToolStripMenuItem1.Visible = False
        MCUToolStripMenuItem.Visible = False
        ITToolStripMenuItem1.Visible = False
        KunjunganToolStripMenuItem.Visible = False
    End Sub

    Private Sub EnabledAllMenu()
        For Each TItems As ToolStripMenuItem In MenuStrip.Items
            TItems.Enabled = True
            TItems.Visible = True
            If TItems.HasDropDownItems = True Then
                For Each TItems2 As ToolStripMenuItem In TItems.DropDownItems
                    TItems2.Enabled = True
                    TItems2.Visible = True
                    If TItems2.HasDropDownItems = True Then
                        For Each TItems3 As ToolStripMenuItem In TItems2.DropDownItems
                            TItems3.Enabled = True
                            TItems3.Visible = True
                        Next
                    End If
                Next
            End If
        Next
    End Sub

    Public Sub UserAccess(ByRef Tgroup As String)
        'PatchUpdate.Show()
        'patchupdate.Focus()        
        DisabledAllMenu()

        If Tgroup = "KEU" Then
            KeuanganToolStripMenuItem1.Visible = True
        ElseIf Tgroup <> "ALL" Then
            EnabledAllMenu()

            For Each TItems As ToolStripMenuItem In MenuStrip.Items
                If CheckSQL("select * from MsConfigGrpForm where GroupID='" & Tgroup & "' and FormID='" & TItems.Tag & "' and CanSee=1") = False Then
                    TItems.Enabled = False
                    TItems.Visible = False
                Else
                    If TItems.HasDropDownItems = True Then
                        For Each TItems2 As ToolStripMenuItem In TItems.DropDownItems
                            If CheckSQL("select * from MsConfigGrpForm where GroupID='" & Tgroup & "' and FormID='" & TItems2.Tag & "' and CanSee=1") = False Then
                                TItems2.Enabled = False
                                TItems2.Visible = False
                            Else
                                If TItems2.HasDropDownItems = True Then
                                    For Each TItems3 As ToolStripMenuItem In TItems2.DropDownItems
                                        If CheckSQL("select * from MsConfigGrpForm where GroupID='" & Tgroup & "' and FormID='" & TItems3.Tag & "' and CanSee=1") = False Then
                                            TItems3.Enabled = False
                                            TItems3.Visible = False
                                        End If
                                    Next
                                End If
                            End If
                        Next
                    End If
                End If
            Next
        ElseIf Tgroup = "ALL" Then
            EnabledAllMenu()
        End If

        ChangePasswordToolStripMenuItem.Enabled = True
    End Sub

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub

    '----------Reminder WA------------------'
    Private Function GetNamaKlinik() As String
        Try
            Dim lokasiPoli As String = "SELECT StrValue FROM MsConfig WHERE ConfigName = 'NoPoli'"
            Dim lokasi As DataTable = ReadSQL(lokasiPoli)

            If lokasi IsNot Nothing AndAlso lokasi.Rows.Count > 0 Then
                Dim row As DataRow = lokasi.Rows(0)
                Dim strValue As String = row("StrValue").ToString()

                Select Case strValue
                    Case "W001" : Return "KLINIK MITRA MEDICARE SUCI"
                    Case "W002" : Return "KLINIK MITRA MEDICARE MANYAR"
                    Case "W003" : Return "KLINIK MITRA MEDICARE DRIYOREJO"
                    Case "L001" : Return "KLINIK MITRA MEDICARE DHARMAHUSADA"
                    Case "L002" : Return "KLINIK MITRA MEDICARE DIPONEGORO"
                    Case "L003" : Return "KLINIK LUMIERA LUZELLA"
                    Case "L005" : Return "INHOUSE WINGS SURYA"
                    Case "A002" : Return "KLINIK MITRA MEDICARE JATIUWUH"
                    Case "AD01" : Return "KLINIK MITRA MEDICARE BOYOLALI"
                    Case "D002" : Return "KLINIK MITRA MEDICARE RANCAEKEK"
                    Case "T001" : Return "KLINIK CITRA MEDICARE KARAWANG"
                End Select
            End If

        Catch ex As Exception
            ' Optional: log error atau berikan default
            Return "KLINIK MITRA MEDICARE/INHOUSE"
        End Try

        Return "KLINIK MITRA MEDICARE/INHOUSE"
    End Function

    Private isTestingMode As Boolean = False

    Private Sub KirimReminderOtomatis()
        Dim query As String = "SELECT ReminderID, NamaPasien, NoHP, Keperluan, Tanggal, TanggalKirim, JenisKelamin " & _
                              "FROM LogReminderPasien " & _
                              "WHERE Status = 'TERJADWAL' AND DATEDIFF(DAY, GETDATE(), Tanggal) = 1"

        Dim dt As DataTable = ReadSQL(query)
        Dim now As DateTime = DateTime.Now
        Dim batasKirim As TimeSpan = New TimeSpan(9, 0, 0) ' 09:00 WIB

        For Each row As DataRow In dt.Rows
            Dim waktuReminder As DateTime = CDate(row("Tanggal"))
            Dim sudahDikirim As Boolean = Not IsDBNull(row("TanggalKirim"))

            ' Kirim H-1 setelah jam 9 pagi dan belum dikirim sebelumnya
            If DateDiff(DateInterval.Day, now.Date, waktuReminder.Date) = 1 AndAlso now.TimeOfDay >= batasKirim AndAlso Not sudahDikirim Then

                Dim namaPasien As String = row("NamaPasien").ToString()
                Dim noHP As String = row("NoHP").ToString()
                Dim keperluan As String = row("Keperluan").ToString()

                Dim jenisKelamin As String = ""
                If row("JenisKelamin").ToString.Trim.ToUpper() = "L" Then
                    jenisKelamin = "Bapak"
                ElseIf row("JenisKelamin").ToString.Trim.ToUpper() = "P" Then
                    jenisKelamin = "Ibu"
                End If

                Dim id As Integer = CInt(row("ReminderID"))

                If isTestingMode Then
                    KirimReminderWhatsAppOtomatis("[TEST]" & namaPasien, noHP, waktuReminder, keperluan, jenisKelamin)
                    My.Computer.FileSystem.WriteAllText("log_reminder_test.txt", now & " >> TESTING MODE >> " & noHP & vbCrLf, True)
                Else
                    KirimReminderWhatsAppOtomatis(namaPasien, noHP, waktuReminder, keperluan, jenisKelamin)
                    WriteSQL("UPDATE LogReminderPasien SET Status = 'TERKIRIM', TanggalKirim = GETDATE() WHERE ReminderID = " & id, 4)
                End If
            End If
        Next
    End Sub

    Private Sub TimerKirimReminderWA_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick
        KirimReminderOtomatis()
    End Sub

    Public Function SetParameterWhatsappText(ByVal nomor As String, ByVal pesan As String) As String
        Dim cleanPesan As String = pesan.Replace(vbCrLf, "\n").Replace("""", "\""")

        ' Buat JSON manual
        Dim json As String = "{" & _
            """number"": """ & nomor & """," & _
            """message"": """ & cleanPesan & """" & _
        "}"

        Return json
    End Function

    Private Sub KirimReminderWhatsAppOtomatis(ByVal namaPasien As String, ByVal noHP As String, ByVal tanggal As DateTime, ByVal keperluan As String, ByVal jenisKelamin As String)
        Try
            If noHP.StartsWith("08") Then
                noHP = "62" & noHP.Substring(1)
            End If

            Dim namaKlinik As String = GetNamaKlinik()
            Dim waStatus As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'whatsapp_klinik_status'")
            Dim waIP As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'whatsapp_klinik_ip'")
            Dim lokasiKlinik As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'AlamatCompany'")

            If waStatus <> "Yes" Then Exit Sub

            Dim tanggalIndo As String = tanggal.ToString("dddd, dd MMMM yyyy", New Globalization.CultureInfo("id-ID"))
            Dim pesan As String = "Salam sehat, " & jenisKelamin & " *" & namaPasien & "*." & vbCrLf & vbCrLf & _
                                  "Kami dari " & namaKlinik & " mengingatkan bahwa jadwal kunjungan kesehatan rutin Anda telah tiba." & vbCrLf & vbCrLf & _
                                  "Mohon hadir ke fasilitas kami untuk *" & keperluan & "* sesuai program yang telah disepakati." & vbCrLf & vbCrLf & _
                                  "Tanggal Kunjungan: " & tanggalIndo & vbCrLf & _
                                  "Jam: " & tanggal.ToString("HH:mm") & " WIB" & vbCrLf & _
                                  "Alamat: " & lokasiKlinik & vbCrLf & vbCrLf & _
                                  "Mohon hadir tepat waktu. Untuk informasi lebih lanjut, silakan hubungi kami di Nomor ini." & vbCrLf & _
                                  "Terima kasih." & vbCrLf & vbCrLf & _
                                  "" & namaKlinik & vbCrLf & vbCrLf & _
                                  "----- Sehat Itu Hak Anda -----"

            Dim parameter As String = SetParameterWhatsappText(noHP, pesan)
            Dim urlSend As String = "http://" & waIP & ":4444/send"
            SendDataWhatsapp(parameter, urlSend)

        Catch ex As Exception
            ' Optional: log ke file jika error
        End Try
        My.Computer.FileSystem.WriteAllText("log_reminder.txt", DateTime.Now & " - Dikirim ke: " & noHP & vbCrLf, True)
    End Sub
    '---------------------END Reminder WA-------------------------'

    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer


    Public Sub LoadConnection2()
        Dim lblconnect As String = "Loading Connect to Cahaya Database ..."
        Try
            dbsql = New SQL("root", "Csj03iB", Utility.GetConfig("Server"), Utility.GetConfig("Database"), True, True)
            lblconnect = "Connected Success"
        Catch ex As Exception
            'MsgBox("Failed Connected to Cahaya Database !!!")
            lblconnect = "Failed Connected !!! " & ex.Message
            MsgBox(lblconnect)
        End Try
    End Sub

    Public Sub LoadConnection3()
        'My Connection
        Try
            PusatSQL.Con = New SqlConnection("Data Source='" & Utility.GetConfig("ServerLocal") & "';Initial Catalog='" & Utility.GetConfig("DbApotik") & "';Integrated Security=SSPI;")
            PusatSQL.Con.Open()
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.ToString)
            MsgBox("Error... Exit Program")
            Me.Close()
        End Try
    End Sub

    Public Sub LoadConnection()
        'My Connection
        Try
            Dim passwd As String = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("Password"), "albert")

            'PusatSQL.Con = New SqlConnection("Data Source='" & Utility.GetConfig("ServerLocal") & "';Initial Catalog='" & Utility.GetConfig("DbPoli") & "';Integrated Security=SSPI;")
            PusatSQL.Con = New SqlConnection("Data Source='" & Utility.GetConfig("ServerLocal") & "';Initial Catalog='" & Utility.GetConfig("DbPoli") & "';Persist Security Info=True;Integrated Security=False;User ID='" & Utility.GetConfig("Username") & "'; Password='" & passwd & "';")
            PusatSQL.Con.Open()
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.ToString)
            MsgBox("Error... Exit Program")
            Me.Close()
        End Try

    End Sub

    Private Sub PoliKlinik_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TimerKirimReminderWA.Interval = 60000
        TimerKirimReminderWA.Start()

        Me.BackgroundImage = Image.FromFile(Application.StartupPath + "\Image\wallpaper.jpg")

        Dim current As CultureInfo = My.Application.Culture
        If current.ToString <> "en-US" Then
            MsgBox("Regional Setting tidak sesuai. Ganti dengan Regional Setting : English-(United States)")
            Me.Close()
        End If

        Me.Hide()

        ' Mengakses informasi versi file dari assembly
        Dim versionProgram As String = ""
        Dim versionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location)
        Dim fileVersion As String = versionInfo.FileVersion

        ' Mengakses deskripsi dari atribut AssemblyDescription
        Dim description As String = String.Empty
        Dim attributes() As Object = Assembly.GetExecutingAssembly().GetCustomAttributes(GetType(AssemblyDescriptionAttribute), False)
        If attributes.Length > 0 Then
            description = DirectCast(attributes(0), AssemblyDescriptionAttribute).Description
        End If

        versionProgram = "Version : " & fileVersion & " (" & description & ")"

        Lblversi.Text = versionProgram
        Lbltime.Text = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:sss")

        If Utility.GetConfig("DrPK") = "Yes" Or Utility.GetConfig("Keu") = "Yes" Or Utility.GetConfig("JPK") = "Yes" Then

            Login.ShowDialog()
        Else
            LoadConnection()

            Dim versionFromDatabase As String = ReadSQLNIK("SELECT StrValue FROM msconfig WHERE ConfigName = 'versi_program_poliklinik'")
           
            If versionFromDatabase = "-" Then
                MsgBox("Confirm IT untuk Insert versi di Server. Upgrade db dan Program")
                Me.Close()
            End If

            If versionFromDatabase <> versionProgram Then
                'versi program di komp client ini g sama dengan server. Perbaiki di komp ini. Baik Poli ataupun yg MCU.
                MsgBox("Versi Program di Komp ini tidak sama dengan di server ( Poli ataupun MCU ). Update Program untuk komp ini.")
                Me.Close()
            Else
                Login.ShowDialog()
            End If

            Dim userproses As String = ReadSQLNIK("select GroupID from Users where UserID='" & Login.UsernameTextBox.Text & "'")

            If userproses.ToUpper.Contains("LAB") = True Then
                MonitorProcess.Show()
                MonitorProcess.Focus()
            End If
        End If
    End Sub

    Public Sub CloseAll()
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Lbltime.Text = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:sss")
        Dim Tdate As Date = DateAndTime.Now

        'Tdate = TimeSerial("00", "00", "15")
        'If Tdate.Hour = DateAndTime.Now.Hour And Tdate.Minute = DateAndTime.Now.Minute And Tdate.Second = DateAndTime.Now.Second And Utility.GetConfig("") = "" Then
        '    SendHasilToday(DateAndTime.Now)
        'End If
    End Sub

    Public Sub SendHasilToday(ByVal Tdatenow As Date)

        Ttcon.Tid = "u9562915_yogy"
        Ttcon.Tip = "ogikomkom.web.id"
        Ttcon.Tdb = "u9562915_poli"
        Ttcon.Tpass = Strings.Replace("yogy|123", "|", "")

        'Dim Tdate As Date = DateAndTime.Now.AddDays(-1)

        If CheckThemysql("select * from acctranspenerimaan where acc1status=1 and inctgl='" & Format(Tdatenow.Date, "yyyyMMdd") & "'", Ttcon) = True Then
            MsgBox("Data tanggal tersebut telah terkunci. Tidak bisa di-send ulang.")
        Else
            Dim Tadmin As DataTable = ReadSQL("select 'Admin       ' as Jenis,JenisBayar,mesin,kartu,(sum(JumlahBayar)-sum(Kembali)) as Penerimaan from TransaksiAdminBayar where TransAdminID in (select TransAdminID  from TransaksiAdmin where deleted=0 and TindakanTgl between '" & Format(Tdatenow.Date, "MM/dd/yyyy") & " 00:00:00' and '" & Format(Tdatenow.Date, "MM/dd/yyyy") & " 23:59:59') group by JenisBayar,mesin,kartu ")
            Dim Tawalpoli As DataTable = ReadSQL("select 'Poli Awal   ' as Jenis,JenisBayar,mesin,kartu,(sum(JumlahBayar)-sum(Kembali)) as Penerimaan from TransaksiPoliBayarAwal  where TransJenis='POLI' and  TransPoliID in (select TransPoliID  from TransaksiPoli where deleted=0 and CONVERT(date, TglPoli) between '" & Format(Tdatenow.Date, "MM/dd/yyyy") & " 00:00:00' and '" & Format(Tdatenow.Date, "MM/dd/yyyy") & " 23:59:59') group by JenisBayar,mesin,kartu")
            Dim Tawalgigi As DataTable = ReadSQL("select 'Gigi Awal   ' as Jenis,JenisBayar,mesin,kartu,(sum(JumlahBayar)-sum(Kembali)) as Penerimaan from TransaksiPoliBayarAwal  where TransJenis='GIGI' and  TransPoliID in (select TransPoliID  from TransaksiPoli where deleted=0 and CONVERT(date, TglPoli) between '" & Format(Tdatenow.Date, "MM/dd/yyyy") & " 00:00:00' and '" & Format(Tdatenow.Date, "MM/dd/yyyy") & " 23:59:59') group by JenisBayar,mesin,kartu ")
            Dim Tpoli As DataTable = ReadSQL("select 'Poli        ' as Jenis,JenisBayar,mesin,kartu,(sum(JumlahBayar)-sum(Kembali)) as Penerimaan from TransaksiPoliBayar where TransPoliID in (select TransPoliID  from TransaksiPoli where deleted=0 and CONVERT(date, TglPoli) between '" & Format(Tdatenow.Date, "MM/dd/yyyy") & " 00:00:00' and '" & Format(Tdatenow.Date, "MM/dd/yyyy") & " 23:59:59') group by JenisBayar,mesin,kartu ")
            Dim Tlab As DataTable = ReadSQL("select 'Laboratorium' as Jenis,JenisBayar,mesin,kartu,(sum(JumlahBayar)-sum(Kembali)) as Penerimaan from TransaksiLabBayar  where TransLabID  in (select TransLabID  from TransaksiLab  where deleted=0 and TglLab  between '" & Format(Tdatenow.Date, "MM/dd/yyyy") & " 00:00:00' and '" & Format(Tdatenow.Date, "MM/dd/yyyy") & " 23:59:59') group by JenisBayar,mesin,kartu ")
            Dim Tgigi As DataTable = ReadSQL("select 'Gigi        ' as Jenis,JenisBayar,mesin,kartu,(sum(JumlahBayar)-sum(Kembali)) as Penerimaan from TransaksiGigiBayar  where TransGigiID  in (select TransGigiID  from TransaksiGigi where deleted=0 and CONVERT(date, TglGigi) between '" & Format(Tdatenow.Date, "MM/dd/yyyy") & " 00:00:00' and '" & Format(Tdatenow.Date, "MM/dd/yyyy") & " 23:59:59') group by JenisBayar,mesin,kartu ")

            ConcatAll(Tadmin, Tawalpoli, Tawalgigi, Tpoli, Tlab, Tgigi, Tdatenow)
        End If

    End Sub

    Private Sub ConcatAll(ByVal Tadmin As DataTable, ByVal Tawalpoli As DataTable, ByVal Tawalgigi As DataTable, ByVal Tpoli As DataTable, ByVal Tlab As DataTable, ByVal Tgigi As DataTable, ByVal Tdate As Date)
        For Each Trow As DataRow In Tawalpoli.Rows
            Dim Tnew As DataRow = Tadmin.NewRow
            For i As Integer = 0 To Tadmin.Columns.Count - 1
                Tnew(i) = Trow(i)
            Next
            Tadmin.Rows.Add(Tnew)
        Next

        For Each Trow As DataRow In Tawalgigi.Rows
            Dim Tnew As DataRow = Tadmin.NewRow
            For i As Integer = 0 To Tadmin.Columns.Count - 1
                Tnew(i) = Trow(i)
            Next
            Tadmin.Rows.Add(Tnew)
        Next

        For Each Trow As DataRow In Tpoli.Rows
            Dim Tnew As DataRow = Tadmin.NewRow
            For i As Integer = 0 To Tadmin.Columns.Count - 1
                Tnew(i) = Trow(i)
            Next
            Tadmin.Rows.Add(Tnew)
        Next

        For Each Trow As DataRow In Tlab.Rows
            Dim Tnew As DataRow = Tadmin.NewRow
            For i As Integer = 0 To Tadmin.Columns.Count - 1
                Tnew(i) = Trow(i)
            Next
            Tadmin.Rows.Add(Tnew)
        Next

        For Each Trow As DataRow In Tgigi.Rows
            Dim Tnew As DataRow = Tadmin.NewRow
            For i As Integer = 0 To Tadmin.Columns.Count - 1
                Tnew(i) = Trow(i)
            Next
            Tadmin.Rows.Add(Tnew)
        Next

        Dim Tloc As String = ReadSQLNIK("select StrValue  from MsConfig where ConfigName='NoPoli'")

        WriteThemysql("delete from acctranspenerimaandetail where loc='" & Tloc & "' and inctgl='" & Format(Tdate, "yyyyMMdd") & "'", Ttcon)

        For Each Trow As DataRow In Tadmin.Rows
            WriteThemysql(" insert into acctranspenerimaandetail (inctgl, incjenis, incnilai, createdate, mesin, kartu, loc, jenis) " & _
                          " values('" & Format(Tdate, "yyyyMMdd") & "','" & Trow("Jenis") & "','" & Trow("penerimaan") & "',now(),'" & Trow("mesin") & "','" & Trow("kartu") & "','" & Tloc & "','" & Trow("Jenisbayar") & "')", Ttcon)
        Next
    End Sub

    Private Sub UpdateObatToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateObatToolStripMenuItem.Click
        LoadConnection3()
        TObat = ReadSQL("select * from MasterObat where ObatId in ( select a.ObatID from DailyStock a left join MasterObat b on a.obatid=b.ObatID  where a.ClosedDate >= (select MAX(closingdate) " & _
                                  "from  ClosingDate  where WrhID='1' and Locked=1) and  a.Closed = 1 And a.WrhID ='1' group by a.ObatID,b.ObatKodeID,b.ObatNama having SUM(a.jumlah)> 0) ")

        LoadConnection()

        WriteSQL("delete from MasterObat", 4)
        For Each Trow As DataRow In TObat.Rows
            WriteSQL("insert into [MasterObat] ([ObatID],[ObatKodeID],[ObatNama],[ObatNumberID],[ObatPabrikID],[ObatSatuanUnit],[ObatSatuanBox],[ObatMinimunStock],[ObatHargaJualNow],[ObatKeterangan],[CreateDate],[CreateBy],[ObatComponent],[Produsen]) " & _
                     "values('" & Trow("ObatID") & "','" & Trow("ObatKodeID") & "','" & Trow("ObatNama") & "','" & Trow("ObatNumberID") & "','" & Trow("ObatPabrikID") & "','" & Trow("ObatSatuanUnit") & "'," & Trow("ObatSatuanBox") & "," & Trow("ObatMinimunStock") & "," & Trow("ObatHargaJualNow") & ",'" & Trow("ObatKeterangan") & "','" & Trow("CreateDate") & "','" & Trow("CreateBy") & "','" & Trow("ObatComponent") & "','" & Trow("Produsen") & "')", 4)
        Next

    End Sub


    Private Sub UGDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UGDToolStripMenuItem.Click

    End Sub

    Private Sub ReportPenerimaanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportPenerimaanToolStripMenuItem.Click
        'report lama. Bisa digunakan tapi kurang pas
        'ReportPenerimaan.Show()
        'ReportPenerimaan.Focus()

        'report baru. lebih detail
    End Sub

    Private Sub JenisTestLabToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JenisTestLabToolStripMenuItem.Click
        MasterTestLab.Show()
        MasterTestLab.Focus()
    End Sub

    Private Sub GroupTestLabToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupTestLabToolStripMenuItem.Click
        MasterTestLabDetail.Show()
        MasterTestLabDetail.Focus()
    End Sub

    Private Sub PaketLabToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaketLabToolStripMenuItem.Click
        MasterGroupTestLab.Show()
        MasterGroupTestLab.Focus()
    End Sub

    Private Sub GroupUserToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupUserToolStripMenuItem.Click
        SettingGroup.Show()
        SettingGroup.Focus()
    End Sub

    Private Sub UserToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserToolStripMenuItem.Click
        SettingUser.Show()
        SettingUser.Focus()
    End Sub

    Private Sub PembayaranPoliToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PembayaranPoliToolStripMenuItem.Click
        FormTransaksiPoli.Show()
        FormTransaksiPoli.Focus()
    End Sub

    Private Sub AdminLabToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LaboratoriumLokalToolStripMenuItem.Click
        LabAdmin.Show()
        LabAdmin.Focus()
    End Sub

    Private Sub ChangePasswordToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangePasswordToolStripMenuItem1.Click
        ChangePassword.Show()
        ChangePassword.Focus()
    End Sub

    Private Sub CetakKartuToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CetakKartuToolStripMenuItem1.Click
        CetakKartu.Show()
        CetakKartu.Focus()
    End Sub

    Private Sub KwitansiToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KwitansiToolStripMenuItem1.Click
        FormCetakInvoice.Show()
        FormCetakInvoice.Focus()
    End Sub

    Private Sub DownloadHasilToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        DownloadHasil.Show()
        DownloadHasil.Focus()
    End Sub

    Private Sub PenggunaanStockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PenggunaanStockToolStripMenuItem.Click
        FormCetakBarcode.Show()
        FormCetakBarcode.Focus()
    End Sub

    Private Sub DokterPengirimToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DokterPengirimToolStripMenuItem.Click
        DokterPengirimLab.Show()
        DokterPengirimLab.Focus()
    End Sub

    Private Sub PendapatanLabToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PendapatanLabToolStripMenuItem.Click
        Report_Pendapatan_Klinik.Show()
        Report_Pendapatan_Klinik.Focus()
        Report_Pendapatan_Klinik.txjenis.Text = "LAB"
        Report_Pendapatan_Klinik.ClearData()
    End Sub

    Private Sub PendapatanKlinikToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PendapatanKlinikToolStripMenuItem.Click
        Report_Pendapatan_Klinik.Show()
        Report_Pendapatan_Klinik.Focus()
        Report_Pendapatan_Klinik.txjenis.Text = "KLINIK"
        Report_Pendapatan_Klinik.ClearData()
    End Sub

    Private Sub MasterPaketToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MasterPaketToolStripMenuItem.Click
        MasterPaket.Show()
        MasterPaket.Focus()
    End Sub

    Private Sub DesignReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DesignReportToolStripMenuItem.Click
        Report = New XtraReport
        Report.RunDesigner()
    End Sub

    Private Sub PendapatanGigiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PendapatanGigiToolStripMenuItem.Click
        Report_Pendapatan_Klinik.Show()
        Report_Pendapatan_Klinik.Focus()
        Report_Pendapatan_Klinik.txjenis.Text = "GIGI"
        Report_Pendapatan_Klinik.ClearData()
    End Sub

    Private Sub SummaryHarianToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SummaryHarianToolStripMenuItem.Click
        SummaryHarian.Show()
        SummaryHarian.Focus()
    End Sub

    Private Sub QueryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QueryToolStripMenuItem.Click
        LoadConnection2()
        Dim Tbls As DataTable = ReadSQL("select * from UpdateInternet where MasterPasien=1 ")
        For Each Trow As DataRow In Tbls.Rows
            WriteMySQL(Strings.Replace(Trow("Strquery").ToString, "#", "'"), 4)
            WriteSQL("update UpdateInternet set Checked=1 , UpdateDate=getdate()  where QueryID='" & Trow("QueryID") & "'", 4)
        Next
    End Sub

    Private Sub PembatalanTransaksiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PembatalanTransaksiToolStripMenuItem.Click
        FormPembatalanTransaksi.Show()
        FormPembatalanTransaksi.Focus()
    End Sub

    Private Sub MsConfigToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MsConfigToolStripMenuItem.Click
        Msconfig.Show()
        Msconfig.Focus()
    End Sub

    Private Sub FormMenuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormMenuToolStripMenuItem.Click
        FormMenu.Show()
        FormMenu.Focus()
    End Sub

    Private Sub DownloadHasilMesinToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ResultMachine.Show()
        ResultMachine.Focus()
    End Sub

    Private Sub PasienToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasienToolStripMenuItem2.Click
        ReportMasterPasien.Show()
        ReportMasterPasien.Focus()
    End Sub

    Private Sub HargaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HargaToolStripMenuItem.Click
        ReportMasterHarga.Show()
        ReportMasterHarga.Focus()
    End Sub

    Private Sub DownloadKPAToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DownloadKPAToolStripMenuItem.Click
        DownloadKPA.Show()
        DownloadKPA.Focus()
    End Sub

    Private Sub ReportPenyakitTerbanyakToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportPenyakitTerbanyakToolStripMenuItem.Click
        ReportSummaryJenisPenyakit.Show()
        ReportSummaryJenisPenyakit.Focus()
    End Sub

    Private Sub ReportJumlahKunjunganToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportJumlahKunjunganToolStripMenuItem.Click
        ReportKunjungan.Show()
        ReportKunjungan.Focus()
    End Sub

    Private Sub PendapatanAdminToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PendapatanAdminToolStripMenuItem.Click
        Report_Pendapatan_Klinik.Show()
        Report_Pendapatan_Klinik.Focus()
        Report_Pendapatan_Klinik.txjenis.Text = "ADMIN"
        Report_Pendapatan_Klinik.ClearData()
    End Sub

    Private Sub PendapatanHarianDetailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PendapatanHarianDetailToolStripMenuItem.Click
        ReportLabPendapatanHarianDetail.Show()
        ReportLabPendapatanHarianDetail.Focus()
        ReportLabPendapatanHarianDetail.txketerangan.Text = "Pembayaran"
        ReportLabPendapatanHarianDetail.Label2.Text = "SUMMARY PENDAPATAN PER-JENIS BAYAR"
        'Report_Pendapatan_Klinik.ClearData()
    End Sub

    Private Sub MasterPaketToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MasterPaketToolStripMenuItem1.Click
        MasterPaket.Show()
        MasterPaket.Focus()
    End Sub

    Private Sub CompanyKerjasamaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CompanyKerjasamaToolStripMenuItem.Click
        MasterCompany.Show()
        MasterCompany.Focus()
    End Sub

    Private Sub PendapatanHarianPerTindakanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PendapatanHarianPerTindakanToolStripMenuItem.Click
        ReportLabPendapatanHarianDetail.Show()
        ReportLabPendapatanHarianDetail.Focus()
        ReportLabPendapatanHarianDetail.txketerangan.Text = "Tindakan"
        ReportLabPendapatanHarianDetail.Label2.Text = "SUMMARY PENDAPATAN PER-TINDAKAN"

    End Sub

    Private Sub TransaksiLabToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransaksiLabToolStripMenuItem1.Click
        TransaksiLab.Show()
        TransaksiLab.Focus()
    End Sub

    Private Sub SettingProgramToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingProgramToolStripMenuItem.Click
        SettingAwal.Show()
        SettingAwal.Focus()
    End Sub

    Private Sub SendUlangLapPendapatanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendUlangLapPendapatanToolStripMenuItem.Click
        ' Old Form
        'FormKirimLaporanOmset.Show()
        'FormKirimLaporanOmset.Focus()

        ' New Form
        FormUploadDataOmset.Show()
        FormUploadDataOmset.Focus()
    End Sub

    Private Sub LaporanDokterPengirimLabToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LaporanDokterPengirimLabToolStripMenuItem.Click
        ReportLabDokterPengirim.Show()
        ReportLabDokterPengirim.Focus()
    End Sub

    Private Sub RekapTagihanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RekapTagihanToolStripMenuItem.Click
        FormDetailTagihan.Show()
        FormDetailTagihan.Focus()
    End Sub

    Private Sub PendapatanBulananToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PendapatanBulananToolStripMenuItem.Click
        Report_Monthly.Show()
        Report_Monthly.Focus()
    End Sub

    Private Sub SummaryMCUToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SummaryMCUToolStripMenuItem.Click
        ReportSummaryMCU.Show()
        ReportSummaryMCU.Focus()
    End Sub

    Private Sub SummaryMCUToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SummaryMCUToolStripMenuItem1.Click
        ReportSummaryheaderMCU.Show()
        ReportSummaryheaderMCU.Focus()
    End Sub

    Private Sub RepairTransaksiTindakanDetailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepairTransaksiTindakanDetailToolStripMenuItem.Click
        RepairDetailTindakan.Show()
        RepairDetailTindakan.Focus()
    End Sub

    Private Sub ReportDinkesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportDinkesToolStripMenuItem.Click
        ReportSumaaryDinkes.Show()
        ReportSumaaryDinkes.Focus()
    End Sub

    Private Sub JumlahAktifToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ReportJPKAktif.Show()
        ReportJPKAktif.Focus()
    End Sub

    Private Sub JumlahKlaimToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ReportJPKKlaim.Show()
        ReportJPKKlaim.Focus()
    End Sub

    Private Sub LaporanJumlahCheckFisikToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LaporanJumlahCheckFisikToolStripMenuItem.Click
        ReportLabFisik.Show()
        ReportLabFisik.Focus()
    End Sub

    Private Sub UserONLINEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserONLINEToolStripMenuItem.Click
        UserONLINE.Show()
        UserONLINE.Focus()
    End Sub

    Private Sub UrutanDisplayHasilToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UrutanDisplayHasilToolStripMenuItem.Click
        MasterUrutan.Show()
        MasterUrutan.Focus()
    End Sub

    Private Sub JenisTindakanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JenisTindakanToolStripMenuItem.Click
        MasterJenisTindakan.Show()
        MasterJenisTindakan.Focus()
    End Sub

    Private Sub AdminLabOnlineToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LaboratoriumOnlineToolStripMenuItem.Click
        LabAdminOnline.Show()
        LabAdminOnline.Focus()
    End Sub

    Private Sub SummaryDetailMCUToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SummaryDetailMCUToolStripMenuItem.Click
        ReportSummaryMCUOnline.Show()
        ReportSummaryMCUOnline.Focus()
    End Sub

    Private Sub DaftarHadirToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DaftarHadirToolStripMenuItem.Click
        DaftarPeserta.Show()
        DaftarPeserta.Focus()
    End Sub

    Private Sub ReportPendapatanTunaiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportPendapatanTunaiToolStripMenuItem.Click
        ReportPendapatanTunai.Show()
        ReportPendapatanTunai.Focus()
    End Sub

    Private Sub ReportPendapatanTunaiToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportPendapatanTagihanToolStripMenuItem.Click
        ReportPendapatanTagihan.Show()
        ReportPendapatanTagihan.Focus()
    End Sub

    Private Sub ImplementasiBPJSToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImplementasiBPJSToolStripMenuItem1.Click
        'Implementasi.Show()
        'Implementasi.Focus()
    End Sub

    Private Sub TunaiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TunaiToolStripMenuItem.Click
        FormVerifikasiOmsetTunai.Show()
        FormVerifikasiOmsetTunai.Focus()
    End Sub

    Private Sub PelunasanTagihanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PelunasanTagihanToolStripMenuItem.Click
        FormVerifikasiOmsetTagihan.Show()
        FormVerifikasiOmsetTagihan.Focus()
    End Sub

    Private Sub FormPendaftaranPasienToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormPendaftaranPasienToolStripMenuItem.Click
        FormDownloadHasilAdminLabOnline.Show()
        FormDownloadHasilAdminLabOnline.Focus()
    End Sub

    Private Sub StartProcessingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormCetakBarcode.Show()
        FormCetakBarcode.Focus()
    End Sub

    Private Sub RekapTagihanLabToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RekapTagihanLabToolStripMenuItem1.Click
        RekapTagihanLab.Show()
        RekapTagihanLab.Focus()
    End Sub

    Private Sub InvoiceTagihanLabToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InvoiceTagihanLabToolStripMenuItem.Click
        FormInvoiceLab.Show()
        FormInvoiceLab.Focus()
    End Sub

    Private Sub MasterLaboratoriumRujukanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LaboratoriumRujukanToolStripMenuItem.Click
        masterlaboratoriumrujukan.Show()
        masterlaboratoriumrujukan.Focus()
    End Sub

    Private Sub TambahRujukanLabToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TambahRujukanLabToolStripMenuItem.Click
        FormCreateRujukan.Show()
        FormCreateRujukan.Focus()
    End Sub

    Private Sub MasterHargaTindakanRujukanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MasterHargaTindakanRujukanToolStripMenuItem1.Click
        MasterHargaRujukan.Show()
        MasterHargaRujukan.Focus()
    End Sub

    Private Sub ReportTagihanLabToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ReportTagihanLab.Show()
        ReportTagihanLab.Focus()
    End Sub

    Private Sub EmailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmailToolStripMenuItem.Click
        'Form1.Show()
        'Form1.Focus()
    End Sub

    Private Sub ReportPembayaranTagihanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ReportPendapatanTagihan.Show()
        ReportPendapatanTagihan.Focus()
    End Sub

    Private Sub TransaksiLokalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransaksiLokalToolStripMenuItem.Click
        MonitorProcess.Show()
        MonitorProcess.Focus()
    End Sub

    Private Sub TransaksiOnlineToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransaksiOnlineToolStripMenuItem.Click
        MonitorProcessOnline.Show()
        MonitorProcessOnline.Focus()
    End Sub

    Private Sub AutoSendingWhatsappEmailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoSendingWhatsappEmailToolStripMenuItem.Click
        FormAutoSendingWhatsapp.Show()
        FormAutoSendingWhatsapp.Focus()
    End Sub

    Private Sub CetakUlangSuratRujukanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CetakUlangSuratRujukanToolStripMenuItem.Click
        FormCetakUlangRujukan.Show()
        FormCetakUlangRujukan.Focus()
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        MonitorProcessPrint.Show()
        MonitorProcessPrint.Focus()
    End Sub

    Private Sub CariNoInvoiceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CariNoInvoiceToolStripMenuItem.Click
        FindNoInvoice.Show()
        FindNoInvoice.Focus()
    End Sub

    Private Sub LogKirimWhatsappEmailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogKirimWhatsappEmailToolStripMenuItem.Click
        LogWhatsappEmail.Show()
        LogWhatsappEmail.Focus()
    End Sub

    Private Sub LogTransaksiCancelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogTransaksiCancelToolStripMenuItem.Click
        LogTransaksiCancel.Show()
        LogTransaksiCancel.Focus()
    End Sub

    Private Sub RekapPendapatanKlinikToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RekapPendapatanKlinikToolStripMenuItem.Click
        ReportPendapatanKlinik.Show()
        ReportPendapatanKlinik.Focus()
    End Sub

    Private Sub KirimUlangKeMesinToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KirimUlangKeMesinToolStripMenuItem1.Click
        SendUlangToMesin.Show()
        SendUlangToMesin.Focus()
    End Sub

    Private Sub UploadTransaksiKeOnlineToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UploadTransaksiKeOnlineToolStripMenuItem.Click
        ToolsTransaksiLab.Show()
        ToolsTransaksiLab.Focus()
    End Sub

    Private Sub JumlahTransaksiPerTindakanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JumlahTransaksiPerTindakanToolStripMenuItem.Click
        ReportJumlahTindakan.Show()
        ReportJumlahTindakan.Focus()
    End Sub

    Private Sub TimerUpdateProgram_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerUpdateProgram.Tick
        If Utility.GetConfig("JenisUser").ToString.ToUpper = "LOCAL" Then
            If CheckSQLConnection() = False Then
                TimerUpdateProgram.Enabled = False
                ShutdownApplication()
            Else
                Dim Tstatus As String = ReadSQLNIK("select StrValue  from MsConfig where ConfigName='StatusMaintenance'")
                If Tstatus = "Yes" Then
                    TimerUpdateProgram.Enabled = False
                    TimerShutdown.Interval = 60000
                    TimerShutdown.Enabled = True
                    MsgBox("Beberapa saat lagi program tidak bisa diakses selama 5-10 menit karena maintenance, terimakasih.", MsgBoxStyle.Exclamation, "Pemberitahuan")
                ElseIf Tstatus = "No" Then
                    'Skip
                Else
                    MsgBox("Komputer tidak terhubung ke jaringan lokal, periksa kabel LAN atau hubungi IT.", MsgBoxStyle.Exclamation, "Pemberitahuan")
                End If
            End If

            'Dim Tstatus As String = ReadSQLNIK("select StrValue  from MsConfig where ConfigName='StatusMaintenance'")
            'If Tstatus = "Yes" Then
            '    TimerUpdateProgram.Enabled = False
            '    TimerShutdown.Interval = 60000
            '    TimerShutdown.Enabled = True
            '    MsgBox("Beberapa saat lagi program tidak bisa diakses selama 5-10 menit karena maintenance, terimakasih.", MsgBoxStyle.Exclamation, "Pemberitahuan")
            'ElseIf Tstatus = "No" Then
            '    'Skip
            'Else
            '    MsgBox("Komputer tidak terhubung ke jaringan lokal, periksa kabel LAN atau hubungi IT.", MsgBoxStyle.Exclamation, "Pemberitahuan")
            'End If
        End If
    End Sub

    Private Sub TimerShutdown_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerShutdown.Tick
        'Dim Tstatus As String = ReadSQLNIK("select StrValue  from MsConfig where ConfigName='StatusMaintenance'")
        'If Tstatus = "Yes" Then
        '    Dim my_proc As Process = Process.GetCurrentProcess
        '    Dim my_name As String = my_proc.ProcessName

        '    ' Get information about processes with this name.
        '    Dim procs() As Process = _
        '        Process.GetProcessesByName(my_name)

        '    my_proc.Kill()
        'End If
    End Sub

    Private Sub ShutdownApplication()
        Dim my_proc As Process = Process.GetCurrentProcess
        Dim my_name As String = my_proc.ProcessName

        ' Get information about processes with this name.
        Dim procs() As Process = _
            Process.GetProcessesByName(my_name)

        my_proc.Kill()
    End Sub

    Private Sub ReportClosingTagihanKlinikToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportClosingTagihanKlinikToolStripMenuItem.Click
        ReportTagihanPoli.Show()
        ReportTagihanPoli.Focus()
    End Sub

    Private Sub ReportClosingPembayaranToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportClosingPembayaranToolStripMenuItem.Click
        ReportClosingBankTagihan.Show()
        ReportClosingBankTagihan.Focus()
    End Sub

    Private Sub TagihanApotekToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TagihanApotekToolStripMenuItem.Click
        FormSendTagihanApotek.Show()
        FormSendTagihanApotek.Focus()
    End Sub

    Private Sub TambahRefundLaboratoriumToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TambahRefundLaboratoriumToolStripMenuItem.Click
        FormCreateRefund.Show()
        FormCreateRefund.Focus()
    End Sub

    Private Sub CetakUlangSuratRefundToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CetakUlangSuratRefundToolStripMenuItem.Click
        FormCetakUlangRefund.Show()
        FormCetakUlangRefund.Focus()
    End Sub

    Private Sub AccRefundLaboratoriumToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccRefundLaboratoriumToolStripMenuItem.Click
        FormAccRefund.Show()
        FormAccRefund.Focus()
    End Sub

    Private Sub JumlahAktifToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JumlahAktifToolStripMenuItem.Click
        ReportJPKAktif.Show()
        ReportJPKAktif.Focus()
    End Sub

    Private Sub JumlahKlaimToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JumlahKlaimToolStripMenuItem.Click
        ReportJPKKlaim.Show()
        ReportJPKKlaim.Focus()
    End Sub

    Private Sub LaporanRujukanSummaryDetailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LaporanRujukanSummaryDetailToolStripMenuItem.Click
        FormReportRujukan.Show()
        FormReportRujukan.Focus()
    End Sub

    Private Sub KasKecilKeuanganToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KasKecilKeuanganToolStripMenuItem.Click
        FormSendPengajuanDanKasKecil.Show()
        FormSendPengajuanDanKasKecil.Focus()
    End Sub

    Private Sub GajiProgramHRDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GajiProgramHRDToolStripMenuItem.Click
        FormSendGajiHRD.Show()
        FormSendGajiHRD.Focus()
    End Sub

    Private Sub LaporanTagihanPembayaranTagihanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LaporanTagihanPembayaranTagihanToolStripMenuItem.Click
        ReportPendapatanTagihan.Show()
        ReportPendapatanTagihan.Focus()
    End Sub

    Private Sub LaporanTagihanSummaryDetailClosedUnclosedToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LaporanTagihanSummaryDetailClosedUnclosedToolStripMenuItem.Click
        ReportTagihanLab.Show()
        ReportTagihanLab.Focus()
    End Sub

    Private Sub UploadTransaksiTindakanLaboratoriumToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UploadTransaksiTindakanLaboratoriumToolStripMenuItem1.Click
        UploadTindakanLaboratorium.Show()
        UploadTindakanLaboratorium.Focus()
    End Sub

    Private Sub FormMonitoringRekapPrintHasilToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormMonitoringRekapPrintHasilToolStripMenuItem1.Click
        MonitoringMCU.Show()
        MonitoringMCU.Focus()
    End Sub

    Private Sub UploadTransaksiTindakanThoraxToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UploadTransaksiTindakanThoraxToolStripMenuItem2.Click
        UploadTindakanThorax.Show()
        UploadTindakanThorax.Focus()
    End Sub

    Private Sub PinjamanKaryawanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PinjamanKaryawanToolStripMenuItem.Click
        FormSendPinjamanKaryawan.Show()
        FormSendPinjamanKaryawan.Focus()
    End Sub

    Private Sub KapitasiBPJSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KapitasiBPJSToolStripMenuItem.Click
        FormSendKapitasiBPJS.Show()
        FormSendKapitasiBPJS.Focus()
    End Sub

    Private Sub KapitasiKlinikToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KapitasiKlinikToolStripMenuItem1.Click
        FormVerifikasiOmsetKapitasi.Show()
        FormVerifikasiOmsetKapitasi.Focus()
    End Sub

    Private Sub MasterHargaKapitasiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MasterHargaKapitasiToolStripMenuItem.Click
        FormMasterKapitasi.Show()
        FormMasterKapitasi.Focus()
    End Sub

    Private Sub FormTrialToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormTrialToolStripMenuItem.Click
        FormTrial.Show()
        FormTrial.Focus()
    End Sub

    Private Sub TambahPenerimaanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TambahPenerimaanToolStripMenuItem.Click
        AccPenerimaan.Show()
        AccPenerimaan.Focus()
    End Sub

    Private Sub TambahTagihanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TambahTagihanToolStripMenuItem.Click
        FormDetailTagihan.Show()
        FormDetailTagihan.Focus()
    End Sub

    Private Sub FormTrial2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormTrial2ToolStripMenuItem.Click
        FormTesting2.Show()
        FormTesting2.Focus()
    End Sub

    Private Sub SettingPCareToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingPCareToolStripMenuItem.Click
        FormSettingBPJS.Show()
        FormSettingBPJS.Focus()
    End Sub

    Private Sub UploadGajiByExcelToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UploadGajiByExcelToolStripMenuItem.Click
        FormUploadGaji.Show()
        FormUploadGaji.Focus()
    End Sub

    Private Sub LaporanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LaporanToolStripMenuItem.Click
        ' Old Form
        'FormRekapFeeKaryawan.Show()
        'FormRekapFeeKaryawan.Focus()

        ' New Form
        RekapFeeKaryawan.Show()
        RekapFeeKaryawan.Focus()
    End Sub

    Private Sub FormMasterPasienToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormMasterPasienToolStripMenuItem.Click
        FormMasterPasien.Show()
        FormMasterPasien.Focus()
    End Sub

    Private Sub FormTrial5ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormTrial5ToolStripMenuItem.Click
        Form2.Show()
        Form2.Focus()
    End Sub

    Private Sub FormPembayaranToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormPembayaranToolStripMenuItem.Click
        FormPembayaran.Show()
        FormPembayaran.Focus()
    End Sub

    Private Sub FormRekamMedisDokterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormRekamMedisDokterToolStripMenuItem.Click
        FormRekamMedisDokter.Show()
        FormRekamMedisDokter.Focus()
        FormRekamMedisDokter.BringToFront()
    End Sub

    Private Sub FormTrial3ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormTrial3ToolStripMenuItem.Click
        FormTrial.Show()
        FormTrial.Focus()
    End Sub

    Private Sub CariTransaksiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CariTransaksiToolStripMenuItem.Click
        FindTransaksi.Show()
        FindTransaksi.Focus()
    End Sub

    Private Sub FormPendaftaranToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormPendaftaranToolStripMenuItem.Click
        FormPendaftaranAwal.Show()
        FormPendaftaranAwal.Focus()
    End Sub

    Private Sub PencarianObatToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PencarianObatToolStripMenuItem.Click
        FindObat.Show()
        FindObat.Focus()
    End Sub

    Private Sub Form3ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Form3ToolStripMenuItem.Click
        Form4.Show()
        Form4.Focus()
    End Sub

    Private Sub PembatalanTransaksiToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PembatalanTransaksiToolStripMenuItem1.Click
        FormPembatalanTransaksi.Show()
        FormPembatalanTransaksi.Focus()
    End Sub

    Private Sub FormExportHasilMCUToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormExportHasilMCUToolStripMenuItem.Click
        ExportReportLaboratorium.Show()
        ExportReportLaboratorium.Focus()
    End Sub

    Private Sub KasirPoliToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KasirPoliToolStripMenuItem.Click
        FormTransaksiPoli.Show()
        FormTransaksiPoli.Focus()
    End Sub

    Private Sub MasterDokterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MasterDokterToolStripMenuItem.Click
        FormMasterDokter.Show()
        FormMasterDokter.Focus()
    End Sub

    Private Sub MasterPasienToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MasterPasienToolStripMenuItem.Click
        FormMasterPasien.Show()
        FormMasterPasien.Focus()
    End Sub

    Private Sub KunjunganToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KunjunganToolStripMenuItem.Click
        FindTransaksi.Show()
        FindTransaksi.Focus()
    End Sub

    Private Sub PopupTindakanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PopupTindakanToolStripMenuItem.Click
        DialogBoxTambahTindakan.Show()
        DialogBoxTambahTindakan.Focus()
    End Sub

    Private Sub PendaftaranAwalToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PendaftaranAwalToolStripMenuItem1.Click
        FormPendaftaranAwal.Show()
        FormPendaftaranAwal.Focus()
    End Sub

    Private Sub UploadTransaksiMCUToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UploadTransaksiMCUToolStripMenuItem.Click
        UploadPasienMCU.Show()
        UploadPasienMCU.Focus()
    End Sub

    Private Sub CekPlafonPesertaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CekPlafonPesertaToolStripMenuItem.Click
        CheckPlafon.ShowDialog()
        CheckPlafon.Focus()
        CheckPlafon.SetClear()
        CheckPlafon.ClearDataPlafon()
    End Sub

    Private Sub UploadTindakanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UploadTindakanToolStripMenuItem.Click
        UploadTindakan.Show()
        UploadTindakan.Focus()
    End Sub

    Private Sub SatuSehatResourceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SatuSehatResourceToolStripMenuItem.Click
        FormResourceSatuSehat.Show()
        FormResourceSatuSehat.Focus()
    End Sub

    Private Sub SatuSehatSynchronizationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SatuSehatSynchronizationToolStripMenuItem.Click
       
    End Sub

    Private Sub FormMasterDokterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormMasterDokterToolStripMenuItem.Click
        FormMasterDokter.Show()
        FormMasterDokter.Focus()
    End Sub

    Private Sub Daftar10DiagnosaTerbanyakToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Daftar10DiagnosaTerbanyakToolStripMenuItem.Click
        Report10DiagnosaTerbanyak.Show()
        Report10DiagnosaTerbanyak.Focus()
    End Sub

    Private Sub DaftarKunjunganPasienToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DaftarKunjunganPasienToolStripMenuItem.Click
        ReportDaftarKunjunganPesien.Show()
        ReportDaftarKunjunganPesien.Focus()
    End Sub

    Private Sub MasterKapitasiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MasterKapitasiToolStripMenuItem.Click
        FormMasterKapitasi.Show()
        FormMasterKapitasi.Focus()
    End Sub

    Private Sub UploadJurnalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UploadJurnalToolStripMenuItem.Click
        FormUploadJurnal.Show()
        FormUploadJurnal.Focus()
    End Sub

    Private Sub ValidasiFaskesPasienToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ValidasiFaskesPasienToolStripMenuItem.Click
        FormValidasiFaskesPasien.Show()
        FormValidasiFaskesPasien.Focus()
    End Sub

    Private Sub MasterTindakanKlinikToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MasterTindakanKlinikToolStripMenuItem.Click
        ' Old Form
        'FormMasterTindakanKlinik.Show()
        'FormMasterTindakanKlinik.Focus()

        ' New Form
        MasterTindakanKlinik.Show()
        MasterTindakanKlinik.Focus()
    End Sub

    Private Sub RekapPendapatanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RekapPendapatanToolStripMenuItem.Click
        ReportPendapatanKlinik.Show()
        ReportPendapatanKlinik.Focus()
    End Sub

    Private Sub InvoiceTagihanKlinikToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InvoiceTagihanKlinikToolStripMenuItem1.Click
        FormInvoicePoli.Show()
        FormInvoicePoli.Focus()
    End Sub

    Private Sub RekapPendapatanKlinikToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RekapPendapatanKlinikToolStripMenuItem1.Click
        RekapPendapatanPoli.Show()
        RekapPendapatanPoli.Focus()
    End Sub

    Private Sub LaporanRiwayatPaketTindakanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LaporanRiwayatPaketTindakanToolStripMenuItem.Click
        ReportLogPaketTindakan.Show()
        ReportLogPaketTindakan.Focus()
    End Sub

    Private Sub ListPembayaranTagihanOldToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListPembayaranTagihanOldToolStripMenuItem.Click
        FormAwalPembayaranTagihan.Show()
        FormAwalPembayaranTagihan.Focus()
    End Sub

    Private Sub Form1gptToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Form1gptToolStripMenuItem.Click
        Form1gpt.Show()
        Form1gpt.Focus()
    End Sub

    Private Sub LaporanFeeDokterPengirimLabToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LaporanFeeDokterPengirimLabToolStripMenuItem.Click
        ReportFeeDokterPengirim.Show()
        ReportFeeDokterPengirim.Focus()
    End Sub

    Private Sub LaporanDaftarDiagnosaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LaporanDaftarDiagnosaToolStripMenuItem.Click
        ReportDiagnosa.Show()
        ReportDiagnosa.Focus()
    End Sub

    Private Sub SettingICareToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingICareToolStripMenuItem.Click
        SettingIcare.Show()
        SettingIcare.Focus()
    End Sub

    Private Sub KYCToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KYCToolStripMenuItem.Click
        KYC.Show()
        KYC.Focus()
    End Sub

    Private Sub DashboardToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DashboardToolStripMenuItem.Click
        Dashboard.Show()
        Dashboard.Focus()
    End Sub

    Private Sub MasterMarketingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormMasterMarketing.Show()
        FormMasterMarketing.Focus()
    End Sub

    Private Sub CapaianKBKToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CapaianKBKToolStripMenuItem.Click
        ReportCapaianKBK.Show()
        ReportCapaianKBK.Focus()
    End Sub

    Private Sub ReservasiDanReminderToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReservasiDanReminderToolStripMenuItem.Click
        FormReservasi.Show()
        FormReservasi.Focus()
    End Sub

    Private Sub RepairNoKunjunganBPJSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepairNoKunjunganBPJSToolStripMenuItem.Click
        RepairNoKunjunganBPJS.Show()
        RepairNoKunjunganBPJS.Focus()
    End Sub

    Private Sub MasterHargaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MasterHargaToolStripMenuItem.Click
        ReportMasterHarga.Show()
        ReportMasterHarga.Focus()
    End Sub

    Private Sub TesFingerprintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TesFingerprintToolStripMenuItem.Click

    End Sub

    Private Sub GantiDokterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GantiDokterToolStripMenuItem.Click
        ToolGantiDokter.Show()
        ToolGantiDokter.Focus()
    End Sub

    Private Sub Base64EncDecToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Base64EncDecToolStripMenuItem.Click
        FormBase64.Show()
        FormBase64.Focus()
    End Sub

    Private Sub PcareSynchronixationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PcareSynchronizationToolStripMenuItem.Click
        FormSinkronPcare.Show()
        FormSinkronPcare.Focus()
    End Sub

    Private Sub EcounterConditionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EcounterConditionToolStripMenuItem.Click
        FormSynchronizationSatuSehat.Show()
        FormSynchronizationSatuSehat.Focus()
    End Sub

    Private Sub ObservationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ObservationToolStripMenuItem.Click
        FormObservation.Show()
        FormObservation.Focus()
    End Sub

    Private Sub MappingTindakanICD9CMToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MappingTindakanICD9CMToolStripMenuItem.Click
        MappingTindakan.Show()
        MappingTindakan.Focus()
    End Sub
End Class
