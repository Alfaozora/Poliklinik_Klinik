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

Public Class RekapFeeKaryawan
    Private formName As String = "REKAP FEE PRACTITIONER"

    Private Find_Poliklinik As Find.TLconnect
    Private DB_Poliklinik As TLcon

    Dim thread As System.Threading.Thread
    Dim conn As OleDbConnection
    Dim dtr As OleDbDataReader
    Dim dta As OleDbDataAdapter
    Dim cmd As OleDbCommand
    Dim dts As DataSet
    Dim excel As String
    Dim opFileDialog As New OpenFileDialog()
    Private userInput As String = PoliKlinik.Lbluser.Text

    Private Sub PanelTop_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelTop.Paint
        Try
            e.Graphics.DrawString(formName, New Font("Arial", 12, FontStyle.Bold), Brushes.White, New Point(10, 10))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub RekapFeeKaryawan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
        Me.MdiParent = PoliKlinik
        Me.Dock = DockStyle.Fill

        SetClearRekapFee()
    End Sub

    Private Sub ButtonClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClose.Click
        Me.Close()
    End Sub

    Private Sub SetClearRekapFee()
        ' Enable Button / TextBox
        ButtonFindTransaksi.BackColor = Color.FromArgb(0, 100, 200)
        ButtonFindTransaksi.Enabled = True

        DateTimeAwalTransaksi.Enabled = True
        DateTimePickerAkhirTransaksi.Enabled = True

        RadioButtonPilihanKonsultasi.Enabled = True
        RadioButtonPilihanTindakan.Enabled = True
        RadioButtonPelaksanaDokter.Enabled = True
        RadioButtonPelaksanaPerawat.Enabled = True

        TextBoxPelaksanaID.ResetText()
        TextBoxNamaPelaksana.ResetText()
        RadioButtonPilihanKonsultasi.Checked = True
        GridViewTransaksi.Columns.Clear()

        DateTimeAwalTransaksi.Value = DateAndTime.Now
        DateTimePickerAkhirTransaksi.Value = DateAndTime.Now
    End Sub

    Private Sub ButtonFindPractitioner_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFindPractitioner.Click
        Dim sqlQuery As String = ""
        Dim sqlQueryOrderBy As String = " ORDER BY Nama"

        If RadioButtonPelaksanaDokter.Checked = True Then
            sqlQuery = "SELECT ID, Nama, Jenis FROM MasterDokter WHERE Jenis LIKE '%Dokter%' AND StatusAktif = 1"
        ElseIf RadioButtonPelaksanaPerawat.Checked = True Then
            sqlQuery = "SELECT ID, Nama, Jenis FROM MasterDokter WHERE Jenis LIKE '%Perawat%' AND StatusAktif = 1"
        End If

        Find.Show()
        Find.Query(sqlQuery, sqlQueryOrderBy, "FindPractitionerRekapFeeKaryawan", 2)
    End Sub

    Public Sub LoadPractitioner(ByRef rowPractitioner As DataRowView)
        TextBoxPelaksanaID.Text = rowPractitioner("ID")
        TextBoxNamaPelaksana.Text = rowPractitioner("Nama")
    End Sub

    Private Sub ButtonFindTransaksi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFindTransaksi.Click
        If ValidasiInputPractitioner() = True Then
            If RadioButtonPilihanKonsultasi.Checked = True Then
                ViewListKonsultasi()
            ElseIf RadioButtonPilihanKonsultasi.Checked = False Then
                ViewListTindakan()
            End If
        End If
    End Sub

    Function ValidasiInputPractitioner() As Boolean
        If DateTimePickerAkhirTransaksi.Value < DateTimeAwalTransaksi.Value Then
            MsgBox("Tanggal akhir tidak boleh melebihi tanggal mulai.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        If TextBoxPelaksanaID.Text = "" Then
            MsgBox("Pilih practitioner terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        Return True
    End Function

    Private Sub ViewListKonsultasi()
        Dim BatasPasienJaminanHarian As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'BatasPasienJaminanHarian'")
        Dim FeePasienPoliUmum As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'FeePasienPoliUmum'")
        Dim FeePasienPoliJaminan As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'FeePasienPoliJaminan'")

        SetGridKonsultasi()

        Dim startP As DateTime = New DateTime(DateTimeAwalTransaksi.Value.Year, DateTimeAwalTransaksi.Value.Month, DateTimeAwalTransaksi.Value.Day)
        Dim endP As DateTime = New DateTime(DateTimePickerAkhirTransaksi.Value.Year, DateTimePickerAkhirTransaksi.Value.Month, DateTimePickerAkhirTransaksi.Value.Day)
        Dim CurrD As DateTime = startP

        Dim queryStringPasienUmum As New StringBuilder()
        Dim queryStringPasienJaminan As New StringBuilder()

        queryStringPasienUmum.AppendLine("SELECT CONVERT(DATE, t2.tglpoli) AS 'Tgl Transaksi', COUNT(t2.NoUrut) AS 'Jumlah Transaksi'")
        queryStringPasienUmum.AppendLine("FROM (")
        queryStringPasienUmum.AppendLine("    SELECT a.NoUrut, CONVERT(DATE, a.TglPoli) AS TglPoli, a.UpdateBy, c.StatusFeeKonsultasi, c.JenisDokter, c.JenisTindakan, a.Deleted, a.KodeDokter")
        queryStringPasienUmum.AppendLine("    FROM TransaksiPoli a")
        queryStringPasienUmum.AppendLine("    LEFT JOIN TransaksiPoliDetail b ON a.TransPoliID = b.TransPoliID")
        queryStringPasienUmum.AppendLine("    LEFT JOIN MasterTindakan c ON b.TindakanID = c.TindakanID")
        queryStringPasienUmum.AppendLine("    LEFT JOIN TransaksiPoliBayarAwal d ON a.TransPoliID = d.TransPoliID")
        queryStringPasienUmum.AppendLine("    WHERE b.NettBayar <> 0 AND b.awal = 1 AND b.DeletedDate IS NULL")
        queryStringPasienUmum.AppendLine("    AND ((d.JenisBayar <> 'TAGIHAN' AND d.JenisBayar IS NOT NULL) OR d.NoJenisBayar LIKE '%TRANSFER%')")
        queryStringPasienUmum.AppendLine("    AND c.JenisTindakan = 'Konsultasi Dokter Umum'")
        queryStringPasienUmum.AppendLine("    AND (b.GroupBayar IS NULL OR b.GroupBayar = '')")
        queryStringPasienUmum.AppendLine("    UNION")
        queryStringPasienUmum.AppendLine("    SELECT a.NoUrut, CONVERT(DATE, a.TglPoli) AS TglPoli, a.UpdateBy, c.StatusFeeKonsultasi, c.JenisDokter, c.JenisTindakan, a.Deleted, a.KodeDokter")
        queryStringPasienUmum.AppendLine("    FROM TransaksiPoli a")
        queryStringPasienUmum.AppendLine("    LEFT JOIN TransaksiPoliDetail b ON a.TransPoliID = b.TransPoliID")
        queryStringPasienUmum.AppendLine("    LEFT JOIN MasterTindakan c ON b.TindakanID = c.TindakanID")
        queryStringPasienUmum.AppendLine("    LEFT JOIN TransaksiPoliBayar d ON a.TransPoliID = d.TransPoliID AND b.GroupBayar = d.GroupBayar")
        queryStringPasienUmum.AppendLine("    WHERE b.NettBayar <> 0 AND b.awal = 0 AND b.DeletedDate IS NULL")
        queryStringPasienUmum.AppendLine("    AND ((d.GroupBayar IS NOT NULL AND (d.JenisBayar <> 'TAGIHAN' OR d.NoJenisBayar LIKE '%TRANSFER%'))")
        queryStringPasienUmum.AppendLine("    AND c.JenisTindakan = 'Konsultasi Dokter Umum')")
        queryStringPasienUmum.AppendLine(") AS t2")
        queryStringPasienUmum.AppendLine("WHERE t2.KodeDokter = '" & TextBoxPelaksanaID.Text & "'")
        queryStringPasienUmum.AppendLine("AND t2.StatusFeeKonsultasi = '1'")
        queryStringPasienUmum.AppendLine("AND t2.jenisdokter LIKE '%Dokter%'")
        queryStringPasienUmum.AppendLine("AND t2.deleted = 0")
        queryStringPasienUmum.AppendLine("AND (t2.TglPoli BETWEEN '" & startP & "' and '" & endP & "')")
        queryStringPasienUmum.AppendLine("GROUP BY CONVERT(DATE, t2.TglPoli)")

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
                                 "WHERE t2.KodeDokter = '" & TextBoxPelaksanaID.Text & "' AND t2.StatusFeeKonsultasi='1' AND t2.jenisdokter LIKE '%Dokter%' AND t2.deleted=0 AND(t2.tglpoli BETWEEN '" & startP & "' and '" & endP & "') " & _
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
                                     "WHERE t2.KodeDokter = '" & TextBoxPelaksanaID.Text & "' AND t2.StatusFeeKonsultasi='1' AND t2.jenisdokter LIKE '%Dokter%' AND t2.deleted=0 AND(t2.tglpoli BETWEEN '" & startP & "' and '" & endP & "') " & _
                                     "GROUP BY CONVERT(DATE, t2.tglpoli)"

        Dim tbls_umum As DataTable = ReadSQL(sql_umum)

        Dim tbls_jaminan As DataTable = ReadSQL(sql_jaminan)

        Dim tbls_lab As DataTable = ReadSQL("select CONVERT(DATE, a.TglLab) as 'Tgl Transaksi', COUNT(a.NoUrut) as 'Jumlah Transaksi' " & _
                                            "FROM TransaksiLab a " & _
                                            "LEFT JOIN TransaksiLabFisik b on a.NoUrut = b.NoUrut " & _
                                            "WHERE b.FisikKet = 'Dokterpelaksana' and b.Result like '%" & TextBoxNamaPelaksana.Text & "%' and a.deleted = 0 and (CONVERT(DATE, a.TglLab) between '" & startP & "' and '" & endP & "') " & _
                                            "group by CONVERT(DATE, TglLab)")

        Dim tbls_closed As DataTable = ReadSQL("select CONVERT(date, TglTransaksi) as 'TglTransaksi' FROM RekapFeeKonsultasi WHERE jenistransaksi = 'Konsultasi' and (CONVERT(date, TglTransaksi) between '" & startP & "' and '" & endP & "') and KodeKaryawan = '" & TextBoxPelaksanaID.Text & "'")

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
                    Tnew("Status") = "CLOSED"
                Else
                    Tnew("Checked") = False
                    Tnew("Status") = "-"
                End If
                Tdata.Rows.Add(Tnew)
            End If

            CurrD = CurrD.AddDays(1)
        End While

        If Tdata.Rows.Count > 0 Then
            ' Disable Button & TextBox
            ButtonFindTransaksi.BackColor = Color.FromArgb(225, 225, 225)
            ButtonFindTransaksi.Enabled = False

            DateTimeAwalTransaksi.Enabled = False
            DateTimePickerAkhirTransaksi.Enabled = False
            RadioButtonPilihanTindakan.Enabled = False

            If RadioButtonPelaksanaDokter.Checked = True Then
                RadioButtonPelaksanaPerawat.Enabled = False
            ElseIf RadioButtonPelaksanaPerawat.Checked = True Then
                RadioButtonPelaksanaDokter.Enabled = False
            End If
        End If

        GridControlTransaksi.DataSource = Tdata
    End Sub

    Private Sub SetGridKonsultasi()
        Dim Tbls As DataTable = CreateTableKonsultasi()

        For Each Tcol As DataColumn In Tbls.Columns
            Tcol.ReadOnly = True
        Next

        Tbls.Columns("Checked").ReadOnly = False

        GridControlTransaksi.DataSource = Tbls

        GridViewTransaksi.Columns("Tgl Value").Visible = False
    End Sub

    Private Sub SetGridTindakan()
        Dim Tbls As DataTable = CreateTableTindakan()

        For Each Tcol As DataColumn In Tbls.Columns
            Tcol.ReadOnly = True
        Next

        Tbls.Columns("Checked").ReadOnly = False

        GridControlTransaksi.DataSource = Tbls

        GridViewTransaksi.Columns("Tgl Value").Visible = False
        GridViewTransaksi.Columns("Transaksi ID").Visible = False
    End Sub

    Function CreateTableTindakan() As DataTable
        Dim Tbls As New DataTable

        insertRowToTbls(Tbls, "Typstring", "Transaksi ID")
        insertRowToTbls(Tbls, "Typstring", "Tgl Transaksi")
        insertRowToTbls(Tbls, "Typstring", "Tgl Value")
        insertRowToTbls(Tbls, "Typstring", "No Transaksi")
        insertRowToTbls(Tbls, "Typstring", "Nama Pasien")
        insertRowToTbls(Tbls, "Typstring", "Tindakan")
        insertRowToTbls(Tbls, "tyinterger", "Nominal Bayar")

        insertRowToTbls(Tbls, "tyinterger", "Nominal BHP")
        insertRowToTbls(Tbls, "tyinterger", "Status BHP")
        insertRowToTbls(Tbls, "tyinterger", "Total Fee")
        insertRowToTbls(Tbls, "Typstring", "Status")
        insertRowToTbls(Tbls, "typchecked", "Checked")

        Return Tbls
    End Function

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

    Private Sub ViewListTindakan()
        Dim tglTransaksiAwal As Date = DateTimeAwalTransaksi.Value
        Dim tglTransaksiAkhir As Date = DateTimePickerAkhirTransaksi.Value
        Dim jenisPelaksana As String = ""

        ' Set Jenis Pelaksana
        If RadioButtonPelaksanaDokter.Checked = True Then jenisPelaksana = "Dokter"
        If RadioButtonPelaksanaPerawat.Checked = True Then jenisPelaksana = "Perawat"

        SetGridTindakan()

        Dim queryString As New StringBuilder()

        queryString.AppendLine("WITH FilteredTransaksiPoli AS (")
        queryString.AppendLine("    SELECT TransPoliID, NoUrut, IDInternet, CONVERT(DATE, TglPoli) AS 'Tgl Transaksi', ClosingTindakanDokter, ClosingTindakanPerawat")
        queryString.AppendLine("    FROM TransaksiPoli")
        queryString.AppendLine("    WHERE (CONVERT(DATE, TglPoli) BETWEEN '" & Format(tglTransaksiAwal.Date, "yyyyMMdd") & "' AND '" & Format(tglTransaksiAkhir.Date, "yyyyMMdd") & "') AND Deleted=0 ")
        If jenisPelaksana = "Dokter" Then
            queryString.AppendLine("AND KodeDokter='" & TextBoxPelaksanaID.Text & "'")
        ElseIf jenisPelaksana = "Perawat" Then
            queryString.AppendLine("AND PerawatPoli='" & TextBoxNamaPelaksana.Text & "'")
        End If
        queryString.AppendLine(")")
        queryString.AppendLine("SELECT b.TransPoliIDDetail AS ID, tblTrans.[Tgl Transaksi], tblPasien.Nama, tblTrans.NoUrut, b.NamaTindakan, b.NettBayar, c.FeeDokter, c.FeePerawat, c.JenisDokter, c.StatusBHP, c.PersentaseFeeKaryawan, c.StatusPersentaseFee, c.StatusNominalFee, c.FeePerTindakan, b.TotalBayarBHP, b.ClosedFeeDokter, b.ClosedFeePerawat, tblTrans.ClosingTindakanDokter, tblTrans.ClosingTindakanPerawat")
        queryString.AppendLine("FROM FilteredTransaksiPoli tblTrans")
        queryString.AppendLine("LEFT JOIN TransaksiPoliDetail b ON tblTrans.TransPoliID=b.TransPoliID AND b.Awal=1")
        queryString.AppendLine("LEFT JOIN MasterTindakan c ON b.TindakanID=c.TindakanID")
        queryString.AppendLine("LEFT JOIN TransaksiPoliBayarAwal d ON tblTrans.TransPoliID=d.TransPoliID")
        queryString.AppendLine("LEFT JOIN MasterPasien tblPasien ON tblTrans.IDInternet=tblPasien.NoRekamMedis")
        queryString.AppendLine("WHERE b.DeletedDate IS NULL AND c.JenisTindakan NOT LIKE '%Konsul%' AND c.StatusFeeTindakan='1'")
        queryString.AppendLine("  AND (b.NettBayar > 0 OR b.KodeVoucher IS NOT NULL)")
        queryString.AppendLine("  AND (c.JenisDokter LIKE '%" & jenisPelaksana & "%' OR c.FeePerawat > 0)")
        queryString.AppendLine("  AND d.JenisBayar IN ('TUNAI', 'DEBET', 'CARD', 'VOUCHER', 'TAGIHAN')")
        queryString.AppendLine("UNION")
        queryString.AppendLine("SELECT b.TransPoliIDDetail AS ID, tblTrans.[Tgl Transaksi], tblPasien.Nama, tblTrans.NoUrut, b.NamaTindakan, b.NettBayar, c.FeeDokter, c.FeePerawat, c.JenisDokter, c.StatusBHP, c.PersentaseFeeKaryawan, c.StatusPersentaseFee, c.StatusNominalFee, c.FeePerTindakan, b.TotalBayarBHP, b.ClosedFeeDokter, b.ClosedFeePerawat, tblTrans.ClosingTindakanDokter, tblTrans.ClosingTindakanPerawat")
        queryString.AppendLine("FROM FilteredTransaksiPoli tblTrans")
        queryString.AppendLine("LEFT JOIN TransaksiPoliDetail b ON tblTrans.TransPoliID=b.TransPoliID AND b.Awal=0")
        queryString.AppendLine("LEFT JOIN MasterTindakan c ON b.TindakanID=c.TindakanID")
        queryString.AppendLine("LEFT JOIN TransaksiPoliBayar e ON tblTrans.TransPoliID=e.TransPoliID")
        queryString.AppendLine("LEFT JOIN MasterPasien tblPasien ON tblTrans.IDInternet=tblPasien.NoRekamMedis")
        queryString.AppendLine("WHERE b.DeletedDate IS NULL AND c.JenisTindakan NOT LIKE '%Konsul%' AND c.StatusFeeTindakan='1'")
        queryString.AppendLine("  AND (b.NettBayar > 0 OR b.KodeVoucher IS NOT NULL)")
        queryString.AppendLine("  AND (c.JenisDokter LIKE '%" & jenisPelaksana & "%' OR c.FeePerawat > 0)")
        queryString.AppendLine("  AND e.JenisBayar IN ('TUNAI', 'DEBET', 'CARD', 'VOUCHER', 'TAGIHAN')")

        Dim tblTindakan As DataTable = ReadSQL(queryString.ToString())
        Dim tblGridControl As DataTable = CreateTableTindakan()
        tblGridControl.Rows.Clear()

        For Each rowTindakan As DataRow In tblTindakan.Rows
            Dim NominalFee As Double = 0
            Dim NominalBHP As Double = 0
            Dim PersentaseFee As Double = 0

            Dim statusBHP As Boolean = False
            Dim statusPersentase As Boolean = False
            Dim statusNominal As Boolean = False

            If Convert.ToInt32(rowTindakan("StatusBHP")) = 1 Then statusBHP = True
            If Convert.ToInt32(rowTindakan("StatusPersentaseFee")) = 1 Then statusPersentase = True
            If Convert.ToInt32(rowTindakan("StatusNominalFee")) = 1 Then statusNominal = True

            If rowTindakan("JenisDokter").ToString.Contains(jenisPelaksana) = True Then
                ' Cek Persentase / Nominal
                If statusPersentase = True Then
                    ' Cek BHP / Non BHP
                    If statusBHP = True Then
                        NominalFee = CDbl(rowTindakan("NettBayar").ToString) - CDbl(ConvertToInteger(rowTindakan("TotalBayarBHP").ToString))
                        NominalBHP = NominalBHP + CDbl(ConvertToInteger(rowTindakan("TotalBayarBHP").ToString))
                    Else
                        NominalFee = CDbl(rowTindakan("NettBayar").ToString)
                    End If

                    ' Set Persentase Fee
                    PersentaseFee = CDbl(rowTindakan("PersentaseFeeKaryawan").ToString)

                    If jenisPelaksana = "Dokter" Then NominalFee = ((NominalFee - CDbl(rowTindakan("FeePerawat"))) * CDbl(PersentaseFee)) / 100
                    If jenisPelaksana = "Perawat" Then NominalFee = (NominalFee * CDbl(PersentaseFee)) / 100
                ElseIf statusNominal = True Then
                    If jenisPelaksana = "Dokter" Then NominalFee = CDbl(rowTindakan("FeePerTindakan").ToString) - CDbl(rowTindakan("FeePerawat"))
                    If jenisPelaksana = "Perawat" Then NominalFee = CDbl(rowTindakan("FeePerTindakan").ToString)
                End If
            ElseIf CDbl(rowTindakan("FeePerawat")) > 0 And rowTindakan("JenisDokter").ToString.Trim <> jenisPelaksana And jenisPelaksana = "Perawat" Then
                ' Jika jenis tindakan milik dokter & terdapat fee tambahan untuk perawat
                NominalFee = CDbl(rowTindakan("FeePerawat").ToString)
            End If

            Dim newRow As DataRow = tblGridControl.NewRow
            newRow("Transaksi ID") = rowTindakan("ID")
            newRow("Tgl Value") = rowTindakan("Tgl Transaksi")
            newRow("Tgl Transaksi") = Format(rowTindakan("Tgl Transaksi"), "dd") & " " & BulanIndonesia(Format(rowTindakan("Tgl Transaksi"), "MM")) & " " & Format(rowTindakan("Tgl Transaksi"), "yyyy")
            newRow("No Transaksi") = rowTindakan("NoUrut")
            newRow("Nama Pasien") = rowTindakan("Nama")
            newRow("Tindakan") = rowTindakan("NamaTindakan")
            newRow("Nominal Bayar") = rowTindakan("NettBayar")
            newRow("Nominal BHP") = NominalBHP
            newRow("Status BHP") = statusBHP
            newRow("Total Fee") = NominalFee

            If jenisPelaksana = "Dokter" Then
                If rowTindakan("ClosedFeeDokter").ToString() = True Or rowTindakan("ClosingTindakanDokter").ToString() = True Then
                    newRow("Status") = "CLOSED"
                    newRow("Checked") = True
                Else
                    newRow("Status") = "-"
                    newRow("Checked") = False
                End If
            ElseIf jenisPelaksana = "Perawat" Then
                If rowTindakan("ClosedFeePerawat").ToString() = True Or rowTindakan("ClosingTindakanPerawat").ToString() = True Then
                    newRow("Status") = "CLOSED"
                    newRow("Checked") = True
                Else
                    newRow("Status") = "-"
                    newRow("Checked") = False
                End If
            End If

            tblGridControl.Rows.Add(newRow)
        Next

        If tblGridControl.Rows.Count > 0 Then
            ' Disable Button & TextBox
            ButtonFindTransaksi.BackColor = Color.FromArgb(225, 225, 225)
            ButtonFindTransaksi.Enabled = False

            DateTimeAwalTransaksi.Enabled = False
            DateTimePickerAkhirTransaksi.Enabled = False
            RadioButtonPilihanKonsultasi.Enabled = False

            If RadioButtonPelaksanaDokter.Checked = True Then
                RadioButtonPelaksanaPerawat.Enabled = False
            ElseIf RadioButtonPelaksanaPerawat.Checked = True Then
                RadioButtonPelaksanaDokter.Enabled = False
            End If
        End If

        GridControlTransaksi.DataSource = tblGridControl
    End Sub

    Private Sub CheckBoxSelectAllOption_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxSelectAllOption.CheckedChanged
        Dim tblTransaksi As DataTable = GridControlTransaksi.DataSource

        If tblTransaksi IsNot Nothing AndAlso tblTransaksi.Rows.Count > 0 Then
            For Each rowTransaksi As DataRow In tblTransaksi.Rows
                If CheckBoxSelectAllOption.CheckState = CheckState.Checked Then
                    rowTransaksi("Checked") = True
                Else
                    If rowTransaksi("Status").ToString() <> "CLOSED" Then rowTransaksi("Checked") = False
                End If
            Next
        Else
            CheckBoxSelectAllOption.Checked = False
            MessageBox.Show("Data Tidak Ditemukan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub SaveTransaksiKonsultasi()
        Dim totalTransaksi As Integer = 0
        Dim tblTransaksi As DataTable = GridControlTransaksi.DataSource

        If tblTransaksi IsNot Nothing AndAlso tblTransaksi.Rows.Count > 0 Then
            For Each rowTransaksi As DataRow In tblTransaksi.Select("[Checked]=True")
                If rowTransaksi("Status") <> "CLOSED" Then
                    ' Insert Tabel RekapFeeKonsultasi
                    WriteSQL("INSERT INTO RekapFeeKonsultasi (JenisTransaksi, TglTransaksi, JumlahPasienUmum, JumlahPasienJaminan, JumlahPasienLab, TotalPasien, TotalFeeUmum, TotalFeeJaminan, GrandTotalFee, JenisKaryawan, KodeKaryawan, JumlahPasienJaminanDanLab, CreateDate, CreateBy) " & _
                             "VALUES ('Konsultasi', '" & rowTransaksi("Tgl Value") & "', '" & rowTransaksi("Pasien Umum") & "', '" & rowTransaksi("Pasien Jaminan") & "', '" & rowTransaksi("Pasien Lab") & "', '" & rowTransaksi("Total Pasien") & "', '" & rowTransaksi("Total Fee Umum") & "', '" & rowTransaksi("Total Fee Jaminan") & "', '" & rowTransaksi("Total Semua") & "', 'Dokter', '" & TextBoxPelaksanaID.Text & "', '" & rowTransaksi("Pasien Jaminan Dan Lab") & "', GETDATE(), '" & userInput & "')", 4)

                    ' Tambah Total Transaksi
                    totalTransaksi += 1
                End If
            Next
        End If

        If totalTransaksi > 0 Then
            MsgBox("Berhasil menyimpan data.", MsgBoxStyle.Information, "Success!")

            ' Refresh Data
            ViewListKonsultasi()
        Else
            MsgBox("Tidak ada data yang disimpan.", MsgBoxStyle.Exclamation, "Warning!")
        End If
    End Sub

    Private Sub SaveTransaksiTindakan()
        Dim totalTransaksi As Integer = 0
        Dim tblTransaksi As DataTable = GridControlTransaksi.DataSource
        Dim jenisPelaksana As String = ""

        ' Set Jenis Pelaksana
        If RadioButtonPelaksanaDokter.Checked = True Then jenisPelaksana = "Dokter"
        If RadioButtonPelaksanaPerawat.Checked = True Then jenisPelaksana = "Perawat"

        If tblTransaksi IsNot Nothing AndAlso tblTransaksi.Rows.Count > 0 And ValidasiFeeTindakan() = True Then
            For Each rowTransaksi As DataRow In tblTransaksi.Select("[Checked]=True")
                If rowTransaksi("Status") <> "CLOSED" Then
                    ' Insert Tabel RekapFeeTindakan
                    WriteSQL("INSERT INTO RekapFeeTindakan (JenisTransaksi, TglTransaksi, NoTransaksi, NamaPasien, Tindakan, NominalBayar, NominalBHP, NominalFee, JenisKaryawan, KodeKaryawan, CreateDate, CreateBy) " & _
                             "VALUES ('Tindakan', '" & rowTransaksi("Tgl Value") & "', '" & rowTransaksi("No Transaksi") & "', '" & rowTransaksi("Nama Pasien") & "', '" & rowTransaksi("Tindakan") & "', '" & rowTransaksi("Nominal Bayar") & "', '" & rowTransaksi("Nominal BHP") & "', '" & rowTransaksi("Total Fee") & "', '" & jenisPelaksana & "', '" & TextBoxPelaksanaID.Text & "', GETDATE(), '" & userInput & "')", 4)

                    ' Set Flag Tabel TransaksiPoliDetail
                    If jenisPelaksana = "Dokter" Then
                        WriteSQL("UPDATE TransaksiPoliDetail SET FeeDokter = '" & rowTransaksi("Total Fee") & "', ClosedFeeDokter = 1, ClosedDateFeeDokter = GETDATE(), ClosedByFeeDokter = '" & userInput & "' WHERE TransPoliIDDetail IN (" & rowTransaksi("Transaksi ID").ToString.Trim & ")", 4)
                    ElseIf jenisPelaksana = "Perawat" Then
                        WriteSQL("UPDATE TransaksiPoliDetail SET FeePerawat = '" & rowTransaksi("Total Fee") & "', ClosedFeePerawat = 1, ClosedDateFeePerawat = GETDATE(), ClosedByFeePerawat = '" & userInput & "' WHERE TransPoliIDDetail IN (" & rowTransaksi("Transaksi ID").ToString.Trim & ")", 4)
                    End If

                    ' Tambah Total Transaksi
                    totalTransaksi += 1
                End If
            Next
        End If

        If totalTransaksi > 0 Then
            MsgBox("Berhasil menyimpan " & totalTransaksi & " data baru.", MsgBoxStyle.Information, "Success!")

            ' Refresh Data
            ViewListTindakan()
        Else
            MsgBox("Tidak ada data yang disimpan.", MsgBoxStyle.Exclamation, "Warning!")
        End If
    End Sub

    Private Sub SaveTindakanPerawat()
        Dim totalTransaksi As Integer = 0
        Dim tblTransaksi As DataTable = GridControlTransaksi.DataSource

        If tblTransaksi IsNot Nothing AndAlso tblTransaksi.Rows.Count > 0 And ValidasiFeeTindakan() = True Then
            For Each rowTransaksi As DataRow In tblTransaksi.Select("[Checked]=True")
                If rowTransaksi("Status") <> "CLOSED" Then
                    ' Insert Tabel RekapFeeTindakan
                    WriteSQL("INSERT INTO RekapFeeTindakan (JenisTransaksi, TglTransaksi, NoTransaksi, NamaPasien, Tindakan, NominalBayar, NominalBHP, NominalFee, JenisKaryawan, KodeKaryawan, CreateDate, CreateBy) " & _
                             "VALUES ('Tindakan', '" & rowTransaksi("Tgl Value") & "', '" & rowTransaksi("No Transaksi") & "', '" & rowTransaksi("Nama Pasien") & "', '" & rowTransaksi("Tindakan") & "', '" & rowTransaksi("Nominal Bayar") & "', '" & rowTransaksi("Nominal BHP") & "', '" & rowTransaksi("Total Fee") & "', 'Dokter', '" & TextBoxPelaksanaID.Text & "', GETDATE(), '" & userInput & "')", 4)

                    ' Set Flag Tabel TransaksiPoliDetail
                    WriteSQL("UPDATE TransaksiPoliDetail SET FeeDokter = '" & rowTransaksi("Total Fee") & "', ClosedFeeDokter = 1, ClosedDateFeeDokter = GETDATE(), ClosedByFeeDokter = '" & userInput & "' WHERE TransPoliIDDetail IN (" & rowTransaksi("Transaksi ID").ToString.Trim & ")", 4)

                    ' Tambah Total Transaksi
                    totalTransaksi += 1
                End If
            Next
        End If

        If totalTransaksi > 0 Then
            MsgBox("Berhasil menyimpan " & totalTransaksi & " data baru.", MsgBoxStyle.Information, "Success!")

            ' Set Clear Data
            ViewListTindakan()
        Else
            MsgBox("Tidak ada data yang disimpan.", MsgBoxStyle.Exclamation, "Warning!")
        End If
    End Sub

    Function ValidasiFeeTindakan() As Boolean
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

        If MsgBox("Yakin ingin menyimpan data tersebut? ", MsgBoxStyle.YesNo, "Validasi.") = MsgBoxResult.No Then
            Return False
        End If

        Return True
    End Function

    Private Sub RadioButtonPelaksana_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonPelaksanaDokter.CheckedChanged, RadioButtonPelaksanaPerawat.CheckedChanged
        TextBoxPelaksanaID.ResetText()
        TextBoxNamaPelaksana.ResetText()

        If RadioButtonPelaksanaDokter.Checked = True Then
            RadioButtonPilihanKonsultasi.Checked = True
            RadioButtonPilihanKonsultasi.Enabled = True
        ElseIf RadioButtonPelaksanaPerawat.Checked = True Then
            RadioButtonPilihanTindakan.Checked = True
            RadioButtonPilihanKonsultasi.Enabled = False
        End If
    End Sub

    Private Sub ButtonSimpanRekap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSimpanRekap.Click
        If RadioButtonPilihanKonsultasi.Checked = True Then
            SaveTransaksiKonsultasi()
        ElseIf RadioButtonPilihanTindakan.Checked = True Then
            SaveTransaksiTindakan()
        End If
    End Sub

    Private Sub ButtonClearData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClearData.Click
        SetClearRekapFee()
    End Sub

    Private Sub ButtonCetakLaporan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCetakLaporan.Click
        If ValidasiInputPractitioner() = True Then
            If RadioButtonPilihanKonsultasi.Checked = True Then
                CetakLaporanKonsultasi()
            ElseIf RadioButtonPilihanTindakan.Checked = True Then
                CetakLaporanTindakan()
            End If
        End If
    End Sub

    Private Sub CetakLaporanKonsultasi()
        Dim tglTransaksiAwal As Date = DateTimeAwalTransaksi.Value
        Dim tglTransaksiAkhir As Date = DateTimePickerAkhirTransaksi.Value

        Dim queryString As New StringBuilder()

        queryString.AppendLine("SELECT CONVERT(date, TglTransaksi) as 'TglTransaksi',")
        queryString.AppendLine("       JumlahPasienUmum, JumlahPasienJaminan, JumlahPasienLab, TotalPasien,")
        queryString.AppendLine("       TotalFeeUmum, TotalFeeJaminan, GrandTotalFee, TotalBHP, JumlahPasienJaminanDanLab")
        queryString.AppendLine("FROM RekapFeeKonsultasi")
        queryString.AppendLine("WHERE JenisTransaksi = 'Konsultasi'")
        queryString.AppendLine("  AND (CONVERT(DATE, TglTransaksi) BETWEEN '" & Format(tglTransaksiAwal.Date, "yyyyMMdd") & "' AND '" & Format(tglTransaksiAkhir.Date, "yyyyMMdd") & "')")
        queryString.AppendLine("  AND JenisKaryawan = 'Dokter'")
        queryString.AppendLine("  AND KodeKaryawan = '" & TextBoxPelaksanaID.Text & "'")

        Dim tblTransaksi As DataTable = ReadSQL(queryString.ToString())

        Report = New XtraReport
        Report = XtraReport.FromFile(Application.StartupPath + "\reports\Klinik\RekapFeeKonsultasiDokter.repx", True)
        Report.DataSource = tblTransaksi

        Report.Bands.Item(BandKind.ReportHeader).Controls("lbltanggal").Text = Format(tglTransaksiAwal.Date, "dd-MM-yyyy") & " s/d " & Format(tglTransaksiAkhir.Date, "dd-MM-yyyy")
        Report.Bands.Item(BandKind.ReportHeader).Controls("lbldokter").Text = TextBoxNamaPelaksana.Text
        Report.Bands.Item(BandKind.ReportHeader).Controls("lblheader").Text = "REKAPAN FEE KONSULTASI DOKTER"
        Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:ss") & " By " & PoliKlinik.Lbluser.Text

        If tblTransaksi.Rows.Count > 0 Then
            'Report.RunDesigner()
            Report.ShowPreview()
        Else
            MsgBox("Tidak ada data yang ditampilkan.", MsgBoxStyle.Exclamation, "Warning!")
        End If
    End Sub

    Private Sub CetakLaporanTindakan()
        Dim tglTransaksiAwal As Date = DateTimeAwalTransaksi.Value
        Dim tglTransaksiAkhir As Date = DateTimePickerAkhirTransaksi.Value
        Dim jenisPelaksana As String = ""

        ' Set Jenis Pelaksana
        If RadioButtonPelaksanaDokter.Checked = True Then jenisPelaksana = "Dokter"
        If RadioButtonPelaksanaPerawat.Checked = True Then jenisPelaksana = "Perawat"

        Dim queryString As New StringBuilder()

        queryString.AppendLine("SELECT *")
        queryString.AppendLine("FROM RekapFeeTindakan a")
        queryString.AppendLine("WHERE (CONVERT(DATE, TglTransaksi) BETWEEN '" & Format(tglTransaksiAwal.Date, "yyyyMMdd") & "' AND '" & Format(tglTransaksiAkhir.Date, "yyyyMMdd") & "')")
        queryString.AppendLine("  AND a.KodeKaryawan = '" & TextBoxPelaksanaID.Text & "'")
        queryString.AppendLine("ORDER BY a.NoTransaksi, CONVERT(date, a.TglTransaksi)")

        Dim tbls As DataTable = ReadSQL(queryString.ToString())

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

        Report.Bands.Item(BandKind.ReportHeader).Controls("lbltanggal").Text = Format(tglTransaksiAwal.Date, "dd-MM-yyyy") & " s/d " & Format(tglTransaksiAkhir.Date, "dd-MM-yyyy")
        Report.Bands.Item(BandKind.ReportHeader).Controls("lbldokter").Text = TextBoxNamaPelaksana.Text
        Report.Bands.Item(BandKind.ReportHeader).Controls("lblheader").Text = "REKAPAN FEE TINDAKAN " & jenisPelaksana.ToUpper()
        Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:ss") & " By " & PoliKlinik.Lbluser.Text

        If tbls.Rows.Count > 0 Then
            'Report.RunDesigner()
            Report.ShowPreview()
        Else
            MsgBox("Tidak ada data yang ditampilkan.", MsgBoxStyle.Exclamation, "Warning!")
        End If
    End Sub

    Private Sub ButtonExportCSV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExportCSV.Click
        Dim Tbls As DataTable = GridControlTransaksi.DataSource
        If Tbls.Rows.Count > 0 Then
            Dim saveFileDialog1 As New SaveFileDialog
            saveFileDialog1.Filter = "Excel File|*.xls"
            saveFileDialog1.Title = "Save an Excel File"
            saveFileDialog1.ShowDialog()
            If saveFileDialog1.CheckPathExists = False Then
                MsgBox("Path tidak ada. Check kembali")
            Else
                If saveFileDialog1.CheckFileExists = True Then
                    MsgBox("Telah ada data dengan nama tersebut. Rubah nama save")
                Else
                    GridControlTransaksi.ExportToExcel(saveFileDialog1.FileName.ToString)
                    MsgBox("File Saved")
                End If
            End If
        End If

        'Dim tglTransaksiAwal As Date = DateTimeAwalTransaksi.Value
        'Dim tglTransaksiAkhir As Date = DateTimePickerAkhirTransaksi.Value

        'Dim Tbls As DataTable = ReadSQL("select b.NoNIP as 'Nip' , convert(varchar, getdate(), 112)  as 'Tgl Entry', SUM(a.GrandTotalFee) as 'Nilai', 'PENDAPATAN LAIN-LAIN' as 'Keterangan', 'Pendapatan' as 'Tipe' " & _
        '                                "FROM RekapFeeKonsultasi a " & _
        '                                "LEFT JOIN MasterDokter b on a.KodeKaryawan = b.ID " & _
        '                                "WHERE (CONVERT(DATE, a.TglTransaksi) BETWEEN '" & Format(tglTransaksiAwal.Date, "yyyyMMdd") & "' AND '" & Format(tglTransaksiAkhir.Date, "yyyyMMdd") & "') " & _
        '                                "group by b.NoNIP")

        'If Tbls.Rows.Count > 0 Then
        '    Dim dt As New DataTable

        '    dt.Columns.AddRange(New DataColumn() {New DataColumn("Nip", GetType(String)), _
        '                                       New DataColumn("Tgl Entry", GetType(String)), _
        '                                       New DataColumn("Nilai", GetType(String)), _
        '                                       New DataColumn("Keterangan", GetType(String)), _
        '                                       New DataColumn("Tipe", GetType(String))})

        '    dt.Rows.Add("Nip", "Tgl Entry", "Nilai", "Keterangan", "Tipe")

        '    For Each Trow As DataRow In Tbls.Rows
        '        dt.Rows.Add("" & Trow("Nip") & "", "" & Trow("Tgl Entry") & "", "" & Trow("Nilai") & "", "" & Trow("Keterangan") & "", "" & Trow("Tipe") & "")
        '    Next

        '    Dim lines() As String = Enumerable.Range(0, dt.Rows.Count).Select(Function(x) String.Join(",", Array.ConvertAll(dt.Rows(x).ItemArray, Function(o) o.ToString))).ToArray

        '    Dim nameFile As String = "File Upload_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".csv"
        '    Dim filePath As String = "D:\Data Program Poliklinik\File Rekap Fee\"

        '    If Not System.IO.Directory.Exists(filePath) Then
        '        System.IO.Directory.CreateDirectory(filePath)
        '    End If

        '    IO.File.WriteAllLines(filePath & nameFile, lines)

        '    MsgBox("Data berhasil disimpan di drive " & filePath & nameFile & ".", MsgBoxStyle.Information, "Success!")

        '    Process.Start(filePath & nameFile)
        'Else
        '    MsgBox("Tidak ada data yang ditampilkan.", MsgBoxStyle.Exclamation, "Warning!")
        'End If
    End Sub
End Class