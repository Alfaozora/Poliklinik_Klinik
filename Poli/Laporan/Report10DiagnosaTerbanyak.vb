Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Drawing
Imports Newtonsoft.Json
Imports Newtonsoft
Imports System.Security.Cryptography
Imports System.Collections.Generic
Imports Newtonsoft.Json.Linq
Imports System.Web.UI.WebControls

Public Class Report10DiagnosaTerbanyak
    Private formName As String = "DAFTAR 10 DIAGNOSA TERBANYAK"
    Private userInput As String = PoliKlinik.Lbluser.Text

    Private Sub PanelTop_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelTop.Paint
        Try
            e.Graphics.DrawString(formName, New Font("Arial", 12, FontStyle.Bold), Brushes.White, New Point(10, 10))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub CreateDataGridViewKunjunganPasien()
        ' Add columns
        DataGridViewDaftarDiagnosa.Columns.Add("ColumnKodeDiagnosa", "Kode Diagnosa")
        DataGridViewDaftarDiagnosa.Columns.Add("ColumnNamaDiagnosa", "Nama Diagnosa")
        DataGridViewDaftarDiagnosa.Columns.Add("ColumnJumlah", "Jumlah")

        ' Setting
        DataGridViewDaftarDiagnosa.DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        DataGridViewDaftarDiagnosa.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI Semibold", 10, FontStyle.Bold)
        DataGridViewDaftarDiagnosa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        ' Mengatur lebar maksimum untuk kolom kode diagnosa
        Dim kodeDiagnosaColumn As DataGridViewColumn = DataGridViewDaftarDiagnosa.Columns("ColumnKodeDiagnosa")
        kodeDiagnosaColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None ' Menonaktifkan penyesuaian otomatis
        kodeDiagnosaColumn.Width = 150 ' Mengatur lebar maksimums

        ' Mengatur lebar maksimum untuk kolom kode diagnosa
        Dim jumlahDiagnosaColumn As DataGridViewColumn = DataGridViewDaftarDiagnosa.Columns("ColumnJumlah")
        jumlahDiagnosaColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None ' Menonaktifkan penyesuaian otomatis
        jumlahDiagnosaColumn.Width = 150 ' Mengatur lebar maksimums
    End Sub

    Private Sub Find_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Control.CheckForIllegalCrossThreadCalls = False
            Me.MdiParent = PoliKlinik
            Me.Dock = DockStyle.Fill

            ' Clear data
            SetAwal()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub SetAwal()
        ' Set ComboBox Bulan
        ComboBoxBulan.Items.Clear()
        LoadComboBoxBulan()
        'ComboBoxBulan.SelectedIndex = -1

        ' Set ComboBox Tahun
        ComboBoxTahun.Items.Clear()
        LoadComboBoxTahun()
        'ComboBoxTahun.SelectedIndex = -1

        ' Set ComboBox Poli Tujuan
        ComboBoxPoliTujuan.Items.Clear()
        ComboBoxPoliTujuan.Items.Add("Semua Transaksi")
        Dim tblsPoliTujuan As DataTable = ReadSQL("SELECT * FROM MasterPoliTujuan WHERE PoliSakit = 'True'")
        For Each TrowPoliTujuan As DataRow In tblsPoliTujuan.Rows
            ComboBoxPoliTujuan.Items.Add(TrowPoliTujuan("NamaPoli"))
        Next
        ComboBoxPoliTujuan.SelectedIndex = 0

        ComboBoxTingkatPelayanan.SelectedIndex = 0
        ComboBoxIndikator.SelectedIndex = 0

        ' Create DataGridView
        CreateDataGridViewKunjunganPasien()
        ButtonSearchDiagnosa.PerformClick()
    End Sub

    Private Sub LoadComboBoxBulan()
        ComboBoxBulan.Items.Add("Januari")
        ComboBoxBulan.Items.Add("Februari")
        ComboBoxBulan.Items.Add("Maret")
        ComboBoxBulan.Items.Add("April")
        ComboBoxBulan.Items.Add("Mei")
        ComboBoxBulan.Items.Add("Juni")
        ComboBoxBulan.Items.Add("Juli")
        ComboBoxBulan.Items.Add("Agustus")
        ComboBoxBulan.Items.Add("September")
        ComboBoxBulan.Items.Add("Oktober")
        ComboBoxBulan.Items.Add("November")
        ComboBoxBulan.Items.Add("Desember")

        'ComboBoxBulan.SelectedIndex = 0
        ' Set default bulan
        Dim bulanSekarang As Integer = DateTime.Now.Month
        ComboBoxBulan.SelectedIndex = bulanSekarang - 1 ' Indeks dimulai dari 0, sedangkan bulan dimulai dari 1
    End Sub

    Private Sub LoadComboBoxTahun()
        Dim vartahun As Integer = Date.Today.Year
        ComboBoxTahun.Items.Add(vartahun)
        ComboBoxTahun.Items.Add(vartahun - 1)
        ComboBoxTahun.Items.Add(vartahun - 2)
        ComboBoxTahun.Items.Add(vartahun - 3)
        ComboBoxTahun.Items.Add(vartahun - 4)

        'ComboBoxTahun.SelectedIndex = 0
        ' Set default tahun
        Dim tahunSekarang As Integer = DateTime.Now.Year
        ComboBoxTahun.Text = tahunSekarang.ToString()
    End Sub

    Private Sub SearchDataDiagnosa()
        If Checking() = True Then
            DataGridViewDaftarDiagnosa.Rows.Clear()

            Dim Tbls As DataTable = LoadDataDiagnosa()

            If Tbls.Rows.Count > 0 Then
                For Each Trow As DataRow In Tbls.Rows
                    DataGridViewDaftarDiagnosa.Rows.Add(New String() {"" & Trow("Kode Diagnosa") & "", "" & Trow("Nama Diagnosa") & "", "" & Trow("Jumlah") & ""})
                Next

                DataGridViewDaftarDiagnosa.CurrentCell = Nothing
            Else
                MsgBox("Data tidak ditemukan.", MsgBoxStyle.Exclamation, "Warning!")
            End If
        End If
    End Sub

    Function Checking() As Boolean
        If ComboBoxPoliTujuan.SelectedIndex = -1 Then
            MsgBox("Pilih poli tujuan terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        Return True
    End Function

    Private Sub ButtonButtonSearchDiagnosa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSearchDiagnosa.Click
        SearchDataDiagnosa()
    End Sub

    Private Sub ButtonCetakDiagnosa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCetakDiagnosa.Click
        CetakDataDiagnosa()
    End Sub

    Private Sub CetakDataDiagnosa()
        Dim Tbls As DataTable = LoadDataDiagnosa()

        If Tbls.Rows.Count > 0 Then
            Report = New XtraReport

            Dim kodePPK As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'KodePPK'")
            Dim namaPPK As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NamaPPK'")

            Report = XtraReport.FromFile(Application.StartupPath + "\Reports\Klinik\Laporan10Diagnosa.repx", True)
            Report.DataSource = Tbls

            Report.Bands.Item(BandKind.ReportHeader).Controls("xrLabelFKTP").Text = namaPPK & " - " & kodePPK
            Report.Bands.Item(BandKind.ReportHeader).Controls("xrLabelBulan").Text = ComboBoxBulan.Text & " " & ComboBoxTahun.Text
            Report.Bands.Item(BandKind.ReportHeader).Controls("xrLabelPelayanan").Text = ComboBoxTingkatPelayanan.Text
            Report.Bands.Item(BandKind.ReportHeader).Controls("xrLabelIndikator").Text = ComboBoxIndikator.Text
            Report.Bands.Item(BandKind.ReportHeader).Controls("xrLabelPoli").Text = ComboBoxPoliTujuan.Text

            Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:ss") & " By " & PoliKlinik.Lbluser.Text

            'Report.RunDesigner()
            Report.ShowPreview()
        Else
            MsgBox("Data tidak ditemukan.", MsgBoxStyle.Exclamation, "Warning!")
        End If
    End Sub

    Function LoadDataDiagnosa() As DataTable
        Dim queryString As String = ""

        ' Set Bulan & Tahun
        Dim bulanSearch As String = Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(ComboBoxBulan.Text, "Januari", "01"), "Februari", "02"), "Maret", "03"), "April", "04"), "Mei", "05"), "Juni", "06"), "Juli", "07"), "Agustus", "08"), "September", "09"), "Oktober", "10"), "November", "11"), "Desember", "12")
        Dim tahunSearch As String = ComboBoxTahun.Text

        ' Set Tingkat Pelayanan
        Dim tingkatPelayananSearch As String = ""
        If ComboBoxTingkatPelayanan.Text <> "Semua" Then
            tingkatPelayananSearch = " AND JenisRawat = '" & ComboBoxTingkatPelayanan.Text & "'"
        End If

        ' Set Indikator
        Dim indikatorSearch As String = ""
        If ComboBoxIndikator.Text = "Kunjungan" Then
            indikatorSearch = " AND StatusPulang LIKE '%Berobat Jalan%'"
        ElseIf ComboBoxIndikator.Text = "Rujukan" Then
            indikatorSearch = " AND StatusPulang LIKE '%Rujuk%'"
        End If

        ' Set Jenis Poli
        Dim jenisPoliSearch As String = ""
        If ComboBoxPoliTujuan.Text <> "Semua Transaksi" Then
            jenisPoliSearch = " AND JenisPoli = '" & ComboBoxPoliTujuan.Text & "'"
        End If

        queryString = "SELECT TOP(10) ROW_NUMBER() OVER (ORDER BY COUNT(KodeDiagnosa) DESC) AS 'No', KodeDiagnosa AS 'Kode Diagnosa', KeteranganDiagnosa AS 'Nama Diagnosa', COUNT(KodeDiagnosa) AS 'Jumlah' FROM TransaksiDetailDiagnosa " & _
                      "WHERE DeletedDate IS NULL AND NoTransaksi IN (SELECT NoUrut FROM TransaksiDetail WHERE YEAR(TanggalTransaksi) = '" & tahunSearch & "' AND MONTH(TanggalTransaksi) = '" & bulanSearch & "'" & tingkatPelayananSearch & indikatorSearch & jenisPoliSearch & ") " & _
                      "GROUP BY KodeDiagnosa, KeteranganDiagnosa " & _
                      "ORDER BY COUNT(KodeDiagnosa) DESC"

        Dim Tbls As DataTable = ReadSQL(queryString)

        Return Tbls
    End Function
End Class