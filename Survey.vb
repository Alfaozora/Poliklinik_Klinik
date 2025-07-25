Public Class Survey

    Dim Ttcon As TLcon
    Dim Texpresi As Integer = 0
    Dim Tnama As String = ""
    Dim Tnomitra As String = ""
    Dim timer As Integer = 0
    Dim tstate As String = ""
    'Dim proc As System.Diagnostics.Process = Nothing

    Public Sub SetFirst()
        If CheckSQL("select * from msconfig where configname='IklainAktif' and StrValue='nonaktif'") = True Then
            picgif1.Visible = False
        Else
            picgif1.Visible = True
        End If

        lbldetail.Text = "Silahkan anda memberikan penilaian terhadap pelayanan kami"

        txjenis.ResetText()
        txnotransaksi.ResetText()
        Tnama = ""

        lbldetail.Visible = True
        lbl1.Visible = True
        lbl2.Visible = True
        lbl3.Visible = True

        pic1.Visible = True
        pic2.Visible = True
        pic3.Visible = True
        TextBox1.Visible = False
        butsave.Visible = False

    End Sub

    Public Sub SetText()
        lbldetail.Visible = False
        lbl1.Visible = False
        lbl2.Visible = False
        lbl3.Visible = False

        pic1.Visible = False
        pic2.Visible = False
        pic3.Visible = False

        TextBox1.Visible = True
        TextBox1.ResetText()
        TextBox1.BringToFront()
        TextBox1.Focus()
        butsave.Visible = True
        butsave.BringToFront()

        'proc = System.Diagnostics.Process.Start("osk.exe")

    End Sub

    Private Sub SetData()
        Ttcon = New TLcon
        Ttcon.Tid = "root"
        Ttcon.Tip = ReadSQLNIK("select StrValue from MsConfig where ConfigName='Twebid'")
        Ttcon.Tdb = "mitramed_survey"
        Ttcon.Tpass = Strings.Replace(ReadSQLNIK("select StrValue from MsConfig where ConfigName='Twebpass'"), "|", "")

        Me.BackgroundImage = Image.FromFile(Application.StartupPath + "\Image\wallpaper.jpg")
        pic1.Image = Image.FromFile(Application.StartupPath + "\Image\sad_to_happy.gif")
        pic2.Image = Image.FromFile(Application.StartupPath + "\Image\nurse_eyes.gif")
        pic3.Image = Image.FromFile(Application.StartupPath + "\Image\smile_to_cry.gif")
        picgif1.Image = Image.FromFile(Application.StartupPath + "\Image\Gifcmh.gif")
        picgif1.Dock = DockStyle.Fill
        picgif1.Hide()
    End Sub

    Public Sub SetNama(ByRef Txnama As String, ByRef TJenis As String, ByRef Tnotrans As String, ByRef Txnomitra As String, ByRef state As String)
        SetFirst()
        picgif1.Visible = False
        lbldetail.Text = "Bpk/Ibu/Sdr. " & Txnama & ", Silahkan memberikan penilaian terhadap pelayanan kami"
        txjenis.Text = TJenis
        txnotransaksi.Text = Tnotrans
        Tnama = Txnama
        Tnomitra = Txnomitra
        Tstate = state
    End Sub

    Private Sub Survey_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetFirst()
        SetData()
        timer = 0
        Timer1.Start()
    End Sub

    Private Sub pic1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pic1.Click
        'If MsgBox("Apakah Bpk/Ibu/Sdr. " & Tnama & " ingin memberikan komentar tertulis ?", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
        Texpresi = 1
        Dim user As String = PoliKlinik.Lbluser.Text()
        'SetText()
        'Else
        WriteThemysql("insert into tr_survey (id_ekspresi,sarankritik,createdby,createddate,JenisPasien,NoTransaksi,nomitra) " & _
                      "values('1','" & TextBox1.Text & "','" & user & "',now(),'" & txjenis.Text & "','" & txnotransaksi.Text & "','" & Tnomitra & "')", Ttcon)
        'MsgBox("Terima kasih atas saran anda.")
        SetFirst()
        Me.Close()
        If tstate = "PAY" Then
            FormPembayaran.Close()
        End If

        Dim OpenCMD
        OpenCMD = CreateObject("wscript.shell")
        OpenCMD.run("DisplaySwitch.exe /internal")
        'End If
    End Sub

    Private Sub pic2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pic2.Click
        'If MsgBox("Apakah Bpk/Ibu/Sdr. " & Tnama & " ingin memberikan komentar tertulis ?", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
        Texpresi = 2
        Dim user As String = PoliKlinik.Lbluser.Text()
        'SetText()
        'Else
        WriteThemysql("insert into tr_survey (id_ekspresi,sarankritik,createdby,createddate,JenisPasien,NoTransaksi,nomitra) " & _
                      "values('2','" & TextBox1.Text & "','" & user & "',now(),'" & txjenis.Text & "','" & txnotransaksi.Text & "','" & Tnomitra & "')", Ttcon)
        'MsgBox("Terima kasih atas saran anda.")
        SetFirst()
        Me.Close()
        If tstate = "PAY" Then
            FormPembayaran.Close()
        End If
        Dim OpenCMD
        OpenCMD = CreateObject("wscript.shell")
        OpenCMD.run("DisplaySwitch.exe /internal")
        'End If
    End Sub

    Private Sub pic3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pic3.Click
        'If MsgBox("Apakah Bpk/Ibu/Sdr. " & Tnama & " ingin memberikan komentar tertulis ?", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
        Texpresi = 3
        Dim user As String = PoliKlinik.Lbluser.Text()
        'SetFirst()
        'SetText()
        'Else
        WriteThemysql("insert into tr_survey (id_ekspresi,sarankritik,createdby,createddate,JenisPasien,NoTransaksi,nomitra) " & _
                      "values('3','" & TextBox1.Text & "','" & user & "',now(),'" & txjenis.Text & "','" & txnotransaksi.Text & "','" & Tnomitra & "')", Ttcon)
        'MsgBox("Terima kasih atas saran anda.")
        SetFirst()
        Me.Close()
        If tstate = "PAY" Then
            FormPembayaran.Close()
        End If
        Dim OpenCMD
        OpenCMD = CreateObject("wscript.shell")
        OpenCMD.run("DisplaySwitch.exe /internal")
        'End If
    End Sub

    Private Sub butsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butsave.Click
        Dim user As String = PoliKlinik.Lbluser.Text()
        WriteThemysql("insert into tr_survey (id_ekspresi,sarankritik,createdby,createddate,JenisPasien,NoTransaksi,nomitra) " & _
                         "values('" & Texpresi & "','" & TextBox1.Text & "','" & user & "',now(),'" & txjenis.Text & "','" & txnotransaksi.Text & "','" & Tnomitra & "')", Ttcon)
        'MsgBox("Terima kasih atas saran anda.")
        Texpresi = 0
        SetFirst()
        Me.Close()
    End Sub

    Private Sub lbl3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl3.Click

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub lbl2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl2.Click

    End Sub

    Private Sub lbl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbl1.Click

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        timer += 1
        If timer > 10 Then
            Timer1.Stop()
            Texpresi = 2
            Dim user As String = PoliKlinik.Lbluser.Text()
            'SetText()
            'Else
            WriteThemysql("insert into tr_survey (id_ekspresi,sarankritik,createdby,createddate,JenisPasien,NoTransaksi,nomitra) " & _
                          "values('2','" & TextBox1.Text & "','" & user & "',now(),'" & txjenis.Text & "','" & txnotransaksi.Text & "','" & Tnomitra & "')", Ttcon)
            'MsgBox("Terima kasih atas saran anda.")
            SetFirst()
            Me.Close()
            FormPembayaran.ButtonCancel.Enabled = True
            FormPembayaran.ButtonSimpan.Enabled = True
            FormPembayaran.ButtonCancel.Enabled = False
            FormPembayaran.Close()
            Dim OpenCMD
            OpenCMD = CreateObject("wscript.shell")
            OpenCMD.run("DisplaySwitch.exe /internal")
        End If
    End Sub
End Class