Public Class FormMenu

    Private Sub SetClear()
        txformid.ResetText()
        txformid.Enabled = True
        txformnama.ResetText()
        txformket.ResetText()
        txformidpast.ResetText()
    End Sub

    Private Sub FormMenu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        NewToolStripMenuItem.PerformClick()
    End Sub

    Private Sub SetGrid()
        gridtindakan.DataSource = ReadSQL("select [FormID],[FormNama],[FormKet] from MsConfigForm order by FormID asc")
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        SetClear()
        SetGrid()
    End Sub

    Public Sub LoadForm(ByRef Tdata As DataRowView)
        txformid.Text = Tdata("FormID").ToString
        txformid.Enabled = False
        txformidpast.Text = Tdata("FormID").ToString
        txformnama.Text = Tdata("FormNama").ToString
        txformket.Text = Tdata("FormKet").ToString
    End Sub

    Private Sub butfindform_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butfindform.Click
        Find.Show()
        Find.Query("select [FormID],[FormNama],[FormKet] from MsConfigForm ", " order by [FormID]", "Findform", 1)
    End Sub

    Function Checking() As Boolean
        If txformid.Text = "" Then
            MsgBox("FormID tidak boleh kosong")
            Return False
        End If

        If txformnama.Text = "" Then
            MsgBox("Form Nama tidak boleh kosong")
            Return False
        End If

        If txformket.Text = "" Then txformket.Text = "-"

        Return True
    End Function

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        If Checking() = True Then
            If txformidpast.Text = "" Then
                WriteSQL("insert into MsConfigForm ([FormID],[FormNama],[FormKet],[FormFinish],[FormStatus]) values('" & txformid.Text & "','" & txformnama.Text & "','" & txformket.Text & "',0,0)", 1)
                txformid.Enabled = False
            ElseIf txformidpast.Text <> "" Then
                If txformid.Text = txformidpast.Text Then
                    If MsgBox("Yakin update nama form dan keterangan ?", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                        'update hanya nama form dan keterangan
                        WriteSQL("update MsConfigForm set FormNama='" & txformnama.Text & "' , FormKet='" & txformket.Text & "' where FormID='" & txformid.Text & "'", 2)
                    Else
                        MsgBox("Batal udpate")
                    End If
                Else
                    If MsgBox("Apakah ada perubahan FormID, dan yakin dilakukan update ID dan keseluruhan Akses Form ini ?", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                        'update formid secara keseluruhan.
                        WriteSQL("update MsConfigForm set FormNama='" & txformnama.Text & "' , FormKet='" & txformket.Text & "' , FormID='" & txformid.Text & "' where FormID='" & txformidpast.Text & "'", 4)
                        WriteSQL("update MsConfigGrpForm set FormID='" & txformid.Text & "' where FormID='" & txformidpast.Text & "'", 4)
                        MsgBox("Update IDForm dan All akses user ke form ini.")
                    Else
                        MsgBox("Batal update")
                    End If
                End If

            End If
        End If
    End Sub
End Class