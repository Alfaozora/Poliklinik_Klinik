Public Class FormSendPengajuanDanKasKecil
    Dim thread As System.Threading.Thread
    Private UserAdmin As String = PoliKlinik.Lbluser.Text

    ' Set Connection
    Private Find_Keuangan2 As Find.TLconnect
    Private DB_Keuangan2 As TLcon
    Private DB_Jurnal As TLcon

    Private Sub SetConnectionFromConfig()
        ' Set Parameter Server Online
        Dim serverOnline_IP As String = Utility.GetConfig("ServerOnline_IP")
        Dim serverOnline_UserID As String = Utility.GetConfig("ServerOnline_UserID")
        Dim serverOnline_Password As String = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerOnline_Password"), "albert")

        ' Set Find Keuangan 2 (mitramed_keu2019)
        Find_Keuangan2.Tip = serverOnline_IP
        Find_Keuangan2.Tid = serverOnline_UserID
        Find_Keuangan2.Tpass = serverOnline_Password
        Find_Keuangan2.Tdb = Utility.GetConfig("ServerOnlineKeuangan2_DB")

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

    Private Sub DisableAll()
        butselectlocation.Enabled = False
        butselectbank.Enabled = False
        rdpengajuan.Enabled = False
        rdkaskecil.Enabled = False
        txnominal.Enabled = False
        dtprocess.Enabled = False
        dtprocessend.Enabled = False
        CheckAll.Enabled = False
        butkalkulasi.Enabled = False
        butsaved.Enabled = False
        butsearch.Enabled = False
        txlocationket.Enabled = False
        txbankket.Enabled = False
        NewToolStripMenuItem1.Enabled = False
    End Sub

    Private Sub EnableAll()
        butselectlocation.Enabled = True
        butselectbank.Enabled = True
        rdpengajuan.Enabled = True
        rdkaskecil.Enabled = True
        txnominal.Enabled = True
        dtprocess.Enabled = True
        dtprocessend.Enabled = True
        CheckAll.Enabled = True
        butkalkulasi.Enabled = True
        butsaved.Enabled = True
        butsearch.Enabled = True
        txlocationket.Enabled = True
        txbankket.Enabled = True
    End Sub

    Private Sub ClearHeader()
        CheckAll.Checked = False
        rdpengajuan.Checked = True
        butsaved.Enabled = True
        butselectlocation.Enabled = True
        txlocationid.ResetText()
        txlocationket.ResetText()
        dtprocess.Value = DateAndTime.Now
        dtprocessend.Value = DateAndTime.Now
        txnominal.ResetText()
        txsendnominal.ResetText()
        txbankket.ResetText()
        txbankid.ResetText()
    End Sub

    Private Sub ClearGrid()
        gridtransaksi.DataSource = Nothing
    End Sub

    Private Sub SetClear()
        ' Inisialisasi koneksi ke database MySQL
        SetConnectionFromConfig()

        EnableAll()
        ClearHeader()
        ClearGrid()
    End Sub

    Private Sub FormSendKasKecil_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        SetFormHeightWeight(Me, 0.95, 0.8)
        Control.CheckForIllegalCrossThreadCalls = False
        SetClear()
    End Sub

    Private Sub NewToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem1.Click
        SetClear()
    End Sub

    Function Checking() As Boolean
        Dim Tbls As DataTable = gridtransaksi.DataSource

        If Tbls.Select("[Select]=1").Count > 0 Then
            'Next Step
        Else
            'Jika tidak ada data yang dipilih
            MsgBox("Pilih Data Terlebih Dahulu", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        Return True
    End Function

    Private Sub butlabrujukan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butselectlocation.Click
        Find.Show()
        Find.QueryTheMysql("SELECT a.locationket, a.locationcode, b.locationgroupket, a.locid FROM masterlokasi a LEFT JOIN mastergruplokasi b ON a.locgroup=b.locgroupcode WHERE a.locgroup <> '0'", " ORDER BY a.locid ASC", "FindLocationKasKecilPengajuan", 0, Find_Keuangan2)
    End Sub

    Private Sub butsaved_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butsaved.Click
        If Checking() = True Then
            DisableAll()

            ProgressBar1.Visible = True
            ProgressBar1.Value = 0

            thread = New System.Threading.Thread(AddressOf SendJurnal)
            thread.Start()
        End If
    End Sub

    Private Sub SendJurnal()
        Dim CoaPrepaidExpense As String = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPrepaidExpense'", DB_Keuangan2)
        Dim CoaAccruedExpense As String = ""
        Dim bsa As String = ""
        Dim flag As String = ""
        Dim Nourut As String = ""
        Dim procent As Integer = 0
        Dim persen As Integer = 0
        Dim keterangan As String = ""
        Dim databaseGL As String = ""

        Dim Ttable As DataTable = gridtransaksi.DataSource
        For Each Trow As DataRow In Ttable.Select("[Select]=1")
            persen = persen + 1
            procent = persen * 100 / Ttable.Select("[Select]=1").Count
            ProgressBar1.Value = procent

            'Set Database
            DB_Jurnal.Tdb = Trow("setDB").ToString

            'Set bsa
            bsa = ReadThemysqlNIK("SELECT a.bsa as a FROM bsa a WHERE a.bsaname='" & Trow("locationcode").ToString.Trim & "'", DB_Jurnal)

            'Set Flag
            Dim Tdetail() As String = Trow("Kode Transaksi").ToString.Split("/")

            Nourut = ReadThemysqlNIK("SELECT concat(lpad(RIGHT(a.flag,5)+1,5,0)) FROM acctranskas a WHERE a.flag LIKE '%" & Tdetail(0) & Tdetail(1) & Tdetail(3) & "%' ORDER BY a.flag DESC LIMIT 1", DB_Keuangan2)

            If IsDBNull(Nourut) = False And Nourut <> "" And Nourut <> "-" Then
                flag = Tdetail(0) & Tdetail(1) & Tdetail(3) & Nourut.Trim
            Else
                flag = Tdetail(0) & Tdetail(1) & Tdetail(3) & "00001"
            End If

            keterangan = Trow("Keterangan").ToString.ToUpper()

            'Send GL
            If rdpengajuan.Checked = True Then 'Pengajuan
                If Format(Trow("Tgl Transaksi"), "MM") = Format(Trow("Tgl Realisasi"), "MM") Then
                    'KAS
                    WriteThemysql("SELECT F_MakeKAS('" & flag & "', 'out', '', '" & Format(Trow("Tgl Realisasi"), "yyyy-MM-dd") & "', '" & Trow("coabankpengirim").ToString.Trim & "', '" & Trow("coajenis").ToString.Trim & "', 'IDR', 1, " & CDbl(Trow("Nominal")) & ", '" & keterangan & "', '1', '1', '', '" & keterangan & "', '" & flag & "', '', '" & bsa & "', 3, " & CDbl(Trow("Nominal")) & ", 'D')", DB_Jurnal)
                Else
                    If Format(Trow("Tgl Transaksi"), "yyyy-MM-dd") < Format(Trow("Tgl Realisasi"), "yyyy-MM-dd") Then
                        CoaAccruedExpense = ReadThemysqlNIK("SELECT b.coa AS 'a' FROM accmasterpengeluaran a LEFT JOIN accmasterpengeluarankomponen b ON a.komponen=b.komponen WHERE a.coa = '" & Trow("coajenis").ToString.Trim & "' LIMIT 1", DB_Keuangan2)

                        If CheckThemysql("SELECT * FROM accmasterpengeluaran a WHERE a.statusumh IS TRUE AND a.coa IN ('" & Trow("coajenis").ToString.Trim & "')", DB_Keuangan2) = True Then
                            'UMH
                            WriteThemysql("SELECT F_MakeUMH('" & flag & "', 'out', '', '" & Format(Trow("Tgl Transaksi"), "yyyy-MM-dd") & "', '" & CoaAccruedExpense & "', '" & Trow("coajenis").ToString.Trim & "', 'IDR', 1, " & CDbl(Trow("Nominal")) & ", '" & keterangan & "', '1', '1', '', '" & keterangan & "', '" & flag & "', '', '" & bsa & "', 1, " & CDbl(Trow("Nominal")) & ", 'D')", DB_Jurnal)
                        End If

                        'KAS
                        WriteThemysql("SELECT F_MakeKAS('" & flag & "', 'out', '', '" & Format(Trow("Tgl Realisasi"), "yyyy-MM-dd") & "', '" & Trow("coabankpengirim").ToString.Trim & "', '" & CoaAccruedExpense & "', 'IDR', 1, " & CDbl(Trow("Nominal")) & ", '" & keterangan & "', '1', '1', '', '" & keterangan & "', '" & flag & "', '', '" & bsa & "', 3, " & CDbl(Trow("Nominal")) & ", 'D')", DB_Jurnal)
                    ElseIf Format(Trow("Tgl Transaksi"), "yyyy-MM-dd") > Format(Trow("Tgl Realisasi"), "yyyy-MM-dd") Then
                        If CheckThemysql("SELECT * FROM accmasterpengeluaran a WHERE a.statusumh IS TRUE AND a.coa IN ('" & Trow("coajenis").ToString.Trim & "')", DB_Keuangan2) = True Then
                            'UMH
                            WriteThemysql("SELECT F_MakeUMH('" & flag & "', 'out', '', '" & Format(Trow("Tgl Transaksi"), "yyyy-MM-dd") & "', '" & CoaPrepaidExpense & "', '" & Trow("coajenis").ToString.Trim & "', 'IDR', 1, " & CDbl(Trow("Nominal")) & ", '" & keterangan & "', '1', '1', '', '" & keterangan & "', '" & flag & "', '', '" & bsa & "', 1, " & CDbl(Trow("Nominal")) & ", 'D')", DB_Jurnal)
                        End If

                        'KAS
                        WriteThemysql("SELECT F_MakeKAS('" & flag & "', 'out', '', '" & Format(Trow("Tgl Realisasi"), "yyyy-MM-dd") & "', '" & Trow("coabankpengirim").ToString.Trim & "', '" & CoaPrepaidExpense & "', 'IDR', 1, " & CDbl(Trow("Nominal")) & ", '" & keterangan & "', '1', '1', '', '" & keterangan & "', '" & flag & "', '', '" & bsa & "', 3, " & CDbl(Trow("Nominal")) & ", 'D')", DB_Jurnal)
                    End If
                End If
            ElseIf rdkaskecil.Checked = True Then 'Kas Kecil
                If CheckThemysql("SELECT * FROM accmasterpengeluaran a WHERE a.statusumh IS TRUE AND a.coa IN ('" & Trow("coajenis").ToString.Trim & "')", DB_Keuangan2) = True Then
                    'UMH
                    WriteThemysql("SELECT F_MakeUMH('" & flag & "', 'out', '', '" & Format(Trow("Tgl Transaksi"), "yyyy-MM-dd") & "', '" & Trow("coabankpenerima").ToString.Trim & "', '" & Trow("coajenis").ToString.Trim & "', 'IDR', 1, " & CDbl(Trow("Nominal")) & ", '" & keterangan & "', '1', '1', '', '" & keterangan & "', '" & flag & "', '', '" & bsa & "', 1, " & CDbl(Trow("Nominal")) & ", 'D')", DB_Jurnal)
                End If

                'KAS
                WriteThemysql("SELECT F_MakeKAS('" & flag & "', 'out', '', '" & Format(Trow("Tgl Realisasi"), "yyyy-MM-dd") & "', '" & Trow("coabankpengirim").ToString.Trim & "', '" & Trow("coabankpenerima").ToString.Trim & "', 'IDR', 1, " & CDbl(Trow("Nominal")) & ", '" & keterangan & "', '1', '1', '', '" & keterangan & "', '" & flag & "', '', '" & bsa & "', 3, " & CDbl(Trow("Nominal")) & ", 'D')", DB_Jurnal)
            End If

            'Update acctranskas
            WriteThemysql("UPDATE acctranskas SET flag='" & flag & "' WHERE transoutid = '" & Trow("transoutid") & "'", DB_Keuangan2)
        Next

        MsgBox("Jurnal & Data Saved.", MsgBoxStyle.Information, "Success!")
        NewToolStripMenuItem1.Enabled = True
    End Sub

    Public Sub LoadLocation(ByRef setID As String, ByRef setKeterangan As String)
        txlocationket.Text = setKeterangan
        txlocationid.Text = setID
    End Sub

    Private Sub butselectbank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butselectbank.Click
        Find.Show()
        Find.QueryTheMysql("SELECT concat(namabank,'-',norekening) as Bank, a.bankid FROM acctranskas a LEFT JOIN accmasterbank b ON a.bankid=b.bankid WHERE a.realisasistatus = 1 AND a.bankid <> 0 GROUP BY a.bankid", " ORDER BY a.bankid ASC", "FindBankKasKecilPengajuan", 0, Find_Keuangan2)
    End Sub

    Public Sub LoadBank(ByRef txid As String, ByRef txket As String)
        txbankket.Text = txket
        txbankid.Text = txid
    End Sub

    Private Sub butsearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butsearch.Click
        Dim Tquery As String = ""
        Dim Tlocation As String = ""
        Dim Tbank As String = ""
        Dim Tjenistransaksi As String = ""
        Dim TorderBy As String = ""
        Dim Tbls As DataTable = New DataTable

        'Query Utama
        Tquery = "SELECT h.db_gl as 'setDB', a.transoutid, a.notrans AS 'Kode Transaksi', b.jenis AS 'Detail Jenis', LEFT(a.keterangan, 200) AS 'Keterangan', g.suppliernama AS 'Supplier', c.locationket AS 'Lokasi', FORMAT(a.realisasi,0) AS 'Nominal', DATE(a.realisasidate) AS 'Tgl Realisasi', DATE(a.transtgl) AS 'Tgl Transaksi', CONCAT(e.namabank,'-',e.norekening) AS 'Transfer Dari', CONCAT(f.namabank,'-',f.norekening) AS 'Transfer Ke', e.coa AS 'coabankpengirim', f.coa AS 'coabankpenerima', b.coa AS 'coajenis', c.locationcode FROM acctranskas a " & _
                 " INNER JOIN accmasterpengeluaran b ON a.outid = b.outid INNER JOIN masterlokasi c ON a.loc = c.locid " & _
                 " INNER JOIN accmasterbank e ON a.bankid = e.bankid " & _
                 " INNER JOIN accmasterbank f ON a.bankiddest = f.bankid " & _
                 " INNER JOIN mastersupplier g ON a.supplierid = g.supplierid " & _
                 " INNER JOIN mastergruplokasi h ON c.locgroup=h.locgroupcode " & _
                 " WHERE a.acc3status = 1 AND a.closed != 0 AND a.flag IS NULL AND a.flag_umh IS NULL AND a.flag_bkk IS NULL AND Date(a.realisasidate) BETWEEN '" & Format(dtprocess.Value, "yyyyMMdd") & "' AND '" & Format(dtprocessend.Value, "yyyyMMdd") & "'"

        'Set Jenis Transaksi
        If rdkaskecil.Checked = True Then
            Tjenistransaksi = " AND a.pengajuan = 0 "
        Else
            Tjenistransaksi = " AND a.pengajuan = 1 "
        End If

        'Set Location
        If txlocationid.Text <> "" Then
            Tlocation = " AND a.loc = '" & txlocationid.Text & "' "
        End If

        'Set Bank
        If txbankid.Text <> "" Then
            Tbank = " AND a.bankid = '" & txbankid.Text & "' "
        End If

        'Set Order By
        TorderBy = " ORDER BY c.locationket, a.realisasidate ASC"

        Tbls = ReadThemysql(Tquery & Tjenistransaksi & Tlocation & Tbank & TorderBy, DB_Keuangan2)
        insertRowToTbls(Tbls, "typchecked", "Select")

        For Each Tcol As DataColumn In Tbls.Columns
            Tcol.ReadOnly = True
        Next

        Tbls.Columns("Select").ReadOnly = False

        gridtransaksi.DataSource = Tbls
        GridView1.Columns("Select").Width = 50
        GridView1.Columns("Tgl Transaksi").Width = 100
        GridView1.Columns("Tgl Realisasi").Width = 100
        GridView1.Columns("coabankpengirim").Visible = False
        GridView1.Columns("coabankpenerima").Visible = False
        GridView1.Columns("coajenis").Visible = False
        GridView1.Columns("locationcode").Visible = False
        GridView1.Columns("transoutid").Visible = False
        GridView1.Columns("setDB").Visible = False

        If rdkaskecil.Checked = True Then
            GridView1.Columns("Supplier").Visible = False
        ElseIf rdkaskecil.Checked = False Then
            GridView1.Columns("Supplier").Visible = True
        End If

        If rdkaskecil.Checked = True Then
            rdpengajuan.Enabled = False
        ElseIf rdpengajuan.Checked = True Then
            rdkaskecil.Enabled = False
        End If
    End Sub

    Private Sub butkalkulasi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butkalkulasi.Click
        Dim Ttable As DataTable = gridtransaksi.DataSource
        Dim total As Integer = 0

        If Ttable Is Nothing = False Then
            For Each Trownew As DataRow In Ttable.Select("[Select]=1")
                total = total + Trownew("Nominal")
            Next

            txsendnominal.Text = total
            If total = 0 Then
                txnominal.Text = "Rp 0"
            Else
                txnominal.Text = Format(Val(total), "Rp, ###,###")
            End If
        Else
            MsgBox("Tidak ada data yang akan di kalkulasi.", MsgBoxStyle.Exclamation, "Warning!")
        End If
    End Sub

    Private Sub CheckAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckAll.CheckedChanged
        Dim Tbls As DataTable = gridtransaksi.DataSource

        If Tbls.Rows.Count > 0 Then
            For Each Trow As DataRow In Tbls.Rows
                If CheckAll.CheckState = CheckState.Checked Then
                    Trow("Select") = True
                    butkalkulasi.PerformClick()
                Else
                    Trow("Select") = False
                    butkalkulasi.PerformClick()
                End If
            Next
        End If
    End Sub
End Class