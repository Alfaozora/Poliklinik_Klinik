<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMasterKapitasi
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMasterKapitasi))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UploadDataToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DownloadFormatUploadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.gridkapitasi = New DevExpress.XtraGrid.GridControl
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.ButtonFindCabang = New System.Windows.Forms.Button
        Me.Label16 = New System.Windows.Forms.Label
        Me.TextBoxKeteranganLokasi = New System.Windows.Forms.TextBox
        Me.butsavemultiple = New System.Windows.Forms.Button
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.rdya = New System.Windows.Forms.RadioButton
        Me.rdtidak = New System.Windows.Forms.RadioButton
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmbbulan2 = New System.Windows.Forms.ComboBox
        Me.lblsampai = New System.Windows.Forms.Label
        Me.gridexcel = New DevExpress.XtraGrid.GridControl
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.lbltext2 = New System.Windows.Forms.Label
        Me.txharga2 = New System.Windows.Forms.TextBox
        Me.txharga1 = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.rdbpjs = New System.Windows.Forms.RadioButton
        Me.rdinhealth = New System.Windows.Forms.RadioButton
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.rdklinik = New System.Windows.Forms.RadioButton
        Me.rdlab = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.butsavelab = New System.Windows.Forms.Button
        Me.lbltext1 = New System.Windows.Forms.Label
        Me.cmbtahun = New System.Windows.Forms.ComboBox
        Me.cmbbulan1 = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        CType(Me.gridkapitasi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.gridexcel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 360)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(472, 10)
        Me.GroupBox1.TabIndex = 108
        Me.GroupBox1.TabStop = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.UploadDataToolStripMenuItem, Me.DownloadFormatUploadToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(472, 24)
        Me.MenuStrip1.TabIndex = 107
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(88, 20)
        Me.NewToolStripMenuItem.Text = "Tambah Data"
        '
        'UploadDataToolStripMenuItem
        '
        Me.UploadDataToolStripMenuItem.Name = "UploadDataToolStripMenuItem"
        Me.UploadDataToolStripMenuItem.Size = New System.Drawing.Size(84, 20)
        Me.UploadDataToolStripMenuItem.Text = "Upload Data"
        '
        'DownloadFormatUploadToolStripMenuItem
        '
        Me.DownloadFormatUploadToolStripMenuItem.Name = "DownloadFormatUploadToolStripMenuItem"
        Me.DownloadFormatUploadToolStripMenuItem.Size = New System.Drawing.Size(155, 20)
        Me.DownloadFormatUploadToolStripMenuItem.Text = "Download Format Upload"
        '
        'gridkapitasi
        '
        Me.gridkapitasi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridkapitasi.EmbeddedNavigator.Name = ""
        Me.gridkapitasi.Location = New System.Drawing.Point(0, 370)
        Me.gridkapitasi.MainView = Me.GridView2
        Me.gridkapitasi.Name = "gridkapitasi"
        Me.gridkapitasi.Size = New System.Drawing.Size(472, 143)
        Me.gridkapitasi.TabIndex = 106
        Me.gridkapitasi.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.gridkapitasi
        Me.GridView2.GroupPanelText = "Daftar Kapitasi"
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsView.ShowAutoFilterRow = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ButtonFindCabang)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.TextBoxKeteranganLokasi)
        Me.GroupBox3.Controls.Add(Me.butsavemultiple)
        Me.GroupBox3.Controls.Add(Me.Panel3)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.cmbbulan2)
        Me.GroupBox3.Controls.Add(Me.lblsampai)
        Me.GroupBox3.Controls.Add(Me.gridexcel)
        Me.GroupBox3.Controls.Add(Me.lbltext2)
        Me.GroupBox3.Controls.Add(Me.txharga2)
        Me.GroupBox3.Controls.Add(Me.txharga1)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Panel1)
        Me.GroupBox3.Controls.Add(Me.Panel2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.butsavelab)
        Me.GroupBox3.Controls.Add(Me.lbltext1)
        Me.GroupBox3.Controls.Add(Me.cmbtahun)
        Me.GroupBox3.Controls.Add(Me.cmbbulan1)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Location = New System.Drawing.Point(0, 24)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(472, 336)
        Me.GroupBox3.TabIndex = 109
        Me.GroupBox3.TabStop = False
        '
        'ButtonFindCabang
        '
        Me.ButtonFindCabang.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindCabang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonFindCabang.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonFindCabang.FlatAppearance.BorderSize = 0
        Me.ButtonFindCabang.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindCabang.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonFindCabang.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonFindCabang.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonFindCabang.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ButtonFindCabang.Location = New System.Drawing.Point(390, 16)
        Me.ButtonFindCabang.Name = "ButtonFindCabang"
        Me.ButtonFindCabang.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonFindCabang.Size = New System.Drawing.Size(60, 25)
        Me.ButtonFindCabang.TabIndex = 443
        Me.ButtonFindCabang.Text = " Cari"
        Me.ButtonFindCabang.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonFindCabang.UseVisualStyleBackColor = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label16.Location = New System.Drawing.Point(106, 19)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(54, 17)
        Me.Label16.TabIndex = 332
        Me.Label16.Text = "Cabang"
        '
        'TextBoxKeteranganLokasi
        '
        Me.TextBoxKeteranganLokasi.BackColor = System.Drawing.Color.White
        Me.TextBoxKeteranganLokasi.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TextBoxKeteranganLokasi.Location = New System.Drawing.Point(170, 16)
        Me.TextBoxKeteranganLokasi.Name = "TextBoxKeteranganLokasi"
        Me.TextBoxKeteranganLokasi.ReadOnly = True
        Me.TextBoxKeteranganLokasi.Size = New System.Drawing.Size(214, 25)
        Me.TextBoxKeteranganLokasi.TabIndex = 330
        '
        'butsavemultiple
        '
        Me.butsavemultiple.Cursor = System.Windows.Forms.Cursors.Hand
        Me.butsavemultiple.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butsavemultiple.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butsavemultiple.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_kosong
        Me.butsavemultiple.Location = New System.Drawing.Point(276, 265)
        Me.butsavemultiple.Name = "butsavemultiple"
        Me.butsavemultiple.Size = New System.Drawing.Size(100, 36)
        Me.butsavemultiple.TabIndex = 329
        Me.butsavemultiple.Text = "SAVE MULTIPLE"
        Me.butsavemultiple.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.Control
        Me.Panel3.Controls.Add(Me.rdya)
        Me.Panel3.Controls.Add(Me.rdtidak)
        Me.Panel3.Location = New System.Drawing.Point(170, 233)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(255, 25)
        Me.Panel3.TabIndex = 327
        '
        'rdya
        '
        Me.rdya.AutoSize = True
        Me.rdya.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.rdya.Location = New System.Drawing.Point(5, 3)
        Me.rdya.Name = "rdya"
        Me.rdya.Size = New System.Drawing.Size(39, 21)
        Me.rdya.TabIndex = 245
        Me.rdya.TabStop = True
        Me.rdya.Text = "Ya"
        Me.rdya.UseVisualStyleBackColor = True
        '
        'rdtidak
        '
        Me.rdtidak.AutoSize = True
        Me.rdtidak.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.rdtidak.Location = New System.Drawing.Point(80, 3)
        Me.rdtidak.Name = "rdtidak"
        Me.rdtidak.Size = New System.Drawing.Size(57, 21)
        Me.rdtidak.TabIndex = 246
        Me.rdtidak.TabStop = True
        Me.rdtidak.Text = "Tidak"
        Me.rdtidak.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(109, 238)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 17)
        Me.Label9.TabIndex = 326
        Me.Label9.Text = "Upload"
        '
        'cmbbulan2
        '
        Me.cmbbulan2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbbulan2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbbulan2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbbulan2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cmbbulan2.FormattingEnabled = True
        Me.cmbbulan2.Location = New System.Drawing.Point(330, 110)
        Me.cmbbulan2.Name = "cmbbulan2"
        Me.cmbbulan2.Size = New System.Drawing.Size(120, 25)
        Me.cmbbulan2.TabIndex = 325
        Me.cmbbulan2.Tag = "3054"
        '
        'lblsampai
        '
        Me.lblsampai.AutoSize = True
        Me.lblsampai.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblsampai.Location = New System.Drawing.Point(296, 113)
        Me.lblsampai.Name = "lblsampai"
        Me.lblsampai.Size = New System.Drawing.Size(28, 17)
        Me.lblsampai.TabIndex = 324
        Me.lblsampai.Text = "s.d."
        '
        'gridexcel
        '
        Me.gridexcel.EmbeddedNavigator.Name = ""
        Me.gridexcel.Location = New System.Drawing.Point(9, 94)
        Me.gridexcel.MainView = Me.GridView3
        Me.gridexcel.Name = "gridexcel"
        Me.gridexcel.Size = New System.Drawing.Size(100, 36)
        Me.gridexcel.TabIndex = 323
        Me.gridexcel.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
        Me.gridexcel.Visible = False
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.gridexcel
        Me.GridView3.Name = "GridView3"
        '
        'lbltext2
        '
        Me.lbltext2.AutoSize = True
        Me.lbltext2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lbltext2.Location = New System.Drawing.Point(5, 205)
        Me.lbltext2.Name = "lbltext2"
        Me.lbltext2.Size = New System.Drawing.Size(155, 17)
        Me.lbltext2.TabIndex = 322
        Me.lbltext2.Text = "Nominal Gigi / Non COB"
        Me.lbltext2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txharga2
        '
        Me.txharga2.BackColor = System.Drawing.SystemColors.Window
        Me.txharga2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txharga2.Location = New System.Drawing.Point(200, 202)
        Me.txharga2.Name = "txharga2"
        Me.txharga2.Size = New System.Drawing.Size(90, 25)
        Me.txharga2.TabIndex = 321
        '
        'txharga1
        '
        Me.txharga1.BackColor = System.Drawing.SystemColors.Window
        Me.txharga1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txharga1.Location = New System.Drawing.Point(200, 171)
        Me.txharga1.Name = "txharga1"
        Me.txharga1.Size = New System.Drawing.Size(90, 25)
        Me.txharga1.TabIndex = 320
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label19.Location = New System.Drawing.Point(167, 205)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(27, 17)
        Me.Label19.TabIndex = 319
        Me.Label19.Text = "Rp."
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label22.Location = New System.Drawing.Point(167, 174)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(27, 17)
        Me.Label22.TabIndex = 318
        Me.Label22.Text = "Rp."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(115, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 17)
        Me.Label2.TabIndex = 317
        Me.Label2.Text = "Lokasi"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.rdbpjs)
        Me.Panel1.Controls.Add(Me.rdinhealth)
        Me.Panel1.Location = New System.Drawing.Point(170, 47)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(255, 25)
        Me.Panel1.TabIndex = 316
        '
        'rdbpjs
        '
        Me.rdbpjs.AutoSize = True
        Me.rdbpjs.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.rdbpjs.Location = New System.Drawing.Point(5, 3)
        Me.rdbpjs.Name = "rdbpjs"
        Me.rdbpjs.Size = New System.Drawing.Size(51, 21)
        Me.rdbpjs.TabIndex = 314
        Me.rdbpjs.TabStop = True
        Me.rdbpjs.Text = "BPJS"
        Me.rdbpjs.UseVisualStyleBackColor = True
        '
        'rdinhealth
        '
        Me.rdinhealth.AutoSize = True
        Me.rdinhealth.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.rdinhealth.Location = New System.Drawing.Point(80, 3)
        Me.rdinhealth.Name = "rdinhealth"
        Me.rdinhealth.Size = New System.Drawing.Size(71, 21)
        Me.rdinhealth.TabIndex = 313
        Me.rdinhealth.TabStop = True
        Me.rdinhealth.Text = "Inhealth"
        Me.rdinhealth.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.Panel2.Controls.Add(Me.rdklinik)
        Me.Panel2.Controls.Add(Me.rdlab)
        Me.Panel2.Location = New System.Drawing.Point(170, 78)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(255, 25)
        Me.Panel2.TabIndex = 315
        '
        'rdklinik
        '
        Me.rdklinik.AutoSize = True
        Me.rdklinik.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.rdklinik.Location = New System.Drawing.Point(5, 3)
        Me.rdklinik.Name = "rdklinik"
        Me.rdklinik.Size = New System.Drawing.Size(56, 21)
        Me.rdklinik.TabIndex = 245
        Me.rdklinik.TabStop = True
        Me.rdklinik.Text = "Klinik"
        Me.rdklinik.UseVisualStyleBackColor = True
        '
        'rdlab
        '
        Me.rdlab.AutoSize = True
        Me.rdlab.Enabled = False
        Me.rdlab.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.rdlab.Location = New System.Drawing.Point(80, 3)
        Me.rdlab.Name = "rdlab"
        Me.rdlab.Size = New System.Drawing.Size(105, 21)
        Me.rdlab.TabIndex = 246
        Me.rdlab.TabStop = True
        Me.rdlab.Text = "Laboratorium"
        Me.rdlab.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(72, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 17)
        Me.Label1.TabIndex = 312
        Me.Label1.Text = "Jenis Kapitasi"
        '
        'butsavelab
        '
        Me.butsavelab.Cursor = System.Windows.Forms.Cursors.Hand
        Me.butsavelab.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butsavelab.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_save
        Me.butsavelab.Location = New System.Drawing.Point(170, 264)
        Me.butsavelab.Name = "butsavelab"
        Me.butsavelab.Size = New System.Drawing.Size(100, 36)
        Me.butsavelab.TabIndex = 311
        Me.butsavelab.UseVisualStyleBackColor = True
        '
        'lbltext1
        '
        Me.lbltext1.AutoSize = True
        Me.lbltext1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lbltext1.Location = New System.Drawing.Point(17, 174)
        Me.lbltext1.Name = "lbltext1"
        Me.lbltext1.Size = New System.Drawing.Size(143, 17)
        Me.lbltext1.TabIndex = 269
        Me.lbltext1.Text = "Nominal Umum / COB"
        Me.lbltext1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmbtahun
        '
        Me.cmbtahun.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbtahun.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbtahun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbtahun.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cmbtahun.FormattingEnabled = True
        Me.cmbtahun.Location = New System.Drawing.Point(170, 140)
        Me.cmbtahun.Name = "cmbtahun"
        Me.cmbtahun.Size = New System.Drawing.Size(120, 25)
        Me.cmbtahun.TabIndex = 268
        Me.cmbtahun.Tag = "3054"
        '
        'cmbbulan1
        '
        Me.cmbbulan1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbbulan1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbbulan1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbbulan1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cmbbulan1.FormattingEnabled = True
        Me.cmbbulan1.Location = New System.Drawing.Point(170, 109)
        Me.cmbbulan1.Name = "cmbbulan1"
        Me.cmbbulan1.Size = New System.Drawing.Size(120, 25)
        Me.cmbbulan1.TabIndex = 267
        Me.cmbbulan1.Tag = "3054"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(115, 143)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 17)
        Me.Label4.TabIndex = 266
        Me.Label4.Text = "Tahun"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(118, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 17)
        Me.Label3.TabIndex = 264
        Me.Label3.Text = "Bulan"
        '
        'FormMasterKapitasi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(472, 513)
        Me.Controls.Add(Me.gridkapitasi)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormMasterKapitasi"
        Me.Text = "Master Kapitasi Klinik"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.gridkapitasi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.gridexcel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    'Friend WithEvents txtindakanbiaya As DevExpress.XtraEditors.TextEdit
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents buttindakanid As DevExpress.XtraEditors.ButtonEdit
    'Friend WithEvents txhargaprt As DevExpress.XtraEditors.TextEdit
    'Friend WithEvents txhargaprh As DevExpress.XtraEditors.TextEdit
    'Friend WithEvents txhargakd As DevExpress.XtraEditors.TextEdit
    Private WithEvents gridkapitasi As DevExpress.XtraGrid.GridControl
    Private WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbbulan1 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbtahun As System.Windows.Forms.ComboBox
    Friend WithEvents lbltext1 As System.Windows.Forms.Label
    Friend WithEvents butsavelab As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rdinhealth As System.Windows.Forms.RadioButton
    Friend WithEvents rdbpjs As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents rdklinik As System.Windows.Forms.RadioButton
    Friend WithEvents rdlab As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbltext2 As System.Windows.Forms.Label
    Friend WithEvents txharga2 As System.Windows.Forms.TextBox
    Friend WithEvents txharga1 As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents DownloadFormatUploadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gridexcel As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cmbbulan2 As System.Windows.Forms.ComboBox
    Friend WithEvents lblsampai As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents rdya As System.Windows.Forms.RadioButton
    Friend WithEvents rdtidak As System.Windows.Forms.RadioButton
    Friend WithEvents butsavemultiple As System.Windows.Forms.Button
    Friend WithEvents UploadDataToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TextBoxKeteranganLokasi As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ButtonFindCabang As System.Windows.Forms.Button
End Class
