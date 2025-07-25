<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RekapPendapatanPoli
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RekapPendapatanPoli))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.NewToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.butprint = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.gridpasien = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ButtonExportData = New System.Windows.Forms.Button
        Me.ComboBoxJenisTransaksi = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.CheckBoxSemuaTransaksi = New System.Windows.Forms.CheckBox
        Me.txbankid = New System.Windows.Forms.TextBox
        Me.txnorek = New System.Windows.Forms.TextBox
        Me.txnamabank = New System.Windows.Forms.TextBox
        Me.txnamarek = New System.Windows.Forms.TextBox
        Me.txtgljatuhtempo = New System.Windows.Forms.TextBox
        Me.ComboBoxJenisCetak = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.rdno = New System.Windows.Forms.RadioButton
        Me.rdyes = New System.Windows.Forms.RadioButton
        Me.Label5 = New System.Windows.Forms.Label
        Me.ComboBoxPembayaran = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txkodecabang = New System.Windows.Forms.TextBox
        Me.exportexcel = New System.Windows.Forms.Button
        Me.dtprocessend = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.buttambahpasien = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.butfindcompany = New System.Windows.Forms.Button
        Me.TextBoxKeteranganPerusahaan = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.dtprocess = New System.Windows.Forms.DateTimePicker
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.gridpasien, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem1, Me.CloseToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1200, 24)
        Me.MenuStrip1.TabIndex = 9
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'NewToolStripMenuItem1
        '
        Me.NewToolStripMenuItem1.Name = "NewToolStripMenuItem1"
        Me.NewToolStripMenuItem1.Size = New System.Drawing.Size(43, 20)
        Me.NewToolStripMenuItem1.Text = "New"
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
        Me.GroupBox3.Location = New System.Drawing.Point(0, 491)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1200, 49)
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
        Me.GroupBox4.Size = New System.Drawing.Size(1200, 588)
        Me.GroupBox4.TabIndex = 13
        Me.GroupBox4.TabStop = False
        '
        'gridpasien
        '
        Me.gridpasien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridpasien.EmbeddedNavigator.Name = ""
        Me.gridpasien.Location = New System.Drawing.Point(3, 131)
        Me.gridpasien.MainView = Me.GridView1
        Me.gridpasien.Name = "gridpasien"
        Me.gridpasien.Size = New System.Drawing.Size(1194, 454)
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
        Me.GroupBox1.BackColor = System.Drawing.Color.White
        Me.GroupBox1.Controls.Add(Me.ButtonExportData)
        Me.GroupBox1.Controls.Add(Me.ComboBoxJenisTransaksi)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.CheckBoxSemuaTransaksi)
        Me.GroupBox1.Controls.Add(Me.txbankid)
        Me.GroupBox1.Controls.Add(Me.txnorek)
        Me.GroupBox1.Controls.Add(Me.txnamabank)
        Me.GroupBox1.Controls.Add(Me.txnamarek)
        Me.GroupBox1.Controls.Add(Me.txtgljatuhtempo)
        Me.GroupBox1.Controls.Add(Me.ComboBoxJenisCetak)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.rdno)
        Me.GroupBox1.Controls.Add(Me.rdyes)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.ComboBoxPembayaran)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txkodecabang)
        Me.GroupBox1.Controls.Add(Me.exportexcel)
        Me.GroupBox1.Controls.Add(Me.dtprocessend)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.buttambahpasien)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.butfindcompany)
        Me.GroupBox1.Controls.Add(Me.TextBoxKeteranganPerusahaan)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.dtprocess)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(3, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1194, 115)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        '
        'ButtonExportData
        '
        Me.ButtonExportData.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(19, Byte), Integer), CType(CType(19, Byte), Integer))
        Me.ButtonExportData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonExportData.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonExportData.FlatAppearance.BorderSize = 0
        Me.ButtonExportData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonExportData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonExportData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonExportData.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonExportData.ForeColor = System.Drawing.Color.White
        Me.ButtonExportData.Image = CType(resources.GetObject("ButtonExportData.Image"), System.Drawing.Image)
        Me.ButtonExportData.Location = New System.Drawing.Point(707, 71)
        Me.ButtonExportData.Name = "ButtonExportData"
        Me.ButtonExportData.Size = New System.Drawing.Size(193, 35)
        Me.ButtonExportData.TabIndex = 525
        Me.ButtonExportData.Text = " EXPORT DATA"
        Me.ButtonExportData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonExportData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonExportData.UseVisualStyleBackColor = False
        '
        'ComboBoxJenisTransaksi
        '
        Me.ComboBoxJenisTransaksi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxJenisTransaksi.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxJenisTransaksi.FormattingEnabled = True
        Me.ComboBoxJenisTransaksi.Items.AddRange(New Object() {"POLI", "GIGI", "ADMIN", "SEMUA"})
        Me.ComboBoxJenisTransaksi.Location = New System.Drawing.Point(493, 40)
        Me.ComboBoxJenisTransaksi.Name = "ComboBoxJenisTransaksi"
        Me.ComboBoxJenisTransaksi.Size = New System.Drawing.Size(208, 23)
        Me.ComboBoxJenisTransaksi.TabIndex = 257
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(381, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 15)
        Me.Label1.TabIndex = 256
        Me.Label1.Text = "Jenis Transaksi"
        '
        'CheckBoxSemuaTransaksi
        '
        Me.CheckBoxSemuaTransaksi.AutoSize = True
        Me.CheckBoxSemuaTransaksi.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxSemuaTransaksi.Location = New System.Drawing.Point(716, 12)
        Me.CheckBoxSemuaTransaksi.Name = "CheckBoxSemuaTransaksi"
        Me.CheckBoxSemuaTransaksi.Size = New System.Drawing.Size(184, 19)
        Me.CheckBoxSemuaTransaksi.TabIndex = 255
        Me.CheckBoxSemuaTransaksi.Text = "Tampilkan Semua Transaksi"
        Me.CheckBoxSemuaTransaksi.UseVisualStyleBackColor = True
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
        'ComboBoxJenisCetak
        '
        Me.ComboBoxJenisCetak.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxJenisCetak.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxJenisCetak.FormattingEnabled = True
        Me.ComboBoxJenisCetak.Items.AddRange(New Object() {"REKAP PENDAPATAN", "REKAP PENDAPATAN TAGIHAN (DETAIL)", "TANDA TERIMA", "INVOICE TAGIHAN"})
        Me.ComboBoxJenisCetak.Location = New System.Drawing.Point(106, 70)
        Me.ComboBoxJenisCetak.Name = "ComboBoxJenisCetak"
        Me.ComboBoxJenisCetak.Size = New System.Drawing.Size(254, 23)
        Me.ComboBoxJenisCetak.TabIndex = 248
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(18, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 15)
        Me.Label6.TabIndex = 247
        Me.Label6.Text = "Jenis Cetak"
        '
        'rdno
        '
        Me.rdno.AutoSize = True
        Me.rdno.Enabled = False
        Me.rdno.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdno.Location = New System.Drawing.Point(537, 75)
        Me.rdno.Name = "rdno"
        Me.rdno.Size = New System.Drawing.Size(55, 19)
        Me.rdno.TabIndex = 240
        Me.rdno.TabStop = True
        Me.rdno.Text = "Tidak"
        Me.rdno.UseVisualStyleBackColor = True
        '
        'rdyes
        '
        Me.rdyes.AutoSize = True
        Me.rdyes.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdyes.Location = New System.Drawing.Point(493, 75)
        Me.rdyes.Name = "rdyes"
        Me.rdyes.Size = New System.Drawing.Size(38, 19)
        Me.rdyes.TabIndex = 241
        Me.rdyes.TabStop = True
        Me.rdyes.Text = "Ya"
        Me.rdyes.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(395, 71)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 30)
        Me.Label5.TabIndex = 242
        Me.Label5.Text = "Tampilkan" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Pemeriksaan" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ComboBoxPembayaran
        '
        Me.ComboBoxPembayaran.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxPembayaran.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxPembayaran.FormattingEnabled = True
        Me.ComboBoxPembayaran.Items.AddRange(New Object() {"TAGIHAN", "DEBET", "TUNAI", "CARD"})
        Me.ComboBoxPembayaran.Location = New System.Drawing.Point(493, 10)
        Me.ComboBoxPembayaran.Name = "ComboBoxPembayaran"
        Me.ComboBoxPembayaran.Size = New System.Drawing.Size(208, 23)
        Me.ComboBoxPembayaran.TabIndex = 241
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(366, 13)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(110, 15)
        Me.Label4.TabIndex = 240
        Me.Label4.Text = "Jenis Pembayaran"
        '
        'txkodecabang
        '
        Me.txkodecabang.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txkodecabang.Location = New System.Drawing.Point(106, 40)
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
        Me.dtprocessend.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtprocessend.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtprocessend.Location = New System.Drawing.Point(251, 10)
        Me.dtprocessend.Name = "dtprocessend"
        Me.dtprocessend.Size = New System.Drawing.Size(109, 21)
        Me.dtprocessend.TabIndex = 235
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(221, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 15)
        Me.Label2.TabIndex = 234
        Me.Label2.Text = "s/d"
        '
        'buttambahpasien
        '
        Me.buttambahpasien.Cursor = System.Windows.Forms.Cursors.Hand
        Me.buttambahpasien.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.buttambahpasien.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_add
        Me.buttambahpasien.Location = New System.Drawing.Point(601, 70)
        Me.buttambahpasien.Name = "buttambahpasien"
        Me.buttambahpasien.Size = New System.Drawing.Size(100, 36)
        Me.buttambahpasien.TabIndex = 233
        Me.buttambahpasien.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(9, 13)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(82, 15)
        Me.Label9.TabIndex = 228
        Me.Label9.Text = "Tgl Transaksi"
        '
        'butfindcompany
        '
        Me.butfindcompany.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butfindcompany.Location = New System.Drawing.Point(329, 37)
        Me.butfindcompany.Name = "butfindcompany"
        Me.butfindcompany.Size = New System.Drawing.Size(31, 25)
        Me.butfindcompany.TabIndex = 227
        Me.butfindcompany.Text = "..."
        Me.butfindcompany.UseVisualStyleBackColor = True
        '
        'TextBoxKeteranganPerusahaan
        '
        Me.TextBoxKeteranganPerusahaan.BackColor = System.Drawing.SystemColors.Window
        Me.TextBoxKeteranganPerusahaan.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxKeteranganPerusahaan.Location = New System.Drawing.Point(106, 40)
        Me.TextBoxKeteranganPerusahaan.Name = "TextBoxKeteranganPerusahaan"
        Me.TextBoxKeteranganPerusahaan.ReadOnly = True
        Me.TextBoxKeteranganPerusahaan.Size = New System.Drawing.Size(217, 21)
        Me.TextBoxKeteranganPerusahaan.TabIndex = 226
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(31, 43)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(60, 15)
        Me.Label16.TabIndex = 225
        Me.Label16.Text = "Company"
        '
        'dtprocess
        '
        Me.dtprocess.CustomFormat = "dd-MMM-yyyy"
        Me.dtprocess.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtprocess.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtprocess.Location = New System.Drawing.Point(106, 10)
        Me.dtprocess.Name = "dtprocess"
        Me.dtprocess.Size = New System.Drawing.Size(109, 21)
        Me.dtprocess.TabIndex = 224
        '
        'RekapPendapatanPoli
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1200, 540)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1216, 579)
        Me.MinimumSize = New System.Drawing.Size(1216, 579)
        Me.Name = "RekapPendapatanPoli"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Rekap Pendapatan Klinik"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.gridpasien, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents NewToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents butprint As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents txkodecabang As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents butfindcompany As System.Windows.Forms.Button
    Friend WithEvents TextBoxKeteranganPerusahaan As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents dtprocess As System.Windows.Forms.DateTimePicker
    Friend WithEvents buttambahpasien As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtprocessend As System.Windows.Forms.DateTimePicker
    Private WithEvents gridpasien As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents exportexcel As System.Windows.Forms.Button
    Friend WithEvents ComboBoxPembayaran As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents rdno As System.Windows.Forms.RadioButton
    Friend WithEvents rdyes As System.Windows.Forms.RadioButton
    Friend WithEvents ComboBoxJenisCetak As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtgljatuhtempo As System.Windows.Forms.TextBox
    Friend WithEvents txnamarek As System.Windows.Forms.TextBox
    Friend WithEvents txnorek As System.Windows.Forms.TextBox
    Friend WithEvents txnamabank As System.Windows.Forms.TextBox
    Friend WithEvents txbankid As System.Windows.Forms.TextBox
    Friend WithEvents CheckBoxSemuaTransaksi As System.Windows.Forms.CheckBox
    Friend WithEvents ComboBoxJenisTransaksi As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonExportData As System.Windows.Forms.Button
End Class
