Public Class Msconfig

    Private Sub SetClear()
        cmbid.ResetText()
        cmbid.Enabled = False
        cmbtype.ResetText()
        InsertNewItemComboSQL("select distinct ConfigName from MsConfig", cmbname)

        txstr.ResetText()
        txint.ResetText()
        txfloat.ResetText()
        dtdate.Value = DateAndTime.Now

        chkstr.Checked = False
        chkint.Checked = False
        chkfloat.Checked = False
        chkdate.Checked = False

        txstr.Enabled = False
        txint.Enabled = False
        txfloat.Enabled = False
        dtdate.Enabled = False

    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub Msconfig_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        NewToolStripMenuItem.PerformClick()
    End Sub

    Private Sub chkstr_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkstr.CheckedChanged
        If chkstr.Checked = True Then
            txstr.Enabled = True
            txstr.Focus()
        Else
            txstr.Enabled = False
            txstr.ResetText()
        End If
    End Sub

    Private Sub chkint_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkint.CheckedChanged
        If chkint.Checked = True Then
            txint.Enabled = True
            txint.Focus()
        Else
            txint.Enabled = False
            txint.ResetText()
        End If
    End Sub

    Private Sub chkfloat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkfloat.CheckedChanged
        If chkfloat.Checked = True Then
            txfloat.Enabled = True
            txfloat.Focus()
        Else
            txfloat.Enabled = False
            txfloat.ResetText()
        End If
    End Sub

    Private Sub chkdate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkdate.CheckedChanged
        If chkdate.Checked = True Then
            dtdate.Enabled = True
            dtdate.Focus()
        Else
            dtdate.Enabled = False
            dtdate.Value = DateAndTime.Now
        End If
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        SetClear()
    End Sub

    Function Checking() As Boolean
        If cmbid.Text <> "" Then
            If MsgBox("Yakin update data ?", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then
                MsgBox("Batal update")
                Return False
            End If
        End If

        If cmbname.FindStringExact(cmbname.Text) < 0 Then
            If MsgBox("Buat Nama Jenis baru ?", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then
                MsgBox("Batal buat baru")
                Return False
            End If
        End If

        If chkdate.Checked = True And dtdate.Value < DateSerial("2001", "1", "1") Then
            MsgBox("Masukkan data Date yang sesuai")
            Return False
        End If

        If chkstr.Checked = True And txstr.Text = "" Then
            MsgBox("Masukkan data String yang sesuai")
            Return False
        End If

        If chkfloat.Checked = True And txfloat.Text = "" Then
            MsgBox("Masukkan data Float yang sesuai")
            Return False
        End If

        If chkint.Checked = True And txint.Text = "" Then
            MsgBox("Masukkan data Int yang sesuai")
            Return False
        End If

        If cmbtype.FindStringExact(cmbtype.Text) < 0 Then
            MsgBox("Isi Type dengan yang sesuai")
            cmbtype.Focus()
            Return False
        End If


        Return True
    End Function

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        If Checking = True Then
            If cmbid.Text = "" Then
                'save new
                WriteSQL("insert into MsConfig(ConfigName,ConfigType) values('" & cmbname.Text & "','" & cmbtype.Text & "')", 4)
                cmbid.Text = ReadSQLNIK("select ConfigID from MsConfig where ConfigName='" & cmbname.Text & "' and ConfigType='" & cmbtype.Text & "' and  StrValue is null and IntValue is null and FloatValue is null and DateValue is null")

                If chkstr.Checked = True Then WriteSQL("update MsConfig set StrValue='" & txstr.Text & "' where ConfigID='" & cmbid.Text & "'", 4)
                If chkint.Checked = True Then WriteSQL("update MsConfig set IntValue='" & txint.Text & "' where ConfigID='" & cmbid.Text & "'", 4)
                If chkfloat.Checked = True Then WriteSQL("update MsConfig set FloatValue='" & txfloat.Text & "'  where ConfigID='" & cmbid.Text & "'", 4)
                If chkdate.Checked = True Then WriteSQL("update MsConfig set DateValue='" & Format(dtdate.Value, "MM/dd/yyyy") & "' where ConfigID='" & cmbid.Text & "'", 4)
            Else
                'update data
                WriteSQL("update MsConfig set ConfigType='" & cmbtype.Text & "' where ConfigID='" & cmbid.Text & "'", 4)
                If chkstr.Checked = True Then WriteSQL("update MsConfig set StrValue='" & txstr.Text & "' where ConfigID='" & cmbid.Text & "'", 4)
                If chkint.Checked = True Then WriteSQL("update MsConfig set IntValue='" & txint.Text & "' where ConfigID='" & cmbid.Text & "'", 4)
                If chkfloat.Checked = True Then WriteSQL("update MsConfig set FloatValue='" & txfloat.Text & "'  where ConfigID='" & cmbid.Text & "'", 4)
                If chkdate.Checked = True Then WriteSQL("update MsConfig set DateValue='" & Format(dtdate.Value, "MM/dd/yyyy") & "' where ConfigID='" & cmbid.Text & "'", 4)
                MsgBox("Data Updated")

            End If
        End If
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        If cmbid.Text <> "" Then
            If chkdelete.Checked = True Then
                If MsgBox("Yakin untuk mendeleted data ?", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then
                    MsgBox("Batal deleted data")
                Else
                    WriteSQL("update MsConfig set Undeleted=0 where ConfigID='" & cmbid.Text & "'", 4)
                    MsgBox("Data Deleted")
                End If
            End If
        End If
    End Sub

    Public Sub LoadData(ByRef Trow As DataRowView)
        SetClear()
        cmbid.Text = Trow("ConfigId").ToString
        cmbname.Text = Trow("ConfigName").ToString
        cmbtype.Text = Trow("ConfigType").ToString
        If IsDBNull(Trow("StrValue")) = False Then
            chkstr.Checked = True
            txstr.Text = Trow("StrValue").ToString
        End If

        If IsDBNull(Trow("IntValue")) = False Then
            chkint.Checked = True
            txint.Text = Trow("IntValue").ToString
        End If

        If IsDBNull(Trow("FloatValue")) = False Then
            chkfloat.Checked = True
            txfloat.Text = Trow("FloatValue").ToString
        End If

        If IsDBNull(Trow("DateValue")) = False Then
            chkdate.Checked = True
            dtdate.Value = Trow("DateValue")
        End If

    End Sub

    Private Sub butfind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butfind.Click
        Find.Show()
        Find.Query(" select * from MsConfig ", " order by configId ", "FindConfig", 1)
    End Sub
End Class