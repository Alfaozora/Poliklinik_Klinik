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
Public Class FormPrediksiPasien

    'Private Sub ButtonKirim_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonKirim.Click
    '    Try
    '        If ComboBoxHari.SelectedItem Is Nothing OrElse ComboBoxHari.Text = "" Then
    '            MessageBox.Show("Silakan pilih rentang prediksi (1, 7, atau 30 hari).", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            Exit Sub
    '        End If

    '        Dim selectedHari As Integer = CInt(ComboBoxHari.SelectedItem)

    '        ' --- Tentukan rentang hari berdasarkan pilihan
    '        Dim rentangHari As Integer = 90 ' default
    '        Select Case selectedHari
    '            Case "Harian"
    '                rentangHari = 90
    '            Case "Mingguan"
    '                rentangHari = 180
    '            Case "Bulanan"
    '                rentangHari = 365
    '        End Select

    '        ' --- Bangun query dinamis
    '        Dim sb As New StringBuilder()
    '        sb.AppendLine("SELECT")
    '        sb.AppendLine("    CONVERT(VARCHAR(10), Tanggal, 120) AS Tanggal,")
    '        sb.AppendLine("    COUNT(*) AS JumlahPasien")
    '        sb.AppendLine("FROM (")
    '        sb.AppendLine("    SELECT TglPoli AS Tanggal, NoUrut FROM TransaksiPoli")
    '        sb.AppendLine("    UNION ALL")
    '        sb.AppendLine("    SELECT TglGigi AS Tanggal, NoUrut FROM TransaksiGigi")
    '        sb.AppendLine(") AS Gabungan")
    '        sb.AppendLine("WHERE")
    '        sb.AppendLine("    Tanggal >= DATEADD(DAY, -" & rentangHari & ", CAST(GETDATE() AS DATE))")
    '        sb.AppendLine("    AND Tanggal < CAST(GETDATE() AS DATE)")
    '        sb.AppendLine("GROUP BY CONVERT(VARCHAR(10), Tanggal, 120)")
    '        sb.AppendLine("ORDER BY Tanggal ASC;")

    '        ' --- 2. Eksekusi query dan ambil hasil ke DataTable
    '        Dim dt As DataTable = ReadSQL(sb.ToString())

    '        If dt.Rows.Count = 0 Then
    '            MsgBox("Tidak ada data kunjungan untuk 90 hari terakhir.", MsgBoxStyle.Exclamation, "Prediksi Gagal")
    '            Exit Sub
    '        End If

    '        ' --- 3. Konversi hasil ke ArrayList agar kompatibel dengan VB.NET 2008
    '        Dim listData As New ArrayList()
    '        For Each row As DataRow In dt.Rows
    '            Dim item As New Dictionary(Of String, Object)
    '            item.Add("Tanggal", row("Tanggal").ToString())
    '            item.Add("JumlahPasien", Convert.ToInt32(row("JumlahPasien")))
    '            listData.Add(item)
    '        Next

    '        Dim dataKirim As New Dictionary(Of String, Object)
    '        dataKirim.Add("data", listData)
    '        dataKirim.Add("days_ahead", selectedHari)

    '        ' --- 4. Serialize ke JSON
    '        Dim jsonData As String = JsonConvert.SerializeObject(dataKirim)

    '        ' --- 5. Ambil URL API dari MsConfig
    '        Dim baseURL As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
    '        baseURL = baseURL.TrimEnd("/"c)
    '        Dim apiUrl As String = baseURL & "/api/predict-patient"

    '        ' --- 6. Kirim JSON ke API Laravel
    '        Dim response As String = InsertDataAPIRM(jsonData, apiUrl)

    '        'Dim hasil = JsonConvert.DeserializeObject(Of JObject)(response)
    '        'If hasil("status").ToString() = "success" Then
    '        '    Dim prediksi As Double = hasil("prediksi")
    '        '    Dim alpha As Double = hasil("detail")("best_alpha")
    '        '    Dim mape As Double = hasil("detail")("mape_validasi")

    '        '    MsgBox("Prediksi kunjungan besok: " & prediksi & vbCrLf & "Alpha terbaik: " & alpha & vbCrLf & "MAPE: " & mape & "%", MsgBoxStyle.Information, "Hasil Prediksi")
    '        'Else
    '        '    MsgBox("Gagal memproses: " & hasil("message").ToString(), MsgBoxStyle.Exclamation, "Prediksi Gagal")
    '        'End If


    '        ' --- 7. Tampilkan hasil
    '        'Try
    '        '    Dim hasil = JsonConvert.DeserializeObject(Of JObject)(response)

    '        '    If hasil("status").ToString().ToLower() = "success" Then
    '        '        Dim prediksiArray As JArray = hasil("prediksi")
    '        '        Dim alpha As Double = hasil("detail")("best_alpha")
    '        '        Dim mape As Double = hasil("detail")("mape_validasi")

    '        '        ' --- Reset DataGridView ---
    '        '        DataGridView1.Rows.Clear()
    '        '        DataGridView1.Columns.Clear()

    '        '        ' --- Tambahkan kolom ---
    '        '        DataGridView1.Columns.Add("TanggalPrediksi", "Tanggal")
    '        '        DataGridView1.Columns.Add("Prediksi", "Prediksi Jumlah Pasien")
    '        '        DataGridView1.Columns.Add("Alpha", "Alpha Terbaik")
    '        '        DataGridView1.Columns.Add("MAPE", "MAPE Validasi (%)")

    '        '        ' --- Atur tampilan ---
    '        '        DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    '        '        DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        '        DataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

    '        '        ' --- Tambahkan hasil prediksi ke grid ---
    '        '        Dim baseDate As DateTime = DateTime.Now
    '        '        For i As Integer = 0 To prediksiArray.Count - 1
    '        '            Dim tanggalPrediksi As String = baseDate.AddDays(i + 1).ToString("yyyy-MM-dd")
    '        '            Dim prediksiValue As Double = Math.Round(prediksiArray(i).ToObject(Of Double)(), 2)
    '        '            DataGridView1.Rows.Add(tanggalPrediksi, prediksiValue, Math.Round(alpha, 2), Math.Round(mape, 2))
    '        '        Next

    '        '    Else
    '        '        MsgBox("Gagal memproses: " & hasil("message").ToString(), MsgBoxStyle.Exclamation, "Prediksi Gagal")
    '        '    End If

    '        'Catch parseEx As Exception
    '        '    MsgBox("Respons tidak dikenali dari server: " & vbCrLf & response, MsgBoxStyle.Exclamation, "Prediksi")
    '        'End Try

    '        Try
    '            Dim hasil = JsonConvert.DeserializeObject(Of JObject)(response)

    '            If hasil("status").ToString().ToLower() = "success" Then
    '                Dim prediksiArray As JArray = hasil("prediksi")
    '                Dim alpha As Double = hasil("detail")("best_alpha")
    '                Dim mape As Double = hasil("detail")("mape_validasi")

    '                ' --- Reset DataGridView ---
    '                DataGridView1.Rows.Clear()
    '                DataGridView1.Columns.Clear()

    '                ' --- Tambahkan kolom ---
    '                DataGridView1.Columns.Add("Periode", "Periode")
    '                DataGridView1.Columns.Add("Prediksi", "Prediksi Jumlah Pasien")
    '                DataGridView1.Columns.Add("Alpha", "Alpha Terbaik")
    '                DataGridView1.Columns.Add("MAPE", "MAPE Validasi (%)")

    '                ' --- Atur tampilan ---
    '                DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    '                DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '                DataGridView1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

    '                ' --- Pilihan mode forecasting ---
    '                Dim modeForecast As String = ComboBoxHari.SelectedItem.ToString().ToLower() ' <- pastikan combobox punya item: Harian, Mingguan, Bulanan

    '                Dim hasilPrediksi As Double = 0
    '                Dim periodeLabel As String = ""

    '                Select Case modeForecast
    '                    Case "Harian"
    '                        hasilPrediksi = prediksiArray(0).ToObject(Of Double)()
    '                        periodeLabel = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd")

    '                    Case "Mingguan"
    '                        ' total prediksi 7 hari
    '                        hasilPrediksi = prediksiArray.Take(7).Sum(Function(x) x.ToObject(Of Double)())
    '                        periodeLabel = "Minggu Depan (" & DateTime.Now.AddDays(1).ToString("dd MMM") & _
    '                                        " - " & DateTime.Now.AddDays(7).ToString("dd MMM yyyy") & ")"

    '                    Case "Bulanan"
    '                        ' total prediksi 30 hari
    '                        hasilPrediksi = prediksiArray.Take(30).Sum(Function(x) x.ToObject(Of Double)())
    '                        periodeLabel = "Bulan Depan (" & DateTime.Now.AddMonths(1).ToString("MMMM yyyy") & ")"

    '                    Case Else
    '                        MsgBox("Silakan pilih jenis forecasting terlebih dahulu.", MsgBoxStyle.Exclamation, "Validasi")
    '                        Exit Sub
    '                End Select

    '                ' --- Tambahkan hasil ke grid (1 baris saja) ---
    '                DataGridView1.Rows.Add(periodeLabel, Math.Round(hasilPrediksi, 2), Math.Round(alpha, 2), Math.Round(mape, 2))

    '            Else
    '                MsgBox("Gagal memproses: " & hasil("message").ToString(), MsgBoxStyle.Exclamation, "Prediksi Gagal")
    '            End If

    '        Catch ex As Exception
    '            MsgBox("Respons tidak dikenali dari server: " & vbCrLf & response, MsgBoxStyle.Exclamation, "Prediksi")
    '        End Try

    '    Catch ex As Exception
    '        MsgBox("Terjadi kesalahan: " & ex.Message, MsgBoxStyle.Critical, "Error Prediksi")
    '    End Try
    'End Sub

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

            ' --- Ambil URL API dari MsConfig ---
            Dim baseURL As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
            baseURL = baseURL.TrimEnd("/"c)
            Dim apiUrl As String = baseURL & "/api/predict-patient"

            ' --- Kirim data ke API ---
            Dim response As String = InsertDataAPIRM(jsonData, apiUrl)

            ' --- Proses respons dari server ---
            Try
                Dim hasil = JsonConvert.DeserializeObject(Of JObject)(response)

                If hasil("status").ToString().ToLower() = "success" Then
                    Dim prediksiArray As JArray = hasil("prediksi")
                    Dim alpha As Double = hasil("detail")("best_alpha")
                    Dim mape As Double = hasil("detail")("mape_validasi")

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
End Class