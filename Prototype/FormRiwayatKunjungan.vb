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

Public Class FormRiwayatKunjungan
    Private formName As String = "RIWAYAT KUNJUNGAN"
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
        ' Bersihkan kolom jika sudah pernah dibuat
        DataGridViewDaftarDiagnosa.Columns.Clear()
        DataGridViewDaftarDiagnosa.ReadOnly = False

        ' Kolom data
        DataGridViewDaftarDiagnosa.Columns.Add("ColumnNoTransaksi", "No Transaksi")
        DataGridViewDaftarDiagnosa.Columns.Add("ColumnTanggal", "Tanggal")
        DataGridViewDaftarDiagnosa.Columns.Add("ColumnKeluhanUtama", "Keluhan Utama")
        DataGridViewDaftarDiagnosa.Columns.Add("ColumnLayanan", "Layanan")
        DataGridViewDaftarDiagnosa.Columns.Add("ColumnVitalStatistik", "Vital Statistik")
        DataGridViewDaftarDiagnosa.Columns.Add("ColumnDiagnosisKerja", "Diagnosis Kerja")
        DataGridViewDaftarDiagnosa.Columns.Add("ColumnResep", "Resep")
        DataGridViewDaftarDiagnosa.Columns.Add("ColumnTindakan", "Tindakan")
        DataGridViewDaftarDiagnosa.Columns.Add("ColumnRujukan", "Rujukan")
        DataGridViewDaftarDiagnosa.Columns.Add("ColumnDokter", "Dokter")

        ' Styling
        DataGridViewDaftarDiagnosa.DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        DataGridViewDaftarDiagnosa.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI Semibold", 10, FontStyle.Bold)
        DataGridViewDaftarDiagnosa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewDaftarDiagnosa.EditMode = DataGridViewEditMode.EditOnEnter

        ' Atur lebar tetap untuk kolom tertentu
        With DataGridViewDaftarDiagnosa.Columns("ColumnKodeDiagnosa")
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Width = 150
            .ReadOnly = True
        End With

        With DataGridViewDaftarDiagnosa.Columns("ColumnNamaDiagnosa")
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With

        With DataGridViewDaftarDiagnosa.Columns("ColumnJumlah")
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Width = 150
            .ReadOnly = True
        End With
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
        ' Create DataGridView
        TextBoxNoRM.ReadOnly = True
        TextBoxNoBPJS.ReadOnly = True
        TextBoxNIK.ReadOnly = True
        TextBoxNama.ReadOnly = True
        TextBoxNoIHS.ReadOnly = True
        TextBoxUmur.ReadOnly = True
        DateTimePickerTglLahir.Value = DateAndTime.Now
        CreateDataGridViewKunjunganPasien()
        ButtonSearchDiagnosa.PerformClick()
    End Sub

    'Private Sub SearchDataDiagnosa()
    '    If Checking() = True Then
    '        DataGridViewDaftarDiagnosa.Rows.Clear()

    '        Dim Tbls As DataTable = LoadDataDiagnosa()

    '        If Tbls.Rows.Count > 0 Then
    '            For Each Trow As DataRow In Tbls.Rows
    '                DataGridViewDaftarDiagnosa.Rows.Add(Trow("Kode Diagnosa").ToString(), Trow("Nama Diagnosa").ToString(), Trow("Jumlah").ToString(), False)
    '            Next

    '            DataGridViewDaftarDiagnosa.CurrentCell = Nothing
    '        Else
    '            MsgBox("Data tidak ditemukan.", MsgBoxStyle.Exclamation, "Warning!")
    '        End If
    '    End If
    'End Sub

    Function Checking() As Boolean

    End Function

    Private Sub ButtonButtonSearchDiagnosa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSearchDiagnosa.Click
        'SearchDataDiagnosa()
    End Sub

    'Function LoadDataDiagnosa() As DataTable
    '    Dim queryString As String = ""

    '    ' Ambil tanggal awal dan akhir dari DateTimePicker
    '    Dim tanggalAwal As String = Format(DateTimePickerAwal.Value, "yyyy-MM-dd")
    '    Dim tanggalAkhir As String = Format(DateTimePickerAkhir.Value, "yyyy-MM-dd")

    '    ' Set Tingkat Pelayanan
    '    Dim tingkatPelayananSearch As String = ""
    '    If ComboBoxTingkatPelayanan.Text <> "Semua" Then
    '        tingkatPelayananSearch = " AND JenisRawat = '" & ComboBoxTingkatPelayanan.Text & "'"
    '    End If

    '    ' Set Indikator
    '    Dim indikatorSearch As String = ""
    '    If ComboBoxIndikator.Text = "Kunjungan" Then
    '        indikatorSearch = " AND StatusPulang LIKE '%Berobat Jalan%'"
    '    ElseIf ComboBoxIndikator.Text = "Rujukan" Then
    '        indikatorSearch = " AND StatusPulang LIKE '%Rujuk%'"
    '    End If

    '    ' Set Jenis Poli
    '    Dim jenisPoliSearch As String = ""
    '    If ComboBoxPoliTujuan.Text <> "Semua Transaksi" Then
    '        jenisPoliSearch = " AND JenisPoli = '" & ComboBoxPoliTujuan.Text & "'"
    '    End If

    '    ' Buat query
    '    queryString = "SELECT ROW_NUMBER() OVER (ORDER BY COUNT(KodeDiagnosa) DESC) AS 'No', " & _
    '                  "KodeDiagnosa AS 'Kode Diagnosa', KeteranganDiagnosa AS 'Nama Diagnosa', COUNT(KodeDiagnosa) AS 'Jumlah' " & _
    '                  "FROM TransaksiDetailDiagnosa " & _
    '                  "WHERE DeletedDate IS NULL AND NoTransaksi IN (" & _
    '                      "SELECT NoUrut FROM TransaksiDetail " & _
    '                      "WHERE CONVERT(date, TanggalTransaksi) BETWEEN '" & tanggalAwal & "' AND '" & tanggalAkhir & "'" & _
    '                      tingkatPelayananSearch & indikatorSearch & jenisPoliSearch & ") " & _
    '                  "GROUP BY KodeDiagnosa, KeteranganDiagnosa " & _
    '                  "ORDER BY COUNT(KodeDiagnosa) DESC"

    '    ' Eksekusi query
    '    Dim Tbls As DataTable = ReadSQL(queryString)
    '    Return Tbls
    'End Function

    Private Sub TextBoxSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxSearch.TextChanged
        Dim searchText As String = TextBoxSearch.Text.Trim().ToLower()

        For Each row As DataGridViewRow In DataGridViewDaftarDiagnosa.Rows
            If row.IsNewRow Then Continue For ' Lewati baris baru/kosong

            Dim kodeDiagnosa As String = row.Cells("ColumnKodeDiagnosa").Value.ToString().ToLower()
            Dim namaDiagnosa As String = row.Cells("ColumnNamaDiagnosa").Value.ToString().ToLower()

            ' Tampilkan hanya baris yang cocok di salah satu kolom
            row.Visible = kodeDiagnosa.Contains(searchText) OrElse namaDiagnosa.Contains(searchText)
        Next
    End Sub

    Public Sub LoadPasien(ByVal Trow As DataRowView)
        SetAwal()

        'Set Data From Pencarian
        TextBoxNama.Text = Trow("Nama").ToString
        TextBoxNoRM.Text = Trow("RM").ToString
        TextBoxNIK.Text = Trow("No NIK").ToString
        TextBoxNoIHS.Text = Trow("No IHS").ToString
        TextBoxNoBPJS.Text = Trow("No JKN-KIS").ToString

        'If Trow("Status NIK").ToString = True Then LabelNotifikasiNIK.Visible = True
        'If Trow("No IHS").ToString = "" Then LabelNotifikasiIHS.Visible = True

        If Trow("Jenis Kelamin").ToString = "P" Then
            RadioButtonJenisKelaminLaki.Enabled = False
            RadioButtonJenisKelaminPerempuan.Enabled = True
            RadioButtonJenisKelaminPerempuan.Checked = True
        ElseIf Trow("Jenis Kelamin").ToString = "L" Then
            RadioButtonJenisKelaminPerempuan.Enabled = False
            RadioButtonJenisKelaminLaki.Enabled = True
            RadioButtonJenisKelaminLaki.Checked = True
        End If

        DateTimePickerTglLahir.Value = Trow("Tgl. Lahir").ToString
        TextBoxUmur.Text = Umur(Trow("Tgl. Lahir").ToString)
    End Sub

    Private Sub ButtonFindPasien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFindPasien.Click
        FindPasien.SetForm("RiwayatKunjungan")
        FindPasien.ShowDialog()
    End Sub
End Class