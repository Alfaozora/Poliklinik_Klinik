<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCetakInvoice
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCetakInvoice))
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.txpoliid = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GridControlTindakan = New DevExpress.XtraGrid.GridControl
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TextBoxKeteranganVoucher = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.CheckBoxStatusPembelianPaket = New System.Windows.Forms.CheckBox
        Me.ButtonCetakInvoice = New System.Windows.Forms.Button
        Me.txtotalrow = New System.Windows.Forms.TextBox
        Me.TextBoxNomorRM = New System.Windows.Forms.TextBox
        Me.txadmin = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TextBoxNomorTransaksi = New System.Windows.Forms.TextBox
        Me.txcustlp = New System.Windows.Forms.TextBox
        Me.txumur = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cmbjenis = New System.Windows.Forms.ComboBox
        Me.txrequest = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TextBoxNamaDokter = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txcustnama = New System.Windows.Forms.TextBox
        Me.dttanggal = New System.Windows.Forms.DateTimePicker
        Me.txtotal = New DevExpress.XtraEditors.TextEdit
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtcusttgllhr = New System.Windows.Forms.DateTimePicker
        Me.butfind = New System.Windows.Forms.Button
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.gridbayar = New DevExpress.XtraGrid.GridControl
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridControlTindakan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.txtotal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.gridbayar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(26, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 15)
        Me.Label2.TabIndex = 105
        Me.Label2.Text = "ID Pasien"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(4, 101)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 15)
        Me.Label1.TabIndex = 104
        Me.Label1.Text = "Nama Pasien"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_cetak
        Me.Button1.Location = New System.Drawing.Point(573, 174)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 36)
        Me.Button1.TabIndex = 103
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txpoliid
        '
        Me.txpoliid.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txpoliid.Location = New System.Drawing.Point(93, 45)
        Me.txpoliid.Name = "txpoliid"
        Me.txpoliid.ReadOnly = True
        Me.txpoliid.Size = New System.Drawing.Size(43, 21)
        Me.txpoliid.TabIndex = 98
        Me.txpoliid.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GridControlTindakan)
        Me.GroupBox1.Controls.Add(Me.GridControl1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 263)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(679, 209)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Summary Tindakan"
        '
        'GridControlTindakan
        '
        Me.GridControlTindakan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControlTindakan.EmbeddedNavigator.Name = ""
        Me.GridControlTindakan.Location = New System.Drawing.Point(3, 16)
        Me.GridControlTindakan.MainView = Me.GridView2
        Me.GridControlTindakan.Name = "GridControlTindakan"
        Me.GridControlTindakan.Size = New System.Drawing.Size(673, 190)
        Me.GridControlTindakan.TabIndex = 1
        Me.GridControlTindakan.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GridControlTindakan
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsBehavior.Editable = False
        Me.GridView2.OptionsCustomization.AllowGroup = False
        Me.GridView2.OptionsView.ShowAutoFilterRow = True
        Me.GridView2.OptionsView.ShowGroupPanel = False
        Me.GridView2.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowForFocusedRow
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.EmbeddedNavigator.Name = ""
        Me.GridControl1.Location = New System.Drawing.Point(3, 16)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(673, 190)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsCustomization.AllowGroup = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowForFocusedRow
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(38, 48)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 15)
        Me.Label9.TabIndex = 97
        Me.Label9.Text = "No Urut"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextBoxKeteranganVoucher)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.CheckBoxStatusPembelianPaket)
        Me.GroupBox2.Controls.Add(Me.ButtonCetakInvoice)
        Me.GroupBox2.Controls.Add(Me.txtotalrow)
        Me.GroupBox2.Controls.Add(Me.TextBoxNomorRM)
        Me.GroupBox2.Controls.Add(Me.txpoliid)
        Me.GroupBox2.Controls.Add(Me.txadmin)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.TextBoxNomorTransaksi)
        Me.GroupBox2.Controls.Add(Me.txcustlp)
        Me.GroupBox2.Controls.Add(Me.txumur)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.cmbjenis)
        Me.GroupBox2.Controls.Add(Me.txrequest)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.TextBoxNamaDokter)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txcustnama)
        Me.GroupBox2.Controls.Add(Me.dttanggal)
        Me.GroupBox2.Controls.Add(Me.txtotal)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.dtcusttgllhr)
        Me.GroupBox2.Controls.Add(Me.butfind)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 24)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(679, 239)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        '
        'TextBoxKeteranganVoucher
        '
        Me.TextBoxKeteranganVoucher.BackColor = System.Drawing.Color.White
        Me.TextBoxKeteranganVoucher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxKeteranganVoucher.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBoxKeteranganVoucher.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TextBoxKeteranganVoucher.Location = New System.Drawing.Point(184, 174)
        Me.TextBoxKeteranganVoucher.Name = "TextBoxKeteranganVoucher"
        Me.TextBoxKeteranganVoucher.ReadOnly = True
        Me.TextBoxKeteranganVoucher.Size = New System.Drawing.Size(137, 23)
        Me.TextBoxKeteranganVoucher.TabIndex = 597
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(26, 176)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(101, 15)
        Me.Label5.TabIndex = 596
        Me.Label5.Text = "Pembelian Paket"
        '
        'CheckBoxStatusPembelianPaket
        '
        Me.CheckBoxStatusPembelianPaket.AutoSize = True
        Me.CheckBoxStatusPembelianPaket.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.CheckBoxStatusPembelianPaket.Location = New System.Drawing.Point(138, 174)
        Me.CheckBoxStatusPembelianPaket.Name = "CheckBoxStatusPembelianPaket"
        Me.CheckBoxStatusPembelianPaket.Size = New System.Drawing.Size(40, 21)
        Me.CheckBoxStatusPembelianPaket.TabIndex = 595
        Me.CheckBoxStatusPembelianPaket.Text = "Ya"
        Me.CheckBoxStatusPembelianPaket.UseVisualStyleBackColor = True
        '
        'ButtonCetakInvoice
        '
        Me.ButtonCetakInvoice.BackColor = System.Drawing.Color.White
        Me.ButtonCetakInvoice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonCetakInvoice.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonCetakInvoice.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCetakInvoice.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCetakInvoice.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonCetakInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCetakInvoice.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ButtonCetakInvoice.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCetakInvoice.Location = New System.Drawing.Point(360, 180)
        Me.ButtonCetakInvoice.Name = "ButtonCetakInvoice"
        Me.ButtonCetakInvoice.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonCetakInvoice.Size = New System.Drawing.Size(207, 25)
        Me.ButtonCetakInvoice.TabIndex = 594
        Me.ButtonCetakInvoice.Text = "Cetak Invoice"
        Me.ButtonCetakInvoice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonCetakInvoice.UseVisualStyleBackColor = False
        '
        'txtotalrow
        '
        Me.txtotalrow.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtotalrow.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtotalrow.Location = New System.Drawing.Point(449, 146)
        Me.txtotalrow.Name = "txtotalrow"
        Me.txtotalrow.Size = New System.Drawing.Size(100, 21)
        Me.txtotalrow.TabIndex = 128
        Me.txtotalrow.Visible = False
        '
        'TextBoxNomorRM
        '
        Me.TextBoxNomorRM.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBoxNomorRM.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxNomorRM.Location = New System.Drawing.Point(93, 71)
        Me.TextBoxNomorRM.Name = "TextBoxNomorRM"
        Me.TextBoxNomorRM.ReadOnly = True
        Me.TextBoxNomorRM.Size = New System.Drawing.Size(228, 21)
        Me.TextBoxNomorRM.TabIndex = 133
        '
        'txadmin
        '
        Me.txadmin.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txadmin.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txadmin.Location = New System.Drawing.Point(449, 146)
        Me.txadmin.Name = "txadmin"
        Me.txadmin.Size = New System.Drawing.Size(224, 21)
        Me.txadmin.TabIndex = 132
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(399, 149)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 15)
        Me.Label3.TabIndex = 131
        Me.Label3.Text = "Admin"
        '
        'TextBoxNomorTransaksi
        '
        Me.TextBoxNomorTransaksi.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBoxNomorTransaksi.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxNomorTransaksi.Location = New System.Drawing.Point(93, 45)
        Me.TextBoxNomorTransaksi.Name = "TextBoxNomorTransaksi"
        Me.TextBoxNomorTransaksi.ReadOnly = True
        Me.TextBoxNomorTransaksi.Size = New System.Drawing.Size(187, 21)
        Me.TextBoxNomorTransaksi.TabIndex = 130
        '
        'txcustlp
        '
        Me.txcustlp.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txcustlp.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txcustlp.Location = New System.Drawing.Point(286, 98)
        Me.txcustlp.Name = "txcustlp"
        Me.txcustlp.ReadOnly = True
        Me.txcustlp.Size = New System.Drawing.Size(35, 21)
        Me.txcustlp.TabIndex = 129
        '
        'txumur
        '
        Me.txumur.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txumur.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txumur.Location = New System.Drawing.Point(209, 125)
        Me.txumur.Name = "txumur"
        Me.txumur.ReadOnly = True
        Me.txumur.Size = New System.Drawing.Size(112, 21)
        Me.txumur.TabIndex = 128
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(50, 25)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(37, 15)
        Me.Label10.TabIndex = 127
        Me.Label10.Text = "Jenis"
        '
        'cmbjenis
        '
        Me.cmbjenis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbjenis.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbjenis.FormattingEnabled = True
        Me.cmbjenis.Items.AddRange(New Object() {"AWALPOLI", "AWALGIGI", "LAB", "POLI", "GIGI"})
        Me.cmbjenis.Location = New System.Drawing.Point(93, 19)
        Me.cmbjenis.Name = "cmbjenis"
        Me.cmbjenis.Size = New System.Drawing.Size(110, 23)
        Me.cmbjenis.TabIndex = 126
        '
        'txrequest
        '
        Me.txrequest.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txrequest.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txrequest.Location = New System.Drawing.Point(449, 120)
        Me.txrequest.Name = "txrequest"
        Me.txrequest.Size = New System.Drawing.Size(224, 21)
        Me.txrequest.TabIndex = 125
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(348, 123)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(93, 15)
        Me.Label8.TabIndex = 124
        Me.Label8.Text = "Dokter Request"
        '
        'TextBoxNamaDokter
        '
        Me.TextBoxNamaDokter.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBoxNamaDokter.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxNamaDokter.Location = New System.Drawing.Point(449, 94)
        Me.TextBoxNamaDokter.Name = "TextBoxNamaDokter"
        Me.TextBoxNamaDokter.Size = New System.Drawing.Size(224, 21)
        Me.TextBoxNamaDokter.TabIndex = 123
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(361, 97)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 15)
        Me.Label7.TabIndex = 122
        Me.Label7.Text = "Nama Dokter"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(32, 128)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(55, 15)
        Me.Label6.TabIndex = 120
        Me.Label6.Text = "Tgl Lahir"
        '
        'txcustnama
        '
        Me.txcustnama.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txcustnama.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txcustnama.Location = New System.Drawing.Point(93, 98)
        Me.txcustnama.Name = "txcustnama"
        Me.txcustnama.ReadOnly = True
        Me.txcustnama.Size = New System.Drawing.Size(187, 21)
        Me.txcustnama.TabIndex = 117
        '
        'dttanggal
        '
        Me.dttanggal.CustomFormat = "dd-MMM-yyyy"
        Me.dttanggal.Enabled = False
        Me.dttanggal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dttanggal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dttanggal.Location = New System.Drawing.Point(209, 20)
        Me.dttanggal.Name = "dttanggal"
        Me.dttanggal.Size = New System.Drawing.Size(112, 21)
        Me.dttanggal.TabIndex = 116
        '
        'txtotal
        '
        Me.txtotal.Enabled = False
        Me.txtotal.Location = New System.Drawing.Point(449, 68)
        Me.txtotal.Name = "txtotal"
        Me.txtotal.Properties.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtotal.Properties.Appearance.Options.UseFont = True
        Me.txtotal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtotal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtotal.Properties.Mask.EditMask = "n0"
        Me.txtotal.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtotal.Size = New System.Drawing.Size(162, 21)
        Me.txtotal.TabIndex = 114
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(335, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 15)
        Me.Label4.TabIndex = 113
        Me.Label4.Text = "Total Pembayaran"
        '
        'dtcusttgllhr
        '
        Me.dtcusttgllhr.CustomFormat = "dd-MMM-yyyy"
        Me.dtcusttgllhr.Enabled = False
        Me.dtcusttgllhr.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtcusttgllhr.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtcusttgllhr.Location = New System.Drawing.Point(93, 125)
        Me.dtcusttgllhr.Name = "dtcusttgllhr"
        Me.dtcusttgllhr.Size = New System.Drawing.Size(110, 21)
        Me.dtcusttgllhr.TabIndex = 112
        '
        'butfind
        '
        Me.butfind.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butfind.Location = New System.Drawing.Point(286, 43)
        Me.butfind.Name = "butfind"
        Me.butfind.Size = New System.Drawing.Size(35, 25)
        Me.butfind.TabIndex = 6
        Me.butfind.Text = "..."
        Me.butfind.UseVisualStyleBackColor = True
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.PrintToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(963, 24)
        Me.MenuStrip1.TabIndex = 5
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.NewToolStripMenuItem.Text = "Clear"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.gridbayar)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox3.Location = New System.Drawing.Point(679, 24)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(284, 448)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Pembayaran"
        '
        'gridbayar
        '
        Me.gridbayar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridbayar.EmbeddedNavigator.Name = ""
        Me.gridbayar.Location = New System.Drawing.Point(3, 16)
        Me.gridbayar.MainView = Me.GridView3
        Me.gridbayar.Name = "gridbayar"
        Me.gridbayar.Size = New System.Drawing.Size(278, 429)
        Me.gridbayar.TabIndex = 2
        Me.gridbayar.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.gridbayar
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsBehavior.Editable = False
        Me.GridView3.OptionsCustomization.AllowGroup = False
        Me.GridView3.OptionsView.ShowAutoFilterRow = True
        Me.GridView3.OptionsView.ShowGroupPanel = False
        Me.GridView3.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowForFocusedRow
        '
        'FormCetakInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(963, 472)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormCetakInvoice"
        Me.Text = "Cetak Ulang Invoice Pembayaran"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.GridControlTindakan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.txtotal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.gridbayar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txpoliid As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents butfind As System.Windows.Forms.Button
    Friend WithEvents dtcusttgllhr As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtotal As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dttanggal As System.Windows.Forms.DateTimePicker
    Friend WithEvents txcustnama As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNamaDokter As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txrequest As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbjenis As System.Windows.Forms.ComboBox
    Friend WithEvents txumur As System.Windows.Forms.TextBox
    Friend WithEvents txtotalrow As System.Windows.Forms.TextBox
    Friend WithEvents txcustlp As System.Windows.Forms.TextBox
    Friend WithEvents GridControlTindakan As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TextBoxNomorTransaksi As System.Windows.Forms.TextBox
    Friend WithEvents txadmin As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents gridbayar As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TextBoxNomorRM As System.Windows.Forms.TextBox
    Friend WithEvents ButtonCetakInvoice As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxStatusPembelianPaket As System.Windows.Forms.CheckBox
    Friend WithEvents TextBoxKeteranganVoucher As System.Windows.Forms.TextBox
End Class
