<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCetakBarcode
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCetakBarcode))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CetakBarcodeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.BarcodeTambahanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CheckBoxAktivo = New System.Windows.Forms.CheckBox
        Me.CheckBoxInbody = New System.Windows.Forms.CheckBox
        Me.rdNonMCU = New System.Windows.Forms.RadioButton
        Me.rdMCU = New System.Windows.Forms.RadioButton
        Me.cbtabung = New System.Windows.Forms.CheckBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmbkodetransaksi = New System.Windows.Forms.ComboBox
        Me.txNoUrut2 = New System.Windows.Forms.TextBox
        Me.txNoUrut1 = New System.Windows.Forms.TextBox
        Me.txkodecabang = New System.Windows.Forms.TextBox
        Me.txcompanycode = New System.Windows.Forms.TextBox
        Me.cbNoUrut = New System.Windows.Forms.CheckBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.butfindcompany = New System.Windows.Forms.Button
        Me.Label16 = New System.Windows.Forms.Label
        Me.dtprocess = New System.Windows.Forms.DateTimePicker
        Me.buttambahpasienmcu = New System.Windows.Forms.Button
        Me.gridlab = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.PanelThorax = New System.Windows.Forms.GroupBox
        Me.txtAlasanThorax = New System.Windows.Forms.TextBox
        Me.rdThoraxTolak = New System.Windows.Forms.RadioButton
        Me.rdThoraxSetuju = New System.Windows.Forms.RadioButton
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.RadioButtonFalse = New System.Windows.Forms.RadioButton
        Me.RadioButtonHaid = New System.Windows.Forms.RadioButton
        Me.RadioButtonHamil = New System.Windows.Forms.RadioButton
        Me.ButtonCariPasien = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.TextBoxScanHyu = New System.Windows.Forms.TextBox
        Me.txtindakan = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txNoMitra1 = New System.Windows.Forms.TextBox
        Me.txTransLabID1 = New System.Windows.Forms.TextBox
        Me.buttambahpasien = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBoxJenisKelamin = New System.Windows.Forms.TextBox
        Me.txtindakanid = New System.Windows.Forms.TextBox
        Me.dtcusttgllhr = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.txcustumur = New System.Windows.Forms.TextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.txcustnama = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.lblStatusMCU = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.gridlab, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.PanelThorax.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.CetakBarcodeToolStripMenuItem, Me.BarcodeTambahanToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(872, 24)
        Me.MenuStrip1.TabIndex = 149
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(65, 20)
        Me.NewToolStripMenuItem.Text = "Set Clear"
        '
        'CetakBarcodeToolStripMenuItem
        '
        Me.CetakBarcodeToolStripMenuItem.Name = "CetakBarcodeToolStripMenuItem"
        Me.CetakBarcodeToolStripMenuItem.Size = New System.Drawing.Size(95, 20)
        Me.CetakBarcodeToolStripMenuItem.Text = "Cetak Barcode"
        '
        'BarcodeTambahanToolStripMenuItem
        '
        Me.BarcodeTambahanToolStripMenuItem.Name = "BarcodeTambahanToolStripMenuItem"
        Me.BarcodeTambahanToolStripMenuItem.Size = New System.Drawing.Size(121, 20)
        Me.BarcodeTambahanToolStripMenuItem.Text = "Barcode Tambahan"
        '
        'GroupBox2
        '
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox2.Location = New System.Drawing.Point(0, 447)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(872, 10)
        Me.GroupBox2.TabIndex = 152
        Me.GroupBox2.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckBoxAktivo)
        Me.GroupBox1.Controls.Add(Me.CheckBoxInbody)
        Me.GroupBox1.Controls.Add(Me.rdNonMCU)
        Me.GroupBox1.Controls.Add(Me.rdMCU)
        Me.GroupBox1.Controls.Add(Me.cbtabung)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(872, 73)
        Me.GroupBox1.TabIndex = 150
        Me.GroupBox1.TabStop = False
        '
        'CheckBoxAktivo
        '
        Me.CheckBoxAktivo.AutoSize = True
        Me.CheckBoxAktivo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxAktivo.Location = New System.Drawing.Point(321, 40)
        Me.CheckBoxAktivo.Name = "CheckBoxAktivo"
        Me.CheckBoxAktivo.Size = New System.Drawing.Size(125, 19)
        Me.CheckBoxAktivo.TabIndex = 250
        Me.CheckBoxAktivo.Text = "Medscape (Aktivo)"
        Me.CheckBoxAktivo.UseVisualStyleBackColor = True
        '
        'CheckBoxInbody
        '
        Me.CheckBoxInbody.AutoSize = True
        Me.CheckBoxInbody.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxInbody.Location = New System.Drawing.Point(252, 40)
        Me.CheckBoxInbody.Name = "CheckBoxInbody"
        Me.CheckBoxInbody.Size = New System.Drawing.Size(63, 19)
        Me.CheckBoxInbody.TabIndex = 249
        Me.CheckBoxInbody.Text = "InBody"
        Me.CheckBoxInbody.UseVisualStyleBackColor = True
        '
        'rdNonMCU
        '
        Me.rdNonMCU.AutoSize = True
        Me.rdNonMCU.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdNonMCU.Location = New System.Drawing.Point(147, 15)
        Me.rdNonMCU.Name = "rdNonMCU"
        Me.rdNonMCU.Size = New System.Drawing.Size(102, 19)
        Me.rdNonMCU.TabIndex = 194
        Me.rdNonMCU.Text = "Per Transaksi"
        Me.rdNonMCU.UseVisualStyleBackColor = True
        '
        'rdMCU
        '
        Me.rdMCU.AutoSize = True
        Me.rdMCU.Checked = True
        Me.rdMCU.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdMCU.Location = New System.Drawing.Point(250, 15)
        Me.rdMCU.Name = "rdMCU"
        Me.rdMCU.Size = New System.Drawing.Size(154, 19)
        Me.rdMCU.TabIndex = 193
        Me.rdMCU.TabStop = True
        Me.rdMCU.Text = "MCU (Multiple Barcode)"
        Me.rdMCU.UseVisualStyleBackColor = True
        '
        'cbtabung
        '
        Me.cbtabung.AutoSize = True
        Me.cbtabung.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbtabung.Location = New System.Drawing.Point(147, 40)
        Me.cbtabung.Name = "cbtabung"
        Me.cbtabung.Size = New System.Drawing.Size(99, 20)
        Me.cbtabung.TabIndex = 248
        Me.cbtabung.Text = "Print Tabung"
        Me.cbtabung.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(13, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(128, 16)
        Me.Label7.TabIndex = 139
        Me.Label7.Text = "Jenis Pemeriksaan"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Controls.Add(Me.cmbkodetransaksi)
        Me.TabPage2.Controls.Add(Me.txNoUrut2)
        Me.TabPage2.Controls.Add(Me.txNoUrut1)
        Me.TabPage2.Controls.Add(Me.txkodecabang)
        Me.TabPage2.Controls.Add(Me.txcompanycode)
        Me.TabPage2.Controls.Add(Me.cbNoUrut)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.butfindcompany)
        Me.TabPage2.Controls.Add(Me.Label16)
        Me.TabPage2.Controls.Add(Me.dtprocess)
        Me.TabPage2.Controls.Add(Me.buttambahpasienmcu)
        Me.TabPage2.Controls.Add(Me.gridlab)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(864, 322)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "MCU (Multiple Barcode)"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(447, 49)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 16)
        Me.Label8.TabIndex = 241
        Me.Label8.Text = "Kode"
        '
        'cmbkodetransaksi
        '
        Me.cmbkodetransaksi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbkodetransaksi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbkodetransaksi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbkodetransaksi.FormattingEnabled = True
        Me.cmbkodetransaksi.Items.AddRange(New Object() {"M", "L"})
        Me.cmbkodetransaksi.Location = New System.Drawing.Point(494, 46)
        Me.cmbkodetransaksi.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbkodetransaksi.Name = "cmbkodetransaksi"
        Me.cmbkodetransaksi.Size = New System.Drawing.Size(65, 23)
        Me.cmbkodetransaksi.TabIndex = 222
        '
        'txNoUrut2
        '
        Me.txNoUrut2.BackColor = System.Drawing.SystemColors.Window
        Me.txNoUrut2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txNoUrut2.Location = New System.Drawing.Point(362, 45)
        Me.txNoUrut2.Name = "txNoUrut2"
        Me.txNoUrut2.Size = New System.Drawing.Size(44, 22)
        Me.txNoUrut2.TabIndex = 246
        '
        'txNoUrut1
        '
        Me.txNoUrut1.BackColor = System.Drawing.SystemColors.Window
        Me.txNoUrut1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txNoUrut1.Location = New System.Drawing.Point(281, 45)
        Me.txNoUrut1.Name = "txNoUrut1"
        Me.txNoUrut1.Size = New System.Drawing.Size(44, 22)
        Me.txNoUrut1.TabIndex = 245
        '
        'txkodecabang
        '
        Me.txkodecabang.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txkodecabang.Location = New System.Drawing.Point(495, 17)
        Me.txkodecabang.Name = "txkodecabang"
        Me.txkodecabang.Size = New System.Drawing.Size(100, 22)
        Me.txkodecabang.TabIndex = 238
        Me.txkodecabang.Visible = False
        '
        'txcompanycode
        '
        Me.txcompanycode.BackColor = System.Drawing.SystemColors.Window
        Me.txcompanycode.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txcompanycode.Location = New System.Drawing.Point(495, 17)
        Me.txcompanycode.Name = "txcompanycode"
        Me.txcompanycode.ReadOnly = True
        Me.txcompanycode.Size = New System.Drawing.Size(217, 22)
        Me.txcompanycode.TabIndex = 241
        '
        'cbNoUrut
        '
        Me.cbNoUrut.AutoSize = True
        Me.cbNoUrut.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cbNoUrut.Location = New System.Drawing.Point(131, 47)
        Me.cbNoUrut.Name = "cbNoUrut"
        Me.cbNoUrut.Size = New System.Drawing.Size(144, 20)
        Me.cbNoUrut.TabIndex = 247
        Me.cbNoUrut.Text = "Sesuaikan No Urut"
        Me.cbNoUrut.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(331, 48)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(26, 16)
        Me.Label10.TabIndex = 246
        Me.Label10.Text = "s/d"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(184, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(91, 16)
        Me.Label9.TabIndex = 243
        Me.Label9.Text = "Tgl Transaksi"
        '
        'butfindcompany
        '
        Me.butfindcompany.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butfindcompany.Location = New System.Drawing.Point(718, 16)
        Me.butfindcompany.Name = "butfindcompany"
        Me.butfindcompany.Size = New System.Drawing.Size(31, 25)
        Me.butfindcompany.TabIndex = 242
        Me.butfindcompany.Text = "..."
        Me.butfindcompany.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(420, 20)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(68, 16)
        Me.Label16.TabIndex = 240
        Me.Label16.Text = "Company"
        '
        'dtprocess
        '
        Me.dtprocess.CustomFormat = "dd-MMM-yyyy"
        Me.dtprocess.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtprocess.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtprocess.Location = New System.Drawing.Point(281, 17)
        Me.dtprocess.Name = "dtprocess"
        Me.dtprocess.Size = New System.Drawing.Size(125, 22)
        Me.dtprocess.TabIndex = 239
        '
        'buttambahpasienmcu
        '
        Me.buttambahpasienmcu.Cursor = System.Windows.Forms.Cursors.Hand
        Me.buttambahpasienmcu.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.buttambahpasienmcu.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_add
        Me.buttambahpasienmcu.Location = New System.Drawing.Point(14, 20)
        Me.buttambahpasienmcu.Name = "buttambahpasienmcu"
        Me.buttambahpasienmcu.Size = New System.Drawing.Size(100, 36)
        Me.buttambahpasienmcu.TabIndex = 235
        Me.buttambahpasienmcu.UseVisualStyleBackColor = True
        '
        'gridlab
        '
        Me.gridlab.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gridlab.EmbeddedNavigator.Name = ""
        Me.gridlab.Location = New System.Drawing.Point(3, 172)
        Me.gridlab.MainView = Me.GridView1
        Me.gridlab.Name = "gridlab"
        Me.gridlab.Size = New System.Drawing.Size(858, 147)
        Me.gridlab.TabIndex = 152
        Me.gridlab.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.gridlab
        Me.GridView1.Name = "GridView1"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(864, 322)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Per Transaksi"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblStatusMCU)
        Me.GroupBox3.Controls.Add(Me.PanelThorax)
        Me.GroupBox3.Controls.Add(Me.GroupBox4)
        Me.GroupBox3.Controls.Add(Me.ButtonCariPasien)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.TextBoxScanHyu)
        Me.GroupBox3.Controls.Add(Me.txtindakan)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.txNoMitra1)
        Me.GroupBox3.Controls.Add(Me.txTransLabID1)
        Me.GroupBox3.Controls.Add(Me.buttambahpasien)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.TextBoxJenisKelamin)
        Me.GroupBox3.Controls.Add(Me.txtindakanid)
        Me.GroupBox3.Controls.Add(Me.dtcusttgllhr)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.txcustumur)
        Me.GroupBox3.Controls.Add(Me.Label30)
        Me.GroupBox3.Controls.Add(Me.txcustnama)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(858, 323)
        Me.GroupBox3.TabIndex = 154
        Me.GroupBox3.TabStop = False
        '
        'PanelThorax
        '
        Me.PanelThorax.Controls.Add(Me.txtAlasanThorax)
        Me.PanelThorax.Controls.Add(Me.rdThoraxTolak)
        Me.PanelThorax.Controls.Add(Me.rdThoraxSetuju)
        Me.PanelThorax.Location = New System.Drawing.Point(616, 198)
        Me.PanelThorax.Name = "PanelThorax"
        Me.PanelThorax.Size = New System.Drawing.Size(221, 103)
        Me.PanelThorax.TabIndex = 243
        Me.PanelThorax.TabStop = False
        Me.PanelThorax.Text = "Persetujuan Tindakan Thorax"
        Me.PanelThorax.Visible = False
        '
        'txtAlasanThorax
        '
        Me.txtAlasanThorax.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtAlasanThorax.Enabled = False
        Me.txtAlasanThorax.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAlasanThorax.Location = New System.Drawing.Point(7, 71)
        Me.txtAlasanThorax.Name = "txtAlasanThorax"
        Me.txtAlasanThorax.Size = New System.Drawing.Size(208, 22)
        Me.txtAlasanThorax.TabIndex = 240
        '
        'rdThoraxTolak
        '
        Me.rdThoraxTolak.AutoSize = True
        Me.rdThoraxTolak.Location = New System.Drawing.Point(6, 46)
        Me.rdThoraxTolak.Name = "rdThoraxTolak"
        Me.rdThoraxTolak.Size = New System.Drawing.Size(93, 19)
        Me.rdThoraxTolak.TabIndex = 1
        Me.rdThoraxTolak.Text = "Tidak Setuju"
        Me.rdThoraxTolak.UseVisualStyleBackColor = True
        '
        'rdThoraxSetuju
        '
        Me.rdThoraxSetuju.AutoSize = True
        Me.rdThoraxSetuju.Checked = True
        Me.rdThoraxSetuju.Location = New System.Drawing.Point(7, 21)
        Me.rdThoraxSetuju.Name = "rdThoraxSetuju"
        Me.rdThoraxSetuju.Size = New System.Drawing.Size(60, 19)
        Me.rdThoraxSetuju.TabIndex = 0
        Me.rdThoraxSetuju.TabStop = True
        Me.rdThoraxSetuju.Text = "Setuju"
        Me.rdThoraxSetuju.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.RadioButtonFalse)
        Me.GroupBox4.Controls.Add(Me.RadioButtonHaid)
        Me.GroupBox4.Controls.Add(Me.RadioButtonHamil)
        Me.GroupBox4.Location = New System.Drawing.Point(616, 91)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(221, 100)
        Me.GroupBox4.TabIndex = 242
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Kondisi Pasien"
        Me.GroupBox4.Visible = False
        '
        'RadioButtonFalse
        '
        Me.RadioButtonFalse.AutoSize = True
        Me.RadioButtonFalse.Checked = True
        Me.RadioButtonFalse.Location = New System.Drawing.Point(6, 17)
        Me.RadioButtonFalse.Name = "RadioButtonFalse"
        Me.RadioButtonFalse.Size = New System.Drawing.Size(113, 19)
        Me.RadioButtonFalse.TabIndex = 2
        Me.RadioButtonFalse.TabStop = True
        Me.RadioButtonFalse.Text = "Tidak Keduanya"
        Me.RadioButtonFalse.UseVisualStyleBackColor = True
        '
        'RadioButtonHaid
        '
        Me.RadioButtonHaid.AutoSize = True
        Me.RadioButtonHaid.Location = New System.Drawing.Point(6, 67)
        Me.RadioButtonHaid.Name = "RadioButtonHaid"
        Me.RadioButtonHaid.Size = New System.Drawing.Size(132, 19)
        Me.RadioButtonHaid.TabIndex = 1
        Me.RadioButtonHaid.Text = "Sedang Menstruasi"
        Me.RadioButtonHaid.UseVisualStyleBackColor = True
        '
        'RadioButtonHamil
        '
        Me.RadioButtonHamil.AutoSize = True
        Me.RadioButtonHamil.Location = New System.Drawing.Point(6, 42)
        Me.RadioButtonHamil.Name = "RadioButtonHamil"
        Me.RadioButtonHamil.Size = New System.Drawing.Size(104, 19)
        Me.RadioButtonHamil.TabIndex = 0
        Me.RadioButtonHamil.Text = "Sedang Hamil"
        Me.RadioButtonHamil.UseVisualStyleBackColor = True
        '
        'ButtonCariPasien
        '
        Me.ButtonCariPasien.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCariPasien.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCariPasien.ForeColor = System.Drawing.Color.White
        Me.ButtonCariPasien.Location = New System.Drawing.Point(276, 68)
        Me.ButtonCariPasien.Name = "ButtonCariPasien"
        Me.ButtonCariPasien.Size = New System.Drawing.Size(75, 27)
        Me.ButtonCariPasien.TabIndex = 241
        Me.ButtonCariPasien.Text = "Cari"
        Me.ButtonCariPasien.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(45, 73)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(74, 16)
        Me.Label11.TabIndex = 240
        Me.Label11.Text = "Scan HYU!"
        '
        'TextBoxScanHyu
        '
        Me.TextBoxScanHyu.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBoxScanHyu.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxScanHyu.Location = New System.Drawing.Point(125, 70)
        Me.TextBoxScanHyu.Name = "TextBoxScanHyu"
        Me.TextBoxScanHyu.Size = New System.Drawing.Size(145, 22)
        Me.TextBoxScanHyu.TabIndex = 239
        '
        'txtindakan
        '
        Me.txtindakan.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtindakan.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtindakan.Location = New System.Drawing.Point(125, 189)
        Me.txtindakan.Multiline = True
        Me.txtindakan.Name = "txtindakan"
        Me.txtindakan.ReadOnly = True
        Me.txtindakan.Size = New System.Drawing.Size(484, 55)
        Me.txtindakan.TabIndex = 238
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(23, 191)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 16)
        Me.Label6.TabIndex = 237
        Me.Label6.Text = "Pemeriksaan"
        '
        'txNoMitra1
        '
        Me.txNoMitra1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txNoMitra1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txNoMitra1.Location = New System.Drawing.Point(125, 128)
        Me.txNoMitra1.Name = "txNoMitra1"
        Me.txNoMitra1.ReadOnly = True
        Me.txNoMitra1.Size = New System.Drawing.Size(145, 22)
        Me.txNoMitra1.TabIndex = 236
        '
        'txTransLabID1
        '
        Me.txTransLabID1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txTransLabID1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txTransLabID1.Location = New System.Drawing.Point(125, 98)
        Me.txTransLabID1.Name = "txTransLabID1"
        Me.txTransLabID1.ReadOnly = True
        Me.txTransLabID1.Size = New System.Drawing.Size(145, 22)
        Me.txTransLabID1.TabIndex = 235
        '
        'buttambahpasien
        '
        Me.buttambahpasien.Cursor = System.Windows.Forms.Cursors.Hand
        Me.buttambahpasien.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.buttambahpasien.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_add
        Me.buttambahpasien.Location = New System.Drawing.Point(14, 20)
        Me.buttambahpasien.Name = "buttambahpasien"
        Me.buttambahpasien.Size = New System.Drawing.Size(100, 36)
        Me.buttambahpasien.TabIndex = 234
        Me.buttambahpasien.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(295, 101)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(55, 16)
        Me.Label12.TabIndex = 154
        Me.Label12.Text = "No Urut"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 101)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(108, 16)
        Me.Label1.TabIndex = 138
        Me.Label1.Text = "Pemeriksaan ID"
        '
        'TextBoxJenisKelamin
        '
        Me.TextBoxJenisKelamin.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBoxJenisKelamin.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxJenisKelamin.Location = New System.Drawing.Point(566, 98)
        Me.TextBoxJenisKelamin.Name = "TextBoxJenisKelamin"
        Me.TextBoxJenisKelamin.ReadOnly = True
        Me.TextBoxJenisKelamin.Size = New System.Drawing.Size(43, 22)
        Me.TextBoxJenisKelamin.TabIndex = 153
        '
        'txtindakanid
        '
        Me.txtindakanid.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtindakanid.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtindakanid.Location = New System.Drawing.Point(355, 98)
        Me.txtindakanid.Name = "txtindakanid"
        Me.txtindakanid.ReadOnly = True
        Me.txtindakanid.Size = New System.Drawing.Size(168, 22)
        Me.txtindakanid.TabIndex = 143
        '
        'dtcusttgllhr
        '
        Me.dtcusttgllhr.CustomFormat = "dd-MMM-yyyy"
        Me.dtcusttgllhr.Enabled = False
        Me.dtcusttgllhr.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtcusttgllhr.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtcusttgllhr.Location = New System.Drawing.Point(125, 158)
        Me.dtcusttgllhr.Name = "dtcusttgllhr"
        Me.dtcusttgllhr.Size = New System.Drawing.Size(145, 22)
        Me.dtcusttgllhr.TabIndex = 152
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(529, 101)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 15)
        Me.Label5.TabIndex = 151
        Me.Label5.Text = "L / P"
        '
        'txcustumur
        '
        Me.txcustumur.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txcustumur.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txcustumur.Location = New System.Drawing.Point(355, 158)
        Me.txcustumur.Name = "txcustumur"
        Me.txcustumur.ReadOnly = True
        Me.txcustumur.Size = New System.Drawing.Size(254, 22)
        Me.txcustumur.TabIndex = 150
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(51, 131)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(68, 16)
        Me.Label30.TabIndex = 145
        Me.Label30.Text = "Pasien ID"
        '
        'txcustnama
        '
        Me.txcustnama.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txcustnama.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txcustnama.Location = New System.Drawing.Point(355, 128)
        Me.txcustnama.Name = "txcustnama"
        Me.txcustnama.ReadOnly = True
        Me.txcustnama.Size = New System.Drawing.Size(254, 22)
        Me.txcustnama.TabIndex = 149
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(305, 131)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 16)
        Me.Label2.TabIndex = 146
        Me.Label2.Text = "Nama"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(308, 161)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 16)
        Me.Label4.TabIndex = 148
        Me.Label4.Text = "Umur"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(23, 161)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 16)
        Me.Label3.TabIndex = 147
        Me.Label3.Text = "Tanggal Lahir"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 97)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(872, 350)
        Me.TabControl1.TabIndex = 155
        '
        'lblStatusMCU
        '
        Me.lblStatusMCU.AutoSize = True
        Me.lblStatusMCU.Location = New System.Drawing.Point(358, 74)
        Me.lblStatusMCU.Name = "lblStatusMCU"
        Me.lblStatusMCU.Size = New System.Drawing.Size(11, 15)
        Me.lblStatusMCU.TabIndex = 244
        Me.lblStatusMCU.Text = "-"
        '
        'FormCetakBarcode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 457)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(888, 496)
        Me.MinimumSize = New System.Drawing.Size(888, 496)
        Me.Name = "FormCetakBarcode"
        Me.Text = "Form Cetak Barcode"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.gridlab, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.PanelThorax.ResumeLayout(False)
        Me.PanelThorax.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CetakBarcodeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BarcodeTambahanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents rdNonMCU As System.Windows.Forms.RadioButton
    Friend WithEvents rdMCU As System.Windows.Forms.RadioButton
    Friend WithEvents cbtabung As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxInbody As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbkodetransaksi As System.Windows.Forms.ComboBox
    Friend WithEvents txNoUrut2 As System.Windows.Forms.TextBox
    Friend WithEvents txNoUrut1 As System.Windows.Forms.TextBox
    Friend WithEvents txkodecabang As System.Windows.Forms.TextBox
    Friend WithEvents txcompanycode As System.Windows.Forms.TextBox
    Friend WithEvents cbNoUrut As System.Windows.Forms.CheckBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents butfindcompany As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents dtprocess As System.Windows.Forms.DateTimePicker
    Friend WithEvents buttambahpasienmcu As System.Windows.Forms.Button
    Friend WithEvents gridlab As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtindakan As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txNoMitra1 As System.Windows.Forms.TextBox
    Friend WithEvents txTransLabID1 As System.Windows.Forms.TextBox
    Friend WithEvents buttambahpasien As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxJenisKelamin As System.Windows.Forms.TextBox
    Friend WithEvents txtindakanid As System.Windows.Forms.TextBox
    Friend WithEvents dtcusttgllhr As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txcustumur As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txcustnama As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextBoxScanHyu As System.Windows.Forms.TextBox
    Friend WithEvents ButtonCariPasien As System.Windows.Forms.Button
    Friend WithEvents CheckBoxAktivo As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButtonFalse As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonHaid As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonHamil As System.Windows.Forms.RadioButton
    Friend WithEvents PanelThorax As System.Windows.Forms.GroupBox
    Friend WithEvents txtAlasanThorax As System.Windows.Forms.TextBox
    Friend WithEvents rdThoraxTolak As System.Windows.Forms.RadioButton
    Friend WithEvents rdThoraxSetuju As System.Windows.Forms.RadioButton
    Friend WithEvents lblStatusMCU As System.Windows.Forms.Label
End Class
