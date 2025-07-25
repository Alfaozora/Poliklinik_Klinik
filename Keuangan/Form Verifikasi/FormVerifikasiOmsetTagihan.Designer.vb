<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormVerifikasiOmsetTagihan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormVerifikasiOmsetTagihan))
        Me.ButtonFindInvoiceTagihan = New System.Windows.Forms.Button
        Me.TextBoxBankTransferCoa = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TextBoxBankTransferKeterangan = New System.Windows.Forms.TextBox
        Me.ButtonFindBankTagihan = New System.Windows.Forms.Button
        Me.CheckBoxSesuaiNominalTagihan = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBoxDetailTambahanKeterangan = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.TextBoxDetailTambahanNominal = New System.Windows.Forms.NumericUpDown
        Me.Label11 = New System.Windows.Forms.Label
        Me.TextBoxKeteranganPembayaran = New System.Windows.Forms.TextBox
        Me.lblbanknorecord = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TglTransferPembayaran = New System.Windows.Forms.DateTimePicker
        Me.Label14 = New System.Windows.Forms.Label
        Me.TextBoxNamaPerusahaanInvoice = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.DataGridViewDetailCOA = New System.Windows.Forms.DataGridView
        Me.ClearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.ButtonFindCoa = New System.Windows.Forms.Button
        Me.TextBoxDetailTambahanCoa = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.TextBoxNomorInvoice = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.TglJatuhTempoInvoice = New System.Windows.Forms.DateTimePicker
        Me.TglInvoice = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.ButtonSimpanDetailPembayaran = New System.Windows.Forms.Button
        Me.ButtonClear = New System.Windows.Forms.Button
        Me.SplitContainerDetailTagihan = New System.Windows.Forms.SplitContainer
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.SplitContainerDetailCOA = New System.Windows.Forms.SplitContainer
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.ButtonSimpanDetailCoa = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.TextBoxNominalInvoice = New PoliKlinik_Net2.NumericUpDownWithThousands
        Me.TextBoxTotalBayar = New PoliKlinik_Net2.NumericUpDownWithThousands
        CType(Me.TextBoxDetailTambahanNominal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridViewDetailCOA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerDetailTagihan.Panel1.SuspendLayout()
        Me.SplitContainerDetailTagihan.Panel2.SuspendLayout()
        Me.SplitContainerDetailTagihan.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SplitContainerDetailCOA.Panel1.SuspendLayout()
        Me.SplitContainerDetailCOA.Panel2.SuspendLayout()
        Me.SplitContainerDetailCOA.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.TextBoxNominalInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxTotalBayar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ButtonFindInvoiceTagihan
        '
        Me.ButtonFindInvoiceTagihan.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindInvoiceTagihan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonFindInvoiceTagihan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonFindInvoiceTagihan.FlatAppearance.BorderSize = 0
        Me.ButtonFindInvoiceTagihan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindInvoiceTagihan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonFindInvoiceTagihan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonFindInvoiceTagihan.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonFindInvoiceTagihan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ButtonFindInvoiceTagihan.Location = New System.Drawing.Point(13, 9)
        Me.ButtonFindInvoiceTagihan.Name = "ButtonFindInvoiceTagihan"
        Me.ButtonFindInvoiceTagihan.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonFindInvoiceTagihan.Size = New System.Drawing.Size(150, 25)
        Me.ButtonFindInvoiceTagihan.TabIndex = 582
        Me.ButtonFindInvoiceTagihan.Text = " Cari Invoice Tagihan"
        Me.ButtonFindInvoiceTagihan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonFindInvoiceTagihan.UseVisualStyleBackColor = False
        '
        'TextBoxBankTransferCoa
        '
        Me.TextBoxBankTransferCoa.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.TextBoxBankTransferCoa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxBankTransferCoa.Cursor = System.Windows.Forms.Cursors.No
        Me.TextBoxBankTransferCoa.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TextBoxBankTransferCoa.Location = New System.Drawing.Point(189, 274)
        Me.TextBoxBankTransferCoa.Name = "TextBoxBankTransferCoa"
        Me.TextBoxBankTransferCoa.ReadOnly = True
        Me.TextBoxBankTransferCoa.Size = New System.Drawing.Size(84, 23)
        Me.TextBoxBankTransferCoa.TabIndex = 581
        Me.TextBoxBankTransferCoa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(12, 274)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 17)
        Me.Label7.TabIndex = 580
        Me.Label7.Text = "Bank Transfer"
        '
        'TextBoxBankTransferKeterangan
        '
        Me.TextBoxBankTransferKeterangan.BackColor = System.Drawing.Color.White
        Me.TextBoxBankTransferKeterangan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxBankTransferKeterangan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBoxBankTransferKeterangan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TextBoxBankTransferKeterangan.Location = New System.Drawing.Point(123, 303)
        Me.TextBoxBankTransferKeterangan.Name = "TextBoxBankTransferKeterangan"
        Me.TextBoxBankTransferKeterangan.ReadOnly = True
        Me.TextBoxBankTransferKeterangan.Size = New System.Drawing.Size(408, 23)
        Me.TextBoxBankTransferKeterangan.TabIndex = 579
        '
        'ButtonFindBankTagihan
        '
        Me.ButtonFindBankTagihan.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindBankTagihan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonFindBankTagihan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonFindBankTagihan.FlatAppearance.BorderSize = 0
        Me.ButtonFindBankTagihan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindBankTagihan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonFindBankTagihan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonFindBankTagihan.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonFindBankTagihan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ButtonFindBankTagihan.Location = New System.Drawing.Point(123, 272)
        Me.ButtonFindBankTagihan.Name = "ButtonFindBankTagihan"
        Me.ButtonFindBankTagihan.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonFindBankTagihan.Size = New System.Drawing.Size(60, 25)
        Me.ButtonFindBankTagihan.TabIndex = 578
        Me.ButtonFindBankTagihan.Text = " Cari"
        Me.ButtonFindBankTagihan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonFindBankTagihan.UseVisualStyleBackColor = False
        '
        'CheckBoxSesuaiNominalTagihan
        '
        Me.CheckBoxSesuaiNominalTagihan.AutoSize = True
        Me.CheckBoxSesuaiNominalTagihan.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.CheckBoxSesuaiNominalTagihan.Location = New System.Drawing.Point(123, 248)
        Me.CheckBoxSesuaiNominalTagihan.Name = "CheckBoxSesuaiNominalTagihan"
        Me.CheckBoxSesuaiNominalTagihan.Size = New System.Drawing.Size(166, 21)
        Me.CheckBoxSesuaiNominalTagihan.TabIndex = 198
        Me.CheckBoxSesuaiNominalTagihan.Text = "Sesuai Nominal Tagihan"
        Me.CheckBoxSesuaiNominalTagihan.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(13, 99)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 17)
        Me.Label1.TabIndex = 204
        Me.Label1.Text = "Keterangan"
        '
        'TextBoxDetailTambahanKeterangan
        '
        Me.TextBoxDetailTambahanKeterangan.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBoxDetailTambahanKeterangan.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxDetailTambahanKeterangan.Location = New System.Drawing.Point(126, 96)
        Me.TextBoxDetailTambahanKeterangan.Name = "TextBoxDetailTambahanKeterangan"
        Me.TextBoxDetailTambahanKeterangan.ReadOnly = True
        Me.TextBoxDetailTambahanKeterangan.Size = New System.Drawing.Size(242, 25)
        Me.TextBoxDetailTambahanKeterangan.TabIndex = 198
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label13.Location = New System.Drawing.Point(13, 68)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(70, 17)
        Me.Label13.TabIndex = 197
        Me.Label13.Text = "Kode COA"
        '
        'TextBoxDetailTambahanNominal
        '
        Me.TextBoxDetailTambahanNominal.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxDetailTambahanNominal.Location = New System.Drawing.Point(126, 127)
        Me.TextBoxDetailTambahanNominal.Maximum = New Decimal(New Integer() {1215752191, 23, 0, 0})
        Me.TextBoxDetailTambahanNominal.Name = "TextBoxDetailTambahanNominal"
        Me.TextBoxDetailTambahanNominal.Size = New System.Drawing.Size(150, 25)
        Me.TextBoxDetailTambahanNominal.TabIndex = 193
        Me.TextBoxDetailTambahanNominal.ThousandsSeparator = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(15, 129)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(59, 17)
        Me.Label11.TabIndex = 132
        Me.Label11.Text = "Nominal"
        '
        'TextBoxKeteranganPembayaran
        '
        Me.TextBoxKeteranganPembayaran.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBoxKeteranganPembayaran.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxKeteranganPembayaran.Location = New System.Drawing.Point(123, 332)
        Me.TextBoxKeteranganPembayaran.Name = "TextBoxKeteranganPembayaran"
        Me.TextBoxKeteranganPembayaran.Size = New System.Drawing.Size(408, 25)
        Me.TextBoxKeteranganPembayaran.TabIndex = 191
        '
        'lblbanknorecord
        '
        Me.lblbanknorecord.AutoSize = True
        Me.lblbanknorecord.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.lblbanknorecord.Location = New System.Drawing.Point(12, 335)
        Me.lblbanknorecord.Name = "lblbanknorecord"
        Me.lblbanknorecord.Size = New System.Drawing.Size(78, 17)
        Me.lblbanknorecord.TabIndex = 155
        Me.lblbanknorecord.Text = "Keterangan"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(281, 219)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(77, 17)
        Me.Label4.TabIndex = 153
        Me.Label4.Text = "Tgl Transfer"
        '
        'TglTransferPembayaran
        '
        Me.TglTransferPembayaran.CustomFormat = "dd-MMM-yyyy"
        Me.TglTransferPembayaran.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TglTransferPembayaran.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TglTransferPembayaran.Location = New System.Drawing.Point(381, 217)
        Me.TglTransferPembayaran.Name = "TglTransferPembayaran"
        Me.TglTransferPembayaran.Size = New System.Drawing.Size(150, 25)
        Me.TglTransferPembayaran.TabIndex = 150
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label14.Location = New System.Drawing.Point(12, 219)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(75, 17)
        Me.Label14.TabIndex = 132
        Me.Label14.Text = "Total Bayar"
        '
        'TextBoxNamaPerusahaanInvoice
        '
        Me.TextBoxNamaPerusahaanInvoice.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBoxNamaPerusahaanInvoice.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxNamaPerusahaanInvoice.Location = New System.Drawing.Point(12, 92)
        Me.TextBoxNamaPerusahaanInvoice.Name = "TextBoxNamaPerusahaanInvoice"
        Me.TextBoxNamaPerusahaanInvoice.ReadOnly = True
        Me.TextBoxNamaPerusahaanInvoice.Size = New System.Drawing.Size(306, 25)
        Me.TextBoxNamaPerusahaanInvoice.TabIndex = 141
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(12, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 17)
        Me.Label2.TabIndex = 140
        Me.Label2.Text = "Nama Perusahaan"
        '
        'DataGridViewDetailCOA
        '
        Me.DataGridViewDetailCOA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewDetailCOA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewDetailCOA.Location = New System.Drawing.Point(0, 0)
        Me.DataGridViewDetailCOA.Name = "DataGridViewDetailCOA"
        Me.DataGridViewDetailCOA.Size = New System.Drawing.Size(380, 208)
        Me.DataGridViewDetailCOA.TabIndex = 201
        '
        'ClearToolStripMenuItem
        '
        Me.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem"
        Me.ClearToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.ClearToolStripMenuItem.Text = "Clear"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(934, 24)
        Me.MenuStrip1.TabIndex = 197
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ButtonFindCoa
        '
        Me.ButtonFindCoa.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindCoa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonFindCoa.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonFindCoa.FlatAppearance.BorderSize = 0
        Me.ButtonFindCoa.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindCoa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonFindCoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonFindCoa.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonFindCoa.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ButtonFindCoa.Location = New System.Drawing.Point(126, 65)
        Me.ButtonFindCoa.Name = "ButtonFindCoa"
        Me.ButtonFindCoa.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonFindCoa.Size = New System.Drawing.Size(60, 25)
        Me.ButtonFindCoa.TabIndex = 583
        Me.ButtonFindCoa.Text = " Cari"
        Me.ButtonFindCoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonFindCoa.UseVisualStyleBackColor = False
        '
        'TextBoxDetailTambahanCoa
        '
        Me.TextBoxDetailTambahanCoa.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.TextBoxDetailTambahanCoa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxDetailTambahanCoa.Cursor = System.Windows.Forms.Cursors.No
        Me.TextBoxDetailTambahanCoa.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TextBoxDetailTambahanCoa.Location = New System.Drawing.Point(192, 67)
        Me.TextBoxDetailTambahanCoa.Name = "TextBoxDetailTambahanCoa"
        Me.TextBoxDetailTambahanCoa.ReadOnly = True
        Me.TextBoxDetailTambahanCoa.Size = New System.Drawing.Size(84, 23)
        Me.TextBoxDetailTambahanCoa.TabIndex = 583
        Me.TextBoxDetailTambahanCoa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label20.Location = New System.Drawing.Point(324, 72)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(73, 17)
        Me.Label20.TabIndex = 584
        Me.Label20.Text = "No Invoice"
        '
        'TextBoxNomorInvoice
        '
        Me.TextBoxNomorInvoice.BackColor = System.Drawing.Color.White
        Me.TextBoxNomorInvoice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxNomorInvoice.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TextBoxNomorInvoice.Location = New System.Drawing.Point(324, 92)
        Me.TextBoxNomorInvoice.Name = "TextBoxNomorInvoice"
        Me.TextBoxNomorInvoice.ReadOnly = True
        Me.TextBoxNomorInvoice.Size = New System.Drawing.Size(150, 23)
        Me.TextBoxNomorInvoice.TabIndex = 583
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label15.Location = New System.Drawing.Point(168, 123)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(72, 17)
        Me.Label15.TabIndex = 590
        Me.Label15.Text = "Tgl Invoice"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label16.Location = New System.Drawing.Point(324, 123)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(107, 17)
        Me.Label16.TabIndex = 589
        Me.Label16.Text = "Tgl Jatuh Tempo"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label17.Location = New System.Drawing.Point(12, 123)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(88, 17)
        Me.Label17.TabIndex = 588
        Me.Label17.Text = "Total Tagihan"
        '
        'TglJatuhTempoInvoice
        '
        Me.TglJatuhTempoInvoice.CalendarFont = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TglJatuhTempoInvoice.CustomFormat = "dd-MMM-yyyy"
        Me.TglJatuhTempoInvoice.Enabled = False
        Me.TglJatuhTempoInvoice.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TglJatuhTempoInvoice.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TglJatuhTempoInvoice.Location = New System.Drawing.Point(324, 143)
        Me.TglJatuhTempoInvoice.Name = "TglJatuhTempoInvoice"
        Me.TglJatuhTempoInvoice.Size = New System.Drawing.Size(150, 25)
        Me.TglJatuhTempoInvoice.TabIndex = 587
        '
        'TglInvoice
        '
        Me.TglInvoice.CalendarFont = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TglInvoice.CustomFormat = "dd-MMM-yyyy"
        Me.TglInvoice.Enabled = False
        Me.TglInvoice.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TglInvoice.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TglInvoice.Location = New System.Drawing.Point(168, 143)
        Me.TglInvoice.Name = "TglInvoice"
        Me.TglInvoice.Size = New System.Drawing.Size(150, 25)
        Me.TglInvoice.TabIndex = 586
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(137, 25)
        Me.Label5.TabIndex = 591
        Me.Label5.Text = "Detail Tagihan"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 185)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(178, 25)
        Me.Label6.TabIndex = 592
        Me.Label6.Text = "Detail Pembayaran"
        '
        'ButtonSimpanDetailPembayaran
        '
        Me.ButtonSimpanDetailPembayaran.BackColor = System.Drawing.Color.White
        Me.ButtonSimpanDetailPembayaran.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonSimpanDetailPembayaran.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonSimpanDetailPembayaran.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSimpanDetailPembayaran.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSimpanDetailPembayaran.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonSimpanDetailPembayaran.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSimpanDetailPembayaran.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ButtonSimpanDetailPembayaran.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSimpanDetailPembayaran.Location = New System.Drawing.Point(324, 363)
        Me.ButtonSimpanDetailPembayaran.Name = "ButtonSimpanDetailPembayaran"
        Me.ButtonSimpanDetailPembayaran.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonSimpanDetailPembayaran.Size = New System.Drawing.Size(207, 25)
        Me.ButtonSimpanDetailPembayaran.TabIndex = 593
        Me.ButtonSimpanDetailPembayaran.Text = " Simpan Detail Pembayaran"
        Me.ButtonSimpanDetailPembayaran.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonSimpanDetailPembayaran.UseVisualStyleBackColor = False
        '
        'ButtonClear
        '
        Me.ButtonClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonClear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonClear.FlatAppearance.BorderSize = 0
        Me.ButtonClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonClear.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonClear.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ButtonClear.Location = New System.Drawing.Point(169, 9)
        Me.ButtonClear.Name = "ButtonClear"
        Me.ButtonClear.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonClear.Size = New System.Drawing.Size(150, 25)
        Me.ButtonClear.TabIndex = 594
        Me.ButtonClear.Text = "Clear Data"
        Me.ButtonClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonClear.UseVisualStyleBackColor = False
        '
        'SplitContainerDetailTagihan
        '
        Me.SplitContainerDetailTagihan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerDetailTagihan.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainerDetailTagihan.Name = "SplitContainerDetailTagihan"
        '
        'SplitContainerDetailTagihan.Panel1
        '
        Me.SplitContainerDetailTagihan.Panel1.BackColor = System.Drawing.Color.White
        Me.SplitContainerDetailTagihan.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainerDetailTagihan.Panel2
        '
        Me.SplitContainerDetailTagihan.Panel2.Controls.Add(Me.SplitContainerDetailCOA)
        Me.SplitContainerDetailTagihan.Size = New System.Drawing.Size(934, 412)
        Me.SplitContainerDetailTagihan.SplitterDistance = 550
        Me.SplitContainerDetailTagihan.TabIndex = 198
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.TextBoxNominalInvoice)
        Me.Panel1.Controls.Add(Me.TextBoxTotalBayar)
        Me.Panel1.Controls.Add(Me.ButtonSimpanDetailPembayaran)
        Me.Panel1.Controls.Add(Me.ButtonClear)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.ButtonFindInvoiceTagihan)
        Me.Panel1.Controls.Add(Me.TextBoxBankTransferCoa)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.TextBoxNamaPerusahaanInvoice)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.TextBoxNomorInvoice)
        Me.Panel1.Controls.Add(Me.TextBoxBankTransferKeterangan)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.ButtonFindBankTagihan)
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.CheckBoxSesuaiNominalTagihan)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.TextBoxKeteranganPembayaran)
        Me.Panel1.Controls.Add(Me.TglInvoice)
        Me.Panel1.Controls.Add(Me.lblbanknorecord)
        Me.Panel1.Controls.Add(Me.TglJatuhTempoInvoice)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.TglTransferPembayaran)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(550, 412)
        Me.Panel1.TabIndex = 149
        '
        'SplitContainerDetailCOA
        '
        Me.SplitContainerDetailCOA.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerDetailCOA.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerDetailCOA.Name = "SplitContainerDetailCOA"
        Me.SplitContainerDetailCOA.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerDetailCOA.Panel1
        '
        Me.SplitContainerDetailCOA.Panel1.BackColor = System.Drawing.Color.White
        Me.SplitContainerDetailCOA.Panel1.Controls.Add(Me.Panel2)
        '
        'SplitContainerDetailCOA.Panel2
        '
        Me.SplitContainerDetailCOA.Panel2.BackColor = System.Drawing.Color.White
        Me.SplitContainerDetailCOA.Panel2.Controls.Add(Me.DataGridViewDetailCOA)
        Me.SplitContainerDetailCOA.Size = New System.Drawing.Size(380, 412)
        Me.SplitContainerDetailCOA.SplitterDistance = 200
        Me.SplitContainerDetailCOA.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.ButtonSimpanDetailCoa)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.TextBoxDetailTambahanCoa)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.TextBoxDetailTambahanNominal)
        Me.Panel2.Controls.Add(Me.ButtonFindCoa)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.TextBoxDetailTambahanKeterangan)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(380, 200)
        Me.Panel2.TabIndex = 0
        '
        'ButtonSimpanDetailCoa
        '
        Me.ButtonSimpanDetailCoa.BackColor = System.Drawing.Color.White
        Me.ButtonSimpanDetailCoa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonSimpanDetailCoa.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonSimpanDetailCoa.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSimpanDetailCoa.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSimpanDetailCoa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonSimpanDetailCoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSimpanDetailCoa.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ButtonSimpanDetailCoa.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSimpanDetailCoa.Location = New System.Drawing.Point(126, 158)
        Me.ButtonSimpanDetailCoa.Name = "ButtonSimpanDetailCoa"
        Me.ButtonSimpanDetailCoa.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonSimpanDetailCoa.Size = New System.Drawing.Size(150, 25)
        Me.ButtonSimpanDetailCoa.TabIndex = 594
        Me.ButtonSimpanDetailCoa.Text = " Simpan Detail COA"
        Me.ButtonSimpanDetailCoa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonSimpanDetailCoa.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(13, 37)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(203, 25)
        Me.Label8.TabIndex = 592
        Me.Label8.Text = "Detail COA Tambahan"
        '
        'TextBoxNominalInvoice
        '
        Me.TextBoxNominalInvoice.BackColor = System.Drawing.Color.White
        Me.TextBoxNominalInvoice.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxNominalInvoice.Location = New System.Drawing.Point(12, 143)
        Me.TextBoxNominalInvoice.Maximum = New Decimal(New Integer() {1000000000, 0, 0, 0})
        Me.TextBoxNominalInvoice.Name = "TextBoxNominalInvoice"
        Me.TextBoxNominalInvoice.ReadOnly = True
        Me.TextBoxNominalInvoice.Size = New System.Drawing.Size(150, 25)
        Me.TextBoxNominalInvoice.TabIndex = 596
        '
        'TextBoxTotalBayar
        '
        Me.TextBoxTotalBayar.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxTotalBayar.Location = New System.Drawing.Point(123, 217)
        Me.TextBoxTotalBayar.Maximum = New Decimal(New Integer() {1000000000, 0, 0, 0})
        Me.TextBoxTotalBayar.Name = "TextBoxTotalBayar"
        Me.TextBoxTotalBayar.Size = New System.Drawing.Size(150, 25)
        Me.TextBoxTotalBayar.TabIndex = 595
        '
        'FormVerifikasiOmsetTagihan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(934, 436)
        Me.Controls.Add(Me.SplitContainerDetailTagihan)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(950, 475)
        Me.MinimumSize = New System.Drawing.Size(950, 475)
        Me.Name = "FormVerifikasiOmsetTagihan"
        Me.Text = "Pembayaran Tagihan"
        CType(Me.TextBoxDetailTambahanNominal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridViewDetailCOA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainerDetailTagihan.Panel1.ResumeLayout(False)
        Me.SplitContainerDetailTagihan.Panel2.ResumeLayout(False)
        Me.SplitContainerDetailTagihan.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.SplitContainerDetailCOA.Panel1.ResumeLayout(False)
        Me.SplitContainerDetailCOA.Panel2.ResumeLayout(False)
        Me.SplitContainerDetailCOA.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.TextBoxNominalInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxTotalBayar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    'Friend WithEvents txbanknama As DevExpress.XtraEditors.TextEdit
    'Friend WithEvents butpelunasanid As DevExpress.XtraEditors.ButtonEdit
    'Friend WithEvents butcomp As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNamaPerusahaanInvoice As System.Windows.Forms.TextBox
    'Friend WithEvents txtotalbayar As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ClearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents txbankrek As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TglTransferPembayaran As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblbanknorecord As System.Windows.Forms.Label
    'Friend WithEvents txbankid As DevExpress.XtraEditors.TextEdit
    'Friend WithEvents txbankcab As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextBoxKeteranganPembayaran As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxDetailTambahanNominal As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextBoxDetailTambahanKeterangan As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewDetailCOA As System.Windows.Forms.DataGridView
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents CheckBoxSesuaiNominalTagihan As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxBankTransferCoa As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBoxBankTransferKeterangan As System.Windows.Forms.TextBox
    Friend WithEvents ButtonFindBankTagihan As System.Windows.Forms.Button
    Friend WithEvents ButtonFindInvoiceTagihan As System.Windows.Forms.Button
    Friend WithEvents ButtonFindCoa As System.Windows.Forms.Button
    Friend WithEvents TextBoxDetailTambahanCoa As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNomorInvoice As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TglJatuhTempoInvoice As System.Windows.Forms.DateTimePicker
    Friend WithEvents TglInvoice As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ButtonSimpanDetailPembayaran As System.Windows.Forms.Button
    Friend WithEvents ButtonClear As System.Windows.Forms.Button
    Friend WithEvents SplitContainerDetailTagihan As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents SplitContainerDetailCOA As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ButtonSimpanDetailCoa As System.Windows.Forms.Button
    Friend WithEvents TextBoxTotalBayar As PoliKlinik_Net2.NumericUpDownWithThousands
    Friend WithEvents TextBoxNominalInvoice As PoliKlinik_Net2.NumericUpDownWithThousands
    'Friend WithEvents txbanknorecord As DevExpress.XtraEditors.TextEdit
End Class
