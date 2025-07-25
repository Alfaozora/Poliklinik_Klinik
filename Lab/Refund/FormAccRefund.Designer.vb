<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAccRefund
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAccRefund))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.NewToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.CetakSuratRefundToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.groupcustomer = New System.Windows.Forms.GroupBox
        Me.cbtransaksi = New System.Windows.Forms.CheckBox
        Me.txnamakaryawan = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.lbllebihbayar = New System.Windows.Forms.Label
        Me.txnominalbayar = New System.Windows.Forms.NumericUpDown
        Me.Label18 = New System.Windows.Forms.Label
        Me.cbdeleterefund = New System.Windows.Forms.CheckBox
        Me.cbaccrefund = New System.Windows.Forms.CheckBox
        Me.dtrefund = New System.Windows.Forms.DateTimePicker
        Me.Label17 = New System.Windows.Forms.Label
        Me.txnorefund = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.butsearchrefund = New System.Windows.Forms.Button
        Me.cmbalasan = New System.Windows.Forms.ComboBox
        Me.cmbstatus = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txbersangkutan = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txnolab = New System.Windows.Forms.TextBox
        Me.CheckAll = New System.Windows.Forms.CheckBox
        Me.butkalkulasi = New System.Windows.Forms.Button
        Me.txnoinvoice = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txatasnamarek = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txbankrek = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txnorek = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txsendnominal = New System.Windows.Forms.TextBox
        Me.dttglakhir = New System.Windows.Forms.DateTimePicker
        Me.Label11 = New System.Windows.Forms.Label
        Me.dttglawal = New System.Windows.Forms.DateTimePicker
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txnominal = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtelp = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.butsaved = New System.Windows.Forms.Button
        Me.dtprocessend = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.dtprocess = New System.Windows.Forms.DateTimePicker
        Me.gridrefund = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.MenuStrip1.SuspendLayout()
        Me.groupcustomer.SuspendLayout()
        CType(Me.txnominalbayar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridrefund, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem1, Me.CetakSuratRefundToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1200, 24)
        Me.MenuStrip1.TabIndex = 9
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'NewToolStripMenuItem1
        '
        Me.NewToolStripMenuItem1.Name = "NewToolStripMenuItem1"
        Me.NewToolStripMenuItem1.Size = New System.Drawing.Size(65, 20)
        Me.NewToolStripMenuItem1.Text = "Set Clear"
        '
        'CetakSuratRefundToolStripMenuItem
        '
        Me.CetakSuratRefundToolStripMenuItem.Name = "CetakSuratRefundToolStripMenuItem"
        Me.CetakSuratRefundToolStripMenuItem.Size = New System.Drawing.Size(120, 20)
        Me.CetakSuratRefundToolStripMenuItem.Text = "Cetak Surat Refund"
        '
        'groupcustomer
        '
        Me.groupcustomer.Controls.Add(Me.cbtransaksi)
        Me.groupcustomer.Controls.Add(Me.txnamakaryawan)
        Me.groupcustomer.Controls.Add(Me.Label19)
        Me.groupcustomer.Controls.Add(Me.lbllebihbayar)
        Me.groupcustomer.Controls.Add(Me.txnominalbayar)
        Me.groupcustomer.Controls.Add(Me.Label18)
        Me.groupcustomer.Controls.Add(Me.cbdeleterefund)
        Me.groupcustomer.Controls.Add(Me.cbaccrefund)
        Me.groupcustomer.Controls.Add(Me.dtrefund)
        Me.groupcustomer.Controls.Add(Me.Label17)
        Me.groupcustomer.Controls.Add(Me.txnorefund)
        Me.groupcustomer.Controls.Add(Me.Label13)
        Me.groupcustomer.Controls.Add(Me.butsearchrefund)
        Me.groupcustomer.Controls.Add(Me.cmbalasan)
        Me.groupcustomer.Controls.Add(Me.cmbstatus)
        Me.groupcustomer.Controls.Add(Me.Label6)
        Me.groupcustomer.Controls.Add(Me.txbersangkutan)
        Me.groupcustomer.Controls.Add(Me.Label4)
        Me.groupcustomer.Controls.Add(Me.txnolab)
        Me.groupcustomer.Controls.Add(Me.CheckAll)
        Me.groupcustomer.Controls.Add(Me.butkalkulasi)
        Me.groupcustomer.Controls.Add(Me.txnoinvoice)
        Me.groupcustomer.Controls.Add(Me.Label16)
        Me.groupcustomer.Controls.Add(Me.txatasnamarek)
        Me.groupcustomer.Controls.Add(Me.Label15)
        Me.groupcustomer.Controls.Add(Me.txbankrek)
        Me.groupcustomer.Controls.Add(Me.Label12)
        Me.groupcustomer.Controls.Add(Me.txnorek)
        Me.groupcustomer.Controls.Add(Me.Label7)
        Me.groupcustomer.Controls.Add(Me.Label14)
        Me.groupcustomer.Controls.Add(Me.txsendnominal)
        Me.groupcustomer.Controls.Add(Me.dttglakhir)
        Me.groupcustomer.Controls.Add(Me.Label11)
        Me.groupcustomer.Controls.Add(Me.dttglawal)
        Me.groupcustomer.Controls.Add(Me.Label10)
        Me.groupcustomer.Controls.Add(Me.Label1)
        Me.groupcustomer.Controls.Add(Me.txnominal)
        Me.groupcustomer.Controls.Add(Me.Label3)
        Me.groupcustomer.Controls.Add(Me.txtelp)
        Me.groupcustomer.Controls.Add(Me.Label2)
        Me.groupcustomer.Controls.Add(Me.butsaved)
        Me.groupcustomer.Controls.Add(Me.dtprocessend)
        Me.groupcustomer.Controls.Add(Me.Label5)
        Me.groupcustomer.Controls.Add(Me.Label9)
        Me.groupcustomer.Controls.Add(Me.dtprocess)
        Me.groupcustomer.Dock = System.Windows.Forms.DockStyle.Top
        Me.groupcustomer.Location = New System.Drawing.Point(0, 24)
        Me.groupcustomer.Name = "groupcustomer"
        Me.groupcustomer.Size = New System.Drawing.Size(1200, 251)
        Me.groupcustomer.TabIndex = 10
        Me.groupcustomer.TabStop = False
        Me.groupcustomer.Text = "Tambah Data Pasien Refund"
        '
        'cbtransaksi
        '
        Me.cbtransaksi.AutoSize = True
        Me.cbtransaksi.Enabled = False
        Me.cbtransaksi.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbtransaksi.Location = New System.Drawing.Point(275, 90)
        Me.cbtransaksi.Name = "cbtransaksi"
        Me.cbtransaksi.Size = New System.Drawing.Size(81, 19)
        Me.cbtransaksi.TabIndex = 315
        Me.cbtransaksi.Text = "Transaksi"
        Me.cbtransaksi.UseVisualStyleBackColor = True
        '
        'txnamakaryawan
        '
        Me.txnamakaryawan.BackColor = System.Drawing.SystemColors.Window
        Me.txnamakaryawan.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txnamakaryawan.Location = New System.Drawing.Point(539, 215)
        Me.txnamakaryawan.Name = "txnamakaryawan"
        Me.txnamakaryawan.ReadOnly = True
        Me.txnamakaryawan.Size = New System.Drawing.Size(250, 21)
        Me.txnamakaryawan.TabIndex = 314
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(423, 218)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(103, 16)
        Me.Label19.TabIndex = 313
        Me.Label19.Text = "Nama Karyawan"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lbllebihbayar
        '
        Me.lbllebihbayar.AutoSize = True
        Me.lbllebihbayar.BackColor = System.Drawing.Color.Transparent
        Me.lbllebihbayar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllebihbayar.ForeColor = System.Drawing.Color.Red
        Me.lbllebihbayar.Location = New System.Drawing.Point(272, 117)
        Me.lbllebihbayar.Name = "lbllebihbayar"
        Me.lbllebihbayar.Size = New System.Drawing.Size(104, 15)
        Me.lbllebihbayar.TabIndex = 312
        Me.lbllebihbayar.Text = "*Kelebihan Bayar"
        Me.lbllebihbayar.Visible = False
        '
        'txnominalbayar
        '
        Me.txnominalbayar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txnominalbayar.Location = New System.Drawing.Point(137, 115)
        Me.txnominalbayar.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.txnominalbayar.Name = "txnominalbayar"
        Me.txnominalbayar.Size = New System.Drawing.Size(129, 21)
        Me.txnominalbayar.TabIndex = 311
        Me.txnominalbayar.ThousandsSeparator = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(5, 118)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(119, 16)
        Me.Label18.TabIndex = 310
        Me.Label18.Text = "Nominal yg dibayar"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cbdeleterefund
        '
        Me.cbdeleterefund.AutoSize = True
        Me.cbdeleterefund.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbdeleterefund.Location = New System.Drawing.Point(842, 90)
        Me.cbdeleterefund.Name = "cbdeleterefund"
        Me.cbdeleterefund.Size = New System.Drawing.Size(117, 20)
        Me.cbdeleterefund.TabIndex = 309
        Me.cbdeleterefund.Text = "Delete Refund"
        Me.cbdeleterefund.UseVisualStyleBackColor = True
        '
        'cbaccrefund
        '
        Me.cbaccrefund.AutoSize = True
        Me.cbaccrefund.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbaccrefund.Location = New System.Drawing.Point(842, 66)
        Me.cbaccrefund.Name = "cbaccrefund"
        Me.cbaccrefund.Size = New System.Drawing.Size(99, 20)
        Me.cbaccrefund.TabIndex = 308
        Me.cbaccrefund.Text = "Acc Refund"
        Me.cbaccrefund.UseVisualStyleBackColor = True
        '
        'dtrefund
        '
        Me.dtrefund.CustomFormat = "dd-MMM-yyyy"
        Me.dtrefund.Enabled = False
        Me.dtrefund.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.dtrefund.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtrefund.Location = New System.Drawing.Point(539, 65)
        Me.dtrefund.Name = "dtrefund"
        Me.dtrefund.Size = New System.Drawing.Size(113, 21)
        Me.dtrefund.TabIndex = 307
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(457, 68)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(69, 16)
        Me.Label17.TabIndex = 306
        Me.Label17.Text = "Tgl Refund"
        '
        'txnorefund
        '
        Me.txnorefund.BackColor = System.Drawing.SystemColors.Window
        Me.txnorefund.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txnorefund.Location = New System.Drawing.Point(137, 65)
        Me.txnorefund.Name = "txnorefund"
        Me.txnorefund.ReadOnly = True
        Me.txnorefund.Size = New System.Drawing.Size(250, 21)
        Me.txnorefund.TabIndex = 305
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(52, 68)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(72, 16)
        Me.Label13.TabIndex = 304
        Me.Label13.Text = "No. Refund"
        '
        'butsearchrefund
        '
        Me.butsearchrefund.Cursor = System.Windows.Forms.Cursors.Hand
        Me.butsearchrefund.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butsearchrefund.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_cari
        Me.butsearchrefund.Location = New System.Drawing.Point(400, 14)
        Me.butsearchrefund.Name = "butsearchrefund"
        Me.butsearchrefund.Size = New System.Drawing.Size(100, 36)
        Me.butsearchrefund.TabIndex = 303
        Me.butsearchrefund.UseVisualStyleBackColor = True
        '
        'cmbalasan
        '
        Me.cmbalasan.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmbalasan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbalasan.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbalasan.FormattingEnabled = True
        Me.cmbalasan.Location = New System.Drawing.Point(137, 170)
        Me.cmbalasan.Name = "cmbalasan"
        Me.cmbalasan.Size = New System.Drawing.Size(250, 23)
        Me.cmbalasan.TabIndex = 295
        '
        'cmbstatus
        '
        Me.cmbstatus.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmbstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbstatus.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbstatus.FormattingEnabled = True
        Me.cmbstatus.Items.AddRange(New Object() {"A. KESALAHAN PASIEN", "B. KESALAHAN PERUSAHAAN", "C. KESALAHAN KARYAWAN"})
        Me.cmbstatus.Location = New System.Drawing.Point(137, 140)
        Me.cmbstatus.Name = "cmbstatus"
        Me.cmbstatus.Size = New System.Drawing.Size(250, 23)
        Me.cmbstatus.TabIndex = 294
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(13, 143)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(111, 16)
        Me.Label6.TabIndex = 293
        Me.Label6.Text = "Status Kesalahan"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txbersangkutan
        '
        Me.txbersangkutan.BackColor = System.Drawing.SystemColors.Window
        Me.txbersangkutan.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txbersangkutan.Location = New System.Drawing.Point(539, 190)
        Me.txbersangkutan.Name = "txbersangkutan"
        Me.txbersangkutan.ReadOnly = True
        Me.txbersangkutan.Size = New System.Drawing.Size(250, 21)
        Me.txbersangkutan.TabIndex = 292
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(440, 193)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 16)
        Me.Label4.TabIndex = 291
        Me.Label4.Text = "Nama Pasien"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txnolab
        '
        Me.txnolab.BackColor = System.Drawing.SystemColors.Window
        Me.txnolab.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txnolab.Location = New System.Drawing.Point(1080, 135)
        Me.txnolab.Name = "txnolab"
        Me.txnolab.Size = New System.Drawing.Size(117, 21)
        Me.txnolab.TabIndex = 290
        Me.txnolab.Visible = False
        '
        'CheckAll
        '
        Me.CheckAll.AutoSize = True
        Me.CheckAll.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckAll.Location = New System.Drawing.Point(800, 178)
        Me.CheckAll.Name = "CheckAll"
        Me.CheckAll.Size = New System.Drawing.Size(97, 20)
        Me.CheckAll.TabIndex = 289
        Me.CheckAll.Text = "Pilih Semua"
        Me.CheckAll.UseVisualStyleBackColor = True
        Me.CheckAll.Visible = False
        '
        'butkalkulasi
        '
        Me.butkalkulasi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.butkalkulasi.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butkalkulasi.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_kalkulasi
        Me.butkalkulasi.Location = New System.Drawing.Point(903, 169)
        Me.butkalkulasi.Name = "butkalkulasi"
        Me.butkalkulasi.Size = New System.Drawing.Size(100, 36)
        Me.butkalkulasi.TabIndex = 288
        Me.butkalkulasi.UseVisualStyleBackColor = True
        Me.butkalkulasi.Visible = False
        '
        'txnoinvoice
        '
        Me.txnoinvoice.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txnoinvoice.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.txnoinvoice.Location = New System.Drawing.Point(947, 39)
        Me.txnoinvoice.Multiline = True
        Me.txnoinvoice.Name = "txnoinvoice"
        Me.txnoinvoice.ReadOnly = True
        Me.txnoinvoice.Size = New System.Drawing.Size(250, 117)
        Me.txnoinvoice.TabIndex = 287
        Me.txnoinvoice.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(874, 39)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(67, 16)
        Me.Label16.TabIndex = 286
        Me.Label16.Text = "No Invoice"
        Me.Label16.Visible = False
        '
        'txatasnamarek
        '
        Me.txatasnamarek.BackColor = System.Drawing.SystemColors.Window
        Me.txatasnamarek.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txatasnamarek.Location = New System.Drawing.Point(539, 165)
        Me.txatasnamarek.Name = "txatasnamarek"
        Me.txatasnamarek.ReadOnly = True
        Me.txatasnamarek.Size = New System.Drawing.Size(250, 21)
        Me.txatasnamarek.TabIndex = 285
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(426, 168)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 16)
        Me.Label15.TabIndex = 284
        Me.Label15.Text = "Atas Nama Rek"
        '
        'txbankrek
        '
        Me.txbankrek.BackColor = System.Drawing.SystemColors.Window
        Me.txbankrek.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txbankrek.Location = New System.Drawing.Point(539, 140)
        Me.txbankrek.Name = "txbankrek"
        Me.txbankrek.ReadOnly = True
        Me.txbankrek.Size = New System.Drawing.Size(250, 21)
        Me.txbankrek.TabIndex = 283
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(423, 143)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(103, 16)
        Me.Label12.TabIndex = 282
        Me.Label12.Text = "Nama Bank Rek"
        '
        'txnorek
        '
        Me.txnorek.BackColor = System.Drawing.SystemColors.Window
        Me.txnorek.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txnorek.Location = New System.Drawing.Point(539, 115)
        Me.txnorek.Name = "txnorek"
        Me.txnorek.ReadOnly = True
        Me.txnorek.Size = New System.Drawing.Size(250, 21)
        Me.txnorek.TabIndex = 281
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(471, 118)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 16)
        Me.Label7.TabIndex = 280
        Me.Label7.Text = "No. Rek"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(885, 17)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(56, 16)
        Me.Label14.TabIndex = 279
        Me.Label14.Text = "Tgl Awal"
        Me.Label14.Visible = False
        '
        'txsendnominal
        '
        Me.txsendnominal.BackColor = System.Drawing.SystemColors.Window
        Me.txsendnominal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txsendnominal.Location = New System.Drawing.Point(137, 90)
        Me.txsendnominal.Name = "txsendnominal"
        Me.txsendnominal.ReadOnly = True
        Me.txsendnominal.Size = New System.Drawing.Size(48, 21)
        Me.txsendnominal.TabIndex = 276
        Me.txsendnominal.Visible = False
        '
        'dttglakhir
        '
        Me.dttglakhir.CustomFormat = "dd-MMM-yyyy"
        Me.dttglakhir.Enabled = False
        Me.dttglakhir.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dttglakhir.Location = New System.Drawing.Point(1109, 14)
        Me.dttglakhir.Name = "dttglakhir"
        Me.dttglakhir.Size = New System.Drawing.Size(88, 20)
        Me.dttglakhir.TabIndex = 272
        Me.dttglakhir.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(1045, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(58, 16)
        Me.Label11.TabIndex = 271
        Me.Label11.Text = "Tgl Akhir"
        Me.Label11.Visible = False
        '
        'dttglawal
        '
        Me.dttglawal.CustomFormat = "dd-MMM-yyyy"
        Me.dttglawal.Enabled = False
        Me.dttglawal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dttglawal.Location = New System.Drawing.Point(947, 14)
        Me.dttglawal.Name = "dttglawal"
        Me.dttglawal.Size = New System.Drawing.Size(88, 20)
        Me.dttglawal.TabIndex = 270
        Me.dttglawal.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(406, 141)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(0, 16)
        Me.Label10.TabIndex = 269
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(26, 93)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 16)
        Me.Label1.TabIndex = 262
        Me.Label1.Text = "Nominal Invoice"
        '
        'txnominal
        '
        Me.txnominal.BackColor = System.Drawing.SystemColors.Window
        Me.txnominal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txnominal.Location = New System.Drawing.Point(137, 90)
        Me.txnominal.Name = "txnominal"
        Me.txnominal.ReadOnly = True
        Me.txnominal.Size = New System.Drawing.Size(129, 21)
        Me.txnominal.TabIndex = 261
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(76, 173)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 16)
        Me.Label3.TabIndex = 258
        Me.Label3.Text = "Alasan"
        '
        'txtelp
        '
        Me.txtelp.BackColor = System.Drawing.SystemColors.Window
        Me.txtelp.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtelp.Location = New System.Drawing.Point(539, 90)
        Me.txtelp.Name = "txtelp"
        Me.txtelp.ReadOnly = True
        Me.txtelp.Size = New System.Drawing.Size(250, 21)
        Me.txtelp.TabIndex = 257
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(458, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 16)
        Me.Label2.TabIndex = 256
        Me.Label2.Text = "No. Telpon"
        '
        'butsaved
        '
        Me.butsaved.Cursor = System.Windows.Forms.Cursors.Hand
        Me.butsaved.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butsaved.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_save
        Me.butsaved.Location = New System.Drawing.Point(1113, 169)
        Me.butsaved.Name = "butsaved"
        Me.butsaved.Size = New System.Drawing.Size(100, 36)
        Me.butsaved.TabIndex = 246
        Me.butsaved.UseVisualStyleBackColor = True
        Me.butsaved.Visible = False
        '
        'dtprocessend
        '
        Me.dtprocessend.CustomFormat = "dd-MMM-yyyy"
        Me.dtprocessend.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtprocessend.Location = New System.Drawing.Point(277, 21)
        Me.dtprocessend.Name = "dtprocessend"
        Me.dtprocessend.Size = New System.Drawing.Size(110, 20)
        Me.dtprocessend.TabIndex = 243
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(249, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(26, 16)
        Me.Label5.TabIndex = 242
        Me.Label5.Text = "s/d"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(56, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(69, 16)
        Me.Label9.TabIndex = 241
        Me.Label9.Text = "Tgl Refund"
        '
        'dtprocess
        '
        Me.dtprocess.CustomFormat = "dd-MMM-yyyy"
        Me.dtprocess.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtprocess.Location = New System.Drawing.Point(137, 21)
        Me.dtprocess.Name = "dtprocess"
        Me.dtprocess.Size = New System.Drawing.Size(110, 20)
        Me.dtprocess.TabIndex = 237
        '
        'gridrefund
        '
        Me.gridrefund.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridrefund.EmbeddedNavigator.Name = ""
        Me.gridrefund.Location = New System.Drawing.Point(0, 275)
        Me.gridrefund.MainView = Me.GridView1
        Me.gridrefund.Name = "gridrefund"
        Me.gridrefund.Size = New System.Drawing.Size(1200, 265)
        Me.gridrefund.TabIndex = 11
        Me.gridrefund.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.gridrefund
        Me.GridView1.GroupPanelText = "Data Pasien Refund"
        Me.GridView1.Name = "GridView1"
        '
        'FormAccRefund
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1200, 540)
        Me.Controls.Add(Me.gridrefund)
        Me.Controls.Add(Me.groupcustomer)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormAccRefund"
        Me.Text = "Form Acc Refund"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.groupcustomer.ResumeLayout(False)
        Me.groupcustomer.PerformLayout()
        CType(Me.txnominalbayar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridrefund, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents NewToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents groupcustomer As System.Windows.Forms.GroupBox
    'Friend WithEvents butlabrujukanid As DevExpress.XtraEditors.ButtonEdit
    'Friend WithEvents butrujukanid As DevExpress.XtraEditors.ButtonEdit
    Private WithEvents gridrefund As DevExpress.XtraGrid.GridControl
    Private WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents dtprocessend As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtprocess As System.Windows.Forms.DateTimePicker
    Friend WithEvents butsaved As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtelp As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txnominal As System.Windows.Forms.TextBox
    Friend WithEvents dttglakhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dttglawal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txsendnominal As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txatasnamarek As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txbankrek As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txnorek As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txnoinvoice As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents CheckAll As System.Windows.Forms.CheckBox
    Friend WithEvents butkalkulasi As System.Windows.Forms.Button
    Friend WithEvents txnolab As System.Windows.Forms.TextBox
    Friend WithEvents txbersangkutan As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbstatus As System.Windows.Forms.ComboBox
    Friend WithEvents cmbalasan As System.Windows.Forms.ComboBox
    Friend WithEvents butsearchrefund As System.Windows.Forms.Button
    Friend WithEvents txnorefund As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents dtrefund As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cbdeleterefund As System.Windows.Forms.CheckBox
    Friend WithEvents cbaccrefund As System.Windows.Forms.CheckBox
    Friend WithEvents CetakSuratRefundToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txnominalbayar As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lbllebihbayar As System.Windows.Forms.Label
    Friend WithEvents txnamakaryawan As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cbtransaksi As System.Windows.Forms.CheckBox
End Class
