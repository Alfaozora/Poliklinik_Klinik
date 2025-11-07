Imports System.Windows.Forms

Public Class PopupObatLokal
    Private _SelectedKodeLokal As String
    Private _SelectedNamaObat As String
    Private _SelectedSkor As String

    Public Property SelectedKodeLokal() As String
        Get
            Return _SelectedKodeLokal
        End Get
        Set(ByVal value As String)
            _SelectedKodeLokal = value
        End Set
    End Property

    Public Property SelectedNamaObat() As String
        Get
            Return _SelectedNamaObat
        End Get
        Set(ByVal value As String)
            _SelectedNamaObat = value
        End Set
    End Property

    Public Property SelectedSkor() As String
        Get
            Return _SelectedSkor
        End Get
        Set(ByVal value As String)
            _SelectedSkor = value
        End Set
    End Property


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        PilihKodeLokal()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub PopupICD9_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ComboBoxData.Items.Clear()
        ComboBoxData.Items.Add("Data Obat")
        ComboBoxData.Items.Add("Mapping Obat")
        ComboBoxData.SelectedIndex = 0 ' default MappingObat
        LoadData("Data Obat")
    End Sub

    Private Sub ComboBoxData_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBoxData.SelectedIndexChanged
        Dim pilihan As String = ComboBoxData.SelectedItem.ToString()

        If pilihan = "Mapping Obat" Then
            LoadData("Mapping Obat")
        ElseIf pilihan = "Data Obat" Then
            LoadData("Data Obat")
        End If
    End Sub

    Private Sub LoadData(ByVal tipe As String, Optional ByVal filter As String = "")
        Dim query As String = ""

        If tipe = "Mapping Obat" Then
            query = "SELECT ObatID, ObatNama, Skor FROM MappingObatManual WHERE 1=1"
            If filter <> "" Then
                query &= " AND (ObatID LIKE '%" & filter.Replace("'", "''") & "%' OR ObatNama LIKE '%" & filter.Replace("'", "''") & "%')"
            End If
            query &= " ORDER BY ObatNama ASC"

        ElseIf tipe = "Data Obat" Then
            query = "SELECT DISTINCT ObatID, ObatNama FROM TransaksiObat WHERE 1=1"
            If filter <> "" Then
                query &= " AND (ObatID LIKE '%" & filter.Replace("'", "''") & "%' OR ObatNama LIKE '%" & filter.Replace("'", "''") & "%')"
            End If
            query &= " ORDER BY ObatNama ASC"
        End If

        Dim dt As DataTable = ReadSQL(query)
        DataGridViewObatLokal.DataSource = dt
        DataGridViewObatLokal.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    Private Sub TextBoxSearch_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TextBoxSearch.TextChanged
        Dim pilihan As String = ComboBoxData.SelectedItem.ToString()
        LoadData(pilihan, TextBoxSearch.Text)
    End Sub

    Private Sub PilihKodeLokal()
        If DataGridViewObatLokal.CurrentRow IsNot Nothing Then
            SelectedKodeLokal = DataGridViewObatLokal.CurrentRow.Cells("ObatID").Value.ToString()
            SelectedNamaObat = DataGridViewObatLokal.CurrentRow.Cells("ObatNama").Value.ToString()

            ' cek apakah ada kolom Skor
            If DataGridViewObatLokal.Columns.Contains("Skor") Then
                SelectedSkor = If(IsDBNull(DataGridViewObatLokal.CurrentRow.Cells("Skor").Value), "", DataGridViewObatLokal.CurrentRow.Cells("Skor").Value.ToString())
            Else
                SelectedSkor = "" ' default kosong
            End If

            Me.DialogResult = DialogResult.OK
            Me.Close()
        Else
            MessageBox.Show("Pilih Nama Obat terlebih dahulu.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub DataGridViewObatLokal_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridViewObatLokal.CellDoubleClick
        PilihKodeLokal()
    End Sub

    Private Sub OK_Button_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

    End Sub
End Class
