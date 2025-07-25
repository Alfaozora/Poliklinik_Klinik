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

Public Class FormSendingJurnalPendapatan
    Dim thread As System.Threading.Thread

    ' Set Connection
    Private DB_Keuangan2 As TLcon
    Private DB_Jurnal As TLcon

    Private Sub PanelTop_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelTop.Paint
        Try
            e.Graphics.DrawString("Form Sending Jurnal Pendapatan", New Font("Segoe UI Semibold", 15, FontStyle.Bold), Brushes.White, New Point(0, 0))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Find_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        SetAwal()

        ' Inisialisasi koneksi ke database MySQL
        SetConnectionFromConfig()
    End Sub

    Private Sub SetConnectionFromConfig()
        ' Set Parameter Server Online
        Dim serverOnline_IP As String = Utility.GetConfig("ServerOnline_IP")
        Dim serverOnline_UserID As String = Utility.GetConfig("ServerOnline_UserID")
        Dim serverOnline_Password As String = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerOnline_Password"), "albert")

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
    End Sub

    Private Sub SetAwal()
        Me.CenterToScreen()
        ProgressBar2.Visible = False
        ButtonSendJurnal.Enabled = True
    End Sub

    Private Sub ButtonSendJurnal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSendJurnal.Click
        thread = New System.Threading.Thread(AddressOf SendingJurnal)
        thread.Start()
    End Sub

    Private Sub SendingJurnal()
        Try
            Dim procent As Integer = 0
            Dim persen As Integer = 0
            Dim keterangan As String = ""
            Dim flag As String = ""
            Dim KetLokasi As String = ""
            Dim Nourut As String = ""
            Dim bsa As String = ""
            Dim Tnow As Date = dtprocess.Value
            Dim Tend As Date = dtend.Value
            Dim Tquery As String = ""
            Dim Tlokasigl As New DataTable
            Dim CoaPiutangPending As String = ""
            Dim CoaJenisBayar As String = ""

            Dim queryBuilder As New StringBuilder()

            queryBuilder.AppendLine("SELECT t2.JumlahBayar, t2.JenisTransaksi, t2.JenisBayar, t2.[Tanggal Transaksi]")
            queryBuilder.AppendLine("FROM (")
            queryBuilder.AppendLine("    SELECT SUM(b.JumlahBayar) AS 'JumlahBayar', 'LAB' AS 'JenisTransaksi', b.JenisBayar, CONVERT(DATE, TglLab) AS 'Tanggal Transaksi'")
            queryBuilder.AppendLine("    FROM TransaksiLab a")
            queryBuilder.AppendLine("    LEFT JOIN TransaksiLabBayar b ON a.TransLabID = b.TransLabID")
            queryBuilder.AppendLine("    WHERE a.deleted <> 1 AND a.SendKeu IS NOT NULL AND(CONVERT(DATE, TglLab) BETWEEN '" & Format(Tnow.Date, "MM/dd/yyyy") & "' AND '" & Format(Tend.Date, "MM/dd/yyyy") & "') AND b.JenisBayar = 'TAGIHAN' AND b.JumlahBayar > 0 AND a.FlagJurnalHarianTagihan IS NULL")
            queryBuilder.AppendLine("    GROUP BY b.JenisBayar, CONVERT(DATE, TglLab)")
            queryBuilder.AppendLine("    UNION")
            queryBuilder.AppendLine("    SELECT SUM(t1.Tagihan) AS 'JumlahBayar', t1.JenisTransaksi, t1.JenisBayar, t1.[Tanggal Transaksi]")
            queryBuilder.AppendLine("    FROM (")
            queryBuilder.AppendLine("        SELECT t1.TransPoliID AS 'Translabid', t1.NoJenisBayar, t1.[No Lab], CONVERT(DATE, t1.[Tanggal Transaksi]) AS 'Tanggal Transaksi', SUM(t1.Tagihan) AS 'Tagihan', t1.kartu, t1.mesin, t1.JenisTransaksi, t1.JenisBayar")
            queryBuilder.AppendLine("        FROM (")
            queryBuilder.AppendLine("            SELECT c.TransPoliIDBayar AS 'No', a.TransPoliID, c.NoJenisBayar, a.NoUrut AS 'No Lab', CONVERT(DATE, a.TglPoli) AS 'Tanggal Transaksi', c.JumlahBayar - c.Kembali AS 'Tagihan', c.kartu, c.mesin, 'POLI' AS 'JenisTransaksi', c.JenisBayar")
            queryBuilder.AppendLine("            FROM TransaksiPoli a")
            queryBuilder.AppendLine("            LEFT JOIN TransaksiPoliBayar c ON a.TransPoliID = c.TransPoliID")
            queryBuilder.AppendLine("            WHERE a.deleted <> 1 AND c.JenisBayar = 'TAGIHAN' AND c.JumlahBayar > 0 AND FlagJurnalHarianTagihan IS NULL")
            queryBuilder.AppendLine("            UNION")
            queryBuilder.AppendLine("            SELECT c.TransPoliIDBayar AS 'No', a.TransPoliID, c.NoJenisBayar, a.NoUrut AS 'No Lab', CONVERT(DATE, a.TglPoli) AS 'Tanggal Transaksi', c.JumlahBayar - c.Kembali AS 'Tagihan', c.kartu, c.mesin, 'POLI' AS 'JenisTransaksi', c.JenisBayar")
            queryBuilder.AppendLine("            FROM TransaksiPoli a")
            queryBuilder.AppendLine("            LEFT JOIN TransaksiPoliBayarAwal c ON a.TransPoliID = c.TransPoliID")
            queryBuilder.AppendLine("            WHERE a.deleted <> 1 AND c.JenisBayar = 'TAGIHAN' AND c.JumlahBayar > 0 AND FlagJurnalHarianTagihan IS NULL")
            queryBuilder.AppendLine("        ) AS t1")
            queryBuilder.AppendLine("        GROUP BY t1.TransPoliID, t1.NoJenisBayar, t1.[No Lab], CONVERT(DATE, t1.[Tanggal Transaksi]), t1.kartu, t1.mesin, t1.JenisTransaksi, t1.JenisBayar")
            queryBuilder.AppendLine("        UNION")
            queryBuilder.AppendLine("        SELECT t1.TransGigiID AS 'Translabid', t1.NoJenisBayar, t1.[No Lab], CONVERT(DATE, t1.[Tanggal Transaksi]) AS 'Tanggal Transaksi', SUM(t1.Tagihan) AS 'Tagihan', t1.kartu, t1.mesin, t1.JenisTransaksi, t1.JenisBayar")
            queryBuilder.AppendLine("        FROM (")
            queryBuilder.AppendLine("            SELECT c.TransGigiIDBayar AS 'No', a.TransGigiID, c.NoJenisBayar, a.NoUrut AS 'No Lab', CONVERT(DATE, a.TglGigi) AS 'Tanggal Transaksi', c.JumlahBayar - c.Kembali AS 'Tagihan', c.kartu, c.mesin, 'GIGI' AS 'JenisTransaksi', c.JenisBayar")
            queryBuilder.AppendLine("            FROM TransaksiGigi a")
            queryBuilder.AppendLine("            LEFT JOIN TransaksiGigiBayar c ON a.TransGigiID = c.TransGigiID")
            queryBuilder.AppendLine("            WHERE a.deleted <> 1 AND c.JenisBayar = 'TAGIHAN' AND c.JumlahBayar > 0 AND FlagJurnalHarianTagihan IS NULL")
            queryBuilder.AppendLine("            UNION")
            queryBuilder.AppendLine("            SELECT c.TransGigiIDBayar AS 'No', a.TransGigiID, c.NoJenisBayar, a.NoUrut AS 'No Lab', CONVERT(DATE, a.TglGigi) AS 'Tanggal Transaksi', c.JumlahBayar - c.Kembali AS 'Tagihan', c.kartu, c.mesin, 'GIGI' AS 'JenisTransaksi', c.JenisBayar")
            queryBuilder.AppendLine("            FROM TransaksiGigi a")
            queryBuilder.AppendLine("            LEFT JOIN TransaksiGigiBayarAwal c ON a.TransGigiID = c.TransGigiID")
            queryBuilder.AppendLine("            WHERE a.deleted <> 1 AND c.JenisBayar = 'TAGIHAN' AND c.JumlahBayar > 0 AND FlagJurnalHarianTagihan IS NULL")
            queryBuilder.AppendLine("        ) AS t1")
            queryBuilder.AppendLine("        GROUP BY t1.TransGigiID, t1.NoJenisBayar, t1.[No Lab], CONVERT(DATE, t1.[Tanggal Transaksi]), t1.kartu, t1.mesin, t1.JenisTransaksi, t1.JenisBayar")
            queryBuilder.AppendLine("        UNION")
            queryBuilder.AppendLine("        SELECT a.TransAdminID AS 'Translabid', c.NoJenisBayar, CAST(a.TransAdminID AS CHAR(10)) AS 'No Lab', CONVERT(DATE, a.TindakanTgl) AS 'Tanggal Transaksi', c.JumlahBayar - c.Kembali AS 'Tagihan', c.mesin, c.kartu, 'DLL' AS 'JenisTransaksi', c.JenisBayar")
            queryBuilder.AppendLine("        FROM TransaksiAdmin a")
            queryBuilder.AppendLine("        LEFT JOIN TransaksiAdminBayar c ON a.TransAdminID = c.TransAdminID")
            queryBuilder.AppendLine("        WHERE a.deleted <> 1 AND c.JenisBayar = 'TAGIHAN' AND c.JumlahBayar > 0 AND FlagJurnalHarianTagihan IS NULL")
            queryBuilder.AppendLine("    ) AS t1")
            queryBuilder.AppendLine("    WHERE (CONVERT(DATE, t1.[Tanggal Transaksi]) BETWEEN '" & Format(Tnow.Date, "MM/dd/yyyy") & "' AND '" & Format(Tend.Date, "MM/dd/yyyy") & "')")
            queryBuilder.AppendLine("    GROUP BY t1.JenisTransaksi, t1.JenisBayar, t1.[Tanggal Transaksi]")
            queryBuilder.AppendLine(") AS t2")
            queryBuilder.AppendLine("ORDER BY t2.[Tanggal Transaksi], t2.JenisTransaksi")

            'Tquery = "SELECT t2.JumlahBayar, t2.JenisTransaksi, t2.JenisBayar, t2.[Tanggal Transaksi] FROM (SELECT SUM(b.JumlahBayar) AS 'JumlahBayar', 'LAB' AS 'JenisTransaksi', b.JenisBayar, CONVERT(date, TglLab) AS 'Tanggal Transaksi' FROM TransaksiLab a LEFT JOIN TransaksiLabBayar b ON a.TransLabID = b.TransLabID" & _
            '         " WHERE a.deleted <> 1 AND a.SendKeu IS NOT NULL AND (CONVERT(DATE, TglLab) BETWEEN '" & Format(Tnow.Date, "MM/dd/yyyy") & "' AND '" & Format(Tend.Date, "MM/dd/yyyy") & "') AND b.JenisBayar = 'TAGIHAN' AND a.FlagJurnalHarianTagihan IS NULL GROUP BY b.JenisBayar, CONVERT(date, TglLab)" & _
            '         " UNION" & _
            '         " SELECT SUM(t1.Tagihan) AS 'JumlahBayar', t1.JenisTransaksi, t1.JenisBayar, t1.[Tanggal Transaksi] FROM (" & _
            '         " SELECT t1.TransPoliID AS 'Translabid', t1.NoJenisBayar, t1.[No Lab], CONVERT(date, t1.[Tanggal Transaksi]) AS 'Tanggal Transaksi', SUM(t1.Tagihan) AS 'Tagihan', t1.kartu, t1.mesin, t1.JenisTransaksi, t1.JenisBayar" & _
            '         " FROM (SELECT c.TransPoliIDBayar AS 'No', a.TransPoliID, c.NoJenisBayar, a.NoUrut AS 'No Lab', CONVERT(date, a.TglPoli) AS 'Tanggal Transaksi', c.JumlahBayar-c.Kembali AS 'Tagihan', c.kartu, c.mesin, 'POLI' AS 'JenisTransaksi', c.JenisBayar" & _
            '         " FROM TransaksiPoli a LEFT JOIN TransaksiPoliBayar c ON a.TransPoliID=c.TransPoliID where a.deleted <> 1 AND c.JenisBayar='TAGIHAN' AND FlagJurnalHarianTagihan IS NULL" & _
            '         " UNION SELECT c.TransPoliIDBayar AS 'No', a.TransPoliID, c.NoJenisBayar, a.NoUrut AS 'No Lab', CONVERT(date, a.TglPoli) AS 'Tanggal Transaksi', c.JumlahBayar-c.Kembali AS 'Tagihan', c.kartu, c.mesin, 'POLI' AS 'JenisTransaksi', c.JenisBayar" & _
            '         " FROM TransaksiPoli a LEFT JOIN TransaksiPoliBayarAwal c ON a.TransPoliID=c.TransPoliID where a.deleted <> 1 AND c.JenisBayar='TAGIHAN' AND FlagJurnalHarianTagihan IS NULL) AS t1 group by t1.TransPoliID, t1.NoJenisBayar, t1.[No Lab], CONVERT(DATE, t1.[Tanggal Transaksi]), t1.kartu, t1.mesin, t1.JenisTransaksi, t1.JenisBayar" & _
            '         " UNION SELECT a.TransGigiID AS 'Translabid', c.NoJenisBayar, a.NoUrut AS 'No Lab', CONVERT(date, a.TglGigi) AS 'Tanggal Transaksi', c.JumlahBayar-c.Kembali AS 'Tagihan', c.mesin, c.kartu, 'GIGI' AS 'JenisTransaksi', c.JenisBayar" & _
            '         " FROM TransaksiGigi a LEFT JOIN TransaksiGigiBayar c ON a.TransGigiID=c.TransGigiID where a.deleted <> 1 AND c.JenisBayar='TAGIHAN' AND FlagJurnalHarianTagihan IS NULL" & _
            '         " UNION SELECT a.TransAdminID AS 'Translabid', c.NoJenisBayar, CAST(a.TransAdminID AS CHAR(10)) AS 'No Lab', CONVERT(date, a.TindakanTgl) AS 'Tanggal Transaksi', c.JumlahBayar-c.Kembali AS 'Tagihan', c.mesin, c.kartu, 'DLL' AS 'JenisTransaksi', c.JenisBayar" & _
            '         " FROM TransaksiAdmin a LEFT JOIN TransaksiAdminBayar c ON a.TransAdminID=c.TransAdminID where a.deleted <> 1 AND c.JenisBayar='TAGIHAN' AND FlagJurnalHarianTagihan IS NULL) AS t1" & _
            '         " WHERE (CONVERT(date, t1.[Tanggal Transaksi]) BETWEEN '" & Format(Tnow.Date, "MM/dd/yyyy") & "' AND '" & Format(Tend.Date, "MM/dd/yyyy") & "')" & _
            '         " GROUP BY t1.JenisTransaksi, t1.JenisBayar, t1.[Tanggal Transaksi]) AS t2 ORDER BY t2.[Tanggal Transaksi], t2.JenisTransaksi"

            Dim Tloc As String = ReadSQLNIK("select StrValue from MsConfig where ConfigName='NoPoli'")
            Dim TKode As String = ReadSQLNIK("SELECT RIGHT(StrValue, 3) FROM MsConfig where ConfigName='KodeInvoiceLab'")
            Dim TKodeBarcode As String = ReadSQLNIK("SELECT StrValue FROM MsConfig where ConfigName='KodeBarcode'")
            Dim TblsGL As DataTable = ReadSQL(queryBuilder.ToString())
            If TblsGL.Rows.Count > 0 Then
                ProgressBar2.Visible = True
                ButtonSendJurnal.Enabled = False

                For Each Trow As DataRow In TblsGL.Rows
                    persen = persen + 1
                    procent = persen * 100 / TblsGL.Rows.Count
                    ProgressBar2.Value = procent

                    Tlokasigl = ReadThemysql("SELECT a.locgl, a.locket FROM masterlokasigl a WHERE a.loc='" & Tloc & "' AND a.jenistransaksi='" & Trow("JenisTransaksi") & "'", DB_Keuangan2)
                    Dim Trowlokasigl As DataRow = Tlokasigl.Rows(0)
                    bsa = Trowlokasigl("locgl")
                    KetLokasi = Trowlokasigl("locket")

                    Nourut = ReadSQLNIK("SELECT myFlag FROM getFlagPendapatan('%" & TKodeBarcode & DateTime.ParseExact(Trow("Tanggal Transaksi"), "M/d/yyyy", Nothing).ToString("yyMM") & "%')")

                    If IsDBNull(Nourut) = False And Nourut <> "" And Nourut <> "-" Then
                        flag = "" & TKodeBarcode & DateTime.ParseExact(Trow("Tanggal Transaksi"), "M/d/yyyy", Nothing).ToString("yyMM") & TKode & Nourut.ToString().PadLeft(4, "0") & ""
                    Else
                        flag = "" & TKodeBarcode & DateTime.ParseExact(Trow("Tanggal Transaksi"), "M/d/yyyy", Nothing).ToString("yyMM") & TKode & "0001"
                    End If

                    keterangan = "TERIMA - TAGIHAN " & KetLokasi & " " & DateTime.ParseExact(Trow("Tanggal Transaksi"), "M/d/yyyy", Nothing).ToString("dd/MM/yyyy") & ""

                    'Jenis Transaksi
                    If Trow("JenisTransaksi").ToString.Trim = "DLL" Then
                        CoaJenisBayar = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPendapatanAdmin'", DB_Keuangan2)
                        CoaPiutangPending = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPiutangPendingAdmin'", DB_Keuangan2)
                    ElseIf Trow("JenisTransaksi").ToString.Trim = "GIGI" Then
                        CoaJenisBayar = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPendapatanGigi'", DB_Keuangan2)
                        CoaPiutangPending = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPiutangPendingGigi'", DB_Keuangan2)
                    ElseIf Trow("JenisTransaksi").ToString.Trim = "LAB" Then
                        CoaJenisBayar = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPendapatanLab'", DB_Keuangan2)
                        CoaPiutangPending = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPiutangPendingLab'", DB_Keuangan2)
                    ElseIf Trow("JenisTransaksi").ToString.Trim = "POLI" Then
                        CoaJenisBayar = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPendapatanKlinik'", DB_Keuangan2)
                        CoaPiutangPending = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPiutangPendingKlinik'", DB_Keuangan2)
                    End If

                    WriteThemysql("SELECT F_MakeUMH('" & flag & "', 'out', '', '" & DateTime.ParseExact(Trow("Tanggal Transaksi"), "M/d/yyyy", Nothing).ToString("yyyy-MM-dd") & "', '" & CoaJenisBayar & "', '" & CoaPiutangPending & "', 'IDR', 1, " & CDbl(Trow("JumlahBayar")) & ", '" & keterangan.ToUpper() & "', '1', 1, '', '" & keterangan.ToUpper() & "', '', '', '" & bsa & "', 4, " & CDbl(Trow("JumlahBayar")) & ", 'K')", DB_Jurnal)

                    'Flag Ke Transaksi
                    If Trow("JenisTransaksi").ToString.Trim = "LAB" Then
                        WriteSQL("UPDATE TransaksiLab SET FlagJurnalHarianTagihan = '" & flag & "' WHERE deleted <> 1 AND SendKeu IS NOT NULL AND (CONVERT(DATE, TglLab) = '" & DateTime.ParseExact(Trow("Tanggal Transaksi"), "M/d/yyyy", Nothing).ToString("yyyy-MM-dd") & "') AND FlagJurnalHarianTagihan IS NULL AND TransLabID in (SELECT TransLabID FROM TransaksiLabBayar WHERE JenisBayar = 'TAGIHAN')", 4)
                    ElseIf Trow("JenisTransaksi").ToString.Trim = "GIGI" Then
                        WriteSQL("UPDATE TransaksiGigi SET FlagJurnalHarianTagihan = '" & flag & "' WHERE deleted <> 1 AND FlagJurnalHarianTagihan IS NULL AND (CONVERT(DATE, TglGigi) = '" & DateTime.ParseExact(Trow("Tanggal Transaksi"), "M/d/yyyy", Nothing).ToString("yyyy-MM-dd") & "') AND (TransGigiID in (SELECT TransGigiID FROM TransaksiGigiBayar WHERE JenisBayar = 'TAGIHAN') OR TransGigiID in (SELECT TransGigiID FROM TransaksiGigiBayarAwal WHERE JenisBayar = 'TAGIHAN'))", 4)
                    ElseIf Trow("JenisTransaksi").ToString.Trim = "DLL" Then
                        WriteSQL("UPDATE TransaksiAdmin SET FlagJurnalHarianTagihan = '" & flag & "' WHERE deleted <> 1 AND FlagJurnalHarianTagihan IS NULL  AND (CONVERT(DATE, TindakanTgl) = '" & DateTime.ParseExact(Trow("Tanggal Transaksi"), "M/d/yyyy", Nothing).ToString("yyyy-MM-dd") & "') AND TransAdminID in (SELECT TransAdminID FROM TransaksiAdminBayar WHERE JenisBayar = 'TAGIHAN')", 4)
                    ElseIf Trow("JenisTransaksi").ToString.Trim = "POLI" Then
                        WriteSQL("UPDATE TransaksiPoli SET FlagJurnalHarianTagihan = '" & flag & "' WHERE deleted <> 1 AND FlagJurnalHarianTagihan IS NULL AND (CONVERT(DATE, TglPoli) = '" & DateTime.ParseExact(Trow("Tanggal Transaksi"), "M/d/yyyy", Nothing).ToString("yyyy-MM-dd") & "') AND (TransPoliID in (SELECT TransPoliID FROM TransaksiPoliBayar WHERE JenisBayar = 'TAGIHAN') OR TransPoliID in (SELECT TransPoliID FROM TransaksiPoliBayarAwal WHERE JenisBayar = 'TAGIHAN'))", 4)
                    End If

                    'Flag Ke Transaksi
                    If Trow("JenisTransaksi").ToString.Trim = "LAB" Then
                        WriteSQL("UPDATE TransaksiLab SET FlagJurnalHarianTagihan = '" & flag & "' WHERE deleted <> 1 AND SendKeu IS NOT NULL AND (CONVERT(DATE, TglLab) = '" & DateTime.ParseExact(Trow("Tanggal Transaksi"), "M/d/yyyy", Nothing).ToString("yyyy-MM-dd") & "') AND FlagJurnalHarianTagihan IS NULL AND TransLabID in (SELECT TransLabID FROM TransaksiLabBayar WHERE JenisBayar = 'TAGIHAN')", 4)
                    ElseIf Trow("JenisTransaksi").ToString.Trim = "GIGI" Then
                        WriteSQL("UPDATE TransaksiGigi SET FlagJurnalHarianTagihan = '" & flag & "' WHERE deleted <> 1 AND FlagJurnalHarianTagihan IS NULL AND (CONVERT(DATE, TglGigi) = '" & DateTime.ParseExact(Trow("Tanggal Transaksi"), "M/d/yyyy", Nothing).ToString("yyyy-MM-dd") & "') AND (TransGigiID in (SELECT TransGigiID FROM TransaksiGigiBayar WHERE JenisBayar = 'TAGIHAN') OR TransGigiID in (SELECT TransGigiID FROM TransaksiGigiBayarAwal WHERE JenisBayar = 'TAGIHAN'))", 4)
                    ElseIf Trow("JenisTransaksi").ToString.Trim = "DLL" Then
                        WriteSQL("UPDATE TransaksiAdmin SET FlagJurnalHarianTagihan = '" & flag & "' WHERE deleted <> 1 AND FlagJurnalHarianTagihan IS NULL  AND (CONVERT(DATE, TindakanTgl) = '" & DateTime.ParseExact(Trow("Tanggal Transaksi"), "M/d/yyyy", Nothing).ToString("yyyy-MM-dd") & "') AND TransAdminID in (SELECT TransAdminID FROM TransaksiAdminBayar WHERE JenisBayar = 'TAGIHAN')", 4)
                    ElseIf Trow("JenisTransaksi").ToString.Trim = "POLI" Then
                        WriteSQL("UPDATE TransaksiPoli SET FlagJurnalHarianTagihan = '" & flag & "' WHERE deleted <> 1 AND FlagJurnalHarianTagihan IS NULL AND (CONVERT(DATE, TglPoli) = '" & DateTime.ParseExact(Trow("Tanggal Transaksi"), "M/d/yyyy", Nothing).ToString("yyyy-MM-dd") & "') AND (TransPoliID in (SELECT TransPoliID FROM TransaksiPoliBayar WHERE JenisBayar = 'TAGIHAN') OR TransPoliID in (SELECT TransPoliID FROM TransaksiPoliBayarAwal WHERE JenisBayar = 'TAGIHAN'))", 4)
                    End If

                    'Flag Ke Transaksi
                    If Trow("JenisTransaksi").ToString.Trim = "LAB" Then
                        WriteSQL("UPDATE TransaksiLab SET FlagJurnalHarianTagihan = '" & flag & "' WHERE deleted <> 1 AND SendKeu IS NOT NULL AND (CONVERT(DATE, TglLab) = '" & DateTime.ParseExact(Trow("Tanggal Transaksi"), "M/d/yyyy", Nothing).ToString("yyyy-MM-dd") & "') AND FlagJurnalHarianTagihan IS NULL AND TransLabID in (SELECT TransLabID FROM TransaksiLabBayar WHERE JenisBayar = 'TAGIHAN')", 4)
                    ElseIf Trow("JenisTransaksi").ToString.Trim = "GIGI" Then
                        WriteSQL("UPDATE TransaksiGigi SET FlagJurnalHarianTagihan = '" & flag & "' WHERE deleted <> 1 AND FlagJurnalHarianTagihan IS NULL AND (CONVERT(DATE, TglGigi) = '" & DateTime.ParseExact(Trow("Tanggal Transaksi"), "M/d/yyyy", Nothing).ToString("yyyy-MM-dd") & "') AND (TransGigiID in (SELECT TransGigiID FROM TransaksiGigiBayar WHERE JenisBayar = 'TAGIHAN') OR TransGigiID in (SELECT TransGigiID FROM TransaksiGigiBayarAwal WHERE JenisBayar = 'TAGIHAN'))", 4)
                    ElseIf Trow("JenisTransaksi").ToString.Trim = "DLL" Then
                        WriteSQL("UPDATE TransaksiAdmin SET FlagJurnalHarianTagihan = '" & flag & "' WHERE deleted <> 1 AND FlagJurnalHarianTagihan IS NULL  AND (CONVERT(DATE, TindakanTgl) = '" & DateTime.ParseExact(Trow("Tanggal Transaksi"), "M/d/yyyy", Nothing).ToString("yyyy-MM-dd") & "') AND TransAdminID in (SELECT TransAdminID FROM TransaksiAdminBayar WHERE JenisBayar = 'TAGIHAN')", 4)
                    ElseIf Trow("JenisTransaksi").ToString.Trim = "POLI" Then
                        WriteSQL("UPDATE TransaksiPoli SET FlagJurnalHarianTagihan = '" & flag & "' WHERE deleted <> 1 AND FlagJurnalHarianTagihan IS NULL AND (CONVERT(DATE, TglPoli) = '" & DateTime.ParseExact(Trow("Tanggal Transaksi"), "M/d/yyyy", Nothing).ToString("yyyy-MM-dd") & "') AND (TransPoliID in (SELECT TransPoliID FROM TransaksiPoliBayar WHERE JenisBayar = 'TAGIHAN') OR TransPoliID in (SELECT TransPoliID FROM TransaksiPoliBayarAwal WHERE JenisBayar = 'TAGIHAN'))", 4)
                    End If

                    'Save Log
                    WriteSQL("INSERT INTO LogJurnalKeuangan (JurnalFlag,JurnalDate,JurnalBy,Status,JenisTransaksi) VALUES ('" & flag & "', getdate(), '" & PoliKlinik.Lbluser.Text & "', 'JURNAL TAGIHAN HARIAN', '" & Trow("JenisTransaksi").ToString.Trim & "')", 4)
                Next

                MsgBox("Jurnal & Data Saved.", MsgBoxStyle.Information, "Success!")
                ProgressBar2.Visible = False
                ButtonSendJurnal.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class