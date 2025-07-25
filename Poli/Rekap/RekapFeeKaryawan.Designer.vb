<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RekapFeeKaryawan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RekapFeeKaryawan))
        Me.PanelTop = New System.Windows.Forms.Panel
        Me.ButtonClose = New System.Windows.Forms.Button
        Me.PanelRekapFeeKaryawan = New System.Windows.Forms.Panel
        Me.SplitContainerMainMenu = New System.Windows.Forms.SplitContainer
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.ButtonSimpanRekap = New System.Windows.Forms.Button
        Me.ButtonClearData = New System.Windows.Forms.Button
        Me.ButtonCetakLaporan = New System.Windows.Forms.Button
        Me.ButtonExportCSV = New System.Windows.Forms.Button
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer
        Me.PanelMasterTindakan = New System.Windows.Forms.Panel
        Me.CheckBoxSelectAllOption = New System.Windows.Forms.CheckBox
        Me.ButtonFindTransaksi = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.DateTimePickerAkhirTransaksi = New System.Windows.Forms.DateTimePicker
        Me.DateTimeAwalTransaksi = New System.Windows.Forms.DateTimePicker
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.RadioButtonPilihanKonsultasi = New System.Windows.Forms.RadioButton
        Me.RadioButtonPilihanTindakan = New System.Windows.Forms.RadioButton
        Me.Label18 = New System.Windows.Forms.Label
        Me.TextBoxPelaksanaID = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.ButtonFindPractitioner = New System.Windows.Forms.Button
        Me.TextBoxNamaPelaksana = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.RadioButtonPelaksanaDokter = New System.Windows.Forms.RadioButton
        Me.RadioButtonPelaksanaPerawat = New System.Windows.Forms.RadioButton
        Me.GridControlTransaksi = New DevExpress.XtraGrid.GridControl
        Me.GridViewTransaksi = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.PanelTop.SuspendLayout()
        Me.PanelRekapFeeKaryawan.SuspendLayout()
        Me.SplitContainerMainMenu.Panel1.SuspendLayout()
        Me.SplitContainerMainMenu.Panel2.SuspendLayout()
        Me.SplitContainerMainMenu.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.PanelMasterTindakan.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.GridControlTransaksi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewTransaksi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.PanelTop.Controls.Add(Me.ButtonClose)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(1000, 35)
        Me.PanelTop.TabIndex = 464
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
        'PanelRekapFeeKaryawan
        '
        Me.PanelRekapFeeKaryawan.Controls.Add(Me.SplitContainerMainMenu)
        Me.PanelRekapFeeKaryawan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelRekapFeeKaryawan.Location = New System.Drawing.Point(0, 35)
        Me.PanelRekapFeeKaryawan.Name = "PanelRekapFeeKaryawan"
        Me.PanelRekapFeeKaryawan.Size = New System.Drawing.Size(1000, 665)
        Me.PanelRekapFeeKaryawan.TabIndex = 465
        '
        'SplitContainerMainMenu
        '
        Me.SplitContainerMainMenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerMainMenu.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainerMainMenu.IsSplitterFixed = True
        Me.SplitContainerMainMenu.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerMainMenu.Name = "SplitContainerMainMenu"
        Me.SplitContainerMainMenu.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerMainMenu.Panel1
        '
        Me.SplitContainerMainMenu.Panel1.Controls.Add(Me.FlowLayoutPanel1)
        '
        'SplitContainerMainMenu.Panel2
        '
        Me.SplitContainerMainMenu.Panel2.AutoScroll = True
        Me.SplitContainerMainMenu.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainerMainMenu.Size = New System.Drawing.Size(1000, 665)
        Me.SplitContainerMainMenu.SplitterDistance = 45
        Me.SplitContainerMainMenu.SplitterWidth = 1
        Me.SplitContainerMainMenu.TabIndex = 462
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.FlowLayoutPanel1.Controls.Add(Me.ButtonSimpanRekap)
        Me.FlowLayoutPanel1.Controls.Add(Me.ButtonClearData)
        Me.FlowLayoutPanel1.Controls.Add(Me.ButtonCetakLaporan)
        Me.FlowLayoutPanel1.Controls.Add(Me.ButtonExportCSV)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(1000, 45)
        Me.FlowLayoutPanel1.TabIndex = 538
        '
        'ButtonSimpanRekap
        '
        Me.ButtonSimpanRekap.BackColor = System.Drawing.Color.White
        Me.ButtonSimpanRekap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonSimpanRekap.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonSimpanRekap.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSimpanRekap.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonSimpanRekap.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSimpanRekap.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSimpanRekap.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSimpanRekap.Image = CType(resources.GetObject("ButtonSimpanRekap.Image"), System.Drawing.Image)
        Me.ButtonSimpanRekap.Location = New System.Drawing.Point(3, 3)
        Me.ButtonSimpanRekap.Name = "ButtonSimpanRekap"
        Me.ButtonSimpanRekap.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonSimpanRekap.Size = New System.Drawing.Size(150, 40)
        Me.ButtonSimpanRekap.TabIndex = 580
        Me.ButtonSimpanRekap.Text = " Simpan Rekap"
        Me.ButtonSimpanRekap.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonSimpanRekap.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonSimpanRekap.UseVisualStyleBackColor = False
        '
        'ButtonClearData
        '
        Me.ButtonClearData.BackColor = System.Drawing.Color.White
        Me.ButtonClearData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonClearData.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonClearData.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonClearData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonClearData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonClearData.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonClearData.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonClearData.Image = CType(resources.GetObject("ButtonClearData.Image"), System.Drawing.Image)
        Me.ButtonClearData.Location = New System.Drawing.Point(159, 3)
        Me.ButtonClearData.Name = "ButtonClearData"
        Me.ButtonClearData.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonClearData.Size = New System.Drawing.Size(150, 40)
        Me.ButtonClearData.TabIndex = 581
        Me.ButtonClearData.Text = " Clear Data"
        Me.ButtonClearData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonClearData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonClearData.UseVisualStyleBackColor = False
        '
        'ButtonCetakLaporan
        '
        Me.ButtonCetakLaporan.BackColor = System.Drawing.Color.White
        Me.ButtonCetakLaporan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonCetakLaporan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonCetakLaporan.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCetakLaporan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonCetakLaporan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCetakLaporan.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCetakLaporan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCetakLaporan.Image = CType(resources.GetObject("ButtonCetakLaporan.Image"), System.Drawing.Image)
        Me.ButtonCetakLaporan.Location = New System.Drawing.Point(315, 3)
        Me.ButtonCetakLaporan.Name = "ButtonCetakLaporan"
        Me.ButtonCetakLaporan.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonCetakLaporan.Size = New System.Drawing.Size(150, 40)
        Me.ButtonCetakLaporan.TabIndex = 579
        Me.ButtonCetakLaporan.Text = " Cetak Laporan"
        Me.ButtonCetakLaporan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonCetakLaporan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonCetakLaporan.UseVisualStyleBackColor = False
        '
        'ButtonExportCSV
        '
        Me.ButtonExportCSV.BackColor = System.Drawing.Color.White
        Me.ButtonExportCSV.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonExportCSV.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonExportCSV.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonExportCSV.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonExportCSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonExportCSV.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonExportCSV.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonExportCSV.Image = CType(resources.GetObject("ButtonExportCSV.Image"), System.Drawing.Image)
        Me.ButtonExportCSV.Location = New System.Drawing.Point(471, 3)
        Me.ButtonExportCSV.Name = "ButtonExportCSV"
        Me.ButtonExportCSV.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonExportCSV.Size = New System.Drawing.Size(150, 40)
        Me.ButtonExportCSV.TabIndex = 580
        Me.ButtonExportCSV.Text = " Export To CSV"
        Me.ButtonExportCSV.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonExportCSV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonExportCSV.UseVisualStyleBackColor = False
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer3.IsSplitterFixed = True
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.AutoScroll = True
        Me.SplitContainer3.Panel1.BackColor = System.Drawing.Color.White
        Me.SplitContainer3.Panel1.Controls.Add(Me.PanelMasterTindakan)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.AutoScroll = True
        Me.SplitContainer3.Panel2.Controls.Add(Me.GridControlTransaksi)
        Me.SplitContainer3.Size = New System.Drawing.Size(1000, 619)
        Me.SplitContainer3.SplitterDistance = 225
        Me.SplitContainer3.SplitterWidth = 1
        Me.SplitContainer3.TabIndex = 462
        '
        'PanelMasterTindakan
        '
        Me.PanelMasterTindakan.AutoScroll = True
        Me.PanelMasterTindakan.Controls.Add(Me.CheckBoxSelectAllOption)
        Me.PanelMasterTindakan.Controls.Add(Me.ButtonFindTransaksi)
        Me.PanelMasterTindakan.Controls.Add(Me.Label9)
        Me.PanelMasterTindakan.Controls.Add(Me.DateTimePickerAkhirTransaksi)
        Me.PanelMasterTindakan.Controls.Add(Me.DateTimeAwalTransaksi)
        Me.PanelMasterTindakan.Controls.Add(Me.Panel5)
        Me.PanelMasterTindakan.Controls.Add(Me.Label18)
        Me.PanelMasterTindakan.Controls.Add(Me.TextBoxPelaksanaID)
        Me.PanelMasterTindakan.Controls.Add(Me.Label19)
        Me.PanelMasterTindakan.Controls.Add(Me.Label15)
        Me.PanelMasterTindakan.Controls.Add(Me.ButtonFindPractitioner)
        Me.PanelMasterTindakan.Controls.Add(Me.TextBoxNamaPelaksana)
        Me.PanelMasterTindakan.Controls.Add(Me.Label20)
        Me.PanelMasterTindakan.Controls.Add(Me.Panel1)
        Me.PanelMasterTindakan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMasterTindakan.Location = New System.Drawing.Point(0, 0)
        Me.PanelMasterTindakan.Name = "PanelMasterTindakan"
        Me.PanelMasterTindakan.Size = New System.Drawing.Size(1000, 225)
        Me.PanelMasterTindakan.TabIndex = 563
        '
        'CheckBoxSelectAllOption
        '
        Me.CheckBoxSelectAllOption.AutoSize = True
        Me.CheckBoxSelectAllOption.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.CheckBoxSelectAllOption.Location = New System.Drawing.Point(393, 174)
        Me.CheckBoxSelectAllOption.Name = "CheckBoxSelectAllOption"
        Me.CheckBoxSelectAllOption.Size = New System.Drawing.Size(88, 19)
        Me.CheckBoxSelectAllOption.TabIndex = 576
        Me.CheckBoxSelectAllOption.Text = "Pilih Semua"
        Me.CheckBoxSelectAllOption.UseVisualStyleBackColor = True
        '
        'ButtonFindTransaksi
        '
        Me.ButtonFindTransaksi.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindTransaksi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonFindTransaksi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonFindTransaksi.FlatAppearance.BorderSize = 0
        Me.ButtonFindTransaksi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindTransaksi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonFindTransaksi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonFindTransaksi.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonFindTransaksi.ForeColor = System.Drawing.Color.White
        Me.ButtonFindTransaksi.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_view_24
        Me.ButtonFindTransaksi.Location = New System.Drawing.Point(195, 165)
        Me.ButtonFindTransaksi.Name = "ButtonFindTransaksi"
        Me.ButtonFindTransaksi.Size = New System.Drawing.Size(192, 35)
        Me.ButtonFindTransaksi.TabIndex = 575
        Me.ButtonFindTransaksi.Text = " Cari Data"
        Me.ButtonFindTransaksi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonFindTransaksi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonFindTransaksi.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label9.Location = New System.Drawing.Point(326, 113)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(24, 15)
        Me.Label9.TabIndex = 574
        Me.Label9.Text = "s/d"
        '
        'DateTimePickerAkhirTransaksi
        '
        Me.DateTimePickerAkhirTransaksi.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerAkhirTransaksi.CustomFormat = "dd-MMM-yyyy"
        Me.DateTimePickerAkhirTransaksi.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DateTimePickerAkhirTransaksi.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerAkhirTransaksi.Location = New System.Drawing.Point(356, 107)
        Me.DateTimePickerAkhirTransaksi.Name = "DateTimePickerAkhirTransaksi"
        Me.DateTimePickerAkhirTransaksi.Size = New System.Drawing.Size(125, 23)
        Me.DateTimePickerAkhirTransaksi.TabIndex = 573
        '
        'DateTimeAwalTransaksi
        '
        Me.DateTimeAwalTransaksi.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimeAwalTransaksi.CustomFormat = "dd-MMM-yyyy"
        Me.DateTimeAwalTransaksi.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DateTimeAwalTransaksi.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimeAwalTransaksi.Location = New System.Drawing.Point(195, 108)
        Me.DateTimeAwalTransaksi.Name = "DateTimeAwalTransaksi"
        Me.DateTimeAwalTransaksi.Size = New System.Drawing.Size(125, 23)
        Me.DateTimeAwalTransaksi.TabIndex = 572
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Transparent
        Me.Panel5.Controls.Add(Me.RadioButtonPilihanKonsultasi)
        Me.Panel5.Controls.Add(Me.RadioButtonPilihanTindakan)
        Me.Panel5.Location = New System.Drawing.Point(195, 137)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(286, 25)
        Me.Panel5.TabIndex = 571
        '
        'RadioButtonPilihanKonsultasi
        '
        Me.RadioButtonPilihanKonsultasi.AutoSize = True
        Me.RadioButtonPilihanKonsultasi.Checked = True
        Me.RadioButtonPilihanKonsultasi.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.RadioButtonPilihanKonsultasi.Location = New System.Drawing.Point(5, 3)
        Me.RadioButtonPilihanKonsultasi.Name = "RadioButtonPilihanKonsultasi"
        Me.RadioButtonPilihanKonsultasi.Size = New System.Drawing.Size(79, 19)
        Me.RadioButtonPilihanKonsultasi.TabIndex = 245
        Me.RadioButtonPilihanKonsultasi.TabStop = True
        Me.RadioButtonPilihanKonsultasi.Text = "Konsultasi"
        Me.RadioButtonPilihanKonsultasi.UseVisualStyleBackColor = True
        '
        'RadioButtonPilihanTindakan
        '
        Me.RadioButtonPilihanTindakan.AutoSize = True
        Me.RadioButtonPilihanTindakan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.RadioButtonPilihanTindakan.Location = New System.Drawing.Point(90, 3)
        Me.RadioButtonPilihanTindakan.Name = "RadioButtonPilihanTindakan"
        Me.RadioButtonPilihanTindakan.Size = New System.Drawing.Size(73, 19)
        Me.RadioButtonPilihanTindakan.TabIndex = 246
        Me.RadioButtonPilihanTindakan.Text = "Tindakan"
        Me.RadioButtonPilihanTindakan.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label18.Location = New System.Drawing.Point(28, 20)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(101, 17)
        Me.Label18.TabIndex = 528
        Me.Label18.Text = "Jenis Pelaksana"
        '
        'TextBoxPelaksanaID
        '
        Me.TextBoxPelaksanaID.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.TextBoxPelaksanaID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxPelaksanaID.Cursor = System.Windows.Forms.Cursors.No
        Me.TextBoxPelaksanaID.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TextBoxPelaksanaID.Location = New System.Drawing.Point(261, 50)
        Me.TextBoxPelaksanaID.Name = "TextBoxPelaksanaID"
        Me.TextBoxPelaksanaID.ReadOnly = True
        Me.TextBoxPelaksanaID.Size = New System.Drawing.Size(84, 23)
        Me.TextBoxPelaksanaID.TabIndex = 526
        Me.TextBoxPelaksanaID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label19.Location = New System.Drawing.Point(28, 79)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(108, 17)
        Me.Label19.TabIndex = 525
        Me.Label19.Text = "Nama Pelaksana"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label15.Location = New System.Drawing.Point(28, 140)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(96, 17)
        Me.Label15.TabIndex = 560
        Me.Label15.Text = "Jenis Transaksi"
        '
        'ButtonFindPractitioner
        '
        Me.ButtonFindPractitioner.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindPractitioner.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonFindPractitioner.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonFindPractitioner.FlatAppearance.BorderSize = 0
        Me.ButtonFindPractitioner.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindPractitioner.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonFindPractitioner.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonFindPractitioner.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonFindPractitioner.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ButtonFindPractitioner.Location = New System.Drawing.Point(195, 48)
        Me.ButtonFindPractitioner.Name = "ButtonFindPractitioner"
        Me.ButtonFindPractitioner.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonFindPractitioner.Size = New System.Drawing.Size(60, 25)
        Me.ButtonFindPractitioner.TabIndex = 527
        Me.ButtonFindPractitioner.Text = " Cari"
        Me.ButtonFindPractitioner.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonFindPractitioner.UseVisualStyleBackColor = False
        '
        'TextBoxNamaPelaksana
        '
        Me.TextBoxNamaPelaksana.BackColor = System.Drawing.Color.White
        Me.TextBoxNamaPelaksana.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxNamaPelaksana.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBoxNamaPelaksana.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TextBoxNamaPelaksana.Location = New System.Drawing.Point(195, 79)
        Me.TextBoxNamaPelaksana.Name = "TextBoxNamaPelaksana"
        Me.TextBoxNamaPelaksana.ReadOnly = True
        Me.TextBoxNamaPelaksana.Size = New System.Drawing.Size(286, 23)
        Me.TextBoxNamaPelaksana.TabIndex = 531
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label20.Location = New System.Drawing.Point(28, 111)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(114, 17)
        Me.Label20.TabIndex = 558
        Me.Label20.Text = "Tanggal Transaksi"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.RadioButtonPelaksanaDokter)
        Me.Panel1.Controls.Add(Me.RadioButtonPelaksanaPerawat)
        Me.Panel1.Location = New System.Drawing.Point(195, 17)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(286, 25)
        Me.Panel1.TabIndex = 555
        '
        'RadioButtonPelaksanaDokter
        '
        Me.RadioButtonPelaksanaDokter.AutoSize = True
        Me.RadioButtonPelaksanaDokter.Checked = True
        Me.RadioButtonPelaksanaDokter.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.RadioButtonPelaksanaDokter.Location = New System.Drawing.Point(5, 3)
        Me.RadioButtonPelaksanaDokter.Name = "RadioButtonPelaksanaDokter"
        Me.RadioButtonPelaksanaDokter.Size = New System.Drawing.Size(60, 19)
        Me.RadioButtonPelaksanaDokter.TabIndex = 245
        Me.RadioButtonPelaksanaDokter.TabStop = True
        Me.RadioButtonPelaksanaDokter.Text = "Dokter"
        Me.RadioButtonPelaksanaDokter.UseVisualStyleBackColor = True
        '
        'RadioButtonPelaksanaPerawat
        '
        Me.RadioButtonPelaksanaPerawat.AutoSize = True
        Me.RadioButtonPelaksanaPerawat.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.RadioButtonPelaksanaPerawat.Location = New System.Drawing.Point(71, 3)
        Me.RadioButtonPelaksanaPerawat.Name = "RadioButtonPelaksanaPerawat"
        Me.RadioButtonPelaksanaPerawat.Size = New System.Drawing.Size(67, 19)
        Me.RadioButtonPelaksanaPerawat.TabIndex = 246
        Me.RadioButtonPelaksanaPerawat.Text = "Perawat"
        Me.RadioButtonPelaksanaPerawat.UseVisualStyleBackColor = True
        '
        'GridControlTransaksi
        '
        Me.GridControlTransaksi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControlTransaksi.EmbeddedNavigator.Name = ""
        Me.GridControlTransaksi.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GridControlTransaksi.Location = New System.Drawing.Point(0, 0)
        Me.GridControlTransaksi.MainView = Me.GridViewTransaksi
        Me.GridControlTransaksi.Name = "GridControlTransaksi"
        Me.GridControlTransaksi.Size = New System.Drawing.Size(1000, 393)
        Me.GridControlTransaksi.TabIndex = 187
        Me.GridControlTransaksi.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewTransaksi})
        '
        'GridViewTransaksi
        '
        Me.GridViewTransaksi.GridControl = Me.GridControlTransaksi
        Me.GridViewTransaksi.Name = "GridViewTransaksi"
        Me.GridViewTransaksi.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridViewTransaksi.OptionsView.ShowGroupPanel = False
        Me.GridViewTransaksi.OptionsView.ShowIndicator = False
        Me.GridViewTransaksi.PaintStyleName = "Skin"
        '
        'RekapFeeKaryawan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1000, 700)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelRekapFeeKaryawan)
        Me.Controls.Add(Me.PanelTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "RekapFeeKaryawan"
        Me.PanelTop.ResumeLayout(False)
        Me.PanelRekapFeeKaryawan.ResumeLayout(False)
        Me.SplitContainerMainMenu.Panel1.ResumeLayout(False)
        Me.SplitContainerMainMenu.Panel2.ResumeLayout(False)
        Me.SplitContainerMainMenu.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.ResumeLayout(False)
        Me.PanelMasterTindakan.ResumeLayout(False)
        Me.PanelMasterTindakan.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.GridControlTransaksi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewTransaksi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents ButtonClose As System.Windows.Forms.Button
    Friend WithEvents PanelRekapFeeKaryawan As System.Windows.Forms.Panel
    Friend WithEvents SplitContainerMainMenu As System.Windows.Forms.SplitContainer
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents TextBoxNamaPelaksana As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents ButtonFindPractitioner As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TextBoxPelaksanaID As System.Windows.Forms.TextBox
    Friend WithEvents RadioButtonPelaksanaDokter As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonPelaksanaPerawat As System.Windows.Forms.RadioButton
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents PanelMasterTindakan As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents RadioButtonPilihanKonsultasi As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonPilihanTindakan As System.Windows.Forms.RadioButton
    Friend WithEvents DateTimeAwalTransaksi As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerAkhirTransaksi As System.Windows.Forms.DateTimePicker
    Friend WithEvents ButtonFindTransaksi As System.Windows.Forms.Button
    Friend WithEvents CheckBoxSelectAllOption As System.Windows.Forms.CheckBox
    Private WithEvents GridControlTransaksi As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewTransaksi As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ButtonSimpanRekap As System.Windows.Forms.Button
    Friend WithEvents ButtonCetakLaporan As System.Windows.Forms.Button
    Friend WithEvents ButtonClearData As System.Windows.Forms.Button
    Friend WithEvents ButtonExportCSV As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
