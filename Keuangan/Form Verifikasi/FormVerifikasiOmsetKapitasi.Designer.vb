<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormVerifikasiOmsetKapitasi
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormVerifikasiOmsetKapitasi))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.gridtindakan = New DevExpress.XtraGrid.GridControl
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.rdcob = New System.Windows.Forms.RadioButton
        Me.rdnoncob = New System.Windows.Forms.RadioButton
        Me.Label17 = New System.Windows.Forms.Label
        Me.lblbank = New System.Windows.Forms.Label
        Me.cmbbank = New System.Windows.Forms.ComboBox
        Me.dttransfer = New System.Windows.Forms.DateTimePicker
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.butsavelab = New System.Windows.Forms.Button
        Me.txnominalselisih = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.txnominaladmin = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.txnominalrekening = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txstatusket = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.rdklinik = New System.Windows.Forms.RadioButton
        Me.rdlab = New System.Windows.Forms.RadioButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.rdbpjs = New System.Windows.Forms.RadioButton
        Me.rdinhealth = New System.Windows.Forms.RadioButton
        Me.Label11 = New System.Windows.Forms.Label
        Me.txgrandtotalbulanberjalan = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txbulan = New System.Windows.Forms.Label
        Me.Label53 = New System.Windows.Forms.Label
        Me.txtotal2 = New System.Windows.Forms.TextBox
        Me.txtotal1 = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.btnview = New System.Windows.Forms.Button
        Me.txharga2 = New System.Windows.Forms.TextBox
        Me.txharga1 = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txjumlahpasien = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmbtahun = New System.Windows.Forms.ComboBox
        Me.cmbbulan = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txlocket = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.MenuStrip1.SuspendLayout()
        CType(Me.gridtindakan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 512)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(619, 10)
        Me.GroupBox1.TabIndex = 108
        Me.GroupBox1.TabStop = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(619, 24)
        Me.MenuStrip1.TabIndex = 107
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(65, 20)
        Me.NewToolStripMenuItem.Text = "Set Clear"
        '
        'gridtindakan
        '
        Me.gridtindakan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridtindakan.EmbeddedNavigator.Name = ""
        Me.gridtindakan.Location = New System.Drawing.Point(0, 522)
        Me.gridtindakan.MainView = Me.GridView2
        Me.gridtindakan.Name = "gridtindakan"
        Me.gridtindakan.Size = New System.Drawing.Size(619, 0)
        Me.gridtindakan.TabIndex = 106
        Me.gridtindakan.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        Me.gridtindakan.Visible = False
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.gridtindakan
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsView.ShowAutoFilterRow = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Panel3)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.lblbank)
        Me.GroupBox3.Controls.Add(Me.cmbbank)
        Me.GroupBox3.Controls.Add(Me.dttransfer)
        Me.GroupBox3.Controls.Add(Me.Label23)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.butsavelab)
        Me.GroupBox3.Controls.Add(Me.txnominalselisih)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Controls.Add(Me.txnominaladmin)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.txnominalrekening)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.txstatusket)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Panel2)
        Me.GroupBox3.Controls.Add(Me.Panel1)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.txgrandtotalbulanberjalan)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.txbulan)
        Me.GroupBox3.Controls.Add(Me.Label53)
        Me.GroupBox3.Controls.Add(Me.txtotal2)
        Me.GroupBox3.Controls.Add(Me.txtotal1)
        Me.GroupBox3.Controls.Add(Me.Label24)
        Me.GroupBox3.Controls.Add(Me.Label27)
        Me.GroupBox3.Controls.Add(Me.Label28)
        Me.GroupBox3.Controls.Add(Me.Label31)
        Me.GroupBox3.Controls.Add(Me.btnview)
        Me.GroupBox3.Controls.Add(Me.txharga2)
        Me.GroupBox3.Controls.Add(Me.txharga1)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.txjumlahpasien)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.cmbtahun)
        Me.GroupBox3.Controls.Add(Me.cmbbulan)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.txlocket)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Location = New System.Drawing.Point(0, 24)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(619, 488)
        Me.GroupBox3.TabIndex = 109
        Me.GroupBox3.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.Control
        Me.Panel3.Controls.Add(Me.rdcob)
        Me.Panel3.Controls.Add(Me.rdnoncob)
        Me.Panel3.Location = New System.Drawing.Point(110, 73)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(255, 25)
        Me.Panel3.TabIndex = 371
        '
        'rdcob
        '
        Me.rdcob.AutoSize = True
        Me.rdcob.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdcob.Location = New System.Drawing.Point(5, 3)
        Me.rdcob.Name = "rdcob"
        Me.rdcob.Size = New System.Drawing.Size(51, 19)
        Me.rdcob.TabIndex = 314
        Me.rdcob.TabStop = True
        Me.rdcob.Text = "COB"
        Me.rdcob.UseVisualStyleBackColor = True
        '
        'rdnoncob
        '
        Me.rdnoncob.AutoSize = True
        Me.rdnoncob.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdnoncob.Location = New System.Drawing.Point(80, 3)
        Me.rdnoncob.Name = "rdnoncob"
        Me.rdnoncob.Size = New System.Drawing.Size(77, 19)
        Me.rdnoncob.TabIndex = 313
        Me.rdnoncob.TabStop = True
        Me.rdnoncob.Text = "Non COB"
        Me.rdnoncob.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(7, 77)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(97, 16)
        Me.Label17.TabIndex = 370
        Me.Label17.Text = "Jenis Inhealth"
        '
        'lblbank
        '
        Me.lblbank.AutoSize = True
        Me.lblbank.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.lblbank.Location = New System.Drawing.Point(297, 427)
        Me.lblbank.Name = "lblbank"
        Me.lblbank.Size = New System.Drawing.Size(92, 16)
        Me.lblbank.TabIndex = 368
        Me.lblbank.Text = "Bank Transfer"
        '
        'cmbbank
        '
        Me.cmbbank.AutoCompleteCustomSource.AddRange(New String() {"TUNAI", "CARD", "DEBET", "DISC", "TAGIHAN"})
        Me.cmbbank.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbbank.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbbank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbbank.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbbank.FormattingEnabled = True
        Me.cmbbank.Location = New System.Drawing.Point(406, 424)
        Me.cmbbank.Name = "cmbbank"
        Me.cmbbank.Size = New System.Drawing.Size(181, 24)
        Me.cmbbank.TabIndex = 367
        '
        'dttransfer
        '
        Me.dttransfer.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dttransfer.CustomFormat = "dd-MMM-yyyy"
        Me.dttransfer.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dttransfer.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dttransfer.Location = New System.Drawing.Point(406, 396)
        Me.dttransfer.Name = "dttransfer"
        Me.dttransfer.Size = New System.Drawing.Size(181, 22)
        Me.dttransfer.TabIndex = 365
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        Me.Label23.Location = New System.Drawing.Point(308, 396)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(81, 16)
        Me.Label23.TabIndex = 366
        Me.Label23.Text = "Tgl Transfer"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(350, 289)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(39, 16)
        Me.Label16.TabIndex = 364
        Me.Label16.Text = "Total"
        '
        'butsavelab
        '
        Me.butsavelab.Cursor = System.Windows.Forms.Cursors.Hand
        Me.butsavelab.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butsavelab.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_save
        Me.butsavelab.Location = New System.Drawing.Point(487, 454)
        Me.butsavelab.Name = "butsavelab"
        Me.butsavelab.Size = New System.Drawing.Size(100, 36)
        Me.butsavelab.TabIndex = 363
        Me.butsavelab.UseVisualStyleBackColor = True
        '
        'txnominalselisih
        '
        Me.txnominalselisih.BackColor = System.Drawing.SystemColors.Window
        Me.txnominalselisih.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txnominalselisih.Location = New System.Drawing.Point(437, 367)
        Me.txnominalselisih.Name = "txnominalselisih"
        Me.txnominalselisih.ReadOnly = True
        Me.txnominalselisih.Size = New System.Drawing.Size(150, 21)
        Me.txnominalselisih.TabIndex = 362
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(403, 370)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(28, 16)
        Me.Label14.TabIndex = 361
        Me.Label14.Text = "Rp."
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(341, 369)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(48, 16)
        Me.Label15.TabIndex = 360
        Me.Label15.Text = "Selisih"
        '
        'txnominaladmin
        '
        Me.txnominaladmin.BackColor = System.Drawing.SystemColors.Window
        Me.txnominaladmin.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txnominaladmin.Location = New System.Drawing.Point(437, 340)
        Me.txnominaladmin.Name = "txnominaladmin"
        Me.txnominaladmin.Size = New System.Drawing.Size(150, 21)
        Me.txnominaladmin.TabIndex = 359
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(403, 343)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(28, 16)
        Me.Label12.TabIndex = 358
        Me.Label12.Text = "Rp."
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(305, 343)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(84, 16)
        Me.Label13.TabIndex = 357
        Me.Label13.Text = "Biaya Admin"
        '
        'txnominalrekening
        '
        Me.txnominalrekening.BackColor = System.Drawing.SystemColors.Window
        Me.txnominalrekening.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txnominalrekening.Location = New System.Drawing.Point(437, 313)
        Me.txnominalrekening.Name = "txnominalrekening"
        Me.txnominalrekening.Size = New System.Drawing.Size(150, 21)
        Me.txnominalrekening.TabIndex = 356
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(403, 316)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(28, 16)
        Me.Label9.TabIndex = 355
        Me.Label9.Text = "Rp."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(263, 315)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 16)
        Me.Label1.TabIndex = 354
        Me.Label1.Text = "Nominal sesuai rek."
        '
        'txstatusket
        '
        Me.txstatusket.AutoSize = True
        Me.txstatusket.BackColor = System.Drawing.Color.Green
        Me.txstatusket.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txstatusket.ForeColor = System.Drawing.Color.Transparent
        Me.txstatusket.Location = New System.Drawing.Point(332, 462)
        Me.txstatusket.Name = "txstatusket"
        Me.txstatusket.Size = New System.Drawing.Size(149, 19)
        Me.txstatusket.TabIndex = 352
        Me.txstatusket.Text = "BELUM APPROVE"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(55, 105)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 16)
        Me.Label2.TabIndex = 351
        Me.Label2.Text = "Lokasi"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.Panel2.Controls.Add(Me.rdklinik)
        Me.Panel2.Controls.Add(Me.rdlab)
        Me.Panel2.Location = New System.Drawing.Point(110, 101)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(255, 25)
        Me.Panel2.TabIndex = 350
        '
        'rdklinik
        '
        Me.rdklinik.AutoSize = True
        Me.rdklinik.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdklinik.Location = New System.Drawing.Point(5, 3)
        Me.rdklinik.Name = "rdklinik"
        Me.rdklinik.Size = New System.Drawing.Size(55, 19)
        Me.rdklinik.TabIndex = 245
        Me.rdklinik.TabStop = True
        Me.rdklinik.Text = "Klinik"
        Me.rdklinik.UseVisualStyleBackColor = True
        '
        'rdlab
        '
        Me.rdlab.AutoSize = True
        Me.rdlab.Enabled = False
        Me.rdlab.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdlab.Location = New System.Drawing.Point(80, 3)
        Me.rdlab.Name = "rdlab"
        Me.rdlab.Size = New System.Drawing.Size(99, 19)
        Me.rdlab.TabIndex = 246
        Me.rdlab.TabStop = True
        Me.rdlab.Text = "Laboratorium"
        Me.rdlab.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.rdbpjs)
        Me.Panel1.Controls.Add(Me.rdinhealth)
        Me.Panel1.Location = New System.Drawing.Point(110, 45)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(255, 25)
        Me.Panel1.TabIndex = 349
        '
        'rdbpjs
        '
        Me.rdbpjs.AutoSize = True
        Me.rdbpjs.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbpjs.Location = New System.Drawing.Point(5, 3)
        Me.rdbpjs.Name = "rdbpjs"
        Me.rdbpjs.Size = New System.Drawing.Size(55, 19)
        Me.rdbpjs.TabIndex = 314
        Me.rdbpjs.TabStop = True
        Me.rdbpjs.Text = "BPJS"
        Me.rdbpjs.UseVisualStyleBackColor = True
        '
        'rdinhealth
        '
        Me.rdinhealth.AutoSize = True
        Me.rdinhealth.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdinhealth.Location = New System.Drawing.Point(80, 3)
        Me.rdinhealth.Name = "rdinhealth"
        Me.rdinhealth.Size = New System.Drawing.Size(69, 19)
        Me.rdinhealth.TabIndex = 313
        Me.rdinhealth.TabStop = True
        Me.rdinhealth.Text = "Inhealth"
        Me.rdinhealth.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(8, 49)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(96, 16)
        Me.Label11.TabIndex = 348
        Me.Label11.Text = "Jenis Kapitasi"
        '
        'txgrandtotalbulanberjalan
        '
        Me.txgrandtotalbulanberjalan.BackColor = System.Drawing.SystemColors.Window
        Me.txgrandtotalbulanberjalan.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txgrandtotalbulanberjalan.Location = New System.Drawing.Point(437, 286)
        Me.txgrandtotalbulanberjalan.Name = "txgrandtotalbulanberjalan"
        Me.txgrandtotalbulanberjalan.ReadOnly = True
        Me.txgrandtotalbulanberjalan.Size = New System.Drawing.Size(150, 21)
        Me.txgrandtotalbulanberjalan.TabIndex = 347
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(403, 289)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(28, 16)
        Me.Label7.TabIndex = 346
        Me.Label7.Text = "Rp."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(401, 261)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(202, 16)
        Me.Label6.TabIndex = 345
        Me.Label6.Text = "__________________________ +"
        '
        'txbulan
        '
        Me.txbulan.AutoSize = True
        Me.txbulan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txbulan.Location = New System.Drawing.Point(8, 183)
        Me.txbulan.Name = "txbulan"
        Me.txbulan.Size = New System.Drawing.Size(47, 16)
        Me.txbulan.TabIndex = 339
        Me.txbulan.Text = "Bulan"
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.Location = New System.Drawing.Point(250, 183)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(111, 16)
        Me.Label53.TabIndex = 338
        Me.Label53.Text = "Harga Kapitasi"
        '
        'txtotal2
        '
        Me.txtotal2.BackColor = System.Drawing.SystemColors.Window
        Me.txtotal2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtotal2.Location = New System.Drawing.Point(435, 237)
        Me.txtotal2.Name = "txtotal2"
        Me.txtotal2.ReadOnly = True
        Me.txtotal2.Size = New System.Drawing.Size(150, 21)
        Me.txtotal2.TabIndex = 304
        '
        'txtotal1
        '
        Me.txtotal1.BackColor = System.Drawing.SystemColors.Window
        Me.txtotal1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtotal1.Location = New System.Drawing.Point(435, 210)
        Me.txtotal1.Name = "txtotal1"
        Me.txtotal1.ReadOnly = True
        Me.txtotal1.Size = New System.Drawing.Size(150, 21)
        Me.txtotal1.TabIndex = 303
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(401, 240)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(28, 16)
        Me.Label24.TabIndex = 302
        Me.Label24.Text = "Rp."
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(401, 214)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(28, 16)
        Me.Label27.TabIndex = 299
        Me.Label27.Text = "Rp."
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(378, 240)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(16, 16)
        Me.Label28.TabIndex = 298
        Me.Label28.Text = "="
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(378, 214)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(16, 16)
        Me.Label31.TabIndex = 295
        Me.Label31.Text = "="
        '
        'btnview
        '
        Me.btnview.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnview.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnview.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_cari
        Me.btnview.Location = New System.Drawing.Point(371, 121)
        Me.btnview.Name = "btnview"
        Me.btnview.Size = New System.Drawing.Size(100, 36)
        Me.btnview.TabIndex = 293
        Me.btnview.UseVisualStyleBackColor = True
        '
        'txharga2
        '
        Me.txharga2.BackColor = System.Drawing.SystemColors.Window
        Me.txharga2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txharga2.Location = New System.Drawing.Point(278, 236)
        Me.txharga2.Name = "txharga2"
        Me.txharga2.ReadOnly = True
        Me.txharga2.Size = New System.Drawing.Size(83, 21)
        Me.txharga2.TabIndex = 290
        '
        'txharga1
        '
        Me.txharga1.BackColor = System.Drawing.SystemColors.Window
        Me.txharga1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txharga1.Location = New System.Drawing.Point(278, 209)
        Me.txharga1.Name = "txharga1"
        Me.txharga1.ReadOnly = True
        Me.txharga1.Size = New System.Drawing.Size(83, 21)
        Me.txharga1.TabIndex = 289
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(244, 239)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(28, 16)
        Me.Label19.TabIndex = 288
        Me.Label19.Text = "Rp."
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(244, 213)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(28, 16)
        Me.Label22.TabIndex = 285
        Me.Label22.Text = "Rp."
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(221, 212)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(16, 16)
        Me.Label18.TabIndex = 281
        Me.Label18.Text = "x"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(172, 212)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 16)
        Me.Label10.TabIndex = 277
        Me.Label10.Text = "Orang"
        '
        'txjumlahpasien
        '
        Me.txjumlahpasien.BackColor = System.Drawing.SystemColors.Window
        Me.txjumlahpasien.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txjumlahpasien.Location = New System.Drawing.Point(106, 209)
        Me.txjumlahpasien.Name = "txjumlahpasien"
        Me.txjumlahpasien.ReadOnly = True
        Me.txjumlahpasien.Size = New System.Drawing.Size(60, 21)
        Me.txjumlahpasien.TabIndex = 270
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 212)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 16)
        Me.Label5.TabIndex = 269
        Me.Label5.Text = "Jumlah Pasien"
        '
        'cmbtahun
        '
        Me.cmbtahun.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbtahun.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbtahun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbtahun.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.cmbtahun.FormattingEnabled = True
        Me.cmbtahun.Location = New System.Drawing.Point(270, 129)
        Me.cmbtahun.Name = "cmbtahun"
        Me.cmbtahun.Size = New System.Drawing.Size(95, 23)
        Me.cmbtahun.TabIndex = 268
        Me.cmbtahun.Tag = "3054"
        '
        'cmbbulan
        '
        Me.cmbbulan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.cmbbulan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbbulan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbbulan.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.cmbbulan.FormattingEnabled = True
        Me.cmbbulan.Location = New System.Drawing.Point(110, 129)
        Me.cmbbulan.Name = "cmbbulan"
        Me.cmbbulan.Size = New System.Drawing.Size(95, 23)
        Me.cmbbulan.TabIndex = 267
        Me.cmbbulan.Tag = "3054"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(222, 131)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 16)
        Me.Label4.TabIndex = 266
        Me.Label4.Text = "Tahun"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(59, 131)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 16)
        Me.Label3.TabIndex = 264
        Me.Label3.Text = "Bulan"
        '
        'txlocket
        '
        Me.txlocket.BackColor = System.Drawing.SystemColors.Window
        Me.txlocket.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txlocket.Location = New System.Drawing.Point(110, 18)
        Me.txlocket.Name = "txlocket"
        Me.txlocket.ReadOnly = True
        Me.txlocket.Size = New System.Drawing.Size(218, 21)
        Me.txlocket.TabIndex = 257
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(60, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 16)
        Me.Label8.TabIndex = 255
        Me.Label8.Text = "Klinik"
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Button1.Location = New System.Drawing.Point(334, 15)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(31, 25)
        Me.Button1.TabIndex = 140
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FormApproveKapitasi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(619, 520)
        Me.Controls.Add(Me.gridtindakan)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormApproveKapitasi"
        Me.Text = "Form Kapitasi Klinik"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.gridtindakan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    'Friend WithEvents txtindakanbiaya As DevExpress.XtraEditors.TextEdit
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents buttindakanid As DevExpress.XtraEditors.ButtonEdit
    'Friend WithEvents txhargaprt As DevExpress.XtraEditors.TextEdit
    'Friend WithEvents txhargaprh As DevExpress.XtraEditors.TextEdit
    'Friend WithEvents txhargakd As DevExpress.XtraEditors.TextEdit
    Private WithEvents gridtindakan As DevExpress.XtraGrid.GridControl
    Private WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txlocket As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbbulan As System.Windows.Forms.ComboBox
    Friend WithEvents cmbtahun As System.Windows.Forms.ComboBox
    Friend WithEvents txjumlahpasien As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txharga2 As System.Windows.Forms.TextBox
    Friend WithEvents txharga1 As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents btnview As System.Windows.Forms.Button
    Friend WithEvents txtotal2 As System.Windows.Forms.TextBox
    Friend WithEvents txtotal1 As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents txgrandtotalbulanberjalan As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txbulan As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rdbpjs As System.Windows.Forms.RadioButton
    Friend WithEvents rdinhealth As System.Windows.Forms.RadioButton
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents rdklinik As System.Windows.Forms.RadioButton
    Friend WithEvents rdlab As System.Windows.Forms.RadioButton
    Friend WithEvents txstatusket As System.Windows.Forms.Label
    Friend WithEvents txnominalselisih As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txnominaladmin As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txnominalrekening As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents butsavelab As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents dttransfer As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents lblbank As System.Windows.Forms.Label
    Friend WithEvents cmbbank As System.Windows.Forms.ComboBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents rdcob As System.Windows.Forms.RadioButton
    Friend WithEvents rdnoncob As System.Windows.Forms.RadioButton
    Friend WithEvents Label17 As System.Windows.Forms.Label
End Class
