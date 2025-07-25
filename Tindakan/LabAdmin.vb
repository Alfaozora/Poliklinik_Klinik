Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports System.IO
Imports System.Text
Imports System.Net.Mail
Imports System.Net
Imports System.Net.Sockets
Imports System.Object
Imports Newtonsoft.Json
Imports Newtonsoft
Imports System.Security.Cryptography
Imports System.Collections.Generic
Imports Newtonsoft.Json.Linq
Imports System.Drawing
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraPrinting.Drawing

Public Class LabAdmin
    Dim Ttcon As TLcon
    Dim TtconU As TLcon
    Dim Ttmesin As TLcon

    Private DB_Tracking As TLcon
    Private DB_Poliklinik As TLcon

    Dim thread As System.Threading.Thread
    Private NoWhatsappCompany As String = ""
    Private NoWhatsappMarketing As String = ""
    Private NoWhatsappCustomer As String = ""
    Private EmailCompany As String = ""
    Private EmailCustomer As String = ""
    Private SendHasilDL As Boolean = False
    Private SendHasilThorax As Boolean = False
    Private UserLabAdmin As String = PoliKlinik.Lbluser.Text
    Private AutoTTD As String = ""

    Private totalKetTidakNormal As Integer = 0
    Private totalKetNormal As Integer = 0
    Private totalSaranTidakNormal As Integer = 0
    Private totalSaranNormal As Integer = 0
    Private totalRiwayat As Integer = 0

    ' Set Default
    Private DrPelaksanaKlinik As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='DokterPK'")

    Function CreateTablePasien() As DataTable
        Dim Thasil As New DataTable

        insertRowToTbls(Thasil, "Typstring", "Nama")
        insertRowToTbls(Thasil, "Typstring", "PTNIK")
        insertRowToTbls(Thasil, "Typstring", "TglLahir")
        insertRowToTbls(Thasil, "Typstring", "Alamat")

        Return Thasil
    End Function

    Private Sub SetClearHeader()
        QR_Code_Trans.Image = Nothing
        butfindtindakanid.Enabled = True

        'Date & Keterangan
        setdatefisik()
        txkenapaoperasi.ResetText()
        txkenapars.ResetText()
        txdimanaoperasi.ResetText()
        txdimanars.ResetText()
        txjenisnarkoba.ResetText()
        txpenyakitobat.ResetText()
        TextBoxStatusFit.ResetText()

        txalamat.ResetText()
        txcaraambil.ResetText()
        txpenagihan.ResetText()
        txcodepenagihan.ResetText()
        TextBoxNoTransaksi.ResetText()
        buttindakanid.ResetText()
        TextBoxNoTransaksi.Enabled = True
        TextBoxNoTransaksi.ReadOnly = False
        TextBoxNoRekamMedis.ResetText()
        TextBoxGelar.ResetText()
        TextBoxJenisKelamin.ResetText()
        TextBoxNamaPasien.ResetText()
        TextBoxUmur.ResetText()
        DateTimeTanggalLahir.Value = DateSerial("9998", "12", "31")
        DateTimeTanggalTransaksi.Value = DateAndTime.Now
        chkclosed.Checked = False
        butdokter.ResetText()
        txpraktekid.ResetText()

        dtchanged.Value = DateAndTime.Now
        txchanged.Text = UserLabAdmin
        txketall.ResetText()
        txsaranall.ResetText()
        cmbvisusmata.SelectedIndex = 0
        cmbvisustanpakacamata.SelectedIndex = 0
        DownloadHasilOnlineToolStripMenuItem.Enabled = False
        DownloadHasilToolStripMenuItem.Enabled = False
        ResendToMesinToolStripMenuItem.Enabled = False
        PrintSementaraToolStripMenuItem.Enabled = False
        PreviewHasilLabToolStripMenuItem.Enabled = False
        PrintSuratKetToolStripMenuItem.Enabled = False
        SendiToolStripMenuItem.Enabled = False
        GroupBoxDL.Visible = False
        exportpdfDL.Visible = False
        CetakLabelMenuStrip.Enabled = False
        StartProcessToolStripMenuItem.Enabled = True
        cmbrangedate.SelectedIndex = 0

        InsertNewItemComboSQL("SELECT StrValue FROM MsConfig WHERE ConfigName like '%fisik%'", cmbfisiknewdr)
        InsertNewItemComboSQL("SELECT StrValue FROM MsConfig WHERE ConfigName like '%thorax%'", drthorax)
        drthorax.ResetText()
        InsertNewItemComboSQL("SELECT StrValue FROM MsConfig WHERE ConfigName like '%ecg%'", cmbecg)
        cmbecg.ResetText()
        InsertNewItemComboSQL("SELECT StrValue FROM MsConfig WHERE ConfigName like '%audio%'", draudio)
        draudio.ResetText()
        InsertNewItemComboSQL("SELECT StrValue FROM MsConfig WHERE ConfigName like '%usg%'", drusg)
        drusg.ResetText()
        InsertNewItemComboSQL("SELECT StrValue FROM MsConfig WHERE ConfigName like '%treadmill%'", drtreadmill)
        drtreadmill.ResetText()
        InsertNewItemComboSQL("SELECT StrValue FROM MsConfig WHERE ConfigName like '%spiro%'", drspiro)
        drspiro.ResetText()
    End Sub

    Public Sub SaveHematologiLengkap()
        CreateHematologiLengkapToPDF("Nothing")
    End Sub

    Public Sub setConnectionMesin()
        ' Set Parameter Server Online
        Dim serverOnline_IP As String = Utility.GetConfig("ServerOnline_IP")
        Dim serverOnline_UserID As String = Utility.GetConfig("ServerOnline_UserID")
        Dim serverOnline_Password As String = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerOnline_Password"), "albert")

        ' Set DB Tracking (db_tracking)
        DB_Tracking.Tip = serverOnline_IP
        DB_Tracking.Tid = serverOnline_UserID
        DB_Tracking.Tpass = serverOnline_Password
        DB_Tracking.Tdb = Utility.GetConfig("ServerOnlineTracking_DB")

        ' Set DB Poliklinik
        DB_Poliklinik.Tip = serverOnline_IP
        DB_Poliklinik.Tid = serverOnline_UserID
        DB_Poliklinik.Tpass = serverOnline_Password
        DB_Poliklinik.Tdb = Utility.GetConfig("ServerOnlinePoli_DB")

        Ttcon.Tid = "root"
        Ttcon.Tip = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='TIP'")
        Ttcon.Tdb = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='TDB'")
        Ttcon.Tpass = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='TPass'")

        Dim status_urine As String = Utility.GetConfig("MesinUrine")
        Dim Tdiff As Integer = Utility.GetConfig("MesinDiff")
        If status_urine = "Yes" Or Tdiff = 3 Then
            TtconU.Tid = "root"
            TtconU.Tip = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='TIP_Urine'")
            TtconU.Tdb = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='TDB_Urine'")
            TtconU.Tpass = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='TPass_Urine'")
        End If
    End Sub

    Private Sub ClearTextDetailSelainLab()
        DisableThorax()
        DisableECG()
        DisableFisikNew2()
        DisableAudio()
        DisableUSG()
        DisableTreadmill()
        DisableSpiro()
    End Sub

    Private Sub DisableUSG()
        txusg.Enabled = False
        butsaveusg.Enabled = False
        butprintusg.Enabled = False

        txusg.ResetText()
    End Sub


    Private Sub DisableAudio()
        txaudiometri.Enabled = False
        butsaveaudio.Enabled = False
        butprintaudio.Enabled = False

        txaudiometri.ResetText()
        dtaudio.Value = DateAndTime.Now
        txaudioby.ResetText()
    End Sub

    Private Sub DisableFisikNew2()
        gridfisiknew.Enabled = False
        butfisiknewsave.Enabled = True
        butfisiknewprint.Enabled = True
        butfisiknewpreview.Enabled = True
        ClearFisikDetail()
    End Sub

    Private Sub DisableECG()
        txhasilecg.Enabled = False
        txecgtekanan.Enabled = False
        butsaveecg.Enabled = False
        butprintecg.Enabled = False
        butpreviewecg.Enabled = False

        txhasilecg.ResetText()
        txecgtekanan.ResetText()
        dtecg.Value = DateAndTime.Now
        txecgby.ResetText()
    End Sub

    Private Sub DisableThorax()
        txthoraxcor.Enabled = False
        txthoraxpulmo.Enabled = False
        txthoraxsinus.Enabled = False
        txthoraxskeletal.Enabled = False
        txthoraxkesimpulan.Enabled = False
        butsavethorax.Enabled = False
        butprintthorax.Enabled = False
        butpreviewthorax.Enabled = False
        cmbjenisthorax.Enabled = False

        cmbjenisthorax.SelectedIndex = -1
        txthoraxcor.ResetText()
        txthoraxpulmo.ResetText()
        txthoraxsinus.ResetText()
        txthoraxskeletal.ResetText()
        txthoraxkesimpulan.ResetText()
        dtthorax.Value = DateAndTime.Now
        txthoraxby.ResetText()
    End Sub

    Private Sub DisableTreadmill()
        txtreadmill.Enabled = False
        butsavetreadmill.Enabled = False
        butprinttreadmill.Enabled = False

        txtreadmill.ResetText()
        dttreadmill.Value = DateAndTime.Now
        txtreadmillby.ResetText()
    End Sub

    Private Sub DisableSpiro()
        txspiro.Enabled = False
        butsavespiro.Enabled = False
        butprintspiro.Enabled = False

        txspiro.ResetText()
        dtspiro.Value = DateAndTime.Now
        txspiroby.ResetText()
    End Sub

    Private Sub RefreshItem(ByVal Tcmb As System.Windows.Forms.ComboBox)
        If (Tcmb.Items.Item(0) <> "") Then
            Tcmb.Items.RemoveAt(0)
        End If
        Tcmb.ResetText()
    End Sub

    Private Sub ClearFisikDetail()
        txriwayat.ResetText()
        TextBoxTinggiBadan.ResetText()
        TextBoxBeratBadan.ResetText()
        TextBoxIndeksMedik.ResetText()
        TextBoxSuhu.ResetText()
        TextBoxDetakNadi.ResetText()
        TextBoxSistole.ResetText()
        TextBoxDiastole.ResetText()
        TextBoxNafas.ResetText()
        txsimpul.ResetText()
        txsaranfisik.ResetText()
        RefreshItem(cmbkesadaran)
        RefreshItem(cmbkepala)
        txkepala.ResetText()
        RefreshItem(cmbrambut)
        txrambut.ResetText()
        RefreshItem(cmbmuka)
        txmuka.ResetText()
        RefreshItem(cmbmata)
        txmata.ResetText()
        RefreshItem(cmbbutawarna)
        txbutwarna.ResetText()
        txvisuskacamata.ResetText()
        txvisuskacamata2.ResetText()
        txvisustanpakacamata.ResetText()
        txvisustanpakacamata2.ResetText()
        txkoreksiakhir.ResetText()
        RefreshItem(cmbtelinga)
        txtelinga.ResetText()
        RefreshItem(cmbhidung)
        txhidung.ResetText()

        RefreshItem(cmbmulut)

        txmulut.ResetText()
        RefreshItem(cmbgigi)
        txgigi.ResetText()
        RefreshItem(cmblidah)
        txlidah.ResetText()
        RefreshItem(cmbtenggorokan)
        txtenggorokan.ResetText()
        RefreshItem(cmbleher)
        txleher.ResetText()
        RefreshItem(cmbdada)
        txdada.ResetText()
        RefreshItem(ComboBoxFisikPerut)
        TextBoxFisikPerut.ResetText()
        RefreshItem(ComboBoxFisikRectalToucher)
        TextBoxFisikRectalToucher.ResetText()
        RefreshItem(cmbintegumen)
        txintegumen.ResetText()
        RefreshItem(cmbekstemitas)
        txekstemitas.ResetText()
        RefreshItem(cmbturgor)

        RefreshItem(cmbrs)
        RefreshItem(cmbobat)
        RefreshItem(cmbnarkoba)
        RefreshItem(cmbsehat)

        RefreshItem(cmbrokok)
        RefreshItem(cmbalkohol)
        RefreshItem(cmbkopi)
        RefreshItem(cmbpolamakan)
        RefreshItem(cmbistirahat)
        RefreshItem(cmbolahraga)

        RefreshItem(cmbhepatitis)
        RefreshItem(cmbtht)
        RefreshItem(cmbtbc)
        RefreshItem(cmbanorexia)
        RefreshItem(cmbmalaria)
        RefreshItem(cmbkulit)

        RefreshItem(cmbtypoid)
        RefreshItem(cmbbbturun)
        RefreshItem(cmbhernia)
        RefreshItem(cmbsakitjantung)
        RefreshItem(cmbambien)
        RefreshItem(cmbhipertensi)

        RefreshItem(cmbkencing)
        RefreshItem(cmbvertigo)
        RefreshItem(cmbepilepsi)
        RefreshItem(cmbpingsan)
        RefreshItem(cmbgastritis)
        RefreshItem(cmbpusing)
        RefreshItem(cmbdiabetes)
        RefreshItem(cmboperasi)

        InsertNewItemComboSQL("SELECT StrValue FROM MsConfig WHERE ConfigName like '%fisik%'", cmbfisiknewdr)
    End Sub

    Private Sub EnableUSG()
        txusg.Enabled = True
        butsaveusg.Enabled = True
        butprintusg.Enabled = True

        Dim Tbls As DataTable = ReadSQL("SELECT * FROM TransaksiLabHasilLain WHERE [NoUrut]='" & TextBoxNoTransaksi.Text & "'")
        If Tbls.Rows.Count > 0 Then
            Dim Trow As DataRow = Tbls.Rows(0)
            If IsDBNull(Trow("usg")) = False Then txusg.Text = Trow("usg")
        End If
    End Sub

    Private Sub EnableAudio()
        txaudiometri.Enabled = True
        butsaveaudio.Enabled = True
        butprintaudio.Enabled = True

        Dim Tbls As DataTable = ReadSQL("SELECT * FROM TransaksiLabHasilLain WHERE [NoUrut]='" & TextBoxNoTransaksi.Text & "'")
        If Tbls.Rows.Count > 0 Then
            Dim Trow As DataRow = Tbls.Rows(0)
            If IsDBNull(Trow("Audio")) = False Then txaudiometri.Text = Trow("Audio")
            If IsDBNull(Trow("AudioDate")) = False Then dtaudio.Value = Trow("AudioDate")
            If IsDBNull(Trow("AudioBy")) = False Then txaudioby.Text = Trow("AudioBy")
        End If
    End Sub

    Private Sub EnableFisikNew2()
        gridfisiknew.Enabled = True
        butfisiknewsave.Enabled = True
        butfisiknewprint.Enabled = True
        butfisiknewpreview.Enabled = True
        ClearFisikDetail()
        setdatefisik()
        LoadFisikDetail()
    End Sub

    Private Sub setdatefisik()
        dtkapannarkoba.Value = "01-01-1900"
        dtkapanoperasi.Value = "01-01-1900"
        dtkapanrs.Value = "01-01-1900"

        dthepatitis.Value = "01-01-1900"
        dttbc.Value = "01-01-1900"
        dthernia.Value = "01-01-1900"
        dtjantung.Value = "01-01-1900"
        dthipertensi.Value = "01-01-1900"
        dtepilepsi.Value = "01-01-1900"
        dtdiabetes.Value = "01-01-1900"
    End Sub

    Private Sub GetResult(ByVal Tcmb As System.Windows.Forms.ComboBox, ByVal Thasil As String)
        Dim key As Integer = 0

        Dim count As Integer = Tcmb.Items.Count

        For index As Integer = 0 To count - 1
            If (Tcmb.Items.Item(index) = Thasil) Then
                Tcmb.Text = Thasil
                key = 1
            End If
        Next

        If (key = 0) Then
            Tcmb.Items.Insert(0, Thasil)
            Tcmb.Text = Thasil
            'Tcmb.SelectedIndex = 10
            'ListBox1.Items.Add(ComboBox1.Items(index))
            'ComboBox1.Items.RemoveAt(index)
        End If
    End Sub

    Private Sub LoadFisikDetail()
        Dim Tbls As DataTable = ReadSQL("SELECT a.fisiknourut, a.result, a.Dimana, a.Kenapa, a.Jenis, a.Kapan FROM transaksilabfisik a, transaksilab b WHERE a.nourut='" & TextBoxNoTransaksi.Text & "' AND a.nourut=b.nourut")
        For Each Trow As DataRow In Tbls.Rows
            If Trow("fisiknourut") = txriwayat.Tag.ToString Then txriwayat.Text = Trow("result") : GoTo GoBackthis
            If Trow("fisiknourut") = TextBoxTinggiBadan.Tag.ToString Then TextBoxTinggiBadan.Text = Trow("result") : GoTo GoBackthis
            If Trow("fisiknourut") = TextBoxBeratBadan.Tag.ToString Then TextBoxBeratBadan.Text = Trow("result") : GoTo GoBackthis
            If Trow("fisiknourut") = TextBoxSuhu.Tag.ToString Then TextBoxSuhu.Text = Trow("result") : GoTo GoBackthis
            If Trow("fisiknourut") = TextBoxDetakNadi.Tag.ToString Then TextBoxDetakNadi.Text = Trow("result") : GoTo GoBackthis

            If Trow("fisiknourut") = TextBoxSistole.Tag.ToString Then
                Dim TsplitTekanan() As String = Trow("result").ToString.Split("/")
                TextBoxSistole.Text = TsplitTekanan(0).ToString.Trim
                TextBoxDiastole.Text = TsplitTekanan(1).ToString.Trim
                GoTo GoBackthis
            End If

            If Trow("fisiknourut") = TextBoxNafas.Tag.ToString Then TextBoxNafas.Text = Trow("result") : GoTo GoBackthis
            If Trow("fisiknourut") = txsimpul.Tag.ToString Then txsimpul.Text = Trow("result") : GoTo GoBackthis
            If Trow("fisiknourut") = txsaranfisik.Tag.ToString Then txsaranfisik.Text = Trow("result") : GoTo GoBackthis
            If Trow("fisiknourut") = cmbfisiknewdr.Tag.ToString Then cmbfisiknewdr.Text = Trow("result") : GoTo GoBackthis
            If Trow("fisiknourut") = cmbkesadaran.Tag.ToString Then GetResult(cmbkesadaran, Trow("result")) : GoTo GoBackthis
            If Trow("fisiknourut") = txkoreksiakhir.Tag.ToString Then txkoreksiakhir.Text = Trow("result")
            If Trow("fisiknourut") = cmbturgor.Tag.ToString Then GetResult(cmbturgor, Trow("result")) : GoTo GoBackthis
            If Trow("fisiknourut") = cmbsehat.Tag.ToString Then GetResult(cmbsehat, Trow("result")) : GoTo GoBackthis
            If Trow("fisiknourut") = cmbrokok.Tag.ToString Then GetResult(cmbrokok, Trow("result")) : GoTo GoBackthis
            If Trow("fisiknourut") = cmbalkohol.Tag.ToString Then GetResult(cmbalkohol, Trow("result")) : GoTo GoBackthis
            If Trow("fisiknourut") = cmbkopi.Tag.ToString Then GetResult(cmbkopi, Trow("result")) : GoTo GoBackthis
            If Trow("fisiknourut") = cmbpolamakan.Tag.ToString Then GetResult(cmbpolamakan, Trow("result")) : GoTo GoBackthis
            If Trow("fisiknourut") = cmbistirahat.Tag.ToString Then GetResult(cmbistirahat, Trow("result")) : GoTo GoBackthis
            If Trow("fisiknourut") = cmbolahraga.Tag.ToString Then GetResult(cmbolahraga, Trow("result")) : GoTo GoBackthis
            If Trow("fisiknourut") = cmbtht.Tag.ToString Then GetResult(cmbtht, Trow("result")) : GoTo GoBackthis
            If Trow("fisiknourut") = cmbanorexia.Tag.ToString Then GetResult(cmbanorexia, Trow("result")) : GoTo GoBackthis
            If Trow("fisiknourut") = cmbmalaria.Tag.ToString Then GetResult(cmbmalaria, Trow("result")) : GoTo GoBackthis
            If Trow("fisiknourut") = cmbkulit.Tag.ToString Then GetResult(cmbkulit, Trow("result")) : GoTo GoBackthis
            If Trow("fisiknourut") = cmbtypoid.Tag.ToString Then GetResult(cmbtypoid, Trow("result")) : GoTo GoBackthis
            If Trow("fisiknourut") = cmbbbturun.Tag.ToString Then GetResult(cmbbbturun, Trow("result")) : GoTo GoBackthis
            If Trow("fisiknourut") = cmbambien.Tag.ToString Then GetResult(cmbambien, Trow("result")) : GoTo GoBackthis
            If Trow("fisiknourut") = cmbkencing.Tag.ToString Then GetResult(cmbkencing, Trow("result")) : GoTo GoBackthis
            If Trow("fisiknourut") = cmbvertigo.Tag.ToString Then GetResult(cmbvertigo, Trow("result")) : GoTo GoBackthis
            If Trow("fisiknourut") = cmbpingsan.Tag.ToString Then GetResult(cmbpingsan, Trow("result")) : GoTo GoBackthis
            If Trow("fisiknourut") = cmbgastritis.Tag.ToString Then GetResult(cmbgastritis, Trow("result")) : GoTo GoBackthis
            If Trow("fisiknourut") = cmbpusing.Tag.ToString Then GetResult(cmbpusing, Trow("result")) : GoTo GoBackthis

            If Trow("fisiknourut") = cmbtelinga.Tag.ToString Then GetResult(cmbtelinga, Trow("result")) : GoTo GoBackthis
            If Trow("fisiknourut") = cmbkepala.Tag.ToString Then GetResult(cmbkepala, Trow("result")) : GoTo GoBackthis
            If Trow("fisiknourut") = cmbrambut.Tag.ToString Then GetResult(cmbrambut, Trow("result")) : GoTo GoBackthis
            If Trow("fisiknourut") = cmbmuka.Tag.ToString Then GetResult(cmbmuka, Trow("result")) : GoTo GoBackthis
            If Trow("fisiknourut") = cmbmata.Tag.ToString Then GetResult(cmbmata, Trow("result")) : GoTo GoBackthis
            If Trow("fisiknourut") = cmbbutawarna.Tag.ToString Then GetResult(cmbbutawarna, Trow("result")) : GoTo GoBackthis
            If Trow("fisiknourut") = cmbhidung.Tag.ToString Then GetResult(cmbhidung, Trow("result")) : GoTo GoBackthis
            If Trow("fisiknourut") = cmbmulut.Tag.ToString Then GetResult(cmbmulut, Trow("result")) : GoTo GoBackthis
            If Trow("fisiknourut") = cmbgigi.Tag.ToString Then GetResult(cmbgigi, Trow("result")) : GoTo GoBackthis
            If Trow("fisiknourut") = cmblidah.Tag.ToString Then GetResult(cmblidah, Trow("result")) : GoTo GoBackthis
            If Trow("fisiknourut") = cmbtenggorokan.Tag.ToString Then GetResult(cmbtenggorokan, Trow("result")) : GoTo GoBackthis
            If Trow("fisiknourut") = cmbleher.Tag.ToString Then GetResult(cmbleher, Trow("result")) : GoTo GoBackthis
            If Trow("fisiknourut") = cmbdada.Tag.ToString Then GetResult(cmbdada, Trow("result")) : GoTo GoBackthis
            If Trow("fisiknourut") = ComboBoxFisikPerut.Tag.ToString Then GetResult(ComboBoxFisikPerut, Trow("result")) : GoTo GoBackthis
            If Trow("fisiknourut") = ComboBoxFisikRectalToucher.Tag.ToString Then GetResult(ComboBoxFisikRectalToucher, Trow("result")) : GoTo GoBackthis
            If Trow("fisiknourut") = cmbintegumen.Tag.ToString Then GetResult(cmbintegumen, Trow("result")) : GoTo GoBackthis
            If Trow("fisiknourut") = cmbekstemitas.Tag.ToString Then GetResult(cmbekstemitas, Trow("result")) : GoTo GoBackthis

            'Set Date
            If Trow("fisiknourut") = cmboperasi.Tag.ToString Then
                GetResult(cmboperasi, Trow("result"))
                If Trow("result").ToString.Trim = "Ya" Then
                    dtkapanoperasi.Value = Trow("Kapan")
                    txdimanaoperasi.Text = Trow("Dimana")
                    txkenapaoperasi.Text = Trow("Kenapa")
                End If
                GoTo GoBackthis
            End If

            If Trow("fisiknourut") = cmbrs.Tag.ToString Then
                GetResult(cmbrs, Trow("result"))
                If Trow("result").ToString.Trim = "Ya" Then
                    dtkapanrs.Value = Trow("Kapan")
                    txdimanars.Text = Trow("Dimana")
                    txkenapars.Text = Trow("Kenapa")
                End If
                GoTo GoBackthis
            End If

            If Trow("fisiknourut") = cmbobat.Tag.ToString Then
                GetResult(cmbobat, Trow("result"))
                If Trow("result").ToString.Trim = "Ya" Then
                    txpenyakitobat.Text = Trow("Jenis")
                End If
                GoTo GoBackthis
            End If

            If Trow("fisiknourut") = cmbnarkoba.Tag.ToString Then
                GetResult(cmbnarkoba, Trow("result"))
                If Trow("result").ToString.Trim = "Ya" Then
                    dtkapannarkoba.Value = Trow("Kapan")
                    txjenisnarkoba.Text = Trow("Jenis")
                End If
                GoTo GoBackthis
            End If

            If Trow("fisiknourut") = cmbhepatitis.Tag.ToString Then
                GetResult(cmbhepatitis, Trow("result"))
                If Trow("result").ToString.Trim = "Ya" Then
                    dthepatitis.Value = Trow("Kapan")
                End If
                GoTo GoBackthis
            End If

            If Trow("fisiknourut") = cmbtbc.Tag.ToString Then
                GetResult(cmbtbc, Trow("result"))
                If Trow("result").ToString.Trim = "Ya" Then
                    dttbc.Value = Trow("Kapan")
                End If
                GoTo GoBackthis
            End If

            If Trow("fisiknourut") = cmbhernia.Tag.ToString Then
                GetResult(cmbhernia, Trow("result"))
                If Trow("result").ToString.Trim = "Ya" Then
                    dthernia.Value = Trow("Kapan")
                End If
                GoTo GoBackthis
            End If

            If Trow("fisiknourut") = cmbsakitjantung.Tag.ToString Then
                GetResult(cmbsakitjantung, Trow("result"))
                If Trow("result").ToString.Trim = "Ya" Then
                    dtjantung.Value = Trow("Kapan")
                End If
                GoTo GoBackthis
            End If

            If Trow("fisiknourut") = cmbhipertensi.Tag.ToString Then
                GetResult(cmbhipertensi, Trow("result"))
                If Trow("result").ToString.Trim = "Ya" Then
                    dthipertensi.Value = Trow("Kapan")
                End If
                GoTo GoBackthis
            End If

            If Trow("fisiknourut") = cmbepilepsi.Tag.ToString Then
                GetResult(cmbepilepsi, Trow("result"))
                If Trow("result").ToString.Trim = "Ya" Then
                    dtepilepsi.Value = Trow("Kapan")
                End If
                GoTo GoBackthis
            End If

            If Trow("fisiknourut") = cmbdiabetes.Tag.ToString Then
                GetResult(cmbdiabetes, Trow("result"))
                If Trow("result").ToString.Trim = "Ya" Then
                    dtdiabetes.Value = Trow("Kapan")
                End If
                GoTo GoBackthis
            End If

GoBackthis:
        Next

        Dim tagvisusmata As String = ReadSQLNIK("SELECT fisiknourut FROM TransaksiLabFisik WHERE FisikNoUrut=3012 AND NoUrut='" & TextBoxNoTransaksi.Text & "'")
        Dim tagvisusmata2 As String = ReadSQLNIK("SELECT fisiknourut FROM TransaksiLabFisik WHERE FisikNoUrut=3014 AND NoUrut='" & TextBoxNoTransaksi.Text & "'")
        Dim var1mata As String = ""
        Dim var2mata As String = ""
        If tagvisusmata <> "-" Then
            var1mata = ReadSQLNIK("SELECT Result FROM TransaksiLabFisik WHERE FisikNoUrut='" & txvisuskacamata.Tag.ToString & "' AND NoUrut='" & TextBoxNoTransaksi.Text & "'")
            var2mata = ReadSQLNIK("SELECT Result FROM TransaksiLabFisik WHERE FisikNoUrut='" & txvisustanpakacamata.Tag.ToString & "' AND NoUrut='" & TextBoxNoTransaksi.Text & "'")

            Dim Tsplit() As String = var1mata.ToString.Split(",")
            Dim Tsplit2() As String = var2mata.ToString.Split(",")

            If var1mata.Trim <> "" Then
                txvisuskacamata.Text = Trim(Tsplit(0))
                If var1mata.Contains(",") = True Then
                    txvisuskacamata2.Text = Trim(Tsplit(1))
                End If
            End If

            If var2mata.Trim <> "" Then
                txvisustanpakacamata.Text = Trim(Tsplit2(0))
                If var2mata.Contains(",") = True Then
                    txvisustanpakacamata2.Text = Trim(Tsplit2(1))
                End If
            End If

            cmbvisustanpakacamata.SelectedIndex = 0
            cmbvisusmata.SelectedIndex = 0
            txvisuskacamata.Tag = 3012
            txvisustanpakacamata.Tag = 3013
        ElseIf tagvisusmata2 <> "-" Then
            var1mata = ReadSQLNIK("SELECT Result FROM TransaksiLabFisik WHERE FisikNoUrut=3014 AND NoUrut='" & TextBoxNoTransaksi.Text & "'")
            var2mata = ReadSQLNIK("SELECT Result FROM TransaksiLabFisik WHERE FisikNoUrut=3015 AND NoUrut='" & TextBoxNoTransaksi.Text & "'")

            Dim Tsplit() As String = var1mata.ToString.Split(",")
            Dim Tsplit2() As String = var2mata.ToString.Split(",")

            If var1mata.Trim <> "" Then
                txvisuskacamata.Text = Trim(Tsplit(0))
                If var1mata.Contains(",") = True Then
                    txvisuskacamata2.Text = Trim(Tsplit(1))
                End If
            End If

            If var2mata.Trim <> "" Then
                txvisustanpakacamata.Text = Trim(Tsplit2(0))
                If var2mata.Contains(",") = True Then
                    txvisustanpakacamata2.Text = Trim(Tsplit2(1))
                End If
            End If

            cmbvisustanpakacamata.SelectedIndex = 1
            cmbvisusmata.SelectedIndex = 1
            txvisuskacamata.Tag = 3014
            txvisustanpakacamata.Tag = 3015
        End If

        'Hitung BMI
        If TextBoxTinggiBadan.Text <> "" And TextBoxBeratBadan.Text <> "" And TextBoxTinggiBadan.Text <> "-" And TextBoxBeratBadan.Text <> "-" Then TextBoxIndeksMedik.Text = Math.Round(CDbl(TextBoxBeratBadan.Text / (TextBoxTinggiBadan.Text * TextBoxTinggiBadan.Text) * 10000), 1) Else TextBoxIndeksMedik.Text = "0"
    End Sub

    Private Sub EnableECG()
        txhasilecg.Enabled = True
        txecgtekanan.Enabled = True
        butsaveecg.Enabled = True
        butprintecg.Enabled = True
        butpreviewecg.Enabled = True

        Dim Tbls As DataTable = ReadSQL("SELECT * FROM TransaksiLabHasilLain WHERE [NoUrut]='" & TextBoxNoTransaksi.Text & "'")
        If Tbls.Rows.Count > 0 Then
            Dim Trow As DataRow = Tbls.Rows(0)
            If IsDBNull(Trow("Tekanan")) = False Then txecgtekanan.Text = Trow("Tekanan")
            If IsDBNull(Trow("DiagnosisECG")) = False Then txhasilecg.Text = Trow("DiagnosisECG")
            If IsDBNull(Trow("ECGDate")) = False Then dtthorax.Value = Trow("ECGDate")
            If IsDBNull(Trow("ECGBy")) = False Then txthoraxby.Text = Trow("ECGBy")
        End If

    End Sub

    Private Sub EnableThorax()
        txthoraxcor.Enabled = True
        txthoraxpulmo.Enabled = True
        txthoraxsinus.Enabled = True
        txthoraxskeletal.Enabled = True
        txthoraxkesimpulan.Enabled = True
        butsavethorax.Enabled = True
        butprintthorax.Enabled = True
        butpreviewthorax.Enabled = True
        cmbjenisthorax.Enabled = True

        InsertNewItemComboSQL("SELECT ValueThorax FROM MasterNilaiHasilThorax ORDER BY ValueThorax ASC", cmbjenisthorax)
        cmbjenisthorax.SelectedIndex = -1

        Dim Tbls As DataTable = ReadSQL("SELECT * FROM TransaksiLabHasilLain WHERE [NoUrut]='" & TextBoxNoTransaksi.Text & "'")
        If Tbls.Rows.Count > 0 Then
            Dim Trow As DataRow = Tbls.Rows(0)
            If IsDBNull(Trow("Cor")) = False Then txthoraxcor.Text = Trow("Cor")
            If IsDBNull(Trow("Pulmo")) = False Then txthoraxpulmo.Text = Trow("Pulmo")
            If IsDBNull(Trow("Sinus")) = False Then txthoraxsinus.Text = Trow("Sinus")
            If IsDBNull(Trow("Skeletal")) = False Then txthoraxskeletal.Text = Trow("Skeletal")
            If IsDBNull(Trow("Kesimpulan")) = False Then txthoraxkesimpulan.Text = Trow("Kesimpulan")
            If IsDBNull(Trow("ThoraxDate")) = False Then dtthorax.Value = Trow("ThoraxDate")
            If IsDBNull(Trow("ThoraxBy")) = False Then txthoraxby.Text = Trow("ThoraxBy")
            If IsDBNull(Trow("DrThorax")) = False Then drthorax.Text = Trow("DrThorax")
        End If
    End Sub

    Private Sub EnableTreadmill()
        txtreadmill.Enabled = True
        butsavetreadmill.Enabled = True
        butprinttreadmill.Enabled = True

        Dim Tbls As DataTable = ReadSQL("SELECT * FROM TransaksiLabHasilLain WHERE [NoUrut]='" & TextBoxNoTransaksi.Text & "'")
        If Tbls.Rows.Count > 0 Then
            Dim Trow As DataRow = Tbls.Rows(0)
            If IsDBNull(Trow("treadmill")) = False Then txtreadmill.Text = Trow("treadmill")
            If IsDBNull(Trow("Treadmilldate")) = False Then dttreadmill.Value = Trow("Treadmilldate")
            If IsDBNull(Trow("Treadmillby")) = False Then txtreadmillby.Text = Trow("Treadmillby")
        End If
    End Sub

    Private Sub EnableSipro()
        txspiro.Enabled = True
        butsavespiro.Enabled = True
        butprintspiro.Enabled = True

        Dim Tbls As DataTable = ReadSQL("SELECT * FROM TransaksiLabHasilLain WHERE [NoUrut]='" & TextBoxNoTransaksi.Text & "'")
        If Tbls.Rows.Count > 0 Then
            Dim Trow As DataRow = Tbls.Rows(0)
            If IsDBNull(Trow("Spirometri")) = False Then txspiro.Text = Trow("Spirometri")
            If IsDBNull(Trow("Spirometridate")) = False Then dtspiro.Value = Trow("Spirometridate")
            If IsDBNull(Trow("Spirometriby")) = False Then txspiroby.Text = Trow("Spirometriby")
        End If
    End Sub

    Private Sub SetUrutan()
        Dim Tbls As DataTable = ReadSQL("SELECT a.TransLabIDDetail,TransLabID,a.TindakanID,a.NamaTindakan,a.JenisTindakan,a.Urutan as UrutID,b.Urutan FROM transaksilabdetail a LEFT JOIN masterlab b on a.TindakanID=b.TindakanID  WHERE TransLabID='" & buttindakanid.Text & "'")
        For Each Trow As DataRow In Tbls.Rows
            WriteSQL("update transaksilabdetail set Urutan='" & Trow("Urutan") & "' WHERE TransLabIDDetail='" & Trow("TransLabIDDetail") & "' AND TransLabID='" & Trow("TransLabID") & "' AND TindakanID='" & Trow("TindakanID") & "'", 4)
        Next

    End Sub

    Public Sub SetClearGrid()
        SetUrutan()
        Dim Tlab As DataTable = ReadSQL(" SELECT a.TransLabID,a.TransLabIDDetail,a.TindakanID,a.NamaTindakan,a.JenisTindakan,b.NoUrut,b.GroupID,b.DetailKet,b.Result,b.Satuan,b.Pria,b.Wanita,b.Keterangan,m.UrutanJenisID,a.Urutan, b.saran as 'Saran' " & _
                                        " FROM transaksilabdetail a LEFT JOIN TransaksiLabResult b on a.TransLabIDDetail =b.TransLabIDDetail AND a.TindakanID=b.TindakanID LEFT JOIN MasterJenisTindakan m on m.JenisTindakan=a.JenisTindakan WHERE a.TransLabID='" & buttindakanid.Text & "' " & _
                                        " order by  m.UrutanJenisID,a.Urutan,b.TindakanID,b.NoUrut,a.TransLabIDDetail,a.TindakanID,b.GroupID,b.DetailKet ")

        For Each Tcol As DataColumn In Tlab.Columns
            Tcol.ReadOnly = True
        Next

        Tlab.Columns("Pria").ReadOnly = False
        Tlab.Columns("Wanita").ReadOnly = False

        Tlab.Columns("Result").ReadOnly = False
        Tlab.Columns("Saran").ReadOnly = False
        Tlab.Columns("Satuan").ReadOnly = False
        Tlab.Columns("Keterangan").ReadOnly = False

        'TEMPAT UNTUK PEMISAHAN DATA YANG CETAK SENDIRI DENGAN CETAKAN LAINNYA
        ClearTextDetailSelainLab()

        For Each Trow As DataRow In Tlab.Rows
            If Strings.LCase(Trow("NamaTindakan").ToString).Contains("hematologi lengkap") = True Or Strings.LCase(Trow("NamaTindakan").ToString).Contains("thorax") = True Or Strings.LCase(Trow("NamaTindakan").ToString).Contains("ecg") = True Or Strings.LCase(Trow("NamaTindakan").ToString).Contains("audiometri") = True Or Strings.LCase(Trow("NamaTindakan").ToString).Contains("fisik") = True Or Strings.LCase(Trow("NamaTindakan").ToString).Contains("usg") = True Or Strings.LCase(Trow("NamaTindakan").ToString).Contains("treadmill") = True Or Strings.LCase(Trow("NamaTindakan").ToString).Contains("spirometri") = True Then

                If Strings.LCase(Trow("NamaTindakan").ToString).Contains("thorax") Then
                    EnableThorax()
                    If IsDBNull(Trow("Result")) = True Then Trow("Result") = "Hasil Terlampir"
                ElseIf Strings.LCase(Trow("NamaTindakan").ToString).Contains("ecg") Then
                    EnableECG()
                    If IsDBNull(Trow("Result")) = True Then Trow("Result") = "Hasil Terlampir"
                ElseIf Strings.LCase(Trow("NamaTindakan").ToString).Contains("audiometri") Then
                    EnableAudio()
                    If IsDBNull(Trow("Result")) = True Then Trow("Result") = "Hasil Terlampir"
                ElseIf Strings.LCase(Trow("NamaTindakan").ToString).Contains("fisik") Then
                    'EnableFisik()
                    EnableFisikNew2()
                    If IsDBNull(Trow("Result")) = True Then Trow("Result") = "Hasil Terlampir"
                ElseIf Strings.LCase(Trow("NamaTindakan").ToString).Contains("usg") Then
                    EnableUSG()
                    If IsDBNull(Trow("Result")) = True Then Trow("Result") = "Hasil Terlampir"
                ElseIf Strings.LCase(Trow("NamaTindakan").ToString).Contains("treadmill") Then
                    EnableTreadmill()
                    If IsDBNull(Trow("Result")) = True Then Trow("Result") = "Hasil Terlampir"
                ElseIf Strings.LCase(Trow("NamaTindakan").ToString).Contains("spirometri") Then
                    EnableSipro()
                    If IsDBNull(Trow("Result")) = True Then Trow("Result") = "Hasil Terlampir"
                End If

                'Set button hematologi lengkap
                If Strings.LCase(Trow("NamaTindakan").ToString).Contains("hematologi lengkap") Then
                    GroupBoxDL.Visible = True
                    exportpdfDL.Visible = True
                End If
            End If
        Next

        gridlab.DataSource = Tlab
        GridView2.Columns("TransLabIDDetail").Visible = False
        GridView2.Columns("TindakanID").Visible = False
        GridView2.Columns("TransLabID").Visible = False
        GridView2.Columns("Urutan").Visible = False
        GridView2.Columns("UrutanJenisID").Visible = False

        If TextBoxJenisKelamin.Text = "L" Then
            GridView2.Columns("Pria").Visible = True
            GridView2.Columns("Wanita").Visible = False
        ElseIf TextBoxJenisKelamin.Text = "P" Then
            GridView2.Columns("Pria").Visible = False
            GridView2.Columns("Wanita").Visible = True
        End If

        GridView2.SortInfo.ClearAndAddRange(New GridColumnSortInfo() _
                                            {New GridColumnSortInfo(GridView2.Columns("JenisTindakan"), DevExpress.Data.ColumnSortOrder.Ascending) _
                                             }, 1)
        GridView2.ExpandAllGroups()
        TextBoxNoTransaksi.Focus()
    End Sub

    Public Sub LoadAdminLab(ByRef TxID As String, ByRef Txnourut As String, ByRef TxFROM As String)
        Dim Barcode As String = ReadSQLNIK("SELECT case when SendKeu = 1 then 'Done' else 'Not Done' end as barcode FROM TransaksiLab WHERE NoUrut = '" & Txnourut & "' AND TransLabID = '" & TxID & "'")

        If Barcode = "Done" Then
            Dim Tbls As New DataTable

            If TxFROM <> "empty" Then
                Tbls = ReadSQL("SELECT CaraAmbil, IDInternet, TglLab, Kesimpulan, Saran, DokterRequest, ClosedTransaksi, Status, ChangeDate, ChangeBy, TglInputHasil, UserInputHasil FROM TransaksiLab WHERE TransLabID='" & TxID & "' AND NoUrut='" & Txnourut & "'")
            Else
                Tbls = ReadSQL("SELECT a.CaraAmbil, a.IDInternet, a.TglLab, a.Kesimpulan, a.Saran, a.DokterRequest, a.ClosedTransaksi, " & _
                "a.Status, a.ChangeDate, a.ChangeBy, a.TglInputHasil, a.UserInputHasil, b.DomisiliAlamat " & _
                "FROM TransaksiLab a LEFT JOIN MasterPasien b on a.IDInternet = b.NoRekamMedis " & _
                "WHERE TransLabID='" & TxID & "' AND NoUrut='" & Txnourut & "'")
            End If

            SetClearHeader()

            Dim Trow As DataRow = Tbls.Rows(0)
            If TxFROM = "empty" Then
                txalamat.Text = Trow("DomisiliAlamat")
            End If

            Dim company As String = ReadSQLNIK("SELECT NoJenisBayar FROM transaksilabbayar WHERE translabid = " & TxID & " AND JenisBayar = 'TAGIHAN'")
            Dim Tsplit() As String = company.ToString.Split("-")
            If Tsplit(0).ToString.Trim = "" Then
                txpenagihan.Text = "PASIEN UMUM"
                txcodepenagihan.Text = "-"
            Else
                txpenagihan.Text = Tsplit(0).ToString.Trim
                txcodepenagihan.Text = Tsplit(1).ToString.Trim
            End If

            TextBoxNoTransaksi.Text = Txnourut
            TextBoxNoTransaksi.ReadOnly = True
            buttindakanid.Text = TxID
            LoadLabPasien(Trow("IDInternet"))
            DateTimeTanggalTransaksi.Value = Trow("TglLab")
            If IsDBNull(Trow("Kesimpulan")) = False Then txketall.Text = Trow("Kesimpulan") Else txketall.ResetText()
            If IsDBNull(Trow("Saran")) = False Then txsaranall.Text = Trow("Saran") Else txsaranall.ResetText()
            If IsDBNull(Trow("CaraAmbil")) = False Then txcaraambil.Text = Trow("CaraAmbil") Else txcaraambil.ResetText()
            txpraktekid.Text = Trow("DokterRequest").ToString.Trim
            butdokter.Text = ReadSQLNIK("SELECT DrNama FROM MasterDokterKirim WHERE IdKirim in ( SELECT IdKirim FROM MasterDokterTempatPraktek WHERE IdPraktek='" & txpraktekid.Text & "')")

            If IsDBNull(Trow("TglInputHasil")) = False Then chkclosed.Checked = True Else chkclosed.Checked = False

            If Trow("Status").ToString.Trim = "CHECK" Then
                PrintSementaraToolStripMenuItem.Enabled = True
                PreviewHasilLabToolStripMenuItem.Enabled = True
                PrintSuratKetToolStripMenuItem.Enabled = True
                SendiToolStripMenuItem.Enabled = True
                CetakLabelMenuStrip.Enabled = True
                DownloadHasilOnlineToolStripMenuItem.Enabled = True
                DownloadHasilToolStripMenuItem.Enabled = True
                StartProcessToolStripMenuItem.Enabled = False
                ResendToMesinToolStripMenuItem.Enabled = True
            ElseIf Trow("Status").ToString.Trim = "SEND" Then
                PrintSementaraToolStripMenuItem.Enabled = False
                PreviewHasilLabToolStripMenuItem.Enabled = False

                GroupBoxDL.Visible = False
                exportpdfDL.Visible = False

                PrintSuratKetToolStripMenuItem.Enabled = False
                SendiToolStripMenuItem.Enabled = False
                CetakLabelMenuStrip.Enabled = False
                DownloadHasilOnlineToolStripMenuItem.Enabled = False
                DownloadHasilToolStripMenuItem.Enabled = False
                ResendToMesinToolStripMenuItem.Enabled = False
                StartProcessToolStripMenuItem.Enabled = False
                ResendToMesinToolStripMenuItem.Enabled = True
            ElseIf Trow("Status").ToString.Trim = "CLOSED" Then
                PrintSementaraToolStripMenuItem.Enabled = False
                PreviewHasilLabToolStripMenuItem.Enabled = False

                GroupBoxDL.Visible = False
                exportpdfDL.Visible = False

                PrintSuratKetToolStripMenuItem.Enabled = False
                SendiToolStripMenuItem.Enabled = False
                CetakLabelMenuStrip.Enabled = False
                DownloadHasilOnlineToolStripMenuItem.Enabled = False
                DownloadHasilToolStripMenuItem.Enabled = False
                ResendToMesinToolStripMenuItem.Enabled = False
                StartProcessToolStripMenuItem.Enabled = False
            ElseIf Trow("Status").ToString.Trim = "CETAK" Then
                PrintSementaraToolStripMenuItem.Enabled = True
                PreviewHasilLabToolStripMenuItem.Enabled = True
                PrintSuratKetToolStripMenuItem.Enabled = True
                SendiToolStripMenuItem.Enabled = True
                CetakLabelMenuStrip.Enabled = True
                DownloadHasilOnlineToolStripMenuItem.Enabled = True
                DownloadHasilToolStripMenuItem.Enabled = True
                StartProcessToolStripMenuItem.Enabled = False
                ResendToMesinToolStripMenuItem.Enabled = True
                StartProcessToolStripMenuItem.Enabled = False
            ElseIf Trow("Status").ToString.Trim = "TAKEIT" Then
                PrintSementaraToolStripMenuItem.Enabled = True
                PreviewHasilLabToolStripMenuItem.Enabled = True
                PrintSuratKetToolStripMenuItem.Enabled = True
                SendiToolStripMenuItem.Enabled = True
                CetakLabelMenuStrip.Enabled = True
                DownloadHasilOnlineToolStripMenuItem.Enabled = True
                DownloadHasilToolStripMenuItem.Enabled = True
                StartProcessToolStripMenuItem.Enabled = False
                ResendToMesinToolStripMenuItem.Enabled = True
            End If

            SetClearGrid()

            If IsDBNull(Trow("ChangeDate")) = False Then dtchanged.Value = Trow("ChangeDate")
            If IsDBNull(Trow("ChangeBy")) = False Then txchanged.Text = Trow("ChangeBy")

            If Utility.GetConfig("Mesin") = "No" Then
                DownloadHasilToolStripMenuItem.Enabled = False
                ResendToMesinToolStripMenuItem.Enabled = False
            End If

            butfindtindakanid.Enabled = False

            If CheckSQL("SELECT b.TindakanID FROM MasterLab a LEFT JOIN TransaksiLabDetail b on a.TindakanID = b.TindakanID WHERE a.SendQR = 1 AND b.TransLabID = '" & TxID & "'") = True And CekKoneksi("SHOW TABLES FROM " & DB_Poliklinik.Tdb & "", DB_Poliklinik) = True Then
                'Set QR Code
                Dim KodeBarcode As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='KodeBarcode'")
                Dim URLQR As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='URLQRHasil_Lab'")
                Dim txQR As String = URLQR & KodeBarcode & Txnourut & "_Hasil_Laboratorium"
                Dim Generator As New MessagingToolkit.Barcode.BarcodeEncoder
                Generator.BackColor = Color.Transparent
                Generator.LabelFont = New Font("Arial", 7, FontStyle.Regular)
                Generator.IncludeLabel = True

                QR_Code_Trans.Image = New Bitmap(Generator.Encode(MessagingToolkit.Barcode.BarcodeFormat.QRCode, txQR))
                QR_Code_Trans.SizeMode = PictureBoxSizeMode.StretchImage
            End If
        Else
            MsgBox("Cetak Barcode (No Urut : " & Txnourut & ") terlebih dahulu.")
            Exit Sub
        End If
    End Sub

    Public Sub LoadLabPasien(ByRef Txid As String)
        Dim Tbls As DataTable = ReadSQL("SELECT NoRekamMedis, Nama, TglLahir, JenisKelamin FROM MasterPasien WHERE NoRekamMedis='" & Txid & "'")
        Dim Trow As DataRow = Tbls.Rows(0)

        TextBoxNoRekamMedis.Text = Txid
        TextBoxNamaPasien.Text = Trow("Nama")
        TextBoxJenisKelamin.Text = Trow("JenisKelamin")
        DateTimeTanggalLahir.Value = Trow("TglLahir")
        TextBoxUmur.Text = Umur(DateTimeTanggalLahir.Value)
        TextBoxGelar.Text = Gelar(Year(Now()) - Year(DateTimeTanggalLahir.Value), TextBoxJenisKelamin.Text)
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        SetClearHeader()
        SetClearGrid()
    End Sub

    Private Sub LabAdmin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
        Me.MdiParent = PoliKlinik
        'SetFormHeightWeight(Me, 0.95, 0.8)
        Me.Dock = DockStyle.Fill
        setConnectionMesin()
        NewToolStripMenuItem.PerformClick()
        AutoTTD = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='AutoTTD'")
        'AutoTTD = "No"
    End Sub

    Function Checking() As Boolean
        Dim Tbls As DataTable = gridlab.DataSource
        Tbls.AcceptChanges()

        Dim I As Integer = 0
        For Each Trow As DataRow In Tbls.Rows
            If Trow("Result").ToString.Trim <> "" And Trow("Result").ToString.Trim <> "-" Then
                I = I + 1
            End If
        Next

        If I <= 0 Then
            MsgBox("Masukkan hasil lab terlebih dahulu.", MsgBoxStyle.Critical, "Warning!")
            Return False
        End If

        If txchanged.Text = "" Then
            MsgBox("Gunakan User yang sesuai pada system.")
            Return False
        End If

        Return True
    End Function

    Private Sub DownloadHasilToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DownloadHasilToolStripMenuItem.Click
        Dim Tdiff As Integer = Utility.GetConfig("MesinDiff")
        If Utility.GetConfig("DualMesin") = "Yes" Then
            OptionDialog.LoadOptionDialog(buttindakanid.Text, 0, "DownloadHasil")
            OptionDialog.ShowDialog()
        Else
            'Dim Tnourut As String = ReadSQLNIK("SELECT NoUrut FROM TransaksiLab WHERE TranslabID='" & buttindakanid.Text & "'")
            Dim Tnourut As String = TextBoxNoTransaksi.Text.Trim
            If buttindakanid.Text <> "" And Tdiff = 3 Then
                ResultMachine.LoadAdminLab(buttindakanid.Text, Tnourut, "Diff3", "Offline", "")
                ResultMachine.ShowDialog()
            Else
                ResultMachine.LoadAdminLab(buttindakanid.Text, Tnourut, "Diff5", "Offline", "")
                ResultMachine.ShowDialog()
            End If
        End If
    End Sub

    Public Sub startprocessing()
        Dim KodeBarcode As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='KodeBarcode'")
        Dim KodeBarcodeNoUrut As String = ""
        Dim Tdatstart As String = InputBox("Masukkan Barcode Reader", "StartSampling")
        Dim counttransid As String = Tdatstart.Length()
        Dim TempNoUrut As String = ""
        Dim TempTranslabID As String = ""

        If counttransid = 12 Then
            If Mid(Tdatstart.ToString.Trim, 7, 1) = "9" Then
                TempNoUrut = Strings.Left(DateAndTime.Now.Year, 2) & Strings.Left(Tdatstart, 6) & "M" & Strings.Right(Tdatstart, 5)
            ElseIf Mid(Tdatstart.ToString.Trim, 7, 1) = "8" Then
                TempNoUrut = Strings.Left(DateAndTime.Now.Year, 2) & Strings.Left(Tdatstart, 6) & "L" & Strings.Right(Tdatstart, 5)
            End If
        ElseIf counttransid = 15 Then
            KodeBarcodeNoUrut = Strings.Left(Tdatstart, 3)
            If KodeBarcode = KodeBarcodeNoUrut Then
                If Mid(Tdatstart.ToString.Trim, 10, 1) = "9" Then
                    TempNoUrut = Strings.Left(DateAndTime.Now.Year, 2) & Strings.Mid(Tdatstart, 4, 6) & "M" & Strings.Right(Tdatstart, 5)
                ElseIf Mid(Tdatstart.ToString.Trim, 10, 1) = "8" Then
                    TempNoUrut = Strings.Left(DateAndTime.Now.Year, 2) & Strings.Mid(Tdatstart, 4, 6) & "L" & Strings.Right(Tdatstart, 5)
                End If
            Else
                MsgBox("Lokasi yang tertera di Barcode tidak sesuai.", MsgBoxStyle.Exclamation, "Warning!")
                Exit Sub
            End If
        ElseIf counttransid = 14 Then
            TempNoUrut = Tdatstart
        End If

        If CheckSQL("SELECT * FROM TransaksiLab WHERE NoUrut='" & TempNoUrut & "' AND LabSamplingTime is null") = True Then
            MsgBox("Jalankan Barcode di sampling, kemudian aktifkan StartProcess ini.", MsgBoxStyle.Exclamation, "Warning!")
            Exit Sub
        End If

        If CheckSQL("SELECT * FROM TransaksiLab WHERE NoUrut='" & TempNoUrut & "'") = True Then
            If MsgBox("Yakin data ini milik User / No Lab : " & ReadSQLNIK("SELECT Nama FROM MasterPasien WHERE NoRekamMedis IN ( SELECT IDInternet FROM TransaksiLab WHERE NoUrut='" & TempNoUrut & "' )") & " / " & TempNoUrut, MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                If CheckSQL("SELECT * FROM TransaksiLab WHERE NoUrut='" & TempNoUrut & "' AND LabStartTime is null ") = True Then
                    WriteSQL("update TransaksiLab set LabStartTime=getdate()  WHERE NoUrut='" & TempNoUrut & "'", 4)
                    TempTranslabID = ReadSQLNIK("SELECT translabid FROM transaksilab WHERE nourut = '" & TempNoUrut & "'")

                    '================================================================================================
                    Dim Tbool As Boolean = True
                    If Utility.GetConfig("Mesin") = "No" Then
                        Tbool = False
                    End If

                    'Insert ke mesin
                    If Tbool = True Then
                        Dim Tdiff As Integer = Utility.GetConfig("MesinDiff")
                        If buttindakanid.Text <> "" And Tdiff = 3 Then
                            If CekKoneksi("SHOW TABLES FROM " & TtconU.Tdb & "", TtconU) = False Then
                                MsgBox("Sending data ke mesin gagal, cek koneksi ke server DB " & TtconU.Tdb & " atau IP " & TtconU.Tip & ".", MsgBoxStyle.Exclamation, "Warning!")
                            Else
                                Dim Tmesin3 As DataTable = ReadSQL("SELECT b.NoUrut,b.TglLab,c.Nama,a.Mesin,a.TindakanID,a.NamaTindakan,f.DrNama,c.JenisKelamin,LEFT(c.DomisiliAlamat,100) as Alamat,c.NoRekamMedis,c.TglLahir,DATEDIFF(YYYY, c.TglLahir, GETDATE()) as Umur " & _
                                                                   "FROM transaksilabdetail a " & _
                                                                   "LEFT JOIN TransaksiLab b on a.TransLabID = b.TransLabID " & _
                                                                   "LEFT JOIN MasterPasien c on b.IDInternet = c.NoRekamMedis " & _
                                                                   "LEFT JOIN MasterDokterTempatPraktek g on g.IdPraktek = b.DokterRequest " & _
                                                                   "LEFT JOIN MasterDokterKirim f on f.IdKirim = g.IdKirim " & _
                                                                   "WHERE  b.TransLabID='" & TempTranslabID & "' AND mesin<>'URINE' AND Mesin is not null AND LTRIM(RTRIM(Mesin))<>'' AND LTRIM(RTRIM(Mesin))<>'-'")
                                If Tmesin3.Rows.Count > 0 Then
                                    For Each Trow As DataRow In Tmesin3.Rows
                                        If CheckThemysql("SELECT * FROM order_lab WHERE no_lab='" & KodeBarcode & Strings.Replace(Strings.Replace(Strings.Right(Trow("NoUrut"), Len(Trow("NoUrut")) - 2), "L", "8"), "M", "9") & "' AND tgl_order='" & Format(Trow("TglLab"), "yyyyMMdd") & "'", TtconU) = False Then
                                            WriteThemysql("INSERT INTO order_lab(`no_lab`, `tgl_order`, `nama_pas`, `jenis_kel`, `tgl_lahir`, `usia`,`alamat`,`nama_dok`,`usertime`, `no_rm`) " & _
                                                     " VALUES('" & KodeBarcode & Strings.Replace(Strings.Replace(Strings.Right(Trow("NoUrut"), Len(Trow("NoUrut")) - 2), "L", "8"), "M", "9") & "','" & Format(Trow("TglLab"), "yyyyMMdd") & "','" & Trow("Nama") & "','" & Trow("JenisKelamin") & "','" & Format(Trow("TglLahir"), "yyyyMMdd") & "','" & Trow("Umur") & " Tahun','" & Trow("DomisiliAlamat") & "','" & Trow("DrNama") & "',NOW(),'" & Trow("NoRekamMedis") & "')", TtconU)
                                        End If
                                    Next
                                End If
                            End If
                        Else
                            Dim Tmesin5 As DataTable = ReadSQL("SELECT b.NoUrut,b.TglLab,c.Nama,a.Mesin,a.TindakanID,a.NamaTindakan,f.DrNama,c.JenisKelamin,LEFT(c.DomisiliAlamat,100) as DomisiliAlamat,c.NoRekamMedis,c.TglLahir " & _
                                                               "FROM transaksilabdetail a " & _
                                                               "LEFT JOIN TransaksiLab b on a.TransLabID=b.TransLabID " & _
                                                               "LEFT JOIN MasterPasien c on b.IDInternet=c.NoRekamMedis " & _
                                                               "LEFT JOIN MasterDokterTempatPraktek g on g.IdPraktek=b.DokterRequest " & _
                                                               "LEFT JOIN MasterDokterKirim f on f.IdKirim=g.IdKirim " & _
                                                               "WHERE  b.TransLabID='" & TempTranslabID & "' AND mesin<>'URINE' AND Mesin is not null AND LTRIM(RTRIM(Mesin))<>'' AND LTRIM(RTRIM(Mesin))<>'-'")
                            If Tmesin5.Rows.Count > 0 Then
                                If CekKoneksi("SHOW TABLES FROM " & Ttcon.Tdb & "", Ttcon) = False Then
                                    MsgBox("Sending data ke mesin gagal, cek koneksi ke server DB " & Ttcon.Tdb & " atau IP " & Ttcon.Tip & ".", MsgBoxStyle.Exclamation, "Warning!")
                                Else
                                    For Each Trow As DataRow In Tmesin5.Rows
                                        If CheckThemysql("SELECT * FROM paslab WHERE NoUrut='" & KodeBarcode & Strings.Replace(Strings.Replace(Strings.Right(Trow("NoUrut"), Len(Trow("NoUrut")) - 2), "L", "8"), "M", "9") & "' AND TglLab='" & Format(Trow("TglLab"), "yyyyMMdd") & "' AND Instrument='" & Trow("Mesin") & "' AND kode_jasa='" & Trow("TindakanID") & "' AND nama_jasa='" & Trow("NamaTindakan") & "'", Ttcon) = False Then
                                            WriteThemysql("INSERT INTO paslab(`NoUrut`, `TglLab`, `Nama`, `Instrument`, `kode_jasa`, `nama_jasa`,`nama_dok`,`sex`,`alamat`,`no_rm`,`tgl_lahir`,`usertime`) " & _
                                                     " VALUES('" & KodeBarcode & Strings.Replace(Strings.Replace(Strings.Right(Trow("NoUrut"), Len(Trow("NoUrut")) - 2), "L", "8"), "M", "9") & "','" & Format(Trow("TglLab"), "yyyyMMdd") & "','" & Trow("Nama") & "','" & Trow("Mesin") & "','" & Trow("TindakanID") & "','" & Trow("NamaTindakan") & "','" & Trow("DrNama") & "','" & Trow("JenisKelamin") & "','" & Trow("DomisiliAlamat") & "','" & Trow("NoRekamMedis") & "','" & Format(Trow("TglLahir"), "yyyyMMdd") & "', NOW())", Ttcon)
                                        End If
                                    Next
                                End If
                            End If
                        End If

                        Dim status_urine As String = Utility.GetConfig("MesinUrine")
                        If status_urine = "Yes" Then
                            Dim TmesinUrine As DataTable = ReadSQL("SELECT b.NoUrut,b.TglLab,c.Nama,a.Mesin,a.TindakanID,a.NamaTindakan,f.DrNama,c.JenisKelamin,LEFT(c.DomisiliAlamat,100) as DomisiliAlamat,c.NoRekamMedis,c.TglLahir,DATEDIFF(YYYY, c.TglLahir, GETDATE()) as Umur " & _
                                                                   "FROM transaksilabdetail a " & _
                                                                   "LEFT JOIN TransaksiLab b on a.TransLabID=b.TransLabID " & _
                                                                   "LEFT JOIN MasterPasien c on b.IDInternet=c.NoRekamMedis " & _
                                                                   "LEFT JOIN MasterDokterTempatPraktek g on g.IdPraktek=b.DokterRequest " & _
                                                                   "LEFT JOIN MasterDokterKirim f on f.IdKirim=g.IdKirim " & _
                                                                   "WHERE  b.TransLabID='" & TempTranslabID & "' AND mesin='URINE' AND Mesin is not null AND LTRIM(RTRIM(Mesin))<>'' AND LTRIM(RTRIM(Mesin))<>'-'")
                            If TmesinUrine.Rows.Count > 0 Then
                                If CekKoneksi("SHOW TABLES FROM " & TtconU.Tdb & "", TtconU) = False Then
                                    MsgBox("Sending data ke mesin urine gagal, cek koneksi ke server DB " & TtconU.Tdb & " atau IP " & TtconU.Tip & ".", MsgBoxStyle.Exclamation, "Warning!")
                                Else
                                    For Each Trow As DataRow In TmesinUrine.Rows
                                        If CheckThemysql("SELECT * FROM order_lab WHERE no_lab='" & KodeBarcode & Strings.Replace(Strings.Replace(Strings.Right(Trow("NoUrut"), Len(Trow("NoUrut")) - 2), "L", "8"), "M", "9") & "' AND tgl_order='" & Format(Trow("TglLab"), "yyyyMMdd") & "'", TtconU) = False Then
                                            WriteThemysql("INSERT INTO order_lab(`no_lab`, `tgl_order`, `nama_pas`, `jenis_kel`, `tgl_lahir`, `usia`,`alamat`,`nama_dok`,`usertime`, `no_rm`) " & _
                                                     " VALUES('" & KodeBarcode & Strings.Replace(Strings.Replace(Strings.Right(Trow("NoUrut"), Len(Trow("NoUrut")) - 2), "L", "8"), "M", "9") & "','" & Format(Trow("TglLab"), "yyyyMMdd") & "','" & Trow("Nama") & "','" & Trow("JenisKelamin") & "','" & Format(Trow("TglLahir"), "yyyyMMdd") & "','" & Trow("Umur") & " Tahun','" & Trow("DomisiliAlamat") & "','" & Trow("DrNama") & "',NOW(),'" & Trow("NoRekamMedis") & "')", TtconU)
                                        End If
                                    Next
                                End If
                            End If
                        End If
                    End If

                    '================================================================================================

                    If Utility.GetConfig("DualLayar") = "Yes" Then
                        Dim Tnomitra As String = ReadSQLNIK("SELECT M.NoRekamMedis FROM MasterPasien M, TRANSAKSILAB T WHERE T.IDInternet = M.NoRekamMedis AND T.NoUrut = '" & TempNoUrut & "'")
                        Dim Tnama As String = ReadSQLNIK("SELECT M.Nama FROM MasterPasien M, TRANSAKSILAB T WHERE T.IDInternet = M.NoRekamMedis AND T.NoUrut = '" & TempNoUrut & "'")
                        Dim Ttranslabid As String = ReadSQLNIK("SELECT T.TransLabID FROM MasterPasien M, TRANSAKSILAB T WHERE T.IDInternet = M.NoRekamMedis AND T.NoUrut = '" & TempNoUrut & "'")
                        Dim OpenCMD
                        OpenCMD = CreateObject("wscript.shell")
                        OpenCMD.run("DisplaySwitch.exe /external")
                        Survey.SetNama(Tnama, "START LAB", Ttranslabid, Tnomitra, "START LAB")
                        Survey.Show()
                        Survey.SetNama(Tnama, "START LAB", Ttranslabid, Tnomitra, "START LAB")
                        Survey.WindowState = FormWindowState.Maximized
                    End If
                    MsgBox("Start Sampling telah masuk system. Silahkan lanjutkan proses.", MsgBoxStyle.Information, "Success!")
                    Exit Sub
                End If
            Else
                Exit Sub
            End If
        End If
        MsgBox("Tidak ada data yang sesuai untuk di proses.", MsgBoxStyle.Exclamation, "Warning!")
    End Sub

    Private Sub StartProcessToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartProcessToolStripMenuItem.Click
        thread = New System.Threading.Thread(AddressOf startprocessing)
        thread.Start()
    End Sub

    Private Sub PrintSementaraToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintSementaraToolStripMenuItem.Click
        CreateHasilToPDF("Print", "No")
    End Sub

    Private Sub CreateHasilToPDF(ByVal Action As String, ByVal Kop As String)
        Dim TempWhatsapp As String = ""
        Dim TempEmail As String = ""
        Dim CountResultEmpty As Integer = 0

        SetClearGrid()
        Dim Tbls As DataTable = gridlab.DataSource
        insertRowToTbls(Tbls, "typstring", "Registrasi")
        insertRowToTbls(Tbls, "typstring", "Hasil")
        insertRowToTbls(Tbls, "typstring", "Nama")
        insertRowToTbls(Tbls, "typstring", "Umur")
        insertRowToTbls(Tbls, "typstring", "Alamat")
        insertRowToTbls(Tbls, "typstring", "NoTransaksi")
        insertRowToTbls(Tbls, "typstring", "DrPelaksana")
        insertRowToTbls(Tbls, "typstring", "DrRequest")
        insertRowToTbls(Tbls, "typstring", "Standart P/W")
        insertRowToTbls(Tbls, "typstring", "Tanggal")
        insertRowToTbls(Tbls, "typstring", "barcodenotrans")
        insertRowToTbls(Tbls, "typstring", "KesimpulanAll")

        Dim Tlab As DataTable = ReadSQL("SELECT a.StatusHardcopy, a.SendingWhatsapp, a.SendingEmail, a.Kesimpulan, a.Saran, b.NoNIK, b.NoNIP, a.caraambil " & _
                                        "FROM transaksilab a " & _
                                        "LEFT JOIN MasterPasien b ON a.IDInternet = b.NoRekamMedis " & _
                                        "WHERE a.TransLabID='" & buttindakanid.Text & "'")
        Dim TrowLab As DataRow = Tlab.Rows(0)
        Dim Tsimpul As String = ""
        Dim Tsaran As String = ""
        Dim noNIK As String = ""
        Dim Pengirim As String = ""
        If IsDBNull(TrowLab("NoNIK")) = False Then noNIK = TrowLab("NoNIK") Else noNIK = "-"

        Dim caraambil As String = TrowLab("caraambil")
        If CheckSQL("SELECT * FROM MasterCompany WHERE NoCompany = '" & txcodepenagihan.Text.Trim & "' AND ReportHasilPerusahaan = 0") = True And TextBoxNoTransaksi.Text.Contains("M") = True Then
            Pengirim = "Atas Permintaan Sendiri"
        End If

        If IsDBNull(TrowLab("SendingWhatsapp")) = False And TrowLab("SendingWhatsapp").ToString.Trim <> "-" And TrowLab("SendingWhatsapp").ToString.Trim <> "" Then
            NoWhatsappCustomer = TrowLab("SendingWhatsapp")
            TempWhatsapp = NoWhatsappCustomer.Substring(0, 3) & "*****" & NoWhatsappCustomer.Substring(8, NoWhatsappCustomer.Length - 8)
            caraambil = caraambil.Replace(NoWhatsappCustomer, TempWhatsapp)
        Else
            NoWhatsappCustomer = "-"
        End If

        If IsDBNull(TrowLab("SendingEmail")) = False And TrowLab("SendingEmail").ToString.Trim <> "-" Then
            EmailCustomer = TrowLab("SendingEmail")
            TempEmail = EmailCustomer.Substring(0, 3) & "*****" & EmailCustomer.Substring(8, EmailCustomer.Length - 8)
            caraambil = caraambil.Replace(EmailCustomer, TempEmail)
        Else
            EmailCustomer = "-"
        End If

        If IsDBNull(TrowLab("Saran")) = False Then Tsaran = TrowLab("Saran")
        If IsDBNull(TrowLab("Kesimpulan")) = False Then Tsimpul = TrowLab("Kesimpulan")

        Dim Nama As String = TextBoxNamaPasien.Text
        Dim numberic As Boolean = False

        For Each str As Char In Nama
            If IsNumeric(str) Then
                numberic = True
                Exit For
            End If
        Next

        For Each Trow As DataRow In Tbls.Rows
            Trow("Registrasi") = TextBoxNoRekamMedis.Text
            Trow("barcodenotrans") = buttindakanid.Text
            If (TextBoxNoTransaksi.Text.Contains("M")) Then
                If numberic = True Then
                    Trow("Nama") = TextBoxGelar.Text & " " & TextBoxNamaPasien.Text & "/(" & TextBoxJenisKelamin.Text & ")" & vbCrLf
                Else
                    Trow("Nama") = TextBoxGelar.Text & " " & TextBoxNamaPasien.Text & " / " & noNIK & " (" & TextBoxJenisKelamin.Text & ")" & vbCrLf
                End If
            Else
                Trow("Nama") = TextBoxGelar.Text & " " & TextBoxNamaPasien.Text & "/(" & TextBoxJenisKelamin.Text & ")" & vbCrLf
            End If

            Dim Tgltemp As Date = DateTimeTanggalLahir.Value
            If Tgltemp.Date.AddYears(120).Year < DateAndTime.Now.Year Then
                Trow("Umur") = ""
            Else
                Trow("Umur") = Format(DateTimeTanggalLahir.Value, "dd MMM yyyy") & " / " & TextBoxUmur.Text
            End If

            Trow("Alamat") = txalamat.Text
            Trow("NoTransaksi") = TextBoxNoTransaksi.Text & " (" & buttindakanid.Text & ")"
            Trow("DrPelaksana") = DrPelaksanaKlinik
            Trow("Hasil") = caraambil

            If Pengirim <> "" Then
                Trow("DrRequest") = Pengirim
            Else
                If (TextBoxNoTransaksi.Text.Contains("M")) Then
                    Trow("DrRequest") = txpenagihan.Text.Trim
                Else
                    Trow("DrRequest") = butdokter.Text
                End If
            End If

            Trow("Tanggal") = Format(DateTimeTanggalTransaksi.Value, "dd-MMM-yyyy")
            Trow("Satuan") = Trow("Satuan").ToString
            Dim Tkriteria As String = ""
            If TextBoxJenisKelamin.Text = "L" Then
                'display hasil pria
                Tkriteria = Trow("Pria").ToString
            ElseIf TextBoxJenisKelamin.Text = "P" Then
                'display hasil wanita
                Tkriteria = Trow("Wanita").ToString
            Else
                MsgBox("Report Tidak bisa di-Display karena Jenis Kelamin tidak terdefinisi. Update Jenis Kelamin terlebih dahulu.")
                Exit Sub
            End If
            Trow("Standart P/W") = Tkriteria

            If Tsimpul <> "" And Tsaran <> "" Then
                Trow("KesimpulanAll") = "Kesimpulan :" + vbCrLf + Tsimpul + vbCrLf + vbCrLf + "Saran :" + vbCrLf + Tsaran
            ElseIf Tsimpul <> "" Then
                Trow("KesimpulanAll") = "Kesimpulan :" + vbCrLf + Tsimpul
            ElseIf Tsaran <> "" Then
                Trow("KesimpulanAll") = "Saran :" + vbCrLf + Tsaran
            End If

            If (Trow("Result").ToString.Trim = "" Or Trow("Result").ToString.Trim = "-") And Trow("DetailKet").ToString.Trim <> "SEDIMEN :" And Trow("DetailKet").ToString.Trim <> "Lain-lain" And Trow("DetailKet").ToString.Trim <> "Makros" Then
                CountResultEmpty = CountResultEmpty + 1
            End If
        Next

        If Action <> "Nothing" Then
            If CountResultEmpty = Tbls.Rows.Count Then
                MsgBox("Input hasil terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
                Exit Sub
            End If
        End If

        Report = New XtraReport

        If Kop = "Yes" Then
            Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\Hasil\HasilLabKop.repx", True)
        ElseIf Kop = "No" Then
            Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\Hasil\HasilLabNonKop.repx", True)
        End If

        If Action = "Preview" And Action = "Nothing" Then
            Report.Bands.Item(BandKind.ReportFooter).Controls("ttd").Visible = True
            Report.Bands.Item(BandKind.ReportFooter).Controls("ttd").Height = 134
            Report.Bands.Item(BandKind.ReportFooter).Controls("ttd").Width = 250
        ElseIf Action = "Print" Then
            If AutoTTD.Trim = "Yes" Then
                Report.Bands.Item(BandKind.ReportFooter).Controls("ttd").Visible = True
                Report.Bands.Item(BandKind.ReportFooter).Controls("ttd").Height = 134
                Report.Bands.Item(BandKind.ReportFooter).Controls("ttd").Width = 250
            Else
                Report.Bands.Item(BandKind.ReportFooter).Controls("ttd").Visible = False
            End If
        End If

        'Set QR
        'Report.Bands(BandKind.PageFooter).Controls.Add(CreateXRPictureBox(70, 0, 160, 85))
        'Report.Bands.Item(BandKind.PageFooter).Controls("QR_Hasil").BringToFront()

        Report.DataSource = Tbls
        Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MM-yyyy HH:mm:ss") + " by " + UserLabAdmin

        If Action = "Preview" Then
            'Report.RunDesigner()
            Report.ShowPreview()
        ElseIf Action = "Print" Then
            Report.Print()
            'Report.RunDesigner()
        ElseIf Action = "Nothing" Then
            'Save PDF
            Dim NameFile As String = TextBoxNoTransaksi.Text & "_Hasil_Laboratorium"
            Dim filepath As String = "FileDownload\Hasil\" & NameFile & ".pdf"
            If File.Exists(filepath) Then
                My.Computer.FileSystem.DeleteFile(filepath)
            End If
            Report.CreatePdfDocument(filepath)

            ' Save hasil ke lokal directory
            'If Utility.GetConfig("BackupLaboratoriumHasil") = "Yes" AND Action = "Nothing" Then
            '    Dim PathFolder As String = Utility.GetConfig("BackupLaboratoriumHasilPath")
            '    ' Format : NoTransaksi_Nama_NIP
            '    Dim NamaFolderTransaksi As String = ""

            '    If nip <> "-" Then
            '        NamaFolderTransaksi = TextBoxNoTransaksi.Text & "_" & TextBoxNamaPasien.Text
            '    Else
            '        NamaFolderTransaksi = TextBoxNoTransaksi.Text & "_" & TextBoxNamaPasien.Text & "_" & nip
            '    End If

            '    PathFolder = PathFolder & "Offline" & "\" & Format(DateTimeTanggalTransaksi.Value, "yyyy") & "\" & Format(DateTimeTanggalTransaksi.Value, "MMMM") & "\" & Format(DateTimeTanggalTransaksi.Value, "dd") & "\" & NamaFolderTransaksi & "\Laboratorium"
            '    If (Not System.IO.Directory.Exists(PathFolder)) Then
            '        System.IO.Directory.CreateDirectory(PathFolder)
            '    End If

            '    Dim nameFileLaboratorium As String = "Laboratorium_" & TextBoxNoTransaksi.Text

            '    Dim filePathLaboratorium As String = PathFolder & "\" & nameFileLaboratorium.Replace("/", "") & ".pdf"
            '    If File.Exists(filePathLaboratorium) Then
            '        My.Computer.FileSystem.DeleteFile(filePathLaboratorium)
            '    End If
            '    Report.CreatePdfDocument(filePathLaboratorium)
            'End If

            ' Create QR Code
            If QR_Code_Trans.Image Is Nothing = False And CekKoneksi("SHOW TABLES FROM " & DB_Poliklinik.Tdb & "", DB_Poliklinik) = True Then
                'Set Nama File di Online
                Dim KodeBarcode As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='KodeBarcode'")
                Dim txQR As String = KodeBarcode & NameFile

                'CreateBase64
                Dim Base64Inv As String = ""
                Base64Inv = Convert.ToBase64String(System.IO.File.ReadAllBytes(filepath))

                'Send Base64 to Online
                WriteThemysql("REPLACE INTO QR_HasilLaboratorium (NameFile, FileBase64, createdate, createby)  " & _
                                                      "VALUES('" & txQR & "', '" & Base64Inv & "', NOW(), '" & UserLabAdmin & "') ", DB_Poliklinik)
            End If
        End If

        If Action <> "Nothing" Then
            If CountResultEmpty = 0 Then
                If CheckSQL("SELECT * FROM TransaksiLab WHERE TransLabID='" & buttindakanid.Text & "' AND TglCetakHasil is null") = True Then
                    WriteSQL("update TransaksiLab set TglCetakHasil=getdate(), LabCetak=getdate() , [Status]='TAKEIT' , UserCetakHasil='" & UserLabAdmin & "' ,ClosedInputHasil=1 WHERE TransLabID='" & buttindakanid.Text & "'", 4)
                End If
            End If
        End If

        '# Fungsi untuk sending ke program tracking
        Dim statusProgramTracking As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'StatusProgramTracking'")
        If Action = "Print" And statusProgramTracking = "Yes" Then
            If HardcopyCompany(buttindakanid.Text, "Offline") = True Then
                If CountResultEmpty = 0 And TrowLab("StatusHardcopy") = True Then
                    'SENDING KE DB TRACKING
                    Dim Tloc As String = ReadSQLNIK("SELECT StrValue  FROM MsConfig WHERE ConfigName='NoPoli'")
                    Dim TglLab As String = "", LabDaftar As String = "", LabSamplingTime As String = "", LabStartTime As String = "", TglInputHasil As String = "", TglCetakHasil As String = ""
                    Dim Tcompany As String = ""
                    Dim Tlab2 As DataTable = ReadSQL("SELECT a.DetailPemeriksaan, a.TransLabID, a.NoUrut, b.Nama, CONVERT(date, b.TglLahir) as 'TglLahir',  " & _
                                                    " b.DomisiliAlamat, c.NoJenisBayar, b.NoRekamMedis, a.CaraAmbil, StatusSoftcopy, StatusHardcopy,  " & _
                                                    " deleted, tgllab, labdaftar, labsamplingtime, labstarttime, tglinputhasil, tglcetakhasil,  " & _
                                                    " DetailPemeriksaan , CASE WHEN c.JenisBayar = 'TAGIHAN' THEN c.NoJenisBayar WHEN c.JenisBayar <> 'TAGIHAN' THEN 'PASIEN UMUM' ELSE 'NOT FOUND' END AS 'NamaCompany' FROM TransaksiLab a " & _
                                                    " LEFT JOIN MasterPasien b on a.IDInternet=b.NoRekamMedis  " & _
                                                    " LEFT JOIN TransaksiLabBayar c on c.TransLabID=a.TransLabID  " & _
                                                    " WHERE a.TransLabID = " & buttindakanid.Text & "")
                    Dim Trow2 As DataRow = Tlab2.Rows(0)

                    If Tlab2.Rows.Count > 0 Then
                        If Trow2("NamaCompany").ToString.Contains("-") Then
                            Tcompany = Trow2("NamaCompany").ToString
                            Dim Tsplit() As String = Tcompany.Split("-")
                            Tcompany = Tsplit(0).ToString.Trim.ToUpper
                        Else
                            Tcompany = Trow2("NamaCompany").ToString.ToUpper
                        End If

                        If IsDBNull(Trow2("tgllab")) = False Then TglLab = "" & Format(Trow2("tgllab"), "yyyy-MM-dd HH:mm:ss") & "" Else TglLab = ""
                        If IsDBNull(Trow2("labdaftar")) = False Then LabDaftar = "" & Format(Trow2("labdaftar"), "yyyy-MM-dd HH:mm:ss") & "" Else LabDaftar = ""
                        If IsDBNull(Trow2("labsamplingtime")) = False Then LabSamplingTime = "" & Format(Trow2("labsamplingtime"), "yyyy-MM-dd HH:mm:ss") & "" Else LabSamplingTime = ""
                        If IsDBNull(Trow2("labstarttime")) = False Then LabStartTime = "" & Format(Trow2("labstarttime"), "yyyy-MM-dd HH:mm:ss") & "" Else LabStartTime = ""
                        If IsDBNull(Trow2("tglinputhasil")) = False Then TglInputHasil = "" & Format(Trow2("tglinputhasil"), "yyyy-MM-dd HH:mm:ss") & "" Else TglInputHasil = ""
                        If IsDBNull(Trow2("tglcetakhasil")) = False Then TglCetakHasil = "" & Format(Trow2("tglcetakhasil"), "yyyy-MM-dd HH:mm:ss") & "" Else TglCetakHasil = ""

                        If Trow2("NoUrut").ToString.Contains("M") = True And IsDBNull(Trow2("labsamplingtime")) = False Then
                            TglLab = LabSamplingTime
                            LabDaftar = LabSamplingTime
                            LabStartTime = LabSamplingTime
                        End If

                        WriteThemysql("REPLACE INTO rekammedis (translabid, cabang, nourut, nama, tgllahir, alamat, company, idpasien, caraambil, statussoftcopy, statushardcopy, deleted, tgllab, labdaftar, labsamplingtime, labstarttime, tglinputhasil, tglcetakhasil, updated, tindakan)  " & _
                                                  "VALUES('" & Trow2("TransLabID") & "', '" & Tloc & "','" & Trow2("NoUrut") & "','" & Trow2("Nama") & "','" & Format(Trow2("TglLahir"), "yyyy-MM-dd") & "','" & Trow2("DomisiliAlamat") & "', '" & Tcompany & "','" & Trow2("NoRekamMedis") & "','" & Trow2("CaraAmbil") & "'," & Trow2("StatusSoftcopy") & "," & Trow2("StatusHardcopy") & "," & Trow2("deleted") & ",  " & _
                                                  "'" & TglLab & "','" & LabDaftar & "','" & LabSamplingTime & "','" & LabStartTime & "','" & TglInputHasil & "','" & TglCetakHasil & "',0, '" & Trow2("DetailPemeriksaan") & "') ", DB_Tracking)
                    End If
                End If
            End If
        End If

        If Action <> "Nothing" Then
            Dim TboolEmail As Boolean = True
            Dim TboolWhatsapp As Boolean = True
            If Utility.GetConfig("Email") = "No" Then TboolEmail = False
            If Utility.GetConfig("Whatsapp") = "No" Then TboolWhatsapp = False

            If TboolEmail = False And TboolWhatsapp = False Then
                'Nothing
            Else
                If CheckSQL("SELECT * FROM transaksilab WHERE LabSendMail is null AND StatusSoftcopy=1 AND TransLabID=" & buttindakanid.Text & "") = True Then
                    SendiToolStripMenuItem.PerformClick()
                ElseIf CheckSQL("SELECT * FROM transaksilab WHERE LabSendMail is null AND TransLabID=" & buttindakanid.Text & "") = True Then
                    Dim NoUrut As String = TextBoxNoTransaksi.Text
                    Dim Tcompany As DataTable = ReadSQL("SELECT No_Handphone2, No_Handphone, Email_Perusahaan, TerimaHasilKaryawan, Whatsapp_Auto, Email_Auto FROM MasterCompany WHERE NoCompany='" & txcodepenagihan.Text.Trim & "'")
                    If Tcompany.Rows.Count > 0 Then
                        Dim TrowCompany As DataRow = Tcompany.Rows(0)
                        If (TrowCompany("TerimaHasilKaryawan") = True And TrowCompany("Whatsapp_Auto") = True And NoUrut.Contains("L") = True) Or (TrowCompany("Whatsapp_Auto") = True And NoUrut.Contains("M") = True) And TboolWhatsapp = True Then
                            SendiToolStripMenuItem.PerformClick()
                        ElseIf (TrowCompany("TerimaHasilKaryawan") = True And TrowCompany("Email_Auto") = True And NoUrut.Contains("L") = True) Or (TrowCompany("Email_Auto") = True And NoUrut.Contains("M") = True) And TboolEmail = True Then
                            SendiToolStripMenuItem.PerformClick()
                        End If

                        If TrowCompany("No_Handphone2").ToString.Trim <> "" And TrowCompany("No_Handphone2").ToString.Trim <> "0" And TrowCompany("No_Handphone2").ToString.Trim <> "-" And TboolWhatsapp = True Then
                            SendiToolStripMenuItem.PerformClick()
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Public Sub sendingwhatsappcompany()
        Try
            Dim Tloc As String = ReadSQLNIK("SELECT StrValue  FROM MsConfig WHERE ConfigName='NoPoli'")
            NewToolStripMenuItem.Enabled = False
            Dim NoWhatsapp As String = NoWhatsappCompany
            If Strings.Left(NoWhatsapp, 2) = "08" Then NoWhatsapp = "62" & NoWhatsapp.Substring(1, NoWhatsapp.Length - 1)
            Dim TIP_Whatsapp = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='TIP_Whatsapp'")
            Dim TxPDF As String = Convert.ToBase64String(System.IO.File.ReadAllBytes("FileDownload\Hasil\" & TextBoxNoTransaksi.Text & "_Hasil_Laboratorium" & ".pdf"))
            Dim filename As String = TextBoxNoTransaksi.Text & "_Hasil_Laboratorium.pdf"
            Dim parameter As String = SetParameterWhatsapp(NoWhatsapp, TxPDF, filename, "No")

            Dim uri As String = "http://" & TIP_Whatsapp & ":4444/send-pdf"
            Dim StatsSending As String = ""

            StatsSending = SendDataWhatsapp(parameter, uri)

            'Check Sending Hasil DL
            If SendHasilDL = True Then
                Dim TxPDF_DL As String = Convert.ToBase64String(System.IO.File.ReadAllBytes("FileDownload\Hasil\Hematologi_Lengkap\" & TextBoxNoTransaksi.Text & "_Hasil_Hematologi_Lengkap" & ".pdf"))
                Dim filename_DL As String = TextBoxNoTransaksi.Text & "_Hasil_Hematologi_Lengkap.pdf"

                Dim parameter_DL As String = SetParameterWhatsapp(NoWhatsapp, TxPDF_DL, filename_DL, "No")
                SendDataWhatsapp(parameter_DL, uri)
            End If

            'Check Sending Hasil Thorax
            If SendHasilThorax = True Then
                Dim TxPDF_Thorax As String = Convert.ToBase64String(System.IO.File.ReadAllBytes("FileDownload\Hasil\Thorax\" & TextBoxNoTransaksi.Text & "_Hasil_Thorax" & ".pdf"))
                Dim filename_Thorax As String = TextBoxNoTransaksi.Text & "_Hasil_Thorax.pdf"

                Dim parameter_Thorax As String = SetParameterWhatsapp(NoWhatsapp, TxPDF_Thorax, filename_Thorax, "Yes")
                SendDataWhatsapp(parameter_Thorax, uri)
            End If

            If StatsSending = "Success" Then
                MsgBox("Berhasil mengirim Whatsapp ke " & NoWhatsappCompany.Trim & ".", MsgBoxStyle.Information, "Success!")
                WriteSQL("update transaksilab set LabSendMail=getdate() WHERE nourut='" & TextBoxNoTransaksi.Text & "'", 4)
                WriteSQL("INSERT INTO LogSendingWhatsappEmail (SendingJenis, SendingTujuan, SendingNamaFile, SendingStatus, SendingDate, SendingBy, NoUrut, JenisSending, Cabang) VALUES ('Whatsapp', '" & NoWhatsapp & "', '" & TextBoxNoTransaksi.Text & "_Hasil_Laboratorium" & "', 1, GETDATE(), '" & UserLabAdmin & "', '" & TextBoxNoTransaksi.Text & "', 'COMPANY', '" & Tloc & "')", 4)
                NewToolStripMenuItem.Enabled = True
            ElseIf StatsSending = "Nothing" Then
                MsgBox("Gagal Mengirim Whatsapp ke " & NoWhatsappCompany.Trim & ". Cek koneksi jaringan atau hubungi IT untuk restart server Whatsapp.", MsgBoxStyle.Exclamation, "Warning!")
                NewToolStripMenuItem.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            NewToolStripMenuItem.Enabled = True
        End Try
    End Sub

    Public Sub sendingwhatsappmarketing()
        Try
            NewToolStripMenuItem.Enabled = False
            Dim Tloc As String = ReadSQLNIK("SELECT StrValue  FROM MsConfig WHERE ConfigName='NoPoli'")
            Dim NoWhatsapp As String = NoWhatsappMarketing
            If Strings.Left(NoWhatsapp, 2) = "08" Then NoWhatsapp = "62" & NoWhatsapp.Substring(1, NoWhatsapp.Length - 1)
            Dim TIP_Whatsapp = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='TIP_Whatsapp'")
            Dim TxPDF As String = Convert.ToBase64String(System.IO.File.ReadAllBytes("FileDownload\Hasil\" & TextBoxNoTransaksi.Text & "_Hasil_Laboratorium" & ".pdf"))
            Dim filename As String = TextBoxNoTransaksi.Text & "_Hasil_Laboratorium.pdf"
            Dim parameter As String = SetParameterWhatsapp(NoWhatsapp, TxPDF, filename, "No")

            Dim uri As String = "http://" & TIP_Whatsapp & ":4444/send-pdf"
            Dim StatsSending As String = ""

            StatsSending = SendDataWhatsapp(parameter, uri)

            'Check Sending Hasil DL
            If SendHasilDL = True Then
                Dim TxPDF_DL As String = Convert.ToBase64String(System.IO.File.ReadAllBytes("FileDownload\Hasil\Hematologi_Lengkap\" & TextBoxNoTransaksi.Text & "_Hasil_Hematologi_Lengkap" & ".pdf"))
                Dim filename_DL As String = TextBoxNoTransaksi.Text & "_Hasil_Hematologi_Lengkap.pdf"

                Dim parameter_DL As String = SetParameterWhatsapp(NoWhatsapp, TxPDF_DL, filename_DL, "No")
                SendDataWhatsapp(parameter_DL, uri)
            End If

            'Check Sending Hasil Thorax
            If SendHasilThorax = True Then
                Dim TxPDF_Thorax As String = Convert.ToBase64String(System.IO.File.ReadAllBytes("FileDownload\Hasil\Thorax\" & TextBoxNoTransaksi.Text & "_Hasil_Thorax" & ".pdf"))
                Dim filename_Thorax As String = TextBoxNoTransaksi.Text & "_Hasil_Thorax.pdf"

                Dim parameter_Thorax As String = SetParameterWhatsapp(NoWhatsapp, TxPDF_Thorax, filename_Thorax, "Yes")
                SendDataWhatsapp(parameter_Thorax, uri)
            End If

            If StatsSending = "Success" Then
                MsgBox("Berhasil mengirim Whatsapp ke " & NoWhatsappMarketing.Trim & ".", MsgBoxStyle.Information, "Success!")
                WriteSQL("update transaksilab set LabSendMail=getdate() WHERE nourut='" & TextBoxNoTransaksi.Text & "'", 4)
                WriteSQL("INSERT INTO LogSendingWhatsappEmail (SendingJenis, SendingTujuan, SendingNamaFile, SendingStatus, SendingDate, SendingBy, NoUrut, JenisSending, Cabang) VALUES ('Whatsapp', '" & NoWhatsapp & "', '" & TextBoxNoTransaksi.Text & "_Hasil_Laboratorium" & "', 1, GETDATE(), '" & UserLabAdmin & "', '" & TextBoxNoTransaksi.Text & "', 'MARKETING','" & Tloc & "')", 4)
                NewToolStripMenuItem.Enabled = True
            ElseIf StatsSending = "Nothing" Then
                MsgBox("Gagal Mengirim Whatsapp ke " & NoWhatsappMarketing.Trim & ". Cek koneksi jaringan atau hubungi IT untuk restart server Whatsapp.", MsgBoxStyle.Exclamation, "Warning!")
                NewToolStripMenuItem.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            NewToolStripMenuItem.Enabled = True
        End Try
    End Sub

    Public Sub sendingwhatsappcust()
        Try
            NewToolStripMenuItem.Enabled = False
            Dim Tloc As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='NoPoli'")
            Dim NoWhatsapp As String = NoWhatsappCustomer
            Dim Twhatsapp() As String = NoWhatsappCustomer.Split(",")
            If NoWhatsappCustomer = "-" Then
                NoWhatsapp = ReadSQLNIK("SELECT NoHandphone FROM MasterPasien WHERE NoRekamMedis IN (SELECT IDInternet FROM TransaksiLab WHERE NoUrut='" & TextBoxNoTransaksi.Text & "')")
            Else
                If NoWhatsappCustomer.Contains(",") = False Then NoWhatsapp = Twhatsapp(0)
            End If

            If NoWhatsappCustomer = "-" Or NoWhatsappCustomer.Contains(",") = False Then
                If Strings.Left(NoWhatsapp, 2) = "08" Then NoWhatsapp = "62" & NoWhatsapp.Substring(1, NoWhatsapp.Length - 1)
            End If

            Dim TIP_Whatsapp As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='TIP_Whatsapp'")
            Dim TxPDF As String = ""
            Dim filename As String = ""
            Dim parameter As String = ""
            Dim uri As String = ""
            Dim uri_message As String = ""
            Dim StatsSending As String = ""

            If NoWhatsappCustomer.Contains(",") = False Or NoWhatsappCustomer = "-" Then
                TxPDF = Convert.ToBase64String(System.IO.File.ReadAllBytes("FileDownload\Hasil\" & TextBoxNoTransaksi.Text & "_Hasil_Laboratorium" & ".pdf"))
                filename = TextBoxNoTransaksi.Text & "_Hasil_Laboratorium.pdf"

                parameter = SetParameterWhatsapp(NoWhatsapp, TxPDF, filename, "Yes")

                uri = "http://" & TIP_Whatsapp & ":4444/send-pdf"
                uri_message = "http://" & TIP_Whatsapp & ":4444/send"

                StatsSending = SendDataWhatsapp(parameter, uri)

                'Check Sending Hasil DL
                If SendHasilDL = True Then
                    Dim TxPDF_DL As String = Convert.ToBase64String(System.IO.File.ReadAllBytes("FileDownload\Hasil\Hematologi_Lengkap\" & TextBoxNoTransaksi.Text & "_Hasil_Hematologi_Lengkap" & ".pdf"))
                    Dim filename_DL As String = TextBoxNoTransaksi.Text & "_Hasil_Hematologi_Lengkap.pdf"

                    Dim parameter_DL As String = SetParameterWhatsapp(NoWhatsapp, TxPDF_DL, filename_DL, "No")
                    SendDataWhatsapp(parameter_DL, uri)
                End If

                'Check Sending Hasil Thorax
                If SendHasilThorax = True Then
                    Dim TxPDF_Thorax As String = Convert.ToBase64String(System.IO.File.ReadAllBytes("FileDownload\Hasil\Thorax\" & TextBoxNoTransaksi.Text & "_Hasil_Thorax" & ".pdf"))
                    Dim filename_Thorax As String = TextBoxNoTransaksi.Text & "_Hasil_Thorax.pdf"

                    Dim parameter_Thorax As String = SetParameterWhatsapp(NoWhatsapp, TxPDF_Thorax, filename_Thorax, "Yes")
                    SendDataWhatsapp(parameter_Thorax, uri)
                End If

                If CheckSQL("SELECT * FROM LogSendingWhatsappEmail WHERE Cabang='" & Tloc & "' AND SendingJenis='Whatsapp' AND SendingTujuan like '%" & NoWhatsapp & "%' AND CONVERT(date, SendingDate) = '" & Format(DateTime.Now, "yyyy-MM-dd") & "'") = False Then
                    SendDataWhatsapp(parameter, uri_message)
                End If
            ElseIf NoWhatsappCustomer.Contains(",") = True Then
                For i As Integer = 0 To Twhatsapp.Count - 1
                    NoWhatsapp = Twhatsapp(i).ToString.Trim
                    If Strings.Left(NoWhatsapp, 2) = "08" Then NoWhatsapp = "62" & NoWhatsapp.Substring(1, NoWhatsapp.Length - 1)

                    TxPDF = Convert.ToBase64String(System.IO.File.ReadAllBytes("FileDownload\Hasil\" & TextBoxNoTransaksi.Text & "_Hasil_Laboratorium" & ".pdf"))
                    filename = TextBoxNoTransaksi.Text & "_Hasil_Laboratorium.pdf"

                    parameter = SetParameterWhatsapp(NoWhatsapp, TxPDF, filename, "Yes")

                    uri = "http://" & TIP_Whatsapp & ":4444/send-pdf"
                    uri_message = "http://" & TIP_Whatsapp & ":4444/send"

                    SendDataWhatsapp(parameter, uri)

                    'Check Sending Hasil DL
                    If SendHasilDL = True Then
                        Dim TxPDF_DL As String = Convert.ToBase64String(System.IO.File.ReadAllBytes("FileDownload\Hasil\Hematologi_Lengkap\" & TextBoxNoTransaksi.Text & "_Hasil_Hematologi_Lengkap" & ".pdf"))
                        Dim filename_DL As String = TextBoxNoTransaksi.Text & "_Hasil_Hematologi_Lengkap.pdf"

                        Dim parameter_DL As String = SetParameterWhatsapp(NoWhatsapp, TxPDF_DL, filename_DL, "No")
                        SendDataWhatsapp(parameter_DL, uri)
                    End If

                    'Check Sending Hasil Thorax
                    If SendHasilThorax = True Then
                        Dim TxPDF_Thorax As String = Convert.ToBase64String(System.IO.File.ReadAllBytes("FileDownload\Hasil\Thorax\" & TextBoxNoTransaksi.Text & "_Hasil_Thorax" & ".pdf"))
                        Dim filename_Thorax As String = TextBoxNoTransaksi.Text & "_Hasil_Thorax.pdf"

                        Dim parameter_Thorax As String = SetParameterWhatsapp(NoWhatsapp, TxPDF_Thorax, filename_Thorax, "Yes")
                        SendDataWhatsapp(parameter_Thorax, uri)
                    End If

                    If CheckSQL("SELECT * FROM LogSendingWhatsappEmail WHERE Cabang='" & Tloc & "' AND SendingJenis='Whatsapp' AND SendingTujuan like '%" & NoWhatsapp & "%' AND CONVERT(date, SendingDate) = '" & Format(DateTime.Now, "yyyy-MM-dd") & "'") = False Then
                        SendDataWhatsapp(parameter, uri_message)
                    End If
                Next
            End If

            If StatsSending = "Success" Then
                MsgBox("Berhasil mengirim Whatsapp ke " & NoWhatsappCustomer.Trim & ".", MsgBoxStyle.Information, "Success!")
                WriteSQL("update transaksilab set LabSendMail=getdate() WHERE nourut='" & TextBoxNoTransaksi.Text & "'", 4)
                WriteSQL("INSERT INTO LogSendingWhatsappEmail (SendingJenis, SendingTujuan, SendingNamaFile, SendingStatus, SendingDate, SendingBy, NoUrut, JenisSending, Cabang) VALUES ('Whatsapp', '" & NoWhatsapp.Trim & "', '" & TextBoxNoTransaksi.Text & "_Hasil_Laboratorium" & "', 1, GETDATE(), '" & UserLabAdmin & "', '" & TextBoxNoTransaksi.Text & "', 'PASIEN', '" & Tloc & "')", 4)
                NewToolStripMenuItem.Enabled = True
            ElseIf StatsSending = "Nothing" Then
                MsgBox("Gagal Mengirim Whatsapp ke " & NoWhatsappCustomer.Trim & ". Cek koneksi jaringan atau hubungi IT untuk restart server Whatsapp.", MsgBoxStyle.Exclamation, "Warning!")
                NewToolStripMenuItem.Enabled = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            NewToolStripMenuItem.Enabled = True
        End Try
    End Sub

    Public Sub sendingemailcust()
        Try
            NewToolStripMenuItem.Enabled = False
            Dim Tloc As String = ReadSQLNIK("SELECT StrValue  FROM MsConfig WHERE ConfigName='NoPoli'")
            Dim email As String = EmailCustomer
            Dim Temail() As String = EmailCustomer.Split(",")
            If EmailCustomer = "-" Then
                email = ReadSQLNIK("SELECT Email FROM MasterPasien WHERE NoRekamMedis in (SELECT IDInternet FROM TransaksiLab WHERE NoUrut='" & TextBoxNoTransaksi.Text & "')")
            Else
                If EmailCustomer.Contains(",") = False Then
                    email = Temail(0)
                End If
            End If

            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential("info@cahayamedika.co.id", "cahayamedika2020!")
            Smtp_Server.Port = 587
            Smtp_Server.EnableSsl = True
            Smtp_Server.Host = "smtp.gmail.com"

            e_mail = New MailMessage()
            e_mail.From = New MailAddress("info@cahayamedika.co.id")
            e_mail.Subject = "Hasil Laboratorium (" & TextBoxNoTransaksi.Text & ")"
            e_mail.To.Add("" & email.Trim & "")
            e_mail.IsBodyHtml = False
            e_mail.Body = "Kepada Yth." & vbCr & vbLf & "" & _
              "Customer Cahaya Diagnostic Centre" & vbCr & vbLf & vbCr & vbLf + "" & _
              "Kami mengucapkan terima kasih atas kepercayaan Bapak/Ibu/Saudara/i sudah melakukan pemeriksaan di Laboratorium Cahaya Diagnostic Centre. Berikut ini kami lampirkan hasil pemeriksaan laboratorium anda." & vbCr & vbLf & vbCr & vbLf + "" & _
              "Silahkan menghubungi kami di nomor 081230885004 (WA/Phone) atau email ke cahayadiagnosticcentre@gmail.com untuk konsultasi lebih lanjut." & vbCr & vbLf & vbCr & vbLf + "" & _
              "Kami menyampaikan beberapa hal yang perlu diperhatikan oleh saudara/i, antara lain:" & vbCr & vbLf + "" & _
              "1. Tetap menjaga jarak dengan orang lain (Physical Distancing)." & vbCr & vbLf + "" & _
              "2. Selalu menggunakan masker saat keluar dari rumah." & vbCr & vbLf + "" & _
              "3. Rajin mencuci & menjaga kebersihan tangan." & vbCr & vbLf + "" & _
              "4. Makan makanan yang bergizi & bila perlu minum suplemen atau vitamin." & vbCr & vbLf + "" & _
              "5. Etika batuk yang baik & benar." & vbCr & vbLf & vbCr & vbLf + "" & _
              "Best regards," & vbCr & vbLf & vbCr & vbLf + "" & _
              "Laboratorium Cahaya Diagnostic Centre."
            e_mail.Attachments.Add(New Attachment("FileDownload\Hasil\" & TextBoxNoTransaksi.Text & "_Hasil_Laboratorium" & ".pdf"))

            'Check Sending Hasil DL
            If SendHasilDL = True Then
                e_mail.Attachments.Add(New Attachment("FileDownload\Hasil\Hematologi_Lengkap\" & TextBoxNoTransaksi.Text & "_Hasil_Hematologi_Lengkap" & ".pdf"))
            End If

            'Check Sending Hasil Thorax
            If SendHasilThorax = True Then
                e_mail.Attachments.Add(New Attachment("FileDownload\Hasil\Thorax\" & TextBoxNoTransaksi.Text & "_Hasil_Thorax" & ".pdf"))
            End If

            Smtp_Server.Send(e_mail)

            WriteSQL("INSERT INTO LogSendingWhatsappEmail (SendingJenis, SendingTujuan, SendingNamaFile, SendingStatus, SendingDate, SendingBy, NoUrut, JenisSending, Cabang) VALUES ('Email', '" & email.Trim & "', '" & TextBoxNoTransaksi.Text & "_Hasil_Laboratorium" & "', 1, GETDATE(), '" & UserLabAdmin & "', '" & TextBoxNoTransaksi.Text & "', 'PASIEN', '" & Tloc & "')", 4)
            WriteSQL("update transaksilab set LabSendMail=getdate() WHERE nourut='" & TextBoxNoTransaksi.Text & "'", 4)
            MsgBox("Berhasil mengirim email ke " & email.Trim & ".", MsgBoxStyle.Information, "Success!")
            NewToolStripMenuItem.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message)
            NewToolStripMenuItem.Enabled = True
        End Try
    End Sub

    Public Sub sendingemailcompany()
        Try
            NewToolStripMenuItem.Enabled = False
            Dim Tloc As String = ReadSQLNIK("SELECT StrValue  FROM MsConfig WHERE ConfigName='NoPoli'")
            Dim email As String = EmailCompany
            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential("info@cahayamedika.co.id", "cahayamedika2020!")
            Smtp_Server.Port = 587
            Smtp_Server.EnableSsl = True
            Smtp_Server.Host = "smtp.gmail.com"

            e_mail = New MailMessage()
            e_mail.From = New MailAddress("info@cahayamedika.co.id")
            e_mail.To.Add("" & email.Trim & "")
            e_mail.Subject = "Hasil Laboratorium (" & TextBoxNoTransaksi.Text & ")"
            e_mail.IsBodyHtml = False
            e_mail.Body = "Kepada Yth." & vbCr & vbLf + "" & _
              "Customer Cahaya Diagnostic Centre" & vbCr & vbLf & vbCr & vbLf + "" & _
              "Kami mengucapkan terima kasih atas kepercayaan Bapak/Ibu/Saudara/i sudah melakukan pemeriksaan di Laboratorium Cahaya Diagnostic Centre. Berikut ini kami lampirkan hasil pemeriksaan laboratorium anda." & vbCr & vbLf & vbCr & vbLf + "" & _
              "Silahkan menghubungi kami di nomor 081230885004 (WA/Phone) atau email ke cahayadiagnosticcentre@gmail.com untuk konsultasi lebih lanjut." & vbCr & vbLf & vbCr & vbLf + "" & _
              "Kami menyampaikan beberapa hal yang perlu diperhatikan oleh saudara/i, antara lain:" & vbCr & vbLf + "" & _
              "1. Tetap menjaga jarak dengan orang lain (Physical Distancing)." & vbCr & vbLf + "" & _
              "2. Selalu menggunakan masker saat keluar dari rumah." & vbCr & vbLf + "" & _
              "3. Rajin mencuci & menjaga kebersihan tangan." & vbCr & vbLf + "" & _
              "4. Makan makanan yang bergizi & bila perlu minum suplemen atau vitamin." & vbCr & vbLf + "" & _
              "5. Etika batuk yang baik & benar." & vbCr & vbLf & vbCr & vbLf + "" & _
              "Best regards," & vbCr & vbLf & vbCr & vbLf + "" & _
              "Laboratorium Cahaya Diagnostic Centre."
            e_mail.Attachments.Add(New Attachment("FileDownload\Hasil\" & TextBoxNoTransaksi.Text & "_Hasil_Laboratorium" & ".pdf"))

            'Check Sending Hasil DL
            If SendHasilDL = True Then
                e_mail.Attachments.Add(New Attachment("FileDownload\Hasil\Hematologi_Lengkap\" & TextBoxNoTransaksi.Text & "_Hasil_Hematologi_Lengkap" & ".pdf"))
            End If

            'Check Sending Hasil Thorax
            If SendHasilThorax = True Then
                e_mail.Attachments.Add(New Attachment("FileDownload\Hasil\Thorax\" & TextBoxNoTransaksi.Text & "_Hasil_Thorax" & ".pdf"))
            End If

            Smtp_Server.Send(e_mail)

            MsgBox("Berhasil mengirim email ke " & email.Trim & ".", MsgBoxStyle.Information, "Success!")
            WriteSQL("update transaksilab set LabSendMail=getdate() WHERE nourut='" & TextBoxNoTransaksi.Text & "'", 4)
            WriteSQL("INSERT INTO LogSendingWhatsappEmail (SendingJenis, SendingTujuan, SendingNamaFile, SendingStatus, SendingDate, SendingBy, NoUrut, JenisSending, Cabang) VALUES ('Email', '" & email.Trim & "', '" & TextBoxNoTransaksi.Text & "_Hasil_Laboratorium" & "', 1, GETDATE(), '" & UserLabAdmin & "', '" & TextBoxNoTransaksi.Text & "', 'COMPANY', '" & Tloc & "')", 4)
            NewToolStripMenuItem.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message)
            NewToolStripMenuItem.Enabled = True
        End Try
    End Sub

    Private Sub butsavethorax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butsavethorax.Click
        Dim Tbls As DataTable = gridlab.DataSource

        If drthorax.FindStringExact(drthorax.Text) < 0 Then
            MsgBox("Pilih dokter Spiro yang memeriksa")
            drthorax.Focus()
            Exit Sub
        End If

        For Each Nnew As DataRow In Tbls.Rows
            If Strings.LCase(Nnew("NamaTindakan").ToString).Contains("thorax") = True Then
                If CheckSQL("SELECT * FROM TransaksiLabHasilLain WHERE [NoUrut]='" & TextBoxNoTransaksi.Text & "'") = True Then
                    WriteSQL("update TransaksiLabHasilLain set [Cor]='" & txthoraxcor.Text & "',[Pulmo]='" & txthoraxpulmo.Text & "',[Sinus]='" & txthoraxsinus.Text & "',[Skeletal]='" & txthoraxskeletal.Text & "',[Kesimpulan]='" & txthoraxkesimpulan.Text & "',[ThoraxDate]='" & Format(DateAndTime.Now, "MM/dd/yyyy") & "',[ThoraxBy]='" & UserLabAdmin & "' , drThorax='" & drthorax.Text & "' WHERE NoUrut='" & TextBoxNoTransaksi.Text & "'", 4)
                Else
                    WriteSQL("insert TransaksiLabHasilLain([NoUrut],[Cor],[Pulmo],[Sinus],[Skeletal],[Kesimpulan],[ThoraxDate],[ThoraxBy],[drThorax]) VALUES('" & TextBoxNoTransaksi.Text & "','" & txthoraxcor.Text & "','" & txthoraxpulmo.Text & "','" & txthoraxsinus.Text & "','" & txthoraxskeletal.Text & "','" & txthoraxkesimpulan.Text & "','" & Format(DateAndTime.Now, "MM/dd/yyyy") & "','" & UserLabAdmin & "','" & drthorax.Text & "')", 4)
                End If

                CreateThoraxToPDF("Nothing", "Yes")

                cmbjenisthorax.SelectedIndex = -1
                MsgBox("Data Thorax Saved.", MsgBoxStyle.Information, "Success!")
                Exit For
            End If
        Next
    End Sub

    Private Sub butsaveecg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butsaveecg.Click
        Dim Tbls As DataTable = gridlab.DataSource

        If cmbecg.FindStringExact(cmbecg.Text) < 0 Then
            MsgBox("Pilih dokter Spiro yang memeriksa")
            cmbecg.Focus()
            Exit Sub
        End If

        For Each Nnew As DataRow In Tbls.Rows
            If Strings.LCase(Nnew("NamaTindakan").ToString).Contains("ecg") = True Then
                If CheckSQL("SELECT * FROM TransaksiLabHasilLain WHERE [NoUrut]='" & TextBoxNoTransaksi.Text & "'") = True Then
                    WriteSQL("update TransaksiLabHasilLain set  [Tekanan]='" & txecgtekanan.Text & "', [DiagnosisECG]='" & txhasilecg.Text & "', [ECGDate]='" & Format(DateAndTime.Now, "MM/dd/yyyy") & "',[ECGBy]='" & UserLabAdmin & "' , DrECG='" & cmbecg.Text & "' WHERE NoUrut='" & TextBoxNoTransaksi.Text & "'", 4)
                Else
                    WriteSQL("insert TransaksiLabHasilLain([NoUrut],[Tekanan],[DiagnosisECG],[ECGDate],[ECGBy]) VALUES('" & TextBoxNoTransaksi.Text & "','" & txecgtekanan.Text & "','" & txhasilecg.Text & "','" & Format(DateAndTime.Now, "MM/dd/yyyy") & "','" & UserLabAdmin & "')", 4)
                End If
                MsgBox("Data ECG Saved.", MsgBoxStyle.Information, "Success!")
                Exit For
            End If
        Next

    End Sub

    Private Sub butsaveaudio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butsaveaudio.Click
        Dim Tbls As DataTable = gridlab.DataSource

        If draudio.FindStringExact(draudio.Text) < 0 Then
            MsgBox("Pilih dokter Spiro yang memeriksa")
            draudio.Focus()
            Exit Sub
        End If

        For Each Nnew As DataRow In Tbls.Rows
            If Strings.LCase(Nnew("NamaTindakan").ToString).Contains("audiometri") = True Then
                If CheckSQL("SELECT * FROM TransaksiLabHasilLain WHERE [NoUrut]='" & TextBoxNoTransaksi.Text & "'") = True Then
                    WriteSQL("update TransaksiLabHasilLain set  [Audio]='" & txaudiometri.Text & "', [AudioDate]='" & Format(DateAndTime.Now, "MM/dd/yyyy") & "',[AudioBy]='" & UserLabAdmin & "' , DrAudio='" & draudio.Text & "' WHERE NoUrut='" & TextBoxNoTransaksi.Text & "'", 4)
                Else
                    WriteSQL("insert TransaksiLabHasilLain([NoUrut],[Audio],[AudioDate],[AudioBy],[DrAudio]) VALUES('" & TextBoxNoTransaksi.Text & "','" & txaudiometri.Text & "','" & Format(DateAndTime.Now, "MM/dd/yyyy") & "','" & UserLabAdmin & "', '" & draudio.Text & "')", 4)
                End If
                MsgBox("Data Audiometri Saved")
            End If
        Next
    End Sub

    Private Sub butprintecg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butprintecg.Click
        If CheckSQL("SELECT * FROM TransaksiLabHasilLain WHERE [NoUrut]='" & TextBoxNoTransaksi.Text & "'") = True Then
            Dim TempWhatsapp As String = ""
            Dim TempEmail As String = ""

            Dim Tlab As DataTable = ReadSQL("SELECT d.*, b.NoNIK, a.caraambil, a.SendingWhatsapp, a.SendingEmail, c.JenisBayar, c.NoJenisBayar " & _
                                            "FROM transaksilab a " & _
                                            "LEFT JOIN MasterPasien b ON a.IDInternet=b.NoRekamMedis " & _
                                            "LEFT JOIN TransaksiLabBayar c on a.TransLabID=c.TransLabID " & _
                                            "LEFT JOIN TransaksiLabHasilLain d on a.NoUrut=d.NoUrut " & _
                                            "WHERE a.TransLabID='" & buttindakanid.Text & "'")
            Dim TrowLab As DataRow = Tlab.Rows(0)
            Dim Tsimpul As String = ""
            Dim Tsaran As String = ""
            Dim noNIK As String = ""
            Dim Pengirim As String = ""
            If IsDBNull(TrowLab("NoNIK")) = False Then noNIK = TrowLab("NoNIK") Else noNIK = "-"
            Dim caraambil As String = TrowLab("caraambil")
            If CheckSQL("SELECT * FROM MasterCompany WHERE NoCompany = '" & txcodepenagihan.Text.Trim & "' AND ReportHasilPerusahaan = 0") = True And TextBoxNoTransaksi.Text.Contains("M") = True Then
                Pengirim = "Atas Permintaan Sendiri"
            End If

            If IsDBNull(TrowLab("SendingWhatsapp")) = False And TrowLab("SendingWhatsapp").ToString.Trim <> "-" Then
                NoWhatsappCustomer = TrowLab("SendingWhatsapp")
                TempWhatsapp = NoWhatsappCustomer.Substring(0, 3) & "*****" & NoWhatsappCustomer.Substring(8, NoWhatsappCustomer.Length - 8)
                caraambil = caraambil.Replace(NoWhatsappCustomer, TempWhatsapp)
            Else
                NoWhatsappCustomer = "-"
            End If

            If IsDBNull(TrowLab("SendingEmail")) = False And TrowLab("SendingEmail").ToString.Trim <> "-" Then
                EmailCustomer = TrowLab("SendingEmail")
                TempEmail = EmailCustomer.Substring(0, 3) & "*****" & EmailCustomer.Substring(8, EmailCustomer.Length - 8)
                caraambil = caraambil.Replace(EmailCustomer, TempEmail)
            Else
                EmailCustomer = "-"
            End If

            insertRowToTbls(Tlab, "typstring", "Registrasi")
            insertRowToTbls(Tlab, "typstring", "Nama")
            insertRowToTbls(Tlab, "typstring", "Umur")
            insertRowToTbls(Tlab, "typstring", "Alamat")
            insertRowToTbls(Tlab, "typstring", "NoTransaksi")
            insertRowToTbls(Tlab, "typstring", "DrPelaksana")
            insertRowToTbls(Tlab, "typstring", "DrRequest")
            insertRowToTbls(Tlab, "typstring", "Tanggal")
            insertRowToTbls(Tlab, "typstring", "Hasil")

            For Each Trow As DataRow In Tlab.Rows
                Trow("Registrasi") = TextBoxNoRekamMedis.Text

                If (TextBoxNoTransaksi.Text.Contains("M")) Then
                    If IsNumeric(Trow("Nama")) = True Then
                        Trow("Nama") = TextBoxGelar.Text & " " & TextBoxNamaPasien.Text & "/(" & TextBoxJenisKelamin.Text & ")" & vbCrLf
                    Else
                        Trow("Nama") = TextBoxGelar.Text & " " & TextBoxNamaPasien.Text & " / " & noNIK & " (" & TextBoxJenisKelamin.Text & ")" & vbCrLf
                    End If
                Else
                    Trow("Nama") = TextBoxGelar.Text & " " & TextBoxNamaPasien.Text & "/(" & TextBoxJenisKelamin.Text & ")" & vbCrLf
                End If

                Dim Tgltemp As Date = DateTimeTanggalLahir.Value
                If Tgltemp.Date.AddYears(120).Year < DateAndTime.Now.Year Then
                    Trow("Umur") = ""
                Else
                    Trow("Umur") = Format(DateTimeTanggalLahir.Value, "dd MMM yyyy") & " / " & TextBoxUmur.Text
                End If

                Trow("Alamat") = txalamat.Text
                Trow("NoTransaksi") = TextBoxNoTransaksi.Text & " (" & buttindakanid.Text & ")"
                Trow("DrPelaksana") = DrPelaksanaKlinik
                Trow("Hasil") = caraambil
                If Pengirim <> "" Then
                    Trow("DrRequest") = Pengirim
                Else
                    If (TextBoxNoTransaksi.Text.Contains("M")) Then
                        Trow("DrRequest") = txpenagihan.Text.Trim
                    Else
                        Trow("DrRequest") = butdokter.Text
                    End If
                End If

                Trow("Tanggal") = Format(DateTimeTanggalTransaksi.Value, "dd-MMM-yyyy")
            Next

            Report = New XtraReport
            Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\Hasil\HasilLabECGNonKop.repx", True)
            If AutoTTD.Trim = "Yes" Then
                Report.Bands.Item(BandKind.PageHeader).Controls("ttd").Visible = True
                Report.Bands.Item(BandKind.PageHeader).Controls("ttd").Height = 134
                Report.Bands.Item(BandKind.PageHeader).Controls("ttd").Width = 250
            Else
                Report.Bands.Item(BandKind.PageHeader).Controls("ttd").Visible = False
            End If

            Report.DataSource = Tlab
            Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MM-yyyy HH:mm:ss") + " by " + UserLabAdmin
            Report.Bands.Item(BandKind.PageHeader).Controls("DokterECG").Text = ReadSQLNIK("SELECT DrECG FROM TransaksiLabHasilLain WHERE NoUrut='" & TextBoxNoTransaksi.Text & "'")

            'Report.RunDesigner()
            'Report.ShowPreview()
            Report.Print()
        End If
    End Sub

    Private Sub butprintthorax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butprintthorax.Click
        CreateThoraxToPDF("Print", "No")
    End Sub

    Private Sub butsaveusg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butsaveusg.Click
        Dim Tbls As DataTable = gridlab.DataSource

        If drusg.FindStringExact(drusg.Text) < 0 Then
            MsgBox("Pilih dokter USG yang memeriksa")
            drusg.Focus()
            Exit Sub
        End If

        For Each Nnew As DataRow In Tbls.Rows
            If Strings.LCase(Nnew("NamaTindakan").ToString).Contains("usg") = True Then
                If CheckSQL("SELECT * FROM TransaksiLabHasilLain WHERE [NoUrut]='" & TextBoxNoTransaksi.Text & "'") = True Then
                    WriteSQL("update TransaksiLabHasilLain set  [usg]='" & txusg.Text & "', [USGDate]='" & Format(DateAndTime.Now, "MM/dd/yyyy") & "' , [USGBy]='" & UserLabAdmin & "',DrUSG='" & drusg.Text & "'  WHERE NoUrut='" & TextBoxNoTransaksi.Text & "'", 4)
                Else
                    WriteSQL("insert TransaksiLabHasilLain([NoUrut],[usg],[USGDate],[USGBy]) VALUES('" & TextBoxNoTransaksi.Text & "','" & txusg.Text & "','" & Format(DateAndTime.Now, "MM/dd/yyyy") & "','" & UserLabAdmin & "')", 4)
                End If
                MsgBox("Data USG Saved")
                Exit For
            End If
        Next

    End Sub

    Private Sub butsavetreadmill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butsavetreadmill.Click
        Dim Tbls As DataTable = gridlab.DataSource

        If drtreadmill.FindStringExact(drtreadmill.Text) < 0 Then
            MsgBox("Pilih dokter Treadmill yang memeriksa")
            drtreadmill.Focus()
            Exit Sub
        End If

        For Each Nnew As DataRow In Tbls.Rows
            If Strings.LCase(Nnew("NamaTindakan").ToString).Contains("treadmill") = True Then
                If CheckSQL("SELECT * FROM TransaksiLabHasilLain WHERE [NoUrut]='" & TextBoxNoTransaksi.Text & "'") = True Then
                    WriteSQL("update TransaksiLabHasilLain set  [treadmill]='" & txtreadmill.Text & "', [treadmillDate]='" & Format(DateAndTime.Now, "MM/dd/yyyy") & "' , [treadmillBy]='" & UserLabAdmin & "' , Drtreadmmill='" & drtreadmill.Text & "'  WHERE NoUrut='" & TextBoxNoTransaksi.Text & "'", 4)
                Else
                    WriteSQL("insert TransaksiLabHasilLain([NoUrut],[treadmill],[treadmillDate],[treadmillBy]) VALUES('" & TextBoxNoTransaksi.Text & "','" & txtreadmill.Text & "','" & Format(DateAndTime.Now, "MM/dd/yyyy") & "','" & UserLabAdmin & "')", 4)
                End If
                MsgBox("Data Treadmill Saved")
                Exit For
            End If
        Next
    End Sub

    Private Sub butsavespiro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butsavespiro.Click
        Dim Tbls As DataTable = gridlab.DataSource
        If drspiro.FindStringExact(drspiro.Text) < 0 Then
            MsgBox("Pilih dokter Spiro yang memeriksa")
            drspiro.Focus()
            Exit Sub
        End If

        For Each Nnew As DataRow In Tbls.Rows
            If Strings.LCase(Nnew("NamaTindakan").ToString).Contains("spirometri") = True Then
                If CheckSQL("SELECT * FROM TransaksiLabHasilLain WHERE [NoUrut]='" & TextBoxNoTransaksi.Text & "'") = True Then
                    WriteSQL("update TransaksiLabHasilLain set  [spirometri]='" & txspiro.Text & "', [spirometriDate]='" & Format(DateAndTime.Now, "MM/dd/yyyy") & "' , [spirometriBy]='" & UserLabAdmin & "' ,DrSpiro='" & drspiro.Text & "' WHERE NoUrut='" & TextBoxNoTransaksi.Text & "'", 4)
                Else
                    WriteSQL("insert TransaksiLabHasilLain([NoUrut],[spirometri],[spirometriDate],[spirometriBy]) VALUES('" & TextBoxNoTransaksi.Text & "','" & txspiro.Text & "','" & Format(DateAndTime.Now, "MM/dd/yyyy") & "','" & UserLabAdmin & "')", 4)
                End If
                MsgBox("Data Spirometri Saved")
                Exit For
            End If
        Next
    End Sub

    Public Sub ResendMesin(ByRef TxID As String, ByRef Tdiff As Integer)
        Dim status_urine As String = Utility.GetConfig("MesinUrine")
        Dim KodeBarcode As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='KodeBarcode'")
        If Tdiff = 5 Then
            Dim db1 As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='TDB'")
            If CheckThemysql("SHOW TABLES FROM '" & db1 & "'", Ttmesin) = False Then
                MsgBox("Proses gagal, periksa kembali koneksi ke server!")
                Exit Sub
            End If
            Dim Tmesin As DataTable
            Tmesin = ReadSQL("SELECT b.NoUrut,b.TglLab,c.Nama,a.Mesin,a.TindakanID,a.NamaTindakan,f.DrNama,c.JenisKelamin,LEFT(c.DomisiliAlamat,100) as DomisiliAlamat,c.NoRekamMedis,c.TglLahir " & _
                             "FROM transaksilabdetail a " & _
                             "LEFT JOIN TransaksiLab b on a.TransLabID=b.TransLabID " & _
                             "LEFT JOIN MasterPasien c on b.IDInternet=c.NoRekamMedis " & _
                             "LEFT JOIN MasterDokterTempatPraktek g on g.IdPraktek=b.DokterRequest " & _
                             "LEFT JOIN MasterDokterKirim f on f.IdKirim=g.IdKirim " & _
                             "WHERE  b.TransLabID='" & buttindakanid.Text & "' AND mesin<>'URINE' AND Mesin is not null AND LTRIM(RTRIM(Mesin))<>'' AND LTRIM(RTRIM(Mesin))<>'-'")
            If Tmesin.Rows.Count > 0 Then
                For Each Trow As DataRow In Tmesin.Rows
                    If CheckThemysql("SELECT * FROM paslab WHERE NoUrut='" & KodeBarcode & Strings.Replace(Strings.Replace(Strings.Right(Trow("NoUrut"), Len(Trow("NoUrut")) - 2), "L", "8"), "M", "9") & "' AND TglLab='" & Format(Trow("TglLab"), "yyyyMMdd") & "' AND Instrument='" & Trow("Mesin") & "' AND kode_jasa='" & Trow("TindakanID") & "' AND nama_jasa='" & Trow("NamaTindakan") & "'", Ttmesin) = False Then
                        WriteThemysql("INSERT INTO paslab(`NoUrut`, `TglLab`, `Nama`, `Instrument`, `kode_jasa`, `nama_jasa`,`nama_dok`,`sex`,`alamat`,`no_rm`,`tgl_lahir`) " & _
                                 " VALUES('" & KodeBarcode & Strings.Replace(Strings.Replace(Strings.Right(Trow("NoUrut"), Len(Trow("NoUrut")) - 2), "L", "8"), "M", "9") & "','" & Format(Trow("TglLab"), "yyyyMMdd") & "','" & Trow("Nama") & "','" & Trow("Mesin") & "','" & Trow("TindakanID") & "','" & Trow("NamaTindakan") & "','" & Trow("DrNama") & "','" & Trow("JenisKelamin") & "','" & Trow("DomisiliAlamat") & "','" & Trow("NoRekamMedis") & "','" & Format(Trow("TglLahir"), "yyyyMMdd") & "')", Ttmesin)
                    End If
                Next
            End If
            MsgBox("Done. Send to Mesin")
        ElseIf Tdiff = 3 Then
            Dim Tmesin3 As DataTable = ReadSQL("SELECT b.NoUrut,b.TglLab,c.Nama,a.Mesin,a.TindakanID,a.NamaTindakan,f.DrNama,c.JenisKelamin,LEFT(c.DomisiliAlamat,100) as DomisiliAlamat,c.NoRekamMedis,c.TglLahir,DATEDIFF(YYYY, c.TglLahir, GETDATE()) as Umur " & _
                                               "FROM transaksilabdetail a " & _
                                               "LEFT JOIN TransaksiLab b on a.TransLabID=b.TransLabID " & _
                                               "LEFT JOIN MasterPasien c on b.IDInternet=c.NoRekamMedis " & _
                                               "LEFT JOIN MasterDokterTempatPraktek g on g.IdPraktek=b.DokterRequest " & _
                                               "LEFT JOIN MasterDokterKirim f on f.IdKirim=g.IdKirim " & _
                                               "WHERE  b.TransLabID='" & buttindakanid.Text & "' AND mesin<>'URINE' AND Mesin is not null AND LTRIM(RTRIM(Mesin))<>'' AND LTRIM(RTRIM(Mesin))<>'-'")
            If Tmesin3.Rows.Count > 0 Then
                For Each Trow As DataRow In Tmesin3.Rows
                    If CheckThemysql("SELECT * FROM order_lab WHERE no_lab='" & Strings.Replace(Strings.Replace(Strings.Right(Trow("NoUrut"), Len(Trow("NoUrut")) - 2), "L", "8"), "M", "9") & "' AND tgl_order='" & Format(Trow("TglLab"), "yyyyMMdd") & "'", TtconU) = False Then
                        WriteThemysql("INSERT INTO order_lab(`no_lab`, `tgl_order`, `nama_pas`, `jenis_kel`, `tgl_lahir`, `usia`,`alamat`,`nama_dok`,`usertime`, `no_rm`) " & _
                                 " VALUES('" & Strings.Replace(Strings.Replace(Strings.Right(Trow("NoUrut"), Len(Trow("NoUrut")) - 2), "L", "8"), "M", "9") & "','" & Format(Trow("TglLab"), "yyyyMMdd") & "','" & Trow("Nama") & "','" & Trow("JenisKelamin") & "','" & Format(Trow("TglLahir"), "yyyyMMdd") & "','" & Trow("Umur") & " Tahun','" & Trow("DomisiliAlamat") & "','" & Trow("DrNama") & "',NOW(),'" & Trow("NoRekamMedis") & "')", TtconU)
                    End If
                Next
            End If
            MsgBox("Done. Send to Mesin")
        Else
            MsgBox("Ubah Config Mesin Diff dulu.", MessageBoxIcon.Information, "Note")
        End If
        If status_urine = "Yes" Then
            Dim TmesinUrine As DataTable = ReadSQL("SELECT b.NoUrut,b.TglLab,c.Nama,a.Mesin,a.TindakanID,a.NamaTindakan,f.DrNama,c.JenisKelamin,LEFT(c.DomisiliAlamat,100) as DomisiliAlamat,c.NoRekamMedis,c.TglLahir,DATEDIFF(YYYY, c.TglLahir, GETDATE()) as Umur " & _
                                                   "FROM transaksilabdetail a " & _
                                                   "LEFT JOIN TransaksiLab b on a.TransLabID=b.TransLabID " & _
                                                   "LEFT JOIN MasterPasien c on b.IDInternet=c.NoRekamMedis " & _
                                                   "LEFT JOIN MasterDokterTempatPraktek g on g.IdPraktek=b.DokterRequest " & _
                                                   "LEFT JOIN MasterDokterKirim f on f.IdKirim=g.IdKirim " & _
                                                   "WHERE  b.TransLabID='" & buttindakanid.Text & "' AND mesin = 'URINE' AND Mesin is not null AND LTRIM(RTRIM(Mesin))<>'' AND LTRIM(RTRIM(Mesin))<>'-'")
            If TmesinUrine.Rows.Count > 0 Then
                For Each Trow As DataRow In TmesinUrine.Rows
                    If CheckThemysql("SELECT * FROM order_lab WHERE no_lab='" & Strings.Replace(Strings.Replace(Strings.Right(Trow("NoUrut"), Len(Trow("NoUrut")) - 2), "L", "8"), "M", "9") & "' AND tgl_order='" & Format(Trow("TglLab"), "yyyyMMdd") & "'", TtconU) = False Then
                        WriteThemysql("INSERT INTO order_lab(`no_lab`, `tgl_order`, `nama_pas`, `jenis_kel`, `tgl_lahir`, `usia`,`alamat`,`nama_dok`,`usertime`, `no_rm`) " & _
                                 " VALUES('" & Strings.Replace(Strings.Replace(Strings.Right(Trow("NoUrut"), Len(Trow("NoUrut")) - 2), "L", "8"), "M", "9") & "','" & Format(Trow("TglLab"), "yyyyMMdd") & "','" & Trow("Nama") & "','" & Trow("JenisKelamin") & "','" & Format(Trow("TglLahir"), "yyyyMMdd") & "','" & Trow("Umur") & " Tahun','" & Trow("DomisiliAlamat") & "','" & Trow("DrNama") & "',NOW(),'" & Trow("NoRekamMedis") & "')", TtconU)
                    End If
                Next
            End If
            MsgBox("Done. Data Urine Send to Mesin")
        End If
    End Sub

    Private Sub ResendToMesinToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResendToMesinToolStripMenuItem.Click
        Ttmesin.Tid = "root"
        Ttmesin.Tip = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='TIP'")
        Ttmesin.Tdb = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='TDB'")
        Ttmesin.Tpass = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='TPass'")

        Dim KodeBarcode As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='KodeBarcode'")
        Dim status_urine As String = Utility.GetConfig("MesinUrine")
        Dim Tdiff As Integer = Utility.GetConfig("MesinDiff")
        If status_urine = "Yes" Or Tdiff = 3 Then
            TtconU.Tid = "root"
            TtconU.Tip = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='TIP_Urine'")
            TtconU.Tdb = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='TDB_Urine'")
            TtconU.Tpass = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='TPass_Urine'")
        End If

        If TextBoxNoTransaksi.Text = "" Then
            MsgBox("Pilih Pasien Lab yang akan dikirim.")
            Exit Sub
        End If
        'If CheckSQL("SELECT * FROM Transaksilab WHERE NoUrut='" & txtindakanid.Text & "' AND Status in ('CLOSED','TAKEIT','NEW')") = True Then
        '    MsgBox("Hasil sudah ter-print / Terkirim / Terkunci. Tidak dapat di-edit kembali.")
        '    Exit Sub
        'End If

        Dim Tmesin As DataTable = ReadSQL("SELECT TindakanID " & _
                                          "FROM TransaksiLabDetail " & _
                                          "WHERE TransLabID='" & buttindakanid.Text & "'")
        For Each Rrow As DataRow In Tmesin.Rows
            If CheckSQL("SELECT * FROM masterlab WHERE TindakanID='" & Rrow("TindakanID") & "' AND Mesin='TMS'") = True Then
                WriteSQL("Update transaksilabdetail set Mesin='TMS' WHERE TransLabID='" & buttindakanid.Text & "' AND TindakanID='" & Rrow("TindakanID") & "'", 4)
            ElseIf CheckSQL("SELECT * FROM masterlab WHERE TindakanID='" & Rrow("TindakanID") & "' AND Mesin='SYSMEX'") = True Then
                WriteSQL("Update transaksilabdetail set Mesin='SYSMEX' WHERE TransLabID='" & buttindakanid.Text & "' AND TindakanID='" & Rrow("TindakanID") & "'", 4)
            ElseIf CheckSQL("SELECT * FROM masterlab WHERE TindakanID='" & Rrow("TindakanID") & "' AND Mesin='CL900'") = True Then
                WriteSQL("Update transaksilabdetail set Mesin='CL900' WHERE TransLabID='" & buttindakanid.Text & "' AND TindakanID='" & Rrow("TindakanID") & "'", 4)
            ElseIf CheckSQL("SELECT * FROM masterlab WHERE TindakanID='" & Rrow("TindakanID") & "' AND Mesin='C0BAS6600'") = True Then
                WriteSQL("Update transaksilabdetail set Mesin='C0BAS6600' WHERE TransLabID='" & buttindakanid.Text & "' AND TindakanID='" & Rrow("TindakanID") & "'", 4)
            ElseIf CheckSQL("SELECT * FROM masterlab WHERE TindakanID='" & Rrow("TindakanID") & "' AND Mesin='URINE'") = True Then
                If status_urine = "Yes" Then
                    WriteSQL("Update transaksilabdetail set Mesin='URINE' WHERE TransLabID='" & buttindakanid.Text & "' AND TindakanID='" & Rrow("TindakanID") & "'", 4)
                End If
            Else
                WriteSQL("Update transaksilabdetail set Mesin='' WHERE TransLabID='" & buttindakanid.Text & "' AND TindakanID='" & Rrow("TindakanID") & "'", 4)
            End If
        Next

        If Utility.GetConfig("DualMesin") = "Yes" Then
            OptionDialog.LoadOptionDialog(buttindakanid.Text, 0, "ResendToMesin")
            OptionDialog.ShowDialog()
        Else
            If buttindakanid.Text <> "" And Tdiff = 3 Then
                Dim Tmesin3 As DataTable = ReadSQL("SELECT b.NoUrut,b.TglLab,c.Nama,a.Mesin,a.TindakanID,a.NamaTindakan,f.DrNama,c.JenisKelamin,LEFT(c.DomisiliAlamat,100) as DomisiliAlamat,c.NoRekamMedis,c.TglLahir,DATEDIFF(YYYY, c.TglLahir, GETDATE()) as Umur " & _
                                                   "FROM TransaksiLabDetail a " & _
                                                   "LEFT JOIN TransaksiLab b on a.TransLabID = b.TransLabID " & _
                                                   "LEFT JOIN MasterPasien c on b.IDInternet=c.NoRekamMedis " & _
                                                   "LEFT JOIN MasterDokterTempatPraktek g on g.IdPraktek=b.DokterRequest " & _
                                                   "LEFT JOIN MasterDokterKirim f on f.IdKirim=g.IdKirim " & _
                                                   "WHERE  b.TransLabID='" & buttindakanid.Text & "' AND mesin<>'URINE' AND Mesin is not null AND LTRIM(RTRIM(Mesin))<>'' AND LTRIM(RTRIM(Mesin))<>'-'")
                If Tmesin3.Rows.Count > 0 Then
                    For Each Trow As DataRow In Tmesin3.Rows
                        If CheckThemysql("SELECT * FROM order_lab WHERE no_lab='" & KodeBarcode & Strings.Replace(Strings.Replace(Strings.Right(Trow("NoUrut"), Len(Trow("NoUrut")) - 2), "L", "8"), "M", "9") & "' AND tgl_order='" & Format(Trow("TglLab"), "yyyyMMdd") & "'", TtconU) = False Then
                            WriteThemysql("INSERT INTO order_lab(`no_lab`, `tgl_order`, `nama_pas`, `jenis_kel`, `tgl_lahir`, `usia`,`alamat`,`nama_dok`,`usertime`, `no_rm`) " & _
                                     " VALUES('" & KodeBarcode & Strings.Replace(Strings.Replace(Strings.Right(Trow("NoUrut"), Len(Trow("NoUrut")) - 2), "L", "8"), "M", "9") & "','" & Format(Trow("TglLab"), "yyyyMMdd") & "','" & Trow("Nama") & "','" & Trow("JenisKelamin") & "','" & Format(Trow("TglLahir"), "yyyyMMdd") & "','" & Trow("Umur") & " Tahun','" & Trow("DomisiliAlamat") & "','" & Trow("DrNama") & "',NOW(),'" & Trow("NoRekamMedis") & "')", TtconU)
                            'Else
                            '    MsgBox("Data sudah ada di Database", MessageBoxIcon.Information, "Note")
                            '    Exit Sub
                        End If
                    Next
                End If
                MsgBox("Done. Send to Mesin")
            Else
                Tmesin = ReadSQL("SELECT b.NoUrut,b.TglLab,c.Nama,a.Mesin,a.TindakanID,a.NamaTindakan,f.DrNama,c.JenisKelamin,LEFT(c.DomisiliAlamat,100) as DomisiliAlamat,c.NoRekamMedis,c.TglLahir " & _
                                 "FROM transaksilabdetail a " & _
                                 "LEFT JOIN TransaksiLab b on a.TransLabID=b.TransLabID " & _
                                 "LEFT JOIN MasterPasien c on b.IDInternet=c.NoRekamMedis " & _
                                 "LEFT JOIN MasterDokterTempatPraktek g on g.IdPraktek=b.DokterRequest " & _
                                 "LEFT JOIN MasterDokterKirim f on f.IdKirim=g.IdKirim " & _
                                 "WHERE  b.TransLabID='" & buttindakanid.Text & "' AND mesin<>'URINE' AND Mesin is not null AND LTRIM(RTRIM(Mesin))<>'' AND LTRIM(RTRIM(Mesin))<>'-'")
                If Tmesin.Rows.Count > 0 Then
                    For Each Trow As DataRow In Tmesin.Rows
                        If CheckThemysql("SELECT * FROM paslab WHERE NoUrut='" & KodeBarcode & Strings.Replace(Strings.Replace(Strings.Right(Trow("NoUrut"), Len(Trow("NoUrut")) - 2), "L", "8"), "M", "9") & "' AND TglLab='" & Format(Trow("TglLab"), "yyyyMMdd") & "' AND Instrument='" & Trow("Mesin") & "' AND kode_jasa='" & Trow("TindakanID") & "' AND nama_jasa='" & Trow("NamaTindakan") & "'", Ttmesin) = False Then
                            WriteThemysql("INSERT INTO paslab(`NoUrut`, `TglLab`, `Nama`, `Instrument`, `kode_jasa`, `nama_jasa`,`nama_dok`,`sex`,`alamat`,`no_rm`,`tgl_lahir`) " & _
                                     " VALUES('" & KodeBarcode & Strings.Replace(Strings.Replace(Strings.Right(Trow("NoUrut"), Len(Trow("NoUrut")) - 2), "L", "8"), "M", "9") & "','" & Format(Trow("TglLab"), "yyyyMMdd") & "','" & Trow("Nama") & "','" & Trow("Mesin") & "','" & Trow("TindakanID") & "','" & Trow("NamaTindakan") & "','-','" & Trow("JenisKelamin") & "','" & Trow("DomisiliAlamat") & "','" & Trow("NoRekamMedis") & "','" & Format(Trow("TglLahir"), "yyyyMMdd") & "')", Ttmesin)
                        End If
                    Next
                End If
            End If

            If status_urine = "Yes" Then
                Dim TmesinUrine As DataTable = ReadSQL("SELECT b.NoUrut,b.TglLab,c.Nama,a.Mesin,a.TindakanID,a.NamaTindakan,f.DrNama,c.JenisKelamin,LEFT(c.DomisiliAlamat,100) as DomisiliAlamat,c.NoRekamMedis,c.TglLahir,DATEDIFF(YYYY, c.TglLahir, GETDATE()) as Umur " & _
                                                       "FROM transaksilabdetail a " & _
                                                       "LEFT JOIN TransaksiLab b on a.TransLabID=b.TransLabID " & _
                                                       "LEFT JOIN MasterPasien c on b.IDInternet=c.NoRekamMedis " & _
                                                       "LEFT JOIN MasterDokterTempatPraktek g on g.IdPraktek=b.DokterRequest " & _
                                                       "LEFT JOIN MasterDokterKirim f on f.IdKirim=g.IdKirim " & _
                                                       "WHERE  b.TransLabID='" & buttindakanid.Text & "' AND mesin = 'URINE' AND Mesin is not null AND LTRIM(RTRIM(Mesin))<>'' AND LTRIM(RTRIM(Mesin))<>'-'")
                If TmesinUrine.Rows.Count > 0 Then
                    For Each Trow As DataRow In TmesinUrine.Rows
                        If CheckThemysql("SELECT * FROM order_lab WHERE no_lab='" & KodeBarcode & Strings.Replace(Strings.Replace(Strings.Right(Trow("NoUrut"), Len(Trow("NoUrut")) - 2), "L", "8"), "M", "9") & "' AND tgl_order='" & Format(Trow("TglLab"), "yyyyMMdd") & "'", TtconU) = False Then
                            WriteThemysql("INSERT INTO order_lab(`no_lab`, `tgl_order`, `nama_pas`, `jenis_kel`, `tgl_lahir`, `usia`,`alamat`,`nama_dok`,`usertime`, `no_rm`) " & _
                                     " VALUES('" & KodeBarcode & Strings.Replace(Strings.Replace(Strings.Right(Trow("NoUrut"), Len(Trow("NoUrut")) - 2), "L", "8"), "M", "9") & "','" & Format(Trow("TglLab"), "yyyyMMdd") & "','" & Trow("Nama") & "','" & Trow("JenisKelamin") & "','" & Format(Trow("TglLahir"), "yyyyMMdd") & "','" & Trow("Umur") & " Tahun','" & Trow("DomisiliAlamat") & "','" & Trow("DrNama") & "',NOW(),'" & Trow("NoRekamMedis") & "')", TtconU)
                        End If
                    Next
                End If
            End If
            MsgBox("Done. Send to Mesin")
        End If

    End Sub

    Private Sub butprintaudio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butprintaudio.Click
        If CheckSQL("SELECT * FROM TransaksiLabHasilLain WHERE [NoUrut]='" & TextBoxNoTransaksi.Text & "'") = True Then
            Dim TempWhatsapp As String = ""
            Dim TempEmail As String = ""

            Dim Tlab As DataTable = ReadSQL("SELECT d.*, b.NoNIK, a.caraambil, a.SendingWhatsapp, a.SendingEmail, c.JenisBayar, c.NoJenisBayar " & _
                                            "FROM transaksilab a " & _
                                            "LEFT JOIN MasterPasien b ON a.IDInternet = b.NoRekamMedis " & _
                                            "LEFT JOIN TransaksiLabBayar c on a.TransLabID=c.TransLabID " & _
                                            "LEFT JOIN TransaksiLabHasilLain d on a.NoUrut=d.NoUrut " & _
                                            "WHERE a.TransLabID='" & buttindakanid.Text & "'")
            Dim TrowLab As DataRow = Tlab.Rows(0)
            Dim Tsimpul As String = ""
            Dim Tsaran As String = ""
            Dim noNIK As String = ""
            Dim Pengirim As String = ""
            If IsDBNull(TrowLab("NoNIK")) = False Then noNIK = TrowLab("NoNIK") Else noNIK = "-"
            Dim caraambil As String = TrowLab("caraambil")
            If CheckSQL("SELECT * FROM MasterCompany WHERE NoCompany = '" & txcodepenagihan.Text.Trim & "' AND ReportHasilPerusahaan = 0") = True And TextBoxNoTransaksi.Text.Contains("M") = True Then
                Pengirim = "Atas Permintaan Sendiri"
            End If

            If IsDBNull(TrowLab("SendingWhatsapp")) = False And TrowLab("SendingWhatsapp").ToString.Trim <> "-" Then
                NoWhatsappCustomer = TrowLab("SendingWhatsapp")
                TempWhatsapp = NoWhatsappCustomer.Substring(0, 3) & "*****" & NoWhatsappCustomer.Substring(8, NoWhatsappCustomer.Length - 8)
                caraambil = caraambil.Replace(NoWhatsappCustomer, TempWhatsapp)
            Else
                NoWhatsappCustomer = "-"
            End If

            If IsDBNull(TrowLab("SendingEmail")) = False And TrowLab("SendingEmail").ToString.Trim <> "-" Then
                EmailCustomer = TrowLab("SendingEmail")
                TempEmail = EmailCustomer.Substring(0, 3) & "*****" & EmailCustomer.Substring(8, EmailCustomer.Length - 8)
                caraambil = caraambil.Replace(EmailCustomer, TempEmail)
            Else
                EmailCustomer = "-"
            End If

            insertRowToTbls(Tlab, "typstring", "Registrasi")
            insertRowToTbls(Tlab, "typstring", "Nama")
            insertRowToTbls(Tlab, "typstring", "Umur")
            insertRowToTbls(Tlab, "typstring", "Alamat")
            insertRowToTbls(Tlab, "typstring", "NoTransaksi")
            insertRowToTbls(Tlab, "typstring", "DrPelaksana")
            insertRowToTbls(Tlab, "typstring", "DrRequest")
            insertRowToTbls(Tlab, "typstring", "Tanggal")
            insertRowToTbls(Tlab, "typstring", "Hasil")

            For Each Trow As DataRow In Tlab.Rows
                Trow("Registrasi") = TextBoxNoRekamMedis.Text

                If (TextBoxNoTransaksi.Text.Contains("M")) Then
                    If IsNumeric(Trow("Nama")) = True Then
                        Trow("Nama") = TextBoxGelar.Text & " " & TextBoxNamaPasien.Text & "/(" & TextBoxJenisKelamin.Text & ")" & vbCrLf
                    Else
                        Trow("Nama") = TextBoxGelar.Text & " " & TextBoxNamaPasien.Text & " / " & noNIK & " (" & TextBoxJenisKelamin.Text & ")" & vbCrLf
                    End If
                Else
                    Trow("Nama") = TextBoxGelar.Text & " " & TextBoxNamaPasien.Text & "/(" & TextBoxJenisKelamin.Text & ")" & vbCrLf
                End If

                Dim Tgltemp As Date = DateTimeTanggalLahir.Value
                If Tgltemp.Date.AddYears(120).Year < DateAndTime.Now.Year Then
                    Trow("Umur") = ""
                Else
                    Trow("Umur") = Format(DateTimeTanggalLahir.Value, "dd MMM yyyy") & " / " & TextBoxUmur.Text
                End If

                Trow("Alamat") = txalamat.Text
                Trow("NoTransaksi") = TextBoxNoTransaksi.Text & " (" & buttindakanid.Text & ")"
                Trow("DrPelaksana") = DrPelaksanaKlinik
                Trow("Hasil") = caraambil
                If Pengirim <> "" Then
                    Trow("DrRequest") = Pengirim
                Else
                    If (TextBoxNoTransaksi.Text.Contains("M")) Then
                        Trow("DrRequest") = txpenagihan.Text.Trim
                    Else
                        Trow("DrRequest") = butdokter.Text
                    End If
                End If

                Trow("Tanggal") = Format(DateTimeTanggalTransaksi.Value, "dd-MMM-yyyy")
            Next

            Report = New XtraReport
            Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\Hasil\HasilLabAudiometriNonKop.repx", True)
            If AutoTTD.Trim = "Yes" Then
                Report.Bands.Item(BandKind.PageHeader).Controls("ttd").Visible = True
                Report.Bands.Item(BandKind.PageHeader).Controls("ttd").Height = 59
                Report.Bands.Item(BandKind.PageHeader).Controls("ttd").Width = 275
            Else
                Report.Bands.Item(BandKind.PageHeader).Controls("ttd").Visible = False
            End If

            Report.DataSource = Tlab
            Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MM-yyyy HH:mm:ss") + " by " + UserLabAdmin

            'Report.RunDesigner()
            'Report.ShowPreview()
            Report.Print()
        End If
    End Sub

    Private Sub butprintusg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butprintusg.Click
        If CheckSQL("SELECT * FROM TransaksiLabHasilLain WHERE [NoUrut]='" & TextBoxNoTransaksi.Text & "'") Then
            Dim Tempecg As DataTable = ReadSQL("SELECT * FROM TransaksiLabHasilLain WHERE [NoUrut]='" & TextBoxNoTransaksi.Text & "'")
            insertRowToTbls(Tempecg, "typstring", "Registrasi")
            insertRowToTbls(Tempecg, "typstring", "Nama")
            insertRowToTbls(Tempecg, "typstring", "Umur")
            insertRowToTbls(Tempecg, "typstring", "Alamat")
            insertRowToTbls(Tempecg, "typstring", "NoTransaksi")
            insertRowToTbls(Tempecg, "typstring", "DrPelaksana")
            insertRowToTbls(Tempecg, "typstring", "DrRequest")
            insertRowToTbls(Tempecg, "typstring", "Tanggal")
            Dim noNIK As String = ReadSQLNIK("SELECT NoNIK FROM MasterPasien WHERE NoRekamMedis = '" & TextBoxNoRekamMedis.Text & "'")

            For Each Trow As DataRow In Tempecg.Rows
                Trow("Registrasi") = TextBoxNoRekamMedis.Text
                If (TextBoxNoTransaksi.Text.Contains("M")) Then
                    If IsNumeric(Trow("Nama")) = True Then
                        Trow("Nama") = TextBoxGelar.Text & " " & TextBoxNamaPasien.Text & "/(" & TextBoxJenisKelamin.Text & ")" & vbCrLf
                    Else
                        Trow("Nama") = TextBoxGelar.Text & " " & TextBoxNamaPasien.Text & " / " & noNIK & " (" & TextBoxJenisKelamin.Text & ")" & vbCrLf
                    End If
                Else
                    Trow("Nama") = TextBoxGelar.Text & " " & TextBoxNamaPasien.Text & "/(" & TextBoxJenisKelamin.Text & ")" & vbCrLf
                End If
                Dim Tgltemp As Date = DateTimeTanggalLahir.Value
                If Tgltemp.Date.AddYears(120).Year < DateAndTime.Now.Year Then
                    Trow("Umur") = ""
                Else
                    Trow("Umur") = Format(DateTimeTanggalLahir.Value, "dd MMM yyyy") & " / " & TextBoxUmur.Text
                End If
                Trow("Alamat") = ReadSQLNIK("SELECT DomisiliAlamat FROM MasterPasien WHERE NoRekamMedis='" & TextBoxNoRekamMedis.Text & "'")
                Trow("NoTransaksi") = TextBoxNoTransaksi.Text & " (" & buttindakanid.Text & ")"
                Trow("DrPelaksana") = DrPelaksanaKlinik
                Trow("DrRequest") = butdokter.Text
                Trow("Tanggal") = Format(DateTimeTanggalTransaksi.Value, "dd-MMM-yyyy")
            Next

            Report = New XtraReport
            Report = XtraReport.FromFile(Application.StartupPath + "\reports\PrintHasilLabUSG.repx", True)
            Report.DataSource = Tempecg
            Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:ss") + UserLabAdmin
            Report.Bands.Item(BandKind.PageHeader).Controls("DokterUSG").Text = ReadSQLNIK("SELECT DrUSG FROM TransaksiLabHasilLain WHERE NoUrut='" & TextBoxNoTransaksi.Text & "'")

            'Report.RunDesigner()
            Report.ShowPreview()
            Report.Print()
        End If
    End Sub

    Private Sub butprinttreadmill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butprinttreadmill.Click
        If CheckSQL("SELECT * FROM TransaksiLabHasilLain WHERE [NoUrut]='" & TextBoxNoTransaksi.Text & "'") Then
            Dim noNIK As String = ReadSQLNIK("SELECT NoNIK FROM MasterPasien WHERE NoRekamMedis = '" & TextBoxNoRekamMedis.Text & "'")
            Dim Tempecg As DataTable = ReadSQL("SELECT * FROM TransaksiLabHasilLain WHERE [NoUrut]='" & TextBoxNoTransaksi.Text & "'")
            insertRowToTbls(Tempecg, "typstring", "Registrasi")
            insertRowToTbls(Tempecg, "typstring", "Nama")
            insertRowToTbls(Tempecg, "typstring", "Umur")
            insertRowToTbls(Tempecg, "typstring", "Alamat")
            insertRowToTbls(Tempecg, "typstring", "NoTransaksi")
            insertRowToTbls(Tempecg, "typstring", "DrPelaksana")
            insertRowToTbls(Tempecg, "typstring", "DrRequest")
            insertRowToTbls(Tempecg, "typstring", "Tanggal")

            For Each Trow As DataRow In Tempecg.Rows
                Trow("Registrasi") = TextBoxNoRekamMedis.Text
                If (TextBoxNoTransaksi.Text.Contains("M")) Then
                    If IsNumeric(Trow("Nama")) = True Then
                        Trow("Nama") = TextBoxGelar.Text & " " & TextBoxNamaPasien.Text & "/(" & TextBoxJenisKelamin.Text & ")" & vbCrLf
                    Else
                        Trow("Nama") = TextBoxGelar.Text & " " & TextBoxNamaPasien.Text & " / " & noNIK & " (" & TextBoxJenisKelamin.Text & ")" & vbCrLf
                    End If
                Else
                    Trow("Nama") = TextBoxGelar.Text & " " & TextBoxNamaPasien.Text & "/(" & TextBoxJenisKelamin.Text & ")" & vbCrLf
                End If
                Dim Tgltemp As Date = DateTimeTanggalLahir.Value
                If Tgltemp.Date.AddYears(120).Year < DateAndTime.Now.Year Then
                    Trow("Umur") = ""
                Else
                    Trow("Umur") = Format(DateTimeTanggalLahir.Value, "dd MMM yyyy") & " / " & TextBoxUmur.Text
                End If
                Trow("Alamat") = ReadSQLNIK("SELECT DomisiliAlamat FROM MasterPasien WHERE NoRekamMedis='" & TextBoxNoRekamMedis.Text & "'")
                Trow("NoTransaksi") = TextBoxNoTransaksi.Text & " (" & buttindakanid.Text & ")"
                Trow("DrPelaksana") = DrPelaksanaKlinik
                Trow("DrRequest") = butdokter.Text
                Trow("Tanggal") = Format(DateTimeTanggalTransaksi.Value, "dd-MMM-yyyy")
            Next

            Report = New XtraReport
            Report = XtraReport.FromFile(Application.StartupPath + "\reports\PrintHasilLabTreadmill.repx", True)
            Report.DataSource = Tempecg
            Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:ss") + UserLabAdmin
            Report.Bands.Item(BandKind.PageHeader).Controls("DokterTreadmill").Text = ReadSQLNIK("SELECT Drtreadmill FROM TransaksiLabHasilLain WHERE NoUrut='" & TextBoxNoTransaksi.Text & "'")

            'Report.RunDesigner()
            Report.ShowPreview()
            Report.Print()
        End If
    End Sub

    Private Sub butprintspiro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butprintspiro.Click
        If CheckSQL("SELECT * FROM TransaksiLabHasilLain WHERE [NoUrut]='" & TextBoxNoTransaksi.Text & "'") Then
            Dim Tempecg As DataTable = ReadSQL("SELECT * FROM TransaksiLabHasilLain WHERE [NoUrut]='" & TextBoxNoTransaksi.Text & "'")
            insertRowToTbls(Tempecg, "typstring", "Registrasi")
            insertRowToTbls(Tempecg, "typstring", "Nama")
            insertRowToTbls(Tempecg, "typstring", "Umur")
            insertRowToTbls(Tempecg, "typstring", "Alamat")
            insertRowToTbls(Tempecg, "typstring", "NoTransaksi")
            insertRowToTbls(Tempecg, "typstring", "DrPelaksana")
            insertRowToTbls(Tempecg, "typstring", "DrRequest")
            insertRowToTbls(Tempecg, "typstring", "Tanggal")
            Dim noNIK As String = ReadSQLNIK("SELECT NoNIK FROM MasterPasien WHERE NoRekamMedis = '" & TextBoxNoRekamMedis.Text & "'")

            For Each Trow As DataRow In Tempecg.Rows
                Trow("Registrasi") = TextBoxNoRekamMedis.Text
                If (TextBoxNoTransaksi.Text.Contains("M")) Then
                    If IsNumeric(Trow("Nama")) = True Then
                        Trow("Nama") = TextBoxGelar.Text & " " & TextBoxNamaPasien.Text & "/(" & TextBoxJenisKelamin.Text & ")" & vbCrLf
                    Else
                        Trow("Nama") = TextBoxGelar.Text & " " & TextBoxNamaPasien.Text & " / " & noNIK & " (" & TextBoxJenisKelamin.Text & ")" & vbCrLf
                    End If
                Else
                    Trow("Nama") = TextBoxGelar.Text & " " & TextBoxNamaPasien.Text & "/(" & TextBoxJenisKelamin.Text & ")" & vbCrLf
                End If
                Dim Tgltemp As Date = DateTimeTanggalLahir.Value
                If Tgltemp.Date.AddYears(120).Year < DateAndTime.Now.Year Then
                    Trow("Umur") = ""
                Else
                    Trow("Umur") = Format(DateTimeTanggalLahir.Value, "dd MMM yyyy") & " / " & TextBoxUmur.Text
                End If
                Trow("Alamat") = ReadSQLNIK("SELECT DomisiliAlamat FROM MasterPasien WHERE NoRekamMedis='" & TextBoxNoRekamMedis.Text & "'")
                Trow("NoTransaksi") = TextBoxNoTransaksi.Text & " (" & buttindakanid.Text & ")"
                Trow("DrPelaksana") = DrPelaksanaKlinik
                Trow("DrRequest") = butdokter.Text
                Trow("Tanggal") = Format(DateTimeTanggalTransaksi.Value, "dd-MMM-yyyy")
            Next

            Report = New XtraReport
            Report = XtraReport.FromFile(Application.StartupPath + "\reports\PrintHasilLabSpiro.repx", True)
            Report.DataSource = Tempecg
            Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:ss") + UserLabAdmin
            Report.Bands.Item(BandKind.PageHeader).Controls("DokterSpiro").Text = ReadSQLNIK("SELECT DrSpiro FROM TransaksiLabHasilLain WHERE NoUrut='" & TextBoxNoTransaksi.Text & "'")

            'Report.RunDesigner()
            Report.ShowPreview()
            Report.Print()
        End If
    End Sub

    Private Sub butfindtindakanid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butfindtindakanid.Click
        Dim Thasil As Date = DateAndTime.Now
        Dim Takhir As Date = DateSerial(Thasil.Year, Thasil.Month, Thasil.Day)
        Dim Tawal As Date = "01/01/2001"

        If cmbrangedate.SelectedIndex = 0 Then
            Tawal = DateAdd(DateInterval.Month, -6, Takhir.Date)
        ElseIf cmbrangedate.SelectedIndex = 1 Then
            Tawal = DateAdd(DateInterval.Month, -12, Takhir.Date)
        End If

        Find.Query("SELECT a.TransLabID, a.NoUrut, b.Nama, b.DomisiliAlamat, a.TglLab " & _
                   "FROM TransaksiLab a " & _
                   "LEFT JOIN MasterPasien b on a.IDInternet = b.NoRekamMedis " & _
                   "WHERE ( a.Status='CHECK' or a.Status='CHECK2' or a.Status='CETAK' or a.Status='CLOSED' or a.Status='TAKEIT') AND CONVERT(date, a.Tgllab) between '" & Format(Tawal.Date, "yyyy-MM-dd") & "' AND '" & Format(Takhir.Date, "yyyy-MM-dd") & "'  AND a.deleted<>1 AND LabStartTime is not null", " order by a.TransLabID desc ", "FindInputLab", 0)
        Find.Show()
    End Sub

    Private Sub ChangeDatawithText(ByVal Tcmb As System.Windows.Forms.ComboBox, ByVal Txid As System.Windows.Forms.TextBox)
        If Tcmb.Text.Contains("...") = True Then
            Txid.Enabled = True
            Txid.ResetText()
            Txid.Focus()
        Else
            Txid.Enabled = False
            Txid.ResetText()
        End If
    End Sub

    Private Sub cmbkepala_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbkepala.SelectedIndexChanged
        If cmbkepala.FindStringExact(cmbkepala.Text) > 0 Then ChangeDatawithText(cmbkepala, txkepala)
    End Sub

    Private Sub cmbrambut_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbrambut.SelectedIndexChanged
        If cmbrambut.FindStringExact(cmbrambut.Text) > 0 Then ChangeDatawithText(cmbrambut, txrambut)
    End Sub

    Private Sub cmbmuka_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbmuka.SelectedIndexChanged
        If cmbmuka.FindStringExact(cmbmuka.Text) > 0 Then ChangeDatawithText(cmbmuka, txmuka)
    End Sub

    Private Sub cmbmata_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbmata.SelectedIndexChanged
        If cmbmata.FindStringExact(cmbmata.Text) > 0 Then ChangeDatawithText(cmbmata, txmata)
    End Sub

    Private Sub cmbtelinga_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtelinga.SelectedIndexChanged, cmbtelinga.SelectedIndexChanged
        If cmbtelinga.FindStringExact(cmbtelinga.Text) > 0 Then ChangeDatawithText(cmbtelinga, txtelinga)
    End Sub

    Private Sub cmbhidung_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbhidung.SelectedIndexChanged
        If cmbhidung.FindStringExact(cmbhidung.Text) > 0 Then ChangeDatawithText(cmbhidung, txhidung)
    End Sub

    Private Sub cmbmulut_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbmulut.SelectedIndexChanged
        If cmbmulut.FindStringExact(cmbmulut.Text) > 0 Then ChangeDatawithText(cmbmulut, txmulut)
    End Sub

    Private Sub cmbgigi_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbgigi.SelectedIndexChanged
        If cmbgigi.FindStringExact(cmbgigi.Text) > 0 Then ChangeDatawithText(cmbgigi, txgigi)
    End Sub

    Private Sub cmblidah_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmblidah.SelectedIndexChanged
        If cmblidah.FindStringExact(cmblidah.Text) > 0 Then ChangeDatawithText(cmblidah, txlidah)
    End Sub

    Private Sub cmbtenggorokan_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtenggorokan.SelectedIndexChanged
        If cmbtenggorokan.FindStringExact(cmbtenggorokan.Text) > 0 Then ChangeDatawithText(cmbtenggorokan, txtenggorokan)
    End Sub

    Private Sub cmbleher_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbleher.SelectedIndexChanged
        If cmbleher.FindStringExact(cmbleher.Text) > 0 Then ChangeDatawithText(cmbleher, txleher)
    End Sub

    Private Sub cmbdada_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbdada.SelectedIndexChanged
        If cmbdada.FindStringExact(cmbdada.Text) > 0 Then ChangeDatawithText(cmbdada, txdada)
    End Sub

    Private Sub ComboBoxFisikPerut_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxFisikPerut.SelectedIndexChanged
        If ComboBoxFisikPerut.FindStringExact(ComboBoxFisikPerut.Text) > 0 Then ChangeDatawithText(ComboBoxFisikPerut, TextBoxFisikPerut)
    End Sub

    Private Sub ComboBoxFisikRectalToucher_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxFisikRectalToucher.SelectedIndexChanged
        If ComboBoxFisikRectalToucher.FindStringExact(ComboBoxFisikRectalToucher.Text) > 0 Then ChangeDatawithText(ComboBoxFisikRectalToucher, TextBoxFisikRectalToucher)
    End Sub

    Private Sub cmbintegumen_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbintegumen.SelectedIndexChanged
        If cmbintegumen.FindStringExact(cmbintegumen.Text) > 0 Then ChangeDatawithText(cmbintegumen, txintegumen)
    End Sub

    Private Sub cmbekstemitas_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbekstemitas.SelectedIndexChanged
        If cmbekstemitas.FindStringExact(cmbekstemitas.Text) > 0 Then ChangeDatawithText(cmbekstemitas, txekstemitas)
    End Sub

    Private Sub cmbbutawarna_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbbutawarna.SelectedIndexChanged
        If cmbbutawarna.FindStringExact(cmbbutawarna.Text) > 0 Then ChangeDatawithText(cmbbutawarna, txbutwarna)
    End Sub

    Function CheckingCombo(ByVal Tcombo As System.Windows.Forms.ComboBox, ByVal Txid As System.Windows.Forms.TextBox) As Boolean
        If Tcombo.Text = "" Then
            MsgBox("Data tidak boleh kosong. ")
            Tcombo.Focus()
            Return False
        Else
            If Tcombo.FindStringExact(Tcombo.Text) > 0 Then
                If Tcombo.Text.Contains("...") = True Then
                    If Txid.Text = "" Then
                        MsgBox("Isi data tindakan detail")
                        Txid.Focus()
                        Return False
                    Else
                        Txid.Text = Strings.Replace(Strings.Replace(Strings.Replace(Txid.Text, "'", ""), """", ""), "`", "")
                    End If
                End If
            End If
        End If

        Return True
    End Function

    Private Sub SaveFisikNew(ByVal FisikID As String, ByVal cmbdata As String, ByVal txdata As String, ByVal Status As Boolean, ByVal FisikKet As String)
        Dim Thasil As String = ""
        Dim Tdimana As String = ""
        Dim Tkenapa As String = ""
        Dim Tjenis As String = ""
        Dim Tkapan As String = ""

        If cmbdata.ToString.Contains("...") = True Then
            Thasil = cmbdata.ToString + "~" + txdata.ToString
            Thasil = ValueKesimpulan(Thasil)
        Else
            Thasil = cmbdata.ToString
        End If

        'Format =>>> hasil # dimana # kenapa # jenis # kapan #
        Dim Tdetailhasil() As String = Thasil.Split("#")
        If Thasil.Contains("#") = True Then
            Thasil = Tdetailhasil(0)
            Tdimana = Tdetailhasil(1)
            Tkenapa = Tdetailhasil(2)
            Tjenis = Tdetailhasil(3)
            Tkapan = Tdetailhasil(4)
        End If

        If Status = True Then
            '1=update
            WriteSQL("Update TransaksiLabFisik set Dimana='" & Tdimana & "', Kenapa='" & Tkenapa & "',Jenis='" & Tjenis & "', Kapan='" & Tkapan & "', Result='" & Thasil & "',UpdateDate=getdate(),UpdateBy='" & UserLabAdmin & "' WHERE NoUrut='" & TextBoxNoTransaksi.Text & "' AND FisikNoUrut='" & FisikID & "' AND FisikKet='" & FisikKet & "'", 4)
        ElseIf Status = False Then
            '0=new 
            Dim Txfisik As String = ReadSQLNIK("SELECT FisikKet FROM masterlabFisik WHERE FisikNoUrut='" & FisikID & "'")
            WriteSQL("INSERT INTO TransaksiLabFisik(NoUrut,FisikNoUrut,FisikKet,Result,CreateDate,CreateBy, Dimana, Kenapa, Jenis, Kapan) VALUES('" & TextBoxNoTransaksi.Text & "','" & FisikID & "','" & Txfisik & "','" & Thasil & "',getdate(),'" & UserLabAdmin & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "')", 4)
        End If
    End Sub

    Private Sub butfisiknewsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butfisiknewsave.Click
        If CheckingSaranKetrangan() = True Then
            ' Set Saran Keterangan
            SetSaranKeterangan()

            Select Case MsgBox("Pastikan data yang anda simpan sudah di set kerangan/saran. Yakin untuk menyimpan data fisik?", MsgBoxStyle.YesNo, "Question.")
                Case MsgBoxResult.Yes
                    Dim Tbls As DataTable = ReadSQL("SELECT FisikNoUrut, FisikKet FROM TransaksiLabFisik WHERE NoUrut='" & TextBoxNoTransaksi.Text & "'")
                    If Tbls.Rows.Count > 0 Then
                        For Each Trow As DataRow In Tbls.Rows
                            If Trow("FisikNoUrut") = txriwayat.Tag.ToString Then SaveFisikNew(txriwayat.Tag.ToString, txriwayat.Text, "", 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = TextBoxTinggiBadan.Tag.ToString Then SaveFisikNew(TextBoxTinggiBadan.Tag.ToString, TextBoxTinggiBadan.Text, "", 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = TextBoxBeratBadan.Tag.ToString Then SaveFisikNew(TextBoxBeratBadan.Tag.ToString, TextBoxBeratBadan.Text, "", 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = TextBoxSuhu.Tag.ToString Then SaveFisikNew(TextBoxSuhu.Tag.ToString, TextBoxSuhu.Text, "", 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = TextBoxDetakNadi.Tag.ToString Then SaveFisikNew(TextBoxDetakNadi.Tag.ToString, TextBoxDetakNadi.Text, "", 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = TextBoxSistole.Tag.ToString Then SaveFisikNew(TextBoxSistole.Tag.ToString, TextBoxSistole.Text & "/" & TextBoxDiastole.Text, "", 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = TextBoxNafas.Tag.ToString Then SaveFisikNew(TextBoxNafas.Tag.ToString, TextBoxNafas.Text, "", 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = txsimpul.Tag.ToString Then SaveFisikNew(txsimpul.Tag.ToString, txsimpul.Text, "", 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = txsaranfisik.Tag.ToString Then SaveFisikNew(txsaranfisik.Tag.ToString, txsaranfisik.Text, "", 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = cmbkesadaran.Tag.ToString Then SaveFisikNew(cmbkesadaran.Tag.ToString, cmbkesadaran.Text, "", 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = cmbkepala.Tag.ToString Then SaveFisikNew(cmbkepala.Tag.ToString, cmbkepala.Text, txkepala.Text, 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = cmbrambut.Tag.ToString Then SaveFisikNew(cmbrambut.Tag.ToString, cmbrambut.Text, txrambut.Text, 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = cmbmuka.Tag.ToString Then SaveFisikNew(cmbmuka.Tag.ToString, cmbmuka.Text, txmuka.Text, 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = cmbmata.Tag.ToString Then SaveFisikNew(cmbmata.Tag.ToString, cmbmata.Text, txmata.Text, 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = cmbbutawarna.Tag.ToString Then SaveFisikNew(cmbbutawarna.Tag.ToString, cmbbutawarna.Text, txbutwarna.Text, 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis

                            'Khusus Visus Mata dsb
                            If Trow("FisikNoUrut").ToString.Contains("3012") = True Or Trow("FisikNoUrut").ToString.Contains("3014") = True Then
                                WriteSQL("DELETE FROM TransaksiLabFisik WHERE NoUrut='" & TextBoxNoTransaksi.Text & "' AND FisikNoUrut IN (3012, 3013, 3014, 3015)", 4)

                                If txvisustanpakacamata.Text <> "" And txvisustanpakacamata2.Text <> "" Then
                                    SaveFisikNew(txvisustanpakacamata.Tag.ToString, txvisustanpakacamata.Text & "," & txvisustanpakacamata2.Text, "", 0, "")
                                Else
                                    SaveFisikNew(txvisustanpakacamata.Tag.ToString, "", "", 0, "")
                                End If

                                If txvisuskacamata.Text <> "" And txvisuskacamata2.Text <> "" Then
                                    SaveFisikNew(txvisuskacamata.Tag.ToString, txvisuskacamata.Text & "," & txvisuskacamata2.Text, "", 0, "")
                                Else
                                    SaveFisikNew(txvisuskacamata.Tag.ToString, "", "", 0, "")
                                End If

                                GoTo GoBackthis
                            End If

                            If Trow("FisikNoUrut") = txkoreksiakhir.Tag.ToString Then SaveFisikNew(txkoreksiakhir.Tag.ToString, txkoreksiakhir.Text, "", 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = cmbtelinga.Tag.ToString Then SaveFisikNew(cmbtelinga.Tag.ToString, cmbtelinga.Text, txtelinga.Text, 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = cmbhidung.Tag.ToString Then SaveFisikNew(cmbhidung.Tag.ToString, cmbhidung.Text, txhidung.Text, 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = cmbmulut.Tag.ToString Then SaveFisikNew(cmbmulut.Tag.ToString, cmbmulut.Text, txmulut.Text, 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = cmbgigi.Tag.ToString Then SaveFisikNew(cmbgigi.Tag.ToString, cmbgigi.Text, txgigi.Text, 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = cmblidah.Tag.ToString Then SaveFisikNew(cmblidah.Tag.ToString, cmblidah.Text, txlidah.Text, 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = cmbtenggorokan.Tag.ToString Then SaveFisikNew(cmbtenggorokan.Tag.ToString, cmbtenggorokan.Text, txtenggorokan.Text, 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = cmbleher.Tag.ToString Then SaveFisikNew(cmbleher.Tag.ToString, cmbleher.Text, txleher.Text, 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = cmbdada.Tag.ToString Then SaveFisikNew(cmbdada.Tag.ToString, cmbdada.Text, txdada.Text, 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = ComboBoxFisikPerut.Tag.ToString Then SaveFisikNew(ComboBoxFisikPerut.Tag.ToString, ComboBoxFisikPerut.Text, TextBoxFisikPerut.Text, 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = ComboBoxFisikRectalToucher.Tag.ToString Then SaveFisikNew(ComboBoxFisikRectalToucher.Tag.ToString, ComboBoxFisikRectalToucher.Text, TextBoxFisikRectalToucher.Text, 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = cmbintegumen.Tag.ToString Then SaveFisikNew(cmbintegumen.Tag.ToString, cmbintegumen.Text, txintegumen.Text, 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = cmbekstemitas.Tag.ToString Then SaveFisikNew(cmbekstemitas.Tag.ToString, cmbekstemitas.Text, txekstemitas.Text, 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = cmbturgor.Tag.ToString Then SaveFisikNew(cmbturgor.Tag.ToString, cmbturgor.Text, "", 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis

                            'Riwayat Kesehatan
                            If Trow("FisikNoUrut") = cmboperasi.Tag.ToString Then SaveFisikNew(cmboperasi.Tag.ToString, cmboperasi.Text & "#" & txdimanaoperasi.Text & "#" & txkenapaoperasi.Text & "##" & Format(dtkapanoperasi.Value, "MM-dd-yyyy"), "", 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = cmbrs.Tag.ToString Then SaveFisikNew(cmbrs.Tag.ToString, cmbrs.Text & "#" & txdimanars.Text & "#" & txkenapars.Text & "##" & Format(dtkapanrs.Value, "MM-dd-yyyy"), "", 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = cmbsehat.Tag.ToString Then SaveFisikNew(cmbsehat.Tag.ToString, cmbsehat.Text, "", 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = cmbobat.Tag.ToString Then SaveFisikNew(cmbobat.Tag.ToString, cmbobat.Text & "###" & txpenyakitobat.Text & "#01-01-1900", "", 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = cmbnarkoba.Tag.ToString Then SaveFisikNew(cmbnarkoba.Tag.ToString, cmbnarkoba.Text & "###" & txjenisnarkoba.Text & "#" & Format(dtkapannarkoba.Value, "MM-dd-yyyy"), "", 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis

                            'Penyakit mempengaruhi riwayat
                            If Trow("FisikNoUrut") = cmbhepatitis.Tag.ToString Then SaveFisikNew(cmbhepatitis.Tag.ToString, cmbhepatitis.Text & "####" & Format(dthepatitis.Value, "MM-dd-yyyy"), "", 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = cmbtbc.Tag.ToString Then SaveFisikNew(cmbtbc.Tag.ToString, cmbtbc.Text & "####" & Format(dttbc.Value, "MM-dd-yyyy"), "", 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = cmbhernia.Tag.ToString Then SaveFisikNew(cmbhernia.Tag.ToString, cmbhernia.Text & "####" & Format(dthernia.Value, "MM-dd-yyyy"), "", 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = cmbsakitjantung.Tag.ToString Then SaveFisikNew(cmbsakitjantung.Tag.ToString, cmbsakitjantung.Text & "####" & Format(dtjantung.Value, "MM-dd-yyyy"), "", 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = cmbhipertensi.Tag.ToString Then SaveFisikNew(cmbhipertensi.Tag.ToString, cmbhipertensi.Text & "####" & Format(dthipertensi.Value, "MM-dd-yyyy"), "", 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = cmbepilepsi.Tag.ToString Then SaveFisikNew(cmbepilepsi.Tag.ToString, cmbepilepsi.Text & "####" & Format(dtepilepsi.Value, "MM-dd-yyyy"), "", 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = cmbdiabetes.Tag.ToString Then SaveFisikNew(cmbdiabetes.Tag.ToString, cmbdiabetes.Text & "####" & Format(dtdiabetes.Value, "MM-dd-yyyy"), "", 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis

                            If Trow("FisikNoUrut") = cmbrokok.Tag.ToString Then SaveFisikNew(cmbrokok.Tag.ToString, cmbrokok.Text, "", 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = cmbalkohol.Tag.ToString Then SaveFisikNew(cmbalkohol.Tag.ToString, cmbalkohol.Text, "", 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = cmbkopi.Tag.ToString Then SaveFisikNew(cmbkopi.Tag.ToString, cmbkopi.Text, "", 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = cmbpolamakan.Tag.ToString Then SaveFisikNew(cmbpolamakan.Tag.ToString, cmbpolamakan.Text, "", 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = cmbistirahat.Tag.ToString Then SaveFisikNew(cmbistirahat.Tag.ToString, cmbistirahat.Text, "", 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = cmbolahraga.Tag.ToString Then SaveFisikNew(cmbolahraga.Tag.ToString, cmbolahraga.Text, "", 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = cmbtht.Tag.ToString Then SaveFisikNew(cmbtht.Tag.ToString, cmbtht.Text, "", 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = cmbanorexia.Tag.ToString Then SaveFisikNew(cmbanorexia.Tag.ToString, cmbanorexia.Text, "", 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = cmbmalaria.Tag.ToString Then SaveFisikNew(cmbmalaria.Tag.ToString, cmbmalaria.Text, "", 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = cmbkulit.Tag.ToString Then SaveFisikNew(cmbkulit.Tag.ToString, cmbkulit.Text, "", 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = cmbtypoid.Tag.ToString Then SaveFisikNew(cmbtypoid.Tag.ToString, cmbtypoid.Text, "", 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = cmbbbturun.Tag.ToString Then SaveFisikNew(cmbbbturun.Tag.ToString, cmbbbturun.Text, "", 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = cmbambien.Tag.ToString Then SaveFisikNew(cmbambien.Tag.ToString, cmbambien.Text, "", 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = cmbkencing.Tag.ToString Then SaveFisikNew(cmbkencing.Tag.ToString, cmbkencing.Text, "", 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = cmbvertigo.Tag.ToString Then SaveFisikNew(cmbvertigo.Tag.ToString, cmbvertigo.Text, "", 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = cmbpingsan.Tag.ToString Then SaveFisikNew(cmbpingsan.Tag.ToString, cmbpingsan.Text, "", 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = cmbgastritis.Tag.ToString Then SaveFisikNew(cmbgastritis.Tag.ToString, cmbgastritis.Text, "", 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
                            If Trow("FisikNoUrut") = cmbpusing.Tag.ToString Then SaveFisikNew(cmbpusing.Tag.ToString, cmbpusing.Text, "", 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis

                            If Trow("FisikNoUrut") = cmbfisiknewdr.Tag.ToString Then SaveFisikNew(cmbfisiknewdr.Tag.ToString, cmbfisiknewdr.Text, "", 1, Trow("FisikKet").ToString.Trim) : GoTo GoBackthis
GoBackthis:
                        Next
                    Else
                        SaveFisikNew(txriwayat.Tag.ToString, txriwayat.Text, "", 0, "")
                        SaveFisikNew(TextBoxTinggiBadan.Tag.ToString, TextBoxTinggiBadan.Text, "", 0, "")
                        SaveFisikNew(TextBoxBeratBadan.Tag.ToString, TextBoxBeratBadan.Text, "", 0, "")
                        SaveFisikNew(TextBoxSuhu.Tag.ToString, TextBoxSuhu.Text, "", 0, "")
                        SaveFisikNew(TextBoxDetakNadi.Tag.ToString, TextBoxDetakNadi.Text, "", 0, "")
                        SaveFisikNew(TextBoxSistole.Tag.ToString, TextBoxSistole.Text & "/" & TextBoxDiastole.Text, "", 0, "")
                        SaveFisikNew(TextBoxNafas.Tag.ToString, TextBoxNafas.Text, "", 0, "")
                        SaveFisikNew(txsimpul.Tag.ToString, txsimpul.Text, "", 0, "")
                        SaveFisikNew(txsaranfisik.Tag.ToString, txsaranfisik.Text, "", 0, "")
                        SaveFisikNew(cmbkesadaran.Tag.ToString, cmbkesadaran.Text, "", 0, "")
                        SaveFisikNew(cmbkepala.Tag.ToString, cmbkepala.Text, txkepala.Text, 0, "")
                        SaveFisikNew(cmbrambut.Tag.ToString, cmbrambut.Text, txrambut.Text, 0, "")
                        SaveFisikNew(cmbmuka.Tag.ToString, cmbmuka.Text, txmuka.Text, 0, "")
                        SaveFisikNew(cmbmata.Tag.ToString, cmbmata.Text, txmata.Text, 0, "")
                        SaveFisikNew(cmbbutawarna.Tag.ToString, cmbbutawarna.Text, txbutwarna.Text, 0, "")

                        If txvisustanpakacamata.Text <> "" And txvisustanpakacamata2.Text <> "" Then
                            SaveFisikNew(txvisustanpakacamata.Tag.ToString, txvisustanpakacamata.Text & "," & txvisustanpakacamata2.Text, "", 0, "")
                        Else
                            SaveFisikNew(txvisustanpakacamata.Tag.ToString, "", "", 0, "")
                        End If

                        If txvisuskacamata.Text <> "" And txvisuskacamata2.Text <> "" Then
                            SaveFisikNew(txvisuskacamata.Tag.ToString, txvisuskacamata.Text & "," & txvisuskacamata2.Text, "", 0, "")
                        Else
                            SaveFisikNew(txvisuskacamata.Tag.ToString, "", "", 0, "")
                        End If

                        SaveFisikNew(txkoreksiakhir.Tag.ToString, txkoreksiakhir.Text, "", 0, "")

                        SaveFisikNew(cmbtelinga.Tag.ToString, cmbtelinga.Text, txtelinga.Text, 0, "")
                        SaveFisikNew(cmbhidung.Tag.ToString, cmbhidung.Text, txhidung.Text, 0, "")
                        SaveFisikNew(cmbmulut.Tag.ToString, cmbmulut.Text, txmulut.Text, 0, "")
                        SaveFisikNew(cmbgigi.Tag.ToString, cmbgigi.Text, txgigi.Text, 0, "")
                        SaveFisikNew(cmblidah.Tag.ToString, cmblidah.Text, txlidah.Text, 0, "")
                        SaveFisikNew(cmbtenggorokan.Tag.ToString, cmbtenggorokan.Text, txtenggorokan.Text, 0, "")
                        SaveFisikNew(cmbleher.Tag.ToString, cmbleher.Text, txleher.Text, 0, "")
                        SaveFisikNew(cmbdada.Tag.ToString, cmbdada.Text, txdada.Text, 0, "")
                        SaveFisikNew(ComboBoxFisikPerut.Tag.ToString, ComboBoxFisikPerut.Text, TextBoxFisikPerut.Text, 0, "")
                        SaveFisikNew(ComboBoxFisikRectalToucher.Tag.ToString, ComboBoxFisikRectalToucher.Text, TextBoxFisikRectalToucher.Text, 0, "")
                        SaveFisikNew(cmbintegumen.Tag.ToString, cmbintegumen.Text, txintegumen.Text, 0, "")
                        SaveFisikNew(cmbekstemitas.Tag.ToString, cmbekstemitas.Text, txekstemitas.Text, 0, "")
                        SaveFisikNew(cmbturgor.Tag.ToString, cmbturgor.Text, "", 0, "")
                        SaveFisikNew(cmbrokok.Tag.ToString, cmbrokok.Text, "", 0, "")
                        SaveFisikNew(cmbalkohol.Tag.ToString, cmbalkohol.Text, "", 0, "")
                        SaveFisikNew(cmbkopi.Tag.ToString, cmbkopi.Text, "", 0, "")
                        SaveFisikNew(cmbpolamakan.Tag.ToString, cmbpolamakan.Text, "", 0, "")
                        SaveFisikNew(cmbistirahat.Tag.ToString, cmbistirahat.Text, "", 0, "")
                        SaveFisikNew(cmbolahraga.Tag.ToString, cmbolahraga.Text, "", 0, "")
                        SaveFisikNew(cmbtht.Tag.ToString, cmbtht.Text, "", 0, "")
                        SaveFisikNew(cmbanorexia.Tag.ToString, cmbanorexia.Text, "", 0, "")
                        SaveFisikNew(cmbmalaria.Tag.ToString, cmbmalaria.Text, "", 0, "")
                        SaveFisikNew(cmbkulit.Tag.ToString, cmbkulit.Text, "", 0, "")
                        SaveFisikNew(cmbtypoid.Tag.ToString, cmbtypoid.Text, "", 0, "")
                        SaveFisikNew(cmbbbturun.Tag.ToString, cmbbbturun.Text, "", 0, "")
                        SaveFisikNew(cmbambien.Tag.ToString, cmbambien.Text, "", 0, "")
                        SaveFisikNew(cmbkencing.Tag.ToString, cmbkencing.Text, "", 0, "")
                        SaveFisikNew(cmbvertigo.Tag.ToString, cmbvertigo.Text, "", 0, "")
                        SaveFisikNew(cmbpingsan.Tag.ToString, cmbpingsan.Text, "", 0, "")
                        SaveFisikNew(cmbgastritis.Tag.ToString, cmbgastritis.Text, "", 0, "")
                        SaveFisikNew(cmbpusing.Tag.ToString, cmbpusing.Text, "", 0, "")

                        'Kebiasaan
                        SaveFisikNew(cmboperasi.Tag.ToString, cmboperasi.Text & "#" & txdimanaoperasi.Text & "#" & txkenapaoperasi.Text & "##" & Format(dtkapanoperasi.Value, "MM-dd-yyyy"), "", 0, "")
                        SaveFisikNew(cmbrs.Tag.ToString, cmbrs.Text & "#" & txdimanars.Text & "#" & txkenapars.Text & "##" & Format(dtkapanrs.Value, "MM-dd-yyyy"), "", 0, "")
                        SaveFisikNew(cmbsehat.Tag.ToString, cmbsehat.Text, "", 0, "")
                        SaveFisikNew(cmbobat.Tag.ToString, cmbobat.Text & "###" & txpenyakitobat.Text & "#01-01-1900", "", 0, "")
                        SaveFisikNew(cmbnarkoba.Tag.ToString, cmbnarkoba.Text & "###" & txjenisnarkoba.Text & "#" & Format(dtkapannarkoba.Value, "MM-dd-yyyy"), "", 0, "")

                        'Penyakit
                        SaveFisikNew(cmbhepatitis.Tag.ToString, cmbhepatitis.Text & "####" & Format(dthepatitis.Value, "MM-dd-yyyy"), "", 0, "")
                        SaveFisikNew(cmbtbc.Tag.ToString, cmbtbc.Text & "####" & Format(dttbc.Value, "MM-dd-yyyy"), "", 0, "")
                        SaveFisikNew(cmbhernia.Tag.ToString, cmbhernia.Text & "####" & Format(dthernia.Value, "MM-dd-yyyy"), "", 0, "")
                        SaveFisikNew(cmbsakitjantung.Tag.ToString, cmbsakitjantung.Text & "####" & Format(dtjantung.Value, "MM-dd-yyyy"), "", 0, "")
                        SaveFisikNew(cmbhipertensi.Tag.ToString, cmbhipertensi.Text & "####" & Format(dthipertensi.Value, "MM-dd-yyyy"), "", 0, "")
                        SaveFisikNew(cmbepilepsi.Tag.ToString, cmbepilepsi.Text & "####" & Format(dtepilepsi.Value, "MM-dd-yyyy"), "", 0, "")
                        SaveFisikNew(cmbdiabetes.Tag.ToString, cmbdiabetes.Text & "####" & Format(dtdiabetes.Value, "MM-dd-yyyy"), "", 0, "")

                        SaveFisikNew(cmbfisiknewdr.Tag.ToString, cmbfisiknewdr.Text, "", 0, "")

                    End If
            End Select

            ' Save StatusKesehatanFisik
            WriteSQL("Update TransaksiLab set StatusKesehatanFisik = '" & TextBoxStatusFit.Text & "' WHERE NoUrut='" & TextBoxNoTransaksi.Text & "'", 4)

            ' Clear TextBoxStatusFit
            TextBoxStatusFit.ResetText()

            MsgBox("Data Berhasil Disimpan.", MsgBoxStyle.Information, "Success")

            ' Create PDF
            'CreateFisikToPDF("Nothing")
        End If
    End Sub

    Private Sub butfisiknewprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butfisiknewprint.Click
        If CheckSQL("SELECT * FROM TransaksiLabFisik WHERE NoUrut='" & TextBoxNoTransaksi.Text & "'") = True Then
            CreateFisikToPDF("Print")
        Else
            MsgBox("Tidak ada data yang akan dicetak.", MsgBoxStyle.Critical, "Warning")
        End If
    End Sub

    Private Sub butnormallab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butnormallab.Click
        Dim Tbls As DataTable = gridlab.DataSource
        Tbls.AcceptChanges()

        For Each Rrow As DataRow In Tbls.Rows
            If IsDBNull(Rrow("Result")) = True Then Rrow("Result") = ""

            If Strings.LCase(Rrow("NamaTindakan").ToString).Contains("thorax") Or Strings.LCase(Rrow("NamaTindakan").ToString).Contains("ecg") Or Strings.LCase(Rrow("NamaTindakan").ToString).Contains("audiometri") Or Strings.LCase(Rrow("NamaTindakan").ToString).Contains("fisik") Or Strings.LCase(Rrow("NamaTindakan").ToString).Contains("usg") Or Strings.LCase(Rrow("NamaTindakan").ToString).Contains("treadmill") Or Strings.LCase(Rrow("NamaTindakan").ToString).Contains("spirometri") Then
                Rrow("Result") = "Hasil Terlampir"
            Else
                If Rrow("Result") = "" Then
                    Dim Tstr As String = ReadSQLNIK("SELECT Pria FROM  masterlabDetail WHERE TindakanID='" & Rrow("TindakanID") & "' AND GroupID='" & Rrow("GroupID") & "' AND NoUrut='" & Rrow("NoUrut") & "' AND DetailKet='" & Rrow("DetailKet") & "'")
                    If Tstr.ToString.ToLower.Contains("non reaktif") = True Or Tstr.ToString.ToLower.Contains("reaktif") = True Or Tstr.ToString.ToLower.Contains("negatif") = True Or Tstr.ToString.ToLower.Contains("positif") = True Then
                        Rrow("Result") = Tstr
                    End If
                End If
            End If
        Next

        gridlab.DataSource = Tbls
    End Sub

    Private Sub butfisiknewnormal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butfisiknewnormal.Click
        cmbkesadaran.SelectedIndex = 1
        cmbkepala.SelectedIndex = 1
        cmbrambut.SelectedIndex = 1
        cmbmuka.SelectedIndex = 1
        cmbmata.SelectedIndex = 1
        cmbbutawarna.SelectedIndex = 1
        cmbtelinga.SelectedIndex = 1
        cmbhidung.SelectedIndex = 1
        cmbmulut.SelectedIndex = 1
        cmbgigi.SelectedIndex = 1
        cmblidah.SelectedIndex = 1
        cmbtenggorokan.SelectedIndex = 1
        cmbleher.SelectedIndex = 1
        cmbdada.SelectedIndex = 1
        ComboBoxFisikPerut.SelectedIndex = 1
        ComboBoxFisikRectalToucher.SelectedIndex = 1
        cmbintegumen.SelectedIndex = 1
        cmbekstemitas.SelectedIndex = 1
        cmbturgor.SelectedIndex = 1

        cmbrs.SelectedIndex = 2
        cmbobat.SelectedIndex = 2
        cmbnarkoba.SelectedIndex = 2
        cmbsehat.SelectedIndex = 2
        cmbrokok.SelectedIndex = 3
        cmbalkohol.SelectedIndex = 3
        cmbkopi.SelectedIndex = 3
        cmbpolamakan.SelectedIndex = 1
        cmbistirahat.SelectedIndex = 1
        cmbolahraga.SelectedIndex = 1

        cmbhepatitis.SelectedIndex = 2
        cmbtht.SelectedIndex = 2
        cmbtbc.SelectedIndex = 2
        cmbanorexia.SelectedIndex = 2
        cmbmalaria.SelectedIndex = 2
        cmbkulit.SelectedIndex = 2
        cmbtypoid.SelectedIndex = 2
        cmbbbturun.SelectedIndex = 2
        cmbhernia.SelectedIndex = 2
        cmbsakitjantung.SelectedIndex = 2
        cmbambien.SelectedIndex = 2
        cmbhipertensi.SelectedIndex = 2
        cmbkencing.SelectedIndex = 2
        cmbvertigo.SelectedIndex = 2
        cmbepilepsi.SelectedIndex = 2
        cmbpingsan.SelectedIndex = 2
        cmbgastritis.SelectedIndex = 2
        cmbpusing.SelectedIndex = 2
        cmbdiabetes.SelectedIndex = 2
        cmboperasi.SelectedIndex = 2
    End Sub

    Private Sub txtb_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxTinggiBadan.TextChanged
        SetBMI()
    End Sub

    Private Sub SetBMI()
        If TextBoxTinggiBadan.Text <> "-" And TextBoxBeratBadan.Text <> "-" And TextBoxTinggiBadan.Text <> "" And TextBoxBeratBadan.Text <> "" Then
            TextBoxIndeksMedik.Text = Math.Round(CDbl(TextBoxBeratBadan.Text / (TextBoxTinggiBadan.Text * TextBoxTinggiBadan.Text) * 10000), 1)
        End If
    End Sub

    Private Sub txbb_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxBeratBadan.TextChanged
        SetBMI()
    End Sub

    Private Sub cmbturgor_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbturgor.KeyUp
        If e.KeyCode = Keys.Tab And cmbturgor.Text <> "" Then
            cmbrs.Focus()
        End If
    End Sub

    Private Sub txtindakanid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxNoTransaksi.KeyUp
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            If CheckSQL("SELECT * FROM TransaksiLab WHERE NoUrut='20" & TextBoxNoTransaksi.Text & "'") = True Then
                Dim Txnourut As String = Strings.Left(DateAndTime.Now.Year, 2) & TextBoxNoTransaksi.Text
                Dim TxTransLabID As String = ReadSQLNIK("SELECT TransLabID FROM TransaksiLab WHERE NoUrut='20" & TextBoxNoTransaksi.Text & "'")
                LoadAdminLab(TxTransLabID, Txnourut, "empty")
            End If
        End If
    End Sub

    Private Sub CetakLabelMenuStrip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CetakLabelMenuStrip.Click
        Dim namaCompany As String = ""
        Dim noNIK As String = ReadSQLNIK("SELECT NoNIK FROM MasterPasien WHERE NoRekamMedis = '" & TextBoxNoRekamMedis.Text & "'")

        Report = New XtraReport
        Report = XtraReport.FromFile(Application.StartupPath + "\reports\PrintLabelPasien.repx", True)
        TextBoxNamaPasien.CharacterCasing = CharacterCasing.Upper
        If noNIK = " " Or noNIK = "-" Or noNIK = "NULL" Then
            Report.Bands.Item(BandKind.Detail).Controls("txnama").Text = TextBoxNamaPasien.Text
        Else
            Report.Bands.Item(BandKind.Detail).Controls("txnama").Text = TextBoxNamaPasien.Text & " / " & noNIK
        End If

        Report.Bands.Item(BandKind.Detail).Controls("txidcust").Text = TextBoxNoRekamMedis.Text & " / " & TextBoxNoTransaksi.Text
        Report.Bands.Item(BandKind.Detail).Controls("txumur").Text = Format(DateTimeTanggalLahir.Value, "dd MMM yyyy") & " / " & TextBoxUmur.Text & " (" & TextBoxJenisKelamin.Text & ")"
        Report.Bands.Item(BandKind.Detail).Controls("txalamat").Text = ReadSQLNIK("SELECT DomisiliAlamat FROM MasterPasien WHERE NoRekamMedis='" & TextBoxNoRekamMedis.Text & "'")

        If (TextBoxNoTransaksi.Text.Contains("M")) Then
            namaCompany = ReadSQLNIK("SELECT SUBSTRING(c.NoJenisBayar, 1, CHARINDEX('-', c.NoJenisBayar) - 1) AS Result " & _
                                     "FROM TransaksiLab a " & _
                                     "INNER JOIN MasterPasien b ON a.IDInternet = b.NoRekamMedis " & _
                                     "LEFT JOIN TransaksiLabBayar c ON a.TransLabID = c.TransLabID " & _
                                     "WHERE a.IDInternet = '" & TextBoxNoRekamMedis.Text & "' AND c.JenisBayar = 'TAGIHAN'")
            Report.Bands.Item(BandKind.Detail).Controls("txcompany").Text = namaCompany
        Else
            Report.Bands.Item(BandKind.Detail).Controls("txcompany").Text = butdokter.Text
        End If

        'Report.RunDesigner()
        'Report.ShowPreview()
        'Report.PrintingSystem.PageSettings.PaperKind = System.Drawing.Printing.PaperKind.Custom
        'Report.PrintingSystem.PageSettings.PaperName = "USER"
        Report.Print()
    End Sub

    Private Sub butprintall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butprintall.Click
        If TextBoxNoTransaksi.Text <> "" Then
            If CheckedListBox1.GetItemChecked(0) Then PrintSementaraToolStripMenuItem_Click(sender, e)
            If CheckedListBox1.GetItemChecked(1) Then butprintthorax_Click(sender, e)
            If CheckedListBox1.GetItemChecked(2) Then butprintecg_Click(sender, e)
            If CheckedListBox1.GetItemChecked(3) Then butprintaudio_Click(sender, e)
            If CheckedListBox1.GetItemChecked(4) Then butprintusg_Click(sender, e)
            If CheckedListBox1.GetItemChecked(5) Then butprinttreadmill_Click(sender, e)
            If CheckedListBox1.GetItemChecked(6) Then butprintspiro_Click(sender, e)
            If CheckedListBox1.GetItemChecked(7) Then butfisiknewprint_Click(sender, e)
            If CheckedListBox1.CheckedItems.Count > 0 Then MsgBox("Data Telah Tercetak Semua!", MsgBoxStyle.Information, "Success")
        Else
            MsgBox("Tidak ada data yang akan dicetak!", MsgBoxStyle.Critical, "Warning")
        End If
    End Sub

    Private Sub txtindakanid_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxNoTransaksi.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim nourut As String = TextBoxNoTransaksi.Text
            Dim counttransid As String = nourut.Length()
            Dim newnourut As String
            Dim translabid As String
            Dim bagian1 As String
            Dim bagian2 As String
            Dim bagian3 As String
            Dim KodeLokal As String
            Dim KodeBarcode As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='KodeBarcode'")

            'jumlah 12 lab biasa, jumlah 15 mcu
            If counttransid = 12 Then 'Offline
                If Strings.Mid(nourut, 7, 1) = "8" Then
                    bagian1 = Strings.Mid(nourut, 1, 6)
                    bagian2 = "L"
                    bagian3 = Strings.Mid(nourut, 8, 5)
                    newnourut = Strings.Left(DateAndTime.Now.Year, 2) & bagian1 & bagian2 & bagian3
                ElseIf Strings.Mid(nourut, 7, 1) = "9" Then
                    bagian1 = Strings.Mid(nourut, 1, 6)
                    bagian2 = "M"
                    bagian3 = Strings.Mid(nourut, 8, 5)
                    newnourut = Strings.Left(DateAndTime.Now.Year, 2) & bagian1 & bagian2 & bagian3
                Else
                    MsgBox("Data tidak ditemukan")
                    Exit Sub
                End If
            ElseIf counttransid = 15 Then 'Online
                KodeLokal = Strings.Left(nourut, 3)
                If KodeLokal <> KodeBarcode Then
                    MsgBox("Kode Barcode bukan dari lokal.")
                    Exit Sub
                End If
                If Strings.Mid(nourut, 10, 1) = "8" Then
                    bagian1 = Strings.Mid(nourut, 4, 6)
                    bagian2 = "L"
                    bagian3 = Strings.Mid(nourut, 11, 8)
                    newnourut = Strings.Left(DateAndTime.Now.Year, 2) & bagian1 & bagian2 & bagian3
                ElseIf Strings.Mid(nourut, 10, 1) = "9" Then
                    bagian1 = Strings.Mid(nourut, 4, 6)
                    bagian2 = "M"
                    bagian3 = Strings.Mid(nourut, 11, 8)
                    newnourut = Strings.Left(DateAndTime.Now.Year, 2) & bagian1 & bagian2 & bagian3
                Else
                    TextBoxNoTransaksi.ResetText()
                    MsgBox("Data tidak ditemukan.", MsgBoxStyle.Exclamation, "Warning!")
                    Exit Sub
                End If
            ElseIf counttransid = 14 Then 'NoUrut Bukan Barcode
                newnourut = nourut
            Else
                TextBoxNoTransaksi.ResetText()
                MessageBox.Show("Periksa lagi ID transaksinya", "Data Tidak Ditemukan")
                Exit Sub
            End If

            translabid = ReadSQLNIK("SELECT translabid FROM transaksilab WHERE nourut='" & newnourut & "' AND Status IN ('CHECK','CHECK2','CETAK','CLOSED','TAKEIT') AND deleted<>1 AND LabStartTime is not null")

            If translabid.Length > 0 And translabid <> "-" Then
                Me.LoadAdminLab(translabid, newnourut, "empty")
            Else
                TextBoxNoTransaksi.ResetText()
                MsgBox("Data tidak ditemukan, cek barcode apakah sudah benar & sudah di barcode.", MsgBoxStyle.Exclamation, "Warning!")
            End If
        End If
    End Sub

    Private Sub CountLenghth(ByVal data As String)
        Dim str As String
        str = data
        MsgBox(str.Length())
    End Sub

    Private Sub cmbvisusmata_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbvisusmata.SelectedIndexChanged
        If cmbvisusmata.SelectedIndex = 0 Then
            txvisuskacamata.Tag = 3012
            txvisustanpakacamata.Tag = 3013
            cmbvisustanpakacamata.SelectedIndex = 0
            cmbvisustanpakacamata.Enabled = False
        Else
            txvisuskacamata.Tag = 3014
            txvisustanpakacamata.Tag = 3015
            cmbvisustanpakacamata.SelectedIndex = 1
            cmbvisustanpakacamata.Enabled = False
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbvisustanpakacamata.SelectedIndexChanged
        If cmbvisusmata.SelectedIndex = 0 Then
            txvisuskacamata.Tag = 3012
            txvisustanpakacamata.Tag = 3013
        Else
            txvisuskacamata.Tag = 3014
            txvisustanpakacamata.Tag = 3015
        End If
    End Sub

    Private Sub butsavelab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butsavelab.Click
        If buttindakanid.Text = "" Then
            MsgBox("Pilih Pasien Terlebih Dahulu.", MsgBoxStyle.Exclamation, "Warning!")
        Else
            If Checking() = True Then
                Dim CountResultEmpty As Integer = 0
                Dim Tbls As DataTable = gridlab.DataSource
                Tbls.AcceptChanges()

                For Each Trownew As DataRow In Tbls.Rows
                    If (Trownew("Result").ToString.Trim = "" Or Trownew("Result").ToString.Trim = "-") And Trownew("DetailKet").ToString.Trim <> "SEDIMEN :" And Trownew("DetailKet").ToString.Trim <> "Lain-lain" And Trownew("DetailKet").ToString.Trim <> "Makros" Then
                        CountResultEmpty = CountResultEmpty + 1
                    End If

                    If Strings.LCase(Trownew("NamaTindakan").ToString).Contains("thorax") Or Strings.LCase(Trownew("NamaTindakan").ToString).Contains("ecg") Or Strings.LCase(Trownew("NamaTindakan").ToString).Contains("audiometri") Or Strings.LCase(Trownew("NamaTindakan").ToString).Contains("fisik") Or Strings.LCase(Trownew("NamaTindakan").ToString).Contains("usg") Or Strings.LCase(Trownew("NamaTindakan").ToString).Contains("treadmill") Or Strings.LCase(Trownew("NamaTindakan").ToString).Contains("spirometri") Then
                        'di skip... Lanjut ke hal lain selain hasil terlampir
                        WriteSQL("update TransaksiLabResult set Result='" & Trownew("Result") & "' , Keterangan='-'  WHERE TransLabIDDetail='" & Trownew("TransLabIDDetail") & "' AND TindakanID='" & Trownew("TindakanID") & "' AND GroupID='" & Trownew("GroupID") & "' AND NoUrut='" & Trownew("NoUrut") & "' AND DetailKet='" & Trownew("DetailKet") & "'", 4)
                    Else
                        WriteSQL("update TransaksiLabResult set Acc1='" & UserLabAdmin & "' + ';'  + convert(nvarchar(MAX), GETDATE(), 113) ,acc2='BYPASS;'  + convert(nvarchar(MAX), GETDATE(), 113), Result='" & Trownew("Result") & "' , Keterangan='" & Trownew("Keterangan") & "', Saran='" & Trownew("Saran") & "', Pria='" & Trownew("Pria") & "' , Wanita='" & Trownew("Wanita") & "' , Satuan='" & Trownew("Satuan") & "' WHERE TransLabIDDetail='" & Trownew("TransLabIDDetail") & "' AND TindakanID='" & Trownew("TindakanID") & "' AND GroupID='" & Trownew("GroupID") & "' AND NoUrut='" & Trownew("NoUrut") & "' AND DetailKet='" & Trownew("DetailKet") & "'", 4)
                    End If
                Next

                If CheckSQL("SELECT * FROM TransaksiLab WHERE TransLabID='" & buttindakanid.Text & "' AND [status]='CHECK'") = True And CountResultEmpty = 0 Then
                    WriteSQL("update TransaksiLab set Saran='" & txsaranall.Text & "', Kesimpulan='" & txketall.Text & "', [status]='CETAK',  LabEndTime=getdate(), TglInputHasil=getdate() WHERE TransLabID='" & buttindakanid.Text & "'", 4)
                    chkclosed.Checked = True
                    MsgBox("Berhasil menyimpan data.", MsgBoxStyle.Information, "Success!")
                ElseIf CountResultEmpty > 0 Then
                    WriteSQL("update TransaksiLab set Saran='" & txsaranall.Text & "', Kesimpulan='" & txketall.Text & "' WHERE TransLabID='" & buttindakanid.Text & "'", 4)
                    MsgBox("Berhasil menyimpan data & terdapat " & CountResultEmpty & " hasil belum terisi.", MsgBoxStyle.Information, "Success!")
                ElseIf CountResultEmpty = 0 Then
                    WriteSQL("update TransaksiLab set Saran='" & txsaranall.Text & "', Kesimpulan='" & txketall.Text & "' WHERE TransLabID='" & buttindakanid.Text & "'", 4)
                    chkclosed.Checked = True
                    MsgBox("Berhasil menyimpan data.", MsgBoxStyle.Information, "Success!")
                End If

                'Save PDF Hasil
                CreateHasilToPDF("Nothing", "Yes")

                If CheckSQL("SELECT * FROM TransaksiLab WHERE TransLabID = '" & buttindakanid.Text & "' AND StatusHardcopy = 1") = True And CountResultEmpty = 0 Then
                    If HardcopyCompany(buttindakanid.Text, "Offline") = True Then
                        PrintSementaraToolStripMenuItem.PerformClick()
                    Else
                        PreviewHasilLabToolStripMenuItem.PerformClick()
                    End If
                ElseIf CheckSQL("SELECT * FROM TransaksiLab WHERE TransLabID = '" & buttindakanid.Text & "' AND StatusSoftcopy = 1") = True And CountResultEmpty = 0 Then
                    PreviewHasilLabToolStripMenuItem.PerformClick()
                End If
            End If
        End If
    End Sub

    Function CreateXRPictureBox(ByVal LocX As Integer, ByVal LocY As Integer, ByVal SizeX As Integer, ByVal SizeY As Integer) As XRPictureBox
        Dim PictureBox As XRPictureBox = New XRPictureBox()
        PictureBox.Name = "QR_Hasil"
        PictureBox.Image = QR_Code_Trans.Image
        PictureBox.Location = New Point(LocX, LocY)
        PictureBox.Size = New Size(SizeX, SizeY)
        PictureBox.Sizing = ImageSizeMode.StretchImage

        Return PictureBox
    End Function

    Private Sub butsaran_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butsaran.Click
        Dim Tbls As DataTable = gridlab.DataSource
        Tbls.AcceptChanges()

        Dim varResultDBString As String = ""
        Dim varResult As Double = 0
        Dim varJenisResult As String = ""
        Dim T1 As Double = 0
        Dim T2 As Double = 0
        Dim varResultDB As Double = 0
        Dim varSaranDB As String = 0
        Dim varKetDB As String = 0
        Dim varKey As String = 0
        Dim ArrayResult = New String() {}
        Dim displayKeterangan As String = ""
        Dim displayKeteranganReaktif As String = ""
        Dim displayKeteranganNonReaktif As String = ""
        Dim displaySaranReaktif As String = ""
        Dim displaySaranNonReaktif As String = ""
        Dim spasi As String = "  - "
        Dim totalKetReaktif As Integer = 0
        Dim totalKetNonReaktif As Integer = 0
        Dim totalSaranReaktif As Integer = 0
        Dim totalSaranNonReaktif As Integer = 0
        Dim tandabaca As String = ""

        ''Manual Code
        'Dim varKonversiSatuanMindray As Double = 0
        'Dim varKonversiSatuanArcht As Double = 0
        'Dim varKonversiSatuanNtAb As Double = 0
        'Dim varNilaiCreatinin As Double = 0
        'Dim varNilaiCreatininEGFR As Double = 0

        For Each Trownew As DataRow In Tbls.Rows
            If IsDBNull(Trownew("Saran")) = True Then Trownew("Saran") = ""
            If IsDBNull(Trownew("Keterangan")) = True Then Trownew("Keterangan") = ""
            If IsDBNull(Trownew("Result")) = True Then Trownew("Result") = ""

            If TextBoxJenisKelamin.Text = "L" Then
                ArrayResult = New String() {"PriaBatasBawah", "PriaBatasNormal", "PriaAmbangBatasTinggi", "PriaBatasAtas"}
            ElseIf TextBoxJenisKelamin.Text = "P" Then
                ArrayResult = New String() {"WanitaBatasBawah", "WanitaBatasNormal", "WanitaAmbangBatasTinggi", "WanitaBatasAtas"}
            End If

            varJenisResult = Trownew("Result")

            ''========== MANUAL CODE =========='

            ''SARS-COV-2 S-RBD IgG (Mindray)
            'If Trownew("GroupID").ToString.Trim = "SARS-COV-2 S-RBD IgG" AND varJenisResult <> "" AND Trownew("NoUrut") = "1" Then
            '    varKonversiSatuanMindray = varJenisResult / 0.8229
            'ElseIf Trownew("GroupID").ToString.Trim = "SARS-COV-2 S-RBD IgG" AND varKonversiSatuanMindray >= 0 AND Trownew("NoUrut") = "2" Then
            '    Trownew("Result") = Math.Round(varKonversiSatuanMindray, 2)
            'End If

            ''SARS-CoV-2 S-RBD IgG (ARCHT)
            'If Trownew("GroupID").ToString.Trim = "SARS-CoV-2 S-RBD IgG (ARCHT)" AND varJenisResult <> "" AND Trownew("NoUrut") = "1" Then
            '    varKonversiSatuanArcht = varJenisResult * 0.142
            'ElseIf Trownew("GroupID").ToString.Trim = "SARS-CoV-2 S-RBD IgG (ARCHT)" AND varKonversiSatuanArcht >= 0 AND Trownew("NoUrut") = "2" Then
            '    Trownew("Result") = Math.Round(varKonversiSatuanArcht, 2)
            'End If

            ''SARS-CoV-2 Neutralizing Antibody (NtAb)
            'If Trownew("GroupID").ToString.Trim = "SARS-CoV-2 Neutralizing Antibody (NtAb)" AND varJenisResult <> "" AND Trownew("NoUrut") = "1" Then
            '    varKonversiSatuanNtAb = varJenisResult * 0.3025
            'ElseIf Trownew("GroupID").ToString.Trim = "SARS-CoV-2 Neutralizing Antibody (NtAb)" AND varKonversiSatuanNtAb >= 0 AND Trownew("NoUrut") = "2" Then
            '    Trownew("Result") = Math.Round(varKonversiSatuanNtAb, 2)
            'End If

            ''Creatinin (e-GFR)
            'If Trownew("GroupID").ToString.Trim = "Creatinin" AND varJenisResult <> "" AND Trownew("NoUrut") = "1" Then
            '    varNilaiCreatinin = varJenisResult
            'ElseIf Trownew("GroupID").ToString.Trim = "Creatinin" AND varNilaiCreatinin >= 0 AND Trownew("NoUrut") = "2" Then
            '    If txcustlp.Text = "P" Then
            '        varNilaiCreatininEGFR = 175 * (varNilaiCreatinin) ^ -1.154 * (GetCurrentAge(dtcusttgllhr.Value)) ^ -0.203 * 0.742
            '    ElseIf txcustlp.Text = "L" Then
            '        varNilaiCreatininEGFR = 175 * (varNilaiCreatinin) ^ -1.154 * (GetCurrentAge(dtcusttgllhr.Value)) ^ -0.203
            '    End If

            '    Trownew("Result") = Math.Round(varNilaiCreatininEGFR, 1)
            'End If

            ''======== END MANUAL CODE ========'

            If Trownew("GroupID").ToString.Contains("Widal") = True And varJenisResult.Contains("/") = True Then
                Dim splitwidal() As String = varJenisResult.Split("/")
                varJenisResult = splitwidal(1)
            End If

            Dim VarLebihKurang As String = ""
            If varJenisResult.Contains(">") = True Then
                VarLebihKurang = Strings.Replace(Strings.Replace(varJenisResult, ">", ""), " ", "")
                varJenisResult = VarLebihKurang + 0.01
            ElseIf varJenisResult.Contains("<") = True Then
                VarLebihKurang = Strings.Replace(Strings.Replace(varJenisResult, "<", ""), " ", "")
                varJenisResult = VarLebihKurang - 0.01
            End If

            If IsNumeric(varJenisResult) = True And varJenisResult <> "" Then
                Dim TblsSaran As DataTable = ReadSQL("SELECT * FROM MasterLabdetailBaru WHERE TindakanID='" & Trownew("TindakanID") & "' AND GroupID='" & Trownew("GroupID") & "' AND NoUrut='" & Trownew("NoUrut") & "' AND (CONVERT(VARCHAR, PriaBatasBawah)<>'' or CONVERT(VARCHAR, PriaBatasNormal)<>'' or CONVERT(VARCHAR, PriaAmbangBatasTinggi)<>'' or CONVERT(VARCHAR, PriaBatasAtas)<>'')")
                If TblsSaran.Rows.Count > 0 Then
                    For Each Trow As DataRow In TblsSaran.Rows
                        varResult = Strings.Replace(varJenisResult, ",", ".")
                        For Each element As String In ArrayResult
                            varResultDBString = ReadSQLNIK("SELECT " + element + " FROM MasterLabdetailBaru WHERE TindakanID='" & Trownew("TindakanID") & "' AND GroupID='" & Trownew("GroupID") & "' AND NoUrut='" & Trownew("NoUrut") & "' AND (CONVERT(VARCHAR, PriaBatasBawah)<>'' or CONVERT(VARCHAR, PriaBatasNormal)<>'' or CONVERT(VARCHAR, PriaAmbangBatasTinggi)<>'' or CONVERT(VARCHAR, PriaBatasAtas)<>'')")
                            varKetDB = ReadSQLNIK("SELECT " + "Ket" + element + " FROM MasterLabdetailBaru WHERE TindakanID='" & Trownew("TindakanID") & "' AND GroupID='" & Trownew("GroupID") & "' AND NoUrut='" & Trownew("NoUrut") & "' AND (CONVERT(VARCHAR, PriaBatasBawah)<>'' or CONVERT(VARCHAR, PriaBatasNormal)<>'' or CONVERT(VARCHAR, PriaAmbangBatasTinggi)<>'' or CONVERT(VARCHAR, PriaBatasAtas)<>'')")
                            varSaranDB = ReadSQLNIK("SELECT " + "Saran" + element + " FROM MasterLabdetailBaru WHERE TindakanID='" & Trownew("TindakanID") & "' AND GroupID='" & Trownew("GroupID") & "' AND NoUrut='" & Trownew("NoUrut") & "' AND (CONVERT(VARCHAR, PriaBatasBawah)<>'' or CONVERT(VARCHAR, PriaBatasNormal)<>'' or CONVERT(VARCHAR, PriaAmbangBatasTinggi)<>'' or CONVERT(VARCHAR, PriaBatasAtas)<>'')")
                            If varResultDBString <> "" Then
                                varResultDBString = Strings.Replace(varResultDBString, ",", ".")
                                If varResultDBString.Contains("<") = True Then
                                    varResultDB = Trim(Strings.Replace(Strings.Replace(varResultDBString, "<", ""), "=", ""))
                                    If varResultDBString.Contains("=") = True Then
                                        If varResult <= varResultDB Then
                                            Trownew("Saran") = varSaranDB
                                            Trownew("Keterangan") = varKetDB
                                            If element.Contains("BatasNormal") = False Then
                                                totalKetReaktif = totalKetReaktif + 1
                                                If totalKetReaktif > 1 Then
                                                    displayKeteranganReaktif = displayKeteranganReaktif + spasi + Trownew("DetailKet") + " : " + varKetDB + vbCrLf
                                                Else
                                                    displayKeteranganReaktif = displayKeteranganReaktif + Trownew("DetailKet") + " : " + varKetDB + vbCrLf
                                                End If

                                                If displaySaranReaktif.Contains("" & varSaranDB & "") = False Then
                                                    totalSaranReaktif = totalSaranReaktif + 1
                                                    If totalSaranReaktif > 1 Then
                                                        displaySaranReaktif = displaySaranReaktif + spasi + varSaranDB + vbCrLf
                                                    Else
                                                        displaySaranReaktif = displaySaranReaktif + varSaranDB + vbCrLf
                                                    End If
                                                End If
                                            Else
                                                totalKetNonReaktif = totalKetNonReaktif + 1
                                                If totalKetNonReaktif > 1 Then
                                                    displayKeteranganNonReaktif = displayKeteranganNonReaktif + spasi + Trownew("DetailKet") + " : " + varKetDB + vbCrLf
                                                Else
                                                    displayKeteranganNonReaktif = displayKeteranganNonReaktif + Trownew("DetailKet") + " : " + varKetDB + vbCrLf
                                                End If

                                                If displaySaranNonReaktif.Contains("" & varSaranDB & "") = False Then
                                                    totalSaranNonReaktif = totalSaranNonReaktif + 1
                                                    If totalSaranNonReaktif > 1 Then
                                                        displaySaranNonReaktif = displaySaranNonReaktif + spasi + varSaranDB + vbCrLf
                                                    Else
                                                        displaySaranNonReaktif = displaySaranNonReaktif + varSaranDB + vbCrLf
                                                    End If
                                                End If
                                            End If
                                            varKey = 1
                                            Exit For
                                        End If
                                    Else
                                        If varResult < varResultDB Then
                                            Trownew("Saran") = varSaranDB
                                            Trownew("Keterangan") = varKetDB
                                            If element.Contains("BatasNormal") = False Then
                                                totalKetReaktif = totalKetReaktif + 1
                                                If totalKetReaktif > 1 Then
                                                    displayKeteranganReaktif = displayKeteranganReaktif + spasi + Trownew("DetailKet") + " : " + varKetDB + vbCrLf
                                                Else
                                                    displayKeteranganReaktif = displayKeteranganReaktif + Trownew("DetailKet") + " : " + varKetDB + vbCrLf
                                                End If

                                                If displaySaranReaktif.Contains("" & varSaranDB & "") = False Then
                                                    totalSaranReaktif = totalSaranReaktif + 1
                                                    If totalSaranReaktif > 1 Then
                                                        displaySaranReaktif = displaySaranReaktif + spasi + varSaranDB + vbCrLf
                                                    Else
                                                        displaySaranReaktif = displaySaranReaktif + varSaranDB + vbCrLf
                                                    End If
                                                End If
                                            Else
                                                totalKetNonReaktif = totalKetNonReaktif + 1
                                                If totalKetNonReaktif > 1 Then
                                                    displayKeteranganNonReaktif = displayKeteranganNonReaktif + spasi + Trownew("DetailKet") + " : " + varKetDB + vbCrLf
                                                Else
                                                    displayKeteranganNonReaktif = displayKeteranganNonReaktif + Trownew("DetailKet") + " : " + varKetDB + vbCrLf
                                                End If

                                                If displaySaranNonReaktif.Contains("" & varSaranDB & "") = False Then
                                                    totalSaranNonReaktif = totalSaranNonReaktif + 1
                                                    If totalSaranNonReaktif > 1 Then
                                                        displaySaranNonReaktif = displaySaranNonReaktif + spasi + varSaranDB + vbCrLf
                                                    Else
                                                        displaySaranNonReaktif = displaySaranNonReaktif + varSaranDB + vbCrLf
                                                    End If
                                                End If
                                            End If
                                            varKey = 1
                                            Exit For
                                        End If
                                    End If
                                ElseIf varResultDBString.Contains(">") = True Then
                                    varResultDB = Trim(Strings.Replace(Strings.Replace(varResultDBString, ">", ""), "=", ""))
                                    If varResultDBString.Contains("=") = True Then
                                        If varResult >= varResultDB Then
                                            Trownew("Saran") = varSaranDB
                                            Trownew("Keterangan") = varKetDB
                                            If element.Contains("BatasNormal") = False Then
                                                totalKetReaktif = totalKetReaktif + 1
                                                If totalKetReaktif > 1 Then
                                                    displayKeteranganReaktif = displayKeteranganReaktif + spasi + Trownew("DetailKet") + " : " + varKetDB + vbCrLf
                                                Else
                                                    displayKeteranganReaktif = displayKeteranganReaktif + Trownew("DetailKet") + " : " + varKetDB + vbCrLf
                                                End If

                                                If displaySaranReaktif.Contains("" & varSaranDB & "") = False Then
                                                    totalSaranReaktif = totalSaranReaktif + 1
                                                    If totalSaranReaktif > 1 Then
                                                        displaySaranReaktif = displaySaranReaktif + spasi + varSaranDB + vbCrLf
                                                    Else
                                                        displaySaranReaktif = displaySaranReaktif + varSaranDB + vbCrLf
                                                    End If
                                                End If
                                            Else
                                                totalKetNonReaktif = totalKetNonReaktif + 1
                                                If totalKetNonReaktif > 1 Then
                                                    displayKeteranganNonReaktif = displayKeteranganNonReaktif + spasi + Trownew("DetailKet") + " : " + varKetDB + vbCrLf
                                                Else
                                                    displayKeteranganNonReaktif = displayKeteranganNonReaktif + Trownew("DetailKet") + " : " + varKetDB + vbCrLf
                                                End If

                                                If displaySaranNonReaktif.Contains("" & varSaranDB & "") = False Then
                                                    totalSaranNonReaktif = totalSaranNonReaktif + 1
                                                    If totalSaranNonReaktif > 1 Then
                                                        displaySaranNonReaktif = displaySaranNonReaktif + spasi + varSaranDB + vbCrLf
                                                    Else
                                                        displaySaranNonReaktif = displaySaranNonReaktif + varSaranDB + vbCrLf
                                                    End If
                                                End If
                                            End If
                                            varKey = 1
                                            Exit For
                                        End If
                                    Else
                                        If varResult > varResultDB Then
                                            Trownew("Saran") = varSaranDB
                                            Trownew("Keterangan") = varKetDB
                                            If element.Contains("BatasNormal") = False Then
                                                totalKetReaktif = totalKetReaktif + 1
                                                If totalKetReaktif > 1 Then
                                                    displayKeteranganReaktif = displayKeteranganReaktif + spasi + Trownew("DetailKet") + " : " + varKetDB + vbCrLf
                                                Else
                                                    displayKeteranganReaktif = displayKeteranganReaktif + Trownew("DetailKet") + " : " + varKetDB + vbCrLf
                                                End If

                                                If displaySaranReaktif.Contains("" & varSaranDB & "") = False Then
                                                    totalSaranReaktif = totalSaranReaktif + 1
                                                    If totalSaranReaktif > 1 Then
                                                        displaySaranReaktif = displaySaranReaktif + spasi + varSaranDB + vbCrLf
                                                    Else
                                                        displaySaranReaktif = displaySaranReaktif + varSaranDB + vbCrLf
                                                    End If
                                                End If
                                            Else
                                                If displaySaranNonReaktif.Contains("" & varSaranDB & "") = False Then
                                                    totalSaranNonReaktif = totalSaranNonReaktif + 1
                                                    If totalSaranNonReaktif > 1 Then
                                                        displaySaranNonReaktif = displaySaranNonReaktif + spasi + varSaranDB + vbCrLf
                                                    Else
                                                        displaySaranNonReaktif = displaySaranNonReaktif + varSaranDB + vbCrLf
                                                    End If
                                                End If
                                            End If
                                            varKey = 1
                                            Exit For
                                        End If
                                    End If
                                ElseIf varResultDBString.Contains("-") = True Then
                                    Dim Tsplit() As String = varResultDBString.ToString.Split("-")
                                    T1 = Trim(Tsplit(0))
                                    T2 = Trim(Tsplit(1))
                                    If varResult >= T1 And varResult <= T2 Then
                                        Trownew("Saran") = varSaranDB
                                        Trownew("Keterangan") = varKetDB
                                        If element.Contains("BatasNormal") = False Then
                                            totalKetReaktif = totalKetReaktif + 1
                                            If totalKetReaktif > 1 Then
                                                displayKeteranganReaktif = displayKeteranganReaktif + spasi + Trownew("DetailKet") + " : " + varKetDB + vbCrLf
                                            Else
                                                displayKeteranganReaktif = displayKeteranganReaktif + Trownew("DetailKet") + " : " + varKetDB + vbCrLf
                                            End If

                                            If displaySaranReaktif.Contains("" & varSaranDB & "") = False Then
                                                totalSaranReaktif = totalSaranReaktif + 1
                                                If totalSaranReaktif > 1 Then
                                                    displaySaranReaktif = displaySaranReaktif + spasi + varSaranDB + vbCrLf
                                                Else
                                                    displaySaranReaktif = displaySaranReaktif + varSaranDB + vbCrLf
                                                End If
                                            End If
                                        Else
                                            If displaySaranNonReaktif.Contains("" & varSaranDB & "") = False Then
                                                totalSaranNonReaktif = totalSaranNonReaktif + 1
                                                If totalSaranNonReaktif > 1 Then
                                                    displaySaranNonReaktif = displaySaranNonReaktif + spasi + varSaranDB + vbCrLf
                                                Else
                                                    displaySaranNonReaktif = displaySaranNonReaktif + varSaranDB + vbCrLf
                                                End If
                                            End If
                                        End If
                                        varKey = 1
                                        Exit For
                                    End If
                                End If
                            End If
                        Next
                    Next
                End If
            ElseIf varJenisResult <> "" Then
                'UNTUK INPUTAN REAKTIF/NON REAKTIF DAN NEGATIF/POSITIF BUKAN ANGKA
                Dim TblsNonAngka As DataTable = ReadSQL("SELECT * FROM MasterLabdetailBaru WHERE TindakanID='" & Trownew("TindakanID") & "' AND GroupID='" & Trownew("GroupID") & "' AND NoUrut='" & Trownew("NoUrut") & "' AND (CONVERT(VARCHAR, PriaReaktif)<>'' or CONVERT(VARCHAR, WanitaReaktif)<>'' or CONVERT(VARCHAR, PriaNonReaktif)<>'' or CONVERT(VARCHAR, WanitaNonReaktif)<>'')")
                If TblsNonAngka.Rows.Count > 0 Then
                    Dim TrowNonAngka As DataRow = TblsNonAngka.Rows(0)
                    If TextBoxJenisKelamin.Text = "L" Then
                        If CheckSQL("SELECT * FROM MasterLabdetailBaru WHERE TindakanID='" & Trownew("TindakanID") & "' AND GroupID='" & Trownew("GroupID") & "' AND NoUrut='" & Trownew("NoUrut") & "' AND (CONVERT(VARCHAR, PriaReaktif) = '" & varJenisResult & "')") = True Then
                            Trownew("Saran") = TrowNonAngka("SaranPriaReaktif").ToString
                            Trownew("Keterangan") = TrowNonAngka("KetPriaReaktif").ToString

                            totalKetReaktif = totalKetReaktif + 1
                            If totalKetReaktif > 1 And TrowNonAngka("KetPriaReaktif").ToString <> "" Then
                                displayKeteranganReaktif = displayKeteranganReaktif + spasi + Trownew("DetailKet") + " : " + TrowNonAngka("KetPriaReaktif").ToString + vbCrLf
                            ElseIf totalKetReaktif = 1 And TrowNonAngka("KetPriaReaktif").ToString = "" Then
                                displayKeteranganReaktif = ""
                            ElseIf TrowNonAngka("KetPriaReaktif").ToString <> "" Then
                                displayKeteranganReaktif = displayKeteranganReaktif + Trownew("DetailKet") + " : " + TrowNonAngka("KetPriaReaktif").ToString + vbCrLf
                            End If

                            If displaySaranReaktif.Contains("" & TrowNonAngka("SaranPriaReaktif").ToString & "") = False Then
                                totalSaranReaktif = totalSaranReaktif + 1
                                If totalSaranReaktif > 1 Then
                                    displaySaranReaktif = displaySaranReaktif + spasi + TrowNonAngka("SaranPriaReaktif").ToString + vbCrLf
                                Else
                                    displaySaranReaktif = displaySaranReaktif + TrowNonAngka("SaranPriaReaktif").ToString + vbCrLf
                                End If
                            End If
                            varKey = 1
                        ElseIf CheckSQL("SELECT * FROM MasterLabdetailBaru WHERE TindakanID='" & Trownew("TindakanID") & "' AND GroupID='" & Trownew("GroupID") & "' AND NoUrut='" & Trownew("NoUrut") & "' AND (CONVERT(VARCHAR, PriaNonReaktif) = '" & varJenisResult & "')") = True Then
                            Trownew("Saran") = TrowNonAngka("SaranPriaNonReaktif").ToString
                            Trownew("Keterangan") = TrowNonAngka("KetPriaNonReaktif").ToString

                            totalKetNonReaktif = totalKetNonReaktif + 1
                            If totalKetNonReaktif > 1 And TrowNonAngka("KetPriaNonReaktif").ToString <> "" Then
                                displayKeteranganNonReaktif = displayKeteranganNonReaktif + spasi + Trownew("DetailKet") + " : " + TrowNonAngka("KetPriaNonReaktif").ToString + vbCrLf
                            ElseIf totalKetNonReaktif = 1 And TrowNonAngka("KetPriaNonReaktif").ToString = "" Then
                                displayKeteranganNonReaktif = ""
                            ElseIf TrowNonAngka("KetPriaNonReaktif").ToString <> "" Then
                                displayKeteranganNonReaktif = displayKeteranganNonReaktif + Trownew("DetailKet") + " : " + TrowNonAngka("KetPriaNonReaktif").ToString + vbCrLf
                            End If

                            If displaySaranNonReaktif.Contains("" & TrowNonAngka("SaranPriaNonReaktif").ToString & "") = False Then
                                totalSaranNonReaktif = totalSaranNonReaktif + 1
                                If totalSaranNonReaktif > 1 Then
                                    displaySaranNonReaktif = displaySaranNonReaktif + spasi + TrowNonAngka("SaranPriaNonReaktif").ToString + vbCrLf
                                Else
                                    displaySaranNonReaktif = displaySaranNonReaktif + TrowNonAngka("SaranPriaNonReaktif").ToString + vbCrLf
                                End If
                            End If
                            varKey = 1
                        End If
                    ElseIf TextBoxJenisKelamin.Text = "P" Then
                        If CheckSQL("SELECT * FROM MasterLabdetailBaru WHERE TindakanID='" & Trownew("TindakanID") & "' AND GroupID='" & Trownew("GroupID") & "' AND NoUrut='" & Trownew("NoUrut") & "' AND (CONVERT(VARCHAR, WanitaReaktif) = '" & varJenisResult & "')") = True Then
                            Trownew("Saran") = TrowNonAngka("SaranWanitaReaktif").ToString
                            Trownew("Keterangan") = TrowNonAngka("KetWanitaReaktif").ToString

                            totalKetReaktif = totalKetReaktif + 1
                            If totalKetReaktif > 1 And TrowNonAngka("KetWanitaReaktif").ToString <> "" Then
                                displayKeteranganReaktif = displayKeteranganReaktif + spasi + Trownew("DetailKet") + " : " + TrowNonAngka("KetWanitaReaktif").ToString + vbCrLf
                            ElseIf totalKetReaktif = 1 And TrowNonAngka("KetWanitaReaktif").ToString = "" Then
                                displayKeteranganReaktif = ""
                            ElseIf TrowNonAngka("KetWanitaReaktif").ToString <> "" Then
                                displayKeteranganReaktif = displayKeteranganReaktif + Trownew("DetailKet") + " : " + TrowNonAngka("KetWanitaReaktif").ToString + vbCrLf
                            End If

                            If displaySaranReaktif.Contains("" & TrowNonAngka("SaranWanitaReaktif").ToString & "") = False Then
                                totalSaranReaktif = totalSaranReaktif + 1
                                If totalSaranReaktif > 1 Then
                                    displaySaranReaktif = displaySaranReaktif + spasi + TrowNonAngka("SaranWanitaReaktif").ToString + vbCrLf
                                Else
                                    displaySaranReaktif = displaySaranReaktif + TrowNonAngka("SaranWanitaReaktif").ToString + vbCrLf
                                End If
                            End If
                            varKey = 1
                        ElseIf CheckSQL("SELECT * FROM MasterLabdetailBaru WHERE TindakanID='" & Trownew("TindakanID") & "' AND GroupID='" & Trownew("GroupID") & "' AND NoUrut='" & Trownew("NoUrut") & "' AND (CONVERT(VARCHAR, WanitaNonReaktif) = '" & varJenisResult & "')") = True Then
                            Trownew("Saran") = TrowNonAngka("SaranWanitaNonReaktif").ToString
                            Trownew("Keterangan") = TrowNonAngka("KetWanitaNonReaktif").ToString

                            totalKetNonReaktif = totalKetNonReaktif + 1
                            If totalKetNonReaktif > 1 And TrowNonAngka("KetWanitaNonReaktif").ToString <> "" Then
                                displayKeteranganNonReaktif = displayKeteranganNonReaktif + spasi + Trownew("DetailKet") + " : " + TrowNonAngka("KetWanitaNonReaktif").ToString + vbCrLf
                            ElseIf totalKetNonReaktif = 1 And TrowNonAngka("KetWanitaNonReaktif").ToString = "" Then
                                displayKeteranganNonReaktif = ""
                            ElseIf TrowNonAngka("KetWanitaNonReaktif").ToString <> "" Then
                                displayKeteranganNonReaktif = displayKeteranganNonReaktif + Trownew("DetailKet") + " : " + TrowNonAngka("KetWanitaNonReaktif").ToString + vbCrLf
                            End If

                            If displaySaranNonReaktif.Contains("" & TrowNonAngka("SaranWanitaNonReaktif").ToString & "") = False Then
                                totalSaranNonReaktif = totalSaranNonReaktif + 1
                                If totalSaranNonReaktif > 1 Then
                                    displaySaranNonReaktif = displaySaranNonReaktif + spasi + TrowNonAngka("SaranWanitaNonReaktif").ToString + vbCrLf
                                Else
                                    displaySaranNonReaktif = displaySaranNonReaktif + TrowNonAngka("SaranWanitaNonReaktif").ToString + vbCrLf
                                End If
                            End If
                            varKey = 1
                        End If
                    End If
                End If
            End If
        Next

        If displayKeteranganNonReaktif <> "" Or displayKeteranganReaktif <> "" Or displaySaranReaktif <> "" Or displaySaranNonReaktif <> "" Then
            If displayKeteranganNonReaktif <> "" Or displayKeteranganReaktif <> "" Then
                If displayKeteranganReaktif <> "" Then
                    If totalKetReaktif > 1 Then
                        txketall.Text = spasi + displayKeteranganReaktif
                    Else
                        txketall.Text = displayKeteranganReaktif
                    End If
                ElseIf displayKeteranganNonReaktif <> "" Then
                    If totalKetNonReaktif > 1 Then
                        txketall.Text = spasi + displayKeteranganNonReaktif
                    Else
                        txketall.Text = displayKeteranganNonReaktif
                    End If
                End If
            Else
                ' Clear Keterangan
                txketall.ResetText()
            End If

            If displaySaranReaktif <> "" Or displaySaranNonReaktif <> "" Then
                If displaySaranReaktif <> "" Then
                    If totalSaranReaktif > 1 Then
                        txsaranall.Text = spasi + displaySaranReaktif
                    Else
                        txsaranall.Text = displaySaranReaktif
                    End If
                ElseIf displaySaranNonReaktif <> "" Then
                    If totalSaranNonReaktif > 1 Then
                        txsaranall.Text = spasi + displaySaranNonReaktif
                    Else
                        txsaranall.Text = displaySaranNonReaktif
                    End If
                End If
            Else
                ' Clear Saran
                txsaranall.ResetText()
            End If
        Else
            txketall.ResetText()
            txsaranall.ResetText()
        End If

        If varKey = 1 Then
            butsavelab.PerformClick()
        ElseIf varKey = 0 Then
            MsgBox("Tidak ada data yang diupdate, periksa result yang diinput atau kosongi kolom saran/keterangan terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
        End If
    End Sub

    Private Sub PrintSuratKetToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintSuratKetToolStripMenuItem.Click
        If CheckSQL("SELECT TglInputHasil FROM TransaksiLab WHERE NoUrut='" & TextBoxNoTransaksi.Text & "' AND TglInputHasil is not null") = True Then
            Dim keycancel As Boolean = False
            Report = New XtraReport
            Select Case MsgBox("Apakah anda ingin menampilkan surat keterangan dengan Kop?", MsgBoxStyle.YesNoCancel, "Question.")
                Case MsgBoxResult.Yes
                    Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\SuratKeteranganLabKop.repx", True)
                Case MsgBoxResult.No
                    Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\SuratKeteranganLabNonKop.repx", True)
                Case MsgBoxResult.Cancel
                    keycancel = True
                    MsgBox("Print Dibatalkan", MsgBoxStyle.Critical, "Cancel!")
            End Select

            Dim Tbls As DataTable = ReadSQL("SELECT Nama, NoNIK, CONVERT(date, TglLahir) As 'TglLahir', DomisiliAlamat FROM MasterPasien WHERE NoRekamMedis = '" & TextBoxNoRekamMedis.Text & "'")
            Dim Tdata As DataTable = New DataTable
            Tdata = CreateTablePasien()
            Tdata.Rows.Clear()

            If Tbls.Rows.Count > 0 And keycancel = False Then
                For Each TrowData As DataRow In Tbls.Rows
                    Dim Tlastnew As DataRow = Tdata.NewRow
                    Dim TglLahir As Date = TrowData("TglLahir")
                    Tlastnew("Nama") = TrowData("Nama")
                    Tlastnew("PTNIK") = TrowData("NoNIK")
                    Tlastnew("TglLahir") = Format(TglLahir, "dd") & " " & BulanIndonesia(Format(TglLahir, "MM")) & " " & Format(TglLahir, "yyyy")
                    Tlastnew("Alamat") = TrowData("DomisiliAlamat")
                    Tdata.Rows.Add(Tlastnew)
                Next
            End If

            Report.DataSource = Tdata
            Report.Bands.Item(BandKind.Detail).Controls("txtgl1").Text = Format(DateTimeTanggalTransaksi.Value, "dd") & " " & BulanIndonesia(Format(DateTimeTanggalTransaksi.Value, "MM")) & " " & Format(DateTimeTanggalTransaksi.Value, "yyyy")
            Report.Bands.Item(BandKind.Detail).Controls("txtgl2").Text = Format(DateAndTime.Now, "dd") & " " & BulanIndonesia(Format(DateAndTime.Now, "MM")) & " " & Format(DateAndTime.Now, "yyyy")
            Report.Bands.Item(BandKind.Detail).Controls("txhasil").Text = txketall.Text
            Report.Bands.Item(BandKind.Detail).Controls("txsaran").Text = txsaranall.Text
            'Report.RunDesigner()
            Report.ShowPreview()

            Select Case MsgBox("Cetak surat keterangan?", MsgBoxStyle.YesNo, "Question.")
                Case MsgBoxResult.Yes
                    Report.Print()
            End Select
        Else
            MsgBox("Input hasil terlebih dahulu.", MsgBoxStyle.Critical, "Warning!")
        End If
    End Sub

    Private Sub SendiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendiToolStripMenuItem.Click
        'Dim TempWhatsapp As String = ""
        'Dim TempEmail As String = ""
        NoWhatsappCompany = ""
        NoWhatsappMarketing = ""
        NoWhatsappCustomer = ""
        EmailCompany = ""
        EmailCustomer = ""
        SendHasilDL = False
        SendHasilThorax = False
        Dim sending As Boolean = False
        Dim TboolEmail As Boolean = True
        Dim TboolWhatsapp As Boolean = True
        Dim CountResultEmpty As Integer = 0
        If Utility.GetConfig("Email") = "No" Then TboolEmail = False
        If Utility.GetConfig("Whatsapp") = "No" Then TboolWhatsapp = False

        If TboolEmail = False And TboolWhatsapp = False Then
            MsgBox("Setting Config Whatsapp & Email Terlebih Dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Exit Sub
        End If

        Dim Tlab As DataTable = ReadSQL("SELECT a.SendingWhatsapp, a.SendingEmail, a.Kesimpulan, a.Saran, a.caraambil " & _
                                        "FROM transaksilab a " & _
                                        "WHERE a.TransLabID='" & buttindakanid.Text & "'")
        Dim TrowLab As DataRow = Tlab.Rows(0)

        Dim caraambil As String = TrowLab("caraambil")
        If IsDBNull(TrowLab("SendingWhatsapp")) = False And TrowLab("SendingWhatsapp").ToString.Trim <> "-" Then
            NoWhatsappCustomer = TrowLab("SendingWhatsapp")
        Else
            NoWhatsappCustomer = "-"
        End If

        If IsDBNull(TrowLab("SendingEmail")) = False And TrowLab("SendingEmail").ToString.Trim <> "-" Then
            EmailCustomer = TrowLab("SendingEmail")
        Else
            EmailCustomer = "-"
        End If
        ' Save PDF Hasil ke Path Tujuan
        Dim NameFile As String = TextBoxNoTransaksi.Text & "_Hasil_Laboratorium"
        Dim filepath As String = "FileDownload\Hasil\" & NameFile & ".pdf"
        If File.Exists(filepath) = False Then
            CreateHasilToPDF("Nothing", "Yes")
        End If

        'Cek Detail (Hematologi Lengkap & Thorax)
        Dim TblsDetail As DataTable = ReadSQL("SELECT NamaTindakan FROM TransaksiLabDetail WHERE TransLabID = '" & buttindakanid.Text & "'")
        For Each TrowDetail As DataRow In TblsDetail.Rows
            If Strings.LCase(TrowDetail("NamaTindakan").ToString).Contains("hematologi lengkap") = True Then
                'Check Hematologi Lengkap
                If Utility.GetConfig("Mesin") = "Yes" And CekKoneksi("SHOW TABLES FROM " & Ttcon.Tdb & "", Ttcon) = True Then
                    Dim NameFileDL As String = TextBoxNoTransaksi.Text & "_Hasil_Hematologi_Lengkap"
                    Dim filepathDL As String = "FileDownload\Hasil\Hematologi_Lengkap\" & NameFileDL & ".pdf"
                    If File.Exists(filepathDL) = False Then
                        'Save PDF
                        CreateHematologiLengkapToPDF("Nothing")

                        If File.Exists(filepathDL) = False Then
                            MsgBox("File Hematologi Lengkap tidak ditemukan, gagal mengirim hasil Whatsapp/Email.", MsgBoxStyle.Exclamation, "Warning!")
                            Exit Sub
                        End If
                    End If

                    SendHasilDL = True
                End If
            ElseIf Strings.LCase(TrowDetail("NamaTindakan").ToString).Contains("thorax") = True Then
                'Check Thorax
                Dim NameFileThorax As String = TextBoxNoTransaksi.Text & "_Hasil_Thorax"
                Dim filepaththorax As String = "FileDownload\Hasil\Thorax\" & NameFileThorax & ".pdf"
                If File.Exists(filepaththorax) = False Then
                    'Save PDF
                    CreateThoraxToPDF("Nothing", "Yes")

                    If File.Exists(filepaththorax) = False Then
                        MsgBox("File Thorax tidak ditemukan, gagal mengirim hasil Whatsapp/Email.", MsgBoxStyle.Exclamation, "Warning!")
                        Exit Sub
                    End If
                End If

                SendHasilThorax = True
            End If
        Next

        If chkclosed.Checked = True Then
            If CheckSQL("SELECT * FROM TransaksiLab WHERE TransLabID='" & buttindakanid.Text & "' AND TglCetakHasil is null") = True Then
                WriteSQL("update TransaksiLab set TglCetakHasil=getdate(), LabCetak=getdate() , [Status]='TAKEIT' , UserCetakHasil='" & UserLabAdmin & "' ,ClosedInputHasil=1 WHERE TransLabID='" & buttindakanid.Text & "'", 4)
            End If
        End If

        If TboolEmail = True Or TboolWhatsapp = True Then
            If Strings.LCase(caraambil.ToString).Contains("email") = True And TboolEmail = True Then
                'SENDING EMAIL
                Select Case MsgBox("Apakah data berikut sudah benar? " & vbCr & vbLf & vbCr & vbLf + "" & _
                          "Nama : " & TextBoxNamaPasien.Text & "" & vbCr & vbLf + "" & _
                          "Alamat :  " & txalamat.Text & "" & vbCr & vbLf + "" & _
                          "Tanggal Lahir : " & DateTimeTanggalLahir.Value & "", MsgBoxStyle.YesNo, "Verifikasi Sending Whatsapp & Email.")
                    Case MsgBoxResult.Yes
                        If CheckSQL("SELECT * FROM TransaksiLab WHERE TransLabID = '" & buttindakanid.Text & "' AND LabSendMail is not null") = True Then
                            If MsgBox("Hasil sudah pernah dikirim ke email tersebut, apakah tetap dilanjutkan?", MsgBoxStyle.YesNo, "Question.") = MsgBoxResult.No Then
                                MsgBox("Batal mengirimkan email.", MsgBoxStyle.Exclamation, "Warning!")
                                Exit Sub
                            End If
                        End If

                        thread = New System.Threading.Thread(AddressOf sendingemailcust)
                        thread.Start()

                        sending = True
                    Case MsgBoxResult.No
                        MsgBox("Cek data pasien kembali.", MsgBoxStyle.Exclamation, "Warning!")
                        Exit Sub
                End Select
            ElseIf Strings.LCase(caraambil.ToString).Contains("whatsapp") = True And TboolWhatsapp = True Then
                'SENDING WHATSAPP
                Select Case MsgBox("Apakah data berikut sudah benar? " & vbCr & vbLf & vbCr & vbLf + "" & _
                          "Nama : " & TextBoxNamaPasien.Text & "" & vbCr & vbLf + "" & _
                          "Alamat :  " & txalamat.Text & "" & vbCr & vbLf + "" & _
                          "Tanggal Lahir : " & DateTimeTanggalLahir.Value & "", MsgBoxStyle.YesNo, "Verifikasi Sending Whatsapp & Email.")
                    Case MsgBoxResult.Yes
                        If CheckSQL("SELECT * FROM TransaksiLab WHERE TransLabID = '" & buttindakanid.Text & "' AND LabSendMail is not null") = True Then
                            If MsgBox("Hasil sudah pernah dikirim ke whatsapp tersebut, apakah tetap dilanjutkan?", MsgBoxStyle.YesNo, "Question.") = MsgBoxResult.No Then
                                MsgBox("Batal mengirimkan email.", MsgBoxStyle.Exclamation, "Warning!")
                                Exit Sub
                            End If
                        End If

                        thread = New System.Threading.Thread(AddressOf sendingwhatsappcust)
                        thread.Start()

                        sending = True
                    Case MsgBoxResult.No
                        MsgBox("Cek data pasien kembali.", MsgBoxStyle.Exclamation, "Warning!")
                        Exit Sub
                End Select
            End If

            'SENDING WHATSAPP KE COMPANY
            Dim NoUrut As String = TextBoxNoTransaksi.Text
            Dim Tcompany As DataTable = ReadSQL("SELECT No_Handphone2, No_Handphone, Email_Perusahaan, TerimaHasilKaryawan, Whatsapp_Auto, Email_Auto FROM MasterCompany WHERE NoCompany='" & txcodepenagihan.Text.Trim & "'")
            If Tcompany.Rows.Count > 0 Then
                Dim TrowCompany As DataRow = Tcompany.Rows(0)
                If (TrowCompany("Whatsapp_Auto") = True And NoUrut.Contains("L") = True) Or (TrowCompany("Whatsapp_Auto") = True And NoUrut.Contains("M") = True) And TboolWhatsapp = True Then
                    NoWhatsappCompany = TrowCompany("No_Handphone")
                    Dim TboolWhatsappDuplicate As Boolean = False
                    If NoWhatsappCustomer.Contains(NoWhatsappCompany) = True Then
                        TboolWhatsappDuplicate = True
                    End If

                    If TboolWhatsappDuplicate = False Then
                        If MsgBox("Apakah anda ingin mengirim hasil ke Whatsapp perusahaan?", MsgBoxStyle.YesNo, "Question.") = MsgBoxResult.Yes Then
                            thread = New System.Threading.Thread(AddressOf sendingwhatsappcompany)
                            thread.Start()

                            sending = True
                        End If
                    End If
                ElseIf (TrowCompany("Email_Auto") = True And NoUrut.Contains("L") = True) Or (TrowCompany("Email_Auto") = True And NoUrut.Contains("M") = True) And TboolEmail = True Then
                    EmailCompany = TrowCompany("Email_Perusahaan")
                    Dim TboolEmailDuplicate As Boolean = False
                    If EmailCustomer.Contains(EmailCompany) = True Then
                        TboolEmailDuplicate = True
                    End If

                    If TboolEmailDuplicate = False Then
                        If MsgBox("Apakah anda ingin mengirim hasil ke Email perusahaan?", MsgBoxStyle.YesNo, "Question.") = MsgBoxResult.Yes Then
                            thread = New System.Threading.Thread(AddressOf sendingemailcompany)
                            thread.Start()

                            sending = True
                        End If
                    End If
                End If

                If TrowCompany("No_Handphone2").ToString.Trim <> "" And TrowCompany("No_Handphone2").ToString.Trim <> "0" And TrowCompany("No_Handphone2").ToString.Trim <> "-" And TboolWhatsapp = True Then
                    If MsgBox("Apakah anda ingin mengirim hasil ke Whatsapp Marketing?", MsgBoxStyle.YesNo, "Question.") = MsgBoxResult.Yes Then
                        NoWhatsappMarketing = TrowCompany("No_Handphone2")
                        Dim TboolWhatsappMarketingDuplicate As Boolean = False
                        If NoWhatsappCustomer.Contains(NoWhatsappMarketing) = True Then
                            TboolWhatsappMarketingDuplicate = True
                        End If

                        If TboolWhatsappMarketingDuplicate = False Then
                            thread = New System.Threading.Thread(AddressOf sendingwhatsappmarketing)
                            thread.Start()

                            sending = True
                        End If
                    End If
                End If
            End If

            If sending = False Then
                MsgBox("Tidak ada Email atau Whatsapp yang dikirimkan.", MsgBoxStyle.Exclamation, "Warning!")
            End If
        End If
    End Sub

    Private Sub PreviewHasilLabToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreviewHasilLabToolStripMenuItem.Click
        CreateHasilToPDF("Preview", "Yes")
    End Sub

    Private Sub exportpdfDL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exportpdfDL.Click
        CreateHematologiLengkapToPDF("Preview")
    End Sub

    Private Sub CreateHematologiLengkapToPDF(ByVal Action As String)
        Try
            If CheckingDL() = True Then
                Dim Tpasien As DataTable = ReadSQL("SELECT a.caraambil, c.JenisBayar, c.NoJenisBayar FROM transaksilab a " & _
                                                   "LEFT JOIN MasterPasien b ON a.IDInternet=b.NoRekamMedis " & _
                                                   "LEFT JOIN TransaksiLabBayar c on a.TransLabID=c.TransLabID " & _
                                                   "WHERE a.TransLabID='" & buttindakanid.Text & "'")
                Dim TrowPasien As DataRow = Tpasien.Rows(0)
                Dim caraambil As String = TrowPasien("caraambil")
                Dim Registrasi As String = TextBoxNoRekamMedis.Text
                Dim barcodenotrans As String = buttindakanid.Text
                Dim Nama As String = TextBoxGelar.Text & " " & TextBoxNamaPasien.Text & "/(" & TextBoxJenisKelamin.Text & ")" & vbCrLf
                Dim Tgltemp As Date = DateTimeTanggalLahir.Value
                Dim UmurPasien As String = ""
                If Tgltemp.Date.AddYears(120).Year < DateAndTime.Now.Year Then
                    UmurPasien = ""
                Else
                    UmurPasien = Format(DateTimeTanggalLahir.Value, "dd MMM yyyy") & " / " & TextBoxUmur.Text
                End If
                Dim Alamat As String = txalamat.Text
                Dim NoTransaksi As String = TextBoxNoTransaksi.Text & " (" & buttindakanid.Text & ")"
                Dim DrRequest As String = ""
                If (TextBoxNoTransaksi.Text.Contains("M")) Then
                    Dim Tsplit() As String = TrowPasien("NoJenisBayar").ToString.Split("-")
                    DrRequest = Tsplit(0).ToString.Trim
                Else
                    DrRequest = butdokter.Text
                End If
                Dim TanggalTrans As String = Format(DateTimeTanggalTransaksi.Value, "dd-MMM-yyyy")
                Dim KodeBarcode As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='KodeBarcode'")

                Dim RangeUmur As String = ""
                Dim T1 As Double = 0
                Dim T2 As Double = 0

                Dim Tstrtemp As String = ""
                If TextBoxNoTransaksi.Text.ToString.Contains("L") = True Then
                    Tstrtemp = Strings.Replace(TextBoxNoTransaksi.Text.ToString.Trim, "L", "8")
                ElseIf TextBoxNoTransaksi.Text.ToString.Contains("M") = True Then
                    Tstrtemp = Strings.Replace(TextBoxNoTransaksi.Text.ToString.Trim, "M", "9")
                End If

                Dim NoUrutMesin As String = KodeBarcode & Strings.Right(Tstrtemp.ToString.Trim, Len(Tstrtemp.ToString.Trim) - 2)

                Dim tbls As DataTable = ReadThemysql("SELECT a.plt_grafik, a.rbc_grafik, a.diff_grafik FROM sysmex a WHERE a.rnoreg='" & NoUrutMesin & "' AND a.`dok`<>'' AND a.`dok`<>0 order by a.seq_no desc limit 1", Ttcon)
                Dim seq_no As String = ReadThemysqlNIK("SELECT seq_no FROM sysmex a WHERE a.rnoreg='" & NoUrutMesin & "' AND a.`dok`<>'' AND a.`dok`<>0 order by a.seq_no desc limit 1", Ttcon)
                Dim tbls_grafik As DataTable = ReadThemysql("SELECT * FROM fsysmex2 WHERE seq_no IN (SELECT seq_no FROM sysmex a WHERE a.rnoreg='" & NoUrutMesin & "' AND a.`dok`<>'' AND a.`dok`<>0 AND a.seq_no = '" & seq_no & "')", Ttcon)
                Dim umur As Integer = ReadSQLNIK("SELECT DATEDIFF(YYYY, TglLahir, GETDATE()) as Umur FROM MasterPasien WHERE NoRekamMedis = '" & Registrasi & "'")
                Dim jenisKelamin As String = ReadSQLNIK("SELECT JenisKelamin FROM MasterPasien WHERE NoRekamMedis = '" & Registrasi & "'")
                Dim Tnilairujukan As New DataTable
                Dim Thasil As New DataTable
                Dim Tdata As New DataTable

                If tbls.Rows.Count > 0 Then
                    Dim TrowLab As DataRow = tbls.Rows(0)

                    For Each TrowData As DataRow In tbls_grafik.Rows
                        insertRowToTbls(Thasil, "Typstring", "" & TrowData("rnmjasa") & "")
                        insertRowToTbls(Thasil, "Typstring", "NilaiRujukan_" & TrowData("rnmjasa") & "")
                    Next

                    insertRowToTbls(Thasil, "typstring", "Registrasi")
                    insertRowToTbls(Thasil, "typstring", "Hasil")
                    insertRowToTbls(Thasil, "typstring", "Nama")
                    insertRowToTbls(Thasil, "typstring", "Umur")
                    insertRowToTbls(Thasil, "typstring", "Alamat")
                    insertRowToTbls(Thasil, "typstring", "NoTransaksi")
                    insertRowToTbls(Thasil, "typstring", "DrPelaksana")
                    insertRowToTbls(Thasil, "typstring", "DrRequest")
                    insertRowToTbls(Thasil, "typstring", "Tanggal")
                    insertRowToTbls(Thasil, "typstring", "barcodenotrans")

                    Dim Tnew As DataRow = Thasil.NewRow
                    For Each TrowData As DataRow In tbls_grafik.Rows
                        Tnew("" & TrowData("rnmjasa") & "") = TrowData("hasil")

                        Tnilairujukan = ReadSQL("SELECT * FROM MasterNilaiRujukanMesin WHERE KodeMesin = '" & TrowData("rnmjasa").ToString.Trim & "'")
                        For Each Tnilairujukanrow As DataRow In Tnilairujukan.Rows
                            RangeUmur = Tnilairujukanrow("RangeUmur").ToString.Trim
                            If RangeUmur.Contains("<") = True Then
                                RangeUmur = Trim(Strings.Replace(Strings.Replace(RangeUmur, "<", ""), "=", ""))
                                If CDbl(umur) < CDbl(RangeUmur) Then
                                    If jenisKelamin = "L" Then
                                        Tnew("NilaiRujukan_" & TrowData("rnmjasa") & "") = Tnilairujukanrow("Pria")
                                    ElseIf jenisKelamin = "P" Then
                                        Tnew("NilaiRujukan_" & TrowData("rnmjasa") & "") = Tnilairujukanrow("Wanita")
                                    End If
                                End If
                            ElseIf RangeUmur.Contains(">") = True Then
                                RangeUmur = Trim(Strings.Replace(Strings.Replace(RangeUmur, ">", ""), "=", ""))
                                If CDbl(umur) > CDbl(RangeUmur) Then
                                    If jenisKelamin = "L" Then
                                        Tnew("NilaiRujukan_" & TrowData("rnmjasa") & "") = Tnilairujukanrow("Pria")
                                    ElseIf jenisKelamin = "P" Then
                                        Tnew("NilaiRujukan_" & TrowData("rnmjasa") & "") = Tnilairujukanrow("Wanita")
                                    End If
                                End If
                            ElseIf RangeUmur.Contains("-") = True Then
                                Dim Tsplit() As String = RangeUmur.ToString.Split("-")
                                T1 = Trim(Tsplit(0))
                                T2 = Trim(Tsplit(1))

                                If CDbl(umur) > T1 And CDbl(umur) < T2 Then
                                    If jenisKelamin = "L" Then
                                        Tnew("NilaiRujukan_" & TrowData("rnmjasa") & "") = Tnilairujukanrow("Pria")
                                    ElseIf jenisKelamin = "P" Then
                                        Tnew("NilaiRujukan_" & TrowData("rnmjasa") & "") = Tnilairujukanrow("Wanita")
                                    End If
                                End If
                            End If
                        Next
                    Next

                    Tnew("Registrasi") = Registrasi
                    Tnew("Nama") = Nama
                    Tnew("Umur") = UmurPasien
                    Tnew("Alamat") = Alamat
                    Tnew("Tanggal") = TanggalTrans
                    Tnew("NoTransaksi") = NoTransaksi
                    Tnew("DrRequest") = DrRequest
                    Tnew("Hasil") = caraambil
                    Tnew("DrPelaksana") = DrPelaksanaKlinik
                    Tnew("barcodenotrans") = buttindakanid.Text
                    Thasil.Rows.Add(Tnew)

                    Report = New XtraReport
                    Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\Hasil\GrafikHematologiLengkap.repx", True)
                    Report.DataSource = Thasil
                    Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MM-yyyy HH:mm:ss") + " by " + UserLabAdmin
                    Report.Bands(BandKind.Detail).Controls.Add(CreateXRPictureBox(TrowLab("rbc_grafik"), 567, 65, 150, 175))
                    Report.Bands(BandKind.Detail).Controls.Add(CreateXRPictureBox(TrowLab("diff_grafik"), 567, 265, 150, 175))
                    Report.Bands(BandKind.Detail).Controls.Add(CreateXRPictureBox(TrowLab("plt_grafik"), 567, 465, 150, 175))

                    If Action = "Preview" Then
                        Report.ShowPreview()
                    End If

                    'SavePDF
                    Dim NameFile As String = TextBoxNoTransaksi.Text & "_Hasil_Hematologi_Lengkap"
                    Dim filepath As String = "FileDownload\Hasil\Hematologi_Lengkap\" & NameFile & ".pdf"
                    If File.Exists(filepath) Then
                        My.Computer.FileSystem.DeleteFile(filepath)
                    End If
                    Report.CreatePdfDocument(filepath)
                Else
                    MsgBox("Pastikan Hasil (Hematologi Lengkap) sudah di running atau verifikasi di mesin jika ingin melampirkannya di Whatsapp/Email.", MsgBoxStyle.Exclamation, "Warning")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CreateThoraxToPDF(ByVal Action As String, ByVal Kop As String)
        If CheckSQL("SELECT * FROM TransaksiLabHasilLain WHERE [NoUrut]='" & TextBoxNoTransaksi.Text & "'") = True Then
            Dim TempWhatsapp As String = ""
            Dim TempEmail As String = ""

            Dim Tlab As DataTable = ReadSQL("SELECT d.*, b.NoNIK, a.caraambil, a.SendingWhatsapp, a.SendingEmail, c.JenisBayar, c.NoJenisBayar " & _
                                            "FROM transaksilab a " & _
                                            "LEFT JOIN MasterPasien b ON a.IDInternet=b.NoRekamMedis " & _
                                            "LEFT JOIN TransaksiLabBayar c on a.TransLabID=c.TransLabID " & _
                                            "LEFT JOIN TransaksiLabHasilLain d on a.NoUrut=d.NoUrut " & _
                                            "WHERE a.TransLabID='" & buttindakanid.Text & "'")
            Dim TrowLab As DataRow = Tlab.Rows(0)
            Dim noNIK As String = ""
            Dim Pengirim As String = ""
            If IsDBNull(TrowLab("NoNIK")) = False Then noNIK = TrowLab("NoNIK") Else noNIK = "-"
            Dim caraambil As String = TrowLab("caraambil")
            If CheckSQL("SELECT * FROM MasterCompany WHERE NoCompany = '" & txcodepenagihan.Text.Trim & "' AND ReportHasilPerusahaan = 0") = True And TextBoxNoTransaksi.Text.Contains("M") = True Then
                Pengirim = "Atas Permintaan Sendiri"
            End If

            If IsDBNull(TrowLab("SendingWhatsapp")) = False And TrowLab("SendingWhatsapp").ToString.Trim <> "-" Then
                NoWhatsappCustomer = TrowLab("SendingWhatsapp")
                TempWhatsapp = NoWhatsappCustomer.Substring(0, 3) & "*****" & NoWhatsappCustomer.Substring(8, NoWhatsappCustomer.Length - 8)
                caraambil = caraambil.Replace(NoWhatsappCustomer, TempWhatsapp)
            Else
                NoWhatsappCustomer = "-"
            End If

            If IsDBNull(TrowLab("SendingEmail")) = False And TrowLab("SendingEmail").ToString.Trim <> "-" Then
                EmailCustomer = TrowLab("SendingEmail")
                TempEmail = EmailCustomer.Substring(0, 3) & "*****" & EmailCustomer.Substring(8, EmailCustomer.Length - 8)
                caraambil = caraambil.Replace(EmailCustomer, TempEmail)
            Else
                EmailCustomer = "-"
            End If

            insertRowToTbls(Tlab, "typstring", "Registrasi")
            insertRowToTbls(Tlab, "typstring", "Nama")
            insertRowToTbls(Tlab, "typstring", "Umur")
            insertRowToTbls(Tlab, "typstring", "Alamat")
            insertRowToTbls(Tlab, "typstring", "NoTransaksi")
            insertRowToTbls(Tlab, "typstring", "DrPelaksana")
            insertRowToTbls(Tlab, "typstring", "DrRequest")
            insertRowToTbls(Tlab, "typstring", "Tanggal")
            insertRowToTbls(Tlab, "typstring", "Hasil")

            For Each Trow As DataRow In Tlab.Rows
                Trow("Registrasi") = TextBoxNoRekamMedis.Text

                If (TextBoxNoTransaksi.Text.Contains("M")) Then
                    If IsNumeric(Trow("Nama")) = True Then
                        Trow("Nama") = TextBoxGelar.Text & " " & TextBoxNamaPasien.Text & "/(" & TextBoxJenisKelamin.Text & ")" & vbCrLf
                    Else
                        Trow("Nama") = TextBoxGelar.Text & " " & TextBoxNamaPasien.Text & " / " & noNIK & " (" & TextBoxJenisKelamin.Text & ")" & vbCrLf
                    End If
                Else
                    Trow("Nama") = TextBoxGelar.Text & " " & TextBoxNamaPasien.Text & "/(" & TextBoxJenisKelamin.Text & ")" & vbCrLf
                End If

                Dim Tgltemp As Date = DateTimeTanggalLahir.Value
                If Tgltemp.Date.AddYears(120).Year < DateAndTime.Now.Year Then
                    Trow("Umur") = ""
                Else
                    Trow("Umur") = Format(DateTimeTanggalLahir.Value, "dd MMM yyyy") & " / " & TextBoxUmur.Text
                End If

                Trow("Alamat") = txalamat.Text
                Trow("NoTransaksi") = TextBoxNoTransaksi.Text & " (" & buttindakanid.Text & ")"
                Trow("DrPelaksana") = DrPelaksanaKlinik
                Trow("Hasil") = caraambil
                If Pengirim <> "" Then
                    Trow("DrRequest") = Pengirim
                Else
                    If (TextBoxNoTransaksi.Text.Contains("M")) Then
                        Trow("DrRequest") = txpenagihan.Text.Trim
                    Else
                        Trow("DrRequest") = butdokter.Text
                    End If
                End If

                Trow("Tanggal") = Format(DateTimeTanggalTransaksi.Value, "dd-MMM-yyyy")
            Next

            Report = New XtraReport
            If Kop = "Yes" Then
                Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\Hasil\HasilLabThoraxKop.repx", True)
            ElseIf Kop = "No" Then
                Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\Hasil\HasilLabThoraxNonKop.repx", True)
            End If

            If Action = "Preview" And Action = "Nothing" Then
                Report.Bands.Item(BandKind.PageHeader).Controls("ttd").Visible = True
                Report.Bands.Item(BandKind.PageHeader).Controls("ttd").Height = 134
                Report.Bands.Item(BandKind.PageHeader).Controls("ttd").Width = 250
            ElseIf Action = "Print" Then
                If AutoTTD.Trim = "Yes" Then
                    Report.Bands.Item(BandKind.PageHeader).Controls("ttd").Visible = True
                    Report.Bands.Item(BandKind.PageHeader).Controls("ttd").Height = 134
                    Report.Bands.Item(BandKind.PageHeader).Controls("ttd").Width = 250
                Else
                    Report.Bands.Item(BandKind.PageHeader).Controls("ttd").Visible = False
                End If
            End If

            Report.DataSource = Tlab
            Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MM-yyyy HH:mm:ss") + " by " + UserLabAdmin

            If Action = "Preview" Then
                Report.ShowPreview()
            ElseIf Action = "Print" Then
                Report.Print()
            End If

            If Kop = "Yes" Then
                'SavePDF
                Dim NameFile As String = TextBoxNoTransaksi.Text & "_Hasil_Thorax"
                Dim filepath As String = "FileDownload\Hasil\Thorax\" & NameFile & ".pdf"
                If File.Exists(filepath) Then
                    My.Computer.FileSystem.DeleteFile(filepath)
                End If
                Report.CreatePdfDocument(filepath)
            End If

            ' Save hasil ke lokal directory
            'If Utility.GetConfig("BackupLaboratoriumHasil") = "Yes" AND Action = "Nothing" Then
            '    Dim PathFolder As String = Utility.GetConfig("BackupLaboratoriumHasilPath")
            '    PathFolder = PathFolder & "Offline" & "\" & Format(DateTimeTanggalTransaksi.Value, "yyyy") & "\" & Format(DateTimeTanggalTransaksi.Value, "MMMM") & "\" & Format(DateTimeTanggalTransaksi.Value, "dd") & "\Non Laboratorium\Thorax"
            '    If (Not System.IO.Directory.Exists(PathFolder)) Then
            '        System.IO.Directory.CreateDirectory(PathFolder)
            '    End If

            '    Dim NameFileThorax As String = "Thorax_" & TextBoxNoTransaksi.Text

            '    Dim filepath As String = PathFolder & "\" & NameFileThorax.Replace("/", "") & ".pdf"
            '    If File.Exists(filepath) Then
            '        My.Computer.FileSystem.DeleteFile(filepath)
            '    End If
            '    Report.CreatePdfDocument(filepath)
            'End If
        End If
    End Sub

    Private Sub CreateFisikToPDF(ByVal Action As String)
        'Dim Tempfisik As DataTable = ReadSQL("SELECT HasilFisikID,FisikNoUrut,FisikKet,REPLACE(replace(result,'.',''),'~',' ') as Result FROM transaksilabFisik WHERE (NoUrut='" & txtindakanid.Text & "' AND FisikNoUrut between 3006 AND 3028) order by FisikNoUrut asc")
        Dim Tempfisik As DataTable = ReadSQL("SELECT HasilFisikID,FisikNoUrut,FisikKet,REPLACE(result,'~',' ') as Result FROM transaksilabFisik WHERE NoUrut='" & TextBoxNoTransaksi.Text & "' AND ((FisikNoUrut between 3006 AND 3028) OR FisikNoUrut = 4001) order by FisikNoUrut asc")

        insertRowToTbls(Tempfisik, "typstring", "Registrasi")
        insertRowToTbls(Tempfisik, "typstring", "Nama")
        insertRowToTbls(Tempfisik, "typstring", "Umur")
        insertRowToTbls(Tempfisik, "typstring", "Alamat")
        insertRowToTbls(Tempfisik, "typstring", "NoTransaksi")
        insertRowToTbls(Tempfisik, "typstring", "DrPelaksana")
        insertRowToTbls(Tempfisik, "typstring", "DrRequest")
        insertRowToTbls(Tempfisik, "typstring", "Tanggal")
        insertRowToTbls(Tempfisik, "typstring", "Indent1")
        insertRowToTbls(Tempfisik, "typstring", "Indent2")
        insertRowToTbls(Tempfisik, "typstring", "Titikdua")
        insertRowToTbls(Tempfisik, "typstring", "barcode")
        insertRowToTbls(Tempfisik, "typstring", "Hasil")

        For Each Tcol As DataColumn In Tempfisik.Columns
            Tcol.ReadOnly = False
        Next

        Dim TempWhatsapp As String = ""
        Dim TempEmail As String = ""

        Dim Tlab As DataTable = ReadSQL("SELECT d.*, b.NoNIK, a.caraambil, a.SendingWhatsapp, a.SendingEmail, c.JenisBayar, c.NoJenisBayar " & _
                                        "FROM transaksilab a " & _
                                        "LEFT JOIN MasterPasien b ON a.IDInternet=b.NoRekamMedis " & _
                                        "LEFT JOIN TransaksiLabBayar c on a.TransLabID=c.TransLabID " & _
                                        "LEFT JOIN TransaksiLabHasilLain d on a.NoUrut=d.NoUrut " & _
                                        "WHERE a.TransLabID='" & buttindakanid.Text & "'")
        Dim TrowLab As DataRow = Tlab.Rows(0)
        Dim noNIK As String = ""
        Dim Pengirim As String = ""
        If IsDBNull(TrowLab("NoNIK")) = False Then noNIK = TrowLab("NoNIK") Else noNIK = "-"
        Dim caraambil As String = TrowLab("caraambil")
        If CheckSQL("SELECT * FROM MasterCompany WHERE NoCompany = '" & txcodepenagihan.Text.Trim & "' AND ReportHasilPerusahaan = 0") = True And TextBoxNoTransaksi.Text.Contains("M") = True Then
            Pengirim = "Atas Permintaan Sendiri"
        End If

        If IsDBNull(TrowLab("SendingWhatsapp")) = False And TrowLab("SendingWhatsapp").ToString.Trim <> "-" Then
            NoWhatsappCustomer = TrowLab("SendingWhatsapp")
            TempWhatsapp = NoWhatsappCustomer.Substring(0, 3) & "*****" & NoWhatsappCustomer.Substring(8, NoWhatsappCustomer.Length - 8)
            caraambil = caraambil.Replace(NoWhatsappCustomer, TempWhatsapp)
        Else
            NoWhatsappCustomer = "-"
        End If

        If IsDBNull(TrowLab("SendingEmail")) = False And TrowLab("SendingEmail").ToString.Trim <> "-" Then
            EmailCustomer = TrowLab("SendingEmail")
            TempEmail = EmailCustomer.Substring(0, 3) & "*****" & EmailCustomer.Substring(8, EmailCustomer.Length - 8)
            caraambil = caraambil.Replace(EmailCustomer, TempEmail)
        Else
            EmailCustomer = "-"
        End If

        For Each Trow As DataRow In Tempfisik.Rows
            Trow("Registrasi") = TextBoxNoRekamMedis.Text

            If (TextBoxNoTransaksi.Text.Contains("M")) Then
                If IsNumeric(Trow("Nama")) = True Then
                    Trow("Nama") = TextBoxGelar.Text & " " & TextBoxNamaPasien.Text & "/(" & TextBoxJenisKelamin.Text & ")" & vbCrLf
                Else
                    Trow("Nama") = TextBoxGelar.Text & " " & TextBoxNamaPasien.Text & " / " & noNIK & " (" & TextBoxJenisKelamin.Text & ")" & vbCrLf
                End If
            Else
                Trow("Nama") = TextBoxGelar.Text & " " & TextBoxNamaPasien.Text & "/(" & TextBoxJenisKelamin.Text & ")" & vbCrLf
            End If

            Dim Tgltemp As Date = DateTimeTanggalLahir.Value
            If Tgltemp.Date.AddYears(120).Year < DateAndTime.Now.Year Then
                Trow("Umur") = ""
            Else
                Trow("Umur") = Format(DateTimeTanggalLahir.Value, "dd MMM yyyy") & " / " & TextBoxUmur.Text
            End If

            Trow("Alamat") = txalamat.Text
            Trow("DrPelaksana") = DrPelaksanaKlinik
            Trow("NoTransaksi") = TextBoxNoTransaksi.Text & " (" & buttindakanid.Text & ")"
            Trow("Hasil") = caraambil
            If Pengirim <> "" Then
                Trow("DrRequest") = Pengirim
            Else
                If (TextBoxNoTransaksi.Text.Contains("M")) Then
                    Trow("DrRequest") = txpenagihan.Text.Trim
                Else
                    Trow("DrRequest") = butdokter.Text
                End If
            End If

            Trow("Tanggal") = Format(DateTimeTanggalTransaksi.Value, "dd-MMM-yyyy")

            'edit visus mata
            If (Trow("FisikNoUrut") = "3012" Or Trow("FisikNoUrut") = "3013" Or Trow("FisikNoUrut") = "3014" Or Trow("FisikNoUrut") = "3015") And Trow("Result").ToString.Trim <> "" And Trow("Result").ToString.Contains(",") = True Then
                Dim hasil As String = ""
                Dim TsplitHasil() As String = Trow("Result").ToString.Split(",")
                If TsplitHasil(0) = TsplitHasil(1) Then
                    hasil = "ODS " & TsplitHasil(0)
                Else
                    hasil = "OD " & TsplitHasil(0).ToString & " OS " & TsplitHasil(1).ToString
                End If

                Trow("Result") = hasil
            ElseIf (Trow("FisikNoUrut") = "3012" Or Trow("FisikNoUrut") = "3013" Or Trow("FisikNoUrut") = "3014" Or Trow("FisikNoUrut") = "3015") And Trow("Result").ToString.Trim = "" Then
                Trow("Result") = "Tidak dilakukan"
            End If
        Next

        ' 1 Report 2 Tabel
        'Dim TempLain As DataTable = ReadSQL("SELECT * FROM MasterPasien WHERE NoRekamMedis = 'L001-230303-0000001'")
        'Dim dataSet As New DataSet()
        'dataSet.Tables.Add(Tempfisik.Copy())
        'dataSet.Tables.Add(TempLain.Copy())

        Report = New XtraReport

        If Action = "Preview" Or Action = "Nothing" Then
            Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\Hasil\HasilLabFisikKop.repx", True)
        ElseIf Action = "Print" Then
            Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\Hasil\HasilLabFisik.repx", True)
        End If

        Report.DataSource = Tempfisik

        Report.Bands.Item(BandKind.GroupHeader).Controls("txbmi").Text = TextBoxIndeksMedik.Text
        Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MM-yyyy HH:mm:ss") + " by " + UserLabAdmin
        Report.Bands.Item(BandKind.PageHeader).Controls("nomorijinklinik").Text = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='NomorIjinLab'")

        Dim Tbls As DataTable = ReadSQL("SELECT a.result, a.fisiknourut FROM transaksilabfisik a, transaksilab b WHERE a.nourut='" & TextBoxNoTransaksi.Text & "' AND a.nourut=b.nourut")
        For Each Trow As DataRow In Tbls.Rows
            If Trow("fisiknourut") = cmbfisiknewdr.Tag.ToString Then Report.Bands.Item(BandKind.PageHeader).Controls("txdrpelaksana").Text = Trow("result") : GoTo GoBackthis
            If Trow("fisiknourut") = TextBoxTinggiBadan.Tag.ToString Then Report.Bands.Item(BandKind.GroupHeader).Controls("txtb").Text = Trow("result") : GoTo GoBackthis
            If Trow("fisiknourut") = TextBoxBeratBadan.Tag.ToString Then Report.Bands.Item(BandKind.GroupHeader).Controls("txbb").Text = Trow("result") : GoTo GoBackthis
            If Trow("fisiknourut") = TextBoxSistole.Tag.ToString Then Report.Bands.Item(BandKind.GroupHeader).Controls("txtensi").Text = Trow("result") : GoTo GoBackthis
            If Trow("fisiknourut") = TextBoxDetakNadi.Tag.ToString Then Report.Bands.Item(BandKind.GroupHeader).Controls("txnadi").Text = Trow("result") : GoTo GoBackthis
            If Trow("fisiknourut") = TextBoxSuhu.Tag.ToString Then Report.Bands.Item(BandKind.GroupHeader).Controls("txsuhu").Text = Trow("result") : GoTo GoBackthis
            If Trow("fisiknourut") = TextBoxNafas.Tag.ToString Then Report.Bands.Item(BandKind.GroupHeader).Controls("txrespirasi").Text = Trow("result") : GoTo GoBackthis
            If Trow("fisiknourut") = txriwayat.Tag.ToString Then Report.Bands.Item(BandKind.GroupHeader).Controls("txriwayat").Text = Trow("result") : GoTo GoBackthis
            If Trow("fisiknourut") = cmbtht.Tag.ToString Then Report.Bands.Item(BandKind.ReportFooter).Controls("txtht").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis
            If Trow("fisiknourut") = cmbanorexia.Tag.ToString Then Report.Bands.Item(BandKind.ReportFooter).Controls("txanorexia").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis
            If Trow("fisiknourut") = cmbmalaria.Tag.ToString Then Report.Bands.Item(BandKind.ReportFooter).Controls("txmalaria").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis
            If Trow("fisiknourut") = cmbkulit.Tag.ToString Then Report.Bands.Item(BandKind.ReportFooter).Controls("txkulit").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis
            If Trow("fisiknourut") = cmbtypoid.Tag.ToString Then Report.Bands.Item(BandKind.ReportFooter).Controls("txtypoid").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis
            If Trow("fisiknourut") = cmbbbturun.Tag.ToString Then Report.Bands.Item(BandKind.ReportFooter).Controls("txbbturun").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis
            If Trow("fisiknourut") = cmbambien.Tag.ToString Then Report.Bands.Item(BandKind.ReportFooter).Controls("txambien").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis
            If Trow("fisiknourut") = cmbkencing.Tag.ToString Then Report.Bands.Item(BandKind.ReportFooter).Controls("txkencing").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis
            If Trow("fisiknourut") = cmbvertigo.Tag.ToString Then Report.Bands.Item(BandKind.ReportFooter).Controls("txvertigo").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis

            If Trow("fisiknourut") = cmboperasi.Tag.ToString Then
                If Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") = "Ya" Then
                    Report.Bands.Item(BandKind.ReportFooter).Controls("txoperasi").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") & ", " & Format(dtkapanoperasi.Value, "yyyy") & " di " & txdimanaoperasi.Text & " karena " & txkenapaoperasi.Text : GoTo GoBackthis
                Else
                    Report.Bands.Item(BandKind.ReportFooter).Controls("txoperasi").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis
                End If
            End If

            If Trow("fisiknourut") = cmbrs.Tag.ToString Then
                If Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") = "Ya" Then
                    Report.Bands.Item(BandKind.ReportFooter).Controls("txrs").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") & ", " & Format(dtkapanrs.Value, "yyyy") & " di " & txdimanars.Text & " karena " & txkenapars.Text : GoTo GoBackthis
                Else
                    Report.Bands.Item(BandKind.ReportFooter).Controls("txrs").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis
                End If
            End If

            If Trow("fisiknourut") = cmbsehat.Tag.ToString Then Report.Bands.Item(BandKind.ReportFooter).Controls("txsehat").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis

            If Trow("fisiknourut") = cmbobat.Tag.ToString Then
                If Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") = "Ya" Then
                    Report.Bands.Item(BandKind.ReportFooter).Controls("txobat").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") & ", " & txpenyakitobat.Text : GoTo GoBackthis
                Else
                    Report.Bands.Item(BandKind.ReportFooter).Controls("txobat").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis
                End If
            End If

            If Trow("fisiknourut") = cmbnarkoba.Tag.ToString Then
                If Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") = "Ya" Then
                    Report.Bands.Item(BandKind.ReportFooter).Controls("txnarkoba").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") & ", " & Format(dtkapannarkoba.Value, "yyyy") & " jenis " & txjenisnarkoba.Text : GoTo GoBackthis
                Else
                    Report.Bands.Item(BandKind.ReportFooter).Controls("txnarkoba").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis
                End If
            End If

            If Trow("fisiknourut") = cmbhepatitis.Tag.ToString Then
                If Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") = "Ya" Then
                    Report.Bands.Item(BandKind.ReportFooter).Controls("txhepa").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") & ", " & Format(dthepatitis.Value, "yyyy") : GoTo GoBackthis
                Else
                    Report.Bands.Item(BandKind.ReportFooter).Controls("txhepa").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis
                End If
            End If

            If Trow("fisiknourut") = cmbtbc.Tag.ToString Then
                If Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") = "Ya" Then
                    Report.Bands.Item(BandKind.ReportFooter).Controls("txtbc").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") & ", " & Format(dttbc.Value, "dd") & " " & BulanIndonesia(Format(dttbc.Value, "MM")) & " " & Format(dttbc.Value, "yyyy") : GoTo GoBackthis
                Else
                    Report.Bands.Item(BandKind.ReportFooter).Controls("txtbc").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis
                End If
            End If

            If Trow("fisiknourut") = cmbhernia.Tag.ToString Then
                If Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") = "Ya" Then
                    Report.Bands.Item(BandKind.ReportFooter).Controls("txhernia").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") & ", " & Format(dthernia.Value, "yyyy") : GoTo GoBackthis
                Else
                    Report.Bands.Item(BandKind.ReportFooter).Controls("txhernia").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis
                End If
            End If

            If Trow("fisiknourut") = cmbsakitjantung.Tag.ToString Then
                If Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") = "Ya" Then
                    Report.Bands.Item(BandKind.ReportFooter).Controls("txsakitjantung").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") & ", " & Format(dtjantung.Value, "yyyy") : GoTo GoBackthis
                Else
                    Report.Bands.Item(BandKind.ReportFooter).Controls("txsakitjantung").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis
                End If
            End If

            If Trow("fisiknourut") = cmbhipertensi.Tag.ToString Then
                If Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") = "Ya" Then
                    Report.Bands.Item(BandKind.ReportFooter).Controls("txhipertensi").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") & ", " & Format(dthipertensi.Value, "yyyy") : GoTo GoBackthis
                Else
                    Report.Bands.Item(BandKind.ReportFooter).Controls("txhipertensi").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis
                End If
            End If

            If Trow("fisiknourut") = cmbepilepsi.Tag.ToString Then
                If Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") = "Ya" Then
                    Report.Bands.Item(BandKind.ReportFooter).Controls("txepilepsi").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") & ", " & Format(dtepilepsi.Value, "yyyy") : GoTo GoBackthis
                Else
                    Report.Bands.Item(BandKind.ReportFooter).Controls("txepilepsi").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis
                End If
            End If

            If Trow("fisiknourut") = cmbdiabetes.Tag.ToString Then
                If Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") = "Ya" Then
                    Report.Bands.Item(BandKind.ReportFooter).Controls("txdiabetes").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") & ", " & Format(dtdiabetes.Value, "yyyy") : GoTo GoBackthis
                Else
                    Report.Bands.Item(BandKind.ReportFooter).Controls("txdiabetes").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis
                End If
            End If

            If Trow("fisiknourut") = cmbpingsan.Tag.ToString Then Report.Bands.Item(BandKind.ReportFooter).Controls("txpingsan").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis
            If Trow("fisiknourut") = cmbgastritis.Tag.ToString Then Report.Bands.Item(BandKind.ReportFooter).Controls("txgastritis").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis
            If Trow("fisiknourut") = cmbpusing.Tag.ToString Then Report.Bands.Item(BandKind.ReportFooter).Controls("txpusing").Text = Strings.Replace(Strings.Replace(Trow("result"), ".", ""), "~", "") : GoTo GoBackthis

            If Trow("fisiknourut") = cmbrokok.Tag.ToString Then Report.Bands.Item(BandKind.ReportFooter).Controls("txrokok").Text = Trow("result") : GoTo GoBackthis
            If Trow("fisiknourut") = cmbalkohol.Tag.ToString Then Report.Bands.Item(BandKind.ReportFooter).Controls("txalkohol").Text = Trow("result") : GoTo GoBackthis
            If Trow("fisiknourut") = cmbkopi.Tag.ToString Then Report.Bands.Item(BandKind.ReportFooter).Controls("txkopi").Text = Trow("result") : GoTo GoBackthis
            If Trow("fisiknourut") = cmbpolamakan.Tag.ToString Then Report.Bands.Item(BandKind.ReportFooter).Controls("txpolamakan").Text = Trow("result") : GoTo GoBackthis
            If Trow("fisiknourut") = cmbistirahat.Tag.ToString Then Report.Bands.Item(BandKind.ReportFooter).Controls("txistirahat").Text = Trow("result") : GoTo GoBackthis
            If Trow("fisiknourut") = cmbolahraga.Tag.ToString Then Report.Bands.Item(BandKind.ReportFooter).Controls("txolahraga").Text = Trow("result") : GoTo GoBackthis
            If Trow("fisiknourut") = txsimpul.Tag.ToString Then Report.Bands.Item(BandKind.ReportFooter).Controls("txsimpul").Text = Trow("result") : GoTo GoBackthis

            If Trow("fisiknourut") = txsaranfisik.Tag.ToString Then
                If Trow("result").ToString.Trim = "" Then
                    Report.Bands.Item(BandKind.ReportFooter).Controls("lblsaran").Visible = False
                    Report.Bands.Item(BandKind.ReportFooter).Controls("titikduasaran").Visible = False
                End If

                Report.Bands.Item(BandKind.ReportFooter).Controls("txsaran").Text = Trow("result") : GoTo GoBackthis
            End If

GoBackthis:
        Next

        If Action = "Preview" Then
            Report.ShowPreview()
            'Report.RunDesigner()
        ElseIf Action = "Print" Then
            Report.Print()
        End If

        ' Save hasil ke lokal directory
        'If Utility.GetConfig("BackupLaboratoriumHasil") = "Yes" AND Action = "Nothing" Then
        '    Dim PathFolder As String = Utility.GetConfig("BackupLaboratoriumHasilPath")
        '    PathFolder = PathFolder & "Offline" & "\" & Format(DateTimeTanggalTransaksi.Value, "yyyy") & "\" & Format(DateTimeTanggalTransaksi.Value, "MMMM") & "\" & Format(DateTimeTanggalTransaksi.Value, "dd") & "\Non Laboratorium\Pemeriksaan Fisik"
        '    If (Not System.IO.Directory.Exists(PathFolder)) Then
        '        System.IO.Directory.CreateDirectory(PathFolder)
        '    End If

        '    Dim NameFileThorax As String = "Fisik_" & TextBoxNoTransaksi.Text

        '    Dim filepath As String = PathFolder & "\" & NameFileThorax.Replace("/", "") & ".pdf"
        '    If File.Exists(filepath) Then
        '        My.Computer.FileSystem.DeleteFile(filepath)
        '    End If
        '    Report.CreatePdfDocument(filepath)
        'End If
    End Sub

    Function CreateXRPictureBox(ByVal Tid As Array, ByVal LocX As Integer, ByVal LocY As Integer, ByVal SizeX As Integer, ByVal SizeY As Integer) As XRPictureBox
        Dim Byted() As Byte = Tid
        Dim Streamed As New System.IO.MemoryStream(Byted)

        Dim PictureBox As XRPictureBox = New XRPictureBox()
        PictureBox.Image = Image.FromStream(Streamed)
        PictureBox.Location = New Point(LocX, LocY)
        PictureBox.Size = New Size(SizeX, SizeY)
        PictureBox.Sizing = ImageSizeMode.StretchImage

        Return PictureBox
    End Function

    Function CheckingDL() As Boolean
        If Utility.GetConfig("Mesin") = "No" Then
            MsgBox("Set config mesin terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        If CekKoneksi("SHOW TABLES FROM " & Ttcon.Tdb & "", Ttcon) = False Then
            MsgBox("Diagram Hematologi Lengkap Gagal. Cek Koneksi ke Server DB " & Ttcon.Tdb & " atau IP " & Ttcon.Tip & ".", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        Return True
    End Function

    Private Sub butpreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butpreviewthorax.Click
        CreateThoraxToPDF("Preview", "Yes")
    End Sub

    Private Sub butpreviewecg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butpreviewecg.Click
        If CheckSQL("SELECT * FROM TransaksiLabHasilLain WHERE [NoUrut]='" & TextBoxNoTransaksi.Text & "'") = True Then
            Dim TempWhatsapp As String = ""
            Dim TempEmail As String = ""

            Dim Tlab As DataTable = ReadSQL("SELECT d.*, b.NoNIK, a.caraambil, a.SendingWhatsapp, a.SendingEmail, c.JenisBayar, c.NoJenisBayar " & _
                                            "FROM transaksilab a " & _
                                            "LEFT JOIN MasterPasien b ON a.IDInternet=b.NoRekamMedis " & _
                                            "LEFT JOIN TransaksiLabBayar c on a.TransLabID=c.TransLabID " & _
                                            "LEFT JOIN TransaksiLabHasilLain d on a.NoUrut=d.NoUrut " & _
                                            "WHERE a.TransLabID='" & buttindakanid.Text & "'")
            Dim TrowLab As DataRow = Tlab.Rows(0)
            Dim Tsimpul As String = ""
            Dim Tsaran As String = ""
            Dim noNIK As String = ""
            Dim Pengirim As String = ""
            If IsDBNull(TrowLab("NoNIK")) = False Then noNIK = TrowLab("NoNIK") Else noNIK = "-"
            Dim caraambil As String = TrowLab("caraambil")
            If CheckSQL("SELECT * FROM MasterCompany WHERE NoCompany = '" & txcodepenagihan.Text.Trim & "' AND ReportHasilPerusahaan = 0") = True And TextBoxNoTransaksi.Text.Contains("M") = True Then
                Pengirim = "Atas Permintaan Sendiri"
            End If

            If IsDBNull(TrowLab("SendingWhatsapp")) = False And TrowLab("SendingWhatsapp").ToString.Trim <> "-" Then
                NoWhatsappCustomer = TrowLab("SendingWhatsapp")
                TempWhatsapp = NoWhatsappCustomer.Substring(0, 3) & "*****" & NoWhatsappCustomer.Substring(8, NoWhatsappCustomer.Length - 8)
                caraambil = caraambil.Replace(NoWhatsappCustomer, TempWhatsapp)
            Else
                NoWhatsappCustomer = "-"
            End If

            If IsDBNull(TrowLab("SendingEmail")) = False And TrowLab("SendingEmail").ToString.Trim <> "-" Then
                EmailCustomer = TrowLab("SendingEmail")
                TempEmail = EmailCustomer.Substring(0, 3) & "*****" & EmailCustomer.Substring(8, EmailCustomer.Length - 8)
                caraambil = caraambil.Replace(EmailCustomer, TempEmail)
            Else
                EmailCustomer = "-"
            End If

            insertRowToTbls(Tlab, "typstring", "Registrasi")
            insertRowToTbls(Tlab, "typstring", "Nama")
            insertRowToTbls(Tlab, "typstring", "Umur")
            insertRowToTbls(Tlab, "typstring", "Alamat")
            insertRowToTbls(Tlab, "typstring", "NoTransaksi")
            insertRowToTbls(Tlab, "typstring", "DrPelaksana")
            insertRowToTbls(Tlab, "typstring", "DrRequest")
            insertRowToTbls(Tlab, "typstring", "Tanggal")
            insertRowToTbls(Tlab, "typstring", "Hasil")

            For Each Trow As DataRow In Tlab.Rows
                Trow("Registrasi") = TextBoxNoRekamMedis.Text

                If (TextBoxNoTransaksi.Text.Contains("M")) Then
                    If IsNumeric(Trow("Nama")) = True Then
                        Trow("Nama") = TextBoxGelar.Text & " " & TextBoxNamaPasien.Text & "/(" & TextBoxJenisKelamin.Text & ")" & vbCrLf
                    Else
                        Trow("Nama") = TextBoxGelar.Text & " " & TextBoxNamaPasien.Text & " / " & noNIK & " (" & TextBoxJenisKelamin.Text & ")" & vbCrLf
                    End If
                Else
                    Trow("Nama") = TextBoxGelar.Text & " " & TextBoxNamaPasien.Text & "/(" & TextBoxJenisKelamin.Text & ")" & vbCrLf
                End If

                Dim Tgltemp As Date = DateTimeTanggalLahir.Value
                If Tgltemp.Date.AddYears(120).Year < DateAndTime.Now.Year Then
                    Trow("Umur") = ""
                Else
                    Trow("Umur") = Format(DateTimeTanggalLahir.Value, "dd MMM yyyy") & " / " & TextBoxUmur.Text
                End If

                Trow("Alamat") = txalamat.Text
                Trow("NoTransaksi") = TextBoxNoTransaksi.Text & " (" & buttindakanid.Text & ")"
                Trow("DrPelaksana") = DrPelaksanaKlinik
                Trow("Hasil") = caraambil
                If Pengirim <> "" Then
                    Trow("DrRequest") = Pengirim
                Else
                    If (TextBoxNoTransaksi.Text.Contains("M")) Then
                        Trow("DrRequest") = txpenagihan.Text.Trim
                    Else
                        Trow("DrRequest") = butdokter.Text
                    End If
                End If

                Trow("Tanggal") = Format(DateTimeTanggalTransaksi.Value, "dd-MMM-yyyy")
            Next

            Report = New XtraReport
            Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\Hasil\HasilLabECGKop.repx", True)
            Report.Bands.Item(BandKind.PageHeader).Controls("ttd").Visible = True
            Report.Bands.Item(BandKind.PageHeader).Controls("ttd").Height = 134
            Report.Bands.Item(BandKind.PageHeader).Controls("ttd").Width = 250

            Report.DataSource = Tlab
            Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MM-yyyy HH:mm:ss") + " by " + UserLabAdmin
            Report.Bands.Item(BandKind.PageHeader).Controls("DokterECG").Text = ReadSQLNIK("SELECT DrECG FROM TransaksiLabHasilLain WHERE NoUrut='" & TextBoxNoTransaksi.Text & "'")

            'Report.RunDesigner()
            Report.ShowPreview()
            'Report.Print()
        End If
    End Sub

    Private Sub butpreviewaudio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butpreviewaudio.Click
        If CheckSQL("SELECT * FROM TransaksiLabHasilLain WHERE [NoUrut]='" & TextBoxNoTransaksi.Text & "'") = True Then
            Dim TempWhatsapp As String = ""
            Dim TempEmail As String = ""

            Dim Tlab As DataTable = ReadSQL("SELECT d.*, b.NoNIK, a.caraambil, a.SendingWhatsapp, a.SendingEmail, c.JenisBayar, c.NoJenisBayar " & _
                                            "FROM transaksilab a " & _
                                            "LEFT JOIN MasterPasien b ON a.IDInternet=b.NoRekamMedis " & _
                                            "LEFT JOIN TransaksiLabBayar c on a.TransLabID=c.TransLabID " & _
                                            "LEFT JOIN TransaksiLabHasilLain d on a.NoUrut=d.NoUrut " & _
                                            "WHERE a.TransLabID='" & buttindakanid.Text & "'")
            Dim TrowLab As DataRow = Tlab.Rows(0)
            Dim Tsimpul As String = ""
            Dim Tsaran As String = ""
            Dim noNIK As String = ""
            Dim Pengirim As String = ""
            If IsDBNull(TrowLab("NoNIK")) = False Then noNIK = TrowLab("NoNIK") Else noNIK = "-"
            Dim caraambil As String = TrowLab("caraambil")
            If CheckSQL("SELECT * FROM MasterCompany WHERE NoCompany = '" & txcodepenagihan.Text.Trim & "' AND ReportHasilPerusahaan = 0") = True And TextBoxNoTransaksi.Text.Contains("M") = True Then
                Pengirim = "Atas Permintaan Sendiri"
            End If

            If IsDBNull(TrowLab("SendingWhatsapp")) = False And TrowLab("SendingWhatsapp").ToString.Trim <> "-" Then
                NoWhatsappCustomer = TrowLab("SendingWhatsapp")
                TempWhatsapp = NoWhatsappCustomer.Substring(0, 3) & "*****" & NoWhatsappCustomer.Substring(8, NoWhatsappCustomer.Length - 8)
                caraambil = caraambil.Replace(NoWhatsappCustomer, TempWhatsapp)
            Else
                NoWhatsappCustomer = "-"
            End If

            If IsDBNull(TrowLab("SendingEmail")) = False And TrowLab("SendingEmail").ToString.Trim <> "-" Then
                EmailCustomer = TrowLab("SendingEmail")
                TempEmail = EmailCustomer.Substring(0, 3) & "*****" & EmailCustomer.Substring(8, EmailCustomer.Length - 8)
                caraambil = caraambil.Replace(EmailCustomer, TempEmail)
            Else
                EmailCustomer = "-"
            End If

            insertRowToTbls(Tlab, "typstring", "Registrasi")
            insertRowToTbls(Tlab, "typstring", "Nama")
            insertRowToTbls(Tlab, "typstring", "Umur")
            insertRowToTbls(Tlab, "typstring", "Alamat")
            insertRowToTbls(Tlab, "typstring", "NoTransaksi")
            insertRowToTbls(Tlab, "typstring", "DrPelaksana")
            insertRowToTbls(Tlab, "typstring", "DrRequest")
            insertRowToTbls(Tlab, "typstring", "Tanggal")
            insertRowToTbls(Tlab, "typstring", "Hasil")

            For Each Trow As DataRow In Tlab.Rows
                Trow("Registrasi") = TextBoxNoRekamMedis.Text

                If (TextBoxNoTransaksi.Text.Contains("M")) Then
                    If IsNumeric(Trow("Nama")) = True Then
                        Trow("Nama") = TextBoxGelar.Text & " " & TextBoxNamaPasien.Text & "/(" & TextBoxJenisKelamin.Text & ")" & vbCrLf
                    Else
                        Trow("Nama") = TextBoxGelar.Text & " " & TextBoxNamaPasien.Text & " / " & noNIK & " (" & TextBoxJenisKelamin.Text & ")" & vbCrLf
                    End If
                Else
                    Trow("Nama") = TextBoxGelar.Text & " " & TextBoxNamaPasien.Text & "/(" & TextBoxJenisKelamin.Text & ")" & vbCrLf
                End If

                Dim Tgltemp As Date = DateTimeTanggalLahir.Value
                If Tgltemp.Date.AddYears(120).Year < DateAndTime.Now.Year Then
                    Trow("Umur") = ""
                Else
                    Trow("Umur") = Format(DateTimeTanggalLahir.Value, "dd MMM yyyy") & " / " & TextBoxUmur.Text
                End If

                Trow("Alamat") = txalamat.Text
                Trow("NoTransaksi") = TextBoxNoTransaksi.Text & " (" & buttindakanid.Text & ")"
                Trow("DrPelaksana") = DrPelaksanaKlinik
                Trow("Hasil") = caraambil
                If Pengirim <> "" Then
                    Trow("DrRequest") = Pengirim
                Else
                    If (TextBoxNoTransaksi.Text.Contains("M")) Then
                        Trow("DrRequest") = txpenagihan.Text.Trim
                    Else
                        Trow("DrRequest") = butdokter.Text
                    End If
                End If

                Trow("Tanggal") = Format(DateTimeTanggalTransaksi.Value, "dd-MMM-yyyy")
            Next

            Report = New XtraReport
            Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\Hasil\HasilLabAudiometriKop.repx", True)
            Report.Bands.Item(BandKind.PageHeader).Controls("ttd").Visible = True
            Report.Bands.Item(BandKind.PageHeader).Controls("ttd").Height = 59
            Report.Bands.Item(BandKind.PageHeader).Controls("ttd").Width = 275

            Report.DataSource = Tlab
            Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MM-yyyy HH:mm:ss") + " by " + UserLabAdmin

            'Report.RunDesigner()
            Report.ShowPreview()
            'Report.Print()
        End If
    End Sub

    Private Sub cmbjenisthorax_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbjenisthorax.SelectedIndexChanged
        If cmbjenisthorax.Text.Trim <> "" Then
            Dim Thasil As New DataTable

            Thasil = ReadSQL("SELECT ValueThorax, Cor, Pulmo, Sinus, Skeletal, Kesimpulan FROM MasterNilaiHasilThorax WHERE ValueThorax = '" & cmbjenisthorax.Text.Trim & "'")
            If Thasil.Rows.Count > 0 Then
                For Each Trow As DataRow In Thasil.Rows
                    txthoraxcor.Text = Trow("Cor")
                    txthoraxpulmo.Text = Trow("Pulmo")
                    txthoraxsinus.Text = Trow("Sinus")
                    txthoraxskeletal.Text = Trow("Skeletal")
                    txthoraxkesimpulan.Text = Trow("Kesimpulan")
                Next
            End If
        End If
    End Sub

    Private Sub butfisiknewpreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butfisiknewpreview.Click
        If CheckSQL("SELECT * FROM TransaksiLabFisik WHERE NoUrut='" & TextBoxNoTransaksi.Text & "'") = True Then
            CreateFisikToPDF("Preview")
        Else
            MsgBox("Tidak ada data yang di preview.", MsgBoxStyle.Critical, "Warning")
        End If
    End Sub

    Private Sub DownloadHasilOnlineToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DownloadHasilOnlineToolStripMenuItem.Click
        Dim Tloc As String = ReadSQLNIK("SELECT StrValue  FROM MsConfig WHERE ConfigName='NoPoli'")
        Dim OnlineID As String = ReadThemysqlNIK("SELECT a.idlabinternet FROM transaksilab a WHERE a.idtempatlab = '" & Tloc & "' AND a.translabid = '" & buttindakanid.Text & "'", DB_Poliklinik)
        Dim status As Boolean = True

        If OnlineID = "-" Then
            MsgBox("Transaksi Tidak Terhubung dengan Hasil Online.", MsgBoxStyle.Exclamation, "Warning!")
            status = False
            'ElseIf CheckThemysql("SELECT namatindakan FROM transaksilabdetail a WHERE a.idlabinternet='" & OnlineID & "' AND a.mesin in ('TMS','SYSMEX','URINE','CL900')", Tqrcon) = False Then
            '    MsgBox("Transaksi yang anda pilih tidak ada tindakan yang berhubungan dengan mesin TMS/SYSMEX/URINE/CL900.", MsgBoxStyle.Exclamation, "Warning!")
            '    status = False
        End If

        If status = True Then
            ResultMachine.LoadAdminLab(buttindakanid.Text, TextBoxNoTransaksi.Text, "Diff3", "DownloadHasilOnline", Tloc)
            ResultMachine.ShowDialog()
        End If
    End Sub

    Private Sub txtb_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxTinggiBadan.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ".") Then e.Handled = True
    End Sub

    Private Sub txbb_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxBeratBadan.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ".") Then e.Handled = True
    End Sub

    Private Sub txnadi_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxDetakNadi.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ".") Then e.Handled = True
    End Sub

    Private Sub txsuhu_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxSuhu.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ".") Then e.Handled = True
    End Sub

    Private Sub txtekanan_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxSistole.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ".") Then e.Handled = True
    End Sub

    Private Sub txtekanan2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxDiastole.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ".") Then e.Handled = True
    End Sub

    Private Sub txrespirasi_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxNafas.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ".") Then e.Handled = True
    End Sub

    Private Sub butsetketeranganfisik_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butsetketeranganfisik.Click
        totalKetTidakNormal = 0
        totalKetNormal = 0
        totalSaranTidakNormal = 0
        totalSaranNormal = 0
        totalRiwayat = 0

        Dim displayRiwayat As String = ""
        Dim displayKeteranganTidakNormal As String = ""
        Dim displayKeteranganNormal As String = ""
        Dim displaySaranTidakNormal As String = ""
        Dim displaySaranNormal As String = ""
        Dim spasi As String = "  - "
        Dim varStatusKesehatan As String = ""
        Dim varKet As String = ""
        Dim varStatusTBC As Boolean = False
        Dim varStatusRectalToucher As Boolean = False

        If CheckingSaranKetrangan() = True Then
            'Set BMI
            Dim tblSaranBMI As DataTable = ReadSQL("SELECT * FROM MasterKesimpulanBMI WHERE WeightStatus = '" & GetKesimpulanBMI(TextBoxIndeksMedik.Text) & "'")

            For Each rowSaranBMI As DataRow In tblSaranBMI.Rows
                If rowSaranBMI("StatusBMI") = "Tidak Normal" Then
                    displayKeteranganTidakNormal = SetKeterangan(rowSaranBMI("WeightStatus"), rowSaranBMI("StatusBMI"), displayKeteranganTidakNormal, "BMI")
                    displaySaranTidakNormal = SetSaran(rowSaranBMI("Saran"), rowSaranBMI("StatusBMI"), displaySaranTidakNormal)
                End If
            Next

            'Set Nadi
            If CDbl(TextBoxDetakNadi.Text) < 60 Then
                displayKeteranganTidakNormal = SetKeterangan("Bradikardia", "Tidak Normal", displayKeteranganTidakNormal, "Nadi")
            ElseIf CDbl(TextBoxDetakNadi.Text) > 100 Then
                displayKeteranganTidakNormal = SetKeterangan("Takikardia", "Tidak Normal", displayKeteranganTidakNormal, "Nadi")
            End If

            'Set Tensi
            If CDbl(TextBoxSistole.Text) >= 160 Or CDbl(TextBoxDiastole.Text) >= 100 Then
                displayKeteranganTidakNormal = SetKeterangan("Hipertensi derajat II", "Tidak Normal", displayKeteranganTidakNormal, "Tensi")
            ElseIf CDbl(TextBoxSistole.Text) > 139 Or CDbl(TextBoxDiastole.Text) > 89 Then
                displayKeteranganTidakNormal = SetKeterangan("Hipertensi derajat I", "Tidak Normal", displayKeteranganTidakNormal, "Tensi")
            ElseIf CDbl(TextBoxSistole.Text) > 119 Or CDbl(TextBoxDiastole.Text) > 79 Then
                displayKeteranganTidakNormal = SetKeterangan("Prehipertensi", "Tidak Normal", displayKeteranganTidakNormal, "Tensi")
            End If

            'Set Suhu
            If CDbl(TextBoxSuhu.Text) > 37.5 Then displayKeteranganTidakNormal = SetKeterangan("Subfebris", "Tidak Normal", displayKeteranganTidakNormal, "Suhu")

            'Set Respirasi
            If CDbl(TextBoxNafas.Text) > 20 Then displayKeteranganTidakNormal = SetKeterangan("Takipnea", "Tidak Normal", displayKeteranganTidakNormal, "Respirasi")

            'Set Kesadaran
            If cmbkesadaran.Text <> "Compos mentis" Then
                displayKeteranganTidakNormal = SetKeterangan(cmbkesadaran.Text, "Tidak Normal", displayKeteranganTidakNormal, "Kesadaran")
                displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
            End If

            'Set Kepala
            If cmbkepala.Text <> "Dalam Batas Normal" Then
                displayKeteranganTidakNormal = SetKeterangan(ValueKesimpulan(cmbkepala.Text & txkepala.Text), "Tidak Normal", displayKeteranganTidakNormal, "Kepala")
                displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
            End If

            'Set Rambut
            If cmbrambut.Text <> "Dalam Batas Normal" Then
                displayKeteranganTidakNormal = SetKeterangan(ValueKesimpulan(cmbrambut.Text & txrambut.Text), "Tidak Normal", displayKeteranganTidakNormal, "Rambut")
                displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
            End If

            'Set Muka
            If cmbmuka.Text <> "Dalam Batas Normal" Then
                displayKeteranganTidakNormal = SetKeterangan(ValueKesimpulan(cmbmuka.Text & txmuka.Text), "Tidak Normal", displayKeteranganTidakNormal, "Muka")
                displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
            End If

            'Set Mata
            If cmbmata.Text <> "Dalam Batas Normal" Then
                displayKeteranganTidakNormal = SetKeterangan(ValueKesimpulan(cmbmata.Text & txmata.Text), "Tidak Normal", displayKeteranganTidakNormal, "Mata")
                displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
            End If

            'Set Buta Warna
            If cmbbutawarna.Text <> "Negatif" Then
                displayKeteranganTidakNormal = SetKeterangan(ValueKesimpulan(cmbbutawarna.Text & txbutwarna.Text), "Tidak Normal", displayKeteranganTidakNormal, "Buta Warna")
                displaySaranTidakNormal = SetSaran("Sebaiknya tidak ditempatkan di bagian yang membutuhkan perbedaan warna.", "Tidak Normal", displaySaranTidakNormal)
            End If

            'Set Mulut
            If cmbmulut.Text <> "Tidak Ada Keluhan" And cmbmulut.Text <> "Tidak dilakukan" Then
                displayKeteranganTidakNormal = SetKeterangan(ValueKesimpulan(cmbmulut.Text & txmulut.Text), "Tidak Normal", displayKeteranganTidakNormal, "Mulut")
                displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
            End If

            'Set Gigi
            If cmbgigi.Text <> "Tidak Ada Keluhan" And cmbgigi.Text <> "Tidak dilakukan" Then
                displayKeteranganTidakNormal = SetKeterangan(ValueKesimpulan(cmbgigi.Text & txgigi.Text), "Tidak Normal", displayKeteranganTidakNormal, "Gigi")
                displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
            End If

            'Set Lidah
            If cmblidah.Text <> "Tidak Ada Keluhan" And cmblidah.Text <> "Tidak dilakukan" Then
                displayKeteranganTidakNormal = SetKeterangan(ValueKesimpulan(cmblidah.Text & txlidah.Text), "Tidak Normal", displayKeteranganTidakNormal, "Lidah")
                displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
            End If

            'Set Tenggorokan
            If cmbtenggorokan.Text <> "Tidak Ada Keluhan" And cmbtenggorokan.Text <> "Tidak dilakukan" Then
                displayKeteranganTidakNormal = SetKeterangan(ValueKesimpulan(cmbtenggorokan.Text & txtenggorokan.Text), "Tidak Normal", displayKeteranganTidakNormal, "Tenggorokan")
                displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
            End If

            'Set Leher
            If cmbleher.Text <> "Dalam Batas Normal" Then
                displayKeteranganTidakNormal = SetKeterangan(ValueKesimpulan(cmbleher.Text & txleher.Text), "Tidak Normal", displayKeteranganTidakNormal, "Leher")
                displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
            End If

            'Set Dada
            If cmbdada.Text <> "Dalam Batas Normal" Then
                displayKeteranganTidakNormal = SetKeterangan(ValueKesimpulan(cmbdada.Text & txdada.Text), "Tidak Normal", displayKeteranganTidakNormal, "Dada")
                displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
            End If

            'Set Perut
            If ComboBoxFisikPerut.Text <> "Dalam Batas Normal" Then
                displayKeteranganTidakNormal = SetKeterangan(ValueKesimpulan(ComboBoxFisikPerut.Text & TextBoxFisikPerut.Text), "Tidak Normal", displayKeteranganTidakNormal, "Perut")
                displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
            End If

            'Set Rectal Toucher
            If ComboBoxFisikRectalToucher.Text <> "Tidak Dilakukan" And ComboBoxFisikRectalToucher.Text <> "Hemoroid (Negatif)" Then
                displayKeteranganTidakNormal = SetKeterangan(ValueKesimpulan(ComboBoxFisikRectalToucher.Text & TextBoxFisikRectalToucher.Text), "Tidak Normal", displayKeteranganTidakNormal, "Rectal Toucher")
                displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)

                ' Set Status Rectal Toucher
                varStatusRectalToucher = True
            End If

            'Set Integumen
            If cmbintegumen.Text <> "Dalam Batas Normal" Then
                displayKeteranganTidakNormal = SetKeterangan(ValueKesimpulan(cmbintegumen.Text & txintegumen.Text), "Tidak Normal", displayKeteranganTidakNormal, "Integumen")
                displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
            End If

            'Set Ekstemitas
            If cmbekstemitas.Text <> "Dalam Batas Normal" Then
                displayKeteranganTidakNormal = SetKeterangan(ValueKesimpulan(cmbekstemitas.Text & txekstemitas.Text), "Tidak Normal", displayKeteranganTidakNormal, "Ekstemitas")
                displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
            End If

            'Set Turgor
            If cmbturgor.Text <> "Normal" Then
                displayKeteranganTidakNormal = SetKeterangan(cmbturgor.Text, "Tidak Normal", displayKeteranganTidakNormal, "Turgor")
                displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
            End If

            'Set Telinga
            If cmbtelinga.Text <> "Dalam Batas Normal" Then
                displayKeteranganTidakNormal = SetKeterangan(ValueKesimpulan(cmbtelinga.Text & txtelinga.Text), "Tidak Normal", displayKeteranganTidakNormal, "Telinga")
                displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
            End If

            'Set Hidung
            If cmbhidung.Text <> "Dalam Batas Normal" Then
                displayKeteranganTidakNormal = SetKeterangan(ValueKesimpulan(cmbhidung.Text & txhidung.Text), "Tidak Normal", displayKeteranganTidakNormal, "Hidung")
                displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
            End If

            If cmbvisusmata.Text = "Visus dgn kacamata" Then
                'Set Visus kacamata
                Dim ketvisuskacamata As String = ""
                Dim ketvisustanpakacamata As String = ""
                If txvisustanpakacamata.Text = "6/6" And txvisustanpakacamata2.Text = "6/6" Then
                    ketvisustanpakacamata = "Normal"
                ElseIf txvisustanpakacamata.Text <> "6/6" And txvisustanpakacamata2.Text = "6/6" Then
                    ketvisustanpakacamata = "Myopia OD"
                ElseIf txvisustanpakacamata.Text = "6/6" And txvisustanpakacamata2.Text <> "6/6" Then
                    ketvisustanpakacamata = "Myopia OS"
                ElseIf txvisustanpakacamata.Text <> "6/6" And txvisustanpakacamata2.Text <> "6/6" Then
                    ketvisustanpakacamata = "Myopia ODS"
                End If

                If txvisuskacamata.Text = "6/6" And txvisuskacamata2.Text <> "6/6" Then
                    ketvisuskacamata = "Myopia OS"
                ElseIf txvisuskacamata.Text <> "6/6" And txvisuskacamata2.Text = "6/6" Then
                    ketvisuskacamata = "Myopia OD"
                ElseIf txvisuskacamata.Text = "6/6" And txvisuskacamata2.Text = "6/6" Then
                    ketvisuskacamata = ketvisustanpakacamata & " terkoreksi"
                ElseIf txvisuskacamata.Text <> "6/6" Or txvisuskacamata2.Text <> "6/6" Then
                    ketvisuskacamata = ketvisustanpakacamata
                End If

                If txvisuskacamata.Text = "" And txvisuskacamata2.Text = "" Then
                    If ketvisustanpakacamata <> "Normal" Then
                        displayKeteranganTidakNormal = SetKeterangan(ketvisustanpakacamata, "Tidak Normal", displayKeteranganTidakNormal, "Visus Mata")
                        displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
                        txkoreksiakhir.Text = ketvisustanpakacamata
                    Else
                        txkoreksiakhir.Text = "Normal"
                    End If
                Else
                    If ketvisuskacamata = "Normal" Or ketvisuskacamata.Contains("terkoreksi") = True Then
                        txkoreksiakhir.Text = ketvisuskacamata
                    Else
                        displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
                        displayKeteranganTidakNormal = SetKeterangan(ketvisuskacamata, "Tidak Normal", displayKeteranganTidakNormal, "Koreksi Akhir Mata")
                        txkoreksiakhir.Text = ketvisuskacamata
                    End If
                End If
            ElseIf cmbvisusmata.Text = "Visus Mata" Then
                'Set Visus Mata (Autorefraksi)

            End If

            'Set Kebiasaan
            If cmbrokok.Text <> "" And cmbrokok.Text <> "Tidak" Then displaySaranTidakNormal = SetSaran("Berhenti merokok.", "Tidak Normal", displaySaranTidakNormal)
            If cmbalkohol.Text <> "" And cmbalkohol.Text <> "Tidak" Then displaySaranTidakNormal = SetSaran("Berhenti minum alkohol.", "Tidak Normal", displaySaranTidakNormal)
            If cmbkopi.Text <> "" And cmbkopi.Text = "Ya, Banyak" Then displaySaranTidakNormal = SetSaran("Kurangi konsumsi kopi.", "Tidak Normal", displaySaranTidakNormal)
            If cmbpolamakan.Text <> "" And cmbpolamakan.Text <> "Teratur" Then displaySaranTidakNormal = SetSaran("Jaga pola makan yang teratur.", "Tidak Normal", displaySaranTidakNormal)
            If cmbistirahat.Text <> "" And cmbistirahat.Text <> "Teratur" Then displaySaranTidakNormal = SetSaran("Istirahat yang cukup.", "Tidak Normal", displaySaranTidakNormal)
            If cmbolahraga.Text <> "" And cmbolahraga.Text <> "Teratur" Then displaySaranTidakNormal = SetSaran("Olahraga yang teratur.", "Tidak Normal", displaySaranTidakNormal)

            'Set Riwayat
            If cmbhepatitis.Text <> "" And cmbhepatitis.Text <> "Tidak" Then displayRiwayat = SetRiwayat("Hepatitis", displayRiwayat) : displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
            If cmbhernia.Text <> "" And cmbhernia.Text <> "Tidak" Then displayRiwayat = SetRiwayat("Hernia", displayRiwayat) : displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
            If cmbsakitjantung.Text <> "" And cmbsakitjantung.Text <> "Tidak" Then displayRiwayat = SetRiwayat("Sakit Jantung", displayRiwayat) : displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
            If cmbhipertensi.Text <> "" And cmbhipertensi.Text <> "Tidak" Then displayRiwayat = SetRiwayat("Hipertensi", displayRiwayat) : displaySaranTidakNormal = SetSaran("Batasi konsumsi natrium / garam.", "Tidak Normal", displaySaranTidakNormal)
            If cmbepilepsi.Text <> "" And cmbepilepsi.Text <> "Tidak" Then displayRiwayat = SetRiwayat("Epilepsi", displayRiwayat) : displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
            If cmbdiabetes.Text <> "" And cmbdiabetes.Text <> "Tidak" Then displayRiwayat = SetRiwayat("Diabetes", displayRiwayat) : displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
            If cmbtbc.Text <> "" And cmbtbc.Text <> "Tidak" Then
                Dim Ttbc As Date = DateSerial(dttbc.Value.Year, dttbc.Value.Month, dttbc.Value.Day).AddMonths(6)
                If Ttbc > Date.Now Then
                    varStatusTBC = True
                End If
                displayRiwayat = SetRiwayat("TBC", displayRiwayat)
                displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
            End If

            'Update Saran & Ketrangan
            If displayKeteranganNormal <> "" Or displayKeteranganTidakNormal <> "" Or displaySaranTidakNormal <> "" Or displaySaranNormal <> "" Then
                'Set Keterangan
                If displayKeteranganNormal <> "" Or displayKeteranganTidakNormal <> "" Then
                    If displayKeteranganTidakNormal <> "" Then
                        If totalKetTidakNormal > 1 Then
                            varKet = spasi + displayKeteranganTidakNormal
                        Else
                            varKet = displayKeteranganTidakNormal
                        End If
                    End If
                Else
                    varKet = ""
                End If

                'Set Saran
                If displaySaranTidakNormal <> "" Or displaySaranNormal <> "" Then
                    If displaySaranTidakNormal <> "" Then
                        If totalSaranTidakNormal > 1 Then
                            txsaranfisik.Text = spasi + displaySaranTidakNormal
                        Else
                            txsaranfisik.Text = displaySaranTidakNormal
                        End If
                    End If
                Else
                    txsaranfisik.ResetText()
                End If
            Else
                varKet = ""
                txsaranfisik.ResetText()
            End If

            'Set Status Fit / Unfit
            If varStatusRectalToucher = True Then
                varStatusKesehatan = "UNFIT"
            ElseIf totalKetTidakNormal = 0 And totalRiwayat = 0 Then
                varStatusKesehatan = "FIT"
            ElseIf totalKetTidakNormal > 0 And varStatusTBC = False Then
                varStatusKesehatan = "FIT DENGAN CATATAN"
            ElseIf totalKetTidakNormal > 0 And varStatusTBC = True Then
                varStatusKesehatan = "UNFIT SEMENTARA"
            ElseIf totalKetTidakNormal = 0 And varStatusTBC = False Then
                varStatusKesehatan = "FIT"
            ElseIf totalKetTidakNormal = 0 And varStatusTBC = True Then
                varStatusKesehatan = "UNFIT SEMENTARA"
            End If

            If totalKetTidakNormal = 0 And totalRiwayat = 0 Then
                txsimpul.Text = varStatusKesehatan
            ElseIf totalKetTidakNormal > 0 And totalRiwayat = 0 Then
                txsimpul.Text = varStatusKesehatan & vbCrLf & vbCrLf & varKet
            ElseIf totalKetTidakNormal > 0 Then
                txsimpul.Text = varStatusKesehatan & vbCrLf & vbCrLf & varKet & vbCrLf & "Memiliki riwayat : " & Strings.Left(displayRiwayat, displayRiwayat.Length - 2)
            ElseIf totalKetTidakNormal = 0 And totalRiwayat > 0 Then
                txsimpul.Text = varStatusKesehatan & vbCrLf & vbCrLf & varKet & vbCrLf & "Memiliki riwayat : " & Strings.Left(displayRiwayat, displayRiwayat.Length - 2)
            End If

            Dim Tempsaranfisik As String = txsaranfisik.Text
            If Tempsaranfisik.Contains(vbCrLf & spasi & "Konsultasi ke dokter.") = True Then
                Tempsaranfisik = Tempsaranfisik.Replace(vbCrLf & spasi & "Konsultasi ke dokter.", "")
                txsaranfisik.Text = Tempsaranfisik & spasi & "Konsultasi ke dokter."
            ElseIf Tempsaranfisik.Contains(spasi & "Konsultasi ke dokter.") = True Then
                Tempsaranfisik = Tempsaranfisik.Replace(spasi & "Konsultasi ke dokter.", "")
                txsaranfisik.Text = Tempsaranfisik & spasi & "Konsultasi ke dokter."
            End If

            TextBoxStatusFit.Text = varStatusKesehatan

            MsgBox("Set saran & keterangan berhasil. Klik tombol simpan.", MsgBoxStyle.Information, "Success!")
        End If
    End Sub

    Function CheckingSaranKetrangan() As Boolean
        SetNilaiKosongFisik()

        Dim ArrayResultMata = New String() {}
        ArrayResultMata = New String() {"6/5", "6/6", "6/7.5", "6/9", "6/12", "6/15", "6/20", "6/24", "6/30", "6/38", "6/48", "6/60", "6/90", "6/120", "6/240"}

        '# Validasi Nilai Vital Statistik & Antropometri
        If CekNilaiVitalAntropometri("Sistole", TextBoxSistole.Text) = False Then Return False
        If CekNilaiVitalAntropometri("Diastole", TextBoxDiastole.Text) = False Then Return False
        If CekNilaiVitalAntropometri("Heart Rate", TextBoxDetakNadi.Text) = False Then Return False
        If CekNilaiVitalAntropometri("Respiratory Rate", TextBoxNafas.Text) = False Then Return False
        If CekNilaiVitalAntropometri("Suhu", TextBoxSuhu.Text) = False Then Return False
        If CekNilaiVitalAntropometri("Tinggi Badan", TextBoxTinggiBadan.Text) = False Then Return False
        If CekNilaiVitalAntropometri("Berat Badan", TextBoxBeratBadan.Text) = False Then Return False

        'Pemeriksaan Head to Toe
        If cmbkesadaran.Text.Trim = "" Then MsgBox("Cek kembali kesadaran.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        If cmbkepala.Text.Trim = "" Then MsgBox("Cek kembali kepala.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        If cmbrambut.Text.Trim = "" Then MsgBox("Cek kembali rambut.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        If cmbmuka.Text.Trim = "" Then MsgBox("Cek kembali muka.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        If cmbmata.Text.Trim = "" Then MsgBox("Cek kembali mata.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        If cmbbutawarna.Text.Trim = "" Then MsgBox("Cek kembali buta warna.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        If cmbtelinga.Text.Trim = "" Then MsgBox("Cek kembali telinga.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        If cmbhidung.Text.Trim = "" Then MsgBox("Cek kembali hidung.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        If cmbmulut.Text.Trim = "" Then MsgBox("Cek kembali mulut.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        If cmbgigi.Text.Trim = "" Then MsgBox("Cek kembali gigi.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        If cmblidah.Text.Trim = "" Then MsgBox("Cek kembali lidah.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        If cmbtenggorokan.Text.Trim = "" Then MsgBox("Cek kembali tenggorokan.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        If cmbleher.Text.Trim = "" Then MsgBox("Cek kembali leher.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        If cmbdada.Text.Trim = "" Then MsgBox("Cek kembali dada.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        If ComboBoxFisikPerut.Text.Trim = "" Then MsgBox("Cek kembali perut.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        If ComboBoxFisikRectalToucher.Text.Trim = "" Then MsgBox("Cek kembali perut.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        If cmbintegumen.Text.Trim = "" Then MsgBox("Cek kembali integumen.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        If cmbekstemitas.Text.Trim = "" Then MsgBox("Cek kembali ekstemitas.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        If cmbturgor.Text.Trim = "" Then MsgBox("Cek kembali turgor.", MsgBoxStyle.Exclamation, "Warning!") : Return False

        If cmbvisusmata.Text = "Visus dgn kacamata" Then
            'Cek Visus
            If txvisuskacamata.Text <> "" And txvisuskacamata2.Text = "" Then
                MsgBox("Cek kembali visus kacamata.", MsgBoxStyle.Exclamation, "Warning!") : Return False
            ElseIf txvisuskacamata.Text = "" And txvisuskacamata2.Text <> "" Then
                MsgBox("Cek kembali visus kacamata.", MsgBoxStyle.Exclamation, "Warning!") : Return False
            ElseIf txvisustanpakacamata.Text <> "" And txvisustanpakacamata2.Text = "" Then
                MsgBox("Cek kembali visus tanpa kacamata.", MsgBoxStyle.Exclamation, "Warning!") : Return False
            ElseIf txvisustanpakacamata.Text = "" And txvisustanpakacamata2.Text <> "" Then
                MsgBox("Cek kembali visus tanpa kacamata.", MsgBoxStyle.Exclamation, "Warning!") : Return False
            ElseIf txvisustanpakacamata.Text = "" Or txvisustanpakacamata2.Text = "" Then
                MsgBox("Cek kembali visus tanpa kacamata.", MsgBoxStyle.Exclamation, "Warning!") : Return False
            End If

            Dim statusvisuskacamata As Boolean = False
            Dim statusvisuskacamata2 As Boolean = False
            Dim statusvisustanpakacamata As Boolean = False
            Dim statusvisustanpakacamata2 As Boolean = False
            For Each element As String In ArrayResultMata
                If txvisuskacamata.Text <> "" And txvisuskacamata2.Text <> "" Then
                    If txvisuskacamata.Text = element Then statusvisuskacamata = True
                    If txvisuskacamata2.Text = element Then statusvisuskacamata2 = True
                End If

                If txvisustanpakacamata.Text <> "" And txvisustanpakacamata2.Text <> "" Then
                    If txvisustanpakacamata.Text = element Then statusvisustanpakacamata = True
                    If txvisustanpakacamata2.Text = element Then statusvisustanpakacamata2 = True
                End If
            Next
            If txvisustanpakacamata.Text = "" And txvisustanpakacamata2.Text = "" And txvisuskacamata.Text <> "" And txvisuskacamata2.Text <> "" And (statusvisuskacamata = False Or statusvisuskacamata2 = False) Then MsgBox("Cek kembali visus kacamata.", MsgBoxStyle.Exclamation, "Warning!") : Return False
            If txvisustanpakacamata.Text <> "" And txvisustanpakacamata2.Text <> "" And (statusvisustanpakacamata = False Or statusvisustanpakacamata2 = False) Then MsgBox("Cek kembali visus tanpa kacamata.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        End If

        'Cek Operasi
        If cmboperasi.Text = "Ya" Then
            If txkenapaoperasi.Text = "" Or txdimanaoperasi.Text = "" Or dtkapanoperasi.Value = "01-01-1900" Then MsgBox("Cek kembali detail operasi.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        ElseIf (cmboperasi.Text <> "Tidak" And cmboperasi.Text <> "Ya") Then
            MsgBox("Cek kembali operasi.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        End If

        'Cek RS
        If cmbrs.Text = "Ya" Then
            If txkenapars.Text = "" Or txdimanars.Text = "" Or dtkapanrs.Value = "01-01-1900" Then MsgBox("Cek kembali detail RS.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        ElseIf (cmbrs.Text <> "Tidak" And cmbrs.Text <> "Ya") Then
            MsgBox("Cek kembali RS.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        End If

        'Cek Penyakit
        If cmbobat.Text = "Ya" Then
            If txpenyakitobat.Text = "" Then MsgBox("Cek kembali detail Penyakit.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        ElseIf cmbobat.Text <> "Tidak" And cmbobat.Text <> "Ya" Then
            MsgBox("Cek kembali Penyakit.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        End If

        'Cek Narkoba
        If cmbnarkoba.Text = "Ya" Then
            If txjenisnarkoba.Text = "" Or dtkapannarkoba.Value = "01-01-1900" Then MsgBox("Cek kembali detail Narkoba.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        ElseIf (cmbnarkoba.Text <> "Tidak" And cmbnarkoba.Text <> "Ya") Then
            MsgBox("Cek kembali Narkoba.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        End If

        'Cek Kebiasaan
        If cmbrokok.Text = "" Then MsgBox("Cek kembali kebiasaan rokok.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        If cmbalkohol.Text = "" Then MsgBox("Cek kembali kebiasaan alkohol.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        If cmbkopi.Text = "" Then MsgBox("Cek kembali kebiasaan kopi.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        If cmbpolamakan.Text = "" Then MsgBox("Cek kembali kebiasaan pola makan.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        If cmbistirahat.Text = "" Then MsgBox("Cek kembali kebiasaan istirahat.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        If cmbolahraga.Text = "" Then MsgBox("Cek kembali kebiasaan olahraga.", MsgBoxStyle.Exclamation, "Warning!") : Return False

        'Cek Penyakit
        If cmbhepatitis.Text = "Ya" Then
            If dthepatitis.Value = "01-01-1900" Then MsgBox("Cek kembali detail Hepatitis.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        ElseIf cmbhepatitis.Text <> "Tidak" And cmbhepatitis.Text <> "Ya" Then
            MsgBox("Cek kembali Hepatitis.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        End If

        If cmbtbc.Text = "Ya" Then
            If dttbc.Value = "01-01-1900" Then MsgBox("Cek kembali detail TBC.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        ElseIf cmbtbc.Text <> "Tidak" And cmbtbc.Text <> "Ya" Then
            MsgBox("Cek kembali TBC.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        End If

        If cmbhernia.Text = "Ya" Then
            If dthernia.Value = "01-01-1900" Then MsgBox("Cek kembali detail Hernia.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        ElseIf cmbhernia.Text <> "Tidak" And cmbhernia.Text <> "Ya" Then
            MsgBox("Cek kembali Hernia.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        End If

        If cmbsakitjantung.Text = "Ya" Then
            If dtjantung.Value = "01-01-1900" Then MsgBox("Cek kembali detail Sakit Jantung.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        ElseIf cmbsakitjantung.Text <> "Tidak" And cmbsakitjantung.Text <> "Ya" Then
            MsgBox("Cek kembali Sakit Jantung.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        End If

        If cmbhipertensi.Text = "Ya" Then
            If dthipertensi.Value = "01-01-1900" Then MsgBox("Cek kembali detail Hipertensi.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        ElseIf cmbhipertensi.Text <> "Tidak" And cmbhipertensi.Text <> "Ya" Then
            MsgBox("Cek kembali Hipertensi.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        End If

        If cmbepilepsi.Text = "Ya" Then
            If dtepilepsi.Value = "01-01-1900" Then MsgBox("Cek kembali detail Epilepsi.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        ElseIf cmbepilepsi.Text <> "Tidak" And cmbepilepsi.Text <> "Ya" Then
            MsgBox("Cek kembali Epilepsi.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        End If

        If cmbdiabetes.Text = "Ya" Then
            If dtdiabetes.Value = "01-01-1900" Then MsgBox("Cek kembali detail Diabetes.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        ElseIf cmbdiabetes.Text <> "Tidak" And cmbdiabetes.Text <> "Ya" Then
            MsgBox("Cek kembali Diabetes.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        End If

        Return True
    End Function

    Private Sub SetSaranKeterangan()
        totalKetTidakNormal = 0
        totalKetNormal = 0
        totalSaranTidakNormal = 0
        totalSaranNormal = 0
        totalRiwayat = 0

        Dim displayRiwayat As String = ""
        Dim displayKeteranganTidakNormal As String = ""
        Dim displayKeteranganNormal As String = ""
        Dim displaySaranTidakNormal As String = ""
        Dim displaySaranNormal As String = ""
        Dim spasi As String = "  - "
        Dim varStatusKesehatan As String = ""
        Dim varKet As String = ""
        Dim varStatusTBC As Boolean = False
        Dim varStatusRectalToucher As Boolean = False

        'Set BMI
        Dim tblSaranBMI As DataTable = ReadSQL("SELECT * FROM MasterKesimpulanBMI WHERE WeightStatus = '" & GetKesimpulanBMI(TextBoxIndeksMedik.Text) & "'")

        For Each rowSaranBMI As DataRow In tblSaranBMI.Rows
            If rowSaranBMI("StatusBMI") = "Tidak Normal" Then
                displayKeteranganTidakNormal = SetKeterangan(rowSaranBMI("WeightStatus"), rowSaranBMI("StatusBMI"), displayKeteranganTidakNormal, "BMI")
                displaySaranTidakNormal = SetSaran(rowSaranBMI("Saran"), rowSaranBMI("StatusBMI"), displaySaranTidakNormal)
            End If
        Next

        'Set Nadi
        If CDbl(TextBoxDetakNadi.Text) < 60 Then
            displayKeteranganTidakNormal = SetKeterangan("Bradikardia", "Tidak Normal", displayKeteranganTidakNormal, "Nadi")
        ElseIf CDbl(TextBoxDetakNadi.Text) > 100 Then
            displayKeteranganTidakNormal = SetKeterangan("Takikardia", "Tidak Normal", displayKeteranganTidakNormal, "Nadi")
        End If

        'Set Tensi
        If CDbl(TextBoxSistole.Text) >= 160 Or CDbl(TextBoxDiastole.Text) >= 100 Then
            displayKeteranganTidakNormal = SetKeterangan("Hipertensi derajat II", "Tidak Normal", displayKeteranganTidakNormal, "Tensi")
        ElseIf CDbl(TextBoxSistole.Text) > 139 Or CDbl(TextBoxDiastole.Text) > 89 Then
            displayKeteranganTidakNormal = SetKeterangan("Hipertensi derajat I", "Tidak Normal", displayKeteranganTidakNormal, "Tensi")
        ElseIf CDbl(TextBoxSistole.Text) > 119 Or CDbl(TextBoxDiastole.Text) > 79 Then
            displayKeteranganTidakNormal = SetKeterangan("Prehipertensi", "Tidak Normal", displayKeteranganTidakNormal, "Tensi")
        End If

        'Set Suhu
        If CDbl(TextBoxSuhu.Text) > 37.5 Then displayKeteranganTidakNormal = SetKeterangan("Subfebris", "Tidak Normal", displayKeteranganTidakNormal, "Suhu")

        'Set Respirasi
        If CDbl(TextBoxNafas.Text) > 20 Then displayKeteranganTidakNormal = SetKeterangan("Takipnea", "Tidak Normal", displayKeteranganTidakNormal, "Respirasi")

        'Set Kesadaran
        If cmbkesadaran.Text <> "Compos mentis" Then
            displayKeteranganTidakNormal = SetKeterangan(cmbkesadaran.Text, "Tidak Normal", displayKeteranganTidakNormal, "Kesadaran")
            displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
        End If

        'Set Kepala
        If cmbkepala.Text <> "Dalam Batas Normal" Then
            displayKeteranganTidakNormal = SetKeterangan(ValueKesimpulan(cmbkepala.Text & txkepala.Text), "Tidak Normal", displayKeteranganTidakNormal, "Kepala")
            displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
        End If

        'Set Rambut
        If cmbrambut.Text <> "Dalam Batas Normal" Then
            displayKeteranganTidakNormal = SetKeterangan(ValueKesimpulan(cmbrambut.Text & txrambut.Text), "Tidak Normal", displayKeteranganTidakNormal, "Rambut")
            displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
        End If

        'Set Muka
        If cmbmuka.Text <> "Dalam Batas Normal" Then
            displayKeteranganTidakNormal = SetKeterangan(ValueKesimpulan(cmbmuka.Text & txmuka.Text), "Tidak Normal", displayKeteranganTidakNormal, "Muka")
            displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
        End If

        'Set Mata
        If cmbmata.Text <> "Dalam Batas Normal" Then
            displayKeteranganTidakNormal = SetKeterangan(ValueKesimpulan(cmbmata.Text & txmata.Text), "Tidak Normal", displayKeteranganTidakNormal, "Mata")
            displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
        End If

        'Set Buta Warna
        If cmbbutawarna.Text <> "Negatif" Then
            displayKeteranganTidakNormal = SetKeterangan(ValueKesimpulan(cmbbutawarna.Text & txbutwarna.Text), "Tidak Normal", displayKeteranganTidakNormal, "Buta Warna")
            displaySaranTidakNormal = SetSaran("Sebaiknya tidak ditempatkan di bagian yang membutuhkan perbedaan warna.", "Tidak Normal", displaySaranTidakNormal)
        End If

        'Set Mulut
        If cmbmulut.Text <> "Tidak Ada Keluhan" And cmbmulut.Text <> "Tidak dilakukan" Then
            displayKeteranganTidakNormal = SetKeterangan(ValueKesimpulan(cmbmulut.Text & txmulut.Text), "Tidak Normal", displayKeteranganTidakNormal, "Mulut")
            displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
        End If

        'Set Gigi
        If cmbgigi.Text <> "Tidak Ada Keluhan" And cmbgigi.Text <> "Tidak dilakukan" Then
            displayKeteranganTidakNormal = SetKeterangan(ValueKesimpulan(cmbgigi.Text & txgigi.Text), "Tidak Normal", displayKeteranganTidakNormal, "Gigi")
            displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
        End If

        'Set Lidah
        If cmblidah.Text <> "Tidak Ada Keluhan" And cmblidah.Text <> "Tidak dilakukan" Then
            displayKeteranganTidakNormal = SetKeterangan(ValueKesimpulan(cmblidah.Text & txlidah.Text), "Tidak Normal", displayKeteranganTidakNormal, "Lidah")
            displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
        End If

        'Set Tenggorokan
        If cmbtenggorokan.Text <> "Tidak Ada Keluhan" And cmbtenggorokan.Text <> "Tidak dilakukan" Then
            displayKeteranganTidakNormal = SetKeterangan(ValueKesimpulan(cmbtenggorokan.Text & txtenggorokan.Text), "Tidak Normal", displayKeteranganTidakNormal, "Tenggorokan")
            displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
        End If

        'Set Leher
        If cmbleher.Text <> "Dalam Batas Normal" Then
            displayKeteranganTidakNormal = SetKeterangan(ValueKesimpulan(cmbleher.Text & txleher.Text), "Tidak Normal", displayKeteranganTidakNormal, "Leher")
            displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
        End If

        'Set Dada
        If cmbdada.Text <> "Dalam Batas Normal" Then
            displayKeteranganTidakNormal = SetKeterangan(ValueKesimpulan(cmbdada.Text & txdada.Text), "Tidak Normal", displayKeteranganTidakNormal, "Dada")
            displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
        End If

        'Set Perut
        If ComboBoxFisikPerut.Text <> "Dalam Batas Normal" Then
            displayKeteranganTidakNormal = SetKeterangan(ValueKesimpulan(ComboBoxFisikPerut.Text & TextBoxFisikPerut.Text), "Tidak Normal", displayKeteranganTidakNormal, "Perut")
            displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
        End If

        'Set Rectal Toucher
        If ComboBoxFisikRectalToucher.Text <> "Tidak Dilakukan" And ComboBoxFisikRectalToucher.Text <> "Hemoroid (Negatif)" Then
            displayKeteranganTidakNormal = SetKeterangan(ValueKesimpulan(ComboBoxFisikRectalToucher.Text & TextBoxFisikRectalToucher.Text), "Tidak Normal", displayKeteranganTidakNormal, "Rectal Toucher")
            displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)

            ' Set Status Rectal Toucher
            varStatusRectalToucher = True
        End If

        'Set Integumen
        If cmbintegumen.Text <> "Dalam Batas Normal" Then
            displayKeteranganTidakNormal = SetKeterangan(ValueKesimpulan(cmbintegumen.Text & txintegumen.Text), "Tidak Normal", displayKeteranganTidakNormal, "Integumen")
            displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
        End If

        'Set Ekstemitas
        If cmbekstemitas.Text <> "Dalam Batas Normal" Then
            displayKeteranganTidakNormal = SetKeterangan(ValueKesimpulan(cmbekstemitas.Text & txekstemitas.Text), "Tidak Normal", displayKeteranganTidakNormal, "Ekstemitas")
            displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
        End If

        'Set Turgor
        If cmbturgor.Text <> "Normal" Then
            displayKeteranganTidakNormal = SetKeterangan(cmbturgor.Text, "Tidak Normal", displayKeteranganTidakNormal, "Turgor")
            displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
        End If

        'Set Telinga
        If cmbtelinga.Text <> "Dalam Batas Normal" Then
            displayKeteranganTidakNormal = SetKeterangan(ValueKesimpulan(cmbtelinga.Text & txtelinga.Text), "Tidak Normal", displayKeteranganTidakNormal, "Telinga")
            displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
        End If

        'Set Hidung
        If cmbhidung.Text <> "Dalam Batas Normal" Then
            displayKeteranganTidakNormal = SetKeterangan(ValueKesimpulan(cmbhidung.Text & txhidung.Text), "Tidak Normal", displayKeteranganTidakNormal, "Hidung")
            displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
        End If

        If cmbvisusmata.Text = "Visus dgn kacamata" Then
            'Set Visus kacamata
            Dim ketvisuskacamata As String = ""
            Dim ketvisustanpakacamata As String = ""
            If txvisustanpakacamata.Text = "6/6" And txvisustanpakacamata2.Text = "6/6" Then
                ketvisustanpakacamata = "Normal"
            ElseIf txvisustanpakacamata.Text <> "6/6" And txvisustanpakacamata2.Text = "6/6" Then
                ketvisustanpakacamata = "Myopia OD"
            ElseIf txvisustanpakacamata.Text = "6/6" And txvisustanpakacamata2.Text <> "6/6" Then
                ketvisustanpakacamata = "Myopia OS"
            ElseIf txvisustanpakacamata.Text <> "6/6" And txvisustanpakacamata2.Text <> "6/6" Then
                ketvisustanpakacamata = "Myopia ODS"
            End If

            If txvisuskacamata.Text = "6/6" And txvisuskacamata2.Text <> "6/6" Then
                ketvisuskacamata = "Myopia OS"
            ElseIf txvisuskacamata.Text <> "6/6" And txvisuskacamata2.Text = "6/6" Then
                ketvisuskacamata = "Myopia OD"
            ElseIf txvisuskacamata.Text = "6/6" And txvisuskacamata2.Text = "6/6" Then
                ketvisuskacamata = ketvisustanpakacamata & " terkoreksi"
            ElseIf txvisuskacamata.Text <> "6/6" Or txvisuskacamata2.Text <> "6/6" Then
                ketvisuskacamata = ketvisustanpakacamata
            End If

            If txvisuskacamata.Text = "" And txvisuskacamata2.Text = "" Then
                If ketvisustanpakacamata <> "Normal" Then
                    displayKeteranganTidakNormal = SetKeterangan(ketvisustanpakacamata, "Tidak Normal", displayKeteranganTidakNormal, "Visus Mata")
                    displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
                    txkoreksiakhir.Text = ketvisustanpakacamata
                Else
                    txkoreksiakhir.Text = "Normal"
                End If
            Else
                If ketvisuskacamata = "Normal" Or ketvisuskacamata.Contains("terkoreksi") = True Then
                    txkoreksiakhir.Text = ketvisuskacamata
                Else
                    displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
                    displayKeteranganTidakNormal = SetKeterangan(ketvisuskacamata, "Tidak Normal", displayKeteranganTidakNormal, "Koreksi Akhir Mata")
                    txkoreksiakhir.Text = ketvisuskacamata
                End If
            End If
        ElseIf cmbvisusmata.Text = "Visus Mata" Then
            'Set Visus Mata (Autorefraksi)

        End If

        'Set Kebiasaan
        If cmbrokok.Text <> "" And cmbrokok.Text <> "Tidak" Then displaySaranTidakNormal = SetSaran("Berhenti merokok.", "Tidak Normal", displaySaranTidakNormal)
        If cmbalkohol.Text <> "" And cmbalkohol.Text <> "Tidak" Then displaySaranTidakNormal = SetSaran("Berhenti minum alkohol.", "Tidak Normal", displaySaranTidakNormal)
        If cmbkopi.Text <> "" And cmbkopi.Text = "Ya, Banyak" Then displaySaranTidakNormal = SetSaran("Kurangi konsumsi kopi.", "Tidak Normal", displaySaranTidakNormal)
        If cmbpolamakan.Text <> "" And cmbpolamakan.Text <> "Teratur" Then displaySaranTidakNormal = SetSaran("Jaga pola makan yang teratur.", "Tidak Normal", displaySaranTidakNormal)
        If cmbistirahat.Text <> "" And cmbistirahat.Text <> "Teratur" Then displaySaranTidakNormal = SetSaran("Istirahat yang cukup.", "Tidak Normal", displaySaranTidakNormal)
        If cmbolahraga.Text <> "" And cmbolahraga.Text <> "Teratur" Then displaySaranTidakNormal = SetSaran("Olahraga yang teratur.", "Tidak Normal", displaySaranTidakNormal)

        'Set Riwayat
        If cmbhepatitis.Text <> "" And cmbhepatitis.Text <> "Tidak" Then displayRiwayat = SetRiwayat("Hepatitis", displayRiwayat) : displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
        If cmbhernia.Text <> "" And cmbhernia.Text <> "Tidak" Then displayRiwayat = SetRiwayat("Hernia", displayRiwayat) : displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
        If cmbsakitjantung.Text <> "" And cmbsakitjantung.Text <> "Tidak" Then displayRiwayat = SetRiwayat("Sakit Jantung", displayRiwayat) : displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
        If cmbhipertensi.Text <> "" And cmbhipertensi.Text <> "Tidak" Then displayRiwayat = SetRiwayat("Hipertensi", displayRiwayat) : displaySaranTidakNormal = SetSaran("Batasi konsumsi natrium / garam.", "Tidak Normal", displaySaranTidakNormal)
        If cmbepilepsi.Text <> "" And cmbepilepsi.Text <> "Tidak" Then displayRiwayat = SetRiwayat("Epilepsi", displayRiwayat) : displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
        If cmbdiabetes.Text <> "" And cmbdiabetes.Text <> "Tidak" Then displayRiwayat = SetRiwayat("Diabetes", displayRiwayat) : displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
        If cmbtbc.Text <> "" And cmbtbc.Text <> "Tidak" Then
            Dim Ttbc As Date = DateSerial(dttbc.Value.Year, dttbc.Value.Month, dttbc.Value.Day).AddMonths(6)
            If Ttbc > Date.Now Then
                varStatusTBC = True
            End If
            displayRiwayat = SetRiwayat("TBC", displayRiwayat)
            displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
        End If

        'Update Saran & Ketrangan
        If displayKeteranganNormal <> "" Or displayKeteranganTidakNormal <> "" Or displaySaranTidakNormal <> "" Or displaySaranNormal <> "" Then
            'Set Keterangan
            If displayKeteranganNormal <> "" Or displayKeteranganTidakNormal <> "" Then
                If displayKeteranganTidakNormal <> "" Then
                    If totalKetTidakNormal > 1 Then
                        varKet = spasi + displayKeteranganTidakNormal
                    Else
                        varKet = displayKeteranganTidakNormal
                    End If
                End If
            Else
                varKet = ""
            End If

            'Set Saran
            If displaySaranTidakNormal <> "" Or displaySaranNormal <> "" Then
                If displaySaranTidakNormal <> "" Then
                    If totalSaranTidakNormal > 1 Then
                        txsaranfisik.Text = spasi + displaySaranTidakNormal
                    Else
                        txsaranfisik.Text = displaySaranTidakNormal
                    End If
                End If
            Else
                txsaranfisik.ResetText()
            End If
        Else
            varKet = ""
            txsaranfisik.ResetText()
        End If

        'Set Status Fit / Unfit
        If varStatusRectalToucher = True Then
            varStatusKesehatan = "UNFIT"
        ElseIf totalKetTidakNormal = 0 And totalRiwayat = 0 Then
            varStatusKesehatan = "FIT"
        ElseIf totalKetTidakNormal > 0 And varStatusTBC = False Then
            varStatusKesehatan = "FIT DENGAN CATATAN"
        ElseIf totalKetTidakNormal > 0 And varStatusTBC = True Then
            varStatusKesehatan = "UNFIT SEMENTARA"
        ElseIf totalKetTidakNormal = 0 And varStatusTBC = False Then
            varStatusKesehatan = "FIT"
        ElseIf totalKetTidakNormal = 0 And varStatusTBC = True Then
            varStatusKesehatan = "UNFIT SEMENTARA"
        End If

        If totalKetTidakNormal = 0 And totalRiwayat = 0 Then
            txsimpul.Text = varStatusKesehatan
        ElseIf totalKetTidakNormal > 0 And totalRiwayat = 0 Then
            txsimpul.Text = varStatusKesehatan & vbCrLf & vbCrLf & varKet
        ElseIf totalKetTidakNormal > 0 Then
            txsimpul.Text = varStatusKesehatan & vbCrLf & vbCrLf & varKet & vbCrLf & "Memiliki riwayat : " & Strings.Left(displayRiwayat, displayRiwayat.Length - 2)
        ElseIf totalKetTidakNormal = 0 And totalRiwayat > 0 Then
            txsimpul.Text = varStatusKesehatan & vbCrLf & vbCrLf & varKet & vbCrLf & "Memiliki riwayat : " & Strings.Left(displayRiwayat, displayRiwayat.Length - 2)
        End If

        Dim Tempsaranfisik As String = txsaranfisik.Text
        If Tempsaranfisik.Contains(vbCrLf & spasi & "Konsultasi ke dokter.") = True Then
            Tempsaranfisik = Tempsaranfisik.Replace(vbCrLf & spasi & "Konsultasi ke dokter.", "")
            txsaranfisik.Text = Tempsaranfisik & spasi & "Konsultasi ke dokter."
        ElseIf Tempsaranfisik.Contains(spasi & "Konsultasi ke dokter.") = True Then
            Tempsaranfisik = Tempsaranfisik.Replace(spasi & "Konsultasi ke dokter.", "")
            txsaranfisik.Text = Tempsaranfisik & spasi & "Konsultasi ke dokter."
        End If

        TextBoxStatusFit.Text = varStatusKesehatan
    End Sub

    Function ValueKesimpulan(ByVal VarKesimpulan As String) As String
        Dim NewValue As String = Strings.Replace(Strings.Replace(Strings.Replace(VarKesimpulan, ".", ""), "~", ""), "Lainnya", "")

        Return NewValue
    End Function

    Private Sub SetNilaiKosongFisik()
        If TextBoxBeratBadan.Text.Trim = "" Then TextBoxBeratBadan.Text = 0
        If TextBoxTinggiBadan.Text.Trim = "" Then TextBoxTinggiBadan.Text = 0
        If TextBoxDetakNadi.Text.Trim = "" Then TextBoxDetakNadi.Text = 0
        If TextBoxSistole.Text.Trim = "" Then TextBoxSistole.Text = 0
        If TextBoxDiastole.Text.Trim = "" Then TextBoxDiastole.Text = 0
        If TextBoxSuhu.Text.Trim = "" Then TextBoxSuhu.Text = 0
        If TextBoxNafas.Text.Trim = "" Then TextBoxNafas.Text = 0
    End Sub

    Function SetKeterangan(ByVal VarKet As String, ByVal StatusKet As String, ByVal displayKeterangan As String, ByVal Tindakan As String) As String
        Dim displayKeteranganTidakNormal As String = displayKeterangan
        Dim displayKeteranganNormal As String = displayKeterangan
        Dim Keterangan As String = ""
        Dim spasi As String = "  - "

        If StatusKet = "Tidak Normal" Then
            totalKetTidakNormal = totalKetTidakNormal + 1
            If totalKetTidakNormal > 1 Then
                Keterangan = displayKeteranganTidakNormal + spasi + Tindakan + " : " + VarKet + vbCrLf
            Else
                Keterangan = displayKeteranganTidakNormal + Tindakan + " : " + VarKet + vbCrLf
            End If
        ElseIf StatusKet = "Normal" Then
            totalKetNormal = totalKetNormal + 1
            If totalKetNormal > 1 Then
                Keterangan = displayKeteranganNormal + spasi + Tindakan + " : " + VarKet + vbCrLf
            Else
                Keterangan = displayKeteranganNormal + Tindakan + " : " + VarKet + vbCrLf
            End If
        End If

        Return Keterangan
    End Function

    Function SetSaran(ByVal VarSaran As String, ByVal StatusSaran As String, ByVal displaySaran As String) As String
        Dim displaySaranTidakNormal As String = displaySaran
        Dim displaySaranNormal As String = displaySaran
        Dim Saran As String = displaySaran
        Dim spasi As String = "  - "

        If StatusSaran = "Tidak Normal" Then
            If Saran.Contains("" & VarSaran & "") = False Then
                totalSaranTidakNormal = totalSaranTidakNormal + 1
                If totalSaranTidakNormal > 1 Then
                    Saran = displaySaranTidakNormal + spasi + VarSaran + vbCrLf
                Else
                    Saran = displaySaranTidakNormal + VarSaran + vbCrLf
                End If
            End If
        End If

        Return Saran
    End Function

    Function SetRiwayat(ByVal VarRiwayat As String, ByVal displayRiwayat As String) As String
        Dim Riwayat As String = ""
        Dim spasi As String = "  - "

        If displayRiwayat.Contains("" & VarRiwayat & "") = False Then
            totalRiwayat = totalRiwayat + 1
            Riwayat = displayRiwayat + VarRiwayat + ", "
        End If

        Return Riwayat
    End Function

    Private Sub txvisuskacamata_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txvisuskacamata.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = "/") Then e.Handled = True
    End Sub

    Private Sub txvisuskacamata2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txvisuskacamata2.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = "/") Then e.Handled = True
    End Sub

    Private Sub txvisustanpakacamata_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txvisustanpakacamata.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = "/") Then e.Handled = True
    End Sub

    Private Sub txvisustanpakacamata2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txvisustanpakacamata2.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = "/") Then e.Handled = True
    End Sub

    Private Sub cmboperasi_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmboperasi.SelectedIndexChanged
        If cmboperasi.Text = "Tidak" Or cmboperasi.Text = "" Then
            lblkapanoperasi.Visible = False
            lbldimanaoperasi.Visible = False
            lblkenapaoperasi.Visible = False
            dtkapanoperasi.Visible = False
            txkenapaoperasi.Visible = False
            txdimanaoperasi.Visible = False
        ElseIf cmboperasi.Text = "Ya" Then
            lblkapanoperasi.Visible = True
            lbldimanaoperasi.Visible = True
            lblkenapaoperasi.Visible = True
            dtkapanoperasi.Visible = True
            txkenapaoperasi.Visible = True
            txdimanaoperasi.Visible = True
        End If
    End Sub

    Private Sub cmbrs_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbrs.SelectedIndexChanged
        If cmbrs.Text = "Tidak" Or cmbrs.Text = "" Then
            lbldimanars.Visible = False
            lblkapanrs.Visible = False
            lblkenapars.Visible = False
            dtkapanrs.Visible = False
            txkenapars.Visible = False
            txdimanars.Visible = False
        ElseIf cmbrs.Text = "Ya" Then
            lbldimanars.Visible = True
            lblkapanrs.Visible = True
            lblkenapars.Visible = True
            dtkapanrs.Visible = True
            txkenapars.Visible = True
            txdimanars.Visible = True
        End If
    End Sub

    Private Sub cmbobat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbobat.SelectedIndexChanged
        If cmbobat.Text = "Tidak" Or cmbobat.Text = "" Then
            lblpenyakitobat.Visible = False
            txpenyakitobat.Visible = False
        ElseIf cmbobat.Text = "Ya" Then
            lblpenyakitobat.Visible = True
            txpenyakitobat.Visible = True
        End If
    End Sub

    Private Sub cmbnarkoba_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbnarkoba.SelectedIndexChanged
        If cmbnarkoba.Text = "Tidak" Or cmbnarkoba.Text = "" Then
            lblkapannarkoba.Visible = False
            lbljenisnarkoba.Visible = False
            txjenisnarkoba.Visible = False
            dtkapannarkoba.Visible = False
        ElseIf cmbnarkoba.Text = "Ya" Then
            lblkapannarkoba.Visible = True
            lbljenisnarkoba.Visible = True
            txjenisnarkoba.Visible = True
            dtkapannarkoba.Visible = True
        End If
    End Sub

    Private Sub cmbhepatitis_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbhepatitis.SelectedIndexChanged
        If cmbhepatitis.Text = "Tidak" Or cmbhepatitis.Text = "" Then
            dthepatitis.Visible = False
        ElseIf cmbhepatitis.Text = "Ya" Then
            dthepatitis.Visible = True
        End If
    End Sub

    Private Sub cmbtbc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtbc.SelectedIndexChanged
        If cmbtbc.Text = "Tidak" Or cmbtbc.Text = "" Then
            dttbc.Visible = False
        ElseIf cmbtbc.Text = "Ya" Then
            dttbc.Visible = True
        End If
    End Sub

    Private Sub cmbhernia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbhernia.SelectedIndexChanged
        If cmbhernia.Text = "Tidak" Or cmbhernia.Text = "" Then
            dthernia.Visible = False
        ElseIf cmbhernia.Text = "Ya" Then
            dthernia.Visible = True
        End If
    End Sub

    Private Sub cmbsakitjantung_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbsakitjantung.SelectedIndexChanged
        If cmbsakitjantung.Text = "Tidak" Or cmbsakitjantung.Text = "" Then
            dtjantung.Visible = False
        ElseIf cmbsakitjantung.Text = "Ya" Then
            dtjantung.Visible = True
        End If
    End Sub

    Private Sub cmbhipertensi_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbhipertensi.SelectedIndexChanged
        If cmbhipertensi.Text = "Tidak" Or cmbhipertensi.Text = "" Then
            dthipertensi.Visible = False
        ElseIf cmbhipertensi.Text = "Ya" Then
            dthipertensi.Visible = True
        End If
    End Sub

    Private Sub cmbepilepsi_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbepilepsi.SelectedIndexChanged
        If cmbepilepsi.Text = "Tidak" Or cmbepilepsi.Text = "" Then
            dtepilepsi.Visible = False
        ElseIf cmbepilepsi.Text = "Ya" Then
            dtepilepsi.Visible = True
        End If
    End Sub

    Private Sub cmbdiabetes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbdiabetes.SelectedIndexChanged
        If cmbdiabetes.Text = "Tidak" Or cmbdiabetes.Text = "" Then
            dtdiabetes.Visible = False
        ElseIf cmbdiabetes.Text = "Ya" Then
            dtdiabetes.Visible = True
        End If
    End Sub

    Private Sub butnilaikonversi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butnilaikonversi.Click
        Try
            Dim Tbls As DataTable = gridlab.DataSource
            Tbls.AcceptChanges()

            Dim varJenisResult As String = ""
            Dim varKonversiSatuanMindray As Double = 0
            Dim varKonversiSatuanArcht As Double = 0
            Dim varKonversiSatuanNtAb As Double = 0
            Dim varNilaiCreatinin As Double = 0
            Dim varNilaiCreatininEGFR As Double = 0

            For Each Trownew As DataRow In Tbls.Rows
                varJenisResult = Trownew("Result")

                '========== MANUAL CODE =========='

                'SARS-COV-2 S-RBD IgG (Mindray)
                If Trownew("GroupID").ToString.Trim = "SARS-COV-2 S-RBD IgG" And varJenisResult <> "" And Trownew("NoUrut") = "1" Then
                    varKonversiSatuanMindray = varJenisResult / 0.8229
                ElseIf Trownew("GroupID").ToString.Trim = "SARS-COV-2 S-RBD IgG" And varKonversiSatuanMindray >= 0 And Trownew("NoUrut") = "2" Then
                    Trownew("Result") = Math.Round(varKonversiSatuanMindray, 2)
                End If

                'SARS-CoV-2 S-RBD IgG (ARCHT)
                If Trownew("GroupID").ToString.Trim = "SARS-CoV-2 S-RBD IgG (ARCHT)" And varJenisResult <> "" And Trownew("NoUrut") = "1" Then
                    varKonversiSatuanArcht = varJenisResult * 0.142
                ElseIf Trownew("GroupID").ToString.Trim = "SARS-CoV-2 S-RBD IgG (ARCHT)" And varKonversiSatuanArcht >= 0 And Trownew("NoUrut") = "2" Then
                    Trownew("Result") = Math.Round(varKonversiSatuanArcht, 2)
                End If

                'SARS-CoV-2 Neutralizing Antibody (NtAb)
                If Trownew("GroupID").ToString.Trim = "SARS-CoV-2 Neutralizing Antibody (NtAb)" And varJenisResult <> "" And Trownew("NoUrut") = "1" Then
                    varKonversiSatuanNtAb = varJenisResult * 0.3025
                ElseIf Trownew("GroupID").ToString.Trim = "SARS-CoV-2 Neutralizing Antibody (NtAb)" And varKonversiSatuanNtAb >= 0 And Trownew("NoUrut") = "2" Then
                    Trownew("Result") = Math.Round(varKonversiSatuanNtAb, 2)
                End If

                'Creatinin (e-GFR)
                If (Trownew("GroupID").ToString.Trim = "Creatinin" Or Trownew("GroupID").ToString.Trim = "Creatinin PAP") And varJenisResult <> "" And Trownew("NoUrut") = "1" Then
                    varNilaiCreatinin = varJenisResult
                ElseIf (Trownew("GroupID").ToString.Trim = "Creatinin" Or Trownew("GroupID").ToString.Trim = "Creatinin PAP") And varNilaiCreatinin >= 0 And Trownew("NoUrut") = "2" Then
                    If TextBoxJenisKelamin.Text = "P" Then
                        varNilaiCreatininEGFR = 175 * (varNilaiCreatinin) ^ -1.154 * (GetCurrentAge(DateTimeTanggalLahir.Value)) ^ -0.203 * 0.742
                    ElseIf TextBoxJenisKelamin.Text = "L" Then
                        varNilaiCreatininEGFR = 175 * (varNilaiCreatinin) ^ -1.154 * (GetCurrentAge(DateTimeTanggalLahir.Value)) ^ -0.203
                    End If

                    Trownew("Result") = Math.Round(varNilaiCreatininEGFR, 1)
                End If

                '======== END MANUAL CODE ========'
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class