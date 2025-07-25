Public Class PendaftaranAwal

    Private Sub PendaftaranAwal_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            If MsgBox("Clear No Urut ? ", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                Dim Tawal As String = Format(DateAndTime.Now.AddDays(-1), "MM/dd/yyyy") + " 23:59:59"
                Dim Takhir As String = Format(DateAndTime.Now.AddDays(1), "MM/dd/yyyy") + " 00:00:01"
                WriteSQL("delete from Pendaftaran where tanggal<'" & Tawal & "' or tanggal>'" & Takhir & "'", 4)
                MsgBox("Clear")
                Setdata()
            End If
        End If
    End Sub

    Private Sub PendaftaranAwal_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.F5 Then
            If MsgBox("Clear No Urut ? ", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                Dim Tawal As String = Format(DateAndTime.Now.AddDays(-1), "MM/dd/yyyy") + " 23:59:59"
                Dim Takhir As String = Format(DateAndTime.Now.AddDays(1), "MM/dd/yyyy") + " 00:00:01"
                WriteSQL("delete from Pendaftaran where tanggal<'" & Tawal & "' or tanggal>'" & Takhir & "'", 4)
                MsgBox("Clear")
                Setdata()
            End If
        End If
    End Sub

    Private Sub Setdata()
        txumum.Text = ReadSQLNIK("select isnull(max(nourut)+1,1) from [Pendaftaran] where day([Tanggal])='" & DateAndTime.Now.Day & "' and month([Tanggal])='" & DateAndTime.Now.Month & "' and year([Tanggal])=" & DateAndTime.Now.Year & " and Jenis='UMUM'")
        txspesialis.Text = ReadSQLNIK("select isnull(max(nourut)+1,1) from [Pendaftaran] where day([Tanggal])='" & DateAndTime.Now.Day & "' and month([Tanggal])='" & DateAndTime.Now.Month & "' and year([Tanggal])=" & DateAndTime.Now.Year & " and Jenis='SPESIAL'")
        txlab.Text = ReadSQLNIK("select isnull(max(nourut)+1,1) from [Pendaftaran] where day([Tanggal])='" & DateAndTime.Now.Day & "' and month([Tanggal])='" & DateAndTime.Now.Month & "' and year([Tanggal])=" & DateAndTime.Now.Year & " and Jenis='LAB'")
        txugd.Text = ReadSQLNIK("select isnull(max(nourut)+1,1) from [Pendaftaran] where day([Tanggal])='" & DateAndTime.Now.Day & "' and month([Tanggal])='" & DateAndTime.Now.Month & "' and year([Tanggal])=" & DateAndTime.Now.Year & " and Jenis='UGD'")
    End Sub

    Private Sub PendaftaranAwal_Layout(ByVal sender As Object, ByVal e As System.Windows.Forms.LayoutEventArgs) Handles Me.Layout

    End Sub

    Private Sub PendaftaranAwal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MaximizeBox = True
        Setdata()
    End Sub

    Private Sub butumum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butumum.Click
        Report = New XtraReport
        Report = XtraReport.FromFile(Application.StartupPath + "\reports\KitirDaftar.repx", True)
        WriteSQL("insert into Pendaftaran ([NoUrut],[Jenis],[Tanggal]) values('" & txumum.Text & "','UMUM',getdate())", 4)
        Dim Tbls As DataTable = ReadSQL("select * from Pendaftaran where Jenis='UMUM' and nourut='" & txumum.Text & "' ")
        MsgBox("UMUM - " & txumum.Text)
        txumum.Text = CInt(txumum.Text) + 1
        Report.DataSource = Tbls
        'Report.RunDesigner()
        'Report.ShowPreview()

    End Sub

    Private Sub but_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butlab.Click
        Report = New XtraReport
        Report = XtraReport.FromFile(Application.StartupPath + "\reports\KitirDaftar.repx", True)
        WriteSQL("insert into Pendaftaran ([NoUrut],[Jenis],[Tanggal])  values('" & txlab.Text & "','LAB',getdate())", 4)
        Dim Tbls As DataTable = ReadSQL("select * from Pendaftaran where Jenis='LAB' and nourut='" & txlab.Text & "' ")
        MsgBox("LAB - " & txlab.Text)
        txlab.Text = CInt(txlab.Text) + 1
        Report.DataSource = Tbls
        'Report.RunDesigner()
        'Report.ShowPreview()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butugd.Click
        Report = New XtraReport
        Report = XtraReport.FromFile(Application.StartupPath + "\reports\KitirDaftar.repx", True)
        WriteSQL("insert into Pendaftaran ([NoUrut],[Jenis],[Tanggal])  values('" & txugd.Text & "','UGD',getdate())", 4)
        Dim Tbls As DataTable = ReadSQL("select * from Pendaftaran where Jenis='UGD' and nourut='" & txugd.Text & "' ")
        MsgBox("UGD - " & txugd.Text)
        txugd.Text = CInt(txugd.Text) + 1
        Report.DataSource = Tbls
        'Report.RunDesigner()
        'Report.ShowPreview()
    End Sub

    Private Sub butumum_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles butumum.KeyUp
        If e.KeyCode = Keys.F5 Then
            If MsgBox("Clear No Urut ? ", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                Dim Tawal As String = Format(DateAndTime.Now.AddDays(-1), "MM/dd/yyyy") + " 23:59:59"
                Dim Takhir As String = Format(DateAndTime.Now.AddDays(1), "MM/dd/yyyy") + " 00:00:01"
                WriteSQL("delete from Pendaftaran where tanggal<'" & Tawal & "' or tanggal>'" & Takhir & "'", 4)
                MsgBox("Clear")
                Setdata()
            End If
        End If
    End Sub

    'Private Sub butspesialis_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
    '    If e.KeyCode = Keys.F5 Then
    '        If MsgBox("Clear No Urut ? ", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
    '            Dim Tawal As String = Format(DateAndTime.Now.AddDays(-1), "MM/dd/yyyy") + " 23:59:59"
    '            Dim Takhir As String = Format(DateAndTime.Now.AddDays(1), "MM/dd/yyyy") + " 00:00:01"
    '            WriteSQL("delete from Pendaftaran where tanggal<'" & Tawal & "' or tanggal>'" & Takhir & "'", 4)
    '            MsgBox("Clear")
    '            Setdata()
    '        End If
    '    End If
    'End Sub

    'Private Sub butspesialis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Report = New XtraReport
    '    Report = XtraReport.FromFile(Application.StartupPath + "\reports\KitirDaftar.repx", True)
    '    WriteSQL("insert into Pendaftaran ([NoUrut],[Jenis],[Tanggal])  values('" & txspesialis.Text & "','SPESIAL',getdate())", 4)
    '    Dim Tbls As DataTable = ReadSQL("select * from Pendaftaran where Jenis='SPESIAL' and nourut='" & txspesialis.Text & "' ")
    '    txspesialis.Text = CInt(txspesialis.Text) + 1
    '    Report.DataSource = Tbls
    '    'Report.RunDesigner()
    '    Report.ShowPreview()
    'End Sub

    Private Sub butlab_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles butlab.KeyUp
        If e.KeyCode = Keys.F5 Then
            If MsgBox("Clear No Urut ? ", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                Dim Tawal As String = Format(DateAndTime.Now.AddDays(-1), "MM/dd/yyyy") + " 23:59:59"
                Dim Takhir As String = Format(DateAndTime.Now.AddDays(1), "MM/dd/yyyy") + " 00:00:01"
                WriteSQL("delete from Pendaftaran where tanggal<'" & Tawal & "' or tanggal>'" & Takhir & "'", 4)
                MsgBox("Clear")
                Setdata()
            End If
        End If
    End Sub

    Private Sub butugd_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles butugd.KeyUp
        If e.KeyCode = Keys.F5 Then
            If MsgBox("Clear No Urut ? ", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                Dim Tawal As String = Format(DateAndTime.Now.AddDays(-1), "MM/dd/yyyy") + " 23:59:59"
                Dim Takhir As String = Format(DateAndTime.Now.AddDays(1), "MM/dd/yyyy") + " 00:00:01"
                WriteSQL("delete from Pendaftaran where tanggal<'" & Tawal & "' or tanggal>'" & Takhir & "'", 4)
                MsgBox("Clear")
                Setdata()
            End If
        End If
    End Sub
End Class