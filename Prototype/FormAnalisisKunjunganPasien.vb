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
Public Class FormAnalisisKunjunganPasien

    Private Sub ButtonKirim_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonKirim.Click
        Try
            ' --- Validasi pilihan ---
            If ComboBoxHari.SelectedItem Is Nothing OrElse ComboBoxHari.Text = "" Then
                MessageBox.Show("Silakan pilih jenis prediksi: Harian, Mingguan, atau Bulanan.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim modeForecast As String = ComboBoxHari.SelectedItem.ToString()

            ' --- Tentukan rentang hari data historis berdasarkan mode prediksi ---
            Dim rentangHari As Integer = 90 ' default
            Select Case modeForecast
                Case "Harian"
                    rentangHari = 90
                Case "Mingguan"
                    rentangHari = 180
                Case "Bulanan"
                    rentangHari = 365
            End Select

            ' --- Bangun query data historis ---
            Dim sb As New StringBuilder()

            Select Case modeForecast
                Case "Harian"
                    sb.AppendLine("SELECT CONVERT(VARCHAR(10), Tanggal, 120) AS Periode, COUNT(*) AS JumlahPasien FROM (")
                    sb.AppendLine("    SELECT TglPoli AS Tanggal, NoUrut FROM TransaksiPoli")
                    sb.AppendLine("    UNION ALL")
                    sb.AppendLine("    SELECT TglGigi AS Tanggal, NoUrut FROM TransaksiGigi")
                    sb.AppendLine(") AS Gabungan")
                    sb.AppendLine("WHERE Tanggal >= DATEADD(DAY, -" & rentangHari & ", CAST(GETDATE() AS DATE)) AND Tanggal < CAST(GETDATE() AS DATE)")
                    sb.AppendLine("GROUP BY CONVERT(VARCHAR(10), Tanggal, 120)")
                    sb.AppendLine("ORDER BY Periode ASC;")

                    'sb.AppendLine("SELECT CONVERT(VARCHAR(10), Tanggal, 120) AS Periode, COUNT(*) AS JumlahPasien FROM (")
                    'sb.AppendLine("    SELECT TglPoli AS Tanggal, NoUrut FROM TransaksiPoli")
                    'sb.AppendLine("    UNION ALL")
                    'sb.AppendLine("    SELECT TglGigi AS Tanggal, NoUrut FROM TransaksiGigi")
                    'sb.AppendLine(") AS Gabungan")
                    'sb.AppendLine("WHERE Tanggal >= DATEADD(DAY, -" & rentangHari & ", CAST(GETDATE() AS DATE)) ")
                    'sb.AppendLine("  AND Tanggal < DATEADD(DAY, -2, CAST(GETDATE() AS DATE))")
                    'sb.AppendLine("GROUP BY CONVERT(VARCHAR(10), Tanggal, 120)")
                    'sb.AppendLine("ORDER BY Periode ASC;")


                Case "Mingguan"
                    sb.AppendLine("SELECT CAST(YEAR(Tanggal) AS VARCHAR(4)) + '-W' + RIGHT('00' + CAST(DATEPART(WEEK, Tanggal) AS VARCHAR(2)), 2) AS Periode, COUNT(*) AS JumlahPasien FROM (")
                    sb.AppendLine("    SELECT TglPoli AS Tanggal, NoUrut FROM TransaksiPoli")
                    sb.AppendLine("    UNION ALL")
                    sb.AppendLine("    SELECT TglGigi AS Tanggal, NoUrut FROM TransaksiGigi")
                    sb.AppendLine(") AS Gabungan")
                    sb.AppendLine("WHERE Tanggal >= DATEADD(DAY, -" & rentangHari & ", CAST(GETDATE() AS DATE)) AND Tanggal < CAST(GETDATE() AS DATE)")
                    sb.AppendLine("GROUP BY YEAR(Tanggal), DATEPART(WEEK, Tanggal)")
                    sb.AppendLine("ORDER BY YEAR(Tanggal), DATEPART(WEEK, Tanggal);")

                Case "Bulanan"
                    sb.AppendLine("SELECT CONVERT(VARCHAR(7), Tanggal, 120) AS Periode, COUNT(*) AS JumlahPasien FROM (")
                    sb.AppendLine("    SELECT TglPoli AS Tanggal, NoUrut FROM TransaksiPoli")
                    sb.AppendLine("    UNION ALL")
                    sb.AppendLine("    SELECT TglGigi AS Tanggal, NoUrut FROM TransaksiGigi")
                    sb.AppendLine(") AS Gabungan")
                    sb.AppendLine("WHERE Tanggal >= DATEADD(DAY, -" & rentangHari & ", CAST(GETDATE() AS DATE)) AND Tanggal < CAST(GETDATE() AS DATE)")
                    sb.AppendLine("GROUP BY CONVERT(VARCHAR(7), Tanggal, 120)")
                    sb.AppendLine("ORDER BY Periode ASC;")
            End Select

            Dim dt As DataTable = ReadSQL(sb.ToString())
            If dt.Rows.Count = 0 Then
                MsgBox("Tidak ada data kunjungan untuk " & rentangHari & " hari terakhir.", MsgBoxStyle.Exclamation, "Prediksi Gagal")
                Exit Sub
            End If

            'Cabang
            Dim Cabang As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NoPoli'")

            ' --- Siapkan data kirim ke API ---
            Dim listData As New ArrayList()

            For Each row As DataRow In dt.Rows
                Dim item As New Dictionary(Of String, Object)

                ' Ambil label periode (kolom Periode); fallback ke Tanggal jika Periode tidak ada
                Dim periodeKolom As String = If(dt.Columns.Contains("Periode"), "Periode", If(dt.Columns.Contains("Tanggal"), "Tanggal", Nothing))

                If periodeKolom Is Nothing Then
                    Throw New Exception("Kolom Periode/Tanggal tidak ditemukan pada hasil query.")
                End If

                item.Add("Tanggal", row(periodeKolom).ToString())
                item.Add("JumlahPasien", Convert.ToInt32(row("JumlahPasien")))
                listData.Add(item)
            Next

            Dim dataKirim As New Dictionary(Of String, Object)
            dataKirim.Add("data", listData)
            dataKirim.Add("mode", modeForecast)
            dataKirim.Add("cabang", Cabang)

            Dim jsonData As String = JsonConvert.SerializeObject(dataKirim)

            Dim apiUrl As String
            Dim baseURL As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
            Dim baseURLPython As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_python'")

            If RadioButtonSes.Checked Then
                apiUrl = baseURL & "api/predict-patient"
            ElseIf RadioButtonHoltW.Checked Then
                apiUrl = baseURLPython & "api/predict-holtwinters"
            Else
                MessageBox.Show("Silakan pilih metode prediksi (SES atau Holt-Winters).")
                Exit Sub
            End If

            ' --- Ambil URL API dari MsConfig ---
            'baseURL = baseURL.TrimEnd("/"c)
            'Dim apiUrl As String = baseURL & "/api/predict-patient"

            ' --- Kirim data ke API ---
            Dim response As String = InsertDataAPIRM(jsonData, apiUrl)

            ' --- Proses respons dari server ---
            Try
                Dim hasil = JsonConvert.DeserializeObject(Of JObject)(response)

                If hasil("status").ToString().ToLower() = "success" Then
                    Dim prediksiArray As JArray = hasil("prediksi")
                    Dim alpha As Double = If(hasil("detail")("best_alpha"), 0)
                    Dim mape As Double = If(hasil("detail")("mape_validasi"), 0)

                    ' --- Reset dan siapkan DataGridView ---
                    DataGridView1.Rows.Clear()
                    DataGridView1.Columns.Clear()
                    DataGridView1.Columns.Add("Periode", "Periode")
                    DataGridView1.Columns.Add("Prediksi", "Prediksi Jumlah Pasien")
                    DataGridView1.Columns.Add("Alpha", "Alpha Terbaik")
                    DataGridView1.Columns.Add("MAPE", "MAPE Validasi (%)")
                    DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                    DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                    ' --- Tentukan hasil berdasarkan mode ---
                    Dim hasilPrediksi As Double = 0
                    Dim periodeLabel As String = ""

                    Select Case modeForecast
                        Case "Harian"
                            hasilPrediksi = prediksiArray(0).ToObject(Of Double)()
                            periodeLabel = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd")

                        Case "Mingguan"
                            hasilPrediksi = prediksiArray(0).ToObject(Of Double)()
                            periodeLabel = "Minggu Depan (" & DateTime.Now.AddDays(1).ToString("dd MMM") & _
                                        " - " & DateTime.Now.AddDays(7).ToString("dd MMM yyyy") & ")"

                        Case "Bulanan"
                            hasilPrediksi = prediksiArray(0).ToObject(Of Double)()

                            ' Kalau hari ini masih tanggal < 10 di bulan berjalan, anggap prediksi untuk bulan ini
                            If DateTime.Now.Day <= 10 Then
                                periodeLabel = "Bulan Ini (" & DateTime.Now.ToString("MMMM yyyy") & ")"
                            Else
                                ' Kalau sudah lewat pertengahan bulan, baru prediksi bulan depan
                                periodeLabel = "Bulan Depan (" & DateTime.Now.AddMonths(1).ToString("MMMM yyyy") & ")"
                            End If
                    End Select

                    ' --- Tambahkan ke grid ---
                    DataGridView1.Rows.Add(periodeLabel, Math.Round(hasilPrediksi, 2), Math.Round(alpha, 2), Math.Round(mape, 2))

                Else
                    MsgBox("Gagal memproses: " & hasil("message").ToString(), MsgBoxStyle.Exclamation, "Prediksi Gagal")
                End If

            Catch parseEx As Exception
                MsgBox("Respons tidak dikenali dari server:" & vbCrLf & response, MsgBoxStyle.Exclamation, "Prediksi")
            End Try

        Catch ex As Exception
            MsgBox("Terjadi kesalahan: " & ex.Message, MsgBoxStyle.Critical, "Error Prediksi")
        End Try
    End Sub

    Private Sub ButtonKirimData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonKirimData.Click
        Try
            ' --- Ambil cabang dari konfigurasi ---
            Dim cabang As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NoPoli'")

            ' --- Ambil mode forecasting (Harian/Mingguan/Bulanan) ---
            Dim modeForecast As String = ComboBoxHari.SelectedItem.ToString()
            Dim rentangHari As Integer = 0

            Select Case modeForecast
                Case "Harian"
                    rentangHari = 30
                Case "Mingguan"
                    rentangHari = 180
                Case "Bulanan"
                    rentangHari = 365
            End Select

            ' --- Bangun query data aktual ---
            Dim sb As New StringBuilder()

            Select Case modeForecast
                Case "Harian"
                    sb.AppendLine("SELECT CONVERT(VARCHAR(10), Tanggal, 120) AS Tanggal, COUNT(*) AS JumlahPasien")
                    sb.AppendLine("FROM (")
                    sb.AppendLine("    SELECT TglPoli AS Tanggal FROM TransaksiPoli")
                    sb.AppendLine("    UNION ALL")
                    sb.AppendLine("    SELECT TglGigi AS Tanggal FROM TransaksiGigi")
                    sb.AppendLine(") AS Gabungan")
                    sb.AppendLine("WHERE Tanggal >= DATEADD(DAY, -" & rentangHari & ", CAST(GETDATE() AS DATE))")
                    sb.AppendLine("  AND Tanggal < CAST(GETDATE() AS DATE)")
                    sb.AppendLine("GROUP BY CONVERT(VARCHAR(10), Tanggal, 120)")
                    sb.AppendLine("ORDER BY Tanggal ASC;")

                Case "Mingguan"
                    sb.AppendLine("SELECT CONVERT(VARCHAR(10), DATEADD(DAY, 1 - DATEPART(WEEKDAY, CONVERT(DATE, Tanggal)), CONVERT(DATE, Tanggal)), 120) AS Tanggal, COUNT(*) AS JumlahPasien")
                    sb.AppendLine("FROM (")
                    sb.AppendLine("    SELECT TglPoli AS Tanggal FROM TransaksiPoli")
                    sb.AppendLine("    UNION ALL")
                    sb.AppendLine("    SELECT TglGigi AS Tanggal FROM TransaksiGigi")
                    sb.AppendLine(") AS Gabungan")
                    sb.AppendLine("WHERE Tanggal >= DATEADD(DAY, -" & rentangHari & ", CAST(GETDATE() AS DATE))")
                    sb.AppendLine("  AND Tanggal < CAST(GETDATE() AS DATE)")
                    sb.AppendLine("GROUP BY DATEADD(DAY, 1 - DATEPART(WEEKDAY, CONVERT(DATE, Tanggal)), CONVERT(DATE, Tanggal))")
                    sb.AppendLine("ORDER BY Tanggal ASC;")

                Case "Bulanan"
                    sb.AppendLine("SELECT CONVERT(VARCHAR(10), DATEADD(DAY, 1 - DAY(CONVERT(DATE, Tanggal)), CONVERT(DATE, Tanggal)), 120) AS Tanggal, COUNT(*) AS JumlahPasien")
                    sb.AppendLine("FROM (")
                    sb.AppendLine("    SELECT TglPoli AS Tanggal FROM TransaksiPoli")
                    sb.AppendLine("    UNION ALL")
                    sb.AppendLine("    SELECT TglGigi AS Tanggal FROM TransaksiGigi")
                    sb.AppendLine(") AS Gabungan")
                    sb.AppendLine("WHERE Tanggal IS NOT NULL")
                    sb.AppendLine("  AND CONVERT(DATE, Tanggal) >= DATEADD(DAY, -365, CAST(GETDATE() AS DATE))")
                    sb.AppendLine("  AND CONVERT(DATE, Tanggal) < CAST(GETDATE() AS DATE)")
                    sb.AppendLine("GROUP BY DATEADD(DAY, 1 - DAY(CONVERT(DATE, Tanggal)), CONVERT(DATE, Tanggal))")
                    sb.AppendLine("ORDER BY DATEADD(DAY, 1 - DAY(CONVERT(DATE, Tanggal)), CONVERT(DATE, Tanggal));")
            End Select

            ' --- Ambil data dari database ---
            Dim dt As DataTable = ReadSQL(sb.ToString())
            If dt.Rows.Count = 0 Then
                MsgBox("Tidak ada data aktual untuk " & rentangHari & " hari terakhir.", MsgBoxStyle.Exclamation, "Gagal Mengirim Data")
                Exit Sub
            End If

            ' --- Siapkan data kirim ke API ---
            Dim listData As New ArrayList()

            For Each row As DataRow In dt.Rows
                Dim item As New Dictionary(Of String, Object)
                Dim t As String = row("Tanggal").ToString().Trim()

                ' Format ke yyyy-MM-dd agar valid sebagai DATE di Laravel
                Dim dtTanggal As DateTime
                If DateTime.TryParse(t, dtTanggal) Then
                    t = dtTanggal.ToString("yyyy-MM-dd")
                Else
                    Continue For
                End If

                item.Add("Tanggal", t)
                item.Add("JumlahAktual", Convert.ToInt32(row("JumlahPasien")))
                listData.Add(item)
            Next

            Dim dataKirim As New Dictionary(Of String, Object)
            dataKirim.Add("data", listData)
            dataKirim.Add("mode", modeForecast)
            dataKirim.Add("cabang", cabang)

            Dim jsonData As String = JsonConvert.SerializeObject(dataKirim)

            ' --- Ambil URL API dari konfigurasi ---
            Dim baseURL As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
            baseURL = baseURL.TrimEnd("/"c)
            Dim apiUrl As String = baseURL & "/api/actual-data"

            ' --- Kirim data ke API ---
            Dim response As String = InsertDataAPIRM(jsonData, apiUrl)

            If String.IsNullOrEmpty(response) Then
                MsgBox("Tidak ada respon dari server API.", MsgBoxStyle.Exclamation, "Gagal")
            Else
                MsgBox("Data aktual berhasil dikirim ke API untuk cabang " & cabang & vbCrLf & "Respon: " & response, MsgBoxStyle.Information, "Sukses")
            End If

        Catch ex As Exception
            MsgBox("Terjadi kesalahan saat mengirim data aktual: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub ButtonReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonReport.Click
        Try
            ' --- Validasi pemilihan periode ---
            If ComboBoxHari.SelectedItem Is Nothing Then
                MessageBox.Show("Silakan pilih periode forecasting (Harian/Mingguan/Bulanan).", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' --- Ambil data dari konfigurasi ---
            Dim tipe As String = ComboBoxHari.SelectedItem.ToString().ToLower()
            Dim cabang As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NoPoli'")
            Dim baseURL As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")

            ' Pastikan baseURL berakhiran slash atau parameter yang benar
            If Not baseURL.ToLower().Contains("forecasting/report") Then
                If Not baseURL.EndsWith("/") Then baseURL &= "/"
                baseURL &= "api/forecasting/report?tipe="
            End If

            ' --- Susun URL lengkap ---
            Dim url As String = baseURL & tipe & "&cabang=" & cabang

            ' --- Request ke server Laravel ---
            Dim client As New WebClient()
            Dim response As String = client.DownloadString(url)
            Dim json = JObject.Parse(response)

            ' --- Cek hasil respon ---
            If json("status").ToString().ToLower() = "success" Then
                Dim pdfUrl As String = json("url").ToString()
                Process.Start(pdfUrl) ' buka langsung di browser default
            Else
                MessageBox.Show("Gagal membuat laporan: " & json("message").ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As WebException
            MessageBox.Show("Gagal menghubungi server laporan: " & ex.Message, "Koneksi Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub ButtonViewTrend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonViewTrend.Click
        Try
            ' --- Validasi input ---
            If ComboBoxPeriode.SelectedItem Is Nothing OrElse ComboBoxPeriode.Text = "" Then
                MessageBox.Show("Silakan pilih periode tampilan: Harian, Mingguan, atau Bulanan.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If dtAwal.Value > dtAkhir.Value Then
                MessageBox.Show("Tanggal awal tidak boleh lebih besar dari tanggal akhir.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim periode As String = ComboBoxPeriode.SelectedItem.ToString()
            Dim poliDipilih As String = ComboBoxPoli.Text
            Dim jaminanDipilih As String = ComboBoxJaminan.Text.Trim().ToUpper()
            Dim tglAwal As String = dtAwal.Value.ToString("yyyy-MM-dd")
            Dim tglAkhir As String = dtAkhir.Value.ToString("yyyy-MM-dd")

            Dim sb As New StringBuilder()

            ' --- Bangun query sesuai periode ---
            Select Case periode
                Case "Harian"
                    sb.AppendLine("SELECT CAST(Tanggal AS DATE) AS Periode,")
                    sb.AppendLine("COUNT(*) AS JumlahPasien,")
                    sb.AppendLine("AVG(DATEDIFF(MINUTE, ArrivedDate, FinishedDate)) AS RataRataMenit")
                    sb.AppendLine("FROM (")
                Case "Mingguan"
                    sb.AppendLine("SELECT CAST(YEAR(Tanggal) AS VARCHAR(4)) + '-W' + RIGHT('00' + CAST(DATEPART(WEEK, Tanggal) AS VARCHAR(2)), 2) AS Periode,")
                    sb.AppendLine("COUNT(*) AS JumlahPasien,")
                    sb.AppendLine("AVG(DATEDIFF(MINUTE, ArrivedDate, FinishedDate)) AS RataRataMenit")
                    sb.AppendLine("FROM (")
                Case "Bulanan"
                    sb.AppendLine("SELECT CONVERT(VARCHAR(7), Tanggal, 120) AS Periode,")
                    sb.AppendLine("COUNT(*) AS JumlahPasien,")
                    sb.AppendLine("AVG(DATEDIFF(MINUTE, ArrivedDate, FinishedDate)) AS RataRataMenit")
                    sb.AppendLine("FROM (")
            End Select

            Dim filterJaminan As String = ""
            If jaminanDipilih <> "" AndAlso jaminanDipilih <> "GABUNGAN" Then
                filterJaminan = " AND td.JenisPenagihan LIKE '%" & jaminanDipilih.Replace("'", "''") & "%'"
            End If

            ' --- Gabungkan data berdasarkan poli ---
            If poliDipilih = "SEMUA POLI" Then
                sb.AppendLine("    SELECT tp.TglPoli AS Tanggal, tp.NoUrut, tp.ArrivedDate, tp.FinishedDate")
                sb.AppendLine("    FROM TransaksiPoli tp")
                sb.AppendLine("    INNER JOIN TransaksiDetail td ON CAST(td.NoUrut AS VARCHAR(50)) = tp.NoUrut")
                sb.AppendLine("    WHERE tp.TglPoli BETWEEN '" & tglAwal & "' AND '" & tglAkhir & "'" & filterJaminan)
                sb.AppendLine("    UNION ALL")
                sb.AppendLine("    SELECT tg.TglGigi AS Tanggal, tg.NoUrut, tg.ArrivedDate, tg.FinishedDate")
                sb.AppendLine("    FROM TransaksiGigi tg")
                sb.AppendLine("    INNER JOIN TransaksiDetail td ON CAST(td.NoUrut AS VARCHAR(50)) = tg.NoUrut")
                sb.AppendLine("    WHERE tg.TglGigi BETWEEN '" & tglAwal & "' AND '" & tglAkhir & "'" & filterJaminan)
            ElseIf poliDipilih = "POLI GIGI & MULUT" Then
                sb.AppendLine("    SELECT tg.TglGigi AS Tanggal, tg.NoUrut, tg.ArrivedDate, tg.FinishedDate")
                sb.AppendLine("    FROM TransaksiGigi tg")
                sb.AppendLine("    INNER JOIN TransaksiDetail td ON CAST(td.NoUrut AS VARCHAR(50)) = tg.NoUrut")
                sb.AppendLine("    WHERE td.JenisPoli = '" & poliDipilih.Replace("'", "''") & "' AND tg.TglGigi BETWEEN '" & tglAwal & "' AND '" & tglAkhir & "'" & filterJaminan)
            Else
                sb.AppendLine("    SELECT tp.TglPoli AS Tanggal, tp.NoUrut, tp.ArrivedDate, tp.FinishedDate")
                sb.AppendLine("    FROM TransaksiPoli tp")
                sb.AppendLine("    INNER JOIN TransaksiDetail td ON CAST(td.NoUrut AS VARCHAR(50)) = tp.NoUrut")
                sb.AppendLine("    WHERE td.JenisPoli = '" & poliDipilih.Replace("'", "''") & "' AND tp.TglPoli BETWEEN '" & tglAwal & "' AND '" & tglAkhir & "'" & filterJaminan)
            End If

            sb.AppendLine(") AS Gabungan")
            sb.AppendLine("WHERE Tanggal BETWEEN '" & tglAwal & "' AND '" & tglAkhir & "'")

            ' --- Grouping sesuai periode ---
            Select Case periode
                Case "Harian"
                    sb.AppendLine("GROUP BY CAST(Tanggal AS DATE)")
                    sb.AppendLine("ORDER BY CAST(Tanggal AS DATE)")
                Case "Mingguan"
                    sb.AppendLine("GROUP BY YEAR(Tanggal), DATEPART(WEEK, Tanggal)")
                    sb.AppendLine("ORDER BY YEAR(Tanggal), DATEPART(WEEK, Tanggal)")
                Case "Bulanan"
                    sb.AppendLine("GROUP BY CONVERT(VARCHAR(7), Tanggal, 120)")
                    sb.AppendLine("ORDER BY CONVERT(VARCHAR(7), Tanggal, 120)")
            End Select

            ' --- Eksekusi query ---
            Dim dt As DataTable = ReadSQL(sb.ToString())

            If dt.Rows.Count = 0 Then
                MessageBox.Show("Tidak ada data kunjungan pada rentang tanggal yang dipilih.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            ' --- Tampilkan ke DataGridView2 ---
            DataGridView2.DataSource = dt
            DataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DataGridView2.Columns(0).HeaderText = "Periode"
            DataGridView2.Columns(1).HeaderText = "Jumlah Pasien"
            DataGridView2.Columns(2).HeaderText = "Rata-Rata Waktu (Menit)"

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonDownloadTrend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDownloadTrend.Click
        Try
            ' --- Validasi ---
            If DataGridView2.Rows.Count = 0 Then
                MessageBox.Show("Tidak ada data tren untuk dikirim.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' --- Ambil konfigurasi ---
            Dim cabang As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NoPoli'")
            Dim baseURL As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
            baseURL = baseURL.TrimEnd("/"c)
            Dim apiUrl As String = baseURL & "/api/forecasting/trend"

            Dim poliDipilih As String = If(ComboBoxPoli.SelectedItem IsNot Nothing, ComboBoxPoli.Text, "")
            Dim jaminanDipilih As String = If(ComboBoxJaminan.SelectedItem IsNot Nothing, ComboBoxJaminan.Text, "")

            ' --- Konversi DataGridView ke ArrayList ---
            Dim listData As New ArrayList()

            For Each row As DataGridViewRow In DataGridView2.Rows
                If row.IsNewRow Then Continue For

                Dim item As New Dictionary(Of String, Object)
                Dim t As String = row.Cells("Periode").Value.ToString().Trim()

                ' Format ke yyyy-MM-dd (jika bisa diparse)
                Dim dtTanggal As DateTime
                If DateTime.TryParse(t, dtTanggal) Then
                    t = dtTanggal.ToString("yyyy-MM-dd")
                End If

                item.Add("periode", t)
                item.Add("jumlah_pasien", Convert.ToInt32(row.Cells("JumlahPasien").Value))

                ' --- Pastikan kolom rata-rata waktu pelayanan ada dan memiliki nilai ---
                If DataGridView2.Columns.Contains("RataRataMenit") Then
                    Dim val As Object = row.Cells("RataRataMenit").Value
                    If val IsNot Nothing AndAlso Not IsDBNull(val) AndAlso val.ToString().Trim() <> "" Then
                        item.Add("rata_waktu_pelayanan_menit", Convert.ToDouble(val))
                    End If
                End If

                listData.Add(item)
            Next

            ' --- Susun payload JSON ---
            Dim dataKirim As New Dictionary(Of String, Object)
            dataKirim.Add("data", listData)
            dataKirim.Add("cabang", cabang)
            dataKirim.Add("poli", poliDipilih)
            dataKirim.Add("jaminan", jaminanDipilih)


            Dim jsonData As String = Newtonsoft.Json.JsonConvert.SerializeObject(dataKirim, Newtonsoft.Json.Formatting.Indented)

            ' --- Kirim data ke API ---
            Dim response As String = InsertDataAPIRM(jsonData, apiUrl)

            ' --- Tangani respon ---
            Dim json = JObject.Parse(response)

            If json("status").ToString().ToLower() = "success" Then
                Dim pdfUrl As String = json("url").ToString()
                Process.Start(pdfUrl)
            Else
                MessageBox.Show("Gagal membuat laporan: " & json("message").ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonKunjungan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonKunjungan.Click
        Try
            If ComboBoxTahun.SelectedItem Is Nothing OrElse ComboBoxTahun.Text = "" Then
                MessageBox.Show("Silakan pilih periode tampilan tahun.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim periode As String = ComboBoxTahun.SelectedItem.ToString()

            Dim sb As New StringBuilder()

            sb.AppendLine("WITH PasienBaru AS (")
            sb.AppendLine("    SELECT ")
            sb.AppendLine("        DATENAME(MONTH, CreatedDate) AS NamaBulan,")
            sb.AppendLine("        MONTH(CreatedDate) AS NoBulan,")
            sb.AppendLine("        COUNT(*) AS JumlahPasienBaru")
            sb.AppendLine("    FROM MasterPasien")
            sb.AppendLine("    WHERE YEAR(CreatedDate) = '" & periode & "'")
            sb.AppendLine("    GROUP BY DATENAME(MONTH, CreatedDate), MONTH(CreatedDate)")
            sb.AppendLine("),")
            sb.AppendLine("PasienLamaPoli AS (")
            sb.AppendLine("    SELECT ")
            sb.AppendLine("        DATENAME(MONTH, T.TglPoli) AS NamaBulan,")
            sb.AppendLine("        MONTH(T.TglPoli) AS NoBulan,")
            sb.AppendLine("        COUNT(DISTINCT T.IDInternet) AS JumlahPasienLamaPoli")
            sb.AppendLine("    FROM TransaksiPoli T")
            sb.AppendLine("    INNER JOIN MasterPasien P ON T.IDInternet = P.NoRekamMedis")
            sb.AppendLine("    WHERE ")
            sb.AppendLine("        YEAR(T.TglPoli) = '" & periode & "'")
            sb.AppendLine("        AND YEAR(P.CreatedDate) < '" & periode & "'")
            sb.AppendLine("    GROUP BY DATENAME(MONTH, T.TglPoli), MONTH(T.TglPoli)")
            sb.AppendLine("),")
            sb.AppendLine("PasienLamaGigi AS (")
            sb.AppendLine("    SELECT ")
            sb.AppendLine("        DATENAME(MONTH, G.TglGigi) AS NamaBulan,")
            sb.AppendLine("        MONTH(G.TglGigi) AS NoBulan,")
            sb.AppendLine("        COUNT(DISTINCT G.IDInternet) AS JumlahPasienLamaGigi")
            sb.AppendLine("    FROM TransaksiGigi G")
            sb.AppendLine("    INNER JOIN MasterPasien P ON G.IDInternet = P.NoRekamMedis")
            sb.AppendLine("    WHERE ")
            sb.AppendLine("        YEAR(G.TglGigi) = '" & periode & "'")
            sb.AppendLine("        AND YEAR(P.CreatedDate) < '" & periode & "'")
            sb.AppendLine("    GROUP BY DATENAME(MONTH, G.TglGigi), MONTH(G.TglGigi)")
            sb.AppendLine("),")
            sb.AppendLine("GabungLama AS (")
            sb.AppendLine("    SELECT ")
            sb.AppendLine("        COALESCE(P.NamaBulan, G.NamaBulan) AS NamaBulan,")
            sb.AppendLine("        COALESCE(P.NoBulan, G.NoBulan) AS NoBulan,")
            sb.AppendLine("        ISNULL(P.JumlahPasienLamaPoli, 0) + ISNULL(G.JumlahPasienLamaGigi, 0) AS JumlahPasienLama")
            sb.AppendLine("    FROM PasienLamaPoli P")
            sb.AppendLine("    FULL OUTER JOIN PasienLamaGigi G ON P.NoBulan = G.NoBulan")
            sb.AppendLine(")")
            sb.AppendLine("SELECT ")
            sb.AppendLine("    COALESCE(B.NamaBulan, L.NamaBulan) AS NamaBulan,")
            sb.AppendLine("    COALESCE(B.NoBulan, L.NoBulan) AS NoBulan,")
            sb.AppendLine("    ISNULL(B.JumlahPasienBaru, 0) AS JumlahPasienBaru,")
            sb.AppendLine("    ISNULL(L.JumlahPasienLama, 0) AS JumlahPasienLama,")
            sb.AppendLine("    (ISNULL(B.JumlahPasienBaru, 0) + ISNULL(L.JumlahPasienLama, 0)) AS TotalPasien")
            sb.AppendLine("FROM PasienBaru B")
            sb.AppendLine("FULL OUTER JOIN GabungLama L ON B.NoBulan = L.NoBulan")
            sb.AppendLine("ORDER BY NoBulan;")

            ' --- Eksekusi query ---
            Dim dt As DataTable = ReadSQL(sb.ToString())

            If dt.Rows.Count = 0 Then
                MessageBox.Show("Tidak ada data kunjungan pada rentang periode yang dipilih.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            ' --- Tampilkan ke DataGridView2 ---
            DataGridView3.DataSource = dt
            DataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            DataGridView3.Columns(0).HeaderText = "NamaBulan"
            DataGridView3.Columns(1).HeaderText = "NoBulan"
            DataGridView3.Columns(2).HeaderText = "JumlahPasienBaru"
            DataGridView3.Columns(3).HeaderText = "JumlahPasienLama"
            DataGridView3.Columns(4).HeaderText = "TotalPasien"

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonDownloadKunjungan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDownloadKunjungan.Click
        Try
            If DataGridView3.Rows.Count = 0 Then
                MessageBox.Show("Tidak ada data tren untuk dikirim.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' --- Ambil konfigurasi ---
            Dim cabang As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NoPoli'")
            Dim baseURL As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
            baseURL = baseURL.TrimEnd("/"c)
            Dim apiUrl As String = baseURL & "/api/forecasting/kunjungan"

            Dim periode As String = ""
            If ComboBoxTahun.SelectedItem IsNot Nothing Then
                periode = ComboBoxTahun.Text
            End If

            ' --- Bangun JSON manual ---
            Dim sb As New System.Text.StringBuilder()
            sb.Append("{")
            sb.Append("""cabang"":""" & cabang & """,")
            sb.Append("""periode"":""" & periode & """,")
            sb.Append("""data"":[") ' mulai array data

            Dim rowCount As Integer = 0
            For Each row As DataGridViewRow In DataGridView3.Rows
                If Not row.IsNewRow Then
                    If rowCount > 0 Then sb.Append(",") ' pisahkan antar data

                    sb.Append("{")
                    sb.Append("""NamaBulan"":""" & row.Cells("NamaBulan").Value.ToString().Replace("""", "'") & """,")
                    sb.Append("""JumlahPasienBaru"":" & Val(row.Cells("JumlahPasienBaru").Value) & ",")
                    sb.Append("""JumlahPasienLama"":" & Val(row.Cells("JumlahPasienLama").Value) & ",")
                    sb.Append("""TotalPasien"":" & Val(row.Cells("TotalPasien").Value))
                    sb.Append("}")

                    rowCount += 1
                End If
            Next

            sb.Append("]}") ' tutup array dan object utama

            Dim jsonData As String = sb.ToString()

            ' --- Kirim ke API ---
            Dim response As String = InsertDataAPIRM(jsonData, apiUrl)

            Try
                ' --- Parsing respons JSON ---
                Dim json As JObject = JObject.Parse(response)

                If json("status").ToString().ToLower() = "success" Then
                    Dim pdfUrl As String = json("url").ToString()
                    Process.Start(pdfUrl) ' Buka file PDF di browser
                Else
                    Dim msg As String = ""
                    If json("message") IsNot Nothing Then
                        msg = json("message").ToString()
                    End If
                    MessageBox.Show("Gagal membuat laporan: " & msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            Catch ex As Exception
                MessageBox.Show("Respons API tidak valid: " & ex.Message & vbCrLf & "Isi respons: " & response, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonViewJam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonViewJam.Click
        Try
            ' --- Validasi input dasar ---
            If ComboBoxPoliWaktu.SelectedItem Is Nothing Then
                MessageBox.Show("Silakan pilih Poli terlebih dahulu.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If ComboBoxPeriodeWaktu.SelectedItem Is Nothing Then
                MessageBox.Show("Silakan pilih periode (Jam/Hari).", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If dtWaktuAwal.Value > dtWaktuAkhir.Value Then
                MessageBox.Show("Tanggal awal tidak boleh lebih besar dari tanggal akhir.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' --- Ambil nilai filter ---
            Dim poli As String = ComboBoxPoliWaktu.Text.Trim()
            Dim periode As String = ComboBoxPeriodeWaktu.Text.Trim()
            Dim jaminan As String = ComboBoxJaminanWaktu.Text.Trim()
            Dim tglAwal As String = Format(dtWaktuAwal.Value, "yyyy-MM-dd")
            Dim tglAkhir As String = Format(dtWaktuAkhir.Value, "yyyy-MM-dd")

            ' --- Siapkan query ---
            Dim sb As New StringBuilder()

            ' === SELECT sesuai mode (Jam atau Hari) ===
            If periode.ToLower() = "jam" Then
                sb.AppendLine("SELECT DATENAME(HOUR, ArrivedDate) AS Jam, COUNT(*) AS JumlahPasien")
            Else
                sb.AppendLine("SELECT DATENAME(WEEKDAY, ArrivedDate) AS Hari, COUNT(*) AS JumlahPasien")
            End If

            sb.AppendLine("FROM (")

            ' === Pilih sumber tabel berdasarkan Poli ===
            Select Case poli.ToLower()
                Case "poli gigi & mulut"
                    sb.AppendLine("    SELECT G.ArrivedDate, D.JenisPenagihan")
                    sb.AppendLine("    FROM TransaksiGigi G")
                    sb.AppendLine("    INNER JOIN TransaksiDetail D ON G.NoUrut = D.NoUrut")
                    sb.AppendLine("    WHERE G.ArrivedDate IS NOT NULL")

                Case "gabungan"
                    sb.AppendLine("    SELECT P.ArrivedDate, D.JenisPenagihan")
                    sb.AppendLine("    FROM TransaksiPoli P")
                    sb.AppendLine("    INNER JOIN TransaksiDetail D ON P.NoUrut = D.NoUrut")
                    sb.AppendLine("    WHERE P.ArrivedDate IS NOT NULL")
                    sb.AppendLine("    UNION ALL")
                    sb.AppendLine("    SELECT G.ArrivedDate, D.JenisPenagihan")
                    sb.AppendLine("    FROM TransaksiGigi G")
                    sb.AppendLine("    INNER JOIN TransaksiDetail D ON G.NoUrut = D.NoUrut")
                    sb.AppendLine("    WHERE G.ArrivedDate IS NOT NULL")

                Case Else
                    sb.AppendLine("    SELECT P.ArrivedDate, D.JenisPenagihan")
                    sb.AppendLine("    FROM TransaksiPoli P")
                    sb.AppendLine("    INNER JOIN TransaksiDetail D ON P.NoUrut = D.NoUrut")
                    sb.AppendLine("    WHERE P.ArrivedDate IS NOT NULL")
            End Select

            sb.AppendLine(") AS Gabungan")
            sb.AppendLine("WHERE CAST(ArrivedDate AS DATE) BETWEEN '" & tglAwal & "' AND '" & tglAkhir & "'")

            ' === Filter jaminan (jika bukan semua) ===
            If jaminan.ToLower() <> "gabungan" Then
                sb.AppendLine("AND JenisPenagihan = '" & jaminan & "'")
            End If

            ' === GROUP BY sesuai periode ===
            If periode.ToLower() = "jam" Then
                sb.AppendLine("GROUP BY DATENAME(HOUR, ArrivedDate), DATEPART(HOUR, ArrivedDate)")
                sb.AppendLine("ORDER BY DATEPART(HOUR, ArrivedDate)")
            Else
                sb.AppendLine("GROUP BY DATENAME(WEEKDAY, ArrivedDate), DATEPART(WEEKDAY, ArrivedDate)")
                sb.AppendLine("ORDER BY DATEPART(WEEKDAY, ArrivedDate)")
            End If

            ' --- Jalankan query ---
            Dim dt As DataTable = ReadSQL(sb.ToString())

            ' --- Tampilkan ke DataGridView4 ---
            DataGridView4.DataSource = dt
            DataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            If periode.ToLower() = "jam" Then
                DataGridView4.Columns(0).HeaderText = "Jam"
            Else
                DataGridView4.Columns(0).HeaderText = "Hari"
            End If
            DataGridView4.Columns(1).HeaderText = "Jumlah Pasien"

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonDonwloadJam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDonwloadJam.Click
        Try
            If DataGridView4.Rows.Count = 0 Then
                MessageBox.Show("Tidak ada data waktu pelayanan untuk dikirim.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' --- Ambil konfigurasi ---
            Dim cabang As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NoPoli'")
            Dim baseURL As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
            baseURL = baseURL.TrimEnd("/"c)
            Dim apiUrl As String = baseURL & "/api/forecasting/waktu"

            ' --- Ambil pilihan user ---
            Dim poli As String = If(ComboBoxPoliWaktu.SelectedItem IsNot Nothing, ComboBoxPoliWaktu.Text, "")
            Dim periode As String = If(ComboBoxPeriodeWaktu.SelectedItem IsNot Nothing, ComboBoxPeriodeWaktu.Text, "")
            Dim jaminan As String = If(ComboBoxJaminanWaktu.SelectedItem IsNot Nothing, ComboBoxJaminanWaktu.Text, "")
            Dim tglAwal As String = Format(dtWaktuAwal.Value, "yyyy-MM-dd")
            Dim tglAkhir As String = Format(dtWaktuAkhir.Value, "yyyy-MM-dd")

            ' --- Ambil nama kolom pertama (bisa Jam atau Hari) ---
            Dim kolomUtama As String = DataGridView4.Columns(0).HeaderText

            ' --- Bangun JSON manual ---
            Dim sb As New System.Text.StringBuilder()
            sb.Append("{")
            sb.Append("""cabang"":""" & cabang & """,")
            sb.Append("""poli"":""" & poli & """,")
            sb.Append("""periode"":""" & periode & """,")
            sb.Append("""jaminan"":""" & jaminan & """,")
            sb.Append("""tglAwal"":""" & tglAwal & """,")
            sb.Append("""tglAkhir"":""" & tglAkhir & """,")
            sb.Append("""data"":[")

            Dim first As Boolean = True
            For Each row As DataGridViewRow In DataGridView4.Rows
                If Not row.IsNewRow Then
                    If Not first Then sb.Append(",")
                    first = False

                    sb.Append("{")
                    sb.Append("""" & kolomUtama & """:""" & row.Cells(0).Value.ToString().Replace("""", "'") & """,")
                    sb.Append("""JumlahPasien"":" & Val(row.Cells(1).Value))
                    sb.Append("}")
                End If
            Next

            sb.Append("]}")

            Dim jsonData As String = sb.ToString()

            ' --- (Opsional) Cek hasil JSON ---
            ' MsgBox(jsonData)

            ' --- Kirim ke API ---
            Dim response As String = InsertDataAPIRM(jsonData, apiUrl)

            ' --- Tangani respon ---
            Try
                Dim json As JObject = JObject.Parse(response)

                If json("status").ToString().ToLower() = "success" Then
                    Dim pdfUrl As String = json("url").ToString()
                    Process.Start(pdfUrl)
                Else
                    Dim msg As String = ""
                    If json("message") IsNot Nothing Then msg = json("message").ToString()
                    MessageBox.Show("Gagal membuat laporan: " & msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show("Respons API tidak valid: " & ex.Message & vbCrLf & "Isi respons: " & response, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class