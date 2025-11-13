<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAnalisisKinerjaDokter
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
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.ComboBoxJaminan = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.dtAkhirObat = New System.Windows.Forms.DateTimePicker
        Me.dtAwalObat = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.ButtonDownloadTrend = New System.Windows.Forms.Button
        Me.ButtonViewObat = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.ComboBoxPoli = New System.Windows.Forms.ComboBox
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.Padding = New System.Drawing.Point(6, 6)
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(900, 491)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.SplitContainer1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 28)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(892, 459)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Pemakaian Obat"
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
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.White
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBoxJaminan)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label6)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label8)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dtAkhirObat)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dtAwalObat)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ButtonDownloadTrend)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ButtonViewObat)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBoxPoli)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.White
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridView1)
        Me.SplitContainer1.Size = New System.Drawing.Size(886, 453)
        Me.SplitContainer1.SplitterDistance = 321
        Me.SplitContainer1.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 28)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(892, 459)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'ComboBoxJaminan
        '
        Me.ComboBoxJaminan.AutoCompleteCustomSource.AddRange(New String() {"sou", "non", "une", "pre", "imv", "ano", "dia", "att", "abr", "car", "cfr", "nvt", "rrx", "mis", "amf", "gif", "cof", "fis", "inl", "onl", "prd/fld", "prd", "fld", "acr", "rct", "fmc", "fmc-rct", "poc", "poc-rct", "ipx-poc", "mpc", "gmc", "ipx", "meb", "pob", "pon", "abu", "abs", "cal", "pulp", "per", "giv", "avs", "muc", "uls", "pst", "sto", "tmj"})
        Me.ComboBoxJaminan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxJaminan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxJaminan.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBoxJaminan.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxJaminan.FormattingEnabled = True
        Me.ComboBoxJaminan.Items.AddRange(New Object() {"BPJS", "UMUM", "Asuransi Lain", "Semua Transaksi"})
        Me.ComboBoxJaminan.Location = New System.Drawing.Point(17, 130)
        Me.ComboBoxJaminan.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxJaminan.Name = "ComboBoxJaminan"
        Me.ComboBoxJaminan.Size = New System.Drawing.Size(204, 25)
        Me.ComboBoxJaminan.TabIndex = 538
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(13, 105)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 21)
        Me.Label6.TabIndex = 537
        Me.Label6.Text = "Jaminan"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(173, 173)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 21)
        Me.Label5.TabIndex = 536
        Me.Label5.Text = "Tgl Akhir"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(148, 213)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(23, 13)
        Me.Label8.TabIndex = 535
        Me.Label8.Text = "s/d"
        '
        'dtAkhirObat
        '
        Me.dtAkhirObat.CalendarFont = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtAkhirObat.CustomFormat = "dd-MMM-yyyy"
        Me.dtAkhirObat.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtAkhirObat.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtAkhirObat.Location = New System.Drawing.Point(177, 204)
        Me.dtAkhirObat.Name = "dtAkhirObat"
        Me.dtAkhirObat.Size = New System.Drawing.Size(125, 25)
        Me.dtAkhirObat.TabIndex = 534
        '
        'dtAwalObat
        '
        Me.dtAwalObat.CalendarFont = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtAwalObat.CustomFormat = "dd-MMM-yyyy"
        Me.dtAwalObat.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtAwalObat.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtAwalObat.Location = New System.Drawing.Point(17, 204)
        Me.dtAwalObat.Name = "dtAwalObat"
        Me.dtAwalObat.Size = New System.Drawing.Size(125, 25)
        Me.dtAwalObat.TabIndex = 533
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 173)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 21)
        Me.Label4.TabIndex = 532
        Me.Label4.Text = "Tgl Awal"
        '
        'ButtonDownloadTrend
        '
        Me.ButtonDownloadTrend.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ButtonDownloadTrend.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonDownloadTrend.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonDownloadTrend.ForeColor = System.Drawing.Color.White
        Me.ButtonDownloadTrend.Location = New System.Drawing.Point(151, 251)
        Me.ButtonDownloadTrend.Name = "ButtonDownloadTrend"
        Me.ButtonDownloadTrend.Size = New System.Drawing.Size(151, 34)
        Me.ButtonDownloadTrend.TabIndex = 531
        Me.ButtonDownloadTrend.Text = "Download Data"
        Me.ButtonDownloadTrend.UseVisualStyleBackColor = False
        '
        'ButtonViewObat
        '
        Me.ButtonViewObat.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonViewObat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonViewObat.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonViewObat.ForeColor = System.Drawing.Color.White
        Me.ButtonViewObat.Location = New System.Drawing.Point(17, 251)
        Me.ButtonViewObat.Name = "ButtonViewObat"
        Me.ButtonViewObat.Size = New System.Drawing.Size(125, 34)
        Me.ButtonViewObat.TabIndex = 530
        Me.ButtonViewObat.Text = "View Data"
        Me.ButtonViewObat.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 21)
        Me.Label2.TabIndex = 527
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
        Me.ComboBoxPoli.Location = New System.Drawing.Point(17, 63)
        Me.ComboBoxPoli.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxPoli.Name = "ComboBoxPoli"
        Me.ComboBoxPoli.Size = New System.Drawing.Size(204, 25)
        Me.ComboBoxPoli.TabIndex = 526
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.GridColor = System.Drawing.Color.Silver
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(561, 453)
        Me.DataGridView1.TabIndex = 0
        '
        'FormAnalisisKinerjaDokter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(900, 491)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "FormAnalisisKinerjaDokter"
        Me.Text = "Form Analisis Obat"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ComboBoxJaminan As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtAkhirObat As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtAwalObat As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ButtonDownloadTrend As System.Windows.Forms.Button
    Friend WithEvents ButtonViewObat As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxPoli As System.Windows.Forms.ComboBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
End Class
