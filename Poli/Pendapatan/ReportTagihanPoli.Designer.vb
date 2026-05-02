<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportTagihanPoli
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportTagihanPoli))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.NewToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.GridControlTagihan = New DevExpress.XtraGrid.GridControl
        Me.GridViewTagihan = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ButtonCetakLaporan = New System.Windows.Forms.Button
        Me.ButtonCariTagihan = New System.Windows.Forms.Button
        Me.TextBoxNamaPerusahaan = New System.Windows.Forms.TextBox
        Me.ButtonCariPerusahaan = New System.Windows.Forms.Button
        Me.ComboBoxJenisTransaksi = New System.Windows.Forms.ComboBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.RadioButtonStatusBayarClosed = New System.Windows.Forms.RadioButton
        Me.RadioButtonStatusBayarUnClosed = New System.Windows.Forms.RadioButton
        Me.RadioButtonStatusBayarAll = New System.Windows.Forms.RadioButton
        Me.Label6 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.RadioButtonJenisReportSummary = New System.Windows.Forms.RadioButton
        Me.RadioButtonJenisReportDetail = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtgllab = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.DateTimeTglAkhirTransaksi = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.DateTimeTglAwalTransaksi = New System.Windows.Forms.DateTimePicker
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.GridControlTagihan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewTagihan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem1, Me.PrintToolStripMenuItem, Me.CloseToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1028, 24)
        Me.MenuStrip1.TabIndex = 9
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'NewToolStripMenuItem1
        '
        Me.NewToolStripMenuItem1.Name = "NewToolStripMenuItem1"
        Me.NewToolStripMenuItem1.Size = New System.Drawing.Size(43, 20)
        Me.NewToolStripMenuItem1.Text = "New"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'CloseToolStripMenuItem1
        '
        Me.CloseToolStripMenuItem1.Name = "CloseToolStripMenuItem1"
        Me.CloseToolStripMenuItem1.Size = New System.Drawing.Size(48, 20)
        Me.CloseToolStripMenuItem1.Text = "Close"
        '
        'GroupBox3
        '
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox3.Location = New System.Drawing.Point(0, 652)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1028, 49)
        Me.GroupBox3.TabIndex = 12
        Me.GroupBox3.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.GridControlTagihan)
        Me.GroupBox4.Controls.Add(Me.GroupBox1)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox4.Location = New System.Drawing.Point(0, 24)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1028, 588)
        Me.GroupBox4.TabIndex = 13
        Me.GroupBox4.TabStop = False
        '
        'GridControlTagihan
        '
        Me.GridControlTagihan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControlTagihan.EmbeddedNavigator.Name = ""
        Me.GridControlTagihan.Location = New System.Drawing.Point(3, 178)
        Me.GridControlTagihan.MainView = Me.GridViewTagihan
        Me.GridControlTagihan.Name = "GridControlTagihan"
        Me.GridControlTagihan.Size = New System.Drawing.Size(1022, 407)
        Me.GridControlTagihan.TabIndex = 12
        Me.GridControlTagihan.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewTagihan})
        '
        'GridViewTagihan
        '
        Me.GridViewTagihan.GridControl = Me.GridControlTagihan
        Me.GridViewTagihan.Name = "GridViewTagihan"
        Me.GridViewTagihan.OptionsView.ShowGroupPanel = False
        Me.GridViewTagihan.OptionsView.ShowIndicator = False
        Me.GridViewTagihan.PaintStyleName = "Skin"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ButtonCetakLaporan)
        Me.GroupBox1.Controls.Add(Me.ButtonCariTagihan)
        Me.GroupBox1.Controls.Add(Me.TextBoxNamaPerusahaan)
        Me.GroupBox1.Controls.Add(Me.ButtonCariPerusahaan)
        Me.GroupBox1.Controls.Add(Me.ComboBoxJenisTransaksi)
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtgllab)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.DateTimeTglAkhirTransaksi)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.DateTimeTglAwalTransaksi)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(3, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1022, 162)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
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
        Me.ButtonCetakLaporan.Location = New System.Drawing.Point(288, 109)
        Me.ButtonCetakLaporan.Name = "ButtonCetakLaporan"
        Me.ButtonCetakLaporan.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonCetakLaporan.Size = New System.Drawing.Size(150, 40)
        Me.ButtonCetakLaporan.TabIndex = 581
        Me.ButtonCetakLaporan.Text = " Cetak Laporan"
        Me.ButtonCetakLaporan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonCetakLaporan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonCetakLaporan.UseVisualStyleBackColor = False
        '
        'ButtonCariTagihan
        '
        Me.ButtonCariTagihan.BackColor = System.Drawing.Color.White
        Me.ButtonCariTagihan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonCariTagihan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonCariTagihan.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCariTagihan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCariTagihan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonCariTagihan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCariTagihan.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.ButtonCariTagihan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCariTagihan.Location = New System.Drawing.Point(166, 109)
        Me.ButtonCariTagihan.Name = "ButtonCariTagihan"
        Me.ButtonCariTagihan.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonCariTagihan.Size = New System.Drawing.Size(116, 40)
        Me.ButtonCariTagihan.TabIndex = 547
        Me.ButtonCariTagihan.Text = " View Laporan"
        Me.ButtonCariTagihan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonCariTagihan.UseVisualStyleBackColor = False
        '
        'TextBoxNamaPerusahaan
        '
        Me.TextBoxNamaPerusahaan.BackColor = System.Drawing.Color.White
        Me.TextBoxNamaPerusahaan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxNamaPerusahaan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBoxNamaPerusahaan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TextBoxNamaPerusahaan.Location = New System.Drawing.Point(166, 53)
        Me.TextBoxNamaPerusahaan.Multiline = True
        Me.TextBoxNamaPerusahaan.Name = "TextBoxNamaPerusahaan"
        Me.TextBoxNamaPerusahaan.ReadOnly = True
        Me.TextBoxNamaPerusahaan.Size = New System.Drawing.Size(272, 48)
        Me.TextBoxNamaPerusahaan.TabIndex = 532
        '
        'ButtonCariPerusahaan
        '
        Me.ButtonCariPerusahaan.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCariPerusahaan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonCariPerusahaan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonCariPerusahaan.FlatAppearance.BorderSize = 0
        Me.ButtonCariPerusahaan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCariPerusahaan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonCariPerusahaan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCariPerusahaan.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonCariPerusahaan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ButtonCariPerusahaan.Location = New System.Drawing.Point(444, 53)
        Me.ButtonCariPerusahaan.Name = "ButtonCariPerusahaan"
        Me.ButtonCariPerusahaan.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonCariPerusahaan.Size = New System.Drawing.Size(60, 25)
        Me.ButtonCariPerusahaan.TabIndex = 528
        Me.ButtonCariPerusahaan.Text = " Cari"
        Me.ButtonCariPerusahaan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonCariPerusahaan.UseVisualStyleBackColor = False
        '
        'ComboBoxJenisTransaksi
        '
        Me.ComboBoxJenisTransaksi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxJenisTransaksi.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBoxJenisTransaksi.FormattingEnabled = True
        Me.ComboBoxJenisTransaksi.Items.AddRange(New Object() {"POLI", "GIGI", "ADMIN"})
        Me.ComboBoxJenisTransaksi.Location = New System.Drawing.Point(642, 22)
        Me.ComboBoxJenisTransaksi.Name = "ComboBoxJenisTransaksi"
        Me.ComboBoxJenisTransaksi.Size = New System.Drawing.Size(140, 25)
        Me.ComboBoxJenisTransaksi.TabIndex = 262
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.RadioButtonStatusBayarClosed)
        Me.Panel2.Controls.Add(Me.RadioButtonStatusBayarUnClosed)
        Me.Panel2.Controls.Add(Me.RadioButtonStatusBayarAll)
        Me.Panel2.Location = New System.Drawing.Point(642, 53)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(217, 25)
        Me.Panel2.TabIndex = 260
        '
        'RadioButtonStatusBayarClosed
        '
        Me.RadioButtonStatusBayarClosed.AutoSize = True
        Me.RadioButtonStatusBayarClosed.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.RadioButtonStatusBayarClosed.Location = New System.Drawing.Point(1, 2)
        Me.RadioButtonStatusBayarClosed.Name = "RadioButtonStatusBayarClosed"
        Me.RadioButtonStatusBayarClosed.Size = New System.Drawing.Size(61, 19)
        Me.RadioButtonStatusBayarClosed.TabIndex = 241
        Me.RadioButtonStatusBayarClosed.Text = "Closed"
        Me.RadioButtonStatusBayarClosed.UseVisualStyleBackColor = True
        '
        'RadioButtonStatusBayarUnClosed
        '
        Me.RadioButtonStatusBayarUnClosed.AutoSize = True
        Me.RadioButtonStatusBayarUnClosed.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.RadioButtonStatusBayarUnClosed.Location = New System.Drawing.Point(80, 2)
        Me.RadioButtonStatusBayarUnClosed.Name = "RadioButtonStatusBayarUnClosed"
        Me.RadioButtonStatusBayarUnClosed.Size = New System.Drawing.Size(74, 19)
        Me.RadioButtonStatusBayarUnClosed.TabIndex = 240
        Me.RadioButtonStatusBayarUnClosed.Text = "Unclosed"
        Me.RadioButtonStatusBayarUnClosed.UseVisualStyleBackColor = True
        '
        'RadioButtonStatusBayarAll
        '
        Me.RadioButtonStatusBayarAll.AutoSize = True
        Me.RadioButtonStatusBayarAll.Checked = True
        Me.RadioButtonStatusBayarAll.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.RadioButtonStatusBayarAll.Location = New System.Drawing.Point(160, 2)
        Me.RadioButtonStatusBayarAll.Name = "RadioButtonStatusBayarAll"
        Me.RadioButtonStatusBayarAll.Size = New System.Drawing.Size(39, 19)
        Me.RadioButtonStatusBayarAll.TabIndex = 255
        Me.RadioButtonStatusBayarAll.TabStop = True
        Me.RadioButtonStatusBayarAll.Text = "All"
        Me.RadioButtonStatusBayarAll.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(540, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(96, 17)
        Me.Label6.TabIndex = 259
        Me.Label6.Text = "Jenis Transaksi"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.RadioButtonJenisReportSummary)
        Me.Panel1.Controls.Add(Me.RadioButtonJenisReportDetail)
        Me.Panel1.Location = New System.Drawing.Point(642, 78)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(140, 25)
        Me.Panel1.TabIndex = 257
        '
        'RadioButtonJenisReportSummary
        '
        Me.RadioButtonJenisReportSummary.AutoSize = True
        Me.RadioButtonJenisReportSummary.Checked = True
        Me.RadioButtonJenisReportSummary.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.RadioButtonJenisReportSummary.Location = New System.Drawing.Point(1, 2)
        Me.RadioButtonJenisReportSummary.Name = "RadioButtonJenisReportSummary"
        Me.RadioButtonJenisReportSummary.Size = New System.Drawing.Size(76, 19)
        Me.RadioButtonJenisReportSummary.TabIndex = 242
        Me.RadioButtonJenisReportSummary.TabStop = True
        Me.RadioButtonJenisReportSummary.Text = "Summary"
        Me.RadioButtonJenisReportSummary.UseVisualStyleBackColor = True
        '
        'RadioButtonJenisReportDetail
        '
        Me.RadioButtonJenisReportDetail.AutoSize = True
        Me.RadioButtonJenisReportDetail.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.RadioButtonJenisReportDetail.Location = New System.Drawing.Point(80, 2)
        Me.RadioButtonJenisReportDetail.Name = "RadioButtonJenisReportDetail"
        Me.RadioButtonJenisReportDetail.Size = New System.Drawing.Size(55, 19)
        Me.RadioButtonJenisReportDetail.TabIndex = 243
        Me.RadioButtonJenisReportDetail.Text = "Detail"
        Me.RadioButtonJenisReportDetail.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(540, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 17)
        Me.Label1.TabIndex = 256
        Me.Label1.Text = "Jenis Report"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtgllab
        '
        Me.txtgllab.Location = New System.Drawing.Point(788, 22)
        Me.txtgllab.Name = "txtgllab"
        Me.txtgllab.Size = New System.Drawing.Size(100, 20)
        Me.txtgllab.TabIndex = 249
        Me.txtgllab.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(540, 55)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 17)
        Me.Label5.TabIndex = 242
        Me.Label5.Text = "Status Bayar"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DateTimeTglAkhirTransaksi
        '
        Me.DateTimeTglAkhirTransaksi.CustomFormat = "dd-MMM-yyyy"
        Me.DateTimeTglAkhirTransaksi.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.DateTimeTglAkhirTransaksi.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimeTglAkhirTransaksi.Location = New System.Drawing.Point(354, 19)
        Me.DateTimeTglAkhirTransaksi.Name = "DateTimeTglAkhirTransaksi"
        Me.DateTimeTglAkhirTransaksi.Size = New System.Drawing.Size(150, 25)
        Me.DateTimeTglAkhirTransaksi.TabIndex = 235
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(322, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 16)
        Me.Label2.TabIndex = 234
        Me.Label2.Text = "s/d"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(25, 25)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 17)
        Me.Label9.TabIndex = 228
        Me.Label9.Text = "Tgl Transaksi"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label16.Location = New System.Drawing.Point(25, 58)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(119, 17)
        Me.Label16.TabIndex = 225
        Me.Label16.Text = "Nama Perusahaan"
        '
        'DateTimeTglAwalTransaksi
        '
        Me.DateTimeTglAwalTransaksi.CustomFormat = "dd-MMM-yyyy"
        Me.DateTimeTglAwalTransaksi.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.DateTimeTglAwalTransaksi.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimeTglAwalTransaksi.Location = New System.Drawing.Point(166, 19)
        Me.DateTimeTglAwalTransaksi.Name = "DateTimeTglAwalTransaksi"
        Me.DateTimeTglAwalTransaksi.Size = New System.Drawing.Size(150, 25)
        Me.DateTimeTglAwalTransaksi.TabIndex = 224
        '
        'ReportTagihanPoli
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 701)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ReportTagihanPoli"
        Me.Text = "Report Tagihan Klinik"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.GridControlTagihan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewTagihan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents NewToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents DateTimeTglAwalTransaksi As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DateTimeTglAkhirTransaksi As System.Windows.Forms.DateTimePicker
    Private WithEvents GridControlTagihan As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewTagihan As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents RadioButtonStatusBayarUnClosed As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonStatusBayarClosed As System.Windows.Forms.RadioButton
    Friend WithEvents txtgllab As System.Windows.Forms.TextBox
    Friend WithEvents RadioButtonStatusBayarAll As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents RadioButtonJenisReportSummary As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonJenisReportDetail As System.Windows.Forms.RadioButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxJenisTransaksi As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonCariPerusahaan As System.Windows.Forms.Button
    Friend WithEvents TextBoxNamaPerusahaan As System.Windows.Forms.TextBox
    Friend WithEvents ButtonCariTagihan As System.Windows.Forms.Button
    Friend WithEvents ButtonCetakLaporan As System.Windows.Forms.Button
End Class
