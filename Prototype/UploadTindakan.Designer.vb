<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UploadTindakan
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UploadTindakan))
        Me.DataGridViewTindakan = New System.Windows.Forms.DataGridView
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ButtonClearData = New System.Windows.Forms.Button
        Me.ButtonDownloadTemplate = New System.Windows.Forms.Button
        Me.ButtonUploadData = New System.Windows.Forms.Button
        Me.ButtonSimpanData = New System.Windows.Forms.Button
        Me.ButtonValidasiData = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.RadioButtonPoliUmum = New System.Windows.Forms.RadioButton
        Me.RadioButtonPoliGigi = New System.Windows.Forms.RadioButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.PanelKeadaanUmumMenuPemeriksaanAwal = New System.Windows.Forms.Panel
        Me.RadioButtonTindakan = New System.Windows.Forms.RadioButton
        Me.RadioButtonTindakanDetail = New System.Windows.Forms.RadioButton
        Me.Label15 = New System.Windows.Forms.Label
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.Label2 = New System.Windows.Forms.Label
        Me.PanelTop = New System.Windows.Forms.Panel
        Me.ButtonClose = New System.Windows.Forms.Button
        Me.SplitContainer7 = New System.Windows.Forms.SplitContainer
        Me.BtnUpload = New System.Windows.Forms.Button
        Me.PBGambar = New System.Windows.Forms.PictureBox
        Me.TextBoxKeterangan = New System.Windows.Forms.TextBox
        Me.BtnSimpanGambar = New System.Windows.Forms.Button
        Me.PictureBoxPreview = New System.Windows.Forms.PictureBox
        Me.ComboBoxKeterangan = New System.Windows.Forms.ComboBox
        CType(Me.DataGridViewTindakan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.SuspendLayout()
        Me.PanelTop.SuspendLayout()
        Me.SplitContainer7.Panel1.SuspendLayout()
        Me.SplitContainer7.Panel2.SuspendLayout()
        Me.SplitContainer7.SuspendLayout()
        CType(Me.PBGambar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxPreview, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridViewTindakan
        '
        Me.DataGridViewTindakan.AllowUserToAddRows = False
        Me.DataGridViewTindakan.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(225, Byte), Integer), CType(CType(247, Byte), Integer), CType(CType(231, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(3)
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTindakan.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewTindakan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridViewTindakan.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridViewTindakan.BackgroundColor = System.Drawing.Color.White
        Me.DataGridViewTindakan.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridViewTindakan.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DataGridViewTindakan.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(218, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(3)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTindakan.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewTindakan.ColumnHeadersHeight = 70
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.Padding = New System.Windows.Forms.Padding(3)
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(186, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(149, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTindakan.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTindakan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewTindakan.EnableHeadersVisualStyles = False
        Me.DataGridViewTindakan.Location = New System.Drawing.Point(0, 0)
        Me.DataGridViewTindakan.Name = "DataGridViewTindakan"
        Me.DataGridViewTindakan.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle4.Padding = New System.Windows.Forms.Padding(3)
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTindakan.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewTindakan.RowHeadersVisible = False
        Me.DataGridViewTindakan.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.DataGridViewTindakan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridViewTindakan.Size = New System.Drawing.Size(1000, 469)
        Me.DataGridViewTindakan.StandardTab = True
        Me.DataGridViewTindakan.TabIndex = 518
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.ButtonClearData)
        Me.Panel1.Controls.Add(Me.ButtonDownloadTemplate)
        Me.Panel1.Controls.Add(Me.ButtonUploadData)
        Me.Panel1.Controls.Add(Me.ButtonSimpanData)
        Me.Panel1.Controls.Add(Me.ButtonValidasiData)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.PanelKeadaanUmumMenuPemeriksaanAwal)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.ProgressBar1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1000, 175)
        Me.Panel1.TabIndex = 236
        '
        'ButtonClearData
        '
        Me.ButtonClearData.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonClearData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonClearData.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonClearData.FlatAppearance.BorderSize = 0
        Me.ButtonClearData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonClearData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonClearData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonClearData.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonClearData.ForeColor = System.Drawing.Color.White
        Me.ButtonClearData.Location = New System.Drawing.Point(285, 23)
        Me.ButtonClearData.Name = "ButtonClearData"
        Me.ButtonClearData.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonClearData.Size = New System.Drawing.Size(150, 30)
        Me.ButtonClearData.TabIndex = 519
        Me.ButtonClearData.Text = "Clear Data"
        Me.ButtonClearData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonClearData.UseVisualStyleBackColor = False
        '
        'ButtonDownloadTemplate
        '
        Me.ButtonDownloadTemplate.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonDownloadTemplate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonDownloadTemplate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonDownloadTemplate.FlatAppearance.BorderSize = 0
        Me.ButtonDownloadTemplate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonDownloadTemplate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonDownloadTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonDownloadTemplate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonDownloadTemplate.ForeColor = System.Drawing.Color.White
        Me.ButtonDownloadTemplate.Location = New System.Drawing.Point(441, 23)
        Me.ButtonDownloadTemplate.Name = "ButtonDownloadTemplate"
        Me.ButtonDownloadTemplate.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonDownloadTemplate.Size = New System.Drawing.Size(150, 30)
        Me.ButtonDownloadTemplate.TabIndex = 518
        Me.ButtonDownloadTemplate.Text = "Download Master Data"
        Me.ButtonDownloadTemplate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonDownloadTemplate.UseVisualStyleBackColor = False
        '
        'ButtonUploadData
        '
        Me.ButtonUploadData.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonUploadData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonUploadData.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonUploadData.FlatAppearance.BorderSize = 0
        Me.ButtonUploadData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonUploadData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonUploadData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonUploadData.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonUploadData.ForeColor = System.Drawing.Color.White
        Me.ButtonUploadData.Location = New System.Drawing.Point(129, 23)
        Me.ButtonUploadData.Name = "ButtonUploadData"
        Me.ButtonUploadData.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonUploadData.Size = New System.Drawing.Size(150, 30)
        Me.ButtonUploadData.TabIndex = 517
        Me.ButtonUploadData.Text = "Upload Data"
        Me.ButtonUploadData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonUploadData.UseVisualStyleBackColor = False
        '
        'ButtonSimpanData
        '
        Me.ButtonSimpanData.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSimpanData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonSimpanData.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonSimpanData.FlatAppearance.BorderSize = 0
        Me.ButtonSimpanData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSimpanData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonSimpanData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSimpanData.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonSimpanData.ForeColor = System.Drawing.Color.White
        Me.ButtonSimpanData.Location = New System.Drawing.Point(285, 126)
        Me.ButtonSimpanData.Name = "ButtonSimpanData"
        Me.ButtonSimpanData.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonSimpanData.Size = New System.Drawing.Size(150, 30)
        Me.ButtonSimpanData.TabIndex = 514
        Me.ButtonSimpanData.Text = "Simpan"
        Me.ButtonSimpanData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonSimpanData.UseVisualStyleBackColor = False
        '
        'ButtonValidasiData
        '
        Me.ButtonValidasiData.BackColor = System.Drawing.Color.White
        Me.ButtonValidasiData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonValidasiData.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonValidasiData.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonValidasiData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonValidasiData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonValidasiData.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonValidasiData.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonValidasiData.Location = New System.Drawing.Point(129, 126)
        Me.ButtonValidasiData.Name = "ButtonValidasiData"
        Me.ButtonValidasiData.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonValidasiData.Size = New System.Drawing.Size(150, 30)
        Me.ButtonValidasiData.TabIndex = 513
        Me.ButtonValidasiData.Text = "Validasi Data"
        Me.ButtonValidasiData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonValidasiData.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.RadioButtonPoliUmum)
        Me.Panel2.Controls.Add(Me.RadioButtonPoliGigi)
        Me.Panel2.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Panel2.Location = New System.Drawing.Point(129, 90)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(243, 30)
        Me.Panel2.TabIndex = 442
        '
        'RadioButtonPoliUmum
        '
        Me.RadioButtonPoliUmum.AutoSize = True
        Me.RadioButtonPoliUmum.Checked = True
        Me.RadioButtonPoliUmum.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonPoliUmum.Location = New System.Drawing.Point(5, 3)
        Me.RadioButtonPoliUmum.Name = "RadioButtonPoliUmum"
        Me.RadioButtonPoliUmum.Size = New System.Drawing.Size(89, 21)
        Me.RadioButtonPoliUmum.TabIndex = 245
        Me.RadioButtonPoliUmum.TabStop = True
        Me.RadioButtonPoliUmum.Text = "Poli Umum"
        Me.RadioButtonPoliUmum.UseVisualStyleBackColor = True
        '
        'RadioButtonPoliGigi
        '
        Me.RadioButtonPoliGigi.AutoSize = True
        Me.RadioButtonPoliGigi.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonPoliGigi.Location = New System.Drawing.Point(104, 3)
        Me.RadioButtonPoliGigi.Name = "RadioButtonPoliGigi"
        Me.RadioButtonPoliGigi.Size = New System.Drawing.Size(74, 21)
        Me.RadioButtonPoliGigi.TabIndex = 246
        Me.RadioButtonPoliGigi.Text = "Poli Gigi"
        Me.RadioButtonPoliGigi.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(17, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 17)
        Me.Label4.TabIndex = 441
        Me.Label4.Text = "Jenis Poli"
        '
        'PanelKeadaanUmumMenuPemeriksaanAwal
        '
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.BackColor = System.Drawing.Color.Transparent
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.Controls.Add(Me.RadioButtonTindakan)
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.Controls.Add(Me.RadioButtonTindakanDetail)
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.Location = New System.Drawing.Point(129, 56)
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.Name = "PanelKeadaanUmumMenuPemeriksaanAwal"
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.Size = New System.Drawing.Size(243, 30)
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.TabIndex = 440
        '
        'RadioButtonTindakan
        '
        Me.RadioButtonTindakan.AutoSize = True
        Me.RadioButtonTindakan.Checked = True
        Me.RadioButtonTindakan.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonTindakan.Location = New System.Drawing.Point(5, 3)
        Me.RadioButtonTindakan.Name = "RadioButtonTindakan"
        Me.RadioButtonTindakan.Size = New System.Drawing.Size(78, 21)
        Me.RadioButtonTindakan.TabIndex = 245
        Me.RadioButtonTindakan.TabStop = True
        Me.RadioButtonTindakan.Text = "Tindakan"
        Me.RadioButtonTindakan.UseVisualStyleBackColor = True
        '
        'RadioButtonTindakanDetail
        '
        Me.RadioButtonTindakanDetail.AutoSize = True
        Me.RadioButtonTindakanDetail.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonTindakanDetail.Location = New System.Drawing.Point(104, 3)
        Me.RadioButtonTindakanDetail.Name = "RadioButtonTindakanDetail"
        Me.RadioButtonTindakanDetail.Size = New System.Drawing.Size(115, 21)
        Me.RadioButtonTindakanDetail.TabIndex = 246
        Me.RadioButtonTindakanDetail.Text = "Tindakan Detail"
        Me.RadioButtonTindakanDetail.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label15.Location = New System.Drawing.Point(17, 61)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(84, 17)
        Me.Label15.TabIndex = 439
        Me.Label15.Text = "Jenis Upload"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.BackColor = System.Drawing.Color.Lime
        Me.ProgressBar1.Location = New System.Drawing.Point(20, 12)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(673, 5)
        Me.ProgressBar1.TabIndex = 241
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Firebrick
        Me.Label2.Location = New System.Drawing.Point(438, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(252, 45)
        Me.Label2.TabIndex = 238
        Me.Label2.Text = "Note : Klik Download untuk mendapatkan" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "format upload excel terbaru && jika ada d" & _
            "ata" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "yang kosong harap diisi -"
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.PanelTop.Controls.Add(Me.ButtonClose)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(1000, 35)
        Me.PanelTop.TabIndex = 519
        '
        'ButtonClose
        '
        Me.ButtonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.ButtonClose.FlatAppearance.BorderSize = 0
        Me.ButtonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonClose.Image = CType(resources.GetObject("ButtonClose.Image"), System.Drawing.Image)
        Me.ButtonClose.Location = New System.Drawing.Point(960, 0)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(40, 35)
        Me.ButtonClose.TabIndex = 281
        Me.ButtonClose.UseVisualStyleBackColor = True
        '
        'SplitContainer7
        '
        Me.SplitContainer7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer7.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer7.IsSplitterFixed = True
        Me.SplitContainer7.Location = New System.Drawing.Point(0, 35)
        Me.SplitContainer7.Name = "SplitContainer7"
        Me.SplitContainer7.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer7.Panel1
        '
        Me.SplitContainer7.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer7.Panel2
        '
        Me.SplitContainer7.Panel2.AutoScroll = True
        Me.SplitContainer7.Panel2.Controls.Add(Me.ComboBoxKeterangan)
        Me.SplitContainer7.Panel2.Controls.Add(Me.PictureBoxPreview)
        Me.SplitContainer7.Panel2.Controls.Add(Me.BtnSimpanGambar)
        Me.SplitContainer7.Panel2.Controls.Add(Me.TextBoxKeterangan)
        Me.SplitContainer7.Panel2.Controls.Add(Me.PBGambar)
        Me.SplitContainer7.Panel2.Controls.Add(Me.BtnUpload)
        Me.SplitContainer7.Panel2.Controls.Add(Me.DataGridViewTindakan)
        Me.SplitContainer7.Size = New System.Drawing.Size(1000, 649)
        Me.SplitContainer7.SplitterDistance = 175
        Me.SplitContainer7.SplitterWidth = 5
        Me.SplitContainer7.TabIndex = 520
        '
        'BtnUpload
        '
        Me.BtnUpload.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.BtnUpload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnUpload.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnUpload.FlatAppearance.BorderSize = 0
        Me.BtnUpload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.BtnUpload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BtnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnUpload.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BtnUpload.ForeColor = System.Drawing.Color.White
        Me.BtnUpload.Image = CType(resources.GetObject("BtnUpload.Image"), System.Drawing.Image)
        Me.BtnUpload.Location = New System.Drawing.Point(250, 355)
        Me.BtnUpload.Name = "BtnUpload"
        Me.BtnUpload.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BtnUpload.Size = New System.Drawing.Size(131, 37)
        Me.BtnUpload.TabIndex = 519
        Me.BtnUpload.Text = "Upload Gambar"
        Me.BtnUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnUpload.UseVisualStyleBackColor = False
        '
        'PBGambar
        '
        Me.PBGambar.Location = New System.Drawing.Point(20, 41)
        Me.PBGambar.Name = "PBGambar"
        Me.PBGambar.Size = New System.Drawing.Size(361, 308)
        Me.PBGambar.TabIndex = 520
        Me.PBGambar.TabStop = False
        '
        'TextBoxKeterangan
        '
        Me.TextBoxKeterangan.BackColor = System.Drawing.Color.White
        Me.TextBoxKeterangan.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxKeterangan.Location = New System.Drawing.Point(20, 355)
        Me.TextBoxKeterangan.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxKeterangan.Name = "TextBoxKeterangan"
        Me.TextBoxKeterangan.Size = New System.Drawing.Size(220, 25)
        Me.TextBoxKeterangan.TabIndex = 521
        '
        'BtnSimpanGambar
        '
        Me.BtnSimpanGambar.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.BtnSimpanGambar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.BtnSimpanGambar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSimpanGambar.FlatAppearance.BorderSize = 0
        Me.BtnSimpanGambar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.BtnSimpanGambar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.BtnSimpanGambar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSimpanGambar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.BtnSimpanGambar.ForeColor = System.Drawing.Color.White
        Me.BtnSimpanGambar.Location = New System.Drawing.Point(20, 387)
        Me.BtnSimpanGambar.Name = "BtnSimpanGambar"
        Me.BtnSimpanGambar.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.BtnSimpanGambar.Size = New System.Drawing.Size(224, 30)
        Me.BtnSimpanGambar.TabIndex = 522
        Me.BtnSimpanGambar.Text = "Simpan Gambar"
        Me.BtnSimpanGambar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.BtnSimpanGambar.UseVisualStyleBackColor = False
        '
        'PictureBoxPreview
        '
        Me.PictureBoxPreview.Location = New System.Drawing.Point(422, 41)
        Me.PictureBoxPreview.Name = "PictureBoxPreview"
        Me.PictureBoxPreview.Size = New System.Drawing.Size(360, 308)
        Me.PictureBoxPreview.TabIndex = 523
        Me.PictureBoxPreview.TabStop = False
        '
        'ComboBoxKeterangan
        '
        Me.ComboBoxKeterangan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxKeterangan.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxKeterangan.FormattingEnabled = True
        Me.ComboBoxKeterangan.Location = New System.Drawing.Point(422, 10)
        Me.ComboBoxKeterangan.Name = "ComboBoxKeterangan"
        Me.ComboBoxKeterangan.Size = New System.Drawing.Size(360, 25)
        Me.ComboBoxKeterangan.TabIndex = 524
        '
        'UploadTindakan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1000, 684)
        Me.ControlBox = False
        Me.Controls.Add(Me.SplitContainer7)
        Me.Controls.Add(Me.PanelTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "UploadTindakan"
        CType(Me.DataGridViewTindakan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.ResumeLayout(False)
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.PerformLayout()
        Me.PanelTop.ResumeLayout(False)
        Me.SplitContainer7.Panel1.ResumeLayout(False)
        Me.SplitContainer7.Panel2.ResumeLayout(False)
        Me.SplitContainer7.Panel2.PerformLayout()
        Me.SplitContainer7.ResumeLayout(False)
        CType(Me.PBGambar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxPreview, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents DataGridViewTindakan As System.Windows.Forms.DataGridView
    Friend WithEvents PanelKeadaanUmumMenuPemeriksaanAwal As System.Windows.Forms.Panel
    Friend WithEvents RadioButtonTindakan As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonTindakanDetail As System.Windows.Forms.RadioButton
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents RadioButtonPoliUmum As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonPoliGigi As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ButtonSimpanData As System.Windows.Forms.Button
    Friend WithEvents ButtonValidasiData As System.Windows.Forms.Button
    Friend WithEvents ButtonUploadData As System.Windows.Forms.Button
    Friend WithEvents ButtonDownloadTemplate As System.Windows.Forms.Button
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents ButtonClose As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer7 As System.Windows.Forms.SplitContainer
    Friend WithEvents ButtonClearData As System.Windows.Forms.Button
    Friend WithEvents ComboBoxKeterangan As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBoxPreview As System.Windows.Forms.PictureBox
    Friend WithEvents BtnSimpanGambar As System.Windows.Forms.Button
    Friend WithEvents TextBoxKeterangan As System.Windows.Forms.TextBox
    Friend WithEvents PBGambar As System.Windows.Forms.PictureBox
    Friend WithEvents BtnUpload As System.Windows.Forms.Button
End Class
