<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCreateRefund
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCreateRefund))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.NewToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.groupcustomer = New System.Windows.Forms.GroupBox
        Me.cbtransaksi = New System.Windows.Forms.CheckBox
        Me.txnamakaryawan = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.txnorek2 = New System.Windows.Forms.TextBox
        Me.cbnominal = New System.Windows.Forms.CheckBox
        Me.txnominalbayar = New System.Windows.Forms.NumericUpDown
        Me.Label13 = New System.Windows.Forms.Label
        Me.cmbalasan = New System.Windows.Forms.ComboBox
        Me.cmbstatus = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txbersangkutan = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txnolab = New System.Windows.Forms.TextBox
        Me.CheckAll = New System.Windows.Forms.CheckBox
        Me.butkalkulasi = New System.Windows.Forms.Button
        Me.txnoinvoice = New System.Windows.Forms.TextBox
        Me.txnamealasan = New System.Windows.Forms.Label
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
        Me.buttambahpasien = New System.Windows.Forms.Button
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
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem1})
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
        'groupcustomer
        '
        Me.groupcustomer.Controls.Add(Me.cbtransaksi)
        Me.groupcustomer.Controls.Add(Me.txnamakaryawan)
        Me.groupcustomer.Controls.Add(Me.Label18)
        Me.groupcustomer.Controls.Add(Me.Label17)
        Me.groupcustomer.Controls.Add(Me.txnorek2)
        Me.groupcustomer.Controls.Add(Me.cbnominal)
        Me.groupcustomer.Controls.Add(Me.txnominalbayar)
        Me.groupcustomer.Controls.Add(Me.Label13)
        Me.groupcustomer.Controls.Add(Me.cmbalasan)
        Me.groupcustomer.Controls.Add(Me.cmbstatus)
        Me.groupcustomer.Controls.Add(Me.Label6)
        Me.groupcustomer.Controls.Add(Me.txbersangkutan)
        Me.groupcustomer.Controls.Add(Me.Label4)
        Me.groupcustomer.Controls.Add(Me.txnolab)
        Me.groupcustomer.Controls.Add(Me.CheckAll)
        Me.groupcustomer.Controls.Add(Me.butkalkulasi)
        Me.groupcustomer.Controls.Add(Me.txnoinvoice)
        Me.groupcustomer.Controls.Add(Me.txnamealasan)
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
        Me.groupcustomer.Controls.Add(Me.buttambahpasien)
        Me.groupcustomer.Dock = System.Windows.Forms.DockStyle.Top
        Me.groupcustomer.Location = New System.Drawing.Point(0, 24)
        Me.groupcustomer.Name = "groupcustomer"
        Me.groupcustomer.Size = New System.Drawing.Size(1200, 216)
        Me.groupcustomer.TabIndex = 10
        Me.groupcustomer.TabStop = False
        Me.groupcustomer.Text = "Tambah Data Pasien Refund"
        '
        'cbtransaksi
        '
        Me.cbtransaksi.AutoSize = True
        Me.cbtransaksi.Enabled = False
        Me.cbtransaksi.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbtransaksi.Location = New System.Drawing.Point(147, 48)
        Me.cbtransaksi.Name = "cbtransaksi"
        Me.cbtransaksi.Size = New System.Drawing.Size(81, 19)
        Me.cbtransaksi.TabIndex = 304
        Me.cbtransaksi.Text = "Transaksi"
        Me.cbtransaksi.UseVisualStyleBackColor = True
        '
        'txnamakaryawan
        '
        Me.txnamakaryawan.BackColor = System.Drawing.SystemColors.Window
        Me.txnamakaryawan.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txnamakaryawan.Location = New System.Drawing.Point(908, 95)
        Me.txnamakaryawan.Name = "txnamakaryawan"
        Me.txnamakaryawan.Size = New System.Drawing.Size(250, 21)
        Me.txnamakaryawan.TabIndex = 303
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(792, 98)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(103, 16)
        Me.Label18.TabIndex = 302
        Me.Label18.Text = "Nama Karyawan"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(949, 20)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(16, 22)
        Me.Label17.TabIndex = 301
        Me.Label17.Text = "-"
        '
        'txnorek2
        '
        Me.txnorek2.BackColor = System.Drawing.SystemColors.Window
        Me.txnorek2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txnorek2.Location = New System.Drawing.Point(965, 20)
        Me.txnorek2.MaxLength = 20
        Me.txnorek2.Name = "txnorek2"
        Me.txnorek2.Size = New System.Drawing.Size(193, 21)
        Me.txnorek2.TabIndex = 301
        '
        'cbnominal
        '
        Me.cbnominal.AutoSize = True
        Me.cbnominal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbnominal.Location = New System.Drawing.Point(262, 127)
        Me.cbnominal.Name = "cbnominal"
        Me.cbnominal.Size = New System.Drawing.Size(115, 19)
        Me.cbnominal.TabIndex = 299
        Me.cbnominal.Text = "Sesuai Nominal"
        Me.cbnominal.UseVisualStyleBackColor = True
        '
        'txnominalbayar
        '
        Me.txnominalbayar.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txnominalbayar.Location = New System.Drawing.Point(147, 126)
        Me.txnominalbayar.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.txnominalbayar.Name = "txnominalbayar"
        Me.txnominalbayar.Size = New System.Drawing.Size(110, 21)
        Me.txnominalbayar.TabIndex = 298
        Me.txnominalbayar.ThousandsSeparator = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(16, 129)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(119, 16)
        Me.Label13.TabIndex = 297
        Me.Label13.Text = "Nominal yg dibayar"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmbalasan
        '
        Me.cmbalasan.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.cmbalasan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbalasan.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbalasan.FormattingEnabled = True
        Me.cmbalasan.Items.AddRange(New Object() {"Tidak Jadi Datang ke Klinik", "Hasil Tidak Selesai Tepat Waktu", "Gagal Dalam Pengambilan Sampel", "Kehabisan Stok", "Kelebihan Bayar"})
        Me.cmbalasan.Location = New System.Drawing.Point(147, 20)
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
        Me.cmbstatus.Location = New System.Drawing.Point(147, 95)
        Me.cmbstatus.Name = "cmbstatus"
        Me.cmbstatus.Size = New System.Drawing.Size(250, 23)
        Me.cmbstatus.TabIndex = 294
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(23, 98)
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
        Me.txbersangkutan.Location = New System.Drawing.Point(147, 155)
        Me.txbersangkutan.Name = "txbersangkutan"
        Me.txbersangkutan.Size = New System.Drawing.Size(250, 21)
        Me.txbersangkutan.TabIndex = 292
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(48, 157)
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
        Me.txnolab.Location = New System.Drawing.Point(613, 155)
        Me.txnolab.Name = "txnolab"
        Me.txnolab.Size = New System.Drawing.Size(117, 21)
        Me.txnolab.TabIndex = 290
        Me.txnolab.Visible = False
        '
        'CheckAll
        '
        Me.CheckAll.AutoSize = True
        Me.CheckAll.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckAll.Location = New System.Drawing.Point(745, 180)
        Me.CheckAll.Name = "CheckAll"
        Me.CheckAll.Size = New System.Drawing.Size(97, 20)
        Me.CheckAll.TabIndex = 289
        Me.CheckAll.Text = "Pilih Semua"
        Me.CheckAll.UseVisualStyleBackColor = True
        '
        'butkalkulasi
        '
        Me.butkalkulasi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.butkalkulasi.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butkalkulasi.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_kalkulasi
        Me.butkalkulasi.Location = New System.Drawing.Point(848, 171)
        Me.butkalkulasi.Name = "butkalkulasi"
        Me.butkalkulasi.Size = New System.Drawing.Size(100, 36)
        Me.butkalkulasi.TabIndex = 288
        Me.butkalkulasi.UseVisualStyleBackColor = True
        '
        'txnoinvoice
        '
        Me.txnoinvoice.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txnoinvoice.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.txnoinvoice.Location = New System.Drawing.Point(480, 45)
        Me.txnoinvoice.Multiline = True
        Me.txnoinvoice.Name = "txnoinvoice"
        Me.txnoinvoice.ReadOnly = True
        Me.txnoinvoice.Size = New System.Drawing.Size(250, 131)
        Me.txnoinvoice.TabIndex = 287
        '
        'txnamealasan
        '
        Me.txnamealasan.AutoSize = True
        Me.txnamealasan.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txnamealasan.Location = New System.Drawing.Point(401, 45)
        Me.txnamealasan.Name = "txnamealasan"
        Me.txnamealasan.Size = New System.Drawing.Size(67, 16)
        Me.txnamealasan.TabIndex = 286
        Me.txnamealasan.Text = "No Invoice"
        Me.txnamealasan.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txatasnamarek
        '
        Me.txatasnamarek.BackColor = System.Drawing.SystemColors.Window
        Me.txatasnamarek.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txatasnamarek.Location = New System.Drawing.Point(908, 70)
        Me.txatasnamarek.Name = "txatasnamarek"
        Me.txatasnamarek.Size = New System.Drawing.Size(250, 21)
        Me.txatasnamarek.TabIndex = 285
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(795, 73)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 16)
        Me.Label15.TabIndex = 284
        Me.Label15.Text = "Atas Nama Rek"
        '
        'txbankrek
        '
        Me.txbankrek.BackColor = System.Drawing.SystemColors.Window
        Me.txbankrek.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txbankrek.Location = New System.Drawing.Point(908, 45)
        Me.txbankrek.Name = "txbankrek"
        Me.txbankrek.Size = New System.Drawing.Size(250, 21)
        Me.txbankrek.TabIndex = 283
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(792, 48)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(103, 16)
        Me.Label12.TabIndex = 282
        Me.Label12.Text = "Nama Bank Rek"
        '
        'txnorek
        '
        Me.txnorek.BackColor = System.Drawing.SystemColors.Window
        Me.txnorek.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txnorek.Location = New System.Drawing.Point(908, 20)
        Me.txnorek.MaxLength = 3
        Me.txnorek.Name = "txnorek"
        Me.txnorek.Size = New System.Drawing.Size(40, 21)
        Me.txnorek.TabIndex = 300
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(840, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 16)
        Me.Label7.TabIndex = 280
        Me.Label7.Text = "No. Rek"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(412, 23)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(56, 16)
        Me.Label14.TabIndex = 279
        Me.Label14.Text = "Tgl Awal"
        '
        'txsendnominal
        '
        Me.txsendnominal.BackColor = System.Drawing.SystemColors.Window
        Me.txsendnominal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txsendnominal.Location = New System.Drawing.Point(480, 180)
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
        Me.dttglakhir.Location = New System.Drawing.Point(642, 20)
        Me.dttglakhir.Name = "dttglakhir"
        Me.dttglakhir.Size = New System.Drawing.Size(88, 20)
        Me.dttglakhir.TabIndex = 272
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(578, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(58, 16)
        Me.Label11.TabIndex = 271
        Me.Label11.Text = "Tgl Akhir"
        '
        'dttglawal
        '
        Me.dttglawal.CustomFormat = "dd-MMM-yyyy"
        Me.dttglawal.Enabled = False
        Me.dttglawal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dttglawal.Location = New System.Drawing.Point(480, 20)
        Me.dttglawal.Name = "dttglawal"
        Me.dttglawal.Size = New System.Drawing.Size(88, 20)
        Me.dttglawal.TabIndex = 270
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(416, 58)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(0, 16)
        Me.Label10.TabIndex = 269
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(409, 175)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 32)
        Me.Label1.TabIndex = 262
        Me.Label1.Text = "Nominal " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Invoice"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txnominal
        '
        Me.txnominal.BackColor = System.Drawing.SystemColors.Window
        Me.txnominal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txnominal.Location = New System.Drawing.Point(480, 180)
        Me.txnominal.Name = "txnominal"
        Me.txnominal.ReadOnly = True
        Me.txnominal.Size = New System.Drawing.Size(250, 21)
        Me.txnominal.TabIndex = 261
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(87, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 16)
        Me.Label3.TabIndex = 258
        Me.Label3.Text = "Alasan"
        '
        'txtelp
        '
        Me.txtelp.BackColor = System.Drawing.SystemColors.Window
        Me.txtelp.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtelp.Location = New System.Drawing.Point(147, 180)
        Me.txtelp.Name = "txtelp"
        Me.txtelp.Size = New System.Drawing.Size(250, 21)
        Me.txtelp.TabIndex = 257
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(65, 183)
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
        Me.butsaved.Location = New System.Drawing.Point(1058, 171)
        Me.butsaved.Name = "butsaved"
        Me.butsaved.Size = New System.Drawing.Size(100, 36)
        Me.butsaved.TabIndex = 246
        Me.butsaved.UseVisualStyleBackColor = True
        '
        'dtprocessend
        '
        Me.dtprocessend.CustomFormat = "dd-MMM-yyyy"
        Me.dtprocessend.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtprocessend.Location = New System.Drawing.Point(287, 70)
        Me.dtprocessend.Name = "dtprocessend"
        Me.dtprocessend.Size = New System.Drawing.Size(110, 20)
        Me.dtprocessend.TabIndex = 243
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(259, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(26, 16)
        Me.Label5.TabIndex = 242
        Me.Label5.Text = "s/d"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(50, 73)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 16)
        Me.Label9.TabIndex = 241
        Me.Label9.Text = "Tgl Transaksi"
        '
        'dtprocess
        '
        Me.dtprocess.CustomFormat = "dd-MMM-yyyy"
        Me.dtprocess.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtprocess.Location = New System.Drawing.Point(147, 70)
        Me.dtprocess.Name = "dtprocess"
        Me.dtprocess.Size = New System.Drawing.Size(110, 20)
        Me.dtprocess.TabIndex = 237
        '
        'buttambahpasien
        '
        Me.buttambahpasien.Cursor = System.Windows.Forms.Cursors.Hand
        Me.buttambahpasien.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.buttambahpasien.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_add
        Me.buttambahpasien.Location = New System.Drawing.Point(953, 171)
        Me.buttambahpasien.Name = "buttambahpasien"
        Me.buttambahpasien.Size = New System.Drawing.Size(100, 36)
        Me.buttambahpasien.TabIndex = 234
        Me.buttambahpasien.UseVisualStyleBackColor = True
        '
        'gridrefund
        '
        Me.gridrefund.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridrefund.EmbeddedNavigator.Name = ""
        Me.gridrefund.Location = New System.Drawing.Point(0, 240)
        Me.gridrefund.MainView = Me.GridView1
        Me.gridrefund.Name = "gridrefund"
        Me.gridrefund.Size = New System.Drawing.Size(1200, 300)
        Me.gridrefund.TabIndex = 11
        Me.gridrefund.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.gridrefund
        Me.GridView1.GroupPanelText = "Data Pasien Refund"
        Me.GridView1.Name = "GridView1"
        '
        'FormCreateRefund
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1200, 540)
        Me.Controls.Add(Me.gridrefund)
        Me.Controls.Add(Me.groupcustomer)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormCreateRefund"
        Me.Text = "Form Refund"
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
    Friend WithEvents buttambahpasien As System.Windows.Forms.Button
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
    Friend WithEvents txnamealasan As System.Windows.Forms.Label
    Friend WithEvents CheckAll As System.Windows.Forms.CheckBox
    Friend WithEvents butkalkulasi As System.Windows.Forms.Button
    Friend WithEvents txnolab As System.Windows.Forms.TextBox
    Friend WithEvents txbersangkutan As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbstatus As System.Windows.Forms.ComboBox
    Friend WithEvents cmbalasan As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txnominalbayar As System.Windows.Forms.NumericUpDown
    Friend WithEvents cbnominal As System.Windows.Forms.CheckBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txnorek2 As System.Windows.Forms.TextBox
    Friend WithEvents txnamakaryawan As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cbtransaksi As System.Windows.Forms.CheckBox
End Class
