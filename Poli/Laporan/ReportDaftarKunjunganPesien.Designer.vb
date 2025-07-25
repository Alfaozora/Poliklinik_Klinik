<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportDaftarKunjunganPesien
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportDaftarKunjunganPesien))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.PanelTop = New System.Windows.Forms.Panel
        Me.btnClose = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.PanelKeadaanUmumMenuPemeriksaanAwal = New System.Windows.Forms.Panel
        Me.TextBoxNomorTransaksi = New System.Windows.Forms.TextBox
        Me.ButtonCariPeserta = New System.Windows.Forms.Button
        Me.TextBoxNomorPeserta = New System.Windows.Forms.TextBox
        Me.ButtonSearchDaftarPeserta = New System.Windows.Forms.Button
        Me.DateTimePickerTglHarian = New System.Windows.Forms.DateTimePicker
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.RadioButtonKunjunganSehat = New System.Windows.Forms.RadioButton
        Me.RadioButtonKunjunganSakit = New System.Windows.Forms.RadioButton
        Me.RadioButtonOpsiNoTransaksi = New System.Windows.Forms.RadioButton
        Me.RadioButtonOpsiIndividu = New System.Windows.Forms.RadioButton
        Me.RadioButtonOpsiHarian = New System.Windows.Forms.RadioButton
        Me.Label3 = New System.Windows.Forms.Label
        Me.ComboBoxTahun = New System.Windows.Forms.ComboBox
        Me.RadioButtonOpsiBulanan = New System.Windows.Forms.RadioButton
        Me.ComboBoxBulan = New System.Windows.Forms.ComboBox
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer
        Me.DataGridViewDaftarKunjungan = New System.Windows.Forms.DataGridView
        Me.PanelTop.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.DataGridViewDaftarKunjungan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.PanelTop.Controls.Add(Me.btnClose)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(1000, 35)
        Me.PanelTop.TabIndex = 5
        '
        'btnClose
        '
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(953, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(47, 35)
        Me.btnClose.TabIndex = 281
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.PanelKeadaanUmumMenuPemeriksaanAwal)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1000, 225)
        Me.Panel1.TabIndex = 6
        '
        'PanelKeadaanUmumMenuPemeriksaanAwal
        '
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.BackColor = System.Drawing.Color.Transparent
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.Controls.Add(Me.TextBoxNomorTransaksi)
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.Controls.Add(Me.ButtonCariPeserta)
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.Controls.Add(Me.TextBoxNomorPeserta)
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.Controls.Add(Me.ButtonSearchDaftarPeserta)
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.Controls.Add(Me.DateTimePickerTglHarian)
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.Controls.Add(Me.Panel2)
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.Controls.Add(Me.RadioButtonOpsiNoTransaksi)
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.Controls.Add(Me.RadioButtonOpsiIndividu)
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.Controls.Add(Me.RadioButtonOpsiHarian)
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.Controls.Add(Me.Label3)
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.Controls.Add(Me.ComboBoxTahun)
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.Controls.Add(Me.RadioButtonOpsiBulanan)
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.Controls.Add(Me.ComboBoxBulan)
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.Location = New System.Drawing.Point(41, 11)
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.Name = "PanelKeadaanUmumMenuPemeriksaanAwal"
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.Size = New System.Drawing.Size(415, 211)
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.TabIndex = 521
        '
        'TextBoxNomorTransaksi
        '
        Me.TextBoxNomorTransaksi.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxNomorTransaksi.Location = New System.Drawing.Point(148, 131)
        Me.TextBoxNomorTransaksi.Name = "TextBoxNomorTransaksi"
        Me.TextBoxNomorTransaksi.Size = New System.Drawing.Size(256, 25)
        Me.TextBoxNomorTransaksi.TabIndex = 528
        '
        'ButtonCariPeserta
        '
        Me.ButtonCariPeserta.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCariPeserta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonCariPeserta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonCariPeserta.FlatAppearance.BorderSize = 0
        Me.ButtonCariPeserta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCariPeserta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonCariPeserta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCariPeserta.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonCariPeserta.ForeColor = System.Drawing.Color.White
        Me.ButtonCariPeserta.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_search_16
        Me.ButtonCariPeserta.Location = New System.Drawing.Point(370, 100)
        Me.ButtonCariPeserta.Name = "ButtonCariPeserta"
        Me.ButtonCariPeserta.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonCariPeserta.Size = New System.Drawing.Size(34, 25)
        Me.ButtonCariPeserta.TabIndex = 527
        Me.ButtonCariPeserta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonCariPeserta.UseVisualStyleBackColor = False
        '
        'TextBoxNomorPeserta
        '
        Me.TextBoxNomorPeserta.BackColor = System.Drawing.Color.White
        Me.TextBoxNomorPeserta.Cursor = System.Windows.Forms.Cursors.No
        Me.TextBoxNomorPeserta.Enabled = False
        Me.TextBoxNomorPeserta.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxNomorPeserta.Location = New System.Drawing.Point(148, 100)
        Me.TextBoxNomorPeserta.Name = "TextBoxNomorPeserta"
        Me.TextBoxNomorPeserta.Size = New System.Drawing.Size(216, 25)
        Me.TextBoxNomorPeserta.TabIndex = 526
        Me.TextBoxNomorPeserta.TabStop = False
        '
        'ButtonSearchDaftarPeserta
        '
        Me.ButtonSearchDaftarPeserta.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSearchDaftarPeserta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonSearchDaftarPeserta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonSearchDaftarPeserta.FlatAppearance.BorderSize = 0
        Me.ButtonSearchDaftarPeserta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSearchDaftarPeserta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonSearchDaftarPeserta.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSearchDaftarPeserta.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonSearchDaftarPeserta.ForeColor = System.Drawing.Color.White
        Me.ButtonSearchDaftarPeserta.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_view_24
        Me.ButtonSearchDaftarPeserta.Location = New System.Drawing.Point(148, 162)
        Me.ButtonSearchDaftarPeserta.Name = "ButtonSearchDaftarPeserta"
        Me.ButtonSearchDaftarPeserta.Size = New System.Drawing.Size(256, 35)
        Me.ButtonSearchDaftarPeserta.TabIndex = 511
        Me.ButtonSearchDaftarPeserta.Text = " Cari Data"
        Me.ButtonSearchDaftarPeserta.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonSearchDaftarPeserta.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonSearchDaftarPeserta.UseVisualStyleBackColor = False
        '
        'DateTimePickerTglHarian
        '
        Me.DateTimePickerTglHarian.CustomFormat = "dd-MMM-yyyy"
        Me.DateTimePickerTglHarian.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.DateTimePickerTglHarian.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerTglHarian.Location = New System.Drawing.Point(148, 35)
        Me.DateTimePickerTglHarian.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DateTimePickerTglHarian.Name = "DateTimePickerTglHarian"
        Me.DateTimePickerTglHarian.Size = New System.Drawing.Size(125, 25)
        Me.DateTimePickerTglHarian.TabIndex = 524
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.RadioButtonKunjunganSehat)
        Me.Panel2.Controls.Add(Me.RadioButtonKunjunganSakit)
        Me.Panel2.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Panel2.Location = New System.Drawing.Point(148, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(258, 25)
        Me.Panel2.TabIndex = 525
        '
        'RadioButtonKunjunganSehat
        '
        Me.RadioButtonKunjunganSehat.AutoSize = True
        Me.RadioButtonKunjunganSehat.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonKunjunganSehat.Location = New System.Drawing.Point(129, 3)
        Me.RadioButtonKunjunganSehat.Name = "RadioButtonKunjunganSehat"
        Me.RadioButtonKunjunganSehat.Size = New System.Drawing.Size(123, 21)
        Me.RadioButtonKunjunganSehat.TabIndex = 440
        Me.RadioButtonKunjunganSehat.Text = "Kunjungan Sehat"
        Me.RadioButtonKunjunganSehat.UseVisualStyleBackColor = True
        '
        'RadioButtonKunjunganSakit
        '
        Me.RadioButtonKunjunganSakit.AutoSize = True
        Me.RadioButtonKunjunganSakit.Checked = True
        Me.RadioButtonKunjunganSakit.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonKunjunganSakit.Location = New System.Drawing.Point(5, 3)
        Me.RadioButtonKunjunganSakit.Name = "RadioButtonKunjunganSakit"
        Me.RadioButtonKunjunganSakit.Size = New System.Drawing.Size(118, 21)
        Me.RadioButtonKunjunganSakit.TabIndex = 245
        Me.RadioButtonKunjunganSakit.TabStop = True
        Me.RadioButtonKunjunganSakit.Text = "Kunjungan Sakit"
        Me.RadioButtonKunjunganSakit.UseVisualStyleBackColor = True
        '
        'RadioButtonOpsiNoTransaksi
        '
        Me.RadioButtonOpsiNoTransaksi.AutoSize = True
        Me.RadioButtonOpsiNoTransaksi.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.RadioButtonOpsiNoTransaksi.Location = New System.Drawing.Point(6, 132)
        Me.RadioButtonOpsiNoTransaksi.Name = "RadioButtonOpsiNoTransaksi"
        Me.RadioButtonOpsiNoTransaksi.Size = New System.Drawing.Size(103, 21)
        Me.RadioButtonOpsiNoTransaksi.TabIndex = 441
        Me.RadioButtonOpsiNoTransaksi.Text = "No Transaksi"
        Me.RadioButtonOpsiNoTransaksi.UseVisualStyleBackColor = True
        '
        'RadioButtonOpsiIndividu
        '
        Me.RadioButtonOpsiIndividu.AutoSize = True
        Me.RadioButtonOpsiIndividu.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.RadioButtonOpsiIndividu.Location = New System.Drawing.Point(6, 101)
        Me.RadioButtonOpsiIndividu.Name = "RadioButtonOpsiIndividu"
        Me.RadioButtonOpsiIndividu.Size = New System.Drawing.Size(75, 21)
        Me.RadioButtonOpsiIndividu.TabIndex = 440
        Me.RadioButtonOpsiIndividu.Text = "Individu"
        Me.RadioButtonOpsiIndividu.UseVisualStyleBackColor = True
        '
        'RadioButtonOpsiHarian
        '
        Me.RadioButtonOpsiHarian.AutoSize = True
        Me.RadioButtonOpsiHarian.Checked = True
        Me.RadioButtonOpsiHarian.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.RadioButtonOpsiHarian.Location = New System.Drawing.Point(6, 39)
        Me.RadioButtonOpsiHarian.Name = "RadioButtonOpsiHarian"
        Me.RadioButtonOpsiHarian.Size = New System.Drawing.Size(66, 21)
        Me.RadioButtonOpsiHarian.TabIndex = 245
        Me.RadioButtonOpsiHarian.TabStop = True
        Me.RadioButtonOpsiHarian.Text = "Harian"
        Me.RadioButtonOpsiHarian.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(3, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 17)
        Me.Label3.TabIndex = 522
        Me.Label3.Text = "Tingkat Pelayanan"
        '
        'ComboBoxTahun
        '
        Me.ComboBoxTahun.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.ComboBoxTahun.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBoxTahun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxTahun.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBoxTahun.FormattingEnabled = True
        Me.ComboBoxTahun.Items.AddRange(New Object() {"Kunjungan Sakit", "Kunjungan Sehat"})
        Me.ComboBoxTahun.Location = New System.Drawing.Point(279, 68)
        Me.ComboBoxTahun.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxTahun.Name = "ComboBoxTahun"
        Me.ComboBoxTahun.Size = New System.Drawing.Size(125, 25)
        Me.ComboBoxTahun.TabIndex = 517
        '
        'RadioButtonOpsiBulanan
        '
        Me.RadioButtonOpsiBulanan.AutoSize = True
        Me.RadioButtonOpsiBulanan.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.RadioButtonOpsiBulanan.Location = New System.Drawing.Point(6, 69)
        Me.RadioButtonOpsiBulanan.Name = "RadioButtonOpsiBulanan"
        Me.RadioButtonOpsiBulanan.Size = New System.Drawing.Size(75, 21)
        Me.RadioButtonOpsiBulanan.TabIndex = 246
        Me.RadioButtonOpsiBulanan.Text = "Bulanan"
        Me.RadioButtonOpsiBulanan.UseVisualStyleBackColor = True
        '
        'ComboBoxBulan
        '
        Me.ComboBoxBulan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.ComboBoxBulan.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBoxBulan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxBulan.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBoxBulan.FormattingEnabled = True
        Me.ComboBoxBulan.Items.AddRange(New Object() {"Kunjungan Sakit", "Kunjungan Sehat"})
        Me.ComboBoxBulan.Location = New System.Drawing.Point(148, 68)
        Me.ComboBoxBulan.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxBulan.Name = "ComboBoxBulan"
        Me.ComboBoxBulan.Size = New System.Drawing.Size(125, 25)
        Me.ComboBoxBulan.TabIndex = 516
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer3.IsSplitterFixed = True
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 35)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.AutoScroll = True
        Me.SplitContainer3.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.AutoScroll = True
        Me.SplitContainer3.Panel2.Controls.Add(Me.DataGridViewDaftarKunjungan)
        Me.SplitContainer3.Size = New System.Drawing.Size(1000, 540)
        Me.SplitContainer3.SplitterDistance = 225
        Me.SplitContainer3.SplitterWidth = 5
        Me.SplitContainer3.TabIndex = 462
        '
        'DataGridViewDaftarKunjungan
        '
        Me.DataGridViewDaftarKunjungan.AllowUserToAddRows = False
        Me.DataGridViewDaftarKunjungan.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewDaftarKunjungan.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewDaftarKunjungan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridViewDaftarKunjungan.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridViewDaftarKunjungan.BackgroundColor = System.Drawing.Color.White
        Me.DataGridViewDaftarKunjungan.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridViewDaftarKunjungan.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DataGridViewDaftarKunjungan.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(218, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(3)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewDaftarKunjungan.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewDaftarKunjungan.ColumnHeadersHeight = 40
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.Padding = New System.Windows.Forms.Padding(3)
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(186, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(149, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewDaftarKunjungan.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewDaftarKunjungan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewDaftarKunjungan.EnableHeadersVisualStyles = False
        Me.DataGridViewDaftarKunjungan.Location = New System.Drawing.Point(0, 0)
        Me.DataGridViewDaftarKunjungan.Name = "DataGridViewDaftarKunjungan"
        Me.DataGridViewDaftarKunjungan.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle4.Padding = New System.Windows.Forms.Padding(3)
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewDaftarKunjungan.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewDaftarKunjungan.RowHeadersVisible = False
        Me.DataGridViewDaftarKunjungan.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.DataGridViewDaftarKunjungan.RowTemplate.Height = 35
        Me.DataGridViewDaftarKunjungan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridViewDaftarKunjungan.Size = New System.Drawing.Size(1000, 310)
        Me.DataGridViewDaftarKunjungan.TabIndex = 517
        '
        'ReportDaftarKunjunganPesien
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1000, 575)
        Me.ControlBox = False
        Me.Controls.Add(Me.SplitContainer3)
        Me.Controls.Add(Me.PanelTop)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ReportDaftarKunjunganPesien"
        Me.PanelTop.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.ResumeLayout(False)
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.ResumeLayout(False)
        CType(Me.DataGridViewDaftarKunjungan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ButtonSearchDaftarPeserta As System.Windows.Forms.Button
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents DataGridViewDaftarKunjungan As System.Windows.Forms.DataGridView
    Friend WithEvents ComboBoxTahun As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxBulan As System.Windows.Forms.ComboBox
    Friend WithEvents PanelKeadaanUmumMenuPemeriksaanAwal As System.Windows.Forms.Panel
    Friend WithEvents RadioButtonOpsiIndividu As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonOpsiHarian As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonOpsiBulanan As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents RadioButtonOpsiNoTransaksi As System.Windows.Forms.RadioButton
    Friend WithEvents DateTimePickerTglHarian As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents RadioButtonKunjunganSehat As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonKunjunganSakit As System.Windows.Forms.RadioButton
    Friend WithEvents TextBoxNomorPeserta As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxNomorTransaksi As System.Windows.Forms.TextBox
    Friend WithEvents ButtonCariPeserta As System.Windows.Forms.Button
End Class
