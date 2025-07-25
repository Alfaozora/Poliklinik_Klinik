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
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Grid

Public Class ReportLogPaketTindakan
    Private formName As String = "RIWAYAT PAKET TINDAKAN"
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

    End Sub

    Private Sub SearchDataRiwayatPaketReguler()
        Dim queryStringHeader As New StringBuilder()
        Dim queryStringDetail As New StringBuilder()

        'queryStringHeader.AppendLine("SELECT ")
        'queryStringHeader.AppendLine("    tblPasien.Nama, ")
        'queryStringHeader.AppendLine("    tblPaket.NoRekamMedis AS 'No RM', ")
        'queryStringHeader.AppendLine("    tblPaket.NamaPaket AS 'Nama Paket', ")
        'queryStringHeader.AppendLine("    STUFF(( ")
        'queryStringHeader.AppendLine("        SELECT ', ' + tblPaketDetail.NamaTindakan ")
        'queryStringHeader.AppendLine("        FROM TransaksiPaketTindakanDetail tblPaketDetail ")
        'queryStringHeader.AppendLine("        WHERE tblPaketDetail.PaketID = tblPaket.PaketID AND tblPaketDetail.KodeVoucher = tblPaket.KodeVoucher ")
        'queryStringHeader.AppendLine("        FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '') ")
        'queryStringHeader.AppendLine("    AS 'Nama Tindakan', ")
        'queryStringHeader.AppendLine("    tblPaket.JenisPaket AS 'Jenis Paket', ")
        'queryStringHeader.AppendLine("    tblPaket.Kuota, ")
        'queryStringHeader.AppendLine("    tblPaket.TanggalMulaiPaket AS 'Tgl Mulai', ")
        'queryStringHeader.AppendLine("    tblPaket.TanggalAkhirPaket AS 'Tgl Berakhir', ")
        'queryStringHeader.AppendLine("    tblPaket.PaketID, ")
        'queryStringHeader.AppendLine("    tblPaket.KodeVoucher, ")
        'queryStringHeader.AppendLine("    0 AS 'TindakanID' ")
        'queryStringHeader.AppendLine("FROM TransaksiPaketTindakan tblPaket ")
        'queryStringHeader.AppendLine("LEFT JOIN MasterPasien tblPasien ON tblPasien.NoRekamMedis = tblPaket.NoRekamMedis ")
        'queryStringHeader.AppendLine("WHERE tblPaket.JenisPaket = 'Paket Reguler'")
        ''queryStringHeader.AppendLine("AND tblPaket.NoRekamMedis = 'L003-0000129'")
        'queryStringHeader.AppendLine("ORDER BY tblPaket.PaketID;")

        ' Ambil Data Header
        'Dim tblRiwayatHeader As DataTable = ReadSQL(queryStringHeader.ToString())
        Dim tblRiwayatHeader As DataTable = GetDataHeaderPaketReguler()

        'queryStringDetail.AppendLine("SELECT tblLog.NoTransaksi, tblPasien.Nama, tblLog.NoRekamMedis AS 'No RM', ")
        'queryStringDetail.AppendLine("       tblLog.KodeVoucher, tblLog.PaketID, ")
        'queryStringDetail.AppendLine("       tblLog.TanggalTransaksi AS 'Tgl Transaksi'")
        'queryStringDetail.AppendLine("FROM LogPenggunaanPaket tblLog")
        'queryStringDetail.AppendLine("INNER JOIN TransaksiPaketTindakan tblPaket ")
        'queryStringDetail.AppendLine("    ON tblLog.KodeVoucher = tblPaket.KodeVoucher ")
        'queryStringDetail.AppendLine("    AND tblLog.PaketID = tblPaket.PaketID")
        'queryStringDetail.AppendLine("INNER JOIN MasterPasien tblPasien ")
        'queryStringDetail.AppendLine("    ON tblLog.NoRekamMedis = tblPasien.NoRekamMedis")
        'queryStringDetail.AppendLine("WHERE tblPaket.JenisPaket = 'Paket Reguler'")
        ''queryStringDetail.AppendLine(" AND tblPaket.NoRekamMedis = 'L003-0000129'")
        'queryStringDetail.AppendLine("ORDER BY tblLog.PaketID, tblLog.KodeVoucher;")

        ' Ambil Data Detail
        'Dim tblRiwayatDetail As DataTable = ReadSQL(queryStringDetail.ToString())
        Dim tblRiwayatDetail As DataTable = GetDataDetailPaketReguler()

        ' Inisialisasi DataSet
        Dim DataSet As New DataSet()

        ' Pastikan tabel memiliki nama yang sesuai sebelum dimasukkan ke DataSet
        tblRiwayatHeader.TableName = "TransaksiPaketTindakan"
        tblRiwayatDetail.TableName = "LogPenggunaanPaket"

        ' Tambahkan ke DataSet
        DataSet.Tables.Add(tblRiwayatHeader.Copy())
        DataSet.Tables.Add(tblRiwayatDetail.Copy())

        ' Definisikan array kolom untuk relasi master (Parent Table)
        Dim parentColumns() As DataColumn = { _
            DataSet.Tables("TransaksiPaketTindakan").Columns("PaketID"), _
                DataSet.Tables("TransaksiPaketTindakan").Columns("KodeVoucher") _
        }

        ' Definisikan array kolom untuk relasi detail (Child Table)
        Dim childColumns() As DataColumn = { _
            DataSet.Tables("LogPenggunaanPaket").Columns("PaketID"), _
                DataSet.Tables("LogPenggunaanPaket").Columns("KodeVoucher") _
        }

        ' Buat DataRelation dengan 2 kolom
        Dim relation As New DataRelation("MasterDetail", parentColumns, childColumns)

        ' Tambahkan relasi ke DataSet
        DataSet.Relations.Add(relation)

        ' Bind Data ke GridControl
        GridControlRiwayatPaket.DataSource = DataSet.Tables("TransaksiPaketTindakan")

        ' Ambil GridView utama dari GridControl
        Dim mainView As DevExpress.XtraGrid.Views.Grid.GridView = CType(GridControlRiwayatPaket.MainView, DevExpress.XtraGrid.Views.Grid.GridView)

        ' Set ReadOnly
        mainView.OptionsBehavior.Editable = False
        mainView.OptionsSelection.EnableAppearanceFocusedRow = False
        mainView.OptionsSelection.EnableAppearanceFocusedCell = False

        ' Sembunyikan kolom PaketID dan KodeVoucher di GridView utama
        If mainView.Columns("PaketID") IsNot Nothing Then mainView.Columns("PaketID").Visible = False
        If mainView.Columns("KodeVoucher") IsNot Nothing Then mainView.Columns("KodeVoucher").Visible = False
        If mainView.Columns("TindakanID") IsNot Nothing Then mainView.Columns("TindakanID").Visible = False

        ' Tambahkan handler untuk event ViewRegistered
        AddHandler GridControlRiwayatPaket.ViewRegistered, AddressOf GridControlRiwayatPaket_ViewRegistered

        AddHandler GridViewRiwayatPaket.RowStyle, AddressOf GridViewRiwayatPaket_RowStyle

        GridViewRiwayatPaket.ExpandAllGroups()
        GridViewRiwayatPaket.BestFitColumns()
    End Sub

    Private Sub SearchDataRiwayatPaketPerTindakan()
        Dim queryStringHeader As New StringBuilder()
        Dim queryStringDetail As New StringBuilder()

        queryStringHeader.AppendLine("SELECT tblPasien.Nama, tblPaket.NoRekamMedis AS 'No RM', ")
        queryStringHeader.AppendLine("       tblPaket.NamaPaket AS 'Nama Paket', tblPaketDetail.NamaTindakan AS 'Nama Tindakan', ")
        queryStringHeader.AppendLine("       tblPaket.JenisPaket AS 'Jenis Paket', ")
        queryStringHeader.AppendLine("       tblPaketDetail.KuotaTindakan AS 'Kuota', tblPaket.TanggalMulaiPaket AS 'Tgl Mulai', ")
        queryStringHeader.AppendLine("       tblPaket.TanggalAkhirPaket AS 'Tgl Berakhir', ")
        queryStringHeader.AppendLine("       tblPaket.PaketID, tblPaket.KodeVoucher, tblPaketDetail.TindakanID ")
        queryStringHeader.AppendLine("FROM TransaksiPaketTindakanDetail tblPaketDetail ")
        queryStringHeader.AppendLine("LEFT JOIN TransaksiPaketTindakan tblPaket ")
        queryStringHeader.AppendLine("       ON tblPaket.PaketID = tblPaketDetail.PaketID ")
        queryStringHeader.AppendLine("       AND tblPaket.KodeVoucher = tblPaketDetail.KodeVoucher ")
        queryStringHeader.AppendLine("LEFT JOIN MasterPasien tblPasien ")
        queryStringHeader.AppendLine("       ON tblPasien.NoRekamMedis = tblPaket.NoRekamMedis ")
        queryStringHeader.AppendLine("WHERE tblPaket.JenisPaket = 'Paket Per-Tindakan'")
        If TextBoxNomorRekamMedis.Text <> "" Then
            ' Filter Nama Pasien
            queryStringHeader.AppendLine("AND tblPaket.NoRekamMedis = '" & TextBoxNomorRekamMedis.Text & "'")
        End If

        ' Ambil Data Header
        Dim tblRiwayatHeader As DataTable = ReadSQL(queryStringHeader.ToString())

        queryStringDetail.AppendLine("SELECT tblLog.NoTransaksi, tblPasien.Nama, tblLog.NoRekamMedis AS 'No RM', ")
        queryStringDetail.AppendLine("       tblLog.KodeVoucher, tblLog.PaketID, tblLog.TindakanID, ")
        queryStringDetail.AppendLine("       tblLog.TanggalTransaksi AS 'Tgl Transaksi'")
        queryStringDetail.AppendLine("FROM LogPenggunaanPaket tblLog")
        queryStringDetail.AppendLine("INNER JOIN TransaksiPaketTindakan tblPaket ")
        queryStringDetail.AppendLine("    ON tblLog.KodeVoucher = tblPaket.KodeVoucher ")
        queryStringDetail.AppendLine("    AND tblLog.PaketID = tblPaket.PaketID")
        queryStringDetail.AppendLine("INNER JOIN MasterPasien tblPasien ")
        queryStringDetail.AppendLine("    ON tblLog.NoRekamMedis = tblPasien.NoRekamMedis")
        queryStringDetail.AppendLine("WHERE tblPaket.JenisPaket = 'Paket Per-Tindakan' ")
        queryStringDetail.AppendLine("AND tblLog.DeletedDate IS NULL ")
        If TextBoxNomorRekamMedis.Text <> "" Then
            ' Filter Nama Pasien
            queryStringHeader.AppendLine("AND tblPaket.NoRekamMedis = '" & TextBoxNomorRekamMedis.Text & "'")
        End If
        queryStringDetail.AppendLine("ORDER BY tblLog.PaketID, tblLog.KodeVoucher;")

        ' Ambil Data Detail
        Dim tblRiwayatDetail As DataTable = ReadSQL(queryStringDetail.ToString())

        ' Inisialisasi DataSet
        Dim DataSet As New DataSet()

        ' Pastikan tabel memiliki nama yang sesuai sebelum dimasukkan ke DataSet
        tblRiwayatHeader.TableName = "TransaksiPaketTindakan"
        tblRiwayatDetail.TableName = "LogPenggunaanPaket"

        ' Tambahkan ke DataSet
        DataSet.Tables.Add(tblRiwayatHeader.Copy())
        DataSet.Tables.Add(tblRiwayatDetail.Copy())

        ' Definisikan array kolom untuk relasi master (Parent Table)
        Dim parentColumns() As DataColumn = { _
            DataSet.Tables("TransaksiPaketTindakan").Columns("PaketID"), _
            DataSet.Tables("TransaksiPaketTindakan").Columns("TindakanID"), _
            DataSet.Tables("TransaksiPaketTindakan").Columns("KodeVoucher") _
        }

        ' Definisikan array kolom untuk relasi detail (Child Table)
        Dim childColumns() As DataColumn = { _
            DataSet.Tables("LogPenggunaanPaket").Columns("PaketID"), _
            DataSet.Tables("LogPenggunaanPaket").Columns("TindakanID"), _
            DataSet.Tables("LogPenggunaanPaket").Columns("KodeVoucher") _
        }

        ' Buat DataRelation dengan 2 kolom
        Dim relation As New DataRelation("MasterDetail", parentColumns, childColumns)

        ' Tambahkan relasi ke DataSet
        DataSet.Relations.Add(relation)

        ' Bind Data ke GridControl
        GridControlRiwayatPaket.DataSource = DataSet.Tables("TransaksiPaketTindakan")

        ' Ambil GridView utama dari GridControl
        Dim mainView As DevExpress.XtraGrid.Views.Grid.GridView = CType(GridControlRiwayatPaket.MainView, DevExpress.XtraGrid.Views.Grid.GridView)

        ' Set ReadOnly
        mainView.OptionsBehavior.Editable = False

        ' Sembunyikan kolom PaketID dan KodeVoucher di GridView utama
        If mainView.Columns("PaketID") IsNot Nothing Then mainView.Columns("PaketID").Visible = False
        If mainView.Columns("KodeVoucher") IsNot Nothing Then mainView.Columns("KodeVoucher").Visible = False
        If mainView.Columns("TindakanID") IsNot Nothing Then mainView.Columns("TindakanID").Visible = False

        ' Tambahkan handler untuk event ViewRegistered
        AddHandler GridControlRiwayatPaket.ViewRegistered, AddressOf GridControlRiwayatPaket_ViewRegistered

        AddHandler GridViewRiwayatPaket.RowStyle, AddressOf GridViewRiwayatPaket_RowStyle

        GridViewRiwayatPaket.ExpandAllGroups()
        GridViewRiwayatPaket.BestFitColumns()
    End Sub

    ' Method untuk menangani event ViewRegistered
    Private Sub GridControlRiwayatPaket_ViewRegistered(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.ViewOperationEventArgs)
        Dim detailView As DevExpress.XtraGrid.Views.Grid.GridView = TryCast(e.View, DevExpress.XtraGrid.Views.Grid.GridView)
        If detailView IsNot Nothing Then
            ' Sembunyikan kolom PaketID dan KodeVoucher di GridView detail
            If detailView.Columns("PaketID") IsNot Nothing Then detailView.Columns("PaketID").Visible = False
            If detailView.Columns("KodeVoucher") IsNot Nothing Then detailView.Columns("KodeVoucher").Visible = False
            If detailView.Columns("TindakanID") IsNot Nothing Then detailView.Columns("TindakanID").Visible = False
        End If
    End Sub

    Private Sub GridViewRiwayatPaket_RowStyle(ByVal sender As Object, ByVal e As RowStyleEventArgs)
        Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)

        If e.RowHandle >= 0 Then
            Dim jenisPaket As String = view.GetRowCellValue(e.RowHandle, "Jenis Paket").ToString()
            Dim kuota As Integer = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, "Kuota"))

            ' Jika kuota tinggal sedikit (misalnya ≤ 2), warnai dengan merah muda
            If kuota = 0 Then
                e.Appearance.BackColor = Color.LightCoral
                'e.Appearance.ForeColor = Color.DarkRed
                'e.Appearance.Font = New Font(e.Appearance.Font, FontStyle.Bold)
            Else
                e.Appearance.BackColor = Color.LightGreen
            End If
        End If
    End Sub

    Function Checking() As Boolean
        'If ComboBoxPoliTujuan.SelectedIndex = -1 Then
        '    MsgBox("Pilih poli tujuan terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
        '    Return False
        'End If

        Return True
    End Function

    Private Sub ButtonSearchRiwayatPaket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSearchRiwayatPaket.Click
        If RadioButtonOptionPaketReguler.Checked = True Then
            SearchDataRiwayatPaketReguler()
        ElseIf RadioButtonOptionPaketPerTindakan.Checked = True Then
            SearchDataRiwayatPaketPerTindakan()
        End If
    End Sub

    Private Sub ButtonCetakDiagnosa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CetakDataDiagnosa()
    End Sub

    Private Sub CetakDataDiagnosa()
        'Dim Tbls As DataTable = LoadDataDiagnosa()

        'If Tbls.Rows.Count > 0 Then
        '    Report = New XtraReport

        '    Dim kodePPK As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'KodePPK'")
        '    Dim namaPPK As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NamaPPK'")

        '    Report = XtraReport.FromFile(Application.StartupPath + "\Reports\Klinik\Laporan10Diagnosa.repx", True)
        '    Report.DataSource = Tbls

        '    'Report.Bands.Item(BandKind.ReportHeader).Controls("xrLabelFKTP").Text = namaPPK & " - " & kodePPK
        '    'Report.Bands.Item(BandKind.ReportHeader).Controls("xrLabelBulan").Text = ComboBoxBulan.Text & " " & ComboBoxTahun.Text
        '    'Report.Bands.Item(BandKind.ReportHeader).Controls("xrLabelPelayanan").Text = ComboBoxTingkatPelayanan.Text
        '    'Report.Bands.Item(BandKind.ReportHeader).Controls("xrLabelIndikator").Text = ComboBoxIndikator.Text
        '    'Report.Bands.Item(BandKind.ReportHeader).Controls("xrLabelPoli").Text = ComboBoxPoliTujuan.Text

        '    Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:ss") & " By " & PoliKlinik.Lbluser.Text

        '    'Report.RunDesigner()
        '    Report.ShowPreview()
        'Else
        '    MsgBox("Data tidak ditemukan.", MsgBoxStyle.Exclamation, "Warning!")
        'End If
    End Sub

    'Function LoadDataDiagnosa() As DataTable
    '    Dim queryString As String = ""

    '    ' Set Bulan & Tahun
    '    Dim bulanSearch As String = Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(ComboBoxBulan.Text, "Januari", "01"), "Februari", "02"), "Maret", "03"), "April", "04"), "Mei", "05"), "Juni", "06"), "Juli", "07"), "Agustus", "08"), "September", "09"), "Oktober", "10"), "November", "11"), "Desember", "12")
    '    Dim tahunSearch As String = ComboBoxTahun.Text

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

    '    queryString = "SELECT TOP(10) ROW_NUMBER() OVER (ORDER BY COUNT(KodeDiagnosa) DESC) AS 'No', KodeDiagnosa AS 'Kode Diagnosa', KeteranganDiagnosa AS 'Nama Diagnosa', COUNT(KodeDiagnosa) AS 'Jumlah' FROM TransaksiDetailDiagnosa " & _
    '                  "WHERE DeletedDate IS NULL AND NoTransaksi IN (SELECT NoUrut FROM TransaksiDetail WHERE YEAR(TanggalTransaksi) = '" & tahunSearch & "' AND MONTH(TanggalTransaksi) = '" & bulanSearch & "'" & tingkatPelayananSearch & indikatorSearch & jenisPoliSearch & ") " & _
    '                  "GROUP BY KodeDiagnosa, KeteranganDiagnosa " & _
    '                  "ORDER BY COUNT(KodeDiagnosa) DESC"

    '    Dim Tbls As DataTable = ReadSQL(queryString)

    '    Return Tbls
    'End Function

    Private Sub ButtonCariPasien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCariPasien.Click
        FindPasien.SetForm("ReportLogPaketTindakan")
        FindPasien.ShowDialog()
    End Sub

    Public Sub LoadPasien(ByVal Trow As DataRowView)
        'Set Data From Pencarian
        TextBoxNomorRekamMedis.Text = Trow("RM").ToString
        TextBoxNamaRekamMedis.Text = Trow("Nama").ToString
    End Sub

    Function GetDataHeaderPaketReguler() As DataTable
        Dim tglTransaksiAwal As Date = TglAwalTransaksi.Value
        Dim tglTransaksiAkhir As Date = TglAkhirTransaksi.Value
        Dim tblResult As New DataTable

        Dim query As New StringBuilder()

        query.AppendLine("SELECT ")
        query.AppendLine("    tblPasien.Nama, ")
        query.AppendLine("    tblPaket.NoRekamMedis AS 'No RM', ")
        query.AppendLine("    tblPaket.NoTransaksi AS 'No Transaksi', ")
        query.AppendLine("    tblPaket.NamaPaket AS 'Nama Paket', ")
        query.AppendLine("    STUFF(( ")
        query.AppendLine("        SELECT ', ' + tblPaketDetail.NamaTindakan ")
        query.AppendLine("        FROM TransaksiPaketTindakanDetail tblPaketDetail ")
        query.AppendLine("        WHERE tblPaketDetail.PaketID = tblPaket.PaketID AND tblPaketDetail.KodeVoucher = tblPaket.KodeVoucher ")
        query.AppendLine("        FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '') ")
        query.AppendLine("    AS 'Nama Tindakan', ")
        query.AppendLine("    tblPaket.JenisPaket AS 'Jenis Paket', ")
        query.AppendLine("    tblPaket.Kuota, ")
        query.AppendLine("    tblPaket.TanggalMulaiPaket AS 'Tgl Mulai', ")
        query.AppendLine("    tblPaket.TanggalAkhirPaket AS 'Tgl Berakhir', ")
        query.AppendLine("    tblPaket.PaketID, ")
        query.AppendLine("    tblPaket.KodeVoucher, ")
        query.AppendLine("    0 AS 'TindakanID' ")
        query.AppendLine("FROM TransaksiPaketTindakan tblPaket ")
        query.AppendLine("LEFT JOIN MasterPasien tblPasien ON tblPasien.NoRekamMedis = tblPaket.NoRekamMedis ")
        query.AppendLine("WHERE tblPaket.JenisPaket = 'Paket Reguler'")
        If TextBoxNomorRekamMedis.Text <> "" Then
            query.AppendLine("AND tblPaket.NoRekamMedis = '" & TextBoxNomorRekamMedis.Text & "'")
        End If
        query.AppendLine("AND (CONVERT(DATE, tblPaket.TanggalMulaiPaket) BETWEEN '" & Format(tglTransaksiAwal.Date, "yyyyMMdd") & "' AND '" & Format(tglTransaksiAkhir.Date, "yyyyMMdd") & "') AND tblPaket.DeletedDate IS NULL")
        query.AppendLine("ORDER BY tblPaket.PaketID;")

        tblResult = ReadSQL(query.ToString())

        Return tblResult
    End Function

    Function GetDataDetailPaketReguler() As DataTable
        Dim tglTransaksiAwal As Date = TglAwalTransaksi.Value
        Dim tglTransaksiAkhir As Date = TglAkhirTransaksi.Value
        Dim tblResult As New DataTable

        Dim query As New StringBuilder()

        query.AppendLine("SELECT tblLog.NoTransaksi, tblPasien.Nama, tblLog.NoRekamMedis AS 'No RM', ")
        query.AppendLine("       tblLog.KodeVoucher, tblLog.PaketID, ")
        query.AppendLine("       tblLog.TanggalTransaksi AS 'Tgl Transaksi'")
        query.AppendLine("FROM LogPenggunaanPaket tblLog")
        query.AppendLine("INNER JOIN TransaksiPaketTindakan tblPaket ")
        query.AppendLine("    ON tblLog.KodeVoucher = tblPaket.KodeVoucher ")
        query.AppendLine("    AND tblLog.PaketID = tblPaket.PaketID")
        query.AppendLine("INNER JOIN MasterPasien tblPasien ")
        query.AppendLine("    ON tblLog.NoRekamMedis = tblPasien.NoRekamMedis")
        query.AppendLine("WHERE tblPaket.JenisPaket = 'Paket Reguler'")
        If TextBoxNomorRekamMedis.Text <> "" Then
            query.AppendLine("AND tblPaket.NoRekamMedis = '" & TextBoxNomorRekamMedis.Text & "'")
        End If
        query.AppendLine("AND (CONVERT(DATE, tblPaket.TanggalMulaiPaket) BETWEEN '" & Format(tglTransaksiAwal.Date, "yyyyMMdd") & "' AND '" & Format(tglTransaksiAkhir.Date, "yyyyMMdd") & "') ")
        query.AppendLine("AND tblLog.DeletedDate IS NULL")
        query.AppendLine("ORDER BY tblLog.PaketID, tblLog.KodeVoucher;")

        tblResult = ReadSQL(query.ToString())

        Return tblResult
    End Function

    Private Sub ButtonClearData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClearData.Click
        SetClearGrid()
    End Sub

    Private Sub SetClearGrid()
        TextBoxNomorRekamMedis.ResetText()
        TextBoxNamaRekamMedis.ResetText()
    End Sub
End Class