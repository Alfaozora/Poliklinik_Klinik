Public Class FormBandingGambar
    Private _idTransaksi As String
    Private _idPasien As String

    Public Sub New(ByVal idTransaksi As String, ByVal idPasien As String)
        InitializeComponent()
        _idTransaksi = idTransaksi
        _idPasien = idPasien
    End Sub

    Private Sub FormBandingGambar_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        Dim dtPoli As DataTable = ReadSQL("SELECT JenisPoli FROM TransaksiDetail WHERE NoUrut = '" & _idTransaksi.Replace("'", "''") & "'")
        If dtPoli.Rows.Count > 0 Then
            Dim jenisPoli As String = dtPoli.Rows(0)("JenisPoli").ToString()
            IsiComboKeterangan(jenisPoli)
        Else
            MessageBox.Show("Jenis Poli tidak ditemukan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub


    Private Sub IsiComboKeterangan(ByVal jenisPoli As String)
        Dim query As String = "SELECT DISTINCT Keterangan FROM UploadGambar " & _
                        "WHERE NoRM = '" & _idPasien.Replace("'", "''") & "' " & _
                        "AND Kategori = '" & jenisPoli.Replace("'", "''") & "' " & _
                        "AND Deleted = 0 " & _
                        "ORDER BY Keterangan"
        Dim dt As DataTable = ReadSQL(query)

        ComboBoxKetBanding.Items.Clear()
        For Each row As DataRow In dt.Rows
            ComboBoxKetBanding.Items.Add(row("Keterangan").ToString())
        Next

        If ComboBoxKetBanding.Items.Count > 0 Then
            ComboBoxKetBanding.SelectedIndex = 0
        End If
    End Sub

    Public Sub TampilkanGambar(ByVal gambar As Image)
        PictureBoxAsli.Image = gambar
        PictureBoxAsli.SizeMode = PictureBoxSizeMode.Zoom
    End Sub

    Public Sub TampilkanGambar(ByVal keterangan As String, ByVal _idPasien As String, ByVal jenisPoli As String)
        Dim dt As DataTable = ReadSQL("SELECT FotoPath FROM UploadGambar WHERE " & _
                              "Keterangan = '" & keterangan.Replace("'", "''") & "' " & _
                              "AND NoRM = '" & _idPasien.Replace("'", "''") & "' " & _
                              "AND Kategori = '" & jenisPoli.Replace("'", "''") & "' " & _
                              "AND Deleted = 0")

        If dt.Rows.Count > 0 Then
            Dim fotoPath As String = dt.Rows(0)("FotoPath").ToString()
            Dim fullPath As String = System.IO.Path.Combine(Application.StartupPath, fotoPath)

            If IO.File.Exists(fullPath) Then
                PictureBoxBanding.Image = Image.FromFile(fullPath)
                PictureBoxBanding.SizeMode = PictureBoxSizeMode.Zoom
            Else
                PictureBoxBanding.Image = Nothing
                MessageBox.Show("File gambar tidak ditemukan di folder Uploads.")
            End If
        Else
            PictureBoxBanding.Image = Nothing
            MessageBox.Show("Data gambar tidak ditemukan.")
        End If
    End Sub

    Private Sub ComboBoxKetBanding_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxKetBanding.SelectedIndexChanged
        If ComboBoxKetBanding.SelectedIndex <> -1 Then
            Dim keteranganDipilih As String = ComboBoxKetBanding.SelectedItem.ToString()

            Dim dtPoli As DataTable = ReadSQL("SELECT JenisPoli FROM TransaksiDetail WHERE NoUrut = '" & _idTransaksi.Replace("'", "''") & "'")
            Dim ambilPoli As String = ""


            If dtPoli.Rows.Count > 0 Then
                ambilPoli = dtPoli.Rows(0)("JenisPoli").ToString()
            Else
                MessageBox.Show("Jenis poli tidak ditemukan untuk transaksi ini.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            TampilkanGambar(keteranganDipilih, _idPasien, ambilPoli)
        End If
    End Sub
End Class