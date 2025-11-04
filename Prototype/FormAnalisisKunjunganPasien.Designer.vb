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
        Me.ButtonDownloadTrend = New System.Windows.Forms.Button
        Me.ButtonViewTrend = New System.Windows.Forms.Button
        Me.ComboBoxPeriode = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ComboBoxPoli = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.dtAkhir = New System.Windows.Forms.DateTimePicker
        Me.dtAwal = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.DataGridView2 = New System.Windows.Forms.DataGridView
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
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
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
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
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
        Me.ButtonKirimData.Location = New System.Drawing.Point(124, 121)
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
        Me.ButtonReport.Location = New System.Drawing.Point(14, 171)
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
        Me.ComboBoxHari.Size = New System.Drawing.Size(204, 25)
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
        Me.ButtonKirim.Location = New System.Drawing.Point(14, 121)
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
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
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
        'ButtonDownloadTrend
        '
        Me.ButtonDownloadTrend.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ButtonDownloadTrend.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonDownloadTrend.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonDownloadTrend.ForeColor = System.Drawing.Color.White
        Me.ButtonDownloadTrend.Location = New System.Drawing.Point(151, 250)
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
        Me.ButtonViewTrend.Location = New System.Drawing.Point(17, 250)
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
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 170)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 21)
        Me.Label4.TabIndex = 519
        Me.Label4.Text = "Tgl Awal"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(148, 210)
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
        Me.dtAkhir.Location = New System.Drawing.Point(177, 201)
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
        Me.dtAwal.Location = New System.Drawing.Point(17, 201)
        Me.dtAwal.Name = "dtAwal"
        Me.dtAwal.Size = New System.Drawing.Size(125, 25)
        Me.dtAwal.TabIndex = 520
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(173, 170)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 21)
        Me.Label5.TabIndex = 523
        Me.Label5.Text = "Tgl Akhir"
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
End Class
