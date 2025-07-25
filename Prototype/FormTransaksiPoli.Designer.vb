<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTransaksiPoli
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormTransaksiPoli))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.gridtindakan = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.MenuStrip5 = New System.Windows.Forms.MenuStrip
        Me.ToolStripTextBox1 = New System.Windows.Forms.ToolStripTextBox
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.butkalkulasi = New System.Windows.Forms.Button
        Me.ButtonSimpanTransaksi = New System.Windows.Forms.Button
        Me.TextBoxTotalBayar = New DevExpress.XtraEditors.TextEdit
        Me.Label11 = New System.Windows.Forms.Label
        Me.TextBoxTotalPembulatan = New DevExpress.XtraEditors.TextEdit
        Me.Label9 = New System.Windows.Forms.Label
        Me.TextBoxTotalBruto = New DevExpress.XtraEditors.TextEdit
        Me.Label6 = New System.Windows.Forms.Label
        Me.TextBoxTotalDiskon = New DevExpress.XtraEditors.TextEdit
        Me.Label5 = New System.Windows.Forms.Label
        Me.TextBoxTotalNett = New DevExpress.XtraEditors.TextEdit
        Me.Label8 = New System.Windows.Forms.Label
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBoxDetailPasien = New System.Windows.Forms.GroupBox
        Me.ButtonFindTransaksi = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.TextBoxNamaPoli = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.TextBoxNoRekamMedis = New System.Windows.Forms.TextBox
        Me.TextBoxNamaDokter = New System.Windows.Forms.TextBox
        Me.chkclosed = New System.Windows.Forms.CheckBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TextBoxNamaPasien = New System.Windows.Forms.TextBox
        Me.dtcusttgllhr = New System.Windows.Forms.DateTimePicker
        Me.TextBoxUmurPasien = New System.Windows.Forms.TextBox
        Me.dtnow = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBoxNoUrutTransaksi = New System.Windows.Forms.TextBox
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.TimerCekTransaksiBaru = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox2.SuspendLayout()
        CType(Me.gridtindakan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip5.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.TextBoxTotalBayar.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxTotalPembulatan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxTotalBruto.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxTotalDiskon.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxTotalNett.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxDetailPasien.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.gridtindakan)
        Me.GroupBox2.Controls.Add(Me.MenuStrip5)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 174)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(959, 243)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detail"
        '
        'gridtindakan
        '
        Me.gridtindakan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridtindakan.EmbeddedNavigator.Name = ""
        Me.gridtindakan.Location = New System.Drawing.Point(3, 40)
        Me.gridtindakan.MainView = Me.GridView1
        Me.gridtindakan.Name = "gridtindakan"
        Me.gridtindakan.Size = New System.Drawing.Size(953, 200)
        Me.gridtindakan.TabIndex = 3
        Me.gridtindakan.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.gridtindakan
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        '
        'MenuStrip5
        '
        Me.MenuStrip5.AllowMerge = False
        Me.MenuStrip5.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.MenuStrip5.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripTextBox1})
        Me.MenuStrip5.Location = New System.Drawing.Point(3, 16)
        Me.MenuStrip5.Name = "MenuStrip5"
        Me.MenuStrip5.Size = New System.Drawing.Size(953, 24)
        Me.MenuStrip5.TabIndex = 4
        Me.MenuStrip5.Text = "MenuStrip5"
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ToolStripTextBox1.Enabled = False
        Me.ToolStripTextBox1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.ReadOnly = True
        Me.ToolStripTextBox1.Size = New System.Drawing.Size(300, 20)
        Me.ToolStripTextBox1.Text = "Tambah Tindakan Melalui Form Rekam Medis Dokter."
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.butkalkulasi)
        Me.GroupBox1.Controls.Add(Me.ButtonSimpanTransaksi)
        Me.GroupBox1.Controls.Add(Me.TextBoxTotalBayar)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.TextBoxTotalPembulatan)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.TextBoxTotalBruto)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.TextBoxTotalDiskon)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TextBoxTotalNett)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(0, 417)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(959, 136)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Summary Total"
        '
        'butkalkulasi
        '
        Me.butkalkulasi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.butkalkulasi.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butkalkulasi.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_kalkulasi
        Me.butkalkulasi.Location = New System.Drawing.Point(763, 42)
        Me.butkalkulasi.Name = "butkalkulasi"
        Me.butkalkulasi.Size = New System.Drawing.Size(100, 36)
        Me.butkalkulasi.TabIndex = 126
        Me.butkalkulasi.UseVisualStyleBackColor = True
        '
        'ButtonSimpanTransaksi
        '
        Me.ButtonSimpanTransaksi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonSimpanTransaksi.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ButtonSimpanTransaksi.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_save
        Me.ButtonSimpanTransaksi.Location = New System.Drawing.Point(661, 42)
        Me.ButtonSimpanTransaksi.Name = "ButtonSimpanTransaksi"
        Me.ButtonSimpanTransaksi.Size = New System.Drawing.Size(100, 36)
        Me.ButtonSimpanTransaksi.TabIndex = 121
        Me.ButtonSimpanTransaksi.UseVisualStyleBackColor = True
        '
        'TextBoxTotalBayar
        '
        Me.TextBoxTotalBayar.Enabled = False
        Me.TextBoxTotalBayar.Location = New System.Drawing.Point(530, 50)
        Me.TextBoxTotalBayar.Name = "TextBoxTotalBayar"
        Me.TextBoxTotalBayar.Properties.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxTotalBayar.Properties.Appearance.Options.UseFont = True
        Me.TextBoxTotalBayar.Size = New System.Drawing.Size(125, 21)
        Me.TextBoxTotalBayar.TabIndex = 120
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(527, 30)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(80, 16)
        Me.Label11.TabIndex = 119
        Me.Label11.Text = "Total Bayar"
        '
        'TextBoxTotalPembulatan
        '
        Me.TextBoxTotalPembulatan.Location = New System.Drawing.Point(400, 50)
        Me.TextBoxTotalPembulatan.Name = "TextBoxTotalPembulatan"
        Me.TextBoxTotalPembulatan.Properties.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxTotalPembulatan.Properties.Appearance.Options.UseFont = True
        Me.TextBoxTotalPembulatan.Size = New System.Drawing.Size(125, 21)
        Me.TextBoxTotalPembulatan.TabIndex = 118
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label9.Location = New System.Drawing.Point(397, 30)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 16)
        Me.Label9.TabIndex = 117
        Me.Label9.Text = "Pembulatan"
        '
        'TextBoxTotalBruto
        '
        Me.TextBoxTotalBruto.Enabled = False
        Me.TextBoxTotalBruto.Location = New System.Drawing.Point(10, 50)
        Me.TextBoxTotalBruto.Name = "TextBoxTotalBruto"
        Me.TextBoxTotalBruto.Properties.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxTotalBruto.Properties.Appearance.Options.UseFont = True
        Me.TextBoxTotalBruto.Size = New System.Drawing.Size(125, 21)
        Me.TextBoxTotalBruto.TabIndex = 116
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label6.Location = New System.Drawing.Point(7, 30)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 16)
        Me.Label6.TabIndex = 115
        Me.Label6.Text = "Total Biaya"
        '
        'TextBoxTotalDiskon
        '
        Me.TextBoxTotalDiskon.Enabled = False
        Me.TextBoxTotalDiskon.Location = New System.Drawing.Point(140, 50)
        Me.TextBoxTotalDiskon.Name = "TextBoxTotalDiskon"
        Me.TextBoxTotalDiskon.Properties.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxTotalDiskon.Properties.Appearance.Options.UseFont = True
        Me.TextBoxTotalDiskon.Size = New System.Drawing.Size(125, 21)
        Me.TextBoxTotalDiskon.TabIndex = 114
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label5.Location = New System.Drawing.Point(137, 30)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 16)
        Me.Label5.TabIndex = 113
        Me.Label5.Text = "Total Diskon"
        '
        'TextBoxTotalNett
        '
        Me.TextBoxTotalNett.Enabled = False
        Me.TextBoxTotalNett.Location = New System.Drawing.Point(270, 50)
        Me.TextBoxTotalNett.Name = "TextBoxTotalNett"
        Me.TextBoxTotalNett.Properties.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxTotalNett.Properties.Appearance.Options.UseFont = True
        Me.TextBoxTotalNett.Size = New System.Drawing.Size(125, 21)
        Me.TextBoxTotalNett.TabIndex = 111
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.Label8.Location = New System.Drawing.Point(267, 30)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(63, 16)
        Me.Label8.TabIndex = 110
        Me.Label8.Text = "Total Nett"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'GroupBoxDetailPasien
        '
        Me.GroupBoxDetailPasien.BackColor = System.Drawing.Color.White
        Me.GroupBoxDetailPasien.Controls.Add(Me.ButtonFindTransaksi)
        Me.GroupBoxDetailPasien.Controls.Add(Me.Label13)
        Me.GroupBoxDetailPasien.Controls.Add(Me.TextBoxNamaPoli)
        Me.GroupBoxDetailPasien.Controls.Add(Me.Label12)
        Me.GroupBoxDetailPasien.Controls.Add(Me.TextBoxNoRekamMedis)
        Me.GroupBoxDetailPasien.Controls.Add(Me.TextBoxNamaDokter)
        Me.GroupBoxDetailPasien.Controls.Add(Me.chkclosed)
        Me.GroupBoxDetailPasien.Controls.Add(Me.Label10)
        Me.GroupBoxDetailPasien.Controls.Add(Me.TextBoxNamaPasien)
        Me.GroupBoxDetailPasien.Controls.Add(Me.dtcusttgllhr)
        Me.GroupBoxDetailPasien.Controls.Add(Me.TextBoxUmurPasien)
        Me.GroupBoxDetailPasien.Controls.Add(Me.dtnow)
        Me.GroupBoxDetailPasien.Controls.Add(Me.Label7)
        Me.GroupBoxDetailPasien.Controls.Add(Me.Label4)
        Me.GroupBoxDetailPasien.Controls.Add(Me.Label3)
        Me.GroupBoxDetailPasien.Controls.Add(Me.Label2)
        Me.GroupBoxDetailPasien.Controls.Add(Me.Label1)
        Me.GroupBoxDetailPasien.Controls.Add(Me.TextBoxNoUrutTransaksi)
        Me.GroupBoxDetailPasien.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBoxDetailPasien.Location = New System.Drawing.Point(0, 24)
        Me.GroupBoxDetailPasien.Name = "GroupBoxDetailPasien"
        Me.GroupBoxDetailPasien.Size = New System.Drawing.Size(959, 150)
        Me.GroupBoxDetailPasien.TabIndex = 9
        Me.GroupBoxDetailPasien.TabStop = False
        '
        'ButtonFindTransaksi
        '
        Me.ButtonFindTransaksi.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindTransaksi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonFindTransaksi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonFindTransaksi.FlatAppearance.BorderSize = 0
        Me.ButtonFindTransaksi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindTransaksi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonFindTransaksi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonFindTransaksi.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonFindTransaksi.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ButtonFindTransaksi.Location = New System.Drawing.Point(317, 20)
        Me.ButtonFindTransaksi.Name = "ButtonFindTransaksi"
        Me.ButtonFindTransaksi.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonFindTransaksi.Size = New System.Drawing.Size(60, 25)
        Me.ButtonFindTransaksi.TabIndex = 443
        Me.ButtonFindTransaksi.Text = " Cari"
        Me.ButtonFindTransaksi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonFindTransaksi.UseVisualStyleBackColor = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label13.Location = New System.Drawing.Point(42, 85)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(50, 17)
        Me.Label13.TabIndex = 188
        Me.Label13.Text = "No RM"
        '
        'TextBoxNamaPoli
        '
        Me.TextBoxNamaPoli.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBoxNamaPoli.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxNamaPoli.Location = New System.Drawing.Point(127, 113)
        Me.TextBoxNamaPoli.Name = "TextBoxNamaPoli"
        Me.TextBoxNamaPoli.ReadOnly = True
        Me.TextBoxNamaPoli.Size = New System.Drawing.Size(250, 25)
        Me.TextBoxNamaPoli.TabIndex = 187
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(18, 116)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(74, 17)
        Me.Label12.TabIndex = 186
        Me.Label12.Text = "Poli Tujuan"
        '
        'TextBoxNoRekamMedis
        '
        Me.TextBoxNoRekamMedis.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBoxNoRekamMedis.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxNoRekamMedis.Location = New System.Drawing.Point(127, 82)
        Me.TextBoxNoRekamMedis.Name = "TextBoxNoRekamMedis"
        Me.TextBoxNoRekamMedis.ReadOnly = True
        Me.TextBoxNoRekamMedis.Size = New System.Drawing.Size(250, 25)
        Me.TextBoxNoRekamMedis.TabIndex = 185
        '
        'TextBoxNamaDokter
        '
        Me.TextBoxNamaDokter.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBoxNamaDokter.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxNamaDokter.Location = New System.Drawing.Point(530, 20)
        Me.TextBoxNamaDokter.Name = "TextBoxNamaDokter"
        Me.TextBoxNamaDokter.ReadOnly = True
        Me.TextBoxNamaDokter.Size = New System.Drawing.Size(250, 25)
        Me.TextBoxNamaDokter.TabIndex = 184
        '
        'chkclosed
        '
        Me.chkclosed.AutoSize = True
        Me.chkclosed.Enabled = False
        Me.chkclosed.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.chkclosed.Location = New System.Drawing.Point(661, 84)
        Me.chkclosed.Name = "chkclosed"
        Me.chkclosed.Size = New System.Drawing.Size(67, 21)
        Me.chkclosed.TabIndex = 5
        Me.chkclosed.Text = "Closed"
        Me.chkclosed.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(446, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 17)
        Me.Label10.TabIndex = 100
        Me.Label10.Text = "Dokter"
        '
        'TextBoxNamaPasien
        '
        Me.TextBoxNamaPasien.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBoxNamaPasien.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxNamaPasien.Location = New System.Drawing.Point(127, 51)
        Me.TextBoxNamaPasien.Name = "TextBoxNamaPasien"
        Me.TextBoxNamaPasien.ReadOnly = True
        Me.TextBoxNamaPasien.Size = New System.Drawing.Size(250, 25)
        Me.TextBoxNamaPasien.TabIndex = 61
        '
        'dtcusttgllhr
        '
        Me.dtcusttgllhr.CustomFormat = "dd-MMM-yyyy"
        Me.dtcusttgllhr.Enabled = False
        Me.dtcusttgllhr.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.dtcusttgllhr.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtcusttgllhr.Location = New System.Drawing.Point(530, 113)
        Me.dtcusttgllhr.Name = "dtcusttgllhr"
        Me.dtcusttgllhr.Size = New System.Drawing.Size(125, 25)
        Me.dtcusttgllhr.TabIndex = 60
        '
        'TextBoxUmurPasien
        '
        Me.TextBoxUmurPasien.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBoxUmurPasien.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxUmurPasien.Location = New System.Drawing.Point(530, 51)
        Me.TextBoxUmurPasien.Name = "TextBoxUmurPasien"
        Me.TextBoxUmurPasien.ReadOnly = True
        Me.TextBoxUmurPasien.Size = New System.Drawing.Size(250, 25)
        Me.TextBoxUmurPasien.TabIndex = 6
        '
        'dtnow
        '
        Me.dtnow.CustomFormat = "dd-MMM-yyyy"
        Me.dtnow.Enabled = False
        Me.dtnow.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.dtnow.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtnow.Location = New System.Drawing.Point(530, 82)
        Me.dtnow.Name = "dtnow"
        Me.dtnow.Size = New System.Drawing.Size(125, 25)
        Me.dtnow.TabIndex = 62
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(411, 88)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(84, 17)
        Me.Label7.TabIndex = 61
        Me.Label7.Text = "Tgl Transaksi"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(453, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 17)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Umur"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(437, 119)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 17)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Tgl Lahir"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(48, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nama"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(12, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Transaksi ID"
        '
        'TextBoxNoUrutTransaksi
        '
        Me.TextBoxNoUrutTransaksi.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBoxNoUrutTransaksi.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxNoUrutTransaksi.Location = New System.Drawing.Point(127, 20)
        Me.TextBoxNoUrutTransaksi.Name = "TextBoxNoUrutTransaksi"
        Me.TextBoxNoUrutTransaksi.ReadOnly = True
        Me.TextBoxNoUrutTransaksi.Size = New System.Drawing.Size(184, 25)
        Me.TextBoxNoUrutTransaksi.TabIndex = 133
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.CloseToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(959, 24)
        Me.MenuStrip1.TabIndex = 8
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'TimerCekTransaksiBaru
        '
        Me.TimerCekTransaksiBaru.Enabled = True
        Me.TimerCekTransaksiBaru.Interval = 5000
        '
        'FormTransaksiPoli
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(959, 553)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBoxDetailPasien)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormTransaksiPoli"
        Me.Text = "Kasir Poli Umum"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.gridtindakan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip5.ResumeLayout(False)
        Me.MenuStrip5.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.TextBoxTotalBayar.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxTotalPembulatan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxTotalBruto.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxTotalDiskon.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxTotalNett.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxDetailPasien.ResumeLayout(False)
        Me.GroupBoxDetailPasien.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents gridtindakan As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents MenuStrip5 As System.Windows.Forms.MenuStrip
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonSimpanTransaksi As System.Windows.Forms.Button
    Friend WithEvents TextBoxTotalBayar As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextBoxTotalPembulatan As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextBoxTotalBruto As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBoxTotalDiskon As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBoxTotalNett As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBoxDetailPasien As System.Windows.Forms.GroupBox
    Friend WithEvents chkclosed As System.Windows.Forms.CheckBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNamaPasien As System.Windows.Forms.TextBox
    Friend WithEvents dtcusttgllhr As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextBoxUmurPasien As System.Windows.Forms.TextBox
    Friend WithEvents dtnow As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents butkalkulasi As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNoUrutTransaksi As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxNamaDokter As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxNoRekamMedis As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNamaPoli As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ButtonFindTransaksi As System.Windows.Forms.Button
    Friend WithEvents ToolStripTextBox1 As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents TimerCekTransaksiBaru As System.Windows.Forms.Timer
End Class
