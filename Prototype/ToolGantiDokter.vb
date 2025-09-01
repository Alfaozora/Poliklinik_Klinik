Public Class ToolGantiDokter
    Private formName As String = "Tool Ganti Dokter"

    Private Sub ToolGantiDokter_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        SetComboBoxNoTransaksi(False)
        SetComboBoxDokter(False)
    End Sub

    Private Sub SetComboBoxNoTransaksi(ByVal poliSakit As Boolean)
        Dim tblsNoTransaksi As DataTable = ReadSQL("SELECT " & _
            "TP.NoUrut, " & _
            "MP.Nama, " & _
            "(TP.NoUrut + ' - ' + MP.Nama) AS DisplayText " & _
        "FROM TransaksiPoli TP " & _
        "INNER JOIN MasterPasien MP " & _
            "ON TP.IDInternet = MP.NoRekamMedis " & _
        "WHERE TP.CreatedDate >= CAST(GETDATE() AS DATE) " & _
          "AND TP.CreatedDate < DATEADD(DAY, 1, CAST(GETDATE() AS DATE)) " & _
          "AND TP.Deleted = 0 " & _
        "ORDER BY TP.NoUrut")

        ComboBoxNoTransaksi.DataSource = tblsNoTransaksi
        ComboBoxNoTransaksi.DisplayMember = "DisplayText"
        ComboBoxNoTransaksi.ValueMember = "NoUrut"
        ComboBoxNoTransaksi.SelectedIndex = -1
    End Sub

    Private Sub SetComboBoxDokter(ByVal poliSakit As Boolean)
        Dim tblsNamaDokter As DataTable = ReadSQL("SELECT " & _
                "MD.ID, " & _
                "MD.Nama, " & _
                "(MD.ID + ' - ' + MD.Nama) AS DisplayText " & _
            "FROM MasterDokter MD " & _
            "WHERE(MD.StatusAktif = 1) " & _
            "AND MD.Jenis = 'Dokter'")

        ComboBoxDokter.DataSource = tblsNamaDokter
        ComboBoxDokter.DisplayMember = "DisplayText"
        ComboBoxDokter.ValueMember = "ID"
        ComboBoxDokter.SelectedIndex = -1
    End Sub

    Private Sub ButtonGanti_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGanti.Click
        Try
            ' Pastikan ada yang dipilih
            If ComboBoxNoTransaksi.SelectedIndex = -1 OrElse ComboBoxDokter.SelectedIndex = -1 Then
                MessageBox.Show("Silakan pilih NoUrut dan Dokter terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' Ambil nilai dari ComboBox
            Dim noUrut As String = ComboBoxNoTransaksi.SelectedValue.ToString()
            Dim kodeDokter As String = ComboBoxDokter.SelectedValue.ToString()
            Dim namaDokter As String = DirectCast(ComboBoxDokter.SelectedItem, DataRowView)("Nama").ToString()

            ' Query Update
            Dim query As String = "UPDATE TransaksiPoli " & _
                                  "SET DokterPoli = '" & namaDokter & "', " & _
                                      "KodeDokter = '" & kodeDokter & "' " & _
                                  "WHERE NoUrut = '" & noUrut & "'"

            ' Eksekusi query
            Dim tblGantiDokter As DataTable = ReadSQL(query)

            MessageBox.Show("Dokter berhasil diganti untuk NoUrut " & noUrut, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class