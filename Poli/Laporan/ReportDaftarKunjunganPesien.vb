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
Imports System.Text

Public Class ReportDaftarKunjunganPesien
    Private formName As String = "DAFTAR KUNJUNGAN PASIEN"
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
        DataGridViewDaftarKunjungan.Columns.Add("ColumnNo", "No")
        DataGridViewDaftarKunjungan.Columns.Add("ColumnNoTransaksi", "No Transaksi")
        DataGridViewDaftarKunjungan.Columns.Add("ColumnTanggalPelayanan", "Tgl Pelayanan")
        DataGridViewDaftarKunjungan.Columns.Add("ColumnPasienID", "ID Pasien")
        DataGridViewDaftarKunjungan.Columns.Add("ColumnNamaPasien", "Nama Pasien")
        DataGridViewDaftarKunjungan.Columns.Add("ColumnJenisKelamin", "Jenis Kelamin")
        DataGridViewDaftarKunjungan.Columns.Add("ColumnDiagnosa", "Diagnosa")
        DataGridViewDaftarKunjungan.Columns.Add("ColumnLayanan", "Layanan")
        DataGridViewDaftarKunjungan.Columns.Add("ColumnNamaDokter", "Dokter")
        DataGridViewDaftarKunjungan.Columns.Add("ColumnTagihan", "Tagihan")

        ' Setting
        DataGridViewDaftarKunjungan.DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        DataGridViewDaftarKunjungan.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI Semibold", 10, FontStyle.Bold)
        DataGridViewDaftarKunjungan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        ' Mengatur lebar maksimum untuk kolom kode diagnosa
        Dim increamentDataColumn As DataGridViewColumn = DataGridViewDaftarKunjungan.Columns("ColumnNo")
        increamentDataColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None ' Menonaktifkan penyesuaian otomatis
        increamentDataColumn.Width = 50 ' Mengatur lebar maksimums
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

        ' Set ComboBox Tahun
        ComboBoxTahun.Items.Clear()
        LoadComboBoxTahun()

        TextBoxNomorPeserta.ResetText()
        TextBoxNomorTransaksi.ResetText()

        ' Create DataGridView
        CreateDataGridViewKunjunganPasien()
        ButtonSearchDaftarPeserta.PerformClick()
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

        ' Set default tahun
        Dim tahunSekarang As Integer = DateTime.Now.Year
        ComboBoxTahun.Text = tahunSekarang.ToString()
    End Sub

    Private Sub SearchDataDaftarKunjungan()
        If ValidasiSearch() = True Then
            DataGridViewDaftarKunjungan.Rows.Clear()

            Dim Tbls As DataTable = LoadDataDaftarKunjungan()

            If Tbls.Rows.Count > 0 Then
                Dim jenisPenagihan As String = ""

                For Each Trow As DataRow In Tbls.Rows
                    ' Set Penagihan
                    If IsDBNull(Trow("JenisPenagihan")) = False Then
                        jenisPenagihan = Trow("JenisPenagihan").ToString
                    Else
                        jenisPenagihan = GetJenisPembayaran(Trow("JenisTransaksi"), Trow("NoUrut"))
                    End If

                    DataGridViewDaftarKunjungan.Rows.Add(New String() {"-", "" & Trow("NoUrut") & "", "" & Format(Trow("TglTransaksi"), "yyyy-MM-dd HH:mm:ss") & "", "" & Trow("NoRekamMedis") & "", "" & Trow("Nama") & "", "" & Trow("JenisKelamin") & "", "" & Trow("Diagnosa") & "", "" & Trow("JenisPoli") & "", "" & Trow("NamaDokter") & "", "" & jenisPenagihan & ""})
                Next

                DataGridViewDaftarKunjungan.CurrentCell = Nothing
            Else
                MsgBox("Data tidak ditemukan.", MsgBoxStyle.Exclamation, "Warning!")
            End If
        End If
    End Sub

    Private Function GetJenisTransaksiByPoli(ByVal namaPoli As String) As String
        ' Hindari karakter petik tunggal error dengan replace (basic sanitasi)
        Dim safePoli As String = namaPoli.Replace("'", "''")

        Dim query As String = "SELECT KodeTransaksi FROM MasterPoliTujuan WHERE NamaPoli = '" & safePoli & "'"
        Dim dt As DataTable = ReadSQL(query)

        If dt.Rows.Count > 0 Then
            Dim kode As String = dt.Rows(0)("KodeTransaksi").ToString().ToUpper()
            If kode = "U" Then
                Return "UMUM"
            ElseIf kode = "G" Then
                Return "GIGI"
            End If
        End If

        Return "" ' Jika tidak ditemukan
    End Function

    Private Sub DataGridViewDaftarKunjungan_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridViewDaftarKunjungan.CellDoubleClick
        ' Pastikan baris yang diklik valid
        If e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0 Then
            Dim dgv As DataGridView = CType(sender, DataGridView)

            ' Ambil data dari baris yang diklik
            Dim noUrut As String = dgv.Rows(e.RowIndex).Cells(1).Value.ToString() 'no transaksi
            Dim noRekamMedis As String = dgv.Rows(e.RowIndex).Cells(3).Value.ToString() 'noRM
            Dim tglPelayanan As String = dgv.Rows(e.RowIndex).Cells(2).Value.ToString() 'tgl pelayanan
            Dim namaPoli As String = dgv.Rows(e.RowIndex).Cells(7).Value.ToString() 'jenis poli
            'Dim namaPasien As String = dgv.Rows(e.RowIndex).Cells(4).Value.ToString()
            Dim jenisPoli As String = GetJenisTransaksiByPoli(namaPoli)
            Dim frm As New FormRekamMedisDokter()
            frm.TglAwalFilter = tglPelayanan
            frm.TglAkhirFilter = Date.Now
            frm.SetDataFromPendaftaran(noRekamMedis, noUrut, jenisPoli)
            frm.Show()
            frm.BukaTabRiwayat()
            frm.GetRiwayatKunjungan()
        End If
    End Sub

    'Private Sub DataGridViewKunjunganPasien_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewDaftarKunjungan.CellDoubleClick
    '    If e.RowIndex >= 0 Then
    '        ' Set Data Transaksi
    '        Dim jenisUser As String = ReadSQLNIK("SELECT GroupID FROM Users WHERE UserID = '" & userInput & "'")
    '        Dim noTransaksi As String = DataGridViewDaftarKunjungan.Rows(e.RowIndex).Cells("ColumnNoTransaksi").Value.ToString()
    '        Dim jenisPoli As String = DataGridViewDaftarKunjungan.Rows(e.RowIndex).Cells("ColumnJenisPoli").Value.ToString()
    '        Dim noRM As String = DataGridViewDaftarKunjungan.Rows(e.RowIndex).Cells("ColumnNoRM").Value.ToString()
    '        Dim namaPoli As String = DataGridViewDaftarKunjungan.Rows(e.RowIndex).Cells("ColumnNamaPoli").Value.ToString()
    '        Dim noBPJS As String = DataGridViewDaftarKunjungan.Rows(e.RowIndex).Cells("ColumnNoBPJS").Value.ToString()
    '        Dim keluhan As String = DataGridViewDaftarKunjungan.Rows(e.RowIndex).Cells("ColumnKeluhan").Value.ToString()
    '        Dim noNIK As String = DataGridViewDaftarKunjungan.Rows(e.RowIndex).Cells("ColumnNoNIK").Value.ToString()
    '        Dim jenisRawat As String = DataGridViewDaftarKunjungan.Rows(e.RowIndex).Cells("ColumnJenisRawat").Value.ToString()

    '        ' Set Status Transaksi
    '        Dim statusTransaksi As String = GetStatusTransaksi(noTransaksi, jenisPoli)

    '        '# Set data dictionary yang akan dikirim ke form popup
    '        Dim dataDictionary As New Dictionary(Of String, Object)()

    '        If (statusTransaksi = "Belum Diperiksa" And jenisUser.Contains("Dokter") = False) Or (statusTransaksi = "Sudah dilakukan TTV" And jenisUser.Contains("Dokter") = True) Then
    '            dataDictionary.Add("No Transaksi", noTransaksi)
    '            dataDictionary.Add("No RM", noRM)
    '            dataDictionary.Add("Jenis Poli", jenisPoli)
    '            dataDictionary.Add("Status Transaksi", statusTransaksi)
    '            dataDictionary.Add("Jenis User", jenisUser)
    '            dataDictionary.Add("Nama Poli", namaPoli)
    '            dataDictionary.Add("Nomor BPJS", noBPJS)
    '            dataDictionary.Add("Keluhan", keluhan)
    '            dataDictionary.Add("Nomor NIK", noNIK)
    '            dataDictionary.Add("Jenis Rawat", jenisRawat)

    '            dataDictionary.Add("Text Button Start Proses", "Mulai Pemeriksaan")
    '            dataDictionary.Add("Jenis Proses", "Pendaftaran - Pemeriksaan")

    '            DialogBoxPanggilPasien.DataDictionary = dataDictionary
    '            DialogBoxPanggilPasien.ShowDialog()
    '        Else
    '            FormRekamMedisDokter.SetDataFromPendaftaran(noRM, noTransaksi, jenisPoli)
    '            FormRekamMedisDokter.Show()
    '            FormRekamMedisDokter.BringToFront()
    '        End If

    '        ' Harusnya refresh grid terbaru
    '        'FindQuery("Nothing")
    '    End If

    'End Sub

    Function ValidasiSearch() As Boolean
        If RadioButtonOpsiIndividu.Checked = True Then
            If TextBoxNomorPeserta.Text = "" Then
                MsgBox("Masukkan nomor peserta terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
                Return False
            End If
        ElseIf RadioButtonOpsiNoTransaksi.Checked = True Then
            If TextBoxNomorTransaksi.Text = "" Then
                MsgBox("Masukkan nomor transaksi terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub ButtonSearchDaftarPeserta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSearchDaftarPeserta.Click
        SearchDataDaftarKunjungan()
    End Sub

    Private Sub CetakDataDaftarKunjungan()
        Dim Tbls As DataTable = LoadDataDaftarKunjungan()

        If Tbls.Rows.Count > 0 Then
            Report = New XtraReport

            Dim kodePPK As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'KodePPK'")
            Dim namaPPK As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NamaPPK'")

            Report = XtraReport.FromFile(Application.StartupPath + "\Reports\Klinik\Laporan10Diagnosa.repx", True)
            Report.DataSource = Tbls

            Report.Bands.Item(BandKind.ReportHeader).Controls("xrLabelFKTP").Text = namaPPK & " - " & kodePPK
            Report.Bands.Item(BandKind.ReportHeader).Controls("xrLabelBulan").Text = ComboBoxBulan.Text & " " & ComboBoxTahun.Text
            'Report.Bands.Item(BandKind.ReportHeader).Controls("xrLabelPelayanan").Text = ComboBoxTingkatPelayanan.Text
            'Report.Bands.Item(BandKind.ReportHeader).Controls("xrLabelIndikator").Text = ComboBoxIndikator.Text
            'Report.Bands.Item(BandKind.ReportHeader).Controls("xrLabelPoli").Text = ComboBoxPoliTujuan.Text

            Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:ss") & " By " & PoliKlinik.Lbluser.Text

            'Report.RunDesigner()
            Report.ShowPreview()
        Else
            MsgBox("Data tidak ditemukan.", MsgBoxStyle.Exclamation, "Warning!")
        End If
    End Sub

    Function LoadDataDaftarKunjungan() As DataTable
        Dim queryString As String = ""
        Dim queryStringCondition As String = ""
        Dim queryStringJenisKunjungan As String = ""

        ' Set Jenis Kunjungan
        If RadioButtonKunjunganSakit.Checked = True Then
            queryStringJenisKunjungan = " AND TransaksiDetail.JenisKunjungan = 'Kunjungan Sakit'"
        ElseIf RadioButtonKunjunganSehat.Checked = True Then
            queryStringJenisKunjungan = " AND TransaksiDetail.JenisKunjungan = 'Kunjungan Sehat'"
        End If

        ' Set Kondisi
        If RadioButtonOpsiHarian.Checked = True Then
            Dim tanggalHarian As Date = DateTimePickerTglHarian.Value
            queryStringCondition = " AND CONVERT(date, TransaksiDetail.TanggalTransaksi) = '" & Format(tanggalHarian.Date, "MM/dd/yyyy") & "'"
        ElseIf RadioButtonOpsiBulanan.Checked = True Then
            Dim bulanSearch As String = Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(ComboBoxBulan.Text, "Januari", "01"), "Februari", "02"), "Maret", "03"), "April", "04"), "Mei", "05"), "Juni", "06"), "Juli", "07"), "Agustus", "08"), "September", "09"), "Oktober", "10"), "November", "11"), "Desember", "12")
            Dim tahunSearch As String = ComboBoxTahun.Text
            queryStringCondition = " AND YEAR(TransaksiDetail.TanggalTransaksi) = '" & tahunSearch & "' AND MONTH(TransaksiDetail.TanggalTransaksi) = '" & bulanSearch & "'"
        ElseIf RadioButtonOpsiIndividu.Checked = True Then
            queryStringCondition = " AND TransaksiDetail.IDInternet = '" & TextBoxNomorPeserta.Text & "'"
        ElseIf RadioButtonOpsiNoTransaksi.Checked = True Then
            queryStringCondition = " AND TransaksiDetail.NoUrut = '" & TextBoxNomorTransaksi.Text & "'"
        End If

        Dim queryBuilder As New StringBuilder()
        queryBuilder.AppendLine("SELECT * FROM (")
        queryBuilder.AppendLine("    SELECT TransaksiDetail.StatusPulang, TransaksiDetail.Diagnosa, MasterPasien.JenisKelamin, TransaksiDetail.JenisPenagihan, TransaksiDetail.JenisTransaksi, TransaksiDetail.JenisPoli, TransaksiPoli.NoUrut, MasterPasien.NoRekamMedis, TransaksiPoli.TglPoli AS 'TglTransaksi', MasterPasien.Nama, TransaksiPoli.DokterPoli AS 'NamaDokter', TransaksiPoli.StatusKeterangan AS 'Status'")
        queryBuilder.AppendLine("    FROM TransaksiPoli")
        queryBuilder.AppendLine("    LEFT JOIN TransaksiDetail ON TransaksiPoli.NoUrut = TransaksiDetail.NoUrut")
        queryBuilder.AppendLine("    LEFT JOIN MasterPasien ON TransaksiPoli.IDInternet = MasterPasien.NoRekamMedis")
        queryBuilder.AppendLine("    WHERE TransaksiPoli.deleted = 0" & queryStringCondition & queryStringJenisKunjungan)
        queryBuilder.AppendLine("    UNION")
        queryBuilder.AppendLine("    SELECT TransaksiDetail.StatusPulang, TransaksiDetail.Diagnosa, MasterPasien.JenisKelamin, TransaksiDetail.JenisPenagihan, TransaksiDetail.JenisTransaksi, TransaksiDetail.JenisPoli, TransaksiGigi.NoUrut, MasterPasien.NoRekamMedis, TransaksiGigi.TglGigi AS 'TglTransaksi', MasterPasien.Nama, TransaksiGigi.DokterGigi AS 'NamaDokter', TransaksiGigi.StatusKeterangan AS 'Status'")
        queryBuilder.AppendLine("    FROM TransaksiGigi")
        queryBuilder.AppendLine("    LEFT JOIN TransaksiDetail ON TransaksiGigi.NoUrut = TransaksiDetail.NoUrut")
        queryBuilder.AppendLine("    LEFT JOIN MasterPasien ON TransaksiGigi.IDInternet = MasterPasien.NoRekamMedis")
        queryBuilder.AppendLine("    WHERE TransaksiGigi.deleted = 0" & queryStringCondition & queryStringJenisKunjungan)
        queryBuilder.AppendLine(") AS CombinedResults")
        queryBuilder.AppendLine("ORDER BY TglTransaksi, NoUrut")

        Dim Tbls As DataTable = ReadSQL(queryBuilder.ToString())

        Return Tbls
    End Function

    Private Sub ButtonCariPeserta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCariPeserta.Click
        FindPasien.SetForm("ReportDaftarKunjunganPeserta")
        FindPasien.ShowDialog()
    End Sub

    Public Sub LoadPasien(ByVal Trow As DataRowView)
        'Set Data From Pencarian
        TextBoxNomorPeserta.Text = Trow("RM").ToString
    End Sub

    Private Sub DataGridViewDaftarDiagnosa_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridViewDaftarKunjungan.CellFormatting
        ' Hanya melakukan perubahan pada kolom nomor urut
        If e.ColumnIndex = 0 AndAlso e.RowIndex >= 0 Then ' Kolom nomor urut adalah kolom indeks 0
            e.Value = e.RowIndex + 1 ' Nomor urut dimulai dari 1
        End If
    End Sub
End Class