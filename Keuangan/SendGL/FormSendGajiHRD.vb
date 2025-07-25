Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports System.Drawing
Imports System
Imports Newtonsoft.Json
Imports Newtonsoft
Imports System.Security.Cryptography
Imports System.Collections.Generic
Imports Newtonsoft.Json.Linq
Imports KASLibrary

Public Class FormSendGajiHRD
    Dim thread As System.Threading.Thread
    Private UserAdmin As String = PoliKlinik.Lbluser.Text
    Private StartjurnalDate As Date = #3/1/2021 12:00:52 AM#
    Private kodeLokasi As String = ""
    Private kodeDatabase As String = ""

    ' Set Connection
    Private Find_Keuangan2 As Find.TLconnect
    Private DB_Keuangan As TLcon
    Private DB_Poliklinik As TLcon
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

        ' Set DB Keuangan 1 (mitramed_keu)
        DB_Keuangan.Tip = serverOnline_IP
        DB_Keuangan.Tid = serverOnline_UserID
        DB_Keuangan.Tpass = serverOnline_Password
        DB_Keuangan.Tdb = Utility.GetConfig("ServerOnlineKeuangan_DB")

        ' Set DB Poliklinik
        DB_Poliklinik.Tip = serverOnline_IP
        DB_Poliklinik.Tid = serverOnline_UserID
        DB_Poliklinik.Tpass = serverOnline_Password
        DB_Poliklinik.Tdb = Utility.GetConfig("ServerOnlinePoli_DB")

        ' Set DB Jurnal
        DB_Jurnal.Tip = Utility.GetConfig("ServerJurnal_IP")
        DB_Jurnal.Tid = Utility.GetConfig("ServerJurnal_UserID")
        DB_Jurnal.Tpass = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerJurnal_Password"), "albert")
        DB_Jurnal.Tdb = Utility.GetConfig("ServerJurnal_DB")
    End Sub

    Public Class container
        Public response As Pendaftaran
        Public metaData As MetaData

        Public result As String
        Public rows() As JSON_result

        Public Class JSON_result
            Public Sales_Office As String
            Public Kode_Admin As String
            Public Komponen As String
            Public Nilai As Double
        End Class
    End Class

    Private Sub SetClear()
        cmbbankedc.SelectedIndex = 0
        kodeLokasi = ""
        kodeDatabase = ""
        txnamacabang.ResetText()
        disablebutton()
        ProgressBar1.Value = 0

        loadcmbbulan()
        loadcmbyear()
        cmbbulan.SelectedIndex = -1
        cmbtahun.SelectedIndex = -1
        cmbbankedc.SelectedIndex = -1

        txstatusket.Visible = False

        txgaji.ResetText()
        txtunjanganjabatan.ResetText()
        TextBoxTunjanganMasaKerja.ResetText()
        TextBoxTunjanganSIP.ResetText()
        txtunjangantransport.ResetText()
        TextBoxTunjanganPPH.ResetText()
        txpotonganabsen.ResetText()
        txuangmakan.ResetText()
        txuanglembur.ResetText()
        txpph21.ResetText()
        txbpjskesehatan.ResetText()
        txbpjsketenagakerjaan.ResetText()
        txpiutangkaryawan.ResetText()
        txpotonganjamin.ResetText()
        txpotonganjamout.ResetText()
        txpotonganmangkir.ResetText()
        txpotonganlain.ResetText()
        txpendapatanlain.ResetText()
        txpembulatan.ResetText()
    End Sub

    Private Sub loadcmbbulan()
        cmbbulan.Items.Clear()
        cmbbulan.Items.Add("Januari")
        cmbbulan.Items.Add("Februari")
        cmbbulan.Items.Add("Maret")
        cmbbulan.Items.Add("April")
        cmbbulan.Items.Add("Mei")
        cmbbulan.Items.Add("Juni")
        cmbbulan.Items.Add("Juli")
        cmbbulan.Items.Add("Agustus")
        cmbbulan.Items.Add("September")
        cmbbulan.Items.Add("Oktober")
        cmbbulan.Items.Add("November")
        cmbbulan.Items.Add("Desember")
        cmbbulan.SelectedIndex = 0
    End Sub

    Private Sub loadcmbyear()
        cmbtahun.Items.Clear()
        Dim vartahun As Integer = Date.Today.Year
        cmbtahun.Items.Add(vartahun)
        cmbtahun.Items.Add(vartahun - 1)
        cmbtahun.Items.Add(vartahun - 2)
        cmbtahun.Items.Add(vartahun - 3)
        cmbtahun.Items.Add(vartahun - 4)
        cmbtahun.SelectedIndex = 0
    End Sub

    Public Sub LoadData()
        ' Inisialisasi koneksi ke database MySQL
        SetConnectionFromConfig()
    End Sub

    Private Sub FormSendGajiHRD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        SetFormHeightWeight(Me, 0.95, 0.8)
        Control.CheckForIllegalCrossThreadCalls = False
        SetClear()
        LoadData()
        disablebutton()
    End Sub

    Public Sub disablebutton()
        butsave.Enabled = False
    End Sub

    Public Sub enablebutton()
        butsave.Enabled = True
    End Sub

    Private Sub ClearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearToolStripMenuItem.Click
        SetClear()
        disablebutton()
        enableheader()
    End Sub

    Private Sub butfindcabang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butfindcabang.Click
        Find.Show()
        Find.QueryTheMysql("SELECT masterlokasi.locid, masterlokasi.locationcode, masterlokasi.locationket, masterlokasi.locgroup, mastergruplokasi.db_gl FROM masterlokasi LEFT JOIN mastergruplokasi ON masterlokasi.locgroup = mastergruplokasi.locgroupcode", " ", "FindCabangSendGaji", 0, Find_Keuangan2)
    End Sub

    Public Sub LoadDataCompany(ByRef Trow As DataRowView)
        txnamacabang.Text = Trow("locationket").ToString
        kodeLokasi = Trow("locationcode").ToString
        kodeDatabase = Trow("db_gl").ToString
    End Sub

    Private Sub btnviewtunai_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butsearch.Click
        If CheckingView() = True Then
            Dim KeyEmpty As Boolean = False
            Dim bulan As String = Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(cmbbulan.Text, "Januari", "01"), "Februari", "02"), "Maret", "03"), "April", "04"), "Mei", "05"), "Juni", "06"), "Juli", "07"), "Agustus", "08"), "September", "09"), "Oktober", "10"), "November", "11"), "Desember", "12")
            Dim tahun As String = cmbtahun.Text
            Dim datepelunasanawal As DateTime = New DateTime(tahun, bulan, 1)
            Dim datepelunasanakhir As DateTime = New DateTime(tahun, bulan, DateTime.DaysInMonth(tahun, bulan))

            'Cek Data
            Dim Tgaji As DataTable = ReadThemysql("SELECT * FROM transaksipelunasangaji a WHERE a.cabang = '" & kodeLokasi & "' AND a.tahun = '" & tahun & "' AND a.bulan = '" & bulan & "' AND a.bank = '" & cmbbankedc.Text & "'", DB_Poliklinik)

            If Tgaji.Rows.Count > 0 Then
                txstatusket.Visible = True
                txstatusket.Text = "SUDAH APPROVE"
                txstatusket.BackColor = System.Drawing.Color.Green
                butsave.Enabled = False
                butsearch.Enabled = False

                Dim TrowGaji As DataRow = Tgaji.Rows(0)
                txgaji.Text = Splitmoney(CDbl(TrowGaji("nominalgaji")))
                txtunjanganjabatan.Text = Splitmoney(CDbl(TrowGaji("nominaltunjanganjabatan")))
                TextBoxTunjanganMasaKerja.Text = Splitmoney(CDbl(TrowGaji("nominaltunjanganmasakerja")))
                TextBoxTunjanganSIP.Text = Splitmoney(CDbl(TrowGaji("nominaltunjangansip")))
                txtunjangantransport.Text = Splitmoney(CDbl(TrowGaji("nominaltunjangantransport")))
                TextBoxTunjanganPPH.Text = Splitmoney(CDbl(TrowGaji("nominaltunjanganpph")))
                txpotonganabsen.Text = Splitmoney(CDbl(TrowGaji("nominalpotonganabsen")))
                txuangmakan.Text = Splitmoney(CDbl(TrowGaji("nominaluangmakan")))
                txuanglembur.Text = Splitmoney(CDbl(TrowGaji("nominaluanglembur")))
                txpembulatan.Text = Splitmoney(CDbl(TrowGaji("nominalpembulatan")))
                txpph21.Text = Splitmoney(CDbl(TrowGaji("nominalpph21")))
                txbpjskesehatan.Text = Splitmoney(CDbl(TrowGaji("nominalbpjskesehatan")))
                txbpjsketenagakerjaan.Text = Splitmoney(CDbl(TrowGaji("nominalbpjsketenagakerjaan")))
                txpiutangkaryawan.Text = Splitmoney(CDbl(TrowGaji("nominalpiutangkaryawan")))
                txpotonganjamin.Text = Splitmoney(CDbl(TrowGaji("nominalpotonganjamin")))
                txpotonganjamout.Text = Splitmoney(CDbl(TrowGaji("nominalpotonganjamout")))
                txpotonganmangkir.Text = Splitmoney(CDbl(TrowGaji("nominalpotonganmangkir")))
                txpotonganlain.Text = Splitmoney(CDbl(TrowGaji("nominalpotonganlain")))
                txpendapatanlain.Text = Splitmoney(CDbl(TrowGaji("nominalpendapatanlain")))
            Else
                Dim uri As String = ""
                'uri = "http://103.115.164.86/api/gaji.php?tglAwal='20210901'&tglAkhir='20210930'&password=GAJICMH"
                uri = "http://103.115.164.86/api/gaji.php?tglAwal='" & Format(datepelunasanawal, "yyyyMMdd") & "'&tglAkhir='" & Format(datepelunasanakhir, "yyyyMMdd") & "'&password=GAJICMH"

                Dim rawresp As String = "[" & GetDataAPI(uri) & "]"
                Dim varses() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of container())(rawresp.Replace("Sales Office", "Sales_Office").Replace("Kode Admin", "Kode_Admin"))

                Dim vNilaiGaji As Double = 0
                Dim vNilaiTunjanganJabatan As Double = 0
                Dim vNilaiTunjanganSIP As Double = 0
                Dim vNilaiTunjanganMasaKerja As Double = 0
                Dim vNilaiTunjanganTransport As Double = 0
                Dim vNilaiTunjanganPPH As Double = 0
                Dim vNilaiPotonganAbsen As Double = 0
                Dim vNilaiUangMakan As Double = 0
                Dim vNilaiUangLembur As Double = 0
                Dim vNilaiPPh21 As Double = 0
                Dim vNilaiKesehatan As Double = 0
                Dim vNilaiKetenagakerjaan As Double = 0
                Dim vNilaiPiutangKaryawan As Double = 0
                Dim vNilaiPotonganJamIn As Double = 0
                Dim vNilaiPotonganJamOut As Double = 0
                Dim vNilaiPotonganMangkir As Double = 0
                Dim vNilaiPotonganLain As Double = 0
                Dim vNilaiPendapatanLain As Double = 0
                Dim vNilaiSumGaji As Double = 0

                For Each oneVar As container In varses
                    If oneVar IsNot Nothing Then
                        For index As Integer = 0 To oneVar.rows.Count - 1
                            If oneVar.rows(index).Sales_Office = "" & kodeLokasi & "" And oneVar.rows(index).Kode_Admin = "" & cmbbankedc.Text & "" And oneVar.rows(index).Nilai <> "0" Then
                                If oneVar.rows(index).Komponen = "@UpahPokok@" Then
                                    vNilaiGaji = vNilaiGaji + oneVar.rows(index).Nilai
                                ElseIf oneVar.rows(index).Komponen = "@TunjanganJabatan@" Then
                                    vNilaiTunjanganJabatan = vNilaiTunjanganJabatan + oneVar.rows(index).Nilai
                                ElseIf oneVar.rows(index).Komponen = "@TunjanganMasaKerja@" Then
                                    vNilaiTunjanganMasaKerja = vNilaiTunjanganMasaKerja + oneVar.rows(index).Nilai
                                ElseIf oneVar.rows(index).Komponen = "@TunjanganSip@" Then
                                    vNilaiTunjanganSIP = vNilaiTunjanganSIP + oneVar.rows(index).Nilai
                                ElseIf oneVar.rows(index).Komponen = "@TunjanganTransport@" Then
                                    vNilaiTunjanganTransport = vNilaiTunjanganTransport + oneVar.rows(index).Nilai
                                ElseIf oneVar.rows(index).Komponen = "@TunjPPh@" Then
                                    vNilaiTunjanganPPH = vNilaiTunjanganPPH + oneVar.rows(index).Nilai
                                ElseIf oneVar.rows(index).Komponen = "@PotonganAbsen@" Then
                                    vNilaiPotonganAbsen = vNilaiPotonganAbsen + oneVar.rows(index).Nilai
                                ElseIf oneVar.rows(index).Komponen = "@UangMakan@" Then
                                    vNilaiUangMakan = vNilaiUangMakan + oneVar.rows(index).Nilai
                                ElseIf oneVar.rows(index).Komponen = "@Lembur@" Then
                                    vNilaiUangLembur = vNilaiUangLembur + oneVar.rows(index).Nilai
                                ElseIf oneVar.rows(index).Komponen = "@PotPPh@" Then
                                    vNilaiPPh21 = vNilaiPPh21 + oneVar.rows(index).Nilai
                                ElseIf oneVar.rows(index).Komponen = "@Kesehatan@" Then
                                    vNilaiKesehatan = vNilaiKesehatan + oneVar.rows(index).Nilai
                                ElseIf oneVar.rows(index).Komponen = "@Astek@" Then
                                    vNilaiKetenagakerjaan = vNilaiKetenagakerjaan + oneVar.rows(index).Nilai
                                ElseIf oneVar.rows(index).Komponen = "@Pinjaman@" Then
                                    vNilaiPiutangKaryawan = vNilaiPiutangKaryawan + oneVar.rows(index).Nilai
                                ElseIf oneVar.rows(index).Komponen = "@PotJamIn@" Then
                                    vNilaiPotonganJamIn = vNilaiPotonganJamIn + oneVar.rows(index).Nilai
                                ElseIf oneVar.rows(index).Komponen = "@PotJamOut@" Then
                                    vNilaiPotonganJamOut = vNilaiPotonganJamOut + oneVar.rows(index).Nilai
                                ElseIf oneVar.rows(index).Komponen = "@PotMangkir@" Then
                                    vNilaiPotonganMangkir = vNilaiPotonganMangkir + oneVar.rows(index).Nilai
                                ElseIf oneVar.rows(index).Komponen = "@PotonganLain@" Then
                                    vNilaiPotonganLain = vNilaiPotonganLain + oneVar.rows(index).Nilai
                                ElseIf oneVar.rows(index).Komponen = "@PendapatanLain@" Then
                                    vNilaiPendapatanLain = vNilaiPendapatanLain + oneVar.rows(index).Nilai
                                ElseIf oneVar.rows(index).Komponen = "@SumGaji@" Then
                                    vNilaiSumGaji = vNilaiSumGaji + oneVar.rows(index).Nilai
                                End If

                                KeyEmpty = True
                                butsave.Enabled = True
                                butsearch.Enabled = False
                                txstatusket.Visible = True
                                txstatusket.Text = "BELUM APPROVE"
                                txstatusket.BackColor = System.Drawing.Color.Tomato
                            End If
                        Next
                    End If
                Next

                txgaji.Text = Splitmoney(vNilaiGaji)
                txtunjanganjabatan.Text = Splitmoney(vNilaiTunjanganJabatan)
                TextBoxTunjanganMasaKerja.Text = Splitmoney(vNilaiTunjanganMasaKerja)
                TextBoxTunjanganSIP.Text = Splitmoney(vNilaiTunjanganSIP)
                txtunjangantransport.Text = Splitmoney(vNilaiTunjanganTransport)
                TextBoxTunjanganPPH.Text = Splitmoney(vNilaiTunjanganPPH)
                txuangmakan.Text = Splitmoney(vNilaiUangMakan)
                txpendapatanlain.Text = Splitmoney(vNilaiPendapatanLain)
                txuanglembur.Text = Splitmoney(vNilaiUangLembur)

                txpph21.Text = Splitmoney(vNilaiPPh21)
                txbpjskesehatan.Text = Splitmoney(vNilaiKesehatan)
                txbpjsketenagakerjaan.Text = Splitmoney(vNilaiKetenagakerjaan)
                txpiutangkaryawan.Text = Splitmoney(vNilaiPiutangKaryawan)
                txpotonganjamin.Text = Splitmoney(vNilaiPotonganJamIn)
                txpotonganjamout.Text = Splitmoney(vNilaiPotonganJamOut)
                txpotonganmangkir.Text = Splitmoney(vNilaiPotonganMangkir)
                txpotonganabsen.Text = Splitmoney(vNilaiPotonganAbsen)
                txpotonganlain.Text = Splitmoney(vNilaiPotonganLain)


                Dim vpembulatan As Double = 0
                vpembulatan = ((vNilaiGaji + vNilaiTunjanganJabatan + vNilaiTunjanganSIP + vNilaiTunjanganMasaKerja + vNilaiTunjanganTransport + vNilaiTunjanganPPH + vNilaiUangMakan + vNilaiPendapatanLain + vNilaiUangLembur) - (vNilaiPPh21 + vNilaiKesehatan + vNilaiKetenagakerjaan + vNilaiPiutangKaryawan + vNilaiPotonganJamIn + vNilaiPotonganJamOut + vNilaiPotonganMangkir + vNilaiPotonganAbsen + vNilaiPotonganLain)) - vNilaiSumGaji

                txpembulatan.Text = Splitmoney(vpembulatan)

                'Jika data kosong
                If KeyEmpty = False Then
                    MsgBox("Data tidak ditemukan.", MsgBoxStyle.Exclamation, "Warning!")
                End If
            End If
        End If
    End Sub

    Function CheckingView() As Boolean
        'Cek Bulan & Tahun
        If cmbbulan.Text = "" Or cmbtahun.Text = "" Then
            MsgBox("Bulan & Tahun tidak boleh kosong.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        'Cek Bank
        If cmbbankedc.Text = "" Then
            MsgBox("Bank tidak boleh kosong.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        'Cek Sales Office
        If kodeLokasi = "" Then
            MsgBox("Pilih sales office terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        Return True
    End Function

    Private Sub disableheader()
        butfindcabang.Enabled = False
        cmbbankedc.Enabled = False
        butsearch.Enabled = False
    End Sub

    Private Sub enableheader()
        butfindcabang.Enabled = True
        cmbbankedc.Enabled = True
        butsearch.Enabled = True
    End Sub

    Private Sub butsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butsave.Click
        If MsgBox("Yakin Data Sudah Benar?", MsgBoxStyle.YesNo, "Verifikasi.") = MsgBoxResult.Yes Then
            butsave.Enabled = False

            thread = New System.Threading.Thread(AddressOf SendJurnal)
            thread.Start()
        End If
    End Sub

    Private Sub SendJurnal()
        Dim procent As Integer = 0
        Dim persen As Integer = 0
        ProgressBar1.Value = procent

        Dim bulan As String = Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(cmbbulan.Text, "Januari", "01"), "Februari", "02"), "Maret", "03"), "April", "04"), "Mei", "05"), "Juni", "06"), "Juli", "07"), "Agustus", "08"), "September", "09"), "Oktober", "10"), "November", "11"), "Desember", "12")
        Dim tahun As String = cmbtahun.Text
        Dim datepelunasanawal As DateTime = New DateTime(tahun, bulan, 1)
        Dim datepelunasanakhir As DateTime = New DateTime(tahun, bulan, DateTime.DaysInMonth(tahun, bulan))

        'Set Database
        DB_Jurnal.Tdb = kodeDatabase

        'Set Jurnal
        Dim bsa As String = ""
        Dim flag As String = ""
        Dim Nourut As String = ""
        Dim Keterangan As String = ""
        Dim CoaGajiPokok As String = "50003801"
        Dim CoaGajiInHouse As String = "50003809"
        Dim CoaGaji As String = ""

        'Set COA Gaji
        If kodeLokasi = "IHWINGS" Or kodeLokasi = "IHKIS" Or kodeLokasi = "IHKIA" Or kodeLokasi = "IHINDOFOOD" Or kodeLokasi = "IHMAS" Or kodeLokasi = "IHASTRA" Or kodeLokasi = "INWIC" Or kodeLokasi = "MMCSBYHS" Or kodeLokasi = "MMCINHOUSESBY" Then
            CoaGaji = CoaGajiInHouse
        Else
            CoaGaji = CoaGajiPokok
        End If

        Dim CoaUtangGaji As String = "21010102"
        Dim CoaTunjanganJabatan As String = "50003804"
        Dim CoaTunjanganSIP As String = "50003812"
        Dim CoaTunjanganMasaKerja As String = "50003813"
        Dim CoaTunjanganTransport As String = "50003805"
        Dim CoaTunjanganPPH As String = "50003811"
        Dim CoaUangMakan As String = "50003806"
        Dim CoaPendapatanLain As String = "50003807"
        Dim CoaLembur As String = "50004201"
        Dim CoaHutangPPH21 As String = "21010116"
        Dim CoaPiutangBPJSKesehatan As String = "11021500"
        Dim CoaPiutangBPJSKetenagakerjaan As String = "11021600"
        Dim CoaPiutangKaryawan As String = "11021401"
        Dim CoaPotJamIn As String = "42011701"
        Dim CoaPotJamOut As String = "42011702"
        Dim CoaPotMangkir As String = "42011703"
        Dim CoaPotAbsen As String = "42011704"
        Dim CoaPotLain As String = "42011705"
        Dim CoaPembulatan As String = "71010602"
        Dim JurnalUMH As String = ""
        Dim IncrementNumber As Integer = 2

        'Set no urut flag
        Nourut = ReadThemysqlNIK("SELECT concat(lpad(RIGHT(a.flag,5)+1,5,0)) FROM transaksipelunasangaji a WHERE a.flag LIKE '%" & Format(datepelunasanawal, "yyyy") & Format(datepelunasanawal, "MM") & "PLN" & "%' ORDER BY a.flag DESC LIMIT 1", DB_Poliklinik)
        If IsDBNull(Nourut) = False And Nourut <> "" And Nourut <> "-" Then
            flag = Format(datepelunasanawal, "yyyy") & Format(datepelunasanawal, "MM") & "PLN" & Nourut.Trim
        Else
            flag = Format(datepelunasanawal, "yyyy") & Format(datepelunasanawal, "MM") & "PLN" & "00001"
        End If

        'Set Keterangan
        Keterangan = "GAJI " & txnamacabang.Text & " BULAN " & cmbbulan.Text.ToUpper & " TAHUN " & cmbtahun.Text & " REK. " & cmbbankedc.Text

        'set bsa
        bsa = ReadThemysqlNIK("SELECT a.bsa as a FROM bsa a WHERE a.bsaname='" & kodeLokasi & "'", DB_Jurnal)

        'Insert Log
        WriteThemysql("INSERT INTO `transaksipelunasangaji` (`cabang`, `tahun`, `bulan`, `bank`, `nominalgaji`, `nominaltunjanganjabatan`, `nominaltunjangansip`, `nominaltunjanganmasakerja`, `nominaltunjangantransport`, `nominaltunjanganpph`, `nominaluangmakan`, `nominalpendapatanlain`, `nominaluanglembur`, `nominalpembulatan`, `nominalpph21`, `nominalbpjskesehatan`, `nominalbpjsketenagakerjaan`, `nominalpiutangkaryawan`,	`nominalpotonganjamin`,	`nominalpotonganjamout`, `nominalpotonganmangkir`, `nominalpotonganabsen`, `nominalpotonganlain`, `flag`, `createdate`, `createby`) " & _
                  "VALUES ('" & kodeLokasi & "', '" & tahun & "', '" & bulan & "', '" & cmbbankedc.Text & "', '" & CDbl(txgaji.Text) & "', '" & CDbl(txtunjanganjabatan.Text) & "', '" & CDbl(TextBoxTunjanganSIP.Text) & "', '" & CDbl(TextBoxTunjanganMasaKerja.Text) & "', '" & CDbl(txtunjangantransport.Text) & "', '" & CDbl(TextBoxTunjanganPPH.Text) & "', '" & CDbl(txuangmakan.Text) & "', '" & CDbl(txpendapatanlain.Text) & "', '" & CDbl(txuanglembur.Text) & "', '" & CDbl(txpembulatan.Text) & "', '" & CDbl(txpph21.Text) & "', '" & CDbl(txbpjskesehatan.Text) & "', '" & CDbl(txbpjsketenagakerjaan.Text) & "', '" & CDbl(txpiutangkaryawan.Text) & "', '" & CDbl(txpotonganjamin.Text) & "', '" & CDbl(txpotonganjamout.Text) & "', '" & CDbl(txpotonganmangkir.Text) & "', '" & CDbl(txpotonganabsen.Text) & "', '" & CDbl(txpotonganlain.Text) & "', '" & flag & "', NOW(), '" & UserAdmin & "')", DB_Poliklinik)

        WriteThemysql("SELECT F_MakeUMH('" & flag & "', 'out', '', '" & Format(datepelunasanakhir, "yyyyMMdd") & "', '" & CoaUtangGaji & "', '" & CoaGaji & "', 'IDR', 1, " & CDbl(txgaji.Text) & ", '" & Keterangan.ToUpper() & "', '1', 1, '', '" & Keterangan.ToUpper() & "', '', '', '" & bsa & "', 1, " & CDbl(txgaji.Text) & ", 'D')", DB_Jurnal)
        JurnalUMH = ReadThemysqlNIK("SELECT a.umh as a FROM umh a WHERE a.oms='" & flag & "'", DB_Jurnal)

        'Proses 25%
        ProgressBar1.Value = 25

        If txtunjanganjabatan.Text <> "" And txtunjanganjabatan.Text <> "0" Then
            IncrementNumber = IncrementNumber + 1
            WriteThemysql("SELECT F_MakeUMH('" & flag & "', 'out', '" & JurnalUMH & "', '" & Format(datepelunasanakhir, "yyyyMMdd") & "', '" & CoaUtangGaji & "', '" & CoaTunjanganJabatan & "', 'IDR', 1, " & CDbl(txtunjanganjabatan.Text) & ", '" & Keterangan.ToUpper() & "', '1', " & IncrementNumber & ", '', '" & Keterangan.ToUpper() & "', '', '', '" & bsa & "', 1, " & CDbl(txtunjanganjabatan.Text) & ", 'D')", DB_Jurnal)
        End If

        If TextBoxTunjanganSIP.Text <> "" And TextBoxTunjanganSIP.Text <> "0" Then
            IncrementNumber = IncrementNumber + 1
            WriteThemysql("SELECT F_MakeUMH('" & flag & "', 'out', '" & JurnalUMH & "', '" & Format(datepelunasanakhir, "yyyyMMdd") & "', '" & CoaUtangGaji & "', '" & CoaTunjanganSIP & "', 'IDR', 1, " & CDbl(TextBoxTunjanganSIP.Text) & ", '" & Keterangan.ToUpper() & "', '1', " & IncrementNumber & ", '', '" & Keterangan.ToUpper() & "', '', '', '" & bsa & "', 1, " & CDbl(TextBoxTunjanganSIP.Text) & ", 'D')", DB_Jurnal)
        End If

        If TextBoxTunjanganMasaKerja.Text <> "" And TextBoxTunjanganMasaKerja.Text <> "0" Then
            IncrementNumber = IncrementNumber + 1
            WriteThemysql("SELECT F_MakeUMH('" & flag & "', 'out', '" & JurnalUMH & "', '" & Format(datepelunasanakhir, "yyyyMMdd") & "', '" & CoaUtangGaji & "', '" & CoaTunjanganMasaKerja & "', 'IDR', 1, " & CDbl(TextBoxTunjanganMasaKerja.Text) & ", '" & Keterangan.ToUpper() & "', '1', " & IncrementNumber & ", '', '" & Keterangan.ToUpper() & "', '', '', '" & bsa & "', 1, " & CDbl(TextBoxTunjanganMasaKerja.Text) & ", 'D')", DB_Jurnal)
        End If

        If txtunjangantransport.Text <> "" And txtunjangantransport.Text <> "0" Then
            IncrementNumber = IncrementNumber + 1
            WriteThemysql("SELECT F_MakeUMH('" & flag & "', 'out', '" & JurnalUMH & "', '" & Format(datepelunasanakhir, "yyyyMMdd") & "', '" & CoaUtangGaji & "', '" & CoaTunjanganTransport & "', 'IDR', 1, " & CDbl(txtunjangantransport.Text) & ", '" & Keterangan.ToUpper() & "', '1', " & IncrementNumber & ", '', '" & Keterangan.ToUpper() & "', '', '', '" & bsa & "', 1, " & CDbl(txtunjangantransport.Text) & ", 'D')", DB_Jurnal)
        End If

        If TextBoxTunjanganPPH.Text <> "" And TextBoxTunjanganPPH.Text <> "0" Then
            IncrementNumber = IncrementNumber + 1
            WriteThemysql("SELECT F_MakeUMH('" & flag & "', 'out', '" & JurnalUMH & "', '" & Format(datepelunasanakhir, "yyyyMMdd") & "', '" & CoaUtangGaji & "', '" & CoaTunjanganPPH & "', 'IDR', 1, " & CDbl(TextBoxTunjanganPPH.Text) & ", '" & Keterangan.ToUpper() & "', '1', " & IncrementNumber & ", '', '" & Keterangan.ToUpper() & "', '', '', '" & bsa & "', 1, " & CDbl(TextBoxTunjanganPPH.Text) & ", 'D')", DB_Jurnal)
        End If

        If txuangmakan.Text <> "" And txuangmakan.Text <> "0" Then
            IncrementNumber = IncrementNumber + 1
            WriteThemysql("SELECT F_MakeUMH('" & flag & "', 'out', '" & JurnalUMH & "', '" & Format(datepelunasanakhir, "yyyyMMdd") & "', '" & CoaUtangGaji & "', '" & CoaUangMakan & "', 'IDR', 1, " & CDbl(txuangmakan.Text) & ", '" & Keterangan.ToUpper() & "', '1', " & IncrementNumber & ", '', '" & Keterangan.ToUpper() & "', '', '', '" & bsa & "', 1, " & CDbl(txuangmakan.Text) & ", 'D')", DB_Jurnal)
        End If

        If txpendapatanlain.Text <> "" And txpendapatanlain.Text <> "0" Then
            IncrementNumber = IncrementNumber + 1
            WriteThemysql("SELECT F_MakeUMH('" & flag & "', 'out', '" & JurnalUMH & "', '" & Format(datepelunasanakhir, "yyyyMMdd") & "', '" & CoaUtangGaji & "', '" & CoaPendapatanLain & "', 'IDR', 1, " & CDbl(txpendapatanlain.Text) & ", '" & Keterangan.ToUpper() & "', '1', " & IncrementNumber & ", '', '" & Keterangan.ToUpper() & "', '', '', '" & bsa & "', 1, " & CDbl(txpendapatanlain.Text) & ", 'D')", DB_Jurnal)
        End If

        If txuanglembur.Text <> "" And txuanglembur.Text <> "0" Then
            IncrementNumber = IncrementNumber + 1
            WriteThemysql("SELECT F_MakeUMH('" & flag & "', 'out', '" & JurnalUMH & "', '" & Format(datepelunasanakhir, "yyyyMMdd") & "', '" & CoaUtangGaji & "', '" & CoaLembur & "', 'IDR', 1, " & CDbl(txuanglembur.Text) & ", '" & Keterangan.ToUpper() & "', '1', " & IncrementNumber & ", '', '" & Keterangan.ToUpper() & "', '', '', '" & bsa & "', 1, " & CDbl(txuanglembur.Text) & ", 'D')", DB_Jurnal)
        End If

        If txpembulatan.Text <> "" And txpembulatan.Text <> "0" Then
            Dim vpembulatan As Double = txpembulatan.Text
            IncrementNumber = IncrementNumber + 1
            If txpembulatan.Text < 0 Then
                WriteThemysql("SELECT F_MakeUMH('" & flag & "', 'out', '" & JurnalUMH & "', '" & Format(datepelunasanakhir, "yyyyMMdd") & "', '" & CoaUtangGaji & "', '" & CoaPembulatan & "', 'IDR', 1, " & CDbl(Math.Abs(vpembulatan)) & ", '" & Keterangan.ToUpper() & "', '1', " & IncrementNumber & ", '', '" & Keterangan.ToUpper() & "', '', '', '" & bsa & "', 1, " & CDbl(Math.Abs(vpembulatan)) & ", 'D')", DB_Jurnal)
            ElseIf txpembulatan.Text > 0 Then
                WriteThemysql("SELECT F_MakeUMH('" & flag & "', 'out', '" & JurnalUMH & "', '" & Format(datepelunasanakhir, "yyyyMMdd") & "', '" & CoaUtangGaji & "', '" & CoaPembulatan & "', 'IDR', 1, " & CDbl(Math.Abs(vpembulatan)) & ", '" & Keterangan.ToUpper() & "', '1', " & IncrementNumber & ", '', '" & Keterangan.ToUpper() & "', '', '', '" & bsa & "', 1, " & CDbl(Math.Abs(vpembulatan)) & ", 'K')", DB_Jurnal)
            End If
        End If

        'Proses 50%
        ProgressBar1.Value = 50

        If txpph21.Text <> "" And txpph21.Text <> "0" Then
            IncrementNumber = IncrementNumber + 1
            WriteThemysql("SELECT F_MakeUMH('" & flag & "', 'out', '" & JurnalUMH & "', '" & Format(datepelunasanakhir, "yyyyMMdd") & "', '" & CoaUtangGaji & "', '" & CoaHutangPPH21 & "', 'IDR', 1, " & CDbl(txpph21.Text) & ", '" & Keterangan.ToUpper() & "', '1', " & IncrementNumber & ", '', '" & Keterangan.ToUpper() & "', '', '', '" & bsa & "', 1, " & CDbl(txpph21.Text) & ", 'K')", DB_Jurnal)
        End If

        If txbpjskesehatan.Text <> "" And txbpjskesehatan.Text <> "0" Then
            IncrementNumber = IncrementNumber + 1
            WriteThemysql("SELECT F_MakeUMH('" & flag & "', 'out', '" & JurnalUMH & "', '" & Format(datepelunasanakhir, "yyyyMMdd") & "', '" & CoaUtangGaji & "', '" & CoaPiutangBPJSKesehatan & "', 'IDR', 1, " & CDbl(txbpjskesehatan.Text) & ", '" & Keterangan.ToUpper() & "', '1', " & IncrementNumber & ", '', '" & Keterangan.ToUpper() & "', '', '', '" & bsa & "', 1, " & CDbl(txbpjskesehatan.Text) & ", 'K')", DB_Jurnal)
        End If

        If txbpjsketenagakerjaan.Text <> "" And txbpjsketenagakerjaan.Text <> "0" Then
            IncrementNumber = IncrementNumber + 1
            WriteThemysql("SELECT F_MakeUMH('" & flag & "', 'out', '" & JurnalUMH & "', '" & Format(datepelunasanakhir, "yyyyMMdd") & "', '" & CoaUtangGaji & "', '" & CoaPiutangBPJSKetenagakerjaan & "', 'IDR', 1, " & CDbl(txbpjsketenagakerjaan.Text) & ", '" & Keterangan.ToUpper() & "', '1', " & IncrementNumber & ", '', '" & Keterangan.ToUpper() & "', '', '', '" & bsa & "', 1, " & CDbl(txbpjsketenagakerjaan.Text) & ", 'K')", DB_Jurnal)
        End If

        'Proses 75%
        ProgressBar1.Value = 75

        If txpiutangkaryawan.Text <> "" And txpiutangkaryawan.Text <> "0" Then
            IncrementNumber = IncrementNumber + 1
            WriteThemysql("SELECT F_MakeUMH('" & flag & "', 'out', '" & JurnalUMH & "', '" & Format(datepelunasanakhir, "yyyyMMdd") & "', '" & CoaUtangGaji & "', '" & CoaPiutangKaryawan & "', 'IDR', 1, " & CDbl(txpiutangkaryawan.Text) & ", '" & Keterangan.ToUpper() & "', '1', " & IncrementNumber & ", '', '" & Keterangan.ToUpper() & "', '', '', '" & bsa & "', 1, " & CDbl(txpiutangkaryawan.Text) & ", 'K')", DB_Jurnal)
        End If

        If txpotonganjamin.Text <> "" And txpotonganjamin.Text <> "0" Then
            IncrementNumber = IncrementNumber + 1
            WriteThemysql("SELECT F_MakeUMH('" & flag & "', 'out', '" & JurnalUMH & "', '" & Format(datepelunasanakhir, "yyyyMMdd") & "', '" & CoaUtangGaji & "', '" & CoaPotJamIn & "', 'IDR', 1, " & CDbl(txpotonganjamin.Text) & ", '" & Keterangan.ToUpper() & "', '1', " & IncrementNumber & ", '', '" & Keterangan.ToUpper() & "', '', '', '" & bsa & "', 1, " & CDbl(txpotonganjamin.Text) & ", 'K')", DB_Jurnal)
        End If

        If txpotonganjamout.Text <> "" And txpotonganjamout.Text <> "0" Then
            IncrementNumber = IncrementNumber + 1
            WriteThemysql("SELECT F_MakeUMH('" & flag & "', 'out', '" & JurnalUMH & "', '" & Format(datepelunasanakhir, "yyyyMMdd") & "', '" & CoaUtangGaji & "', '" & CoaPotJamOut & "', 'IDR', 1, " & CDbl(txpotonganjamout.Text) & ", '" & Keterangan.ToUpper() & "', '1', " & IncrementNumber & ", '', '" & Keterangan.ToUpper() & "', '', '', '" & bsa & "', 1, " & CDbl(txpotonganjamout.Text) & ", 'K')", DB_Jurnal)
        End If

        If txpotonganmangkir.Text <> "" And txpotonganmangkir.Text <> "0" Then
            IncrementNumber = IncrementNumber + 1
            WriteThemysql("SELECT F_MakeUMH('" & flag & "', 'out', '" & JurnalUMH & "', '" & Format(datepelunasanakhir, "yyyyMMdd") & "', '" & CoaUtangGaji & "', '" & CoaPotMangkir & "', 'IDR', 1, " & CDbl(txpotonganmangkir.Text) & ", '" & Keterangan.ToUpper() & "', '1', " & IncrementNumber & ", '', '" & Keterangan.ToUpper() & "', '', '', '" & bsa & "', 1, " & CDbl(txpotonganmangkir.Text) & ", 'K')", DB_Jurnal)
        End If

        If txpotonganabsen.Text <> "" And txpotonganabsen.Text <> "0" Then
            IncrementNumber = IncrementNumber + 1
            WriteThemysql("SELECT F_MakeUMH('" & flag & "', 'out', '" & JurnalUMH & "', '" & Format(datepelunasanakhir, "yyyyMMdd") & "', '" & CoaUtangGaji & "', '" & CoaPotAbsen & "', 'IDR', 1, " & CDbl(txpotonganabsen.Text) & ", '" & Keterangan.ToUpper() & "', '1', " & IncrementNumber & ", '', '" & Keterangan.ToUpper() & "', '', '', '" & bsa & "', 1, " & CDbl(txpotonganabsen.Text) & ", 'K')", DB_Jurnal)
        End If

        If txpotonganlain.Text <> "" And txpotonganlain.Text <> "0" Then
            IncrementNumber = IncrementNumber + 1
            WriteThemysql("SELECT F_MakeUMH('" & flag & "', 'out', '" & JurnalUMH & "', '" & Format(datepelunasanakhir, "yyyyMMdd") & "', '" & CoaUtangGaji & "', '" & CoaPotLain & "', 'IDR', 1, " & CDbl(txpotonganlain.Text) & ", '" & Keterangan.ToUpper() & "', '1', " & IncrementNumber & ", '', '" & Keterangan.ToUpper() & "', '', '', '" & bsa & "', 1, " & CDbl(txpotonganlain.Text) & ", 'K')", DB_Jurnal)
        End If

        'Proses 100%
        ProgressBar1.Value = 100

        MsgBox("Berhasil menyimpan data.", MsgBoxStyle.Information, "Success!")
    End Sub

    Function Checking() As Boolean
        Dim TempJenisBayar As String = ""
        Dim TempJenisBankTF As String = ""
        Dim JumlahRow As Integer = 0

        'If dttransfer.Value < dtawaltunai.Value Then
        '    MsgBox("Tanggal transfer tidak boleh kurang dari tanggal transaksi.", MsgBoxStyle.Exclamation, "Warning!")
        '    Return False
        'End If

        If JumlahRow = 0 Then
            MsgBox("Pilih Data Terlebih Dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        Return True
    End Function
End Class