<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPembayaran
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPembayaran))
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.ComboBoxJenisBayar = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GridControlPembayaran = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.Label7 = New System.Windows.Forms.Label
        Me.txbayarfromQRcode = New System.Windows.Forms.TextBox
        Me.CheckBoxNominalTagihan = New System.Windows.Forms.CheckBox
        Me.ComboBoxJenisEDC = New System.Windows.Forms.ComboBox
        Me.txnokartupembayaran = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.ComboBoxJenisBank = New System.Windows.Forms.ComboBox
        Me.butcompany = New System.Windows.Forms.Button
        Me.ButtonClear = New System.Windows.Forms.Button
        Me.TextBoxNoKartu = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.ButtonTambah = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.PanelTop = New System.Windows.Forms.Panel
        Me.ButtonCancel = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TextBoxJumlahBayar = New PoliKlinik_Net2.NumericUpDownWithThousands
        Me.TextBoxNomorRM = New System.Windows.Forms.TextBox
        Me.TextBoxNama = New System.Windows.Forms.TextBox
        Me.TextBoxTotalTagihan = New PoliKlinik_Net2.NumericUpDownWithThousands
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.CheckBoxLunasBayar = New System.Windows.Forms.CheckBox
        Me.TextBoxTotalKembali = New PoliKlinik_Net2.NumericUpDownWithThousands
        Me.TextBoxTotalBayar = New PoliKlinik_Net2.NumericUpDownWithThousands
        Me.Label8 = New System.Windows.Forms.Label
        Me.ButtonSimpan = New System.Windows.Forms.Button
        Me.ButtonCetakInvoice = New System.Windows.Forms.Button
        Me.ButtonExportInvoice = New System.Windows.Forms.Button
        Me.ButtonWhatsAppInvoice = New System.Windows.Forms.Button
        CType(Me.GridControlPembayaran, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelTop.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.TextBoxJumlahBayar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxTotalTagihan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.TextBoxTotalKembali, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxTotalBayar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label14.Location = New System.Drawing.Point(30, 15)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 17)
        Me.Label14.TabIndex = 132
        Me.Label14.Text = "Total Tagihan"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(30, 80)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(75, 17)
        Me.Label12.TabIndex = 131
        Me.Label12.Text = "Jenis Bayar"
        '
        'ComboBoxJenisBayar
        '
        Me.ComboBoxJenisBayar.AutoCompleteCustomSource.AddRange(New String() {"TUNAI", "CARD", "DEBET", "DISC", "TAGIHAN"})
        Me.ComboBoxJenisBayar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxJenisBayar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxJenisBayar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxJenisBayar.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBoxJenisBayar.FormattingEnabled = True
        Me.ComboBoxJenisBayar.Items.AddRange(New Object() {"TUNAI", "CARD", "DEBET", "DISC", "TAGIHAN"})
        Me.ComboBoxJenisBayar.Location = New System.Drawing.Point(145, 77)
        Me.ComboBoxJenisBayar.Name = "ComboBoxJenisBayar"
        Me.ComboBoxJenisBayar.Size = New System.Drawing.Size(100, 25)
        Me.ComboBoxJenisBayar.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(30, 49)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 17)
        Me.Label2.TabIndex = 140
        Me.Label2.Text = "Nama Pasien"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(30, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 17)
        Me.Label1.TabIndex = 138
        Me.Label1.Text = "No. eRM"
        '
        'GridControlPembayaran
        '
        Me.GridControlPembayaran.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControlPembayaran.EmbeddedNavigator.Name = ""
        Me.GridControlPembayaran.Location = New System.Drawing.Point(0, 0)
        Me.GridControlPembayaran.MainView = Me.GridView1
        Me.GridControlPembayaran.Name = "GridControlPembayaran"
        Me.GridControlPembayaran.Size = New System.Drawing.Size(773, 136)
        Me.GridControlPembayaran.TabIndex = 144
        Me.GridControlPembayaran.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControlPembayaran
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OptionsView.ShowIndicator = False
        Me.GridView1.PaintStyleName = "Skin"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(421, 47)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 17)
        Me.Label7.TabIndex = 156
        Me.Label7.Text = "From QR"
        Me.Label7.Visible = False
        '
        'txbayarfromQRcode
        '
        Me.txbayarfromQRcode.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txbayarfromQRcode.Enabled = False
        Me.txbayarfromQRcode.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txbayarfromQRcode.Location = New System.Drawing.Point(528, 44)
        Me.txbayarfromQRcode.Name = "txbayarfromQRcode"
        Me.txbayarfromQRcode.ReadOnly = True
        Me.txbayarfromQRcode.Size = New System.Drawing.Size(113, 25)
        Me.txbayarfromQRcode.TabIndex = 155
        Me.txbayarfromQRcode.Visible = False
        '
        'CheckBoxNominalTagihan
        '
        Me.CheckBoxNominalTagihan.AutoSize = True
        Me.CheckBoxNominalTagihan.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.CheckBoxNominalTagihan.Location = New System.Drawing.Point(251, 140)
        Me.CheckBoxNominalTagihan.Name = "CheckBoxNominalTagihan"
        Me.CheckBoxNominalTagihan.Size = New System.Drawing.Size(113, 21)
        Me.CheckBoxNominalTagihan.TabIndex = 154
        Me.CheckBoxNominalTagihan.Text = "Sesuai Tagihan"
        Me.CheckBoxNominalTagihan.UseVisualStyleBackColor = True
        '
        'ComboBoxJenisEDC
        '
        Me.ComboBoxJenisEDC.AutoCompleteCustomSource.AddRange(New String() {"TUNAI", "CARD", "DEBET", "DISC", "TAGIHAN"})
        Me.ComboBoxJenisEDC.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxJenisEDC.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxJenisEDC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxJenisEDC.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBoxJenisEDC.FormattingEnabled = True
        Me.ComboBoxJenisEDC.Items.AddRange(New Object() {"TUNAI", "CARD", "DEBET", "DISC", "TAGIHAN"})
        Me.ComboBoxJenisEDC.Location = New System.Drawing.Point(528, 77)
        Me.ComboBoxJenisEDC.Name = "ComboBoxJenisEDC"
        Me.ComboBoxJenisEDC.Size = New System.Drawing.Size(113, 25)
        Me.ComboBoxJenisEDC.TabIndex = 152
        '
        'txnokartupembayaran
        '
        Me.txnokartupembayaran.AutoSize = True
        Me.txnokartupembayaran.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txnokartupembayaran.Location = New System.Drawing.Point(30, 111)
        Me.txnokartupembayaran.Name = "txnokartupembayaran"
        Me.txnokartupembayaran.Size = New System.Drawing.Size(63, 17)
        Me.txnokartupembayaran.TabIndex = 151
        Me.txnokartupembayaran.Text = "No Kartu"
        Me.txnokartupembayaran.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(421, 79)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 17)
        Me.Label6.TabIndex = 150
        Me.Label6.Text = "Mesin EDC"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(421, 111)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 17)
        Me.Label5.TabIndex = 149
        Me.Label5.Text = "Jenis Kartu"
        '
        'ComboBoxJenisBank
        '
        Me.ComboBoxJenisBank.AutoCompleteCustomSource.AddRange(New String() {"TUNAI", "CARD", "DEBET", "DISC", "TAGIHAN"})
        Me.ComboBoxJenisBank.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxJenisBank.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxJenisBank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxJenisBank.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBoxJenisBank.FormattingEnabled = True
        Me.ComboBoxJenisBank.Items.AddRange(New Object() {"TUNAI", "CARD", "DEBET", "DISC", "TAGIHAN"})
        Me.ComboBoxJenisBank.Location = New System.Drawing.Point(528, 108)
        Me.ComboBoxJenisBank.Name = "ComboBoxJenisBank"
        Me.ComboBoxJenisBank.Size = New System.Drawing.Size(113, 25)
        Me.ComboBoxJenisBank.TabIndex = 148
        '
        'butcompany
        '
        Me.butcompany.Location = New System.Drawing.Point(251, 77)
        Me.butcompany.Name = "butcompany"
        Me.butcompany.Size = New System.Drawing.Size(31, 23)
        Me.butcompany.TabIndex = 147
        Me.butcompany.Text = "..."
        Me.butcompany.UseVisualStyleBackColor = True
        '
        'ButtonClear
        '
        Me.ButtonClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonClear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonClear.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonClear.ForeColor = System.Drawing.Color.White
        Me.ButtonClear.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_clear_24
        Me.ButtonClear.Location = New System.Drawing.Point(145, 170)
        Me.ButtonClear.Name = "ButtonClear"
        Me.ButtonClear.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonClear.Size = New System.Drawing.Size(115, 35)
        Me.ButtonClear.TabIndex = 15
        Me.ButtonClear.Text = " Clear"
        Me.ButtonClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonClear.UseVisualStyleBackColor = False
        '
        'TextBoxNoKartu
        '
        Me.TextBoxNoKartu.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBoxNoKartu.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxNoKartu.Location = New System.Drawing.Point(145, 108)
        Me.TextBoxNoKartu.Name = "TextBoxNoKartu"
        Me.TextBoxNoKartu.ReadOnly = True
        Me.TextBoxNoKartu.Size = New System.Drawing.Size(236, 25)
        Me.TextBoxNoKartu.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(30, 142)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 17)
        Me.Label3.TabIndex = 146
        Me.Label3.Text = "Jumlah Bayar"
        '
        'ButtonTambah
        '
        Me.ButtonTambah.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonTambah.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonTambah.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonTambah.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonTambah.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonTambah.ForeColor = System.Drawing.Color.White
        Me.ButtonTambah.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_add_24
        Me.ButtonTambah.Location = New System.Drawing.Point(266, 170)
        Me.ButtonTambah.Name = "ButtonTambah"
        Me.ButtonTambah.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonTambah.Size = New System.Drawing.Size(115, 35)
        Me.ButtonTambah.TabIndex = 14
        Me.ButtonTambah.Text = " Tambah"
        Me.ButtonTambah.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonTambah.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonTambah.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(30, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 17)
        Me.Label4.TabIndex = 148
        Me.Label4.Text = "Kembali"
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.PanelTop.Controls.Add(Me.ButtonCancel)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(773, 35)
        Me.PanelTop.TabIndex = 147
        '
        'ButtonCancel
        '
        Me.ButtonCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonCancel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.ButtonCancel.FlatAppearance.BorderSize = 0
        Me.ButtonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCancel.Image = CType(resources.GetObject("ButtonCancel.Image"), System.Drawing.Image)
        Me.ButtonCancel.Location = New System.Drawing.Point(733, 0)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(40, 35)
        Me.ButtonCancel.TabIndex = 281
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.TextBoxJumlahBayar)
        Me.Panel1.Controls.Add(Me.TextBoxNomorRM)
        Me.Panel1.Controls.Add(Me.TextBoxNama)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txbayarfromQRcode)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.CheckBoxNominalTagihan)
        Me.Panel1.Controls.Add(Me.ComboBoxJenisEDC)
        Me.Panel1.Controls.Add(Me.txnokartupembayaran)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.ComboBoxJenisBayar)
        Me.Panel1.Controls.Add(Me.ComboBoxJenisBank)
        Me.Panel1.Controls.Add(Me.butcompany)
        Me.Panel1.Controls.Add(Me.ButtonTambah)
        Me.Panel1.Controls.Add(Me.ButtonClear)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.TextBoxNoKartu)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(773, 210)
        Me.Panel1.TabIndex = 148
        '
        'TextBoxJumlahBayar
        '
        Me.TextBoxJumlahBayar.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxJumlahBayar.Location = New System.Drawing.Point(145, 139)
        Me.TextBoxJumlahBayar.Maximum = New Decimal(New Integer() {1000000000, 0, 0, 0})
        Me.TextBoxJumlahBayar.Name = "TextBoxJumlahBayar"
        Me.TextBoxJumlahBayar.Size = New System.Drawing.Size(100, 25)
        Me.TextBoxJumlahBayar.TabIndex = 598
        '
        'TextBoxNomorRM
        '
        Me.TextBoxNomorRM.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.TextBoxNomorRM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxNomorRM.Cursor = System.Windows.Forms.Cursors.No
        Me.TextBoxNomorRM.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxNomorRM.Location = New System.Drawing.Point(145, 14)
        Me.TextBoxNomorRM.Name = "TextBoxNomorRM"
        Me.TextBoxNomorRM.ReadOnly = True
        Me.TextBoxNomorRM.Size = New System.Drawing.Size(236, 25)
        Me.TextBoxNomorRM.TabIndex = 448
        Me.TextBoxNomorRM.TabStop = False
        '
        'TextBoxNama
        '
        Me.TextBoxNama.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.TextBoxNama.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxNama.Cursor = System.Windows.Forms.Cursors.No
        Me.TextBoxNama.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxNama.Location = New System.Drawing.Point(145, 45)
        Me.TextBoxNama.Name = "TextBoxNama"
        Me.TextBoxNama.ReadOnly = True
        Me.TextBoxNama.Size = New System.Drawing.Size(236, 25)
        Me.TextBoxNama.TabIndex = 447
        Me.TextBoxNama.TabStop = False
        '
        'TextBoxTotalTagihan
        '
        Me.TextBoxTotalTagihan.BackColor = System.Drawing.Color.White
        Me.TextBoxTotalTagihan.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxTotalTagihan.Location = New System.Drawing.Point(145, 13)
        Me.TextBoxTotalTagihan.Maximum = New Decimal(New Integer() {1000000000, 0, 0, 0})
        Me.TextBoxTotalTagihan.Name = "TextBoxTotalTagihan"
        Me.TextBoxTotalTagihan.ReadOnly = True
        Me.TextBoxTotalTagihan.Size = New System.Drawing.Size(113, 25)
        Me.TextBoxTotalTagihan.TabIndex = 597
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GridControlPembayaran)
        Me.SplitContainer1.Size = New System.Drawing.Size(773, 350)
        Me.SplitContainer1.SplitterDistance = 210
        Me.SplitContainer1.TabIndex = 149
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 35)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.SplitContainer1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.CheckBoxLunasBayar)
        Me.SplitContainer2.Panel2.Controls.Add(Me.TextBoxTotalKembali)
        Me.SplitContainer2.Panel2.Controls.Add(Me.TextBoxTotalTagihan)
        Me.SplitContainer2.Panel2.Controls.Add(Me.TextBoxTotalBayar)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label8)
        Me.SplitContainer2.Panel2.Controls.Add(Me.ButtonSimpan)
        Me.SplitContainer2.Panel2.Controls.Add(Me.ButtonCetakInvoice)
        Me.SplitContainer2.Panel2.Controls.Add(Me.ButtonExportInvoice)
        Me.SplitContainer2.Panel2.Controls.Add(Me.ButtonWhatsAppInvoice)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label4)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label14)
        Me.SplitContainer2.Size = New System.Drawing.Size(773, 463)
        Me.SplitContainer2.SplitterDistance = 350
        Me.SplitContainer2.TabIndex = 150
        '
        'CheckBoxLunasBayar
        '
        Me.CheckBoxLunasBayar.AutoSize = True
        Me.CheckBoxLunasBayar.Enabled = False
        Me.CheckBoxLunasBayar.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxLunasBayar.Location = New System.Drawing.Point(438, 24)
        Me.CheckBoxLunasBayar.Name = "CheckBoxLunasBayar"
        Me.CheckBoxLunasBayar.Size = New System.Drawing.Size(116, 21)
        Me.CheckBoxLunasBayar.TabIndex = 614
        Me.CheckBoxLunasBayar.Text = "STATUS LUNAS"
        Me.CheckBoxLunasBayar.UseVisualStyleBackColor = True
        '
        'TextBoxTotalKembali
        '
        Me.TextBoxTotalKembali.BackColor = System.Drawing.Color.White
        Me.TextBoxTotalKembali.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxTotalKembali.Location = New System.Drawing.Point(145, 75)
        Me.TextBoxTotalKembali.Maximum = New Decimal(New Integer() {1000000000, 0, 0, 0})
        Me.TextBoxTotalKembali.Name = "TextBoxTotalKembali"
        Me.TextBoxTotalKembali.ReadOnly = True
        Me.TextBoxTotalKembali.Size = New System.Drawing.Size(113, 25)
        Me.TextBoxTotalKembali.TabIndex = 612
        '
        'TextBoxTotalBayar
        '
        Me.TextBoxTotalBayar.BackColor = System.Drawing.Color.White
        Me.TextBoxTotalBayar.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxTotalBayar.Location = New System.Drawing.Point(145, 44)
        Me.TextBoxTotalBayar.Maximum = New Decimal(New Integer() {1000000000, 0, 0, 0})
        Me.TextBoxTotalBayar.Name = "TextBoxTotalBayar"
        Me.TextBoxTotalBayar.ReadOnly = True
        Me.TextBoxTotalBayar.Size = New System.Drawing.Size(113, 25)
        Me.TextBoxTotalBayar.TabIndex = 611
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(30, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(75, 17)
        Me.Label8.TabIndex = 610
        Me.Label8.Text = "Total Bayar"
        '
        'ButtonSimpan
        '
        Me.ButtonSimpan.BackColor = System.Drawing.Color.White
        Me.ButtonSimpan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonSimpan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonSimpan.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSimpan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSimpan.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSimpan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSimpan.Image = CType(resources.GetObject("ButtonSimpan.Image"), System.Drawing.Image)
        Me.ButtonSimpan.Location = New System.Drawing.Point(280, 13)
        Me.ButtonSimpan.Name = "ButtonSimpan"
        Me.ButtonSimpan.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonSimpan.Size = New System.Drawing.Size(152, 40)
        Me.ButtonSimpan.TabIndex = 609
        Me.ButtonSimpan.Text = " Simpan"
        Me.ButtonSimpan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonSimpan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonSimpan.UseVisualStyleBackColor = False
        '
        'ButtonCetakInvoice
        '
        Me.ButtonCetakInvoice.BackColor = System.Drawing.Color.White
        Me.ButtonCetakInvoice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonCetakInvoice.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonCetakInvoice.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCetakInvoice.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonCetakInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCetakInvoice.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCetakInvoice.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCetakInvoice.Image = CType(resources.GetObject("ButtonCetakInvoice.Image"), System.Drawing.Image)
        Me.ButtonCetakInvoice.Location = New System.Drawing.Point(280, 59)
        Me.ButtonCetakInvoice.Name = "ButtonCetakInvoice"
        Me.ButtonCetakInvoice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonCetakInvoice.Size = New System.Drawing.Size(152, 40)
        Me.ButtonCetakInvoice.TabIndex = 608
        Me.ButtonCetakInvoice.Text = "   Cetak"
        Me.ButtonCetakInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonCetakInvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonCetakInvoice.UseVisualStyleBackColor = False
        '
        'ButtonExportInvoice
        '
        Me.ButtonExportInvoice.BackColor = System.Drawing.Color.White
        Me.ButtonExportInvoice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonExportInvoice.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonExportInvoice.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonExportInvoice.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonExportInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonExportInvoice.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonExportInvoice.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonExportInvoice.Image = CType(resources.GetObject("ButtonExportInvoice.Image"), System.Drawing.Image)
        Me.ButtonExportInvoice.Location = New System.Drawing.Point(438, 59)
        Me.ButtonExportInvoice.Name = "ButtonExportInvoice"
        Me.ButtonExportInvoice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonExportInvoice.Size = New System.Drawing.Size(152, 40)
        Me.ButtonExportInvoice.TabIndex = 607
        Me.ButtonExportInvoice.Text = " Export PDF"
        Me.ButtonExportInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonExportInvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonExportInvoice.UseVisualStyleBackColor = False
        '
        'ButtonWhatsAppInvoice
        '
        Me.ButtonWhatsAppInvoice.BackColor = System.Drawing.Color.White
        Me.ButtonWhatsAppInvoice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonWhatsAppInvoice.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonWhatsAppInvoice.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonWhatsAppInvoice.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonWhatsAppInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonWhatsAppInvoice.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonWhatsAppInvoice.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonWhatsAppInvoice.Image = CType(resources.GetObject("ButtonWhatsAppInvoice.Image"), System.Drawing.Image)
        Me.ButtonWhatsAppInvoice.Location = New System.Drawing.Point(596, 59)
        Me.ButtonWhatsAppInvoice.Name = "ButtonWhatsAppInvoice"
        Me.ButtonWhatsAppInvoice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonWhatsAppInvoice.Size = New System.Drawing.Size(152, 40)
        Me.ButtonWhatsAppInvoice.TabIndex = 606
        Me.ButtonWhatsAppInvoice.Text = " WhatsApp"
        Me.ButtonWhatsAppInvoice.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonWhatsAppInvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonWhatsAppInvoice.UseVisualStyleBackColor = False
        '
        'FormPembayaran
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(773, 498)
        Me.ControlBox = False
        Me.Controls.Add(Me.SplitContainer2)
        Me.Controls.Add(Me.PanelTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPembayaran"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.GridControlPembayaran, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelTop.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.TextBoxJumlahBayar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxTotalTagihan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel2.PerformLayout()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.TextBoxTotalKembali, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxTotalBayar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxJenisBayar As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ButtonTambah As System.Windows.Forms.Button
    Friend WithEvents TextBoxNoKartu As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ButtonClear As System.Windows.Forms.Button
    Friend WithEvents butcompany As System.Windows.Forms.Button
    Friend WithEvents ComboBoxJenisBank As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxJenisEDC As System.Windows.Forms.ComboBox
    Friend WithEvents txnokartupembayaran As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Private WithEvents GridControlPembayaran As DevExpress.XtraGrid.GridControl
    Private WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents CheckBoxNominalTagihan As System.Windows.Forms.CheckBox
    Friend WithEvents txbayarfromQRcode As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents TextBoxNama As System.Windows.Forms.TextBox
    Friend WithEvents ButtonCetakInvoice As System.Windows.Forms.Button
    Friend WithEvents ButtonExportInvoice As System.Windows.Forms.Button
    Friend WithEvents ButtonWhatsAppInvoice As System.Windows.Forms.Button
    Friend WithEvents ButtonSimpan As System.Windows.Forms.Button
    Friend WithEvents TextBoxNomorRM As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxTotalTagihan As PoliKlinik_Net2.NumericUpDownWithThousands
    Friend WithEvents TextBoxJumlahBayar As PoliKlinik_Net2.NumericUpDownWithThousands
    Friend WithEvents TextBoxTotalKembali As PoliKlinik_Net2.NumericUpDownWithThousands
    Friend WithEvents TextBoxTotalBayar As PoliKlinik_Net2.NumericUpDownWithThousands
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxLunasBayar As System.Windows.Forms.CheckBox
End Class
