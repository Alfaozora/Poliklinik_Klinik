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

Public Class LabAdminOnline
    Private DB_Poliklinik As TLcon
    Private DB_Sysmex As TLcon
    Private Find_Poliklinik As Find.TLconnect

    Dim thread As System.Threading.Thread
    Private NoWhatsappCompany As String = ""
    Private NoWhatsappMarketing As String = ""
    Private NoWhatsappCustomer As String = ""
    Private EmailCompany As String = ""
    Private EmailCustomer As String = ""
    Private SendHasilDL As Boolean = False
    Private SendHasilThorax As Boolean = False
    Private UserLabAdminOnline As String = PoliKlinik.Lbluser.Text
    Private AutoTTD As String = ""

    Private totalKetTidakNormal As Integer = 0
    Private totalKetNormal As Integer = 0
    Private totalSaranTidakNormal As Integer = 0
    Private totalSaranNormal As Integer = 0
    Private totalRiwayat As Integer = 0

    ' Set Default
    Private DrPelaksanaKlinik As String = ReadSQLNIK("select StrValue from MsConfig where ConfigName='DokterPK'")

    ' Set Lokal Variabel
    Private kodeLokasi As String = ""
    Private idTransaksi As String = ""

    Private Sub SetClearHeader()
        QR_Code_Trans.Image = Nothing
        butfindtindakanid.Enabled = True

        ' Default Variabel
        kodeLokasi = ""
        idTransaksi = ""

        'Date & Keterangan
        setdatefisik()
        TextBoxDiagnosaRiwayatOperasi.ResetText()
        TextBoxDiagnosaRiwayatRumahSakit.ResetText()
        TextBoxTempatRiwayatOperasi.ResetText()
        TextBoxTempatRiwayatRumahSakit.ResetText()
        TextBoxJenisRiwayatPenggunaNarkoba.ResetText()
        TextBoxDiagnosaRiwayatPengobatanPenyakit.ResetText()
        TextBoxPenyakitRiwayatPenyakitKeluarga.ResetText()
        txstatusfit.ResetText()

        txalamat.ResetText()
        txcaraambil.ResetText()
        txpenagihan.ResetText()
        txcodepenagihan.ResetText()
        TextBoxNoTransaksi.ResetText()
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

        dtchanged.Value = DateAndTime.Now
        txchanged.Text = UserLabAdminOnline
        txketall.ResetText()
        txsaranall.ResetText()
        ComboBoxVisusMata1.SelectedIndex = 0
        ComboBoxVisusMata2.SelectedIndex = 0

        DownloadHasilToolStripMenuItem.Enabled = False
        ResendToMesinToolStripMenuItem.Enabled = False
        PrintSementaraToolStripMenuItem.Enabled = False
        PreviewHasilLabToolStripMenuItem.Enabled = False

        CetakBarcodeToolStripMenuItem.Enabled = False
        cmbrangedate.SelectedIndex = 0

        SendingWhatsappEmailToolStripMenuItem.Enabled = False
        'CetakLabelToolStripMenuItem.Enabled = False
        idTransaksi = ""

        InsertNewItemComboSQL("select StrValue from MsConfig where ConfigName like '%fisik%'", ComboBoxDokterFisik)
        InsertNewItemComboSQL("select StrValue from MsConfig where ConfigName like '%thorax%'", drthorax)
        drthorax.ResetText()
        InsertNewItemComboSQL("select StrValue from MsConfig where ConfigName like '%ecg%'", cmbecg)
        cmbecg.ResetText()
        InsertNewItemComboSQL("select StrValue from MsConfig where ConfigName like '%audio%'", draudio)
        draudio.ResetText()
        InsertNewItemComboSQL("select StrValue from MsConfig where ConfigName like '%usg%'", drusg)
        drusg.ResetText()
        InsertNewItemComboSQL("select StrValue from MsConfig where ConfigName like '%treadmill%'", drtreadmill)
        drtreadmill.ResetText()
        InsertNewItemComboSQL("select StrValue from MsConfig where ConfigName like '%spiro%'", drspiro)
        drspiro.ResetText()
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
        PanelDetailPemeriksaanFisik.Enabled = False
        ButtonSimpanFisik.Enabled = False
        ButtonCetakFisik.Enabled = False
        ButtonPreviewFisik.Enabled = False
        ClearFisikDetail()
    End Sub

    Private Sub DisableECG()
        txhasilecg.Enabled = False
        txecgtekanan.Enabled = False
        ButtonSaveECG.Enabled = False
        ButtonPrintECG.Enabled = False
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

    Private Sub ClearFisikDetail()
        ' Pemeriksaan Vital & Antropometri
        TextBoxRiwayatPenyakit.ResetText()
        TextBoxTinggiBadan.ResetText()
        TextBoxBeratBadan.ResetText()
        TextBoxIndeksMedik.ResetText()
        TextBoxSuhu.ResetText()
        TextBoxDetakNadi.ResetText()
        TextBoxSistole.ResetText()
        TextBoxDiastole.ResetText()
        TextBoxNafas.ResetText()

        ' Pemeriksaan Head-to-toe (kepala ke kaki)
        cmbkesadaran.ResetText()
        cmbkepala.ResetText()
        txkepala.ResetText()
        cmbrambut.ResetText()
        txrambut.ResetText()
        cmbmuka.ResetText()
        txmuka.ResetText()
        cmbmata.ResetText()
        txmata.ResetText()
        cmbbutawarna.ResetText()
        txbutwarna.ResetText()
        TextBoxVisusKacamataOD.ResetText()
        TextBoxVisusKacamataOS.ResetText()
        TextBoxVisusTanpaKacamataOD.ResetText()
        TextBoxVisusTanpaKacamataOS.ResetText()
        txkoreksiakhir.ResetText()
        cmbtelinga.ResetText()
        txtelinga.ResetText()
        cmbhidung.ResetText()
        txhidung.ResetText()
        cmbmulut.ResetText()
        txmulut.ResetText()
        cmbgigi.ResetText()
        txgigi.ResetText()
        cmblidah.ResetText()
        txlidah.ResetText()
        cmbtenggorokan.ResetText()
        txtenggorokan.ResetText()
        cmbleher.ResetText()
        txleher.ResetText()
        cmbdada.ResetText()
        txdada.ResetText()
        ComboBoxFisikPerut.ResetText()
        TextBoxFisikPerut.ResetText()
        ComboBoxFisikRectalToucher.ResetText()
        TextBoxFisikRectalToucher.ResetText()
        cmbintegumen.ResetText()
        txintegumen.ResetText()
        cmbekstemitas.ResetText()
        txekstemitas.ResetText()
        cmbturgor.ResetText()

        ' Riwayat Kebiasaan
        cmbrokok.ResetText()
        cmbalkohol.ResetText()
        cmbkopi.ResetText()
        cmbpolamakan.ResetText()
        cmbistirahat.ResetText()
        cmbolahraga.ResetText()

        ' Riwayat Penyakit (Kolom 1)
        ComboBoxHepatitis.ResetText()
        ComboBoxTHT.ResetText()
        ComboBoxTBC.ResetText()
        ComboBoxAnorexia.ResetText()
        ComboBoxMalaria.ResetText()
        ComboBoxGangguanKulit.ResetText()
        ComboBoxTypoidFever.ResetText()
        ComboBoxTurunBB.ResetText()
        ComboBoxHernia.ResetText()
        ComboBoxSakitJantung.ResetText()
        ComboBoxAmbeien.ResetText()
        ComboBoxHipertensi.ResetText()
        ComboBoxKencingBatu.ResetText()
        ComboBoxVertigo.ResetText()
        ComboBoxEpilepsi.ResetText()
        ComboBoxPingsan.ResetText()
        ComboBoxGastritis.ResetText()
        ComboBoxPusing.ResetText()
        ComboBoxDiabetesMellitus.ResetText()
        ComboBoxParuNonTBC.ResetText()

        ' Riwayat Penyakit (Kolom 2)

        ' Riwayat Kesehatan
        ComboBoxRiwayatRumahSakit.ResetText()
        ComboBoxRiwayatPengobatanPenyakit.ResetText()
        ComboBoxRiwayatPenggunaNarkoba.ResetText()
        ComboBoxRiwayatKondisiSehat.ResetText()
        ComboBoxRiwayatOperasi.ResetText()
        ComboBoxRiwayatPenyakitKeluarga.ResetText()

        ' Kesimpulan & Saran
        txsimpul.ResetText()
        txsaranfisik.ResetText()

        ' ComboBox Dokterc 
        InsertNewItemComboSQL("SELECT StrValue FROM MsConfig WHERE ConfigName LIKE '%fisik%'", ComboBoxDokterFisik)
    End Sub

    Private Sub EnableUSG()
        txusg.Enabled = True
        butsaveusg.Enabled = True
        butprintusg.Enabled = True

        Dim Tbls As DataTable = ReadThemysql("SELECT a.usg from transaksilabhasillain a, transaksilab b WHERE a.nourut='" & TextBoxNoTransaksi.Text & "' AND a.nourut=b.nourut AND b.idtempatlab='" & kodeLokasi & "' and a.idlabinternet=b.idlabinternet", DB_Poliklinik)
        If Tbls.Rows.Count > 0 Then
            Dim Trow As DataRow = Tbls.Rows(0)
            If IsDBNull(Trow("usg")) = False Then txusg.Text = Trow("usg")
        End If
    End Sub

    Private Sub EnableAudio()
        txaudiometri.Enabled = True
        butsaveaudio.Enabled = True
        butprintaudio.Enabled = True

        Dim Tbls As DataTable = ReadThemysql("SELECT a.Audio, a.AudioDate, a.AudioBy from transaksilabhasillain a, transaksilab b WHERE a.nourut='" & TextBoxNoTransaksi.Text & "' AND a.nourut=b.nourut AND b.idtempatlab='" & kodeLokasi & "' and a.idlabinternet=b.idlabinternet", DB_Poliklinik)
        If Tbls.Rows.Count > 0 Then
            Dim Trow As DataRow = Tbls.Rows(0)
            If IsDBNull(Trow("Audio")) = False Then txaudiometri.Text = Trow("Audio")
            If IsDBNull(Trow("AudioDate")) = False Then dtaudio.Value = Trow("AudioDate")
            If IsDBNull(Trow("AudioBy")) = False Then txaudioby.Text = Trow("AudioBy")
        End If
    End Sub

    Private Sub EnableFisikNew2()
        PanelDetailPemeriksaanFisik.Enabled = True
        ButtonSimpanFisik.Enabled = True
        ButtonCetakFisik.Enabled = True
        ButtonPreviewFisik.Enabled = True
        ClearFisikDetail()
        setdatefisik()
        LoadFisikDetail()
    End Sub

    Private Sub InputCheck(ByVal Tcmb As System.Windows.Forms.ComboBox, ByVal Ttx As System.Windows.Forms.TextBox)
        Dim Thasil As String = ReadThemysqlNIK("select Result from transaksilabfisik where FisikNoUrut='" & Tcmb.Tag.ToString.Trim & "' and NoUrut='" & TextBoxNoTransaksi.Text & "' and idlabinternet='" & idTransaksi & "'", DB_Poliklinik)
        Dim T1 As String = ""
        Dim T2 As String = ""

        If Thasil.Contains("~") = True Then
            Dim Tsplit() As String = Thasil.ToString.Split("~")
            T1 = Tsplit(0)
            T2 = Tsplit(1)
        Else
            T1 = Thasil
        End If

        If T2 = "" Then
            Tcmb.Text = T1
        Else
            Tcmb.Text = T1
            Ttx.Text = T2
        End If
    End Sub

    Private Sub LoadFisikDetail()
        Dim Tbls As DataTable = ReadThemysql("SELECT a.fisiknourut, a.result, a.dimana, a.kenapa, a.jenis, date(a.kapan) AS 'kapan', a.StatusSembuh from transaksilabfisik a, transaksilab b WHERE a.nourut='" & TextBoxNoTransaksi.Text & "' AND a.nourut=b.nourut AND b.idtempatlab='" & kodeLokasi & "' AND a.idlabinternet=b.idlabinternet", DB_Poliklinik)
        For Each Trow As DataRow In Tbls.Rows
            ' Pemeriksaan Vital & Antropometri
            If Trow("fisiknourut") = TextBoxRiwayatPenyakit.Tag.ToString Then TextBoxRiwayatPenyakit.Text = Trow("result") : GoTo GoBackthis
            If Trow("fisiknourut") = TextBoxTinggiBadan.Tag.ToString Then TextBoxTinggiBadan.Text = Trow("result") : GoTo GoBackthis
            If Trow("fisiknourut") = TextBoxBeratBadan.Tag.ToString Then TextBoxBeratBadan.Text = Trow("result") : GoTo GoBackthis
            If Trow("fisiknourut") = TextBoxSuhu.Tag.ToString Then TextBoxSuhu.Text = Trow("result") : GoTo GoBackthis
            If Trow("fisiknourut") = TextBoxDetakNadi.Tag.ToString Then TextBoxDetakNadi.Text = Trow("result") : GoTo GoBackthis
            If Trow("fisiknourut") = TextBoxNafas.Tag.ToString Then TextBoxNafas.Text = Trow("result") : GoTo GoBackthis
            If Trow("fisiknourut") = TextBoxSistole.Tag.ToString Then
                Dim TsplitTekanan() As String = Trow("result").ToString.Split("/")
                TextBoxSistole.Text = TsplitTekanan(0).ToString.Trim
                TextBoxDiastole.Text = TsplitTekanan(1).ToString.Trim
                GoTo GoBackthis
            End If

            ' Pemeriksaan Head-to-toe (kepala ke kaki)
            If Trow("fisiknourut") = cmbkesadaran.Tag.ToString Then GetResult(cmbkesadaran, Trow("result")) : GoTo GoBackthis
            If Trow("fisiknourut") = txkoreksiakhir.Tag.ToString Then txkoreksiakhir.Text = Trow("result")
            If Trow("fisiknourut") = cmbturgor.Tag.ToString Then GetResult(cmbturgor, Trow("result")) : GoTo GoBackthis
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

            ' Visus Mata & Koreksi Akhir

            ' Riwayat Kebiasaan
            If Trow("fisiknourut") = cmbrokok.Tag.ToString Then GetResult(cmbrokok, Trow("result")) : GoTo GoBackthis
            If Trow("fisiknourut") = cmbalkohol.Tag.ToString Then GetResult(cmbalkohol, Trow("result")) : GoTo GoBackthis
            If Trow("fisiknourut") = cmbkopi.Tag.ToString Then GetResult(cmbkopi, Trow("result")) : GoTo GoBackthis
            If Trow("fisiknourut") = cmbpolamakan.Tag.ToString Then GetResult(cmbpolamakan, Trow("result")) : GoTo GoBackthis
            If Trow("fisiknourut") = cmbistirahat.Tag.ToString Then GetResult(cmbistirahat, Trow("result")) : GoTo GoBackthis
            If Trow("fisiknourut") = cmbolahraga.Tag.ToString Then GetResult(cmbolahraga, Trow("result")) : GoTo GoBackthis

            ' Dokter Fisik
            If Trow("fisiknourut") = ComboBoxDokterFisik.Tag.ToString Then ComboBoxDokterFisik.Text = Trow("result") : GoTo GoBackthis

            ' Riwayat Kesehatan
            If Trow("fisiknourut") = ComboBoxRiwayatOperasi.Tag.ToString Then
                GetResult(ComboBoxRiwayatOperasi, Trow("result"))
                If Trow("result").ToString.Trim = "Ya" Then
                    DateTimeRiwayatOperasi.Value = Trow("Kapan")
                    TextBoxTempatRiwayatOperasi.Text = Trow("Dimana")
                    TextBoxDiagnosaRiwayatOperasi.Text = Trow("Kenapa")
                End If
                GoTo GoBackthis
            End If

            If Trow("fisiknourut") = ComboBoxRiwayatRumahSakit.Tag.ToString Then
                GetResult(ComboBoxRiwayatRumahSakit, Trow("result"))
                If Trow("result").ToString.Trim = "Ya" Then
                    DateTimeRiwayatRumahSakit.Value = Trow("Kapan")
                    TextBoxTempatRiwayatRumahSakit.Text = Trow("Dimana")
                    TextBoxDiagnosaRiwayatRumahSakit.Text = Trow("Kenapa")
                End If
                GoTo GoBackthis
            End If

            If Trow("fisiknourut") = ComboBoxRiwayatKondisiSehat.Tag.ToString Then
                GetResult(ComboBoxRiwayatKondisiSehat, Trow("result"))
                If Trow("result").ToString.Trim = "Tidak" Then
                    TextBoxKeluhanRiwayatKondisiSehat.Text = Trow("Kenapa")
                End If
                GoTo GoBackthis
            End If

            If Trow("fisiknourut") = ComboBoxRiwayatPengobatanPenyakit.Tag.ToString Then
                GetResult(ComboBoxRiwayatPengobatanPenyakit, Trow("result"))
                If Trow("result").ToString.Trim = "Ya" Then
                    DateTimeRiwayatPengobatanPenyakit.Value = Trow("Kapan")
                    TextBoxTerapiRiwayatPengobatanPenyakit.Text = Trow("Jenis")
                    TextBoxDiagnosaRiwayatPengobatanPenyakit.Text = Trow("Kenapa")
                End If
                GoTo GoBackthis
            End If

            If Trow("fisiknourut") = ComboBoxRiwayatPenggunaNarkoba.Tag.ToString Then
                GetResult(ComboBoxRiwayatPenggunaNarkoba, Trow("result"))
                If Trow("result").ToString.Trim = "Ya" Then
                    DateTimeRiwayatPenggunaNarkoba.Value = Trow("Kapan")
                    TextBoxJenisRiwayatPenggunaNarkoba.Text = Trow("Jenis")
                End If
                GoTo GoBackthis
            End If

            ' Tambah Riwayat Keluarga
            If Trow("fisiknourut") = ComboBoxRiwayatPenyakitKeluarga.Tag.ToString Then
                GetResult(ComboBoxRiwayatPenyakitKeluarga, Trow("result"))
                If Trow("result").ToString.Trim = "Ya" Then
                    TextBoxPenyakitRiwayatPenyakitKeluarga.Text = Trow("kenapa")
                End If
                GoTo GoBackthis
            End If

            ' Kesimpulan & Saran
            If Trow("fisiknourut") = txsimpul.Tag.ToString Then txsimpul.Text = Trow("result") : GoTo GoBackthis
            If Trow("fisiknourut") = txsaranfisik.Tag.ToString Then txsaranfisik.Text = Trow("result") : GoTo GoBackthis

            ' Riwayat Penyakit (Kolom 1)
            If Trow("fisiknourut") = ComboBoxHepatitis.Tag.ToString Then
                GetResult(ComboBoxHepatitis, Trow("result"))
                If Trow("result").ToString.Trim = "Ya" Then
                    DateTimeHepatitis.Value = Trow("Kapan")
                    ComboBoxListHepatitis.Text = Trow("kenapa")
                    If Not IsDBNull(Trow("StatusSembuh")) Then CheckBoxSembuhHepatitis.Checked = Convert.ToBoolean(Trow("StatusSembuh"))
                End If
                GoTo GoBackthis
            End If

            If Trow("fisiknourut") = ComboBoxTBC.Tag.ToString Then
                GetResult(ComboBoxTBC, Trow("result"))
                If Trow("result").ToString.Trim = "Ya" Then
                    DateTimeTBC.Value = Trow("Kapan")
                    If Not IsDBNull(Trow("StatusSembuh")) Then CheckBoxSembuhTBC.Checked = Convert.ToBoolean(Trow("StatusSembuh"))
                End If
                GoTo GoBackthis
            End If

            If Trow("fisiknourut") = ComboBoxHernia.Tag.ToString Then
                GetResult(ComboBoxHernia, Trow("result"))
                If Trow("result").ToString.Trim = "Ya" Then
                    DateTimeHernia.Value = Trow("Kapan")
                    If Not IsDBNull(Trow("StatusSembuh")) Then CheckBoxSembuhHernia.Checked = Convert.ToBoolean(Trow("StatusSembuh"))
                End If
                GoTo GoBackthis
            End If

            If Trow("fisiknourut") = ComboBoxHipertensi.Tag.ToString Then
                GetResult(ComboBoxHipertensi, Trow("result"))
                If Trow("result").ToString.Trim = "Ya" Then
                    DateTimeHipertensi.Value = Trow("Kapan")
                    If Not IsDBNull(Trow("StatusSembuh")) Then CheckBoxSembuhHipertensi.Checked = Convert.ToBoolean(Trow("StatusSembuh"))
                End If
                GoTo GoBackthis
            End If

            If Trow("fisiknourut") = ComboBoxEpilepsi.Tag.ToString Then
                GetResult(ComboBoxEpilepsi, Trow("result"))
                If Trow("result").ToString.Trim = "Ya" Then
                    DateTimeEpilepsi.Value = Trow("Kapan")
                    If Not IsDBNull(Trow("StatusSembuh")) Then CheckBoxSembuhEpilepsi.Checked = Convert.ToBoolean(Trow("StatusSembuh"))
                End If
                GoTo GoBackthis
            End If

            If Trow("fisiknourut") = ComboBoxDiabetesMellitus.Tag.ToString Then
                GetResult(ComboBoxDiabetesMellitus, Trow("result"))
                If Trow("result").ToString.Trim = "Ya" Then
                    DateTimeDiabetesMellitus.Value = Trow("Kapan")
                    If Not IsDBNull(Trow("StatusSembuh")) Then CheckBoxSembuhDiabetesMellitus.Checked = Convert.ToBoolean(Trow("StatusSembuh"))
                End If
                GoTo GoBackthis
            End If

            If Trow("fisiknourut") = ComboBoxParuNonTBC.Tag.ToString Then
                GetResult(ComboBoxParuNonTBC, Trow("result"))
                If Trow("result").ToString.Trim = "Ya" Then
                    DateTimeParuNonTBC.Value = Trow("Kapan")
                    ComboBoxListParuNonTBC.Text = Trow("kenapa")
                    If Not IsDBNull(Trow("StatusSembuh")) Then CheckBoxSembuhParuNonTBC.Checked = Convert.ToBoolean(Trow("StatusSembuh"))
                End If
                GoTo GoBackthis
            End If

            If Trow("fisiknourut") = ComboBoxSakitJantung.Tag.ToString Then
                GetResult(ComboBoxSakitJantung, Trow("result"))
                If Trow("result").ToString.Trim = "Ya" Then
                    DateTimeSakitJantung.Value = Trow("Kapan")
                    ComboBoxListSakitJantung.Text = Trow("kenapa")
                    If Not IsDBNull(Trow("StatusSembuh")) Then CheckBoxSembuhSakitJantung.Checked = Convert.ToBoolean(Trow("StatusSembuh"))
                End If
                GoTo GoBackthis
            End If

            If Trow("fisiknourut") = ComboBoxMalaria.Tag.ToString Then
                GetResult(ComboBoxMalaria, Trow("result"))
                If Trow("result").ToString.Trim = "Ya" Then
                    DateTimeMalaria.Value = Trow("Kapan")
                    If Not IsDBNull(Trow("StatusSembuh")) Then CheckBoxSembuhMalaria.Checked = Convert.ToBoolean(Trow("StatusSembuh"))
                End If
                GoTo GoBackthis
            End If

            If Trow("fisiknourut") = ComboBoxGangguanKulit.Tag.ToString Then
                GetResult(ComboBoxGangguanKulit, Trow("result"))
                If Trow("result").ToString.Trim = "Ya" Then
                    DateTimeGangguanKulit.Value = Trow("Kapan")
                    If Not IsDBNull(Trow("StatusSembuh")) Then CheckBoxSembuhGangguanKulit.Checked = Convert.ToBoolean(Trow("StatusSembuh"))
                End If
                GoTo GoBackthis
            End If

            ' Riwayat Penyakit (Kolom 2)
            If Trow("fisiknourut") = ComboBoxAmbeien.Tag.ToString Then
                GetResult(ComboBoxAmbeien, Trow("result"))
                If Trow("result").ToString.Trim = "Ya" Then
                    DateTimeAmbeien.Value = Trow("Kapan")
                    If Not IsDBNull(Trow("StatusSembuh")) Then CheckBoxSembuhAmbeien.Checked = Convert.ToBoolean(Trow("StatusSembuh"))
                End If
                GoTo GoBackthis
            End If

            If Trow("fisiknourut") = ComboBoxTHT.Tag.ToString Then
                GetResult(ComboBoxTHT, Trow("result"))
                If Trow("result").ToString.Trim = "Ya" Then
                    DateTimeTHT.Value = Trow("Kapan")
                    If Not IsDBNull(Trow("StatusSembuh")) Then CheckBoxSembuhTHT.Checked = Convert.ToBoolean(Trow("StatusSembuh"))
                End If
                GoTo GoBackthis
            End If

            If Trow("fisiknourut") = ComboBoxKencingBatu.Tag.ToString Then
                GetResult(ComboBoxKencingBatu, Trow("result"))
                If Trow("result").ToString.Trim = "Ya" Then
                    DateTimeKencingBatu.Value = Trow("Kapan")
                    If Not IsDBNull(Trow("StatusSembuh")) Then CheckBoxSembuhKencingBatu.Checked = Convert.ToBoolean(Trow("StatusSembuh"))
                End If
                GoTo GoBackthis
            End If

            If Trow("fisiknourut") = ComboBoxVertigo.Tag.ToString Then
                GetResult(ComboBoxVertigo, Trow("result"))
                If Trow("result").ToString.Trim = "Ya" Then
                    DateTimeVertigo.Value = Trow("Kapan")
                    If Not IsDBNull(Trow("StatusSembuh")) Then CheckBoxSembuhVertigo.Checked = Convert.ToBoolean(Trow("StatusSembuh"))
                End If
                GoTo GoBackthis
            End If

            If Trow("fisiknourut") = ComboBoxAnorexia.Tag.ToString Then
                GetResult(ComboBoxAnorexia, Trow("result"))
                If Trow("result").ToString.Trim = "Ya" Then
                    DateTimeAnorexia.Value = Trow("Kapan")
                    If Not IsDBNull(Trow("StatusSembuh")) Then CheckBoxSembuhAnorexia.Checked = Convert.ToBoolean(Trow("StatusSembuh"))
                End If
                GoTo GoBackthis
            End If

            If Trow("fisiknourut") = ComboBoxPingsan.Tag.ToString Then
                GetResult(ComboBoxPingsan, Trow("result"))
                If Trow("result").ToString.Trim = "Ya" Then
                    DateTimePingsan.Value = Trow("Kapan")
                    If Not IsDBNull(Trow("StatusSembuh")) Then CheckBoxSembuhPingsan.Checked = Convert.ToBoolean(Trow("StatusSembuh"))
                End If
                GoTo GoBackthis
            End If

            If Trow("fisiknourut") = ComboBoxGastritis.Tag.ToString Then
                GetResult(ComboBoxGastritis, Trow("result"))
                If Trow("result").ToString.Trim = "Ya" Then
                    DateTimeGastritis.Value = Trow("Kapan")
                    If Not IsDBNull(Trow("StatusSembuh")) Then CheckBoxSembuhGastritis.Checked = Convert.ToBoolean(Trow("StatusSembuh"))
                End If
                GoTo GoBackthis
            End If

            If Trow("fisiknourut") = ComboBoxPusing.Tag.ToString Then
                GetResult(ComboBoxPusing, Trow("result"))
                If Trow("result").ToString.Trim = "Ya" Then
                    DateTimePusing.Value = Trow("Kapan")
                    If Not IsDBNull(Trow("StatusSembuh")) Then CheckBoxSembuhPusing.Checked = Convert.ToBoolean(Trow("StatusSembuh"))
                End If
                GoTo GoBackthis
            End If

            If Trow("fisiknourut") = ComboBoxTypoidFever.Tag.ToString Then
                GetResult(ComboBoxTypoidFever, Trow("result"))
                If Trow("result").ToString.Trim = "Ya" Then
                    DateTimeTypoidFever.Value = Trow("Kapan")
                    If Not IsDBNull(Trow("StatusSembuh")) Then CheckBoxSembuhTypoidFever.Checked = Convert.ToBoolean(Trow("StatusSembuh"))
                End If
                GoTo GoBackthis
            End If

            If Trow("fisiknourut") = ComboBoxTurunBB.Tag.ToString Then
                GetResult(ComboBoxTurunBB, Trow("result"))
                If Trow("result").ToString.Trim = "Ya" Then
                    DateTimeTurunBB.Value = Trow("Kapan")
                    If Not IsDBNull(Trow("StatusSembuh")) Then CheckBoxSembuhTurunBB.Checked = Convert.ToBoolean(Trow("StatusSembuh"))
                End If
                GoTo GoBackthis
            End If
GoBackthis:
        Next

        Dim tagvisusmata As String = ReadThemysqlNIK("select fisiknourut from transaksilabfisik where FisikNoUrut=3012 and NoUrut='" & TextBoxNoTransaksi.Text & "' AND idlabinternet='" & idTransaksi & "'", DB_Poliklinik)
        Dim tagvisusmata2 As String = ReadThemysqlNIK("select fisiknourut from transaksilabfisik where FisikNoUrut=3014 and NoUrut='" & TextBoxNoTransaksi.Text & "' AND idlabinternet='" & idTransaksi & "'", DB_Poliklinik)
        Dim var1mata As String = ""
        Dim var2mata As String = ""
        If tagvisusmata <> "-" Then
            var1mata = ReadThemysqlNIK("select Result from transaksilabfisik where FisikNoUrut='" & TextBoxVisusKacamataOD.Tag.ToString & "' and NoUrut='" & TextBoxNoTransaksi.Text & "' AND idlabinternet='" & idTransaksi & "'", DB_Poliklinik)
            var2mata = ReadThemysqlNIK("select Result from transaksilabfisik where FisikNoUrut='" & TextBoxVisusTanpaKacamataOD.Tag.ToString & "' and NoUrut='" & TextBoxNoTransaksi.Text & "' AND idlabinternet='" & idTransaksi & "'", DB_Poliklinik)

            Dim Tsplit() As String = var1mata.ToString.Split(",")
            Dim Tsplit2() As String = var2mata.ToString.Split(",")

            If var1mata.Trim <> "" Then
                TextBoxVisusKacamataOD.Text = Trim(Tsplit(0))
                If var1mata.Contains(",") = True Then
                    TextBoxVisusKacamataOS.Text = Trim(Tsplit(1))
                End If
            End If

            If var2mata.Trim <> "" Then
                TextBoxVisusTanpaKacamataOD.Text = Trim(Tsplit2(0))
                If var2mata.Contains(",") = True Then
                    TextBoxVisusTanpaKacamataOS.Text = Trim(Tsplit2(1))
                End If
            End If

            ComboBoxVisusMata2.SelectedIndex = 0
            ComboBoxVisusMata1.SelectedIndex = 0
            TextBoxVisusKacamataOD.Tag = 3012
            TextBoxVisusTanpaKacamataOD.Tag = 3013
        ElseIf tagvisusmata2 <> "-" Then
            var1mata = ReadThemysqlNIK("select Result from transaksilabfisik where FisikNoUrut=3014 and NoUrut='" & TextBoxNoTransaksi.Text & "' AND idlabinternet='" & idTransaksi & "'", DB_Poliklinik)
            var2mata = ReadThemysqlNIK("select Result from transaksilabfisik where FisikNoUrut=3015 and NoUrut='" & TextBoxNoTransaksi.Text & "' AND idlabinternet='" & idTransaksi & "'", DB_Poliklinik)

            Dim Tsplit() As String = var1mata.ToString.Split(",")
            Dim Tsplit2() As String = var2mata.ToString.Split(",")

            If var1mata.Trim <> "" Then
                TextBoxVisusKacamataOD.Text = Trim(Tsplit(0))
                If var1mata.Contains(",") = True Then
                    TextBoxVisusKacamataOS.Text = Trim(Tsplit(1))
                End If
            End If

            If var2mata.Trim <> "" Then
                TextBoxVisusTanpaKacamataOD.Text = Trim(Tsplit2(0))
                If var2mata.Contains(",") = True Then
                    TextBoxVisusTanpaKacamataOS.Text = Trim(Tsplit2(1))
                End If
            End If

            ComboBoxVisusMata2.SelectedIndex = 1
            ComboBoxVisusMata1.SelectedIndex = 1
            TextBoxVisusKacamataOD.Tag = 3014
            TextBoxVisusTanpaKacamataOD.Tag = 3015
        End If

        'Hitung BMI
        If TextBoxTinggiBadan.Text <> "" And TextBoxBeratBadan.Text <> "" And TextBoxTinggiBadan.Text <> "-" And TextBoxBeratBadan.Text <> "-" Then TextBoxIndeksMedik.Text = Math.Round(CDbl(TextBoxBeratBadan.Text / (TextBoxTinggiBadan.Text * TextBoxTinggiBadan.Text) * 10000), 1) Else TextBoxIndeksMedik.Text = "0"
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
        End If
    End Sub

    Private Sub EnableECG()
        txhasilecg.Enabled = True
        txecgtekanan.Enabled = True
        ButtonSaveECG.Enabled = True
        ButtonPrintECG.Enabled = True

        Dim Tbls As DataTable = ReadThemysql("SELECT a.Tekanan, a.DiagnosisECG, a.ECGDate, a.ECGBy from transaksilabhasillain a, transaksilab b WHERE a.nourut='" & TextBoxNoTransaksi.Text & "' AND a.nourut=b.nourut AND b.idtempatlab='" & kodeLokasi & "' and a.idlabinternet=b.idlabinternet", DB_Poliklinik)
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
        cmbjenisthorax.Enabled = True

        InsertNewItemComboSQL("SELECT ValueThorax FROM MasterNilaiHasilThorax ORDER BY ValueThorax ASC", cmbjenisthorax)
        cmbjenisthorax.SelectedIndex = -1

        Dim Tbls As DataTable = ReadThemysql("SELECT a.cor, a.pulmo, a.sinus, a.skeletal, a.kesimpulan, a.thoraxdate, a.thoraxby, a.drthorax from transaksilabhasillain a, transaksilab b WHERE a.nourut='" & TextBoxNoTransaksi.Text & "' AND a.nourut=b.nourut AND b.idtempatlab='" & kodeLokasi & "' and a.idlabinternet=b.idlabinternet", DB_Poliklinik)
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

        Dim Tbls As DataTable = ReadThemysql("SELECT a.treadmill, a.Treadmilldate, a.Treadmillby from transaksilabhasillain a, transaksilab b WHERE a.nourut='" & TextBoxNoTransaksi.Text & "' AND a.nourut=b.nourut AND b.idtempatlab='" & kodeLokasi & "' and a.idlabinternet=b.idlabinternet", DB_Poliklinik)
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

        Dim Tbls As DataTable = ReadThemysql("SELECT a.Spirometri, a.Spirometridate, a.Spirometriby from transaksilabhasillain a, transaksilab b WHERE a.nourut='" & TextBoxNoTransaksi.Text & "' AND a.nourut=b.nourut AND b.idtempatlab='" & kodeLokasi & "' and a.idlabinternet=b.idlabinternet", DB_Poliklinik)
        If Tbls.Rows.Count > 0 Then
            Dim Trow As DataRow = Tbls.Rows(0)
            If IsDBNull(Trow("Spirometri")) = False Then txspiro.Text = Trow("Spirometri")
            If IsDBNull(Trow("Spirometridate")) = False Then dtspiro.Value = Trow("Spirometridate")
            If IsDBNull(Trow("Spirometriby")) = False Then txspiroby.Text = Trow("Spirometriby")
        End If
    End Sub

    Private Sub SetUrutan()
        Dim Tbls As DataTable = ReadThemysql("select a.TransLabIDDetail,TransLabID,a.TindakanID,a.NamaTindakan,a.JenisTindakan,a.Urutan as UrutID,b.Urutan from transaksilabdetail a left join MasterLab b on a.TindakanID=b.TindakanID  where TransLabID='" & idTransaksi & "'", DB_Poliklinik)
        For Each Trow As DataRow In Tbls.Rows
            WriteThemysql("update transaksilabdetail set Urutan='" & Trow("Urutan") & "' where TransLabIDDetail='" & Trow("TransLabIDDetail") & "' and TransLabID='" & Trow("TransLabID") & "' and TindakanID='" & Trow("TindakanID") & "'", DB_Poliklinik)
        Next
    End Sub

    Public Sub SetClearGrid()
        'SetUrutan()

        'Dim Tlab As DataTable = ReadThemysql(" SELECT b.translabid As TransLabID, a.translabiddetail as TransLabIDDetail, a.tindakanid as TindakanID, a.groupid as NamaTindakan, c.jenistindakan as JenisTindakan, a.nourut as NoUrut, a.groupid as GroupID, a.detailket as DetailKet, a.result as Result, a.satuan as Satuan, a.pria as Pria, a.wanita as Wanita, a.keterangan as Keterangan, a.urutan as Urutan " & _
        '"from transaksilab b, transaksilabresult a, masterjenistindakan c " & _
        '"where a.idlabinternet = b.idlabinternet and a.urutan = c.urutanjenisid and b.translabid='" & idTransaksi & "'", DB_Poliklinik)
        'insertRowToTbls(Tlab, "typchecked", "Checked")
        Dim Tlab As DataTable = ReadThemysql(" select a.TransLabID,a.TransLabIDDetail,a.TindakanID,a.NamaTindakan,a.JenisTindakan,b.NoUrut,b.GroupID,b.DetailKet,b.Result,b.Satuan,b.Pria,b.Wanita,b.Keterangan,m.UrutanJenisID,a.Urutan, b.saran as 'Saran' " & _
                                        " from transaksilabdetail a left join transaksilabresult b on a.TransLabIDDetail =b.TransLabIDDetail and a.TindakanID=b.TindakanID and a.idlabinternet=b.idlabinternet left join masterjenistindakan m on m.JenisTindakan=a.JenisTindakan where a.idlabinternet='" & idTransaksi & "' AND a.idlabinternet<>0" & _
                                        " order by  m.UrutanJenisID,a.Urutan,b.TindakanID,b.NoUrut,a.TransLabIDDetail,a.TindakanID,b.GroupID,b.DetailKet ", DB_Poliklinik)
        'insertRowToTbls(Tlab, "typchecked", "Checked")
        For Each Tcol As DataColumn In Tlab.Columns
            Tcol.ReadOnly = True
        Next

        'Tlab.Columns("Checked").ReadOnly = False
        Tlab.Columns("Pria").ReadOnly = False
        Tlab.Columns("Wanita").ReadOnly = False

        Tlab.Columns("Result").ReadOnly = False
        Tlab.Columns("Saran").ReadOnly = False
        Tlab.Columns("Satuan").ReadOnly = False
        Tlab.Columns("Keterangan").ReadOnly = False

        'TEMPAT UNTUK PEMISAHAN DATA YANG CETAK SENDIRI DENGAN CETAKAN LAINNYA
        ClearTextDetailSelainLab()

        For Each Trow As DataRow In Tlab.Rows
            If Strings.LCase(Trow("NamaTindakan").ToString).Contains("thorax") = True Or Strings.LCase(Trow("NamaTindakan").ToString).Contains("ecg") = True Or Strings.LCase(Trow("NamaTindakan").ToString).Contains("audiometri") = True Or Strings.LCase(Trow("NamaTindakan").ToString).Contains("fisik") = True Or Strings.LCase(Trow("NamaTindakan").ToString).Contains("usg") = True Or Strings.LCase(Trow("NamaTindakan").ToString).Contains("treadmill") = True Or Strings.LCase(Trow("NamaTindakan").ToString).Contains("spirometri") = True Then

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
            End If
        Next

        gridlab.DataSource = Tlab
        GridView2.Columns("TransLabIDDetail").Visible = False
        GridView2.Columns("TindakanID").Visible = False
        GridView2.Columns("TransLabID").Visible = False
        GridView2.Columns("Urutan").Visible = False

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

    Public Sub LoadAdminLab(ByRef TxID As String, ByRef Txnourut As String)
        Dim Tbls As DataTable = ReadThemysql("SELECT a.tglinputhasil, a.caraambil, b.alamat, a.kesimpulan, a.saran, a.idpasien, a.tgllab, a.dokterrequest, a.idtempatlab, a.idlabinternet from transaksilab a LEFT JOIN masterpasien b ON a.idpasien=b.nomitra AND a.idtempatlab=b.cabang where a.idlabinternet='" & TxID & "' and a.NoUrut='" & Txnourut & "'", DB_Poliklinik)
        Dim Trow As DataRow = Tbls.Rows(0)

        SetClearHeader()

        Dim company As String = ReadThemysqlNIK("select NoJenisBayar from transaksilabbayar where idlabinternet = " & TxID & " and JenisBayar = 'TAGIHAN'", DB_Poliklinik)
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
        kodeLokasi = Trow("idtempatlab")
        idTransaksi = Trow("idlabinternet")
        butdokter.Text = Trow("dokterrequest")
        txalamat.Text = Trow("alamat")
        idTransaksi = TxID
        LoadLabPasien(Trow("idpasien"))
        DateTimeTanggalTransaksi.Value = Trow("TglLab")
        If IsDBNull(Trow("kesimpulan")) = False Then txketall.Text = Trow("kesimpulan") Else txketall.ResetText()
        If IsDBNull(Trow("saran")) = False Then txsaranall.Text = Trow("saran") Else txsaranall.ResetText()
        If IsDBNull(Trow("caraambil")) = False Then txcaraambil.Text = Trow("caraambil") Else txcaraambil.ResetText()

        If IsDBNull(Trow("tglinputhasil")) = False Then chkclosed.Checked = True Else chkclosed.Checked = False

        'If Trow("Status").ToString.Trim = "CHECK" Then
        PrintSementaraToolStripMenuItem.Enabled = True
        PreviewHasilLabToolStripMenuItem.Enabled = True
        SendingWhatsappEmailToolStripMenuItem.Enabled = True
        'CetakLabelToolStripMenuItem.Enabled = True
        DownloadHasilToolStripMenuItem.Enabled = True
        ResendToMesinToolStripMenuItem.Enabled = True
        CetakBarcodeToolStripMenuItem.Enabled = True
        'ElseIf Trow("Status").ToString.Trim = "SEND" Then
        'PrintSementaraToolStripMenuItem.Enabled = False
        'PrintToolStripMenuItem.Enabled = False
        'DownloadHasilToolStripMenuItem.Enabled = False
        'ResendToMesinToolStripMenuItem.Enabled = False
        'StartProcessToolStripMenuItem.Enabled = False
        'ResendToMesinToolStripMenuItem.Enabled = True
        'ElseIf Trow("Status").ToString.Trim = "CLOSED" Then
        'PrintSementaraToolStripMenuItem.Enabled = False
        'PrintToolStripMenuItem.Enabled = False
        'SendToDrPKToolStripMenuItem.Enabled = False
        'DownloadHasilToolStripMenuItem.Enabled = False
        'ResendToMesinToolStripMenuItem.Enabled = False
        'StartProcessToolStripMenuItem.Enabled = False
        'ElseIf Trow("Status").ToString.Trim = "CETAK" Then
        'PrintSementaraToolStripMenuItem.Enabled = False
        'PrintToolStripMenuItem.Enabled = True
        'SendToDrPKToolStripMenuItem.Enabled = False
        'DownloadHasilToolStripMenuItem.Enabled = False
        'SaveToolStripMenuItem.Enabled = False
        'If IsDBNull(Trow("TglCetakHasil")) = False Then PrintToolStripMenuItem.Enabled = False Else PrintToolStripMenuItem.Enabled = True
        'StartProcessToolStripMenuItem.Enabled = False
        'ElseIf Trow("Status").ToString.Trim = "TAKEIT" Then
        'DownloadHasilToolStripMenuItem.Enabled = False
        'StartProcessToolStripMenuItem.Enabled = False
        'SendToDrPKToolStripMenuItem.Enabled = False
        'ResendToMesinToolStripMenuItem.Enabled = False
        'StartProcessToolStripMenuItem.Enabled = False
        'End If

        SetClearGrid()
        butfindtindakanid.Enabled = False
        'If Trow("ClosedInputHasil").ToString = True Then
        '    MsgBox("Hasil telah terkunci. Tidak dapat diganti-ganti.")
        '    SaveToolStripMenuItem.Enabled = False
        '    SendToDrPKToolStripMenuItem.Enabled = True
        '    txhasilecg.Enabled = False
        '    txecgtekanan.Enabled = False
        '    txaudiometri.Enabled = False
        '    txthoraxcor.Enabled = False
        '    txthoraxpulmo.Enabled = False
        '    txthoraxsinus.Enabled = False
        '    txthoraxskeletal.Enabled = False
        '    txthoraxkesimpulan.Enabled = False
        '    gridfisik.Enabled = False
        '    butsavethorax.Enabled = False
        '    butsaveecg.Enabled = False
        '    butsavefisik.Enabled = False
        '    butsaveaudio.Enabled = False
        'End If

        'Set QR Code
        'Dim KodeBarcode As String = ReadThemysqlNIK("SELECT a.kodebarcode FROM mastercodebarcode a WHERE a.kodecabang = '" & Trow("idtempatlab") & "'", DB_Poliklinik)
        'Dim URLQR As String = ReadSQLNIK("select StrValue from MsConfig where ConfigName='URLQRHasil_Lab'")
        'Dim txQR As String = URLQR & KodeBarcode & Txnourut & "_Hasil_Laboratorium_" & TxID
        'Dim Generator As New MessagingToolkit.Barcode.BarcodeEncoder
        'Generator.BackColor = Color.Transparent
        'Generator.LabelFont = New Font("Arial", 7, FontStyle.Regular)
        'Generator.IncludeLabel = True

        'QR_Code_Trans.Image = New Bitmap(Generator.Encode(MessagingToolkit.Barcode.BarcodeFormat.QRCode, txQR))
        'QR_Code_Trans.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub

    Public Sub LoadLabPasien(ByRef Txid As String)
        Dim Tbls As DataTable = ReadThemysql("select NoMitra,NoKartu,Nama,TglLahir,Sex from masterpasien where nomitra='" & Txid & "' AND cabang='" & kodeLokasi & "'", DB_Poliklinik)
        Dim Trow As DataRow = Tbls.Rows(0)
        TextBoxNoRekamMedis.Text = Txid
        TextBoxNamaPasien.Text = Trow("Nama")
        TextBoxJenisKelamin.Text = Trow("Sex")
        DateTimeTanggalLahir.Value = Trow("TglLahir")
        TextBoxUmur.Text = Umur(DateTimeTanggalLahir.Value)
        TextBoxGelar.Text = Gelar(Year(Now()) - Year(DateTimeTanggalLahir.Value), TextBoxJenisKelamin.Text)
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        SetClearHeader()
        SetClearGrid()
    End Sub

    Private Sub LabAdmin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        setConn()
        Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
        Me.MdiParent = PoliKlinik
        'SetFormHeightWeight(Me, 0.95, 0.8)
        Me.Dock = DockStyle.Fill
        NewToolStripMenuItem.PerformClick()
        AutoTTD = ReadSQLNIK("select StrValue from MsConfig where ConfigName='AutoTTD'")
        'AutoTTD = "No"
    End Sub

    Private Sub setConn()
        ' Set Parameter Server Online
        Dim serverOnline_IP As String = Utility.GetConfig("ServerOnline_IP")
        Dim serverOnline_UserID As String = Utility.GetConfig("ServerOnline_UserID")
        Dim serverOnline_Password As String = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerOnline_Password"), "albert")

        ' Set DB Poliklinik
        DB_Poliklinik.Tip = serverOnline_IP
        DB_Poliklinik.Tid = serverOnline_UserID
        DB_Poliklinik.Tpass = serverOnline_Password
        DB_Poliklinik.Tdb = Utility.GetConfig("ServerOnlinePoli_DB")

        ' Set Find Poliklinik
        Find_Poliklinik.Tip = serverOnline_IP
        Find_Poliklinik.Tid = serverOnline_UserID
        Find_Poliklinik.Tpass = serverOnline_Password
        Find_Poliklinik.Tdb = Utility.GetConfig("ServerOnlinePoli_DB")

        DB_Sysmex.Tid = "root"
        DB_Sysmex.Tip = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'db_host_sysmex'")
        DB_Sysmex.Tdb = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'db_name_sysmex'")
        DB_Sysmex.Tpass = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'db_pass_sysmex'")
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
        If idTransaksi <> "" Then
            Dim Tdiff As Integer = Utility.GetConfig("MesinDiff")

            If Tdiff = "5" Then
                Dim Tnourut As String = ReadThemysqlNIK("select NoUrut from transaksilab where idlabinternet='" & idTransaksi & "'", DB_Poliklinik)
                ResultMachine.LoadAdminLab(idTransaksi, Tnourut, "Diff5", "Online", kodeLokasi)
                ResultMachine.ShowDialog()
            ElseIf Tdiff = "3" Then
                Dim Tnourut As String = ReadThemysqlNIK("select NoUrut from transaksilab where idlabinternet='" & idTransaksi & "'", DB_Poliklinik)
                ResultMachine.LoadAdminLab(idTransaksi, Tnourut, "Diff3", "Online", kodeLokasi)
                ResultMachine.ShowDialog()
            End If
        End If
    End Sub

    Private Sub PrintSementaraToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintSementaraToolStripMenuItem.Click
        CreateHasilToPDF("Print", "No")
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
                If CheckThemysql("select * from transaksilabhasillain where NoUrut='" & TextBoxNoTransaksi.Text & "' and idlabinternet='" & idTransaksi & "'", DB_Poliklinik) = True Then
                    WriteThemysql("update transaksilabhasillain set Cor='" & txthoraxcor.Text & "',Pulmo='" & txthoraxpulmo.Text & "',Sinus='" & txthoraxsinus.Text & "',Skeletal='" & txthoraxskeletal.Text & "',Kesimpulan='" & txthoraxkesimpulan.Text & "',ThoraxDate=NOW(),ThoraxBy='" & UserLabAdminOnline & "' , drThorax='" & drthorax.Text & "' where NoUrut='" & TextBoxNoTransaksi.Text & "' and idlabinternet='" & idTransaksi & "'", DB_Poliklinik)
                Else
                    WriteThemysql("insert transaksilabhasillain(NoUrut,Cor,Pulmo,Sinus,Skeletal,Kesimpulan,ThoraxDate,ThoraxBy,idlabinternet,drThorax) values('" & TextBoxNoTransaksi.Text & "','" & txthoraxcor.Text & "','" & txthoraxpulmo.Text & "','" & txthoraxsinus.Text & "','" & txthoraxskeletal.Text & "','" & txthoraxkesimpulan.Text & "',NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "','" & drthorax.Text & "')", DB_Poliklinik)
                End If

                cmbjenisthorax.SelectedIndex = -1
                MsgBox("Data Thorax Saved.", MsgBoxStyle.Information, "Success!")
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
                If CheckThemysql("select * from transaksilabhasillain where NoUrut='" & TextBoxNoTransaksi.Text & "' and idlabinternet='" & idTransaksi & "'", DB_Poliklinik) = True Then
                    WriteThemysql("update transaksilabhasillain set  Audio='" & txaudiometri.Text & "', AudioDate=NOW(),AudioBy='" & UserLabAdminOnline & "' , DrAudio='" & draudio.Text & "' where NoUrut='" & TextBoxNoTransaksi.Text & "' and idlabinternet='" & idTransaksi & "'", DB_Poliklinik)
                Else
                    WriteThemysql("insert transaksilabhasillain(NoUrut,Audio,AudioDate,AudioBy,idlabinternet) values('" & TextBoxNoTransaksi.Text & "','" & txaudiometri.Text & "',NOW(),'" & UserLabAdminOnline & "', '" & idTransaksi & "')", DB_Poliklinik)
                End If
                MsgBox("Data Audiometri Saved")
            End If
        Next
    End Sub

    Private Sub butprintthorax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butprintthorax.Click
        If CheckThemysql("select * from transaksilabhasillain where NoUrut='" & TextBoxNoTransaksi.Text & "' and idlabinternet='" & idTransaksi & "'", DB_Poliklinik) Then
            Dim TempWhatsapp As String = ""
            Dim TempEmail As String = ""

            Dim Tlab As DataTable = ReadThemysql("SELECT a.SendingWhatsapp, a.SendingEmail, b.PTNIK, a.caraambil, a.dokterrequest from transaksilab a LEFT JOIN masterpasien b ON a.idpasien=b.nomitra AND a.idtempatlab=b.cabang where idlabinternet='" & idTransaksi & "' AND idtempatlab='" & kodeLokasi & "'", DB_Poliklinik)
            Dim TrowLab As DataRow = Tlab.Rows(0)
            Dim ptnik As String = ""
            Dim Pengirim As String = ""
            If IsDBNull(TrowLab("PTNIK")) = False Then ptnik = TrowLab("PTNIK") Else ptnik = "-"
            Dim DrRequest As String = TrowLab("dokterrequest")
            Dim caraambil As String = TrowLab("caraambil")
            If CheckSQL("select * from mastercompany where NoCompany = '" & txcodepenagihan.Text.Trim & "' and ReportHasilPerusahaan = 0") = True And TextBoxNoTransaksi.Text.Contains("M") = True Then
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

            Dim Nama As String = TextBoxNamaPasien.Text
            Dim numberic As Boolean = False

            For Each str As Char In Nama
                If IsNumeric(str) Then
                    numberic = True
                    Exit For
                End If
            Next

            Dim Tempthorax As DataTable = ReadThemysql("select * from transaksilabhasillain where NoUrut='" & TextBoxNoTransaksi.Text & "' and idlabinternet='" & idTransaksi & "'", DB_Poliklinik)
            insertRowToTbls(Tempthorax, "typstring", "Registrasi")
            insertRowToTbls(Tempthorax, "typstring", "Nama")
            insertRowToTbls(Tempthorax, "typstring", "barcodenotrans")
            insertRowToTbls(Tempthorax, "typstring", "Umur")
            insertRowToTbls(Tempthorax, "typstring", "Alamat")
            insertRowToTbls(Tempthorax, "typstring", "NoTransaksi")
            insertRowToTbls(Tempthorax, "typstring", "DrPelaksana")
            insertRowToTbls(Tempthorax, "typstring", "DrRequest")
            insertRowToTbls(Tempthorax, "typstring", "Tanggal")
            insertRowToTbls(Tempthorax, "typstring", "Hasil")
            For Each Trow As DataRow In Tempthorax.Rows
                Trow("Registrasi") = TextBoxNoRekamMedis.Text
                Trow("barcodenotrans") = idTransaksi
                If (TextBoxNoTransaksi.Text.Contains("M")) Then
                    If numberic = True Then
                        Trow("Nama") = TextBoxGelar.Text & " " & TextBoxNamaPasien.Text & "/(" & TextBoxJenisKelamin.Text & ")" & vbCrLf
                    Else
                        Trow("Nama") = TextBoxGelar.Text & " " & TextBoxNamaPasien.Text & " / " & ptnik & " (" & TextBoxJenisKelamin.Text & ")" & vbCrLf
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
                Trow("NoTransaksi") = TextBoxNoTransaksi.Text & " (" & idTransaksi & ")"
                Trow("DrPelaksana") = DrPelaksanaKlinik
                Trow("Hasil") = caraambil

                If Pengirim <> "" Then
                    Trow("DrRequest") = Pengirim
                Else
                    If IsNumeric(DrRequest.ToString.Trim) = True Or DrRequest.ToString.Trim = "" Or TextBoxNoTransaksi.Text.Contains("M") Then
                        Trow("DrRequest") = txpenagihan.Text.Trim
                    Else
                        Trow("DrRequest") = DrRequest
                    End If
                End If

                Trow("Tanggal") = Format(DateTimeTanggalTransaksi.Value, "dd-MMM-yyyy")
            Next

            Report = New XtraReport
            Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\Hasil\HasilLabThoraxNonKop.repx", True)
            If AutoTTD.Trim = "Yes" Then
                Report.Bands.Item(BandKind.PageHeader).Controls("ttd").Visible = True
                Report.Bands.Item(BandKind.PageHeader).Controls("ttd").Height = 134
                Report.Bands.Item(BandKind.PageHeader).Controls("ttd").Width = 250
            Else
                Report.Bands.Item(BandKind.PageHeader).Controls("ttd").Visible = False
            End If

            Report.DataSource = Tempthorax
            Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MM-yyyy HH:mm:ss") + " by " + UserLabAdminOnline

            'Report.RunDesigner()
            'Report.ShowPreview()
            Report.Print()
        End If
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
                If CheckThemysql("select * from transaksilabhasillain where NoUrut='" & TextBoxNoTransaksi.Text & "' and idlabinternet='" & idTransaksi & "'", DB_Poliklinik) = True Then
                    WriteThemysql("update transaksilabhasillain set  usg='" & txusg.Text & "', USGDate=NOW() , USGBy='" & UserLabAdminOnline & "',DrUSG='" & drusg.Text & "'  where NoUrut='" & TextBoxNoTransaksi.Text & "' and idlabinternet='" & idTransaksi & "'", DB_Poliklinik)
                Else
                    WriteThemysql("insert transaksilabhasillain(NoUrut,usg,USGDate,USGBy,idlabinternet) values('" & TextBoxNoTransaksi.Text & "','" & txusg.Text & "',NOW(),'" & UserLabAdminOnline & "', '" & idTransaksi & "')", DB_Poliklinik)
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
                If CheckThemysql("select * from transaksilabhasillain where NoUrut='" & TextBoxNoTransaksi.Text & "' and idlabinternet='" & idTransaksi & "'", DB_Poliklinik) = True Then
                    WriteThemysql("update transaksilabhasillain set  treadmill='" & txtreadmill.Text & "', treadmillDate=NOW() , treadmillBy='" & UserLabAdminOnline & "' , Drtreadmmill='" & drtreadmill.Text & "'  where NoUrut='" & TextBoxNoTransaksi.Text & "' and idlabinternet='" & idTransaksi & "'", DB_Poliklinik)
                Else
                    WriteThemysql("insert transaksilabhasillain(NoUrut,treadmill,treadmillDate,treadmillBy,idlabinternet) values('" & TextBoxNoTransaksi.Text & "','" & txtreadmill.Text & "',NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "')", DB_Poliklinik)
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
                If CheckThemysql("select * from transaksilabhasillain where NoUrut='" & TextBoxNoTransaksi.Text & "' and idlabinternet='" & idTransaksi & "'", DB_Poliklinik) = True Then
                    WriteThemysql("update transaksilabhasillain set  spirometri='" & txspiro.Text & "', spirometriDate=NOW() , spirometriBy='" & UserLabAdminOnline & "' ,DrSpiro='" & drspiro.Text & "' where NoUrut='" & TextBoxNoTransaksi.Text & "' and idlabinternet='" & idTransaksi & "'", DB_Poliklinik)
                Else
                    WriteThemysql("insert transaksilabhasillain(NoUrut,spirometri,spirometriDate,spirometriBy,idlabinternet) values('" & TextBoxNoTransaksi.Text & "','" & txspiro.Text & "',NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "')", DB_Poliklinik)
                End If
                MsgBox("Data Spirometri Saved")
                Exit For
            End If
        Next
    End Sub

    Private Sub ResendToMesinToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ResendToMesinToolStripMenuItem.Click
        If TextBoxNoTransaksi.Text = "" Then
            MsgBox("Pilih Pasien Lab yang akan dikirim.")
            Exit Sub
        End If

        Dim KodeBarcodeOnline As String = ""
        KodeBarcodeOnline = ReadThemysqlNIK("SELECT kodebarcode FROM mastercodebarcode WHERE kodecabang='" & kodeLokasi & "'", DB_Poliklinik)

        'Dim Tmesin As DataTable = ReadThemysql("select a.NoUrut,a.TglLab,a.Nama,b.Mesin,b.TindakanID,b.groupid as NamaTindakan, a.dokterrequest as DrNama,d.Sex,LEFT(d.Alamat,100) as Alamat from transaksilab a left join transaksilabresult b on a.idlabinternet=b.idlabinternet left join masterpasien d on d.idpasien=a.idpasien where a.idlabinternet='" & idTransaksi & "' and Mesin is not null", DB_Poliklinik)
        Dim Tmesin As DataTable = ReadThemysql("select a.NoUrut,a.TglLab, a.idpasien AS 'nomitra', a.tgllahir,a.Nama,c.Mesin,c.TindakanID,c.NamaTindakan, a.dokterrequest as DrNama,d.Sex,LEFT(d.Alamat,100) as Alamat from transaksilab a left join transaksilabdetail c on c.idlabinternet=a.idlabinternet left join masterpasien d on d.nomitra=a.idpasien AND d.cabang=a.idtempatlab where a.idlabinternet='" & idTransaksi & "' and c.mesin is not null  and c.mesin<>''  AND d.cabang='" & kodeLokasi & "'", DB_Poliklinik)

        If Tmesin.Rows.Count > 0 Then
            For Each Trow As DataRow In Tmesin.Rows
                If CheckThemysql("select * from paslab where NoUrut='" & KodeBarcodeOnline & Strings.Right(Strings.Replace(Strings.Replace(Trow("NoUrut"), "L", 8), "M", 9), Len(Trow("NoUrut").ToString.Trim) - 2) & "' and TglLab='" & Format(Trow("TglLab"), "yyyyMMdd") & "' and Instrument='" & Trow("Mesin") & "' and kode_jasa='" & Trow("TindakanID") & "' and nama_jasa='" & Trow("NamaTindakan") & "'", DB_Sysmex) = False Then
                    WriteThemysql("insert into paslab(`NoUrut`, `TglLab`, `Nama`, `Instrument`, `kode_jasa`, `nama_jasa`,`nama_dok`,`sex`,`alamat`,`no_rm`,`tgl_lahir`) " & _
                             " values('" & KodeBarcodeOnline & Strings.Right(Strings.Replace(Strings.Replace(Trow("NoUrut"), "L", 8), "M", 9), Len(Trow("NoUrut").ToString.Trim) - 2) & "','" & Format(Trow("TglLab"), "yyyyMMdd") & "','" & Trow("Nama") & "','" & Trow("Mesin") & "','" & Trow("TindakanID") & "','" & Trow("NamaTindakan") & "','" & Trow("DrNama") & "','" & Trow("Sex") & "','" & Trow("Alamat") & "','" & Trow("nomitra") & "','" & Format(Trow("TglLahir"), "yyyyMMdd") & "')", DB_Sysmex)
                End If
            Next
        End If
        MsgBox("Done. Send to Mesin")
    End Sub

    Private Sub butprintaudio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butprintaudio.Click
        If CheckThemysql("select * from transaksilabhasillain where NoUrut='" & TextBoxNoTransaksi.Text & "' and idlabinternet='" & idTransaksi & "'", DB_Poliklinik) Then
            Dim Tlab As DataTable = ReadThemysql("SELECT a.Kesimpulan, a.Saran, b.PTNIK, a.caraambil, a.dokterrequest from transaksilab a LEFT JOIN masterpasien b ON a.idpasien=b.nomitra AND a.idtempatlab=b.cabang where idlabinternet='" & idTransaksi & "' AND idtempatlab='" & kodeLokasi & "'", DB_Poliklinik)
            Dim TrowLab As DataRow = Tlab.Rows(0)
            Dim Tsimpul As String = TrowLab("Kesimpulan")
            Dim Tsaran As String = TrowLab("Saran")
            Dim ptnik As String = TrowLab("PTNIK")
            Dim DrRequest As String = TrowLab("dokterrequest")
            Dim caraambil As String = TrowLab("caraambil")

            Dim Tempecg As DataTable = ReadThemysql("select * from transaksilabhasillain where NoUrut='" & TextBoxNoTransaksi.Text & "' and idlabinternet='" & idTransaksi & "'", DB_Poliklinik)
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
                Trow("Nama") = TextBoxGelar.Text & " " & TextBoxNamaPasien.Text & "/(" & TextBoxJenisKelamin.Text & ")"
                Dim Tgltemp As Date = DateTimeTanggalLahir.Value
                If Tgltemp.Date.AddYears(120).Year < DateAndTime.Now.Year Then
                    Trow("Umur") = ""
                Else
                    Trow("Umur") = Format(DateTimeTanggalLahir.Value, "dd MMM yyyy") & " / " & TextBoxUmur.Text
                End If
                Trow("Alamat") = txalamat.Text
                Trow("NoTransaksi") = TextBoxNoTransaksi.Text & " (" & idTransaksi & ")"
                Trow("DrPelaksana") = DrPelaksanaKlinik

                If IsNumeric(DrRequest.ToString.Trim) = True Or DrRequest.ToString.Trim = "" Then
                    Trow("DrRequest") = ReadThemysqlNIK("select b.CompanyNama from transaksilab c inner join masterpasien a on c.idpasien=a.nomitra inner join mitramed_poliklinik.mastercompany b on a.PTID=b.NoCompany where c.idpasien='" & TextBoxNoRekamMedis.Text & "' AND a.cabang='" & kodeLokasi & "' LIMIT 1", DB_Poliklinik)
                Else
                    Trow("DrRequest") = DrRequest
                End If

                Trow("Tanggal") = Format(DateTimeTanggalTransaksi.Value, "dd-MMM-yyyy")
            Next

            Report = New XtraReport
            Report = XtraReport.FromFile(Application.StartupPath + "\reports\PrintHasilLabAudiometri.repx", True)
            Report.DataSource = Tempecg
            Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:ss") + UserLabAdminOnline
            'Report.Bands.Item(BandKind.PageHeader).Controls("DokterAudio").Text = ReadSQLNIK("select StrValue from msconfig where ConfigName='DokterAudio'")
            Report.Bands.Item(BandKind.PageHeader).Controls("DokterAudio").Text = ReadThemysqlNIK("select DrAudio from transaksilabhasillain where NoUrut='" & TextBoxNoTransaksi.Text & "' and idlabinternet='" & idTransaksi & "'", DB_Poliklinik)

            'Report.RunDesigner()
            Report.ShowPreview()
            'Report.Print()
        End If
    End Sub

    Private Sub butprintusg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butprintusg.Click
        If CheckThemysql("select * from transaksilabhasillain where NoUrut='" & TextBoxNoTransaksi.Text & "' and idlabinternet='" & idTransaksi & "'", DB_Poliklinik) Then
            Dim Tlab As DataTable = ReadThemysql("SELECT a.Kesimpulan, a.Saran, b.PTNIK, a.caraambil, a.dokterrequest from transaksilab a LEFT JOIN masterpasien b ON a.idpasien=b.nomitra AND a.idtempatlab=b.cabang where idlabinternet='" & idTransaksi & "' AND idtempatlab='" & kodeLokasi & "'", DB_Poliklinik)
            Dim TrowLab As DataRow = Tlab.Rows(0)
            Dim Tsimpul As String = TrowLab("Kesimpulan")
            Dim Tsaran As String = TrowLab("Saran")
            Dim ptnik As String = TrowLab("PTNIK")
            Dim DrRequest As String = TrowLab("dokterrequest")
            Dim caraambil As String = TrowLab("caraambil")

            Dim Tempecg As DataTable = ReadThemysql("select * from transaksilabhasillain where NoUrut='" & TextBoxNoTransaksi.Text & "' and idlabinternet='" & idTransaksi & "'", DB_Poliklinik)
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
                Trow("Nama") = TextBoxGelar.Text & " " & TextBoxNamaPasien.Text & "/(" & TextBoxJenisKelamin.Text & ")"
                Dim Tgltemp As Date = DateTimeTanggalLahir.Value
                If Tgltemp.Date.AddYears(120).Year < DateAndTime.Now.Year Then
                    Trow("Umur") = ""
                Else
                    Trow("Umur") = Format(DateTimeTanggalLahir.Value, "dd MMM yyyy") & " / " & TextBoxUmur.Text
                End If
                Trow("Alamat") = txalamat.Text
                Trow("NoTransaksi") = TextBoxNoTransaksi.Text & " (" & idTransaksi & ")"
                Trow("DrPelaksana") = DrPelaksanaKlinik

                If IsNumeric(DrRequest.ToString.Trim) = True Or DrRequest.ToString.Trim = "" Then
                    Trow("DrRequest") = ReadThemysqlNIK("select b.CompanyNama from transaksilab c inner join masterpasien a on c.idpasien=a.nomitra inner join mitramed_poliklinik.mastercompany b on a.PTID=b.NoCompany where c.idpasien='" & TextBoxNoRekamMedis.Text & "' AND a.cabang='" & kodeLokasi & "' LIMIT 1", DB_Poliklinik)
                Else
                    Trow("DrRequest") = DrRequest
                End If

                Trow("Tanggal") = Format(DateTimeTanggalTransaksi.Value, "dd-MMM-yyyy")
            Next

            Report = New XtraReport
            Report = XtraReport.FromFile(Application.StartupPath + "\reports\PrintHasilLabUSG.repx", True)
            Report.DataSource = Tempecg
            Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:ss") + UserLabAdminOnline
            'Report.Bands.Item(BandKind.PageHeader).Controls("DokterUSG").Text = ReadSQLNIK("select StrValue from msconfig where ConfigName='DokterUSG'")
            Report.Bands.Item(BandKind.PageHeader).Controls("DokterUSG").Text = ReadThemysqlNIK("select DrUSG from transaksilabhasillain where NoUrut='" & TextBoxNoTransaksi.Text & "' and idlabinternet='" & idTransaksi & "'", DB_Poliklinik)

            'Report.RunDesigner()
            Report.ShowPreview()
            'Report.Print()
        End If
    End Sub

    Private Sub butprinttreadmill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butprinttreadmill.Click
        If CheckThemysql("select * from transaksilabhasillain where NoUrut='" & TextBoxNoTransaksi.Text & "' and idlabinternet='" & idTransaksi & "'", DB_Poliklinik) Then
            Dim Tlab As DataTable = ReadThemysql("SELECT a.Kesimpulan, a.Saran, b.PTNIK, a.caraambil, a.dokterrequest from transaksilab a LEFT JOIN masterpasien b ON a.idpasien=b.nomitra AND a.idtempatlab=b.cabang where idlabinternet='" & idTransaksi & "' AND idtempatlab='" & kodeLokasi & "'", DB_Poliklinik)
            Dim TrowLab As DataRow = Tlab.Rows(0)
            Dim Tsimpul As String = TrowLab("Kesimpulan")
            Dim Tsaran As String = TrowLab("Saran")
            Dim ptnik As String = TrowLab("PTNIK")
            Dim DrRequest As String = TrowLab("dokterrequest")
            Dim caraambil As String = TrowLab("caraambil")

            Dim Tempecg As DataTable = ReadThemysql("select * from transaksilabhasillain where NoUrut='" & TextBoxNoTransaksi.Text & "' and idlabinternet='" & idTransaksi & "'", DB_Poliklinik)
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
                Trow("Nama") = TextBoxGelar.Text & " " & TextBoxNamaPasien.Text & "/(" & TextBoxJenisKelamin.Text & ")"
                Dim Tgltemp As Date = DateTimeTanggalLahir.Value
                If Tgltemp.Date.AddYears(120).Year < DateAndTime.Now.Year Then
                    Trow("Umur") = ""
                Else
                    Trow("Umur") = Format(DateTimeTanggalLahir.Value, "dd MMM yyyy") & " / " & TextBoxUmur.Text
                End If
                Trow("Alamat") = txalamat.Text
                Trow("NoTransaksi") = TextBoxNoTransaksi.Text & " (" & idTransaksi & ")"
                Trow("DrPelaksana") = DrPelaksanaKlinik

                If IsNumeric(DrRequest.ToString.Trim) = True Or DrRequest.ToString.Trim = "" Then
                    Trow("DrRequest") = ReadThemysqlNIK("select b.CompanyNama from transaksilab c inner join masterpasien a on c.idpasien=a.nomitra inner join mitramed_poliklinik.mastercompany b on a.PTID=b.NoCompany where c.idpasien='" & TextBoxNoRekamMedis.Text & "' AND a.cabang='" & kodeLokasi & "' LIMIT 1", DB_Poliklinik)
                Else
                    Trow("DrRequest") = DrRequest
                End If

                Trow("Tanggal") = Format(DateTimeTanggalTransaksi.Value, "dd-MMM-yyyy")
            Next

            Report = New XtraReport
            Report = XtraReport.FromFile(Application.StartupPath + "\reports\PrintHasilLabTreadmill.repx", True)
            Report.DataSource = Tempecg
            Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:ss") + UserLabAdminOnline
            'Report.Bands.Item(BandKind.PageHeader).Controls("DokterTreadmill").Text = ReadSQLNIK("select StrValue from msconfig where ConfigName='DokterTreadmill'")
            Report.Bands.Item(BandKind.PageHeader).Controls("DokterTreadmill").Text = ReadThemysqlNIK("select Drtreadmill from transaksilabhasillain where NoUrut='" & TextBoxNoTransaksi.Text & "' and idlabinternet='" & idTransaksi & "'", DB_Poliklinik)

            'Report.RunDesigner()
            Report.ShowPreview()
            'Report.Print()
        End If
    End Sub

    Private Sub butprintspiro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butprintspiro.Click
        If CheckThemysql("select * from transaksilabhasillain where NoUrut='" & TextBoxNoTransaksi.Text & "' and idlabinternet='" & idTransaksi & "'", DB_Poliklinik) Then
            Dim Tlab As DataTable = ReadThemysql("SELECT a.Kesimpulan, a.Saran, b.PTNIK, a.caraambil, a.dokterrequest from transaksilab a LEFT JOIN masterpasien b ON a.idpasien=b.nomitra AND a.idtempatlab=b.cabang where idlabinternet='" & idTransaksi & "' AND idtempatlab='" & kodeLokasi & "'", DB_Poliklinik)
            Dim TrowLab As DataRow = Tlab.Rows(0)
            Dim Tsimpul As String = TrowLab("Kesimpulan")
            Dim Tsaran As String = TrowLab("Saran")
            Dim ptnik As String = TrowLab("PTNIK")
            Dim DrRequest As String = TrowLab("dokterrequest")
            Dim caraambil As String = TrowLab("caraambil")

            Dim Tempecg As DataTable = ReadThemysql("select * from transaksilabhasillain where NoUrut='" & TextBoxNoTransaksi.Text & "' and '" & idTransaksi & "'", DB_Poliklinik)
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
                Trow("Nama") = TextBoxGelar.Text & " " & TextBoxNamaPasien.Text & "/(" & TextBoxJenisKelamin.Text & ")"
                Dim Tgltemp As Date = DateTimeTanggalLahir.Value
                If Tgltemp.Date.AddYears(120).Year < DateAndTime.Now.Year Then
                    Trow("Umur") = ""
                Else
                    Trow("Umur") = Format(DateTimeTanggalLahir.Value, "dd MMM yyyy") & " / " & TextBoxUmur.Text
                End If
                Trow("Alamat") = txalamat.Text
                Trow("NoTransaksi") = TextBoxNoTransaksi.Text & " (" & idTransaksi & ")"
                Trow("DrPelaksana") = DrPelaksanaKlinik

                If IsNumeric(DrRequest.ToString.Trim) = True Or DrRequest.ToString.Trim = "" Then
                    Trow("DrRequest") = ReadThemysqlNIK("select b.CompanyNama from transaksilab c inner join masterpasien a on c.idpasien=a.nomitra inner join mitramed_poliklinik.mastercompany b on a.PTID=b.NoCompany where c.idpasien='" & TextBoxNoRekamMedis.Text & "' AND a.cabang='" & kodeLokasi & "' LIMIT 1", DB_Poliklinik)
                Else
                    Trow("DrRequest") = DrRequest
                End If

                Trow("Tanggal") = Format(DateTimeTanggalTransaksi.Value, "dd-MMM-yyyy")
            Next

            Report = New XtraReport
            Report = XtraReport.FromFile(Application.StartupPath + "\reports\PrintHasilLabSpiro.repx", True)
            Report.DataSource = Tempecg
            Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:ss") + UserLabAdminOnline
            Report.Bands.Item(BandKind.PageHeader).Controls("DokterSpiro").Text = ReadThemysqlNIK("select DrSpiro from transaksilabhasillain where NoUrut='" & TextBoxNoTransaksi.Text & "' and idlabinternet='" & idTransaksi & "'", DB_Poliklinik)

            'Report.RunDesigner()
            Report.ShowPreview()
            'Report.Print()
        End If
    End Sub

    Private Sub butfindtindakanid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butfindtindakanid.Click
        Dim Thasil As Date = DateAndTime.Now
        Dim Takhir As Date = DateSerial(Thasil.Year, Thasil.Month, Thasil.Day)
        Dim Tawal As Date = "01/01/2001"

        Dim DTlong As DataTable = ReadSQL("select StrValue from msconfig where ConfigName='LongDate'")
        If DTlong.Rows.Count > 0 Then
            Dim Rdata As DataRow = DTlong.Rows(0)
            Tawal = FormatDateTime(Rdata("StrValue"), DateFormat.ShortDate)
        Else
            MsgBox("Range Tanggal belum ada di config. Set Terlebih dahulu (Default Tahun berjalan).")
        End If

        If cmbrangedate.SelectedIndex = 0 Then
            Tawal = DateAdd(DateInterval.Day, -14, Takhir.Date)
        ElseIf cmbrangedate.SelectedIndex = 1 Then
            Tawal = DateAdd(DateInterval.Month, -1, Takhir.Date)
        ElseIf cmbrangedate.SelectedIndex = 2 Then
            Tawal = DateAdd(DateInterval.Month, -6, Takhir.Date)
        ElseIf cmbrangedate.SelectedIndex = 3 Then
            Tawal = DateAdd(DateInterval.Month, -12, Takhir.Date)
        End If

        Dim Ttempat As String = ReadSQLNIK("select StrValue from MsConfig where ConfigName like '%KodePoli%'")

        Find.Show()
        Find.QueryTheMysql("select a.idlabinternet, c.kodeket, a.idtempatlab, a.nourut, a.translabid, a.idpasien, a.nama, d.alamat, a.tgllab from transaksilab a LEFT JOIN mastercodebarcode c ON c.kodecabang=a.idtempatlab LEFT JOIN masterpasien d ON a.idpasien=d.nomitra AND a.idtempatlab=d.cabang where (date(a.tgllab) between '" & Format(Tawal, "yyyy-MM-dd") & "' and '" & Format(Takhir, "yyyy-MM-dd") & "') and a.idtempatlab=c.kodecabang and a.idtempatlab<>'MCUC040 '", " order by a.idlabinternet desc", "FindTransaksiIDLab", 0, Find_Poliklinik)
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

    Private Sub cmbtelinga_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtelinga.SelectedIndexChanged
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

    Function CheckingFisikNew() As Boolean
        If TextBoxRiwayatPenyakit.Text = "" Then
            MsgBox("Masukkan Riwayat sakit jika ada. Jika tidak harap diisi dengan - ")
            TextBoxRiwayatPenyakit.Focus()
            Return False
        End If

        If TextBoxTinggiBadan.Text = "" Then
            MsgBox("Masukkan detail suhu yang sesuai")
            TextBoxTinggiBadan.Focus()
            Return False
        End If

        If TextBoxBeratBadan.Text = "" Then
            MsgBox("Masukkan detail suhu yang sesuai")
            TextBoxBeratBadan.Focus()
            Return False
        End If

        If TextBoxSuhu.Text = "" Then
            MsgBox("Masukkan detail suhu yang sesuai")
            TextBoxSuhu.Focus()
            Return False
        End If

        If TextBoxDetakNadi.Text = "" Then
            MsgBox("Masukkan detail nadi yang sesuai")
            TextBoxDetakNadi.Focus()
            Return False
        End If

        If TextBoxSistole.Text = "" Then
            MsgBox("Masukkan detail tekanan yang sesuai")
            TextBoxSistole.Focus()
            Return False
        End If

        If TextBoxDiastole.Text = "" Then
            MsgBox("Masukkan detail tekanan yang sesuai")
            TextBoxDiastole.Focus()
            Return False
        End If

        If TextBoxNafas.Text = "" Then
            MsgBox("Masukkan detail data yang sesuai")
            TextBoxNafas.Focus()
            Return False
        End If

        If cmbkesadaran.FindStringExact(cmbkesadaran.Text) <= 0 Then
            MsgBox("Masukkan detail data yang sesuai")
            cmbkesadaran.Focus()
            Return False
        End If

        If CheckingCombo(cmbkepala, txkepala) = False Then Exit Function
        If CheckingCombo(cmbrambut, txrambut) = False Then Exit Function
        If CheckingCombo(cmbmuka, txmuka) = False Then Exit Function
        If CheckingCombo(cmbmata, txmata) = False Then Exit Function
        If CheckingCombo(cmbbutawarna, txbutwarna) = False Then Exit Function
        If CheckingCombo(cmbtelinga, txtelinga) = False Then Exit Function
        If CheckingCombo(cmbhidung, txhidung) = False Then Exit Function
        If CheckingCombo(cmbmulut, txmulut) = False Then Exit Function
        If CheckingCombo(cmbgigi, txgigi) = False Then Exit Function
        If CheckingCombo(cmblidah, txlidah) = False Then Exit Function
        If CheckingCombo(cmbtenggorokan, txtenggorokan) = False Then Exit Function
        If CheckingCombo(cmbleher, txleher) = False Then Exit Function
        If CheckingCombo(cmbdada, txdada) = False Then Exit Function
        If CheckingCombo(ComboBoxFisikPerut, TextBoxFisikPerut) = False Then Exit Function
        If CheckingCombo(ComboBoxFisikRectalToucher, TextBoxFisikRectalToucher) = False Then Exit Function
        If CheckingCombo(cmbintegumen, txintegumen) = False Then Exit Function
        If CheckingCombo(cmbekstemitas, txekstemitas) = False Then Exit Function


        If TextBoxVisusKacamataOD.Text = "" Then
            MsgBox("Masukkan detail data yang sesuai")
            TextBoxVisusKacamataOD.Focus()
            Return False
        End If

        If TextBoxVisusTanpaKacamataOD.Text = "" Then
            MsgBox("Masukkan detail data yang sesuai")
            TextBoxVisusTanpaKacamataOD.Focus()
            Return False
        End If


        If txkoreksiakhir.Text = "" Then
            MsgBox("Masukkan detail data yang sesuai")
            txkoreksiakhir.Focus()
            Return False
        End If

        If cmbturgor.FindStringExact(cmbturgor.Text) <= 0 Then
            MsgBox("Masukkan detail data yang sesuai")
            cmbturgor.Focus()
            Return False
        End If

        If ComboBoxRiwayatRumahSakit.FindStringExact(ComboBoxRiwayatRumahSakit.Text) <= 0 Then
            MsgBox("Masukkan detail data yang sesuai")
            ComboBoxRiwayatRumahSakit.Focus()
            Return False
        End If

        If ComboBoxRiwayatPengobatanPenyakit.FindStringExact(ComboBoxRiwayatPengobatanPenyakit.Text) <= 0 Then
            MsgBox("Masukkan detail data yang sesuai")
            ComboBoxRiwayatPengobatanPenyakit.Focus()
            Return False
        End If

        If ComboBoxRiwayatPenggunaNarkoba.FindStringExact(ComboBoxRiwayatPenggunaNarkoba.Text) <= 0 Then
            MsgBox("Masukkan detail data yang sesuai")
            ComboBoxRiwayatPenggunaNarkoba.Focus()
            Return False
        End If

        If ComboBoxRiwayatPenyakitKeluarga.FindStringExact(ComboBoxRiwayatPenyakitKeluarga.Text) <= 0 Then
            MsgBox("Masukkan detail data yang sesuai")
            ComboBoxRiwayatPenyakitKeluarga.Focus()
            Return False
        End If

        If ComboBoxRiwayatKondisiSehat.FindStringExact(ComboBoxRiwayatKondisiSehat.Text) <= 0 Then
            MsgBox("Masukkan detail data yang sesuai")
            ComboBoxRiwayatKondisiSehat.Focus()
            Return False
        End If

        If cmbrokok.FindStringExact(cmbrokok.Text) <= 0 Then
            MsgBox("Masukkan detail data yang sesuai")
            cmbrokok.Focus()
            Return False
        End If

        If cmbalkohol.FindStringExact(cmbalkohol.Text) <= 0 Then
            MsgBox("Masukkan detail data yang sesuai")
            cmbalkohol.Focus()
            Return False
        End If

        If cmbkopi.FindStringExact(cmbkopi.Text) <= 0 Then
            MsgBox("Masukkan detail data yang sesuai")
            cmbkopi.Focus()
            Return False
        End If

        If cmbpolamakan.FindStringExact(cmbpolamakan.Text) <= 0 Then
            MsgBox("Masukkan detail data yang sesuai")
            cmbpolamakan.Focus()
            Return False
        End If

        If cmbistirahat.FindStringExact(cmbistirahat.Text) <= 0 Then
            MsgBox("Masukkan detail data yang sesuai")
            cmbistirahat.Focus()
            Return False
        End If

        If cmbolahraga.FindStringExact(cmbolahraga.Text) <= 0 Then
            MsgBox("Masukkan detail data yang sesuai")
            cmbolahraga.Focus()
            Return False
        End If

        If ComboBoxHepatitis.FindStringExact(ComboBoxHepatitis.Text) <= 0 Then
            MsgBox("Masukkan detail data yang sesuai")
            ComboBoxHepatitis.Focus()
            Return False
        End If

        If ComboBoxTHT.FindStringExact(ComboBoxTHT.Text) <= 0 Then
            MsgBox("Masukkan detail data yang sesuai")
            ComboBoxTHT.Focus()
            Return False
        End If

        If ComboBoxTBC.FindStringExact(ComboBoxTBC.Text) <= 0 Then
            MsgBox("Masukkan detail data yang sesuai")
            ComboBoxTBC.Focus()
            Return False
        End If

        If ComboBoxAnorexia.FindStringExact(ComboBoxAnorexia.Text) <= 0 Then
            MsgBox("Masukkan detail data yang sesuai")
            ComboBoxAnorexia.Focus()
            Return False
        End If

        If ComboBoxTypoidFever.FindStringExact(ComboBoxTypoidFever.Text) <= 0 Then
            MsgBox("Masukkan detail data yang sesuai")
            ComboBoxTypoidFever.Focus()
            Return False
        End If

        If ComboBoxTurunBB.FindStringExact(ComboBoxTurunBB.Text) <= 0 Then
            MsgBox("Masukkan detail data yang sesuai")
            ComboBoxTurunBB.Focus()
            Return False
        End If

        If ComboBoxHernia.FindStringExact(ComboBoxHernia.Text) <= 0 Then
            MsgBox("Masukkan detail data yang sesuai")
            ComboBoxHernia.Focus()
            Return False
        End If

        If ComboBoxSakitJantung.FindStringExact(ComboBoxSakitJantung.Text) <= 0 Then
            MsgBox("Masukkan detail data yang sesuai")
            ComboBoxSakitJantung.Focus()
            Return False
        End If

        If ComboBoxAmbeien.FindStringExact(ComboBoxAmbeien.Text) <= 0 Then
            MsgBox("Masukkan detail data yang sesuai")
            ComboBoxAmbeien.Focus()
            Return False
        End If

        If ComboBoxHipertensi.FindStringExact(ComboBoxHipertensi.Text) <= 0 Then
            MsgBox("Masukkan detail data yang sesuai")
            ComboBoxHipertensi.Focus()
            Return False
        End If

        If ComboBoxKencingBatu.FindStringExact(ComboBoxKencingBatu.Text) <= 0 Then
            MsgBox("Masukkan detail data yang sesuai")
            ComboBoxKencingBatu.Focus()
            Return False
        End If

        If ComboBoxVertigo.FindStringExact(ComboBoxVertigo.Text) <= 0 Then
            MsgBox("Masukkan detail data yang sesuai")
            ComboBoxVertigo.Focus()
            Return False
        End If

        If ComboBoxEpilepsi.FindStringExact(ComboBoxEpilepsi.Text) <= 0 Then
            MsgBox("Masukkan detail data yang sesuai")
            ComboBoxEpilepsi.Focus()
            Return False
        End If

        If ComboBoxPingsan.FindStringExact(ComboBoxPingsan.Text) <= 0 Then
            MsgBox("Masukkan detail data yang sesuai")
            ComboBoxPingsan.Focus()
            Return False
        End If

        If ComboBoxGastritis.FindStringExact(ComboBoxGastritis.Text) <= 0 Then
            MsgBox("Masukkan detail data yang sesuai")
            ComboBoxGastritis.Focus()
            Return False
        End If

        If ComboBoxPusing.FindStringExact(ComboBoxPusing.Text) <= 0 Then
            MsgBox("Masukkan detail data yang sesuai")
            ComboBoxPusing.Focus()
            Return False
        End If

        If ComboBoxDiabetesMellitus.FindStringExact(ComboBoxDiabetesMellitus.Text) <= 0 Then
            MsgBox("Masukkan detail data yang sesuai")
            ComboBoxDiabetesMellitus.Focus()
            Return False
        End If

        If ComboBoxParuNonTBC.FindStringExact(ComboBoxParuNonTBC.Text) <= 0 Then
            MsgBox("Masukkan detail data yang sesuai")
            ComboBoxParuNonTBC.Focus()
            Return False
        End If

        If ComboBoxRiwayatOperasi.FindStringExact(ComboBoxRiwayatOperasi.Text) <= 0 Then
            MsgBox("Masukkan detail data yang sesuai")
            ComboBoxRiwayatOperasi.Focus()
            Return False
        End If

        If ComboBoxDokterFisik.FindStringExact(ComboBoxDokterFisik.Text) < 0 Then
            MsgBox("Pilih dokter Fisik yang memeriksa")
            ComboBoxDokterFisik.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub UpdateHasilFisik(ByVal fisikKeterangan As String, ByVal fisikID As String, ByVal fisikResult As String, ByVal fisikResult2 As String)
        Dim _hasil As String = ""
        Dim _dimana As String = ""
        Dim _kenapa As String = ""
        Dim _jenis As String = ""
        Dim _kapan As String = "1900-01-01"
        Dim _statusSembuh As Boolean = False

        If fisikResult.ToString.Contains("...") = True Then
            _hasil = fisikResult.ToString + "~" + fisikResult2.ToString
            _hasil = ValueKesimpulan(_hasil)
        Else
            _hasil = fisikResult.ToString
        End If

        ' Format => Hasil # Dimana # Kenapa (Penyakit / Diagnosa / Keluhan) # Jenis (Terapi / Jenis) # Kapan # Status Sembuh
        Dim Tdetailhasil() As String = _hasil.Split("#")
        If _hasil.Contains("#") = True Then
            _hasil = Tdetailhasil(0)
            _dimana = Tdetailhasil(1)
            _kenapa = Tdetailhasil(2)
            _jenis = Tdetailhasil(3)
            _kapan = Tdetailhasil(4)
            _statusSembuh = Tdetailhasil(5)
        End If

        ' Set parameter update
        Dim parameterUpdate As String = ""
        parameterUpdate = "dimana = '" & _dimana & "'," & _
                          "kenapa = '" & _kenapa & "'," & _
                          "jenis = '" & _jenis & "'," & _
                          "kapan = '" & _kapan & "'," & _
                          "Result = '" & _hasil & "'," & _
                          "StatusSembuh = " & _statusSembuh & "," & _
                          "UpdateBy = '" & UserLabAdminOnline & "'," & _
                          "UpdateDate = NOW()"

        WriteThemysql("UPDATE transaksilabfisik SET " & parameterUpdate & " WHERE NoUrut='" & TextBoxNoTransaksi.Text & "' and FisikNoUrut='" & fisikID & "' and FisikKet='" & fisikKeterangan & "' and idlabinternet='" & idTransaksi & "'", DB_Poliklinik)
    End Sub

    Function GetHasilComboBox(ByVal ComboBoxString As String, ByVal TextBoxString As String) As String
        Dim keteranganHasil As String = ""

        If ComboBoxString.ToString.Contains("...") = True Then
            keteranganHasil = ComboBoxString.ToString + "~" + TextBoxString.ToString
            keteranganHasil = ValueKesimpulan(keteranganHasil)
        Else
            keteranganHasil = ComboBoxString.ToString
        End If

        Return keteranganHasil
    End Function

    Private Sub butnormallab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butnormallab.Click
        Dim Tbls As DataTable = gridlab.DataSource
        Tbls.AcceptChanges()

        For Each Rrow As DataRow In Tbls.Rows
            If IsDBNull(Rrow("Result")) = True Then Rrow("Result") = ""

            If Strings.LCase(Rrow("NamaTindakan").ToString).Contains("thorax") Or Strings.LCase(Rrow("NamaTindakan").ToString).Contains("ecg") Or Strings.LCase(Rrow("NamaTindakan").ToString).Contains("audiometri") Or Strings.LCase(Rrow("NamaTindakan").ToString).Contains("fisik") Or Strings.LCase(Rrow("NamaTindakan").ToString).Contains("usg") Or Strings.LCase(Rrow("NamaTindakan").ToString).Contains("treadmill") Or Strings.LCase(Rrow("NamaTindakan").ToString).Contains("spirometri") Then
                Rrow("Result") = "Hasil Terlampir"
            Else
                If Rrow("Result") = "" Then
                    Dim Tstr As String = ReadThemysqlNIK("select Pria from  masterlabdetail where TindakanID='" & Rrow("TindakanID") & "' and GroupID='" & Rrow("GroupID") & "' and NoUrut='" & Rrow("NoUrut") & "' and DetailKet='" & Rrow("DetailKet") & "'", DB_Poliklinik)
                    If Tstr.ToString.ToLower.Contains("non reaktif") = True Or Tstr.ToString.ToLower.Contains("reaktif") = True Or Tstr.ToString.ToLower.Contains("negatif") = True Or Tstr.ToString.ToLower.Contains("positif") = True Then
                        Rrow("Result") = Tstr
                    End If
                End If
            End If
        Next

        gridlab.DataSource = Tbls
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
            ComboBoxRiwayatRumahSakit.Focus()
        End If
    End Sub

    Private Sub txtindakanid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxNoTransaksi.KeyUp
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
            Dim Ttempat As String = ReadSQLNIK("select StrValue from MsConfig where ConfigName like '%KodePoli%'")

            If CheckThemysql("select * from transaksilab where idtempatlab = '" & Ttempat & "' and nourut='" & TextBoxNoTransaksi.Text & "'", DB_Poliklinik) = True Then
                Dim Txnourut As String = TextBoxNoTransaksi.Text
                Dim TxTransLabID As DataTable = ReadThemysql("select idlabinternet from transaksilab where idtempatlab = '" & Ttempat & "' and nourut='" & TextBoxNoTransaksi.Text & "'", DB_Poliklinik)
                LoadAdminLab(TxTransLabID(0)("idlabinternet"), Txnourut)
            End If
        End If
    End Sub

    Private Sub CetakBarcodeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CetakBarcodeToolStripMenuItem.Click
        Dim Tpos As String = ReadSQLNIK("select StrValue from MsConfig where ConfigName='PathBarcode'")
        Dim KodeBarcodeOnline As String = ReadThemysqlNIK("SELECT kodebarcode FROM mastercodebarcode WHERE kodecabang='" & kodeLokasi & "'", DB_Poliklinik)
        Dim Ttx As String = Tpos & "Output.txt"
        Dim barcode As String = ""

        If idTransaksi <> "" Then
            Try
                Dim TblsDetail As DataTable = ReadThemysql("select distinct TindakanID from transaksilabdetail WHERE idlabinternet='" & idTransaksi & "'", DB_Poliklinik)

                Dim Tstr As String = ""
                Dim TtempDetail As String = "("

                If TblsDetail.Rows.Count > 0 Then
                    For Each Trow As DataRow In TblsDetail.Rows
                        TtempDetail = TtempDetail & "'" & Trow("TindakanID").ToString.Trim & "',"
                    Next
                    Tstr = Strings.Left(TtempDetail, TtempDetail.Length - 1) & ")"
                End If

                'Dim Tgrouping As DataTable = ReadSQL("select distinct Tabung,TabungRef from MasterLab where TindakanID in " & Tstr & " and TabungRef is not null and Tabung like '%tabung%' order by Tabung ")
                Dim Tgrouping As DataTable = ReadSQL("select distinct Tabung,TabungRef from MasterLab where TindakanID in " & Tstr & " order by Tabung ")

                If Tgrouping.Rows.Count > 0 Then

                    Dim Ttemp As String = ""
                    If TextBoxNoTransaksi.Text.ToString.Contains("L") = True Then
                        Ttemp = Strings.Replace(TextBoxNoTransaksi.Text, "L", "8")
                    ElseIf TextBoxNoTransaksi.Text.ToString.Contains("M") = True Then
                        Ttemp = Strings.Replace(TextBoxNoTransaksi.Text, "M", "9")
                    End If

                    For Each Treply As DataRow In Tgrouping.Rows
                        If System.IO.File.Exists(Ttx) = True Then System.IO.File.Delete(Ttx)

                        Dim objStreamWriter As StreamWriter
                        objStreamWriter = New StreamWriter(Ttx)

                        objStreamWriter.WriteLine("<xpml><page quantity='0' pitch='29.3 mm'></xpml>I8,A")
                        objStreamWriter.WriteLine("ZN")
                        objStreamWriter.WriteLine("q275")
                        objStreamWriter.WriteLine("S3")
                        objStreamWriter.WriteLine("O")
                        objStreamWriter.WriteLine("JF")
                        objStreamWriter.WriteLine("D9")
                        objStreamWriter.WriteLine("ZT")
                        objStreamWriter.WriteLine("Q234,B24")
                        objStreamWriter.WriteLine("KI80")
                        objStreamWriter.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='29.3 mm'></xpml>N")

                        barcode = KodeBarcodeOnline & Strings.Right(Ttemp.ToString.Trim, Len(Ttemp.ToString.Trim) - 2)

                        If Treply("TabungRef").ToString <> "" Then
                            objStreamWriter.WriteLine("B290,177,2,1,2,4,97,N,""" & barcode & Treply("TabungRef").ToString & """")
                        Else
                            objStreamWriter.WriteLine("B290,177,2,1,2,4,97,N,""" & barcode & """")
                        End If
                        objStreamWriter.WriteLine("A95,217,2,3,1,1,N,""""""")
                        objStreamWriter.WriteLine("A95,30,2,3,1,1,N,""" & Treply("Tabung").ToString & """")
                        objStreamWriter.WriteLine("A290,54,2,2,1,1,N,""" & TextBoxNamaPasien.Text & """")
                        objStreamWriter.WriteLine("A290,30,2,2,1,1,N,""" & DateTimeTanggalLahir.Value & " / " & TextBoxJenisKelamin.Text & """")

                        If Treply("TabungRef").ToString <> "" Then
                            objStreamWriter.WriteLine("A290,217,2,3,1,1,N,""" & barcode & Treply("TabungRef") & """")
                        Else
                            objStreamWriter.WriteLine("A290,217,2,3,1,1,N,""" & barcode & """")
                        End If

                        objStreamWriter.WriteLine("P1")
                        objStreamWriter.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
                        objStreamWriter.Close()
                        Dim Tpathprf As String = ReadSQLNIK("select StrValue from MsConfig where ConfigName='Pathprf'")
                        Process.Start(Tpathprf & "PrFile32.exe ", Ttx)
GoBackthis:
                        If MsgBox("Wait... Melanjutkan print Barcode ?", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then
                            'GoTo GoBackthis
                            Exit Sub
                        End If
                    Next
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If

JumpSystem:
        Exit Sub
NextSystem:
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TextBoxNoTransaksi.Text <> "" Then
            If CheckedListBox1.GetItemChecked(0) Then PrintSementaraToolStripMenuItem_Click(sender, e)
            If CheckedListBox1.GetItemChecked(1) Then butprintthorax_Click(sender, e)
            If CheckedListBox1.GetItemChecked(2) Then ButtonPrintECG_Click(sender, e)
            If CheckedListBox1.GetItemChecked(3) Then butprintaudio_Click(sender, e)
            If CheckedListBox1.GetItemChecked(4) Then butprintusg_Click(sender, e)
            If CheckedListBox1.GetItemChecked(5) Then butprinttreadmill_Click(sender, e)
            If CheckedListBox1.GetItemChecked(6) Then butprintspiro_Click(sender, e)
            If CheckedListBox1.GetItemChecked(7) Then ButtonSimpanFisik_Click(sender, e)
            If CheckedListBox1.CheckedItems.Count > 0 Then MsgBox("Data Telah Tercetak Semua!", MsgBoxStyle.Information, "Success")
        Else
            MsgBox("Tidak ada data yang akan dicetak!", MsgBoxStyle.Critical, "Warning")
        End If
    End Sub

    Private Sub txtindakanid_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxNoTransaksi.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim nourut As String = TextBoxNoTransaksi.Text
            Dim KodeCabangOnline As String = ""
            Dim counttransid As String = nourut.Length()
            Dim newnourut As String = ""
            Dim translabid As String = ""
            Dim bagian1 As String = ""
            Dim bagian2 As String = ""
            Dim bagian3 As String = ""

            'jumlah 12 lab biasa, jumlah 15 mcu
            If counttransid = 12 Then 'Offline
                MsgBox("Masukkan Kode Barcode 15 Digit")
                'If Strings.Mid(nourut, 7, 1) = "8" Then
                '    bagian1 = Strings.Mid(nourut, 1, 6)
                '    bagian2 = "L"
                '    bagian3 = Strings.Mid(nourut, 8, 5)
                '    newnourut = "20" & bagian1 & bagian2 & bagian3
                '    'MsgBox(newnourut)
                'ElseIf Strings.Mid(nourut, 7, 1) = "9" Then
                '    bagian1 = Strings.Mid(nourut, 1, 6)
                '    bagian2 = "M"
                '    bagian3 = Strings.Mid(nourut, 8, 5)
                '    newnourut = "20" & bagian1 & bagian2 & bagian3
                '    'MsgBox(newnourut)
                'Else
                '    MsgBox("Data tidak ditemukan")
                '    Exit Sub
                'End If
            ElseIf counttransid = 15 Then 'Online
                KodeCabangOnline = ReadThemysqlNIK("SELECT kodecabang FROM mastercodebarcode WHERE kodebarcode='" & Strings.Left(nourut, 3) & "'", DB_Poliklinik)
                If Strings.Mid(nourut, 10, 1) = "8" Then
                    bagian1 = Strings.Mid(nourut, 4, 6)
                    bagian2 = "L"
                    bagian3 = Strings.Mid(nourut, 11, 8)
                    newnourut = Strings.Left(DateAndTime.Now.Year, 2) & bagian1 & bagian2 & bagian3
                    'MsgBox(newnourut)
                ElseIf Strings.Mid(nourut, 10, 1) = "9" Then
                    bagian1 = Strings.Mid(nourut, 4, 6)
                    bagian2 = "M"
                    bagian3 = Strings.Mid(nourut, 11, 8)
                    newnourut = Strings.Left(DateAndTime.Now.Year, 2) & bagian1 & bagian2 & bagian3
                    'MsgBox(newnourut)
                Else
                    MsgBox("Data tidak ditemukan")
                    Exit Sub
                End If
            ElseIf counttransid = 14 Then 'NoUrut Bukan Barcode
                newnourut = nourut
            Else
                MessageBox.Show("Periksa lagi ID transaksinya", "Data Tidak Ditemukan")
                Exit Sub
            End If

            translabid = ReadThemysqlNIK("select idlabinternet from transaksilab where idtempatlab='" & KodeCabangOnline & "' and nourut='" & newnourut & "'", DB_Poliklinik)

            If translabid.Length > 0 And translabid <> "-" Then
                Me.LoadAdminLab(translabid, newnourut)
            Else
                MsgBox("Data tidak ditemukan")
            End If
        End If
    End Sub

    Private Sub butsavelab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butsavelab.Click
        If idTransaksi = "" Then
            MsgBox("Pilih Pasien Terlebih Dahulu")
        Else
            If Checking() = True Then
                Dim CountReultEmpty As Integer = 0
                Dim Tbls As DataTable = gridlab.DataSource
                Tbls.AcceptChanges()

                For Each Trownew As DataRow In Tbls.Rows
                    If (Trownew("Result").ToString.Trim = "" Or Trownew("Result").ToString.Trim = "-") And Trownew("DetailKet").ToString.Trim <> "SEDIMEN :" And Trownew("DetailKet").ToString.Trim <> "Lain-lain" And Trownew("DetailKet").ToString.Trim <> "Makros" Then
                        CountReultEmpty = CountReultEmpty + 1
                    End If

                    If Strings.LCase(Trownew("NamaTindakan").ToString).Contains("thorax") Or Strings.LCase(Trownew("NamaTindakan").ToString).Contains("ecg") Or Strings.LCase(Trownew("NamaTindakan").ToString).Contains("audiometri") Or Strings.LCase(Trownew("NamaTindakan").ToString).Contains("fisik") Or Strings.LCase(Trownew("NamaTindakan").ToString).Contains("usg") Or Strings.LCase(Trownew("NamaTindakan").ToString).Contains("treadmill") Or Strings.LCase(Trownew("NamaTindakan").ToString).Contains("spirometri") Then
                        WriteThemysql("update transaksilabresult set Result='" & Trownew("Result") & "' , Keterangan='-'  where idlabinternet = '" & idTransaksi & "' and TransLabIDDetail='" & Trownew("TransLabIDDetail") & "' and TindakanID='" & Trownew("TindakanID") & "' and GroupID='" & Trownew("GroupID") & "' and NoUrut='" & Trownew("NoUrut") & "' and DetailKet='" & Trownew("DetailKet") & "'", DB_Poliklinik)
                    Else
                        WriteThemysql("update transaksilabresult set acc1=CONCAT('" & UserLabAdminOnline & "',';',now()) ,acc2=CONCAT('BYPASS;',now()), Result='" & Trownew("Result") & "' , Keterangan='" & Trownew("Keterangan") & "', Saran='" & Trownew("Saran") & "', Pria='" & Trownew("Pria") & "' , Wanita='" & Trownew("Wanita") & "' , Satuan='" & Trownew("Satuan") & "' , Urutan='" & Trownew("Urutan") & "' where idlabinternet = '" & idTransaksi & "' and TransLabIDDetail='" & Trownew("TransLabIDDetail") & "' and TindakanID='" & Trownew("TindakanID") & "' and GroupID='" & Trownew("GroupID") & "' and NoUrut='" & Trownew("NoUrut") & "' and DetailKet='" & Trownew("DetailKet") & "'", DB_Poliklinik)
                    End If
                Next

                If CheckThemysql("select * from transaksilab where idlabinternet='" & idTransaksi & "' and status='CHECK'", DB_Poliklinik) = True And CountReultEmpty = 0 Then
                    WriteThemysql("update transaksilab set saran='" & txsaranall.Text & "', kesimpulan='" & txketall.Text & "', status='CETAK',  labstarttime=now(), labendtime=now(), tglinputhasil=now() where idlabinternet='" & idTransaksi & "'", DB_Poliklinik)
                    chkclosed.Checked = True
                    MsgBox("Berhasil menyimpan data.", MsgBoxStyle.Information, "Success!")
                ElseIf CountReultEmpty > 0 Then
                    WriteThemysql("update transaksilab set saran='" & txsaranall.Text & "', kesimpulan='" & txketall.Text & "' where idlabinternet='" & idTransaksi & "'", DB_Poliklinik)
                    MsgBox("Berhasil menyimpan data & terdapat " & CountReultEmpty & " hasil belum terisi.", MsgBoxStyle.Information, "Success!")
                ElseIf CountReultEmpty = 0 Then
                    WriteThemysql("update transaksilab set saran='" & txsaranall.Text & "', kesimpulan='" & txketall.Text & "' where idlabinternet='" & idTransaksi & "'", DB_Poliklinik)
                    chkclosed.Checked = True
                    MsgBox("Berhasil menyimpan data.", MsgBoxStyle.Information, "Success!")
                End If

                ' Aktifkan Jika Ingin ada QR Code
                SavePDFtoPath()

                'If CheckThemysql("select * from transaksilab WHERE idlabinternet = '" & txidinternet.Text.Trim & "' AND (caraambil LIKE '%Ambil%' OR caraambil LIKE '%Kirim%')", DB_Poliklinik) = True And CountReultEmpty = 0 Then
                '    If HardcopyCompany(txidinternet.Text, "Online") = True Then
                '        PrintSementaraToolStripMenuItem.PerformClick()
                '    Else
                '        PreviewHasilLabToolStripMenuItem.PerformClick()
                '    End If
                'ElseIf CheckThemysql("select * from transaksilab WHERE idlabinternet = '" & txidinternet.Text.Trim & "' AND (caraambil LIKE '%Email%' OR caraambil LIKE '%Whatsapp%')", DB_Poliklinik) = True And CountReultEmpty = 0 Then
                '    PreviewHasilLabToolStripMenuItem.PerformClick()
                'End If
            End If
        End If
    End Sub

    Private Sub SavePDFtoPath()
        Dim TempWhatsapp As String = ""
        Dim TempEmail As String = ""
        Dim CountResultEmpty As Integer = 0
        NoWhatsappCompany = ""
        NoWhatsappMarketing = ""
        NoWhatsappCustomer = ""
        EmailCompany = ""
        EmailCustomer = ""

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

        Dim Tlab As DataTable = ReadThemysql("SELECT a.SendingWhatsapp, a.SendingEmail, a.Kesimpulan, a.Saran, b.PTNIK, a.caraambil, a.dokterrequest " & _
                                             "FROM transaksilab a " & _
                                             "LEFT JOIN masterpasien b ON a.idpasien=b.nomitra AND a.idtempatlab=b.cabang " & _
                                             "WHERE a.idlabinternet='" & idTransaksi & "' AND a.idtempatlab='" & kodeLokasi & "'", DB_Poliklinik)
        Dim TrowLab As DataRow = Tlab.Rows(0)
        Dim Tsimpul As String = ""
        Dim Tsaran As String = ""
        Dim noNIK As String = ""
        Dim Pengirim As String = ""
        If IsDBNull(TrowLab("PTNIK")) = False Then noNIK = TrowLab("PTNIK") Else noNIK = "-"
        Dim DrRequest As String = TrowLab("dokterrequest")
        Dim caraambil As String = TrowLab("caraambil")
        If CheckSQL("SELECT * FROM mastercompany WHERE NoCompany = '" & txcodepenagihan.Text.Trim & "' AND ReportHasilPerusahaan = 0") = True And TextBoxNoTransaksi.Text.Contains("M") = True Then
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
            Trow("barcodenotrans") = idTransaksi
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
            Trow("NoTransaksi") = TextBoxNoTransaksi.Text & " (" & idTransaksi & ")"
            Trow("DrPelaksana") = DrPelaksanaKlinik
            Trow("Hasil") = caraambil

            If Pengirim <> "" Then
                Trow("DrRequest") = Pengirim
            Else
                If IsNumeric(DrRequest.ToString.Trim) = True Or DrRequest.ToString.Trim = "" Or TextBoxNoTransaksi.Text.Contains("M") Then
                    Trow("DrRequest") = txpenagihan.Text.Trim
                Else
                    Trow("DrRequest") = DrRequest
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

        'If CountResultEmpty = Tbls.Rows.Count Then
        '    MsgBox("Input hasil terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
        '    Exit Sub
        'End If

        Report = New XtraReport
        Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\Hasil\HasilLabKop.repx", True)
        Report.Bands.Item(BandKind.ReportFooter).Controls("ttd").Visible = True
        Report.Bands.Item(BandKind.ReportFooter).Controls("ttd").Height = 134
        Report.Bands.Item(BandKind.ReportFooter).Controls("ttd").Width = 250

        Report.DataSource = Tbls
        Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MM-yyyy HH:mm:ss") + " by " + UserLabAdminOnline

        Report.Bands(BandKind.PageFooter).Controls.Add(CreateXRPictureBox(70, 0, 160, 85))
        Report.Bands.Item(BandKind.PageFooter).Controls("QR_Hasil").BringToFront()

        'If CountResultEmpty = 0 Then
        '    WriteThemysql("update transaksilab set tglcetakhasil=now(), labcetak=now() , Status='TAKEIT' , usercetakhasil='" & UserLabAdminOnline & "' ,closedinputhasil=1 where idlabinternet='" & txidinternet.Text & "'", DB_Poliklinik)
        'End If

        Dim NameFile As String = TextBoxNoTransaksi.Text & "_Hasil_Laboratorium_" & idTransaksi.Trim
        Dim filepath As String = "FileDownload\Hasil_Online\" & NameFile & ".pdf"

        'If CheckThemysql("select * from LogSendingWhatsappEmail where Cabang='" & kodeLokasi.Trim & "' and (SendingJenis='Whatsapp' or SendingJenis='Email') and NoUrut = '" & txtindakanid.Text.Trim & "'", DB_Poliklinik) = True Then
        '    If MsgBox("Hasil sudah pernah dikirim ke email/Whatsapp tersebut, apakah tetap dilanjutkan?", MsgBoxStyle.YesNo, "Question.") = MsgBoxResult.No Then
        '        MsgBox("Batal mengirimkan email.", MsgBoxStyle.Exclamation, "Warning!")
        '        Exit Sub
        '    End If
        'End If

        If File.Exists(filepath) = True Then
            My.Computer.FileSystem.DeleteFile("FileDownload\Hasil_Online\" & NameFile & ".pdf")
        End If
        Report.CreatePdfDocument("FileDownload\Hasil_Online\" & NameFile & ".pdf")

        'Set Nama File di Online
        Dim KodeBarcode As String = ReadThemysqlNIK("SELECT a.kodebarcode FROM mastercodebarcode a WHERE a.kodecabang = '" & kodeLokasi & "'", DB_Poliklinik)
        Dim txQR As String = KodeBarcode & NameFile

        'CreateBase64
        Dim Base64Inv As String = ""
        Base64Inv = Convert.ToBase64String(System.IO.File.ReadAllBytes(filepath))

        'Send Base64 to Online
        WriteThemysql("REPLACE INTO QR_HasilLaboratorium (NameFile, FileBase64, createdate, createby)  " & _
                                              "VALUES('" & txQR & "', '" & Base64Inv & "', NOW(), '" & UserLabAdminOnline & "') ", DB_Poliklinik)
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
            'If Trownew("GroupID").ToString.Trim = "SARS-COV-2 S-RBD IgG" And varJenisResult <> "" And Trownew("NoUrut") = "1" Then
            '    varKonversiSatuanMindray = varJenisResult / 0.8229
            'ElseIf Trownew("GroupID").ToString.Trim = "SARS-COV-2 S-RBD IgG" And varKonversiSatuanMindray >= 0 And Trownew("NoUrut") = "2" Then
            '    Trownew("Result") = Math.Round(varKonversiSatuanMindray, 2)
            'End If

            ''SARS-CoV-2 S-RBD IgG (ARCHT)
            'If Trownew("GroupID").ToString.Trim = "SARS-CoV-2 S-RBD IgG (ARCHT)" And varJenisResult <> "" And Trownew("NoUrut") = "1" Then
            '    varKonversiSatuanArcht = varJenisResult * 0.142
            'ElseIf Trownew("GroupID").ToString.Trim = "SARS-CoV-2 S-RBD IgG (ARCHT)" And varKonversiSatuanArcht >= 0 And Trownew("NoUrut") = "2" Then
            '    Trownew("Result") = Math.Round(varKonversiSatuanArcht, 2)
            'End If

            ''SARS-CoV-2 Neutralizing Antibody (NtAb)
            'If Trownew("GroupID").ToString.Trim = "SARS-CoV-2 Neutralizing Antibody (NtAb)" And varJenisResult <> "" And Trownew("NoUrut") = "1" Then
            '    varKonversiSatuanNtAb = varJenisResult * 0.3025
            'ElseIf Trownew("GroupID").ToString.Trim = "SARS-CoV-2 Neutralizing Antibody (NtAb)" And varKonversiSatuanNtAb >= 0 And Trownew("NoUrut") = "2" Then
            '    Trownew("Result") = Math.Round(varKonversiSatuanNtAb, 2)
            'End If

            ''Creatinin (e-GFR)
            'If Trownew("GroupID").ToString.Trim = "Creatinin" And varJenisResult <> "" And Trownew("NoUrut") = "1" Then
            '    varNilaiCreatinin = varJenisResult
            'ElseIf Trownew("GroupID").ToString.Trim = "Creatinin" And varNilaiCreatinin >= 0 And Trownew("NoUrut") = "2" Then
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
                Dim TblsSaran As DataTable = ReadSQL("select * from MasterLabdetailBaru where TindakanID='" & Trownew("TindakanID") & "' and GroupID='" & Trownew("GroupID") & "' and NoUrut='" & Trownew("NoUrut") & "' and (CONVERT(VARCHAR, PriaBatasBawah)<>'' or CONVERT(VARCHAR, PriaBatasNormal)<>'' or CONVERT(VARCHAR, PriaAmbangBatasTinggi)<>'' or CONVERT(VARCHAR, PriaBatasAtas)<>'')")
                If TblsSaran.Rows.Count > 0 Then
                    For Each Trow As DataRow In TblsSaran.Rows
                        varResult = Strings.Replace(varJenisResult, ",", ".")
                        For Each element As String In ArrayResult
                            varResultDBString = ReadSQLNIK("select " + element + " from MasterLabdetailBaru where TindakanID='" & Trownew("TindakanID") & "' and GroupID='" & Trownew("GroupID") & "' and NoUrut='" & Trownew("NoUrut") & "' and (CONVERT(VARCHAR, PriaBatasBawah)<>'' or CONVERT(VARCHAR, PriaBatasNormal)<>'' or CONVERT(VARCHAR, PriaAmbangBatasTinggi)<>'' or CONVERT(VARCHAR, PriaBatasAtas)<>'')")
                            varKetDB = ReadSQLNIK("select " + "Ket" + element + " from MasterLabdetailBaru where TindakanID='" & Trownew("TindakanID") & "' and GroupID='" & Trownew("GroupID") & "' and NoUrut='" & Trownew("NoUrut") & "' and (CONVERT(VARCHAR, PriaBatasBawah)<>'' or CONVERT(VARCHAR, PriaBatasNormal)<>'' or CONVERT(VARCHAR, PriaAmbangBatasTinggi)<>'' or CONVERT(VARCHAR, PriaBatasAtas)<>'')")
                            varSaranDB = ReadSQLNIK("select " + "Saran" + element + " from MasterLabdetailBaru where TindakanID='" & Trownew("TindakanID") & "' and GroupID='" & Trownew("GroupID") & "' and NoUrut='" & Trownew("NoUrut") & "' and (CONVERT(VARCHAR, PriaBatasBawah)<>'' or CONVERT(VARCHAR, PriaBatasNormal)<>'' or CONVERT(VARCHAR, PriaAmbangBatasTinggi)<>'' or CONVERT(VARCHAR, PriaBatasAtas)<>'')")
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
                Dim TblsNonAngka As DataTable = ReadSQL("select * from MasterLabdetailBaru where TindakanID='" & Trownew("TindakanID") & "' and GroupID='" & Trownew("GroupID") & "' and NoUrut='" & Trownew("NoUrut") & "' and (CONVERT(VARCHAR, PriaReaktif)<>'' or CONVERT(VARCHAR, WanitaReaktif)<>'' or CONVERT(VARCHAR, PriaNonReaktif)<>'' or CONVERT(VARCHAR, WanitaNonReaktif)<>'')")
                If TblsNonAngka.Rows.Count > 0 Then
                    Dim TrowNonAngka As DataRow = TblsNonAngka.Rows(0)
                    If TextBoxJenisKelamin.Text = "L" Then
                        If CheckSQL("select * from MasterLabdetailBaru where TindakanID='" & Trownew("TindakanID") & "' and GroupID='" & Trownew("GroupID") & "' and NoUrut='" & Trownew("NoUrut") & "' and (CONVERT(VARCHAR, PriaReaktif) = '" & varJenisResult & "')") = True Then
                            Trownew("Saran") = TrowNonAngka("SaranPriaReaktif").ToString
                            Trownew("Keterangan") = TrowNonAngka("KetPriaReaktif").ToString

                            totalKetReaktif = totalKetReaktif + 1
                            If totalKetReaktif > 1 Then
                                displayKeteranganReaktif = displayKeteranganReaktif + spasi + Trownew("DetailKet") + " : " + TrowNonAngka("KetPriaReaktif").ToString + vbCrLf
                            Else
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
                        ElseIf CheckSQL("select * from MasterLabdetailBaru where TindakanID='" & Trownew("TindakanID") & "' and GroupID='" & Trownew("GroupID") & "' and NoUrut='" & Trownew("NoUrut") & "' and (CONVERT(VARCHAR, PriaNonReaktif) = '" & varJenisResult & "')") = True Then
                            Trownew("Saran") = TrowNonAngka("SaranPriaNonReaktif").ToString
                            Trownew("Keterangan") = TrowNonAngka("KetPriaNonReaktif").ToString

                            totalKetNonReaktif = totalKetNonReaktif + 1
                            If totalKetNonReaktif > 1 Then
                                displayKeteranganNonReaktif = displayKeteranganNonReaktif + spasi + Trownew("DetailKet") + " : " + TrowNonAngka("KetPriaNonReaktif").ToString + vbCrLf
                            Else
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
                        If CheckSQL("select * from MasterLabdetailBaru where TindakanID='" & Trownew("TindakanID") & "' and GroupID='" & Trownew("GroupID") & "' and NoUrut='" & Trownew("NoUrut") & "' and (CONVERT(VARCHAR, WanitaReaktif) = '" & varJenisResult & "')") = True Then
                            Trownew("Saran") = TrowNonAngka("SaranWanitaReaktif").ToString
                            Trownew("Keterangan") = TrowNonAngka("KetWanitaReaktif").ToString

                            totalKetReaktif = totalKetReaktif + 1
                            If totalKetReaktif > 1 Then
                                displayKeteranganReaktif = displayKeteranganReaktif + spasi + Trownew("DetailKet") + " : " + TrowNonAngka("KetWanitaReaktif").ToString + vbCrLf
                            Else
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
                        ElseIf CheckSQL("select * from MasterLabdetailBaru where TindakanID='" & Trownew("TindakanID") & "' and GroupID='" & Trownew("GroupID") & "' and NoUrut='" & Trownew("NoUrut") & "' and (CONVERT(VARCHAR, WanitaNonReaktif) = '" & varJenisResult & "')") = True Then
                            Trownew("Saran") = TrowNonAngka("SaranWanitaNonReaktif").ToString
                            Trownew("Keterangan") = TrowNonAngka("KetWanitaNonReaktif").ToString

                            totalKetNonReaktif = totalKetNonReaktif + 1
                            If totalKetNonReaktif > 1 Then
                                displayKeteranganNonReaktif = displayKeteranganNonReaktif + spasi + Trownew("DetailKet") + " : " + TrowNonAngka("KetWanitaNonReaktif").ToString + vbCrLf
                            Else
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
                Else
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
                Else
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
            MsgBox("Tidak ada data yang diupdate, periksa result yang diinput atau kosongi kolom saran/keterangan terlebih dahulu.")
        End If
    End Sub

    Function CreateTable() As DataTable
        Dim Thasil As New DataTable

        insertRowToTbls(Thasil, "Typstring", "nama")
        insertRowToTbls(Thasil, "Typstring", "tgllahir")
        insertRowToTbls(Thasil, "Typstring", "PTNIK")
        insertRowToTbls(Thasil, "Typstring", "alamat")
        insertRowToTbls(Thasil, "Typstring", "companynama")
        insertRowToTbls(Thasil, "Typstring", "txidcust")

        Return Thasil
    End Function

    Private Sub CetakLabelMenuStrip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CetakLabelMenuStrip.Click
        Dim Tpoli As DataTable = CreateTable()

        'Dim Tbls As DataTable = ReadThemysql("SELECT a.nomitra, b.nourut, a.nama, a.sex, DATE(a.tgllahir) AS tgllahir, a.PTNIK, a.alamat, c.nojenisbayar AS companynama FROM masterpasien a  LEFT JOIN transaksilab b ON b.idpasien=a.nomitra AND a.cabang = b.idtempatlab LEFT JOIN transaksilabbayar c ON b.idlabinternet=c.idlabinternet WHERE b.idtempatlab='U006' AND DATE(b.tgllab) = '20211205' AND b.DetailPemeriksaan <> 'HBA 1 C' AND b.DetailPemeriksaan <> 'HBsAg (GLOW-CLIA)' AND b.nourut BETWEEN '20211205M00056' AND '20211205M00438' ORDER BY b.nourut ASC", DB_Poliklinik)
        Dim Tbls As DataTable = ReadThemysql("SELECT a.nomitra, b.dokterrequest, b.nourut, a.nama, a.sex, DATE(a.tgllahir) AS tgllahir, a.PTNIK, a.alamat, c.nojenisbayar AS companynama" & _
                                             " FROM masterpasien a " & _
                                             " LEFT JOIN transaksilab b ON b.idpasien=a.nomitra " & _
                                             " LEFT JOIN transaksilabbayar c ON b.idlabinternet=c.idlabinternet" & _
                                             " WHERE a.nomitra='" & TextBoxNoRekamMedis.Text & "' AND b.idtempatlab='" & kodeLokasi & "'  AND b.idlabinternet = '" & idTransaksi & "'" & _
                                             " LIMIT 1", DB_Poliklinik)
        If Tbls.Rows.Count > 0 Then
            For Each Trow As DataRow In Tbls.Rows
                Dim Tnew As DataRow = Tpoli.NewRow
                If Trow("PTNIK").ToString.Trim = "" Or Trow("PTNIK").ToString.Trim = "-" Or Trow("PTNIK") = "NULL" Then
                    Tnew("nama") = Trow("nama").ToString.Trim.ToUpper
                Else
                    Tnew("nama") = Trow("nama").ToString.Trim.ToUpper & " / " & Trow("PTNIK")
                End If
                Tnew("txidcust") = Trow("nomitra") & " / " & Trow("nourut")
                Tnew("alamat") = Trow("alamat")
                Tnew("tgllahir") = Format(Trow("tgllahir"), "dd MMM yyyy") & " / " & Umur(Trow("tgllahir")) & " (" & Trow("sex") & ")"

                Dim Tsplit() As String = Trow("companynama").ToString.Split("-")
                If Trow("nourut").ToString.Contains("M") Then
                    If Tsplit(0).ToString.Trim = "" Then
                        Tnew("companynama") = "PASIEN UMUM"
                    Else
                        Tnew("companynama") = Tsplit(0).ToString.Trim
                    End If
                Else
                    Tnew("companynama") = Trow("dokterrequest")
                End If



                Tpoli.Rows.Add(Tnew)

                Report = New XtraReport
                Report = XtraReport.FromFile(Application.StartupPath + "\reports\PrintLabelPasienOnline.repx", True)
                Report.DataSource = Tpoli

                'For i As Integer = 0 To 1
                'Report.Print()
                Report.ShowPreview()
                'Next

                Tpoli.Rows.Remove(Tnew)
            Next
        End If
    End Sub

    Private Sub cmbvisusmata_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxVisusMata1.SelectedIndexChanged
        If ComboBoxVisusMata1.SelectedIndex = 0 Then
            TextBoxVisusKacamataOD.Tag = 3012
            TextBoxVisusTanpaKacamataOD.Tag = 3013
            ComboBoxVisusMata2.SelectedIndex = 0
            ComboBoxVisusMata2.Enabled = False
        Else
            TextBoxVisusKacamataOD.Tag = 3014
            TextBoxVisusTanpaKacamataOD.Tag = 3015
            ComboBoxVisusMata2.SelectedIndex = 1
            ComboBoxVisusMata2.Enabled = False
        End If
    End Sub

    'Function GetDataHeaderReport() As DataTable
    '    Dim tblDetailPasien As New DataTable
    '    Dim queryBuilder As New StringBuilder()

    '    ' Set Table Detail Pasien
    '    insertRowToTbls(tblDetailPasien, "Typstring", "Registrasi")
    '    insertRowToTbls(tblDetailPasien, "Typstring", "Nama")
    '    insertRowToTbls(tblDetailPasien, "typstring", "Umur")
    '    insertRowToTbls(tblDetailPasien, "typstring", "Alamat")
    '    insertRowToTbls(tblDetailPasien, "typstring", "NoTransaksi")
    '    insertRowToTbls(tblDetailPasien, "typstring", "DrPelaksana")
    '    insertRowToTbls(tblDetailPasien, "typstring", "DrRequest")
    '    insertRowToTbls(tblDetailPasien, "typstring", "Tanggal")
    '    insertRowToTbls(tblDetailPasien, "typstring", "Hasil")
    '    insertRowToTbls(tblDetailPasien, "typstring", "Saran")
    '    insertRowToTbls(tblDetailPasien, "typstring", "Kesimpulan")
    '    insertRowToTbls(tblDetailPasien, "typstring", "InfoCetak")
    '    insertRowToTbls(tblDetailPasien, "typstring", "NomorIzinKlinik")

    '    ' Query Transaksi
    '    queryBuilder.AppendLine("SELECT b.alamat, a.idpasien, a.SendingWhatsapp, a.SendingEmail, a.Kesimpulan, a.Saran, b.PTNIK, a.caraambil, a.dokterrequest")
    '    queryBuilder.AppendLine("FROM transaksilab a")
    '    queryBuilder.AppendLine("     LEFT JOIN masterpasien b ON a.idpasien=b.nomitra AND a.idtempatlab=b.cabang")
    '    queryBuilder.AppendLine("WHERE idlabinternet='" & idTransaksi & "' AND idtempatlab='" & kodeLokasi & "'")

    '    Dim tblTransaksi As DataTable = ReadThemysql(queryBuilder.ToString(), DB_Poliklinik)
    '    Dim rowTransaksi As DataRow = tblTransaksi.Rows(0)

    '    ' Set No Rekam Medis Pasien
    '    Dim noRekamMedisPasien As String = rowTransaksi("idpasien")

    '    ' Set Nama Pasien
    '    Dim namaPasien As String = ""

    '    If IsDBNull(rowTransaksi("PTNIK")) = False AndAlso rowTransaksi("PTNIK").ToString <> "-" And rowTransaksi("PTNIK").ToString <> "" Then
    '        namaPasien = TextBoxGelar.Text & " " & TextBoxNama.Text & " / " & rowTransaksi("PTNIK") & " (" & TextBoxJenisKelamin.Text & ")" & vbCrLf
    '    Else
    '        namaPasien = TextBoxGelar.Text & " " & TextBoxNama.Text & " (" & TextBoxJenisKelamin.Text & ")" & vbCrLf
    '    End If

    '    ' Set Umur Pasien
    '    Dim umurPasien As String = ""
    '    Dim Tgltemp As Date = DateTimeTanggalLahir.Value
    '    If Tgltemp.Date.AddYears(120).Year > DateAndTime.Now.Year Then
    '        umurPasien = Format(DateTimeTanggalLahir.Value, "dd MMM yyyy") & " / " & TextBoxUmur.Text
    '    End If

    '    ' Set Alamat Pasien
    '    Dim alamatPasien As String = rowTransaksi("alamat")

    '    ' Set No Transaksi Pasien
    '    Dim noTransaksiPasien As String = TextBoxNoTransaksi.Text & " (" & idTransaksi & ")"

    '    ' Set Dokter Pengirim
    '    Dim dokterPengirimPasien As String = ""

    '    If txcodepenagihan.Text <> "-" Then
    '        If CheckSQL("SELECT * FROM mastercompany WHERE NoCompany = '" & txcodepenagihan.Text.Trim & "' AND ReportHasilPerusahaan = 0") = True Then
    '            dokterPengirimPasien = "Atas Permintaan Sendiri"
    '        Else
    '            dokterPengirimPasien = txpenagihan.Text
    '        End If
    '    Else
    '        dokterPengirimPasien = rowTransaksi("dokterrequest")
    '    End If

    '    Dim TempWhatsapp As String = ""
    '    Dim TempEmail As String = ""

    '    ' Set Metode Kirim Hasil
    '    Dim metodeKirimHasilPasien As String = rowTransaksi("caraambil")

    '    If IsDBNull(rowTransaksi("SendingWhatsapp")) = False And rowTransaksi("SendingWhatsapp").ToString.Trim <> "-" And rowTransaksi("SendingWhatsapp").ToString.Trim <> "" Then
    '        NoWhatsappCustomer = rowTransaksi("SendingWhatsapp")
    '        TempWhatsapp = NoWhatsappCustomer.Substring(0, 3) & "*****" & NoWhatsappCustomer.Substring(8, NoWhatsappCustomer.Length - 8)
    '        metodeKirimHasilPasien = metodeKirimHasilPasien.Replace(NoWhatsappCustomer, TempWhatsapp)
    '    Else
    '        NoWhatsappCustomer = "-"
    '    End If

    '    If IsDBNull(rowTransaksi("SendingEmail")) = False And rowTransaksi("SendingEmail").ToString.Trim <> "-" Then
    '        EmailCustomer = rowTransaksi("SendingEmail")
    '        TempEmail = EmailCustomer.Substring(0, 3) & "*****" & EmailCustomer.Substring(8, EmailCustomer.Length - 8)
    '        metodeKirimHasilPasien = metodeKirimHasilPasien.Replace(EmailCustomer, TempEmail)
    '    Else
    '        EmailCustomer = "-"
    '    End If

    '    ' Set Kesimpulan & Saran
    '    Dim saranHasilPasien As String = ""
    '    Dim kesimpulanHasilPasien As String = ""

    '    If IsDBNull(rowTransaksi("Saran")) = False Then saranHasilPasien = rowTransaksi("Saran")
    '    If IsDBNull(rowTransaksi("Kesimpulan")) = False Then kesimpulanHasilPasien = rowTransaksi("Kesimpulan")

    '    ' Add Detail Pasien
    '    Dim newDetail As DataRow = tblDetailPasien.NewRow
    '    newDetail("Registrasi") = noRekamMedisPasien
    '    newDetail("Nama") = namaPasien
    '    newDetail("Umur") = umurPasien
    '    newDetail("Alamat") = alamatPasien
    '    newDetail("NoTransaksi") = noTransaksiPasien
    '    newDetail("DrPelaksana") = DrPelaksanaKlinik
    '    newDetail("DrRequest") = dokterPengirimPasien
    '    newDetail("Tanggal") = Format(DateTimeTanggalTransaksi.Value, "dd-MMM-yyyy")
    '    newDetail("Hasil") = metodeKirimHasilPasien
    '    newDetail("Saran") = saranHasilPasien
    '    newDetail("Kesimpulan") = kesimpulanHasilPasien
    '    newDetail("InfoCetak") = Format(DateAndTime.Now, "dd-MM-yyyy HH:mm:ss") + " by " + UserLabAdminOnline
    '    newDetail("NomorIzinKlinik") = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NomorIjinLab'")
    '    tblDetailPasien.Rows.Add(newDetail)

    '    Return tblDetailPasien
    'End Function

    Function GetDataDetailPemeriksaan() As DataTable
        Dim tblDetailPemeriksaan As New DataTable
        Dim queryBuilder As New StringBuilder()

        ' Set Table Detail
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PemeriksaanTinggiBadan")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PemeriksaanBeratBadan")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PemeriksaanDetakNadi")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PemeriksaanSuhu")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PemeriksaanNafas")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PemeriksaanTensi")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PemeriksaanBMI")

        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "RiwayatOperasi")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "RiwayatRumahSakit")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "RiwayatPengobatanPenyakit")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "RiwayatPenggunaanNarkoba")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "RiwayatKondisiSehat")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "RiwayatPenyakitKeluarga")

        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "KebiasaanRokok")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "KebiasaanAlkohol")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "KebiasaanKopi")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "KebiasaanPolaMakan")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "KebiasaanPolaIstirahat")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "KebiasaanOlahraga")

        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PenyakitHepatitis")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PenyakitTBC")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PenyakitHernia")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PenyakitHipertensi")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PenyakitEpilepsi")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PenyakitDiabetesMellitus")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PenyakitParuNonTBC")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PenyakitSakitJantung")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PenyakitGangguanKulit")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PenyakitMalaria")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PenyakitAmbeien")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PenyakitTHT")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PenyakitKencingBatu")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PenyakitVertigo")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PenyakitAnorexia")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PenyakitPingsan")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PenyakitGastritis")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PenyakitPusing")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PenyakitTypoidFever")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "PenyakitTurunBB")

        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "KesimpulanFisik")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "SaranFisik")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "SaranFisikTitikDuaLabel")
        insertRowToTbls(tblDetailPemeriksaan, "Typstring", "SaranFisikKeteranganLabel")

        ' Query Transaksi
        queryBuilder.AppendLine("SELECT a.*")
        queryBuilder.AppendLine("FROM transaksilabfisik a")
        queryBuilder.AppendLine("LEFT JOIN transaksilab b ON a.idlabinternet = b.idlabinternet AND a.nourut = b.nourut")
        queryBuilder.AppendLine("WHERE a.idlabinternet = '" & idTransaksi & "' AND b.idtempatlab = '" & kodeLokasi & "';")

        Dim tblTransaksi As DataTable = ReadThemysql(queryBuilder.ToString(), DB_Poliklinik)

        ' Set Default Pemeriksaan Fisik Pasien
        Dim pemeriksaanTinggiBadan As Double = 0
        Dim pemeriksaanBeratBadan As Double = 0
        Dim pemeriksaanDetakNadi As String = ""
        Dim pemeriksaanSuhu As String = ""
        Dim pemeriksaanNafas As String = ""
        Dim pemeriksaanTensi As String = ""
        Dim pemeriksaanBMI As String = ""

        ' Set Default Riwayat Kesehatan Pasien
        Dim riwayatOperasi As String = ""
        Dim riwayatRumahSakit As String = ""
        Dim riwayatPengobatanPenyakit As String = ""
        Dim riwayatPenggunaanNarkoba As String = ""
        Dim riwayatKondisiSehat As String = ""
        Dim riwayatPenyakitKeluarga As String = ""

        ' Set Default Kebiasaan Pasien
        Dim kebiasaanRokok As String = ""
        Dim kebiasaanAlkohol As String = ""
        Dim kebiasaanKopi As String = ""
        Dim kebiasaanPolaMakan As String = ""
        Dim kebiasaanPolaIstirahat As String = ""
        Dim kebiasaanOlahraga As String = ""

        ' Set Default Penyakit Pasien
        Dim penyakitHepatitis As String = ""
        Dim penyakitTbc As String = ""
        Dim penyakitHernia As String = ""
        Dim penyakitHipertensi As String = ""
        Dim penyakitEpilepsi As String = ""
        Dim penyakitDiabetesMellitus As String = ""
        Dim penyakitParuNonTbc As String = ""
        Dim penyakitSakitJantung As String = ""
        Dim penyakitGangguanKulit As String = ""
        Dim penyakitMalaria As String = ""
        Dim penyakitAmbeien As String = ""
        Dim penyakitTht As String = ""
        Dim penyakitKencingBatu As String = ""
        Dim penyakitVertigo As String = ""
        Dim penyakitAnorexia As String = ""
        Dim penyakitPingsan As String = ""
        Dim penyakitGastritis As String = ""
        Dim penyakitPusing As String = ""
        Dim penyakitTypoidFever As String = ""
        Dim penyakitTurunBb As String = ""

        ' Set Default Kesimpulan & Saran
        Dim kesimpulanFisik As String = ""
        Dim saranFisik As String = ""
        Dim saranFisikTitikDuaLabel As String = ""
        Dim saranFisikKeteranganLabel As String = ""

        For Each rowTransaksi As DataRow In tblTransaksi.Rows
            'Dim fisikResult As String = Strings.Replace(Strings.Replace(rowTransaksi("result"), ".", ""), "~", "")
            Dim fisikResult As String = rowTransaksi("result")

            ' ################### Pemeriksaan Fisik ################### '
            ' Tinggi Badan
            If rowTransaksi("fisiknourut") = "1401" Then pemeriksaanTinggiBadan = fisikResult : GoTo GoBackthis

            ' Berat Badan
            If rowTransaksi("fisiknourut") = "1402" Then pemeriksaanBeratBadan = fisikResult : GoTo GoBackthis

            ' Detak Nadi
            If rowTransaksi("fisiknourut") = "3003" Then pemeriksaanDetakNadi = fisikResult : GoTo GoBackthis

            ' Suhu
            If rowTransaksi("fisiknourut") = "3002" Then pemeriksaanSuhu = fisikResult : GoTo GoBackthis

            ' Nafas
            If rowTransaksi("fisiknourut") = "3005" Then pemeriksaanNafas = fisikResult : GoTo GoBackthis

            ' Tensi
            If rowTransaksi("fisiknourut") = "3004" Then pemeriksaanTensi = fisikResult : GoTo GoBackthis

            ' ################### Riwayat Kesehatan ################### '
            ' Riwayat Operasi
            If rowTransaksi("fisiknourut") = "3058" Then
                If fisikResult = "Ya" Then
                    riwayatOperasi = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " di " & rowTransaksi("dimana") & " dengan riwayat diagnosis " & rowTransaksi("kenapa") : GoTo GoBackthis
                Else
                    riwayatOperasi = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Riwayat Rumah Sakit
            If rowTransaksi("fisiknourut") = "3029" Then
                If fisikResult = "Ya" Then
                    riwayatRumahSakit = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " di " & rowTransaksi("dimana") & " dengan riwayat diagnosis " & rowTransaksi("kenapa") : GoTo GoBackthis
                Else
                    riwayatRumahSakit = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Riwayat Pengobatan Penyakit
            If rowTransaksi("fisiknourut") = "3030" Then
                If fisikResult = "Ya" Then
                    riwayatPengobatanPenyakit = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " terapi " & rowTransaksi("jenis") & " dengan riwayat diagnosis " & rowTransaksi("kenapa") : GoTo GoBackthis
                Else
                    riwayatPengobatanPenyakit = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Riwayat Penggunaan Narkoba
            If rowTransaksi("fisiknourut") = "3031" Then
                If fisikResult = "Ya" Then
                    riwayatPenggunaanNarkoba = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " jenis " & rowTransaksi("jenis") : GoTo GoBackthis
                Else
                    riwayatPenggunaanNarkoba = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Riwayat Kondisi Sehat
            If rowTransaksi("fisiknourut") = "3032" Then
                If fisikResult = "Tidak" Then
                    riwayatKondisiSehat = fisikResult & ", keluhan " & rowTransaksi("kenapa") : GoTo GoBackthis
                Else
                    riwayatKondisiSehat = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Riwayat Penyakit Keluarga
            If rowTransaksi("fisiknourut") = "4002" Then
                If fisikResult = "Ya" Then
                    riwayatPenyakitKeluarga = fisikResult & ", " & rowTransaksi("kenapa") : GoTo GoBackthis
                Else
                    riwayatPenyakitKeluarga = fisikResult : GoTo GoBackthis
                End If
            End If

            ' ################### Kebiasaan ################### '
            ' Kebiasaan Rokok
            If rowTransaksi("fisiknourut") = "3033" Then kebiasaanRokok = fisikResult : GoTo GoBackthis

            ' Kebiasaan Alkohol
            If rowTransaksi("fisiknourut") = "3034" Then kebiasaanAlkohol = fisikResult : GoTo GoBackthis

            ' Kebiasaan Kopi
            If rowTransaksi("fisiknourut") = "3035" Then kebiasaanKopi = fisikResult : GoTo GoBackthis

            ' Kebiasaan Pola Makan
            If rowTransaksi("fisiknourut") = "3036" Then kebiasaanPolaMakan = fisikResult : GoTo GoBackthis

            ' Kebiasaan Pola Istirahat
            If rowTransaksi("fisiknourut") = "3037" Then kebiasaanPolaIstirahat = fisikResult : GoTo GoBackthis

            ' Kebiasaan Olahraga
            If rowTransaksi("fisiknourut") = "3038" Then kebiasaanOlahraga = fisikResult : GoTo GoBackthis


            ' ################### Penyakit ################### '
            ' Penyakit Hepatitis
            If rowTransaksi("fisiknourut") = "3039" Then
                If fisikResult = "Ya" Then
                    If Not IsDBNull(rowTransaksi("StatusSembuh")) AndAlso Convert.ToBoolean(rowTransaksi("StatusSembuh")) = True Then
                        penyakitHepatitis = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " " & rowTransaksi("kenapa") & " (Sembuh)" : GoTo GoBackthis
                    Else
                        penyakitHepatitis = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " " & rowTransaksi("kenapa") : GoTo GoBackthis
                    End If
                Else
                    penyakitHepatitis = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Penyakit TBC
            If rowTransaksi("fisiknourut") = "3041" Then
                If fisikResult = "Ya" Then
                    If Not IsDBNull(rowTransaksi("StatusSembuh")) AndAlso Convert.ToBoolean(rowTransaksi("StatusSembuh")) = True Then
                        penyakitTbc = fisikResult & ", " & Format(rowTransaksi("kapan"), "dd") & " " & BulanIndonesia(Format(rowTransaksi("kapan"), "MM")) & " " & Format(rowTransaksi("kapan"), "yyyy") & " (Sembuh)" : GoTo GoBackthis
                    Else
                        penyakitTbc = fisikResult & ", " & Format(rowTransaksi("kapan"), "dd") & " " & BulanIndonesia(Format(rowTransaksi("kapan"), "MM")) & " " & Format(rowTransaksi("kapan"), "yyyy") : GoTo GoBackthis
                    End If
                Else
                    penyakitTbc = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Penyakit Hernia
            If rowTransaksi("fisiknourut") = "3047" Then
                If fisikResult = "Ya" Then
                    If Not IsDBNull(rowTransaksi("StatusSembuh")) AndAlso Convert.ToBoolean(rowTransaksi("StatusSembuh")) = True Then
                        penyakitHernia = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " (Sembuh)" : GoTo GoBackthis
                    Else
                        penyakitHernia = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") : GoTo GoBackthis
                    End If
                Else
                    penyakitHernia = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Penyakit Hipertensi
            If rowTransaksi("fisiknourut") = "3050" Then
                If fisikResult = "Ya" Then
                    If Not IsDBNull(rowTransaksi("StatusSembuh")) AndAlso Convert.ToBoolean(rowTransaksi("StatusSembuh")) = True Then
                        penyakitHipertensi = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " (Sembuh)" : GoTo GoBackthis
                    Else
                        penyakitHipertensi = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") : GoTo GoBackthis
                    End If
                Else
                    penyakitHipertensi = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Penyakit Epilepsi
            If rowTransaksi("fisiknourut") = "3053" Then
                If fisikResult = "Ya" Then
                    If Not IsDBNull(rowTransaksi("StatusSembuh")) AndAlso Convert.ToBoolean(rowTransaksi("StatusSembuh")) = True Then
                        penyakitEpilepsi = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " (Sembuh)" : GoTo GoBackthis
                    Else
                        penyakitEpilepsi = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") : GoTo GoBackthis
                    End If
                Else
                    penyakitEpilepsi = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Penyakit Diabetes Mellitus
            If rowTransaksi("fisiknourut") = "3057" Then
                If fisikResult = "Ya" Then
                    If Not IsDBNull(rowTransaksi("StatusSembuh")) AndAlso Convert.ToBoolean(rowTransaksi("StatusSembuh")) = True Then
                        penyakitDiabetesMellitus = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " (Sembuh)" : GoTo GoBackthis
                    Else
                        penyakitDiabetesMellitus = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") : GoTo GoBackthis
                    End If
                Else
                    penyakitDiabetesMellitus = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Penyakit Paru Non TBC
            If rowTransaksi("fisiknourut") = "4003" Then
                If fisikResult = "Ya" Then
                    If Not IsDBNull(rowTransaksi("StatusSembuh")) AndAlso Convert.ToBoolean(rowTransaksi("StatusSembuh")) = True Then
                        penyakitParuNonTbc = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " " & rowTransaksi("kenapa") & " (Sembuh)" : GoTo GoBackthis
                    Else
                        penyakitParuNonTbc = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " " & rowTransaksi("kenapa") : GoTo GoBackthis
                    End If
                Else
                    penyakitParuNonTbc = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Penyakit Sakit Jantung
            If rowTransaksi("fisiknourut") = "3048" Then
                If fisikResult = "Ya" Then
                    If Not IsDBNull(rowTransaksi("StatusSembuh")) AndAlso Convert.ToBoolean(rowTransaksi("StatusSembuh")) = True Then
                        penyakitSakitJantung = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " " & rowTransaksi("kenapa") & " (Sembuh)" : GoTo GoBackthis
                    Else
                        penyakitSakitJantung = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " " & rowTransaksi("kenapa") : GoTo GoBackthis
                    End If
                Else
                    penyakitSakitJantung = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Penyakit Gangguan Kulit
            If rowTransaksi("fisiknourut") = "3044" Then
                If fisikResult = "Ya" Then
                    If Not IsDBNull(rowTransaksi("StatusSembuh")) AndAlso Convert.ToBoolean(rowTransaksi("StatusSembuh")) = True Then
                        penyakitGangguanKulit = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " (Sembuh)" : GoTo GoBackthis
                    Else
                        penyakitGangguanKulit = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") : GoTo GoBackthis
                    End If
                Else
                    penyakitGangguanKulit = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Penyakit Malaria
            If rowTransaksi("fisiknourut") = "3043" Then
                If fisikResult = "Ya" Then
                    If Not IsDBNull(rowTransaksi("StatusSembuh")) AndAlso Convert.ToBoolean(rowTransaksi("StatusSembuh")) = True Then
                        penyakitMalaria = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " (Sembuh)" : GoTo GoBackthis
                    Else
                        penyakitMalaria = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") : GoTo GoBackthis
                    End If
                Else
                    penyakitMalaria = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Penyakit Ambeien
            If rowTransaksi("fisiknourut") = "3049" Then
                If fisikResult = "Ya" Then
                    If Not IsDBNull(rowTransaksi("StatusSembuh")) AndAlso Convert.ToBoolean(rowTransaksi("StatusSembuh")) = True Then
                        penyakitAmbeien = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " (Sembuh)" : GoTo GoBackthis
                    Else
                        penyakitAmbeien = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") : GoTo GoBackthis
                    End If
                Else
                    penyakitAmbeien = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Penyakit THT
            If rowTransaksi("fisiknourut") = "3040" Then
                If fisikResult = "Ya" Then
                    If Not IsDBNull(rowTransaksi("StatusSembuh")) AndAlso Convert.ToBoolean(rowTransaksi("StatusSembuh")) = True Then
                        penyakitTht = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " (Sembuh)" : GoTo GoBackthis
                    Else
                        penyakitTht = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") : GoTo GoBackthis
                    End If
                Else
                    penyakitTht = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Penyakit Kencing Batu
            If rowTransaksi("fisiknourut") = "3051" Then
                If fisikResult = "Ya" Then
                    If Not IsDBNull(rowTransaksi("StatusSembuh")) AndAlso Convert.ToBoolean(rowTransaksi("StatusSembuh")) = True Then
                        penyakitKencingBatu = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " (Sembuh)" : GoTo GoBackthis
                    Else
                        penyakitKencingBatu = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") : GoTo GoBackthis
                    End If
                Else
                    penyakitKencingBatu = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Penyakit Vertigo
            If rowTransaksi("fisiknourut") = "3052" Then
                If fisikResult = "Ya" Then
                    If Not IsDBNull(rowTransaksi("StatusSembuh")) AndAlso Convert.ToBoolean(rowTransaksi("StatusSembuh")) = True Then
                        penyakitVertigo = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " (Sembuh)" : GoTo GoBackthis
                    Else
                        penyakitVertigo = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") : GoTo GoBackthis
                    End If
                Else
                    penyakitVertigo = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Penyakit Anorexia
            If rowTransaksi("fisiknourut") = "3042" Then
                If fisikResult = "Ya" Then
                    If Not IsDBNull(rowTransaksi("StatusSembuh")) AndAlso Convert.ToBoolean(rowTransaksi("StatusSembuh")) = True Then
                        penyakitAnorexia = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " (Sembuh)" : GoTo GoBackthis
                    Else
                        penyakitAnorexia = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") : GoTo GoBackthis
                    End If
                Else
                    penyakitAnorexia = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Penyakit Pingsan
            If rowTransaksi("fisiknourut") = "3054" Then
                If fisikResult = "Ya" Then
                    If Not IsDBNull(rowTransaksi("StatusSembuh")) AndAlso Convert.ToBoolean(rowTransaksi("StatusSembuh")) = True Then
                        penyakitPingsan = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " (Sembuh)" : GoTo GoBackthis
                    Else
                        penyakitPingsan = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") : GoTo GoBackthis
                    End If
                Else
                    penyakitPingsan = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Penyakit Gastritis
            If rowTransaksi("fisiknourut") = "3055" Then
                If fisikResult = "Ya" Then
                    If Not IsDBNull(rowTransaksi("StatusSembuh")) AndAlso Convert.ToBoolean(rowTransaksi("StatusSembuh")) = True Then
                        penyakitGastritis = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " (Sembuh)" : GoTo GoBackthis
                    Else
                        penyakitGastritis = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") : GoTo GoBackthis
                    End If
                Else
                    penyakitGastritis = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Penyakit Pusing
            If rowTransaksi("fisiknourut") = "3056" Then
                If fisikResult = "Ya" Then
                    If Not IsDBNull(rowTransaksi("StatusSembuh")) AndAlso Convert.ToBoolean(rowTransaksi("StatusSembuh")) = True Then
                        penyakitPusing = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " (Sembuh)" : GoTo GoBackthis
                    Else
                        penyakitPusing = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") : GoTo GoBackthis
                    End If
                Else
                    penyakitPusing = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Penyakit Typoid Fever
            If rowTransaksi("fisiknourut") = "3045" Then
                If fisikResult = "Ya" Then
                    If Not IsDBNull(rowTransaksi("StatusSembuh")) AndAlso Convert.ToBoolean(rowTransaksi("StatusSembuh")) = True Then
                        penyakitTypoidFever = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " (Sembuh)" : GoTo GoBackthis
                    Else
                        penyakitTypoidFever = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") : GoTo GoBackthis
                    End If
                Else
                    penyakitTypoidFever = fisikResult : GoTo GoBackthis
                End If
            End If

            ' Penyakit Turun BB
            If rowTransaksi("fisiknourut") = "3046" Then
                If fisikResult = "Ya" Then
                    If Not IsDBNull(rowTransaksi("StatusSembuh")) AndAlso Convert.ToBoolean(rowTransaksi("StatusSembuh")) = True Then
                        penyakitTurunBb = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") & " (Sembuh)" : GoTo GoBackthis
                    Else
                        penyakitTurunBb = fisikResult & ", " & Format(rowTransaksi("kapan"), "yyyy") : GoTo GoBackthis
                    End If
                Else
                    penyakitTurunBb = fisikResult : GoTo GoBackthis
                End If
            End If



            ' ################### Kesimpulan & Saran Fisik ################### '
            ' Kesimpulan Fisik
            If rowTransaksi("fisiknourut") = "3060" Then kesimpulanFisik = fisikResult : GoTo GoBackthis

            ' Saran Fisik
            If rowTransaksi("fisiknourut") = "3061" Then
                If fisikResult <> "" Then
                    saranFisikTitikDuaLabel = ":"
                    saranFisikKeteranganLabel = "SARAN"
                End If

                saranFisik = fisikResult : GoTo GoBackthis
            End If

GoBackthis:
        Next

        ' Set BMI
        pemeriksaanBMI = Math.Round(CDbl(pemeriksaanBeratBadan / (pemeriksaanTinggiBadan * pemeriksaanTinggiBadan) * 10000), 1)

        ' Add Detail Fisik
        Dim newDetail As DataRow = tblDetailPemeriksaan.NewRow

        newDetail("PemeriksaanTinggiBadan") = pemeriksaanTinggiBadan
        newDetail("PemeriksaanBeratBadan") = pemeriksaanBeratBadan
        newDetail("PemeriksaanDetakNadi") = pemeriksaanDetakNadi
        newDetail("PemeriksaanSuhu") = pemeriksaanSuhu
        newDetail("PemeriksaanNafas") = pemeriksaanNafas
        newDetail("PemeriksaanTensi") = pemeriksaanTensi
        newDetail("PemeriksaanBMI") = pemeriksaanBMI

        newDetail("RiwayatOperasi") = riwayatOperasi
        newDetail("RiwayatRumahSakit") = riwayatRumahSakit
        newDetail("RiwayatPengobatanPenyakit") = riwayatPengobatanPenyakit
        newDetail("RiwayatPenggunaanNarkoba") = riwayatPenggunaanNarkoba
        newDetail("RiwayatKondisiSehat") = riwayatKondisiSehat
        newDetail("RiwayatPenyakitKeluarga") = riwayatPenyakitKeluarga

        newDetail("KebiasaanRokok") = kebiasaanRokok
        newDetail("KebiasaanAlkohol") = kebiasaanAlkohol
        newDetail("KebiasaanKopi") = kebiasaanKopi
        newDetail("KebiasaanPolaMakan") = kebiasaanPolaMakan
        newDetail("KebiasaanPolaIstirahat") = kebiasaanPolaIstirahat
        newDetail("KebiasaanOlahraga") = kebiasaanOlahraga

        newDetail("PenyakitHepatitis") = penyakitHepatitis
        newDetail("PenyakitTbc") = penyakitTbc
        newDetail("PenyakitHernia") = penyakitHernia
        newDetail("PenyakitHipertensi") = penyakitHipertensi
        newDetail("PenyakitEpilepsi") = penyakitEpilepsi
        newDetail("PenyakitDiabetesMellitus") = penyakitDiabetesMellitus
        newDetail("PenyakitParuNonTbc") = penyakitParuNonTbc
        newDetail("PenyakitSakitJantung") = penyakitSakitJantung
        newDetail("PenyakitGangguanKulit") = penyakitGangguanKulit
        newDetail("PenyakitMalaria") = penyakitMalaria
        newDetail("PenyakitAmbeien") = penyakitAmbeien
        newDetail("PenyakitTht") = penyakitTht
        newDetail("PenyakitKencingBatu") = penyakitKencingBatu
        newDetail("PenyakitVertigo") = penyakitVertigo
        newDetail("PenyakitAnorexia") = penyakitAnorexia
        newDetail("PenyakitPingsan") = penyakitPingsan
        newDetail("PenyakitGastritis") = penyakitGastritis
        newDetail("PenyakitPusing") = penyakitPusing
        newDetail("PenyakitTypoidFever") = penyakitTypoidFever
        newDetail("PenyakitTurunBb") = penyakitTurunBb

        newDetail("KesimpulanFisik") = kesimpulanFisik
        newDetail("SaranFisik") = saranFisik
        newDetail("SaranFisikTitikDuaLabel") = saranFisikTitikDuaLabel
        newDetail("SaranFisikKeteranganLabel") = saranFisikKeteranganLabel

        tblDetailPemeriksaan.Rows.Add(newDetail)

        Return tblDetailPemeriksaan
    End Function

    Private Sub CreateReportFisik(ByVal Action As String)
        ' Set Data Transaksi Fisik
        Dim tblPemeriksaanFisik As DataTable = ReadThemysql("SELECT HasilFisikID, FisikNoUrut, FisikKet, REPLACE(result,'~',' ') AS Result FROM transaksilabfisik WHERE NoUrut = '" & TextBoxNoTransaksi.Text & "' AND idlabinternet='" & idTransaksi & "' and ((FisikNoUrut between 3006 AND 3028) OR FisikNoUrut = 4001) order by FisikNoUrut", DB_Poliklinik)
        tblPemeriksaanFisik.TableName = "DetailPemeriksaanFisik"

        ' Set Data Pasien
        Dim tblDetailPasien As DataTable = GetDataHeaderReport()
        tblDetailPasien.TableName = "DetailTransaksi"

        ' Set Data Riwayat Kesehatan
        Dim tblDetailPemeriksaan As DataTable = GetDataDetailPemeriksaan()
        tblDetailPemeriksaan.TableName = "DetailPemeriksaan"

        For Each Trow As DataRow In tblPemeriksaanFisik.Rows
            ' Edit Tampilan Visus Mata
            If (Trow("FisikNoUrut") = "3012" Or Trow("FisikNoUrut") = "3013" Or Trow("FisikNoUrut") = "3014" Or Trow("FisikNoUrut") = "3015") And Trow("Result").ToString.Trim <> "" And Trow("Result").ToString.Contains(",") = True Then
                Dim hasil As String = ""

                Dim TsplitHasil() As String = Trow("Result").ToString.Split(",")
                If TsplitHasil(0) = TsplitHasil(1) Then
                    hasil = "ODS: " & TsplitHasil(0)
                Else
                    hasil = "OD: " & TsplitHasil(0).ToString & ", OS: " & TsplitHasil(1).ToString
                End If

                Trow("Result") = hasil
            ElseIf (Trow("FisikNoUrut") = "3012" Or Trow("FisikNoUrut") = "3013" Or Trow("FisikNoUrut") = "3014" Or Trow("FisikNoUrut") = "3015") And Trow("Result").ToString.Trim = "" Then
                Trow("Result") = "Tidak dilakukan"
            End If
        Next

        Report = New XtraReport

        If Action = "Preview" Then
            Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\Hasil\HasilLabFisikKopOnline.repx", True)
        ElseIf Action = "Print" Then
            Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\Hasil\HasilLabFisikOnline.repx", True)
        End If

        Dim dataSet As New DataSet()
        dataSet.Tables.Add(tblPemeriksaanFisik.Copy())
        dataSet.Tables.Add(tblDetailPasien.Copy())
        dataSet.Tables.Add(tblDetailPemeriksaan.Copy())

        Report.DataSource = dataSet

        If Action = "Preview" Then
            Report.ShowPreview()
            'Report.RunDesigner()
        ElseIf Action = "Print" Then
            Report.Print()
            'Report.RunDesigner()
        End If
    End Sub

    Function GetDataHeaderReport() As DataTable
        Dim tblDetailPasien As New DataTable
        Dim queryBuilder As New StringBuilder()

        ' Set Table Detail Pasien
        insertRowToTbls(tblDetailPasien, "Typstring", "Registrasi")
        insertRowToTbls(tblDetailPasien, "Typstring", "Nama")
        insertRowToTbls(tblDetailPasien, "typstring", "Umur")
        insertRowToTbls(tblDetailPasien, "typstring", "Alamat")
        insertRowToTbls(tblDetailPasien, "typstring", "NoTransaksi")
        insertRowToTbls(tblDetailPasien, "typstring", "DrPelaksana")
        insertRowToTbls(tblDetailPasien, "typstring", "DrRequest")
        insertRowToTbls(tblDetailPasien, "typstring", "Tanggal")
        insertRowToTbls(tblDetailPasien, "typstring", "Hasil")
        insertRowToTbls(tblDetailPasien, "typstring", "Saran")
        insertRowToTbls(tblDetailPasien, "typstring", "Kesimpulan")
        insertRowToTbls(tblDetailPasien, "typstring", "InfoCetak")
        insertRowToTbls(tblDetailPasien, "typstring", "NomorIzinKlinik")

        ' Query Transaksi
        queryBuilder.AppendLine("SELECT a.SendingWhatsapp, a.SendingEmail, b.PTNIK, b.NIP, a.caraambil, a.dokterrequest, c.nojenisbayar, b.nama, b.nomitra, a.nourut, b.sex, DATE(b.tgllahir) AS tgllahir, b.alamat, DATE(a.tgllab) AS tgllab, a.Kesimpulan, a.Saran")
        queryBuilder.AppendLine("FROM transaksilab a")
        queryBuilder.AppendLine("     LEFT JOIN masterpasien b ON a.idpasien=b.nomitra AND a.idtempatlab=b.cabang")
        queryBuilder.AppendLine("     LEFT JOIN transaksilabbayar c ON a.idlabinternet = c.idlabinternet")
        queryBuilder.AppendLine("WHERE a.idlabinternet = '" & idTransaksi & "' AND a.idtempatlab = '" & kodeLokasi & "'")

        Dim tblTransaksi As DataTable = ReadThemysql(queryBuilder.ToString(), DB_Poliklinik)
        Dim rowTransaksi As DataRow = tblTransaksi.Rows(0)

        ' Set No Rekam Medis Pasien
        Dim noRekamMedisPasien As String = rowTransaksi("nomitra")

        ' Set Nama Pasien
        Dim namaPasien As String = ""

        ' Set Gelar Pasien
        Dim gelarPasien As String = Gelar(Year(Now()) - Year(rowTransaksi("tgllahir")), rowTransaksi("sex").ToString.Trim)

        If IsDBNull(rowTransaksi("PTNIK")) = False AndAlso rowTransaksi("PTNIK").ToString <> "-" And rowTransaksi("PTNIK").ToString <> "" Then
            namaPasien = gelarPasien & " " & rowTransaksi("nama") & " / " & rowTransaksi("PTNIK") & " (" & rowTransaksi("sex") & ")" & vbCrLf
        Else
            namaPasien = gelarPasien & " " & rowTransaksi("nama") & " (" & rowTransaksi("sex") & ")" & vbCrLf
        End If

        ' Set Umur Pasien
        Dim umurPasien As String = ""
        Dim Tgltemp As Date = rowTransaksi("tgllahir")
        If Tgltemp.Date.AddYears(120).Year > DateAndTime.Now.Year Then
            umurPasien = Format(rowTransaksi("tgllahir"), "dd MMM yyyy") & " / " & Umur(rowTransaksi("tgllahir"))
        End If

        ' Set Alamat Pasien
        Dim alamatPasien As String = ""
        If IsDBNull(rowTransaksi("NIP")) = False AndAlso rowTransaksi("NIP").ToString <> "-" And rowTransaksi("NIP").ToString <> "" Then
            alamatPasien = rowTransaksi("alamat") & " / " & rowTransaksi("NIP")
        Else
            alamatPasien = rowTransaksi("alamat")
        End If

        ' Set No Transaksi Pasien
        Dim noTransaksiPasien As String = rowTransaksi("nourut") & " (" & idTransaksi & ")"

        ' Set Dokter Pengirim
        Dim dokterPengirimPasien As String = ""

        Dim splitcompany() As String = rowTransaksi("nojenisbayar").ToString.Split("-")

        If CheckSQL("SELECT * FROM mastercompany WHERE NoCompany = '" & splitcompany(1) & "' AND ReportHasilPerusahaan = 0") = True And rowTransaksi("nourut").ToString.Trim.Contains("M") = True Then
            dokterPengirimPasien = "Atas Permintaan Sendiri"
        Else
            If IsNumeric(rowTransaksi("dokterrequest").ToString) = True Or rowTransaksi("dokterrequest").ToString = "" Or rowTransaksi("nourut").Contains("M") Then
                dokterPengirimPasien = splitcompany(0)
            Else
                dokterPengirimPasien = rowTransaksi("dokterrequest")
            End If
        End If

        Dim TempWhatsapp As String = ""
        Dim TempEmail As String = ""

        ' Set Metode Kirim Hasil
        Dim metodeKirimHasilPasien As String = rowTransaksi("caraambil")

        If IsDBNull(rowTransaksi("SendingWhatsapp")) = False And rowTransaksi("SendingWhatsapp").ToString.Trim <> "-" And rowTransaksi("SendingWhatsapp").ToString.Trim <> "" Then
            NoWhatsappCustomer = rowTransaksi("SendingWhatsapp")
            TempWhatsapp = NoWhatsappCustomer.Substring(0, 3) & "*****" & NoWhatsappCustomer.Substring(8, NoWhatsappCustomer.Length - 8)
            metodeKirimHasilPasien = metodeKirimHasilPasien.Replace(NoWhatsappCustomer, TempWhatsapp)
        Else
            NoWhatsappCustomer = "-"
        End If

        If IsDBNull(rowTransaksi("SendingEmail")) = False And rowTransaksi("SendingEmail").ToString.Trim <> "-" Then
            EmailCustomer = rowTransaksi("SendingEmail")
            TempEmail = EmailCustomer.Substring(0, 3) & "*****" & EmailCustomer.Substring(8, EmailCustomer.Length - 8)
            metodeKirimHasilPasien = metodeKirimHasilPasien.Replace(EmailCustomer, TempEmail)
        Else
            EmailCustomer = "-"
        End If

        ' Set Kesimpulan & Saran
        Dim saranHasilPasien As String = ""
        Dim kesimpulanHasilPasien As String = ""

        If IsDBNull(rowTransaksi("Saran")) = False Then saranHasilPasien = rowTransaksi("Saran")
        If IsDBNull(rowTransaksi("Kesimpulan")) = False Then kesimpulanHasilPasien = rowTransaksi("Kesimpulan")

        ' Add Detail Pasien
        Dim newDetail As DataRow = tblDetailPasien.NewRow
        newDetail("Registrasi") = noRekamMedisPasien
        newDetail("Nama") = namaPasien
        newDetail("Umur") = umurPasien
        newDetail("Alamat") = alamatPasien
        newDetail("NoTransaksi") = noTransaksiPasien
        newDetail("DrPelaksana") = DrPelaksanaKlinik
        newDetail("DrRequest") = dokterPengirimPasien
        newDetail("Tanggal") = Format(rowTransaksi("tgllab"), "dd-MMM-yyyy")
        newDetail("Hasil") = metodeKirimHasilPasien
        newDetail("Saran") = saranHasilPasien
        newDetail("Kesimpulan") = kesimpulanHasilPasien
        newDetail("InfoCetak") = Format(DateAndTime.Now, "dd-MM-yyyy HH:mm:ss") + " by " + UserLabAdminOnline
        newDetail("NomorIzinKlinik") = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NomorIjinLab'")
        tblDetailPasien.Rows.Add(newDetail)

        Return tblDetailPasien
    End Function

    Private Sub PreviewHasilLabToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreviewHasilLabToolStripMenuItem.Click
        CreateHasilToPDF("Preview", "Yes")
    End Sub

    Private Sub SendingWhatsappEmailToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendingWhatsappEmailToolStripMenuItem.Click
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

        Dim Tlab As DataTable = ReadThemysql("SELECT SendingWhatsapp, SendingEmail, Kesimpulan, Saran, caraambil, dokterrequest " & _
                                             "FROM transaksilab " & _
                                             "WHERE idlabinternet='" & idTransaksi & "' AND idtempatlab='" & kodeLokasi & "'", DB_Poliklinik)
        Dim TrowLab As DataRow = Tlab.Rows(0)

        Dim caraambil As String = TrowLab("caraambil")
        If IsDBNull(TrowLab("SendingWhatsapp")) = False And TrowLab("SendingWhatsapp").ToString.Trim <> "-" And TrowLab("SendingWhatsapp").ToString.Trim <> "" Then
            NoWhatsappCustomer = TrowLab("SendingWhatsapp")
        Else
            NoWhatsappCustomer = "-"
        End If

        If IsDBNull(TrowLab("SendingEmail")) = False And TrowLab("SendingEmail").ToString.Trim <> "-" Then
            EmailCustomer = TrowLab("SendingEmail")
        Else
            EmailCustomer = "-"
        End If

        If chkclosed.Checked = True Then
            If CheckThemysql("SELECT * FROM transaksilab a WHERE a.idlabinternet='" & idTransaksi & "' AND a.tglcetakhasil IS NULL", DB_Poliklinik) = True Then
                WriteThemysql("update transaksilab set tglcetakhasil=now(), labcetak=now() , Status='TAKEIT' , usercetakhasil='" & UserLabAdminOnline & "' ,closedinputhasil=1 where idlabinternet='" & idTransaksi & "'", DB_Poliklinik)
            End If
        End If

        ' Save PDF Hasil ke Path Tujuan
        Dim NameFile As String = TextBoxNoTransaksi.Text & "_Hasil_Laboratorium_" & idTransaksi.Trim
        Dim filepath As String = "FileDownload\Hasil_Online\" & NameFile & ".pdf"
        If File.Exists(filepath) = False Then
            SavePDFtoPath()
        End If

        ' ========================================================

        ' Cek Save Thorax & Hematologi Lengkap
        Dim TblsDetail As DataTable = ReadThemysql("SELECT namatindakan AS 'Nama Tindakan' FROM transaksilabdetail WHERE idlabinternet = '" & idTransaksi & "'", DB_Poliklinik)
        For Each TrowDetail As DataRow In TblsDetail.Rows
            If TrowDetail("Nama Tindakan").ToString.Trim() = "Hematologi Lengkap" Then
                ' Cek Hematologi Lengkap
                If Utility.GetConfig("Mesin") = "Yes" And CekKoneksi("SHOW TABLES FROM " & DB_Sysmex.Tdb & "", DB_Sysmex) = True Then
                    Dim NameFileDL As String = TextBoxNoTransaksi.Text & "_Hasil_Hematologi_Lengkap_" & idTransaksi.Trim
                    Dim filepathDL As String = "FileDownload\Hasil_Online\Hematologi_Lengkap\" & NameFileDL & ".pdf"
                    If File.Exists(filepathDL) = False Then
                        ' Save PDF Hasil Hematologi Lengkap
                        CreateHematologiLengkapToPDF("Nothing")

                        If File.Exists(filepathDL) = False Then
                            MsgBox("File Hematologi Lengkap tidak ditemukan, gagal mengirim hasil Whatsapp/Email.", MsgBoxStyle.Exclamation, "Warning!")
                            Exit Sub
                        End If
                    End If

                    SendHasilDL = True
                End If
                'ElseIf Strings.LCase(TrowDetail("NamaTindakan").ToString).Contains("thorax") = True Then
                '    'Check Thorax
                '    Dim NameFileThorax As String = TextBoxNoTransaksi.Text & "_Hasil_Thorax"
                '    Dim filepaththorax As String = "FileDownload\Hasil\Thorax\" & NameFileThorax & ".pdf"
                '    If File.Exists(filepaththorax) = False Then
                '        'Save PDF
                '        CreateThoraxToPDF("Nothing", "Yes")

                '        If File.Exists(filepaththorax) = False Then
                '            MsgBox("File Thorax tidak ditemukan, gagal mengirim hasil Whatsapp/Email.", MsgBoxStyle.Exclamation, "Warning!")
                '            Exit Sub
                '        End If
                '    End If

                '    SendHasilThorax = True
            End If
        Next

        ' ========================================================

        If CheckThemysql("select * from LogSendingWhatsappEmail where Cabang='" & kodeLokasi.Trim & "' and (SendingJenis='Whatsapp' or SendingJenis='Email') and NoUrut = '" & TextBoxNoTransaksi.Text.Trim & "'", DB_Poliklinik) = True Then
            If MsgBox("Hasil sudah pernah dikirim ke email/Whatsapp tersebut, apakah tetap dilanjutkan?", MsgBoxStyle.YesNo, "Question.") = MsgBoxResult.No Then
                MsgBox("Batal mengirimkan email.", MsgBoxStyle.Exclamation, "Warning!")
                Exit Sub
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
            Dim Tcompany As DataTable = ReadSQL("select No_Handphone2, No_Handphone, Email_Perusahaan, TerimaHasilKaryawan, Whatsapp_Auto, Email_Auto from mastercompany where NoCompany='" & txcodepenagihan.Text.Trim & "'")
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

    Public Sub sendingwhatsappcompany()
        Try

            NewToolStripMenuItem.Enabled = False
            Dim NoWhatsapp As String = NoWhatsappCompany
            If Strings.Left(NoWhatsapp, 2) = "08" Then NoWhatsapp = "62" & NoWhatsapp.Substring(1, NoWhatsapp.Length - 1)
            Dim TIP_Whatsapp = ReadSQLNIK("select StrValue from MsConfig where ConfigName='TIP_Whatsapp'")
            Dim TxPDF As String = Convert.ToBase64String(System.IO.File.ReadAllBytes("FileDownload\Hasil_Online\" & TextBoxNoTransaksi.Text & "_Hasil_Laboratorium_" & idTransaksi.Trim & ".pdf"))
            Dim filename As String = TextBoxNoTransaksi.Text & "_Hasil_Laboratorium.pdf"
            Dim parameter As String = SetParameterWhatsapp(NoWhatsapp, TxPDF, filename, "No")

            Dim uri As String = "http://" & TIP_Whatsapp & ":4444/send-pdf"
            Dim StatsSending As String = ""

            StatsSending = SendDataWhatsapp(parameter, uri)

            ' Kirim Hasil Hematologi Lengkap
            If SendHasilDL = True Then
                Dim nameFile_DL As String = TextBoxNoTransaksi.Text & "_Hasil_Hematologi_Lengkap_" & idTransaksi.Trim
                Dim filePath_DL As String = "FileDownload\Hasil_Online\Hematologi_Lengkap\" & nameFile_DL & ".pdf"

                Dim convertBase64PDF_DL As String = Convert.ToBase64String(System.IO.File.ReadAllBytes(filePath_DL))
                Dim filename_DL As String = TextBoxNoTransaksi.Text & "_Hasil_Hematologi_Lengkap.pdf"

                Dim parameter_DL As String = SetParameterWhatsapp(NoWhatsapp, convertBase64PDF_DL, nameFile_DL, "No")
                SendDataWhatsapp(parameter_DL, uri)
            End If

            If StatsSending = "Success" Then
                MsgBox("Berhasil mengirim Whatsapp ke " & NoWhatsappCompany.Trim & ".", MsgBoxStyle.Information, "Success!")
                WriteThemysql("insert into LogSendingWhatsappEmail (SendingJenis, SendingTujuan, SendingNamaFile, SendingStatus, SendingDate, SendingBy, NoUrut, JenisSending, Cabang) values ('Whatsapp', '" & NoWhatsapp & "', '" & TextBoxNoTransaksi.Text & "_Hasil_Laboratorium_" & idTransaksi.Trim & "', 1, NOW(), '" & UserLabAdminOnline & "', '" & TextBoxNoTransaksi.Text & "', 'COMPANY', '" & kodeLokasi.Trim & "')", DB_Poliklinik)
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

            Dim NoWhatsapp As String = NoWhatsappMarketing
            If Strings.Left(NoWhatsapp, 2) = "08" Then NoWhatsapp = "62" & NoWhatsapp.Substring(1, NoWhatsapp.Length - 1)
            Dim TIP_Whatsapp = ReadSQLNIK("select StrValue from MsConfig where ConfigName='TIP_Whatsapp'")
            Dim TxPDF As String = Convert.ToBase64String(System.IO.File.ReadAllBytes("FileDownload\Hasil_Online\" & TextBoxNoTransaksi.Text & "_Hasil_Laboratorium_" & idTransaksi.Trim & ".pdf"))
            Dim filename As String = TextBoxNoTransaksi.Text & "_Hasil_Laboratorium.pdf"
            Dim parameter As String = SetParameterWhatsapp(NoWhatsapp, TxPDF, filename, "No")

            Dim uri As String = "http://" & TIP_Whatsapp & ":4444/send-pdf"
            Dim StatsSending As String = ""

            StatsSending = SendDataWhatsapp(parameter, uri)

            ' Kirim Hasil Hematologi Lengkap
            If SendHasilDL = True Then
                Dim nameFile_DL As String = TextBoxNoTransaksi.Text & "_Hasil_Hematologi_Lengkap_" & idTransaksi.Trim
                Dim filePath_DL As String = "FileDownload\Hasil_Online\Hematologi_Lengkap\" & nameFile_DL & ".pdf"

                Dim convertBase64PDF_DL As String = Convert.ToBase64String(System.IO.File.ReadAllBytes(filePath_DL))
                Dim filename_DL As String = TextBoxNoTransaksi.Text & "_Hasil_Hematologi_Lengkap.pdf"

                Dim parameter_DL As String = SetParameterWhatsapp(NoWhatsapp, convertBase64PDF_DL, nameFile_DL, "No")
                SendDataWhatsapp(parameter_DL, uri)
            End If

            If StatsSending = "Success" Then
                MsgBox("Berhasil mengirim Whatsapp ke " & NoWhatsappMarketing.Trim & ".", MsgBoxStyle.Information, "Success!")
                WriteThemysql("insert into LogSendingWhatsappEmail (SendingJenis, SendingTujuan, SendingNamaFile, SendingStatus, SendingDate, SendingBy, NoUrut, JenisSending, Cabang) values ('Whatsapp', '" & NoWhatsapp & "', '" & TextBoxNoTransaksi.Text & "_Hasil_Laboratorium_" & idTransaksi.Trim & "', 1, NOW(), '" & UserLabAdminOnline & "', '" & TextBoxNoTransaksi.Text & "', 'MARKETING','" & kodeLokasi.Trim & "')", DB_Poliklinik)
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

            Dim NoWhatsapp As String = NoWhatsappCustomer
            Dim Twhatsapp() As String = NoWhatsappCustomer.Split(",")
            If NoWhatsappCustomer = "-" Then
                NoWhatsapp = ReadThemysqlNIK("select tlp from masterpasien where nomitra in (select idpasien from transaksilab where idlabinternet='" & idTransaksi & "' AND idtempatlab='" & kodeLokasi & "') AND cabang = '" & kodeLokasi & "'", DB_Poliklinik)
            Else
                If NoWhatsappCustomer.Contains(",") = False Then NoWhatsapp = Twhatsapp(0)
            End If

            If NoWhatsappCustomer = "-" Or NoWhatsappCustomer.Contains(",") = False Then
                If Strings.Left(NoWhatsapp, 2) = "08" Then NoWhatsapp = "62" & NoWhatsapp.Substring(1, NoWhatsapp.Length - 1)
            End If

            Dim TIP_Whatsapp As String = ReadSQLNIK("select StrValue from MsConfig where ConfigName='TIP_Whatsapp'")
            Dim TxPDF As String = ""
            Dim filename As String = ""
            Dim parameter As String = ""
            Dim uri As String = ""
            Dim uri_message As String = ""
            Dim StatsSending As String = ""

            If NoWhatsappCustomer.Contains(",") = False Or NoWhatsappCustomer = "-" Then
                TxPDF = Convert.ToBase64String(System.IO.File.ReadAllBytes("FileDownload\Hasil_Online\" & TextBoxNoTransaksi.Text & "_Hasil_Laboratorium_" & idTransaksi.Trim & ".pdf"))
                filename = TextBoxNoTransaksi.Text & "_Hasil_Laboratorium.pdf"

                parameter = SetParameterWhatsapp(NoWhatsapp, TxPDF, filename, "Yes")

                uri = "http://" & TIP_Whatsapp & ":4444/send-pdf"
                uri_message = "http://" & TIP_Whatsapp & ":4444/send"

                StatsSending = SendDataWhatsapp(parameter, uri)

                ' Kirim Hasil Hematologi Lengkap
                If SendHasilDL = True Then
                    Dim nameFile_DL As String = TextBoxNoTransaksi.Text & "_Hasil_Hematologi_Lengkap_" & idTransaksi.Trim
                    Dim filePath_DL As String = "FileDownload\Hasil_Online\Hematologi_Lengkap\" & nameFile_DL & ".pdf"

                    Dim convertBase64PDF_DL As String = Convert.ToBase64String(System.IO.File.ReadAllBytes(filePath_DL))
                    Dim filename_DL As String = TextBoxNoTransaksi.Text & "_Hasil_Hematologi_Lengkap.pdf"

                    Dim parameter_DL As String = SetParameterWhatsapp(NoWhatsapp, convertBase64PDF_DL, nameFile_DL, "No")
                    SendDataWhatsapp(parameter_DL, uri)
                End If

                If CheckThemysql("select * from LogSendingWhatsappEmail where Cabang='" & kodeLokasi.Trim & "' and SendingJenis='Whatsapp' and SendingTujuan like '%" & NoWhatsapp & "%' and date(SendingDate) = '" & Format(DateTime.Now, "yyyy-MM-dd") & "'", DB_Poliklinik) = False Then
                    SendDataWhatsapp(parameter, uri_message)
                End If
            ElseIf NoWhatsappCustomer.Contains(",") = True Then
                For i As Integer = 0 To Twhatsapp.Count - 1
                    NoWhatsapp = Twhatsapp(i).ToString.Trim
                    If Strings.Left(NoWhatsapp, 2) = "08" Then NoWhatsapp = "62" & NoWhatsapp.Substring(1, NoWhatsapp.Length - 1)

                    TxPDF = Convert.ToBase64String(System.IO.File.ReadAllBytes("FileDownload\Hasil_Online\" & TextBoxNoTransaksi.Text & "_Hasil_Laboratorium_" & idTransaksi.Trim & ".pdf"))
                    filename = TextBoxNoTransaksi.Text & "_Hasil_Laboratorium.pdf"

                    parameter = SetParameterWhatsapp(NoWhatsapp, TxPDF, filename, "Yes")

                    uri = "http://" & TIP_Whatsapp & ":4444/send-pdf"
                    uri_message = "http://" & TIP_Whatsapp & ":4444/send"

                    SendDataWhatsapp(parameter, uri)

                    ' Kirim Hasil Hematologi Lengkap
                    If SendHasilDL = True Then
                        Dim nameFile_DL As String = TextBoxNoTransaksi.Text & "_Hasil_Hematologi_Lengkap_" & idTransaksi.Trim
                        Dim filePath_DL As String = "FileDownload\Hasil_Online\Hematologi_Lengkap\" & nameFile_DL & ".pdf"

                        Dim convertBase64PDF_DL As String = Convert.ToBase64String(System.IO.File.ReadAllBytes(filePath_DL))
                        Dim filename_DL As String = TextBoxNoTransaksi.Text & "_Hasil_Hematologi_Lengkap.pdf"

                        Dim parameter_DL As String = SetParameterWhatsapp(NoWhatsapp, convertBase64PDF_DL, nameFile_DL, "No")
                        SendDataWhatsapp(parameter_DL, uri)
                    End If

                    If CheckThemysql("select * from LogSendingWhatsappEmail where Cabang='" & kodeLokasi.Trim & "' and SendingJenis='Whatsapp' and SendingTujuan like '%" & NoWhatsapp & "%' and date(SendingDate) = '" & Format(DateTime.Now, "yyyy-MM-dd") & "'", DB_Poliklinik) = False Then
                        SendDataWhatsapp(parameter, uri_message)
                    End If
                Next
            End If

            If StatsSending = "Success" Then
                MsgBox("Berhasil mengirim Whatsapp ke " & NoWhatsappCustomer.Trim & ".", MsgBoxStyle.Information, "Success!")
                WriteThemysql("insert into LogSendingWhatsappEmail (SendingJenis, SendingTujuan, SendingNamaFile, SendingStatus, SendingDate, SendingBy, NoUrut, JenisSending, Cabang) values ('Whatsapp', '" & NoWhatsapp.Trim & "', '" & TextBoxNoTransaksi.Text & "_Hasil_Laboratorium_" & idTransaksi.Trim & "', 1, NOW(), '" & UserLabAdminOnline & "', '" & TextBoxNoTransaksi.Text & "', 'PASIEN', '" & kodeLokasi.Trim & "')", DB_Poliklinik)
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
            Dim email As String = EmailCustomer
            Dim Temail() As String = EmailCustomer.Split(",")
            If EmailCustomer = "-" Then
                email = ReadThemysqlNIK("select email from masterpasien where nomitra in (select idpasien from transaksilab where idlabinternet='" & idTransaksi & "' AND idtempatlab='" & kodeLokasi & "') AND cabang = '" & kodeLokasi & "'", DB_Poliklinik)
            Else
                If EmailCustomer.Contains(",") = False Then email = Temail(0)
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
            e_mail.Attachments.Add(New Attachment("FileDownload\Hasil_Online\" & TextBoxNoTransaksi.Text & "_Hasil_Laboratorium_" & idTransaksi.Trim & ".pdf"))

            Smtp_Server.Send(e_mail)

            WriteThemysql("insert into LogSendingWhatsappEmail (SendingJenis, SendingTujuan, SendingNamaFile, SendingStatus, SendingDate, SendingBy, NoUrut, JenisSending, Cabang) values ('Email', '" & email.Trim & "', '" & TextBoxNoTransaksi.Text & "_Hasil_Laboratorium_" & idTransaksi.Trim & "', 1, NOW(), '" & UserLabAdminOnline & "', '" & TextBoxNoTransaksi.Text & "', 'PASIEN', '" & kodeLokasi.Trim & "')", DB_Poliklinik)
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
            e_mail.Attachments.Add(New Attachment("FileDownload\Hasil_Online\" & TextBoxNoTransaksi.Text & "_Hasil_Laboratorium_" & idTransaksi.Trim & ".pdf"))
            Smtp_Server.Send(e_mail)

            MsgBox("Berhasil mengirim email ke " & email.Trim & ".", MsgBoxStyle.Information, "Success!")
            WriteThemysql("insert into LogSendingWhatsappEmail (SendingJenis, SendingTujuan, SendingNamaFile, SendingStatus, SendingDate, SendingBy, NoUrut, JenisSending, Cabang) values ('Email', '" & email.Trim & "', '" & TextBoxNoTransaksi.Text & "_Hasil_Laboratorium_" & idTransaksi.Trim & "', 1, NOW(), '" & UserLabAdminOnline & "', '" & TextBoxNoTransaksi.Text & "', 'COMPANY', '" & kodeLokasi.Trim & "')", DB_Poliklinik)
            NewToolStripMenuItem.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message)
            NewToolStripMenuItem.Enabled = True
        End Try
    End Sub

    Private Sub butpreviewthorax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butpreviewthorax.Click
        If CheckThemysql("select * from transaksilabhasillain where NoUrut='" & TextBoxNoTransaksi.Text & "' and idlabinternet='" & idTransaksi & "'", DB_Poliklinik) Then
            Dim TempWhatsapp As String = ""
            Dim TempEmail As String = ""

            Dim Tlab As DataTable = ReadThemysql("SELECT a.SendingWhatsapp, a.SendingEmail, b.PTNIK, a.caraambil, a.dokterrequest from transaksilab a LEFT JOIN masterpasien b ON a.idpasien=b.nomitra AND a.idtempatlab=b.cabang where idlabinternet='" & idTransaksi & "' AND idtempatlab='" & kodeLokasi & "'", DB_Poliklinik)
            Dim TrowLab As DataRow = Tlab.Rows(0)
            Dim ptnik As String = ""
            Dim Pengirim As String = ""
            If IsDBNull(TrowLab("PTNIK")) = False Then ptnik = TrowLab("PTNIK") Else ptnik = "-"
            Dim DrRequest As String = TrowLab("dokterrequest")
            Dim caraambil As String = TrowLab("caraambil")
            If CheckSQL("select * from mastercompany where NoCompany = '" & txcodepenagihan.Text.Trim & "' and ReportHasilPerusahaan = 0") = True And TextBoxNoTransaksi.Text.Contains("M") = True Then
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

            Dim Nama As String = TextBoxNamaPasien.Text
            Dim numberic As Boolean = False

            For Each str As Char In Nama
                If IsNumeric(str) Then
                    numberic = True
                    Exit For
                End If
            Next

            Dim Tempthorax As DataTable = ReadThemysql("select * from transaksilabhasillain where NoUrut='" & TextBoxNoTransaksi.Text & "' and idlabinternet='" & idTransaksi & "'", DB_Poliklinik)
            insertRowToTbls(Tempthorax, "typstring", "Registrasi")
            insertRowToTbls(Tempthorax, "typstring", "Nama")
            insertRowToTbls(Tempthorax, "typstring", "barcodenotrans")
            insertRowToTbls(Tempthorax, "typstring", "Umur")
            insertRowToTbls(Tempthorax, "typstring", "Alamat")
            insertRowToTbls(Tempthorax, "typstring", "NoTransaksi")
            insertRowToTbls(Tempthorax, "typstring", "DrPelaksana")
            insertRowToTbls(Tempthorax, "typstring", "DrRequest")
            insertRowToTbls(Tempthorax, "typstring", "Tanggal")
            insertRowToTbls(Tempthorax, "typstring", "Hasil")
            For Each Trow As DataRow In Tempthorax.Rows
                Trow("Registrasi") = TextBoxNoRekamMedis.Text
                Trow("barcodenotrans") = idTransaksi
                If (TextBoxNoTransaksi.Text.Contains("M")) Then
                    If numberic = True Then
                        Trow("Nama") = TextBoxGelar.Text & " " & TextBoxNamaPasien.Text & "/(" & TextBoxJenisKelamin.Text & ")" & vbCrLf
                    Else
                        Trow("Nama") = TextBoxGelar.Text & " " & TextBoxNamaPasien.Text & " / " & ptnik & " (" & TextBoxJenisKelamin.Text & ")" & vbCrLf
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
                Trow("NoTransaksi") = TextBoxNoTransaksi.Text & " (" & idTransaksi & ")"
                Trow("DrPelaksana") = DrPelaksanaKlinik
                Trow("Hasil") = caraambil

                If Pengirim <> "" Then
                    Trow("DrRequest") = Pengirim
                Else
                    If IsNumeric(DrRequest.ToString.Trim) = True Or DrRequest.ToString.Trim = "" Or TextBoxNoTransaksi.Text.Contains("M") Then
                        Trow("DrRequest") = txpenagihan.Text.Trim
                    Else
                        Trow("DrRequest") = DrRequest
                    End If
                End If

                Trow("Tanggal") = Format(DateTimeTanggalTransaksi.Value, "dd-MMM-yyyy")
            Next

            Report = New XtraReport
            Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\Hasil\HasilLabThoraxKop.repx", True)

            If AutoTTD.Trim = "Yes" Then
                Report.Bands.Item(BandKind.PageHeader).Controls("ttd").Visible = True
                Report.Bands.Item(BandKind.PageHeader).Controls("ttd").Height = 134
                Report.Bands.Item(BandKind.PageHeader).Controls("ttd").Width = 250
            Else
                Report.Bands.Item(BandKind.PageHeader).Controls("ttd").Visible = False
            End If

            Report.DataSource = Tempthorax
            Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MM-yyyy HH:mm:ss") + " by " + UserLabAdminOnline

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

    Function CheckingDL() As Boolean
        If Utility.GetConfig("Mesin") = "No" Then
            MsgBox("Set config mesin terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        If CekKoneksi("SHOW TABLES FROM " & DB_Poliklinik.Tdb & "", DB_Poliklinik) = False Then
            MsgBox("Diagram Hematologi Lengkap Gagal. Cek Koneksi ke Server DB " & DB_Poliklinik.Tdb & " atau IP " & DB_Poliklinik.Tip & ".", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        Return True
    End Function

    Private Sub CreateHematologiLengkapToPDF(ByVal Action As String)
        Try
            If CheckingDL() = True Then
                Dim Tpasien As DataTable = ReadThemysql("SELECT b.PTNIK, a.caraambil, c.JenisBayar, c.NoJenisBayar, d.kodebarcode, YEAR(CURDATE()) - YEAR(b.tgllahir) AS Umur, b.sex " & _
                                         " FROM transaksilab a" & _
                                         " LEFT JOIN masterpasien b ON a.idpasien=b.nomitra AND a.idtempatlab=b.cabang" & _
                                         " LEFT JOIN transaksilabbayar c ON a.idlabinternet=c.idlabinternet " & _
                                         " LEFT JOIN mastercodebarcode d ON a.idtempatlab=d.kodecabang WHERE a.idlabinternet = '" & idTransaksi & "'", DB_Poliklinik)
                Dim TrowPasien As DataRow = Tpasien.Rows(0)
                Dim ptnik As String = ""
                If IsDBNull(TrowPasien("PTNIK")) = False Then ptnik = TrowPasien("PTNIK") Else ptnik = "-"
                Dim caraambil As String = TrowPasien("caraambil")
                Dim Registrasi As String = TextBoxNoRekamMedis.Text
                Dim barcodenotrans As String = idTransaksi
                Dim Nama As String = TextBoxGelar.Text & " " & TextBoxNamaPasien.Text & "/(" & TextBoxJenisKelamin.Text & ")" & vbCrLf
                Dim Tgltemp As Date = DateTimeTanggalLahir.Value
                Dim UmurPasien As String = ""
                If Tgltemp.Date.AddYears(120).Year < DateAndTime.Now.Year Then
                    UmurPasien = ""
                Else
                    UmurPasien = Format(DateTimeTanggalLahir.Value, "dd MMM yyyy") & " / " & TextBoxUmur.Text
                End If
                Dim Alamat As String = txalamat.Text
                Dim NoTransaksi As String = TextBoxNoTransaksi.Text & " (" & idTransaksi & ")"
                Dim DrRequest As String = ""
                If (TextBoxNoTransaksi.Text.Contains("M")) Then
                    Dim Tsplit() As String = TrowPasien("NoJenisBayar").ToString.Split("-")
                    DrRequest = Tsplit(0).ToString.Trim
                Else
                    DrRequest = butdokter.Text
                End If
                Dim TanggalTrans As String = Format(DateTimeTanggalTransaksi.Value, "dd-MMM-yyyy")
                Dim KodeBarcode As String = TrowPasien("kodebarcode")

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

                Dim tbls As DataTable = ReadThemysql("SELECT a.plt_grafik, a.rbc_grafik, a.diff_grafik FROM sysmex a WHERE a.rnoreg='" & NoUrutMesin & "' AND a.`dok`<>'' AND a.`dok`<>0 order by a.seq_no desc limit 1", DB_Sysmex)
                Dim seq_no As String = ReadThemysqlNIK("SELECT seq_no FROM sysmex a WHERE a.rnoreg='" & NoUrutMesin & "' AND a.`dok`<>'' AND a.`dok`<>0 order by a.seq_no desc limit 1", DB_Sysmex)
                Dim tbls_grafik As DataTable = ReadThemysql("SELECT * FROM fsysmex2 where seq_no IN (SELECT seq_no FROM sysmex a WHERE a.rnoreg='" & NoUrutMesin & "' AND a.`dok`<>'' AND a.`dok`<>0 AND a.seq_no = '" & seq_no & "')", DB_Sysmex)
                Dim umur As Integer = TrowPasien("Umur")
                Dim sex As String = TrowPasien("sex")
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

                        Tnilairujukan = ReadSQL("select * from MasterNilaiRujukanMesin where KodeMesin = '" & TrowData("rnmjasa").ToString.Trim & "'")
                        For Each Tnilairujukanrow As DataRow In Tnilairujukan.Rows
                            RangeUmur = Tnilairujukanrow("RangeUmur").ToString.Trim
                            If RangeUmur.Contains("<") = True Then
                                RangeUmur = Trim(Strings.Replace(Strings.Replace(RangeUmur, "<", ""), "=", ""))
                                If CDbl(umur) < CDbl(RangeUmur) Then
                                    If sex = "L" Then
                                        Tnew("NilaiRujukan_" & TrowData("rnmjasa") & "") = Tnilairujukanrow("Pria")
                                    ElseIf sex = "P" Then
                                        Tnew("NilaiRujukan_" & TrowData("rnmjasa") & "") = Tnilairujukanrow("Wanita")
                                    End If
                                End If
                            ElseIf RangeUmur.Contains(">") = True Then
                                RangeUmur = Trim(Strings.Replace(Strings.Replace(RangeUmur, ">", ""), "=", ""))
                                If CDbl(umur) > CDbl(RangeUmur) Then
                                    If sex = "L" Then
                                        Tnew("NilaiRujukan_" & TrowData("rnmjasa") & "") = Tnilairujukanrow("Pria")
                                    ElseIf sex = "P" Then
                                        Tnew("NilaiRujukan_" & TrowData("rnmjasa") & "") = Tnilairujukanrow("Wanita")
                                    End If
                                End If
                            ElseIf RangeUmur.Contains("-") = True Then
                                Dim Tsplit() As String = RangeUmur.ToString.Split("-")
                                T1 = Trim(Tsplit(0))
                                T2 = Trim(Tsplit(1))

                                If CDbl(umur) > T1 And CDbl(umur) < T2 Then
                                    If sex = "L" Then
                                        Tnew("NilaiRujukan_" & TrowData("rnmjasa") & "") = Tnilairujukanrow("Pria")
                                    ElseIf sex = "P" Then
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
                    Tnew("barcodenotrans") = idTransaksi
                    Thasil.Rows.Add(Tnew)

                    Report = New XtraReport
                    Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\Hasil\GrafikHematologiLengkap.repx", True)
                    Report.DataSource = Thasil
                    Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MM-yyyy HH:mm:ss") + " by " + UserLabAdminOnline
                    Report.Bands(BandKind.Detail).Controls.Add(CreateXRPictureBox(TrowLab("rbc_grafik"), 567, 65, 150, 175))
                    Report.Bands(BandKind.Detail).Controls.Add(CreateXRPictureBox(TrowLab("diff_grafik"), 567, 265, 150, 175))
                    Report.Bands(BandKind.Detail).Controls.Add(CreateXRPictureBox(TrowLab("plt_grafik"), 567, 465, 150, 175))

                    If Action = "Preview" Then
                        Report.ShowPreview()
                    ElseIf Action = "Nothing" Then
                        'SavePDF
                        Dim NameFile As String = TextBoxNoTransaksi.Text & "_Hasil_Hematologi_Lengkap_" & idTransaksi.Trim
                        Dim filepath As String = "FileDownload\Hasil_Online\Hematologi_Lengkap\" & NameFile & ".pdf"
                        If File.Exists(filepath) Then
                            My.Computer.FileSystem.DeleteFile(filepath)
                        End If
                        Report.CreatePdfDocument(filepath)

                        'CreateBase64
                        Dim Base64Inv As String = ""
                        Base64Inv = Convert.ToBase64String(System.IO.File.ReadAllBytes(filepath))

                        'Send Base64 to Online
                        If CheckThemysql("SELECT * FROM transaksilabreportonline WHERE idlabinternet='" & idTransaksi & "'", DB_Poliklinik) = False Then
                            WriteThemysql("INSERT INTO transaksilabreportonline (idlabinternet, hemafilebase64, createdate, createby)  " & _
                                                              "VALUES('" & idTransaksi & "', '" & Base64Inv & "', NOW(), '" & UserLabAdminOnline & "') ", DB_Poliklinik)
                        Else
                            WriteThemysql("UPDATE transaksilabreportonline SET hemafilebase64 = '" & Base64Inv & "', updatedate = NOW(), updateby = '" & UserLabAdminOnline & "' " & _
                                                              "WHERE idlabinternet='" & idTransaksi & "'", DB_Poliklinik)
                        End If
                    End If
                Else
                    MsgBox("Pastikan Hasil (Hematologi Lengkap) sudah di running atau verifikasi di mesin jika ingin melampirkannya di Whatsapp/Email.", MsgBoxStyle.Exclamation, "Warning")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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

    Private Sub exportpdfDL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exportpdfDL.Click
        CreateHematologiLengkapToPDF("Preview")
    End Sub

    Public Sub SaveHematologiLengkap()
        CreateHematologiLengkapToPDF("Nothing")
    End Sub

    Private Sub txtb_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxTinggiBadan.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ".") Then e.Handled = True
    End Sub

    Private Sub txnadi_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxDetakNadi.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ".") Then e.Handled = True
    End Sub

    Private Sub txtekanan_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxSistole.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ".") Then e.Handled = True
    End Sub

    Private Sub txtekanan2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxDiastole.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ".") Then e.Handled = True
    End Sub

    Private Sub txbb_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxBeratBadan.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ".") Then e.Handled = True
    End Sub

    Private Sub txsuhu_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxSuhu.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ".") Then e.Handled = True
    End Sub

    Private Sub txrespirasi_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxNafas.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ".") Then e.Handled = True
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

        '# Validasi Pemeriksaan Head to Toe
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
        If ComboBoxFisikRectalToucher.Text.Trim = "" Then MsgBox("Cek kembali rectal toucher.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        If cmbintegumen.Text.Trim = "" Then MsgBox("Cek kembali integumen.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        If cmbekstemitas.Text.Trim = "" Then MsgBox("Cek kembali ekstemitas.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        If cmbturgor.Text.Trim = "" Then MsgBox("Cek kembali turgor.", MsgBoxStyle.Exclamation, "Warning!") : Return False

        ' Validasi Visus Mata
        If ComboBoxVisusMata1.Text = "Visus dgn kacamata" Then
            ' Set Visus Mata
            If TextBoxVisusKacamataOD.Text <> "" And TextBoxVisusKacamataOS.Text = "" Then
                MsgBox("Cek kembali visus kacamata.", MsgBoxStyle.Exclamation, "Warning!") : Return False
            ElseIf TextBoxVisusKacamataOD.Text = "" And TextBoxVisusKacamataOS.Text <> "" Then
                MsgBox("Cek kembali visus kacamata.", MsgBoxStyle.Exclamation, "Warning!") : Return False
            ElseIf TextBoxVisusTanpaKacamataOD.Text <> "" And TextBoxVisusTanpaKacamataOS.Text = "" Then
                MsgBox("Cek kembali visus tanpa kacamata.", MsgBoxStyle.Exclamation, "Warning!") : Return False
            ElseIf TextBoxVisusTanpaKacamataOD.Text = "" And TextBoxVisusTanpaKacamataOS.Text <> "" Then
                MsgBox("Cek kembali visus tanpa kacamata.", MsgBoxStyle.Exclamation, "Warning!") : Return False
            ElseIf TextBoxVisusTanpaKacamataOD.Text = "" Or TextBoxVisusTanpaKacamataOS.Text = "" Then
                MsgBox("Cek kembali visus tanpa kacamata.", MsgBoxStyle.Exclamation, "Warning!") : Return False
            End If

            Dim statusvisuskacamata As Boolean = False
            Dim statusvisuskacamata2 As Boolean = False
            Dim statusvisustanpakacamata As Boolean = False
            Dim statusvisustanpakacamata2 As Boolean = False
            For Each element As String In ArrayResultMata
                If TextBoxVisusKacamataOD.Text <> "" And TextBoxVisusKacamataOS.Text <> "" Then
                    If TextBoxVisusKacamataOD.Text = element Then statusvisuskacamata = True
                    If TextBoxVisusKacamataOS.Text = element Then statusvisuskacamata2 = True
                End If

                If TextBoxVisusTanpaKacamataOD.Text <> "" And TextBoxVisusTanpaKacamataOS.Text <> "" Then
                    If TextBoxVisusTanpaKacamataOD.Text = element Then statusvisustanpakacamata = True
                    If TextBoxVisusTanpaKacamataOS.Text = element Then statusvisustanpakacamata2 = True
                End If
            Next
            If TextBoxVisusTanpaKacamataOD.Text = "" And TextBoxVisusTanpaKacamataOS.Text = "" And TextBoxVisusKacamataOD.Text <> "" And TextBoxVisusKacamataOS.Text <> "" And (statusvisuskacamata = False Or statusvisuskacamata2 = False) Then MsgBox("Cek kembali visus kacamata.", MsgBoxStyle.Exclamation, "Warning!") : Return False
            If TextBoxVisusTanpaKacamataOD.Text <> "" And TextBoxVisusTanpaKacamataOS.Text <> "" And (statusvisustanpakacamata = False Or statusvisustanpakacamata2 = False) Then MsgBox("Cek kembali visus tanpa kacamata.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        ElseIf ComboBoxVisusMata1.Text = "Visus Mata" Then
            ' Set Visus Mata (Autorefraksi)

        End If

        '# Validasi Riwayat Kesehatan
        ' Riwayat Operasi
        If ComboBoxRiwayatOperasi.Text = "Ya" Then
            If TextBoxDiagnosaRiwayatOperasi.Text = "" Or TextBoxTempatRiwayatOperasi.Text = "" Or DateTimeRiwayatOperasi.Value = "01-01-1900" Then MsgBox("Cek Data Detail Riwayat Operasi.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        ElseIf (ComboBoxRiwayatOperasi.Text <> "Tidak" And ComboBoxRiwayatOperasi.Text <> "Ya") Then
            MsgBox("Cek Data Riwayat Operasi.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        End If

        ' Riwayat Rumah Sakit
        If ComboBoxRiwayatRumahSakit.Text = "Ya" Then
            If TextBoxDiagnosaRiwayatRumahSakit.Text = "" Or TextBoxTempatRiwayatRumahSakit.Text = "" Or DateTimeRiwayatRumahSakit.Value = "01-01-1900" Then MsgBox("Cek Data Detail Riwayat Rumah Sakit.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        ElseIf (ComboBoxRiwayatRumahSakit.Text <> "Tidak" And ComboBoxRiwayatRumahSakit.Text <> "Ya") Then
            MsgBox("Cek Data Riwayat Rumah Sakit.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        End If

        ' Riwayat Sehat
        If ComboBoxRiwayatKondisiSehat.Text = "Tidak" Then
            If TextBoxKeluhanRiwayatKondisiSehat.Text = "" Then MsgBox("Cek Data Detail Riwayat Sehat.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        ElseIf (ComboBoxRiwayatKondisiSehat.Text <> "Tidak" And ComboBoxRiwayatKondisiSehat.Text <> "Ya") Then
            MsgBox("Cek Data Riwayat Sehat.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        End If

        ' Riwayat Pengobatan Penyakit
        If ComboBoxRiwayatPengobatanPenyakit.Text = "Ya" Then
            If TextBoxDiagnosaRiwayatPengobatanPenyakit.Text = "" Or TextBoxTerapiRiwayatPengobatanPenyakit.Text = "" Or DateTimeRiwayatPengobatanPenyakit.Value = "01-01-1900" Then MsgBox("Cek Data Detail Riwayat Pengobatan Penyakit.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        ElseIf ComboBoxRiwayatPengobatanPenyakit.Text <> "Tidak" And ComboBoxRiwayatPengobatanPenyakit.Text <> "Ya" Then
            MsgBox("Cek Data Riwayat Pengobatan Penyakit.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        End If

        ' Riwayat Penggunaan Narkoba
        If ComboBoxRiwayatPenggunaNarkoba.Text = "Ya" Then
            If TextBoxJenisRiwayatPenggunaNarkoba.Text = "" Or DateTimeRiwayatPenggunaNarkoba.Value = "01-01-1900" Then MsgBox("Cek Data Detail Riwayat Penggunaan Narkoba.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        ElseIf (ComboBoxRiwayatPenggunaNarkoba.Text <> "Tidak" And ComboBoxRiwayatPenggunaNarkoba.Text <> "Ya") Then
            MsgBox("Cek Data Riwayat Penggunaan Narkoba.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        End If

        ' Riwayat Penyakit Keluarga
        If ComboBoxRiwayatPenyakitKeluarga.Text = "Ya" Then
            If TextBoxPenyakitRiwayatPenyakitKeluarga.Text = "" Then MsgBox("Cek Data Detail Riwayat Penyakit Keluarga.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        ElseIf (ComboBoxRiwayatPenyakitKeluarga.Text <> "Tidak" And ComboBoxRiwayatPenyakitKeluarga.Text <> "Ya") Then
            MsgBox("Cek Data Riwayat Penyakit Keluarga.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        End If

        '# Validasi Kebiasaan
        If cmbrokok.Text = "" Then MsgBox("Cek kembali kebiasaan rokok.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        If cmbalkohol.Text = "" Then MsgBox("Cek kembali kebiasaan alkohol.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        If cmbkopi.Text = "" Then MsgBox("Cek kembali kebiasaan kopi.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        If cmbpolamakan.Text = "" Then MsgBox("Cek kembali kebiasaan pola makan.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        If cmbistirahat.Text = "" Then MsgBox("Cek kembali kebiasaan istirahat.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        If cmbolahraga.Text = "" Then MsgBox("Cek kembali kebiasaan olahraga.", MsgBoxStyle.Exclamation, "Warning!") : Return False

        '# Validasi Riwayat Penyakit
        ' Hepatitis / Kuning
        If ComboBoxHepatitis.Text = "Ya" Then
            If DateTimeHepatitis.Value = "01-01-1900" Or ComboBoxListHepatitis.SelectedIndex = -1 Or DateTimeHepatitis.Value.Year > DateTime.Now.Year Then MsgBox("Inputan Detail Data Hepatitis / Kuning Tidak Valid.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        ElseIf ComboBoxHepatitis.Text <> "Tidak" And ComboBoxHepatitis.Text <> "Ya" Then
            MsgBox("Cek Data Hepatitis.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        End If

        ' TBC
        If ComboBoxTBC.Text = "Ya" Then
            If DateTimeTBC.Value = "01-01-1900" Or DateTimeTBC.Value.Year > DateTime.Now.Year Then MsgBox("Inputan Detail Data TBC Tidak Valid.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        ElseIf ComboBoxTBC.Text <> "Tidak" And ComboBoxTBC.Text <> "Ya" Then
            MsgBox("Cek Data TBC.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        End If

        ' Hernia
        If ComboBoxHernia.Text = "Ya" Then
            If DateTimeHernia.Value = "01-01-1900" Or DateTimeHernia.Value.Year > DateTime.Now.Year Then MsgBox("Inputan Detail Data Hernia Tidak Valid.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        ElseIf ComboBoxHernia.Text <> "Tidak" And ComboBoxHernia.Text <> "Ya" Then
            MsgBox("Cek Data Hernia.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        End If

        ' Hipertensi
        If ComboBoxHipertensi.Text = "Ya" Then
            If DateTimeHipertensi.Value = "01-01-1900" Or DateTimeHipertensi.Value.Year > DateTime.Now.Year Then MsgBox("Inputan Detail Data Hipertensi Tidak Valid.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        ElseIf ComboBoxHipertensi.Text <> "Tidak" And ComboBoxHipertensi.Text <> "Ya" Then
            MsgBox("Cek Data Hipertensi.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        End If

        ' Epilepsi
        If ComboBoxEpilepsi.Text = "Ya" Then
            If DateTimeEpilepsi.Value = "01-01-1900" Or DateTimeEpilepsi.Value.Year > DateTime.Now.Year Then MsgBox("Inputan Detail Data Epilepsi Tidak Valid.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        ElseIf ComboBoxEpilepsi.Text <> "Tidak" And ComboBoxEpilepsi.Text <> "Ya" Then
            MsgBox("Cek Data Epilepsi.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        End If

        ' Diabetes Mellitus
        If ComboBoxDiabetesMellitus.Text = "Ya" Then
            If DateTimeDiabetesMellitus.Value = "01-01-1900" Or DateTimeDiabetesMellitus.Value.Year > DateTime.Now.Year Then MsgBox("Inputan Detail Data Diabetes Mellitus Tidak Valid.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        ElseIf ComboBoxDiabetesMellitus.Text <> "Tidak" And ComboBoxDiabetesMellitus.Text <> "Ya" Then
            MsgBox("Cek kembali Diabetes.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        End If

        ' Paru (Non TBC)
        If ComboBoxParuNonTBC.Text = "Ya" Then
            If DateTimeParuNonTBC.Value = "01-01-1900" Or DateTimeParuNonTBC.Value.Year > DateTime.Now.Year Or ComboBoxListParuNonTBC.SelectedIndex = -1 Then MsgBox("Inputan Detail Paru (Non TBC) Tidak Valid.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        ElseIf ComboBoxParuNonTBC.Text <> "Tidak" And ComboBoxParuNonTBC.Text <> "Ya" Then
            MsgBox("Cek Data Paru (Non TBC).", MsgBoxStyle.Exclamation, "Warning!") : Return False
        End If

        ' Sakit Jantung
        If ComboBoxSakitJantung.Text = "Ya" Then
            If DateTimeSakitJantung.Value = "01-01-1900" Or DateTimeSakitJantung.Value.Year > DateTime.Now.Year Or ComboBoxListSakitJantung.SelectedIndex = -1 Then MsgBox("Inputan Detail Data Sakit Jantung Tidak Valid.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        ElseIf ComboBoxSakitJantung.Text <> "Tidak" And ComboBoxSakitJantung.Text <> "Ya" Then
            MsgBox("Cek Data Sakit Jantung.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        End If

        ' Gangguan Kulit
        If ComboBoxGangguanKulit.Text = "Ya" Then
            If DateTimeGangguanKulit.Value = "01-01-1900" Or DateTimeGangguanKulit.Value.Year > DateTime.Now.Year Then MsgBox("Inputan Detail Data Gangguan Kulit Tidak Valid.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        ElseIf ComboBoxGangguanKulit.Text <> "Tidak" And ComboBoxGangguanKulit.Text <> "Ya" Then
            MsgBox("Cek Data Gangguan Kulit.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        End If

        ' Malaria
        If ComboBoxMalaria.Text = "Ya" Then
            If DateTimeMalaria.Value = "01-01-1900" Or DateTimeMalaria.Value.Year > DateTime.Now.Year Then MsgBox("Inputan Detail Data Malaria Tidak Valid.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        ElseIf ComboBoxMalaria.Text <> "Tidak" And ComboBoxMalaria.Text <> "Ya" Then
            MsgBox("Cek Data Malaria.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        End If

        ' Ambeien / Hemoroid
        If ComboBoxAmbeien.Text = "Ya" Then
            If DateTimeAmbeien.Value = "01-01-1900" Or DateTimeAmbeien.Value.Year > DateTime.Now.Year Then MsgBox("Inputan Detail Data Ambeien / Hemoroid Tidak Valid.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        ElseIf ComboBoxAmbeien.Text <> "Tidak" And ComboBoxAmbeien.Text <> "Ya" Then
            MsgBox("Cek Data Ambeien.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        End If

        ' THT
        If ComboBoxTHT.Text = "Ya" Then
            If DateTimeTHT.Value = "01-01-1900" Or DateTimeTHT.Value.Year > DateTime.Now.Year Then MsgBox("Inputan Detail Data THT Tidak Valid.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        ElseIf ComboBoxTHT.Text <> "Tidak" And ComboBoxTHT.Text <> "Ya" Then
            MsgBox("Cek Data THT.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        End If

        ' Kencing Batu
        If ComboBoxKencingBatu.Text = "Ya" Then
            If DateTimeKencingBatu.Value = "01-01-1900" Or DateTimeKencingBatu.Value.Year > DateTime.Now.Year Then MsgBox("Inputan Detail Data Kencing Batu Tidak Valid.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        ElseIf ComboBoxKencingBatu.Text <> "Tidak" And ComboBoxKencingBatu.Text <> "Ya" Then
            MsgBox("Cek Data KencingBatu.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        End If

        ' Vertigo
        If ComboBoxVertigo.Text = "Ya" Then
            If DateTimeVertigo.Value = "01-01-1900" Or DateTimeVertigo.Value.Year > DateTime.Now.Year Then MsgBox("Inputan Detail Data Vertigo Tidak Valid.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        ElseIf ComboBoxVertigo.Text <> "Tidak" And ComboBoxVertigo.Text <> "Ya" Then
            MsgBox("Cek Data Vertigo.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        End If

        ' Anorexia
        If ComboBoxAnorexia.Text = "Ya" Then
            If DateTimeAnorexia.Value = "01-01-1900" Or DateTimeAnorexia.Value.Year > DateTime.Now.Year Then MsgBox("Inputan Detail Data Anorexia Tidak Valid.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        ElseIf ComboBoxAnorexia.Text <> "Tidak" And ComboBoxAnorexia.Text <> "Ya" Then
            MsgBox("Cek Data Anorexia.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        End If

        ' Pingsan
        If ComboBoxPingsan.Text = "Ya" Then
            If DateTimePingsan.Value = "01-01-1900" Or DateTimePingsan.Value.Year > DateTime.Now.Year Then MsgBox("Inputan Detail Data Pingsan Tidak Valid.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        ElseIf ComboBoxPingsan.Text <> "Tidak" And ComboBoxPingsan.Text <> "Ya" Then
            MsgBox("Cek Data Pingsan.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        End If

        ' Gastritis
        If ComboBoxGastritis.Text = "Ya" Then
            If DateTimeGastritis.Value = "01-01-1900" Or DateTimeGastritis.Value.Year > DateTime.Now.Year Then MsgBox("Inputan Detail Data Gastritis Tidak Valid.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        ElseIf ComboBoxGastritis.Text <> "Tidak" And ComboBoxGastritis.Text <> "Ya" Then
            MsgBox("Cek Data Gastritis.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        End If

        ' Pusing
        If ComboBoxPusing.Text = "Ya" Then
            If DateTimePusing.Value = "01-01-1900" Or DateTimePusing.Value.Year > DateTime.Now.Year Then MsgBox("Inputan Detail Data Pusing Tidak Valid.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        ElseIf ComboBoxPusing.Text <> "Tidak" And ComboBoxPusing.Text <> "Ya" Then
            MsgBox("Cek Data Pusing.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        End If

        ' Typoid Fever
        If ComboBoxTypoidFever.Text = "Ya" Then
            If DateTimeTypoidFever.Value = "01-01-1900" Or DateTimeTypoidFever.Value.Year > DateTime.Now.Year Then MsgBox("Inputan Detail Data Typoid Fever Tidak Valid.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        ElseIf ComboBoxTypoidFever.Text <> "Tidak" And ComboBoxTypoidFever.Text <> "Ya" Then
            MsgBox("Cek Data TypoidFever.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        End If

        ' Turun BB
        If ComboBoxTurunBB.Text = "Ya" Then
            If DateTimeTurunBB.Value = "01-01-1900" Or DateTimeTurunBB.Value.Year > DateTime.Now.Year Then MsgBox("Inputan Detail Data Turun BB Tidak Valid.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        ElseIf ComboBoxTurunBB.Text <> "Tidak" And ComboBoxTurunBB.Text <> "Ya" Then
            MsgBox("Cek Data TurunBB.", MsgBoxStyle.Exclamation, "Warning!") : Return False
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
        'Dim varStatusTBC As Boolean = False
        'Dim varStatusRectalToucher As Boolean = False

        ' Set Status Kesehatan
        Dim varStatusKesehatanUnfit As Boolean = False
        Dim varStatusKesehatanUnfitSementara As Boolean = False
        Dim varStatusKesehatanFitDenganCatatan As Boolean = False


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

            ' Set Status Kesehatan Unfit
            varStatusKesehatanUnfit = True
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

        If ComboBoxVisusMata1.Text = "Visus dgn kacamata" Then
            Dim keteranganKoreksiAkhir As String = ""
            Dim statusVisusNormal As Boolean = False

            If TextBoxVisusTanpaKacamataOD.Text = "6/6" And TextBoxVisusTanpaKacamataOS.Text = "6/6" Then
                keteranganKoreksiAkhir = "ODS: " & TextBoxVisusTanpaKacamataOD.Text & " (Dalam Batas Normal)"
                statusVisusNormal = True
            ElseIf TextBoxVisusTanpaKacamataOD.Text <> "6/6" And TextBoxVisusTanpaKacamataOS.Text = "6/6" Then
                If TextBoxVisusKacamataOD.Text.Trim = "" Or TextBoxVisusKacamataOS.Text.Trim = "" Then
                    keteranganKoreksiAkhir = "OD: " & TextBoxVisusTanpaKacamataOD.Text & ", OS: " & TextBoxVisusTanpaKacamataOS.Text & " (Kelainan Refraksi Mata Kanan)"
                ElseIf TextBoxVisusKacamataOD.Text = "6/6" Then
                    keteranganKoreksiAkhir = "ODS: " & TextBoxVisusKacamataOD.Text & " (Kelainan Refraksi Mata Kanan Terkoreksi)"
                    statusVisusNormal = True
                ElseIf TextBoxVisusKacamataOD.Text <> "6/6" Then
                    keteranganKoreksiAkhir = "OD: " & TextBoxVisusKacamataOD.Text & ", OS: " & TextBoxVisusKacamataOS.Text & " (Kelainan Refraksi Mata Kanan Belum Terkoreksi)"
                End If
            ElseIf TextBoxVisusTanpaKacamataOD.Text = "6/6" And TextBoxVisusTanpaKacamataOS.Text <> "6/6" Then
                If TextBoxVisusKacamataOD.Text.Trim = "" Or TextBoxVisusKacamataOS.Text.Trim = "" Then
                    keteranganKoreksiAkhir = "OD: " & TextBoxVisusTanpaKacamataOD.Text & ", OS: " & TextBoxVisusTanpaKacamataOS.Text & " (Kelainan Refraksi Mata Kiri)"
                ElseIf TextBoxVisusKacamataOS.Text = "6/6" Then
                    keteranganKoreksiAkhir = "ODS: " & TextBoxVisusKacamataOS.Text & " (Kelainan Refraksi Mata Kiri Terkoreksi)"
                    statusVisusNormal = True
                ElseIf TextBoxVisusKacamataOS.Text <> "6/6" Then
                    keteranganKoreksiAkhir = "OD: " & TextBoxVisusKacamataOD.Text & ", OS: " & TextBoxVisusKacamataOS.Text & " (Kelainan Refraksi Mata Kiri Belum Terkoreksi)"
                End If
            ElseIf TextBoxVisusTanpaKacamataOD.Text <> "6/6" And TextBoxVisusTanpaKacamataOS.Text <> "6/6" Then
                If TextBoxVisusKacamataOD.Text.Trim = "" Or TextBoxVisusKacamataOS.Text.Trim = "" Then
                    If TextBoxVisusTanpaKacamataOD.Text = TextBoxVisusTanpaKacamataOS.Text Then
                        keteranganKoreksiAkhir = "ODS: " & TextBoxVisusTanpaKacamataOD.Text & " (Kelainan Refraksi Mata Kanan & Kiri)"
                    Else
                        keteranganKoreksiAkhir = "OD: " & TextBoxVisusTanpaKacamataOD.Text & ", OS: " & TextBoxVisusTanpaKacamataOS.Text & " (Kelainan Refraksi Mata Kanan & Kiri)"
                    End If
                ElseIf TextBoxVisusKacamataOS.Text = "6/6" And TextBoxVisusKacamataOD.Text = "6/6" Then
                    keteranganKoreksiAkhir = "ODS: " & TextBoxVisusKacamataOD.Text & " (Kelainan Refraksi Mata Kanan & Kiri Terkoreksi)"
                    statusVisusNormal = True
                ElseIf TextBoxVisusKacamataOS.Text <> "6/6" And TextBoxVisusKacamataOD.Text = "6/6" Then
                    keteranganKoreksiAkhir = "OD: " & TextBoxVisusKacamataOD.Text & ", OS: " & TextBoxVisusKacamataOS.Text & " (Kelainan Refraksi Mata Kiri Belum Terkoreksi)"
                ElseIf TextBoxVisusKacamataOS.Text = "6/6" And TextBoxVisusKacamataOD.Text <> "6/6" Then
                    keteranganKoreksiAkhir = "OD: " & TextBoxVisusKacamataOD.Text & ", OS: " & TextBoxVisusKacamataOS.Text & " (Kelainan Refraksi Mata Kanan Belum Terkoreksi)"
                ElseIf TextBoxVisusKacamataOS.Text <> "6/6" And TextBoxVisusKacamataOD.Text <> "6/6" Then
                    If TextBoxVisusKacamataOD.Text.Trim = TextBoxVisusKacamataOS.Text.Trim Then
                        keteranganKoreksiAkhir = "ODS: " & TextBoxVisusKacamataOD.Text & " (Kelainan Refraksi Mata Kanan & Kiri Belum Terkoreksi)"
                    Else
                        keteranganKoreksiAkhir = "OD: " & TextBoxVisusKacamataOD.Text & ", OS: " & TextBoxVisusKacamataOS.Text & " (Kelainan Refraksi Mata Kanan & Kiri Belum Terkoreksi)"
                    End If
                End If
            End If

            If statusVisusNormal = False Then
                If TextBoxVisusKacamataOD.Text.Trim = "" Or TextBoxVisusKacamataOS.Text.Trim = "" Then
                    displayKeteranganTidakNormal = SetKeterangan(keteranganKoreksiAkhir, "Tidak Normal", displayKeteranganTidakNormal, "Visus Mata")
                Else
                    displayKeteranganTidakNormal = SetKeterangan(keteranganKoreksiAkhir, "Tidak Normal", displayKeteranganTidakNormal, "Koreksi Akhir Mata")
                End If

                displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
            End If

            txkoreksiakhir.Text = keteranganKoreksiAkhir
        ElseIf ComboBoxVisusMata1.Text = "Visus Mata" Then
            'Set Visus Mata (Autorefraksi)

        End If

        'If ComboBoxVisusMata1.Text = "Visus dgn kacamata" Then
        '    'Set Visus Mata
        '    Dim ketvisuskacamata As String = ""
        '    Dim ketvisustanpakacamata As String = ""
        '    Dim statusVisusTanpaKacaMataNormal As Boolean = False
        '    Dim statusVisusKacaMataNormal As Boolean = False
        '    Dim statusKoreksi As String = ""

        '    Dim keteranganKoreksiAkhir As String = ""

        '    ' Tanpa Kacamata
        '    If TextBoxVisusTanpaKacamataOD.Text = "6/6" And TextBoxVisusTanpaKacamataOS.Text = "6/6" Then
        '        ketvisustanpakacamata = "ODS: " & TextBoxVisusTanpaKacamataOD.Text & " (Dalam Batas Normal)"
        '        statusVisusTanpaKacaMataNormal = True
        '        keteranganKoreksiAkhir = "Dalam Batas Normal"
        '    ElseIf TextBoxVisusTanpaKacamataOD.Text <> "6/6" And TextBoxVisusTanpaKacamataOS.Text = "6/6" Then
        '        ketvisustanpakacamata = "OD: " & TextBoxVisusTanpaKacamataOD.Text & ", OS: " & TextBoxVisusTanpaKacamataOS.Text & " (Kelainan Refraksi Mata Kanan)"
        '        keteranganKoreksiAkhir = "Kelainan Refraksi Mata Kanan"
        '    ElseIf TextBoxVisusTanpaKacamataOD.Text = "6/6" And TextBoxVisusTanpaKacamataOS.Text <> "6/6" Then
        '        ketvisustanpakacamata = "OD: " & TextBoxVisusTanpaKacamataOD.Text & ", OS: " & TextBoxVisusTanpaKacamataOS.Text & " (Kelainan Refraksi Mata Kiri)"
        '        keteranganKoreksiAkhir = "Kelainan Refraksi Mata Kiri"
        '    ElseIf TextBoxVisusTanpaKacamataOD.Text <> "6/6" And TextBoxVisusTanpaKacamataOS.Text <> "6/6" Then
        '        If TextBoxVisusTanpaKacamataOD.Text = TextBoxVisusTanpaKacamataOS.Text Then
        '            ketvisustanpakacamata = "ODS: " & TextBoxVisusTanpaKacamataOD.Text & " (Kelainan Refraksi Mata Kanan & Kiri)"
        '        Else
        '            ketvisustanpakacamata = "OD: " & TextBoxVisusTanpaKacamataOD.Text & ", OS: " & TextBoxVisusTanpaKacamataOS.Text & " (Kelainan Refraksi Mata Kanan & Kiri)"
        '        End If

        '        keteranganKoreksiAkhir = "Kelainan Refraksi Mata Kanan & Kiri"
        '    End If

        '    ' Dengan Kacamata
        '    If TextBoxVisusKacamataOD.Text = "6/6" And TextBoxVisusKacamataOS.Text = "6/6" Then
        '        ketvisuskacamata = "ODS: " & TextBoxVisusKacamataOD.Text
        '    ElseIf TextBoxVisusKacamataOD.Text <> "6/6" And TextBoxVisusKacamataOS.Text = "6/6" Then
        '        ketvisuskacamata = "OD: " & TextBoxVisusKacamataOD.Text & ", OS: " & TextBoxVisusKacamataOS.Text
        '    ElseIf TextBoxVisusKacamataOD.Text = "6/6" And TextBoxVisusKacamataOS.Text <> "6/6" Then
        '        ketvisuskacamata = "OD: " & TextBoxVisusKacamataOD.Text & ", OS: " & TextBoxVisusKacamataOS.Text
        '    ElseIf TextBoxVisusKacamataOD.Text <> "6/6" And TextBoxVisusKacamataOS.Text <> "6/6" Then
        '        If TextBoxVisusKacamataOD.Text = TextBoxVisusKacamataOS.Text Then
        '            ketvisuskacamata = "ODS: " & TextBoxVisusKacamataOD.Text
        '        Else
        '            ketvisuskacamata = "OD: " & TextBoxVisusKacamataOD.Text & ", OS: " & TextBoxVisusKacamataOS.Text
        '        End If
        '    End If

        '    If TextBoxVisusKacamataOD.Text = "6/6" And TextBoxVisusKacamataOS.Text = "6/6" Then
        '        'ketvisuskacamata = ketvisustanpakacamata.Replace(")", "") & " Terkoreksi)"
        '        ketvisuskacamata = ketvisuskacamata & " (" & keteranganKoreksiAkhir & " Terkoreksi)"
        '        statusVisusKacaMataNormal = True
        '    Else
        '        'ketvisuskacamata = ketvisustanpakacamata.Replace(")", "") & " Belum Terkoreksi)"
        '        ketvisuskacamata = ketvisuskacamata & " (" & keteranganKoreksiAkhir & " Belum Terkoreksi)"
        '    End If

        '    If TextBoxVisusKacamataOD.Text = "" And TextBoxVisusKacamataOS.Text = "" Then
        '        If statusVisusTanpaKacaMataNormal = True Then
        '            txkoreksiakhir.Text = ketvisustanpakacamata
        '        Else
        '            displayKeteranganTidakNormal = SetKeterangan(ketvisustanpakacamata, "Tidak Normal", displayKeteranganTidakNormal, "Visus Mata")
        '            displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
        '            txkoreksiakhir.Text = ketvisustanpakacamata
        '        End If
        '    Else
        '        If statusVisusKacaMataNormal = True Then
        '            txkoreksiakhir.Text = ketvisuskacamata
        '        Else
        '            displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
        '            displayKeteranganTidakNormal = SetKeterangan(ketvisuskacamata, "Tidak Normal", displayKeteranganTidakNormal, "Koreksi Akhir Mata")
        '            txkoreksiakhir.Text = ketvisuskacamata
        '        End If
        '    End If
        'ElseIf ComboBoxVisusMata1.Text = "Visus Mata" Then
        '    'Set Visus Mata (Autorefraksi)

        'End If

        'Set Kebiasaan
        If cmbrokok.Text <> "" And cmbrokok.Text <> "Tidak" Then displaySaranTidakNormal = SetSaran("Berhenti merokok.", "Tidak Normal", displaySaranTidakNormal)
        If cmbalkohol.Text <> "" And cmbalkohol.Text <> "Tidak" Then displaySaranTidakNormal = SetSaran("Berhenti minum alkohol.", "Tidak Normal", displaySaranTidakNormal)
        If cmbkopi.Text <> "" And cmbkopi.Text = "Ya, Banyak" Then displaySaranTidakNormal = SetSaran("Kurangi konsumsi kopi.", "Tidak Normal", displaySaranTidakNormal)
        If cmbpolamakan.Text <> "" And cmbpolamakan.Text <> "Teratur" Then displaySaranTidakNormal = SetSaran("Jaga pola makan yang teratur.", "Tidak Normal", displaySaranTidakNormal)
        If cmbistirahat.Text <> "" And cmbistirahat.Text <> "Teratur" Then displaySaranTidakNormal = SetSaran("Istirahat yang cukup.", "Tidak Normal", displaySaranTidakNormal)
        If cmbolahraga.Text <> "" And cmbolahraga.Text <> "Teratur" Then displaySaranTidakNormal = SetSaran("Olahraga yang teratur.", "Tidak Normal", displaySaranTidakNormal)

        ' Set Riwayat (Mempengaruhi Hasil Fit)
        If ComboBoxHepatitis.Text <> "" And ComboBoxHepatitis.Text <> "Tidak" Then
            Dim riwayatHepatitis As String = "Hepatitits (Jenis: " & ComboBoxListHepatitis.Text & ")"

            If CheckBoxSembuhHepatitis.Checked = False Then
                displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
                varStatusKesehatanUnfitSementara = True
            End If

            displayRiwayat = SetRiwayat(riwayatHepatitis, displayRiwayat)
        End If

        If ComboBoxHernia.Text <> "" And ComboBoxHernia.Text <> "Tidak" Then
            If CheckBoxSembuhHernia.Checked = False Then displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
            displayRiwayat = SetRiwayat("Hernia", displayRiwayat)
        End If

        If ComboBoxHipertensi.Text <> "" And ComboBoxHipertensi.Text <> "Tidak" Then
            If CheckBoxSembuhHipertensi.Checked = False Then
                displaySaranTidakNormal = SetSaran("Batasi konsumsi natrium / garam.", "Tidak Normal", displaySaranTidakNormal)
                varStatusKesehatanFitDenganCatatan = True
            End If

            displayRiwayat = SetRiwayat("Hipertensi", displayRiwayat)
        End If

        If ComboBoxEpilepsi.Text <> "" And ComboBoxEpilepsi.Text <> "Tidak" Then
            If CheckBoxSembuhEpilepsi.Checked = False Then
                displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
                varStatusKesehatanUnfitSementara = True
            End If

            displayRiwayat = SetRiwayat("Epilepsi", displayRiwayat)
        End If

        If ComboBoxDiabetesMellitus.Text <> "" And ComboBoxDiabetesMellitus.Text <> "Tidak" Then
            If CheckBoxSembuhDiabetesMellitus.Checked = False Then
                displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
                varStatusKesehatanFitDenganCatatan = True
            End If

            displayRiwayat = SetRiwayat("Diabetes Mellitus", displayRiwayat)
        End If

        If ComboBoxParuNonTBC.Text <> "" And ComboBoxParuNonTBC.Text <> "Tidak" Then
            Dim riwayatParuNonTbc As String = "Penyakit Paru Non TBC (" & ComboBoxListParuNonTBC.Text & ")"

            If CheckBoxSembuhParuNonTBC.Checked = False Then
                displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)

                If ComboBoxListParuNonTBC.Text = "Bronkopneumonia" Or ComboBoxListParuNonTBC.Text = "Asma Bronkial" Then
                    varStatusKesehatanFitDenganCatatan = True
                ElseIf ComboBoxListParuNonTBC.Text = "Kanker Paru" Or ComboBoxListParuNonTBC.Text = "Pneumonia" Then
                    varStatusKesehatanUnfitSementara = True
                End If
            End If

            displayRiwayat = SetRiwayat(riwayatParuNonTbc, displayRiwayat)
        End If

        If ComboBoxSakitJantung.Text <> "" And ComboBoxSakitJantung.Text <> "Tidak" Then
            Dim riwayatSakitJantung As String = "Sakit Jantung (" & ComboBoxListSakitJantung.Text & ")"

            If CheckBoxSembuhSakitJantung.Checked = False Then
                displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
                varStatusKesehatanFitDenganCatatan = True
            End If

            displayRiwayat = SetRiwayat(riwayatSakitJantung, displayRiwayat)
        End If

        If ComboBoxTBC.Text <> "" And ComboBoxTBC.Text <> "Tidak" Then
            'Dim Ttbc As Date = DateSerial(DateTimeTBC.Value.Year, DateTimeTBC.Value.Month, DateTimeTBC.Value.Day).AddMonths(6)
            'If Ttbc > Date.Now Then varStatusKesehatanUnfitSementara = True

            If CheckBoxSembuhTBC.Checked = False Then
                varStatusKesehatanUnfitSementara = True
                displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
            End If

            displayRiwayat = SetRiwayat("TBC", displayRiwayat)
        End If

        If ComboBoxMalaria.Text = "Ya" Then
            If CheckBoxSembuhMalaria.Checked = False Then
                displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
                varStatusKesehatanFitDenganCatatan = True
            End If

            displayRiwayat = SetRiwayat("Malaria", displayRiwayat)
        End If

        If ComboBoxTypoidFever.Text = "Ya" Then
            If CheckBoxSembuhTypoidFever.Checked = False Then
                displaySaranTidakNormal = SetSaran("Konsultasi ke dokter.", "Tidak Normal", displaySaranTidakNormal)
                varStatusKesehatanFitDenganCatatan = True
            End If

            displayRiwayat = SetRiwayat("Typoid Fever", displayRiwayat)
        End If

        ' Set Riwayat (Tidak Mempengaruhi Hasil Fit)
        If ComboBoxGangguanKulit.Text = "Ya" Then displayRiwayat = SetRiwayat("Gangguan Kulit", displayRiwayat)
        If ComboBoxAmbeien.Text = "Ya" Then displayRiwayat = SetRiwayat("Ambeien / Hemoroid", displayRiwayat)
        If ComboBoxTHT.Text = "Ya" Then displayRiwayat = SetRiwayat("Gangguan THT > 4 minggu", displayRiwayat)
        If ComboBoxKencingBatu.Text = "Ya" Then displayRiwayat = SetRiwayat("Kencing Batu", displayRiwayat)
        If ComboBoxVertigo.Text = "Ya" Then displayRiwayat = SetRiwayat("Vertigo / Pusing Berputar", displayRiwayat)
        If ComboBoxAnorexia.Text = "Ya" Then displayRiwayat = SetRiwayat("Anorexia > 4 minggu", displayRiwayat)
        If ComboBoxPingsan.Text = "Ya" Then displayRiwayat = SetRiwayat("Pernah Pingsan", displayRiwayat)
        If ComboBoxGastritis.Text = "Ya" Then displayRiwayat = SetRiwayat("Gastritis / Sakit Lambung", displayRiwayat)
        If ComboBoxPusing.Text = "Ya" Then displayRiwayat = SetRiwayat("Sering Pusing / Nyeri Kepala", displayRiwayat)
        If ComboBoxTurunBB.Text = "Ya" Then displayRiwayat = SetRiwayat("BB turun > 5 Kg / bln", displayRiwayat)

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
        If varStatusKesehatanUnfit = True Then
            varStatusKesehatan = "UNFIT"
        ElseIf varStatusKesehatanUnfitSementara = True Then
            varStatusKesehatan = "UNFIT SEMENTARA"
        ElseIf varStatusKesehatanFitDenganCatatan = True Or totalKetTidakNormal > 0 Then
            varStatusKesehatan = "FIT DENGAN CATATAN"
        ElseIf totalKetTidakNormal = 0 Then
            varStatusKesehatan = "FIT"
        End If

        'Set Status Fit / Unfit
        'If varStatusRectalToucher = True Then
        '    varStatusKesehatan = "UNFIT"
        'ElseIf totalKetTidakNormal = 0 And totalRiwayat = 0 Then
        '    varStatusKesehatan = "FIT"
        'ElseIf totalKetTidakNormal > 0 And varStatusTBC = False Then
        '    varStatusKesehatan = "FIT DENGAN CATATAN"
        'ElseIf totalKetTidakNormal > 0 And varStatusTBC = True Then
        '    varStatusKesehatan = "UNFIT SEMENTARA"
        'ElseIf totalKetTidakNormal = 0 And varStatusTBC = False Then
        '    varStatusKesehatan = "FIT"
        'ElseIf totalKetTidakNormal = 0 And varStatusTBC = True Then
        '    varStatusKesehatan = "UNFIT SEMENTARA"
        'End If

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

        txstatusfit.Text = varStatusKesehatan
    End Sub

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

        'If displayRiwayat.Contains("" & VarRiwayat & "") = False Then
        totalRiwayat = totalRiwayat + 1
        Riwayat = displayRiwayat + VarRiwayat + ", "
        'End If

        Return Riwayat
    End Function

    Function ValueKesimpulan(ByVal VarKesimpulan As String) As String
        Dim NewValue As String = Strings.Replace(Strings.Replace(Strings.Replace(VarKesimpulan, ".", ""), "~", ""), "Lainnya", "")

        Return NewValue
    End Function

    Private Sub setdatefisik()
        ' Riwayat Kesehatan
        DateTimeRiwayatOperasi.Value = "01-01-1900"
        DateTimeRiwayatRumahSakit.Value = "01-01-1900"
        DateTimeRiwayatPengobatanPenyakit.Value = "01-01-1900"
        DateTimeRiwayatPenggunaNarkoba.Value = "01-01-1900"

        ' Daftar Riwayat Penyakit
        DateTimeHepatitis.Value = "01-01-1900"
        DateTimeTBC.Value = "01-01-1900"
        DateTimeHernia.Value = "01-01-1900"
        DateTimeHipertensi.Value = "01-01-1900"
        DateTimeEpilepsi.Value = "01-01-1900"
        DateTimeDiabetesMellitus.Value = "01-01-1900"
        DateTimeParuNonTBC.Value = "01-01-1900"
        DateTimeSakitJantung.Value = "01-01-1900"
        DateTimeGangguanKulit.Value = "01-01-1900"
        DateTimeMalaria.Value = "01-01-1900"
        DateTimeAmbeien.Value = "01-01-1900"
        DateTimeTHT.Value = "01-01-1900"
        DateTimeKencingBatu.Value = "01-01-1900"
        DateTimeVertigo.Value = "01-01-1900"
        DateTimeAnorexia.Value = "01-01-1900"
        DateTimePingsan.Value = "01-01-1900"
        DateTimeGastritis.Value = "01-01-1900"
        DateTimePusing.Value = "01-01-1900"
        DateTimeTypoidFever.Value = "01-01-1900"
        DateTimeTurunBB.Value = "01-01-1900"
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

        Dim Tlab As DataTable = ReadThemysql("SELECT a.SendingWhatsapp, a.SendingEmail, a.Kesimpulan, a.Saran, b.PTNIK, b.NIP, a.caraambil, a.dokterrequest " & _
                                             "FROM transaksilab a " & _
                                             "LEFT JOIN masterpasien b ON a.idpasien=b.nomitra AND a.idtempatlab=b.cabang " & _
                                             "WHERE idlabinternet='" & idTransaksi & "' AND idtempatlab='" & kodeLokasi & "'", DB_Poliklinik)
        Dim TrowLab As DataRow = Tlab.Rows(0)
        Dim Tsimpul As String = ""
        Dim Tsaran As String = ""
        Dim noNIK As String = ""
        Dim nip As String = ""
        Dim Pengirim As String = ""
        If IsDBNull(TrowLab("PTNIK")) = False Then noNIK = TrowLab("PTNIK") Else noNIK = "-"
        If IsDBNull(TrowLab("NIP")) = False And TrowLab("NIP").ToString <> "-" And TrowLab("NIP").ToString <> "" Then nip = TrowLab("NIP") Else nip = "-"
        Dim DrRequest As String = TrowLab("dokterrequest")
        Dim caraambil As String = TrowLab("caraambil")
        If CheckSQL("select * from mastercompany where NoCompany = '" & txcodepenagihan.Text.Trim & "' and ReportHasilPerusahaan = 0") = True And TextBoxNoTransaksi.Text.Contains("M") = True Then
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
            Trow("barcodenotrans") = idTransaksi
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

            ' Penambahan NIP
            If nip <> "-" Then
                Trow("Alamat") = txalamat.Text & " / " & nip
            Else
                Trow("Alamat") = txalamat.Text
            End If

            Trow("NoTransaksi") = TextBoxNoTransaksi.Text & " (" & idTransaksi & ")"
            Trow("DrPelaksana") = DrPelaksanaKlinik
            Trow("Hasil") = caraambil

            If Pengirim <> "" Then
                Trow("DrRequest") = Pengirim
            Else
                If IsNumeric(DrRequest.ToString.Trim) = True Or DrRequest.ToString.Trim = "" Or TextBoxNoTransaksi.Text.Contains("M") Then
                    Trow("DrRequest") = txpenagihan.Text.Trim
                Else
                    Trow("DrRequest") = DrRequest
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

        ' Set QR
        ' Aktifkan Jika Ingin ada QR di hasil
        'Report.Bands(BandKind.PageFooter).Controls.Add(CreateXRPictureBox(70, 0, 160, 85))
        'Report.Bands.Item(BandKind.PageFooter).Controls("QR_Hasil").BringToFront()

        Report.DataSource = Tbls
        Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MM-yyyy HH:mm:ss") + " by " + UserLabAdminOnline

        If Action = "Preview" Then
            'Report.RunDesigner()
            Report.ShowPreview()
        ElseIf Action = "Print" Then
            Report.Print()
            'Report.RunDesigner()
        ElseIf Action = "Nothing" Then
            ''Save PDF
            'Dim NameFile As String = txtindakanid.Text & "_Hasil_Laboratorium"
            'Dim filepath As String = "FileDownload\Hasil\" & NameFile & ".pdf"
            'If File.Exists(filepath) Then
            '    My.Computer.FileSystem.DeleteFile(filepath)
            'End If
            'Report.CreatePdfDocument(filepath)

            'If QR_Code_Trans.Image Is Nothing = False And CekKoneksi("SHOW TABLES FROM " & Tqrcon.Tdb & "", Tqrcon) = True Then
            '    'Set Nama File di Online
            '    Dim KodeBarcode As String = ReadSQLNIK("select StrValue from MsConfig where ConfigName='KodeBarcode'")
            '    Dim txQR As String = KodeBarcode & NameFile

            '    'CreateBase64
            '    Dim Base64Inv As String = ""
            '    Base64Inv = Convert.ToBase64String(System.IO.File.ReadAllBytes(filepath))

            '    'Send Base64 to Online
            '    WriteThemysql("REPLACE INTO QR_HasilLaboratorium (NameFile, FileBase64, createdate, createby)  " & _
            '                                          "VALUES('" & txQR & "', '" & Base64Inv & "', NOW(), '" & UserLabAdmin & "') ", Tqrcon)
            'End If
        End If

        If Action <> "Nothing" Then
            If CountResultEmpty = 0 Then
                WriteThemysql("update transaksilab set tglcetakhasil=now(), labcetak=now() , Status='TAKEIT' , usercetakhasil='" & UserLabAdminOnline & "' ,closedinputhasil=1 where idlabinternet='" & idTransaksi & "'", DB_Poliklinik)
            End If
        End If

        If Action <> "Nothing" Then
            Dim TboolEmail As Boolean = True
            Dim TboolWhatsapp As Boolean = True
            If Utility.GetConfig("Email") = "No" Then TboolEmail = False
            If Utility.GetConfig("Whatsapp") = "No" Then TboolWhatsapp = False
            Dim NameFile As String = TextBoxNoTransaksi.Text & "_Hasil_Laboratorium_" & idTransaksi.Trim
            Dim filepath As String = "FileDownload\Hasil_Online\" & NameFile & ".pdf"

            If TboolEmail = False And TboolWhatsapp = False Then
                'Nothing
            Else
                If File.Exists(filepath) = False And (caraambil.Contains("Email") = True Or caraambil.Contains("Whatsapp") = True) Then
                    SendingWhatsappEmailToolStripMenuItem.PerformClick()
                ElseIf File.Exists(filepath) = False Then
                    Dim NoUrut As String = TextBoxNoTransaksi.Text
                    Dim Tcompany As DataTable = ReadSQL("select No_Handphone2, No_Handphone, Email_Perusahaan, TerimaHasilKaryawan, Whatsapp_Auto, Email_Auto from mastercompany where NoCompany='" & txcodepenagihan.Text.Trim & "'")
                    If Tcompany.Rows.Count > 0 Then
                        Dim TrowCompany As DataRow = Tcompany.Rows(0)
                        If (TrowCompany("TerimaHasilKaryawan") = True And TrowCompany("Whatsapp_Auto") = True And NoUrut.Contains("L") = True) Or (TrowCompany("Whatsapp_Auto") = True And NoUrut.Contains("M") = True) And TboolWhatsapp = True Then
                            SendingWhatsappEmailToolStripMenuItem.PerformClick()
                        ElseIf (TrowCompany("TerimaHasilKaryawan") = True And TrowCompany("Email_Auto") = True And NoUrut.Contains("L") = True) Or (TrowCompany("Email_Auto") = True And NoUrut.Contains("M") = True) And TboolEmail = True Then
                            SendingWhatsappEmailToolStripMenuItem.PerformClick()
                        End If

                        If TrowCompany("No_Handphone2").ToString.Trim <> "" And TrowCompany("No_Handphone2").ToString.Trim <> "0" And TrowCompany("No_Handphone2").ToString.Trim <> "-" And TboolWhatsapp = True Then
                            SendingWhatsappEmailToolStripMenuItem.PerformClick()
                        End If
                    End If
                End If
            End If
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

    Private Sub ButtonSaveECG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSaveECG.Click
        Dim Tbls As DataTable = gridlab.DataSource

        If cmbecg.FindStringExact(cmbecg.Text) < 0 Then
            MsgBox("Pilih dokter Spiro yang memeriksa")
            cmbecg.Focus()
            Exit Sub
        End If

        For Each Nnew As DataRow In Tbls.Rows
            If Strings.LCase(Nnew("NamaTindakan").ToString).Contains("ecg") = True Then
                If CheckThemysql("select * from transaksilabhasillain where NoUrut='" & TextBoxNoTransaksi.Text & "' and idlabinternet='" & idTransaksi & "'", DB_Poliklinik) = True Then
                    WriteThemysql("update transaksilabhasillain set  Tekanan='" & txecgtekanan.Text & "', DiagnosisECG='" & txhasilecg.Text & "', ECGDate=NOW(),ECGBy='" & UserLabAdminOnline & "' , DrECG='" & cmbecg.Text & "' where NoUrut='" & TextBoxNoTransaksi.Text & "' and idlabinternet='" & idTransaksi & "'", DB_Poliklinik)
                Else
                    WriteThemysql("insert transaksilabhasillain(NoUrut,Tekanan,DiagnosisECG,ECGDate,ECGBy,idlabinternet) values('" & TextBoxNoTransaksi.Text & "','" & txecgtekanan.Text & "','" & txhasilecg.Text & "',NOW(),'" & UserLabAdminOnline & "', '" & idTransaksi & "')", DB_Poliklinik)
                End If
                MsgBox("Data ECG Saved")
                Exit For
            End If
        Next
    End Sub

    Private Sub ButtonPrintECG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPrintECG.Click
        If CheckThemysql("select * from transaksilabhasillain where NoUrut='" & TextBoxNoTransaksi.Text & "' and idlabinternet='" & idTransaksi & "'", DB_Poliklinik) Then
            Dim Tlab As DataTable = ReadThemysql("SELECT a.Kesimpulan, a.Saran, b.PTNIK, a.caraambil, a.dokterrequest from transaksilab a LEFT JOIN masterpasien b ON a.idpasien=b.nomitra AND a.idtempatlab=b.cabang where idlabinternet='" & idTransaksi & "' AND idtempatlab='" & kodeLokasi & "'", DB_Poliklinik)
            Dim TrowLab As DataRow = Tlab.Rows(0)
            Dim Tsimpul As String = TrowLab("Kesimpulan")
            Dim Tsaran As String = TrowLab("Saran")
            Dim ptnik As String = TrowLab("PTNIK")
            Dim DrRequest As String = TrowLab("dokterrequest")
            Dim caraambil As String = TrowLab("caraambil")

            Dim Tempecg As DataTable = ReadThemysql("select * from transaksilabhasillain where NoUrut='" & TextBoxNoTransaksi.Text & "' and idlabinternet='" & idTransaksi & "'", DB_Poliklinik)
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
                Trow("Nama") = TextBoxGelar.Text & " " & TextBoxNamaPasien.Text & "/(" & TextBoxJenisKelamin.Text & ")"
                Dim Tgltemp As Date = DateTimeTanggalLahir.Value
                If Tgltemp.Date.AddYears(120).Year < DateAndTime.Now.Year Then
                    Trow("Umur") = ""
                Else
                    Trow("Umur") = Format(DateTimeTanggalLahir.Value, "dd MMM yyyy") & " / " & TextBoxUmur.Text
                End If
                Trow("Alamat") = txalamat.Text
                Trow("NoTransaksi") = TextBoxNoTransaksi.Text & " (" & idTransaksi & ")"
                Trow("DrPelaksana") = DrPelaksanaKlinik

                If IsNumeric(DrRequest.ToString.Trim) = True Or DrRequest.ToString.Trim = "" Then
                    Trow("DrRequest") = ReadThemysqlNIK("select b.CompanyNama from transaksilab c inner join masterpasien a on c.idpasien=a.nomitra inner join mitramed_poliklinik.mastercompany b on a.PTID=b.NoCompany where c.idpasien='" & TextBoxNoRekamMedis.Text & "' AND a.cabang='" & kodeLokasi & "' LIMIT 1", DB_Poliklinik)
                Else
                    Trow("DrRequest") = DrRequest
                End If

                Trow("Tanggal") = Format(DateTimeTanggalTransaksi.Value, "dd-MMM-yyyy")
            Next

            Report = New XtraReport
            Report = XtraReport.FromFile(Application.StartupPath + "\reports\PrintHasilLabECG.repx", True)
            Report.DataSource = Tempecg
            Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:ss") + UserLabAdminOnline
            'Report.Bands.Item(BandKind.PageHeader).Controls("DokterECG").Text = ReadSQLNIK("select StrValue from msconfig where ConfigName='DokterECG'")
            Report.Bands.Item(BandKind.PageHeader).Controls("DokterECG").Text = ReadThemysqlNIK("select DrECG from transaksilabhasillain where NoUrut='" & TextBoxNoTransaksi.Text & "' and idlabinternet='" & idTransaksi & "'", DB_Poliklinik)

            'Report.RunDesigner()
            Report.ShowPreview()
            'Report.Print()
        End If
    End Sub

    Private Sub txvisuskacamata_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxVisusKacamataOD.KeyPress
        If e.KeyChar = ","c Then e.Handled = True
    End Sub

    Private Sub txvisuskacamata2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxVisusKacamataOS.KeyPress
        If e.KeyChar = ","c Then e.Handled = True
    End Sub

    Private Sub txvisustanpakacamata_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxVisusTanpaKacamataOD.KeyPress
        If e.KeyChar = ","c Then e.Handled = True
    End Sub

    Private Sub txvisustanpakacamata2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxVisusTanpaKacamataOS.KeyPress
        If e.KeyChar = ","c Then e.Handled = True
    End Sub

    Private Sub SimpanPemeriksaanFisik()
        If CheckingSaranKetrangan() = True Then
            ' Set Saran Keterangan
            SetSaranKeterangan()

            If MsgBox("Pastikan data yang anda simpan sudah benar. Yakin untuk menyimpan data fisik?", MsgBoxStyle.YesNo, "Question.") = MsgBoxResult.Yes Then
                '# Set Default Variabel
                Dim Tdimana As String = ""
                Dim Tkenapa As String = ""
                Dim Tjenis As String = ""
                Dim Tkapan As String = "1900-01-01"
                Dim _statusSembuh As Boolean = False

                '# Set Tabel Transaksi Fisik
                Dim tblFisik As DataTable = ReadThemysql("SELECT a.FisikKet, a.fisiknourut FROM transaksilabfisik a WHERE a.idlabinternet = '" & idTransaksi & "'", DB_Poliklinik)

                '# Set Manual Query
                Dim queryStringInsert As New StringBuilder()
                queryStringInsert.AppendLine("INSERT INTO transaksilabfisik (NoUrut, FisikNoUrut, FisikKet, Result, CreateDate, CreateBy, idlabinternet, dimana, kenapa, jenis, kapan, StatusSembuh) VALUES ")

                If tblFisik.Rows.Count > 0 Then
                    'If CheckThemysql("SELECT a.fisiknourut FROM transaksilabfisik a, transaksilab b WHERE a.nourut='" & TextBoxNoTransaksi.Text & "' AND a.nourut=b.nourut AND b.idtempatlab='" & kodeLokasi & "' AND a.idlabinternet=b.idlabinternet", DB_Poliklinik) = True Then
                    '# Update Data Fisik

                    For Each Trow As DataRow In tblFisik.Rows
                        'If Trow("fisiknourut") = txriwayat.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), txriwayat.Tag.ToString, txriwayat.Text, "") : GoTo GoBackthis

                        ' Pemeriksaan Vital & Antropometri
                        If Trow("fisiknourut") = TextBoxTinggiBadan.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), TextBoxTinggiBadan.Tag.ToString, TextBoxTinggiBadan.Text, "") : GoTo GoBackthis
                        If Trow("fisiknourut") = TextBoxBeratBadan.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), TextBoxBeratBadan.Tag.ToString, TextBoxBeratBadan.Text, "") : GoTo GoBackthis
                        If Trow("fisiknourut") = TextBoxSuhu.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), TextBoxSuhu.Tag.ToString, TextBoxSuhu.Text, "") : GoTo GoBackthis
                        If Trow("fisiknourut") = TextBoxDetakNadi.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), TextBoxDetakNadi.Tag.ToString, TextBoxDetakNadi.Text, "") : GoTo GoBackthis
                        If Trow("fisiknourut") = TextBoxSistole.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), TextBoxSistole.Tag.ToString, TextBoxSistole.Text & "/" & TextBoxDiastole.Text, "") : GoTo GoBackthis
                        If Trow("fisiknourut") = TextBoxNafas.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), TextBoxNafas.Tag.ToString, TextBoxNafas.Text, "") : GoTo GoBackthis

                        ' Kesimpulan & Saran
                        If Trow("fisiknourut") = txsimpul.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), txsimpul.Tag.ToString, txsimpul.Text, "") : GoTo GoBackthis
                        If Trow("FisikNoUrut") = txsaranfisik.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), txsaranfisik.Tag.ToString, txsaranfisik.Text, "") : GoTo GoBackthis

                        ' Pemeriksaan Head-to-toe (kepala ke kaki)
                        If Trow("fisiknourut") = cmbkesadaran.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), cmbkesadaran.Tag.ToString, cmbkesadaran.Text, "") : GoTo GoBackthis
                        If Trow("fisiknourut") = cmbkepala.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), cmbkepala.Tag.ToString, cmbkepala.Text, txkepala.Text) : GoTo GoBackthis
                        If Trow("fisiknourut") = cmbrambut.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), cmbrambut.Tag.ToString, cmbrambut.Text, txrambut.Text) : GoTo GoBackthis
                        If Trow("fisiknourut") = cmbmuka.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), cmbmuka.Tag.ToString, cmbmuka.Text, txmuka.Text) : GoTo GoBackthis
                        If Trow("fisiknourut") = cmbmata.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), cmbmata.Tag.ToString, cmbmata.Text, txmata.Text) : GoTo GoBackthis
                        If Trow("fisiknourut") = cmbbutawarna.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), cmbbutawarna.Tag.ToString, cmbbutawarna.Text, txbutwarna.Text) : GoTo GoBackthis
                        If Trow("fisiknourut") = cmbtelinga.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), cmbtelinga.Tag.ToString, cmbtelinga.Text, txtelinga.Text) : GoTo GoBackthis
                        If Trow("fisiknourut") = cmbhidung.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), cmbhidung.Tag.ToString, cmbhidung.Text, txhidung.Text) : GoTo GoBackthis
                        If Trow("fisiknourut") = cmbmulut.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), cmbmulut.Tag.ToString, cmbmulut.Text, txmulut.Text) : GoTo GoBackthis
                        If Trow("fisiknourut") = cmbgigi.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), cmbgigi.Tag.ToString, cmbgigi.Text, txgigi.Text) : GoTo GoBackthis
                        If Trow("fisiknourut") = cmblidah.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), cmblidah.Tag.ToString, cmblidah.Text, txlidah.Text) : GoTo GoBackthis
                        If Trow("fisiknourut") = cmbtenggorokan.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), cmbtenggorokan.Tag.ToString, cmbtenggorokan.Text, txtenggorokan.Text) : GoTo GoBackthis
                        If Trow("fisiknourut") = cmbleher.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), cmbleher.Tag.ToString, cmbleher.Text, txleher.Text) : GoTo GoBackthis
                        If Trow("fisiknourut") = cmbdada.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), cmbdada.Tag.ToString, cmbdada.Text, txdada.Text) : GoTo GoBackthis
                        If Trow("fisiknourut") = ComboBoxFisikPerut.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), ComboBoxFisikPerut.Tag.ToString, ComboBoxFisikPerut.Text, TextBoxFisikPerut.Text) : GoTo GoBackthis
                        If Trow("fisiknourut") = ComboBoxFisikRectalToucher.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), ComboBoxFisikRectalToucher.Tag.ToString, ComboBoxFisikRectalToucher.Text, TextBoxFisikRectalToucher.Text) : GoTo GoBackthis
                        If Trow("fisiknourut") = cmbintegumen.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), cmbintegumen.Tag.ToString, cmbintegumen.Text, txintegumen.Text) : GoTo GoBackthis
                        If Trow("fisiknourut") = cmbekstemitas.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), cmbekstemitas.Tag.ToString, cmbekstemitas.Text, txekstemitas.Text) : GoTo GoBackthis
                        If Trow("fisiknourut") = cmbturgor.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), cmbturgor.Tag.ToString, cmbturgor.Text, "") : GoTo GoBackthis
                        If Trow("fisiknourut") = txkoreksiakhir.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), txkoreksiakhir.Tag.ToString, txkoreksiakhir.Text, "") : GoTo GoBackthis

                        ' Visus Mata & Koreksi Akhir
                        ' VisusMata1 = Visus dgn kacamata (3012) / Visus Mata (3014)
                        ' VisusMata2 = Visustanpakacamata (3013) / Autorefraksi (3015)

                        ' Visus dgn kacamata (3012) / Visus Mata (3014)
                        'If Trow("fisiknourut") = "3012" Or Trow("fisiknourut") = "3014" Then
                        '    WriteThemysql("DELETE FROM transaksilabfisik WHERE FisikNoUrut IN (3012, 3013, 3014, 3015) AND idlabinternet='" & idTransaksi & "'", DB_Poliklinik)

                        '    If txvisuskacamata.Text <> "" And txvisuskacamata2.Text <> "" Then
                        '        queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & txvisuskacamata.Tag.ToString & "', '" & txvisuskacamata.Text & "', '" & GetHasilComboBox(txvisuskacamata.Text & "," & txvisuskacamata2.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                        '    Else
                        '        queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & txvisuskacamata.Tag.ToString & "', '" & txvisuskacamata.Text & "', '" & GetHasilComboBox("", "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                        '    End If
                        'End If

                        '' Visustanpakacamata (3013) / Autorefraksi (3015)
                        'If Trow("fisiknourut") = "3013" Or Trow("fisiknourut") = "3015" Then
                        '    If txvisustanpakacamata.Text <> "" And txvisustanpakacamata2.Text <> "" Then
                        '        queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & txvisustanpakacamata.Tag.ToString & "', '" & txvisustanpakacamata.Text & "', '" & GetHasilComboBox(txvisustanpakacamata.Text & "," & txvisustanpakacamata2.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                        '    Else
                        '        queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & txvisustanpakacamata.Tag.ToString & "', '" & txvisustanpakacamata.Text & "', '" & GetHasilComboBox("", "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                        '    End If
                        'End If

                        'If ComboBoxVisusMata1.Text = "Visus dgn kacamata" And Trow("fisiknourut") = "3012" Then
                        '    If txvisuskacamata.Text <> "" And txvisuskacamata2.Text <> "" Then
                        '        queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & txvisuskacamata.Tag.ToString & "', 'Visus dgn kacamata', '" & GetHasilComboBox(txvisuskacamata.Text & "," & txvisuskacamata2.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                        '    Else
                        '        queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & txvisuskacamata.Tag.ToString & "', 'Visus dgn kacamata', '" & GetHasilComboBox("", "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                        '    End If
                        'ElseIf ComboBoxVisusMata1.Text = "Visus Mata" And Trow("fisiknourut") = "3014" Then
                        '    If txvisuskacamata.Text <> "" And txvisuskacamata2.Text <> "" Then
                        '        queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & txvisuskacamata.Tag.ToString & "', 'Visus dgn kacamata', '" & GetHasilComboBox(txvisuskacamata.Text & "," & txvisuskacamata2.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                        '    Else
                        '        queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & txvisuskacamata.Tag.ToString & "', 'Visus dgn kacamata', '" & GetHasilComboBox("", "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                        '    End If
                        'End If

                        'If Trow("fisiknourut").ToString.Contains("3012") = True Or Trow("fisiknourut").ToString.Contains("3014") = True Then
                        '    WriteThemysql("DELETE FROM transaksilabfisik WHERE FisikNoUrut IN (3012, 3013, 3014, 3015) AND idlabinternet='" & idTransaksi & "'", DB_Poliklinik)

                        '    If Trow("fisiknourut").ToString.Contains("3012") = True Then
                        '        If txvisuskacamata.Text <> "" And txvisuskacamata2.Text <> "" Then
                        '            queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & txvisuskacamata.Tag.ToString & "', 'Visus dgn kacamata', '" & GetHasilComboBox(txvisuskacamata.Text & "," & txvisuskacamata2.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                        '        Else
                        '            queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & txvisuskacamata.Tag.ToString & "', 'Visus dgn kacamata', '" & GetHasilComboBox("", "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                        '        End If

                        '        If txvisustanpakacamata.Text <> "" And txvisustanpakacamata2.Text <> "" Then
                        '            queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & txvisustanpakacamata.Tag.ToString & "', 'Visustanpakacamata', '" & GetHasilComboBox(txvisustanpakacamata.Text & "," & txvisustanpakacamata2.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                        '        Else
                        '            queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & txvisustanpakacamata.Tag.ToString & "', 'Visustanpakacamata', '" & GetHasilComboBox("", "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                        '        End If
                        '    ElseIf Trow("fisiknourut").ToString.Contains("3014") = True Then
                        '        If txvisuskacamata.Text <> "" Then
                        '            queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & txvisuskacamata.Tag.ToString & "', 'Visus Mata', '" & GetHasilComboBox(txvisuskacamata.Text & "," & txvisuskacamata2.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                        '        Else
                        '            queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & txvisuskacamata.Tag.ToString & "', 'Visus Mata', '" & GetHasilComboBox("", "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                        '        End If

                        '        If txvisustanpakacamata.Text <> "" Then
                        '            queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & txvisustanpakacamata.Tag.ToString & "', 'Autorefraksi', '" & GetHasilComboBox(txvisustanpakacamata.Text & "," & txvisustanpakacamata2.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                        '        Else
                        '            queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & txvisustanpakacamata.Tag.ToString & "', 'Autorefraksi', '" & GetHasilComboBox("", "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                        '        End If
                        '    End If

                        '    GoTo GoBackthis
                        'End If

                        ' Riwayat Kebiasaan
                        If Trow("fisiknourut") = cmbrokok.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), cmbrokok.Tag.ToString, cmbrokok.Text, "") : GoTo GoBackthis
                        If Trow("fisiknourut") = cmbalkohol.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), cmbalkohol.Tag.ToString, cmbalkohol.Text, "") : GoTo GoBackthis
                        If Trow("fisiknourut") = cmbkopi.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), cmbkopi.Tag.ToString, cmbkopi.Text, "") : GoTo GoBackthis
                        If Trow("fisiknourut") = cmbpolamakan.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), cmbpolamakan.Tag.ToString, cmbpolamakan.Text, "") : GoTo GoBackthis
                        If Trow("fisiknourut") = cmbistirahat.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), cmbistirahat.Tag.ToString, cmbistirahat.Text, "") : GoTo GoBackthis
                        If Trow("fisiknourut") = cmbolahraga.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), cmbolahraga.Tag.ToString, cmbolahraga.Text, "") : GoTo GoBackthis

                        ' Riwayat Penyakit (Kolom 1)
                        If Trow("fisiknourut") = ComboBoxHepatitis.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), ComboBoxHepatitis.Tag.ToString, ComboBoxHepatitis.Text & "##" & ComboBoxListHepatitis.Text & "##" & Format(DateTimeHepatitis.Value, "yyyy-MM-dd") & "#" & CheckBoxSembuhHepatitis.Checked, "") : GoTo GoBackthis
                        If Trow("fisiknourut") = ComboBoxTBC.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), ComboBoxTBC.Tag.ToString, ComboBoxTBC.Text & "####" & Format(DateTimeTBC.Value, "yyyy-MM-dd") & "#" & CheckBoxSembuhTBC.Checked, "") : GoTo GoBackthis
                        If Trow("fisiknourut") = ComboBoxHernia.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), ComboBoxHernia.Tag.ToString, ComboBoxHernia.Text & "####" & Format(DateTimeHernia.Value, "yyyy-MM-dd") & "#" & CheckBoxSembuhHernia.Checked, "") : GoTo GoBackthis
                        If Trow("fisiknourut") = ComboBoxHipertensi.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), ComboBoxHipertensi.Tag.ToString, ComboBoxHipertensi.Text & "####" & Format(DateTimeHipertensi.Value, "yyyy-MM-dd") & "#" & CheckBoxSembuhHipertensi.Checked, "") : GoTo GoBackthis
                        If Trow("fisiknourut") = ComboBoxEpilepsi.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), ComboBoxEpilepsi.Tag.ToString, ComboBoxEpilepsi.Text & "####" & Format(DateTimeEpilepsi.Value, "yyyy-MM-dd") & "#" & CheckBoxSembuhEpilepsi.Checked, "") : GoTo GoBackthis
                        If Trow("fisiknourut") = ComboBoxDiabetesMellitus.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), ComboBoxDiabetesMellitus.Tag.ToString, ComboBoxDiabetesMellitus.Text & "####" & Format(DateTimeDiabetesMellitus.Value, "yyyy-MM-dd") & "#" & CheckBoxSembuhDiabetesMellitus.Checked, "") : GoTo GoBackthis
                        If Trow("fisiknourut") = ComboBoxParuNonTBC.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), ComboBoxParuNonTBC.Tag.ToString, ComboBoxParuNonTBC.Text & "##" & ComboBoxListParuNonTBC.Text & "##" & Format(DateTimeParuNonTBC.Value, "yyyy-MM-dd") & "#" & CheckBoxSembuhParuNonTBC.Checked, "") : GoTo GoBackthis
                        If Trow("fisiknourut") = ComboBoxSakitJantung.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), ComboBoxSakitJantung.Tag.ToString, ComboBoxSakitJantung.Text & "##" & ComboBoxListSakitJantung.Text & "##" & Format(DateTimeSakitJantung.Value, "yyyy-MM-dd") & "#" & CheckBoxSembuhSakitJantung.Checked, "") : GoTo GoBackthis
                        If Trow("fisiknourut") = ComboBoxGangguanKulit.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), ComboBoxGangguanKulit.Tag.ToString, ComboBoxGangguanKulit.Text & "####" & Format(DateTimeGangguanKulit.Value, "yyyy-MM-dd") & "#" & CheckBoxSembuhGangguanKulit.Checked, "") : GoTo GoBackthis
                        If Trow("fisiknourut") = ComboBoxMalaria.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), ComboBoxMalaria.Tag.ToString, ComboBoxMalaria.Text & "####" & Format(DateTimeMalaria.Value, "yyyy-MM-dd") & "#" & CheckBoxSembuhMalaria.Checked, "") : GoTo GoBackthis

                        ' Riwayat Penyakit (Kolom 2)
                        If Trow("fisiknourut") = ComboBoxAmbeien.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), ComboBoxAmbeien.Tag.ToString, ComboBoxAmbeien.Text & "####" & Format(DateTimeAmbeien.Value, "yyyy-MM-dd") & "#" & CheckBoxSembuhAmbeien.Checked, "") : GoTo GoBackthis
                        If Trow("fisiknourut") = ComboBoxTHT.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), ComboBoxTHT.Tag.ToString, ComboBoxTHT.Text & "####" & Format(DateTimeTHT.Value, "yyyy-MM-dd") & "#" & CheckBoxSembuhTHT.Checked, "") : GoTo GoBackthis
                        If Trow("fisiknourut") = ComboBoxKencingBatu.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), ComboBoxKencingBatu.Tag.ToString, ComboBoxKencingBatu.Text & "####" & Format(DateTimeKencingBatu.Value, "yyyy-MM-dd") & "#" & CheckBoxSembuhKencingBatu.Checked, "") : GoTo GoBackthis
                        If Trow("fisiknourut") = ComboBoxVertigo.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), ComboBoxVertigo.Tag.ToString, ComboBoxVertigo.Text & "####" & Format(DateTimeVertigo.Value, "yyyy-MM-dd") & "#" & CheckBoxSembuhVertigo.Checked, "") : GoTo GoBackthis
                        If Trow("fisiknourut") = ComboBoxAnorexia.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), ComboBoxAnorexia.Tag.ToString, ComboBoxAnorexia.Text & "####" & Format(DateTimeAnorexia.Value, "yyyy-MM-dd") & "#" & CheckBoxSembuhAnorexia.Checked, "") : GoTo GoBackthis
                        If Trow("fisiknourut") = ComboBoxPingsan.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), ComboBoxPingsan.Tag.ToString, ComboBoxPingsan.Text & "####" & Format(DateTimePingsan.Value, "yyyy-MM-dd") & "#" & CheckBoxSembuhPingsan.Checked, "") : GoTo GoBackthis
                        If Trow("fisiknourut") = ComboBoxGastritis.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), ComboBoxGastritis.Tag.ToString, ComboBoxGastritis.Text & "####" & Format(DateTimeGastritis.Value, "yyyy-MM-dd") & "#" & CheckBoxSembuhGastritis.Checked, "") : GoTo GoBackthis
                        If Trow("fisiknourut") = ComboBoxPusing.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), ComboBoxPusing.Tag.ToString, ComboBoxPusing.Text & "####" & Format(DateTimePusing.Value, "yyyy-MM-dd") & "#" & CheckBoxSembuhPusing.Checked, "") : GoTo GoBackthis
                        If Trow("fisiknourut") = ComboBoxTypoidFever.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), ComboBoxTypoidFever.Tag.ToString, ComboBoxTypoidFever.Text & "####" & Format(DateTimeTypoidFever.Value, "yyyy-MM-dd") & "#" & CheckBoxSembuhTypoidFever.Checked, "") : GoTo GoBackthis
                        If Trow("fisiknourut") = ComboBoxTurunBB.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), ComboBoxTurunBB.Tag.ToString, ComboBoxTurunBB.Text & "####" & Format(DateTimeTurunBB.Value, "yyyy-MM-dd") & "#" & CheckBoxSembuhTurunBB.Checked, "") : GoTo GoBackthis

                        ' Dokter Fisik
                        If Trow("fisiknourut") = ComboBoxDokterFisik.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), ComboBoxDokterFisik.Tag.ToString, ComboBoxDokterFisik.Text, "") : GoTo GoBackthis

                        ' Riwayat Kesehatan
                        If Trow("fisiknourut") = ComboBoxRiwayatOperasi.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), ComboBoxRiwayatOperasi.Tag.ToString, ComboBoxRiwayatOperasi.Text & "#" & TextBoxTempatRiwayatOperasi.Text & "#" & TextBoxDiagnosaRiwayatOperasi.Text & "##" & Format(DateTimeRiwayatOperasi.Value, "yyyy-MM-dd") & "#False", "") : GoTo GoBackthis
                        If Trow("fisiknourut") = ComboBoxRiwayatRumahSakit.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), ComboBoxRiwayatRumahSakit.Tag.ToString, ComboBoxRiwayatRumahSakit.Text & "#" & TextBoxTempatRiwayatRumahSakit.Text & "#" & TextBoxDiagnosaRiwayatRumahSakit.Text & "##" & Format(DateTimeRiwayatRumahSakit.Value, "yyyy-MM-dd") & "#False", "") : GoTo GoBackthis
                        If Trow("fisiknourut") = ComboBoxRiwayatKondisiSehat.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), ComboBoxRiwayatKondisiSehat.Tag.ToString, ComboBoxRiwayatKondisiSehat.Text & "##" & TextBoxKeluhanRiwayatKondisiSehat.Text & "##1900-01-01#False", "") : GoTo GoBackthis
                        If Trow("fisiknourut") = ComboBoxRiwayatPengobatanPenyakit.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), ComboBoxRiwayatPengobatanPenyakit.Tag.ToString, ComboBoxRiwayatPengobatanPenyakit.Text & "##" & TextBoxDiagnosaRiwayatPengobatanPenyakit.Text & "#" & TextBoxTerapiRiwayatPengobatanPenyakit.Text & "#" & Format(DateTimeRiwayatPengobatanPenyakit.Value, "yyyy-MM-dd") & "#False", "") : GoTo GoBackthis
                        If Trow("fisiknourut") = ComboBoxRiwayatPenggunaNarkoba.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), ComboBoxRiwayatPenggunaNarkoba.Tag.ToString, ComboBoxRiwayatPenggunaNarkoba.Text & "###" & TextBoxJenisRiwayatPenggunaNarkoba.Text & "#" & Format(DateTimeRiwayatPenggunaNarkoba.Value, "yyyy-MM-dd") & "#False", "") : GoTo GoBackthis
                        If Trow("fisiknourut") = ComboBoxRiwayatPenyakitKeluarga.Tag.ToString Then UpdateHasilFisik(Trow("FisikKet"), ComboBoxRiwayatPenyakitKeluarga.Tag.ToString, ComboBoxRiwayatPenyakitKeluarga.Text & "##" & TextBoxPenyakitRiwayatPenyakitKeluarga.Text & "##1900-01-01#False", "") : GoTo GoBackthis
GoBackthis:
                    Next

                    ' Hapus Data Visus Mata
                    WriteThemysql("DELETE FROM transaksilabfisik WHERE FisikNoUrut IN (3012, 3013, 3014, 3015) AND idlabinternet='" & idTransaksi & "'", DB_Poliklinik)
                Else
                    '# Insert Data Fisik

                    '# Set Manual Query Insert
                    'Dim queryStringInsert As New StringBuilder()
                    'queryStringInsert.AppendLine("INSERT INTO transaksilabfisik (NoUrut, FisikNoUrut, FisikKet, Result, CreateDate, CreateBy, idlabinternet, dimana, kenapa, jenis, kapan, StatusSembuh) VALUES ")

                    ' Pemeriksaan Vital & Antropometri
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & TextBoxRiwayatPenyakit.Tag.ToString & "', 'Riwayat', '" & GetHasilComboBox(TextBoxRiwayatPenyakit.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & TextBoxTinggiBadan.Tag.ToString & "', 'Tinggi Badan', '" & GetHasilComboBox(TextBoxTinggiBadan.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & TextBoxBeratBadan.Tag.ToString & "', 'BeratBadan', '" & GetHasilComboBox(TextBoxBeratBadan.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & TextBoxSuhu.Tag.ToString & "', 'Suhu', '" & GetHasilComboBox(TextBoxSuhu.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & TextBoxDetakNadi.Tag.ToString & "', 'Nadi', '" & GetHasilComboBox(TextBoxDetakNadi.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & TextBoxSistole.Tag.ToString & "', 'Tekanan', '" & GetHasilComboBox(TextBoxSistole.Text & "/" & TextBoxDiastole.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & TextBoxNafas.Tag.ToString & "', 'Respirasi', '" & GetHasilComboBox(TextBoxNafas.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")

                    ' Kesimpulan & Saran
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & txsimpul.Tag.ToString & "', 'Kesimpulan', '" & GetHasilComboBox(txsimpul.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & txsaranfisik.Tag.ToString & "', 'Saran', '" & GetHasilComboBox(txsaranfisik.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")

                    ' Pemeriksaan Head-to-toe (kepala ke kaki)
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & cmbkesadaran.Tag.ToString & "', 'Kesadaran', '" & GetHasilComboBox(cmbkesadaran.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & cmbkepala.Tag.ToString & "', 'Kepala', '" & GetHasilComboBox(cmbkepala.Text, txkepala.Text) & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & cmbrambut.Tag.ToString & "', 'Rambut', '" & GetHasilComboBox(cmbrambut.Text, txrambut.Text) & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & cmbmuka.Tag.ToString & "', 'Muka', '" & GetHasilComboBox(cmbmuka.Text, txmuka.Text) & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & cmbmata.Tag.ToString & "', 'Mata', '" & GetHasilComboBox(cmbmata.Text, txmata.Text) & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & cmbbutawarna.Tag.ToString & "', 'Buta warna', '" & GetHasilComboBox(cmbbutawarna.Text, txbutwarna.Text) & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & cmbtelinga.Tag.ToString & "', 'Telinga', '" & GetHasilComboBox(cmbtelinga.Text, txtelinga.Text) & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & cmbhidung.Tag.ToString & "', 'Hidung', '" & GetHasilComboBox(cmbhidung.Text, txhidung.Text) & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & cmbmulut.Tag.ToString & "', 'Mulut', '" & GetHasilComboBox(cmbmulut.Text, txmulut.Text) & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & cmbgigi.Tag.ToString & "', 'Gigi', '" & GetHasilComboBox(cmbgigi.Text, txgigi.Text) & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & cmblidah.Tag.ToString & "', 'Lidah', '" & GetHasilComboBox(cmblidah.Text, txlidah.Text) & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & cmbtenggorokan.Tag.ToString & "', 'Tenggorokan', '" & GetHasilComboBox(cmbtenggorokan.Text, txtenggorokan.Text) & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & cmbleher.Tag.ToString & "', 'Leher', '" & GetHasilComboBox(cmbleher.Text, txleher.Text) & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & cmbdada.Tag.ToString & "', 'Dada', '" & GetHasilComboBox(cmbdada.Text, txdada.Text) & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & ComboBoxFisikPerut.Tag.ToString & "', 'Perut', '" & GetHasilComboBox(ComboBoxFisikPerut.Text, TextBoxFisikPerut.Text) & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & ComboBoxFisikRectalToucher.Tag.ToString & "', 'Rectal Toucher', '" & GetHasilComboBox(ComboBoxFisikRectalToucher.Text, TextBoxFisikRectalToucher.Text) & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & cmbintegumen.Tag.ToString & "', 'Integumen', '" & GetHasilComboBox(cmbintegumen.Text, txintegumen.Text) & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & cmbekstemitas.Tag.ToString & "', 'Ekstemitas', '" & GetHasilComboBox(cmbekstemitas.Text, txekstemitas.Text) & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & cmbturgor.Tag.ToString & "', 'Turgor', '" & GetHasilComboBox(cmbturgor.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")

                    ' Koreksi Akhir
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & txkoreksiakhir.Tag.ToString & "', 'Koreksi Akhir', '" & GetHasilComboBox(txkoreksiakhir.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")

                    ' Riwayat Kebiasaan
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & cmbrokok.Tag.ToString & "', 'Rokok', '" & GetHasilComboBox(cmbrokok.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & cmbalkohol.Tag.ToString & "', 'Alkohol', '" & GetHasilComboBox(cmbalkohol.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & cmbkopi.Tag.ToString & "', 'Kopi', '" & GetHasilComboBox(cmbkopi.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & cmbpolamakan.Tag.ToString & "', 'Polamakan', '" & GetHasilComboBox(cmbpolamakan.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & cmbistirahat.Tag.ToString & "', 'Polaistirahat', '" & GetHasilComboBox(cmbistirahat.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & cmbolahraga.Tag.ToString & "', 'Olahraga', '" & GetHasilComboBox(cmbolahraga.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")

                    ' Riwayat Kesehatan
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & ComboBoxRiwayatOperasi.Tag.ToString & "', 'Operasi', '" & GetHasilComboBox(ComboBoxRiwayatOperasi.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & TextBoxTempatRiwayatOperasi.Text & "', '" & TextBoxDiagnosaRiwayatOperasi.Text & "', '" & Tjenis & "', '" & Format(DateTimeRiwayatOperasi.Value, "yyyy-MM-dd") & "', " & _statusSembuh & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & ComboBoxRiwayatRumahSakit.Tag.ToString & "', 'Rs', '" & GetHasilComboBox(ComboBoxRiwayatRumahSakit.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & TextBoxTempatRiwayatRumahSakit.Text & "', '" & TextBoxDiagnosaRiwayatRumahSakit.Text & "', '" & Tjenis & "', '" & Format(DateTimeRiwayatRumahSakit.Value, "yyyy-MM-dd") & "', " & _statusSembuh & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & ComboBoxRiwayatKondisiSehat.Tag.ToString & "', 'Sehat', '" & GetHasilComboBox(ComboBoxRiwayatKondisiSehat.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & TextBoxKeluhanRiwayatKondisiSehat.Text & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & ComboBoxRiwayatPengobatanPenyakit.Tag.ToString & "', 'Obat', '" & GetHasilComboBox(ComboBoxRiwayatPengobatanPenyakit.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & TextBoxDiagnosaRiwayatPengobatanPenyakit.Text & "', '" & TextBoxTerapiRiwayatPengobatanPenyakit.Text & "', '" & Format(DateTimeRiwayatPengobatanPenyakit.Value, "yyyy-MM-dd") & "', " & _statusSembuh & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & ComboBoxRiwayatPenggunaNarkoba.Tag.ToString & "', 'Narkoba', '" & GetHasilComboBox(ComboBoxRiwayatPenggunaNarkoba.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & TextBoxJenisRiwayatPenggunaNarkoba.Text & "', '" & Format(DateTimeRiwayatPenggunaNarkoba.Value, "yyyy-MM-dd") & "', " & _statusSembuh & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & ComboBoxRiwayatPenyakitKeluarga.Tag.ToString & "', 'Riwayat Penyakit Keluarga', '" & GetHasilComboBox(ComboBoxRiwayatPenyakitKeluarga.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & TextBoxPenyakitRiwayatPenyakitKeluarga.Text & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")

                    ' Format Header
                    'queryStringInsert.AppendLine("INSERT INTO transaksilabfisik (NoUrut, FisikNoUrut, FisikKet, Result, CreateDate, CreateBy, idlabinternet, dimana, kenapa, jenis, kapan, StatusSembuh, Diagnosa, Terapi, Keluhan) VALUES ")
                    'queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & ComboBoxHepatitis.Tag.ToString & "', 'Hepatitis', '" & GetHasilComboBox(ComboBoxHepatitis.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")

                    ' Riwayat Penyakit (Kolom 1)
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & ComboBoxHepatitis.Tag.ToString & "', 'Hepatitis', '" & GetHasilComboBox(ComboBoxHepatitis.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & ComboBoxListHepatitis.Text & "', '" & Tjenis & "', '" & Format(DateTimeHepatitis.Value, "yyyy-MM-dd") & "', " & CheckBoxSembuhHepatitis.Checked & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & ComboBoxTBC.Tag.ToString & "', 'Tbc', '" & GetHasilComboBox(ComboBoxTBC.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Format(DateTimeTBC.Value, "yyyy-MM-dd") & "', " & CheckBoxSembuhTBC.Checked & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & ComboBoxHernia.Tag.ToString & "', 'Hernia', '" & GetHasilComboBox(ComboBoxHernia.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Format(DateTimeHernia.Value, "yyyy-MM-dd") & "', " & CheckBoxSembuhHernia.Checked & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & ComboBoxHipertensi.Tag.ToString & "', 'Hipertensi', '" & GetHasilComboBox(ComboBoxHipertensi.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Format(DateTimeHipertensi.Value, "yyyy-MM-dd") & "', " & CheckBoxSembuhHipertensi.Checked & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & ComboBoxEpilepsi.Tag.ToString & "', 'Epilepsi', '" & GetHasilComboBox(ComboBoxEpilepsi.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Format(DateTimeEpilepsi.Value, "yyyy-MM-dd") & "', " & CheckBoxSembuhEpilepsi.Checked & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & ComboBoxDiabetesMellitus.Tag.ToString & "', 'Diabetes', '" & GetHasilComboBox(ComboBoxDiabetesMellitus.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Format(DateTimeDiabetesMellitus.Value, "yyyy-MM-dd") & "', " & CheckBoxSembuhDiabetesMellitus.Checked & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & ComboBoxParuNonTBC.Tag.ToString & "', 'Penyakit Paru (Non TBC)', '" & GetHasilComboBox(ComboBoxParuNonTBC.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & ComboBoxListParuNonTBC.Text & "', '" & Tjenis & "', '" & Format(DateTimeParuNonTBC.Value, "yyyy-MM-dd") & "', " & CheckBoxSembuhParuNonTBC.Checked & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & ComboBoxSakitJantung.Tag.ToString & "', 'Sakitjantung', '" & GetHasilComboBox(ComboBoxSakitJantung.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & ComboBoxListSakitJantung.Text & "', '" & Tjenis & "', '" & Format(DateTimeSakitJantung.Value, "yyyy-MM-dd") & "', " & CheckBoxSembuhSakitJantung.Checked & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & ComboBoxGangguanKulit.Tag.ToString & "', 'Kulit', '" & GetHasilComboBox(ComboBoxGangguanKulit.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Format(DateTimeGangguanKulit.Value, "yyyy-MM-dd") & "', " & CheckBoxSembuhGangguanKulit.Checked & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & ComboBoxMalaria.Tag.ToString & "', 'Malaria', '" & GetHasilComboBox(ComboBoxMalaria.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Format(DateTimeMalaria.Value, "yyyy-MM-dd") & "', " & CheckBoxSembuhMalaria.Checked & "),")

                    ' Riwayat Penyakit (Kolom 2)
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & ComboBoxAmbeien.Tag.ToString & "', 'Ambien', '" & GetHasilComboBox(ComboBoxAmbeien.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Format(DateTimeAmbeien.Value, "yyyy-MM-dd") & "', " & CheckBoxSembuhAmbeien.Checked & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & ComboBoxTHT.Tag.ToString & "', 'Tht', '" & GetHasilComboBox(ComboBoxTHT.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Format(DateTimeTHT.Value, "yyyy-MM-dd") & "', " & CheckBoxSembuhTHT.Checked & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & ComboBoxKencingBatu.Tag.ToString & "', 'Kencing', '" & GetHasilComboBox(ComboBoxKencingBatu.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Format(DateTimeKencingBatu.Value, "yyyy-MM-dd") & "', " & CheckBoxSembuhKencingBatu.Checked & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & ComboBoxVertigo.Tag.ToString & "', 'Vertigo', '" & GetHasilComboBox(ComboBoxVertigo.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Format(DateTimeVertigo.Value, "yyyy-MM-dd") & "', " & CheckBoxSembuhVertigo.Checked & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & ComboBoxAnorexia.Tag.ToString & "', 'Anorexia', '" & GetHasilComboBox(ComboBoxAnorexia.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Format(DateTimeAnorexia.Value, "yyyy-MM-dd") & "', " & CheckBoxSembuhAnorexia.Checked & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & ComboBoxPingsan.Tag.ToString & "', 'Pingsan', '" & GetHasilComboBox(ComboBoxPingsan.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Format(DateTimePingsan.Value, "yyyy-MM-dd") & "', " & CheckBoxSembuhPingsan.Checked & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & ComboBoxGastritis.Tag.ToString & "', 'Gastritis', '" & GetHasilComboBox(ComboBoxGastritis.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Format(DateTimeGastritis.Value, "yyyy-MM-dd") & "', " & CheckBoxSembuhGastritis.Checked & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & ComboBoxPusing.Tag.ToString & "', 'Pusing', '" & GetHasilComboBox(ComboBoxPusing.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Format(DateTimePusing.Value, "yyyy-MM-dd") & "', " & CheckBoxSembuhPusing.Checked & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & ComboBoxTypoidFever.Tag.ToString & "', 'Typoid', '" & GetHasilComboBox(ComboBoxTypoidFever.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Format(DateTimeTypoidFever.Value, "yyyy-MM-dd") & "', " & CheckBoxSembuhTypoidFever.Checked & "),")
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & ComboBoxTurunBB.Tag.ToString & "', 'Bbturun', '" & GetHasilComboBox(ComboBoxTurunBB.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Format(DateTimeTurunBB.Value, "yyyy-MM-dd") & "', " & CheckBoxSembuhTurunBB.Checked & "),")

                    ' Dokter Fisik
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & ComboBoxDokterFisik.Tag.ToString & "', 'Dokterpelaksana', '" & GetHasilComboBox(ComboBoxDokterFisik.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                End If

                ' Visus dgn kacamata (3012) / Visus Mata (3014)
                If TextBoxVisusKacamataOD.Text <> "" And TextBoxVisusKacamataOS.Text <> "" Then
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & TextBoxVisusKacamataOD.Tag.ToString & "', '" & ComboBoxVisusMata1.Text & "', '" & GetHasilComboBox(TextBoxVisusKacamataOD.Text & "," & TextBoxVisusKacamataOS.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                Else
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & TextBoxVisusKacamataOD.Tag.ToString & "', '" & ComboBoxVisusMata1.Text & "', '" & GetHasilComboBox("", "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                End If

                ' Visustanpakacamata (3013) / Autorefraksi (3015)
                If TextBoxVisusTanpaKacamataOD.Text <> "" And TextBoxVisusTanpaKacamataOS.Text <> "" Then
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & TextBoxVisusTanpaKacamataOD.Tag.ToString & "', '" & ComboBoxVisusMata2.Text & "', '" & GetHasilComboBox(TextBoxVisusTanpaKacamataOD.Text & "," & TextBoxVisusTanpaKacamataOS.Text, "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                Else
                    queryStringInsert.AppendLine("('" & TextBoxNoTransaksi.Text & "', '" & TextBoxVisusTanpaKacamataOD.Tag.ToString & "', '" & ComboBoxVisusMata2.Text & "', '" & GetHasilComboBox("", "") & "', NOW(),'" & UserLabAdminOnline & "','" & idTransaksi & "', '" & Tdimana & "', '" & Tkenapa & "', '" & Tjenis & "', '" & Tkapan & "', " & _statusSembuh & "),")
                End If

                ' Post Pemeriksaan Fisik
                Dim sqlInsertFisik As String = queryStringInsert.ToString()

                sqlInsertFisik = sqlInsertFisik.TrimEnd()
                If sqlInsertFisik.EndsWith(",") Then
                    sqlInsertFisik = sqlInsertFisik.Substring(0, sqlInsertFisik.Length - 1)
                End If

                WriteThemysql(sqlInsertFisik, DB_Poliklinik)

                'Save StatusKesehatanFisik
                WriteThemysql("UPDATE transaksilab SET StatusKesehatanFisik = '" & txstatusfit.Text & "' WHERE idlabinternet='" & idTransaksi & "'", DB_Poliklinik)

                txstatusfit.ResetText()
                MsgBox("Data Berhasil Disimpan.", MsgBoxStyle.Information, "Success")
            End If
        End If
    End Sub

    Private Sub SetNilaiNormalFisik()
        ' Pemeriksaan Fisik Head to Toe
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

        ' Riwayat Kesehatan
        ComboBoxRiwayatOperasi.SelectedIndex = 2
        ComboBoxRiwayatRumahSakit.SelectedIndex = 2
        ComboBoxRiwayatKondisiSehat.SelectedIndex = 2
        ComboBoxRiwayatPengobatanPenyakit.SelectedIndex = 2
        ComboBoxRiwayatPenggunaNarkoba.SelectedIndex = 2
        ComboBoxRiwayatPenyakitKeluarga.SelectedIndex = 2

        ' Kebiasaan
        cmbrokok.SelectedIndex = 3
        cmbalkohol.SelectedIndex = 3
        cmbkopi.SelectedIndex = 3
        cmbpolamakan.SelectedIndex = 1
        cmbistirahat.SelectedIndex = 1
        cmbolahraga.SelectedIndex = 1

        ' Daftar Riwayat Penyakit
        ComboBoxHepatitis.SelectedIndex = 2
        ComboBoxTBC.SelectedIndex = 2
        ComboBoxHernia.SelectedIndex = 2
        ComboBoxHipertensi.SelectedIndex = 2
        ComboBoxEpilepsi.SelectedIndex = 2
        ComboBoxDiabetesMellitus.SelectedIndex = 2
        ComboBoxParuNonTBC.SelectedIndex = 2
        ComboBoxSakitJantung.SelectedIndex = 2
        ComboBoxGangguanKulit.SelectedIndex = 2
        ComboBoxMalaria.SelectedIndex = 2

        ComboBoxAmbeien.SelectedIndex = 2
        ComboBoxTHT.SelectedIndex = 2
        ComboBoxKencingBatu.SelectedIndex = 2
        ComboBoxVertigo.SelectedIndex = 2
        ComboBoxAnorexia.SelectedIndex = 2
        ComboBoxPingsan.SelectedIndex = 2
        ComboBoxGastritis.SelectedIndex = 2
        ComboBoxPusing.SelectedIndex = 2
        ComboBoxTypoidFever.SelectedIndex = 2
        ComboBoxTurunBB.SelectedIndex = 2
    End Sub

    Private Sub ButtonSimpanFisik_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSimpanFisik.Click
        SimpanPemeriksaanFisik()
    End Sub

    Private Sub ButtonNilaiNormalFisik_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonNilaiNormalFisik.Click
        SetNilaiNormalFisik()
    End Sub

    Private Sub ButtonPreviewFisik_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPreviewFisik.Click
        If CheckThemysql("SELECT * FROM transaksilabfisik WHERE NoUrut='" & TextBoxNoTransaksi.Text & "' AND idlabinternet='" & idTransaksi & "'", DB_Poliklinik) = True Then
            'CreateFisikToPDF("Preview")
            CreateReportFisik("Preview")
        Else
            MsgBox("Data tidak ditemukan.", MsgBoxStyle.Critical, "Warning")
        End If
    End Sub

    Private Sub ButtonCetakFisik_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCetakFisik.Click
        If CheckThemysql("select * from transaksilabfisik where NoUrut='" & TextBoxNoTransaksi.Text & "' AND idlabinternet='" & idTransaksi & "'", DB_Poliklinik) = True Then
            CreateReportFisik("Print")
        Else
            MsgBox("Tidak ada data yang di preview.", MsgBoxStyle.Critical, "Warning")
        End If
    End Sub

    Private Sub ComboBoxRiwayatOperasi_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxRiwayatOperasi.SelectedIndexChanged
        If ComboBoxRiwayatOperasi.Text = "Tidak" Or ComboBoxRiwayatOperasi.Text = "" Then
            TextBoxTempatRiwayatOperasi.ResetText()
            TextBoxDiagnosaRiwayatOperasi.ResetText()
            DateTimeRiwayatOperasi.Value = "01-01-1900"

            LabelKapanRiwayatOperasi.Enabled = False
            LabelDimanaRiwayatOperasi.Enabled = False
            LabelDiagnosaRiwayatOperasi.Enabled = False
            DateTimeRiwayatOperasi.Enabled = False
            TextBoxDiagnosaRiwayatOperasi.Enabled = False
            TextBoxTempatRiwayatOperasi.Enabled = False
        ElseIf ComboBoxRiwayatOperasi.Text = "Ya" Then
            LabelKapanRiwayatOperasi.Enabled = True
            LabelDimanaRiwayatOperasi.Enabled = True
            LabelDiagnosaRiwayatOperasi.Enabled = True
            DateTimeRiwayatOperasi.Enabled = True
            TextBoxDiagnosaRiwayatOperasi.Enabled = True
            TextBoxTempatRiwayatOperasi.Enabled = True
        End If
    End Sub

    Private Sub ComboBoxRiwayatRumahSakit_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxRiwayatRumahSakit.SelectedIndexChanged
        If ComboBoxRiwayatRumahSakit.Text = "Tidak" Or ComboBoxRiwayatRumahSakit.Text = "" Then
            TextBoxTempatRiwayatRumahSakit.ResetText()
            TextBoxDiagnosaRiwayatRumahSakit.ResetText()
            DateTimeRiwayatRumahSakit.Value = "01-01-1900"

            LabelDimanaRiwayatRumahSakit.Enabled = False
            LabelKapanRiwayatRumahSakit.Enabled = False
            LabelDiagnosaRiwayatRumahSakit.Enabled = False
            DateTimeRiwayatRumahSakit.Enabled = False
            TextBoxDiagnosaRiwayatRumahSakit.Enabled = False
            TextBoxTempatRiwayatRumahSakit.Enabled = False
        ElseIf ComboBoxRiwayatRumahSakit.Text = "Ya" Then
            LabelDimanaRiwayatRumahSakit.Enabled = True
            LabelKapanRiwayatRumahSakit.Enabled = True
            LabelDiagnosaRiwayatRumahSakit.Enabled = True
            DateTimeRiwayatRumahSakit.Enabled = True
            TextBoxDiagnosaRiwayatRumahSakit.Enabled = True
            TextBoxTempatRiwayatRumahSakit.Enabled = True
        End If
    End Sub

    Private Sub ComboBoxRiwayatKondisiSehat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxRiwayatKondisiSehat.SelectedIndexChanged
        If ComboBoxRiwayatKondisiSehat.Text = "Ya" Or ComboBoxRiwayatKondisiSehat.Text = "" Then
            TextBoxKeluhanRiwayatKondisiSehat.ResetText()

            LabelKeluhanRiwayatKondisiSehat.Enabled = False
            TextBoxKeluhanRiwayatKondisiSehat.Enabled = False
        ElseIf ComboBoxRiwayatKondisiSehat.Text = "Tidak" Then
            LabelKeluhanRiwayatKondisiSehat.Enabled = True
            TextBoxKeluhanRiwayatKondisiSehat.Enabled = True
        End If
    End Sub

    Private Sub ComboBoxRiwayatPengobatanPenyakit_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxRiwayatPengobatanPenyakit.SelectedIndexChanged
        If ComboBoxRiwayatPengobatanPenyakit.Text = "Tidak" Or ComboBoxRiwayatPengobatanPenyakit.Text = "" Then
            TextBoxTerapiRiwayatPengobatanPenyakit.ResetText()
            TextBoxDiagnosaRiwayatPengobatanPenyakit.ResetText()
            DateTimeRiwayatPengobatanPenyakit.Value = "01-01-1900"

            LabelKapanRiwayatPengobatanPenyakit.Enabled = False
            LabelTerapiRiwayatPengobatanPenyakit.Enabled = False
            LabelDiagnosaRiwayatPengobatanPenyakit.Enabled = False
            DateTimeRiwayatPengobatanPenyakit.Enabled = False
            TextBoxTerapiRiwayatPengobatanPenyakit.Enabled = False
            TextBoxDiagnosaRiwayatPengobatanPenyakit.Enabled = False
        ElseIf ComboBoxRiwayatPengobatanPenyakit.Text = "Ya" Then
            LabelKapanRiwayatPengobatanPenyakit.Enabled = True
            LabelTerapiRiwayatPengobatanPenyakit.Enabled = True
            LabelDiagnosaRiwayatPengobatanPenyakit.Enabled = True
            DateTimeRiwayatPengobatanPenyakit.Enabled = True
            TextBoxTerapiRiwayatPengobatanPenyakit.Enabled = True
            TextBoxDiagnosaRiwayatPengobatanPenyakit.Enabled = True
        End If
    End Sub

    Private Sub ComboBoxRiwayatPenggunaNarkoba_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxRiwayatPenggunaNarkoba.SelectedIndexChanged
        If ComboBoxRiwayatPenggunaNarkoba.Text = "Tidak" Or ComboBoxRiwayatPenggunaNarkoba.Text = "" Then
            TextBoxJenisRiwayatPenggunaNarkoba.ResetText()
            DateTimeRiwayatPenggunaNarkoba.Value = "01-01-1900"

            LabelKapanRiwayatPenggunaNarkoba.Enabled = False
            LabelJenisRiwayatPenggunaNarkoba.Enabled = False
            DateTimeRiwayatPenggunaNarkoba.Enabled = False
            TextBoxJenisRiwayatPenggunaNarkoba.Enabled = False
        ElseIf ComboBoxRiwayatPenggunaNarkoba.Text = "Ya" Then
            LabelKapanRiwayatPenggunaNarkoba.Enabled = True
            LabelJenisRiwayatPenggunaNarkoba.Enabled = True
            DateTimeRiwayatPenggunaNarkoba.Enabled = True
            TextBoxJenisRiwayatPenggunaNarkoba.Enabled = True
        End If
    End Sub

    Private Sub ComboBoxRiwayatPenyakitKeluarga_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxRiwayatPenyakitKeluarga.SelectedIndexChanged
        If ComboBoxRiwayatPenyakitKeluarga.Text = "Tidak" Or ComboBoxRiwayatPenyakitKeluarga.Text = "" Then
            TextBoxPenyakitRiwayatPenyakitKeluarga.ResetText()

            LabelPenyakitRiwayatPenyakitKeluarga.Enabled = False
            TextBoxPenyakitRiwayatPenyakitKeluarga.Enabled = False
        ElseIf ComboBoxRiwayatPenyakitKeluarga.Text = "Ya" Then
            LabelPenyakitRiwayatPenyakitKeluarga.Enabled = True
            TextBoxPenyakitRiwayatPenyakitKeluarga.Enabled = True
        End If
    End Sub

    Private Sub ComboBoxHepatitis_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxHepatitis.SelectedIndexChanged
        If ComboBoxHepatitis.Text = "Tidak" Or ComboBoxHepatitis.Text = "" Then
            ' Set Enable False
            DateTimeHepatitis.Enabled = False
            ComboBoxListHepatitis.Enabled = False
            CheckBoxSembuhHepatitis.Enabled = False

            ' Set Default
            ComboBoxListHepatitis.SelectedIndex = -1
            CheckBoxSembuhHepatitis.Checked = False
            DateTimeHepatitis.Value = "01-01-1900"
        ElseIf ComboBoxHepatitis.Text = "Ya" Then
            ' Set Enable True
            DateTimeHepatitis.Enabled = True
            ComboBoxListHepatitis.Enabled = True
            CheckBoxSembuhHepatitis.Enabled = True
        End If
    End Sub

    Private Sub ComboBoxTBC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxTBC.SelectedIndexChanged
        If ComboBoxTBC.Text = "Tidak" Or ComboBoxTBC.Text = "" Then
            ' Set Enable False
            DateTimeTBC.Enabled = False
            CheckBoxSembuhTBC.Enabled = False

            ' Set Default
            CheckBoxSembuhTBC.Checked = False
            DateTimeTBC.Value = "01-01-1900"
        ElseIf ComboBoxTBC.Text = "Ya" Then
            ' Set Enable True
            DateTimeTBC.Enabled = True
            CheckBoxSembuhTBC.Enabled = True
        End If
    End Sub

    Private Sub ComboBoxHernia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxHernia.SelectedIndexChanged
        If ComboBoxHernia.Text = "Tidak" Or ComboBoxHernia.Text = "" Then
            ' Set Enable False
            DateTimeHernia.Enabled = False
            CheckBoxSembuhHernia.Enabled = False

            ' Set Default
            CheckBoxSembuhHernia.Checked = False
            DateTimeHernia.Value = "01-01-1900"
        ElseIf ComboBoxHernia.Text = "Ya" Then
            ' Set Enable True
            DateTimeHernia.Enabled = True
            CheckBoxSembuhHernia.Enabled = True
        End If
    End Sub

    Private Sub ComboBoxHipertensi_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxHipertensi.SelectedIndexChanged
        If ComboBoxHipertensi.Text = "Tidak" Or ComboBoxHipertensi.Text = "" Then
            ' Set Enable False
            DateTimeHipertensi.Enabled = False
            CheckBoxSembuhHipertensi.Enabled = False

            ' Set Default
            CheckBoxSembuhHipertensi.Checked = False
            DateTimeHipertensi.Value = "01-01-1900"
        ElseIf ComboBoxHipertensi.Text = "Ya" Then
            ' Set Enable True
            DateTimeHipertensi.Enabled = True
            CheckBoxSembuhHipertensi.Enabled = True
        End If
    End Sub

    Private Sub ComboBoxEpilepsi_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxEpilepsi.SelectedIndexChanged
        If ComboBoxEpilepsi.Text = "Tidak" Or ComboBoxEpilepsi.Text = "" Then
            ' Set Enable False
            DateTimeEpilepsi.Enabled = False
            CheckBoxSembuhEpilepsi.Enabled = False

            ' Set Default
            CheckBoxSembuhEpilepsi.Checked = False
            DateTimeEpilepsi.Value = "01-01-1900"
        ElseIf ComboBoxEpilepsi.Text = "Ya" Then
            ' Set Enable True
            DateTimeEpilepsi.Enabled = True
            CheckBoxSembuhEpilepsi.Enabled = True
        End If
    End Sub

    Private Sub ComboBoxDiabetesMellitus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxDiabetesMellitus.SelectedIndexChanged
        If ComboBoxDiabetesMellitus.Text = "Tidak" Or ComboBoxDiabetesMellitus.Text = "" Then
            ' Set Enable False
            DateTimeDiabetesMellitus.Enabled = False
            CheckBoxSembuhDiabetesMellitus.Enabled = False

            ' Set Default
            CheckBoxSembuhDiabetesMellitus.Checked = False
            DateTimeDiabetesMellitus.Value = "01-01-1900"
        ElseIf ComboBoxDiabetesMellitus.Text = "Ya" Then
            ' Set Enable True
            DateTimeDiabetesMellitus.Enabled = True
            CheckBoxSembuhDiabetesMellitus.Enabled = True
        End If
    End Sub

    Private Sub ComboBoxParuNonTBC_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxParuNonTBC.SelectedIndexChanged
        If ComboBoxParuNonTBC.Text = "Tidak" Or ComboBoxParuNonTBC.Text = "" Then
            ' Set Enable False
            DateTimeParuNonTBC.Enabled = False
            CheckBoxSembuhParuNonTBC.Enabled = False
            ComboBoxListParuNonTBC.Enabled = False

            ' Set Default
            ComboBoxListParuNonTBC.SelectedIndex = -1
            CheckBoxSembuhParuNonTBC.Checked = False
            DateTimeParuNonTBC.Value = "01-01-1900"
        ElseIf ComboBoxParuNonTBC.Text = "Ya" Then
            ' Set Enable True
            DateTimeParuNonTBC.Enabled = True
            ComboBoxListParuNonTBC.Enabled = True
            CheckBoxSembuhParuNonTBC.Enabled = True
        End If
    End Sub

    Private Sub ComboBoxSakitJantung_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxSakitJantung.SelectedIndexChanged
        If ComboBoxSakitJantung.Text = "Tidak" Or ComboBoxSakitJantung.Text = "" Then
            ' Set Enable False
            DateTimeSakitJantung.Enabled = False
            CheckBoxSembuhSakitJantung.Enabled = False
            ComboBoxListSakitJantung.Enabled = False

            ' Set Default
            ComboBoxListSakitJantung.SelectedIndex = -1
            CheckBoxSembuhSakitJantung.Checked = False
            DateTimeSakitJantung.Value = "01-01-1900"
        ElseIf ComboBoxSakitJantung.Text = "Ya" Then
            ' Set Enable True
            DateTimeSakitJantung.Enabled = True
            ComboBoxListSakitJantung.Enabled = True
            CheckBoxSembuhSakitJantung.Enabled = True
        End If
    End Sub

    Private Sub ComboBoxGangguanKulit_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxGangguanKulit.SelectedIndexChanged
        If ComboBoxGangguanKulit.Text = "Tidak" Or ComboBoxGangguanKulit.Text = "" Then
            ' Set Enable False
            DateTimeGangguanKulit.Enabled = False
            CheckBoxSembuhGangguanKulit.Enabled = False

            ' Set Default
            CheckBoxSembuhGangguanKulit.Checked = False
            DateTimeGangguanKulit.Value = "01-01-1900"
        ElseIf ComboBoxGangguanKulit.Text = "Ya" Then
            ' Set Enable True
            DateTimeGangguanKulit.Enabled = True
            CheckBoxSembuhGangguanKulit.Enabled = True
        End If
    End Sub

    Private Sub ComboBoxMalaria_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxMalaria.SelectedIndexChanged
        If ComboBoxMalaria.Text = "Tidak" Or ComboBoxMalaria.Text = "" Then
            ' Set Enable False
            DateTimeMalaria.Enabled = False
            CheckBoxSembuhMalaria.Enabled = False

            ' Set Default
            CheckBoxSembuhMalaria.Checked = False
            DateTimeMalaria.Value = "01-01-1900"
        ElseIf ComboBoxMalaria.Text = "Ya" Then
            ' Set Enable True
            DateTimeMalaria.Enabled = True
            CheckBoxSembuhMalaria.Enabled = True
        End If
    End Sub

    Private Sub ComboBoxAmbeien_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxAmbeien.SelectedIndexChanged
        If ComboBoxAmbeien.Text = "Tidak" Or ComboBoxAmbeien.Text = "" Then
            ' Set Enable False
            DateTimeAmbeien.Enabled = False
            CheckBoxSembuhAmbeien.Enabled = False

            ' Set Default
            CheckBoxSembuhAmbeien.Checked = False
            DateTimeAmbeien.Value = "01-01-1900"
        ElseIf ComboBoxAmbeien.Text = "Ya" Then
            ' Set Enable True
            DateTimeAmbeien.Enabled = True
            CheckBoxSembuhAmbeien.Enabled = True
        End If
    End Sub

    Private Sub ComboBoxTHT_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxTHT.SelectedIndexChanged
        If ComboBoxTHT.Text = "Tidak" Or ComboBoxTHT.Text = "" Then
            ' Set Enable False
            DateTimeTHT.Enabled = False
            CheckBoxSembuhTHT.Enabled = False

            ' Set Default
            CheckBoxSembuhTHT.Checked = False
            DateTimeTHT.Value = "01-01-1900"
        ElseIf ComboBoxTHT.Text = "Ya" Then
            ' Set Enable True
            DateTimeTHT.Enabled = True
            CheckBoxSembuhTHT.Enabled = True
        End If
    End Sub

    Private Sub ComboBoxKencingBatu_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxKencingBatu.SelectedIndexChanged
        If ComboBoxKencingBatu.Text = "Tidak" Or ComboBoxKencingBatu.Text = "" Then
            ' Set Enable False
            DateTimeKencingBatu.Enabled = False
            CheckBoxSembuhKencingBatu.Enabled = False

            ' Set Default
            CheckBoxSembuhKencingBatu.Checked = False
            DateTimeKencingBatu.Value = "01-01-1900"
        ElseIf ComboBoxKencingBatu.Text = "Ya" Then
            ' Set Enable True
            DateTimeKencingBatu.Enabled = True
            CheckBoxSembuhKencingBatu.Enabled = True
        End If
    End Sub

    Private Sub ComboBoxVertigo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxVertigo.SelectedIndexChanged
        If ComboBoxVertigo.Text = "Tidak" Or ComboBoxVertigo.Text = "" Then
            ' Set Enable False
            DateTimeVertigo.Enabled = False
            CheckBoxSembuhVertigo.Enabled = False

            ' Set Default
            CheckBoxSembuhVertigo.Checked = False
            DateTimeVertigo.Value = "01-01-1900"
        ElseIf ComboBoxVertigo.Text = "Ya" Then
            ' Set Enable True
            DateTimeVertigo.Enabled = True
            CheckBoxSembuhVertigo.Enabled = True
        End If
    End Sub

    Private Sub ComboBoxAnorexia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxAnorexia.SelectedIndexChanged
        If ComboBoxAnorexia.Text = "Tidak" Or ComboBoxAnorexia.Text = "" Then
            ' Set Enable False
            DateTimeAnorexia.Enabled = False
            CheckBoxSembuhAnorexia.Enabled = False

            ' Set Default
            CheckBoxSembuhAnorexia.Checked = False
            DateTimeAnorexia.Value = "01-01-1900"
        ElseIf ComboBoxAnorexia.Text = "Ya" Then
            ' Set Enable True
            DateTimeAnorexia.Enabled = True
            CheckBoxSembuhAnorexia.Enabled = True
        End If
    End Sub

    Private Sub ComboBoxPingsan_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxPingsan.SelectedIndexChanged
        If ComboBoxPingsan.Text = "Tidak" Or ComboBoxPingsan.Text = "" Then
            ' Set Enable False
            DateTimePingsan.Enabled = False
            CheckBoxSembuhPingsan.Enabled = False

            ' Set Default
            CheckBoxSembuhPingsan.Checked = False
            DateTimePingsan.Value = "01-01-1900"
        ElseIf ComboBoxPingsan.Text = "Ya" Then
            ' Set Enable True
            DateTimePingsan.Enabled = True
            CheckBoxSembuhPingsan.Enabled = True
        End If
    End Sub

    Private Sub ComboBoxGastritis_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxGastritis.SelectedIndexChanged
        If ComboBoxGastritis.Text = "Tidak" Or ComboBoxGastritis.Text = "" Then
            ' Set Enable False
            DateTimeGastritis.Enabled = False
            CheckBoxSembuhGastritis.Enabled = False

            ' Set Default
            CheckBoxSembuhGastritis.Checked = False
            DateTimeGastritis.Value = "01-01-1900"
        ElseIf ComboBoxGastritis.Text = "Ya" Then
            ' Set Enable True
            DateTimeGastritis.Enabled = True
            CheckBoxSembuhGastritis.Enabled = True
        End If
    End Sub

    Private Sub ComboBoxPusing_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxPusing.SelectedIndexChanged
        If ComboBoxPusing.Text = "Tidak" Or ComboBoxPusing.Text = "" Then
            ' Set Enable False
            DateTimePusing.Enabled = False
            CheckBoxSembuhPusing.Enabled = False

            ' Set Default
            CheckBoxSembuhPusing.Checked = False
            DateTimePusing.Value = "01-01-1900"
        ElseIf ComboBoxPusing.Text = "Ya" Then
            ' Set Enable True
            DateTimePusing.Enabled = True
            CheckBoxSembuhPusing.Enabled = True
        End If
    End Sub

    Private Sub ComboBoxTypoidFever_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxTypoidFever.SelectedIndexChanged
        If ComboBoxTypoidFever.Text = "Tidak" Or ComboBoxTypoidFever.Text = "" Then
            ' Set Enable False
            DateTimeTypoidFever.Enabled = False
            CheckBoxSembuhTypoidFever.Enabled = False

            ' Set Default
            CheckBoxSembuhTypoidFever.Checked = False
            DateTimeTypoidFever.Value = "01-01-1900"
        ElseIf ComboBoxTypoidFever.Text = "Ya" Then
            ' Set Enable True
            DateTimeTypoidFever.Enabled = True
            CheckBoxSembuhTypoidFever.Enabled = True
        End If
    End Sub

    Private Sub ComboBoxTurunBB_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxTurunBB.SelectedIndexChanged
        If ComboBoxTurunBB.Text = "Tidak" Or ComboBoxTurunBB.Text = "" Then
            ' Set Enable False
            DateTimeTurunBB.Enabled = False
            CheckBoxSembuhTurunBB.Enabled = False

            ' Set Default
            CheckBoxSembuhTurunBB.Checked = False
            DateTimeTurunBB.Value = "01-01-1900"
        ElseIf ComboBoxTurunBB.Text = "Ya" Then
            ' Set Enable True
            DateTimeTurunBB.Enabled = True
            CheckBoxSembuhTurunBB.Enabled = True
        End If
    End Sub

    Private Sub CheckBoxSembuhTBC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxSembuhTBC.CheckedChanged
        Dim Ttbc As Date = DateSerial(DateTimeTBC.Value.Year, DateTimeTBC.Value.Month, DateTimeTBC.Value.Day).AddMonths(6)
        If Ttbc > Date.Now And CheckBoxSembuhTBC.Checked = True Then
            MsgBox("Status sembuh penyakit TBC harus lebih dari 6 bulan.", MsgBoxStyle.Exclamation, "Warning!")
            CheckBoxSembuhTBC.Checked = False
        End If
    End Sub

    Private Sub DateTimeTBC_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateTimeTBC.ValueChanged
        Dim Ttbc As Date = DateSerial(DateTimeTBC.Value.Year, DateTimeTBC.Value.Month, DateTimeTBC.Value.Day).AddMonths(6)
        If Ttbc > Date.Now And CheckBoxSembuhTBC.Checked = True Then
            MsgBox("Status sembuh penyakit TBC harus lebih dari 6 bulan.", MsgBoxStyle.Exclamation, "Warning!")
            CheckBoxSembuhTBC.Checked = False
        End If
    End Sub
End Class