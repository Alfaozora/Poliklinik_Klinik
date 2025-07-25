<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportTagihanLab
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportTagihanLab))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.NewToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.butprint = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.gridpasien = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.rdjenis1 = New System.Windows.Forms.RadioButton
        Me.rdjenis2 = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.rdstatus3 = New System.Windows.Forms.RadioButton
        Me.txbankid = New System.Windows.Forms.TextBox
        Me.txnorek = New System.Windows.Forms.TextBox
        Me.txnamabank = New System.Windows.Forms.TextBox
        Me.txnamarek = New System.Windows.Forms.TextBox
        Me.txtgljatuhtempo = New System.Windows.Forms.TextBox
        Me.txtgllab = New System.Windows.Forms.TextBox
        Me.exportpdf = New System.Windows.Forms.Button
        Me.rdstatus2 = New System.Windows.Forms.RadioButton
        Me.rdstatus1 = New System.Windows.Forms.RadioButton
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmbpembayaran = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txkodecabang = New System.Windows.Forms.TextBox
        Me.exportexcel = New System.Windows.Forms.Button
        Me.dtprocessend = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.buttambahpasien = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.butfindcompany = New System.Windows.Forms.Button
        Me.txcompanycode = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.dtprocess = New System.Windows.Forms.DateTimePicker
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.gridpasien, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
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
        Me.GroupBox3.Controls.Add(Me.Button2)
        Me.GroupBox3.Controls.Add(Me.butprint)
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox3.Location = New System.Drawing.Point(0, 652)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1028, 49)
        Me.GroupBox3.TabIndex = 12
        Me.GroupBox3.TabStop = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(783, 16)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 123
        Me.Button2.Text = "Export .xls"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'butprint
        '
        Me.butprint.Location = New System.Drawing.Point(887, 39)
        Me.butprint.Name = "butprint"
        Me.butprint.Size = New System.Drawing.Size(75, 23)
        Me.butprint.TabIndex = 122
        Me.butprint.Text = "Print"
        Me.butprint.UseVisualStyleBackColor = True
        Me.butprint.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(445, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 121
        Me.Button1.Text = "Display"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.gridpasien)
        Me.GroupBox4.Controls.Add(Me.GroupBox1)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox4.Location = New System.Drawing.Point(0, 24)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1028, 588)
        Me.GroupBox4.TabIndex = 13
        Me.GroupBox4.TabStop = False
        '
        'gridpasien
        '
        Me.gridpasien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridpasien.EmbeddedNavigator.Name = ""
        Me.gridpasien.Location = New System.Drawing.Point(3, 132)
        Me.gridpasien.MainView = Me.GridView1
        Me.gridpasien.Name = "gridpasien"
        Me.gridpasien.Size = New System.Drawing.Size(1022, 453)
        Me.gridpasien.TabIndex = 12
        Me.gridpasien.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.gridpasien
        Me.GridView1.Name = "GridView1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.rdstatus3)
        Me.GroupBox1.Controls.Add(Me.txbankid)
        Me.GroupBox1.Controls.Add(Me.txnorek)
        Me.GroupBox1.Controls.Add(Me.txnamabank)
        Me.GroupBox1.Controls.Add(Me.txnamarek)
        Me.GroupBox1.Controls.Add(Me.txtgljatuhtempo)
        Me.GroupBox1.Controls.Add(Me.txtgllab)
        Me.GroupBox1.Controls.Add(Me.exportpdf)
        Me.GroupBox1.Controls.Add(Me.rdstatus2)
        Me.GroupBox1.Controls.Add(Me.rdstatus1)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.cmbpembayaran)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txkodecabang)
        Me.GroupBox1.Controls.Add(Me.exportexcel)
        Me.GroupBox1.Controls.Add(Me.dtprocessend)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.buttambahpasien)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.butfindcompany)
        Me.GroupBox1.Controls.Add(Me.txcompanycode)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.dtprocess)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(3, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1022, 116)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(387, 75)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(84, 16)
        Me.Label3.TabIndex = 258
        Me.Label3.Text = "Cetak Report"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rdjenis1)
        Me.Panel1.Controls.Add(Me.rdjenis2)
        Me.Panel1.Location = New System.Drawing.Point(473, 43)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(160, 25)
        Me.Panel1.TabIndex = 257
        '
        'rdjenis1
        '
        Me.rdjenis1.AutoSize = True
        Me.rdjenis1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdjenis1.Location = New System.Drawing.Point(6, 3)
        Me.rdjenis1.Name = "rdjenis1"
        Me.rdjenis1.Size = New System.Drawing.Size(78, 19)
        Me.rdjenis1.TabIndex = 242
        Me.rdjenis1.TabStop = True
        Me.rdjenis1.Text = "Summary"
        Me.rdjenis1.UseVisualStyleBackColor = True
        '
        'rdjenis2
        '
        Me.rdjenis2.AutoSize = True
        Me.rdjenis2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdjenis2.Location = New System.Drawing.Point(84, 3)
        Me.rdjenis2.Name = "rdjenis2"
        Me.rdjenis2.Size = New System.Drawing.Size(57, 19)
        Me.rdjenis2.TabIndex = 243
        Me.rdjenis2.TabStop = True
        Me.rdjenis2.Text = "Detail"
        Me.rdjenis2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(391, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 256
        Me.Label1.Text = "Jenis Report"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'rdstatus3
        '
        Me.rdstatus3.AutoSize = True
        Me.rdstatus3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdstatus3.Location = New System.Drawing.Point(647, 21)
        Me.rdstatus3.Name = "rdstatus3"
        Me.rdstatus3.Size = New System.Drawing.Size(38, 19)
        Me.rdstatus3.TabIndex = 255
        Me.rdstatus3.TabStop = True
        Me.rdstatus3.Text = "All"
        Me.rdstatus3.UseVisualStyleBackColor = True
        '
        'txbankid
        '
        Me.txbankid.Location = New System.Drawing.Point(925, 77)
        Me.txbankid.Name = "txbankid"
        Me.txbankid.Size = New System.Drawing.Size(100, 20)
        Me.txbankid.TabIndex = 254
        Me.txbankid.Visible = False
        '
        'txnorek
        '
        Me.txnorek.Location = New System.Drawing.Point(925, 18)
        Me.txnorek.Name = "txnorek"
        Me.txnorek.Size = New System.Drawing.Size(100, 20)
        Me.txnorek.TabIndex = 253
        Me.txnorek.Visible = False
        '
        'txnamabank
        '
        Me.txnamabank.Location = New System.Drawing.Point(925, 70)
        Me.txnamabank.Name = "txnamabank"
        Me.txnamabank.Size = New System.Drawing.Size(100, 20)
        Me.txnamabank.TabIndex = 252
        Me.txnamabank.Visible = False
        '
        'txnamarek
        '
        Me.txnamarek.Location = New System.Drawing.Point(925, 26)
        Me.txnamarek.Name = "txnamarek"
        Me.txnamarek.Size = New System.Drawing.Size(100, 20)
        Me.txnamarek.TabIndex = 251
        Me.txnamarek.Visible = False
        '
        'txtgljatuhtempo
        '
        Me.txtgljatuhtempo.Location = New System.Drawing.Point(925, 39)
        Me.txtgljatuhtempo.Name = "txtgljatuhtempo"
        Me.txtgljatuhtempo.Size = New System.Drawing.Size(100, 20)
        Me.txtgljatuhtempo.TabIndex = 250
        Me.txtgljatuhtempo.Visible = False
        '
        'txtgllab
        '
        Me.txtgllab.Location = New System.Drawing.Point(925, 51)
        Me.txtgllab.Name = "txtgllab"
        Me.txtgllab.Size = New System.Drawing.Size(100, 20)
        Me.txtgllab.TabIndex = 249
        Me.txtgllab.Visible = False
        '
        'exportpdf
        '
        Me.exportpdf.Cursor = System.Windows.Forms.Cursors.Hand
        Me.exportpdf.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.exportpdf.Image = Global.PoliKlinik_Net2.My.Resources.Resources.PDF
        Me.exportpdf.Location = New System.Drawing.Point(473, 70)
        Me.exportpdf.Name = "exportpdf"
        Me.exportpdf.Size = New System.Drawing.Size(100, 26)
        Me.exportpdf.TabIndex = 229
        Me.exportpdf.UseVisualStyleBackColor = True
        '
        'rdstatus2
        '
        Me.rdstatus2.AutoSize = True
        Me.rdstatus2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdstatus2.Location = New System.Drawing.Point(557, 21)
        Me.rdstatus2.Name = "rdstatus2"
        Me.rdstatus2.Size = New System.Drawing.Size(78, 19)
        Me.rdstatus2.TabIndex = 240
        Me.rdstatus2.TabStop = True
        Me.rdstatus2.Text = "Unclosed"
        Me.rdstatus2.UseVisualStyleBackColor = True
        '
        'rdstatus1
        '
        Me.rdstatus1.AutoSize = True
        Me.rdstatus1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdstatus1.Location = New System.Drawing.Point(479, 21)
        Me.rdstatus1.Name = "rdstatus1"
        Me.rdstatus1.Size = New System.Drawing.Size(65, 19)
        Me.rdstatus1.TabIndex = 241
        Me.rdstatus1.TabStop = True
        Me.rdstatus1.Text = "Closed"
        Me.rdstatus1.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(387, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 16)
        Me.Label5.TabIndex = 242
        Me.Label5.Text = "Status Bayar"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbpembayaran
        '
        Me.cmbpembayaran.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbpembayaran.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbpembayaran.FormattingEnabled = True
        Me.cmbpembayaran.Items.AddRange(New Object() {"TAGIHAN"})
        Me.cmbpembayaran.Location = New System.Drawing.Point(106, 75)
        Me.cmbpembayaran.Name = "cmbpembayaran"
        Me.cmbpembayaran.Size = New System.Drawing.Size(254, 24)
        Me.cmbpembayaran.TabIndex = 241
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(13, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 16)
        Me.Label4.TabIndex = 240
        Me.Label4.Text = "Pembayaran"
        '
        'txkodecabang
        '
        Me.txkodecabang.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txkodecabang.Location = New System.Drawing.Point(106, 46)
        Me.txkodecabang.Name = "txkodecabang"
        Me.txkodecabang.Size = New System.Drawing.Size(100, 21)
        Me.txkodecabang.TabIndex = 16
        Me.txkodecabang.Visible = False
        '
        'exportexcel
        '
        Me.exportexcel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.exportexcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.exportexcel.Image = Global.PoliKlinik_Net2.My.Resources.Resources.Excell
        Me.exportexcel.Location = New System.Drawing.Point(925, 18)
        Me.exportexcel.Name = "exportexcel"
        Me.exportexcel.Size = New System.Drawing.Size(100, 26)
        Me.exportexcel.TabIndex = 236
        Me.exportexcel.UseVisualStyleBackColor = True
        Me.exportexcel.Visible = False
        '
        'dtprocessend
        '
        Me.dtprocessend.CustomFormat = "dd-MMM-yyyy"
        Me.dtprocessend.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtprocessend.Location = New System.Drawing.Point(251, 20)
        Me.dtprocessend.Name = "dtprocessend"
        Me.dtprocessend.Size = New System.Drawing.Size(109, 20)
        Me.dtprocessend.TabIndex = 235
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(221, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 16)
        Me.Label2.TabIndex = 234
        Me.Label2.Text = "s/d"
        '
        'buttambahpasien
        '
        Me.buttambahpasien.Cursor = System.Windows.Forms.Cursors.Hand
        Me.buttambahpasien.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.buttambahpasien.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_cari
        Me.buttambahpasien.Location = New System.Drawing.Point(585, 70)
        Me.buttambahpasien.Name = "buttambahpasien"
        Me.buttambahpasien.Size = New System.Drawing.Size(100, 36)
        Me.buttambahpasien.TabIndex = 233
        Me.buttambahpasien.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(9, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 16)
        Me.Label9.TabIndex = 228
        Me.Label9.Text = "Tgl Transaksi"
        '
        'butfindcompany
        '
        Me.butfindcompany.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butfindcompany.Location = New System.Drawing.Point(329, 43)
        Me.butfindcompany.Name = "butfindcompany"
        Me.butfindcompany.Size = New System.Drawing.Size(31, 25)
        Me.butfindcompany.TabIndex = 227
        Me.butfindcompany.Text = "..."
        Me.butfindcompany.UseVisualStyleBackColor = True
        '
        'txcompanycode
        '
        Me.txcompanycode.BackColor = System.Drawing.SystemColors.Window
        Me.txcompanycode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txcompanycode.Location = New System.Drawing.Point(106, 46)
        Me.txcompanycode.Name = "txcompanycode"
        Me.txcompanycode.ReadOnly = True
        Me.txcompanycode.Size = New System.Drawing.Size(217, 21)
        Me.txcompanycode.TabIndex = 226
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(31, 48)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(63, 16)
        Me.Label16.TabIndex = 225
        Me.Label16.Text = "Company"
        '
        'dtprocess
        '
        Me.dtprocess.CustomFormat = "dd-MMM-yyyy"
        Me.dtprocess.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtprocess.Location = New System.Drawing.Point(106, 20)
        Me.dtprocess.Name = "dtprocess"
        Me.dtprocess.Size = New System.Drawing.Size(109, 20)
        Me.dtprocess.TabIndex = 224
        '
        'ReportTagihanLab
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 701)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ReportTagihanLab"
        Me.Text = "Report Tagihan Laboratorium"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.gridpasien, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents butprint As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents txkodecabang As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents exportpdf As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents butfindcompany As System.Windows.Forms.Button
    Friend WithEvents txcompanycode As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents dtprocess As System.Windows.Forms.DateTimePicker
    Friend WithEvents buttambahpasien As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtprocessend As System.Windows.Forms.DateTimePicker
    Private WithEvents gridpasien As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents exportexcel As System.Windows.Forms.Button
    Friend WithEvents cmbpembayaran As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents rdstatus2 As System.Windows.Forms.RadioButton
    Friend WithEvents rdstatus1 As System.Windows.Forms.RadioButton
    Friend WithEvents txtgllab As System.Windows.Forms.TextBox
    Friend WithEvents txtgljatuhtempo As System.Windows.Forms.TextBox
    Friend WithEvents txnamarek As System.Windows.Forms.TextBox
    Friend WithEvents txnorek As System.Windows.Forms.TextBox
    Friend WithEvents txnamabank As System.Windows.Forms.TextBox
    Friend WithEvents txbankid As System.Windows.Forms.TextBox
    Friend WithEvents rdstatus3 As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rdjenis1 As System.Windows.Forms.RadioButton
    Friend WithEvents rdjenis2 As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
