Public Class ReportPendapatanTunai
    Private DB_Keuangan As TLcon
    Private Find_Poliklinik As Find.TLconnect

    Private Sub Connection()
        ' Set Parameter Server Online
        Dim serverOnline_IP As String = Utility.GetConfig("ServerOnline_IP")
        Dim serverOnline_UserID As String = Utility.GetConfig("ServerOnline_UserID")
        Dim serverOnline_Password As String = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerOnline_Password"), "albert")

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
        'cmbjenistrans.ResetText()
        cmbjenistrans.SelectedIndex = 0
        cmbpembayaran.SelectedIndex = 0
        rddetail.Checked = True
        dtkasirakhir.Value = DateAndTime.Now
        dtkasirawal.Value = DateAndTime.Now
        'rdsumm.Checked = True
        'rdlocked.Checked = True
    End Sub

    Private Sub ReportPendapatanTunai_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.MdiParent = PoliKlinik
        SetClear()
        Connection()
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

        insertRowToTbls(Thasil, "Typstring", "inctgl")
        insertRowToTbls(Thasil, "Typstring", "loc")
        insertRowToTbls(Thasil, "Typstring", "incjenis")
        insertRowToTbls(Thasil, "Typstring", "jenis")
        insertRowToTbls(Thasil, "Typstring", "sumnilai")
        insertRowToTbls(Thasil, "tyinterger", "vKredit")
        insertRowToTbls(Thasil, "tyinterger", "vTunai")
        insertRowToTbls(Thasil, "tyinterger", "vDebit")
        insertRowToTbls(Thasil, "tyinterger", "sumjenis")

        Return Thasil
    End Function

    Private Sub butdisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butdisplay.Click
        If txkodecabang.Text = "" Then
            MsgBox("Pilih Lokasi Terlebih Dahulu.")
            Exit Sub
        End If

        Dim Thasil As New DataTable
        Dim Tpoli As DataTable = CreateTable()
        Dim Tquery As String = ""
        Dim Tcriteria As String = ""
        Dim Tjenistransaksi As String = ""
        Dim Tgroup As String = ""
        Dim Torder As String = ""

        If dtkasirawal.Value > dtkasirakhir.Value Then
            MsgBox("Tanggal akhir tidak boleh kecil dari tanggal awal")
            Exit Sub
        End If

        If rddetail.Checked = True Then
            SetDataDetail(Thasil)
            Tquery = "select DATE_FORMAT(a.inctgl, '%d-%b-%Y') as `inctgl`, a.loc, a.incjenis, a.jenis, a.kartu, a.mesin, a.incnilai, a.inctransid, a.idinternet, UPPER(a.pasien) as 'pasien', a.transferid, b.locationket, DATE_FORMAT(c.tgltransfer, '%d-%b-%Y') as `tgltransfer`, CONCAT(d.namabank,' - ',d.norekening, ' - ', d.namarekening) as Bank from acctranspendapatandetail a LEFT JOIN masterlokasi b ON a.loc=b.locid LEFT JOIN acctranspendapatantransfer c ON a.transferid=c.transferid LEFT JOIN accmasterbank d ON c.bankcoa=d.coa where inctgl between '" & Format(dtkasirawal.Value, "yyyyMMdd") & "' and '" & Format(dtkasirakhir.Value, "yyyyMMdd") & "' "
            Torder = " order by `loc`,a.inctgl , `incjenis`, `jenis`, a.transferid,`mesin` ASC"
        ElseIf rdsumm.Checked = True Then
            Tquery = "SELECT DATE_FORMAT(a.inctgl, '%Y-%m-%d')  as inctgl, a.loc, a.incjenis, a.jenis,  sum(a.incnilai) as sumnilai from acctranspendapatandetail a where a.inctgl between '" & Format(dtkasirawal.Value, "yyyyMMdd") & "' and '" & Format(dtkasirakhir.Value, "yyyyMMdd") & "' and a.incnilai>0 "
            Tgroup = " group by a.inctgl "
        End If

        Select Case cmbjenistrans.Text
            Case "SEMUA"
                Tcriteria = " AND `incjenis` IN ('POLI','LAB','GIGI', 'DLL') "
            Case "POLI"
                Tcriteria = " and `incjenis`='POLI' "
            Case "LAB"
                Tcriteria = " and `incjenis`='LAB' "
            Case "GIGI"
                Tcriteria = " and `incjenis`='GIGI' "
            Case "DLL"
                Tcriteria = " and `incjenis`='DLL' "
            Case Else
                MsgBox("Pilihan Jenis tidak dikenali. Check kembali")
                Exit Sub
        End Select

        If cmbpembayaran.SelectedIndex = 0 Then
            Tjenistransaksi = " AND a.jenis IN ('Tunai','Debet','Kredit')"
        ElseIf cmbpembayaran.SelectedIndex = 1 Then
            Tjenistransaksi = " AND a.jenis='Tunai'"
        ElseIf cmbpembayaran.SelectedIndex = 2 Then
            Tjenistransaksi = " AND a.jenis='Debet'"
        ElseIf cmbpembayaran.SelectedIndex = 3 Then
            Tjenistransaksi = " AND a.jenis='Kredit'"
        End If

        Tcriteria = Tcriteria + " and a.trflockeddate<>'99981231' AND a.transferid IS NOT NULL AND a.loc='" & txkodecabang.Text & "'"

        Dim Tbls As DataTable = ReadThemysql(Tquery & Tjenistransaksi & Tcriteria & Tgroup & Torder, DB_Keuangan)

        If rdsumm.Checked = True Then
            For Each Trow As DataRow In Tbls.Rows
                Dim vTunaiDLL As Double = 0, vDebitDLL As Double = 0, vKreditDLL As Double = 0
                Dim vTunaiLAB As Double = 0, vDebitLAB As Double = 0, vKreditLAB As Double = 0
                Dim vTunaiPOLI As Double = 0, vDebitPOLI As Double = 0, vKreditPOLI As Double = 0
                Dim vTunaiGIGI As Double = 0, vDebitGIGI As Double = 0, vKreditGIGI As Double = 0
                Dim key1 As String = "", key2 As String = ""

                Dim Tdetail As DataTable = ReadThemysql("SELECT DATE_FORMAT(a.inctgl, '%Y-%m-%d')  as inctgl, a.loc, a.incjenis, a.jenis,  sum(a.incnilai) as sumnilai from acctranspendapatandetail a where a.inctgl = '" & Trow("inctgl") & "' and a.incnilai>0 " & Tjenistransaksi & Tcriteria & " group by a.inctgl,  a.incjenis, a.jenis order by a.inctgl, a.incjenis, a.jenis", DB_Keuangan)
                If Tdetail.Rows.Count > 0 Then
                    For Each Ttemp As DataRow In Tdetail.Rows
                        Select Case Ttemp("incjenis")
                            Case "DLL"
                                If Ttemp("jenis") = "Debet" Then vDebitDLL = Ttemp("sumnilai")
                                If Ttemp("jenis") = "Tunai" Then vTunaiDLL = Ttemp("sumnilai")
                                If Ttemp("jenis") = "Kredit" Then vKreditDLL = Ttemp("sumnilai")
                            Case "LAB"
                                If Ttemp("jenis") = "Debet" Then vDebitLAB = Ttemp("sumnilai")
                                If Ttemp("jenis") = "Tunai" Then vTunaiLAB = Ttemp("sumnilai")
                                If Ttemp("jenis") = "Kredit" Then vKreditLAB = Ttemp("sumnilai")
                            Case "POLI"
                                If Ttemp("jenis") = "Debet" Then vDebitPOLI = Ttemp("sumnilai")
                                If Ttemp("jenis") = "Tunai" Then vTunaiPOLI = Ttemp("sumnilai")
                                If Ttemp("jenis") = "Kredit" Then vKreditPOLI = Ttemp("sumnilai")
                            Case "GIGI"
                                If Ttemp("jenis") = "Debet" Then vDebitGIGI = Ttemp("sumnilai")
                                If Ttemp("jenis") = "Tunai" Then vTunaiGIGI = Ttemp("sumnilai")
                                If Ttemp("jenis") = "Kredit" Then vKreditGIGI = Ttemp("sumnilai")
                        End Select
                    Next

                    'DLL
                    Dim Tnew As DataRow = Tpoli.NewRow
                    Tnew("inctgl") = Trow("inctgl")
                    Tnew("loc") = Trow("loc")
                    Tnew("jenis") = "-"
                    If vTunaiDLL > 0 Then Tnew("vTunai") = vTunaiDLL Else Tnew("vTunai") = 0
                    If vDebitDLL > 0 Then Tnew("vDebit") = vDebitDLL Else Tnew("vDebit") = 0
                    If vKreditDLL > 0 Then Tnew("vKredit") = vKreditDLL Else Tnew("vKredit") = 0
                    Tnew("sumjenis") = vTunaiDLL + vDebitDLL + vKreditDLL
                    Tnew("incjenis") = "DLL"
                    If Tnew("sumjenis") <> 0 Then
                        Tpoli.Rows.Add(Tnew)
                    End If

                    'LAB
                    Tnew = Tpoli.NewRow
                    Tnew("inctgl") = Trow("inctgl")
                    Tnew("loc") = Trow("loc")
                    Tnew("jenis") = "-"
                    If vTunaiLAB > 0 Then Tnew("vTunai") = vTunaiLAB Else Tnew("vTunai") = 0
                    If vDebitLAB > 0 Then Tnew("vDebit") = vDebitLAB Else Tnew("vDebit") = 0
                    If vKreditLAB > 0 Then Tnew("vKredit") = vKreditLAB Else Tnew("vKredit") = 0
                    Tnew("sumjenis") = vTunaiLAB + vDebitLAB + vKreditLAB
                    Tnew("incjenis") = "LAB"
                    If Tnew("sumjenis") <> 0 Then
                        Tpoli.Rows.Add(Tnew)
                    End If

                    'POLI
                    Tnew = Tpoli.NewRow
                    Tnew("inctgl") = Trow("inctgl")
                    Tnew("loc") = Trow("loc")
                    Tnew("jenis") = "-"
                    If vTunaiPOLI > 0 Then Tnew("vTunai") = vTunaiPOLI Else Tnew("vTunai") = 0
                    If vDebitPOLI > 0 Then Tnew("vDebit") = vDebitPOLI Else Tnew("vDebit") = 0
                    If vKreditPOLI > 0 Then Tnew("vKredit") = vKreditPOLI Else Tnew("vKredit") = 0
                    Tnew("sumjenis") = vTunaiPOLI + vDebitPOLI + vKreditPOLI
                    Tnew("incjenis") = "POLI"
                    If Tnew("sumjenis") <> 0 Then
                        Tpoli.Rows.Add(Tnew)
                    End If

                    'GIGI
                    Tnew = Tpoli.NewRow
                    Tnew("inctgl") = Trow("inctgl")
                    Tnew("loc") = Trow("loc")
                    Tnew("jenis") = "-"
                    If vTunaiGIGI > 0 Then Tnew("vTunai") = vTunaiGIGI Else Tnew("vTunai") = 0
                    If vDebitGIGI > 0 Then Tnew("vDebit") = vDebitGIGI Else Tnew("vDebit") = 0
                    If vKreditGIGI > 0 Then Tnew("vKredit") = vKreditGIGI Else Tnew("vKredit") = 0
                    Tnew("sumjenis") = vTunaiGIGI + vDebitGIGI + vKreditGIGI
                    Tnew("incjenis") = "GIGI"
                    If Tnew("sumjenis") <> 0 Then
                        Tpoli.Rows.Add(Tnew)
                    End If

                End If
            Next
        End If

        Report = New XtraReport
        If rddetail.Checked = True Then
            Report = XtraReport.FromFile(Application.StartupPath + "\reports\Keuangan\PendapatanTunaiDetail.repx", True)
            Report.DataSource = Tbls
            Report.Bands.Item(BandKind.ReportHeader).Controls("lbljenissetoran").Text = "LAPORAN PENDAPATAN TUNAI DETAIL"
        ElseIf rdsumm.Checked = True Then
            Report = XtraReport.FromFile(Application.StartupPath + "\reports\Keuangan\PendapatanTunaiSummary.repx", True)
            Report.DataSource = Tpoli
            Report.Bands.Item(BandKind.ReportHeader).Controls("lbljenissetoran").Text = "LAPORAN PENDAPATAN TUNAI SUMMARY"
        End If

        Report.Bands.Item(BandKind.ReportHeader).Controls("lbltanggal").Text = Format(dtkasirawal.Value, "dd-MMM-yyyy") & " - " & Format(dtkasirakhir.Value, "dd-MMM-yyyy")
        Report.Bands.Item(BandKind.ReportHeader).Controls("lbladmin").Text = PoliKlinik.Lbluser.Text
        Report.Bands.Item(BandKind.ReportHeader).Controls("lbljenis").Text = "TUNAI"
        Report.Bands.Item(BandKind.ReportHeader).Controls("lblcabang").Text = txnamacabang.Text
        Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:ss")
        'Report.RunDesigner()
        Report.ShowPreview()
        'Report.Print()
    End Sub

    Private Sub butfind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butfind.Click
        Find.Show()
        Find.QueryTheMysql("SELECT a.kodecabang AS kodeklinik, a.kodeket AS locationket FROM mastercodebarcode a", " ", "FindCabangLapTunai", 0, Find_Poliklinik)
    End Sub

    Public Sub LoadLapPendapatanTunai(ByRef txkode As String, ByRef txlocationket As String)
        txnamacabang.Text = txlocationket
        txkodecabang.Text = txkode
    End Sub
End Class

