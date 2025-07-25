Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Drawing

Imports Excel = Microsoft.Office.Interop.Excel
Imports Microsoft.Office
Imports Microsoft.Office.Interop
Imports System.Text

Imports Newtonsoft.Json
Imports System.Data.SqlClient

Public Class ReportPendapatanKlinik
    ' Set Variabel Private
    Private formName As String = "LAPORAN PENDAPATAN KLINIK"
    Private tipeJurnal As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'tipe_jurnal'")
    Private kodeLokasiKlinik As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NoPoli'")
    Private autoJurnal As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'AutoJurnal'")
    Private userInput As String = PoliKlinik.Lbluser.Text

    Private DB_Keuangan As TLcon
    Private DB_Omset As TLcon
    Private DB_Jurnal As TLcon
    Private Find_Poliklinik As Find.TLconnect
    Private Find_Omset As Find.TLconnect
    Private Find_Keuangan As Find.TLconnect

    Dim thread As System.Threading.Thread

    ' Deklarasi variabel untuk menyimpan link terakhir yang diklik
    Private lastClickedItem As DevExpress.XtraNavBar.NavBarItem = Nothing

    Private Sub PanelTop_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelTop.Paint
        Try
            e.Graphics.DrawString(formName, New Font("Arial", 12, FontStyle.Bold), Brushes.White, New Point(10, 10))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub SetConnectionFromConfig()
        ' Set Parameter Server Online
        Dim serverOnline_IP As String = Utility.GetConfig("ServerOnline_IP")
        Dim serverOnline_UserID As String = Utility.GetConfig("ServerOnline_UserID")
        Dim serverOnline_Password As String = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerOnline_Password"), "albert")

        ' Set Find Keuangan 1 (mitramed_keu)
        Find_Keuangan.Tip = serverOnline_IP
        Find_Keuangan.Tid = serverOnline_UserID
        Find_Keuangan.Tpass = serverOnline_Password
        Find_Keuangan.Tdb = Utility.GetConfig("ServerOnlineKeuangan_DB")

        ' Set DB Keuangan 1 (mitramed_keu)
        DB_Keuangan.Tip = serverOnline_IP
        DB_Keuangan.Tid = serverOnline_UserID
        DB_Keuangan.Tpass = serverOnline_Password
        DB_Keuangan.Tdb = Utility.GetConfig("ServerOnlineKeuangan_DB")

        ' Set Find Poliklinik
        Find_Poliklinik.Tip = serverOnline_IP
        Find_Poliklinik.Tid = serverOnline_UserID
        Find_Poliklinik.Tpass = serverOnline_Password
        Find_Poliklinik.Tdb = Utility.GetConfig("ServerOnlinePoli_DB")

        ' Set Find Omset (mitramedicare_omset_keuangan)
        Find_Omset.Tip = serverOnline_IP
        Find_Omset.Tid = serverOnline_UserID
        Find_Omset.Tpass = serverOnline_Password
        Find_Omset.Tdb = Utility.GetConfig("ServerOnlineOmset_DB")

        ' Set DB Omset (mitramedicare_omset_keuangan)
        DB_Omset.Tip = serverOnline_IP
        DB_Omset.Tid = serverOnline_UserID
        DB_Omset.Tpass = serverOnline_Password
        DB_Omset.Tdb = Utility.GetConfig("ServerOnlineOmset_DB")

        ' Set DB Jurnal
        DB_Jurnal.Tip = Utility.GetConfig("ServerJurnal_IP")
        DB_Jurnal.Tid = Utility.GetConfig("ServerJurnal_UserID")
        DB_Jurnal.Tpass = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerJurnal_Password"), "albert")
        DB_Jurnal.Tdb = Utility.GetConfig("ServerJurnal_DB")
    End Sub

    Private Sub ReportPendapatanKlinik_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
        Me.MdiParent = PoliKlinik
        Me.Dock = DockStyle.Fill

        ' Hide tab header button TabControl
        TabControlMenu.ItemSize = New Size(0, 1)

        ' Set Clear Form
        SetClearLaporanPendapatan()
        SetClearRekapTagihan()
        SetClearRekapInvoice()

        ' Set Connection Database
        SetConnectionFromConfig()

        ' Panggil metode untuk NavBarItemTindakanPoliUmum
        TriggerNavBarItemClick(NavBarItemLaporanPendapatan)
    End Sub

    ' Akses event LinkClicked dari NavBarItem secara manual
    Public Sub TriggerNavBarItemClick(ByVal navBarItem As DevExpress.XtraNavBar.NavBarItem)
        ' Buat event args dengan item NavBar yang diinginkan
        Dim link As New DevExpress.XtraNavBar.NavBarItemLink(navBarItem)
        Dim eventArgs As New DevExpress.XtraNavBar.NavBarLinkEventArgs(link)

        ' Panggil event handler NavBarItem_LinkClicked dengan argumen yang sesuai
        NavBarItem_LinkClicked(navBarItem, eventArgs)
    End Sub

    Private Sub ButtonClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClose.Click
        Me.Close()
    End Sub

    Private Sub NavBarItem_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItemLaporanPendapatan.LinkClicked, NavBarItemRekapTagihan.LinkClicked, NavBarItemRekapInvoice.LinkClicked
        ' Reset gaya dari item sebelumnya jika ada
        If lastClickedItem IsNot Nothing Then lastClickedItem.Appearance.ForeColor = Color.Empty

        ' Simpan item yang baru diklik dan setel warnanya
        lastClickedItem = e.Link.Item
        lastClickedItem.Appearance.ForeColor = Color.Gray

        ' Dapatkan caption dari link yang diklik
        Dim clickedLink As String = e.Link.Item.Caption

        ' Lakukan navigasi berdasarkan link yang diklik
        Select Case clickedLink
            Case "LAPORAN PENDAPATAN"
                TabControlMenu.SelectedTab = TabPageLaporanPendapatan
            Case "REKAP TAGIHAN"
                TabControlMenu.SelectedTab = TabPageRekapTagihan
            Case "REKAP INVOICE"
                TabControlMenu.SelectedTab = TabPageRekapInvoice
            Case Else
                MessageBox.Show("Link tidak dikenali!")
        End Select
    End Sub

    Private Sub SetClearLaporanPendapatan()
        ' Set ComboBox Poli Tujuan
        ComboBoxPoliTujuanLaporanPendapatan.Items.Clear()
        ComboBoxPoliTujuanLaporanPendapatan.Items.Add("SEMUA TRANSAKSI")
        Dim tblsPoliTujuan As DataTable = ReadSQL("SELECT * FROM MasterPoliTujuan WHERE PoliSakit = 'True'")
        For Each TrowPoliTujuan As DataRow In tblsPoliTujuan.Rows
            ComboBoxPoliTujuanLaporanPendapatan.Items.Add(TrowPoliTujuan("NamaPoli"))
        Next
        ComboBoxPoliTujuanLaporanPendapatan.SelectedIndex = 0

        ' Set Grid Control
        SetGridLaporanPendapatan()

        ' Clear Variabel
        TextBoxNamaPerusahaanLaporanPendapatan.ResetText()
        TextBoxNamaPerusahaanRekapTagihan.ResetText()

        ' Enable Control
        TglAwalTransaksiLaporanPendapatan.Enabled = True
        TglAkhirTransaksiLaporanPendapatan.Enabled = True
        ComboBoxPoliTujuanLaporanPendapatan.Enabled = True
        ButtonFindPerusahaanLaporanPendapatan.Enabled = True
        ButtonViewDataPendapatan.Enabled = True
        CheckBoxTagihan.Enabled = True
        CheckBoxTunai.Enabled = True
        CheckBoxCard.Enabled = True
        CheckBoxDebet.Enabled = True
        CheckBoxTransaksiNolRupiah.Enabled = True
    End Sub

    Private Sub SetGridLaporanPendapatan()
        Dim tblOmset As DataTable = CreateTableLaporanPendapatan()

        GridControlLaporanPendapatan.DataSource = tblOmset

        GridViewLaporanPendapatan.Columns("No").Visible = False
        GridViewLaporanPendapatan.Columns("NoJenisBayar").Visible = False
        GridViewLaporanPendapatan.Columns("NIP").Visible = False
        GridViewLaporanPendapatan.Columns("Tgl Lahir").Visible = False
        GridViewLaporanPendapatan.Columns("Alamat").Visible = False
        GridViewLaporanPendapatan.Columns("Translabid").Visible = False
        GridViewLaporanPendapatan.Columns("mesin").Visible = False
        GridViewLaporanPendapatan.Columns("kartu").Visible = False
        GridViewLaporanPendapatan.Columns("JenisTransaksi").Visible = False
        GridViewLaporanPendapatan.Columns("Jenis Bayar").Visible = False
    End Sub

    Function CreateTableLaporanPendapatan() As DataTable
        Dim Thasil As New DataTable

        insertRowToTbls(Thasil, "tyinterger", "No")
        insertRowToTbls(Thasil, "Typstring", "NoJenisBayar")
        insertRowToTbls(Thasil, "Typstring", "No Transaksi")
        insertRowToTbls(Thasil, "typdate", "Tgl Transaksi")
        insertRowToTbls(Thasil, "Typstring", "NIP")
        insertRowToTbls(Thasil, "Typstring", "Nama")
        insertRowToTbls(Thasil, "typdate", "Tgl Lahir")
        insertRowToTbls(Thasil, "Typstring", "Alamat") '
        insertRowToTbls(Thasil, "Typstring", "pemeriksaan")
        insertRowToTbls(Thasil, "tyinterger", "Tagihan")
        insertRowToTbls(Thasil, "tyinterger", "Translabid")
        insertRowToTbls(Thasil, "Typstring", "mesin")
        insertRowToTbls(Thasil, "Typstring", "kartu")
        insertRowToTbls(Thasil, "Typstring", "JenisTransaksi")
        insertRowToTbls(Thasil, "Typstring", "Jenis Poli")
        insertRowToTbls(Thasil, "Typstring", "Jenis Bayar")
        insertRowToTbls(Thasil, "Typstring", "Detail Pembayaran")

        For Each Tcol As DataColumn In Thasil.Columns
            Tcol.ReadOnly = True
        Next

        Return Thasil
    End Function

    Private Sub SetClearRekapTagihan()
        ' Set ComboBox Poli Tujuan
        ComboBoxJenisPoliOrTransaksi.Items.Clear()
        If tipeJurnal = "Poli" Then
            Dim tblsJenisPoli As New DataTable
            tblsJenisPoli = ReadSQL("SELECT * FROM MasterPoliTujuan WHERE PoliSakit = 'True' AND JenisPoli NOT IN ('LABORATORIUM')")
            For Each rowPoli As DataRow In tblsJenisPoli.Rows
                ComboBoxJenisPoliOrTransaksi.Items.Add(rowPoli("NamaPoli"))
            Next
        ElseIf tipeJurnal = "Transaksi" Then
            ComboBoxJenisPoliOrTransaksi.Items.Add("POLI")
            ComboBoxJenisPoliOrTransaksi.Items.Add("GIGI")
        End If
        ComboBoxJenisPoliOrTransaksi.SelectedIndex = -1

        ' Set Grid Control
        SetGridRekapTagihan()

        ' Clear Variabel
        TextBoxNamaPerusahaanRekapTagihan.ResetText()

        ' Enable Control
        TglAwalTransaksiRekapTagihan.Enabled = True
        TglAkhirTransaksiRekapTagihan.Enabled = True
        ComboBoxJenisPoliOrTransaksi.Enabled = True
        ButtonFindPerusahaanRekapTagihan.Enabled = True
        TextBoxNamaPerusahaanRekapTagihan.Enabled = True
        ButtonViewDataRekapTagihan.Enabled = True

        ' Change Color Button
        ButtonFindPerusahaanRekapTagihan.BackColor = Color.FromArgb(0, 100, 200)

        ' Disable Control
        PanelCreateInvoice.Visible = False

        ' Set Control Penagihan
        CheckBoxSemuaTransaksiRekapTagihan.Checked = False
        TextBoxBankTransferCoa.ResetText()
        TextBoxBankTransferKeterangan.ResetText()
    End Sub

    Private Sub SetGridRekapTagihan()
        Dim tblOmset As DataTable = CreateTableRekapTagihan()

        GridControlRekapTagihan.DataSource = tblOmset

        GridViewRekapTagihan.Columns("No").Visible = False
        'GridViewRekapTagihan.Columns("ID").Visible = False
        GridViewRekapTagihan.Columns("NoJenisBayar").Visible = False
        GridViewRekapTagihan.Columns("Tgl Lahir").Visible = False
        GridViewRekapTagihan.Columns("Alamat").Visible = False
        GridViewRekapTagihan.Columns("Translabid").Visible = False
        GridViewRekapTagihan.Columns("mesin").Visible = False
        GridViewRekapTagihan.Columns("kartu").Visible = False
        GridViewRekapTagihan.Columns("JenisTransaksi").Visible = False
        GridViewRekapTagihan.Columns("Jenis Bayar").Visible = False
    End Sub

    Function CreateTableRekapTagihan() As DataTable
        Dim Thasil As New DataTable

        insertRowToTbls(Thasil, "tyinterger", "No")
        insertRowToTbls(Thasil, "tyinterger", "ID")
        insertRowToTbls(Thasil, "Typstring", "NoJenisBayar")
        insertRowToTbls(Thasil, "Typstring", "No Transaksi")
        insertRowToTbls(Thasil, "typdate", "Tgl Transaksi")
        insertRowToTbls(Thasil, "Typstring", "Nama")
        insertRowToTbls(Thasil, "typdate", "Tgl Lahir")
        insertRowToTbls(Thasil, "Typstring", "Alamat") '
        insertRowToTbls(Thasil, "Typstring", "pemeriksaan")
        insertRowToTbls(Thasil, "tyinterger", "Tagihan")
        insertRowToTbls(Thasil, "tyinterger", "Translabid")
        insertRowToTbls(Thasil, "Typstring", "mesin")
        insertRowToTbls(Thasil, "Typstring", "kartu")
        insertRowToTbls(Thasil, "Typstring", "JenisTransaksi")
        insertRowToTbls(Thasil, "Typstring", "Jenis Poli")
        insertRowToTbls(Thasil, "Typstring", "Jenis Bayar")
        insertRowToTbls(Thasil, "Typstring", "Detail Pembayaran")
        insertRowToTbls(Thasil, "Typstring", "Jenis Kasir")

        insertRowToTbls(Thasil, "Typstring", "Status")
        insertRowToTbls(Thasil, "typchecked", "Checked")

        For Each Tcol As DataColumn In Thasil.Columns
            Tcol.ReadOnly = True
        Next

        Thasil.Columns("Checked").ReadOnly = False

        Return Thasil
    End Function

    Private Sub ButtonViewDataPendapatan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonViewDataPendapatan.Click
        Try
            ViewDataLaporanPendapatan()
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ViewDataLaporanPendapatan()
        Dim tblPoliUmum As DataTable = GetDataLaporanPendapatanPoliUmum()
        Dim tblPoliGigi As DataTable = GetDataLaporanPendapatanPoliGigi()

        ' Buat tabel gabungan dengan struktur yang sama
        Dim tblOmset As DataTable = tblPoliUmum.Clone()

        ' Gabungkan data dari kedua tabel
        tblOmset.Merge(tblPoliUmum)
        tblOmset.Merge(tblPoliGigi)

        If tblOmset.Rows.Count > 0 Then
            Dim rowTable As DataTable = CreateTableLaporanPendapatan()
            rowTable.Rows.Clear()

            For Each rowData As DataRow In tblOmset.Rows
                ' Set Keterangan Jenis Bayar
                Dim keteranganJenisBayar As String = ""
                If rowData("JenisBayar").ToString = "DEBET" Or rowData("JenisBayar").ToString = "CARD" Then
                    keteranganJenisBayar = rowData("JenisMesin")
                ElseIf rowData("JenisBayar").ToString = "TAGIHAN" Then
                    Dim Tsplit() As String = rowData("CompanyTagihan").Split("-")
                    keteranganJenisBayar = Tsplit(0).ToString.Trim.ToUpper
                End If

                ' Set Keterangan Detail Pembayaran
                Dim keteranganDetailPembayaran As String = ""
                If rowData("JenisBayar").ToString = "DEBET" Or rowData("JenisBayar").ToString = "CARD" Or rowData("JenisBayar").ToString = "TAGIHAN" Then
                    keteranganDetailPembayaran = rowData("JenisBayar").ToString & " " & keteranganJenisBayar
                Else
                    keteranganDetailPembayaran = rowData("JenisBayar").ToString
                End If

                Dim newRow As DataRow = rowTable.NewRow
                newRow("No") = rowData("NomorUrutTransaksi")
                newRow("No Transaksi") = rowData("No Transaksi")
                newRow("Tgl Transaksi") = rowData("Tgl Transaksi")
                newRow("Nama") = rowData("Nama").ToString.ToUpper
                newRow("Tgl Lahir") = rowData("Tgl Lahir")
                newRow("pemeriksaan") = rowData("DataListTindakan")
                newRow("Tagihan") = rowData("TotalBayar")
                newRow("JenisTransaksi") = rowData("JenisTransaksi")
                newRow("Jenis Poli") = rowData("JenisPoli")
                newRow("Jenis Bayar") = rowData("JenisBayar")
                newRow("NoJenisBayar") = keteranganJenisBayar
                newRow("Detail Pembayaran") = keteranganDetailPembayaran
                rowTable.Rows.Add(newRow)
            Next

            GridControlLaporanPendapatan.DataSource = rowTable

            ' Disable Control
            TglAwalTransaksiLaporanPendapatan.Enabled = False
            TglAkhirTransaksiLaporanPendapatan.Enabled = False
            ComboBoxPoliTujuanLaporanPendapatan.Enabled = False
            ButtonFindPerusahaanLaporanPendapatan.Enabled = False
            ButtonViewDataPendapatan.Enabled = False
            CheckBoxTagihan.Enabled = False
            CheckBoxTunai.Enabled = False
            CheckBoxCard.Enabled = False
            CheckBoxDebet.Enabled = False
            CheckBoxTransaksiNolRupiah.Enabled = False
        Else
            MessageBox.Show("Tidak Ada Data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Function GetDataLaporanPendapatanPoliUmum() As DataTable
        ' Set Tanggal Transaksi
        Dim tglTransaksiAwal As Date = TglAwalTransaksiLaporanPendapatan.Value
        Dim tglTransaksiAkhir As Date = TglAkhirTransaksiLaporanPendapatan.Value

        ' Set Jenis Pembayaran
        Dim listJenisBayar As New List(Of String)
        If CheckBoxTagihan.Checked Then listJenisBayar.Add("'Tagihan'")
        If CheckBoxTunai.Checked Then listJenisBayar.Add("'Tunai'")
        If CheckBoxDebet.Checked Then listJenisBayar.Add("'Debet'")
        If CheckBoxCard.Checked Then listJenisBayar.Add("'Card'")
        Dim jenisBayar As String = String.Join(", ", listJenisBayar.ToArray())

        ' Set Jenis Poli
        Dim poliTujuan As String = ""
        If ComboBoxPoliTujuanLaporanPendapatan.Text <> "SEMUA TRANSAKSI" Then
            poliTujuan = "WHERE JenisPoli = '" & ComboBoxPoliTujuanLaporanPendapatan.Text & "'"
        End If

        ' Set Tabel Result
        Dim tblResult As New DataTable

        Dim queryBuilder As New StringBuilder()

        ' WITH clause for FilteredTransPoli
        queryBuilder.AppendLine("WITH FilteredTransPoli AS (")
        queryBuilder.AppendLine("    SELECT TransPoliID, RekapID")
        queryBuilder.AppendLine("    FROM TransaksiPoli")
        queryBuilder.AppendLine("    WHERE (CONVERT(DATE, TglPoli) BETWEEN '" & Format(tglTransaksiAwal.Date, "yyyyMMdd") & "' AND '" & Format(tglTransaksiAkhir.Date, "yyyyMMdd") & "') AND Deleted = 0")
        queryBuilder.AppendLine(")")

        ' Main SELECT statement
        queryBuilder.AppendLine("SELECT ROW_NUMBER() OVER (PARTITION BY tblDetail.JenisPoli, tblBayar.JenisBayar, tblBayar.CompanyTagihan, tblBayar.mesin ORDER BY tblPoli.TglPoli, tblPoli.NoUrut) AS NomorUrutTransaksi, tblBayar.TransPoliIDBayar AS 'ID',")
        queryBuilder.AppendLine("       tblPoli.NoUrut AS 'No Transaksi', CONVERT(DATE, tblPoli.TglPoli) AS 'Tgl Transaksi',")
        queryBuilder.AppendLine("       tblDetail.JenisPoli, tblBayar.DataListTindakan, tblPasien.Nama, CONVERT(DATE, tblPasien.TglLahir) AS 'Tgl Lahir', tblPasien.NoRekamMedis,")
        queryBuilder.AppendLine("       tblBayar.JenisBayar, tblBayar.CompanyTagihan, tblBayar.kartu AS 'JenisKartu',")
        queryBuilder.AppendLine("       tblBayar.mesin AS 'JenisMesin', tblDetail.JenisTransaksi,")
        queryBuilder.AppendLine("       tblBayar.JumlahBayar - tblBayar.Kembali AS TotalBayar, tblPoli.RekapID, tblBayar.NoInvoicePembayaran")
        queryBuilder.AppendLine("FROM (")
        queryBuilder.AppendLine("    SELECT tb.TransPoliIDBayar, tb.TransPoliID,")
        queryBuilder.AppendLine("           STUFF((SELECT ', ' + ISNULL(tblTindakan.NamaTindakan, '')")
        queryBuilder.AppendLine("                  FROM TransaksiPoliDetail tblTindakan")
        queryBuilder.AppendLine("                  WHERE tblTindakan.Awal = '0' AND tblTindakan.TransPoliID = tb.TransPoliID")
        queryBuilder.AppendLine("                  FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS DataListTindakan,")
        queryBuilder.AppendLine("           tb.JenisBayar, CASE WHEN tb.JenisBayar = 'TAGIHAN' THEN tb.NoJenisBayar ELSE '' END AS 'CompanyTagihan', tb.JumlahBayar, tb.Kembali, tb.kartu, tb.mesin, tb.NoInvoicePembayaran")
        queryBuilder.AppendLine("    FROM TransaksiPoliBayar tb")
        queryBuilder.AppendLine("         INNER JOIN FilteredTransPoli ft ON tb.TransPoliID = ft.TransPoliID")
        queryBuilder.AppendLine("    WHERE tb.JenisBayar IN (" & jenisBayar & ")")

        If CheckBoxTransaksiNolRupiah.Checked = False Then
            queryBuilder.AppendLine("    AND tb.JumlahBayar > 0")
        End If

        If CheckBoxTagihan.Checked = True And TextBoxNamaPerusahaanLaporanPendapatan.Text.Length > 0 Then
            queryBuilder.AppendLine("    AND tb.NoJenisBayar = '" & TextBoxNamaPerusahaanLaporanPendapatan.Text & "'")
        End If

        queryBuilder.AppendLine("    UNION ALL")
        queryBuilder.AppendLine("    SELECT tba.TransPoliIDBayar, tba.TransPoliID,")
        queryBuilder.AppendLine("           STUFF((SELECT ', ' + ISNULL(tblTindakan.NamaTindakan, '')")
        queryBuilder.AppendLine("                  FROM TransaksiPoliDetail tblTindakan")
        queryBuilder.AppendLine("                  WHERE tblTindakan.Awal = '1' AND tblTindakan.TransPoliID = tba.TransPoliID")
        queryBuilder.AppendLine("                  FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS DataListTindakan,")
        queryBuilder.AppendLine("           tba.JenisBayar, CASE WHEN tba.JenisBayar = 'TAGIHAN' THEN tba.NoJenisBayar ELSE '' END AS 'CompanyTagihan', tba.JumlahBayar, tba.Kembali, tba.kartu, tba.mesin, tba.NoInvoicePembayaran")
        queryBuilder.AppendLine("    FROM TransaksiPoliBayarAwal tba")
        queryBuilder.AppendLine("         INNER JOIN FilteredTransPoli ft ON tba.TransPoliID = ft.TransPoliID")
        queryBuilder.AppendLine("    WHERE tba.JenisBayar IN (" & jenisBayar & ")")

        If CheckBoxTransaksiNolRupiah.Checked = False Then
            queryBuilder.AppendLine("    AND tba.JumlahBayar > 0")
        End If

        If CheckBoxTagihan.Checked = True And TextBoxNamaPerusahaanLaporanPendapatan.Text.Length > 0 Then
            queryBuilder.AppendLine("    AND tba.NoJenisBayar = '" & TextBoxNamaPerusahaanLaporanPendapatan.Text & "'")
        End If

        queryBuilder.AppendLine(") AS tblBayar")
        queryBuilder.AppendLine("LEFT JOIN TransaksiPoli tblPoli ON tblBayar.TransPoliID = tblPoli.TransPoliID")
        queryBuilder.AppendLine("LEFT JOIN TransaksiDetail tblDetail ON tblPoli.NoUrut = tblDetail.NoUrut")
        queryBuilder.AppendLine("LEFT JOIN MasterPasien tblPasien ON tblPoli.IDInternet = tblPasien.NoRekamMedis")
        If ComboBoxPoliTujuanLaporanPendapatan.Text <> "SEMUA TRANSAKSI" Then
            queryBuilder.AppendLine("WHERE JenisPoli = '" & ComboBoxPoliTujuanLaporanPendapatan.Text & "'")
        End If
        queryBuilder.AppendLine("ORDER BY tblBayar.JenisBayar, tblDetail.JenisPoli")

        tblResult = ReadSQL(queryBuilder.ToString())

        Return tblResult
    End Function

    Function GetDataLaporanPendapatanPoliGigi() As DataTable
        ' Set Tanggal Transaksi
        Dim tglTransaksiAwal As Date = TglAwalTransaksiLaporanPendapatan.Value
        Dim tglTransaksiAkhir As Date = TglAkhirTransaksiLaporanPendapatan.Value

        ' Set Jenis Pembayaran
        Dim listJenisBayar As New List(Of String)
        If CheckBoxTagihan.Checked Then listJenisBayar.Add("'Tagihan'")
        If CheckBoxTunai.Checked Then listJenisBayar.Add("'Tunai'")
        If CheckBoxDebet.Checked Then listJenisBayar.Add("'Debet'")
        If CheckBoxCard.Checked Then listJenisBayar.Add("'Card'")
        Dim jenisBayar As String = String.Join(", ", listJenisBayar.ToArray())

        ' Set Jenis Poli
        Dim poliTujuan As String = ""
        If ComboBoxPoliTujuanLaporanPendapatan.Text <> "SEMUA TRANSAKSI" Then
            poliTujuan = "WHERE JenisPoli = '" & ComboBoxPoliTujuanLaporanPendapatan.Text & "'"
        End If

        ' Set Tabel Result
        Dim tblResult As New DataTable

        Dim queryBuilder As New StringBuilder()

        ' WITH clause for FilteredTransPoli
        queryBuilder.AppendLine("WITH FilteredTransGigi AS (")
        queryBuilder.AppendLine("    SELECT TransGigiID, RekapID")
        queryBuilder.AppendLine("    FROM TransaksiGigi")
        queryBuilder.AppendLine("    WHERE (CONVERT(DATE, TglGigi) BETWEEN '" & Format(tglTransaksiAwal.Date, "yyyyMMdd") & "' AND '" & Format(tglTransaksiAkhir.Date, "yyyyMMdd") & "') AND Deleted = 0")
        queryBuilder.AppendLine(")")

        ' Main SELECT statement
        queryBuilder.AppendLine("SELECT ROW_NUMBER() OVER (PARTITION BY tblDetail.JenisPoli, tblBayar.JenisBayar, tblBayar.CompanyTagihan, tblBayar.mesin ORDER BY tblGigi.TglGigi, tblGigi.NoUrut) AS NomorUrutTransaksi, tblBayar.TransGigiIDBayar AS 'ID',")
        queryBuilder.AppendLine("       tblGigi.NoUrut AS 'No Transaksi', CONVERT(DATE, tblGigi.TglGigi) AS 'Tgl Transaksi',")
        queryBuilder.AppendLine("       tblDetail.JenisPoli, tblBayar.DataListTindakan, tblPasien.Nama, CONVERT(DATE, tblPasien.TglLahir) AS 'Tgl Lahir', tblPasien.NoRekamMedis,")
        queryBuilder.AppendLine("       tblBayar.JenisBayar, tblBayar.CompanyTagihan, tblBayar.kartu AS 'JenisKartu',")
        queryBuilder.AppendLine("       tblBayar.mesin AS 'JenisMesin', tblDetail.JenisTransaksi,")
        queryBuilder.AppendLine("       tblBayar.JumlahBayar - tblBayar.Kembali AS TotalBayar, tblGigi.RekapID, tblBayar.NoInvoicePembayaran")
        queryBuilder.AppendLine("FROM (")
        queryBuilder.AppendLine("    SELECT tb.TransGigiIDBayar, tb.TransGigiID,")
        queryBuilder.AppendLine("           STUFF((SELECT ', ' + ISNULL(tblTindakan.NamaTindakan, '')")
        queryBuilder.AppendLine("                  FROM TransaksiGigiDetail tblTindakan")
        queryBuilder.AppendLine("                  WHERE tblTindakan.Awal = '0' AND tblTindakan.TransGigiID = tb.TransGigiID")
        queryBuilder.AppendLine("                  FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS DataListTindakan,")
        queryBuilder.AppendLine("           tb.JenisBayar, CASE WHEN tb.JenisBayar = 'TAGIHAN' THEN tb.NoJenisBayar ELSE '' END AS 'CompanyTagihan', tb.JumlahBayar, tb.Kembali, tb.kartu, tb.mesin, tb.NoInvoicePembayaran")
        queryBuilder.AppendLine("    FROM TransaksiGigiBayar tb")
        queryBuilder.AppendLine("         INNER JOIN FilteredTransGigi ft ON tb.TransGigiID = ft.TransGigiID")
        queryBuilder.AppendLine("    WHERE tb.JenisBayar IN (" & jenisBayar & ")")

        If CheckBoxTransaksiNolRupiah.Checked = False Then
            queryBuilder.AppendLine("    AND tb.JumlahBayar > 0")
        End If

        If CheckBoxTagihan.Checked = True And TextBoxNamaPerusahaanLaporanPendapatan.Text.Length > 0 Then
            queryBuilder.AppendLine("    AND tb.NoJenisBayar = '" & TextBoxNamaPerusahaanLaporanPendapatan.Text & "'")
        End If

        queryBuilder.AppendLine("    UNION ALL")
        queryBuilder.AppendLine("    SELECT tba.TransGigiIDBayar, tba.TransGigiID,")
        queryBuilder.AppendLine("           STUFF((SELECT ', ' + ISNULL(tblTindakan.NamaTindakan, '')")
        queryBuilder.AppendLine("                  FROM TransaksiGigiDetail tblTindakan")
        queryBuilder.AppendLine("                  WHERE tblTindakan.Awal = '1' AND tblTindakan.TransGigiID = tba.TransGigiID")
        queryBuilder.AppendLine("                  FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS DataListTindakan,")
        queryBuilder.AppendLine("           tba.JenisBayar, CASE WHEN tba.JenisBayar = 'TAGIHAN' THEN tba.NoJenisBayar ELSE '' END AS 'CompanyTagihan', tba.JumlahBayar, tba.Kembali, tba.kartu, tba.mesin, tba.NoInvoicePembayaran")
        queryBuilder.AppendLine("    FROM TransaksiGigiBayarAwal tba")
        queryBuilder.AppendLine("         INNER JOIN FilteredTransGigi ft ON tba.TransGigiID = ft.TransGigiID")
        queryBuilder.AppendLine("    WHERE tba.JenisBayar IN (" & jenisBayar & ")")

        If CheckBoxTransaksiNolRupiah.Checked = False Then
            queryBuilder.AppendLine("    AND tba.JumlahBayar > 0")
        End If

        If CheckBoxTagihan.Checked = True And TextBoxNamaPerusahaanLaporanPendapatan.Text.Length > 0 Then
            queryBuilder.AppendLine("    AND tba.NoJenisBayar = '" & TextBoxNamaPerusahaanLaporanPendapatan.Text & "'")
        End If

        queryBuilder.AppendLine(") AS tblBayar")
        queryBuilder.AppendLine("LEFT JOIN TransaksiGigi tblGigi ON tblBayar.TransGigiID = tblGigi.TransGigiID")
        queryBuilder.AppendLine("LEFT JOIN TransaksiDetail tblDetail ON tblGigi.NoUrut = tblDetail.NoUrut")
        queryBuilder.AppendLine("LEFT JOIN MasterPasien tblPasien ON tblGigi.IDInternet = tblPasien.NoRekamMedis")
        If ComboBoxPoliTujuanLaporanPendapatan.Text <> "SEMUA TRANSAKSI" Then
            queryBuilder.AppendLine("WHERE JenisPoli = '" & ComboBoxPoliTujuanLaporanPendapatan.Text & "'")
        End If
        queryBuilder.AppendLine("ORDER BY tblBayar.JenisBayar, tblDetail.JenisPoli")

        tblResult = ReadSQL(queryBuilder.ToString())

        Return tblResult
    End Function

    Private Sub ButtonFindPerusahaan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFindPerusahaanLaporanPendapatan.Click
        Find.Show()
        Find.Query("SELECT NoCompany AS 'ID', CompanyCode AS 'Kode Perusahaan', CompanyNama AS 'Keterangan' FROM mastercompany WHERE GETDATE() BETWEEN StartDate AND EndDate", " ORDER BY NoCompany ASC", "FindPerusahaanReportPendapatanKlinik_LaporanPendapatan", 2)
    End Sub

    Private Sub ButtonCetakLaporanPendapatan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCetakLaporanPendapatan.Click
        Dim tblOmset As DataTable = GridControlLaporanPendapatan.DataSource

        If tblOmset.Rows.Count > 0 Then
            If RadioButtonOptionLaporanPendapatan.Checked Then
                LaporanPendapatanKlinikVersi1()
            ElseIf RadioButtonOptionLaporanPendapatanTagihan.Checked Then
                LaporanPendapatanKlinikVersi2()
            End If
        Else
            MessageBox.Show("Tidak Ada Data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub LaporanPendapatanKlinikVersi1()
        ' Set Tanggal Transaksi
        Dim tglTransaksiAwal As Date = TglAwalTransaksiLaporanPendapatan.Value
        Dim tglTransaksiAkhir As Date = TglAkhirTransaksiLaporanPendapatan.Value

        ' Convert Tanggal Transaksi
        Dim stringTglTransaksiAwal As String = Format(tglTransaksiAwal, "dd") & " " & BulanIndonesia(Format(tglTransaksiAwal, "MM")) & " " & Format(tglTransaksiAwal, "yyyy")
        Dim stringTglTransaksiAkhir As String = Format(tglTransaksiAkhir, "dd") & " " & BulanIndonesia(Format(tglTransaksiAkhir, "MM")) & " " & Format(tglTransaksiAkhir, "yyyy")

        Dim tblOmset As DataTable = GridControlLaporanPendapatan.DataSource
        tblOmset.AcceptChanges()

        Report = New XtraReport
        Report = XtraReport.FromFile(Application.StartupPath + "\reports\Klinik\Laporan\LaporanPendapatanKlinikVersi1.repx", True)

        Report.Bands.Item(BandKind.ReportHeader).Controls("xrLabelJudulLaporan").Text = "Laporan Pendapatan Klinik"
        Report.Bands.Item(BandKind.ReportHeader).Controls("xrLabelLokasiLaporan").Text = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NamaPoli'")
        Report.Bands.Item(BandKind.ReportHeader).Controls("xrLabelTanggalLaporan").Text = stringTglTransaksiAwal & " - " & stringTglTransaksiAkhir
        Report.Bands.Item(BandKind.PageFooter).Controls("xrLabelInfoCetak").Text = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:ss") & " By " & userInput
        Report.DataSource = tblOmset

        'Report.RunDesigner()
        Report.ShowPreview()
        'Report.Print()
    End Sub

    Private Sub LaporanPendapatanKlinikVersi2()
        ' Set Tanggal Transaksi
        Dim tglTransaksiAwal As Date = TglAwalTransaksiLaporanPendapatan.Value
        Dim tglTransaksiAkhir As Date = TglAkhirTransaksiLaporanPendapatan.Value

        ' Convert Tanggal Transaksi
        Dim stringTglTransaksiAwal As String = Format(tglTransaksiAwal, "dd") & " " & BulanIndonesia(Format(tglTransaksiAwal, "MM")) & " " & Format(tglTransaksiAwal, "yyyy")
        Dim stringTglTransaksiAkhir As String = Format(tglTransaksiAkhir, "dd") & " " & BulanIndonesia(Format(tglTransaksiAkhir, "MM")) & " " & Format(tglTransaksiAkhir, "yyyy")

        Dim tblOmset As DataTable = GridControlLaporanPendapatan.DataSource
        tblOmset.AcceptChanges()

        ' Ubah kolom "No" menjadi tidak readonly sementara
        tblOmset.Columns("No").ReadOnly = False

        Dim rowNumber As Integer = 0
        For Each Trow As DataRow In tblOmset.Rows
            rowNumber = rowNumber + 1
            Trow("No") = rowNumber
        Next

        Report = New XtraReport
        Report = XtraReport.FromFile(Application.StartupPath + "\reports\Klinik\Laporan\LaporanPendapatanKlinikVersi2.repx", True)

        Report.Bands.Item(BandKind.ReportHeader).Controls("xrLabelJudulLaporan").Text = "Laporan Pendapatan Klinik"
        Report.Bands.Item(BandKind.ReportHeader).Controls("xrLabelLokasiLaporan").Text = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NamaPoli'")
        Report.Bands.Item(BandKind.ReportHeader).Controls("xrLabelTanggalLaporan").Text = stringTglTransaksiAwal & " - " & stringTglTransaksiAkhir
        Report.Bands.Item(BandKind.PageFooter).Controls("xrLabelInfoCetak").Text = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:ss") & " By " & userInput
        Report.DataSource = tblOmset

        'Report.RunDesigner()
        Report.ShowPreview()
        'Report.Print()
    End Sub

    Private Sub ButtonClearDataLaporanPendapatan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClearDataLaporanPendapatan.Click
        SetClearLaporanPendapatan()
    End Sub

    Private Sub ButtonViewDataRekapTagihan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonViewDataRekapTagihan.Click
        Try
            If ValidasiViewDataRekapTagihan() = True Then
                ViewDataRekapTagihan()
            End If
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function ValidasiViewDataRekapTagihan() As Boolean
        If TglAkhirTransaksiRekapTagihan.Value.Date < TglAwalTransaksiRekapTagihan.Value.Date Then
            MsgBox("Tanggal akhir tidak boleh melebihi tanggal mulai.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        If TextBoxNamaPerusahaanRekapTagihan.Text = "" Then
            MsgBox("Pilih perusahaan terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        Return True
    End Function

    Private Sub ViewDataRekapTagihan()
        Dim tblPoliUmum As DataTable = GetDataRekapTagihanPoliUmum()
        Dim tblPoliGigi As DataTable = GetDataRekapTagihanPoliGigi()

        ' Buat tabel gabungan dengan struktur yang sama
        Dim tblOmset As DataTable = tblPoliUmum.Clone()

        ' Gabungkan data dari kedua tabel
        tblOmset.Merge(tblPoliUmum)
        tblOmset.Merge(tblPoliGigi)

        If tblOmset.Rows.Count > 0 Then
            Dim rowTable As DataTable = CreateTableRekapTagihan()
            rowTable.Rows.Clear()

            For Each rowData As DataRow In tblOmset.Rows
                ' Set Keterangan Jenis Bayar
                Dim keteranganJenisBayar As String = ""
                If rowData("JenisBayar").ToString = "DEBET" Or rowData("JenisBayar").ToString = "CARD" Then
                    keteranganJenisBayar = rowData("JenisMesin")
                ElseIf rowData("JenisBayar").ToString = "TAGIHAN" Then
                    Dim Tsplit() As String = rowData("CompanyTagihan").Split("-")
                    keteranganJenisBayar = Tsplit(0).ToString.Trim.ToUpper
                End If

                ' Set Keterangan Detail Pembayaran
                Dim keteranganDetailPembayaran As String = ""
                If rowData("JenisBayar").ToString = "DEBET" Or rowData("JenisBayar").ToString = "CARD" Or rowData("JenisBayar").ToString = "TAGIHAN" Then
                    keteranganDetailPembayaran = rowData("JenisBayar").ToString & " " & keteranganJenisBayar
                Else
                    keteranganDetailPembayaran = rowData("JenisBayar").ToString
                End If

                Dim newRow As DataRow = rowTable.NewRow
                newRow("No") = rowData("NomorUrutTransaksi")
                newRow("ID") = rowData("ID")
                newRow("No Transaksi") = rowData("No Transaksi")
                newRow("Tgl Transaksi") = rowData("Tgl Transaksi")
                newRow("Nama") = rowData("Nama").ToString.ToUpper
                newRow("Tgl Lahir") = rowData("Tgl Lahir")
                newRow("pemeriksaan") = rowData("DataListTindakan")
                newRow("Tagihan") = rowData("TotalBayar")
                newRow("JenisTransaksi") = rowData("JenisTransaksi")
                newRow("Jenis Poli") = rowData("JenisPoli")
                newRow("Jenis Bayar") = rowData("JenisBayar")
                newRow("NoJenisBayar") = keteranganJenisBayar
                newRow("Detail Pembayaran") = keteranganDetailPembayaran
                newRow("Jenis Kasir") = rowData("JenisKasir")

                If IsDBNull(rowData("RekapID")) = False Or IsDBNull(rowData("NoInvoicePembayaran")) = False Then
                    newRow("Status") = "CLOSED"
                    newRow("Checked") = True
                Else
                    newRow("Status") = "-"
                    newRow("Checked") = False
                End If

                rowTable.Rows.Add(newRow)
            Next

            GridControlRekapTagihan.DataSource = rowTable

            ' Disable Control
            TglAwalTransaksiRekapTagihan.Enabled = False
            TglAkhirTransaksiRekapTagihan.Enabled = False
            ComboBoxJenisPoliOrTransaksi.Enabled = False
            ButtonFindPerusahaanRekapTagihan.Enabled = False
            TextBoxNamaPerusahaanRekapTagihan.Enabled = False
            ButtonViewDataRekapTagihan.Enabled = False

            ' Change Color Button
            ButtonFindPerusahaanRekapTagihan.BackColor = Color.FromArgb(225, 225, 225)

            ' Enable Control
            PanelCreateInvoice.Visible = True
        Else
            MessageBox.Show("Tidak Ada Data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Function GetDataRekapTagihanPoliUmum() As DataTable
        ' Set Tanggal Transaksi
        Dim tglTransaksiAwal As Date = TglAwalTransaksiRekapTagihan.Value
        Dim tglTransaksiAkhir As Date = TglAkhirTransaksiRekapTagihan.Value

        ' Set Jenis Pembayaran
        Dim jenisBayar As String = "'Tagihan'"

        ' Set Jenis Poli / Transaksi
        Dim jenisPoliOrTransaksi As String = ""
        If tipeJurnal = "Poli" Then
            If ComboBoxJenisPoliOrTransaksi.Text <> "SEMUA TRANSAKSI" Then
                jenisPoliOrTransaksi = "WHERE JenisPoli = '" & ComboBoxJenisPoliOrTransaksi.Text & "'"
            End If
        ElseIf tipeJurnal = "Transaksi" Then
            jenisPoliOrTransaksi = "WHERE JenisTransaksi = '" & ComboBoxJenisPoliOrTransaksi.Text & "'"
        End If

        ' Set Tabel Result
        Dim tblResult As New DataTable

        Dim queryBuilder As New StringBuilder()

        ' WITH clause for FilteredTransPoli
        queryBuilder.AppendLine("WITH FilteredTransPoli AS (")
        queryBuilder.AppendLine("    SELECT TransPoliID, RekapID")
        queryBuilder.AppendLine("    FROM TransaksiPoli")
        queryBuilder.AppendLine("    WHERE (CONVERT(DATE, TglPoli) BETWEEN '" & Format(tglTransaksiAwal.Date, "yyyyMMdd") & "' AND '" & Format(tglTransaksiAkhir.Date, "yyyyMMdd") & "') AND Deleted = 0")
        queryBuilder.AppendLine(")")

        ' Main SELECT statement
        queryBuilder.AppendLine("SELECT ROW_NUMBER() OVER (PARTITION BY tblDetail.JenisPoli, tblBayar.JenisBayar, tblBayar.CompanyTagihan, tblBayar.mesin ORDER BY tblPoli.TglPoli, tblPoli.NoUrut) AS NomorUrutTransaksi, tblBayar.TransPoliIDBayar AS 'ID',")
        queryBuilder.AppendLine("       tblPoli.NoUrut AS 'No Transaksi', CONVERT(DATE, tblPoli.TglPoli) AS 'Tgl Transaksi',")
        queryBuilder.AppendLine("       tblDetail.JenisPoli, tblBayar.DataListTindakan, tblPasien.Nama, CONVERT(DATE, tblPasien.TglLahir) AS 'Tgl Lahir', tblPasien.NoRekamMedis,")
        queryBuilder.AppendLine("       tblBayar.JenisBayar, tblBayar.CompanyTagihan, tblBayar.kartu AS 'JenisKartu',")
        queryBuilder.AppendLine("       tblBayar.mesin AS 'JenisMesin', tblDetail.JenisTransaksi,")
        queryBuilder.AppendLine("       tblBayar.JumlahBayar - tblBayar.Kembali AS TotalBayar, tblPoli.RekapID, tblBayar.NoInvoicePembayaran, tblBayar.JenisKasir")
        queryBuilder.AppendLine("FROM (")
        queryBuilder.AppendLine("    SELECT tb.TransPoliIDBayar, tb.TransPoliID,")
        queryBuilder.AppendLine("           STUFF((SELECT ', ' + ISNULL(tblTindakan.NamaTindakan, '')")
        queryBuilder.AppendLine("                  FROM TransaksiPoliDetail tblTindakan")
        queryBuilder.AppendLine("                  WHERE tblTindakan.Awal = '0' AND tblTindakan.TransPoliID = tb.TransPoliID")
        queryBuilder.AppendLine("                  FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS DataListTindakan,")
        queryBuilder.AppendLine("           tb.JenisBayar, CASE WHEN tb.JenisBayar = 'TAGIHAN' THEN tb.NoJenisBayar ELSE '' END AS 'CompanyTagihan', tb.JumlahBayar, tb.Kembali, tb.kartu, tb.mesin, tb.NoInvoicePembayaran, 'Transaksi Tindakan' AS JenisKasir")
        queryBuilder.AppendLine("    FROM TransaksiPoliBayar tb")
        queryBuilder.AppendLine("         INNER JOIN FilteredTransPoli ft ON tb.TransPoliID = ft.TransPoliID")
        queryBuilder.AppendLine("    WHERE tb.JumlahBayar > 0 AND tb.JenisBayar IN (" & jenisBayar & ")")
        If CheckBoxTagihan.Checked = True And TextBoxNamaPerusahaanRekapTagihan.Text.Length > 0 Then
            queryBuilder.AppendLine("    AND tb.NoJenisBayar = '" & TextBoxNamaPerusahaanRekapTagihan.Text & "'")
        End If
        queryBuilder.AppendLine("    UNION ALL")
        queryBuilder.AppendLine("    SELECT tba.TransPoliIDBayar, tba.TransPoliID,")
        queryBuilder.AppendLine("           STUFF((SELECT ', ' + ISNULL(tblTindakan.NamaTindakan, '')")
        queryBuilder.AppendLine("                  FROM TransaksiPoliDetail tblTindakan")
        queryBuilder.AppendLine("                  WHERE tblTindakan.Awal = '1' AND tblTindakan.TransPoliID = tba.TransPoliID")
        queryBuilder.AppendLine("                  FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS DataListTindakan,")
        queryBuilder.AppendLine("           tba.JenisBayar, CASE WHEN tba.JenisBayar = 'TAGIHAN' THEN tba.NoJenisBayar ELSE '' END AS 'CompanyTagihan', tba.JumlahBayar, tba.Kembali, tba.kartu, tba.mesin, tba.NoInvoicePembayaran, 'Transaksi Awal' AS JenisKasir")
        queryBuilder.AppendLine("    FROM TransaksiPoliBayarAwal tba")
        queryBuilder.AppendLine("         INNER JOIN FilteredTransPoli ft ON tba.TransPoliID = ft.TransPoliID")
        queryBuilder.AppendLine("    WHERE tba.JumlahBayar > 0 AND tba.JenisBayar IN (" & jenisBayar & ")")
        If CheckBoxTagihan.Checked = True And TextBoxNamaPerusahaanRekapTagihan.Text.Length > 0 Then
            queryBuilder.AppendLine("    AND tba.NoJenisBayar = '" & TextBoxNamaPerusahaanRekapTagihan.Text & "'")
        End If
        queryBuilder.AppendLine(") AS tblBayar")
        queryBuilder.AppendLine("LEFT JOIN TransaksiPoli tblPoli ON tblBayar.TransPoliID = tblPoli.TransPoliID")
        queryBuilder.AppendLine("LEFT JOIN TransaksiDetail tblDetail ON tblPoli.NoUrut = tblDetail.NoUrut")
        queryBuilder.AppendLine("LEFT JOIN MasterPasien tblPasien ON tblPoli.IDInternet = tblPasien.NoRekamMedis")
        queryBuilder.AppendLine(jenisPoliOrTransaksi)
        queryBuilder.AppendLine("ORDER BY tblBayar.JenisBayar, tblDetail.JenisPoli")

        tblResult = ReadSQL(queryBuilder.ToString())

        Return tblResult
    End Function

    Function GetDataRekapTagihanPoliGigi() As DataTable
        ' Set Tanggal Transaksi
        Dim tglTransaksiAwal As Date = TglAwalTransaksiRekapTagihan.Value
        Dim tglTransaksiAkhir As Date = TglAkhirTransaksiRekapTagihan.Value

        ' Set Jenis Pembayaran
        Dim jenisBayar As String = "'Tagihan'"

        ' Set Jenis Poli / Transaksi
        Dim jenisPoliOrTransaksi As String = ""
        If tipeJurnal = "Poli" Then
            If ComboBoxJenisPoliOrTransaksi.Text <> "SEMUA TRANSAKSI" Then
                jenisPoliOrTransaksi = "WHERE JenisPoli = '" & ComboBoxJenisPoliOrTransaksi.Text & "'"
            End If
        ElseIf tipeJurnal = "Transaksi" Then
            jenisPoliOrTransaksi = "WHERE JenisTransaksi = '" & ComboBoxJenisPoliOrTransaksi.Text & "'"
        End If

        ' Set Tabel Result
        Dim tblResult As New DataTable

        Dim queryBuilder As New StringBuilder()

        ' WITH clause for FilteredTransPoli
        queryBuilder.AppendLine("WITH FilteredTransGigi AS (")
        queryBuilder.AppendLine("    SELECT TransGigiID, RekapID")
        queryBuilder.AppendLine("    FROM TransaksiGigi")
        queryBuilder.AppendLine("    WHERE (CONVERT(DATE, TglGigi) BETWEEN '" & Format(tglTransaksiAwal.Date, "yyyyMMdd") & "' AND '" & Format(tglTransaksiAkhir.Date, "yyyyMMdd") & "') AND Deleted = 0")
        queryBuilder.AppendLine(")")

        ' Main SELECT statement
        queryBuilder.AppendLine("SELECT ROW_NUMBER() OVER (PARTITION BY tblDetail.JenisPoli, tblBayar.JenisBayar, tblBayar.CompanyTagihan, tblBayar.mesin ORDER BY tblGigi.TglGigi, tblGigi.NoUrut) AS NomorUrutTransaksi, tblBayar.TransGigiIDBayar AS 'ID',")
        queryBuilder.AppendLine("       tblGigi.NoUrut AS 'No Transaksi', CONVERT(DATE, tblGigi.TglGigi) AS 'Tgl Transaksi',")
        queryBuilder.AppendLine("       tblDetail.JenisPoli, tblBayar.DataListTindakan, tblPasien.Nama, CONVERT(DATE, tblPasien.TglLahir) AS 'Tgl Lahir', tblPasien.NoRekamMedis,")
        queryBuilder.AppendLine("       tblBayar.JenisBayar, tblBayar.CompanyTagihan, tblBayar.kartu AS 'JenisKartu',")
        queryBuilder.AppendLine("       tblBayar.mesin AS 'JenisMesin', tblDetail.JenisTransaksi,")
        queryBuilder.AppendLine("       tblBayar.JumlahBayar - tblBayar.Kembali AS TotalBayar, tblGigi.RekapID, tblBayar.NoInvoicePembayaran, tblBayar.JenisKasir")
        queryBuilder.AppendLine("FROM (")
        queryBuilder.AppendLine("    SELECT tb.TransGigiIDBayar, tb.TransGigiID,")
        queryBuilder.AppendLine("           STUFF((SELECT ', ' + ISNULL(tblTindakan.NamaTindakan, '')")
        queryBuilder.AppendLine("                  FROM TransaksiGigiDetail tblTindakan")
        queryBuilder.AppendLine("                  WHERE tblTindakan.Awal = '0' AND tblTindakan.TransGigiID = tb.TransGigiID")
        queryBuilder.AppendLine("                  FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS DataListTindakan,")
        queryBuilder.AppendLine("           tb.JenisBayar, CASE WHEN tb.JenisBayar = 'TAGIHAN' THEN tb.NoJenisBayar ELSE '' END AS 'CompanyTagihan', tb.JumlahBayar, tb.Kembali, tb.kartu, tb.mesin, tb.NoInvoicePembayaran, 'Transaksi Tindakan' AS JenisKasir")
        queryBuilder.AppendLine("    FROM TransaksiGigiBayar tb")
        queryBuilder.AppendLine("         INNER JOIN FilteredTransGigi ft ON tb.TransGigiID = ft.TransGigiID")
        queryBuilder.AppendLine("    WHERE tb.JumlahBayar > 0 AND tb.JenisBayar IN (" & jenisBayar & ")")
        If CheckBoxTagihan.Checked = True And TextBoxNamaPerusahaanRekapTagihan.Text.Length > 0 Then
            queryBuilder.AppendLine("    AND tb.NoJenisBayar = '" & TextBoxNamaPerusahaanRekapTagihan.Text & "'")
        End If
        queryBuilder.AppendLine("    UNION ALL")
        queryBuilder.AppendLine("    SELECT tba.TransGigiIDBayar, tba.TransGigiID,")
        queryBuilder.AppendLine("           STUFF((SELECT ', ' + ISNULL(tblTindakan.NamaTindakan, '')")
        queryBuilder.AppendLine("                  FROM TransaksiGigiDetail tblTindakan")
        queryBuilder.AppendLine("                  WHERE tblTindakan.Awal = '1' AND tblTindakan.TransGigiID = tba.TransGigiID")
        queryBuilder.AppendLine("                  FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS DataListTindakan,")
        queryBuilder.AppendLine("           tba.JenisBayar, CASE WHEN tba.JenisBayar = 'TAGIHAN' THEN tba.NoJenisBayar ELSE '' END AS 'CompanyTagihan', tba.JumlahBayar, tba.Kembali, tba.kartu, tba.mesin, tba.NoInvoicePembayaran, 'Transaksi Awal' AS JenisKasir")
        queryBuilder.AppendLine("    FROM TransaksiGigiBayarAwal tba")
        queryBuilder.AppendLine("         INNER JOIN FilteredTransGigi ft ON tba.TransGigiID = ft.TransGigiID")
        queryBuilder.AppendLine("    WHERE tba.JumlahBayar > 0 AND tba.JenisBayar IN (" & jenisBayar & ")")
        If CheckBoxTagihan.Checked = True And TextBoxNamaPerusahaanRekapTagihan.Text.Length > 0 Then
            queryBuilder.AppendLine("    AND tba.NoJenisBayar = '" & TextBoxNamaPerusahaanRekapTagihan.Text & "'")
        End If
        queryBuilder.AppendLine(") AS tblBayar")
        queryBuilder.AppendLine("LEFT JOIN TransaksiGigi tblGigi ON tblBayar.TransGigiID = tblGigi.TransGigiID")
        queryBuilder.AppendLine("LEFT JOIN TransaksiDetail tblDetail ON tblGigi.NoUrut = tblDetail.NoUrut")
        queryBuilder.AppendLine("LEFT JOIN MasterPasien tblPasien ON tblGigi.IDInternet = tblPasien.NoRekamMedis")
        queryBuilder.AppendLine(jenisPoliOrTransaksi)
        queryBuilder.AppendLine("ORDER BY tblBayar.JenisBayar, tblDetail.JenisPoli")

        tblResult = ReadSQL(queryBuilder.ToString())

        Return tblResult
    End Function

    Private Sub ButtonClearDataRekapTagihan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClearDataRekapTagihan.Click
        SetClearRekapTagihan()
    End Sub

    Private Sub CheckBoxSemuaTransaksiRekapTagihan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxSemuaTransaksiRekapTagihan.CheckedChanged
        Dim tblTagihan As DataTable = GridControlRekapTagihan.DataSource

        If tblTagihan IsNot Nothing AndAlso tblTagihan.Rows.Count > 0 Then
            For Each rowTransaksi As DataRow In tblTagihan.Rows
                If CheckBoxSemuaTransaksiRekapTagihan.CheckState = CheckState.Checked Then
                    rowTransaksi("Checked") = True
                Else
                    If rowTransaksi("Status").ToString() <> "CLOSED" Then rowTransaksi("Checked") = False
                End If
            Next
        Else
            CheckBoxSemuaTransaksiRekapTagihan.Checked = False
        End If
    End Sub

    Private Sub ButtonFindBankTagihan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFindBankTagihan.Click
        Find.Show()
        Find.QueryTheMysql("SELECT a.NamaBank, a.NomorRekening, a.NamaRekening, a.CabangRekening, a.CoaBank FROM MasterBankTransfer a WHERE a.StatusAktif = 1 AND a.TransferTagihan = 1", " ", "FindBankTagihanReportPendapatanKlinik", 0, Find_Omset)
    End Sub

    Private Sub ButtonSimpanRekapTagihan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSimpanRekapTagihan.Click
        Try
            If ValidasiSimpanRekapTagihan() = True Then
                CreateInvoiceTagihan()
            End If
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function CreateTableInvoice() As DataTable
        Dim Thasil As New DataTable

        insertRowToTbls(Thasil, "Typstring", "TglInvoice")
        insertRowToTbls(Thasil, "Typstring", "TglJatuhTempo")
        insertRowToTbls(Thasil, "Typstring", "NomorInvoice")
        insertRowToTbls(Thasil, "Typstring", "NamaPerusahaan")
        insertRowToTbls(Thasil, "Typstring", "TglTTD")
        insertRowToTbls(Thasil, "Typstring", "UserTTD")
        insertRowToTbls(Thasil, "Typstring", "KeteranganNominal")
        insertRowToTbls(Thasil, "Typstring", "NamaRekeningBank")
        insertRowToTbls(Thasil, "Typstring", "NomorRekeningBank")
        insertRowToTbls(Thasil, "Typstring", "NamaBank")
        insertRowToTbls(Thasil, "Typstring", "KeteranganEmail")

        Return Thasil
    End Function

    Function ValidasiSimpanRekapTagihan() As Boolean
        'Dim tblTransaksi As DataTable = GridControlTransaksi.DataSource

        'If tblTransaksi IsNot Nothing AndAlso tblTransaksi.Rows.Count > 0 Then
        '    For Each rowTransaksi As DataRow In tblTransaksi.Select("[Checked]=True")
        '        If rowTransaksi("Status") <> "CLOSED" Then
        '            ' Validasi apakah ada tindakan yang belum di BHP
        '            If rowTransaksi("Status BHP") = 1 And rowTransaksi("Nominal BHP") = 0 Then
        '                MsgBox("Tindakan " & rowTransaksi("Tindakan") & " atas nama " & rowTransaksi("Nama Pasien") & " (" & rowTransaksi("No Transaksi") & ") belum dilakukan BHP.", MsgBoxStyle.Exclamation, "Warning!")
        '                Return False
        '            End If
        '        End If
        '    Next
        'End If

        If TglJatuhTempoRekapTagihan.Value.Date < Date.Now.Date Then
            MsgBox("Tanggal jatuh tempo tidak boleh kurang dari tanggal hari ini.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        If TextBoxBankTransferKeterangan.Text = "" Then
            MsgBox("Pilih bank terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        If MsgBox("Yakin ingin menyimpan data tersebut? ", MsgBoxStyle.YesNo, "Validasi.") = MsgBoxResult.No Then
            Return False
        End If

        Return True
    End Function

    Function GetNomorInvoiceTagihan() As String
        Dim NoTagihan As String = ""
        Dim NoRef1 As String = ""
        Dim NoRef2 As String = ""
        Dim NoRef3 As String = ""

        Dim angka2 As String = "0001"
        Dim angka As String = ReadThemysqlNIK("SELECT concat(lpad(LEFT(notagihancompany,4)+1,4,0)) FROM acctransrekaptagihan WHERE DATE(tgltagihan) BETWEEN DATE_FORMAT('" & Format(DateAndTime.Now, "yyyy-MM-dd") & "' ,'%Y-%m-01 %T') AND LAST_DAY('" & Format(DateAndTime.Now, "yyyy-MM-dd") & "') ORDER BY notagihancompany DESC LIMIT 1", DB_Keuangan)

        If angka = "" Or angka = "-" Then
            NoRef1 = angka2
        ElseIf angka <> "" Then
            NoRef1 = angka
        End If

        NoRef2 = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='KodeInvoicePoli'")
        NoRef3 = GetRomes(DateAndTime.Now.Month) & "/" & Format(DateAndTime.Now, "yyyy")
        NoTagihan = NoRef1 & "/" & NoRef2 & "/" & NoRef3

        Return NoTagihan
    End Function

    Private Sub CreateInvoiceTagihan()
        Dim jenisTransaksi As String = ""
        Dim jenisPoli As String = ""

        Dim totalTransaksi As Integer = 0
        Dim totalTagihan As Integer = 0

        ' Set Jenis Poli / Transaksi
        If tipeJurnal = "Transaksi" Then jenisTransaksi = ComboBoxJenisPoliOrTransaksi.Text
        If tipeJurnal = "Poli" Then jenisPoli = ComboBoxJenisPoliOrTransaksi.Text

        Dim sqlJenisTransaksi As String = If(jenisTransaksi = "", "NULL", "'" & jenisTransaksi & "'")
        Dim sqlJenisPoli As String = If(jenisPoli = "", "NULL", "'" & jenisPoli & "'")

        ' Set Nama Perusahaan
        Dim splitPerusahaan() As String = TextBoxNamaPerusahaanRekapTagihan.Text.Split("-")

        ' Set Data No Transaksi
        Dim idDetailTransaksiPoliAwal As String = ""
        Dim idDetailTransaksiGigiAwal As String = ""
        Dim idDetailTransaksiPoliAkhir As String = ""
        Dim idDetailTransaksiGigiAkhir As String = ""
        Dim nomorTransaksiPoli As String = ""
        Dim nomorTransaksiGigi As String = ""

        ' Set HashSet untuk setiap jenis transaksi
        Dim tempTransaksiPoli As New HashSet(Of String)()
        Dim tempTransaksiGigi As New HashSet(Of String)()

        Dim tblTransaksi As DataTable = GridControlRekapTagihan.DataSource
        If tblTransaksi IsNot Nothing AndAlso tblTransaksi.Rows.Count > 0 Then
            For Each rowTransaksi As DataRow In tblTransaksi.Select("[Checked]=True")
                If rowTransaksi("Status") <> "CLOSED" Then
                    totalTagihan = totalTagihan + CDbl(rowTransaksi("Tagihan"))

                    Select Case rowTransaksi("JenisTransaksi").ToString()
                        Case "POLI"
                            ' Set Nomor Transaksi
                            If tempTransaksiPoli.Add(rowTransaksi("No Transaksi").ToString()) Then
                                nomorTransaksiPoli &= "'" & rowTransaksi("No Transaksi").ToString() & "',"
                            End If

                            ' Set ID Detail (Untuk Update Flag)
                            If rowTransaksi("Jenis Kasir").ToString() = "Transaksi Awal" Then
                                idDetailTransaksiPoliAwal &= "'" & rowTransaksi("ID").ToString() & "',"
                            ElseIf rowTransaksi("Jenis Kasir").ToString() = "Transaksi Tindakan" Then
                                idDetailTransaksiPoliAkhir &= "'" & rowTransaksi("ID").ToString() & "',"
                            End If
                        Case "GIGI"
                            ' Set Nomor Transaksi
                            If tempTransaksiGigi.Add(rowTransaksi("No Transaksi").ToString()) Then
                                nomorTransaksiGigi &= "'" & rowTransaksi("No Transaksi").ToString() & "',"
                            End If

                            ' Set ID Detail (Untuk Update Flag)
                            If rowTransaksi("Jenis Kasir").ToString() = "Transaksi Awal" Then
                                idDetailTransaksiGigiAwal &= "'" & rowTransaksi("ID").ToString() & "',"
                            ElseIf rowTransaksi("Jenis Kasir").ToString() = "Transaksi Tindakan" Then
                                idDetailTransaksiGigiAkhir &= "'" & rowTransaksi("ID").ToString() & "',"
                            End If
                    End Select

                    ' Tambah Total Transaksi
                    totalTransaksi += 1
                End If
            Next

            If totalTransaksi > 0 Then
                Dim nomorInvoice As String = GetNomorInvoiceTagihan()
                Dim tglJatuhTempo As Date = TglJatuhTempoRekapTagihan.Value
                Dim tblBankTransfer As DataTable = ReadThemysql("SELECT * FROM MasterBankTransfer WHERE CoaBank = '" & TextBoxBankTransferCoa.Text & "'", DB_Omset)
                Dim rowBankTransfer As DataRow = tblBankTransfer.Rows(0)

                ' Insert Database Rekap Tagihan Online
                WriteThemysql("INSERT INTO acctransrekaptagihan(company, tgltagihan, periode, duedate, totaltagihan, keterangan, createdate, createby, notagihancompany, cabang, JenisTransaksi, JenisPoli) " & _
                              "VALUES('" & TextBoxNamaPerusahaanRekapTagihan.Text & "', NOW(), '" & CInt(0) & "', '" & Format(tglJatuhTempo, "yyyy/MM/dd") & "', '" & CDbl(totalTagihan) & "', '-', NOW(), '" & userInput & "', '" & nomorInvoice & "', '" & kodeLokasiKlinik & "', " & sqlJenisTransaksi & ", " & sqlJenisPoli & ") ", DB_Keuangan)

                ' Get Rekap ID
                Dim rekapID As String = ReadThemysqlNIK("SELECT a.RekapID FROM acctransrekaptagihan a ORDER BY a.RekapID DESC LIMIT 1", DB_Keuangan)

                ' Update Flag Tabel TransaksiPoliBayarAwal
                If idDetailTransaksiPoliAwal <> "" Then
                    idDetailTransaksiPoliAwal = Strings.Left(idDetailTransaksiPoliAwal, idDetailTransaksiPoliAwal.Length - 1)
                    WriteSQL("UPDATE TransaksiPoliBayarAwal SET NoInvoicePembayaran = '" & nomorInvoice & "', RekapBy = '" & userInput & "', RekapDate = GETDATE() WHERE TransPoliIDBayar IN (" & idDetailTransaksiPoliAwal & ")", 4)
                End If

                ' Update Flag Tabel TransaksiGigiBayarAwal
                If idDetailTransaksiGigiAwal <> "" Then
                    idDetailTransaksiGigiAwal = Strings.Left(idDetailTransaksiGigiAwal, idDetailTransaksiGigiAwal.Length - 1)
                    WriteSQL("UPDATE TransaksiGigiBayarAwal SET NoInvoicePembayaran = '" & nomorInvoice & "', RekapBy = '" & userInput & "', RekapDate = GETDATE() WHERE TransGigiIDBayar IN (" & idDetailTransaksiGigiAwal & ")", 4)
                End If

                ' Update Flag Tabel TransaksiPoliBayar
                If idDetailTransaksiPoliAkhir <> "" Then
                    idDetailTransaksiPoliAkhir = Strings.Left(idDetailTransaksiPoliAkhir, idDetailTransaksiPoliAkhir.Length - 1)
                    WriteSQL("UPDATE TransaksiPoliBayar SET NoInvoicePembayaran = '" & nomorInvoice & "', RekapBy = '" & userInput & "', RekapDate = GETDATE() WHERE TransPoliIDBayar IN (" & idDetailTransaksiPoliAkhir & ")", 4)
                End If

                ' Update Flag Tabel TransaksiGigiBayar
                If idDetailTransaksiGigiAkhir <> "" Then
                    idDetailTransaksiGigiAkhir = Strings.Left(idDetailTransaksiGigiAkhir, idDetailTransaksiGigiAkhir.Length - 1)
                    WriteSQL("UPDATE TransaksiGigiBayar SET NoInvoicePembayaran = '" & nomorInvoice & "', RekapBy = '" & userInput & "', RekapDate = GETDATE() WHERE TransGigiIDBayar IN (" & idDetailTransaksiGigiAkhir & ")", 4)
                End If

                ' Update Flag Tabel acctranstagihandetail (Online)
                If nomorTransaksiPoli.Length > 0 Then
                    nomorTransaksiPoli = Strings.Left(nomorTransaksiPoli, nomorTransaksiPoli.Length - 1)
                    WriteThemysql("UPDATE acctranstagihandetail SET lockeddate = NOW(), lockedby='" & userInput & "', RekapID='" & rekapID & "' WHERE no_transaksi IN (" & nomorTransaksiPoli & ") AND loc = '" & kodeLokasiKlinik & "' AND kartu = '" & splitPerusahaan(0).ToString.Trim.ToUpper() & "' AND mesin = '" & splitPerusahaan(1).ToString.Trim.ToUpper() & "'", DB_Keuangan)
                ElseIf nomorTransaksiGigi.Length > 0 Then
                    nomorTransaksiGigi = Strings.Left(nomorTransaksiGigi, nomorTransaksiGigi.Length - 1)
                    WriteThemysql("UPDATE acctranstagihandetail SET lockeddate = NOW(), lockedby='" & userInput & "', RekapID='" & rekapID & "' WHERE no_transaksi IN (" & nomorTransaksiGigi & ") AND loc = '" & kodeLokasiKlinik & "' AND kartu = '" & splitPerusahaan(0).ToString.Trim.ToUpper() & "' AND mesin = '" & splitPerusahaan(1).ToString.Trim.ToUpper() & "'", DB_Keuangan)
                End If

                ' Insert Tabel RekapTagihan (Lokal)
                WriteSQL("INSERT INTO RekapTagihan (RekapID, company, tgltagihan, periode, duedate, totaltagihan, keterangan, createdate, createby, notagihancompany, jenistransaksi, JenisPoli, CoaBank, NamaBank, NamaRekeningBank, NomorRekeningBank, CabangRekeningBank, JenisBank) " & _
                         "VALUES('" & rekapID & "', '" & TextBoxNamaPerusahaanRekapTagihan.Text & "', GETDATE(), '0', '" & tglJatuhTempo & "', '" & CDbl(totalTagihan) & "', '-', GETDATE() , '" & userInput & "', '" & nomorInvoice & "', " & sqlJenisTransaksi & ", " & sqlJenisPoli & ", '" & rowBankTransfer("CoaBank") & "', '" & rowBankTransfer("NamaBank") & "', '" & rowBankTransfer("NamaRekening") & "', '" & rowBankTransfer("NomorRekening") & "', '" & rowBankTransfer("CabangRekening") & "', '" & rowBankTransfer("LabelBank") & "')", 4)

                ' Create Jurnal
                If autoJurnal.Trim = "Yes" Then
                    SendingJurnal(nomorInvoice)
                End If

                ' Cetak Invoice
                CetakInvoiceTagihan(nomorInvoice, True)

                SetClearRekapTagihan()
                MsgBox("Berhasil Menyimpan Data dengan No. Invoice : " & nomorInvoice & "", MsgBoxStyle.Information, "Success!")
            Else
                MessageBox.Show("Tidak ada data yang dipilih.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Tidak ada data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub CetakInvoiceTagihan(ByVal nomorInvoice As String, ByVal simpanLaporanPDF As Boolean)
        Dim Ttempat As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='Kota'")
        Dim Temail As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='InvoiceEmail'")
        Dim Tnamaklinik As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='InvoiceTempat_Klinik'")

        Dim queryBuilder As New StringBuilder()

        ' WITH clause
        queryBuilder.AppendLine("WITH BaseData AS (")
        queryBuilder.AppendLine("    SELECT c.NoJenisBayar AS NamaPerusahaan,")
        queryBuilder.AppendLine("           a.NoUrut AS NoTransaksi,")
        queryBuilder.AppendLine("           CONVERT(DATE, a.TglPoli) AS TglTransaksi,")
        queryBuilder.AppendLine("           c.JumlahBayar - c.Kembali AS Tagihan")
        queryBuilder.AppendLine("    FROM TransaksiPoli a")
        queryBuilder.AppendLine("         LEFT JOIN TransaksiPoliBayar c ON a.TransPoliID = c.TransPoliID")
        queryBuilder.AppendLine("    WHERE c.NoInvoicePembayaran = '" & nomorInvoice & "'")
        queryBuilder.AppendLine("          AND a.deleted <> 1")
        queryBuilder.AppendLine("          AND c.JenisBayar = 'TAGIHAN'")
        queryBuilder.AppendLine("    UNION ALL")
        queryBuilder.AppendLine("    SELECT c.NoJenisBayar,")
        queryBuilder.AppendLine("           a.NoUrut AS NoTransaksi,")
        queryBuilder.AppendLine("           CONVERT(DATE, a.TglPoli) AS TglTransaksi,")
        queryBuilder.AppendLine("           c.JumlahBayar - c.Kembali AS Tagihan")
        queryBuilder.AppendLine("    FROM TransaksiPoli a")
        queryBuilder.AppendLine("         LEFT JOIN TransaksiPoliBayarAwal c ON a.TransPoliID = c.TransPoliID")
        queryBuilder.AppendLine("    WHERE c.NoInvoicePembayaran = '" & nomorInvoice & "'")
        queryBuilder.AppendLine("          AND a.deleted <> 1")
        queryBuilder.AppendLine("          AND c.JenisBayar = 'TAGIHAN'")
        queryBuilder.AppendLine("    UNION ALL")
        queryBuilder.AppendLine("    SELECT c.NoJenisBayar AS NamaPerusahaan,")
        queryBuilder.AppendLine("           a.NoUrut AS NoTransaksi,")
        queryBuilder.AppendLine("           CONVERT(DATE, a.TglGigi) AS TglTransaksi,")
        queryBuilder.AppendLine("           c.JumlahBayar - c.Kembali AS Tagihan")
        queryBuilder.AppendLine("    FROM TransaksiGigi a")
        queryBuilder.AppendLine("         LEFT JOIN TransaksiGigiBayar c ON a.TransGigiID = c.TransGigiID")
        queryBuilder.AppendLine("    WHERE c.NoInvoicePembayaran = '" & nomorInvoice & "'")
        queryBuilder.AppendLine("          AND a.deleted <> 1")
        queryBuilder.AppendLine("          AND c.JenisBayar = 'TAGIHAN'")
        queryBuilder.AppendLine("    UNION ALL")
        queryBuilder.AppendLine("    SELECT c.NoJenisBayar,")
        queryBuilder.AppendLine("           a.NoUrut AS NoTransaksi,")
        queryBuilder.AppendLine("           CONVERT(DATE, a.TglGigi) AS TglTransaksi,")
        queryBuilder.AppendLine("           c.JumlahBayar - c.Kembali AS Tagihan")
        queryBuilder.AppendLine("    FROM TransaksiGigi a")
        queryBuilder.AppendLine("         LEFT JOIN TransaksiGigiBayarAwal c ON a.TransGigiID = c.TransGigiID")
        queryBuilder.AppendLine("    WHERE c.NoInvoicePembayaran = '" & nomorInvoice & "'")
        queryBuilder.AppendLine("          AND a.deleted <> 1")
        queryBuilder.AppendLine("          AND c.JenisBayar = 'TAGIHAN'")
        queryBuilder.AppendLine(")")

        ' Main SELECT statement
        queryBuilder.AppendLine("SELECT ROW_NUMBER() OVER (ORDER BY NamaPerusahaan, TglTransaksi) AS NomorUrut,")
        queryBuilder.AppendLine("       NamaPerusahaan,")
        queryBuilder.AppendLine("       TglTransaksi,")
        queryBuilder.AppendLine("       COUNT(DISTINCT NoTransaksi) AS JumlahPasien,")
        queryBuilder.AppendLine("       'Sesuai Rekapan' AS Keterangan,")
        queryBuilder.AppendLine("       SUM(Tagihan) AS JumlahTagihan")
        queryBuilder.AppendLine("FROM BaseData")
        queryBuilder.AppendLine("GROUP BY NamaPerusahaan, TglTransaksi")
        queryBuilder.AppendLine("ORDER BY NamaPerusahaan, TglTransaksi ASC;")

        Dim tblDetailTransaksi As DataTable = ReadSQL(queryBuilder.ToString())

        Dim tblHeaderLaporan As DataTable = New DataTable
        tblHeaderLaporan = CreateTableInvoice()
        tblHeaderLaporan.Rows.Clear()

        Dim tblDataHeader As DataTable = ReadSQL("SELECT * FROM RekapTagihan WHERE notagihancompany = '" & nomorInvoice & "'")
        For Each rowHeader As DataRow In tblDataHeader.Rows
            Dim newRowHeader As DataRow = tblHeaderLaporan.NewRow
            Dim splitPerusahaan() As String = rowHeader("company").ToString().Split("-")

            newRowHeader("TglInvoice") = Format(rowHeader("tgltagihan"), "dd") & " " & BulanIndonesia(Format(rowHeader("tgltagihan"), "MM")) & " " & Format(rowHeader("tgltagihan"), "yyyy")
            newRowHeader("TglJatuhTempo") = Format(rowHeader("duedate"), "dd") & " " & BulanIndonesia(Format(rowHeader("duedate"), "MM")) & " " & Format(rowHeader("duedate"), "yyyy")
            newRowHeader("NomorInvoice") = rowHeader("notagihancompany").ToString()
            newRowHeader("NamaPerusahaan") = splitPerusahaan(0).ToString.Trim.ToUpper()
            newRowHeader("TglTTD") = Ttempat & ", " & Format(DateAndTime.Now, "dd") & " " & BulanIndonesia(Format(DateAndTime.Now, "MM")) & " " & Format(DateAndTime.Now, "yyyy")
            newRowHeader("KeteranganNominal") = "Terbilang : " & Terbilang(rowHeader("totaltagihan").ToString()) & " Rupiah"

            ' Get Nama User TTD
            Dim userTTD As String = ReadSQLNIK("SELECT UserNama FROM Users WHERE UserID = '" & rowHeader("createby").ToString() & "'")

            newRowHeader("UserTTD") = userTTD
            newRowHeader("KeteranganEmail") = "3. Bukti Pembayaran dapat dikirim melalui email " & Temail

            ' Set Data Bank
            newRowHeader("NamaRekeningBank") = rowHeader("NamaRekeningBank").ToString()
            newRowHeader("NomorRekeningBank") = rowHeader("NomorRekeningBank").ToString()
            If rowHeader("CabangRekeningBank").ToString() <> "-" Then
                newRowHeader("NamaBank") = rowHeader("JenisBank").ToString() & " - " & "CABANG " & rowHeader("CabangRekeningBank").ToString()
            Else
                newRowHeader("NamaBank") = rowHeader("JenisBank").ToString()
            End If

            tblHeaderLaporan.Rows.Add(newRowHeader)
        Next

        tblHeaderLaporan.TableName = "HeaderLaporan"
        tblDetailTransaksi.TableName = "DetailTransaksi"

        Dim dataSet As New DataSet()
        dataSet.Tables.Add(tblHeaderLaporan.Copy())
        dataSet.Tables.Add(tblDetailTransaksi.Copy())

        Report = New XtraReport
        Report = XtraReport.FromFile(Application.StartupPath + "\reports\Klinik\Laporan\LaporanRekapInvoiceKlinik.repx", True)

        Report.DataSource = dataSet
        Report.Bands.Item(BandKind.ReportHeader).Controls("xrLabelJudulLaporan").Text = "INVOICE"
        Report.Bands.Item(BandKind.ReportHeader).Controls("xrLabelKalimatPembuka").Text = "Dengan hormat," & vbCrLf & _
                                                                                          "Kami mengucapkan terimakasih atas kepercayaan yang telah diberikan kepada " & Tnamaklinik & ". Bersama surat ini kami menginformasikan tagihan Pemeriksaan Klinik dengan rincian sebagai berikut:"
        Report.Bands.Item(BandKind.PageFooter).Controls("xrLabelInfoCetak").Text = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:ss") & " By " & userInput

        'Report.RunDesigner()
        Report.ShowPreview()
        'Report.Print()

        If simpanLaporanPDF = True Then
            ' SavePDF
            Dim NameFile As String = nomorInvoice.Replace("/", "-")
            Dim PathFolder As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='PathAutoSaveInvoice'")
            PathFolder = PathFolder & "INVOICE_POLI" & "\" & Format(DateAndTime.Now, "yyyy") & "\" & Format(DateAndTime.Now, "MMMM") & "\" & Format(DateAndTime.Now, "dd") & ""

            If (Not System.IO.Directory.Exists(PathFolder)) Then
                System.IO.Directory.CreateDirectory(PathFolder)
            End If

            Dim filepath As String = PathFolder & "\" & NameFile & ".pdf"
            If File.Exists(filepath) Then
                My.Computer.FileSystem.DeleteFile(filepath)
            End If
            Report.CreatePdfDocument(filepath)

            ' CreateBase64
            'Dim Base64Inv As String = ""
            'Base64Inv = Convert.ToBase64String(System.IO.File.ReadAllBytes(filepath))

            ' Update Base64
            'WriteThemysql("UPDATE acctransrekaptagihan a SET a.FileBase64 = '" & Base64Inv & "' WHERE a.notagihancompany = '" & NoTagihan & "'", DB_Keuangan)

            MsgBox("Invoice Otomatis Tersimpan di drive : " & PathFolder & "", MsgBoxStyle.Information, "Success!")
        End If
    End Sub

    Private Sub ButtonFindPerusahaanRekapTagihan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFindPerusahaanRekapTagihan.Click
        Find.Show()
        Find.Query("SELECT NoCompany AS 'ID', CompanyCode AS 'Kode Perusahaan', CompanyNama AS 'Keterangan' FROM mastercompany WHERE GETDATE() BETWEEN StartDate AND EndDate", " ORDER BY NoCompany ASC", "FindPerusahaanReportPendapatanKlinik_RekapTagihan", 2)
    End Sub

    Private Sub SendingJurnal(ByVal nomorInvoice As String)
        ' Set Data Rekap Tagihan
        Dim tblInvoice As DataTable = ReadSQL("SELECT * FROM RekapTagihan WHERE notagihancompany = '" & nomorInvoice & "'")
        Dim rowInvoice As DataRow = tblInvoice.Rows(0)

        ' Set Variabel Jurnal
        Dim idLokasiJurnal As String = ""
        Dim keteranganLokasiJurnal As String = ""
        Dim coaPiutang As String = ""
        Dim coaPiutangPending As String = ""

        ' Set COA Piutang & Piutang Pending
        If IsDBNull(rowInvoice("JenisPoli")) = False Then ' Jika Kolom Jenis Poli Tidak Kosong (Jurnal Berdasarkan Jenis Poli)
            Dim tblMasterJurnal As DataTable = ReadThemysql("SELECT * FROM MasterLokasiJurnal a WHERE a.KodeLokasi = '" & kodeLokasiKlinik & "' AND a.KeteranganPoli = '" & rowInvoice("JenisPoli") & "' LIMIT 1", DB_Omset)
            Dim rowDataJurnal As DataRow = tblMasterJurnal.Rows(0)
            idLokasiJurnal = rowDataJurnal("KodeLokasiJurnal")
            keteranganLokasiJurnal = rowDataJurnal("KeteranganLokasi") & " (" & rowDataJurnal("KeteranganPoli") & ") "
            coaPiutang = rowDataJurnal("KodeCoaPiutang")
            coaPiutangPending = rowDataJurnal("KodeCoaPiutangPending")
        Else ' Jika Kolom Jenis Poli Kosong (Jurnal Berdasarkan Jenis Transaksi)
            Dim tblMasterJurnal As DataTable = ReadThemysql("SELECT * FROM MasterLokasiJurnal a WHERE a.KodeLokasi = '" & kodeLokasiKlinik & "' AND a.JenisTransaksi = '" & rowInvoice("jenistransaksi") & "' LIMIT 1", DB_Omset)
            Dim rowDataJurnal As DataRow = tblMasterJurnal.Rows(0)
            idLokasiJurnal = rowDataJurnal("KodeLokasiJurnal")
            keteranganLokasiJurnal = rowDataJurnal("KeteranganLokasi") & " (" & rowDataJurnal("JenisTransaksi") & ") "
            If rowInvoice("jenistransaksi").ToString() = "POLI" Then
                coaPiutang = ReadThemysqlNIK("SELECT KodeAkun FROM MasterCoaJurnal WHERE NamaAkun = 'Piutang Poli Umum'", DB_Omset)
                coaPiutangPending = ReadThemysqlNIK("SELECT KodeAkun FROM MasterCoaJurnal WHERE NamaAkun = 'Piutang Pending Poli Umum'", DB_Omset)
            ElseIf rowInvoice("jenistransaksi").ToString() = "GIGI" Then
                coaPiutang = ReadThemysqlNIK("SELECT KodeAkun FROM MasterCoaJurnal WHERE NamaAkun = 'Piutang Poli Gigi'", DB_Omset)
                coaPiutangPending = ReadThemysqlNIK("SELECT KodeAkun FROM MasterCoaJurnal WHERE NamaAkun = 'Piutang Pending Poli Gigi'", DB_Omset)
            End If
        End If

        ' Set Flag / Refference
        Dim refferenceID As String = GetUUID()

        ' Set Nama Perusahaan
        Dim splitPerusahaan() As String = rowInvoice("company").ToString().Split("-")

        ' Set Keterangan Jurnal
        Dim keteranganJurnal As String = "TERIMA - TAGIHAN " & splitPerusahaan(0).ToString.Trim.ToUpper() & " " & keteranganLokasiJurnal & " " & Format(rowInvoice("tgltagihan"), "dd/MM/yyyy") & " (NO. INVOICE : " & nomorInvoice & ")"

        ' Kirim Jurnal Create Tagihan
        WriteThemysql("SELECT F_MakeUMH('" & refferenceID & "', 'out', '', '" & Format(rowInvoice("tgltagihan"), "yyyy-MM-dd") & "', '" & CoaPiutangPending & "', '" & CoaPiutang & "', 'IDR', 1, " & CDbl(rowInvoice("totaltagihan")) & ", '" & keteranganJurnal.ToUpper() & "', '1', 1, '', '" & keteranganJurnal.ToUpper() & "', '', '', '" & idLokasiJurnal & "', 4, " & CDbl(rowInvoice("totaltagihan")) & ", 'K')", DB_Jurnal)

        ' Update Flag di Tabel Bayar
        WriteSQL("UPDATE TransaksiPoliBayar SET FlagJurnalCreateTagihan = '" & refferenceID & "' WHERE NoInvoicePembayaran = '" & nomorInvoice & "'", 4)
        WriteSQL("UPDATE TransaksiPoliBayarAwal SET FlagJurnalCreateTagihan = '" & refferenceID & "' WHERE NoInvoicePembayaran = '" & nomorInvoice & "'", 4)
        WriteSQL("UPDATE TransaksiGigiBayar SET FlagJurnalCreateTagihan = '" & refferenceID & "' WHERE NoInvoicePembayaran = '" & nomorInvoice & "'", 4)
        WriteSQL("UPDATE TransaksiGigiBayarAwal SET FlagJurnalCreateTagihan = '" & refferenceID & "' WHERE NoInvoicePembayaran = '" & nomorInvoice & "'", 4)

        ' Update Tabel Rekap Tagihan (Online)
        WriteThemysql("UPDATE acctransrekaptagihan SET FlagJurnalCreateTagihan = '" & refferenceID & "' WHERE notagihancompany = '" & nomorInvoice & "'", DB_Keuangan)

        ' Insert Log Invoice Tagihan
        WriteSQL("INSERT INTO LogJurnalKeuangan (JurnalFlag, JurnalDate, JurnalBy, Status, JenisPoli, JenisTransaksi) VALUES ('" & refferenceID & "', GETDATE(), '" & userInput & "', '" & keteranganJurnal & "', '" & rowInvoice("JenisPoli").ToString & "', '" & rowInvoice("jenistransaksi").ToString() & "')", 4)
    End Sub

    Private Sub ButtonCariDataInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCariDataInvoice.Click
        ' Cek Koneksi
        If CekKoneksi("SHOW TABLES FROM " & DB_Keuangan.Tdb & "", DB_Keuangan) = False Then
            MsgBox("Proses gagal, cek koneksi internet atau server Database " & DB_Keuangan.Tdb & ".", MsgBoxStyle.Exclamation, "Warning!")
            Exit Sub
        End If

        Dim kodeInvoice As String = ReadSQLNIK("SELECT StrValue  FROM MsConfig WHERE ConfigName = 'KodeInvoicePoli'")
        Dim queryBuilder As New StringBuilder()

        queryBuilder.AppendLine("SELECT RekapID, company, notagihancompany AS 'No Tagihan',")
        queryBuilder.AppendLine("       tgltagihan AS 'Tgl Tagihan', totaltagihan,")
        queryBuilder.AppendLine("       duedate AS 'Tgl Jatuh Tempo',")
        queryBuilder.AppendLine("       CASE WHEN lunasid > 0 THEN 'LUNAS' ELSE '-' END AS 'Status'")
        queryBuilder.AppendLine("FROM acctransrekaptagihan")
        queryBuilder.AppendLine("WHERE notagihancompany LIKE '%" & kodeInvoice & "%'")
        queryBuilder.AppendLine("      AND cabang = '" & kodeLokasiKlinik & "'")
        queryBuilder.AppendLine("      AND (DATE(tgltagihan) BETWEEN '" & Format(TglAwalTransaksiRekapInvoice.Value, "yyyy-MM-dd") & "' AND '" & Format(TglAkhirTransaksiRekapInvoice.Value, "yyyy-MM-dd") & "')")
        queryBuilder.AppendLine("      AND deleted IS NULL")

        Dim queryString As String = queryBuilder.ToString()

        ' Set Nama Perusahaan
        If TextBoxNamaPerusahaanRekapInvoice.Text <> "" Then
            queryString = queryString & " AND (company = '" & TextBoxNamaPerusahaanRekapInvoice.Text & "')"
        End If

        Find.Show()
        Find.QueryTheMysql(queryString, " ORDER BY tgltagihan, RekapID ASC", "FindInvoiceKlinik_ReportPendapatanKlinik", 2, Find_Keuangan)
    End Sub

    Public Sub LoadInvoiceTagihan(ByRef NomorInvoice As String)
        ' Set Data Header
        SetHeaderRekapInvoice(NomorInvoice)

        Dim tblPoliUmum As DataTable = GetDataRekapTagihanPoliUmum(NomorInvoice)
        Dim tblPoliGigi As DataTable = GetDataRekapTagihanPoliGigi(NomorInvoice)

        ' Buat tabel gabungan dengan struktur yang sama
        Dim tblRekapTagihan As DataTable = tblPoliUmum.Clone()

        ' Gabungkan data dari kedua tabel
        tblRekapTagihan.Merge(tblPoliUmum)
        tblRekapTagihan.Merge(tblPoliGigi)

        If tblRekapTagihan.Rows.Count > 0 Then
            Dim rowTable As DataTable = CreateTableLaporanPendapatan()
            rowTable.Rows.Clear()

            For Each rowData As DataRow In tblRekapTagihan.Rows
                ' Set Keterangan Jenis Bayar
                Dim keteranganJenisBayar As String = ""
                If rowData("JenisBayar").ToString = "DEBET" Or rowData("JenisBayar").ToString = "CARD" Then
                    keteranganJenisBayar = rowData("JenisMesin")
                ElseIf rowData("JenisBayar").ToString = "TAGIHAN" Then
                    Dim Tsplit() As String = rowData("CompanyTagihan").Split("-")
                    keteranganJenisBayar = Tsplit(0).ToString.Trim.ToUpper
                End If

                ' Set Keterangan Detail Pembayaran
                Dim keteranganDetailPembayaran As String = ""
                If rowData("JenisBayar").ToString = "DEBET" Or rowData("JenisBayar").ToString = "CARD" Or rowData("JenisBayar").ToString = "TAGIHAN" Then
                    keteranganDetailPembayaran = rowData("JenisBayar").ToString & " " & keteranganJenisBayar
                Else
                    keteranganDetailPembayaran = rowData("JenisBayar").ToString
                End If

                Dim newRow As DataRow = rowTable.NewRow
                newRow("No") = rowData("NomorUrutTransaksi")
                newRow("No Transaksi") = rowData("No Transaksi")
                newRow("Tgl Transaksi") = rowData("Tgl Transaksi")
                newRow("Nama") = rowData("Nama").ToString.ToUpper
                newRow("Tgl Lahir") = rowData("Tgl Lahir")
                newRow("pemeriksaan") = rowData("DataListTindakan")
                newRow("Tagihan") = rowData("TotalBayar")
                newRow("JenisTransaksi") = rowData("JenisTransaksi")
                newRow("Jenis Poli") = rowData("JenisPoli")
                newRow("Jenis Bayar") = rowData("JenisBayar")
                newRow("NoJenisBayar") = keteranganJenisBayar
                newRow("Detail Pembayaran") = keteranganDetailPembayaran
                rowTable.Rows.Add(newRow)
            Next

            GridControlRekapInvoice.DataSource = rowTable
        Else
            MessageBox.Show("Tidak Ada Data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub SetHeaderRekapInvoice(ByRef NomorInvoice As String)
        Dim tblDataHeader As DataTable = ReadSQL("SELECT * FROM RekapTagihan WHERE notagihancompany = '" & NomorInvoice & "'")

        If tblDataHeader.Rows.Count > 0 Then
            Dim rowHeader As DataRow = tblDataHeader.Rows(0)

            Dim splitPerusahaan() As String = rowHeader("company").ToString().Split("-")

            TextBoxNamaPerusahaanInvoice.Text = splitPerusahaan(0).ToString.Trim.ToUpper()
            TextBoxNomorInvoice.Text = rowHeader("notagihancompany").ToString()
            TextBoxBankInvoice.Text = rowHeader("NamaBank").ToString() & " – " & rowHeader("NomorRekeningBank").ToString() & " – a.n. " & rowHeader("NamaRekeningBank").ToString()
            TextBoxNominalInvoice.Text = "" & Format(Val(rowHeader("totaltagihan")), "Rp, ###,###.#0") & ""
            TglInvoice.Value = rowHeader("tgltagihan")
            TglJatuhTempoInvoice.Value = rowHeader("duedate")
        End If
    End Sub

    Function GetDataRekapTagihanPoliUmum(ByRef NomorInvoice As String) As DataTable
        ' Set Tabel Result
        Dim tblResult As New DataTable

        Dim queryBuilder As New StringBuilder()

        queryBuilder.AppendLine("DECLARE @NoInvoicePembayaran NVARCHAR(50) = '" & NomorInvoice & "'") ' Menggunakan parameter
        queryBuilder.AppendLine("SELECT ROW_NUMBER() OVER (PARTITION BY tblDetail.JenisPoli, tblBayar.JenisBayar, tblBayar.CompanyTagihan, tblBayar.mesin ")
        queryBuilder.AppendLine("ORDER BY tblPoli.TglPoli, tblPoli.NoUrut) AS NomorUrutTransaksi, ")
        queryBuilder.AppendLine("tblBayar.TransPoliIDBayar AS 'ID', tblPoli.NoUrut AS 'No Transaksi', ")
        queryBuilder.AppendLine("CONVERT(DATE, tblPoli.TglPoli) AS 'Tgl Transaksi', tblDetail.JenisPoli, tblBayar.DataListTindakan, ")
        queryBuilder.AppendLine("tblPasien.Nama, CONVERT(DATE, tblPasien.TglLahir) AS 'Tgl Lahir', ")
        queryBuilder.AppendLine("tblPasien.NoRekamMedis, tblBayar.JenisBayar, tblBayar.CompanyTagihan, ")
        queryBuilder.AppendLine("tblBayar.kartu AS 'JenisKartu', tblBayar.mesin AS 'JenisMesin', ")
        queryBuilder.AppendLine("tblDetail.JenisTransaksi, tblBayar.JumlahBayar - tblBayar.Kembali AS TotalBayar, ")
        queryBuilder.AppendLine("tblPoli.RekapID, tblBayar.NoInvoicePembayaran, tblBayar.JenisKasir ")
        queryBuilder.AppendLine("FROM ( ")
        queryBuilder.AppendLine("    SELECT tb.TransPoliIDBayar, tb.TransPoliID, ")
        queryBuilder.AppendLine("    STUFF((SELECT ', ' + ISNULL(tblTindakan.NamaTindakan, '') ")
        queryBuilder.AppendLine("           FROM TransaksiPoliDetail tblTindakan ")
        queryBuilder.AppendLine("           WHERE tblTindakan.Awal = '0' AND tblTindakan.TransPoliID = tb.TransPoliID ")
        queryBuilder.AppendLine("           FOR XML PATH (''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS DataListTindakan, ")
        queryBuilder.AppendLine("    tb.JenisBayar, CASE WHEN tb.JenisBayar = 'TAGIHAN' THEN tb.NoJenisBayar ELSE '' END AS 'CompanyTagihan', ")
        queryBuilder.AppendLine("    tb.JumlahBayar, tb.Kembali, tb.kartu, tb.mesin, tb.NoInvoicePembayaran, 'Transaksi Tindakan' AS JenisKasir ")
        queryBuilder.AppendLine("    FROM TransaksiPoliBayar tb ")
        queryBuilder.AppendLine("    WHERE tb.JumlahBayar > 0 ")
        queryBuilder.AppendLine("    AND tb.NoInvoicePembayaran = @NoInvoicePembayaran ")
        queryBuilder.AppendLine("    UNION ALL ")
        queryBuilder.AppendLine("    SELECT tba.TransPoliIDBayar, tba.TransPoliID, ")
        queryBuilder.AppendLine("    STUFF((SELECT ', ' + ISNULL(tblTindakan.NamaTindakan, '') ")
        queryBuilder.AppendLine("           FROM TransaksiPoliDetail tblTindakan ")
        queryBuilder.AppendLine("           WHERE tblTindakan.Awal = '1' AND tblTindakan.TransPoliID = tba.TransPoliID ")
        queryBuilder.AppendLine("           FOR XML PATH (''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS DataListTindakan, ")
        queryBuilder.AppendLine("    tba.JenisBayar, CASE WHEN tba.JenisBayar = 'TAGIHAN' THEN tba.NoJenisBayar ELSE '' END AS 'CompanyTagihan', ")
        queryBuilder.AppendLine("    tba.JumlahBayar, tba.Kembali, tba.kartu, tba.mesin, tba.NoInvoicePembayaran, 'Transaksi Awal' AS JenisKasir ")
        queryBuilder.AppendLine("    FROM TransaksiPoliBayarAwal tba ")
        queryBuilder.AppendLine("    WHERE tba.JumlahBayar > 0 ")
        queryBuilder.AppendLine("    AND tba.NoInvoicePembayaran = @NoInvoicePembayaran ")
        queryBuilder.AppendLine(") AS tblBayar ")
        queryBuilder.AppendLine("LEFT JOIN TransaksiPoli tblPoli ON tblBayar.TransPoliID = tblPoli.TransPoliID ")
        queryBuilder.AppendLine("LEFT JOIN TransaksiDetail tblDetail ON tblPoli.NoUrut = tblDetail.NoUrut ")
        queryBuilder.AppendLine("LEFT JOIN MasterPasien tblPasien ON tblPoli.IDInternet = tblPasien.NoRekamMedis ")
        queryBuilder.AppendLine("WHERE tblDetail.DeletedDate IS NULL ")
        queryBuilder.AppendLine("ORDER BY tblBayar.JenisBayar, tblDetail.JenisPoli;")

        tblResult = ReadSQL(queryBuilder.ToString())

        Return tblResult
    End Function

    Function GetDataRekapTagihanPoliGigi(ByRef NomorInvoice As String) As DataTable
        ' Set Tabel Result
        Dim tblResult As New DataTable

        Dim queryBuilder As New StringBuilder()

        queryBuilder.AppendLine("DECLARE @NoInvoicePembayaran NVARCHAR(50) = '" & NomorInvoice & "'") ' Menggunakan parameter
        queryBuilder.AppendLine("SELECT ROW_NUMBER() OVER (PARTITION BY tblDetail.JenisPoli, tblBayar.JenisBayar, tblBayar.CompanyTagihan, tblBayar.mesin ")
        queryBuilder.AppendLine("ORDER BY tblGigi.TglGigi, tblGigi.NoUrut) AS NomorUrutTransaksi, ")
        queryBuilder.AppendLine("tblBayar.TransGigiIDBayar AS 'ID', tblGigi.NoUrut AS 'No Transaksi', ")
        queryBuilder.AppendLine("CONVERT(DATE, tblGigi.TglGigi) AS 'Tgl Transaksi', tblDetail.JenisPoli, tblBayar.DataListTindakan, ")
        queryBuilder.AppendLine("tblPasien.Nama, CONVERT(DATE, tblPasien.TglLahir) AS 'Tgl Lahir', ")
        queryBuilder.AppendLine("tblPasien.NoRekamMedis, tblBayar.JenisBayar, tblBayar.CompanyTagihan, ")
        queryBuilder.AppendLine("tblBayar.kartu AS 'JenisKartu', tblBayar.mesin AS 'JenisMesin', ")
        queryBuilder.AppendLine("tblDetail.JenisTransaksi, tblBayar.JumlahBayar - tblBayar.Kembali AS TotalBayar, ")
        queryBuilder.AppendLine("tblGigi.RekapID, tblBayar.NoInvoicePembayaran, tblBayar.JenisKasir ")
        queryBuilder.AppendLine("FROM ( ")
        queryBuilder.AppendLine("    SELECT tb.TransGigiIDBayar, tb.TransGigiID, ")
        queryBuilder.AppendLine("    STUFF((SELECT ', ' + ISNULL(tblTindakan.NamaTindakan, '') ")
        queryBuilder.AppendLine("           FROM TransaksiGigiDetail tblTindakan ")
        queryBuilder.AppendLine("           WHERE tblTindakan.Awal = '0' AND tblTindakan.TransGigiID = tb.TransGigiID ")
        queryBuilder.AppendLine("           FOR XML PATH (''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS DataListTindakan, ")
        queryBuilder.AppendLine("    tb.JenisBayar, CASE WHEN tb.JenisBayar = 'TAGIHAN' THEN tb.NoJenisBayar ELSE '' END AS 'CompanyTagihan', ")
        queryBuilder.AppendLine("    tb.JumlahBayar, tb.Kembali, tb.kartu, tb.mesin, tb.NoInvoicePembayaran, 'Transaksi Tindakan' AS JenisKasir ")
        queryBuilder.AppendLine("    FROM TransaksiGigiBayar tb ")
        queryBuilder.AppendLine("    WHERE tb.JumlahBayar > 0 ")
        queryBuilder.AppendLine("    AND tb.NoInvoicePembayaran = @NoInvoicePembayaran ")
        queryBuilder.AppendLine("    UNION ALL ")
        queryBuilder.AppendLine("    SELECT tba.TransGigiIDBayar, tba.TransGigiID, ")
        queryBuilder.AppendLine("    STUFF((SELECT ', ' + ISNULL(tblTindakan.NamaTindakan, '') ")
        queryBuilder.AppendLine("           FROM TransaksiGigiDetail tblTindakan ")
        queryBuilder.AppendLine("           WHERE tblTindakan.Awal = '1' AND tblTindakan.TransGigiID = tba.TransGigiID ")
        queryBuilder.AppendLine("           FOR XML PATH (''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS DataListTindakan, ")
        queryBuilder.AppendLine("    tba.JenisBayar, CASE WHEN tba.JenisBayar = 'TAGIHAN' THEN tba.NoJenisBayar ELSE '' END AS 'CompanyTagihan', ")
        queryBuilder.AppendLine("    tba.JumlahBayar, tba.Kembali, tba.kartu, tba.mesin, tba.NoInvoicePembayaran, 'Transaksi Awal' AS JenisKasir ")
        queryBuilder.AppendLine("    FROM TransaksiGigiBayarAwal tba ")
        queryBuilder.AppendLine("    WHERE tba.JumlahBayar > 0 ")
        queryBuilder.AppendLine("    AND tba.NoInvoicePembayaran = @NoInvoicePembayaran ")
        queryBuilder.AppendLine(") AS tblBayar ")
        queryBuilder.AppendLine("LEFT JOIN TransaksiGigi tblGigi ON tblBayar.TransGigiID = tblGigi.TransGigiID ")
        queryBuilder.AppendLine("LEFT JOIN TransaksiDetail tblDetail ON tblGigi.NoUrut = tblDetail.NoUrut ")
        queryBuilder.AppendLine("LEFT JOIN MasterPasien tblPasien ON tblGigi.IDInternet = tblPasien.NoRekamMedis ")
        queryBuilder.AppendLine("WHERE tblDetail.DeletedDate IS NULL ")
        queryBuilder.AppendLine("ORDER BY tblBayar.JenisBayar, tblDetail.JenisPoli;")

        tblResult = ReadSQL(queryBuilder.ToString())

        Return tblResult
    End Function

    Private Sub ButtonFindPerusahaanRekapInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFindPerusahaanRekapInvoice.Click
        Find.Show()
        Find.Query("SELECT NoCompany AS 'ID', CompanyCode AS 'Kode Perusahaan', CompanyNama AS 'Keterangan' FROM mastercompany WHERE GETDATE() BETWEEN StartDate AND EndDate", " ORDER BY NoCompany ASC", "FindPerusahaanReportPendapatanKlinik_RekapInvoice", 2)
    End Sub

    Private Sub LaporanRekapTagihanInvoice()
        ' Set Tanggal Transaksi
        Dim tglTransaksiAwal As Date = TglAwalTransaksiLaporanPendapatan.Value
        Dim tglTransaksiAkhir As Date = TglAkhirTransaksiLaporanPendapatan.Value
        Dim stringTglTransaksi As String

        If tglTransaksiAwal.Date = tglTransaksiAkhir.Date Then
            ' Jika tanggal awal dan akhir sama, hanya tampilkan satu tanggal
            stringTglTransaksi = Format(tglTransaksiAwal, "dd") & " " & BulanIndonesia(Format(tglTransaksiAwal, "MM")) & " " & Format(tglTransaksiAwal, "yyyy")
        Else
            ' Jika berbeda, tampilkan rentang tanggal
            Dim stringTglTransaksiAwal As String = Format(tglTransaksiAwal, "dd") & " " & BulanIndonesia(Format(tglTransaksiAwal, "MM")) & " " & Format(tglTransaksiAwal, "yyyy")
            Dim stringTglTransaksiAkhir As String = Format(tglTransaksiAkhir, "dd") & " " & BulanIndonesia(Format(tglTransaksiAkhir, "MM")) & " " & Format(tglTransaksiAkhir, "yyyy")
            stringTglTransaksi = stringTglTransaksiAwal & " - " & stringTglTransaksiAkhir
        End If

        Dim tblOmset As DataTable = GridControlLaporanPendapatan.DataSource
        tblOmset.AcceptChanges()

        Report = New XtraReport
        Report = XtraReport.FromFile(Application.StartupPath + "\reports\Klinik\Laporan\LaporanPendapatanKlinikVersi1.repx", True)

        Report.Bands.Item(BandKind.ReportHeader).Controls("xrLabelJudulLaporan").Text = "Laporan Pendapatan Klinik"
        Report.Bands.Item(BandKind.ReportHeader).Controls("xrLabelLokasiLaporan").Text = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NamaPoli'")
        Report.Bands.Item(BandKind.ReportHeader).Controls("xrLabelTanggalLaporan").Text = stringTglTransaksi
        Report.Bands.Item(BandKind.PageFooter).Controls("xrLabelInfoCetak").Text = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:ss") & " By " & userInput
        Report.DataSource = tblOmset

        'Report.RunDesigner()
        Report.ShowPreview()
        'Report.Print()
    End Sub

    Private Sub ViewRekapTagihan()
        Dim tblPoliUmum As DataTable = GetDataLaporanPendapatanPoliUmum()
        Dim tblPoliGigi As DataTable = GetDataLaporanPendapatanPoliGigi()

        ' Buat tabel gabungan dengan struktur yang sama
        Dim tblOmset As DataTable = tblPoliUmum.Clone()

        ' Gabungkan data dari kedua tabel
        tblOmset.Merge(tblPoliUmum)
        tblOmset.Merge(tblPoliGigi)

        If tblOmset.Rows.Count > 0 Then
            Dim rowTable As DataTable = CreateTableLaporanPendapatan()
            rowTable.Rows.Clear()

            For Each rowData As DataRow In tblOmset.Rows
                ' Set Keterangan Jenis Bayar
                Dim keteranganJenisBayar As String = ""
                If rowData("JenisBayar").ToString = "DEBET" Or rowData("JenisBayar").ToString = "CARD" Then
                    keteranganJenisBayar = rowData("JenisMesin")
                ElseIf rowData("JenisBayar").ToString = "TAGIHAN" Then
                    Dim Tsplit() As String = rowData("CompanyTagihan").Split("-")
                    keteranganJenisBayar = Tsplit(0).ToString.Trim.ToUpper
                End If

                ' Set Keterangan Detail Pembayaran
                Dim keteranganDetailPembayaran As String = ""
                If rowData("JenisBayar").ToString = "DEBET" Or rowData("JenisBayar").ToString = "CARD" Or rowData("JenisBayar").ToString = "TAGIHAN" Then
                    keteranganDetailPembayaran = rowData("JenisBayar").ToString & " " & keteranganJenisBayar
                Else
                    keteranganDetailPembayaran = rowData("JenisBayar").ToString
                End If

                Dim newRow As DataRow = rowTable.NewRow
                newRow("No") = rowData("NomorUrutTransaksi")
                newRow("No Transaksi") = rowData("No Transaksi")
                newRow("Tgl Transaksi") = rowData("Tgl Transaksi")
                newRow("Nama") = rowData("Nama").ToString.ToUpper
                newRow("Tgl Lahir") = rowData("Tgl Lahir")
                newRow("pemeriksaan") = rowData("DataListTindakan")
                newRow("Tagihan") = rowData("TotalBayar")
                newRow("JenisTransaksi") = rowData("JenisTransaksi")
                newRow("Jenis Poli") = rowData("JenisPoli")
                newRow("Jenis Bayar") = rowData("JenisBayar")
                newRow("NoJenisBayar") = keteranganJenisBayar
                newRow("Detail Pembayaran") = keteranganDetailPembayaran
                rowTable.Rows.Add(newRow)
            Next

            GridControlLaporanPendapatan.DataSource = rowTable

            ' Disable Control
            TglAwalTransaksiLaporanPendapatan.Enabled = False
            TglAkhirTransaksiLaporanPendapatan.Enabled = False
            ComboBoxPoliTujuanLaporanPendapatan.Enabled = False
            ButtonFindPerusahaanLaporanPendapatan.Enabled = False
            ButtonViewDataPendapatan.Enabled = False
            CheckBoxTagihan.Enabled = False
            CheckBoxTunai.Enabled = False
            CheckBoxCard.Enabled = False
            CheckBoxDebet.Enabled = False
            CheckBoxTransaksiNolRupiah.Enabled = False
        Else
            MessageBox.Show("Tidak Ada Data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub ButtonCetakRekapTagihan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCetakRekapTagihan.Click
        Dim tblRekapInvoice As DataTable = GridControlRekapInvoice.DataSource

        If tblRekapInvoice.Rows.Count > 0 Then
            CetakRekapTagihan()
        Else
            MessageBox.Show("Tidak Ada Data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub CetakRekapTagihan()
        Dim tblRekapInvoice As DataTable = GridControlRekapInvoice.DataSource
        tblRekapInvoice.AcceptChanges()

        Report = New XtraReport
        Report = XtraReport.FromFile(Application.StartupPath + "\reports\Klinik\Laporan\LaporanRekapTagihanKlinik.repx", True)

        Report.Bands.Item(BandKind.ReportHeader).Controls("xrLabelJudulLaporan").Text = "Rekap Tagihan Pemeriksaan Klinik"
        Report.Bands.Item(BandKind.ReportHeader).Controls("xrLabelLokasiLaporan").Text = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NamaPoli'")
        Report.Bands.Item(BandKind.ReportHeader).Controls("xrLabelNamaPerusahaan").Text = TextBoxNamaPerusahaanInvoice.Text
        Report.Bands.Item(BandKind.ReportHeader).Controls("xrLabelNomorInvoice").Text = TextBoxNomorInvoice.Text
        Report.Bands.Item(BandKind.PageFooter).Controls("xrLabelInfoCetak").Text = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:ss") & " By " & userInput
        Report.DataSource = tblRekapInvoice

        'Report.RunDesigner()
        Report.ShowPreview()
        'Report.Print()
    End Sub

    Private Sub ButtonCetakInvoiceTagihan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCetakInvoiceTagihan.Click
        If TextBoxNomorInvoice.Text <> "" Then
            CetakInvoiceTagihan(TextBoxNomorInvoice.Text, False)
        Else
            MessageBox.Show("Tidak Ada Data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub ButtonHapusTagihan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonHapusTagihan.Click
        If TextBoxNomorInvoice.Text = "" Then
            MessageBox.Show("Tidak Ada Data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If MsgBox("Apakah anda yakin ingin menghapus invoice " & TextBoxNomorInvoice.Text & " (" & TextBoxNamaPerusahaanInvoice.Text & ")?", MsgBoxStyle.YesNoCancel, "Question.") = MsgBoxResult.Yes Then
            If CekKoneksi("SHOW TABLES FROM " & DB_Keuangan.Tdb & "", DB_Keuangan) = False Then
                MsgBox("Proses gagal, cek koneksi internet atau server Database " & DB_Keuangan.Tdb & ".", MsgBoxStyle.Exclamation, "Warning!")
            Else
                If CheckThemysql("SELECT * FROM acctransrekaptagihan WHERE notagihancompany = '" & TextBoxNomorInvoice.Text & "' and lunasid > 0", DB_Keuangan) = True Then
                    MsgBox("Proses gagal, invoice " & TextBoxNomorInvoice.Text & " sudah terlunasi di keuangan.", MsgBoxStyle.Exclamation, "Warning!")
                Else
                    ' Update Tabel Rekap Online
                    WriteThemysql("UPDATE acctransrekaptagihan SET deleted=1, deletedby='" & userInput & "', deleteddate=NOW() WHERE notagihancompany = '" & TextBoxNomorInvoice.Text & "'", DB_Keuangan)
                    WriteThemysql("UPDATE acctranstagihandetail SET lockedby='', lockeddate='9998-12-31 00:00:00', rekapid=NULL WHERE rekapid IN (SELECT RekapID FROM acctransrekaptagihan WHERE notagihancompany = '" & TextBoxNomorInvoice.Text & "')", DB_Keuangan)

                    ' Update Tabel Rekap Lokal
                    WriteSQL("UPDATE RekapTagihan SET deleted=1, deletedby='" & userInput & "', deleteddate=GETDATE() WHERE notagihancompany = '" & TextBoxNomorInvoice.Text & "'", 4)

                    ' Update Tabel Pembayaran
                    WriteSQL("UPDATE TransaksiPoliBayarAwal SET NoInvoicePembayaran=NULL, RekapBy=NULL, RekapDate=NULL WHERE NoInvoicePembayaran='" & TextBoxNomorInvoice.Text & "'", 4)
                    WriteSQL("UPDATE TransaksiPoliBayar SET NoInvoicePembayaran=NULL, RekapBy=NULL, RekapDate=NULL WHERE NoInvoicePembayaran='" & TextBoxNomorInvoice.Text & "'", 4)
                    WriteSQL("UPDATE TransaksiGigiBayarAwal SET NoInvoicePembayaran=NULL, RekapBy=NULL, RekapDate=NULL WHERE NoInvoicePembayaran='" & TextBoxNomorInvoice.Text & "'", 4)
                    WriteSQL("UPDATE TransaksiGigiBayar SET NoInvoicePembayaran=NULL, RekapBy=NULL, RekapDate=NULL WHERE NoInvoicePembayaran='" & TextBoxNomorInvoice.Text & "'", 4)

                    ' Create Jurnal
                    Dim AutoJurnal As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='AutoJurnal'")
                    If AutoJurnal.Trim = "Yes" Then
                        SendingJurnalCancel(TextBoxNomorInvoice.Text)
                    End If

                    MsgBox("Invoice " & TextBoxNomorInvoice.Text & " berhasil dihapus dari program.", MsgBoxStyle.Information, "Success!")
                    SetClearRekapInvoice()
                End If
            End If
        End If
    End Sub

    Private Sub SetClearRekapInvoice()
        ' Clear Header
        TextBoxNamaPerusahaanRekapInvoice.ResetText()

        ' Clear Detail
        TextBoxNamaPerusahaanInvoice.ResetText()
        TextBoxNomorInvoice.ResetText()
        TextBoxBankInvoice.ResetText()
        TextBoxNominalInvoice.ResetText()

        GridControlRekapInvoice.DataSource = Nothing
    End Sub

    Private Sub ButtonClearDataRekapInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClearDataRekapInvoice.Click
        SetClearRekapInvoice()
    End Sub

    Private Sub SendingJurnalCancel(ByVal nomorInvoice As String)
        ' Set Data Rekap Tagihan
        Dim tblInvoice As DataTable = ReadSQL("SELECT * FROM RekapTagihan WHERE notagihancompany = '" & nomorInvoice & "'")
        Dim rowInvoice As DataRow = tblInvoice.Rows(0)

        ' Set Variabel Jurnal
        Dim idLokasiJurnal As String = ""
        Dim keteranganLokasiJurnal As String = ""
        Dim coaPiutang As String = ""
        Dim coaPiutangPending As String = ""

        ' Set COA Piutang & Piutang Pending
        If IsDBNull(rowInvoice("JenisPoli")) = False Then ' Jika Kolom Jenis Poli Tidak Kosong (Jurnal Berdasarkan Jenis Poli)
            Dim tblMasterJurnal As DataTable = ReadThemysql("SELECT * FROM MasterLokasiJurnal a WHERE a.KodeLokasi = '" & kodeLokasiKlinik & "' AND a.KeteranganPoli = '" & rowInvoice("JenisPoli") & "' LIMIT 1", DB_Omset)
            Dim rowDataJurnal As DataRow = tblMasterJurnal.Rows(0)
            idLokasiJurnal = rowDataJurnal("KodeLokasiJurnal")
            keteranganLokasiJurnal = rowDataJurnal("KeteranganLokasi") & " (" & rowDataJurnal("KeteranganPoli") & ") "
            coaPiutang = rowDataJurnal("KodeCoaPiutang")
            coaPiutangPending = rowDataJurnal("KodeCoaPiutangPending")
        Else ' Jika Kolom Jenis Poli Kosong (Jurnal Berdasarkan Jenis Transaksi)
            Dim tblMasterJurnal As DataTable = ReadThemysql("SELECT * FROM MasterLokasiJurnal a WHERE a.KodeLokasi = '" & kodeLokasiKlinik & "' AND a.JenisTransaksi = '" & rowInvoice("jenistransaksi") & "' LIMIT 1", DB_Omset)
            Dim rowDataJurnal As DataRow = tblMasterJurnal.Rows(0)
            idLokasiJurnal = rowDataJurnal("KodeLokasiJurnal")
            keteranganLokasiJurnal = rowDataJurnal("KeteranganLokasi") & " (" & rowDataJurnal("JenisTransaksi") & ") "
            If rowInvoice("jenistransaksi").ToString() = "POLI" Then
                coaPiutang = ReadThemysqlNIK("SELECT KodeAkun FROM MasterCoaJurnal WHERE NamaAkun = 'Piutang Poli Umum'", DB_Omset)
                coaPiutangPending = ReadThemysqlNIK("SELECT KodeAkun FROM MasterCoaJurnal WHERE NamaAkun = 'Piutang Pending Poli Umum'", DB_Omset)
            ElseIf rowInvoice("jenistransaksi").ToString() = "GIGI" Then
                coaPiutang = ReadThemysqlNIK("SELECT KodeAkun FROM MasterCoaJurnal WHERE NamaAkun = 'Piutang Poli Gigi'", DB_Omset)
                coaPiutangPending = ReadThemysqlNIK("SELECT KodeAkun FROM MasterCoaJurnal WHERE NamaAkun = 'Piutang Pending Poli Gigi'", DB_Omset)
            End If
        End If

        ' Set Flag / Refference
        Dim refferenceID As String = GetUUID()

        ' Set Nama Perusahaan
        Dim splitPerusahaan() As String = rowInvoice("company").ToString().Split("-")

        ' Set Keterangan Jurnal
        Dim keteranganJurnal As String = "CANCEL - TAGIHAN " & splitPerusahaan(0).ToString.Trim.ToUpper() & " " & keteranganLokasiJurnal & " " & Format(rowInvoice("tgltagihan"), "dd/MM/yyyy") & " (NO. INVOICE : " & nomorInvoice & ")"

        ' Kirim Jurnal Create Tagihan
        WriteThemysql("SELECT F_MakeUMH('" & refferenceID & "', 'out', '', '" & Format(rowInvoice("tgltagihan"), "yyyyMMdd") & "', '" & coaPiutang & "', '" & coaPiutangPending & "', 'IDR', 1, " & CDbl(rowInvoice("totaltagihan")) & ", '" & keteranganJurnal.ToUpper() & "', '1', 1, '', '" & keteranganJurnal.ToUpper() & "', '', '', '" & idLokasiJurnal & "', 4, " & CDbl(rowInvoice("totaltagihan")) & ", 'K')", DB_Jurnal)

        ' Update Tabel Rekap Tagihan (Online)
        WriteThemysql("UPDATE acctransrekaptagihan SET FlagJurnalCancel = '" & refferenceID & "' WHERE notagihancompany = '" & nomorInvoice & "'", DB_Keuangan)

        ' Insert Log Invoice Tagihan
        WriteSQL("INSERT INTO LogJurnalKeuangan (JurnalFlag, JurnalDate, JurnalBy, Status, JenisPoli, JenisTransaksi) VALUES ('" & refferenceID & "', GETDATE(), '" & userInput & "', '" & keteranganJurnal & "', '" & rowInvoice("JenisPoli").ToString & "', '" & rowInvoice("jenistransaksi").ToString() & "')", 4)
    End Sub

    Private Sub ButtonKirimUlangJurnal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonKirimUlangJurnal.Click
        SendingJurnal(TextBoxNoTagihan.Text)
    End Sub
End Class