Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns

Public Class FormAwalPembayaranTagihan
    ' Set Connection
    Private DB_Keuangan As TLcon
    Private Find_Keuangan As Find.TLconnect

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

        ' Set Find Keuangan 1 (mitramed_keu)
        Find_Keuangan.Tip = serverOnline_IP
        Find_Keuangan.Tid = serverOnline_UserID
        Find_Keuangan.Tpass = serverOnline_Password
        Find_Keuangan.Tdb = Utility.GetConfig("ServerOnlineKeuangan_DB")
    End Sub

    Private Sub SetClear()
        txcompanycode.ResetText()
        txcompanycode.Enabled = True
        butfindcomp.Enabled = True
        txtotalpembayaran.Text = 0
        txtotalsisa.Text = 0
        txtotaltagihan.Text = 0
        dtawal.Value = DateSerial("2001", "1", "1")
        dtakhir.Value = DateAndTime.Now.AddDays(1)
        chkedittagihan.Checked = False
        dtawal.Enabled = False

        dtawalbayar.Value = DateSerial("2001", "1", "1")
        dtakhirbayar.Value = DateAndTime.Now.AddDays(1)
        chkeditbayar.Checked = False
        dtawalbayar.Enabled = False
        gridpoli.DataSource = CreateTable()

        LoadData()
        butnewtagihan.PerformClick()
    End Sub

    Function CreateTable() As DataTable
        Dim Thasil As New DataTable

        insertRowToTbls(Thasil, "tyinterger", "ID")
        insertRowToTbls(Thasil, "Typstring", "Lokasi")
        insertRowToTbls(Thasil, "Typstring", "JenisTrans")
        insertRowToTbls(Thasil, "Typstring", "NoTransaksi")
        insertRowToTbls(Thasil, "Typstring", "IDPasien")
        insertRowToTbls(Thasil, "Typstring", "Pasien")
        insertRowToTbls(Thasil, "Typstring", "JenisBayar")
        insertRowToTbls(Thasil, "Typstring", "Kartu")
        insertRowToTbls(Thasil, "Typstring", "Mesin")
        insertRowToTbls(Thasil, "Typstring", "NilaiUang")
        insertRowToTbls(Thasil, "Typstring", "TglClosed")
        insertRowToTbls(Thasil, "Typstring", "Status")
        insertRowToTbls(Thasil, "typchecked", "Closed")
        insertRowToTbls(Thasil, "Typstring", "MM")
        insertRowToTbls(Thasil, "Typstring", "YY")
        insertRowToTbls(Thasil, "Typstring", "TglTrans")

        For Each Tcol As DataColumn In Thasil.Columns
            Tcol.ReadOnly = True
        Next

        Thasil.Columns("Closed").ReadOnly = False

        Return Thasil
    End Function

    Public Sub LoadData()
        ' Inisialisasi koneksi ke database MySQL
        SetConnectionFromConfig()

        Kalkulasi()

        'Dim Tdata As DataTable = gridpoli.DataSource
        'Tdata.Rows.Clear()

        'Dim Ttagihan As DataTable = ReadThemysql("SELECT *,month(inctgl) as MM,year(inctgl) as YY FROM acctranstagihandetail where concat(kartu,'-',mesin)='" & txcompanycode.Text & "' and lockeddate<>'99981231' ", DB_Keuangan)
        'If Ttagihan.Rows.Count > 0 Then    
        '    For Each Trow As DataRow In Ttagihan.Rows
        '        Dim Tnew As DataRow = Tdata.NewRow
        '        Tnew("ID") = Trow("incdetailid")
        '        Tnew("Lokasi") = Trow("loc")
        '        Tnew("JenisTrans") = Trow("incjenis")
        '        Tnew("NoTransaksi") = Trow("inctransid")
        '        Tnew("IDPasien") = Trow("idinternet")
        '        Tnew("Pasien") = Trow("Pasien")
        '        Tnew("JenisBayar") = Trow("jenis")
        '        Tnew("Kartu") = Trow("kartu")
        '        Tnew("Mesin") = Trow("mesin")
        '        Tnew("MM") = Month(Trow("inctgl"))
        '        Tnew("YY") = Year(Trow("inctgl"))
        '        Tnew("TglTrans") = Format(Trow("inctgl"), "yyyy-MM-dd")
        '        Tnew("NilaiUang") = Splitmoney(Trow("incnilai"))
        '        If Trow("lockeddate") <> DateSerial("9998", "12", "31") Then
        '            Tnew("Status") = "LOCKED"
        '            Tnew("Closed") = True
        '            Tnew("TglClosed") = Format(Trow("lockeddate"), "dd-MMM-yyyy HH:mm")
        '        Else
        '            Tnew("Status") = ""
        '            Tnew("Closed") = False
        '            Tnew("TglClosed") = ""
        '        End If
        '        Tdata.Rows.Add(Tnew)
        '    Next

        '    For Each Tcol As DataColumn In Tdata.Columns
        '        Tcol.ReadOnly = True
        '    Next
        '    Tdata.Columns("Closed").ReadOnly = False
        '    gridpoli.DataSource = Tdata
        'Else
        '    If txcompanycode.Text <> "" Then
        '        MsgBox("Detail Penerimaan belum terkirim. Minta dikirim ulang dari lokal")
        '    End If
        'End If

        'GridView1.Columns("ID").Visible = False
        ''GridView1.Columns("MM").Visible = False
        ''GridView1.Columns("YY").Visible = False
        'GridView1.Columns("Status").Visible = False
        'GridView1.Columns("Closed").Visible = False
        'GridView1.Columns("TglClosed").Visible = False
        ''GridView1.Columns("").Visible = False

        'Dim Tlunas As DataTable = ReadThemysql("SELECT c.company, c.notagihancompany, DATE(c.tgltagihan) as tgltagihan,a.lunasid as ID,lunastgl as tgllunas,MONTH(a.lunastgl) as MM,YEAR(a.lunastgl) as YY,c.totaltagihan AS totaltagihan,c.totaltagihan-a.lunasnilai AS tambahan,a.lunasnilai as Realisasi, b.namabank,b.namarekening from acctranspelunasantagihan a INNER JOIN acctransrekaptagihan c ON a.lunasid=c.lunasid left join accmasterbank b on a.bankid=b.bankid where concat(kartu,'-',mesin)='" & txcompanycode.Text & "' and lunastgl between '" & Format(dtawal.Value, "yyyyMMdd") & "' and '" & Format(dtakhir.Value, "yyyyMMdd") & "'", DB_Keuangan)

        'For Each Tnewrow As DataRow In Tlunas.Rows
        '    Dim Tadd As DataTable = ReadThemysql("select ifnull(sum(nilai),0) as Nilai from acctranspelunasantagihandetail where lunasid='" & Tnewrow("ID") & "'", DB_Keuangan)
        '    If Tadd.Rows.Count > 0 Then
        '        Dim RRow As DataRow = Tadd.Rows(0)
        '        Tnewrow("realisasi") = Tnewrow("realisasi") + RRow("Nilai")
        '    End If
        'Next

        'GridControl1.DataSource = Tlunas
        'GridView2.Columns("company").Visible = False
        'GridView2.Columns("ID").Visible = False
        'GridView2.Columns("MM").Visible = False
        'GridView2.Columns("YY").Visible = False
        ''GridView2.Columns("").Visible = False

        'Kalkulasi()

        'gridtrans.DataSource = ReadThemysql("SELECT a.`RekapID`,a.`incdetailid` as ID, a.`incJenis` as Jenis , a.`inctransid` as TransID, a.`inctgl` as Tgl , a.`idinternet` as IDPasien, a.`pasien` as Nama ,a.`incnilai` as Tagihan FROM acctranstagihandetail a where concat(kartu,'-',mesin)='" & txcompanycode.Text & "' and a.`incdetailid`=-1", DB_Keuangan)

    End Sub

    Private Sub Kalkulasi()
        Dim Tbls As DataTable = gridpoli.DataSource
        Dim Tbls2 As DataTable = GridControl1.DataSource
        Dim Thasil As String = 0
        Dim Thasil2 As String = 0

        If txcompanycode.Text.Trim <> "" Then
            Thasil = ReadThemysqlNIK("SELECT SUM(a.totaltagihan) AS 'TotalBelumBayar' FROM acctransrekaptagihan a WHERE a.company='" & txcompanycode.Text & "'", DB_Keuangan)
            Thasil2 = ReadThemysqlNIK("SELECT SUM(a.totaltagihan) AS 'TotalBelumBayar' FROM acctransrekaptagihan a WHERE a.company='" & txcompanycode.Text & "' AND a.lunasid<>0", DB_Keuangan)
            If IsDBNull(Thasil) = True Or Thasil = "" Then Thasil = 0
            If IsDBNull(Thasil2) = True Or Thasil2 = "" Then Thasil2 = 0
        Else
            Thasil = ReadThemysqlNIK("SELECT SUM(a.totaltagihan) AS 'TotalBelumBayar' FROM acctransrekaptagihan a", DB_Keuangan)
            Thasil2 = ReadThemysqlNIK("SELECT SUM(a.totaltagihan) AS 'TotalBelumBayar' FROM acctransrekaptagihan a WHERE a.lunasid<>0", DB_Keuangan)
            If IsDBNull(Thasil) = True Or Thasil = "" Then Thasil = 0
            If IsDBNull(Thasil2) = True Or Thasil2 = "" Then Thasil2 = 0
        End If

        'For Each Trow As DataRow In Tbls.Rows
        '    Thasil = Thasil + CDbl(Trow("NilaiUang"))
        'Next

        'For Each Trow As DataRow In Tbls2.Rows
        '    Thasil2 = Thasil2 + CDbl(Trow("realisasi"))
        'Next

        txtotaltagihan.Text = Splitmoney(CDbl(Thasil))
        txtotalpembayaran.Text = Splitmoney(CDbl(Thasil2))
        txtotalsisa.Text = Splitmoney(CDbl(txtotalpembayaran.Text) - CDbl(txtotaltagihan.Text))
        If txtotalsisa.Text < 0 Then
            txtotalsisa.BackColor = Color.Red
        ElseIf txtotalsisa.Text > 0 Then
            txtotalsisa.BackColor = Color.Green
        Else
            txtotalsisa.BackColor = txtotaltagihan.BackColor
        End If

    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub AccPelunasan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        SetFormHeightWeight(Me, 0.95, 0.8)
        SetClear()
        disablebutton()
        TabPage1.Hide()
        TabControl1.TabPages.Remove(TabPage1)
        TabPage2.Hide()
        TabControl1.TabPages.Remove(TabPage2)
    End Sub

    Public Sub disablebutton()
        Button1.Enabled = False
        dtakhir.Enabled = False
        chkedittagihan.Enabled = False
        butfindnotagihan.Enabled = False
        butnewtagihan.Enabled = False
        butrekappasien.Enabled = False
        butcreatetagihan.Enabled = False
        butdisplaytangga.Enabled = False
        Button2.Enabled = False
        Button3.Enabled = False
        dtakhirbayar.Enabled = False
        chkeditbayar.Enabled = False
        Button5.Enabled = False
    End Sub

    Public Sub enablebutton()
        Button1.Enabled = True
        dtakhir.Enabled = True
        chkedittagihan.Enabled = True
        butfindnotagihan.Enabled = True
        butnewtagihan.Enabled = True
        butrekappasien.Enabled = True
        butcreatetagihan.Enabled = True
        butdisplaytangga.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        dtakhirbayar.Enabled = True
        chkeditbayar.Enabled = True
        Button5.Enabled = True
    End Sub

    Private Sub ClearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearToolStripMenuItem.Click
        SetClear()
    End Sub

    Private Sub butfindcomp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butfindcomp.Click
        Find.Show()
        Find.QueryTheMysql("select distinct concat(kartu,'-',mesin) as CompJenis from acctranstagihandetail", " ", "FindCompTagihan", 0, Find_Keuangan)
    End Sub

    Private Sub butdisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butdisplay.Click
        If txcompanycode.Text.Trim = "" Then
            MsgBox("Pilih Company Terlebih Dahulu.", MsgBoxStyle.Exclamation, "Eror!")
            Exit Sub
        End If

        LoadData()
        butfindcomp.Enabled = False
        enablebutton()
        Button2.PerformClick()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        FormVerifikasiOmsetTagihan.SetClear()
        'FormVerifikasiOmsetTagihan.TextBoxNamaPerusahaanInvoice.Text = txcompanycode.Text
        FormVerifikasiOmsetTagihan.ShowDialog()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Dim Tlunas As DataTable = ReadThemysql("SELECT c.company, c.notagihancompany, DATE(c.tgltagihan) as tgltagihan,a.lunasid as ID,lunastgl as tgllunas,MONTH(a.lunastgl) as MM,YEAR(a.lunastgl) as YY,c.totaltagihan AS totaltagihan,c.totaltagihan-a.lunasnilai AS tambahan,a.lunasnilai as Realisasi, b.namabank,b.namarekening from acctranspelunasantagihan a INNER JOIN acctransrekaptagihan c ON a.lunasid=c.lunasid left join accmasterbank b on a.bankid=b.bankid where concat(kartu,'-',mesin)='" & txcompanycode.Text & "' and lunastgl between '" & Format(dtawalbayar.Value, "yyyyMMdd") & "' and '" & Format(dtakhirbayar.Value, "yyyyMMdd") & "'", DB_Keuangan)
        Dim Tlunas As DataTable = ReadThemysql("SELECT c.company, c.notagihancompany, DATE(c.tgltagihan) as tgltagihan,a.lunasid as ID,DATE(lunastgl) as tgllunas,MONTH(a.lunastgl) as MM,YEAR(a.lunastgl) as YY,c.totaltagihan AS totaltagihan,c.totaltagihan-a.lunasnilai AS selisih,a.lunasnilai as Realisasi, b.namabank,a.keterangan , CASE WHEN c.lunasid = 0 THEN 'BELUM LUNAS' WHEN c.lunasid <> 0 THEN 'LUNAS' END AS 'status' from acctranspelunasantagihan a INNER JOIN acctransrekaptagihan c ON a.lunasid=c.lunasid left join accmasterbank b on a.bankid=b.bankid where concat(kartu,'-',mesin)='" & txcompanycode.Text & "' and lunastgl between '" & Format(dtawalbayar.Value, "yyyyMMdd") & "' and '" & Format(dtakhirbayar.Value, "yyyyMMdd") & "'", DB_Keuangan)
        GridControl1.DataSource = Tlunas
        GridView2.Columns("ID").Visible = False
        GridView2.Columns("company").Visible = False
        GridView2.Columns("MM").Visible = False
        GridView2.Columns("YY").Visible = False
        'For Each Tnewrow As DataRow In Tlunas.Rows
        '    Dim Tadd As DataTable = ReadThemysql("select ifnull(sum(nilai),0) as Nilai from acctranspelunasantagihandetail where lunasid='" & Tnewrow("ID") & "'", DB_Keuangan)
        '    If Tadd.Rows.Count > 0 Then
        '        Dim RRow As DataRow = Tadd.Rows(0)
        '        Tnewrow("realisasi") = Tnewrow("realisasi") + RRow("Nilai")
        '    End If
        'Next

        Kalkulasi()
        'GridView2.Columns("").Visible = False
        'GridView2.Columns("").Visible = False
        'GridView2.Columns("").Visible = False

    End Sub

    Private Sub chkedit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkeditbayar.CheckedChanged
        If chkeditbayar.CheckState = CheckState.Checked Then
            dtawalbayar.Enabled = True
        Else
            dtawalbayar.Enabled = False
            dtawalbayar.Value = DateSerial("2001", "1", "1")
        End If
    End Sub

    Private Sub chkedittagihan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkedittagihan.CheckedChanged
        If chkedittagihan.CheckState = CheckState.Checked Then
            dtawal.Enabled = True
        Else
            dtawal.Enabled = False
            dtawal.Value = DateSerial("2001", "1", "1")
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Dim Ttagihan As New DataTable
        'Ttagihan = ReadThemysql("SELECT incdetailid as ID,inctgl,incjenis,jenis,incnilai as Nilai FROM acctranstagihandetail where concat(kartu,'-',mesin)='" & txcompanycode.Text & "'", DB_Keuangan)
        'gridpoli.DataSource = Ttagihan
        'GridView1.Columns("ID").Visible = False
        'GridView1.Columns("").Visible = False
        'GridView1.Columns("").Visible = False
        'GridView1.Columns("").Visible = False

        Dim Tdata As DataTable = gridpoli.DataSource
        Tdata.Rows.Clear()

        Dim Ttagihan As DataTable = ReadThemysql("SELECT *,month(inctgl) as MM,year(inctgl) as YY FROM acctranstagihandetail where concat(kartu,'-',mesin)='" & txcompanycode.Text & "' and lockeddate<>'99981231' and inctgl between '" & Format(dtawal.Value, "yyyyMMdd") & "' and '" & Format(dtakhir.Value, "yyyyMMdd") & "' ", DB_Keuangan)
        If Ttagihan.Rows.Count > 0 Then
            For Each Trow As DataRow In Ttagihan.Rows
                Dim Tnew As DataRow = Tdata.NewRow
                Tnew("ID") = Trow("incdetailid")
                Tnew("Lokasi") = Trow("loc")
                Tnew("JenisTrans") = Trow("incjenis")
                Tnew("NoTransaksi") = Trow("inctransid")
                Tnew("IDPasien") = Trow("idinternet")
                Tnew("Pasien") = Trow("Pasien")
                Tnew("JenisBayar") = Trow("jenis")
                Tnew("Kartu") = Trow("kartu")
                Tnew("Mesin") = Trow("mesin")
                Tnew("MM") = Month(Trow("inctgl"))
                Tnew("YY") = Year(Trow("inctgl"))
                Tnew("TglTrans") = Format(Trow("inctgl"), "yyyy-MM-dd")
                Tnew("NilaiUang") = Splitmoney(Trow("incnilai"))
                If Trow("lockeddate") <> DateSerial("9998", "12", "31") Then
                    Tnew("Status") = "LOCKED"
                    Tnew("Closed") = True
                    Tnew("TglClosed") = Format(Trow("lockeddate"), "dd-MMM-yyyy HH:mm")
                Else
                    Tnew("Status") = ""
                    Tnew("Closed") = False
                    Tnew("TglClosed") = ""
                End If
                Tdata.Rows.Add(Tnew)
            Next

            For Each Tcol As DataColumn In Tdata.Columns
                Tcol.ReadOnly = True
            Next
            Tdata.Columns("Closed").ReadOnly = False
            gridpoli.DataSource = Tdata
        Else
            If txcompanycode.Text <> "" Then
                MsgBox("Detail Penerimaan belum terkirim. Minta dikirim ulang dari lokal")
            End If
        End If

        GridView1.Columns("ID").Visible = False
        'GridView1.Columns("MM").Visible = False
        'GridView1.Columns("YY").Visible = False
        GridView1.Columns("Status").Visible = False
        GridView1.Columns("Closed").Visible = False
        GridView1.Columns("TglClosed").Visible = False

    End Sub

    Private Sub SetClearTagihan()
        txnotagihan.ResetText()
        txtagihanid.ResetText()
        butcreatetagihan.Enabled = True
        butrekappasien.Enabled = True
        rdrekap.Checked = False
        rdblmrekap.Checked = False
    End Sub

    Private Sub butnewtagihan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butnewtagihan.Click
        SetClearTagihan()
        Dim Tbls As DataTable = ReadThemysql("SELECT a.`RekapID`,a.`incdetailid` as ID, a.`incJenis` as Jenis , a.`inctransid` as TransID, a.`inctgl` as Tgl , a.`idinternet` as IDPasien, a.`pasien` as Nama ,a.`incnilai` as Tagihan FROM acctranstagihandetail a where concat(kartu,'-',mesin)='" & txcompanycode.Text & "' and a.`inctransid` in ('')", DB_Keuangan)
        gridtrans.DataSource = Tbls
    End Sub

    Private Sub butdisplaytangga_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butdisplaytangga.Click
        If txcompanycode.Text <> "" Then
            Dim Tbls As New DataTable
            If rdblmrekap.Checked = True Then
                'display tagihan yang blm masuk rekap
                Tbls = ReadThemysql("SELECT a.`RekapID`,a.`incdetailid` as ID, a.`incJenis` as Jenis , a.`inctransid` as TransID, a.`inctgl` as Tgl , a.`idinternet` as IDPasien, a.`pasien` as Nama ,a.`incnilai` as Tagihan FROM acctranstagihandetail a where concat(kartu,'-',mesin)='" & txcompanycode.Text & "' and rekapid in ( select rekapid from acctransrekaptagihan where  tglcetak is null)", DB_Keuangan)
            ElseIf rdrekap.Checked = True Then
                'display tagihan yang sudah masuk rekap
                Tbls = ReadThemysql("SELECT a.`RekapID`,a.`incdetailid` as ID, a.`incJenis` as Jenis , a.`inctransid` as TransID, a.`inctgl` as Tgl , a.`idinternet` as IDPasien, a.`pasien` as Nama ,a.`incnilai` as Tagihan FROM acctranstagihandetail a where concat(kartu,'-',mesin)='" & txcompanycode.Text & "' and rekapid in ( select rekapid from acctransrekaptagihan where  tglcetak is not null)", DB_Keuangan)
            End If

            gridtrans.DataSource = Tbls

            GridView3.SortInfo.ClearAndAddRange(New GridColumnSortInfo() _
                                        {New GridColumnSortInfo(GridView3.Columns("RekapID"), DevExpress.Data.ColumnSortOrder.Ascending) _
                                         }, 1)

            GridView3.ExpandAllGroups()

        Else
            MsgBox("Pilih Company terlebih dahulu!")
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butrekappasien.Click
        If txcompanycode.Text <> "" Then
            If (CheckThemysql("select * from acctransrekaptagihan where rekapid='" & txtagihanid.Text & "' and tglcetak is null and company='" & txcompanycode.Text & "' and lunasid=0", DB_Keuangan) = True And txtagihanid.Text <> "") Or txtagihanid.Text = "" Then
                RekapPasien.Clear()
                RekapPasien.QueryTheMysql(txcompanycode.Text, txtagihanid.Text, Find_Keuangan)
                RekapPasien.ShowDialog()
            Else
                MsgBox("Proses tagihan telah berjalan. Tidak bisa ditambah Pasien di Rekap")
            End If
        Else
            MsgBox("Pilih Company terlebih dahulu!")
        End If
    End Sub

    Public Sub SetGridBaru(ByRef Trow() As DataRow)
        Dim Tstr As String = "("
        For i As Integer = 0 To Trow.Length - 1
            Tstr = Tstr + "'" & Trow(i)("ID").ToString & "',"
        Next

        Dim Ttdataawal As DataTable = gridtrans.DataSource

        Dim Tdata As DataTable = gridtrans.DataSource
        Tdata.AcceptChanges()
        For Each Tgrid As DataRow In Tdata.Rows
            Tstr = Tstr + "'" & Tgrid("ID").ToString & "',"
        Next

        Dim Tresult As String = Strings.Left(Tstr, Len(Tstr) - 1) & ")"
        Dim Tbls As DataTable = ReadThemysql("SELECT a.`RekapID`,a.`incdetailid` as ID, a.`incJenis` as Jenis , a.`inctransid` as TransID, a.`inctgl` as Tgl , a.`idinternet` as IDPasien, a.`pasien` as Nama ,a.`incnilai` as Tagihan FROM acctranstagihandetail a where concat(kartu,'-',mesin)='" & txcompanycode.Text & "' and a.`incdetailid` in " & Tresult, DB_Keuangan)

        gridtrans.DataSource = Tbls
    End Sub

    Private Sub butcreatetagihan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butcreatetagihan.Click
        If txcompanycode.Text <> "" Then
            Dim Tbls As DataTable = gridtrans.DataSource
            Tbls.AcceptChanges()

            If Tbls.Rows.Count <= 0 Then
                MsgBox("Tidak ada data pasien yang direkapkan")
                Exit Sub
            End If

            If txtagihanid.Text = "" Then
                GoTo SavedData
            ElseIf CheckThemysql("select * from acctransrekaptagihan where rekapid='" & txtagihanid.Text & "' and  tglcetak is null and company='" & txcompanycode.Text & "'", DB_Keuangan) = True Then
                GoTo SavedData
            Else
                MsgBox("Data tidak dapat disimpan. Sudah dicetak atau telah terlunasi. Check kembali")
                Exit Sub
            End If

SavedData:
            Dim Tid As String = ""
            If txtagihanid.Text = "" Then
                'create new
                CreateTagihan.Clear()
                CreateTagihan.LoadTagihan("", txcompanycode.Text, gridtrans.DataSource)
                CreateTagihan.OffCetakan()
                CreateTagihan.butsaved.Enabled = True
                CreateTagihan.ShowDialog()

            Else
                'update lama
                CreateTagihan.Clear()
                CreateTagihan.LoadTagihan(txtagihanid.Text, txcompanycode.Text, gridtrans.DataSource)
                CreateTagihan.OffCetakan()
                CreateTagihan.butsaved.Enabled = True
                CreateTagihan.ShowDialog()
            End If
        Else
            MsgBox("Pilih Company terlebih dahulu!")
        End If
    End Sub

    Private Sub butfindnotagihan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butfindnotagihan.Click
        Find.Show()
        Find.QueryTheMysql("SELECT * FROM acctransrekaptagihan a where company='" & txcompanycode.Text & "'", " order by a.RekapID asc", "Findrekappelunasan", 1, Find_Keuangan)
    End Sub

    Public Sub LoadRekapTagihan(ByRef Txid As String)
        Dim Tbls As DataTable = ReadThemysql("SELECT a.`incdetailid` as ID, a.`incJenis` as Jenis , a.`inctransid` as TransID, a.`inctgl` as Tgl , a.`idinternet` as IDPasien, a.`pasien` as Nama ,a.`incnilai` as Tagihan FROM acctranstagihandetail a where  rekapid='" & Txid & "'", DB_Keuangan)
        Dim Theader As DataTable = ReadThemysql("select * from acctransrekaptagihan where rekapid='" & Txid & "'", DB_Keuangan)
        Dim RRow As DataRow = Theader.Rows(0)

        txnotagihan.Text = RRow("notagihancompany").ToString
        txtagihanid.Text = RRow("RekapID").ToString

        Dim Ttemp As DataTable = ReadThemysql("SELECT a.`RekapID`,a.`incdetailid` as ID, a.`incJenis` as Jenis , a.`inctransid` as TransID, a.`inctgl` as Tgl , a.`idinternet` as IDPasien, a.`pasien` as Nama ,a.`incnilai` as Tagihan FROM acctranstagihandetail a where concat(kartu,'-',mesin)='" & txcompanycode.Text & "' and rekapid='" & Txid & "'", DB_Keuangan)
        gridtrans.DataSource = Ttemp

        CreateTagihan.Clear()
        CreateTagihan.LoadTagihan(txtagihanid.Text, txcompanycode.Text, Tbls)
        CreateTagihan.ShowDialog()
    End Sub

    Private Sub rdrekap_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdrekap.CheckedChanged
        If rdrekap.Checked = True Then
            butrekappasien.Enabled = False
            butcreatetagihan.Enabled = False
        End If
    End Sub

    Private Sub rdblmrekap_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdblmrekap.CheckedChanged
        If rdrekap.Checked = True Then
            butrekappasien.Enabled = False
            butcreatetagihan.Enabled = False
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If txcompanycode.Text <> "" Then
            If Format(dtawallaporancompany.Value, "yyyyMMdd") <= Format(dtakhirlaporancompany.Value, "yyyyMMdd") Then
                Report = New XtraReport
                'Report = XtraReport.FromFile(Application.StartupPath + "\reports\LapTagihan2.repx", True)
                'Dim Tbls As DataTable = ReadThemysql("select a.lunasid as idlunas,a.mesin,a.kartu,a.lunastgl,a.lunasnilai,a.keterangan,a.bankid, b.rekapid,b.company,b.tgltagihan,b.periode,b.duedate,b.totaltagihan,b.notagihancompany,b.tglcetak " & _
                '                                 " from acctranspelunasantagihan a left join acctransrekaptagihan b on a.lunasid=b.lunasid where concat(kartu,'-',mesin)='" & txcompanycode.Text & "'", DB_Keuangan)

                Report = XtraReport.FromFile(Application.StartupPath + "\reports\Keuangan\TagihanPerCompany.repx", True)
                'Dim tbls As DataTable = ReadThemysql("select a.rekapid,a.company,a.tgltagihan,a.periode,a.duedate,a.totaltagihan,a.notagihancompany,a.tglcetak, b.lunasid as idlunas,b.mesin,b.kartu,b.lunastgl,b.lunasnilai,b.keterangan,b.bankid,c.namabank,c.norekening,c.namarekening,c.cabangrekening, d.coaid,e.costid,e.jenis,e.jenis as ket,d.nilai,d.createby as createcoa,d.createdate as datecoa " & _
                '                         " from acctransrekaptagihan a left join acctranspelunasantagihan b on a.lunasid=b.lunasid left join accmasterbank c on b.bankid=c.bankid left join acctranspelunasantagihandetail d on d.lunasid=a.lunasid left join accmasterpengeluaran e on e.coa=d.coaid  where a.company='" & txcompanycode.Text & "' AND date(a.tgltagihan) BETWEEN '" & Format(dtawallaporancompany.Value, "yyyyMMdd") & "' AND '" & Format(dtakhirlaporancompany.Value, "yyyyMMdd") & "'", DB_Keuangan)

                Dim tbls As DataTable = ReadThemysql("SELECT a.RekapID, a.tgltagihan, a.totaltagihan, a.notagihancompany AS notagihan, ifnull(b.lunastgl,'-') AS lunastgl,  " & _
                                        " ifnull(d.namabank,'-') AS namabank, ifnull(b.lunasnilai,0) AS lunasnilai, ifnull(c.coadetail,'-') AS coadetail, ifnull(c.nilai,0) AS coanilai, ifnull(b.lunasnilai,0)+ifnull(c.nilai,0) AS totalall  " & _
                                        " FROM acctransrekaptagihan a  " & _
                                        " LEFT JOIN acctranspelunasantagihan b ON a.lunasid=b.lunasid  " & _
                                        " LEFT JOIN acctranspelunasantagihandetail c ON b.lunasid=c.lunasid  " & _
                                        " LEFT JOIN accmasterbank d ON b.bankid=d.bankid  " & _
                                        " where a.company='" & txcompanycode.Text & "' AND date(a.tgltagihan) BETWEEN '" & Format(dtawallaporancompany.Value, "yyyyMMdd") & "' AND '" & Format(dtakhirlaporancompany.Value, "yyyyMMdd") & "'", DB_Keuangan)

                insertRowToTbls(tbls, "tyinterger", "TotalAll")

                'For i As Integer = 0 To tbls.Rows.Count - 1
                '    If i - 1 > 0 Then
                '        Dim T1 As DataRow = tbls.Rows(i - 1)
                '        Dim T2 As DataRow = tbls.Rows(i)

                '        If T1("rekapid") = T2("rekapid") Then
                '            T2("TotalAll") = "0"
                '        Else
                '            T2("TotalAll") = T2("totaltagihan")
                '        End If
                '    End If
                'Next

                'Dim tbls2 As DataTable = ReadThemysql("SELECT SUM(b.lunasnilai) AS totalpelunasan, ifnull(SUM(c.nilai),0) AS totalnilaicoa, SUM(b.lunasnilai)+ifnull(SUM(c.nilai),0) AS totalpelunasandancoa  " & _
                '                        " FROM acctransrekaptagihan a  " & _
                '                        " LEFT JOIN acctranspelunasantagihan b ON a.lunasid=b.lunasid  " & _
                '                        " LEFT JOIN acctranspelunasantagihandetail c ON b.lunasid=c.lunasid where a.company='" & txcompanycode.Text & "' AND date(a.tgltagihan) BETWEEN '" & Format(dtawallaporancompany.Value, "yyyyMMdd") & "' AND '" & Format(dtakhirlaporancompany.Value, "yyyyMMdd") & "'", DB_Keuangan)
                'For Each Trow As DataRow In tbls2.Rows

                'Next

                Report.DataSource = tbls
                Dim Tcomp() As String = txcompanycode.Text.Split("-")
                Report.Bands.Item(BandKind.ReportHeader).Controls("txtanggal").Text = Format(dtawallaporancompany.Value, "dd MMM yyyy") & " - " & Format(dtakhirlaporancompany.Value, "dd MMM yyyy")
                Report.Bands.Item(BandKind.ReportHeader).Controls("txcompany").Text = Tcomp(0).ToString & " / " & Tcomp(1).ToString
                Report.Bands.Item(BandKind.ReportHeader).Controls("txtotal").Text = Splitmoney(CDbl(ReadThemysqlNIK("SELECT ifnull(sum(a.totaltagihan),0) FROM acctransrekaptagihan a WHERE a.company='" & txcompanycode.Text & "' AND DATE(a.tgltagihan) BETWEEN '" & Format(dtawallaporancompany.Value, "yyyyMMdd") & "' AND '" & Format(dtakhirlaporancompany.Value, "yyyyMMdd") & "'", DB_Keuangan)))
                Report.Bands.Item(BandKind.ReportHeader).Controls("txblmterbayar").Text = Splitmoney(CDbl(ReadThemysqlNIK("SELECT ifnull(sum(a.totaltagihan),0) FROM acctransrekaptagihan a WHERE a.lunasid=0 AND a.company='" & txcompanycode.Text & "' AND DATE(a.tgltagihan) BETWEEN '" & Format(dtawallaporancompany.Value, "yyyyMMdd") & "' AND '" & Format(dtakhirlaporancompany.Value, "yyyyMMdd") & "'", DB_Keuangan)))
                'Dim Tnilairekap As Integer = CDbl(ReadThemysqlNIK("select ifnull(sum(a.totaltagihan),0)  from acctransrekaptagihan a where a.company='" & txcompanycode.Text & "' ", DB_Keuangan))
                'Report.Bands.Item(BandKind.ReportHeader).Controls("txrekap").Text = Splitmoney(Tnilairekap)
                Report.Bands.Item(BandKind.ReportHeader).Controls("txterbayar").Text = Splitmoney(CDbl(ReadThemysqlNIK("SELECT ifnull(sum(a.totaltagihan),0) FROM acctransrekaptagihan a WHERE a.lunasid<>0 AND a.company='" & txcompanycode.Text & "' AND DATE(a.tgltagihan) BETWEEN '" & Format(dtawallaporancompany.Value, "yyyyMMdd") & "' AND '" & Format(dtakhirlaporancompany.Value, "yyyyMMdd") & "'", DB_Keuangan)))
                'Report.Bands.Item(BandKind.ReportHeader).Controls("txrekapblmbayar").Text = Splitmoney(Tnilairekap - CInt(txtotalpembayaran.Text))
                Report.Bands.Item(BandKind.ReportFooter).Controls("lbltanggalacc").Text = ".............. ," & Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:sss")
                'Report.RunDesigner()
                Report.ShowPreview()
            Else
                MsgBox("Tanggal akhir lebih besar dari tanggal awal!")
            End If
        Else
            MsgBox("Pilih Company terlebih dahulu!")
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        If Format(dtawaltagihanbelumlunas.Value, "yyyyMMdd") <= Format(dtakhirtagihanbelumlunas.Value, "yyyyMMdd") Then
            Report = New XtraReport
            'Report = XtraReport.FromFile(Application.StartupPath + "\reports\LapTagihan2.repx", True)
            'Dim Tbls As DataTable = ReadThemysql("select a.lunasid as idlunas,a.mesin,a.kartu,a.lunastgl,a.lunasnilai,a.keterangan,a.bankid, b.rekapid,b.company,b.tgltagihan,b.periode,b.duedate,b.totaltagihan,b.notagihancompany,b.tglcetak " & _
            '                                 " from acctranspelunasantagihan a left join acctransrekaptagihan b on a.lunasid=b.lunasid where concat(kartu,'-',mesin)='" & txcompanycode.Text & "'", DB_Keuangan)

            Report = XtraReport.FromFile(Application.StartupPath + "\reports\Keuangan\TagihanBelumTerbayar.repx", True)
            Dim tbls As DataTable = ReadThemysql("SELECT a.RekapID, a.company, a.keterangan, a.notagihancompany, a.tgltagihan, a.totaltagihan, DATE_ADD(a.tgltagihan, INTERVAL a.periode DAY) as jatuh_tempo,DATEDIFF(DATE_ADD(a.tgltagihan, INTERVAL a.periode DAY), CURDATE()) as selisih " & _
                                                " FROM acctransrekaptagihan a where a.lunasid=0 AND date(a.tgltagihan) BETWEEN '" & Format(dtawaltagihanbelumlunas.Value, "yyyyMMdd") & "' AND '" & Format(dtakhirtagihanbelumlunas.Value, "yyyyMMdd") & "' ORDER BY selisih", DB_Keuangan)

            insertRowToTbls(tbls, "tyinterger", "TotalAll")

            For i As Integer = 0 To tbls.Rows.Count - 1
                If i - 1 > 0 Then
                    Dim T1 As DataRow = tbls.Rows(i - 1)
                    Dim T2 As DataRow = tbls.Rows(i)

                    If T1("rekapid") = T2("rekapid") Then
                        T2("TotalAll") = "0"
                    Else
                        T2("TotalAll") = T2("totaltagihan")
                    End If
                End If
            Next

            Report.DataSource = tbls
            Dim Tcomp() As String = txcompanycode.Text.Split("-")
            Report.Bands.Item(BandKind.ReportHeader).Controls("txcompany").Text = "All Company"
            Report.Bands.Item(BandKind.ReportHeader).Controls("txtanggal").Text = Format(dtawaltagihanbelumlunas.Value, "dd MMM yyyy") & " - " & Format(dtakhirtagihanbelumlunas.Value, "dd MMM yyyy")
            'Report.Bands.Item(BandKind.ReportHeader).Controls("txtotal").Text = ReadThemysqlNIK("SELECT SUM(a.totaltagihan) AS totaltagihan FROM acctransrekaptagihan a WHERE a.lunasid=0", DB_Keuangan)
            Report.Bands.Item(BandKind.ReportHeader).Controls("txblmterbayar").Text = Splitmoney(CDbl(ReadThemysqlNIK("SELECT ifnull(sum(a.totaltagihan),0) AS totaltagihan FROM acctransrekaptagihan a WHERE a.lunasid=0 AND date(a.tgltagihan) BETWEEN '" & Format(dtawaltagihanbelumlunas.Value, "yyyyMMdd") & "' AND '" & Format(dtakhirtagihanbelumlunas.Value, "yyyyMMdd") & "'", DB_Keuangan)))
            'Dim Tnilairekap As Integer = ReadThemysqlNIK("select ifnull(sum(a.totaltagihan),0)  from acctransrekaptagihan a where a.company='" & txcompanycode.Text & "' ", DB_Keuangan)
            'Report.Bands.Item(BandKind.ReportHeader).Controls("txrekap").Text = ReadThemysqlNIK("SELECT SUM(a.totaltagihan) AS totaltagihan FROM acctransrekaptagihan a WHERE a.lunasid=0 AND date(a.tgltagihan) BETWEEN '" & Format(dtawaltagihanbelumlunas.Value, "yyyyMMdd") & "' AND '" & Format(dtakhirtagihanbelumlunas.Value, "yyyyMMdd") & "'", DB_Keuangan)
            'Report.Bands.Item(BandKind.ReportHeader).Controls("txterbayar").Text = txtotalpembayaran.Text
            'Report.Bands.Item(BandKind.ReportHeader).Controls("txrekapblmbayar").Text = Splitmoney(Tnilairekap - CInt(txtotalpembayaran.Text))
            Report.Bands.Item(BandKind.ReportFooter).Controls("lbltanggalacc").Text = ".............. ," & Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:sss")
            'Report.RunDesigner()
            Report.ShowPreview()
        Else
            MsgBox("Tanggal akhir lebih besar dari tanggal awal!")
        End If
    End Sub
End Class

