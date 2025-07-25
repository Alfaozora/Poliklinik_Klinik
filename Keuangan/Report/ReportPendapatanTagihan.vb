Public Class ReportPendapatanTagihan
    Private Find_Poliklinik As Find.TLconnect
    Private Find_Keuangan As Find.TLconnect
    Private DB_Keuangan As TLcon

    Private Sub SetConn()
        ' Set Parameter Server Online
        Dim serverOnline_IP As String = Utility.GetConfig("ServerOnline_IP")
        Dim serverOnline_UserID As String = Utility.GetConfig("ServerOnline_UserID")
        Dim serverOnline_Password As String = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerOnline_Password"), "albert")

        ' Set Find Keuangan 1 (mitramed_keu)
        Find_Keuangan.Tip = serverOnline_IP
        Find_Keuangan.Tid = serverOnline_UserID
        Find_Keuangan.Tpass = serverOnline_Password
        Find_Keuangan.Tdb = Utility.GetConfig("ServerOnlineKeuangan_DB")

        ' Set Find Poliklinik
        Find_Poliklinik.Tip = serverOnline_IP
        Find_Poliklinik.Tid = serverOnline_UserID
        Find_Poliklinik.Tpass = serverOnline_Password
        Find_Poliklinik.Tdb = Utility.GetConfig("ServerOnlinePoli_DB")

        ' Set DB Keuangan 1 (mitramed_keu)
        DB_Keuangan.Tip = serverOnline_IP
        DB_Keuangan.Tid = serverOnline_UserID
        DB_Keuangan.Tpass = serverOnline_Password
        DB_Keuangan.Tdb = Utility.GetConfig("ServerOnlineKeuangan_DB")
    End Sub

    Private Sub SetClear()
        dtkasirakhir.Value = DateAndTime.Now
        dtkasirawal.Value = DateAndTime.Now
        rdbayar3.Checked = True
        rdjenistransaksi3.Checked = True
    End Sub

    Private Sub ReportPendapatanTagihan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.MdiParent = PoliKlinik
        SetClear()
        SetConn()
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
        'If txnamacompany.Text = "" Then
        '    MsgBox("Pilih Company Terlebih Dahulu.")
        '    Exit Sub
        'End If

        If rdbayar1.Checked = False And rdbayar2.Checked = False And rdbayar3.Checked = False Then
            MsgBox("Pilih Status Tagihan Terlebih Dahulu.")
            Exit Sub
        End If

        Dim Thasil As New DataTable
        Dim Tpoli As DataTable = CreateTable()
        Dim Tquery As String = ""
        Dim Tcriteria As String = ""
        Dim Tlunas As String = ""
        Dim Tjenistransaksi As String = ""
        Dim Tcabang As String = ""
        Dim Tgroup As String = ""
        Dim Torder As String = ""
        Dim NoUrut1 As Integer = 0
        Dim NoUrut2 As Integer = 0

        Tquery = "SELECT b.createby AS 'admin', CASE WHEN a.lunasid > 0 THEN 1 ELSE 0 END AS 'statustransaksi', CASE WHEN a.lunasid > 0 THEN 'INVOICE TERBAYAR' ELSE 'INVOICE BELUM TERBAYAR' END AS 'statustransaksidetail',a.company, a.RekapID, DATE_FORMAT(a.tgltagihan, '%d-%b-%Y') as `tgltagihan`, a.totaltagihan, a.notagihancompany AS notagihan, ifnull(DATE_FORMAT(b.lunastgl, '%d-%b-%Y'),'-') AS lunastgl,   ifnull(d.namabank,'-') AS namabank, ifnull(b.lunasnilai,0) AS lunasnilai, ifnull(c.coadetail,'-') AS coadetail, ifnull(c.nilai,0) AS coanilai, CASE WHEN a.lunasid > 0 THEN ifnull(b.lunasnilai,0)+ifnull(c.nilai,0) ELSE a.totaltagihan END AS 'totalall' FROM acctransrekaptagihan a   LEFT JOIN acctranspelunasantagihan b ON a.lunasid=b.lunasid   LEFT JOIN acctranspelunasantagihandetail c ON b.lunasid=c.lunasid   LEFT JOIN accmasterbank d ON b.bankid=d.bankid where a.deleted IS NULL and "

        If rdbayar1.Checked = True Then
            Tlunas = " a.lunasid <> 0 and "
        ElseIf rdbayar2.Checked = True Then
            Tlunas = " a.lunasid = 0 and "
        ElseIf rdbayar3.Checked = True Then
            Tlunas = " "
        End If

        If rdjenistransaksi1.Checked = True Then
            Tjenistransaksi = " a.notagihancompany LIKE '%MMC%' AND "
        ElseIf rdjenistransaksi2.Checked = True Then
            Tjenistransaksi = " a.notagihancompany LIKE '%CDC%' AND "
        ElseIf rdjenistransaksi3.Checked = True Then
            Tjenistransaksi = " "
        End If

        If txlocid.Text = "" Then
            Tcabang = " "
        Else
            Tcabang = " a.cabang = '" & txlocid.Text & "' AND "
        End If

        If txnamacompany.Text <> "" Then
            Tcriteria = "a.company='" & txnamacompany.Text & "' and DATE(a.tgltagihan) between '" & Format(dtkasirawal.Value, "yyyyMMdd") & "' and '" & Format(dtkasirakhir.Value, "yyyyMMdd") & "' ORDER BY a.company, a.lunasid , a.tgltagihan asc"
        Else
            Tcriteria = "DATE(a.tgltagihan) between '" & Format(dtkasirawal.Value, "yyyyMMdd") & "' and '" & Format(dtkasirakhir.Value, "yyyyMMdd") & "' ORDER BY a.company, a.lunasid , a.tgltagihan asc"
        End If

        If dtkasirawal.Value > dtkasirakhir.Value Then
            MsgBox("Tanggal akhir tidak boleh kecil dari tanggal awal")
            Exit Sub
        End If

        Dim Tbls As DataTable = ReadThemysql(Tquery & Tcabang & Tjenistransaksi & Tlunas & Tcriteria, DB_Keuangan)
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

                'If Tbls(i)("statustransaksi") = "1" Then
                '    NoUrut1 = NoUrut1 + 1
                '    Tnew("no") = NoUrut1
                'ElseIf Tbls(i)("statustransaksi") = "0" Then
                '    NoUrut2 = NoUrut2 + 1
                '    Tnew("no") = NoUrut2
                'End If

                If i = 0 And Tbls(i)("statustransaksi") = "1" Then
                    NoUrutTerbayar = 1
                    Tnew("no") = NoUrutTerbayar
                ElseIf i = 0 And Tbls(i)("statustransaksi") = "0" Then
                    NoUrutBelumTerbayar = 1
                    Tnew("no") = NoUrutBelumTerbayar
                ElseIf Tbls(i - 1)("company") = Tbls(i)("company") And Tbls(i)("statustransaksi") = "1" And Tbls(i - 1)("statustransaksi") = "1" Then
                    NoUrutTerbayar = NoUrutTerbayar + 1
                    Tnew("no") = NoUrutTerbayar
                ElseIf Tbls(i - 1)("company") = Tbls(i)("company") And Tbls(i)("statustransaksi") = "0" And Tbls(i - 1)("statustransaksi") = "0" Then
                    NoUrutBelumTerbayar = NoUrutBelumTerbayar + 1
                    Tnew("no") = NoUrutBelumTerbayar
                ElseIf Tbls(i - 1)("company") = Tbls(i)("company") And Tbls(i)("statustransaksi") = "1" Then
                    NoUrutTerbayar = 1
                    Tnew("no") = NoUrutTerbayar
                ElseIf Tbls(i - 1)("company") = Tbls(i)("company") And Tbls(i)("statustransaksi") = "0" Then
                    NoUrutBelumTerbayar = 1
                    Tnew("no") = NoUrutBelumTerbayar
                ElseIf Tbls(i - 1)("company") <> Tbls(i)("company") And Tbls(i)("statustransaksi") = "1" Then
                    NoUrutTerbayar = 1
                    Tnew("no") = NoUrutTerbayar
                ElseIf Tbls(i - 1)("company") <> Tbls(i)("company") And Tbls(i)("statustransaksi") = "0" Then
                    NoUrutBelumTerbayar = 1
                    Tnew("no") = NoUrutBelumTerbayar
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
                Tnew("namabank") = Tbls(i)("namabank")
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
        Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\Laporan\LapPendapatanTagihan.repx", True)
        Report.DataSource = Tpoli
        Report.Bands.Item(BandKind.ReportHeader).Controls("lbljenissetoran").Text = "LAPORAN PENDAPATAN"
        Report.Bands.Item(BandKind.ReportHeader).Controls("lbltanggal").Text = Format(dtkasirawal.Value, "dd-MMM-yyyy") & " - " & Format(dtkasirakhir.Value, "dd-MMM-yyyy")
        Report.Bands.Item(BandKind.ReportHeader).Controls("lbladmin").Text = PoliKlinik.Lbluser.Text
        Report.Bands.Item(BandKind.ReportHeader).Controls("lbljenis").Text = "TAGIHAN"
        If txnamacompany.Text = "" Then
            Report.Bands.Item(BandKind.ReportHeader).Controls("lblcabang").Text = "SEMUA CABANG"
        Else
            Dim Tsplit() As String = txnamacompany.Text.ToString.Split("-")
            Report.Bands.Item(BandKind.ReportHeader).Controls("lblcabang").Text = Tsplit(0).ToString.Trim.ToUpper
        End If
        Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MM-yyyy HH:mm:ss") & " by " & PoliKlinik.Lbluser.Text
        'Report.RunDesigner()
        Report.ShowPreview()
        'Report.Print()
    End Sub

    Private Sub butfind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butfind.Click
        ''Find.Show()
        ''Find.QueryTheMysql("SELECT a.kodeklinik, a.locationket FROM masterlokasi a WHERE a.kodeklinik IS NOT NULL", " ", "FindCabangLapTagihan", 0, Ttcmh)
        'Find.Show()
        'Find.QueryTheMysql("select distinct concat(kartu,'-',mesin) as CompJenis from acctranstagihandetail", " ", "FindCabangLapTagihan", 0, Ttcmh)
        Find.Show()
        Find.QueryTheMysql("SELECT a.company as CompJenis FROM acctransrekaptagihan a GROUP BY a.company", " ", "FindCabangLapTagihan", 0, Find_Keuangan)
    End Sub

    Public Sub LoadLapPendapatanTagihan(ByRef txCompJenis As String)
        txnamacompany.Text = txCompJenis
        'txkodecabang.Text = txkode
    End Sub

    Private Sub butcabang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butcabang.Click
        Find.Show()
        Find.QueryTheMysql("SELECT a.kodebarcode AS 'ID', a.kodecabang, a.kodeket FROM mastercodebarcode a ", " ORDER BY ID ASC", "FindCabangPendapatanTagihan", 1, Find_Poliklinik)
    End Sub
End Class

