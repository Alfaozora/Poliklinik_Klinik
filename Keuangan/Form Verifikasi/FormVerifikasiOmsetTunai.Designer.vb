<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormVerifikasiOmsetTunai
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormVerifikasiOmsetTunai))
        Me.ProgressBarUpload = New System.Windows.Forms.ProgressBar
        Me.ComboBoxBankEDC = New System.Windows.Forms.ComboBox
        Me.ComboBoxJenisPembayaran = New System.Windows.Forms.ComboBox
        Me.ComboBoxJenisTransaksi = New System.Windows.Forms.ComboBox
        Me.TextBoxKeteranganLokasi = New System.Windows.Forms.TextBox
        Me.DateTimeTglTransaksi = New System.Windows.Forms.DateTimePicker
        Me.DataGridViewDaftarTransaksi = New System.Windows.Forms.DataGridView
        Me.bankid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NoTransaksiTunai = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IDTunai = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.JenisTunai = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.IDPasienTunai = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PasienTunai = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.JenisBayarTunai = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.KartuTunai = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.MesinTunai = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.NilaiUangTunai = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BiayaAdmin = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TglTransaksiTunai = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusTunai = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PilihanTunai = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.bankcoa = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LabelTotalBiayaAdmin = New System.Windows.Forms.Label
        Me.LabelTotalOmsetClosing = New System.Windows.Forms.Label
        Me.LabelTotalOmsetCentang = New System.Windows.Forms.Label
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.DateTimeTglTransfer = New System.Windows.Forms.DateTimePicker
        Me.Label28 = New System.Windows.Forms.Label
        Me.ProgressBar3 = New System.Windows.Forms.ProgressBar
        Me.Label30 = New System.Windows.Forms.Label
        Me.ProgressBar4 = New System.Windows.Forms.ProgressBar
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.PanelTop = New System.Windows.Forms.Panel
        Me.ButtonClose = New System.Windows.Forms.Button
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TextBoxCoaBank = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ButtonCariBank = New System.Windows.Forms.Button
        Me.TextBoxNamaBank = New System.Windows.Forms.TextBox
        Me.LabelTotalOmset = New System.Windows.Forms.Label
        Me.ButtonSimpan = New System.Windows.Forms.Button
        Me.ButtonKalkulasi = New System.Windows.Forms.Button
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.ButtonView = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ButtonCariLokasi = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.ButtonKirimUlangUMH = New System.Windows.Forms.Button
        Me.ButtonKirimUlangBKM = New System.Windows.Forms.Button
        Me.ButtonClearData = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        CType(Me.DataGridViewDaftarTransaksi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelTop.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ProgressBarUpload
        '
        Me.ProgressBarUpload.BackColor = System.Drawing.Color.Lime
        Me.ProgressBarUpload.Location = New System.Drawing.Point(12, 188)
        Me.ProgressBarUpload.Name = "ProgressBarUpload"
        Me.ProgressBarUpload.Size = New System.Drawing.Size(821, 6)
        Me.ProgressBarUpload.TabIndex = 146
        '
        'ComboBoxBankEDC
        '
        Me.ComboBoxBankEDC.BackColor = System.Drawing.Color.White
        Me.ComboBoxBankEDC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxBankEDC.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBoxBankEDC.FormattingEnabled = True
        Me.ComboBoxBankEDC.Items.AddRange(New Object() {"SEMUA", "BCA", "MANDIRI", "CIMB"})
        Me.ComboBoxBankEDC.Location = New System.Drawing.Point(683, 116)
        Me.ComboBoxBankEDC.Name = "ComboBoxBankEDC"
        Me.ComboBoxBankEDC.Size = New System.Drawing.Size(150, 25)
        Me.ComboBoxBankEDC.TabIndex = 221
        '
        'ComboBoxJenisPembayaran
        '
        Me.ComboBoxJenisPembayaran.BackColor = System.Drawing.Color.White
        Me.ComboBoxJenisPembayaran.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxJenisPembayaran.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBoxJenisPembayaran.FormattingEnabled = True
        Me.ComboBoxJenisPembayaran.Items.AddRange(New Object() {"SEMUA", "TUNAI", "DEBET", "KREDIT", "DEBET & KREDIT"})
        Me.ComboBoxJenisPembayaran.Location = New System.Drawing.Point(683, 54)
        Me.ComboBoxJenisPembayaran.Name = "ComboBoxJenisPembayaran"
        Me.ComboBoxJenisPembayaran.Size = New System.Drawing.Size(150, 25)
        Me.ComboBoxJenisPembayaran.TabIndex = 204
        '
        'ComboBoxJenisTransaksi
        '
        Me.ComboBoxJenisTransaksi.BackColor = System.Drawing.Color.White
        Me.ComboBoxJenisTransaksi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxJenisTransaksi.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBoxJenisTransaksi.FormattingEnabled = True
        Me.ComboBoxJenisTransaksi.Items.AddRange(New Object() {"SEMUA", "DLL", "GIGI", "LAB", "POLI"})
        Me.ComboBoxJenisTransaksi.Location = New System.Drawing.Point(683, 85)
        Me.ComboBoxJenisTransaksi.Name = "ComboBoxJenisTransaksi"
        Me.ComboBoxJenisTransaksi.Size = New System.Drawing.Size(150, 25)
        Me.ComboBoxJenisTransaksi.TabIndex = 198
        '
        'TextBoxKeteranganLokasi
        '
        Me.TextBoxKeteranganLokasi.BackColor = System.Drawing.Color.White
        Me.TextBoxKeteranganLokasi.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxKeteranganLokasi.Location = New System.Drawing.Point(185, 86)
        Me.TextBoxKeteranganLokasi.Multiline = True
        Me.TextBoxKeteranganLokasi.Name = "TextBoxKeteranganLokasi"
        Me.TextBoxKeteranganLokasi.ReadOnly = True
        Me.TextBoxKeteranganLokasi.Size = New System.Drawing.Size(235, 50)
        Me.TextBoxKeteranganLokasi.TabIndex = 193
        Me.TextBoxKeteranganLokasi.TabStop = False
        '
        'DateTimeTglTransaksi
        '
        Me.DateTimeTglTransaksi.CalendarFont = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.DateTimeTglTransaksi.CustomFormat = "dd-MMM-yyyy"
        Me.DateTimeTglTransaksi.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.DateTimeTglTransaksi.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimeTglTransaksi.Location = New System.Drawing.Point(185, 54)
        Me.DateTimeTglTransaksi.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DateTimeTglTransaksi.Name = "DateTimeTglTransaksi"
        Me.DateTimeTglTransaksi.Size = New System.Drawing.Size(150, 25)
        Me.DateTimeTglTransaksi.TabIndex = 120
        '
        'DataGridViewDaftarTransaksi
        '
        Me.DataGridViewDaftarTransaksi.AllowUserToAddRows = False
        Me.DataGridViewDaftarTransaksi.AllowUserToDeleteRows = False
        Me.DataGridViewDaftarTransaksi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewDaftarTransaksi.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.bankid, Me.NoTransaksiTunai, Me.IDTunai, Me.JenisTunai, Me.IDPasienTunai, Me.PasienTunai, Me.JenisBayarTunai, Me.KartuTunai, Me.MesinTunai, Me.NilaiUangTunai, Me.BiayaAdmin, Me.TglTransaksiTunai, Me.StatusTunai, Me.PilihanTunai, Me.bankcoa})
        Me.DataGridViewDaftarTransaksi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewDaftarTransaksi.Location = New System.Drawing.Point(0, 0)
        Me.DataGridViewDaftarTransaksi.Name = "DataGridViewDaftarTransaksi"
        Me.DataGridViewDaftarTransaksi.Size = New System.Drawing.Size(1109, 304)
        Me.DataGridViewDaftarTransaksi.TabIndex = 149
        '
        'bankid
        '
        Me.bankid.HeaderText = "bankid"
        Me.bankid.Name = "bankid"
        Me.bankid.Visible = False
        '
        'NoTransaksiTunai
        '
        Me.NoTransaksiTunai.HeaderText = "ID"
        Me.NoTransaksiTunai.Name = "NoTransaksiTunai"
        Me.NoTransaksiTunai.ReadOnly = True
        Me.NoTransaksiTunai.Width = 75
        '
        'IDTunai
        '
        Me.IDTunai.HeaderText = "ID"
        Me.IDTunai.Name = "IDTunai"
        Me.IDTunai.ReadOnly = True
        Me.IDTunai.Visible = False
        '
        'JenisTunai
        '
        Me.JenisTunai.HeaderText = "Jenis"
        Me.JenisTunai.Name = "JenisTunai"
        Me.JenisTunai.ReadOnly = True
        Me.JenisTunai.Width = 70
        '
        'IDPasienTunai
        '
        Me.IDPasienTunai.HeaderText = "ID Pasien"
        Me.IDPasienTunai.Name = "IDPasienTunai"
        Me.IDPasienTunai.ReadOnly = True
        Me.IDPasienTunai.Visible = False
        '
        'PasienTunai
        '
        Me.PasienTunai.HeaderText = "Pasien"
        Me.PasienTunai.Name = "PasienTunai"
        Me.PasienTunai.ReadOnly = True
        '
        'JenisBayarTunai
        '
        Me.JenisBayarTunai.HeaderText = "Jenis Bayar"
        Me.JenisBayarTunai.Name = "JenisBayarTunai"
        Me.JenisBayarTunai.ReadOnly = True
        '
        'KartuTunai
        '
        Me.KartuTunai.HeaderText = "Kartu"
        Me.KartuTunai.Name = "KartuTunai"
        Me.KartuTunai.ReadOnly = True
        '
        'MesinTunai
        '
        Me.MesinTunai.HeaderText = "Mesin"
        Me.MesinTunai.Name = "MesinTunai"
        Me.MesinTunai.ReadOnly = True
        '
        'NilaiUangTunai
        '
        Me.NilaiUangTunai.HeaderText = "Nilai Uang"
        Me.NilaiUangTunai.Name = "NilaiUangTunai"
        Me.NilaiUangTunai.ReadOnly = True
        '
        'BiayaAdmin
        '
        Me.BiayaAdmin.HeaderText = "Biaya Admin"
        Me.BiayaAdmin.Name = "BiayaAdmin"
        Me.BiayaAdmin.ReadOnly = True
        '
        'TglTransaksiTunai
        '
        Me.TglTransaksiTunai.HeaderText = "TglTrans"
        Me.TglTransaksiTunai.Name = "TglTransaksiTunai"
        Me.TglTransaksiTunai.ReadOnly = True
        Me.TglTransaksiTunai.Width = 75
        '
        'StatusTunai
        '
        Me.StatusTunai.HeaderText = "Status"
        Me.StatusTunai.Name = "StatusTunai"
        Me.StatusTunai.ReadOnly = True
        Me.StatusTunai.Width = 75
        '
        'PilihanTunai
        '
        Me.PilihanTunai.HeaderText = "Pilihan"
        Me.PilihanTunai.Name = "PilihanTunai"
        Me.PilihanTunai.Width = 75
        '
        'bankcoa
        '
        Me.bankcoa.HeaderText = "bankcoa"
        Me.bankcoa.Name = "bankcoa"
        Me.bankcoa.Visible = False
        '
        'LabelTotalBiayaAdmin
        '
        Me.LabelTotalBiayaAdmin.AutoSize = True
        Me.LabelTotalBiayaAdmin.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.LabelTotalBiayaAdmin.Location = New System.Drawing.Point(182, 265)
        Me.LabelTotalBiayaAdmin.Name = "LabelTotalBiayaAdmin"
        Me.LabelTotalBiayaAdmin.Size = New System.Drawing.Size(38, 17)
        Me.LabelTotalBiayaAdmin.TabIndex = 220
        Me.LabelTotalBiayaAdmin.Text = "Rp. 0"
        '
        'LabelTotalOmsetClosing
        '
        Me.LabelTotalOmsetClosing.AutoSize = True
        Me.LabelTotalOmsetClosing.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTotalOmsetClosing.Location = New System.Drawing.Point(182, 203)
        Me.LabelTotalOmsetClosing.Name = "LabelTotalOmsetClosing"
        Me.LabelTotalOmsetClosing.Size = New System.Drawing.Size(38, 17)
        Me.LabelTotalOmsetClosing.TabIndex = 213
        Me.LabelTotalOmsetClosing.Text = "Rp. 0"
        '
        'LabelTotalOmsetCentang
        '
        Me.LabelTotalOmsetCentang.AutoSize = True
        Me.LabelTotalOmsetCentang.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.LabelTotalOmsetCentang.Location = New System.Drawing.Point(182, 234)
        Me.LabelTotalOmsetCentang.Name = "LabelTotalOmsetCentang"
        Me.LabelTotalOmsetCentang.Size = New System.Drawing.Size(38, 17)
        Me.LabelTotalOmsetCentang.TabIndex = 217
        Me.LabelTotalOmsetCentang.Text = "Rp. 0"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(394, 274)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(97, 20)
        Me.CheckBox1.TabIndex = 214
        Me.CheckBox1.Text = "Pilih Semua"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'DateTimeTglTransfer
        '
        Me.DateTimeTglTransfer.CalendarFont = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.DateTimeTglTransfer.CustomFormat = "dd-MMM-yyyy"
        Me.DateTimeTglTransfer.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.DateTimeTglTransfer.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimeTglTransfer.Location = New System.Drawing.Point(527, 203)
        Me.DateTimeTglTransfer.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DateTimeTglTransfer.Name = "DateTimeTglTransfer"
        Me.DateTimeTglTransfer.Size = New System.Drawing.Size(150, 25)
        Me.DateTimeTglTransfer.TabIndex = 202
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(13, 25)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(96, 18)
        Me.Label28.TabIndex = 205
        Me.Label28.Text = "Processing.."
        '
        'ProgressBar3
        '
        Me.ProgressBar3.BackColor = System.Drawing.Color.Lime
        Me.ProgressBar3.Location = New System.Drawing.Point(115, 14)
        Me.ProgressBar3.Name = "ProgressBar3"
        Me.ProgressBar3.Size = New System.Drawing.Size(318, 38)
        Me.ProgressBar3.TabIndex = 146
        Me.ProgressBar3.Visible = False
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(13, 25)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(96, 18)
        Me.Label30.TabIndex = 205
        Me.Label30.Text = "Processing.."
        '
        'ProgressBar4
        '
        Me.ProgressBar4.BackColor = System.Drawing.Color.Lime
        Me.ProgressBar4.Location = New System.Drawing.Point(115, 14)
        Me.ProgressBar4.Name = "ProgressBar4"
        Me.ProgressBar4.Size = New System.Drawing.Size(318, 38)
        Me.ProgressBar4.TabIndex = 146
        Me.ProgressBar4.Visible = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 663)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New System.Windows.Forms.Padding(1, 0, 16, 0)
        Me.StatusStrip1.Size = New System.Drawing.Size(1109, 22)
        Me.StatusStrip1.TabIndex = 120
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.PanelTop.Controls.Add(Me.ButtonClose)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(1109, 35)
        Me.PanelTop.TabIndex = 121
        '
        'ButtonClose
        '
        Me.ButtonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.ButtonClose.FlatAppearance.BorderSize = 0
        Me.ButtonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonClose.Image = CType(resources.GetObject("ButtonClose.Image"), System.Drawing.Image)
        Me.ButtonClose.Location = New System.Drawing.Point(1069, 0)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(40, 35)
        Me.ButtonClose.TabIndex = 281
        Me.ButtonClose.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 35)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.AutoScroll = True
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.AutoScroll = True
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridViewDaftarTransaksi)
        Me.SplitContainer1.Size = New System.Drawing.Size(1109, 628)
        Me.SplitContainer1.SplitterDistance = 320
        Me.SplitContainer1.TabIndex = 122
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TextBoxCoaBank)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.ButtonCariBank)
        Me.Panel1.Controls.Add(Me.TextBoxNamaBank)
        Me.Panel1.Controls.Add(Me.LabelTotalOmset)
        Me.Panel1.Controls.Add(Me.ButtonSimpan)
        Me.Panel1.Controls.Add(Me.ButtonKalkulasi)
        Me.Panel1.Controls.Add(Me.LabelTotalBiayaAdmin)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.LabelTotalOmsetCentang)
        Me.Panel1.Controls.Add(Me.LabelTotalOmsetClosing)
        Me.Panel1.Controls.Add(Me.CheckBox1)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.DateTimeTglTransfer)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.ProgressBarUpload)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.ButtonView)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.ComboBoxBankEDC)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.ButtonCariLokasi)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.ButtonKirimUlangUMH)
        Me.Panel1.Controls.Add(Me.ComboBoxJenisPembayaran)
        Me.Panel1.Controls.Add(Me.ButtonKirimUlangBKM)
        Me.Panel1.Controls.Add(Me.ButtonClearData)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.ComboBoxJenisTransaksi)
        Me.Panel1.Controls.Add(Me.DateTimeTglTransaksi)
        Me.Panel1.Controls.Add(Me.TextBoxKeteranganLokasi)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1109, 320)
        Me.Panel1.TabIndex = 123
        '
        'TextBoxCoaBank
        '
        Me.TextBoxCoaBank.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.TextBoxCoaBank.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxCoaBank.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxCoaBank.Location = New System.Drawing.Point(683, 203)
        Me.TextBoxCoaBank.Name = "TextBoxCoaBank"
        Me.TextBoxCoaBank.Size = New System.Drawing.Size(79, 25)
        Me.TextBoxCoaBank.TabIndex = 537
        Me.TextBoxCoaBank.TabStop = False
        Me.TextBoxCoaBank.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(391, 209)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 17)
        Me.Label3.TabIndex = 536
        Me.Label3.Text = "Tgl Transfer"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(391, 238)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 17)
        Me.Label2.TabIndex = 535
        Me.Label2.Text = "Bank Transfer"
        '
        'ButtonCariBank
        '
        Me.ButtonCariBank.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCariBank.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonCariBank.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonCariBank.FlatAppearance.BorderSize = 0
        Me.ButtonCariBank.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCariBank.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonCariBank.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCariBank.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonCariBank.ForeColor = System.Drawing.Color.White
        Me.ButtonCariBank.Location = New System.Drawing.Point(768, 235)
        Me.ButtonCariBank.Name = "ButtonCariBank"
        Me.ButtonCariBank.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonCariBank.Size = New System.Drawing.Size(65, 25)
        Me.ButtonCariBank.TabIndex = 534
        Me.ButtonCariBank.Text = "Cari"
        Me.ButtonCariBank.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonCariBank.UseVisualStyleBackColor = False
        '
        'TextBoxNamaBank
        '
        Me.TextBoxNamaBank.BackColor = System.Drawing.Color.White
        Me.TextBoxNamaBank.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxNamaBank.Location = New System.Drawing.Point(527, 235)
        Me.TextBoxNamaBank.Name = "TextBoxNamaBank"
        Me.TextBoxNamaBank.ReadOnly = True
        Me.TextBoxNamaBank.Size = New System.Drawing.Size(235, 25)
        Me.TextBoxNamaBank.TabIndex = 533
        Me.TextBoxNamaBank.TabStop = False
        '
        'LabelTotalOmset
        '
        Me.LabelTotalOmset.AutoSize = True
        Me.LabelTotalOmset.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTotalOmset.Location = New System.Drawing.Point(182, 145)
        Me.LabelTotalOmset.Name = "LabelTotalOmset"
        Me.LabelTotalOmset.Size = New System.Drawing.Size(38, 17)
        Me.LabelTotalOmset.TabIndex = 532
        Me.LabelTotalOmset.Text = "Rp. 0"
        '
        'ButtonSimpan
        '
        Me.ButtonSimpan.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSimpan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonSimpan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonSimpan.FlatAppearance.BorderSize = 0
        Me.ButtonSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSimpan.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonSimpan.ForeColor = System.Drawing.Color.White
        Me.ButtonSimpan.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_save_24
        Me.ButtonSimpan.Location = New System.Drawing.Point(633, 266)
        Me.ButtonSimpan.Name = "ButtonSimpan"
        Me.ButtonSimpan.Size = New System.Drawing.Size(200, 35)
        Me.ButtonSimpan.TabIndex = 531
        Me.ButtonSimpan.Text = " Simpan Data"
        Me.ButtonSimpan.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonSimpan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonSimpan.UseVisualStyleBackColor = False
        '
        'ButtonKalkulasi
        '
        Me.ButtonKalkulasi.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonKalkulasi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonKalkulasi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonKalkulasi.FlatAppearance.BorderSize = 0
        Me.ButtonKalkulasi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonKalkulasi.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonKalkulasi.ForeColor = System.Drawing.Color.White
        Me.ButtonKalkulasi.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_calculator_24
        Me.ButtonKalkulasi.Location = New System.Drawing.Point(527, 266)
        Me.ButtonKalkulasi.Name = "ButtonKalkulasi"
        Me.ButtonKalkulasi.Size = New System.Drawing.Size(100, 35)
        Me.ButtonKalkulasi.TabIndex = 530
        Me.ButtonKalkulasi.Text = "Kalkulasi"
        Me.ButtonKalkulasi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonKalkulasi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonKalkulasi.UseVisualStyleBackColor = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(12, 265)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(117, 17)
        Me.Label17.TabIndex = 529
        Me.Label17.Text = "Total Biaya Admin"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(12, 234)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(152, 17)
        Me.Label16.TabIndex = 527
        Me.Label16.Text = "Total Omset Tercentang"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(12, 203)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(145, 17)
        Me.Label11.TabIndex = 525
        Me.Label11.Text = "Total Omset Terclosing"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 145)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 17)
        Me.Label8.TabIndex = 468
        Me.Label8.Text = "Total Omset"
        '
        'ButtonView
        '
        Me.ButtonView.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonView.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonView.FlatAppearance.BorderSize = 0
        Me.ButtonView.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonView.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonView.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonView.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonView.ForeColor = System.Drawing.Color.White
        Me.ButtonView.Image = CType(resources.GetObject("ButtonView.Image"), System.Drawing.Image)
        Me.ButtonView.Location = New System.Drawing.Point(527, 147)
        Me.ButtonView.Name = "ButtonView"
        Me.ButtonView.Size = New System.Drawing.Size(306, 35)
        Me.ButtonView.TabIndex = 521
        Me.ButtonView.Text = " Tampilkan Data"
        Me.ButtonView.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonView.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(524, 57)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(117, 17)
        Me.Label10.TabIndex = 473
        Me.Label10.Text = "Jenis Pembayaran"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(524, 88)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(96, 17)
        Me.Label9.TabIndex = 472
        Me.Label9.Text = "Jenis Transaksi"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(524, 119)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 17)
        Me.Label1.TabIndex = 471
        Me.Label1.Text = "Bank EDC"
        '
        'ButtonCariLokasi
        '
        Me.ButtonCariLokasi.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCariLokasi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonCariLokasi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonCariLokasi.FlatAppearance.BorderSize = 0
        Me.ButtonCariLokasi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCariLokasi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonCariLokasi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCariLokasi.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonCariLokasi.ForeColor = System.Drawing.Color.White
        Me.ButtonCariLokasi.Location = New System.Drawing.Point(426, 86)
        Me.ButtonCariLokasi.Name = "ButtonCariLokasi"
        Me.ButtonCariLokasi.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonCariLokasi.Size = New System.Drawing.Size(65, 25)
        Me.ButtonCariLokasi.TabIndex = 470
        Me.ButtonCariLokasi.Text = "Cari"
        Me.ButtonCariLokasi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonCariLokasi.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 89)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(95, 17)
        Me.Label7.TabIndex = 467
        Me.Label7.Text = "Lokasi Cabang"
        '
        'ButtonKirimUlangUMH
        '
        Me.ButtonKirimUlangUMH.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonKirimUlangUMH.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonKirimUlangUMH.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonKirimUlangUMH.FlatAppearance.BorderSize = 0
        Me.ButtonKirimUlangUMH.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonKirimUlangUMH.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonKirimUlangUMH.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonKirimUlangUMH.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonKirimUlangUMH.ForeColor = System.Drawing.Color.White
        Me.ButtonKirimUlangUMH.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_clear_24
        Me.ButtonKirimUlangUMH.Location = New System.Drawing.Point(294, 6)
        Me.ButtonKirimUlangUMH.Name = "ButtonKirimUlangUMH"
        Me.ButtonKirimUlangUMH.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonKirimUlangUMH.Size = New System.Drawing.Size(150, 35)
        Me.ButtonKirimUlangUMH.TabIndex = 466
        Me.ButtonKirimUlangUMH.Text = " Send Ulang UMH"
        Me.ButtonKirimUlangUMH.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonKirimUlangUMH.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonKirimUlangUMH.UseVisualStyleBackColor = False
        '
        'ButtonKirimUlangBKM
        '
        Me.ButtonKirimUlangBKM.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonKirimUlangBKM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonKirimUlangBKM.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonKirimUlangBKM.FlatAppearance.BorderSize = 0
        Me.ButtonKirimUlangBKM.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonKirimUlangBKM.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonKirimUlangBKM.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonKirimUlangBKM.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonKirimUlangBKM.ForeColor = System.Drawing.Color.White
        Me.ButtonKirimUlangBKM.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_clear_24
        Me.ButtonKirimUlangBKM.Location = New System.Drawing.Point(138, 6)
        Me.ButtonKirimUlangBKM.Name = "ButtonKirimUlangBKM"
        Me.ButtonKirimUlangBKM.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonKirimUlangBKM.Size = New System.Drawing.Size(150, 35)
        Me.ButtonKirimUlangBKM.TabIndex = 465
        Me.ButtonKirimUlangBKM.Text = " Send Ulang BKM"
        Me.ButtonKirimUlangBKM.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonKirimUlangBKM.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonKirimUlangBKM.UseVisualStyleBackColor = False
        '
        'ButtonClearData
        '
        Me.ButtonClearData.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonClearData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonClearData.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonClearData.FlatAppearance.BorderSize = 0
        Me.ButtonClearData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonClearData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonClearData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonClearData.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonClearData.ForeColor = System.Drawing.Color.White
        Me.ButtonClearData.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_clear_24
        Me.ButtonClearData.Location = New System.Drawing.Point(12, 6)
        Me.ButtonClearData.Name = "ButtonClearData"
        Me.ButtonClearData.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonClearData.Size = New System.Drawing.Size(120, 35)
        Me.ButtonClearData.TabIndex = 464
        Me.ButtonClearData.Text = " Clear Data"
        Me.ButtonClearData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonClearData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonClearData.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 17)
        Me.Label6.TabIndex = 440
        Me.Label6.Text = "Tgl Transaksi"
        '
        'FormVerifikasiOmsetTunai
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1109, 685)
        Me.ControlBox = False
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.PanelTop)
        Me.Controls.Add(Me.StatusStrip1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormVerifikasiOmsetTunai"
        CType(Me.DataGridViewDaftarTransaksi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelTop.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DateTimeTglTransaksi As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextBoxKeteranganLokasi As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxJenisTransaksi As System.Windows.Forms.ComboBox
    Friend WithEvents DateTimeTglTransfer As System.Windows.Forms.DateTimePicker
    Friend WithEvents LabelTotalOmsetClosing As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents LabelTotalOmsetCentang As System.Windows.Forms.Label
    Friend WithEvents ComboBoxJenisPembayaran As System.Windows.Forms.ComboBox
    Friend WithEvents DataGridViewDaftarTransaksi As System.Windows.Forms.DataGridView
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar3 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar4 As System.Windows.Forms.ProgressBar
    Friend WithEvents ProgressBarUpload As System.Windows.Forms.ProgressBar
    Friend WithEvents LabelTotalBiayaAdmin As System.Windows.Forms.Label
    Friend WithEvents ComboBoxBankEDC As System.Windows.Forms.ComboBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents bankid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NoTransaksiTunai As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDTunai As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JenisTunai As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDPasienTunai As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PasienTunai As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JenisBayarTunai As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents KartuTunai As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MesinTunai As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents NilaiUangTunai As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BiayaAdmin As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TglTransaksiTunai As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusTunai As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PilihanTunai As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents bankcoa As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents ButtonClose As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ButtonClearData As System.Windows.Forms.Button
    Friend WithEvents ButtonKirimUlangUMH As System.Windows.Forms.Button
    Friend WithEvents ButtonKirimUlangBKM As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ButtonCariLokasi As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonView As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ButtonSimpan As System.Windows.Forms.Button
    Friend WithEvents ButtonKalkulasi As System.Windows.Forms.Button
    Friend WithEvents LabelTotalOmset As System.Windows.Forms.Label
    Friend WithEvents ButtonCariBank As System.Windows.Forms.Button
    Friend WithEvents TextBoxNamaBank As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBoxCoaBank As System.Windows.Forms.TextBox
End Class
