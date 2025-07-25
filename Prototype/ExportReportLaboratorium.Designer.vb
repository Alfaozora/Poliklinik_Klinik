<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ExportReportLaboratorium
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ExportReportLaboratorium))
        Me.GroupBoxFilter = New System.Windows.Forms.GroupBox
        Me.TextBoxNoUrut2 = New System.Windows.Forms.TextBox
        Me.CheckBoxNoUrut = New System.Windows.Forms.CheckBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.CheckBoxLaboratorium = New System.Windows.Forms.CheckBox
        Me.CheckBoxFisik = New System.Windows.Forms.CheckBox
        Me.TextBoxNoUrut1 = New System.Windows.Forms.TextBox
        Me.CheckBoxThorax = New System.Windows.Forms.CheckBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.rdOnline = New System.Windows.Forms.RadioButton
        Me.rdOffline = New System.Windows.Forms.RadioButton
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.ButtonFindPathDirectoryTujuan1 = New System.Windows.Forms.Button
        Me.ButtonFindLokasi = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.TextBoxPathDirectoryTujuan1 = New System.Windows.Forms.TextBox
        Me.ButtonFindCompany = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.dtprocess = New System.Windows.Forms.DateTimePicker
        Me.txidloc = New System.Windows.Forms.TextBox
        Me.NamaLokasi = New System.Windows.Forms.Label
        Me.txkodecabang = New System.Windows.Forms.TextBox
        Me.txloc = New System.Windows.Forms.TextBox
        Me.txcompanycode = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.ButtonExport = New System.Windows.Forms.Button
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.RadioButtonExportData = New System.Windows.Forms.RadioButton
        Me.RadioButtonPindahData = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.ComboBoxFolderTujuan = New System.Windows.Forms.ComboBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.ButtonPindahFile = New System.Windows.Forms.Button
        Me.TextBoxPathDirectoryData = New System.Windows.Forms.TextBox
        Me.SplitContainerRujukanVertikal = New System.Windows.Forms.SplitContainer
        Me.TabControlJenisAction = New System.Windows.Forms.TabControl
        Me.TabExportData = New System.Windows.Forms.TabPage
        Me.CheckBoxReverse = New System.Windows.Forms.CheckBox
        Me.ButtonPrint = New System.Windows.Forms.Button
        Me.TabPindahData = New System.Windows.Forms.TabPage
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar
        Me.Label5 = New System.Windows.Forms.Label
        Me.TextBoxLabelTambahan = New System.Windows.Forms.TextBox
        Me.ButtonFindPathDirectoryTujuan2 = New System.Windows.Forms.Button
        Me.ButtonFindPathDirectoryData = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.TextBoxPathDirectoryTujuan2 = New System.Windows.Forms.TextBox
        Me.PanelTop = New System.Windows.Forms.Panel
        Me.ButtonClose = New System.Windows.Forms.Button
        Me.PanelMainMenu = New System.Windows.Forms.Panel
        Me.GroupBoxFilter.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.SplitContainerRujukanVertikal.Panel1.SuspendLayout()
        Me.SplitContainerRujukanVertikal.Panel2.SuspendLayout()
        Me.SplitContainerRujukanVertikal.SuspendLayout()
        Me.TabControlJenisAction.SuspendLayout()
        Me.TabExportData.SuspendLayout()
        Me.TabPindahData.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.PanelTop.SuspendLayout()
        Me.PanelMainMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBoxFilter
        '
        Me.GroupBoxFilter.Controls.Add(Me.TextBoxNoUrut2)
        Me.GroupBoxFilter.Controls.Add(Me.CheckBoxNoUrut)
        Me.GroupBoxFilter.Controls.Add(Me.Label10)
        Me.GroupBoxFilter.Controls.Add(Me.CheckBoxLaboratorium)
        Me.GroupBoxFilter.Controls.Add(Me.CheckBoxFisik)
        Me.GroupBoxFilter.Controls.Add(Me.TextBoxNoUrut1)
        Me.GroupBoxFilter.Controls.Add(Me.CheckBoxThorax)
        Me.GroupBoxFilter.Controls.Add(Me.Panel1)
        Me.GroupBoxFilter.Controls.Add(Me.ProgressBar1)
        Me.GroupBoxFilter.Controls.Add(Me.ButtonFindPathDirectoryTujuan1)
        Me.GroupBoxFilter.Controls.Add(Me.ButtonFindLokasi)
        Me.GroupBoxFilter.Controls.Add(Me.Label3)
        Me.GroupBoxFilter.Controls.Add(Me.TextBoxPathDirectoryTujuan1)
        Me.GroupBoxFilter.Controls.Add(Me.ButtonFindCompany)
        Me.GroupBoxFilter.Controls.Add(Me.Label8)
        Me.GroupBoxFilter.Controls.Add(Me.Label9)
        Me.GroupBoxFilter.Controls.Add(Me.dtprocess)
        Me.GroupBoxFilter.Controls.Add(Me.txidloc)
        Me.GroupBoxFilter.Controls.Add(Me.NamaLokasi)
        Me.GroupBoxFilter.Controls.Add(Me.txkodecabang)
        Me.GroupBoxFilter.Controls.Add(Me.txloc)
        Me.GroupBoxFilter.Controls.Add(Me.txcompanycode)
        Me.GroupBoxFilter.Controls.Add(Me.Label16)
        Me.GroupBoxFilter.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBoxFilter.Location = New System.Drawing.Point(14, 6)
        Me.GroupBoxFilter.Name = "GroupBoxFilter"
        Me.GroupBoxFilter.Size = New System.Drawing.Size(615, 250)
        Me.GroupBoxFilter.TabIndex = 461
        Me.GroupBoxFilter.TabStop = False
        Me.GroupBoxFilter.Text = "Export Data"
        '
        'TextBoxNoUrut2
        '
        Me.TextBoxNoUrut2.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxNoUrut2.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxNoUrut2.Location = New System.Drawing.Point(254, 179)
        Me.TextBoxNoUrut2.Name = "TextBoxNoUrut2"
        Me.TextBoxNoUrut2.Size = New System.Drawing.Size(44, 25)
        Me.TextBoxNoUrut2.TabIndex = 473
        '
        'CheckBoxNoUrut
        '
        Me.CheckBoxNoUrut.AutoSize = True
        Me.CheckBoxNoUrut.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.CheckBoxNoUrut.Location = New System.Drawing.Point(18, 181)
        Me.CheckBoxNoUrut.Name = "CheckBoxNoUrut"
        Me.CheckBoxNoUrut.Size = New System.Drawing.Size(140, 21)
        Me.CheckBoxNoUrut.TabIndex = 474
        Me.CheckBoxNoUrut.Text = "Sesuaikan No Urut"
        Me.CheckBoxNoUrut.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label10.Location = New System.Drawing.Point(221, 182)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(27, 17)
        Me.Label10.TabIndex = 472
        Me.Label10.Text = "s/d"
        '
        'CheckBoxLaboratorium
        '
        Me.CheckBoxLaboratorium.AutoSize = True
        Me.CheckBoxLaboratorium.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.CheckBoxLaboratorium.Location = New System.Drawing.Point(173, 210)
        Me.CheckBoxLaboratorium.Name = "CheckBoxLaboratorium"
        Me.CheckBoxLaboratorium.Size = New System.Drawing.Size(106, 21)
        Me.CheckBoxLaboratorium.TabIndex = 468
        Me.CheckBoxLaboratorium.Text = "Laboratorium"
        Me.CheckBoxLaboratorium.UseVisualStyleBackColor = True
        '
        'CheckBoxFisik
        '
        Me.CheckBoxFisik.AutoSize = True
        Me.CheckBoxFisik.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.CheckBoxFisik.Location = New System.Drawing.Point(358, 210)
        Me.CheckBoxFisik.Name = "CheckBoxFisik"
        Me.CheckBoxFisik.Size = New System.Drawing.Size(51, 21)
        Me.CheckBoxFisik.TabIndex = 470
        Me.CheckBoxFisik.Text = "Fisik"
        Me.CheckBoxFisik.UseVisualStyleBackColor = True
        '
        'TextBoxNoUrut1
        '
        Me.TextBoxNoUrut1.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxNoUrut1.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxNoUrut1.Location = New System.Drawing.Point(173, 179)
        Me.TextBoxNoUrut1.Name = "TextBoxNoUrut1"
        Me.TextBoxNoUrut1.Size = New System.Drawing.Size(44, 25)
        Me.TextBoxNoUrut1.TabIndex = 471
        '
        'CheckBoxThorax
        '
        Me.CheckBoxThorax.AutoSize = True
        Me.CheckBoxThorax.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.CheckBoxThorax.Location = New System.Drawing.Point(285, 210)
        Me.CheckBoxThorax.Name = "CheckBoxThorax"
        Me.CheckBoxThorax.Size = New System.Drawing.Size(67, 21)
        Me.CheckBoxThorax.TabIndex = 469
        Me.CheckBoxThorax.Text = "Thorax"
        Me.CheckBoxThorax.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.rdOnline)
        Me.Panel1.Controls.Add(Me.rdOffline)
        Me.Panel1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Panel1.Location = New System.Drawing.Point(173, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(291, 25)
        Me.Panel1.TabIndex = 466
        '
        'rdOnline
        '
        Me.rdOnline.AutoSize = True
        Me.rdOnline.Checked = True
        Me.rdOnline.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rdOnline.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.rdOnline.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.rdOnline.Location = New System.Drawing.Point(5, 3)
        Me.rdOnline.Name = "rdOnline"
        Me.rdOnline.Size = New System.Drawing.Size(60, 19)
        Me.rdOnline.TabIndex = 244
        Me.rdOnline.TabStop = True
        Me.rdOnline.Text = "Online"
        Me.rdOnline.UseVisualStyleBackColor = True
        '
        'rdOffline
        '
        Me.rdOffline.AutoSize = True
        Me.rdOffline.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rdOffline.Enabled = False
        Me.rdOffline.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.rdOffline.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.rdOffline.Location = New System.Drawing.Point(79, 3)
        Me.rdOffline.Name = "rdOffline"
        Me.rdOffline.Size = New System.Drawing.Size(61, 19)
        Me.rdOffline.TabIndex = 243
        Me.rdOffline.Text = "Offline"
        Me.rdOffline.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.BackColor = System.Drawing.Color.Lime
        Me.ProgressBar1.Location = New System.Drawing.Point(173, 237)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(434, 5)
        Me.ProgressBar1.TabIndex = 241
        '
        'ButtonFindPathDirectoryTujuan1
        '
        Me.ButtonFindPathDirectoryTujuan1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindPathDirectoryTujuan1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonFindPathDirectoryTujuan1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonFindPathDirectoryTujuan1.FlatAppearance.BorderSize = 0
        Me.ButtonFindPathDirectoryTujuan1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindPathDirectoryTujuan1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonFindPathDirectoryTujuan1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonFindPathDirectoryTujuan1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonFindPathDirectoryTujuan1.ForeColor = System.Drawing.Color.White
        Me.ButtonFindPathDirectoryTujuan1.Location = New System.Drawing.Point(542, 148)
        Me.ButtonFindPathDirectoryTujuan1.Name = "ButtonFindPathDirectoryTujuan1"
        Me.ButtonFindPathDirectoryTujuan1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonFindPathDirectoryTujuan1.Size = New System.Drawing.Size(65, 25)
        Me.ButtonFindPathDirectoryTujuan1.TabIndex = 464
        Me.ButtonFindPathDirectoryTujuan1.Text = "Cari"
        Me.ButtonFindPathDirectoryTujuan1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonFindPathDirectoryTujuan1.UseVisualStyleBackColor = False
        '
        'ButtonFindLokasi
        '
        Me.ButtonFindLokasi.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindLokasi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonFindLokasi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonFindLokasi.FlatAppearance.BorderSize = 0
        Me.ButtonFindLokasi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindLokasi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonFindLokasi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonFindLokasi.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonFindLokasi.ForeColor = System.Drawing.Color.White
        Me.ButtonFindLokasi.Location = New System.Drawing.Point(542, 117)
        Me.ButtonFindLokasi.Name = "ButtonFindLokasi"
        Me.ButtonFindLokasi.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonFindLokasi.Size = New System.Drawing.Size(65, 25)
        Me.ButtonFindLokasi.TabIndex = 463
        Me.ButtonFindLokasi.Text = "Cari"
        Me.ButtonFindLokasi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonFindLokasi.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(14, 151)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(140, 17)
        Me.Label3.TabIndex = 461
        Me.Label3.Text = "Path Directory Tujuan"
        '
        'TextBoxPathDirectoryTujuan1
        '
        Me.TextBoxPathDirectoryTujuan1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBoxPathDirectoryTujuan1.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxPathDirectoryTujuan1.Location = New System.Drawing.Point(173, 148)
        Me.TextBoxPathDirectoryTujuan1.Name = "TextBoxPathDirectoryTujuan1"
        Me.TextBoxPathDirectoryTujuan1.ReadOnly = True
        Me.TextBoxPathDirectoryTujuan1.Size = New System.Drawing.Size(363, 25)
        Me.TextBoxPathDirectoryTujuan1.TabIndex = 460
        '
        'ButtonFindCompany
        '
        Me.ButtonFindCompany.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindCompany.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonFindCompany.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonFindCompany.FlatAppearance.BorderSize = 0
        Me.ButtonFindCompany.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindCompany.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonFindCompany.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonFindCompany.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonFindCompany.ForeColor = System.Drawing.Color.White
        Me.ButtonFindCompany.Location = New System.Drawing.Point(542, 86)
        Me.ButtonFindCompany.Name = "ButtonFindCompany"
        Me.ButtonFindCompany.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonFindCompany.Size = New System.Drawing.Size(65, 25)
        Me.ButtonFindCompany.TabIndex = 462
        Me.ButtonFindCompany.Text = "Cari"
        Me.ButtonFindCompany.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonFindCompany.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label8.Location = New System.Drawing.Point(15, 27)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 17)
        Me.Label8.TabIndex = 242
        Me.Label8.Text = "Jenis Transaksi"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(15, 59)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 17)
        Me.Label9.TabIndex = 241
        Me.Label9.Text = "Tgl Transaksi"
        '
        'dtprocess
        '
        Me.dtprocess.CustomFormat = "dd-MMM-yyyy"
        Me.dtprocess.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.dtprocess.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtprocess.Location = New System.Drawing.Point(173, 55)
        Me.dtprocess.Name = "dtprocess"
        Me.dtprocess.Size = New System.Drawing.Size(130, 25)
        Me.dtprocess.TabIndex = 237
        '
        'txidloc
        '
        Me.txidloc.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txidloc.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txidloc.Location = New System.Drawing.Point(173, 117)
        Me.txidloc.Name = "txidloc"
        Me.txidloc.ReadOnly = True
        Me.txidloc.Size = New System.Drawing.Size(100, 25)
        Me.txidloc.TabIndex = 248
        Me.txidloc.Visible = False
        '
        'NamaLokasi
        '
        Me.NamaLokasi.AutoSize = True
        Me.NamaLokasi.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.NamaLokasi.ForeColor = System.Drawing.SystemColors.ControlText
        Me.NamaLokasi.Location = New System.Drawing.Point(15, 120)
        Me.NamaLokasi.Name = "NamaLokasi"
        Me.NamaLokasi.Size = New System.Drawing.Size(88, 17)
        Me.NamaLokasi.TabIndex = 245
        Me.NamaLokasi.Text = "Lokasi Server"
        '
        'txkodecabang
        '
        Me.txkodecabang.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txkodecabang.Location = New System.Drawing.Point(173, 86)
        Me.txkodecabang.Name = "txkodecabang"
        Me.txkodecabang.Size = New System.Drawing.Size(100, 25)
        Me.txkodecabang.TabIndex = 236
        Me.txkodecabang.Visible = False
        '
        'txloc
        '
        Me.txloc.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txloc.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txloc.Location = New System.Drawing.Point(173, 117)
        Me.txloc.Name = "txloc"
        Me.txloc.ReadOnly = True
        Me.txloc.Size = New System.Drawing.Size(363, 25)
        Me.txloc.TabIndex = 247
        '
        'txcompanycode
        '
        Me.txcompanycode.BackColor = System.Drawing.SystemColors.Window
        Me.txcompanycode.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txcompanycode.Location = New System.Drawing.Point(173, 86)
        Me.txcompanycode.Name = "txcompanycode"
        Me.txcompanycode.ReadOnly = True
        Me.txcompanycode.Size = New System.Drawing.Size(363, 25)
        Me.txcompanycode.TabIndex = 239
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label16.Location = New System.Drawing.Point(15, 89)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(66, 17)
        Me.Label16.TabIndex = 238
        Me.Label16.Text = "Company"
        '
        'ButtonExport
        '
        Me.ButtonExport.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonExport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonExport.FlatAppearance.BorderSize = 0
        Me.ButtonExport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonExport.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonExport.ForeColor = System.Drawing.Color.White
        Me.ButtonExport.Location = New System.Drawing.Point(479, 262)
        Me.ButtonExport.Name = "ButtonExport"
        Me.ButtonExport.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonExport.Size = New System.Drawing.Size(150, 30)
        Me.ButtonExport.TabIndex = 456
        Me.ButtonExport.Text = "Export Data"
        Me.ButtonExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonExport.UseVisualStyleBackColor = False
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Transparent
        Me.Panel7.Controls.Add(Me.RadioButtonExportData)
        Me.Panel7.Controls.Add(Me.RadioButtonPindahData)
        Me.Panel7.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Panel7.Location = New System.Drawing.Point(81, 7)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(321, 25)
        Me.Panel7.TabIndex = 465
        '
        'RadioButtonExportData
        '
        Me.RadioButtonExportData.AutoSize = True
        Me.RadioButtonExportData.Checked = True
        Me.RadioButtonExportData.Cursor = System.Windows.Forms.Cursors.Hand
        Me.RadioButtonExportData.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonExportData.Location = New System.Drawing.Point(5, 3)
        Me.RadioButtonExportData.Name = "RadioButtonExportData"
        Me.RadioButtonExportData.Size = New System.Drawing.Size(135, 19)
        Me.RadioButtonExportData.TabIndex = 245
        Me.RadioButtonExportData.TabStop = True
        Me.RadioButtonExportData.Text = "Export/Print Laporan"
        Me.RadioButtonExportData.UseVisualStyleBackColor = True
        '
        'RadioButtonPindahData
        '
        Me.RadioButtonPindahData.AutoSize = True
        Me.RadioButtonPindahData.Cursor = System.Windows.Forms.Cursors.Hand
        Me.RadioButtonPindahData.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonPindahData.Location = New System.Drawing.Point(145, 3)
        Me.RadioButtonPindahData.Name = "RadioButtonPindahData"
        Me.RadioButtonPindahData.Size = New System.Drawing.Size(90, 19)
        Me.RadioButtonPindahData.TabIndex = 246
        Me.RadioButtonPindahData.Text = "Pindah Data"
        Me.RadioButtonPindahData.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(15, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 17)
        Me.Label1.TabIndex = 464
        Me.Label1.Text = "Action"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(15, 89)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 17)
        Me.Label7.TabIndex = 460
        Me.Label7.Text = "Folder Tujuan"
        '
        'ComboBoxFolderTujuan
        '
        Me.ComboBoxFolderTujuan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxFolderTujuan.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBoxFolderTujuan.FormattingEnabled = True
        Me.ComboBoxFolderTujuan.Items.AddRange(New Object() {"Laboratorium", "Non Laboratorium/Pemeriksaan Fisik", "Non Laboratorium/Thorax", "Non Laboratorium/Audiometri", "Non Laboratorium/Spirometri", "Non Laboratorium/ECG", "Non Laboratorium/USG Mammae", "Non Laboratorium/Pap Smear", "Non Laboratorium/Treadmill Test", "Non Laboratorium/Pemeriksaan Dokter Spesialis Jantung", "Non Laboratorium/Pemeriksaan Dokter Spesialis Penyakit Dalam", "Non Laboratorium/Pemeriksaan Dokter Spesialis Mata", "Non Laboratorium/Pemeriksaan Dokter Gigi", "Rekapan"})
        Me.ComboBoxFolderTujuan.Location = New System.Drawing.Point(173, 86)
        Me.ComboBoxFolderTujuan.Name = "ComboBoxFolderTujuan"
        Me.ComboBoxFolderTujuan.Size = New System.Drawing.Size(434, 25)
        Me.ComboBoxFolderTujuan.TabIndex = 459
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label17.Location = New System.Drawing.Point(15, 27)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(128, 17)
        Me.Label17.TabIndex = 458
        Me.Label17.Text = "Path Directory Data"
        '
        'ButtonPindahFile
        '
        Me.ButtonPindahFile.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonPindahFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonPindahFile.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonPindahFile.FlatAppearance.BorderSize = 0
        Me.ButtonPindahFile.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonPindahFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonPindahFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonPindahFile.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonPindahFile.ForeColor = System.Drawing.Color.White
        Me.ButtonPindahFile.Location = New System.Drawing.Point(173, 159)
        Me.ButtonPindahFile.Name = "ButtonPindahFile"
        Me.ButtonPindahFile.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonPindahFile.Size = New System.Drawing.Size(434, 30)
        Me.ButtonPindahFile.TabIndex = 457
        Me.ButtonPindahFile.Text = "Pindah File"
        Me.ButtonPindahFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonPindahFile.UseVisualStyleBackColor = False
        '
        'TextBoxPathDirectoryData
        '
        Me.TextBoxPathDirectoryData.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBoxPathDirectoryData.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxPathDirectoryData.Location = New System.Drawing.Point(173, 24)
        Me.TextBoxPathDirectoryData.Name = "TextBoxPathDirectoryData"
        Me.TextBoxPathDirectoryData.ReadOnly = True
        Me.TextBoxPathDirectoryData.Size = New System.Drawing.Size(363, 25)
        Me.TextBoxPathDirectoryData.TabIndex = 272
        '
        'SplitContainerRujukanVertikal
        '
        Me.SplitContainerRujukanVertikal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerRujukanVertikal.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainerRujukanVertikal.IsSplitterFixed = True
        Me.SplitContainerRujukanVertikal.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerRujukanVertikal.Name = "SplitContainerRujukanVertikal"
        Me.SplitContainerRujukanVertikal.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerRujukanVertikal.Panel1
        '
        Me.SplitContainerRujukanVertikal.Panel1.Controls.Add(Me.Panel7)
        Me.SplitContainerRujukanVertikal.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainerRujukanVertikal.Panel2
        '
        Me.SplitContainerRujukanVertikal.Panel2.AutoScroll = True
        Me.SplitContainerRujukanVertikal.Panel2.Controls.Add(Me.TabControlJenisAction)
        Me.SplitContainerRujukanVertikal.Size = New System.Drawing.Size(738, 415)
        Me.SplitContainerRujukanVertikal.SplitterDistance = 40
        Me.SplitContainerRujukanVertikal.SplitterWidth = 5
        Me.SplitContainerRujukanVertikal.TabIndex = 462
        '
        'TabControlJenisAction
        '
        Me.TabControlJenisAction.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControlJenisAction.Controls.Add(Me.TabExportData)
        Me.TabControlJenisAction.Controls.Add(Me.TabPindahData)
        Me.TabControlJenisAction.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlJenisAction.ItemSize = New System.Drawing.Size(125, 25)
        Me.TabControlJenisAction.Location = New System.Drawing.Point(0, 0)
        Me.TabControlJenisAction.Name = "TabControlJenisAction"
        Me.TabControlJenisAction.SelectedIndex = 0
        Me.TabControlJenisAction.Size = New System.Drawing.Size(738, 370)
        Me.TabControlJenisAction.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControlJenisAction.TabIndex = 1
        '
        'TabExportData
        '
        Me.TabExportData.AutoScroll = True
        Me.TabExportData.BackColor = System.Drawing.Color.White
        Me.TabExportData.Controls.Add(Me.CheckBoxReverse)
        Me.TabExportData.Controls.Add(Me.GroupBoxFilter)
        Me.TabExportData.Controls.Add(Me.ButtonExport)
        Me.TabExportData.Controls.Add(Me.ButtonPrint)
        Me.TabExportData.Location = New System.Drawing.Point(4, 29)
        Me.TabExportData.Name = "TabExportData"
        Me.TabExportData.Padding = New System.Windows.Forms.Padding(3)
        Me.TabExportData.Size = New System.Drawing.Size(730, 337)
        Me.TabExportData.TabIndex = 0
        Me.TabExportData.Text = "Export Data"
        Me.TabExportData.UseVisualStyleBackColor = True
        '
        'CheckBoxReverse
        '
        Me.CheckBoxReverse.AutoSize = True
        Me.CheckBoxReverse.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.CheckBoxReverse.Location = New System.Drawing.Point(187, 267)
        Me.CheckBoxReverse.Name = "CheckBoxReverse"
        Me.CheckBoxReverse.Size = New System.Drawing.Size(103, 21)
        Me.CheckBoxReverse.TabIndex = 469
        Me.CheckBoxReverse.Text = "Print Reverse"
        Me.CheckBoxReverse.UseVisualStyleBackColor = True
        '
        'ButtonPrint
        '
        Me.ButtonPrint.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonPrint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonPrint.FlatAppearance.BorderSize = 0
        Me.ButtonPrint.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonPrint.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonPrint.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonPrint.ForeColor = System.Drawing.Color.White
        Me.ButtonPrint.Location = New System.Drawing.Point(323, 262)
        Me.ButtonPrint.Name = "ButtonPrint"
        Me.ButtonPrint.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonPrint.Size = New System.Drawing.Size(150, 30)
        Me.ButtonPrint.TabIndex = 467
        Me.ButtonPrint.Text = "Print Data"
        Me.ButtonPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonPrint.UseVisualStyleBackColor = False
        '
        'TabPindahData
        '
        Me.TabPindahData.AutoScroll = True
        Me.TabPindahData.BackColor = System.Drawing.Color.White
        Me.TabPindahData.Controls.Add(Me.GroupBox1)
        Me.TabPindahData.Location = New System.Drawing.Point(4, 29)
        Me.TabPindahData.Name = "TabPindahData"
        Me.TabPindahData.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPindahData.Size = New System.Drawing.Size(742, 337)
        Me.TabPindahData.TabIndex = 1
        Me.TabPindahData.Text = "Pindah Data"
        Me.TabPindahData.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ProgressBar2)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.TextBoxLabelTambahan)
        Me.GroupBox1.Controls.Add(Me.ButtonFindPathDirectoryTujuan2)
        Me.GroupBox1.Controls.Add(Me.ButtonPindahFile)
        Me.GroupBox1.Controls.Add(Me.ButtonFindPathDirectoryData)
        Me.GroupBox1.Controls.Add(Me.ComboBoxFolderTujuan)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.TextBoxPathDirectoryData)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TextBoxPathDirectoryTujuan2)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(615, 230)
        Me.GroupBox1.TabIndex = 470
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pindah Data"
        '
        'ProgressBar2
        '
        Me.ProgressBar2.BackColor = System.Drawing.Color.Lime
        Me.ProgressBar2.Location = New System.Drawing.Point(18, 148)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(589, 5)
        Me.ProgressBar2.TabIndex = 241
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(15, 120)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 17)
        Me.Label5.TabIndex = 469
        Me.Label5.Text = "Label Tambahan"
        '
        'TextBoxLabelTambahan
        '
        Me.TextBoxLabelTambahan.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBoxLabelTambahan.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxLabelTambahan.Location = New System.Drawing.Point(173, 117)
        Me.TextBoxLabelTambahan.Name = "TextBoxLabelTambahan"
        Me.TextBoxLabelTambahan.Size = New System.Drawing.Size(124, 25)
        Me.TextBoxLabelTambahan.TabIndex = 468
        '
        'ButtonFindPathDirectoryTujuan2
        '
        Me.ButtonFindPathDirectoryTujuan2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindPathDirectoryTujuan2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonFindPathDirectoryTujuan2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonFindPathDirectoryTujuan2.FlatAppearance.BorderSize = 0
        Me.ButtonFindPathDirectoryTujuan2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindPathDirectoryTujuan2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonFindPathDirectoryTujuan2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonFindPathDirectoryTujuan2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonFindPathDirectoryTujuan2.ForeColor = System.Drawing.Color.White
        Me.ButtonFindPathDirectoryTujuan2.Location = New System.Drawing.Point(542, 55)
        Me.ButtonFindPathDirectoryTujuan2.Name = "ButtonFindPathDirectoryTujuan2"
        Me.ButtonFindPathDirectoryTujuan2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonFindPathDirectoryTujuan2.Size = New System.Drawing.Size(65, 25)
        Me.ButtonFindPathDirectoryTujuan2.TabIndex = 467
        Me.ButtonFindPathDirectoryTujuan2.Text = "Cari"
        Me.ButtonFindPathDirectoryTujuan2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonFindPathDirectoryTujuan2.UseVisualStyleBackColor = False
        '
        'ButtonFindPathDirectoryData
        '
        Me.ButtonFindPathDirectoryData.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindPathDirectoryData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonFindPathDirectoryData.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonFindPathDirectoryData.FlatAppearance.BorderSize = 0
        Me.ButtonFindPathDirectoryData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindPathDirectoryData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonFindPathDirectoryData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonFindPathDirectoryData.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonFindPathDirectoryData.ForeColor = System.Drawing.Color.White
        Me.ButtonFindPathDirectoryData.Location = New System.Drawing.Point(542, 24)
        Me.ButtonFindPathDirectoryData.Name = "ButtonFindPathDirectoryData"
        Me.ButtonFindPathDirectoryData.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonFindPathDirectoryData.Size = New System.Drawing.Size(65, 25)
        Me.ButtonFindPathDirectoryData.TabIndex = 464
        Me.ButtonFindPathDirectoryData.Text = "Cari"
        Me.ButtonFindPathDirectoryData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonFindPathDirectoryData.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(15, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(140, 17)
        Me.Label4.TabIndex = 466
        Me.Label4.Text = "Path Directory Tujuan"
        '
        'TextBoxPathDirectoryTujuan2
        '
        Me.TextBoxPathDirectoryTujuan2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBoxPathDirectoryTujuan2.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxPathDirectoryTujuan2.Location = New System.Drawing.Point(173, 55)
        Me.TextBoxPathDirectoryTujuan2.Name = "TextBoxPathDirectoryTujuan2"
        Me.TextBoxPathDirectoryTujuan2.ReadOnly = True
        Me.TextBoxPathDirectoryTujuan2.Size = New System.Drawing.Size(363, 25)
        Me.TextBoxPathDirectoryTujuan2.TabIndex = 465
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.PanelTop.Controls.Add(Me.ButtonClose)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(738, 35)
        Me.PanelTop.TabIndex = 463
        '
        'ButtonClose
        '
        Me.ButtonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.ButtonClose.FlatAppearance.BorderSize = 0
        Me.ButtonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonClose.Image = CType(resources.GetObject("ButtonClose.Image"), System.Drawing.Image)
        Me.ButtonClose.Location = New System.Drawing.Point(698, 0)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(40, 35)
        Me.ButtonClose.TabIndex = 281
        Me.ButtonClose.UseVisualStyleBackColor = True
        '
        'PanelMainMenu
        '
        Me.PanelMainMenu.Controls.Add(Me.SplitContainerRujukanVertikal)
        Me.PanelMainMenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMainMenu.Location = New System.Drawing.Point(0, 35)
        Me.PanelMainMenu.Name = "PanelMainMenu"
        Me.PanelMainMenu.Size = New System.Drawing.Size(738, 415)
        Me.PanelMainMenu.TabIndex = 464
        '
        'ExportReportLaboratorium
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(738, 450)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelMainMenu)
        Me.Controls.Add(Me.PanelTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ExportReportLaboratorium"
        Me.GroupBoxFilter.ResumeLayout(False)
        Me.GroupBoxFilter.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.SplitContainerRujukanVertikal.Panel1.ResumeLayout(False)
        Me.SplitContainerRujukanVertikal.Panel1.PerformLayout()
        Me.SplitContainerRujukanVertikal.Panel2.ResumeLayout(False)
        Me.SplitContainerRujukanVertikal.ResumeLayout(False)
        Me.TabControlJenisAction.ResumeLayout(False)
        Me.TabExportData.ResumeLayout(False)
        Me.TabExportData.PerformLayout()
        Me.TabPindahData.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.PanelTop.ResumeLayout(False)
        Me.PanelMainMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents rdOnline As System.Windows.Forms.RadioButton
    Friend WithEvents rdOffline As System.Windows.Forms.RadioButton
    Friend WithEvents txloc As System.Windows.Forms.TextBox
    Friend WithEvents NamaLokasi As System.Windows.Forms.Label
    Friend WithEvents txidloc As System.Windows.Forms.TextBox
    Friend WithEvents txkodecabang As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txcompanycode As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents dtprocess As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextBoxPathDirectoryData As System.Windows.Forms.TextBox
    Friend WithEvents ButtonPindahFile As System.Windows.Forms.Button
    Friend WithEvents ButtonExport As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxFolderTujuan As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents GroupBoxFilter As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonFindCompany As System.Windows.Forms.Button
    Friend WithEvents ButtonFindLokasi As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents RadioButtonExportData As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonPindahData As System.Windows.Forms.RadioButton
    Friend WithEvents SplitContainerRujukanVertikal As System.Windows.Forms.SplitContainer
    Friend WithEvents TabControlJenisAction As System.Windows.Forms.TabControl
    Friend WithEvents TabExportData As System.Windows.Forms.TabPage
    Friend WithEvents TabPindahData As System.Windows.Forms.TabPage
    Friend WithEvents ButtonFindPathDirectoryTujuan1 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBoxPathDirectoryTujuan1 As System.Windows.Forms.TextBox
    Friend WithEvents ButtonFindPathDirectoryData As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ButtonFindPathDirectoryTujuan2 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBoxPathDirectoryTujuan2 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBoxLabelTambahan As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ProgressBar2 As System.Windows.Forms.ProgressBar
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents ButtonClose As System.Windows.Forms.Button
    Friend WithEvents PanelMainMenu As System.Windows.Forms.Panel
    Friend WithEvents ButtonPrint As System.Windows.Forms.Button
    Friend WithEvents CheckBoxFisik As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxThorax As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxLaboratorium As System.Windows.Forms.CheckBox
    Friend WithEvents TextBoxNoUrut2 As System.Windows.Forms.TextBox
    Friend WithEvents CheckBoxNoUrut As System.Windows.Forms.CheckBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNoUrut1 As System.Windows.Forms.TextBox
    Friend WithEvents CheckBoxReverse As System.Windows.Forms.CheckBox
End Class
