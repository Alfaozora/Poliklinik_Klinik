Public Class FormSendTagihanApotek
    Dim thread As System.Threading.Thread

    '# Inisialisasi Variabel Lokal
    Private UserAdmin As String = PoliKlinik.Lbluser.Text
    Private getLPB As String = ""
    Private getSupplierID As String = ""
    Private getLokasiID As String = ""
    Private getLokasiKode As String = ""
    Private getOutID As String = ""
    Private getCoaJenis As String = ""
    Private getNominalPembulatan As String = ""
    Private getNominal As String = ""

    ' Set Connection
    Private Find_Keuangan2 As Find.TLconnect
    Private FindMultiple_Keuangan2 As FindMultiple.TLconnect
    Private DB_Poliklinik As TLcon
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

        ' Set Find Multiple Keuangan 2 (mitramed_keu2019)
        FindMultiple_Keuangan2.Tip = serverOnline_IP
        FindMultiple_Keuangan2.Tid = serverOnline_UserID
        FindMultiple_Keuangan2.Tpass = serverOnline_Password
        FindMultiple_Keuangan2.Tdb = Utility.GetConfig("ServerOnlineKeuangan2_DB")

        ' Set DB Poliklinik
        DB_Poliklinik.Tip = serverOnline_IP
        DB_Poliklinik.Tid = serverOnline_UserID
        DB_Poliklinik.Tpass = serverOnline_Password
        DB_Poliklinik.Tdb = Utility.GetConfig("ServerOnlinePoli_DB")

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

    Private Sub ClearHeader()
        butsaved.Enabled = True
        buttambahpasien.Enabled = True
        butselectsupp.Enabled = True
        butreject.Enabled = True
        txsuppket.ResetText()
        dtprocess.Value = DateAndTime.Now
        dtprocessend.Value = DateAndTime.Now
        txloc.ResetText()
        txpembayaran.ResetText()
        txjenispengajuan.ResetText()
        txfaktur.ResetText()
        txnominal.ResetText()
        txketreject.ResetText()

        getLPB = ""
        getSupplierID = ""
        getLokasiID = ""
        getLokasiKode = ""
        getOutID = ""
        getCoaJenis = ""
        getNominalPembulatan = "0"
        getNominal = ""
    End Sub

    Private Sub ClearGrid()
        gridrujukan.DataSource = Nothing
    End Sub

    Private Sub SetClear()
        ' Inisialisasi koneksi ke database MySQL
        SetConnectionFromConfig()

        ClearHeader()
        ClearGrid()
    End Sub

    Private Sub FormSendTagihanApotek_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        SetFormHeightWeight(Me, 0.95, 0.8)
        SetClear()
    End Sub

    Private Sub NewToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem1.Click
        SetClear()
    End Sub

    Function Checking() As Boolean
        Dim Tbls As DataTable = gridrujukan.DataSource

        If Tbls.Rows.Count > 0 Then
            'Next Step
        Else
            'Jika tidak ada data yang dipilih
            MsgBox("Pilih Faktur Terlebih Dahulu", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        Return True
    End Function

    Private Sub buttambahpasien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttambahpasien.Click
        If dtprocessend.Value < dtprocess.Value Then
            MsgBox("Tanggal Akhir tidak boleh melebihi tanggal mulai.", MsgBoxStyle.Exclamation, "Warning!")
            Exit Sub
        ElseIf getSupplierID = "" Then
            MsgBox("Masukkan Supplier.", MsgBoxStyle.Exclamation, "Warning!")
            Exit Sub
        End If

        Dim Tquery As String = ""

        'Query Utama
        Tquery = "SELECT a.rfp, a.nodoc, FORMAT(a.val,0) as 'val', date(a.tglnota) as 'Tgl Nota', a.remarkkas AS 'Supplier', a.remarkkad AS 'No. Faktur' FROM acctranspelunasanapotek a LEFT JOIN masterlokasi b ON a.cct=b.locationcode where (date(a.tglnota) BETWEEN '" & Format(dtprocess.Value, "yyyyMMdd") & "' AND '" & Format(dtprocessend.Value, "yyyyMMdd") & "') AND a.uploadstatus <> 1 AND a.rejectedstatus <> 1 AND a.remarkkas='" & txsuppket.Text & "' AND a.suppid = '" & getSupplierID & "'"

        Dim Tbls As DataTable = ReadThemysql(Tquery, DB_Keuangan2)

        If Tbls.Rows.Count > 0 Then
            FindMultiple.Show()
            FindMultiple.QueryTheMysql(Tquery, " ORDER BY a.tglnota ASC", "SelectDetailTagihanApotek", 1, FindMultiple_Keuangan2)
        Else
            MsgBox("Tidak ada data yang ditampilkan.", MsgBoxStyle.Exclamation, "Warning!")
            Exit Sub
        End If
    End Sub

    Public Sub LoadPasien(ByRef Trow() As DataRow)
        If Trow.Length = 0 Then
            SetClear()
        Else
            Dim Tquery As String = ""

            'Query Utama
            Tquery = "SELECT a.rfp AS 'Jurnal', a.val AS 'nominal_asli', FORMAT(a.val,0) as 'val', a.nodoc AS 'LPB', a.remarkkad AS 'No Faktur', DATE(a.tgljatuhtempo) AS 'Jatuh Tempo', DATE(a.tglnota) AS 'Tanggal Nota' FROM acctranspelunasanapotek a LEFT JOIN masterlokasi b ON a.cct=b.locationcode where a.uploadstatus <> 1 AND a.rejectedstatus <> 1 AND a.remarkkas='" & txsuppket.Text & "'"

            Dim Tstr As String = ""
            Dim Ttemp As String = "("
            For i As Integer = 0 To Trow.Length - 1
                Ttemp = Ttemp & "'" & Trow(i)("nodoc").ToString.Trim & "',"
            Next
            Tstr = Strings.Left(Ttemp, Ttemp.Length - 1) & ")"
            getLPB = Tstr.Replace(")", "").Replace("(", "")

            Dim Tbls As DataTable = New DataTable

            Tbls = ReadThemysql(Tquery + " and a.nodoc in " & Tstr & " ORDER BY a.tglnota ASC", DB_Keuangan2)

            If Tbls.Rows.Count > 0 Then
                gridrujukan.DataSource = Tbls
                GridView1.Columns("nominal_asli").Visible = False
                SetHeader()
            Else
                MsgBox("Tidak ada data yang ditampilkan.", MsgBoxStyle.Exclamation, "Warning!")
                Exit Sub
            End If
        End If
    End Sub

    Private Sub SetHeader()
        Dim Tbls As DataTable = gridrujukan.DataSource
        Dim TotalPembulatan As Double = 0
        Dim Total As Double = 0
        Dim Years As Integer = 0
        Dim Month As Integer = 0
        Dim JumlahTransaksi As Integer = 0
        Dim NoFaktur As String = ""

        For Each Ttemp As DataRow In Tbls.Rows
            TotalPembulatan = TotalPembulatan + Ttemp("val")
            Total = Total + Ttemp("nominal_asli")
            JumlahTransaksi = JumlahTransaksi + 1
            NoFaktur = Ttemp("No Faktur")

            'Set Tanggal
            dttglnota.Value = Ttemp("Tanggal Nota")
            Years = CDbl(Format(Ttemp("Tanggal Nota"), "yyyy"))
            Month = CDbl(Format(Ttemp("Tanggal Nota"), "MM"))
            dttglbeban.Value = New DateTime(Years, Month, DateTime.DaysInMonth(Years, Month))
        Next

        If JumlahTransaksi = 1 Then
            txfaktur.Text = NoFaktur
        Else
            txfaktur.Text = JumlahTransaksi & " FAKTUR"
        End If

        getNominal = Total
        getNominalPembulatan = TotalPembulatan
        txnominal.Text = Format(Val(TotalPembulatan), "Rp, ###,###.#0")
        butselectsupp.Enabled = False
    End Sub

    Function CreateTable() As DataTable
        Dim Thasil As New DataTable

        insertRowToTbls(Thasil, "Typstring", "No")
        insertRowToTbls(Thasil, "Typstring", "No Lab")
        insertRowToTbls(Thasil, "typdate", "Tanggal Lab")
        insertRowToTbls(Thasil, "Typstring", "Nama")
        insertRowToTbls(Thasil, "typdate", "Tgl Lahir")
        insertRowToTbls(Thasil, "tyinterger", "Translabid")

        For Each Tcol As DataColumn In Thasil.Columns
            Tcol.ReadOnly = True
        Next

        Return Thasil
    End Function

    Private Sub butlabrujukan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butselectsupp.Click
        Find.Show()
        Find.QueryTheMysql("SELECT a.remarkkas AS 'Nama Perusahaan', a.cct AS 'Jenis', a.suppid AS 'ID Supplier' FROM acctranspelunasanapotek a WHERE a.uploadstatus=0 AND a.rejectedstatus <> 1 AND a.notrans IS NULL GROUP BY a.remarkkas, a.suppid ORDER BY a.remarkkas", " ", "FindSupplierTagihanApotek", 0, Find_Keuangan2)
    End Sub

    Private Sub butsaved_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butsaved.Click
        If Checking() = True Then
            Dim NoTransaksi As String = ""
            Dim UserID As String = ReadThemysqlNIK("SELECT a.bridginguser FROM users a WHERE a.username = '" & UserAdmin & "'", DB_Poliklinik)

            'Insert Transaksi Baru
            WriteThemysql("INSERT INTO `acctranskas` (`outid`, `pengajuan`, `transtgl`, `createdby`, `createddate`, `accuserby`, `accuserdate`, `accuserstatus`, `acc1by`, `acc1date`, `acc1status`, `keterangan`, `bebantgl`, `nilaiuang`, `nomorfaktur`, `supplierid`, `loc`, `rfp`, `realisasi`) " & _
                          "VALUES ('" & getOutID & "', '1', '" & Format(dttglnota.Value, "yyyyMMdd") & "', '" & UserID & "', NOW(), '" & UserID & "', NOW(), '1', '" & UserID & "', NOW(), '1', '" & txsuppket.Text.ToUpper & "', '" & Format(dttglbeban.Value, "yyyyMMdd") & "', '" & CDbl(getNominalPembulatan) & "', '" & txfaktur.Text & "', '" & getSupplierID & "', '" & getLokasiID & "', 1, '" & CDbl(getNominalPembulatan) & "')", DB_Keuangan2)

            NoTransaksi = ReadThemysqlNIK("SELECT a.notrans AS a FROM acctranskas a WHERE a.outid='" & getOutID & "' and a.pengajuan=1 and date(a.transtgl)='" & Format(dttglnota.Value, "yyyyMMdd") & "' and date(a.bebantgl)='" & Format(dttglbeban.Value, "yyyyMMdd") & "' and  a.supplierid='" & getSupplierID & "' and a.rfp=1 and a.keterangan='" & txsuppket.Text & "' ORDER BY a.transoutid DESC LIMIT 1", DB_Keuangan2)

            WriteThemysql("update acctranspelunasanapotek a set a.uploadstatus=1, uploadby='" & UserAdmin & "', uploaddate=NOW(), notrans='" & NoTransaksi & "' WHERE a.nodoc IN (" & getLPB & ") and rejectedstatus <> 1", DB_Keuangan2)

            '# Send Jurnal Perkiraan
            SendJurnalUMH(NoTransaksi)

            MsgBox("Berhasil Menyimpan Data dengan No. Transaksi: " & NoTransaksi & "", MsgBoxStyle.Information, "Success!")
            butsaved.Enabled = False
            buttambahpasien.Enabled = False
            butselectsupp.Enabled = False
            butreject.Enabled = False
        End If
    End Sub

    Public Sub LoadSupplier(ByRef txid As String, ByRef txket As String, ByRef txjenis As String)
        txsuppket.Text = txket
        getSupplierID = txid
        getLokasiKode = txjenis

        'Set Lokasi
        Dim Tloc As DataTable = ReadThemysql("SELECT a.locid, a.locationket FROM masterlokasi a WHERE a.locationcode = '" & txjenis & "'", DB_Keuangan2)
        Dim Trowloc As DataRow = Tloc.Rows(0)
        txloc.Text = Trowloc("locationket")
        getLokasiID = Trowloc("locid")

        txpembayaran.Text = ReadThemysqlNIK(" SELECT if(a.supplierid=1,'TUNAI', concat(a.suppliernama, ' - ', b.norekening, ' (', b.namabank ,') a/n ' , b.namarekening)) AS supplier" & _
                                            " FROM mastersupplier a" & _
                                            " LEFT JOIN accmasterbank b on a.supplierid=b.supplierid" & _
                                            " WHERE a.supplierid='" & txid & "'", DB_Keuangan2)

        'Set OutID
        Dim Toutid As DataTable = ReadThemysql("SELECT b.jenis, b.outid as outid, b.coa FROM mastersetting a LEFT JOIN accmasterpengeluaran b ON a.value=b.coa WHERE a.name='CoaUtangPembelianObat'", DB_Keuangan2)
        Dim Trow As DataRow = Toutid.Rows(0)
        getOutID = Trow("outid")
        getCoaJenis = Trow("coa")
        txjenispengajuan.Text = Trow("jenis").ToString.ToUpper
    End Sub

    Private Sub butreject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butreject.Click
        Dim KetReject As String = txketreject.Text

        'Set Reject di Program Keu
        WriteThemysql("update acctranspelunasanapotek set rejectedstatus=1, rejecteddate=NOW(), rejectedby='" & UserAdmin & "' where nodoc IN (" & getLPB & ")", DB_Keuangan2)

        'Set Reject di Program GL
        WriteThemysql("update rhp set payment=0 where jurnal IN (" & getLPB & ")", DB_Jurnal)
        WriteThemysql("update lph set sendkeu=0 where lph IN (" & getLPB & ")", DB_Jurnal)

        'Search RFP
        Dim Trfp As DataTable = ReadThemysql("SELECT a.rfp FROM acctranspelunasanapotek a WHERE a.nodoc IN (" & getLPB & ")", DB_Keuangan2)
        Dim Tstr As String = ""
        Dim Ttemp As String = "("
        For Each Trow As DataRow In Trfp.Rows
            Ttemp = Ttemp & "'" & Trow("rfp").ToString.Trim & "',"
        Next
        Tstr = Strings.Left(Ttemp, Ttemp.Length - 1) & ")"

        WriteThemysql("update rfd set reject=1 where rfp IN " & Tstr & "", DB_Jurnal)
        WriteThemysql("update rfp set ketreject='" & KetReject & "' where rfp IN " & Tstr & "", DB_Jurnal)

        MsgBox("Berhasil Reject Data. (" & getLPB & ")", MsgBoxStyle.Information, "Success!")
        butsaved.Enabled = False
        buttambahpasien.Enabled = False
        butselectsupp.Enabled = False
        butreject.Enabled = False
    End Sub

    Private Sub SendJurnalUMH(ByVal noTransaksi As String)
        Dim ketTransaksi As String = txsuppket.Text
        Dim tglTransaksi As String = Format(dttglnota.Value, "yyyy-MM-dd")
        Dim jurnalLokasi As String = ""
        Dim noUrut As String = ""
        Dim flag As String = ""
        Dim coaAccruedExpense As String = ReadThemysqlNIK("SELECT b.coa FROM accmasterpengeluaran a LEFT JOIN accmasterpengeluarankomponen b ON a.komponen=b.komponen WHERE a.coa = '" & getCoaJenis & "' LIMIT 1", DB_Keuangan2)
        Dim jurnalUMH As String = ""

        '# Set Lokasi Jurnal
        jurnalLokasi = ReadThemysqlNIK("SELECT a.bsa as a FROM bsa a WHERE a.bsaname='" & getLokasiKode & "'", DB_Jurnal)

        '# Set Flag Jurnal
        Dim Tdetail() As String = noTransaksi.Split("/")

        noUrut = ReadThemysqlNIK("SELECT CONCAT(lpad(RIGHT(a.flag_umh,5)+1,5,0)) FROM acctranskas a WHERE a.flag_umh LIKE '%" & Tdetail(0) & Tdetail(1) & Tdetail(3) & "%' ORDER BY a.flag_umh DESC LIMIT 1", DB_Keuangan2)

        If IsDBNull(noUrut) = False And noUrut <> "" And noUrut <> "-" Then
            flag = Tdetail(0) & Tdetail(1) & Tdetail(3) & "UMH" & noUrut.Trim
        Else
            flag = Tdetail(0) & Tdetail(1) & Tdetail(3) & "UMH" & "00001"
        End If

        '# Sending Jurnal UMH
        WriteThemysql("SELECT F_MakeUMH('" & flag & "', 'out', '', '" & tglTransaksi & "', '" & coaAccruedExpense & "', '" & getCoaJenis & "', 'IDR', 1, " & CDbl(getNominal) & ", '" & ketTransaksi & "', '1', '1', '', '" & ketTransaksi & "', '" & flag & "', '', '" & jurnalLokasi & "', 1, " & CDbl(getNominal) & ", 'D')", DB_Jurnal)

        '# Get No Jurnal
        jurnalUMH = ReadThemysqlNIK("SELECT a.umh FROM umh a WHERE a.oms = '" & flag & "'", DB_Jurnal)

        '# Update flag & jurnal di tabel acctranskas
        WriteThemysql("UPDATE acctranskas SET val_rfp = '" & CDbl(getNominal) & "', flag_umh = '" & flag & "', jurnal_umh = '" & jurnalUMH & "' WHERE notrans = '" & noTransaksi & "'", DB_Keuangan2)
    End Sub
End Class
