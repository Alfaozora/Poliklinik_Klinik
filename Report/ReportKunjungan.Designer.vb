<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportKunjungan
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rdpasienbpjs = New System.Windows.Forms.RadioButton
        Me.rdtagihan = New System.Windows.Forms.RadioButton
        Me.rdpasienumum = New System.Windows.Forms.RadioButton
        Me.rdpasienall = New System.Windows.Forms.RadioButton
        Me.butdisplay = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtakhir = New System.Windows.Forms.DateTimePicker
        Me.dtawal = New System.Windows.Forms.DateTimePicker
        Me.rdtanggal = New System.Windows.Forms.RadioButton
        Me.cmbdasar = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.rddetail = New System.Windows.Forms.RadioButton
        Me.rdsummary = New System.Windows.Forms.RadioButton
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Controls.Add(Me.rdpasienbpjs)
        Me.GroupBox2.Controls.Add(Me.rdtagihan)
        Me.GroupBox2.Controls.Add(Me.butdisplay)
        Me.GroupBox2.Controls.Add(Me.rdpasienumum)
        Me.GroupBox2.Controls.Add(Me.rdpasienall)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(337, 377)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Jenis Pasien"
        '
        'rdpasienbpjs
        '
        Me.rdpasienbpjs.AutoSize = True
        Me.rdpasienbpjs.Location = New System.Drawing.Point(6, 88)
        Me.rdpasienbpjs.Name = "rdpasienbpjs"
        Me.rdpasienbpjs.Size = New System.Drawing.Size(86, 17)
        Me.rdpasienbpjs.TabIndex = 3
        Me.rdpasienbpjs.TabStop = True
        Me.rdpasienbpjs.Text = "Pasien BPJS"
        Me.rdpasienbpjs.UseVisualStyleBackColor = True
        '
        'rdtagihan
        '
        Me.rdtagihan.AutoSize = True
        Me.rdtagihan.Location = New System.Drawing.Point(6, 65)
        Me.rdtagihan.Name = "rdtagihan"
        Me.rdtagihan.Size = New System.Drawing.Size(64, 17)
        Me.rdtagihan.TabIndex = 2
        Me.rdtagihan.TabStop = True
        Me.rdtagihan.Text = "Tagihan"
        Me.rdtagihan.UseVisualStyleBackColor = True
        '
        'rdpasienumum
        '
        Me.rdpasienumum.AutoSize = True
        Me.rdpasienumum.Location = New System.Drawing.Point(6, 42)
        Me.rdpasienumum.Name = "rdpasienumum"
        Me.rdpasienumum.Size = New System.Drawing.Size(90, 17)
        Me.rdpasienumum.TabIndex = 1
        Me.rdpasienumum.TabStop = True
        Me.rdpasienumum.Text = "Pasien Umum"
        Me.rdpasienumum.UseVisualStyleBackColor = True
        '
        'rdpasienall
        '
        Me.rdpasienall.AutoSize = True
        Me.rdpasienall.Location = New System.Drawing.Point(6, 19)
        Me.rdpasienall.Name = "rdpasienall"
        Me.rdpasienall.Size = New System.Drawing.Size(120, 17)
        Me.rdpasienall.TabIndex = 0
        Me.rdpasienall.TabStop = True
        Me.rdpasienall.Text = "Semua Jenis Pasien"
        Me.rdpasienall.UseVisualStyleBackColor = True
        '
        'butdisplay
        '
        Me.butdisplay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butdisplay.Location = New System.Drawing.Point(250, 237)
        Me.butdisplay.Name = "butdisplay"
        Me.butdisplay.Size = New System.Drawing.Size(75, 23)
        Me.butdisplay.TabIndex = 6
        Me.butdisplay.Text = "Display"
        Me.butdisplay.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.dtakhir)
        Me.GroupBox3.Controls.Add(Me.dtawal)
        Me.GroupBox3.Controls.Add(Me.rdtanggal)
        Me.GroupBox3.Location = New System.Drawing.Point(0, 111)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(337, 51)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Periode Tanggal"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(189, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 13)
        Me.Label1.TabIndex = 65
        Me.Label1.Text = "s/d"
        '
        'dtakhir
        '
        Me.dtakhir.CustomFormat = "dd-MMM-yyyy"
        Me.dtakhir.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtakhir.Location = New System.Drawing.Point(218, 18)
        Me.dtakhir.Name = "dtakhir"
        Me.dtakhir.Size = New System.Drawing.Size(107, 20)
        Me.dtakhir.TabIndex = 64
        '
        'dtawal
        '
        Me.dtawal.CustomFormat = "dd-MMM-yyyy"
        Me.dtawal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtawal.Location = New System.Drawing.Point(76, 18)
        Me.dtawal.Name = "dtawal"
        Me.dtawal.Size = New System.Drawing.Size(107, 20)
        Me.dtawal.TabIndex = 63
        '
        'rdtanggal
        '
        Me.rdtanggal.AutoSize = True
        Me.rdtanggal.Location = New System.Drawing.Point(6, 19)
        Me.rdtanggal.Name = "rdtanggal"
        Me.rdtanggal.Size = New System.Drawing.Size(64, 17)
        Me.rdtanggal.TabIndex = 0
        Me.rdtanggal.TabStop = True
        Me.rdtanggal.Text = "Tanggal"
        Me.rdtanggal.UseVisualStyleBackColor = True
        '
        'cmbdasar
        '
        Me.cmbdasar.FormattingEnabled = True
        Me.cmbdasar.Items.AddRange(New Object() {"", "Pemeriksaan Kunjungan Awal", "Jenis Penyakit", "Jumlah Pemeriksaan Dokter Poli", "Jumlah Pemeriksaan Perawat"})
        Me.cmbdasar.Location = New System.Drawing.Point(76, 171)
        Me.cmbdasar.Name = "cmbdasar"
        Me.cmbdasar.Size = New System.Drawing.Size(249, 21)
        Me.cmbdasar.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 174)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Berdasar"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DataGridView1)
        Me.GroupBox1.Controls.Add(Me.GridControl1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(337, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(644, 377)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detail"
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        '
        '
        '
        Me.GridControl1.EmbeddedNavigator.Name = ""
        Me.GridControl1.Location = New System.Drawing.Point(3, 16)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(638, 358)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'rddetail
        '
        Me.rddetail.AutoSize = True
        Me.rddetail.Location = New System.Drawing.Point(192, 13)
        Me.rddetail.Name = "rddetail"
        Me.rddetail.Size = New System.Drawing.Size(52, 17)
        Me.rddetail.TabIndex = 8
        Me.rddetail.TabStop = True
        Me.rddetail.Text = "Detail"
        Me.rddetail.UseVisualStyleBackColor = True
        '
        'rdsummary
        '
        Me.rdsummary.AutoSize = True
        Me.rdsummary.Location = New System.Drawing.Point(93, 13)
        Me.rdsummary.Name = "rdsummary"
        Me.rdsummary.Size = New System.Drawing.Size(68, 17)
        Me.rdsummary.TabIndex = 7
        Me.rdsummary.TabStop = True
        Me.rdsummary.Text = "Summary"
        Me.rdsummary.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rdsummary)
        Me.GroupBox4.Controls.Add(Me.rddetail)
        Me.GroupBox4.Location = New System.Drawing.Point(0, 192)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(337, 36)
        Me.GroupBox4.TabIndex = 9
        Me.GroupBox4.TabStop = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(3, 16)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(638, 358)
        Me.DataGridView1.TabIndex = 1
        '
        'ReportKunjungan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(981, 377)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbdasar)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "ReportKunjungan"
        Me.Text = "ReportKunjungan"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rdpasienbpjs As System.Windows.Forms.RadioButton
    Friend WithEvents rdtagihan As System.Windows.Forms.RadioButton
    Friend WithEvents rdpasienumum As System.Windows.Forms.RadioButton
    Friend WithEvents rdpasienall As System.Windows.Forms.RadioButton
    Friend WithEvents butdisplay As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtakhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtawal As System.Windows.Forms.DateTimePicker
    Friend WithEvents rdtanggal As System.Windows.Forms.RadioButton
    Friend WithEvents cmbdasar As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Private WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents rddetail As System.Windows.Forms.RadioButton
    Friend WithEvents rdsummary As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
End Class
