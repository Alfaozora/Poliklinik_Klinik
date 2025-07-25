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

Public Class FormRekapFeeKaryawan
    Private userAdmin As String = PoliKlinik.Lbluser.Text
    Private dokterID As String = ""
    Private perawatID As String = ""
    'Private bridgingDokterID As String = ""

    Private Sub PanelTop_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelTop.Paint
        Try
            e.Graphics.DrawString("Rekap Fee Karyawan", New Font("Segoe UI Semibold", 15, FontStyle.Bold), Brushes.White, New Point(10, 3))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FormRekapFeeKaryawan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Control.CheckForIllegalCrossThreadCalls = False
            Me.MdiParent = PoliKlinik
            Me.Dock = DockStyle.Fill

            SetClearTabDokter()
            SetClearTabPerawat()

            '# Hide tab header button
            TabControl1.Appearance = TabAppearance.FlatButtons
            TabControl1.ItemSize = New Size(0, 1)
            TabControl1.SizeMode = TabSizeMode.Fixed
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMenu1.Click, btnMenu2.Click, btnMenu3.Click
        Try
            Dim myButton = DirectCast(sender, Button)

            Select Case myButton.Name
                Case "btnMenu1"
                    SetClearTabDokter()
                    TabControl1.SelectedTab = TabPage1
                Case "btnMenu2"
                    SetClearTabPerawat()
                    TabControl1.SelectedTab = TabPage2
                Case "btnMenu3"
                    SetClearTabLaporan()
                    TabControl1.SelectedTab = TabPage3
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Function CreateTableKonsultasi() As DataTable
        Dim Tbls As New DataTable

        insertRowToTbls(Tbls, "Typstring", "Tgl Transaksi")
        insertRowToTbls(Tbls, "Typstring", "Tgl Value")

        insertRowToTbls(Tbls, "Typstring", "Total Pasien")
        insertRowToTbls(Tbls, "Typstring", "Pasien Umum")
        insertRowToTbls(Tbls, "Typstring", "Pasien Jaminan")
        insertRowToTbls(Tbls, "Typstring", "Pasien Lab")
        insertRowToTbls(Tbls, "Typstring", "Pasien Jaminan Dan Lab")

        insertRowToTbls(Tbls, "tyinterger", "Total Fee Umum")
        insertRowToTbls(Tbls, "tyinterger", "Total Fee Jaminan")
        insertRowToTbls(Tbls, "tyinterger", "Total Semua")

        insertRowToTbls(Tbls, "Typstring", "Status")
        insertRowToTbls(Tbls, "typchecked", "Checked")

        Return Tbls
    End Function

    Function CreateTableTindakan() As DataTable
        Dim Tbls As New DataTable

        insertRowToTbls(Tbls, "Typstring", "Tgl Transaksi")
        insertRowToTbls(Tbls, "Typstring", "Tgl Value")
        insertRowToTbls(Tbls, "Typstring", "No Transaksi")
        insertRowToTbls(Tbls, "Typstring", "Tindakan")
        insertRowToTbls(Tbls, "tyinterger", "Nominal Bayar")

        insertRowToTbls(Tbls, "tyinterger", "Nominal BHP")
        insertRowToTbls(Tbls, "tyinterger", "Total Fee")
        insertRowToTbls(Tbls, "Typstring", "Nama Pasien")
        insertRowToTbls(Tbls, "Typstring", "Status")
        insertRowToTbls(Tbls, "typchecked", "Checked")

        Return Tbls
    End Function

    Private Sub SetGridKonsultasiDokter()
        Dim Tbls As DataTable = CreateTableKonsultasi()

        For Each Tcol As DataColumn In Tbls.Columns
            Tcol.ReadOnly = True
        Next

        Tbls.Columns("Checked").ReadOnly = False

        GridControlDokterMenu1.DataSource = Tbls

        GridView1.Columns("Tgl Value").Visible = False
    End Sub

    Private Sub SetGridTindakan()
        Dim Tbls As DataTable = CreateTableTindakan()

        For Each Tcol As DataColumn In Tbls.Columns
            Tcol.ReadOnly = True
        Next

        Tbls.Columns("Checked").ReadOnly = False

        GridControlDokterMenu1.DataSource = Tbls
        GridControlPerawatMenu2.DataSource = Tbls

        GridView1.Columns("Tgl Value").Visible = False
        GridView3.Columns("Tgl Value").Visible = False
    End Sub

    Private Sub SetClearTabDokter()
        ButtonFindTransaksi.Enabled = True
        ButtonFindDokterMenu1.Enabled = True
        DateTimeAwalTransaksi.Enabled = True
        DateTimePickerAkhirTransaksi.Enabled = True
        RadioButtonPilihanKonsultasi.Checked = True
        RadioButtonPilihanKonsultasi.Enabled = True
        RadioButtonPilihanTindakan.Enabled = True
        dokterID = ""
        'bridgingDokterID = ""
        TextBoxNamaPelaksana.ResetText()
        RadioButtonPilihanKonsultasi.Checked = True
        GridView1.Columns.Clear()

        DateTimeAwalTransaksi.Value = DateAndTime.Now
        DateTimePickerAkhirTransaksi.Value = DateAndTime.Now
    End Sub

    Private Sub SetClearTabPerawat()
        ButtonViewMenu2.Enabled = True
        DateTimeStartMenu2.Enabled = True
        DateTimeEndMenu2.Enabled = True
        RadioButtonTindakanMenu2.Checked = True
        RadioButtonTindakanMenu2.Enabled = True
        perawatID = ""
        TextBoxNamaPerawatMenu2.ResetText()
        GridView3.Columns.Clear()

        ButtonFindPerawatMenu2.Enabled = True

        DateTimeStartMenu2.Value = DateAndTime.Now
        DateTimeEndMenu2.Value = DateAndTime.Now
    End Sub

    Private Sub SetClearTabLaporan()
        perawatID = ""
        dokterID = ""
        'bridgingDokterID = ""
        rddokter.Checked = True
        rdkonsultasi.Checked = True
        loadcmbbulan()
        loadcmbyear()
    End Sub

    Private Sub loadcmbbulan()
        cmbbulan.Items.Add("Januari")
        cmbbulan.Items.Add("Februari")
        cmbbulan.Items.Add("Maret")
        cmbbulan.Items.Add("April")
        cmbbulan.Items.Add("Mei")
        cmbbulan.Items.Add("Juni")
        cmbbulan.Items.Add("Juli")
        cmbbulan.Items.Add("Agustus")
        cmbbulan.Items.Add("September")
        cmbbulan.Items.Add("Oktober")
        cmbbulan.Items.Add("November")
        cmbbulan.Items.Add("Desember")
        cmbbulan.SelectedIndex = 0
    End Sub

    Private Sub loadcmbyear()
        Dim vartahun As Integer = Date.Today.Year
        cmbtahun.Items.Add(vartahun)
        cmbtahun.Items.Add(vartahun - 1)
        cmbtahun.Items.Add(vartahun - 2)
        cmbtahun.Items.Add(vartahun - 3)
        cmbtahun.Items.Add(vartahun - 4)
        cmbtahun.SelectedIndex = 0
    End Sub

    Private Sub ButtonClearMenu1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SetClearTabDokter()
    End Sub

    Public Sub LoadDokterID(ByRef Tgrid As DataRowView)
        dokterID = Tgrid("ID")
        TextBoxNamaPelaksana.Text = Tgrid("Nama")
    End Sub

    Public Sub LoadLaporanDokterID(ByRef Tgrid As DataRowView)
        dokterID = Tgrid("ID")
        txdokterket.Text = Tgrid("Nama")
    End Sub

    Public Sub LoadPerawatID(ByRef Tgrid As DataRowView)
        perawatID = Tgrid("ID")
        TextBoxNamaPerawatMenu2.Text = Tgrid("Nama")
    End Sub

    Public Sub LoadLaporanPerawatID(ByRef Tgrid As DataRowView)
        perawatID = Tgrid("ID")
        txperawatket.Text = Tgrid("Nama")
    End Sub

    Function CheckingDokter() As Boolean
        If DateTimePickerAkhirTransaksi.Value < DateTimeAwalTransaksi.Value Then
            MsgBox("Tanggal akhir tidak boleh melebihi tanggal mulai.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        If dokterID = "" Then
            MsgBox("Pilih dokter terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        Return True
    End Function

    Function CheckingPerawat() As Boolean
        If DateTimeEndMenu2.Value < DateTimeStartMenu2.Value Then
            MsgBox("Tanggal akhir tidak boleh melebihi tanggal mulai.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        If perawatID = "" Then
            MsgBox("Pilih perawat terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        Return True
    End Function

    Function CheckingLaporan() As Boolean
        'Cek Bulan & Tahun  
        If cmbbulan.Text = "" Or cmbtahun.Text = "" Then
            MsgBox("Bulan & Tahun tidak boleh kosong.")
            Return False
        End If

        Return True
    End Function

    Private Sub ButtonViewMenu1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFindTransaksi.Click
        If CheckingDokter() = True Then
            If RadioButtonPilihanKonsultasi.Checked = True Then
                ViewKonsultasiDokter()
            ElseIf RadioButtonPilihanKonsultasi.Checked = False Then
                ViewTindakanDokter()
            End If
        End If
    End Sub

    Private Sub ViewTindakanDokter()
        SetGridTindakan()
        Dim startP As DateTime = New DateTime(DateTimeAwalTransaksi.Value.Year, DateTimeAwalTransaksi.Value.Month, DateTimeAwalTransaksi.Value.Day)
        Dim endP As DateTime = New DateTime(DateTimePickerAkhirTransaksi.Value.Year, DateTimePickerAkhirTransaksi.Value.Month, DateTimePickerAkhirTransaksi.Value.Day)
        'Dim startP As DateTime = New DateTime(2021, 2, 1)
        'Dim endP As DateTime = New DateTime(2021, 2, 28)
        Dim CurrD As DateTime = startP

        Dim tbls_tindakan As DataTable = ReadSQL("SELECT CONVERT(date, a.TglPoli) as 'Tgl Transaksi', a.NoUrut, UPPER(b.Nama) as 'Nama', a.TransPoliID, a.ClosingTindakanDokter " & _
                                                 "FROM TransaksiPoli a " & _
                                                 "LEFT JOIN MasterPasien b on a.IDInternet = b.NoRekamMedis " & _
                                                 "WHERE (CONVERT(date, a.TglPoli) between '" & startP & "' and '" & endP & "') and a.deleted = 0 and a.KodeDokter = '" & dokterID & "' " & _
                                                 "ORDER BY a.TransPoliID, CONVERT(date, a.TglPoli)")

        Dim Tdata As DataTable = CreateTableTindakan()
        Tdata.Rows.Clear()

        Dim DetailTindakan As String = ""

        For Each TrowData As DataRow In tbls_tindakan.Rows
            DetailTindakan = SetTindakanDetailPoli(TrowData("NoUrut"), "Dokter")

            If DetailTindakan <> "Nothing" Then
                Dim Tdetail() As String = DetailTindakan.Split("#")

                Dim Tnew As DataRow = Tdata.NewRow
                Tnew("Tgl Value") = TrowData("Tgl Transaksi")
                Tnew("Tgl Transaksi") = Format(TrowData("Tgl Transaksi"), "dd") & " " & BulanIndonesia(Format(TrowData("Tgl Transaksi"), "MM")) & " " & Format(TrowData("Tgl Transaksi"), "yyyy")
                Tnew("No Transaksi") = TrowData("NoUrut")
                Tnew("Tindakan") = Tdetail(0)
                Tnew("Nominal Bayar") = Tdetail(1)
                Tnew("Nominal BHP") = Tdetail(3)
                Tnew("Total Fee") = Tdetail(2)
                Tnew("Nama Pasien") = TrowData("Nama")

                If TrowData("ClosingTindakanDokter").ToString() = True Then
                    Tnew("Status") = "LOCKED"
                    Tnew("Checked") = True
                Else
                    Tnew("Status") = "-"
                    Tnew("Checked") = False
                End If

                Tdata.Rows.Add(Tnew)
            End If
        Next

        If Tdata.Rows.Count > 0 Then
            ButtonFindTransaksi.Enabled = False
            ButtonFindDokterMenu1.Enabled = False
            DateTimeAwalTransaksi.Enabled = False
            DateTimePickerAkhirTransaksi.Enabled = False
            RadioButtonPilihanKonsultasi.Enabled = False
        End If

        GridControlDokterMenu1.DataSource = Tdata
    End Sub

    Private Sub ViewKonsultasiDokter()
        Dim BatasPasienJaminanHarian As String = ReadSQLNIK("select StrValue FROM MsConfig WHERE ConfigName='BatasPasienJaminanHarian'")
        Dim FeePasienPoliUmum As String = ReadSQLNIK("select StrValue FROM MsConfig WHERE ConfigName='FeePasienPoliUmum'")
        Dim FeePasienPoliJaminan As String = ReadSQLNIK("select StrValue FROM MsConfig WHERE ConfigName='FeePasienPoliJaminan'")
        SetGridKonsultasiDokter()
        Dim startP As DateTime = New DateTime(DateTimeAwalTransaksi.Value.Year, DateTimeAwalTransaksi.Value.Month, DateTimeAwalTransaksi.Value.Day)
        Dim endP As DateTime = New DateTime(DateTimePickerAkhirTransaksi.Value.Year, DateTimePickerAkhirTransaksi.Value.Month, DateTimePickerAkhirTransaksi.Value.Day)
        'Dim startP As DateTime = New DateTime(2021, 2, 1)
        'Dim endP As DateTime = New DateTime(2021, 2, 28)
        Dim CurrD As DateTime = startP

        Dim sql_umum As String = "SELECT CONVERT(DATE, t2.tglpoli) AS 'Tgl Transaksi', Count(t2.nourut) AS 'Jumlah Transaksi' " & _
                                 "FROM(SELECT a.nourut, CONVERT(DATE, a.tglpoli) AS TglPoli, a.updateby, c.StatusFeeKonsultasi, c.jenisdokter, c.jenistindakan, a.deleted, a.KodeDokter " & _
                                 "FROM transaksipoli a " & _
                                 "LEFT JOIN transaksipolidetail b ON a.transpoliid=b.transpoliid " & _
                                 "LEFT JOIN mastertindakan c ON b.tindakanid=c.tindakanid " & _
                                 "LEFT JOIN transaksipolibayarawal d ON a.transpoliid=d.transpoliid " & _
                                 "WHERE b.NettBayar<>0 AND b.awal=1 AND b.DeletedDate IS NULL AND (((d.jenisbayar<>'TAGIHAN' AND d.jenisbayar IS NOT NULL)OR d.nojenisbayar LIKE '%TRANSFER%')and c.jenistindakan='Konsultasi Dokter Umum')AND(b.groupbayar IS NULL OR b.groupbayar='') " & _
                                 "UNION " & _
                                 "SELECT a.nourut, CONVERT(DATE, a.tglpoli) AS TglPoli, a.updateby, c.StatusFeeKonsultasi, c.jenisdokter, c.jenistindakan, a.deleted, a.KodeDokter " & _
                                 "FROM transaksipoli a " & _
                                 "LEFT JOIN transaksipolidetail b ON a.transpoliid=b.transpoliid " & _
                                 "LEFT JOIN mastertindakan c ON b.tindakanid=c.tindakanid " & _
                                 "LEFT JOIN transaksipolibayar d ON a.transpoliid=d.transpoliid AND b.groupbayar=d.groupbayar " & _
                                 "WHERE b.NettBayar<>0 and b.awal=0 AND b.DeletedDate IS NULL AND ((d.groupbayar IS NOT NULL AND(d.jenisbayar<>'TAGIHAN' OR d.nojenisbayar LIKE '%TRANSFER%'))and c.jenistindakan='Konsultasi Dokter Umum')) AS t2 " & _
                                 "WHERE t2.KodeDokter = '" & dokterID & "' AND t2.StatusFeeKonsultasi='1' AND t2.jenisdokter LIKE '%Dokter%' AND t2.deleted=0 AND(t2.tglpoli BETWEEN '" & startP & "' and '" & endP & "') " & _
                                 "GROUP BY CONVERT(DATE, t2.tglpoli)"

        Dim sql_jaminan As String = "SELECT CONVERT(DATE, t2.tglpoli) AS 'Tgl Transaksi', Count(t2.nourut) AS 'Jumlah Transaksi' " & _
                                     "FROM(SELECT a.nourut, CONVERT(DATE, a.tglpoli) AS TglPoli, a.updateby, c.jenisdokter, c.jenistindakan, a.deleted, d.jenisbayar, d.nojenisbayar, c.StatusFeeKonsultasi, a.KodeDokter " & _
                                     "FROM transaksipoli a " & _
                                     "LEFT JOIN transaksipolidetail b ON a.transpoliid=b.transpoliid " & _
                                     "LEFT JOIN mastertindakan c ON b.tindakanid=c.tindakanid " & _
                                     "LEFT JOIN transaksipolibayarawal d ON a.transpoliid=d.transpoliid " & _
                                     "WHERE(b.groupbayar IS NULL OR b.groupbayar='')AND b.awal=1 AND b.DeletedDate IS NULL and((d.jenisbayar IS NULL OR(d.jenisbayar NOT IN ('DEBET', 'TUNAI', 'CARD')AND d.nojenisbayar NOT LIKE '%TRANSFER%'))or c.jenistindakan LIKE '%Konsultasi Dokter Jaminan%') " & _
                                     "UNION " & _
                                     "SELECT a.nourut, CONVERT(DATE, a.tglpoli) AS TglPoli, a.updateby, c.jenisdokter, c.jenistindakan, a.deleted, d.jenisbayar, d.nojenisbayar, c.StatusFeeKonsultasi, a.KodeDokter " & _
                                     "FROM transaksipoli a " & _
                                     "LEFT JOIN transaksipolidetail b ON a.transpoliid=b.transpoliid " & _
                                     "LEFT JOIN mastertindakan c ON b.tindakanid=c.tindakanid " & _
                                     "LEFT JOIN transaksipolibayar d ON a.transpoliid=d.transpoliid AND b.groupbayar=d.groupbayar " & _
                                     "WHERE d.groupbayar IS NOT NULL AND b.awal=0 AND b.DeletedDate IS NULL and(d.groupbayar IS NOT NULL AND((d.jenisbayar IS NULL OR(d.jenisbayar NOT IN ('DEBET', 'TUNAI', 'CARD')AND d.nojenisbayar NOT LIKE '%TRANSFER%'))or c.jenistindakan LIKE '%Konsultasi Dokter Jaminan%'))) AS t2 " & _
                                     "WHERE t2.KodeDokter = '" & dokterID & "' AND t2.StatusFeeKonsultasi='1' AND t2.jenisdokter LIKE '%Dokter%' AND t2.deleted=0 AND(t2.tglpoli BETWEEN '" & startP & "' and '" & endP & "') " & _
                                     "GROUP BY CONVERT(DATE, t2.tglpoli)"

        Dim tbls_umum As DataTable = ReadSQL(sql_umum)

        Dim tbls_jaminan As DataTable = ReadSQL(sql_jaminan)

        Dim tbls_lab As DataTable = ReadSQL("select CONVERT(DATE, a.TglLab) as 'Tgl Transaksi', COUNT(a.NoUrut) as 'Jumlah Transaksi' " & _
                                            "FROM TransaksiLab a " & _
                                            "LEFT JOIN TransaksiLabFisik b on a.NoUrut = b.NoUrut " & _
                                            "WHERE b.FisikKet = 'Dokterpelaksana' and b.Result like '%" & TextBoxNamaPelaksana.Text & "%' and a.deleted = 0 and (CONVERT(DATE, a.TglLab) between '" & startP & "' and '" & endP & "') " & _
                                            "group by CONVERT(DATE, TglLab)")

        Dim tbls_closed As DataTable = ReadSQL("select CONVERT(date, TglTransaksi) as 'TglTransaksi' FROM RekapFeeKonsultasi WHERE jenistransaksi = 'Konsultasi' and (CONVERT(date, TglTransaksi) between '" & startP & "' and '" & endP & "') and KodeKaryawan = '" & dokterID & "'")

        '#Checkpoint 1
        'MsgBox("Checkpoint 1")

        Dim Tumum As New DataTable
        Dim Tjaminan As New DataTable
        Dim Tlab As New DataTable
        Dim VariabelUmum As New Dictionary(Of String, String)()
        Dim VariabelJaminan As New Dictionary(Of String, String)()
        Dim VariabelLab As New Dictionary(Of String, String)()
        Dim VariabelClosed As New Dictionary(Of String, String)()

        For Each TrowData As DataRow In tbls_umum.Rows
            VariabelUmum("TglUmum_" & TrowData("Tgl Transaksi")) = TrowData("Tgl Transaksi")
            VariabelUmum("JumlahUmum_" & TrowData("Tgl Transaksi")) = TrowData("Jumlah Transaksi")
            VariabelUmum("FeeUmum_" & TrowData("Tgl Transaksi")) = (CDbl(FeePasienPoliUmum) * CDbl(TrowData("Jumlah Transaksi")))
        Next

        For Each TrowData As DataRow In tbls_jaminan.Rows
            VariabelJaminan("TglJaminan_" & TrowData("Tgl Transaksi")) = TrowData("Tgl Transaksi")
            VariabelJaminan("JumlahJaminan_" & TrowData("Tgl Transaksi")) = TrowData("Jumlah Transaksi")
            VariabelJaminan("FeeJaminan_" & TrowData("Tgl Transaksi")) = (CDbl(FeePasienPoliJaminan) * CDbl(TrowData("Jumlah Transaksi")))
        Next

        For Each TrowData As DataRow In tbls_lab.Rows
            VariabelLab("TglLab_" & TrowData("Tgl Transaksi")) = TrowData("Tgl Transaksi")
            VariabelLab("JumlahLab_" & TrowData("Tgl Transaksi")) = TrowData("Jumlah Transaksi")
            VariabelLab("FeeLab_" & TrowData("Tgl Transaksi")) = (CDbl(FeePasienPoliJaminan) * CDbl(TrowData("Jumlah Transaksi")))
        Next

        For Each TrowData As DataRow In tbls_closed.Rows
            VariabelClosed("TglClosed_" & TrowData("TglTransaksi")) = TrowData("TglTransaksi")
        Next

        '#Checkpoint 2
        'MsgBox("Checkpoint 2")

        Dim TglTransaksi As String = ""
        Dim JumlahPasienUmum As Integer = 0
        Dim JumlahPasienJaminan As Integer = 0
        Dim JumlahPasienLab As Integer = 0
        Dim JumlahTotalPasien As Integer = 0
        Dim JumlahFeePasienUmum As Double = 0
        Dim JumlahFeePasienJaminan As Double = 0
        Dim JumlahFeePasienLab As Double = 0
        Dim JumlahTotalFee As Double = 0
        Dim JumlahPasienJaminanDanLab As Double = 0
        Dim JumlahPasienFix As Double = 0

        Dim Tdata As DataTable = CreateTableKonsultasi()
        Tdata.Rows.Clear()

        While (CurrD <= endP)
            TglTransaksi = ""
            JumlahPasienUmum = 0
            JumlahPasienJaminan = 0
            JumlahPasienLab = 0
            JumlahTotalPasien = 0
            JumlahFeePasienUmum = 0
            JumlahFeePasienJaminan = 0
            JumlahFeePasienLab = 0
            JumlahTotalFee = 0
            JumlahPasienJaminanDanLab = 0
            JumlahPasienFix = 0

            If VariabelUmum.ContainsValue(CurrD.ToShortDateString) Then
                TglTransaksi = VariabelUmum("TglUmum_" & CurrD.ToShortDateString)
                JumlahPasienUmum = VariabelUmum("JumlahUmum_" & CurrD.ToShortDateString)
                JumlahFeePasienUmum = VariabelUmum("FeeUmum_" & CurrD.ToShortDateString)
            End If

            If VariabelJaminan.ContainsValue(CurrD.ToShortDateString) Or VariabelLab.ContainsValue(CurrD.ToShortDateString) Then
                If VariabelJaminan.ContainsValue(CurrD.ToShortDateString) Then
                    JumlahPasienJaminan = CDbl(VariabelJaminan("JumlahJaminan_" & CurrD.ToShortDateString))
                    JumlahPasienJaminanDanLab = CDbl(VariabelJaminan("JumlahJaminan_" & CurrD.ToShortDateString))
                End If

                If VariabelLab.ContainsValue(CurrD.ToShortDateString) Then
                    JumlahPasienLab = VariabelLab("JumlahLab_" & CurrD.ToShortDateString)
                    JumlahPasienJaminanDanLab = JumlahPasienJaminanDanLab + CDbl(VariabelLab("JumlahLab_" & CurrD.ToShortDateString))
                End If

                If CDbl(JumlahPasienJaminanDanLab) > CDbl(BatasPasienJaminanHarian) Then
                    If VariabelJaminan.ContainsValue(CurrD.ToShortDateString) Then TglTransaksi = VariabelJaminan("TglJaminan_" & CurrD.ToShortDateString)
                    If VariabelLab.ContainsValue(CurrD.ToShortDateString) Then TglTransaksi = VariabelLab("TglLab_" & CurrD.ToShortDateString)

                    JumlahPasienFix = CDbl(JumlahPasienJaminanDanLab) - CDbl(BatasPasienJaminanHarian)
                    JumlahFeePasienJaminan = (CDbl(JumlahPasienJaminanDanLab) - CDbl(BatasPasienJaminanHarian)) * CDbl(FeePasienPoliJaminan)
                End If
            End If

            If TglTransaksi <> "" Then
                Dim Tnew As DataRow = Tdata.NewRow
                Tnew("Tgl Value") = TglTransaksi
                Tnew("Tgl Transaksi") = Format(CurrD, "dd") & " " & BulanIndonesia(Format(CurrD, "MM")) & " " & Format(CurrD, "yyyy")

                Tnew("Pasien Jaminan Dan Lab") = JumlahPasienFix

                Tnew("Pasien Umum") = JumlahPasienUmum
                Tnew("Pasien Jaminan") = JumlahPasienJaminan
                Tnew("Pasien Lab") = JumlahPasienLab
                Tnew("Total Pasien") = JumlahPasienUmum + JumlahPasienJaminanDanLab
                Tnew("Total Fee Umum") = JumlahFeePasienUmum
                Tnew("Total Fee Jaminan") = JumlahFeePasienJaminan
                Tnew("Total Semua") = JumlahFeePasienUmum + JumlahFeePasienJaminan
                If VariabelClosed.ContainsValue(CurrD.ToShortDateString) Then
                    Tnew("Checked") = True
                    Tnew("Status") = "LOCKED"
                Else
                    Tnew("Checked") = False
                    Tnew("Status") = "-"
                End If
                Tdata.Rows.Add(Tnew)
            End If

            CurrD = CurrD.AddDays(1)
        End While

        '#Checkpoint 3
        'MsgBox("Checkpoint 3")

        If Tdata.Rows.Count > 0 Then
            ButtonFindTransaksi.Enabled = False
            ButtonFindDokterMenu1.Enabled = False
            DateTimeAwalTransaksi.Enabled = False
            DateTimePickerAkhirTransaksi.Enabled = False
            RadioButtonPilihanTindakan.Enabled = False
        End If

        GridControlDokterMenu1.DataSource = Tdata
    End Sub

    Private Sub ViewTindakanPerawat()
        SetGridTindakan()
        Dim startP As DateTime = New DateTime(DateTimeStartMenu2.Value.Year, DateTimeStartMenu2.Value.Month, DateTimeStartMenu2.Value.Day)
        Dim endP As DateTime = New DateTime(DateTimeEndMenu2.Value.Year, DateTimeEndMenu2.Value.Month, DateTimeEndMenu2.Value.Day)
        'Dim startP As DateTime = New DateTime(2021, 2, 1)
        'Dim endP As DateTime = New DateTime(2021, 2, 28)
        Dim CurrD As DateTime = startP

        Dim tbls_tindakan As DataTable = ReadSQL("select CONVERT(date, a.TglPoli) as 'Tgl Transaksi', a.NoUrut, UPPER(b.Nama) as 'Nama', a.TransPoliID, a.ClosingTindakanPerawat " & _
                                                 "FROM TransaksiPoli a " & _
                                                 "LEFT JOIN MasterPasien b on a.IDInternet = b.NoRekamMedis " & _
                                                 "WHERE (CONVERT(date, a.TglPoli) between '" & startP & "' and '" & endP & "') and a.deleted = 0 and a.PerawatPoli like '%" & TextBoxNamaPerawatMenu2.Text & "%' " & _
                                                 "ORDER BY a.TransPoliID, CONVERT(date, a.TglPoli)")

        Dim Tdata As DataTable = CreateTableTindakan()
        Tdata.Rows.Clear()

        Dim DetailTindakan As String = ""

        For Each TrowData As DataRow In tbls_tindakan.Rows
            DetailTindakan = SetTindakanDetailPoli(TrowData("NoUrut"), "Perawat")

            If DetailTindakan <> "Nothing" Then
                Dim Tdetail() As String = DetailTindakan.Split("#")

                Dim Tnew As DataRow = Tdata.NewRow
                Tnew("Tgl Value") = TrowData("Tgl Transaksi")
                Tnew("Tgl Transaksi") = Format(TrowData("Tgl Transaksi"), "dd") & " " & BulanIndonesia(Format(TrowData("Tgl Transaksi"), "MM")) & " " & Format(TrowData("Tgl Transaksi"), "yyyy")
                Tnew("No Transaksi") = TrowData("NoUrut")
                Tnew("Tindakan") = Tdetail(0)
                Tnew("Nominal Bayar") = Tdetail(1)
                Tnew("Nominal BHP") = Tdetail(3)
                Tnew("Total Fee") = Tdetail(2)
                Tnew("Nama Pasien") = TrowData("Nama")

                If TrowData("ClosingTindakanPerawat").ToString() = True Then
                    Tnew("Status") = "LOCKED"
                    Tnew("Checked") = True
                Else
                    Tnew("Status") = "-"
                    Tnew("Checked") = False
                End If

                Tdata.Rows.Add(Tnew)
            End If
        Next

        If Tdata.Rows.Count > 0 Then
            ButtonViewMenu2.Enabled = False
            ButtonFindPerawatMenu2.Enabled = False
            DateTimeStartMenu2.Enabled = False
            DateTimeEndMenu2.Enabled = False
        End If

        GridControlPerawatMenu2.DataSource = Tdata
    End Sub

    Private Sub ButtonSimpanMenu1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If RadioButtonPilihanKonsultasi.Checked = True Then
            SaveKonsultasiDokter()
        ElseIf RadioButtonPilihanTindakan.Checked = True Then
            SaveTindakanDokter()
        End If
    End Sub

    Private Sub SaveKonsultasiDokter()
        Dim JumlahSimpan As Integer = 0
        Dim Tbls As DataTable = GridControlDokterMenu1.DataSource

        If Tbls IsNot Nothing AndAlso Tbls.Rows.Count > 0 Then
            For Each Trow As DataRow In Tbls.Select("[Checked]=True")
                If Trow("Status") <> "LOCKED" Then
                    WriteSQL("insert into RekapFeeKonsultasi (JenisTransaksi, TglTransaksi, JumlahPasienUmum, JumlahPasienJaminan, JumlahPasienLab, TotalPasien, TotalFeeUmum, TotalFeeJaminan, GrandTotalFee, JenisKaryawan, KodeKaryawan, JumlahPasienJaminanDanLab, CreateDate, CreateBy) " & _
                             "values ('Konsultasi', '" & Trow("Tgl Value") & "', '" & Trow("Pasien Umum") & "', '" & Trow("Pasien Jaminan") & "', '" & Trow("Pasien Lab") & "', '" & Trow("Total Pasien") & "', '" & Trow("Total Fee Umum") & "', '" & Trow("Total Fee Jaminan") & "', '" & Trow("Total Semua") & "', 'Dokter', '" & dokterID & "', '" & Trow("Pasien Jaminan Dan Lab") & "', getdate(), '" & userAdmin & "')", 4)
                    JumlahSimpan = JumlahSimpan + 1
                End If
            Next
        End If

        If JumlahSimpan > 0 Then
            MsgBox("Berhasil menyimpan data.", MsgBoxStyle.Information, "Success!")
            SetClearTabDokter()
        Else
            MsgBox("Tidak ada data yang disimpan.", MsgBoxStyle.Exclamation, "Warning!")
        End If
    End Sub

    Private Sub SaveTindakanDokter()
        Dim JumlahSimpan As Integer = 0
        Dim DaftarNoTransaksi As String = ""
        Dim TtempDaftarNoTransaksi As String = ""
        Dim Tbls As DataTable = GridControlDokterMenu1.DataSource

        If Tbls IsNot Nothing AndAlso Tbls.Rows.Count > 0 Then
            For Each Trow As DataRow In Tbls.Select("[Checked]=True")
                If Trow("Status") <> "LOCKED" Then
                    '#Insert ke tabel RekapFeeTindakan
                    WriteSQL("Insert into RekapFeeTindakan (JenisTransaksi, TglTransaksi, NoTransaksi, NamaPasien, Tindakan, NominalBayar, NominalBHP, NominalFee, JenisKaryawan, KodeKaryawan, CreateDate, CreateBy) " & _
                             "values ('Tindakan', '" & Trow("Tgl Value") & "', '" & Trow("No Transaksi") & "', '" & Trow("Nama Pasien") & "', '" & Trow("Tindakan") & "', '" & Trow("Nominal Bayar") & "', '" & Trow("Nominal BHP") & "', '" & Trow("Total Fee") & "', 'Dokter', '" & dokterID & "', getdate(), '" & userAdmin & "')", 4)

                    'Cek sudah ada log atau tidak
                    If CheckSQL("select * FROM RekapFeeKonsultasi WHERE JenisTransaksi='Tindakan' and TglTransaksi='" & Trow("Tgl Value") & "' and KodeKaryawan = '" & dokterID & "' and JenisKaryawan = 'Dokter'") = False Then
                        WriteSQL("Insert into RekapFeeKonsultasi (JenisTransaksi, TglTransaksi, JumlahPasienUmum, JumlahPasienJaminan, JumlahPasienLab, TotalPasien, TotalFeeUmum, TotalFeeJaminan, GrandTotalFee, JenisKaryawan, KodeKaryawan, TotalBHP, CreateDate, CreateBy) values ('Tindakan', '" & Trow("Tgl Value") & "', '0', '0', '0', '1', '0', '0', '" & Trow("Total Fee") & "', 'Dokter', '" & dokterID & "', '" & Trow("Nominal BHP") & "', getdate(), '" & userAdmin & "')", 4)
                    Else
                        WriteSQL("Update RekapFeeKonsultasi Set TotalPasien = TotalPasien + 1, GrandTotalFee = GrandTotalFee + " & Trow("Total Fee") & ", TotalBHP = TotalBHP + " & Trow("Nominal BHP") & " WHERE JenisTransaksi='Tindakan' and TglTransaksi='" & Trow("Tgl Value") & "' and KodeKaryawan = '" & dokterID & "' and JenisKaryawan = 'Dokter'", 4)
                    End If

                    DaftarNoTransaksi = DaftarNoTransaksi & "'" & Trow("No Transaksi").ToString.Trim & "', "

                    JumlahSimpan = JumlahSimpan + 1
                End If
            Next
        End If

        If JumlahSimpan > 0 Then
            DaftarNoTransaksi = Strings.Left(DaftarNoTransaksi, DaftarNoTransaksi.Length - 2)
            WriteSQL("Update TransaksiPoli Set ClosingTindakanDokter = 1 WHERE NoUrut in (" & DaftarNoTransaksi & ")", 4)

            MsgBox("Berhasil menyimpan data.", MsgBoxStyle.Information, "Success!")
            SetClearTabDokter()
        Else
            MsgBox("Tidak ada data yang disimpan.", MsgBoxStyle.Exclamation, "Warning!")
        End If
    End Sub

    Private Sub cbAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxSelectAllOption.CheckedChanged
        Dim Tbls As DataTable = GridControlDokterMenu1.DataSource

        If Tbls.Rows.Count > 0 Then
            For Each Trow As DataRow In Tbls.Rows
                'If Trow("Status") = "-" Then
                If CheckBoxSelectAllOption.CheckState = CheckState.Checked Then
                    Trow("Checked") = True
                Else
                    Trow("Checked") = False
                End If
                'End If
            Next
        End If
    End Sub

    Private Sub ButtonClearMenu2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClearMenu2.Click
        SetClearTabPerawat()
    End Sub

    Private Sub ButtonViewMenu2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonViewMenu2.Click
        If CheckingPerawat() = True Then
            ViewTindakanPerawat()
        End If
    End Sub

    Private Sub ButtonSimpanMenu2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSimpanMenu2.Click
        SaveTindakanPerawat()
    End Sub

    Private Sub SaveTindakanPerawat()
        Dim JumlahSimpan As Integer = 0
        Dim DaftarNoTransaksi As String = ""
        Dim TtempDaftarNoTransaksi As String = ""
        Dim Tbls As DataTable = GridControlPerawatMenu2.DataSource

        If Tbls IsNot Nothing AndAlso Tbls.Rows.Count > 0 Then
            For Each Trow As DataRow In Tbls.Select("[Checked]=True")
                If Trow("Status") <> "LOCKED" Then
                    '#Insert ke tabel RekapFeeTindakan
                    WriteSQL("Insert into RekapFeeTindakan (JenisTransaksi, TglTransaksi, NoTransaksi, NamaPasien, Tindakan, NominalBayar, NominalBHP, NominalFee, JenisKaryawan, KodeKaryawan, CreateDate, CreateBy) " & _
                             "values ('Tindakan', '" & Trow("Tgl Value") & "', '" & Trow("No Transaksi") & "', '" & Trow("Nama Pasien") & "', '" & Trow("Tindakan") & "', '" & Trow("Nominal Bayar") & "', '" & Trow("Nominal BHP") & "', '" & Trow("Total Fee") & "', 'Perawat', '" & perawatID & "', getdate(), '" & userAdmin & "')", 4)

                    'Cek sudah ada log atau tidak
                    If CheckSQL("select * FROM RekapFeeKonsultasi WHERE JenisTransaksi='Tindakan' and TglTransaksi='" & Trow("Tgl Value") & "' and KodeKaryawan = '" & perawatID & "' and JenisKaryawan = 'Perawat'") = False Then
                        WriteSQL("Insert into RekapFeeKonsultasi (JenisTransaksi, TglTransaksi, JumlahPasienUmum, JumlahPasienJaminan, JumlahPasienLab, TotalPasien, TotalFeeUmum, TotalFeeJaminan, GrandTotalFee, JenisKaryawan, KodeKaryawan, TotalBHP, CreateDate, CreateBy) values ('Tindakan', '" & Trow("Tgl Value") & "', '0', '0', '0', '1', '0', '0', '" & Trow("Total Fee") & "', 'Perawat', '" & perawatID & "', '" & Trow("Nominal BHP") & "', getdate(), '" & userAdmin & "')", 4)
                    Else
                        WriteSQL("Update RekapFeeKonsultasi Set TotalPasien = TotalPasien + 1, GrandTotalFee = GrandTotalFee + " & Trow("Total Fee") & ", TotalBHP = TotalBHP + " & Trow("Nominal BHP") & " WHERE JenisTransaksi='Tindakan' and TglTransaksi='" & Trow("Tgl Value") & "' and KodeKaryawan = '" & perawatID & "' and JenisKaryawan = 'Perawat'", 4)
                    End If

                    DaftarNoTransaksi = DaftarNoTransaksi & "'" & Trow("No Transaksi").ToString.Trim & "', "

                    JumlahSimpan = JumlahSimpan + 1
                End If
            Next
        End If

        If JumlahSimpan > 0 Then
            DaftarNoTransaksi = Strings.Left(DaftarNoTransaksi, DaftarNoTransaksi.Length - 2)
            WriteSQL("Update TransaksiPoli Set ClosingTindakanPerawat = 1 WHERE NoUrut in (" & DaftarNoTransaksi & ")", 4)

            MsgBox("Berhasil menyimpan data.", MsgBoxStyle.Information, "Success!")
            SetClearTabPerawat()
        Else
            MsgBox("Tidak ada data yang disimpan.", MsgBoxStyle.Exclamation, "Warning!")
        End If
    End Sub

    Private Sub CheckBoxSelectAllMenu2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxSelectAllMenu2.CheckedChanged
        Dim Tbls As DataTable = GridControlPerawatMenu2.DataSource

        If Tbls.Rows.Count > 0 Then
            For Each Trow As DataRow In Tbls.Rows
                If CheckBoxSelectAllMenu2.CheckState = CheckState.Checked Then
                    Trow("Checked") = True
                Else
                    Trow("Checked") = False
                End If
            Next
        End If
    End Sub

    Private Sub ButtonCetakMenu3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCetakMenu3.Click
        If CheckingLaporan() = True Then
            If rdkonsultasi.Checked = True And rddokter.Checked = True Then
                CetakKonsultasiDokter()
            ElseIf rdtindakan.Checked = True And rddokter.Checked = True Then
                CetakTindakanDokter()
            ElseIf rdtindakan.Checked = True And rdperawat.Checked = True Then
                CetakTindakanPerawat()
            End If
        End If
    End Sub

    Private Sub CetakTindakanDokter()
        Dim bulan As String = Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(cmbbulan.Text, "Januari", "01"), "Februari", "02"), "Maret", "03"), "April", "04"), "Mei", "05"), "Juni", "06"), "Juli", "07"), "Agustus", "08"), "September", "09"), "Oktober", "10"), "November", "11"), "Desember", "12")
        Dim tahun As String = cmbtahun.Text

        Dim tbls As DataTable = ReadSQL("select * FROM RekapFeeTindakan a " & _
                                        "WHERE YEAR(a.TglTransaksi) = '" & tahun & "' AND MONTH(a.TglTransaksi) = '" & bulan & "' and a.KodeKaryawan = '" & dokterID & "' ORDER BY a.NoTransaksi, CONVERT(date, a.TglTransaksi)")

        Dim Tdata As DataTable = CreateTableTindakan()
        Tdata.Rows.Clear()

        For Each TrowData As DataRow In tbls.Rows
            Dim Tnew As DataRow = Tdata.NewRow
            Tnew("Tgl Value") = TrowData("TglTransaksi")
            Tnew("Tgl Transaksi") = Format(TrowData("TglTransaksi"), "dd") & " " & BulanIndonesia(Format(TrowData("TglTransaksi"), "MM")) & " " & Format(TrowData("TglTransaksi"), "yyyy")
            Tnew("No Transaksi") = TrowData("NoTransaksi")
            Tnew("Tindakan") = TrowData("Tindakan")
            Tnew("Nominal Bayar") = Val(TrowData("NominalBayar"))
            Tnew("Nominal BHP") = Val(TrowData("NominalBHP"))
            Tnew("Total Fee") = Val(TrowData("NominalFee"))
            Tnew("Nama Pasien") = TrowData("NamaPasien")
            Tdata.Rows.Add(Tnew)
        Next

        Report = New XtraReport
        Report = XtraReport.FromFile(Application.StartupPath + "\reports\Klinik\RekapFeeTindakanDokter.repx", True)
        Report.DataSource = Tdata

        Report.Bands.Item(BandKind.ReportHeader).Controls("lbltanggal").Text = BulanIndonesia(bulan) & " " & tahun

        Report.Bands.Item(BandKind.ReportHeader).Controls("lbldokter").Text = txdokterket.Text
        Report.Bands.Item(BandKind.ReportHeader).Controls("lblheader").Text = "REKAPAN FEE TINDAKAN DOKTER UMUM"
        Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:ss") & " By " & PoliKlinik.Lbluser.Text

        If tbls.Rows.Count > 0 Then
            'Report.RunDesigner()
            Report.ShowPreview()
            'Report.Print()
        Else
            MsgBox("Tidak ada data yang ditampilkan.", MsgBoxStyle.Exclamation, "Warning!")
        End If
    End Sub

    Private Sub CetakTindakanPerawat()
        Dim bulan As String = Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(cmbbulan.Text, "Januari", "01"), "Februari", "02"), "Maret", "03"), "April", "04"), "Mei", "05"), "Juni", "06"), "Juli", "07"), "Agustus", "08"), "September", "09"), "Oktober", "10"), "November", "11"), "Desember", "12")
        Dim tahun As String = cmbtahun.Text

        Dim tbls As DataTable = ReadSQL("select * FROM RekapFeeTindakan a " & _
                                        "WHERE YEAR(a.TglTransaksi) = '" & tahun & "' AND MONTH(a.TglTransaksi) = '" & bulan & "' and a.KodeKaryawan = '" & perawatID & "' ORDER BY a.NoTransaksi, CONVERT(date, a.TglTransaksi)")

        Dim Tdata As DataTable = CreateTableTindakan()
        Tdata.Rows.Clear()

        For Each TrowData As DataRow In tbls.Rows
            Dim Tnew As DataRow = Tdata.NewRow
            Tnew("Tgl Value") = TrowData("TglTransaksi")
            Tnew("Tgl Transaksi") = Format(TrowData("TglTransaksi"), "dd") & " " & BulanIndonesia(Format(TrowData("TglTransaksi"), "MM")) & " " & Format(TrowData("TglTransaksi"), "yyyy")
            Tnew("No Transaksi") = TrowData("NoTransaksi")
            Tnew("Tindakan") = TrowData("Tindakan")
            Tnew("Nominal Bayar") = Val(TrowData("NominalBayar"))
            Tnew("Nominal BHP") = Val(TrowData("NominalBHP"))
            Tnew("Total Fee") = Val(TrowData("NominalFee"))
            Tnew("Nama Pasien") = TrowData("NamaPasien")
            Tdata.Rows.Add(Tnew)
        Next

        Report = New XtraReport
        Report = XtraReport.FromFile(Application.StartupPath + "\reports\Klinik\RekapFeeTindakanDokter.repx", True)
        Report.DataSource = Tdata

        Report.Bands.Item(BandKind.ReportHeader).Controls("lbltanggal").Text = BulanIndonesia(bulan) & " " & tahun

        Report.Bands.Item(BandKind.ReportHeader).Controls("lbldokter").Text = txperawatket.Text
        Report.Bands.Item(BandKind.ReportHeader).Controls("lblheader").Text = "REKAPAN FEE TINDAKAN PERAWAT"
        Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:ss") & " By " & PoliKlinik.Lbluser.Text

        If tbls.Rows.Count > 0 Then
            'Report.RunDesigner()
            Report.ShowPreview()
            'Report.Print()
        Else
            MsgBox("Tidak ada data yang ditampilkan.", MsgBoxStyle.Exclamation, "Warning!")
        End If
    End Sub

    Private Sub CetakKonsultasiDokter()
        Dim bulan As String = Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(cmbbulan.Text, "Januari", "01"), "Februari", "02"), "Maret", "03"), "April", "04"), "Mei", "05"), "Juni", "06"), "Juli", "07"), "Agustus", "08"), "September", "09"), "Oktober", "10"), "November", "11"), "Desember", "12")
        Dim tahun As String = cmbtahun.Text

        Dim tbls As DataTable = ReadSQL("SELECT CONVERT(date, TglTransaksi) as 'TglTransaksi', JumlahPasienUmum, JumlahPasienJaminan, JumlahPasienLab, TotalPasien, TotalFeeUmum, TotalFeeJaminan,GrandTotalFee, TotalBHP, JumlahPasienJaminanDanLab FROM RekapFeeKonsultasi WHERE JenisTransaksi = 'Konsultasi' AND YEAR(TglTransaksi) = '" & tahun & "' AND MONTH(TglTransaksi) = '" & bulan & "' AND JenisKaryawan = 'Dokter' AND KodeKaryawan = '" & dokterID & "'")

        Report = New XtraReport
        Report = XtraReport.FromFile(Application.StartupPath + "\reports\Klinik\RekapFeeKonsultasiDokter.repx", True)
        Report.DataSource = tbls

        Report.Bands.Item(BandKind.ReportHeader).Controls("lbltanggal").Text = BulanIndonesia(bulan) & " " & tahun

        Report.Bands.Item(BandKind.ReportHeader).Controls("lbldokter").Text = txdokterket.Text
        Report.Bands.Item(BandKind.ReportHeader).Controls("lblheader").Text = "REKAPAN FEE KONSULTASI DOKTER UMUM"
        Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:ss") & " By " & PoliKlinik.Lbluser.Text

        If tbls.Rows.Count > 0 Then
            'Report.RunDesigner()
            Report.ShowPreview()
            'Report.Print()
        Else
            MsgBox("Tidak ada data yang ditampilkan.", MsgBoxStyle.Exclamation, "Warning!")
        End If
    End Sub

    Private Sub rddokter_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rddokter.CheckedChanged
        txperawatket.Enabled = False
        ButtonLaporanPerawat.Enabled = False
        txdokterket.Enabled = True
        ButtonLaporanDokter.Enabled = True

        rdkonsultasi.Checked = True
        rdkonsultasi.Enabled = True

        perawatID = ""
        txperawatket.ResetText()
    End Sub

    Private Sub rdperawat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdperawat.CheckedChanged
        txperawatket.Enabled = True
        ButtonLaporanPerawat.Enabled = True
        txdokterket.Enabled = False
        ButtonLaporanDokter.Enabled = False

        rdkonsultasi.Checked = False
        rdkonsultasi.Enabled = False
        rdtindakan.Checked = True

        dokterID = ""
        'bridgingDokterID = ""
        txdokterket.ResetText()
    End Sub

    Private Sub ButtonExportMenu3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExportMenu3.Click
        Dim bulan As String = Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(cmbbulan.Text, "Januari", "01"), "Februari", "02"), "Maret", "03"), "April", "04"), "Mei", "05"), "Juni", "06"), "Juli", "07"), "Agustus", "08"), "September", "09"), "Oktober", "10"), "November", "11"), "Desember", "12")
        Dim tahun As String = cmbtahun.Text

        Dim Tbls As DataTable = ReadSQL("select b.NoNIP as 'Nip' , convert(varchar, getdate(), 112)  as 'Tgl Entry', SUM(a.GrandTotalFee) as 'Nilai', 'PENDAPATAN LAIN-LAIN' as 'Keterangan', 'Pendapatan' as 'Tipe' " & _
                                        "FROM RekapFeeKonsultasi a " & _
                                        "LEFT JOIN MasterDokter b on a.KodeKaryawan = b.ID " & _
                                        "WHERE YEAR(a.TglTransaksi) = '" & tahun & "' AND MONTH(a.TglTransaksi) = '" & bulan & "' " & _
                                        "group by b.NoNIP")

        If Tbls.Rows.Count > 0 Then
            Dim dt As New DataTable

            dt.Columns.AddRange(New DataColumn() {New DataColumn("Nip", GetType(String)), _
                                               New DataColumn("Tgl Entry", GetType(String)), _
                                               New DataColumn("Nilai", GetType(String)), _
                                               New DataColumn("Keterangan", GetType(String)), _
                                               New DataColumn("Tipe", GetType(String))})

            dt.Rows.Add("Nip", "Tgl Entry", "Nilai", "Keterangan", "Tipe")

            For Each Trow As DataRow In Tbls.Rows
                dt.Rows.Add("" & Trow("Nip") & "", "" & Trow("Tgl Entry") & "", "" & Trow("Nilai") & "", "" & Trow("Keterangan") & "", "" & Trow("Tipe") & "")
            Next

            Dim lines() As String = Enumerable.Range(0, dt.Rows.Count).Select(Function(x) String.Join(",", Array.ConvertAll(dt.Rows(x).ItemArray, Function(o) o.ToString))).ToArray

            Dim nameFile As String = "File Upload " & cmbbulan.Text & " " & cmbtahun.Text & "_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".csv"
            Dim filePath As String = "D:\Data Program Poliklinik\File Rekap Fee\"

            If Not System.IO.Directory.Exists(filePath) Then
                System.IO.Directory.CreateDirectory(filePath)
            End If

            IO.File.WriteAllLines(filePath & nameFile, lines)

            MsgBox("Data berhasil disimpan di drive " & filePath & nameFile & ".", MsgBoxStyle.Information, "Success!")

            Process.Start(filePath & nameFile)
        Else
            MsgBox("Tidak ada data yang ditampilkan.", MsgBoxStyle.Exclamation, "Warning!")
        End If
    End Sub

    Private Sub ButtonClearMenu3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClearMenu3.Click
        SetClearTabLaporan()
    End Sub

    Private Sub ButtonFindDokterMenu1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFindDokterMenu1.Click
        Find.Show()
        Find.Query("SELECT ID, Nama, Jenis FROM MasterDokter WHERE Jenis LIKE '%Dokter%' AND StatusAktif = 1", " ORDER BY Nama ", "FindDokterFormRekapFeeKaryawan", 2)
    End Sub

    Private Sub ButtonFindPerawatMenu2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFindPerawatMenu2.Click
        Find.Show()
        Find.Query("SELECT ID, Nama, Jenis FROM MasterDokter WHERE Jenis LIKE '%Perawat%' AND StatusAktif = 1", " ORDER BY Nama ", "FindPerawatFormRekapFeeKaryawan", 2)
    End Sub

    Private Sub ButtonLaporanDokter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLaporanDokter.Click
        Find.Show()
        Find.Query("SELECT ID, Nama, Jenis FROM MasterDokter WHERE Jenis LIKE '%Dokter%' AND StatusAktif = 1", " ORDER BY Nama ", "FindLaporanDokterFormRekapFeeKaryawan", 2)
    End Sub

    Private Sub ButtonLaporanPerawat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLaporanPerawat.Click
        Find.Show()
        Find.Query("SELECT ID, Nama, Jenis FROM MasterDokter WHERE Jenis LIKE '%Perawat%' AND StatusAktif = 1", " ORDER BY Nama ", "FindLaporanPerawatFormRekapFeeKaryawan", 2)
    End Sub

    Private Sub ButtonSimpanDokter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSimpanDokter.Click
        If RadioButtonPilihanKonsultasi.Checked = True Then
            SaveKonsultasiDokter()
        ElseIf RadioButtonPilihanTindakan.Checked = True Then
            SaveTindakanDokter()
        End If
    End Sub

    Private Sub ButtonClearData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClearData.Click
        SetClearTabDokter()
    End Sub
End Class