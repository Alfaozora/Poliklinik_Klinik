Public Class MappingTindakan
    Private userInput As String = PoliKlinik.Lbluser.Text

    Private Sub MappingTindakan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBoxTindakan.Items.Clear()
        ComboBoxTindakan.Items.Add("POLI UMUM")
        ComboBoxTindakan.Items.Add("POLI GIGI")
        'ComboBoxTindakan.Items.Add("SEMUA") ' opsional
        ComboBoxTindakan.SelectedIndex = 0
    End Sub

    Private Sub ComboBoxTindakan_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxTindakan.SelectedIndexChanged
        LoadTindakan()
    End Sub

    Private Sub LoadTindakan()
        Dim tableName As String = ""

        If ComboBoxTindakan.Text = "Poli Umum" Then
            tableName = "MasterTindakan"
        ElseIf ComboBoxTindakan.Text = "Poli Gigi" Then
            tableName = "MasterTindakanGigi"
        End If

        If tableName = "" Then Exit Sub

        Dim query As String = "SELECT TindakanID, NamaTindakan, JenisTindakan, ICD9, Display FROM " & tableName & " WHERE ClosedDate IS NULL ORDER BY NamaTindakan ASC"

        Dim dt As DataTable = ReadSQL(query)

        DataGridViewTindakan.DataSource = dt
        DataGridViewTindakan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        ' Atur header kolom
        If DataGridViewTindakan.Columns.Contains("TindakanID") Then
            DataGridViewTindakan.Columns("TindakanID").HeaderText = "Kode"
            DataGridViewTindakan.Columns("NamaTindakan").HeaderText = "Nama Tindakan"
            DataGridViewTindakan.Columns("JenisTindakan").HeaderText = "Jenis Tindakan"
            DataGridViewTindakan.Columns("ICD9").HeaderText = "ICD-9-CM Code"
            DataGridViewTindakan.Columns("Display").HeaderText = "ICD-9-CM Display"
        End If
    End Sub

    Private Sub DataGridViewTindakan_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridViewTindakan.CellDoubleClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = DataGridViewTindakan.Columns("ICD9").Index Then
            Dim frm As New PopupICD9()

            ' Show popup ICD9, hasil return disimpan
            If frm.ShowDialog() = DialogResult.OK Then
                Dim selectedCode As String = frm.SelectedICD9
                Dim selectedDisplay As String = frm.SelectedDisplay

                ' Update ke DataGridView
                DataGridViewTindakan.Rows(e.RowIndex).Cells("ICD9").Value = selectedCode
                DataGridViewTindakan.Rows(e.RowIndex).Cells("Display").Value = selectedDisplay

                ' Tentukan tabel sesuai poli
                Dim tableName As String = ""
                If ComboBoxTindakan.Text = "Poli Umum" Then
                    tableName = "MasterTindakan"
                ElseIf ComboBoxTindakan.Text = "Poli Gigi" Then
                    tableName = "MasterTindakanGigi"
                End If

                If tableName <> "" Then
                    ' Update ke database juga
                    Dim tindakanID As String = DataGridViewTindakan.Rows(e.RowIndex).Cells("TindakanID").Value.ToString()
                    Dim queryUpdate As String = "UPDATE " & tableName & " " & _
                                "SET ICD9 = '" & selectedCode.Replace("'", "''") & "', " & _
                                "    Display = '" & selectedDisplay.Replace("'", "''") & "', " & _
                                "    UpdatedDate = GETDATE(), " & _
                                "    UpdatedBy = '" & userInput & "' " & _
                                "WHERE TindakanID = '" & tindakanID.Replace("'", "''") & "'"

                    WriteSQL(queryUpdate, 4)
                End If
            End If
        End If
    End Sub
End Class