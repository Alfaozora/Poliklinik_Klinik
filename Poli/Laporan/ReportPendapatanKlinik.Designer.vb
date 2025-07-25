<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportPendapatanKlinik
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportPendapatanKlinik))
        Me.PanelTop = New System.Windows.Forms.Panel
        Me.ButtonClose = New System.Windows.Forms.Button
        Me.PanelReportPendapatanKlinik = New System.Windows.Forms.Panel
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.NavBarControl1 = New DevExpress.XtraNavBar.NavBarControl
        Me.NavBarGroup1 = New DevExpress.XtraNavBar.NavBarGroup
        Me.NavBarItemLaporanPendapatan = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarItemRekapTagihan = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarItemRekapInvoice = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarItem2 = New DevExpress.XtraNavBar.NavBarItem
        Me.TabControlMenu = New System.Windows.Forms.TabControl
        Me.TabPageLaporanPendapatan = New System.Windows.Forms.TabPage
        Me.SplitContainerLaporanPendapatanMain = New System.Windows.Forms.SplitContainer
        Me.FlowLayoutPanel4 = New System.Windows.Forms.FlowLayoutPanel
        Me.ButtonCetakLaporanPendapatan = New System.Windows.Forms.Button
        Me.ButtonClearDataLaporanPendapatan = New System.Windows.Forms.Button
        Me.SplitContainerLaporanPendapatanHeader = New System.Windows.Forms.SplitContainer
        Me.CheckBoxTransaksiNolRupiah = New System.Windows.Forms.CheckBox
        Me.CheckBoxCard = New System.Windows.Forms.CheckBox
        Me.CheckBoxDebet = New System.Windows.Forms.CheckBox
        Me.CheckBoxTunai = New System.Windows.Forms.CheckBox
        Me.CheckBoxTagihan = New System.Windows.Forms.CheckBox
        Me.Panel9 = New System.Windows.Forms.Panel
        Me.RadioButtonOptionLaporanPendapatanTagihan = New System.Windows.Forms.RadioButton
        Me.RadioButtonOptionLaporanPendapatan = New System.Windows.Forms.RadioButton
        Me.ComboBoxPoliTujuanLaporanPendapatan = New System.Windows.Forms.ComboBox
        Me.ButtonViewDataPendapatan = New System.Windows.Forms.Button
        Me.Label54 = New System.Windows.Forms.Label
        Me.TglAkhirTransaksiLaporanPendapatan = New System.Windows.Forms.DateTimePicker
        Me.TglAwalTransaksiLaporanPendapatan = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBoxNamaPerusahaanLaporanPendapatan = New System.Windows.Forms.TextBox
        Me.Label157 = New System.Windows.Forms.Label
        Me.ButtonFindPerusahaanLaporanPendapatan = New System.Windows.Forms.Button
        Me.Label203 = New System.Windows.Forms.Label
        Me.GridControlLaporanPendapatan = New DevExpress.XtraGrid.GridControl
        Me.GridViewLaporanPendapatan = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.TabPageRekapTagihan = New System.Windows.Forms.TabPage
        Me.SplitContainerRekapTagihanMain = New System.Windows.Forms.SplitContainer
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.ButtonClearDataRekapTagihan = New System.Windows.Forms.Button
        Me.SplitContainerRekapTagihanHeader = New System.Windows.Forms.SplitContainer
        Me.ButtonKirimUlangJurnal = New System.Windows.Forms.Button
        Me.TextBoxNoTagihan = New System.Windows.Forms.TextBox
        Me.PanelCreateInvoice = New System.Windows.Forms.Panel
        Me.ButtonSimpanRekapTagihan = New System.Windows.Forms.Button
        Me.TextBoxBankTransferCoa = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TextBoxBankTransferKeterangan = New System.Windows.Forms.TextBox
        Me.ButtonFindBankTagihan = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.TglJatuhTempoRekapTagihan = New System.Windows.Forms.DateTimePicker
        Me.CheckBoxSemuaTransaksiRekapTagihan = New System.Windows.Forms.CheckBox
        Me.ComboBoxJenisPoliOrTransaksi = New System.Windows.Forms.ComboBox
        Me.ButtonViewDataRekapTagihan = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.TglAkhirTransaksiRekapTagihan = New System.Windows.Forms.DateTimePicker
        Me.TglAwalTransaksiRekapTagihan = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.TextBoxNamaPerusahaanRekapTagihan = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.ButtonFindPerusahaanRekapTagihan = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.GridControlRekapTagihan = New DevExpress.XtraGrid.GridControl
        Me.GridViewRekapTagihan = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.TabPageRekapInvoice = New System.Windows.Forms.TabPage
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel
        Me.ButtonClearDataRekapInvoice = New System.Windows.Forms.Button
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer
        Me.ButtonHapusTagihan = New System.Windows.Forms.Button
        Me.ButtonCetakInvoiceTagihan = New System.Windows.Forms.Button
        Me.ButtonCetakRekapTagihan = New System.Windows.Forms.Button
        Me.TextBoxBankInvoice = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.TglJatuhTempoInvoice = New System.Windows.Forms.DateTimePicker
        Me.TglInvoice = New System.Windows.Forms.DateTimePicker
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.TextBoxNamaPerusahaanInvoice = New System.Windows.Forms.TextBox
        Me.TextBoxNomorInvoice = New System.Windows.Forms.TextBox
        Me.TextBoxNominalInvoice = New System.Windows.Forms.TextBox
        Me.ButtonCariDataInvoice = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.TglAkhirTransaksiRekapInvoice = New System.Windows.Forms.DateTimePicker
        Me.TglAwalTransaksiRekapInvoice = New System.Windows.Forms.DateTimePicker
        Me.Label13 = New System.Windows.Forms.Label
        Me.TextBoxNamaPerusahaanRekapInvoice = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.ButtonFindPerusahaanRekapInvoice = New System.Windows.Forms.Button
        Me.GridControlRekapInvoice = New DevExpress.XtraGrid.GridControl
        Me.GridViewRekapInvoice = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.PanelTop.SuspendLayout()
        Me.PanelReportPendapatanKlinik.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.NavBarControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlMenu.SuspendLayout()
        Me.TabPageLaporanPendapatan.SuspendLayout()
        Me.SplitContainerLaporanPendapatanMain.Panel1.SuspendLayout()
        Me.SplitContainerLaporanPendapatanMain.Panel2.SuspendLayout()
        Me.SplitContainerLaporanPendapatanMain.SuspendLayout()
        Me.FlowLayoutPanel4.SuspendLayout()
        Me.SplitContainerLaporanPendapatanHeader.Panel1.SuspendLayout()
        Me.SplitContainerLaporanPendapatanHeader.Panel2.SuspendLayout()
        Me.SplitContainerLaporanPendapatanHeader.SuspendLayout()
        Me.Panel9.SuspendLayout()
        CType(Me.GridControlLaporanPendapatan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewLaporanPendapatan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageRekapTagihan.SuspendLayout()
        Me.SplitContainerRekapTagihanMain.Panel1.SuspendLayout()
        Me.SplitContainerRekapTagihanMain.Panel2.SuspendLayout()
        Me.SplitContainerRekapTagihanMain.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SplitContainerRekapTagihanHeader.Panel1.SuspendLayout()
        Me.SplitContainerRekapTagihanHeader.Panel2.SuspendLayout()
        Me.SplitContainerRekapTagihanHeader.SuspendLayout()
        Me.PanelCreateInvoice.SuspendLayout()
        CType(Me.GridControlRekapTagihan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewRekapTagihan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageRekapInvoice.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.GridControlRekapInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewRekapInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'PanelReportPendapatanKlinik
        '
        Me.PanelReportPendapatanKlinik.Controls.Add(Me.SplitContainer1)
        Me.PanelReportPendapatanKlinik.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelReportPendapatanKlinik.Location = New System.Drawing.Point(0, 35)
        Me.PanelReportPendapatanKlinik.Name = "PanelReportPendapatanKlinik"
        Me.PanelReportPendapatanKlinik.Size = New System.Drawing.Size(1000, 665)
        Me.PanelReportPendapatanKlinik.TabIndex = 465
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.NavBarControl1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TabControlMenu)
        Me.SplitContainer1.Size = New System.Drawing.Size(1000, 665)
        Me.SplitContainer1.SplitterDistance = 225
        Me.SplitContainer1.TabIndex = 0
        '
        'NavBarControl1
        '
        Me.NavBarControl1.ActiveGroup = Me.NavBarGroup1
        Me.NavBarControl1.BackColor = System.Drawing.SystemColors.Control
        Me.NavBarControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NavBarControl1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarControl1.Groups.AddRange(New DevExpress.XtraNavBar.NavBarGroup() {Me.NavBarGroup1})
        Me.NavBarControl1.Items.AddRange(New DevExpress.XtraNavBar.NavBarItem() {Me.NavBarItemLaporanPendapatan, Me.NavBarItem2, Me.NavBarItemRekapTagihan, Me.NavBarItemRekapInvoice})
        Me.NavBarControl1.Location = New System.Drawing.Point(0, 0)
        Me.NavBarControl1.Name = "NavBarControl1"
        Me.NavBarControl1.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.ExplorerBar
        Me.NavBarControl1.Size = New System.Drawing.Size(225, 665)
        Me.NavBarControl1.TabIndex = 1
        Me.NavBarControl1.Text = "NavBarControl1"
        Me.NavBarControl1.View = New DevExpress.XtraNavBar.ViewInfo.StandardSkinExplorerBarViewInfoRegistrator("The Asphalt World")
        '
        'NavBarGroup1
        '
        Me.NavBarGroup1.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.NavBarGroup1.Appearance.Options.UseFont = True
        Me.NavBarGroup1.Caption = ""
        Me.NavBarGroup1.Expanded = True
        Me.NavBarGroup1.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsList
        Me.NavBarGroup1.ItemLinks.AddRange(New DevExpress.XtraNavBar.NavBarItemLink() {New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItemLaporanPendapatan), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItemRekapTagihan), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItemRekapInvoice)})
        Me.NavBarGroup1.Name = "NavBarGroup1"
        '
        'NavBarItemLaporanPendapatan
        '
        Me.NavBarItemLaporanPendapatan.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NavBarItemLaporanPendapatan.Appearance.Options.UseFont = True
        Me.NavBarItemLaporanPendapatan.AppearanceHotTracked.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.NavBarItemLaporanPendapatan.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItemLaporanPendapatan.AppearancePressed.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.NavBarItemLaporanPendapatan.AppearancePressed.Options.UseFont = True
        Me.NavBarItemLaporanPendapatan.Caption = "LAPORAN PENDAPATAN"
        Me.NavBarItemLaporanPendapatan.LargeImage = CType(resources.GetObject("NavBarItemLaporanPendapatan.LargeImage"), System.Drawing.Image)
        Me.NavBarItemLaporanPendapatan.Name = "NavBarItemLaporanPendapatan"
        Me.NavBarItemLaporanPendapatan.SmallImage = CType(resources.GetObject("NavBarItemLaporanPendapatan.SmallImage"), System.Drawing.Image)
        '
        'NavBarItemRekapTagihan
        '
        Me.NavBarItemRekapTagihan.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.NavBarItemRekapTagihan.Appearance.Options.UseFont = True
        Me.NavBarItemRekapTagihan.AppearanceHotTracked.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.NavBarItemRekapTagihan.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItemRekapTagihan.AppearancePressed.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.NavBarItemRekapTagihan.AppearancePressed.Options.UseFont = True
        Me.NavBarItemRekapTagihan.Caption = "REKAP TAGIHAN"
        Me.NavBarItemRekapTagihan.LargeImage = CType(resources.GetObject("NavBarItemRekapTagihan.LargeImage"), System.Drawing.Image)
        Me.NavBarItemRekapTagihan.Name = "NavBarItemRekapTagihan"
        Me.NavBarItemRekapTagihan.SmallImage = CType(resources.GetObject("NavBarItemRekapTagihan.SmallImage"), System.Drawing.Image)
        '
        'NavBarItemRekapInvoice
        '
        Me.NavBarItemRekapInvoice.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.NavBarItemRekapInvoice.Appearance.Options.UseFont = True
        Me.NavBarItemRekapInvoice.AppearanceHotTracked.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.NavBarItemRekapInvoice.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItemRekapInvoice.AppearancePressed.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.NavBarItemRekapInvoice.AppearancePressed.Options.UseFont = True
        Me.NavBarItemRekapInvoice.Caption = "REKAP INVOICE"
        Me.NavBarItemRekapInvoice.LargeImage = CType(resources.GetObject("NavBarItemRekapInvoice.LargeImage"), System.Drawing.Image)
        Me.NavBarItemRekapInvoice.Name = "NavBarItemRekapInvoice"
        Me.NavBarItemRekapInvoice.SmallImage = CType(resources.GetObject("NavBarItemRekapInvoice.SmallImage"), System.Drawing.Image)
        '
        'NavBarItem2
        '
        Me.NavBarItem2.Appearance.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.NavBarItem2.Appearance.Options.UseFont = True
        Me.NavBarItem2.AppearanceHotTracked.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.NavBarItem2.AppearanceHotTracked.Options.UseFont = True
        Me.NavBarItem2.AppearancePressed.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.NavBarItem2.AppearancePressed.Options.UseFont = True
        Me.NavBarItem2.Caption = "DAFTAR PAKET TINDAKAN"
        Me.NavBarItem2.Name = "NavBarItem2"
        '
        'TabControlMenu
        '
        Me.TabControlMenu.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControlMenu.Controls.Add(Me.TabPageLaporanPendapatan)
        Me.TabControlMenu.Controls.Add(Me.TabPageRekapTagihan)
        Me.TabControlMenu.Controls.Add(Me.TabPageRekapInvoice)
        Me.TabControlMenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlMenu.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TabControlMenu.ItemSize = New System.Drawing.Size(150, 23)
        Me.TabControlMenu.Location = New System.Drawing.Point(0, 0)
        Me.TabControlMenu.Name = "TabControlMenu"
        Me.TabControlMenu.SelectedIndex = 0
        Me.TabControlMenu.Size = New System.Drawing.Size(771, 665)
        Me.TabControlMenu.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControlMenu.TabIndex = 0
        '
        'TabPageLaporanPendapatan
        '
        Me.TabPageLaporanPendapatan.AutoScroll = True
        Me.TabPageLaporanPendapatan.BackColor = System.Drawing.Color.White
        Me.TabPageLaporanPendapatan.Controls.Add(Me.SplitContainerLaporanPendapatanMain)
        Me.TabPageLaporanPendapatan.Location = New System.Drawing.Point(4, 27)
        Me.TabPageLaporanPendapatan.Name = "TabPageLaporanPendapatan"
        Me.TabPageLaporanPendapatan.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageLaporanPendapatan.Size = New System.Drawing.Size(763, 634)
        Me.TabPageLaporanPendapatan.TabIndex = 0
        Me.TabPageLaporanPendapatan.Text = "Laporan Pendapatan"
        Me.TabPageLaporanPendapatan.UseVisualStyleBackColor = True
        '
        'SplitContainerLaporanPendapatanMain
        '
        Me.SplitContainerLaporanPendapatanMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerLaporanPendapatanMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainerLaporanPendapatanMain.IsSplitterFixed = True
        Me.SplitContainerLaporanPendapatanMain.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainerLaporanPendapatanMain.Name = "SplitContainerLaporanPendapatanMain"
        Me.SplitContainerLaporanPendapatanMain.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerLaporanPendapatanMain.Panel1
        '
        Me.SplitContainerLaporanPendapatanMain.Panel1.Controls.Add(Me.FlowLayoutPanel4)
        '
        'SplitContainerLaporanPendapatanMain.Panel2
        '
        Me.SplitContainerLaporanPendapatanMain.Panel2.AutoScroll = True
        Me.SplitContainerLaporanPendapatanMain.Panel2.Controls.Add(Me.SplitContainerLaporanPendapatanHeader)
        Me.SplitContainerLaporanPendapatanMain.Size = New System.Drawing.Size(757, 628)
        Me.SplitContainerLaporanPendapatanMain.SplitterDistance = 45
        Me.SplitContainerLaporanPendapatanMain.SplitterWidth = 1
        Me.SplitContainerLaporanPendapatanMain.TabIndex = 461
        '
        'FlowLayoutPanel4
        '
        Me.FlowLayoutPanel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.FlowLayoutPanel4.Controls.Add(Me.ButtonCetakLaporanPendapatan)
        Me.FlowLayoutPanel4.Controls.Add(Me.ButtonClearDataLaporanPendapatan)
        Me.FlowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel4.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel4.Name = "FlowLayoutPanel4"
        Me.FlowLayoutPanel4.Size = New System.Drawing.Size(757, 45)
        Me.FlowLayoutPanel4.TabIndex = 538
        '
        'ButtonCetakLaporanPendapatan
        '
        Me.ButtonCetakLaporanPendapatan.BackColor = System.Drawing.Color.White
        Me.ButtonCetakLaporanPendapatan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonCetakLaporanPendapatan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonCetakLaporanPendapatan.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCetakLaporanPendapatan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonCetakLaporanPendapatan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCetakLaporanPendapatan.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCetakLaporanPendapatan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCetakLaporanPendapatan.Image = CType(resources.GetObject("ButtonCetakLaporanPendapatan.Image"), System.Drawing.Image)
        Me.ButtonCetakLaporanPendapatan.Location = New System.Drawing.Point(3, 3)
        Me.ButtonCetakLaporanPendapatan.Name = "ButtonCetakLaporanPendapatan"
        Me.ButtonCetakLaporanPendapatan.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonCetakLaporanPendapatan.Size = New System.Drawing.Size(150, 40)
        Me.ButtonCetakLaporanPendapatan.TabIndex = 580
        Me.ButtonCetakLaporanPendapatan.Text = " Cetak Laporan"
        Me.ButtonCetakLaporanPendapatan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonCetakLaporanPendapatan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonCetakLaporanPendapatan.UseVisualStyleBackColor = False
        '
        'ButtonClearDataLaporanPendapatan
        '
        Me.ButtonClearDataLaporanPendapatan.BackColor = System.Drawing.Color.White
        Me.ButtonClearDataLaporanPendapatan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonClearDataLaporanPendapatan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonClearDataLaporanPendapatan.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonClearDataLaporanPendapatan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonClearDataLaporanPendapatan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonClearDataLaporanPendapatan.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonClearDataLaporanPendapatan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonClearDataLaporanPendapatan.Image = CType(resources.GetObject("ButtonClearDataLaporanPendapatan.Image"), System.Drawing.Image)
        Me.ButtonClearDataLaporanPendapatan.Location = New System.Drawing.Point(159, 3)
        Me.ButtonClearDataLaporanPendapatan.Name = "ButtonClearDataLaporanPendapatan"
        Me.ButtonClearDataLaporanPendapatan.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonClearDataLaporanPendapatan.Size = New System.Drawing.Size(171, 40)
        Me.ButtonClearDataLaporanPendapatan.TabIndex = 583
        Me.ButtonClearDataLaporanPendapatan.Text = " Clear Data"
        Me.ButtonClearDataLaporanPendapatan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonClearDataLaporanPendapatan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonClearDataLaporanPendapatan.UseVisualStyleBackColor = False
        '
        'SplitContainerLaporanPendapatanHeader
        '
        Me.SplitContainerLaporanPendapatanHeader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerLaporanPendapatanHeader.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainerLaporanPendapatanHeader.IsSplitterFixed = True
        Me.SplitContainerLaporanPendapatanHeader.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerLaporanPendapatanHeader.Name = "SplitContainerLaporanPendapatanHeader"
        Me.SplitContainerLaporanPendapatanHeader.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerLaporanPendapatanHeader.Panel1
        '
        Me.SplitContainerLaporanPendapatanHeader.Panel1.BackColor = System.Drawing.Color.White
        Me.SplitContainerLaporanPendapatanHeader.Panel1.Controls.Add(Me.CheckBoxTransaksiNolRupiah)
        Me.SplitContainerLaporanPendapatanHeader.Panel1.Controls.Add(Me.CheckBoxCard)
        Me.SplitContainerLaporanPendapatanHeader.Panel1.Controls.Add(Me.CheckBoxDebet)
        Me.SplitContainerLaporanPendapatanHeader.Panel1.Controls.Add(Me.CheckBoxTunai)
        Me.SplitContainerLaporanPendapatanHeader.Panel1.Controls.Add(Me.CheckBoxTagihan)
        Me.SplitContainerLaporanPendapatanHeader.Panel1.Controls.Add(Me.Panel9)
        Me.SplitContainerLaporanPendapatanHeader.Panel1.Controls.Add(Me.ComboBoxPoliTujuanLaporanPendapatan)
        Me.SplitContainerLaporanPendapatanHeader.Panel1.Controls.Add(Me.ButtonViewDataPendapatan)
        Me.SplitContainerLaporanPendapatanHeader.Panel1.Controls.Add(Me.Label54)
        Me.SplitContainerLaporanPendapatanHeader.Panel1.Controls.Add(Me.TglAkhirTransaksiLaporanPendapatan)
        Me.SplitContainerLaporanPendapatanHeader.Panel1.Controls.Add(Me.TglAwalTransaksiLaporanPendapatan)
        Me.SplitContainerLaporanPendapatanHeader.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainerLaporanPendapatanHeader.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainerLaporanPendapatanHeader.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainerLaporanPendapatanHeader.Panel1.Controls.Add(Me.TextBoxNamaPerusahaanLaporanPendapatan)
        Me.SplitContainerLaporanPendapatanHeader.Panel1.Controls.Add(Me.Label157)
        Me.SplitContainerLaporanPendapatanHeader.Panel1.Controls.Add(Me.ButtonFindPerusahaanLaporanPendapatan)
        Me.SplitContainerLaporanPendapatanHeader.Panel1.Controls.Add(Me.Label203)
        '
        'SplitContainerLaporanPendapatanHeader.Panel2
        '
        Me.SplitContainerLaporanPendapatanHeader.Panel2.AutoScroll = True
        Me.SplitContainerLaporanPendapatanHeader.Panel2.Controls.Add(Me.GridControlLaporanPendapatan)
        Me.SplitContainerLaporanPendapatanHeader.Size = New System.Drawing.Size(757, 582)
        Me.SplitContainerLaporanPendapatanHeader.SplitterDistance = 250
        Me.SplitContainerLaporanPendapatanHeader.SplitterWidth = 1
        Me.SplitContainerLaporanPendapatanHeader.TabIndex = 462
        '
        'CheckBoxTransaksiNolRupiah
        '
        Me.CheckBoxTransaksiNolRupiah.AutoSize = True
        Me.CheckBoxTransaksiNolRupiah.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.CheckBoxTransaksiNolRupiah.Location = New System.Drawing.Point(320, 187)
        Me.CheckBoxTransaksiNolRupiah.Name = "CheckBoxTransaksiNolRupiah"
        Me.CheckBoxTransaksiNolRupiah.Size = New System.Drawing.Size(226, 21)
        Me.CheckBoxTransaksiNolRupiah.TabIndex = 571
        Me.CheckBoxTransaksiNolRupiah.Tag = ""
        Me.CheckBoxTransaksiNolRupiah.Text = "Tampilkan Transaksi Nominal Rp 0"
        Me.CheckBoxTransaksiNolRupiah.UseVisualStyleBackColor = True
        '
        'CheckBoxCard
        '
        Me.CheckBoxCard.AutoSize = True
        Me.CheckBoxCard.Checked = True
        Me.CheckBoxCard.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxCard.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.CheckBoxCard.Location = New System.Drawing.Point(369, 78)
        Me.CheckBoxCard.Name = "CheckBoxCard"
        Me.CheckBoxCard.Size = New System.Drawing.Size(55, 21)
        Me.CheckBoxCard.TabIndex = 570
        Me.CheckBoxCard.Tag = ""
        Me.CheckBoxCard.Text = "Card"
        Me.CheckBoxCard.UseVisualStyleBackColor = True
        '
        'CheckBoxDebet
        '
        Me.CheckBoxDebet.AutoSize = True
        Me.CheckBoxDebet.Checked = True
        Me.CheckBoxDebet.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxDebet.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.CheckBoxDebet.Location = New System.Drawing.Point(301, 78)
        Me.CheckBoxDebet.Name = "CheckBoxDebet"
        Me.CheckBoxDebet.Size = New System.Drawing.Size(62, 21)
        Me.CheckBoxDebet.TabIndex = 569
        Me.CheckBoxDebet.Tag = ""
        Me.CheckBoxDebet.Text = "Debet"
        Me.CheckBoxDebet.UseVisualStyleBackColor = True
        '
        'CheckBoxTunai
        '
        Me.CheckBoxTunai.AutoSize = True
        Me.CheckBoxTunai.Checked = True
        Me.CheckBoxTunai.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxTunai.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.CheckBoxTunai.Location = New System.Drawing.Point(237, 78)
        Me.CheckBoxTunai.Name = "CheckBoxTunai"
        Me.CheckBoxTunai.Size = New System.Drawing.Size(58, 21)
        Me.CheckBoxTunai.TabIndex = 568
        Me.CheckBoxTunai.Tag = ""
        Me.CheckBoxTunai.Text = "Tunai"
        Me.CheckBoxTunai.UseVisualStyleBackColor = True
        '
        'CheckBoxTagihan
        '
        Me.CheckBoxTagihan.AutoSize = True
        Me.CheckBoxTagihan.Checked = True
        Me.CheckBoxTagihan.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxTagihan.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.CheckBoxTagihan.Location = New System.Drawing.Point(159, 78)
        Me.CheckBoxTagihan.Name = "CheckBoxTagihan"
        Me.CheckBoxTagihan.Size = New System.Drawing.Size(72, 21)
        Me.CheckBoxTagihan.TabIndex = 567
        Me.CheckBoxTagihan.Tag = ""
        Me.CheckBoxTagihan.Text = "Tagihan"
        Me.CheckBoxTagihan.UseVisualStyleBackColor = True
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.Transparent
        Me.Panel9.Controls.Add(Me.RadioButtonOptionLaporanPendapatanTagihan)
        Me.Panel9.Controls.Add(Me.RadioButtonOptionLaporanPendapatan)
        Me.Panel9.Location = New System.Drawing.Point(159, 151)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(387, 25)
        Me.Panel9.TabIndex = 564
        '
        'RadioButtonOptionLaporanPendapatanTagihan
        '
        Me.RadioButtonOptionLaporanPendapatanTagihan.AutoSize = True
        Me.RadioButtonOptionLaporanPendapatanTagihan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.RadioButtonOptionLaporanPendapatanTagihan.Location = New System.Drawing.Point(189, 3)
        Me.RadioButtonOptionLaporanPendapatanTagihan.Name = "RadioButtonOptionLaporanPendapatanTagihan"
        Me.RadioButtonOptionLaporanPendapatanTagihan.Size = New System.Drawing.Size(178, 19)
        Me.RadioButtonOptionLaporanPendapatanTagihan.TabIndex = 248
        Me.RadioButtonOptionLaporanPendapatanTagihan.Text = "Laporan Pendapatan (Versi 2)"
        Me.RadioButtonOptionLaporanPendapatanTagihan.UseVisualStyleBackColor = True
        '
        'RadioButtonOptionLaporanPendapatan
        '
        Me.RadioButtonOptionLaporanPendapatan.AutoSize = True
        Me.RadioButtonOptionLaporanPendapatan.Checked = True
        Me.RadioButtonOptionLaporanPendapatan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.RadioButtonOptionLaporanPendapatan.Location = New System.Drawing.Point(5, 3)
        Me.RadioButtonOptionLaporanPendapatan.Name = "RadioButtonOptionLaporanPendapatan"
        Me.RadioButtonOptionLaporanPendapatan.Size = New System.Drawing.Size(178, 19)
        Me.RadioButtonOptionLaporanPendapatan.TabIndex = 245
        Me.RadioButtonOptionLaporanPendapatan.TabStop = True
        Me.RadioButtonOptionLaporanPendapatan.Text = "Laporan Pendapatan (Versi 1)"
        Me.RadioButtonOptionLaporanPendapatan.UseVisualStyleBackColor = True
        '
        'ComboBoxPoliTujuanLaporanPendapatan
        '
        Me.ComboBoxPoliTujuanLaporanPendapatan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.ComboBoxPoliTujuanLaporanPendapatan.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBoxPoliTujuanLaporanPendapatan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxPoliTujuanLaporanPendapatan.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBoxPoliTujuanLaporanPendapatan.FormattingEnabled = True
        Me.ComboBoxPoliTujuanLaporanPendapatan.Location = New System.Drawing.Point(159, 46)
        Me.ComboBoxPoliTujuanLaporanPendapatan.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxPoliTujuanLaporanPendapatan.Name = "ComboBoxPoliTujuanLaporanPendapatan"
        Me.ComboBoxPoliTujuanLaporanPendapatan.Size = New System.Drawing.Size(265, 25)
        Me.ComboBoxPoliTujuanLaporanPendapatan.TabIndex = 558
        '
        'ButtonViewDataPendapatan
        '
        Me.ButtonViewDataPendapatan.BackColor = System.Drawing.Color.White
        Me.ButtonViewDataPendapatan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonViewDataPendapatan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonViewDataPendapatan.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonViewDataPendapatan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonViewDataPendapatan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonViewDataPendapatan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonViewDataPendapatan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ButtonViewDataPendapatan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonViewDataPendapatan.Location = New System.Drawing.Point(159, 182)
        Me.ButtonViewDataPendapatan.Name = "ButtonViewDataPendapatan"
        Me.ButtonViewDataPendapatan.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonViewDataPendapatan.Size = New System.Drawing.Size(155, 30)
        Me.ButtonViewDataPendapatan.TabIndex = 546
        Me.ButtonViewDataPendapatan.Text = " View Data Pendapatan"
        Me.ButtonViewDataPendapatan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonViewDataPendapatan.UseVisualStyleBackColor = False
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.BackColor = System.Drawing.Color.Transparent
        Me.Label54.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.Location = New System.Drawing.Point(311, 20)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(24, 15)
        Me.Label54.TabIndex = 543
        Me.Label54.Text = "s/d"
        '
        'TglAkhirTransaksiLaporanPendapatan
        '
        Me.TglAkhirTransaksiLaporanPendapatan.CalendarFont = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TglAkhirTransaksiLaporanPendapatan.CustomFormat = "dd-MMM-yyyy"
        Me.TglAkhirTransaksiLaporanPendapatan.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TglAkhirTransaksiLaporanPendapatan.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TglAkhirTransaksiLaporanPendapatan.Location = New System.Drawing.Point(336, 14)
        Me.TglAkhirTransaksiLaporanPendapatan.Name = "TglAkhirTransaksiLaporanPendapatan"
        Me.TglAkhirTransaksiLaporanPendapatan.Size = New System.Drawing.Size(150, 25)
        Me.TglAkhirTransaksiLaporanPendapatan.TabIndex = 540
        '
        'TglAwalTransaksiLaporanPendapatan
        '
        Me.TglAwalTransaksiLaporanPendapatan.CalendarFont = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TglAwalTransaksiLaporanPendapatan.CustomFormat = "dd-MMM-yyyy"
        Me.TglAwalTransaksiLaporanPendapatan.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TglAwalTransaksiLaporanPendapatan.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TglAwalTransaksiLaporanPendapatan.Location = New System.Drawing.Point(159, 14)
        Me.TglAwalTransaksiLaporanPendapatan.Name = "TglAwalTransaksiLaporanPendapatan"
        Me.TglAwalTransaksiLaporanPendapatan.Size = New System.Drawing.Size(150, 25)
        Me.TglAwalTransaksiLaporanPendapatan.TabIndex = 539
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(27, 108)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(119, 17)
        Me.Label4.TabIndex = 538
        Me.Label4.Text = "Nama Perusahaan"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(27, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 17)
        Me.Label3.TabIndex = 537
        Me.Label3.Text = "Jenis Bayar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(28, 154)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 17)
        Me.Label1.TabIndex = 535
        Me.Label1.Text = "Jenis Cetak"
        '
        'TextBoxNamaPerusahaanLaporanPendapatan
        '
        Me.TextBoxNamaPerusahaanLaporanPendapatan.BackColor = System.Drawing.Color.White
        Me.TextBoxNamaPerusahaanLaporanPendapatan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxNamaPerusahaanLaporanPendapatan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBoxNamaPerusahaanLaporanPendapatan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TextBoxNamaPerusahaanLaporanPendapatan.Location = New System.Drawing.Point(225, 105)
        Me.TextBoxNamaPerusahaanLaporanPendapatan.Multiline = True
        Me.TextBoxNamaPerusahaanLaporanPendapatan.Name = "TextBoxNamaPerusahaanLaporanPendapatan"
        Me.TextBoxNamaPerusahaanLaporanPendapatan.ReadOnly = True
        Me.TextBoxNamaPerusahaanLaporanPendapatan.Size = New System.Drawing.Size(321, 40)
        Me.TextBoxNamaPerusahaanLaporanPendapatan.TabIndex = 531
        '
        'Label157
        '
        Me.Label157.AutoSize = True
        Me.Label157.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label157.Location = New System.Drawing.Point(28, 20)
        Me.Label157.Name = "Label157"
        Me.Label157.Size = New System.Drawing.Size(84, 17)
        Me.Label157.TabIndex = 528
        Me.Label157.Text = "Tgl Transaksi"
        '
        'ButtonFindPerusahaanLaporanPendapatan
        '
        Me.ButtonFindPerusahaanLaporanPendapatan.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindPerusahaanLaporanPendapatan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonFindPerusahaanLaporanPendapatan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonFindPerusahaanLaporanPendapatan.FlatAppearance.BorderSize = 0
        Me.ButtonFindPerusahaanLaporanPendapatan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindPerusahaanLaporanPendapatan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonFindPerusahaanLaporanPendapatan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonFindPerusahaanLaporanPendapatan.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonFindPerusahaanLaporanPendapatan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ButtonFindPerusahaanLaporanPendapatan.Location = New System.Drawing.Point(159, 105)
        Me.ButtonFindPerusahaanLaporanPendapatan.Name = "ButtonFindPerusahaanLaporanPendapatan"
        Me.ButtonFindPerusahaanLaporanPendapatan.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonFindPerusahaanLaporanPendapatan.Size = New System.Drawing.Size(60, 25)
        Me.ButtonFindPerusahaanLaporanPendapatan.TabIndex = 527
        Me.ButtonFindPerusahaanLaporanPendapatan.Text = " Cari"
        Me.ButtonFindPerusahaanLaporanPendapatan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonFindPerusahaanLaporanPendapatan.UseVisualStyleBackColor = False
        '
        'Label203
        '
        Me.Label203.AutoSize = True
        Me.Label203.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label203.Location = New System.Drawing.Point(28, 49)
        Me.Label203.Name = "Label203"
        Me.Label203.Size = New System.Drawing.Size(74, 17)
        Me.Label203.TabIndex = 525
        Me.Label203.Text = "Poli Tujuan"
        '
        'GridControlLaporanPendapatan
        '
        Me.GridControlLaporanPendapatan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControlLaporanPendapatan.EmbeddedNavigator.Name = ""
        Me.GridControlLaporanPendapatan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GridControlLaporanPendapatan.Location = New System.Drawing.Point(0, 0)
        Me.GridControlLaporanPendapatan.MainView = Me.GridViewLaporanPendapatan
        Me.GridControlLaporanPendapatan.Name = "GridControlLaporanPendapatan"
        Me.GridControlLaporanPendapatan.Size = New System.Drawing.Size(757, 331)
        Me.GridControlLaporanPendapatan.TabIndex = 186
        Me.GridControlLaporanPendapatan.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewLaporanPendapatan})
        '
        'GridViewLaporanPendapatan
        '
        Me.GridViewLaporanPendapatan.GridControl = Me.GridControlLaporanPendapatan
        Me.GridViewLaporanPendapatan.Name = "GridViewLaporanPendapatan"
        Me.GridViewLaporanPendapatan.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridViewLaporanPendapatan.OptionsView.ShowGroupPanel = False
        Me.GridViewLaporanPendapatan.OptionsView.ShowIndicator = False
        Me.GridViewLaporanPendapatan.PaintStyleName = "Skin"
        '
        'TabPageRekapTagihan
        '
        Me.TabPageRekapTagihan.BackColor = System.Drawing.Color.White
        Me.TabPageRekapTagihan.Controls.Add(Me.SplitContainerRekapTagihanMain)
        Me.TabPageRekapTagihan.Location = New System.Drawing.Point(4, 27)
        Me.TabPageRekapTagihan.Name = "TabPageRekapTagihan"
        Me.TabPageRekapTagihan.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageRekapTagihan.Size = New System.Drawing.Size(763, 634)
        Me.TabPageRekapTagihan.TabIndex = 1
        Me.TabPageRekapTagihan.Text = "Rekap Tagihan"
        Me.TabPageRekapTagihan.UseVisualStyleBackColor = True
        '
        'SplitContainerRekapTagihanMain
        '
        Me.SplitContainerRekapTagihanMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerRekapTagihanMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainerRekapTagihanMain.IsSplitterFixed = True
        Me.SplitContainerRekapTagihanMain.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainerRekapTagihanMain.Name = "SplitContainerRekapTagihanMain"
        Me.SplitContainerRekapTagihanMain.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerRekapTagihanMain.Panel1
        '
        Me.SplitContainerRekapTagihanMain.Panel1.Controls.Add(Me.FlowLayoutPanel1)
        '
        'SplitContainerRekapTagihanMain.Panel2
        '
        Me.SplitContainerRekapTagihanMain.Panel2.AutoScroll = True
        Me.SplitContainerRekapTagihanMain.Panel2.Controls.Add(Me.SplitContainerRekapTagihanHeader)
        Me.SplitContainerRekapTagihanMain.Size = New System.Drawing.Size(757, 628)
        Me.SplitContainerRekapTagihanMain.SplitterDistance = 45
        Me.SplitContainerRekapTagihanMain.SplitterWidth = 1
        Me.SplitContainerRekapTagihanMain.TabIndex = 462
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.FlowLayoutPanel1.Controls.Add(Me.ButtonClearDataRekapTagihan)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(757, 45)
        Me.FlowLayoutPanel1.TabIndex = 538
        '
        'ButtonClearDataRekapTagihan
        '
        Me.ButtonClearDataRekapTagihan.BackColor = System.Drawing.Color.White
        Me.ButtonClearDataRekapTagihan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonClearDataRekapTagihan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonClearDataRekapTagihan.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonClearDataRekapTagihan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonClearDataRekapTagihan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonClearDataRekapTagihan.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonClearDataRekapTagihan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonClearDataRekapTagihan.Image = CType(resources.GetObject("ButtonClearDataRekapTagihan.Image"), System.Drawing.Image)
        Me.ButtonClearDataRekapTagihan.Location = New System.Drawing.Point(3, 3)
        Me.ButtonClearDataRekapTagihan.Name = "ButtonClearDataRekapTagihan"
        Me.ButtonClearDataRekapTagihan.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonClearDataRekapTagihan.Size = New System.Drawing.Size(171, 40)
        Me.ButtonClearDataRekapTagihan.TabIndex = 583
        Me.ButtonClearDataRekapTagihan.Text = " Clear Data"
        Me.ButtonClearDataRekapTagihan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonClearDataRekapTagihan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonClearDataRekapTagihan.UseVisualStyleBackColor = False
        '
        'SplitContainerRekapTagihanHeader
        '
        Me.SplitContainerRekapTagihanHeader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerRekapTagihanHeader.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainerRekapTagihanHeader.IsSplitterFixed = True
        Me.SplitContainerRekapTagihanHeader.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerRekapTagihanHeader.Name = "SplitContainerRekapTagihanHeader"
        Me.SplitContainerRekapTagihanHeader.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerRekapTagihanHeader.Panel1
        '
        Me.SplitContainerRekapTagihanHeader.Panel1.BackColor = System.Drawing.Color.White
        Me.SplitContainerRekapTagihanHeader.Panel1.Controls.Add(Me.ButtonKirimUlangJurnal)
        Me.SplitContainerRekapTagihanHeader.Panel1.Controls.Add(Me.TextBoxNoTagihan)
        Me.SplitContainerRekapTagihanHeader.Panel1.Controls.Add(Me.PanelCreateInvoice)
        Me.SplitContainerRekapTagihanHeader.Panel1.Controls.Add(Me.ComboBoxJenisPoliOrTransaksi)
        Me.SplitContainerRekapTagihanHeader.Panel1.Controls.Add(Me.ButtonViewDataRekapTagihan)
        Me.SplitContainerRekapTagihanHeader.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainerRekapTagihanHeader.Panel1.Controls.Add(Me.TglAkhirTransaksiRekapTagihan)
        Me.SplitContainerRekapTagihanHeader.Panel1.Controls.Add(Me.TglAwalTransaksiRekapTagihan)
        Me.SplitContainerRekapTagihanHeader.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainerRekapTagihanHeader.Panel1.Controls.Add(Me.TextBoxNamaPerusahaanRekapTagihan)
        Me.SplitContainerRekapTagihanHeader.Panel1.Controls.Add(Me.Label8)
        Me.SplitContainerRekapTagihanHeader.Panel1.Controls.Add(Me.ButtonFindPerusahaanRekapTagihan)
        Me.SplitContainerRekapTagihanHeader.Panel1.Controls.Add(Me.Label9)
        '
        'SplitContainerRekapTagihanHeader.Panel2
        '
        Me.SplitContainerRekapTagihanHeader.Panel2.AutoScroll = True
        Me.SplitContainerRekapTagihanHeader.Panel2.Controls.Add(Me.GridControlRekapTagihan)
        Me.SplitContainerRekapTagihanHeader.Size = New System.Drawing.Size(757, 582)
        Me.SplitContainerRekapTagihanHeader.SplitterDistance = 285
        Me.SplitContainerRekapTagihanHeader.SplitterWidth = 1
        Me.SplitContainerRekapTagihanHeader.TabIndex = 462
        '
        'ButtonKirimUlangJurnal
        '
        Me.ButtonKirimUlangJurnal.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonKirimUlangJurnal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonKirimUlangJurnal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonKirimUlangJurnal.FlatAppearance.BorderSize = 0
        Me.ButtonKirimUlangJurnal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonKirimUlangJurnal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonKirimUlangJurnal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonKirimUlangJurnal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonKirimUlangJurnal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ButtonKirimUlangJurnal.Location = New System.Drawing.Point(504, 234)
        Me.ButtonKirimUlangJurnal.Name = "ButtonKirimUlangJurnal"
        Me.ButtonKirimUlangJurnal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonKirimUlangJurnal.Size = New System.Drawing.Size(153, 25)
        Me.ButtonKirimUlangJurnal.TabIndex = 575
        Me.ButtonKirimUlangJurnal.Text = "Kirim Ulang Jurnal"
        Me.ButtonKirimUlangJurnal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonKirimUlangJurnal.UseVisualStyleBackColor = False
        Me.ButtonKirimUlangJurnal.Visible = False
        '
        'TextBoxNoTagihan
        '
        Me.TextBoxNoTagihan.BackColor = System.Drawing.Color.White
        Me.TextBoxNoTagihan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxNoTagihan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBoxNoTagihan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TextBoxNoTagihan.Location = New System.Drawing.Point(504, 205)
        Me.TextBoxNoTagihan.Name = "TextBoxNoTagihan"
        Me.TextBoxNoTagihan.Size = New System.Drawing.Size(153, 23)
        Me.TextBoxNoTagihan.TabIndex = 573
        Me.TextBoxNoTagihan.Visible = False
        '
        'PanelCreateInvoice
        '
        Me.PanelCreateInvoice.Controls.Add(Me.ButtonSimpanRekapTagihan)
        Me.PanelCreateInvoice.Controls.Add(Me.TextBoxBankTransferCoa)
        Me.PanelCreateInvoice.Controls.Add(Me.Label7)
        Me.PanelCreateInvoice.Controls.Add(Me.TextBoxBankTransferKeterangan)
        Me.PanelCreateInvoice.Controls.Add(Me.ButtonFindBankTagihan)
        Me.PanelCreateInvoice.Controls.Add(Me.Label6)
        Me.PanelCreateInvoice.Controls.Add(Me.TglJatuhTempoRekapTagihan)
        Me.PanelCreateInvoice.Controls.Add(Me.CheckBoxSemuaTransaksiRekapTagihan)
        Me.PanelCreateInvoice.Location = New System.Drawing.Point(14, 140)
        Me.PanelCreateInvoice.Name = "PanelCreateInvoice"
        Me.PanelCreateInvoice.Size = New System.Drawing.Size(484, 140)
        Me.PanelCreateInvoice.TabIndex = 572
        '
        'ButtonSimpanRekapTagihan
        '
        Me.ButtonSimpanRekapTagihan.BackColor = System.Drawing.Color.White
        Me.ButtonSimpanRekapTagihan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonSimpanRekapTagihan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonSimpanRekapTagihan.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSimpanRekapTagihan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSimpanRekapTagihan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonSimpanRekapTagihan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSimpanRekapTagihan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ButtonSimpanRekapTagihan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSimpanRekapTagihan.Location = New System.Drawing.Point(327, 111)
        Me.ButtonSimpanRekapTagihan.Name = "ButtonSimpanRekapTagihan"
        Me.ButtonSimpanRekapTagihan.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonSimpanRekapTagihan.Size = New System.Drawing.Size(145, 25)
        Me.ButtonSimpanRekapTagihan.TabIndex = 578
        Me.ButtonSimpanRekapTagihan.Text = " Simpan Rekap Tagihan"
        Me.ButtonSimpanRekapTagihan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonSimpanRekapTagihan.UseVisualStyleBackColor = False
        '
        'TextBoxBankTransferCoa
        '
        Me.TextBoxBankTransferCoa.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.TextBoxBankTransferCoa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxBankTransferCoa.Cursor = System.Windows.Forms.Cursors.No
        Me.TextBoxBankTransferCoa.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TextBoxBankTransferCoa.Location = New System.Drawing.Point(211, 36)
        Me.TextBoxBankTransferCoa.Name = "TextBoxBankTransferCoa"
        Me.TextBoxBankTransferCoa.ReadOnly = True
        Me.TextBoxBankTransferCoa.Size = New System.Drawing.Size(84, 23)
        Me.TextBoxBankTransferCoa.TabIndex = 577
        Me.TextBoxBankTransferCoa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(14, 34)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 17)
        Me.Label7.TabIndex = 576
        Me.Label7.Text = "Bank Transfer"
        '
        'TextBoxBankTransferKeterangan
        '
        Me.TextBoxBankTransferKeterangan.BackColor = System.Drawing.Color.White
        Me.TextBoxBankTransferKeterangan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxBankTransferKeterangan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBoxBankTransferKeterangan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TextBoxBankTransferKeterangan.Location = New System.Drawing.Point(145, 65)
        Me.TextBoxBankTransferKeterangan.Multiline = True
        Me.TextBoxBankTransferKeterangan.Name = "TextBoxBankTransferKeterangan"
        Me.TextBoxBankTransferKeterangan.ReadOnly = True
        Me.TextBoxBankTransferKeterangan.Size = New System.Drawing.Size(327, 40)
        Me.TextBoxBankTransferKeterangan.TabIndex = 575
        '
        'ButtonFindBankTagihan
        '
        Me.ButtonFindBankTagihan.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindBankTagihan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonFindBankTagihan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonFindBankTagihan.FlatAppearance.BorderSize = 0
        Me.ButtonFindBankTagihan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindBankTagihan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonFindBankTagihan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonFindBankTagihan.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonFindBankTagihan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ButtonFindBankTagihan.Location = New System.Drawing.Point(145, 34)
        Me.ButtonFindBankTagihan.Name = "ButtonFindBankTagihan"
        Me.ButtonFindBankTagihan.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonFindBankTagihan.Size = New System.Drawing.Size(60, 25)
        Me.ButtonFindBankTagihan.TabIndex = 574
        Me.ButtonFindBankTagihan.Text = " Cari"
        Me.ButtonFindBankTagihan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonFindBankTagihan.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(14, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 17)
        Me.Label6.TabIndex = 573
        Me.Label6.Text = "Tgl Jatuh Tempo"
        '
        'TglJatuhTempoRekapTagihan
        '
        Me.TglJatuhTempoRekapTagihan.CalendarFont = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TglJatuhTempoRekapTagihan.CustomFormat = "dd-MMM-yyyy"
        Me.TglJatuhTempoRekapTagihan.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TglJatuhTempoRekapTagihan.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TglJatuhTempoRekapTagihan.Location = New System.Drawing.Point(145, 3)
        Me.TglJatuhTempoRekapTagihan.Name = "TglJatuhTempoRekapTagihan"
        Me.TglJatuhTempoRekapTagihan.Size = New System.Drawing.Size(150, 25)
        Me.TglJatuhTempoRekapTagihan.TabIndex = 572
        '
        'CheckBoxSemuaTransaksiRekapTagihan
        '
        Me.CheckBoxSemuaTransaksiRekapTagihan.AutoSize = True
        Me.CheckBoxSemuaTransaksiRekapTagihan.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.CheckBoxSemuaTransaksiRekapTagihan.Location = New System.Drawing.Point(145, 113)
        Me.CheckBoxSemuaTransaksiRekapTagihan.Name = "CheckBoxSemuaTransaksiRekapTagihan"
        Me.CheckBoxSemuaTransaksiRekapTagihan.Size = New System.Drawing.Size(177, 21)
        Me.CheckBoxSemuaTransaksiRekapTagihan.TabIndex = 571
        Me.CheckBoxSemuaTransaksiRekapTagihan.Text = "Checklist Semua Transaksi"
        Me.CheckBoxSemuaTransaksiRekapTagihan.UseVisualStyleBackColor = True
        '
        'ComboBoxJenisPoliOrTransaksi
        '
        Me.ComboBoxJenisPoliOrTransaksi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.ComboBoxJenisPoliOrTransaksi.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBoxJenisPoliOrTransaksi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxJenisPoliOrTransaksi.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBoxJenisPoliOrTransaksi.FormattingEnabled = True
        Me.ComboBoxJenisPoliOrTransaksi.Location = New System.Drawing.Point(159, 46)
        Me.ComboBoxJenisPoliOrTransaksi.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxJenisPoliOrTransaksi.Name = "ComboBoxJenisPoliOrTransaksi"
        Me.ComboBoxJenisPoliOrTransaksi.Size = New System.Drawing.Size(265, 25)
        Me.ComboBoxJenisPoliOrTransaksi.TabIndex = 558
        '
        'ButtonViewDataRekapTagihan
        '
        Me.ButtonViewDataRekapTagihan.BackColor = System.Drawing.Color.White
        Me.ButtonViewDataRekapTagihan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonViewDataRekapTagihan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonViewDataRekapTagihan.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonViewDataRekapTagihan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonViewDataRekapTagihan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonViewDataRekapTagihan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonViewDataRekapTagihan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ButtonViewDataRekapTagihan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonViewDataRekapTagihan.Location = New System.Drawing.Point(159, 109)
        Me.ButtonViewDataRekapTagihan.Name = "ButtonViewDataRekapTagihan"
        Me.ButtonViewDataRekapTagihan.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonViewDataRekapTagihan.Size = New System.Drawing.Size(327, 25)
        Me.ButtonViewDataRekapTagihan.TabIndex = 546
        Me.ButtonViewDataRekapTagihan.Text = " View Data Tagihan"
        Me.ButtonViewDataRekapTagihan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonViewDataRekapTagihan.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(311, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 15)
        Me.Label2.TabIndex = 543
        Me.Label2.Text = "s/d"
        '
        'TglAkhirTransaksiRekapTagihan
        '
        Me.TglAkhirTransaksiRekapTagihan.CalendarFont = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TglAkhirTransaksiRekapTagihan.CustomFormat = "dd-MMM-yyyy"
        Me.TglAkhirTransaksiRekapTagihan.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TglAkhirTransaksiRekapTagihan.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TglAkhirTransaksiRekapTagihan.Location = New System.Drawing.Point(336, 14)
        Me.TglAkhirTransaksiRekapTagihan.Name = "TglAkhirTransaksiRekapTagihan"
        Me.TglAkhirTransaksiRekapTagihan.Size = New System.Drawing.Size(150, 25)
        Me.TglAkhirTransaksiRekapTagihan.TabIndex = 540
        '
        'TglAwalTransaksiRekapTagihan
        '
        Me.TglAwalTransaksiRekapTagihan.CalendarFont = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TglAwalTransaksiRekapTagihan.CustomFormat = "dd-MMM-yyyy"
        Me.TglAwalTransaksiRekapTagihan.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TglAwalTransaksiRekapTagihan.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TglAwalTransaksiRekapTagihan.Location = New System.Drawing.Point(159, 14)
        Me.TglAwalTransaksiRekapTagihan.Name = "TglAwalTransaksiRekapTagihan"
        Me.TglAwalTransaksiRekapTagihan.Size = New System.Drawing.Size(150, 25)
        Me.TglAwalTransaksiRekapTagihan.TabIndex = 539
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(27, 81)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(119, 17)
        Me.Label5.TabIndex = 538
        Me.Label5.Text = "Nama Perusahaan"
        '
        'TextBoxNamaPerusahaanRekapTagihan
        '
        Me.TextBoxNamaPerusahaanRekapTagihan.BackColor = System.Drawing.Color.White
        Me.TextBoxNamaPerusahaanRekapTagihan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxNamaPerusahaanRekapTagihan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBoxNamaPerusahaanRekapTagihan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TextBoxNamaPerusahaanRekapTagihan.Location = New System.Drawing.Point(225, 80)
        Me.TextBoxNamaPerusahaanRekapTagihan.Name = "TextBoxNamaPerusahaanRekapTagihan"
        Me.TextBoxNamaPerusahaanRekapTagihan.ReadOnly = True
        Me.TextBoxNamaPerusahaanRekapTagihan.Size = New System.Drawing.Size(261, 23)
        Me.TextBoxNamaPerusahaanRekapTagihan.TabIndex = 531
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(28, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 17)
        Me.Label8.TabIndex = 528
        Me.Label8.Text = "Tgl Transaksi"
        '
        'ButtonFindPerusahaanRekapTagihan
        '
        Me.ButtonFindPerusahaanRekapTagihan.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindPerusahaanRekapTagihan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonFindPerusahaanRekapTagihan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonFindPerusahaanRekapTagihan.FlatAppearance.BorderSize = 0
        Me.ButtonFindPerusahaanRekapTagihan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindPerusahaanRekapTagihan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonFindPerusahaanRekapTagihan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonFindPerusahaanRekapTagihan.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonFindPerusahaanRekapTagihan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ButtonFindPerusahaanRekapTagihan.Location = New System.Drawing.Point(159, 78)
        Me.ButtonFindPerusahaanRekapTagihan.Name = "ButtonFindPerusahaanRekapTagihan"
        Me.ButtonFindPerusahaanRekapTagihan.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonFindPerusahaanRekapTagihan.Size = New System.Drawing.Size(60, 25)
        Me.ButtonFindPerusahaanRekapTagihan.TabIndex = 527
        Me.ButtonFindPerusahaanRekapTagihan.Text = " Cari"
        Me.ButtonFindPerusahaanRekapTagihan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonFindPerusahaanRekapTagihan.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(28, 49)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 17)
        Me.Label9.TabIndex = 525
        Me.Label9.Text = "Poli Tujuan"
        '
        'GridControlRekapTagihan
        '
        Me.GridControlRekapTagihan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControlRekapTagihan.EmbeddedNavigator.Name = ""
        Me.GridControlRekapTagihan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GridControlRekapTagihan.Location = New System.Drawing.Point(0, 0)
        Me.GridControlRekapTagihan.MainView = Me.GridViewRekapTagihan
        Me.GridControlRekapTagihan.Name = "GridControlRekapTagihan"
        Me.GridControlRekapTagihan.Size = New System.Drawing.Size(757, 296)
        Me.GridControlRekapTagihan.TabIndex = 186
        Me.GridControlRekapTagihan.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewRekapTagihan})
        '
        'GridViewRekapTagihan
        '
        Me.GridViewRekapTagihan.GridControl = Me.GridControlRekapTagihan
        Me.GridViewRekapTagihan.Name = "GridViewRekapTagihan"
        Me.GridViewRekapTagihan.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridViewRekapTagihan.OptionsView.ShowGroupPanel = False
        Me.GridViewRekapTagihan.OptionsView.ShowIndicator = False
        Me.GridViewRekapTagihan.PaintStyleName = "Skin"
        '
        'TabPageRekapInvoice
        '
        Me.TabPageRekapInvoice.BackColor = System.Drawing.Color.White
        Me.TabPageRekapInvoice.Controls.Add(Me.SplitContainer2)
        Me.TabPageRekapInvoice.Location = New System.Drawing.Point(4, 27)
        Me.TabPageRekapInvoice.Name = "TabPageRekapInvoice"
        Me.TabPageRekapInvoice.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageRekapInvoice.Size = New System.Drawing.Size(763, 634)
        Me.TabPageRekapInvoice.TabIndex = 2
        Me.TabPageRekapInvoice.Text = "Rekap Invoice"
        Me.TabPageRekapInvoice.UseVisualStyleBackColor = True
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer2.IsSplitterFixed = True
        Me.SplitContainer2.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.FlowLayoutPanel2)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.AutoScroll = True
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer2.Size = New System.Drawing.Size(757, 628)
        Me.SplitContainer2.SplitterDistance = 45
        Me.SplitContainer2.SplitterWidth = 1
        Me.SplitContainer2.TabIndex = 463
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.FlowLayoutPanel2.Controls.Add(Me.ButtonClearDataRekapInvoice)
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(757, 45)
        Me.FlowLayoutPanel2.TabIndex = 538
        '
        'ButtonClearDataRekapInvoice
        '
        Me.ButtonClearDataRekapInvoice.BackColor = System.Drawing.Color.White
        Me.ButtonClearDataRekapInvoice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonClearDataRekapInvoice.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonClearDataRekapInvoice.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonClearDataRekapInvoice.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonClearDataRekapInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonClearDataRekapInvoice.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonClearDataRekapInvoice.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonClearDataRekapInvoice.Image = CType(resources.GetObject("ButtonClearDataRekapInvoice.Image"), System.Drawing.Image)
        Me.ButtonClearDataRekapInvoice.Location = New System.Drawing.Point(3, 3)
        Me.ButtonClearDataRekapInvoice.Name = "ButtonClearDataRekapInvoice"
        Me.ButtonClearDataRekapInvoice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonClearDataRekapInvoice.Size = New System.Drawing.Size(171, 40)
        Me.ButtonClearDataRekapInvoice.TabIndex = 583
        Me.ButtonClearDataRekapInvoice.Text = " Clear Data"
        Me.ButtonClearDataRekapInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonClearDataRekapInvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonClearDataRekapInvoice.UseVisualStyleBackColor = False
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
        Me.SplitContainer3.Panel1.BackColor = System.Drawing.Color.White
        Me.SplitContainer3.Panel1.Controls.Add(Me.ButtonHapusTagihan)
        Me.SplitContainer3.Panel1.Controls.Add(Me.ButtonCetakInvoiceTagihan)
        Me.SplitContainer3.Panel1.Controls.Add(Me.ButtonCetakRekapTagihan)
        Me.SplitContainer3.Panel1.Controls.Add(Me.TextBoxBankInvoice)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label15)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label16)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label17)
        Me.SplitContainer3.Panel1.Controls.Add(Me.TglJatuhTempoInvoice)
        Me.SplitContainer3.Panel1.Controls.Add(Me.TglInvoice)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label21)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label20)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label19)
        Me.SplitContainer3.Panel1.Controls.Add(Me.TextBoxNamaPerusahaanInvoice)
        Me.SplitContainer3.Panel1.Controls.Add(Me.TextBoxNomorInvoice)
        Me.SplitContainer3.Panel1.Controls.Add(Me.TextBoxNominalInvoice)
        Me.SplitContainer3.Panel1.Controls.Add(Me.ButtonCariDataInvoice)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label12)
        Me.SplitContainer3.Panel1.Controls.Add(Me.TglAkhirTransaksiRekapInvoice)
        Me.SplitContainer3.Panel1.Controls.Add(Me.TglAwalTransaksiRekapInvoice)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label13)
        Me.SplitContainer3.Panel1.Controls.Add(Me.TextBoxNamaPerusahaanRekapInvoice)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label14)
        Me.SplitContainer3.Panel1.Controls.Add(Me.ButtonFindPerusahaanRekapInvoice)
        Me.SplitContainer3.Panel1.ForeColor = System.Drawing.Color.Black
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.AutoScroll = True
        Me.SplitContainer3.Panel2.Controls.Add(Me.GridControlRekapInvoice)
        Me.SplitContainer3.Size = New System.Drawing.Size(757, 582)
        Me.SplitContainer3.SplitterDistance = 250
        Me.SplitContainer3.SplitterWidth = 1
        Me.SplitContainer3.TabIndex = 462
        '
        'ButtonHapusTagihan
        '
        Me.ButtonHapusTagihan.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(69, Byte), Integer), CType(CType(58, Byte), Integer))
        Me.ButtonHapusTagihan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonHapusTagihan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonHapusTagihan.FlatAppearance.BorderSize = 0
        Me.ButtonHapusTagihan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonHapusTagihan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonHapusTagihan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonHapusTagihan.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonHapusTagihan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ButtonHapusTagihan.Location = New System.Drawing.Point(570, 216)
        Me.ButtonHapusTagihan.Name = "ButtonHapusTagihan"
        Me.ButtonHapusTagihan.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonHapusTagihan.Size = New System.Drawing.Size(150, 25)
        Me.ButtonHapusTagihan.TabIndex = 576
        Me.ButtonHapusTagihan.Text = "Hapus Tagihan"
        Me.ButtonHapusTagihan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonHapusTagihan.UseVisualStyleBackColor = False
        '
        'ButtonCetakInvoiceTagihan
        '
        Me.ButtonCetakInvoiceTagihan.BackColor = System.Drawing.Color.CornflowerBlue
        Me.ButtonCetakInvoiceTagihan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonCetakInvoiceTagihan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonCetakInvoiceTagihan.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCetakInvoiceTagihan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCetakInvoiceTagihan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonCetakInvoiceTagihan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCetakInvoiceTagihan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ButtonCetakInvoiceTagihan.ForeColor = System.Drawing.Color.White
        Me.ButtonCetakInvoiceTagihan.Location = New System.Drawing.Point(364, 216)
        Me.ButtonCetakInvoiceTagihan.Name = "ButtonCetakInvoiceTagihan"
        Me.ButtonCetakInvoiceTagihan.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonCetakInvoiceTagihan.Size = New System.Drawing.Size(200, 25)
        Me.ButtonCetakInvoiceTagihan.TabIndex = 575
        Me.ButtonCetakInvoiceTagihan.Text = "Cetak Invoice Tagihan"
        Me.ButtonCetakInvoiceTagihan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonCetakInvoiceTagihan.UseVisualStyleBackColor = False
        '
        'ButtonCetakRekapTagihan
        '
        Me.ButtonCetakRekapTagihan.BackColor = System.Drawing.Color.CornflowerBlue
        Me.ButtonCetakRekapTagihan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonCetakRekapTagihan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonCetakRekapTagihan.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCetakRekapTagihan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCetakRekapTagihan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonCetakRekapTagihan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCetakRekapTagihan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ButtonCetakRekapTagihan.ForeColor = System.Drawing.Color.White
        Me.ButtonCetakRekapTagihan.Location = New System.Drawing.Point(159, 216)
        Me.ButtonCetakRekapTagihan.Name = "ButtonCetakRekapTagihan"
        Me.ButtonCetakRekapTagihan.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonCetakRekapTagihan.Size = New System.Drawing.Size(200, 25)
        Me.ButtonCetakRekapTagihan.TabIndex = 574
        Me.ButtonCetakRekapTagihan.Text = "Cetak Rekap Tagihan"
        Me.ButtonCetakRekapTagihan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonCetakRekapTagihan.UseVisualStyleBackColor = False
        '
        'TextBoxBankInvoice
        '
        Me.TextBoxBankInvoice.BackColor = System.Drawing.Color.White
        Me.TextBoxBankInvoice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxBankInvoice.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TextBoxBankInvoice.Location = New System.Drawing.Point(159, 187)
        Me.TextBoxBankInvoice.Name = "TextBoxBankInvoice"
        Me.TextBoxBankInvoice.ReadOnly = True
        Me.TextBoxBankInvoice.Size = New System.Drawing.Size(261, 23)
        Me.TextBoxBankInvoice.TabIndex = 573
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label15.Location = New System.Drawing.Point(439, 132)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(72, 17)
        Me.Label15.TabIndex = 572
        Me.Label15.Text = "Tgl Invoice"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label16.Location = New System.Drawing.Point(439, 158)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(107, 17)
        Me.Label16.TabIndex = 571
        Me.Label16.Text = "Tgl Jatuh Tempo"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label17.Location = New System.Drawing.Point(439, 187)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(59, 17)
        Me.Label17.TabIndex = 570
        Me.Label17.Text = "Nominal"
        '
        'TglJatuhTempoInvoice
        '
        Me.TglJatuhTempoInvoice.CalendarFont = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TglJatuhTempoInvoice.CustomFormat = "dd-MMM-yyyy"
        Me.TglJatuhTempoInvoice.Enabled = False
        Me.TglJatuhTempoInvoice.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TglJatuhTempoInvoice.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TglJatuhTempoInvoice.Location = New System.Drawing.Point(570, 156)
        Me.TglJatuhTempoInvoice.Name = "TglJatuhTempoInvoice"
        Me.TglJatuhTempoInvoice.Size = New System.Drawing.Size(150, 25)
        Me.TglJatuhTempoInvoice.TabIndex = 569
        '
        'TglInvoice
        '
        Me.TglInvoice.CalendarFont = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TglInvoice.CustomFormat = "dd-MMM-yyyy"
        Me.TglInvoice.Enabled = False
        Me.TglInvoice.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TglInvoice.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TglInvoice.Location = New System.Drawing.Point(570, 125)
        Me.TglInvoice.Name = "TglInvoice"
        Me.TglInvoice.Size = New System.Drawing.Size(150, 25)
        Me.TglInvoice.TabIndex = 568
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label21.Location = New System.Drawing.Point(27, 132)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(119, 17)
        Me.Label21.TabIndex = 567
        Me.Label21.Text = "Nama Perusahaan"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label20.Location = New System.Drawing.Point(27, 158)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(73, 17)
        Me.Label20.TabIndex = 566
        Me.Label20.Text = "No Invoice"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label19.Location = New System.Drawing.Point(27, 187)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(38, 17)
        Me.Label19.TabIndex = 565
        Me.Label19.Text = "Bank"
        '
        'TextBoxNamaPerusahaanInvoice
        '
        Me.TextBoxNamaPerusahaanInvoice.BackColor = System.Drawing.Color.White
        Me.TextBoxNamaPerusahaanInvoice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxNamaPerusahaanInvoice.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TextBoxNamaPerusahaanInvoice.Location = New System.Drawing.Point(159, 129)
        Me.TextBoxNamaPerusahaanInvoice.Name = "TextBoxNamaPerusahaanInvoice"
        Me.TextBoxNamaPerusahaanInvoice.ReadOnly = True
        Me.TextBoxNamaPerusahaanInvoice.Size = New System.Drawing.Size(261, 23)
        Me.TextBoxNamaPerusahaanInvoice.TabIndex = 564
        '
        'TextBoxNomorInvoice
        '
        Me.TextBoxNomorInvoice.BackColor = System.Drawing.Color.White
        Me.TextBoxNomorInvoice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxNomorInvoice.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TextBoxNomorInvoice.Location = New System.Drawing.Point(159, 158)
        Me.TextBoxNomorInvoice.Name = "TextBoxNomorInvoice"
        Me.TextBoxNomorInvoice.ReadOnly = True
        Me.TextBoxNomorInvoice.Size = New System.Drawing.Size(261, 23)
        Me.TextBoxNomorInvoice.TabIndex = 563
        '
        'TextBoxNominalInvoice
        '
        Me.TextBoxNominalInvoice.BackColor = System.Drawing.Color.White
        Me.TextBoxNominalInvoice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxNominalInvoice.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TextBoxNominalInvoice.Location = New System.Drawing.Point(570, 187)
        Me.TextBoxNominalInvoice.Name = "TextBoxNominalInvoice"
        Me.TextBoxNominalInvoice.ReadOnly = True
        Me.TextBoxNominalInvoice.Size = New System.Drawing.Size(150, 23)
        Me.TextBoxNominalInvoice.TabIndex = 562
        '
        'ButtonCariDataInvoice
        '
        Me.ButtonCariDataInvoice.BackColor = System.Drawing.Color.White
        Me.ButtonCariDataInvoice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonCariDataInvoice.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonCariDataInvoice.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCariDataInvoice.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCariDataInvoice.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonCariDataInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCariDataInvoice.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ButtonCariDataInvoice.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCariDataInvoice.Location = New System.Drawing.Point(159, 76)
        Me.ButtonCariDataInvoice.Name = "ButtonCariDataInvoice"
        Me.ButtonCariDataInvoice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonCariDataInvoice.Size = New System.Drawing.Size(327, 25)
        Me.ButtonCariDataInvoice.TabIndex = 546
        Me.ButtonCariDataInvoice.Text = "Cari Data Invoice"
        Me.ButtonCariDataInvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonCariDataInvoice.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(311, 20)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(24, 15)
        Me.Label12.TabIndex = 543
        Me.Label12.Text = "s/d"
        '
        'TglAkhirTransaksiRekapInvoice
        '
        Me.TglAkhirTransaksiRekapInvoice.CalendarFont = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TglAkhirTransaksiRekapInvoice.CustomFormat = "dd-MMM-yyyy"
        Me.TglAkhirTransaksiRekapInvoice.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TglAkhirTransaksiRekapInvoice.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TglAkhirTransaksiRekapInvoice.Location = New System.Drawing.Point(336, 14)
        Me.TglAkhirTransaksiRekapInvoice.Name = "TglAkhirTransaksiRekapInvoice"
        Me.TglAkhirTransaksiRekapInvoice.Size = New System.Drawing.Size(150, 25)
        Me.TglAkhirTransaksiRekapInvoice.TabIndex = 540
        '
        'TglAwalTransaksiRekapInvoice
        '
        Me.TglAwalTransaksiRekapInvoice.CalendarFont = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TglAwalTransaksiRekapInvoice.CustomFormat = "dd-MMM-yyyy"
        Me.TglAwalTransaksiRekapInvoice.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TglAwalTransaksiRekapInvoice.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TglAwalTransaksiRekapInvoice.Location = New System.Drawing.Point(159, 14)
        Me.TglAwalTransaksiRekapInvoice.Name = "TglAwalTransaksiRekapInvoice"
        Me.TglAwalTransaksiRekapInvoice.Size = New System.Drawing.Size(150, 25)
        Me.TglAwalTransaksiRekapInvoice.TabIndex = 539
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label13.Location = New System.Drawing.Point(27, 48)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(119, 17)
        Me.Label13.TabIndex = 538
        Me.Label13.Text = "Nama Perusahaan"
        '
        'TextBoxNamaPerusahaanRekapInvoice
        '
        Me.TextBoxNamaPerusahaanRekapInvoice.BackColor = System.Drawing.Color.White
        Me.TextBoxNamaPerusahaanRekapInvoice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxNamaPerusahaanRekapInvoice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBoxNamaPerusahaanRekapInvoice.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TextBoxNamaPerusahaanRekapInvoice.Location = New System.Drawing.Point(225, 47)
        Me.TextBoxNamaPerusahaanRekapInvoice.Name = "TextBoxNamaPerusahaanRekapInvoice"
        Me.TextBoxNamaPerusahaanRekapInvoice.ReadOnly = True
        Me.TextBoxNamaPerusahaanRekapInvoice.Size = New System.Drawing.Size(261, 23)
        Me.TextBoxNamaPerusahaanRekapInvoice.TabIndex = 531
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label14.Location = New System.Drawing.Point(28, 20)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(72, 17)
        Me.Label14.TabIndex = 528
        Me.Label14.Text = "Tgl Invoice"
        '
        'ButtonFindPerusahaanRekapInvoice
        '
        Me.ButtonFindPerusahaanRekapInvoice.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindPerusahaanRekapInvoice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonFindPerusahaanRekapInvoice.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonFindPerusahaanRekapInvoice.FlatAppearance.BorderSize = 0
        Me.ButtonFindPerusahaanRekapInvoice.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindPerusahaanRekapInvoice.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonFindPerusahaanRekapInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonFindPerusahaanRekapInvoice.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonFindPerusahaanRekapInvoice.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ButtonFindPerusahaanRekapInvoice.Location = New System.Drawing.Point(159, 45)
        Me.ButtonFindPerusahaanRekapInvoice.Name = "ButtonFindPerusahaanRekapInvoice"
        Me.ButtonFindPerusahaanRekapInvoice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonFindPerusahaanRekapInvoice.Size = New System.Drawing.Size(60, 25)
        Me.ButtonFindPerusahaanRekapInvoice.TabIndex = 527
        Me.ButtonFindPerusahaanRekapInvoice.Text = " Cari"
        Me.ButtonFindPerusahaanRekapInvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonFindPerusahaanRekapInvoice.UseVisualStyleBackColor = False
        '
        'GridControlRekapInvoice
        '
        Me.GridControlRekapInvoice.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControlRekapInvoice.EmbeddedNavigator.Name = ""
        Me.GridControlRekapInvoice.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GridControlRekapInvoice.Location = New System.Drawing.Point(0, 0)
        Me.GridControlRekapInvoice.MainView = Me.GridViewRekapInvoice
        Me.GridControlRekapInvoice.Name = "GridControlRekapInvoice"
        Me.GridControlRekapInvoice.Size = New System.Drawing.Size(757, 331)
        Me.GridControlRekapInvoice.TabIndex = 186
        Me.GridControlRekapInvoice.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewRekapInvoice})
        '
        'GridViewRekapInvoice
        '
        Me.GridViewRekapInvoice.GridControl = Me.GridControlRekapInvoice
        Me.GridViewRekapInvoice.Name = "GridViewRekapInvoice"
        Me.GridViewRekapInvoice.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridViewRekapInvoice.OptionsView.ShowGroupPanel = False
        Me.GridViewRekapInvoice.OptionsView.ShowIndicator = False
        Me.GridViewRekapInvoice.PaintStyleName = "Skin"
        '
        'ReportPendapatanKlinik
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1000, 700)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelReportPendapatanKlinik)
        Me.Controls.Add(Me.PanelTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ReportPendapatanKlinik"
        Me.PanelTop.ResumeLayout(False)
        Me.PanelReportPendapatanKlinik.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.NavBarControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlMenu.ResumeLayout(False)
        Me.TabPageLaporanPendapatan.ResumeLayout(False)
        Me.SplitContainerLaporanPendapatanMain.Panel1.ResumeLayout(False)
        Me.SplitContainerLaporanPendapatanMain.Panel2.ResumeLayout(False)
        Me.SplitContainerLaporanPendapatanMain.ResumeLayout(False)
        Me.FlowLayoutPanel4.ResumeLayout(False)
        Me.SplitContainerLaporanPendapatanHeader.Panel1.ResumeLayout(False)
        Me.SplitContainerLaporanPendapatanHeader.Panel1.PerformLayout()
        Me.SplitContainerLaporanPendapatanHeader.Panel2.ResumeLayout(False)
        Me.SplitContainerLaporanPendapatanHeader.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        CType(Me.GridControlLaporanPendapatan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewLaporanPendapatan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageRekapTagihan.ResumeLayout(False)
        Me.SplitContainerRekapTagihanMain.Panel1.ResumeLayout(False)
        Me.SplitContainerRekapTagihanMain.Panel2.ResumeLayout(False)
        Me.SplitContainerRekapTagihanMain.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.SplitContainerRekapTagihanHeader.Panel1.ResumeLayout(False)
        Me.SplitContainerRekapTagihanHeader.Panel1.PerformLayout()
        Me.SplitContainerRekapTagihanHeader.Panel2.ResumeLayout(False)
        Me.SplitContainerRekapTagihanHeader.ResumeLayout(False)
        Me.PanelCreateInvoice.ResumeLayout(False)
        Me.PanelCreateInvoice.PerformLayout()
        CType(Me.GridControlRekapTagihan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewRekapTagihan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageRekapInvoice.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel1.PerformLayout()
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.ResumeLayout(False)
        CType(Me.GridControlRekapInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewRekapInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents ButtonClose As System.Windows.Forms.Button
    Friend WithEvents PanelReportPendapatanKlinik As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents NavBarControl1 As DevExpress.XtraNavBar.NavBarControl
    Friend WithEvents NavBarGroup1 As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents NavBarItemLaporanPendapatan As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem2 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents TabControlMenu As System.Windows.Forms.TabControl
    Friend WithEvents TabPageLaporanPendapatan As System.Windows.Forms.TabPage
    Friend WithEvents TabPageRekapTagihan As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainerLaporanPendapatanMain As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainerLaporanPendapatanHeader As System.Windows.Forms.SplitContainer
    Friend WithEvents Label157 As System.Windows.Forms.Label
    Friend WithEvents ButtonFindPerusahaanLaporanPendapatan As System.Windows.Forms.Button
    Friend WithEvents Label203 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNamaPerusahaanLaporanPendapatan As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TglAkhirTransaksiLaporanPendapatan As System.Windows.Forms.DateTimePicker
    Friend WithEvents TglAwalTransaksiLaporanPendapatan As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents ButtonViewDataPendapatan As System.Windows.Forms.Button
    Friend WithEvents NavBarItemRekapTagihan As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents FlowLayoutPanel4 As System.Windows.Forms.FlowLayoutPanel
    Private WithEvents GridControlLaporanPendapatan As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewLaporanPendapatan As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ComboBoxPoliTujuanLaporanPendapatan As System.Windows.Forms.ComboBox
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents RadioButtonOptionLaporanPendapatanTagihan As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonOptionLaporanPendapatan As System.Windows.Forms.RadioButton
    Friend WithEvents ButtonCetakLaporanPendapatan As System.Windows.Forms.Button
    Friend WithEvents CheckBoxTunai As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxTagihan As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxCard As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxDebet As System.Windows.Forms.CheckBox
    Friend WithEvents ButtonClearDataLaporanPendapatan As System.Windows.Forms.Button
    Friend WithEvents SplitContainerRekapTagihanMain As System.Windows.Forms.SplitContainer
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents ButtonClearDataRekapTagihan As System.Windows.Forms.Button
    Friend WithEvents SplitContainerRekapTagihanHeader As System.Windows.Forms.SplitContainer
    Friend WithEvents ComboBoxJenisPoliOrTransaksi As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonViewDataRekapTagihan As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TglAkhirTransaksiRekapTagihan As System.Windows.Forms.DateTimePicker
    Friend WithEvents TglAwalTransaksiRekapTagihan As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNamaPerusahaanRekapTagihan As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ButtonFindPerusahaanRekapTagihan As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Private WithEvents GridControlRekapTagihan As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewRekapTagihan As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents CheckBoxSemuaTransaksiRekapTagihan As System.Windows.Forms.CheckBox
    Friend WithEvents PanelCreateInvoice As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TglJatuhTempoRekapTagihan As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBoxBankTransferKeterangan As System.Windows.Forms.TextBox
    Friend WithEvents ButtonFindBankTagihan As System.Windows.Forms.Button
    Friend WithEvents TextBoxBankTransferCoa As System.Windows.Forms.TextBox
    Friend WithEvents ButtonSimpanRekapTagihan As System.Windows.Forms.Button
    Friend WithEvents NavBarItemRekapInvoice As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents TabPageRekapInvoice As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents ButtonClearDataRekapInvoice As System.Windows.Forms.Button
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents ButtonCariDataInvoice As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TglAkhirTransaksiRekapInvoice As System.Windows.Forms.DateTimePicker
    Friend WithEvents TglAwalTransaksiRekapInvoice As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNamaPerusahaanRekapInvoice As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ButtonFindPerusahaanRekapInvoice As System.Windows.Forms.Button
    Private WithEvents GridControlRekapInvoice As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewRekapInvoice As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TextBoxNamaPerusahaanInvoice As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxNomorInvoice As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxNominalInvoice As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TglJatuhTempoInvoice As System.Windows.Forms.DateTimePicker
    Friend WithEvents TglInvoice As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TextBoxBankInvoice As System.Windows.Forms.TextBox
    Friend WithEvents ButtonCetakInvoiceTagihan As System.Windows.Forms.Button
    Friend WithEvents ButtonCetakRekapTagihan As System.Windows.Forms.Button
    Friend WithEvents ButtonHapusTagihan As System.Windows.Forms.Button
    Friend WithEvents ButtonKirimUlangJurnal As System.Windows.Forms.Button
    Friend WithEvents TextBoxNoTagihan As System.Windows.Forms.TextBox
    Friend WithEvents CheckBoxTransaksiNolRupiah As System.Windows.Forms.CheckBox
End Class
