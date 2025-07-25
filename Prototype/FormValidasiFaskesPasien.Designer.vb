<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormValidasiFaskesPasien
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormValidasiFaskesPasien))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.TextBoxResponseSukses = New System.Windows.Forms.TextBox
        Me.TextBoxResponseGagal = New System.Windows.Forms.TextBox
        Me.gridlab = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label6 = New System.Windows.Forms.Label
        Me.TextBoxCount = New System.Windows.Forms.TextBox
        Me.ButtonUploadData = New System.Windows.Forms.Button
        Me.ButtonStopProses = New System.Windows.Forms.Button
        Me.ButtonSinkronisasi = New System.Windows.Forms.Button
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.rdOnline = New System.Windows.Forms.RadioButton
        Me.rdOffline = New System.Windows.Forms.RadioButton
        Me.PanelKeadaanUmumMenuPemeriksaanAwal = New System.Windows.Forms.Panel
        Me.RadioButtonKesimpulanYa = New System.Windows.Forms.RadioButton
        Me.RadioButtonKesimpulanTidak = New System.Windows.Forms.RadioButton
        Me.Label15 = New System.Windows.Forms.Label
        Me.gridexcel = New DevExpress.XtraGrid.GridControl
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.txidloc = New System.Windows.Forms.TextBox
        Me.txloc = New System.Windows.Forms.TextBox
        Me.butfindloc = New System.Windows.Forms.Button
        Me.NamaLokasi = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.butsavemultiple = New System.Windows.Forms.Button
        Me.butsavelab = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.CheckBoxJatiuwung = New System.Windows.Forms.CheckBox
        Me.CheckBoxPasarKemis = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.gridlab, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.SuspendLayout()
        CType(Me.gridexcel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.SplitContainer1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 217)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1101, 323)
        Me.GroupBox1.TabIndex = 181
        Me.GroupBox1.TabStop = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(3, 16)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBoxResponseSukses)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TextBoxResponseGagal)
        Me.SplitContainer1.Size = New System.Drawing.Size(1095, 304)
        Me.SplitContainer1.SplitterDistance = 500
        Me.SplitContainer1.TabIndex = 0
        '
        'TextBoxResponseSukses
        '
        Me.TextBoxResponseSukses.BackColor = System.Drawing.Color.White
        Me.TextBoxResponseSukses.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxResponseSukses.Location = New System.Drawing.Point(0, 0)
        Me.TextBoxResponseSukses.Multiline = True
        Me.TextBoxResponseSukses.Name = "TextBoxResponseSukses"
        Me.TextBoxResponseSukses.ReadOnly = True
        Me.TextBoxResponseSukses.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxResponseSukses.Size = New System.Drawing.Size(500, 304)
        Me.TextBoxResponseSukses.TabIndex = 462
        '
        'TextBoxResponseGagal
        '
        Me.TextBoxResponseGagal.BackColor = System.Drawing.Color.White
        Me.TextBoxResponseGagal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxResponseGagal.Location = New System.Drawing.Point(0, 0)
        Me.TextBoxResponseGagal.Multiline = True
        Me.TextBoxResponseGagal.Name = "TextBoxResponseGagal"
        Me.TextBoxResponseGagal.ReadOnly = True
        Me.TextBoxResponseGagal.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxResponseGagal.Size = New System.Drawing.Size(591, 304)
        Me.TextBoxResponseGagal.TabIndex = 463
        '
        'gridlab
        '
        Me.gridlab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridlab.EmbeddedNavigator.Name = ""
        Me.gridlab.Location = New System.Drawing.Point(0, 0)
        Me.gridlab.MainView = Me.GridView1
        Me.gridlab.Name = "gridlab"
        Me.gridlab.Size = New System.Drawing.Size(347, 138)
        Me.gridlab.TabIndex = 0
        Me.gridlab.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.gridlab
        Me.GridView1.Name = "GridView1"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.Panel1)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1101, 217)
        Me.GroupBox2.TabIndex = 183
        Me.GroupBox2.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.CheckBoxPasarKemis)
        Me.Panel1.Controls.Add(Me.CheckBoxJatiuwung)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.TextBoxCount)
        Me.Panel1.Controls.Add(Me.ButtonUploadData)
        Me.Panel1.Controls.Add(Me.ButtonStopProses)
        Me.Panel1.Controls.Add(Me.ButtonSinkronisasi)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.PanelKeadaanUmumMenuPemeriksaanAwal)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.gridexcel)
        Me.Panel1.Controls.Add(Me.txidloc)
        Me.Panel1.Controls.Add(Me.txloc)
        Me.Panel1.Controls.Add(Me.butfindloc)
        Me.Panel1.Controls.Add(Me.NamaLokasi)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.ProgressBar1)
        Me.Panel1.Controls.Add(Me.butsavemultiple)
        Me.Panel1.Controls.Add(Me.butsavelab)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 16)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1095, 198)
        Me.Panel1.TabIndex = 236
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 168)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 17)
        Me.Label6.TabIndex = 531
        Me.Label6.Text = "Status Proses :"
        '
        'TextBoxCount
        '
        Me.TextBoxCount.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.TextBoxCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxCount.Cursor = System.Windows.Forms.Cursors.No
        Me.TextBoxCount.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxCount.Location = New System.Drawing.Point(111, 166)
        Me.TextBoxCount.Name = "TextBoxCount"
        Me.TextBoxCount.ReadOnly = True
        Me.TextBoxCount.Size = New System.Drawing.Size(67, 25)
        Me.TextBoxCount.TabIndex = 530
        Me.TextBoxCount.TabStop = False
        '
        'ButtonUploadData
        '
        Me.ButtonUploadData.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonUploadData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonUploadData.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonUploadData.FlatAppearance.BorderSize = 0
        Me.ButtonUploadData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonUploadData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonUploadData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonUploadData.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonUploadData.ForeColor = System.Drawing.Color.White
        Me.ButtonUploadData.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_add_24
        Me.ButtonUploadData.Location = New System.Drawing.Point(11, 114)
        Me.ButtonUploadData.Name = "ButtonUploadData"
        Me.ButtonUploadData.Size = New System.Drawing.Size(150, 35)
        Me.ButtonUploadData.TabIndex = 529
        Me.ButtonUploadData.Text = " Upload Data"
        Me.ButtonUploadData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonUploadData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonUploadData.UseVisualStyleBackColor = False
        '
        'ButtonStopProses
        '
        Me.ButtonStopProses.BackColor = System.Drawing.Color.White
        Me.ButtonStopProses.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonStopProses.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonStopProses.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonStopProses.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonStopProses.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonStopProses.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonStopProses.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonStopProses.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonStopProses.Image = CType(resources.GetObject("ButtonStopProses.Image"), System.Drawing.Image)
        Me.ButtonStopProses.Location = New System.Drawing.Point(373, 113)
        Me.ButtonStopProses.Name = "ButtonStopProses"
        Me.ButtonStopProses.Size = New System.Drawing.Size(150, 35)
        Me.ButtonStopProses.TabIndex = 528
        Me.ButtonStopProses.Text = " Stop Proses"
        Me.ButtonStopProses.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonStopProses.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonStopProses.UseVisualStyleBackColor = False
        '
        'ButtonSinkronisasi
        '
        Me.ButtonSinkronisasi.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSinkronisasi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonSinkronisasi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonSinkronisasi.FlatAppearance.BorderSize = 0
        Me.ButtonSinkronisasi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSinkronisasi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonSinkronisasi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSinkronisasi.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonSinkronisasi.ForeColor = System.Drawing.Color.White
        Me.ButtonSinkronisasi.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_sync_24
        Me.ButtonSinkronisasi.Location = New System.Drawing.Point(167, 114)
        Me.ButtonSinkronisasi.Name = "ButtonSinkronisasi"
        Me.ButtonSinkronisasi.Size = New System.Drawing.Size(200, 35)
        Me.ButtonSinkronisasi.TabIndex = 517
        Me.ButtonSinkronisasi.Text = " Sinkronisasi Data"
        Me.ButtonSinkronisasi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonSinkronisasi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonSinkronisasi.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.gridlab)
        Me.Panel3.Location = New System.Drawing.Point(529, 57)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(347, 138)
        Me.Panel3.TabIndex = 442
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.rdOnline)
        Me.Panel2.Controls.Add(Me.rdOffline)
        Me.Panel2.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Panel2.Location = New System.Drawing.Point(648, 18)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(236, 25)
        Me.Panel2.TabIndex = 441
        Me.Panel2.Visible = False
        '
        'rdOnline
        '
        Me.rdOnline.AutoSize = True
        Me.rdOnline.Checked = True
        Me.rdOnline.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.rdOnline.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.rdOnline.Location = New System.Drawing.Point(5, 3)
        Me.rdOnline.Name = "rdOnline"
        Me.rdOnline.Size = New System.Drawing.Size(63, 21)
        Me.rdOnline.TabIndex = 244
        Me.rdOnline.TabStop = True
        Me.rdOnline.Text = "Online"
        Me.rdOnline.UseVisualStyleBackColor = True
        '
        'rdOffline
        '
        Me.rdOffline.AutoSize = True
        Me.rdOffline.Enabled = False
        Me.rdOffline.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.rdOffline.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.rdOffline.Location = New System.Drawing.Point(74, 3)
        Me.rdOffline.Name = "rdOffline"
        Me.rdOffline.Size = New System.Drawing.Size(64, 21)
        Me.rdOffline.TabIndex = 243
        Me.rdOffline.Text = "Offline"
        Me.rdOffline.UseVisualStyleBackColor = True
        '
        'PanelKeadaanUmumMenuPemeriksaanAwal
        '
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.BackColor = System.Drawing.Color.Transparent
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.Controls.Add(Me.RadioButtonKesimpulanYa)
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.Controls.Add(Me.RadioButtonKesimpulanTidak)
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.Location = New System.Drawing.Point(648, 49)
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.Name = "PanelKeadaanUmumMenuPemeriksaanAwal"
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.Size = New System.Drawing.Size(236, 25)
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.TabIndex = 440
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.Visible = False
        '
        'RadioButtonKesimpulanYa
        '
        Me.RadioButtonKesimpulanYa.AutoSize = True
        Me.RadioButtonKesimpulanYa.Checked = True
        Me.RadioButtonKesimpulanYa.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonKesimpulanYa.Location = New System.Drawing.Point(5, 3)
        Me.RadioButtonKesimpulanYa.Name = "RadioButtonKesimpulanYa"
        Me.RadioButtonKesimpulanYa.Size = New System.Drawing.Size(39, 21)
        Me.RadioButtonKesimpulanYa.TabIndex = 245
        Me.RadioButtonKesimpulanYa.TabStop = True
        Me.RadioButtonKesimpulanYa.Text = "Ya"
        Me.RadioButtonKesimpulanYa.UseVisualStyleBackColor = True
        '
        'RadioButtonKesimpulanTidak
        '
        Me.RadioButtonKesimpulanTidak.AutoSize = True
        Me.RadioButtonKesimpulanTidak.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonKesimpulanTidak.Location = New System.Drawing.Point(50, 3)
        Me.RadioButtonKesimpulanTidak.Name = "RadioButtonKesimpulanTidak"
        Me.RadioButtonKesimpulanTidak.Size = New System.Drawing.Size(57, 21)
        Me.RadioButtonKesimpulanTidak.TabIndex = 246
        Me.RadioButtonKesimpulanTidak.Text = "Tidak"
        Me.RadioButtonKesimpulanTidak.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label15.Location = New System.Drawing.Point(474, 54)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(148, 17)
        Me.Label15.TabIndex = 439
        Me.Label15.Text = "Set Kesimpulan / Saran"
        Me.Label15.Visible = False
        '
        'gridexcel
        '
        Me.gridexcel.EmbeddedNavigator.Name = ""
        Me.gridexcel.Location = New System.Drawing.Point(1018, 80)
        Me.gridexcel.MainView = Me.GridView3
        Me.gridexcel.Name = "gridexcel"
        Me.gridexcel.Size = New System.Drawing.Size(100, 50)
        Me.gridexcel.TabIndex = 253
        Me.gridexcel.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
        Me.gridexcel.Visible = False
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.gridexcel
        Me.GridView3.Name = "GridView3"
        '
        'txidloc
        '
        Me.txidloc.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txidloc.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txidloc.Location = New System.Drawing.Point(859, 80)
        Me.txidloc.Name = "txidloc"
        Me.txidloc.ReadOnly = True
        Me.txidloc.Size = New System.Drawing.Size(60, 21)
        Me.txidloc.TabIndex = 248
        Me.txidloc.Visible = False
        '
        'txloc
        '
        Me.txloc.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txloc.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txloc.Location = New System.Drawing.Point(648, 80)
        Me.txloc.Name = "txloc"
        Me.txloc.ReadOnly = True
        Me.txloc.Size = New System.Drawing.Size(271, 21)
        Me.txloc.TabIndex = 247
        Me.txloc.Visible = False
        '
        'butfindloc
        '
        Me.butfindloc.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butfindloc.Location = New System.Drawing.Point(925, 78)
        Me.butfindloc.Name = "butfindloc"
        Me.butfindloc.Size = New System.Drawing.Size(35, 25)
        Me.butfindloc.TabIndex = 246
        Me.butfindloc.Text = "..."
        Me.butfindloc.UseVisualStyleBackColor = True
        Me.butfindloc.Visible = False
        '
        'NamaLokasi
        '
        Me.NamaLokasi.AutoSize = True
        Me.NamaLokasi.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.NamaLokasi.ForeColor = System.Drawing.SystemColors.ControlText
        Me.NamaLokasi.Location = New System.Drawing.Point(577, 81)
        Me.NamaLokasi.Name = "NamaLokasi"
        Me.NamaLokasi.Size = New System.Drawing.Size(45, 17)
        Me.NamaLokasi.TabIndex = 245
        Me.NamaLokasi.Text = "Lokasi"
        Me.NamaLokasi.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label8.Location = New System.Drawing.Point(526, 23)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 17)
        Me.Label8.TabIndex = 242
        Me.Label8.Text = "Jenis Transaksi"
        Me.Label8.Visible = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.BackColor = System.Drawing.Color.Lime
        Me.ProgressBar1.Location = New System.Drawing.Point(11, 155)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(512, 5)
        Me.ProgressBar1.TabIndex = 241
        '
        'butsavemultiple
        '
        Me.butsavemultiple.Cursor = System.Windows.Forms.Cursors.Hand
        Me.butsavemultiple.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butsavemultiple.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butsavemultiple.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_kosong
        Me.butsavemultiple.Location = New System.Drawing.Point(890, 15)
        Me.butsavemultiple.Name = "butsavemultiple"
        Me.butsavemultiple.Size = New System.Drawing.Size(100, 36)
        Me.butsavemultiple.TabIndex = 239
        Me.butsavemultiple.Text = "SAVE MULTIPLE"
        Me.butsavemultiple.UseVisualStyleBackColor = True
        Me.butsavemultiple.Visible = False
        '
        'butsavelab
        '
        Me.butsavelab.Cursor = System.Windows.Forms.Cursors.Hand
        Me.butsavelab.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butsavelab.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_save
        Me.butsavelab.Location = New System.Drawing.Point(903, 35)
        Me.butsavelab.Name = "butsavelab"
        Me.butsavelab.Size = New System.Drawing.Size(100, 36)
        Me.butsavelab.TabIndex = 192
        Me.butsavelab.UseVisualStyleBackColor = True
        Me.butsavelab.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label1.Location = New System.Drawing.Point(8, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 17)
        Me.Label1.TabIndex = 532
        Me.Label1.Text = "Lokasi :"
        '
        'CheckBoxJatiuwung
        '
        Me.CheckBoxJatiuwung.AutoSize = True
        Me.CheckBoxJatiuwung.Checked = True
        Me.CheckBoxJatiuwung.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxJatiuwung.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.CheckBoxJatiuwung.Location = New System.Drawing.Point(65, 77)
        Me.CheckBoxJatiuwung.Name = "CheckBoxJatiuwung"
        Me.CheckBoxJatiuwung.Size = New System.Drawing.Size(84, 21)
        Me.CheckBoxJatiuwung.TabIndex = 533
        Me.CheckBoxJatiuwung.Tag = "0223B069"
        Me.CheckBoxJatiuwung.Text = "Jatiuwung"
        Me.CheckBoxJatiuwung.UseVisualStyleBackColor = True
        '
        'CheckBoxPasarKemis
        '
        Me.CheckBoxPasarKemis.AutoSize = True
        Me.CheckBoxPasarKemis.Checked = True
        Me.CheckBoxPasarKemis.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxPasarKemis.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.CheckBoxPasarKemis.Location = New System.Drawing.Point(155, 77)
        Me.CheckBoxPasarKemis.Name = "CheckBoxPasarKemis"
        Me.CheckBoxPasarKemis.Size = New System.Drawing.Size(98, 21)
        Me.CheckBoxPasarKemis.TabIndex = 534
        Me.CheckBoxPasarKemis.Tag = "0221B186"
        Me.CheckBoxPasarKemis.Text = "Pasar Kemis"
        Me.CheckBoxPasarKemis.UseVisualStyleBackColor = True
        '
        'FormValidasiFaskesPasien
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1101, 540)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1216, 579)
        Me.MinimumSize = New System.Drawing.Size(1098, 558)
        Me.Name = "FormValidasiFaskesPasien"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Upload Tindakan Laboratorium"
        Me.GroupBox1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.gridlab, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.ResumeLayout(False)
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.PerformLayout()
        CType(Me.gridexcel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents gridlab As DevExpress.XtraGrid.GridControl
    Private WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents butsavelab As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents butsavemultiple As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents rdOnline As System.Windows.Forms.RadioButton
    Friend WithEvents rdOffline As System.Windows.Forms.RadioButton
    Friend WithEvents txloc As System.Windows.Forms.TextBox
    Friend WithEvents butfindloc As System.Windows.Forms.Button
    Friend WithEvents NamaLokasi As System.Windows.Forms.Label
    Friend WithEvents txidloc As System.Windows.Forms.TextBox
    Friend WithEvents gridexcel As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PanelKeadaanUmumMenuPemeriksaanAwal As System.Windows.Forms.Panel
    Friend WithEvents RadioButtonKesimpulanYa As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonKesimpulanTidak As System.Windows.Forms.RadioButton
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents TextBoxResponseSukses As System.Windows.Forms.TextBox
    Friend WithEvents ButtonSinkronisasi As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TextBoxResponseGagal As System.Windows.Forms.TextBox
    Friend WithEvents ButtonStopProses As System.Windows.Forms.Button
    Friend WithEvents ButtonUploadData As System.Windows.Forms.Button
    Friend WithEvents TextBoxCount As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxPasarKemis As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxJatiuwung As System.Windows.Forms.CheckBox
End Class
