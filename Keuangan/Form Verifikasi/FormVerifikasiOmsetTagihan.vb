Public Class FormVerifikasiOmsetTagihan
    ' Set Connection
    Private Find_Jurnal As Find.TLconnect
    Private Find_Keuangan As Find.TLconnect
    Private Find_Omset As Find.TLconnect
    Private DB_Keuangan As TLcon
    Private DB_Jurnal As TLcon
    Private DB_Poliklinik As TLcon
    Private DB_Omset As TLcon

    ' Set Private Variabel
    Private kodeLokasiKlinik As String = ""
    Private jenisTransaksi As String = ""
    Private jenisPoli As String = ""
    Private jurnalDB As String = ""
    Private jurnalMethod As String = ""

    Private userInput As String = PoliKlinik.Lbluser.Text

    Private Sub SetConnectionFromConfig()
        ' Set Parameter Server Online
        Dim serverOnline_IP As String = Utility.GetConfig("ServerOnline_IP")
        Dim serverOnline_UserID As String = Utility.GetConfig("ServerOnline_UserID")
        Dim serverOnline_Password As String = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerOnline_Password"), "albert")

        ' Set Find Jurnal
        Find_Jurnal.Tip = Utility.GetConfig("ServerJurnal_IP")
        Find_Jurnal.Tid = Utility.GetConfig("ServerJurnal_UserID")
        Find_Jurnal.Tpass = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerJurnal_Password"), "albert")
        Find_Jurnal.Tdb = Utility.GetConfig("ServerJurnal_DB")

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

        ' Set DB Jurnal
        DB_Jurnal.Tip = Utility.GetConfig("ServerJurnal_IP")
        DB_Jurnal.Tid = Utility.GetConfig("ServerJurnal_UserID")
        DB_Jurnal.Tpass = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerJurnal_Password"), "albert")
        DB_Jurnal.Tdb = Utility.GetConfig("ServerJurnal_DB")

        ' Set DB Poliklinik
        DB_Poliklinik.Tip = serverOnline_IP
        DB_Poliklinik.Tid = serverOnline_UserID
        DB_Poliklinik.Tpass = serverOnline_Password
        DB_Poliklinik.Tdb = Utility.GetConfig("ServerOnlinePoli_DB")

        ' Set Find Omset (mitramedicare_omset_keuangan)
        Find_Omset.Tip = serverOnline_IP
        Find_Omset.Tid = serverOnline_UserID
        Find_Omset.Tpass = serverOnline_Password
        Find_Omset.Tdb = Utility.GetConfig("ServerOnlineOmset_DB")

        ' Set Find Keuangan 1 (mitramed_keu)
        Find_Keuangan.Tip = serverOnline_IP
        Find_Keuangan.Tid = serverOnline_UserID
        Find_Keuangan.Tpass = serverOnline_Password
        Find_Keuangan.Tdb = Utility.GetConfig("ServerOnlineKeuangan_DB")
    End Sub

    Public Sub SetClear()
        ' Inisialisasi koneksi ke database MySQL
        SetConnectionFromConfig()

        ' Set Clear Detail Tagihan
        TextBoxNominalInvoice.Value = 0
        TextBoxNamaPerusahaanInvoice.ResetText()
        TextBoxNomorInvoice.ResetText()
        TextBoxNominalInvoice.ResetText()
        TglInvoice.Value = DateAndTime.Now
        TglJatuhTempoInvoice.Value = DateAndTime.Now

        ' Set Clear Detail Pembayaran
        TextBoxTotalBayar.Value = 0
        TglTransferPembayaran.Value = DateAndTime.Now
        TextBoxBankTransferCoa.ResetText()
        TextBoxBankTransferKeterangan.ResetText()
        TextBoxKeteranganPembayaran.ResetText()
        TextBoxKeteranganPembayaran.Enabled = True
        CheckBoxSesuaiNominalTagihan.Checked = False
    End Sub

    Private Sub SetClearDetailCOA()
        TextBoxDetailTambahanCoa.ResetText()
        TextBoxDetailTambahanKeterangan.ResetText()
        TextBoxDetailTambahanNominal.Value = 0
    End Sub

    Private Sub SetGrid()
        DataGridViewDetailCOA.DataSource = ReadThemysql("SELECT coaid as coa,coadetail as jenis,nilai FROM acctranspelunasantagihandetail where lunasid=-1", DB_Keuangan)
        DataGridViewDetailCOA.ReadOnly = True
    End Sub

    Function ValidasiPembayaran() As Boolean
        'If GridView1.RowCount = 0 Then
        '    MsgBox("Pilih Rekap Tagihan Terlebih Dahulu.", MsgBoxStyle.Exclamation, "Eror!")
        '    Return False
        'ElseIf GridView1.RowCount > 1 Then
        '    MsgBox("Maksimal Rekap yang dipilih hanya boleh 1.", MsgBoxStyle.Exclamation, "Eror!")
        '    Return False
        'End If

        If TextBoxNomorInvoice.Text = "" Then
            MsgBox("Pilih Rekap Tagihan Terlebih Dahulu.", MsgBoxStyle.Exclamation, "Eror!")
            Return False
        End If

        If TextBoxTotalBayar.Text <= 0 Then
            MsgBox("Nilai kurang dari nol. Check kembali.", MsgBoxStyle.Exclamation, "Eror!")
            Return False
        End If

        If TglTransferPembayaran.Value > DateAndTime.Now Then
            MsgBox("Tanggal Transfer tidak boleh lebih besar dari tanggal sekarang.", MsgBoxStyle.Exclamation, "Eror!")
            Return False
        End If

        If MessageBox.Show("Apakah anda yakin ingin menyimpan data?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
            Return False
        End If

        Return True
    End Function

    Private Sub FormApprovePembayaranTagihan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetClear()
        SetClearDetailCOA()
        SetGrid()
    End Sub

    Private Sub DisableDetailTagihan()
        TextBoxNamaPerusahaanInvoice.Enabled = False
        TextBoxNamaPerusahaanInvoice.Enabled = False
    End Sub

    Public Sub LoadDetailPelunasan(ByRef nomorInvoice As String)
        Dim tblRekap As DataTable = ReadThemysql("SELECT * FROM acctransrekaptagihan a WHERE a.notagihancompany = '" & nomorInvoice & "';", DB_Keuangan)

        If tblRekap.Rows.Count > 0 Then
            Dim rowHeader As DataRow = tblRekap.Rows(0)

            TextBoxNamaPerusahaanInvoice.Text = rowHeader("company").ToString()
            TextBoxNomorInvoice.Text = rowHeader("notagihancompany").ToString()
            TextBoxNominalInvoice.Value = Val(rowHeader("totaltagihan"))
            TglInvoice.Value = rowHeader("tgltagihan")
            TglJatuhTempoInvoice.Value = rowHeader("duedate")

            jenisTransaksi = rowHeader("JenisTransaksi").ToString()
            jenisPoli = rowHeader("JenisPoli").ToString()
            kodeLokasiKlinik = rowHeader("cabang").ToString()

            ' Set DB dan Metode Jurnal
            Dim tblLokasi As DataTable = ReadThemysql("SELECT * FROM masterlokasiklinik WHERE kode_klinik = '" & kodeLokasiKlinik & "';", DB_Poliklinik)
            Dim rowLokasi As DataRow = tblLokasi.Rows(0)

            jurnalDB = rowLokasi("db_jurnal").ToString()
            jurnalMethod = rowLokasi("jenis_jurnal").ToString()
        Else
            SetClear()
            SetClearDetailCOA()

            MsgBox("Gagal mendapatkan detail invoice.", MsgBoxStyle.Critical, "Warning!")
            Exit Sub
        End If
    End Sub

    Public Sub LoadCOAdetail(ByRef Trow As DataRowView)
        TextBoxDetailTambahanCoa.Text = Trow("coa").ToString
        TextBoxDetailTambahanKeterangan.Text = Trow("jenis").ToString
    End Sub

    Function CheckCOA() As Boolean
        If TextBoxDetailTambahanCoa.Text = "" Then
            MsgBox("Pilih COA yang akan ditambahkan")
            Return False
        End If

        If TextBoxDetailTambahanNominal.Value <= 0 Then
            MsgBox("Masukkan nilai tambahannya")
            Return False
        End If

        Return True
    End Function

    Private Sub butaddcoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If CheckCOA() = True Then
            DataGridViewDetailCOA.ReadOnly = False
            Dim Tbls As DataTable = DataGridViewDetailCOA.DataSource
            Dim Tnewrow As DataRow = Tbls.NewRow
            Tnewrow("coa") = TextBoxDetailTambahanCoa.Text
            Tnewrow("jenis") = TextBoxDetailTambahanKeterangan.Text
            Tnewrow("nilai") = TextBoxDetailTambahanNominal.Value
            Tbls.Rows.Add(Tnewrow)
            DataGridViewDetailCOA.DataSource = Tbls
            DataGridViewDetailCOA.ReadOnly = True
            SetClearDetailCOA()
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxSesuaiNominalTagihan.CheckedChanged
        If CheckBoxSesuaiNominalTagihan.Checked = True Then
            TextBoxTotalBayar.Value = TextBoxNominalInvoice.Value
        ElseIf CheckBoxSesuaiNominalTagihan.Checked = False Then
            TextBoxTotalBayar.Text = CDbl(0)
        End If
    End Sub

    Private Sub SendJurnal_BKM()
        Dim keteranganJurnal As String = ""
        Dim keteranganJurnalUMH As String = ""
        'Dim flag As String = ""
        'Dim KetLokasi As String = ""
        'Dim Nourut As String = ""
        'Dim bsa As String = ""
        'Dim JenisTransaksi As String = ""
        'Dim Tlokasigl As New DataTable
        'Dim Tloc As String = ""
        'Dim CoaPiutangPending As String = ""
        'Dim CoaPiutang As String = ""
        'Dim Tsplit() As String = TextBoxNamaPerusahaanInvoice.Text.Split("-")

        'Dim Tbls As DataTable = GridControl1.DataSource
        'Dim TrowInv As DataRow = Tbls.Rows(0)
        'JenisTransaksi = TrowInv("JenisTransaksi")
        'Tloc = TrowInv("Cabang")

        'Tlokasigl = ReadThemysql("SELECT a.locgl, a.locket FROM masterlokasigl a WHERE a.loc='" & Tloc & "' AND a.jenistransaksi='" & JenisTransaksi & "'", DB_Keuangan)
        'Dim Trowlokasigl As DataRow = Tlokasigl.Rows(0)
        'bsa = Trowlokasigl("locgl")
        'KetLokasi = Trowlokasigl("locket")

        ' Set Variabel COA Bank
        Dim CoaBank As String = TextBoxBankTransferCoa.Text.Trim

        ' Set Variabel Nama Perusahaan
        Dim splitPerusahaan() As String = TextBoxNamaPerusahaanInvoice.Text.Split("-")

        ' Set Tabel Data MasterLokasiJurnal
        Dim tblMasterJurnal As New DataTable

        ' Set Tabel tblMasterJurnal Untuk Set Jurnal & Lokasi
        If jurnalMethod = "JENIS POLI" Then
            tblMasterJurnal = ReadThemysql("SELECT a.KeteranganLokasi AS 'Lokasi', a.KeteranganPoli AS 'Keterangan', a.KodeLokasiJurnal, a.KodeCoaPiutang, a.KodeCoaPiutangPending FROM MasterLokasiJurnal a WHERE a.KodeLokasi = '" & kodeLokasiKlinik & "' AND a.KeteranganPoli = '" & jenisPoli & "' LIMIT 1;", DB_Omset)
        ElseIf jurnalMethod = "JENIS TRANSAKSI" Then
            tblMasterJurnal = ReadThemysql("SELECT a.KeteranganLokasi AS 'Lokasi', a.JenisTransaksi AS 'Keterangan', a.KodeLokasiJurnal, a.KodeCoaPiutang, a.KodeCoaPiutangPending FROM MasterLokasiJurnal a WHERE a.KodeLokasi = '" & kodeLokasiKlinik & "' AND a.JenisTransaksi = '" & jenisTransaksi & "' LIMIT 1;", DB_Omset)
        End If

        ' Set ID Lokasi Jurnal
        Dim rowDataJurnal As DataRow = tblMasterJurnal.Rows(0)
        Dim idLokasiJurnal As String = rowDataJurnal("KodeLokasiJurnal")
        Dim keteranganLokasiJurnal As String = rowDataJurnal("Lokasi") & " (" & rowDataJurnal("Keterangan") & ")"

        ' Set DB Berdasarkan Lokasi di GL
        DB_Jurnal.Tdb = jurnalDB

        ' Set Flag / Refference
        Dim refferenceID As String = GetUUID()

        ' Set Keterangan Jurnal
        keteranganJurnal = "TERIMA - PEMBAYARAN TAGIHAN " & splitPerusahaan(0).ToString.Trim.ToUpper() & " " & keteranganLokasiJurnal & " " & Format(TglInvoice.Value, "dd/MM/yyyy") & " (NO. INVOICE : " & TextBoxNomorInvoice.Text & ")"
        keteranganJurnalUMH = "TERIMA - TAGIHAN " & splitPerusahaan(0).ToString.Trim.ToUpper() & " " & keteranganLokasiJurnal & " " & Format(TglInvoice.Value, "dd/MM/yyyy") & " (NO. INVOICE : " & TextBoxNomorInvoice.Text & ")"

        'If JenisTransaksi = "POLI" Then
        '    CoaPiutang = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPiutangKlinik'", DB_Keuangan2)
        '    CoaPiutangPending = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPiutangPendingKlinik'", DB_Keuangan2)
        'ElseIf JenisTransaksi = "GIGI" Then
        '    CoaPiutang = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPiutangGigi'", DB_Keuangan2)
        '    CoaPiutangPending = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPiutangPendingGigi'", DB_Keuangan2)
        'ElseIf JenisTransaksi = "DLL" Then
        '    CoaPiutang = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPiutangAdmin'", DB_Keuangan2)
        '    CoaPiutangPending = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPiutangPendingAdmin'", DB_Keuangan2)
        'ElseIf JenisTransaksi = "LAB" Then
        '    CoaPiutang = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPiutangLab'", DB_Keuangan2)
        '    CoaPiutangPending = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPiutangPendingLab'", DB_Keuangan2)
        'End If

        ' Get Detail COA
        Dim CoaDetail As String = ""
        Dim CoaDetailNilai As Integer = 0
        Dim JurnalKAS As String = ""
        Dim CoaDetailKeterangan As String = ""
        Dim TblsCoa As DataTable = DataGridViewDetailCOA.DataSource
        TblsCoa.AcceptChanges()
        If TblsCoa.Rows.Count > 0 Then
            For Each TrowCoa As DataRow In TblsCoa.Rows
                CoaDetail = TrowCoa("coa")
                CoaDetailNilai = TrowCoa("nilai")
                CoaDetailKeterangan = TrowCoa("jenis")
            Next
        End If

        ' Sending Jurnal Omset
        If CheckThemysql("SELECT * FROM acctransrekaptagihan WHERE FlagJurnalCreateTagihan IS NULL AND notagihancompany = '" & TextBoxNomorInvoice.Text & "'", DB_Keuangan) = True Then
            WriteThemysql("SELECT F_MakeUMH('" & refferenceID & "', 'out', '', '" & Format(TglInvoice.Value, "yyyy-MM-dd") & "', '" & rowDataJurnal("KodeCoaPiutangPending").ToString() & "', '" & rowDataJurnal("KodeCoaPiutang").ToString() & "', 'IDR', 1, " & CDbl(TextBoxTotalBayar.Value) & ", '" & keteranganJurnalUMH & "', '1', 1, '', '" & keteranganJurnalUMH & "', '', '', '" & idLokasiJurnal & "', 4, " & CDbl(TextBoxTotalBayar.Value) & ", 'K')", DB_Jurnal)

            ' Flag Tabel acctransrekaptagihan field FlagJurnalCreateTagihan
            WriteThemysql("UPDATE acctransrekaptagihan a SET a.FlagJurnalCreateTagihan = '" & refferenceID & "' WHERE a.notagihancompany = '" & TextBoxNomorInvoice.Text & "'", DB_Keuangan)
        End If

        WriteThemysql("SELECT F_MakeBKM('" & refferenceID & "', 'out', '', '" & Format(TglTransferPembayaran.Value, "yyyy-MM-dd") & "', '" & CoaBank & "', '" & rowDataJurnal("KodeCoaPiutang").ToString() & "', 'IDR', 1, " & CDbl(TextBoxTotalBayar.Value) & ", '" & keteranganJurnal & "', '1', 1, '', '" & keteranganJurnal & "', '', '', '" & idLokasiJurnal & "', 4, " & CDbl(TextBoxTotalBayar.Value) & ", 'K')", DB_Jurnal)

        If TblsCoa.Rows.Count > 0 Then
            JurnalKAS = ReadThemysqlNIK("SELECT a.kas as a FROM kas a WHERE a.oms='" & refferenceID & "'", DB_Jurnal)
            WriteThemysql("SELECT F_MakeBKM('" & refferenceID & "', 'out', '" & JurnalKAS & "', '" & Format(TglTransferPembayaran.Value, "yyyy-MM-dd") & "', '" & rowDataJurnal("KodeCoaPiutang").ToString() & "', '" & CoaDetail & "', 'IDR', 1, " & CDbl(CoaDetailNilai) & ", '" & CoaDetailKeterangan.ToUpper() & "', '1', 2, '', '" & CoaDetailKeterangan.ToUpper() & "', '', '', '" & idLokasiJurnal & "', 4, " & CDbl(CoaDetailNilai) & ", 'D')", DB_Jurnal)
        End If

        ' Flag Tabel acctransrekaptagihan field FlagJurnalPembayaran
        WriteThemysql("UPDATE acctransrekaptagihan a SET a.FlagJurnalPembayaran = '" & refferenceID & "' WHERE a.notagihancompany = '" & TextBoxNomorInvoice.Text & "'", DB_Keuangan)

        ' Save Log Jurnal
        WriteThemysql("INSERT INTO logjurnalkeuangan (JurnalFlag, JurnalDate, JurnalBy, Status, JenisTransaksi, Cabang) VALUES ('" & refferenceID & "', NOW(), '" & userInput & "', '" & keteranganJurnal & "', '" & jenisTransaksi & "', '" & kodeLokasiKlinik & "')", DB_Keuangan)
    End Sub

    Private Sub ButtonFindBankTagihan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFindBankTagihan.Click
        Find.Show()
        Find.QueryTheMysql("SELECT a.NamaBank, a.NomorRekening, a.NamaRekening, a.CabangRekening, a.CoaBank FROM MasterBankTransfer a WHERE a.StatusAktif = 1 AND a.TransferTagihan = 1", " ", "FindBankTagihanFormVerifikasiOmsetTagihan", 0, Find_Omset)
    End Sub

    Private Sub ButtonFindInvoiceTagihan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFindInvoiceTagihan.Click
        Find.Show()
        Find.QueryTheMysql("SELECT a.company AS 'Perusahaan', a.notagihancompany AS 'No Tagihan', DATE(a.tgltagihan) AS 'Tgl Invoice', DATE(a.duedate) AS 'Tgl Jatuh Tempo', CONCAT('Rp ', FORMAT(a.totaltagihan, 0)) AS 'Total Tagihan' FROM acctransrekaptagihan a WHERE a.deleted IS NULL AND a.lunasid = 0 AND a.cabang IS NOT NULL", " ORDER BY a.TglTagihan ASC", "FindInvoiceTagihanFormVerifikasiOmsetTagihan", 0, Find_Keuangan)
    End Sub

    Private Sub ButtonFindCoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFindCoa.Click
        Find.Show()
        Find.QueryTheMysql("SELECT a.acc AS 'coa', a.name AS 'jenis', '-' AS 'keterangan' FROM acc a ", " ORDER BY a.acc ", "FindCOAadd", 0, Find_Jurnal)
    End Sub

    Private Sub ButtonSimpanDetailCoa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSimpanDetailCoa.Click
        If CheckCOA() = True Then
            DataGridViewDetailCOA.ReadOnly = False
            Dim Tbls As DataTable = DataGridViewDetailCOA.DataSource
            Dim Tnewrow As DataRow = Tbls.NewRow
            Tnewrow("coa") = TextBoxDetailTambahanCoa.Text
            Tnewrow("jenis") = TextBoxDetailTambahanKeterangan.Text
            Tnewrow("nilai") = TextBoxDetailTambahanNominal.Value
            Tbls.Rows.Add(Tnewrow)
            DataGridViewDetailCOA.DataSource = Tbls
            DataGridViewDetailCOA.ReadOnly = True
            SetClearDetailCOA()
        End If
    End Sub

    Private Sub ButtonClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClear.Click
        SetClear()
        SetClearDetailCOA()
    End Sub

    Private Sub ButtonSimpanDetailPembayaran_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSimpanDetailPembayaran.Click
        If ValidasiPembayaran() = True Then
            ' Set Variabel Nama Perusahaan
            Dim splitPerusahaan() As String = TextBoxNamaPerusahaanInvoice.Text.Split("-")

            ' Insert Tabel acctranspelunasantagihan
            WriteThemysql("INSERT INTO acctranspelunasantagihan(coa, kartu, mesin, lunastgl, lunasnilai, bankid, loc, keterangan, closed, createdate, createby) " & _
                          "VALUES('" & TextBoxBankTransferCoa.Text & "', '" & splitPerusahaan(0).ToString & "','" & splitPerusahaan(1).ToString & "','" & Format(TglTransferPembayaran.Value, "yyyyMMdd") & "'," & CDbl(TextBoxTotalBayar.Text) & ",'0','','" & TextBoxKeteranganPembayaran.Text & "', 0, NOW(), '" & userInput & "')", DB_Keuangan)

            ' Get Flag Pelunasan
            Dim flagPelunasan As String = ReadThemysqlNIK("SELECT MAX(lunasid) FROM acctranspelunasantagihan WHERE coa = '" & TextBoxBankTransferCoa.Text & "' AND kartu = '" & splitPerusahaan(0).ToString & "' AND mesin = '" & splitPerusahaan(1).ToString & "' AND lunastgl = '" & Format(TglTransferPembayaran.Value, "yyyyMMdd") & "' AND lunasnilai = '" & CDbl(TextBoxTotalBayar.Text) & "'", DB_Keuangan)

            ' Set Flag Pelunasan di Tabel acctransrekaptagihan
            WriteThemysql("UPDATE acctransrekaptagihan SET lunasid = '" & flagPelunasan & "' WHERE notagihancompany = '" & TextBoxNomorInvoice.Text & "'", DB_Keuangan)

            ' Insert Tabel acctranspelunasantagihandetail
            Dim tblDetailCOA As DataTable = DataGridViewDetailCOA.DataSource
            tblDetailCOA.AcceptChanges()
            For Each rowDetail As DataRow In tblDetailCOA.Rows
                WriteThemysql("INSERT INTO acctranspelunasantagihandetail (lunasid, coaid, coadetail, nilai, createdate, createby) " & _
                              "VALUES(" & flagPelunasan & ", '" & rowDetail("coa") & "', '" & rowDetail("jenis") & "', " & rowDetail("nilai") & ", NOW(), '" & userInput & "')", DB_Keuangan)
            Next

            ' Sending Jurnal
            SendJurnal_BKM()

            MsgBox("Berhasil menyimpan data pembayaran.", MsgBoxStyle.Information, "Success!")

            If MsgBox("Lanjut input penerimaan lainnya ?", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                SetClear()
                SetClearDetailCOA()
                FormAwalPembayaranTagihan.LoadData()
            Else
                Me.Close()
            End If
        End If
    End Sub
End Class