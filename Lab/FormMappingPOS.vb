Public Class FormMappingPOS

    Private Sub FormMappingPOS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim posList As New Dictionary(Of String, String)()
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
        posList.Add("rectal_swab", "RECTAL SWAB")

        cmbPOS.DataSource = New BindingSource(posList, Nothing)
        cmbPOS.DisplayMember = "Value"
        cmbPOS.ValueMember = "Key"

        LoadDgvTindakan()
    End Sub

    Private Sub LoadDgvTindakan()
        ' 1. Ambil data MasterLab
        Dim queryMaster As String = "SELECT TindakanID, NamaTindakan FROM MasterLab ORDER BY NamaTindakan ASC"
        Dim dtMaster As DataTable = ReadSQL(queryMaster)

        ' 2. Ambil data mapping POS yang sudah ada
        Dim queryMapping As String = "SELECT TindakanID, KodePOS FROM mapping_pos"
        Dim dtMapping As DataTable = ReadSQL(queryMapping)

        ' 3. Ambil data Pemeriksaan Khusus yang sudah ada
        Dim queryKhusus As String = "SELECT TindakanID FROM ms_pemeriksaan_khusus WHERE IsAktif = 1"
        Dim dtKhusus As DataTable = ReadSQL(queryKhusus)

        ' 4. Bersihkan DataGridView
        dgvTindakan.Columns.Clear()

        ' 5. Tambahkan kolom text standar
        dgvTindakan.Columns.Add("TindakanID", "ID Tindakan")
        dgvTindakan.Columns.Add("NamaTindakan", "Nama Pemeriksaan")
        dgvTindakan.Columns("NamaTindakan").Width = 250

        ' =======================================================================
        ' 6. TAMBAHKAN KOLOM CHECKBOX KHUSUS UNTUK "PEMERIKSAAN KHUSUS"
        ' =======================================================================
        Dim chkKhusus As New DataGridViewCheckBoxColumn()
        chkKhusus.Name = "is_khusus"
        chkKhusus.HeaderText = "Pemeriksaan Khusus"
        chkKhusus.Width = 120
        chkKhusus.DefaultCellStyle.BackColor = Color.LightYellow ' Diberi warna latar agar menonjol
        dgvTindakan.Columns.Add(chkKhusus)

        ' 7. Definisikan daftar POS standar
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
        posList.Add("rectal_swab", "RectalSwab")

        ' 8. Buat kolom Checkbox untuk setiap POS
        For Each kvp As KeyValuePair(Of String, String) In posList
            Dim chkCol As New DataGridViewCheckBoxColumn()
            chkCol.Name = kvp.Key
            chkCol.HeaderText = kvp.Value
            chkCol.Width = 80
            dgvTindakan.Columns.Add(chkCol)
        Next

        ' 9. Isi data dari DataTable Master ke DataGridView beserta status Centangnya
        For Each rowMaster As DataRow In dtMaster.Rows
            Dim rowIndex As Integer = dgvTindakan.Rows.Add()
            Dim idTindakan As String = rowMaster("TindakanID").ToString()
            Dim namaTindakan As String = rowMaster("NamaTindakan").ToString()

            dgvTindakan.Rows(rowIndex).Cells("TindakanID").Value = idTindakan
            dgvTindakan.Rows(rowIndex).Cells("NamaTindakan").Value = namaTindakan

            ' A. CEK STATUS CENTANG PEMERIKSAAN KHUSUS
            Dim rowsKhususMatch As DataRow() = dtKhusus.Select("TindakanID = '" & idTindakan & "'")
            If rowsKhususMatch.Length > 0 Then
                dgvTindakan.Rows(rowIndex).Cells("is_khusus").Value = True
            Else
                dgvTindakan.Rows(rowIndex).Cells("is_khusus").Value = False
            End If

            ' B. CEK STATUS CENTANG POS MAPPING
            For Each kvp As KeyValuePair(Of String, String) In posList
                Dim rowsMatch As DataRow() = dtMapping.Select("TindakanID = '" & idTindakan & "' AND KodePOS = '" & kvp.Key & "'")
                If rowsMatch.Length > 0 Then
                    dgvTindakan.Rows(rowIndex).Cells(kvp.Key).Value = True
                Else
                    dgvTindakan.Rows(rowIndex).Cells(kvp.Key).Value = False
                End If
            Next
        Next
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If dgvTindakan.Rows.Count = 0 Then Exit Sub
        dgvTindakan.EndEdit()

        Dim posColumns As String() = {"tt_tb", "screening", "visus", "dokter", "darah", "urine", "thorax", "spiro", "audio", "ecg", "usg", "treadmill", "rectal_swab"}

        Try
            For Each row As DataGridViewRow In dgvTindakan.Rows
                If Not row.IsNewRow Then
                    Dim idTindakan As String = row.Cells("TindakanID").Value.ToString()
                    Dim namaTindakan As String = row.Cells("NamaTindakan").Value.ToString().Replace("'", "''")

                    ' =======================================================================
                    ' 1. SIMPAN KE TABEL MS_PEMERIKSAAN_KHUSUS
                    ' =======================================================================
                    Dim isKhususChecked As Boolean = False
                    If row.Cells("is_khusus").Value IsNot Nothing Then
                        isKhususChecked = Convert.ToBoolean(row.Cells("is_khusus").Value)
                    End If

                    ' Hapus status lama untuk tindakan ini
                    WriteSQL("DELETE FROM ms_pemeriksaan_khusus WHERE TindakanID = '" & idTindakan & "'", 4)

                    ' Jika dicentang, Insert ke ms_pemeriksaan_khusus
                    If isKhususChecked Then
                        Dim qInsertKhusus As String = String.Format( _
                            "INSERT INTO ms_pemeriksaan_khusus (TindakanID, NamaPemeriksaanKhusus, IsAktif) VALUES ('{0}', '{1}', 1)", _
                            idTindakan, namaTindakan)
                        WriteSQL(qInsertKhusus, 4)
                    End If

                    ' =======================================================================
                    ' 2. SIMPAN KE TABEL MAPPING_POS
                    ' =======================================================================
                    ' Hapus mapping POS lama untuk tindakan ini
                    WriteSQL("DELETE FROM mapping_pos WHERE TindakanID = '" & idTindakan & "'", 4)

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

            MsgBox("Data Mapping POS dan Pemasteran Pemeriksaan Khusus berhasil disimpan!", MsgBoxStyle.Information)
            LoadDgvTindakan() ' Refresh Grid View

        Catch ex As Exception
            MsgBox("Terjadi kesalahan: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

End Class