Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports System.Drawing
Imports System.Math
Imports System.Text

Public Class FormVerifikasiOmsetTunai
    Dim thread As System.Threading.Thread
    Private UserAdmin As String = PoliKlinik.Lbluser.Text
    Private locationCode As String = ""
    Private jurnalDB As String = ""
    Private jurnalMethod As String = ""

    ' Set Connection
    Private Find_Poliklinik As Find.TLconnect
    Private Find_Keuangan As Find.TLconnect
    Private Find_Omset As Find.TLconnect
    Private DB_Keuangan As TLcon
    Private DB_Keuangan2 As TLcon
    Private DB_Omset As TLcon
    Private DB_Jurnal As TLcon

    Private Sub SetConnectionFromConfig()
        ' Set Parameter Server Online
        Dim serverOnline_IP As String = Utility.GetConfig("ServerOnline_IP")
        Dim serverOnline_UserID As String = Utility.GetConfig("ServerOnline_UserID")
        Dim serverOnline_Password As String = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerOnline_Password"), "albert")

        ' Set Find Poliklinik
        Find_Poliklinik.Tip = serverOnline_IP
        Find_Poliklinik.Tid = serverOnline_UserID
        Find_Poliklinik.Tpass = serverOnline_Password
        Find_Poliklinik.Tdb = Utility.GetConfig("ServerOnlinePoli_DB")

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

        ' Set DB Keuangan 2 (mitramed_keu2019)
        DB_Keuangan2.Tip = serverOnline_IP
        DB_Keuangan2.Tid = serverOnline_UserID
        DB_Keuangan2.Tpass = serverOnline_Password
        DB_Keuangan2.Tdb = Utility.GetConfig("ServerOnlineKeuangan2_DB")

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
    End Sub

    Public Sub LoadFormApprovePembayaranTunai(ByRef kodeKlinik As String, ByRef namaKlinik As String, ByRef namaDatabase As String, ByRef metodeJurnal As String)
        TextBoxKeteranganLokasi.Text = namaKlinik

        locationCode = kodeKlinik
        jurnalDB = namaDatabase
        jurnalMethod = metodeJurnal
    End Sub

    Private Sub SetClear()
        DataGridViewDaftarTransaksi.Rows.Clear()
        DateTimeTglTransaksi.Value = DateAndTime.Now
        DateTimeTglTransfer.Value = DateAndTime.Now
        ComboBoxJenisTransaksi.SelectedIndex = 0
        ComboBoxJenisPembayaran.SelectedIndex = 0
        ComboBoxBankEDC.SelectedIndex = 0
        LabelTotalOmset.ResetText()
        locationCode = ""
        jurnalDB = ""
        jurnalMethod = ""
        TextBoxKeteranganLokasi.ResetText()
        disablebutton()
        CheckBox1.CheckState = CheckState.Unchecked

        TextBoxCoaBank.ResetText()
        TextBoxNamaBank.ResetText()

        LabelTotalOmset.Text = "Rp. 0"
        LabelTotalOmsetClosing.Text = "Rp. 0"
        LabelTotalOmsetCentang.Text = "Rp. 0"
        LabelTotalBiayaAdmin.Text = "Rp. 0"

        ProgressBarUpload.Value = 0
    End Sub

    Function CreateTable() As DataTable
        Dim Thasil As New DataTable

        insertRowToTbls(Thasil, "Typstring", "NoTransaksi") 'inctransid
        insertRowToTbls(Thasil, "tyinterger", "ID") 'incdetailid
        insertRowToTbls(Thasil, "Typstring", "Lokasi") 'loc 
        insertRowToTbls(Thasil, "Typstring", "Ket. Lokasi")
        insertRowToTbls(Thasil, "Typstring", "Jenis") 'incjenis
        insertRowToTbls(Thasil, "Typstring", "IDPasien") '
        insertRowToTbls(Thasil, "Typstring", "Pasien")
        insertRowToTbls(Thasil, "Typstring", "JenisBayar")
        insertRowToTbls(Thasil, "Typstring", "Kartu")
        insertRowToTbls(Thasil, "Typstring", "Mesin")
        insertRowToTbls(Thasil, "Typstring", "NilaiUang")
        insertRowToTbls(Thasil, "Typstring", "Biaya Admin")
        insertRowToTbls(Thasil, "Typstring", "TglClosed")
        insertRowToTbls(Thasil, "typchecked", "Closed")
        insertRowToTbls(Thasil, "Typstring", "Tgl Transaksi")
        insertRowToTbls(Thasil, "Typstring", "Status")
        insertRowToTbls(Thasil, "typchecked", "Pilihan")

        For Each Tcol As DataColumn In Thasil.Columns
            Tcol.ReadOnly = True
        Next

        Thasil.Columns("Pilihan").ReadOnly = False
        Thasil.Columns("Closed").ReadOnly = False

        Return Thasil
    End Function

    Private Sub SendJurnal_TunaiUMH()
        Dim procent As Integer = 0
        Dim persen As Integer = 0
        Dim total As Integer = 0
        Dim totalUMH As Integer = 0
        Dim trfid As Integer = 0
        Dim keterangan As String = ""
        Dim KetLokasi As String = ""
        Dim JurnalUMH As String = ""
        Dim CoaMesin As String = ""
        Dim CoaJenisBayar As String = ""
        Dim CoaTunai As String = ""
        Dim Tquery As String = ""
        Dim Tjenispembayaran As String = ""
        Dim Tjenistransaksi As String = ""
        Dim Tlokasi As String = ""
        Dim Torder As String = ""
        Dim Tgroup As String = ""
        Dim konversi As Double = 0
        Dim bsa As String = ""

        ' Set database jurnal
        DB_Jurnal.Tdb = jurnalDB

        'Jenis Pembayaran
        Tjenispembayaran = " AND a.incjenis IN ('DLL','GIGI','LAB','POLI')"

        'Jenis Transaksi
        Tjenistransaksi = " AND a.jenis IN ('Tunai','Debet','Kredit')"

        'Lokasi
        If locationCode = "" Then
            Tlokasi = " "
        Else
            Tlokasi = " AND a.loc='" & locationCode & "'"
        End If

        'Penggunaan group by
        Tgroup = " GROUP BY a.loc, a.incjenis, a.jenis, a.mesin, a.inctgl "

        'Penggunaan order by
        Torder = " ORDER BY a.loc, a.incjenis, a.jenis, a.mesin, a.inctgl DESC"

        'Query Dasar
        Tquery = "SELECT a.kartu, a.mesin, a.loc, a.incjenis, a.jenis, a.inctgl, a.incnilai AS sumnilai, CASE WHEN a.flagby = '' THEN '-' ELSE 'SEND' END AS 'flag' FROM acctranspendapatandetail a WHERE a.flag IS NULL AND date(a.inctgl)= '" & Format(DateTimeTglTransaksi.Value, "yyyyMMdd") & "'"
        Dim TblsGL As DataTable = ReadThemysql(Tquery + Tlokasi + Tjenispembayaran + Tjenistransaksi + Tgroup + Torder, DB_Keuangan)
        If TblsGL.Rows.Count > 0 Then
            For Each Trow As DataRow In TblsGL.Rows
                persen = persen + 1
                procent = persen * 100 / TblsGL.Rows.Count
                ProgressBarUpload.Value = procent

                Dim SumNilai As Double = 0
                Dim TempData As DataTable = ReadThemysql("" & Tquery & Tlokasi & " AND a.incjenis = '" & Trow("incjenis") & "' AND a.jenis = '" & Trow("jenis") & "' AND a.mesin='" & Trow("mesin") & "'" & Torder & "", DB_Keuangan)
                For Each TrowData As DataRow In TempData.Rows
                    SumNilai = SumNilai + TrowData("sumnilai")
                Next

                Dim Tlokasigl As DataTable = ReadThemysql("SELECT a.locgl, a.locket FROM masterlokasigl a WHERE a.loc='" & locationCode & "' AND a.jenistransaksi='" & Trow("incjenis") & "'", DB_Keuangan)
                Dim Trowlokasigl As DataRow = Tlokasigl.Rows(0)
                bsa = Trowlokasigl("locgl")
                KetLokasi = Trowlokasigl("locket")

                ' Set Flag / Refference
                Dim refferenceID As String = GetUUID()

                Dim KetBank As String = ""
                If Trow("mesin").ToString.Trim <> "" Then
                    KetBank = " " & Trow("mesin").ToString.Trim & " "
                Else
                    KetBank = " "
                End If

                keterangan = "TERIMA - OMZET " & Trow("jenis") & KetBank & KetLokasi & " " & DateTime.ParseExact(Trow("inctgl"), "M/d/yyyy", Nothing).ToString("dd/MM/yyyy") & ""

                'Select COA Pendapatan & Jenis Tunai
                If Trow("incjenis") = "DLL" Then
                    CoaJenisBayar = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPendapatanAdmin'", DB_Keuangan2)
                    CoaTunai = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaTunaiAdmin'", DB_Keuangan2)
                ElseIf Trow("incjenis") = "GIGI" Then
                    CoaJenisBayar = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPendapatanGigi'", DB_Keuangan2)
                    CoaTunai = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaTunaiGigi'", DB_Keuangan2)
                ElseIf Trow("incjenis") = "LAB" Then
                    CoaJenisBayar = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPendapatanLab'", DB_Keuangan2)
                    CoaTunai = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaTunaiLab'", DB_Keuangan2)
                ElseIf Trow("incjenis") = "POLI" Then
                    CoaJenisBayar = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPendapatanKlinik'", DB_Keuangan2)
                    CoaTunai = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaTunaiKlinik'", DB_Keuangan2)
                End If

                'Select Mesin EDC
                If Trow("mesin") = "BCA" Then
                    CoaMesin = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPiutangBCA'", DB_Keuangan2)
                ElseIf Trow("mesin") = "MANDIRI" Then
                    CoaMesin = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPiutangMANDIRI'", DB_Keuangan2)
                ElseIf Trow("mesin") = "CIMB" Then
                    CoaMesin = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPiutangCIMB'", DB_Keuangan2)
                ElseIf Trow("mesin") = "QRIS" Then
                    CoaMesin = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPiutangQRIS'", DB_Keuangan2)
                End If

                'Sending Jurnal
                If Trow("jenis") = "TUNAI" Then
                    WriteThemysql("SELECT F_MakeUMH('" & refferenceID & "', 'out', '', '" & DateTime.ParseExact(Trow("inctgl"), "M/d/yyyy", Nothing).ToString("yyyy-MM-dd") & "', '" & CoaJenisBayar & "', '" & CoaTunai & "', 'IDR', 1, " & CDbl(SumNilai) & ", '" & keterangan.ToUpper() & "', '1', 1, '', '" & keterangan.ToUpper() & "', '', '', '" & bsa & "', 4, " & CDbl(SumNilai) & ", 'K')", DB_Jurnal)
                ElseIf Trow("jenis") = "DEBET" Or Trow("jenis") = "KREDIT" Then
                    WriteThemysql("SELECT F_MakeUMH('" & refferenceID & "', 'out', '', '" & DateTime.ParseExact(Trow("inctgl"), "M/d/yyyy", Nothing).ToString("yyyy-MM-dd") & "', '" & CoaJenisBayar & "', '" & CoaMesin & "', 'IDR', 1, " & CDbl(SumNilai) & ", '" & keterangan.ToUpper() & "', '1', 1, '', '" & keterangan.ToUpper() & "', '', '', '" & bsa & "', 4, " & CDbl(SumNilai) & ", 'K')", DB_Jurnal)
                End If

                WriteThemysql("UPDATE acctranspendapatandetail a SET flagdate=now(), flagby='" & UserAdmin & "', a.flag='" & refferenceID & "' WHERE a.flag IS NULL AND DATE(a.inctgl)= '" & Format(DateTimeTglTransaksi.Value, "yyyyMMdd") & "' AND a.loc='" & locationCode & "' AND a.incjenis = '" & Trow("incjenis") & "' AND a.jenis = '" & Trow("jenis") & "' AND a.mesin='" & Trow("mesin") & "'", DB_Keuangan)
            Next

            MsgBox("Jurnal & Data Saved.", MsgBoxStyle.Information, "Success!")
        End If
    End Sub

    Private Sub SendJurnal_BKM()
        ' Set Variabel Query
        Dim stringQueryGroupBy As String = ""
        Dim stringQueryOrderBy As String = ""

        Dim transaksiProgres As Integer = 0
        Dim persentaseProgres As Integer = 0

        Dim coaMesinEDC As String = ""
        Dim coaBiayaAdminEDC As String = ""

        Dim keteranganJurnal As String = ""
        Dim keteranganJurnalBiayaAdmin As String = ""

        ' Set database jurnal
        DB_Jurnal.Tdb = jurnalDB

        ' Group By & Order By
        If jurnalMethod = "JENIS POLI" Then
            stringQueryGroupBy = " GROUP BY a.loc, a.jenis_poli, a.jenis, b.tgltransaksi, b.tgltransfer, b.bankcoa, a.mesin "
            stringQueryOrderBy = " ORDER BY a.loc, a.jenis_poli, a.jenis, b.tgltransaksi, b.tgltransfer, b.bankcoa, a.mesin DESC"
        ElseIf jurnalMethod = "JENIS TRANSAKSI" Then
            stringQueryGroupBy = " GROUP BY a.loc, a.incjenis, a.jenis, b.tgltransaksi, b.tgltransfer, b.bankcoa, a.mesin "
            stringQueryOrderBy = " ORDER BY a.loc, a.incjenis, a.jenis, b.tgltransaksi, b.tgltransfer, b.bankcoa, a.mesin DESC"
        End If

        Dim stringQuery As New StringBuilder()
        stringQuery.AppendLine("SELECT a.transferid, a.flag AS 'flag_gl', a.kartu, a.mesin, a.loc, ")
        If jurnalMethod = "JENIS POLI" Then
            stringQuery.AppendLine("       a.jenis_poli, ")
        ElseIf jurnalMethod = "JENIS TRANSAKSI" Then
            stringQuery.AppendLine("       a.incjenis, ")
        End If
        stringQuery.AppendLine("       a.jenis, b.tgltransfer, b.tgltransaksi, b.bankcoa, a.incnilai AS sumnilai, ")
        stringQuery.AppendLine("       CASE WHEN a.flagby = '' THEN '-' ELSE 'SEND' END AS 'flag' ")
        stringQuery.AppendLine("FROM acctranspendapatandetail a ")
        stringQuery.AppendLine("     LEFT JOIN acctranspendapatantransfer b ON a.transferid = b.transferid ")
        stringQuery.AppendLine("WHERE a.flag IS NOT NULL ")
        stringQuery.AppendLine("AND a.flag2 IS NULL ")
        stringQuery.AppendLine("AND a.transferid IS NOT NULL ")
        stringQuery.AppendLine("AND a.loc = '" & locationCode & "' ")
        stringQuery.AppendLine("AND DATE(b.tgltransaksi) = '" & Format(DateTimeTglTransaksi.Value, "yyyyMMdd") & "'")

        Dim tblTransaksi As DataTable = ReadThemysql(stringQuery.ToString() + stringQueryGroupBy + stringQueryOrderBy, DB_Keuangan)

        If tblTransaksi.Rows.Count > 0 Then
            For Each rowHeaderOmset As DataRow In tblTransaksi.Rows
                ' Set Tabel Data MasterLokasiJurnal
                Dim tblMasterJurnal As New DataTable

                ' Cek Jumlah Proses & Update ProgressBar
                transaksiProgres += 1
                persentaseProgres = transaksiProgres * 100 / tblTransaksi.Rows.Count
                ProgressBarUpload.Value = persentaseProgres

                Dim SumNilai As Double = 0
                Dim SumAdmin As Double = 0
                Dim BiayaAdmin As Double = 0
                Dim bankTujuan As String = ""
                Dim bankSumber As String = ""

                ' Set Tabel MasterKonversiAdminBankEDC
                Dim tblKonversiAdminBank As DataTable = New DataTable

                ' Set Tabel Data MasterLokasiJurnal
                Dim tblDetailOmset As New DataTable

                If jurnalMethod = "JENIS POLI" Then
                    tblDetailOmset = ReadThemysql("" & stringQuery.ToString() & " AND b.bankcoa = '" & rowHeaderOmset("bankcoa") & "' AND a.jenis_poli = '" & rowHeaderOmset("jenis_poli") & "' AND a.jenis = '" & rowHeaderOmset("jenis") & "' AND a.mesin = '" & rowHeaderOmset("mesin") & "' AND date(b.tgltransfer) = '" & Format(rowHeaderOmset("tgltransfer"), "yyyy-MM-dd") & "' " & stringQueryOrderBy & "", DB_Keuangan)
                ElseIf jurnalMethod = "JENIS TRANSAKSI" Then
                    tblDetailOmset = ReadThemysql("" & stringQuery.ToString() & " AND b.bankcoa = '" & rowHeaderOmset("bankcoa") & "' AND a.incjenis = '" & rowHeaderOmset("incjenis") & "' AND a.jenis = '" & rowHeaderOmset("jenis") & "' AND a.mesin = '" & rowHeaderOmset("mesin") & "' AND date(b.tgltransfer) = '" & Format(rowHeaderOmset("tgltransfer"), "yyyy-MM-dd") & "' " & stringQueryOrderBy & "", DB_Keuangan)
                End If

                For Each rowDetailOmset As DataRow In tblDetailOmset.Rows
                    SumNilai = SumNilai + rowDetailOmset("sumnilai")
                    If rowDetailOmset("jenis") = "Debet" Or rowDetailOmset("jenis") = "Kredit" Then
                        If rowDetailOmset("mesin") <> "" Then
                            ' Set Bank Tujuan (Bank EDC)
                            bankTujuan = rowDetailOmset("mesin")
                            If bankTujuan.Contains("QRIS MANDIRI") = True Then
                                bankTujuan = "QRIS MANDIRI"
                            ElseIf bankTujuan.Contains("QRIS BTN") = True Then
                                bankTujuan = "QRIS BTN"
                            ElseIf bankTujuan.Contains("QRIS") = True Then
                                bankTujuan = "QRIS"
                            ElseIf bankTujuan.Contains("BCA") = True Then
                                bankTujuan = "BCA"
                            ElseIf bankTujuan.Contains("MANDIRI") = True Then
                                bankTujuan = "MANDIRI"
                            ElseIf bankTujuan.Contains("CIMB") = True Or bankTujuan.Contains("NIAGA") = True Then
                                bankTujuan = "CIMB"
                            Else
                                bankTujuan = "DLL"
                            End If

                            ' Set Bank Sumber (Bank Pasien)
                            If rowDetailOmset("kartu").Contains("" & bankTujuan & "") = True Then
                                bankSumber = bankTujuan
                            ElseIf rowDetailOmset("kartu").Contains("QRIS") = True Then
                                bankSumber = "QRIS"
                            Else
                                bankSumber = "DLL"
                            End If

                            tblKonversiAdminBank = ReadThemysql("SELECT BiayaAdmin, Pembulatan FROM MasterKonversiAdminBankEDC WHERE JenisTransaksi = '" & rowHeaderOmset("jenis") & "' AND BankTujuan = '" & bankTujuan & "' AND BankSumber = '" & bankSumber & "';", DB_Omset)
                            Dim rowBiayaAdmin As DataRow = tblKonversiAdminBank.Rows(0)

                            ' Set Biaya Admin Bank
                            BiayaAdmin = (rowBiayaAdmin("BiayaAdmin") * rowDetailOmset("sumnilai")) / 100

                            ' Kalkulasi Biaya Admin Bank
                            If rowBiayaAdmin("Pembulatan") = 1 Then
                                SumAdmin = SumAdmin + Math.Round(BiayaAdmin, 0, MidpointRounding.AwayFromZero)
                            Else
                                SumAdmin = SumAdmin + BiayaAdmin
                            End If
                        End If
                    End If
                Next

                ' Set Tabel tblMasterJurnal Untuk Set Jurnal & Lokasi
                If jurnalMethod = "JENIS POLI" Then
                    tblMasterJurnal = ReadThemysql("SELECT a.KeteranganLokasi AS 'Lokasi', a.KeteranganPoli AS 'Keterangan', a.KodeLokasiJurnal, a.KodeCoaPendapatan, a.KodeCoaPiutangPending, a.KodeCoaPendapatanTunai FROM MasterLokasiJurnal a WHERE a.KodeLokasi = '" & locationCode & "' AND a.KeteranganPoli = '" & rowHeaderOmset("jenis_poli") & "' LIMIT 1;", DB_Omset)
                ElseIf jurnalMethod = "JENIS TRANSAKSI" Then
                    tblMasterJurnal = ReadThemysql("SELECT a.KeteranganLokasi AS 'Lokasi', a.JenisTransaksi AS 'Keterangan', a.KodeLokasiJurnal, a.KodeCoaPendapatan, a.KodeCoaPiutangPending, a.KodeCoaPendapatanTunai FROM MasterLokasiJurnal a WHERE a.KodeLokasi = '" & locationCode & "' AND a.JenisTransaksi = '" & rowHeaderOmset("incjenis") & "' LIMIT 1;", DB_Omset)
                End If

                ' Set ID Lokasi Jurnal
                Dim rowDataJurnal As DataRow = tblMasterJurnal.Rows(0)
                Dim idLokasiJurnal As String = rowDataJurnal("KodeLokasiJurnal")
                Dim keteranganLokasiJurnal As String = rowDataJurnal("Lokasi") & " (" & rowDataJurnal("Keterangan") & ")"

                ' Set Flag / Refference
                Dim refferenceID As String = GetUUID()

                ' Set Keterangan Bank
                Dim keteranganBank As String = " "
                If rowHeaderOmset("mesin").ToString.Trim <> "" Then keteranganBank = " " & rowHeaderOmset("mesin").ToString.Trim & " "

                ' Set Keterangan Jurnal
                keteranganJurnal = "TERIMA - OMZET " & rowHeaderOmset("jenis") & keteranganBank & keteranganLokasiJurnal & " " & DateTime.ParseExact(rowHeaderOmset("tgltransaksi"), "M/d/yyyy", Nothing).ToString("dd/MM/yyyy") & ""
                keteranganJurnalBiayaAdmin = "BIAYA ADMIN " & rowHeaderOmset("jenis") & " (" & bankTujuan & ") " & keteranganLokasiJurnal & " " & DateTime.ParseExact(rowHeaderOmset("tgltransaksi"), "M/d/yyyy", Nothing).ToString("dd/MM/yyyy") & ""

                ' Set Mesin EDC & COA Biaya Admin
                If rowHeaderOmset("mesin").Contains("QRIS") = True Then
                    coaMesinEDC = ReadThemysqlNIK("SELECT a.KodeAkun FROM MasterCoaJurnal a WHERE a.NamaAkun = 'Piutang QRIS'", DB_Omset)
                    coaBiayaAdminEDC = ReadThemysqlNIK("SELECT a.KodeAkun FROM MasterCoaJurnal a WHERE a.NamaAkun = 'Biaya Admin QRIS'", DB_Omset)
                ElseIf rowHeaderOmset("mesin").Contains("BCA") = True Then
                    coaMesinEDC = ReadThemysqlNIK("SELECT a.KodeAkun FROM MasterCoaJurnal a WHERE a.NamaAkun = 'Piutang BCA'", DB_Omset)
                    coaBiayaAdminEDC = ReadThemysqlNIK("SELECT a.KodeAkun FROM MasterCoaJurnal a WHERE a.NamaAkun = 'Biaya Admin BCA'", DB_Omset)
                ElseIf rowHeaderOmset("mesin").Contains("MANDIRI") = True Then
                    coaMesinEDC = ReadThemysqlNIK("SELECT a.KodeAkun FROM MasterCoaJurnal a WHERE a.NamaAkun = 'Piutang MANDIRI'", DB_Omset)
                    coaBiayaAdminEDC = ReadThemysqlNIK("SELECT a.KodeAkun FROM MasterCoaJurnal a WHERE a.NamaAkun = 'Biaya Admin MANDIRI'", DB_Omset)
                ElseIf rowHeaderOmset("mesin").Contains("CIMB") = True Then
                    coaMesinEDC = ReadThemysqlNIK("SELECT a.KodeAkun FROM MasterCoaJurnal a WHERE a.NamaAkun = 'Piutang CIMB'", DB_Omset)
                    coaBiayaAdminEDC = ReadThemysqlNIK("SELECT a.KodeAkun FROM MasterCoaJurnal a WHERE a.NamaAkun = 'Biaya Admin CIMB'", DB_Omset)
                End If

                ' Sending Jurnal Omset
                If rowHeaderOmset("jenis") = "TUNAI" Then
                    WriteThemysql("SELECT F_MakeBKM('" & refferenceID & "', 'out', '', '" & DateTime.ParseExact(rowHeaderOmset("tgltransfer"), "M/d/yyyy", Nothing).ToString("yyyy-MM-dd") & "', '" & rowHeaderOmset("bankcoa") & "', '" & rowDataJurnal("KodeCoaPendapatanTunai").ToString() & "', 'IDR', 1, " & CDbl(SumNilai) & ", '" & keteranganJurnal.ToUpper() & "', '1', 1, '', '" & keteranganJurnal.ToUpper() & "', '', '', '" & idLokasiJurnal & "', 4, " & CDbl(SumNilai) & ", 'K')", DB_Jurnal)
                ElseIf rowHeaderOmset("jenis") = "DEBET" Or rowHeaderOmset("jenis") = "KREDIT" Then
                    WriteThemysql("SELECT F_MakeBKM('" & refferenceID & "', 'out', '', '" & DateTime.ParseExact(rowHeaderOmset("tgltransfer"), "M/d/yyyy", Nothing).ToString("yyyy-MM-dd") & "', '" & rowHeaderOmset("bankcoa") & "', '" & coaMesinEDC & "', 'IDR', 1, " & CDbl(SumNilai) & ", '" & keteranganJurnal.ToUpper() & "', '1', 1, '', '" & keteranganJurnal.ToUpper() & "', '', '', '" & idLokasiJurnal & "', 4, " & CDbl(SumNilai) & ", 'K')", DB_Jurnal)
                    Dim nomorJurnalBKM As String = ReadThemysqlNIK("SELECT kas FROM kas WHERE oms = '" & refferenceID & "'", DB_Jurnal)
                    WriteThemysql("SELECT F_MakeBKM('" & refferenceID & "', 'out', '" & nomorJurnalBKM & "', '" & DateTime.ParseExact(rowHeaderOmset("tgltransfer"), "M/d/yyyy", Nothing).ToString("yyyy-MM-dd") & "', '" & coaMesinEDC & "', '" & coaBiayaAdminEDC & "', 'IDR', 1, " & CDbl(SumAdmin) & ", '" & keteranganJurnalBiayaAdmin.ToUpper() & "', '1', 2, '', '" & keteranganJurnalBiayaAdmin.ToUpper() & "', '', '', '" & idLokasiJurnal & "', 4, " & CDbl(SumAdmin) & ", 'D')", DB_Jurnal)
                End If

                ' Update Flag Jurnal Omset
                If jurnalMethod = "JENIS POLI" Then
                    WriteThemysql("UPDATE acctranspendapatandetail a SET a.flag2='" & refferenceID & "' WHERE a.transferid IN (SELECT b.transferid from acctranspendapatantransfer b WHERE date(b.tgltransfer) = '" & DateTime.ParseExact(rowHeaderOmset("tgltransfer"), "M/d/yyyy", Nothing).ToString("yyyy-MM-dd") & "' AND date(b.tgltransaksi)= '" & DateTime.ParseExact(rowHeaderOmset("tgltransaksi"), "M/d/yyyy", Nothing).ToString("yyyy-MM-dd") & "') AND a.transferid IS NOT NULL AND a.loc='" & locationCode & "' AND a.jenis_poli = '" & rowHeaderOmset("jenis_poli") & "' AND a.jenis = '" & rowHeaderOmset("Jenis") & "' AND a.mesin = '" & rowHeaderOmset("mesin") & "' AND a.transferid = '" & rowHeaderOmset("transferid") & "';", DB_Keuangan)
                ElseIf jurnalMethod = "JENIS TRANSAKSI" Then
                    WriteThemysql("UPDATE acctranspendapatandetail a SET a.flag2='" & refferenceID & "' WHERE a.transferid IN (SELECT b.transferid from acctranspendapatantransfer b WHERE date(b.tgltransfer) = '" & DateTime.ParseExact(rowHeaderOmset("tgltransfer"), "M/d/yyyy", Nothing).ToString("yyyy-MM-dd") & "' AND date(b.tgltransaksi)= '" & DateTime.ParseExact(rowHeaderOmset("tgltransaksi"), "M/d/yyyy", Nothing).ToString("yyyy-MM-dd") & "') AND a.transferid IS NOT NULL AND a.loc='" & locationCode & "' AND a.incjenis = '" & rowHeaderOmset("incjenis") & "' AND a.jenis = '" & rowHeaderOmset("Jenis") & "' AND a.mesin = '" & rowHeaderOmset("mesin") & "' AND a.transferid = '" & rowHeaderOmset("transferid") & "';", DB_Keuangan)
                End If
            Next

            MsgBox("Jurnal & Data Saved.", MsgBoxStyle.Information, "Success!")
        End If
    End Sub

    Private Sub SendJurnal_UMH()
        Dim procent As Integer = 0
        Dim persen As Integer = 0
        Dim total As Integer = 0
        Dim totalUMH As Integer = 0
        Dim trfid As Integer = 0
        Dim keterangan As String = ""
        Dim flag As String = ""
        Dim KetLokasi As String = ""
        Dim Nourut As String = ""
        Dim JurnalUMH As String = ""
        Dim CoaMesin As String = ""
        Dim CoaJenisBayar As String = ""
        Dim CoaTunai As String = ""
        Dim Tquery As String = ""
        Dim Tjenispembayaran As String = ""
        Dim Tjenistransaksi As String = ""
        Dim Tlokasi As String = ""
        Dim Torder As String = ""
        Dim Tgroup As String = ""
        Dim konversi As Double = 0
        Dim bsa As String = ""

        'Send To GL
        'If txkeyflag.Text = 1 Then
        ' Set database jurnal
        DB_Jurnal.Tdb = jurnalDB

        'Jenis Pembayaran
        Tjenispembayaran = " AND a.incjenis IN ('DLL','GIGI','LAB','POLI')"

        'Jenis Transaksi
        Tjenistransaksi = " AND a.jenis IN ('Tunai','Debet','Kredit')"

        'Lokasi
        If locationCode = "" Then
            Tlokasi = " "
        Else
            Tlokasi = " AND a.loc='" & locationCode & "'"
        End If

        'Penggunaan group by
        Tgroup = " GROUP BY a.loc, a.incjenis, a.jenis, a.mesin, a.inctgl "

        'Penggunaan order by
        Torder = " ORDER BY a.loc, a.incjenis, a.jenis, a.mesin, a.inctgl DESC"

        'Query Dasar
        Tquery = "SELECT a.kartu, a.mesin, a.loc, a.incjenis, a.jenis, a.inctgl, a.incnilai AS sumnilai, CASE WHEN a.flagby = '' THEN '-' ELSE 'SEND' END AS 'flag' FROM acctranspendapatandetail a WHERE a.flag IS NULL AND date(a.inctgl)= '" & Format(DateTimeTglTransaksi.Value, "yyyyMMdd") & "'"
        Tquery = "SELECT a.kartu, a.mesin, a.loc, a.incjenis, a.jenis, a.inctgl, a.incnilai AS sumnilai, CASE WHEN a.flagby = '' THEN '-' ELSE 'SEND' END AS 'flag' FROM acctranspendapatandetail a WHERE date(a.inctgl)= '" & Format(DateTimeTglTransaksi.Value, "yyyyMMdd") & "'"

        Dim TblsGL As DataTable = ReadThemysql(Tquery + Tlokasi + Tjenispembayaran + Tjenistransaksi + Tgroup + Torder, DB_Keuangan)
        If TblsGL.Rows.Count > 0 Then
            For Each Trow As DataRow In TblsGL.Rows
                persen = persen + 1
                procent = persen * 100 / TblsGL.Rows.Count
                ProgressBarUpload.Value = procent

                Dim SumNilai As Double = 0
                Dim TempData As DataTable = ReadThemysql("" & Tquery & Tlokasi & " AND a.incjenis = '" & Trow("incjenis") & "' AND a.jenis = '" & Trow("jenis") & "' AND a.mesin='" & Trow("mesin") & "'" & Torder & "", DB_Keuangan)
                For Each TrowData As DataRow In TempData.Rows
                    SumNilai = SumNilai + TrowData("sumnilai")
                Next

                Dim Tlokasigl As DataTable = ReadThemysql("SELECT a.locgl, a.locket FROM masterlokasigl a WHERE a.loc='" & locationCode & "' AND a.jenistransaksi='" & Trow("incjenis") & "'", DB_Keuangan)
                Dim Trowlokasigl As DataRow = Tlokasigl.Rows(0)
                bsa = Trowlokasigl("locgl")
                KetLokasi = Trowlokasigl("locket")

                Nourut = ReadThemysqlNIK("SELECT concat(lpad(RIGHT(flag,3)+1,3,0)) from ( SELECT a.flag FROM acctranspendapatandetail a WHERE a.flag IS NOT NULL AND MONTH(a.inctgl)= '" & DateTime.ParseExact(Trow("inctgl"), "M/d/yyyy", Nothing).ToString("MM") & "' AND year(a.inctgl)= '" & DateTime.ParseExact(Trow("inctgl"), "M/d/yyyy", Nothing).ToString("yyyy-MM-dd") & "' AND a.loc='" & locationCode & "'  AND a.incjenis='" & Trow("incjenis") & "' UNION SELECT a.flag2 FROM acctranspendapatandetail a WHERE a.flag2 IS NOT NULL AND MONTH(a.inctgl)= '" & DateTime.ParseExact(Trow("inctgl"), "M/d/yyyy", Nothing).ToString("MM") & "' AND year(a.inctgl)= '" & DateTime.ParseExact(Trow("inctgl"), "M/d/yyyy", Nothing).ToString("yyyy-MM-dd") & "' AND a.loc='" & locationCode & "' AND a.incjenis='" & Trow("incjenis") & "') AS TRANSACTION order BY flag desc limit 1", DB_Keuangan)
                If IsDBNull(Nourut) = False And Nourut <> "" And Nourut <> "-" Then
                    flag = "" & DateTime.ParseExact(Trow("inctgl"), "M/d/yyyy", Nothing).ToString("yyMM") & locationCode & Trow("incjenis") & Nourut & ""
                Else
                    flag = "" & DateTime.ParseExact(Trow("inctgl"), "M/d/yyyy", Nothing).ToString("yyMM") & locationCode & Trow("incjenis") & "001"
                End If

                Dim KetBank As String = ""
                If Trow("mesin").ToString.Trim <> "" Then
                    KetBank = " " & Trow("mesin").ToString.Trim & " "
                Else
                    KetBank = " "
                End If

                keterangan = "TERIMA - OMZET " & Trow("jenis") & KetBank & KetLokasi & " " & DateTime.ParseExact(Trow("inctgl"), "M/d/yyyy", Nothing).ToString("dd/MM/yyyy") & ""

                'Select COA Pendapatan & Jenis Tunai
                If Trow("incjenis") = "DLL" Then
                    CoaJenisBayar = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPendapatanAdmin'", DB_Keuangan2)
                    CoaTunai = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaTunaiAdmin'", DB_Keuangan2)
                ElseIf Trow("incjenis") = "GIGI" Then
                    CoaJenisBayar = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPendapatanGigi'", DB_Keuangan2)
                    CoaTunai = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaTunaiGigi'", DB_Keuangan2)
                ElseIf Trow("incjenis") = "LAB" Then
                    CoaJenisBayar = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPendapatanLab'", DB_Keuangan2)
                    CoaTunai = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaTunaiLab'", DB_Keuangan2)
                ElseIf Trow("incjenis") = "POLI" Then
                    CoaJenisBayar = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPendapatanKlinik'", DB_Keuangan2)
                    CoaTunai = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaTunaiKlinik'", DB_Keuangan2)
                End If

                'Select Mesin EDC
                If Trow("mesin") = "BCA" Then
                    CoaMesin = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPiutangBCA'", DB_Keuangan2)
                ElseIf Trow("mesin") = "MANDIRI" Then
                    CoaMesin = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPiutangMANDIRI'", DB_Keuangan2)
                ElseIf Trow("mesin") = "CIMB" Then
                    CoaMesin = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPiutangCIMB'", DB_Keuangan2)
                ElseIf Trow("mesin") = "QRIS" Then
                    CoaMesin = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPiutangQRIS'", DB_Keuangan2)
                End If

                'Sending Jurnal
                'If Trow("jenis") = "TUNAI" Then
                '    WriteThemysql("SELECT F_MakeUMH('" & flag & "', 'out', '', '" & DateTime.ParseExact(Trow("inctgl"), "M/d/yyyy", Nothing).ToString("yyyy-MM-dd") & "', '" & CoaJenisBayar & "', '" & CoaTunai & "', 'IDR', 1, " & CDbl(SumNilai) & ", '" & keterangan.ToUpper() & "', '1', 1, '', '" & keterangan.ToUpper() & "', '', '', '" & bsa & "', 4, " & CDbl(SumNilai) & ", 'K')", DB_Jurnal)
                'ElseIf Trow("jenis") = "DEBET" Or Trow("jenis") = "KREDIT" Then
                '    WriteThemysql("SELECT F_MakeUMH('" & flag & "', 'out', '', '" & DateTime.ParseExact(Trow("inctgl"), "M/d/yyyy", Nothing).ToString("yyyy-MM-dd") & "', '" & CoaJenisBayar & "', '" & CoaMesin & "', 'IDR', 1, " & CDbl(SumNilai) & ", '" & keterangan.ToUpper() & "', '1', 1, '', '" & keterangan.ToUpper() & "', '', '', '" & bsa & "', 4, " & CDbl(SumNilai) & ", 'K')", DB_Jurnal)
                'End If

                'WriteThemysql("UPDATE acctranspendapatandetail a SET flagdate=now(), flagby='" & UserAdmin & "', a.flag='" & flag & "' WHERE a.flag IS NULL AND DATE(a.inctgl)= '" & Format(dtawaltunai.Value, "yyyyMMdd") & "' AND a.loc='" & locationCode & "' AND a.incjenis = '" & Trow("incjenis") & "' AND a.jenis = '" & Trow("jenis") & "' AND a.mesin='" & Trow("mesin") & "'", DB_Keuangan)
            Next

            MsgBox("Jurnal & Data Saved.", MsgBoxStyle.Information, "Success!")
        End If
        'End If
    End Sub

    Private Sub LoadTable()
        Dim status As String = ""
        Dim pilihan As Boolean = False

        Dim Tquery As String = ""
        Dim Tjenispembayaran As String = ""
        Dim Tjenistransaksi As String = ""
        Dim Tlokasi As String = ""
        Dim Tmesinedc As String = ""
        Dim Torder As String = ""
        Dim Tgroup As String = ""
        Dim Tkonversi As DataTable = New DataTable
        Dim KeyFlag As Integer = 0

        'Jenis Pembayaran
        If ComboBoxJenisTransaksi.SelectedIndex = 0 Then
            Tjenispembayaran = " AND a.incjenis IN ('DLL','GIGI','LAB','POLI')"
        ElseIf ComboBoxJenisTransaksi.SelectedIndex = 1 Then
            Tjenispembayaran = " AND a.incjenis='DLL'"
        ElseIf ComboBoxJenisTransaksi.SelectedIndex = 2 Then
            Tjenispembayaran = " AND a.incjenis='GIGI'"
        ElseIf ComboBoxJenisTransaksi.SelectedIndex = 3 Then
            Tjenispembayaran = " AND a.incjenis='LAB'"
        ElseIf ComboBoxJenisTransaksi.SelectedIndex = 4 Then
            Tjenispembayaran = " AND a.incjenis='POLI'"
        End If

        'Jenis Transaksi
        If ComboBoxJenisPembayaran.SelectedIndex = 0 Then
            Tjenistransaksi = " AND a.jenis IN ('Tunai','Debet','Kredit')"
        ElseIf ComboBoxJenisPembayaran.SelectedIndex = 1 Then
            Tjenistransaksi = " AND a.jenis='Tunai'"
        ElseIf ComboBoxJenisPembayaran.SelectedIndex = 2 Then
            Tjenistransaksi = " AND a.jenis='Debet'"
        ElseIf ComboBoxJenisPembayaran.SelectedIndex = 3 Then
            Tjenistransaksi = " AND a.jenis='Kredit'"
        ElseIf ComboBoxJenisPembayaran.SelectedIndex = 4 Then
            Tjenistransaksi = " AND a.jenis IN ('Debet','Kredit')"
        End If

        'Lokasi
        If locationCode = "" Then
            Tlokasi = " "
        Else
            Tlokasi = " AND a.loc='" & locationCode & "'"
        End If

        'Set Mesin
        If ComboBoxJenisPembayaran.Text.Contains("TUNAI") = False Then
            If ComboBoxBankEDC.SelectedIndex = 0 Then
                Tmesinedc = ""
            Else
                Tmesinedc = " AND a.mesin = '" & ComboBoxBankEDC.Text.Trim & "'"
            End If
        Else
            Tmesinedc = ""
        End If

        'Penggunaan order by
        Torder = " ORDER BY a.inctgl, a.incjenis, a.jenis ASC"

        Dim queryBuilder As New StringBuilder()
        queryBuilder.AppendLine("SELECT c.bankcoa, a.*, b.locationket, CASE WHEN a.trflockedby='' OR a.trflockedby IS NULL THEN '-' ELSE 'LOCKED' END AS 'transferlocked'")
        queryBuilder.AppendLine("FROM acctranspendapatandetail a")
        queryBuilder.AppendLine("     LEFT JOIN masterlokasi b ON a.loc=b.kodeklinik")
        queryBuilder.AppendLine("     LEFT JOIN acctranspendapatantransfer c ON a.transferid=c.transferid")
        queryBuilder.AppendLine("WHERE DATE(a.inctgl) = '" & Format(DateTimeTglTransaksi.Value, "yyyyMMdd") & "'")

        'Query Dasar
        Tquery = queryBuilder.ToString()

        Dim Tbls As DataTable = ReadThemysql(Tquery + Tlokasi + Tjenispembayaran + Tjenistransaksi + Tmesinedc + Torder, DB_Keuangan)

        DataGridViewDaftarTransaksi.Rows.Clear()

        If Tbls.Rows.Count > 0 Then
            For Each Trow As DataRow In Tbls.Rows
                Dim SumNilai As Double = 0
                Dim SumAdmin As Double = 0
                Dim BiayaAdmin As Double = 0
                Dim bankTujuan As String = ""
                Dim bankSumber As String = ""

                If IsDBNull(Trow("flag")) = True Then
                    KeyFlag = 1
                End If

                If Trow("transferlocked") = "LOCKED" Then
                    status = "LOCKED"
                    pilihan = True
                Else
                    If IsDBNull(Trow("pendingid")) = False Then
                        status = "PENDING"
                        pilihan = True
                    Else
                        status = "-"
                        pilihan = False
                    End If
                End If

                If Trow("jenis") = "Debet" Or Trow("jenis") = "Kredit" Then
                    If Trow("mesin") <> "" Then
                        ' Set Bank Tujuan (Bank EDC)
                        bankTujuan = Trow("mesin") ' Bank Pilihan Saat Closing

                        If bankTujuan.Contains("QRIS MANDIRI") = True Then
                            bankTujuan = "QRIS MANDIRI"
                        ElseIf bankTujuan.Contains("QRIS BTN") = True Then
                            bankTujuan = "QRIS BTN"
                        ElseIf bankTujuan.Contains("QRIS") = True Then
                            bankTujuan = "QRIS"
                        ElseIf bankTujuan.Contains("BCA") = True Then
                            bankTujuan = "BCA"
                        ElseIf bankTujuan.Contains("MANDIRI") = True Then
                            bankTujuan = "MANDIRI"
                        ElseIf bankTujuan.Contains("CIMB") = True Or bankTujuan.Contains("NIAGA") = True Then
                            bankTujuan = "CIMB"
                        Else
                            bankTujuan = "DLL"
                        End If

                        ' Set Bank Sumber (Bank Pasien)
                        If Trow("kartu").Contains("" & bankTujuan & "") = True Then
                            bankSumber = bankTujuan
                        ElseIf Trow("kartu").Contains("QRIS") = True Then
                            bankSumber = "QRIS"
                        Else
                            bankSumber = "DLL"
                        End If

                        Tkonversi = ReadThemysql("SELECT BiayaAdmin, Pembulatan FROM MasterKonversiAdminBankEDC WHERE JenisTransaksi = '" & Trow("jenis") & "' AND BankTujuan = '" & bankTujuan & "' AND BankSumber = '" & bankSumber & "';", DB_Omset)
                        Dim TrowKonversi As DataRow = Tkonversi.Rows(0)

                        BiayaAdmin = (TrowKonversi("BiayaAdmin") * Trow("incnilai")) / 100

                        If TrowKonversi("Pembulatan") = 1 Then
                            SumAdmin = SumAdmin + Math.Round(BiayaAdmin, 0, MidpointRounding.AwayFromZero)
                        Else
                            SumAdmin = SumAdmin + BiayaAdmin
                        End If
                    End If
                End If

                DataGridViewDaftarTransaksi.Rows.Add(New String() {"-", "" & Trow("inctransid") & "", "" & Trow("incdetailid") & "", "" & Trow("jenis") & "", "" & Trow("idinternet") & "", "" & Trow("Pasien") & "", "" & Trow("incjenis") & "", "" & Trow("kartu") & "", "" & Trow("mesin") & "", "" & Splitmoney(Trow("incnilai")) & "", "" & Splitmoney(SumAdmin) & "", "" & Format(Trow("inctgl"), "yyyy-MM-dd") & "", "" & status & "", "" & pilihan & "", "" & Trow("bankcoa") & ""})
            Next
        Else
            MsgBox("Belum ada data transaksi di tanggal " & Format(DateTimeTglTransaksi.Value, "dd-MMMM-yyyy") & "", MsgBoxStyle.Exclamation, "Warning!")
        End If

        If KeyFlag = 1 Then
            ProgressBarUpload.Visible = True
            ProgressBarUpload.Value = 0
        End If

        thread = New System.Threading.Thread(AddressOf SendJurnal_TunaiUMH)
        thread.Start()
    End Sub

    Public Sub LoadData()
        ' Inisialisasi koneksi ke database MySQL
        SetConnectionFromConfig()
    End Sub

    Private Sub Kalkulasi()
        Dim Tquery As String = ""
        Dim Tquery2 As String = ""
        Dim Tjenispembayaran As String = ""
        Dim Tjenistransaksi As String = ""
        Dim Tlokasi As String = ""
        Dim Tmesinedc As String = ""

        'Jenis Pembayaran
        If ComboBoxJenisTransaksi.SelectedIndex = 0 Then
            Tjenispembayaran = " AND a.incjenis IN ('DLL','GIGI','LAB','POLI')"
        ElseIf ComboBoxJenisTransaksi.SelectedIndex = 1 Then
            Tjenispembayaran = " AND a.incjenis='DLL'"
        ElseIf ComboBoxJenisTransaksi.SelectedIndex = 2 Then
            Tjenispembayaran = " AND a.incjenis='GIGI'"
        ElseIf ComboBoxJenisTransaksi.SelectedIndex = 3 Then
            Tjenispembayaran = " AND a.incjenis='LAB'"
        ElseIf ComboBoxJenisTransaksi.SelectedIndex = 4 Then
            Tjenispembayaran = " AND a.incjenis='POLI'"
        End If

        'Jenis Transaksi
        If ComboBoxJenisPembayaran.SelectedIndex = 0 Then
            Tjenistransaksi = " AND a.jenis IN ('Tunai','Debet','Kredit')"
        ElseIf ComboBoxJenisPembayaran.SelectedIndex = 1 Then
            Tjenistransaksi = " AND a.jenis='Tunai'"
        ElseIf ComboBoxJenisPembayaran.SelectedIndex = 2 Then
            Tjenistransaksi = " AND a.jenis='Debet'"
        ElseIf ComboBoxJenisPembayaran.SelectedIndex = 3 Then
            Tjenistransaksi = " AND a.jenis='Kredit'"
        ElseIf ComboBoxJenisPembayaran.SelectedIndex = 4 Then
            Tjenistransaksi = " AND a.jenis IN ('Debet','Kredit')"
        End If

        'Set Mesin
        If ComboBoxJenisPembayaran.Text.Contains("TUNAI") = False Then
            If ComboBoxBankEDC.SelectedIndex = 0 Then
                Tmesinedc = ""
            Else
                Tmesinedc = " AND a.mesin = '" & ComboBoxBankEDC.Text.Trim & "'"
            End If
        Else
            Tmesinedc = ""
        End If

        'Lokasi
        If locationCode = "" Then
            Tlokasi = " "
        Else
            Tlokasi = " AND a.loc='" & locationCode & "'"
        End If

        Tquery = "SELECT CASE WHEN COUNT(a.inctransid) > 0 THEN COUNT(a.inctransid) ELSE 0 END AS 'jumlahtransaksi', CASE WHEN SUM(a.incnilai) > 0 THEN SUM(a.incnilai) ELSE 0 END AS 'totalomset' FROM acctranspendapatandetail a WHERE date(a.inctgl)= '" & Format(DateTimeTglTransaksi.Value, "yyyyMMdd") & "'"
        Tquery2 = "SELECT CASE WHEN COUNT(a.inctransid) > 0 THEN COUNT(a.inctransid) ELSE 0 END AS 'jumlahtransaksi', CASE WHEN SUM(a.incnilai) > 0 THEN SUM(a.incnilai) ELSE 0 END AS 'totalomset' FROM acctranspendapatandetail a WHERE date(a.inctgl)= '" & Format(DateTimeTglTransaksi.Value, "yyyyMMdd") & "' AND a.trflockedby <> ''"

        Dim Tbls As DataTable = ReadThemysql(Tquery + Tlokasi + Tjenispembayaran + Tjenistransaksi + Tmesinedc, DB_Keuangan)
        Dim Tbls2 As DataTable = ReadThemysql(Tquery2 + Tlokasi + Tjenispembayaran + Tjenistransaksi + Tmesinedc, DB_Keuangan)

        For Each Trow As DataRow In Tbls.Rows
            'If Trow("totalomset") > 0 Then
            '    LabelTotalOmset.Text = Format(Val(Trow("totalomset")), "Rp, ###,###.#0")
            '    lbljumlahomset.Text = Trow("jumlahtransaksi")
            'Else
            '    LabelTotalOmset.Text = "Rp. 0"
            '    lbljumlahomset.Text = 0
            'End If

            If Trow("totalomset") > 0 Then
                LabelTotalOmset.Text = "" & Format(Val(Trow("totalomset")), "Rp, ###,###.#0") & " (" & Trow("jumlahtransaksi") & " Transaksi)"
            Else
                LabelTotalOmset.Text = "Rp. 0"
            End If
        Next

        For Each Trow As DataRow In Tbls2.Rows
            If Trow("totalomset") > 0 Then
                LabelTotalOmsetClosing.Text = "" & Format(Val(Trow("totalomset")), "Rp, ###,###.#0") & " (" & Trow("jumlahtransaksi") & " Transaksi)"
            Else
                LabelTotalOmsetClosing.Text = "Rp. 0"
            End If
        Next

        ButtonKalkulasi.PerformClick()
    End Sub

    Private Sub FormApprovePembayaranTunai_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        Me.MdiParent = PoliKlinik
        Me.Dock = DockStyle.Fill

        SetClear()
        LoadData()
        disablebutton()
    End Sub

    Public Sub disablebutton()
        ButtonKalkulasi.Enabled = False
        ButtonSimpan.Enabled = False
        DateTimeTglTransfer.Enabled = False
        TextBoxCoaBank.Enabled = False
        TextBoxNamaBank.Enabled = False
        ButtonCariBank.Enabled = False
    End Sub

    Public Sub enablebutton()
        ButtonKalkulasi.Enabled = True
        ButtonSimpan.Enabled = True
        DateTimeTglTransfer.Enabled = True
        CheckBox1.CheckState = CheckState.Unchecked
        TextBoxCoaBank.Enabled = True
        TextBoxNamaBank.Enabled = True
        ButtonCariBank.Enabled = True
    End Sub

    Private Sub butfindcomp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Find.Show()
        Find.QueryTheMysql("select distinct concat(kartu,'-',mesin) as CompJenis from acctranstagihandetail", " ", "FindCompTagihan", 0, Find_Keuangan)
    End Sub

    Private Sub butdisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadData()
        enablebutton()
    End Sub

    Private Sub butfindcabang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Find.Show()
        Find.QueryTheMysql("SELECT a.kodecabang AS 'kodeklinik', a.kodeket AS 'locationket', a.db_gl AS 'database' FROM mastercodebarcode a WHERE a.db_gl <> ''", " ", "FindCabangTunai", 0, Find_Poliklinik)
    End Sub

    Private Sub disableheader()
        DateTimeTglTransaksi.Enabled = False
        ComboBoxJenisPembayaran.Enabled = False
        ComboBoxJenisTransaksi.Enabled = False
        ComboBoxBankEDC.Enabled = False
        ButtonView.Enabled = False
    End Sub

    Private Sub enableheader()
        DateTimeTglTransaksi.Enabled = True
        ComboBoxJenisPembayaran.Enabled = True
        ComboBoxJenisTransaksi.Enabled = True
        ComboBoxBankEDC.Enabled = True
        ButtonView.Enabled = True
    End Sub

    'Private Sub loadcmbbanktransfer()
    '    Dim key As Integer = 0
    '    Dim VarBank As String = ""

    '    Dim BankTunai As String = ReadThemysqlNIK("SELECT b.namabank FROM masterlokasibank a LEFT JOIN accmasterbank b ON a.coabank = b.coa WHERE a.kodelokasi = '" & locationCode & "' AND a.statustunai = 1", DB_Keuangan2)
    '    Dim BankQRIS As String = ReadThemysqlNIK("SELECT b.namabank FROM masterlokasibank a LEFT JOIN accmasterbank b ON a.coabank = b.coa WHERE a.kodelokasi = '" & locationCode & "' AND a.namabank = 'QRIS'", DB_Keuangan2)

    '    Dim row As DataGridViewRow = Me.GridTunai.Rows(0)
    '    For Each col As DataGridViewColumn In row.DataGridView.Columns
    '        If col.Name = "BankTransfer" Then
    '            key = 1
    '        End If
    '    Next

    '    If key = 0 Then
    '        Dim dgvComboBox As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn()
    '        dgvComboBox.HeaderText = "Bank Transfer"
    '        dgvComboBox.Name = "BankTransfer"
    '        dgvComboBox.DisplayIndex = 10
    '        dgvComboBox.Width = 150
    '        Dim Tbls As DataTable = ReadThemysql("SELECT b.namabank, a.coabank FROM masterlokasibank a LEFT JOIN accmasterbank b ON a.coabank = b.coa GROUP BY b.namabank", DB_Keuangan2)
    '        For Each Trow As DataRow In Tbls.Rows
    '            dgvComboBox.Items.Add(Trow("namabank"))
    '        Next
    '        'dgvComboBox.Items.AddRange(New Object() {"Value 1", "Value 2", "Value 3"})
    '        GridTunai.Columns.Add(dgvComboBox)
    '    End If

    '    Dim TblsData As DataTable = ReadThemysql("SELECT b.namabank, a.coabank FROM masterlokasibank a LEFT JOIN accmasterbank b ON a.coabank = b.coa GROUP BY b.namabank", DB_Keuangan2)

    '    For i As Integer = 0 To GridTunai.Rows.Count - 1
    '        For Each Trow As DataRow In TblsData.Rows
    '            VarBank = Trow("namabank")
    '            If GridTunai.Rows(i).Cells("bankcoa").Value <> "" Then
    '                If GridTunai.Rows(i).Cells("bankcoa").Value = Trow("coabank") Then
    '                    GridTunai.Rows(i).Cells("BankTransfer").Value = Trow("namabank")
    '                End If
    '            Else
    '                If GridTunai.Rows(i).Cells("MesinTunai").Value = "" Then
    '                    GridTunai.Rows(i).Cells("BankTransfer").Value = BankTunai
    '                ElseIf VarBank.Contains(GridTunai.Rows(i).Cells("MesinTunai").Value) = True Then
    '                    GridTunai.Rows(i).Cells("BankTransfer").Value = ReadThemysqlNIK("SELECT b.namabank FROM masterlokasibank a LEFT JOIN accmasterbank b ON a.coabank = b.coa WHERE a.kodelokasi = '" & locationCode & "' AND a.namabank = '" & GridTunai.Rows(i).Cells("MesinTunai").Value & "'", DB_Keuangan2)
    '                ElseIf GridTunai.Rows(i).Cells("MesinTunai").Value = "QRIS" Then
    '                    GridTunai.Rows(i).Cells("BankTransfer").Value = BankQRIS
    '                End If
    '            End If
    '        Next
    '    Next
    'End Sub

    'Private Sub loadcmbbanktransfer()
    '    Dim key As Integer = 0
    '    Dim VarBank As String = ""

    '    Dim BankTunai As String = ReadThemysqlNIK("SELECT b.namabank FROM masterlokasibank a LEFT JOIN accmasterbank b ON a.coabank = b.coa WHERE a.kodelokasi = '" & locationCode & "' AND a.statustunai = 1", DB_Keuangan2)
    '    Dim BankQRIS As String = ReadThemysqlNIK("SELECT b.namabank FROM masterlokasibank a LEFT JOIN accmasterbank b ON a.coabank = b.coa WHERE a.kodelokasi = '" & locationCode & "' AND a.namabank = 'QRIS'", DB_Keuangan2)

    '    Dim row As DataGridViewRow = Me.DataGridViewDaftarTransaksi.Rows(0)
    '    For Each col As DataGridViewColumn In row.DataGridView.Columns
    '        If col.Name = "BankTransfer" Then
    '            key = 1
    '        End If
    '    Next

    '    If key = 0 Then
    '        Dim dgvComboBox As DataGridViewComboBoxColumn = New DataGridViewComboBoxColumn()
    '        dgvComboBox.HeaderText = "Bank Transfer"
    '        dgvComboBox.Name = "BankTransfer"
    '        dgvComboBox.DisplayIndex = 10
    '        dgvComboBox.Width = 150
    '        Dim Tbls As DataTable = ReadThemysql("SELECT b.namabank, a.coabank FROM masterlokasibank a LEFT JOIN accmasterbank b ON a.coabank = b.coa GROUP BY b.namabank", DB_Keuangan2)
    '        For Each Trow As DataRow In Tbls.Rows
    '            dgvComboBox.Items.Add(Trow("namabank"))
    '        Next
    '        'dgvComboBox.Items.AddRange(New Object() {"Value 1", "Value 2", "Value 3"})
    '        DataGridViewDaftarTransaksi.Columns.Add(dgvComboBox)
    '    End If

    '    Dim TblsData As DataTable = ReadThemysql("SELECT b.namabank, a.coabank FROM masterlokasibank a LEFT JOIN accmasterbank b ON a.coabank = b.coa GROUP BY b.namabank", DB_Keuangan2)

    '    For i As Integer = 0 To DataGridViewDaftarTransaksi.Rows.Count - 1
    '        For Each Trow As DataRow In TblsData.Rows
    '            VarBank = Trow("namabank")
    '            If DataGridViewDaftarTransaksi.Rows(i).Cells("bankcoa").Value <> "" Then
    '                If DataGridViewDaftarTransaksi.Rows(i).Cells("bankcoa").Value = Trow("coabank") Then
    '                    DataGridViewDaftarTransaksi.Rows(i).Cells("BankTransfer").Value = Trow("namabank")
    '                End If
    '            Else
    '                If DataGridViewDaftarTransaksi.Rows(i).Cells("MesinTunai").Value = "" Then
    '                    DataGridViewDaftarTransaksi.Rows(i).Cells("BankTransfer").Value = BankTunai
    '                ElseIf VarBank.Contains(DataGridViewDaftarTransaksi.Rows(i).Cells("MesinTunai").Value) = True Then
    '                    DataGridViewDaftarTransaksi.Rows(i).Cells("BankTransfer").Value = ReadThemysqlNIK("SELECT b.namabank FROM masterlokasibank a LEFT JOIN accmasterbank b ON a.coabank = b.coa WHERE a.kodelokasi = '" & locationCode & "' AND a.namabank = '" & DataGridViewDaftarTransaksi.Rows(i).Cells("MesinTunai").Value & "'", DB_Keuangan2)
    '                ElseIf DataGridViewDaftarTransaksi.Rows(i).Cells("MesinTunai").Value = "QRIS" Then
    '                    DataGridViewDaftarTransaksi.Rows(i).Cells("BankTransfer").Value = BankQRIS
    '                End If
    '            End If
    '        Next
    '    Next
    'End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        For i As Integer = 0 To DataGridViewDaftarTransaksi.Rows.Count - 1
            If DataGridViewDaftarTransaksi.Rows(i).Cells("StatusTunai").Value = "-" Then
                If CheckBox1.CheckState = CheckState.Checked Then
                    DataGridViewDaftarTransaksi.Rows(i).Cells("PilihanTunai").Value = True
                Else
                    DataGridViewDaftarTransaksi.Rows(i).Cells("PilihanTunai").Value = False
                End If
            End If
        Next
    End Sub

    Function ValidasiSimpanPembayaran() As Boolean
        Dim TempJenisBayar As String = ""
        Dim TempJenisBankTF As String = ""
        Dim JumlahRow As Integer = 0

        ' Validasi Tgl Transfer
        If DateTimeTglTransfer.Value < DateTimeTglTransaksi.Value Then
            MsgBox("Error: Tanggal transfer tidak boleh kurang dari tanggal transaksi.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        ' Validasi Bank Transfer
        If TextBoxCoaBank.ToString.Length = 0 Then
            MsgBox("Error: Bank transfer tidak boleh kosong.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        For i As Integer = 0 To DataGridViewDaftarTransaksi.Rows.Count - 1
            If CBool(DirectCast(DataGridViewDaftarTransaksi.Rows(i).Cells("PilihanTunai"), DataGridViewCheckBoxCell).Value) = True Then
                If DataGridViewDaftarTransaksi.Rows(i).Cells("StatusTunai").Value = "-" Then
                    If TempJenisBayar = "" Then
                        TempJenisBayar = DataGridViewDaftarTransaksi.Rows(i).Cells("JenisTunai").Value
                    ElseIf TempJenisBayar <> DataGridViewDaftarTransaksi.Rows(i).Cells("JenisTunai").Value Then
                        MsgBox("Jenis bayar yang di closing harus seragam.", MsgBoxStyle.Exclamation, "Warning!")
                        Return False
                    Else
                        TempJenisBayar = DataGridViewDaftarTransaksi.Rows(i).Cells("JenisTunai").Value
                    End If

                    JumlahRow = JumlahRow + 1
                End If
            End If
        Next

        If JumlahRow = 0 Then
            MsgBox("Error: Pilih Data Terlebih Dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        Return True
    End Function

    Private Sub cmbpembayaran_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxJenisPembayaran.SelectedIndexChanged
        If ComboBoxJenisPembayaran.Text.Contains("TUNAI") = False Then
            ComboBoxBankEDC.Enabled = True
        Else
            ComboBoxBankEDC.Enabled = False
        End If
    End Sub

    Private Sub ButtonClearData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClearData.Click
        SetClear()
        disablebutton()
        enableheader()
    End Sub

    Private Sub ButtonKirimUlangBKM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonKirimUlangBKM.Click
        thread = New System.Threading.Thread(AddressOf SendJurnal_BKM)
        thread.Start()
    End Sub

    Private Sub ButtonKirimUlangUMH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonKirimUlangUMH.Click
        thread = New System.Threading.Thread(AddressOf SendJurnal_UMH)
        thread.Start()
    End Sub

    Private Sub ButtonCariLokasi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCariLokasi.Click
        Find.Show()
        Find.QueryTheMysql("SELECT a.kode_klinik, a.nama_klinik, a.db_jurnal, a.jenis_jurnal FROM masterlokasiklinik a", " ", "FindCabangTunai", 0, Find_Poliklinik)
    End Sub

    Private Sub ButtonView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonView.Click
        If TextBoxKeteranganLokasi.Text = "" Then
            MsgBox("Pilih Cabang Terlebih Dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Exit Sub
        End If

        LoadTable()

        If DataGridViewDaftarTransaksi.Rows.Count > 0 Then
            'loadcmbbanktransfer()
            enablebutton()
            Kalkulasi()
        Else
            SetClear()
            disablebutton()
        End If

        disableheader()
    End Sub

    Private Sub ButtonKalkulasi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonKalkulasi.Click
        Dim total As Double = 0
        Dim totalbiayaadmin As Double = 0
        Dim jumlah As Integer = 0

        For i As Integer = 0 To DataGridViewDaftarTransaksi.Rows.Count - 1
            If CBool(DirectCast(DataGridViewDaftarTransaksi.Rows(i).Cells("PilihanTunai"), DataGridViewCheckBoxCell).Value) = True Then
                total = total + DataGridViewDaftarTransaksi.Rows(i).Cells("NilaiUangTunai").Value
                totalbiayaadmin = totalbiayaadmin + DataGridViewDaftarTransaksi.Rows(i).Cells("BiayaAdmin").Value
                jumlah = jumlah + 1
                LabelTotalOmsetCentang.Text = "" & Format(Val(total), "Rp, ###,###.#0") & " (" & jumlah & " Transaksi)"
                LabelTotalBiayaAdmin.Text = "" & Format(Val(totalbiayaadmin), "Rp, ###,###.#0")
            End If
        Next

        If jumlah = 0 Then
            LabelTotalOmsetCentang.Text = "Rp 0 (" & jumlah & " Transaksi)"
            LabelTotalBiayaAdmin.Text = "Rp 0 "
        End If
    End Sub

    Private Sub ButtonSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSimpan.Click
        Try
            thread = New System.Threading.Thread(AddressOf SimpanDataPembayaran)
            thread.Start()
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SimpanDataPembayaran()
        If MessageBox.Show("Yakin Data Sudah Benar?", "Validasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = MsgBoxResult.Yes Then
            If ValidasiSimpanPembayaran() = True Then
                Dim nominalTotal As Integer = 0
                Dim idTransfer As Integer = 0
                Dim idTransaksi As String = ""
                Dim rowTransaksi As Integer = 0

                ' Get Coa Bank
                Dim bankCoa As String = TextBoxCoaBank.Text

                For i As Integer = 0 To DataGridViewDaftarTransaksi.Rows.Count - 1
                    If CBool(DirectCast(DataGridViewDaftarTransaksi.Rows(i).Cells("PilihanTunai"), DataGridViewCheckBoxCell).Value) = True Then
                        If DataGridViewDaftarTransaksi.Rows(i).Cells("StatusTunai").Value = "-" Then
                            ' Set Total Nominal
                            nominalTotal = nominalTotal + DataGridViewDaftarTransaksi.Rows(i).Cells("NilaiUangTunai").Value

                            ' Set Transaksi ID
                            idTransaksi = idTransaksi & "'" & DataGridViewDaftarTransaksi.Rows(i).Cells("IDTunai").Value & "',"
                            rowTransaksi += 1
                        End If
                    End If
                Next

                If CheckThemysql("SELECT a.transferid FROM acctranspendapatantransfer a WHERE a.bankcoa = " & bankCoa & " AND date(a.tgltransfer)=" & Format(DateTimeTglTransfer.Value, "yyyyMMdd") & " AND date(a.tgltransaksi)= '" & Format(DateTimeTglTransaksi.Value, "yyyyMMdd") & "' AND cabang='" & locationCode & "'", DB_Keuangan) = False Then
                    ' Insert acctranspendapatantransfer
                    WriteThemysql("INSERT INTO acctranspendapatantransfer(`transferid`, `cabang`, `nominaltotal`, `tgltransaksi`, `tgltransfer`, `createdate`, `createby`, `bankcoa`) " & _
                     " VALUES('', '" & locationCode & "'," & nominalTotal & ",'" & Format(DateTimeTglTransaksi.Value, "yyyyMMdd") & "' ,'" & Format(DateTimeTglTransfer.Value, "yyyyMMdd") & "',now(),'" & UserAdmin & "', '" & bankCoa & "')", DB_Keuangan)

                    ' Get Transfer ID
                    idTransfer = ReadThemysqlNIK("SELECT a.transferid FROM acctranspendapatantransfer a WHERE a.bankcoa = " & bankCoa & " AND date(a.tgltransfer)=" & Format(DateTimeTglTransfer.Value, "yyyyMMdd") & " AND date(a.tgltransaksi)= '" & Format(DateTimeTglTransaksi.Value, "yyyyMMdd") & "' AND cabang='" & locationCode & "'", DB_Keuangan)
                Else
                    ' Get Transfer ID
                    idTransfer = ReadThemysqlNIK("SELECT a.transferid FROM acctranspendapatantransfer a WHERE a.bankcoa = " & bankCoa & " AND date(a.tgltransfer)=" & Format(DateTimeTglTransfer.Value, "yyyyMMdd") & " AND date(a.tgltransaksi)= '" & Format(DateTimeTglTransaksi.Value, "yyyyMMdd") & "' AND cabang='" & locationCode & "'", DB_Keuangan)

                    ' Update acctranspendapatantransfer
                    WriteThemysql("UPDATE acctranspendapatantransfer a SET a.nominaltotal = a.nominaltotal + " & nominalTotal & ", updatedate = NOW(), updateby = '" & UserAdmin & "' WHERE a.bankcoa = " & bankCoa & " AND date(a.tgltransfer)='" & Format(DateTimeTglTransfer.Value, "yyyyMMdd") & "' AND date(a.tgltransaksi)= '" & Format(DateTimeTglTransaksi.Value, "yyyyMMdd") & "' AND cabang='" & locationCode & "'", DB_Keuangan)
                End If

                If rowTransaksi > 0 Then
                    idTransaksi = Strings.Left(idTransaksi, idTransaksi.Length - 1)
                    WriteThemysql("UPDATE acctranspendapatandetail SET transferid = " & idTransfer & ", trflockeddate = NOW(), trflockedby = '" & UserAdmin & "', lockedby = '" & UserAdmin & "', lockeddate = NOW() WHERE incdetailid IN (" & idTransaksi & ")", DB_Keuangan)
                End If

                ' MASIH DIGUNAKAN
                ProgressBarUpload.Visible = True
                ProgressBarUpload.Value = 0

                ' Sending Jurnal BKM
                SendJurnal_BKM()

                ButtonView.PerformClick()
            End If
        End If
    End Sub

    Private Sub ButtonCariBank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCariBank.Click
        Find.Show()
        Find.QueryTheMysql("SELECT a.NamaBank, a.NomorRekening, a.NamaRekening, a.CabangRekening, a.CoaBank FROM MasterBankTransfer a WHERE a.StatusAktif = 1 AND a.TransferTunai = 1", " ", "FindBankApproveOmset", 0, Find_Omset)
    End Sub

    Private Sub ButtonClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClose.Click
        Me.Close()
    End Sub
End Class