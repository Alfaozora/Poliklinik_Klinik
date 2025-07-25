<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FindTransaksi
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FindTransaksi))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.PanelTop = New System.Windows.Forms.Panel
        Me.btnClose = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ButtonFindTransaksi = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TextBoxNoAntrian = New System.Windows.Forms.TextBox
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.RadioButtonNoAntrian = New System.Windows.Forms.RadioButton
        Me.RadioButtonNoKartu = New System.Windows.Forms.RadioButton
        Me.ButtonFindNoAntrian = New System.Windows.Forms.Button
        Me.TextBoxAbjadBPJS = New System.Windows.Forms.TextBox
        Me.ComboBoxJenisKunjungan = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.ComboBoxPoliTujuan = New System.Windows.Forms.ComboBox
        Me.Label139 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtend = New System.Windows.Forms.DateTimePicker
        Me.dtprocess = New System.Windows.Forms.DateTimePicker
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer
        Me.DataGridViewKunjunganPasien = New System.Windows.Forms.DataGridView
        Me.SplitContainerFilterKunjungan = New System.Windows.Forms.SplitContainer
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel
        Me.Label5 = New System.Windows.Forms.Label
        Me.TextBoxSearchKunjungan = New System.Windows.Forms.TextBox
        Me.PanelTop.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.DataGridViewKunjunganPasien, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerFilterKunjungan.Panel1.SuspendLayout()
        Me.SplitContainerFilterKunjungan.Panel2.SuspendLayout()
        Me.SplitContainerFilterKunjungan.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
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
        Me.Panel1.Controls.Add(Me.ButtonFindTransaksi)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.ComboBoxJenisKunjungan)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.ComboBoxPoliTujuan)
        Me.Panel1.Controls.Add(Me.Label139)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.dtend)
        Me.Panel1.Controls.Add(Me.dtprocess)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1000, 165)
        Me.Panel1.TabIndex = 6
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
        Me.ButtonFindTransaksi.Location = New System.Drawing.Point(205, 120)
        Me.ButtonFindTransaksi.Name = "ButtonFindTransaksi"
        Me.ButtonFindTransaksi.Size = New System.Drawing.Size(285, 35)
        Me.ButtonFindTransaksi.TabIndex = 511
        Me.ButtonFindTransaksi.Text = " Cari Data"
        Me.ButtonFindTransaksi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonFindTransaksi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonFindTransaksi.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TextBoxNoAntrian)
        Me.GroupBox1.Controls.Add(Me.Panel6)
        Me.GroupBox1.Controls.Add(Me.ButtonFindNoAntrian)
        Me.GroupBox1.Controls.Add(Me.TextBoxAbjadBPJS)
        Me.GroupBox1.Location = New System.Drawing.Point(515, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(420, 85)
        Me.GroupBox1.TabIndex = 510
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pencarian Nomor Kartu BPJS"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(54, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 17)
        Me.Label3.TabIndex = 512
        Me.Label3.Text = "Sumber Data"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(34, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(107, 17)
        Me.Label4.TabIndex = 513
        Me.Label4.Text = "No. Pendaftaran"
        '
        'TextBoxNoAntrian
        '
        Me.TextBoxNoAntrian.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxNoAntrian.Location = New System.Drawing.Point(210, 51)
        Me.TextBoxNoAntrian.Name = "TextBoxNoAntrian"
        Me.TextBoxNoAntrian.Size = New System.Drawing.Size(122, 25)
        Me.TextBoxNoAntrian.TabIndex = 512
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.RadioButtonNoAntrian)
        Me.Panel6.Controls.Add(Me.RadioButtonNoKartu)
        Me.Panel6.Location = New System.Drawing.Point(179, 15)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(224, 30)
        Me.Panel6.TabIndex = 511
        '
        'RadioButtonNoAntrian
        '
        Me.RadioButtonNoAntrian.AutoSize = True
        Me.RadioButtonNoAntrian.Checked = True
        Me.RadioButtonNoAntrian.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonNoAntrian.Location = New System.Drawing.Point(5, 5)
        Me.RadioButtonNoAntrian.Name = "RadioButtonNoAntrian"
        Me.RadioButtonNoAntrian.Size = New System.Drawing.Size(92, 21)
        Me.RadioButtonNoAntrian.TabIndex = 226
        Me.RadioButtonNoAntrian.TabStop = True
        Me.RadioButtonNoAntrian.Tag = "10"
        Me.RadioButtonNoAntrian.Text = "No. Antrian"
        Me.RadioButtonNoAntrian.UseVisualStyleBackColor = True
        '
        'RadioButtonNoKartu
        '
        Me.RadioButtonNoKartu.AutoSize = True
        Me.RadioButtonNoKartu.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonNoKartu.Location = New System.Drawing.Point(112, 5)
        Me.RadioButtonNoKartu.Name = "RadioButtonNoKartu"
        Me.RadioButtonNoKartu.Size = New System.Drawing.Size(82, 21)
        Me.RadioButtonNoKartu.TabIndex = 224
        Me.RadioButtonNoKartu.Tag = "50"
        Me.RadioButtonNoKartu.Text = "No. Kartu"
        Me.RadioButtonNoKartu.UseVisualStyleBackColor = True
        '
        'ButtonFindNoAntrian
        '
        Me.ButtonFindNoAntrian.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindNoAntrian.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonFindNoAntrian.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonFindNoAntrian.FlatAppearance.BorderSize = 0
        Me.ButtonFindNoAntrian.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindNoAntrian.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonFindNoAntrian.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonFindNoAntrian.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonFindNoAntrian.ForeColor = System.Drawing.Color.White
        Me.ButtonFindNoAntrian.Location = New System.Drawing.Point(338, 51)
        Me.ButtonFindNoAntrian.Name = "ButtonFindNoAntrian"
        Me.ButtonFindNoAntrian.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonFindNoAntrian.Size = New System.Drawing.Size(65, 25)
        Me.ButtonFindNoAntrian.TabIndex = 511
        Me.ButtonFindNoAntrian.Text = "Cari"
        Me.ButtonFindNoAntrian.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonFindNoAntrian.UseVisualStyleBackColor = False
        '
        'TextBoxAbjadBPJS
        '
        Me.TextBoxAbjadBPJS.BackColor = System.Drawing.Color.White
        Me.TextBoxAbjadBPJS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxAbjadBPJS.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TextBoxAbjadBPJS.Location = New System.Drawing.Point(179, 51)
        Me.TextBoxAbjadBPJS.Name = "TextBoxAbjadBPJS"
        Me.TextBoxAbjadBPJS.Size = New System.Drawing.Size(25, 25)
        Me.TextBoxAbjadBPJS.TabIndex = 511
        Me.TextBoxAbjadBPJS.Text = "A"
        Me.TextBoxAbjadBPJS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ComboBoxJenisKunjungan
        '
        Me.ComboBoxJenisKunjungan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.ComboBoxJenisKunjungan.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBoxJenisKunjungan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxJenisKunjungan.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBoxJenisKunjungan.FormattingEnabled = True
        Me.ComboBoxJenisKunjungan.Items.AddRange(New Object() {"Kunjungan Sakit", "Kunjungan Sehat"})
        Me.ComboBoxJenisKunjungan.Location = New System.Drawing.Point(205, 55)
        Me.ComboBoxJenisKunjungan.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxJenisKunjungan.Name = "ComboBoxJenisKunjungan"
        Me.ComboBoxJenisKunjungan.Size = New System.Drawing.Size(125, 25)
        Me.ComboBoxJenisKunjungan.TabIndex = 509
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(60, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 17)
        Me.Label2.TabIndex = 508
        Me.Label2.Text = "Jenis Kunjungan"
        '
        'ComboBoxPoliTujuan
        '
        Me.ComboBoxPoliTujuan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.ComboBoxPoliTujuan.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBoxPoliTujuan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxPoliTujuan.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBoxPoliTujuan.FormattingEnabled = True
        Me.ComboBoxPoliTujuan.Location = New System.Drawing.Point(205, 88)
        Me.ComboBoxPoliTujuan.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxPoliTujuan.Name = "ComboBoxPoliTujuan"
        Me.ComboBoxPoliTujuan.Size = New System.Drawing.Size(285, 25)
        Me.ComboBoxPoliTujuan.TabIndex = 507
        '
        'Label139
        '
        Me.Label139.AutoSize = True
        Me.Label139.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label139.Location = New System.Drawing.Point(93, 91)
        Me.Label139.Name = "Label139"
        Me.Label139.Size = New System.Drawing.Size(74, 17)
        Me.Label139.TabIndex = 506
        Me.Label139.Text = "Poli Tujuan"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(362, 7)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 13)
        Me.Label9.TabIndex = 453
        Me.Label9.Text = "Tgl Akhir"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(336, 30)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(23, 13)
        Me.Label8.TabIndex = 452
        Me.Label8.Text = "s/d"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(202, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 451
        Me.Label7.Text = "Tgl Awal"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(34, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 17)
        Me.Label1.TabIndex = 450
        Me.Label1.Text = "Tanggal Pendaftaran"
        '
        'dtend
        '
        Me.dtend.CalendarFont = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtend.CustomFormat = "dd-MMM-yyyy"
        Me.dtend.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtend.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtend.Location = New System.Drawing.Point(365, 23)
        Me.dtend.Name = "dtend"
        Me.dtend.Size = New System.Drawing.Size(125, 25)
        Me.dtend.TabIndex = 449
        '
        'dtprocess
        '
        Me.dtprocess.CalendarFont = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtprocess.CustomFormat = "dd-MMM-yyyy"
        Me.dtprocess.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtprocess.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtprocess.Location = New System.Drawing.Point(205, 23)
        Me.dtprocess.Name = "dtprocess"
        Me.dtprocess.Size = New System.Drawing.Size(125, 25)
        Me.dtprocess.TabIndex = 448
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
        Me.SplitContainer3.Panel1.Controls.Add(Me.SplitContainerFilterKunjungan)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.AutoScroll = True
        Me.SplitContainer3.Panel2.Controls.Add(Me.DataGridViewKunjunganPasien)
        Me.SplitContainer3.Size = New System.Drawing.Size(1000, 540)
        Me.SplitContainer3.SplitterDistance = 200
        Me.SplitContainer3.SplitterWidth = 5
        Me.SplitContainer3.TabIndex = 462
        '
        'DataGridViewKunjunganPasien
        '
        Me.DataGridViewKunjunganPasien.AllowUserToAddRows = False
        Me.DataGridViewKunjunganPasien.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewKunjunganPasien.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewKunjunganPasien.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridViewKunjunganPasien.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridViewKunjunganPasien.BackgroundColor = System.Drawing.Color.White
        Me.DataGridViewKunjunganPasien.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridViewKunjunganPasien.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DataGridViewKunjunganPasien.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(218, Byte), Integer))
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle6.Padding = New System.Windows.Forms.Padding(3)
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewKunjunganPasien.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewKunjunganPasien.ColumnHeadersHeight = 40
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.Padding = New System.Windows.Forms.Padding(3)
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(186, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(149, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewKunjunganPasien.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewKunjunganPasien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewKunjunganPasien.EnableHeadersVisualStyles = False
        Me.DataGridViewKunjunganPasien.Location = New System.Drawing.Point(0, 0)
        Me.DataGridViewKunjunganPasien.Name = "DataGridViewKunjunganPasien"
        Me.DataGridViewKunjunganPasien.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle8.Padding = New System.Windows.Forms.Padding(3)
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewKunjunganPasien.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridViewKunjunganPasien.RowHeadersVisible = False
        Me.DataGridViewKunjunganPasien.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.DataGridViewKunjunganPasien.RowTemplate.Height = 35
        Me.DataGridViewKunjunganPasien.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridViewKunjunganPasien.Size = New System.Drawing.Size(1000, 335)
        Me.DataGridViewKunjunganPasien.TabIndex = 517
        '
        'SplitContainerFilterKunjungan
        '
        Me.SplitContainerFilterKunjungan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerFilterKunjungan.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainerFilterKunjungan.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerFilterKunjungan.Name = "SplitContainerFilterKunjungan"
        Me.SplitContainerFilterKunjungan.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerFilterKunjungan.Panel1
        '
        Me.SplitContainerFilterKunjungan.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainerFilterKunjungan.Panel2
        '
        Me.SplitContainerFilterKunjungan.Panel2.Controls.Add(Me.FlowLayoutPanel2)
        Me.SplitContainerFilterKunjungan.Size = New System.Drawing.Size(1000, 200)
        Me.SplitContainerFilterKunjungan.SplitterDistance = 165
        Me.SplitContainerFilterKunjungan.TabIndex = 7
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.FlowLayoutPanel2.Controls.Add(Me.Label5)
        Me.FlowLayoutPanel2.Controls.Add(Me.TextBoxSearchKunjungan)
        Me.FlowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(1000, 31)
        Me.FlowLayoutPanel2.TabIndex = 463
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(3, 5)
        Me.Label5.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 17)
        Me.Label5.TabIndex = 518
        Me.Label5.Text = "Search :"
        '
        'TextBoxSearchKunjungan
        '
        Me.TextBoxSearchKunjungan.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBoxSearchKunjungan.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxSearchKunjungan.Location = New System.Drawing.Point(64, 3)
        Me.TextBoxSearchKunjungan.Name = "TextBoxSearchKunjungan"
        Me.TextBoxSearchKunjungan.Size = New System.Drawing.Size(351, 25)
        Me.TextBoxSearchKunjungan.TabIndex = 495
        Me.TextBoxSearchKunjungan.Tag = ""
        '
        'FindTransaksi
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
        Me.Name = "FindTransaksi"
        Me.PanelTop.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.ResumeLayout(False)
        CType(Me.DataGridViewKunjunganPasien, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerFilterKunjungan.Panel1.ResumeLayout(False)
        Me.SplitContainerFilterKunjungan.Panel2.ResumeLayout(False)
        Me.SplitContainerFilterKunjungan.ResumeLayout(False)
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtend As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtprocess As System.Windows.Forms.DateTimePicker
    Friend WithEvents ComboBoxPoliTujuan As System.Windows.Forms.ComboBox
    Friend WithEvents Label139 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxJenisKunjungan As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents RadioButtonNoAntrian As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonNoKartu As System.Windows.Forms.RadioButton
    Friend WithEvents TextBoxNoAntrian As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxAbjadBPJS As System.Windows.Forms.TextBox
    Friend WithEvents ButtonFindNoAntrian As System.Windows.Forms.Button
    Friend WithEvents ButtonFindTransaksi As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents DataGridViewKunjunganPasien As System.Windows.Forms.DataGridView
    Friend WithEvents SplitContainerFilterKunjungan As System.Windows.Forms.SplitContainer
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBoxSearchKunjungan As System.Windows.Forms.TextBox
End Class
