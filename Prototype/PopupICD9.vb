Imports System.Windows.Forms

Public Class PopupICD9
    Private _SelectedICD9 As String
    Private _SelectedDisplay As String

    Public Property SelectedICD9() As String
        Get
            Return _SelectedICD9
        End Get
        Set(ByVal value As String)
            _SelectedICD9 = value
        End Set
    End Property

    Public Property SelectedDisplay() As String
        Get
            Return _SelectedDisplay
        End Get
        Set(ByVal value As String)
            _SelectedDisplay = value
        End Set
    End Property

    ' Tombol OK
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        PilihICD9()
    End Sub

    ' Tombol Cancel
    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    ' Load Data ICD9 pertama kali
    Private Sub PopupICD9_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        LoadICD9("")
    End Sub

    ' Load ICD9 ke DataGridView
    Private Sub LoadICD9(ByVal filter As String)
        Dim query As String = "SELECT Code, Display FROM MasterICD9CM WHERE 1=1"

        If filter <> "" Then
            query &= " AND (Code LIKE '%" & filter.Replace("'", "''") & "%' OR Display LIKE '%" & filter.Replace("'", "''") & "%')"
        End If

        query &= " ORDER BY Display ASC"

        Dim dt As DataTable = ReadSQL(query)

        DataGridViewICD9.DataSource = dt
        DataGridViewICD9.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    ' Event Search
    Private Sub TextBoxSearch_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TextBoxSearch.TextChanged
        LoadICD9(TextBoxSearch.Text)
    End Sub

    ' === Pilih ICD9 ===
    Private Sub PilihICD9()
        If DataGridViewICD9.CurrentRow IsNot Nothing Then
            SelectedICD9 = DataGridViewICD9.CurrentRow.Cells("Code").Value.ToString()
            SelectedDisplay = DataGridViewICD9.CurrentRow.Cells("Display").Value.ToString()
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show("Pilih ICD9 terlebih dahulu.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    ' === Double click DataGridView ===
    Private Sub DataGridViewICD9_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridViewICD9.CellDoubleClick
        PilihICD9()
    End Sub
End Class
