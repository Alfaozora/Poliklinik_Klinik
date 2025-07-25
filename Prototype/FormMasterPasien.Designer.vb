<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterPasien
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMasterPasien))
        Me.PanelTop = New System.Windows.Forms.Panel
        Me.btnClose = New System.Windows.Forms.Button
        Me.PanelSide = New System.Windows.Forms.Panel
        Me.btnMenu4 = New System.Windows.Forms.Button
        Me.btnMenu3 = New System.Windows.Forms.Button
        Me.btnMenu2 = New System.Windows.Forms.Button
        Me.btnMenu1 = New System.Windows.Forms.Button
        Me.ToolTipBtnMenu = New System.Windows.Forms.ToolTip(Me.components)
        Me.ButtonCekNIK = New System.Windows.Forms.Button
        Me.ButtonCekKIS = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.ButtonGetNomorIHS = New System.Windows.Forms.Button
        Me.ButtonCariNoRM = New System.Windows.Forms.Button
        Me.ButtonUploadFoto = New System.Windows.Forms.Button
        Me.TabControlMenu = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.PanelLayoutMenu1TopMain = New System.Windows.Forms.Panel
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.PictureBoxFotoPasien = New System.Windows.Forms.PictureBox
        Me.GroupBoxAlergiPemeriksaanAwal = New System.Windows.Forms.GroupBox
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.ButtonTambahAlergi = New System.Windows.Forms.Button
        Me.ButtonHapusAlergi = New System.Windows.Forms.Button
        Me.GridControlAlergi = New DevExpress.XtraGrid.GridControl
        Me.GridViewAlergi = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.CheckBoxStatusNIK = New System.Windows.Forms.CheckBox
        Me.Label71 = New System.Windows.Forms.Label
        Me.TextBoxNoDokumenRM = New System.Windows.Forms.TextBox
        Me.TextBoxNomorIHS = New System.Windows.Forms.TextBox
        Me.Label65 = New System.Windows.Forms.Label
        Me.LabelSignatureDate = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.LabelSignatureKeterangan = New System.Windows.Forms.Label
        Me.Label64 = New System.Windows.Forms.Label
        Me.TextBoxNoTeleponGC = New System.Windows.Forms.TextBox
        Me.Label63 = New System.Windows.Forms.Label
        Me.TextBoxTempatLahirGC = New System.Windows.Forms.TextBox
        Me.PictureBoxSignatureGC = New System.Windows.Forms.PictureBox
        Me.Label62 = New System.Windows.Forms.Label
        Me.Label61 = New System.Windows.Forms.Label
        Me.Label60 = New System.Windows.Forms.Label
        Me.DateTimePickerTglLahirGC = New System.Windows.Forms.DateTimePicker
        Me.PanelJenisKelaminGC = New System.Windows.Forms.Panel
        Me.RadioButtonJenisKelaminLakiGC = New System.Windows.Forms.RadioButton
        Me.RadioButtonJenisKelaminPerempuanGC = New System.Windows.Forms.RadioButton
        Me.TextBoxNamaGC = New System.Windows.Forms.TextBox
        Me.TextBoxHubunganKeluargaGC = New System.Windows.Forms.TextBox
        Me.TextBoxAlamatGC = New System.Windows.Forms.TextBox
        Me.Label55 = New System.Windows.Forms.Label
        Me.Label57 = New System.Windows.Forms.Label
        Me.Label58 = New System.Windows.Forms.Label
        Me.GroupBoxWaliPasien = New System.Windows.Forms.GroupBox
        Me.CheckBoxStatusWaliPasien = New System.Windows.Forms.CheckBox
        Me.TextBoxAlamatDomisiliWali = New System.Windows.Forms.TextBox
        Me.TextBoxTempatLahirWali = New System.Windows.Forms.TextBox
        Me.TextBoxHubunganKeluargaWali = New System.Windows.Forms.TextBox
        Me.TextBoxNoHPWali = New System.Windows.Forms.TextBox
        Me.DateTimePickerTglLahirWali = New System.Windows.Forms.DateTimePicker
        Me.PanelJenisKelaminWali = New System.Windows.Forms.Panel
        Me.RadioButtonJenisKelaminLakiWali = New System.Windows.Forms.RadioButton
        Me.RadioButtonJenisKelaminPerempuanWali = New System.Windows.Forms.RadioButton
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label42 = New System.Windows.Forms.Label
        Me.Label45 = New System.Windows.Forms.Label
        Me.Label51 = New System.Windows.Forms.Label
        Me.TextBoxNamaLengkapWali = New System.Windows.Forms.TextBox
        Me.Label52 = New System.Windows.Forms.Label
        Me.Label53 = New System.Windows.Forms.Label
        Me.Label54 = New System.Windows.Forms.Label
        Me.GroupBox9 = New System.Windows.Forms.GroupBox
        Me.TextBoxRiwayatKebiasaan = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TextBoxRiwayatPenyakitKeluarga = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.TextBoxRiwayatPenyakitDahulu = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.TextBoxNoRM = New System.Windows.Forms.TextBox
        Me.Label59 = New System.Windows.Forms.Label
        Me.GroupBoxDataLain = New System.Windows.Forms.GroupBox
        Me.ComboBoxStatusPerkawinan = New System.Windows.Forms.ComboBox
        Me.ComboBoxPendidikanTerakhir = New System.Windows.Forms.ComboBox
        Me.ComboBoxAgama = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.TextBoxNoTeleponIdentitas = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.TextBoxNoHPIdentitas = New System.Windows.Forms.TextBox
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.RadioButtonWNI = New System.Windows.Forms.RadioButton
        Me.RadioButtonWNA = New System.Windows.Forms.RadioButton
        Me.Label9 = New System.Windows.Forms.Label
        Me.TextBoxKetWNA = New System.Windows.Forms.TextBox
        Me.TextBoxEmailIdentitas = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBoxAlamatDomisili = New System.Windows.Forms.GroupBox
        Me.ComboBoxKelurahanDomisili = New System.Windows.Forms.ComboBox
        Me.Label70 = New System.Windows.Forms.Label
        Me.ComboBoxKecamatanDomisili = New System.Windows.Forms.ComboBox
        Me.Label69 = New System.Windows.Forms.Label
        Me.ComboBoxKabupatenDomisili = New System.Windows.Forms.ComboBox
        Me.Label68 = New System.Windows.Forms.Label
        Me.ComboBoxProvinsiDomisili = New System.Windows.Forms.ComboBox
        Me.Label67 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.TextBoxAlamatDomisili = New System.Windows.Forms.TextBox
        Me.TextBoxRTDomisili = New System.Windows.Forms.TextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.TextBoxRWDomisili = New System.Windows.Forms.TextBox
        Me.TextBoxKodePosDomisili = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.GroupBoxAlamatKTP = New System.Windows.Forms.GroupBox
        Me.ComboBoxKelurahanKTP = New System.Windows.Forms.ComboBox
        Me.Label72 = New System.Windows.Forms.Label
        Me.ComboBoxKecamatanKTP = New System.Windows.Forms.ComboBox
        Me.Label73 = New System.Windows.Forms.Label
        Me.ComboBoxKabupatenKTP = New System.Windows.Forms.ComboBox
        Me.Label74 = New System.Windows.Forms.Label
        Me.ComboBoxProvinsiKTP = New System.Windows.Forms.ComboBox
        Me.Label75 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.TextBoxAlamatKTP = New System.Windows.Forms.TextBox
        Me.TextBoxRTKTP = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.TextBoxRWKTP = New System.Windows.Forms.TextBox
        Me.TextBoxKodePosKTP = New System.Windows.Forms.TextBox
        Me.CheckBoxCopyAlamatDomisili = New System.Windows.Forms.CheckBox
        Me.GroupBoxBiodataDiri = New System.Windows.Forms.GroupBox
        Me.TextBoxNomorCahaya = New System.Windows.Forms.TextBox
        Me.ComboBoxStatusKeluarga = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label39 = New System.Windows.Forms.Label
        Me.TextBoxPRB = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.TextBoxNamaLengkapIdentitas = New System.Windows.Forms.TextBox
        Me.TextBoxProlanis = New System.Windows.Forms.TextBox
        Me.Label37 = New System.Windows.Forms.Label
        Me.Label43 = New System.Windows.Forms.Label
        Me.TextBoxTempatLahir = New System.Windows.Forms.TextBox
        Me.Label36 = New System.Windows.Forms.Label
        Me.DateTimePickerTglLahir = New System.Windows.Forms.DateTimePicker
        Me.TextBoxNomorJPK = New System.Windows.Forms.TextBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label48 = New System.Windows.Forms.Label
        Me.PanelJenisKelaminPasien = New System.Windows.Forms.Panel
        Me.RadioButtonJenisKelaminLakiIdentitas = New System.Windows.Forms.RadioButton
        Me.RadioButtonJenisKelaminPerempuanIdentitas = New System.Windows.Forms.RadioButton
        Me.TextBoxNomorInhealth = New System.Windows.Forms.TextBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.Label47 = New System.Windows.Forms.Label
        Me.ComboBoxGolDarahIdentitas = New System.Windows.Forms.ComboBox
        Me.TextBoxNomorNIP = New System.Windows.Forms.TextBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label46 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.TextBoxPekerjaan = New System.Windows.Forms.TextBox
        Me.GroupBoxJKN = New System.Windows.Forms.GroupBox
        Me.TextBoxFaskesAktif = New System.Windows.Forms.TextBox
        Me.Label40 = New System.Windows.Forms.Label
        Me.TextBoxFKTP = New System.Windows.Forms.TextBox
        Me.TextBoxNomorKIS = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TextBoxStatusPeserta = New System.Windows.Forms.TextBox
        Me.TextBoxStatusAktif = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.TextBoxNomorNIK = New System.Windows.Forms.TextBox
        Me.Label41 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.PanelLayoutMenu2TopMain = New System.Windows.Forms.Panel
        Me.TextBoxHPKontakDarurat = New System.Windows.Forms.TextBox
        Me.Label38 = New System.Windows.Forms.Label
        Me.TextBoxAlamatKontakDarurat = New System.Windows.Forms.TextBox
        Me.Label56 = New System.Windows.Forms.Label
        Me.TextBoxNamaLengkapKontakDarurat = New System.Windows.Forms.TextBox
        Me.Label66 = New System.Windows.Forms.Label
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.PanelLayoutMenu3TopMain = New System.Windows.Forms.Panel
        Me.TextBoxNoKaryawanPerusahaan = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBoxEmailPerusahaan = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBoxTeleponPerusahaan = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TextBoxAlamatPerusahaan = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.TextBoxNamaPerusahaan = New System.Windows.Forms.TextBox
        Me.Label44 = New System.Windows.Forms.Label
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.PanelLayoutMenu4TopMain = New System.Windows.Forms.Panel
        Me.PanelButton = New System.Windows.Forms.Panel
        Me.ButtonCetakGeneralConsent = New System.Windows.Forms.Button
        Me.ButtonClearMenu1 = New System.Windows.Forms.Button
        Me.ButtonScanQR = New System.Windows.Forms.Button
        Me.ButtonSimpanMenu1 = New System.Windows.Forms.Button
        Me.SplitContainer9 = New System.Windows.Forms.SplitContainer
        Me.PanelTop.SuspendLayout()
        Me.PanelSide.SuspendLayout()
        Me.TabControlMenu.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.PanelLayoutMenu1TopMain.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBoxFotoPasien, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxAlergiPemeriksaanAwal.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.GridControlAlergi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewAlergi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBoxSignatureGC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelJenisKelaminGC.SuspendLayout()
        Me.GroupBoxWaliPasien.SuspendLayout()
        Me.PanelJenisKelaminWali.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBoxDataLain.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.GroupBoxAlamatDomisili.SuspendLayout()
        Me.GroupBoxAlamatKTP.SuspendLayout()
        Me.GroupBoxBiodataDiri.SuspendLayout()
        Me.PanelJenisKelaminPasien.SuspendLayout()
        Me.GroupBoxJKN.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.PanelLayoutMenu2TopMain.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.PanelLayoutMenu3TopMain.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.PanelButton.SuspendLayout()
        Me.SplitContainer9.Panel1.SuspendLayout()
        Me.SplitContainer9.Panel2.SuspendLayout()
        Me.SplitContainer9.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.PanelTop.Controls.Add(Me.btnClose)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(1100, 40)
        Me.PanelTop.TabIndex = 0
        '
        'btnClose
        '
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(1060, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(40, 40)
        Me.btnClose.TabIndex = 281
        Me.ToolTipBtnMenu.SetToolTip(Me.btnClose, "Tutup Form")
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'PanelSide
        '
        Me.PanelSide.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.PanelSide.Controls.Add(Me.btnMenu4)
        Me.PanelSide.Controls.Add(Me.btnMenu3)
        Me.PanelSide.Controls.Add(Me.btnMenu2)
        Me.PanelSide.Controls.Add(Me.btnMenu1)
        Me.PanelSide.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelSide.Location = New System.Drawing.Point(0, 40)
        Me.PanelSide.Name = "PanelSide"
        Me.PanelSide.Size = New System.Drawing.Size(150, 644)
        Me.PanelSide.TabIndex = 1
        '
        'btnMenu4
        '
        Me.btnMenu4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnMenu4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMenu4.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnMenu4.FlatAppearance.BorderSize = 0
        Me.btnMenu4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btnMenu4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnMenu4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMenu4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnMenu4.ForeColor = System.Drawing.Color.White
        Me.btnMenu4.Location = New System.Drawing.Point(0, 135)
        Me.btnMenu4.Name = "btnMenu4"
        Me.btnMenu4.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnMenu4.Size = New System.Drawing.Size(150, 45)
        Me.btnMenu4.TabIndex = 5
        Me.btnMenu4.Text = "Asuransi"
        Me.ToolTipBtnMenu.SetToolTip(Me.btnMenu4, "Asuransi")
        Me.btnMenu4.UseVisualStyleBackColor = True
        Me.btnMenu4.Visible = False
        '
        'btnMenu3
        '
        Me.btnMenu3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnMenu3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMenu3.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnMenu3.FlatAppearance.BorderSize = 0
        Me.btnMenu3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btnMenu3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnMenu3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMenu3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnMenu3.ForeColor = System.Drawing.Color.White
        Me.btnMenu3.Location = New System.Drawing.Point(0, 90)
        Me.btnMenu3.Name = "btnMenu3"
        Me.btnMenu3.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnMenu3.Size = New System.Drawing.Size(150, 45)
        Me.btnMenu3.TabIndex = 4
        Me.btnMenu3.Text = "Kontak Pekerjaan"
        Me.ToolTipBtnMenu.SetToolTip(Me.btnMenu3, "Kontak Pekerjaan")
        Me.btnMenu3.UseVisualStyleBackColor = True
        Me.btnMenu3.Visible = False
        '
        'btnMenu2
        '
        Me.btnMenu2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnMenu2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMenu2.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnMenu2.FlatAppearance.BorderSize = 0
        Me.btnMenu2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btnMenu2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnMenu2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMenu2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnMenu2.ForeColor = System.Drawing.Color.White
        Me.btnMenu2.Location = New System.Drawing.Point(0, 45)
        Me.btnMenu2.Name = "btnMenu2"
        Me.btnMenu2.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnMenu2.Size = New System.Drawing.Size(150, 45)
        Me.btnMenu2.TabIndex = 3
        Me.btnMenu2.Text = "Kontak Darurat"
        Me.ToolTipBtnMenu.SetToolTip(Me.btnMenu2, "Kontak Darurat")
        Me.btnMenu2.UseVisualStyleBackColor = True
        Me.btnMenu2.Visible = False
        '
        'btnMenu1
        '
        Me.btnMenu1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnMenu1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMenu1.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnMenu1.FlatAppearance.BorderSize = 0
        Me.btnMenu1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btnMenu1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnMenu1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMenu1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnMenu1.ForeColor = System.Drawing.Color.White
        Me.btnMenu1.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_user_account_30
        Me.btnMenu1.Location = New System.Drawing.Point(0, 0)
        Me.btnMenu1.Name = "btnMenu1"
        Me.btnMenu1.Padding = New System.Windows.Forms.Padding(5, 0, 0, 0)
        Me.btnMenu1.Size = New System.Drawing.Size(150, 45)
        Me.btnMenu1.TabIndex = 0
        Me.btnMenu1.Text = "Identitas Diri"
        Me.btnMenu1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTipBtnMenu.SetToolTip(Me.btnMenu1, "Identitas Pasien")
        Me.btnMenu1.UseVisualStyleBackColor = False
        '
        'ButtonCekNIK
        '
        Me.ButtonCekNIK.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCekNIK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonCekNIK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonCekNIK.FlatAppearance.BorderSize = 0
        Me.ButtonCekNIK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCekNIK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonCekNIK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCekNIK.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonCekNIK.ForeColor = System.Drawing.Color.White
        Me.ButtonCekNIK.Location = New System.Drawing.Point(405, 92)
        Me.ButtonCekNIK.Name = "ButtonCekNIK"
        Me.ButtonCekNIK.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonCekNIK.Size = New System.Drawing.Size(150, 25)
        Me.ButtonCekNIK.TabIndex = 421
        Me.ButtonCekNIK.Text = "Cek BPJS - NIK"
        Me.ButtonCekNIK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTipBtnMenu.SetToolTip(Me.ButtonCekNIK, "Cek BPJS")
        Me.ButtonCekNIK.UseVisualStyleBackColor = False
        '
        'ButtonCekKIS
        '
        Me.ButtonCekKIS.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCekKIS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonCekKIS.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonCekKIS.FlatAppearance.BorderSize = 0
        Me.ButtonCekKIS.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCekKIS.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonCekKIS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCekKIS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonCekKIS.ForeColor = System.Drawing.Color.White
        Me.ButtonCekKIS.Location = New System.Drawing.Point(387, 27)
        Me.ButtonCekKIS.Name = "ButtonCekKIS"
        Me.ButtonCekKIS.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonCekKIS.Size = New System.Drawing.Size(150, 25)
        Me.ButtonCekKIS.TabIndex = 422
        Me.ButtonCekKIS.Text = "Cek BPJS - No. Kartu"
        Me.ButtonCekKIS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTipBtnMenu.SetToolTip(Me.ButtonCekKIS, "Cek BPJS")
        Me.ButtonCekKIS.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(727, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Button1.Size = New System.Drawing.Size(149, 30)
        Me.Button1.TabIndex = 501
        Me.Button1.Text = "Get General Consent"
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTipBtnMenu.SetToolTip(Me.Button1, "Cari Data eRM")
        Me.Button1.UseVisualStyleBackColor = False
        Me.Button1.Visible = False
        '
        'ButtonGetNomorIHS
        '
        Me.ButtonGetNomorIHS.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonGetNomorIHS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonGetNomorIHS.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonGetNomorIHS.FlatAppearance.BorderSize = 0
        Me.ButtonGetNomorIHS.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonGetNomorIHS.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonGetNomorIHS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonGetNomorIHS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonGetNomorIHS.ForeColor = System.Drawing.Color.White
        Me.ButtonGetNomorIHS.Location = New System.Drawing.Point(405, 147)
        Me.ButtonGetNomorIHS.Name = "ButtonGetNomorIHS"
        Me.ButtonGetNomorIHS.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonGetNomorIHS.Size = New System.Drawing.Size(150, 25)
        Me.ButtonGetNomorIHS.TabIndex = 519
        Me.ButtonGetNomorIHS.Text = "Cek SATUSEHAT"
        Me.ButtonGetNomorIHS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTipBtnMenu.SetToolTip(Me.ButtonGetNomorIHS, "Cek BPJS")
        Me.ButtonGetNomorIHS.UseVisualStyleBackColor = False
        '
        'ButtonCariNoRM
        '
        Me.ButtonCariNoRM.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCariNoRM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonCariNoRM.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonCariNoRM.FlatAppearance.BorderSize = 0
        Me.ButtonCariNoRM.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCariNoRM.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonCariNoRM.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCariNoRM.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonCariNoRM.ForeColor = System.Drawing.Color.White
        Me.ButtonCariNoRM.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_search_16
        Me.ButtonCariNoRM.Location = New System.Drawing.Point(521, 27)
        Me.ButtonCariNoRM.Name = "ButtonCariNoRM"
        Me.ButtonCariNoRM.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonCariNoRM.Size = New System.Drawing.Size(34, 25)
        Me.ButtonCariNoRM.TabIndex = 520
        Me.ButtonCariNoRM.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTipBtnMenu.SetToolTip(Me.ButtonCariNoRM, "Cek BPJS")
        Me.ButtonCariNoRM.UseVisualStyleBackColor = False
        '
        'ButtonUploadFoto
        '
        Me.ButtonUploadFoto.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonUploadFoto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonUploadFoto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonUploadFoto.FlatAppearance.BorderSize = 0
        Me.ButtonUploadFoto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonUploadFoto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonUploadFoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonUploadFoto.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonUploadFoto.ForeColor = System.Drawing.Color.White
        Me.ButtonUploadFoto.Location = New System.Drawing.Point(30, 231)
        Me.ButtonUploadFoto.Name = "ButtonUploadFoto"
        Me.ButtonUploadFoto.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonUploadFoto.Size = New System.Drawing.Size(150, 25)
        Me.ButtonUploadFoto.TabIndex = 422
        Me.ButtonUploadFoto.Text = "Upload Foto"
        Me.ButtonUploadFoto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTipBtnMenu.SetToolTip(Me.ButtonUploadFoto, "Cek BPJS")
        Me.ButtonUploadFoto.UseVisualStyleBackColor = False
        '
        'TabControlMenu
        '
        Me.TabControlMenu.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControlMenu.Controls.Add(Me.TabPage1)
        Me.TabControlMenu.Controls.Add(Me.TabPage2)
        Me.TabControlMenu.Controls.Add(Me.TabPage3)
        Me.TabControlMenu.Controls.Add(Me.TabPage4)
        Me.TabControlMenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlMenu.Location = New System.Drawing.Point(0, 0)
        Me.TabControlMenu.Name = "TabControlMenu"
        Me.TabControlMenu.SelectedIndex = 0
        Me.TabControlMenu.Size = New System.Drawing.Size(950, 594)
        Me.TabControlMenu.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControlMenu.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.White
        Me.TabPage1.Controls.Add(Me.PanelLayoutMenu1TopMain)
        Me.TabPage1.Location = New System.Drawing.Point(4, 27)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(942, 563)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Tab Menu 1"
        '
        'PanelLayoutMenu1TopMain
        '
        Me.PanelLayoutMenu1TopMain.AutoScroll = True
        Me.PanelLayoutMenu1TopMain.BackColor = System.Drawing.Color.White
        Me.PanelLayoutMenu1TopMain.Controls.Add(Me.Button1)
        Me.PanelLayoutMenu1TopMain.Controls.Add(Me.GroupBox2)
        Me.PanelLayoutMenu1TopMain.Controls.Add(Me.GroupBoxAlergiPemeriksaanAwal)
        Me.PanelLayoutMenu1TopMain.Controls.Add(Me.CheckBoxStatusNIK)
        Me.PanelLayoutMenu1TopMain.Controls.Add(Me.Label71)
        Me.PanelLayoutMenu1TopMain.Controls.Add(Me.TextBoxNoDokumenRM)
        Me.PanelLayoutMenu1TopMain.Controls.Add(Me.ButtonCariNoRM)
        Me.PanelLayoutMenu1TopMain.Controls.Add(Me.ButtonGetNomorIHS)
        Me.PanelLayoutMenu1TopMain.Controls.Add(Me.TextBoxNomorIHS)
        Me.PanelLayoutMenu1TopMain.Controls.Add(Me.Label65)
        Me.PanelLayoutMenu1TopMain.Controls.Add(Me.LabelSignatureDate)
        Me.PanelLayoutMenu1TopMain.Controls.Add(Me.GroupBox1)
        Me.PanelLayoutMenu1TopMain.Controls.Add(Me.GroupBoxWaliPasien)
        Me.PanelLayoutMenu1TopMain.Controls.Add(Me.GroupBox9)
        Me.PanelLayoutMenu1TopMain.Controls.Add(Me.TextBoxNoRM)
        Me.PanelLayoutMenu1TopMain.Controls.Add(Me.Label59)
        Me.PanelLayoutMenu1TopMain.Controls.Add(Me.GroupBoxDataLain)
        Me.PanelLayoutMenu1TopMain.Controls.Add(Me.GroupBoxAlamatDomisili)
        Me.PanelLayoutMenu1TopMain.Controls.Add(Me.GroupBoxAlamatKTP)
        Me.PanelLayoutMenu1TopMain.Controls.Add(Me.GroupBoxBiodataDiri)
        Me.PanelLayoutMenu1TopMain.Controls.Add(Me.GroupBoxJKN)
        Me.PanelLayoutMenu1TopMain.Controls.Add(Me.ButtonCekNIK)
        Me.PanelLayoutMenu1TopMain.Controls.Add(Me.TextBoxNomorNIK)
        Me.PanelLayoutMenu1TopMain.Controls.Add(Me.Label41)
        Me.PanelLayoutMenu1TopMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelLayoutMenu1TopMain.Location = New System.Drawing.Point(3, 3)
        Me.PanelLayoutMenu1TopMain.Name = "PanelLayoutMenu1TopMain"
        Me.PanelLayoutMenu1TopMain.Size = New System.Drawing.Size(936, 557)
        Me.PanelLayoutMenu1TopMain.TabIndex = 6
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ButtonUploadFoto)
        Me.GroupBox2.Controls.Add(Me.PictureBoxFotoPasien)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(577, 24)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(210, 262)
        Me.GroupBox2.TabIndex = 534
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Foto Pasien"
        '
        'PictureBoxFotoPasien
        '
        Me.PictureBoxFotoPasien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBoxFotoPasien.Location = New System.Drawing.Point(17, 31)
        Me.PictureBoxFotoPasien.Name = "PictureBoxFotoPasien"
        Me.PictureBoxFotoPasien.Size = New System.Drawing.Size(177, 196)
        Me.PictureBoxFotoPasien.TabIndex = 0
        Me.PictureBoxFotoPasien.TabStop = False
        '
        'GroupBoxAlergiPemeriksaanAwal
        '
        Me.GroupBoxAlergiPemeriksaanAwal.Controls.Add(Me.SplitContainer1)
        Me.GroupBoxAlergiPemeriksaanAwal.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxAlergiPemeriksaanAwal.Location = New System.Drawing.Point(574, 292)
        Me.GroupBoxAlergiPemeriksaanAwal.Name = "GroupBoxAlergiPemeriksaanAwal"
        Me.GroupBoxAlergiPemeriksaanAwal.Size = New System.Drawing.Size(385, 330)
        Me.GroupBoxAlergiPemeriksaanAwal.TabIndex = 533
        Me.GroupBoxAlergiPemeriksaanAwal.TabStop = False
        Me.GroupBoxAlergiPemeriksaanAwal.Text = "Alergi Pasien"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 23)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(30)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.White
        Me.SplitContainer1.Panel1.Controls.Add(Me.ButtonTambahAlergi)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ButtonHapusAlergi)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GridControlAlergi)
        Me.SplitContainer1.Size = New System.Drawing.Size(379, 304)
        Me.SplitContainer1.SplitterDistance = 32
        Me.SplitContainer1.TabIndex = 0
        '
        'ButtonTambahAlergi
        '
        Me.ButtonTambahAlergi.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonTambahAlergi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonTambahAlergi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonTambahAlergi.FlatAppearance.BorderSize = 0
        Me.ButtonTambahAlergi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonTambahAlergi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonTambahAlergi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonTambahAlergi.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonTambahAlergi.ForeColor = System.Drawing.Color.White
        Me.ButtonTambahAlergi.Location = New System.Drawing.Point(3, 3)
        Me.ButtonTambahAlergi.Name = "ButtonTambahAlergi"
        Me.ButtonTambahAlergi.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonTambahAlergi.Size = New System.Drawing.Size(100, 25)
        Me.ButtonTambahAlergi.TabIndex = 535
        Me.ButtonTambahAlergi.Text = "Tambah Alergi"
        Me.ButtonTambahAlergi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonTambahAlergi.UseVisualStyleBackColor = False
        '
        'ButtonHapusAlergi
        '
        Me.ButtonHapusAlergi.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.ButtonHapusAlergi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonHapusAlergi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonHapusAlergi.FlatAppearance.BorderSize = 0
        Me.ButtonHapusAlergi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.ButtonHapusAlergi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonHapusAlergi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonHapusAlergi.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonHapusAlergi.ForeColor = System.Drawing.Color.White
        Me.ButtonHapusAlergi.Location = New System.Drawing.Point(109, 3)
        Me.ButtonHapusAlergi.Name = "ButtonHapusAlergi"
        Me.ButtonHapusAlergi.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonHapusAlergi.Size = New System.Drawing.Size(75, 25)
        Me.ButtonHapusAlergi.TabIndex = 536
        Me.ButtonHapusAlergi.Text = "Hapus"
        Me.ButtonHapusAlergi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonHapusAlergi.UseVisualStyleBackColor = False
        '
        'GridControlAlergi
        '
        Me.GridControlAlergi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControlAlergi.EmbeddedNavigator.Name = ""
        Me.GridControlAlergi.Location = New System.Drawing.Point(0, 0)
        Me.GridControlAlergi.MainView = Me.GridViewAlergi
        Me.GridControlAlergi.Name = "GridControlAlergi"
        Me.GridControlAlergi.Size = New System.Drawing.Size(379, 268)
        Me.GridControlAlergi.TabIndex = 185
        Me.GridControlAlergi.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewAlergi})
        '
        'GridViewAlergi
        '
        Me.GridViewAlergi.GridControl = Me.GridControlAlergi
        Me.GridViewAlergi.Name = "GridViewAlergi"
        Me.GridViewAlergi.OptionsBehavior.Editable = False
        Me.GridViewAlergi.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridViewAlergi.OptionsView.ShowGroupPanel = False
        Me.GridViewAlergi.OptionsView.ShowIndicator = False
        Me.GridViewAlergi.PaintStyleName = "Skin"
        '
        'CheckBoxStatusNIK
        '
        Me.CheckBoxStatusNIK.AutoSize = True
        Me.CheckBoxStatusNIK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CheckBoxStatusNIK.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxStatusNIK.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CheckBoxStatusNIK.Location = New System.Drawing.Point(205, 124)
        Me.CheckBoxStatusNIK.Name = "CheckBoxStatusNIK"
        Me.CheckBoxStatusNIK.Size = New System.Drawing.Size(182, 17)
        Me.CheckBoxStatusNIK.TabIndex = 532
        Me.CheckBoxStatusNIK.Text = "Tidak bawa / belum punya NIK"
        Me.CheckBoxStatusNIK.UseVisualStyleBackColor = True
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label71.Location = New System.Drawing.Point(33, 62)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(116, 17)
        Me.Label71.TabIndex = 521
        Me.Label71.Text = "No. Dokumen RM"
        '
        'TextBoxNoDokumenRM
        '
        Me.TextBoxNoDokumenRM.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxNoDokumenRM.Location = New System.Drawing.Point(205, 59)
        Me.TextBoxNoDokumenRM.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxNoDokumenRM.Name = "TextBoxNoDokumenRM"
        Me.TextBoxNoDokumenRM.Size = New System.Drawing.Size(350, 25)
        Me.TextBoxNoDokumenRM.TabIndex = 522
        '
        'TextBoxNomorIHS
        '
        Me.TextBoxNomorIHS.BackColor = System.Drawing.Color.White
        Me.TextBoxNomorIHS.Cursor = System.Windows.Forms.Cursors.No
        Me.TextBoxNomorIHS.Enabled = False
        Me.TextBoxNomorIHS.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxNomorIHS.Location = New System.Drawing.Point(205, 147)
        Me.TextBoxNomorIHS.Name = "TextBoxNomorIHS"
        Me.TextBoxNomorIHS.Size = New System.Drawing.Size(194, 25)
        Me.TextBoxNomorIHS.TabIndex = 517
        Me.TextBoxNomorIHS.TabStop = False
        Me.TextBoxNomorIHS.Tag = ""
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label65.Location = New System.Drawing.Point(33, 147)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(83, 17)
        Me.Label65.TabIndex = 516
        Me.Label65.Text = "IHS Number"
        '
        'LabelSignatureDate
        '
        Me.LabelSignatureDate.AutoSize = True
        Me.LabelSignatureDate.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSignatureDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelSignatureDate.Location = New System.Drawing.Point(733, 1214)
        Me.LabelSignatureDate.Name = "LabelSignatureDate"
        Me.LabelSignatureDate.Size = New System.Drawing.Size(11, 13)
        Me.LabelSignatureDate.TabIndex = 515
        Me.LabelSignatureDate.Text = "-"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LabelSignatureKeterangan)
        Me.GroupBox1.Controls.Add(Me.Label64)
        Me.GroupBox1.Controls.Add(Me.TextBoxNoTeleponGC)
        Me.GroupBox1.Controls.Add(Me.Label63)
        Me.GroupBox1.Controls.Add(Me.TextBoxTempatLahirGC)
        Me.GroupBox1.Controls.Add(Me.PictureBoxSignatureGC)
        Me.GroupBox1.Controls.Add(Me.Label62)
        Me.GroupBox1.Controls.Add(Me.Label61)
        Me.GroupBox1.Controls.Add(Me.Label60)
        Me.GroupBox1.Controls.Add(Me.DateTimePickerTglLahirGC)
        Me.GroupBox1.Controls.Add(Me.PanelJenisKelaminGC)
        Me.GroupBox1.Controls.Add(Me.TextBoxNamaGC)
        Me.GroupBox1.Controls.Add(Me.TextBoxHubunganKeluargaGC)
        Me.GroupBox1.Controls.Add(Me.TextBoxAlamatGC)
        Me.GroupBox1.Controls.Add(Me.Label55)
        Me.GroupBox1.Controls.Add(Me.Label57)
        Me.GroupBox1.Controls.Add(Me.Label58)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.Location = New System.Drawing.Point(577, 894)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(330, 606)
        Me.GroupBox1.TabIndex = 504
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "General Consent"
        '
        'LabelSignatureKeterangan
        '
        Me.LabelSignatureKeterangan.AutoSize = True
        Me.LabelSignatureKeterangan.Font = New System.Drawing.Font("Segoe UI Semibold", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSignatureKeterangan.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LabelSignatureKeterangan.Location = New System.Drawing.Point(15, 583)
        Me.LabelSignatureKeterangan.Name = "LabelSignatureKeterangan"
        Me.LabelSignatureKeterangan.Size = New System.Drawing.Size(88, 13)
        Me.LabelSignatureKeterangan.TabIndex = 514
        Me.LabelSignatureKeterangan.Text = "Signature Date :"
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label64.Location = New System.Drawing.Point(15, 440)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(31, 17)
        Me.Label64.TabIndex = 509
        Me.Label64.Text = "TTD"
        '
        'TextBoxNoTeleponGC
        '
        Me.TextBoxNoTeleponGC.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxNoTeleponGC.Location = New System.Drawing.Point(18, 404)
        Me.TextBoxNoTeleponGC.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxNoTeleponGC.Name = "TextBoxNoTeleponGC"
        Me.TextBoxNoTeleponGC.Size = New System.Drawing.Size(300, 25)
        Me.TextBoxNoTeleponGC.TabIndex = 508
        '
        'Label63
        '
        Me.Label63.AutoSize = True
        Me.Label63.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label63.Location = New System.Drawing.Point(15, 383)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(51, 17)
        Me.Label63.TabIndex = 507
        Me.Label63.Text = "No. HP"
        '
        'TextBoxTempatLahirGC
        '
        Me.TextBoxTempatLahirGC.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxTempatLahirGC.Location = New System.Drawing.Point(18, 278)
        Me.TextBoxTempatLahirGC.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxTempatLahirGC.Name = "TextBoxTempatLahirGC"
        Me.TextBoxTempatLahirGC.Size = New System.Drawing.Size(300, 25)
        Me.TextBoxTempatLahirGC.TabIndex = 506
        '
        'PictureBoxSignatureGC
        '
        Me.PictureBoxSignatureGC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBoxSignatureGC.Location = New System.Drawing.Point(18, 460)
        Me.PictureBoxSignatureGC.Name = "PictureBoxSignatureGC"
        Me.PictureBoxSignatureGC.Size = New System.Drawing.Size(200, 120)
        Me.PictureBoxSignatureGC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBoxSignatureGC.TabIndex = 502
        Me.PictureBoxSignatureGC.TabStop = False
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label62.Location = New System.Drawing.Point(15, 257)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(86, 17)
        Me.Label62.TabIndex = 505
        Me.Label62.Text = "Tempat Lahir"
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label61.Location = New System.Drawing.Point(15, 204)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(89, 17)
        Me.Label61.TabIndex = 504
        Me.Label61.Text = "Jenis Kelamin"
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label60.Location = New System.Drawing.Point(15, 147)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(88, 17)
        Me.Label60.TabIndex = 503
        Me.Label60.Text = "Tanggal Lahir"
        '
        'DateTimePickerTglLahirGC
        '
        Me.DateTimePickerTglLahirGC.CustomFormat = "dd-MMM-yyyy"
        Me.DateTimePickerTglLahirGC.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.DateTimePickerTglLahirGC.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerTglLahirGC.Location = New System.Drawing.Point(18, 168)
        Me.DateTimePickerTglLahirGC.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DateTimePickerTglLahirGC.Name = "DateTimePickerTglLahirGC"
        Me.DateTimePickerTglLahirGC.Size = New System.Drawing.Size(150, 25)
        Me.DateTimePickerTglLahirGC.TabIndex = 501
        '
        'PanelJenisKelaminGC
        '
        Me.PanelJenisKelaminGC.BackColor = System.Drawing.Color.Transparent
        Me.PanelJenisKelaminGC.Controls.Add(Me.RadioButtonJenisKelaminLakiGC)
        Me.PanelJenisKelaminGC.Controls.Add(Me.RadioButtonJenisKelaminPerempuanGC)
        Me.PanelJenisKelaminGC.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.PanelJenisKelaminGC.Location = New System.Drawing.Point(18, 224)
        Me.PanelJenisKelaminGC.Name = "PanelJenisKelaminGC"
        Me.PanelJenisKelaminGC.Size = New System.Drawing.Size(203, 25)
        Me.PanelJenisKelaminGC.TabIndex = 502
        '
        'RadioButtonJenisKelaminLakiGC
        '
        Me.RadioButtonJenisKelaminLakiGC.AutoSize = True
        Me.RadioButtonJenisKelaminLakiGC.Checked = True
        Me.RadioButtonJenisKelaminLakiGC.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonJenisKelaminLakiGC.Location = New System.Drawing.Point(5, 2)
        Me.RadioButtonJenisKelaminLakiGC.Name = "RadioButtonJenisKelaminLakiGC"
        Me.RadioButtonJenisKelaminLakiGC.Size = New System.Drawing.Size(72, 21)
        Me.RadioButtonJenisKelaminLakiGC.TabIndex = 245
        Me.RadioButtonJenisKelaminLakiGC.TabStop = True
        Me.RadioButtonJenisKelaminLakiGC.Text = "Laki-laki"
        Me.RadioButtonJenisKelaminLakiGC.UseVisualStyleBackColor = True
        '
        'RadioButtonJenisKelaminPerempuanGC
        '
        Me.RadioButtonJenisKelaminPerempuanGC.AutoSize = True
        Me.RadioButtonJenisKelaminPerempuanGC.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonJenisKelaminPerempuanGC.Location = New System.Drawing.Point(100, 2)
        Me.RadioButtonJenisKelaminPerempuanGC.Name = "RadioButtonJenisKelaminPerempuanGC"
        Me.RadioButtonJenisKelaminPerempuanGC.Size = New System.Drawing.Size(92, 21)
        Me.RadioButtonJenisKelaminPerempuanGC.TabIndex = 246
        Me.RadioButtonJenisKelaminPerempuanGC.Text = "Perempuan"
        Me.RadioButtonJenisKelaminPerempuanGC.UseVisualStyleBackColor = True
        '
        'TextBoxNamaGC
        '
        Me.TextBoxNamaGC.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxNamaGC.Location = New System.Drawing.Point(18, 108)
        Me.TextBoxNamaGC.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxNamaGC.Name = "TextBoxNamaGC"
        Me.TextBoxNamaGC.Size = New System.Drawing.Size(300, 25)
        Me.TextBoxNamaGC.TabIndex = 446
        '
        'TextBoxHubunganKeluargaGC
        '
        Me.TextBoxHubunganKeluargaGC.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxHubunganKeluargaGC.Location = New System.Drawing.Point(18, 51)
        Me.TextBoxHubunganKeluargaGC.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxHubunganKeluargaGC.Name = "TextBoxHubunganKeluargaGC"
        Me.TextBoxHubunganKeluargaGC.Size = New System.Drawing.Size(300, 25)
        Me.TextBoxHubunganKeluargaGC.TabIndex = 445
        '
        'TextBoxAlamatGC
        '
        Me.TextBoxAlamatGC.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBoxAlamatGC.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxAlamatGC.Location = New System.Drawing.Point(18, 333)
        Me.TextBoxAlamatGC.Multiline = True
        Me.TextBoxAlamatGC.Name = "TextBoxAlamatGC"
        Me.TextBoxAlamatGC.Size = New System.Drawing.Size(300, 40)
        Me.TextBoxAlamatGC.TabIndex = 444
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label55.Location = New System.Drawing.Point(15, 313)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(106, 17)
        Me.Label55.TabIndex = 443
        Me.Label55.Text = "Alamat Lengkap"
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label57.Location = New System.Drawing.Point(15, 87)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(44, 17)
        Me.Label57.TabIndex = 441
        Me.Label57.Text = "Nama"
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label58.Location = New System.Drawing.Point(15, 30)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(130, 17)
        Me.Label58.TabIndex = 439
        Me.Label58.Text = "Hubungan Keluarga"
        '
        'GroupBoxWaliPasien
        '
        Me.GroupBoxWaliPasien.Controls.Add(Me.CheckBoxStatusWaliPasien)
        Me.GroupBoxWaliPasien.Controls.Add(Me.TextBoxAlamatDomisiliWali)
        Me.GroupBoxWaliPasien.Controls.Add(Me.TextBoxTempatLahirWali)
        Me.GroupBoxWaliPasien.Controls.Add(Me.TextBoxHubunganKeluargaWali)
        Me.GroupBoxWaliPasien.Controls.Add(Me.TextBoxNoHPWali)
        Me.GroupBoxWaliPasien.Controls.Add(Me.DateTimePickerTglLahirWali)
        Me.GroupBoxWaliPasien.Controls.Add(Me.PanelJenisKelaminWali)
        Me.GroupBoxWaliPasien.Controls.Add(Me.Label31)
        Me.GroupBoxWaliPasien.Controls.Add(Me.Label42)
        Me.GroupBoxWaliPasien.Controls.Add(Me.Label45)
        Me.GroupBoxWaliPasien.Controls.Add(Me.Label51)
        Me.GroupBoxWaliPasien.Controls.Add(Me.TextBoxNamaLengkapWali)
        Me.GroupBoxWaliPasien.Controls.Add(Me.Label52)
        Me.GroupBoxWaliPasien.Controls.Add(Me.Label53)
        Me.GroupBoxWaliPasien.Controls.Add(Me.Label54)
        Me.GroupBoxWaliPasien.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBoxWaliPasien.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxWaliPasien.Location = New System.Drawing.Point(18, 1735)
        Me.GroupBoxWaliPasien.Name = "GroupBoxWaliPasien"
        Me.GroupBoxWaliPasien.Size = New System.Drawing.Size(550, 330)
        Me.GroupBoxWaliPasien.TabIndex = 503
        Me.GroupBoxWaliPasien.TabStop = False
        Me.GroupBoxWaliPasien.Text = "Informasi Wali Pasien"
        '
        'CheckBoxStatusWaliPasien
        '
        Me.CheckBoxStatusWaliPasien.AutoSize = True
        Me.CheckBoxStatusWaliPasien.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxStatusWaliPasien.Location = New System.Drawing.Point(15, 30)
        Me.CheckBoxStatusWaliPasien.Name = "CheckBoxStatusWaliPasien"
        Me.CheckBoxStatusWaliPasien.Size = New System.Drawing.Size(226, 19)
        Me.CheckBoxStatusWaliPasien.TabIndex = 506
        Me.CheckBoxStatusWaliPasien.Text = "Input Informasi Wali Pasien (Jika ada)"
        Me.CheckBoxStatusWaliPasien.UseVisualStyleBackColor = True
        '
        'TextBoxAlamatDomisiliWali
        '
        Me.TextBoxAlamatDomisiliWali.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxAlamatDomisiliWali.Location = New System.Drawing.Point(187, 190)
        Me.TextBoxAlamatDomisiliWali.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxAlamatDomisiliWali.Multiline = True
        Me.TextBoxAlamatDomisiliWali.Name = "TextBoxAlamatDomisiliWali"
        Me.TextBoxAlamatDomisiliWali.Size = New System.Drawing.Size(350, 63)
        Me.TextBoxAlamatDomisiliWali.TabIndex = 505
        '
        'TextBoxTempatLahirWali
        '
        Me.TextBoxTempatLahirWali.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxTempatLahirWali.Location = New System.Drawing.Point(187, 157)
        Me.TextBoxTempatLahirWali.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxTempatLahirWali.Name = "TextBoxTempatLahirWali"
        Me.TextBoxTempatLahirWali.Size = New System.Drawing.Size(350, 25)
        Me.TextBoxTempatLahirWali.TabIndex = 504
        '
        'TextBoxHubunganKeluargaWali
        '
        Me.TextBoxHubunganKeluargaWali.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxHubunganKeluargaWali.Location = New System.Drawing.Point(187, 294)
        Me.TextBoxHubunganKeluargaWali.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxHubunganKeluargaWali.Name = "TextBoxHubunganKeluargaWali"
        Me.TextBoxHubunganKeluargaWali.Size = New System.Drawing.Size(350, 25)
        Me.TextBoxHubunganKeluargaWali.TabIndex = 502
        '
        'TextBoxNoHPWali
        '
        Me.TextBoxNoHPWali.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxNoHPWali.Location = New System.Drawing.Point(187, 261)
        Me.TextBoxNoHPWali.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxNoHPWali.Name = "TextBoxNoHPWali"
        Me.TextBoxNoHPWali.Size = New System.Drawing.Size(350, 25)
        Me.TextBoxNoHPWali.TabIndex = 501
        '
        'DateTimePickerTglLahirWali
        '
        Me.DateTimePickerTglLahirWali.CustomFormat = "dd-MMM-yyyy"
        Me.DateTimePickerTglLahirWali.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.DateTimePickerTglLahirWali.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerTglLahirWali.Location = New System.Drawing.Point(187, 95)
        Me.DateTimePickerTglLahirWali.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DateTimePickerTglLahirWali.Name = "DateTimePickerTglLahirWali"
        Me.DateTimePickerTglLahirWali.Size = New System.Drawing.Size(175, 25)
        Me.DateTimePickerTglLahirWali.TabIndex = 499
        '
        'PanelJenisKelaminWali
        '
        Me.PanelJenisKelaminWali.BackColor = System.Drawing.Color.Transparent
        Me.PanelJenisKelaminWali.Controls.Add(Me.RadioButtonJenisKelaminLakiWali)
        Me.PanelJenisKelaminWali.Controls.Add(Me.RadioButtonJenisKelaminPerempuanWali)
        Me.PanelJenisKelaminWali.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.PanelJenisKelaminWali.Location = New System.Drawing.Point(187, 125)
        Me.PanelJenisKelaminWali.Name = "PanelJenisKelaminWali"
        Me.PanelJenisKelaminWali.Size = New System.Drawing.Size(350, 25)
        Me.PanelJenisKelaminWali.TabIndex = 500
        '
        'RadioButtonJenisKelaminLakiWali
        '
        Me.RadioButtonJenisKelaminLakiWali.AutoSize = True
        Me.RadioButtonJenisKelaminLakiWali.Checked = True
        Me.RadioButtonJenisKelaminLakiWali.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonJenisKelaminLakiWali.Location = New System.Drawing.Point(5, 2)
        Me.RadioButtonJenisKelaminLakiWali.Name = "RadioButtonJenisKelaminLakiWali"
        Me.RadioButtonJenisKelaminLakiWali.Size = New System.Drawing.Size(72, 21)
        Me.RadioButtonJenisKelaminLakiWali.TabIndex = 245
        Me.RadioButtonJenisKelaminLakiWali.TabStop = True
        Me.RadioButtonJenisKelaminLakiWali.Text = "Laki-laki"
        Me.RadioButtonJenisKelaminLakiWali.UseVisualStyleBackColor = True
        '
        'RadioButtonJenisKelaminPerempuanWali
        '
        Me.RadioButtonJenisKelaminPerempuanWali.AutoSize = True
        Me.RadioButtonJenisKelaminPerempuanWali.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonJenisKelaminPerempuanWali.Location = New System.Drawing.Point(100, 2)
        Me.RadioButtonJenisKelaminPerempuanWali.Name = "RadioButtonJenisKelaminPerempuanWali"
        Me.RadioButtonJenisKelaminPerempuanWali.Size = New System.Drawing.Size(92, 21)
        Me.RadioButtonJenisKelaminPerempuanWali.TabIndex = 246
        Me.RadioButtonJenisKelaminPerempuanWali.Text = "Perempuan"
        Me.RadioButtonJenisKelaminPerempuanWali.UseVisualStyleBackColor = True
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(15, 65)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(99, 17)
        Me.Label31.TabIndex = 407
        Me.Label31.Text = "Nama Lengkap"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(15, 160)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(86, 17)
        Me.Label42.TabIndex = 403
        Me.Label42.Text = "Tempat Lahir"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(15, 193)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(106, 17)
        Me.Label45.TabIndex = 405
        Me.Label45.Text = "Alamat Lengkap"
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.Location = New System.Drawing.Point(15, 101)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(88, 17)
        Me.Label51.TabIndex = 409
        Me.Label51.Text = "Tanggal Lahir"
        '
        'TextBoxNamaLengkapWali
        '
        Me.TextBoxNamaLengkapWali.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxNamaLengkapWali.Location = New System.Drawing.Point(187, 62)
        Me.TextBoxNamaLengkapWali.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxNamaLengkapWali.Name = "TextBoxNamaLengkapWali"
        Me.TextBoxNamaLengkapWali.Size = New System.Drawing.Size(350, 25)
        Me.TextBoxNamaLengkapWali.TabIndex = 410
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.Location = New System.Drawing.Point(15, 131)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(89, 17)
        Me.Label52.TabIndex = 411
        Me.Label52.Text = "Jenis Kelamin"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.Location = New System.Drawing.Point(15, 297)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(130, 17)
        Me.Label53.TabIndex = 418
        Me.Label53.Text = "Hubungan Keluarga"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.Location = New System.Drawing.Point(15, 264)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(51, 17)
        Me.Label54.TabIndex = 416
        Me.Label54.Text = "No. HP"
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.TextBoxRiwayatKebiasaan)
        Me.GroupBox9.Controls.Add(Me.Label10)
        Me.GroupBox9.Controls.Add(Me.TextBoxRiwayatPenyakitKeluarga)
        Me.GroupBox9.Controls.Add(Me.Label19)
        Me.GroupBox9.Controls.Add(Me.TextBoxRiwayatPenyakitDahulu)
        Me.GroupBox9.Controls.Add(Me.Label25)
        Me.GroupBox9.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox9.Location = New System.Drawing.Point(577, 628)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(330, 260)
        Me.GroupBox9.TabIndex = 499
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Riwayat Penyakit"
        '
        'TextBoxRiwayatKebiasaan
        '
        Me.TextBoxRiwayatKebiasaan.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBoxRiwayatKebiasaan.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxRiwayatKebiasaan.Location = New System.Drawing.Point(18, 200)
        Me.TextBoxRiwayatKebiasaan.Multiline = True
        Me.TextBoxRiwayatKebiasaan.Name = "TextBoxRiwayatKebiasaan"
        Me.TextBoxRiwayatKebiasaan.Size = New System.Drawing.Size(300, 40)
        Me.TextBoxRiwayatKebiasaan.TabIndex = 444
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(15, 175)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(120, 17)
        Me.Label10.TabIndex = 443
        Me.Label10.Text = "Riwayat Kebiasaan"
        '
        'TextBoxRiwayatPenyakitKeluarga
        '
        Me.TextBoxRiwayatPenyakitKeluarga.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBoxRiwayatPenyakitKeluarga.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxRiwayatPenyakitKeluarga.Location = New System.Drawing.Point(18, 125)
        Me.TextBoxRiwayatPenyakitKeluarga.Multiline = True
        Me.TextBoxRiwayatPenyakitKeluarga.Name = "TextBoxRiwayatPenyakitKeluarga"
        Me.TextBoxRiwayatPenyakitKeluarga.Size = New System.Drawing.Size(300, 40)
        Me.TextBoxRiwayatPenyakitKeluarga.TabIndex = 442
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label19.Location = New System.Drawing.Point(15, 100)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(168, 17)
        Me.Label19.TabIndex = 441
        Me.Label19.Text = "Riwayat Penyakit Keluarga"
        '
        'TextBoxRiwayatPenyakitDahulu
        '
        Me.TextBoxRiwayatPenyakitDahulu.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBoxRiwayatPenyakitDahulu.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxRiwayatPenyakitDahulu.Location = New System.Drawing.Point(18, 55)
        Me.TextBoxRiwayatPenyakitDahulu.Multiline = True
        Me.TextBoxRiwayatPenyakitDahulu.Name = "TextBoxRiwayatPenyakitDahulu"
        Me.TextBoxRiwayatPenyakitDahulu.Size = New System.Drawing.Size(300, 40)
        Me.TextBoxRiwayatPenyakitDahulu.TabIndex = 440
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label25.Location = New System.Drawing.Point(15, 30)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(158, 17)
        Me.Label25.TabIndex = 439
        Me.Label25.Text = "Riwayat Penyakit Dahulu"
        '
        'TextBoxNoRM
        '
        Me.TextBoxNoRM.BackColor = System.Drawing.Color.White
        Me.TextBoxNoRM.Cursor = System.Windows.Forms.Cursors.No
        Me.TextBoxNoRM.Enabled = False
        Me.TextBoxNoRM.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxNoRM.Location = New System.Drawing.Point(205, 27)
        Me.TextBoxNoRM.Name = "TextBoxNoRM"
        Me.TextBoxNoRM.Size = New System.Drawing.Size(310, 25)
        Me.TextBoxNoRM.TabIndex = 494
        Me.TextBoxNoRM.TabStop = False
        Me.TextBoxNoRM.Tag = ""
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label59.Location = New System.Drawing.Point(33, 30)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(57, 17)
        Me.Label59.TabIndex = 493
        Me.Label59.Text = "No eRM"
        '
        'GroupBoxDataLain
        '
        Me.GroupBoxDataLain.Controls.Add(Me.ComboBoxStatusPerkawinan)
        Me.GroupBoxDataLain.Controls.Add(Me.ComboBoxPendidikanTerakhir)
        Me.GroupBoxDataLain.Controls.Add(Me.ComboBoxAgama)
        Me.GroupBoxDataLain.Controls.Add(Me.Label16)
        Me.GroupBoxDataLain.Controls.Add(Me.Label18)
        Me.GroupBoxDataLain.Controls.Add(Me.Label17)
        Me.GroupBoxDataLain.Controls.Add(Me.TextBoxNoTeleponIdentitas)
        Me.GroupBoxDataLain.Controls.Add(Me.Label15)
        Me.GroupBoxDataLain.Controls.Add(Me.TextBoxNoHPIdentitas)
        Me.GroupBoxDataLain.Controls.Add(Me.Panel6)
        Me.GroupBoxDataLain.Controls.Add(Me.Label9)
        Me.GroupBoxDataLain.Controls.Add(Me.TextBoxKetWNA)
        Me.GroupBoxDataLain.Controls.Add(Me.TextBoxEmailIdentitas)
        Me.GroupBoxDataLain.Controls.Add(Me.Label6)
        Me.GroupBoxDataLain.Controls.Add(Me.Label7)
        Me.GroupBoxDataLain.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBoxDataLain.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxDataLain.Location = New System.Drawing.Point(18, 1469)
        Me.GroupBoxDataLain.Name = "GroupBoxDataLain"
        Me.GroupBoxDataLain.Size = New System.Drawing.Size(550, 260)
        Me.GroupBoxDataLain.TabIndex = 492
        Me.GroupBoxDataLain.TabStop = False
        Me.GroupBoxDataLain.Text = "Data Lain-Lain"
        '
        'ComboBoxStatusPerkawinan
        '
        Me.ComboBoxStatusPerkawinan.AutoCompleteCustomSource.AddRange(New String() {"BELUM KAWIN", "KAWIN", "CERAI HIDUP", "CERAI MATI", "-"})
        Me.ComboBoxStatusPerkawinan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxStatusPerkawinan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.ComboBoxStatusPerkawinan.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBoxStatusPerkawinan.FormattingEnabled = True
        Me.ComboBoxStatusPerkawinan.Items.AddRange(New Object() {"BELUM KAWIN", "KAWIN", "CERAI HIDUP", "CERAI MATI", "-"})
        Me.ComboBoxStatusPerkawinan.Location = New System.Drawing.Point(187, 150)
        Me.ComboBoxStatusPerkawinan.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxStatusPerkawinan.Name = "ComboBoxStatusPerkawinan"
        Me.ComboBoxStatusPerkawinan.Size = New System.Drawing.Size(350, 25)
        Me.ComboBoxStatusPerkawinan.TabIndex = 498
        '
        'ComboBoxPendidikanTerakhir
        '
        Me.ComboBoxPendidikanTerakhir.AutoCompleteCustomSource.AddRange(New String() {"TIDAK/BELUM SEKOLAH", "BELUM TAMAT SD/SEDERAJAT", "TAMAT SD/SEDERAJAT", "SLTP/SEDERAJAT", "SLTA/SEDERAJAT", "DIPLOMA I", "DIPLOMA II", "AKADEMI/DIPLOMA III/SARJANA MUDA", "DIPLOMA IV/STRATA I", "STRATA II", "STRATA III", "-"})
        Me.ComboBoxPendidikanTerakhir.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxPendidikanTerakhir.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.ComboBoxPendidikanTerakhir.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBoxPendidikanTerakhir.FormattingEnabled = True
        Me.ComboBoxPendidikanTerakhir.Items.AddRange(New Object() {"TIDAK/BELUM SEKOLAH", "BELUM TAMAT SD/SEDERAJAT", "TAMAT SD/SEDERAJAT", "SLTP/SEDERAJAT", "SLTA/SEDERAJAT", "DIPLOMA I", "DIPLOMA II", "AKADEMI/DIPLOMA III/SARJANA MUDA", "DIPLOMA IV/STRATA I", "STRATA II", "STRATA III", "-"})
        Me.ComboBoxPendidikanTerakhir.Location = New System.Drawing.Point(187, 119)
        Me.ComboBoxPendidikanTerakhir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxPendidikanTerakhir.Name = "ComboBoxPendidikanTerakhir"
        Me.ComboBoxPendidikanTerakhir.Size = New System.Drawing.Size(350, 25)
        Me.ComboBoxPendidikanTerakhir.TabIndex = 497
        '
        'ComboBoxAgama
        '
        Me.ComboBoxAgama.AutoCompleteCustomSource.AddRange(New String() {"ISLAM", "PROTESTAN", "KATOLIK", "HINDU", "BUDDHA", "KHONGHUCU", "-"})
        Me.ComboBoxAgama.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxAgama.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.ComboBoxAgama.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBoxAgama.FormattingEnabled = True
        Me.ComboBoxAgama.Items.AddRange(New Object() {"ISLAM", "PROTESTAN", "KATOLIK", "HINDU", "BUDDHA", "KHONGHUCU", "-"})
        Me.ComboBoxAgama.Location = New System.Drawing.Point(187, 181)
        Me.ComboBoxAgama.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxAgama.Name = "ComboBoxAgama"
        Me.ComboBoxAgama.Size = New System.Drawing.Size(350, 25)
        Me.ComboBoxAgama.TabIndex = 496
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(15, 30)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(137, 17)
        Me.Label16.TabIndex = 407
        Me.Label16.Text = "No. HP (WhatsApp) *"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(15, 123)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(127, 17)
        Me.Label18.TabIndex = 403
        Me.Label18.Text = "Pendidikan Terakhir"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(15, 154)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(120, 17)
        Me.Label17.TabIndex = 405
        Me.Label17.Text = "Status Perkawinan"
        '
        'TextBoxNoTeleponIdentitas
        '
        Me.TextBoxNoTeleponIdentitas.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxNoTeleponIdentitas.Location = New System.Drawing.Point(187, 58)
        Me.TextBoxNoTeleponIdentitas.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxNoTeleponIdentitas.Name = "TextBoxNoTeleponIdentitas"
        Me.TextBoxNoTeleponIdentitas.Size = New System.Drawing.Size(350, 25)
        Me.TextBoxNoTeleponIdentitas.TabIndex = 408
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(15, 61)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(55, 17)
        Me.Label15.TabIndex = 409
        Me.Label15.Text = "Telepon"
        '
        'TextBoxNoHPIdentitas
        '
        Me.TextBoxNoHPIdentitas.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxNoHPIdentitas.Location = New System.Drawing.Point(187, 27)
        Me.TextBoxNoHPIdentitas.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxNoHPIdentitas.Name = "TextBoxNoHPIdentitas"
        Me.TextBoxNoHPIdentitas.Size = New System.Drawing.Size(350, 25)
        Me.TextBoxNoHPIdentitas.TabIndex = 410
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Transparent
        Me.Panel6.Controls.Add(Me.RadioButtonWNI)
        Me.Panel6.Controls.Add(Me.RadioButtonWNA)
        Me.Panel6.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Panel6.Location = New System.Drawing.Point(187, 211)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(146, 25)
        Me.Panel6.TabIndex = 420
        '
        'RadioButtonWNI
        '
        Me.RadioButtonWNI.AutoSize = True
        Me.RadioButtonWNI.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonWNI.Location = New System.Drawing.Point(3, 1)
        Me.RadioButtonWNI.Name = "RadioButtonWNI"
        Me.RadioButtonWNI.Size = New System.Drawing.Size(51, 21)
        Me.RadioButtonWNI.TabIndex = 245
        Me.RadioButtonWNI.TabStop = True
        Me.RadioButtonWNI.Text = "WNI"
        Me.RadioButtonWNI.UseVisualStyleBackColor = True
        '
        'RadioButtonWNA
        '
        Me.RadioButtonWNA.AutoSize = True
        Me.RadioButtonWNA.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonWNA.Location = New System.Drawing.Point(82, 1)
        Me.RadioButtonWNA.Name = "RadioButtonWNA"
        Me.RadioButtonWNA.Size = New System.Drawing.Size(56, 21)
        Me.RadioButtonWNA.TabIndex = 246
        Me.RadioButtonWNA.TabStop = True
        Me.RadioButtonWNA.Text = "WNA"
        Me.RadioButtonWNA.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(15, 92)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 17)
        Me.Label9.TabIndex = 411
        Me.Label9.Text = "Email"
        '
        'TextBoxKetWNA
        '
        Me.TextBoxKetWNA.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxKetWNA.Location = New System.Drawing.Point(339, 211)
        Me.TextBoxKetWNA.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxKetWNA.Name = "TextBoxKetWNA"
        Me.TextBoxKetWNA.Size = New System.Drawing.Size(198, 25)
        Me.TextBoxKetWNA.TabIndex = 419
        '
        'TextBoxEmailIdentitas
        '
        Me.TextBoxEmailIdentitas.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxEmailIdentitas.Location = New System.Drawing.Point(187, 89)
        Me.TextBoxEmailIdentitas.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxEmailIdentitas.Name = "TextBoxEmailIdentitas"
        Me.TextBoxEmailIdentitas.Size = New System.Drawing.Size(350, 25)
        Me.TextBoxEmailIdentitas.TabIndex = 412
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(15, 216)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(117, 17)
        Me.Label6.TabIndex = 418
        Me.Label6.Text = "Kewarganegaraan"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(15, 185)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 17)
        Me.Label7.TabIndex = 416
        Me.Label7.Text = "Agama"
        '
        'GroupBoxAlamatDomisili
        '
        Me.GroupBoxAlamatDomisili.Controls.Add(Me.ComboBoxKelurahanDomisili)
        Me.GroupBoxAlamatDomisili.Controls.Add(Me.Label70)
        Me.GroupBoxAlamatDomisili.Controls.Add(Me.ComboBoxKecamatanDomisili)
        Me.GroupBoxAlamatDomisili.Controls.Add(Me.Label69)
        Me.GroupBoxAlamatDomisili.Controls.Add(Me.ComboBoxKabupatenDomisili)
        Me.GroupBoxAlamatDomisili.Controls.Add(Me.Label68)
        Me.GroupBoxAlamatDomisili.Controls.Add(Me.ComboBoxProvinsiDomisili)
        Me.GroupBoxAlamatDomisili.Controls.Add(Me.Label67)
        Me.GroupBoxAlamatDomisili.Controls.Add(Me.Label24)
        Me.GroupBoxAlamatDomisili.Controls.Add(Me.TextBoxAlamatDomisili)
        Me.GroupBoxAlamatDomisili.Controls.Add(Me.TextBoxRTDomisili)
        Me.GroupBoxAlamatDomisili.Controls.Add(Me.Label28)
        Me.GroupBoxAlamatDomisili.Controls.Add(Me.TextBoxRWDomisili)
        Me.GroupBoxAlamatDomisili.Controls.Add(Me.TextBoxKodePosDomisili)
        Me.GroupBoxAlamatDomisili.Controls.Add(Me.Label23)
        Me.GroupBoxAlamatDomisili.Controls.Add(Me.Label20)
        Me.GroupBoxAlamatDomisili.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBoxAlamatDomisili.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxAlamatDomisili.Location = New System.Drawing.Point(18, 827)
        Me.GroupBoxAlamatDomisili.Name = "GroupBoxAlamatDomisili"
        Me.GroupBoxAlamatDomisili.Size = New System.Drawing.Size(550, 300)
        Me.GroupBoxAlamatDomisili.TabIndex = 491
        Me.GroupBoxAlamatDomisili.TabStop = False
        Me.GroupBoxAlamatDomisili.Text = "Alamat Domisili"
        '
        'ComboBoxKelurahanDomisili
        '
        Me.ComboBoxKelurahanDomisili.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxKelurahanDomisili.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.ComboBoxKelurahanDomisili.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBoxKelurahanDomisili.FormattingEnabled = True
        Me.ComboBoxKelurahanDomisili.Location = New System.Drawing.Point(187, 197)
        Me.ComboBoxKelurahanDomisili.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxKelurahanDomisili.Name = "ComboBoxKelurahanDomisili"
        Me.ComboBoxKelurahanDomisili.Size = New System.Drawing.Size(350, 25)
        Me.ComboBoxKelurahanDomisili.TabIndex = 504
        '
        'Label70
        '
        Me.Label70.AutoSize = True
        Me.Label70.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label70.Location = New System.Drawing.Point(15, 200)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(103, 17)
        Me.Label70.TabIndex = 503
        Me.Label70.Text = "Kelurahan/Desa"
        '
        'ComboBoxKecamatanDomisili
        '
        Me.ComboBoxKecamatanDomisili.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxKecamatanDomisili.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.ComboBoxKecamatanDomisili.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBoxKecamatanDomisili.FormattingEnabled = True
        Me.ComboBoxKecamatanDomisili.Location = New System.Drawing.Point(187, 164)
        Me.ComboBoxKecamatanDomisili.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxKecamatanDomisili.Name = "ComboBoxKecamatanDomisili"
        Me.ComboBoxKecamatanDomisili.Size = New System.Drawing.Size(350, 25)
        Me.ComboBoxKecamatanDomisili.TabIndex = 502
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label69.Location = New System.Drawing.Point(15, 167)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(75, 17)
        Me.Label69.TabIndex = 501
        Me.Label69.Text = "Kecamatan"
        '
        'ComboBoxKabupatenDomisili
        '
        Me.ComboBoxKabupatenDomisili.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxKabupatenDomisili.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.ComboBoxKabupatenDomisili.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBoxKabupatenDomisili.FormattingEnabled = True
        Me.ComboBoxKabupatenDomisili.Location = New System.Drawing.Point(187, 131)
        Me.ComboBoxKabupatenDomisili.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxKabupatenDomisili.Name = "ComboBoxKabupatenDomisili"
        Me.ComboBoxKabupatenDomisili.Size = New System.Drawing.Size(350, 25)
        Me.ComboBoxKabupatenDomisili.TabIndex = 500
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label68.Location = New System.Drawing.Point(15, 134)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(107, 17)
        Me.Label68.TabIndex = 499
        Me.Label68.Text = "Kota/Kabupaten"
        '
        'ComboBoxProvinsiDomisili
        '
        Me.ComboBoxProvinsiDomisili.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxProvinsiDomisili.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.ComboBoxProvinsiDomisili.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBoxProvinsiDomisili.FormattingEnabled = True
        Me.ComboBoxProvinsiDomisili.Location = New System.Drawing.Point(187, 98)
        Me.ComboBoxProvinsiDomisili.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxProvinsiDomisili.Name = "ComboBoxProvinsiDomisili"
        Me.ComboBoxProvinsiDomisili.Size = New System.Drawing.Size(350, 25)
        Me.ComboBoxProvinsiDomisili.TabIndex = 498
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label67.Location = New System.Drawing.Point(15, 101)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(56, 17)
        Me.Label67.TabIndex = 489
        Me.Label67.Text = "Provinsi"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(15, 32)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(112, 17)
        Me.Label24.TabIndex = 385
        Me.Label24.Text = "Alamat Domisili *"
        '
        'TextBoxAlamatDomisili
        '
        Me.TextBoxAlamatDomisili.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxAlamatDomisili.Location = New System.Drawing.Point(187, 29)
        Me.TextBoxAlamatDomisili.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxAlamatDomisili.Multiline = True
        Me.TextBoxAlamatDomisili.Name = "TextBoxAlamatDomisili"
        Me.TextBoxAlamatDomisili.Size = New System.Drawing.Size(350, 63)
        Me.TextBoxAlamatDomisili.TabIndex = 375
        '
        'TextBoxRTDomisili
        '
        Me.TextBoxRTDomisili.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxRTDomisili.Location = New System.Drawing.Point(187, 230)
        Me.TextBoxRTDomisili.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxRTDomisili.Name = "TextBoxRTDomisili"
        Me.TextBoxRTDomisili.Size = New System.Drawing.Size(75, 25)
        Me.TextBoxRTDomisili.TabIndex = 377
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(268, 231)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(13, 17)
        Me.Label28.TabIndex = 378
        Me.Label28.Text = "/"
        '
        'TextBoxRWDomisili
        '
        Me.TextBoxRWDomisili.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxRWDomisili.Location = New System.Drawing.Point(287, 230)
        Me.TextBoxRWDomisili.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxRWDomisili.Name = "TextBoxRWDomisili"
        Me.TextBoxRWDomisili.Size = New System.Drawing.Size(75, 25)
        Me.TextBoxRWDomisili.TabIndex = 379
        '
        'TextBoxKodePosDomisili
        '
        Me.TextBoxKodePosDomisili.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxKodePosDomisili.Location = New System.Drawing.Point(187, 263)
        Me.TextBoxKodePosDomisili.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxKodePosDomisili.Name = "TextBoxKodePosDomisili"
        Me.TextBoxKodePosDomisili.Size = New System.Drawing.Size(350, 25)
        Me.TextBoxKodePosDomisili.TabIndex = 383
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(15, 233)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(49, 17)
        Me.Label23.TabIndex = 387
        Me.Label23.Text = "RT/RW"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(15, 264)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(65, 17)
        Me.Label20.TabIndex = 393
        Me.Label20.Text = "Kode Pos"
        '
        'GroupBoxAlamatKTP
        '
        Me.GroupBoxAlamatKTP.Controls.Add(Me.ComboBoxKelurahanKTP)
        Me.GroupBoxAlamatKTP.Controls.Add(Me.Label72)
        Me.GroupBoxAlamatKTP.Controls.Add(Me.ComboBoxKecamatanKTP)
        Me.GroupBoxAlamatKTP.Controls.Add(Me.Label73)
        Me.GroupBoxAlamatKTP.Controls.Add(Me.ComboBoxKabupatenKTP)
        Me.GroupBoxAlamatKTP.Controls.Add(Me.Label74)
        Me.GroupBoxAlamatKTP.Controls.Add(Me.ComboBoxProvinsiKTP)
        Me.GroupBoxAlamatKTP.Controls.Add(Me.Label75)
        Me.GroupBoxAlamatKTP.Controls.Add(Me.Label30)
        Me.GroupBoxAlamatKTP.Controls.Add(Me.Label29)
        Me.GroupBoxAlamatKTP.Controls.Add(Me.Label26)
        Me.GroupBoxAlamatKTP.Controls.Add(Me.TextBoxAlamatKTP)
        Me.GroupBoxAlamatKTP.Controls.Add(Me.TextBoxRTKTP)
        Me.GroupBoxAlamatKTP.Controls.Add(Me.Label22)
        Me.GroupBoxAlamatKTP.Controls.Add(Me.TextBoxRWKTP)
        Me.GroupBoxAlamatKTP.Controls.Add(Me.TextBoxKodePosKTP)
        Me.GroupBoxAlamatKTP.Controls.Add(Me.CheckBoxCopyAlamatDomisili)
        Me.GroupBoxAlamatKTP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBoxAlamatKTP.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxAlamatKTP.Location = New System.Drawing.Point(18, 1133)
        Me.GroupBoxAlamatKTP.Name = "GroupBoxAlamatKTP"
        Me.GroupBoxAlamatKTP.Size = New System.Drawing.Size(550, 330)
        Me.GroupBoxAlamatKTP.TabIndex = 490
        Me.GroupBoxAlamatKTP.TabStop = False
        Me.GroupBoxAlamatKTP.Text = "Alamat Berdasarkan KTP"
        '
        'ComboBoxKelurahanKTP
        '
        Me.ComboBoxKelurahanKTP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxKelurahanKTP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.ComboBoxKelurahanKTP.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBoxKelurahanKTP.FormattingEnabled = True
        Me.ComboBoxKelurahanKTP.Location = New System.Drawing.Point(187, 229)
        Me.ComboBoxKelurahanKTP.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxKelurahanKTP.Name = "ComboBoxKelurahanKTP"
        Me.ComboBoxKelurahanKTP.Size = New System.Drawing.Size(350, 25)
        Me.ComboBoxKelurahanKTP.TabIndex = 512
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label72.Location = New System.Drawing.Point(15, 232)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(103, 17)
        Me.Label72.TabIndex = 511
        Me.Label72.Text = "Kelurahan/Desa"
        '
        'ComboBoxKecamatanKTP
        '
        Me.ComboBoxKecamatanKTP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxKecamatanKTP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.ComboBoxKecamatanKTP.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBoxKecamatanKTP.FormattingEnabled = True
        Me.ComboBoxKecamatanKTP.Location = New System.Drawing.Point(187, 196)
        Me.ComboBoxKecamatanKTP.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxKecamatanKTP.Name = "ComboBoxKecamatanKTP"
        Me.ComboBoxKecamatanKTP.Size = New System.Drawing.Size(350, 25)
        Me.ComboBoxKecamatanKTP.TabIndex = 510
        '
        'Label73
        '
        Me.Label73.AutoSize = True
        Me.Label73.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label73.Location = New System.Drawing.Point(15, 199)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(75, 17)
        Me.Label73.TabIndex = 509
        Me.Label73.Text = "Kecamatan"
        '
        'ComboBoxKabupatenKTP
        '
        Me.ComboBoxKabupatenKTP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxKabupatenKTP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.ComboBoxKabupatenKTP.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBoxKabupatenKTP.FormattingEnabled = True
        Me.ComboBoxKabupatenKTP.Location = New System.Drawing.Point(187, 163)
        Me.ComboBoxKabupatenKTP.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxKabupatenKTP.Name = "ComboBoxKabupatenKTP"
        Me.ComboBoxKabupatenKTP.Size = New System.Drawing.Size(350, 25)
        Me.ComboBoxKabupatenKTP.TabIndex = 508
        '
        'Label74
        '
        Me.Label74.AutoSize = True
        Me.Label74.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label74.Location = New System.Drawing.Point(15, 166)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(107, 17)
        Me.Label74.TabIndex = 507
        Me.Label74.Text = "Kota/Kabupaten"
        '
        'ComboBoxProvinsiKTP
        '
        Me.ComboBoxProvinsiKTP.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxProvinsiKTP.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.ComboBoxProvinsiKTP.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBoxProvinsiKTP.FormattingEnabled = True
        Me.ComboBoxProvinsiKTP.Location = New System.Drawing.Point(187, 130)
        Me.ComboBoxProvinsiKTP.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxProvinsiKTP.Name = "ComboBoxProvinsiKTP"
        Me.ComboBoxProvinsiKTP.Size = New System.Drawing.Size(350, 25)
        Me.ComboBoxProvinsiKTP.TabIndex = 506
        '
        'Label75
        '
        Me.Label75.AutoSize = True
        Me.Label75.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label75.Location = New System.Drawing.Point(15, 133)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(56, 17)
        Me.Label75.TabIndex = 505
        Me.Label75.Text = "Provinsi"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(15, 62)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(78, 17)
        Me.Label30.TabIndex = 374
        Me.Label30.Text = "Alamat KTP"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(15, 263)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(49, 17)
        Me.Label29.TabIndex = 376
        Me.Label29.Text = "RT/RW"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(15, 294)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(65, 17)
        Me.Label26.TabIndex = 382
        Me.Label26.Text = "Kode Pos"
        '
        'TextBoxAlamatKTP
        '
        Me.TextBoxAlamatKTP.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxAlamatKTP.Location = New System.Drawing.Point(187, 59)
        Me.TextBoxAlamatKTP.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxAlamatKTP.Multiline = True
        Me.TextBoxAlamatKTP.Name = "TextBoxAlamatKTP"
        Me.TextBoxAlamatKTP.Size = New System.Drawing.Size(350, 63)
        Me.TextBoxAlamatKTP.TabIndex = 386
        '
        'TextBoxRTKTP
        '
        Me.TextBoxRTKTP.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxRTKTP.Location = New System.Drawing.Point(187, 262)
        Me.TextBoxRTKTP.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxRTKTP.Name = "TextBoxRTKTP"
        Me.TextBoxRTKTP.Size = New System.Drawing.Size(75, 25)
        Me.TextBoxRTKTP.TabIndex = 388
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(268, 263)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(13, 17)
        Me.Label22.TabIndex = 389
        Me.Label22.Text = "/"
        '
        'TextBoxRWKTP
        '
        Me.TextBoxRWKTP.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxRWKTP.Location = New System.Drawing.Point(287, 262)
        Me.TextBoxRWKTP.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxRWKTP.Name = "TextBoxRWKTP"
        Me.TextBoxRWKTP.Size = New System.Drawing.Size(75, 25)
        Me.TextBoxRWKTP.TabIndex = 390
        '
        'TextBoxKodePosKTP
        '
        Me.TextBoxKodePosKTP.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxKodePosKTP.Location = New System.Drawing.Point(187, 295)
        Me.TextBoxKodePosKTP.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxKodePosKTP.Name = "TextBoxKodePosKTP"
        Me.TextBoxKodePosKTP.Size = New System.Drawing.Size(350, 25)
        Me.TextBoxKodePosKTP.TabIndex = 394
        '
        'CheckBoxCopyAlamatDomisili
        '
        Me.CheckBoxCopyAlamatDomisili.AutoSize = True
        Me.CheckBoxCopyAlamatDomisili.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxCopyAlamatDomisili.Location = New System.Drawing.Point(15, 31)
        Me.CheckBoxCopyAlamatDomisili.Name = "CheckBoxCopyAlamatDomisili"
        Me.CheckBoxCopyAlamatDomisili.Size = New System.Drawing.Size(146, 19)
        Me.CheckBoxCopyAlamatDomisili.TabIndex = 395
        Me.CheckBoxCopyAlamatDomisili.Text = "Sama dengan Domisili"
        Me.CheckBoxCopyAlamatDomisili.UseVisualStyleBackColor = True
        '
        'GroupBoxBiodataDiri
        '
        Me.GroupBoxBiodataDiri.Controls.Add(Me.TextBoxNomorCahaya)
        Me.GroupBoxBiodataDiri.Controls.Add(Me.ComboBoxStatusKeluarga)
        Me.GroupBoxBiodataDiri.Controls.Add(Me.Label8)
        Me.GroupBoxBiodataDiri.Controls.Add(Me.Label39)
        Me.GroupBoxBiodataDiri.Controls.Add(Me.TextBoxPRB)
        Me.GroupBoxBiodataDiri.Controls.Add(Me.Label11)
        Me.GroupBoxBiodataDiri.Controls.Add(Me.TextBoxNamaLengkapIdentitas)
        Me.GroupBoxBiodataDiri.Controls.Add(Me.TextBoxProlanis)
        Me.GroupBoxBiodataDiri.Controls.Add(Me.Label37)
        Me.GroupBoxBiodataDiri.Controls.Add(Me.Label43)
        Me.GroupBoxBiodataDiri.Controls.Add(Me.TextBoxTempatLahir)
        Me.GroupBoxBiodataDiri.Controls.Add(Me.Label36)
        Me.GroupBoxBiodataDiri.Controls.Add(Me.DateTimePickerTglLahir)
        Me.GroupBoxBiodataDiri.Controls.Add(Me.TextBoxNomorJPK)
        Me.GroupBoxBiodataDiri.Controls.Add(Me.Label35)
        Me.GroupBoxBiodataDiri.Controls.Add(Me.Label48)
        Me.GroupBoxBiodataDiri.Controls.Add(Me.PanelJenisKelaminPasien)
        Me.GroupBoxBiodataDiri.Controls.Add(Me.TextBoxNomorInhealth)
        Me.GroupBoxBiodataDiri.Controls.Add(Me.Label34)
        Me.GroupBoxBiodataDiri.Controls.Add(Me.Label47)
        Me.GroupBoxBiodataDiri.Controls.Add(Me.ComboBoxGolDarahIdentitas)
        Me.GroupBoxBiodataDiri.Controls.Add(Me.TextBoxNomorNIP)
        Me.GroupBoxBiodataDiri.Controls.Add(Me.Label33)
        Me.GroupBoxBiodataDiri.Controls.Add(Me.Label46)
        Me.GroupBoxBiodataDiri.Controls.Add(Me.Label32)
        Me.GroupBoxBiodataDiri.Controls.Add(Me.TextBoxPekerjaan)
        Me.GroupBoxBiodataDiri.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBoxBiodataDiri.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxBiodataDiri.Location = New System.Drawing.Point(18, 375)
        Me.GroupBoxBiodataDiri.Name = "GroupBoxBiodataDiri"
        Me.GroupBoxBiodataDiri.Size = New System.Drawing.Size(550, 446)
        Me.GroupBoxBiodataDiri.TabIndex = 489
        Me.GroupBoxBiodataDiri.TabStop = False
        Me.GroupBoxBiodataDiri.Text = "Biodata Diri"
        '
        'TextBoxNomorCahaya
        '
        Me.TextBoxNomorCahaya.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxNomorCahaya.Location = New System.Drawing.Point(187, 402)
        Me.TextBoxNomorCahaya.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxNomorCahaya.Name = "TextBoxNomorCahaya"
        Me.TextBoxNomorCahaya.Size = New System.Drawing.Size(350, 25)
        Me.TextBoxNomorCahaya.TabIndex = 497
        '
        'ComboBoxStatusKeluarga
        '
        Me.ComboBoxStatusKeluarga.AutoCompleteCustomSource.AddRange(New String() {"KEPALA KELUARGA", "SUAMI", "ISTRI", "ANAK", "MENANTU", "CUCU", "ORANG TUA", "MERTUA", "FAMILI LAIN", "PEMBANTU", "-"})
        Me.ComboBoxStatusKeluarga.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxStatusKeluarga.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.ComboBoxStatusKeluarga.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBoxStatusKeluarga.FormattingEnabled = True
        Me.ComboBoxStatusKeluarga.Items.AddRange(New Object() {"KEPALA KELUARGA", "SUAMI", "ISTRI", "ANAK", "MENANTU", "CUCU", "ORANG TUA", "MERTUA", "FAMILI LAIN", "PEMBANTU", "-"})
        Me.ComboBoxStatusKeluarga.Location = New System.Drawing.Point(187, 245)
        Me.ComboBoxStatusKeluarga.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxStatusKeluarga.Name = "ComboBoxStatusKeluarga"
        Me.ComboBoxStatusKeluarga.Size = New System.Drawing.Size(350, 25)
        Me.ComboBoxStatusKeluarga.TabIndex = 498
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(15, 405)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 17)
        Me.Label8.TabIndex = 496
        Me.Label8.Text = "No Cahaya"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(15, 30)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(109, 17)
        Me.Label39.TabIndex = 197
        Me.Label39.Text = "Nama Lengkap *"
        '
        'TextBoxPRB
        '
        Me.TextBoxPRB.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBoxPRB.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxPRB.Location = New System.Drawing.Point(187, 91)
        Me.TextBoxPRB.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxPRB.Name = "TextBoxPRB"
        Me.TextBoxPRB.Size = New System.Drawing.Size(350, 25)
        Me.TextBoxPRB.TabIndex = 429
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(15, 95)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(32, 17)
        Me.Label11.TabIndex = 428
        Me.Label11.Text = "PRB"
        '
        'TextBoxNamaLengkapIdentitas
        '
        Me.TextBoxNamaLengkapIdentitas.BackColor = System.Drawing.Color.White
        Me.TextBoxNamaLengkapIdentitas.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxNamaLengkapIdentitas.Location = New System.Drawing.Point(187, 27)
        Me.TextBoxNamaLengkapIdentitas.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxNamaLengkapIdentitas.Name = "TextBoxNamaLengkapIdentitas"
        Me.TextBoxNamaLengkapIdentitas.Size = New System.Drawing.Size(350, 25)
        Me.TextBoxNamaLengkapIdentitas.TabIndex = 198
        '
        'TextBoxProlanis
        '
        Me.TextBoxProlanis.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBoxProlanis.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxProlanis.Location = New System.Drawing.Point(187, 59)
        Me.TextBoxProlanis.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxProlanis.Name = "TextBoxProlanis"
        Me.TextBoxProlanis.Size = New System.Drawing.Size(350, 25)
        Me.TextBoxProlanis.TabIndex = 475
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(15, 127)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(86, 17)
        Me.Label37.TabIndex = 199
        Me.Label37.Text = "Tempat Lahir"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(15, 63)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(56, 17)
        Me.Label43.TabIndex = 474
        Me.Label43.Text = "Prolanis"
        '
        'TextBoxTempatLahir
        '
        Me.TextBoxTempatLahir.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxTempatLahir.Location = New System.Drawing.Point(187, 124)
        Me.TextBoxTempatLahir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxTempatLahir.Name = "TextBoxTempatLahir"
        Me.TextBoxTempatLahir.Size = New System.Drawing.Size(350, 25)
        Me.TextBoxTempatLahir.TabIndex = 200
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(15, 160)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(98, 17)
        Me.Label36.TabIndex = 201
        Me.Label36.Text = "Tanggal Lahir *"
        '
        'DateTimePickerTglLahir
        '
        Me.DateTimePickerTglLahir.CustomFormat = "dd-MMM-yyyy"
        Me.DateTimePickerTglLahir.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.DateTimePickerTglLahir.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerTglLahir.Location = New System.Drawing.Point(187, 154)
        Me.DateTimePickerTglLahir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DateTimePickerTglLahir.Name = "DateTimePickerTglLahir"
        Me.DateTimePickerTglLahir.Size = New System.Drawing.Size(175, 25)
        Me.DateTimePickerTglLahir.TabIndex = 203
        '
        'TextBoxNomorJPK
        '
        Me.TextBoxNomorJPK.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxNomorJPK.Location = New System.Drawing.Point(187, 369)
        Me.TextBoxNomorJPK.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxNomorJPK.Name = "TextBoxNomorJPK"
        Me.TextBoxNomorJPK.Size = New System.Drawing.Size(350, 25)
        Me.TextBoxNomorJPK.TabIndex = 483
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(15, 189)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(99, 17)
        Me.Label35.TabIndex = 204
        Me.Label35.Text = "Jenis Kelamin *"
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.Location = New System.Drawing.Point(15, 372)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(88, 17)
        Me.Label48.TabIndex = 482
        Me.Label48.Text = "No Kartu JPK"
        '
        'PanelJenisKelaminPasien
        '
        Me.PanelJenisKelaminPasien.BackColor = System.Drawing.Color.Transparent
        Me.PanelJenisKelaminPasien.Controls.Add(Me.RadioButtonJenisKelaminLakiIdentitas)
        Me.PanelJenisKelaminPasien.Controls.Add(Me.RadioButtonJenisKelaminPerempuanIdentitas)
        Me.PanelJenisKelaminPasien.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.PanelJenisKelaminPasien.Location = New System.Drawing.Point(187, 184)
        Me.PanelJenisKelaminPasien.Name = "PanelJenisKelaminPasien"
        Me.PanelJenisKelaminPasien.Size = New System.Drawing.Size(350, 25)
        Me.PanelJenisKelaminPasien.TabIndex = 366
        '
        'RadioButtonJenisKelaminLakiIdentitas
        '
        Me.RadioButtonJenisKelaminLakiIdentitas.AutoSize = True
        Me.RadioButtonJenisKelaminLakiIdentitas.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonJenisKelaminLakiIdentitas.Location = New System.Drawing.Point(5, 2)
        Me.RadioButtonJenisKelaminLakiIdentitas.Name = "RadioButtonJenisKelaminLakiIdentitas"
        Me.RadioButtonJenisKelaminLakiIdentitas.Size = New System.Drawing.Size(72, 21)
        Me.RadioButtonJenisKelaminLakiIdentitas.TabIndex = 245
        Me.RadioButtonJenisKelaminLakiIdentitas.TabStop = True
        Me.RadioButtonJenisKelaminLakiIdentitas.Text = "Laki-laki"
        Me.RadioButtonJenisKelaminLakiIdentitas.UseVisualStyleBackColor = True
        '
        'RadioButtonJenisKelaminPerempuanIdentitas
        '
        Me.RadioButtonJenisKelaminPerempuanIdentitas.AutoSize = True
        Me.RadioButtonJenisKelaminPerempuanIdentitas.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonJenisKelaminPerempuanIdentitas.Location = New System.Drawing.Point(100, 2)
        Me.RadioButtonJenisKelaminPerempuanIdentitas.Name = "RadioButtonJenisKelaminPerempuanIdentitas"
        Me.RadioButtonJenisKelaminPerempuanIdentitas.Size = New System.Drawing.Size(92, 21)
        Me.RadioButtonJenisKelaminPerempuanIdentitas.TabIndex = 246
        Me.RadioButtonJenisKelaminPerempuanIdentitas.TabStop = True
        Me.RadioButtonJenisKelaminPerempuanIdentitas.Text = "Perempuan"
        Me.RadioButtonJenisKelaminPerempuanIdentitas.UseVisualStyleBackColor = True
        '
        'TextBoxNomorInhealth
        '
        Me.TextBoxNomorInhealth.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxNomorInhealth.Location = New System.Drawing.Point(187, 338)
        Me.TextBoxNomorInhealth.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxNomorInhealth.Name = "TextBoxNomorInhealth"
        Me.TextBoxNomorInhealth.Size = New System.Drawing.Size(350, 25)
        Me.TextBoxNomorInhealth.TabIndex = 481
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(15, 217)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(107, 17)
        Me.Label34.TabIndex = 367
        Me.Label34.Text = "Golongan Darah"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.Location = New System.Drawing.Point(15, 341)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(117, 17)
        Me.Label47.TabIndex = 480
        Me.Label47.Text = "No Kartu Inhealth"
        '
        'ComboBoxGolDarahIdentitas
        '
        Me.ComboBoxGolDarahIdentitas.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxGolDarahIdentitas.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxGolDarahIdentitas.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBoxGolDarahIdentitas.FormattingEnabled = True
        Me.ComboBoxGolDarahIdentitas.Items.AddRange(New Object() {"A", "B", "AB", "O", "-"})
        Me.ComboBoxGolDarahIdentitas.Location = New System.Drawing.Point(187, 214)
        Me.ComboBoxGolDarahIdentitas.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxGolDarahIdentitas.Name = "ComboBoxGolDarahIdentitas"
        Me.ComboBoxGolDarahIdentitas.Size = New System.Drawing.Size(75, 25)
        Me.ComboBoxGolDarahIdentitas.TabIndex = 368
        '
        'TextBoxNomorNIP
        '
        Me.TextBoxNomorNIP.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxNomorNIP.Location = New System.Drawing.Point(187, 307)
        Me.TextBoxNomorNIP.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxNomorNIP.Name = "TextBoxNomorNIP"
        Me.TextBoxNomorNIP.Size = New System.Drawing.Size(350, 25)
        Me.TextBoxNomorNIP.TabIndex = 479
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(15, 248)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(103, 17)
        Me.Label33.TabIndex = 369
        Me.Label33.Text = "Status Keluarga"
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.Location = New System.Drawing.Point(15, 310)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(52, 17)
        Me.Label46.TabIndex = 478
        Me.Label46.Text = "No NIP"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(15, 279)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(67, 17)
        Me.Label32.TabIndex = 371
        Me.Label32.Text = "Pekerjaan"
        '
        'TextBoxPekerjaan
        '
        Me.TextBoxPekerjaan.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxPekerjaan.Location = New System.Drawing.Point(187, 276)
        Me.TextBoxPekerjaan.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxPekerjaan.Name = "TextBoxPekerjaan"
        Me.TextBoxPekerjaan.Size = New System.Drawing.Size(350, 25)
        Me.TextBoxPekerjaan.TabIndex = 372
        '
        'GroupBoxJKN
        '
        Me.GroupBoxJKN.Controls.Add(Me.TextBoxFaskesAktif)
        Me.GroupBoxJKN.Controls.Add(Me.Label40)
        Me.GroupBoxJKN.Controls.Add(Me.TextBoxFKTP)
        Me.GroupBoxJKN.Controls.Add(Me.TextBoxNomorKIS)
        Me.GroupBoxJKN.Controls.Add(Me.Label5)
        Me.GroupBoxJKN.Controls.Add(Me.ButtonCekKIS)
        Me.GroupBoxJKN.Controls.Add(Me.TextBoxStatusPeserta)
        Me.GroupBoxJKN.Controls.Add(Me.TextBoxStatusAktif)
        Me.GroupBoxJKN.Controls.Add(Me.Label4)
        Me.GroupBoxJKN.Controls.Add(Me.Label14)
        Me.GroupBoxJKN.Controls.Add(Me.Label12)
        Me.GroupBoxJKN.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBoxJKN.Location = New System.Drawing.Point(18, 180)
        Me.GroupBoxJKN.Name = "GroupBoxJKN"
        Me.GroupBoxJKN.Size = New System.Drawing.Size(550, 189)
        Me.GroupBoxJKN.TabIndex = 476
        Me.GroupBoxJKN.TabStop = False
        Me.GroupBoxJKN.Text = "JKN-KIS"
        '
        'TextBoxFaskesAktif
        '
        Me.TextBoxFaskesAktif.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBoxFaskesAktif.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxFaskesAktif.Location = New System.Drawing.Point(187, 59)
        Me.TextBoxFaskesAktif.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxFaskesAktif.Name = "TextBoxFaskesAktif"
        Me.TextBoxFaskesAktif.ReadOnly = True
        Me.TextBoxFaskesAktif.Size = New System.Drawing.Size(350, 25)
        Me.TextBoxFaskesAktif.TabIndex = 476
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(15, 30)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(102, 17)
        Me.Label40.TabIndex = 195
        Me.Label40.Text = "Nomor JKN-KIS"
        '
        'TextBoxFKTP
        '
        Me.TextBoxFKTP.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBoxFKTP.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxFKTP.Location = New System.Drawing.Point(187, 155)
        Me.TextBoxFKTP.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxFKTP.Name = "TextBoxFKTP"
        Me.TextBoxFKTP.ReadOnly = True
        Me.TextBoxFKTP.Size = New System.Drawing.Size(350, 25)
        Me.TextBoxFKTP.TabIndex = 426
        '
        'TextBoxNomorKIS
        '
        Me.TextBoxNomorKIS.BackColor = System.Drawing.Color.White
        Me.TextBoxNomorKIS.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxNomorKIS.Location = New System.Drawing.Point(187, 27)
        Me.TextBoxNomorKIS.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxNomorKIS.MaxLength = 13
        Me.TextBoxNomorKIS.Name = "TextBoxNomorKIS"
        Me.TextBoxNomorKIS.Size = New System.Drawing.Size(194, 25)
        Me.TextBoxNomorKIS.TabIndex = 196
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(15, 158)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(38, 17)
        Me.Label5.TabIndex = 425
        Me.Label5.Text = "FKTP"
        '
        'TextBoxStatusPeserta
        '
        Me.TextBoxStatusPeserta.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBoxStatusPeserta.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxStatusPeserta.Location = New System.Drawing.Point(187, 123)
        Me.TextBoxStatusPeserta.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxStatusPeserta.Name = "TextBoxStatusPeserta"
        Me.TextBoxStatusPeserta.ReadOnly = True
        Me.TextBoxStatusPeserta.Size = New System.Drawing.Size(350, 25)
        Me.TextBoxStatusPeserta.TabIndex = 424
        '
        'TextBoxStatusAktif
        '
        Me.TextBoxStatusAktif.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBoxStatusAktif.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxStatusAktif.Location = New System.Drawing.Point(187, 90)
        Me.TextBoxStatusAktif.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxStatusAktif.Name = "TextBoxStatusAktif"
        Me.TextBoxStatusAktif.ReadOnly = True
        Me.TextBoxStatusAktif.Size = New System.Drawing.Size(350, 25)
        Me.TextBoxStatusAktif.TabIndex = 473
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(15, 126)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 17)
        Me.Label4.TabIndex = 423
        Me.Label4.Text = "Status Peserta"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(15, 92)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(46, 17)
        Me.Label14.TabIndex = 472
        Me.Label14.Text = "Status"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(15, 62)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 17)
        Me.Label12.TabIndex = 430
        Me.Label12.Text = "Faskes ini?"
        '
        'TextBoxNomorNIK
        '
        Me.TextBoxNomorNIK.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxNomorNIK.Location = New System.Drawing.Point(205, 92)
        Me.TextBoxNomorNIK.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxNomorNIK.MaxLength = 16
        Me.TextBoxNomorNIK.Name = "TextBoxNomorNIK"
        Me.TextBoxNomorNIK.Size = New System.Drawing.Size(194, 25)
        Me.TextBoxNomorNIK.TabIndex = 194
        Me.TextBoxNomorNIK.Tag = ""
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(33, 93)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(40, 17)
        Me.Label41.TabIndex = 193
        Me.Label41.Text = "NIK *"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.PanelLayoutMenu2TopMain)
        Me.TabPage2.Location = New System.Drawing.Point(4, 25)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(942, 565)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Tab Menu 2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'PanelLayoutMenu2TopMain
        '
        Me.PanelLayoutMenu2TopMain.AutoScroll = True
        Me.PanelLayoutMenu2TopMain.BackColor = System.Drawing.Color.White
        Me.PanelLayoutMenu2TopMain.Controls.Add(Me.TextBoxHPKontakDarurat)
        Me.PanelLayoutMenu2TopMain.Controls.Add(Me.Label38)
        Me.PanelLayoutMenu2TopMain.Controls.Add(Me.TextBoxAlamatKontakDarurat)
        Me.PanelLayoutMenu2TopMain.Controls.Add(Me.Label56)
        Me.PanelLayoutMenu2TopMain.Controls.Add(Me.TextBoxNamaLengkapKontakDarurat)
        Me.PanelLayoutMenu2TopMain.Controls.Add(Me.Label66)
        Me.PanelLayoutMenu2TopMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelLayoutMenu2TopMain.Location = New System.Drawing.Point(3, 3)
        Me.PanelLayoutMenu2TopMain.Name = "PanelLayoutMenu2TopMain"
        Me.PanelLayoutMenu2TopMain.Size = New System.Drawing.Size(936, 559)
        Me.PanelLayoutMenu2TopMain.TabIndex = 3
        '
        'TextBoxHPKontakDarurat
        '
        Me.TextBoxHPKontakDarurat.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxHPKontakDarurat.Location = New System.Drawing.Point(219, 131)
        Me.TextBoxHPKontakDarurat.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxHPKontakDarurat.Name = "TextBoxHPKontakDarurat"
        Me.TextBoxHPKontakDarurat.Size = New System.Drawing.Size(350, 25)
        Me.TextBoxHPKontakDarurat.TabIndex = 410
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(15, 132)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(127, 17)
        Me.Label38.TabIndex = 409
        Me.Label38.Text = "No. HP (WhatsApp)"
        '
        'TextBoxAlamatKontakDarurat
        '
        Me.TextBoxAlamatKontakDarurat.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxAlamatKontakDarurat.Location = New System.Drawing.Point(219, 60)
        Me.TextBoxAlamatKontakDarurat.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxAlamatKontakDarurat.Multiline = True
        Me.TextBoxAlamatKontakDarurat.Name = "TextBoxAlamatKontakDarurat"
        Me.TextBoxAlamatKontakDarurat.Size = New System.Drawing.Size(350, 63)
        Me.TextBoxAlamatKontakDarurat.TabIndex = 375
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label56.Location = New System.Drawing.Point(15, 61)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(106, 17)
        Me.Label56.TabIndex = 374
        Me.Label56.Text = "Alamat Lengkap"
        '
        'TextBoxNamaLengkapKontakDarurat
        '
        Me.TextBoxNamaLengkapKontakDarurat.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxNamaLengkapKontakDarurat.Location = New System.Drawing.Point(219, 29)
        Me.TextBoxNamaLengkapKontakDarurat.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxNamaLengkapKontakDarurat.Name = "TextBoxNamaLengkapKontakDarurat"
        Me.TextBoxNamaLengkapKontakDarurat.Size = New System.Drawing.Size(350, 25)
        Me.TextBoxNamaLengkapKontakDarurat.TabIndex = 194
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label66.Location = New System.Drawing.Point(15, 30)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(54, 17)
        Me.Label66.TabIndex = 193
        Me.Label66.Text = "Nama *"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.PanelLayoutMenu3TopMain)
        Me.TabPage3.Location = New System.Drawing.Point(4, 25)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(942, 565)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Tab Menu 3"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'PanelLayoutMenu3TopMain
        '
        Me.PanelLayoutMenu3TopMain.AutoScroll = True
        Me.PanelLayoutMenu3TopMain.BackColor = System.Drawing.Color.White
        Me.PanelLayoutMenu3TopMain.Controls.Add(Me.TextBoxNoKaryawanPerusahaan)
        Me.PanelLayoutMenu3TopMain.Controls.Add(Me.Label1)
        Me.PanelLayoutMenu3TopMain.Controls.Add(Me.TextBoxEmailPerusahaan)
        Me.PanelLayoutMenu3TopMain.Controls.Add(Me.Label2)
        Me.PanelLayoutMenu3TopMain.Controls.Add(Me.TextBoxTeleponPerusahaan)
        Me.PanelLayoutMenu3TopMain.Controls.Add(Me.Label3)
        Me.PanelLayoutMenu3TopMain.Controls.Add(Me.TextBoxAlamatPerusahaan)
        Me.PanelLayoutMenu3TopMain.Controls.Add(Me.Label13)
        Me.PanelLayoutMenu3TopMain.Controls.Add(Me.TextBoxNamaPerusahaan)
        Me.PanelLayoutMenu3TopMain.Controls.Add(Me.Label44)
        Me.PanelLayoutMenu3TopMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelLayoutMenu3TopMain.Location = New System.Drawing.Point(3, 3)
        Me.PanelLayoutMenu3TopMain.Name = "PanelLayoutMenu3TopMain"
        Me.PanelLayoutMenu3TopMain.Size = New System.Drawing.Size(936, 559)
        Me.PanelLayoutMenu3TopMain.TabIndex = 5
        '
        'TextBoxNoKaryawanPerusahaan
        '
        Me.TextBoxNoKaryawanPerusahaan.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxNoKaryawanPerusahaan.Location = New System.Drawing.Point(219, 193)
        Me.TextBoxNoKaryawanPerusahaan.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxNoKaryawanPerusahaan.Name = "TextBoxNoKaryawanPerusahaan"
        Me.TextBoxNoKaryawanPerusahaan.Size = New System.Drawing.Size(350, 25)
        Me.TextBoxNoKaryawanPerusahaan.TabIndex = 412
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 194)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 17)
        Me.Label1.TabIndex = 411
        Me.Label1.Text = "No Karyawan"
        '
        'TextBoxEmailPerusahaan
        '
        Me.TextBoxEmailPerusahaan.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxEmailPerusahaan.Location = New System.Drawing.Point(219, 162)
        Me.TextBoxEmailPerusahaan.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxEmailPerusahaan.Name = "TextBoxEmailPerusahaan"
        Me.TextBoxEmailPerusahaan.Size = New System.Drawing.Size(350, 25)
        Me.TextBoxEmailPerusahaan.TabIndex = 410
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 163)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 17)
        Me.Label2.TabIndex = 409
        Me.Label2.Text = "Email"
        '
        'TextBoxTeleponPerusahaan
        '
        Me.TextBoxTeleponPerusahaan.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxTeleponPerusahaan.Location = New System.Drawing.Point(219, 131)
        Me.TextBoxTeleponPerusahaan.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxTeleponPerusahaan.Name = "TextBoxTeleponPerusahaan"
        Me.TextBoxTeleponPerusahaan.Size = New System.Drawing.Size(350, 25)
        Me.TextBoxTeleponPerusahaan.TabIndex = 408
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 132)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 17)
        Me.Label3.TabIndex = 407
        Me.Label3.Text = "Telepon"
        '
        'TextBoxAlamatPerusahaan
        '
        Me.TextBoxAlamatPerusahaan.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxAlamatPerusahaan.Location = New System.Drawing.Point(219, 60)
        Me.TextBoxAlamatPerusahaan.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxAlamatPerusahaan.Multiline = True
        Me.TextBoxAlamatPerusahaan.Name = "TextBoxAlamatPerusahaan"
        Me.TextBoxAlamatPerusahaan.Size = New System.Drawing.Size(350, 63)
        Me.TextBoxAlamatPerusahaan.TabIndex = 375
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(15, 61)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(51, 17)
        Me.Label13.TabIndex = 374
        Me.Label13.Text = "Alamat"
        '
        'TextBoxNamaPerusahaan
        '
        Me.TextBoxNamaPerusahaan.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxNamaPerusahaan.Location = New System.Drawing.Point(219, 29)
        Me.TextBoxNamaPerusahaan.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxNamaPerusahaan.Name = "TextBoxNamaPerusahaan"
        Me.TextBoxNamaPerusahaan.Size = New System.Drawing.Size(350, 25)
        Me.TextBoxNamaPerusahaan.TabIndex = 194
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(15, 30)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(119, 17)
        Me.Label44.TabIndex = 193
        Me.Label44.Text = "Nama Perusahaan"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.PanelLayoutMenu4TopMain)
        Me.TabPage4.Location = New System.Drawing.Point(4, 25)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(942, 565)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Tab Menu 4"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'PanelLayoutMenu4TopMain
        '
        Me.PanelLayoutMenu4TopMain.AutoScroll = True
        Me.PanelLayoutMenu4TopMain.BackColor = System.Drawing.Color.White
        Me.PanelLayoutMenu4TopMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelLayoutMenu4TopMain.Location = New System.Drawing.Point(3, 3)
        Me.PanelLayoutMenu4TopMain.Name = "PanelLayoutMenu4TopMain"
        Me.PanelLayoutMenu4TopMain.Size = New System.Drawing.Size(936, 559)
        Me.PanelLayoutMenu4TopMain.TabIndex = 7
        '
        'PanelButton
        '
        Me.PanelButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.PanelButton.Controls.Add(Me.ButtonCetakGeneralConsent)
        Me.PanelButton.Controls.Add(Me.ButtonClearMenu1)
        Me.PanelButton.Controls.Add(Me.ButtonScanQR)
        Me.PanelButton.Controls.Add(Me.ButtonSimpanMenu1)
        Me.PanelButton.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelButton.Location = New System.Drawing.Point(0, 0)
        Me.PanelButton.Name = "PanelButton"
        Me.PanelButton.Size = New System.Drawing.Size(950, 45)
        Me.PanelButton.TabIndex = 3
        '
        'ButtonCetakGeneralConsent
        '
        Me.ButtonCetakGeneralConsent.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCetakGeneralConsent.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonCetakGeneralConsent.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonCetakGeneralConsent.FlatAppearance.BorderSize = 0
        Me.ButtonCetakGeneralConsent.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCetakGeneralConsent.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonCetakGeneralConsent.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCetakGeneralConsent.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCetakGeneralConsent.ForeColor = System.Drawing.Color.White
        Me.ButtonCetakGeneralConsent.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_print_24
        Me.ButtonCetakGeneralConsent.Location = New System.Drawing.Point(383, 5)
        Me.ButtonCetakGeneralConsent.Name = "ButtonCetakGeneralConsent"
        Me.ButtonCetakGeneralConsent.Size = New System.Drawing.Size(200, 35)
        Me.ButtonCetakGeneralConsent.TabIndex = 503
        Me.ButtonCetakGeneralConsent.Text = " Cetak General Consent"
        Me.ButtonCetakGeneralConsent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonCetakGeneralConsent.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonCetakGeneralConsent.UseVisualStyleBackColor = False
        '
        'ButtonClearMenu1
        '
        Me.ButtonClearMenu1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonClearMenu1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonClearMenu1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonClearMenu1.FlatAppearance.BorderSize = 0
        Me.ButtonClearMenu1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonClearMenu1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonClearMenu1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonClearMenu1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonClearMenu1.ForeColor = System.Drawing.Color.White
        Me.ButtonClearMenu1.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_clear_24
        Me.ButtonClearMenu1.Location = New System.Drawing.Point(131, 5)
        Me.ButtonClearMenu1.Name = "ButtonClearMenu1"
        Me.ButtonClearMenu1.Size = New System.Drawing.Size(120, 35)
        Me.ButtonClearMenu1.TabIndex = 502
        Me.ButtonClearMenu1.Text = " Clear Data"
        Me.ButtonClearMenu1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonClearMenu1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonClearMenu1.UseVisualStyleBackColor = False
        '
        'ButtonScanQR
        '
        Me.ButtonScanQR.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonScanQR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonScanQR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonScanQR.FlatAppearance.BorderSize = 0
        Me.ButtonScanQR.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonScanQR.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonScanQR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonScanQR.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonScanQR.ForeColor = System.Drawing.Color.White
        Me.ButtonScanQR.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_barcode_24
        Me.ButtonScanQR.Location = New System.Drawing.Point(257, 5)
        Me.ButtonScanQR.Name = "ButtonScanQR"
        Me.ButtonScanQR.Size = New System.Drawing.Size(120, 35)
        Me.ButtonScanQR.TabIndex = 501
        Me.ButtonScanQR.Text = " Scan QR"
        Me.ButtonScanQR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonScanQR.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonScanQR.UseVisualStyleBackColor = False
        '
        'ButtonSimpanMenu1
        '
        Me.ButtonSimpanMenu1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSimpanMenu1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonSimpanMenu1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonSimpanMenu1.FlatAppearance.BorderSize = 0
        Me.ButtonSimpanMenu1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSimpanMenu1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonSimpanMenu1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSimpanMenu1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSimpanMenu1.ForeColor = System.Drawing.Color.White
        Me.ButtonSimpanMenu1.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_save_24
        Me.ButtonSimpanMenu1.Location = New System.Drawing.Point(5, 5)
        Me.ButtonSimpanMenu1.Name = "ButtonSimpanMenu1"
        Me.ButtonSimpanMenu1.Size = New System.Drawing.Size(120, 35)
        Me.ButtonSimpanMenu1.TabIndex = 499
        Me.ButtonSimpanMenu1.Text = " Simpan Data"
        Me.ButtonSimpanMenu1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonSimpanMenu1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonSimpanMenu1.UseVisualStyleBackColor = False
        '
        'SplitContainer9
        '
        Me.SplitContainer9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer9.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer9.IsSplitterFixed = True
        Me.SplitContainer9.Location = New System.Drawing.Point(150, 40)
        Me.SplitContainer9.Name = "SplitContainer9"
        Me.SplitContainer9.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer9.Panel1
        '
        Me.SplitContainer9.Panel1.AutoScroll = True
        Me.SplitContainer9.Panel1.Controls.Add(Me.PanelButton)
        '
        'SplitContainer9.Panel2
        '
        Me.SplitContainer9.Panel2.AutoScroll = True
        Me.SplitContainer9.Panel2.Controls.Add(Me.TabControlMenu)
        Me.SplitContainer9.Size = New System.Drawing.Size(950, 644)
        Me.SplitContainer9.SplitterDistance = 45
        Me.SplitContainer9.SplitterWidth = 5
        Me.SplitContainer9.TabIndex = 461
        '
        'FormMasterPasien
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1100, 684)
        Me.ControlBox = False
        Me.Controls.Add(Me.SplitContainer9)
        Me.Controls.Add(Me.PanelSide)
        Me.Controls.Add(Me.PanelTop)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormMasterPasien"
        Me.PanelTop.ResumeLayout(False)
        Me.PanelSide.ResumeLayout(False)
        Me.TabControlMenu.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.PanelLayoutMenu1TopMain.ResumeLayout(False)
        Me.PanelLayoutMenu1TopMain.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.PictureBoxFotoPasien, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxAlergiPemeriksaanAwal.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.GridControlAlergi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewAlergi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBoxSignatureGC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelJenisKelaminGC.ResumeLayout(False)
        Me.PanelJenisKelaminGC.PerformLayout()
        Me.GroupBoxWaliPasien.ResumeLayout(False)
        Me.GroupBoxWaliPasien.PerformLayout()
        Me.PanelJenisKelaminWali.ResumeLayout(False)
        Me.PanelJenisKelaminWali.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBoxDataLain.ResumeLayout(False)
        Me.GroupBoxDataLain.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.GroupBoxAlamatDomisili.ResumeLayout(False)
        Me.GroupBoxAlamatDomisili.PerformLayout()
        Me.GroupBoxAlamatKTP.ResumeLayout(False)
        Me.GroupBoxAlamatKTP.PerformLayout()
        Me.GroupBoxBiodataDiri.ResumeLayout(False)
        Me.GroupBoxBiodataDiri.PerformLayout()
        Me.PanelJenisKelaminPasien.ResumeLayout(False)
        Me.PanelJenisKelaminPasien.PerformLayout()
        Me.GroupBoxJKN.ResumeLayout(False)
        Me.GroupBoxJKN.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.PanelLayoutMenu2TopMain.ResumeLayout(False)
        Me.PanelLayoutMenu2TopMain.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.PanelLayoutMenu3TopMain.ResumeLayout(False)
        Me.PanelLayoutMenu3TopMain.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.PanelButton.ResumeLayout(False)
        Me.SplitContainer9.Panel1.ResumeLayout(False)
        Me.SplitContainer9.Panel2.ResumeLayout(False)
        Me.SplitContainer9.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents PanelSide As System.Windows.Forms.Panel
    Friend WithEvents ToolTipBtnMenu As System.Windows.Forms.ToolTip
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnMenu3 As System.Windows.Forms.Button
    Friend WithEvents btnMenu2 As System.Windows.Forms.Button
    Friend WithEvents btnMenu1 As System.Windows.Forms.Button
    Friend WithEvents btnMenu4 As System.Windows.Forms.Button
    Friend WithEvents TabControlMenu As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents PanelLayoutMenu1TopMain As System.Windows.Forms.Panel
    Friend WithEvents TextBoxPRB As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextBoxFKTP As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBoxStatusPeserta As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ButtonCekKIS As System.Windows.Forms.Button
    Friend WithEvents ButtonCekNIK As System.Windows.Forms.Button
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents RadioButtonWNI As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonWNA As System.Windows.Forms.RadioButton
    Friend WithEvents TextBoxKetWNA As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBoxEmailIdentitas As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNoHPIdentitas As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNoTeleponIdentitas As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxCopyAlamatDomisili As System.Windows.Forms.CheckBox
    Friend WithEvents TextBoxKodePosKTP As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TextBoxRWKTP As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TextBoxRTKTP As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents TextBoxAlamatKTP As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents TextBoxKodePosDomisili As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents TextBoxRWDomisili As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents TextBoxRTDomisili As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents TextBoxAlamatDomisili As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents TextBoxPekerjaan As System.Windows.Forms.TextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxGolDarahIdentitas As System.Windows.Forms.ComboBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents PanelJenisKelaminPasien As System.Windows.Forms.Panel
    Friend WithEvents RadioButtonJenisKelaminLakiIdentitas As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonJenisKelaminPerempuanIdentitas As System.Windows.Forms.RadioButton
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerTglLahir As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents TextBoxTempatLahir As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNamaLengkapIdentitas As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNomorKIS As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNomorNIK As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents PanelLayoutMenu2TopMain As System.Windows.Forms.Panel
    Friend WithEvents TextBoxHPKontakDarurat As System.Windows.Forms.TextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents TextBoxAlamatKontakDarurat As System.Windows.Forms.TextBox
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNamaLengkapKontakDarurat As System.Windows.Forms.TextBox
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents PanelLayoutMenu3TopMain As System.Windows.Forms.Panel
    Friend WithEvents TextBoxNoKaryawanPerusahaan As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxEmailPerusahaan As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBoxTeleponPerusahaan As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBoxAlamatPerusahaan As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNamaPerusahaan As System.Windows.Forms.TextBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents PanelLayoutMenu4TopMain As System.Windows.Forms.Panel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TextBoxStatusAktif As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TextBoxProlanis As System.Windows.Forms.TextBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents GroupBoxJKN As System.Windows.Forms.GroupBox
    Friend WithEvents TextBoxFaskesAktif As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxNomorNIP As System.Windows.Forms.TextBox
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNomorJPK As System.Windows.Forms.TextBox
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNomorInhealth As System.Windows.Forms.TextBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents GroupBoxBiodataDiri As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBoxAlamatKTP As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBoxAlamatDomisili As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBoxDataLain As System.Windows.Forms.GroupBox
    Friend WithEvents TextBoxNoRM As System.Windows.Forms.TextBox
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxAgama As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxPendidikanTerakhir As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxStatusPerkawinan As System.Windows.Forms.ComboBox
    Friend WithEvents PanelButton As System.Windows.Forms.Panel
    Friend WithEvents ComboBoxStatusKeluarga As System.Windows.Forms.ComboBox
    Friend WithEvents TextBoxNomorCahaya As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ButtonSimpanMenu1 As System.Windows.Forms.Button
    Friend WithEvents ButtonClearMenu1 As System.Windows.Forms.Button
    Friend WithEvents ButtonScanQR As System.Windows.Forms.Button
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBoxRiwayatKebiasaan As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextBoxRiwayatPenyakitKeluarga As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TextBoxRiwayatPenyakitDahulu As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents PictureBoxSignatureGC As System.Windows.Forms.PictureBox
    Friend WithEvents SplitContainer9 As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBoxWaliPasien As System.Windows.Forms.GroupBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNamaLengkapWali As System.Windows.Forms.TextBox
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerTglLahirWali As System.Windows.Forms.DateTimePicker
    Friend WithEvents PanelJenisKelaminWali As System.Windows.Forms.Panel
    Friend WithEvents RadioButtonJenisKelaminLakiWali As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonJenisKelaminPerempuanWali As System.Windows.Forms.RadioButton
    Friend WithEvents TextBoxTempatLahirWali As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxHubunganKeluargaWali As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxNoHPWali As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxAlamatDomisiliWali As System.Windows.Forms.TextBox
    Friend WithEvents CheckBoxStatusWaliPasien As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBoxTempatLahirGC As System.Windows.Forms.TextBox
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerTglLahirGC As System.Windows.Forms.DateTimePicker
    Friend WithEvents PanelJenisKelaminGC As System.Windows.Forms.Panel
    Friend WithEvents RadioButtonJenisKelaminLakiGC As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonJenisKelaminPerempuanGC As System.Windows.Forms.RadioButton
    Friend WithEvents TextBoxNamaGC As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxHubunganKeluargaGC As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxAlamatGC As System.Windows.Forms.TextBox
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNoTeleponGC As System.Windows.Forms.TextBox
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents LabelSignatureDate As System.Windows.Forms.Label
    Friend WithEvents LabelSignatureKeterangan As System.Windows.Forms.Label
    Friend WithEvents ButtonCetakGeneralConsent As System.Windows.Forms.Button
    Friend WithEvents TextBoxNomorIHS As System.Windows.Forms.TextBox
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents ButtonGetNomorIHS As System.Windows.Forms.Button
    Friend WithEvents ButtonCariNoRM As System.Windows.Forms.Button
    Friend WithEvents ComboBoxProvinsiDomisili As System.Windows.Forms.ComboBox
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxKabupatenDomisili As System.Windows.Forms.ComboBox
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxKecamatanDomisili As System.Windows.Forms.ComboBox
    Friend WithEvents Label69 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxKelurahanDomisili As System.Windows.Forms.ComboBox
    Friend WithEvents Label70 As System.Windows.Forms.Label
    Friend WithEvents Label71 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNoDokumenRM As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxKelurahanKTP As System.Windows.Forms.ComboBox
    Friend WithEvents Label72 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxKecamatanKTP As System.Windows.Forms.ComboBox
    Friend WithEvents Label73 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxKabupatenKTP As System.Windows.Forms.ComboBox
    Friend WithEvents Label74 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxProvinsiKTP As System.Windows.Forms.ComboBox
    Friend WithEvents Label75 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxStatusNIK As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBoxAlergiPemeriksaanAwal As System.Windows.Forms.GroupBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ButtonTambahAlergi As System.Windows.Forms.Button
    Friend WithEvents ButtonHapusAlergi As System.Windows.Forms.Button
    Private WithEvents GridControlAlergi As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewAlergi As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBoxFotoPasien As System.Windows.Forms.PictureBox
    Friend WithEvents ButtonUploadFoto As System.Windows.Forms.Button
End Class
