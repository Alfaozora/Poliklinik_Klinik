Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Net
Imports System.Drawing
Imports Newtonsoft.Json
Imports Newtonsoft
Imports System.Security.Cryptography
Imports System.Collections.Generic
Imports Newtonsoft.Json.Linq
Imports System.Globalization
Imports DevExpress.XtraGrid.Columns

Public Class FormPendaftaranAwal
    Private formName As String = "FORM PENDAFTARAN AWAL"
    Private userInput As String = PoliKlinik.Lbluser.Text

    ' Variabel BPJS
    Private urlPcare As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_base_url'")

    ' Model untuk metadata
    Public Class MetadataAntrol
        Private _message As String
        Private _code As Integer

        Public Property message() As String
            Get
                Return _message
            End Get
            Set(ByVal value As String)
                _message = value
            End Set
        End Property

        Public Property code() As Integer
            Get
                Return _code
            End Get
            Set(ByVal value As Integer)
                _code = value
            End Set
        End Property
    End Class

    ' Model untuk satu entri antrean
    Public Class AntreanItem
        Private _nomorantrean As String
        Private _angkaantrean As Integer
        Private _nomorkartu As String
        Private _nik As String
        Private _namapeserta As String
        Private _kodedokter As String
        Private _namadokter As String
        Private _kodepoli As String
        Private _namapoli As String
        Private _keluhan As String
        Private _tanggalperiksa As String
        Private _tanggaldibuat As String
        Private _tanggalpanggil As String
        Private _tanggalbatal As String
        Private _tanggaldilayani As String
        Private _statusantrean As String
        Private _dibatalkan As Integer
        Private _dilayani As Integer
        Private _dipanggil As Integer
        Private _dilayanioleh As String
        Private _konter As String
        Private _kodelokasi As String
        Private _sisapanggilan As Integer
        Private _sumberantrean As String
        Private _jenispeserta As String
        Private _jeniskelamin As String
        Private _tanggallahir As String
        Private _alamat As String
        Private _nohp As String
        Private _kodefaskes As String
        Private _namafaskes As String

        Public Property nomorantrean() As String
            Get
                Return _nomorantrean
            End Get
            Set(ByVal value As String)
                _nomorantrean = value
            End Set
        End Property

        Public Property angkaantrean() As Integer
            Get
                Return _angkaantrean
            End Get
            Set(ByVal value As Integer)
                _angkaantrean = value
            End Set
        End Property

        Public Property nomorkartu() As String
            Get
                Return _nomorkartu
            End Get
            Set(ByVal value As String)
                _nomorkartu = value
            End Set
        End Property

        Public Property nik() As String
            Get
                Return _nik
            End Get
            Set(ByVal value As String)
                _nik = value
            End Set
        End Property

        Public Property namapeserta() As String
            Get
                Return _namapeserta
            End Get
            Set(ByVal value As String)
                _namapeserta = value
            End Set
        End Property

        Public Property kodedokter() As String
            Get
                Return _kodedokter
            End Get
            Set(ByVal value As String)
                _kodedokter = value
            End Set
        End Property

        Public Property namadokter() As String
            Get
                Return _namadokter
            End Get
            Set(ByVal value As String)
                _namadokter = value
            End Set
        End Property

        Public Property kodepoli() As String
            Get
                Return _kodepoli
            End Get
            Set(ByVal value As String)
                _kodepoli = value
            End Set
        End Property

        Public Property namapoli() As String
            Get
                Return _namapoli
            End Get
            Set(ByVal value As String)
                _namapoli = value
            End Set
        End Property

        Public Property keluhan() As String
            Get
                Return _keluhan
            End Get
            Set(ByVal value As String)
                _keluhan = value
            End Set
        End Property

        Public Property tanggalperiksa() As String
            Get
                Return _tanggalperiksa
            End Get
            Set(ByVal value As String)
                _tanggalperiksa = value
            End Set
        End Property

        Public Property tanggaldibuat() As String
            Get
                Return _tanggaldibuat
            End Get
            Set(ByVal value As String)
                _tanggaldibuat = value
            End Set
        End Property

        Public Property tanggalpanggil() As String
            Get
                Return _tanggalpanggil
            End Get
            Set(ByVal value As String)
                _tanggalpanggil = value
            End Set
        End Property

        Public Property tanggalbatal() As String
            Get
                Return _tanggalbatal
            End Get
            Set(ByVal value As String)
                _tanggalbatal = value
            End Set
        End Property

        Public Property tanggaldilayani() As String
            Get
                Return _tanggaldilayani
            End Get
            Set(ByVal value As String)
                _tanggaldilayani = value
            End Set
        End Property

        Public Property statusantrean() As String
            Get
                Return _statusantrean
            End Get
            Set(ByVal value As String)
                _statusantrean = value
            End Set
        End Property

        Public Property dibatalkan() As Integer
            Get
                Return _dibatalkan
            End Get
            Set(ByVal value As Integer)
                _dibatalkan = value
            End Set
        End Property

        Public Property dilayani() As Integer
            Get
                Return _dilayani
            End Get
            Set(ByVal value As Integer)
                _dilayani = value
            End Set
        End Property

        Public Property dipanggil() As Integer
            Get
                Return _dipanggil
            End Get
            Set(ByVal value As Integer)
                _dipanggil = value
            End Set
        End Property

        Public Property dilayanioleh() As String
            Get
                Return _dilayanioleh
            End Get
            Set(ByVal value As String)
                _dilayanioleh = value
            End Set
        End Property

        Public Property konter() As String
            Get
                Return _konter
            End Get
            Set(ByVal value As String)
                _konter = value
            End Set
        End Property

        Public Property kodelokasi() As String
            Get
                Return _kodelokasi
            End Get
            Set(ByVal value As String)
                _kodelokasi = value
            End Set
        End Property

        Public Property sisapanggilan() As Integer
            Get
                Return _sisapanggilan
            End Get
            Set(ByVal value As Integer)
                _sisapanggilan = value
            End Set
        End Property

        Public Property sumberantrean() As String
            Get
                Return _sumberantrean
            End Get
            Set(ByVal value As String)
                _sumberantrean = value
            End Set
        End Property

        Public Property jenispeserta() As String
            Get
                Return _jenispeserta
            End Get
            Set(ByVal value As String)
                _jenispeserta = value
            End Set
        End Property

        Public Property jeniskelamin() As String
            Get
                Return _jeniskelamin
            End Get
            Set(ByVal value As String)
                _jeniskelamin = value
            End Set
        End Property

        Public Property tanggallahir() As String
            Get
                Return _tanggallahir
            End Get
            Set(ByVal value As String)
                _tanggallahir = value
            End Set
        End Property

        Public Property alamat() As String
            Get
                Return _alamat
            End Get
            Set(ByVal value As String)
                _alamat = value
            End Set
        End Property

        Public Property nohp() As String
            Get
                Return _nohp
            End Get
            Set(ByVal value As String)
                _nohp = value
            End Set
        End Property

        Public Property kodefaskes() As String
            Get
                Return _kodefaskes
            End Get
            Set(ByVal value As String)
                _kodefaskes = value
            End Set
        End Property

        Public Property namafaskes() As String
            Get
                Return _namafaskes
            End Get
            Set(ByVal value As String)
                _namafaskes = value
            End Set
        End Property
    End Class

    ' Model untuk root response
    Public Class RootAntrean
        Private _response As List(Of AntreanItem)
        Private _metadataAntrol As MetadataAntrol

        Public Property response() As List(Of AntreanItem)
            Get
                Return _response
            End Get
            Set(ByVal value As List(Of AntreanItem))
                _response = value
            End Set
        End Property

        Public Property metadata() As MetadataAntrol
            Get
                Return _metadataAntrol
            End Get
            Set(ByVal value As MetadataAntrol)
                _metadataAntrol = value
            End Set
        End Property
    End Class

    Private Class varJson
        Public response As v4_BPJS
        Public metaData As MetaData
    End Class

    Private Class responseAntrol
        Public code As String
        Public status As String
        Public message As String
    End Class

    Private Class JsonGetPesertaAntrol
        Public metaData As v4_BPJS_Antrol
        Public response As v4_BPJS_Antrol
    End Class

    Private Sub PanelTop_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelTop.Paint
        Try
            e.Graphics.DrawString(formName, New Font("Arial", 12, FontStyle.Bold), Brushes.White, New Point(10, 10))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FormPendaftaranAwal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Control.CheckForIllegalCrossThreadCalls = False
            Me.MdiParent = PoliKlinik
            Me.Dock = DockStyle.Fill

            '# Hide tab header button TabControl1
            'TabControl1.Appearance = TabAppearance.FlatButtons
            TabControlDaftarMenu.ItemSize = New Size(0, 1)
            'TabControl1.SizeMode = TabSizeMode.Fixed

            '# Load Font DataGridView
            CreateDataGridViewAntreanOnline()

            ClearFormFields()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ButtonClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClose.Click
        Me.Close()
    End Sub

    'Private Sub SetControlAccess(ByVal formName As String)
    '    ' Ambil semua pengaturan hak akses untuk form dari database
    '    Dim accessData As Dictionary(Of String, Boolean) = GetAccessData(UserGroup, formName)

    '    ' Looping untuk mengatur kontrol berdasarkan nama kontrol
    '    For Each ctrl As Control In Me.Controls
    '        If accessData.ContainsKey(ctrl.Name) Then
    '            ctrl.Enabled = accessData(ctrl.Name)
    '        End If
    '    Next
    'End Sub

    'Private Function GetAccessData(ByVal groupName As String, ByVal formName As String) As Dictionary(Of String, Boolean)
    '    Dim accessData As New Dictionary(Of String, Boolean)
    '    Dim tblAccess As DataTable = ReadSQL("SELECT ControlName, IsAllowed FROM MsControlAccess WHERE GroupName = '" & groupName & "' AND FormName = '" & formName & "'")

    '    If tblAccess IsNot Nothing AndAlso tblAccess.Rows.Count > 0 Then
    '        For Each rowAccess As DataRow In tblAccess.Rows
    '            Dim controlName As String = rowAccess("ControlName").ToString()
    '            Dim isAllowed As Boolean = Convert.ToBoolean(rowAccess("IsAllowed"))
    '            accessData(controlName) = isAllowed
    '        Next
    '    End If

    '    Return accessData
    'End Function

    Private Sub ButtonFindPasien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFindPasien.Click
        FindPasien.SetForm("PendaftaranAwal")
        FindPasien.ShowDialog()
    End Sub

    Private Sub ButtonTambahPasienBaru_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTambahPasienBaru.Click
        FormMasterPasien.Show()
        FormMasterPasien.Focus()
    End Sub

    Private Sub ButtonClearData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClearData.Click
        ClearFormFields()
    End Sub

    Private Sub InitializeForm()
        ' Set ComboBox Poli Tujuan
        SetComboBoxPoliTujuan(True)
        ComboBoxPoliTujuan.Enabled = False

        ' Set ComboBox Dokter Poli
        InsertNewItemComboSQL("SELECT Nama FROM MasterDokter WHERE (Jenis LIKE '%Dokter%' OR Jenis LIKE '%Bidan%') AND NoNIP IS NOT NULL AND StatusAktif = 1", ComboBoxPilihanDokter)
        ComboBoxPilihanDokter.SelectedIndex = -1
        ComboBoxPilihanDokter.Enabled = False
        'LoadComboBoxDokter()

        ' Set ComboBox Perawat Poli
        InsertNewItemComboSQL("SELECT Nama FROM MasterDokter WHERE (Jenis like '%Perawat%' OR Jenis LIKE '%Bidan%') AND NoNIP IS NOT NULL AND StatusAktif = 1", ComboBoxPilihanPerawat)
        ComboBoxPilihanPerawat.SelectedIndex = -1
        ComboBoxPilihanPerawat.Enabled = False

        'Set ComboBox Marketing Poli
        InsertNewItemComboSQL("SELECT Nama FROM MasterDokter WHERE (Jenis like '%Marketing%') AND StatusAktif = 1", ComboBoxMarketing)
        ComboBoxMarketing.SelectedIndex = -1
        ComboBoxMarketing.Enabled = False

        CheckBoxPaket.Checked = False
        CheckBoxPaket.Visible = False

        TextBoxPoliKeluhanUtama.ResetText()
        TextBoxPoliKeluhanTambahan.ResetText()

        ' Disable Button & TextBox
        ButtonSimpan.BackColor = Color.FromArgb(225, 225, 225)
        ButtonSimpan.Enabled = False

        ButtonKalkulasi.BackColor = Color.FromArgb(225, 225, 225)
        ButtonKalkulasi.Enabled = False

        TextBoxPoliKeluhanUtama.Enabled = False
        TextBoxPoliKeluhanTambahan.Enabled = False

        ' Disable Pemeriksaan Fisik
        DisablePemeriksaanFisik()

        ' Disable TabControlMenu1
        ButtonTambahTindakan.BackColor = Color.FromArgb(225, 225, 225)
        ButtonTambahPaket.BackColor = Color.FromArgb(225, 225, 225)
        ButtonClearTindakan.BackColor = Color.FromArgb(225, 225, 225)
        ButtonScanQR.BackColor = Color.FromArgb(225, 225, 225)
        TabControlMenu1.Enabled = False

        ButtonTambahTindakan.Visible = True
        ButtonScanQR.Visible = True
        ButtonTambahPaket.Visible = False

        ' Clear Footer
        TextBoxTotalBruto.Text = 0
        TextBoxTotalDiskon.Text = 0
        TextBoxTotalNett.Text = 0
        TextBoxTotalPembulatan.Text = 0
        TextBoxTotalBayar.Text = 0

        ' Button Strip Menu
        ButtonMenu_Click(ButtonMenuPendaftaran, EventArgs.Empty)
    End Sub

    Public Sub LoadComboBoxDokter()
        ComboBoxPilihanDokter.Items.Clear()
        Dim getResponse As String = ""
        Dim messageError As String = ""
        Dim uri As String = urlPcare + "/dokter/1/100"

        getResponse = getDataFromPcare(uri)

        Dim varsespoli() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of v4_BPJS_Get_Dokter())(getResponse)

        For Each oneVar As v4_BPJS_Get_Dokter In varsespoli
            For index As Integer = 0 To oneVar.response.count - 1
                If oneVar.metaData.message <> "NO_CONTENT" Then
                    ComboBoxPilihanDokter.Items.Add(oneVar.response.list(index).nmDokter)
                Else
                    messageError = oneVar.metaData.message
                    Exit For
                End If
            Next
        Next

        ComboBoxPilihanDokter.SelectedIndex = -1
        ComboBoxPilihanDokter.Enabled = False
    End Sub

    Private Sub DisablePemeriksaanFisik()
        TextBoxSistole.Enabled = False
        TextBoxDiastole.Enabled = False
        TextBoxDetakNadi.Enabled = False
        TextBoxNafas.Enabled = False
        TextBoxSuhu.Enabled = False
        TextBoxSaturasi.Enabled = False
        TextBoxTinggiBadan.Enabled = False
        TextBoxBeratBadan.Enabled = False
        TextBoxLingkarPerut.Enabled = False

        TextBoxSistole.ResetText()
        TextBoxDiastole.ResetText()
        TextBoxDetakNadi.ResetText()
        TextBoxNafas.ResetText()
        TextBoxSuhu.ResetText()
        TextBoxSaturasi.ResetText()
        TextBoxTinggiBadan.ResetText()
        TextBoxBeratBadan.ResetText()
        TextBoxLingkarPerut.ResetText()
        TextBoxIndeks.ResetText()
        TextBoxIndeksKeterangan.ResetText()
    End Sub

    Private Sub EnablePemeriksaanFisik()
        TextBoxSistole.Enabled = True
        TextBoxDiastole.Enabled = True
        TextBoxDetakNadi.Enabled = True
        TextBoxNafas.Enabled = True
        TextBoxSuhu.Enabled = True
        TextBoxSaturasi.Enabled = True
        TextBoxTinggiBadan.Enabled = True
        TextBoxBeratBadan.Enabled = True
        TextBoxLingkarPerut.Enabled = True
    End Sub

    Private Sub SetComboBoxPoliTujuan(ByVal poliSakit As Boolean)
        ComboBoxPoliTujuan.Items.Clear()
        Dim tblsPoliTujuan As DataTable = ReadSQL("SELECT * FROM MasterPoliTujuan WHERE PoliSakit = '" & poliSakit & "'")
        For Each TrowPoliTujuan As DataRow In tblsPoliTujuan.Rows
            ComboBoxPoliTujuan.Items.Add(TrowPoliTujuan("NamaPoli"))
        Next

        ComboBoxPoliTujuan.SelectedIndex = -1
        ComboBoxPoliTujuan_SelectedIndexChanged(ComboBoxPoliTujuan, EventArgs.Empty)
    End Sub

    Public Sub ClearGridDataTindakan()
        Dim Tbls As DataTable = CreateTableTindakan()

        Tbls.Columns("DiscNilai").ReadOnly = False
        Tbls.Columns("DiscTindakan").ReadOnly = False
        GridControlTindakanPoli.MainView = GridViewTindakanPoli
        GridControlTindakanPoli.DataSource = Tbls

        ' Pastikan GridView memperbarui kolom berdasarkan DataSource
        GridViewTindakanPoli.PopulateColumns()

        ' Sembunyikan kolom yang tidak diperlukan
        Dim columnsToHide As String() = {"TindakanID", "PaketID", "KodeVoucher", "Jenis", "Penjamin"}
        For Each columnName As String In columnsToHide
            If GridViewTindakanPoli.Columns(columnName) IsNot Nothing Then
                GridViewTindakanPoli.Columns(columnName).Visible = False
            End If
        Next

        ' Sesuaikan lebar kolom
        GridViewTindakanPoli.BestFitColumns()

        ' Tambah Grouping
        GridViewTindakanPoli.SortInfo.ClearAndAddRange(New GridColumnSortInfo() _
                                            {New GridColumnSortInfo(GridViewTindakanPoli.Columns("Klasifikasi"), DevExpress.Data.ColumnSortOrder.Ascending) _
                                             }, 1)
    End Sub

    Function CreateTableTindakan() As DataTable
        Dim Thasil As New DataTable

        insertRowToTbls(Thasil, "tyinterger", "TindakanID")
        insertRowToTbls(Thasil, "Typstring", "Tindakan")
        insertRowToTbls(Thasil, "Typstring", "Jenis")
        insertRowToTbls(Thasil, "Typstring", "Biaya Tindakan")
        insertRowToTbls(Thasil, "Typstring", "DiscTindakan")
        insertRowToTbls(Thasil, "Typstring", "DiscNilai")
        insertRowToTbls(Thasil, "Typstring", "NettBayar")

        insertRowToTbls(Thasil, "Typstring", "PaketID")
        insertRowToTbls(Thasil, "Typstring", "Klasifikasi")
        insertRowToTbls(Thasil, "Typstring", "KodeVoucher")
        insertRowToTbls(Thasil, "Typstring", "Penjamin")

        For Each Tcol As DataColumn In Thasil.Columns
            Tcol.ReadOnly = True
        Next

        Return Thasil
    End Function

    Public Sub ClearGridDataPaket()
        Dim Tbls As DataTable = CreateTablePaket()

        GridControlTindakanPoli.MainView = GridViewPaketPoli
        GridControlTindakanPoli.DataSource = Tbls

        ' Pastikan GridView memperbarui kolom berdasarkan DataSource
        GridViewPaketPoli.PopulateColumns()

        ' Sembunyikan kolom yang tidak diperlukan
        Dim columnsToHide As String() = {"TindakanID", "PaketID", "KodeVoucher", "DurasiAktif", "Kuota", "DetailTindakan", "Penjamin"}
        For Each columnName As String In columnsToHide
            If GridViewPaketPoli.Columns(columnName) IsNot Nothing Then
                GridViewPaketPoli.Columns(columnName).Visible = False
            End If
        Next

        ' Sesuaikan lebar kolom
        GridViewPaketPoli.BestFitColumns()

        ' Tambah Grouping
        GridViewPaketPoli.SortInfo.ClearAndAddRange(New GridColumnSortInfo() _
                                            {New GridColumnSortInfo(GridViewPaketPoli.Columns("Jenis Paket"), DevExpress.Data.ColumnSortOrder.Ascending) _
                                             }, 1)
    End Sub

    Function CreateTablePaket() As DataTable
        Dim Thasil As New DataTable

        insertRowToTbls(Thasil, "tyinterger", "TindakanID")
        insertRowToTbls(Thasil, "Typstring", "PaketID")
        insertRowToTbls(Thasil, "Typstring", "KodeVoucher")
        insertRowToTbls(Thasil, "Typstring", "Nama Paket")
        insertRowToTbls(Thasil, "Typstring", "Keterangan Paket")
        insertRowToTbls(Thasil, "Typstring", "DurasiAktif")
        insertRowToTbls(Thasil, "Typstring", "Kuota")
        insertRowToTbls(Thasil, "Typstring", "Jenis Paket")
        insertRowToTbls(Thasil, "Typstring", "Penjamin")
        insertRowToTbls(Thasil, "Typstring", "DetailTindakan")
        insertRowToTbls(Thasil, "Typstring", "Harga Awal")
        insertRowToTbls(Thasil, "Typstring", "Diskon")
        insertRowToTbls(Thasil, "Typstring", "Harga Nett")

        For Each Tcol As DataColumn In Thasil.Columns
            Tcol.ReadOnly = True
        Next

        Return Thasil
    End Function

    Private Sub ClearFormFields()
        ClearPatientData()
        ClearGridDataTindakan()
        ClearGridDataPaket()

        InitializeForm()
    End Sub

    Private Sub ClearPatientData()
        TextBoxRM.ResetText()
        TextBoxNama.ResetText()
        TextBoxNoNIK.ResetText()
        TextBoxNoIHS.ResetText()
        RadioButtonJenisKelaminLaki.Checked = True
        DateTimePickerTglLahir.Value = DateAndTime.Now
        TextBoxUmur.ResetText()
        TextBoxNoHP.ResetText()
        TextBoxAlamat.ResetText()
        TextBoxProlanis.ResetText()
        TextBoxPRB.ResetText()
        TextBoxNoKartuBPJS.ResetText()
        TextBoxStatusPeserta.ResetText()
        TextBoxPPK.ResetText()
        RadioButtonKunjunganSakit.Checked = True
        RadioButtonStatusRawatJalan.Checked = True
        CheckBoxStatusHandaya.Checked = False
        CheckBoxStatusDifabel.Checked = False
        CheckBoxStatusLansia.Checked = False
        CheckBoxStatusGawatDarurat.Checked = False
        Dim defaultFotoPath As String = Application.StartupPath & "\Uploads\BlankProfile.png"
        PictureBoxFotoPasien.Image = Image.FromFile(defaultFotoPath)
        PictureBoxFotoPasien.SizeMode = PictureBoxSizeMode.Zoom

        ' Notifikasi
        LabelNotifikasiNIK.Visible = False
        LabelNotifikasiIHS.Visible = False
    End Sub

    Function ValidasiInputPendaftaran() As Boolean
        Dim result As DialogResult

        ' Set data master poli tujuan
        Dim tblPoli As DataTable = ReadSQL("SELECT * FROM MasterPoliTujuan WHERE NamaPoli = '" & ComboBoxPoliTujuan.Text & "'")
        Dim TrowPoli As DataRow = tblPoli.Rows(0)

        ' Validasi pasien
        If TextBoxRM.Text = "" Then
            MsgBox("Masukkan data pasien terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        ' Validasi poli tujuan
        If ComboBoxPoliTujuan.Text = "" Then
            MsgBox("Masukkan poli tujuan yang sesuai.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        ' Validasi inputan dokter & perawat
        If Not TrowPoli("JenisPoli").Equals("LABORATORIUM") And CheckBoxPaket.Checked = False Then
            ' Validasi Inputan Keluhan
            Dim inputKeluhanUtama As String = TextBoxPoliKeluhanUtama.Text.Trim()
            Dim inputKeluhanTambahan As String = TextBoxPoliKeluhanTambahan.Text.Trim()

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

            ' Validasi Inputan Dokter
            If ComboBoxPilihanDokter.FindStringExact(ComboBoxPilihanDokter.Text) < 0 Then
                MsgBox("Masukkan nama dokter yang sesuai.", MsgBoxStyle.Exclamation, "Warning!")
                Return False
            End If

            ' Validasi Inputan Perawat
            If ComboBoxPilihanPerawat.FindStringExact(ComboBoxPilihanPerawat.Text) < 0 Then
                MsgBox("Masukkan nama perawat yang sesuai.", MsgBoxStyle.Exclamation, "Warning!")
                Return False
            End If
        End If

        ' Validasi tindakan klinik
        If TrowPoli("TindakanAwal") = True Then
            Dim Tbls As DataTable = GridControlTindakanPoli.DataSource
            Tbls.AcceptChanges()
            Dim Tbool As Boolean = False
            If Tbls.Rows.Count > 0 Then
                Tbool = True
            End If

            If Tbool = False Then
                MsgBox("Tambahkan tindakan terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
                Return False
            End If
        End If

        ' Validasi Pendaftaran Pasien Dengan Poli Yang Sama Dalam 1 Hari
        If CheckSQL("SELECT * FROM TransaksiDetail WHERE StatusBPJS = 'True' AND IDInternet = '" & TextBoxRM.Text & "' AND JenisPoli = '" & TrowPoli("NamaPoli") & "' AND CONVERT(DATE, TanggalTransaksi) = '" & Format(DateAndTime.Now, "yyyy-MM-dd") & "' AND DeletedDate IS NULL") = True Then
            If TrowPoli("TindakanAwal") = True Then
                result = MessageBox.Show("Pasien tersebut sudah terdaftar dengan poli yang sama dalam satu hari, lanjutkan?", "Validasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.No Then
                    MessageBox.Show("Pilih poli yang berbeda.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return False
                End If
            Else
                MsgBox("Pasien tersebut sudah terdaftar dengan poli yang sama dalam satu hari.", MsgBoxStyle.Exclamation, "Warning!")
                Return False
            End If
        End If

        ' Validasi pemeriksaan fisik
        If TrowPoli("PoliSakit") = False Then
            '# Cek Nilai Vital Statistik & Antropometri
            ' Sistole
            If CekNilaiVitalAntropometri("Sistole", TextBoxSistole.Text) = False Then Return False

            ' Diastole
            If CekNilaiVitalAntropometri("Diastole", TextBoxDiastole.Text) = False Then Return False

            ' Heart Rate
            If CekNilaiVitalAntropometri("Heart Rate", TextBoxDetakNadi.Text) = False Then Return False

            ' Respiratory Rate
            If CekNilaiVitalAntropometri("Respiratory Rate", TextBoxNafas.Text) = False Then Return False

            ' Suhu
            If CekNilaiVitalAntropometri("Suhu", TextBoxSuhu.Text) = False Then Return False

            ' Tinggi Badan
            If CekNilaiVitalAntropometri("Tinggi Badan", TextBoxTinggiBadan.Text) = False Then Return False

            ' Berat Badan
            If CekNilaiVitalAntropometri("Berat Badan", TextBoxBeratBadan.Text) = False Then Return False

            ' Lingkar Perut
            If CekNilaiVitalAntropometri("Lingkar Perut", TextBoxLingkarPerut.Text) = False Then Return False
        End If

        Return True
    End Function

    Public Sub LoadTindakan(ByRef Trow() As DataRow)
        If ValidasiTambahTindakan(Trow) = True Then
            Dim Tbls As DataTable = GridControlTindakanPoli.DataSource
            Tbls.AcceptChanges()
            If Trow.Count > 0 Then
                For i As Integer = 0 To Trow.Length - 1
                    Dim Tnew As DataRow = Tbls.NewRow
                    Tnew("PaketID") = "0"
                    Tnew("TindakanID") = Trow(i)("ID")
                    Tnew("Tindakan") = Trow(i)("Tindakan")
                    Tnew("Jenis") = Trow(i)("Jenis")
                    Tnew("Biaya Tindakan") = Trow(i)("Biaya Tindakan")
                    Tnew("Klasifikasi") = "Tindakan"
                    Tnew("DiscNilai") = 0
                    Tnew("NettBayar") = 0
                    Tnew("DiscTindakan") = 0
                    Tbls.Rows.Add(Tnew)
                Next
                Tbls.AcceptChanges()

                GridViewTindakanPoli.ExpandAllGroups()

                KalkulasiTindakan()
            End If
        End If
    End Sub

    Function ValidasiTambahTindakan(ByRef Trow() As DataRow)
        Dim Tbls As DataTable = GridControlTindakanPoli.DataSource
        Tbls.AcceptChanges()
        If Trow.Count > 0 Then
            For i As Integer = 0 To Trow.Length - 1
                For Each Ttemp As DataRow In Tbls.Rows
                    If Ttemp("TindakanID") = Trow(i)("ID") Then
                        MsgBox("Tindakan sudah ada di grid.", MsgBoxStyle.Exclamation, "Warning!")
                        Return False
                    End If
                Next
            Next
        End If
        Return True
    End Function

    Private Sub butsaved_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSimpan.Click
        ' Get Data Master Poli Tujuan
        Dim tblPoli As DataTable = ReadSQL("SELECT * FROM MasterPoliTujuan WHERE NamaPoli = '" & ComboBoxPoliTujuan.Text & "'")
        Dim rowPoli As DataRow = tblPoli.Rows(0)

        If ComboBoxPilihanDokter.SelectedIndex = 0 OrElse ComboBoxPilihanDokter.Text = "-- Pilih Dokter --" Then
            MessageBox.Show("Silakan pilih dokter yang valid terlebih dahulu.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            ComboBoxPilihanDokter.Focus()
            Exit Sub
        End If

        Select Case rowPoli("JenisPoli")
            Case "UMUM"
                If GridControlTindakanPoli.MainView Is GridViewTindakanPoli Then
                    If KalkulasiTindakan() = True Then
                        ' Validasi Akses Ke Pembayaran
                        If ValidasiAccess(Me.Name, "AksesPembayaranInvoice") = True Then
                            SimpanPendaftaran()
                        End If
                    End If
                ElseIf GridControlTindakanPoli.MainView Is GridViewPaketPoli Then
                    If KalkulasiPaketTindakan() = True Then
                        If CDbl(TextBoxTotalBayar.Text) = 0 And RadioButtonKunjunganSakit.Checked = True Then
                            SimpanPenggunaanPaket()
                        Else
                            ' Validasi Akses Ke Pembayaran
                            If ValidasiAccess(Me.Name, "AksesPembayaranInvoice") = True Then
                                SimpanPendaftaran()
                            End If
                        End If
                    End If
                End If
            Case "GIGI"
                If GridControlTindakanPoli.MainView Is GridViewTindakanPoli Then
                    If KalkulasiTindakan() = True Then SimpanPendaftaran()
                Else
                    MsgBox("Belum Support Paket Tindakan.", MsgBoxStyle.Exclamation, "Warning!")
                End If
            Case "LABORATORIUM"
                SimpanPendaftaran()
        End Select
    End Sub

    Private Function ValidasiAccess(ByVal formName As String, ByVal controlName As String) As Boolean
        ' Get Group ID
        Dim userGroupID As String = ReadSQLNIK("SELECT GroupID FROM Users WHERE UserID = '" & userInput & "'")

        ' Validasi Akses Kontrol
        If CheckSQL("SELECT * FROM MsControlAccess WHERE GroupName = '" & userGroupID & "' AND FormName = '" & formName & "' AND ControlName = '" & controlName & "' AND IsAllowed = 1") = False Then
            MsgBox("User anda tidak memiliki akses.", MsgBoxStyle.Exclamation, "Error!")
            Return False
        End If

        Return True
    End Function

    Public Sub SimpanPendaftaran()
        If ValidasiInputPendaftaran() = True Then
            Dim idTransaksi As String = ""
            Dim kodeDokter As String = ""
            Dim JenisKunjungan As String = ""
            Dim jenisRawat As String = ""
            Dim marketingPoliValue As String

            'Marketing Default NULL 
            If ComboBoxMarketing.SelectedIndex = -1 Then
                marketingPoliValue = "NULL"
            Else
                marketingPoliValue = ComboBoxMarketing.Text
            End If

            '# Get Data Master Poli
            Dim tblPoli As DataTable = ReadSQL("SELECT * FROM MasterPoliTujuan WHERE NamaPoli = '" & ComboBoxPoliTujuan.Text & "'")
            Dim TrowPoli As DataRow = tblPoli.Rows(0)

            '# Generate No Urut Transaksi
            Dim nomorUrutTransaksi As String = generateNoTransaksi(TrowPoli("KodeTransaksi"), TrowPoli("JenisPoli"), DateTime.Now.ToString("yyyyMMdd"), False)

            '# Get Kode Dokter
            Dim tblsDokter As DataTable = ReadSQL("SELECT ID FROM MasterDokter WHERE Nama = '" & ComboBoxPilihanDokter.Text & "'")
            If tblsDokter.Rows.Count > 0 Then
                Dim trowDokter As DataRow = tblsDokter.Rows(0)
                kodeDokter = trowDokter("ID")
            Else
                kodeDokter = "-"
            End If

            '# Get Jenis Kunjungan
            If RadioButtonKunjunganSakit.Checked Then
                JenisKunjungan = "Kunjungan Sakit"
            ElseIf RadioButtonkunjunganSehat.Checked Then
                JenisKunjungan = "Kunjungan Sehat"
            End If

            '# Get Jenis Rawat
            If RadioButtonStatusRawatJalan.Checked Then
                jenisRawat = "Rawat Jalan"
            ElseIf RadioButtonStatusRawatInap.Checked Then
                jenisRawat = "Rawat Inap"
            ElseIf RadioButtonPromotifPreventif.Checked Then
                jenisRawat = "Promotif Preventif"
            End If

            '# Set data dictionary yang akan dikirim ke form pembayaran
            Dim dataDictionary As New Dictionary(Of String, Object)()

            Select Case TrowPoli("JenisPoli")
                Case "UMUM", "GIGI"
                    If TrowPoli("TindakanAwal") = True Then
                        '# KUNJUNGAN SAKIT

                        ' Set Tabel Tindakan
                        Dim tblTindakan As DataTable = GridControlTindakanPoli.DataSource
                        tblTindakan.AcceptChanges()

                        ' Set Jenis Transaksi
                        Dim jenisTindakan As String = ""
                        If GridControlTindakanPoli.MainView Is GridViewTindakanPoli Then
                            jenisTindakan = "Tindakan"
                        ElseIf GridControlTindakanPoli.MainView Is GridViewPaketPoli Then
                            jenisTindakan = "Paket"
                        End If

                        If TrowPoli("JenisPoli") = "UMUM" Then
                            dataDictionary.Add("Jenis Transaksi", "AWAL")
                        ElseIf TrowPoli("JenisPoli") = "GIGI" Then
                            dataDictionary.Add("Jenis Transaksi", "AWALGIGI")
                        End If

                        dataDictionary.Add("ID Transaksi", "")
                        dataDictionary.Add("No Urut Transaksi", "")
                        dataDictionary.Add("Poli Tujuan", ComboBoxPoliTujuan.Text)
                        dataDictionary.Add("No Rekam Medis", TextBoxRM.Text)
                        dataDictionary.Add("No BPJS", TextBoxNoKartuBPJS.Text)
                        dataDictionary.Add("No NIK", TextBoxNoNIK.Text)
                        dataDictionary.Add("Nama Pasien", TextBoxNama.Text)
                        dataDictionary.Add("Nama Dokter", ComboBoxPilihanDokter.Text)
                        dataDictionary.Add("Nama Perawat", ComboBoxPilihanPerawat.Text)
                        dataDictionary.Add("Nama Marketing", marketingPoliValue)
                        dataDictionary.Add("Keluhan Utama", TextBoxPoliKeluhanUtama.Text)
                        dataDictionary.Add("Keluhan Tambahan", TextBoxPoliKeluhanTambahan.Text)
                        dataDictionary.Add("Jenis Kunjungan", JenisKunjungan)
                        dataDictionary.Add("Jenis Rawat", jenisRawat)
                        dataDictionary.Add("Jenis Tindakan", jenisTindakan)

                        dataDictionary.Add("Status Handaya", CheckBoxStatusHandaya.Checked)
                        dataDictionary.Add("Status Difabel", CheckBoxStatusDifabel.Checked)
                        dataDictionary.Add("Status Lansia", CheckBoxStatusLansia.Checked)
                        dataDictionary.Add("Status Gawat Darurat", CheckBoxStatusGawatDarurat.Checked)

                        FormPembayaran.DataDictionary = dataDictionary
                        FormPembayaran.SetDataFromPendaftaran(TextBoxTotalBayar.Text, tblTindakan, TextBoxTotalBruto.Text, TextBoxTotalDiskon.Text, TextBoxTotalPembulatan.Text)
                        FormPembayaran.ShowDialog()
                    Else
                        '# KUNJUNGAN SEHAT

                        If CheckBridgingPcareActive() = False Then
                            MsgBox("Eror : FKTP Belum mengaktifkan bridging PCare, hubungi IT untuk mengaktifkan.", MsgBoxStyle.Exclamation, "Error!")
                            Exit Sub
                        End If

                        '# Variabel BPJS
                        Dim noUrutBPJS As String = ""
                        Dim uriBPJS As String = urlPcare + "pendaftaran"
                        Dim tglDaftarBPJS As String = Format(DateAndTime.Now, "dd-MM-yyyy") ' Get tglDaftarBPJS
                        Dim noBPJS As String = TextBoxNoKartuBPJS.Text ' Get noKartu
                        Dim kdprovider As String = ReadSQLNIK("SELECT KdProviderPst FROM MasterPasienBPJS WHERE NoKartu = '" & noBPJS & "'") ' Get kdprovider
                        Dim kdPoli As String = TrowPoli("KodeBPJS") ' Get kdPoli
                        Dim keluhanUtama As String = TextBoxPoliKeluhanUtama.Text ' Get keluhan
                        Dim kunjSakit As String = "" ' Set kunjSakit

                        If TrowPoli("PoliSakit") = True Then
                            kunjSakit = "true" ' Jika kunjSakit bernilai true
                        ElseIf TrowPoli("PoliSakit") = False Then
                            kunjSakit = "false" ' Jika kunjSakit bernilai false
                        End If

                        Dim kdTkp As String = "" ' Set kdTkp

                        If RadioButtonStatusRawatJalan.Checked = True Then
                            kdTkp = RadioButtonStatusRawatJalan.Tag ' Jika status rawat jalan
                        ElseIf RadioButtonStatusRawatInap.Checked = True Then
                            kdTkp = RadioButtonStatusRawatInap.Tag ' Jika status rawat inap
                        ElseIf RadioButtonPromotifPreventif.Checked = True Then
                            kdTkp = RadioButtonPromotifPreventif.Tag ' Jika status promotif
                        End If

                        ' Set parameter untuk POST data ke pcare BPJS
                        Dim parameterPendaftaran As String = "{" & _
                               """kdProviderPeserta"" : """ & kdprovider & """," & _
                               """tglDaftar"" : """ & tglDaftarBPJS & """," & _
                               """noKartu"" : """ & noBPJS & """," & _
                               """kdPoli"" : """ & kdPoli & """," & _
                               """keluhan"": """ & keluhanUtama & """," & _
                               """kunjSakit"": " & kunjSakit & "," & _
                               """sistole"": """ & TextBoxSistole.Text & """," & _
                               """diastole"": """ & TextBoxDiastole.Text & """," & _
                               """beratBadan"": """ & TextBoxBeratBadan.Text & """," & _
                               """tinggiBadan"": """ & TextBoxTinggiBadan.Text & """," & _
                               """respRate"": """ & TextBoxNafas.Text & """," & _
                               """lingkarPerut"": """ & TextBoxLingkarPerut.Text & """," & _
                               """heartRate"": """ & TextBoxDetakNadi.Text & """," & _
                               """rujukBalik"": 0," & _
                               """kdTkp"": """ & kdTkp & """" & _
                              "}"

                        Dim jsonString As String = PostDataFromPcare(parameterPendaftaran, uriBPJS, "POST")
                        jsonString = "[" + jsonString + "]"
                        Dim jsonObject() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of varJson())(jsonString)

                        ' Get data no urut pendaftaran pcare BPJS
                        For Each rowData As varJson In jsonObject
                            Dim codeMetaData As Integer = Convert.ToInt32(rowData.metaData.code)
                            Dim messageMetaData As String = rowData.metaData.message
                            Dim messageResponse As String = rowData.response.message

                            Select Case codeMetaData
                                Case 200, 201, 204
                                    noUrutBPJS = messageResponse ' Set Nomor Urut BPJS
                                Case Else
                                    If messageMetaData <> "Peserta sudah di-entri di poli yang sama pada hari yang sama" Then
                                        Dim messageError As String = ""
                                        If messageResponse <> "" And messageMetaData <> "" Then
                                            messageError = messageResponse & " (" & messageMetaData & ")"
                                        ElseIf messageResponse <> "" Then
                                            messageError = messageResponse
                                        ElseIf messageMetaData <> "" Then
                                            messageError = messageMetaData
                                        End If

                                        MsgBox("Eror BPJS : " & vbCrLf & messageError, MsgBoxStyle.Exclamation, "Error!")

                                        Exit Sub
                                    End If
                            End Select
                        Next

                        ' Insert TransaksiPoli
                        WriteSQL("INSERT INTO TransaksiPoli (IDInternet, DokterPoli, PerawatPoli, TglPoli, CreatedDate, CreatedBy, ClosedBayar, KodeDokter, NoUrut, MarketingPoli) " & _
                             "VALUES('" & TextBoxRM.Text & "','" & ComboBoxPilihanDokter.Text & "', '" & ComboBoxPilihanPerawat.Text & "', GETDATE(), GETDATE(),'" & userInput & "', '12/31/9998', '" & kodeDokter & "', '" & nomorUrutTransaksi & "', '" & marketingPoliValue & "')", 4)

                        ' Set ID Poli
                        idTransaksi = ReadSQLNIK("SELECT TransPoliID FROM TransaksiPoli WHERE NoUrut = '" & nomorUrutTransaksi & "'")

                        ' Insert TransaksiDetail
                        WriteSQL("INSERT INTO TransaksiDetail(NoUrutBPJS, NoTransaksi, JenisKunjungan, JenisRawat, JenisTransaksi, JenisPoli, TanggalTransaksi, KeluhanUtama, KeluhanTambahan, IDInternet, StatusBPJS, NoUrut, StatusHandaya, StatusLansia, StatusDifabel, StatusGawatDarurat, CreatedBy, CreatedDate) " & _
                                        "VALUES('" & noUrutBPJS & "', '" & idTransaksi & "', '" & JenisKunjungan & "', '" & jenisRawat & "', 'POLI', '" & TrowPoli("NamaPoli") & "', GETDATE(),'" & TextBoxPoliKeluhanUtama.Text & "', '" & TextBoxPoliKeluhanTambahan.Text & "', " & _
                                        "'" & TextBoxRM.Text & "'," & Convert.ToInt32(True) & ", '" & nomorUrutTransaksi & "', '" & CheckBoxStatusHandaya.Checked & "', '" & CheckBoxStatusLansia.Checked & "', '" & CheckBoxStatusDifabel.Checked & "', '" & CheckBoxStatusGawatDarurat.Checked & "', '" & userInput & "', GETDATE())", 4)

                        ' Pesan Success
                        If noUrutBPJS = "" Then
                            ' Non BPJS
                            MsgBox("Berhasil Menyimpan Data Pendaftaran Pasien." & vbCrLf & "No Transaksi : " & nomorUrutTransaksi, MsgBoxStyle.Information, "Success!")
                        Else
                            ' BPJS
                            MsgBox("Berhasil Menyimpan Data Pendaftaran Pasien." & vbCrLf & "No Transaksi : " & nomorUrutTransaksi & vbCrLf & "No Urut BPJS : " & noUrutBPJS, MsgBoxStyle.Information, "Success!")
                        End If

                        ClearFormFields()
                    End If
                Case "LABORATORIUM"
                    ' Insert TransaksiLab
                    WriteSQL("INSERT INTO TransaksiLab (IDInternet,DokterRequest,DokterLab,TglLab,TotalTagihan,TotalDisc,Pembulatan,NettBayar,ClosedTransaksi,CreateDate,CreateBy,NoUrut, StatusSoftcopy, StatusHardcopy) " & _
                             "VALUES('" & TextBoxRM.Text & "', '-', '-', GETDATE(), 0, 0, 0, 0, 0, GETDATE(), '" & userInput & "', '" & nomorUrutTransaksi & "',0,0)", 4)

                    ' Set ID Poli
                    idTransaksi = ReadSQLNIK("SELECT TransLabID FROM TransaksiLab WHERE NoUrut = '" & nomorUrutTransaksi & "'")

                    ' Insert TransaksiDetail
                    WriteSQL("INSERT INTO TransaksiDetail(NoUrutBPJS, NoTransaksi, JenisKunjungan, JenisRawat, JenisTransaksi, JenisPoli, TanggalTransaksi, KeluhanUtama, KeluhanTambahan, IDInternet, StatusBPJS, NoUrut, StatusHandaya, StatusLansia, StatusDifabel, StatusGawatDarurat, CreatedBy, CreatedDate) " & _
                             "VALUES(NULL, '" & idTransaksi & "', '" & JenisKunjungan & "', '" & jenisRawat & "', 'LAB', '" & TrowPoli("NamaPoli") & "', GETDATE(), '" & TextBoxPoliKeluhanUtama.Text & "', '" & TextBoxPoliKeluhanUtama.Text & "', '" & TextBoxRM.Text & "'," & Convert.ToInt32(False) & ", '" & nomorUrutTransaksi & "', '" & CheckBoxStatusHandaya.Checked & "', " & _
                             "'" & CheckBoxStatusLansia.Checked & "', '" & CheckBoxStatusDifabel.Checked & "', '" & CheckBoxStatusGawatDarurat.Checked & "', '" & userInput & "', GETDATE())", 4)

                    MsgBox("Data Saved. No Urut : " & nomorUrutTransaksi, MsgBoxStyle.Information, "Success!")

                    ClearFormFields()
            End Select
        End If
    End Sub

    Public Sub SimpanPenggunaanPaket()
        If ValidasiInputPendaftaran() = True Then
            Dim idTransaksi As String = ""
            Dim jenisKunjungan As String = ""
            Dim jenisRawat As String = ""
            Dim NoUrutBPJS As String = ""
            Dim tblTindakan As DataTable = GridControlTindakanPoli.DataSource
            Dim statusBPJS As Boolean = False

            Dim NewHeader As DataTable = CreateTableInvoice()

            ' Get Data Master Poli Tujuan
            Dim tblPoli As DataTable = ReadSQL("SELECT * FROM MasterPoliTujuan WHERE NamaPoli = '" & ComboBoxPoliTujuan.Text & "'")
            Dim rowPoli As DataRow = tblPoli.Rows(0)

            ' Get Kode Dokter
            Dim kodeDokter As String = ReadSQLNIK("SELECT ID FROM MasterDokter WHERE Nama = '" & ComboBoxPilihanDokter.Text & "'")

            ' Generate No Urut Transaksi
            Dim nomorUrutTransaksi As String = generateNoTransaksi(rowPoli("KodeTransaksi"), rowPoli("JenisPoli"), DateTime.Now.ToString("yyyyMMdd"), False)

            ' Get Jenis Kunjungan
            If RadioButtonKunjunganSakit.Checked Then
                jenisKunjungan = "Kunjungan Sakit"
            ElseIf RadioButtonkunjunganSehat.Checked Then
                jenisKunjungan = "Kunjungan Sehat"
            End If

            ' Get Jenis Rawat
            If RadioButtonStatusRawatJalan.Checked Then
                jenisRawat = "Rawat Jalan"
            ElseIf RadioButtonStatusRawatInap.Checked Then
                jenisRawat = "Rawat Inap"
            ElseIf RadioButtonPromotifPreventif.Checked Then
                jenisRawat = "Promotif Preventif"
            End If

            If ValidasiPenggunaanPaket() = True Then
                Select Case rowPoli("JenisPoli")
                    Case "UMUM"
                        ' Insert Tabel TransaksiPoli
                        WriteSQL("INSERT INTO TransaksiPoli (IDInternet, DokterPoli, PerawatPoli, TglPoli, CreatedDate, CreatedBy, ClosedBayar, KodeDokter, NoUrut, StatusKeterangan, StatusTransaksi, ArrivedDate) " & _
                             "VALUES('" & TextBoxRM.Text & "','" & ComboBoxPilihanDokter.Text & "', '" & ComboBoxPilihanPerawat.Text & "', GETDATE(), GETDATE(),'" & userInput & "', '12/31/9998', '" & kodeDokter & "', '" & nomorUrutTransaksi & "', 'Belum Diperiksa', 'arrived', GETDATE())", 4)

                        ' Set ID Poli
                        idTransaksi = ReadSQLNIK("SELECT TransPoliID FROM TransaksiPoli WHERE NoUrut = '" & nomorUrutTransaksi & "'")

                        ' Set Total Tagihan
                        Dim totalTagihan As Double = 0

                        ' Insert ke tabel TransaksiPoliDetail (Cek Inputan Paket Reguler / Per-Tindakan)
                        For Each rowTindakan As DataRow In tblTindakan.Rows
                            Dim tblPaket As New DataTable

                            If rowTindakan("Jenis Paket").ToString() = "Paket Reguler" Then
                                tblPaket = ReadSQL("SELECT * FROM MasterPaketTindakanDetail WHERE PaketID = '" & rowTindakan("PaketID").ToString() & "'")
                            ElseIf rowTindakan("Jenis Paket").ToString() = "Paket Per-Tindakan" Then
                                tblPaket = ReadSQL("SELECT * FROM TransaksiPaketTindakanDetail WHERE PaketID = '" & rowTindakan("PaketID").ToString() & "' AND KodeVoucher = '" & rowTindakan("KodeVoucher").ToString & "' AND TindakanID = '" & rowTindakan("TindakanID").ToString() & "'")
                            End If

                            For Each rowPaket As DataRow In tblPaket.Rows
                                WriteSQL("INSERT INTO TransaksiPoliDetail(Awal, TransPoliID, TindakanID, PaketID, NamaTindakan, JenisTindakan, BiayaTindakan, DiscTindakan, NettBayar, admin, transaksitime, DiscPersenTindakan, StatusPembayaran, KodeVoucher, Penjamin) " & _
                                     "VALUES('1', '" & idTransaksi & "', '" & rowPaket("TindakanID").ToString() & "', '" & rowPaket("PaketID").ToString() & "', '" & rowPaket("NamaTindakan") & "', '" & rowPaket("JenisTindakan") & "', " & CDbl(rowPaket("BiayaTindakan")) & ", " & CDbl(rowPaket("DiskonTindakan")) & ", " & CDbl(rowPaket("NettBayar")) & ", '" & userInput & "', GETDATE(), 0, 'PAID', '" & rowTindakan("KodeVoucher").ToString & "', '" & rowTindakan("Penjamin").ToString & "')", 4)

                                ' Summary Total Tagihan
                                totalTagihan = totalTagihan + CDbl(rowPaket("NettBayar"))
                            Next
                        Next

                        ' Insert ke tabel TransaksiPoliBayarAwal
                        WriteSQL("INSERT INTO TransaksiPoliBayarAwal (TransJenis, TransPoliID, JenisBayar, NoJenisBayar, JumlahBayar, admin, transaksitime, mesin, kartu) " & _
                                 "VALUES('POLI', '" & idTransaksi & "', 'VOUCHER', '-', '" & CDbl(totalTagihan) & "', '" & userInput & "', GETDATE(), '', '')", 4)

                        ' Set Jenis Bayar
                        Dim jenisBayar As String = "UMUM"

                        ' Insert TransaksiDetail
                        WriteSQL("INSERT INTO TransaksiDetail(NoUrutBPJS, NoTransaksi, JenisKunjungan, JenisRawat, JenisTransaksi, JenisPoli, JenisPenagihan, TanggalTransaksi, KeluhanUtama, KeluhanTambahan, IDInternet, StatusBPJS, NoUrut, StatusHandaya, StatusLansia, StatusDifabel, StatusGawatDarurat, CreatedBy, CreatedDate) " & _
                                        "VALUES('" & NoUrutBPJS & "', '" & idTransaksi & "', '" & jenisKunjungan & "', '" & jenisRawat & "', 'POLI', '" & ComboBoxPoliTujuan.Text & "', '" & jenisBayar & "', GETDATE(),'" & TextBoxPoliKeluhanUtama.Text & "', '" & TextBoxPoliKeluhanUtama.Text & "', " & _
                                        "'" & TextBoxRM.Text & "'," & Convert.ToInt32(statusBPJS) & ", '" & nomorUrutTransaksi & "', '" & CheckBoxStatusHandaya.Checked & "', '" & CheckBoxStatusLansia.Checked & "', '" & CheckBoxStatusDifabel.Checked & "', '" & CheckBoxStatusGawatDarurat.Checked & "', '" & userInput & "', GETDATE())", 4)

                        ' DELETE
                        WriteSQL("UPDATE TransaksiPoli SET TotalTagihan = " & CDbl(TextBoxTotalBruto.Text) & ", TotalDisc = " & CDbl(TextBoxTotalDiskon.Text) & ", Pembulatan = " & CDbl(TextBoxTotalPembulatan.Text) & ", NettBayar = " & CDbl(TextBoxTotalBayar.Text) & ", TotalBayar = " & CDbl(TextBoxTotalNett.Text) & ", Pengembalian = " & CDbl(0) & " WHERE TransPoliID='" & idTransaksi & "'", 4)

                        ' Generate Kode Voucher (Jika Pembelian Baru)
                        For Each rowTindakan As DataRow In tblTindakan.Rows
                            ' Insert Tabel LogPenggunaanPaket
                            WriteSQL("INSERT INTO LogPenggunaanPaket(NoRekamMedis, NoTransaksi, PaketID, TindakanID, JenisPaket, TanggalTransaksi, KodeVoucher, CreatedBy, CreatedDate) " & _
                                     "VALUES('" & TextBoxRM.Text & "', '" & nomorUrutTransaksi & "', '" & rowTindakan("PaketID") & "', '" & rowTindakan("TindakanID") & "', '" & rowTindakan("Jenis Paket") & "', GETDATE(), '" & rowTindakan("KodeVoucher") & "', '" & userInput & "', GETDATE())", 4)

                            ' Update Sisa Kuota Paket
                            If rowTindakan("Jenis Paket").ToString() = "Paket Reguler" Then
                                WriteSQL("UPDATE TransaksiPaketTindakan SET Kuota = Kuota - 1 WHERE PaketID = '" & rowTindakan("PaketID") & "' AND KodeVoucher = '" & rowTindakan("KodeVoucher") & "' AND DeletedDate IS NULL", 4)
                            ElseIf rowTindakan("Jenis Paket").ToString() = "Paket Per-Tindakan" Then
                                WriteSQL("UPDATE TransaksiPaketTindakanDetail SET KuotaTindakan = KuotaTindakan - 1 WHERE PaketID = '" & rowTindakan("PaketID") & "' AND TindakanID = '" & rowTindakan("TindakanID").ToString() & "' AND KodeVoucher = '" & rowTindakan("KodeVoucher") & "'", 4)
                            End If
                        Next

                        ' Insert / Update Detail Waktu Transaksi (WaktuSelesaiPendaftaran)
                        SetDetailWaktuTransaksi(nomorUrutTransaksi, "WaktuSelesaiPendaftaran", userInput)

                        ' Pesan Success
                        If NoUrutBPJS = "" Then
                            ' Non BPJS
                            MsgBox("Berhasil Menyimpan Data Pendaftaran Pasien." & vbCrLf & "No Transaksi : " & nomorUrutTransaksi, MsgBoxStyle.Information, "Success!")
                        Else
                            ' BPJS
                            MsgBox("Berhasil Menyimpan Data Pendaftaran Pasien." & vbCrLf & "No Transaksi : " & nomorUrutTransaksi & vbCrLf & "No Urut BPJS : " & NoUrutBPJS, MsgBoxStyle.Information, "Success!")
                        End If

                        '# Set Clear FormPendaftaranAwal
                        ClearDataPendaftaranAwal()
                    Case "GIGI"

                    Case "LABORATORIUM"

                End Select
            End If
        End If
    End Sub

    Function ValidasiPenggunaanPaket() As Boolean
        '' Set data master poli tujuan
        'Dim tblPoli As DataTable = ReadSQL("SELECT * FROM MasterPoliTujuan WHERE NamaPoli = '" & ComboBoxPoliTujuan.Text & "'")
        'Dim TrowPoli As DataRow = tblPoli.Rows(0)

        '' Validasi pasien
        'If TextBoxRM.Text = "" Then
        '    MsgBox("Masukkan data pasien terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
        '    Return False
        'End If

        '' Validasi poli tujuan
        'If ComboBoxPoliTujuan.Text = "" Then
        '    MsgBox("Masukkan poli tujuan yang sesuai.", MsgBoxStyle.Exclamation, "Warning!")
        '    Return False
        'End If

        Return True
    End Function

    Function CreateTableInvoice() As DataTable
        Dim Thasil As New DataTable

        insertRowToTbls(Thasil, "Typstring", "TindakanID")
        insertRowToTbls(Thasil, "Typstring", "Tindakan")
        insertRowToTbls(Thasil, "Typstring", "Jenis")
        insertRowToTbls(Thasil, "typefloat", "Biaya Tindakan")
        insertRowToTbls(Thasil, "typefloat", "DiscTindakan")
        insertRowToTbls(Thasil, "typefloat", "DiscNilai")
        insertRowToTbls(Thasil, "typefloat", "NettBayar")
        insertRowToTbls(Thasil, "typstring", "Registrasi")
        insertRowToTbls(Thasil, "typstring", "Nama")
        insertRowToTbls(Thasil, "typstring", "Umur")
        insertRowToTbls(Thasil, "typstring", "Alamat")
        insertRowToTbls(Thasil, "typstring", "Tanggal")
        insertRowToTbls(Thasil, "typstring", "NoTransaksi")
        insertRowToTbls(Thasil, "typstring", "DrPengirim")
        insertRowToTbls(Thasil, "typstring", "StatusAmbil")
        insertRowToTbls(Thasil, "typstring", "lblDokter")
        insertRowToTbls(Thasil, "typstring", "lbltitikDokter")
        insertRowToTbls(Thasil, "typstring", "lblStatusAmbil")
        insertRowToTbls(Thasil, "typstring", "lbltitikStatusAmbil")

        For Each Tcol As DataColumn In Thasil.Columns
            Tcol.ReadOnly = True
        Next

        Return Thasil
    End Function

    Private Sub txtotalpembulatan_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxTotalPembulatan.ValueChanged
        If IsNumeric(TextBoxTotalPembulatan.Text) = True Then
            TextBoxTotalBayar.Text = Splitmoney(CInt(TextBoxTotalNett.Text) + TextBoxTotalPembulatan.Text)
        End If
    End Sub

    Private Sub ComboBoxPoliTujuan_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxPoliTujuan.SelectedIndexChanged
        Try

            ' Ambil data dokter berdasarkan poli
            Dim namaPoliDipilih As String = ComboBoxPoliTujuan.Text
            Dim queryPoli As String = "SELECT Nama FROM MasterDokter WHERE ',' + Poli + ',' LIKE '%," & namaPoliDipilih & ",%' AND StatusAktif = 1"
            Dim tblDokter As DataTable = ReadSQL(queryPoli)

            ' Tambahkan baris kosong/manual jika ingin ada pilihan awal "-- Pilih Dokter --"
            Dim rowKosong As DataRow = tblDokter.NewRow()
            rowKosong("Nama") = "-- Pilih Dokter --"
            tblDokter.Rows.InsertAt(rowKosong, 0)

            ' Isi ComboBox dengan DataSource
            ComboBoxPilihanDokter.DataSource = tblDokter
            ComboBoxPilihanDokter.DisplayMember = "Nama"
            ComboBoxPilihanDokter.ValueMember = "Nama" ' jika pakai ID, ubah ini jadi "ID"
            ComboBoxPilihanDokter.SelectedIndex = 0

            ' Disable Button & ComboBox
            ComboBoxPilihanDokter.Enabled = False
            ComboBoxPilihanPerawat.Enabled = False
            ComboBoxMarketing.Enabled = False

            TextBoxPoliKeluhanUtama.Enabled = False
            TextBoxPoliKeluhanTambahan.Enabled = False

            ' Set Clear
            Dim tblsTindakan As DataTable = CType(GridControlTindakanPoli.DataSource, DataTable)
            If tblsTindakan IsNot Nothing Then tblsTindakan.Clear()

            DisablePemeriksaanFisik()
            ComboBoxPilihanDokter.SelectedIndex = -1
            ComboBoxPilihanPerawat.SelectedIndex = -1
            ComboBoxMarketing.SelectedIndex = -1
            TextBoxPoliKeluhanUtama.ResetText()
            TextBoxPoliKeluhanTambahan.ResetText()

            CheckBoxPaket.Checked = False

            If ComboBoxPoliTujuan.Text <> "" Then
                ' Get Detail Poli Tujuan
                Dim tblPoli As DataTable = ReadSQL("SELECT * FROM MasterPoliTujuan WHERE NamaPoli = '" & ComboBoxPoliTujuan.Text & "'")
                Dim TrowPoli As DataRow = tblPoli.Rows(0)

                ' Set Enable Dokter & Perawat
                If TrowPoli("DokterAwal") = True Then
                    ComboBoxPilihanDokter.Enabled = True
                    ComboBoxPilihanPerawat.Enabled = True
                    ComboBoxMarketing.Enabled = True

                    TextBoxPoliKeluhanUtama.Enabled = True
                    TextBoxPoliKeluhanTambahan.Enabled = True
                End If

                ' Visible Tab Pemeriksaan Fisik
                If Not TabControlMenu1.TabPages.Contains(TabPagePemeriksaanFisik) Then
                    ' Tambahkan TabPagePemeriksaanFisik ke posisi pertama (indeks 1)
                    TabControlMenu1.TabPages.Insert(1, TabPagePemeriksaanFisik)
                End If

                ' Visible Tab Tindakan
                If TrowPoli("TindakanAwal") = True Then
                    If Not TabControlMenu1.TabPages.Contains(TabPageTindakan) Then
                        ' Tambahkan TabPageTindakan ke posisi pertama (indeks 0)
                        TabControlMenu1.TabPages.Insert(0, TabPageTindakan)

                        ' Atur TabPageTindakan sebagai tab yang aktif
                        TabControlMenu1.SelectedTab = TabPageTindakan
                    End If
                Else
                    TabControlMenu1.TabPages.Remove(TabPageTindakan)
                    TabPageTindakan.Hide()
                End If

                If TrowPoli("PaketTindakan") = True Then
                    CheckBoxPaket.Visible = True
                Else
                    CheckBoxPaket.Visible = False
                End If

                ' Enable Button / TextBox
                ButtonSimpan.BackColor = Color.FromArgb(0, 100, 200)
                ButtonSimpan.Enabled = True

                ButtonKalkulasi.BackColor = Color.FromArgb(0, 100, 200)
                ButtonKalkulasi.Enabled = True

                ' Enable Pemeriksaan Fisik
                EnablePemeriksaanFisik()

                ' Enable TabControlMenu1
                ButtonTambahTindakan.BackColor = Color.FromArgb(0, 100, 200)
                ButtonTambahPaket.BackColor = Color.FromArgb(0, 100, 200)
                ButtonClearTindakan.BackColor = Color.FromArgb(0, 100, 200)
                ButtonScanQR.BackColor = Color.FromArgb(0, 100, 200)
                TabControlMenu1.Enabled = True

                ButtonTambahTindakan.Visible = True
                ButtonScanQR.Visible = True
                ButtonTambahPaket.Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ButtonTambahTindakan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTambahTindakan.Click
        If GridControlTindakanPoli.MainView IsNot GridViewTindakanPoli Then ClearGridDataTindakan()

        Dim queryString As String = ""
        Dim queryOrderString As String = ""

        '# Get Data Master Poli
        Dim tblPoli As DataTable = ReadSQL("SELECT * FROM MasterPoliTujuan WHERE NamaPoli = '" & ComboBoxPoliTujuan.Text & "'")
        Dim TrowPoli As DataRow = tblPoli.Rows(0)

        Select Case TrowPoli("JenisPoli")
            Case "UMUM"
                queryString = "SELECT TindakanID AS ID, NamaTindakan AS Tindakan, JenisTindakan AS Jenis, JenisDokter, PARSENAME(CONVERT(varchar, CONVERT(money, BiayaTindakan), 1), 2) AS [Biaya Tindakan] " & _
                              "FROM MasterTindakan " & _
                              "WHERE Closed = 0 AND (JenisTindakan LIKE '%Konsultasi%' OR JenisTindakan LIKE '%Administrasi%')"
                queryOrderString = " ORDER BY JenisTindakan, NamaTindakan"
            Case "GIGI"
                queryString = "SELECT TindakanID AS ID, NamaTindakan AS Tindakan, JenisTindakan AS Jenis, PARSENAME(CONVERT(varchar, CONVERT(money, BiayaTindakan), 1), 2) AS [Biaya Tindakan] " & _
                              "FROM MasterTindakanGigi " & _
                              "WHERE Closed = 0 AND (JenisTindakan LIKE '%Konsultasi%' OR JenisTindakan LIKE '%Administrasi%')"
                queryOrderString = "ORDER BY JenisTindakan, NamaTindakan"
        End Select

        FindMultiple.Show()
        FindMultiple.Query(queryString, queryOrderString, "FindPemeriksaanPendaftaran", 1)

        'LoadTindakan()
    End Sub

    Public Sub LoadPasien(ByVal Trow As DataRowView)
        ClearFormFields()

        'Set Data From Pencarian
        TextBoxNama.Text = Trow("Nama").ToString
        TextBoxRM.Text = Trow("RM").ToString
        TextBoxNoNIK.Text = Trow("No NIK").ToString
        TextBoxNoIHS.Text = Trow("No IHS").ToString

        If Trow("Status NIK").ToString = True Then LabelNotifikasiNIK.Visible = True
        If Trow("No IHS").ToString = "" Then LabelNotifikasiIHS.Visible = True

        If Trow("Jenis Kelamin").ToString = "P" Then
            RadioButtonJenisKelaminLaki.Enabled = False
            RadioButtonJenisKelaminPerempuan.Enabled = True
            RadioButtonJenisKelaminPerempuan.Checked = True
        ElseIf Trow("Jenis Kelamin").ToString = "L" Then
            RadioButtonJenisKelaminPerempuan.Enabled = False
            RadioButtonJenisKelaminLaki.Enabled = True
            RadioButtonJenisKelaminLaki.Checked = True
        End If

        DateTimePickerTglLahir.Value = Trow("Tgl. Lahir").ToString
        TextBoxUmur.Text = Umur(Trow("Tgl. Lahir").ToString)
        TextBoxNoHP.Text = Trow("No. HP").ToString
        TextBoxAlamat.Text = Trow("Alamat").ToString

        TextBoxProlanis.Text = Trow("Prolanis").ToString
        TextBoxPRB.Text = Trow("PRB").ToString
        TextBoxNoKartuBPJS.Text = Trow("No JKN-KIS").ToString
        TextBoxStatusPeserta.Text = Trow("Status Peserta").ToString
        TextBoxPPK.Text = Trow("FKTP").ToString

        ' Ambil FotoPath dari database berdasarkan NIK
        Dim nikPasien As String = Trow("No NIK").ToString().Trim()
        Dim fotoPath As String = ""

        If Not String.IsNullOrEmpty(nikPasien) Then
            fotoPath = GetFotoPathByNIK(nikPasien)
        End If

        ' Path absolut ke file foto
        Dim fullPath As String = System.IO.Path.Combine(Application.StartupPath, fotoPath)
        Dim defaultFotoPath As String = Application.StartupPath & "\Uploads\BlankProfile.png"

        Try
            If Not String.IsNullOrEmpty(fotoPath) AndAlso fotoPath.Trim() <> "" AndAlso File.Exists(fullPath) Then
                PictureBoxFotoPasien.Image = Image.FromFile(fullPath)
            Else
                PictureBoxFotoPasien.Image = Image.FromFile(defaultFotoPath)
            End If
        Catch ex As Exception
            PictureBoxFotoPasien.Image = Image.FromFile(defaultFotoPath)
            MessageBox.Show("Gagal memuat foto pasien: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        PictureBoxFotoPasien.SizeMode = PictureBoxSizeMode.Zoom
        ComboBoxPoliTujuan.Enabled = True
    End Sub

    Private Sub ButtonClearTindakan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClearTindakan.Click
        If GridControlTindakanPoli.MainView Is GridViewPaketPoli Then ClearGridDataPaket()
        If GridControlTindakanPoli.MainView Is GridViewTindakanPoli Then ClearGridDataTindakan()
    End Sub

    Private Sub RadioButtonKunjunganSakit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonKunjunganSakit.CheckedChanged, RadioButtonkunjunganSehat.CheckedChanged
        If RadioButtonKunjunganSakit.Checked = True Then
            RadioButtonStatusRawatJalan.Checked = True
            RadioButtonStatusRawatInap.Enabled = False
            RadioButtonPromotifPreventif.Enabled = True

            SetComboBoxPoliTujuan(True)
        ElseIf RadioButtonkunjunganSehat.Checked = True Then
            RadioButtonStatusRawatJalan.Checked = True
            RadioButtonStatusRawatInap.Enabled = False
            RadioButtonPromotifPreventif.Enabled = False

            SetComboBoxPoliTujuan(False)
        End If
    End Sub

    Private Sub TextBoxSistole_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxSistole.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ".") Then e.Handled = True
    End Sub

    Private Sub TextBoxDiastole_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxDiastole.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ".") Then e.Handled = True
    End Sub

    Private Sub TextBoxDetakNadi_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxDetakNadi.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ".") Then e.Handled = True
    End Sub

    Private Sub TextBoxNafas_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxNafas.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ".") Then e.Handled = True
    End Sub

    Private Sub TextBoxSuhu_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxSuhu.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ".") Then e.Handled = True
    End Sub

    Private Sub TextBoxSaturasi_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxSaturasi.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ".") Then e.Handled = True
    End Sub

    Private Sub TextBoxTinggiBadan_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxTinggiBadan.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ".") Then e.Handled = True
    End Sub

    Private Sub TextBoxBeratBadan_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxBeratBadan.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ".") Then e.Handled = True
    End Sub

    Private Sub TextBoxLingkarPerut_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxLingkarPerut.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ".") Then e.Handled = True
    End Sub

    Private Sub ButtonCariAntreanOnline_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCariAntreanOnline.Click
        Try
            GetDataAntreanOnline()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Function GetFotoPathByNIK(ByVal nik As String) As String
        Try
            Dim sql As String = "SELECT FotoPath FROM MasterPasien WHERE NoNIK = '" & nik & "'"
            Dim fotoPath As String = ReadSQLNIK(sql)

            If Not String.IsNullOrEmpty(fotoPath) Then
                Return fotoPath
            Else
                Return "" ' atau path gambar default
            End If
        Catch ex As Exception
            MessageBox.Show("Gagal mengambil FotoPath: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return ""
        End Try
    End Function

    'Public Sub GetDataAntreanOnline()
    '    Try
    '        MsgBox("STEP 1: Mulai GetDataAntreanOnline")

    '        Dim urlWebService As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'web_service_get_data_antrol'")

    '        MsgBox("STEP 2: URL dari DB = " & urlWebService)

    '        If urlWebService = "" Then
    '            MsgBox("URL Web Service kosong!", MsgBoxStyle.Critical)
    '            Exit Sub
    '        End If

    '        If Not urlWebService.EndsWith("/") Then
    '            urlWebService &= "/"
    '        End If

    '        Dim Tawal As Date = TglAwalAntrean.Value
    '        MsgBox("STEP 3: Tanggal Awal = " & Format(Tawal, "yyyy-MM-dd"))

    '        Dim fullUrl As String = urlWebService & "0/" & Format(Tawal.Date, "yyyy-MM-dd") & "/1"
    '        MsgBox("STEP 4: FULL URL = " & fullUrl)

    '        MsgBox("STEP 5: Call API")

    '        Dim responseString As String = GetDataAntrianOnline(fullUrl)

    '        If responseString Is Nothing Then
    '            MsgBox("STEP 6: responseString = NOTHING", MsgBoxStyle.Critical)
    '            Exit Sub
    '        End If

    '        MsgBox("STEP 6: responseString DIDAPAT")
    '        Dim preview As String = responseString

    '        If responseString.Length > 500 Then
    '            preview = responseString.Substring(0, 500)
    '        End If

    '        MsgBox(preview, MsgBoxStyle.Information, "RAW JSON (500 char)")


    '        ' ===== FIX JSON NaN =====
    '        responseString = responseString.Replace(":NaN", ":null")
    '        responseString = responseString.Replace(": NaN", ": null")
    '        responseString = responseString.Replace("NaN,", "null,")
    '        responseString = responseString.Replace("NaN]", "null]")

    '        MsgBox(responseString.Substring(0, 1), MsgBoxStyle.Information, "JSON FIRST CHAR")

    '        MsgBox("STEP 7: Mulai Deserialize JSON (ARRAY)")

    '        Dim rootList As List(Of RootAntrean) = JsonConvert.DeserializeObject(Of List(Of RootAntrean))(responseString)

    '        If rootList Is Nothing OrElse rootList.Count = 0 Then
    '            MsgBox("STEP 8: Data kosong / gagal deserialize", MsgBoxStyle.Critical)
    '            Exit Sub
    '        End If

    '        MsgBox("STEP 8: rootList COUNT = " & rootList.Count)

    '        Dim rootObj As RootAntrean = rootList(0)

    '        If rootObj.metadata Is Nothing Then
    '            MsgBox("STEP 9: metadata = NOTHING", MsgBoxStyle.Critical)
    '            Exit Sub
    '        End If

    '        MsgBox("STEP 10: metadata.code = " & rootObj.metadata.code)
    '        MsgBox("STEP 10: metadata.message = " & rootObj.metadata.message)

    '        MsgBox("STEP 11: Isi DataGridView")

    '        DataGridViewAntrean.Rows.Clear()

    '        If rootObj.response IsNot Nothing Then
    '            MsgBox("STEP 12: Jumlah data = " & rootObj.response.Count)

    '            For Each item As AntreanItem In rootObj.response

    '                Dim tglPeriksa As String = item.tanggalperiksa
    '                Try
    '                    tglPeriksa = ConvertDateStringAntreanOnline(item.tanggalperiksa)
    '                Catch
    '                End Try

    '                DataGridViewAntrean.Rows.Add(New String() { _
    '                    item.namapeserta, _
    '                    item.nik, _
    '                    item.namapoli, _
    '                    item.jenispeserta, _
    '                    item.nomorantrean, _
    '                    tglPeriksa.Split(" "c)(0), _
    '                    item.statusantrean, _
    '                    item.sumberantrean, _
    '                    If(item.nomorkartu, ""), _
    '                    item.jeniskelamin, _
    '                    item.tanggallahir, _
    '                    If(item.alamat, ""), _
    '                    If(item.nohp, ""), _
    '                    If(item.kodedokter, ""), _
    '                    If(item.namadokter, ""), _
    '                    If(item.kodepoli, ""), _
    '                    If(item.namapoli, ""), _
    '                    If(item.keluhan, ""), _
    '                    If(item.kodefaskes, ""), _
    '                    If(item.namafaskes, "") _
    '                })
    '            Next
    '        End If

    '        DataGridViewAntrean.CurrentCell = Nothing
    '        MsgBox("STEP 13: SELESAI")

    '    Catch ex As Exception
    '        MsgBox("EXCEPTION TERJADI: " & ex.Message, MsgBoxStyle.Critical)
    '    End Try
    'End Sub

    Public Sub GetDataAntreanOnline()
        Try
            ' Ambil URL web service
            Dim urlWebService As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'web_service_get_data_antrol'")

            If urlWebService = "" Then
                MessageBox.Show("URL Web Service belum disetting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            ' Pastikan ada trailing slash
            If Not urlWebService.EndsWith("/") Then
                urlWebService &= "/"
            End If

            ' Parameter tanggal
            Dim Tawal As Date = TglAwalAntrean.Value
            Dim fullUrl As String = urlWebService & "0/" & Format(Tawal.Date, "yyyy-MM-dd") & "/1"

            ' Call API
            Dim responseString As String = GetDataAntrianOnline(fullUrl)

            If responseString Is Nothing OrElse responseString.Trim() = "" Then
                MessageBox.Show("Tidak ada respon dari server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            ' ===== FIX JSON NaN (WAJIB) =====
            responseString = responseString.Replace(":NaN", ":null")
            responseString = responseString.Replace(": NaN", ": null")
            responseString = responseString.Replace("NaN,", "null,")
            responseString = responseString.Replace("NaN]", "null]")

            ' Deserialize (JSON ARRAY)
            Dim rootList As List(Of RootAntrean) = JsonConvert.DeserializeObject(Of List(Of RootAntrean))(responseString)

            If rootList Is Nothing OrElse rootList.Count = 0 Then
                MessageBox.Show("Data kosong dari server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            Dim rootObj As RootAntrean = rootList(0)

            ' Validasi metadata
            If rootObj Is Nothing OrElse rootObj.metadata Is Nothing Then
                MessageBox.Show("Format response tidak sesuai.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If rootObj.metadata.code <> 200 Then
                MessageBox.Show("Data tidak ditemukan: " & rootObj.metadata.message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' Isi DataGridView
            DataGridViewAntrean.Rows.Clear()

            If rootObj.response IsNot Nothing Then
                For Each item As AntreanItem In rootObj.response
                    Dim tglPeriksa As String = item.tanggalperiksa
                    Try
                        tglPeriksa = ConvertDateStringAntreanOnline(item.tanggalperiksa)
                    Catch
                        ' pakai nilai asli
                    End Try

                    DataGridViewAntrean.Rows.Add(New String() { _
                        item.namapeserta, _
                        item.nik, _
                        item.namapoli, _
                        item.jenispeserta, _
                        item.nomorantrean, _
                        tglPeriksa.Split(" "c)(0), _
                        item.statusantrean, _
                        item.sumberantrean, _
                        If(item.nomorkartu, ""), _
                        item.jeniskelamin, _
                        item.tanggallahir, _
                        If(item.alamat, ""), _
                        If(item.nohp, ""), _
                        If(item.kodedokter, ""), _
                        If(item.namadokter, ""), _
                        If(item.kodepoli, ""), _
                        If(item.namapoli, ""), _
                        If(item.keluhan, ""), _
                        If(item.kodefaskes, ""), _
                        If(item.namafaskes, "")})
            Next
            End If

            DataGridViewAntrean.CurrentCell = Nothing

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CreateDataGridViewAntreanOnline()
        ' Add columns
        DataGridViewAntrean.Columns.Add("ColumnNamaPasien", "Nama Pasien")
        DataGridViewAntrean.Columns.Add("ColumnNomorNIK", "NIK")
        DataGridViewAntrean.Columns.Add("ColumnNamaPoli", "Nama Poli")
        DataGridViewAntrean.Columns.Add("ColumnJenisPeserta", "Jenis Peserta")
        DataGridViewAntrean.Columns.Add("ColumnNomorAntrean", "Nomor Antrean")
        DataGridViewAntrean.Columns.Add("ColumnTglPeriksa", "Tgl Periksa")
        DataGridViewAntrean.Columns.Add("ColumnStatus", "Status")
        DataGridViewAntrean.Columns.Add("ColumnSumber", "Sumber")
        DataGridViewAntrean.Columns.Add("ColumnNomorKartu", "Nomor Kartu")
        DataGridViewAntrean.Columns.Add("ColumnJenisKelamin", "Jenis Kelamin")
        DataGridViewAntrean.Columns.Add("ColumnTanggalLahir", "Tgl Lahir")
        DataGridViewAntrean.Columns.Add("ColumnAlamat", "Alamat")
        DataGridViewAntrean.Columns.Add("ColumnNomorHP", "Nomor HP")
        DataGridViewAntrean.Columns.Add("ColumnKodeDokter", "Kode Dokter")
        DataGridViewAntrean.Columns.Add("ColumnNamaDokter", "Nama Dokter")
        DataGridViewAntrean.Columns.Add("ColumnKodePoli", "Kode Poli")
        DataGridViewAntrean.Columns.Add("ColumnNamaPoli", "Nama Poli")
        DataGridViewAntrean.Columns.Add("ColumnKeluhan", "Keluhan")
        DataGridViewAntrean.Columns.Add("ColumnKodeFaskes", "Kode Faskes")
        DataGridViewAntrean.Columns.Add("ColumnNamaFaskes", "Nama Faskes")

        ' Hide
        DataGridViewAntrean.Columns("ColumnNomorKartu").Visible = False
        DataGridViewAntrean.Columns("ColumnJenisKelamin").Visible = False
        DataGridViewAntrean.Columns("ColumnTanggalLahir").Visible = False
        DataGridViewAntrean.Columns("ColumnAlamat").Visible = False
        DataGridViewAntrean.Columns("ColumnNomorHP").Visible = False
        DataGridViewAntrean.Columns("ColumnKodeDokter").Visible = False
        'DataGridViewAntrean.Columns("ColumnNamaDokter").Visible = False
        DataGridViewAntrean.Columns("ColumnKodePoli").Visible = False
        DataGridViewAntrean.Columns("ColumnNamaPoli").Visible = False
        DataGridViewAntrean.Columns("ColumnKeluhan").Visible = False
        DataGridViewAntrean.Columns("ColumnKodeFaskes").Visible = False
        DataGridViewAntrean.Columns("ColumnNamaFaskes").Visible = False

        ' Setting
        DataGridViewAntrean.DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        DataGridViewAntrean.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI Semibold", 9, FontStyle.Bold)
        DataGridViewAntrean.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    Private Sub SearchDataGridView(ByVal dataGridView As DataGridView, ByVal keyword As String)
        ' Set ulang Visible untuk semua baris sebelum memulai pencarian baru
        For Each row As DataGridViewRow In dataGridView.Rows
            row.Visible = True
        Next

        ' Sekarang lakukan pencarian seperti biasa
        For Each row As DataGridViewRow In dataGridView.Rows
            Dim matchFound As Boolean = False

            If String.IsNullOrEmpty(keyword) Then
                ' Jika teks pencarian kosong, tampilkan semua baris
                matchFound = True
            Else
                For Each cell As DataGridViewCell In row.Cells
                    If cell.Visible AndAlso cell.Value IsNot Nothing AndAlso cell.Value.ToString().IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 Then
                        matchFound = True
                        Exit For
                    End If
                Next
            End If

            row.Visible = matchFound
        Next
    End Sub

    Private Sub TextBoxSearchAntreanOnline_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxSearchAntreanOnline.TextChanged
        SearchDataGridView(DataGridViewAntrean, TextBoxSearchAntreanOnline.Text)
    End Sub

    Private Sub DataGridViewAntrean_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewAntrean.CellDoubleClick
        If e.RowIndex >= 0 Then
            Dim nomorNIK As String = DataGridViewAntrean.Rows(e.RowIndex).Cells("ColumnNomorNIK").Value.ToString()
            Dim kodePoli As String = DataGridViewAntrean.Rows(e.RowIndex).Cells("ColumnKodePoli").Value.ToString()
            Dim kodeDokter As String = DataGridViewAntrean.Rows(e.RowIndex).Cells("ColumnKodeDokter").Value.ToString()
            Dim nomorAntrean As String = DataGridViewAntrean.Rows(e.RowIndex).Cells("ColumnNomorAntrean").Value.ToString()
            Dim jenisPeserta As String = DataGridViewAntrean.Rows(e.RowIndex).Cells("ColumnJenisPeserta").Value.ToString()

            ' Debug awal
            'MsgBox("DEBUG DATA CLICKED" & vbCrLf & _
            '       "Nomor Antrean: " & nomorAntrean & vbCrLf & _
            '       "NIK: " & nomorNIK & vbCrLf & _
            '       "Kode Poli: " & kodePoli & vbCrLf & _
            '       "Kode Dokter: " & kodeDokter & vbCrLf & _
            '       "Jenis Peserta: " & jenisPeserta)

            ' Validasi jika status sudah terlayani
            'If ValidasiAntrean(nomorAntrean, nomorNIK, kodePoli, kodeDokter) = False Then Exit Sub

            If ValidasiAntrean(nomorAntrean, nomorNIK, kodePoli, kodeDokter) = False Then
                'MsgBox("DEBUG: Antrean tidak valid / sudah terlayani")
                Exit Sub
            End If


            Dim kolom() As String = {"ColumnNomorAntrean", "ColumnNomorNIK", "ColumnNomorKartu", "ColumnNamaPasien", "ColumnJenisKelamin", "ColumnTanggalLahir", "ColumnAlamat", "ColumnNomorHP", "ColumnKodeDokter", "ColumnNamaDokter", "ColumnKodePoli", "ColumnNamaPoli", "ColumnKeluhan", "ColumnKodeFaskes", "ColumnNamaFaskes"}
            Dim kunci() As String = {"Nomor Antrean", "Nomor NIK", "Nomor Kartu BPJS", "Nama Pasien", "Jenis Kelamin", "Tgl Lahir", "Alamat", "Nomor HP", "Kode Dokter", "Nama Dokter", "Kode Poli", "Nama Poli", "Keluhan", "Kode Faskes", "Nama Faskes"}

            Dim dataDictionary As New Dictionary(Of String, Object)()

            For i As Integer = 0 To kolom.Length - 1
                dataDictionary.Add(kunci(i), DataGridViewAntrean.Rows(e.RowIndex).Cells(kolom(i)).Value.ToString())
            Next

            If jenisPeserta = "BPJS" Then
                ' Jika Pasien BPJS
                DialogBoxKonfirmasiPendaftaran.DataDictionary = dataDictionary
                DialogBoxKonfirmasiPendaftaran.ShowDialog()
            ElseIf jenisPeserta = "NON-BPJS" Then
                ' Jika Pasien NON-BPJS
                If CheckSQL("SELECT * FROM MasterPasien WHERE NoNIK = '" & nomorNIK & "'") = True Then
                    ' Jika Pasien Sudah Terdaftar di Master Pasien
                    dataDictionary.Add("Text Button Start Proses", "Mulai Pendaftaran")
                    dataDictionary.Add("Jenis Proses", "Antrean - Pendaftaran")

                    DialogBoxPanggilPasien.DataDictionary = dataDictionary
                    DialogBoxPanggilPasien.ShowDialog()
                Else
                    ' Jika Pasien Belum Terdaftar di Master Pasien
                    Select Case MsgBox("Nomor NIK " & nomorNIK & " belum terdaftar di master pasien. Silahkan tambah data terlebih dahulu.", MsgBoxStyle.OkCancel, "Validasi.")
                        Case MsgBoxResult.Ok
                            ' Create tabel pasien baru
                            Dim tblPasienBaru As DataTable = New DataTable
                            tblPasienBaru.Columns.Add("Nama", GetType(String))
                            tblPasienBaru.Columns.Add("Nomor NIK", GetType(String))
                            tblPasienBaru.Columns.Add("Nomor BPJS", GetType(String))
                            tblPasienBaru.Columns.Add("Jenis Kelamin", GetType(String))
                            tblPasienBaru.Columns.Add("Tanggal Lahir", GetType(String))
                            tblPasienBaru.Columns.Add("Alamat", GetType(String))

                            ' Set Row Data Pasien Baru
                            Dim rowPasien As DataRow = tblPasienBaru.NewRow()

                            ' Set URL Web Service
                            Dim urlWebService As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'web_service_get_data_peserta_antrol'")

                            urlWebService = urlWebService & nomorNIK

                            Dim responseString As String = GetDataAntrianOnline(urlWebService)
                            Dim jsonObject() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of JsonGetPesertaAntrol())(responseString)

                            For Each rowData As JsonGetPesertaAntrol In jsonObject
                                Dim codeMetaData As Integer = Convert.ToInt32(rowData.metaData.code)

                                If codeMetaData = "200" Then
                                    rowPasien("Nama") = rowData.response.nama
                                    rowPasien("Nomor NIK") = rowData.response.nik
                                    rowPasien("Nomor BPJS") = rowData.response.nomorkartu
                                    rowPasien("Jenis Kelamin") = rowData.response.jeniskelamin
                                    'rowPasien("Tanggal Lahir") = rowData.response.tanggallahir
                                    If rowData.response.tanggallahir IsNot Nothing AndAlso rowData.response.tanggallahir.Trim() <> "" Then
                                        rowPasien("Tanggal Lahir") = rowData.response.tanggallahir
                                    Else
                                        rowPasien("Tanggal Lahir") = "01/01/1900"
                                    End If
                                    rowPasien("Alamat") = rowData.response.alamat
                                Else
                                    rowPasien("Nomor NIK") = nomorNIK
                                End If
                            Next

                            FormMasterPasien.Show()
                            FormMasterPasien.BringToFront()
                            FormMasterPasien.SetPasienFromPendaftaran(rowPasien)
                        Case MsgBoxResult.Cancel
                            MsgBox("Batal menambahkan data ke master pasien.", MsgBoxStyle.Exclamation, "Warning!")
                    End Select
                End If
            End If

            ' Validasi apakah NIK sudah ada di master pasien
            'If CheckSQL("SELECT * FROM MasterPasien WHERE NoNIK = '" & nomorNIK & "'") = True Then
            '    '# Set data dictionary yang akan dikirim ke form popup
            '    Dim dataDictionary As New Dictionary(Of String, Object)()

            '    dataDictionary.Add("Text Button Start Proses", "Mulai Pendaftaran")
            '    dataDictionary.Add("Jenis Proses", "Antrean - Pendaftaran")
            '    dataDictionary.Add("Nomor Antrean", nomorAntrean)
            '    dataDictionary.Add("Nomor NIK", nomorNIK)

            '    DialogBoxPanggilPasien.DataDictionary = dataDictionary
            '    DialogBoxPanggilPasien.ShowDialog()
            'Else
            '    Select Case MsgBox("Nomor NIK " & nomorNIK & " belum terdaftar di master pasien. Silahkan tambah data terlebih dahulu.", MsgBoxStyle.OkCancel, "Validasi.")
            '        Case MsgBoxResult.Ok
            '            ' Create tabel pasien baru
            '            Dim tblPasienBaru As DataTable = New DataTable
            '            tblPasienBaru.Columns.Add("Nama", GetType(String))
            '            tblPasienBaru.Columns.Add("Nomor NIK", GetType(String))
            '            tblPasienBaru.Columns.Add("Nomor BPJS", GetType(String))
            '            tblPasienBaru.Columns.Add("Jenis Kelamin", GetType(String))
            '            tblPasienBaru.Columns.Add("Tanggal Lahir", GetType(String))
            '            tblPasienBaru.Columns.Add("Alamat", GetType(String))

            '            ' Set Row Data Pasien Baru
            '            Dim rowPasien As DataRow = tblPasienBaru.NewRow()

            '            ' Set URL Web Service
            '            Dim urlWebService As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'web_service_get_data_peserta_antrol'")

            '            urlWebService = urlWebService & nomorNIK

            '            Dim responseString As String = GetDataAntrianOnline(urlWebService)
            '            Dim jsonObject() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of JsonGetPesertaAntrol())(responseString)

            '            For Each rowData As JsonGetPesertaAntrol In jsonObject
            '                Dim codeMetaData As Integer = Convert.ToInt32(rowData.metaData.code)

            '                If codeMetaData = "200" Then
            '                    rowPasien("Nama") = rowData.response.nama
            '                    rowPasien("Nomor NIK") = rowData.response.nik
            '                    rowPasien("Nomor BPJS") = rowData.response.nomorkartu
            '                    rowPasien("Jenis Kelamin") = rowData.response.jeniskelamin
            '                    rowPasien("Tanggal Lahir") = rowData.response.tanggallahir
            '                    rowPasien("Alamat") = rowData.response.alamat
            '                Else
            '                    rowPasien("Nomor NIK") = nomorNIK
            '                End If
            '            Next

            '            FormMasterPasien.Show()
            '            FormMasterPasien.BringToFront()
            '            FormMasterPasien.SetPasienFromPendaftaran(rowPasien)
            '        Case MsgBoxResult.Cancel
            '            MsgBox("Batal menambahkan data ke master pasien.", MsgBoxStyle.Exclamation, "Warning!")
            '    End Select
            'End If
        End If

        'If e.RowIndex >= 0 Then
        '    Dim statusAntrean As String = DataGridViewAntrean.Rows(e.RowIndex).Cells("ColumnStatus").Value.ToString()
        '    Dim nomorAntrean As String = DataGridViewAntrean.Rows(e.RowIndex).Cells("ColumnNomorAntrean").Value.ToString()
        '    Dim nomorNIK As String = DataGridViewAntrean.Rows(e.RowIndex).Cells("ColumnNomorNIK").Value.ToString()

        '    If statusAntrean = "Dibatalkan" Then
        '        MsgBox("Eror : Status transaksi sudah dibatalkan.", MsgBoxStyle.Exclamation, "Error!")
        '        Exit Sub
        '    End If

        '    ' Validasi apakah NIK sudah ada di master pasien
        '    If CheckSQL("SELECT * FROM MasterPasien WHERE NoNIK = '" & nomorNIK & "'") = True Then
        '        '# Set data dictionary yang akan dikirim ke form popup
        '        Dim dataDictionary As New Dictionary(Of String, Object)()

        '        dataDictionary.Add("Text Button Start Proses", "Mulai Pendaftaran")
        '        dataDictionary.Add("Jenis Proses", "Antrean - Pendaftaran")
        '        dataDictionary.Add("Nomor Antrean", nomorAntrean)
        '        dataDictionary.Add("Nomor NIK", nomorNIK)

        '        DialogBoxPanggilPasien.DataDictionary = dataDictionary
        '        DialogBoxPanggilPasien.ShowDialog()
        '    Else
        '        Select Case MsgBox("Nomor NIK " & nomorNIK & " belum terdaftar di master pasien. Silahkan tambah data terlebih dahulu.", MsgBoxStyle.OkCancel, "Validasi.")
        '            Case MsgBoxResult.Ok
        '                ' Create tabel pasien baru
        '                Dim tblPasienBaru As DataTable = New DataTable
        '                tblPasienBaru.Columns.Add("Nama", GetType(String))
        '                tblPasienBaru.Columns.Add("Nomor NIK", GetType(String))
        '                tblPasienBaru.Columns.Add("Nomor BPJS", GetType(String))
        '                tblPasienBaru.Columns.Add("Jenis Kelamin", GetType(String))
        '                tblPasienBaru.Columns.Add("Tanggal Lahir", GetType(String))
        '                tblPasienBaru.Columns.Add("Alamat", GetType(String))

        '                ' Set Row Data Pasien Baru
        '                Dim rowPasien As DataRow = tblPasienBaru.NewRow()

        '                ' Set URL Web Service
        '                Dim urlWebService As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'web_service_get_data_peserta_antrol'")

        '                urlWebService = urlWebService & nomorNIK

        '                Dim responseString As String = GetDataAntrianOnline(urlWebService)
        '                Dim jsonObject() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of JsonGetPesertaAntrol())(responseString)

        '                For Each rowData As JsonGetPesertaAntrol In jsonObject
        '                    Dim codeMetaData As Integer = Convert.ToInt32(rowData.metaData.code)

        '                    If codeMetaData = "200" Then
        '                        rowPasien("Nama") = rowData.response.nama
        '                        rowPasien("Nomor NIK") = rowData.response.nik
        '                        rowPasien("Nomor BPJS") = rowData.response.nomorkartu
        '                        rowPasien("Jenis Kelamin") = rowData.response.jeniskelamin
        '                        rowPasien("Tanggal Lahir") = rowData.response.tanggallahir
        '                        rowPasien("Alamat") = rowData.response.alamat
        '                    Else
        '                        rowPasien("Nomor NIK") = nomorNIK
        '                    End If
        '                Next

        '                FormMasterPasien.Show()
        '                FormMasterPasien.BringToFront()
        '                FormMasterPasien.SetPasienFromPendaftaran(rowPasien)
        '            Case MsgBoxResult.Cancel
        '                MsgBox("Batal menambahkan data ke master pasien.", MsgBoxStyle.Exclamation, "Warning!")
        '        End Select
        '    End If
        'End If
    End Sub

    Private Sub InsertDataBPJS(ByRef noKartu As String, ByRef jenisProses As String)
        Try
            Dim parameterUpdate As String = ""
            Dim getResponse As String = ""
            Dim uri As String = ""
            Dim urlPcare As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_base_url'")

            uri = urlPcare & "peserta/noka/" & noKartu
            getResponse = getDataFromPcare(uri)

            If getResponse <> "Nothing" Then
                Dim varsespoli() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of varJson())(getResponse)

                For Each oneVar As varJson In varsespoli
                    If jenisProses = "UPDATE" Then
                        parameterUpdate = "HubunganKeluarga = '" & oneVar.response.hubunganKeluarga & "'," & _
                                          "TglMulaiAktif = '" & oneVar.response.tglMulaiAktif & "'," & _
                                          "TglAkhirBerlaku = '" & oneVar.response.tglAkhirBerlaku & "'," & _
                                          "KdProviderPst = '" & oneVar.response.kdProviderPst.kdProvider & "'," & _
                                          "NmProviderPst = '" & oneVar.response.kdProviderPst.nmProvider & "'," & _
                                          "KdProviderGigi = '" & oneVar.response.kdProviderGigi.kdProvider & "'," & _
                                          "NmProviderGigi = '" & oneVar.response.kdProviderGigi.nmProvider & "'," & _
                                          "JenisKelas = '" & oneVar.response.jnsKelas.nama & "'," & _
                                          "KdJenisKelas = '" & oneVar.response.jnsKelas.kode & "'," & _
                                          "JenisPeserta = '" & oneVar.response.jnsPeserta.nama & "'," & _
                                          "KdJenisPeserta = '" & oneVar.response.jnsPeserta.kode & "'," & _
                                          "PesertaProl = '" & oneVar.response.pstProl & "'," & _
                                          "PesertaPrb = '" & oneVar.response.pstPrb & "'," & _
                                          "Aktif = '" & oneVar.response.aktif & "'," & _
                                          "KetAktif = '" & oneVar.response.ketAktif & "'," & _
                                          "tunggakan = '" & oneVar.response.tunggakan & "'"

                        ' Update Data
                        WriteSQL("UPDATE MasterPasienBPJS SET " & parameterUpdate & " WHERE NoKartu = '" & noKartu & "'", 4)
                    ElseIf jenisProses = "CREATE" Then
                        ' Insert Data
                        WriteSQL("INSERT INTO MasterPasienBPJS (NoKartu, HubunganKeluarga, TglMulaiAktif, TglAkhirBerlaku, KdProviderPst, NmProviderPst, KdProviderGigi, NmProviderGigi, JenisKelas, KdJenisKelas, JenisPeserta, KdJenisPeserta, PesertaProl, PesertaPrb, Aktif, KetAktif, tunggakan) " & _
                                 "VALUES('" & noKartu & "', '" & oneVar.response.hubunganKeluarga & "', '" & oneVar.response.tglMulaiAktif & "', '" & oneVar.response.tglAkhirBerlaku & "', '" & oneVar.response.kdProviderPst.kdProvider & "', '" & oneVar.response.kdProviderPst.nmProvider & "', '" & oneVar.response.kdProviderGigi.kdProvider & "', '" & oneVar.response.kdProviderGigi.nmProvider & "', '" & oneVar.response.jnsKelas.nama & "','" & oneVar.response.jnsKelas.kode & "','" & oneVar.response.jnsPeserta.nama & "', '" & oneVar.response.jnsPeserta.kode & "','" & oneVar.response.pstProl & "','" & oneVar.response.pstPrb & "','" & oneVar.response.aktif & "','" & oneVar.response.ketAktif & "','" & oneVar.response.tunggakan & "')", 4)
                    End If
                Next
            Else
                MsgBox("Data tidak ditemukan.", MsgBoxStyle.Critical, "Warning!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Function GetNumberIHS(ByVal nomorNIK As String) As String
        Dim nomorIHS As String = ""

        Dim baseURL As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'satu_sehat_base_url'")
        Dim apiEndpoint As String = baseURL & "Patient?identifier=https://fhir.kemkes.go.id/id/nik|" & nomorNIK
        Dim responseString As String = GetDataSatuSehat(apiEndpoint)
        Dim jsonObject() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of PatientResource())(responseString)

        For Each oneVar As PatientResource In jsonObject
            For index As Integer = 0 To oneVar.entry.Length - 1
                nomorIHS = oneVar.entry(index).resource.id
            Next
        Next

        Return nomorIHS
    End Function

    Private Sub ButtonMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonMenuPendaftaran.Click, ButtonMenuAntrianOnline.Click
        Try
            ButtonMenuPendaftaran.BackColor = Color.FromArgb(101, 129, 229)
            ButtonMenuAntrianOnline.BackColor = Color.FromArgb(101, 129, 229)

            Dim menuItem As ToolStripMenuItem = DirectCast(sender, ToolStripMenuItem)
            menuItem.BackColor = Color.FromArgb(85, 99, 114)

            Select Case menuItem.Name
                Case "ButtonMenuPendaftaran"
                    TabControlDaftarMenu.SelectedTab = TabPage1
                Case "ButtonMenuAntrianOnline"
                    TabControlDaftarMenu.SelectedTab = TabPage2
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TextBoxTinggiBadan_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxTinggiBadan.TextChanged
        SetBMI()
    End Sub

    Private Sub TextBoxBeratBadan_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxBeratBadan.TextChanged
        SetBMI()
    End Sub

    Private Sub SetBMI()
        Dim nilaiBMI As Double = 0

        If TextBoxTinggiBadan.Text.Length > 0 And TextBoxBeratBadan.Text.Length > 0 Then
            nilaiBMI = Math.Round(CDbl(TextBoxBeratBadan.Text / (TextBoxTinggiBadan.Text * TextBoxTinggiBadan.Text) * 10000), 1)

            TextBoxIndeks.Text = nilaiBMI
            TextBoxIndeksKeterangan.Text = GetKesimpulanBMI(nilaiBMI)
        End If
    End Sub

    Public Sub ClearDataPendaftaranAwal()
        ClearFormFields()
    End Sub

    'OLD
    'Function ValidasiAntrean(ByRef nomorAntrean As String, ByRef nomorNIK As String, ByRef kodePoli As String, ByRef kodeDokter As String)
    '    ' Variabel BPJS
    '    Dim tglDaftar As String = Format(DateAndTime.Now, "yyyy-MM-dd")
    '    Dim waktuDaftar As String = Format(DateAndTime.Now, "HH:mm")
    '    Dim uriSINA As String = "https://sina.mitramedicare.com/v3/controller/get_status_jadwal_dokter_dan_status_antrean.php"

    '    ' Variabel SINA
    '    Dim kodeLokasi As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NoPoli'")

    '    ' Set parameter untuk POST data ke pcare BPJS
    '    Dim parameterPendaftaran As String = "{" & _
    '           """nik"" : """ & nomorNIK & """," & _
    '           """tanggalpraktek"" : """ & tglDaftar & """," & _
    '           """jampraktek"" : """ & waktuDaftar & """," & _
    '           """nomor_antrean"" : """ & nomorAntrean & """," & _
    '           """kode_poli"" : """ & kodePoli & """," & _
    '           """kode_lokasi"" : """ & kodeLokasi & """," & _
    '           """kode_nakes"": """ & kodeDokter & """" & _
    '          "}"

    '    Dim jsonString As String = InsertDataAPI(parameterPendaftaran, uriSINA)

    '    Dim jsonObject() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of responseAntrol())(jsonString)
    '    For Each rowData As responseAntrol In jsonObject
    '        Dim codeMetaData As Integer = Convert.ToInt32(rowData.code)
    '        Dim messageResponse As String = rowData.message

    '        Select Case codeMetaData
    '            Case 200, 201, 204
    '                Return True
    '            Case Else
    '                GetDataAntreanOnline()
    '                MsgBox("Eror : " & messageResponse, MsgBoxStyle.Exclamation, "Error!")
    '                Return False
    '        End Select
    '    Next

    '    Return True
    'End Function

    'NEW
    Function ValidasiAntrean(ByRef nomorAntrean As String, ByRef nomorNIK As String, ByRef kodePoli As String, ByRef kodeDokter As String)
        Try
            Dim tglDaftar As String = Format(DateAndTime.Now, "yyyy-MM-dd")
            Dim waktuDaftar As String = Format(DateAndTime.Now, "HH:mm")
            Dim kodeLokasi As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NoPoli'")

            ' Buat JSON parameter
            Dim parameterPendaftaran As String = "{" & _
                   """nik"" : """ & nomorNIK & """," & _
                   """tanggalpraktek"" : """ & tglDaftar & """," & _
                   """jampraktek"" : """ & waktuDaftar & """," & _
                   """nomor_antrean"" : """ & nomorAntrean & """," & _
                   """kode_poli"" : """ & kodePoli & """," & _
                   """kode_lokasi"" : """ & kodeLokasi & """," & _
                   """kode_nakes"": """ & kodeDokter & """" & _
                  "}"

            Dim wsCadangan As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_cadangan'")

            Dim baseUrl As String = ""

            If wsCadangan IsNot Nothing AndAlso wsCadangan.ToUpper() = "YES" Then
                baseUrl = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'web_service_cadangan'")
            Else
                baseUrl = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'web_service_klinik'")
            End If

            Dim urlWebService As String = baseUrl & "api/bridge/get-doctor-status"
            Dim jsonString As String = InsertDataAPI(parameterPendaftaran, urlWebService)
            Dim jsonObject() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of responseAntrol())(jsonString)

            For Each rowData As responseAntrol In jsonObject
                Dim codeMetaData As Integer = Convert.ToInt32(rowData.code)
                Dim messageResponse As String = rowData.message

                Select Case codeMetaData
                    Case 200, 201, 204
                        Return True
                    Case Else
                        GetDataAntreanOnline()
                        MsgBox("Eror : " & messageResponse, MsgBoxStyle.Exclamation, "Error!")
                        Return False
                End Select
            Next

            Return True
        Catch ex As Exception
            MsgBox("Exception: " & ex.Message, MsgBoxStyle.Critical, "Error!")
            Return False
        End Try
    End Function

    Private Sub ButtonTambahPaket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTambahPaket.Click
        If GridControlTindakanPoli.MainView IsNot GridViewPaketPoli Then
            ClearGridDataPaket()
        End If

        ' Ambil PoliTujuan dari ComboBox
        Dim poliTujuanFilter As String = ComboBoxPoliTujuan.Text.Trim()

        ' Validasi input
        If poliTujuanFilter = "" Then
            MessageBox.Show("Silakan pilih Poli Tujuan terlebih dahulu.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Query dengan filter PoliTujuan
        Dim queryString As String = "SELECT NamaPaket, KeteranganPaket, " & _
                                "PARSENAME(CONVERT(VARCHAR,CONVERT(MONEY,HargaNett),1),2) AS PaketNilaiTotal, PaketID " & _
                                "FROM MasterPaketTindakan " & _
                                "WHERE CONVERT(DATE, GETDATE()) BETWEEN TanggalMulai AND TanggalBerakhir " & _
                                "AND PoliTujuan LIKE '%" & poliTujuanFilter.Replace("'", "''") & "%'"

        FindMultiple.Show()
        FindMultiple.Query(queryString, " ORDER BY NamaPaket", "FindPemeriksaanPendaftaranPaket", 0)
    End Sub

    Public Sub LoadTindakanPaket(ByRef rowPaket() As DataRow)
        If ValidasiTambahPaketTindakan(rowPaket) = True Then
            Dim tblTindakan As DataTable = GridControlTindakanPoli.DataSource
            tblTindakan.AcceptChanges()
            If rowPaket.Count > 0 Then
                For i As Integer = 0 To rowPaket.Length - 1
                    Dim tblPaket As DataTable = ReadSQL("SELECT * FROM MasterPaketTindakan WHERE PaketID = '" & rowPaket(i)("PaketID").ToString() & "'")
                    For Each Trow As DataRow In tblPaket.Rows
                        Dim Tnew As DataRow = tblTindakan.NewRow
                        Tnew("PaketID") = Trow("PaketID")
                        Tnew("Nama Paket") = Trow("NamaPaket")
                        Tnew("Keterangan Paket") = Trow("KeteranganPaket")
                        Tnew("DurasiAktif") = Trow("DurasiAktif")
                        Tnew("Kuota") = Trow("Kuota")
                        Tnew("Jenis Paket") = Trow("JenisPaket")
                        Tnew("DetailTindakan") = Trow("DetailTindakan")
                        Tnew("Harga Awal") = Splitmoney(Trow("HargaAwal"))
                        Tnew("Diskon") = Splitmoney(Trow("DiskonNominal"))
                        Tnew("Harga Nett") = Splitmoney(Trow("HargaNett"))
                        tblTindakan.Rows.Add(Tnew)
                    Next
                Next
                tblTindakan.AcceptChanges()

                GridViewPaketPoli.ExpandAllGroups()
                GridViewPaketPoli.BestFitColumns()

                KalkulasiPaketTindakan()
            End If
        End If
    End Sub

    Public Sub LoadTindakanPaketQR(ByRef rowPaket() As DataRow)
        'If ValidasiTambahPaketTindakan(rowPaket) = True Then
        '    Dim tblTindakan As DataTable = GridControlTindakanPoli.DataSource
        '    tblTindakan.AcceptChanges()
        '    If rowPaket.Count > 0 Then
        '        For i As Integer = 0 To rowPaket.Length - 1
        '            Dim Tnew As DataRow = tblTindakan.NewRow
        '            Tnew("PaketID") = rowPaket(i)("PaketID")
        '            Tnew("KodeVoucher") = rowPaket(i)("KodeVoucher")
        '            Tnew("Nama Paket") = rowPaket(i)("Nama Paket")
        '            Tnew("Keterangan Paket") = rowPaket(i)("Keterangan Paket")
        '            Tnew("Penjamin") = rowPaket(i)("Penjamin")
        '            Tnew("Harga Awal") = rowPaket(i)("Harga Nett")
        '            Tnew("Diskon") = rowPaket(i)("Harga Nett")
        '            Tnew("Harga Nett") = 0
        '            tblTindakan.Rows.Add(Tnew)
        '        Next
        '        tblTindakan.AcceptChanges()
        '        KalkulasiPaketTindakan()
        '    End If
        'End If

        If ValidasiTambahPaketTindakan(rowPaket) = True Then
            If GridControlTindakanPoli.MainView IsNot GridViewPaketPoli Then ClearGridDataPaket()

            Dim tblTindakan As DataTable = GridControlTindakanPoli.DataSource
            tblTindakan.AcceptChanges()
            If rowPaket.Count > 0 Then
                For i As Integer = 0 To rowPaket.Length - 1
                    Dim jenisTindakan As String = ""
                    If rowPaket(i)("TindakanID").ToString() = "0" Then
                        jenisTindakan = "Paket"
                    Else
                        jenisTindakan = rowPaket(i)("Keterangan Paket")
                    End If

                    'Dim Tnew As DataRow = tblTindakan.NewRow
                    'Tnew("PaketID") = rowPaket(i)("PaketID")
                    'Tnew("TindakanID") = rowPaket(i)("TindakanID")
                    'Tnew("Tindakan") = rowPaket(i)("Nama Paket")
                    'Tnew("Jenis") = jenisTindakan
                    'Tnew("Biaya Tindakan") = rowPaket(i)("Harga Nett")
                    'Tnew("DiscTindakan") = 100
                    'Tnew("DiscNilai") = rowPaket(i)("Harga Nett")
                    'Tnew("NettBayar") = 0

                    'Tnew("KodeVoucher") = rowPaket(i)("KodeVoucher")
                    'Tnew("Klasifikasi") = rowPaket(i)("Jenis Paket")
                    'Tnew("Penjamin") = rowPaket(i)("Penjamin")
                    'tblTindakan.Rows.Add(Tnew)

                    Dim Tnew As DataRow = tblTindakan.NewRow
                    Tnew("PaketID") = rowPaket(i)("PaketID")
                    Tnew("TindakanID") = rowPaket(i)("TindakanID")
                    Tnew("Nama Paket") = rowPaket(i)("Nama Paket")
                    Tnew("Keterangan Paket") = rowPaket(i)("Keterangan Paket")

                    Tnew("Penjamin") = rowPaket(i)("Penjamin")
                    Tnew("Harga Awal") = rowPaket(i)("Harga Nett")
                    Tnew("Diskon") = rowPaket(i)("Harga Nett")
                    Tnew("Harga Nett") = 0

                    Tnew("KodeVoucher") = rowPaket(i)("KodeVoucher")
                    Tnew("Jenis Paket") = rowPaket(i)("Jenis Paket")
                    tblTindakan.Rows.Add(Tnew)
                Next
                tblTindakan.AcceptChanges()

                GridViewPaketPoli.ExpandAllGroups()
                GridViewPaketPoli.BestFitColumns()

                KalkulasiPaketTindakan()
            End If
        End If
    End Sub

    Function ValidasiTambahPaketTindakan(ByRef rowPaket() As DataRow)
        Dim tblTindakan As DataTable = GridControlTindakanPoli.DataSource
        tblTindakan.AcceptChanges()
        If rowPaket.Count > 0 Then
            For i As Integer = 0 To rowPaket.Length - 1
                For Each rowTindakan As DataRow In tblTindakan.Rows
                    If rowTindakan("PaketID").ToString() = rowPaket(i)("PaketID").ToString() Then
                        MsgBox("Paket sudah ada di grid.", MsgBoxStyle.Exclamation, "Warning!")
                        Return False
                    End If
                Next
            Next
        End If
        Return True
    End Function

    Private Sub ButtonScanQR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonScanQR.Click
        DialogBoxPaketTindakan.SetForm("Pendaftaran Awal")
        DialogBoxPaketTindakan.ShowDialog()
    End Sub

    Private Sub ButtonKalkulasi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonKalkulasi.Click
        If GridControlTindakanPoli.MainView Is GridViewTindakanPoli Then
            KalkulasiTindakan()
        ElseIf GridControlTindakanPoli.MainView Is GridViewPaketPoli Then
            KalkulasiPaketTindakan()
        End If
    End Sub

    Function KalkulasiTindakan() As Boolean
        Dim Tbruto As Double = 0
        Dim Tdisc As Double = 0
        Dim Tnett As Double = 0
        Dim Tbayar As Double = 0

        Dim Tbls2 As DataTable = GridControlTindakanPoli.DataSource
        Tbls2.AcceptChanges()

        If Tbls2.Rows.Count > 0 Then
            ' Validasi Inputan Tindakan
            For Each rowTindakan As DataRow In Tbls2.Rows
                Dim discTindakan As Double
                ' Coba parsing input ke dalam tipe data Double
                If Not Double.TryParse(rowTindakan("DiscTindakan").ToString(), discTindakan) Then
                    MsgBox("Gagal. Diskon tindakan " & rowTindakan("Tindakan") & " harus berupa angka.", MsgBoxStyle.Exclamation, "Warning!")
                    Return False
                End If

                ' Validasi diskon tindakan harus antara 0 sampai 100
                'If (discTindakan < 0 OrElse discTindakan > 100) And rowTindakan("Klasifikasi") <> "Paket" Then
                '    MsgBox("Gagal. Diskon tindakan " & rowTindakan("Tindakan") & " harus antara 0 sampai 100.", MsgBoxStyle.Exclamation, "Warning!")
                '    Return False
                'End If

                ' Validasi diskon tindakan harus antara 0 sampai 25
                If (discTindakan < 0 OrElse discTindakan > 25) And rowTindakan("Klasifikasi") <> "Paket" Then
                    MsgBox("Gagal. Diskon tindakan " & rowTindakan("Tindakan") & " harus antara 0 sampai 25.", MsgBoxStyle.Exclamation, "Warning!")
                    Return False
                End If

                ' Coba parsing input ke dalam tipe data Double
                Dim discNilai As Double
                If Not Double.TryParse(rowTindakan("DiscNilai").ToString(), discNilai) Then
                    MsgBox("Gagal. Diskon tindakan " & rowTindakan("Tindakan") & " harus berupa angka.", MsgBoxStyle.Exclamation, "Warning!")
                    Return False
                End If

                ' Validasi diskon tindakan harus antara 0 sampai 100
                If discNilai < 0 Then
                    MsgBox("Gagal. Diskon tindakan " & rowTindakan("Tindakan") & " harus lebih dari 0.", MsgBoxStyle.Exclamation, "Warning!")
                    Return False
                End If

                ' Validasi diskon tindakan tidak boleh lebih dari biaya tindakan.
                If discNilai > CDbl(rowTindakan("Biaya Tindakan").ToString()) Then
                    MsgBox("Gagal. Diskon tindakan " & rowTindakan("Tindakan") & " tidak boleh lebih dari biaya tindakan.", MsgBoxStyle.Exclamation, "Warning!")
                    Return False
                End If
            Next

            For Each Tcol As DataColumn In Tbls2.Columns
                Tcol.ReadOnly = False
            Next

            For Each Trow As DataRow In Tbls2.Rows
                If Trow("DiscTindakan") = "" Then Trow("DiscTindakan") = "0"
                If Trow("DiscNilai") = "" Then Trow("DiscNilai") = "0"

                If Trow("DiscNilai") <> "0" Then
                    Trow("DiscTindakan") = Splitmoney(CDbl(Trow("DiscNilai") / Trow("Biaya Tindakan") * 100))
                ElseIf Trow("DiscTindakan") <> "0" Then
                    Trow("DiscNilai") = Splitmoney(CDbl(Trow("Biaya Tindakan") * Trow("DiscTindakan") / 100))
                End If

                Trow("NettBayar") = Splitmoney(Trow("Biaya Tindakan") - Trow("DiscNilai"))
            Next

            For Each Tcol As DataColumn In Tbls2.Columns
                Tcol.ReadOnly = True
            Next

            Tbls2.Columns("DiscNilai").ReadOnly = False
            Tbls2.Columns("DiscTindakan").ReadOnly = False

            For Each Trow As DataRow In Tbls2.Rows
                Tbruto = CDbl(Tbruto) + CDbl(Trow("Biaya Tindakan"))
                Tnett = CDbl(Tnett) + CDbl(Trow("NettBayar"))
                Tdisc = CDbl(Tdisc) + CDbl(Trow("DiscNilai"))
            Next
        End If

        Dim Tbulat As Double = 100 - (Tnett Mod 100)
        If Tbulat = 100 Then Tbulat = 0

        TextBoxTotalBruto.Text = Splitmoney(Tbruto)
        TextBoxTotalDiskon.Text = Splitmoney(Tdisc)
        TextBoxTotalNett.Text = Splitmoney(Tnett)
        TextBoxTotalPembulatan.Text = Splitmoney(Tbulat)
        TextBoxTotalBayar.Text = Splitmoney(Tbulat + Tnett)

        Return True
    End Function

    Function KalkulasiPaketTindakan() As Boolean
        Dim Tbruto As Double = 0
        Dim Tdisc As Double = 0
        Dim Tnett As Double = 0
        Dim Tbayar As Double = 0

        Dim tblPaket As DataTable = GridControlTindakanPoli.DataSource
        tblPaket.AcceptChanges()

        If tblPaket.Rows.Count > 0 Then
            For Each Trow As DataRow In tblPaket.Rows
                Tbruto = CDbl(Tbruto) + CDbl(Trow("Harga Awal"))
                Tdisc = CDbl(Tdisc) + CDbl(Trow("Diskon"))
                Tnett = CDbl(Tnett) + CDbl(Trow("Harga Nett"))
            Next
        End If

        Dim Tbulat As Double = 100 - (Tnett Mod 100)
        If Tbulat = 100 Then Tbulat = 0

        TextBoxTotalBruto.Text = Splitmoney(Tbruto)
        TextBoxTotalDiskon.Text = Splitmoney(Tdisc)
        TextBoxTotalNett.Text = Splitmoney(Tnett)
        TextBoxTotalPembulatan.Text = Splitmoney(Tbulat)
        TextBoxTotalBayar.Text = Splitmoney(Tbulat + Tnett)

        Return True
    End Function

    Private Sub TextBoxPoliKeluhanUtama_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxPoliKeluhanUtama.KeyPress
        ' Memeriksa apakah tombol yang ditekan adalah Enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            ' Mencegah input Enter
            e.Handled = True
        End If
    End Sub

    Private Sub TextBoxPoliKeluhanTambahan_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxPoliKeluhanTambahan.KeyPress
        ' Memeriksa apakah tombol yang ditekan adalah Enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            ' Mencegah input Enter
            e.Handled = True
        End If
    End Sub

    Private Sub CheckBoxPaket_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxPaket.CheckedChanged
        ' Set Clear
        Dim tblsTindakan As DataTable = CType(GridControlTindakanPoli.DataSource, DataTable)
        If tblsTindakan IsNot Nothing Then tblsTindakan.Clear()

        If CheckBoxPaket.Checked = True Then
            ' Disable Button & ComboBox
            ComboBoxPilihanDokter.Enabled = False
            ComboBoxPilihanPerawat.Enabled = False
            ComboBoxMarketing.Enabled = False

            TextBoxPoliKeluhanUtama.Enabled = False
            TextBoxPoliKeluhanTambahan.Enabled = False

            DisablePemeriksaanFisik()
            ComboBoxPilihanDokter.SelectedIndex = -1
            ComboBoxPilihanPerawat.SelectedIndex = -1
            ComboBoxMarketing.SelectedIndex = -1
            TextBoxPoliKeluhanUtama.ResetText()
            TextBoxPoliKeluhanTambahan.ResetText()

            ButtonTambahTindakan.Visible = False
            ButtonScanQR.Visible = False
            ButtonTambahPaket.Visible = True

            ' Hidden Tab Pemeriksaan Fisik
            TabControlMenu1.TabPages.Remove(TabPagePemeriksaanFisik)
            TabPagePemeriksaanFisik.Hide()
        ElseIf CheckBoxPaket.Checked = False Then
            If ComboBoxPoliTujuan.Text <> "" Then
                ' Get Detail Poli Tujuan
                Dim tblPoli As DataTable = ReadSQL("SELECT * FROM MasterPoliTujuan WHERE NamaPoli = '" & ComboBoxPoliTujuan.Text & "'")
                Dim TrowPoli As DataRow = tblPoli.Rows(0)

                ' Set Enable Dokter & Perawat
                If TrowPoli("DokterAwal") = True Then
                    ComboBoxPilihanDokter.Enabled = True
                    ComboBoxPilihanPerawat.Enabled = True
                    ComboBoxMarketing.Enabled = True

                    TextBoxPoliKeluhanUtama.Enabled = True
                    TextBoxPoliKeluhanTambahan.Enabled = True
                End If

                ' Set Enable Tindakan
                If TrowPoli("TindakanAwal") = True Then
                    If Not TabControlMenu1.TabPages.Contains(TabPageTindakan) Then
                        ' Tambahkan TabPageSetTindakan ke posisi pertama (indeks 0)
                        TabControlMenu1.TabPages.Insert(0, TabPageTindakan)

                        ' Atur TabPageSetTindakan sebagai tab yang aktif
                        TabControlMenu1.SelectedTab = TabPageTindakan
                    End If
                Else
                    TabControlMenu1.TabPages.Remove(TabPageTindakan)
                    TabPageTindakan.Hide()
                End If

                ButtonTambahTindakan.Visible = True
                ButtonScanQR.Visible = True
                ButtonTambahPaket.Visible = False

                ' Visible Tab Pemeriksaan Fisik
                If Not TabControlMenu1.TabPages.Contains(TabPagePemeriksaanFisik) Then
                    ' Tambahkan TabPagePemeriksaanFisik ke posisi pertama (indeks 1)
                    TabControlMenu1.TabPages.Insert(1, TabPagePemeriksaanFisik)
                End If
            End If
        End If
    End Sub
End Class