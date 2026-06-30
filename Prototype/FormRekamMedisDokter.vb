Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Linq
Imports Newtonsoft.Json
Imports Newtonsoft
Imports System.Security.Cryptography
Imports System.Collections.Generic
Imports Newtonsoft.Json.Linq
Imports System.Drawing.Imaging
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraPrinting.Drawing
Imports PoliKlinik_Net2.ShapeDrawingFunctions
Imports System.Text
Imports System.Globalization
Imports System.Text.RegularExpressions

Public Class FormRekamMedisDokter

    Public Class TindakanDetail
        Private _TindakanID As String
        Private _NamaTindakan As String
        Private _JenisTindakan As String
        Private _BiayaTindakan As Decimal
        Private _DiskonTindakan As Decimal
        Private _NettBayar As Decimal
        Private _Jumlah As Integer
        Private _GrandTotal As Decimal

        Public Class varJson
            Public metaData As metaData
            Public response As Object   ' ganti jadi Object dulu biar bisa array atau single
        End Class

        Public Class metaData
            Private _code As String
            Private _message As String

            Public Property code() As String
                Get
                    Return _code
                End Get
                Set(ByVal value As String)
                    _code = value
                End Set
            End Property

            Public Property message() As String
                Get
                    Return _message
                End Get
                Set(ByVal value As String)
                    _message = value
                End Set
            End Property
        End Class

        Public Class responseItem
            Private _field As String
            Private _message As String

            Public Property field() As String
                Get
                    Return _field
                End Get
                Set(ByVal value As String)
                    _field = value
                End Set
            End Property

            Public Property message() As String
                Get
                    Return _message
                End Get
                Set(ByVal value As String)
                    _message = value
                End Set
            End Property
        End Class

        Public Property TindakanID() As String
            Get
                Return _TindakanID
            End Get
            Set(ByVal value As String)
                _TindakanID = value
            End Set
        End Property

        Public Property NamaTindakan() As String
            Get
                Return _NamaTindakan
            End Get
            Set(ByVal value As String)
                _NamaTindakan = value
            End Set
        End Property

        Public Property JenisTindakan() As String
            Get
                Return _JenisTindakan
            End Get
            Set(ByVal value As String)
                _JenisTindakan = value
            End Set
        End Property

        Public Property BiayaTindakan() As Decimal
            Get
                Return _BiayaTindakan
            End Get
            Set(ByVal value As Decimal)
                _BiayaTindakan = value
            End Set
        End Property

        Public Property DiskonTindakan() As Decimal
            Get
                Return _DiskonTindakan
            End Get
            Set(ByVal value As Decimal)
                _DiskonTindakan = value
            End Set
        End Property

        Public Property NettBayar() As Decimal
            Get
                Return _NettBayar
            End Get
            Set(ByVal value As Decimal)
                _NettBayar = value
            End Set
        End Property

        Public Property Jumlah() As Integer
            Get
                Return _Jumlah
            End Get
            Set(ByVal value As Integer)
                _Jumlah = value
            End Set
        End Property

        Public Property GrandTotal() As Decimal
            Get
                Return _GrandTotal
            End Get
            Set(ByVal value As Decimal)
                _GrandTotal = value
            End Set
        End Property
    End Class

    ' Connection
    Dim dbApotek As New TLcon

    ' Variabel Umum
    Private formName As String = "FORM REKAM MEDIS" ' Nama form
    Private userInput As String = PoliKlinik.Lbluser.Text ' User input program
    Private tblsRekamMedis As DataTable ' Tabel utama untuk menampilkan semua data tentang rekam medis

    ' Variabel untuk Tab Penandaan Gambar
    ' Deklarasi variabel global untuk menyimpan keterangan gambar
    Dim clickedPoint As Point
    Dim currentLabel As Label

    ' Deklarasi objek ToolTip
    Private WithEvents tooltip As New ToolTip()

    ' Variabel Penting
    Private idTransaksi As String = "" ' Berisi No Urut Transaksi
    Private jenisTransaksi As String ' Berisi Jenis Tujuan Poli
    Private idPasien As String ' Berisi No RM Pasien
    Public TglAwalFilter As Date = Date.MinValue
    Public TglAkhirFilter As Date = Date.MinValue

    ' Variabel BPJS
    Private urlPcare As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_base_url'")
    Private statusBPJS As Boolean = False ' Berisi Status BPJS false / true
    Private noBPJS As String = "" ' Berisi No BPJS Pasien (jika ada)
    Private noKunjunganBPJS As String = "" ' Berisi No Kunjungan BPJS (jika ada)

    ' Variabel Odontogram
    Private simbolOdontogram As String = ""
    'Private jenisOutputOdontogram As String = ""
    'Private textOutputOdontogram As String = ""
    'Private warnaOutputOdontogram As String = ""
    'Private gambarOutputOdontogram As String = ""
    'Private statusPerBagianOdontogram As Boolean = False
    Private tblsTransaksiOdontogram As DataTable ' Untuk simpan tabel temporary transaksi

    ' Penandaan Gambar
    Private startPoint1 As Point
    Private endPoint1 As Point
    Private startPoint2 As Point
    Private endPoint2 As Point

    Dim sedangLoadData As Boolean = False

    ' Set Default
    Private DrPelaksanaKlinik As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'DokterPK'")
    Private AutoTTD As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'AutoTTD'")

    Private Class varJson
        Public response As v4_BPJS
        Public metaData As MetaData
    End Class

    Private Sub ConnectionApotek()
        Dim Tbls As DataTable = ReadSQL("SELECT ConfigName, StrValue FROM MsConfig WHERE ConfigName IN ('NameDatabaseObat', 'AddressDatabaseObat', 'PasswordDatabaseObat')")
        dbApotek.Tid = "root"

        For Each Trow As DataRow In Tbls.Rows
            If Trow("ConfigName") = "NameDatabaseObat" Then
                dbApotek.Tdb = Trow("StrValue")
            ElseIf Trow("ConfigName") = "AddressDatabaseObat" Then
                dbApotek.Tip = Trow("StrValue")
            ElseIf Trow("ConfigName") = "PasswordDatabaseObat" Then
                dbApotek.Tpass = Trow("StrValue")
            End If
        Next
    End Sub

    Private Sub PanelTop_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelTop.Paint
        Try
            e.Graphics.DrawString(formName, New Font("Arial", 12, FontStyle.Bold), Brushes.White, New Point(10, 10))
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Warning!")
        End Try
    End Sub

    Private ttRisikoDM As New ToolTip()

    Private Sub FormRekamMedisDokter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
            Me.MdiParent = PoliKlinik
            Me.Dock = DockStyle.Fill

            ' Hide tab header button
            'TabControlMenuUtama.Appearance = TabAppearance.FlatButtons
            TabControlMenuUtama.ItemSize = New Size(0, 1)
            'TabControlMenuUtama.SizeMode = TabSizeMode.Fixed

            ' Hide tab header button
            TabControlPerencanaan.ItemSize = New Size(0, 1)
            TabControlObjektif.ItemSize = New Size(0, 1)
            TabControlSuratKeterangan.ItemSize = New Size(0, 1)
            TabControlPerencanaan.ItemSize = New Size(0, 1)
            TabControlCekStik.ItemSize = New Size(0, 1)
            TabControlMenu1.ItemSize = New Size(0, 1)

            '# Load Placeholder
            ' On Proggress

            '# Load Font DataGridView
            LoadFontDataGridView()

            '# Load Notification
            LoadNotification(True)

            '# Load Connection
            ConnectionApotek()

            '# Load Surat Persetujuan

            '# Load PDF
            Call MuatPDFByTransaksiNoRM(idTransaksi, idPasien)

            'Cek riwayat B20
            'Dim dt As DataTable = GetRiwayatB20(idPasien)

            'If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then

            '    Dim kode As String = dt.Rows(0)("KodeDiagnosa").ToString()
            '    Dim ket As String = dt.Rows(0)("KeteranganDiagnosa").ToString()

            '    MsgBox("PERHATIAN!" & vbCrLf & _
            '           "Pasien memiliki riwayat diagnosa: " & kode & vbCrLf & _
            '           "Keterangan    : " & ket, MsgBoxStyle.Exclamation, "Warning!")

            'End If

            '========================================
            ' TAMPILAN RISIKO DM SAAT FORM LOAD
            '========================================
            Try
                If idPasien <> "" Then
                    Dim risiko As Dictionary(Of String, String) = HitungRisikoDM_Tahap2(idPasien)

                    If risiko.Count > 0 Then
                        LabelResikoDM.Text = "Risiko DM : " & risiko("StatusRisiko") & _
                                             " | Skor : " & risiko("Skor")

                        Select Case risiko("StatusRisiko")
                            Case "RENDAH"
                                LabelResikoDM.ForeColor = Color.Green
                            Case "SEDANG"
                                LabelResikoDM.ForeColor = Color.Orange
                            Case "TINGGI"
                                LabelResikoDM.ForeColor = Color.Red
                        End Select
                    Else
                        LabelResikoDM.Text = "Risiko DM : -"
                        LabelResikoDM.ForeColor = Color.Black
                    End If
                End If
            Catch
                LabelResikoDM.Text = "Risiko DM : -"
            End Try


            '========================================
            ' TAMPILAN RISIKO HT SAAT FORM LOAD
            '========================================
            Try
                If idPasien <> "" Then
                    Dim risikoHT As Dictionary(Of String, String) = HitungRisikoHipertensi_Tahap2(idPasien)

                    If risikoHT.Count > 0 Then
                        LabelRisikoHT.Text = "Risiko HT : " & risikoHT("StatusRisiko") & _
                                             " | Skor : " & risikoHT("Skor")

                        Select Case risikoHT("StatusRisiko")
                            Case "RENDAH"
                                LabelRisikoHT.ForeColor = Color.Green
                            Case "SEDANG"
                                LabelRisikoHT.ForeColor = Color.Orange
                            Case "TINGGI"
                                LabelRisikoHT.ForeColor = Color.Red
                        End Select
                    Else
                        LabelRisikoHT.Text = "Risiko HT : -"
                        LabelRisikoHT.ForeColor = Color.Black
                    End If
                End If
            Catch
                LabelRisikoHT.Text = "Risiko HT : -"
            End Try

            '========================================
            ' TAMPILKAN RISIKO STROKE SAAT FORM LOAD
            '========================================
            Try
                Dim risikoDM As Dictionary(Of String, String) = HitungRisikoDM_Tahap2(idPasien)
                Dim risikoHT As Dictionary(Of String, String) = HitungRisikoHipertensi_Tahap2(idPasien)

                If risikoDM.Count > 0 And risikoHT.Count > 0 Then
                    Dim Umur As Integer = CInt(risikoDM("Umur"))
                    Dim StatusDM As String = risikoDM("StatusRisiko")
                    Dim StatusHT As String = risikoHT("StatusRisiko")
                    Dim IMT As Double = CDbl(risikoDM("RataIMT"))

                    Dim risikoStroke As Dictionary(Of String, String) = HitungRisikoStroke(Umur, StatusDM, StatusHT, IMT)

                    LabelRisikoStroke.Text = "Risiko Stroke : " & _
                                             risikoStroke("StatusRisiko") & _
                                             " | Skor : " & risikoStroke("Skor")

                    Select Case risikoStroke("StatusRisiko")
                        Case "RENDAH"
                            LabelRisikoStroke.ForeColor = Color.Green
                        Case "SEDANG"
                            LabelRisikoStroke.ForeColor = Color.Orange
                        Case "TINGGI"
                            LabelRisikoStroke.ForeColor = Color.Red
                    End Select
                End If
            Catch ex As Exception
                LabelRisikoStroke.Text = "Risiko Stroke : -"
            End Try


            '========================================
            ' TAMPILKAN ICD ASISTAN FORM LOAD
            '========================================
            Try
                If idPasien <> "" Then
                    TextBoxSaranDiagnosa.Text = GetSaranDiagnosaICD_ML(idPasien)

                    If TextBoxSaranDiagnosa.Text.Trim() = "" Then
                        TextBoxSaranDiagnosa.Text = "-"
                    End If
                End If
            Catch
                TextBoxSaranDiagnosa.Text = "-"
            End Try

            '# Set Timer Notification
            TimerNotifikasi.Interval = 1000 ' berkedip setiap 1000ms (1 detik)

            'Cek Stik Jenis
            ComboBoxJenisCekStik.SelectedIndex = ComboBoxJenisCekStik.Items.IndexOf("GULA DARAH")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Warning!")
        End Try
    End Sub

    Private Sub ButtonMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonMenu7.Click, ButtonMenu6.Click, ButtonMenu5.Click, ButtonMenu4.Click, ButtonMenu3.Click, ButtonMenu2.Click, ButtonMenu1.Click
        Try
            Dim myButton = DirectCast(sender, Button)

            '# Set Default Warna Button
            ButtonMenu1.BackColor = Color.FromArgb(0, 100, 200)
            ButtonMenu2.BackColor = Color.FromArgb(0, 100, 200)
            ButtonMenu3.BackColor = Color.FromArgb(0, 100, 200)
            ButtonMenu4.BackColor = Color.FromArgb(0, 100, 200)
            ButtonMenu5.BackColor = Color.FromArgb(0, 100, 200)
            ButtonMenu6.BackColor = Color.FromArgb(0, 100, 200)
            ButtonMenu7.BackColor = Color.FromArgb(0, 100, 200)
            ButtonSideMenu1.Visible = False
            ButtonSideMenu2.Visible = False
            ButtonSideMenu3.Visible = False
            ButtonSideMenu4.Visible = False
            ButtonSideMenu5.Visible = False
            ButtonSideMenu6.Visible = False
            ButtonSideMenu7.Visible = False
            ButtonSideMenu8.Visible = False

            '# Ganti Tab Page
            Select Case myButton.Name
                Case "ButtonMenu1"
                    TabControlMenuUtama.SelectedTab = TabPage1
                    ButtonSideMenu1.Visible = True
                Case "ButtonMenu2"
                    TabControlMenuUtama.SelectedTab = TabPage2
                    ButtonSideMenu2.Visible = True
                Case "ButtonMenu3"
                    TabControlMenuUtama.SelectedTab = TabPage3
                    ButtonSideMenu3.Visible = True
                Case "ButtonMenu4"
                    TabControlMenuUtama.SelectedTab = TabPage4
                    ButtonSideMenu4.Visible = True
                Case "ButtonMenu5"
                    TabControlMenuUtama.SelectedTab = TabPage7
                    ButtonSideMenu5.Visible = True
                Case "ButtonMenu6"
                    TabControlMenuUtama.SelectedTab = TabPage8
                    ButtonSideMenu7.Visible = True
                Case "ButtonMenu7"
                    TabControlMenuUtama.SelectedTab = TabPage9
                    ButtonSideMenu8.Visible = True
            End Select

            '# Ganti Warna Button
            myButton.BackColor = Color.FromArgb(0, 130, 255)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Warning!")
        End Try
    End Sub

    Public Sub BukaTabRiwayat()
        TabControlMenuUtama.SelectedTab = TabPage3
        ButtonSideMenu3.Visible = True
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub SetClear()
        ' Click Button
        SetButton()

        ' Clear Pemeriksaan Awal
        ClearPemeriksaanAwal()

        ' Clear Medik
        ClearMedik()

        ' Clear Pasien
        ClearDataPasien()

        ' Clear DataGridView
        ClearDataGridView()
    End Sub

    Public Sub SetDataFromPendaftaran(ByRef _idPasien As String, ByRef _idTransaksi As String, ByRef _jenisTransaksi As String)
        idPasien = _idPasien
        idTransaksi = _idTransaksi
        jenisTransaksi = _jenisTransaksi

        SetClear()
        SetDataRekamMedis()
    End Sub

    Private Sub ClearDataGridView()
        DataGridViewRiwayatKunjungan.Rows.Clear()
        DataGridViewRiwayatKunjungan.Columns.Clear()

        DataGridViewRiwayatGigi.Rows.Clear()
        DataGridViewRiwayatGigi.Columns.Clear()

        'DataGridViewRiwayatLaboratorium.Rows.Clear()
        'DataGridViewRiwayatLaboratorium.Columns.Clear()
        DataGridViewRiwayatLaboratorium.DataSource = Nothing
    End Sub

    Private Sub ClearDataPasien()
        ' Set Clear
        TextBoxNoRM.ResetText()
        TextBoxNomorNIK.ResetText()
        TextBoxNomorKIS.ResetText()
        TextBoxFaskesAktif.ResetText()
        TextBoxStatusAktif.ResetText()
        TextBoxProlanis.ResetText()
        TextBoxPRB.ResetText()
        TextBoxStatusPeserta.ResetText()
        TextBoxFKTP.ResetText()
        TextBoxNamaLengkapIdentitas.ResetText()
        TextBoxTempatLahir.ResetText()
        DateTimePickerTglLahir.Value = DateSerial("9998", "12", "31")
        RadioButtonJenisKelaminLakiIdentitas.Checked = True
        ComboBoxGolDarahIdentitas.Text = "-"
        ComboBoxStatusKeluarga.Text = "-"
        TextBoxPekerjaan.ResetText()
        TextBoxNomorNIP.ResetText()
        TextBoxNomorInhealth.ResetText()
        TextBoxNomorJPK.ResetText()
        TextBoxNomorCahaya.ResetText()
        TextBoxAlamatKTP.ResetText()
        TextBoxRTKTP.ResetText()
        TextBoxRWKTP.ResetText()
        TextBoxKelurahanKTP.ResetText()
        TextBoxKecamatanKTP.ResetText()
        TextBoxKodePosKTP.ResetText()
        TextBoxNoRM.ResetText()
        TextBoxNoRM.ResetText()
        TextBoxNoRM.ResetText()
        CheckBoxCopyAlamatKTP.Checked = False
        TextBoxAlamatDomisili.ResetText()
        TextBoxRTDomisili.ResetText()
        TextBoxRWDomisili.ResetText()
        TextBoxKelurahanDomisili.ResetText()
        TextBoxKecamatanDomisili.ResetText()
        TextBoxKodePosDomisili.ResetText()
        TextBoxNoHPIdentitas.ResetText()
        TextBoxNoTeleponIdentitas.ResetText()
        TextBoxEmailIdentitas.ResetText()
        ComboBoxStatusPerkawinan.Text = "-"
        ComboBoxPendidikanTerakhir.Text = "-"
        ComboBoxAgama.Text = "-"
        RadioButtonWNI.Checked = True
        TextBoxKetWNA.ResetText()

        ' Informasi Wali
        CheckBoxStatusWaliPasien.Checked = False
        TextBoxNamaLengkapWali.ResetText()
        TextBoxTempatLahirWali.ResetText()
        TextBoxAlamatDomisiliWali.ResetText()
        TextBoxNoHPWali.ResetText()
        TextBoxHubunganKeluargaWali.ResetText()
    End Sub

    Private Sub SetButton()
        ' Button Side Menu
        ButtonMenu_Click(ButtonMenu1, EventArgs.Empty)

        ' Button Objektif
        ButtonObjektif_Click(ButtonObjektifFisik, EventArgs.Empty)

        ' Button Perencanaan
        ButtonPerencanaan_Click(ButtonResep, EventArgs.Empty)

        ' Button Strip Menu
        ToolStripMenuItem_Click(PemeriksaanAwalToolStripMenuItem, EventArgs.Empty)
    End Sub

    'DEBUG
    'Private Sub SetDataRekamMedis()
    '    Dim Tquery As String = ""

    '    ' Cek isi variabel awal
    '    MsgBox("DEBUG: jenisTransaksi=" & jenisTransaksi & vbCrLf & _
    '       "idTransaksi=" & idTransaksi)

    '    If jenisTransaksi = "UMUM" Or jenisTransaksi = "POLI" Then
    '        Tquery = "SELECT TransaksiPoli.TransPoliID, TransaksiPoli.DokterPoli AS 'NamaDokter', TransaksiPoli.PerawatPoli AS 'NamaPerawat', TransaksiPoli.KodeDokter, TransaksiPoli.TglPoli AS 'TglTransaksi', TransaksiPoli.Status, TransaksiDetail.*, MasterPasien.* " & _
    '                 "FROM TransaksiPoli " & _
    '                 "LEFT JOIN TransaksiDetail ON TransaksiDetail.NoUrut = TransaksiPoli.NoUrut " & _
    '                 "LEFT JOIN MasterPasien ON MasterPasien.NoRekamMedis = TransaksiPoli.IDInternet " & _
    '                 "WHERE TransaksiPoli.NoUrut = '" & idTransaksi & "'"
    '    ElseIf jenisTransaksi = "GIGI" Then
    '        Tquery = "SELECT TransaksiGigi.TransGigiID, TransaksiGigi.DokterGigi AS 'NamaDokter', TransaksiGigi.PerawatGigi AS 'NamaPerawat', TransaksiGigi.KodeDokter, TransaksiGigi.TglGigi AS 'TglTransaksi', TransaksiGigi.Status, TransaksiDetail.*, MasterPasien.* " & _
    '                 "FROM TransaksiGigi " & _
    '                 "LEFT JOIN TransaksiDetail ON TransaksiDetail.NoUrut = TransaksiGigi.NoUrut " & _
    '                 "LEFT JOIN MasterPasien ON MasterPasien.NoRekamMedis = TransaksiGigi.IDInternet " & _
    '                 "WHERE TransaksiGigi.NoUrut = '" & idTransaksi & "'"
    '    End If

    '    ' Cek query final
    '    MsgBox("DEBUG: Query yang dieksekusi:" & vbCrLf & Tquery)

    '    ' Eksekusi query
    '    tblsRekamMedis = ReadSQL(Tquery)

    '    ' Cek hasil dataset
    '    If tblsRekamMedis IsNot Nothing Then
    '        MsgBox("DEBUG: Jumlah baris tblsRekamMedis = " & tblsRekamMedis.Rows.Count)
    '    Else
    '        MsgBox("DEBUG: tblsRekamMedis = Nothing")
    '    End If

    '    '# Load All Grid
    '    LoadDataPasien()
    '    LoadGridPenandaanGambar()
    '    LoadGridAlergiPasien()
    '    LoadGridResepObat()
    '    LoadGridRiwayatDiagnosa()
    '    LoadGridTindakanPoli()
    '    LoadGridRiwayatPemeriksaanPenunjang()

    '    DataGridViewRiwayatLaboratorium.DataSource = CreateTableRiwayatLaboratorium()

    '    '# Load ListView
    '    CreateListViewRacikanTemp()

    '    '# Load ComboBox
    '    LoadComboBoxStatusPulang()
    '    LoadComboBoxPoliTujuan()
    '    LoadComboBoxPrognosa()
    '    LoadComboBoxPoliGambar()

    '    '# Load Data RM
    '    SetInfoPasien()
    '    SetPemeriksaanAwal()
    '    SetMedik()
    '    SetGambarPenanda()

    '    '# Hidden Tab Page
    '    HiddenTabPage()
    'End Sub

    Private Sub SetDataRekamMedis()
        Dim Tquery As String = ""

        If jenisTransaksi = "UMUM" Or jenisTransaksi = "POLI" Then
            Tquery = "SELECT TransaksiPoli.TransPoliID, TransaksiPoli.DokterPoli AS 'NamaDokter', TransaksiPoli.PerawatPoli AS 'NamaPerawat', TransaksiPoli.KodeDokter, TransaksiPoli.TglPoli AS 'TglTransaksi', TransaksiPoli.Status, TransaksiDetail.*, MasterPasien.* " & _
                     "FROM TransaksiPoli " & _
                     "LEFT JOIN TransaksiDetail ON TransaksiDetail.NoUrut = TransaksiPoli.NoUrut " & _
                     "LEFT JOIN MasterPasien ON MasterPasien.NoRekamMedis = TransaksiPoli.IDInternet " & _
                     "WHERE TransaksiPoli.NoUrut = '" & idTransaksi & "'"
        ElseIf jenisTransaksi = "GIGI" Then
            Tquery = "SELECT TransaksiGigi.TransGigiID, TransaksiGigi.DokterGigi AS 'NamaDokter', TransaksiGigi.PerawatGigi AS 'NamaPerawat', TransaksiGigi.KodeDokter, TransaksiGigi.TglGigi AS 'TglTransaksi', TransaksiGigi.Status, TransaksiDetail.*, MasterPasien.* " & _
                     "FROM TransaksiGigi " & _
                     "LEFT JOIN TransaksiDetail ON TransaksiDetail.NoUrut = TransaksiGigi.NoUrut " & _
                     "LEFT JOIN MasterPasien ON MasterPasien.NoRekamMedis = TransaksiGigi.IDInternet " & _
                     "WHERE TransaksiGigi.NoUrut = '" & idTransaksi & "'"
        End If

        tblsRekamMedis = ReadSQL(Tquery)

        '# Load All Grid
        LoadDataPasien()
        LoadGridPenandaanGambar()
        LoadGridAlergiPasien()
        LoadGridResepObat()
        LoadGridRiwayatDiagnosa()
        LoadGridTindakanPoli()
        LoadGridRiwayatPemeriksaanPenunjang()

        DataGridViewRiwayatLaboratorium.DataSource = CreateTableRiwayatLaboratorium()

        '# Load ListView
        CreateListViewRacikanTemp()

        '# Load ComboBox
        LoadComboBoxStatusPulang()
        LoadComboBoxPoliTujuan()
        LoadComboBoxPrognosa()
        LoadComboBoxPoliGambar()

        '# Load Data RM
        SetInfoPasien()
        SetPemeriksaanAwal()
        SetMedik()
        SetGambarPenanda()

        '# Hidden Tab Page
        HiddenTabPage()

        '# Load Placeholder
    End Sub

    Private Sub LoadDataPasien()
        Dim kdProviderLokal As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'KodePPK'")

        Dim jenisKelaminPasien As String = ""

        ' Load data dari tabel MasterPasien
        Dim Tbls As DataTable = ReadSQL("SELECT * FROM MasterPasien a LEFT JOIN MasterPasienBPJS b ON a.NoKartuBPJS = b.NoKartu WHERE NoRekamMedis = '" & idPasien & "'")
        Dim Trow As DataRow = Tbls.Rows(0)

        ' Insert data ke textbox
        If IsDBNull(Trow("NoRekamMedis")) = False Then TextBoxNoRM.Text = Trow("NoRekamMedis")
        If IsDBNull(Trow("NoNIK")) = False Then TextBoxNomorNIK.Text = Trow("NoNIK")
        If IsDBNull(Trow("NoNIP")) = False Then TextBoxNomorNIP.Text = Trow("NoNIP")
        If IsDBNull(Trow("NoKartuInhealth")) = False Then TextBoxNomorInhealth.Text = Trow("NoKartuInhealth")
        If IsDBNull(Trow("NoKartuJPK")) = False Then TextBoxNomorJPK.Text = Trow("NoKartuJPK")
        If IsDBNull(Trow("NoKartuCahaya")) = False Then TextBoxNomorCahaya.Text = Trow("NoKartuCahaya")
        If IsDBNull(Trow("Nama")) = False Then TextBoxNamaLengkapIdentitas.Text = Trow("Nama")
        If IsDBNull(Trow("Prolanis")) = False Then TextBoxProlanis.Text = Trow("Prolanis")
        If IsDBNull(Trow("PRB")) = False Then TextBoxPRB.Text = Trow("PRB")
        If IsDBNull(Trow("TempatLahir")) = False Then TextBoxTempatLahir.Text = Trow("TempatLahir")
        If IsDBNull(Trow("TglLahir")) = False Then DateTimePickerTglLahir.Text = Trow("TglLahir")

        If Trow("JenisKelamin") = "L" Then
            RadioButtonJenisKelaminLakiIdentitas.Checked = True
            jenisKelaminPasien = "L"
        ElseIf Trow("JenisKelamin") = "P" Then
            RadioButtonJenisKelaminPerempuanIdentitas.Checked = True
            jenisKelaminPasien = "P"
        End If

        If IsDBNull(Trow("GolonganDarah")) = False Then ComboBoxGolDarahIdentitas.Text = Trow("GolonganDarah")
        If IsDBNull(Trow("DomisiliAlamat")) = False Then TextBoxAlamatDomisili.Text = Trow("DomisiliAlamat")
        If IsDBNull(Trow("DomisiliRT")) = False Then TextBoxRTDomisili.Text = Trow("DomisiliRT")
        If IsDBNull(Trow("DomisiliRW")) = False Then TextBoxRWDomisili.Text = Trow("DomisiliRW")
        If IsDBNull(Trow("DomisiliKelurahan")) = False Then TextBoxKelurahanDomisili.Text = Trow("DomisiliKelurahan")
        If IsDBNull(Trow("DomisiliKecamatan")) = False Then TextBoxKecamatanDomisili.Text = Trow("DomisiliKecamatan")
        If IsDBNull(Trow("DomisiliKodePos")) = False Then TextBoxKodePosDomisili.Text = Trow("DomisiliKodePos")
        If IsDBNull(Trow("KtpAlamat")) = False Then TextBoxAlamatKTP.Text = Trow("KtpAlamat")
        If IsDBNull(Trow("KtpRT")) = False Then TextBoxRTKTP.Text = Trow("KtpRT")
        If IsDBNull(Trow("KtpRW")) = False Then TextBoxRWKTP.Text = Trow("KtpRW")
        If IsDBNull(Trow("KtpKelurahan")) = False Then TextBoxKelurahanKTP.Text = Trow("KtpKelurahan")
        If IsDBNull(Trow("KtpKecamatan")) = False Then TextBoxKecamatanKTP.Text = Trow("KtpKecamatan")
        If IsDBNull(Trow("KtpKodePos")) = False Then TextBoxKodePosKTP.Text = Trow("KtpKodePos")
        If IsDBNull(Trow("NoHandphone")) = False Then TextBoxNoHPIdentitas.Text = Trow("NoHandphone")
        If IsDBNull(Trow("NoTelepon")) = False Then TextBoxNoTeleponIdentitas.Text = Trow("NoTelepon")
        If IsDBNull(Trow("Email")) = False Then TextBoxEmailIdentitas.Text = Trow("Email")
        If IsDBNull(Trow("PendidikanTerakhir")) = False Then ComboBoxPendidikanTerakhir.Text = Trow("PendidikanTerakhir")
        If IsDBNull(Trow("StatusPerkawinan")) = False Then ComboBoxStatusPerkawinan.Text = Trow("StatusPerkawinan")
        If IsDBNull(Trow("Agama")) = False Then ComboBoxAgama.Text = Trow("Agama")

        If IsDBNull(Trow("Kewarganegaraan")) = False Then
            If Trow("Kewarganegaraan") = "WNI" Then
                RadioButtonWNI.Checked = True
            ElseIf Trow("Kewarganegaraan") = "WNA" Then
                RadioButtonWNA.Checked = True
                If IsDBNull(Trow("KeteranganKewarganegaraanAsing")) = False Then TextBoxKetWNA.Text = Trow("KeteranganKewarganegaraanAsing")
            End If
        End If

        If IsDBNull(Trow("StatusKeluarga")) = False Then ComboBoxStatusKeluarga.Text = Trow("StatusKeluarga")
        If IsDBNull(Trow("Pekerjaan")) = False Then TextBoxPekerjaan.Text = Trow("Pekerjaan")

        ' Load data BPJS jika ada
        If IsDBNull(Trow("NoKartu")) = False Then
            Dim statusAktif As String = ""
            Dim statusFKTP As Boolean = True

            TextBoxNomorKIS.Text = Trow("NoKartu")

            If kdProviderLokal <> Trow("KdProviderPst") Then
                statusFKTP = False
            End If

            If statusFKTP = False Then
                statusAktif = Trow("KetAktif") & ", tidak terdaftar di FKTP ini dan rekanan."
                TextBoxFaskesAktif.Text = "Tidak"
            Else
                statusAktif = Trow("KetAktif")
                TextBoxFaskesAktif.Text = "Ya"
            End If

            TextBoxStatusAktif.Text = statusAktif
            TextBoxFKTP.Text = Trow("KdProviderPst") & " ~ " & Trow("NmProviderPst")
            If IsDBNull(Trow("HubunganKeluarga")) = False Then TextBoxStatusPeserta.Text = Trow("HubunganKeluarga")
        Else
            TextBoxNomorKIS.ResetText()
            TextBoxFaskesAktif.ResetText()
            TextBoxStatusAktif.ResetText()
            TextBoxFKTP.ResetText()
            TextBoxStatusPeserta.ResetText()
        End If

        ' Set data readonly
        TextBoxNomorNIK.ReadOnly = True
        TextBoxNomorNIK.BackColor = SystemColors.Window
    End Sub

    Private Function GetRiwayatB20(ByVal idInternet As String) As DataTable
        Try
            Dim sql As String = _
            "SELECT TOP 1 TDD.KodeDiagnosa, TDD.KeteranganDiagnosa " & _
            "FROM TransaksiDetailDiagnosa TDD " & _
            "INNER JOIN TransaksiDetail TD ON TDD.NoTransaksi = TD.NoUrut " & _
            "WHERE ( " & _
            "    TDD.KodeDiagnosa LIKE 'B16%' " & _
            " OR TDD.KodeDiagnosa LIKE 'B17%' " & _
            " OR TDD.KodeDiagnosa LIKE 'B18%' " & _
            " OR TDD.KodeDiagnosa LIKE 'B19%' " & _
            " OR TDD.KodeDiagnosa LIKE 'B20%' " & _
            " OR TDD.KodeDiagnosa LIKE 'B21%' " & _
            " OR TDD.KodeDiagnosa LIKE 'B22%' " & _
            " OR TDD.KodeDiagnosa LIKE 'B23%' " & _
            " OR TDD.KodeDiagnosa LIKE 'B24%' " & _
            ") " & _
            "AND TD.IDInternet = '" & idInternet & "' " & _
            "AND TDD.DeletedBy IS NULL"

            Return ReadSQL(sql)

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Private Sub LoadNotification(ByVal messageBox As Boolean)

        TimerNotifikasi.Stop()
        PanelNotifikasi.Visible = False

        Dim alergiList As New List(Of String)
        Dim ketAlergi As String = ""

        Dim daftarAlergiMakanan As String = GetListAlergi("Makanan", idPasien)
        Dim daftarAlergiObat As String = GetListAlergi("Obat", idPasien)

        'Riwayat B20
        Dim dtRiwayatB20 As DataTable = GetRiwayatB20(idPasien)

        If daftarAlergiMakanan.Count > 0 Then
            alergiList.Add("Alergi Makanan : " & daftarAlergiMakanan)
        End If

        If daftarAlergiObat.Count > 0 Then
            alergiList.Add("Alergi Obat : " & daftarAlergiObat)
        End If

        If dtRiwayatB20 IsNot Nothing AndAlso dtRiwayatB20.Rows.Count > 0 Then
            Dim kode As String = dtRiwayatB20.Rows(0)("KodeDiagnosa").ToString()
            Dim ket As String = dtRiwayatB20.Rows(0)("KeteranganDiagnosa").ToString()

            alergiList.Add("Riwayat Diagnosa : " & kode & " - " & ket)
        End If

        If alergiList.Count > 0 Then
            ketAlergi = String.Join(vbCrLf, alergiList.ToArray())
        End If

        If ketAlergi <> "" Then

            TextBoxNotifikasi.Text = ketAlergi

            TimerNotifikasi.Start()
            PanelNotifikasi.Visible = True

            'If messageBox Then
            '    MsgBox("Pasien memiliki catatan penting." & vbCrLf & ketAlergi, MsgBoxStyle.Exclamation, "Warning!")
            'End If

        End If

    End Sub

    Private Sub LoadFontDataGridView()
        DataGridViewRiwayatKunjungan.DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        DataGridViewRiwayatKunjungan.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI Semibold", 10, FontStyle.Bold)

        DataGridViewRiwayatGigi.DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        DataGridViewRiwayatGigi.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI Semibold", 10, FontStyle.Bold)

        DataGridViewDiagnosa.DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        DataGridViewDiagnosa.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI Semibold", 10, FontStyle.Bold)

        DataGridViewObat.DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        DataGridViewObat.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI Semibold", 10, FontStyle.Bold)

        DataGridViewTindakan.DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        DataGridViewTindakan.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI Semibold", 10, FontStyle.Bold)

        DataGridViewPemeriksaanPenunjang.DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        DataGridViewPemeriksaanPenunjang.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI Semibold", 10, FontStyle.Bold)

        DataGridViewRiwayatLaboratorium.DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        DataGridViewRiwayatLaboratorium.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI Semibold", 10, FontStyle.Bold)
    End Sub

    Private Sub HiddenTabPage()
        If tblsRekamMedis.Rows.Count > 0 Then
            Dim Trow As DataRow = tblsRekamMedis.Rows(0)

            TabRecycle.Hide()
            TabControlMenu1.TabPages.Remove(TabRecycle)

            If jenisTransaksi = "UMUM" Or jenisTransaksi = "POLI" Then
                ' Elemen gigi pada diagnosa (Assesmen)
                LabelElemenGigi.Visible = False
                ComboBoxElemenGigi.Visible = False

                ' Pemeriksaan Gigi
                ButtonObjektifPemeriksaanGigi.Visible = False
            ElseIf jenisTransaksi = "GIGI" Then
                ' Elemen gigi pada diagnosa (Assesmen)
                LabelElemenGigi.Visible = True
                ComboBoxElemenGigi.Visible = True

                ' Pemeriksaan Gigi
                ButtonObjektifPemeriksaanGigi.Visible = True
            End If

            If Trow("StatusDifabel") = False Then
                TabPageResikoJatuh.Hide()
                TabControlAnamnesis.TabPages.Remove(TabPageResikoJatuh)
            End If

            If Trow("StatusGawatDarurat") = False Then

            End If
        End If
    End Sub

    Private Sub SetInfoPasien()
        Dim dataPasien As String = ""
        Dim dataTransaksi As String = ""

        ' Default Variabel BPJS
        statusBPJS = False
        noBPJS = ""
        noKunjunganBPJS = ""

        If tblsRekamMedis.Rows.Count > 0 Then
            Dim Trow As DataRow = tblsRekamMedis.Rows(0)

            'Nama Company
            Dim idTransaksi As String = Trow("NoUrut")
            Dim sqlGetCompany As String = "SELECT mc.CompanyNama FROM TransaksiPoli d JOIN TransaksiPoliBayarAwal t ON t.TransPoliID = d.TransPoliID JOIN MasterCompany mc ON mc.NoCompany = LTRIM(RTRIM(SUBSTRING(t.NoJenisBayar, CHARINDEX('-', t.NoJenisBayar) + 1, LEN(t.NoJenisBayar))))WHERE d.NoUrut = '" & idTransaksi & "'"
            Dim companyNama As String = ReadSQLNIK(sqlGetCompany)


            ' Set Variabel BPJS
            If IsDBNull(Trow("StatusBPJS")) = False Then statusBPJS = Trow("StatusBPJS")
            If IsDBNull(Trow("NoKartuBPJS")) = False Then noBPJS = Trow("NoKartuBPJS")
            If IsDBNull(Trow("NoKunjunganBPJS")) = False Then noKunjunganBPJS = Trow("NoKunjunganBPJS")

            ' Data Pasien
            Dim namaPasien As String = Trow("Nama")
            Dim tglLahirPasien As String = Format(Trow("TglLahir"), "dd") & " " & BulanIndonesia(Format(Trow("TglLahir"), "MM")) & " " & Format(Trow("TglLahir"), "yyyy")
            Dim umurPasien As String = Umur(Trow("TglLahir"))
            Dim noRekamMedis As String = Trow("NoRekamMedis")
            dataPasien = "Data Pasien : " & namaPasien & " / " & tglLahirPasien & " (" & umurPasien & ") / " & noRekamMedis

            LabelDataPasien.Text = dataPasien

            ' Data Penagihan
            Dim jenisPenagihan As String = ""
            If IsDBNull(Trow("JenisPenagihan")) = False Then
                jenisPenagihan = "Tagihan: " & Trow("JenisPenagihan").ToString
            Else
                jenisPenagihan = "Tagihan: " & GetJenisPembayaran(Trow("JenisTransaksi"), Trow("NoUrut"))
            End If

            ' Data Transaksi
            Dim noTransaksi As String = Trow("NoUrut")
            Dim tglTransaksi As String = Format(Trow("TanggalTransaksi"), "yyyy-MM-dd HH:mm:ss")

            dataTransaksi = "Data Transaksi : " & Trow("JenisPoli") & " (" & noTransaksi & ")" & " / " & tglTransaksi & " / " & jenisPenagihan

            If companyNama <> "" Then
                If jenisPenagihan <> "Tagihan: BPJS" AndAlso jenisPenagihan <> "Tagihan: UMUM" Then
                    dataTransaksi &= " (" & companyNama & ")"
                End If
            End If

            LabelDataTransaksi.Text = dataTransaksi
        End If
    End Sub

    Private Sub SetMedik()
        If tblsRekamMedis.Rows.Count > 0 Then
            Dim Trow As DataRow = tblsRekamMedis.Rows(0)

            '# SUBJEKTIF
            ' Umum
            If IsDBNull(Trow("KeluhanUtama")) = False Then TextBoxKeluhanUtamaMedik.Text = Trow("KeluhanUtama").ToString.Trim
            If IsDBNull(Trow("KeluhanTambahan")) = False Then TextBoxKeluhanTambahanMedik.Text = Trow("KeluhanTambahan").ToString.Trim
            If IsDBNull(Trow("RiwayatPenyakitSekarang")) = False Then TextBoxRiwayatPenyakitSekarang.Text = Trow("RiwayatPenyakitSekarang").ToString.Trim
            If IsDBNull(Trow("RiwayatPenggunaanObat")) = False Then TextBoxRiwayatPenggunaanObat.Text = Trow("RiwayatPenggunaanObat").ToString.Trim

            ' Riwayat Penyakit
            If IsDBNull(Trow("RiwayatPenyakitDahulu")) = False Then TextBoxRiwayatPenyakitDahuluMedik.Text = Trow("RiwayatPenyakitDahulu").ToString.Trim
            If IsDBNull(Trow("RiwayatPenyakitKeluarga")) = False Then TextBoxRiwayatPenyakitKeluargaMedik.Text = Trow("RiwayatPenyakitKeluarga").ToString.Trim
            If IsDBNull(Trow("RiwayatKebiasaan")) = False Then TextBoxRiwayatKebiasaanMedik.Text = Trow("RiwayatKebiasaan").ToString.Trim

            '# OBJEKTIF
            ' Vital Statistik & Antropometri
            LoadPemeriksaanFisik()

            ' Set Pemeriksaan Generalis
            LoadPemeriksaanGeneralis()

            ' Set Pemeriksaan Diagnostik

            ' Odontogram
            LoadOdontogram()

            '# ASESMEN
            LoadPrognosa()

            '# PERENCANAAN
            ' Rujukan
            LoadRujukan(Trow("StatusPulang"))

            ' Surat Keterangan
            LoadSuratKeteranganDokter()
            LoadSuratKeteranganIstirahat()
            LoadSuratKeteranganBerobat()
            LoadSuratKeteranganCutiHamil()
            LoadSuratKeteranganKematian()
            LoadSuratKeteranganLayakTerbang()
            LoadSuratKeteranganKhitan()
            LoadSuratKeterangankontrol()
            LoadDataSuratPersetujuan()

            ' Catatan Obat
            LoadCatatanObat()

            ' Load Pemeriksaan Penunjang
            TextBoxNoTransaksiLab.Text = Trow("NoTransaksiLab").ToString
        End If
    End Sub

    Private Sub LoadSuratKeteranganDokter()
        ' SURAT KETERANGAN DOKTER
        Dim tblSuratKeterangan As DataTable = ReadSQL("SELECT * FROM SuratKeteranganDokter WHERE NoTransaksi = '" & idTransaksi & "'")

        If tblSuratKeterangan.Rows.Count > 0 Then
            Dim rowSurat As DataRow = tblSuratKeterangan.Rows(0)

            ' ======= SET DATA BIASA =======
            TextBoxNoSuratDokter.Text = rowSurat("NoSurat")

            If rowSurat("Hasil") = RadioButtonStatusSehatSuratDokter.Text Then
                RadioButtonStatusSehatSuratDokter.Checked = True
            ElseIf rowSurat("Hasil") = RadioButtonStatusTidakSehatSuratDokter.Text Then
                RadioButtonStatusTidakSehatSuratDokter.Checked = True
            End If

            TextBoxTujuanSuratDokter.Text = rowSurat("Tujuan")

            Select Case rowSurat("ButaWarna")
                Case "Negatif", "Total"
                    ComboBoxButaWarnaSuratSehat.Text = rowSurat("ButaWarna")
                Case "Partial"
                    ComboBoxButaWarnaSuratSehat.Text = rowSurat("ButaWarna")
                    TextBoxKeteranganButaWarnaSuratSehat.Text = rowSurat("KeteranganButaWarna")
            End Select

            ' ======= PARSE JSON KETERANGAN =======
            If Not IsDBNull(rowSurat("Keterangan")) Then
                Dim json As String = rowSurat("Keterangan").ToString().Trim()

                If json <> "" Then
                    ' Buang tanda [ dan ] di awal/akhir
                    If json.StartsWith("[") Then json = json.Substring(1)
                    If json.EndsWith("]") Then json = json.Substring(0, json.Length - 1)

                    ' Pisahkan berdasarkan koma antar elemen array
                    Dim rawItems() As String = Split(json, ",")

                    ' Bersihkan tanda kutip dan spasi di tiap item
                    Dim items As New List(Of String)
                    For Each r As String In rawItems
                        Dim clean As String = r.Trim()
                        If clean.StartsWith("""") Then clean = clean.Substring(1)
                        If clean.EndsWith("""") Then clean = clean.Substring(0, clean.Length - 1)
                        items.Add(clean)
                    Next

                    ' Gabungkan ke TextBox, tiap item baris baru
                    TextBoxKeteranganCostom.Text = String.Join(Environment.NewLine, items.ToArray())
                End If
            End If
        End If
    End Sub

    Private Sub LoadSuratKeteranganIstirahat()
        ' SURAT KETERANGAN ISTIRAHAT
        Dim tblSuratKeterangan As DataTable = ReadSQL("SELECT * FROM SuratKeteranganIstirahat WHERE NoTransaksi = '" & idTransaksi & "'")

        If tblSuratKeterangan.Rows.Count > 0 Then
            Dim rowSurat As DataRow = tblSuratKeterangan.Rows(0)

            ' Set No Surat
            TextBoxNoSuratIstirahat.Text = rowSurat("NoSurat")

            ' Set Tanggal Awal & Akhir
            TanggalMulaiSuratKeteranganIstirahat.Value = rowSurat("TanggalAwal")
            TanggalAkhirSuratKeteranganIstirahat.Value = rowSurat("TanggalAkhir")

            ' Set Diagnosa
            TextBoxDiagnosaSuratIstirahat.Text = rowSurat("Diagnosa")
        End If
    End Sub

    Private Sub LoadSuratKeteranganBerobat()
        ' SURAT KETERANGAN BEROBAT
        Dim tblSuratKeterangan As DataTable = ReadSQL("SELECT * FROM SuratKeteranganBerobat WHERE NoTransaksi = '" & idTransaksi & "'")

        If tblSuratKeterangan.Rows.Count > 0 Then
            Dim rowSurat As DataRow = tblSuratKeterangan.Rows(0)

            ' Set Kolom No Surat
            TextBoxNoSuratBerobat.Text = rowSurat("NoSurat").ToString()

            ' Set Diagnosa
            TextBoxDiagnosaSuratBerobat.Text = rowSurat("Diagnosa")
        End If
    End Sub

    Private Sub LoadSuratKeteranganCutiHamil()
        ' SURAT KETERANGAN CUTI HAMIL
        Dim tblSuratKeterangan As DataTable = ReadSQL("SELECT * FROM SuratKeteranganCutiHamil WHERE NoTransaksi = '" & idTransaksi & "'")

        If tblSuratKeterangan.Rows.Count > 0 Then
            Dim rowSurat As DataRow = tblSuratKeterangan.Rows(0)

            ' Set No Surat
            TextBoxNoSuratKeteranganCutiHamil.Text = rowSurat("NoSurat")

            ' Set Kolom Tanggal Awal & Akhir
            TanggalMulaiSuratKeteranganCutiHamil.Value = rowSurat("TanggalAwal")
            TanggalAkhirSuratKeteranganCutiHamil.Value = rowSurat("TanggalAkhir")

            ' Set Kolom Diagnosis GPA
            TextBoxDiagnosisGravidaSuratKeteranganCutiHamil.Text = rowSurat("DiagnosisGravida").ToString()
            TextBoxDiagnosisParaSuratKeteranganCutiHamil.Text = rowSurat("DiagnosisPara").ToString()
            TextBoxDiagnosisAbortusSuratKeteranganCutiHamil.Text = rowSurat("DiagnosisAbortus").ToString()

            ' Set Kolom Usia Kehamilan
            TextBoxUsiaKehamilanSuratKeteranganCutiHamil.Text = rowSurat("UsiaKehamilan").ToString()

            ' Set Kolom Taksiran Persalinan
            TanggalTaksiranPersalinanSuratKeteranganCutiHamil.Value = rowSurat("TaksiranPersalinan")
        End If
    End Sub

    Private Sub LoadSuratKeteranganKematian()
        ' SURAT KETERANGAN KEMATIAN
        Dim tblSuratKeterangan As DataTable = ReadSQL("SELECT * FROM SuratKeteranganKematian WHERE NoTransaksi = '" & idTransaksi & "'")

        If tblSuratKeterangan.Rows.Count > 0 Then
            Dim rowSurat As DataRow = tblSuratKeterangan.Rows(0)

            ' Set No Surat
            TextBoxNoSuratKematian.Text = rowSurat("NoSurat")

            ' Set Diagnosa
            TextBoxDiagnosaSuratKematian.Text = rowSurat("Diagnosa")

            ' Set Penyebab Kematian
            TextBoxSebabKematian.Text = rowSurat("PenyebabKematian")
        End If
    End Sub

    Private Sub LoadSuratKeteranganLayakTerbang()
        ' SURAT KETERANGAN LAYAK TERBANG
        Dim tblSuratKeterangan As DataTable = ReadSQL("SELECT * FROM SuratKeteranganLayakTerbang WHERE NoTransaksi = '" & idTransaksi & "'")

        If tblSuratKeterangan.Rows.Count > 0 Then
            Dim rowSurat As DataRow = tblSuratKeterangan.Rows(0)

            ' Set No Surat
            TextBoxNoSuratLayakTerbang.Text = rowSurat("NoSurat")

            ' Set Diagnosa
            TextBoxDiagnosaSuratLayakTerbang.Text = rowSurat("Diagnosa")
        End If
    End Sub

    Private Sub LoadSuratKeteranganKhitan()
        ' SURAT KETERANGAN KHITAN
        Dim tblSuratKeterangan As DataTable = ReadSQL("SELECT * FROM SuratKeteranganKhitan WHERE NoTransaksi = '" & idTransaksi & "'")

        If tblSuratKeterangan.Rows.Count > 0 Then
            Dim rowSurat As DataRow = tblSuratKeterangan.Rows(0)

            ' Set No Surat
            TextBoxNoSuratKhitan.Text = rowSurat("NoSurat")

            ' Set Tanggal
            DateTimePickerTanggalKhitan.Value = Convert.ToDateTime(rowSurat("TanggalKhitan"))

            ' Konversi TimeSpan ke DateTime untuk Waktu
            Dim waktu As TimeSpan = rowSurat("WaktuKhitan")
            DateTimePickerWaktuKhitan.Value = DateTime.Today.Add(waktu)
        End If
    End Sub

    Private Sub LoadCatatanObat()
        Dim tblCatatanObat As DataTable = ReadSQL("SELECT * FROM TransaksiDetailCatatanObat WHERE NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL")

        If tblCatatanObat.Rows.Count > 0 Then
            Dim rowCatatanObat As DataRow = tblCatatanObat.Rows(0)

            ' Set Catatan Obat
            TextBoxKeteranganCatatanObat.Text = rowCatatanObat("Catatan")
        End If
    End Sub

    Private Sub LoadSuratKeterangankontrol()
        ' SURAT KETERANGAN KONTROL
        Dim tblSuratKeterangan As DataTable = ReadSQL("SELECT * FROM SuratKeteranganKontrol WHERE NoTransaksi = '" & idTransaksi & "'")

        If tblSuratKeterangan.Rows.Count > 0 Then
            Dim rowSurat As DataRow = tblSuratKeterangan.Rows(0)

            ' Set No Surat
            TextBoxNoSuratKeteranganKontrol.Text = rowSurat("NoSurat")

            ' Set Tanggal Awal & Akhir
            DateTimePickerTanggalKontrol.Value = rowSurat("Tanggal")

            ' Set Diagnosa
            TextBoxDiagnosaSuratKontrol.Text = rowSurat("Diagnosa")
        End If
    End Sub

    Private Sub LoadRujukan(ByRef statusPulang As String)
        ComboBoxStatusPulang.Text = statusPulang
        If statusPulang.ToString.Contains("Rujuk") = True Then
            Dim tblsRujukan As DataTable = ReadSQL("SELECT * FROM TransaksiDetailRujukan WHERE NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL")

            If tblsRujukan.Rows.Count > 0 Then
                For Each trowRujukan As DataRow In tblsRujukan.Rows
                    TextBoxJenisRujukan.Text = trowRujukan("JenisRujukan")
                    TextBoxKodeFaskesRujukan.Text = trowRujukan("KodePPK")
                    TextBoxNamaFaskesRujukan.Text = trowRujukan("KeteranganPPK")
                    DateTimePickerTglRencanaBerkunjung.Value = trowRujukan("TanggalRujukan")
                    TextBoxKodeTACC.Text = trowRujukan("KodeTACC")
                    TextBoxKeteranganTACC.Text = trowRujukan("KeteranganTACC")
                    TextBoxAlasanTACC.Text = trowRujukan("AlasanTACC")
                    TextBoxJadwalPraktekRujukan.Text = trowRujukan("JadwalPraktek")

                    If trowRujukan("JenisRujukan") = "Kondisi Khusus" Then
                        ' Rujukan Kondisi Khusus
                        TextBoxKodeKhusus.Text = trowRujukan("KodeKhusus")
                        TextBoxNamaKhusus.Text = trowRujukan("KeteranganKhusus")

                        TextBoxKodeSpesialis.Text = trowRujukan("KodeSubSpesialis")
                        TextBoxNamaSpesialis.Text = trowRujukan("KeteranganSubSpesialis")

                        TextBoxCatatanRujukan.Text = trowRujukan("Catatan")
                    ElseIf trowRujukan("JenisRujukan") = "Spesialis" Then
                        ' Rujukan Spesialis
                        TextBoxKodeSpesialis.Text = trowRujukan("KodeSubSpesialis")
                        TextBoxNamaSpesialis.Text = trowRujukan("KeteranganSubSpesialis")

                        TextBoxKodeSarana.Text = trowRujukan("KodeSarana")
                        TextBoxNamaSarana.Text = trowRujukan("KeteranganSarana")
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub LoadPrognosa()
        Dim tblsPrognosa As DataTable = ReadSQL("SELECT * FROM TransaksiDetailPrognosa WHERE NoTransaksi = '" & idTransaksi & "'")

        If tblsPrognosa.Rows.Count > 0 Then
            Dim rowPrognosa As DataRow = tblsPrognosa.Rows(0)

            ComboBoxPrognosa.Text = rowPrognosa("KeteranganPrognosa")
        End If
    End Sub

    Private Sub LoadPemeriksaanGeneralis()
        Dim tblsGeneralis As DataTable = ReadSQL("SELECT * FROM TransaksiDetailGeneralis WHERE NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL")

        If tblsGeneralis.Rows.Count > 0 Then
            Dim Trow As DataRow = tblsGeneralis.Rows(0)

            If IsDBNull(Trow("StatusGeneralisKepala")) = False Then TextBoxStatusGeneralisKepala.Text = Trow("StatusGeneralisKepala").ToString.Trim
            If IsDBNull(Trow("StatusGeneralisMata")) = False Then TextBoxStatusGeneralisMata.Text = Trow("StatusGeneralisMata").ToString.Trim
            If IsDBNull(Trow("StatusGeneralisHidung")) = False Then TextBoxStatusGeneralisHidung.Text = Trow("StatusGeneralisHidung").ToString.Trim
            If IsDBNull(Trow("StatusGeneralisMulutFaring")) = False Then TextBoxStatusGeneralisMulutFaring.Text = Trow("StatusGeneralisMulutFaring").ToString.Trim
            If IsDBNull(Trow("StatusGeneralisTelinga")) = False Then TextBoxStatusGeneralisTelinga.Text = Trow("StatusGeneralisTelinga").ToString.Trim
            If IsDBNull(Trow("StatusGeneralisLeher")) = False Then TextBoxStatusGeneralisLeher.Text = Trow("StatusGeneralisLeher").ToString.Trim
            If IsDBNull(Trow("StatusGeneralisThorax")) = False Then TextBoxStatusGeneralisThorax.Text = Trow("StatusGeneralisThorax").ToString.Trim
            If IsDBNull(Trow("StatusGeneralisAbdomen")) = False Then TextBoxStatusGeneralisAbdomen.Text = Trow("StatusGeneralisAbdomen").ToString.Trim
            If IsDBNull(Trow("StatusGeneralisEkstremitas")) = False Then TextBoxStatusGeneralisEkstremitas.Text = Trow("StatusGeneralisEkstremitas").ToString.Trim
            If IsDBNull(Trow("StatusGeneralisStatusLokalis")) = False Then TextBoxStatusGeneralisStatusLokalis.Text = Trow("StatusGeneralisStatusLokalis").ToString.Trim
        End If
    End Sub

    Private Sub LoadPemeriksaanFisik()
        Dim tblsFisik As DataTable = ReadSQL("SELECT * FROM TransaksiDetailFisik WHERE NoTransaksi = '" & idTransaksi & "'")

        If tblsFisik.Rows.Count > 0 Then
            Dim Trow As DataRow = tblsFisik.Rows(0)

            ' Keadaan Umum
            If IsDBNull(Trow("KeadaanUmum")) = False Then
                If RadioButtonKeadaanTampakSehatMedik.Text = Trow("KeadaanUmum") Then
                    RadioButtonKeadaanTampakSehatMedik.Checked = True
                ElseIf RadioButtonKeadaanSakitRinganMedik.Text = Trow("KeadaanUmum") Then
                    RadioButtonKeadaanSakitRinganMedik.Checked = True
                ElseIf RadioButtonKeadaanSakitSedangMedik.Text = Trow("KeadaanUmum") Then
                    RadioButtonKeadaanSakitSedangMedik.Checked = True
                ElseIf RadioButtonKeadaanSakitBeratMedik.Text = Trow("KeadaanUmum") Then
                    RadioButtonKeadaanSakitBeratMedik.Checked = True
                End If
            End If

            ' Kesadaran
            If IsDBNull(Trow("Kesadaran")) = False Then
                If RadioButtonComposMentisMedik.Text = Trow("Kesadaran") Then
                    RadioButtonComposMentisMedik.Checked = True
                ElseIf RadioButtonApatisMedik.Text = Trow("Kesadaran") Then
                    RadioButtonApatisMedik.Checked = True
                ElseIf RadioButtonSomnolenceMedik.Text = Trow("Kesadaran") Then
                    RadioButtonSomnolenceMedik.Checked = True
                ElseIf RadioButtonSoporMedik.Text = Trow("Kesadaran") Then
                    RadioButtonSoporMedik.Checked = True
                ElseIf RadioButtonComaMedik.Text = Trow("Kesadaran") Then
                    RadioButtonComaMedik.Checked = True
                End If
            End If

            ' Skala Nyeri
            Dim tblMasterSkalaNyeri As DataTable = ReadSQL("SELECT * FROM MasterSkalaNyeri WHERE Skor = '" & Trow("SkalaNyeri") & "'")
            Dim rowSkalaNyeri As DataRow = tblMasterSkalaNyeri.Rows(0)
            Dim nilaiWarna As String = rowSkalaNyeri("Warna").ToString

            TextBoxSkalaNyeriMedik.BackColor = ColorTranslator.FromHtml(nilaiWarna)
            TextBoxSkalaNyeriMedik.Text = rowSkalaNyeri("Keterangan").ToString
            TrackBarSkalaNyeriMedik.Value = Trow("SkalaNyeri").ToString()

            ' Vital Statistik & Antropometri
            If IsDBNull(Trow("Sistole")) = False Then TextBoxSistoleMedik.Text = Trow("Sistole").ToString.Trim
            If IsDBNull(Trow("Diastole")) = False Then TextBoxDiastoleMedik.Text = Trow("Diastole").ToString.Trim
            If IsDBNull(Trow("HeartRate")) = False Then TextBoxDetakNadiMedik.Text = Trow("HeartRate").ToString.Trim
            If IsDBNull(Trow("RespiratoryRate")) = False Then TextBoxNafasMedik.Text = Trow("RespiratoryRate").ToString.Trim
            If IsDBNull(Trow("Suhu")) = False Then TextBoxSuhuMedik.Text = Trow("Suhu").ToString.Trim
            If IsDBNull(Trow("Saturasi")) = False Then TextBoxSaturasiMedik.Text = Trow("Saturasi").ToString.Trim
            If IsDBNull(Trow("Tinggi")) = False Then TextBoxTinggiBadanMedik.Text = Trow("Tinggi").ToString.Trim
            If IsDBNull(Trow("Berat")) = False Then TextBoxBeratBadanMedik.Text = Trow("Berat").ToString.Trim
            If IsDBNull(Trow("LingkarPerut")) = False Then TextBoxLingkarPerutMedik.Text = Trow("LingkarPerut").ToString.Trim
            If IsDBNull(Trow("IMT")) = False Then TextBoxIndeksMedik.Text = Trow("IMT").ToString.Trim
            If IsDBNull(Trow("KeteranganIMT")) = False Then TextBoxIndeksKeteranganMedik.Text = Trow("KeteranganIMT").ToString.Trim
        End If
    End Sub

    Private Sub SetPemeriksaanAwal()
        Dim queryString As String = "SELECT TOP(1) * FROM TransaksiDetail " & _
                                    "WHERE IDInternet = '" & idPasien & "' AND PemeriksaanAwalDate IS NOT NULL AND DeletedDate IS NULL " & _
                                    "ORDER BY PemeriksaanAwalDate DESC"

        Dim tblsPemeriksaanAwal As DataTable = ReadSQL(queryString)

        If tblsPemeriksaanAwal.Rows.Count > 0 Then
            ' Enable Menu Strip
            MedisToolStripMenuItem.Visible = True
            PenandaanGambarToolStripMenuItem.Visible = True

            Dim rowPemeriksaanAwal As DataRow = tblsPemeriksaanAwal.Rows(0)

            If rowPemeriksaanAwal("NoUrut") = idTransaksi Then
                ButtonSavePemeriksaanAwal.Enabled = True
                ButtonSavePemeriksaanAwal.BackColor = Color.White
                LabelPemeriksaanAwalDate.Visible = False

                GroupBoxAnamnesa.Enabled = True
                GroupBoxAlergiPemeriksaanAwal.Enabled = True
                GroupBoxPemeriksaanFisik.Enabled = True
                GroupBoxRiwayatPenyakit.Enabled = True
                GroupBoxMST.Enabled = True
                GroupBoxPsikoSosial.Enabled = True
                GroupBoxStatusFungsional.Enabled = True
            Else
                ButtonSavePemeriksaanAwal.Enabled = False
                ButtonSavePemeriksaanAwal.BackColor = Color.FromArgb(225, 225, 225)

                Dim tglPemeriksaanAwal As String = Format(rowPemeriksaanAwal("PemeriksaanAwalDate"), "yyyy-MM-dd HH:mm:ss")
                LabelPemeriksaanAwalDate.Text = "Pemeriksaan Awal Date : " & tglPemeriksaanAwal
                LabelPemeriksaanAwalDate.Visible = True

                GroupBoxAnamnesa.Enabled = False
                GroupBoxAlergiPemeriksaanAwal.Enabled = False
                GroupBoxPemeriksaanFisik.Enabled = False
                GroupBoxRiwayatPenyakit.Enabled = False
                GroupBoxMST.Enabled = False
                GroupBoxPsikoSosial.Enabled = False
                GroupBoxStatusFungsional.Enabled = False
            End If

            ' Load Keluhan Utama & Tambahan
            If IsDBNull(rowPemeriksaanAwal("KeluhanUtama")) = False Then TextBoxKeluhanUtamaPemeriksaanAwal.Text = rowPemeriksaanAwal("KeluhanUtama").ToString.Trim
            If IsDBNull(rowPemeriksaanAwal("KeluhanTambahan")) = False Then TextBoxKeluhanTambahanPemeriksaanAwal.Text = rowPemeriksaanAwal("KeluhanTambahan").ToString.Trim

            ' Load Pemeriksaan Fisik
            Dim tblsFisik As DataTable = ReadSQL("SELECT * FROM TransaksiDetailFisik WHERE NoTransaksi = '" & rowPemeriksaanAwal("NoUrut") & "'")
            If tblsFisik.Rows.Count > 0 Then
                Dim rowFisik As DataRow = tblsFisik.Rows(0)

                ' Load Keadaan Umum
                If IsDBNull(rowFisik("KeadaanUmum")) = False Then
                    If RadioButtonKeadaanTampakSehatPemeriksaanAwal.Text = rowFisik("KeadaanUmum") Then
                        RadioButtonKeadaanTampakSehatPemeriksaanAwal.Checked = True
                    ElseIf RadioButtonKeadaanSakitRinganPemeriksaanAwal.Text = rowFisik("KeadaanUmum") Then
                        RadioButtonKeadaanSakitRinganPemeriksaanAwal.Checked = True
                    ElseIf RadioButtonKeadaanSakitSedangPemeriksaanAwal.Text = rowFisik("KeadaanUmum") Then
                        RadioButtonKeadaanSakitSedangPemeriksaanAwal.Checked = True
                    ElseIf RadioButtonKeadaanSakitBeratPemeriksaanAwal.Text = rowFisik("KeadaanUmum") Then
                        RadioButtonKeadaanSakitBeratPemeriksaanAwal.Checked = True
                    End If
                End If

                ' Load Kesadaran
                If IsDBNull(rowFisik("Kesadaran")) = False Then
                    If RadioButtonComposMentisPemeriksaanAwal.Text = rowFisik("Kesadaran") Then
                        RadioButtonComposMentisPemeriksaanAwal.Checked = True
                    ElseIf RadioButtonApatisPemeriksaanAwal.Text = rowFisik("Kesadaran") Then
                        RadioButtonApatisPemeriksaanAwal.Checked = True
                    ElseIf RadioButtonSomnolencePemeriksaanAwal.Text = rowFisik("Kesadaran") Then
                        RadioButtonSomnolencePemeriksaanAwal.Checked = True
                    ElseIf RadioButtonSoporPemeriksaanAwal.Text = rowFisik("Kesadaran") Then
                        RadioButtonSoporPemeriksaanAwal.Checked = True
                    ElseIf RadioButtonComaPemeriksaanAwal.Text = rowFisik("Kesadaran") Then
                        RadioButtonComaPemeriksaanAwal.Checked = True
                    End If
                End If

                ' Skala Nyeri
                Dim tblMasterSkalaNyeri As DataTable = ReadSQL("SELECT * FROM MasterSkalaNyeri WHERE Skor = '" & rowFisik("SkalaNyeri") & "'")
                Dim rowSkalaNyeri As DataRow = tblMasterSkalaNyeri.Rows(0)
                Dim nilaiWarna As String = rowSkalaNyeri("Warna").ToString

                TextBoxSkalaNyeriPemeriksaanAwal.BackColor = ColorTranslator.FromHtml(nilaiWarna)
                TextBoxSkalaNyeriPemeriksaanAwal.Text = rowSkalaNyeri("Keterangan").ToString
                TrackBarSkalaNyeriPemeriksaanAwal.Value = rowFisik("SkalaNyeri").ToString()

                ' Load Vital Statistik & Antropometri
                If IsDBNull(rowFisik("Sistole")) = False Then TextBoxSistolePemeriksaanAwal.Text = rowFisik("Sistole").ToString.Trim
                If IsDBNull(rowFisik("Diastole")) = False Then TextBoxDiastolePemeriksaanAwal.Text = rowFisik("Diastole").ToString.Trim
                If IsDBNull(rowFisik("HeartRate")) = False Then TextBoxDetakNadiPemeriksaanAwal.Text = rowFisik("HeartRate").ToString.Trim
                If IsDBNull(rowFisik("RespiratoryRate")) = False Then TextBoxNafasPemeriksaanAwal.Text = rowFisik("RespiratoryRate").ToString.Trim
                If IsDBNull(rowFisik("Suhu")) = False Then TextBoxSuhuPemeriksaanAwal.Text = rowFisik("Suhu").ToString.Trim
                If IsDBNull(rowFisik("Saturasi")) = False Then TextBoxSaturasiPemeriksaanAwal.Text = rowFisik("Saturasi").ToString.Trim
                If IsDBNull(rowFisik("Tinggi")) = False Then TextBoxTinggiBadanPemeriksaanAwal.Text = rowFisik("Tinggi").ToString.Trim
                If IsDBNull(rowFisik("Berat")) = False Then TextBoxBeratBadanPemeriksaanAwal.Text = rowFisik("Berat").ToString.Trim
                If IsDBNull(rowFisik("LingkarPerut")) = False Then TextBoxLingkarPerutPemeriksaanAwal.Text = rowFisik("LingkarPerut").ToString.Trim
                If IsDBNull(rowFisik("IMT")) = False Then TextBoxIndeksPemeriksaanAwal.Text = rowFisik("IMT").ToString.Trim
                If IsDBNull(rowFisik("KeteranganIMT")) = False Then TextBoxIndeksKeteranganPemeriksaanAwal.Text = rowFisik("KeteranganIMT").ToString.Trim
            End If

            ' Set Data Kuisioner
            ' PenurunanBeratBadan
            If IsDBNull(rowPemeriksaanAwal("PenurunanBeratBadan")) = False Then
                If RadioButtonPertanyaan1Pilihan1MST.Text = rowPemeriksaanAwal("PenurunanBeratBadan") Then
                    RadioButtonPertanyaan1Pilihan1MST.Checked = True
                ElseIf RadioButtonPertanyaan1Pilihan2MST.Text = rowPemeriksaanAwal("PenurunanBeratBadan") Then
                    RadioButtonPertanyaan1Pilihan2MST.Checked = True
                Else
                    RadioButtonPertanyaan1Pilihan3MST.Checked = True

                    If RadioButtonPertanyaan1Opsi1MST.Text = rowPemeriksaanAwal("PenurunanBeratBadan") Then
                        RadioButtonPertanyaan1Opsi1MST.Checked = True
                    ElseIf RadioButtonPertanyaan1Opsi2MST.Text = rowPemeriksaanAwal("PenurunanBeratBadan") Then
                        RadioButtonPertanyaan1Opsi2MST.Checked = True
                    ElseIf RadioButtonPertanyaan1Opsi3MST.Text = rowPemeriksaanAwal("PenurunanBeratBadan") Then
                        RadioButtonPertanyaan1Opsi3MST.Checked = True
                    ElseIf RadioButtonPertanyaan1Opsi4MST.Text = rowPemeriksaanAwal("PenurunanBeratBadan") Then
                        RadioButtonPertanyaan1Opsi4MST.Checked = True
                    End If
                End If
            End If

            ' AsupanMakan
            If IsDBNull(rowPemeriksaanAwal("AsupanMakan")) = False Then
                If RadioButtonPertanyaan2Pilihan1MST.Text = rowPemeriksaanAwal("AsupanMakan") Then
                    RadioButtonPertanyaan2Pilihan1MST.Checked = True
                ElseIf RadioButtonPertanyaan2Pilihan2MST.Text = rowPemeriksaanAwal("AsupanMakan") Then
                    RadioButtonPertanyaan2Pilihan2MST.Checked = True
                End If
            End If

            ' DiagnosisKhusus
            If IsDBNull(rowPemeriksaanAwal("DiagnosisKhusus")) = False Then
                Dim diagnosaLainnya As String = ""
                Dim splitDiagnosa() As String = rowPemeriksaanAwal("DiagnosisKhusus").ToString.Split(",")

                For i As Integer = 0 To splitDiagnosa.Length - 1
                    If splitDiagnosa(i).ToString.Trim = CheckBoxDiabetesMST.Text Then
                        CheckBoxDiabetesMST.Checked = True
                    ElseIf splitDiagnosa(i).ToString.Trim = CheckBoxKemoterapiMST.Text Then
                        CheckBoxKemoterapiMST.Checked = True
                    ElseIf splitDiagnosa(i).ToString.Trim = CheckBoxHemodialisaMST.Text Then
                        CheckBoxHemodialisaMST.Checked = True
                    ElseIf splitDiagnosa(i).ToString.Trim = CheckBoxGeriatriMST.Text Then
                        CheckBoxGeriatriMST.Checked = True
                    ElseIf splitDiagnosa(i).ToString.Trim = CheckBoxImunitasMST.Text Then
                        CheckBoxImunitasMST.Checked = True
                    ElseIf splitDiagnosa(i).ToString.Trim = CheckBoxTiroidMST.Text Then
                        CheckBoxTiroidMST.Checked = True
                    ElseIf splitDiagnosa(i).ToString.Trim.Length > 0 Then
                        CheckBoxLainnyaMST.Checked = True
                        diagnosaLainnya = diagnosaLainnya & splitDiagnosa(i).ToString.Trim & ", "
                    End If
                Next

                If diagnosaLainnya.Length > 0 Then
                    diagnosaLainnya = Strings.Left(diagnosaLainnya, diagnosaLainnya.Length - 2)
                    TextBoxLainnyaKeterangan.Text = diagnosaLainnya
                End If

                If rowPemeriksaanAwal("DiagnosisKhusus").ToString.Length > 0 Then
                    RadioButtonYaPertanyaan3MST.Checked = True
                Else
                    RadioButtonTidakPertanyaan3MST.Checked = True
                End If
            End If

            ' TotalSkorMST
            If IsDBNull(rowPemeriksaanAwal("TotalSkorMST")) = False Then
                If rowPemeriksaanAwal("TotalSkorMST").ToString.Length > 0 Then
                    TextBoxTotalSkorMST.Text = rowPemeriksaanAwal("TotalSkorMST").ToString
                End If
            End If

            ' StatusMental
            If IsDBNull(rowPemeriksaanAwal("StatusMental")) = False Then
                If RadioButtonOrientasiBaikPsiko.Text = rowPemeriksaanAwal("StatusMental") Then
                    RadioButtonOrientasiBaikPsiko.Checked = True
                ElseIf RadioButtonDisorientasiPsiko.Text = rowPemeriksaanAwal("StatusMental") Then
                    RadioButtonDisorientasiPsiko.Checked = True
                ElseIf RadioButtonGelisahPsiko.Text = rowPemeriksaanAwal("StatusMental") Then
                    RadioButtonGelisahPsiko.Checked = True
                ElseIf RadioButtonTidakResponPsiko.Text = rowPemeriksaanAwal("StatusMental") Then
                    RadioButtonTidakResponPsiko.Checked = True
                End If
            End If

            ' StatusPsikologis
            If IsDBNull(rowPemeriksaanAwal("StatusPsikologis")) = False Then
                Dim splitStatusPsikologis() As String = rowPemeriksaanAwal("StatusPsikologis").ToString.Split("#")

                If RadioButtonTenangPsiko.Text = splitStatusPsikologis(0).ToString.Trim Then
                    RadioButtonTenangPsiko.Checked = True
                ElseIf RadioButtonCemasPsiko.Text = splitStatusPsikologis(0).ToString.Trim Then
                    RadioButtonCemasPsiko.Checked = True
                ElseIf RadioButtonTakutPsiko.Text = splitStatusPsikologis(0).ToString.Trim Then
                    RadioButtonTakutPsiko.Checked = True
                ElseIf RadioButtonMarahPsiko.Text = splitStatusPsikologis(0).ToString.Trim Then
                    RadioButtonMarahPsiko.Checked = True
                ElseIf RadioButtonSedihPsiko.Text = splitStatusPsikologis(0).ToString.Trim Then
                    RadioButtonSedihPsiko.Checked = True
                ElseIf RadioButtonBunuhDiriPsiko.Text = splitStatusPsikologis(0).ToString.Trim Then
                    RadioButtonBunuhDiriPsiko.Checked = True
                    TextBoxLaporKeteranganPsiko.Text = splitStatusPsikologis(1).ToString.Trim
                    TextBoxLaporWaktuPsiko.Text = splitStatusPsikologis(2).ToString.Trim
                End If
            End If

            ' HubunganPasien
            If IsDBNull(rowPemeriksaanAwal("HubunganPasien")) = False Then
                If RadioButtonBaikPsiko.Text = rowPemeriksaanAwal("HubunganPasien") Then
                    RadioButtonBaikPsiko.Checked = True
                ElseIf RadioButtonTidakBaikPsiko.Text = rowPemeriksaanAwal("HubunganPasien") Then
                    RadioButtonTidakBaikPsiko.Checked = True
                End If
            End If

            ' NilaiKepercayaan
            If IsDBNull(rowPemeriksaanAwal("NilaiKepercayaan")) = False Then
                If RadioButtonAdaPsiko.Text = rowPemeriksaanAwal("NilaiKepercayaan") Then
                    RadioButtonAdaPsiko.Checked = True
                ElseIf RadioButtonTidakAdaPsiko.Text = rowPemeriksaanAwal("NilaiKepercayaan") Then
                    RadioButtonTidakAdaPsiko.Checked = True
                End If
            End If

            ' Bahasa
            If IsDBNull(rowPemeriksaanAwal("Bahasa")) = False Then
                Dim splitBahasa() As String = rowPemeriksaanAwal("Bahasa").ToString.Split("#")

                If RadioButtonBahasaIndonesiaPsiko.Text = splitBahasa(0).ToString.Trim Then
                    RadioButtonBahasaIndonesiaPsiko.Checked = True
                ElseIf RadioButtonBahasaInggrisPsiko.Text = splitBahasa(0).ToString.Trim Then
                    RadioButtonBahasaInggrisPsiko.Checked = True
                ElseIf RadioButtonBahasaDaerahPsiko.Text = splitBahasa(0).ToString.Trim Then
                    RadioButtonBahasaDaerahPsiko.Checked = True
                    TextBoxBahasaDaerahKeteranganPsiko.Text = splitBahasa(1).ToString.Trim
                ElseIf RadioButtonBahasaLainnyaPsiko.Text = splitBahasa(0).ToString.Trim Then
                    RadioButtonBahasaLainnyaPsiko.Checked = True
                    TextBoxBahasaLainnyaPsiko.Text = splitBahasa(1).ToString.Trim
                End If
            End If

            ' StatusFungsional
            If IsDBNull(rowPemeriksaanAwal("StatusFungsional")) = False Then
                Dim splitStatusFungsional() As String = rowPemeriksaanAwal("StatusFungsional").ToString.Split("#")

                If RadioButtonStatusMandiriFungsional.Text = splitStatusFungsional(0).ToString.Trim Then
                    RadioButtonStatusMandiriFungsional.Checked = True
                ElseIf RadioButtonStatusPerluBantuanFungsional.Text = splitStatusFungsional(0).ToString.Trim Then
                    RadioButtonStatusPerluBantuanFungsional.Checked = True
                    TextBoxStatusPerluBantuanKeteranganFungsional.Text = splitStatusFungsional(1).ToString.Trim
                End If
            End If

            If tblsRekamMedis.Rows.Count > 0 Then
                Dim Trow As DataRow = tblsRekamMedis.Rows(0)

                ' Riwayat Penyakit
                If IsDBNull(Trow("RiwayatPenyakitDahulu")) = False Then TextBoxRiwayatPenyakitDahuluPemeriksaanAwal.Text = Trow("RiwayatPenyakitDahulu").ToString.Trim
                If IsDBNull(Trow("RiwayatPenyakitKeluarga")) = False Then TextBoxRiwayatPenyakitKeluargaPemeriksaanAwal.Text = Trow("RiwayatPenyakitKeluarga").ToString.Trim
                If IsDBNull(Trow("RiwayatKebiasaan")) = False Then TextBoxRiwayatKebiasaanPemeriksaanAwal.Text = Trow("RiwayatKebiasaan").ToString.Trim
            End If
        Else
            ' Jika belum ada riwayat pemeriksaan awal
            If tblsRekamMedis.Rows.Count > 0 Then
                Dim Trow As DataRow = tblsRekamMedis.Rows(0)

                ' Load Keluhan Utama & Tambahan
                If IsDBNull(Trow("KeluhanUtama")) = False Then TextBoxKeluhanUtamaPemeriksaanAwal.Text = Trow("KeluhanUtama").ToString.Trim
                If IsDBNull(Trow("KeluhanTambahan")) = False Then TextBoxKeluhanTambahanPemeriksaanAwal.Text = Trow("KeluhanTambahan").ToString.Trim

                ' Riwayat Penyakit
                If IsDBNull(Trow("RiwayatPenyakitDahulu")) = False Then TextBoxRiwayatPenyakitDahuluPemeriksaanAwal.Text = Trow("RiwayatPenyakitDahulu").ToString.Trim
                If IsDBNull(Trow("RiwayatPenyakitKeluarga")) = False Then TextBoxRiwayatPenyakitKeluargaPemeriksaanAwal.Text = Trow("RiwayatPenyakitKeluarga").ToString.Trim
                If IsDBNull(Trow("RiwayatKebiasaan")) = False Then TextBoxRiwayatKebiasaanPemeriksaanAwal.Text = Trow("RiwayatKebiasaan").ToString.Trim
            End If

            ' Enable Button
            ButtonSavePemeriksaanAwal.Enabled = True
            ButtonSavePemeriksaanAwal.BackColor = Color.White
            LabelPemeriksaanAwalDate.Visible = False

            ' Disable Menu Strip
            MedisToolStripMenuItem.Visible = False
            PenandaanGambarToolStripMenuItem.Visible = False

            ' Disable Group Box
            GroupBoxAnamnesa.Enabled = True
            GroupBoxAlergiPemeriksaanAwal.Enabled = True
            GroupBoxPemeriksaanFisik.Enabled = True
            GroupBoxRiwayatPenyakit.Enabled = True
            GroupBoxMST.Enabled = True
            GroupBoxPsikoSosial.Enabled = True
            GroupBoxStatusFungsional.Enabled = True
        End If
    End Sub

    Private Sub SetGambarPenanda()
        If tblsRekamMedis.Rows.Count > 0 Then
            Dim Trow As DataRow = tblsRekamMedis.Rows(0)

            ' Set gambar pada PictureBox
            If Trow("JenisKelamin") = "L" Then
                PictureBoxPenandaanGambar.Image = My.Resources.gambar_laki_laki
            ElseIf Trow("JenisKelamin") = "P" Then
                PictureBoxPenandaanGambar.Image = My.Resources.gambar_perempuan
            End If
        End If
    End Sub

    Private Sub ClearStatusGeneralis()
        ' Kepala
        CheckBoxStatusGeneralisKepala.Checked = False
        TextBoxStatusGeneralisKepala.ReadOnly = True
        TextBoxStatusGeneralisKepala.ResetText()

        ' Mata
        CheckBoxStatusGeneralisMata.Checked = False
        TextBoxStatusGeneralisMata.ReadOnly = True
        TextBoxStatusGeneralisMata.ResetText()

        ' Hidung
        CheckBoxStatusGeneralisHidung.Checked = False
        TextBoxStatusGeneralisHidung.ReadOnly = True
        TextBoxStatusGeneralisHidung.ResetText()

        ' Mulut dan Faring
        CheckBoxStatusGeneralisMulutFaring.Checked = False
        TextBoxStatusGeneralisMulutFaring.ReadOnly = True
        TextBoxStatusGeneralisMulutFaring.ResetText()

        ' Telinga
        CheckBoxStatusGeneralisTelinga.Checked = False
        TextBoxStatusGeneralisTelinga.ReadOnly = True
        TextBoxStatusGeneralisTelinga.ResetText()

        ' Leher
        CheckBoxStatusGeneralisLeher.Checked = False
        TextBoxStatusGeneralisLeher.ReadOnly = True
        TextBoxStatusGeneralisLeher.ResetText()

        ' Thorax
        CheckBoxStatusGeneralisThorax.Checked = False
        TextBoxStatusGeneralisThorax.ReadOnly = True
        TextBoxStatusGeneralisThorax.ResetText()

        ' Abdomen
        CheckBoxStatusGeneralisAbdomen.Checked = False
        TextBoxStatusGeneralisAbdomen.ReadOnly = True
        TextBoxStatusGeneralisAbdomen.ResetText()

        ' Ekstremitas
        CheckBoxStatusGeneralisEkstremitas.Checked = False
        TextBoxStatusGeneralisEkstremitas.ReadOnly = True
        TextBoxStatusGeneralisEkstremitas.ResetText()

        ' Status Lokalis
        CheckBoxStatusGeneralisStatusLokalis.Checked = False
        TextBoxStatusGeneralisStatusLokalis.ReadOnly = True
        TextBoxStatusGeneralisStatusLokalis.ResetText()
    End Sub

    Private Sub ClearTabNonRacikan()
        TextBoxNamaObatNonRacikan.ResetText()
        TextBoxKodeObatNonRacikan.ResetText()
        TextBoxSigna1NonRacikan.ResetText()
        TextBoxSigna2NonRacikan.ResetText()
        ComboBoxAturanPakaiObatNonRacikan.SelectedIndex = -1
        TextBoxJumlahObatNonRacikan.ResetText()
        TextBoxCatatanObatNonRacikan.ResetText()
        TextBoxHargaObatNonRacikan.ResetText()
        LabelStokObatNonRacikan.ResetText()
        TextBoxObatDPHO.ResetText()
        TextBoxKodeObatDPHO.ResetText()

        RadioButtonImmTidak.Checked = True
        CheckBoxSignaAktif.Checked = True
        TextBoxSigna1NonRacikan.Enabled = True
        TextBoxSigna2NonRacikan.Enabled = True
        ComboBoxSatuanSignaNonRacikan.Enabled = True
    End Sub

    Private Sub ClearTabRacikan()
        ComboBoxAturanPakaiObatRacikan.SelectedIndex = -1
        TextBoxSigna1Racikan.ResetText()
        TextBoxSigna2Racikan.ResetText()
        TextBoxCatatanObatRacikan.ResetText()
        ListViewRacikanTemp.Items.Clear()

        TextBoxKodeObatRacikan.ResetText()
        TextBoxNamaObatRacikan.ResetText()
        TextBoxJumlahObatRacikan.ResetText()
        TextBoxHargaObatRacikan.ResetText()
        LabelStokObatRacikan.ResetText()
    End Sub

    Private Sub ClearTabTindakan()
        TextBoxTindakanID.ResetText()
        TextBoxNamaTindakan.ResetText()
        TextBoxJenisTindakan.ResetText()
        TextBoxBiayaTindakan.ResetText()
        CheckBoxInformedConsent.Checked = False
        SplitContainerTindakan.Panel2Collapsed = True
    End Sub

    Private Sub ClearTabRujukan()
        TextBoxKodeFaskesRujukan.ResetText()
        TextBoxNamaFaskesRujukan.ResetText()
        TextBoxKodeKhusus.ResetText()
        TextBoxNamaKhusus.ResetText()
        TextBoxKodeSpesialis.ResetText()
        TextBoxNamaSpesialis.ResetText()
        TextBoxCatatanRujukan.ResetText()
        TextBoxKodeSarana.ResetText()
        TextBoxNamaSarana.ResetText()
        TextBoxKodeTACC.ResetText()
        TextBoxKeteranganTACC.ResetText()
        TextBoxAlasanTACC.ResetText()
        TextBoxJenisRujukan.ResetText()
        DateTimePickerTglRencanaBerkunjung.Value = DateTime.Now
        TextBoxJadwalPraktekRujukan.ResetText()

        LabelNonSpesialistik.Visible = False
    End Sub

    Private Sub ClearTabPenunjang()

    End Sub

    Private Sub ClearSuratKeterangan()
        ComboBoxJenisSuratKeterangan.SelectedIndex = 0

        ' Surat Keterangan Dokter
        TextBoxNoSuratDokter.ResetText()
        RadioButtonStatusSehatSuratDokter.Checked = True
        TextBoxTujuanSuratDokter.ResetText()
        ComboBoxButaWarnaSuratSehat.SelectedIndex = -1
        TextBoxKeteranganButaWarnaSuratSehat.Enabled = False
        TextBoxKeteranganButaWarnaSuratSehat.ResetText()

        ' Surat Keterangan Istirahat
        TextBoxNoSuratIstirahat.ResetText()
        TextBoxDiagnosaSuratIstirahat.ResetText()

        ' Surat Keterangan Berobat
        TextBoxNoSuratBerobat.ResetText()
        TextBoxDiagnosaSuratBerobat.ResetText()

        ' Surat Keterangan Cuti Hamil
        TextBoxNoSuratKeteranganCutiHamil.ResetText()
        TextBoxDiagnosisGravidaSuratKeteranganCutiHamil.ResetText()
        TextBoxDiagnosisParaSuratKeteranganCutiHamil.ResetText()
        TextBoxDiagnosisAbortusSuratKeteranganCutiHamil.ResetText()
        TextBoxUsiaKehamilanSuratKeteranganCutiHamil.ResetText()

        ' Surat Keterangan Kematian
        TextBoxNoSuratKematian.ResetText()
        TextBoxDiagnosaSuratKematian.ResetText()
        TextBoxSebabKematian.ResetText()

        ' Surat Keterangan Khitan
        TextBoxNoSuratKhitan.ResetText()

        ' Surat Keterangan Layak Terbang
        TextBoxNoSuratLayakTerbang.ResetText()
        RadioButtonStatusSehatLayakTerbang.Checked = True
        TextBoxDiagnosaSuratLayakTerbang.ResetText()
    End Sub

    Private Sub ClearPemeriksaanAwal()
        ' Vital Statistik & Antropometri
        TextBoxKeluhanUtamaPemeriksaanAwal.ResetText()
        TextBoxKeluhanTambahanPemeriksaanAwal.ResetText()
        RadioButtonKeadaanTampakSehatPemeriksaanAwal.Checked = True
        RadioButtonComposMentisPemeriksaanAwal.Checked = True
        TextBoxSkalaNyeriPemeriksaanAwal.ResetText()
        TrackBarSkalaNyeriPemeriksaanAwal.Value = 0

        TextBoxSistolePemeriksaanAwal.ResetText()
        TextBoxDiastolePemeriksaanAwal.ResetText()
        TextBoxDetakNadiPemeriksaanAwal.ResetText()
        TextBoxNafasPemeriksaanAwal.ResetText()
        TextBoxSuhuPemeriksaanAwal.ResetText()
        TextBoxSaturasiPemeriksaanAwal.ResetText()
        TextBoxTinggiBadanPemeriksaanAwal.ResetText()
        TextBoxBeratBadanPemeriksaanAwal.ResetText()
        TextBoxIndeksPemeriksaanAwal.ResetText()
        TextBoxIndeksKeteranganPemeriksaanAwal.ResetText()
        TextBoxLingkarPerutPemeriksaanAwal.ResetText()

        ' Riwayat Penyakit
        TextBoxRiwayatPenyakitDahuluPemeriksaanAwal.ResetText()
        TextBoxRiwayatPenyakitKeluargaPemeriksaanAwal.ResetText()
        TextBoxRiwayatKebiasaanPemeriksaanAwal.ResetText()

        ' Penurunan Berat Badan
        RadioButtonPertanyaan1Pilihan1MST.Checked = True
        RadioButtonPertanyaan1Pilihan2MST.Checked = False
        RadioButtonPertanyaan1Pilihan3MST.Checked = False
        RadioButtonPertanyaan1Opsi1MST.Enabled = False
        RadioButtonPertanyaan1Opsi2MST.Enabled = False
        RadioButtonPertanyaan1Opsi3MST.Enabled = False
        RadioButtonPertanyaan1Opsi4MST.Enabled = False
        RadioButtonPertanyaan1Opsi1MST.Checked = False
        RadioButtonPertanyaan1Opsi2MST.Checked = False
        RadioButtonPertanyaan1Opsi3MST.Checked = False
        RadioButtonPertanyaan1Opsi4MST.Checked = False

        ' Asupan Makan
        RadioButtonPertanyaan2Pilihan1MST.Checked = True

        ' Total Skor MST
        TextBoxTotalSkorMST.ResetText()

        ' Diagnosis Khusus
        RadioButtonTidakPertanyaan3MST.Checked = True
        CheckBoxDiabetesMST.Checked = False
        CheckBoxKemoterapiMST.Checked = False
        CheckBoxHemodialisaMST.Checked = False
        CheckBoxGeriatriMST.Checked = False
        CheckBoxImunitasMST.Checked = False
        CheckBoxTiroidMST.Checked = False
        CheckBoxLainnyaMST.Checked = False
        CheckBoxDiabetesMST.Enabled = False
        CheckBoxKemoterapiMST.Enabled = False
        CheckBoxHemodialisaMST.Enabled = False
        CheckBoxGeriatriMST.Enabled = False
        CheckBoxImunitasMST.Enabled = False
        CheckBoxTiroidMST.Enabled = False
        CheckBoxLainnyaMST.Enabled = False

        TextBoxLainnyaKeterangan.ResetText()
        TextBoxLainnyaKeterangan.Enabled = False

        ' Status Mental
        RadioButtonOrientasiBaikPsiko.Checked = True

        ' StatusPsikologis
        RadioButtonTenangPsiko.Checked = True
        TextBoxLaporKeteranganPsiko.ResetText()
        TextBoxLaporWaktuPsiko.ResetText()
        TextBoxLaporKeteranganPsiko.Enabled = False
        TextBoxLaporWaktuPsiko.Enabled = False

        ' HubunganPasien
        RadioButtonBaikPsiko.Checked = True

        ' NilaiKepercayaan
        RadioButtonAdaPsiko.Checked = True

        ' Bahasa
        RadioButtonBahasaIndonesiaPsiko.Checked = True
        TextBoxBahasaDaerahKeteranganPsiko.ResetText()
        TextBoxBahasaLainnyaPsiko.ResetText()
        TextBoxBahasaDaerahKeteranganPsiko.Enabled = False
        TextBoxBahasaLainnyaPsiko.Enabled = False

        ' StatusFungsional
        RadioButtonStatusMandiriFungsional.Checked = True
        TextBoxStatusPerluBantuanKeteranganFungsional.ResetText()
        TextBoxStatusPerluBantuanKeteranganFungsional.Enabled = False
    End Sub

    Private Sub ClearMedik()
        '# SUBJEKTIF
        ' Anamnesa
        TextBoxKeluhanUtamaMedik.ResetText()
        TextBoxKeluhanTambahanMedik.ResetText()
        TextBoxRiwayatPenyakitSekarang.ResetText()
        TextBoxRiwayatPenggunaanObat.ResetText()
        RadioButtonKeadaanTampakSehatPemeriksaanAwal.Checked = True

        ' Riwayat Penyakit
        TextBoxRiwayatPenyakitDahuluMedik.ResetText()
        TextBoxRiwayatPenyakitKeluargaMedik.ResetText()
        TextBoxRiwayatKebiasaanMedik.ResetText()

        '# OBJEKTIF
        ' Umum
        RadioButtonKeadaanTampakSehatMedik.Checked = True
        RadioButtonComposMentisMedik.Checked = True
        TextBoxSkalaNyeriMedik.ResetText()
        TrackBarSkalaNyeriMedik.Value = 0

        ' Vital Statistik & Antropometri
        TextBoxSistoleMedik.ResetText()
        TextBoxDiastoleMedik.ResetText()
        TextBoxDetakNadiMedik.ResetText()
        TextBoxNafasMedik.ResetText()
        TextBoxSuhuMedik.ResetText()
        TextBoxSaturasiMedik.ResetText()
        TextBoxTinggiBadanMedik.ResetText()
        TextBoxBeratBadanMedik.ResetText()
        TextBoxIndeksMedik.ResetText()
        TextBoxIndeksKeteranganMedik.ResetText()
        TextBoxLingkarPerutMedik.ResetText()

        ' Keterangan
        TextBoxKeteranganMST.ResetText()
        TextBoxKeteranganStatusPsiko.ResetText()
        TextBoxKeteranganStatusFungsional.ResetText()

        ' Status Generalis
        ClearStatusGeneralis()

        ' Odontogram
        ClearDetailOdontogram()
        tblsTransaksiOdontogram = CreateTableTransaksiOdontogram()

        '# ASESMEN
        ClearDiagnosa()

        '# PERENCANAAN
        ' Resep
        ClearTabNonRacikan()
        ClearTabRacikan()
        LabelAlergiObatRacikan.ResetText()
        LabelAlergiObatNonRacikan.ResetText()

        ' Catatan Obat
        TextBoxKeteranganCatatanObat.ResetText()

        ' Rujukan
        ClearTabRujukan()

        ' Tindakan
        ClearTabTindakan() ' Belum Fix

        ' Penunjang
        ClearTabPenunjang() ' Belum Fix

        ' Surat Keterangan
        ClearSuratKeterangan()

        ' Edukasi
        TextBoxKeteranganEdukasi.ResetText()
    End Sub

    Private Sub TextBoxSistolePemeriksaanAwal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxSistolePemeriksaanAwal.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub TextBoxDiastolePemeriksaanAwal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxDiastolePemeriksaanAwal.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub TextBoxTinggiBadanPemeriksaanAwal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxTinggiBadanPemeriksaanAwal.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = vbBack Or e.KeyChar = ".") Then e.Handled = True

        ' Hanya satu tanda titik desimal yang diizinkan
        If e.KeyChar = "." AndAlso (TryCast(sender, TextBox)).Text.Contains(".") Then e.Handled = True
    End Sub

    Private Sub TextBoxBeratBadanPemeriksaanAwal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxBeratBadanPemeriksaanAwal.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = vbBack Or e.KeyChar = ".") Then e.Handled = True

        ' Hanya satu tanda titik desimal yang diizinkan
        If e.KeyChar = "." AndAlso (TryCast(sender, TextBox)).Text.Contains(".") Then e.Handled = True
    End Sub

    Private Sub TextBoxLingkarPerut_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxLingkarPerutPemeriksaanAwal.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = vbBack Or e.KeyChar = ".") Then e.Handled = True

        ' Hanya satu tanda titik desimal yang diizinkan
        If e.KeyChar = "." AndAlso (TryCast(sender, TextBox)).Text.Contains(".") Then e.Handled = True
    End Sub

    Private Sub TextBoxDetakNadiPemeriksaanAwal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxDetakNadiPemeriksaanAwal.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub TextBoxNafasPemeriksaanAwal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxNafasPemeriksaanAwal.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub TextBoxSuhuPemeriksaanAwal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxSuhuPemeriksaanAwal.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = vbBack Or e.KeyChar = ".") Then e.Handled = True

        ' Hanya satu tanda titik desimal yang diizinkan
        If e.KeyChar = "." AndAlso (TryCast(sender, TextBox)).Text.Contains(".") Then e.Handled = True
    End Sub

    Private Sub TextBoxSaturasiPemeriksaanAwal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxSaturasiPemeriksaanAwal.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Public Sub LoadGridAlergiPasien()
        LoadDataAlergi(idPasien, GridControlAlergiMedis)
        LoadDataAlergi(idPasien, GridControlAlergiPemeriksaanAwal)
        LoadNotification(False)
    End Sub

    Private Function getNilaiNormalStatusGeneralis(ByRef NamaBagian As String) As String
        Dim nilaiNormal As String = ReadSQLNIK("SELECT NilaiNormal FROM MasterStatusGeneralis WHERE NamaBagian = '" & NamaBagian & "'")

        Return nilaiNormal
    End Function

    Private Sub CheckBoxStatusGeneralisThorax_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxStatusGeneralisThorax.CheckedChanged
        If CheckBoxStatusGeneralisThorax.Checked = True Then
            TextBoxStatusGeneralisThorax.ReadOnly = False
            If TextBoxStatusGeneralisThorax.Text.Length = 0 Then TextBoxStatusGeneralisThorax.Text = getNilaiNormalStatusGeneralis("Thorax")
        Else
            TextBoxStatusGeneralisThorax.ReadOnly = True
            TextBoxStatusGeneralisThorax.ResetText()
        End If
    End Sub

    Private Sub CheckBoxStatusGeneralisKepala_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxStatusGeneralisKepala.CheckedChanged
        If CheckBoxStatusGeneralisKepala.Checked = True Then
            TextBoxStatusGeneralisKepala.ReadOnly = False
            If TextBoxStatusGeneralisKepala.Text.Length = 0 Then TextBoxStatusGeneralisKepala.Text = getNilaiNormalStatusGeneralis("Kepala")
        Else
            TextBoxStatusGeneralisKepala.ReadOnly = True
            TextBoxStatusGeneralisKepala.ResetText()
        End If
    End Sub

    Private Sub CheckBoxStatusGeneralisMata_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxStatusGeneralisMata.CheckedChanged
        If CheckBoxStatusGeneralisMata.Checked = True Then
            TextBoxStatusGeneralisMata.ReadOnly = False
            If TextBoxStatusGeneralisMata.Text.Length = 0 Then TextBoxStatusGeneralisMata.Text = getNilaiNormalStatusGeneralis("Mata")
        Else
            TextBoxStatusGeneralisMata.ReadOnly = True
            TextBoxStatusGeneralisMata.ResetText()
        End If
    End Sub

    Private Sub CheckBoxStatusGeneralisHidung_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxStatusGeneralisHidung.CheckedChanged
        If CheckBoxStatusGeneralisHidung.Checked = True Then
            TextBoxStatusGeneralisHidung.ReadOnly = False
            If TextBoxStatusGeneralisHidung.Text.Length = 0 Then TextBoxStatusGeneralisHidung.Text = getNilaiNormalStatusGeneralis("Hidung")
        Else
            TextBoxStatusGeneralisHidung.ReadOnly = True
            TextBoxStatusGeneralisHidung.ResetText()
        End If
    End Sub

    Private Sub CheckBoxStatusGeneralisMulutFaring_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxStatusGeneralisMulutFaring.CheckedChanged
        If CheckBoxStatusGeneralisMulutFaring.Checked = True Then
            TextBoxStatusGeneralisMulutFaring.ReadOnly = False
            If TextBoxStatusGeneralisMulutFaring.Text.Length = 0 Then TextBoxStatusGeneralisMulutFaring.Text = getNilaiNormalStatusGeneralis("MulutFaring")
        Else
            TextBoxStatusGeneralisMulutFaring.ReadOnly = True
            TextBoxStatusGeneralisMulutFaring.ResetText()
        End If
    End Sub

    Private Sub CheckBoxStatusGeneralisTelinga_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxStatusGeneralisTelinga.CheckedChanged
        If CheckBoxStatusGeneralisTelinga.Checked = True Then
            TextBoxStatusGeneralisTelinga.ReadOnly = False
            If TextBoxStatusGeneralisTelinga.Text.Length = 0 Then TextBoxStatusGeneralisTelinga.Text = getNilaiNormalStatusGeneralis("Telinga")
        Else
            TextBoxStatusGeneralisTelinga.ReadOnly = True
            TextBoxStatusGeneralisTelinga.ResetText()
        End If
    End Sub

    Private Sub CheckBoxStatusGeneralisLeher_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxStatusGeneralisLeher.CheckedChanged
        If CheckBoxStatusGeneralisLeher.Checked = True Then
            TextBoxStatusGeneralisLeher.ReadOnly = False
            If TextBoxStatusGeneralisLeher.Text.Length = 0 Then TextBoxStatusGeneralisLeher.Text = getNilaiNormalStatusGeneralis("Leher")
        Else
            TextBoxStatusGeneralisLeher.ReadOnly = True
            TextBoxStatusGeneralisLeher.ResetText()
        End If
    End Sub

    Private Sub CheckBoxStatusGeneralisAbdomen_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxStatusGeneralisAbdomen.CheckedChanged
        If CheckBoxStatusGeneralisAbdomen.Checked = True Then
            TextBoxStatusGeneralisAbdomen.ReadOnly = False
            If TextBoxStatusGeneralisAbdomen.Text.Length = 0 Then TextBoxStatusGeneralisAbdomen.Text = getNilaiNormalStatusGeneralis("Abdomen")
        Else
            TextBoxStatusGeneralisAbdomen.ReadOnly = True
            TextBoxStatusGeneralisAbdomen.ResetText()
        End If
    End Sub

    Private Sub CheckBoxStatusGeneralisEkstremitas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxStatusGeneralisEkstremitas.CheckedChanged
        If CheckBoxStatusGeneralisEkstremitas.Checked = True Then
            TextBoxStatusGeneralisEkstremitas.ReadOnly = False
            If TextBoxStatusGeneralisEkstremitas.Text.Length = 0 Then TextBoxStatusGeneralisEkstremitas.Text = getNilaiNormalStatusGeneralis("Ekstremitas")
        Else
            TextBoxStatusGeneralisEkstremitas.ReadOnly = True
            TextBoxStatusGeneralisEkstremitas.ResetText()
        End If
    End Sub

    Private Sub ButtonPerencanaan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCekStik.Click, ButtonResep.Click, ButtonTindakan.Click, ButtonPenunjang.Click, ButtonSuratKeterangan.Click, ButtonSuratRujukan.Click, ButtonPerencanaanEdukasi.Click
        Try
            Dim myButton = DirectCast(sender, Button)

            Dim lokasiPoli As DataTable = ReadSQL("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NoPoli'")

            If lokasiPoli.Rows.Count > 0 Then
                Dim row As DataRow = lokasiPoli.Rows(0)
                Dim strValue As String = row("StrValue").ToString()

                If strValue = "L003" Then
                    ButtonScanQR.Visible = True
                Else
                    ButtonScanQR.Visible = False
                    CheckBoxInformedConsent.Location = New Point(243, 16)
                End If
            Else
                ButtonScanQR.Visible = False
                CheckBoxInformedConsent.Location = New Point(243, 16)
            End If

            '# Set Default Warna Button
            ButtonResep.BackColor = Color.FromArgb(0, 100, 200)
            ButtonTindakan.BackColor = Color.FromArgb(0, 100, 200)
            ButtonPenunjang.BackColor = Color.FromArgb(0, 100, 200)
            ButtonSuratKeterangan.BackColor = Color.FromArgb(0, 100, 200)
            ButtonSuratRujukan.BackColor = Color.FromArgb(0, 100, 200)
            ButtonPerencanaanEdukasi.BackColor = Color.FromArgb(0, 100, 200)
            ButtonCekStik.BackColor = Color.FromArgb(0, 100, 200)

            '# Buka TabPage
            Select Case myButton.Name
                Case "ButtonResep"
                    TabControlPerencanaan.SelectedTab = TabResep
                Case "ButtonTindakan"
                    TabControlPerencanaan.SelectedTab = TabTindakan
                Case "ButtonPenunjang"
                    TabControlPerencanaan.SelectedTab = TabPenunjang
                Case "ButtonSuratKeterangan"
                    TabControlPerencanaan.SelectedTab = TabSuratKeterangan
                Case "ButtonSuratRujukan"
                    TabControlPerencanaan.SelectedTab = TabSuratRujukan
                Case "ButtonPerencanaanEdukasi"
                    LoadPerencanaanEdukasi()
                    TabControlPerencanaan.SelectedTab = TabPageEdukasi
                Case "ButtonCekStik"
                    TabControlPerencanaan.SelectedTab = TabCekStik
            End Select

            '# Ganti Warna Button
            myButton.BackColor = Color.FromArgb(85, 99, 114)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Warning!")
        End Try
    End Sub

    Private Sub LoadPerencanaanEdukasi()
        Dim perencanaanEdukasi As String = ReadSQLNIK("SELECT Edukasi FROM TransaksiDetail WHERE NoUrut = '" & idTransaksi & "'")

        If perencanaanEdukasi <> "" Then TextBoxKeteranganEdukasi.Text = perencanaanEdukasi
    End Sub

    Private Sub ButtonTambahPenunjang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTambahPenunjang.Click
        FindMultiple.Query("select TindakanID as ID,NamaTindakan as [Tindakan],JenisTindakan as [Jenis],PARSENAME(CONVERT(varchar,convert(money,BiayaTindakan),1),2) as [Biaya Tindakan],[Mesin] from MasterLab where Closed=0 ", " order by JenisTindakan,NamaTindakan", "FindTindakanLabPerencanaan", 1)
        FindMultiple.Show()
    End Sub

    Public Sub LoadTindakanLab(ByRef Trow() As DataRow)
        If CheckTambahTindakanLab(Trow) = True Then
            Dim nomorUrutTransaksi As String = ""
            Dim idTransaksiLab As String = ""

            If TextBoxNoTransaksiLab.Text = "" Then
                ' Generate No Urut Transaksi
                nomorUrutTransaksi = generateNoTransaksi("L", "LABORATORIUM", DateTime.Now.ToString("yyyyMMdd"), False)

                ' Insert TransaksiLab
                WriteSQL("INSERT INTO TransaksiLab (IDInternet,DokterRequest,DokterLab,TglLab,TotalTagihan,TotalDisc,Pembulatan,NettBayar,ClosedTransaksi,CreateDate,CreateBy,NoUrut, StatusSoftcopy, StatusHardcopy) " & _
                         "VALUES('" & idPasien & "', '-', '-', GETDATE(), 0, 0, 0, 0, 0, GETDATE(), '" & userInput & "', '" & nomorUrutTransaksi & "',0,0)", 4)

                ' Update Nomor Transaksi Lab
                WriteSQL("UPDATE TransaksiDetail SET NoTransaksiLab = '" & nomorUrutTransaksi & "' WHERE NoUrut = '" & idTransaksi & "'", 4)

                ' Set Nomor Lab
                TextBoxNoTransaksiLab.Text = nomorUrutTransaksi
            Else
                nomorUrutTransaksi = TextBoxNoTransaksiLab.Text
            End If

            ' Set ID Lab
            idTransaksiLab = ReadSQLNIK("SELECT TransLabID FROM TransaksiLab WHERE NoUrut = '" & nomorUrutTransaksi & "'")

            If CheckSQL("SELECT * FROM TransaksiDetail WHERE NoUrut = '" & nomorUrutTransaksi & "'") = False Then
                ' Insert TransaksiDetail
                WriteSQL("INSERT INTO TransaksiDetail(NoUrutBPJS, NoTransaksi, JenisKunjungan, JenisRawat, JenisTransaksi, JenisPoli, TanggalTransaksi, KeluhanUtama, KeluhanTambahan, IDInternet, StatusBPJS, NoUrut, StatusHandaya, StatusLansia, StatusDifabel, StatusGawatDarurat, CreatedBy, CreatedDate) " & _
                         "VALUES(NULL, '" & idTransaksiLab & "', 'Kunjungan Sakit', 'Rawat Jalan', 'LAB', 'LABORATORIUM', GETDATE(), '-', '-', '" & idPasien & "'," & Convert.ToInt32(False) & ", '" & nomorUrutTransaksi & "', " & Convert.ToInt32(False) & ", " & _
                         "" & Convert.ToInt32(False) & ", " & Convert.ToInt32(False) & ", " & Convert.ToInt32(False) & ", '" & userInput & "', GETDATE())", 4)
            End If

            If Trow.Count > 0 Then
                For i As Integer = 0 To Trow.Length - 1
                    ' Insert TransaksiLabDetail
                    WriteSQL("INSERT INTO TransaksiLabDetail(TransLabID, TindakanID, NamaTindakan, JenisTindakan, BiayaTindakan, DiscTindakan, NettBayar, DiscPersenTindakan, Mesin, Urutan, StatusPembayaran, CreatedBy, CreatedDate, NoTransaksiPoli) " & _
                             "VALUES('" & idTransaksiLab & "','" & Trow(i)("ID") & "','" & Trow(i)("Tindakan") & "','" & Trow(i)("Jenis") & "'," & CDbl(Trow(i)("Biaya Tindakan")) & ",0," & CDbl(Trow(i)("Biaya Tindakan")) & ",0,'" & Trow(i)("Mesin") & "','', 'PENDING', '" & userInput & "', GETDATE(), '" & idTransaksi & "')", 4)
                Next
            End If

            LoadGridRiwayatPemeriksaanPenunjang()
            SaveDetailPemeriksaanPenunjang()

            MsgBox("Data berhasil disimpan. No Transaksi Lab : " & nomorUrutTransaksi, MsgBoxStyle.Information, "Success!")
        End If
    End Sub

    Private Sub SaveDetailPemeriksaanPenunjang()
        Dim detailTindakan As String = ""
        Dim Tbls As DataTable = New DataTable

        ' Get Data Tindakan Lab
        Tbls = ReadSQL("SELECT * FROM TransaksiLabDetail " & _
                       "WHERE TransaksiLabDetail.NoTransaksiPoli = '" & idTransaksi & "'")

        For Each Trow As DataRow In Tbls.Rows
            detailTindakan = detailTindakan & "- " & Trow("NamaTindakan").ToString & vbCrLf
        Next

        If detailTindakan <> "" Then detailTindakan = Strings.Left(detailTindakan, detailTindakan.Length - 2)

        ' Update Keterangan Diagnosa
        WriteSQL("UPDATE TransaksiDetail SET PemeriksaanPenunjang = '" & detailTindakan & "' WHERE NoUrut = '" & idTransaksi & "'", 4)
    End Sub

    Function CheckTambahTindakanLab(ByRef Trow() As DataRow)
        If Trow.Count > 0 Then
            For i As Integer = 0 To Trow.Length - 1
                If CheckSQL("SELECT * FROM TransaksiLabDetail WHERE NoTransaksiPoli = '" & idTransaksi & "' AND TindakanID = '" & Trow(i)("ID") & "'") = True Then
                    MsgBox("Terdapat tindakan double. Sudah ada pada pilihan. Check kembali.", MsgBoxStyle.Exclamation, "Warning!")
                    Return False
                End If
            Next
        End If

        Dim result As DialogResult
        result = MessageBox.Show("Yakin untuk menyimpan data & mengirim data ke kasir laboratorium?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.No Then
            MsgBox("Tindakan Laboratorium dibatalkan.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        Return True
    End Function

    Public Sub LoadTindakanPoli(ByRef Trow As DataRowView)
        If CheckTambahTindakanPoli(Trow) = True Then
            If Trow("TindakanID") > 0 Then
                TextBoxTindakanID.Text = Trow("TindakanID")
                TextBoxNamaTindakan.Text = Trow("NamaTindakan")
                TextBoxJenisTindakan.Text = Trow("JenisTindakan")
                TextBoxBiayaTindakan.Text = Trow("BiayaTindakan")
                CheckBoxInformedConsent.Checked = Trow("StatusInformedConsent").ToString
            End If
        End If
    End Sub

    Function CheckTambahTindakanPoli(ByRef Trow As DataRowView)
        ' Validasi tindakan double jika diperlukan

        Return True
    End Function

    Private Sub SetClearGridPenandaanGambar()
        GridControlPenandaanGambar.DataSource = CreateTablePenandaanGambar()
    End Sub

    Function CreateTablePenandaanGambar() As DataTable
        Dim Thasil As New DataTable

        insertRowToTbls(Thasil, "Typstring", "Nomor")
        insertRowToTbls(Thasil, "Typstring", "Keterangan")

        For Each Tcol As DataColumn In Thasil.Columns
            Tcol.ReadOnly = True
        Next

        Return Thasil
    End Function

    Private Sub ButtonSimpanTindakan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSimpanTindakan.Click
        If ValidasiDataTindakanPoli() = True AndAlso ValidasiSignatureInformedConsent() = True Then
            ' Get data poli
            Dim trowPoli As DataRow = tblsRekamMedis.Rows(0)

            ' Get Penjamin
            Dim penjaminTindakan As String = ""
            If RadioButtonPenjaminUmum.Checked = True Then
                penjaminTindakan = RadioButtonPenjaminUmum.Text
            ElseIf RadioButtonPenjaminAsuransiLain.Checked = True Then
                penjaminTindakan = LabelPenjaminAsuransiLain.Text
            End If

            Dim dtPasien As DataTable = ReadSQL("SELECT MR.Nama, MR.NoHandphone, MR.JenisKelamin " & _
                                    "FROM TransaksiDetail TD " & _
                                    "INNER JOIN MasterPasien MR ON TD.IDInternet = MR.NoRekamMedis " & _
                                    "WHERE TD.NoUrut = '" & idTransaksi & "'")

            Dim namaPasien As String = ""
            Dim NoHp As String = ""
            Dim jenisKelamin As String = ""

            If dtPasien.Rows.Count > 0 Then
                namaPasien = dtPasien.Rows(0)("Nama").ToString()
                NoHp = dtPasien.Rows(0)("NoHandphone").ToString()
                jenisKelamin = dtPasien.Rows(0)("JenisKelamin").ToString()
            End If

            If jenisTransaksi = "UMUM" Or jenisTransaksi = "POLI" Then
                ' Insert ke tabel TransaksiPoliDetail
                WriteSQL("INSERT INTO TransaksiPoliDetail(TransPoliID,TindakanID,NamaTindakan,JenisTindakan,BiayaTindakan,DiscTindakan,NettBayar,Penjamin,GroupBayar,StatusPembayaran,CreatedBy,CreatedDate) " & _
                         "VALUES('" & trowPoli("TransPoliID") & "','" & TextBoxTindakanID.Text & "','" & TextBoxNamaTindakan.Text & "','" & TextBoxJenisTindakan.Text & "'," & CDbl(TextBoxBiayaTindakan.Text) & ", 0," & CDbl(TextBoxBiayaTindakan.Text) & ", '" & penjaminTindakan & "', '', 'PENDING', '" & userInput & "', GETDATE())", 4)

                Dim dtReminder As DataTable = ReadSQL("SELECT Reminder, Hari FROM MasterTindakan WHERE TindakanID = '" & TextBoxTindakanID.Text & "'")

                If dtReminder.Rows.Count > 0 AndAlso CBool(dtReminder.Rows(0)("Reminder")) = True Then
                    Dim hariStr As String = dtReminder.Rows(0)("Hari").ToString().Trim()
                    Dim jumlahHari As Integer = 1 ' default jika kosong
                    If IsNumeric(hariStr) Then
                        jumlahHari = CInt(hariStr)
                    End If

                    ' Hitung tanggal reminder = hari ini + jumlah hari
                    Dim tglReminder As Date = Date.Today.AddDays(jumlahHari)
                    Dim kdPoli As String = ReadSQLNIK( _
                        "SELECT TOP 1 MPT.KodeBPJS " & _
                        "FROM TransaksiDetail TD " & _
                        "INNER JOIN MasterPoliTujuan MPT ON TD.JenisPoli = MPT.NamaPoli " & _
                        "WHERE TD.NoUrut = '" & idTransaksi & "'")

                    ' Simpan ke LogReminderPasien
                    WriteSQL("INSERT INTO LogReminderPasien " & _
                          "(NamaPasien, NoHP, Keperluan, Tanggal, Status, CreatedBy, CreatedDate, JenisKelamin, NoRekamMedis,  KodePoli) " & _
                          "VALUES (" & _
                          "'" & namaPasien.Replace("'", "''") & "', " & _
                          "'" & NoHp.Replace("'", "''") & "', " & _
                          "'" & TextBoxNamaTindakan.Text.Replace("'", "''") & "', " & _
                          "'" & tglReminder.ToString("yyyy-MM-dd 09:00") & "', " & _
                          "'TERJADWAL', " & _
                          "'" & userInput.Replace("'", "''") & "', " & _
                          "GETDATE(), " & _
                          "'" & jenisKelamin & "', " & _
                          "'" & idPasien & "'," & _
                          "'" & kdPoli & "'" & _
                          ")", 4)

                    MsgBox("INSERT Reminder sukses untuk: " & namaPasien & vbCrLf & "Tanggal: " & tglReminder.ToString("yyyy-MM-dd"), MsgBoxStyle.Information)
                End If

            ElseIf jenisTransaksi = "GIGI" Then
                ' Insert ke tabel TransaksiGigiDetail
                WriteSQL("INSERT INTO TransaksiGigiDetail(TransGigiID,TindakanID,NamaTindakan,JenisTindakan,BiayaTindakan,DiscTindakan,NettBayar,Penjamin,GroupBayar,StatusPembayaran,CreatedBy,CreatedDate) " & _
                         "VALUES('" & trowPoli("TransGigiID") & "','" & TextBoxTindakanID.Text & "','" & TextBoxNamaTindakan.Text & "','" & TextBoxJenisTindakan.Text & "'," & CDbl(TextBoxBiayaTindakan.Text) & ", 0," & CDbl(TextBoxBiayaTindakan.Text) & ", '" & penjaminTindakan & "', '', 'PENDING', '" & userInput & "', GETDATE())", 4)
            End If

            MsgBox("Tindakan berhasil disimpan.", MsgBoxStyle.Information, "Success!")

            ' Refresh Grid
            LoadGridTindakanPoli()

            SaveDetailTindakan()
            ClearTabTindakan()
        Else
            ' Refresh Grid
            LoadGridTindakanPoli()
        End If
    End Sub

    Private Sub SaveDetailTindakan()
        Dim detailTindakan As String = ""
        Dim Tbls As DataTable = New DataTable

        If jenisTransaksi = "UMUM" Or jenisTransaksi = "POLI" Then
            Tbls = ReadSQL("SELECT * FROM TransaksiPoliDetail " & _
                           "WHERE StatusPembayaran = 'PAID' AND DeletedDate IS NULL AND TransPoliID IN (SELECT TransPoliID FROM TransaksiPoli WHERE NoUrut = '" & idTransaksi & "') AND JenisTindakan NOT LIKE '%Konsul%'")
        ElseIf jenisTransaksi = "GIGI" Then
            Tbls = ReadSQL("SELECT * FROM TransaksiGigiDetail " & _
                           "WHERE StatusPembayaran = 'PAID' AND DeletedDate IS NULL AND TransGigiID IN (SELECT TransGigiID FROM TransaksiGigi WHERE NoUrut = '" & idTransaksi & "') AND JenisTindakan NOT LIKE '%Konsul%'")
        End If

        For Each Trow As DataRow In Tbls.Rows
            detailTindakan = detailTindakan & "- " & Trow("NamaTindakan").ToString & vbCrLf
        Next

        If detailTindakan <> "" Then detailTindakan = Strings.Left(detailTindakan, detailTindakan.Length - 2)

        ' Update Keterangan Diagnosa
        WriteSQL("UPDATE TransaksiDetail SET Tindakan = '" & detailTindakan & "' WHERE NoUrut = '" & idTransaksi & "'", 4)
    End Sub

    Function ValidasiDataTindakanPoli() As Boolean
        Select Case MsgBox("Apakah anda yakin ingin melanjutkan?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Validasi.")
            Case MsgBoxResult.No
                Return False
        End Select

        ' Validasi input tindakan
        If TextBoxTindakanID.Text = "" Then
            MsgBox("Masukkan tindakan pasien terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        ' Validasi apakah sudah dilakukan pembayaran
        If jenisTransaksi = "UMUM" Or jenisTransaksi = "POLI" Then
            If CheckSQL("SELECT * FROM TransaksiPoli WHERE NoUrut = '" & idTransaksi & "' AND ClosedBayar <> '12/31/9998'") = True Then
                MsgBox("Gagal. Transaksi sudah dilakukan pembayaran tindakan.", MsgBoxStyle.Exclamation, "Warning!")
                Return False
            End If
        ElseIf jenisTransaksi = "GIGI" Then
            If CheckSQL("SELECT * FROM TransaksiGigi WHERE NoUrut = '" & idTransaksi & "' AND ClosedBayar <> '12/31/9998'") = True Then
                MsgBox("Gagal. Transaksi sudah dilakukan pembayaran tindakan.", MsgBoxStyle.Exclamation, "Warning!")
                Return False
            End If
        End If

        ' Validasi jika beda hari
        If jenisTransaksi = "UMUM" Or jenisTransaksi = "POLI" Then
            If CheckSQL("SELECT * FROM TransaksiPoli WHERE NoUrut = '" & idTransaksi & "' AND CAST(TglPoli AS DATE) = CAST(GETDATE() AS DATE)") = False Then
                MsgBox("Gagal. Transaksi sudah melewati hari yang ditentukan.", MsgBoxStyle.Exclamation, "Warning!")
                Return False
            End If
        ElseIf jenisTransaksi = "GIGI" Then
            If CheckSQL("SELECT * FROM TransaksiGigi WHERE NoUrut = '" & idTransaksi & "' AND CAST(TglGigi AS DATE) = CAST(GETDATE() AS DATE)") = False Then
                MsgBox("Gagal. Transaksi sudah melewati hari yang ditentukan.", MsgBoxStyle.Exclamation, "Warning!")
                Return False
            End If
        End If

        ' Validasi Penjamin Tindakan
        If RadioButtonPenjaminAsuransiLain.Checked = True And LabelPenjaminAsuransiLain.Text = "" Then
            MsgBox("Gagal. Pilih penjamin asuransi terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        Return True
    End Function

    Function ValidasiSignatureInformedConsent() As Boolean
        Dim kodeLokasi As String = ReadSQLNIK("select StrValue from MsConfig where ConfigName = 'NoPoli'")
        Dim statusInformedConsent As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'SettingInformedConsent'")

        ' Skip jika setting informed consent tidak aktif
        If statusInformedConsent = "No" Then Return True

        ' Skip jika tindakan tidak membutuhkan informed consent
        If CheckBoxInformedConsent.Checked = False Then Return True

        Dim baseURL As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'web_service_klinik'")
        Dim urlWebService As String = baseURL & "api/informed_consent/no_transaksi/" & idTransaksi & "/id_tindakan/" & TextBoxTindakanID.Text & "/kode_lokasi/" & kodeLokasi
        Dim response As String = "[" & GetDataAPI(urlWebService) & "]"

        Dim jsonObject() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of InformedConsent())(response)

        For Each rowData As InformedConsent In jsonObject
            If rowData.response.message <> "Transaksi berhasil" Then
                MsgBox(rowData.response.message, MsgBoxStyle.Exclamation, "Warning!")
                Return False
            Else
                ' Insert Informed Consent
                Dim query As String = "INSERT INTO InformedConsent (NoTransaksi, NoRekamMedis, TglTransaksi, JenisPoli, KeteranganLokasi, NoNIK, NamaPasien, UmurPasien, JenisKelaminPasien, AlamatPasien, NamaDokter, NamaPerawat, KeteranganDiagnosis, DasarDiagnosis, TindakanID, KeteranganTindakan, IndikasiTindakan, TataCara, TujuanTindakan, Risiko, Komplikasi, Prognosis, AlternatifTindakan, BiayaTindakan, NamaPenanggungJawab, UmurPenanggungJawab, JenisKelaminPenanggungJawab, HubunganPenanggungJawab, AlamatPenanggungJawab, StatusSaksiPasien, NamaSaksiPasien, HubunganSaksiPasien, StatusPersetujuan, StatusTransaksi, SignatureDokter1, SignatureDokter2, SignaturePerawat, SignaturePasien1, SignaturePasien2, SignatureKeluarga, CreatedBy, CreatedDate) " & _
                                      "VALUES (@NoTransaksi, @NoRekamMedis, @TglTransaksi, @JenisPoli, @KeteranganLokasi, @NoNIK, @NamaPasien, @UmurPasien, @JenisKelaminPasien, @AlamatPasien, @NamaDokter, @NamaPerawat, @KeteranganDiagnosis, @DasarDiagnosis, @TindakanID, @KeteranganTindakan, @IndikasiTindakan, @TataCara, @TujuanTindakan, @Risiko, @Komplikasi, @Prognosis, @AlternatifTindakan, @BiayaTindakan, @NamaPenanggungJawab, @UmurPenanggungJawab, @JenisKelaminPenanggungJawab, @HubunganPenanggungJawab, @AlamatPenanggungJawab, @StatusSaksiPasien, @NamaSaksiPasien, @HubunganSaksiPasien, @StatusPersetujuan, @StatusTransaksi, @SignatureDokter1, @SignatureDokter2, @SignaturePerawat, @SignaturePasien1, @SignaturePasien2, @SignatureKeluarga, @CreatedBy, GETDATE())"

                ' Memanggil fungsi WriteParameterizedSQL untuk eksekusi query
                WriteParameterizedLokalSQL(query, 4, _
                    New SqlParameter("@NoTransaksi", rowData.response.data.no_transaksi), _
                    New SqlParameter("@NoRekamMedis", rowData.response.data.no_rekam_medis), _
                    New SqlParameter("@TglTransaksi", rowData.response.data.tgl_transaksi), _
                    New SqlParameter("@JenisPoli", rowData.response.data.jenis_poli), _
                    New SqlParameter("@KeteranganLokasi", rowData.response.data.ket_lokasi), _
                    New SqlParameter("@NoNIK", rowData.response.data.no_nik), _
                    New SqlParameter("@NamaPasien", rowData.response.data.nama_pasien), _
                    New SqlParameter("@UmurPasien", rowData.response.data.umur_pasien), _
                    New SqlParameter("@JenisKelaminPasien", rowData.response.data.jenis_kelamin_pasien), _
                    New SqlParameter("@AlamatPasien", rowData.response.data.alamat_pasien), _
                    New SqlParameter("@NamaDokter", rowData.response.data.nama_dokter), _
                    New SqlParameter("@NamaPerawat", rowData.response.data.nama_perawat), _
                    New SqlParameter("@KeteranganDiagnosis", rowData.response.data.ket_diagnosis), _
                    New SqlParameter("@DasarDiagnosis", rowData.response.data.dasar_diagnosis), _
                    New SqlParameter("@TindakanID", rowData.response.data.id_tindakan), _
                    New SqlParameter("@KeteranganTindakan", rowData.response.data.ket_tindakan), _
                    New SqlParameter("@IndikasiTindakan", rowData.response.data.indikasi_tindakan), _
                    New SqlParameter("@TataCara", rowData.response.data.tata_cara), _
                    New SqlParameter("@TujuanTindakan", rowData.response.data.tujuan_tindakan), _
                    New SqlParameter("@Risiko", rowData.response.data.risiko), _
                    New SqlParameter("@Komplikasi", rowData.response.data.komplikasi), _
                    New SqlParameter("@Prognosis", rowData.response.data.prognosis), _
                    New SqlParameter("@AlternatifTindakan", rowData.response.data.alternatif_tindakan), _
                    New SqlParameter("@BiayaTindakan", rowData.response.data.biaya_tindakan), _
                    New SqlParameter("@NamaPenanggungJawab", rowData.response.data.nama_penanggung_jawab), _
                    New SqlParameter("@UmurPenanggungJawab", rowData.response.data.umur_penanggung_jawab), _
                    New SqlParameter("@JenisKelaminPenanggungJawab", rowData.response.data.jenis_kelamin_penanggung_jawab), _
                    New SqlParameter("@HubunganPenanggungJawab", rowData.response.data.hubungan_penanggung_jawab), _
                    New SqlParameter("@AlamatPenanggungJawab", rowData.response.data.alamat_penanggung_jawab), _
                    New SqlParameter("@StatusSaksiPasien", rowData.response.data.status_saksi_pasien), _
                    New SqlParameter("@NamaSaksiPasien", rowData.response.data.nama_saksi_pasien), _
                    New SqlParameter("@HubunganSaksiPasien", rowData.response.data.hubungan_saksi_pasien), _
                    New SqlParameter("@StatusPersetujuan", rowData.response.data.status_persetujuan), _
                    New SqlParameter("@StatusTransaksi", rowData.response.data.status_transaksi), _
                    New SqlParameter("@SignatureDokter1", rowData.response.data.signed_dokter_1), _
                    New SqlParameter("@SignatureDokter2", rowData.response.data.signed_dokter_2), _
                    New SqlParameter("@SignaturePerawat", rowData.response.data.signed_perawat), _
                    New SqlParameter("@SignaturePasien1", rowData.response.data.signed_pasien_1), _
                    New SqlParameter("@SignaturePasien2", rowData.response.data.signed_pasien_2), _
                    New SqlParameter("@SignatureKeluarga", rowData.response.data.signed_keluarga), _
                    New SqlParameter("@CreatedBy", userInput))
            End If

            'MsgBox(rowData.response.message)
            'MsgBox(rowData.response.data.nama_pasien)
        Next

        ' ============================================

        '' Deserialize JSON response
        'Dim jsonObject As JObject = JObject.Parse(response)

        '' Set Response
        'Dim responseObj As JObject = jsonObject("response")
        'Dim responseMessage As String = responseObj("message").ToString()

        '' Set MetaData
        'Dim metaDataObj As JObject = jsonObject("metaData")
        'Dim codeMetaData As Integer = Convert.ToInt32(metaDataObj("code").ToString)

        'If responseMessage <> "Transaksi berhasil" Then
        '    MsgBox(responseMessage, MsgBoxStyle.Exclamation, "Warning!")
        '    Return False
        'Else
        '    Dim responseData As String = responseObj("data").ToString()

        '    ' Insert Informed Consent

        'End If

        Return True
    End Function

    Private Sub SaveMedikSubjektif()
        Try
            Dim parameterSubjektif As String = ""
            Dim parameterGeneral As String = ""
            Dim parameterUpdatePasien As String = ""

            If CheckInputSubjektif() = True Then
                parameterSubjektif = GetDataMedikSubjektif()
                parameterGeneral = "NoKunjunganBPJS = '" & noKunjunganBPJS & "'"

                ' Update tabel TransaksiDetail
                WriteSQL("UPDATE TransaksiDetail SET " & parameterGeneral & "," & parameterSubjektif & " WHERE NoUrut = '" & idTransaksi & "'", 4)

                ' Save riwayat penyakit pasien
                parameterUpdatePasien = "RiwayatPenyakitDahulu = '" & TextBoxRiwayatPenyakitDahuluMedik.Text & "'," & _
                                        "RiwayatPenyakitKeluarga = '" & TextBoxRiwayatPenyakitKeluargaMedik.Text & "'," & _
                                        "RiwayatKebiasaan = '" & TextBoxRiwayatKebiasaanPemeriksaanAwal.Text & "'"

                WriteSQL("UPDATE MasterPasien SET " & parameterUpdatePasien & " WHERE NoRekamMedis = '" & idPasien & "'", 4)

                ' Kirim P-Care
                If statusBPJS = True AndAlso CheckBridgingPcareActive() = True Then SaveKunjunganBPJS()

                MsgBox("Data berhasil disimpan.", MsgBoxStyle.Information, "Success!")

                ' UATBPJS
                ' Refresh Form Rekam Medis
                SetDataFromPendaftaran(idPasien, idTransaksi, jenisTransaksi)


                TextBoxSaranDiagnosa.Text = GetSaranDiagnosaICD_ML(idPasien)

                If TextBoxSaranDiagnosa.Text.Trim() = "" Then
                    TextBoxSaranDiagnosa.Text = "-"
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Warning!")
        End Try
    End Sub

    'NEW HYU
    Public Function SendPCarePendaftaranV3( _
            ByVal kdProviderPeserta As String, _
            ByVal noKartu As String, _
            ByVal tglDaftar As String, _
            ByVal kdPoli As String, _
            ByVal kdTkp As String, _
            ByVal keluhan As String, _
            ByVal kunjSakit As Boolean, _
            ByVal sistole As Integer, _
            ByVal diastole As Integer, _
            ByVal beratBadan As Double, _
            ByVal tinggiBadan As Double, _
            ByVal respRate As Integer, _
            ByVal lingkarPerut As Integer, _
            ByVal heartRate As Integer _
        ) As Boolean

        Try
            ' 🔒 VALIDASI
            If String.IsNullOrEmpty(noKartu) Then
                MsgBox("No Kartu kosong", MsgBoxStyle.Exclamation)
                Return False
            End If

            If String.IsNullOrEmpty(kdPoli) Then
                MsgBox("Kode Poli kosong", MsgBoxStyle.Exclamation)
                Return False
            End If

            ' 🔗 CONFIG
            Dim urlWebService As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
            Dim loc As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NoPoli'")

            Dim url As String = urlWebService & "api/pcare/pendaftaran"

            ' 🔥 BUILD JSON BODY
            Dim jsonBody As String = "{"
            jsonBody &= """kode_klinik"":""" & loc & ""","
            jsonBody &= """kdProviderPeserta"":""" & kdProviderPeserta & ""","
            jsonBody &= """noKartu"":""" & noKartu & ""","
            jsonBody &= """tglDaftar"":""" & tglDaftar & ""","
            jsonBody &= """kdPoli"":""" & kdPoli & ""","
            jsonBody &= """kdTkp"":""" & kdTkp & ""","

            ' keluhan bisa null
            If String.IsNullOrEmpty(keluhan) Then
                jsonBody &= """keluhan"":null,"
            Else
                jsonBody &= """keluhan"":""" & keluhan.Replace("""", "\""") & ""","
            End If

            jsonBody &= """kunjSakit"":" & If(kunjSakit, "true", "false") & ","
            jsonBody &= """sistole"":" & sistole & ","
            jsonBody &= """diastole"":" & diastole & ","
            jsonBody &= """beratBadan"":" & beratBadan.ToString(System.Globalization.CultureInfo.InvariantCulture) & ","
            jsonBody &= """tinggiBadan"":" & tinggiBadan.ToString(System.Globalization.CultureInfo.InvariantCulture) & ","
            jsonBody &= """respRate"":" & respRate & ","
            jsonBody &= """lingkarPerut"":" & lingkarPerut & ","
            jsonBody &= """heartRate"":" & heartRate
            jsonBody &= "}"

            ' 🔍 DEBUG
            'MsgBox(jsonBody)

            ' 🚀 KIRIM (pakai fungsi khusus JSON)
            Dim responseString As String = InsertDataAPIRM(jsonBody, url)

            ' 🔍 DEBUG RESPONSE
            'MsgBox(responseString)

            If String.IsNullOrEmpty(responseString) Then
                MsgBox("Response kosong dari server", MsgBoxStyle.Critical)
                Return False
            End If

            ' 📦 PARSE JSON
            Dim jsonObj As JObject = JObject.Parse(responseString)

            If jsonObj("status") Is Nothing Then
                MsgBox("Response tidak valid", MsgBoxStyle.Critical)
                Return False
            End If

            If jsonObj("status").ToString().ToLower() = "success" Then

                ' 🔥 cek response PCare
                If jsonObj("response") IsNot Nothing Then
                    Dim meta = jsonObj("response")("metaData")

                    If meta IsNot Nothing Then
                        Dim code As String = meta("code").ToString()

                        If code = "201" Then
                            Return True
                        Else
                            MsgBox("PCare gagal: " & meta("message").ToString(), MsgBoxStyle.Exclamation)
                            Return False
                        End If
                    End If
                End If

                Return True
            Else
                MsgBox("Gagal: " & jsonObj("message").ToString(), MsgBoxStyle.Critical)
                Return False
            End If

        Catch ex As Exception
            MsgBox("Error SendPCarePendaftaranV3: " & ex.Message, MsgBoxStyle.Critical)
            Return False
        End Try

    End Function

    Private Sub SavePemeriksaanGeneralis()
        Try
            Dim parameterUpdate As String = ""
            Dim statusGeneralisKepala As String = "NULL"
            Dim statusGeneralisMata As String = "NULL"
            Dim statusGeneralisHidung As String = "NULL"
            Dim statusGeneralisMulutFaring As String = "NULL"
            Dim statusGeneralisTelinga As String = "NULL"
            Dim statusGeneralisLeher As String = "NULL"
            Dim statusGeneralisThorax As String = "NULL"
            Dim statusGeneralisAbdomen As String = "NULL"
            Dim statusGeneralisEkstremitas As String = "NULL"
            Dim statusGeneralisStatusLokalis As String = "NULL"

            If CheckInputPemeriksaanGeneralis() = True Then
                ' Get Data Generalis From CheckBox
                If TextBoxStatusGeneralisKepala.Text.Length > 0 Then statusGeneralisKepala = "'" & TextBoxStatusGeneralisKepala.Text & "'"
                If TextBoxStatusGeneralisMata.Text.Length > 0 Then statusGeneralisMata = "'" & TextBoxStatusGeneralisMata.Text & "'"
                If TextBoxStatusGeneralisHidung.Text.Length > 0 Then statusGeneralisHidung = "'" & TextBoxStatusGeneralisHidung.Text & "'"
                If TextBoxStatusGeneralisMulutFaring.Text.Length > 0 Then statusGeneralisMulutFaring = "'" & TextBoxStatusGeneralisMulutFaring.Text & "'"
                If TextBoxStatusGeneralisTelinga.Text.Length > 0 Then statusGeneralisTelinga = "'" & TextBoxStatusGeneralisTelinga.Text & "'"
                If TextBoxStatusGeneralisLeher.Text.Length > 0 Then statusGeneralisLeher = "'" & TextBoxStatusGeneralisLeher.Text & "'"
                If TextBoxStatusGeneralisThorax.Text.Length > 0 Then statusGeneralisThorax = "'" & TextBoxStatusGeneralisThorax.Text & "'"
                If TextBoxStatusGeneralisAbdomen.Text.Length > 0 Then statusGeneralisAbdomen = "'" & TextBoxStatusGeneralisAbdomen.Text & "'"
                If TextBoxStatusGeneralisEkstremitas.Text.Length > 0 Then statusGeneralisEkstremitas = "'" & TextBoxStatusGeneralisEkstremitas.Text & "'"
                If TextBoxStatusGeneralisStatusLokalis.Text.Length > 0 Then statusGeneralisStatusLokalis = "'" & TextBoxStatusGeneralisStatusLokalis.Text & "'"

                If CheckSQL("SELECT * FROM TransaksiDetailGeneralis WHERE NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL") = False Then
                    ' Insert Data TransaksiDetailGeneralis
                    WriteSQL("INSERT INTO TransaksiDetailGeneralis (NoTransaksi, StatusGeneralisKepala, StatusGeneralisMata, StatusGeneralisHidung, StatusGeneralisMulutFaring, StatusGeneralisTelinga, StatusGeneralisLeher, StatusGeneralisThorax, StatusGeneralisAbdomen, StatusGeneralisEkstremitas, StatusGeneralisStatusLokalis, CreatedBy, CreatedDate) " & _
                             "VALUES('" & idTransaksi & "', " & statusGeneralisKepala & ", " & statusGeneralisMata & ", " & statusGeneralisHidung & ", " & statusGeneralisMulutFaring & ", " & statusGeneralisTelinga & ", " & statusGeneralisLeher & ", " & statusGeneralisThorax & ", " & statusGeneralisAbdomen & ", " & statusGeneralisEkstremitas & ", " & statusGeneralisStatusLokalis & ", '" & userInput & "', GETDATE())", 4)

                    MsgBox("Data berhasil disimpan.", MsgBoxStyle.Information, "Success!")
                Else
                    ' Update Data TransaksiDetailGeneralis
                    parameterUpdate = "StatusGeneralisKepala = " & statusGeneralisKepala & "," & _
                                      "StatusGeneralisMata = " & statusGeneralisMata & "," & _
                                      "StatusGeneralisHidung = " & statusGeneralisHidung & "," & _
                                      "StatusGeneralisMulutFaring = " & statusGeneralisMulutFaring & "," & _
                                      "StatusGeneralisTelinga = " & statusGeneralisTelinga & "," & _
                                      "StatusGeneralisLeher = " & statusGeneralisLeher & "," & _
                                      "StatusGeneralisThorax = " & statusGeneralisThorax & "," & _
                                      "StatusGeneralisAbdomen = " & statusGeneralisAbdomen & "," & _
                                      "StatusGeneralisEkstremitas = " & statusGeneralisEkstremitas & "," & _
                                      "StatusGeneralisStatusLokalis = " & statusGeneralisStatusLokalis & "," & _
                                      "UpdatedBy = '" & userInput & "'," & _
                                      "UpdatedDate = GETDATE()"

                    WriteSQL("UPDATE TransaksiDetailGeneralis SET " & parameterUpdate & " WHERE NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL", 4)

                    MsgBox("Data berhasil diupdate.", MsgBoxStyle.Information, "Success!")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Warning!")
        End Try
    End Sub

    Private Sub SendToApiPemFisik(ByVal noTransaksi As String, ByVal noRM As String, ByVal keadaanUmum As String, ByVal sistole As Double, ByVal diastole As Double, ByVal heartRate As Double, ByVal suhu As Double, ByVal Saturasi As Double, ByVal tinggi As Double, ByVal berat As Double, ByVal lingkarPerut As Double, ByVal imt As Double, ByVal KeteranganIMT As String, ByVal nafas As Double)
        Try
            Dim client As New Net.WebClient()

            Dim json As String = "{" & _
                 """NoRM"":""" & noRM & """," & _
                 """NoTransaksi"":""" & noTransaksi & """," & _
                 """KeadaanUmum"":""" & keadaanUmum & """," & _
                 """Sistole"":""" & sistole & """," & _
                 """Diastole"":""" & diastole & """," & _
                 """HeartRate"":""" & heartRate & """," & _
                 """Suhu"":""" & suhu & """," & _
                 """Saturasi"":""" & Saturasi & """," & _
                 """Tinggi"":""" & tinggi & """," & _
                 """Berat"":""" & berat & """," & _
                 """LingkarPerut"":""" & lingkarPerut & """," & _
                 """IMT"":""" & imt & """," & _
                 """KeteranganIMT"":""" & KeteranganIMT & """," & _
                 """Nafas"":""" & nafas & """" & _
             "}"

            Dim baseUrl As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
            Dim urlWebService As String = baseUrl & "api/statistikVital/save"
            Dim response As String = InsertDataAPIRM(json, urlWebService)

            ' --- Parse JSON response ---
            Dim result As JObject = JObject.Parse(response)

            Dim status As String = result("status").ToString()
            Dim message As String = result("message").ToString()

            Dim insertedId As String = ""
            Dim data As JObject = TryCast(result("data"), JObject)
            If data IsNot Nothing AndAlso data("id") IsNot Nothing Then
                insertedId = data("id").ToString()
            End If

            ' --- Tampilkan hasil ---
            If status = "success" Then
                MsgBox("Data berhasil dikirim ke API ERM." & vbCrLf & _
                       "Pesan: " & message & vbCrLf & _
                       "Dengan ID: " & insertedId)
            Else
                MsgBox("API mengembalikan status gagal: " & status & vbCrLf & message)
            End If

        Catch ex As Exception
            MsgBox("Gagal kirim ke API: " & ex.Message)
        End Try
    End Sub

    Private Sub SavePemeriksaanFisik()
        Try
            Dim parameterUpdate As String = ""
            Dim noTransaksi As String = idTransaksi
            Dim noRM As String = idPasien
            Dim keadaanUmum As String = GetKeadaanUmum("Medik")
            Dim sistole As Double = Val(TextBoxSistoleMedik.Text)
            Dim diastole As Double = Val(TextBoxDiastoleMedik.Text)
            Dim heartRate As Double = Val(TextBoxDetakNadiMedik.Text)
            Dim suhu As Double = Val(TextBoxSuhuMedik.Text)
            Dim saturasi As Double = Val(TextBoxSaturasiMedik.Text)
            Dim tinggi As Double = Val(TextBoxTinggiBadanMedik.Text)
            Dim berat As Double = Val(TextBoxBeratBadanMedik.Text)
            Dim lingkarPerut As Double = Val(TextBoxLingkarPerutMedik.Text)
            Dim imt As Double = Val(TextBoxIndeksMedik.Text)
            Dim keteranganIMT As String = TextBoxIndeksKeteranganMedik.Text
            Dim nafas As Double = Val(TextBoxNafasMedik.Text)

            Dim statusAPI As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'status_ws_RM'")

            If CheckInputPemeriksaanFisik() = True Then
                If CheckSQL("SELECT * FROM TransaksiDetailFisik WHERE NoTransaksi = '" & idTransaksi & "'") = False Then
                    ' Insert Data TransaksiDetailFisik
                    WriteSQL("INSERT INTO TransaksiDetailFisik (NoTransaksi, KeadaanUmum, Kesadaran, SkalaNyeri, Sistole, Diastole, HeartRate, RespiratoryRate, Suhu, Saturasi, Tinggi, Berat, LingkarPerut, IMT, KeteranganIMT, CreatedBy, CreatedDate) " & _
                             "VALUES('" & idTransaksi & "', '" & GetKeadaanUmum("Medik") & "', '" & GetKesadaran("Medik") & "', '" & TrackBarSkalaNyeriMedik.Value.ToString() & "', '" & TextBoxSistoleMedik.Text & "', '" & TextBoxDiastoleMedik.Text & "', '" & TextBoxDetakNadiMedik.Text & "', " & _
                                    "'" & TextBoxNafasMedik.Text & "', '" & TextBoxSuhuMedik.Text & "', '" & TextBoxSaturasiMedik.Text & "', '" & TextBoxTinggiBadanMedik.Text & "', '" & TextBoxBeratBadanMedik.Text & "', '" & TextBoxLingkarPerutMedik.Text & "', '" & TextBoxIndeksMedik.Text & "', '" & TextBoxIndeksKeteranganMedik.Text & "', '" & userInput & "', GETDATE())", 4)

                    If statusAPI IsNot Nothing AndAlso statusAPI = "Yes" Then
                        SendToApiPemFisik(noTransaksi, noRM, keadaanUmum, sistole, diastole, heartRate, suhu, saturasi, tinggi, berat, lingkarPerut, imt, keteranganIMT, nafas)
                    End If

                    ' Update status transaksi menjadi > Sudah dilakukan TTV
                    If jenisTransaksi = "UMUM" Or jenisTransaksi = "POLI" Then
                        WriteSQL("UPDATE TransaksiPoli SET StatusKeterangan = 'Sudah dilakukan TTV' WHERE NoUrut = '" & idTransaksi & "'", 4)
                    ElseIf jenisTransaksi = "GIGI" Then
                        WriteSQL("UPDATE TransaksiGigi SET StatusKeterangan = 'Sudah dilakukan TTV' WHERE NoUrut = '" & idTransaksi & "'", 4)
                    End If

                    ' Insert / Update Detail Waktu Transaksi (WaktuSelesaiTTV)
                    SetDetailWaktuTransaksi(idTransaksi, "WaktuSelesaiTTV", userInput)
                Else
                    ' Update Data TransaksiDetailFisik
                    parameterUpdate = "KeadaanUmum = '" & GetKeadaanUmum("Medik") & "'," & _
                                      "Kesadaran = '" & GetKesadaran("Medik") & "'," & _
                                      "SkalaNyeri = '" & TrackBarSkalaNyeriMedik.Value.ToString() & "'," & _
                                      "Sistole = '" & TextBoxSistoleMedik.Text & "'," & _
                                      "Diastole = '" & TextBoxDiastoleMedik.Text & "'," & _
                                      "HeartRate = '" & TextBoxDetakNadiMedik.Text & "'," & _
                                      "RespiratoryRate = '" & TextBoxNafasMedik.Text & "'," & _
                                      "Suhu = '" & TextBoxSuhuMedik.Text & "'," & _
                                      "Saturasi = '" & TextBoxSaturasiMedik.Text & "'," & _
                                      "Tinggi = '" & TextBoxTinggiBadanMedik.Text & "'," & _
                                      "Berat = '" & TextBoxBeratBadanMedik.Text & "'," & _
                                      "LingkarPerut = '" & TextBoxLingkarPerutMedik.Text & "'," & _
                                      "IMT = '" & TextBoxIndeksMedik.Text & "'," & _
                                      "KeteranganIMT = '" & TextBoxIndeksKeteranganMedik.Text & "'," & _
                                      "UpdatedBy = '" & userInput & "'," & _
                                      "UpdatedDate = GETDATE()"

                    WriteSQL("UPDATE TransaksiDetailFisik SET " & parameterUpdate & " WHERE NoTransaksi = '" & idTransaksi & "'", 4)

                    If statusAPI IsNot Nothing AndAlso statusAPI = "Yes" Then
                        SendToApiPemFisik(noTransaksi, noRM, keadaanUmum, sistole, diastole, heartRate, suhu, saturasi, tinggi, berat, lingkarPerut, imt, keteranganIMT, nafas)
                    End If

                End If

                If statusBPJS = True AndAlso CheckBridgingPcareActive() = True Then SaveKunjunganBPJS() ' Save PCare BPJS

                'If statusBPJS = True AndAlso CheckBridgingPcareActive() = True Then SavePendaftaranBPJS()

                Dim sql As String = "SELECT TD.NoAntreanHyu, MP.NoNIK " & _
                   "FROM TransaksiDetail TD " & _
                   "INNER JOIN MasterPasien MP ON TD.IDInternet = MP.NoRekamMedis " & _
                   "WHERE TD.NoUrut = '" & idTransaksi & "'"

                Dim tbl As DataTable = ReadSQL(sql)

                If tbl.Rows.Count = 0 Then
                    MsgBox("Data antrean tidak ditemukan", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If

                Dim nomorAntrean As String = If(IsDBNull(tbl.Rows(0)("NoAntreanHyu")), "", tbl.Rows(0)("NoAntreanHyu").ToString())
                Dim nomorNIK As String = If(IsDBNull(tbl.Rows(0)("NoNIK")), "", tbl.Rows(0)("NoNIK").ToString())

                If SendPCareDataV3(nomorNIK, nomorAntrean, "dilayani", "poli") = False Then Exit Sub

                If noKunjunganBPJS.Length > 0 Then
                    MsgBox("Data berhasil disimpan." & vbCr & vbLf & "No kunjungan PCare : " & noKunjunganBPJS & "", MsgBoxStyle.Information, "Success!")
                Else
                    MsgBox("Data berhasil disimpan.", MsgBoxStyle.Information, "Success!")
                End If

                ' UATBPJS
                ' Refresh Form Rekam Medis
                SetDataFromPendaftaran(idPasien, idTransaksi, jenisTransaksi)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Warning!")
        End Try
    End Sub

    Private Sub ButtonSetMedscape_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSetMedscape.Click
        Dim lokasi As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NoPoli'")
        Dim noAntreanHyu As String = ReadSQLNIK("SELECT NoAntreanHyu FROM TransaksiDetail WHERE NoUrut = '" & idTransaksi & "'")
        Dim tanggalFormat As String = ""
        Try
            Dim stringTanggal As String = idTransaksi.Substring(0, 8)
            Dim objTanggal As DateTime = DateTime.ParseExact(stringTanggal, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture)
            tanggalFormat = objTanggal.ToString("yyyy-MM-dd")
        Catch ex As Exception
            tanggalFormat = DateTime.Now.ToString("yyyy-MM-dd")
        End Try

        Dim urlWebService As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
        Dim url As String = urlWebService & "api/medscape-shck/ttv/" & lokasi & "/" & noAntreanHyu & "/" & tanggalFormat

        Try
            Dim jsonString As String = GetDataAPIRM(url)
            Dim jsonResult As JObject = JObject.Parse(jsonString)

            If jsonResult("code") IsNot Nothing AndAlso jsonResult("code").ToString() = "1" Then
                Dim dataObj As JObject = CType(jsonResult("data"), JObject)
                Dim name As String = dataObj("name").ToString()
                Dim examNo As String = dataObj("exam_no").ToString()

                Dim sistole As String = ""
                Dim diastole As String = ""
                Dim detakNadi As String = ""
                Dim nafas As String = ""
                Dim suhu As String = ""
                Dim saturasi As String = ""
                Dim tinggiBadan As String = ""
                Dim beratBadan As String = ""
                Dim bmi As String = ""

                Dim resultsArray As JArray = CType(dataObj("results"), JArray)

                For Each result As JObject In resultsArray
                    Dim parameter As String = result("parameter").ToString().ToLower()
                    Dim value As String = result("value").ToString()

                    Select Case parameter
                        Case "high"
                            sistole = value
                        Case "low"
                            diastole = value
                        Case "rate"
                            detakNadi = value
                        Case "tiwen"
                            suhu = value
                        Case "sp"
                            saturasi = value
                        Case "pr"
                            If detakNadi = "" Then detakNadi = value
                        Case "height"
                            tinggiBadan = value
                        Case "weight"
                            beratBadan = value
                        Case "bmi"
                            bmi = value
                    End Select
                Next

                If Not String.IsNullOrEmpty(detakNadi) AndAlso IsNumeric(detakNadi) Then
                    Dim nilaiNadi As Double = Convert.ToDouble(detakNadi)
                    nafas = Math.Round(nilaiNadi / 4).ToString()
                End If

                TextBoxSistoleMedik.Text = sistole
                TextBoxDiastoleMedik.Text = diastole
                TextBoxDetakNadiMedik.Text = detakNadi
                TextBoxSuhuMedik.Text = suhu
                TextBoxSaturasiMedik.Text = saturasi
                TextBoxTinggiBadanMedik.Text = tinggiBadan
                TextBoxBeratBadanMedik.Text = beratBadan
                TextBoxIndeksMedik.Text = bmi
                TextBoxNafasMedik.Text = nafas

                MessageBox.Show("Data TTV berhasil ditarik untuk pasien: " & name, "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                Dim errorMsg As String = "Gagal memuat data."

                If jsonResult("msg") IsNot Nothing Then
                    errorMsg = jsonResult("msg").ToString()
                ElseIf jsonResult("message") IsNot Nothing Then
                    errorMsg = jsonResult("message").ToString()
                End If

                MessageBox.Show(errorMsg, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan sistem: " & ex.Message, "Error Parsing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'NEW HYU
    Public Function SendPCareDataV3( _
            ByVal patient_nik As String, _
            ByVal queueNumber As String, _
            ByVal queueStatus As String, _
            Optional ByVal queueStage As String = "" _
        ) As Boolean

        Try
            ' 🔒 Validasi wajib
            If String.IsNullOrEmpty(patient_nik) Then
                MessageBox.Show("NIK tidak boleh kosong", "Validasi")
                Return False
            End If

            If String.IsNullOrEmpty(queueNumber) Then
                MessageBox.Show("Queue Number tidak boleh kosong", "Validasi")
                Return False
            End If

            If String.IsNullOrEmpty(queueStatus) Then
                MessageBox.Show("Queue Status tidak boleh kosong", "Validasi")
                Return False
            End If

            ' 🔗 Ambil config
            Dim urlWebService As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
            Dim Loc As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NoPoli'")

            If String.IsNullOrEmpty(Loc) Then
                MessageBox.Show("Kode Klinik tidak ditemukan di config", "Error")
                Return False
            End If

            Dim url As String = urlWebService & "api/antrian/update-status"

            ' 🔥 Build form-urlencoded
            Dim postData As String = ""

            postData &= "clinic_code=" & Uri.EscapeDataString(Loc.Trim())
            postData &= "&patient_nik=" & Uri.EscapeDataString(patient_nik.Trim())
            postData &= "&queue_number=" & Uri.EscapeDataString(queueNumber.Trim())
            postData &= "&queue_status=" & Uri.EscapeDataString(queueStatus.Trim())

            If Not String.IsNullOrEmpty(queueStage) Then
                postData &= "&queue_stage=" & Uri.EscapeDataString(queueStage.Trim())
            End If

            'MsgBox(postData)

            ' 🚀 Call API (error sudah ditangani di sini)
            Dim responseString As String = InsertDataAPIRMUrlEncode(postData, url)

            If String.IsNullOrEmpty(responseString) Then
                MessageBox.Show("Response kosong dari server", "Error")
                Return False
            End If

            ' 📦 Parse JSON
            Dim jsonObj As JObject = JObject.Parse(responseString)

            If jsonObj("status") Is Nothing Then
                MessageBox.Show("Format response tidak valid", "Error")
                Return False
            End If

            If jsonObj("status").ToString().ToLower() = "success" Then
                Return True
            Else
                Dim msg As String = If(jsonObj("message") IsNot Nothing, jsonObj("message").ToString(), "Unknown error")
                MessageBox.Show("Gagal update: " & msg, "Error")
                Return False
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error")
            Return False
        End Try

    End Function

    'NEW HYU
    Public Sub SavePendaftaranBPJS()

        Try
            Dim noUrut As String = idTransaksi

            If String.IsNullOrEmpty(noUrut) Then
                MsgBox("No Urut BPJS kosong", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            Dim sql As String = ""
            sql &= "SELECT "
            sql &= "MPB.KdProviderPst, "
            sql &= "MPB.NoKartu, "
            sql &= "TD.TanggalTransaksi, "
            sql &= "MPT.KodeBPJS, "
            sql &= "TD.KeluhanUtama, "
            sql &= "TDF.Sistole, "
            sql &= "TDF.Diastole, "
            sql &= "TDF.Berat, "
            sql &= "TDF.Tinggi, "
            sql &= "TDF.RespiratoryRate, "
            sql &= "TDF.LingkarPerut, "
            sql &= "TDF.HeartRate "
            sql &= "FROM TransaksiDetail TD "
            sql &= "LEFT JOIN TransaksiDetailFisik TDF ON TD.NoUrut = TDF.NoTransaksi "
            sql &= "LEFT JOIN MasterPasien MP ON TD.IDInternet = MP.NoRekamMedis "
            sql &= "LEFT JOIN MasterPasienBPJS MPB ON MP.NoKartuBPJS = MPB.NoKartu "
            sql &= "INNER JOIN MasterPoliTujuan MPT ON TD.JenisPoli = MPT.NamaPoli "
            sql &= "WHERE TD.NoUrut = '" & noUrut & "' "
            sql &= "AND TD.JenisPenagihan = 'BPJS' "

            Dim tbl As DataTable = ReadSQL(sql)

            If tbl.Rows.Count = 0 Then
                MsgBox("Data BPJS tidak ditemukan", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            Dim row As DataRow = tbl.Rows(0)

            ' 🔥 AMBIL DATA
            Dim kdProvider As String = If(IsDBNull(row("KdProviderPst")), "", row("KdProviderPst").ToString())
            Dim noKartu As String = If(IsDBNull(row("NoKartu")), "", row("NoKartu").ToString())

            Dim tglDaftar As String = ""
            If Not IsDBNull(row("TanggalTransaksi")) Then
                tglDaftar = Format(CDate(row("TanggalTransaksi")), "dd-MM-yyyy")
            End If

            Dim kdPoli As String = If(IsDBNull(row("KodeBPJS")), "", row("KodeBPJS").ToString())
            Dim keluhan As String = If(IsDBNull(row("KeluhanUtama")), "Keluhan tidak diisi", row("KeluhanUtama").ToString())

            ' 🔥 CONVERT NUMERIC
            Dim sistole As Integer = If(IsDBNull(row("Sistole")), 0, CInt(row("Sistole")))
            Dim diastole As Integer = If(IsDBNull(row("Diastole")), 0, CInt(row("Diastole")))
            Dim berat As Double = If(IsDBNull(row("Berat")), 0, CDbl(row("Berat")))
            Dim tinggi As Double = If(IsDBNull(row("Tinggi")), 0, CDbl(row("Tinggi")))
            Dim rr As Integer = If(IsDBNull(row("RespiratoryRate")), 0, CInt(row("RespiratoryRate")))
            Dim lp As Integer = If(IsDBNull(row("LingkarPerut")), 0, CInt(row("LingkarPerut")))
            Dim hr As Integer = If(IsDBNull(row("HeartRate")), 0, CInt(row("HeartRate")))

            ' 🔒 VALIDASI WAJIB
            If noKartu = "" Then
                MsgBox("No Kartu BPJS kosong", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            If kdPoli = "" Then
                MsgBox("Kode Poli BPJS kosong", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            If kdProvider = "" Then
                MsgBox("Kode Provider kosong", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            ' 🔍 DEBUG
            'MsgBox("Poli: " & kdPoli & vbCrLf & "Provider: " & kdProvider)

            ' 🚀 KIRIM
            Dim result As Boolean = SendPCarePendaftaranV3( _
                kdProviderPeserta:=kdProvider, _
                noKartu:=noKartu, _
                tglDaftar:=tglDaftar, _
                kdPoli:=kdPoli, _
                kdTkp:="10", _
                keluhan:=keluhan, _
                kunjSakit:=True, _
                sistole:=sistole, _
                diastole:=diastole, _
                beratBadan:=berat, _
                tinggiBadan:=tinggi, _
                respRate:=rr, _
                lingkarPerut:=lp, _
                heartRate:=hr _
            )

            If result = False Then
                MsgBox("Gagal kirim ke PCare", MsgBoxStyle.Critical)
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox("Error SavePendaftaranBPJS: " & ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub SavePemeriksaanAwal()
        Try
            Dim parameterUpdate As String = ""
            Dim parameterUpdateFisik As String = ""
            Dim parameterKuisioner As String = ""

            If CheckInputPemeriksaanAwal() = True Then
                ' Input Pemeriksaan Fisik
                If CheckSQL("SELECT * FROM TransaksiDetailFisik WHERE NoTransaksi = '" & idTransaksi & "'") = False Then
                    ' Insert Data TransaksiDetailFisik
                    WriteSQL("INSERT INTO TransaksiDetailFisik (NoTransaksi, KeadaanUmum, Kesadaran, SkalaNyeri, Sistole, Diastole, HeartRate, RespiratoryRate, Suhu, Saturasi, Tinggi, Berat, LingkarPerut, IMT, KeteranganIMT, CreatedBy, CreatedDate) " & _
                             "VALUES('" & idTransaksi & "', '" & GetKeadaanUmum("Pemeriksaan Awal") & "', '" & GetKesadaran("Pemeriksaan Awal") & "', '" & TrackBarSkalaNyeriPemeriksaanAwal.Value.ToString() & "', '" & TextBoxSistolePemeriksaanAwal.Text & "', '" & TextBoxDiastolePemeriksaanAwal.Text & "', '" & TextBoxDetakNadiPemeriksaanAwal.Text & "', " & _
                                    "'" & TextBoxNafasPemeriksaanAwal.Text & "', '" & TextBoxSuhuPemeriksaanAwal.Text & "', '" & TextBoxSaturasiPemeriksaanAwal.Text & "', '" & TextBoxTinggiBadanPemeriksaanAwal.Text & "', '" & TextBoxBeratBadanPemeriksaanAwal.Text & "', '" & TextBoxLingkarPerutPemeriksaanAwal.Text & "', '" & TextBoxIndeksPemeriksaanAwal.Text & "', '" & TextBoxIndeksKeteranganPemeriksaanAwal.Text & "', '" & userInput & "', GETDATE())", 4)

                    ' Update status transaksi menjadi > Sudah dilakukan TTV
                    If jenisTransaksi = "UMUM" Or jenisTransaksi = "POLI" Then
                        WriteSQL("UPDATE TransaksiPoli SET StatusKeterangan = 'Sudah dilakukan TTV' WHERE NoUrut = '" & idTransaksi & "'", 4)
                    ElseIf jenisTransaksi = "GIGI" Then
                        WriteSQL("UPDATE TransaksiGigi SET StatusKeterangan = 'Sudah dilakukan TTV' WHERE NoUrut = '" & idTransaksi & "'", 4)
                    End If

                    ' Insert / Update Detail Waktu Transaksi (WaktuSelesaiTTV)
                    SetDetailWaktuTransaksi(idTransaksi, "WaktuSelesaiTTV", userInput)
                Else
                    ' Update Data TransaksiDetailFisik
                    parameterUpdateFisik = "KeadaanUmum = '" & GetKeadaanUmum("Pemeriksaan Awal") & "'," & _
                                           "Kesadaran = '" & GetKesadaran("Pemeriksaan Awal") & "'," & _
                                           "SkalaNyeri = '" & TrackBarSkalaNyeriPemeriksaanAwal.Value.ToString() & "'," & _
                                           "Sistole = '" & TextBoxSistolePemeriksaanAwal.Text & "'," & _
                                           "Diastole = '" & TextBoxDiastolePemeriksaanAwal.Text & "'," & _
                                           "HeartRate = '" & TextBoxDetakNadiPemeriksaanAwal.Text & "'," & _
                                           "RespiratoryRate = '" & TextBoxNafasPemeriksaanAwal.Text & "'," & _
                                           "Suhu = '" & TextBoxSuhuPemeriksaanAwal.Text & "'," & _
                                           "Saturasi = '" & TextBoxSaturasiPemeriksaanAwal.Text & "'," & _
                                           "Tinggi = '" & TextBoxTinggiBadanPemeriksaanAwal.Text & "'," & _
                                           "Berat = '" & TextBoxBeratBadanPemeriksaanAwal.Text & "'," & _
                                           "LingkarPerut = '" & TextBoxLingkarPerutPemeriksaanAwal.Text & "'," & _
                                           "IMT = '" & TextBoxIndeksPemeriksaanAwal.Text & "'," & _
                                           "KeteranganIMT = '" & TextBoxIndeksKeteranganPemeriksaanAwal.Text & "'," & _
                                           "UpdatedBy = '" & userInput & "'," & _
                                           "UpdatedDate = GETDATE()"

                    WriteSQL("UPDATE TransaksiDetailFisik SET " & parameterUpdateFisik & " WHERE NoTransaksi = '" & idTransaksi & "'", 4)
                End If

                parameterKuisioner = GetDataKuisioner()
                parameterUpdate = "PemeriksaanAwal = 1," & _
                                  "PemeriksaanAwalDate = GETDATE()," & _
                                  "PemeriksaanAwalBy = '" & userInput & "'," & _
                                  "KeluhanUtama = '" & TextBoxKeluhanUtamaPemeriksaanAwal.Text & "'," & _
                                  "KeluhanTambahan = '" & TextBoxKeluhanTambahanPemeriksaanAwal.Text & "'"

                ' Update tabel TransaksiDetail
                WriteSQL("UPDATE TransaksiDetail SET " & parameterKuisioner & "," & parameterUpdate & " WHERE NoUrut = '" & idTransaksi & "'", 4)

                ' Save riwayat penyakit pasien
                Dim parameterUpdatePasien As String = "RiwayatPenyakitDahulu = '" & TextBoxRiwayatPenyakitDahuluPemeriksaanAwal.Text & "'," & _
                                                      "RiwayatPenyakitKeluarga = '" & TextBoxRiwayatPenyakitKeluargaPemeriksaanAwal.Text & "'," & _
                                                      "RiwayatKebiasaan = '" & TextBoxRiwayatKebiasaanPemeriksaanAwal.Text & "'"

                WriteSQL("UPDATE MasterPasien SET " & parameterUpdatePasien & " WHERE NoRekamMedis = '" & idPasien & "'", 4)

                ' Load Ulang data
                SetDataFromPendaftaran(idPasien, idTransaksi, jenisTransaksi)

                MsgBox("Data berhasil disimpan.", MsgBoxStyle.Information, "Success!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Function GetAnamnesaPasien(ByVal rowDetailTransaksi As DataRow) As String
        Dim anamnesaPasien As String = ""
        Dim keluhanTambahan As String = ""
        Dim riwayatPenyakitSekarang As String = ""
        Dim riwayatPenggunaanObat As String = ""
        'Dim riwayatPenyakitDahulu As String = ""
        'Dim riwayatPenyakitKeluarga As String = ""
        'Dim riwayatKebiasaan As String = ""

        ' Keluhan Tambahan
        If IsDBNull(rowDetailTransaksi("KeluhanTambahan")) = False AndAlso rowDetailTransaksi("KeluhanTambahan") <> "" Then
            keluhanTambahan = rowDetailTransaksi("KeluhanTambahan") & " | "
        End If

        ' Riwayat Penyakit Sekarang
        If IsDBNull(rowDetailTransaksi("RiwayatPenyakitSekarang")) = False AndAlso rowDetailTransaksi("RiwayatPenyakitSekarang") <> "" Then
            riwayatPenyakitSekarang = "RPS: " & rowDetailTransaksi("RiwayatPenyakitSekarang") & " | "
        End If

        ' Riwayat Penggunaan Obat
        If IsDBNull(rowDetailTransaksi("RiwayatPenggunaanObat")) = False AndAlso rowDetailTransaksi("RiwayatPenggunaanObat") <> "" Then
            riwayatPenggunaanObat = "RPO: " & rowDetailTransaksi("RiwayatPenggunaanObat") & " | "
        End If

        '' Riwayat Penyakit Dahulu
        'If IsDBNull(rowDetailTransaksi("RiwayatPenyakitDahulu")) = False Then
        '    riwayatPenyakitDahulu = "Riwayat Penyakit Dahulu: " & rowDetailTransaksi("RiwayatPenyakitDahulu") & " | "
        'End If

        '' Riwayat Penyakit Keluarga
        'If IsDBNull(rowDetailTransaksi("RiwayatPenyakitKeluarga")) = False Then
        '    riwayatPenyakitKeluarga = "Riwayat Penyakit Keluarga: " & rowDetailTransaksi("RiwayatPenyakitKeluarga") & " | "
        'End If

        '' Riwayat Kebiasaan
        'If IsDBNull(rowDetailTransaksi("RiwayatKebiasaan")) = False Then
        '    riwayatKebiasaan = "Riwayat Kebiasaan: " & rowDetailTransaksi("RiwayatKebiasaan") & " | "
        'End If

        ' Set Anamnesa
        anamnesaPasien = keluhanTambahan & riwayatPenyakitSekarang & riwayatPenggunaanObat

        Return Strings.Left(anamnesaPasien, anamnesaPasien.Length - 2)
    End Function

    'NEW VER 1
    'Private Sub SaveKunjunganBPJS()
    '    If CheckVariabelPCare() = True Then
    '        Dim endpointPostKunjungan As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'api_endpoint_post_kunjungan_pcare'")
    '        Dim uri As String = urlPcare + endpointPostKunjungan

    '        Dim parameterKunjunganBPJS As String = ""
    '        Dim kodeDiagnosa As String = ""
    '        Dim paramRujukLanjut As String = ""
    '        Dim paramNoKunjungan As String = ""
    '        Dim statusTransaksi As String = ""

    '        Dim queryDetailTransaksi As New StringBuilder()

    '        queryDetailTransaksi.AppendLine("SELECT *")
    '        queryDetailTransaksi.AppendLine("FROM TransaksiDetail a")
    '        queryDetailTransaksi.AppendLine("     LEFT JOIN TransaksiDetailfisik b ON a.NoUrut = b.NoTransaksi")
    '        queryDetailTransaksi.AppendLine("WHERE a.NoUrut = '" & idTransaksi & "'")

    '        ' Set Transaksi Detail
    '        Dim tblDetailTransaksi As DataTable = ReadSQL(queryDetailTransaksi.ToString())
    '        Dim rowDetailTransaksi As DataRow = tblDetailTransaksi.Rows(0)

    '        ' Get Nomor Poli
    '        Dim kondisiPoliSakit As String = ""
    '        If rowDetailTransaksi("JenisKunjungan").ToString() = "Kunjungan Sakit" Then
    '            kondisiPoliSakit = " AND PoliSakit = 1"
    '        ElseIf rowDetailTransaksi("JenisKunjungan").ToString() = "Kunjungan Sehat" Then
    '            kondisiPoliSakit = " AND PoliSakit = 0"
    '        End If
    '        Dim kdPoli As String = ReadSQLNIK("SELECT KodeBPJS FROM MasterPoliTujuan WHERE NamaPoli = '" & rowDetailTransaksi("JenisPoli") & "'" & kondisiPoliSakit)

    '        ' Get Kesadaran
    '        Dim kodeKesadaran As String = ReadSQLNIK("SELECT KodeBPJS FROM MasterKesadaran WHERE NamaKesadaran = '" & rowDetailTransaksi("Kesadaran") & "'")

    '        ' Get Status Pulang
    '        Dim statusPulang As String = ReadSQLNIK("SELECT KodeStatusPulang FROM MasterStatusPulang WHERE NamaStatusPulang = '" & rowDetailTransaksi("StatusPulang") & "'")

    '        ' Inisialisasi Variabel BPJS
    '        Dim prognosa As String = ReadSQLNIK("SELECT KodePrognosa FROM TransaksiDetailPrognosa WHERE NoTransaksi = '" & idTransaksi & "'")
    '        Dim anamnesa As String = GetAnamnesaPasien(rowDetailTransaksi) ' Belum di set (Berisi anamnesa pasien)
    '        Dim terapiObat As String = "Tidak Ada" ' Belum di set (Berisi resep pasien)
    '        Dim terapiNonObat As String = "Tidak Ada" ' Belum di set (Berisi edukasi pasien)
    '        Dim bmhp As String = "-" ' Belum di set (Berisi bahan habis pakai)

    '        If IsDBNull(rowDetailTransaksi("Resep")) = False And rowDetailTransaksi("Resep").ToString.Trim <> "" Then terapiObat = rowDetailTransaksi("Resep")
    '        If IsDBNull(rowDetailTransaksi("Edukasi")) = False And rowDetailTransaksi("Edukasi").ToString.Trim <> "" Then terapiNonObat = rowDetailTransaksi("Edukasi")

    '        ' Get Alergi
    '        Dim alergiMakan As String = GetKodeAlergiBridgingPCare("Makanan", idPasien)
    '        Dim alergiUdara As String = GetKodeAlergiBridgingPCare("Udara", idPasien)
    '        Dim alergiObat As String = GetKodeAlergiBridgingPCare("Obat", idPasien)

    '        ' Get Kode Dokter
    '        Dim kodeDokter As String = ""
    '        If jenisTransaksi = "UMUM" Or jenisTransaksi = "POLI" Then
    '            kodeDokter = ReadSQLNIK("SELECT MasterDokter.KodeBridgingPCare FROM TransaksiPoli " & _
    '                                    "LEFT JOIN MasterDokter ON TransaksiPoli.KodeDokter = MasterDokter.NoNIP " & _
    '                                    "WHERE TransaksiPoli.NoUrut = '" & idTransaksi & "'")
    '        ElseIf jenisTransaksi = "GIGI" Then
    '            kodeDokter = ReadSQLNIK("SELECT MasterDokter.KodeBridgingPCare FROM TransaksiGigi " & _
    '                                    "LEFT JOIN MasterDokter ON TransaksiGigi.KodeDokter = MasterDokter.NoNIP " & _
    '                                    "WHERE TransaksiGigi.NoUrut = '" & idTransaksi & "'")
    '        End If

    '        ' Tgl Kunjungan
    '        Dim tglKunjungan As Date = rowDetailTransaksi("TanggalTransaksi")

    '        ' Get Diagnosa
    '        Dim tblsDiagnosa As DataTable = ReadSQL("SELECT * FROM TransaksiDetailDiagnosa WHERE NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL")

    '        If tblsDiagnosa.Rows.Count > 0 Then
    '            For Each trowDiagnosa As DataRow In tblsDiagnosa.Rows
    '                If trowDiagnosa("JenisDiagnosa") = "Diagnosa Utama" Then
    '                    kodeDiagnosa = kodeDiagnosa & """kdDiag1"": """ & trowDiagnosa("KodeDiagnosa") & ""","
    '                ElseIf trowDiagnosa("JenisDiagnosa") = "Diagnosa Sekunder" Then
    '                    kodeDiagnosa = kodeDiagnosa & """kdDiag2"": """ & trowDiagnosa("KodeDiagnosa") & ""","
    '                ElseIf trowDiagnosa("JenisDiagnosa") = "Diagnosa Komplikasi" Then
    '                    kodeDiagnosa = kodeDiagnosa & """kdDiag3"": """ & trowDiagnosa("KodeDiagnosa") & ""","
    '                End If
    '            Next
    '        End If

    '        ' Get Status Insert / Update 
    '        If noKunjunganBPJS.Length = 0 Then
    '            paramNoKunjungan = """noKunjungan"" : null,"
    '            statusTransaksi = "INSERT"
    '        Else
    '            paramNoKunjungan = """noKunjungan"" : """ & noKunjunganBPJS & ""","
    '            statusTransaksi = "UPDATE"
    '        End If

    '        ' Get Rujukan Pasien
    '        Dim tblsRujukan As DataTable = ReadSQL("SELECT * FROM TransaksiDetailRujukan WHERE NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL")
    '        Dim jenisRujukan As String = ""
    '        Dim kdKhusus As String = ""
    '        Dim kdSubSpesialis As String = ""
    '        Dim catatan As String = ""
    '        Dim kdSubSpesialis1 As String = ""
    '        Dim kdSarana As String = ""
    '        Dim kdTacc As String = ""
    '        Dim alasanTacc As String = ""
    '        Dim kodePPK As String = ""
    '        Dim tglRujukan As String = ""

    '        If tblsRujukan.Rows.Count > 0 Then
    '            For Each trowRujukan As DataRow In tblsRujukan.Rows
    '                jenisRujukan = trowRujukan("JenisRujukan")
    '                Dim convertTglRujukan As Date = CType(trowRujukan("TanggalRujukan"), Date)
    '                tglRujukan = convertTglRujukan.ToString("dd-MM-yyyy")
    '                kodePPK = trowRujukan("KodePPK")

    '                If jenisRujukan = "Kondisi Khusus" Then
    '                    ' Rujukan Kondisi Khusus
    '                    kdKhusus = """kdKhusus"": """ & trowRujukan("KodeKhusus") & ""","

    '                    If trowRujukan("KodeSubSpesialis") <> "" Then
    '                        kdSubSpesialis = """kdSubSpesialis"": """ & trowRujukan("KodeSubSpesialis") & ""","
    '                    Else
    '                        kdSubSpesialis = """kdSubSpesialis"": null,"
    '                    End If

    '                    catatan = """catatan"": """ & Replace(trowRujukan("Catatan"), vbCrLf, " ") & """ } },"
    '                ElseIf jenisRujukan = "Spesialis" Then
    '                    ' Rujukan Spesialis
    '                    kdSubSpesialis1 = """kdSubSpesialis1"": """ & trowRujukan("KodeSubSpesialis") & ""","

    '                    If trowRujukan("KodeSarana") <> "" Then
    '                        kdSarana = """kdSarana"": """ & trowRujukan("KodeSarana") & """ },"
    '                    Else
    '                        kdSarana = """kdSarana"": null },"
    '                    End If
    '                End If

    '                ' Set Status TACC Rujukan
    '                If trowRujukan("KodeTACC").ToString <> "" Then
    '                    kdTacc = """kdTacc"": " & trowRujukan("KodeTACC") & ","
    '                    alasanTacc = """alasanTacc"": """ & trowRujukan("AlasanTACC") & """"
    '                Else
    '                    kdTacc = """kdTacc"": -1,"
    '                    alasanTacc = """alasanTacc"": null"
    '                End If
    '            Next
    '        End If

    '        ' Get Status Rujukan / Non Rujukan
    '        If statusPulang = "3" Then
    '            paramRujukLanjut = """rujukLanjut"": { " & _
    '                                """tglEstRujuk"": """"," & _
    '                                """kdppk"": """"," & _
    '                                """subSpesialis"": null," & _
    '                                """khusus"": null }," & _
    '                               """kdTacc"": -1," & _
    '                               """alasanTacc"": null" & _
    '                               "}"
    '        ElseIf statusPulang = "4" Then
    '            If jenisRujukan = "Kondisi Khusus" Then
    '                paramRujukLanjut = """rujukLanjut"": { " & _
    '                                    """tglEstRujuk"": """ & tglRujukan & """," & _
    '                                    """kdppk"": """ & kodePPK & """," & _
    '                                    """subSpesialis"": null," & _
    '                                    """khusus"": { " & _
    '                                        kdKhusus & _
    '                                        kdSubSpesialis & _
    '                                        catatan & _
    '                                    kdTacc & _
    '                                    alasanTacc & _
    '                                  "}"
    '            ElseIf jenisRujukan = "Spesialis" Then
    '                paramRujukLanjut = """rujukLanjut"": { " & _
    '                                    """kdppk"": """ & kodePPK & """," & _
    '                                    """tglEstRujuk"": """ & tglRujukan & """," & _
    '                                    """subSpesialis"": { " & _
    '                                        kdSubSpesialis1 & _
    '                                        kdSarana & _
    '                                    """khusus"": null }," & _
    '                                    kdTacc & _
    '                                    alasanTacc & _
    '                                  "}"
    '            End If
    '        End If

    '        parameterKunjunganBPJS = "{" & _
    '                                  paramNoKunjungan & _
    '                                  """noKartu"" : """ & noBPJS & """," & _
    '                                  """tglDaftar"" : """ & Format(tglKunjungan, "dd-MM-yyyy") & """," & _
    '                                  """kdPoli"" : """ & kdPoli & """," & _
    '                                  """keluhan"": """ & rowDetailTransaksi("KeluhanUtama") & """," & _
    '                                  """kdSadar"": """ & kodeKesadaran & """," & _
    '                                  """sistole"": " & rowDetailTransaksi("Sistole") & "," & _
    '                                  """diastole"": " & rowDetailTransaksi("Diastole") & "," & _
    '                                  """beratBadan"": " & rowDetailTransaksi("Berat") & "," & _
    '                                  """tinggiBadan"": " & rowDetailTransaksi("Tinggi") & "," & _
    '                                  """suhu"": " & rowDetailTransaksi("Suhu") & "," & _
    '                                  """respRate"": " & rowDetailTransaksi("RespiratoryRate") & "," & _
    '                                  """heartRate"": " & rowDetailTransaksi("HeartRate") & "," & _
    '                                  """lingkarPerut"": " & rowDetailTransaksi("LingkarPerut") & "," & _
    '                                  """terapiObat"": """ & terapiObat & """," & _
    '                                  """terapiNonObat"": """ & terapiNonObat & """," & _
    '                                  """anamnesa"": """ & anamnesa & """," & _
    '                                  """alergiMakan"": """ & alergiMakan & """," & _
    '                                  """alergiUdara"": """ & alergiUdara & """," & _
    '                                  """alergiObat"": """ & alergiObat & """," & _
    '                                  """kdPrognosa"": """ & prognosa & """," & _
    '                                  """bmhp"": """ & bmhp & """," & _
    '                                  """kdStatusPulang"": """ & statusPulang & """," & _
    '                                  """tglPulang"": """ & Format(tglKunjungan, "dd-MM-yyyy") & """," & _
    '                                  """kdDokter"": """ & kodeDokter & """," & _
    '                                  kodeDiagnosa & _
    '                                  """kdPoliRujukInternal"": null," & _
    '                                  paramRujukLanjut

    '        ' Insert / update data ke pcare BPJS
    '        Dim jsonString As String = ""
    '        If statusTransaksi = "INSERT" Then
    '            jsonString = PostDataFromPcare(parameterKunjunganBPJS, uri, "POST")
    '        ElseIf statusTransaksi = "UPDATE" Then
    '            jsonString = PostDataFromPcare(parameterKunjunganBPJS, uri, "PUT")
    '        End If

    '        Dim jsonObject As JObject = JObject.Parse(jsonString)
    '        Dim responseArray As New JArray()

    '        ' Mengakses nilai "metaData"
    '        Dim metaDataObj As JObject = jsonObject("metaData")
    '        Dim codeMetaData As Integer = Convert.ToInt32(metaDataObj("code").ToString)

    '        ' Mengakses nilai "response"
    '        Dim messageResponse As String = ""
    '        If jsonObject("response").Type = JTokenType.Array Then
    '            responseArray = DirectCast(jsonObject("response"), JArray)
    '        ElseIf jsonObject("response").Type = JTokenType.String Then
    '            messageResponse = jsonObject("response").ToString()
    '        End If

    '        Select Case codeMetaData
    '            Case 200, 201, 204
    '                If statusTransaksi = "INSERT" Then
    '                    For Each responseArrayObj As JObject In responseArray
    '                        noKunjunganBPJS = responseArrayObj("message").ToString()
    '                    Next

    '                    ' Insert No Kunjungan BPJS
    '                    WriteSQL("UPDATE TransaksiDetail SET NoKunjunganBPJS = '" & noKunjunganBPJS & "' WHERE NoUrut = '" & idTransaksi & "'", 4)
    '                ElseIf statusTransaksi = "UPDATE" Then
    '                    ' Skip
    '                End If
    '            Case Else
    '                Dim errorMessage As String = ""

    '                If jsonObject("response").Type = JTokenType.Array Then
    '                    For Each responseArrayObj As JObject In responseArray
    '                        errorMessage = errorMessage & "- " & responseArrayObj("field").ToString() & " : " & responseArrayObj("message").ToString() & vbCrLf
    '                    Next
    '                End If

    '                MsgBox("Eror BPJS : " & vbCrLf & errorMessage, MsgBoxStyle.Exclamation, "Error!")

    '                Exit Sub
    '        End Select
    '    Else

    '    End If
    'End Sub

    'NEW VER 2
    Private Sub SaveKunjunganBPJS()
        Try
            If CheckVariabelPCare() = True Then
                Dim endpointPostKunjungan As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'api_endpoint_post_kunjungan_pcare'")
                Dim uri As String = urlPcare + endpointPostKunjungan

                Dim parameterKunjunganBPJS As String = ""
                Dim kodeDiagnosa As String = ""
                Dim paramRujukLanjut As String = ""
                Dim paramNoKunjungan As String = ""
                Dim statusTransaksi As String = ""

                Dim queryDetailTransaksi As New StringBuilder()

                queryDetailTransaksi.AppendLine("SELECT *")
                queryDetailTransaksi.AppendLine("FROM TransaksiDetail a")
                queryDetailTransaksi.AppendLine("     LEFT JOIN TransaksiDetailfisik b ON a.NoUrut = b.NoTransaksi")
                queryDetailTransaksi.AppendLine("WHERE a.NoUrut = '" & idTransaksi & "'")

                ' Set Transaksi Detail
                Dim tblDetailTransaksi As DataTable = ReadSQL(queryDetailTransaksi.ToString())
                Dim rowDetailTransaksi As DataRow = tblDetailTransaksi.Rows(0)

                ' Get Nomor Poli
                Dim kondisiPoliSakit As String = ""
                If rowDetailTransaksi("JenisKunjungan").ToString() = "Kunjungan Sakit" Then
                    kondisiPoliSakit = " AND PoliSakit = 1"
                ElseIf rowDetailTransaksi("JenisKunjungan").ToString() = "Kunjungan Sehat" Then
                    kondisiPoliSakit = " AND PoliSakit = 0"
                End If
                Dim kdPoli As String = ReadSQLNIK("SELECT KodeBPJS FROM MasterPoliTujuan WHERE NamaPoli = '" & rowDetailTransaksi("JenisPoli") & "'" & kondisiPoliSakit)

                ' Get Kesadaran
                Dim kodeKesadaran As String = ReadSQLNIK("SELECT KodeBPJS FROM MasterKesadaran WHERE NamaKesadaran = '" & rowDetailTransaksi("Kesadaran") & "'")

                ' Get Status Pulang
                Dim statusPulang As String = ReadSQLNIK("SELECT KodeStatusPulang FROM MasterStatusPulang WHERE NamaStatusPulang = '" & rowDetailTransaksi("StatusPulang") & "'")

                ' Inisialisasi Variabel BPJS
                Dim prognosa As String = ReadSQLNIK("SELECT KodePrognosa FROM TransaksiDetailPrognosa WHERE NoTransaksi = '" & idTransaksi & "'")
                Dim anamnesa As String = GetAnamnesaPasien(rowDetailTransaksi) ' Belum di set (Berisi anamnesa pasien)
                Dim terapiObat As String = "Tidak Ada" ' Belum di set (Berisi resep pasien)
                Dim terapiNonObat As String = "Tidak Ada" ' Belum di set (Berisi edukasi pasien)
                Dim bmhp As String = "-" ' Belum di set (Berisi bahan habis pakai)

                If IsDBNull(rowDetailTransaksi("Resep")) = False And rowDetailTransaksi("Resep").ToString.Trim <> "" Then terapiObat = rowDetailTransaksi("Resep")
                If IsDBNull(rowDetailTransaksi("Edukasi")) = False And rowDetailTransaksi("Edukasi").ToString.Trim <> "" Then terapiNonObat = rowDetailTransaksi("Edukasi")

                ' Get Alergi
                Dim alergiMakan As String = GetKodeAlergiBridgingPCare("Makanan", idPasien)
                Dim alergiUdara As String = GetKodeAlergiBridgingPCare("Udara", idPasien)
                Dim alergiObat As String = GetKodeAlergiBridgingPCare("Obat", idPasien)

                ' Get Kode Dokter
                Dim kodeDokter As String = ""
                If jenisTransaksi = "UMUM" Or jenisTransaksi = "POLI" Then
                    kodeDokter = ReadSQLNIK("SELECT MasterDokter.KodeBridgingPCare FROM TransaksiPoli " & _
                                            "LEFT JOIN MasterDokter ON TransaksiPoli.KodeDokter = MasterDokter.NoNIP " & _
                                            "WHERE TransaksiPoli.NoUrut = '" & idTransaksi & "'")
                ElseIf jenisTransaksi = "GIGI" Then
                    kodeDokter = ReadSQLNIK("SELECT MasterDokter.KodeBridgingPCare FROM TransaksiGigi " & _
                                            "LEFT JOIN MasterDokter ON TransaksiGigi.KodeDokter = MasterDokter.NoNIP " & _
                                            "WHERE TransaksiGigi.NoUrut = '" & idTransaksi & "'")
                End If

                ' Tgl Kunjungan
                Dim tglKunjungan As Date = rowDetailTransaksi("TanggalTransaksi")

                ' Get Diagnosa
                Dim tblsDiagnosa As DataTable = ReadSQL("SELECT * FROM TransaksiDetailDiagnosa WHERE NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL")

                If tblsDiagnosa.Rows.Count > 0 Then
                    For Each trowDiagnosa As DataRow In tblsDiagnosa.Rows
                        If trowDiagnosa("JenisDiagnosa") = "Diagnosa Utama" Then
                            kodeDiagnosa = kodeDiagnosa & """kdDiag1"": """ & trowDiagnosa("KodeDiagnosa") & ""","
                        ElseIf trowDiagnosa("JenisDiagnosa") = "Diagnosa Sekunder" Then
                            kodeDiagnosa = kodeDiagnosa & """kdDiag2"": """ & trowDiagnosa("KodeDiagnosa") & ""","
                        ElseIf trowDiagnosa("JenisDiagnosa") = "Diagnosa Komplikasi" Then
                            kodeDiagnosa = kodeDiagnosa & """kdDiag3"": """ & trowDiagnosa("KodeDiagnosa") & ""","
                        End If
                    Next
                End If

                ' Get Status Insert / Update 
                If noKunjunganBPJS.Length = 0 Then
                    paramNoKunjungan = """noKunjungan"" : null,"
                    statusTransaksi = "INSERT"
                Else
                    paramNoKunjungan = """noKunjungan"" : """ & noKunjunganBPJS & ""","
                    statusTransaksi = "UPDATE"
                End If

                ' Get Rujukan Pasien
                Dim tblsRujukan As DataTable = ReadSQL("SELECT * FROM TransaksiDetailRujukan WHERE NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL")
                Dim jenisRujukan As String = ""
                Dim kdKhusus As String = ""
                Dim kdSubSpesialis As String = ""
                Dim catatan As String = ""
                Dim kdSubSpesialis1 As String = ""
                Dim kdSarana As String = ""
                Dim kdTacc As String = ""
                Dim alasanTacc As String = ""
                Dim kodePPK As String = ""
                Dim tglRujukan As String = ""

                If tblsRujukan.Rows.Count > 0 Then
                    For Each trowRujukan As DataRow In tblsRujukan.Rows
                        jenisRujukan = trowRujukan("JenisRujukan")
                        Dim convertTglRujukan As Date = CType(trowRujukan("TanggalRujukan"), Date)
                        tglRujukan = convertTglRujukan.ToString("dd-MM-yyyy")
                        kodePPK = trowRujukan("KodePPK")

                        If jenisRujukan = "Kondisi Khusus" Then
                            ' Rujukan Kondisi Khusus
                            kdKhusus = """kdKhusus"": """ & trowRujukan("KodeKhusus") & ""","

                            If trowRujukan("KodeSubSpesialis") <> "" Then
                                kdSubSpesialis = """kdSubSpesialis"": """ & trowRujukan("KodeSubSpesialis") & ""","
                            Else
                                kdSubSpesialis = """kdSubSpesialis"": null,"
                            End If

                            catatan = """catatan"": """ & Replace(trowRujukan("Catatan"), vbCrLf, " ") & """ } },"
                        ElseIf jenisRujukan = "Spesialis" Then
                            ' Rujukan Spesialis
                            kdSubSpesialis1 = """kdSubSpesialis1"": """ & trowRujukan("KodeSubSpesialis") & ""","

                            If trowRujukan("KodeSarana") <> "" Then
                                kdSarana = """kdSarana"": """ & trowRujukan("KodeSarana") & """ },"
                            Else
                                kdSarana = """kdSarana"": null },"
                            End If
                        End If

                        ' Set Status TACC Rujukan
                        If trowRujukan("KodeTACC").ToString <> "" Then
                            kdTacc = """kdTacc"": " & trowRujukan("KodeTACC") & ","
                            alasanTacc = """alasanTacc"": """ & trowRujukan("AlasanTACC") & """"
                        Else
                            kdTacc = """kdTacc"": -1,"
                            alasanTacc = """alasanTacc"": null"
                        End If
                    Next
                End If

                ' Get Status Rujukan / Non Rujukan
                If statusPulang = "3" Then
                    paramRujukLanjut = """rujukLanjut"": { " & _
                                        """tglEstRujuk"": """"," & _
                                        """kdppk"": """"," & _
                                        """subSpesialis"": null," & _
                                        """khusus"": null }," & _
                                       """kdTacc"": -1," & _
                                       """alasanTacc"": null" & _
                                       "}"
                ElseIf statusPulang = "4" Then
                    If jenisRujukan = "Kondisi Khusus" Then
                        paramRujukLanjut = """rujukLanjut"": { " & _
                                            """tglEstRujuk"": """ & tglRujukan & """," & _
                                            """kdppk"": """ & kodePPK & """," & _
                                            """subSpesialis"": null," & _
                                            """khusus"": { " & _
                                                kdKhusus & _
                                                kdSubSpesialis & _
                                                catatan & _
                                            kdTacc & _
                                            alasanTacc & _
                                          "}"
                    ElseIf jenisRujukan = "Spesialis" Then
                        paramRujukLanjut = """rujukLanjut"": { " & _
                                            """kdppk"": """ & kodePPK & """," & _
                                            """tglEstRujuk"": """ & tglRujukan & """," & _
                                            """subSpesialis"": { " & _
                                                kdSubSpesialis1 & _
                                                kdSarana & _
                                            """khusus"": null }," & _
                                            kdTacc & _
                                            alasanTacc & _
                                          "}"
                    End If
                End If

                parameterKunjunganBPJS = "{" & _
                                          paramNoKunjungan & _
                                          """noKartu"" : """ & noBPJS & """," & _
                                          """tglDaftar"" : """ & Format(tglKunjungan, "dd-MM-yyyy") & """," & _
                                          """kdPoli"" : """ & kdPoli & """," & _
                                          """keluhan"": """ & rowDetailTransaksi("KeluhanUtama") & """," & _
                                          """kdSadar"": """ & kodeKesadaran & """," & _
                                          """sistole"": " & rowDetailTransaksi("Sistole") & "," & _
                                          """diastole"": " & rowDetailTransaksi("Diastole") & "," & _
                                          """beratBadan"": " & rowDetailTransaksi("Berat") & "," & _
                                          """tinggiBadan"": " & rowDetailTransaksi("Tinggi") & "," & _
                                          """suhu"": " & rowDetailTransaksi("Suhu") & "," & _
                                          """respRate"": " & rowDetailTransaksi("RespiratoryRate") & "," & _
                                          """heartRate"": " & rowDetailTransaksi("HeartRate") & "," & _
                                          """lingkarPerut"": " & rowDetailTransaksi("LingkarPerut") & "," & _
                                          """terapiObat"": """ & terapiObat & """," & _
                                          """terapiNonObat"": """ & terapiNonObat & """," & _
                                          """anamnesa"": """ & anamnesa & """," & _
                                          """alergiMakan"": """ & alergiMakan & """," & _
                                          """alergiUdara"": """ & alergiUdara & """," & _
                                          """alergiObat"": """ & alergiObat & """," & _
                                          """kdPrognosa"": """ & prognosa & """," & _
                                          """bmhp"": """ & bmhp & """," & _
                                          """kdStatusPulang"": """ & statusPulang & """," & _
                                          """tglPulang"": """ & Format(tglKunjungan, "dd-MM-yyyy") & """," & _
                                          """kdDokter"": """ & kodeDokter & """," & _
                                          kodeDiagnosa & _
                                          """kdPoliRujukInternal"": null," & _
                                          paramRujukLanjut

                ' Insert / update data ke pcare BPJS
                Dim jsonString As String = ""
                Try
                    If statusTransaksi = "INSERT" Then
                        jsonString = PostDataFromPcare(parameterKunjunganBPJS, uri, "POST")
                    ElseIf statusTransaksi = "UPDATE" Then
                        jsonString = PostDataFromPcare(parameterKunjunganBPJS, uri, "PUT")
                    End If

                Catch ex As Exception
                    ' ====== PENANGANAN INTERNET PUTUS / TIMEOUT / HOST NOT RESPONDING ======
                    MsgBox("Gagal menghubungi server BPJS PCare." & vbCrLf & _
                           "Kemungkinan:" & vbCrLf & _
                           "- Internet lambat / terputus" & vbCrLf & _
                           "- Server BPJS sedang tidak dapat diakses" & vbCrLf & _
                           "- Koneksi timeout" & vbCrLf & _
                           vbCrLf & _
                           "Error detail: " & ex.Message, MsgBoxStyle.Critical, "Koneksi PCare Error")

                    Exit Sub
                End Try
                ' ==========================
                ' CEK JIKA RESPON STRING KOSONG
                ' ==========================
                If String.IsNullOrEmpty(jsonString) Then
                    MsgBox("Tidak ada respon dari server BPJS PCare." & vbCrLf & _
                            "Kemungkinan server DOWN atau internet terputus.", MsgBoxStyle.Exclamation, "BPJS PCare")
                    Exit Sub
                End If

                Dim jsonObject As JObject = Nothing

                ' ============================
                ' PARSE JSON
                ' ============================
                Try
                    jsonObject = JObject.Parse(jsonString)
                Catch ex As Exception
                    MsgBox("Format respon dari BPJS PCare tidak valid." & vbCrLf & _
                           "Raw Response:" & vbCrLf & jsonString, MsgBoxStyle.Critical, "FORMAT ERROR")
                    Exit Sub
                End Try

                ' ============================
                ' VALIDASI metaData
                ' ============================
                Dim metaDataObj As JObject = Nothing
                If jsonObject("metaData") Is Nothing Then
                    MsgBox("Respons BPJS tidak memiliki metaData." & vbCrLf & _
                           "Kemungkinan server DOWN / respons tidak lengkap." & vbCrLf & _
                           "Raw Response:" & vbCrLf & jsonString, MsgBoxStyle.Critical, "MISSING METADATA")
                    Exit Sub
                End If

                metaDataObj = jsonObject("metaData")

                If metaDataObj("code") Is Nothing Then
                    MsgBox("Kode metaData tidak ditemukan pada respons BPJS.", MsgBoxStyle.Exclamation, "META INVALID")
                    Exit Sub
                End If

                Dim codeMetaData As Integer = CInt(metaDataObj("code"))

                ' ============================
                ' VALIDASI response
                ' ============================
                Dim responseToken As JToken = jsonObject("response")
                Dim responseArray As New JArray()
                Dim messageResponse As String = ""

                If responseToken Is Nothing Then
                    ' Respons tidak memiliki "response"
                    responseArray = New JArray()
                ElseIf responseToken.Type = JTokenType.Array Then
                    responseArray = DirectCast(responseToken, JArray)
                ElseIf responseToken.Type = JTokenType.String Then
                    messageResponse = responseToken.ToString()
                End If

                ' ============================
                ' HANDLE STATUS KODE
                ' ============================
                Select Case codeMetaData

                    Case 200, 201, 204
                        ' ----------- STATUS SUCCESS -----------
                        If statusTransaksi = "INSERT" Then

                            If responseArray.Count > 0 Then
                                For Each item As JObject In responseArray
                                    If item("message") IsNot Nothing Then
                                        noKunjunganBPJS = item("message").ToString()
                                    End If
                                Next
                            ElseIf messageResponse <> "" Then
                                noKunjunganBPJS = messageResponse
                            Else
                                MsgBox("Berhasil, namun tidak ada nomor kunjungan yang dikembalikan.", MsgBoxStyle.Information, "INFO")
                            End If

                            ' Update database
                            WriteSQL("UPDATE TransaksiDetail SET NoKunjunganBPJS = '" & noKunjunganBPJS & "' WHERE NoUrut = '" & idTransaksi & "'", 4)
                        End If

                    Case Else
                        ' ----------- STATUS ERROR -----------
                        Dim errorMessage As String = ""

                        If responseArray.Count > 0 Then
                            For Each item As JObject In responseArray
                                If item("field") IsNot Nothing Then
                                    errorMessage &= "- " & item("field").ToString() & " : " & _
                                    item("message").ToString() & vbCrLf
                                End If
                            Next
                        Else
                            errorMessage = messageResponse
                        End If

                        MsgBox("Error BPJS :" & vbCrLf & errorMessage, MsgBoxStyle.Exclamation, "ERROR!")
                        Exit Sub

                End Select
            Else

            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Function GetKodeAlergiBridgingPCare(ByVal alergiJenis As String, ByVal noRekamMedis As String) As String
        Dim queryString As New StringBuilder()

        queryString.AppendLine("SELECT b.KodeBPJS")
        queryString.AppendLine("FROM MasterPasienAlergi a")
        queryString.AppendLine("LEFT JOIN MasterAlergi b ON a.AlergiID = b.ID")
        queryString.AppendLine("WHERE a.AlergiJenis = '" & alergiJenis & "' AND a.NoRekamMedis = '" & noRekamMedis & "'")
        queryString.AppendLine("AND a.DeletedDate IS NULL AND b.KodeBPJS IS NOT NULL")
        queryString.AppendLine("ORDER BY a.CreatedBy ASC;")

        Dim kodeBridging As String = ReadSQLNIK(queryString.ToString())

        If kodeBridging = "-" Then kodeBridging = "00"

        Return kodeBridging
    End Function

    Function GetListAlergi(ByVal alergiJenis As String, ByVal noRekamMedis As String) As String
        Dim queryAlergi As String = "SELECT AlergiJenis, AlergiNama, Keterangan FROM MasterPasienAlergi WHERE AlergiJenis = '" & alergiJenis & "' AND NoRekamMedis = '" & noRekamMedis & "' AND DeletedDate IS NULL"
        Dim tblAlergi As DataTable = ReadSQL(queryAlergi)

        ' List untuk menampung alergi makanan dan obat
        Dim alergiList As New List(Of String)

        ' Kumpulkan alergi berdasarkan jenisnya
        For Each row As DataRow In tblAlergi.Rows
            If row("Keterangan").ToString() <> "" Then
                alergiList.Add(row("AlergiNama").ToString() & " (" & row("Keterangan").ToString() & ")")
            Else
                alergiList.Add(row("AlergiNama").ToString())
            End If
        Next

        Dim alergiPasien As String = ""

        If alergiList.Count > 0 Then alergiPasien = String.Join(", ", alergiList.ToArray())

        Return alergiPasien
    End Function

    Function CheckVariabelPCare() As Boolean
        ' Cek apakah diagnosa sudah di input
        If CheckSQL("SELECT * FROM TransaksiDetailDiagnosa WHERE NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL") = False Then
            Return False
        End If

        ' Cek apakah fisik sudah di input
        If CheckSQL("SELECT * FROM TransaksiDetailFisik WHERE NoTransaksi = '" & idTransaksi & "'") = False Then
            Return False
        End If

        Return True
    End Function

    Function GetKeadaanUmum(ByRef tabPage As String) As String
        Dim keterangan As String = ""

        If tabPage = "Pemeriksaan Awal" Then
            If RadioButtonKeadaanTampakSehatPemeriksaanAwal.Checked = True Then
                keterangan = RadioButtonKeadaanTampakSehatPemeriksaanAwal.Text
            ElseIf RadioButtonKeadaanSakitRinganPemeriksaanAwal.Checked = True Then
                keterangan = RadioButtonKeadaanSakitRinganPemeriksaanAwal.Text
            ElseIf RadioButtonKeadaanSakitSedangPemeriksaanAwal.Checked = True Then
                keterangan = RadioButtonKeadaanSakitSedangPemeriksaanAwal.Text
            ElseIf RadioButtonKeadaanSakitBeratPemeriksaanAwal.Checked = True Then
                keterangan = RadioButtonKeadaanSakitBeratPemeriksaanAwal.Text
            End If
        ElseIf tabPage = "Medik" Then
            If RadioButtonKeadaanTampakSehatMedik.Checked = True Then
                keterangan = RadioButtonKeadaanTampakSehatMedik.Text
            ElseIf RadioButtonKeadaanSakitRinganMedik.Checked = True Then
                keterangan = RadioButtonKeadaanSakitRinganMedik.Text
            ElseIf RadioButtonKeadaanSakitSedangMedik.Checked = True Then
                keterangan = RadioButtonKeadaanSakitSedangMedik.Text
            ElseIf RadioButtonKeadaanSakitBeratMedik.Checked = True Then
                keterangan = RadioButtonKeadaanSakitBeratMedik.Text
            End If
        End If

        Return keterangan
    End Function

    Function GetKesadaran(ByRef tabPage As String) As String
        Dim keterangan As String = ""

        If tabPage = "Pemeriksaan Awal" Then
            If RadioButtonComposMentisPemeriksaanAwal.Checked = True Then
                keterangan = RadioButtonComposMentisPemeriksaanAwal.Text
            ElseIf RadioButtonApatisPemeriksaanAwal.Checked = True Then
                keterangan = RadioButtonApatisPemeriksaanAwal.Text
            ElseIf RadioButtonSomnolencePemeriksaanAwal.Checked = True Then
                keterangan = RadioButtonSomnolencePemeriksaanAwal.Text
            ElseIf RadioButtonSoporPemeriksaanAwal.Checked = True Then
                keterangan = RadioButtonSoporPemeriksaanAwal.Text
            ElseIf RadioButtonComaPemeriksaanAwal.Checked = True Then
                keterangan = RadioButtonComaPemeriksaanAwal.Text
            End If
        ElseIf tabPage = "Medik" Then
            If RadioButtonComposMentisMedik.Checked = True Then
                keterangan = RadioButtonComposMentisMedik.Text
            ElseIf RadioButtonApatisMedik.Checked = True Then
                keterangan = RadioButtonApatisMedik.Text
            ElseIf RadioButtonSomnolenceMedik.Checked = True Then
                keterangan = RadioButtonSomnolenceMedik.Text
            ElseIf RadioButtonSoporMedik.Checked = True Then
                keterangan = RadioButtonSoporMedik.Text
            ElseIf RadioButtonComaMedik.Checked = True Then
                keterangan = RadioButtonComaMedik.Text
            End If
        End If

        Return keterangan
    End Function

    Function CheckInputPemeriksaanAwal() As Boolean
        ' Validasi Inputan Keluhan
        Dim inputKeluhanUtama As String = TextBoxKeluhanUtamaPemeriksaanAwal.Text.Trim()
        Dim inputKeluhanTambahan As String = TextBoxKeluhanTambahanPemeriksaanAwal.Text.Trim()

        If inputKeluhanUtama = "" Or inputKeluhanTambahan = "" Then
            MsgBox("Gagal. Silahkan isi keluhan utama / keluhan tambahan terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        ElseIf inputKeluhanUtama.Length <= 4 Then
            MsgBox("Gagal. Keluhan utama harus lebih dari 4 karakter.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        ElseIf inputKeluhanTambahan.Length <= 10 Then
            MsgBox("Gagal. Keluhan tambahan harus lebih dari 10 karakter.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        '# Cek Nilai Vital Statistik & Antropometri
        ' Sistole
        If CekNilaiVitalAntropometri("Sistole", TextBoxSistolePemeriksaanAwal.Text) = False Then Return False

        ' Diastole
        If CekNilaiVitalAntropometri("Diastole", TextBoxDiastolePemeriksaanAwal.Text) = False Then Return False

        ' Heart Rate
        If CekNilaiVitalAntropometri("Heart Rate", TextBoxDetakNadiPemeriksaanAwal.Text) = False Then Return False

        ' Respiratory Rate
        If CekNilaiVitalAntropometri("Respiratory Rate", TextBoxNafasPemeriksaanAwal.Text) = False Then Return False

        ' Suhu
        If CekNilaiVitalAntropometri("Suhu", TextBoxSuhuPemeriksaanAwal.Text) = False Then Return False

        ' Tinggi Badan
        If CekNilaiVitalAntropometri("Tinggi Badan", TextBoxTinggiBadanPemeriksaanAwal.Text) = False Then Return False

        ' Berat Badan
        If CekNilaiVitalAntropometri("Berat Badan", TextBoxBeratBadanPemeriksaanAwal.Text) = False Then Return False

        ' Lingkar Perut
        If CekNilaiVitalAntropometri("Lingkar Perut", TextBoxLingkarPerutPemeriksaanAwal.Text) = False Then Return False

        Return True
    End Function

    Function CheckInputSubjektif() As Boolean
        ' Validasi RPS & RPO
        Dim inputRiwayatPenyakitSekarang As String = TextBoxRiwayatPenyakitSekarang.Text.Trim()
        Dim inputRiwayatPenggunaanObat As String = TextBoxRiwayatPenggunaanObat.Text.Trim()

        If inputRiwayatPenyakitSekarang <> "" And inputRiwayatPenyakitSekarang.Length <= 4 Then
            MsgBox("Gagal. RPS harus lebih dari 4 karakter atau kosongi.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        ElseIf inputRiwayatPenggunaanObat <> "" And inputRiwayatPenggunaanObat.Length <= 4 Then
            MsgBox("Gagal. RPO harus lebih dari 4 karakter atau kosongi.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        ' Validasi Inputan Keluhan
        Dim inputKeluhanUtama As String = TextBoxKeluhanUtamaMedik.Text.Trim()
        Dim inputKeluhanTambahan As String = TextBoxKeluhanTambahanMedik.Text.Trim()

        ' UATBPJS
        If inputKeluhanUtama = "" Or inputKeluhanTambahan = "" Then
            MsgBox("Gagal. Silahkan isi keluhan utama / keluhan tambahan terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        ElseIf inputKeluhanUtama.Length <= 4 Then
            MsgBox("Gagal. Keluhan utama harus lebih dari 4 karakter.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        ElseIf inputKeluhanTambahan.Length <= 10 Then
            MsgBox("Gagal. Keluhan tambahan harus lebih dari 10 karakter.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        Return True
    End Function

    Function CheckInputPemeriksaanFisik() As Boolean
        '# Validasi Nilai Vital Statistik & Antropometri
        ' Sistole
        If CekNilaiVitalAntropometri("Sistole", TextBoxSistoleMedik.Text) = False Then Return False

        ' Diastole
        If CekNilaiVitalAntropometri("Diastole", TextBoxDiastoleMedik.Text) = False Then Return False

        ' Heart Rate
        If CekNilaiVitalAntropometri("Heart Rate", TextBoxDetakNadiMedik.Text) = False Then Return False

        ' Respiratory Rate
        If CekNilaiVitalAntropometri("Respiratory Rate", TextBoxNafasMedik.Text) = False Then Return False

        ' Suhu
        If CekNilaiVitalAntropometri("Suhu", TextBoxSuhuMedik.Text) = False Then Return False

        ' Tinggi Badan
        If CekNilaiVitalAntropometri("Tinggi Badan", TextBoxTinggiBadanMedik.Text) = False Then Return False

        ' Berat Badan
        If CekNilaiVitalAntropometri("Berat Badan", TextBoxBeratBadanMedik.Text) = False Then Return False

        ' Lingkar Perut
        If CekNilaiVitalAntropometri("Lingkar Perut", TextBoxLingkarPerutMedik.Text) = False Then Return False

        Return True
    End Function

    Function CheckInputPemeriksaanGeneralis() As Boolean
        Dim dataNotEmpty As Boolean = False

        '# Validasi Checkbox apakah ada yang tercentang
        If TextBoxStatusGeneralisKepala.Text.Length > 0 Then dataNotEmpty = True
        If TextBoxStatusGeneralisMata.Text.Length > 0 Then dataNotEmpty = True
        If TextBoxStatusGeneralisHidung.Text.Length > 0 Then dataNotEmpty = True
        If TextBoxStatusGeneralisMulutFaring.Text.Length > 0 Then dataNotEmpty = True
        If TextBoxStatusGeneralisTelinga.Text.Length > 0 Then dataNotEmpty = True
        If TextBoxStatusGeneralisLeher.Text.Length > 0 Then dataNotEmpty = True
        If TextBoxStatusGeneralisThorax.Text.Length > 0 Then dataNotEmpty = True
        If TextBoxStatusGeneralisAbdomen.Text.Length > 0 Then dataNotEmpty = True
        If TextBoxStatusGeneralisEkstremitas.Text.Length > 0 Then dataNotEmpty = True
        If TextBoxStatusGeneralisStatusLokalis.Text.Length > 0 Then dataNotEmpty = True

        If dataNotEmpty = False Then
            MessageBox.Show("Gagal simpan! Masukkan data terlebih dahulu.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        Return True
    End Function

    Private Sub SetBMI(ByRef jenisForm As String)
        Dim nilaiBMI As Double = 0

        If jenisForm = "Pemeriksaan Awal" Then
            If TextBoxTinggiBadanPemeriksaanAwal.Text.Length > 0 And TextBoxBeratBadanPemeriksaanAwal.Text.Length > 0 Then
                nilaiBMI = Math.Round(CDbl(TextBoxBeratBadanPemeriksaanAwal.Text / (TextBoxTinggiBadanPemeriksaanAwal.Text * TextBoxTinggiBadanPemeriksaanAwal.Text) * 10000), 1)

                TextBoxIndeksPemeriksaanAwal.Text = nilaiBMI
                TextBoxIndeksKeteranganPemeriksaanAwal.Text = GetKesimpulanBMI(nilaiBMI)
            End If
        ElseIf jenisForm = "Medik" Then
            If TextBoxTinggiBadanMedik.Text.Length > 0 And TextBoxBeratBadanMedik.Text.Length > 0 Then
                nilaiBMI = Math.Round(CDbl(TextBoxBeratBadanMedik.Text / (TextBoxTinggiBadanMedik.Text * TextBoxTinggiBadanMedik.Text) * 10000), 1)

                TextBoxIndeksMedik.Text = nilaiBMI
                TextBoxIndeksKeteranganMedik.Text = GetKesimpulanBMI(nilaiBMI)
            End If
        End If
    End Sub

    Private Sub TextBoxTinggiBadanPemeriksaanAwal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxTinggiBadanPemeriksaanAwal.TextChanged
        SetBMI("Pemeriksaan Awal")
    End Sub

    Private Sub TextBoxBeratBadanPemeriksaanAwal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxBeratBadanPemeriksaanAwal.TextChanged
        SetBMI("Pemeriksaan Awal")
    End Sub

    Private Sub TextBoxTinggiBadanMedik_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxTinggiBadanMedik.TextChanged
        SetBMI("Medik")
    End Sub

    Private Sub TextBoxBeratBadanMedik_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxBeratBadanMedik.TextChanged
        SetBMI("Medik")
    End Sub

    Function GetDataKuisioner() As String
        ' Set MST
        Dim jawabanPertanyaan1 As String = ""
        Dim jawabanPertanyaan1_2 As String = ""
        Dim jawabanPertanyaan2 As String = ""
        Dim jawabanPertanyaan3 As String = ""

        Dim PenurunanBeratBadan As String = ""
        Dim AsupanMakan As String = ""
        Dim DiagnosisKhusus As String = ""
        Dim TotalSkorMST As String = TextBoxTotalSkorMST.Text
        Dim StatusMental As String = ""
        Dim StatusPsikologis As String = ""
        Dim HubunganPasien As String = ""
        Dim NilaiKepercayaan As String = ""
        Dim Bahasa As String = ""
        Dim StatusFungsional As String = ""

        Dim parameterUpdate As String = ""

        ' PenurunanBeratBadan
        If RadioButtonPertanyaan1Pilihan1MST.Checked = True Then
            PenurunanBeratBadan = RadioButtonPertanyaan1Pilihan1MST.Text
        ElseIf RadioButtonPertanyaan1Pilihan2MST.Checked = True Then
            PenurunanBeratBadan = RadioButtonPertanyaan1Pilihan2MST.Text
        ElseIf RadioButtonPertanyaan1Pilihan3MST.Checked = True Then
            If RadioButtonPertanyaan1Opsi1MST.Checked = True Then
                PenurunanBeratBadan = RadioButtonPertanyaan1Opsi1MST.Text
            ElseIf RadioButtonPertanyaan1Opsi2MST.Checked = True Then
                PenurunanBeratBadan = RadioButtonPertanyaan1Opsi2MST.Text
            ElseIf RadioButtonPertanyaan1Opsi3MST.Checked = True Then
                PenurunanBeratBadan = RadioButtonPertanyaan1Opsi3MST.Text
            ElseIf RadioButtonPertanyaan1Opsi4MST.Checked = True Then
                PenurunanBeratBadan = RadioButtonPertanyaan1Opsi4MST.Text
            End If
        End If

        ' AsupanMakan
        If RadioButtonPertanyaan2Pilihan1MST.Checked = True Then
            AsupanMakan = RadioButtonPertanyaan2Pilihan1MST.Text
        ElseIf RadioButtonPertanyaan2Pilihan2MST.Checked = True Then
            AsupanMakan = RadioButtonPertanyaan2Pilihan2MST.Text
        End If

        ' DiagnosisKhusus
        If CheckBoxDiabetesMST.Checked = True Then
            DiagnosisKhusus = DiagnosisKhusus & CheckBoxDiabetesMST.Text & ", "
        End If

        If CheckBoxKemoterapiMST.Checked = True Then
            DiagnosisKhusus = DiagnosisKhusus & CheckBoxKemoterapiMST.Text & ", "
        End If

        If CheckBoxHemodialisaMST.Checked = True Then
            DiagnosisKhusus = DiagnosisKhusus & CheckBoxHemodialisaMST.Text & ", "
        End If

        If CheckBoxGeriatriMST.Checked = True Then
            DiagnosisKhusus = DiagnosisKhusus & CheckBoxGeriatriMST.Text & ", "
        End If

        If CheckBoxImunitasMST.Checked = True Then
            DiagnosisKhusus = DiagnosisKhusus & CheckBoxImunitasMST.Text & ", "
        End If

        If CheckBoxTiroidMST.Checked = True Then
            DiagnosisKhusus = DiagnosisKhusus & CheckBoxTiroidMST.Text & ", "
        End If

        If CheckBoxLainnyaMST.Checked = True Then
            DiagnosisKhusus = DiagnosisKhusus & TextBoxLainnyaKeterangan.Text & ", "
        End If

        ' StatusMental
        If RadioButtonOrientasiBaikPsiko.Checked = True Then
            StatusMental = RadioButtonOrientasiBaikPsiko.Text
        ElseIf RadioButtonDisorientasiPsiko.Checked = True Then
            StatusMental = RadioButtonDisorientasiPsiko.Text
        ElseIf RadioButtonGelisahPsiko.Checked = True Then
            StatusMental = RadioButtonGelisahPsiko.Text
        ElseIf RadioButtonTidakResponPsiko.Checked = True Then
            StatusMental = RadioButtonTidakResponPsiko.Text
        End If

        ' StatusPsikologis
        If RadioButtonTenangPsiko.Checked = True Then
            StatusPsikologis = RadioButtonTenangPsiko.Text
        ElseIf RadioButtonCemasPsiko.Checked = True Then
            StatusPsikologis = RadioButtonCemasPsiko.Text
        ElseIf RadioButtonTakutPsiko.Checked = True Then
            StatusPsikologis = RadioButtonTakutPsiko.Text
        ElseIf RadioButtonMarahPsiko.Checked = True Then
            StatusPsikologis = RadioButtonMarahPsiko.Text
        ElseIf RadioButtonSedihPsiko.Checked = True Then
            StatusPsikologis = RadioButtonSedihPsiko.Text
        ElseIf RadioButtonBunuhDiriPsiko.Checked = True Then
            StatusPsikologis = RadioButtonBunuhDiriPsiko.Text & "#" & TextBoxLaporKeteranganPsiko.Text & "#" & TextBoxLaporWaktuPsiko.Text
        End If

        ' HubunganPasien
        If RadioButtonBaikPsiko.Checked = True Then
            HubunganPasien = RadioButtonBaikPsiko.Text
        ElseIf RadioButtonTidakBaikPsiko.Checked = True Then
            HubunganPasien = RadioButtonTidakBaikPsiko.Text
        End If

        ' NilaiKepercayaan
        If RadioButtonAdaPsiko.Checked = True Then
            NilaiKepercayaan = RadioButtonAdaPsiko.Text
        ElseIf RadioButtonTidakAdaPsiko.Checked = True Then
            NilaiKepercayaan = RadioButtonTidakAdaPsiko.Text
        End If

        ' Bahasa
        If RadioButtonBahasaIndonesiaPsiko.Checked = True Then
            Bahasa = RadioButtonBahasaIndonesiaPsiko.Text
        ElseIf RadioButtonBahasaInggrisPsiko.Checked = True Then
            Bahasa = RadioButtonBahasaInggrisPsiko.Text
        ElseIf RadioButtonBahasaDaerahPsiko.Checked = True Then
            Bahasa = RadioButtonBahasaDaerahPsiko.Text & "#" & TextBoxBahasaDaerahKeteranganPsiko.Text
        ElseIf RadioButtonBahasaLainnyaPsiko.Checked = True Then
            Bahasa = RadioButtonBahasaLainnyaPsiko.Text & "#" & TextBoxBahasaLainnyaPsiko.Text
        End If

        ' StatusFungsional
        If RadioButtonStatusMandiriFungsional.Checked = True Then
            StatusFungsional = RadioButtonStatusMandiriFungsional.Text
        ElseIf RadioButtonStatusPerluBantuanFungsional.Checked = True Then
            StatusFungsional = RadioButtonStatusPerluBantuanFungsional.Text & "#" & TextBoxStatusPerluBantuanKeteranganFungsional.Text
        End If

        If DiagnosisKhusus.Length > 0 Then
            DiagnosisKhusus = Strings.Left(DiagnosisKhusus, DiagnosisKhusus.Length - 2)
        End If

        parameterUpdate = "PenurunanBeratBadan = '" & PenurunanBeratBadan & "'," & _
                          "AsupanMakan = '" & AsupanMakan & "'," & _
                          "DiagnosisKhusus = '" & DiagnosisKhusus & "'," & _
                          "TotalSkorMST = '" & TotalSkorMST & "'," & _
                          "StatusMental = '" & StatusMental & "'," & _
                          "StatusPsikologis = '" & StatusPsikologis & "'," & _
                          "HubunganPasien = '" & HubunganPasien & "'," & _
                          "NilaiKepercayaan = '" & NilaiKepercayaan & "'," & _
                          "Bahasa = '" & Bahasa & "'," & _
                          "StatusFungsional = '" & StatusFungsional & "'"

        Return parameterUpdate
    End Function

    Private Sub CheckBoxLainnyaMST_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxLainnyaMST.CheckedChanged
        If CheckBoxLainnyaMST.Checked = True Then
            TextBoxLainnyaKeterangan.Enabled = True
        ElseIf CheckBoxLainnyaMST.Checked = False Then
            TextBoxLainnyaKeterangan.ResetText()
            TextBoxLainnyaKeterangan.Enabled = False
        End If
    End Sub

    Private Sub RadioButtonPertanyaan1Pilihan3MST_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonPertanyaan1Pilihan3MST.CheckedChanged
        If RadioButtonPertanyaan1Pilihan3MST.Checked = True Then
            RadioButtonPertanyaan1Opsi1MST.Enabled = True
            RadioButtonPertanyaan1Opsi2MST.Enabled = True
            RadioButtonPertanyaan1Opsi3MST.Enabled = True
            RadioButtonPertanyaan1Opsi4MST.Enabled = True
        ElseIf RadioButtonPertanyaan1Pilihan3MST.Checked = False Then
            RadioButtonPertanyaan1Opsi1MST.Checked = False
            RadioButtonPertanyaan1Opsi2MST.Checked = False
            RadioButtonPertanyaan1Opsi3MST.Checked = False
            RadioButtonPertanyaan1Opsi4MST.Checked = False
            RadioButtonPertanyaan1Opsi1MST.Enabled = False
            RadioButtonPertanyaan1Opsi2MST.Enabled = False
            RadioButtonPertanyaan1Opsi3MST.Enabled = False
            RadioButtonPertanyaan1Opsi4MST.Enabled = False
        End If
    End Sub

    Private Sub RadioButtonYaPertanyaan3MST_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonYaPertanyaan3MST.CheckedChanged
        If RadioButtonYaPertanyaan3MST.Checked = True Then
            CheckBoxDiabetesMST.Enabled = True
            CheckBoxKemoterapiMST.Enabled = True
            CheckBoxHemodialisaMST.Enabled = True
            CheckBoxGeriatriMST.Enabled = True
            CheckBoxImunitasMST.Enabled = True
            CheckBoxTiroidMST.Enabled = True
            CheckBoxLainnyaMST.Enabled = True
        ElseIf RadioButtonYaPertanyaan3MST.Checked = False Then
            CheckBoxDiabetesMST.Checked = False
            CheckBoxKemoterapiMST.Checked = False
            CheckBoxHemodialisaMST.Checked = False
            CheckBoxGeriatriMST.Checked = False
            CheckBoxImunitasMST.Checked = False
            CheckBoxTiroidMST.Checked = False
            CheckBoxLainnyaMST.Checked = False
            CheckBoxDiabetesMST.Enabled = False
            CheckBoxKemoterapiMST.Enabled = False
            CheckBoxHemodialisaMST.Enabled = False
            CheckBoxGeriatriMST.Enabled = False
            CheckBoxImunitasMST.Enabled = False
            CheckBoxTiroidMST.Enabled = False
            CheckBoxLainnyaMST.Enabled = False

            TextBoxLainnyaKeterangan.ResetText()
            TextBoxLainnyaKeterangan.Enabled = False
        End If
    End Sub

    Private Sub RadioButtonBunuhDiriPsiko_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonBunuhDiriPsiko.CheckedChanged
        If RadioButtonBunuhDiriPsiko.Checked = True Then
            TextBoxLaporKeteranganPsiko.Enabled = True
            TextBoxLaporWaktuPsiko.Enabled = True
        ElseIf RadioButtonBunuhDiriPsiko.Checked = False Then
            TextBoxLaporKeteranganPsiko.ResetText()
            TextBoxLaporWaktuPsiko.ResetText()
            TextBoxLaporKeteranganPsiko.Enabled = False
            TextBoxLaporWaktuPsiko.Enabled = False
        End If
    End Sub

    Private Sub RadioButtonBahasaDaerahPsiko_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonBahasaDaerahPsiko.CheckedChanged
        If RadioButtonBahasaDaerahPsiko.Checked = True Then
            TextBoxBahasaDaerahKeteranganPsiko.Enabled = True
        ElseIf RadioButtonBahasaDaerahPsiko.Checked = False Then
            TextBoxBahasaDaerahKeteranganPsiko.ResetText()
            TextBoxBahasaDaerahKeteranganPsiko.Enabled = False
        End If
    End Sub

    Private Sub RadioButtonBahasaLainnyaPsiko_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonBahasaLainnyaPsiko.CheckedChanged
        If RadioButtonBahasaLainnyaPsiko.Checked = True Then
            TextBoxBahasaLainnyaPsiko.Enabled = True
        ElseIf RadioButtonBahasaLainnyaPsiko.Checked = False Then
            TextBoxBahasaLainnyaPsiko.ResetText()
            TextBoxBahasaLainnyaPsiko.Enabled = False
        End If
    End Sub

    Private Sub RadioButtonStatusPerluBantuanFungsional_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonStatusPerluBantuanFungsional.CheckedChanged
        If RadioButtonStatusPerluBantuanFungsional.Checked = True Then
            TextBoxStatusPerluBantuanKeteranganFungsional.Enabled = True
        ElseIf RadioButtonStatusPerluBantuanFungsional.Checked = False Then
            TextBoxStatusPerluBantuanKeteranganFungsional.ResetText()
            TextBoxStatusPerluBantuanKeteranganFungsional.Enabled = False
        End If
    End Sub

    Public Sub LoadDataObat(ByVal Trow As DataRowView, ByRef JenisObat As String, Optional ByVal kodeDPHO As String = "", Optional ByVal namaDPHO As String = "")
        Dim formatHarga As Decimal
        'Dim HargaObat As String = Trow("Harga").ToString
        Dim HargaObat As String = ReadThemysqlNIK("SELECT F_HargaObatKlinik('" & Trow("Kode Obat").ToString & "')", dbApotek)

        If JenisObat = "RekamMedisDokterObatNonRacikan" Then
            TextBoxNamaObatNonRacikan.Text = Trow("Nama Obat").ToString
            TextBoxKodeObatNonRacikan.Text = Trow("Kode Obat").ToString
            LabelStokObatNonRacikan.Text = "Stok Obat : " & Trow("Stok").ToString

            If Decimal.TryParse(HargaObat, formatHarga) Then TextBoxHargaObatNonRacikan.Text = formatHarga.ToString("N2")
        ElseIf JenisObat = "RekamMedisDokterObatRacikan" Then
            TextBoxNamaObatRacikan.Text = Trow("Nama Obat").ToString
            TextBoxKodeObatRacikan.Text = Trow("Kode Obat").ToString
            LabelStokObatRacikan.Text = "Stok Obat : " & Trow("Stok").ToString

            If Decimal.TryParse(HargaObat, formatHarga) Then TextBoxHargaObatRacikan.Text = formatHarga.ToString("N2")
        End If

        If kodeDPHO <> "" AndAlso namaDPHO <> "" Then
            TextBoxKodeObatDPHO.Text = kodeDPHO
            TextBoxObatDPHO.Text = namaDPHO
        End If
    End Sub

    Private Sub HitungNilaiMST()
        Dim nilaiPertanyaan1 As Integer = 0
        Dim nilaiPertanyaan2 As Integer = 0

        ' Set nilai pertanyaan 1
        If RadioButtonPertanyaan1Pilihan1MST.Checked = True Then
            nilaiPertanyaan1 = 0
        ElseIf RadioButtonPertanyaan1Pilihan2MST.Checked = True Then
            nilaiPertanyaan1 = 2
        ElseIf RadioButtonPertanyaan1Pilihan3MST.Checked = True Then
            If RadioButtonPertanyaan1Opsi1MST.Checked = True Then
                nilaiPertanyaan1 = 1
            ElseIf RadioButtonPertanyaan1Opsi2MST.Checked = True Then
                nilaiPertanyaan1 = 2
            ElseIf RadioButtonPertanyaan1Opsi3MST.Checked = True Then
                nilaiPertanyaan1 = 3
            ElseIf RadioButtonPertanyaan1Opsi4MST.Checked = True Then
                nilaiPertanyaan1 = 4
            End If
        End If

        ' Set nilai pertanyaan 2
        If RadioButtonPertanyaan2Pilihan1MST.Checked = True Then
            nilaiPertanyaan2 = 0
        ElseIf RadioButtonPertanyaan2Pilihan2MST.Checked = True Then
            nilaiPertanyaan2 = 1
        End If

        TextBoxTotalSkorMST.Text = nilaiPertanyaan1 + nilaiPertanyaan2
    End Sub

    Private Sub SetNilaiMST(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonPertanyaan1Pilihan1MST.CheckedChanged, RadioButtonPertanyaan1Pilihan2MST.CheckedChanged, RadioButtonPertanyaan1Opsi1MST.CheckedChanged, RadioButtonPertanyaan1Opsi2MST.CheckedChanged, RadioButtonPertanyaan1Opsi3MST.CheckedChanged, RadioButtonPertanyaan1Opsi4MST.CheckedChanged, RadioButtonPertanyaan2Pilihan1MST.CheckedChanged, RadioButtonPertanyaan2Pilihan2MST.CheckedChanged
        HitungNilaiMST()
    End Sub

    Public Sub LoadDiagnosa(ByRef Trow As DataRowView, ByRef JenisDiagnosa As String)
        If JenisDiagnosa = "RekamMedisDokterDiagnosa" Then
            TextBoxKodeDiagnosa.Text = Trow("Kode Diagnosa").ToString
            TextBoxKeteranganDiagnosa.Text = Trow("Nama Diagnosa").ToString
            CheckBoxDiagnosaNonSpesialistik.Checked = Trow("Non Spesialis").ToString
        End If
    End Sub

    Function GetDataMedikSubjektif() As String
        Dim parameterUpdate As String = ""

        parameterUpdate = "RiwayatPenyakitSekarang = '" & TextBoxRiwayatPenyakitSekarang.Text & "'," & _
                          "RiwayatPenggunaanObat = '" & TextBoxRiwayatPenggunaanObat.Text & "'," & _
                          "KeluhanUtama = '" & TextBoxKeluhanUtamaMedik.Text & "'," & _
                          "KeluhanTambahan = '" & TextBoxKeluhanTambahanMedik.Text & "'"

        Return parameterUpdate
    End Function

    Private Sub HitungNilaiResikoJatuh()
        If (RadioButtonPertanyaan1Pilihan1RJ.Checked = True Or RadioButtonPertanyaan1Pilihan2RJ.Checked = True) And (RadioButtonPertanyaan2Pilihan1RJ.Checked = True Or RadioButtonPertanyaan2Pilihan2RJ.Checked = True) Then
            Dim nilaiPertanyaan1 As Integer = 0
            Dim nilaiPertanyaan2 As Integer = 0
            Dim nilaiTotal As Integer = 0

            ' Set nilai pertanyaan 1
            If RadioButtonPertanyaan1Pilihan1RJ.Checked = True Then
                nilaiPertanyaan1 = 1
            ElseIf RadioButtonPertanyaan1Pilihan2RJ.Checked = True Then
                nilaiPertanyaan1 = 0
            End If

            ' Set nilai pertanyaan 2
            If RadioButtonPertanyaan2Pilihan1RJ.Checked = True Then
                nilaiPertanyaan2 = 1
            ElseIf RadioButtonPertanyaan2Pilihan2RJ.Checked = True Then
                nilaiPertanyaan2 = 0
            End If

            nilaiTotal = nilaiPertanyaan1 + nilaiPertanyaan2
            TextBoxTotalSkorMST.Text = nilaiTotal

            Dim tbls As DataTable = New DataTable
            tbls = ReadSQL("SELECT Hasil, DasarPenilaian, Tindakan FROM MasterResikoJatuh WHERE Skor = " & nilaiTotal & "")
            Dim Trow As DataRow = tbls.Rows(0)

            TextBoxSkorResikoJatuh.Text = nilaiTotal
            TextBoxHasilResikoJatuh.Text = Trow("Hasil")
            TextBoxDasarPenilaianResikoJatuh.Text = Trow("DasarPenilaian")
            TextBoxTindakanResikoJatuh.Text = Trow("Tindakan")
        End If
    End Sub

    Private Sub CreateListViewRacikanTemp()
        ' Membuat kolom-kolom untuk ListView
        ListViewRacikanTemp.Columns.Add("ObatID", 100, HorizontalAlignment.Left)
        ListViewRacikanTemp.Columns.Add("Jumlah", 75, HorizontalAlignment.Left)
        ListViewRacikanTemp.Columns.Add("ObatNama", 250, HorizontalAlignment.Left)
        ListViewRacikanTemp.Columns.Add("ObatHarga", 100, HorizontalAlignment.Left)
    End Sub

    Private Sub ButtonCariObatNonRacikan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCariObatNonRacikan.Click
        If ValidasiObat() = True Then
            FindObat.SetForm("RekamMedisDokterObatNonRacikan")
            FindObat.ShowDialog()
        End If
    End Sub

    Private Sub ButtonCariObatRacikan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCariObatRacikan.Click
        If ValidasiObat() = True Then
            FindObat.SetForm("RekamMedisDokterObatRacikan")
            FindObat.ShowDialog()
        End If
    End Sub

    Private Sub ButtonSimpanObatRacikan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSimpanObatRacikan.Click
        Try
            If CheckSimpanObatRacikan() = True Then
                ' Set No Racikan
                Dim noRacikan As String = ReadSQLNIK("EXEC sp_generate_no_racikan '" & idTransaksi & "'")
                Dim kodeRacikan As String = noRacikan
                Dim signa1 As Double
                Dim signa2 As Double
                Dim aturanpakai As String = ComboBoxAturanPakaiObatRacikan.Text
                Dim catatan As String = TextBoxCatatanObatRacikan.Text
                Dim jumlahObatRacikan As Double

                Double.TryParse(TextBoxSigna1Racikan.Text, signa1)
                Double.TryParse(TextBoxSigna2Racikan.Text, signa2)
                Double.TryParse(TextBoxJumlahObatRacikan.Text, jumlahObatRacikan)

                ' Set Variabel Harga
                Dim formatHarga As Decimal
                Dim hargaObat As Double = 0
                Dim hargaTotalObat As Double = 0
                Dim statusPenutupRacikan As Boolean = False
                Dim namaObat As String = ""

                Dim statusAPI As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'status_ws_RM' ")

                ' Save ke tabel TransaksiObatRacikan
                WriteSQL("INSERT INTO TransaksiObatRacikan (NoTransaksi, KodeRacikan, AturanPakai, Signa1, Signa2, SignaSatuan, Catatan, JumlahKapsul) " & _
                                 "VALUES('" & idTransaksi & "', '" & noRacikan & "', '" & ComboBoxAturanPakaiObatRacikan.Text & "', '" & TextBoxSigna1Racikan.Text & "', '" & TextBoxSigna2Racikan.Text & "', '', '" & TextBoxCatatanObatRacikan.Text & "', 0)", 4)

                For Each item As ListViewItem In ListViewRacikanTemp.Items
                    'Dim jumlahObat As Double = item.SubItems(1).Text
                    Dim jumlahObat As Double
                    Dim hargaSatuan As Double
                    Double.TryParse(item.SubItems(1).Text, jumlahObat)
                    Double.TryParse(item.SubItems(3).Text, hargaSatuan)

                    ' Set Default
                    statusPenutupRacikan = False
                    namaObat = item.SubItems(2).Text

                    ' Set Penutup Racikan
                    If namaObat.StartsWith("POT ") = True Or namaObat.StartsWith("KAPSUL") = True Or namaObat.StartsWith("KERTAS PUYER") = True Or namaObat.StartsWith("RACIKAN SIRUP") = True Or namaObat.StartsWith("PUYER") = True Then
                        statusPenutupRacikan = True
                    End If

                    If statusPenutupRacikan = False Then
                        If statusAPI IsNot Nothing AndAlso statusAPI = "Yes" Then
                            SendToApiObatRacikan(idTransaksi, kodeRacikan, namaObat, jumlahObat)
                        End If
                    End If

                    ' Set Total Harga Obat
                    'hargaTotalObat = item.SubItems(1).Text * item.SubItems(3).Text
                    'hargaObat = item.SubItems(3).Text
                    hargaTotalObat = jumlahObat * hargaSatuan
                    hargaObat = hargaSatuan

                    If Decimal.TryParse(hargaTotalObat, formatHarga) Then hargaTotalObat = hargaTotalObat.ToString("N2")
                    If Decimal.TryParse(hargaObat, formatHarga) Then hargaObat = hargaObat.ToString("N2")

                    ' Save ke tabel TransaksiObat
                    WriteSQL("INSERT INTO TransaksiObat (NoTransaksi, ObatID, ObatNama, Jumlah, Harga, HargaTotal, Racikan, KodeRacikan, PenutupRacikan, CreatedBy, CreatedDate) " & _
                                     "VALUES('" & idTransaksi & "', '" & item.SubItems(0).Text & "', '" & item.SubItems(2).Text & "', '" & item.SubItems(1).Text & "', '" & hargaObat & "', '" & hargaTotalObat & "', 1, '" & noRacikan & "', " & Convert.ToInt32(statusPenutupRacikan) & ", '" & userInput & "', GETDATE())", 4)


                    If statusPenutupRacikan = True Then
                        SendToApiObat(idTransaksi, namaObat, jumlahObat, True, kodeRacikan, signa1, signa2, "", aturanpakai, catatan, False)
                    End If
                Next

                LoadGridResepObat()
                SaveDetailResep()
                ClearTabRacikan()
                SetLabelKirimResep()

                ' Kirim P-Care
                If statusBPJS = True AndAlso CheckBridgingPcareActive() = True Then SaveKunjunganBPJS()

                MsgBox("Berhasil menyimpan racikan.", MsgBoxStyle.Information, "Success!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub ListViewRacikanTemp_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListViewRacikanTemp.KeyDown
        If e.KeyCode = Keys.Delete AndAlso ListViewRacikanTemp.SelectedItems.Count > 0 Then
            Dim item As ListViewItem = ListViewRacikanTemp.SelectedItems(0)
            ListViewRacikanTemp.Items.Remove(item)
        End If
    End Sub

    Private Sub SendToApiObat(ByVal idTransaksi As String, ByVal namaObat As String, ByVal jumlahObat As Double, ByVal racikan As Boolean, ByVal kodeRacikan As String, ByVal signa1 As Double, ByVal signa2 As Double, ByVal signaSatuan As String, ByVal aturanPakai As String, ByVal catatan As String, ByVal deleted As Boolean)
        Try
            Dim client As New Net.WebClient()

            ' Siapkan JSON sesuai field di Laravel
            Dim json As String = "{" & _
                """NoTransaksi"":""" & idTransaksi & """," & _
                """NamaObat"":""" & namaObat.Replace("""", "\""") & """," & _
                """Jumlah"":""" & jumlahObat.ToString(CultureInfo.InvariantCulture) & """," & _
                """Racikan"":""" & If(racikan, "1", "0") & """," & _
                """KodeRacikan"":""" & kodeRacikan.Replace("""", "\""") & """," & _
                """Signa1"":""" & signa1.ToString(CultureInfo.InvariantCulture) & """," & _
                """Signa2"":""" & signa2.ToString(CultureInfo.InvariantCulture) & """," & _
                """SignaSatuan"":""" & signaSatuan.Replace("""", "\""") & """," & _
                """AturanPakai"":""" & aturanPakai.Replace("""", "\""") & """," & _
                """Catatan"":""" & catatan.Replace("""", "\""") & """," & _
                """Deleted"":""" & If(deleted, "1", "0") & """" & _
            "}"

            Dim baseUrl As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
            Dim urlWebService As String = baseUrl & "api/obat/save"
            Dim response As String = InsertDataAPIRM(json, urlWebService)


            ' --- Parse JSON response ---
            Dim result As JObject = JObject.Parse(response)

            Dim status As String = result("status").ToString()
            Dim message As String = result("message").ToString()

            Dim insertedId As String = ""
            Dim data As JObject = TryCast(result("data"), JObject)
            If data IsNot Nothing AndAlso data("id") IsNot Nothing Then
                insertedId = data("id").ToString()
            End If

            ' --- Tampilkan hasil ---
            If status = "success" Then
                MsgBox("Data Obat berhasil dikirim ke API ERM." & vbCrLf & _
                       "Pesan: " & message & vbCrLf & _
                       "Dengan ID: " & insertedId)
            Else
                MsgBox("API mengembalikan status gagal: " & status & vbCrLf & message)
            End If

        Catch ex As Exception
            ' Jangan hentikan aplikasi, cukup log error
            MsgBox("Gagal kirim ke API: " & ex.Message)
        End Try
    End Sub

    Private Sub SendToApiObatRacikan(ByVal idTransaksi As String, ByVal kodeRacikan As String, ByVal namaObat As String, ByVal jumlahObat As Double)
        Try
            Dim client As New Net.WebClient()

            ' Siapkan JSON sesuai field di Laravel
            Dim json As String = "{" & _
                """NoTransaksi"":""" & idTransaksi & """," & _
                """KodeRacikan"":""" & kodeRacikan.Replace("""", "\""") & """," & _
                """NamaObat"":""" & namaObat.Replace("""", "\""") & """," & _
                """Jumlah"":" & jumlahObat.ToString(CultureInfo.InvariantCulture) & _
            "}"

            Dim baseUrl As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
            Dim urlWebService As String = baseUrl & "api/obatRacikan/save"
            Dim response As String = InsertDataAPIRM(json, urlWebService)

            ' --- Parse JSON response ---
            Dim result As JObject = JObject.Parse(response)

            Dim status As String = result("status").ToString()
            Dim message As String = result("message").ToString()

            Dim insertedId As String = ""
            Dim data As JObject = TryCast(result("data"), JObject)
            If data IsNot Nothing AndAlso data("id") IsNot Nothing Then
                insertedId = data("id").ToString()
            End If

            ' --- Tampilkan hasil ---
            If status = "success" Then
                MsgBox("Data Obat Racikan berhasil dikirim ke API ERM." & vbCrLf & _
                       "Pesan: " & message & vbCrLf & _
                       "Dengan ID: " & insertedId)
            Else
                MsgBox("API mengembalikan status gagal: " & status & vbCrLf & message)
            End If

        Catch ex As Exception
            ' Jangan hentikan aplikasi, cukup log error
            MsgBox("Gagal kirim ke API: " & ex.Message)
        End Try
    End Sub

    Private Sub ButtonSimpanObatNonRacikan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSimpanObatNonRacikan.Click
        Try
            If CheckSimpanObatNonRacikan() = True Then
                ' Set Format Harga
                Dim formatHarga As Decimal

                ' Set Harga & Jumlah Obat
                Dim hargaObat As Double = TextBoxHargaObatNonRacikan.Text
                Dim jumlahObat As Double = TextBoxJumlahObatNonRacikan.Text
                Dim namaObat As String = TextBoxNamaObatNonRacikan.Text
                Dim signaSatuan As String = ComboBoxSatuanSignaNonRacikan.Text
                Dim catatan As String = TextBoxCatatanObatNonRacikan.Text
                Dim aturanPakai As String = ComboBoxAturanPakaiObatNonRacikan.Text

                ' Set Signa
                Dim signa1 As Double = 0
                Dim signa2 As Double = 0

                If Not String.IsNullOrEmpty(TextBoxSigna1NonRacikan.Text.Trim()) Then
                    Double.TryParse(TextBoxSigna1NonRacikan.Text.Trim(), signa1)
                End If

                If Not String.IsNullOrEmpty(TextBoxSigna2NonRacikan.Text.Trim()) Then
                    Double.TryParse(TextBoxSigna2NonRacikan.Text.Trim(), signa2)
                End If

                'Set Jumlah Permintaan
                Dim totalPerHari As Double = signa1 * signa2
                Dim habisHari As Double = 0
                If totalPerHari > 0 Then
                    habisHari = jumlahObat / totalPerHari
                End If

                ' Set Status IMM
                Dim statusIMM As Boolean = True
                If RadioButtonImmYa.Checked = True Then
                    statusIMM = True
                ElseIf RadioButtonImmTidak.Checked = True Then
                    statusIMM = False
                End If

                ' Set Total Harga Obat
                Dim hargaTotalObat As Double = hargaObat * jumlahObat
                If Decimal.TryParse(hargaTotalObat, formatHarga) Then hargaTotalObat = hargaTotalObat.ToString("N2")

                Dim statusAPI As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'status_ws_RM' ")

                ' Save ke tabel TransaksiObat
                WriteSQL("INSERT INTO TransaksiObat (NoTransaksi, ObatID, ObatNama, Jumlah, Harga, HargaTotal, Racikan, KodeRacikan, CreatedBy, CreatedDate) " & _
                                 "VALUES('" & idTransaksi & "', '" & TextBoxKodeObatNonRacikan.Text & "', '" & TextBoxNamaObatNonRacikan.Text & "', '" & TextBoxJumlahObatNonRacikan.Text & "', '" & hargaObat & "', '" & hargaTotalObat & "', 0, NULL, '" & userInput & "', GETDATE())", 4)

                ' Save ke tabel TransaksiObatNonRacikan
                WriteSQL("INSERT INTO TransaksiObatNonRacikan (NoTransaksi, ObatID, AturanPakai, Signa1, Signa2, SignaSatuan, Catatan, StatusIMM) " & _
                                 "VALUES('" & idTransaksi & "', '" & TextBoxKodeObatNonRacikan.Text & "', '" & ComboBoxAturanPakaiObatNonRacikan.Text & "', " & signa1.ToString(System.Globalization.CultureInfo.InvariantCulture) & ", " & signa2.ToString(System.Globalization.CultureInfo.InvariantCulture) & ", '" & ComboBoxSatuanSignaNonRacikan.Text & "', '" & TextBoxCatatanObatNonRacikan.Text & "', " & Convert.ToInt32(statusIMM) & ")", 4)

                If statusAPI IsNot Nothing AndAlso statusAPI = "Yes" Then
                    SendToApiObat(idTransaksi, namaObat, jumlahObat, False, "0", signa1, signa2, signaSatuan, aturanPakai, catatan, False)
                End If

                ' Save ke tabel TransaksiObatBPJS
                If Not String.IsNullOrEmpty(TextBoxKodeObatDPHO.Text) AndAlso Not String.IsNullOrEmpty(TextBoxObatDPHO.Text) Then
                    WriteSQL("INSERT INTO TransaksiObatBPJS (NoTransaksi, kdObatSK, noKunjungan, racikan, kdRacikan, obatDPHO, kdObat, signa1, signa2, signaSatuan, jmlObat, jmlPermintaan, nmObatNonDPHO, CreatedBy, CreatedDate) " & _
                             "VALUES('" & idTransaksi & "', 0, '" & noKunjunganBPJS & "', 0, NULL, 1, '" & TextBoxKodeObatDPHO.Text & "', " & signa1.ToString(System.Globalization.CultureInfo.InvariantCulture) & ", " & signa2.ToString(System.Globalization.CultureInfo.InvariantCulture) & ", '" & ComboBoxSatuanSignaNonRacikan.Text & "', " & TextBoxJumlahObatNonRacikan.Text & ", " & habisHari & ", NULL, '" & userInput & "', GETDATE())", 4)
                End If


                LoadGridResepObat()
                SaveDetailResep()
                ClearTabNonRacikan()
                SetLabelKirimResep()

                ' Kirim P-Care
                If statusBPJS = True AndAlso CheckBridgingPcareActive() = True Then SaveKunjunganBPJS()

                MsgBox("Berhasil menyimpan obat.", MsgBoxStyle.Information, "Success!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub SaveDetailResep()
        Dim queryRacikanDetail As DataTable = New DataTable
        Dim queryNonRacikanDetail As DataTable = New DataTable
        Dim stringNonRacikanHeader As String = ""
        Dim stringNonRacikanDetail As String = ""
        Dim stringRacikanHeader As String = ""
        Dim stringRacikanDetail As String = ""

        ' Set Non Racikan
        Dim TblsNonRacikan As DataTable = ReadSQL("SELECT * FROM TransaksiObat " & _
                                                  "LEFT JOIN TransaksiObatNonRacikan ON TransaksiObat.NoTransaksi = TransaksiObatNonRacikan.NoTransaksi AND TransaksiObat.ObatID = TransaksiObatNonRacikan.ObatID " & _
                                                  "WHERE TransaksiObat.NoTransaksi = '" & idTransaksi & "' AND TransaksiObat.Racikan = 0 AND TransaksiObat.DeletedDate IS NULL")

        For Each rowHeader As DataRow In TblsNonRacikan.Rows
            stringNonRacikanHeader = stringNonRacikanHeader & "- " & rowHeader("ObatNama").ToString & " [jml:" & rowHeader("Jumlah") & "] (dosis: " & rowHeader("Signa1") & "x" & rowHeader("Signa2") & ")" & vbCrLf
        Next

        ' Set Racikan
        Dim TblsRacikan As DataTable = ReadSQL("SELECT * FROM TransaksiObatRacikan WHERE NoTransaksi = '" & idTransaksi & "'")
        For Each rowHeader As DataRow In TblsRacikan.Rows
            stringRacikanDetail = ""
            queryRacikanDetail = ReadSQL("SELECT * FROM TransaksiObat WHERE NoTransaksi = '" & idTransaksi & "' AND KodeRacikan = '" & rowHeader("KodeRacikan") & "' AND Racikan = 1 AND DeletedDate IS NULL")
            For Each rowDetail As DataRow In queryRacikanDetail.Rows
                stringRacikanDetail = stringRacikanDetail & "" & rowDetail("ObatNama").ToString & " [jml:" & rowDetail("Jumlah") & "]" & ", "
            Next
            stringRacikanDetail = Strings.Left(stringRacikanDetail, stringRacikanDetail.Length - 2)

            'stringRacikanHeader = stringRacikanHeader & "- " & rowHeader("KodeRacikan") & " " & stringRacikanDetail & " [jml kapsul:" & rowHeader("JumlahKapsul") & "] (dosis: " & rowHeader("Signa1") & "x" & rowHeader("Signa2") & ")" & vbCrLf
            stringRacikanHeader = stringRacikanHeader & "- " & rowHeader("KodeRacikan") & " " & stringRacikanDetail & " (dosis: " & rowHeader("Signa1") & "x" & rowHeader("Signa2") & ")" & vbCrLf
        Next

        ' Update Keterangan Resep
        WriteSQL("UPDATE TransaksiDetail SET Resep = '" & stringNonRacikanHeader & stringRacikanHeader & "' WHERE NoUrut = '" & idTransaksi & "'", 4)
    End Sub

    Function CheckSimpanObatNonRacikan() As Boolean
        ' Validasi Obat Kosong
        If TextBoxKodeObatNonRacikan.Text.Length = 0 Then
            MsgBox("Pilih obat terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")

            Return False
        End If

        ' Validasi Aturan Pakai Obat
        If ComboBoxAturanPakaiObatNonRacikan.Text.Length = 0 Then
            MsgBox("Pilih aturan pakai terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")

            Return False
        End If

        ' Validasi Signa
        If CheckBoxSignaAktif.Checked = True Then
            If TextBoxSigna1NonRacikan.Text.Length = 0 Or TextBoxSigna2NonRacikan.Text.Length = 0 Then
                MsgBox("Lengkapi signa terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")

                Return False
            End If

            If ComboBoxSatuanSignaNonRacikan.Text.Length = 0 Then
                MsgBox("Pilih satuan signa terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")

                Return False
            End If
        End If

        ' Validasi Jumlah Obat
        If TextBoxJumlahObatNonRacikan.Text.Length = 0 Then
            MsgBox("Pilih jumlah obat terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")

            Return False
        End If

        ' Cek apakah inputan baru sudah ada di database
        If CheckSQL("SELECT * FROM TransaksiObat WHERE NoTransaksi = '" & idTransaksi & "' AND ObatID = '" & TextBoxKodeObatNonRacikan.Text & "' AND DeletedBy IS NULL") = True Then
            MsgBox("Obat yang anda pilih sudah pernah di input.", MsgBoxStyle.Exclamation, "Warning!")

            Return False
        End If

        If ValidasiObat() = False Then
            Return False
        End If

        ' Validasi Stok
        Dim TsplitObat() As String = LabelStokObatNonRacikan.Text.ToString.Split(":")
        Dim jumlahStok As Integer = TsplitObat(1).ToString.Trim

        If CDbl(TextBoxJumlahObatNonRacikan.Text) > jumlahStok Then
            MsgBox("Jumlah obat melebihi stok.", MsgBoxStyle.Exclamation, "Warning!")

            Return False
        End If

        Return True
    End Function

    Function CheckSimpanObatRacikan() As Boolean
        If ComboBoxAturanPakaiObatRacikan.Text.Length = 0 Then
            MsgBox("Pilih aturan pakai terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")

            Return False
        End If

        If TextBoxSigna1Racikan.Text.Length = 0 Or TextBoxSigna2Racikan.Text.Length = 0 Then
            MsgBox("Lengkapi signa terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")

            Return False
        End If

        If ListViewRacikanTemp.Items.Count = 0 Then
            MsgBox("Pilih obat terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")

            Return False
        End If

        Dim namaObat As String = ""
        Dim statusPenutupRacikan As Boolean = False

        For Each item As ListViewItem In ListViewRacikanTemp.Items
            ' Set Default
            namaObat = item.SubItems(2).Text

            ' Set Penutup Racikan
            If namaObat.StartsWith("POT ") = True Or namaObat.StartsWith("KAPSUL") = True Or namaObat.Contains("PUYER") = True Or namaObat.Contains("RACIKAN") = True Then
                statusPenutupRacikan = True
            End If
        Next

        If statusPenutupRacikan = False Then
            MsgBox("Tambahkan penutup racikan terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")

            Return False
        End If

        If ValidasiObat() = False Then
            Return False
        End If

        Return True
    End Function

    Private Sub TextBoxJumlahObatNonRacikan_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxJumlahObatNonRacikan.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ".") Then e.Handled = True
    End Sub

    Private Sub ButtonTambahListRacikan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTambahListRacikan.Click
        Try
            If CheckListRacikan() = True Then
                ' Menambahkan data ke dalam array
                Dim data() As String = {TextBoxKodeObatRacikan.Text, TextBoxJumlahObatRacikan.Text, TextBoxNamaObatRacikan.Text, TextBoxHargaObatRacikan.Text}

                ' Menambahkan item baru ke dalam ListView
                Dim item As New ListViewItem(data)
                ListViewRacikanTemp.Items.Add(item)

                'Clear data
                TextBoxKodeObatRacikan.ResetText()
                TextBoxNamaObatRacikan.ResetText()
                TextBoxJumlahObatRacikan.ResetText()
                TextBoxHargaObatRacikan.ResetText()
                LabelStokObatRacikan.ResetText()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Function CheckListRacikan() As Boolean
        ' Validasi Nama Obat
        If TextBoxKodeObatRacikan.Text.Length = 0 Then
            MsgBox("Pilih obat terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")

            Return False
        End If

        ' Validasi Jumlah Obat
        If TextBoxJumlahObatRacikan.Text.Length = 0 Then
            MsgBox("Pilih jumlah obat terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")

            Return False
        End If

        ' Validasi apakah inputan baru sudah ada di list racikan
        For Each item As ListViewItem In ListViewRacikanTemp.Items
            If item.SubItems(0).Text = TextBoxKodeObatRacikan.Text Then
                MsgBox("Obat yang dipilih sudah ada di dalam list.", MsgBoxStyle.Exclamation, "Warning!")

                Return False
            End If
        Next

        ' Validasi apakah inputan baru sudah ada di database
        If CheckSQL("SELECT * FROM TransaksiObat WHERE NoTransaksi = '" & idTransaksi & "' AND ObatID = '" & TextBoxKodeObatRacikan.Text & "' AND DeletedBy IS NULL") = True Then
            MsgBox("Obat yang anda pilih sudah pernah di input.", MsgBoxStyle.Exclamation, "Warning!")

            Return False
        End If

        ' Validasi Stok
        Dim TsplitObat() As String = LabelStokObatRacikan.Text.ToString.Split(":")
        Dim jumlahStok As Integer = TsplitObat(1).ToString.Trim

        If CDbl(TextBoxJumlahObatRacikan.Text) > jumlahStok Then
            MsgBox("Jumlah obat melebihi stok.", MsgBoxStyle.Exclamation, "Warning!")

            Return False
        End If

        Return True
    End Function

    Private Sub TextBoxJumlahObatRacikan_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxJumlahObatRacikan.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ".") Then e.Handled = True
    End Sub

    Private Sub PictureBoxGambar_Click(ByVal sender As System.Object, ByVal e As MouseEventArgs) Handles PictureBoxPenandaanGambar.Click
        Try
            Dim namePictureBox As PictureBox = DirectCast(sender, PictureBox)

            clickedPoint = e.Location
            Dim keterangan As String = InputBox("Masukkan keterangan pada gambar:", "Keterangan Gambar", "")
            AddLabelPictureBox(keterangan, namePictureBox)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub AddLabelPictureBox(ByVal keteranganGambar As String, ByVal pictureBox As PictureBox)
        Dim noUrut As String = ReadSQLNIK("EXEC sp_generate_no_gambar_penanda '" & idTransaksi & "', '" & pictureBox.Name & "'")

        ' Save Gambar ke Directory
        SaveImage(pictureBox, pictureBox.Name & "_" & idTransaksi & ".png")

        ' Save ke Database
        WriteSQL("INSERT INTO TransaksiDetailGambar (NoTransaksi, JenisGambar, NoUrut, Keterangan, LocationX, LocationY, CreatedBy, CreatedDate) " & _
                 "VALUES('" & idTransaksi & "', '" & pictureBox.Name & "', '" & noUrut & "', '" & keteranganGambar & "', '" & clickedPoint.X & "', '" & clickedPoint.Y & "', '" & userInput & "', GETDATE())", 4)

        ' Load All Data
        LoadGridPenandaanGambar()

        MsgBox("Data berhasil disimpan.", MsgBoxStyle.Information, "Success!")
    End Sub

    Private Sub LabelDeleteGambarPenanda_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim result As DialogResult = MessageBox.Show("Apakah Anda yakin ingin menghapus tanda ini?", "Hapus Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            Dim label As Label = DirectCast(sender, Label)

            ' Delete dari database
            Dim statusDelete As String = ReadSQLNIK("EXEC sp_delete_gambar_penanda '" & idTransaksi & "', '" & label.Tag & "', '" & label.Text & "', '" & userInput & "'")

            ' Delete dari gambar
            label.Parent.Controls.Remove(label)

            If statusDelete = "Success" Then
                Dim pictureBox As PictureBox = Me.Controls.Find(label.Tag, True).FirstOrDefault()

                ' Load ulang gambar
                LoadGridPenandaanGambar()

                ' Save Gambar ke Directory
                SaveImage(pictureBox, pictureBox.Name & "_" & idTransaksi & ".png")

                MsgBox("Berhasil menghapus data.", MsgBoxStyle.Information, "Success!")
            End If
        End If
    End Sub

    Private Sub LoadPictureBox(ByVal pictureBox As PictureBox, ByVal Tbls As DataTable)
        pictureBox.Controls.Clear()

        For Each Trow As DataRow In Tbls.Rows
            currentLabel = New Label
            currentLabel.Text = Trow("NoUrut")
            currentLabel.AutoSize = True
            currentLabel.Location = New Point(Trow("LocationX"), Trow("LocationY"))
            currentLabel.BackColor = Color.Red
            currentLabel.ForeColor = Color.White
            currentLabel.BorderStyle = BorderStyle.FixedSingle
            currentLabel.Font = New Font("Arial", 10)
            currentLabel.Tag = pictureBox.Name
            tooltip.SetToolTip(currentLabel, Trow("Keterangan"))

            AddHandler currentLabel.Click, AddressOf LabelDeleteGambarPenanda_Click
            pictureBox.Controls.Add(currentLabel)
        Next
    End Sub

    Private Sub SaveImage(ByVal pictureBox As PictureBox, ByVal txFileName As String)
        Dim mergedImage As New Bitmap(pictureBox.Width, pictureBox.Height)

        pictureBox.DrawToBitmap(mergedImage, New Rectangle(0, 0, mergedImage.Width, mergedImage.Height))

        Dim directoryPath As String = Application.StartupPath + "\FileDownload\Gambar\Penanda Operasi"
        Dim fileName As String = txFileName
        Dim filePath As String = Path.Combine(directoryPath, fileName)

        mergedImage.Save(filePath, ImageFormat.Png)
    End Sub

    Private Sub LoadGridResepObat()
        DataGridViewObat.Rows.Clear()
        DataGridViewObat.Columns.Clear()

        Dim Tbls As DataTable = ReadSQL("EXEC sp_get_obat_by_no_transaksi @NoTransaksi = '" & idTransaksi & "'")

        If Tbls.Rows.Count > 0 Then
            CreateDataGridViewObat()

            Dim signaString As String = ""
            Dim statusIMM As String = 0
            Dim hargaObatString As String = ""
            Dim hargaObatTotalString As String = ""
            Dim hargaObat As Double = 0
            Dim hargaObatTotal As Double = 0

            For Each Trow As DataRow In Tbls.Rows
                ' Default Value
                'signaString = "-"

                'If IsDBNull(Trow("KodeRacikan")) = False Then
                '    If Trow("ObatNama").ToString.StartsWith("POT ") = True Or Trow("ObatNama").ToString.StartsWith("KAPSUL") = True Or Trow("ObatNama").ToString.StartsWith("KERTAS PUYER") = True Or Trow("ObatNama").ToString.StartsWith("RACIKAN SIRUP") = True Then
                '        ' Set Signa Racikan
                '        signaString = Trow("Signa1") & "x" & Trow("Signa2") & " " & Trow("SignaSatuan")
                '    End If
                'Else
                '    ' Set Signa Non Racikan
                '    If IsDBNull(Trow("Signa1")) = False And IsDBNull(Trow("Signa2")) = False Then
                '        signaString = Trow("Signa1") & "x" & Trow("Signa2") & " " & Trow("SignaSatuan")
                '    End If
                'End If

                signaString = "-"

                If IsDBNull(Trow("KodeRacikan")) = False Then
                    ' Obat racikan → tampilkan signa (jangan bergantung nama obat)
                    If IsDBNull(Trow("Signa1")) = False And IsDBNull(Trow("Signa2")) = False Then
                        signaString = Trow("Signa1") & "x" & Trow("Signa2") & " " & Trow("SignaSatuan")
                    End If
                Else
                    ' Obat non racikan → tampilkan signa
                    If IsDBNull(Trow("Signa1")) = False And IsDBNull(Trow("Signa2")) = False Then
                        signaString = Trow("Signa1") & "x" & Trow("Signa2") & " " & Trow("SignaSatuan")
                    End If
                End If

                ' Set Harga
                hargaObat = Trow("Harga")
                hargaObatTotal = Trow("HargaTotal")
                hargaObatString = hargaObat.ToString("C2", New Globalization.CultureInfo("id-ID"))
                hargaObatTotalString = hargaObatTotal.ToString("C2", New Globalization.CultureInfo("id-ID"))

                ' Set IMM
                If Trow("StatusIMM") = "1" Then
                    statusIMM = "Ya"
                ElseIf Trow("StatusIMM") = "0" Then
                    statusIMM = "Tidak"
                End If


                DataGridViewObat.Rows.Add(New String() {"" & Trow("ObatID") & "", "" & Trow("ObatNama") & "", "" & signaString & "", "" & hargaObatString & "", "" & Trow("Jumlah") & "", "" & hargaObatTotalString & "", "" & statusIMM & "", "" & Trow("KodeRacikan") & "", "" & Trow("DPHO") & ""})
            Next

            DataGridViewObat.CurrentCell = Nothing
            DataGridViewObat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End If

        SetLabelKirimResep()
    End Sub

    Private Sub LoadGridTindakanPoli()
        DataGridViewTindakan.Rows.Clear()
        DataGridViewTindakan.Columns.Clear()

        Dim Tbls As DataTable = New DataTable

        'If jenisTransaksi = "UMUM" Or jenisTransaksi = "POLI" Then
        '    Tbls = ReadSQL("SELECT " & _
        '       "TPD.TransPoliIDDetail AS ID, " & _
        '       "TPD.TindakanID, " & _
        '       "TPD.NamaTindakan, " & _
        '       "TPD.JenisTindakan, " & _
        '       "TPD.CreatedBy, " & _
        '       "TPD.CreatedDate, " & _
        '       "TPD.StatusPembayaran, " & _
        '       "TPD.Penjamin, " & _
        '       "LPP.KodeVoucher, " & _
        '       "NULL AS Kuota " & _
        '       "FROM TransaksiPoliDetail TPD " & _
        '       "INNER JOIN TransaksiPoli TP ON TPD.TransPoliID = TP.TransPoliID " & _
        '        "OUTER APPLY ( " & _
        '        "    SELECT TOP 1 * " & _
        '        "    FROM LogPenggunaanPaket " & _
        '        "    WHERE NoTransaksi = TP.NoUrut AND DeletedDate IS NULL " & _
        '        "    ORDER BY CreatedDate DESC " & _
        '        ") LPP " & _
        '       "LEFT JOIN TransaksiPaketTindakan TPT ON LPP.KodeVoucher = TPT.KodeVoucher " & _
        '       "WHERE TPD.DeletedDate IS NULL AND TPD.Awal <> 1 AND TP.NoUrut = '" & idTransaksi & "' " & _
        '       "UNION ALL " & _
        '       "SELECT " & _
        '       "NULL AS ID, " & _
        '       "NULL AS TindakanID, " & _
        '       "TPT.NamaPaket, " & _
        '       "TPT.JenisPaket, " & _
        '       "TPBA.admin, " & _
        '       "TPBA.transaksitime, " & _
        '       "'PAID' AS StatusPembayaran, " & _
        '       "'-' AS Penjamin, " & _
        '       "LPP.KodeVoucher, " & _
        '       "TPT.Kuota " & _
        '       "FROM LogPenggunaanPaket LPP " & _
        '       "LEFT JOIN TransaksiPoli TP ON LPP.NoTransaksi = TP.NoUrut " & _
        '       "OUTER APPLY ( " & _
        '       "    SELECT TOP 1 admin, transaksitime " & _
        '       "    FROM TransaksiPoliBayarAwal " & _
        '       "    WHERE TransPoliID = TP.TransPoliID " & _
        '       "    ORDER BY transaksitime DESC " & _
        '       ") TPBA " & _
        '       "LEFT JOIN TransaksiPaketTindakan TPT ON LPP.KodeVoucher = TPT.KodeVoucher " & _
        '       "WHERE LPP.NoTransaksi = '" & idTransaksi & "' AND LPP.DeletedDate IS NULL")
        If jenisTransaksi = "UMUM" Or jenisTransaksi = "POLI" Then
            Dim filterPaketPerTindakan As Boolean = True
            Dim filterPaketReguler As Boolean = True

            Dim queryUnion1 As String = ""
            Dim queryUnion2 As String = ""
            Dim queryUnion3 As String = ""

            ' Paket Per-Tindakan dari Log
            If filterPaketPerTindakan Then
                queryUnion1 = "SELECT DISTINCT " & _
                    "NULL AS ID, " & _
                    "LPP.TindakanID, " & _
                    "TPTD.NamaTindakan, " & _
                    "TPT.JenisPaket AS JenisTindakan, " & _
                    "TPBA.admin AS CreatedBy, " & _
                    "TPBA.transaksitime AS CreatedDate, " & _
                    "'PAID' AS StatusPembayaran, '-' AS Penjamin, " & _
                    "LPP.KodeVoucher, TPTD.KuotaTindakan AS Kuota " & _
                    "FROM LogPenggunaanPaket LPP " & _
                    "LEFT JOIN TransaksiPoli TP ON LPP.NoTransaksi = TP.NoUrut " & _
                    "OUTER APPLY (SELECT TOP 1 admin, transaksitime FROM TransaksiPoliBayarAwal " & _
                    "WHERE TransPoliID = TP.TransPoliID ORDER BY transaksitime DESC) TPBA " & _
                    "INNER JOIN TransaksiPaketTindakan TPT ON LPP.KodeVoucher = TPT.KodeVoucher " & _
                    "INNER JOIN TransaksiPaketTindakanDetail TPTD " & _
                    "ON TPT.KodeVoucher = TPTD.KodeVoucher AND TPT.PaketID = TPTD.PaketID " & _
                    "AND TPTD.TindakanID = LPP.TindakanID " & _
                    "WHERE LPP.NoTransaksi = '" & idTransaksi & "' AND LPP.DeletedDate IS NULL " & _
                    "AND TPT.JenisPaket = 'Paket Per-Tindakan' AND TPT.PaketID = LPP.PaketID"
            End If

            ' Paket Reguler
            If filterPaketReguler Then
                queryUnion2 = "SELECT DISTINCT " & _
                    "TPD.TransPoliIDDetail AS ID, " & _
                    "TPD.TindakanID, " & _
                    "TPTD.NamaTindakan, " & _
                    "TPT.JenisPaket AS JenisTindakan, " & _
                    "TPBA.admin AS CreatedBy, " & _
                    "TPBA.transaksitime AS CreatedDate, " & _
                    "'PAID' AS StatusPembayaran, '-' AS Penjamin, " & _
                    "TPT.KodeVoucher, " & _
                    "TPT.Kuota AS Kuota " & _
                    "FROM TransaksiPoliDetail TPD " & _
                    "INNER JOIN TransaksiPoli TP ON TP.TransPoliID = TPD.TransPoliID " & _
                    "INNER JOIN TransaksiPaketTindakan TPT ON TPT.PaketID = TPD.PaketID AND TPT.KodeVoucher = TPD.KodeVoucher " & _
                    "LEFT JOIN TransaksiPaketTindakanDetail TPTD ON TPTD.PaketID = TPD.PaketID AND TPTD.KodeVoucher = TPD.KodeVoucher " & _
                    "OUTER APPLY (SELECT TOP 1 admin, transaksitime FROM TransaksiPoliBayarAwal " & _
                    "WHERE TransPoliID = TPD.TransPoliID ORDER BY transaksitime DESC) TPBA " & _
                    "WHERE TPT.JenisPaket = 'Paket Reguler' " & _
                    "AND TP.NoUrut = '" & idTransaksi & "' " & _
                    "AND TPD.DeletedDate IS NULL"
            End If

            ' Tindakan langsung dari TransaksiPoliDetail
            queryUnion3 = "SELECT DISTINCT " & _
                "TPD.TransPoliIDDetail AS ID, TPD.TindakanID, " & _
                "ISNULL(TPTD.NamaTindakan, TPD.NamaTindakan) AS NamaTindakan, " & _
                "TPD.JenisTindakan, TPD.CreatedBy, TPD.CreatedDate, " & _
                "TPD.StatusPembayaran, TPD.Penjamin, LPP.KodeVoucher, NULL AS Kuota " & _
                "FROM TransaksiPoliDetail TPD " & _
                "INNER JOIN TransaksiPoli TP ON TPD.TransPoliID = TP.TransPoliID " & _
                "OUTER APPLY (SELECT TOP 1 * FROM LogPenggunaanPaket " & _
                "WHERE NoTransaksi = TP.NoUrut AND DeletedDate IS NULL ORDER BY CreatedDate DESC) LPP " & _
                "LEFT JOIN TransaksiPaketTindakan TPT ON LPP.KodeVoucher = TPT.KodeVoucher " & _
                "LEFT JOIN TransaksiPaketTindakanDetail TPTD ON TPT.KodeVoucher = TPTD.KodeVoucher " & _
                "AND TPT.PaketID = TPTD.PaketID AND TPTD.TindakanID = TPD.TindakanID " & _
                "WHERE TPD.DeletedDate IS NULL AND TPD.Awal <> 1 AND TP.NoUrut = '" & idTransaksi & "'"

            ' Gabung semua bagian query sesuai filter
            Dim finalQuery As String = queryUnion3

            If filterPaketPerTindakan Then
                finalQuery &= " UNION ALL " & queryUnion1
            End If
            If filterPaketReguler Then
                finalQuery &= " UNION ALL " & queryUnion2
            End If

            ' Eksekusi
            Tbls = ReadSQL(finalQuery)
        ElseIf jenisTransaksi = "GIGI" Then
        'Tbls = ReadSQL("SELECT TransGigiIDDetail AS 'ID', TindakanID, NamaTindakan, JenisTindakan, CreatedBy, CreatedDate, StatusPembayaran, Penjamin " & _
        '               "FROM TransaksiGigiDetail " & _
        '               "WHERE DeletedDate IS NULL AND Awal <> 1 AND TransGigiID IN (SELECT TransGigiID FROM TransaksiGigi WHERE NoUrut = '" & idTransaksi & "')")
        Tbls = ReadSQL("SELECT TransGigiIDDetail AS 'ID', TindakanID, NamaTindakan, JenisTindakan, CreatedBy, CreatedDate, StatusPembayaran, Penjamin, '' AS Kuota, '' AS KodeVoucher " & _
           "FROM TransaksiGigiDetail " & _
           "WHERE DeletedDate IS NULL AND Awal <> 1 AND TransGigiID IN (SELECT TransGigiID FROM TransaksiGigi WHERE NoUrut = '" & idTransaksi & "')")

        End If

        If Tbls.Rows.Count > 0 Then
            CreateDataGridViewTindakan()

            For Each Trow As DataRow In Tbls.Rows
                DataGridViewTindakan.Rows.Add(New String() {"" & Trow("ID") & "", "" & Trow("TindakanID") & "", "" & Trow("NamaTindakan") & "", "" & Trow("JenisTindakan") & "", "" & Trow("Penjamin") & "", "" & Trow("CreatedBy") & "", "" & Format(Trow("CreatedDate"), "yyyy-MM-dd HH:mm:ss") & "", "" & Trow("StatusPembayaran") & "", "" & Trow("Kuota") & "", "" & Trow("KodeVoucher") & ""})
            Next

            DataGridViewTindakan.CurrentCell = Nothing
            DataGridViewTindakan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End If
    End Sub

    Private Sub LoadGridRiwayatDiagnosa()
        DataGridViewDiagnosa.Rows.Clear()
        DataGridViewDiagnosa.Columns.Clear()

        Dim Tbls As DataTable = ReadSQL("SELECT TransaksiDetailDiagnosa.CreatedDate, '(' + TransaksiDetailDiagnosa.KodeDiagnosa + ') ' + TransaksiDetailDiagnosa.KeteranganDiagnosa AS Diagnosa, TransaksiDetailDiagnosa.KasusDiagnosa, TransaksiDetailDiagnosa.JenisDiagnosa, TransaksiDetailDiagnosa.ElemenGigi, TransaksiDetail.JenisPoli " & _
                                        "FROM TransaksiDetailDiagnosa " & _
                                        "LEFT JOIN TransaksiDetail ON TransaksiDetailDiagnosa.NoTransaksi = TransaksiDetail.NoUrut " & _
                                        "WHERE TransaksiDetail.IDInternet = '" & idPasien & "' AND TransaksiDetailDiagnosa.NoTransaksi = '" & idTransaksi & "' AND TransaksiDetailDiagnosa.DeletedDate IS NULL")

        If Tbls.Rows.Count > 0 Then
            CreateDataGridViewDiagnosa()

            For Each Trow As DataRow In Tbls.Rows
                DataGridViewDiagnosa.Rows.Add(New String() {"" & Format(Trow("CreatedDate"), "yyyy-MM-dd HH:mm:ss") & "", "" & Trow("Diagnosa") & "", "" & Trow("KasusDiagnosa") & "", "" & Trow("JenisDiagnosa") & "", "" & Trow("ElemenGigi") & "", "" & Trow("JenisPoli") & ""})
            Next

            DataGridViewDiagnosa.CurrentCell = Nothing
            DataGridViewDiagnosa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End If
    End Sub

    Private Sub LoadGridRiwayatPemeriksaanPenunjang()
        DataGridViewPemeriksaanPenunjang.Rows.Clear()
        DataGridViewPemeriksaanPenunjang.Columns.Clear()

        Dim Tbls As DataTable = ReadSQL("SELECT TindakanID, CreateDate, NamaTindakan, JenisTindakan, BiayaTindakan, StatusPembayaran " & _
                                        "FROM TransaksiLabDetail " & _
                                        "LEFT JOIN TransaksiLab ON TransaksiLab.TransLabID = TransaksiLabDetail.TransLabID " & _
                                        "WHERE TransaksiLabDetail.NoTransaksiPoli = '" & idTransaksi & "' AND TransaksiLab.deleteddate IS NULL")

        If Tbls.Rows.Count > 0 Then
            CreateDataGridViewPemeriksaanPenunjang()

            For Each Trow As DataRow In Tbls.Rows
                DataGridViewPemeriksaanPenunjang.Rows.Add(New String() {"" & Trow("TindakanID") & "", "" & Format(Trow("CreateDate"), "yyyy-MM-dd HH:mm:ss") & "", "" & Trow("NamaTindakan") & "", "" & Trow("JenisTindakan") & "", "" & Trow("BiayaTindakan") & "", "" & Trow("StatusPembayaran") & ""})
            Next

            DataGridViewPemeriksaanPenunjang.CurrentCell = Nothing
            DataGridViewPemeriksaanPenunjang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End If
    End Sub

    Private Sub LoadGridPenandaanGambar()
        Dim pictureBox As PictureBox = Me.Controls.Find("PictureBoxPenandaanGambar", True).FirstOrDefault()

        Dim Tbls As DataTable = ReadSQL("SELECT * FROM TransaksiDetailGambar WHERE NoTransaksi = '" & idTransaksi & "' AND DeletedBy IS NULL")
        Dim Tdata As DataTable = New DataTable

        Tdata = CreateTablePenandaanGambar()
        Tdata.Rows.Clear()

        '# Load Grid
        For Each Trow As DataRow In Tbls.Rows
            Dim Tnew As DataRow = Tdata.NewRow
            Tnew("Nomor") = Trow("NoUrut")
            Tnew("Keterangan") = Trow("Keterangan")
            Tdata.Rows.Add(Tnew)
        Next

        GridControlPenandaanGambar.DataSource = Tdata
        GridView9.BestFitColumns()

        '# Load Picturebox
        LoadPictureBox(pictureBox, Tbls)
    End Sub

    Private Sub PictureBoxOdontogramObjektif_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBoxOdontogramObjektif.Click
        ' Get koordinat gambar
        Dim point As Point = PictureBoxOdontogramObjektif.PointToClient(MousePosition)

        ' Set variabel
        Dim jenisOutputOdontogram As String = ""
        Dim textOutputOdontogram As String = ""
        Dim warnaOutputOdontogram As String = ""
        Dim gambarOutputOdontogram As String = ""
        Dim statusPerBagianOdontogram As Boolean = False
        Dim nomorGigi As String = ""
        Dim namaGigi As String = ""
        Dim keteranganGigi As String = ""
        Dim bagianGigi As String = ""

        ' Set header tabel
        Dim tblsHeader As DataTable = ReadSQL("SELECT JenisOutput, TextOutput, WarnaOutput, GambarOutput, PerBagian " & _
                                              "FROM MasterOdontogramJenis " & _
                                              "WHERE Nama = '" & simbolOdontogram & "'")

        If tblsHeader.Rows.Count > 0 Then
            Dim rowHeader As DataRow = tblsHeader.Rows(0)

            statusPerBagianOdontogram = rowHeader("PerBagian")
            jenisOutputOdontogram = rowHeader("JenisOutput")
            If IsDBNull(rowHeader("TextOutput")) = False Then textOutputOdontogram = rowHeader("TextOutput")
            If IsDBNull(rowHeader("WarnaOutput")) = False Then warnaOutputOdontogram = rowHeader("WarnaOutput")
            If IsDBNull(rowHeader("GambarOutput")) = False Then gambarOutputOdontogram = rowHeader("GambarOutput")
        End If

        ' Get bagian gigi
        bagianGigi = CekKoordinatOdontogram(point, statusPerBagianOdontogram)

        Dim TblsKoordinat As DataTable = ReadSQL("SELECT * FROM MasterOdontogram WHERE NamaBagian = '" & bagianGigi & "'")

        ' ==========================================
        ' Validasi nomor gigi
        If TblsKoordinat.Rows.Count > 0 Then
            Dim rowKoordinat As DataRow = TblsKoordinat.Rows(0)
            nomorGigi = rowKoordinat("NomorGigi")
            namaGigi = rowKoordinat("NamaGigi")
            keteranganGigi = rowKoordinat("KeteranganGigi")
        Else
            MsgBox("Pilih gigi dengan benar.", MsgBoxStyle.Exclamation, "Warning!")
            Exit Sub
        End If

        ' Validasi apakah data sudah ada di tabel temporary.
        Dim rows() As DataRow = tblsTransaksiOdontogram.Select("NomorGigi = '" & nomorGigi & "'")
        If tblsTransaksiOdontogram.Rows.Count > 0 Then
            If rows.Length = 0 Then
                ' Jika nomor gigi sudah terinput di tabel temporary, maka tidak boleh di input ulang.
                ' Klik simpan dulu untuk input nomor gigi yang lain.

                MsgBox("Tidak boleh input gigi yang berbeda." & vbCr & vbLf & "Klik simpan data untuk menambahkan lainnya.", MsgBoxStyle.Exclamation, "Warning!")
                Exit Sub
            End If
        End If

        ' Cek apakah data sudah ada di database.
        If CheckSQL("SELECT * FROM TransaksiGigiOdontogramDetail WHERE NoTransaksi = '" & idTransaksi & "' AND NomorGigi = '" & nomorGigi & "' AND NamaBagian = '" & bagianGigi & "' AND Jenis = '" & simbolOdontogram & "'") = True Then
            MsgBox("Data sudah pernah diinput sebelumnya.", MsgBoxStyle.Exclamation, "Warning!")
            Exit Sub
        End If

        GroupBoxDetailTransaksiOdontogram.Enabled = True
        ' ==========================================

        ' Set value gigi header
        Dim TblsGigiHeader As DataTable = ReadSQL("SELECT * FROM TransaksiGigiOdontogramHeader WHERE NoTransaksi = '" & idTransaksi & "' AND NomorGigi = '" & nomorGigi & "'")
        If tblsTransaksiOdontogram.Rows.Count = 0 Then
            If TblsGigiHeader.Rows.Count > 0 Then
                Dim rowHeader As DataRow = TblsGigiHeader.Rows(0)
                TextBoxKeteranganOdontogram.Text = rowHeader("Keterangan").ToString
                CheckBoxMesial.Checked = rowHeader("Mesial")
                CheckBoxOcclusal.Checked = rowHeader("Occusal")
                CheckBoxDistal.Checked = rowHeader("Distal")
                CheckBoxVestibular.Checked = rowHeader("Vestibular")
                CheckBoxLingual.Checked = rowHeader("Lingual")
            Else
                TextBoxKeteranganOdontogram.ResetText()
                CheckBoxMesial.Checked = False
                CheckBoxOcclusal.Checked = False
                CheckBoxDistal.Checked = False
                CheckBoxVestibular.Checked = False
                CheckBoxLingual.Checked = False
            End If
        End If

        ' Set value gigi
        TextBoxNomorGigi.Text = nomorGigi
        LabelKeteranganGigi.Text = namaGigi & " - " & keteranganGigi

        Dim Tbls As DataTable = ReadSQL("SELECT * FROM MasterOdontogramDetail WHERE NamaBagian = '" & bagianGigi & "'")
        For Each Trow As DataRow In Tbls.Rows
            ' Mengkonversi gambar menjadi Bitmap 
            Dim originalImage As Bitmap = DirectCast(PictureBoxOdontogramObjektif.Image, Bitmap)
            Dim fontOdontogram As New Font("Arial", 7, FontStyle.Bold)
            Dim colorText As String = ""

            ' Membuat salinan gambar asli
            Dim updatedImage As New Bitmap(originalImage)

            If jenisOutputOdontogram.Contains("Text Atas") And Trow("JenisBagian").ToString = "Text Atas" Then
                ShapeDrawingFunctions.DrawText(updatedImage, Trow("x1"), Trow("y1"), textOutputOdontogram, fontOdontogram, Color.Black)
            ElseIf jenisOutputOdontogram.Contains("Text Bawah") And Trow("JenisBagian").ToString = "Text Bawah" Then
                ShapeDrawingFunctions.DrawText(updatedImage, Trow("x1"), Trow("y1"), textOutputOdontogram, fontOdontogram, Color.Black)
            ElseIf jenisOutputOdontogram = "Warna" Then
                colorText = warnaOutputOdontogram
                Dim fillColor As Color = ColorTranslator.FromHtml(colorText)

                If Trow("JenisBagian").ToString = "Persegi" Then
                    DrawSquare(updatedImage, Trow("x1"), Trow("y1"), Trow("x2"), Trow("y2"), fillColor, Color.Black)
                ElseIf Trow("JenisBagian").ToString = "Trapesium" Then
                    ShapeDrawingFunctions.DrawTrapezium(updatedImage, Trow("x1"), Trow("y1"), Trow("x2"), Trow("y2"), Trow("x3"), Trow("y3"), Trow("x4"), Trow("y4"), fillColor, Color.Black)
                ElseIf Trow("JenisBagian").ToString = "Segitiga" Then
                    ShapeDrawingFunctions.DrawTriangle(updatedImage, Trow("x1"), Trow("y1"), Trow("x2"), Trow("y2"), Trow("x3"), Trow("y3"), fillColor, Color.Black)
                End If
            ElseIf jenisOutputOdontogram.Contains("Gambar") And gambarOutputOdontogram.Contains(Trow("JenisBagian").ToString) Then
                startPoint1 = New Point(Trow("x1"), Trow("y1"))
                endPoint1 = New Point(Trow("x2"), Trow("y2"))
                startPoint2 = New Point(Trow("x3"), Trow("y3"))
                endPoint2 = New Point(Trow("x4"), Trow("y4"))

                If Trow("JenisBagian").ToString = "Pagar" Then
                    fontOdontogram = New Font("Arial", 28, FontStyle.Regular)
                    ShapeDrawingFunctions.DrawText(updatedImage, Trow("x1"), Trow("y1"), "#", fontOdontogram, Color.Black)
                ElseIf Trow("JenisBagian").ToString = "V Bawah" Then
                    fontOdontogram = New Font("Arial", 16, FontStyle.Regular)
                    ShapeDrawingFunctions.DrawText(updatedImage, Trow("x1"), Trow("y1"), "V", fontOdontogram, Color.Black)
                ElseIf Trow("JenisBagian").ToString = "V Tengah" Then
                    ShapeDrawingFunctions.DrawLines(updatedImage, startPoint1, endPoint1, startPoint2, endPoint2, Color.Black, 3)
                ElseIf Trow("JenisBagian").ToString = "X Tengah" Then
                    ShapeDrawingFunctions.DrawLines(updatedImage, startPoint1, endPoint1, startPoint2, endPoint2, Color.Black, 3)
                ElseIf Trow("JenisBagian").ToString = "Segitiga Bawah" Then
                    ShapeDrawingFunctions.DrawTriangle(updatedImage, Trow("x1"), Trow("y1"), Trow("x2"), Trow("y2"), Trow("x3"), Trow("y3"), Color.Black, Color.Black)
                ElseIf Trow("JenisBagian").ToString = "Sisi Persegi" Then
                    ShapeDrawingFunctions.DrawColoredRectangle(updatedImage, Trow("x1"), Trow("y1"), Trow("x2"), Trow("y2"), 4)
                ElseIf Trow("JenisBagian").ToString = "Persegi Arsir Vertikal" Then
                    ShapeDrawingFunctions.DrawColoredRectangleWithVerticalHatch(updatedImage, Trow("x1"), Trow("y1"), Trow("x2"), Trow("y2"), Color.Black)
                ElseIf Trow("JenisBagian").ToString = "Garis Lurus Atas" Then
                    ShapeDrawingFunctions.DrawLines(updatedImage, startPoint1, endPoint1, startPoint2, endPoint2, Color.Black, 3)
                End If
            End If

            ' Menampilkan gambar yang telah diperbarui
            PictureBoxOdontogramObjektif.Image = updatedImage
        Next

        ' Save ke tabel temporary
        If simbolOdontogram <> "" Then
            ' Memeriksa apakah data sudah ada dalam DataTable
            Dim existingRows() As DataRow = tblsTransaksiOdontogram.Select("NomorGigi = '" & nomorGigi & "' AND Jenis = '" & simbolOdontogram & "' AND NamaBagian = '" & bagianGigi & "'")

            If existingRows.Length = 0 Then
                Dim addData As DataRow = tblsTransaksiOdontogram.NewRow
                addData("NomorGigi") = nomorGigi
                addData("NamaBagian") = bagianGigi
                addData("Jenis") = simbolOdontogram
                tblsTransaksiOdontogram.Rows.Add(addData)
            End If
        End If
    End Sub

    Public Sub LoadTindakanOdontogram(ByRef Trow As DataRowView, ByRef Jenis As String)
        'If Jenis = "Tindakan" Then
        '    ButtonFindTindakanGigi.Text = Trow("TindakanID")
        '    LabelTindakanGigi.Text = Trow("NamaTindakan") & " | " & Trow("JenisTindakan")
        '    TextBoxHargaTindakanGigi.Text = Trow("BiayaTindakan")
        'End If

        If Jenis = "Simbol" Then
            simbolOdontogram = Trow("Nama")
            ButtonFindSimbolGigi.Text = Trow("Nama")
            LabelSimbolGigi.Text = Trow("Arti")
            PictureBoxPreviewSimbol.ImageLocation = Application.StartupPath & "\Image\template\BagianOdontogram\" & Trow("Nama") & ".png"
        End If
    End Sub

    Private Function FormatPecahanNominal(ByVal nominal As Integer) As String
        Dim formattedNominal As String = "Rp " & nominal.ToString("N0")
        Return formattedNominal
    End Function

    Private Function CekKoordinatOdontogram(ByVal point As Point, ByVal perBagian As Boolean) As String
        Dim valAngka As String = ReadSQLNIK("SELECT NamaBagian FROM MasterOdontogram WHERE PerBagian = " & If(perBagian, 1, 0) & " AND " & point.X & " >= X AND " & point.X & " <= X + Width AND " & point.Y & " >= Y AND " & point.Y & " <= Y + Height")

        Return valAngka.ToString()
    End Function

    Private Sub PictureBox1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBox1.Paint
        'Dim graphics As Graphics = e.Graphics

        'Dim tblsOdontogram As DataTable = New DataTable
        'tblsOdontogram = ReadSQL("SELECT * FROM MasterOdontogram WHERE PerBagian = 1")

        'For Each Trow As DataRow In tblsOdontogram.Rows
        '    Dim rectangle As New Rectangle(Trow("X"), Trow("Y"), Trow("Width"), Trow("Height"))
        '    graphics.DrawRectangle(Pens.Blue, rectangle)
        'Next

        ' Odontogram Baris Ke-1
        'Dim rectangle1 As New Rectangle(153, 98, 33, 33)
        'graphics.DrawRectangle(Pens.Blue, rectangle1)

        'Dim rectangle2 As New Rectangle(201, 98, 33, 33)
        'graphics.DrawRectangle(Pens.Blue, rectangle2)

        'Dim rectangle3 As New Rectangle(247, 98, 33, 33)
        'graphics.DrawRectangle(Pens.Blue, rectangle3)

        'Dim rectangle4 As New Rectangle(294, 98, 33, 33)
        'graphics.DrawRectangle(Pens.Blue, rectangle4)

        'Dim rectangle5 As New Rectangle(340, 98, 33, 33)
        'graphics.DrawRectangle(Pens.Blue, rectangle5)

        'Dim rectangle1 As New Rectangle(12, 10, 33, 33)
        'Dim pen As New Pen(Color.Blue, 3) ' Menentukan ketebalan garis (misalnya 3 piksel)
        'graphics.DrawRectangle(pen, rectangle1)

        'Dim rectangle1 As New Rectangle(12, 10, 33, 33)
        'Dim hatchBrush As New HatchBrush(HatchStyle.Vertical, Color.Blue, Color.White) ' Menentukan jenis arsiran dan warna arsiran
        'graphics.FillRectangle(hatchBrush, rectangle1)

        'Dim g As Graphics = e.Graphics
        'Dim pen As New Pen(Color.Black, 2) ' Warna dan lebar garis

        '' Titik awal dan titik akhir untuk garis pertama
        'Dim startPoint1 As New Point(10, 10)
        'Dim endPoint1 As New Point(PictureBox1.Width \ 2, PictureBox1.Height \ 2)

        '' Titik awal dan titik akhir untuk garis kedua
        'Dim startPoint2 As New Point(PictureBox1.Width \ 2, PictureBox1.Height \ 2)
        'Dim endPoint2 As New Point(PictureBox1.Width - 10, 10)

        '' Menggambar garis pertama
        'g.DrawLine(pen, startPoint1, endPoint1)

        '' Menggambar garis kedua
        'g.DrawLine(pen, startPoint2, endPoint2)
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        'DrawColoredTriangle1(32, 55, 8, 8)
        'DrawColoredTriangle2(32, 41, 8, 8)
        'DrawColoredRectangle(32, 41, 8, 14)

        ' Garis miring arsir
        'DrawColoredRectangleWithHatch(10, 10, 100, 100, Color.Blue, 10)

        ' Garis vertikal arsir
        'DrawColoredRectangleWithVerticalHatch(12, 10, 33, 33, Color.Black)

        ' Gambar Trapezium
        'DrawTrapezium(50, 150, 200, 50, 100, Color.Yellow, Color.Black)

        'Dim image As Bitmap = CType(PictureBox1.Image, Bitmap)
        'Dim font As New Font("Arial", 7, FontStyle.Bold)
        'DrawText(image, 28, 5, "UNE", font, Color.Black)
        'PictureBox1.Image = image

        'Dim image As Bitmap = CType(PictureBox1.Image, Bitmap)
        'Dim font As New Font("Arial", 28, FontStyle.Regular)
        'DrawText(image, 30, 30, "#", font, Color.Black)
        'PictureBox1.Image = image

        'Dim image As Bitmap = CType(PictureBox1.Image, Bitmap)

        'Dim startPoint1 As New Point(19, 4)
        'Dim endPoint1 As New Point(38, 49)

        'Dim startPoint2 As New Point(38, 4)
        'Dim endPoint2 As New Point(19, 49)

        '' Panggil fungsi DrawLines untuk menggambar garis-garis pada gambar
        'DrawLines(image, startPoint1, endPoint1, startPoint2, endPoint2, Color.Black, 3)

        '' Menampilkan gambar hasil
        'PictureBox1.Image = image

        'Dim image As Bitmap = CType(PictureBox1.Image, Bitmap)
        'ShapeDrawingFunctions.DrawTriangle(image, 22, 43, 35, 43, 28, 56, Color.Black, Color.Black)
        'PictureBox1.Image = image
    End Sub

    Private Sub DrawColoredRectangleWithHatch(ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal hatchColor As Color, ByVal hatchSpacing As Integer)
        ' DrawColoredRectangleWithHatch(10, 10, 100, 100, Color.Blue, 10)
        ' Mendapatkan gambar odontogram dari PictureBox
        Dim odontoImage As Image = PictureBox1.Image

        ' Mengecek apakah gambar odontogram sudah ada
        If odontoImage IsNot Nothing Then
            ' Membuat salinan gambar odontogram
            Dim updatedImage As New Bitmap(odontoImage)

            ' Menggambar bidang warna pada gambar odontogram
            Using g As Graphics = Graphics.FromImage(updatedImage)
                ' Menggambar persegi panjang dengan arsiran di tengah
                Using hatchBrush As New HatchBrush(HatchStyle.ForwardDiagonal, hatchColor, Color.Transparent)
                    Dim numLinesHorizontal As Integer = width \ hatchSpacing ' Jumlah garis arsiran secara horizontal
                    Dim numLinesVertical As Integer = height \ hatchSpacing ' Jumlah garis arsiran secara vertical

                    ' Menggambar garis arsiran secara horizontal
                    For i As Integer = 0 To numLinesHorizontal - 1
                        Dim hatchX As Integer = x + i * hatchSpacing
                        Dim hatchY As Integer = y
                        Dim hatchWidth As Integer = hatchSpacing
                        Dim hatchHeight As Integer = height
                        Dim hatchRectangle As New Rectangle(hatchX, hatchY, hatchWidth, hatchHeight)
                        g.FillRectangle(hatchBrush, hatchRectangle)
                    Next

                    ' Menggambar garis arsiran secara vertical
                    For i As Integer = 0 To numLinesVertical - 1
                        Dim hatchX As Integer = x
                        Dim hatchY As Integer = y + i * hatchSpacing
                        Dim hatchWidth As Integer = width
                        Dim hatchHeight As Integer = hatchSpacing
                        Dim hatchRectangle As New Rectangle(hatchX, hatchY, hatchWidth, hatchHeight)
                        g.FillRectangle(hatchBrush, hatchRectangle)
                    Next
                End Using
            End Using

            ' Menampilkan gambar odontogram yang telah diperbarui
            PictureBox1.Image = updatedImage
        End If
    End Sub

    Private Sub ButtonSavePemeriksaanAwal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSavePemeriksaanAwal.Click
        SavePemeriksaanAwal()
    End Sub

    Private Sub LoadComboBoxStatusPulang()
        Dim tbls As DataTable = New DataTable

        tbls = ReadSQL("SELECT KodeStatusPulang, NamaStatusPulang FROM MasterStatusPulang WHERE StatusPulang = 'False'")

        If tbls.Rows.Count > 0 Then
            ' Mendeklarasikan List<KeyValuePair(Of Integer, String)>
            Dim dataItems As New List(Of KeyValuePair(Of String, String))

            ' Mendeklarasikan AutoCompleteStringCollection
            Dim autoCompleteData As New AutoCompleteStringCollection()

            For Each Trow As DataRow In tbls.Rows
                ' Menambahkan keterangan ke dalam AutoCompleteStringCollection
                autoCompleteData.Add(Trow("NamaStatusPulang").ToString())

                ' Menambahkan pasangan nilai ID dan keterangan ke dalam List
                dataItems.Add(New KeyValuePair(Of String, String)(Trow("KodeStatusPulang"), Trow("NamaStatusPulang")))
            Next

            ' Menghubungkan dataItems ke ComboBox
            ComboBoxStatusPulang.DataSource = dataItems
            ComboBoxStatusPulang.DisplayMember = "Value" ' Menampilkan keterangan sebagai teks yang ditampilkan di ComboBox
            ComboBoxStatusPulang.ValueMember = "Key" ' Menyimpan ID sebagai nilai yang terkait dengan item yang dipilih

            ' Mengatur AutoCompleteCustomSource ke koleksi yang telah diisi
            ComboBoxStatusPulang.AutoCompleteCustomSource = autoCompleteData
            ComboBoxStatusPulang.Text = "Berobat Jalan"
        End If
    End Sub

    Private Sub LoadComboBoxPoliTujuan()
        ' Set ComboBox Poli Tujuan
        ComboBoxPoliTujuan.Items.Clear()
        ComboBoxPoliTujuan.Items.Add("SEMUA TRANSAKSI")
        Dim tblsPoliTujuan As DataTable = ReadSQL("SELECT * FROM MasterPoliTujuan WHERE PoliSakit = 'True'")
        For Each TrowPoliTujuan As DataRow In tblsPoliTujuan.Rows
            ComboBoxPoliTujuan.Items.Add(TrowPoliTujuan("NamaPoli"))
        Next
        ComboBoxPoliTujuan.SelectedIndex = -1
    End Sub


    Private Sub LoadComboBoxPoliGambar()
        ' Set ComboBox Poli Tujuan
        ComboBoxPoliGambar.Items.Clear()
        ComboBoxPoliGambar.Items.Add("SEMUA TRANSAKSI")
        Dim tblsPoliTujuan As DataTable = ReadSQL("SELECT * FROM MasterPoliTujuan WHERE PoliSakit = 'True'")
        For Each TrowPoliTujuan As DataRow In tblsPoliTujuan.Rows
            ComboBoxPoliGambar.Items.Add(TrowPoliTujuan("NamaPoli"))
        Next
        ComboBoxPoliGambar.SelectedIndex = -1
    End Sub

    Private Sub LoadComboBoxPrognosa()
        Dim tbls As DataTable = New DataTable

        tbls = ReadSQL("SELECT * FROM Klinik_MasterPrognosa")

        If tbls.Rows.Count > 0 Then
            ' Mendeklarasikan List<KeyValuePair(Of Integer, String)>
            Dim dataItems As New List(Of KeyValuePair(Of String, String))

            ' Mendeklarasikan AutoCompleteStringCollection
            Dim autoCompleteData As New AutoCompleteStringCollection()

            For Each Trow As DataRow In tbls.Rows
                ' Menambahkan keterangan ke dalam AutoCompleteStringCollection
                autoCompleteData.Add(Trow("KeteranganPrognosa").ToString())

                ' Menambahkan pasangan nilai ID dan keterangan ke dalam List
                dataItems.Add(New KeyValuePair(Of String, String)(Trow("KodePrognosa"), Trow("KeteranganPrognosa")))
            Next

            ' Menghubungkan dataItems ke ComboBox
            ComboBoxPrognosa.DataSource = dataItems
            ComboBoxPrognosa.DisplayMember = "Value" ' Menampilkan keterangan sebagai teks yang ditampilkan di ComboBox
            ComboBoxPrognosa.ValueMember = "Key" ' Menyimpan ID sebagai nilai yang terkait dengan item yang dipilih

            ' Mengatur AutoCompleteCustomSource ke koleksi yang telah diisi
            ComboBoxPrognosa.AutoCompleteCustomSource = autoCompleteData
            ComboBoxPrognosa.SelectedIndex = -1
            'ComboBoxPrognosa.Text = "Sanam (Sembuh)"
        End If
    End Sub

    Private Sub InsertSpesialisToDatabaseLokal()
        Dim getResponse As String = ""
        Dim messageError As String = ""
        Dim uri As String = urlPcare + "spesialis"

        getResponse = getDataFromPcare(uri)

        If getResponse <> "Nothing" Then
            Dim varsespoli() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of varJson())(getResponse)

            For Each oneVar As varJson In varsespoli
                For index As Integer = 0 To oneVar.response.count - 1
                    If oneVar.metaData.message <> "NO_CONTENT" Then
                        WriteSQL("INSERT INTO MasterRujukanSpesialis (JenisRujukan, Kode, Keterangan) " & _
                                 "VALUES('Spesialis', '" & oneVar.response.list(index).kdSpesialis & "', '" & oneVar.response.list(index).nmSpesialis & "')", 4)
                    Else
                        messageError = oneVar.metaData.message
                        Exit For
                    End If
                Next
            Next
        Else
            MsgBox("Data tidak ditemukan.", MsgBoxStyle.Critical, "Warning!")
        End If
    End Sub

    Private Sub InsertSubSpesialisToDatabaseLokal()
        Dim tbls As DataTable = New DataTable

        tbls = ReadSQL("SELECT Kode, Keterangan FROM MasterRujukanSpesialis WHERE JenisRujukan = 'Spesialis'")

        If tbls.Rows.Count > 0 Then
            For Each Trow As DataRow In tbls.Rows
                Dim getResponse As String = ""
                Dim messageError As String = ""
                Dim uri As String = urlPcare + "spesialis/" & Trow("Kode") & "/subspesialis"

                getResponse = getDataFromPcare(uri)

                If getResponse <> "Nothing" Then
                    Dim varsespoli() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of varJson())(getResponse)

                    For Each oneVar As varJson In varsespoli
                        For index As Integer = 0 To oneVar.response.count - 1
                            If oneVar.metaData.message <> "NO_CONTENT" Then
                                WriteSQL("INSERT INTO MasterRujukanSubSpesialis (KodeSpesialis, KodePoliRujuk, KodeSub, Keterangan) " & _
                                         "VALUES('" & Trow("Kode") & "', '" & oneVar.response.list(index).kdPoliRujuk & "', '" & oneVar.response.list(index).kdSubSpesialis & "', '" & oneVar.response.list(index).nmSubSpesialis & "')", 4)
                            Else
                                messageError = oneVar.metaData.message
                                Exit For
                            End If
                        Next
                    Next
                Else
                    MsgBox("Data tidak ditemukan.", MsgBoxStyle.Critical, "Warning!")
                End If
            Next
        End If
    End Sub

    Private Sub InsertSaranaToDatabaseLokal()
        Dim getResponse As String = ""
        Dim messageError As String = ""
        Dim uri As String = urlPcare + "spesialis/sarana"

        getResponse = getDataFromPcare(uri)

        If getResponse <> "Nothing" Then
            Dim varsespoli() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of varJson())(getResponse)

            For Each oneVar As varJson In varsespoli
                For index As Integer = 0 To oneVar.response.count - 1
                    If oneVar.metaData.message <> "NO_CONTENT" Then
                        WriteSQL("INSERT INTO MasterRujukanSarana (KodeSarana, Keterangan) " & _
                                 "VALUES('" & oneVar.response.list(index).kdSarana & "', '" & oneVar.response.list(index).nmSarana & "')", 4)
                    Else
                        messageError = oneVar.metaData.message
                        Exit For
                    End If
                Next
            Next
        Else
            MsgBox("Data tidak ditemukan.", MsgBoxStyle.Critical, "Warning!")
        End If
    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        InsertSaranaToDatabaseLokal()
    End Sub

    Private Sub InsertObatBPJS()
        Dim getResponse As String = ""
        Dim messageError As String = ""
        Dim uri As String = urlPcare + "obat/dpho/a/1/2"

        getResponse = getDataFromPcare(uri)

        If getResponse <> "Nothing" Then
            Dim varsespoli() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of varJson())(getResponse)

            For Each oneVar As varJson In varsespoli
                For index As Integer = 0 To oneVar.response.count - 1
                    If oneVar.metaData.message <> "NO_CONTENT" Then
                        WriteSQL("INSERT INTO _MasterObatBPJS (kdObat, nmObat) " & _
                                 "VALUES('" & oneVar.response.list(index).kdObat & "', '" & oneVar.response.list(index).nmObat & "')", 4)
                    Else
                        messageError = oneVar.metaData.message
                        Exit For
                    End If
                Next
            Next
        Else
            MsgBox("Data tidak ditemukan.", MsgBoxStyle.Critical, "Warning!")
        End If
    End Sub

    Private Sub SetNilaiResikoJatuh(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonPertanyaan1Pilihan1RJ.CheckedChanged, RadioButtonPertanyaan1Pilihan2RJ.CheckedChanged, RadioButtonPertanyaan2Pilihan1RJ.CheckedChanged, RadioButtonPertanyaan2Pilihan2RJ.CheckedChanged
        HitungNilaiResikoJatuh()
    End Sub

    Private Sub TimerNotifikasi_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerNotifikasi.Tick
        If TextBoxNotifikasi.Visible = False Then
            PanelNotifikasi.Visible = True
            PictureBoxNotifikasi.BackColor = Color.FromArgb(236, 100, 75)
            TextBoxNotifikasi.BackColor = Color.FromArgb(236, 100, 75)
            TextBoxNotifikasi.ForeColor = Color.White
        Else
            PanelNotifikasi.Visible = False
        End If
    End Sub

    Private Sub ComboBoxJenisSuratKeterangan_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxJenisSuratKeterangan.SelectedIndexChanged
        If ComboBoxJenisSuratKeterangan.Text = "SURAT KETERANGAN DOKTER" Then
            TabControlSuratKeterangan.SelectedTab = TabPageSuratKeteranganDokter
        ElseIf ComboBoxJenisSuratKeterangan.Text = "SURAT KETERANGAN ISTIRAHAT" Then
            TabControlSuratKeterangan.SelectedTab = TabPageSuratKeteranganIstirahat
        ElseIf ComboBoxJenisSuratKeterangan.Text = "SURAT KETERANGAN BEROBAT" Then
            TabControlSuratKeterangan.SelectedTab = TabPageSuratKeteranganBerobat
        ElseIf ComboBoxJenisSuratKeterangan.Text = "SURAT KETERANGAN CUTI HAMIL" Then
            TabControlSuratKeterangan.SelectedTab = TabPageSuratKeteranganCutiHamil
        ElseIf ComboBoxJenisSuratKeterangan.Text = "SURAT KETERANGAN KEMATIAN" Then
            TabControlSuratKeterangan.SelectedTab = TabPageSuratKeteranganKematian
        ElseIf ComboBoxJenisSuratKeterangan.Text = "SURAT KETERANGAN KHITAN" Then
            TabControlSuratKeterangan.SelectedTab = TabPageSuratKeteranganKhitan
        ElseIf ComboBoxJenisSuratKeterangan.Text = "SURAT KETERANGAN LAYAK TERBANG" Then
            TabControlSuratKeterangan.SelectedTab = TabPageSuratKeteranganLayakTerbang
        ElseIf ComboBoxJenisSuratKeterangan.Text = "SURAT KETERANGAN KONTROL" Then
            TabControlSuratKeterangan.SelectedTab = TabPageSuratKeteranganKontrol
        ElseIf ComboBoxJenisSuratKeterangan.Text = "SURAT KETERANGAN PERSETUJUAN RUJUKAN" Then
            TabControlSuratKeterangan.SelectedTab = TabPageSuratPersetujuanRujukan
        End If
    End Sub

    Private Sub ComboBoxButaWarna_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ComboBoxButaWarnaSuratSehat.Validating
        If Not IsComboBoxItemValid(DirectCast(sender, System.Windows.Forms.ComboBox)) Then
            MsgBox("Data yang dimasukkan tidak valid. Silakan pilih item dari daftar yang tersedia.", MsgBoxStyle.Exclamation, "Warning!")
            e.Cancel = True
        End If
    End Sub

    Private Sub ComboBoxButaWarna_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxButaWarnaSuratSehat.SelectedIndexChanged
        If ComboBoxButaWarnaSuratSehat.Text = "Partial" Then
            TextBoxKeteranganButaWarnaSuratSehat.Enabled = True
        Else
            TextBoxKeteranganButaWarnaSuratSehat.Enabled = False
        End If

        TextBoxKeteranganButaWarnaSuratSehat.ResetText()
    End Sub

    Function ValidasiInputSuratKeterangan(ByRef namaSurat As String) As Boolean
        ' Cek Pemeriksaan Fisik
        If CheckSQL("SELECT * FROM TransaksiDetailFisik WHERE NoTransaksi = '" & idTransaksi & "'") = False Then
            MsgBox("Isi pemeriksaan fisik terlebih dahulu.", MsgBoxStyle.Critical, "Warning!")

            Return False
        End If

        ' Cek Diagnosa
        If CheckSQL("SELECT * FROM TransaksiDetailDiagnosa WHERE NoTransaksi = '" & idTransaksi & "'") = False Then
            MsgBox("Isi diagnosa terlebih dahulu.", MsgBoxStyle.Critical, "Warning!")

            Return False
        End If

        Select Case namaSurat
            Case "SURAT KETERANGAN DOKTER"
                ' Validasi kolom buta warna
                If ComboBoxButaWarnaSuratSehat.Text.Length = 0 Then
                    MsgBox("Kolom buta warna wajib terisi.", MsgBoxStyle.Critical, "Warning!")
                    Return False
                End If

                ' Validasi kolom keterangan buta warna
                If ComboBoxButaWarnaSuratSehat.Text = "Partial" And TextBoxKeteranganButaWarnaSuratSehat.Text.Length = 0 Then
                    MsgBox("Kolom keterangan buta warna wajib terisi jika memilih partial.", MsgBoxStyle.Critical, "Warning!")
                    Return False
                End If

                ' Validasi kolom tujuan
                If TextBoxTujuanSuratDokter.Text.Length = 0 Then
                    MsgBox("Kolom tujuan wajib terisi.", MsgBoxStyle.Critical, "Warning!")
                    Return False
                End If
            Case "SURAT KETERANGAN ISTIRAHAT"
                ' Validasi Tanggal
                If TanggalMulaiSuratKeteranganIstirahat.Value.Date > TanggalAkhirSuratKeteranganIstirahat.Value.Date Then
                    MsgBox("Tanggal akhir tidak boleh melebihi tanggal awal.", MsgBoxStyle.Critical, "Warning!")
                    Return False
                End If

                ' Validasi Tanggal
                If TanggalMulaiSuratKeteranganIstirahat.Value.Date < DateTime.Now.Date Then
                    MsgBox("Tanggal awal tidak boleh kurang dari tanggal sekarang.", MsgBoxStyle.Critical, "Warning!")
                    Return False
                End If

                ' Validasi kolom diagnosa
                If TextBoxDiagnosaSuratIstirahat.Text.Length = 0 Then
                    MsgBox("Kolom diagnosa wajib terisi.", MsgBoxStyle.Critical, "Warning!")
                    Return False
                End If
            Case "SURAT KETERANGAN CUTI HAMIL"
                ' Validasi Tanggal
                If TanggalMulaiSuratKeteranganCutiHamil.Value.Date > TanggalAkhirSuratKeteranganCutiHamil.Value.Date Then
                    MsgBox("Tanggal akhir tidak boleh melebihi tanggal awal.", MsgBoxStyle.Critical, "Warning!")
                    Return False
                End If

                ' Validasi Inputan GPA
                If TextBoxDiagnosisGravidaSuratKeteranganCutiHamil.Text.Trim = "" Or TextBoxDiagnosisParaSuratKeteranganCutiHamil.Text.Trim = "" Or TextBoxDiagnosisAbortusSuratKeteranganCutiHamil.Text.Trim = "" Then
                    MsgBox("Kolom GPA wajib terisi.", MsgBoxStyle.Critical, "Warning!")
                    Return False
                End If

                ' Validasi Inputan Usia Kehamilan
                If TextBoxUsiaKehamilanSuratKeteranganCutiHamil.Text.Trim = "" Then
                    MsgBox("Kolom usia kehamilan wajib terisi.", MsgBoxStyle.Critical, "Warning!")
                    Return False
                End If
            Case "SURAT KETERANGAN KEMATIAN"
                ' Cek isian kolom diagnosa
                If TextBoxDiagnosaSuratKematian.Text.Length = 0 Then
                    MsgBox("Kolom diagnosa wajib terisi.", MsgBoxStyle.Critical, "Warning!")

                    Return False
                End If

                ' Cek isian kolom penyebab kematian
                If TextBoxSebabKematian.Text.Length = 0 Then
                    MsgBox("Kolom penyebab kematian wajib terisi.", MsgBoxStyle.Critical, "Warning!")

                    Return False
                End If
            Case "SURAT KETERANGAN KHITAN"
                ' Tambah jika ada
            Case "SURAT KETERANGAN LAYAK TERBANG"
                ' Cek isian kolom diagnosa
                If TextBoxDiagnosaSuratLayakTerbang.Text.Length = 0 Then
                    MsgBox("Kolom diagnosa wajib terisi.", MsgBoxStyle.Critical, "Warning!")

                    Return False
                End If
            Case "SURAT KETERANGAN BEROBAT"
                ' Validasi kolom diagnosa
                If TextBoxDiagnosaSuratBerobat.Text.Length = 0 Then
                    MsgBox("Kolom diagnosa wajib terisi.", MsgBoxStyle.Critical, "Warning!")
                    Return False
                End If
        End Select

        Return True
    End Function

    Function GenerateNomorSurat(ByRef namaSurat As String) As String
        Dim NoSurat As String = ""
        Dim nomorUrut As String = ""
        Dim kodeLokasiSurat As String = ReadSQLNIK("select StrValue from MsConfig where ConfigName='KodeInvoicePoli'")
        Dim kodeTanggalSurat As String = "/" & GetRomes(DateAndTime.Now.Month) & "/" & Format(DateAndTime.Now, "yyyy")

        ' Get Kode Surat
        Dim kodeSurat As String = ReadSQLNIK("SELECT KodeDokumen FROM MasterDokumen WHERE NamaDokumen = '" & namaSurat & "'")

        If namaSurat = "SURAT KETERANGAN DOKTER" Then
            nomorUrut = ReadSQLNIK("SELECT LEFT(MAX(NoSurat), 4) AS Number FROM SuratKeteranganDokter WHERE NoSurat LIKE '%" & kodeTanggalSurat & "%'")
        ElseIf namaSurat = "SURAT KETERANGAN ISTIRAHAT" Then
            nomorUrut = ReadSQLNIK("SELECT LEFT(MAX(NoSurat), 4) AS Number FROM SuratKeteranganIstirahat WHERE NoSurat LIKE '%" & kodeTanggalSurat & "%'")
        ElseIf namaSurat = "SURAT KETERANGAN BEROBAT" Then
            nomorUrut = ReadSQLNIK("SELECT LEFT(MAX(NoSurat), 4) AS Number FROM SuratKeteranganBerobat WHERE NoSurat LIKE '%" & kodeTanggalSurat & "%'")
        ElseIf namaSurat = "SURAT KETERANGAN CUTI HAMIL" Then
            nomorUrut = ReadSQLNIK("SELECT LEFT(MAX(NoSurat), 4) AS Number FROM SuratKeteranganCutiHamil WHERE NoSurat LIKE '%" & kodeTanggalSurat & "%'")
        ElseIf namaSurat = "SURAT KETERANGAN KEMATIAN" Then
            nomorUrut = ReadSQLNIK("SELECT LEFT(MAX(NoSurat), 4) AS Number FROM SuratKeteranganKematian WHERE NoSurat LIKE '%" & kodeTanggalSurat & "%'")
        ElseIf namaSurat = "SURAT KETERANGAN LAYAK TERBANG" Then
            nomorUrut = ReadSQLNIK("SELECT LEFT(MAX(NoSurat), 4) AS Number FROM SuratKeteranganLayakTerbang WHERE NoSurat LIKE '%" & kodeTanggalSurat & "%'")
        ElseIf namaSurat = "SURAT KETERANGAN KHITAN" Then
            nomorUrut = ReadSQLNIK("SELECT LEFT(MAX(NoSurat), 4) AS Number FROM SuratKeteranganKhitan WHERE NoSurat LIKE '%" & kodeTanggalSurat & "%'")
        ElseIf namaSurat = "SURAT KETERANGAN KONTROL" Then
            nomorUrut = ReadSQLNIK("SELECT LEFT (MAX(NoSurat), 4)AS Number FROM SuratKeteranganKontrol WHERE NoSurat LIKE '%" & kodeTanggalSurat & "%'")
        End If
        If Not String.IsNullOrEmpty(nomorUrut) AndAlso IsNumeric(nomorUrut) Then
            nomorUrut = (Convert.ToInt32(nomorUrut) + 1).ToString()
        Else
            nomorUrut = "1"
        End If

        NoSurat = nomorUrut.PadLeft(4, "0"c) & "/" & kodeSurat & "/" & kodeLokasiSurat & kodeTanggalSurat

        Return NoSurat
    End Function

    Function CreateTableSuratKeterangan() As DataTable
        Dim Thasil As New DataTable

        insertRowToTbls(Thasil, "Typstring", "No Surat")
        insertRowToTbls(Thasil, "Typstring", "Tanggal Surat")
        insertRowToTbls(Thasil, "Typstring", "Waktu Surat")
        insertRowToTbls(Thasil, "Typstring", "Nama")
        insertRowToTbls(Thasil, "Typstring", "NIK")
        insertRowToTbls(Thasil, "Typstring", "Umur")
        insertRowToTbls(Thasil, "Typstring", "Pekerjaan")
        insertRowToTbls(Thasil, "Typstring", "Jenis Kelamin")
        insertRowToTbls(Thasil, "Typstring", "Agama")
        insertRowToTbls(Thasil, "Typstring", "Alamat")
        insertRowToTbls(Thasil, "Typstring", "Status Sehat")
        insertRowToTbls(Thasil, "Typstring", "Tinggi Badan")
        insertRowToTbls(Thasil, "Typstring", "Berat Badan")
        insertRowToTbls(Thasil, "Typstring", "Tekanan Darah")
        insertRowToTbls(Thasil, "Typstring", "Suhu")
        insertRowToTbls(Thasil, "Typstring", "Nadi")
        insertRowToTbls(Thasil, "Typstring", "Frekuensi Nafas")
        insertRowToTbls(Thasil, "Typstring", "Penglihatan")
        insertRowToTbls(Thasil, "Typstring", "Diagnosis")
        insertRowToTbls(Thasil, "Typstring", "Penyebab Kematian")
        insertRowToTbls(Thasil, "Typstring", "IDInternet")
        insertRowToTbls(Thasil, "Typstring", "TglLahir")
        Return Thasil
    End Function

    Private Sub ButtonGenerateSuratKeteranganDokter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGenerateSuratKeteranganDokter.Click
        Try
            If ValidasiInputSuratKeterangan("SURAT KETERANGAN DOKTER") = True Then
                Dim statusSuratDokter As String = ""

                ' Set Status Sehat
                If RadioButtonStatusSehatSuratDokter.Checked = True Then
                    statusSuratDokter = RadioButtonStatusSehatSuratDokter.Text
                ElseIf RadioButtonStatusTidakSehatSuratDokter.Checked = True Then
                    statusSuratDokter = RadioButtonStatusTidakSehatSuratDokter.Text
                End If

                If TextBoxNoSuratDokter.Text = "" Then
                    ' Insert Data SuratKeteranganDokter
                    If tblsRekamMedis.Rows.Count > 0 Then
                        Dim rowData As DataRow = tblsRekamMedis.Rows(0)

                        Dim tglSekarang As String = Format(DateAndTime.Now, "dd") & " " & BulanIndonesia(Format(DateAndTime.Now, "MM")) & " " & Format(DateAndTime.Now, "yyyy")

                        ' Get Nomor Surat
                        Dim nomorSurat As String = GenerateNomorSurat("SURAT KETERANGAN DOKTER")

                        ' --- Ubah TextBox jadi JSON array ---
                        Dim listKeterangan As New List(Of String)
                        For Each item As String In TextBoxKeteranganCostom.Text.Split(","c)
                            Dim trimmed = item.Trim()
                            If trimmed <> "" Then
                                listKeterangan.Add(trimmed)
                            End If
                        Next

                        ' Buat JSON array string
                        Dim jsonKeterangan As String = "["
                        For i As Integer = 0 To listKeterangan.Count - 1
                            jsonKeterangan &= """" & listKeterangan(i).Replace("""", "\""") & """"
                            If i < listKeterangan.Count - 1 Then jsonKeterangan &= ","
                        Next
                        jsonKeterangan &= "]"

                        ' Insert data ke SuratKeteranganDokter
                        WriteSQL("INSERT INTO SuratKeteranganDokter (NoTransaksi, NoRekamMedis, NoSurat, TanggalSurat, DokterID, DokterNama, Hasil, Tujuan, ButaWarna, KeteranganButaWarna, CreatedBy, CreatedDate, Keterangan) " & _
                                "VALUES ('" & idTransaksi & "', '" & idPasien & "', '" & nomorSurat & "', GETDATE(), '" & rowData("KodeDokter") & "', '" & rowData("NamaDokter") & "', '" & statusSuratDokter.ToUpper() & "', '" & TextBoxTujuanSuratDokter.Text & "', '" & ComboBoxButaWarnaSuratSehat.Text & "', '" & TextBoxKeteranganButaWarnaSuratSehat.Text & "', '" & userInput & "', GETDATE(), '" & jsonKeterangan & "')", 4)

                        ' Set Nomor Surat
                        TextBoxNoSuratDokter.Text = nomorSurat
                    End If
                ElseIf TextBoxNoSuratDokter.Text <> "" Then
                    Dim parameterUpdate As String = ""

                    ' Ubah teks menjadi array JSON
                    Dim rawKeterangan As String = TextBoxKeteranganCostom.Text
                    Dim arrParts() As String = rawKeterangan.Split(","c)
                    For i As Integer = 0 To arrParts.Length - 1
                        arrParts(i) = """" & arrParts(i).Trim() & """"
                    Next
                    Dim jsonKeterangan As String = "[" & String.Join(",", arrParts) & "]"

                    ' Buat parameter update
                    parameterUpdate = "Hasil = '" & statusSuratDokter.ToUpper() & "'," & _
                                      "Tujuan = '" & TextBoxTujuanSuratDokter.Text & "'," & _
                                      "ButaWarna = '" & ComboBoxButaWarnaSuratSehat.Text & "'," & _
                                      "KeteranganButaWarna = '" & TextBoxKeteranganButaWarnaSuratSehat.Text & "'," & _
                                      "Keterangan = '" & jsonKeterangan & "'," & _
                                      "UpdatedBy = '" & userInput & "'," & _
                                      "UpdatedDate = GETDATE()"

                    ' Jalankan update
                    WriteSQL("UPDATE SuratKeteranganDokter SET " & parameterUpdate & " WHERE NoTransaksi = '" & idTransaksi & "'", 4)
                End If

                MsgBox("Data Berhasil Disimpan.", MsgBoxStyle.Information, "Success")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub ButtonGenerateSuratKeteranganIstirahat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGenerateSuratKeteranganIstirahat.Click
        Try
            If ValidasiInputSuratKeterangan("SURAT KETERANGAN ISTIRAHAT") = True Then
                ' Ambil nilai tanggal dari DateTimePicker
                Dim tglAwal As DateTime = TanggalMulaiSuratKeteranganIstirahat.Value.Date ' Normalisasi ke tengah malam
                Dim tglAkhir As DateTime = TanggalAkhirSuratKeteranganIstirahat.Value.Date ' Normalisasi ke tengah malam

                ' Hitung selisih hari
                Dim jumlahHari As Integer = (tglAkhir - tglAwal).Days + 1

                If TextBoxNoSuratIstirahat.Text = "" Then
                    ' Insert Data SuratKeteranganIstirahat
                    If tblsRekamMedis.Rows.Count > 0 Then
                        Dim rowData As DataRow = tblsRekamMedis.Rows(0)

                        Dim tglSekarang As String = Format(DateAndTime.Now, "dd") & " " & BulanIndonesia(Format(DateAndTime.Now, "MM")) & " " & Format(DateAndTime.Now, "yyyy")

                        ' Get Nomor Surat
                        Dim nomorSurat As String = GenerateNomorSurat("SURAT KETERANGAN ISTIRAHAT")

                        ' Insert data ke SuratKeteranganIstirahat
                        WriteSQL("INSERT INTO SuratKeteranganIstirahat (NoTransaksi, NoRekamMedis, NoSurat, TanggalSurat, DokterID, DokterNama, JumlahHari, TanggalAwal, TanggalAkhir, Diagnosa, CreatedBy, CreatedDate) " & _
                                "VALUES ('" & idTransaksi & "', '" & idPasien & "', '" & nomorSurat & "', GETDATE(), '" & rowData("KodeDokter") & "', '" & rowData("NamaDokter") & "', '" & jumlahHari & "', '" & Format(TanggalMulaiSuratKeteranganIstirahat.Value, "yyyy-MM-dd") & "', '" & Format(TanggalAkhirSuratKeteranganIstirahat.Value, "yyyy-MM-dd") & "', '" & TextBoxDiagnosaSuratIstirahat.Text & "', '" & userInput & "', GETDATE())", 4)

                        ' Set Nomor Surat
                        TextBoxNoSuratIstirahat.Text = nomorSurat
                    End If
                ElseIf TextBoxNoSuratIstirahat.Text <> "" Then
                    Dim parameterUpdate As String = ""

                    ' Update Data SuratKeteranganIstirahat
                    parameterUpdate = "JumlahHari = '" & jumlahHari & "'," & _
                                      "TanggalAwal = '" & Format(TanggalMulaiSuratKeteranganIstirahat.Value, "yyyy-MM-dd") & "'," & _
                                      "TanggalAkhir = '" & Format(TanggalAkhirSuratKeteranganIstirahat.Value, "yyyy-MM-dd") & "'," & _
                                      "Diagnosa = '" & TextBoxDiagnosaSuratIstirahat.Text & "'," & _
                                      "UpdatedBy = '" & userInput & "'," & _
                                      "UpdatedDate = GETDATE()"

                    WriteSQL("UPDATE SuratKeteranganIstirahat SET " & parameterUpdate & " WHERE NoTransaksi = '" & idTransaksi & "'", 4)
                End If

                MsgBox("Data Berhasil Disimpan.", MsgBoxStyle.Information, "Success")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub TextBoxJumlahHariIstirahat_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub ButtonGenerateSuratKeteranganKematian_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGenerateSuratKeteranganKematian.Click
        Try
            If ValidasiInputSuratKeterangan("SURAT KETERANGAN KEMATIAN") = True Then
                If TextBoxNoSuratKematian.Text = "" Then
                    ' Insert Data SuratKeteranganKematian
                    If tblsRekamMedis.Rows.Count > 0 Then
                        Dim rowData As DataRow = tblsRekamMedis.Rows(0)

                        Dim tglSekarang As String = Format(DateAndTime.Now, "dd") & " " & BulanIndonesia(Format(DateAndTime.Now, "MM")) & " " & Format(DateAndTime.Now, "yyyy")

                        ' Get Nomor Surat
                        Dim nomorSurat As String = GenerateNomorSurat("SURAT KETERANGAN KEMATIAN")

                        ' Insert data ke SuratKeteranganKematian
                        WriteSQL("INSERT INTO SuratKeteranganKematian (NoTransaksi, NoRekamMedis, NoSurat, TanggalSurat, DokterID, DokterNama, Diagnosa, PenyebabKematian, CreatedBy, CreatedDate) " & _
                                "VALUES ('" & idTransaksi & "', '" & idPasien & "', '" & nomorSurat & "', GETDATE(), '" & rowData("KodeDokter") & "', '" & rowData("NamaDokter") & "', '" & TextBoxDiagnosaSuratKematian.Text & "', '" & TextBoxSebabKematian.Text & "', '" & userInput & "', GETDATE())", 4)

                        ' Set Nomor Surat
                        TextBoxNoSuratKematian.Text = nomorSurat
                    End If
                ElseIf TextBoxNoSuratKematian.Text <> "" Then
                    Dim parameterUpdate As String = ""

                    ' Update Data SuratKeteranganKematian
                    parameterUpdate = "Diagnosa = '" & TextBoxDiagnosaSuratKematian.Text & "'," & _
                                      "PenyebabKematian = '" & TextBoxSebabKematian.Text & "'," & _
                                      "UpdatedBy = '" & userInput & "'," & _
                                      "UpdatedDate = GETDATE()"

                    WriteSQL("UPDATE SuratKeteranganKematian SET " & parameterUpdate & " WHERE NoTransaksi = '" & idTransaksi & "'", 4)
                End If

                MsgBox("Data Berhasil Disimpan.", MsgBoxStyle.Information, "Success")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        PictureBox1.Image = My.Resources.OdontogramFromWeb
    End Sub

    Private Sub ComboBoxNama_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxNama.SelectedIndexChanged
        'Dim Tbls As DataTable = ReadSQL("SELECT PerBagian, JenisOutput, TextOutput, WarnaOutput, GambarOutput FROM MasterOdontogramJenis WHERE Nama = '" & ComboBoxNama.Text & "'")

        'For Each Trow As DataRow In Tbls.Rows
        '    statusPerBagianOdontogram = Trow("PerBagian")
        '    jenisOutputOdontogram = Trow("JenisOutput")
        '    If IsDBNull(Trow("TextOutput")) = False Then textOutputOdontogram = Trow("TextOutput")
        '    If IsDBNull(Trow("WarnaOutput")) = False Then warnaOutputOdontogram = Trow("WarnaOutput")
        '    If IsDBNull(Trow("GambarOutput")) = False Then gambarOutputOdontogram = Trow("GambarOutput")
        'Next
    End Sub

    Private Sub ButtonInformedConsentInput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonInputInformedConsent.Click
        Try
            If ValidasiDataTindakanPoli() = True Then
                Dim statusPersetujuan As Boolean = RadioButtonSetujuInformedConsent.Checked

                FormInputInformedConsent.SetForm("RekamMedisPerencanaanTindakan", tblsRekamMedis, TextBoxTindakanID.Text, statusPersetujuan, jenisTransaksi)
                FormInputInformedConsent.ShowDialog()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        'Report = New XtraReport
        'Report = XtraReport.FromFile(Application.StartupPath + "\Reports\Klinik\RekamMedis\RM_05.repx", True)
        'Report.Bands(BandKind.Detail).Controls.Add(CreateXRPictureBox(54, 186, 475, 183))
        'Report.RunDesigner()

        ViewReportRM05()
    End Sub

    Private Sub ViewReportRM05()
        If ValidasiCetakRM05() = True Then
            Dim resultGigiDictionary As New Dictionary(Of String, String)()
            Dim tblsResult As New DataTable
            Dim tblsUrutan As New DataTable
            Dim tblsKondisiMulut As New DataTable
            Dim tblsHasil As New DataTable
            Dim variabel1 As String = ""
            Dim variabel2 As String = ""

            ' Create Report
            Report = New XtraReport
            Report = XtraReport.FromFile(Application.StartupPath + "\Reports\Klinik\RekamMedis\RM_05.repx", True)

            ' Get data pasien
            Dim trowPasien As DataRow = tblsRekamMedis.Rows(0)

            ' Get data per gigi
            tblsResult = ReadSQL("SELECT a.NomorGigi, COALESCE(b.GenerateHasil, 'sou') AS GenerateHasil " & _
                                 "FROM MasterOdontogram a " & _
                                 "LEFT JOIN TransaksiGigiOdontogramHeader b ON a.NomorGigi = b.NomorGigi AND b.NoTransaksi = '" & idTransaksi & "' " & _
                                 "WHERE NamaBagian LIKE '%Full%'")

            ' Input dictionary per gigi
            For Each trowResult As DataRow In tblsResult.Rows
                resultGigiDictionary("" & trowResult("NomorGigi") & "") = trowResult("GenerateHasil")
            Next

            ' Set field tabel hasil
            insertRowToTbls(tblsHasil, "typstring", "Nama")
            insertRowToTbls(tblsHasil, "typstring", "JenisKelamin")
            insertRowToTbls(tblsHasil, "typstring", "NIK")
            insertRowToTbls(tblsHasil, "typstring", "TTL")
            insertRowToTbls(tblsHasil, "typstring", "Occlusi")
            insertRowToTbls(tblsHasil, "typstring", "TorusPalatinus")
            insertRowToTbls(tblsHasil, "typstring", "TorusMandibularis")
            insertRowToTbls(tblsHasil, "typstring", "Palatum")
            insertRowToTbls(tblsHasil, "typstring", "Diastema")
            insertRowToTbls(tblsHasil, "typstring", "KeteranganDiastema")
            insertRowToTbls(tblsHasil, "typstring", "GigiAnomali")
            insertRowToTbls(tblsHasil, "typstring", "KeteranganGigiAnomali")
            insertRowToTbls(tblsHasil, "typstring", "KeteranganLain")
            insertRowToTbls(tblsHasil, "typstring", "Decay")
            insertRowToTbls(tblsHasil, "typstring", "Missing")
            insertRowToTbls(tblsHasil, "typstring", "Filled")

            ' Set kondisi mulut
            tblsKondisiMulut = ReadSQL("SELECT * FROM TransaksiGigiKondisi WHERE NoTransaksi = '" & idTransaksi & "'")

            Dim trowKondisiMulut As DataRow = tblsKondisiMulut.Rows(0)

            tblsUrutan = ReadSQL("SELECT * FROM MasterOdontogramUrutanHasil")

            Dim Tnew As DataRow = tblsHasil.NewRow
            For Each trowUrutan As DataRow In tblsUrutan.Rows
                insertRowToTbls(tblsHasil, "Typstring", "" & trowUrutan("KeteranganHasil") & "")

                If trowUrutan("Variabel2").ToString = "-" Then
                    Tnew("" & trowUrutan("KeteranganHasil") & "") = resultGigiDictionary("" & trowUrutan("Variabel1") & "")
                Else
                    If resultGigiDictionary("" & trowUrutan("Variabel1") & "") = "sou" And resultGigiDictionary("" & trowUrutan("Variabel2") & "") = "sou" Then
                        Tnew("" & trowUrutan("KeteranganHasil") & "") = "sou"
                    Else
                        variabel1 = trowUrutan("Variabel1") & " : " & resultGigiDictionary("" & trowUrutan("Variabel1") & "")
                        variabel2 = trowUrutan("Variabel2") & " : " & resultGigiDictionary("" & trowUrutan("Variabel2") & "")
                        Tnew("" & trowUrutan("KeteranganHasil") & "") = variabel1 & " ; " & variabel2
                    End If
                End If
            Next

            Tnew("Nama") = trowPasien("Nama")
            Tnew("JenisKelamin") = trowPasien("JenisKelamin")
            Tnew("NIK") = trowPasien("NoNIK")
            Tnew("TTL") = trowPasien("TempatLahir") & ", " & Format(trowPasien("TglLahir"), "dd") & " " & BulanIndonesia(Format(trowPasien("TglLahir"), "MM")) & " " & Format(trowPasien("TglLahir"), "yyyy")
            Tnew("Occlusi") = trowKondisiMulut("Occlusi")
            Tnew("TorusPalatinus") = trowKondisiMulut("TorusPalatinus")
            Tnew("TorusMandibularis") = trowKondisiMulut("TorusMandibularis")
            Tnew("Palatum") = trowKondisiMulut("Palatum")
            Tnew("Diastema") = trowKondisiMulut("Diastema")
            Tnew("KeteranganDiastema") = trowKondisiMulut("KeteranganDiastema")
            Tnew("GigiAnomali") = trowKondisiMulut("GigiAnomali")
            Tnew("KeteranganGigiAnomali") = trowKondisiMulut("KeteranganGigiAnomali")
            Tnew("KeteranganLain") = trowKondisiMulut("KeteranganLain")
            Tnew("Decay") = trowKondisiMulut("Decay")
            Tnew("Missing") = trowKondisiMulut("Missing")
            Tnew("Filled") = trowKondisiMulut("Filled")

            tblsHasil.Rows.Add(Tnew)

            Report.DataSource = tblsHasil
            'Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MM-yyyy HH:mm:ss") + " by " + userInput
            'Report.Bands(BandKind.Detail).Controls.Add(CreateXRPictureBox(TrowLab("rbc_grafik"), 567, 65, 150, 175))
            'Report.Bands(BandKind.DetailReport)(0).Controls.Add(CreateXRPictureBox(10, 10, 563, 260))
            Report.Bands(BandKind.Detail).Controls.Add(CreateXRPictureBox(54, 186, 475, 183))



            Report.RunDesigner()
            'Report.ShowPreview()
        End If
    End Sub

    Function ValidasiCetakRM05() As Boolean
        ' Validasi apakah ada resep yang akan dikirim
        If CheckSQL("SELECT * FROM TransaksiGigiKondisi WHERE NoTransaksi = '" & idTransaksi & "'") = False Then
            MsgBox("Gagal. Kondisi gigi & mulut belum terisi.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        Return True
    End Function

    Function CreateXRPictureBox(ByVal LocX As Integer, ByVal LocY As Integer, ByVal SizeX As Integer, ByVal SizeY As Integer) As XRPictureBox
        Dim PictureBox As XRPictureBox = New XRPictureBox()
        PictureBox.Name = "QR_Hasil"
        PictureBox.Image = PictureBoxOdontogramObjektif.Image
        PictureBox.Location = New Point(LocX, LocY)
        PictureBox.Size = New Size(SizeX, SizeY)
        PictureBox.Sizing = ImageSizeMode.StretchImage

        Return PictureBox
    End Function

    Private Sub ButtonFindSimbol_ButtonClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles ButtonFindSimbolGigi.ButtonClick
        Find.Show()
        Find.Query("SELECT Kategori, Nama, Arti, Keterangan FROM MasterOdontogramJenis", " ORDER BY Kategori ASC", "FindObjektifSimbolGigi", 1)
    End Sub

    Function CreateTableTransaksiOdontogram() As DataTable
        Dim Thasil As New DataTable

        insertRowToTbls(Thasil, "Typstring", "NomorGigi")
        insertRowToTbls(Thasil, "Typstring", "NamaBagian")
        insertRowToTbls(Thasil, "Typstring", "Jenis")

        For Each Tcol As DataColumn In Thasil.Columns
            Tcol.ReadOnly = True
        Next

        Return Thasil
    End Function

    Private Sub LoadOdontogram()
        Dim tblsHeader As New DataTable
        Dim tblsDetail As New DataTable

        Dim jenisOutputOdontogram As String = ""
        Dim textOutputOdontogram As String = ""
        Dim warnaOutputOdontogram As String = ""
        Dim gambarOutputOdontogram As String = ""

        ' Set header tabel
        tblsHeader = ReadSQL("SELECT a.NomorGigi, a.NamaBagian, a.Jenis, b.JenisOutput, b.TextOutput, b.WarnaOutput, b.GambarOutput " & _
                             "FROM TransaksiGigiOdontogramDetail a " & _
                             "LEFT JOIN MasterOdontogramJenis b ON a.Jenis = b.Nama " & _
                             "WHERE NoTransaksi = '" & idTransaksi & "'")

        For Each rowHeader As DataRow In tblsHeader.Rows
            ' Set detail tabel
            tblsDetail = ReadSQL("SELECT * FROM MasterOdontogramDetail WHERE NamaBagian = '" & rowHeader("NamaBagian") & "'")

            jenisOutputOdontogram = rowHeader("JenisOutput")
            If IsDBNull(rowHeader("TextOutput")) = False Then textOutputOdontogram = rowHeader("TextOutput")
            If IsDBNull(rowHeader("WarnaOutput")) = False Then warnaOutputOdontogram = rowHeader("WarnaOutput")
            If IsDBNull(rowHeader("GambarOutput")) = False Then gambarOutputOdontogram = rowHeader("GambarOutput")

            For Each Trow As DataRow In tblsDetail.Rows
                ' Mengkonversi gambar menjadi Bitmap
                Dim originalImage As Bitmap = DirectCast(PictureBoxOdontogramObjektif.Image, Bitmap)
                Dim fontOdontogram As New Font("Arial", 7, FontStyle.Bold)
                Dim colorText As String = ""

                ' Membuat salinan gambar asli
                Dim updatedImage As New Bitmap(originalImage)

                If jenisOutputOdontogram.Contains("Text Atas") And Trow("JenisBagian").ToString = "Text Atas" Then
                    ShapeDrawingFunctions.DrawText(updatedImage, Trow("x1"), Trow("y1"), textOutputOdontogram, fontOdontogram, Color.Black)
                ElseIf jenisOutputOdontogram.Contains("Text Bawah") And Trow("JenisBagian").ToString = "Text Bawah" Then
                    ShapeDrawingFunctions.DrawText(updatedImage, Trow("x1"), Trow("y1"), textOutputOdontogram, fontOdontogram, Color.Black)
                ElseIf jenisOutputOdontogram = "Warna" Then
                    colorText = warnaOutputOdontogram
                    Dim fillColor As Color = ColorTranslator.FromHtml(colorText)

                    If Trow("JenisBagian").ToString = "Persegi" Then
                        DrawSquare(updatedImage, Trow("x1"), Trow("y1"), Trow("x2"), Trow("y2"), fillColor, Color.Black)
                    ElseIf Trow("JenisBagian").ToString = "Trapesium" Then
                        ShapeDrawingFunctions.DrawTrapezium(updatedImage, Trow("x1"), Trow("y1"), Trow("x2"), Trow("y2"), Trow("x3"), Trow("y3"), Trow("x4"), Trow("y4"), fillColor, Color.Black)
                    ElseIf Trow("JenisBagian").ToString = "Segitiga" Then
                        ShapeDrawingFunctions.DrawTriangle(updatedImage, Trow("x1"), Trow("y1"), Trow("x2"), Trow("y2"), Trow("x3"), Trow("y3"), fillColor, Color.Black)
                    End If
                ElseIf jenisOutputOdontogram.Contains("Gambar") And gambarOutputOdontogram.Contains(Trow("JenisBagian").ToString) Then
                    startPoint1 = New Point(Trow("x1"), Trow("y1"))
                    endPoint1 = New Point(Trow("x2"), Trow("y2"))
                    startPoint2 = New Point(Trow("x3"), Trow("y3"))
                    endPoint2 = New Point(Trow("x4"), Trow("y4"))

                    If Trow("JenisBagian").ToString = "Pagar" Then
                        fontOdontogram = New Font("Arial", 28, FontStyle.Regular)
                        ShapeDrawingFunctions.DrawText(updatedImage, Trow("x1"), Trow("y1"), "#", fontOdontogram, Color.Black)
                    ElseIf Trow("JenisBagian").ToString = "V Bawah" Then
                        fontOdontogram = New Font("Arial", 16, FontStyle.Regular)
                        ShapeDrawingFunctions.DrawText(updatedImage, Trow("x1"), Trow("y1"), "V", fontOdontogram, Color.Black)
                    ElseIf Trow("JenisBagian").ToString = "V Tengah" Then
                        ShapeDrawingFunctions.DrawLines(updatedImage, startPoint1, endPoint1, startPoint2, endPoint2, Color.Black, 3)
                    ElseIf Trow("JenisBagian").ToString = "X Tengah" Then
                        ShapeDrawingFunctions.DrawLines(updatedImage, startPoint1, endPoint1, startPoint2, endPoint2, Color.Black, 3)
                    ElseIf Trow("JenisBagian").ToString = "Segitiga Bawah" Then
                        ShapeDrawingFunctions.DrawTriangle(updatedImage, Trow("x1"), Trow("y1"), Trow("x2"), Trow("y2"), Trow("x3"), Trow("y3"), Color.Black, Color.Black)
                    ElseIf Trow("JenisBagian").ToString = "Sisi Persegi" Then
                        ShapeDrawingFunctions.DrawColoredRectangle(updatedImage, Trow("x1"), Trow("y1"), Trow("x2"), Trow("y2"), 4)
                    ElseIf Trow("JenisBagian").ToString = "Persegi Arsir Vertikal" Then
                        ShapeDrawingFunctions.DrawColoredRectangleWithVerticalHatch(updatedImage, Trow("x1"), Trow("y1"), Trow("x2"), Trow("y2"), Color.Black)
                    ElseIf Trow("JenisBagian").ToString = "Garis Lurus Atas" Then
                        ShapeDrawingFunctions.DrawLines(updatedImage, startPoint1, endPoint1, startPoint2, endPoint2, Color.Black, 3)
                    End If
                End If

                ' Menampilkan gambar yang telah diperbarui
                PictureBoxOdontogramObjektif.Image = updatedImage
            Next
        Next
    End Sub

    Private Sub ClearDetailOdontogram()
        TextBoxNomorGigi.ResetText()
        LabelKeteranganGigi.Text = "-"

        'ButtonFindTindakanGigi.ResetText()
        'LabelTindakanGigi.Text = "-"
        'TextBoxHargaTindakanGigi.ResetText()
        TextBoxKeteranganOdontogram.ResetText()

        simbolOdontogram = ""
        ButtonFindSimbolGigi.ResetText()
        LabelSimbolGigi.Text = "-"
        PictureBoxPreviewSimbol.ImageLocation = Nothing

        TextBoxKeteranganOdontogram.ResetText()
        CheckBoxMesial.Checked = False
        CheckBoxOcclusal.Checked = False
        CheckBoxDistal.Checked = False
        CheckBoxVestibular.Checked = False
        CheckBoxLingual.Checked = False

        GroupBoxDetailTransaksiOdontogram.Enabled = False
    End Sub

    Private Sub ButtonSimpanTransaksiOdontogram_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSimpanTransaksiOdontogram.Click
        Try
            If CheckingTransaksiOdontogram() = True Then
                Dim nomorGigi As String = ""
                Dim result As String = ""
                Dim resultDetailGigi As String = ""
                Dim resultPermukaanGigi As String = ""
                Dim parameterUpdate As String = ""
                'Dim splitTindakanGigi() As String = LabelTindakanGigi.Text.Split("|")

                For Each Trow As DataRow In tblsTransaksiOdontogram.Rows
                    ' Insert data ke TransaksiGigiOdontogramDetail
                    WriteSQL("INSERT INTO TransaksiGigiOdontogramDetail (NoTransaksi, NomorGigi, NamaBagian, Jenis, CreatedBy, CreatedDate) " & _
                             "VALUES ('" & idTransaksi & "', '" & Trow("NomorGigi") & "', '" & Trow("NamaBagian") & "', '" & Trow("Jenis") & "', '" & userInput & "', GETDATE())", 4)

                    nomorGigi = Trow("NomorGigi")
                Next

                resultDetailGigi = GetResultDetailOdontogram(nomorGigi)
                If CheckBoxMesial.Checked = True Then resultPermukaanGigi = resultPermukaanGigi & CheckBoxMesial.Tag
                If CheckBoxOcclusal.Checked = True Then resultPermukaanGigi = resultPermukaanGigi & CheckBoxOcclusal.Tag
                If CheckBoxDistal.Checked = True Then resultPermukaanGigi = resultPermukaanGigi & CheckBoxDistal.Tag
                If CheckBoxVestibular.Checked = True Then resultPermukaanGigi = resultPermukaanGigi & CheckBoxVestibular.Tag
                If CheckBoxLingual.Checked = True Then resultPermukaanGigi = resultPermukaanGigi & CheckBoxLingual.Tag

                result = resultPermukaanGigi & " " & resultDetailGigi

                If CheckSQL("SELECT * FROM TransaksiGigiOdontogramHeader WHERE NoTransaksi = '" & idTransaksi & "' AND NomorGigi = '" & nomorGigi & "'") = False Then
                    ' Insert data TransaksiGigiOdontogramHeader
                    WriteSQL("INSERT INTO TransaksiGigiOdontogramHeader (NoTransaksi, NomorGigi, GenerateHasil, Mesial, Occusal, Distal, Vestibular, Lingual, Keterangan, CreatedBy, CreatedDate) " & _
                         "VALUES ('" & idTransaksi & "', '" & nomorGigi & "', '" & result & "', '" & CheckBoxMesial.Checked & "', '" & CheckBoxOcclusal.Checked & "', '" & CheckBoxDistal.Checked & "', '" & CheckBoxVestibular.Checked & "', '" & CheckBoxLingual.Checked & "', '" & TextBoxKeteranganOdontogram.Text & "', '" & userInput & "', GETDATE())", 4)
                Else
                    parameterUpdate = "GenerateHasil = '" & result & "'," & _
                                      "Keterangan = '" & TextBoxKeteranganOdontogram.Text & "'," & _
                                      "Mesial = '" & CheckBoxMesial.Checked & "'," & _
                                      "Occusal = '" & CheckBoxOcclusal.Checked & "'," & _
                                      "Distal = '" & CheckBoxDistal.Checked & "'," & _
                                      "Vestibular = '" & CheckBoxVestibular.Checked & "'," & _
                                      "Lingual = '" & CheckBoxLingual.Checked & "'," & _
                                      "ChangeBy = '" & userInput & "'," & _
                                      "ChangeDate = GETDATE()"

                    ' Update data TransaksiGigiOdontogramHeader
                    WriteSQL("UPDATE TransaksiGigiOdontogramHeader SET " & parameterUpdate & " WHERE NoTransaksi = '" & idTransaksi & "' AND NomorGigi = '" & nomorGigi & "'", 4)
                End If

                ' Get data poli
                Dim trowPoli As DataRow = tblsRekamMedis.Rows(0)

                ' Insert ke tabel TransaksiGigiDetail
                'WriteSQL("INSERT INTO TransaksiGigiDetail(TransGigiID,TindakanID,NamaTindakan,JenisTindakan,ElemenGigi,BiayaTindakan,DiscTindakan,NettBayar,GroupBayar,StatusPembayaran,CreatedBy,CreatedDate) " & _
                '         "VALUES('" & trowPoli("TransGigiID") & "','" & ButtonFindTindakanGigi.Text & "','" & splitTindakanGigi(0).Trim & "','" & splitTindakanGigi(1).Trim & "','" & LabelKeteranganGigi.Text & "'," & CDbl(TextBoxHargaTindakanGigi.Text) & ", 0," & CDbl(TextBoxHargaTindakanGigi.Text) & ", '', 'PENDING', '" & userInput & "', GETDATE())", 4)

                ' Set clear data temporary odontogram
                tblsTransaksiOdontogram.Rows.Clear()

                ' Clear data
                ClearDetailOdontogram()

                'Save image
                'SaveImageOdontogram(PictureBox, PictureBox.Name & "_" & idTransaksi & ".png")

                MsgBox("Data Berhasil Disimpan.", MsgBoxStyle.Information, "Success")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Function GetResultDetailOdontogram(ByVal nomorGigi As String)
        Dim result As String = ""

        Dim tblsDetail As DataTable = ReadSQL("SELECT Jenis FROM TransaksiGigiOdontogramDetail WHERE NoTransaksi = '" & idTransaksi & "' AND NomorGigi = '" & nomorGigi & "' " & _
                                              "GROUP BY Jenis, NomorGigi")

        For Each Trow As DataRow In tblsDetail.Rows
            result = result & Trow("Jenis").ToString.Trim & "-"
        Next

        result = Strings.Left(result, result.Length - 1)

        Return result
    End Function

    Function CheckingTransaksiOdontogram() As Boolean
        If tblsTransaksiOdontogram.Rows.Count = 0 Then
            MsgBox("Pilih gigi yang ingin ditandai.", MsgBoxStyle.Critical, "Warning!")
            Return False
        End If

        'If ButtonFindTindakanGigi.Text = "" Then
        '    MsgBox("Pilih tindakan terlebih dahulu.", MsgBoxStyle.Critical, "Warning!")
        '    Return False
        'End If

        Return True
    End Function

    Private Sub ButtonFindDiagnosa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFindDiagnosa.Click
        If ValidasiTambahDiagnosa() = True Then
            FindDiagnosa.SetForm("RekamMedisDokterDiagnosa")
            FindDiagnosa.ShowDialog()
        End If
    End Sub

    Function ValidasiTambahDiagnosa() As Boolean
        ' Validasi Pemeriksaan Fisik
        If ValidasiPemeriksaanFisik() = False Then Return False

        ' Validasi Prognosa
        If ValidasiPrognosa() = False Then Return False

        ' UATBPJS
        ' Validasi Status Transaksi
        Dim statusTransaksi As String = GetStatusTransaksi(idTransaksi, jenisTransaksi)
        'MsgBox("Debug Info:" & vbCrLf & _
        '               "No Transaksi: " & idTransaksi & vbCrLf & _
        '               "Jenis Poli: " & jenisTransaksi & vbCrLf & _
        '               "Status Transaksi: " & statusTransaksi)
        If statusTransaksi <> "Sedang Diperiksa Dokter" And statusTransaksi <> "Sudah Diperiksa" Then
            MsgBox("Transaksi belum dipanggil oleh dokter.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        Return True
    End Function

    Private Sub SendToApiDiagnosa(ByVal idTransaksi As String, ByVal kodeDiagnosa As String, ByVal namaDiagnosa As String, ByVal jenisDiagnosa As String, ByVal kasusDiagnosa As String, ByVal deleted As String)
        Try
            Dim client As New Net.WebClient()

            ' Siapkan JSON sesuai field di Laravel
            Dim json As String = "{" & _
                 """NoTransaksi"":""" & idTransaksi & """," & _
                 """KodeDiagnosa"":""" & kodeDiagnosa & """," & _
                 """KeteranganDiagnosa"":""" & namaDiagnosa & """," & _
                 """JenisDiagnosa"":""" & jenisDiagnosa & """," & _
                 """KasusDiagnosa"":""" & kasusDiagnosa & """," & _
                 """Deleted"":""" & deleted & """}"

            Dim baseUrl As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
            Dim urlWebService As String = baseUrl & "api/diagnosa/save"
            Dim response As String = InsertDataAPIRM(json, urlWebService)

            ' --- Parse JSON response ---
            Dim result As JObject = JObject.Parse(response)

            Dim status As String = result("status").ToString()
            Dim message As String = result("message").ToString()

            Dim insertedId As String = ""
            Dim data As JObject = TryCast(result("data"), JObject)
            If data IsNot Nothing AndAlso data("id") IsNot Nothing Then
                insertedId = data("id").ToString()
            End If

            ' --- Tampilkan hasil ---
            If status = "success" Then
                MsgBox("Data berhasil dikirim ke API ERM." & vbCrLf & _
                       "Pesan: " & message & vbCrLf & _
                       "Dengan ID: " & insertedId)
            Else
                MsgBox("API mengembalikan status gagal: " & status & vbCrLf & message)
            End If
        Catch ex As Exception
            MsgBox("Gagal kirim ke API: " & ex.Message)
        End Try
    End Sub

    Private Sub ButtonSaveDiagnosa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSaveDiagnosa.Click
        Try
            If CheckingDiagnosa() = True Then
                Dim namaDiagnosa As String = TextBoxKeteranganDiagnosa.Text.Replace("'", "''")
                Dim kodeDiagnosa As String = TextBoxKodeDiagnosa.Text
                Dim jenisDiagnosa As String = ComboBoxJenisDiagnosa.Text
                Dim kasusDiagnosa As String = ComboBoxKasusDiagnosa.Text

                Dim statusAPI As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'status_ws_RM' ")

                ' Set UUID
                Dim uuid As String = GetUUID()

                ' Save ke tabel TransaksiDetailDiagnosa
                WriteSQL("INSERT INTO TransaksiDetailDiagnosa (NoTransaksi, KodeDiagnosa, KeteranganDiagnosa, JenisDiagnosa, KasusDiagnosa, ElemenGigi, DiagnosaNonSpesialistik, UUID, CreatedBy, CreatedDate) " & _
                         "VALUES('" & idTransaksi & "', '" & TextBoxKodeDiagnosa.Text & "', '" & namaDiagnosa & "', '" & ComboBoxJenisDiagnosa.Text & "', '" & ComboBoxKasusDiagnosa.Text & "', '" & ComboBoxElemenGigi.Text & "', '" & CheckBoxDiagnosaNonSpesialistik.Checked & "', '" & uuid & "', '" & userInput & "', GETDATE())", 4)

                If statusAPI IsNot Nothing AndAlso statusAPI = "Yes" Then
                    SendToApiDiagnosa(idTransaksi, kodeDiagnosa, namaDiagnosa, jenisDiagnosa, kasusDiagnosa, "0")
                End If

                ' Insert / Update Detail Waktu Transaksi (WaktuSelesaiDokter)
                SetDetailWaktuTransaksi(idTransaksi, "WaktuSelesaiDokter", userInput)

                ' Refresh Grid Diagnosa
                LoadGridRiwayatDiagnosa()

                ' Simpan Detail Diagnosa
                SaveDetailDiagnosa()

                ' Kirim P-Care
                If statusBPJS = True AndAlso CheckBridgingPcareActive() = True Then SaveKunjunganBPJS()

                If noKunjunganBPJS.Length > 0 Then
                    MsgBox("Data berhasil disimpan." & vbCr & vbLf & "No kunjungan PCare : " & noKunjunganBPJS & "", MsgBoxStyle.Information, "Success!")
                Else
                    MsgBox("Data berhasil disimpan.", MsgBoxStyle.Information, "Success!")
                End If

                ClearDiagnosa()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub SaveDetailDiagnosa()
        Dim detailDiagnosa As String = ""
        Dim tempDetailDiagnosa As String = ""
        Dim namaDiagnosa As String = ""

        Dim Tbls As DataTable = ReadSQL("SELECT TransaksiDetailDiagnosa.KeteranganDiagnosa + ' ('+TransaksiDetailDiagnosa.KodeDiagnosa+')' AS Diagnosa, TransaksiDetailDiagnosa.KasusDiagnosa, TransaksiDetailDiagnosa.JenisDiagnosa, TransaksiDetailDiagnosa.ElemenGigi, TransaksiDetail.JenisPoli " & _
                                        "FROM TransaksiDetailDiagnosa " & _
                                        "LEFT JOIN TransaksiDetail ON TransaksiDetailDiagnosa.NoTransaksi=TransaksiDetail.NoUrut " & _
                                        "WHERE TransaksiDetailDiagnosa.NoTransaksi = '" & idTransaksi & "' AND TransaksiDetailDiagnosa.DeletedDate IS NULL")

        For Each Trow As DataRow In Tbls.Rows
            namaDiagnosa = Trow("Diagnosa").ToString.Replace("'", "''")
            detailDiagnosa = detailDiagnosa & "" & namaDiagnosa & ", "
        Next

        If detailDiagnosa <> "" Then detailDiagnosa = Strings.Left(detailDiagnosa, detailDiagnosa.Length - 2)

        ' Update Keterangan Diagnosa
        WriteSQL("UPDATE TransaksiDetail SET Diagnosa = '" & detailDiagnosa & "' WHERE NoUrut = '" & idTransaksi & "'", 4)
    End Sub

    Function CheckingDiagnosa() As Boolean
        If TextBoxKodeDiagnosa.Text = "" Then
            MsgBox("Pilih diagnosa terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        If ComboBoxJenisDiagnosa.SelectedIndex = -1 Then
            MsgBox("Pilih jenis diagnosa terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        If ComboBoxKasusDiagnosa.SelectedIndex = -1 Then
            MsgBox("Pilih kasus diagnosa terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        If jenisTransaksi = "GIGI" Then
            If ComboBoxElemenGigi.SelectedIndex = -1 Then
                MsgBox("Pilih elemen gigi terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
                Return False
            End If
        End If

        Dim tblsDiagnosa As DataTable = ReadSQL("SELECT * FROM TransaksiDetailDiagnosa WHERE NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL")
        Dim checkJenisDiagnosa As Boolean = False

        For Each trowDiagnosa As DataRow In tblsDiagnosa.Rows
            If ComboBoxJenisDiagnosa.Text = "Diagnosa Sekunder" And trowDiagnosa("JenisDiagnosa") = "Diagnosa Utama" Then
                checkJenisDiagnosa = True
            ElseIf ComboBoxJenisDiagnosa.Text = "Diagnosa Komplikasi" And trowDiagnosa("JenisDiagnosa") = "Diagnosa Sekunder" Then
                checkJenisDiagnosa = True
            End If

            If trowDiagnosa("KodeDiagnosa") = TextBoxKodeDiagnosa.Text Or trowDiagnosa("JenisDiagnosa") = ComboBoxJenisDiagnosa.Text Then
                MsgBox("Gagal. Jenis atau kode diagnosa yang dipilih sudah pernah diinput.", MsgBoxStyle.Exclamation, "Warning!")
                Return False
            End If
        Next

        If checkJenisDiagnosa = False And ComboBoxJenisDiagnosa.Text <> "Diagnosa Utama" Then
            MsgBox("Gagal. Cek jenis diagnosa yang sesuai.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        Return True
    End Function

    Private Sub ClearDiagnosa()
        TextBoxKodeDiagnosa.ResetText()
        TextBoxKeteranganDiagnosa.ResetText()
        ComboBoxJenisDiagnosa.SelectedIndex = -1
        ComboBoxKasusDiagnosa.SelectedIndex = -1
        ComboBoxElemenGigi.SelectedIndex = -1
    End Sub

    Private Sub ButtonSaveKondisiGigi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSaveKondisiGigi.Click
        Try
            If CheckingKondisiGigi() = True Then
                '# Set Data 
                Dim Occlusi As String = ""
                Dim TorusPalatinus As String = ""
                Dim TorusMandibularis As String = ""
                Dim Palatum As String = ""
                Dim Diastema As String = ""
                Dim KeteranganDiastema As String = TextBoxKeteranganDiastema.Text
                Dim GigiAnomali As String = ""
                Dim KeteranganGigiAnomali As String = TextBoxKeteranganGigiAnomali.Text
                Dim KeteranganLain As String = TextBoxKeteranganKondisiGigiLainnya.Text
                Dim Decay As String = TextBoxKeteranganDecay.Text
                Dim Missing As String = TextBoxKeteranganMissing.Text
                Dim Filled As String = TextBoxKeteranganFilled.Text

                '# Fill Data
                ' Occlusi
                If RadioButtonOcclusi1.Checked Then
                    Occlusi = RadioButtonOcclusi1.Text
                ElseIf RadioButtonOcclusi2.Checked Then
                    Occlusi = RadioButtonOcclusi2.Text
                ElseIf RadioButtonOcclusi3.Checked Then
                    Occlusi = RadioButtonOcclusi3.Text
                End If

                ' TorusPalatinus
                If RadioButtonTorusPalatinus1.Checked Then
                    TorusPalatinus = RadioButtonTorusPalatinus1.Text
                ElseIf RadioButtonTorusPalatinus2.Checked Then
                    TorusPalatinus = RadioButtonTorusPalatinus2.Text
                ElseIf RadioButtonTorusPalatinus3.Checked Then
                    TorusPalatinus = RadioButtonTorusPalatinus3.Text
                ElseIf RadioButtonTorusPalatinus4.Checked Then
                    TorusPalatinus = RadioButtonTorusPalatinus4.Text
                ElseIf RadioButtonTorusPalatinus5.Checked Then
                    TorusPalatinus = RadioButtonTorusPalatinus5.Text
                End If

                ' TorusMandibularis
                If RadioButtonTorusMandibularis1.Checked Then
                    TorusMandibularis = RadioButtonTorusMandibularis1.Text
                ElseIf RadioButtonTorusMandibularis2.Checked Then
                    TorusMandibularis = RadioButtonTorusMandibularis2.Text
                ElseIf RadioButtonTorusMandibularis3.Checked Then
                    TorusMandibularis = RadioButtonTorusMandibularis3.Text
                ElseIf RadioButtonTorusMandibularis4.Checked Then
                    TorusMandibularis = RadioButtonTorusMandibularis4.Text
                End If

                ' Palatum
                If RadioButtonPalatum1.Checked Then
                    Palatum = RadioButtonPalatum1.Text
                ElseIf RadioButtonPalatum2.Checked Then
                    Palatum = RadioButtonPalatum2.Text
                ElseIf RadioButtonPalatum3.Checked Then
                    Palatum = RadioButtonPalatum3.Text
                End If

                ' Diastema
                If RadioButtonDiastema1.Checked Then
                    Diastema = RadioButtonDiastema1.Text
                ElseIf RadioButtonDiastema2.Checked Then
                    Diastema = RadioButtonDiastema2.Text
                End If

                ' GigiAnomali
                If RadioButtonGigiAnomali1.Checked Then
                    GigiAnomali = RadioButtonGigiAnomali1.Text
                ElseIf RadioButtonGigiAnomali2.Checked Then
                    GigiAnomali = RadioButtonGigiAnomali2.Text
                End If

                ' Save ke tabel TransaksiDetailDiagnosa
                WriteSQL("INSERT INTO TransaksiGigiKondisi (NoTransaksi, Occlusi, TorusPalatinus, TorusMandibularis, Palatum, Diastema, KeteranganDiastema, GigiAnomali, KeteranganGigiAnomali, KeteranganLain, Decay, Missing, Filled, CreatedBy, CreatedDate) " & _
                                 "VALUES('" & idTransaksi & "', '" & Occlusi & "', '" & TorusPalatinus & "', '" & TorusMandibularis & "', '" & Palatum & "', '" & Diastema & "', '" & KeteranganDiastema & "', '" & GigiAnomali & "', '" & KeteranganGigiAnomali & "', '" & KeteranganLain & "', '" & Decay & "', '" & Missing & "', '" & Filled & "', '" & userInput & "', GETDATE())", 4)

                MsgBox("Data berhasil disimpan.", MsgBoxStyle.Information, "Success!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Function CheckingKondisiGigi() As Boolean
        If RadioButtonPalatum1.Checked = False And RadioButtonPalatum2.Checked = False And RadioButtonPalatum2.Checked = False Then
            MsgBox("Pilih palatum terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        If RadioButtonDiastema2.Checked = True And TextBoxKeteranganDiastema.Text = "" Then
            MsgBox("Keterangan diastema belum terisi.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        If RadioButtonGigiAnomali2.Checked = True And TextBoxKeteranganGigiAnomali.Text = "" Then
            MsgBox("Keterangan gigi anomali belum terisi.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        Return True
    End Function

    'Private Sub SaveImageOdontogram(ByVal pictureBox As PictureBox, ByVal txFileName As String)
    '    Dim mergedImage As New Bitmap(pictureBox.Width, pictureBox.Height)

    '    pictureBox.DrawToBitmap(mergedImage, New Rectangle(0, 0, mergedImage.Width, mergedImage.Height))

    '    Dim directoryPath As String = Application.StartupPath + "\FileDownload\Gambar\Penanda Operasi"
    '    Dim fileName As String = txFileName
    '    Dim filePath As String = Path.Combine(directoryPath, fileName)

    '    mergedImage.Save(filePath, ImageFormat.Png)
    'End Sub

    Private Sub ButtonSaveRujukan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSaveRujukan.Click
        Try
            If Not ValidasiInputStatusPulang() Then Exit Sub

            Dim statusPulang As String = ComboBoxStatusPulang.Text

            ' ========================== Rujukan BPJS ==========================
            If statusPulang.Contains("Rujuk") Then
                Dim tglRujukan As Date = DateTimePickerTglRencanaBerkunjung.Value

                If CheckSQL("SELECT * FROM TransaksiDetailRujukan WHERE NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL") Then
                    ' Update
                    Dim parameterUpdate As String = "KodePPK = '" & TextBoxKodeFaskesRujukan.Text & "'," & _
                                                    "KeteranganPPK = '" & TextBoxNamaFaskesRujukan.Text & "'," & _
                                                    "TanggalRujukan = '" & tglRujukan & "'," & _
                                                    "JenisRujukan = '" & TextBoxJenisRujukan.Text & "'," & _
                                                    "TipeRujukan = '-'," & _
                                                    "KodeKhusus = '" & TextBoxKodeKhusus.Text & "'," & _
                                                    "KeteranganKhusus = '" & TextBoxNamaKhusus.Text & "'," & _
                                                    "KodeSubSpesialis = '" & TextBoxKodeSpesialis.Text & "'," & _
                                                    "KeteranganSubSpesialis = '" & TextBoxNamaSpesialis.Text & "'," & _
                                                    "KodeSarana = '" & TextBoxKodeSarana.Text & "'," & _
                                                    "KeteranganSarana = '" & TextBoxNamaSarana.Text & "'," & _
                                                    "Catatan = '" & TextBoxCatatanRujukan.Text & "'," & _
                                                    "KodeTACC = '" & TextBoxKodeTACC.Text & "'," & _
                                                    "KeteranganTACC = '" & TextBoxKeteranganTACC.Text & "'," & _
                                                    "JadwalPraktek = '" & TextBoxJadwalPraktekRujukan.Text & "'," & _
                                                    "AlasanTACC = '" & TextBoxAlasanTACC.Text & "'," & _
                                                    "ChangeBy = '" & userInput & "', ChangeDate = GETDATE()"

                    WriteSQL("UPDATE TransaksiDetailRujukan SET " & parameterUpdate & " WHERE NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL", 4)
                Else
                    ' Insert
                    WriteSQL("INSERT INTO TransaksiDetailRujukan (NoTransaksi, KodePPK, KeteranganPPK, TanggalRujukan, JenisRujukan, TipeRujukan, KodeKhusus, KeteranganKhusus, KodeSubSpesialis, KeteranganSubSpesialis, KodeSarana, KeteranganSarana, Catatan, KodeTACC, KeteranganTACC, AlasanTACC, JadwalPraktek, CreatedBy, CreatedDate) " & _
                             "VALUES('" & idTransaksi & "', '" & TextBoxKodeFaskesRujukan.Text & "', '" & TextBoxNamaFaskesRujukan.Text & "', '" & tglRujukan & "', '" & TextBoxJenisRujukan.Text & "', '-', '" & TextBoxKodeKhusus.Text & "', '" & TextBoxNamaKhusus.Text & "', '" & TextBoxKodeSpesialis.Text & "', " & _
                             "'" & TextBoxNamaSpesialis.Text & "', '" & TextBoxKodeSarana.Text & "', '" & TextBoxNamaSarana.Text & "', '" & TextBoxCatatanRujukan.Text & "', '" & TextBoxKodeTACC.Text & "', '" & TextBoxKeteranganTACC.Text & "', '" & TextBoxAlasanTACC.Text & "', '" & TextBoxJadwalPraktekRujukan.Text & "', '" & userInput & "', GETDATE())", 4)
                End If

                ' Simpan detail rujukan BPJS jika ada
                SaveDetailRujukan()

                ' ===================== Rujukan Non-BPJS =====================
            ElseIf statusPulang.Contains("Rjk") Then
                Dim tglRujukan As Date = dtTanggalRujukan.Value
                Dim pemeriksaanFisik As String = BuildPemeriksaanFisik()
                Dim diagnosaSementaraStr As String = BuildDiagnosaSementara()

                If CheckSQL("SELECT * FROM TransaksiDetailRujukanNonBPJS WHERE NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL") Then
                    ' Update
                    Dim parameterUpdate As String = "Klinik = '" & TextBoxKlinik.Text & "'," & _
                                                    "NoRujukan = '" & TextBoxNoRujukan.Text & "'," & _
                                                    "KeRS = '" & TextBoxRujukan.Text & "'," & _
                                                    "TanggalRujukan = '" & tglRujukan & "'," & _
                                                    "NamaPenderita = '" & TextBoxNamaPendertia.Text & "'," & _
                                                    "StatusHubungan = '" & CBStatusHubungan.Text & "'," & _
                                                    "JenisKelamin = '" & TextBoxJenisKelamin.Text & "'," & _
                                                    "NamaPeserta = '" & TextBoxNamaPeserta.Text & "'," & _
                                                    "Perusahaan = '" & TextBoxCompany.Text & "'," & _
                                                    "NamaKartuPeserta = '" & TextBoxNamaKartu.Text & "'," & _
                                                    "Anamnesa = '" & TextBoxAnamnesa.Text & "'," & _
                                                    "PemeriksaanFisik = '" & pemeriksaanFisik & "'," & _
                                                    "DiagnosaSementara = '" & diagnosaSementaraStr & "'," & _
                                                    "TerapiSementara = '" & TextBoxTerapiSementara.Text & "'," & _
                                                    "Poli = '" & TextBoxPoli.Text & "'," & _
                                                    "ChangeBy = '" & userInput & "', ChangeDate = GETDATE()"

                    WriteSQL("UPDATE TransaksiDetailRujukanNonBPJS SET " & parameterUpdate & " WHERE NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL", 4)
                Else
                    ' Insert
                    WriteSQL("INSERT INTO TransaksiDetailRujukanNonBPJS (NoTransaksi, Klinik, NoRujukan, KeRS, TanggalRujukan, NamaPenderita, StatusHubungan, JenisKelamin, NamaPeserta, Perusahaan, NamaKartuPeserta, Anamnesa, PemeriksaanFisik, DiagnosaSementara, TerapiSementara, CreatedBy, Poli, CreatedDate) " & _
                             "VALUES('" & idTransaksi & "', '" & TextBoxKlinik.Text & "', '" & TextBoxNoRujukan.Text & "', '" & TextBoxRujukan.Text & "', '" & tglRujukan & "', '" & TextBoxNamaPendertia.Text & "', '" & CBStatusHubungan.Text & "', '" & TextBoxJenisKelamin.Text & "', " & _
                             "'" & TextBoxNamaPeserta.Text & "', '" & TextBoxCompany.Text & "', '" & TextBoxNamaKartu.Text & "', '" & TextBoxRujukan.Text & "', '" & pemeriksaanFisik & "', '" & diagnosaSementaraStr & "', '" & TextBoxTerapiSementara.Text & "', '" & userInput & "' , '" & TextBoxPoli.Text & "', GETDATE())", 4)
                End If

                ' ===================== Non-Rujukan =====================
            Else
                ' Soft delete rujukan BPJS
                WriteSQL("UPDATE TransaksiDetailRujukan " & _
                         "SET DeletedBy = '" & userInput & "', DeletedDate = GETDATE() " & _
                         "WHERE NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL", 4)

                ' Soft delete rujukan Non-BPJS
                WriteSQL("UPDATE TransaksiDetailRujukanNonBPJS " & _
                         "SET DeletedBy = '" & userInput & "', DeletedDate = GETDATE() " & _
                         "WHERE NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL", 4)

                'WAJIB: Kosongkan ringkasan rujukan
                WriteSQL("UPDATE TransaksiDetail SET Rujukan = NULL WHERE NoUrut = '" & idTransaksi & "'", 4)
            End If

            ' ===================== Update Status Pulang =====================
            WriteSQL("UPDATE TransaksiDetail SET StatusPulang = '" & statusPulang & "' WHERE NoUrut = '" & idTransaksi & "'", 4)

            ' ===================== Update status antrian Hyu ================
            Dim sql As String = "SELECT TD.NoAntreanHyu, MP.NoNIK " & _
                  "FROM TransaksiDetail TD " & _
                  "INNER JOIN MasterPasien MP ON TD.IDInternet = MP.NoRekamMedis " & _
                  "WHERE TD.NoUrut = '" & idTransaksi & "'"

            Dim tbl As DataTable = ReadSQL(sql)

            If tbl.Rows.Count = 0 Then
                MsgBox("Data antrean tidak ditemukan", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            Dim nomorAntrean As String = If(IsDBNull(tbl.Rows(0)("NoAntreanHyu")), "", tbl.Rows(0)("NoAntreanHyu").ToString())
            Dim nomorNIK As String = If(IsDBNull(tbl.Rows(0)("NoNIK")), "", tbl.Rows(0)("NoNIK").ToString())
            Dim isExist As Boolean = CheckSQL("SELECT 1 FROM TransaksiObat WHERE NoTransaksi = '" & idTransaksi & "'")

            If Not nomorAntrean.ToUpper().Contains("OFF") Then

                If isExist Then
                    If SendPCareDataV3(nomorNIK, nomorAntrean, "menunggu_obat", "farmasi") = False Then Exit Sub
                Else
                    If SendPCareDataV3(nomorNIK, nomorAntrean, "selesai", "selesai") = False Then Exit Sub
                End If

            Else
                Dim sqlOffline As String = _
                    "SELECT " & _
                    "CONVERT(VARCHAR(10), TD.TanggalTransaksi, 23) AS TanggalTransaksi, " & _
                    "MPT.KodeBPJS, " & _
                    "MD.KodeBridgingPCare, " & _
                    "MP.NoNIK " & _
                    "FROM TransaksiDetail TD " & _
                    "INNER JOIN MasterPoliTujuan MPT " & _
                    "ON TD.JenisPoli = MPT.NamaPoli " & _
                    "INNER JOIN TransaksiPoli TP " & _
                    "ON TD.NoUrut = TP.NoUrut " & _
                    "INNER JOIN MasterDokter MD " & _
                    "ON TP.KodeDokter = MD.ID " & _
                    "INNER JOIN MasterPasien MP " & _
                    "ON TD.IDInternet = MP.NoRekamMedis " & _
                    "WHERE TD.NoUrut = '" & idTransaksi & "'"

                Dim tblOffline As DataTable = ReadSQL(sqlOffline)

                If tblOffline.Rows.Count > 0 Then

                    Dim tanggalTransaksi As String = tblOffline.Rows(0)("TanggalTransaksi").ToString()
                    Dim kodeBPJS As String = tblOffline.Rows(0)("KodeBPJS").ToString()
                    Dim kodeDokter As String = tblOffline.Rows(0)("KodeBridgingPCare").ToString()
                    Dim nik As String = tblOffline.Rows(0)("NoNIK").ToString()

                    'MsgBox("Tanggal : " & tanggalTransaksi)

                    Dim urlWebService As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
                    Dim loc As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NoPoli'")

                    Dim url As String = urlWebService & _
                     "api/antrian/pasien?kode_klinik=" & loc & _
                     "&visit_date=" & tanggalTransaksi & _
                     "&clinic_code=" & kodeBPJS & _
                     "&doctor_code=" & kodeDokter & _
                     "&patient_nik=" & nik

                    Dim responseString As String = GetDataAPIRM(url)
                    Dim jsonObj As JObject = JObject.Parse(responseString)

                    Dim validHyu As Boolean = True
                    Dim nomorAntreanHyu As String = ""

                    If jsonObj("status") Is Nothing OrElse jsonObj("status").ToString() <> "success" Then
                        MessageBox.Show("Gagal ambil data antrean HYU", "Error")
                        validHyu = False
                    ElseIf jsonObj("data") Is Nothing Then
                        ' MessageBox.Show("Data kosong", "Info")
                        validHyu = False
                    Else
                        Dim dataArray As JArray = CType(jsonObj("data"), JArray)

                        If dataArray.Count = 0 Then
                            MessageBox.Show("Antrean HYU tidak ditemukan", "Info")
                            validHyu = False
                        Else
                            nomorAntreanHyu = dataArray(0)("nomor_antrean").ToString()

                            If String.IsNullOrEmpty(nomorAntreanHyu) Then
                                MessageBox.Show("Nomor antrean HYU kosong", "Info")
                                validHyu = False
                            End If
                        End If
                    End If

                    If validHyu = True Then
                        Dim sqlUpdate As String = _
                            "UPDATE TransaksiDetail " & _
                            "SET NoAntreanHyu = '" & nomorAntreanHyu & "' " & _
                            "WHERE NoUrut = '" & idTransaksi & "'"

                        WriteSQL(sqlUpdate, 4)

                        If isExist Then
                            If SendPCareDataV3(nomorNIK, nomorAntreanHyu, "menunggu_obat", "farmasi") = False Then Exit Sub
                        Else
                            If SendPCareDataV3(nomorNIK, nomorAntreanHyu, "selesai", "selesai") = False Then Exit Sub
                        End If
                    End If
                End If
                'MsgBox("Antrean OFFLINE, skip update status Hyu", MsgBoxStyle.Exclamation)
            End If

            ' ===================== Kirim ke PCare Jika BPJS =====================
            If statusBPJS AndAlso CheckBridgingPcareActive() Then
                SaveKunjunganBPJS()
            End If

            ' ===================== Notifikasi Sukses =====================
            If noKunjunganBPJS.Length > 0 Then
                MsgBox("Data berhasil disimpan." & vbCrLf & "No kunjungan PCare: " & noKunjunganBPJS, MsgBoxStyle.Information, "Success!")
            Else
                MsgBox("Data berhasil disimpan.", MsgBoxStyle.Information, "Success!")
            End If

            ' Update status transaksi menjadi > Sudah Diperiksa
            If jenisTransaksi = "UMUM" Or jenisTransaksi = "POLI" Then
                WriteSQL("UPDATE TransaksiPoli SET StatusTransaksi = 'finished', FinishedDate = GETDATE(), StatusKeterangan = 'Sudah Diperiksa' WHERE NoUrut = '" & idTransaksi & "' AND StatusKeterangan <> 'Sudah Diperiksa'", 4)
            ElseIf jenisTransaksi = "GIGI" Then
                WriteSQL("UPDATE TransaksiGigi SET StatusTransaksi = 'finished', FinishedDate = GETDATE(), StatusKeterangan = 'Sudah Diperiksa' WHERE NoUrut = '" & idTransaksi & "' AND StatusKeterangan <> 'Sudah Diperiksa'", 4)
            End If

            ' Safety net: jika bukan rujukan, pastikan kolom rujukan kosong
            If Not statusPulang.Contains("Rujuk") AndAlso Not statusPulang.Contains("Rjk") Then
                WriteSQL("UPDATE TransaksiDetail SET Rujukan = NULL WHERE NoUrut = '" & idTransaksi & "'", 4)
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Function BuildPemeriksaanFisik() As String
        Dim pf As String = ""
        pf &= "Keadaan Umum: " & GetKeadaanUmum("Medik") & " | "
        pf &= "Kesadaran: " & GetKesadaran("Medik") & " | "
        pf &= "Skala Nyeri: " & TrackBarSkalaNyeriMedik.Value.ToString() & " | "
        pf &= "TD: " & TextBoxSistoleMedik.Text & "/" & TextBoxDiastoleMedik.Text & " mmHg | "
        pf &= "Nadi: " & TextBoxDetakNadiMedik.Text & " x/mnt | "
        pf &= "Nafas: " & TextBoxNafasMedik.Text & " x/mnt | "
        pf &= "Suhu: " & TextBoxSuhuMedik.Text & " °C | "
        pf &= "Saturasi: " & TextBoxSaturasiMedik.Text & " % | "
        pf &= "TB: " & TextBoxTinggiBadanMedik.Text & " cm | "
        pf &= "BB: " & TextBoxBeratBadanMedik.Text & " kg | "
        pf &= "Lingkar Perut: " & TextBoxLingkarPerutMedik.Text & " cm | "
        pf &= "IMT: " & TextBoxIndeksMedik.Text & " (" & TextBoxIndeksKeteranganMedik.Text & ")"
        Return pf.Replace("'", "''")
    End Function

    Private Function BuildDiagnosaSementara() As String
        Dim diagnosaTable As DataTable = ReadSQL("SELECT * FROM TransaksiDetailDiagnosa WHERE NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL")
        Dim result As New System.Text.StringBuilder()

        For Each row As DataRow In diagnosaTable.Rows
            result.Append(row("KeteranganDiagnosa").ToString() & ";")
        Next

        If result.Length > 0 Then result.Length -= 1 ' Remove trailing semicolon
        Return result.ToString().Replace("'", "''")
    End Function


    Private Sub SaveDetailRujukan()
        Dim detailRujukan As String = ""
        Dim tempDetailRujukan As String = ""
        Dim keteranganRujukan As String = ""

        Dim tblRujukan As DataTable = ReadSQL("SELECT TransaksiDetailRujukan.* " & _
                                              "FROM TransaksiDetailRujukan " & _
                                              "WHERE NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL")

        If tblRujukan.Rows.Count > 0 Then
            Dim dataRujukan As DataRow = tblRujukan.Rows(0)

            If dataRujukan("JenisRujukan") = "Kondisi Khusus" Then
                If dataRujukan("KeteranganSubSpesialis") = "" Then
                    keteranganRujukan = dataRujukan("KeteranganPPK") & " (" & dataRujukan("KeteranganKhusus") & ")"
                Else
                    keteranganRujukan = dataRujukan("KeteranganPPK") & " (" & dataRujukan("KeteranganKhusus") & " - " & dataRujukan("KeteranganSubSpesialis") & ")"
                End If
            ElseIf dataRujukan("JenisRujukan") = "Spesialis" Then
                keteranganRujukan = dataRujukan("KeteranganPPK") & " (" & dataRujukan("KeteranganSubSpesialis") & ")"
            End If
        End If

        ' Update Keterangan Diagnosa
        WriteSQL("UPDATE TransaksiDetail SET Rujukan = '" & keteranganRujukan & "' WHERE NoUrut = '" & idTransaksi & "'", 4)
    End Sub

    Function ValidasiInputStatusPulang() As Boolean
        ' UATBPJS
        ' Validasi BPJS (DELETE)
        'If CheckSQL("SELECT * FROM MasterPasienAlergi WHERE NoRekamMedis = '" & idPasien & "' AND AlergiJenis = 'Makanan'") = False Then
        '    MsgBox("Masukkan alergi makanan terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
        '    Return False
        'ElseIf CheckSQL("SELECT * FROM MasterPasienAlergi WHERE NoRekamMedis = '" & idPasien & "' AND AlergiJenis = 'Obat'") = False Then
        '    MsgBox("Masukkan alergi obat terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
        '    Return False
        'ElseIf CheckSQL("SELECT * FROM MasterPasienAlergi WHERE NoRekamMedis = '" & idPasien & "' AND AlergiJenis = 'Udara'") = False Then
        '    MsgBox("Masukkan alergi udara terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
        '    Return False
        'End If

        ' Validasi Diagnosa
        If ValidasiDiagnosa() = False Then Return False

        ' Validasi Pemeriksaan Fisik
        If ValidasiPemeriksaanFisik() = False Then Return False

        ' Validasi Rujukan
        If ComboBoxStatusPulang.Text.Contains("Rujuk") = True Then
            If TextBoxJenisRujukan.Text = "" Then
                MsgBox("Pilih rujukan terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
                Return False
            End If

            ' Validasi Diagnosa Non Spesialistik
            If CheckSQL("SELECT * FROM TransaksiDetailDiagnosa WHERE NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL AND DiagnosaNonSpesialistik = 1") = True Then
                If TextBoxKodeTACC.Text.Length = 0 Then
                    MsgBox("Masukkan TACC terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")

                    LabelNonSpesialistik.Visible = True

                    Return False
                End If
            End If

            ' Validasi Tanggal Rencana Berkunjung
            Dim todayDate As Date = Date.Today
            Dim selectedDate As Date = DateTimePickerTglRencanaBerkunjung.Value.Date

            If selectedDate < todayDate Then
                MessageBox.Show("Tanggal yang dipilih tidak boleh kurang dari hari ini.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                ' Set nilai DateTimePicker ke tanggal hari ini
                DateTimePickerTglRencanaBerkunjung.Value = todayDate

                Return False
            End If
        End If

        Return True
    End Function

    Private Sub ButtonTambahTACC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTambahTACC.Click
        Dim tblsDiagnosa As DataTable = ReadSQL("SELECT * FROM TransaksiDetailDiagnosa WHERE NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL")

        ' Validasi input diagnosa
        If tblsDiagnosa.Rows.Count > 0 Then
            For Each trowDiagnosa As DataRow In tblsDiagnosa.Rows
                If trowDiagnosa("DiagnosaNonSpesialistik") = True Then
                    FindRujukanTACC.SetForm("RekamMedisDokterRujukanTACC")
                    FindRujukanTACC.ShowDialog()

                    LabelNonSpesialistik.Visible = True
                End If
            Next
        Else
            MsgBox("Diagnosa pasien tidak membutuhkan TACC.", MsgBoxStyle.Exclamation, "Warning!")
        End If
    End Sub

    Public Sub LoadRujukanTACC(ByRef txKodeTACC As String, ByRef txKeteranganTACC As String, ByRef txAlasanTACC As String, ByRef JenisDiagnosa As String)
        If JenisDiagnosa = "RekamMedisDokterRujukanTACC" Then
            TextBoxKodeTACC.Text = txKodeTACC
            TextBoxKeteranganTACC.Text = txKeteranganTACC
            TextBoxAlasanTACC.Text = txAlasanTACC
        End If
    End Sub

    Private Sub ComboBoxStatusPulang_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxStatusPulang.SelectedIndexChanged
        If ValidasiStatusPulang() = True Then
            If ComboBoxStatusPulang.Text = "Berobat Jalan" Or ComboBoxStatusPulang.Text = "Meninggal" Then
                SplitContainerRujukanHeader.Panel2Collapsed = True
                PanelRujukanHeader.Visible = True
                PanelRujukanNonBPJS.Visible = False
            ElseIf ComboBoxStatusPulang.Text.Contains("Rujuk") = True Then
                ClearTabRujukan()
                SplitContainerRujukanHeader.Panel2Collapsed = False
                PanelRujukanHeader.Visible = True
                PanelRujukanNonBPJS.Visible = False

                ' --- Ambil data rujukan terakhir ---
                Dim sqlRujuk As String = "" & _
                    "SELECT TOP 1 " & _
                        "TDR.KeteranganPPK, " & _
                        "TDR.KeteranganSubSpesialis, " & _
                        "TDR.TanggalRujukan " & _
                    "FROM TransaksiDetail TD " & _
                    "INNER JOIN TransaksiDetailRujukan TDR " & _
                        "ON TD.NoUrut = TDR.NoTransaksi " & _
                    "WHERE TD.IDInternet = '" & idPasien & "' " & _
                    "ORDER BY TDR.TanggalRujukan DESC"

                Dim dtCheck As DataTable = ReadSQL(sqlRujuk)

                If dtCheck.Rows.Count > 0 Then
                    Dim keteranganPPK As String = dtCheck.Rows(0)("KeteranganPPK").ToString()
                    Dim subSpesialis As String = dtCheck.Rows(0)("KeteranganSubSpesialis").ToString()
                    Dim tanggalRujukan As String = Format(CDate(dtCheck.Rows(0)("TanggalRujukan")), "dd MMM yyyy")

                    MessageBox.Show("Pasien pernah dirujuk sebelumnya:" & vbCrLf & _
                        "PPK: " & keteranganPPK & vbCrLf & _
                        "Sub Spesialis: " & subSpesialis & vbCrLf & _
                        "Tanggal Rujukan: " & tanggalRujukan, _
                        "Informasi Rujukan Terakhir", _
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    MessageBox.Show("Tidak ditemukan riwayat rujukan sebelumnya.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            ElseIf ComboBoxStatusPulang.Text.Contains("Rjk") = True Then
                ClearTabRujukan()
                SplitContainerRujukanHeader.Panel2Collapsed = False
                'PanelRujukanHeader.Visible = False
                PanelRujukanNonBPJS.Visible = True
                TextBoxUmur.ReadOnly = True
                TextBoxJenisKelamin.ReadOnly = True
                TextBoxNamaPendertia.ReadOnly = True

                Dim sql As String = "SELECT MP.* FROM TransaksiDetail TD JOIN MasterPasien MP ON TD.IDInternet = MP.NoRekamMedis WHERE TD.NoUrut = '" & idTransaksi & "'"
                Dim sqlCheck As String = "SELECT * FROM TransaksiDetailRujukanNonBPJS WHERE NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL"

                Dim dtPasien As DataTable = ReadSQL(sql)
                Dim dtCheck As DataTable = ReadSQL(sqlCheck)

                If dtPasien.Rows.Count > 0 Then
                    ' Contoh mengambil data dari hasil query
                    Dim tglLahirStr As String = dtPasien.Rows(0)("TglLahir").ToString()
                    Dim tglLahir As Date = Date.Parse(tglLahirStr)
                    Dim umur As Integer = GetCurrentAge(tglLahir)
                    Dim jenisKelamin As String = dtPasien.Rows(0)("JenisKelamin").ToString()
                    Dim nama As String = dtPasien.Rows(0)("Nama").ToString()

                    TextBoxUmur.Text = umur
                    TextBoxJenisKelamin.Text = jenisKelamin
                    TextBoxNamaPendertia.Text = nama
                Else
                    MessageBox.Show("Data pasien tidak ditemukan.")
                End If

                If dtCheck.Rows.Count > 0 Then
                    Dim klinik As String = dtCheck.Rows(0)("Klinik").ToString()
                    Dim noRujukan As String = dtCheck.Rows(0)("NoRujukan").ToString()
                    Dim keRS As String = dtCheck.Rows(0)("KeRS").ToString()
                    Dim namaPenderita As String = dtCheck.Rows(0)("NamaPenderita").ToString()
                    Dim statusHubungan As String = dtCheck.Rows(0)("StatusHubungan").ToString()
                    'CBStatusHubungan.Items.Clear()
                    CBStatusHubungan.Items.Add(statusHubungan)
                    CBStatusHubungan.SelectedIndex = 0
                    Dim namaPeserta As String = dtCheck.Rows(0)("NamaPeserta").ToString()
                    Dim perusahaan As String = dtCheck.Rows(0)("Perusahaan").ToString()
                    Dim namaKartuPeserta As String = dtCheck.Rows(0)("NamaKartuPeserta").ToString()
                    Dim anamnesa As String = dtCheck.Rows(0)("Anamnesa").ToString()
                    Dim pemeriksaanFisik As String = dtCheck.Rows(0)("PemeriksaanFisik").ToString()
                    Dim diagnosaSementara As String = dtCheck.Rows(0)("DiagnosaSementara").ToString()
                    Dim terapiSementara As String = dtCheck.Rows(0)("TerapiSementara").ToString()
                    Dim poli As String = dtCheck.Rows(0)("Poli").ToString()

                    TextBoxKlinik.Text = klinik
                    TextBoxNoRujukan.Text = noRujukan
                    TextBoxRujukan.Text = keRS
                    TextBoxNamaPendertia.Text = namaPenderita
                    TextBoxNamaPeserta.Text = namaPeserta
                    TextBoxCompany.Text = perusahaan
                    TextBoxNamaKartu.Text = namaKartuPeserta
                    TextBoxAnamnesa.Text = anamnesa
                    TextBoxDiagnosa.Text = diagnosaSementara
                    TextBoxTerapiSementara.Text = terapiSementara
                    TextBoxPoli.Text = poli
                End If
            End If
        Else
            ComboBoxStatusPulang.Text = "Berobat Jalan"
        End If
    End Sub

    Function ValidasiStatusPulang() As Boolean
        If ComboBoxStatusPulang.Text.Contains("Rujuk") = True Then
            ' Validasi Diagnosa
            If ValidasiDiagnosa() = False Then Return False

            ' Validasi Pemeriksaan Fisik
            If ValidasiPemeriksaanFisik() = False Then Return False

            ' Validasi config sistem PCare aktif
            If statusBPJS = False Or CheckBridgingPcareActive() = False Then
                MsgBox("status pcare tidak aktif.", MsgBoxStyle.Critical, "warning!")
                Return False
            End If

            ' Validasi bridging PCare aktif
            If ValidateBridgingPcare() = False Then Return False

        ElseIf ComboBoxStatusPulang.Text = "Rjk" Then
            ' Untuk Rujukan Vertikal (Non BPJS), tidak validasi PCare
            ' Tapi tetap validasi data lokal
            If ValidasiDiagnosa() = False Then Return False
            If ValidasiPemeriksaanFisik() = False Then Return False
        End If

        Return True
    End Function


    Private Sub ButtonCetakRujukan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCetakRujukan.Click
        Try
            ' Cek data sudah ada / tidak
            If CheckSQL("SELECT * FROM TransaksiDetailRujukan WHERE NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL") = False Then
                MsgBox("Input rujukan di RME terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
                Exit Sub
            End If

            If noKunjunganBPJS <> "" Then
                Dim getResponse As String = ""
                Dim messageError As String = ""
                Dim uri As String = urlPcare & "kunjungan/rujukan/" & noKunjunganBPJS
                Dim keteranganTACC As String = ""

                Dim tblsReport As DataTable = CreateTableReportKunjungan()
                tblsReport.Rows.Clear()

                getResponse = getDataFromPcare(uri)

                If getResponse <> "Nothing" Then
                    Dim varsespoli() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of varJson())(getResponse)

                    For Each oneVar As varJson In varsespoli
                        If oneVar.metaData.message <> "NO_CONTENT" Then
                            Dim rowReport As DataRow = tblsReport.NewRow

                            rowReport("Kedeputian Wilayah") = oneVar.response.ppk.kc.kdKR.nmKR
                            rowReport("Kantor Cabang") = oneVar.response.ppk.kc.nmKC
                            rowReport("No Rujukan") = oneVar.response.noRujukan
                            rowReport("FKTP") = oneVar.response.ppk.nmPPK & " (" & oneVar.response.ppk.kdPPK & ")"
                            rowReport("Kabupaten/Kota") = oneVar.response.ppk.kc.dati.nmDati & " (" & oneVar.response.ppk.kc.dati.kdDati & ")"

                            Dim tblsRujukan As DataTable = ReadSQL("SELECT * FROM TransaksiDetailRujukan WHERE NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL")
                            Dim namaSpesialis As String = ""
                            Dim catatanRujukan As String = ""
                            Dim jadwalPraktek As String = ""

                            If tblsRujukan.Rows.Count > 0 Then
                                For Each trowRujukan As DataRow In tblsRujukan.Rows
                                    If trowRujukan("JenisRujukan") = "Kondisi Khusus" Then
                                        ' Rujukan Kondisi Khusus
                                        namaSpesialis = trowRujukan("KeteranganKhusus")
                                    ElseIf trowRujukan("JenisRujukan") = "Spesialis" Then
                                        ' Rujukan Spesialis
                                        namaSpesialis = trowRujukan("KeteranganSubSpesialis")
                                    End If

                                    catatanRujukan = trowRujukan("Catatan")
                                    jadwalPraktek = trowRujukan("JadwalPraktek")
                                Next
                            End If

                            rowReport("Spesialis") = namaSpesialis

                            rowReport("RS Tujuan Spesialis") = oneVar.response.ppkRujuk.nmPPK
                            rowReport("Jadwal Praktek") = jadwalPraktek

                            rowReport("Nama Pasien") = oneVar.response.nmPst
                            rowReport("No Kartu") = oneVar.response.nokaPst
                            rowReport("Catatan") = catatanRujukan

                            ' Get Diagnosa
                            Dim ketDiagnosa As String = ReadSQLNIK("SELECT Diagnosa FROM TransaksiDetail WHERE NoUrut = '" & idTransaksi & "'")
                            'If oneVar.response.diag1 IsNot Nothing Then ketDiagnosa = oneVar.response.diag1.nmDiag & " (" & oneVar.response.diag1.kdDiag & ")"
                            'If oneVar.response.diag2 IsNot Nothing Then ketDiagnosa = ketDiagnosa & ", " & oneVar.response.diag2.nmDiag & " (" & oneVar.response.diag2.kdDiag & ")"
                            'If oneVar.response.diag3 IsNot Nothing Then ketDiagnosa = ketDiagnosa & ", " & oneVar.response.diag3.nmDiag & " (" & oneVar.response.diag3.kdDiag & ")"
                            rowReport("Diagnosa") = ketDiagnosa

                            rowReport("Umur") = GetCurrentAge(Date.ParseExact(oneVar.response.tglLahir, "dd-MM-yyyy", Nothing).ToString("MM/dd/yyyy"))
                            rowReport("Tanggal Lahir") = Date.ParseExact(oneVar.response.tglLahir, "dd-MM-yyyy", Nothing).ToString("dd-MMM-yyyy")
                            rowReport("Status") = oneVar.response.pisa
                            rowReport("L/P") = oneVar.response.sex
                            rowReport("Catatan 2") = oneVar.response.catatanRujuk

                            rowReport("Dokter") = oneVar.response.dokter.nmDokter
                            rowReport("Tgl Rencana Rujukan") = Date.ParseExact(oneVar.response.tglEstRujuk, "dd-MM-yyyy", Nothing).ToString("dd-MMM-yyyy")
                            rowReport("Tgl Akhir Rujukan") = Date.ParseExact(oneVar.response.tglAkhirRujuk, "dd-MM-yyyy", Nothing).ToString("dd-MMM-yyyy")
                            rowReport("Tgl Kunjungan") = Date.ParseExact(oneVar.response.tglKunjungan, "dd-MM-yyyy", Nothing).ToString("dd-MMM-yyyy")

                            ' Keterangan TACC
                            If oneVar.response.tacc.nmTacc <> "" Then
                                keteranganTACC = "# Alasan Rujuk Diagnosa Non-Spesialistik : " & "(" & oneVar.response.tacc.nmTacc & ") " & oneVar.response.tacc.alasanTacc
                            End If

                            rowReport("Keterangan TACC") = keteranganTACC

                            tblsReport.Rows.Add(rowReport)
                        End If
                    Next

                    Report = New XtraReport
                    If RadioButtonRujukLanjut.Checked = True Then
                        Report = XtraReport.FromFile(Application.StartupPath + "\reports\Klinik\BPJS\LaporanRujukBPJS.repx", True)
                        Report.DataSource = tblsReport
                        Report.Bands.Item(BandKind.TopMargin).Controls("lbljenissetoran").Text = "Surat Rujukan FKTP"
                    ElseIf RadioButtonRujukBalik.Checked = True Then
                        Report = XtraReport.FromFile(Application.StartupPath + "\reports\Klinik\BPJS\LaporanRujukBalikBPJS.repx", True)
                        Report.DataSource = tblsReport
                        Report.Bands.Item(BandKind.TopMargin).Controls("lbljenissetoran").Text = "Surat Rujukan FKTP"
                    End If

                    'Report.RunDesigner()
                    Report.ShowPreview()
                    'Report.Print()
                Else
                    MsgBox("Data tidak ditemukan.", MsgBoxStyle.Critical, "Warning!")
                End If
            Else
                MsgBox("Input Kunjungan BPJS terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Function CreateTableReportKunjungan() As DataTable
        Dim Thasil As New DataTable
        insertRowToTbls(Thasil, "Typstring", "Kedeputian Wilayah")
        insertRowToTbls(Thasil, "Typstring", "Kantor Cabang")
        insertRowToTbls(Thasil, "Typstring", "No Rujukan")
        insertRowToTbls(Thasil, "Typstring", "FKTP")
        insertRowToTbls(Thasil, "Typstring", "Kabupaten/Kota")
        insertRowToTbls(Thasil, "Typstring", "Spesialis")
        insertRowToTbls(Thasil, "Typstring", "RS Tujuan Spesialis")

        insertRowToTbls(Thasil, "Typstring", "Nama Pasien")
        insertRowToTbls(Thasil, "Typstring", "No Kartu")
        insertRowToTbls(Thasil, "Typstring", "Diagnosa")
        insertRowToTbls(Thasil, "Typstring", "Catatan")

        insertRowToTbls(Thasil, "Typstring", "Umur")
        insertRowToTbls(Thasil, "Typstring", "Tanggal Lahir")
        insertRowToTbls(Thasil, "Typstring", "Status")
        insertRowToTbls(Thasil, "Typstring", "L/P")
        insertRowToTbls(Thasil, "Typstring", "Catatan 2")

        insertRowToTbls(Thasil, "Typstring", "Dokter")
        insertRowToTbls(Thasil, "Typstring", "Jadwal Praktek")
        insertRowToTbls(Thasil, "Typstring", "Tgl Rencana Rujukan")
        insertRowToTbls(Thasil, "Typstring", "Tgl Akhir Rujukan")
        insertRowToTbls(Thasil, "Typstring", "Tgl Kunjungan")

        insertRowToTbls(Thasil, "Typstring", "Keterangan TACC")

        Return Thasil
    End Function

    Function CreateTableRiwayatKunjunganBPJS() As DataTable
        Dim Thasil As New DataTable
        insertRowToTbls(Thasil, "Typstring", "No. Kunjungan")
        insertRowToTbls(Thasil, "Typstring", "Faskes")
        insertRowToTbls(Thasil, "Typstring", "Poli")
        insertRowToTbls(Thasil, "Typstring", "Tgl. Layanan")
        insertRowToTbls(Thasil, "Typstring", "Diagnosa")

        For Each Tcol As DataColumn In Thasil.Columns
            Tcol.ReadOnly = True
        Next

        Return Thasil
    End Function

    Function CreateTableRiwayatKunjungan() As DataTable
        Dim Thasil As New DataTable
        insertRowToTbls(Thasil, "Typstring", "Tgl Kunjungan")
        insertRowToTbls(Thasil, "Typstring", "No Transaksi")
        insertRowToTbls(Thasil, "Typstring", "Keluhan Utama")
        insertRowToTbls(Thasil, "Typstring", "Poli")
        insertRowToTbls(Thasil, "Typstring", "Diagnosa")

        For Each Tcol As DataColumn In Thasil.Columns
            Tcol.ReadOnly = True
        Next

        Return Thasil
    End Function

    Private Sub ButtonCariRiwayatKunjungan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCariRiwayatKunjungan.Click
        Try
            If RadioButtonRiwayatKunjunganPoli.Checked = True Then
                If ComboBoxPoliTujuan.SelectedIndex <> -1 Then
                    GetRiwayatKunjungan()
                Else
                    MsgBox("Pilih poli tujuan terlebih dahulu.", MsgBoxStyle.Critical, "Warning!")
                End If
            ElseIf RadioButtonRiwayatPelayananBPJS.Checked = True Then
                If noBPJS <> "" Then
                    GetRiwayatKunjunganBPJS()
                Else
                    MsgBox("Peserta tidak terdaftar di BPJS", MsgBoxStyle.Critical, "Warning!")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Public Sub GetRiwayatKunjungan()
        DataGridViewRiwayatKunjungan.Rows.Clear()
        DataGridViewRiwayatKunjungan.Columns.Clear()

        'Gunakan nilai filter tanggal jika tersedia
        If TglAwalFilter <> Date.MinValue Then
            TglAwalRiwayat.Value = TglAwalFilter
        End If

        If TglAkhirFilter <> Date.MinValue Then
            TglAkhirRiwayat.Value = TglAkhirFilter
        End If

        'Gunakan nilai dari DateTimePicker setelah di-set
        Dim Tawal As String = Format(TglAwalRiwayat.Value, "yyyy-MM-dd")
        Dim Takhir As String = Format(TglAkhirRiwayat.Value, "yyyy-MM-dd")

        Dim queryString As String = ""
        Dim queryOrderString As String = ""
        Dim queryPoliTujuanString As String = ""
        Dim jenisPoli As String = ""
        Dim sqlPoli As String = "SELECT JenisPoli FROM TransaksiDetail WHERE NoUrut = '" & idTransaksi & "'"
        Dim dtPoli As DataTable = ReadSQL(sqlPoli)

        If dtPoli.Rows.Count > 0 Then
            jenisPoli = dtPoli.Rows(0)("JenisPoli").ToString().Trim()
        End If

        If ComboBoxPoliTujuan.Text = "SEMUA TRANSAKSI" Then
            queryPoliTujuanString = ""
        Else
            queryPoliTujuanString = " AND c.JenisPoli = '" & ComboBoxPoliTujuan.Text & "'"
        End If

        queryString = "SELECT * FROM ( " & _
            "SELECT a.NoUrut AS 'No Transaksi', CONVERT(VARCHAR, TglPoli, 120) AS 'Tanggal', " & _
            "c.KeluhanUtama AS 'Keluhan Utama', c.JenisPoli AS 'Layanan', c.Diagnosa AS 'Diagnosis', " & _
            "c.Resep AS 'Resep', " & _
            "(" & _
            "   ISNULL(( " & _
            "   SELECT STUFF(( " & _
            "   SELECT ' | ' + tpd.NamaTindakan " & _
            "   FROM TransaksiPoliDetail tpd " & _
            "   WHERE(tpd.TransPoliID = a.TransPoliID) " & _
            "  AND tpd.StatusPembayaran = 'PAID' " & _
            "  AND tpd.DeletedDate IS NULL " & _
            "  AND tpd.JenisTindakan NOT LIKE '%Konsul%' " & _
            "   FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 3, '') " & _
            "   ), '') " & _
            ") AS 'Tindakan', " & _
            "c.Rujukan AS 'Rujukan', a.DokterPoli AS 'Dokter', d.Sistole, d.Diastole, d.HeartRate, d.RespiratoryRate, d.Suhu " & _
            "FROM TransaksiPoli a " & _
            "LEFT JOIN TransaksiDetail c ON a.NoUrut=c.NoUrut " & _
            "LEFT JOIN TransaksiDetailFisik d ON a.NoUrut=d.NoTransaksi " & _
            "LEFT JOIN MasterPasien b ON a.idinternet=b.NoRekamMedis " & _
            "WHERE b.NoRekamMedis = '" & idPasien & "' " & _
            "AND CONVERT(date, TglPoli) BETWEEN '" & Tawal & "' AND '" & Takhir & "' " & _
            "AND a.deleted<>1 " & queryPoliTujuanString & " " & _
            "AND (" & _
            "   ISNULL(c.Diagnosa, '') <> '' OR " & _
            "   d.Sistole IS NOT NULL OR " & _
            "   d.Diastole IS NOT NULL OR " & _
            "   d.HeartRate IS NOT NULL OR " & _
            "   d.RespiratoryRate IS NOT NULL OR " & _
            "   d.Suhu IS NOT NULL " & _
            ") " & _
            "UNION ALL " & _
            "SELECT a.NoUrut AS 'No Transaksi', CONVERT(VARCHAR, TglGigi, 120) AS 'Tanggal', " & _
            "c.KeluhanUtama AS 'Keluhan Utama', c.JenisPoli AS 'Layanan', c.Diagnosa AS 'Diagnosis', " & _
            "c.Resep AS 'Resep', " & _
            "(" & _
            "   ISNULL(c.Tindakan, '') + " & _
            "   ISNULL(" & _
            "       '' + (" & _
            "           SELECT STUFF((" & _
            "               SELECT ' | ' + tgd.NamaTindakan " & _
            "               FROM TransaksiGigiDetail tgd " & _
            "               WHERE tgd.TransGigiID = a.TransGigiID " & _
            "                 AND tgd.StatusPembayaran = 'PAID' " & _
            "                 AND tgd.DeletedDate IS NULL " & _
            "               FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 3, '')" & _
            "       ), ''" & _
            ")" & _
            ") AS 'Tindakan', c.Rujukan AS 'Rujukan', " & _
            "a.DokterGigi AS 'Dokter', d.Sistole, d.Diastole, d.HeartRate, d.RespiratoryRate, d.Suhu " & _
            "FROM TransaksiGigi a " & _
            "LEFT JOIN TransaksiDetail c ON a.NoUrut=c.NoUrut " & _
            "LEFT JOIN TransaksiDetailFisik d ON a.NoUrut=d.NoTransaksi " & _
            "LEFT JOIN MasterPasien b ON a.idinternet=b.NoRekamMedis " & _
            "WHERE b.NoRekamMedis = '" & idPasien & "' " & _
            "AND CONVERT(date, TglGigi) BETWEEN '" & Tawal & "' AND '" & Takhir & "' " & _
            "AND a.deleted<>1 " & queryPoliTujuanString & " " & _
            "AND a.deleted<>1 " & queryPoliTujuanString & " " & _
            "AND (" & _
            "   ISNULL(c.Diagnosa, '') <> '' OR " & _
            "   d.Sistole IS NOT NULL OR " & _
            "   d.Diastole IS NOT NULL OR " & _
            "   d.HeartRate IS NOT NULL OR " & _
            "   d.RespiratoryRate IS NOT NULL OR " & _
            "   d.Suhu IS NOT NULL " & _
            ") " & _
            ") AS CombinedResults "
        queryOrderString = " ORDER BY Tanggal DESC"


        Dim Tbls As DataTable = ReadSQL(queryString & queryOrderString)
        If Tbls.Rows.Count > 0 Then
            CreateDataGridViewKunjunganPoli()

            For Each Trow As DataRow In Tbls.Rows
                ' Set Data Vital Statistik
                Dim dataItemsVitalStatistik As New List(Of String)()
                If Not String.IsNullOrEmpty(Trow("Sistole").ToString) Then
                    dataItemsVitalStatistik.Add("Sistole: " & Trow("Sistole").ToString)
                End If
                If Not String.IsNullOrEmpty(Trow("Diastole").ToString) Then
                    dataItemsVitalStatistik.Add("Diastole: " & Trow("Diastole").ToString)
                End If
                If Not String.IsNullOrEmpty(Trow("HeartRate").ToString) Then
                    dataItemsVitalStatistik.Add("Heart Rate: " & Trow("HeartRate").ToString)
                End If
                If Not String.IsNullOrEmpty(Trow("RespiratoryRate").ToString) Then
                    dataItemsVitalStatistik.Add("Respiratory Rate: " & Trow("RespiratoryRate").ToString)
                End If
                If Not String.IsNullOrEmpty(Trow("Suhu").ToString) Then
                    dataItemsVitalStatistik.Add("Suhu: " & Trow("Suhu").ToString)
                End If

                Dim stringVitalStatistik As String = String.Join(vbCrLf, dataItemsVitalStatistik.ToArray())

                DataGridViewRiwayatKunjungan.Rows.Add(New String() {"" & Trow("No Transaksi") & "", "" & Trow("Tanggal") & "", "" & Trow("Keluhan Utama") & "", "" & Trow("Layanan") & "", "" & stringVitalStatistik & "", "" & Trow("Diagnosis") & "", "" & Trow("Resep") & "", "" & Trow("Tindakan") & "", "" & Trow("Rujukan") & "", "" & Trow("Dokter") & ""})
            Next

            DataGridViewRiwayatKunjungan.CurrentCell = Nothing
            DataGridViewRiwayatKunjungan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        Else
            MsgBox("Data tidak ditemukan.", MsgBoxStyle.Critical, "Warning!")
        End If
    End Sub

    Private Sub CreateDataGridViewKunjunganPoli()
        ' Auto resize all columns to fill DataGridView width
        DataGridViewRiwayatKunjungan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        ' Add columns
        DataGridViewRiwayatKunjungan.Columns.Add("ColumnNoTransaksi", "No Transaksi")
        DataGridViewRiwayatKunjungan.Columns.Add("ColumnTanggal", "Tanggal")
        DataGridViewRiwayatKunjungan.Columns.Add("ColumnKeluhanUtama", "Keluhan Utama")
        DataGridViewRiwayatKunjungan.Columns.Add("ColumnLayanan", "Layanan")
        DataGridViewRiwayatKunjungan.Columns.Add("ColumnVitalStatistik", "Vital Statistik")
        DataGridViewRiwayatKunjungan.Columns("ColumnVitalStatistik").FillWeight = 150
        DataGridViewRiwayatKunjungan.Columns.Add("ColumnDiagnosisKerja", "Diagnosis Kerja")
        DataGridViewRiwayatKunjungan.Columns("ColumnDiagnosisKerja").FillWeight = 150
        DataGridViewRiwayatKunjungan.Columns.Add("ColumnResep", "Resep")
        DataGridViewRiwayatKunjungan.Columns.Add("ColumnTindakan", "Tindakan")
        DataGridViewRiwayatKunjungan.Columns("ColumnTindakan").FillWeight = 150
        DataGridViewRiwayatKunjungan.Columns.Add("ColumnRujukan", "Rujukan")
        DataGridViewRiwayatKunjungan.Columns.Add("ColumnDokter", "Dokter")

        Dim buttonColumn As New DataGridViewButtonColumn()
        buttonColumn.HeaderText = "Aksi"
        buttonColumn.Text = "Detail"
        buttonColumn.Name = "ButtonDetail"
        buttonColumn.UseColumnTextForButtonValue = True
        buttonColumn.FlatStyle = FlatStyle.Standard
        DataGridViewRiwayatKunjungan.Columns.Add(buttonColumn)
    End Sub

    Private Sub CreateDataGridViewKunjunganBPJS()
        ' Add columns
        DataGridViewRiwayatKunjungan.Columns.Add("ColumnNoKunjungan", "No Kunjungan")
        DataGridViewRiwayatKunjungan.Columns.Add("ColumnFaskes", "Faskes")
        DataGridViewRiwayatKunjungan.Columns.Add("ColumnPoli", "Poli")
        DataGridViewRiwayatKunjungan.Columns.Add("ColumnTglLayanan", "Tgl. Layanan")
        DataGridViewRiwayatKunjungan.Columns.Add("ColumnDiagnosa", "Diagnosa")
    End Sub

    Private Sub CreateDataGridViewDiagnosa()
        ' Add columns
        DataGridViewDiagnosa.Columns.Add("ColumnTanggal", "Tanggal")
        DataGridViewDiagnosa.Columns.Add("ColumnKeteranganDiagnosa", "(ICD-X) Diagnosa")
        DataGridViewDiagnosa.Columns.Add("ColumnKasus", "Kasus")
        DataGridViewDiagnosa.Columns.Add("ColumnJenis", "Jenis")
        DataGridViewDiagnosa.Columns.Add("ColumnGigi", "Gigi")
        DataGridViewDiagnosa.Columns.Add("ColumnPoli", "Poli")

        Dim buttonColumn As New DataGridViewButtonColumn()
        buttonColumn.HeaderText = "Aksi"
        buttonColumn.Text = "Hapus"
        buttonColumn.Name = "ButtonDetail"
        buttonColumn.UseColumnTextForButtonValue = True
        buttonColumn.FlatStyle = FlatStyle.Standard
        DataGridViewDiagnosa.Columns.Add(buttonColumn)
    End Sub

    Private Sub CreateDataGridViewPemeriksaanPenunjang()
        ' Add columns
        DataGridViewPemeriksaanPenunjang.Columns.Add("ColumnID", "ID")
        DataGridViewPemeriksaanPenunjang.Columns.Add("ColumnTanggal", "Tanggal")
        DataGridViewPemeriksaanPenunjang.Columns.Add("ColumnNamaTindakan", "Nama Tindakan")
        DataGridViewPemeriksaanPenunjang.Columns.Add("ColumnJenisTindakan", "Jenis Tindakan")
        DataGridViewPemeriksaanPenunjang.Columns.Add("ColumnBiayaTindakan", "Biaya Tindakan")
        DataGridViewPemeriksaanPenunjang.Columns.Add("ColumnStatusPembayaran", "Status Pembayaran")

        Dim buttonColumn As New DataGridViewButtonColumn()
        buttonColumn.HeaderText = "Aksi"
        buttonColumn.Text = "Hapus"
        buttonColumn.Name = "ButtonDetail"
        buttonColumn.UseColumnTextForButtonValue = True
        buttonColumn.FlatStyle = FlatStyle.Standard
        DataGridViewPemeriksaanPenunjang.Columns.Add(buttonColumn)
    End Sub

    Private Sub CreateDataGridViewObat()
        ' Add columns
        DataGridViewObat.Columns.Add("ColumnObatID", "ObatID")
        DataGridViewObat.Columns.Add("ColumnObatNama", "ObatNama")
        DataGridViewObat.Columns.Add("ColumnObatSigna", "Signa")
        DataGridViewObat.Columns.Add("ColumnObatHarga", "Harga")
        DataGridViewObat.Columns.Add("ColumnJumlah", "Jumlah")
        DataGridViewObat.Columns.Add("ColumnTotal", "Total")
        DataGridViewObat.Columns.Add("ColumnStatusIMM", "IMM")
        DataGridViewObat.Columns.Add("ColumnRacikan", "Racikan")
        DataGridViewObat.Columns.Add("ColumnDpho", "DPHO")

        Dim buttonColumn As New DataGridViewButtonColumn()
        buttonColumn.HeaderText = "Aksi"
        buttonColumn.Text = "Hapus"
        buttonColumn.Name = "ButtonDetail"
        buttonColumn.UseColumnTextForButtonValue = True
        buttonColumn.FlatStyle = FlatStyle.Standard
        DataGridViewObat.Columns.Add(buttonColumn)

        ' Sembunyikan kolom
        DataGridViewObat.Columns("ColumnObatID").Visible = False
    End Sub

    Private Sub CreateDataGridViewTindakan()
        ' Add columns
        DataGridViewTindakan.Columns.Add("ColumnID", "ID")
        DataGridViewTindakan.Columns.Add("ColumnTindakanID", "TindakanID")
        DataGridViewTindakan.Columns.Add("ColumnNamaTindakan", "NamaTindakan")
        DataGridViewTindakan.Columns.Add("ColumnJenisTindakan", "JenisTindakan")
        DataGridViewTindakan.Columns.Add("ColumnPenjaminTindakan", "PenjaminTindakan")
        DataGridViewTindakan.Columns.Add("ColumnCreatedBy", "CreatedBy")
        DataGridViewTindakan.Columns.Add("ColumnCreatedDate", "CreatedDate")
        DataGridViewTindakan.Columns.Add("ColumnStatus", "Status")
        DataGridViewTindakan.Columns.Add("ColumnKuota", "Sisa Kuota")
        DataGridViewTindakan.Columns.Add("ColumnKodeVoucher", "Voucher")

        Dim informedConsentColumn As New DataGridViewButtonColumn()
        informedConsentColumn.HeaderText = "Informed Consent"
        informedConsentColumn.Text = "Preview"
        informedConsentColumn.Name = "ButtonInformedConsent"
        informedConsentColumn.UseColumnTextForButtonValue = True
        informedConsentColumn.FlatStyle = FlatStyle.Standard
        DataGridViewTindakan.Columns.Add(informedConsentColumn)

        Dim buttonColumn As New DataGridViewButtonColumn()
        buttonColumn.HeaderText = "Action"
        buttonColumn.Text = "Hapus"
        buttonColumn.Name = "ButtonDetail"
        buttonColumn.UseColumnTextForButtonValue = True
        buttonColumn.FlatStyle = FlatStyle.Standard
        DataGridViewTindakan.Columns.Add(buttonColumn)

        ' Sembunyikan kolom
        DataGridViewTindakan.Columns("ColumnID").Visible = False
        DataGridViewTindakan.Columns("ColumnTindakanID").Visible = False
        DataGridViewTindakan.Columns("ColumnKodeVoucher").Visible = False
    End Sub

    Private Sub GetRiwayatKunjunganBPJS()
        DataGridViewRiwayatKunjungan.Rows.Clear()
        DataGridViewRiwayatKunjungan.Columns.Clear()

        Dim getResponse As String = ""
        Dim messageError As String = ""
        Dim uri As String = urlPcare & "kunjungan/peserta/" & noBPJS

        getResponse = getDataFromPcare(uri)

        If getResponse <> "Nothing" Then
            CreateDataGridViewKunjunganBPJS()

            Dim varsespoli() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of varJson())(getResponse)

            For Each oneVar As varJson In varsespoli
                For index As Integer = 0 To oneVar.response.count - 1
                    If oneVar.metaData.message <> "NO_CONTENT" Then
                        ' Get Diagnosa
                        Dim ketDiagnosa As String = ""
                        If oneVar.response.list(index).diagnosa1.nmDiag IsNot Nothing Then ketDiagnosa = oneVar.response.list(index).diagnosa1.nmDiag
                        If oneVar.response.list(index).diagnosa2.nmDiag IsNot Nothing Then ketDiagnosa = ketDiagnosa & ", " & oneVar.response.list(index).diagnosa2.nmDiag
                        If oneVar.response.list(index).diagnosa3.nmDiag IsNot Nothing Then ketDiagnosa = ketDiagnosa & ", " & oneVar.response.list(index).diagnosa3.nmDiag

                        DataGridViewRiwayatKunjungan.Rows.Add(New String() {"" & oneVar.response.list(index).noKunjungan & "", "" & oneVar.response.list(index).providerPelayanan.nmProvider & "", "" & oneVar.response.list(index).poli.nmPoli & "", "" & oneVar.response.list(index).tglKunjungan & "", "" & ketDiagnosa & ""})
                    End If
                Next
            Next

            DataGridViewRiwayatKunjungan.CurrentCell = Nothing
            DataGridViewRiwayatKunjungan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Else
            MsgBox("Data tidak ditemukan.", MsgBoxStyle.Critical, "Warning!")
        End If
    End Sub

    Private Sub ButtonObjektif_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonObjektifFisik.Click, ButtonObjektifPemeriksaanGeneralis.Click, ButtonObjektifPemeriksaanDiagnostik.Click, ButtonObjektifPemeriksaanGigi.Click, ButtonObjektifPemeriksaanLab.Click, ButtonObjektifUploadGambar.Click
        Try
            Dim myButton = DirectCast(sender, Button)

            ' Set Default Waran Button
            ButtonObjektifFisik.BackColor = Color.FromArgb(0, 100, 200)
            ButtonObjektifPemeriksaanGeneralis.BackColor = Color.FromArgb(0, 100, 200)
            ButtonObjektifPemeriksaanDiagnostik.BackColor = Color.FromArgb(0, 100, 200)
            ButtonObjektifPemeriksaanGigi.BackColor = Color.FromArgb(0, 100, 200)
            ButtonObjektifPemeriksaanLab.BackColor = Color.FromArgb(0, 100, 200)
            ButtonObjektifUploadGambar.BackColor = Color.FromArgb(0, 100, 200)

            '# Buka TabPage 
            Select Case myButton.Name
                Case "ButtonObjektifFisik"
                    TabControlObjektif.SelectedTab = TabObjektifFisik
                Case "ButtonObjektifPemeriksaanGeneralis"
                    TabControlObjektif.SelectedTab = TabObjektifPemeriksaanGeneralis
                Case "ButtonObjektifPemeriksaanDiagnostik"
                    TabControlObjektif.SelectedTab = TabObjektifPemeriksaanDiagnostik
                Case "ButtonObjektifPemeriksaanGigi"
                    TabControlObjektif.SelectedTab = TabObjektifPemeriksaanGigi
                Case "ButtonObjektifPemeriksaanLab"
                    TabControlObjektif.SelectedTab = TabObjektifPemeriksaanLab
                Case "ButtonObjektifUploadGambar"
                    TabControlObjektif.SelectedTab = TabObjektifGambar
            End Select

            myButton.BackColor = Color.FromArgb(85, 99, 114) ' Ganti Warna Button
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub ButtonSimpanSubjektif_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSimpanSubjektif.Click
        SaveMedikSubjektif()
    End Sub

    Private Sub ButtonSimpanPemeriksaanFisikObjektif_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSimpanPemeriksaanFisikObjektif.Click
        SavePemeriksaanFisik()
    End Sub

    Private Sub ButtonSimpanPemeriksaanGeneralisObjektif_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSimpanPemeriksaanGeneralisObjektif.Click
        SavePemeriksaanGeneralis()
    End Sub

    Private Sub ButtonSimpanPemeriksaanDiagnostikObjektif_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSimpanPemeriksaanDiagnostikObjektif.Click
        SaveMedikSubjektif()
    End Sub

    Private Sub ButtonSimpanResikoJatuh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSimpanResikoJatuh.Click
        Try

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub ButtonFindTindakan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFindTindakan.Click
        If ValidasiTambahTindakan() = True Then
            Dim queryString As String = ""
            Dim queryOrderString As String = ""

            If jenisTransaksi = "UMUM" Or jenisTransaksi = "POLI" Then
                queryString = "SELECT TindakanID, NamaTindakan, JenisTindakan, JenisDokter, PARSENAME(CONVERT(varchar,convert(money,BiayaTindakan),1),2) as [BiayaTindakan], StatusInformedConsent " & _
                              "FROM MasterTindakan " & _
                              "WHERE Closed = 0 AND JenisTindakan NOT LIKE '%Konsultasi%' AND JenisTindakan NOT LIKE '%Administrasi%'"
                queryOrderString = " ORDER BY JenisTindakan, NamaTindakan"
            ElseIf jenisTransaksi = "GIGI" Then
                queryString = "SELECT TindakanID, NamaTindakan, JenisTindakan, PARSENAME(CONVERT(varchar, CONVERT(money, BiayaTindakan), 1), 2) AS [BiayaTindakan], StatusInformedConsent " & _
                              "FROM MasterTindakanGigi " & _
                              "WHERE Closed = 0 AND JenisTindakan NOT LIKE '%Konsultasi%' AND JenisTindakan NOT LIKE '%Administrasi%'"
                queryOrderString = " ORDER BY JenisTindakan, NamaTindakan"
            End If

            Find.Show()
            Find.Query(queryString, queryOrderString, "FindTindakanPoliPerencanaan", 1)
        Else
            ' Refresh Grid
            LoadGridTindakanPoli()
        End If
    End Sub

    Function ValidasiTambahTindakan() As Boolean
        ' Validasi Diagnosa
        If ValidasiDiagnosa() = False Then Return False

        ' Validasi Pemeriksaan Fisik
        If ValidasiPemeriksaanFisik() = False Then Return False

        ' Validasi apakah sudah dilakukan pembayaran
        If jenisTransaksi = "UMUM" Or jenisTransaksi = "POLI" Then
            If CheckSQL("SELECT * FROM TransaksiPoli WHERE NoUrut = '" & idTransaksi & "' AND ClosedBayar <> '12/31/9998'") = True Then
                MsgBox("Gagal. Transaksi sudah dilakukan pembayaran tindakan.", MsgBoxStyle.Exclamation, "Warning!")
                Return False
            End If
        ElseIf jenisTransaksi = "GIGI" Then
            If CheckSQL("SELECT * FROM TransaksiGigi WHERE NoUrut = '" & idTransaksi & "' AND ClosedBayar <> '12/31/9998'") = True Then
                MsgBox("Gagal. Transaksi sudah dilakukan pembayaran tindakan.", MsgBoxStyle.Exclamation, "Warning!")
                Return False
            End If
        End If

        ' Validasi jika beda hari
        If jenisTransaksi = "UMUM" Or jenisTransaksi = "POLI" Then
            If CheckSQL("SELECT * FROM TransaksiPoli WHERE NoUrut = '" & idTransaksi & "' AND CAST(TglPoli AS DATE) = CAST(GETDATE() AS DATE)") = False Then
                MsgBox("Gagal. Transaksi sudah melewati hari yang ditentukan.", MsgBoxStyle.Exclamation, "Warning!")
                Return False
            End If
        ElseIf jenisTransaksi = "GIGI" Then
            If CheckSQL("SELECT * FROM TransaksiGigi WHERE NoUrut = '" & idTransaksi & "' AND CAST(TglGigi AS DATE) = CAST(GETDATE() AS DATE)") = False Then
                MsgBox("Gagal. Transaksi sudah melewati hari yang ditentukan.", MsgBoxStyle.Exclamation, "Warning!")
                Return False
            End If
        End If

        Return True
    End Function

    Function ValidasiDiagnosa() As Boolean
        Dim tblsDiagnosa As DataTable = ReadSQL("SELECT * FROM TransaksiDetailDiagnosa WHERE NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL")
        If tblsDiagnosa.Rows.Count = 0 Then
            MsgBox("Masukkan diagnosa terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        Return True
    End Function

    Function ValidasiPemeriksaanFisik() As Boolean
        If CheckSQL("SELECT * FROM TransaksiDetailFisik WHERE NoTransaksi = '" & idTransaksi & "'") = False Then
            MsgBox("Isi pemeriksaan fisik terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        Return True
    End Function

    Function ValidasiPrognosa() As Boolean
        If CheckSQL("SELECT * FROM TransaksiDetailPrognosa WHERE NoTransaksi = '" & idTransaksi & "'") = False Then
            MsgBox("Isi prognosa terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        Return True
    End Function

    Private Sub CheckBoxInformedConsent_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxInformedConsent.CheckedChanged
        If CheckBoxInformedConsent.Checked = True Then
            Dim statusInformedConsent As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'SettingInformedConsent'")

            ' Tampilkan jika setting informed consent aktif
            If statusInformedConsent = "Yes" Then
                SplitContainerTindakan.Panel2Collapsed = False
            End If
        ElseIf CheckBoxInformedConsent.Checked = False Then
            SplitContainerTindakan.Panel2Collapsed = True
        End If
    End Sub

    Private Sub DataGridViewRiwayatKunjungan_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewRiwayatKunjungan.CellClick
        If e.RowIndex >= 0 Then
            If DataGridViewRiwayatKunjungan.Columns.Contains("ButtonDetail") Then
                If e.ColumnIndex = DataGridViewRiwayatKunjungan.Columns("ButtonDetail").Index Then
                    Dim noTransaksi As String = DataGridViewRiwayatKunjungan.Rows(e.RowIndex).Cells("ColumnNoTransaksi").Value.ToString()
                    CetakDetail(noTransaksi)
                End If
            End If
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim jenisOutputOdontogram As String = "Gambar"
        Dim textOutputOdontogram As String = "TEXT"
        Dim warnaOutputOdontogram As String = "#ffd662"
        Dim gambarOutputOdontogram As String = "Garis Lurus Atas"

        Dim Tbls As DataTable = ReadSQL("SELECT * FROM MasterOdontogramDetail WHERE (NamaBagian LIKE '%Full%') AND (JenisBagian = 'Garis Lurus Atas')")
        For Each Trow As DataRow In Tbls.Rows
            ' Mengkonversi gambar menjadi Bitmap 
            Dim originalImage As Bitmap = DirectCast(PictureBox1.Image, Bitmap)
            Dim fontOdontogram As New Font("Arial", 7, FontStyle.Bold)
            Dim colorText As String = ""

            ' Membuat salinan gambar asli
            Dim updatedImage As New Bitmap(originalImage)

            If jenisOutputOdontogram.Contains("Text Atas") And Trow("JenisBagian").ToString = "Text Atas" Then
                ShapeDrawingFunctions.DrawText(updatedImage, Trow("x1"), Trow("y1"), textOutputOdontogram, fontOdontogram, Color.Black)
            ElseIf jenisOutputOdontogram.Contains("Text Bawah") And Trow("JenisBagian").ToString = "Text Bawah" Then
                ShapeDrawingFunctions.DrawText(updatedImage, Trow("x1"), Trow("y1"), textOutputOdontogram, fontOdontogram, Color.Black)
            ElseIf jenisOutputOdontogram = "Warna" Then
                colorText = warnaOutputOdontogram
                Dim fillColor As Color = ColorTranslator.FromHtml(colorText)

                If Trow("JenisBagian").ToString = "Persegi" Then
                    DrawSquare(updatedImage, Trow("x1"), Trow("y1"), Trow("x2"), Trow("y2"), fillColor, Color.Black)
                ElseIf Trow("JenisBagian").ToString = "Trapesium" Then
                    ShapeDrawingFunctions.DrawTrapezium(updatedImage, Trow("x1"), Trow("y1"), Trow("x2"), Trow("y2"), Trow("x3"), Trow("y3"), Trow("x4"), Trow("y4"), fillColor, Color.Black)
                ElseIf Trow("JenisBagian").ToString = "Segitiga" Then
                    ShapeDrawingFunctions.DrawTriangle(updatedImage, Trow("x1"), Trow("y1"), Trow("x2"), Trow("y2"), Trow("x3"), Trow("y3"), fillColor, Color.Black)
                End If
            ElseIf jenisOutputOdontogram.Contains("Gambar") And gambarOutputOdontogram.Contains(Trow("JenisBagian").ToString) Then
                startPoint1 = New Point(Trow("x1"), Trow("y1"))
                endPoint1 = New Point(Trow("x2"), Trow("y2"))
                startPoint2 = New Point(Trow("x3"), Trow("y3"))
                endPoint2 = New Point(Trow("x4"), Trow("y4"))

                If Trow("JenisBagian").ToString = "Pagar" Then
                    fontOdontogram = New Font("Arial", 28, FontStyle.Regular)
                    ShapeDrawingFunctions.DrawText(updatedImage, Trow("x1"), Trow("y1"), "#", fontOdontogram, Color.Black)
                ElseIf Trow("JenisBagian").ToString = "V Bawah" Then
                    fontOdontogram = New Font("Arial", 16, FontStyle.Regular)
                    ShapeDrawingFunctions.DrawText(updatedImage, Trow("x1"), Trow("y1"), "V", fontOdontogram, Color.Black)
                ElseIf Trow("JenisBagian").ToString = "V Tengah" Then
                    ShapeDrawingFunctions.DrawLines(updatedImage, startPoint1, endPoint1, startPoint2, endPoint2, Color.Black, 3)
                ElseIf Trow("JenisBagian").ToString = "X Tengah" Then
                    ShapeDrawingFunctions.DrawLines(updatedImage, startPoint1, endPoint1, startPoint2, endPoint2, Color.Black, 3)
                ElseIf Trow("JenisBagian").ToString = "Segitiga Bawah" Then
                    ShapeDrawingFunctions.DrawTriangle(updatedImage, Trow("x1"), Trow("y1"), Trow("x2"), Trow("y2"), Trow("x3"), Trow("y3"), Color.Black, Color.Black)
                ElseIf Trow("JenisBagian").ToString = "Sisi Persegi" Then
                    ShapeDrawingFunctions.DrawColoredRectangle(updatedImage, Trow("x1"), Trow("y1"), Trow("x2"), Trow("y2"), 4)
                ElseIf Trow("JenisBagian").ToString = "Persegi Arsir Vertikal" Then
                    ShapeDrawingFunctions.DrawColoredRectangleWithVerticalHatch(updatedImage, Trow("x1"), Trow("y1"), Trow("x2"), Trow("y2"), Color.Black)
                ElseIf Trow("JenisBagian").ToString = "Garis Lurus Atas" Then
                    ShapeDrawingFunctions.DrawLines(updatedImage, startPoint1, endPoint1, startPoint2, endPoint2, Color.Black, 3)
                End If
            End If

            ' Menampilkan gambar yang telah diperbarui
            PictureBox1.Image = updatedImage
        Next
    End Sub

    Private Sub ButtonCancelTransaksiOdontogram_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancelTransaksiOdontogram.Click
        Select Case MsgBox("Apakah anda yakin ingin membatalkan?", MsgBoxStyle.YesNo Or MsgBoxStyle.Question, "Question.")
            Case MsgBoxResult.Yes
                ' Clear gambar odontogram
                PictureBoxOdontogramObjektif.Image = My.Resources.OdontogramFromWeb

                ' Load data awal
                LoadOdontogram()

                ' Set clear data temporary odontogram
                tblsTransaksiOdontogram.Rows.Clear()

                ' Clear data
                ClearDetailOdontogram()

                MsgBox("Tindakan berhasil dibatalkan.", MsgBoxStyle.Exclamation, "Cancel!")
        End Select
    End Sub

    Private Sub ButtonFindRiwayatGigi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFindRiwayatGigi.Click
        If ComboBoxRiwayatElemenGigi.SelectedIndex <> -1 Then
            GetRiwayatGigi()
        Else
            MsgBox("Pilih gigi terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
        End If
    End Sub

    Private Sub GetRiwayatGigi()
        DataGridViewRiwayatGigi.Rows.Clear()
        DataGridViewRiwayatGigi.Columns.Clear()

        Dim Takhir As Date = TglAkhirRiwayatGigi.Value
        Dim Tawal As Date = TglAwalRiwayatGigi.Value
        Dim queryString As String = ""
        Dim queryOrderString As String = ""
        Dim queryElemenGigiString As String = ""

        If ComboBoxRiwayatElemenGigi.Text = "SEMUA GIGI" Then
            queryElemenGigiString = ""
        Else
            queryElemenGigiString = " AND MasterOdontogram.NamaGigi = '" & ComboBoxRiwayatElemenGigi.Text & "'"
        End If

        queryString = "SELECT MasterOdontogram.NamaGigi, MasterOdontogram.KeteranganGigi, TransaksiGigiOdontogramHeader.Tindakan, TransaksiGigiOdontogramHeader.GenerateHasil, TransaksiGigiOdontogramHeader.Mesial, TransaksiGigiOdontogramHeader.Occusal, TransaksiGigiOdontogramHeader.Vestibular, TransaksiGigiOdontogramHeader.Lingual, TransaksiGigiOdontogramHeader.Distal, TransaksiGigiOdontogramHeader.Keterangan, CONVERT(date, TransaksiGigiOdontogramHeader.CreatedDate) AS 'CreatedDate', TransaksiGigiOdontogramHeader.CreatedBy " & _
                      "FROM TransaksiGigiOdontogramHeader " & _
                      "LEFT JOIN TransaksiDetail ON TransaksiGigiOdontogramHeader.NoTransaksi=TransaksiDetail.NoUrut " & _
                      "LEFT JOIN MasterOdontogram ON TransaksiGigiOdontogramHeader.NomorGigi=MasterOdontogram.NomorGigi AND MasterOdontogram.NamaBagian LIKE '%FULL%' " & _
                      "WHERE TransaksiDetail.IDInternet = '" & idPasien & "' AND CONVERT(date, TransaksiDetail.TanggalTransaksi) BETWEEN '" & Tawal & "' AND '" & Takhir & "'" & queryElemenGigiString
        queryOrderString = " ORDER BY TransaksiGigiOdontogramHeader.CreatedDate DESC"

        Dim Tbls As DataTable = ReadSQL(queryString & queryOrderString)
        If Tbls.Rows.Count > 0 Then
            CreateDataGridViewRiwayatGigi()

            For Each Trow As DataRow In Tbls.Rows
                Dim dataItemsPosisi As New List(Of String)()
                If Trow("Mesial") = True Then dataItemsPosisi.Add("Mesial")
                If Trow("Occusal") = True Then dataItemsPosisi.Add("Occusal")
                If Trow("Vestibular") = True Then dataItemsPosisi.Add("Vestibular")
                If Trow("Lingual") = True Then dataItemsPosisi.Add("Lingual")
                If Trow("Distal") = True Then dataItemsPosisi.Add("Distal")

                Dim stringPosisi As String = String.Join(", ", dataItemsPosisi.ToArray())

                DataGridViewRiwayatGigi.Rows.Add(New String() {"" & Trow("NamaGigi") & "", "" & Trow("Tindakan") & "", "" & stringPosisi & "", "" & Trow("GenerateHasil") & "", "" & Trow("Keterangan") & "", "" & Format(Trow("CreatedDate"), "yyyy-MM-dd") & "", "" & Trow("CreatedBy") & ""})
            Next

            DataGridViewRiwayatGigi.CurrentCell = Nothing
            DataGridViewRiwayatGigi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        Else
            MsgBox("Data tidak ditemukan.", MsgBoxStyle.Exclamation, "Warning!")
        End If
    End Sub

    Private Sub CreateDataGridViewRiwayatGigi()
        ' Add columns
        DataGridViewRiwayatGigi.Columns.Add("ColumnElemenGigi", "Elemen Gigi")
        DataGridViewRiwayatGigi.Columns.Add("ColumnTindakan", "Tindakan")
        DataGridViewRiwayatGigi.Columns.Add("ColumnPosisi", "Posisi")
        DataGridViewRiwayatGigi.Columns.Add("ColumnKeterangan", "Kode Gigi")
        DataGridViewRiwayatGigi.Columns.Add("ColumnKeterangan", "Keterangan")
        DataGridViewRiwayatGigi.Columns.Add("ColumnCreatedDate", "CreatedDate")
        DataGridViewRiwayatGigi.Columns.Add("ColumnCreatedBy", "CreatedBy")
    End Sub

    Private Sub CetakDetail(ByRef noUrut As String)
        Dim tblsHasil As New DataTable
        Dim Tquery As String = ""

        If noUrut.Contains("U") = True Then
            Tquery = "SELECT TransaksiPoli.TransPoliID, TransaksiPoli.DokterPoli AS 'NamaDokter', TransaksiPoli.PerawatPoli AS 'NamaPerawat', TransaksiPoli.KodeDokter, TransaksiPoli.TglPoli AS 'TglTransaksi', TransaksiPoli.Status, TransaksiDetail.*, MasterPasien.* " & _
                     "FROM TransaksiPoli " & _
                     "LEFT JOIN TransaksiDetail ON TransaksiDetail.NoUrut = TransaksiPoli.NoUrut " & _
                     "LEFT JOIN MasterPasien ON MasterPasien.NoRekamMedis = TransaksiPoli.IDInternet " & _
                     "WHERE TransaksiPoli.NoUrut = '" & noUrut & "'"
        ElseIf noUrut.Contains("G") = True Then
            Tquery = "SELECT TransaksiGigi.TransGigiID, TransaksiGigi.DokterGigi AS 'NamaDokter', TransaksiGigi.PerawatGigi AS 'NamaPerawat', TransaksiGigi.KodeDokter, TransaksiGigi.TglGigi AS 'TglTransaksi', TransaksiGigi.Status, TransaksiDetail.*, MasterPasien.* " & _
                     "FROM TransaksiGigi " & _
                     "LEFT JOIN TransaksiDetail ON TransaksiDetail.NoUrut = TransaksiGigi.NoUrut " & _
                     "LEFT JOIN MasterPasien ON MasterPasien.NoRekamMedis = TransaksiGigi.IDInternet " & _
                     "WHERE TransaksiGigi.NoUrut = '" & noUrut & "'"
        End If

        Dim tblsRiwayatRekamMedis As DataTable = ReadSQL(Tquery)
        Dim trowPasien As DataRow = tblsRiwayatRekamMedis.Rows(0)

        Dim ketTindakan As String = ""

        If noUrut.Contains("U") Then
            ' Poli Umum
            Dim transPoliID As String = trowPasien("TransPoliID").ToString()
            Dim sqlTindakan As String = "SELECT NamaTindakan FROM TransaksiPoliDetail " & _
                                        "WHERE StatusPembayaran = 'PAID' " & _
                                        "AND DeletedDate IS NULL " & _
                                        "AND TransPoliID = '" & transPoliID & "' " & _
                                        "AND JenisTindakan NOT LIKE '%Konsul%'"
            Dim tblTindakanPoli As DataTable = ReadSQL(sqlTindakan)

            If tblTindakanPoli.Rows.Count > 0 Then
                ketTindakan = "Tindakan:" & vbCrLf
                Dim i As Integer
                For i = 0 To tblTindakanPoli.Rows.Count - 1
                    ketTindakan &= "- " & tblTindakanPoli.Rows(i)("NamaTindakan").ToString() & vbCrLf
                Next
            End If

        ElseIf noUrut.Contains("G") Then
            ' Poli Gigi
            Dim transGigiID As String = trowPasien("TransGigiID").ToString()
            Dim sqlTindakan As String = "SELECT NamaTindakan FROM TransaksiGigiDetail " & _
                                        "WHERE StatusPembayaran = 'PAID' " & _
                                        "AND DeletedDate IS NULL " & _
                                        "AND TransGigiID = '" & transGigiID & "' " & _
                                        "AND JenisTindakan NOT LIKE '%Konsul%'"
            Dim tblTindakanGigi As DataTable = ReadSQL(sqlTindakan)

            If tblTindakanGigi.Rows.Count > 0 Then
                ketTindakan = "Tindakan:" & vbCrLf
                Dim i As Integer
                For i = 0 To tblTindakanGigi.Rows.Count - 1
                    ketTindakan &= "- " & tblTindakanGigi.Rows(i)("NamaTindakan").ToString() & vbCrLf
                Next
            End If
        End If

                ' Create Report
        Report = New XtraReport
        Report = XtraReport.FromFile(Application.StartupPath + "\Reports\Klinik\RekamMedis\ReportDetailKunjungan.repx", True)

                ' Set field tabel hasil
        insertRowToTbls(tblsHasil, "typstring", "Nama")
        insertRowToTbls(tblsHasil, "typstring", "NoRekamMedis")
        insertRowToTbls(tblsHasil, "typstring", "TTL")
        insertRowToTbls(tblsHasil, "typstring", "Nama Poli")
        insertRowToTbls(tblsHasil, "typstring", "Tanggal Transaksi")
        insertRowToTbls(tblsHasil, "typstring", "Waktu Transaksi")
        insertRowToTbls(tblsHasil, "typstring", "Keluhan Utama")
        insertRowToTbls(tblsHasil, "typstring", "Keluhan Tambahan")
        insertRowToTbls(tblsHasil, "typstring", "Riwayat Kebiasaan")
        insertRowToTbls(tblsHasil, "typstring", "Riwayat Penyakit Sekarang")
        insertRowToTbls(tblsHasil, "typstring", "Riwayat Penggunaan Obat")
        insertRowToTbls(tblsHasil, "typstring", "Riwayat Alergi")
        insertRowToTbls(tblsHasil, "typstring", "Riwayat Penyakit")
        insertRowToTbls(tblsHasil, "typstring", "Riwayat Penyakit Keluarga")
        insertRowToTbls(tblsHasil, "typstring", "Keadaan umum")
        insertRowToTbls(tblsHasil, "typstring", "Kesadaran")
        insertRowToTbls(tblsHasil, "typstring", "Tanda Vital")
        insertRowToTbls(tblsHasil, "typstring", "Antropometri")
        insertRowToTbls(tblsHasil, "typstring", "Status Generalis")
        insertRowToTbls(tblsHasil, "typstring", "Diagnosa")
        insertRowToTbls(tblsHasil, "typstring", "Rencana Tindakan / Pengobatan")
        insertRowToTbls(tblsHasil, "typstring", "RS Rujukan")
        insertRowToTbls(tblsHasil, "typstring", "Edukasi")
        insertRowToTbls(tblsHasil, "typstring", "TanggalKontrol")

                ' Set Alergi
        Dim alergiList As New List(Of String)
        Dim ketAlergi As String = ""

        Dim daftarAlergiMakanan As String = GetListAlergi("Makanan", idPasien)
        Dim daftarAlergiObat As String = GetListAlergi("Obat", idPasien)
        Dim daftarAlergiUdara As String = GetListAlergi("Udara", idPasien)

        If daftarAlergiMakanan.Count > 0 Then alergiList.Add("Alergi Makanan : " & daftarAlergiMakanan.ToString())
        If daftarAlergiObat.Count > 0 Then alergiList.Add("Alergi Obat : " & daftarAlergiObat.ToString())
        If daftarAlergiUdara.Count > 0 Then alergiList.Add("Alergi Udara : " & daftarAlergiUdara.ToString())

        If alergiList.Count > 0 Then ketAlergi = String.Join(vbCrLf, alergiList.ToArray())

                ' Set Pemeriksaan Fisik
        Dim ketTandaVital As String = ""
        Dim ketAntropometri As String = ""
        Dim ketKeadaanUmum As String = ""
        Dim ketKesadaran As String = ""

        Dim tblsFisik As DataTable = ReadSQL("SELECT * FROM TransaksiDetailFisik WHERE NoTransaksi = '" & noUrut & "'")

        If tblsFisik.Rows.Count > 0 Then
            Dim rowFisik As DataRow = tblsFisik.Rows(0)

            If rowFisik("Sistole").ToString <> "" And rowFisik("Diastole").ToString <> "" Then ketTandaVital = "TD: " & rowFisik("Sistole").ToString & "/" & rowFisik("Diastole").ToString & " mmHg"
            If rowFisik("HeartRate").ToString <> "" Then ketTandaVital = ketTandaVital & ", Nadi: " & rowFisik("HeartRate").ToString & " x/menit"
            If rowFisik("RespiratoryRate").ToString <> "" Then ketTandaVital = ketTandaVital & ", Napas: " & rowFisik("RespiratoryRate").ToString & " x/menit"
            If rowFisik("Suhu").ToString <> "" Then ketTandaVital = ketTandaVital & ", Suhu: " & rowFisik("Suhu").ToString & " ℃"

            If rowFisik("Berat").ToString <> "" Then ketAntropometri = "BB: " & rowFisik("Berat").ToString & " kg"
            If rowFisik("Tinggi").ToString <> "" Then ketAntropometri = ketAntropometri & ", TB: " & rowFisik("Tinggi").ToString & " cm"
            If rowFisik("IMT").ToString <> "" Then ketAntropometri = ketAntropometri & ", BMI: " & rowFisik("IMT").ToString & " kg/m2"

            If rowFisik("KeadaanUmum").ToString <> "" Then ketKeadaanUmum = rowFisik("KeadaanUmum").ToString
            If rowFisik("Kesadaran").ToString <> "" Then ketKesadaran = rowFisik("Kesadaran").ToString
                End If

                ' Set Status Generalis
        Dim ketStatusGeneralis As String = ""
        Dim tblsGeneralis As DataTable = ReadSQL("SELECT * FROM TransaksiDetailGeneralis WHERE NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL")

        If tblsGeneralis.Rows.Count > 0 Then
            Dim rowGeneralis As DataRow = tblsGeneralis.Rows(0)

            If rowGeneralis("StatusGeneralisKepala").ToString <> "" Then ketStatusGeneralis = "Kepala: " & vbCrLf & rowGeneralis("StatusGeneralisKepala").ToString
            If rowGeneralis("StatusGeneralisMata").ToString <> "" Then ketStatusGeneralis = ketStatusGeneralis & vbCrLf & vbCrLf & "Mata: " & vbCrLf & rowGeneralis("StatusGeneralisMata").ToString
            If rowGeneralis("StatusGeneralisHidung").ToString <> "" Then ketStatusGeneralis = ketStatusGeneralis & vbCrLf & vbCrLf & "Hidung: " & vbCrLf & rowGeneralis("StatusGeneralisHidung").ToString
            If rowGeneralis("StatusGeneralisMulutFaring").ToString <> "" Then ketStatusGeneralis = ketStatusGeneralis & vbCrLf & vbCrLf & "Mulut dan Faring: " & vbCrLf & rowGeneralis("StatusGeneralisMulutFaring").ToString
            If rowGeneralis("StatusGeneralisTelinga").ToString <> "" Then ketStatusGeneralis = ketStatusGeneralis & vbCrLf & vbCrLf & "Telinga: " & vbCrLf & rowGeneralis("StatusGeneralisTelinga").ToString
            If rowGeneralis("StatusGeneralisLeher").ToString <> "" Then ketStatusGeneralis = ketStatusGeneralis & vbCrLf & vbCrLf & "Leher: " & vbCrLf & rowGeneralis("StatusGeneralisLeher").ToString
            If rowGeneralis("StatusGeneralisThorax").ToString <> "" Then ketStatusGeneralis = ketStatusGeneralis & vbCrLf & vbCrLf & "Thorax: " & vbCrLf & rowGeneralis("StatusGeneralisThorax").ToString
            If rowGeneralis("StatusGeneralisAbdomen").ToString <> "" Then ketStatusGeneralis = ketStatusGeneralis & vbCrLf & vbCrLf & "Abdomen: " & vbCrLf & rowGeneralis("StatusGeneralisAbdomen").ToString
            If rowGeneralis("StatusGeneralisEkstremitas").ToString <> "" Then ketStatusGeneralis = ketStatusGeneralis & vbCrLf & vbCrLf & "Ekstremitas: " & vbCrLf & rowGeneralis("StatusGeneralisEkstremitas").ToString
            If rowGeneralis("StatusGeneralisStatusLokalis").ToString <> "" Then ketStatusGeneralis = ketStatusGeneralis & vbCrLf & vbCrLf & "Status Lokalis: " & vbCrLf & rowGeneralis("StatusGeneralisStatusLokalis").ToString
                End If

                ' Rencana Tindakan & Pengobatan
        Dim ketObatTindakan As String = ""
        Dim resep As String = trowPasien("Resep").ToString()

        If resep <> "" And ketTindakan <> "" Then
            ketObatTindakan = "Pengobatan:" & vbCrLf & resep & vbCrLf & ketTindakan
        ElseIf ketTindakan <> "" Then
            ketObatTindakan = ketTindakan
        ElseIf resep <> "" Then
            ketObatTindakan = "Pengobatan:" & vbCrLf & resep
        End If

        'Catatan Obat
        Dim ketCatatanObat As String = ""
        Dim tblsCatatanObat As DataTable = ReadSQL("SELECT Catatan FROM TransaksiDetailCatatanObat WHERE NoTransaksi = '" & noUrut & "' AND DeletedDate IS NULL")
        If tblsCatatanObat.Rows.Count > 0 Then
            ketCatatanObat = "Catatan Obat: " & vbCrLf & tblsCatatanObat.Rows(0)("Catatan").ToString()
        End If

        'Set Cek Stik
        Dim ketCekStik As String = ""
        Dim tblsCekStik As DataTable = ReadSQL("SELECT * FROM HasilCekStik WHERE NoTransaksi = '" & noUrut & "' AND Deleted IS NULL")

        If tblsCekStik.Rows.Count > 0 Then
            ketCekStik = "Hasil Cek Stik:" & vbCrLf
            For Each row As DataRow In tblsCekStik.Rows
                ketCekStik &= "- " & row("Kondisi").ToString() & ": " & row("Hasil").ToString() & " " & row("Satuan").ToString() & " (" & row("Keterangan").ToString & ")" & vbCrLf
            Next
        End If

        ' Set Diagnosa
        Dim tblsDiagnosa As DataTable = ReadSQL("SELECT * FROM TransaksiDetailDiagnosa WHERE NoTransaksi = '" & noUrut & "' AND DeletedDate IS NULL")
        Dim ketDiagnosa As String = ""

        If tblsDiagnosa.Rows.Count > 0 Then
            For Each trowDiagnosa As DataRow In tblsDiagnosa.Rows
                If trowDiagnosa("JenisDiagnosa") = "Diagnosa Utama" Then
                    ketDiagnosa = trowDiagnosa("KeteranganDiagnosa").ToString & " (" & trowDiagnosa("KodeDiagnosa").ToString & ")"
                ElseIf trowDiagnosa("JenisDiagnosa") = "Diagnosa Sekunder" Then
                    ketDiagnosa = ketDiagnosa & vbCrLf & trowDiagnosa("KeteranganDiagnosa").ToString & " (" & trowDiagnosa("KodeDiagnosa").ToString & ")"
                ElseIf trowDiagnosa("JenisDiagnosa") = "Diagnosa Komplikasi" Then
                    ketDiagnosa = ketDiagnosa & vbCrLf & trowDiagnosa("KeteranganDiagnosa").ToString & " (" & trowDiagnosa("KodeDiagnosa").ToString & ")"
                End If
            Next
        End If

        Dim Tnew As DataRow = tblsHasil.NewRow
        ' DATA PASIEN
        Tnew("Nama") = trowPasien("Nama") & " (" & trowPasien("JenisKelamin") & ")"
        Tnew("NoRekamMedis") = trowPasien("NoRekamMedis")
        Tnew("TTL") = trowPasien("TempatLahir") & ", " & Format(trowPasien("TglLahir"), "dd") & " " & BulanIndonesia(Format(trowPasien("TglLahir"), "MM")) & " " & Format(trowPasien("TglLahir"), "yyyy")
        Tnew("Nama Poli") = "Unit pelayanan : " & trowPasien("JenisPoli")
        Tnew("Tanggal Transaksi") = "Tanggal : " & Format(trowPasien("TanggalTransaksi"), "yyyy-MM-dd")
        Tnew("Waktu Transaksi") = "Pukul : " & Format(trowPasien("TanggalTransaksi"), "HH:mm:ss")

        ' SUBJECTIVE
        Tnew("Keluhan Utama") = trowPasien("KeluhanUtama")
        Tnew("Keluhan Tambahan") = trowPasien("KeluhanTambahan")
        Tnew("Riwayat Penyakit Sekarang") = trowPasien("RiwayatPenyakitSekarang")
        Tnew("Riwayat Penggunaan Obat") = trowPasien("RiwayatPenggunaanObat")
        Tnew("Riwayat Kebiasaan") = trowPasien("RiwayatKebiasaan")
        Tnew("Riwayat Alergi") = ketAlergi
        Tnew("Riwayat Penyakit") = trowPasien("RiwayatPenyakitDahulu")
        Tnew("Riwayat Penyakit Keluarga") = trowPasien("RiwayatPenyakitKeluarga")

        ' OBJECTIVE
        Tnew("Keadaan umum") = ketKeadaanUmum
        Tnew("Kesadaran") = ketKesadaran
        Tnew("Tanda Vital") = ketTandaVital
        Tnew("Antropometri") = ketAntropometri
        Tnew("Status Generalis") = ketStatusGeneralis

        'Kontrol Kembali
        Dim tblsKontrol As DataTable = ReadSQL("SELECT * FROM SuratKeteranganKontrol WHERE NoTransaksi = '" & noUrut & "'")
        Dim ketKontrol As String = ""

        If tblsKontrol.Rows.Count > 0 Then
            Dim tanggalKontrol As Date = CDate(tblsKontrol.Rows(0)("Tanggal"))
            Dim culture As New CultureInfo("id-ID")
            ketKontrol = tanggalKontrol.ToString("dd MMMM yyyy", culture)
        End If
        Tnew("TanggalKontrol") = ketKontrol

        ' ASSESMENT
        Tnew("Diagnosa") = ketDiagnosa

        ' PLANNING
        Tnew("Rencana Tindakan / Pengobatan") = ketObatTindakan
        If ketCatatanObat <> "" Then
            Tnew("Rencana Tindakan / Pengobatan") &= vbCrLf & ketCatatanObat
        End If
        If ketCekStik <> "" Then
            Tnew("Rencana Tindakan / Pengobatan") &= vbCrLf & vbCrLf & ketCekStik
        End If
        Tnew("RS Rujukan") = trowPasien("Rujukan")
        Tnew("Edukasi") = trowPasien("Edukasi")

        ' FOOTER
        Dim namaKota As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'Kota'")
        Dim tglKunjungan As String = Format(trowPasien("TanggalTransaksi"), "dd") & " " & BulanIndonesia(Format(trowPasien("TanggalTransaksi"), "MM")) & " " & Format(trowPasien("TanggalTransaksi"), "yyyy")
        Dim nomorSIP As String = ReadSQLNIK("SELECT NoSIP FROM MasterDokter WHERE ID = '" & trowPasien("KodeDokter") & "'")

        tblsHasil.Rows.Add(Tnew)

        Report.DataSource = tblsHasil
        Report.Bands.Item(BandKind.ReportFooter).Controls("xrLabelTanggalPeriksa").Text = namaKota & ", " & tglKunjungan
        Report.Bands.Item(BandKind.ReportFooter).Controls("xrLabelNamaDokter").Text = trowPasien("NamaDokter").ToString
        Report.Bands.Item(BandKind.ReportFooter).Controls("xrLabelNomorSIP").Text = "SIP " & nomorSIP

        'Report.RunDesigner()
        Report.ShowPreview()
    End Sub

    Private Sub TextBoxSistoleMedik_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxSistoleMedik.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub TextBoxDiastoleMedik_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxDiastoleMedik.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub TextBoxDetakNadiMedik_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxDetakNadiMedik.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub TextBoxNafasMedik_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxNafasMedik.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub TextBoxSuhuMedik_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxSuhuMedik.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = vbBack Or e.KeyChar = ".") Then e.Handled = True

        ' Hanya satu tanda titik desimal yang diizinkan
        If e.KeyChar = "." AndAlso (TryCast(sender, TextBox)).Text.Contains(".") Then e.Handled = True
    End Sub

    Private Sub TextBoxSaturasiMedik_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxSaturasiMedik.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub TextBoxTinggiBadanMedik_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxTinggiBadanMedik.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = vbBack Or e.KeyChar = ".") Then e.Handled = True

        ' Hanya satu tanda titik desimal yang diizinkan
        If e.KeyChar = "." AndAlso (TryCast(sender, TextBox)).Text.Contains(".") Then e.Handled = True
    End Sub

    Private Sub TextBoxBeratBadanMedik_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxBeratBadanMedik.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = vbBack Or e.KeyChar = ".") Then e.Handled = True

        ' Hanya satu tanda titik desimal yang diizinkan
        If e.KeyChar = "." AndAlso (TryCast(sender, TextBox)).Text.Contains(".") Then e.Handled = True
    End Sub

    Private Sub TextBoxLingkarPerutMedik_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxLingkarPerutMedik.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = vbBack Or e.KeyChar = ".") Then e.Handled = True

        ' Hanya satu tanda titik desimal yang diizinkan
        If e.KeyChar = "." AndAlso (TryCast(sender, TextBox)).Text.Contains(".") Then e.Handled = True
    End Sub

    ' Event saat item dalam MenuStrip diklik
    Private Sub ToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles PemeriksaanAwalToolStripMenuItem.Click, MedisToolStripMenuItem.Click, PenandaanGambarToolStripMenuItem.Click
        PemeriksaanAwalToolStripMenuItem.BackColor = Color.FromArgb(81, 168, 255)
        MedisToolStripMenuItem.BackColor = Color.FromArgb(81, 168, 255)
        PenandaanGambarToolStripMenuItem.BackColor = Color.FromArgb(81, 168, 255)

        ' Set warna latar belakang dan warna teks saat item diklik
        Dim menuItem As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)
        menuItem.BackColor = Color.FromArgb(85, 99, 114)

        '# Ganti Tab Page
        Select Case menuItem.Name
            Case "PemeriksaanAwalToolStripMenuItem"
                TabControlMenu1.SelectedTab = TabPemeriksaanAwal
            Case "MedisToolStripMenuItem"
                TabControlMenu1.SelectedTab = TabMedis
            Case "PenandaanGambarToolStripMenuItem"
                TabControlMenu1.SelectedTab = TabPenandaanGambar
        End Select
    End Sub

    Private Sub ButtonTambahRujukanBPJS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FindFaskesRujukan.SetRujukan("FaskesRujukanKondisiKhusus", noBPJS, ComboBoxStatusPulang.Text)
        FindFaskesRujukan.ShowDialog()
    End Sub

    Private Sub DataGridViewDiagnosa_CellPainting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles DataGridViewDiagnosa.CellPainting
        ' Pastikan kita hanya menggambar tombol untuk kolom button (Aksi)
        If e.ColumnIndex = DataGridViewDiagnosa.Columns("ButtonDetail").Index AndAlso e.RowIndex >= 0 Then
            ' Gambar tombol
            e.Paint(e.CellBounds, DataGridViewPaintParts.All)

            ' Set teks pada tombol
            Dim cellButton As DataGridViewButtonCell = CType(DataGridViewDiagnosa.Rows(e.RowIndex).Cells("ButtonDetail"), DataGridViewButtonCell)
            cellButton.Value = "Hapus" ' Ganti teks sesuai kebutuhan

            ' Atur alignment teks pada tombol (misalnya, ke tengah)
            cellButton.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            ' Sinyal bahwa kita sudah menangani penggambaran tombol
            e.Handled = True
        End If
    End Sub

    Private Sub SendToApiDeleteDiagnosa(ByVal idTransaksi As String, ByVal jenisDiagnosa As String)
        Try
            Dim json As String = "{" & _
                 """NoTransaksi"":""" & idTransaksi & """," & _
                 """JenisDiagnosa"":""" & jenisDiagnosa & """}"

            Dim baseUrl As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
            Dim urlWebService As String = baseUrl & "api/diagnosa/delete"
            Dim response As String = InsertDataAPIRM(json, urlWebService)

            ' --- Parse JSON response ---
            Dim result As JObject = JObject.Parse(response)

            Dim status As String = result("status").ToString()
            Dim message As String = result("message").ToString()

            Dim insertedId As String = ""
            Dim data As JObject = TryCast(result("data"), JObject)
            If data IsNot Nothing AndAlso data("id") IsNot Nothing Then
                insertedId = data("id").ToString()
            End If

            ' --- Tampilkan hasil ---
            If status = "success" Then
                MsgBox("Data berhasil dihapus di API ERM." & vbCrLf & _
                       "Pesan: " & message & vbCrLf & _
                       "Dengan ID: " & insertedId)
            Else
                MsgBox("API ERM mengembalikan status gagal: " & status & vbCrLf & message)
            End If
        Catch ex As Exception
            MsgBox("Gagal kirim hapus diagnosa ke API: " & ex.Message)
        End Try
    End Sub

    Private Sub DataGridViewDiagnosa_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewDiagnosa.CellClick
        If e.RowIndex >= 0 Then
            If DataGridViewDiagnosa.Columns.Contains("ButtonDetail") Then
                If e.ColumnIndex = DataGridViewDiagnosa.Columns("ButtonDetail").Index Then
                    Dim namaDiagnosa As String = DataGridViewDiagnosa.Rows(e.RowIndex).Cells("ColumnKeteranganDiagnosa").Value.ToString()
                    Dim jenisDiagnosa As String = DataGridViewDiagnosa.Rows(e.RowIndex).Cells("ColumnJenis").Value.ToString()
                    Dim result As DialogResult = MessageBox.Show("Apakah Anda yakin ingin menghapus diagnosa " & namaDiagnosa & "?", "Validasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                    Dim statusAPI As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'status_ws_RM' ")

                    If result = DialogResult.Yes Then
                        If CheckingDeleteDiagnosa(jenisDiagnosa) = True Then
                            ' Delete Diagnosa
                            WriteSQL("UPDATE TransaksiDetailDiagnosa SET DeletedBy = '" & userInput & "', DeletedDate = GETDATE() WHERE NoTransaksi = '" & idTransaksi & "' AND JenisDiagnosa = '" & jenisDiagnosa & "'", 4)

                            If statusAPI IsNot Nothing AndAlso statusAPI = "Yes" Then
                                SendToApiDeleteDiagnosa(idTransaksi, jenisDiagnosa)
                            End If

                            If statusBPJS = True AndAlso CheckBridgingPcareActive() = True Then SaveKunjunganBPJS() ' Save PCare BPJS

                            LoadGridRiwayatDiagnosa()
                            SaveDetailDiagnosa()

                            MsgBox("Diagnosa : " & namaDiagnosa & " berhasil dihapus.", MsgBoxStyle.Information, "Success!")
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub DataGridViewPemeriksaanPenunjang_CellPainting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles DataGridViewPemeriksaanPenunjang.CellPainting
        ' Pastikan kita hanya menggambar tombol untuk kolom button (Aksi)
        If e.ColumnIndex = DataGridViewPemeriksaanPenunjang.Columns("ButtonDetail").Index AndAlso e.RowIndex >= 0 Then
            ' Gambar tombol
            e.Paint(e.CellBounds, DataGridViewPaintParts.All)

            ' Set teks pada tombol
            Dim cellButton As DataGridViewButtonCell = CType(DataGridViewPemeriksaanPenunjang.Rows(e.RowIndex).Cells("ButtonDetail"), DataGridViewButtonCell)
            cellButton.Value = "Hapus" ' Ganti teks sesuai kebutuhan

            ' Atur alignment teks pada tombol (misalnya, ke tengah)
            cellButton.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            ' Sinyal bahwa kita sudah menangani penggambaran tombol
            e.Handled = True
        End If
    End Sub

    Private Sub DataGridViewPemeriksaanPenunjang_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewPemeriksaanPenunjang.CellClick
        If e.RowIndex >= 0 Then
            If DataGridViewPemeriksaanPenunjang.Columns.Contains("ButtonDetail") Then
                If e.ColumnIndex = DataGridViewPemeriksaanPenunjang.Columns("ButtonDetail").Index Then
                    Dim namaTindakan As String = DataGridViewPemeriksaanPenunjang.Rows(e.RowIndex).Cells("ColumnNamaTindakan").Value.ToString()
                    Dim tindakanID As String = DataGridViewPemeriksaanPenunjang.Rows(e.RowIndex).Cells("ColumnID").Value.ToString()
                    Dim result As DialogResult = MessageBox.Show("Apakah Anda yakin ingin menghapus tindakan " & namaTindakan & "?", "Validasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                    If result = DialogResult.Yes Then
                        If CheckSQL("SELECT * FROM TransaksiLabDetail WHERE StatusPembayaran = 'PAID' AND NoTransaksiPoli = '" & idTransaksi & "'") = False Then
                            ' Delete Diagnosa
                            WriteSQL("DELETE FROM TransaksiLabDetail WHERE NoTransaksiPoli = '" & idTransaksi & "' AND TindakanID = '" & tindakanID & "'", 4)

                            LoadGridRiwayatPemeriksaanPenunjang()
                            SaveDetailPemeriksaanPenunjang()

                            MsgBox("Tindakan : " & namaTindakan & " berhasil dihapus.", MsgBoxStyle.Information, "Success!")
                        Else
                            LoadGridRiwayatPemeriksaanPenunjang()

                            MsgBox("Gagal. " & namaTindakan & " sudah di transaksi.", MsgBoxStyle.Exclamation, "Warning!")
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Function CheckingDeleteDiagnosa(ByRef _jenisDiagnosa As String) As Boolean
        Dim tblsDiagnosa As DataTable = ReadSQL("SELECT * FROM TransaksiDetailDiagnosa WHERE NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL")

        If tblsDiagnosa.Rows.Count > 0 Then
            For Each trowDiagnosa As DataRow In tblsDiagnosa.Rows
                If _jenisDiagnosa = "Diagnosa Utama" And (trowDiagnosa("JenisDiagnosa") = "Diagnosa Sekunder" Or trowDiagnosa("JenisDiagnosa") = "Diagnosa Komplikasi") Then
                    MsgBox("Gagal. " & trowDiagnosa("JenisDiagnosa") & " masih terisi.", MsgBoxStyle.Exclamation, "Warning!")
                    Return False
                ElseIf _jenisDiagnosa = "Diagnosa Sekunder" And trowDiagnosa("JenisDiagnosa") = "Diagnosa Komplikasi" Then
                    MsgBox("Gagal. " & trowDiagnosa("JenisDiagnosa") & " masih terisi.", MsgBoxStyle.Exclamation, "Warning!")
                    Return False
                End If
            Next
        End If

        Return True
    End Function

    Private Sub DataGridView_CellPainting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles DataGridViewObat.CellPainting, DataGridViewTindakan.CellPainting
        Dim dataGridView As DataGridView = DirectCast(sender, DataGridView)

        ' Pastikan kita hanya menggambar tombol untuk kolom button (Aksi)
        If e.ColumnIndex = dataGridView.Columns("ButtonDetail").Index AndAlso e.RowIndex >= 0 Then
            ' Gambar tombol
            e.Paint(e.CellBounds, DataGridViewPaintParts.All)

            ' Set teks pada tombol
            Dim cellButton As DataGridViewButtonCell = CType(dataGridView.Rows(e.RowIndex).Cells("ButtonDetail"), DataGridViewButtonCell)
            cellButton.Value = "Hapus" ' Ganti teks sesuai kebutuhan

            ' Atur alignment teks pada tombol (misalnya, ke tengah)
            cellButton.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            ' Sinyal bahwa kita sudah menangani penggambaran tombol
            e.Handled = True
        End If
    End Sub

    Private Sub SendToApiDeleteObat(ByVal idTransaksi As String, ByVal namaObat As String)
        Try
            Dim json As String = "{" & _
                 """NoTransaksi"":""" & idTransaksi & """," & _
                 """NamaObat"":""" & namaObat & """}"

            Dim baseUrl As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
            Dim urlWebService As String = baseUrl & "api/obat/delete"
            Dim response As String = InsertDataAPIRM(json, urlWebService)

            ' --- Parse JSON response ---
            Dim result As JObject = JObject.Parse(response)

            Dim status As String = result("status").ToString()
            Dim message As String = result("message").ToString()

            Dim insertedId As String = ""
            Dim data As JObject = TryCast(result("data"), JObject)
            If data IsNot Nothing AndAlso data("id") IsNot Nothing Then
                insertedId = data("id").ToString()
            End If

            ' --- Tampilkan hasil ---
            If status = "success" Then
                MsgBox("Data berhasil dikirim ke API ERM." & vbCrLf & _
                       "Pesan: " & message & vbCrLf & _
                       "Dengan ID: " & insertedId)
            Else
                MsgBox("API mengembalikan status gagal: " & status & vbCrLf & message)
            End If
        Catch ex As Exception
            MsgBox("Gagal kirim hapus Obat ke API: " & ex.Message)
        End Try
    End Sub

    Private Sub DataGridViewObat_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewObat.CellClick
        If e.RowIndex >= 0 Then
            If DataGridViewObat.Columns.Contains("ButtonDetail") Then
                If e.ColumnIndex = DataGridViewObat.Columns("ButtonDetail").Index Then
                    If ValidasiObat() = True Then
                        Dim noRacikan As String = DataGridViewObat.Rows(e.RowIndex).Cells("ColumnRacikan").Value.ToString()
                        Dim idObat As String = DataGridViewObat.Rows(e.RowIndex).Cells("ColumnObatID").Value.ToString()
                        Dim namaObat As String = DataGridViewObat.Rows(e.RowIndex).Cells("ColumnObatNama").Value.ToString()

                        If noRacikan = "" Then
                            Dim resultNonRacikan As DialogResult = MessageBox.Show("Apakah Anda yakin ingin menghapus obat " & namaObat & "?", "Validasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            If resultNonRacikan = DialogResult.Yes Then
                                ' Delete Header
                                WriteSQL("UPDATE TransaksiObat SET DeletedBy = '" & userInput & "', DeletedDate = GETDATE() WHERE NoTransaksi = '" & idTransaksi & "' AND ObatID = '" & idObat & "' AND DeletedDate IS NULL", 4)

                                SendToApiDeleteObat(idTransaksi, namaObat)

                                ' Delete Detail
                                WriteSQL("DELETE FROM TransaksiObatNonRacikan WHERE NoTransaksi = '" & idTransaksi & "' AND ObatID = '" & idObat & "'", 4)

                                Dim kdObatSK As String = ""
                                Dim noKunjunganBPJS As String = ""

                                Dim dtBpjs As DataTable = ReadSQL( _
                                      "SELECT TOP 1 " & _
                                      "ISNULL(CAST(kdObatSK AS VARCHAR(50)),'') AS kdObatSK, " & _
                                      "ISNULL(noKunjungan,'') AS noKunjungan " & _
                                      "FROM TransaksiObatBPJS " & _
                                      "WHERE NoTransaksi = '" & idTransaksi & "' " & _
                                      "AND kdObat = '" & idObat & "' " & _
                                      "AND DeletedDate IS NULL")

                                If dtBpjs IsNot Nothing AndAlso dtBpjs.Rows.Count > 0 Then
                                    kdObatSK = dtBpjs.Rows(0)("kdObatSK").ToString().Trim()
                                    noKunjunganBPJS = dtBpjs.Rows(0)("noKunjungan").ToString().Trim()
                                End If

                                If kdObatSK <> "" AndAlso kdObatSK <> "0" AndAlso noKunjunganBPJS <> "" Then
                                    Try
                                        ' --- Kirim DELETE ke PCare ---
                                        Dim uriBPJS As String = urlPcare & "obat/" & kdObatSK & "/kunjungan/" & noKunjunganBPJS
                                        Dim jsonResponse As String = PostDataFromPcare("", uriBPJS, "DELETE")

                                        ' TRACE (opsional)
                                        'MsgBox("Kirim DELETE ke: " & uriBPJS)
                                        'MsgBox("Response Hapus: " & jsonResponse)

                                        ' Cek metaData BPJS
                                        Dim jObj As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(jsonResponse)
                                        Dim code As String = jObj("metaData")("code").ToString()
                                        Dim msg As String = jObj("metaData")("message").ToString()

                                        If code = "200" OrElse code = "204" Then
                                            ' Hapus di DB kalau sukses
                                            WriteSQL("UPDATE TransaksiObatBPJS SET DeletedBy = '" & userInput & "', DeletedDate = GETDATE() " & _
                                                     "WHERE NoTransaksi = '" & idTransaksi & "' AND kdObat = '" & idObat & "' AND DeletedDate IS NULL", 4)
                                            MsgBox("Obat " & namaObat & " berhasil dihapus di BPJS PCare dan database lokal.", MsgBoxStyle.Information, "Success!")
                                        Else
                                            MsgBox("Gagal hapus obat di BPJS PCare: " & msg, MsgBoxStyle.Exclamation, "BPJS Error")
                                        End If

                                    Catch ex As Exception
                                        MsgBox("Terjadi error hapus obat di PCare: " & ex.Message, MsgBoxStyle.Critical, "Error")
                                    End Try
                                Else
                                    ' Kalau belum pernah terkirim ke PCare (kdObatSK = 0), cukup hapus lokal
                                    WriteSQL("UPDATE TransaksiObatBPJS SET DeletedBy = '" & userInput & "', DeletedDate = GETDATE() " & _
                                             "WHERE NoTransaksi = '" & idTransaksi & "' AND kdObat = '" & idObat & "' AND DeletedDate IS NULL", 4)
                                    MsgBox("Obat " & namaObat & " berhasil dihapus hanya di database lokal.", MsgBoxStyle.Information, "Success!")
                                End If
                            End If
                        Else
                            Dim resultRacikan As DialogResult = MessageBox.Show("Apakah Anda yakin ingin menghapus racikan " & noRacikan & "?", "Validasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                            If resultRacikan = DialogResult.Yes Then
                                ' Delete Header
                                WriteSQL("UPDATE TransaksiObat SET DeletedBy = '" & userInput & "', DeletedDate = GETDATE() WHERE NoTransaksi = '" & idTransaksi & "' AND KodeRacikan = '" & noRacikan & "' AND DeletedDate IS NULL", 4)

                                ' Delete Detail
                                WriteSQL("DELETE FROM TransaksiObatRacikan WHERE NoTransaksi = '" & idTransaksi & "' AND KodeRacikan = '" & noRacikan & "'", 4)

                                MsgBox("Racikan : " & noRacikan & " berhasil dihapus.", MsgBoxStyle.Information, "Success!")
                            End If
                        End If

                        LoadGridResepObat()
                        SaveDetailResep()

                        ' Kirim P-Care
                        If statusBPJS = True AndAlso CheckBridgingPcareActive() = True Then SaveKunjunganBPJS()
                    End If
                End If
            End If
        End If
    End Sub

    Function ValidasiObat() As Boolean
        ' Validasi Diagnosa
        If ValidasiDiagnosa() = False Then Return False

        ' Validasi Pemeriksaan Fisik
        If ValidasiPemeriksaanFisik() = False Then Return False

        ' Validasi Pembayaran Obat
        If jenisTransaksi = "UMUM" Or jenisTransaksi = "POLI" Then
            If CheckSQL("SELECT * FROM TransaksiPoli WHERE NoUrut = '" & idTransaksi & "' AND ResepStatus = 1") = True Then
                MsgBox("Gagal. Resep sudah dilakukan pembayaran.", MsgBoxStyle.Exclamation, "Warning!")
                Return False
            End If
        ElseIf jenisTransaksi = "GIGI" Then
            If CheckSQL("SELECT * FROM TransaksiGigi WHERE NoUrut = '" & idTransaksi & "' AND ResepStatus = 1") = True Then
                MsgBox("Gagal. Resep sudah dilakukan pembayaran.", MsgBoxStyle.Exclamation, "Warning!")
                Return False
            End If
        End If

        Return True
    End Function

    Function CheckingDeleteTindakan() As Boolean
        If jenisTransaksi = "UMUM" Or jenisTransaksi = "POLI" Then
            If CheckSQL("SELECT * FROM TransaksiPoli WHERE NoUrut = '" & idTransaksi & "' AND ClosedBayar <> '12/31/9998'") = True Then
                MsgBox("Gagal. Transaksi sudah dilakukan pembayaran tindakan.", MsgBoxStyle.Exclamation, "Warning!")
                Return False
            End If
        ElseIf jenisTransaksi = "GIGI" Then
            If CheckSQL("SELECT * FROM TransaksiGigi WHERE NoUrut = '" & idTransaksi & "' AND ClosedBayar <> '12/31/9998'") = True Then
                MsgBox("Gagal. Transaksi sudah dilakukan pembayaran tindakan.", MsgBoxStyle.Exclamation, "Warning!")
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub ButtonCetakSuratKeteranganDokter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCetakSuratKeteranganDokter.Click
        Try
            ' Set No Dokumen
            Dim noDocument As String = ReadSQLNIK("SELECT NomorDokumen FROM MasterDokumen WHERE NamaDokumen = 'Surat Keterangan Dokter'")

            ' Set Path Kop Surat
            Dim pathKopSurat As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'image_path_kop_surat_keterangan'")

            ' Set Alamat & No Telpon
            Dim namaKota As String = ReadSQLNIK("SELECT StrValue FROM  msconfig WHERE configname = 'Kota'")
            Dim alamatCompany As String = ReadSQLNIK("SELECT StrValue FROM  msconfig WHERE configname = 'AlamatCompany'")
            Dim telpCompany As String = ReadSQLNIK("SELECT StrValue FROM  msconfig WHERE configname = 'TelpCompany'")

            ' Set Data Surat Keterangan
            Dim tblSuratKeterangan As DataTable = ReadSQL("SELECT * FROM SuratKeteranganDokter WHERE NoTransaksi = '" & idTransaksi & "'")

            'Nama Dokter
            Dim namaDokter As String = ""
            Dim noSIP As String = ""
            Dim kodeDokter As String = ""

            If jenisTransaksi = "UMUM" Or jenisTransaksi = "POLI" Then
                namaDokter = ReadSQLNIK("SELECT DokterPoli FROM TransaksiPoli WHERE NoUrut = '" & idTransaksi & "'")
                kodeDokter = ReadSQLNIK("SELECT KodeDokter FROM TransaksiPoli WHERE NoUrut = '" & idTransaksi & "'")
                noSIP = ReadSQLNIK("SELECT NoSIP FROM MasterDokter WHERE ID = '" & kodeDokter & "'")
            Else
                namaDokter = ReadSQLNIK("SELECT DokterGigi FROM TransaksiGigi WHERE NoUrut = '" & idTransaksi & "'")
                kodeDokter = ReadSQLNIK("SELECT KodeDokter FROM TransaksiGigi WHERE NoUrut = '" & idTransaksi & "'")
                noSIP = ReadSQLNIK("SELECT NoSIP FROM MasterDokter WHERE ID = '" & kodeDokter & "'")
            End If

            If tblSuratKeterangan.Rows.Count > 0 Then
                Dim rowSurat As DataRow = tblSuratKeterangan.Rows(0)

                Report = New XtraReport
                Report = XtraReport.FromFile(Application.StartupPath + "\Reports\Klinik\SuratKeterangan\SuratKeteranganDokter.repx", True)

                ' Ambil kolom Keterangan (format JSON array)
                Dim isiKeterangan As String = ""
                If Not IsDBNull(rowSurat("Keterangan")) AndAlso rowSurat("Keterangan").ToString() <> "" Then
                    Dim json As String = rowSurat("Keterangan").ToString()
                    json = json.Trim("["c, "]"c)
                    Dim parts() As String = json.Split(New String() {","}, StringSplitOptions.RemoveEmptyEntries)
                    For i As Integer = 0 To parts.Length - 1
                        parts(i) = parts(i).Trim().Trim(""""c)
                    Next
                    isiKeterangan = String.Join(vbCrLf, parts)
                End If

                ' === Cari table → row → cell secara aman ===
                Dim table4 As XRTable = TryCast(Report.Bands(BandKind.Detail).Controls("xrTable4"), XRTable)
                If table4 IsNot Nothing Then
                    Dim row12 As XRTableRow = Nothing
                    For Each r As XRTableRow In table4.Rows
                        If r.Name = "xrTableRow12" Then
                            row12 = r
                            Exit For
                        End If
                    Next

                    If row12 IsNot Nothing Then
                        Dim cellKeterangan As XRTableCell = Nothing
                        For Each c As XRTableCell In row12.Cells
                            If c.Name = "Keterangan" Then
                                cellKeterangan = c
                                Exit For
                            End If
                        Next

                        If cellKeterangan IsNot Nothing Then
                            cellKeterangan.Multiline = True
                            cellKeterangan.CanGrow = True
                            cellKeterangan.Visible = True
                            cellKeterangan.Text = isiKeterangan
                        End If
                    End If
                End If

                ' Add Kop Image
                Dim imagePathKopSurat As String = System.IO.Path.Combine(Application.StartupPath, pathKopSurat)
                Dim pictureBoxKopSurat As XRPictureBox = CreateXRPictureBoxReport("Kop Surat", Image.FromFile(imagePathKopSurat), 87, 33, 408, 71)

                Dim Tdata As DataTable = New DataTable
                Tdata = CreateTableSuratKeterangan()
                Tdata.Rows.Clear()

                If tblsRekamMedis.Rows.Count > 0 Then
                    Dim rowData As DataRow = tblsRekamMedis.Rows(0)

                    Dim tglSurat As String = Format(rowSurat("TanggalSurat"), "dd") & " " & BulanIndonesia(Format(rowSurat("TanggalSurat"), "MM")) & " " & Format(rowSurat("TanggalSurat"), "yyyy")
                    Dim statusSuratDokter As String = ""
                    Dim keteranganButaWarna As String = ""
                    Dim tujuanSuratDokter As String = ""
                    Dim keteranganSuratDokter As String = ""

                    ' Get Nomor Surat
                    Dim nomorSurat As String = rowSurat("NoSurat")

                    ' Set Keterangan
                    keteranganSuratDokter = "Setelah dilakukan pemeriksaan, dinyatakan dalam keadaan " & rowSurat("Hasil") & "."

                    ' Set Tujuan
                    tujuanSuratDokter = "Surat keterangan ini dipergunakan untuk " & rowSurat("Tujuan")

                    ' Set Buta Warna
                    Select Case rowSurat("ButaWarna")
                        Case "Negatif", "Total"
                            keteranganButaWarna = "Buta Warna (" & rowSurat("ButaWarna") & ")"
                        Case "Partial"
                            keteranganButaWarna = "Buta Warna (" & rowSurat("ButaWarna") & " " & rowSurat("KeteranganButaWarna") & ")"
                    End Select

                    Dim tblsFisik As DataTable = ReadSQL("SELECT * FROM TransaksiDetailFisik WHERE NoTransaksi = '" & idTransaksi & "'")
                    Dim tinggi As String = ""
                    Dim berat As String = ""
                    Dim sistole As String = ""
                    Dim diastole As String = ""
                    Dim suhu As String = ""
                    Dim heartRate As String = ""
                    Dim respiratoryRate As String = ""

                    If tblsFisik.Rows.Count > 0 Then
                        Dim rowFisik As DataRow = tblsFisik.Rows(0)

                        tinggi = rowFisik("Tinggi")
                        berat = rowFisik("Berat")
                        sistole = rowFisik("Sistole")
                        diastole = rowFisik("Diastole")
                        suhu = rowFisik("Suhu")
                        heartRate = rowFisik("HeartRate")
                        respiratoryRate = rowFisik("RespiratoryRate")
                    End If

                    For Each Trow As DataRow In tblsRekamMedis.Rows
                        Dim Tlastnew As DataRow = Tdata.NewRow

                        Tlastnew("Nama") = Trow("Nama")
                        Tlastnew("Umur") = Umur(Trow("TglLahir"))
                        Tlastnew("Jenis Kelamin") = Trow("JenisKelamin")
                        Tlastnew("Alamat") = Trow("DomisiliAlamat")
                        Tlastnew("Tinggi Badan") = tinggi
                        Tlastnew("Berat Badan") = berat
                        Tlastnew("Tekanan Darah") = sistole & "/" & diastole
                        Tlastnew("Suhu") = suhu
                        Tlastnew("Nadi") = heartRate
                        Tlastnew("Frekuensi Nafas") = respiratoryRate
                        Tlastnew("Penglihatan") = keteranganButaWarna

                        Tdata.Rows.Add(Tlastnew)
                    Next

                    Report.DataSource = Tdata
                    Report.Bands.Item(BandKind.PageHeader).Controls("xrLabelNoDokumen").Text = noDocument

                    ' Akses panel yang sudah ada di dalam band Detail menggunakan index
                    Dim panel As XRPanel = CType(Report.Bands(BandKind.PageHeader).Controls(0), XRPanel)

                    ' Cari panel berdasarkan nama di dalam band Detail
                    Dim PanelAlamat As XRPanel = TryCast(Report.Bands(BandKind.PageHeader).Controls("xrPanelAlamat"), XRPanel)

                    ' Input data label
                    PanelAlamat.Controls("xrLabelAlamat").Text = alamatCompany
                    PanelAlamat.Controls("xrLabelNoTelepon").Text = telpCompany

                    Report.Bands.Item(BandKind.Detail).Controls("xrLabelNoSurat").Text = nomorSurat
                    Report.Bands.Item(BandKind.Detail).Controls("xrLabelStatusSehat").Text = keteranganSuratDokter
                    Report.Bands.Item(BandKind.Detail).Controls("xrLabelTujuanSurat").Text = tujuanSuratDokter

                    Report.Bands.Item(BandKind.PageFooter).Controls("xrLabelTgl").Text = namaKota & ", " & tglSurat

                    If Report.Bands.Item(BandKind.PageFooter).Controls("xrLabelDokter") IsNot Nothing Then
                        Report.Bands.Item(BandKind.PageFooter).Controls("xrLabelDokter").Text = namaDokter
                        Report.Bands.Item(BandKind.PageFooter).Controls("xrLabelSIP").Text = "SIP: " & noSIP
                    End If


                    ' Nonaktifkan jika sudah ada master TTD Dokter
                    'Report.Bands.Item(BandKind.PageFooter).Controls("xrPictureBoxTTD").Visible = False

                    ' Add Kop Surat
                    'Report.Bands.Item(BandKind.PageHeader).Controls.Add(pictureBoxKopSurat)

                    'Report.RunDesigner()
                    Report.ShowPreview()
                End If
            Else
                MsgBox("Generate surat terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Warning!")
        End Try
    End Sub

    Private Sub TextBoxSigna1NonRacikan_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxSigna1NonRacikan.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub TextBoxSigna2NonRacikan_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxSigna2NonRacikan.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = vbBack Or e.KeyChar = ".") Then e.Handled = True
    End Sub

    Private Sub ButtonPreviewHasilLab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPreviewHasilLab.Click
        Try
            Dim noTransaksiLab As String = ""

            If RadioButtonLaboratorium.Checked = True Then
                noTransaksiLab = ReadSQLNIK("SELECT TransaksiLab.NoUrut " & _
                                            "FROM TransaksiLab " & _
                                            "LEFT JOIN TransaksiDetail ON TransaksiDetail.NoTransaksiLab = TransaksiLab.NoUrut " & _
                                            "WHERE TransaksiDetail.NoUrut = '" & idTransaksi & "' AND TransaksiLab.Status IN ('CETAK', 'TAKEIT')")

                If noTransaksiLab <> "" And noTransaksiLab <> "-" Then
                    PreviewHasilLab("Preview", "Yes", noTransaksiLab)
                Else
                    MsgBox("Hasil Tidak Ditemukan.", MsgBoxStyle.Exclamation, "Warning!")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub PreviewHasilLab(ByVal Action As String, ByVal Kop As String, ByVal noTransaksiLab As String)
        Dim TempWhatsapp As String = ""
        Dim TempEmail As String = ""
        Dim NoWhatsappCustomer As String = ""
        Dim EmailCustomer As String = ""

        ' Set ID Transaksi Lab
        Dim idTransaksiLab As String = ReadSQLNIK("SELECT TransLabID FROM TransaksiLab WHERE NoUrut = '" & noTransaksiLab & "'")

        Dim Tbls As DataTable = New DataTable
        Tbls = ReadSQL("SELECT a.TransLabID, a.TransLabIDDetail, a.TindakanID, a.NamaTindakan, a.JenisTindakan, b.NoUrut, b.GroupID, b.DetailKet, b.Result, b.Satuan, b.Pria, b.Wanita, b.Keterangan, m.UrutanJenisID, a.Urutan, b.saran AS 'Saran' " & _
                       "FROM transaksilabdetail a " & _
                       "LEFT JOIN TransaksiLabResult b ON a.TransLabIDDetail=b.TransLabIDDetail AND a.TindakanID=b.TindakanID " & _
                       "LEFT JOIN MasterJenisTindakan m ON m.JenisTindakan=a.JenisTindakan " & _
                       "WHERE a.TransLabID = '" & idTransaksiLab & "' " & _
                       "ORDER BY m.UrutanJenisID, a.Urutan, b.TindakanID, b.NoUrut, a.TransLabIDDetail, a.TindakanID, b.GroupID, b.DetailKet")

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

        Dim Tlab As DataTable = ReadSQL("SELECT a.SendingWhatsapp, a.SendingEmail, a.Kesimpulan, a.Saran, b.NoNIK, b.NoNIP, a.caraambil, a.DokterRequest, c.NoJenisBayar, b.Nama, b.NoRekamMedis, a.NoUrut, b.JenisKelamin, CONVERT(DATE, b.TglLahir) AS tgllahir, b.DomisiliAlamat, CONVERT(DATE, a.TglLab) AS tgllab " & _
                                        "FROM TransaksiLab a " & _
                                        "LEFT JOIN MasterPasien b ON a.IDInternet = b.NoRekamMedis " & _
                                        "LEFT JOIN TransaksiLabBayar c ON a.TransLabID = c.TransLabID " & _
                                        "WHERE a.TransLabID = '" & idTransaksiLab & "'")

        Dim TrowLab As DataRow = Tlab.Rows(0)
        Dim Tsimpul As String = ""
        Dim Tsaran As String = ""
        Dim noNIK As String = ""
        Dim nip As String = ""
        Dim Pengirim As String = ""
        If IsDBNull(TrowLab("NoNIK")) = False Then noNIK = TrowLab("NoNIK") Else noNIK = "-"
        If IsDBNull(TrowLab("NoNIP")) = False Then nip = TrowLab("NoNIP") Else nip = "-"

        Dim caraambil As String = TrowLab("caraambil")

        Dim splitcompany() As String = TrowLab("nojenisbayar").ToString.Split("-")

        If CheckSQL("SELECT * FROM mastercompany WHERE NoCompany = '" & splitcompany(1) & "' AND ReportHasilPerusahaan = 0") = True And TrowLab("nourut").ToString.Trim.Contains("M") = True Then
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

        Dim Nama As String = TrowLab("Nama").ToString.Trim
        Dim numberic As Boolean = False

        For Each str As Char In Nama
            If IsNumeric(str) Then
                numberic = True
                Exit For
            End If
        Next

        Dim Tgelar As String = Gelar(Year(Now()) - Year(TrowLab("tgllahir")), TrowLab("JenisKelamin").ToString.Trim)

        For Each Trow As DataRow In Tbls.Rows
            Trow("Registrasi") = TrowLab("NoRekamMedis").ToString.Trim
            Trow("barcodenotrans") = idTransaksiLab
            Trow("Nama") = Tgelar & " " & Nama & "/(" & TrowLab("JenisKelamin").ToString.Trim & ")" & vbCrLf

            Dim Tgltemp As Date = TrowLab("tgllahir")
            If Tgltemp.Date.AddYears(120).Year < DateAndTime.Now.Year Then
                Trow("Umur") = ""
            Else
                Trow("Umur") = Format(TrowLab("tgllahir"), "dd MMM yyyy") & " / " & Umur(TrowLab("tgllahir"))
            End If

            Trow("Alamat") = TrowLab("DomisiliAlamat")
            Trow("NoTransaksi") = TrowLab("NoUrut") & " (" & idTransaksiLab & ")"
            Trow("DrPelaksana") = DrPelaksanaKlinik
            Trow("Hasil") = caraambil

            If Pengirim <> "" Then
                Trow("DrRequest") = Pengirim
            Else
                Trow("DrRequest") = ReadSQLNIK("SELECT DrNama FROM MasterDokterKirim WHERE IdKirim in ( select IdKirim FROM MasterDokterTempatPraktek WHERE IdPraktek = '" & TrowLab("DokterRequest") & "')")
            End If

            Trow("Tanggal") = Format(TrowLab("tgllab"), "dd-MMM-yyyy")
            Trow("Satuan") = Trow("Satuan").ToString
            Dim Tkriteria As String = ""
            If TrowLab("JenisKelamin").ToString.Trim = "L" Then
                'display hasil pria
                Tkriteria = Trow("Pria").ToString
            ElseIf TrowLab("JenisKelamin").ToString.Trim = "P" Then
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
        Next

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

        Report.DataSource = Tbls
        Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MM-yyyy HH:mm:ss") + " by " + userInput

        If Action = "Preview" Then
            Report.ShowPreview()
        ElseIf Action = "Print" Then
            Report.Print()
        End If
    End Sub

    Private Sub ButtonCariRiwayatLaboratorium_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCariRiwayatLaboratorium.Click
        Try
            GetRiwayatLaboratorium()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Warning!")
        End Try
    End Sub

    'Private Sub GetRiwayatLaboratorium()
    '    'If DataGridViewRiwayatLaboratorium.Rows.Count > 0 Then
    '    '    DataGridViewRiwayatLaboratorium.Rows.Clear()
    '    'End If

    '    DataGridViewRiwayatLaboratorium.DataSource = Nothing

    '    Dim Tawal As Date = TglAwalRiwayatLaboratorium.Value
    '    Dim Takhir As Date = TglAkhirRiwayatLaboratorium.Value
    '    Dim queryString As String = ""
    '    Dim queryOrderString As String = ""
    '    Dim queryTindakanString As String = ""

    '    Dim tblTemp As DataTable = CreateTableRiwayatLaboratorium()

    '    If RadioButtonRiwayatTindakan1.Checked = True Then
    '        queryTindakanString = "AND a.TindakanID = '" & TextBoxKodeTindakanRiwayatLaboratorium.Text & "'"
    '    ElseIf RadioButtonRiwayatTindakan2.Checked = True Then
    '        queryTindakanString = ""
    '    ElseIf RadioButtonCekStik.Checked = True Then
    '        Dim queryCekStik As String = "SELECT CreatedDate, Kategori, Kondisi, Hasil, Satuan, Keterangan " & _
    '                               "FROM HasilCekstik " & _
    '                               "WHERE NoRM = '" & idPasien & "' " & _
    '                               "AND CONVERT(date, CreatedDate) BETWEEN '" & Format(Tawal, "yyyy-MM-dd") & "' AND '" & Format(Takhir, "yyyy-MM-dd") & "'"

    '        'MsgBox("Query CekStik: " & queryCekStik)

    '        Dim TblCekStik As DataTable = ReadSQL(queryCekStik)


    '        If TblCekStik.Rows.Count > 0 Then
    '            For Each rowCekStik As DataRow In TblCekStik.Rows
    '                Dim newRow As DataRow = tblTemp.NewRow()
    '                newRow("Tgl Pemeriksaan") = Format(rowCekStik("CreatedDate"), "yyyy-MM-dd HH:mm:ss")
    '                newRow("Nama Pemeriksaan") = rowCekStik("Kategori").ToString()
    '                newRow("Jenis Pemeriksaan") = "Cek Stik"
    '                newRow("Detail Keterangan") = rowCekStik("Kondisi").ToString()
    '                newRow("Hasil") = rowCekStik("Hasil").ToString()
    '                newRow("Satuan") = rowCekStik("Satuan").ToString()
    '                newRow("Nilai Rujukan") = ""
    '                newRow("Keterangan") = rowCekStik("Keterangan").ToString()

    '                tblTemp.Rows.Add(newRow)
    '            Next
    '        End If

    '    End If

    '    queryString = "SELECT a.CreatedDate, a.NamaTindakan, a.JenisTindakan, b.DetailKet, b.Result, b.Satuan, b.Pria, b.Wanita, b.Keterangan, b.saran AS 'Saran' " & _
    '                  "FROM TransaksiLabDetail a " & _
    '                  "LEFT JOIN TransaksiLabResult b ON a.TransLabIDDetail = b.TransLabIDDetail AND a.TindakanID = b.TindakanID " & _
    '                  "LEFT JOIN MasterJenisTindakan m ON m.JenisTindakan=a.JenisTindakan " & _
    '                  "WHERE a.StatusPembayaran = 'PAID' " & queryTindakanString & " AND a.TransLabID IN (SELECT TransLabID FROM TransaksiLab WHERE IDInternet = '" & idPasien & "' AND Status IN ('CETAK', 'TAKEIT')  AND CONVERT(date, Tgllab) BETWEEN '" & Format(Tawal.Date, "yyyy-MM-dd") & "' AND '" & Format(Takhir.Date, "yyyy-MM-dd") & "' AND deleted <> 1 AND LabStartTime IS NOT NULL)"
    '    queryOrderString = " ORDER BY a.TransLabID DESC, m.UrutanJenisID, a.Urutan, b.TindakanID, b.NoUrut, a.TransLabIDDetail, a.TindakanID, b.GroupID, b.DetailKet"


    '    Dim Tbls As DataTable = ReadSQL(queryString & queryOrderString)
    '    If Tbls.Rows.Count > 0 Then
    '        For Each Trow As DataRow In Tbls.Rows
    '            Dim nilaiRujukan As String = ""

    '            Dim newRow As DataRow = tblTemp.NewRow()
    '            newRow("Tgl Pemeriksaan") = Format(Trow("CreatedDate"), "yyyy-MM-dd HH:mm:ss")
    '            newRow("Nama Pemeriksaan") = Trow("NamaTindakan")
    '            newRow("Jenis Pemeriksaan") = Trow("JenisTindakan")
    '            newRow("Detail Keterangan") = Trow("DetailKet")
    '            newRow("Hasil") = Trow("Result")
    '            newRow("Satuan") = Trow("Satuan")
    '            newRow("Nilai Rujukan") = Trow("Pria")
    '            newRow("Keterangan") = Trow("Keterangan")

    '            tblTemp.Rows.Add(newRow)
    '        Next

    '        ' Tambahkan kolom checkbox
    '        'Dim checkColumn As New DataGridViewCheckBoxColumn()
    '        'checkColumn.Name = "CheckColumn" ' Nama kolom
    '        'checkColumn.HeaderText = "Pilih" ' Header kolom
    '        'DataGridViewRiwayatLaboratorium.Columns.Add(checkColumn)
    '        'DataGridViewRiwayatLaboratorium.Columns("CheckColumn").ReadOnly = False

    '        DataGridViewRiwayatLaboratorium.DataSource = tblTemp
    '        DataGridViewRiwayatLaboratorium.CurrentCell = Nothing
    '        DataGridViewRiwayatLaboratorium.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

    '        'For Each row As DataGridViewRow In DataGridViewRiwayatLaboratorium.Rows
    '        '    Dim cell As DataGridViewCell = row.Cells("CheckColumn")

    '        '    If row.Cells("Nama Pemeriksaan").ToString.Contains("ECG") = True Then
    '        '        cell.Value = True ' Ubah menjadi True (checked) untuk setiap baris.
    '        '    End If
    '        'Next
    '    Else
    '        MsgBox("Data tidak ditemukan.", MsgBoxStyle.Exclamation, "Warning!")
    '    End If
    'End Sub

    Private Sub GetRiwayatLaboratorium()
        DataGridViewRiwayatLaboratorium.DataSource = Nothing

        Dim Tawal As Date = TglAwalRiwayatLaboratorium.Value
        Dim Takhir As Date = TglAkhirRiwayatLaboratorium.Value
        Dim tblTemp As DataTable = CreateTableRiwayatLaboratorium()

        ' Set Jenis Kelamin
        Dim jenisKelamin As String = ""
        Dim dtJK As DataTable = ReadSQL("SELECT JenisKelamin FROM MasterPasien WHERE NoRekamMedis = '" & idPasien & "'")
        If dtJK.Rows.Count > 0 Then
            jenisKelamin = dtJK.Rows(0)("JenisKelamin").ToString().Trim().ToUpper()
        End If

        If RadioButtonCekStik.Checked = True Then
            If DataGridViewRiwayatLaboratorium.Columns.Contains("BtnLihatPDF") Then
                DataGridViewRiwayatLaboratorium.Columns("BtnLihatPDF").Visible = False
            End If
            ' Ambil hanya data dari HasilCekstik
            Dim queryCekStik As String = "SELECT CreatedDate, Kategori, Kondisi, Hasil, Satuan, Keterangan " & _
                                         "FROM HasilCekstik " & _
                                         "WHERE NoRM = '" & idPasien & "' " & _
                                         "AND CONVERT(date, CreatedDate) BETWEEN '" & Format(Tawal, "yyyy-MM-dd") & "' AND '" & Format(Takhir, "yyyy-MM-dd") & "'"

            Dim TblCekStik As DataTable = ReadSQL(queryCekStik)

            If TblCekStik.Rows.Count > 0 Then
                For Each rowCekStik As DataRow In TblCekStik.Rows
                    Dim newRow As DataRow = tblTemp.NewRow()
                    newRow("Tgl Pemeriksaan") = Format(rowCekStik("CreatedDate"), "yyyy-MM-dd HH:mm:ss")
                    newRow("Nama Pemeriksaan") = rowCekStik("Kategori").ToString()
                    newRow("Jenis Pemeriksaan") = "Cek Stik"
                    newRow("Detail Keterangan") = rowCekStik("Kondisi").ToString()
                    newRow("Hasil") = rowCekStik("Hasil").ToString()
                    newRow("Satuan") = rowCekStik("Satuan").ToString()
                    Dim kondisi As String = rowCekStik("Kondisi").ToString().Trim().ToUpper()
                    Dim nilaiRujukan As String = ""

                    Select Case kondisi
                        Case "Tes Gulah Darah Puasa (GDP)"
                            nilaiRujukan = "<126 mg/dL"
                        Case "Tes Gula Darah Sewaktu (GDS)"
                            nilaiRujukan = "<200 mg/dL"
                        Case "TC"
                            nilaiRujukan = "<200 mg/dL"
                        Case "Asam Urat"
                            If jenisKelamin = "L" Then
                                nilaiRujukan = "2 - 7.5 mg/dL"
                            ElseIf jenisKelamin = "P" Then
                                nilaiRujukan = "2 - 6.5 mg/dL"
                            Else
                                nilaiRujukan = "-"
                            End If
                        Case Else
                            nilaiRujukan = "-"
                    End Select

                    newRow("Nilai Rujukan") = nilaiRujukan

                    newRow("Keterangan") = rowCekStik("Keterangan").ToString()

                    tblTemp.Rows.Add(newRow)
                Next
            Else
                If DataGridViewRiwayatLaboratorium.Columns.Contains("BtnLihatPDF") Then
                    DataGridViewRiwayatLaboratorium.Columns("BtnLihatPDF").Visible = True
                End If
            End If

            ' Tampilkan hasil cek stik
            If tblTemp.Rows.Count > 0 Then
                DataGridViewRiwayatLaboratorium.DataSource = tblTemp
                SetupGridRiwayatLaboratorium()

                DataGridViewRiwayatLaboratorium.CurrentCell = Nothing
                DataGridViewRiwayatLaboratorium.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

                ' Nonaktifkan PDF di mode Cek Stik
                If DataGridViewRiwayatLaboratorium.Columns.Contains("BtnLihatPDF") Then
                    DataGridViewRiwayatLaboratorium.Columns("BtnLihatPDF").Visible = False
                End If
            Else
                MsgBox("Data tidak ditemukan.", MsgBoxStyle.Exclamation, "Warning!")
            End If

            Exit Sub
        End If

        ' Jika bukan Cek Stik, ambil dari TransaksiLabDetail
        Dim queryTindakanString As String = ""
        If RadioButtonRiwayatTindakan1.Checked = True Then
            queryTindakanString = "AND a.TindakanID = '" & TextBoxKodeTindakanRiwayatLaboratorium.Text & "'"
        End If

        Dim queryString As New System.Text.StringBuilder()
        queryString.AppendLine("SELECT t.NoUrut + ' (' + CONVERT(VARCHAR(10), t.TglLab, 105) + ')' AS NoTransaksiTgl,")
        queryString.AppendLine("       a.NamaTindakan, a.JenisTindakan, b.DetailKet, b.Result, b.Satuan, b.Flag,")
        queryString.AppendLine("       b.Pria, b.Wanita, b.Keterangan, b.Saran AS Saran, CONVERT(VARCHAR(10), t.TglLab, 105) AS TanggalLab")
        queryString.AppendLine("FROM TransaksiLabDetail a")
        queryString.AppendLine("     LEFT JOIN TransaksiLabResult b ON a.TransLabIDDetail=b.TransLabIDDetail AND a.TindakanID=b.TindakanID")
        queryString.AppendLine("     INNER JOIN TransaksiLab t ON a.TransLabID=t.TransLabID")
        queryString.AppendLine("WHERE a.StatusPembayaran='PAID' " & queryTindakanString)
        queryString.AppendLine("  AND t.IDInternet='" & idPasien & "'")
        queryString.AppendLine("  AND t.Status IN ('CETAK', 'TAKEIT')")
        queryString.AppendLine("  AND CONVERT(DATE, t.TglLab) BETWEEN '" & Format(Tawal, "yyyy-MM-dd") & "' AND '" & Format(Takhir, "yyyy-MM-dd") & "'")
        queryString.AppendLine("  AND t.deleted<>1")
        queryString.AppendLine("  AND t.LabStartTime IS NOT NULL")

        Dim queryOrderString As String = " ORDER BY a.TransLabID DESC, a.Urutan, b.TindakanID, b.NoUrut, a.TransLabIDDetail, a.TindakanID, b.GroupID, b.DetailKet"

        Dim Tbls As DataTable = ReadSQL(queryString.ToString() & queryOrderString)
        'Dim jenisKelamin As String = ReadSQLNIK("SELECT JenisKelamin FROM MasterPasien WHERE NoRekamMedis = '" & idPasien & "'")

        If Tbls.Rows.Count > 0 Then
            For Each Trow As DataRow In Tbls.Rows
                Dim newRow As DataRow = tblTemp.NewRow()

                Dim hasil As String = Trow("Result").ToString()
                Dim flag As String = Trow("Flag").ToString().Trim()
                Dim nilaiRujukan As String = ""

                ' Tambahkan tanda * jika Flag High/Low
                If flag = "High" OrElse flag = "Low" Then
                    hasil &= " *"
                End If

                ' Set Nilai Rujukan berdasarkan Jenis Kelamin
                If jenisKelamin = "L" Then
                    nilaiRujukan = Trow("Pria").ToString
                ElseIf jenisKelamin = "P" Then
                    nilaiRujukan = Trow("Wanita").ToString
                End If

                newRow("Tgl Pemeriksaan") = Trow("TanggalLab")
                newRow("Nama Pemeriksaan") = Trow("NamaTindakan")
                newRow("Jenis Pemeriksaan") = Trow("JenisTindakan")
                newRow("Detail Keterangan") = Trow("DetailKet")
                newRow("Hasil") = hasil
                newRow("Satuan") = Trow("Satuan")
                newRow("Nilai Rujukan") = nilaiRujukan
                newRow("Keterangan") = Trow("Keterangan")

                tblTemp.Rows.Add(newRow)
            Next
        End If

        ' Tampilkan data lab
        If tblTemp.Rows.Count > 0 Then
            DataGridViewRiwayatLaboratorium.DataSource = tblTemp
            SetupGridRiwayatLaboratorium()

            DataGridViewRiwayatLaboratorium.CurrentCell = Nothing
            DataGridViewRiwayatLaboratorium.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            ' Aktifkan PDF di mode Lab
            If DataGridViewRiwayatLaboratorium.Columns.Contains("BtnLihatPDF") Then
                DataGridViewRiwayatLaboratorium.Columns("BtnLihatPDF").Visible = True
            End If
        Else
            MsgBox("Data tidak ditemukan.", MsgBoxStyle.Exclamation, "Warning!")
        End If
    End Sub

    Private Sub SetupGridRiwayatLaboratorium()
        With DataGridViewRiwayatLaboratorium
            .AutoGenerateColumns = True
            .AllowUserToAddRows = False
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False

            ' === Tambahkan kolom FilePath jika belum ada ===
            If Not .Columns.Contains("FilePath") Then
                Dim colPath As New DataGridViewTextBoxColumn()
                colPath.Name = "FilePath"
                colPath.HeaderText = "FilePath"
                colPath.Visible = False
                .Columns.Add(colPath)
            End If

            ' === Tambahkan tombol PDF jika belum ada ===
            If Not .Columns.Contains("BtnLihatPDF") Then
                Dim btnPdf As New DataGridViewButtonColumn()
                btnPdf.Name = "BtnLihatPDF"
                btnPdf.HeaderText = "PDF"
                btnPdf.Text = "Lihat PDF"
                btnPdf.UseColumnTextForButtonValue = True
                btnPdf.Width = 80
                .Columns.Add(btnPdf)
            End If
        End With
    End Sub

    Private Sub DataGridViewRiwayatLaboratorium_CellContentClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridViewRiwayatLaboratorium.CellContentClick

        ' === Validasi baris ===
        If e.RowIndex < 0 Then Exit Sub

        ' === Pastikan kolom tombol ada ===
        If Not DataGridViewRiwayatLaboratorium.Columns.Contains("BtnLihatPDF") Then Exit Sub

        ' === Pastikan klik di kolom PDF ===
        If e.ColumnIndex <> DataGridViewRiwayatLaboratorium.Columns("BtnLihatPDF").Index Then Exit Sub

        ' === Ambil FilePath ===
        Dim cellPath = DataGridViewRiwayatLaboratorium.Rows(e.RowIndex).Cells("FilePath")

        If cellPath Is Nothing OrElse IsDBNull(cellPath.Value) Then
            MessageBox.Show("File PDF tidak tersedia.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim filePath As String = cellPath.Value.ToString().Trim()

        If filePath = "" Then
            MessageBox.Show("File PDF tidak tersedia.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        ' === Buka PDF ===
        If IO.File.Exists(filePath) Then
            Try
                Process.Start(filePath)
            Catch ex As Exception
                MessageBox.Show("Gagal membuka PDF." & vbCrLf & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            MessageBox.Show("File PDF tidak ditemukan:" & vbCrLf & filePath, "File Tidak Ada", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Function CreateTableRiwayatLaboratorium() As DataTable
        Dim Thasil As New DataTable

        insertRowToTbls(Thasil, "Typstring", "Tgl Pemeriksaan")
        insertRowToTbls(Thasil, "Typstring", "Nama Pemeriksaan")
        insertRowToTbls(Thasil, "Typstring", "Jenis Pemeriksaan")
        insertRowToTbls(Thasil, "Typstring", "Detail Keterangan")
        insertRowToTbls(Thasil, "Typstring", "Hasil")
        insertRowToTbls(Thasil, "Typstring", "Satuan")
        insertRowToTbls(Thasil, "Typstring", "Nilai Rujukan")
        insertRowToTbls(Thasil, "Typstring", "Keterangan")
        insertRowToTbls(Thasil, "Typstring", "FilePath")

        Return Thasil
    End Function

    Private Sub ButtonCariTindakanRiwayatLaboratorium_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCariTindakanRiwayatLaboratorium.Click
        Dim queryString As String = ""
        Dim queryOrderString As String = ""

        queryString = "SELECT TindakanID AS ID, NamaTindakan AS [Tindakan], JenisTindakan AS [Jenis], PARSENAME(CONVERT(varchar, CONVERT(money, BiayaTindakan), 1), 2) AS [Biaya Tindakan], [Mesin] " & _
                      "FROM MasterLab " & _
                      "WHERE Closed = 0"
        queryOrderString = " ORDER BY JenisTindakan, NamaTindakan"

        Find.Show()
        Find.Query(queryString, queryOrderString, "FindTindakanRiwayatLaboratorium", 1)
    End Sub

    Public Sub LoadTindakanRiwayatLaboratorium(ByRef Trow As DataRowView)
        If Trow("ID") > 0 Then
            TextBoxNamaTindakanRiwayatLaboratorium.Text = Trow("Tindakan")
            TextBoxKodeTindakanRiwayatLaboratorium.Text = Trow("ID")
        End If
    End Sub

    Private Sub TextBoxSearchRiwayatLaboratorium_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxSearchRiwayatLaboratorium.TextChanged
        SearchDataGridView(DataGridViewRiwayatLaboratorium, TextBoxSearchRiwayatLaboratorium.Text)
    End Sub

    Private Sub ButtonSearchDataGridViewRiwayatLaboratorium_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSearchDataGridViewRiwayatLaboratorium.Click
        SearchDataGridView(DataGridViewRiwayatLaboratorium, TextBoxSearchRiwayatLaboratorium.Text)
    End Sub

    Private Sub SearchDataGridViewRiwayatLaboratoriumPerKolom()
        Dim keyword As String = TextBoxSearchRiwayatLaboratorium.Text
        Dim dv As DataView = CType(DataGridViewRiwayatLaboratorium.DataSource, DataTable).DefaultView
        dv.RowFilter = "[Tgl Pemeriksaan] LIKE '%" & keyword & "%' OR [Nama Pemeriksaan] LIKE '%" & keyword & "%' OR [Jenis Pemeriksaan] LIKE '%" & keyword & "%' OR [Detail Keterangan] LIKE '%" & keyword & "%' OR [Hasil] LIKE '%" & keyword & "%' OR [Satuan] LIKE '%" & keyword & "%' OR [Nilai Rujukan] LIKE '%" & keyword & "%' OR [Keterangan] LIKE '%" & keyword & "%'"
    End Sub

    Private Sub SearchDataGridView(ByVal dataGridView As DataGridView, ByVal keyword As String)
        Dim dv As DataView = CType(dataGridView.DataSource, DataTable).DefaultView
        Dim stringSearch As String = ""

        ' Loop melintasi semua kolom dan menambahkan filter untuk setiap kolom
        For Each column As DataGridViewColumn In dataGridView.Columns
            If column.Visible Then ' Hanya filter kolom yang terlihat
                stringSearch = stringSearch & "[" & column.DataPropertyName & "] LIKE '%" & keyword & "%' OR "
            End If
        Next

        ' Hapus " OR " terakhir dari string
        If stringSearch.EndsWith(" OR ") Then
            stringSearch = stringSearch.Substring(0, stringSearch.Length - 4)
        End If

        dv.RowFilter = stringSearch
    End Sub

    Private Sub ButtonCetakSuratKeteranganIstirahat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCetakSuratKeteranganIstirahat.Click
        Try
            ' Set No Dokumen
            Dim noDocument As String = ReadSQLNIK("SELECT NomorDokumen FROM MasterDokumen WHERE NamaDokumen = 'Surat Keterangan Istirahat'")

            ' Set Path Kop Surat
            Dim pathKopSurat As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'image_path_kop_surat_keterangan'")

            ' Set Alamat & No Telpon
            Dim namaKota As String = ReadSQLNIK("SELECT StrValue FROM  msconfig WHERE configname = 'Kota'")
            Dim alamatCompany As String = ReadSQLNIK("SELECT StrValue FROM  msconfig WHERE configname = 'AlamatCompany'")
            Dim telpCompany As String = ReadSQLNIK("SELECT StrValue FROM  msconfig WHERE configname = 'TelpCompany'")

            'Nama Dokter
            Dim namaDokter As String = ""
            Dim noSIP As String = ""
            Dim kodeDokter As String = ""

            If jenisTransaksi = "UMUM" Or jenisTransaksi = "POLI" Then
                namaDokter = ReadSQLNIK("SELECT DokterPoli FROM TransaksiPoli WHERE NoUrut = '" & idTransaksi & "'")
                kodeDokter = ReadSQLNIK("SELECT KodeDokter FROM TransaksiPoli WHERE NoUrut = '" & idTransaksi & "'")
                noSIP = ReadSQLNIK("SELECT NoSIP FROM MasterDokter WHERE ID = '" & kodeDokter & "'")
            Else
                namaDokter = ReadSQLNIK("SELECT DokterGigi FROM TransaksiGigi WHERE NoUrut = '" & idTransaksi & "'")
                kodeDokter = ReadSQLNIK("SELECT KodeDokter FROM TransaksiGigi WHERE NoUrut = '" & idTransaksi & "'")
                noSIP = ReadSQLNIK("SELECT NoSIP FROM MasterDokter WHERE ID = '" & kodeDokter & "'")
            End If


            ' Set Data Surat Keterangan
            Dim tblSuratKeterangan As DataTable = ReadSQL("SELECT * FROM SuratKeteranganIstirahat WHERE NoTransaksi = '" & idTransaksi & "'")

            If tblSuratKeterangan.Rows.Count > 0 Then
                Dim rowSurat As DataRow = tblSuratKeterangan.Rows(0)

                Report = New XtraReport
                Report = XtraReport.FromFile(Application.StartupPath + "\Reports\Klinik\SuratKeterangan\SuratKeteranganIstirahat.repx", True)

                ' Add Kop Image
                Dim imagePathKopSurat As String = System.IO.Path.Combine(Application.StartupPath, pathKopSurat)
                Dim pictureBoxKopSurat As XRPictureBox = CreateXRPictureBoxReport("Kop Surat", Image.FromFile(imagePathKopSurat), 87, 33, 408, 71)

                Dim Tdata As DataTable = New DataTable
                Tdata = CreateTableSuratKeterangan()
                Tdata.Rows.Clear()

                If tblsRekamMedis.Rows.Count > 0 Then
                    Dim rowData As DataRow = tblsRekamMedis.Rows(0)

                    Dim tglSurat As String = Format(rowSurat("TanggalSurat"), "dd") & " " & BulanIndonesia(Format(rowSurat("TanggalSurat"), "MM")) & " " & Format(rowSurat("TanggalSurat"), "yyyy")
                    Dim jumlahHari As String = rowSurat("JumlahHari") & " (" & Terbilang(rowSurat("JumlahHari")) & ")"
                    Dim diagnosaPasien As String = rowSurat("Diagnosa")
                    Dim tglAwal As String = Format(rowSurat("TanggalAwal"), "dd") & " " & BulanIndonesia(Format(rowSurat("TanggalAwal"), "MM")) & " " & Format(rowSurat("TanggalAwal"), "yyyy")
                    Dim tglAkhir As String = Format(rowSurat("TanggalAkhir"), "dd") & " " & BulanIndonesia(Format(rowSurat("TanggalAkhir"), "MM")) & " " & Format(rowSurat("TanggalAkhir"), "yyyy")
                    Dim keteranganDetail As String = "Pada tanggal " & tglSurat & " pukul " & Format(rowSurat("TanggalSurat"), "HH") & "." & Format(rowSurat("TanggalSurat"), "mm") & " Sudah dilakukan pemeriksaan kesehatan dari orang tersebut diatas dan ternyata " & _
                                                     "hasilnya : perlu istirahat karena sakit selama " & jumlahHari & " hari, terhitung tanggal " & tglAwal & " s/d " & tglAkhir

                    ' Get Nomor Surat
                    Dim nomorSurat As String = rowSurat("NoSurat")

                    Dim tblsFisik As DataTable = ReadSQL("SELECT * FROM TransaksiDetailFisik WHERE NoTransaksi = '" & idTransaksi & "'")
                    Dim tinggi As String = ""
                    Dim berat As String = ""
                    Dim sistole As String = ""
                    Dim diastole As String = ""
                    Dim suhu As String = ""
                    Dim heartRate As String = ""
                    Dim respiratoryRate As String = ""

                    If tblsFisik.Rows.Count > 0 Then
                        Dim rowFisik As DataRow = tblsFisik.Rows(0)

                        tinggi = rowFisik("Tinggi")
                        berat = rowFisik("Berat")
                        sistole = rowFisik("Sistole")
                        diastole = rowFisik("Diastole")
                        suhu = rowFisik("Suhu")
                        heartRate = rowFisik("HeartRate")
                        respiratoryRate = rowFisik("RespiratoryRate")
                    End If

                    Dim pekerjaanPasien As String = "-"

                    For Each Trow As DataRow In tblsRekamMedis.Rows
                        Dim Tlastnew As DataRow = Tdata.NewRow

                        ' Set Pekerjaan
                        If IsDBNull(Trow("Pekerjaan")) = False Then pekerjaanPasien = Trow("Pekerjaan")

                        Tlastnew("Nama") = Trow("Nama")
                        Tlastnew("Umur") = Umur(Trow("TglLahir"))
                        Tlastnew("NIK") = Trow("NoNIK")
                        Tlastnew("Pekerjaan") = pekerjaanPasien
                        Tlastnew("Diagnosis") = diagnosaPasien

                        Tdata.Rows.Add(Tlastnew)
                    Next

                    Report.DataSource = Tdata
                    Report.Bands.Item(BandKind.PageHeader).Controls("xrLabelNoDokumen").Text = noDocument

                    ' Akses panel yang sudah ada di dalam band Detail menggunakan index
                    Dim panel As XRPanel = CType(Report.Bands(BandKind.PageHeader).Controls(0), XRPanel)

                    ' Cari panel berdasarkan nama di dalam band Detail
                    Dim PanelAlamat As XRPanel = TryCast(Report.Bands(BandKind.PageHeader).Controls("xrPanelAlamat"), XRPanel)

                    ' Input data label
                    PanelAlamat.Controls("xrLabelAlamat").Text = alamatCompany
                    PanelAlamat.Controls("xrLabelNoTelepon").Text = telpCompany

                    Report.Bands.Item(BandKind.Detail).Controls("xrLabelNoSurat").Text = nomorSurat
                    Report.Bands.Item(BandKind.Detail).Controls("xrLabelKeteranganDetail").Text = keteranganDetail

                    Report.Bands.Item(BandKind.GroupFooter).Controls("xrLabelTgl").Text = namaKota & ", " & tglSurat

                    If Report.Bands.Item(BandKind.GroupFooter).Controls("xrLabelDokter") IsNot Nothing Then
                        Report.Bands.Item(BandKind.GroupFooter).Controls("xrLabelDokter").Text = namaDokter
                        Report.Bands.Item(BandKind.GroupFooter).Controls("xrLabelSIP").Text = "SIP: " & noSIP
                    End If

                    ' Nonaktifkan jika sudah ada master TTD Dokter
                    Report.Bands.Item(BandKind.GroupFooter).Controls("xrPictureBoxTTD").Visible = False

                    ' Add Kop Surat
                    Report.Bands.Item(BandKind.PageHeader).Controls.Add(pictureBoxKopSurat)

                    'Report.RunDesigner()
                    Report.ShowPreview()
                End If
            Else
                MsgBox("Generate surat terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Warning!")
        End Try
    End Sub

    Private Sub ButtonHapusPemeriksaanGeneralisObjektif_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonHapusPemeriksaanGeneralisObjektif.Click
        Try
            If CheckSQL("SELECT * FROM TransaksiDetailGeneralis WHERE NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL") = False Then
                MsgBox("Tidak ada data yang dihapus.", MsgBoxStyle.Exclamation, "Warning!")
            Else
                Dim parameterUpdate As String = ""

                ' Update Data TransaksiDetailGeneralis
                parameterUpdate = "DeletedBy = '" & userInput & "'," & _
                                  "DeletedDate = GETDATE()"

                WriteSQL("UPDATE TransaksiDetailGeneralis SET " & parameterUpdate & " WHERE NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL", 4)

                MsgBox("Data berhasil dihapus.", MsgBoxStyle.Information, "Success!")

                ClearStatusGeneralis()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Warning!")
        End Try
    End Sub

    Private Sub CheckBoxStatusGeneralisStatusLokalis_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxStatusGeneralisStatusLokalis.CheckedChanged
        If CheckBoxStatusGeneralisStatusLokalis.Checked = True Then
            TextBoxStatusGeneralisStatusLokalis.ReadOnly = False
        Else
            TextBoxStatusGeneralisStatusLokalis.ReadOnly = True
            TextBoxStatusGeneralisStatusLokalis.ResetText()
        End If
    End Sub

    Private Sub CheckBoxSignaAktif_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TextBoxSigna1NonRacikan.ResetText()
        TextBoxSigna2NonRacikan.ResetText()
        ComboBoxSatuanSignaNonRacikan.ResetText()

        If CheckBoxSignaAktif.Checked = True Then
            TextBoxSigna1NonRacikan.Enabled = True
            TextBoxSigna2NonRacikan.Enabled = True
            ComboBoxSatuanSignaNonRacikan.Enabled = True
        ElseIf CheckBoxSignaAktif.Checked = False Then
            TextBoxSigna1NonRacikan.Enabled = False
            TextBoxSigna2NonRacikan.Enabled = False
            ComboBoxSatuanSignaNonRacikan.Enabled = False
        End If
    End Sub



    Private Sub WhatsappToApotek()
        Try
            Dim NoWhatsapp As String = "6285655784251"
            Dim TIP_Whatsapp As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='TIP_Whatsapp'")
            Dim TxPDF As String = ""
            Dim filename As String = ""
            Dim parameter As String = ""
            Dim uri As String = ""
            Dim uri_message As String = ""
            Dim StatsSending As String = ""

            Dim message_whatsapp As String = ""

            ' Ganti sesuai kebutuhan
            message_whatsapp = "Sending Berhasil."

            parameter = "{" & _
              """number"" : """ & NoWhatsapp & """," & _
              """mime"" : ""application/pdf""," & _
              """src"" : """"," & _
              """filename"" : """"," & _
              """caption"" : """"," & _
              """thumbnail"" : """"," & _
              """message"" : """ & message_whatsapp & """" & _
             "}"

            uri_message = "http://" & TIP_Whatsapp & ":4444/send"

            SendDataWhatsapp(parameter, uri_message)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ButtonKirimResep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonKirimResep.Click
        If ValidasiKirimResep() = True Then
            ' Update status kirim apotek lokal
            WriteSQL("UPDATE TransaksiObat SET KirimApotekStatus = 1, KirimApotekDate = GETDATE() " & _
                     "WHERE NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL AND KirimApotekStatus = 0", 4)

            SetLabelKirimResep()
            'WhatsappToApotek()

            ' Cek jika penagihan BPJS, maka kirim juga ke PCare
            Dim dtJenis As DataTable = ReadSQL("SELECT JenisPenagihan FROM TransaksiDetail WHERE NoUrut = '" & idTransaksi & "'")
            If dtJenis.Rows.Count > 0 Then
                Dim JenisPenagihan As String = dtJenis.Rows(0)("JenisPenagihan").ToString()
                If JenisPenagihan = "BPJS" Then
                    KirimResepKePCare(idTransaksi)
                End If
            End If

            MsgBox("Resep berhasil terkirim ke Apotek.", MsgBoxStyle.Information, "Success!")
        End If
    End Sub

    Private Sub KirimResepKePCare(ByVal idTransaksi As String)
        Try
            ' Ambil data resep
            Dim dtObat As DataTable = ReadSQL("SELECT * FROM TransaksiObatBPJS WHERE NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL")
            If dtObat.Rows.Count = 0 Then
                MsgBox("Tidak ada resep BPJS yang akan dikirim.", MsgBoxStyle.Exclamation, "Warning")
                Exit Sub
            End If

            Dim noKunjungan As String = ""
            If Not IsDBNull(dtObat.Rows(0)("noKunjungan")) Then
                noKunjungan = dtObat.Rows(0)("noKunjungan").ToString().Trim()
            End If

            If noKunjungan = "" Then
                MsgBox("Nomor Kunjungan BPJS belum ada.", MsgBoxStyle.Exclamation, "Warning")
                Exit Sub
            End If

            ' Endpoint PCare resep
            Dim uriBPJS As String = urlPcare & "obat/kunjungan"

            For Each row As DataRow In dtObat.Rows
                ' siapkan variabel aman
                Dim racikan As String = "false"
                If Not IsDBNull(row("racikan")) AndAlso (row("racikan").ToString() = "1" OrElse row("racikan").ToString().ToLower() = "true") Then
                    racikan = "true"
                End If

                Dim obatDPHO As String = "false"
                If Not IsDBNull(row("obatDPHO")) AndAlso (row("obatDPHO").ToString() = "1" OrElse row("obatDPHO").ToString().ToLower() = "true") Then
                    obatDPHO = "true"
                End If

                Dim kdRacikan As String = "null"
                If Not IsDBNull(row("kdRacikan")) AndAlso row("kdRacikan").ToString().Trim() <> "" Then
                    kdRacikan = """" & row("kdRacikan").ToString() & """"
                End If

                Dim nmObatNonDPHO As String = """" & """" ' default string kosong
                If obatDPHO = "false" Then
                    If Not IsDBNull(row("nmObatNonDPHO")) AndAlso row("nmObatNonDPHO").ToString().Trim() <> "" Then
                        nmObatNonDPHO = """" & row("nmObatNonDPHO").ToString() & """"
                    End If
                End If

                ' siapkan JSON
                Dim parameterResep As String = "{" & _
                    """kdObatSK"": " & row("kdObatSK").ToString() & "," & _
                    """noKunjungan"": """ & row("noKunjungan").ToString() & """," & _
                    """racikan"": " & racikan & "," & _
                    """kdRacikan"": " & kdRacikan & "," & _
                    """obatDPHO"": " & obatDPHO & "," & _
                    """kdObat"": """ & row("kdObat").ToString() & """," & _
                    """signa1"": " & row("signa1").ToString() & "," & _
                    """signa2"": " & row("signa2").ToString() & "," & _
                    """jmlObat"": " & row("jmlObat").ToString() & "," & _
                    """jmlHari"": " & row("jmlPermintaan").ToString() & "," & _
                    """jmlPermintaan"": " & row("jmlPermintaan").ToString() & "," & _
                    """nmObatNonDPHO"": " & nmObatNonDPHO & _
                "}"
                'MsgBox("JSON yang akan dikirim ke PCare:" & vbCrLf & parameterResep, MsgBoxStyle.Information, "TRACE")

                ' kirim request
                Dim jsonString As String = PostDataFromPcare(parameterResep, uriBPJS, "POST")
                'MsgBox("Response BPJS: " & vbCrLf & jsonString)

                ' parse response ke object tunggal
                Dim jObj As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(jsonString)

                Dim codeMetaData As Integer = Convert.ToInt32(jObj("metaData")("code").ToString())
                Dim messageMetaData As String = jObj("metaData")("message").ToString()
                Dim messageResponse As String = ""

                Select Case codeMetaData
                    Case 200, 201, 204
                        Dim kdObatSKValue As String = ""

                        Try
                            If jObj("response") IsNot Nothing Then
                                If jObj("response").Type = Newtonsoft.Json.Linq.JTokenType.Array Then
                                    For Each item As Newtonsoft.Json.Linq.JObject In jObj("response")
                                        Dim field As String = item("field").ToString()
                                        Dim msg As String = item("message").ToString()

                                        If field = "kdObatSK" Then
                                            kdObatSKValue = msg
                                        End If
                                    Next
                                ElseIf jObj("response").Type = Newtonsoft.Json.Linq.JTokenType.Object Then
                                    Dim field As String = jObj("response")("field").ToString()
                                    Dim msg As String = jObj("response")("message").ToString()

                                    If field = "kdObatSK" Then
                                        kdObatSKValue = msg
                                    End If
                                End If
                            End If
                        Catch ex As Exception
                            ' bisa pakai debug trace aja
                            MsgBox("Trace parsing response: " & ex.Message)
                        End Try

                        ' simpan kdObatSK
                        If kdObatSKValue <> "" Then
                            Dim sqlUpdate As String = "UPDATE TransaksiObatBPJS " & _
                                                      "SET kdObatSK = '" & kdObatSKValue & "' " & _
                                                      "WHERE NoTransaksi = '" & idTransaksi & "' " & _
                                                      "AND kdObat = '" & row("kdObat").ToString() & "' " & _
                                                      "AND DeletedDate IS NULL"
                            WriteSQL(sqlUpdate, 4)
                        End If

                        ' notifikasi sukses
                        Dim pesanSukses As String = "Obat berhasil dikirim ke BPJS PCare."
                        If messageResponse <> "" Then
                            pesanSukses &= vbCrLf & "Response: " & messageResponse
                        End If
                        If kdObatSKValue <> "" Then
                            pesanSukses &= vbCrLf & "kdObatSK: " & kdObatSKValue
                        End If
                        MsgBox(pesanSukses, MsgBoxStyle.Information, "Success!")

                    Case Else
                        Dim messageError As String = ""
                        If messageResponse <> "" AndAlso messageMetaData <> "" Then
                            messageError = messageResponse & " (" & messageMetaData & ")"
                        ElseIf messageResponse <> "" Then
                            messageError = messageResponse
                        ElseIf messageMetaData <> "" Then
                            messageError = messageMetaData
                        End If

                        MsgBox("Eror BPJS : " & vbCrLf & messageError, MsgBoxStyle.Exclamation, "Error!")
                        Exit Sub
                End Select
            Next
        Catch ex As Exception
            MsgBox("Terjadi error KirimResepKePCare: " & ex.Message, MsgBoxStyle.Critical, "Error!")
        End Try
    End Sub

    Function ValidasiKirimResep() As Boolean
        ' Validasi apakah ada resep yang akan dikirim
        If CheckSQL("SELECT * FROM TransaksiObat WHERE NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL AND KirimApotekStatus = 0") = False Then
            MsgBox("Gagal. Tidak ada resep yang dikirim.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        Return True
    End Function

    Private Sub SetLabelKirimResep()
        Dim keteranganResep As String = ""
        Dim tblResep As DataTable = ReadSQL("SELECT * FROM TransaksiObat WHERE NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL AND KirimApotekStatus = 0")

        If tblResep.Rows.Count > 0 Then
            keteranganResep = "Note : " & tblResep.Rows.Count & " data resep belum dikirim."
        Else
            keteranganResep = ""
        End If

        LabelKeteranganKirimResep.Text = keteranganResep
    End Sub

    Private Sub TrackBarSkalaNyeriMedik_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBarSkalaNyeriMedik.Scroll
        Dim tblMasterSkalaNyeri As DataTable = ReadSQL("SELECT * FROM MasterSkalaNyeri WHERE Skor = '" & TrackBarSkalaNyeriMedik.Value & "'")
        Dim rowSkalaNyeri As DataRow = tblMasterSkalaNyeri.Rows(0)
        Dim nilaiWarna As String = rowSkalaNyeri("Warna").ToString

        TextBoxSkalaNyeriMedik.BackColor = ColorTranslator.FromHtml(nilaiWarna)
        TextBoxSkalaNyeriMedik.Text = rowSkalaNyeri("Keterangan").ToString
    End Sub

    Private Sub TrackBarSkalaNyeriPemeriksaanAwal_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBarSkalaNyeriPemeriksaanAwal.Scroll
        Dim tblMasterSkalaNyeri As DataTable = ReadSQL("SELECT * FROM MasterSkalaNyeri WHERE Skor = '" & TrackBarSkalaNyeriPemeriksaanAwal.Value & "'")
        Dim rowSkalaNyeri As DataRow = tblMasterSkalaNyeri.Rows(0)
        Dim nilaiWarna As String = rowSkalaNyeri("Warna").ToString

        TextBoxSkalaNyeriPemeriksaanAwal.BackColor = ColorTranslator.FromHtml(nilaiWarna)
        TextBoxSkalaNyeriPemeriksaanAwal.Text = rowSkalaNyeri("Keterangan").ToString
    End Sub

    Private Sub ButtonCetakCatatanObat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCetakCatatanObat.Click
        Try
            Dim pathKopSurat As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'image_path_kop_catatan_obat'")
            Dim noDocument As String = ReadSQLNIK("SELECT StrValue FROM  msconfig WHERE configname = 'NoDocResepObat'")
            Dim alamatCompany As String = ReadSQLNIK("SELECT StrValue FROM  msconfig WHERE configname = 'AlamatCompany'")
            Dim telpCompany As String = ReadSQLNIK("SELECT StrValue FROM  msconfig WHERE configname = 'TelpCompany'")
            Dim tblCatatanObat As DataTable = ReadSQL("SELECT * FROM TransaksiDetailCatatanObat WHERE NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL")

            If tblCatatanObat.Rows.Count > 0 Then
                Dim rowCatatanObat As DataRow = tblCatatanObat.Rows(0)
                Dim tglResep As String = Format(rowCatatanObat("CreatedDate"), "dd") & " " & BulanIndonesia(Format(rowCatatanObat("CreatedDate"), "MM")) & " " & Format(rowCatatanObat("CreatedDate"), "yyyy")

                Report = New XtraReport
                Report = XtraReport.FromFile(Application.StartupPath + "\Reports\Klinik\RekamMedis\ReportCatatanObat.repx", True)

                ' Add Kop Image
                Dim imagePathKopSurat As String = System.IO.Path.Combine(Application.StartupPath, pathKopSurat)
                Dim pictureBoxKopSurat As XRPictureBox = CreateXRPictureBoxReport("Kop Surat", Image.FromFile(imagePathKopSurat), 141, 20, 300, 50)

                Dim Tdata As DataTable = New DataTable
                Tdata = CreateTableCatatanObat()
                Tdata.Rows.Clear()

                If tblsRekamMedis.Rows.Count > 0 Then
                    Dim rowData As DataRow = tblsRekamMedis.Rows(0)

                    For Each Trow As DataRow In tblsRekamMedis.Rows
                        Dim Tlastnew As DataRow = Tdata.NewRow

                        Tlastnew("Nama Dokter") = Trow("NamaDokter")
                        Tlastnew("NoSIP") = ReadSQLNIK("SELECT NoSIP FROM MasterDokter WHERE Nama = '" & Trow("NamaDokter") & "'")
                        Tlastnew("No RM") = Trow("NoRekamMedis")
                        Tlastnew("Nama Pasien") = Trow("Nama")
                        Tlastnew("Alamat/Telp") = Trow("DomisiliAlamat") & "/" & Trow("NoHandphone")
                        Tlastnew("Berat Badan") = ReadSQLNIK("SELECT Berat FROM TransaksiDetailFisik WHERE NoTransaksi = '" & idTransaksi & "'") & " kg"
                        Tlastnew("Tgl Lahir/Usia") = Format(Trow("TglLahir"), "dd") & " " & BulanIndonesia(Format(Trow("TglLahir"), "MM")) & " " & Format(Trow("TglLahir"), "yyyy") & "/" & Umur(Trow("TglLahir"))
                        Tlastnew("Tgl Resep") = tglResep
                        Tlastnew("Poli") = Trow("JenisPoli")
                        Tlastnew("Catatan") = rowCatatanObat("Catatan")

                        Tdata.Rows.Add(Tlastnew)
                    Next

                    Report.DataSource = Tdata
                    Report.Bands.Item(BandKind.PageHeader).Controls("xrLabelNoDokumen").Text = noDocument

                    ' Inisialisasi Panel XtraReport
                    Dim panelAlamat As XRPanel = CType(Report.Bands(BandKind.PageHeader).Controls("xrPanelAlamat"), XRPanel)
                    Dim panelDetailPasien As XRPanel = CType(Report.Bands(BandKind.Detail).Controls("xrPanelDetailPasien"), XRPanel)
                    Dim panelDetailAlergi As XRPanel = CType(Report.Bands(BandKind.Detail).Controls("xrPanelDetailAlergi"), XRPanel)

                    ' Inisialisasi CheckBox XtraReport
                    Dim xrCheckBoxPasienUmum As XRCheckBox = CType(panelDetailPasien.FindControl("xrCheckBoxPasienUmum", True), XRCheckBox)
                    Dim xrCheckBoxPasienBPJS As XRCheckBox = CType(panelDetailPasien.FindControl("xrCheckBoxPasienBPJS", True), XRCheckBox)
                    Dim xrCheckBoxPasienAsuransiLain As XRCheckBox = CType(panelDetailPasien.FindControl("xrCheckBoxPasienAsuransiLain", True), XRCheckBox)
                    Dim xrCheckBoxAlergiObatYa As XRCheckBox = CType(panelDetailPasien.FindControl("xrCheckBoxAlergiObatYa", True), XRCheckBox)
                    Dim xrCheckBoxAlergiObatTidak As XRCheckBox = CType(panelDetailPasien.FindControl("xrCheckBoxAlergiObatTidak", True), XRCheckBox)

                    ' Set Penagihan
                    Dim jenisBayar As String = GetJenisPembayaran(jenisTransaksi, idTransaksi)

                    ' Set CheckBox Jenis Tagihan
                    If jenisBayar = "BPJS" Then
                        xrCheckBoxPasienBPJS.Checked = True
                    ElseIf jenisBayar = "UMUM" Then
                        xrCheckBoxPasienUmum.Checked = True
                    Else
                        xrCheckBoxPasienAsuransiLain.Checked = True
                    End If

                    ' Set Alergi
                    If CheckSQL("SELECT * FROM MasterPasienAlergi WHERE AlergiJenis = 'Obat' AND NoRekamMedis = '" & idPasien & "' AND DeletedDate IS NULL") = True Then
                        xrCheckBoxAlergiObatYa.Checked = True
                        xrCheckBoxAlergiObatTidak.Checked = False
                    Else
                        xrCheckBoxAlergiObatYa.Checked = False
                        xrCheckBoxAlergiObatTidak.Checked = True
                    End If

                    ' Set Label Alamat
                    panelAlamat.Controls("xrLabelAlamat").Text = alamatCompany
                    panelAlamat.Controls("xrLabelNoTelepon").Text = telpCompany

                    ' Add Kop Surat
                    Report.Bands.Item(BandKind.PageHeader).Controls.Add(pictureBoxKopSurat)

                    'Report.RunDesigner()
                    Report.ShowPreview()
                End If
            Else
                MsgBox("Input dan simpan catatan obat terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Warning!")
        End Try
    End Sub

    Function CreateTableCatatanObat() As DataTable
        Dim Thasil As New DataTable

        insertRowToTbls(Thasil, "Typstring", "Nama Dokter")
        insertRowToTbls(Thasil, "Typstring", "NoSIP")
        insertRowToTbls(Thasil, "Typstring", "No RM")
        insertRowToTbls(Thasil, "Typstring", "Nama Pasien")
        insertRowToTbls(Thasil, "Typstring", "Alamat/Telp")
        insertRowToTbls(Thasil, "Typstring", "Berat Badan")
        insertRowToTbls(Thasil, "Typstring", "Tgl Lahir/Usia")
        insertRowToTbls(Thasil, "Typstring", "Tgl Resep")
        insertRowToTbls(Thasil, "Typstring", "Poli")
        insertRowToTbls(Thasil, "Typstring", "Catatan")

        Return Thasil
    End Function

    Private Sub ButtonSimpanCatatanObat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSimpanCatatanObat.Click
        Try
            If ValidasiCatatanObat() = True Then
                If CheckSQL("SELECT * FROM TransaksiDetailCatatanObat WHERE NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL") = False Then
                    ' Insert Data TransaksiDetailCatatanObat
                    WriteSQL("INSERT INTO TransaksiDetailCatatanObat (NoTransaksi, NoRekamMedis, Catatan, CreatedBy, CreatedDate) " & _
                            "VALUES ('" & idTransaksi & "', '" & idPasien & "', '" & TextBoxKeteranganCatatanObat.Text & "', '" & userInput & "', GETDATE())", 4)
                Else
                    Dim parameterUpdate As String = ""

                    ' Update Data TransaksiDetailCatatanObat
                    parameterUpdate = "Catatan = '" & TextBoxKeteranganCatatanObat.Text & "'," & _
                                      "UpdatedBy = '" & userInput & "'," & _
                                      "UpdatedDate = GETDATE()"

                    WriteSQL("UPDATE TransaksiDetailCatatanObat SET " & parameterUpdate & " WHERE NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL", 4)
                End If

                MsgBox("Data Berhasil Disimpan.", MsgBoxStyle.Information, "Success")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Warning!")
        End Try
    End Sub

    Function ValidasiCatatanObat() As Boolean
        ' Validasi apakah ada resep yang akan dikirim
        If TextBoxKeteranganCatatanObat.Text.Trim = "" Or TextBoxKeteranganCatatanObat.Text.Trim = "-" Then
            MsgBox("Gagal. Silahkan isi catatan obat terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        Return True
    End Function

    Private Sub ButtonHapusCatatanObat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonHapusCatatanObat.Click
        If CheckSQL("SELECT * FROM TransaksiDetailCatatanObat WHERE NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL") = True Then
            TextBoxKeteranganCatatanObat.ResetText()

            Dim parameterDelete As String = ""

            ' Delete Data TransaksiDetailCatatanObat
            parameterDelete = "Catatan = '" & TextBoxKeteranganCatatanObat.Text & "'," & _
                              "DeletedBy = '" & userInput & "'," & _
                              "DeletedDate = GETDATE()"

            WriteSQL("UPDATE TransaksiDetailCatatanObat SET " & parameterDelete & " WHERE NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL", 4)

            MsgBox("Data Berhasil Dihapus.", MsgBoxStyle.Information, "Success")
        Else
            MsgBox("Gagal. Tidak ada data catatan obat.", MsgBoxStyle.Exclamation, "Warning!")
        End If
    End Sub

    'Debug
    'Private Sub PreviewInformedConsent(ByRef _idTransaksi As String, ByRef _idTindakan As String)
    '    MsgBox("▶ Memulai PreviewInformedConsent")

    '    Dim tblsInformedConsent As DataTable = ReadSQL("SELECT * FROM InformedConsent WHERE NoTransaksi = '" & _idTransaksi & "' AND TindakanID = '" & _idTindakan & "'")
    '    MsgBox("Jumlah baris hasil query: " & tblsInformedConsent.Rows.Count)

    '    If tblsInformedConsent.Rows.Count > 0 Then
    '        Dim rowData As DataRow = tblsInformedConsent.Rows(0)

    '        MsgBox("Memuat report dari file .repx ...")
    '        Dim reportPath As String = Application.StartupPath + "\Reports\Klinik\RekamMedis\ReportInformedConsent.repx"
    '        If Not IO.File.Exists(reportPath) Then
    '            MsgBox("❌ File report tidak ditemukan: " & reportPath)
    '            Exit Sub
    '        End If

    '        Report = XtraReport.FromFile(reportPath, True)
    '        Report.DataSource = tblsInformedConsent
    '        MsgBox("Report berhasil dimuat & datasource diisi")

    '        ' --- Debug isi data utama ---
    '        MsgBox("Nama Pasien: " & rowData("NamaPasien").ToString())
    '        MsgBox("Nama Penanggung Jawab: " & rowData("NamaPenanggungJawab").ToString())
    '        MsgBox("Nama Dokter: " & rowData("NamaDokter").ToString())

    '        ' --- Debug kontrol di dalam report ---
    '        Try
    '            Dim panelPernyataanPasien As XRPanel = CType(Report.Bands(BandKind.Detail).Controls("xrPanelPernyataan"), XRPanel)
    '            If panelPernyataanPasien Is Nothing Then
    '                MsgBox("❌ xrPanelPernyataan tidak ditemukan di report")
    '            Else
    '                MsgBox("✔ xrPanelPernyataan ditemukan")
    '            End If
    '        Catch ex As Exception
    '            MsgBox("Error akses panel: " & ex.Message)
    '        End Try

    '        ' --- Debug sebelum preview ---
    '        Try
    '            MsgBox("▶ Membuat dokumen report ...")
    '            Report.CreateDocument()
    '            MsgBox("✔ Dokumen report sudah dibuat")

    '            'Gunakan ShowPreview agar tampil
    '            Report.ShowPreview()
    '            MsgBox("✔ Preview report sudah dipanggil")
    '        Catch ex As Exception
    '            MsgBox("❌ Terjadi error saat preview: " & ex.Message)
    '        End Try
    '    Else
    '        MsgBox("Data tidak ditemukan.", MsgBoxStyle.Critical, "Warning!")
    '    End If
    'End Sub

    'NEW PREVIEW
    'Private Sub PreviewInformedConsent(ByRef _idTransaksi As String, ByRef _idTindakan As String)
    '    Dim tblsInformedConsent As DataTable = ReadSQL("SELECT * FROM InformedConsent WHERE NoTransaksi = '" & _idTransaksi & "' AND TindakanID = '" & _idTindakan & "'")

    '    If tblsInformedConsent.Rows.Count > 0 Then
    '        Dim rowData As DataRow = tblsInformedConsent.Rows(0)
    '        Dim reportPath As String = Application.StartupPath + "\Reports\Klinik\RekamMedis\ReportInformedConsent.repx"
    '        If Not IO.File.Exists(reportPath) Then
    '            Exit Sub
    '        End If

    '        Report = XtraReport.FromFile(reportPath, True)
    '        Report.DataSource = tblsInformedConsent

    '        Try
    '            Dim panelPernyataanPasien As XRPanel = CType(Report.Bands(BandKind.Detail).Controls("xrPanelPernyataan"), XRPanel)
    '            If panelPernyataanPasien Is Nothing Then
    '            Else
    '            End If
    '        Catch ex As Exception
    '            MsgBox("Error akses panel: " & ex.Message)
    '        End Try

    '        Try
    '            Report.CreateDocument()

    '            'Gunakan ShowPreview agar tampil
    '            Report.ShowPreview()
    '        Catch ex As Exception
    '            MsgBox("Terjadi error saat preview: " & ex.Message)
    '        End Try
    '    Else
    '        MsgBox("Data tidak ditemukan.", MsgBoxStyle.Critical, "Warning!")
    '    End If
    'End Sub

    'OLD
    Private Sub PreviewInformedConsent(ByRef _idTransaksi As String, ByRef _idTindakan As String)
        Dim tblsInformedConsent As DataTable = ReadSQL("SELECT * FROM InformedConsent WHERE NoTransaksi = '" & _idTransaksi & "' AND TindakanID = '" & _idTindakan & "'")

        If tblsInformedConsent.Rows.Count > 0 Then
            Dim rowData As DataRow = tblsInformedConsent.Rows(0)

            Report = New XtraReport
            Report = XtraReport.FromFile(Application.StartupPath + "\Reports\Klinik\RekamMedis\ReportInformedConsent.repx", True)
            Report.DataSource = tblsInformedConsent

            ' Set Jenis Kelamin Penanggung Jawab
            Dim jenisKelaminPenanggungJawab As String = ""
            If rowData("JenisKelaminPenanggungJawab").ToString = "L" Then
                jenisKelaminPenanggungJawab = "Laki-laki"
            ElseIf rowData("JenisKelaminPenanggungJawab").ToString = "P" Then
                jenisKelaminPenanggungJawab = "Perempuan"
            End If

            ' Set Jenis Kelamin Pasien
            Dim jenisKelaminPasien As String = ""
            If rowData("JenisKelaminPasien").ToString = "L" Then
                jenisKelaminPasien = "Laki-laki"
            ElseIf rowData("JenisKelaminPasien").ToString = "P" Then
                jenisKelaminPasien = "Perempuan"
            End If

            ' Set Hubungan Penanggung Jawab
            Dim hubunganPenanggungJawab As String = ""
            If rowData("HubunganPenanggungJawab") = "Pasien Sendiri" Then
                hubunganPenanggungJawab = "saya"
            Else
                hubunganPenanggungJawab = rowData("HubunganPenanggungJawab") & " saya"
            End If

            ' Set Lokasi & Waktu
            Dim waktuDariDatabase As DateTime = rowData("TglTransaksi")

            Dim tanggal As String = waktuDariDatabase.ToString("dd-MM-yyyy")
            Dim jam As String = waktuDariDatabase.ToString("HH:mm:ss")
            Dim waktuInformedConsent As String = rowData("KeteranganLokasi") & ", tanggal " & tanggal & " pukul " & jam

            ' Set Field Penyataan Pasien
            Dim panelPernyataanPasien As XRPanel = CType(Report.Bands(BandKind.Detail).Controls("xrPanelPernyataan"), XRPanel)
            Dim panelPersetujuanPasien As XRPanel = CType(Report.Bands(BandKind.Detail).Controls("xrPanelPersetujuan"), XRPanel)
            Dim panelPenolakanPasien As XRPanel = CType(Report.Bands(BandKind.Detail).Controls("xrPanelPenolakan"), XRPanel)

            Dim stringPenyataanPasien As String = "Yang bertandatangan di bawah ini, saya, nama " & rowData("NamaPenanggungJawab") & ", umur " & rowData("UmurPenanggungJawab") & " tahun, " & jenisKelaminPenanggungJawab & ", alamat " & rowData("AlamatPenanggungJawab") & _
                                                  " dengan ini menyatakan persetujuan untuk dilakukannya tindakan " & rowData("KeteranganTindakan") & _
                                                  " terhadap " & hubunganPenanggungJawab & " bernama " & rowData("NamaPasien") & ", umur " & rowData("UmurPasien") & " tahun, " & jenisKelaminPasien & ", alamat " & rowData("AlamatPasien")
            panelPernyataanPasien.Controls("xrLabelPernyataanPasien").Text = stringPenyataanPasien
            panelPersetujuanPasien.Controls("xrLabelTanggalPersetujuanPasien").Text = waktuInformedConsent
            panelPenolakanPasien.Controls("xrLabelTanggalPenolakanPasien").Text = waktuInformedConsent

            '# Set Signature Page 1
            Dim xrTablePage1 As XRTable = CType(Report.Bands(BandKind.Detail).Controls("xrTableSignaturePage1"), XRTable)

            Dim rowDokterSignatureTablePage1 As XRTableRow = CType(xrTablePage1.Controls("xrTableRowDokterSignature"), XRTableRow)
            Dim cellDokterSignatureTablePage1 As XRTableCell = CType(rowDokterSignatureTablePage1.Controls("xrTableCellDokterSignature"), XRTableCell)
            Dim panelDokterSignatureTablePage1 As XRPanel = CType(cellDokterSignatureTablePage1.Controls("xrPanelDokterSignature"), XRPanel)

            Dim rowPasienSignatureTablePage1 As XRTableRow = CType(xrTablePage1.Controls("xrTableRowPasienSignature"), XRTableRow)
            Dim cellPasienSignatureTablePage1 As XRTableCell = CType(rowPasienSignatureTablePage1.Controls("xrTableCellPasienSignature"), XRTableCell)
            Dim panelPasienSignatureTablePage1 As XRPanel = CType(cellPasienSignatureTablePage1.Controls("xrPanelPasienSignature"), XRPanel)

            ' Signature Dokter
            Dim pictureBoxDokterSignaturePage1 As XRPictureBox = CreateXRPictureBoxReportFromBase64(rowData("SignatureDokter1"), "DokterSignaturePage1", 5, 20, 125, 50)
            panelDokterSignatureTablePage1.Controls.Add(pictureBoxDokterSignaturePage1)

            ' Signature Pasien
            Dim pictureBoxPasienSignaturePage1 As XRPictureBox = CreateXRPictureBoxReportFromBase64(rowData("SignaturePasien1"), "PasienSignaturePage1", 5, 20, 125, 50)
            panelPasienSignatureTablePage1.Controls.Add(pictureBoxPasienSignaturePage1)

            '# Set Signature Page 2
            Dim panelSignaturePersetujuanDokter As XRPanel = CType(panelPersetujuanPasien.Controls("xrPanelSignaturePersetujuanDokter"), XRPanel)
            Dim panelSignaturePersetujuanPasien As XRPanel = CType(panelPersetujuanPasien.Controls("xrPanelSignaturePersetujuanPasien"), XRPanel)
            Dim panelSignaturePersetujuanPerawat As XRPanel = CType(panelPersetujuanPasien.Controls("xrPanelSignaturePersetujuanPerawat"), XRPanel)
            Dim panelSignaturePersetujuanKeluarga As XRPanel = CType(panelPersetujuanPasien.Controls("xrPanelSignaturePersetujuanKeluarga"), XRPanel)

            ' Signature Dokter
            Dim pictureBoxSignaturePersetujuanDokter As XRPictureBox = CreateXRPictureBoxReportFromBase64(rowData("SignatureDokter2"), "SignaturePersetujuanDokter", 5, 20, 125, 50)
            panelSignaturePersetujuanDokter.Controls.Add(pictureBoxSignaturePersetujuanDokter)
            panelSignaturePersetujuanDokter.Controls("xrLabelSignaturePersetujuanDokter").Text = "( " & rowData("NamaDokter") & " )"

            ' Signature Pasien
            Dim pictureBoxSignaturePersetujuanPasien As XRPictureBox = CreateXRPictureBoxReportFromBase64(rowData("SignaturePasien2"), "SignaturePersetujuanPasien", 5, 20, 125, 50)
            panelSignaturePersetujuanPasien.Controls.Add(pictureBoxSignaturePersetujuanPasien)
            panelSignaturePersetujuanPasien.Controls("xrLabelSignaturePersetujuanPasien").Text = "( " & rowData("NamaPenanggungJawab") & " )"

            ' Signature Perawat
            Dim pictureBoxSignaturePersetujuanPerawat As XRPictureBox = CreateXRPictureBoxReportFromBase64(rowData("SignaturePerawat"), "SignaturePersetujuanPerawat", 5, 20, 125, 50)
            panelSignaturePersetujuanPerawat.Controls.Add(pictureBoxSignaturePersetujuanPerawat)
            panelSignaturePersetujuanPerawat.Controls("xrLabelSignaturePersetujuanPerawat").Text = "( " & rowData("NamaPerawat") & " )"

            ' Signature Keluarga
            If rowData("StatusSaksiPasien") = True Then
                Dim pictureBoxSignaturePersetujuanKeluarga As XRPictureBox = CreateXRPictureBoxReportFromBase64(rowData("SignatureKeluarga"), "SignaturePersetujuanKeluarga", 5, 20, 125, 50)
                panelSignaturePersetujuanKeluarga.Controls.Add(pictureBoxSignaturePersetujuanKeluarga)
                panelSignaturePersetujuanKeluarga.Controls("xrLabelSignaturePersetujuanKeluarga").Text = "( " & rowData("NamaSaksiPasien") & " )"
            End If
            Try
                Report.CreateDocument()
                'Report.RunDesigner()
                Report.ShowPreview()
            Catch ex As Exception
                MsgBox("Terjadi error saat preview: " & ex.Message)
            End Try
        Else
            MsgBox("Data tidak ditemukan.", MsgBoxStyle.Critical, "Warning!")
        End If
    End Sub

    Private Sub HapusPaketReguler(ByVal kodeVoucher As String)
        ' Soft delete 1 data TransaksiPoliDetail terkait Paket Reguler
        WriteSQL("WITH CTE AS (" & _
                 "SELECT TOP 1 * FROM TransaksiPoliDetail " & _
                 "WHERE KodeVoucher = '" & kodeVoucher & "' " & _
                 "AND CONVERT(DATE, TransaksiTime) = CONVERT(DATE, GETDATE()) " & _
                 "AND DeletedDate IS NULL " & _
                 "ORDER BY TransaksiTime DESC) " & _
                 "UPDATE CTE SET DeletedBy = '" & userInput & "', DeletedDate = GETDATE()", 4)

        ' Tambahkan kembali kuota paket
        WriteSQL("UPDATE TransaksiPaketTindakan SET Kuota = ISNULL(Kuota, 0) + 1 " & _
             "WHERE KodeVoucher = '" & kodeVoucher & "'", 4)

        ' Soft delete dari LogPenggunaanPaket
        WriteSQL("UPDATE LogPenggunaanPaket SET DeletedBy = '" & userInput & "', DeletedDate = GETDATE() " & _
                 "WHERE ID IN (SELECT TOP 1 ID FROM LogPenggunaanPaket " & _
                 "WHERE KodeVoucher = '" & kodeVoucher & "' AND NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL " & _
                 "ORDER BY CreatedDate DESC)", 4)
    End Sub

    Private Sub HapusPaketPerTindakan(ByVal kodeVoucher As String, ByVal tindakanID As String)
        ' Soft delete 1 tindakan dari TransaksiPoliDetail
        WriteSQL("WITH CTE AS (" & _
                 "SELECT TOP 1 * FROM TransaksiPoliDetail " & _
                 "WHERE KodeVoucher = '" & kodeVoucher & "' AND TindakanID = '" & tindakanID & "' " & _
                 "AND CONVERT(DATE, TransaksiTime) = CONVERT(DATE, GETDATE()) " & _
                 "AND DeletedDate IS NULL " & _
                 "ORDER BY TransaksiTime DESC) " & _
                 "UPDATE CTE SET DeletedBy = '" & userInput & "', DeletedDate = GETDATE()", 4)

        ' Tambahkan kembali kuota tindakan
        WriteSQL("UPDATE TransaksiPaketTindakanDetail SET KuotaTindakan = ISNULL(KuotaTindakan, 0) + 1 " & _
             "WHERE KodeVoucher = '" & kodeVoucher & "' AND TindakanID = '" & tindakanID & "'", 4)

        ' Soft delete dari LogPenggunaanPaket
        WriteSQL("UPDATE LogPenggunaanPaket SET DeletedBy = '" & userInput & "', DeletedDate = GETDATE() " & _
                 "WHERE ID IN (SELECT TOP 1 ID FROM LogPenggunaanPaket " & _
                 "WHERE KodeVoucher = '" & kodeVoucher & "' AND TindakanID = '" & tindakanID & "' AND NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL " & _
                 "ORDER BY CreatedDate DESC)", 4)
    End Sub


    Private Sub HapusTindakanPaket(ByVal idTindakanDetailObj As Object, ByVal namaTindakan As String, ByVal kodeVoucher As String)
        If Not IsDBNull(idTindakanDetailObj) AndAlso idTindakanDetailObj IsNot Nothing AndAlso idTindakanDetailObj.ToString() <> "" Then
            ' Hapus berdasarkan ID Detail
            Dim idTindakanDetail As String = idTindakanDetailObj.ToString()
            If jenisTransaksi = "UMUM" Or jenisTransaksi = "POLI" Then
                'WriteSQL("UPDATE TransaksiPoliDetail SET DeletedBy = '" & userInput & "', DeletedDate = GETDATE() " & _
                '     "WHERE TransPoliIDDetail = '" & idTindakanDetail & "' AND DeletedDate IS NULL", 4)
                Dim queryTindakanID As String = "SELECT TindakanID FROM TransaksiPoliDetail " & _
                                      "WHERE TransPoliIDDetail = '" & idTindakanDetail & "' AND DeletedDate IS NULL"
                Dim tindakanID As String = ReadSQLNIK(queryTindakanID)

                If Not String.IsNullOrEmpty(tindakanID) Then
                    Dim tindakanNama As String = "SELECT NamaTindakan FROM MasterTindakan WHERE TindakanID = '" & tindakanID & "'"
                    Dim tindakan As String = ReadSQLNIK(tindakanNama)

                    If Not String.IsNullOrEmpty(tindakanNama) Then
                        Dim queryReminderID As String = "SELECT TOP 1 ReminderID FROM LogReminderPasien " & _
                                                "WHERE Keperluan LIKE '%" & tindakan.Replace("'", "''") & "%' " & _
                                                "AND DeletedDate IS NULL AND CONVERT(DATE, Tanggal) >= CONVERT(DATE, GETDATE()) " & _
                                                "ORDER BY CreatedDate DESC"
                        Dim dtReminder As DataTable = ReadSQL(queryReminderID)

                        If dtReminder.Rows.Count > 0 Then
                            Dim reminderID As String = dtReminder.Rows(0)("ReminderID").ToString()
                            'MsgBox("Reminder Ditemukan!" & vbCrLf & _
                            '       "ReminderID: " & dtReminder.Rows(0)("ReminderID").ToString() & vbCrLf & _
                            '       "Total Baris: " & dtReminder.Rows.Count.ToString())
                            Dim queryDeleteReminder As String = "UPDATE LogReminderPasien SET Status = 'CANCLE', DeletedBy = '" & userInput.Replace("'", "''") & "', DeletedDate = GETDATE() " & _
                                       "WHERE ReminderID = '" & reminderID & "' AND DeletedDate IS NULL"
                            WriteSQL(queryDeleteReminder, 4)
                        Else
                            'MsgBox("Tidak ada reminder yang ditemukan." & vbCrLf & _
                            '       "Query dijalankan: " & vbCrLf & queryReminderID)
                        End If
                    Else
                        MsgBox("NamaTindakan tidak ditemukan untuk TindakanID: " & tindakanID)
                    End If
                Else
                    MsgBox("TindakanID tidak ditemukan untuk TransPoliIDDetail: " & idTindakanDetail)
                End If
                WriteSQL("UPDATE TransaksiPoliDetail SET DeletedBy = '" & userInput.Replace("'", "''") & "', DeletedDate = GETDATE() " & _
                         "WHERE TransPoliIDDetail = '" & idTindakanDetail.Replace("'", "''") & "' AND DeletedDate IS NULL", 4)
            ElseIf jenisTransaksi = "GIGI" Then
                WriteSQL("UPDATE TransaksiGigiDetail SET DeletedBy = '" & userInput & "', DeletedDate = GETDATE() " & _
                     "WHERE TransGigiIDDetail = '" & idTindakanDetail & "' AND DeletedDate IS NULL", 4)
            End If

        ElseIf kodeVoucher.Trim() <> "" Then
            ' Ambil TindakanID dari Log Penggunaan
            Dim tindakanID As String = ReadSQLNIK("SELECT TOP 1 TindakanID FROM LogPenggunaanPaket WHERE KodeVoucher = '" & kodeVoucher & "' AND NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL ORDER BY CreatedDate DESC")

            ' Cek apakah PAKET REGULER
            Dim queryCek As String = _
             "SELECT CASE WHEN EXISTS (" & vbCrLf & _
             "    SELECT 1 FROM LogPenggunaanPaket logpaket " & vbCrLf & _
             "    INNER JOIN TransaksiPaketTindakan tpt ON logpaket.KodeVoucher = tpt.KodeVoucher AND logpaket.PaketID = tpt.PaketID " & vbCrLf & _
             "    WHERE logpaket.KodeVoucher = '" & kodeVoucher & "' " & vbCrLf & _
             "    AND logpaket.NoTransaksi = '" & idTransaksi & "' " & vbCrLf & _
             "    AND UPPER(tpt.JenisPaket) = 'PAKET REGULER' " & vbCrLf & _
             "    AND logpaket.DeletedDate IS NULL" & vbCrLf & _
             ") THEN 1 ELSE 0 END"

            Dim isPaketReguler As Boolean = CBool(ReadSQLNIK(queryCek))

            If isPaketReguler Then
                HapusPaketReguler(kodeVoucher)
            ElseIf tindakanID <> "" Then
                HapusPaketPerTindakan(kodeVoucher, tindakanID)
            End If
        End If
    End Sub

    'Debug
    'Private Sub DataGridViewTindakan_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewTindakan.CellContentClick
    '    MsgBox("▶ Event CellContentClick dipanggil. RowIndex=" & e.RowIndex & ", ColumnIndex=" & e.ColumnIndex)

    '    Dim dataGridView As DataGridView = DirectCast(sender, DataGridView)

    '    If e.RowIndex >= 0 Then
    '        MsgBox("✔ Klik terjadi pada row valid: " & e.RowIndex)

    '        If dataGridView.Columns.Contains("ButtonDetail") Then
    '            MsgBox("✔ Kolom ButtonDetail ditemukan di DataGridView")

    '            ' Cek klik kolom ButtonDetail
    '            If e.ColumnIndex = dataGridView.Columns("ButtonDetail").Index Then
    '                MsgBox("▶ Klik pada kolom ButtonDetail")

    '                If CheckingDeleteTindakan() = True Then
    '                    MsgBox("✔ CheckingDeleteTindakan() = True")

    '                    Dim idTindakanDetailObj As Object = dataGridView.Rows(e.RowIndex).Cells("ColumnID").Value
    '                    Dim namaTindakan As String = dataGridView.Rows(e.RowIndex).Cells("ColumnNamaTindakan").Value.ToString()
    '                    Dim kodeVoucher As String = If(IsDBNull(dataGridView.Rows(e.RowIndex).Cells("ColumnKodeVoucher").Value), "", dataGridView.Rows(e.RowIndex).Cells("ColumnKodeVoucher").Value.ToString())

    '                    MsgBox("Data Row: " & vbCrLf & _
    '                           "ID Tindakan Detail: " & If(idTindakanDetailObj Is Nothing, "(NULL)", idTindakanDetailObj.ToString()) & vbCrLf & _
    '                           "Nama Tindakan: " & namaTindakan & vbCrLf & _
    '                           "Kode Voucher: " & kodeVoucher)

    '                    Dim resultNonRacikan As DialogResult = MessageBox.Show("Apakah Anda yakin ingin menghapus tindakan " & namaTindakan & "?", "Validasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    '                    If resultNonRacikan = DialogResult.Yes Then
    '                        MsgBox("▶ User memilih YA untuk hapus tindakan")

    '                        HapusTindakanPaket(idTindakanDetailObj, namaTindakan, kodeVoucher)
    '                        MsgBox("✔ Tindakan : " & namaTindakan & " berhasil dihapus.")
    '                    Else
    '                        MsgBox("❌ User memilih TIDAK, batal hapus")
    '                    End If

    '                    SaveDetailTindakan()
    '                Else
    '                    MsgBox("❌ CheckingDeleteTindakan() = False")
    '                End If

    '                ' Refresh grid
    '                MsgBox("▶ Refresh Grid Tindakan")
    '                LoadGridTindakanPoli()

    '            ElseIf e.ColumnIndex = dataGridView.Columns("ButtonInformedConsent").Index Then
    '                MsgBox("▶ Klik pada kolom ButtonInformedConsent")

    '                Dim idTindakan As String = dataGridView.Rows(e.RowIndex).Cells("ColumnTindakanID").Value.ToString()
    '                MsgBox("Memanggil PreviewInformedConsent untuk ID Tindakan: " & idTindakan & " | NoTransaksi: " & idTransaksi)

    '                PreviewInformedConsent(idTransaksi, idTindakan)
    '            Else
    '                MsgBox("Kolom lain diklik, bukan ButtonDetail atau ButtonInformedConsent")
    '            End If
    '        Else
    '            MsgBox("❌ Kolom ButtonDetail tidak ada di DataGridView")
    '        End If
    '    Else
    '        MsgBox("❌ Klik terjadi pada header / row invalid (RowIndex < 0)")
    '    End If
    'End Sub

    'NEW
    Private Sub DataGridViewTindakan_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewTindakan.CellContentClick
        Dim dataGridView As DataGridView = DirectCast(sender, DataGridView)

        If e.RowIndex >= 0 Then
            If dataGridView.Columns.Contains("ButtonDetail") Then
                ' Klik kolom ButtonDetail
                If e.ColumnIndex = dataGridView.Columns("ButtonDetail").Index Then
                    If CheckingDeleteTindakan() = True Then
                        Dim idTindakanDetailObj As Object = dataGridView.Rows(e.RowIndex).Cells("ColumnID").Value
                        Dim namaTindakan As String = dataGridView.Rows(e.RowIndex).Cells("ColumnNamaTindakan").Value.ToString()
                        Dim kodeVoucher As String = If(IsDBNull(dataGridView.Rows(e.RowIndex).Cells("ColumnKodeVoucher").Value), "", dataGridView.Rows(e.RowIndex).Cells("ColumnKodeVoucher").Value.ToString())

                        Dim resultNonRacikan As DialogResult = MessageBox.Show("Apakah Anda yakin ingin menghapus tindakan " & namaTindakan & "?", "Validasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                        If resultNonRacikan = DialogResult.Yes Then
                            HapusTindakanPaket(idTindakanDetailObj, namaTindakan, kodeVoucher)
                            MsgBox("Tindakan : " & namaTindakan & " berhasil dihapus.", MsgBoxStyle.Information, "Success!")
                        End If

                        SaveDetailTindakan()
                    End If

                    ' Refresh Grid
                    LoadGridTindakanPoli()

                    ' Klik kolom ButtonInformedConsent
                ElseIf e.ColumnIndex = dataGridView.Columns("ButtonInformedConsent").Index Then
                    Dim idTindakan As String = dataGridView.Rows(e.RowIndex).Cells("ColumnTindakanID").Value.ToString()
                    PreviewInformedConsent(idTransaksi, idTindakan)
                End If
            End If
        End If
    End Sub

    'OLD
    'Private Sub DataGridViewTindakan_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewTindakan.CellContentClick
    '    'Dim colName As String = DataGridViewTindakan.Columns(e.ColumnIndex).Name

    '    'If colName = "ButtonDetail" Then
    '    '    MsgBox("Delete")
    '    'ElseIf colName = "ButtonInformedConsent" Then
    '    '    MsgBox("Informed Consent")
    '    'End If

    '    Dim dataGridView As DataGridView = DirectCast(sender, DataGridView)

    '    If e.RowIndex >= 0 Then
    '        If dataGridView.Columns.Contains("ButtonDetail") Then
    '            If e.ColumnIndex = dataGridView.Columns("ButtonDetail").Index Then
    '                If CheckingDeleteTindakan() = True Then
    '                    Dim idTindakanDetailObj As Object = dataGridView.Rows(e.RowIndex).Cells("ColumnID").Value
    '                    Dim namaTindakan As String = dataGridView.Rows(e.RowIndex).Cells("ColumnNamaTindakan").Value.ToString()
    '                    Dim kodeVoucher As String = If(IsDBNull(dataGridView.Rows(e.RowIndex).Cells("ColumnKodeVoucher").Value), "", dataGridView.Rows(e.RowIndex).Cells("ColumnKodeVoucher").Value.ToString())

    '                    Dim resultNonRacikan As DialogResult = MessageBox.Show("Apakah Anda yakin ingin menghapus tindakan " & namaTindakan & "?", "Validasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    '                    If resultNonRacikan = DialogResult.Yes Then

    '                        'If Not IsDBNull(idTindakanDetailObj) AndAlso idTindakanDetailObj IsNot Nothing AndAlso idTindakanDetailObj.ToString() <> "" Then
    '                        '    ' Jika ID ada → hapus dari TransaksiPoliDetail / TransaksiGigiDetail
    '                        '    Dim idTindakanDetail As String = idTindakanDetailObj.ToString()
    '                        '    If jenisTransaksi = "UMUM" Or jenisTransaksi = "POLI" Then
    '                        '        WriteSQL("UPDATE TransaksiPoliDetail SET DeletedBy = '" & userInput & "', DeletedDate = GETDATE() WHERE TransPoliIDDetail = '" & idTindakanDetail & "' AND DeletedDate IS NULL", 4)
    '                        '    ElseIf jenisTransaksi = "GIGI" Then
    '                        '        WriteSQL("UPDATE TransaksiGigiDetail SET DeletedBy = '" & userInput & "', DeletedDate = GETDATE() WHERE TransGigiIDDetail = '" & idTindakanDetail & "' AND DeletedDate IS NULL", 4)
    '                        '    End If
    '                        'ElseIf kodeVoucher <> "" Then
    '                        '    ' Jika ID NULL dan KodeVoucher ada → soft delete dari LogPenggunaanPaket dan tambah kuota
    '                        '    WriteSQL("UPDATE LogPenggunaanPaket SET DeletedBy = 'Admin', DeletedDate = GETDATE() WHERE ID IN (" & _
    '                        '            "SELECT TOP 1 ID FROM LogPenggunaanPaket WHERE KodeVoucher = '" & kodeVoucher & "' AND NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL ORDER BY CreatedDate DESC)", 4)
    '                        '    WriteSQL("UPDATE TransaksiPaketTindakan SET Kuota = ISNULL(Kuota, 0) + 1 WHERE KodeVoucher = '" & kodeVoucher & "'", 4)
    '                        '    WriteSQL("UPDATE TransaksiPoliDetail " & _
    '                        '          "SET DeletedBy = '" & userInput & "', DeletedDate = GETDATE() " & _
    '                        '          "WHERE TransPoliID IN (SELECT TransPoliID FROM TransaksiPoli WHERE NoUrut = '" & idTransaksi & "') " & _
    '                        '          "AND KodeVoucher = '" & kodeVoucher & "' " & _
    '                        '          "AND CONVERT(DATE, transaksitime) = CONVERT(DATE, GETDATE()) " & _
    '                        '          "AND DeletedDate IS NULL", 4)
    '                        'End If

    '                        'If Not IsDBNull(idTindakanDetailObj) AndAlso idTindakanDetailObj IsNot Nothing AndAlso idTindakanDetailObj.ToString() <> "" Then
    '                        '    ' Jika ID ada → hapus dari TransaksiPoliDetail / TransaksiGigiDetail
    '                        '    Dim idTindakanDetail As String = idTindakanDetailObj.ToString()
    '                        '    If jenisTransaksi = "UMUM" Or jenisTransaksi = "POLI" Then
    '                        '        WriteSQL("UPDATE TransaksiPoliDetail SET DeletedBy = '" & userInput & "', DeletedDate = GETDATE() " & _
    '                        '                 "WHERE TransPoliIDDetail = '" & idTindakanDetail & "' AND DeletedDate IS NULL", 4)
    '                        '    ElseIf jenisTransaksi = "GIGI" Then
    '                        '        WriteSQL("UPDATE TransaksiGigiDetail SET DeletedBy = '" & userInput & "', DeletedDate = GETDATE() " & _
    '                        '                 "WHERE TransGigiIDDetail = '" & idTindakanDetail & "' AND DeletedDate IS NULL", 4)
    '                        '    End If

    '                        'ElseIf kodeVoucher <> "" Then
    '                        '    ' Jika ID NULL dan KodeVoucher ada → soft delete dari LogPenggunaanPaket dan tambah kuota
    '                        '    ' Ambil TindakanID yang digunakan
    '                        '    Dim tindakanID As String = ReadSQLNIK("SELECT TOP 1 TindakanID FROM LogPenggunaanPaket WHERE KodeVoucher = '" & kodeVoucher & "' AND NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL ORDER BY CreatedDate DESC")

    '                        '    ' Soft delete dari LogPenggunaanPaket
    '                        '    WriteSQL("UPDATE LogPenggunaanPaket SET DeletedBy = 'Admin', DeletedDate = GETDATE() " & _
    '                        '             "WHERE ID IN (" & _
    '                        '             "SELECT TOP 1 ID FROM LogPenggunaanPaket " & _
    '                        '             "WHERE KodeVoucher = '" & kodeVoucher & "' AND NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL " & _
    '                        '             "ORDER BY CreatedDate DESC)", 4)

    '                        '    ' Tambahkan kuota kembali ke TransaksiPaketTindakanDetail jika TindakanID ditemukan
    '                        '    If tindakanID <> "" Then
    '                        '        WriteSQL("UPDATE TransaksiPaketTindakanDetail SET KuotaTindakan = ISNULL(KuotaTindakan, 0) + 1 " & _
    '                        '                 "WHERE KodeVoucher = '" & kodeVoucher & "' AND TindakanID = '" & tindakanID & "'", 4)
    '                        '    End If

    '                        '    ' Hapus juga dari TransaksiPoliDetail berdasarkan KodeVoucher + Tanggal Hari Ini
    '                        '    WriteSQL("UPDATE TransaksiPoliDetail SET DeletedBy = '" & userInput & "', DeletedDate = GETDATE() " & _
    '                        '             "WHERE TransPoliID IN (SELECT TransPoliID FROM TransaksiPoli WHERE NoUrut = '" & idTransaksi & "') " & _
    '                        '             "AND KodeVoucher = '" & kodeVoucher & "' " & _
    '                        '             "AND CONVERT(DATE, transaksitime) = CONVERT(DATE, GETDATE()) " & _
    '                        '             "AND DeletedDate IS NULL", 4)

    '                        '    ' Cek apakah ini adalah paket reguler berdasarkan TindakanID = 0
    '                        '    Dim isPaketReguler As Boolean = CBool(ReadSQLNIK("SELECT CASE WHEN EXISTS (" & _
    '                        '        "SELECT 1 FROM TransaksiPoliDetail " & _
    '                        '        "WHERE KodeVoucher = '" & kodeVoucher & "' " & _
    '                        '        "AND CONVERT(DATE, transaksitime) = CONVERT(DATE, GETDATE()) " & _
    '                        '        "AND DeletedDate IS NULL AND TindakanID = '0') THEN 1 ELSE 0 END"))

    '                        '    If isPaketReguler Then
    '                        '        ' Tambahkan kuota kembali ke TransaksiPaketTindakan
    '                        '        WriteSQL("UPDATE TransaksiPaketTindakan SET Kuota = ISNULL(Kuota, 0) + 1 WHERE KodeVoucher = '" & kodeVoucher & "'", 4)
    '                        '    End If

    '                        HapusTindakanPaket(idTindakanDetailObj, namaTindakan, kodeVoucher)
    '                    End If
    '                    MsgBox("Tindakan : " & namaTindakan & " berhasil dihapus.", MsgBoxStyle.Information, "Success!")
    '                End If

    '                SaveDetailTindakan()
    '            End If

    '            ' Refresh Grid
    '            LoadGridTindakanPoli()

    '        ElseIf e.ColumnIndex = dataGridView.Columns("ButtonInformedConsent").Index Then
    '            Dim idTindakan As String = dataGridView.Rows(e.RowIndex).Cells("ColumnTindakanID").Value.ToString()
    '            PreviewInformedConsent(idTransaksi, idTindakan)
    '        End If
    '    End If
    'End Sub

    Private Sub ButtonGenerateSuratKeteranganBerobat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGenerateSuratKeteranganBerobat.Click
        Try
            If ValidasiInputSuratKeterangan("SURAT KETERANGAN BEROBAT") = True Then
                If TextBoxNoSuratBerobat.Text = "" Then
                    ' Insert Data SuratKeteranganBerobat
                    If tblsRekamMedis.Rows.Count > 0 Then
                        Dim rowData As DataRow = tblsRekamMedis.Rows(0)

                        Dim tglSekarang As String = Format(DateAndTime.Now, "dd") & " " & BulanIndonesia(Format(DateAndTime.Now, "MM")) & " " & Format(DateAndTime.Now, "yyyy")

                        ' Get Nomor Surat
                        Dim nomorSurat As String = GenerateNomorSurat("SURAT KETERANGAN BEROBAT")

                        ' Insert data ke SuratKeteranganBerobat
                        WriteSQL("INSERT INTO SuratKeteranganBerobat (NoTransaksi, NoRekamMedis, NoSurat, TanggalSurat, DokterID, DokterNama, Diagnosa, CreatedBy, CreatedDate) " & _
                                "VALUES ('" & idTransaksi & "', '" & idPasien & "', '" & nomorSurat & "', GETDATE(), '" & rowData("KodeDokter") & "', '" & rowData("NamaDokter") & "', '" & TextBoxDiagnosaSuratBerobat.Text & "', '" & userInput & "', GETDATE())", 4)

                        ' Set Nomor Surat
                        TextBoxNoSuratBerobat.Text = nomorSurat
                    End If
                ElseIf TextBoxNoSuratBerobat.Text <> "" Then
                    Dim parameterUpdate As String = ""

                    ' Update Data SuratKeteranganBerobat
                    parameterUpdate = "Diagnosa = '" & TextBoxDiagnosaSuratBerobat.Text & "'," & _
                                      "UpdatedBy = '" & userInput & "'," & _
                                      "UpdatedDate = GETDATE()"

                    WriteSQL("UPDATE SuratKeteranganBerobat SET " & parameterUpdate & " WHERE NoTransaksi = '" & idTransaksi & "'", 4)
                End If

                MsgBox("Data Berhasil Disimpan.", MsgBoxStyle.Information, "Success")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub ButtonCetakSuratKeteranganBerobat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCetakSuratKeteranganBerobat.Click
        Try
            ' Set No Dokumen
            Dim noDocument As String = ReadSQLNIK("SELECT NomorDokumen FROM MasterDokumen WHERE NamaDokumen = 'Surat Keterangan Berobat'")

            ' Set Path Kop Surat
            Dim pathKopSurat As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'image_path_kop_surat_keterangan'")

            ' Set Alamat & No Telpon
            Dim namaKota As String = ReadSQLNIK("SELECT StrValue FROM  msconfig WHERE configname = 'Kota'")
            Dim alamatCompany As String = ReadSQLNIK("SELECT StrValue FROM  msconfig WHERE configname = 'AlamatCompany'")
            Dim telpCompany As String = ReadSQLNIK("SELECT StrValue FROM  msconfig WHERE configname = 'TelpCompany'")

            ' Set Data Surat Keterangan
            Dim tblSuratKeterangan As DataTable = ReadSQL("SELECT * FROM SuratKeteranganBerobat WHERE NoTransaksi = '" & idTransaksi & "'")

            If tblSuratKeterangan.Rows.Count > 0 Then
                Dim rowSurat As DataRow = tblSuratKeterangan.Rows(0)

                Report = New XtraReport
                Report = XtraReport.FromFile(Application.StartupPath + "\Reports\Klinik\SuratKeterangan\SuratKeteranganBerobat.repx", True)

                ' Add Kop Image
                Dim imagePathKopSurat As String = System.IO.Path.Combine(Application.StartupPath, pathKopSurat)
                Dim pictureBoxKopSurat As XRPictureBox = CreateXRPictureBoxReport("Kop Surat", Image.FromFile(imagePathKopSurat), 87, 33, 408, 71)

                Dim Tdata As DataTable = New DataTable
                Tdata = CreateTableSuratKeterangan()
                Tdata.Rows.Clear()

                If tblsRekamMedis.Rows.Count > 0 Then
                    Dim rowData As DataRow = tblsRekamMedis.Rows(0)

                    Dim tglSuratDate As DateTime = rowSurat("TanggalSurat")
                    Dim culture As System.Globalization.CultureInfo = New System.Globalization.CultureInfo("id-ID")
                    Dim hariBerobat As String = culture.DateTimeFormat.GetDayName(tglSuratDate.DayOfWeek)

                    Dim tglSurat As String = Format(rowSurat("TanggalSurat"), "dd") & " " & BulanIndonesia(Format(rowSurat("TanggalSurat"), "MM")) & " " & Format(rowSurat("TanggalSurat"), "yyyy")
                    Dim diagnosaPasien As String = rowSurat("Diagnosa")
                    Dim keteranganDetail As String = "Bahwa benar yang bersangkutan telah berobat ke Klinik Pratama Mitra Medicare pada hari " & hariBerobat & " " & _
                                                     "tanggal " & tglSurat & " pukul " & tglSuratDate.ToString("HH:mm") & " dengan diagnosis : " & diagnosaPasien

                    ' Get Nomor Surat
                    Dim nomorSurat As String = rowSurat("NoSurat")

                    Dim pekerjaanPasien As String = "-"

                    For Each Trow As DataRow In tblsRekamMedis.Rows
                        Dim Tlastnew As DataRow = Tdata.NewRow

                        ' Set Pekerjaan
                        If IsDBNull(Trow("Pekerjaan")) = False Then pekerjaanPasien = Trow("Pekerjaan")

                        Tlastnew("Nama") = Trow("Nama")
                        Tlastnew("Umur") = Umur(Trow("TglLahir"))
                        Tlastnew("NIK") = Trow("NoNIK")
                        Tlastnew("Pekerjaan") = pekerjaanPasien
                        Tlastnew("Diagnosis") = diagnosaPasien

                        Tdata.Rows.Add(Tlastnew)
                    Next

                    Report.DataSource = Tdata
                    Report.Bands.Item(BandKind.PageHeader).Controls("xrLabelNoDokumen").Text = noDocument

                    ' Akses panel yang sudah ada di dalam band Detail menggunakan index
                    Dim panel As XRPanel = CType(Report.Bands(BandKind.PageHeader).Controls(0), XRPanel)

                    ' Cari panel berdasarkan nama di dalam band Detail
                    Dim PanelAlamat As XRPanel = TryCast(Report.Bands(BandKind.PageHeader).Controls("xrPanelAlamat"), XRPanel)

                    ' Input data label
                    PanelAlamat.Controls("xrLabelAlamat").Text = alamatCompany
                    PanelAlamat.Controls("xrLabelNoTelepon").Text = telpCompany

                    Report.Bands.Item(BandKind.Detail).Controls("xrLabelNoSurat").Text = nomorSurat
                    Report.Bands.Item(BandKind.Detail).Controls("xrLabelKeteranganDetail").Text = keteranganDetail

                    Report.Bands.Item(BandKind.PageFooter).Controls("xrLabelTgl").Text = namaKota & ", " & tglSurat

                    ' Nonaktifkan jika sudah ada master TTD Dokter
                    Report.Bands.Item(BandKind.PageFooter).Controls("xrPictureBoxTTD").Visible = False

                    ' Add Kop Surat
                    Report.Bands.Item(BandKind.PageHeader).Controls.Add(pictureBoxKopSurat)

                    'Report.RunDesigner()
                    Report.ShowPreview()
                End If
            Else
                MsgBox("Generate surat terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Warning!")
        End Try
    End Sub

    Private Sub ButtonCetakSuratKeteranganKematian_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCetakSuratKeteranganKematian.Click
        Try
            ' Set No Dokumen
            Dim noDocument As String = ReadSQLNIK("SELECT NomorDokumen FROM MasterDokumen WHERE NamaDokumen = 'Surat Keterangan Kematian'")

            ' Set Path Kop Surat
            Dim pathKopSurat As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'image_path_kop_surat_keterangan'")

            ' Set Alamat & No Telpon
            Dim namaKota As String = ReadSQLNIK("SELECT StrValue FROM  msconfig WHERE configname = 'Kota'")
            Dim alamatCompany As String = ReadSQLNIK("SELECT StrValue FROM  msconfig WHERE configname = 'AlamatCompany'")
            Dim telpCompany As String = ReadSQLNIK("SELECT StrValue FROM  msconfig WHERE configname = 'TelpCompany'")

            ' Set Data Surat Keterangan
            Dim tblSuratKeterangan As DataTable = ReadSQL("SELECT * FROM SuratKeteranganKematian WHERE NoTransaksi = '" & idTransaksi & "'")

            If tblSuratKeterangan.Rows.Count > 0 Then
                Dim rowSurat As DataRow = tblSuratKeterangan.Rows(0)

                Report = New XtraReport
                Report = XtraReport.FromFile(Application.StartupPath + "\Reports\Klinik\SuratKeterangan\SuratKeteranganPemeriksaanKematian.repx", True)

                ' Add Kop Image
                Dim imagePathKopSurat As String = System.IO.Path.Combine(Application.StartupPath, pathKopSurat)
                Dim pictureBoxKopSurat As XRPictureBox = CreateXRPictureBoxReport("Kop Surat", Image.FromFile(imagePathKopSurat), 87, 33, 408, 71)

                Dim Tdata As DataTable = New DataTable
                Tdata = CreateTableSuratKeterangan()
                Tdata.Rows.Clear()

                If tblsRekamMedis.Rows.Count > 0 Then
                    Dim rowData As DataRow = tblsRekamMedis.Rows(0)

                    Dim tglSuratDate As DateTime = rowSurat("TanggalSurat")
                    Dim tglSurat As String = Format(rowSurat("TanggalSurat"), "dd") & " " & BulanIndonesia(Format(rowSurat("TanggalSurat"), "MM")) & " " & Format(rowSurat("TanggalSurat"), "yyyy")
                    Dim diagnosaPasien As String = rowSurat("Diagnosa")
                    Dim penyebabKematianPasien As String = rowSurat("PenyebabKematian")

                    ' Get Nomor Surat
                    Dim nomorSurat As String = rowSurat("NoSurat")

                    Dim pekerjaanPasien As String = "-"

                    For Each Trow As DataRow In tblsRekamMedis.Rows
                        Dim Tlastnew As DataRow = Tdata.NewRow

                        ' Set Pekerjaan
                        If IsDBNull(Trow("Pekerjaan")) = False Then pekerjaanPasien = Trow("Pekerjaan")

                        Tlastnew("Nama") = Trow("Nama")
                        Tlastnew("Umur") = Umur(Trow("TglLahir"))
                        Tlastnew("Jenis Kelamin") = Trow("JenisKelamin")
                        Tlastnew("Agama") = Trow("Agama")
                        Tlastnew("Alamat") = Trow("DomisiliAlamat")

                        Tlastnew("Tanggal Surat") = tglSurat
                        Tlastnew("Waktu Surat") = tglSuratDate.ToString("HH:mm")
                        Tlastnew("Penyebab Kematian") = penyebabKematianPasien
                        Tlastnew("Diagnosis") = diagnosaPasien

                        Tdata.Rows.Add(Tlastnew)
                    Next

                    Report.DataSource = Tdata
                    Report.Bands.Item(BandKind.PageHeader).Controls("xrLabelNoDokumen").Text = noDocument

                    ' Akses panel yang sudah ada di dalam band Detail menggunakan index
                    Dim panel As XRPanel = CType(Report.Bands(BandKind.PageHeader).Controls(0), XRPanel)

                    ' Cari panel berdasarkan nama di dalam band Detail
                    Dim PanelAlamat As XRPanel = TryCast(Report.Bands(BandKind.PageHeader).Controls("xrPanelAlamat"), XRPanel)

                    ' Input data label
                    PanelAlamat.Controls("xrLabelAlamat").Text = alamatCompany
                    PanelAlamat.Controls("xrLabelNoTelepon").Text = telpCompany

                    Report.Bands.Item(BandKind.Detail).Controls("xrLabelNoSurat").Text = nomorSurat
                    Report.Bands.Item(BandKind.PageFooter).Controls("xrLabelTgl").Text = namaKota & ", " & tglSurat

                    ' Nonaktifkan jika sudah ada master TTD Dokter
                    Report.Bands.Item(BandKind.PageFooter).Controls("xrPictureBoxTTD").Visible = False

                    ' Add Kop Surat
                    Report.Bands.Item(BandKind.PageHeader).Controls.Add(pictureBoxKopSurat)

                    'Report.RunDesigner()
                    Report.ShowPreview()
                End If
            Else
                MsgBox("Generate surat terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Warning!")
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Dim Trow As DataRow = tblsRekamMedis.Rows(0)
            Dim baseURL As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'web_service_klinik'")
            Dim urlWebService As String = baseURL & "api/post-data-anesthesia-monitoring"
            Dim parameter As String = ""
            Dim uri_message As String = ""

            Dim kodeLokasi As String = ReadSQLNIK("select StrValue from MsConfig where ConfigName = 'NoPoli'")
            Dim keteranganLokasi As String = ReadSQLNIK("select StrValue from MsConfig where ConfigName = 'Kota'")

            parameter = "{" & _
                          """tgl_transaksi"" : """ & Format(Trow("TglTransaksi"), "yyyy-MM-dd HH:mm:ss.fff") & """," & _
                          """kode_lokasi"" : """ & kodeLokasi & """," & _
                          """ket_lokasi"" : """ & keteranganLokasi & """," & _
                          """jenis_poli"" : """ & Trow("JenisPoli") & """," & _
                          """status_transaksi"" : ""Pending""," & _
                          """no_transaksi"" : """ & Trow("NoUrut") & """," & _
                          """no_rekam_medis"" : """ & Trow("IDInternet") & """," & _
                          """no_nik"" : """ & Trow("NoNIK") & """," & _
                          """nama_pasien"" : """ & Trow("Nama") & """," & _
                          """tgl_lahir_pasien"" : """ & Format(Trow("TglLahir"), "yyyy-MM-dd HH:mm:ss.fff") & """," & _
                          """umur_pasien"" : """ & HitungUsia(Trow("TglLahir")) & """," & _
                          """jenis_kelamin_pasien"" : """ & Trow("JenisKelamin") & """," & _
                          """alamat_pasien"" : """ & Trow("DomisiliAlamat") & """," & _
                          """id_dokter"" : """ & Trow("KodeDokter") & """," & _
                          """nama_dokter"" : """ & Trow("NamaDokter") & """," & _
                          """id_perawat"" : null," & _
                          """nama_perawat"" : """ & Trow("NamaPerawat") & """," & _
                          """id_tindakan"" : """ & TextBoxTindakanID.Text & """," & _
                          """ket_tindakan"" : """ & TextBoxNamaTindakan.Text & """," & _
                          """created_by"" : """ & userInput & """" & _
                         "}"

            uri_message = urlWebService

            Dim response As String = InsertDataAPI(parameter, uri_message)

            Dim jsonArray As JArray = JArray.Parse(response)

            Dim responseObj As JObject = jsonArray(0)("response")
            Dim responseMessage As String = responseObj("message").ToString()

            Dim metaDataObj As JObject = jsonArray(0)("metaData")
            Dim metaDataMessage As String = metaDataObj("message").ToString()

            If metaDataMessage = "TRANSACTION_COMPLETE" Then
                MsgBox(responseMessage, MsgBoxStyle.Critical, "Warning!")
            Else
                MsgBox(responseMessage & vbCr & vbLf & "Kunjungi dashboard web untuk melakukan tanda tangan.", MsgBoxStyle.Information, "Success!")
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Warning!")
        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            Dim Trow As DataRow = tblsRekamMedis.Rows(0)
            Dim baseURL As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'web_service_klinik'")
            Dim urlWebService As String = baseURL & "api/post-data-surgical-safety-checklist"
            Dim parameter As String = ""
            Dim uri_message As String = ""

            Dim kodeLokasi As String = ReadSQLNIK("select StrValue from MsConfig where ConfigName = 'NoPoli'")
            Dim keteranganLokasi As String = ReadSQLNIK("select StrValue from MsConfig where ConfigName = 'Kota'")

            parameter = "{" & _
                          """tgl_transaksi"" : """ & Format(Trow("TglTransaksi"), "yyyy-MM-dd HH:mm:ss.fff") & """," & _
                          """kode_lokasi"" : """ & kodeLokasi & """," & _
                          """ket_lokasi"" : """ & keteranganLokasi & """," & _
                          """jenis_poli"" : """ & Trow("JenisPoli") & """," & _
                          """status_transaksi"" : ""Pending""," & _
                          """no_transaksi"" : """ & Trow("NoUrut") & """," & _
                          """no_rekam_medis"" : """ & Trow("IDInternet") & """," & _
                          """no_nik"" : """ & Trow("NoNIK") & """," & _
                          """nama_pasien"" : """ & Trow("Nama") & """," & _
                          """tgl_lahir_pasien"" : """ & Format(Trow("TglLahir"), "yyyy-MM-dd HH:mm:ss.fff") & """," & _
                          """umur_pasien"" : """ & HitungUsia(Trow("TglLahir")) & """," & _
                          """jenis_kelamin_pasien"" : """ & Trow("JenisKelamin") & """," & _
                          """alamat_pasien"" : """ & Trow("DomisiliAlamat") & """," & _
                          """id_dokter"" : """ & Trow("KodeDokter") & """," & _
                          """nama_dokter"" : """ & Trow("NamaDokter") & """," & _
                          """id_perawat"" : null," & _
                          """nama_perawat"" : """ & Trow("NamaPerawat") & """," & _
                          """id_tindakan"" : """ & TextBoxTindakanID.Text & """," & _
                          """ket_tindakan"" : """ & TextBoxNamaTindakan.Text & """," & _
                          """created_by"" : """ & userInput & """" & _
                         "}"

            uri_message = urlWebService

            Dim response As String = InsertDataAPI(parameter, uri_message)

            Dim jsonArray As JArray = JArray.Parse(response)

            Dim responseObj As JObject = jsonArray(0)("response")
            Dim responseMessage As String = responseObj("message").ToString()

            Dim metaDataObj As JObject = jsonArray(0)("metaData")
            Dim metaDataMessage As String = metaDataObj("message").ToString()

            If metaDataMessage = "TRANSACTION_COMPLETE" Then
                MsgBox(responseMessage, MsgBoxStyle.Critical, "Warning!")
            Else
                MsgBox(responseMessage & vbCr & vbLf & "Kunjungi dashboard web untuk melakukan tanda tangan.", MsgBoxStyle.Information, "Success!")
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Warning!")
        End Try
    End Sub

    Private Sub ButtonSavePrognosa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSavePrognosa.Click
        If ComboBoxPrognosa.SelectedIndex <> -1 Then
            Dim kdPrognosa As String = DirectCast(ComboBoxPrognosa.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim nmPrognosa As String = DirectCast(ComboBoxPrognosa.SelectedItem, KeyValuePair(Of String, String)).Value

            If CheckSQL("SELECT * FROM TransaksiDetailPrognosa WHERE NoTransaksi = '" & idTransaksi & "'") = False Then
                ' Insert Data TransaksiDetailPrognosa
                WriteSQL("INSERT INTO TransaksiDetailPrognosa (NoTransaksi, KodePrognosa, KeteranganPrognosa, CreatedBy, CreatedDate) " & _
                         "VALUES('" & idTransaksi & "', '" & kdPrognosa & "', '" & nmPrognosa & "', '" & userInput & "', GETDATE())", 4)

                MsgBox("Data berhasil disimpan.", MsgBoxStyle.Information, "Success!")
            Else
                Dim parameterUpdate As String = ""

                ' Update Data TransaksiDetailPrognosa
                parameterUpdate = "KodePrognosa = '" & kdPrognosa & "'," & _
                                  "KeteranganPrognosa = '" & nmPrognosa & "'," & _
                                  "UpdatedBy = '" & userInput & "'," & _
                                  "UpdatedDate = GETDATE()"

                WriteSQL("UPDATE TransaksiDetailPrognosa SET " & parameterUpdate & " WHERE NoTransaksi = '" & idTransaksi & "'", 4)

                MsgBox("Data berhasil diupdate.", MsgBoxStyle.Information, "Success!")
            End If
        Else
            MsgBox("Pilih jenis prognosa terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
        End If
    End Sub

    Private Sub ButtonCariPenjaminTindakan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCariPenjaminAsuransiLain.Click
        If ValidasiTambahTindakan() = True Then
            Dim queryString As String = ""
            Dim queryOrderString As String = ""

            queryString = "SELECT NoCompany, CompanyCode, CompanyNama FROM MasterCompany WHERE GETDATE() BETWEEN StartDate AND EndDate"
            queryOrderString = ""

            Find.Show()
            Find.Query(queryString, queryOrderString, "FindPenjaminTindakanRekamMedis", 2)
        Else
            ' Refresh Grid
            LoadGridTindakanPoli()
        End If
    End Sub

    Private Sub RadioButtonPenjaminUmum_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonPenjaminUmum.CheckedChanged
        ButtonCariPenjaminAsuransiLain.Enabled = False
        LabelPenjaminAsuransiLain.ResetText()
    End Sub

    Private Sub RadioButtonPenjaminAsuransiLain_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonPenjaminAsuransiLain.CheckedChanged
        ButtonCariPenjaminAsuransiLain.Enabled = True
    End Sub

    Private Sub ButtonSimpanDataEdukasi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSimpanDataEdukasi.Click
        Try
            If ValidasiPerencanaanEdukasi() = True Then
                Dim result As DialogResult
                result = MessageBox.Show("Apakah data yang dimasukkan sudah sesuai?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                If result = DialogResult.Yes Then
                    ' Update Edukasi TransaksiDetail
                    WriteSQL("UPDATE TransaksiDetail SET Edukasi = '" & TextBoxKeteranganEdukasi.Text & "' WHERE NoUrut = '" & idTransaksi & "'", 4)

                    ' Kirim P-Care
                    If statusBPJS = True AndAlso CheckBridgingPcareActive() = True Then SaveKunjunganBPJS()

                    MsgBox("Data Edukasi Berhasil Disimpan.", MsgBoxStyle.Information, "Success")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Warning!")
        End Try
    End Sub

    Function ValidasiPerencanaanEdukasi() As Boolean
        Dim inputEdukasi As String = TextBoxKeteranganEdukasi.Text.Trim()

        ' Validasi inputan kosong
        If inputEdukasi = "" Or inputEdukasi = "-" Then
            MsgBox("Gagal. Silahkan isi perencanaan edukasi terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        ' Validasi inputan lebih dari 4 karakter
        If inputEdukasi.Length <= 4 Then
            MsgBox("Gagal. Perencanaan edukasi harus lebih dari 4 karakter.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        ' Validasi Diagnosa
        If ValidasiDiagnosa() = False Then Return False

        ' Validasi Pemeriksaan Fisik
        If ValidasiPemeriksaanFisik() = False Then Return False

        Return True
    End Function

    Private Sub ButtonHapusDataEdukasi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonHapusDataEdukasi.Click
        Try
            Dim result As DialogResult
            result = MessageBox.Show("Yakin untuk menghapus data edukasi pasien?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                WriteSQL("UPDATE TransaksiDetail SET Edukasi = NULL WHERE NoUrut = '" & idTransaksi & "'", 4)
                TextBoxKeteranganEdukasi.ResetText()
                MsgBox("Data Edukasi Berhasil Dihapus.", MsgBoxStyle.Exclamation, "Warning!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Warning!")
        End Try
    End Sub

    Private Sub LoadDataAlergi(ByVal noRekamMedis As String, ByVal dataGridView As DevExpress.XtraGrid.GridControl)
        Dim tblAlergi As DataTable = New DataTable

        tblAlergi = ReadSQL("SELECT AlergiJenis, AlergiNama, Keterangan FROM MasterPasienAlergi WHERE NoRekamMedis = '" & noRekamMedis & "' AND DeletedDate IS NULL ORDER BY AlergiJenis")

        dataGridView.DataSource = tblAlergi
    End Sub

    Private Sub TambahDataAlergi(ByVal noRekamMedis As String)
        '# Set data dictionary yang akan dikirim ke form popup
        Dim dataDictionary As New Dictionary(Of String, Object)()

        dataDictionary.Add("No Rekam Medis", noRekamMedis)

        DialogBoxTambahAlergi.DataDictionary = dataDictionary
        DialogBoxTambahAlergi.ShowDialog()

        LoadDataAlergi(idPasien, GridControlAlergiMedis)
        LoadDataAlergi(idPasien, GridControlAlergiPemeriksaanAwal)
        LoadNotification(False)
    End Sub

    Private Sub HapusDataAlergi(ByVal noRekamMedis As String, ByVal gridView As DevExpress.XtraGrid.Views.Grid.GridView)
        ' Dapatkan baris yang dipilih
        Dim selectedRow As Integer = gridView.FocusedRowHandle

        If selectedRow >= 0 Then
            ' Dapatkan nilai ID atau kolom utama dari baris yang dipilih
            Dim jenisAlergi As String = gridView.GetRowCellValue(selectedRow, "AlergiJenis")
            Dim namaAlergi As String = gridView.GetRowCellValue(selectedRow, "AlergiNama")

            If MessageBox.Show("Apakah Anda yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim parameterUpdate As String = ""

                ' Hapus Data MasterPasienAlergi
                parameterUpdate = "DeletedBy = '" & userInput & "'," & _
                                  "DeletedDate = GETDATE()"

                WriteSQL("UPDATE MasterPasienAlergi SET " & parameterUpdate & " WHERE NoRekamMedis = '" & noRekamMedis & "' AND AlergiJenis = '" & jenisAlergi & "' AND AlergiNama = '" & namaAlergi & "' AND DeletedDate IS NULL", 4)

                MsgBox("Data Alergi Berhasil Dihapus.", MsgBoxStyle.Information, "Success")

                LoadDataAlergi(idPasien, GridControlAlergiMedis)
                LoadDataAlergi(idPasien, GridControlAlergiPemeriksaanAwal)
                LoadNotification(False)
            End If
        End If
    End Sub

    Private Sub ButtonTambahAlergiMedis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTambahAlergiMedis.Click
        TambahDataAlergi(idPasien)
    End Sub

    Private Sub ButtonHapusAlergiMedis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonHapusAlergiMedis.Click
        HapusDataAlergi(idPasien, GridViewAlergiMedis)
    End Sub

    Private Sub ButtonTambahAlergiPemeriksaanAwal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTambahAlergiPemeriksaanAwal.Click
        TambahDataAlergi(idPasien)
    End Sub

    Private Sub ButtonHapusAlergiPemeriksaanAwal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonHapusAlergiPemeriksaanAwal.Click
        HapusDataAlergi(idPasien, GridViewAlergiPemeriksaanAwal)
    End Sub

    Private Sub ButtonCekRiwayatBPJS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCekRiwayatBPJS.Click
        SetRekamMedisBridgingIcare(noBPJS)
    End Sub

    Private Sub SetRekamMedisBridgingIcare(ByVal noKartuPasien As String)
        If ValidasiViewICare() = True Then
            DialogBoxRiwayatPerawatanICare.SetData(noKartuPasien)
            DialogBoxRiwayatPerawatanICare.ShowDialog()

            'Dim endpointBridging As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'icare_base_url'")
            'Dim payloadBridging As String = ""

            'payloadBridging = "{" & _
            '                        """param"" : """ & noKartuPasien & """" & _
            '                  "}"

            'Dim jsonString As String = ""
            'jsonString = GenerateICareUrl(payloadBridging, endpointBridging, "POST")

            '' Parsing JSON response
            'Dim jsonObj As JObject = JObject.Parse(jsonString)

            '' Mengambil nilai metaData.code
            'Dim code As Integer = CInt(jsonObj("metaData")("code"))

            '' Jika kode 200, sukses
            'If code = 200 Then
            '    ' Menampilkan alert sukses
            '    MsgBox("User Valid. Klik OK untuk menampilkan informasi pencarian riwayat pelayanan kesehatan.", MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, "Validasi User")

            '    ' Mengambil nilai dari response.url
            '    Dim url As String = jsonObj("response")("url").ToString()

            '    ' Membuka di chrome
            '    OpenInNewChromeWindow(url)
            'Else
            '    ' Mengambil pesan error
            '    Dim message As String = jsonObj("metaData")("message").ToString()

            '    ' Menampilkan alert jika terjadi error
            '    MsgBox("Error: " & message, MsgBoxStyle.Critical, "API Error")
            'End If
        End If
    End Sub

    Function ValidasiViewICare() As Boolean
        ' Validasi Status Bridging
        Dim statusBridging As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'icare_status_bridging'")
        If statusBridging <> "Yes" Then
            MsgBox("Eror : Lokasi belum setting bridging I-Care", MsgBoxStyle.Exclamation, "Error!")
            Return False
        End If

        ' Validasi User I-Care
        Dim statusUserBridging As Boolean = ReadSQLNIK("SELECT StatusIcare FROM Users where UserID = '" & userInput & "'")
        If statusUserBridging = False Then
            MsgBox("Eror : User `" & userInput & "` tidak memiliki akses I-Care", MsgBoxStyle.Exclamation, "Error!")
            Return False
        End If

        Return True
    End Function

    'Private Sub TabControlMedis_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControlMedis.SelectedIndexChanged
    '    Dim selectedTab As String = TabControlMedis.SelectedTab.Text
    '    Select Case selectedTab
    '        Case "Subjektif"
    '            MsgBox("Anda memilih Tab 1", MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, "Tab Terpilih")
    '        Case "Objektif"
    '            MsgBox("Anda memilih Tab 2", MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, "Tab Terpilih")
    '        Case "Asesmen"
    '            MsgBox("Anda memilih Tab 3", MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, "Tab Terpilih")
    '        Case "Perencanaan"
    '            MsgBox("Anda memilih Tab 4", MsgBoxStyle.OkOnly Or MsgBoxStyle.Exclamation, "Peringatan")
    '    End Select
    'End Sub

    Private Sub TextBoxKeluhanUtamaPemeriksaanAwal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxKeluhanUtamaPemeriksaanAwal.KeyPress
        ' Memeriksa apakah tombol yang ditekan adalah Enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            ' Mencegah input Enter
            e.Handled = True
        End If
    End Sub

    Private Sub TextBoxKeluhanTambahanPemeriksaanAwal_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxKeluhanTambahanPemeriksaanAwal.KeyPress
        ' Memeriksa apakah tombol yang ditekan adalah Enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            ' Mencegah input Enter
            e.Handled = True
        End If
    End Sub

    Private Sub TextBoxKeluhanUtamaMedik_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxKeluhanUtamaMedik.KeyPress
        ' Memeriksa apakah tombol yang ditekan adalah Enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            ' Mencegah input Enter
            e.Handled = True
        End If
    End Sub

    Private Sub TextBoxKeluhanTambahanMedik_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxKeluhanTambahanMedik.KeyPress
        ' Memeriksa apakah tombol yang ditekan adalah Enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            ' Mencegah input Enter
            e.Handled = True
        End If
    End Sub

    Private Sub TextBoxRiwayatPenyakitSekarang_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxRiwayatPenyakitSekarang.KeyPress
        ' Memeriksa apakah tombol yang ditekan adalah Enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            ' Mencegah input Enter
            e.Handled = True
        End If
    End Sub

    Private Sub TextBoxRiwayatPenggunaanObat_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxRiwayatPenggunaanObat.KeyPress
        ' Memeriksa apakah tombol yang ditekan adalah Enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            ' Mencegah input Enter
            e.Handled = True
        End If
    End Sub

    Private Sub TextBoxRiwayatPenyakitDahuluMedik_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxRiwayatPenyakitDahuluMedik.KeyPress
        ' Memeriksa apakah tombol yang ditekan adalah Enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            ' Mencegah input Enter
            e.Handled = True
        End If
    End Sub

    Private Sub TextBoxRiwayatPenyakitKeluargaMedik_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxRiwayatPenyakitKeluargaMedik.KeyPress
        ' Memeriksa apakah tombol yang ditekan adalah Enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            ' Mencegah input Enter
            e.Handled = True
        End If
    End Sub

    Private Sub TextBoxRiwayatKebiasaanMedik_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxRiwayatKebiasaanMedik.KeyPress
        ' Memeriksa apakah tombol yang ditekan adalah Enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            ' Mencegah input Enter
            e.Handled = True
        End If
    End Sub

    Private Sub TextBoxKeteranganEdukasi_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxKeteranganEdukasi.KeyPress
        ' Memeriksa apakah tombol yang ditekan adalah Enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            ' Mencegah input Enter
            e.Handled = True
        End If
    End Sub

    Private Sub ButtonGenerateSuratKeteranganLayakTerbang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGenerateSuratKeteranganLayakTerbang.Click
        Try
            If ValidasiInputSuratKeterangan("SURAT KETERANGAN LAYAK TERBANG") = True Then
                Dim statusSehat As String = ""

                ' Set Status Sehat
                If RadioButtonStatusSehatLayakTerbang.Checked = True Then
                    statusSehat = RadioButtonStatusSehatLayakTerbang.Text
                ElseIf RadioButtonStatusTidakSehatLayakTerbang.Checked = True Then
                    statusSehat = RadioButtonStatusTidakSehatLayakTerbang.Text
                End If

                If TextBoxNoSuratLayakTerbang.Text = "" Then
                    ' Insert Data SuratKeteranganLayakTerbang
                    If tblsRekamMedis.Rows.Count > 0 Then
                        Dim rowData As DataRow = tblsRekamMedis.Rows(0)

                        Dim tglSekarang As String = Format(DateAndTime.Now, "dd") & " " & BulanIndonesia(Format(DateAndTime.Now, "MM")) & " " & Format(DateAndTime.Now, "yyyy")

                        ' Get Nomor Surat
                        Dim nomorSurat As String = GenerateNomorSurat("SURAT KETERANGAN LAYAK TERBANG")

                        ' Insert data ke SuratKeteranganLayakTerbang
                        WriteSQL("INSERT INTO SuratKeteranganLayakTerbang (NoTransaksi, NoRekamMedis, NoSurat, TanggalSurat, DokterID, DokterNama, Diagnosa, Hasil, CreatedBy, CreatedDate) " & _
                                "VALUES ('" & idTransaksi & "', '" & idPasien & "', '" & nomorSurat & "', GETDATE(), '" & rowData("KodeDokter") & "', '" & rowData("NamaDokter") & "', '" & TextBoxDiagnosaSuratLayakTerbang.Text & "', '" & statusSehat.ToUpper() & "', '" & userInput & "', GETDATE())", 4)

                        ' Set Nomor Surat
                        TextBoxNoSuratLayakTerbang.Text = nomorSurat
                    End If
                ElseIf TextBoxNoSuratLayakTerbang.Text <> "" Then
                    Dim parameterUpdate As String = ""

                    ' Update Data SuratKeteranganLayakTerbang
                    parameterUpdate = "Diagnosa = '" & TextBoxDiagnosaSuratLayakTerbang.Text & "'," & _
                                      "Hasil = '" & statusSehat.ToUpper() & "'," & _
                                      "UpdatedBy = '" & userInput & "'," & _
                                      "UpdatedDate = GETDATE()"

                    WriteSQL("UPDATE SuratKeteranganLayakTerbang SET " & parameterUpdate & " WHERE NoTransaksi = '" & idTransaksi & "'", 4)
                End If

                MsgBox("Data Berhasil Disimpan.", MsgBoxStyle.Information, "Success")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub ButtonCetakSuratKeteranganLayakTerbang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCetakSuratKeteranganLayakTerbang.Click
        Try
            ' Set No Dokumen
            Dim noDocument As String = ReadSQLNIK("SELECT NomorDokumen FROM MasterDokumen WHERE NamaDokumen = 'Surat Keterangan Layak Terbang'")

            ' Set Path Kop Surat
            Dim pathKopSurat As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'image_path_kop_surat_keterangan'")

            ' Set Alamat & No Telpon
            Dim namaKota As String = ReadSQLNIK("SELECT StrValue FROM  msconfig WHERE configname = 'Kota'")
            Dim alamatCompany As String = ReadSQLNIK("SELECT StrValue FROM  msconfig WHERE configname = 'AlamatCompany'")
            Dim telpCompany As String = ReadSQLNIK("SELECT StrValue FROM  msconfig WHERE configname = 'TelpCompany'")

            ' Set Data Surat Keterangan
            Dim tblSuratKeterangan As DataTable = ReadSQL("SELECT * FROM SuratKeteranganLayakTerbang WHERE NoTransaksi = '" & idTransaksi & "'")

            If tblSuratKeterangan.Rows.Count > 0 Then
                Dim rowSurat As DataRow = tblSuratKeterangan.Rows(0)

                Report = New XtraReport
                Report = XtraReport.FromFile(Application.StartupPath + "\Reports\Klinik\SuratKeterangan\SuratKeteranganLayakTerbang.repx", True)

                ' Add Kop Image
                Dim imagePathKopSurat As String = System.IO.Path.Combine(Application.StartupPath, pathKopSurat)
                Dim pictureBoxKopSurat As XRPictureBox = CreateXRPictureBoxReport("Kop Surat", Image.FromFile(imagePathKopSurat), 87, 33, 408, 71)

                Dim Tdata As DataTable = New DataTable
                Tdata = CreateTableSuratKeterangan()
                Tdata.Rows.Clear()

                If tblsRekamMedis.Rows.Count > 0 Then
                    Dim rowData As DataRow = tblsRekamMedis.Rows(0)

                    Dim tglSurat As String = Format(rowSurat("TanggalSurat"), "dd") & " " & BulanIndonesia(Format(rowSurat("TanggalSurat"), "MM")) & " " & Format(rowSurat("TanggalSurat"), "yyyy")
                    Dim diagnosaPasien As String = rowSurat("Diagnosa")
                    Dim keteranganSuratSehat As String = ""

                    ' Set Status Sehat
                    If rowSurat("Hasil").ToString() = "SEHAT" Then
                        keteranganSuratSehat = "Setelah dilakukan pemeriksaan, dinyatakan dalam keadaan " & rowSurat("Hasil").ToString() & " serta layak melakukan perjalanan udara."
                    ElseIf rowSurat("Hasil").ToString() = "TIDAK SEHAT" Then
                        keteranganSuratSehat = "Setelah dilakukan pemeriksaan, dinyatakan dalam keadaan " & rowSurat("Hasil").ToString() & "."
                    End If

                    ' Get Nomor Surat
                    Dim nomorSurat As String = rowSurat("NoSurat")

                    Dim tblsFisik As DataTable = ReadSQL("SELECT * FROM TransaksiDetailFisik WHERE NoTransaksi = '" & idTransaksi & "'")
                    Dim tinggi As String = ""
                    Dim berat As String = ""
                    Dim sistole As String = ""
                    Dim diastole As String = ""
                    Dim suhu As String = ""
                    Dim heartRate As String = ""
                    Dim respiratoryRate As String = ""

                    If tblsFisik.Rows.Count > 0 Then
                        Dim rowFisik As DataRow = tblsFisik.Rows(0)

                        tinggi = rowFisik("Tinggi")
                        berat = rowFisik("Berat")
                        sistole = rowFisik("Sistole")
                        diastole = rowFisik("Diastole")
                        suhu = rowFisik("Suhu")
                        heartRate = rowFisik("HeartRate")
                        respiratoryRate = rowFisik("RespiratoryRate")
                    End If

                    For Each Trow As DataRow In tblsRekamMedis.Rows
                        Dim Tlastnew As DataRow = Tdata.NewRow

                        Tlastnew("Nama") = Trow("Nama")
                        Tlastnew("Umur") = Umur(Trow("TglLahir"))
                        Tlastnew("Jenis Kelamin") = Trow("JenisKelamin")
                        Tlastnew("Alamat") = Trow("DomisiliAlamat")
                        Tlastnew("Tinggi Badan") = tinggi
                        Tlastnew("Berat Badan") = berat
                        Tlastnew("Tekanan Darah") = sistole & "/" & diastole
                        Tlastnew("Suhu") = suhu
                        Tlastnew("Nadi") = heartRate
                        Tlastnew("Frekuensi Nafas") = respiratoryRate
                        Tlastnew("Diagnosis") = diagnosaPasien

                        Tdata.Rows.Add(Tlastnew)
                    Next

                    Report.DataSource = Tdata
                    Report.Bands.Item(BandKind.PageHeader).Controls("xrLabelNoDokumen").Text = noDocument

                    ' Akses panel yang sudah ada di dalam band Detail menggunakan index
                    Dim panel As XRPanel = CType(Report.Bands(BandKind.PageHeader).Controls(0), XRPanel)

                    ' Cari panel berdasarkan nama di dalam band Detail
                    Dim PanelAlamat As XRPanel = TryCast(Report.Bands(BandKind.PageHeader).Controls("xrPanelAlamat"), XRPanel)

                    ' Input data label
                    PanelAlamat.Controls("xrLabelAlamat").Text = alamatCompany
                    PanelAlamat.Controls("xrLabelNoTelepon").Text = telpCompany

                    Report.Bands.Item(BandKind.Detail).Controls("xrLabelNoSurat").Text = nomorSurat
                    Report.Bands.Item(BandKind.Detail).Controls("xrLabelKeterangan").Text = keteranganSuratSehat

                    Report.Bands.Item(BandKind.PageFooter).Controls("xrLabelTgl").Text = namaKota & ", " & tglSurat

                    ' Nonaktifkan jika sudah ada master TTD Dokter
                    Report.Bands.Item(BandKind.PageFooter).Controls("xrPictureBoxTTD").Visible = False

                    ' Add Kop Surat
                    Report.Bands.Item(BandKind.PageHeader).Controls.Add(pictureBoxKopSurat)

                    'Report.RunDesigner()
                    Report.ShowPreview()
                End If
            Else
                MsgBox("Generate surat terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Warning!")
        End Try
    End Sub

    Private Sub ButtonGenerateSuratKeteranganKhitan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGenerateSuratKeteranganKhitan.Click
        Try
            If ValidasiInputSuratKeterangan("SURAT KETERANGAN KHITAN") = True Then
                ' Ambil nilai dari DateTimePicker
                Dim tanggalKhitan As String = DateTimePickerTanggalKhitan.Value.ToString("yyyy-MM-dd")
                Dim waktuKhitan As String = DateTimePickerWaktuKhitan.Value.ToString("HH:mm:ss")

                If TextBoxNoSuratKhitan.Text = "" Then
                    ' Insert Data SuratKeteranganKhitan
                    If tblsRekamMedis.Rows.Count > 0 Then
                        Dim rowData As DataRow = tblsRekamMedis.Rows(0)

                        Dim tglSekarang As String = Format(DateAndTime.Now, "dd") & " " & BulanIndonesia(Format(DateAndTime.Now, "MM")) & " " & Format(DateAndTime.Now, "yyyy")

                        ' Get Nomor Surat
                        Dim nomorSurat As String = GenerateNomorSurat("SURAT KETERANGAN KHITAN")

                        ' Insert data ke SuratKeteranganKhitan
                        WriteSQL("INSERT INTO SuratKeteranganKhitan (NoTransaksi, NoRekamMedis, NoSurat, TanggalSurat, DokterID, DokterNama, TanggalKhitan, WaktuKhitan, CreatedBy, CreatedDate) " & _
                                "VALUES ('" & idTransaksi & "', '" & idPasien & "', '" & nomorSurat & "', GETDATE(), '" & rowData("KodeDokter") & "', '" & rowData("NamaDokter") & "', '" & tanggalKhitan & "', '" & waktuKhitan & "', '" & userInput & "', GETDATE())", 4)

                        ' Set Nomor Surat
                        TextBoxNoSuratKhitan.Text = nomorSurat
                    End If
                ElseIf TextBoxNoSuratKhitan.Text <> "" Then
                    Dim parameterUpdate As String = ""

                    ' Update Data SuratKeteranganKhitan
                    parameterUpdate = "TanggalKhitan = '" & tanggalKhitan & "'," & _
                                      "WaktuKhitan = '" & waktuKhitan & "'," & _
                                      "UpdatedBy = '" & userInput & "'," & _
                                      "UpdatedDate = GETDATE()"

                    WriteSQL("UPDATE SuratKeteranganKhitan SET " & parameterUpdate & " WHERE NoTransaksi = '" & idTransaksi & "'", 4)
                End If

                MsgBox("Data Berhasil Disimpan.", MsgBoxStyle.Information, "Success")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub ButtonCetakSuratKeteranganKhitan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCetakSuratKeteranganKhitan.Click
        Try
            ' Set No Dokumen
            Dim noDocument As String = ReadSQLNIK("SELECT NomorDokumen FROM MasterDokumen WHERE NamaDokumen = 'Surat Keterangan Khitan'")

            ' Set Path Kop Surat
            Dim pathKopSurat As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'image_path_kop_surat_keterangan'")

            ' Set Alamat & No Telpon
            Dim namaKota As String = ReadSQLNIK("SELECT StrValue FROM  msconfig WHERE configname = 'Kota'")
            Dim alamatCompany As String = ReadSQLNIK("SELECT StrValue FROM  msconfig WHERE configname = 'AlamatCompany'")
            Dim telpCompany As String = ReadSQLNIK("SELECT StrValue FROM  msconfig WHERE configname = 'TelpCompany'")

            ' Set Data Surat Keterangan
            Dim tblSuratKeterangan As DataTable = ReadSQL("SELECT * FROM SuratKeteranganKhitan WHERE NoTransaksi = '" & idTransaksi & "'")

            If tblSuratKeterangan.Rows.Count > 0 Then
                Dim rowSurat As DataRow = tblSuratKeterangan.Rows(0)

                Report = New XtraReport
                Report = XtraReport.FromFile(Application.StartupPath + "\Reports\Klinik\SuratKeterangan\SuratKeteranganKhitan.repx", True)

                ' Add Kop Image
                Dim imagePathKopSurat As String = System.IO.Path.Combine(Application.StartupPath, pathKopSurat)
                Dim pictureBoxKopSurat As XRPictureBox = CreateXRPictureBoxReport("Kop Surat", Image.FromFile(imagePathKopSurat), 87, 33, 408, 71)

                Dim Tdata As DataTable = New DataTable
                Tdata = CreateTableSuratKeterangan()
                Tdata.Rows.Clear()

                If tblsRekamMedis.Rows.Count > 0 Then
                    Dim rowData As DataRow = tblsRekamMedis.Rows(0)

                    Dim tglSurat As String = Format(rowSurat("TanggalSurat"), "dd") & " " & BulanIndonesia(Format(rowSurat("TanggalSurat"), "MM")) & " " & Format(rowSurat("TanggalSurat"), "yyyy")

                    ' Format tanggal
                    Dim tglKhitan As String = Format(rowSurat("TanggalKhitan"), "dd") & " " & BulanIndonesia(Format(rowSurat("TanggalKhitan"), "MM")) & " " & Format(rowSurat("TanggalKhitan"), "yyyy")

                    ' Ambil nilai WaktuKhitan dari database (TimeSpan)
                    Dim waktuSpan As TimeSpan = rowSurat("WaktuKhitan")

                    ' Format waktu menjadi "HH:mm" atau sesuai kebutuhan
                    Dim waktuKhitan As String = waktuSpan.Hours.ToString("00") & ":" & waktuSpan.Minutes.ToString("00")

                    ' Set Keterangan
                    Dim keteranganDetail As String = "Yang bertanda tangan di bawah ini, Dokter Klinik Pratama Mitra Medicare menerangkan bahwa pada tanggal " & tglKhitan & " " & waktuKhitan

                    ' Get Nomor Surat
                    Dim nomorSurat As String = rowSurat("NoSurat")

                    For Each Trow As DataRow In tblsRekamMedis.Rows
                        Dim Tlastnew As DataRow = Tdata.NewRow

                        Tlastnew("Nama") = Trow("Nama")
                        Tlastnew("Umur") = Umur(Trow("TglLahir"))
                        Tlastnew("Jenis Kelamin") = Trow("JenisKelamin")
                        Tlastnew("Alamat") = Trow("DomisiliAlamat")

                        Tdata.Rows.Add(Tlastnew)
                    Next

                    Report.DataSource = Tdata
                    Report.Bands.Item(BandKind.PageHeader).Controls("xrLabelNoDokumen").Text = noDocument

                    ' Akses panel yang sudah ada di dalam band Detail menggunakan index
                    Dim panel As XRPanel = CType(Report.Bands(BandKind.PageHeader).Controls(0), XRPanel)

                    ' Cari panel berdasarkan nama di dalam band Detail
                    Dim PanelAlamat As XRPanel = TryCast(Report.Bands(BandKind.PageHeader).Controls("xrPanelAlamat"), XRPanel)

                    ' Input data label
                    PanelAlamat.Controls("xrLabelAlamat").Text = alamatCompany
                    PanelAlamat.Controls("xrLabelNoTelepon").Text = telpCompany

                    Report.Bands.Item(BandKind.Detail).Controls("xrLabelNoSurat").Text = nomorSurat
                    Report.Bands.Item(BandKind.Detail).Controls("xrLabelKeterangan").Text = keteranganDetail

                    Report.Bands.Item(BandKind.PageFooter).Controls("xrLabelTgl").Text = namaKota & ", " & tglSurat

                    ' Nonaktifkan jika sudah ada master TTD Dokter
                    Report.Bands.Item(BandKind.PageFooter).Controls("xrPictureBoxTTD").Visible = False

                    ' Add Kop Surat
                    Report.Bands.Item(BandKind.PageHeader).Controls.Add(pictureBoxKopSurat)

                    'Report.RunDesigner()
                    Report.ShowPreview()
                End If
            Else
                MsgBox("Generate surat terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Warning!")
        End Try
    End Sub

    Private Sub ButtonGenerateSuratKeteranganCutiHamil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGenerateSuratKeteranganCutiHamil.Click
        Try
            If ValidasiInputSuratKeterangan("SURAT KETERANGAN CUTI HAMIL") = True Then
                If TextBoxNoSuratKeteranganCutiHamil.Text = "" Then
                    ' Insert Data SuratKeteranganBerobat
                    If tblsRekamMedis.Rows.Count > 0 Then
                        Dim rowData As DataRow = tblsRekamMedis.Rows(0)

                        Dim tglSekarang As String = Format(DateAndTime.Now, "dd") & " " & BulanIndonesia(Format(DateAndTime.Now, "MM")) & " " & Format(DateAndTime.Now, "yyyy")

                        ' Get Nomor Surat
                        Dim nomorSurat As String = GenerateNomorSurat("SURAT KETERANGAN CUTI HAMIL")

                        ' Insert data ke SuratKeteranganBerobat
                        WriteSQL("INSERT INTO SuratKeteranganCutiHamil (NoTransaksi, NoRekamMedis, NoSurat, TanggalSurat, DokterID, DokterNama, DiagnosisGravida, DiagnosisPara, DiagnosisAbortus, UsiaKehamilan, TaksiranPersalinan, TanggalAwal, TanggalAkhir, CreatedBy, CreatedDate) " & _
                                "VALUES ('" & idTransaksi & "', '" & idPasien & "', '" & nomorSurat & "', GETDATE(), '" & rowData("KodeDokter") & "', '" & rowData("NamaDokter") & "', '" & TextBoxDiagnosisGravidaSuratKeteranganCutiHamil.Text & "', '" & TextBoxDiagnosisParaSuratKeteranganCutiHamil.Text & "', '" & TextBoxDiagnosisAbortusSuratKeteranganCutiHamil.Text & "', '" & TextBoxUsiaKehamilanSuratKeteranganCutiHamil.Text & "', '" & Format(TanggalTaksiranPersalinanSuratKeteranganCutiHamil.Value, "yyyy-MM-dd") & "', '" & Format(TanggalMulaiSuratKeteranganCutiHamil.Value, "yyyy-MM-dd") & "', '" & Format(TanggalAkhirSuratKeteranganCutiHamil.Value, "yyyy-MM-dd") & "', '" & userInput & "', GETDATE())", 4)

                        ' Set Nomor Surat
                        TextBoxNoSuratKeteranganCutiHamil.Text = nomorSurat
                    End If
                ElseIf TextBoxNoSuratKeteranganCutiHamil.Text <> "" Then
                    Dim parameterUpdate As String = ""

                    ' Update Data SuratKeteranganCutiHamil
                    parameterUpdate = "DiagnosisGravida = '" & TextBoxDiagnosisGravidaSuratKeteranganCutiHamil.Text & "'," & _
                                      "DiagnosisPara = '" & TextBoxDiagnosisParaSuratKeteranganCutiHamil.Text & "'," & _
                                      "DiagnosisAbortus = '" & TextBoxDiagnosisAbortusSuratKeteranganCutiHamil.Text & "'," & _
                                      "UsiaKehamilan = '" & TextBoxUsiaKehamilanSuratKeteranganCutiHamil.Text & "'," & _
                                      "TaksiranPersalinan = '" & Format(TanggalTaksiranPersalinanSuratKeteranganCutiHamil.Value, "yyyy-MM-dd") & "'," & _
                                      "TanggalAwal = '" & Format(TanggalMulaiSuratKeteranganCutiHamil.Value, "yyyy-MM-dd") & "'," & _
                                      "TanggalAkhir = '" & Format(TanggalAkhirSuratKeteranganCutiHamil.Value, "yyyy-MM-dd") & "'," & _
                                      "UpdatedBy = '" & userInput & "'," & _
                                      "UpdatedDate = GETDATE()"

                    WriteSQL("UPDATE SuratKeteranganCutiHamil SET " & parameterUpdate & " WHERE NoTransaksi = '" & idTransaksi & "'", 4)
                End If

                MsgBox("Data Berhasil Disimpan.", MsgBoxStyle.Information, "Success")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub ButtonCetakSuratKeteranganCutiHamil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCetakSuratKeteranganCutiHamil.Click
        Try
            ' Set No Dokumen
            Dim noDocument As String = ReadSQLNIK("SELECT NomorDokumen FROM MasterDokumen WHERE NamaDokumen = 'Surat Keterangan Cuti Hamil'")

            ' Set Path Kop Surat
            Dim pathKopSurat As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'image_path_kop_surat_keterangan'")

            ' Set Alamat & No Telpon
            Dim namaKota As String = ReadSQLNIK("SELECT StrValue FROM  msconfig WHERE configname = 'Kota'")
            Dim alamatCompany As String = ReadSQLNIK("SELECT StrValue FROM  msconfig WHERE configname = 'AlamatCompany'")
            Dim telpCompany As String = ReadSQLNIK("SELECT StrValue FROM  msconfig WHERE configname = 'TelpCompany'")

            ' Set Data Surat Keterangan
            Dim tblSuratKeterangan As DataTable = ReadSQL("SELECT * FROM SuratKeteranganCutiHamil WHERE NoTransaksi = '" & idTransaksi & "'")

            If tblSuratKeterangan.Rows.Count > 0 Then
                Dim rowSurat As DataRow = tblSuratKeterangan.Rows(0)

                Report = New XtraReport
                Report = XtraReport.FromFile(Application.StartupPath + "\Reports\Klinik\SuratKeterangan\SuratKeteranganCutiHamil.repx", True)

                ' Add Kop Image
                Dim imagePathKopSurat As String = System.IO.Path.Combine(Application.StartupPath, pathKopSurat)
                Dim pictureBoxKopSurat As XRPictureBox = CreateXRPictureBoxReport("Kop Surat", Image.FromFile(imagePathKopSurat), 87, 33, 408, 71)

                Dim tblBiodata As DataTable = New DataTable
                tblBiodata = CreateTableSuratKeterangan()
                tblBiodata.Rows.Clear()

                If tblsRekamMedis.Rows.Count > 0 Then
                    Dim rowData As DataRow = tblsRekamMedis.Rows(0)

                    Dim tglSurat As String = Format(rowSurat("TanggalSurat"), "dd") & " " & BulanIndonesia(Format(rowSurat("TanggalSurat"), "MM")) & " " & Format(rowSurat("TanggalSurat"), "yyyy")
                    Dim tglAwal As String = Format(rowSurat("TanggalAwal"), "dd") & " " & BulanIndonesia(Format(rowSurat("TanggalAwal"), "MM")) & " " & Format(rowSurat("TanggalAwal"), "yyyy")
                    Dim tglAkhir As String = Format(rowSurat("TanggalAkhir"), "dd") & " " & BulanIndonesia(Format(rowSurat("TanggalAkhir"), "MM")) & " " & Format(rowSurat("TanggalAkhir"), "yyyy")
                    Dim tglTaksiranPersalinan As String = Format(rowSurat("TaksiranPersalinan"), "dd") & " " & BulanIndonesia(Format(rowSurat("TaksiranPersalinan"), "MM")) & " " & Format(rowSurat("TaksiranPersalinan"), "yyyy")

                    ' Get Jenis Dokter / Bidan
                    Dim jenisPelaksana As String = ReadSQLNIK("SELECT Jenis FROM MasterDokter WHERE ID = '" & rowData("KodeDokter").ToString() & "'")

                    ' Get Nomor SIP
                    Dim nomorSIP As String = ReadSQLNIK("SELECT NoSIP FROM MasterDokter WHERE ID = '" & rowData("KodeDokter").ToString() & "'")

                    ' Set Keterangan 1
                    Dim keteranganDetail1 As String = "Yang bertanda tangan di bawah ini, " & jenisPelaksana & " Klinik Pratama Mitra Medicare menerangakan bahwa :"

                    ' Set Keterangan 2
                    Dim keteranganDetail2 As String = "Sesuai hasil pemeriksaan kehamilan di Klinik Pratama Mitra Medicare, dengan diagnosis G" & rowSurat("DiagnosisGravida").ToString() & "P" & rowSurat("DiagnosisPara").ToString() & "A" & rowSurat("DiagnosisAbortus").ToString() & " usia kehamilan " & rowSurat("UsiaKehamilan").ToString() & " minggu dan taksiran persalinan " & tglTaksiranPersalinan & ", " & _
                                                      "maka perlu mendapatkan ijin cuti hamil dan melahirkan selama 3 bulan mulai tanggal " & tglAwal & " s/d " & tglAkhir

                    ' Get Nomor Surat
                    Dim nomorSurat As String = rowSurat("NoSurat").ToString()

                    For Each Trow As DataRow In tblsRekamMedis.Rows
                        Dim rowBiodata As DataRow = tblBiodata.NewRow

                        rowBiodata("Nama") = Trow("Nama")
                        rowBiodata("Umur") = Umur(Trow("TglLahir"))
                        rowBiodata("Alamat") = Trow("DomisiliAlamat")
                        rowBiodata("NIK") = Trow("NoNIK")

                        tblBiodata.Rows.Add(rowBiodata)
                    Next

                    Report.DataSource = tblBiodata
                    Report.Bands.Item(BandKind.PageHeader).Controls("xrLabelNoDokumen").Text = noDocument

                    ' Akses panel yang sudah ada di dalam band Detail menggunakan index
                    Dim panel As XRPanel = CType(Report.Bands(BandKind.PageHeader).Controls(0), XRPanel)

                    ' Cari panel berdasarkan nama di dalam band Detail
                    Dim PanelAlamat As XRPanel = TryCast(Report.Bands(BandKind.PageHeader).Controls("xrPanelAlamat"), XRPanel)

                    ' Input data label
                    PanelAlamat.Controls("xrLabelAlamat").Text = alamatCompany
                    PanelAlamat.Controls("xrLabelNoTelepon").Text = telpCompany

                    Report.Bands.Item(BandKind.Detail).Controls("xrLabelNoSurat").Text = "Nomor : " & nomorSurat
                    Report.Bands.Item(BandKind.Detail).Controls("xrLabelKeteranganDetail1").Text = keteranganDetail1
                    Report.Bands.Item(BandKind.Detail).Controls("xrLabelKeteranganDetail2").Text = keteranganDetail2

                    Report.Bands.Item(BandKind.PageFooter).Controls("xrLabelTgl").Text = namaKota & ", " & tglSurat
                    Report.Bands.Item(BandKind.PageFooter).Controls("xrLabelNamaPelaksana").Text = rowData("NamaDokter").ToString()
                    Report.Bands.Item(BandKind.PageFooter).Controls("xrLabelJenisPelaksana").Text = jenisPelaksana & " yang memeriksa"

                    If jenisPelaksana = "Dokter" Then
                        Report.Bands.Item(BandKind.PageFooter).Controls("xrLabelNomorSIP").Text = "No SIP : " & nomorSIP
                    Else
                        Report.Bands.Item(BandKind.PageFooter).Controls("xrLabelNomorSIP").Text = "No SIPB : " & nomorSIP
                    End If

                    ' Hidden jika nomor SIP kosong
                    If nomorSIP = "" Then
                        Report.Bands.Item(BandKind.PageFooter).Controls("xrLabelNomorSIP").Visible = False
                    End If

                    ' Nonaktifkan jika sudah ada master TTD Dokter
                    Report.Bands.Item(BandKind.PageFooter).Controls("xrPictureBoxTTD").Visible = False

                    ' Add Kop Surat
                    Report.Bands.Item(BandKind.PageHeader).Controls.Add(pictureBoxKopSurat)

                    'Report.RunDesigner()
                    Report.ShowPreview()
                End If
            Else
                MsgBox("Generate surat terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Warning!")
        End Try
    End Sub

    Private Sub ButtonGenerateSuratKeteranganKontrol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGenerateSuratKeteranganKontrol.Click
        Try
            If ValidasiInputSuratKeterangan("SURAT KETERANGAN KONTROL") = True Then
                ' Ambil nilai tanggal dari DateTimePicker
                Dim tgl As DateTime = DateTimePickerTanggalKontrol.Value.Date ' Normalisasi ke tengah malam
                Dim diagnosa = TextBoxDiagnosaSuratKontrol.Text.Replace("'", "''")
                Dim dtPasien As DataTable = ReadSQL("SELECT MR.Nama, MR.NoHandphone, MR.JenisKelamin " & _
                                    "FROM TransaksiDetail TD " & _
                                    "INNER JOIN MasterPasien MR ON TD.IDInternet = MR.NoRekamMedis " & _
                                    "WHERE TD.NoUrut = '" & idTransaksi & "'")

                Dim namaPasien As String = ""
                Dim NoHp As String = ""
                Dim jenisKelamin As String = ""

                If dtPasien.Rows.Count > 0 Then
                    namaPasien = dtPasien.Rows(0)("Nama").ToString()
                    NoHp = dtPasien.Rows(0)("NoHandphone").ToString()
                    jenisKelamin = dtPasien.Rows(0)("JenisKelamin").ToString()
                End If

                If TextBoxNoSuratKeteranganKontrol.Text = "" Then
                    ' Insert Data SuratKeteranganKontrol
                    If tblsRekamMedis.Rows.Count > 0 Then
                        Dim rowData As DataRow = tblsRekamMedis.Rows(0)

                        Dim tglSekarang As String = Format(DateAndTime.Now, "dd") & " " & BulanIndonesia(Format(DateAndTime.Now, "MM")) & " " & Format(DateAndTime.Now, "yyyy")

                        ' Get Nomor Surat
                        Dim nomorSurat As String = GenerateNomorSurat("SURAT KETERANGAN KONTROL")

                        ' Insert data ke SuratKeteranganKontrol
                        WriteSQL("INSERT INTO SuratKeteranganKontrol (NoTransaksi, NoRekamMedis, NoSurat, TanggalSurat, DokterID, DokterNama, Diagnosa, Tanggal, CreatedBy, CreatedDate) " & _
                                "VALUES ('" & idTransaksi & "', '" & idPasien & "', '" & nomorSurat & "', GETDATE(), '" & rowData("KodeDokter") & "', '" & rowData("NamaDokter") & "', '" & diagnosa & "', '" & Format(tgl, "yyyy-MM-dd") & "', '" & userInput & "', GETDATE())", 4)

                       

                        ' Tanggal kontrol
                        Dim tglKontrol As DateTime = DateTimePickerTanggalKontrol.Value.Date

                        ' Reminder H-6 jam 09:00 WIB
                        Dim tglReminder As DateTime = tglKontrol.AddDays(-6).AddHours(9)
                        Dim kdPoli As String = ReadSQLNIK( _
                           "SELECT TOP 1 MPT.KodeBPJS " & _
                           "FROM TransaksiDetail TD " & _
                           "INNER JOIN MasterPoliTujuan MPT ON TD.JenisPoli = MPT.NamaPoli " & _
                           "WHERE TD.NoUrut = '" & idTransaksi & "'")

                        If CheckSQL("SELECT 1 FROM LogReminderPasien WHERE NoRekamMedis='" & idPasien & "' AND Tanggal='" & tglReminder.ToString("yyyy-MM-dd HH:mm") & "'") = False Then

                            'Simpan ke LogReminderPasien
                            WriteSQL("INSERT INTO LogReminderPasien " & _
                                  "(NamaPasien, NoHP, Keperluan, Tanggal, Status, CreatedBy, CreatedDate, JenisKelamin, NoRekamMedis,  KodePoli) " & _
                                  "VALUES (" & _
                                  "'" & namaPasien.Replace("'", "''") & "', " & _
                                  "'" & NoHp.Replace("'", "''") & "', " & _
                                  "'" & TextBoxNamaTindakan.Text.Replace("'", "''") & "', " & _
                                  "'" & tglReminder.ToString("yyyy-MM-dd 09:00") & "', " & _
                                  "'TERJADWAL', " & _
                                  "'" & userInput.Replace("'", "''") & "', " & _
                                  "GETDATE(), " & _
                                  "'" & jenisKelamin & "', " & _
                                  "'" & idPasien & "'," & _
                                  "'" & kdPoli & "'" & _
                                  ")", 4)
                        End If

                        ' Set Nomor Surat
                        TextBoxNoSuratKeteranganKontrol.Text = nomorSurat
                    End If
                ElseIf TextBoxNoSuratKeteranganKontrol.Text <> "" Then
                    Dim parameterUpdate As String = ""

                    ' Update Data SuratKeteranganIstirahat
                    parameterUpdate = "Tanggal = '" & Format(DateTimePickerTanggalKontrol.Value, "yyyy-MM-dd") & "'," & _
                                      "Diagnosa = '" & TextBoxDiagnosaSuratKontrol.Text & "'," & _
                                      "UpdatedBy = '" & userInput & "'," & _
                                      "UpdatedDate = GETDATE()"

                    WriteSQL("UPDATE SuratKeteranganKontrol SET " & parameterUpdate & " WHERE NoTransaksi = '" & idTransaksi & "'", 4)
                End If

                MsgBox("Data Berhasil Disimpan.", MsgBoxStyle.Information, "Success")
            End If
        Catch ex As Exception
            MsgBox(ex.StackTrace, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub ButtonCetakSuratKeteranganKontrol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCetakSuratKeteranganKontrol.Click
        Try
            ' Set No Dokumen
            Dim noDocument As String = ReadSQLNIK("SELECT NomorDokumen FROM MasterDokumen WHERE NamaDokumen = 'Surat Keterangan Kontrol'")

            ' Set Path Kop Surat
            Dim pathKopSurat As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'image_path_kop_surat_keterangan'")

            ' Set Alamat & No Telpon
            Dim namaKota As String = ReadSQLNIK("SELECT StrValue FROM  msconfig WHERE configname = 'Kota'")
            Dim alamatCompany As String = ReadSQLNIK("SELECT StrValue FROM  msconfig WHERE configname = 'AlamatCompany'")
            Dim telpCompany As String = ReadSQLNIK("SELECT StrValue FROM  msconfig WHERE configname = 'TelpCompany'")
            Dim lokasi As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'InvoiceTempat_Klinik'")

            ' Set Data Surat Keterangan
            Dim tblSuratKeterangan As DataTable = ReadSQL("SELECT * FROM SuratKeteranganKontrol WHERE NoTransaksi = '" & idTransaksi & "'")

            If tblSuratKeterangan.Rows.Count > 0 Then
                Dim rowSurat As DataRow = tblSuratKeterangan.Rows(0)

                Report = New XtraReport
                Report = XtraReport.FromFile(Application.StartupPath + "\Reports\Klinik\SuratKeterangan\SuratKeteranganKontrol.repx", True)

                ' Add Kop Image
                Dim imagePathKopSurat As String = System.IO.Path.Combine(Application.StartupPath, pathKopSurat)
                Dim pictureBoxKopSurat As XRPictureBox = CreateXRPictureBoxReport("Kop Surat", Image.FromFile(imagePathKopSurat), 87, 33, 408, 71)

                Dim Tdata As DataTable = New DataTable
                Tdata = CreateTableSuratKeterangan()
                Tdata.Rows.Clear()

                If tblsRekamMedis.Rows.Count > 0 Then
                    Dim rowData As DataRow = tblsRekamMedis.Rows(0)

                    Dim tglSurat As String = Format(rowSurat("TanggalSurat"), "dd") & " " & BulanIndonesia(Format(rowSurat("TanggalSurat"), "MM")) & " " & Format(rowSurat("TanggalSurat"), "yyyy")
                    Dim diagnosaPasien As String = rowSurat("Diagnosa")
                    Dim tgl As String = Format(rowSurat("Tanggal"), "dd") & " " & BulanIndonesia(Format(rowSurat("Tanggal"), "MM")) & " " & Format(rowSurat("Tanggal"), "yyyy")

                    Dim keteranganDetail As String = "Dianjurkan kontrol rawat jalan pada tanggal " & tgl & " di " & lokasi

                    ' Get Nomor Surat
                    Dim nomorSurat As String = rowSurat("NoSurat")

                    Dim tblsFisik As DataTable = ReadSQL("SELECT * FROM TransaksiDetailFisik WHERE NoTransaksi = '" & idTransaksi & "'")
                    Dim tinggi As String = ""
                    Dim berat As String = ""
                    Dim sistole As String = ""
                    Dim diastole As String = ""
                    Dim suhu As String = ""
                    Dim heartRate As String = ""
                    Dim respiratoryRate As String = ""

                    If tblsFisik.Rows.Count > 0 Then
                        Dim rowFisik As DataRow = tblsFisik.Rows(0)

                        tinggi = rowFisik("Tinggi")
                        berat = rowFisik("Berat")
                        sistole = rowFisik("Sistole")
                        diastole = rowFisik("Diastole")
                        suhu = rowFisik("Suhu")
                        heartRate = rowFisik("HeartRate")
                        respiratoryRate = rowFisik("RespiratoryRate")
                    End If

                    Dim pekerjaanPasien As String = "-"

                    For Each Trow As DataRow In tblsRekamMedis.Rows
                        Dim Tlastnew As DataRow = Tdata.NewRow

                        ' Set Pekerjaan
                        If IsDBNull(Trow("Pekerjaan")) = False Then pekerjaanPasien = Trow("Pekerjaan")

                        Tlastnew("Nama") = Trow("Nama")
                        If Not IsDBNull(Trow("JenisKelamin")) Then
                            Tlastnew("Jenis Kelamin") = "(" & Trow("JenisKelamin").ToString() & ")"
                        Else
                            Tlastnew("Jenis Kelamin") = ""
                        End If

                        If Not IsDBNull(Trow("TglLahir")) Then
                            Dim tglLahir As Date = CDate(Trow("TglLahir"))
                            Tlastnew("TglLahir") = Format(tglLahir, "dd") & " " & BulanIndonesia(tglLahir.Month.ToString("00")) & " " & Format(tglLahir, "yyyy")
                        Else
                            Tlastnew("TglLahir") = ""
                        End If
                        Tlastnew("IDInternet") = Trow("IDInternet")
                        Tlastnew("Alamat") = Trow("DomisiliAlamat")
                        Tlastnew("Diagnosis") = diagnosaPasien

                        Tdata.Rows.Add(Tlastnew)
                    Next

                    Report.DataSource = Tdata
                    Report.Bands.Item(BandKind.PageHeader).Controls("xrLabelNoDokumen").Text = noDocument

                    ' Akses panel yang sudah ada di dalam band Detail menggunakan index
                    Dim panel As XRPanel = CType(Report.Bands(BandKind.PageHeader).Controls(0), XRPanel)

                    ' Cari panel berdasarkan nama di dalam band Detail
                    Dim PanelAlamat As XRPanel = TryCast(Report.Bands(BandKind.PageHeader).Controls("xrPanelAlamat"), XRPanel)

                    ' Input data label
                    PanelAlamat.Controls("xrLabelAlamat").Text = alamatCompany
                    PanelAlamat.Controls("xrLabelNoTelepon").Text = telpCompany

                    Report.Bands.Item(BandKind.Detail).Controls("xrLabelNoSurat").Text = nomorSurat
                    Report.Bands.Item(BandKind.Detail).Controls("xrLabelKeteranganDetail").Text = keteranganDetail
                    'For Each row As DataRow In Tdata.Rows
                    '    Dim detailBand As DetailBand = Report.Bands(BandKind.Detail)

                    '    detailBand.Controls("JenisKelamin").Text = row("Jenis Kelamin").ToString()
                    '    ' set juga field lain jika perlu
                    'Next

                    Report.Bands.Item(BandKind.PageFooter).Controls("xrLabelTgl").Text = namaKota & ", " & tglSurat

                    ' Nonaktifkan jika sudah ada master TTD Dokter
                    Report.Bands.Item(BandKind.PageFooter).Controls("xrPictureBoxTTD").Visible = False

                    ' Add Kop Surat
                    Report.Bands.Item(BandKind.PageHeader).Controls.Add(pictureBoxKopSurat)

                    'Report.RunDesigner()
                    Report.ShowPreview()
                End If
            Else
                MsgBox("Generate surat terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Warning!")
        End Try
    End Sub

    Private Sub GroupBoxPasienRujukan_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBoxPasienRujukan.Enter
        Dim Tbls As DataTable = ReadSQL("SELECT * FROM MasterPasien a LEFT JOIN MasterPasienBPJS b ON a.NoKartuBPJS = b.NoKartu WHERE NoRekamMedis = '" & idPasien & "'")
        Dim Trow As DataRow = Tbls.Rows(0)

        If IsDBNull(Trow("Nama")) = False Then TextBoxNamaPasien.Text = Trow("Nama")

        If Trow("JenisKelamin") = "L" Then
            RadioButton5.Checked = True
        ElseIf Trow("JenisKelamin") = "P" Then
            RadioButton6.Checked = True
        End If

        Dim tglLahirPasien As String = Format(Trow("TglLahir"), "dd") & " " & BulanIndonesia(Format(Trow("TglLahir"), "MM")) & " " & Format(Trow("TglLahir"), "yyyy")
        Dim umurPasien As String = Umur(Trow("TglLahir"))
        TextBoxUmurPasien.Text = umurPasien

        If IsDBNull(Trow("DomisiliAlamat")) = False Then TextBoxAlamat.Text = Trow("DomisiliAlamat")
    End Sub

    Private Sub ComboBoxHubungan_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBoxHubungan.SelectedIndexChanged
        If sedangLoadData Then Exit Sub ' Cegah eksekusi saat loading

        If ComboBoxHubungan.SelectedItem IsNot Nothing Then
            Dim hubungan As String = ComboBoxHubungan.SelectedItem.ToString()

            If hubungan = "Diri Sendiri" Then
                ' Ambil data dari tabel pasien berdasarkan idPasien
                Dim dtPasien As DataTable = ReadSQL("SELECT Nama, JenisKelamin, TglLahir, NoNIK FROM MasterPasien WHERE NoRekamMedis= '" & idPasien & "'")
                If dtPasien.Rows.Count > 0 Then
                    Dim rowPasien As DataRow = dtPasien.Rows(0)

                    TextBoxNama.Text = rowPasien("Nama").ToString()
                    TextBoxNik.Text = rowPasien("NoNIK").ToString()

                    ' Hitung umur dari tanggal lahir
                    Dim tglLahir As Date = Date.Parse(rowPasien("TglLahir"))
                    Dim umur As Integer = DateDiff(DateInterval.Year, tglLahir, Date.Now)
                    TextBoxUmurTtd.Text = umur.ToString()

                    ' Set jenis kelamin
                    If rowPasien("JenisKelamin").ToString() = "L" Then
                        RadioButtonLakiLaki.Checked = True
                    ElseIf rowPasien("JenisKelamin").ToString() = "P" Then
                        RadioButtonPerempuan.Checked = True
                    End If
                End If

            ElseIf hubungan = "Istri" Then
                RadioButtonPerempuan.Checked = True
                TextBoxNama.Clear()
                TextBoxUmurTtd.Clear()
                TextBoxNik.Clear()
            ElseIf hubungan = "Suami" Then
                RadioButtonLakiLaki.Checked = True
                TextBoxNama.Clear()
                TextBoxUmurTtd.Clear()
                TextBoxNik.Clear()
            Else
                TextBoxNama.Clear()
                RadioButtonLakiLaki.Checked = False
                RadioButtonPerempuan.Checked = False
                TextBoxUmurTtd.Clear()
                TextBoxNik.Clear()
            End If
        End If
    End Sub


    Private Sub TextBoxNik_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TextBoxNik.KeyPress
        ' Hanya izinkan angka dan kontrol seperti backspace
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub LoadDataSuratPersetujuan()
        sedangLoadData = True

        Dim dt As DataTable = ReadSQL("SELECT * FROM SuratKeteranganPersetujuanRujukan WHERE NoTransaksi = '" & idTransaksi & "'")
        If dt.Rows.Count > 0 Then
            Dim row As DataRow = dt.Rows(0)

            TextBoxNama.Text = row("NamaTTD").ToString()
            TextBoxUmurTtd.Text = row("UmurTTD").ToString()
            TextBoxNik.Text = row("NoNIK").ToString()
            ComboBoxHubungan.Text = row("Hubungan").ToString()
            TextBoxDiagnosaRujukan.Text = row("Diagnosa").ToString()

            If row("JenisKelamin").ToString() = "L" Then
                RadioButtonLakiLaki.Checked = True
            ElseIf row("JenisKelamin").ToString() = "P" Then
                RadioButtonPerempuan.Checked = True
            End If

            If row("Menyatakan").ToString() = "SETUJU" Then
                RadioButtonSetuju.Checked = True
            ElseIf row("Menyatakan").ToString() = "TIDAK SETUJU" Then
                RadioButtonTidakSetuju.Checked = True
            End If
        End If

        sedangLoadData = False
    End Sub


    Private Sub ButtonSimpanSurat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSimpanSurat.Click
        Try
            ' Validasi semua input wajib
            If ComboBoxHubungan.SelectedItem Is Nothing OrElse ComboBoxHubungan.Text.Trim() = "" Then
                MsgBox("Silakan pilih hubungan dengan pasien.", MsgBoxStyle.Exclamation, "Validasi")
                Exit Sub
            End If

            If TextBoxNama.Text.Trim() = "" Then
                MsgBox("Nama penandatangan belum diisi.", MsgBoxStyle.Exclamation, "Validasi")
                Exit Sub
            End If

            If TextBoxUmurTtd.Text.Trim() = "" Then
                MsgBox("Umur penandatangan belum diisi.", MsgBoxStyle.Exclamation, "Validasi")
                Exit Sub
            End If

            If TextBoxNik.Text.Trim() = "" Then
                MsgBox("NIK penandatangan belum diisi.", MsgBoxStyle.Exclamation, "Validasi")
                Exit Sub
            End If

            Dim nikPattern As String = "^\d{16}$"
            If Not System.Text.RegularExpressions.Regex.IsMatch(TextBoxNik.Text.Trim(), nikPattern) Then
                MsgBox("NIK harus terdiri dari 16 digit angka.", MsgBoxStyle.Exclamation, "Validasi Format NIK")
                Exit Sub
            End If

            If TextBoxDiagnosaRujukan.Text.Trim() = "" Then
                MsgBox("Diagnosa belum diisi.", MsgBoxStyle.Exclamation, "Validasi")
                Exit Sub
            End If

            If Not RadioButtonLakiLaki.Checked AndAlso Not RadioButtonPerempuan.Checked Then
                MsgBox("Silakan pilih jenis kelamin penandatangan.", MsgBoxStyle.Exclamation, "Validasi")
                Exit Sub
            End If

            If Not RadioButtonSetuju.Checked AndAlso Not RadioButtonTidakSetuju.Checked Then
                MsgBox("Silakan pilih pernyataan persetujuan atau tidak setuju.", MsgBoxStyle.Exclamation, "Validasi")
                Exit Sub
            End If

            ' Validasi tambahan dari fungsi ValidasiInputSuratKeterangan
            If Not ValidasiInputSuratKeterangan("SURAT KETERANGAN PERSETUJUAN RUJUKAN") Then
                Exit Sub
            End If

            ' Ambil semua nilai
            Dim tgl As DateTime = DateTimePickerTanggalKontrol.Value.Date
            Dim diagnosa = TextBoxDiagnosaRujukan.Text.Replace("'", "''")
            Dim namaTTD As String = TextBoxNama.Text
            Dim jenisKelamin As String = If(RadioButtonLakiLaki.Checked, "L", "P")
            Dim umurTTD As String = TextBoxUmurTtd.Text
            Dim noNikTTD As String = TextBoxNik.Text
            Dim hubungan As String = ComboBoxHubungan.Text
            Dim menyatakan As String = If(RadioButtonSetuju.Checked, "SETUJU", "TIDAK SETUJU")

            ' Ambil data dokter dari transaksi
            Dim idDokter As String = "", namaDokter As String = "", namaPerawat As String = ""
            Dim dt As DataTable = ReadSQL("SELECT KodeDokter, DokterPoli, PerawatPoli FROM TransaksiPoli WHERE NoUrut = '" & idTransaksi & "'")

            If dt.Rows.Count > 0 Then
                Dim row As DataRow = dt.Rows(0)
                idDokter = row("KodeDokter").ToString()
                namaDokter = row("DokterPoli").ToString()
                namaPerawat = row("PerawatPoli").ToString()
            End If


            ' Cek apakah data sudah ada
            Dim cek As DataTable = ReadSQL("SELECT * FROM SuratKeteranganPersetujuanRujukan WHERE NoTransaksi = '" & idTransaksi & "'")
            If cek.Rows.Count > 0 Then
                ' === UPDATE ===
                Dim sqlUpdate As String = "UPDATE SuratKeteranganPersetujuanRujukan SET " & _
                    "TanggalSurat = GETDATE(), " & _
                    "DokterID = '" & idDokter & "', " & _
                    "DokterNama = '" & namaDokter & "', " & _
                    "PerawatNama = '" & namaPerawat & "', " & _
                    "NamaTTD = '" & namaTTD & "', " & _
                    "JenisKelamin = '" & jenisKelamin & "', " & _
                    "UmurTTD = '" & umurTTD & "', " & _
                    "NoNIK = '" & noNikTTD & "', " & _
                    "Hubungan = '" & hubungan & "', " & _
                    "Menyatakan = '" & menyatakan & "', " & _
                    "Diagnosa = '" & diagnosa & "', " & _
                    "UpdatedBy = '" & userInput & "', " & _
                    "UpdatedDate = GETDATE() " & _
                    "WHERE NoTransaksi = '" & idTransaksi & "'"

                WriteSQL(sqlUpdate, 4)
                MsgBox("Data berhasil diperbarui.", MsgBoxStyle.Information, "Update Berhasil")
            Else
                ' === INSERT ===
                Dim sqlInsert As String = "INSERT INTO SuratKeteranganPersetujuanRujukan " & _
                "(NoTransaksi, NoRekamMedis, TanggalSurat, DokterID, DokterNama, PerawatNama, NamaTTD, JenisKelamin, UmurTTD, NoNIK, Hubungan, Menyatakan, Diagnosa, CreatedBy, CreatedDate) VALUES (" & _
                "'" & idTransaksi & "', '" & idPasien & "', GETDATE(), '" & idDokter & "', '" & namaDokter & "', '" & namaPerawat & "', " & _
                "'" & namaTTD & "', '" & jenisKelamin & "', '" & umurTTD & "', '" & noNikTTD & "', '" & hubungan & "', '" & menyatakan & "', '" & diagnosa & "', '" & userInput & "', GETDATE())"

                WriteSQL(sqlInsert, 4)
                MsgBox("Data berhasil disimpan.", MsgBoxStyle.Information, "Simpan Berhasil")
            End If

        Catch ex As Exception
            MsgBox("Terjadi kesalahan: " & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub ButtonCetakSurat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCetakSurat.Click
        Try
            ' Ambil data pasien
            Dim TblsPasien As DataTable = ReadSQL("SELECT * FROM MasterPasien a LEFT JOIN MasterPasienBPJS b ON a.NoKartuBPJS = b.NoKartu WHERE NoRekamMedis = '" & idPasien & "'")
            If TblsPasien.Rows.Count = 0 Then
                MsgBox("Data pasien tidak ditemukan.", MsgBoxStyle.Exclamation, "Peringatan")
                Exit Sub
            End If

            Dim TrowPasien As DataRow = TblsPasien.Rows(0)
            Dim namaPasien As String = TrowPasien("Nama").ToString()
            Dim jenisKelaminPasien As String = If(TrowPasien("JenisKelamin").ToString() = "L", "Laki-laki", "Perempuan")
            Dim alamatPasien As String = If(IsDBNull(TrowPasien("DomisiliAlamat")), "", TrowPasien("DomisiliAlamat").ToString())
            Dim tglLahirPasienStr As String = ""
            Dim umurPasienStr As String = ""

            If Not IsDBNull(TrowPasien("TglLahir")) Then
                Dim tglLahir As Date = CDate(TrowPasien("TglLahir"))
                tglLahirPasienStr = Format(tglLahir, "dd") & " " & BulanIndonesia(tglLahir.Month.ToString("00")) & " " & Format(tglLahir, "yyyy")
                umurPasienStr = Umur(tglLahir)
            End If

            ' Ambil konfigurasi
            Dim namaKota As String = ReadSQLNIK("SELECT StrValue FROM msconfig WHERE configname = 'Kota'")
            Dim alamatCompany As String = ReadSQLNIK("SELECT StrValue FROM msconfig WHERE configname = 'AlamatCompany'")

            ' Ambil data surat
            Dim tblSurat As DataTable = ReadSQL("SELECT * FROM SuratKeteranganPersetujuanRujukan WHERE NoTransaksi = '" & idTransaksi & "'")
            If tblSurat.Rows.Count = 0 Then
                MsgBox("Generate surat terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
                Exit Sub
            End If

            Dim rowSurat As DataRow = tblSurat.Rows(0)

            ' Siapkan Report
            Report = New XtraReport
            Report = XtraReport.FromFile(Application.StartupPath + "\Reports\Klinik\SuratKeterangan\SuratPersetujuanRujukan.repx", True)

            ' Buat tabel data untuk report
            Dim Tdata As New DataTable()
            With Tdata.Columns
                .Add("NamaPasien")
                .Add("AlamatPasien")
                .Add("JenisKelaminPasien")
                .Add("TglLahirPasien")
                .Add("UmurPasien")
                .Add("Nama")
                .Add("Umur")
                .Add("NoNIK")
                .Add("Hubungan")
                .Add("JenisKelamin")
                .Add("Menyatakan")
                .Add("Diagnosis")
                .Add("Kota")
                .Add("Tanggal")
                .Add("DokterNama")
                .Add("PerawatNama")
            End With

            Dim Trow As DataRow = Tdata.NewRow()

            ' Isi data pasien
            Trow("NamaPasien") = namaPasien
            Trow("AlamatPasien") = alamatPasien
            Trow("JenisKelaminPasien") = jenisKelaminPasien
            Trow("TglLahirPasien") = tglLahirPasienStr
            Trow("UmurPasien") = umurPasienStr

            ' Isi data surat
            Trow("Nama") = rowSurat("NamaTTD")
            Trow("Umur") = rowSurat("UmurTTD")
            Trow("NoNIK") = rowSurat("NoNIK")
            Trow("Hubungan") = rowSurat("Hubungan") & " dari"
            Trow("JenisKelamin") = If(rowSurat("JenisKelamin") = "L", "Laki-laki", "Perempuan")
            Trow("Menyatakan") = rowSurat("Menyatakan")
            Trow("Diagnosis") = rowSurat("Diagnosa")
            Trow("Kota") = namaKota & ","
            Trow("DokterNama") = "( " & rowSurat("DokterNama") & " )"
            Trow("PerawatNama") = "( " & rowSurat("PerawatNama") & " )"

            If Not IsDBNull(rowSurat("TanggalSurat")) Then
                Dim tanggal As Date = CDate(rowSurat("TanggalSurat"))
                Trow("Tanggal") = Format(tanggal, "dd") & " " & BulanIndonesia(tanggal.Month.ToString("00")) & " " & Format(tanggal, "yyyy")
            Else
                Trow("Tanggal") = ""
            End If

            Tdata.Rows.Add(Trow)

            ' Set DataSource ke Report
            Report.DataSource = Tdata

            ' Set Alamat Klinik di header
            Dim PanelAlamat As XRPanel = TryCast(Report.Bands(BandKind.PageHeader).Controls("xrPanelAlamat"), XRPanel)
            If PanelAlamat IsNot Nothing Then
                PanelAlamat.Controls("xrLabelAlamat").Text = alamatCompany
            End If

            ' Tampilkan laporan
            'Report.RunDesigner()
            Report.ShowPreview()

        Catch ex As Exception
            MsgBox("Terjadi kesalahan saat mencetak surat: " & ex.Message, MsgBoxStyle.Exclamation, "Error")
        End Try
    End Sub

    Private Sub butfindcompany_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butfindcompany.Click
        Dim frmFind As New Find
        frmFind.Query("SELECT IDCompany, CompanyCode, CompanyNama, NoCompany FROM mastercompany a", " ORDER BY a.idcompany desc", "FindCabangSuratRujukan", 2)
        frmFind.Show()
    End Sub

    Private Sub ButtonTambahRujukanBPJS_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTambahRujukanBPJS.Click
        FindFaskesRujukan.SetRujukan("FaskesRujukanKondisiKhusus", noBPJS, ComboBoxStatusPulang.Text)
        FindFaskesRujukan.ShowDialog()
    End Sub

    Private Sub ButtonTambahTACC_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTambahTACC.Click
        Dim tblsDiagnosa As DataTable = ReadSQL("SELECT * FROM TransaksiDetailDiagnosa WHERE NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL")

        ' Validasi input diagnosa
        If tblsDiagnosa.Rows.Count > 0 Then
            For Each trowDiagnosa As DataRow In tblsDiagnosa.Rows
                If trowDiagnosa("DiagnosaNonSpesialistik") = True Then
                    FindRujukanTACC.SetForm("RekamMedisDokterRujukanTACC")
                    FindRujukanTACC.ShowDialog()

                    LabelNonSpesialistik.Visible = True
                End If
            Next
        Else
            MsgBox("Diagnosa pasien tidak membutuhkan TACC.", MsgBoxStyle.Exclamation, "Warning!")
        End If
    End Sub

    Private Sub BtnCetakNonBPJS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCetakNonBPJS.Click
        Try
            ' Cek data sudah ada / tidak
            If CheckSQL("SELECT * FROM TransaksiDetailRujukanNonBPJS WHERE NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL") = False Then
                MsgBox("Input rujukan di RME terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
                Exit Sub
            End If

            Dim dt As DataTable = ReadSQL("SELECT * FROM TransaksiDetailRujukanNonBPJS WHERE NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL")
            Dim tblsReport As New DataTable()
            tblsReport.Columns.Add("NoTransaksi")
            tblsReport.Columns.Add("Klinik")
            tblsReport.Columns.Add("NoRujukan")
            tblsReport.Columns.Add("KeRS")
            tblsReport.Columns.Add("TanggalRujukan")
            tblsReport.Columns.Add("NamaPenderita")
            tblsReport.Columns.Add("StatusHubungan")
            tblsReport.Columns.Add("JenisKelamin")
            tblsReport.Columns.Add("NamaPeserta")
            tblsReport.Columns.Add("Perusahaan")
            tblsReport.Columns.Add("NamaKartuPeserta")
            tblsReport.Columns.Add("Anamnesa")
            tblsReport.Columns.Add("PemeriksaanFisik")
            tblsReport.Columns.Add("DiagnosaSementara")
            tblsReport.Columns.Add("TerapiSementara")
            tblsReport.Columns.Add("CreatedDate")
            tblsReport.Columns.Add("Poli")

            ' Ambil data pasien (termasuk TglLahir)
            Dim sql As String = "SELECT MP.* FROM TransaksiDetail TD JOIN MasterPasien MP ON TD.IDInternet = MP.NoRekamMedis WHERE TD.NoUrut = '" & idTransaksi & "'"
            Dim dtPasien As DataTable = ReadSQL(sql)

            Dim umur As Integer = 0
            If dtPasien.Rows.Count > 0 Then
                Dim tglLahirStr As String = dtPasien.Rows(0)("TglLahir").ToString()
                Dim tglLahir As Date = Date.Parse(tglLahirStr)
                umur = GetCurrentAge(tglLahir)
            End If

            ' Tambahkan kolom Umur ke tblsReport
            tblsReport.Columns.Add("Umur")

            ' Ambil nama kota
            Dim sqlKota As String = "SELECT StrValue FROM MSConfig WHERE ConfigName = 'kota'"
            Dim dtKota As DataTable = ReadSQL(sqlKota)

            Dim kota As String = ""
            If dtKota.Rows.Count > 0 Then
                kota = dtKota.Rows(0)("StrValue").ToString()
            End If

            tblsReport.Columns.Add("Kota")

            Dim culture As New CultureInfo("id-ID")

            For Each r As DataRow In dt.Rows
                Dim rowReport As DataRow = tblsReport.NewRow()
                rowReport("NoTransaksi") = r("NoTransaksi").ToString()
                rowReport("Klinik") = r("Klinik").ToString()
                rowReport("NoRujukan") = r("NoRujukan").ToString()
                rowReport("KeRS") = r("KeRS").ToString()
                rowReport("TanggalRujukan") = CDate(r("TanggalRujukan")).ToString("dd MMM yyyy", culture)
                rowReport("NamaPenderita") = r("NamaPenderita").ToString()
                rowReport("StatusHubungan") = r("StatusHubungan").ToString()
                rowReport("JenisKelamin") = "(" & r("JenisKelamin").ToString() & ")"
                rowReport("NamaPeserta") = r("NamaPeserta").ToString()
                rowReport("Perusahaan") = r("Perusahaan").ToString()
                rowReport("NamaKartuPeserta") = r("NamaKartuPeserta").ToString()
                rowReport("Anamnesa") = r("Anamnesa").ToString()
                rowReport("PemeriksaanFisik") = r("PemeriksaanFisik").ToString()
                rowReport("DiagnosaSementara") = r("DiagnosaSementara").ToString()
                rowReport("TerapiSementara") = r("TerapiSementara").ToString()
                rowReport("Umur") = umur.ToString() & " Tahun"
                rowReport("CreatedDate") = CDate(r("CreatedDate")).ToString("dd MM yyyy", culture)
                rowReport("Kota") = kota.ToString() & ","
                rowReport("Poli") = r("Poli").ToString()

                tblsReport.Rows.Add(rowReport)
            Next

            Report = New XtraReport
            Report = XtraReport.FromFile(Application.StartupPath + "\reports\Klinik\SuratKeterangan\SuratKeteranganRujukanNonBPJS.repx", True)
            Report.DataSource = tblsReport
            'Report.Bands.Item(BandKind.TopMargin).Controls("lbljenissetoran").Text = "Surat Rujukan FKTP"

            'Report.RunDesigner()
            Report.ShowPreview()
            'Report.Print()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub MuatKeteranganKeComboBox()
        ' Ambil JenisPoli dari TransaksiDetail
        Dim dtPoli As DataTable = ReadSQL("SELECT JenisPoli FROM TransaksiDetail WHERE NoUrut = '" & idTransaksi.Replace("'", "''") & "'")
        Dim ambilPoli As String = ""

        If dtPoli.Rows.Count > 0 Then
            ambilPoli = dtPoli.Rows(0)("JenisPoli").ToString()
        Else
            MessageBox.Show("Jenis poli tidak ditemukan untuk transaksi ini.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        ' Filter berdasarkan NoRM dan JenisPoli (Kategori)
        Dim dt As DataTable = ReadSQL("SELECT DISTINCT Keterangan FROM UploadGambar WHERE NoRM = '" & idPasien.Replace("'", "''") & "' AND Kategori = '" & ambilPoli.Replace("'", "''") & "' AND Deleted = 0")

        ComboBoxKeterangan.Items.Clear()

        For Each row As DataRow In dt.Rows
            ComboBoxKeterangan.Items.Add(row("Keterangan").ToString())
        Next

        ' Optional: reset pilihan sebelumnya
        ComboBoxKeterangan.SelectedIndex = -1
    End Sub

    Private Sub ButtonSimpanGambar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSimpanGambar.Click
        Dim nilaiPemeriksaan As String = ""

        If RadioButtonBefore.Checked Then
            nilaiPemeriksaan = "Before"
        ElseIf RadioButtonAfter.Checked Then
            nilaiPemeriksaan = "After"
        Else
            MessageBox.Show("Silakan pilih jenis pemeriksaan: Before atau After.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If PBGambar.Tag Is Nothing Then
            MessageBox.Show("Silakan upload gambar terlebih dahulu.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If TextBoxKeterangan.Text.Trim() = "" Or TextBoxKeterangan.Text = placeholderText Then
            MessageBox.Show("Silakan isi keterangan gambar.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim dtCek As DataTable = ReadSQL("SELECT COUNT(*) AS Jumlah FROM UploadGambar WHERE Keterangan = '" & TextBoxKeterangan.Text.Replace("'", "''") & "' AND Deleted = 0")
        If dtCek.Rows(0)("Jumlah") > 0 Then
            MessageBox.Show("Keterangan sudah digunakan. Harap gunakan keterangan lain.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        'Simpan folder 
        Dim folderPath As String = Application.StartupPath & "\Uploads\FotoPemeriksaan"
        If Not IO.Directory.Exists(folderPath) Then
            IO.Directory.CreateDirectory(folderPath)
        End If

        ' Buat nama file unik untuk menghindari konflik
        Dim ekstensi As String = IO.Path.GetExtension(PBGambar.Tag.ToString())
        Dim namaFileUnik As String = Guid.NewGuid().ToString() & ekstensi
        Dim targetPath As String = IO.Path.Combine(folderPath, namaFileUnik)

        ' Salin gambar ke folder Uploads
        IO.File.Copy(PBGambar.Tag.ToString(), targetPath, True)

        ' Path relatif yang akan disimpan di database
        Dim namaGambar As String = TextBoxKeterangan.Text
        Dim fotoPath As String = "Uploads\FotoPemeriksaan\" & namaFileUnik
        Dim keterangan As String = TextBoxKeterangan.Text

        Dim dt As DataTable = ReadSQL("SELECT JenisPoli FROM TransaksiDetail WHERE NoUrut = '" & idTransaksi & "'")

        Dim ambilPoli As String = ""
        If dt.Rows.Count > 0 Then
            ambilPoli = dt.Rows(0)("JenisPoli").ToString()
        End If

        ' Tentukan Jenis (Umum/Lab)
        Dim jenisGambar As String = "Umum" ' default
        If RbJenisLab.Checked Then
            jenisGambar = "LAB"
        ElseIf RbJenisUmum.Checked Then
            jenisGambar = "Umum"
        End If

        ' Simpan ke database
        WriteSQL("INSERT INTO UploadGambar (NoUrut, NoRM, FotoPath, Kategori, Keterangan, Pemeriksaan, CreatedBy, CreatedDate, Deleted, Jenis) " & _
         "VALUES ('" & idTransaksi & "', '" & idPasien & "', '" & fotoPath & "', '" & ambilPoli & "', '" & keterangan & "', '" & nilaiPemeriksaan & "', '" & userInput & "', GETDATE(), 0, '" & jenisGambar & "')", 4)

        ' Refresh ComboBox setelah simpan
        MuatKeteranganKeComboBox()

        ' (Opsional) Set ke keterangan baru otomatis
        ComboBoxKeterangan.SelectedItem = namaGambar

        MessageBox.Show("Gambar berhasil disimpan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Dim placeholderText As String = "Masukkan keterangan gambar"

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        MuatKeteranganKeComboBox()
        TextBoxKeterangan.Text = placeholderText
        TextBoxKeterangan.ForeColor = Color.Gray
        RbJenisUmum.Checked = True
    End Sub

    Private Sub TextBoxKeterangan_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If TextBoxKeterangan.Text = placeholderText Then
            TextBoxKeterangan.Text = ""
            TextBoxKeterangan.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TextBoxKeterangan_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        If TextBoxKeterangan.Text = "" Then
            TextBoxKeterangan.Text = placeholderText
            TextBoxKeterangan.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub BtnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpload.Click
        Dim openFile As New OpenFileDialog()
        openFile.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png"

        If openFile.ShowDialog() = DialogResult.OK Then
            Dim originalFilePath As String = openFile.FileName

            ' Cek ukuran file (dalam byte)
            Dim fileInfo As New IO.FileInfo(originalFilePath)
            Dim maxFileSize As Long = 1572864 ' 1.5 MB

            If fileInfo.Length > maxFileSize Then
                MessageBox.Show("Ukuran file terlalu besar. Maksimal 1 MB.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' Cek resolusi gambar (minimal 600x600)
            Using img As Image = Image.FromFile(originalFilePath)
                If img.Width < 600 Or img.Height < 600 Then
                    MessageBox.Show("Resolusi gambar terlalu kecil. Minimal 600x600 piksel.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                ' Tampilkan gambar jika lolos semua pengecekan
                PBGambar.Image = CType(img.Clone(), Image) ' Clone agar tidak lock file
            End Using

            ' Jika lolos ukuran, tampilkan gambar
            PBGambar.Tag = originalFilePath
            PBGambar.SizeMode = PictureBoxSizeMode.Zoom
        End If
    End Sub

    Private Sub TampilkanGambar(ByVal keterangan As String, ByVal noRM As String, ByVal jenisPoli As String)
        Dim dt As DataTable = ReadSQL("SELECT FotoPath FROM UploadGambar WHERE " & _
                              "Keterangan = '" & keterangan.Replace("'", "''") & "' " & _
                              "AND NoRM = '" & noRM.Replace("'", "''") & "' " & _
                              "AND Kategori = '" & jenisPoli.Replace("'", "''") & "' " & _
                              "AND Deleted = 0")

        If dt.Rows.Count > 0 Then
            Dim fotoPath As String = dt.Rows(0)("FotoPath").ToString()
            Dim fullPath As String = System.IO.Path.Combine(Application.StartupPath, fotoPath)

            If IO.File.Exists(fullPath) Then
                PictureBoxPreview.Image = Image.FromFile(fullPath)
                PictureBoxPreview.SizeMode = PictureBoxSizeMode.Zoom
            Else
                PictureBoxPreview.Image = Nothing
                MessageBox.Show("File gambar tidak ditemukan di folder Uploads.")
            End If
        Else
            PictureBoxPreview.Image = Nothing
            MessageBox.Show("Data gambar tidak ditemukan.")
        End If
    End Sub

    Private Sub ComboBoxKeterangan_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxKeterangan.SelectedIndexChanged
        If ComboBoxKeterangan.SelectedIndex <> -1 Then
            Dim keteranganDipilih As String = ComboBoxKeterangan.SelectedItem.ToString()

            ' Ambil JenisPoli dari TransaksiDetail
            Dim dtPoli As DataTable = ReadSQL("SELECT JenisPoli FROM TransaksiDetail WHERE NoUrut = '" & idTransaksi.Replace("'", "''") & "'")
            Dim ambilPoli As String = ""

            If dtPoli.Rows.Count > 0 Then
                ambilPoli = dtPoli.Rows(0)("JenisPoli").ToString()
            Else
                MessageBox.Show("Jenis poli tidak ditemukan untuk transaksi ini.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            ' Panggil fungsi yang sudah diperbarui
            TampilkanGambar(keteranganDipilih, idPasien, ambilPoli)
        End If
    End Sub

    Private Sub ButtonDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDelete.Click
        If ComboBoxKeterangan.SelectedIndex = -1 Then
            MessageBox.Show("Silakan pilih keterangan gambar yang ingin dihapus.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim keteranganDipilih As String = ComboBoxKeterangan.SelectedItem.ToString()

        ' Konfirmasi
        Dim hasil As DialogResult = MessageBox.Show("Apakah Anda yakin ingin menghapus gambar ini?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If hasil = DialogResult.No Then Exit Sub

        ' Ambil path file dari database
        Dim dtGambar As DataTable = ReadSQL("SELECT FotoPath FROM UploadGambar WHERE NoRM = '" & idPasien.Replace("'", "''") & "' AND Keterangan = '" & keteranganDipilih.Replace("'", "''") & "' AND Deleted = 0")

        If dtGambar.Rows.Count = 0 Then
            MessageBox.Show("Gambar tidak ditemukan atau sudah dihapus.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim pathFile As String = dtGambar.Rows(0)("FotoPath").ToString()

        ' Update kolom Deleted di database
        Try
            WriteSQL("UPDATE UploadGambar SET Deleted = 1 WHERE NoRM = '" & idPasien.Replace("'", "''") & "' AND Keterangan = '" & keteranganDipilih.Replace("'", "''") & "'", 2)
        Catch ex As Exception
            MessageBox.Show("Gagal update data di database: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try

        MessageBox.Show("Gambar berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' Refresh ComboBox dan gambar
        ComboBoxKeterangan.Items.Remove(keteranganDipilih)
        ComboBoxKeterangan.SelectedIndex = -1
        PictureBoxPreview.Image = Nothing
    End Sub


    Private Sub FormatDataGridViewRiwayatGambar()
        With DataGridViewRiwayatGambar
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .MultiSelect = False
            .RowHeadersVisible = False

            ' Font umum isi
            .DefaultCellStyle.Font = New Font("Segoe UI", 10)
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            ' Style Header
            .EnableHeadersVisualStyles = False ' Penting agar warna kustom bisa tampil
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 100, 200)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        End With
    End Sub

    Private Sub CreateDataGridViewGambarPoli()
        With DataGridViewRiwayatGambar
            .Columns.Clear()
            .Rows.Clear()
            .AllowUserToAddRows = False
            .RowTemplate.Height = 40

            Dim imgColumn As New DataGridViewImageColumn()
            imgColumn.HeaderText = "Gambar"
            imgColumn.Name = "ColumnGambar"
            imgColumn.ImageLayout = DataGridViewImageCellLayout.Zoom
            .Columns.Add(imgColumn)

            .Columns.Add("ColumnNoTransaksi", "No Transaksi")
            .Columns.Add("ColumnKeterangan", "Keterangan")
            .Columns.Add("ColumnPemeriksaan", "Pemeriksaan")
            .Columns.Add("ColumnKategori", "Jenis Poli")
            .Columns.Add("ColumnTanggal", "Tanggal Upload")
            .Columns.Add("ColumnCreatedBy", "Diupload Oleh")

            Dim btnColumn As New DataGridViewButtonColumn()
            btnColumn.HeaderText = "Aksi"
            btnColumn.Name = "ButtonBandingkan"
            btnColumn.Text = "Bandingkan"
            btnColumn.UseColumnTextForButtonValue = True
            btnColumn.FlatStyle = FlatStyle.Standard
            .Columns.Add(btnColumn)
        End With
    End Sub

    Private Sub DataGridViewRiwayatGambar_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridViewRiwayatGambar.CellClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = DataGridViewRiwayatGambar.Columns("ButtonBandingkan").Index Then
            ' Ambil No Transaksi
            Dim idTransaksi As String = DataGridViewRiwayatGambar.Rows(e.RowIndex).Cells("ColumnNoTransaksi").Value.ToString()

            ' Ambil gambar dari sel gambar (pastikan ini image)
            Dim gambarObj As Object = DataGridViewRiwayatGambar.Rows(e.RowIndex).Cells("ColumnGambar").Value

            If gambarObj IsNot Nothing AndAlso TypeOf gambarObj Is Image Then
                Dim gambar As Image = DirectCast(gambarObj, Image)

                ' Tampilkan FormBandingGambar dan kirim gambar
                Dim formBanding As New FormBandingGambar(idTransaksi, idPasien)
                formBanding.TampilkanGambar(gambar)
                formBanding.ShowDialog()
            Else
                MessageBox.Show("Gambar tidak ditemukan untuk No Transaksi: " & idTransaksi, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Public Sub GetRiwayatGambar()
        DataGridViewRiwayatGambar.Rows.Clear()
        DataGridViewRiwayatGambar.Columns.Clear()

        ' Format tanggal
        Dim Tawal As String = Format(TglAwalRiwayatGambar.Value, "yyyy-MM-dd")
        Dim Takhir As String = Format(TglAkhirRiwayatGambar.Value, "yyyy-MM-dd")

        ' Filter Poli jika dipilih
        Dim queryFilterPoli As String = ""
        If ComboBoxPoliGambar.Text <> "SEMUA TRANSAKSI" Then
            queryFilterPoli = " AND Kategori = '" & ComboBoxPoliGambar.Text.Replace("'", "''") & "'"
        End If

        ' Query ambil riwayat gambar
        Dim query As String = "SELECT NoUrut, NoRM, Keterangan, Pemeriksaan, Kategori, FotoPath, CreatedDate, CreatedBy " & _
                      "FROM UploadGambar " & _
                      "WHERE Deleted = 0 " & _
                      "AND NoRM = '" & idPasien.Replace("'", "''") & "' " & _
                      "AND CONVERT(date, CreatedDate) BETWEEN '" & Tawal & "' AND '" & Takhir & "' " & _
                      queryFilterPoli & " " & _
                      "ORDER BY CreatedDate DESC"

        Dim dt As DataTable = ReadSQL(query)

        If dt.Rows.Count > 0 Then
            ' Buat kolom DataGridView secara manual
            CreateDataGridViewGambarPoli()

            ' Masukkan data
            For Each row As DataRow In dt.Rows
                Dim img As Image = Nothing
                Dim path As String = Application.StartupPath & "\" & row("FotoPath").ToString()

                If IO.File.Exists(path) Then
                    img = Image.FromFile(path)
                Else
                    img = New Bitmap(100, 100) ' Placeholder kosong jika file tidak ada
                End If

                DataGridViewRiwayatGambar.Rows.Add(img, row("NoUrut").ToString(), row("Keterangan").ToString(), row("Pemeriksaan").ToString(), row("Kategori").ToString(), Convert.ToDateTime(row("CreatedDate")).ToString("yyyy-MM-dd HH:mm"), row("CreatedBy").ToString())
            Next

            FormatDataGridViewRiwayatGambar()
        Else
            DataGridViewRiwayatGambar.Rows.Clear()
            DataGridViewRiwayatGambar.Columns.Clear()
            MessageBox.Show("Tidak ada data gambar yang ditemukan untuk periode ini.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ButtonCariRiwayatGambar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCariRiwayatGambar.Click
        Try
            If ComboBoxPoliGambar.SelectedIndex <> -1 Then
                GetRiwayatGambar()
            Else
                MsgBox("Pilih poli tujuan terlebih dahulu.", MsgBoxStyle.Critical, "Warning!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub FormatDataGridViewRiwayatSurat()
        With DataGridViewRiwayatSurat
            ' Auto format dan tampilan dasar
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .ReadOnly = True
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .MultiSelect = False
            .RowHeadersVisible = False

            ' Style isi sel
            .DefaultCellStyle.Font = New Font("Segoe UI", 10)
            .DefaultCellStyle.WrapMode = DataGridViewTriState.True
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft

            ' Style Header
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 100, 200)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            ' Gaya baris selang-seling
            .AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke

            ' Warna seleksi (opsional)
            .DefaultCellStyle.SelectionBackColor = Color.LightBlue
            .DefaultCellStyle.SelectionForeColor = Color.Black
        End With
    End Sub

    Private Sub CreateDataGridViewRiwayatSurat()
        With DataGridViewRiwayatSurat
            .Columns.Clear()
            .Rows.Clear()

            ' Kolom sesuai dengan hasil query surat
            .Columns.Add("ColumnNoTransaksi", "No Transaksi")
            .Columns.Add("ColumnNoSurat", "No Surat")
            .Columns.Add("ColumnJenisSurat", "Jenis Surat")
            .Columns.Add("ColumnDokter", "Dokter")
            .Columns.Add("ColumnKeterangan", "Keterangan")
        End With
    End Sub

    Public Sub GetRiwayatSurat()
        ' Format tanggal
        Dim Tawal As String = Format(TglAwalRiwayatSurat.Value, "yyyy-MM-dd")
        Dim Takhir As String = Format(TglAkhirRiwayatSurat.Value, "yyyy-MM-dd")
        Dim noRekamMedis As String = idPasien ' Pastikan idPasien tidak kosong

        ' SQL Query
        Dim query As String = _
            "SELECT NoTransaksi, NoSurat, JenisSurat, Dokter, Keterangan FROM (" & _
            "SELECT sb.NoTransaksi, sb.NoSurat, 'Surat Keterangan Berobat' AS JenisSurat, sb.DokterNama AS Dokter, sb.Diagnosa AS Keterangan " & _
            "FROM SuratKeteranganBerobat sb " & _
            "WHERE sb.NoRekamMedis = '" & noRekamMedis & "' AND sb.TanggalSurat BETWEEN '" & Tawal & "' AND '" & Takhir & "' " & _
            "UNION ALL " & _
            "SELECT si.NoTransaksi, si.NoSurat, 'Surat Keterangan Istirahat' AS JenisSurat, si.DokterNama, si.Diagnosa " & _
            "FROM SuratKeteranganIstirahat si " & _
            "WHERE si.NoRekamMedis = '" & noRekamMedis & "' AND si.TanggalSurat BETWEEN '" & Tawal & "' AND '" & Takhir & "' " & _
            "UNION ALL " & _
            "SELECT sd.NoTransaksi, sd.NoSurat, 'Surat Keterangan Dokter' AS JenisSurat, sd.DokterNama, sd.Tujuan " & _
            "FROM SuratKeteranganDokter sd " & _
            "WHERE sd.NoRekamMedis = '" & noRekamMedis & "' AND sd.TanggalSurat BETWEEN '" & Tawal & "' AND '" & Takhir & "' " & _
            "UNION ALL " & _
            "SELECT ch.NoTransaksi, ch.NoSurat, 'Surat Keterangan Cuti Hamil' AS JenisSurat, ch.DokterNama, ch.UsiaKehamilan " & _
            "FROM SuratKeteranganCutiHamil ch " & _
            "WHERE ch.NoRekamMedis = '" & noRekamMedis & "' AND ch.TanggalSurat BETWEEN '" & Tawal & "' AND '" & Takhir & "' " & _
            "UNION ALL " & _
            "SELECT sk.NoTransaksi, sk.NoSurat, 'Surat Keterangan Kematian' AS JenisSurat, sk.DokterNama, sk.Diagnosa " & _
            "FROM SuratKeteranganKematian sk " & _
            "WHERE sk.NoRekamMedis = '" & noRekamMedis & "' AND sk.TanggalSurat BETWEEN '" & Tawal & "' AND '" & Takhir & "' " & _
            "UNION ALL " & _
            "SELECT ko.NoTransaksi, ko.NoSurat, 'Surat Keterangan Kontrol' AS JenisSurat, ko.DokterNama, ko.Diagnosa " & _
            "FROM SuratKeteranganKontrol ko " & _
            "WHERE ko.NoRekamMedis = '" & noRekamMedis & "' AND ko.TanggalSurat BETWEEN '" & Tawal & "' AND '" & Takhir & "' " & _
            "UNION ALL " & _
            "SELECT lt.NoTransaksi, lt.NoSurat, 'Surat Keterangan Layak Terbang' AS JenisSurat, lt.DokterNama, lt.Diagnosa " & _
            "FROM SuratKeteranganLayakTerbang lt " & _
            "WHERE lt.NoRekamMedis = '" & noRekamMedis & "' AND lt.TanggalSurat BETWEEN '" & Tawal & "' AND '" & Takhir & "' " & _
            ") AS RiwayatSurat " & _
            "ORDER BY NoTransaksi"

        ' Eksekusi dan tampilkan data
        Dim dt As DataTable = ReadSQL(query)
        DataGridViewRiwayatSurat.DataSource = dt

        ' Format tampilannya setelah assign data
        FormatDataGridViewRiwayatSurat()
    End Sub

    Private Sub ButtonCariRiwayatSurat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCariRiwayatSurat.Click
        Try
            GetRiwayatSurat()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Public Sub GetDataPaketHeader()
        Dim tglAwal As String = Format(DtAwalPaket.Value, "yyyyMMdd")
        Dim tglAkhir As String = Format(DtAkhirPaket.Value, "yyyyMMdd")
        Dim noRM As String = idPasien
        Dim jenisPaket As String = ""

        If RadioButtonReguler.Checked Then
            jenisPaket = "Paket Reguler"
        ElseIf RadioButtonPerTindakan.Checked Then
            jenisPaket = "Paket Per-Tindakan"
        End If

        Dim query As New System.Text.StringBuilder()

        If jenisPaket = "Paket Reguler" Then
            query.AppendLine("SELECT ")
            query.AppendLine("    tblPasien.Nama, ")
            query.AppendLine("    tblPaket.NoRekamMedis AS [No RM], ")
            query.AppendLine("    tblPaket.NoTransaksi AS [No Transaksi], ")
            query.AppendLine("    tblPaket.NamaPaket AS [Nama Paket], ")
            query.AppendLine("    STUFF(( ")
            query.AppendLine("        SELECT ', ' + tblPaketDetail.NamaTindakan ")
            query.AppendLine("        FROM TransaksiPaketTindakanDetail tblPaketDetail ")
            query.AppendLine("        WHERE tblPaketDetail.PaketID = tblPaket.PaketID ")
            query.AppendLine("          AND tblPaketDetail.KodeVoucher = tblPaket.KodeVoucher ")
            query.AppendLine("        FOR XML PATH(''), TYPE).value('.', 'NVARCHAR(MAX)') ")
            query.AppendLine("    , 1, 2, '') AS [Nama Tindakan], ")
            query.AppendLine("    tblPaket.JenisPaket AS [Jenis Paket], ")
            query.AppendLine("    tblPaket.Kuota, ")
            query.AppendLine("    tblPaket.TanggalMulaiPaket AS [Tgl Mulai], ")
            query.AppendLine("    tblPaket.TanggalAkhirPaket AS [Tgl Berakhir], ")
            query.AppendLine("    tblPaket.PaketID, ")
            query.AppendLine("    tblPaket.KodeVoucher, ")
            query.AppendLine("    0 AS [TindakanID] ")
            query.AppendLine("FROM TransaksiPaketTindakan tblPaket ")
            query.AppendLine("LEFT JOIN MasterPasien tblPasien ON tblPasien.NoRekamMedis = tblPaket.NoRekamMedis ")
            query.AppendLine("WHERE tblPaket.JenisPaket = 'Paket Reguler' ")

            If noRM <> "" Then
                query.AppendLine("AND tblPaket.NoRekamMedis = '" & noRM & "' ")
            End If

            query.AppendLine("AND CONVERT(DATE, tblPaket.TanggalMulaiPaket) BETWEEN '" & tglAwal & "' AND '" & tglAkhir & "' ")
            query.AppendLine("AND tblPaket.DeletedDate IS NULL ")
            query.AppendLine("ORDER BY tblPaket.PaketID")

        ElseIf jenisPaket = "Paket Per-Tindakan" Then
            query.AppendLine("SELECT ")
            query.AppendLine("    tblPasien.Nama, ")
            query.AppendLine("    tblPaket.NoRekamMedis AS [No RM], ")
            query.AppendLine("    tblPaket.NamaPaket AS [Nama Paket], ")
            query.AppendLine("    tblPaketDetail.NamaTindakan AS [Nama Tindakan], ")
            query.AppendLine("    tblPaket.JenisPaket AS [Jenis Paket], ")
            query.AppendLine("    tblPaketDetail.KuotaTindakan AS [Kuota], ")
            query.AppendLine("    tblPaket.TanggalMulaiPaket AS [Tgl Mulai], ")
            query.AppendLine("    tblPaket.TanggalAkhirPaket AS [Tgl Berakhir], ")
            query.AppendLine("    tblPaket.PaketID, ")
            query.AppendLine("    tblPaket.KodeVoucher, ")
            query.AppendLine("    tblPaketDetail.TindakanID ")
            query.AppendLine("FROM TransaksiPaketTindakanDetail tblPaketDetail ")
            query.AppendLine("LEFT JOIN TransaksiPaketTindakan tblPaket ")
            query.AppendLine("    ON tblPaket.PaketID = tblPaketDetail.PaketID ")
            query.AppendLine("    AND tblPaket.KodeVoucher = tblPaketDetail.KodeVoucher ")
            query.AppendLine("LEFT JOIN MasterPasien tblPasien ")
            query.AppendLine("    ON tblPasien.NoRekamMedis = tblPaket.NoRekamMedis ")
            query.AppendLine("WHERE tblPaket.JenisPaket = 'Paket Per-Tindakan' ")

            If noRM <> "" Then
                query.AppendLine("AND tblPaket.NoRekamMedis = '" & noRM & "' ")
            End If

            query.AppendLine("AND CONVERT(DATE, tblPaket.TanggalMulaiPaket) BETWEEN '" & tglAwal & "' AND '" & tglAkhir & "' ")
            query.AppendLine("AND tblPaket.DeletedDate IS NULL ")
            query.AppendLine("ORDER BY tblPaket.PaketID, tblPaketDetail.TindakanID")
        End If

        Dim dt As DataTable = ReadSQL(query.ToString())

        If dt.Rows.Count = 0 Then
            MessageBox.Show("Data tidak ditemukan untuk jenis paket " & jenisPaket, "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)

            DataGridViewPaket.DataSource = Nothing
            DataGridViewPaket.Rows.Clear()
            DataGridViewPaket.Columns.Clear()
            Return ' Keluar dari Sub agar tidak lanjut styling dll
        End If

        DataGridViewPaket.DataSource = dt

        ' Sembunyikan kolom asli tanggal
        If DataGridViewPaket.Columns.Contains("Tgl Mulai") Then DataGridViewPaket.Columns("Tgl Mulai").Visible = False
        If DataGridViewPaket.Columns.Contains("Tgl Berakhir") Then DataGridViewPaket.Columns("Tgl Berakhir").Visible = False
        If DataGridViewPaket.Columns.Contains("PaketID") Then DataGridViewPaket.Columns("PaketID").Visible = False
        If DataGridViewPaket.Columns.Contains("KodeVoucher") Then DataGridViewPaket.Columns("KodeVoucher").Visible = False
        If DataGridViewPaket.Columns.Contains("TindakanID") Then DataGridViewPaket.Columns("TindakanID").Visible = False


        ' Ganti Header kolom tampilan
        If DataGridViewPaket.Columns.Contains("Tgl Mulai Format") Then DataGridViewPaket.Columns("Tgl Mulai Format").HeaderText = "Tgl Mulai"
        If DataGridViewPaket.Columns.Contains("Tgl Berakhir Format") Then DataGridViewPaket.Columns("Tgl Berakhir Format").HeaderText = "Tgl Berakhir"

        ' Styling Header dan Grid
        With DataGridViewPaket
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI Semibold", 10, FontStyle.Bold)
            .DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Regular)
            .AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
            .RowsDefaultCellStyle.SelectionBackColor = Color.DodgerBlue
            .RowsDefaultCellStyle.SelectionForeColor = Color.White
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 100, 200)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .RowHeadersVisible = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        End With

        ' Pewarnaan baris berdasarkan Kuota
        For Each row As DataGridViewRow In DataGridViewPaket.Rows
            If Not row.IsNewRow Then
                Dim kuotaVal As Integer = 0
                If Integer.TryParse(row.Cells("Kuota").Value.ToString(), kuotaVal) Then
                    If kuotaVal = 0 Then
                        row.DefaultCellStyle.BackColor = Color.FromArgb(242, 222, 222)
                        row.DefaultCellStyle.ForeColor = Color.Black
                    ElseIf kuotaVal >= 1 Then
                        row.DefaultCellStyle.BackColor = Color.FromArgb(195, 237, 192)
                        row.DefaultCellStyle.ForeColor = Color.Black
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub DataGridViewPaket_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridViewPaket.CellClick
        If e.RowIndex >= 0 Then
            Dim jenisPaket As String = ""
            If RadioButtonReguler.Checked Then
                jenisPaket = "Paket Reguler"
            ElseIf RadioButtonPerTindakan.Checked Then
                jenisPaket = "Paket Per-Tindakan"
            End If

            Dim selectedRow As DataGridViewRow = DataGridViewPaket.Rows(e.RowIndex)

            Dim paketID As String = selectedRow.Cells("PaketID").Value.ToString()
            Dim kodeVoucher As String = selectedRow.Cells("KodeVoucher").Value.ToString()

            LoadDetailPaket(paketID, kodeVoucher, jenisPaket)
        End If
    End Sub


    Public Sub LoadDetailPaket(ByVal paketID As String, ByVal kodeVoucher As String, ByVal jenisPaket As String)
        Dim query As New System.Text.StringBuilder()

        query.AppendLine("SELECT ")
        query.AppendLine("    tblLog.NoTransaksi, ")
        query.AppendLine("    tblPasien.Nama, ")
        query.AppendLine("    tblLog.NoRekamMedis AS [No RM], ")
        query.AppendLine("    tblLog.KodeVoucher, ")
        query.AppendLine("    tblLog.PaketID, ")
        query.AppendLine("    tblLog.TanggalTransaksi AS [Tgl Transaksi] ")
        query.AppendLine("FROM LogPenggunaanPaket tblLog ")
        query.AppendLine("INNER JOIN TransaksiPaketTindakan tblPaket ")
        query.AppendLine("    ON tblLog.KodeVoucher = tblPaket.KodeVoucher AND tblLog.PaketID = tblPaket.PaketID ")
        query.AppendLine("INNER JOIN MasterPasien tblPasien ON tblLog.NoRekamMedis = tblPasien.NoRekamMedis ")
        query.AppendLine("WHERE tblPaket.JenisPaket = '" & jenisPaket & "' ")
        query.AppendLine("AND tblLog.PaketID = '" & paketID & "' ")
        query.AppendLine("AND tblLog.KodeVoucher = '" & kodeVoucher & "' ")
        query.AppendLine("AND tblLog.DeletedDate IS NULL ")
        query.AppendLine("ORDER BY tblLog.TanggalTransaksi ASC")

        Dim dtDetail As DataTable = ReadSQL(query.ToString())

        ' Format tanggal (jika perlu)
        If Not dtDetail.Columns.Contains("Tgl Transaksi Format") Then
            dtDetail.Columns.Add("Tgl Transaksi Format", GetType(String))
        End If

        For Each row As DataRow In dtDetail.Rows
            If Not IsDBNull(row("Tgl Transaksi")) Then
                row("Tgl Transaksi Format") = CDate(row("Tgl Transaksi")).ToString("dddd, dd MMM yyyy", New Globalization.CultureInfo("id-ID"))
            End If
        Next

        ' Tampilkan di DataGridViewDetail
        DataGridViewDetail.DataSource = dtDetail

        If DataGridViewDetail.Columns.Contains("KodeVoucher") Then DataGridViewDetail.Columns("KodeVoucher").Visible = False
        If DataGridViewDetail.Columns.Contains("PaketID") Then DataGridViewDetail.Columns("PaketID").Visible = False

        ' Styling
        With DataGridViewDetail
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI Semibold", 10, FontStyle.Bold)
            .DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Regular)
            .AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
            .RowsDefaultCellStyle.SelectionBackColor = Color.DodgerBlue
            .RowsDefaultCellStyle.SelectionForeColor = Color.White
            .EnableHeadersVisualStyles = False
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 100, 200)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .RowHeadersVisible = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .Columns("Tgl Transaksi").Visible = False
            .Columns("Tgl Transaksi Format").HeaderText = "Tanggal Transaksi"
        End With
    End Sub

    Private Sub ClearGrid()
        DataGridViewPaket.DataSource = Nothing
        DataGridViewPaket.Rows.Clear()
        DataGridViewPaket.Columns.Clear()

        DataGridViewDetail.DataSource = Nothing
        DataGridViewDetail.Rows.Clear()
        DataGridViewDetail.Columns.Clear()
    End Sub

    Private Sub ClearGridView()
        DataGridViewPaket.DataSource = Nothing
        DataGridViewPaket.Rows.Clear()
        DataGridViewPaket.Columns.Clear()

        ' Jika ada DataGridView detail
        If DataGridViewDetail IsNot Nothing Then
            DataGridViewDetail.DataSource = Nothing
            DataGridViewDetail.Rows.Clear()
            DataGridViewDetail.Columns.Clear()
        End If
    End Sub

    Private Sub RadioButtonReguler_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RadioButtonReguler.CheckedChanged
        If RadioButtonReguler.Checked Then
            ClearGridView()
        End If
    End Sub

    Private Sub RadioButtonPerTindakan_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RadioButtonPerTindakan.CheckedChanged
        If RadioButtonPerTindakan.Checked Then
            ClearGridView()
        End If
    End Sub

    Private Sub BtnCariPaket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCariPaket.Click
        Try
            ClearGrid()
            GetDataPaketHeader()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub ComboBoxJenisCekStik_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxJenisCekStik.SelectedIndexChanged
        Dim jenisTes As String = ComboBoxJenisCekStik.SelectedItem.ToString()
        If ComboBoxJenisCekStik.Text = "GULA DARAH" Then
            TabControlCekStik.SelectedTab = TabPageGula
        ElseIf ComboBoxJenisCekStik.Text = "KOLESTEROL" Then
            TabControlCekStik.SelectedTab = TabPageKolesterol
        ElseIf ComboBoxJenisCekStik.Text = "ASAM URAT" Then
            TabControlCekStik.SelectedTab = TabPageAsamUrat
            Dim query As DataTable = ReadSQL("SELECT Hasil, Keterangan FROM HasilCekStik WHERE Kondisi LIKE '%" & jenisTes & "%' AND NoTransaksi = '" & idTransaksi & "'")
            If query.Rows.Count > 0 Then
                TextBoxHasilAsamUrat.Text = query.Rows(0)("Hasil").ToString()
            Else
                TextBoxHasilAsamUrat.Text = ""
            End If
        ElseIf ComboBoxJenisCekStik.Text = "HB" Then
            TabControlCekStik.SelectedTab = TabPageHB
            Dim query As DataTable = ReadSQL("SELECT Hasil, Keterangan FROM HasilCekStik WHERE Kondisi LIKE '%" & jenisTes & "%' AND NoTransaksi = '" & idTransaksi & "'")
            If query.Rows.Count > 0 Then
                TextBoxHasilHb.Text = query.Rows(0)("Hasil").ToString()
            Else
                TextBoxHasilHb.Text = ""
            End If
        End If
    End Sub

    Private Sub SendToApiCekStik(ByVal noTransaksi As String, ByVal noRM As String, ByVal kategori As String, ByVal kondisi As String, ByVal hasil As String, ByVal keterangan As String, ByVal satuan As String, ByVal createdBy As String)
        Try
            Dim client As New Net.WebClient()

            ' Siapkan JSON sesuai field di Laravel
            Dim json As String = "{" & _
                """NoTransaksi"":""" & noTransaksi & """," & _
                """NoRM"":""" & noRM & """," & _
                """Kategori"":""" & kategori & """," & _
                """Kondisi"":""" & kondisi & """," & _
                """Hasil"":""" & hasil & """," & _
                """Keterangan"":""" & keterangan & """," & _
                """CreatedBy"":""" & createdBy & """," & _
                """Satuan"":""" & satuan & """" & _
            "}"

            Dim baseUrl As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
            Dim urlWebService As String = baseUrl & "api/cekstik/save"
            Dim response As String = InsertDataAPIRM(json, urlWebService)


            ' --- Parse JSON response ---
            Dim result As JObject = JObject.Parse(response)

            Dim status As String = result("status").ToString()
            Dim message As String = result("message").ToString()

            Dim insertedId As String = ""
            Dim data As JObject = TryCast(result("data"), JObject)
            If data IsNot Nothing AndAlso data("id") IsNot Nothing Then
                insertedId = data("id").ToString()
            End If

            ' --- Tampilkan hasil ---
            If status = "success" Then
                MsgBox("Data berhasil dikirim ke API ERM." & vbCrLf & _
                       "Pesan: " & message & vbCrLf & _
                       "Dengan ID: " & insertedId)
            Else
                MsgBox("API mengembalikan status gagal: " & status & vbCrLf & message)
            End If

        Catch ex As Exception
            ' Jangan hentikan aplikasi, cukup log error
            MsgBox("Gagal kirim ke API: " & ex.Message)
        End Try
    End Sub

    Private Sub TimerAPI_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerAPI.Tick
        Dim dt As DataTable = ReadSQL("SELECT * FROM HasilCekStik WHERE IsSent = 0")

        For Each row As DataRow In dt.Rows
            SendToApiCekStik(row("NoTransaksi"), row("NoRM"), row("Kategori"), row("Kondisi"), row("Hasil"), row("Keterangan"), row("Satuan"), row("CreatedBy"))
        Next
    End Sub

    Private Sub ButtonSimpanCekStik_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSimpanCekStik.Click
        Try
            ' Validasi tanggal transaksi
            Dim queryValidasiTanggal As String = ""
            If jenisTransaksi = "UMUM" Or jenisTransaksi = "POLI" Then
                queryValidasiTanggal = "SELECT * FROM TransaksiPoli WHERE NoUrut = '" & idTransaksi & "' AND CAST(TglPoli AS DATE) = CAST(GETDATE() AS DATE)"
            ElseIf jenisTransaksi = "GIGI" Then
                queryValidasiTanggal = "SELECT * FROM TransaksiGigi WHERE NoUrut = '" & idTransaksi & "' AND CAST(TglGigi AS DATE) = CAST(GETDATE() AS DATE)"
            End If

            If queryValidasiTanggal <> "" AndAlso Not CheckSQL(queryValidasiTanggal) Then
                MsgBox("Gagal. Transaksi sudah melewati hari yang ditentukan, tidak bisa disimpan.", MsgBoxStyle.Exclamation, "Warning!")
                Exit Sub
            End If

            Dim cekStik As String = ComboBoxJenisCekStik.Text
            Dim kategori As String = ""
            Dim kondisi As String = ""
            Dim hasil As String = ""
            Dim keterangan As String = ""
            Dim satuan As String = ""

            If cekStik.Contains("GULA") Then
                kategori = "GULA DARAH"
                kondisi = ComboBoxKondisiTes.Text
                hasil = TextBoxHasilGula.Text
                keterangan = TextBoxKeteranganGula.Text
                satuan = "mg/dL"
            ElseIf cekStik.Contains("KOLESTEROL") Then
                kategori = "KOLESTEROL"
                kondisi = ComboBoxJenisKolesterol.Text
                hasil = TextBoxHasilKolesterol.Text
                keterangan = TextBoxKetKolesterol.Text
                satuan = "mg/dL"
            ElseIf cekStik.Contains("ASAM") Then
                kategori = "ASAM URAT"
                kondisi = "Asam Urat"
                hasil = TextBoxHasilAsamUrat.Text
                keterangan = TextBoxKetAsamUrat.Text
                satuan = "mg/dL"
            ElseIf cekStik.Contains("HB") Then
                kategori = "HEMOGLOBIN"
                kondisi = "HB"
                hasil = TextBoxHasilHb.Text
                keterangan = TextBoxKetHb.Text
                satuan = "g/dL"
            Else
                MessageBox.Show("Jenis cek stik belum dipilih atau tidak valid.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If hasil.Trim = "" OrElse keterangan.Trim = "" Then
                MessageBox.Show("Nilai hasil atau keterangan tidak boleh kosong.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' Cek apakah data cek stik sudah pernah disimpan untuk transaksi ini
            Dim queryCekDuplikat As String = "SELECT COUNT(*) FROM HasilCekStik WHERE NoTransaksi = '" & idTransaksi.Replace("'", "''") & "' AND Kondisi = '" & kondisi.Replace("'", "''") & "'"
            Dim dtDuplikat As DataTable = ReadSQL(queryCekDuplikat)

            Dim statusAPI As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'status_ws_RM' ")

            If dtDuplikat.Rows.Count > 0 AndAlso Convert.ToInt32(dtDuplikat.Rows(0)(0)) > 0 Then
                ' Jika sudah ada, update data
                Dim queryUpdate As String = "UPDATE HasilCekStik " & _
                                "SET Hasil = '" & hasil.Replace("'", "''") & "', " & _
                                "    Keterangan = '" & keterangan.Replace("'", "''") & "', " & _
                                "    Satuan = '" & satuan.Replace("'", "''") & "', " & _
                                "    UpdatedDate = GETDATE(), " & _
                                "    UpdatedBy = '" & userInput & "' " & _
                                "WHERE NoTransaksi = '" & idTransaksi.Replace("'", "''") & "' " & _
                                "  AND Kondisi = '" & kondisi.Replace("'", "''") & "'"
                WriteSQL(queryUpdate, 4)
                MessageBox.Show("Data cek stik berhasil diperbarui.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)

                If statusAPI IsNot Nothing AndAlso statusAPI = "Yes" Then
                    SendToApiCekStik(idTransaksi, idPasien, kategori, kondisi, hasil, keterangan, satuan, userInput)
                End If
            Else
                ' Jika belum ada, insert data baru
                Dim queryInsert As String = "INSERT INTO HasilCekStik (NoTransaksi, NoRM, Kategori, Kondisi, Hasil, Keterangan, CreatedDate, CreatedBy, Satuan, IsSent) " & _
                                "VALUES ('" & idTransaksi.Replace("'", "''") & "', '" & idPasien.Replace("'", "''") & "', '" & kategori & "', '" & kondisi & "', '" & hasil & "', '" & keterangan & "', GETDATE(), '" & userInput & "', '" & satuan & "', 0)"
                WriteSQL(queryInsert, 4)
                MessageBox.Show("Data cek stik berhasil disimpan.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)

                If statusAPI IsNot Nothing AndAlso statusAPI = "Yes" Then
                    SendToApiCekStik(idTransaksi, idPasien, kategori, kondisi, hasil, keterangan, satuan, userInput)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat menyimpan data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub HitungKeteranganGula()
        Dim hasilGula As Double

        If Not Double.TryParse(TextBoxHasilGula.Text, hasilGula) Then
            TextBoxKeteranganGula.Text = ""
            Exit Sub
        End If

        Select Case ComboBoxKondisiTes.Text
            Case "Tes Gula Darah Sewaktu (GDS)"
                If hasilGula < 200 Then
                    TextBoxKeteranganGula.Text = "Normal"
                    TextBoxKeteranganGula.ForeColor = Color.Green
                    'ElseIf hasilGula >= 140 AndAlso hasilGula <= 199 Then
                    '    TextBoxKeteranganGula.Text = "Prediabetes"
                    '    TextBoxKeteranganGula.ForeColor = Color.Orange
                Else
                    TextBoxKeteranganGula.Text = "Tinggi (Hiperglikemia)"
                    TextBoxKeteranganGula.ForeColor = Color.Red
                End If
            Case "Tes Gula Darah Puasa (GDP)"
                If hasilGula < 126 Then
                    TextBoxKeteranganGula.Text = "Normal"
                    TextBoxKeteranganGula.ForeColor = Color.Green
                    'ElseIf hasilGula >= 100 AndAlso hasilGula <= 125 Then
                    '    TextBoxKeteranganGula.Text = "Prediabetes"
                    '    TextBoxKeteranganGula.ForeColor = Color.Orange
                Else
                    TextBoxKeteranganGula.Text = "Tinggi (Hiperglikemia)"
                    TextBoxKeteranganGula.ForeColor = Color.Red
                End If
            Case "Tes Postprandial Gula Darah"
                If hasilGula < 140 Then
                    TextBoxKeteranganGula.Text = "Normal"
                    TextBoxKeteranganGula.ForeColor = Color.Green
                ElseIf hasilGula >= 140 AndAlso hasilGula <= 199 Then
                    TextBoxKeteranganGula.Text = "Prediabetes"
                    TextBoxKeteranganGula.ForeColor = Color.Orange
                Else
                    TextBoxKeteranganGula.Text = "Diabetes"
                    TextBoxKeteranganGula.ForeColor = Color.Red
                End If
            Case "Tes Toleransi Glukosa Oral"
                If hasilGula < 140 Then
                    TextBoxKeteranganGula.Text = "Normal"
                    TextBoxKeteranganGula.ForeColor = Color.Green
                ElseIf hasilGula >= 140 AndAlso hasilGula <= 199 Then
                    TextBoxKeteranganGula.Text = "Prediabetes"
                    TextBoxKeteranganGula.ForeColor = Color.Orange
                Else
                    TextBoxKeteranganGula.Text = "Diabetes"
                    TextBoxKeteranganGula.ForeColor = Color.Red
                End If
            Case Else
                TextBoxKeteranganGula.Text = "Jenis tes tidak dikenali"
        End Select
    End Sub

    Private Sub ComboBoxKondisiTes_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxKondisiTes.SelectedIndexChanged
        If ComboBoxKondisiTes.SelectedIndex = -1 Then Exit Sub
        Dim jenisTes As String = ComboBoxKondisiTes.SelectedItem.ToString()
        Dim query As DataTable = ReadSQL("SELECT Hasil, Keterangan FROM HasilCekStik WHERE Kondisi LIKE '%" & jenisTes & "%' AND NoTransaksi = '" & idTransaksi & "'")

        If query.Rows.Count > 0 Then
            TextBoxHasilGula.Text = query.Rows(0)("Hasil").ToString()
        Else
            TextBoxHasilGula.Text = ""
        End If

        HitungKeteranganGula()
    End Sub

    Private Sub TextBoxHasilGula_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxHasilGula.TextChanged
        HitungKeteranganGula()
    End Sub

    Private Sub HitungKeteranganKolesterol()
        Dim hasilKolesterol As Double

        If Not Double.TryParse(TextBoxHasilKolesterol.Text, hasilKolesterol) Then
            TextBoxKetKolesterol.Text = ""
            Exit Sub
        End If
        GroupBoxCad.Visible = False

        Select Case ComboBoxJenisKolesterol.Text
            Case "TC"
                If hasilKolesterol < 200 Then
                    TextBoxKetKolesterol.Text = "Normal (Baik)"
                    TextBoxKetKolesterol.ForeColor = Color.Green
                ElseIf hasilKolesterol >= 200 AndAlso hasilKolesterol <= 239 Then
                    TextBoxKetKolesterol.Text = "Batas Tinggi"
                    TextBoxKetKolesterol.ForeColor = Color.Orange
                Else
                    TextBoxKetKolesterol.Text = "Tinggi (Berisiko)"
                    TextBoxKetKolesterol.ForeColor = Color.Red
                End If
            Case "HDL"
                Dim dtPoli As DataTable = ReadSQL("SELECT JenisKelamin FROM MasterPasien WHERE NoRekamMedis = '" & idPasien.Replace("'", "''") & "'")
                Dim jenisKelamin As String = ""

                If dtPoli.Rows.Count > 0 Then
                    jenisKelamin = dtPoli.Rows(0)("JenisKelamin").ToString().ToUpper()
                Else
                    MessageBox.Show("Jenis Kelamin tidak ditemukan untuk transaksi ini.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If

                If (jenisKelamin = "L" AndAlso hasilKolesterol < 40) OrElse (jenisKelamin = "P" AndAlso hasilKolesterol < 50) Then
                    TextBoxKetKolesterol.Text = "Rendah (Berisiko)"
                    TextBoxKetKolesterol.ForeColor = Color.Red
                ElseIf hasilKolesterol >= 40 AndAlso hasilKolesterol <= 59 Then
                    TextBoxKetKolesterol.Text = "Normal"
                    TextBoxKetKolesterol.ForeColor = Color.Orange
                Else
                    TextBoxKetKolesterol.Text = "Tinggi (Sangat Baik)"
                    TextBoxKetKolesterol.ForeColor = Color.Green
                End If

            Case "LDL"
                GroupBoxCad.Visible = True
                If Not RadioButtonCadIya.Checked AndAlso Not RadioButtonCadTidak.Checked Then
                    MessageBox.Show("Silakan pilih status riwayat penyakit jantung (CAD).", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                If (RadioButtonCadIya.Checked AndAlso hasilKolesterol < 70) OrElse (RadioButtonCadTidak.Checked AndAlso hasilKolesterol < 100) Then
                    TextBoxKetKolesterol.Text = "Optimal"
                    TextBoxKetKolesterol.ForeColor = Color.Green
                ElseIf hasilKolesterol >= 100 AndAlso hasilKolesterol <= 129 Then
                    TextBoxKetKolesterol.Text = "Hampir Optimal"
                    TextBoxKetKolesterol.ForeColor = Color.Orange
                ElseIf hasilKolesterol >= 130 AndAlso hasilKolesterol <= 159 Then
                    TextBoxKetKolesterol.Text = "Batas Tinggi"
                    TextBoxKetKolesterol.ForeColor = Color.OrangeRed
                Else
                    TextBoxKetKolesterol.Text = "Tinggi"
                    TextBoxKetKolesterol.ForeColor = Color.Red
                End If
            Case "Trigliserida"
                If hasilKolesterol < 150 Then
                    TextBoxKetKolesterol.Text = "Normal"
                    TextBoxKetKolesterol.ForeColor = Color.Green
                ElseIf hasilKolesterol >= 150 AndAlso hasilKolesterol <= 199 Then
                    TextBoxKetKolesterol.Text = "Batas Tinggi"
                    TextBoxKetKolesterol.ForeColor = Color.Orange
                ElseIf hasilKolesterol >= 200 AndAlso hasilKolesterol <= 499 Then
                    TextBoxKetKolesterol.Text = "Tinggi"
                    TextBoxKetKolesterol.ForeColor = Color.OrangeRed
                Else
                    TextBoxKetKolesterol.Text = "Sangat Tinggi (Perlu perhatian serius)"
                    TextBoxKetKolesterol.ForeColor = Color.Red
                End If
            Case Else
                TextBoxKetKolesterol.Text = "Jenis tes tidak dikenali"
        End Select
    End Sub

    Private Sub ComboBoxJenisKolesterol_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxJenisKolesterol.SelectedIndexChanged
        If ComboBoxJenisKolesterol.SelectedIndex = -1 Then Exit Sub
        Dim jenisTes As String = ComboBoxJenisKolesterol.SelectedItem.ToString()
        Dim query As DataTable = ReadSQL("SELECT Hasil, Keterangan FROM HasilCekStik WHERE Kondisi LIKE '%" & jenisTes & "%' AND NoTransaksi = '" & idTransaksi & "'")

        If query.Rows.Count > 0 Then
            TextBoxHasilKolesterol.Text = query.Rows(0)("Hasil").ToString()
        Else
            TextBoxHasilKolesterol.Text = ""
        End If

        If ComboBoxJenisKolesterol.Text = "LDL" Then
            GroupBoxCad.Visible = True
        Else
            GroupBoxCad.Visible = False
            RadioButtonCadIya.Checked = False
            RadioButtonCadTidak.Checked = False
        End If

        If Not String.IsNullOrEmpty(TextBoxHasilKolesterol.Text) Then
            HitungKeteranganKolesterol()
        End If
    End Sub

    Private Sub TextBoxHasilKolesterol_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxHasilKolesterol.TextChanged
        HitungKeteranganKolesterol()
    End Sub

    Private Sub HitungKeteranganAsamUrat()
        Dim hasilAsamUrat As Double

        If Not Double.TryParse(TextBoxHasilAsamUrat.Text, hasilAsamUrat) Then
            TextBoxKetAsamUrat.Text = ""
            Exit Sub
        End If

        Dim dtPoli As DataTable = ReadSQL("SELECT JenisKelamin FROM MasterPasien WHERE NoRekamMedis = '" & idPasien.Replace("'", "''") & "'")
        Dim jenisKelamin As String = ""

        If dtPoli.Rows.Count > 0 Then
            jenisKelamin = dtPoli.Rows(0)("JenisKelamin").ToString().ToUpper()
        Else
            MessageBox.Show("Jenis Kelamin tidak ditemukan untuk transaksi ini.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If jenisKelamin = "L" Then
            If hasilAsamUrat < 2 Then
                TextBoxKetAsamUrat.Text = "Rendah"
                TextBoxKetAsamUrat.ForeColor = Color.Orange
            ElseIf hasilAsamUrat <= 7.5 Then
                TextBoxKetAsamUrat.Text = "Normal"
                TextBoxKetAsamUrat.ForeColor = Color.Green
            Else
                TextBoxKetAsamUrat.Text = "Tinggi (Perlu Pemeriksaan Lanjutan)"
                TextBoxKetAsamUrat.ForeColor = Color.Red
            End If

        ElseIf jenisKelamin = "P" Then
            If hasilAsamUrat < 2 Then
                TextBoxKetAsamUrat.Text = "Rendah"
                TextBoxKetAsamUrat.ForeColor = Color.Orange
            ElseIf hasilAsamUrat <= 6.5 Then
                TextBoxKetAsamUrat.Text = "Normal"
                TextBoxKetAsamUrat.ForeColor = Color.Green
            Else
                TextBoxKetAsamUrat.Text = "Tinggi (Perlu Pemeriksaan Lanjutan)"
                TextBoxKetAsamUrat.ForeColor = Color.Red
            End If

        Else
            TextBoxKetAsamUrat.Text = "Jenis kelamin tidak dikenali"
            TextBoxKetAsamUrat.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub TextBoxHasilAsamUrat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxHasilAsamUrat.TextChanged
        HitungKeteranganAsamUrat()
    End Sub

    Private Sub TextBoxKetAsamUrat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxKetAsamUrat.TextChanged
        HitungKeteranganAsamUrat()
    End Sub

    Private Sub HitungKeteranganHB()
        Dim hasilHB As Double

        If Not Double.TryParse(TextBoxHasilHb.Text, hasilHB) Then
            TextBoxKetHb.Text = ""
            Exit Sub
        End If

        Dim dtPoli As DataTable = ReadSQL("SELECT JenisKelamin FROM MasterPasien WHERE NoRekamMedis = '" & idPasien.Replace("'", "''") & "'")
        Dim jenisKelamin As String = ""

        If dtPoli.Rows.Count > 0 Then
            jenisKelamin = dtPoli.Rows(0)("JenisKelamin").ToString().ToUpper()
        Else
            MessageBox.Show("Jenis Kelamin tidak ditemukan untuk transaksi ini.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If jenisKelamin = "L" Then
            If hasilHB < 13 Then
                TextBoxKetHb.Text = "Rendah (Anemia)"
                TextBoxKetHb.ForeColor = Color.Orange
            ElseIf hasilHB >= 13 AndAlso hasilHB <= 17.2 Then
                TextBoxKetHb.Text = "Normal"
                TextBoxKetHb.ForeColor = Color.Green
            Else
                TextBoxKetHb.Text = "Tinggi (Perlu Pemeriksaan Lanjutan)"
                TextBoxKetHb.ForeColor = Color.Red
            End If

        ElseIf jenisKelamin = "P" Then
            If hasilHB < 12 Then
                TextBoxKetHb.Text = "Rendah (Anemia)"
                TextBoxKetHb.ForeColor = Color.Orange
            ElseIf hasilHB >= 12 AndAlso hasilHB <= 15.1 Then
                TextBoxKetHb.Text = "Normal"
                TextBoxKetHb.ForeColor = Color.Green
            Else
                TextBoxKetHb.Text = "Tinggi (Perlu Pemeriksaan Lanjutan)"
                TextBoxKetHb.ForeColor = Color.Red
            End If
        Else
            TextBoxKetAsamUrat.Text = "Jenis kelamin tidak dikenali"
            TextBoxKetAsamUrat.ForeColor = Color.Gray
        End If
    End Sub

    Private Sub TextBoxHasilHb_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxHasilHb.TextChanged
        HitungKeteranganHB()
    End Sub

    Private Sub TextBoxKetHb_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxKetHb.TextChanged
        HitungKeteranganHB()
    End Sub

    Public Function SetParameterWhatsappText(ByVal nomor As String, ByVal pesan As String) As String
        ' Bersihkan format pesan: ganti newline jadi \n, escape kutip dua
        Dim cleanPesan As String = pesan.Replace(vbCrLf, "\n").Replace("""", "\""")

        ' Buat JSON manual
        Dim json As String = "{" & _
            """number"": """ & nomor & """," & _
            """message"": """ & cleanPesan & """" & _
        "}"

        Return json
    End Function

    Private Sub SendToApiGetUrl(ByVal noRM As String)
        Try
            ' Siapkan JSON → hanya kirim NoRM
            Dim json As String = "{" & _
                """NoRM"":""" & noRM & """" & _
            "}"

            ' Ambil base URL dari config
            Dim baseUrl As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
            Dim urlWebService As String = baseUrl & "api/pasien/get-url"

            ' Panggil API Laravel
            Dim response As String = InsertDataAPIRM(json, urlWebService)

            ' Cek respon
            If response.Contains("""status"":""ok""") Then
                ' Ambil URL dari response
                Dim urlPasien As String = ""
                Dim uuid As String = ""
                ' Setelah ambil urlPasien
                urlPasien = urlPasien.Replace("V", "/")
                urlPasien = urlPasien.Replace("\", "/")
                urlPasien = urlPasien.Replace("http:/", "http://")

                ' Cari "url"
                Dim urlKey As String = """url"":"""
                Dim posUrl As Integer = response.IndexOf(urlKey)
                If posUrl > -1 Then
                    posUrl += urlKey.Length
                    Dim endPos As Integer = response.IndexOf("""", posUrl)
                    urlPasien = response.Substring(posUrl, endPos - posUrl)
                End If

                ' Cari "uuid"
                Dim uuidKey As String = """uuid"":"""
                Dim posUuid As Integer = response.IndexOf(uuidKey)
                If posUuid > -1 Then
                    posUuid += uuidKey.Length
                    Dim endPos As Integer = response.IndexOf("""", posUuid)
                    uuid = response.Substring(posUuid, endPos - posUuid)
                End If

                'MsgBox("URL: " & urlPasien & vbCrLf & "UUID: " & uuid)

                If urlPasien <> "" Then
                    'Process.Start(New ProcessStartInfo(urlPasien) With {.UseShellExecute = True})
                    Dim noHP As String = ReadSQLNIK("SELECT NoHandphone FROM MasterPasien WHERE NoRekamMedis = '" & noRM.Replace("'", "''") & "'")
                    Dim nama As String = ReadSQLNIK("SELECT Nama FROM MasterPasien WHERE NoRekamMedis = '" & noRM.Replace("'", "''") & "'")

                    If Not String.IsNullOrEmpty(noHP) Then
                        ' Format jadi 62 kalau masih 08
                        If Strings.Left(noHP, 2) = "08" Then
                            noHP = "62" & noHP.Substring(1)
                        End If

                        ' Kirim pesan WhatsApp sederhana berisi link URL
                        Dim pesan As String = "Kepada Yth. *" & nama & "*," & vbCrLf & vbCrLf & _
                        "Terima kasih telah berkunjung ke klinik kami." & vbCrLf & _
                        "Anda dapat mengakses riwayat cek stik Anda melalui link berikut:" & vbCrLf & vbCrLf & _
                        urlPasien & vbCrLf & vbCrLf & _
                        "Silakan simpan link ini untuk akses riwayat cek stik Anda kapan saja."


                        Dim waIP As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'whatsapp_klinik_ip'")
                        If String.IsNullOrEmpty(waIP) Then
                            MsgBox("IP WhatsApp tidak ditemukan di MsConfig.")
                            Exit Sub
                        End If
                        Dim parameter As String = SetParameterWhatsappText(noHP, pesan)
                        Dim urlSend As String = "http://" & waIP & ":4444/send"
                        Dim statusKirim As String = SendDataWhatsapp(parameter, urlSend)

                        MsgBox("WA Response: " & statusKirim)
                    Else
                        MsgBox("Nomor HP pasien tidak ditemukan di MasterPasien.")
                    End If
                End If
            Else
                MsgBox("Response gagal: " & response)
            End If
        Catch ex As Exception
            MsgBox("Gagal kirim ke API: " & ex.Message)
        End Try
    End Sub

    Private Sub ButtonCetakCekStik_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCetakCekStik.Click
        ' Buat DataTable kosong
        Dim tblsHasil As New DataTable
        With tblsHasil.Columns
            .Add("Nama", GetType(String))
            .Add("JenisKelamin", GetType(String))
            .Add("TglLahir", GetType(String))
            .Add("TC", GetType(String))
            .Add("Gula", GetType(String))
            .Add("AsamUrat", GetType(String))
            .Add("HB", GetType(String))
            .Add("KetGula", GetType(String))
            .Add("KetAsamUrat", GetType(String))
            .Add("TekananDarah", GetType(String))
            .Add("Kota", GetType(String))
            .Add("TanggalKunjungan", GetType(String))
        End With

        ' Ambil data pasien
        Dim dtPasien As DataTable = ReadSQL("SELECT Nama, JenisKelamin, TglLahir FROM MasterPasien WHERE NoRekamMedis = '" & idPasien.Replace("'", "''") & "'")
        Dim namaPasien As String = ""
        Dim jenisKelamin As String = ""
        Dim umurPasien As Integer = 0
        Dim hasilTC As String = ""
        Dim hasilGDP As String = ""
        Dim hasilGDS As String = ""
        Dim hasilAsam As String = ""
        Dim hasilHB As String = ""
        Dim ketAsamurat As String = ""

        If dtPasien.Rows.Count > 0 Then
            namaPasien = dtPasien.Rows(0)("Nama").ToString()
            jenisKelamin = dtPasien.Rows(0)("JenisKelamin").ToString().ToUpper()

            Dim tanggalLahir As Date
            If Date.TryParse(dtPasien.Rows(0)("TglLahir").ToString(), tanggalLahir) Then
                Dim today As Date = Date.Today
                umurPasien = today.Year - tanggalLahir.Year
                If (today.Month < tanggalLahir.Month) Or (today.Month = tanggalLahir.Month AndAlso today.Day < tanggalLahir.Day) Then
                    umurPasien -= 1
                End If
            Else
                MessageBox.Show("Format tanggal lahir tidak valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            MessageBox.Show("Data pasien tidak ditemukan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If


        If jenisKelamin = "L" Then
            ketAsamurat = "L 2-7.5 mg/dL"
        ElseIf jenisKelamin = "P" Then
            ketAsamurat = "P 2-6.5 mg/dL"
        End If

        Dim tblsFisik As DataTable = ReadSQL("SELECT * FROM TransaksiDetailFisik WHERE NoTransaksi = '" & idTransaksi & "'")
        Dim sistole As String = ""
        Dim diastole As String = ""

        If tblsFisik.Rows.Count > 0 Then
            Dim rowFisik As DataRow = tblsFisik.Rows(0)
            sistole = rowFisik("Sistole")
            diastole = rowFisik("Diastole")
        End If

        Dim namaKota As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'Kota'")

        ' Ambil hasil cek stik
        Dim tblsCekStik As DataTable = ReadSQL("SELECT * FROM HasilCekStik WHERE NoTransaksi = '" & idTransaksi & "' AND Deleted IS NULL")


        Dim tglKunjungan As String = "-"

        If tblsCekStik.Rows.Count > 0 AndAlso Not IsDBNull(tblsCekStik.Rows(0)("CreatedDate")) Then
            Dim createdDate As DateTime = Convert.ToDateTime(tblsCekStik.Rows(0)("CreatedDate"))
            tglKunjungan = Format(createdDate, "dd") & " " & BulanIndonesia(Format(createdDate, "MM")) & " " & Format(createdDate, "yyyy")
        End If

        If tblsCekStik.Rows.Count = 0 Then
            MsgBox("Data cek stik tidak ditemukan untuk transaksi " & idTransaksi, MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        Dim hasilGula As String = ""
        Dim jenisTesGula As String = ""
        Dim ketGula As String = ""
        Dim foundGDP As Boolean = False

        For Each row As DataRow In tblsCekStik.Rows
            Dim kondisi As String = row("Kondisi").ToString().Trim()
            Dim hasilFormatted As String = ""
            Dim hasilRaw As String = row("Hasil").ToString()
            Dim hasilDouble As Double

            If Double.TryParse(hasilRaw, hasilDouble) Then
                hasilFormatted = hasilDouble.ToString("0.#")
            Else
                hasilFormatted = hasilRaw
            End If

            If kondisi = "Tes Gula Darah Sewaktu (GDS)" AndAlso Not foundGDP Then
                hasilGula = hasilFormatted
                foundGDP = True
                jenisTesGula = "GDS"
                ketGula = "Acak <200 mg/dL"
            End If

            ' Ambil tes lain
            Select Case kondisi
                Case "TC"
                    hasilTC = hasilFormatted
                Case "Asam Urat"
                    hasilAsam = hasilFormatted
                Case "HB"
                    hasilHB = hasilFormatted
            End Select
        Next

        If Not foundGDP Then
            For Each row As DataRow In tblsCekStik.Rows
                Dim kondisi As String = row("Kondisi").ToString().Trim()
                If kondisi = "Tes Gula Darah Puasa (GDP)" Then
                    Dim hasilRaw As String = row("Hasil").ToString()
                    Dim hasilDouble As Double
                    If Double.TryParse(hasilRaw, hasilDouble) Then
                        hasilGula = hasilDouble.ToString("0.#")
                        jenisTesGula = "GDP"
                        ketGula = "Puasa <126 mg/dL"
                    Else
                        hasilGula = hasilRaw
                    End If
                    Exit For
                End If
            Next
        End If

        ' Ambil info cek stik pertama
        Dim trowCekStik As DataRow = tblsCekStik.Rows(0)

        ' Buat baris baru untuk ditampilkan
        Dim newRow As DataRow = tblsHasil.NewRow
        newRow("Nama") = namaPasien
        newRow("JenisKelamin") = "( " & jenisKelamin & " )"
        newRow("TglLahir") = umurPasien & " Thn"
        newRow("TC") = If(hasilTC.Trim() = "", "-", hasilTC & " mg/dL")
        newRow("Gula") = If(hasilGula.Trim() = "", "-", hasilGula & " mg/dL")
        newRow("AsamUrat") = If(hasilAsam.Trim() = "", "-", hasilAsam & " mg/dL")
        newRow("HB") = If(hasilHB.Trim() = "", "-", hasilHB & " g/dL")
        newRow("KetGula") = ketGula
        newRow("KetAsamUrat") = ketAsamurat
        newRow("TekananDarah") = sistole & "/" & diastole & " mmHg"
        newRow("Kota") = namaKota & ", "
        newRow("TanggalKunjungan") = tglKunjungan
        tblsHasil.Rows.Add(newRow)

        ' Load Report
        Report = New XtraReport
        Report = XtraReport.FromFile(Application.StartupPath + "\Reports\Klinik\RekamMedis\ReportCekStik.repx", True)
        Report.DataSource = tblsHasil

        'Report.RunDesigner()
        Report.ShowPreview()

        Dim statusAPI As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'status_ws_RM' ")

        Dim result As DialogResult = MessageBox.Show("Apakah Anda ingin mengirim data ke Whatsapp pasien?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If result = DialogResult.Yes Then
            If statusAPI IsNot Nothing AndAlso statusAPI = "Yes" Then
                SendToApiGetUrl(idPasien)
            End If
        End If
    End Sub

    Public Function SubmitPotongPaket(ByRef rowPaket() As DataRow) As DataTable
        Dim tblTindakan As New DataTable
        tblTindakan.Columns.Add("PaketID", GetType(String))
        tblTindakan.Columns.Add("TindakanID", GetType(String))
        tblTindakan.Columns.Add("Nama Paket", GetType(String))
        tblTindakan.Columns.Add("Keterangan Paket", GetType(String))
        tblTindakan.Columns.Add("Penjamin", GetType(String))
        tblTindakan.Columns.Add("Harga Awal", GetType(Decimal))
        tblTindakan.Columns.Add("Diskon", GetType(Decimal))
        tblTindakan.Columns.Add("Harga Nett", GetType(Decimal))
        tblTindakan.Columns.Add("KodeVoucher", GetType(String))
        tblTindakan.Columns.Add("Jenis Paket", GetType(String))

        Try
            Dim totalTagihan As Decimal = 0
            Dim identitasPaket As String = ""
            Dim listPaketID As New HashSet(Of String)

            If rowPaket IsNot Nothing AndAlso rowPaket.Length > 0 Then
                For Each row As DataRow In rowPaket
                    Dim hargaAwal As Decimal = CDec(row("Harga Nett"))
                    Dim diskon As Decimal = 0D
                    Dim hargaNett As Decimal = hargaAwal - diskon
                    Dim idPaket As String = row("PaketID").ToString()
                    If Not listPaketID.Contains(idPaket) Then
                        listPaketID.Add(idPaket)
                    End If

                    Dim Tnew As DataRow = tblTindakan.NewRow
                    Tnew("PaketID") = idPaket
                    Tnew("TindakanID") = row("TindakanID")
                    Tnew("Nama Paket") = row("Nama Paket")
                    Tnew("Keterangan Paket") = row("Keterangan Paket")
                    Tnew("Penjamin") = row("Penjamin")
                    Tnew("Harga Awal") = hargaAwal
                    Tnew("Diskon") = diskon
                    Tnew("Harga Nett") = hargaNett
                    Tnew("KodeVoucher") = row("KodeVoucher")
                    Tnew("Jenis Paket") = row("Jenis Paket")
                    tblTindakan.Rows.Add(Tnew)

                    identitasPaket = idPaket
                Next
            End If

            ' Ambil data HargaNett dan Kuota dari MasterPaketTindakan
            Dim tblPaket As DataTable = ReadSQL("SELECT * FROM MasterPaketTindakan WHERE PaketID = '" & identitasPaket & "'")
            'Parsing JSON DetailTindakan
            Dim jsonText As String = tblPaket.Rows(0)("DetailTindakan").ToString()
            Dim listTindakan As List(Of TindakanDetail) = JsonConvert.DeserializeObject(Of List(Of TindakanDetail))(jsonText)

            Dim hargaNettPaket As Decimal = 0
            Dim kuotaPaket As Integer = 1
           
            If tblPaket IsNot Nothing AndAlso tblPaket.Rows.Count > 0 Then
                Dim paket As DataRow = tblPaket.Rows(0)
                If Not IsDBNull(paket("HargaNett")) Then
                    hargaNettPaket = CDec(paket("HargaNett"))
                End If
                If Not IsDBNull(paket("Kuota")) AndAlso CInt(paket("Kuota")) > 0 Then
                    kuotaPaket = CInt(paket("Kuota"))
                End If
            End If

            ' Hitung harga per kuota
            Dim hargaPerKuota As Decimal = 0
            If kuotaPaket > 0 Then
                hargaPerKuota = hargaNettPaket / kuotaPaket
            End If
            totalTagihan = hargaPerKuota * rowPaket.Length

            ' Ambil TransPoliID
            Dim transPoliId As String = ReadSQLNIK("SELECT TransPoliID FROM TransaksiPoli WHERE NoUrut = '" & idTransaksi & "'")

            ' Simpan ke TransaksiPoliBayarAwal
            WriteSQL("INSERT INTO TransaksiPoliBayarAwal (TransJenis, TransPoliID, JenisBayar, NoJenisBayar, JumlahBayar, admin, transaksitime, mesin, kartu) " & _
                 "VALUES('POLI', '" & transPoliId & "', 'VOUCHER', '-', '" & CDbl(totalTagihan) & "', '" & userInput & "', GETDATE(), '', '')", 4)

            ' Proses tiap tindakan
            For Each rowTindakan As DataRow In tblTindakan.Rows
                WriteSQL("INSERT INTO LogPenggunaanPaket(NoRekamMedis, NoTransaksi, PaketID, TindakanID, JenisPaket, TanggalTransaksi, KodeVoucher, CreatedBy, CreatedDate) " & _
                     "VALUES('" & idPasien & "', '" & idTransaksi & "', '" & rowTindakan("PaketID") & "', '" & rowTindakan("TindakanID") & "', '" & rowTindakan("Jenis Paket") & "', GETDATE(), '" & rowTindakan("KodeVoucher") & "', '" & userInput & "', GETDATE())", 4)

                If rowTindakan("Jenis Paket").ToString() = "Paket Reguler" Then
                    WriteSQL("UPDATE TransaksiPaketTindakan SET Kuota = Kuota - 1 WHERE PaketID = '" & rowTindakan("PaketID") & "' AND KodeVoucher = '" & rowTindakan("KodeVoucher") & "' AND DeletedDate IS NULL", 4)
                ElseIf rowTindakan("Jenis Paket").ToString() = "Paket Per-Tindakan" Then
                    WriteSQL("UPDATE TransaksiPaketTindakanDetail SET KuotaTindakan = KuotaTindakan - 1 WHERE PaketID = '" & rowTindakan("PaketID") & "' AND TindakanID = '" & rowTindakan("TindakanID") & "' AND KodeVoucher = '" & rowTindakan("KodeVoucher") & "'", 4)
                End If
            Next

            ' Ambil TindakanID dari rowPaket agar hanya tindakan yang dipilih yang disimpan
            Dim tindakanDipilih As New HashSet(Of String)
            For Each row In rowPaket
                tindakanDipilih.Add(row("TindakanID").ToString())
                'Debug.WriteLine("TindakanID dipilih: " & row("TindakanID").ToString())
            Next

            ' Loop data JSON dan simpan ke TransaksiPoliDetail
            For Each rowTindakan As DataRow In tblTindakan.Rows
                Dim tindakanID As String = rowTindakan("TindakanID").ToString()

                ' Cari data dari JSON yang sesuai dengan tindakanID
                Dim tindakan As TindakanDetail = listTindakan.Find(Function(x) x.TindakanID = tindakanID)
                If tindakan Is Nothing Then Continue For

                Dim sqlFee As String = "SELECT FeeDokter, FeePerawat FROM MasterTindakan WHERE TindakanID = '" & tindakan.TindakanID & "'"
                Dim tblFee As DataTable = ReadSQL(sqlFee)

                Dim feeDokter As Decimal = 0D
                Dim feePerawat As Decimal = 0D
                If tblFee IsNot Nothing AndAlso tblFee.Rows.Count > 0 Then
                    If Not IsDBNull(tblFee.Rows(0)("FeeDokter")) Then
                        feeDokter = CDec(tblFee.Rows(0)("FeeDokter"))
                    End If
                    If Not IsDBNull(tblFee.Rows(0)("FeePerawat")) Then
                        feePerawat = CDec(tblFee.Rows(0)("FeePerawat"))
                    End If
                End If

                WriteSQL("INSERT INTO TransaksiPoliDetail(Awal, TransPoliID, TindakanID, PaketID, NamaTindakan, JenisTindakan, BiayaTindakan, DiscTindakan, NettBayar, admin, transaksitime, DiscPersenTindakan, StatusPembayaran, KodeVoucher, Penjamin, FeeDokter, FeePerawat) " & _
                     "VALUES('1', '" & transPoliId & "', " & _
                     "'" & tindakan.TindakanID & "', " & _
                     "'" & identitasPaket & "', " & _
                     "'" & tindakan.NamaTindakan.Replace("'", "''") & "', " & _
                     "'" & tindakan.JenisTindakan.Replace("'", "''") & "', " & _
                     CDec(tindakan.BiayaTindakan) & ", " & _
                     CDec(tindakan.DiskonTindakan) & ", " & _
                     CDec(tindakan.NettBayar) & ", " & _
                     "'" & userInput & "', GETDATE(), 0, 'PAID', " & _
                     "'" & rowTindakan("KodeVoucher").ToString() & "', " & _
                     "'" & rowTindakan("Penjamin").ToString() & "', " & _
                     feeDokter & ", " & feePerawat & ")", 4)
            Next

            ' Tambahkan khusus untuk Paket Reguler (jika ditemukan)
            If tblTindakan.Rows.Count > 0 AndAlso tblTindakan.Rows(0)("Jenis Paket").ToString().ToUpper() = "Paket Reguler" Then
                Dim namaPaket As String = tblTindakan.Rows(0)("Nama Paket").ToString()
                Dim penjamin As String = tblTindakan.Rows(0)("Penjamin").ToString()
                Dim kodeVoucher As String = tblTindakan.Rows(0)("KodeVoucher").ToString()

                ' Ambil harga paket dari variabel hargaNettPaket (jika sudah dihitung sebelumnya)
                WriteSQL("INSERT INTO TransaksiPoliDetail(Awal, TransPoliID, TindakanID, PaketID, NamaTindakan, JenisTindakan, BiayaTindakan, DiscTindakan, NettBayar, admin, transaksitime, DiscPersenTindakan, StatusPembayaran, KodeVoucher, Penjamin, FeeDokter, FeePerawat) " & _
                         "VALUES('1', '" & transPoliId & "', " & _
                         "'0', " & _
                         "'" & identitasPaket & "', " & _
                         "'" & namaPaket.Replace("'", "''") & "', " & _
                         "'Tindakan', " & _
                         hargaNettPaket & ", 0, " & hargaNettPaket & ", " & _
                         "'" & userInput & "', GETDATE(), 0, 'PAID', " & _
                         "'" & kodeVoucher & "', " & _
                         "'" & penjamin & "', 0, 0)", 4)
            End If


            MsgBox("Data berhasil disimpan.", MsgBoxStyle.Information, "Sukses")
            'Return tblTindakan

            LoadGridTindakanPoli()
        Catch ex As Exception
            MsgBox("Terjadi kesalahan saat menyimpan data: " & ex.Message, MsgBoxStyle.Critical, "Error")
            Return Nothing
        End Try
    End Function

    Private Sub ButtonScanQR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonScanQR.Click
        DialogBoxPaketTindakan.SetForm("Perencanaan Tindakan")
        DialogBoxPaketTindakan.ShowDialog()
    End Sub

    Private Sub ButtonUploadPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonUploadPDF.Click
        Dim ofd As New OpenFileDialog()
        ofd.Filter = "PDF Files|*.pdf"
        ofd.Title = "Pilih File PDF"

        If ofd.ShowDialog() = DialogResult.OK Then
            Dim folderPath As String = Application.StartupPath & "\Uploads\PDF"
            If Not IO.Directory.Exists(folderPath) Then
                IO.Directory.CreateDirectory(folderPath)
            End If

            ' Buat nama file unik agar tidak bentrok
            Dim fileName As String = IO.Path.GetFileName(ofd.FileName)
            Dim uniqueName As String = Guid.NewGuid().ToString() & "_" & fileName
            Dim targetPath As String = IO.Path.Combine(folderPath, uniqueName)

            ' Salin ke folder aplikasi
            IO.File.Copy(ofd.FileName, targetPath, True)

            ' (Opsional) tampilkan nama file di TextBox
            TextBoxNamaPDF.Text = fileName

            ' Simpan path ke database
            Dim sql As String = "INSERT INTO UploadPDF (NoUrut, NoRM, FilePath, NamaFile, CreatedBy, CreatedDate) " & _
                                "VALUES ('" & idTransaksi & "', '" & idPasien & "', '" & targetPath.Replace("'", "''") & "', '" & _
                                fileName.Replace("'", "''") & "', '" & userInput & "', GETDATE())"
            WriteSQL(sql, 4)

            MessageBox.Show("File PDF berhasil diunggah.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' === Buka file PDF di browser default ===
            Try
                System.Diagnostics.Process.Start(targetPath)
            Catch ex As Exception
                MessageBox.Show("Gagal membuka PDF di browser: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            ' ===============================================================
            MessageBox.Show("File PDF berhasil diunggah dan dibuka di browser.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Call MuatPDFByTransaksiNoRM(idTransaksi, idPasien)
        End If
    End Sub

    Private Sub MuatPDFByTransaksiNoRM(ByVal noUrut As String, ByVal noRM As String)
        Dim query As String = "SELECT ID, NamaFile, FilePath FROM UploadPDF " & _
                          "WHERE NoUrut = '" & noUrut & "' AND NoRM = '" & noRM & "' AND DeletedDate IS NULL"
        Dim dt As DataTable = ReadSQL(query)

        ComboBoxTampilPDF.DataSource = dt
        ComboBoxTampilPDF.DisplayMember = "NamaFile"
        ComboBoxTampilPDF.ValueMember = "FilePath"
    End Sub

    Private Sub ComboBoxTampilPDF_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBoxTampilPDF.SelectedIndexChanged
        If ComboBoxTampilPDF.SelectedValue IsNot Nothing Then
            Dim pathPDF As String = ComboBoxTampilPDF.SelectedValue.ToString()
            If IO.File.Exists(pathPDF) Then
                Try
                    ' Buka file PDF di browser default
                    System.Diagnostics.Process.Start(pathPDF)
                Catch ex As Exception
                    MessageBox.Show("Gagal membuka PDF di browser: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            Else
                MessageBox.Show("File PDF tidak ditemukan di folder.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub ButtonHapusPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonHapusPDF.Click
        If ComboBoxTampilPDF.SelectedValue Is Nothing Then
            MessageBox.Show("Silakan pilih file PDF yang akan dihapus.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim filePath As String = ComboBoxTampilPDF.SelectedValue.ToString()
        Dim namaFile As String = ComboBoxTampilPDF.Text

        If MessageBox.Show("Yakin ingin menghapus file: " & namaFile & " ?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            ' Update database
            Dim sql As String = "UPDATE UploadPDF SET DeletedDate = GETDATE(), DeletedBy = '" & userInput & "' WHERE FilePath = '" & filePath.Replace("'", "''") & "'"
            WriteSQL(sql, 4)

            ' Hapus file fisik
            If IO.File.Exists(filePath) Then
                IO.File.Delete(filePath)
            End If

            MessageBox.Show("File PDF berhasil dihapus.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Refresh daftar PDF
            Call MuatPDFByTransaksiNoRM(idTransaksi, idPasien)

            ' Hapus tampilan PDF di AxAcroPDF (tidak digunakan lagi)
            ' AxAcroPDF1.src = Nothing

            ' Jika ingin tampilkan di browser (opsional untuk cek)
            Try
                If IO.File.Exists(filePath) Then
                    Process.Start(New ProcessStartInfo(filePath) With {.UseShellExecute = True})
                End If
            Catch ex As Exception
                MessageBox.Show("Gagal membuka PDF di browser: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Public Function HitungRisikoDM_Tahap2(ByVal NoRM As String) As Dictionary(Of String, String)
        Dim hasil As New Dictionary(Of String, String)

        '===========================
        ' 1. HITUNG UMUR
        '===========================
        Dim tglLahirStr As String = ReadSQLNIK("SELECT TglLahir FROM MasterPasien WHERE NoRekamMedis='" & NoRM & "'")

        If tglLahirStr = "" Then Return hasil

        Dim TglLahir As Date = CDate(tglLahirStr)
        Dim Umur As Integer = DateDiff(DateInterval.Year, TglLahir, Date.Now)

        Dim tglUltahTahunIni As Date
        tglUltahTahunIni = DateSerial(Year(Date.Now), Month(TglLahir), TglLahir.Day)

        If Date.Now < tglUltahTahunIni Then
            Umur = Umur - 1
        End If


        '===========================
        ' 2. GULA DARAH (3 BULAN)
        '===========================
        Dim JumlahGulaNaik As Integer = Val(ReadSQLNIK( _
            "SELECT COUNT(*) FROM HasilCekStik " & _
            "WHERE NoRM='" & NoRM & "' AND Kategori='GULA DARAH' " & _
            "AND Hasil>=110 AND Deleted IS NULL " & _
            "AND CreatedDate>=DATEADD(MONTH,-3,GETDATE())"))

        Dim RataGula As Double = Val(ReadSQLNIK( _
            "SELECT AVG(Hasil) FROM HasilCekStik " & _
            "WHERE NoRM='" & NoRM & "' AND Kategori='GULA DARAH' " & _
            "AND Deleted IS NULL " & _
            "AND CreatedDate>=DATEADD(MONTH,-3,GETDATE())"))

        '===========================
        ' 3. IMT (3 BULAN)
        '===========================
        Dim RataIMT As Double = Val(ReadSQLNIK( _
            "SELECT AVG(TDF.IMT) FROM TransaksiDetailFisik TDF " & _
            "INNER JOIN TransaksiDetail TD ON TDF.NoTransaksi=TD.NoUrut " & _
            "WHERE TD.IDInternet='" & NoRM & "' " & _
            "AND TD.CreatedDate>=DATEADD(MONTH,-3,GETDATE())"))

        '===========================
        ' 4. KELUHAN
        '===========================
        Dim AdaKeluhanDM As Integer = Val(ReadSQLNIK( _
            "SELECT COUNT(*) FROM TransaksiDetail " & _
            "WHERE IDInternet='" & NoRM & "' " & _
            "AND CreatedDate>=DATEADD(MONTH,-3,GETDATE()) " & _
            "AND ( " & _
            "KeluhanUtama LIKE '%haus%' OR KeluhanUtama LIKE '%lelah%' OR " & _
            "KeluhanUtama LIKE '%DM%' OR KeluhanUtama LIKE '%dm%' OR " & _
            "KeluhanUtama LIKE '%kencing%' OR KeluhanUtama LIKE '%minum%' OR " & _
            "KeluhanTambahan LIKE '%haus%' OR KeluhanTambahan LIKE '%lelah%' OR " & _
            "KeluhanTambahan LIKE '%kencing%' OR KeluhanTambahan LIKE '%minum%' " & _
            ")"))

        '===========================
        ' 5. SCORING
        '===========================
        Dim Skor As Integer = 0

        If Umur >= 45 Then Skor += 2
        If JumlahGulaNaik >= 2 Then Skor += 3
        If RataGula >= 120 Then Skor += 2
        If RataIMT >= 25 Then Skor += 2
        If AdaKeluhanDM >= 1 Then Skor += 1
        If AdaKeluhanDM >= 2 And JumlahGulaNaik >= 2 Then Skor += 1

        Dim StatusRisiko As String
        If Skor >= 7 Then
            StatusRisiko = "TINGGI"
        ElseIf Skor >= 4 Then
            StatusRisiko = "SEDANG"
        Else
            StatusRisiko = "RENDAH"
        End If

        '===========================
        ' 6. RETURN
        '===========================
        hasil("Umur") = Umur.ToString()
        hasil("JumlahGulaNaik") = JumlahGulaNaik.ToString()
        hasil("RataGulaDarah") = FormatNumber(RataGula, 0)
        hasil("RataIMT") = FormatNumber(RataIMT, 1)
        hasil("Skor") = Skor.ToString()
        hasil("StatusRisiko") = StatusRisiko

        Return hasil
    End Function

    Public Function HitungRisikoHipertensi_Tahap2(ByVal NoRM As String) As Dictionary(Of String, String)
        Dim hasil As New Dictionary(Of String, String)

        '===========================
        ' 1. HITUNG UMUR
        '===========================
        Dim tglLahirStr As String = ReadSQLNIK("SELECT TglLahir FROM MasterPasien WHERE NoRekamMedis='" & NoRM & "'")

        If tglLahirStr = "" Then Return hasil

        Dim TglLahir As Date = CDate(tglLahirStr)
        Dim Umur As Integer = DateDiff(DateInterval.Year, TglLahir, Date.Now)

        Dim tglUltahTahunIni As Date
        tglUltahTahunIni = DateSerial(Year(Date.Now), Month(TglLahir), TglLahir.Day)
        If Date.Now < tglUltahTahunIni Then Umur = Umur - 1

        '===========================
        ' 2. TEKANAN DARAH (3 BULAN)
        '===========================
        Dim JumlahTDNaik As Integer = Val(ReadSQLNIK( _
            "SELECT COUNT(*) FROM TransaksiDetailFisik TDF " & _
            "INNER JOIN TransaksiDetail TD ON TDF.NoTransaksi=TD.NoUrut " & _
            "WHERE TD.IDInternet='" & NoRM & "' " & _
            "AND (TDF.Sistole>=140 OR TDF.Diastole>=90) " & _
            "AND TD.CreatedDate>=DATEADD(MONTH,-3,GETDATE())"))

        Dim RataSistol As Double = Val(ReadSQLNIK( _
            "SELECT AVG(TDF.Sistole) FROM TransaksiDetailFisik TDF " & _
            "INNER JOIN TransaksiDetail TD ON TDF.NoTransaksi=TD.NoUrut " & _
            "WHERE TD.IDInternet='" & NoRM & "' " & _
            "AND TD.CreatedDate>=DATEADD(MONTH,-3,GETDATE())"))

        Dim RataDiastol As Double = Val(ReadSQLNIK( _
            "SELECT AVG(TDF.Diastole) FROM TransaksiDetailFisik TDF " & _
            "INNER JOIN TransaksiDetail TD ON TDF.NoTransaksi=TD.NoUrut " & _
            "WHERE TD.IDInternet='" & NoRM & "' " & _
            "AND TD.CreatedDate>=DATEADD(MONTH,-3,GETDATE())"))

        '===========================
        ' 3. IMT (OPSIONAL)
        '===========================
        Dim RataIMT As Double = Val(ReadSQLNIK( _
            "SELECT AVG(TDF.IMT) FROM TransaksiDetailFisik TDF " & _
            "INNER JOIN TransaksiDetail TD ON TDF.NoTransaksi=TD.NoUrut " & _
            "WHERE TD.IDInternet='" & NoRM & "' " & _
            "AND TD.CreatedDate>=DATEADD(MONTH,-3,GETDATE())"))

        '===========================
        ' 4. KELUHAN
        '===========================
        Dim AdaKeluhanHT As Integer = Val(ReadSQLNIK( _
            "SELECT COUNT(*) FROM TransaksiDetail " & _
            "WHERE IDInternet='" & NoRM & "' " & _
            "AND CreatedDate>=DATEADD(MONTH,-3,GETDATE()) " & _
            "AND ( " & _
            "KeluhanUtama LIKE '%pusing%' OR KeluhanUtama LIKE '%sakit kepala%' OR " & _
            "KeluhanUtama LIKE '%tengkuk%' OR KeluhanUtama LIKE '%leher%' OR " & _
            "KeluhanUtama LIKE '%HT%' OR KeluhanUtama LIKE '%ht%' OR " & _
            "KeluhanTambahan LIKE '%pusing%' OR KeluhanTambahan LIKE '%sakit kepala%' OR " & _
            "KeluhanTambahan LIKE '%tengkuk%' OR KeluhanTambahan LIKE '%leher%' " & _
            ")"))


        '===========================
        ' 5. SCORING HIPERTENSI
        '===========================
        Dim Skor As Integer = 0

        If Umur >= 40 Then Skor += 2
        If JumlahTDNaik >= 2 Then Skor += 3
        If RataSistol >= 140 Or RataDiastol >= 90 Then Skor += 2
        If RataIMT >= 25 Then Skor += 1
        If AdaKeluhanHT >= 1 Then Skor += 1

        Dim StatusRisiko As String
        If Skor >= 7 Then
            StatusRisiko = "TINGGI"
        ElseIf Skor >= 4 Then
            StatusRisiko = "SEDANG"
        Else
            StatusRisiko = "RENDAH"
        End If

        '===========================
        ' 6. RETURN
        '===========================
        hasil("Umur") = Umur.ToString()
        hasil("JumlahTDNaik") = JumlahTDNaik.ToString()
        hasil("RataSistol") = FormatNumber(RataSistol, 0)
        hasil("RataDiastol") = FormatNumber(RataDiastol, 0)
        hasil("RataIMT") = FormatNumber(RataIMT, 1)
        hasil("Skor") = Skor.ToString()
        hasil("StatusRisiko") = StatusRisiko

        Return hasil
    End Function

    Public Function HitungRisikoStroke( _
        ByVal Umur As Integer, _
        ByVal StatusDM As String, _
        ByVal StatusHT As String, _
        ByVal IMT As Double _
    ) As Dictionary(Of String, String)

        Dim hasil As New Dictionary(Of String, String)
        Dim Skor As Integer = 0

        '===========================
        ' UMUR
        '===========================
        If Umur >= 55 Then Skor += 2

        '===========================
        ' DIABETES
        '===========================
        If StatusDM = "TINGGI" Then
            Skor += 3
        ElseIf StatusDM = "SEDANG" Then
            Skor += 2
        End If

        '===========================
        ' HIPERTENSI
        '===========================
        If StatusHT = "TINGGI" Then
            Skor += 3
        ElseIf StatusHT = "SEDANG" Then
            Skor += 2
        End If

        '===========================
        ' IMT
        '===========================
        If IMT >= 25 Then Skor += 1

        '===========================
        ' KATEGORI
        '===========================
        Dim StatusStroke As String
        If Skor >= 7 Then
            StatusStroke = "TINGGI"
        ElseIf Skor >= 4 Then
            StatusStroke = "SEDANG"
        Else
            StatusStroke = "RENDAH"
        End If

        hasil("Skor") = Skor.ToString()
        hasil("StatusRisiko") = StatusStroke

        Return hasil
    End Function

    Public Function NormalizeKeluhan(ByVal teks As String) As String
        If teks Is Nothing Then Return ""

        ' 1. Lowercase
        teks = teks.ToLower()

        ' 2. Hilangkan tanda baca (selain huruf & angka)
        teks = Regex.Replace(teks, "[^a-z0-9\s]", " ")

        ' 3. Rapikan spasi berlebih
        teks = Regex.Replace(teks, "\s+", " ").Trim()

        Return teks
    End Function

    Public Function GetSaranDiagnosaICD_ML(ByVal idPasien As String) As String
        Try
            Dim keluhan As String = ReadSQLNIK( _
                "SELECT TOP 1 " & _
                "ISNULL(KeluhanUtama,'') + ' ' + ISNULL(KeluhanTambahan,'') " & _
                "FROM TransaksiDetail " & _
                "WHERE IDInternet='" & idPasien & "' " & _
                "ORDER BY CreatedDate DESC")

            If keluhan.Trim() = "" Then Return "-"

            ' =========================
            ' PREPROCESS TEKS
            ' =========================
            keluhan = NormalizeKeluhan(keluhan)

            ' =========================
            ' PANGGIL ML LOKAL
            ' =========================
            Dim jsonResult As String = CallLocalICDML(keluhan)

            If jsonResult.StartsWith("ERROR") Then
                Return "-"
            End If

            ' =========================
            ' FORMAT OUTPUT
            ' =========================
            Return FormatICDResult(jsonResult)

        Catch
            Return "-"
        End Try
    End Function

    
    Private Sub ButtonSetMedscapeAwal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSetMedscapeAwal.Click
        Dim lokasi As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NoPoli'")
        Dim noAntreanHyu As String = ReadSQLNIK("SELECT NoAntreanHyu FROM TransaksiDetail WHERE NoUrut = '" & idTransaksi & "'")
        Dim tanggalFormat As String = ""
        Try
            Dim stringTanggal As String = idTransaksi.Substring(0, 8)
            Dim objTanggal As DateTime = DateTime.ParseExact(stringTanggal, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture)
            tanggalFormat = objTanggal.ToString("yyyy-MM-dd")
        Catch ex As Exception
            tanggalFormat = DateTime.Now.ToString("yyyy-MM-dd")
        End Try

        Dim urlWebService As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
        Dim url As String = urlWebService & "api/medscape-shck/ttv/" & lokasi & "/" & noAntreanHyu & "/" & tanggalFormat

        Try
            Dim jsonString As String = GetDataAPIRM(url)
            Dim jsonResult As JObject = JObject.Parse(jsonString)

            If jsonResult("code") IsNot Nothing AndAlso jsonResult("code").ToString() = "1" Then
                Dim dataObj As JObject = CType(jsonResult("data"), JObject)
                Dim name As String = dataObj("name").ToString()
                Dim examNo As String = dataObj("exam_no").ToString()

                Dim sistole As String = ""
                Dim diastole As String = ""
                Dim detakNadi As String = ""
                Dim nafas As String = ""
                Dim suhu As String = ""
                Dim saturasi As String = ""
                Dim tinggiBadan As String = ""
                Dim beratBadan As String = ""
                Dim bmi As String = ""

                Dim resultsArray As JArray = CType(dataObj("results"), JArray)

                For Each result As JObject In resultsArray
                    Dim parameter As String = result("parameter").ToString().ToLower()
                    Dim value As String = result("value").ToString()

                    Select Case parameter
                        Case "high"
                            sistole = value
                        Case "low"
                            diastole = value
                        Case "rate"
                            detakNadi = value
                        Case "tiwen"
                            suhu = value
                        Case "sp"
                            saturasi = value
                        Case "pr"
                            If detakNadi = "" Then detakNadi = value
                        Case "height"
                            tinggiBadan = value
                        Case "weight"
                            beratBadan = value
                        Case "bmi"
                            bmi = value
                    End Select
                Next

                If Not String.IsNullOrEmpty(detakNadi) AndAlso IsNumeric(detakNadi) Then
                    Dim nilaiNadi As Double = Convert.ToDouble(detakNadi)
                    nafas = Math.Round(nilaiNadi / 4).ToString()
                End If

                TextBoxSistolePemeriksaanAwal.Text = sistole
                TextBoxDiastolePemeriksaanAwal.Text = diastole
                TextBoxDetakNadiPemeriksaanAwal.Text = detakNadi
                TextBoxSuhuPemeriksaanAwal.Text = suhu
                TextBoxSaturasiPemeriksaanAwal.Text = saturasi
                TextBoxTinggiBadanPemeriksaanAwal.Text = tinggiBadan
                TextBoxBeratBadanPemeriksaanAwal.Text = beratBadan
                TextBoxIndeksPemeriksaanAwal.Text = bmi
                TextBoxNafasPemeriksaanAwal.Text = nafas

                MessageBox.Show("Data TTV berhasil ditarik untuk pasien: " & name, "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Else
                Dim errorMsg As String = "Gagal memuat data."

                If jsonResult("msg") IsNot Nothing Then
                    errorMsg = jsonResult("msg").ToString()
                ElseIf jsonResult("message") IsNot Nothing Then
                    errorMsg = jsonResult("message").ToString()
                End If

                MessageBox.Show(errorMsg, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan sistem: " & ex.Message, "Error Parsing", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class