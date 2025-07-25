

Public Class SettingIcare

    Inherits System.Windows.Forms.Form
    'Dim WithEvents dev As DpSdkEngLib.FPDevice
    'Dim Template As DpSdkEngLib.FPTemplate
    'Public myDevices As DpSdkEngLib.FPDevices
    Dim ScanOke As Boolean


    Private Sub SetClear()
        butuser.Enabled = True
        butuser.ResetText()
        txusernama.ResetText()
        cmbgudang.ResetText()
        cmbgroupid.ResetText()
        txupdate.ResetText()
        dtupdate.Value = dtupdate.MaxDate
        txcreate.ResetText()
        dtcreate.Value = dtcreate.MaxDate
        TextBoxUsernameIcare.ResetText()
        TextBoxPasswordIcare.ResetText()
    End Sub

    Private Sub SetData()
        InsertNewItemComboSQL("select distinct GroupID from [MsConfigGrpForm]", cmbgroupid)
        InsertNewItemComboSQL("select [StrValue] from [MsConfig] where [ConfigName]='Gudang'", cmbgudang)
    End Sub

    Private Sub ClearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearToolStripMenuItem.Click
        SetClear()
        SetData()
    End Sub

    'Private Sub SettingUser_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
    '    dev = Nothing
    '    ScanOke = False
    'End Sub

    Private Sub SettingUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        SetClear()
        SetData()
    End Sub

    'Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
    '    dev = Nothing
    '    ScanOke = False
    '    Me.Close()
    'End Sub

    Function CheckingData() As Boolean
        If butuser.Text = "" Then
            MsgBox("User ID harus diisi.")
            Return False
        End If

        If txusernama.Text = "" Then
            MsgBox("Nama user harus diisi")
            Return False
        End If

        If cmbgroupid.FindStringExact(cmbgroupid.Text) < 0 Then
            If MsgBox("Apakah Membuat Group baru ?", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then
                MsgBox("Batal membuat group baru. Pilih Group yang sesuai.")
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        If CheckingData() = True Then
            If CheckSQL("select * from [Users] where UserID='" & butuser.Text & "'") = True Then
                'update 
                If MsgBox("User yang telah ada. Update ? ", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                    WriteSQL("update [Users]  set [GroupID]='" & cmbgroupid.Text & "',[UsernameIcare]='" & TextBoxUsernameIcare.Text & "',[PasswordIcare]='" & TextBoxPasswordIcare.Text & "',[UpdateBy]='" & PoliKlinik.Lbluser.Text & "',[UpdateDate]='" & Format(DateAndTime.Now, "MM/dd/yyyy") & "' , Gudang='" & cmbgudang.Text & "'" & _
                             "where [UserID]='" & butuser.Text & "'", 2)
                Else
                    MsgBox("Cancel")
                End If
            Else
                'new
                WriteSQL("insert into [Users] ([UserID],[GroupID],[UsernameIcare],[PasswordIcare],[CreateBy],[CreateDate],[Gudang]) " & _
                         "values('" & butuser.Text & "','" & cmbgroupid.Text & "','" & TextBoxUsernameIcare.Text & "','" & TextBoxPasswordIcare.Text & "','" & PoliKlinik.Lbluser.Text & "','" & Format(DateAndTime.Now, "MM/dd/yyyy") & "','" & cmbgudang.Text & "')", 1)
            End If
            ClearToolStripMenuItem.PerformClick()
        End If

    End Sub

    Public Sub LoadUser(ByRef Txid As String)
        butuser.Enabled = False
        Dim Tbls As DataTable = ReadSQL("select * from [Users] where UserId='" & Txid & "'")
        Dim Trow As DataRow = Tbls.Rows(0)
        butuser.Text = Txid
        txusernama.Text = Trow("UserNama").ToString
        cmbgroupid.Text = Trow("GroupID").ToString
        cmbgudang.Text = Trow("Gudang").ToString
        txcreate.Text = Trow("CreateBy").ToString
        If IsDBNull(Trow("CreateDate")) = False Then dtcreate.Value = Trow("CreateDate")
        txupdate.Text = Trow("UpdateBy").ToString
        If IsDBNull(Trow("UpdateDate")) = False Then dtcreate.Value = Trow("UpdateDate")
        TextBoxUsernameIcare.Text = Trow("UsernameIcare").ToString
        TextBoxPasswordIcare.Text = Trow("PasswordIcare").ToString
    End Sub


    Private Sub butuser_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles butuser.KeyUp
        If e.KeyCode = Keys.Enter Then
            If CheckSQL("select * from [Users] where [UserID]='" & butuser.Text & "' ") = True Then
                LoadUser(butuser.Text)
            Else
                txusernama.ResetText()
                cmbgroupid.ResetText()
                txupdate.ResetText()
                dtupdate.Value = dtupdate.MaxDate
                txcreate.ResetText()
                dtcreate.Value = dtcreate.MaxDate
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If CheckSQL("select * from [Users] where UserID='" & butuser.Text & "' and UserLocked=1") = True Then
            If MsgBox("Unlocked User ? ", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                WriteSQL("Update [Users] set UserLocked=0 where UserID='" & butuser.Text & "' and UserLocked=1", 2)
            End If
        End If
    End Sub

    'Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    '    Dim x As Object
    '    myDevices = New DpSdkEngLib.FPDevices

    '    If myDevices.Count = 0 Then
    '        MsgBox("FingerPrint Tidak Ditemukan !!!")
    '        End
    '    Else
    '        For Each x In myDevices
    '            dev = x
    '        Next x

    '        dev.SubScribe(DpSdkEngLib.AIDevPriorities.Dp_StdPriority, Me.Handle.ToInt32)
    '        Sta.Text = "Letakan Jari Anda Pada FingerPrint"
    '    End If
    'End Sub

    'Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
    '    dev = Nothing
    '    ScanOke = False
    'End Sub

    'Private Sub dev_FingerLeaving() Handles dev.FingerLeaving
    '    Sta.Text = "Letakan Jari Anda Pada FingerPrint"
    'End Sub

    'Private Sub dev_FingerTouching() Handles dev.FingerTouching
    '    Sta.Text = "Sidik Jari di-Process"
    'End Sub

    'Private Sub dev_SampleAcquired(ByVal pRawSample As Object) Handles dev.SampleAcquired

    '    Dim smpPro As DpSdkEngLib.FPRawSamplePro
    '    Dim ftrex As DpSdkEngLib.FPFtrEx
    '    Dim qt As DpSdkEngLib.AISampleQuality
    '    'UPGRADE_NOTE: Sample was upgraded to Sample_Renamed. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    '    Dim Sample_Renamed As New DpSdkEngLib.FPSample
    '    If ScanOke = False Then

    '        smpPro = New DpSdkEngLib.FPRawSamplePro
    '        smpPro.Convert(pRawSample, Sample_Renamed)

    '        ftrex = New DpSdkEngLib.FPFtrEx
    '        ftrex.Process(Sample_Renamed, DpSdkEngLib.AITemplateTypes.Tt_PreRegistration, Template, qt)
    '        If qt = 0 Then

    '            Sample_Renamed.PictureOrientation = DpSdkEngLib.AIOrientation.Or_Landscape
    '            'Sample_Renamed.PictureWidth = TwipsToPixelsx(Picture1.Width)
    '            'Sample_Renamed.PictureHeight = TwipsToPixelsy(Picture1.Height)

    '            Dim register As DpSdkEngLib.FPRegister
    '            register = New DpSdkEngLib.FPRegister
    '            register.NewRegistration(DpSdkEngLib.AIRegTargets.Rt_Verify)

    '            Dim regTemplate As DpSdkEngLib.FPTemplate
    '            regTemplate = register.RegistrationTemplate

    '            Dim blob As New Object
    '            Dim blobarray() As Byte

    '            regTemplate.Export(blob)
    '            'UPGRADE_WARNING: Couldn't resolve default property of object blob. Click for more: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="6A50421D-15FE-4896-8A1B-2EC21E9037B2"'
    '            blobarray = blob
    '            If MsgBox("Save data finger print ?", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
    '                WriteSQL("update [Users]  set FPId='" & arraytohex(blobarray) & "' where [UserID]='" & butuser.Text & "'", 4)
    '                ScanOke = True
    '            End If

    '            Picture1.Image = Sample_Renamed.Picture
    '            MsgBox("Scan berhasil")
    '        Else
    '            MsgBox("Ulang Scan jari")
    '        End If
    '    End If
    'End Sub

    Private Function TwipsToPixelsy(ByVal intPixels As Integer) As Integer
        Dim pixles As Integer = 0
        Dim g As Graphics = Me.CreateGraphics()
        pixles = intPixels * g.DpiY / 1440
        g.Dispose()
        Return pixles
    End Function

    Private Function TwipsToPixelsx(ByVal intPixels As Integer) As Integer
        Dim pixles As Integer = 0
        Dim g As Graphics = Me.CreateGraphics()
        pixles = intPixels * g.DpiX / 1440
        g.Dispose()
        Return pixles
    End Function

    Private Sub butfinduser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butfinduser.Click
        Find.Show()
        Find.Query("select [UserID],[GroupID],[UserNama],[UserLocked] from [Users] where ( dataoff<>1 or dataoff is null )", " order by [GroupID],[UserID]", "FindUserIcare", 1)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FindMultiple.Show()
        FindMultiple.Query("select NoID,UserID,GroupID,UserNama  from Users where ( dataoff<>1 or dataoff is null )", " order by GroupID,UserID ", "OFFUSER", 3)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FindMultiple.Show()
        FindMultiple.Query("select NoID,UserID,GroupID,UserNama  from Users where dataoff=1", " order by GroupID,UserID ", "ONUSER", 3)
    End Sub

    Public Sub OFFUSER(ByRef Trow() As DataRow)

        For i As Integer = 0 To Trow.Length - 1
            WriteSQL("update Users set DATAOFF=1 where NoID='" & Trow(i)("NoID").ToString & "'", 4)
        Next
        MsgBox("Data Saved")
    End Sub

    Public Sub ONUSER(ByRef Trow() As DataRow)

        For i As Integer = 0 To Trow.Length - 1
            WriteSQL("update Users set DATAOFF=0 where NoID='" & Trow(i)("NoID").ToString & "'", 4)
        Next
        MsgBox("Data Saved")
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class