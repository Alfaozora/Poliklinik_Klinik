<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormUploadGaji
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormUploadGaji))
        Me.PanelTop = New System.Windows.Forms.Panel
        Me.btnClose = New System.Windows.Forms.Button
        Me.PanelSide = New System.Windows.Forms.Panel
        Me.btnMenu3 = New System.Windows.Forms.Button
        Me.btnMenu2 = New System.Windows.Forms.Button
        Me.btnMenu1 = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.RadioButtonPilihanGaji = New System.Windows.Forms.RadioButton
        Me.RadioButtonPilihanTHR = New System.Windows.Forms.RadioButton
        Me.txPemberitahuan = New System.Windows.Forms.Label
        Me.txProcent = New System.Windows.Forms.Label
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.btnClear = New System.Windows.Forms.Button
        Me.btnSimpan = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbtahun = New System.Windows.Forms.ComboBox
        Me.cmbbulan = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnDownload = New System.Windows.Forms.Button
        Me.btnUpload = New System.Windows.Forms.Button
        Me.gridGaji = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Label2 = New System.Windows.Forms.Label
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.Label3 = New System.Windows.Forms.Label
        Me.ToolTipBtnMenu = New System.Windows.Forms.ToolTip(Me.components)
        Me.PanelTop.SuspendLayout()
        Me.PanelSide.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.gridGaji, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.PanelTop.Controls.Add(Me.btnClose)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(684, 40)
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
        Me.btnClose.Location = New System.Drawing.Point(644, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(40, 40)
        Me.btnClose.TabIndex = 281
        Me.ToolTipBtnMenu.SetToolTip(Me.btnClose, "Tutup Form")
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'PanelSide
        '
        Me.PanelSide.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.PanelSide.Controls.Add(Me.btnMenu3)
        Me.PanelSide.Controls.Add(Me.btnMenu2)
        Me.PanelSide.Controls.Add(Me.btnMenu1)
        Me.PanelSide.Dock = System.Windows.Forms.DockStyle.Left
        Me.PanelSide.Location = New System.Drawing.Point(0, 40)
        Me.PanelSide.Name = "PanelSide"
        Me.PanelSide.Size = New System.Drawing.Size(40, 321)
        Me.PanelSide.TabIndex = 1
        '
        'btnMenu3
        '
        Me.btnMenu3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnMenu3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMenu3.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnMenu3.FlatAppearance.BorderSize = 0
        Me.btnMenu3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMenu3.Image = CType(resources.GetObject("btnMenu3.Image"), System.Drawing.Image)
        Me.btnMenu3.Location = New System.Drawing.Point(0, 80)
        Me.btnMenu3.Name = "btnMenu3"
        Me.btnMenu3.Size = New System.Drawing.Size(40, 40)
        Me.btnMenu3.TabIndex = 2
        Me.ToolTipBtnMenu.SetToolTip(Me.btnMenu3, "Pengaturan")
        Me.btnMenu3.UseVisualStyleBackColor = True
        Me.btnMenu3.Visible = False
        '
        'btnMenu2
        '
        Me.btnMenu2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnMenu2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMenu2.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnMenu2.FlatAppearance.BorderSize = 0
        Me.btnMenu2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMenu2.Image = CType(resources.GetObject("btnMenu2.Image"), System.Drawing.Image)
        Me.btnMenu2.Location = New System.Drawing.Point(0, 40)
        Me.btnMenu2.Name = "btnMenu2"
        Me.btnMenu2.Size = New System.Drawing.Size(40, 40)
        Me.btnMenu2.TabIndex = 1
        Me.ToolTipBtnMenu.SetToolTip(Me.btnMenu2, "Tambah Waktu")
        Me.btnMenu2.UseVisualStyleBackColor = True
        Me.btnMenu2.Visible = False
        '
        'btnMenu1
        '
        Me.btnMenu1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnMenu1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnMenu1.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnMenu1.FlatAppearance.BorderSize = 0
        Me.btnMenu1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMenu1.Image = Global.PoliKlinik_Net2.My.Resources.Resources.calendar_icon30
        Me.btnMenu1.Location = New System.Drawing.Point(0, 0)
        Me.btnMenu1.Name = "btnMenu1"
        Me.btnMenu1.Size = New System.Drawing.Size(40, 40)
        Me.btnMenu1.TabIndex = 0
        Me.ToolTipBtnMenu.SetToolTip(Me.btnMenu1, "Tambah Data")
        Me.btnMenu1.UseVisualStyleBackColor = True
        Me.btnMenu1.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(40, 40)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(644, 321)
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.White
        Me.TabPage1.Controls.Add(Me.Panel3)
        Me.TabPage1.Controls.Add(Me.txPemberitahuan)
        Me.TabPage1.Controls.Add(Me.txProcent)
        Me.TabPage1.Controls.Add(Me.ProgressBar1)
        Me.TabPage1.Controls.Add(Me.btnClear)
        Me.TabPage1.Controls.Add(Me.btnSimpan)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.cmbtahun)
        Me.TabPage1.Controls.Add(Me.cmbbulan)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.btnDownload)
        Me.TabPage1.Controls.Add(Me.btnUpload)
        Me.TabPage1.Controls.Add(Me.gridGaji)
        Me.TabPage1.Location = New System.Drawing.Point(4, 27)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(636, 290)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Tab Menu 1"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.RadioButtonPilihanGaji)
        Me.Panel3.Controls.Add(Me.RadioButtonPilihanTHR)
        Me.Panel3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Panel3.Location = New System.Drawing.Point(73, 22)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(318, 25)
        Me.Panel3.TabIndex = 435
        '
        'RadioButtonPilihanGaji
        '
        Me.RadioButtonPilihanGaji.AutoSize = True
        Me.RadioButtonPilihanGaji.Checked = True
        Me.RadioButtonPilihanGaji.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonPilihanGaji.Location = New System.Drawing.Point(5, 3)
        Me.RadioButtonPilihanGaji.Name = "RadioButtonPilihanGaji"
        Me.RadioButtonPilihanGaji.Size = New System.Drawing.Size(48, 21)
        Me.RadioButtonPilihanGaji.TabIndex = 245
        Me.RadioButtonPilihanGaji.TabStop = True
        Me.RadioButtonPilihanGaji.Text = "Gaji"
        Me.RadioButtonPilihanGaji.UseVisualStyleBackColor = True
        '
        'RadioButtonPilihanTHR
        '
        Me.RadioButtonPilihanTHR.AutoSize = True
        Me.RadioButtonPilihanTHR.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonPilihanTHR.Location = New System.Drawing.Point(72, 3)
        Me.RadioButtonPilihanTHR.Name = "RadioButtonPilihanTHR"
        Me.RadioButtonPilihanTHR.Size = New System.Drawing.Size(50, 21)
        Me.RadioButtonPilihanTHR.TabIndex = 246
        Me.RadioButtonPilihanTHR.Text = "THR"
        Me.RadioButtonPilihanTHR.UseVisualStyleBackColor = True
        '
        'txPemberitahuan
        '
        Me.txPemberitahuan.AutoSize = True
        Me.txPemberitahuan.BackColor = System.Drawing.Color.Transparent
        Me.txPemberitahuan.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txPemberitahuan.Location = New System.Drawing.Point(56, 170)
        Me.txPemberitahuan.Name = "txPemberitahuan"
        Me.txPemberitahuan.Size = New System.Drawing.Size(12, 15)
        Me.txPemberitahuan.TabIndex = 280
        Me.txPemberitahuan.Text = "-"
        '
        'txProcent
        '
        Me.txProcent.AutoSize = True
        Me.txProcent.BackColor = System.Drawing.Color.Transparent
        Me.txProcent.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txProcent.Location = New System.Drawing.Point(16, 170)
        Me.txProcent.Name = "txProcent"
        Me.txProcent.Size = New System.Drawing.Size(27, 15)
        Me.txProcent.TabIndex = 279
        Me.txProcent.Text = "0 %"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.BackColor = System.Drawing.SystemColors.Control
        Me.ProgressBar1.ForeColor = System.Drawing.SystemColors.Control
        Me.ProgressBar1.Location = New System.Drawing.Point(19, 157)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(498, 10)
        Me.ProgressBar1.TabIndex = 277
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnClear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClear.FlatAppearance.BorderSize = 0
        Me.btnClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnClear.ForeColor = System.Drawing.Color.White
        Me.btnClear.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_clear_24
        Me.btnClear.Location = New System.Drawing.Point(397, 100)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnClear.Size = New System.Drawing.Size(120, 40)
        Me.btnClear.TabIndex = 276
        Me.btnClear.Text = " CLEAR"
        Me.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTipBtnMenu.SetToolTip(Me.btnClear, "Clear Data")
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'btnSimpan
        '
        Me.btnSimpan.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btnSimpan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSimpan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSimpan.FlatAppearance.BorderSize = 0
        Me.btnSimpan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btnSimpan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSimpan.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnSimpan.ForeColor = System.Drawing.Color.White
        Me.btnSimpan.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_save_24
        Me.btnSimpan.Location = New System.Drawing.Point(271, 100)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnSimpan.Size = New System.Drawing.Size(120, 40)
        Me.btnSimpan.TabIndex = 275
        Me.btnSimpan.Text = " SIMPAN"
        Me.btnSimpan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSimpan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTipBtnMenu.SetToolTip(Me.btnSimpan, "Simpan Data")
        Me.btnSimpan.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(16, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 17)
        Me.Label4.TabIndex = 273
        Me.Label4.Text = "Jenis"
        '
        'cmbtahun
        '
        Me.cmbtahun.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbtahun.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbtahun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbtahun.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.cmbtahun.FormattingEnabled = True
        Me.cmbtahun.Location = New System.Drawing.Point(271, 53)
        Me.cmbtahun.Name = "cmbtahun"
        Me.cmbtahun.Size = New System.Drawing.Size(120, 25)
        Me.cmbtahun.TabIndex = 272
        Me.cmbtahun.Tag = "3054"
        '
        'cmbbulan
        '
        Me.cmbbulan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbbulan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbbulan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbbulan.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.cmbbulan.FormattingEnabled = True
        Me.cmbbulan.Location = New System.Drawing.Point(73, 52)
        Me.cmbbulan.Name = "cmbbulan"
        Me.cmbbulan.Size = New System.Drawing.Size(120, 25)
        Me.cmbbulan.TabIndex = 271
        Me.cmbbulan.Tag = "3054"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(218, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 17)
        Me.Label1.TabIndex = 270
        Me.Label1.Text = "Tahun"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(16, 53)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 17)
        Me.Label5.TabIndex = 269
        Me.Label5.Text = "Bulan"
        '
        'btnDownload
        '
        Me.btnDownload.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btnDownload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnDownload.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDownload.FlatAppearance.BorderSize = 0
        Me.btnDownload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btnDownload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnDownload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDownload.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnDownload.ForeColor = System.Drawing.Color.White
        Me.btnDownload.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_send_24
        Me.btnDownload.Location = New System.Drawing.Point(19, 100)
        Me.btnDownload.Name = "btnDownload"
        Me.btnDownload.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnDownload.Size = New System.Drawing.Size(120, 40)
        Me.btnDownload.TabIndex = 236
        Me.btnDownload.Text = " DOWNLOAD"
        Me.btnDownload.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDownload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTipBtnMenu.SetToolTip(Me.btnDownload, "Download Template")
        Me.btnDownload.UseVisualStyleBackColor = False
        '
        'btnUpload
        '
        Me.btnUpload.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btnUpload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnUpload.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnUpload.FlatAppearance.BorderSize = 0
        Me.btnUpload.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btnUpload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpload.Font = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Bold)
        Me.btnUpload.ForeColor = System.Drawing.Color.White
        Me.btnUpload.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_send_24
        Me.btnUpload.Location = New System.Drawing.Point(145, 100)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnUpload.Size = New System.Drawing.Size(120, 40)
        Me.btnUpload.TabIndex = 235
        Me.btnUpload.Text = " UPLOAD"
        Me.btnUpload.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTipBtnMenu.SetToolTip(Me.btnUpload, "Upload Excel Data Gaji")
        Me.btnUpload.UseVisualStyleBackColor = False
        '
        'gridGaji
        '
        Me.gridGaji.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gridGaji.Cursor = System.Windows.Forms.Cursors.Hand
        Me.gridGaji.EmbeddedNavigator.Name = ""
        Me.gridGaji.Location = New System.Drawing.Point(3, 190)
        Me.gridGaji.MainView = Me.GridView1
        Me.gridGaji.Name = "gridGaji"
        Me.gridGaji.Size = New System.Drawing.Size(630, 97)
        Me.gridGaji.TabIndex = 1
        Me.gridGaji.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.gridGaji
        Me.GridView1.Name = "GridView1"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 27)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(636, 290)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Tab Menu 2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(185, 119)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(149, 32)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Tab Menu 2"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Label3)
        Me.TabPage3.Location = New System.Drawing.Point(4, 27)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(636, 290)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Tab Menu 3"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(185, 119)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(149, 32)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Tab Menu 3"
        '
        'ToolTipBtnMenu
        '
        Me.ToolTipBtnMenu.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTipBtnMenu.ToolTipTitle = "Detail"
        '
        'FormUploadGaji
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(684, 361)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.PanelSide)
        Me.Controls.Add(Me.PanelTop)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormUploadGaji"
        Me.PanelTop.ResumeLayout(False)
        Me.PanelSide.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.gridGaji, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents PanelSide As System.Windows.Forms.Panel
    Friend WithEvents btnMenu1 As System.Windows.Forms.Button
    Friend WithEvents btnMenu2 As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents btnMenu3 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToolTipBtnMenu As System.Windows.Forms.ToolTip
    Friend WithEvents gridGaji As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents btnUpload As System.Windows.Forms.Button
    Friend WithEvents btnDownload As System.Windows.Forms.Button
    Friend WithEvents cmbtahun As System.Windows.Forms.ComboBox
    Friend WithEvents cmbbulan As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnSimpan As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents txProcent As System.Windows.Forms.Label
    Friend WithEvents txPemberitahuan As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents RadioButtonPilihanGaji As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonPilihanTHR As System.Windows.Forms.RadioButton
End Class
