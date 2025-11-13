Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Text
Imports System.Globalization
Imports System.Security.Cryptography
Imports System.Diagnostics
Imports System.Net.WebRequestMethods.Http
Imports System.Net
Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.ComponentModel.BackgroundWorker
Imports System.Data.SqlClient
Public Class FormAnalisisKinerjaDokter

    Private Sub ButtonViewObat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonViewObat.Click
        Try
            ' --- Validasi input ---
            If ComboBoxPoli.SelectedItem Is Nothing OrElse ComboBoxPoli.Text = "" Then
                MessageBox.Show("Silakan pilih poli terlebih dahulu.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If ComboBoxJaminan.SelectedItem Is Nothing OrElse ComboBoxJaminan.Text = "" Then
                MessageBox.Show("Silakan pilih jaminan terlebih dahulu.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If dtAwalObat.Value > dtAkhirObat.Value Then
                MessageBox.Show("Tanggal awal tidak boleh lebih besar dari tanggal akhir.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' --- Ambil nilai dari form ---
            Dim poliDipilih As String = ComboBoxPoli.Text.Trim().ToUpper()
            Dim jaminanDipilih As String = ComboBoxJaminan.Text.Trim().ToUpper()
            Dim tglAwal As String = dtAwalObat.Value.ToString("yyyy-MM-dd")
            Dim tglAkhir As String = dtAkhirObat.Value.ToString("yyyy-MM-dd")

            Dim sb As New StringBuilder()

            ' --- Bangun query analisis pemakaian obat ---
            sb.AppendLine("SELECT TOP 10")
            sb.AppendLine("    Tobat.ObatNama AS [Nama Obat],")
            sb.AppendLine("    SUM(Tobat.Jumlah) AS TotalPemakaian")
            sb.AppendLine("FROM TransaksiObat Tobat")
            sb.AppendLine("INNER JOIN TransaksiDetail TD ON Tobat.NoTransaksi = TD.NoUrut")
            sb.AppendLine("WHERE Tobat.CreatedDate BETWEEN '" & tglAwal & "' AND '" & tglAkhir & "'")
            sb.AppendLine("AND Tobat.DeletedBy IS NULL")

            ' --- Filter jaminan ---
            If jaminanDipilih <> "" AndAlso jaminanDipilih <> "Semua Transaksi" Then
                sb.AppendLine("AND TD.JenisPenagihan LIKE '%" & jaminanDipilih.Replace("'", "''") & "%'")
            End If

            ' --- Filter poli ---
            If poliDipilih <> "" AndAlso poliDipilih <> "SEMUA POLI" Then
                sb.AppendLine("AND TD.JenisPoli = '" & poliDipilih.Replace("'", "''") & "'")
            End If

            sb.AppendLine("GROUP BY Tobat.ObatNama")
            sb.AppendLine("ORDER BY TotalPemakaian DESC")

            ' --- Eksekusi query ---
            Dim dt As DataTable = ReadSQL(sb.ToString())

            If dt.Rows.Count = 0 Then
                MessageBox.Show("Tidak ada data pemakaian obat pada rentang tanggal yang dipilih.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            ' --- Tampilkan ke DataGridView ---
            DataGridView1.DataSource = dt
            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DataGridView1.Columns(0).HeaderText = "Nama Obat"
            DataGridView1.Columns(1).HeaderText = "Total Pemakaian"

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonDownloadTrend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDownloadTrend.Click
        Try
            If DataGridView1.Rows.Count = 0 Then
                MessageBox.Show("Tidak ada data pemakaian obat untuk dikirim.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim cabang As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NoPoli'")
            Dim baseURL As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
            baseURL = baseURL.TrimEnd("/"c)
            Dim apiUrl As String = baseURL & "/api/obat/pemakaianObat"

            Dim poliDipilih As String = If(ComboBoxPoli.SelectedItem IsNot Nothing, ComboBoxPoli.Text.Trim(), "")
            Dim jaminanDipilih As String = If(ComboBoxJaminan.SelectedItem IsNot Nothing, ComboBoxJaminan.Text.Trim(), "")
            Dim tglAwal As String = dtAwalObat.Value.ToString("yyyy-MM-dd")
            Dim tglAkhir As String = dtAkhirObat.Value.ToString("yyyy-MM-dd")

            Dim listData As New ArrayList()

            For Each row As DataGridViewRow In DataGridView1.Rows
                If row.IsNewRow Then Continue For

                Dim item As New Dictionary(Of String, Object)

                Dim namaObat As String = row.Cells("Nama Obat").Value.ToString().Trim()
                Dim totalPemakaian As Integer = 0

                If Not IsDBNull(row.Cells("TotalPemakaian").Value) Then
                    totalPemakaian = Convert.ToInt32(row.Cells("TotalPemakaian").Value)
                End If

                item.Add("nama_obat", namaObat)
                item.Add("total_pemakaian", totalPemakaian)

                listData.Add(item)
            Next

            Dim dataKirim As New Dictionary(Of String, Object)
            dataKirim.Add("data", listData)
            dataKirim.Add("cabang", cabang)
            dataKirim.Add("poli", poliDipilih)
            dataKirim.Add("jaminan", jaminanDipilih)
            dataKirim.Add("periode_awal", tglAwal)
            dataKirim.Add("periode_akhir", tglAkhir)

            Dim jsonData As String = Newtonsoft.Json.JsonConvert.SerializeObject(dataKirim, Newtonsoft.Json.Formatting.Indented)

            Dim response As String = InsertDataAPIRM(jsonData, apiUrl)

            Dim json = JObject.Parse(response)

            If json("status").ToString().ToLower() = "success" Then
                MessageBox.Show("Data pemakaian obat berhasil dikirim ke server.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)

                If json("url") IsNot Nothing AndAlso json("url").ToString().Trim() <> "" Then
                    Process.Start(json("url").ToString())
                End If
            Else
                MessageBox.Show("Gagal mengirim data: " & json("message").ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class