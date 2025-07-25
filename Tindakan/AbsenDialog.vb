Public Class AbsenDialog

    Public Twaker As Integer = 0
    Public FingerCheck As Boolean = False

    Public Sub SetClear()
        txdokterkode.ResetText()
        txdokterjenis.ResetText()
        txdokternama.ResetText()
    End Sub

    Public Sub ResetUser()
        txpassword.ResetText()
        txuser.ResetText()
    End Sub

    Public Sub HidePass()
        lblpassword.Visible = False
        lbluser.Visible = False
        txpassword.Visible = False
        txuser.Visible = False
    End Sub

    Public Sub UnHidePass()
        lblpassword.Visible = True
        lbluser.Visible = True
        txpassword.Visible = True
        txuser.Visible = True
    End Sub

    Public Sub HideFinger()
        lblfinger.Visible = False
    End Sub

    Public Sub UnhideFinger()
        lblfinger.Text = "Waiting."
        lblfinger.Visible = True
        FingerCheck = True
        Twaker = 0
        Button1.Enabled = False
        Button2.Enabled = False
        butok.Enabled = False
    End Sub

    Private Sub AbsenDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetClear()
        ResetUser()
        HidePass()
        Timer1.Enabled = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ResetUser()
        UnHidePass()
        HideFinger()
        txuser.Focus()
    End Sub

    Private Sub LoadDokter(ByRef Txid As String)
        Dim Tbls As DataTable = ReadSQL("select * from MasterDokter where DrCode in ( select UserId from Users where NoID='" & Txid & "')")
        Dim Trow As DataRow = Tbls.Rows(0)
        txdokterkode.Text = Trow("DrCode").ToString
        txdokterjenis.Text = Trow("DrJenis").ToString
        txdokternama.Text = Trow("DrNama").ToString
        'foto load belum ready
        'picfoto.Load("")
    End Sub

    Private Sub txuser_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txuser.KeyUp
        If e.KeyCode = Keys.Enter Then
            txpassword.Focus()
        End If
    End Sub

    Private Sub txuser_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txuser.TextChanged
        If CheckSQL("select * from Users where UserID in ( select distinct DrCode  from MasterDokter ) and NoID='" & txuser.Text & "' ") = True Then
            LoadDokter(txuser.Text)
        Else
            SetClear()
        End If
    End Sub


    Function Checking() As Boolean
        If CheckSQL("select * from Users where NoID='" & txuser.Text & "'") = False Then
            MsgBox("User anda tidak dikenali. Insert users yang sesuai")
            Return False
        ElseIf CheckSQL("select * from Users where NoID='" & txuser.Text & "' and PWDCOMPARE('" & txpassword.Text & "',userpassword)=1 ") = False Then
            MsgBox("Password anda tidak salah. Insert Password yang sesuai")
            Return False
        ElseIf CheckSQL("select * from Users where NoID='" & txuser.Text & "' and PWDCOMPARE('" & txpassword.Text & "',userpassword)=1 ") = True Then
            'continue 
        End If

        Return True
    End Function

    Private Sub butok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butok.Click
        If Checking() = False Then
            txpassword.Focus()
        Else
            If CheckSQL("select * from Users where UserID in ( select distinct DrCode  from MasterDokter ) and NoID='" & txuser.Text & "' and PWDCOMPARE('" & txpassword.Text & "',userpassword)=1 ") = True Then
                If txjenis.Text = "IN" Then
                    If CheckSQL("select * from DokterAktif where DrCode='" & txdokterkode.Text & "' and Tanggal='" & Format(DateAndTime.Now, "MM/dd/yyyy") & "'") = True Then
                        MsgBox("Telah ada absen datang anda")
                        Exit Sub
                    Else
                        WriteSQL("insert into DokterAktif ([DrCode],[DrNama],[DrJenis],[RuangID],[Tanggal],[JamMasuk]) values('" & txdokterkode.Text & "','" & txdokternama.Text & "','" & txdokterjenis.Text & "','-','" & Format(DateAndTime.Now, "MM/dd/yyyy") & "',getdate())", 4)
                        MsgBox("Jam IN disimpan")
                        SetClear()
                        Me.Close()
                    End If
                ElseIf txjenis.Text = "OUT" Then
                    If CheckSQL("select * from DokterAktif where DrCode='" & txdokterkode.Text & "' and Tanggal='" & Format(DateAndTime.Now, "MM/dd/yyyy") & "'") = True Then
                        WriteSQL("update DokterAktif set [JamKeluar]=getdate() where  [DrCode]='" & txdokterkode.Text & "' and [Tanggal]='" & Format(DateAndTime.Now, "MM/dd/yyyy") & "'", 4)
                        MsgBox("Jam OUT disimpan")
                        SetClear()
                        Me.Close()
                    Else
                        WriteSQL("insert into DokterAktif ([DrCode],[DrNama],[DrJenis],[RuangID],[Tanggal],[JamKeluar]) values('" & txdokterkode.Text & "','" & txdokternama.Text & "','" & txdokterjenis.Text & "','-','" & Format(DateAndTime.Now, "MM/dd/yyyy") & "',getdate())", 4)
                        MsgBox("Jam OUT disimpan. Tetapi Tanpa Jam Datang.")
                        SetClear()
                        Me.Close()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        UnhideFinger()
        ResetUser()
        HidePass()

    End Sub

    Function CheckFinger() As Boolean
        'fungsi check finger dari mesin finger 
        ' if ok timer1.enabled =false  data ok di-save

        Return False
    End Function

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        dttime.Value = DateAndTime.Now
        If FingerCheck = True Then
            If Twaker > 5 Then
                Twaker = 0
                MsgBox("Fingered Canceled. Klik Ulang Menu Finger")
                Button1.Enabled = True
                Button2.Enabled = True
                butok.Enabled = True
                FingerCheck = False
                HideFinger()
            Else
                If CheckFinger() = False Then
                    Twaker = Twaker + 1
                    lblfinger.Text = lblfinger.Text + "."
                End If
            End If
        End If
    End Sub

    Private Sub txpassword_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txpassword.KeyUp
        If e.KeyCode = Keys.Enter Then
            If Checking() = False Then
                txuser.Focus()
            Else
                butok.PerformClick()
            End If
        End If
    End Sub

    Private Sub txpassword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txpassword.TextChanged

    End Sub
End Class