Imports KASLibrary
Imports System.Drawing
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraReports.UI
Imports System.Drawing.Text
Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Object
Imports Newtonsoft.Json
Imports Newtonsoft
Imports System.Security.Cryptography
Imports System.Collections.Generic
Imports Newtonsoft.Json.Linq
Imports DevExpress.XtraPrinting
Imports System.Net.Mail
Imports System.Net.Sockets

Public Class FormCetakInvoice
    Dim Tbls, Tbls2 As New DataTable
    Dim txtotalbruto, txtotaldisc, txtotalpembulatan, txkembali As Double
    Dim thread As System.Threading.Thread

    ' Variabel Lokal
    Private userInput As String = PoliKlinik.Lbluser.Text

    Private Sub SetClear()
        cmbjenis.Enabled = True
        butfind.Enabled = True
        txtotalrow.ResetText()
        cmbjenis.ResetText()
        dttanggal.Value = DateAndTime.Now
        TextBoxNomorTransaksi.ResetText()
        txtotalrow.ResetText()

        txpoliid.ResetText()
        txcustnama.ResetText()
        TextBoxNomorRM.ResetText()
        dtcusttgllhr.Value = DateAndTime.Now
        txumur.ResetText()
        txcustlp.ResetText()

        txtotal.ResetText()
        txrequest.ResetText()
        TextBoxNamaDokter.ResetText()
        txadmin.ResetText()
        LoadGrid("0", "")
        LoadBayar("-1", "")
    End Sub

    Private Sub LoadGrid(ByRef Txid As String, ByRef Turut As String)
        Dim queryDetail As New StringBuilder()
        Dim queryBayar As New StringBuilder()

        TextBoxNomorTransaksi.Text = Turut

        If cmbjenis.Text = "AWALGIGI" Then
            ' Set Query Detail
            queryDetail.AppendLine("SELECT")
            queryDetail.AppendLine("  TindakanID,")
            queryDetail.AppendLine("  NamaTindakan AS [Tindakan],")
            queryDetail.AppendLine("  JenisTindakan AS [Jenis],")
            queryDetail.AppendLine("  PARSENAME(CONVERT(varchar, CONVERT(money, BiayaTindakan), 1), 2) AS [Biaya Tindakan],")
            queryDetail.AppendLine("  PARSENAME(CONVERT(varchar, CONVERT(money, DiscPersenTindakan), 1), 2) AS DiscTindakan,")
            queryDetail.AppendLine("  PARSENAME(CONVERT(varchar, CONVERT(money, DiscTindakan), 1), 2) AS DiscNilai,")
            queryDetail.AppendLine("  PARSENAME(CONVERT(varchar, CONVERT(money, NettBayar), 1), 2) AS NettBayar")
            queryDetail.AppendLine("FROM TransaksiGigiDetail")
            queryDetail.AppendLine("WHERE DeletedDate IS NULL AND Awal = 1 AND TransGigiID = '" & Txid & "'")

            ' Set Query Bayar
            queryBayar.AppendLine("SELECT *")
            queryBayar.AppendLine("FROM TransaksiGigiBayarAwal")
            queryBayar.AppendLine("WHERE TransGigiID = '" & Txid & "' AND TransJenis = 'GIGI'")

            TextBoxNamaDokter.Text = ReadSQLNIK("SELECT DokterGigi FROM TransaksiGigi WHERE TransGigiID = '" & Txid & "' AND Nourut = '" & Turut & "'")
            txrequest.Text = "-"
        ElseIf cmbjenis.Text = "GIGI" Then
            ' Set Query Detail
            queryDetail.AppendLine("SELECT")
            queryDetail.AppendLine("  TindakanID,")
            queryDetail.AppendLine("  NamaTindakan AS [Tindakan],")
            queryDetail.AppendLine("  JenisTindakan AS [Jenis],")
            queryDetail.AppendLine("  PARSENAME(CONVERT(varchar, CONVERT(money, BiayaTindakan), 1), 2) AS [Biaya Tindakan],")
            queryDetail.AppendLine("  PARSENAME(CONVERT(varchar, CONVERT(money, DiscPersenTindakan), 1), 2) AS DiscTindakan,")
            queryDetail.AppendLine("  PARSENAME(CONVERT(varchar, CONVERT(money, DiscTindakan), 1), 2) AS DiscNilai,")
            queryDetail.AppendLine("  PARSENAME(CONVERT(varchar, CONVERT(money, NettBayar), 1), 2) AS NettBayar")
            queryDetail.AppendLine("FROM TransaksiGigiDetail")
            queryDetail.AppendLine("WHERE DeletedDate IS NULL AND Awal = 0 AND TransGigiID = '" & Txid & "'")

            ' Set Query Bayar
            queryBayar.AppendLine("SELECT *")
            queryBayar.AppendLine("FROM TransaksiGigiBayar")
            queryBayar.AppendLine("WHERE TransGigiID = '" & Txid & "' AND GroupBayar IS NOT NULL")

            TextBoxNamaDokter.Text = ReadSQLNIK("SELECT DokterGigi FROM TransaksiGigi WHERE TransGigiID = '" & Txid & "' AND Nourut = '" & Turut & "'")
            txrequest.Text = "-"
        ElseIf cmbjenis.Text = "AWALPOLI" Then
            ' Set Query Detail
            queryDetail.AppendLine("SELECT")
            queryDetail.AppendLine("  TindakanID,")
            queryDetail.AppendLine("  NamaTindakan AS [Tindakan],")
            queryDetail.AppendLine("  JenisTindakan AS [Jenis],")
            queryDetail.AppendLine("  PARSENAME(CONVERT(varchar, CONVERT(money, BiayaTindakan), 1), 2) AS [Biaya Tindakan],")
            queryDetail.AppendLine("  PARSENAME(CONVERT(varchar, CONVERT(money, DiscPersenTindakan), 1), 2) AS DiscTindakan,")
            queryDetail.AppendLine("  PARSENAME(CONVERT(varchar, CONVERT(money, DiscTindakan), 1), 2) AS DiscNilai,")
            queryDetail.AppendLine("  PARSENAME(CONVERT(varchar, CONVERT(money, NettBayar), 1), 2) AS NettBayar")
            queryDetail.AppendLine("FROM TransaksiPoliDetail")
            queryDetail.AppendLine("WHERE DeletedDate IS NULL AND Awal = 1 AND TransPoliID = '" & Txid & "'")

            ' Set Query Bayar
            queryBayar.AppendLine("SELECT *")
            queryBayar.AppendLine("FROM TransaksiPoliBayarAwal")
            queryBayar.AppendLine("WHERE TransPoliID = '" & Txid & "' AND TransJenis = 'POLI'")

            TextBoxNamaDokter.Text = ReadSQLNIK("SELECT DokterPoli FROM TransaksiPoli WHERE TransPoliID = '" & Txid & "' AND Nourut = '" & Turut & "'")
            txrequest.Text = "-"
        ElseIf cmbjenis.Text = "POLI" Then
            ' Set Query Detail
            queryDetail.AppendLine("SELECT")
            queryDetail.AppendLine("  TindakanID,")
            queryDetail.AppendLine("  NamaTindakan AS [Tindakan],")
            queryDetail.AppendLine("  JenisTindakan AS [Jenis],")
            queryDetail.AppendLine("  PARSENAME(CONVERT(varchar, CONVERT(money, BiayaTindakan), 1), 2) AS [Biaya Tindakan],")
            queryDetail.AppendLine("  PARSENAME(CONVERT(varchar, CONVERT(money, DiscPersenTindakan), 1), 2) AS DiscTindakan,")
            queryDetail.AppendLine("  PARSENAME(CONVERT(varchar, CONVERT(money, DiscTindakan), 1), 2) AS DiscNilai,")
            queryDetail.AppendLine("  PARSENAME(CONVERT(varchar, CONVERT(money, NettBayar), 1), 2) AS NettBayar")
            queryDetail.AppendLine("FROM TransaksiPoliDetail")
            queryDetail.AppendLine("WHERE DeletedDate IS NULL AND Awal = 0 AND TransPoliID = '" & Txid & "'")

            ' Set Query Bayar
            queryBayar.AppendLine("SELECT *")
            queryBayar.AppendLine("FROM TransaksiPoliBayar")
            queryBayar.AppendLine("WHERE TransPoliID = '" & Txid & "' AND GroupBayar IS NOT NULL")

            TextBoxNamaDokter.Text = ReadSQLNIK("SELECT DokterPoli FROM TransaksiPoli WHERE TransPoliID = '" & Txid & "' AND Nourut = '" & Turut & "'")
            txrequest.Text = "-"
        ElseIf cmbjenis.Text = "LAB" Then
            ' Set Query Detail
            queryDetail.AppendLine("SELECT TindakanID, NamaTindakan AS [Tindakan], JenisTindakan AS [Jenis],")
            queryDetail.AppendLine("PARSENAME(CONVERT(varchar, CONVERT(money, BiayaTindakan), 1), 2) AS [Biaya Tindakan],")
            queryDetail.AppendLine("PARSENAME(CONVERT(varchar, CONVERT(money, DiscPersenTindakan), 1), 2) AS DiscTindakan,")
            queryDetail.AppendLine("PARSENAME(CONVERT(varchar, CONVERT(money, DiscTindakan), 1), 2) AS DiscNilai,")
            queryDetail.AppendLine("PARSENAME(CONVERT(varchar, CONVERT(money, NettBayar), 1), 2) AS NettBayar, Mesin")
            queryDetail.AppendLine("FROM TransaksiLabDetail")
            queryDetail.AppendLine("WHERE TransLabID = '" & Txid & "'")

            ' Set Query Bayar
            queryBayar.AppendLine("SELECT * FROM TransaksiLabBayar WHERE TransLabID = '" & Txid & "'")

            TextBoxNamaDokter.Text = ReadSQLNIK("SELECT DokterLab FROM TransaksiLab WHERE TransLabID = '" & Txid & "' AND Nourut='" & Turut & "'")
            txrequest.Text = ReadSQLNIK("SELECT DrNama FROM MasterDokterKirim WHERE IdKirim IN (SELECT IdKirim FROM MasterDokterTempatPraktek WHERE IdPraktek IN (SELECT DokterRequest FROM TransaksiLab WHERE TransLabID = '" & Txid & "' AND Nourut='" & Turut & "'))")
        Else
            ' Set Query Detail
            queryDetail.AppendLine("SELECT")
            queryDetail.AppendLine("  TindakanID,")
            queryDetail.AppendLine("  NamaTindakan AS [Nama Tindakan],")
            queryDetail.AppendLine("  JenisTindakan AS [Jenis],")
            queryDetail.AppendLine("  PARSENAME(CONVERT(varchar, CONVERT(money, BiayaTindakan), 1), 2) AS [Biaya Tindakan],")
            queryDetail.AppendLine("  PARSENAME(CONVERT(varchar, CONVERT(money, DiscPersenTindakan), 1), 2) AS DiscTindakan,")
            queryDetail.AppendLine("  PARSENAME(CONVERT(varchar, CONVERT(money, DiscTindakan), 1), 2) AS DiscNilai,")
            queryDetail.AppendLine("  PARSENAME(CONVERT(varchar, CONVERT(money, NettBayar), 1), 2) AS NettBayar")
            queryDetail.AppendLine("FROM TransaksiPoliDetail")
            queryDetail.AppendLine("WHERE DeletedDate IS NULL AND Awal = 0 AND TransPoliID = '" & Txid & "'")

            ' Set Query Bayar
            queryBayar.AppendLine("SELECT *")
            queryBayar.AppendLine("FROM TransaksiPoliBayar")
            queryBayar.AppendLine("WHERE TransPoliID = '" & Txid & "'")
        End If

        Tbls = ReadSQL(queryDetail.ToString())
        Tbls2 = ReadSQL(queryBayar.ToString())

        GridView2.Columns.Clear()
        GridControlTindakan.DataSource = Tbls

        txtotalbruto = 0
        txtotaldisc = 0
        txtotalpembulatan = 0
        txkembali = 0

        GridControl1.DataSource = Tbls2

        Dim totalrow As Integer = 1700

        For Each Trow As DataRow In Tbls2.Rows
            'totalrow = totalrow + 75
            txtotalbruto = txtotalbruto + Trow("JumlahBayar")
            txkembali = txkembali + Trow("Kembali")
        Next

        For Each Trow As DataRow In Tbls.Rows
            totalrow = totalrow + 75
        Next

        txtotalrow.Text = totalrow

        txtotal.Text = Splitmoney(txtotalbruto)
    End Sub

    Public Sub LoadTindakan(ByRef Tgrid As DataRowView)
        cmbjenis.Enabled = False
        butfind.Enabled = False

        txpoliid.Text = Tgrid("TransID").ToString
        dttanggal.Value = Tgrid("TglTransaksi")
        LoadPasien(Tgrid("NoRekamMedis"))
        LoadGrid(Tgrid("TransID").ToString, Tgrid("Nourut").ToString)
        LoadBayar(Tgrid("TransID").ToString, Tgrid("Nourut").ToString)

    End Sub

    Public Sub LoadBayar(ByRef Txid As String, ByRef Turut As String)
        Dim Tbls As New DataTable
        Dim queryBuilder As New StringBuilder()

        If cmbjenis.Text = "AWALGIGI" Then
            queryBuilder.AppendLine("SELECT TransGigiIDBayar AS ID, JenisBayar, NoJenisBayar, PARSENAME(CONVERT(varchar, CONVERT(money, JumlahBayar), 1), 2) AS JumlahBayar, admin")
            queryBuilder.AppendLine("FROM TransaksiGigiBayarAwal")
            queryBuilder.AppendLine("WHERE TransJenis = 'GIGI' AND TransGigiID = '" & Txid & "'")
        ElseIf cmbjenis.Text = "GIGI" Then
            queryBuilder.AppendLine("SELECT TransGigiIDBayar AS ID, JenisBayar, NoJenisBayar, PARSENAME(CONVERT(varchar, CONVERT(money, JumlahBayar), 1), 2) AS JumlahBayar, admin")
            queryBuilder.AppendLine("FROM TransaksiGigiBayar")
            queryBuilder.AppendLine("WHERE GroupBayar IS NOT NULL AND TransGigiID = '" & Txid & "'")
        ElseIf cmbjenis.Text = "AWALPOLI" Then
            queryBuilder.AppendLine("SELECT TransPoliIDBayar AS ID, JenisBayar, NoJenisBayar, PARSENAME(CONVERT(varchar, CONVERT(money, JumlahBayar), 1), 2) AS JumlahBayar, admin")
            queryBuilder.AppendLine("FROM TransaksiPoliBayarAwal")
            queryBuilder.AppendLine("WHERE TransJenis = 'POLI' AND TransPoliID = '" & Txid & "'")
        ElseIf cmbjenis.Text = "POLI" Then
            queryBuilder.AppendLine("SELECT TransPoliIDBayar AS ID, JenisBayar, NoJenisBayar, PARSENAME(CONVERT(varchar, CONVERT(money, JumlahBayar), 1), 2) AS JumlahBayar, admin")
            queryBuilder.AppendLine("FROM TransaksiPoliBayar")
            queryBuilder.AppendLine("WHERE GroupBayar IS NOT NULL AND TransPoliID = '" & Txid & "'")
        ElseIf cmbjenis.Text = "LAB" Then
            queryBuilder.AppendLine("SELECT TransLabIDBayar AS ID, JenisBayar, NoJenisBayar,")
            queryBuilder.AppendLine("PARSENAME(CONVERT(varchar, CONVERT(money, JumlahBayar), 1), 2) AS JumlahBayar, admin")
            queryBuilder.AppendLine("FROM TransaksiLabBayar")
            queryBuilder.AppendLine("WHERE TransLabID = '" & Txid & "'")
        Else
            queryBuilder.AppendLine("SELECT TransLabIDBayar AS ID, JenisBayar, NoJenisBayar, PARSENAME(CONVERT(varchar, CONVERT(money, JumlahBayar), 1), 2) AS JumlahBayar, admin")
            queryBuilder.AppendLine("FROM TransaksiLabBayar")
            queryBuilder.AppendLine("WHERE TransLabID = '-1'")
        End If

        Tbls = ReadSQL(queryBuilder.ToString())

        gridbayar.DataSource = Tbls
        GridView3.Columns("ID").Visible = False
        GridView3.Columns("admin").Visible = False

        If Tbls.Rows.Count > 0 Then
            If IsDBNull(Tbls.Rows(0)("admin")) = False Then
                txadmin.Text = Tbls.Rows(0)("admin").ToString
            End If
        End If
    End Sub

    Public Sub LoadPasien(ByRef Txid As String)
        Dim Tcust As DataTable = ReadSQL("SELECT * FROM MasterPasien WHERE NoRekamMedis = '" & Txid & "'")
        Dim Rcust As DataRow = Tcust.Rows(0)
        TextBoxNomorRM.Text = Txid
        txcustnama.Text = Rcust("Nama")
        dtcusttgllhr.Value = Rcust("TglLahir")
        txumur.Text = Umur(dtcusttgllhr.Value)
        txcustlp.Text = Rcust("JenisKelamin")
    End Sub

    Private Sub butfind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butfind.Click
        If cmbjenis.Text <> "" Then
            Dim queryBuilder As New StringBuilder()

            If cmbjenis.Text = "AWALGIGI" Then
                queryBuilder.AppendLine("SELECT a.TransGigiID AS TransID, a.NoUrut, a.TglGigi AS TglTransaksi, b.NoRekamMedis, b.Nama, a.[Status]")
                queryBuilder.AppendLine("FROM TransaksiGigi a")
                queryBuilder.AppendLine("     LEFT JOIN MasterPasien b ON a.IDInternet = b.NoRekamMedis")
                queryBuilder.AppendLine("WHERE a.deleted <> 1 AND TransGigiID IN(SELECT TransGigiID FROM TransaksiGigiBayarAwal WHERE TransJenis='GIGI')")
                queryBuilder.AppendLine("ORDER BY a.TransGigiID DESC, a.NoUrut, a.TglGigi")
            ElseIf cmbjenis.Text = "GIGI" Then
                queryBuilder.AppendLine("SELECT a.TransGigiID AS TransID, a.NoUrut, a.TglGigi AS TglTransaksi, b.NoRekamMedis, b.Nama, a.[Status]")
                queryBuilder.AppendLine("FROM TransaksiGigi a")
                queryBuilder.AppendLine("     LEFT JOIN MasterPasien b ON a.IDInternet = b.NoRekamMedis")
                queryBuilder.AppendLine("WHERE a.deleted <> 1 AND TransGigiID IN(SELECT TransGigiID FROM TransaksiGigiBayar WHERE GroupBayar IS NOT NULL)")
                queryBuilder.AppendLine("ORDER BY a.TransGigiID DESC, a.NoUrut, a.TglGigi")
            ElseIf cmbjenis.Text = "AWALPOLI" Then
                queryBuilder.AppendLine("SELECT a.TransPoliID AS TransID, a.NoUrut, a.TglPoli AS TglTransaksi, b.NoRekamMedis, b.Nama, a.[Status]")
                queryBuilder.AppendLine("FROM TransaksiPoli a")
                queryBuilder.AppendLine("     LEFT JOIN MasterPasien b ON a.IDInternet = b.NoRekamMedis")
                queryBuilder.AppendLine("WHERE a.deleted <> 1 AND TransPoliID IN(SELECT TransPoliID FROM TransaksiPoliBayarAwal WHERE TransJenis='POLI')")
                queryBuilder.AppendLine("ORDER BY a.TransPoliID DESC, a.NoUrut, a.TglPoli")
            ElseIf cmbjenis.Text = "POLI" Then
                queryBuilder.AppendLine("SELECT a.TransPoliID AS TransID, a.NoUrut, a.TglPoli AS TglTransaksi, b.NoRekamMedis, b.Nama, a.[Status]")
                queryBuilder.AppendLine("FROM TransaksiPoli a")
                queryBuilder.AppendLine("     LEFT JOIN MasterPasien b ON a.IDInternet = b.NoRekamMedis")
                queryBuilder.AppendLine("WHERE a.deleted <> 1 AND TransPoliID IN(SELECT TransPoliID FROM TransaksiPoliBayar WHERE GroupBayar IS NOT NULL)")
                queryBuilder.AppendLine("ORDER BY a.TransPoliID DESC, a.NoUrut, a.TglPoli")
            ElseIf cmbjenis.Text = "LAB" Then
                queryBuilder.AppendLine("SELECT a.TransLabID AS TransID, a.NoUrut, a.TglLab AS TglTransaksi, b.NoRekamMedis, b.Nama, a.[Status], a.CreateBy AS 'Admin'")
                queryBuilder.AppendLine("FROM TransaksiLab a")
                queryBuilder.AppendLine("LEFT JOIN MasterPasien b ON a.IDInternet = b.NoRekamMedis")
                queryBuilder.AppendLine("WHERE a.Status IN ('CHECK', 'CHECK2', 'CETAK', 'CLOSED', 'TAKEIT') AND a.deleted <> 1")
                queryBuilder.AppendLine("ORDER BY a.TransLabID DESC, a.NoUrut, a.TglLab")
            End If

            Find.Show()
            Find.Query(queryBuilder.ToString(), "", "FindKwitansi", 2)
        Else

            MsgBox("Pilih jenis Transaksi terlebih dahulu")
        End If
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        SetClear()
    End Sub

    Private Sub Kwitansi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        SetFormHeightWeight(Me, 0.95, 0.8)
        NewToolStripMenuItem.PerformClick()
    End Sub

    Function CreateTable() As DataTable
        Dim Thasil As New DataTable

        insertRowToTbls(Thasil, "Typstring", "TindakanID")
        insertRowToTbls(Thasil, "Typstring", "Tindakan")
        insertRowToTbls(Thasil, "Typstring", "Jenis")
        insertRowToTbls(Thasil, "typefloat", "Biaya Tindakan")
        insertRowToTbls(Thasil, "typefloat", "DiscTindakan")
        insertRowToTbls(Thasil, "typefloat", "DiscNilai")
        insertRowToTbls(Thasil, "typefloat", "NettBayar")
        insertRowToTbls(Thasil, "typstring", "Registrasi")
        insertRowToTbls(Thasil, "typstring", "Nama")
        insertRowToTbls(Thasil, "typstring", "Umur")
        insertRowToTbls(Thasil, "typstring", "Alamat")
        insertRowToTbls(Thasil, "typstring", "Tanggal")
        insertRowToTbls(Thasil, "typstring", "NoTransaksi")
        insertRowToTbls(Thasil, "typstring", "DrPengirim")
        insertRowToTbls(Thasil, "typstring", "StatusAmbil")
        insertRowToTbls(Thasil, "typstring", "lblDokter")
        insertRowToTbls(Thasil, "typstring", "lbltitikDokter")
        insertRowToTbls(Thasil, "typstring", "lblStatusAmbil")
        insertRowToTbls(Thasil, "typstring", "lbltitikStatusAmbil")

        For Each Tcol As DataColumn In Thasil.Columns
            Tcol.ReadOnly = True
        Next

        Return Thasil
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Jeniscetak As String = Utility.GetConfig("Jeniscetak")
        Dim NewHeader As DataTable = CreateTable()

        Report = New XtraReport

        If Jeniscetak = "Struk" Then
            Report = XtraReport.FromFile(Application.StartupPath + "\reports\PrintTindakanCopiedStruk.repx", True)
        Else
            Report = XtraReport.FromFile(Application.StartupPath + "\reports\PrintTindakanCopied.repx", True)
            'Report = XtraReport.FromFile(Application.StartupPath + "\reports\PrintTindakanKop.repx", True)
        End If

        Dim Ttemp As New DataTable
        Dim Thasil As New DataTable
        Thasil = GridControlTindakan.DataSource
        Select Case cmbjenis.Text
            Case "POLI"
                Ttemp = ReadSQL("SELECT * FROM TransaksiPoliBayar WHERE TransPoliID='" & txpoliid.Text & "'")
            Case "GIGI"
                Ttemp = ReadSQL("SELECT * FROM TransaksiGigiBayar WHERE TransGigiID='" & txpoliid.Text & "'")
            Case "LAB"
                Ttemp = ReadSQL("SELECT * FROM TransaksiLabBayar WHERE TransLabID='" & txpoliid.Text & "'")
            Case "AWALPOLI"
                Ttemp = ReadSQL("SELECT * FROM TransaksiPoliBayarAwal WHERE TransPoliID='" & txpoliid.Text & "' and TransJenis='POLI'")
            Case "AWALGIGI"
                Ttemp = ReadSQL("SELECT * FROM TransaksiGigiBayarAwal WHERE TransGigiID = '" & txpoliid.Text & "' AND TransJenis = 'GIGI'")
        End Select

        NewHeader.Rows.Clear()
        For Each TrowNewHeader As DataRow In Thasil.Rows
            Dim Tnew As DataRow = NewHeader.NewRow
            Tnew("TindakanID") = TrowNewHeader("TindakanID")

            'If cmbjenis.Text = "LAB" Or cmbjenis.Text = "GIGI" Then
            '    Tnew("Tindakan") = TrowNewHeader("Tindakan")
            'Else
            '    Tnew("Tindakan") = TrowNewHeader("Nama")
            'End If

            Tnew("Tindakan") = TrowNewHeader("Tindakan")

            Tnew("Jenis") = TrowNewHeader("Jenis")
            Tnew("Biaya Tindakan") = TrowNewHeader("Biaya Tindakan")
            Tnew("DiscTindakan") = TrowNewHeader("DiscTindakan")
            Tnew("DiscNilai") = TrowNewHeader("DiscNilai")
            Tnew("NettBayar") = TrowNewHeader("NettBayar")
            Tnew("Registrasi") = TextBoxNomorRM.Text

            Dim tblsPasien As DataTable = ReadSQL("SELECT Nama + ' / (' + JenisKelamin + ')' AS 'Nama', YEAR(TglLahir) AS 'TahunLahir', MONTH(TglLahir) AS 'BulanLahir', DAY(TglLahir) AS 'TanggalLahir', " & _
                                                          "CONVERT(VARCHAR(11),TglLahir,106) AS 'TanggalLengkap', DomisiliAlamat AS 'Alamat' " & _
                                                          "FROM MasterPasien WHERE NoRekamMedis = '" & TextBoxNomorRM.Text & "'")
            Dim TrowPasien As DataRow = tblsPasien.Rows(0)

            Tnew("Nama") = TrowPasien("Nama")
            Dim Tdate As Date = DateSerial(TrowPasien("TahunLahir"), TrowPasien("BulanLahir"), TrowPasien("TanggalLahir"))
            Tnew("Umur") = TrowPasien("TanggalLengkap") & " / " & Umur(Tdate.Date)
            Tnew("Alamat") = TrowPasien("Alamat")
            Tnew("Tanggal") = Format(dttanggal.Value, "dd-MMM-yyyy")
            Tnew("NoTransaksi") = TextBoxNomorTransaksi.Text + " (" + txpoliid.Text + ")"
            If cmbjenis.Text = "LAB" Then
                Tnew("DrPengirim") = txrequest.Text
                Tnew("StatusAmbil") = ReadSQLNIK("select CaraAmbil from TransaksiLab WHERE TransLabID='" & txpoliid.Text & "'")
                Tnew("lblDokter") = "Dr. Pengirim"
                Tnew("lblStatusAmbil") = "Status Ambil"
                Tnew("lbltitikDokter") = ":"
                Tnew("lbltitikStatusAmbil") = ":"
            Else
                Tnew("DrPengirim") = TextBoxNamaDokter.Text
                Tnew("StatusAmbil") = ""
                Tnew("lblDokter") = "Dr. Pelaksana"
                Tnew("lblStatusAmbil") = ""
                Tnew("lbltitikDokter") = ":"
                Tnew("lbltitikStatusAmbil") = ""
            End If
            NewHeader.Rows.Add(Tnew)
        Next

        Report.DataSource = NewHeader
        If Jeniscetak = "Struk" Then
            Report.Bands.Item(BandKind.TopMargin).Controls("txalamat").Text = Utility.GetConfig("CompanyAddr")
            Report.Bands.Item(BandKind.TopMargin).Controls("txtelfon").Text = Utility.GetConfig("CompanyContact")
            Report.Bands.Item(BandKind.TopMargin).Controls("txfaskes").Text = Utility.GetConfig("CompanyFaskes")
        End If

        Report.Bands.Item(BandKind.ReportFooter).Controls("lblBayar").Text = Splitmoney(txtotalbruto + txkembali)
        Report.Bands.Item(BandKind.ReportFooter).Controls("lblKembalian").Text = Splitmoney(txkembali)
        Report.Bands.Item(BandKind.BottomMargin).Controls("lbladmin").Text = userInput
        Report.Bands.Item(BandKind.BottomMargin).Controls("lbltanggalcetak").Text = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mmm:ss")

        For i As Integer = 1 To Ttemp.Rows.Count
            Dim Trow As DataRow = Ttemp.Rows(i - 1)
            Dim Tket As String = "bayar" & i
            Report.Bands.Item(BandKind.ReportFooter).Controls(Tket).Visible = True
            If Trow("JenisBayar") = "TAGIHAN" Or Trow("JenisBayar") = "TUNAI" Then
                Report.Bands.Item(BandKind.ReportFooter).Controls(Tket).Text = Trow("JenisBayar") & " - Jumlah : " & Splitmoney(Trow("JumlahBayar")) & " (" & Trow("NoJenisBayar").ToString & ")"
            Else
                Report.Bands.Item(BandKind.ReportFooter).Controls(Tket).Text = Trow("JenisBayar") & " - No Kartu : " & "*".PadRight(Len(Trow("NoJenisBayar")) - 3) & Strings.Right(Trow("NoJenisBayar"), 3) & Trow("kartu") & " - Jumlah : " & Splitmoney(Trow("JumlahBayar"))
            End If
        Next

        If Jeniscetak = "Struk" Then
            Report.PageHeight = txtotalrow.Text
        End If

        'Report.RunDesigner()
        Report.ShowPreview()
        'Report.PrintDialog()

        '===============================================================================
        'Testing 
        'Dim Tbool As Boolean = False
        'If Utility.GetConfig("Email") = "No" Then
        '    Tbool = False
        'End If

        'If Tbool = True Then
        '    If CheckSQL("select CaraAmbil from TransaksiLab WHERE NoUrut='" & txnourut.Text & "' and CaraAmbil like '%email%'") = True Then
        '        If MsgBox("Apakah anda ingin mengirim invoice ke email pasien?", MsgBoxStyle.YesNo, "Question.") = MsgBoxResult.Yes Then
        '            Report = New XtraReport

        '            Report = XtraReport.FromFile(Application.StartupPath + "\reports\PrintTindakan.repx", True)
        '            Report.DataSource = NewHeader

        '            Report.Bands.Item(BandKind.ReportFooter).Controls("lblBayar").Text = Splitmoney(txtotalbruto + txkembali)
        '            Report.Bands.Item(BandKind.ReportFooter).Controls("lblKembalian").Text = Splitmoney(txkembali)
        '            Report.Bands.Item(BandKind.BottomMargin).Controls("lbladmin").Text = userInput
        '            Report.Bands.Item(BandKind.BottomMargin).Controls("lbltanggalcetak").Text = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mmm:ss")

        '            For i As Integer = 1 To Ttemp.Rows.Count
        '                Dim Trow As DataRow = Ttemp.Rows(i - 1)
        '                Dim Tket As String = "bayar" & i
        '                Report.Bands.Item(BandKind.ReportFooter).Controls(Tket).Visible = True
        '                If Trow("JenisBayar") = "TAGIHAN" Or Trow("JenisBayar") = "TUNAI" Then
        '                    Report.Bands.Item(BandKind.ReportFooter).Controls(Tket).Text = Trow("JenisBayar") & " - Jumlah : " & Splitmoney(Trow("JumlahBayar")) & " (" & Trow("NoJenisBayar").ToString & ")"
        '                Else
        '                    Report.Bands.Item(BandKind.ReportFooter).Controls(Tket).Text = Trow("JenisBayar") & " - No Kartu : " & "*".PadRight(Len(Trow("NoJenisBayar")) - 3) & Strings.Right(Trow("NoJenisBayar"), 3) & Trow("kartu") & " - Jumlah : " & Splitmoney(Trow("JumlahBayar"))
        '                End If
        '            Next

        '            Dim NameFile As String = txnourut.Text & "_Invoice_Laboratorium"
        '            Dim filepath As String = "FileDownload\" & NameFile & ".pdf"

        '            If File.Exists(filepath) Then
        '                If MsgBox("Hasil sudah pernah dikirim ke email tersebut, apakah tetap dilanjutkan?", MsgBoxStyle.YesNo, "Question.") = MsgBoxResult.No Then
        '                    MsgBox("Batal mengirimkan email.", MsgBoxStyle.Exclamation, "Warning!")
        '                    Exit Sub
        '                End If
        '                My.Computer.FileSystem.DeleteFile("FileDownload\Invoice\" & NameFile & ".pdf")
        '            End If

        '            Report.CreatePdfDocument("FileDownload\Invoice\" & NameFile & ".pdf")

        '            thread = New System.Threading.Thread(AddressOf sendingemail)
        '            thread.Start()
        '        End If
        '    End If
        'End If
        '===============================================================================

    End Sub

    Public Sub sendingemail()
        Try
            Dim email As String = ReadSQLNIK("select email from MasterCustomer WHERE nomitra in (select IDInternet from TransaksiLab where NoUrut='" & TextBoxNomorTransaksi.Text & "')")
            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential("info@cahayamedika.co.id", "cahayamedika2020!")
            Smtp_Server.Port = 587
            Smtp_Server.EnableSsl = True
            Smtp_Server.Host = "smtp.gmail.com"

            e_mail = New MailMessage()
            e_mail.From = New MailAddress("info@cahayamedika.co.id")
            e_mail.To.Add("" & email.Trim & "")
            e_mail.Subject = "Invoice Laboratorium (" & TextBoxNomorTransaksi.Text & ")"
            e_mail.IsBodyHtml = False
            e_mail.Body = "Kepada Yth." & vbCr & vbLf + "" & _
              "Customer Cahaya Diagnostic Centre" & vbCr & vbLf & vbCr & vbLf + "" & _
              "Kami mengucapkan terima kasih atas kepercayaan Bapak/Ibu/Saudara/i sudah melakukan pemeriksaan di Laboratorium Cahaya Diagnostic Centre. Berikut ini kami lampirkan hasil pemeriksaan laboratorium anda." & vbCr & vbLf & vbCr & vbLf + "" & _
              "Silahkan menghubungi kami di nomor 081230885004 (WA/Phone) atau email ke cahayadiagnosticcentre@gmail.com untuk konsultasi lebih lanjut." & vbCr & vbLf & vbCr & vbLf + "" & _
              "Kami menyampaikan beberapa hal yang perlu diperhatikan oleh saudara/i, antara lain:" & vbCr & vbLf + "" & _
              "1. Tetap menjaga jarak dengan orang lain (Physical Distancing)." & vbCr & vbLf + "" & _
              "2. Selalu menggunakan masker saat keluar dari rumah." & vbCr & vbLf + "" & _
              "3. Rajin mencuci & menjaga kebersihan tangan." & vbCr & vbLf + "" & _
              "4. Makan makanan yang bergizi & bila perlu minum suplemen atau vitamin." & vbCr & vbLf + "" & _
              "5. Etika batuk yang baik & benar." & vbCr & vbLf & vbCr & vbLf + "" & _
              "Best regards," & vbCr & vbLf & vbCr & vbLf + "" & _
              "Laboratorium Cahaya Diagnostic Centre."
            e_mail.Attachments.Add(New Attachment("FileDownload\Invoice\" & TextBoxNomorTransaksi.Text & "_Invoice_Laboratorium" & ".pdf"))
            Smtp_Server.Send(e_mail)

            MsgBox("Berhasil mengirim email ke " & email.Trim & ".", MsgBoxStyle.Information, "Success!")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        Button1.PerformClick()
    End Sub

    Private Sub cmbjenis_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbjenis.SelectedIndexChanged
        butfind.PerformClick()
    End Sub

    Private Sub ButtonCetakInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCetakInvoice.Click
        Dim Jeniscetak As String = Utility.GetConfig("Jeniscetak")

        Dim tblTindakan As DataTable = GridControlTindakan.DataSource
        Dim NewHeader As DataTable = CreateTable()

        Report = New XtraReport

        If Jeniscetak = "Struk" Then
            Report = XtraReport.FromFile(Application.StartupPath + "\reports\PrintTindakanCopiedStruk.repx", True)
        Else
            Report = XtraReport.FromFile(Application.StartupPath + "\reports\Resource\PrintInvoiceTransaksiKop.repx", True)
            'Report = XtraReport.FromFile(Application.StartupPath + "\reports\PrintTindakanCopied.repx", True)
            'Report = XtraReport.FromFile(Application.StartupPath + "\reports\PrintTindakanKop.repx", True)
        End If

        ' Set Data Pasien
        Dim tblsPasien As DataTable = ReadSQL("SELECT NoRekamMedis, Nama + ' / (' + JenisKelamin + ')' AS 'Nama', YEAR(TglLahir) AS 'TahunLahir', MONTH(TglLahir) AS 'BulanLahir', DAY(TglLahir) AS 'TanggalLahir', " & _
                                                  "CONVERT(VARCHAR(11),TglLahir,106) AS 'TanggalLengkap', DomisiliAlamat AS 'Alamat' " & _
                                                  "FROM MasterPasien WHERE NoRekamMedis = '" & TextBoxNomorRM.Text & "'")
        Dim TrowPasien As DataRow = tblsPasien.Rows(0)
        Dim Tdate As Date = DateSerial(TrowPasien("TahunLahir"), TrowPasien("BulanLahir"), TrowPasien("TanggalLahir"))

        NewHeader.Rows.Clear()
        For Each rowTindakan As DataRow In tblTindakan.Rows
            If CheckBoxStatusPembelianPaket.Checked = False Then
                Dim Tnew As DataRow = NewHeader.NewRow
                Tnew("TindakanID") = rowTindakan("TindakanID")
                Tnew("Tindakan") = rowTindakan("Tindakan")
                Tnew("Jenis") = rowTindakan("Jenis")
                Tnew("Biaya Tindakan") = rowTindakan("Biaya Tindakan")
                Tnew("DiscTindakan") = rowTindakan("DiscTindakan")
                Tnew("DiscNilai") = rowTindakan("DiscNilai")
                Tnew("NettBayar") = rowTindakan("NettBayar")

                Tnew("Registrasi") = TrowPasien("NoRekamMedis")
                Tnew("Nama") = TrowPasien("Nama")
                Tnew("Umur") = TrowPasien("TanggalLengkap") & " / " & Umur(Tdate.Date)
                Tnew("Alamat") = TrowPasien("Alamat")
                Tnew("Tanggal") = Format(DateAndTime.Now, "dd-MMM-yyyy")
                Tnew("NoTransaksi") = TextBoxNomorTransaksi.Text
                Tnew("DrPengirim") = TextBoxNamaDokter.Text
                Tnew("StatusAmbil") = ""
                Tnew("lblDokter") = "Dr. Pelaksana"
                Tnew("lblStatusAmbil") = ""
                Tnew("lbltitikDokter") = ":"
                Tnew("lbltitikStatusAmbil") = ""
                NewHeader.Rows.Add(Tnew)
            ElseIf CheckBoxStatusPembelianPaket.Checked = True Then
                Dim Tnew As DataRow = NewHeader.NewRow
                Dim hargaAwal As Decimal = 0
                If Not IsDBNull(rowTindakan("Biaya Tindakan")) AndAlso rowTindakan("Biaya Tindakan").ToString.Trim <> "" Then
                    hargaAwal = Convert.ToDecimal(rowTindakan("Biaya Tindakan"))
                End If

                Dim diskon As Decimal = 0
                If Not IsDBNull(rowTindakan("DiscNilai")) AndAlso rowTindakan("DiscNilai").ToString.Trim <> "" Then
                    diskon = Convert.ToDecimal(rowTindakan("DiscNilai"))
                End If

                'Dim hargaAwal As Decimal = Convert.ToDecimal(rowTindakan("Biaya Tindakan"))
                'Dim diskon As Decimal = Convert.ToDecimal(rowTindakan("DiscNilai"))

                ' Menghitung persentase diskon berdasarkan harga awal dan diskon
                Dim discTindakan As Decimal
                If hargaAwal > 0 Then
                    discTindakan = (diskon / hargaAwal) * 100
                Else
                    discTindakan = 0 ' Menghindari pembagian dengan nol
                End If

                Tnew("TindakanID") = rowTindakan("TindakanID").ToString()
                Tnew("Tindakan") = rowTindakan("Tindakan")
                Tnew("Jenis") = rowTindakan("Jenis")
                Tnew("Biaya Tindakan") = rowTindakan("Biaya Tindakan")
                Tnew("DiscTindakan") = discTindakan
                Tnew("DiscNilai") = rowTindakan("DiscNilai")
                Tnew("NettBayar") = rowTindakan("NettBayar")

                Tnew("Registrasi") = TrowPasien("NoRekamMedis")
                Tnew("Nama") = TrowPasien("Nama")
                Tnew("Umur") = TrowPasien("TanggalLengkap") & " / " & Umur(Tdate.Date)
                Tnew("Alamat") = TrowPasien("Alamat")
                Tnew("Tanggal") = Format(DateAndTime.Now, "dd-MMM-yyyy")
                Tnew("NoTransaksi") = TextBoxNomorTransaksi.Text
                Tnew("DrPengirim") = TextBoxNamaDokter.Text
                Tnew("StatusAmbil") = ""
                Tnew("lblDokter") = "Dr. Pelaksana"
                Tnew("lblStatusAmbil") = ""
                Tnew("lbltitikDokter") = ":"
                Tnew("lbltitikStatusAmbil") = ""
                NewHeader.Rows.Add(Tnew)
            End If
        Next

        Report = New XtraReport

        If Jeniscetak = "Struk" Then
            Report = XtraReport.FromFile(Application.StartupPath + "\reports\PrintTindakanStruk.repx", True)
        Else
            Report = XtraReport.FromFile(Application.StartupPath + "\reports\Resource\PrintInvoiceTransaksi.repx", True)
        End If

        Report.DataSource = NewHeader

        If Jeniscetak = "Struk" Then
            Report.Bands.Item(BandKind.TopMargin).Controls("txalamat").Text = Utility.GetConfig("CompanyAddr")
            Report.Bands.Item(BandKind.TopMargin).Controls("txtelfon").Text = Utility.GetConfig("CompanyContact")
            Report.Bands.Item(BandKind.TopMargin).Controls("txfaskes").Text = Utility.GetConfig("CompanyFaskes")
        End If

        'Report.Bands.Item(BandKind.ReportFooter).Controls("lblBayar").Text = Splitmoney(Math.Abs(CInt(txtotal.Text) + CInt(TextBoxTotalBayar.Text)))
        'Report.Bands.Item(BandKind.ReportFooter).Controls("lblKembalian").Text = Splitmoney(Math.Abs(CInt(txtotal.Text)))
        Report.Bands.Item(BandKind.BottomMargin).Controls("lbladmin").Text = userInput
        Report.Bands.Item(BandKind.BottomMargin).Controls("lbltanggalcetak").Text = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mmm:ss")

        Dim Ttemp As New DataTable

        Select Case cmbjenis.Text
            Case "POLI"
                Ttemp = ReadSQL("SELECT * FROM TransaksiPoliBayar WHERE TransPoliID='" & txpoliid.Text & "'")
            Case "GIGI"
                Ttemp = ReadSQL("SELECT * FROM TransaksiGigiBayar WHERE TransGigiID='" & txpoliid.Text & "'")
            Case "LAB"
                Ttemp = ReadSQL("SELECT * FROM TransaksiLabBayar WHERE TransLabID='" & txpoliid.Text & "'")
            Case "AWALPOLI"
                Ttemp = ReadSQL("SELECT * FROM TransaksiPoliBayarAwal WHERE TransPoliID='" & txpoliid.Text & "' and TransJenis='POLI'")
            Case "AWALGIGI"
                Ttemp = ReadSQL("SELECT * FROM TransaksiGigiBayarAwal WHERE TransGigiID = '" & txpoliid.Text & "' AND TransJenis = 'GIGI'")
        End Select

        If Ttemp.Rows.Count > 1 Then
            For i As Integer = 1 To Ttemp.Rows.Count
                Dim Trow As DataRow = Ttemp.Rows(i - 1)
                Dim Tket As String = "bayar" & i
                Report.Bands.Item(BandKind.ReportFooter).Controls(Tket).Visible = True
                If Trow("JenisBayar") = "TAGIHAN" Or Trow("JenisBayar") = "TUNAI" Then
                    Report.Bands.Item(BandKind.ReportFooter).Controls(Tket).Text = Trow("JenisBayar") & " - Jumlah : " & Splitmoney(Trow("JumlahBayar"))
                Else
                    Report.Bands.Item(BandKind.ReportFooter).Controls(Tket).Text = Trow("JenisBayar") & " - No Kartu : " & "*".PadRight(Len(Trow("NoJenisBayar")) - 3) & Strings.Right(Trow("NoJenisBayar"), 3) & Trow("kartu") & " - Jumlah : " & Splitmoney(Trow("JumlahBayar"))
                End If
            Next
        Else
            Report.Bands.Item(BandKind.ReportFooter).Controls("bayar1").Text = "-"
        End If

        ' Set QR (Report)
        If CheckBoxStatusPembelianPaket.Checked = True Then
            Dim Generator As New MessagingToolkit.Barcode.BarcodeEncoder
            Dim qrImage As Bitmap = New Bitmap(Generator.Encode(MessagingToolkit.Barcode.BarcodeFormat.QRCode, TextBoxKeteranganVoucher.Text))

            Dim pictureBox As XRPictureBox = CreateXRPictureBox(qrImage, 0, 0, 175, 100)
            Dim panelQR As XRPanel = CType(Report.Bands(BandKind.ReportFooter).Controls("xrPanelQR"), XRPanel)

            ' Add pictureBox
            panelQR.Controls.Add(pictureBox)

            ' Set Visible
            panelQR.Visible = True
            Report.Bands.Item(BandKind.ReportFooter).Controls("xrLabelKodeVoucher").Visible = True
        End If

        'Report.RunDesigner()
        Report.ShowPreview()
        'Report.Print()

        ' ==================================================================================
        ' ==================================================================================



        'Dim Ttemp As New DataTable
        'Dim Thasil As New DataTable
        'Thasil = GridControlTindakan.DataSource
        'Select Case cmbjenis.Text
        '    Case "POLI"
        '        Ttemp = ReadSQL("SELECT * FROM TransaksiPoliBayar WHERE TransPoliID='" & txpoliid.Text & "'")
        '    Case "GIGI"
        '        Ttemp = ReadSQL("SELECT * FROM TransaksiGigiBayar WHERE TransGigiID='" & txpoliid.Text & "'")
        '    Case "LAB"
        '        Ttemp = ReadSQL("SELECT * FROM TransaksiLabBayar WHERE TransLabID='" & txpoliid.Text & "'")
        '    Case "AWALPOLI"
        '        Ttemp = ReadSQL("SELECT * FROM TransaksiPoliBayarAwal WHERE TransPoliID='" & txpoliid.Text & "' and TransJenis='POLI'")
        '    Case "AWALGIGI"
        '        Ttemp = ReadSQL("SELECT * FROM TransaksiGigiBayarAwal WHERE TransGigiID = '" & txpoliid.Text & "' AND TransJenis = 'GIGI'")
        'End Select

        'NewHeader.Rows.Clear()
        'For Each TrowNewHeader As DataRow In Thasil.Rows
        '    Dim Tnew As DataRow = NewHeader.NewRow
        '    Tnew("TindakanID") = TrowNewHeader("TindakanID")
        '    Tnew("Tindakan") = TrowNewHeader("Tindakan")

        '    Tnew("Jenis") = TrowNewHeader("Jenis")
        '    Tnew("Biaya Tindakan") = TrowNewHeader("Biaya Tindakan")
        '    Tnew("DiscTindakan") = TrowNewHeader("DiscTindakan")
        '    Tnew("DiscNilai") = TrowNewHeader("DiscNilai")
        '    Tnew("NettBayar") = TrowNewHeader("NettBayar")
        '    Tnew("Registrasi") = TextBoxNomorRM.Text

        '    Dim tblsPasien As DataTable = ReadSQL("SELECT Nama + ' / (' + JenisKelamin + ')' AS 'Nama', YEAR(TglLahir) AS 'TahunLahir', MONTH(TglLahir) AS 'BulanLahir', DAY(TglLahir) AS 'TanggalLahir', " & _
        '                                                  "CONVERT(VARCHAR(11),TglLahir,106) AS 'TanggalLengkap', DomisiliAlamat AS 'Alamat' " & _
        '                                                  "FROM MasterPasien WHERE NoRekamMedis = '" & TextBoxNomorRM.Text & "'")
        '    Dim TrowPasien As DataRow = tblsPasien.Rows(0)

        '    Tnew("Nama") = TrowPasien("Nama")
        '    Dim Tdate As Date = DateSerial(TrowPasien("TahunLahir"), TrowPasien("BulanLahir"), TrowPasien("TanggalLahir"))
        '    Tnew("Umur") = TrowPasien("TanggalLengkap") & " / " & Umur(Tdate.Date)
        '    Tnew("Alamat") = TrowPasien("Alamat")
        '    Tnew("Tanggal") = Format(dttanggal.Value, "dd-MMM-yyyy")
        '    Tnew("NoTransaksi") = TextBoxNomorTransaksi.Text + " (" + txpoliid.Text + ")"
        '    If cmbjenis.Text = "LAB" Then
        '        Tnew("DrPengirim") = txrequest.Text
        '        Tnew("StatusAmbil") = ReadSQLNIK("select CaraAmbil from TransaksiLab WHERE TransLabID='" & txpoliid.Text & "'")
        '        Tnew("lblDokter") = "Dr. Pengirim"
        '        Tnew("lblStatusAmbil") = "Status Ambil"
        '        Tnew("lbltitikDokter") = ":"
        '        Tnew("lbltitikStatusAmbil") = ":"
        '    Else
        '        Tnew("DrPengirim") = TextBoxNamaDokter.Text
        '        Tnew("StatusAmbil") = ""
        '        Tnew("lblDokter") = "Dr. Pelaksana"
        '        Tnew("lblStatusAmbil") = ""
        '        Tnew("lbltitikDokter") = ":"
        '        Tnew("lbltitikStatusAmbil") = ""
        '    End If
        '    NewHeader.Rows.Add(Tnew)
        'Next

        'Report.DataSource = NewHeader
        'If Jeniscetak = "Struk" Then
        '    Report.Bands.Item(BandKind.TopMargin).Controls("txalamat").Text = Utility.GetConfig("CompanyAddr")
        '    Report.Bands.Item(BandKind.TopMargin).Controls("txtelfon").Text = Utility.GetConfig("CompanyContact")
        '    Report.Bands.Item(BandKind.TopMargin).Controls("txfaskes").Text = Utility.GetConfig("CompanyFaskes")
        'End If

        'Report.Bands.Item(BandKind.ReportFooter).Controls("lblBayar").Text = Splitmoney(txtotalbruto + txkembali)
        'Report.Bands.Item(BandKind.ReportFooter).Controls("lblKembalian").Text = Splitmoney(txkembali)
        'Report.Bands.Item(BandKind.BottomMargin).Controls("lbladmin").Text = userInput
        'Report.Bands.Item(BandKind.BottomMargin).Controls("lbltanggalcetak").Text = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mmm:ss")

        'For i As Integer = 1 To Ttemp.Rows.Count
        '    Dim Trow As DataRow = Ttemp.Rows(i - 1)
        '    Dim Tket As String = "bayar" & i
        '    Report.Bands.Item(BandKind.ReportFooter).Controls(Tket).Visible = True
        '    If Trow("JenisBayar") = "TAGIHAN" Or Trow("JenisBayar") = "TUNAI" Then
        '        Report.Bands.Item(BandKind.ReportFooter).Controls(Tket).Text = Trow("JenisBayar") & " - Jumlah : " & Splitmoney(Trow("JumlahBayar")) & " (" & Trow("NoJenisBayar").ToString & ")"
        '    Else
        '        Report.Bands.Item(BandKind.ReportFooter).Controls(Tket).Text = Trow("JenisBayar") & " - No Kartu : " & "*".PadRight(Len(Trow("NoJenisBayar")) - 3) & Strings.Right(Trow("NoJenisBayar"), 3) & Trow("kartu") & " - Jumlah : " & Splitmoney(Trow("JumlahBayar"))
        '    End If
        'Next

        'If Jeniscetak = "Struk" Then
        '    Report.PageHeight = txtotalrow.Text
        'End If

        'Report.RunDesigner()
        'Report.ShowPreview()
        'Report.PrintDialog()

        '===============================================================================
        'Testing 
        'Dim Tbool As Boolean = False
        'If Utility.GetConfig("Email") = "No" Then
        '    Tbool = False
        'End If

        'If Tbool = True Then
        '    If CheckSQL("select CaraAmbil from TransaksiLab WHERE NoUrut='" & txnourut.Text & "' and CaraAmbil like '%email%'") = True Then
        '        If MsgBox("Apakah anda ingin mengirim invoice ke email pasien?", MsgBoxStyle.YesNo, "Question.") = MsgBoxResult.Yes Then
        '            Report = New XtraReport

        '            Report = XtraReport.FromFile(Application.StartupPath + "\reports\PrintTindakan.repx", True)
        '            Report.DataSource = NewHeader

        '            Report.Bands.Item(BandKind.ReportFooter).Controls("lblBayar").Text = Splitmoney(txtotalbruto + txkembali)
        '            Report.Bands.Item(BandKind.ReportFooter).Controls("lblKembalian").Text = Splitmoney(txkembali)
        '            Report.Bands.Item(BandKind.BottomMargin).Controls("lbladmin").Text = userInput
        '            Report.Bands.Item(BandKind.BottomMargin).Controls("lbltanggalcetak").Text = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mmm:ss")

        '            For i As Integer = 1 To Ttemp.Rows.Count
        '                Dim Trow As DataRow = Ttemp.Rows(i - 1)
        '                Dim Tket As String = "bayar" & i
        '                Report.Bands.Item(BandKind.ReportFooter).Controls(Tket).Visible = True
        '                If Trow("JenisBayar") = "TAGIHAN" Or Trow("JenisBayar") = "TUNAI" Then
        '                    Report.Bands.Item(BandKind.ReportFooter).Controls(Tket).Text = Trow("JenisBayar") & " - Jumlah : " & Splitmoney(Trow("JumlahBayar")) & " (" & Trow("NoJenisBayar").ToString & ")"
        '                Else
        '                    Report.Bands.Item(BandKind.ReportFooter).Controls(Tket).Text = Trow("JenisBayar") & " - No Kartu : " & "*".PadRight(Len(Trow("NoJenisBayar")) - 3) & Strings.Right(Trow("NoJenisBayar"), 3) & Trow("kartu") & " - Jumlah : " & Splitmoney(Trow("JumlahBayar"))
        '                End If
        '            Next

        '            Dim NameFile As String = txnourut.Text & "_Invoice_Laboratorium"
        '            Dim filepath As String = "FileDownload\" & NameFile & ".pdf"

        '            If File.Exists(filepath) Then
        '                If MsgBox("Hasil sudah pernah dikirim ke email tersebut, apakah tetap dilanjutkan?", MsgBoxStyle.YesNo, "Question.") = MsgBoxResult.No Then
        '                    MsgBox("Batal mengirimkan email.", MsgBoxStyle.Exclamation, "Warning!")
        '                    Exit Sub
        '                End If
        '                My.Computer.FileSystem.DeleteFile("FileDownload\Invoice\" & NameFile & ".pdf")
        '            End If

        '            Report.CreatePdfDocument("FileDownload\Invoice\" & NameFile & ".pdf")

        '            thread = New System.Threading.Thread(AddressOf sendingemail)
        '            thread.Start()
        '        End If
        '    End If
        'End If
        '===============================================================================

    End Sub

    Function CreateXRPictureBox(ByVal imageSignature As Image, ByVal LocX As Integer, ByVal LocY As Integer, ByVal SizeX As Integer, ByVal SizeY As Integer) As XRPictureBox
        Dim PictureBox As XRPictureBox = New XRPictureBox()
        PictureBox.Name = "QR_Hasil"
        PictureBox.Image = imageSignature
        PictureBox.Location = New Point(LocX, LocY)
        PictureBox.Size = New Size(SizeX, SizeY)
        PictureBox.Sizing = ImageSizeMode.StretchImage
        PictureBox.BorderWidth = 0

        Return PictureBox
    End Function
End Class