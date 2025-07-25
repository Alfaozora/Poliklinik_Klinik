Imports System
Imports System.IO
Imports System.Drawing
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports KASLibrary
Imports System.Reflection

Public Class Login

    'Dim Ttcon As TLcon
    Private DB_Poliklinik As TLcon
    Private DB_Omset As TLcon

    Dim TStatus

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.
    Dim i As Integer = 0

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If UsernameTextBox.Text = "" Then
            MsgBox("Masukkan username")
            UsernameTextBox.Focus()
        End If

        If PasswordTextBox.Text = "" Then
            MsgBox("Masukkan Password")
            PasswordTextBox.Focus()
        End If

        If cmbjenis.Text = "" Then
            MsgBox("Pilih Jenis pada ComboBox")
            cmbjenis.Focus()
            Exit Sub
        End If

        If cmbjenis.FindStringExact(cmbjenis.Text) < 0 Then
            MsgBox("Pilih Jenis pada ComboBox")
            cmbjenis.Focus()
            Exit Sub
        End If

        If (UsernameTextBox.Text = "admin" And PasswordTextBox.Text = "graceraymond_") Then
            PoliKlinik.txmcu.Text = cmbjenis.Text
            PoliKlinik.Visible = True
            PoliKlinik.Lbluser.Text = "Admin"
            PoliKlinik.UserAccess("ALL")
            TStatus = "NEXT"
            Me.Close()
            'ElseIf Utility.GetConfig("JenisUser").ToString.ToUpper = "DRPK" Then
            '    Dim Tbls As DataTable = ReadThemysql("SELECT * FROM users where username='" & UsernameTextBox.Text & "' and password='" & PasswordTextBox.Text & "'", DB_Poliklinik)
            '    If Tbls.Rows.Count > 0 Then
            '        PoliKlinik.Visible = True
            '        PoliKlinik.Lbluser.Text = UsernameTextBox.Text
            '        PoliKlinik.UserAccess("" & Utility.GetConfig("JenisUser").ToString.ToUpper & "")
            '        TStatus = "NEXT"
            '        Me.Close()
            '    Else
            '        MsgBox("Username dan Password anda salah. Check kembali.")
            '    End If
        ElseIf Utility.GetConfig("JenisUser").ToString.ToUpper = "KEU" Then
            If CheckLoginKeuangan() = True Then
                PoliKlinik.Visible = True
                PoliKlinik.Lbluser.Text = UsernameTextBox.Text
                PoliKlinik.UserAccess("" & Utility.GetConfig("JenisUser").ToString.ToUpper & "")
                PoliKlinik.KeuanganToolStripMenuItem1.Visible = True
                Me.Close()
            End If
            'ElseIf Utility.GetConfig("JenisUser").ToString.ToUpper = "POLIOL" Then
            '    Dim Tbls As DataTable = ReadThemysql("SELECT * FROM users where username='" & UsernameTextBox.Text & "' and password='" & PasswordTextBox.Text & "'", DB_Poliklinik)
            '    If Tbls.Rows.Count > 0 Then
            '        Dim Tnrow As DataRow = Tbls.Rows(0)
            '        PoliKlinik.Visible = True
            '        PoliKlinik.Lbluser.Text = UsernameTextBox.Text
            '        PoliKlinik.UserAccess("POLIOL")
            '        PoliKlinik.txcompid.Text = Tnrow("Company").ToString.Trim
            '        Me.Close()
            '    Else
            '        MsgBox("Username dan Password anda salah. Check kembali.")
            '    End If
        ElseIf Utility.GetConfig("JenisUser").ToString.ToUpper = "LOCAL" Then
            If Test.CheckSQL("select * from users where userid='" & UsernameTextBox.Text & "'") = True Then
                If Test.CheckSQL("select * from users where userid='" & UsernameTextBox.Text & "' and userlocked=0") = True Then
                    If Test.CheckSQL("select * from users where userid='" & UsernameTextBox.Text & "' and pwdcompare('" & PasswordTextBox.Text & "',[userpassword])=1") = True Then
                        PoliKlinik.txmcu.Text = cmbjenis.Text
                        PoliKlinik.Lbluser.Text = UsernameTextBox.Text
                        PoliKlinik.Visible = True
                        PoliKlinik.UserAccess(ReadSQLNIK("select GroupID from Users where UserID='" & UsernameTextBox.Text & "'"))
                        TStatus = "NEXT"
                        Me.Close()
                    Else
                        If i >= 3 Then
                            WriteSQL("update users set userlocked='1' where userid='" & UsernameTextBox.Text & "'", 4)
                            MsgBox("User Anda Telah ter-blocked. Call Administrator")
                        Else
                            i = i + 1
                            MsgBox("Password anda salah.")
                            PasswordTextBox.Focus()
                        End If
                    End If
                Else
                    MsgBox("User Anda Telah ter-blocked. Call Administrator")
                End If
            Else
                MsgBox("Anda tidak memiliki user di program ini.")
                UsernameTextBox.Focus()
            End If
        End If
    End Sub

    Function CheckLoginKeuangan() As Boolean
        'Dim versiLokal As String = ""
        Dim versiOnline As String = ""

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

        ' Get Version From Online
        versiOnline = ReadThemysqlNIK("SELECT ConfigValue FROM MasterConfig WHERE ConfigName = 'versi_program_omset_keuangan';", DB_Omset)

        ' Cek Username & Password
        If CheckThemysql("SELECT * FROM users WHERE username='" & UsernameTextBox.Text & "' AND password=MD5('" & PasswordTextBox.Text & "')", DB_Poliklinik) = False Then
            MsgBox("Username dan Password anda salah. Check kembali.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        If versiOnline <> versionProgram Then
            MsgBox("Versi program telah dirilis. Hubungi IT untuk melakukan update program.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        Return True
    End Function

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
        PoliKlinik.Close()
    End Sub

    Private Sub LoginHRIS_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
        PoliKlinik.Close()
        Me.Close()
    End Sub

    ' Return True if another instance
    ' of this program is already running.
    Private Function AlreadyRunning() As Boolean
        ' Get our process name.
        Dim my_proc As Process = Process.GetCurrentProcess
        Dim my_name As String = my_proc.ProcessName

        ' Get information about processes with this name.
        Dim procs() As Process = _
            Process.GetProcessesByName(my_name)

        'If Utility.GetConfig("JenisUser").ToString.ToUpper = "LOCAL" Then
        '    'MENGECEK APAKAH ADA MAINTENANCE ATAU TIDAK
        '    Dim Tstatus As String = ReadSQLNIK("select StrValue  from MsConfig where ConfigName='StatusMaintenance'")
        '    If Tstatus = "Yes" Then
        '        PoliKlinik.TimerUpdateProgram.Enabled = False

        '        Shutdown.Interval = 5000
        '        Shutdown.Enabled = True
        '        MsgBox("Program Poliklinik Sedang dalam Maintenance.", MsgBoxStyle.Exclamation, "Warning!")

        '        my_proc.Kill()
        '        Return True
        '    End If
        'End If

        ' If there is only one, it's us.
        If procs.Length = 1 Then Return False

        ' If there is more than one process,
        ' see if one has a StartTime before ours.
        Dim i As Integer
        For i = 0 To procs.Length - 1
            If procs(i).StartTime < my_proc.StartTime Then
                MsgBox("Program Poliklinik Sudah berjalan di sistem.", MsgBoxStyle.Exclamation, "Warning!")
                my_proc.Kill()
                Return True
            End If
        Next i

        Return False
    End Function

    Private Sub SetConnection()
        ' Set Parameter Server Online
        Dim serverOnline_IP As String = Utility.GetConfig("ServerOnline_IP")
        Dim serverOnline_UserID As String = Utility.GetConfig("ServerOnline_UserID")
        Dim serverOnline_Password As String = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerOnline_Password"), "albert")

        ' Set DB Poliklinik
        DB_Poliklinik.Tip = serverOnline_IP
        DB_Poliklinik.Tid = serverOnline_UserID
        DB_Poliklinik.Tpass = serverOnline_Password
        DB_Poliklinik.Tdb = Utility.GetConfig("ServerOnlinePoli_DB")

        ' Set DB Omset (mitramedicare_omset_keuangan)
        DB_Omset.Tip = serverOnline_IP
        DB_Omset.Tid = serverOnline_UserID
        DB_Omset.Tpass = serverOnline_Password
        DB_Omset.Tdb = Utility.GetConfig("ServerOnlineOmset_DB")
    End Sub

    Private Sub LoginHRIS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set Connection
        SetConnection()

        ' See if another instance is already running.
        If AlreadyRunning() Then
            MessageBox.Show( _
                "Terdapat program poliklinik lain yang sedang berjalan. Tutup program tersebut terlebih dahulu atau matikan proses melalui task manager.", _
                "Already Running", _
                MessageBoxButtons.OK, _
                MessageBoxIcon.Exclamation)
            Me.Close()
        End If

        cmbjenis.SelectedIndex = 0
        'UsernameTextBox.ResetText()
        'PasswordTextBox.ResetText()
        'Me.BackgroundImage = Image.FromFile(Application.StartupPath + "\Image\flat-ui-login-form.jpg")
        Me.BackgroundImage = Image.FromFile(Application.StartupPath + "\Image\login.jpg")

        If Utility.GetConfig("DrPK") = "Yes" Then
            LabelVersiProgram.Text = "Cahaya Medika Dr. PK"
            lblalamat.Text = "-"
        ElseIf Utility.GetConfig("Keu") = "Yes" Then
            LabelVersiProgram.Text = "Keuangan MitraMedicare"
            lblalamat.Text = "-"
        ElseIf Utility.GetConfig("mkt") = "Yes" Then
            LabelVersiProgram.Text = "Marketing MitraMedicare"
            lblalamat.Text = "-"
        ElseIf Utility.GetConfig("JPK") = "Yes" Then
            LabelVersiProgram.Text = "JPK Utama"
            lblalamat.Text = "-"
        Else
            'lblapotik.Text = ReadSQLNIK("select StrValue  from MsConfig where ConfigName='NamaCompany'")
            'lblalamat.Text = ReadSQLNIK("select StrValue  from MsConfig where ConfigName='AlamatCompany'") & vbCrLf & ReadSQLNIK("select StrValue  from MsConfig where ConfigName='TelpCompany'")
        End If

        ' Mendapatkan baris pertama pada notepad
        'Using sr As New StreamReader(Application.StartupPath & "\updatelog.txt")
        '    line = sr.ReadLine()
        '    sr.Dispose()
        'End Using

        ' Mengakses informasi versi file dari assembly
        Dim versionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location)
        Dim fileVersion As String = versionInfo.FileVersion

        ' Mengakses deskripsi dari atribut AssemblyDescription
        Dim description As String = String.Empty
        Dim attributes() As Object = Assembly.GetExecutingAssembly().GetCustomAttributes(GetType(AssemblyDescriptionAttribute), False)
        If attributes.Length > 0 Then
            description = DirectCast(attributes(0), AssemblyDescriptionAttribute).Description
        End If

        LabelVersiProgram.Text = "Version : " & fileVersion & vbCrLf & " (" & description & ")"

        i = 0
    End Sub

    Private Sub UsernameTextBox_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles UsernameTextBox.MouseClick
        UsernameTextBox.ResetText()
    End Sub

    Private Sub PasswordTextBox_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PasswordTextBox.MouseClick
        PasswordTextBox.ResetText()
    End Sub

    Private Sub ToolTip1_Popup(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PopupEventArgs) Handles ToolTip1.Popup
        Dim buttonToolTip As New ToolTip()

        buttonToolTip.ToolTipTitle = "Button Tooltip"

        buttonToolTip.UseFading = True

        buttonToolTip.UseAnimation = True

        buttonToolTip.IsBalloon = True

        buttonToolTip.ShowAlways = True

        buttonToolTip.AutoPopDelay = 5000

        buttonToolTip.InitialDelay = 1000

        buttonToolTip.ReshowDelay = 500

        buttonToolTip.IsBalloon = True

        buttonToolTip.SetToolTip(LabelVersiProgram, "Click me to execute.")
    End Sub

    Private Sub Shutdown_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Shutdown.Tick
        ' Get our process name.
        Dim my_proc As Process = Process.GetCurrentProcess
        Dim my_name As String = my_proc.ProcessName

        ' Get information about processes with this name.
        Dim procs() As Process = _
            Process.GetProcessesByName(my_name)

        my_proc.Kill()
    End Sub

    Private Sub LabelVersiProgram_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelVersiProgram.Click
        PatchUpdate.Show()
        PatchUpdate.Focus()
    End Sub
End Class
