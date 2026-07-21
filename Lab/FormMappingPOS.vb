Public Class FormMappingPOS

    Private Sub FormMappingPOS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Inisialisasi dictionary kosong terlebih dahulu
        Dim posList As New Dictionary(Of String, String)()

        ' Masukkan data satu per satu menggunakan method .Add (Gaya lama VB.NET 2008)
        posList.Add("pendaftaran", "POS PENDAFTARAN")
        posList.Add("tt_tb", "PEMERIKSAAN FISIK: TB/BB")
        posList.Add("screening", "PEMERIKSAAN FISIK: SCREENING (TENSI, NADI)")
        posList.Add("visus", "PEMERIKSAAN FISIK: VISUS MATA")
        posList.Add("dokter", "PEMERIKSAAN FISIK: DOKTER")
        posList.Add("darah", "PENGAMBILAN DARAH")
        posList.Add("urine", "PENGAMBILAN URINE")
        posList.Add("thorax", "THORAX")
        posList.Add("spiro", "SPIRO")
        posList.Add("audio", "AUDIO")
        posList.Add("ecg", "ECG")
        posList.Add("usg", "USG")
        posList.Add("treadmill", "TREADMILL")

        ' Binding ke ComboBox menggunakan BindingSource
        cmbPOS.DataSource = New BindingSource(posList, Nothing)
        cmbPOS.DisplayMember = "Value"
        cmbPOS.ValueMember = "Key"

        LoadDgvTindakan()
    End Sub

    Private Sub LoadDgvTindakan()
        ' 1. Ambil data MasterLab
        Dim queryMaster As String = "SELECT TindakanID, NamaTindakan FROM MasterLab ORDER BY NamaTindakan ASC"
        Dim dtMaster As DataTable = ReadSQL(queryMaster)

        ' 2. Ambil semua data mapping yang sudah ada untuk referensi centang
        Dim queryMapping As String = "SELECT TindakanID, KodePOS FROM mapping_pos"
        Dim dtMapping As DataTable = ReadSQL(queryMapping)

        ' 3. Bersihkan DataGridView
        dgvTindakan.Columns.Clear()

        ' 4. Tambahkan kolom text standar
        dgvTindakan.Columns.Add("TindakanID", "ID Tindakan")
        dgvTindakan.Columns.Add("NamaTindakan", "Nama Pemeriksaan")
        dgvTindakan.Columns("NamaTindakan").Width = 250

        ' 5. Definisikan daftar POS yang akan dijadikan kolom Checkbox ke samping
        Dim posList As New Dictionary(Of String, String)()
        posList.Add("tt_tb", "TB/BB")
        posList.Add("screening", "Screening")
        posList.Add("visus", "Visus")
        posList.Add("dokter", "Dokter")
        posList.Add("darah", "Darah")
        posList.Add("urine", "Urine")
        posList.Add("thorax", "Thorax")
        posList.Add("spiro", "Spiro")
        posList.Add("audio", "Audio")
        posList.Add("ecg", "ECG")
        posList.Add("usg", "USG")
        posList.Add("treadmill", "Treadmill")

        ' 6. Buat kolom Checkbox untuk setiap POS
        For Each kvp As KeyValuePair(Of String, String) In posList
            Dim chkCol As New DataGridViewCheckBoxColumn()
            chkCol.Name = kvp.Key      ' Nama kolom diisi KodePOS (misal: 'thorax')
            chkCol.HeaderText = kvp.Value ' Judul kolom yang dilihat user (misal: 'Thorax')
            chkCol.Width = 80
            dgvTindakan.Columns.Add(chkCol)
        Next

        ' 7. Isi data dari DataTable Master ke DataGridView beserta status Centangnya
        For Each rowMaster As DataRow In dtMaster.Rows
            ' Tambah baris baru dan isi ID & Nama
            Dim rowIndex As Integer = dgvTindakan.Rows.Add()
            dgvTindakan.Rows(rowIndex).Cells("TindakanID").Value = rowMaster("TindakanID").ToString()
            dgvTindakan.Rows(rowIndex).Cells("NamaTindakan").Value = rowMaster("NamaTindakan").ToString()

            ' Cek ke database apakah tindakan ini sudah dicentang di POS tertentu
            Dim idTindakan As String = rowMaster("TindakanID").ToString()

            For Each kvp As KeyValuePair(Of String, String) In posList
                ' Filter apakah ada match antara TindakanID dan KodePOS di tabel mapping
                Dim rowsMatch As DataRow() = dtMapping.Select("TindakanID = '" & idTindakan & "' AND KodePOS = '" & kvp.Key & "'")

                If rowsMatch.Length > 0 Then
                    dgvTindakan.Rows(rowIndex).Cells(kvp.Key).Value = True ' Centang jika ada di DB
                Else
                    dgvTindakan.Rows(rowIndex).Cells(kvp.Key).Value = False
                End If
            Next
        Next
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If dgvTindakan.Rows.Count = 0 Then Exit Sub
        dgvTindakan.EndEdit()

        ' Definisikan ulang daftar kolom POS untuk keperluan looping salvaging
        Dim posColumns As String() = {"tt_tb", "screening", "visus", "dokter", "darah", "urine", "thorax", "spiro", "audio", "ecg", "usg", "treadmill"}

        Try
            For Each row As DataGridViewRow In dgvTindakan.Rows
                If Not row.IsNewRow Then
                    Dim idTindakan As String = row.Cells("TindakanID").Value.ToString()

                    ' Langkah A: Hapus semua mapping lama untuk tindakan ini agar tidak duplikat/salah data
                    WriteSQL("DELETE FROM mapping_pos WHERE TindakanID = '" & idTindakan & "'", 4)

                    ' Langkah B: Cek tiap kolom POS, jika True (dicentang), Insert ke database
                    For Each colName As String In posColumns
                        Dim isChecked As Boolean = False
                        If row.Cells(colName).Value IsNot Nothing Then
                            isChecked = Convert.ToBoolean(row.Cells(colName).Value)
                        End If

                        If isChecked Then
                            Dim queryInsert As String = "INSERT INTO mapping_pos (TindakanID, KodePOS) VALUES ('" & idTindakan & "', '" & colName & "')"
                            WriteSQL(queryInsert, 4)
                        End If
                    Next
                End If
            Next

            MsgBox("Multi-POS Mapping berhasil disimpan dengan cepat!", MsgBoxStyle.Information)
            LoadDgvTindakan() ' Refresh Grid

        Catch ex As Exception
            MsgBox("Terjadi kesalahan: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class