<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInvoiceLab
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
        Me.Button3 = New System.Windows.Forms.Button
        Me.txbelumlunas = New System.Windows.Forms.Label
        Me.txlunas = New System.Windows.Forms.Label
        Me.CheckBoxDelete = New System.Windows.Forms.CheckBox
        Me.txrekapid = New System.Windows.Forms.TextBox
        Me.dtheadertglinvoice = New System.Windows.Forms.DateTimePicker
        Me.dtheadertgljatuhtempo = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txheadernominal = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txheadernotagihan = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txheadercompany = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txnorek = New System.Windows.Forms.TextBox
        Me.txnamabank = New System.Windows.Forms.TextBox
        Me.txnamarek = New System.Windows.Forms.TextBox
        Me.txtgljatuhtempo = New System.Windows.Forms.TextBox
        Me.txtgllab = New System.Windows.Forms.TextBox
        Me.cmbjeniscetak = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.exportpdf = New System.Windows.Forms.Button
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
        Me.gridpasien.Location = New System.Drawing.Point(3, 152)
        Me.gridpasien.MainView = Me.GridView1
        Me.gridpasien.Name = "gridpasien"
        Me.gridpasien.Size = New System.Drawing.Size(1022, 433)
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
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.txbelumlunas)
        Me.GroupBox1.Controls.Add(Me.txlunas)
        Me.GroupBox1.Controls.Add(Me.CheckBoxDelete)
        Me.GroupBox1.Controls.Add(Me.txrekapid)
        Me.GroupBox1.Controls.Add(Me.dtheadertglinvoice)
        Me.GroupBox1.Controls.Add(Me.dtheadertgljatuhtempo)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.txheadernominal)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txheadernotagihan)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txheadercompany)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txnorek)
        Me.GroupBox1.Controls.Add(Me.txnamabank)
        Me.GroupBox1.Controls.Add(Me.txnamarek)
        Me.GroupBox1.Controls.Add(Me.txtgljatuhtempo)
        Me.GroupBox1.Controls.Add(Me.txtgllab)
        Me.GroupBox1.Controls.Add(Me.cmbjeniscetak)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.exportpdf)
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
        Me.GroupBox1.Size = New System.Drawing.Size(1022, 136)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(844, 20)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 269
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'txbelumlunas
        '
        Me.txbelumlunas.AutoSize = True
        Me.txbelumlunas.BackColor = System.Drawing.Color.Tomato
        Me.txbelumlunas.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txbelumlunas.ForeColor = System.Drawing.Color.Transparent
        Me.txbelumlunas.Location = New System.Drawing.Point(698, 76)
        Me.txbelumlunas.Name = "txbelumlunas"
        Me.txbelumlunas.Size = New System.Drawing.Size(159, 24)
        Me.txbelumlunas.TabIndex = 268
        Me.txbelumlunas.Text = "BELUM LUNAS"
        '
        'txlunas
        '
        Me.txlunas.AutoSize = True
        Me.txlunas.BackColor = System.Drawing.Color.Tomato
        Me.txlunas.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txlunas.ForeColor = System.Drawing.Color.Transparent
        Me.txlunas.Location = New System.Drawing.Point(698, 76)
        Me.txlunas.Name = "txlunas"
        Me.txlunas.Size = New System.Drawing.Size(80, 24)
        Me.txlunas.TabIndex = 267
        Me.txlunas.Text = "LUNAS"
        '
        'CheckBoxDelete
        '
        Me.CheckBoxDelete.AutoSize = True
        Me.CheckBoxDelete.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxDelete.Location = New System.Drawing.Point(698, 53)
        Me.CheckBoxDelete.Name = "CheckBoxDelete"
        Me.CheckBoxDelete.Size = New System.Drawing.Size(107, 20)
        Me.CheckBoxDelete.TabIndex = 266
        Me.CheckBoxDelete.Text = "Delete Invoice"
        Me.CheckBoxDelete.UseVisualStyleBackColor = True
        '
        'txrekapid
        '
        Me.txrekapid.BackColor = System.Drawing.SystemColors.Window
        Me.txrekapid.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txrekapid.Location = New System.Drawing.Point(592, 49)
        Me.txrekapid.Name = "txrekapid"
        Me.txrekapid.ReadOnly = True
        Me.txrekapid.Size = New System.Drawing.Size(63, 21)
        Me.txrekapid.TabIndex = 265
        Me.txrekapid.Visible = False
        '
        'dtheadertglinvoice
        '
        Me.dtheadertglinvoice.CustomFormat = "dd-MMM-yyyy"
        Me.dtheadertglinvoice.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtheadertglinvoice.Location = New System.Drawing.Point(442, 50)
        Me.dtheadertglinvoice.Name = "dtheadertglinvoice"
        Me.dtheadertglinvoice.Size = New System.Drawing.Size(144, 20)
        Me.dtheadertglinvoice.TabIndex = 264
        '
        'dtheadertgljatuhtempo
        '
        Me.dtheadertgljatuhtempo.CustomFormat = "dd-MMM-yyyy"
        Me.dtheadertgljatuhtempo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtheadertgljatuhtempo.Location = New System.Drawing.Point(442, 73)
        Me.dtheadertgljatuhtempo.Name = "dtheadertgljatuhtempo"
        Me.dtheadertgljatuhtempo.Size = New System.Drawing.Size(144, 20)
        Me.dtheadertgljatuhtempo.TabIndex = 263
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(329, 74)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 16)
        Me.Label5.TabIndex = 262
        Me.Label5.Text = "Tgl Jatuh Tempo"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(363, 52)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 16)
        Me.Label7.TabIndex = 261
        Me.Label7.Text = "Tgl Invoice"
        '
        'txheadernominal
        '
        Me.txheadernominal.BackColor = System.Drawing.SystemColors.Window
        Me.txheadernominal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txheadernominal.Location = New System.Drawing.Point(91, 95)
        Me.txheadernominal.Name = "txheadernominal"
        Me.txheadernominal.ReadOnly = True
        Me.txheadernominal.Size = New System.Drawing.Size(217, 21)
        Me.txheadernominal.TabIndex = 260
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(22, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 16)
        Me.Label4.TabIndex = 259
        Me.Label4.Text = "Nominal"
        '
        'txheadernotagihan
        '
        Me.txheadernotagihan.BackColor = System.Drawing.SystemColors.Window
        Me.txheadernotagihan.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txheadernotagihan.Location = New System.Drawing.Point(91, 72)
        Me.txheadernotagihan.Name = "txheadernotagihan"
        Me.txheadernotagihan.ReadOnly = True
        Me.txheadernotagihan.Size = New System.Drawing.Size(217, 21)
        Me.txheadernotagihan.TabIndex = 258
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 16)
        Me.Label3.TabIndex = 257
        Me.Label3.Text = "No Invoice"
        '
        'txheadercompany
        '
        Me.txheadercompany.BackColor = System.Drawing.SystemColors.Window
        Me.txheadercompany.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txheadercompany.Location = New System.Drawing.Point(91, 49)
        Me.txheadercompany.Name = "txheadercompany"
        Me.txheadercompany.ReadOnly = True
        Me.txheadercompany.Size = New System.Drawing.Size(217, 21)
        Me.txheadercompany.TabIndex = 256
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 52)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 16)
        Me.Label1.TabIndex = 254
        Me.Label1.Text = "Company"
        '
        'txnorek
        '
        Me.txnorek.Location = New System.Drawing.Point(925, 58)
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
        Me.txnamarek.Location = New System.Drawing.Point(925, 32)
        Me.txnamarek.Name = "txnamarek"
        Me.txnamarek.Size = New System.Drawing.Size(100, 20)
        Me.txnamarek.TabIndex = 251
        Me.txnamarek.Visible = False
        '
        'txtgljatuhtempo
        '
        Me.txtgljatuhtempo.Location = New System.Drawing.Point(925, 51)
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
        'cmbjeniscetak
        '
        Me.cmbjeniscetak.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbjeniscetak.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbjeniscetak.FormattingEnabled = True
        Me.cmbjeniscetak.Items.AddRange(New Object() {"Rekap Tagihan", "Tanda Terima", "Invoice", "Kwitansi"})
        Me.cmbjeniscetak.Location = New System.Drawing.Point(442, 98)
        Me.cmbjeniscetak.Name = "cmbjeniscetak"
        Me.cmbjeniscetak.Size = New System.Drawing.Size(144, 24)
        Me.cmbjeniscetak.TabIndex = 248
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(355, 97)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 16)
        Me.Label6.TabIndex = 247
        Me.Label6.Text = "Jenis Cetak"
        '
        'exportpdf
        '
        Me.exportpdf.Cursor = System.Windows.Forms.Cursors.Hand
        Me.exportpdf.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.exportpdf.Image = Global.PoliKlinik_Net2.My.Resources.Resources.PDF
        Me.exportpdf.Location = New System.Drawing.Point(592, 96)
        Me.exportpdf.Name = "exportpdf"
        Me.exportpdf.Size = New System.Drawing.Size(100, 26)
        Me.exportpdf.TabIndex = 229
        Me.exportpdf.UseVisualStyleBackColor = True
        '
        'txkodecabang
        '
        Me.txkodecabang.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txkodecabang.Location = New System.Drawing.Point(438, 18)
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
        Me.dtprocessend.Location = New System.Drawing.Point(236, 19)
        Me.dtprocessend.Name = "dtprocessend"
        Me.dtprocessend.Size = New System.Drawing.Size(109, 20)
        Me.dtprocessend.TabIndex = 235
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(206, 21)
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
        Me.buttambahpasien.Location = New System.Drawing.Point(698, 12)
        Me.buttambahpasien.Name = "buttambahpasien"
        Me.buttambahpasien.Size = New System.Drawing.Size(100, 36)
        Me.buttambahpasien.TabIndex = 233
        Me.buttambahpasien.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(9, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 16)
        Me.Label9.TabIndex = 228
        Me.Label9.Text = "Tgl Invoice"
        '
        'butfindcompany
        '
        Me.butfindcompany.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butfindcompany.Location = New System.Drawing.Point(661, 15)
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
        Me.txcompanycode.Location = New System.Drawing.Point(438, 18)
        Me.txcompanycode.Name = "txcompanycode"
        Me.txcompanycode.ReadOnly = True
        Me.txcompanycode.Size = New System.Drawing.Size(217, 21)
        Me.txcompanycode.TabIndex = 226
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(369, 21)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(63, 16)
        Me.Label16.TabIndex = 225
        Me.Label16.Text = "Company"
        '
        'dtprocess
        '
        Me.dtprocess.CustomFormat = "dd-MMM-yyyy"
        Me.dtprocess.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtprocess.Location = New System.Drawing.Point(91, 19)
        Me.dtprocess.Name = "dtprocess"
        Me.dtprocess.Size = New System.Drawing.Size(109, 20)
        Me.dtprocess.TabIndex = 224
        '
        'FormInvoiceLab
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 701)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "FormInvoiceLab"
        Me.Text = "Invoice Laboratorium"
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
    Friend WithEvents cmbjeniscetak As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtgllab As System.Windows.Forms.TextBox
    Friend WithEvents txtgljatuhtempo As System.Windows.Forms.TextBox
    Friend WithEvents txnamarek As System.Windows.Forms.TextBox
    Friend WithEvents txnorek As System.Windows.Forms.TextBox
    Friend WithEvents txnamabank As System.Windows.Forms.TextBox
    Friend WithEvents txheadernotagihan As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txheadercompany As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtheadertglinvoice As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtheadertgljatuhtempo As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txheadernominal As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txrekapid As System.Windows.Forms.TextBox
    Friend WithEvents CheckBoxDelete As System.Windows.Forms.CheckBox
    Friend WithEvents txlunas As System.Windows.Forms.Label
    Friend WithEvents txbelumlunas As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
End Class
