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

Public Class FormUploadDataOmset
    Dim thread As System.Threading.Thread

    ' Set Connection
    Private DB_Keuangan As TLcon
    Private DB_Keuangan2 As TLcon
    Private DB_Jurnal As TLcon
    Private DB_Omset As TLcon

    ' Set Variabel Private
    Private formName As String = "UPLOAD OMSET"
    Private tipeJurnal As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'tipe_jurnal'")
    Private kodeLokasiKlinik As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NoPoli'")
    Private autoJurnal As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'AutoJurnal'")
    Private userInput As String = PoliKlinik.Lbluser.Text

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

        ' Set DB Keuangan 1 (mitramed_keu)
        DB_Keuangan.Tip = serverOnline_IP
        DB_Keuangan.Tid = serverOnline_UserID
        DB_Keuangan.Tpass = serverOnline_Password
        DB_Keuangan.Tdb = Utility.GetConfig("ServerOnlineKeuangan_DB")

        ' Set DB Keuangan 2 (mitramed_keu2019)
        DB_Keuangan2.Tip = serverOnline_IP
        DB_Keuangan2.Tid = serverOnline_UserID
        DB_Keuangan2.Tpass = serverOnline_Password
        DB_Keuangan2.Tdb = Utility.GetConfig("ServerOnlineKeuangan2_DB")

        ' Set DB Jurnal
        DB_Jurnal.Tip = Utility.GetConfig("ServerJurnal_IP")
        DB_Jurnal.Tid = Utility.GetConfig("ServerJurnal_UserID")
        DB_Jurnal.Tpass = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerJurnal_Password"), "albert")
        DB_Jurnal.Tdb = Utility.GetConfig("ServerJurnal_DB")

        ' Set DB Omset (mitramedicare_omset_keuangan)
        DB_Omset.Tip = serverOnline_IP
        DB_Omset.Tid = serverOnline_UserID
        DB_Omset.Tpass = serverOnline_Password
        DB_Omset.Tdb = Utility.GetConfig("ServerOnlineOmset_DB")
    End Sub

    Private Sub FormUploadDataOmset_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
        Me.MdiParent = PoliKlinik
        Me.Dock = DockStyle.Fill

        SetConnectionFromConfig()
        LabelProgress.ResetText()
    End Sub

    Private Sub ButtonClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClose.Click
        Me.Close()
    End Sub

    Function JumlahTransaksiPending() As Integer
        Dim query As New StringBuilder()

        query.AppendLine("SELECT COUNT(*) ")
        query.AppendLine("FROM ( ")
        query.AppendLine("    SELECT TransPoliID ")
        query.AppendLine("    FROM TransaksiPoli a ")
        query.AppendLine("    WHERE (CONVERT(DATE, TglPoli) BETWEEN '" & Format(DateTimePickerTanggalTransaksiAwal.Value, "yyyy-MM-dd") & "' AND '" & Format(DateTimePickerTanggalTransaksiAkhir.Value, "yyyy-MM-dd") & "') ")
        query.AppendLine("      AND Deleted = 0 ")
        query.AppendLine("      AND TransPoliID IN ( ")
        query.AppendLine("          SELECT TransPoliID ")
        query.AppendLine("          FROM TransaksiPoliDetail ")
        query.AppendLine("          WHERE StatusPembayaran = 'PENDING' AND DeletedDate IS NULL")
        query.AppendLine("      ) ")
        query.AppendLine("    UNION ALL ")
        query.AppendLine("    SELECT TransGigiID ")
        query.AppendLine("    FROM TransaksiGigi a ")
        query.AppendLine("    WHERE (CONVERT(DATE, TglGigi) BETWEEN '" & Format(DateTimePickerTanggalTransaksiAwal.Value, "yyyy-MM-dd") & "' AND '" & Format(DateTimePickerTanggalTransaksiAkhir.Value, "yyyy-MM-dd") & "') ")
        query.AppendLine("      AND Deleted = 0 ")
        query.AppendLine("      AND TransGigiID IN ( ")
        query.AppendLine("          SELECT TransPoliID ")
        query.AppendLine("          FROM TransaksiPoliDetail ")
        query.AppendLine("          WHERE StatusPembayaran = 'PENDING' AND DeletedDate IS NULL")
        query.AppendLine("      ) ")
        query.AppendLine(") AS CombinedResult;")

        Dim jumlahTransaksi As String = ReadSQLNIK(query.ToString())

        Return CDbl(jumlahTransaksi)
    End Function

    Private Function ValidasiDataUpload() As Boolean
        ' Cek sambungan internet
        If CheckInternetConnection() = False Then
            MessageBox.Show("Eror : Tidak ada koneksi internet.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Return False
        End If

        ' Validasi Tanggal Transaksi
        If DateTimePickerTanggalTransaksiAkhir.Value.Date > DateTime.Now.AddDays(-1).Date Then
            MessageBox.Show("Eror : Tanggal transaksi maksimal H-1.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            ' Kembalikan ke tanggal kemarin
            DateTimePickerTanggalTransaksiAkhir.Value = DateTime.Now.AddDays(-1)

            Return False
        End If

        ' Validasi transaksi pending
        If JumlahTransaksiPending() > 0 Then
            MessageBox.Show("Eror : Terdapat transaksi pending yang belum diselesaikan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Return False
        End If

        Return True
    End Function

    Private Sub ButtonSearchDataOmset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSearchDataOmset.Click
        Try
            If ValidasiDataUpload() = True Then
                ViewDataOmset()
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub ViewDataOmset()
        Dim tblPoliUmum As DataTable = GetDataUploadOmsetPoliUmum()
        Dim tblPoliGigi As DataTable = GetDataUploadOmsetPoliGigi()
        Dim tblLaboratorium As DataTable = GetDataUploadOmsetLaboratorium()

        ' Buat tabel gabungan dengan struktur yang sama
        Dim tblOmset As DataTable = tblPoliUmum.Clone()

        ' Gabungkan data dari kedua tabel
        tblOmset.Merge(tblPoliUmum)
        tblOmset.Merge(tblPoliGigi)
        tblOmset.Merge(tblLaboratorium)

        If tblOmset.Rows.Count > 0 Then
            For Each Tcol As DataColumn In tblOmset.Columns
                Tcol.ReadOnly = True
            Next

            GridControlTransaksi.DataSource = tblOmset
            GridViewTransaksi.Columns("JenisTransaksi").Visible = False
            GridViewTransaksi.BestFitColumns()
        Else
            MsgBox("Tidak Ada Data.", MsgBoxStyle.Exclamation, "Warning")
        End If
    End Sub

    Function GetDataUploadOmsetPoliUmum() As DataTable
        Dim tglTransaksiAwal As Date = DateTimePickerTanggalTransaksiAwal.Value
        Dim tglTransaksiAkhir As Date = DateTimePickerTanggalTransaksiAkhir.Value
        Dim tblResult As New DataTable

        Dim query As New StringBuilder()

        query.AppendLine("WITH FilteredTransPoli AS (")
        query.AppendLine("    SELECT TransPoliID")
        query.AppendLine("    FROM TransaksiPoli")
        query.AppendLine("    WHERE (CONVERT(DATE, TglPoli) BETWEEN '" & Format(tglTransaksiAwal.Date, "yyyyMMdd") & "' AND '" & Format(tglTransaksiAkhir.Date, "yyyyMMdd") & "') AND Upload = 0 AND Deleted = 0")
        query.AppendLine(")")
        query.AppendLine("SELECT tblBayar.TransPoliID AS 'ID', t.NoUrut, CONVERT(DATE, t.TglPoli) AS 'Tgl Transaksi',")
        query.AppendLine("       d.JenisPoli, p.Nama, p.NoRekamMedis, tblBayar.JenisBayar, tblBayar.NoJenisBayar, tblBayar.kartu AS 'JenisKartu', tblBayar.mesin AS 'JenisMesin', d.JenisTransaksi,")
        query.AppendLine("       SUM(JumlahBayar - Kembali) AS TotalBayar")
        query.AppendLine("FROM (")
        query.AppendLine("    SELECT tb.TransPoliID, tb.JenisBayar, tb.NoJenisBayar, tb.JumlahBayar, tb.Kembali, tb.kartu, tb.mesin")
        query.AppendLine("    FROM TransaksiPoliBayar tb")
        query.AppendLine("    INNER JOIN FilteredTransPoli ft ON tb.TransPoliID = ft.TransPoliID")
        query.AppendLine("    WHERE tb.JumlahBayar > 0 AND tb.JenisBayar IN ('TAGIHAN', 'TUNAI', 'DEBET', 'CARD')")
        query.AppendLine("    UNION ALL")
        query.AppendLine("    SELECT tba.TransPoliID, tba.JenisBayar, tba.NoJenisBayar, tba.JumlahBayar, tba.Kembali, tba.kartu, tba.mesin")
        query.AppendLine("    FROM TransaksiPoliBayarAwal tba")
        query.AppendLine("    INNER JOIN FilteredTransPoli ft ON tba.TransPoliID = ft.TransPoliID")
        query.AppendLine("    WHERE tba.JumlahBayar > 0 AND tba.JenisBayar IN ('TAGIHAN', 'TUNAI', 'DEBET', 'CARD')")
        query.AppendLine(") AS tblBayar")
        query.AppendLine("LEFT JOIN TransaksiPoli t ON tblBayar.TransPoliID = t.TransPoliID")
        query.AppendLine("LEFT JOIN TransaksiDetail d ON t.NoUrut = d.NoUrut")
        query.AppendLine("LEFT JOIN MasterPasien p ON t.IDInternet = p.NoRekamMedis")
        query.AppendLine("GROUP BY tblBayar.TransPoliID, t.NoUrut, CONVERT(DATE, t.TglPoli),")
        query.AppendLine("         d.JenisPoli, p.Nama, p.NoRekamMedis, tblBayar.JenisBayar, tblBayar.NoJenisBayar, tblBayar.kartu, tblBayar.mesin, d.JenisTransaksi")

        tblResult = ReadSQL(query.ToString())

        Return tblResult
    End Function

    Function GetDataUploadOmsetPoliGigi() As DataTable
        Dim tglTransaksiAwal As Date = DateTimePickerTanggalTransaksiAwal.Value
        Dim tglTransaksiAkhir As Date = DateTimePickerTanggalTransaksiAkhir.Value
        Dim tblResult As New DataTable

        Dim query As New StringBuilder()

        query.AppendLine("WITH FilteredTransGigi AS (")
        query.AppendLine("    SELECT TransGigiID")
        query.AppendLine("    FROM TransaksiGigi")
        query.AppendLine("    WHERE (CONVERT(DATE, TglGigi) BETWEEN '" & Format(tglTransaksiAwal.Date, "yyyyMMdd") & "' AND '" & Format(tglTransaksiAkhir.Date, "yyyyMMdd") & "') AND Upload = 0 AND Deleted = 0")
        query.AppendLine(")")
        query.AppendLine("SELECT tblBayar.TransGigiID AS 'ID', t.NoUrut, CONVERT(DATE, t.TglGigi) AS 'Tgl Transaksi',")
        query.AppendLine("       d.JenisPoli, p.Nama, p.NoRekamMedis, tblBayar.JenisBayar, tblBayar.NoJenisBayar, tblBayar.kartu AS 'JenisKartu', tblBayar.mesin AS 'JenisMesin', d.JenisTransaksi,")
        query.AppendLine("       SUM(JumlahBayar - Kembali) AS TotalBayar")
        query.AppendLine("FROM (")
        query.AppendLine("    SELECT tb.TransGigiID, tb.JenisBayar, tb.NoJenisBayar, tb.JumlahBayar, tb.Kembali, tb.kartu, tb.mesin")
        query.AppendLine("    FROM TransaksiGigiBayar tb")
        query.AppendLine("    INNER JOIN FilteredTransGigi ft ON tb.TransGigiID = ft.TransGigiID")
        query.AppendLine("    WHERE tb.JumlahBayar > 0 AND tb.JenisBayar IN ('TAGIHAN', 'TUNAI', 'DEBET', 'CARD')")
        query.AppendLine("    UNION ALL")
        query.AppendLine("    SELECT tba.TransGigiID, tba.JenisBayar, tba.NoJenisBayar, tba.JumlahBayar, tba.Kembali, tba.kartu, tba.mesin")
        query.AppendLine("    FROM TransaksiGigiBayarAwal tba")
        query.AppendLine("    INNER JOIN FilteredTransGigi ft ON tba.TransGigiID = ft.TransGigiID")
        query.AppendLine("    WHERE tba.JumlahBayar > 0 AND tba.JenisBayar IN ('TAGIHAN', 'TUNAI', 'DEBET', 'CARD')")
        query.AppendLine(") AS tblBayar")
        query.AppendLine("LEFT JOIN TransaksiGigi t ON tblBayar.TransGigiID = t.TransGigiID")
        query.AppendLine("LEFT JOIN TransaksiDetail d ON t.NoUrut = d.NoUrut")
        query.AppendLine("LEFT JOIN MasterPasien p ON t.IDInternet = p.NoRekamMedis")
        query.AppendLine("GROUP BY tblBayar.TransGigiID, t.NoUrut, CONVERT(DATE, t.TglGigi),")
        query.AppendLine("         d.JenisPoli, p.Nama, p.NoRekamMedis, tblBayar.JenisBayar, tblBayar.NoJenisBayar, tblBayar.kartu, tblBayar.mesin, d.JenisTransaksi")

        tblResult = ReadSQL(query.ToString())

        Return tblResult
    End Function

    Function GetDataUploadOmsetLaboratorium() As DataTable
        Dim tglTransaksiAwal As Date = DateTimePickerTanggalTransaksiAwal.Value
        Dim tglTransaksiAkhir As Date = DateTimePickerTanggalTransaksiAkhir.Value
        Dim tblResult As New DataTable

        Dim query As New StringBuilder()

        query.AppendLine("WITH FilteredTransLab AS (")
        query.AppendLine("    SELECT TransLabID")
        query.AppendLine("    FROM TransaksiLab")
        query.AppendLine("    WHERE (CONVERT(DATE, TglLab) BETWEEN '" & Format(tglTransaksiAwal.Date, "yyyyMMdd") & "' AND '" & Format(tglTransaksiAkhir.Date, "yyyyMMdd") & "') AND Upload = 0 AND Deleted = 0 AND SendKeu IS NOT NULL AND NoUrut LIKE '%L%'")
        query.AppendLine(")")
        query.AppendLine("SELECT tblBayar.TransLabID AS 'ID', t.NoUrut, CONVERT(DATE, t.TglLab) AS 'Tgl Transaksi',")
        query.AppendLine("       d.JenisPoli, p.Nama, p.NoRekamMedis, tblBayar.JenisBayar, tblBayar.NoJenisBayar, tblBayar.kartu AS 'JenisKartu', tblBayar.mesin AS 'JenisMesin', d.JenisTransaksi,")
        query.AppendLine("       SUM(JumlahBayar - Kembali) AS TotalBayar")
        query.AppendLine("FROM (")
        query.AppendLine("    SELECT tb.TransLabID, tb.JenisBayar, tb.NoJenisBayar, tb.JumlahBayar, tb.Kembali, tb.kartu, tb.mesin")
        query.AppendLine("    FROM TransaksiLabBayar tb")
        query.AppendLine("    INNER JOIN FilteredTransLab ft ON tb.TransLabID = ft.TransLabID")
        query.AppendLine("    WHERE tb.JumlahBayar > 0 AND tb.JenisBayar IN ('TAGIHAN', 'TUNAI', 'DEBET', 'CARD')")
        query.AppendLine(") AS tblBayar")
        query.AppendLine("LEFT JOIN TransaksiLab t ON tblBayar.TransLabID = t.TransLabID")
        query.AppendLine("LEFT JOIN TransaksiDetail d ON t.NoUrut = d.NoUrut")
        query.AppendLine("LEFT JOIN MasterPasien p ON t.IDInternet = p.NoRekamMedis")
        query.AppendLine("GROUP BY tblBayar.TransLabID, t.NoUrut, CONVERT(DATE, t.TglLab),")
        query.AppendLine("         d.JenisPoli, p.Nama, p.NoRekamMedis, tblBayar.JenisBayar, tblBayar.NoJenisBayar, tblBayar.kartu, tblBayar.mesin, d.JenisTransaksi")

        tblResult = ReadSQL(query.ToString())

        Return tblResult
    End Function

    Private Sub ButtonKirimDataOmset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonKirimDataOmset.Click
        thread = New System.Threading.Thread(AddressOf KirimOmsetHarian)
        thread.Start()
    End Sub

    Private Sub KirimOmsetHarian()
        Dim tblPoliUmum As DataTable = GetDataUploadOmsetPoliUmum()
        Dim tblPoliGigi As DataTable = GetDataUploadOmsetPoliGigi()
        Dim tblLaboratorium As DataTable = GetDataUploadOmsetLaboratorium()

        ' Buat tabel gabungan dengan struktur yang sama
        Dim tblOmset As DataTable = tblPoliUmum.Clone()

        ' Gabungkan data dari kedua tabel
        tblOmset.Merge(tblPoliUmum)
        tblOmset.Merge(tblPoliGigi)
        tblOmset.Merge(tblLaboratorium)

        If tblOmset.Rows.Count > 0 Then
            ' Disable Button
            ButtonKirimDataOmset.BackColor = Color.FromArgb(225, 225, 225)
            ButtonKirimDataOmset.Enabled = False

            Dim queryStringRekap As String = ""
            Dim transaksiProgres As Integer = 0
            Dim persentaseProgres As Integer = 0

            ' Set Data Pasien Umum
            Dim rowPasienUmum As Integer = 0
            Dim queryStringUmum As New StringBuilder()
            queryStringUmum.AppendLine("INSERT INTO acctranspendapatandetail (inctgl, loc, incjenis, jenis, kartu, mesin, incnilai, createdate, inctransid, idinternet, pasien, no_transaksi, jenis_poli, flagdate, flagby, flag) VALUES ")

            ' Set Data Pasien Tagihan
            Dim rowPasienTagihan As Integer = 0
            Dim queryStringTagihan As New StringBuilder()
            queryStringTagihan.AppendLine("INSERT INTO acctranstagihandetail(inctgl, loc, incjenis, jenis, kartu, mesin, incnilai, createdate, inctransid, idinternet, pasien, rekapid, lockeddate, lockedby, no_transaksi, jenis_poli) VALUES ")

            ' Set Data No Transaksi
            Dim noTransaksiPoli As String = ""
            Dim noTransaksiGigi As String = ""
            Dim noTransaksiLab As String = ""

            ' Set HashSet untuk setiap jenis transaksi
            Dim tempTransaksiPoli As New HashSet(Of String)()
            Dim tempTransaksiLab As New HashSet(Of String)()
            Dim tempTransaksiGigi As New HashSet(Of String)()

            For Each rowOmset As DataRow In tblOmset.Rows
                ' Cek Jumlah Proses
                transaksiProgres += 1
                persentaseProgres = transaksiProgres * 100 / tblOmset.Rows.Count

                ' Update ProgressBar
                ProgressBarUpload.Value = persentaseProgres
                LabelProgress.Text = "Progress : " & persentaseProgres & " %"

                ' Set Variabel Input Data
                Dim tglSekarang As String = Format(DateAndTime.Now, "yyyy-MM-dd")
                Dim tglPeriksa As String = Format(rowOmset("Tgl Transaksi"), "yyyy-MM-dd")
                Dim jenisKartu As String = rowOmset("JenisKartu")
                Dim jenisMesin As String = rowOmset("JenisMesin")
                Dim idTransaksi As String = rowOmset("ID")
                Dim noRekamMedis As String = rowOmset("NoRekamMedis")
                Dim namaPasien As String = rowOmset("Nama").ToString.Replace("'", "''")
                Dim noTransaksi As String = rowOmset("NoUrut")
                Dim jenisPoli As String = rowOmset("JenisPoli")
                Dim keteranganBayar As String = rowOmset("NoJenisBayar")
                Dim jenisTransaksi As String = rowOmset("JenisTransaksi")
                Dim nominalTransaksi As String = rowOmset("TotalBayar")
                Dim jenisBayar As String = ""

                ' Set Keterangan Jenis Bayar
                If rowOmset("JenisBayar").ToString = "TUNAI" Then
                    jenisBayar = "Tunai"
                ElseIf rowOmset("JenisBayar").ToString = "DEBET" Then
                    jenisBayar = "Debet"
                ElseIf rowOmset("JenisBayar").ToString = "CARD" Then
                    jenisBayar = "Kredit"
                ElseIf rowOmset("JenisBayar").ToString = "TAGIHAN" Then
                    jenisBayar = "Tagihan"
                End If

                If jenisBayar = "TAGIHAN" Then ' Get Rekap Tagihan Per Transaksi
                    Dim keteranganPerusahaan, kodePerusahaan As String
                    If keteranganBayar.Contains("-") = True Then
                        Dim splitKeterangan() As String = keteranganBayar.Split("-")
                        keteranganPerusahaan = splitKeterangan(0)
                        kodePerusahaan = splitKeterangan(1)
                    Else
                        keteranganPerusahaan = keteranganBayar
                        kodePerusahaan = ""
                    End If

                    Select Case jenisTransaksi
                        Case "POLI"
                            queryStringRekap = "SELECT a.RekapID, b.CreateDate, b.CreateBy FROM TransaksiPoli a LEFT JOIN RekapTagihan b ON a.RekapID=b.RekapID WHERE a.TransPoliID='" & idTransaksi & "'"
                        Case "GIGI"
                            queryStringRekap = "SELECT a.RekapID, b.CreateDate, b.CreateBy FROM TransaksiGigi a LEFT JOIN RekapTagihan b ON a.RekapID=b.RekapID WHERE a.TransGigiID='" & idTransaksi & "'"
                        Case "LAB"
                            queryStringRekap = "SELECT a.RekapID, b.CreateDate, b.CreateBy FROM TransaksiLab a LEFT JOIN RekapTagihan b ON a.RekapID=b.RekapID WHERE a.translabid='" & idTransaksi & "'"
                    End Select

                    Dim TblsRekap As DataTable = ReadSQL(queryStringRekap)

                    For Each TrowRekap As DataRow In TblsRekap.Rows
                        Dim idRekap As String = "NULL"
                        Dim tglRekap As String = "9998-12-31 00:00:00"
                        Dim namaUserRekap As String = ""

                        If IsDBNull(TrowRekap("RekapID")) = False Then idRekap = TrowRekap("RekapID")
                        If IsDBNull(TrowRekap("CreateDate")) = False Then tglRekap = Format(TrowRekap("CreateDate"), "yyyy-MM-dd HH:mm:ss")
                        If IsDBNull(TrowRekap("CreateBy")) = False Then namaUserRekap = TrowRekap("CreateBy")

                        queryStringTagihan.AppendLine("('" & tglPeriksa & "','" & kodeLokasiKlinik & "','" & jenisTransaksi & "','" & jenisBayar & "','" & keteranganPerusahaan & "','" & kodePerusahaan & "','" & nominalTransaksi & "',NOW(),'" & idTransaksi & "','" & noRekamMedis & "','" & namaPasien & "', " & idRekap & ", '" & tglRekap & "', '" & namaUserRekap & "', '" & noTransaksi & "', '" & jenisPoli & "'),")
                        rowPasienTagihan += 1
                    Next
                Else
                    queryStringUmum.AppendLine("('" & tglPeriksa & "','" & kodeLokasiKlinik & "','" & jenisTransaksi & "','" & jenisBayar & "','" & jenisKartu & "','" & jenisMesin & "','" & nominalTransaksi & "',NOW(),'" & idTransaksi & "','" & noRekamMedis & "','" & namaPasien & "', '" & noTransaksi & "', '" & jenisPoli & "', NOW(), '" & userInput & "', 'Auto Jurnal Pendapatan'),")
                    rowPasienUmum += 1
                End If

                Select Case jenisTransaksi
                    Case "POLI"
                        If tempTransaksiPoli.Add(idTransaksi) Then
                            noTransaksiPoli &= "'" & idTransaksi & "',"
                        End If
                    Case "LAB"
                        If tempTransaksiLab.Add(idTransaksi) Then
                            noTransaksiLab &= "'" & idTransaksi & "',"
                        End If
                    Case "GIGI"
                        If tempTransaksiGigi.Add(idTransaksi) Then
                            noTransaksiGigi &= "'" & idTransaksi & "',"
                        End If
                End Select
            Next

            ' Post Pendapatan Umum ke Keuangan
            If rowPasienUmum > 0 Then
                Dim sqlStatementUmum As String = queryStringUmum.ToString()

                sqlStatementUmum = sqlStatementUmum.TrimEnd()
                If sqlStatementUmum.EndsWith(",") Then
                    sqlStatementUmum = sqlStatementUmum.Substring(0, sqlStatementUmum.Length - 1)
                End If

                WriteThemysql(sqlStatementUmum, DB_Keuangan)
            End If

            ' Post Pendapatan Tagihan ke Keuangan
            If rowPasienTagihan > 0 Then
                Dim sqlStatementTagihan As String = queryStringTagihan.ToString()

                sqlStatementTagihan = sqlStatementTagihan.TrimEnd()
                If sqlStatementTagihan.EndsWith(",") Then
                    sqlStatementTagihan = sqlStatementTagihan.Substring(0, sqlStatementTagihan.Length - 1)
                End If

                WriteThemysql(sqlStatementTagihan, DB_Keuangan)
            End If

            ' Update Flag Upload
            If tempTransaksiPoli.Count > 0 Then
                noTransaksiPoli = Strings.Left(noTransaksiPoli, noTransaksiPoli.Length - 1)
                WriteSQL("UPDATE TransaksiPoli SET Upload = 1, UploadDate = GETDATE() WHERE TransPoliID IN (" & noTransaksiPoli & ")", 4)
            End If

            If tempTransaksiLab.Count > 0 Then
                noTransaksiLab = Strings.Left(noTransaksiLab, noTransaksiLab.Length - 1)
                WriteSQL("UPDATE TransaksiLab SET Upload = 1, UploadDate = GETDATE() WHERE TransLabID IN (" & noTransaksiLab & ")", 4)
            End If

            If tempTransaksiGigi.Count > 0 Then
                noTransaksiGigi = Strings.Left(noTransaksiGigi, noTransaksiGigi.Length - 1)
                WriteSQL("UPDATE TransaksiGigi SET Upload = 1, UploadDate = GETDATE() WHERE TransGigiID IN (" & noTransaksiGigi & ")", 4)
            End If

            Dim jumlahTransaksi As Integer = tempTransaksiPoli.Count + tempTransaksiLab.Count + tempTransaksiGigi.Count

            ' Send Jurnal
            SendingJurnal()

            ' Enable Button / TextBox
            ButtonKirimDataOmset.BackColor = Color.FromArgb(0, 100, 200)
            ButtonKirimDataOmset.Enabled = True

            MsgBox(jumlahTransaksi & " Data telah berhasil upload.", MsgBoxStyle.Information, "Success!")
        Else
            MsgBox("Tidak Ada Data.", MsgBoxStyle.Exclamation, "Warning")
        End If
    End Sub

    Private Sub ButtonKirimJurnalUlang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonKirimJurnalUlang.Click
        Try
            thread = New System.Threading.Thread(AddressOf SendingJurnal)
            thread.Start()
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub SendingJurnal()
        Dim tblPoliUmum As DataTable = GetDataUploadJurnalPoliUmum()
        Dim tblPoliGigi As DataTable = GetDataUploadJurnalPoliGigi()
        Dim tblLaboratorium As DataTable = GetDataUploadJurnalLaboratorium()

        ' Buat tabel gabungan dengan struktur yang sama
        Dim tblTransaksi As DataTable = tblPoliUmum.Clone()

        ' Gabungkan data dari kedua tabel
        tblTransaksi.Merge(tblPoliUmum)
        tblTransaksi.Merge(tblPoliGigi)
        tblTransaksi.Merge(tblLaboratorium)

        Dim transaksiProgres As Integer = 0
        Dim persentaseProgres As Integer = 0

        Dim tglTransaksiAwal As Date = DateTimePickerTanggalTransaksiAwal.Value
        Dim tglTransaksiAkhir As Date = DateTimePickerTanggalTransaksiAkhir.Value

        If tblTransaksi.Rows.Count > 0 Then
            For Each rowTransaksi As DataRow In tblTransaksi.Rows
                ' Cek Jumlah Proses
                transaksiProgres += 1
                persentaseProgres = transaksiProgres * 100 / tblTransaksi.Rows.Count

                ' Update ProgressBar
                ProgressBarUpload.Value = persentaseProgres
                LabelProgress.Text = "Progress : " & persentaseProgres & " %"

                ' Set ID Lokasi Jurnal
                Dim tblMasterJurnal As New DataTable
                Dim idLokasiJurnal As String = ""
                Dim keteranganLokasiJurnal As String = ""

                If tipeJurnal = "Poli" Then
                    tblMasterJurnal = ReadThemysql("SELECT a.KeteranganLokasi AS 'Lokasi', a.KeteranganPoli AS 'Keterangan', a.KodeLokasiJurnal, a.KodeCoaPendapatan, a.KodeCoaPiutangPending, a.KodeCoaPendapatanTunai FROM MasterLokasiJurnal a WHERE a.KodeLokasi = '" & kodeLokasiKlinik & "' AND a.KeteranganPoli = '" & rowTransaksi("JenisPoli") & "' LIMIT 1;", DB_Omset)
                ElseIf tipeJurnal = "Transaksi" Then
                    tblMasterJurnal = ReadThemysql("SELECT a.KeteranganLokasi AS 'Lokasi', a.JenisTransaksi AS 'Keterangan', a.KodeLokasiJurnal, a.KodeCoaPendapatan, a.KodeCoaPiutangPending, a.KodeCoaPendapatanTunai FROM MasterLokasiJurnal a WHERE a.KodeLokasi = '" & kodeLokasiKlinik & "' AND a.JenisTransaksi = '" & rowTransaksi("JenisTransaksi") & "' LIMIT 1;", DB_Omset)
                End If

                Dim rowDataJurnal As DataRow = tblMasterJurnal.Rows(0)
                idLokasiJurnal = rowDataJurnal("KodeLokasiJurnal")
                keteranganLokasiJurnal = rowDataJurnal("Lokasi") & " (" & rowDataJurnal("Keterangan") & ")"

                ' Set Flag / Refference
                Dim refferenceID As String = GetUUID()

                ' Set Mesin EDC
                Dim mesinEDC As String = rowTransaksi("mesin").ToString.Trim
                Dim keteranganMesinEDC As String = " "
                Dim coaMesinEDC As String = ""

                If rowTransaksi("JenisBayar").ToString = "DEBET" Or rowTransaksi("JenisBayar").ToString = "CARD" Then
                    ' Set Keterangan Mesin EDC
                    If rowTransaksi("mesin").ToString.Trim <> "" Then
                        keteranganMesinEDC = " " & rowTransaksi("mesin").ToString.Trim & " "
                    End If

                    ' Set COA Mesin EDC
                    If mesinEDC.Contains("QRIS") = True Then
                        coaMesinEDC = ReadThemysqlNIK("SELECT a.KodeAkun FROM MasterCoaJurnal a WHERE a.NamaAkun = 'Piutang QRIS'", DB_Omset)
                    ElseIf mesinEDC = "BCA" Then
                        coaMesinEDC = ReadThemysqlNIK("SELECT a.KodeAkun FROM MasterCoaJurnal a WHERE a.NamaAkun = 'Piutang BCA'", DB_Omset)
                    ElseIf mesinEDC = "MANDIRI" Then
                        coaMesinEDC = ReadThemysqlNIK("SELECT a.KodeAkun FROM MasterCoaJurnal a WHERE a.NamaAkun = 'Piutang MANDIRI'", DB_Omset)
                    ElseIf mesinEDC = "CIMB" Or mesinEDC = "NIAGA" Then
                        coaMesinEDC = ReadThemysqlNIK("SELECT a.KodeAkun FROM MasterCoaJurnal a WHERE a.NamaAkun = 'Piutang CIMB'", DB_Omset)
                    End If
                End If

                    ' Set Keterangan Jenis Bayar
                    Dim keteranganJenisBayar As String = ""
                    If rowTransaksi("JenisBayar").ToString = "TUNAI" Then
                        keteranganJenisBayar = "Tunai"
                    ElseIf rowTransaksi("JenisBayar").ToString = "DEBET" Then
                        keteranganJenisBayar = "Debet"
                    ElseIf rowTransaksi("JenisBayar").ToString = "CARD" Then
                        keteranganJenisBayar = "Kredit"
                    ElseIf rowTransaksi("JenisBayar").ToString = "TAGIHAN" Then
                        keteranganJenisBayar = "Tagihan"
                    End If

                    ' Set Keterangan Jurnal
                    Dim keteranganJurnal As String = "TERIMA - OMZET " & keteranganJenisBayar.ToUpper() & keteranganMesinEDC.ToUpper() & keteranganLokasiJurnal & " " & Format(rowTransaksi("Tgl Transaksi"), "dd/MM/yyyy") & ""

                    ' Kirim Jurnal Omset
                    If keteranganJenisBayar = "Tagihan" Then
                        WriteThemysql("SELECT F_MakeUMH('" & refferenceID & "', 'out', '', '" & Format(rowTransaksi("Tgl Transaksi"), "yyyyMMdd") & "', '" & rowDataJurnal("KodeCoaPendapatan").ToString() & "', '" & rowDataJurnal("KodeCoaPiutangPending").ToString() & "', 'IDR', 1, " & CDbl(rowTransaksi("JumlahBayar")) & ", '" & keteranganJurnal.ToUpper() & "', '1', 1, '', '" & keteranganJurnal.ToUpper() & "', '', '', '" & idLokasiJurnal & "', 4, " & CDbl(rowTransaksi("JumlahBayar")) & ", 'K')", DB_Jurnal)
                    ElseIf keteranganJenisBayar = "Tunai" Then
                        WriteThemysql("SELECT F_MakeUMH('" & refferenceID & "', 'out', '', '" & Format(rowTransaksi("Tgl Transaksi"), "yyyyMMdd") & "', '" & rowDataJurnal("KodeCoaPendapatan").ToString() & "', '" & rowDataJurnal("KodeCoaPendapatanTunai").ToString() & "', 'IDR', 1, " & CDbl(rowTransaksi("JumlahBayar")) & ", '" & keteranganJurnal.ToUpper() & "', '1', 1, '', '" & keteranganJurnal.ToUpper() & "', '', '', '" & idLokasiJurnal & "', 4, " & CDbl(rowTransaksi("JumlahBayar")) & ", 'K')", DB_Jurnal)
                    ElseIf keteranganJenisBayar = "Debet" Or keteranganJenisBayar = "Kredit" Then
                        WriteThemysql("SELECT F_MakeUMH('" & refferenceID & "', 'out', '', '" & Format(rowTransaksi("Tgl Transaksi"), "yyyyMMdd") & "', '" & rowDataJurnal("KodeCoaPendapatan").ToString() & "', '" & coaMesinEDC & "', 'IDR', 1, " & CDbl(rowTransaksi("JumlahBayar")) & ", '" & keteranganJurnal.ToUpper() & "', '1', 1, '', '" & keteranganJurnal.ToUpper() & "', '', '', '" & idLokasiJurnal & "', 4, " & CDbl(rowTransaksi("JumlahBayar")) & ", 'K')", DB_Jurnal)
                    End If

                    ' Set Jenis Poli
                    Dim jenisPoli As String = ""
                    If tipeJurnal = "Poli" Then
                        jenisPoli = rowTransaksi("JenisPoli").ToString
                    ElseIf tipeJurnal = "Transaksi" Then
                        jenisPoli = ""
                    End If

                    ' Update Flag Jurnal Omset
                    If rowTransaksi("JenisTransaksi").ToString.Trim = "POLI" Then
                        UpdateFlagPoliUmum(Format(rowTransaksi("Tgl Transaksi"), "yyyyMMdd"), refferenceID, jenisPoli, rowTransaksi("JenisBayar").ToString, keteranganJenisBayar)
                    ElseIf rowTransaksi("JenisTransaksi").ToString.Trim = "GIGI" Then
                        UpdateFlagPoliGigi(Format(rowTransaksi("Tgl Transaksi"), "yyyyMMdd"), refferenceID, jenisPoli, rowTransaksi("JenisBayar").ToString, keteranganJenisBayar)
                    ElseIf rowTransaksi("JenisTransaksi").ToString.Trim = "LAB" Then
                        UpdateFlagLaboratorium(Format(rowTransaksi("Tgl Transaksi"), "yyyyMMdd"), refferenceID, jenisPoli, rowTransaksi("JenisBayar").ToString, keteranganJenisBayar)
                    End If

                    ' Simpan Log Jurnal Omset
                    WriteSQL("INSERT INTO LogJurnalKeuangan (JurnalFlag, JurnalDate, JurnalBy, Status, JenisPoli, JenisTransaksi) VALUES ('" & refferenceID & "', GETDATE(), '" & userInput & "', '" & keteranganJurnal & "', '" & jenisPoli & "', '" & rowTransaksi("JenisTransaksi").ToString & "')", 4)
            Next
        End If
    End Sub

    Private Sub UpdateFlagPoliUmum(ByVal tglTransaksi As String, ByVal flagJurnal As String, ByVal namaPoli As String, ByVal jenisBayar As String, ByVal stringFlag As String)
        Dim query As New StringBuilder()

        query.AppendLine("UPDATE TransaksiPoli")
        query.AppendLine("SET FlagJurnalHarian" & stringFlag & " = '" & flagJurnal & "'")
        query.AppendLine("WHERE CONVERT(DATE, TglPoli) = '" & tglTransaksi & "'")
        query.AppendLine("  AND Deleted = 0")
        query.AppendLine("  AND FlagJurnalHarian" & stringFlag & " IS NULL")
        query.AppendLine("  AND TransPoliID IN (")
        query.AppendLine("      SELECT tp.TransPoliID")
        query.AppendLine("      FROM TransaksiPoliBayar tb")
        query.AppendLine("      INNER JOIN TransaksiPoli tp ON tp.TransPoliID = tb.TransPoliID")
        query.AppendLine("      WHERE tb.JenisBayar = '" & jenisBayar & "' AND tb.JumlahBayar > 0")
        query.AppendLine("        AND tp.NoUrut IN (")
        query.AppendLine("            SELECT td.NoUrut")
        query.AppendLine("            FROM TransaksiDetail td")
        If tipeJurnal = "Poli" Then
            query.AppendLine("            WHERE td.JenisPoli = '" & namaPoli & "'")
        End If
        query.AppendLine("        )")
        query.AppendLine("      UNION ALL")
        query.AppendLine("      SELECT tp.TransPoliID")
        query.AppendLine("      FROM TransaksiPoliBayarAwal tba")
        query.AppendLine("      INNER JOIN TransaksiPoli tp ON tp.TransPoliID = tba.TransPoliID")
        query.AppendLine("      WHERE tba.JenisBayar = '" & jenisBayar & "' AND tba.JumlahBayar > 0")
        query.AppendLine("        AND tp.NoUrut IN (")
        query.AppendLine("            SELECT td.NoUrut")
        query.AppendLine("            FROM TransaksiDetail td")
        If tipeJurnal = "Poli" Then
            query.AppendLine("            WHERE td.JenisPoli = '" & namaPoli & "'")
        End If
        query.AppendLine("        )")
        query.AppendLine("  )")

        ' Exec Query
        WriteSQL(query.ToString(), 4)
    End Sub

    Private Sub UpdateFlagPoliGigi(ByVal tglTransaksi As String, ByVal flagJurnal As String, ByVal namaPoli As String, ByVal jenisBayar As String, ByVal stringFlag As String)
        Dim query As New StringBuilder()

        query.AppendLine("UPDATE TransaksiGigi")
        query.AppendLine("SET FlagJurnalHarian" & stringFlag & " = '" & flagJurnal & "'")
        query.AppendLine("WHERE CONVERT(DATE, TglGigi) = '" & tglTransaksi & "'")
        query.AppendLine("  AND Deleted = 0")
        query.AppendLine("  AND FlagJurnalHarian" & stringFlag & " IS NULL")
        query.AppendLine("  AND TransGigiID IN (")
        query.AppendLine("      SELECT tp.TransGigiID")
        query.AppendLine("      FROM TransaksiGigiBayar tb")
        query.AppendLine("      INNER JOIN TransaksiGigi tp ON tp.TransGigiID = tb.TransGigiID")
        query.AppendLine("      WHERE tb.JenisBayar = '" & jenisBayar & "' AND tb.JumlahBayar > 0")
        query.AppendLine("        AND tp.NoUrut IN (")
        query.AppendLine("            SELECT td.NoUrut")
        query.AppendLine("            FROM TransaksiDetail td")
        If tipeJurnal = "Poli" Then
            query.AppendLine("            WHERE td.JenisPoli = '" & namaPoli & "'")
        End If
        query.AppendLine("        )")
        query.AppendLine("      UNION ALL")
        query.AppendLine("      SELECT tp.TransGigiID")
        query.AppendLine("      FROM TransaksiGigiBayarAwal tba")
        query.AppendLine("      INNER JOIN TransaksiGigi tp ON tp.TransGigiID = tba.TransGigiID")
        query.AppendLine("      WHERE tba.JenisBayar = '" & jenisBayar & "' AND tba.JumlahBayar > 0")
        query.AppendLine("        AND tp.NoUrut IN (")
        query.AppendLine("            SELECT td.NoUrut")
        query.AppendLine("            FROM TransaksiDetail td")
        If tipeJurnal = "Poli" Then
            query.AppendLine("            WHERE td.JenisPoli = '" & namaPoli & "'")
        End If
        query.AppendLine("        )")
        query.AppendLine("  )")

        ' Exec Query
        WriteSQL(query.ToString(), 4)
    End Sub

    Private Sub UpdateFlagLaboratorium(ByVal tglTransaksi As String, ByVal flagJurnal As String, ByVal namaPoli As String, ByVal jenisBayar As String, ByVal stringFlag As String)
        Dim query As New StringBuilder()

        query.AppendLine("UPDATE TransaksiLab")
        query.AppendLine("SET FlagJurnalHarian" & stringFlag & " = '" & flagJurnal & "'")
        query.AppendLine("WHERE CONVERT(DATE, TglLab) = '" & tglTransaksi & "'")
        query.AppendLine("  AND Deleted = 0 AND SendKeu IS NOT NULL")
        query.AppendLine("  AND FlagJurnalHarian" & stringFlag & " IS NULL")
        query.AppendLine("  AND TransLabID IN (")
        query.AppendLine("      SELECT tb.TransLabID")
        query.AppendLine("      FROM TransaksiLabBayar tb")
        query.AppendLine("      WHERE tb.JenisBayar = '" & jenisBayar & "' AND tb.JumlahBayar > 0")
        query.AppendLine("  )")

        ' Exec Query
        WriteSQL(query.ToString(), 4)
    End Sub

    Function GetDataUploadJurnalPoliUmum() As DataTable
        Dim tglTransaksiAwal As Date = DateTimePickerTanggalTransaksiAwal.Value
        Dim tglTransaksiAkhir As Date = DateTimePickerTanggalTransaksiAkhir.Value
        Dim tblResult As New DataTable

        Dim query As New StringBuilder()

        query.AppendLine("WITH FilteredTransPoli AS (")
        query.AppendLine("    SELECT TransPoliID")
        query.AppendLine("    FROM TransaksiPoli")
        query.AppendLine("    WHERE (CONVERT(DATE, TglPoli) BETWEEN '" & Format(tglTransaksiAwal.Date, "yyyyMMdd") & "' AND '" & Format(tglTransaksiAkhir.Date, "yyyyMMdd") & "') AND Deleted = 0 AND (FlagJurnalHarianTagihan IS NULL AND FlagJurnalHarianTunai IS NULL AND FlagJurnalHarianDebet IS NULL AND FlagJurnalHarianKredit IS NULL)")
        query.AppendLine(")")
        If tipeJurnal = "Poli" Then
            query.AppendLine("SELECT SUM(tblBayar.JumlahBayar - tblBayar.Kembali) AS 'JumlahBayar', tblBayar.JenisBayar, tblBayar.kartu, tblBayar.mesin, d.JenisPoli, d.JenisTransaksi, CONVERT(DATE, t.TglPoli) AS 'Tgl Transaksi'")
        ElseIf tipeJurnal = "Transaksi" Then
            query.AppendLine("SELECT SUM(tblBayar.JumlahBayar - tblBayar.Kembali) AS 'JumlahBayar', tblBayar.JenisBayar, tblBayar.kartu, tblBayar.mesin, d.JenisTransaksi, CONVERT(DATE, t.TglPoli) AS 'Tgl Transaksi'")
        End If
        query.AppendLine("FROM (")
        query.AppendLine("    SELECT tb.TransPoliID, tb.JenisBayar, tb.JumlahBayar, tb.Kembali, tb.kartu, tb.mesin")
        query.AppendLine("    FROM TransaksiPoliBayar tb")
        query.AppendLine("    INNER JOIN FilteredTransPoli ft ON tb.TransPoliID = ft.TransPoliID")
        query.AppendLine("    WHERE tb.JumlahBayar > 0 AND tb.JenisBayar IN ('TAGIHAN', 'TUNAI', 'DEBET', 'CARD')")
        query.AppendLine("    UNION ALL")
        query.AppendLine("    SELECT tba.TransPoliID, tba.JenisBayar, tba.JumlahBayar, tba.Kembali, tba.kartu, tba.mesin")
        query.AppendLine("    FROM TransaksiPoliBayarAwal tba")
        query.AppendLine("    INNER JOIN FilteredTransPoli ft ON tba.TransPoliID = ft.TransPoliID")
        query.AppendLine("    WHERE tba.JumlahBayar > 0 AND tba.JenisBayar IN ('TAGIHAN', 'TUNAI', 'DEBET', 'CARD')")
        query.AppendLine(") AS tblBayar")
        query.AppendLine("LEFT JOIN TransaksiPoli t ON tblBayar.TransPoliID = t.TransPoliID")
        query.AppendLine("LEFT JOIN TransaksiDetail d ON t.NoUrut = d.NoUrut")
        If tipeJurnal = "Poli" Then
            query.AppendLine("GROUP BY CONVERT(DATE, t.TglPoli), d.JenisPoli, d.JenisTransaksi, tblBayar.JenisBayar, tblBayar.kartu, tblBayar.mesin")
        ElseIf tipeJurnal = "Transaksi" Then
            query.AppendLine("GROUP BY CONVERT(DATE, t.TglPoli), d.JenisTransaksi, tblBayar.JenisBayar, tblBayar.kartu, tblBayar.mesin")
        End If

        tblResult = ReadSQL(query.ToString())

        Return tblResult
    End Function

    Function GetDataUploadJurnalPoliGigi() As DataTable
        Dim tglTransaksiAwal As Date = DateTimePickerTanggalTransaksiAwal.Value
        Dim tglTransaksiAkhir As Date = DateTimePickerTanggalTransaksiAkhir.Value
        Dim tblResult As New DataTable

        Dim query As New StringBuilder()

        query.AppendLine("WITH FilteredTransGigi AS (")
        query.AppendLine("    SELECT TransGigiID")
        query.AppendLine("    FROM TransaksiGigi")
        query.AppendLine("    WHERE (CONVERT(DATE, TglGigi) BETWEEN '" & Format(tglTransaksiAwal.Date, "yyyyMMdd") & "' AND '" & Format(tglTransaksiAkhir.Date, "yyyyMMdd") & "')")
        query.AppendLine("      AND Deleted = 0 AND (FlagJurnalHarianTagihan IS NULL AND FlagJurnalHarianTunai IS NULL AND FlagJurnalHarianDebet IS NULL AND FlagJurnalHarianKredit IS NULL)")
        query.AppendLine(")")
        If tipeJurnal = "Poli" Then
            query.AppendLine("SELECT SUM(tblBayar.JumlahBayar - tblBayar.Kembali) AS 'JumlahBayar', tblBayar.JenisBayar, tblBayar.kartu, tblBayar.mesin, d.JenisPoli, d.JenisTransaksi, CONVERT(DATE, t.TglGigi) AS 'Tgl Transaksi'")
        ElseIf tipeJurnal = "Transaksi" Then
            query.AppendLine("SELECT SUM(tblBayar.JumlahBayar - tblBayar.Kembali) AS 'JumlahBayar', tblBayar.JenisBayar, tblBayar.kartu, tblBayar.mesin, d.JenisTransaksi, CONVERT(DATE, t.TglGigi) AS 'Tgl Transaksi'")
        End If
        query.AppendLine("FROM (")
        query.AppendLine("    SELECT tb.TransGigiID, tb.JenisBayar, tb.JumlahBayar, tb.Kembali, tb.kartu, tb.mesin")
        query.AppendLine("    FROM TransaksiGigiBayar tb")
        query.AppendLine("    INNER JOIN FilteredTransGigi ft ON tb.TransGigiID = ft.TransGigiID")
        query.AppendLine("    WHERE tb.JumlahBayar > 0 AND tb.JenisBayar IN ('TAGIHAN', 'TUNAI', 'DEBET', 'CARD')")
        query.AppendLine("    UNION ALL")
        query.AppendLine("    SELECT tba.TransGigiID, tba.JenisBayar, tba.JumlahBayar, tba.Kembali, tba.kartu, tba.mesin")
        query.AppendLine("    FROM TransaksiGigiBayarAwal tba")
        query.AppendLine("    INNER JOIN FilteredTransGigi ft ON tba.TransGigiID = ft.TransGigiID")
        query.AppendLine("    WHERE tba.JumlahBayar > 0 AND tba.JenisBayar IN ('TAGIHAN', 'TUNAI', 'DEBET', 'CARD')")
        query.AppendLine(") AS tblBayar")
        query.AppendLine("LEFT JOIN TransaksiGigi t ON tblBayar.TransGigiID = t.TransGigiID")
        query.AppendLine("LEFT JOIN TransaksiDetail d ON t.NoUrut = d.NoUrut")
        If tipeJurnal = "Poli" Then
            query.AppendLine("GROUP BY CONVERT(DATE, t.TglGigi), d.JenisPoli, d.JenisTransaksi, tblBayar.JenisBayar, tblBayar.kartu, tblBayar.mesin")
        ElseIf tipeJurnal = "Transaksi" Then
            query.AppendLine("GROUP BY CONVERT(DATE, t.TglGigi), d.JenisTransaksi, tblBayar.JenisBayar, tblBayar.kartu, tblBayar.mesin")
        End If

        tblResult = ReadSQL(query.ToString())

        Return tblResult
    End Function

    Function GetDataUploadJurnalLaboratorium() As DataTable
        Dim tglTransaksiAwal As Date = DateTimePickerTanggalTransaksiAwal.Value
        Dim tglTransaksiAkhir As Date = DateTimePickerTanggalTransaksiAkhir.Value
        Dim tblResult As New DataTable

        Dim query As New StringBuilder()

        query.AppendLine("WITH FilteredTransLab AS (")
        query.AppendLine("    SELECT TransLabID")
        query.AppendLine("    FROM TransaksiLab")
        query.AppendLine("    WHERE (CONVERT(DATE, TglLab) BETWEEN '" & Format(tglTransaksiAwal.Date, "yyyyMMdd") & "' AND '" & Format(tglTransaksiAkhir.Date, "yyyyMMdd") & "')")
        query.AppendLine("      AND Deleted = 0 AND (FlagJurnalHarianTagihan IS NULL AND FlagJurnalHarianTunai IS NULL AND FlagJurnalHarianDebet IS NULL AND FlagJurnalHarianKredit IS NULL)")
        query.AppendLine("      AND SendKeu IS NOT NULL")
        query.AppendLine("      AND NoUrut LIKE '%L%'")
        query.AppendLine(")")
        If tipeJurnal = "Poli" Then
            query.AppendLine("SELECT SUM(tblBayar.JumlahBayar - tblBayar.Kembali) AS 'JumlahBayar', tblBayar.JenisBayar, tblBayar.kartu, tblBayar.mesin, d.JenisPoli, d.JenisTransaksi, CONVERT(DATE, t.TglLab) AS 'Tgl Transaksi'")
        ElseIf tipeJurnal = "Transaksi" Then
            query.AppendLine("SELECT SUM(tblBayar.JumlahBayar - tblBayar.Kembali) AS 'JumlahBayar', tblBayar.JenisBayar, tblBayar.kartu, tblBayar.mesin, d.JenisTransaksi, CONVERT(DATE, t.TglLab) AS 'Tgl Transaksi'")
        End If
        query.AppendLine("FROM (")
        query.AppendLine("    SELECT tb.TransLabID, tb.JenisBayar, tb.JumlahBayar, tb.Kembali, tb.kartu, tb.mesin")
        query.AppendLine("    FROM TransaksiLabBayar tb")
        query.AppendLine("    INNER JOIN FilteredTransLab ft ON tb.TransLabID = ft.TransLabID")
        query.AppendLine("    WHERE tb.JumlahBayar > 0 AND tb.JenisBayar IN ('TAGIHAN', 'TUNAI', 'DEBET', 'CARD')")
        query.AppendLine(") AS tblBayar")
        query.AppendLine("LEFT JOIN TransaksiLab t ON tblBayar.TransLabID = t.TransLabID")
        query.AppendLine("LEFT JOIN TransaksiDetail d ON t.NoUrut = d.NoUrut")
        If tipeJurnal = "Poli" Then
            query.AppendLine("GROUP BY CONVERT(DATE, t.TglLab), d.JenisPoli, d.JenisTransaksi, tblBayar.JenisBayar, tblBayar.kartu, tblBayar.mesin")
        ElseIf tipeJurnal = "Transaksi" Then
            query.AppendLine("GROUP BY CONVERT(DATE, t.TglLab), d.JenisTransaksi, tblBayar.JenisBayar, tblBayar.kartu, tblBayar.mesin")
        End If
        tblResult = ReadSQL(query.ToString())

        Return tblResult
    End Function
End Class