Imports System.Text

Public Class ReportClosingBankTagihan
    ' Set Connection
    Private Find_Keuangan As Find.TLconnect
    Private Find_Omset As Find.TLconnect
    Private DB_Keuangan As TLcon
    Private DB_Omset As TLcon

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

        ' Set Find Omset (mitramedicare_omset_keuangan)
        Find_Omset.Tip = serverOnline_IP
        Find_Omset.Tid = serverOnline_UserID
        Find_Omset.Tpass = serverOnline_Password
        Find_Omset.Tdb = Utility.GetConfig("ServerOnlineOmset_DB")

        ' Set DB Keuangan 1 (mitramed_keu)
        DB_Keuangan.Tip = serverOnline_IP
        DB_Keuangan.Tid = serverOnline_UserID
        DB_Keuangan.Tpass = serverOnline_Password
        DB_Keuangan.Tdb = Utility.GetConfig("ServerOnlineKeuangan_DB")

        ' Set DB Omset (mitramedicare_omset_keuangan)
        DB_Omset.Tip = serverOnline_IP
        DB_Omset.Tid = serverOnline_UserID
        DB_Omset.Tpass = serverOnline_Password
        DB_Omset.Tdb = Utility.GetConfig("ServerOnlineOmset_DB")
    End Sub

    Private Sub SetClear()
        dtkasirakhir.Value = DateAndTime.Now
        dtkasirawal.Value = DateAndTime.Now
        RadioButtonJenisTransaksiAll.Checked = True
        rdtanggalbayar.Checked = True
    End Sub

    Private Sub ReportClosingBankTagihan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.MdiParent = PoliKlinik
        SetClear()
        SetConnectionFromConfig()
    End Sub

    Private Sub SetDataDetail(ByRef Tdb As DataTable)
        Tdb = New DataTable

        insertRowToTbls(Tdb, "typdate", "Tgl")
        insertRowToTbls(Tdb, "Typstring", "Lokasi")
        insertRowToTbls(Tdb, "Typstring", "Jenis")
        insertRowToTbls(Tdb, "Typstring", "Pembayaran")
        insertRowToTbls(Tdb, "Typstring", "Kartu")
        insertRowToTbls(Tdb, "Typstring", "Mesin")
        insertRowToTbls(Tdb, "typefloat", "Nilai")
        insertRowToTbls(Tdb, "Typstring", "TransID")
        insertRowToTbls(Tdb, "Typstring", "PasienID")
        insertRowToTbls(Tdb, "Typstring", "PasienNama")

        'select `inctgl`, `loc`, `incjenis`, `jenis`, `kartu`, `mesin`, `incnilai`, `inctransid`, `idinternet`, `pasien` from acctranspendapatandetail;
    End Sub

    Function CreateTable() As DataTable
        Dim Thasil As New DataTable

        insertRowToTbls(Thasil, "tyinterger", "no")
        insertRowToTbls(Thasil, "tyinterger", "statustransaksi")
        insertRowToTbls(Thasil, "Typstring", "statustransaksidetail")
        insertRowToTbls(Thasil, "Typstring", "company")
        insertRowToTbls(Thasil, "Typstring", "admin")
        insertRowToTbls(Thasil, "Typstring", "RekapID")
        insertRowToTbls(Thasil, "Typstring", "tgltagihan")
        insertRowToTbls(Thasil, "tyinterger", "totaltagihan")
        insertRowToTbls(Thasil, "Typstring", "notagihan")
        insertRowToTbls(Thasil, "Typstring", "lunastgl")
        insertRowToTbls(Thasil, "Typstring", "namabank")
        insertRowToTbls(Thasil, "tyinterger", "lunasnilai")
        insertRowToTbls(Thasil, "Typstring", "coadetail")
        insertRowToTbls(Thasil, "Typstring", "coanilai")
        insertRowToTbls(Thasil, "Typstring", "coanilaidetail")
        insertRowToTbls(Thasil, "tyinterger", "totalall")

        Return Thasil
    End Function

    Private Sub butdisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butdisplay.Click
        Dim Thasil As New DataTable
        Dim Tpoli As DataTable = CreateTable()
        'Dim Tquery As String = ""
        'Dim Tcriteria As String = ""
        'Dim Tlunas As String = ""
        'Dim Tbank As String = ""
        'Dim Tjenistransaksi As String = ""
        'Dim Tgroup As String = ""
        'Dim Torder As String = ""
        Dim NoUrut1 As Integer = 0
        Dim NoUrut2 As Integer = 0
        Dim JenisTanggal As String = ""
        Dim TextJenisTanggal As String = ""

        Dim stringQueryBank As String = " "
        Dim stringQueryPerusahaan As String = " "
        Dim stringQueryJenisTransaksi As String = " "

        ' Validasi Tanggal
        If dtkasirawal.Value > dtkasirakhir.Value Then
            MsgBox("Tanggal akhir tidak boleh kecil dari tanggal awal.", MsgBoxStyle.Exclamation, "Eror!")
            Exit Sub
        End If

        ' Set COA Bank
        If TextBoxBankTransferCoa.Text <> "" Then
            stringQueryBank = "  AND b.coa = '" & TextBoxBankTransferCoa.Text & "' "
        End If

        ' Set Perusahaan
        If TextBoxNamaPerusahaan.Text <> "" Then
            stringQueryPerusahaan = "  AND a.company = '" & TextBoxNamaPerusahaan.Text & "' "
        End If

        ' Set Jenis Transaksi
        If RadioButtonJenisTransaksiKlinik.Checked = True Then
            stringQueryJenisTransaksi = "  AND a.notagihancompany LIKE '%MMC%' AND "
        ElseIf RadioButtonJenisTransaksiLaboratorium.Checked = True Then
            stringQueryJenisTransaksi = "  AND a.notagihancompany LIKE '%CDC%' AND "
        End If

        ' Set Jenis Tanggal
        If rdtanggalbayar.Checked = True Then
            JenisTanggal = "b.lunastgl"
            TextJenisTanggal = "Tanggal Lunas"
        ElseIf rdtanggalclosing.Checked = True Then
            JenisTanggal = "b.createdate"
            TextJenisTanggal = "Tanggal Closing"
        End If

        'Select Bank
        'If txbankid.Text.Trim <> "" Then
        '    Tbank = "d.bankid=" & txbankid.Text.Trim & " AND "
        'End If

        'Status Lunas
        'Tlunas = " a.lunasid <> 0 and "

        'Jenis Transaksi
        'If RadioButtonJenisTransaksiKlinik.Checked = True Then
        '    Tjenistransaksi = " a.notagihancompany LIKE '%MMC%' AND "
        'ElseIf RadioButtonJenisTransaksiLaboratorium.Checked = True Then
        '    Tjenistransaksi = " a.notagihancompany LIKE '%CDC%' AND "
        'ElseIf RadioButtonJenisTransaksiAll.Checked = True Then
        '    Tjenistransaksi = " "
        'End If

        'Pilih Company
        'If TextBoxNamaPerusahaan.Text <> "" Then
        '    Tcriteria = "a.company='" & TextBoxNamaPerusahaan.Text & "' and DATE(" & JenisTanggal & ") between '" & Format(dtkasirawal.Value, "yyyyMMdd") & "' and '" & Format(dtkasirakhir.Value, "yyyyMMdd") & "' ORDER BY b.bankid, " & JenisTanggal & ", a.company, a.lunasid ASC"
        'Else
        '    Tcriteria = "DATE(" & JenisTanggal & ") between '" & Format(dtkasirawal.Value, "yyyyMMdd") & "' and '" & Format(dtkasirakhir.Value, "yyyyMMdd") & "' ORDER BY b.bankid, " & JenisTanggal & ", a.company, a.lunasid ASC"
        'End If

        'Query Utama
        'Tquery = "SELECT b.createby AS 'admin', CASE WHEN a.lunasid > 0 THEN 1 ELSE 0 END AS 'statustransaksi', CASE WHEN a.lunasid > 0 THEN 'INVOICE TERBAYAR' ELSE 'INVOICE BELUM TERBAYAR' END AS 'statustransaksidetail',a.company, a.RekapID, DATE_FORMAT(b.createdate, '%d-%b-%Y') as `tgltagihan`, a.totaltagihan, a.notagihancompany AS notagihan, ifnull(DATE_FORMAT(b.lunastgl, '%d-%b-%Y'),'-') AS lunastgl,   ifnull(d.namabank,'-') AS namabank, ifnull(b.lunasnilai,0) AS lunasnilai, ifnull(c.coadetail,'-') AS coadetail, ifnull(c.nilai,0) AS coanilai, CASE WHEN a.lunasid > 0 THEN ifnull(b.lunasnilai,0)+ifnull(c.nilai,0) ELSE a.totaltagihan END AS 'totalall' FROM acctransrekaptagihan a LEFT JOIN acctranspelunasantagihan b ON a.lunasid=b.lunasid LEFT JOIN acctranspelunasantagihandetail c ON b.lunasid=c.lunasid LEFT JOIN accmasterbank d ON b.bankid=d.bankid where a.deleted IS NULL and "

        Dim stringQuery As New StringBuilder()

        stringQuery.AppendLine("SELECT b.coa, b.createby AS 'admin', ")
        stringQuery.AppendLine("       CASE WHEN a.lunasid > 0 THEN 1 ELSE 0 END AS 'statustransaksi', ")
        stringQuery.AppendLine("       CASE WHEN a.lunasid > 0 THEN 'INVOICE TERBAYAR' ELSE 'INVOICE BELUM TERBAYAR' END AS 'statustransaksidetail', ")
        stringQuery.AppendLine("       a.company, a.RekapID, DATE_FORMAT(b.createdate, '%d-%b-%Y') AS 'tgltagihan', ")
        stringQuery.AppendLine("       a.totaltagihan, a.notagihancompany AS notagihan, ")
        stringQuery.AppendLine("       IFNULL(DATE_FORMAT(b.lunastgl, '%d-%b-%Y'), '-') AS lunastgl, ")
        stringQuery.AppendLine("       IFNULL(b.lunasnilai, 0) AS lunasnilai, ")
        stringQuery.AppendLine("       IFNULL(c.coadetail, '-') AS coadetail, ")
        stringQuery.AppendLine("       IFNULL(c.nilai, 0) AS coanilai, ")
        stringQuery.AppendLine("       CASE WHEN a.lunasid > 0 THEN IFNULL(b.lunasnilai, 0) + IFNULL(c.nilai, 0) ELSE a.totaltagihan END AS 'totalall' ")
        stringQuery.AppendLine("FROM acctransrekaptagihan a ")
        stringQuery.AppendLine("     LEFT JOIN acctranspelunasantagihan b ON a.lunasid = b.lunasid ")
        stringQuery.AppendLine("     LEFT JOIN acctranspelunasantagihandetail c ON b.lunasid = c.lunasid ")
        stringQuery.AppendLine("WHERE a.deleted IS NULL ")
        stringQuery.AppendLine("  AND a.lunasid <> 0 ")
        stringQuery.AppendLine("  AND DATE(" & JenisTanggal & ") BETWEEN '" & Format(dtkasirawal.Value, "yyyyMMdd") & "' AND '" & Format(dtkasirakhir.Value, "yyyyMMdd") & "' ")
        stringQuery.AppendLine(stringQueryBank)
        stringQuery.AppendLine(stringQueryPerusahaan)
        stringQuery.AppendLine(stringQueryJenisTransaksi)
        stringQuery.AppendLine("ORDER BY b.coa, b.lunastgl, a.company, a.lunasid ASC")

        ' Set Master Bank
        Dim listBank As New Dictionary(Of String, String)
        Dim tblMasterBank As DataTable = ReadThemysql("SELECT CONCAT(a.NamaBank, - a.NomorRekening) AS 'Keterangan Bank', a.CoaBank AS 'Kode COA' FROM MasterBankTransfer a WHERE a.StatusAktif = 1 AND a.TransferTagihan = 1;", DB_Omset)
        For Each rowMasterBank As DataRow In tblMasterBank.Rows
            Dim keterenganBank As String = rowMasterBank("Keterangan Bank").ToString()
            Dim kodeCoa As String = rowMasterBank("Kode COA").ToString()
            If Not listBank.ContainsKey(keterenganBank) Then
                listBank.Add(kodeCoa, keterenganBank)
            End If
        Next

        Dim Tbls As DataTable = ReadThemysql(stringQuery.ToString(), DB_Keuangan)
        Dim tempCompany As String = ""
        Dim NoUrutTerbayar As Integer = 0
        Dim NoUrutBelumTerbayar As Integer = 0

        If Tbls.Rows.Count > 0 Then
            For i As Integer = 0 To Tbls.Rows.Count - 1
                Dim Tnew As DataRow = Tpoli.NewRow

                If i + 1 <= Tbls.Rows.Count - 1 Then
                    tempCompany = Tbls(i + 1)("company")
                Else
                    tempCompany = Tbls(i)("company")
                End If

                If i = 0 Then
                    NoUrutTerbayar = 1
                    Tnew("no") = NoUrutTerbayar
                ElseIf Tbls(i - 1)("coa") = Tbls(i)("coa") Then
                    NoUrutTerbayar = NoUrutTerbayar + 1
                    Tnew("no") = NoUrutTerbayar
                ElseIf Tbls(i - 1)("coa") <> Tbls(i)("coa") Then
                    NoUrutTerbayar = 1
                    Tnew("no") = NoUrutTerbayar
                End If

                Tnew("statustransaksidetail") = Tbls(i)("statustransaksidetail")
                Tnew("statustransaksi") = Tbls(i)("statustransaksi")

                Dim Tsplit() As String = Tbls(i)("company").ToString.Split("-")

                Tnew("company") = Tsplit(0).ToString.Trim.ToUpper
                Tnew("RekapID") = Tbls(i)("RekapID")
                Tnew("admin") = Tbls(i)("admin")
                Tnew("tgltagihan") = Tbls(i)("tgltagihan")
                Tnew("totaltagihan") = Tbls(i)("totaltagihan")
                Tnew("notagihan") = Tbls(i)("notagihan")
                Tnew("lunastgl") = Tbls(i)("lunastgl")
                Tnew("namabank") = listBank(Tbls(i)("coa"))
                Tnew("lunasnilai") = Tbls(i)("lunasnilai")
                Tnew("coadetail") = Tbls(i)("coadetail")
                Tnew("coanilai") = Tbls(i)("coanilai")
                Tnew("totalall") = Tbls(i)("totalall")
                If Tbls(i)("coanilai") > 0 Then
                    Tnew("coanilaidetail") = Tbls(i)("coadetail") & " (" & Format(Val(Tbls(i)("coanilai")), "###,###") & ")"
                Else
                    Tnew("coanilaidetail") = "-"
                End If

                Tpoli.Rows.Add(Tnew)
            Next
        End If

        Report = New XtraReport
        Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\Laporan\LapPembayaranBankTagihan.repx", True)
        Report.DataSource = Tpoli
        Report.Bands.Item(BandKind.ReportHeader).Controls("lbljenissetoran").Text = "LAPORAN PEMBAYARAN BANK"
        Report.Bands.Item(BandKind.ReportHeader).Controls("lbltanggal").Text = Format(dtkasirawal.Value, "dd-MMM-yyyy") & " s/d " & Format(dtkasirakhir.Value, "dd-MMM-yyyy")
        Report.Bands.Item(BandKind.ReportHeader).Controls("xrlabeltanggal").Text = TextJenisTanggal
        If TextBoxNamaPerusahaan.Text = "" Then
            Report.Bands.Item(BandKind.ReportHeader).Controls("lblcabang").Text = "SEMUA CABANG"
        Else
            Dim Tsplit() As String = TextBoxNamaPerusahaan.Text.ToString.Split("-")
            Report.Bands.Item(BandKind.ReportHeader).Controls("lblcabang").Text = Tsplit(0).ToString.Trim.ToUpper
        End If
        Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MM-yyyy HH:mm:ss") & " by " & PoliKlinik.Lbluser.Text

        'Report.RunDesigner()
        Report.ShowPreview()
        'Report.Print()
    End Sub

    Private Sub butfind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butfind.Click
        Find.Show()
        Find.QueryTheMysql("SELECT a.company as CompJenis FROM acctransrekaptagihan a GROUP BY a.company", " ", "FindCabangClosingBankTagihan", 0, Find_Keuangan)
    End Sub

    Public Sub LoadLapPendapatanTagihan(ByRef txCompJenis As String)
        TextBoxNamaPerusahaan.Text = txCompJenis
    End Sub

    Public Sub LoadBank(ByRef CoaBank As String, ByRef NamaBank As String)
        TextBoxBankTransferCoa.Text = CoaBank
        TextBoxBankTransferKeterangan.Text = NamaBank
    End Sub

    Private Sub butselectbank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butselectbank.Click
        'Find.Show()
        'Find.QueryTheMysql("SELECT CONCAT(a.namabank, - a.norekening, ' a/n ', a.namarekening) AS 'namabank', a.cabangrekening, a.coa, a.bankid FROM accmasterbank a WHERE a.bankid IN (SELECT bankid FROM acctranspelunasantagihan GROUP BY bankid)", " ", "FindBankClosingBankTagihan", 0, Find_Keuangan)

        Find.Show()
        Find.QueryTheMysql("SELECT CONCAT(a.NamaBank, - a.NomorRekening, ' a/n ', a.NamaRekening) AS 'Keterangan Bank', a.CabangRekening AS 'Cabang Bank', a.CoaBank AS 'COA Bank' FROM MasterBankTransfer a WHERE a.StatusAktif = 1 AND a.TransferTagihan = 1;", " ", "FindBankClosingBankTagihan", 0, Find_Omset)
    End Sub
End Class

