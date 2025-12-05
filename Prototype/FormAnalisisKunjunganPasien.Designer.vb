<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAnalisisKunjunganPasien
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
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.ButtonKirimData = New System.Windows.Forms.Button
        Me.ButtonReport = New System.Windows.Forms.Button
        Me.ComboBoxHari = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ButtonKirim = New System.Windows.Forms.Button
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.ComboBoxJaminan = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.dtAkhir = New System.Windows.Forms.DateTimePicker
        Me.dtAwal = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.ButtonDownloadTrend = New System.Windows.Forms.Button
        Me.ButtonViewTrend = New System.Windows.Forms.Button
        Me.ComboBoxPeriode = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ComboBoxPoli = New System.Windows.Forms.ComboBox
        Me.DataGridView2 = New System.Windows.Forms.DataGridView
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer
        Me.ButtonDownloadKunjungan = New System.Windows.Forms.Button
        Me.ButtonKunjungan = New System.Windows.Forms.Button
        Me.ComboBoxTahun = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.DataGridView3 = New System.Windows.Forms.DataGridView
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.SplitContainer4 = New System.Windows.Forms.SplitContainer
        Me.ComboBoxJaminanWaktu = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.dtWaktuAkhir = New System.Windows.Forms.DateTimePicker
        Me.dtWaktuAwal = New System.Windows.Forms.DateTimePicker
        Me.Label11 = New System.Windows.Forms.Label
        Me.ButtonDonwloadJam = New System.Windows.Forms.Button
        Me.ButtonViewJam = New System.Windows.Forms.Button
        Me.ComboBoxPeriodeWaktu = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.ComboBoxPoliWaktu = New System.Windows.Forms.ComboBox
        Me.DataGridView4 = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.RadioButtonSes = New System.Windows.Forms.RadioButton
        Me.RadioButtonHoltW = New System.Windows.Forms.RadioButton
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        Me.SplitContainer4.Panel1.SuspendLayout()
        Me.SplitContainer4.Panel2.SuspendLayout()
        Me.SplitContainer4.SuspendLayout()
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.Padding = New System.Drawing.Point(6, 6)
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(927, 506)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.White
        Me.TabPage1.Controls.Add(Me.SplitContainer1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 28)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(919, 474)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Forecasting"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ButtonKirimData)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ButtonReport)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBoxHari)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ButtonKirim)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridView1)
        Me.SplitContainer1.Size = New System.Drawing.Size(913, 468)
        Me.SplitContainer1.SplitterDistance = 282
        Me.SplitContainer1.TabIndex = 0
        '
        'ButtonKirimData
        '
        Me.ButtonKirimData.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonKirimData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonKirimData.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonKirimData.ForeColor = System.Drawing.Color.White
        Me.ButtonKirimData.Location = New System.Drawing.Point(125, 192)
        Me.ButtonKirimData.Name = "ButtonKirimData"
        Me.ButtonKirimData.Size = New System.Drawing.Size(132, 34)
        Me.ButtonKirimData.TabIndex = 513
        Me.ButtonKirimData.Text = "Kiri Data Aktual"
        Me.ButtonKirimData.UseVisualStyleBackColor = False
        '
        'ButtonReport
        '
        Me.ButtonReport.BackColor = System.Drawing.Color.FromArgb(CType(CType(83, Byte), Integer), CType(CType(145, Byte), Integer), CType(CType(101, Byte), Integer))
        Me.ButtonReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonReport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonReport.FlatAppearance.BorderSize = 0
        Me.ButtonReport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonReport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonReport.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonReport.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ButtonReport.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_save_16
        Me.ButtonReport.Location = New System.Drawing.Point(15, 242)
        Me.ButtonReport.Name = "ButtonReport"
        Me.ButtonReport.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonReport.Size = New System.Drawing.Size(242, 34)
        Me.ButtonReport.TabIndex = 512
        Me.ButtonReport.Text = " Report"
        Me.ButtonReport.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonReport.UseVisualStyleBackColor = False
        '
        'ComboBoxHari
        '
        Me.ComboBoxHari.AutoCompleteCustomSource.AddRange(New String() {"sou", "non", "une", "pre", "imv", "ano", "dia", "att", "abr", "car", "cfr", "nvt", "rrx", "mis", "amf", "gif", "cof", "fis", "inl", "onl", "prd/fld", "prd", "fld", "acr", "rct", "fmc", "fmc-rct", "poc", "poc-rct", "ipx-poc", "mpc", "gmc", "ipx", "meb", "pob", "pon", "abu", "abs", "cal", "pulp", "per", "giv", "avs", "muc", "uls", "pst", "sto", "tmj"})
        Me.ComboBoxHari.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxHari.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxHari.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBoxHari.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxHari.FormattingEnabled = True
        Me.ComboBoxHari.Items.AddRange(New Object() {"Harian", "Mingguan", "Bulanan"})
        Me.ComboBoxHari.Location = New System.Drawing.Point(18, 77)
        Me.ComboBoxHari.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxHari.Name = "ComboBoxHari"
        Me.ComboBoxHari.Size = New System.Drawing.Size(239, 25)
        Me.ComboBoxHari.TabIndex = 511
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 21)
        Me.Label1.TabIndex = 510
        Me.Label1.Text = "Periode"
        '
        'ButtonKirim
        '
        Me.ButtonKirim.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonKirim.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonKirim.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonKirim.ForeColor = System.Drawing.Color.White
        Me.ButtonKirim.Location = New System.Drawing.Point(15, 192)
        Me.ButtonKirim.Name = "ButtonKirim"
        Me.ButtonKirim.Size = New System.Drawing.Size(104, 34)
        Me.ButtonKirim.TabIndex = 509
        Me.ButtonKirim.Text = "View Data"
        Me.ButtonKirim.UseVisualStyleBackColor = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(627, 468)
        Me.DataGridView1.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.White
        Me.TabPage2.Controls.Add(Me.SplitContainer2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 28)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(919, 474)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Tren Kunjungan Pasien"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.ComboBoxJaminan)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label8)
        Me.SplitContainer2.Panel1.Controls.Add(Me.dtAkhir)
        Me.SplitContainer2.Panel1.Controls.Add(Me.dtAwal)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer2.Panel1.Controls.Add(Me.ButtonDownloadTrend)
        Me.SplitContainer2.Panel1.Controls.Add(Me.ButtonViewTrend)
        Me.SplitContainer2.Panel1.Controls.Add(Me.ComboBoxPeriode)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label3)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer2.Panel1.Controls.Add(Me.ComboBoxPoli)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.DataGridView2)
        Me.SplitContainer2.Size = New System.Drawing.Size(913, 468)
        Me.SplitContainer2.SplitterDistance = 331
        Me.SplitContainer2.TabIndex = 0
        '
        'ComboBoxJaminan
        '
        Me.ComboBoxJaminan.AutoCompleteCustomSource.AddRange(New String() {"sou", "non", "une", "pre", "imv", "ano", "dia", "att", "abr", "car", "cfr", "nvt", "rrx", "mis", "amf", "gif", "cof", "fis", "inl", "onl", "prd/fld", "prd", "fld", "acr", "rct", "fmc", "fmc-rct", "poc", "poc-rct", "ipx-poc", "mpc", "gmc", "ipx", "meb", "pob", "pon", "abu", "abs", "cal", "pulp", "per", "giv", "avs", "muc", "uls", "pst", "sto", "tmj"})
        Me.ComboBoxJaminan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxJaminan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxJaminan.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBoxJaminan.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxJaminan.FormattingEnabled = True
        Me.ComboBoxJaminan.Items.AddRange(New Object() {"BPJS", "UMUM", "Asuransai Lain", "GABUNGAN"})
        Me.ComboBoxJaminan.Location = New System.Drawing.Point(17, 192)
        Me.ComboBoxJaminan.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxJaminan.Name = "ComboBoxJaminan"
        Me.ComboBoxJaminan.Size = New System.Drawing.Size(204, 25)
        Me.ComboBoxJaminan.TabIndex = 525
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(13, 167)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 21)
        Me.Label6.TabIndex = 524
        Me.Label6.Text = "Jaminan"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(173, 235)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 21)
        Me.Label5.TabIndex = 523
        Me.Label5.Text = "Tgl Akhir"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(148, 275)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(23, 13)
        Me.Label8.TabIndex = 522
        Me.Label8.Text = "s/d"
        '
        'dtAkhir
        '
        Me.dtAkhir.CalendarFont = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtAkhir.CustomFormat = "dd-MMM-yyyy"
        Me.dtAkhir.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtAkhir.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtAkhir.Location = New System.Drawing.Point(177, 266)
        Me.dtAkhir.Name = "dtAkhir"
        Me.dtAkhir.Size = New System.Drawing.Size(125, 25)
        Me.dtAkhir.TabIndex = 521
        '
        'dtAwal
        '
        Me.dtAwal.CalendarFont = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtAwal.CustomFormat = "dd-MMM-yyyy"
        Me.dtAwal.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtAwal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtAwal.Location = New System.Drawing.Point(17, 266)
        Me.dtAwal.Name = "dtAwal"
        Me.dtAwal.Size = New System.Drawing.Size(125, 25)
        Me.dtAwal.TabIndex = 520
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 235)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 21)
        Me.Label4.TabIndex = 519
        Me.Label4.Text = "Tgl Awal"
        '
        'ButtonDownloadTrend
        '
        Me.ButtonDownloadTrend.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ButtonDownloadTrend.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonDownloadTrend.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonDownloadTrend.ForeColor = System.Drawing.Color.White
        Me.ButtonDownloadTrend.Location = New System.Drawing.Point(151, 313)
        Me.ButtonDownloadTrend.Name = "ButtonDownloadTrend"
        Me.ButtonDownloadTrend.Size = New System.Drawing.Size(151, 34)
        Me.ButtonDownloadTrend.TabIndex = 517
        Me.ButtonDownloadTrend.Text = "Download Data"
        Me.ButtonDownloadTrend.UseVisualStyleBackColor = False
        '
        'ButtonViewTrend
        '
        Me.ButtonViewTrend.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonViewTrend.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonViewTrend.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonViewTrend.ForeColor = System.Drawing.Color.White
        Me.ButtonViewTrend.Location = New System.Drawing.Point(17, 313)
        Me.ButtonViewTrend.Name = "ButtonViewTrend"
        Me.ButtonViewTrend.Size = New System.Drawing.Size(125, 34)
        Me.ButtonViewTrend.TabIndex = 516
        Me.ButtonViewTrend.Text = "View Data"
        Me.ButtonViewTrend.UseVisualStyleBackColor = False
        '
        'ComboBoxPeriode
        '
        Me.ComboBoxPeriode.AutoCompleteCustomSource.AddRange(New String() {"sou", "non", "une", "pre", "imv", "ano", "dia", "att", "abr", "car", "cfr", "nvt", "rrx", "mis", "amf", "gif", "cof", "fis", "inl", "onl", "prd/fld", "prd", "fld", "acr", "rct", "fmc", "fmc-rct", "poc", "poc-rct", "ipx-poc", "mpc", "gmc", "ipx", "meb", "pob", "pon", "abu", "abs", "cal", "pulp", "per", "giv", "avs", "muc", "uls", "pst", "sto", "tmj"})
        Me.ComboBoxPeriode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxPeriode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxPeriode.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBoxPeriode.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxPeriode.FormattingEnabled = True
        Me.ComboBoxPeriode.Items.AddRange(New Object() {"Harian", "Mingguan", "Bulanan"})
        Me.ComboBoxPeriode.Location = New System.Drawing.Point(17, 128)
        Me.ComboBoxPeriode.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxPeriode.Name = "ComboBoxPeriode"
        Me.ComboBoxPeriode.Size = New System.Drawing.Size(204, 25)
        Me.ComboBoxPeriode.TabIndex = 515
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 21)
        Me.Label3.TabIndex = 514
        Me.Label3.Text = "Periode"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 21)
        Me.Label2.TabIndex = 513
        Me.Label2.Text = "Poli"
        '
        'ComboBoxPoli
        '
        Me.ComboBoxPoli.AutoCompleteCustomSource.AddRange(New String() {"sou", "non", "une", "pre", "imv", "ano", "dia", "att", "abr", "car", "cfr", "nvt", "rrx", "mis", "amf", "gif", "cof", "fis", "inl", "onl", "prd/fld", "prd", "fld", "acr", "rct", "fmc", "fmc-rct", "poc", "poc-rct", "ipx-poc", "mpc", "gmc", "ipx", "meb", "pob", "pon", "abu", "abs", "cal", "pulp", "per", "giv", "avs", "muc", "uls", "pst", "sto", "tmj"})
        Me.ComboBoxPoli.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxPoli.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxPoli.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBoxPoli.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxPoli.FormattingEnabled = True
        Me.ComboBoxPoli.Items.AddRange(New Object() {"POLI UMUM", "POLI GIGI & MULUT", "POLI KIA", "POLI KB", "SEMUA POLI"})
        Me.ComboBoxPoli.Location = New System.Drawing.Point(17, 64)
        Me.ComboBoxPoli.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxPoli.Name = "ComboBoxPoli"
        Me.ComboBoxPoli.Size = New System.Drawing.Size(204, 25)
        Me.ComboBoxPoli.TabIndex = 512
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView2.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.Size = New System.Drawing.Size(578, 468)
        Me.DataGridView2.TabIndex = 0
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.SplitContainer3)
        Me.TabPage3.Location = New System.Drawing.Point(4, 28)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(919, 474)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Kunjungan Pasien Baru & Lama"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'SplitContainer3
        '
        Me.SplitContainer3.BackColor = System.Drawing.Color.White
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.ButtonDownloadKunjungan)
        Me.SplitContainer3.Panel1.Controls.Add(Me.ButtonKunjungan)
        Me.SplitContainer3.Panel1.Controls.Add(Me.ComboBoxTahun)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Label12)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.DataGridView3)
        Me.SplitContainer3.Size = New System.Drawing.Size(919, 474)
        Me.SplitContainer3.SplitterDistance = 343
        Me.SplitContainer3.TabIndex = 0
        '
        'ButtonDownloadKunjungan
        '
        Me.ButtonDownloadKunjungan.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ButtonDownloadKunjungan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonDownloadKunjungan.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonDownloadKunjungan.ForeColor = System.Drawing.Color.White
        Me.ButtonDownloadKunjungan.Location = New System.Drawing.Point(149, 200)
        Me.ButtonDownloadKunjungan.Name = "ButtonDownloadKunjungan"
        Me.ButtonDownloadKunjungan.Size = New System.Drawing.Size(151, 34)
        Me.ButtonDownloadKunjungan.TabIndex = 531
        Me.ButtonDownloadKunjungan.Text = "Download Data"
        Me.ButtonDownloadKunjungan.UseVisualStyleBackColor = False
        '
        'ButtonKunjungan
        '
        Me.ButtonKunjungan.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonKunjungan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonKunjungan.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonKunjungan.ForeColor = System.Drawing.Color.White
        Me.ButtonKunjungan.Location = New System.Drawing.Point(18, 200)
        Me.ButtonKunjungan.Name = "ButtonKunjungan"
        Me.ButtonKunjungan.Size = New System.Drawing.Size(125, 34)
        Me.ButtonKunjungan.TabIndex = 530
        Me.ButtonKunjungan.Text = "View Data"
        Me.ButtonKunjungan.UseVisualStyleBackColor = False
        '
        'ComboBoxTahun
        '
        Me.ComboBoxTahun.AutoCompleteCustomSource.AddRange(New String() {"sou", "non", "une", "pre", "imv", "ano", "dia", "att", "abr", "car", "cfr", "nvt", "rrx", "mis", "amf", "gif", "cof", "fis", "inl", "onl", "prd/fld", "prd", "fld", "acr", "rct", "fmc", "fmc-rct", "poc", "poc-rct", "ipx-poc", "mpc", "gmc", "ipx", "meb", "pob", "pon", "abu", "abs", "cal", "pulp", "per", "giv", "avs", "muc", "uls", "pst", "sto", "tmj"})
        Me.ComboBoxTahun.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxTahun.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxTahun.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBoxTahun.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxTahun.FormattingEnabled = True
        Me.ComboBoxTahun.Items.AddRange(New Object() {"2023", "2024", "2025", "2026"})
        Me.ComboBoxTahun.Location = New System.Drawing.Point(19, 130)
        Me.ComboBoxTahun.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxTahun.Name = "ComboBoxTahun"
        Me.ComboBoxTahun.Size = New System.Drawing.Size(204, 25)
        Me.ComboBoxTahun.TabIndex = 529
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(15, 105)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(62, 21)
        Me.Label12.TabIndex = 528
        Me.Label12.Text = "Periode"
        '
        'DataGridView3
        '
        Me.DataGridView3.AllowUserToAddRows = False
        Me.DataGridView3.AllowUserToDeleteRows = False
        Me.DataGridView3.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView3.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView3.Name = "DataGridView3"
        Me.DataGridView3.ReadOnly = True
        Me.DataGridView3.Size = New System.Drawing.Size(572, 474)
        Me.DataGridView3.TabIndex = 0
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.SplitContainer4)
        Me.TabPage4.Location = New System.Drawing.Point(4, 28)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(919, 474)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Jam Sibuk"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'SplitContainer4
        '
        Me.SplitContainer4.BackColor = System.Drawing.Color.White
        Me.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer4.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer4.Name = "SplitContainer4"
        '
        'SplitContainer4.Panel1
        '
        Me.SplitContainer4.Panel1.Controls.Add(Me.ComboBoxJaminanWaktu)
        Me.SplitContainer4.Panel1.Controls.Add(Me.Label7)
        Me.SplitContainer4.Panel1.Controls.Add(Me.Label9)
        Me.SplitContainer4.Panel1.Controls.Add(Me.Label10)
        Me.SplitContainer4.Panel1.Controls.Add(Me.dtWaktuAkhir)
        Me.SplitContainer4.Panel1.Controls.Add(Me.dtWaktuAwal)
        Me.SplitContainer4.Panel1.Controls.Add(Me.Label11)
        Me.SplitContainer4.Panel1.Controls.Add(Me.ButtonDonwloadJam)
        Me.SplitContainer4.Panel1.Controls.Add(Me.ButtonViewJam)
        Me.SplitContainer4.Panel1.Controls.Add(Me.ComboBoxPeriodeWaktu)
        Me.SplitContainer4.Panel1.Controls.Add(Me.Label13)
        Me.SplitContainer4.Panel1.Controls.Add(Me.Label14)
        Me.SplitContainer4.Panel1.Controls.Add(Me.ComboBoxPoliWaktu)
        '
        'SplitContainer4.Panel2
        '
        Me.SplitContainer4.Panel2.Controls.Add(Me.DataGridView4)
        Me.SplitContainer4.Size = New System.Drawing.Size(919, 474)
        Me.SplitContainer4.SplitterDistance = 346
        Me.SplitContainer4.TabIndex = 0
        '
        'ComboBoxJaminanWaktu
        '
        Me.ComboBoxJaminanWaktu.AutoCompleteCustomSource.AddRange(New String() {"sou", "non", "une", "pre", "imv", "ano", "dia", "att", "abr", "car", "cfr", "nvt", "rrx", "mis", "amf", "gif", "cof", "fis", "inl", "onl", "prd/fld", "prd", "fld", "acr", "rct", "fmc", "fmc-rct", "poc", "poc-rct", "ipx-poc", "mpc", "gmc", "ipx", "meb", "pob", "pon", "abu", "abs", "cal", "pulp", "per", "giv", "avs", "muc", "uls", "pst", "sto", "tmj"})
        Me.ComboBoxJaminanWaktu.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxJaminanWaktu.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxJaminanWaktu.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBoxJaminanWaktu.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxJaminanWaktu.FormattingEnabled = True
        Me.ComboBoxJaminanWaktu.Items.AddRange(New Object() {"BPJS", "UMUM", "Asuransi Lain", "GABUNGAN"})
        Me.ComboBoxJaminanWaktu.Location = New System.Drawing.Point(23, 194)
        Me.ComboBoxJaminanWaktu.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxJaminanWaktu.Name = "ComboBoxJaminanWaktu"
        Me.ComboBoxJaminanWaktu.Size = New System.Drawing.Size(204, 25)
        Me.ComboBoxJaminanWaktu.TabIndex = 538
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(19, 169)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 21)
        Me.Label7.TabIndex = 537
        Me.Label7.Text = "Jaminan"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(179, 237)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 21)
        Me.Label9.TabIndex = 536
        Me.Label9.Text = "Tgl Akhir"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(154, 277)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(23, 13)
        Me.Label10.TabIndex = 535
        Me.Label10.Text = "s/d"
        '
        'dtWaktuAkhir
        '
        Me.dtWaktuAkhir.CalendarFont = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtWaktuAkhir.CustomFormat = "dd-MMM-yyyy"
        Me.dtWaktuAkhir.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtWaktuAkhir.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtWaktuAkhir.Location = New System.Drawing.Point(183, 268)
        Me.dtWaktuAkhir.Name = "dtWaktuAkhir"
        Me.dtWaktuAkhir.Size = New System.Drawing.Size(125, 25)
        Me.dtWaktuAkhir.TabIndex = 534
        '
        'dtWaktuAwal
        '
        Me.dtWaktuAwal.CalendarFont = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtWaktuAwal.CustomFormat = "dd-MMM-yyyy"
        Me.dtWaktuAwal.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtWaktuAwal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtWaktuAwal.Location = New System.Drawing.Point(23, 268)
        Me.dtWaktuAwal.Name = "dtWaktuAwal"
        Me.dtWaktuAwal.Size = New System.Drawing.Size(125, 25)
        Me.dtWaktuAwal.TabIndex = 533
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(19, 237)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 21)
        Me.Label11.TabIndex = 532
        Me.Label11.Text = "Tgl Awal"
        '
        'ButtonDonwloadJam
        '
        Me.ButtonDonwloadJam.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ButtonDonwloadJam.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonDonwloadJam.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonDonwloadJam.ForeColor = System.Drawing.Color.White
        Me.ButtonDonwloadJam.Location = New System.Drawing.Point(157, 315)
        Me.ButtonDonwloadJam.Name = "ButtonDonwloadJam"
        Me.ButtonDonwloadJam.Size = New System.Drawing.Size(151, 34)
        Me.ButtonDonwloadJam.TabIndex = 531
        Me.ButtonDonwloadJam.Text = "Download Data"
        Me.ButtonDonwloadJam.UseVisualStyleBackColor = False
        '
        'ButtonViewJam
        '
        Me.ButtonViewJam.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonViewJam.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonViewJam.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonViewJam.ForeColor = System.Drawing.Color.White
        Me.ButtonViewJam.Location = New System.Drawing.Point(23, 315)
        Me.ButtonViewJam.Name = "ButtonViewJam"
        Me.ButtonViewJam.Size = New System.Drawing.Size(125, 34)
        Me.ButtonViewJam.TabIndex = 530
        Me.ButtonViewJam.Text = "View Data"
        Me.ButtonViewJam.UseVisualStyleBackColor = False
        '
        'ComboBoxPeriodeWaktu
        '
        Me.ComboBoxPeriodeWaktu.AutoCompleteCustomSource.AddRange(New String() {"sou", "non", "une", "pre", "imv", "ano", "dia", "att", "abr", "car", "cfr", "nvt", "rrx", "mis", "amf", "gif", "cof", "fis", "inl", "onl", "prd/fld", "prd", "fld", "acr", "rct", "fmc", "fmc-rct", "poc", "poc-rct", "ipx-poc", "mpc", "gmc", "ipx", "meb", "pob", "pon", "abu", "abs", "cal", "pulp", "per", "giv", "avs", "muc", "uls", "pst", "sto", "tmj"})
        Me.ComboBoxPeriodeWaktu.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxPeriodeWaktu.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxPeriodeWaktu.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBoxPeriodeWaktu.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxPeriodeWaktu.FormattingEnabled = True
        Me.ComboBoxPeriodeWaktu.Items.AddRange(New Object() {"Jam", "Hari"})
        Me.ComboBoxPeriodeWaktu.Location = New System.Drawing.Point(23, 130)
        Me.ComboBoxPeriodeWaktu.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxPeriodeWaktu.Name = "ComboBoxPeriodeWaktu"
        Me.ComboBoxPeriodeWaktu.Size = New System.Drawing.Size(204, 25)
        Me.ComboBoxPeriodeWaktu.TabIndex = 529
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(19, 105)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(62, 21)
        Me.Label13.TabIndex = 528
        Me.Label13.Text = "Periode"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(19, 41)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(35, 21)
        Me.Label14.TabIndex = 527
        Me.Label14.Text = "Poli"
        '
        'ComboBoxPoliWaktu
        '
        Me.ComboBoxPoliWaktu.AutoCompleteCustomSource.AddRange(New String() {"sou", "non", "une", "pre", "imv", "ano", "dia", "att", "abr", "car", "cfr", "nvt", "rrx", "mis", "amf", "gif", "cof", "fis", "inl", "onl", "prd/fld", "prd", "fld", "acr", "rct", "fmc", "fmc-rct", "poc", "poc-rct", "ipx-poc", "mpc", "gmc", "ipx", "meb", "pob", "pon", "abu", "abs", "cal", "pulp", "per", "giv", "avs", "muc", "uls", "pst", "sto", "tmj"})
        Me.ComboBoxPoliWaktu.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxPoliWaktu.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxPoliWaktu.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBoxPoliWaktu.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxPoliWaktu.FormattingEnabled = True
        Me.ComboBoxPoliWaktu.Items.AddRange(New Object() {"POLI UMUM", "POLI GIGI & MULUT", "POLI KIA", "POLI KB", "SEMUA POLI"})
        Me.ComboBoxPoliWaktu.Location = New System.Drawing.Point(23, 66)
        Me.ComboBoxPoliWaktu.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxPoliWaktu.Name = "ComboBoxPoliWaktu"
        Me.ComboBoxPoliWaktu.Size = New System.Drawing.Size(204, 25)
        Me.ComboBoxPoliWaktu.TabIndex = 526
        '
        'DataGridView4
        '
        Me.DataGridView4.AllowUserToAddRows = False
        Me.DataGridView4.AllowUserToDeleteRows = False
        Me.DataGridView4.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.DataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView4.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView4.Name = "DataGridView4"
        Me.DataGridView4.ReadOnly = True
        Me.DataGridView4.Size = New System.Drawing.Size(569, 474)
        Me.DataGridView4.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButtonHoltW)
        Me.GroupBox1.Controls.Add(Me.RadioButtonSes)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 109)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(239, 77)
        Me.GroupBox1.TabIndex = 514
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Metode"
        '
        'RadioButtonSes
        '
        Me.RadioButtonSes.AutoSize = True
        Me.RadioButtonSes.Checked = True
        Me.RadioButtonSes.Location = New System.Drawing.Point(11, 32)
        Me.RadioButtonSes.Name = "RadioButtonSes"
        Me.RadioButtonSes.Size = New System.Drawing.Size(86, 17)
        Me.RadioButtonSes.TabIndex = 0
        Me.RadioButtonSes.TabStop = True
        Me.RadioButtonSes.Text = "SES + MAPE"
        Me.RadioButtonSes.UseVisualStyleBackColor = True
        '
        'RadioButtonHoltW
        '
        Me.RadioButtonHoltW.AutoSize = True
        Me.RadioButtonHoltW.Location = New System.Drawing.Point(103, 32)
        Me.RadioButtonHoltW.Name = "RadioButtonHoltW"
        Me.RadioButtonHoltW.Size = New System.Drawing.Size(133, 17)
        Me.RadioButtonHoltW.TabIndex = 1
        Me.RadioButtonHoltW.Text = "Holt Winters + MAPE"
        Me.RadioButtonHoltW.UseVisualStyleBackColor = True
        '
        'FormAnalisisKunjunganPasien
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(927, 506)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "FormAnalisisKunjunganPasien"
        Me.Text = "FormAnalisisKunjunganPasien"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel1.PerformLayout()
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.ResumeLayout(False)
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.SplitContainer4.Panel1.ResumeLayout(False)
        Me.SplitContainer4.Panel1.PerformLayout()
        Me.SplitContainer4.Panel2.ResumeLayout(False)
        Me.SplitContainer4.ResumeLayout(False)
        CType(Me.DataGridView4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ButtonKirimData As System.Windows.Forms.Button
    Friend WithEvents ButtonReport As System.Windows.Forms.Button
    Friend WithEvents ComboBoxHari As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonKirim As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents ComboBoxPeriode As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxPoli As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonDownloadTrend As System.Windows.Forms.Button
    Friend WithEvents ButtonViewTrend As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtAkhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtAwal As System.Windows.Forms.DateTimePicker
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents ComboBoxJaminan As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents DataGridView3 As System.Windows.Forms.DataGridView
    Friend WithEvents ButtonDownloadKunjungan As System.Windows.Forms.Button
    Friend WithEvents ButtonKunjungan As System.Windows.Forms.Button
    Friend WithEvents ComboBoxTahun As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer4 As System.Windows.Forms.SplitContainer
    Friend WithEvents ComboBoxJaminanWaktu As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dtWaktuAkhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtWaktuAwal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ButtonDonwloadJam As System.Windows.Forms.Button
    Friend WithEvents ButtonViewJam As System.Windows.Forms.Button
    Friend WithEvents ComboBoxPeriodeWaktu As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxPoliWaktu As System.Windows.Forms.ComboBox
    Friend WithEvents DataGridView4 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButtonHoltW As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonSes As System.Windows.Forms.RadioButton
End Class
