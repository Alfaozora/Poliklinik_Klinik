Public Class MasterUrutan

    Private Sub ClearHeader()
        Dim Tbls As DataTable = ReadSQL("select JenisID,JenisTindakan,UrutanJenisID as Urutan from MasterJenisTindakan order by UrutanJenisID")
        gridjenis.DataSource = Tbls
        gridjenis.Columns("JenisID").Visible = False
        gridjenis.Columns("Urutan").Visible = False
        gridjenis.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    End Sub

    Public Sub SetDetailJenis()
        Dim Tbls As DataTable = ReadSQL("select TindakanID,NamaTindakan,Urutan  from MasterLab where JenisTindakan='" & butjenis.Text & "' order by Urutan")
        gridurutantindakan.DataSource = Tbls
        gridurutantindakan.Columns("Urutan").Visible = False
        gridurutantindakan.Columns("TindakanID").Visible = False
        gridurutantindakan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    End Sub


    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub MasterUrutan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        ClearHeader()
        butjenis.ResetText()
        txjenisid.ResetText()
        SetDetailJenis()
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        ClearHeader()
        butjenis.ResetText()
        txjenisid.ResetText()
        SetDetailJenis()
    End Sub

    Private Sub butfindjenis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butfindjenis.Click
        Find.Show()
        Find.Query("select * from MasterJenisTindakan ", " order by UrutanJenisID", "FindUrutanJenisTindakan", 2)
    End Sub


    Private Sub butup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butup.Click
        If gridurutantindakan.CurrentCell.RowIndex = 0 Then
            Exit Sub
        Else
            MoveRow(-1, gridurutantindakan)
            gridurutantindakan.CurrentCell = gridurutantindakan.Rows(gridurutantindakan.CurrentRow.Index - 1).Cells(1)
        End If
    End Sub

    Private Sub butdown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butdown.Click
        If gridurutantindakan.CurrentCell.RowIndex = gridurutantindakan.RowCount - 1 Then
            Exit Sub
        Else
            MoveRow(1, gridurutantindakan)
            gridurutantindakan.CurrentCell = gridurutantindakan.Rows(gridurutantindakan.CurrentRow.Index + 1).Cells(1)
        End If
    End Sub

    Private Sub MoveRow(ByVal i As Integer, ByVal Ttemp As DataGridView)
        Try
            Dim Tnew As DataTable = Ttemp.DataSource
            Tnew.AcceptChanges()
            For Each Tcol As DataColumn In Tnew.Columns
                Tcol.ReadOnly = False
            Next

            If (Ttemp.SelectedCells.Count > 0) Then
                Dim curr_index As Integer = Ttemp.CurrentCell.RowIndex
                Dim Tpindah As Integer = curr_index + i
                Dim T1 As DataRow = Tnew.NewRow
                Dim T2 As DataRow = Tnew.Rows(Tpindah)

                For j As Integer = 0 To Tnew.Columns.Count - 1
                    T1(j) = Tnew(curr_index)(j)
                Next

                For j As Integer = 0 To Tnew.Columns.Count - 1
                    Tnew(curr_index)(j) = T2(j)
                Next

                For j As Integer = 0 To Tnew.Columns.Count - 1
                    Tnew(Tpindah)(j) = T1(j)
                Next

                For Each Tcol As DataColumn In Tnew.Columns
                    Tcol.ReadOnly = True
                Next

                Ttemp.DataSource = Tnew


            End If
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            ' do nothing if error encountered while trying to move the row up or down
        End Try
    End Sub

    Private Sub butsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butsave.Click
        Dim Tbls As DataTable = gridurutantindakan.DataSource
        Tbls.AcceptChanges()
        Dim i As Integer = 1
        Try
            For Each Trow As DataRow In Tbls.Rows
                WriteSQL("update MasterLab set Urutan='" & i & "' where TindakanID='" & Trow("TindakanID") & "'", 4)
                i = i + 1
            Next
            MsgBox("Data Saved")
        Catch ex As Exception

        End Try

    End Sub

    Private Sub butjenisup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butjenisup.Click
        If gridjenis.CurrentCell.RowIndex = 0 Then
            Exit Sub
        Else
            MoveRow(-1, gridjenis)
            gridjenis.CurrentCell = gridjenis.Rows(gridjenis.CurrentRow.Index - 1).Cells(1)
        End If
    End Sub

    Private Sub butjenisdown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butjenisdown.Click
        If gridjenis.CurrentCell.RowIndex = gridjenis.RowCount - 1 Then
            Exit Sub
        Else
            MoveRow(1, gridjenis)
            gridjenis.CurrentCell = gridjenis.Rows(gridjenis.CurrentRow.Index + 1).Cells(1)
        End If
    End Sub

    Private Sub butsavejenis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butsavejenis.Click
        Dim Tbls As DataTable = gridjenis.DataSource
        Tbls.AcceptChanges()
        Dim i As Integer = 1
        Try
            For Each Trow As DataRow In Tbls.Rows
                WriteSQL("update MasterJenisTindakan set UrutanJenisID='" & i & "' where JenisID='" & Trow("JenisID") & "'", 4)
                i = i + 1
            Next
            MsgBox("Data Saved")
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TestDisplayToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestDisplayToolStripMenuItem.Click

    End Sub
End Class

