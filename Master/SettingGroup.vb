Public Class SettingGroup

    Private Sub SetClear()
        cmbgroupid.ResetText()
        dtcreate.Value = DateAndTime.Now
        dtupdate.Value = DateAndTime.Now
        txcreate.ResetText()
        txupdate.ResetText()
    End Sub

    Private Sub SetData()
        'InsertNewItemComboSQL("select [StrValue] from [MsConfig] where ConfigName='GroupID'", cmbgroupid)
        InsertNewItemComboSQL("select distinct GroupID from [MsConfigGrpForm]", cmbgroupid)
    End Sub

    Private Sub ClearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearToolStripMenuItem.Click
        SetClear()
        SetData()
        LoadData("")
    End Sub

    Private Sub SettingGroup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        SetClear()
        SetData()
    End Sub

    Private Sub LoadData(ByRef Tid As String)
        'Dim Tbls As DataTable = ReadSQL("select a.FormID,a.FormNama from MsConfigForm a left join MsConfigGrpForm b on a.FormID =b.FormID where GroupID='" & cmbgroupid.Text & "' order by a.FormID ")
        Dim Tbls As DataTable = ReadSQL("select a.FormID,a.FormNama from MsConfigForm a order by a.FormID ")
        insertRowToTbls(Tbls, "typchecked", "CanSee")
        'insertRowToTbls(Tbls, "typchecked", "CanSave")
        'insertRowToTbls(Tbls, "typchecked", "CanDelete")

        For Each Trow As DataRow In Tbls.Rows
            If CheckSQL("select * from MsConfigGrpForm where GroupID='" & Tid & "' and FormID='" & Trow("FormId") & "' and isnull(CanSee,0)=1") = True Then Trow("CanSee") = True
            'If CheckSQL("select * from MsConfigGrpForm where GroupID='" & Tid & "' and FormID='" & Trow("FormId") & "' and isnull(CanSave,0)=1") = True Then Trow("CanSave") = True
            'If CheckSQL("select * from MsConfigGrpForm where GroupID='" & Tid & "' and FormID='" & Trow("FormId") & "' and isnull(CanDelete,0)=1") = True Then Trow("CanDelete") = True
        Next
        Tbls.Columns("FormNama").ReadOnly = True
        GridControl1.DataSource = Tbls
        'GridView1.Columns(0).Visible = False
    End Sub

    Private Sub cmbgroupid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbgroupid.KeyUp
        If e.KeyCode = Keys.Enter Then
            If cmbgroupid.FindStringExact(cmbgroupid.Text) >= 0 Then
                LoadData(cmbgroupid.Text)
            Else
                cmbgroupid.ResetText()
                GridControl1.DataSource = Nothing
            End If
        End If
    End Sub

    Private Sub cmbgroupid_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbgroupid.SelectedIndexChanged
        If cmbgroupid.FindStringExact(cmbgroupid.Text) >= 0 Then
            LoadData(cmbgroupid.Text)
        Else
            cmbgroupid.ResetText()
            GridControl1.DataSource = Nothing
        End If
    End Sub

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        Dim Tbls As DataTable = GridControl1.DataSource
        Tbls.AcceptChanges()

        Try
            For Each Trow As DataRow In Tbls.Rows
                If CheckSQL("select * from MsConfigGrpForm where FormID='" & Trow("FormID") & "' and GroupID='" & cmbgroupid.Text & "'") = True Then
                    'WriteSQL("update MsConfigGrpForm set CanSee='" & Trow("CanSee") & "' , CanSave='" & Trow("CanSave") & "' ,  CanDelete='" & Trow("CanDelete") & "' , UpdateDate='" & Format(DateAndTime.Now, "MM/dd/yyyy") & "' , UpdateBy='" & PoliKlinik.lbluser.Text & "' where FormID='" & Trow("FormID") & "' and GroupID='" & cmbgroupid.Text & "'", 4)
                    WriteSQL("update MsConfigGrpForm set CanSee='" & Trow("CanSee") & "' , UpdateDate='" & Format(DateAndTime.Now, "MM/dd/yyyy") & "' , UpdateBy='" & PoliKlinik.Lbluser.Text & "' where FormID='" & Trow("FormID") & "' and GroupID='" & cmbgroupid.Text & "'", 4)
                Else
                    'WriteSQL("insert into MsConfigGrpForm (FormID,GroupID,CanSee,CanSave,CanDelete,CreateDate,CreateBy) values('" & Trow("FormID") & "','" & cmbgroupid.Text & "','" & Trow("CanSee") & "','" & Trow("CanSave") & "','" & Trow("CanDelete") & "','" & Format(DateAndTime.Now, "MM/dd/yyyy") & "','" & PoliKlinik.lbluser.Text & "')", 4)
                    WriteSQL("insert into MsConfigGrpForm (FormID,GroupID,CanSee,CreateDate,CreateBy) values('" & Trow("FormID") & "','" & cmbgroupid.Text & "','" & Trow("CanSee") & "','" & Format(DateAndTime.Now, "MM/dd/yyyy") & "','" & PoliKlinik.Lbluser.Text & "')", 4)
                End If
            Next
            MsgBox("Saved")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub
End Class