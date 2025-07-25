Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Collections.Generic
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Data.SqlClient
Imports System.Globalization
Public Class Dashboard
    Private Sub LoadChartStatusPoli()
        Try
            Dim whereClause As String = ""
            Dim tanggalAwal = New Date(Date.Today.Year, Date.Today.Month, 1)
            Dim tanggalAkhir As Date

            If DateTimePickerAwal.Checked AndAlso DateTimePickerAkhir.Checked Then
                tanggalAwal = DateTimePickerAwal.Value.Date
                tanggalAkhir = DateTimePickerAkhir.Value.Date

                If tanggalAwal > tanggalAkhir Then
                    MessageBox.Show("Tanggal awal tidak boleh lebih besar dari tanggal akhir.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
            Else
                ' Jika tidak dipilih, gunakan default: hari ini
                tanggalAwal = Date.Today
                tanggalAkhir = Date.Today
            End If

            whereClause = "AND CreatedDate BETWEEN '" & tanggalAwal.ToString("yyyy-MM-dd") & "' AND '" & tanggalAkhir.ToString("yyyy-MM-dd") & "'"

            Dim query As String = "SELECT StatusKeterangan, COUNT(*) AS Jumlah FROM TransaksiPoli " & _
                        "WHERE StatusKeterangan IN ('Sudah Diperiksa', 'Belum Diperiksa', 'Sedang Diperiksa Dokter', 'Sudah Dilakukan TTV') " & _
                        whereClause & _
                        " GROUP BY StatusKeterangan"


            Dim Tbls As DataTable = ReadSQL(query)

            If Chart1 Is Nothing Then
                MessageBox.Show("Chart1 belum tersedia di form.")
                Exit Sub
            End If

            Chart1.Series.Clear()
            Chart1.Titles.Clear()
            Chart1.Legends.Clear()

            ' Judul chart
            'Chart1.Titles.Add("Status Pemeriksaan Poli")
            'Chart1.Titles(0).Font = New Font("Segoe UI", 14, FontStyle.Bold)

            ' Legend
            Chart1.Legends.Add("Legend1")
            Chart1.Legends("Legend1").Docking = DataVisualization.Charting.Docking.Right
            Chart1.Legends("Legend1").Font = New Font("Segoe UI", 9, FontStyle.Regular)

            Chart1.BackColor = Color.Transparent
            Chart1.ChartAreas.Clear()

            Dim area As New DataVisualization.Charting.ChartArea("MainArea")
            area.BackColor = Color.Transparent
            area.BackSecondaryColor = Color.Transparent
            area.BackGradientStyle = DataVisualization.Charting.GradientStyle.None
            area.BorderColor = Color.Transparent
            area.ShadowColor = Color.Transparent
            Chart1.ChartAreas.Add(area)

            Chart1.Legends("Legend1").BackColor = Color.Transparent
            Chart1.Legends("Legend1").BorderColor = Color.Transparent

            Chart1.Series.Add("Status")
            With Chart1.Series("Status")
                .ChartType = DataVisualization.Charting.SeriesChartType.Pie
                .Font = New Font("Segoe UI", 10, FontStyle.Regular)
                .IsValueShownAsLabel = True
                .Legend = "Legend1"
                .Label = "#PERCENT{P0}" ' Menampilkan persentase
                .LegendText = "#VALX"    ' Nama status di legend
                .ToolTip = "#VALX: #VALY pasien"
            End With

            ' Tambahkan point berdasarkan data
            For Each row As DataRow In Tbls.Rows
                Dim status As String = row("StatusKeterangan").ToString()
                Dim jumlah As Integer = Convert.ToInt32(row("Jumlah"))

                Dim dp As New DataVisualization.Charting.DataPoint()
                dp.AxisLabel = status
                dp.YValues = New Double() {jumlah}
                dp.Label = "#PERCENT{P0}"
                dp.ToolTip = status & ": " & jumlah & " pasien"
                dp.LegendText = status

                ' Warna berdasarkan status
                Select Case status
                    Case "Sudah Diperiksa"
                        dp.Color = Color.FromArgb(195, 237, 192)
                    Case "Belum Diperiksa"
                        dp.Color = Color.FromArgb(242, 222, 222)
                    Case "Sedang Diperiksa Dokter"
                        dp.Color = Color.FromArgb(184, 232, 252)
                    Case "Sudah Dilakukan TTV"
                        dp.Color = Color.FromArgb(253, 253, 189)
                    Case Else
                        dp.Color = Color.Gray
                End Select

                Chart1.Series("Status").Points.Add(dp)
            Next

            ' Efek 3D
            Chart1.ChartAreas(0).Area3DStyle.Enable3D = False
            Chart1.ChartAreas(0).BackColor = Color.Transparent

            ' Perbesar ukuran pie chart
            With Chart1.ChartAreas(0)
                '.Position = New DataVisualization.Charting.ElementPosition(5, 10, 90, 80) 'posisi dan ukuran area seluruh chart, termasuk label & axis (dalam persen dari control).
                '.InnerPlotPosition = New DataVisualization.Charting.ElementPosition(20, 20, 80, 80) 'posisi dan ukuran area pie-nya sendiri.
            End With

        Catch ex As Exception
            MessageBox.Show("Gagal menampilkan chart: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadChartKunjungan()
        Try
            Dim bulan As Integer = DateTime.Now.Month
            Dim tahun As Integer = DateTime.Now.Year
            Dim namaBulanIndonesia As String = New DateTime(tahun, bulan, 1).ToString("MMMM", New CultureInfo("id-ID"))

            Dim query As String = "SELECT CAST(TanggalTransaksi AS DATE) AS Tanggal, COUNT(*) AS JumlahKunjungan " & _
                                  "FROM TransaksiDetail " & _
                                  "WHERE MONTH(TanggalTransaksi) = " & bulan & " AND YEAR(TanggalTransaksi) = " & tahun & " AND DeletedBy IS NULL " & _
                                  "GROUP BY CAST(TanggalTransaksi AS DATE) " & _
                                  "ORDER BY Tanggal ASC"

            Dim tbl As DataTable = ReadSQL(query)

            Chart2.Series.Clear()
            Chart2.Titles.Clear()
            Chart2.Legends.Clear()
            Chart2.ChartAreas.Clear()

            ' Tambahkan ChartArea agar bisa atur sumbu lebih rapi
            Dim area As New DataVisualization.Charting.ChartArea("MainArea")
            area.AxisX.Title = "Tanggal"
            area.AxisY.Title = "Jumlah Pasien"
            area.AxisX.MajorGrid.LineColor = Color.LightGray
            area.AxisY.MajorGrid.LineColor = Color.LightGray
            Chart2.ChartAreas.Add(area)

            Chart2.Titles.Add("Jumlah Kunjungan Harian - " & namaBulanIndonesia & " " & tahun)
            Chart2.Titles(0).Font = New Font("Segoe UI", 12, FontStyle.Bold)

            Chart2.Series.Add("Kunjungan")
            With Chart2.Series("Kunjungan")
                .ChartType = DataVisualization.Charting.SeriesChartType.Spline
                .BorderWidth = 3
                .Color = Color.FromArgb(1, 87, 155)
                .MarkerStyle = DataVisualization.Charting.MarkerStyle.Circle
                .MarkerSize = 7
                .MarkerColor = Color.Orange
                .IsValueShownAsLabel = False
                .ToolTip = "#VALX: #VALY pasien"
            End With

            For Each row As DataRow In tbl.Rows
                Dim tanggal As Date = Convert.ToDateTime(row("Tanggal"))
                Dim jumlah As Integer = Convert.ToInt32(row("JumlahKunjungan"))

                Dim dp As New DataVisualization.Charting.DataPoint()
                dp.AxisLabel = tanggal.ToString("dd MMM")
                dp.YValues = New Double() {jumlah}
                dp.ToolTip = tanggal.ToString("dd MMM yyyy") & ": " & jumlah.ToString() & " pasien"

                Chart2.Series("Kunjungan").Points.Add(dp)
            Next

        Catch ex As Exception
            MessageBox.Show("Gagal menampilkan chart kunjungan: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadChartDiagnosa()
        Try
            Dim bulan As Integer = DateTime.Now.Month
            Dim tahun As Integer = DateTime.Now.Year
            Dim namaBulanIndonesia As String = New DateTime(tahun, bulan, 1).ToString("MMMM", New CultureInfo("id-ID"))

            'Chart3.Titles.Add("10 Diagnosa Terbanyak Bulan " & namaBulanIndonesia & " " & tahun)
            'Chart3.Titles(0).Font = New Font("Segoe UI", 12, FontStyle.Bold)

            Label1Diagnosa.Text = "10 Diagnosa Terbanyak Bulan " & StrConv(namaBulanIndonesia, VbStrConv.ProperCase) & " " & tahun.ToString()

            Dim query As String = "SELECT TOP 10 " & _
                                  "KodeDiagnosa, " & _
                                  "KeteranganDiagnosa AS [Nama Diagnosa], " & _
                                  "COUNT(KodeDiagnosa) AS [Jumlah] " & _
                                  "FROM TransaksiDetailDiagnosa " & _
                                  "WHERE DeletedDate IS NULL " & _
                                  "AND NoTransaksi IN ( " & _
                                      "SELECT NoUrut FROM TransaksiDetail " & _
                                      "WHERE YEAR(TanggalTransaksi) = " & tahun & " " & _
                                      "AND MONTH(TanggalTransaksi) = " & bulan & _
                                  ") " & _
                                  "GROUP BY KodeDiagnosa, KeteranganDiagnosa " & _
                                  "ORDER BY COUNT(KodeDiagnosa) DESC"

            Dim tbl As DataTable = ReadSQL(query)

            Chart3.Series.Clear()
            Chart3.Titles.Clear()
            Chart3.Legends.Clear()

            Chart3.Legends.Add("Legend1")
            Chart3.Legends("Legend1").Docking = DataVisualization.Charting.Docking.Right
            Chart3.Legends("Legend1").Font = New Font("Segoe UI", 9, FontStyle.Regular)

            Chart3.Series.Add("Diagnosa")
            With Chart3.Series("Diagnosa")
                .ChartType = DataVisualization.Charting.SeriesChartType.Doughnut
                .Font = New Font("Segoe UI", 10, FontStyle.Regular)
                .IsValueShownAsLabel = True
                .Legend = "Legend1"
                .Label = "#PERCENT{P0}" ' label di tengah pie
                .LegendText = "#VALX"   ' VALX = KodeDiagnosa dari AddXY
            End With

            For Each row As DataRow In tbl.Rows
                Dim kodeDiagnosa As String = row("KodeDiagnosa").ToString()
                Dim namaDiagnosa As String = row("Nama Diagnosa").ToString()
                Dim jumlah As Integer = Convert.ToInt32(row("Jumlah"))

                Dim dp As New DataVisualization.Charting.DataPoint()
                dp.AxisLabel = kodeDiagnosa
                dp.YValues = New Double() {jumlah}
                dp.Label = "#PERCENT{P0}"
                dp.LegendText = kodeDiagnosa
                dp.ToolTip = namaDiagnosa & ": " & jumlah.ToString() & " pasien"

                Chart3.Series("Diagnosa").Points.Add(dp)
            Next

        Catch ex As Exception
            MessageBox.Show("Gagal menampilkan chart: " & ex.Message)
        End Try
    End Sub

    Public Sub RoundPanel(ByVal pnl As Panel, ByVal radius As Integer)
        Dim path As New Drawing2D.GraphicsPath()
        path.StartFigure()
        path.AddArc(New Rectangle(0, 0, radius, radius), 180, 90)
        path.AddArc(New Rectangle(pnl.Width - radius, 0, radius, radius), -90, 90)
        path.AddArc(New Rectangle(pnl.Width - radius, pnl.Height - radius, radius, radius), 0, 90)
        path.AddArc(New Rectangle(0, pnl.Height - radius, radius, radius), 90, 90)
        path.CloseFigure()

        pnl.Region = New Region(path)
    End Sub


    Private Sub LoadPasienBaru()
        Try
            Dim query As String = "SELECT COUNT(*) AS JumlahPasienBaru " & _
                      "FROM MasterPasien " & _
                      "WHERE YEAR(CreatedDate) = YEAR(GETDATE()) " & _
                      "AND MONTH(CreatedDate) = MONTH(GETDATE())"


            Dim tbl As DataTable = ReadSQL(query)
            If tbl.Rows.Count > 0 Then
                Dim jumlah As Integer = Convert.ToInt32(tbl.Rows(0)("JumlahPasienBaru"))
                LabelPasien.Text = jumlah
                LabelPasien.ForeColor = Color.Coral
                LabelPasien.TextAlign = ContentAlignment.MiddleCenter
            End If
        Catch ex As Exception
            MessageBox.Show("Gagal menampilkan data: " & ex.Message)
        End Try
    End Sub

    Private Sub Dashboard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        Me.Dock = DockStyle.Fill
        Me.BackgroundImage = Image.FromFile(Application.StartupPath + "\Image\wallpaper.jpg")
        Me.BackgroundImageLayout = ImageLayout.Stretch

        With Me
            .ControlBox = False
            .FormBorderStyle = FormBorderStyle.None
        End With

        'btnClose.Dispose()

        ' Set tanggal awal ke tanggal 1 di bulan ini
        Dim awalBulan As New Date(Date.Today.Year, Date.Today.Month, 1)
        DateTimePickerAwal.Value = awalBulan

        ' Tanggal akhir tetap default ke hari ini
        DateTimePickerAkhir.Value = Date.Today
        LoadChartStatusPoli()
        LoadChartKunjungan()
        LoadChartDiagnosa()
        LoadPasienBaru()

        Dim culture As New CultureInfo("id-ID")
        Dim tanggalFormat As String = Date.Today.ToString("dddd, dd MMMM yyyy", culture)
        LabelTittlePoli.Text = "Jumlah Kunjungan Poli Hari " & tanggalFormat
        LabelTittlePoli.TextAlign = ContentAlignment.MiddleCenter

        Dim lokasiPoli As DataTable = ReadSQL("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NoPoli'")

        If lokasiPoli.Rows.Count > 0 Then
            Dim row As DataRow = lokasiPoli.Rows(0)
            Dim strValue As String = row("StrValue").ToString()

            If strValue = "L003" Then
                Dim jumlahUmum As Integer = ReadSQLNIK("SELECT COUNT(*) FROM TransaksiDetail WHERE JenisPoli = 'POLI KECANTIKAN' AND DeletedBy IS NULL AND CONVERT(DATE, CreatedDate) = CONVERT(DATE, GETDATE())")
                LabelPoliUmum.Text = jumlahUmum.ToString()
                LabelPoliUmum.ForeColor = Color.Coral
                LabelPoliUmum.TextAlign = ContentAlignment.MiddleCenter
                Label3.Visible = True
                Panel8.BackgroundImage = Image.FromFile(Application.StartupPath + "\Image\icon\Hair.png")

                Dim jumlahGigiMulut As Integer = ReadSQLNIK("SELECT COUNT(*) FROM TransaksiDetail WHERE JenisPoli = 'POLI HBOT' AND DeletedBy IS NULL AND CONVERT(DATE, CreatedDate) = CONVERT(DATE, GETDATE())")
                LabelPoliGigi.Text = jumlahGigiMulut.ToString()
                LabelPoliGigi.ForeColor = Color.Coral
                LabelPoliUmum.TextAlign = ContentAlignment.MiddleCenter
                Label7.Visible = True
                Label4.Visible = False
                Panel10.BackgroundImage = Image.FromFile(Application.StartupPath + "\Image\icon\oxygen.png")

                Dim jumlahKia As Integer = ReadSQLNIK("SELECT COUNT(*) FROM TransaksiDetail WHERE JenisPoli = 'POLI FISIOTERAPI' AND DeletedBy IS NULL AND CONVERT(DATE, CreatedDate) = CONVERT(DATE, GETDATE())")
                LabelPoliKia.Text = jumlahKia.ToString()
                LabelPoliKia.ForeColor = Color.Coral
                LabelPoliKia.TextAlign = ContentAlignment.MiddleCenter
                Label8.Visible = True
                Label5.Visible = False
                Panel5.Visible = False
                Panel4.Visible = False
                Panel12.Visible = False
                Panel9.BackgroundImage = Image.FromFile(Application.StartupPath + "\Image\icon\Bone.png")
                Panel6.Location = New Point(959, 212)
            Else
                Dim jumlahUmum As Integer = ReadSQLNIK("SELECT COUNT(*) FROM TransaksiDetail WHERE JenisPoli = 'POLI UMUM' AND DeletedBy IS NULL AND CONVERT(DATE, CreatedDate) = CONVERT(DATE, GETDATE())")
                LabelPoliUmum.Text = jumlahUmum.ToString()
                LabelPoliUmum.ForeColor = Color.Coral
                LabelPoliUmum.TextAlign = ContentAlignment.MiddleCenter

                Dim jumlahGigiMulut As Integer = ReadSQLNIK("SELECT COUNT(*) FROM TransaksiDetail WHERE JenisPoli = 'POLI GIGI & MULUT' AND DeletedBy IS NULL AND CONVERT(DATE, CreatedDate) = CONVERT(DATE, GETDATE())")
                LabelPoliGigi.Text = jumlahGigiMulut.ToString()
                LabelPoliGigi.ForeColor = Color.Coral
                LabelPoliUmum.TextAlign = ContentAlignment.MiddleCenter

                Dim jumlahKia As Integer = ReadSQLNIK("SELECT COUNT(*) FROM TransaksiDetail WHERE JenisPoli = 'POLI KIA' AND DeletedBy IS NULL AND CONVERT(DATE, CreatedDate) = CONVERT(DATE, GETDATE())")
                LabelPoliKia.Text = jumlahKia.ToString()
                LabelPoliKia.ForeColor = Color.Coral
                LabelPoliKia.TextAlign = ContentAlignment.MiddleCenter

                Dim jumlahKb As Integer = ReadSQLNIK("SELECT COUNT(*) FROM TransaksiDetail WHERE JenisPoli = 'POLI KB' AND DeletedBy IS NULL AND CONVERT(DATE, CreatedDate) = CONVERT(DATE, GETDATE())")
                LabelPoliKb.Text = jumlahKb.ToString()
                LabelPoliKb.ForeColor = Color.Coral
                LabelPoliKb.TextAlign = ContentAlignment.MiddleCenter

                Dim jumlahLab As Integer = ReadSQLNIK("SELECT COUNT(*) FROM TransaksiDetail WHERE JenisPoli = 'LABORATORIUM' AND DeletedBy IS NULL AND CONVERT(DATE, CreatedDate) = CONVERT(DATE, GETDATE())")
                LabelLab.Text = jumlahLab.ToString()
                LabelLab.ForeColor = Color.Coral
                LabelLab.TextAlign = ContentAlignment.MiddleCenter
            End If
        Else

        End If

        RoundPanel(Panel10, 20)
        RoundPanel(Panel9, 20)
        RoundPanel(Panel8, 20)
        RoundPanel(Panel6, 20)
        RoundPanel(Panel7, 20)
        RoundPanel(Panel4, 20)
        RoundPanel(Panel5, 20)
        RoundPanel(Panel3, 20)
        RoundPanel(Panel2, 20)
        RoundPanel(Panel1, 20)
        RoundPanel(Panel12, 20)
        Panel1.BackColor = Color.WhiteSmoke
    End Sub

    Private Sub DateTimePickerAwal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePickerAwal.ValueChanged
        LoadChartStatusPoli()
    End Sub

    Private Sub DateTimePickerAkhir_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimePickerAkhir.ValueChanged
        LoadChartStatusPoli()
    End Sub

    Private Sub ButtonClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClose.Click
        Me.Close()
    End Sub
End Class