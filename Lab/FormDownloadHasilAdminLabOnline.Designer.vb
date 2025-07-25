<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDownloadHasilAdminLabOnline
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormDownloadHasilAdminLabOnline))
        Me.gridpoli = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.butsave = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbfaskes = New System.Windows.Forms.ComboBox
        Me.btnviewriwayatpeserta = New System.Windows.Forms.Button
        Me.cmbjeniskunjungan = New System.Windows.Forms.ComboBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.dttglpendaftaran = New System.Windows.Forms.DateTimePicker
        Me.Label9 = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.ClearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.gridtrans = New DevExpress.XtraGrid.GridControl
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txtagihanid = New System.Windows.Forms.TextBox
        Me.butrekappasien = New System.Windows.Forms.Button
        Me.butfindnotagihan = New System.Windows.Forms.Button
        Me.txnotagihan = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.chkeditbayar = New System.Windows.Forms.CheckBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.dtakhirbayar = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.dtawalbayar = New System.Windows.Forms.DateTimePicker
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Button6 = New System.Windows.Forms.Button
        Me.Label15 = New System.Windows.Forms.Label
        Me.dtakhirtagihanbelumlunas = New System.Windows.Forms.DateTimePicker
        Me.dtawaltagihanbelumlunas = New System.Windows.Forms.DateTimePicker
        Me.Label14 = New System.Windows.Forms.Label
        Me.Button5 = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.dtakhirlaporancompany = New System.Windows.Forms.DateTimePicker
        Me.Label12 = New System.Windows.Forms.Label
        Me.dtawallaporancompany = New System.Windows.Forms.DateTimePicker
        Me.kodecabang = New DevExpress.XtraGrid.Columns.GridColumn
        Me.kodebarcode = New DevExpress.XtraGrid.Columns.GridColumn
        Me.kodeket = New DevExpress.XtraGrid.Columns.GridColumn
        CType(Me.gridpoli, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.gridtrans, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'gridpoli
        '
        Me.gridpoli.Cursor = System.Windows.Forms.Cursors.Hand
        Me.gridpoli.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridpoli.EmbeddedNavigator.Name = ""
        Me.gridpoli.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gridpoli.Location = New System.Drawing.Point(3, 13)
        Me.gridpoli.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D
        Me.gridpoli.MainView = Me.GridView1
        Me.gridpoli.Name = "gridpoli"
        Me.gridpoli.Size = New System.Drawing.Size(1133, 361)
        Me.gridpoli.TabIndex = 116
        Me.gridpoli.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.kodecabang, Me.kodebarcode, Me.kodeket})
        Me.GridView1.GridControl = Me.gridpoli
        Me.GridView1.Name = "GridView1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmbfaskes)
        Me.GroupBox1.Controls.Add(Me.btnviewriwayatpeserta)
        Me.GroupBox1.Controls.Add(Me.cmbjeniskunjungan)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.dttglpendaftaran)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1147, 93)
        Me.GroupBox1.TabIndex = 117
        Me.GroupBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(284, 29)
        Me.Label2.TabIndex = 213
        Me.Label2.Text = "Riwayat Pendaftaran Peserta"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.butsave)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel1.Location = New System.Drawing.Point(1034, 16)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(110, 74)
        Me.Panel1.TabIndex = 212
        '
        'butsave
        '
        Me.butsave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.butsave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butsave.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butsave.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_kosong
        Me.butsave.Location = New System.Drawing.Point(3, 31)
        Me.butsave.Name = "butsave"
        Me.butsave.Size = New System.Drawing.Size(100, 36)
        Me.butsave.TabIndex = 211
        Me.butsave.Text = "DELETE"
        Me.butsave.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 54)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 20)
        Me.Label1.TabIndex = 205
        Me.Label1.Text = "Faskes"
        '
        'cmbfaskes
        '
        Me.cmbfaskes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbfaskes.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbfaskes.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbfaskes.FormattingEnabled = True
        Me.cmbfaskes.Location = New System.Drawing.Point(68, 55)
        Me.cmbfaskes.Name = "cmbfaskes"
        Me.cmbfaskes.Size = New System.Drawing.Size(148, 28)
        Me.cmbfaskes.TabIndex = 204
        '
        'btnviewriwayatpeserta
        '
        Me.btnviewriwayatpeserta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnviewriwayatpeserta.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnviewriwayatpeserta.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_cari
        Me.btnviewriwayatpeserta.Location = New System.Drawing.Point(788, 51)
        Me.btnviewriwayatpeserta.Name = "btnviewriwayatpeserta"
        Me.btnviewriwayatpeserta.Size = New System.Drawing.Size(99, 36)
        Me.btnviewriwayatpeserta.TabIndex = 120
        Me.btnviewriwayatpeserta.UseVisualStyleBackColor = True
        '
        'cmbjeniskunjungan
        '
        Me.cmbjeniskunjungan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbjeniskunjungan.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbjeniskunjungan.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbjeniskunjungan.FormattingEnabled = True
        Me.cmbjeniskunjungan.Items.AddRange(New Object() {"Semua", "Kunjungan Sakit", "Kunjungan Sehat"})
        Me.cmbjeniskunjungan.Location = New System.Drawing.Point(618, 55)
        Me.cmbjeniskunjungan.Name = "cmbjeniskunjungan"
        Me.cmbjeniskunjungan.Size = New System.Drawing.Size(147, 28)
        Me.cmbjeniskunjungan.TabIndex = 198
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(512, 58)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(101, 20)
        Me.Label16.TabIndex = 192
        Me.Label16.Text = "Jenis Kunjungan"
        '
        'dttglpendaftaran
        '
        Me.dttglpendaftaran.CalendarFont = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dttglpendaftaran.CustomFormat = "dd-MMM-yyyy"
        Me.dttglpendaftaran.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dttglpendaftaran.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dttglpendaftaran.Location = New System.Drawing.Point(363, 54)
        Me.dttglpendaftaran.Name = "dttglpendaftaran"
        Me.dttglpendaftaran.Size = New System.Drawing.Size(125, 25)
        Me.dttglpendaftaran.TabIndex = 120
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(233, 54)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(126, 20)
        Me.Label9.TabIndex = 190
        Me.Label9.Text = "Tanggal Pendaftaran"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearToolStripMenuItem, Me.CloseToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1147, 24)
        Me.MenuStrip1.TabIndex = 118
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ClearToolStripMenuItem
        '
        Me.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem"
        Me.ClearToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.ClearToolStripMenuItem.Text = "Clear"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 117)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1147, 403)
        Me.TabControl1.TabIndex = 119
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Transparent
        Me.TabPage1.Controls.Add(Me.gridpoli)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1139, 377)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Riwayat Peserta"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1133, 10)
        Me.GroupBox2.TabIndex = 118
        Me.GroupBox2.TabStop = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.gridtrans)
        Me.TabPage2.Controls.Add(Me.GroupBox4)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1139, 377)
        Me.TabPage2.TabIndex = 2
        Me.TabPage2.Text = "Rekap Tagihan"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'gridtrans
        '
        Me.gridtrans.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridtrans.EmbeddedNavigator.Name = ""
        Me.gridtrans.Location = New System.Drawing.Point(3, 65)
        Me.gridtrans.MainView = Me.GridView3
        Me.gridtrans.Name = "gridtrans"
        Me.gridtrans.Size = New System.Drawing.Size(1133, 309)
        Me.gridtrans.TabIndex = 116
        Me.gridtrans.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.gridtrans
        Me.GridView3.Name = "GridView3"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox4.Controls.Add(Me.txtagihanid)
        Me.GroupBox4.Controls.Add(Me.butrekappasien)
        Me.GroupBox4.Controls.Add(Me.butfindnotagihan)
        Me.GroupBox4.Controls.Add(Me.txnotagihan)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox4.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1133, 62)
        Me.GroupBox4.TabIndex = 121
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Display"
        '
        'txtagihanid
        '
        Me.txtagihanid.Enabled = False
        Me.txtagihanid.Location = New System.Drawing.Point(283, 19)
        Me.txtagihanid.Name = "txtagihanid"
        Me.txtagihanid.Size = New System.Drawing.Size(47, 20)
        Me.txtagihanid.TabIndex = 191
        '
        'butrekappasien
        '
        Me.butrekappasien.Cursor = System.Windows.Forms.Cursors.Hand
        Me.butrekappasien.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butrekappasien.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butrekappasien.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_kosong
        Me.butrekappasien.Location = New System.Drawing.Point(479, 11)
        Me.butrekappasien.Name = "butrekappasien"
        Me.butrekappasien.Size = New System.Drawing.Size(100, 36)
        Me.butrekappasien.TabIndex = 188
        Me.butrekappasien.Text = "REKAP PASIEN"
        Me.butrekappasien.UseVisualStyleBackColor = True
        '
        'butfindnotagihan
        '
        Me.butfindnotagihan.Location = New System.Drawing.Point(336, 17)
        Me.butfindnotagihan.Name = "butfindnotagihan"
        Me.butfindnotagihan.Size = New System.Drawing.Size(31, 23)
        Me.butfindnotagihan.TabIndex = 186
        Me.butfindnotagihan.Text = "..."
        Me.butfindnotagihan.UseVisualStyleBackColor = True
        '
        'txnotagihan
        '
        Me.txnotagihan.Enabled = False
        Me.txnotagihan.Location = New System.Drawing.Point(114, 19)
        Me.txnotagihan.Name = "txnotagihan"
        Me.txnotagihan.Size = New System.Drawing.Size(163, 20)
        Me.txnotagihan.TabIndex = 184
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(8, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(100, 13)
        Me.Label11.TabIndex = 185
        Me.Label11.Text = "Display No Tagihan"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.GridControl1)
        Me.TabPage3.Controls.Add(Me.GroupBox3)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1139, 377)
        Me.TabPage3.TabIndex = 1
        Me.TabPage3.Text = "Pelunasan"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.EmbeddedNavigator.Name = ""
        Me.GridControl1.Location = New System.Drawing.Point(0, 70)
        Me.GridControl1.MainView = Me.GridView2
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1139, 307)
        Me.GridControl1.TabIndex = 119
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GridControl1
        Me.GridView2.Name = "GridView2"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox3.Controls.Add(Me.chkeditbayar)
        Me.GroupBox3.Controls.Add(Me.Button3)
        Me.GroupBox3.Controls.Add(Me.dtakhirbayar)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.dtawalbayar)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1139, 70)
        Me.GroupBox3.TabIndex = 120
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Display"
        '
        'chkeditbayar
        '
        Me.chkeditbayar.AutoSize = True
        Me.chkeditbayar.Location = New System.Drawing.Point(145, 47)
        Me.chkeditbayar.Name = "chkeditbayar"
        Me.chkeditbayar.Size = New System.Drawing.Size(88, 17)
        Me.chkeditbayar.TabIndex = 118
        Me.chkeditbayar.Text = "Edit Tgl Awal"
        Me.chkeditbayar.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button3.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_add
        Me.Button3.Location = New System.Drawing.Point(834, 14)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(100, 36)
        Me.Button3.TabIndex = 117
        Me.Button3.UseVisualStyleBackColor = True
        '
        'dtakhirbayar
        '
        Me.dtakhirbayar.CustomFormat = "dd-MMM-yyyy"
        Me.dtakhirbayar.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtakhirbayar.Location = New System.Drawing.Point(289, 21)
        Me.dtakhirbayar.Name = "dtakhirbayar"
        Me.dtakhirbayar.Size = New System.Drawing.Size(109, 20)
        Me.dtakhirbayar.TabIndex = 115
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(260, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(23, 13)
        Me.Label7.TabIndex = 114
        Me.Label7.Text = "s/d"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(131, 13)
        Me.Label8.TabIndex = 113
        Me.Label8.Text = "Periode Tampilan Tagihan"
        '
        'dtawalbayar
        '
        Me.dtawalbayar.CustomFormat = "dd-MMM-yyyy"
        Me.dtawalbayar.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtawalbayar.Location = New System.Drawing.Point(145, 21)
        Me.dtawalbayar.Name = "dtawalbayar"
        Me.dtawalbayar.Size = New System.Drawing.Size(109, 20)
        Me.dtawalbayar.TabIndex = 112
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.GroupBox5)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(1139, 377)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Report"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox5.Controls.Add(Me.Button6)
        Me.GroupBox5.Controls.Add(Me.Label15)
        Me.GroupBox5.Controls.Add(Me.dtakhirtagihanbelumlunas)
        Me.GroupBox5.Controls.Add(Me.dtawaltagihanbelumlunas)
        Me.GroupBox5.Controls.Add(Me.Label14)
        Me.GroupBox5.Controls.Add(Me.Button5)
        Me.GroupBox5.Controls.Add(Me.Label13)
        Me.GroupBox5.Controls.Add(Me.dtakhirlaporancompany)
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Controls.Add(Me.dtawallaporancompany)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox5.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(1133, 371)
        Me.GroupBox5.TabIndex = 2
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Laporan Pelunasan "
        '
        'Button6
        '
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button6.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_cetak
        Me.Button6.Location = New System.Drawing.Point(280, 117)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(100, 36)
        Me.Button6.TabIndex = 9
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(130, 130)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(23, 13)
        Me.Label15.TabIndex = 8
        Me.Label15.Text = "s/d"
        '
        'dtakhirtagihanbelumlunas
        '
        Me.dtakhirtagihanbelumlunas.CustomFormat = "dd-MMM-yyyy"
        Me.dtakhirtagihanbelumlunas.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtakhirtagihanbelumlunas.Location = New System.Drawing.Point(159, 123)
        Me.dtakhirtagihanbelumlunas.Name = "dtakhirtagihanbelumlunas"
        Me.dtakhirtagihanbelumlunas.Size = New System.Drawing.Size(101, 20)
        Me.dtakhirtagihanbelumlunas.TabIndex = 7
        '
        'dtawaltagihanbelumlunas
        '
        Me.dtawaltagihanbelumlunas.CustomFormat = "dd-MMM-yyyy"
        Me.dtawaltagihanbelumlunas.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtawaltagihanbelumlunas.Location = New System.Drawing.Point(12, 124)
        Me.dtawaltagihanbelumlunas.Name = "dtawaltagihanbelumlunas"
        Me.dtawaltagihanbelumlunas.Size = New System.Drawing.Size(108, 20)
        Me.dtawaltagihanbelumlunas.TabIndex = 6
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(12, 94)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(184, 13)
        Me.Label14.TabIndex = 5
        Me.Label14.Text = "Laporan Tagihan yang Belum dilunasi"
        '
        'Button5
        '
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button5.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_cetak
        Me.Button5.Location = New System.Drawing.Point(280, 46)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(100, 36)
        Me.Button5.TabIndex = 4
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(127, 52)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(23, 13)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "s/d"
        '
        'dtakhirlaporancompany
        '
        Me.dtakhirlaporancompany.CustomFormat = "dd-MMM-yyyy"
        Me.dtakhirlaporancompany.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtakhirlaporancompany.Location = New System.Drawing.Point(156, 53)
        Me.dtakhirlaporancompany.Name = "dtakhirlaporancompany"
        Me.dtakhirlaporancompany.Size = New System.Drawing.Size(104, 20)
        Me.dtakhirlaporancompany.TabIndex = 2
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(9, 28)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(154, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Laporan Tagihan Per Company"
        '
        'dtawallaporancompany
        '
        Me.dtawallaporancompany.CustomFormat = "dd-MMM-yyyy"
        Me.dtawallaporancompany.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtawallaporancompany.Location = New System.Drawing.Point(12, 53)
        Me.dtawallaporancompany.Name = "dtawallaporancompany"
        Me.dtawallaporancompany.Size = New System.Drawing.Size(108, 20)
        Me.dtawallaporancompany.TabIndex = 1
        '
        'kodecabang
        '
        Me.kodecabang.Caption = "kodecabang"
        Me.kodecabang.Name = "kodecabang"
        Me.kodecabang.Visible = True
        Me.kodecabang.VisibleIndex = 0
        '
        'kodebarcode
        '
        Me.kodebarcode.Caption = "kodebarcode"
        Me.kodebarcode.Name = "kodebarcode"
        Me.kodebarcode.Visible = True
        Me.kodebarcode.VisibleIndex = 1
        '
        'kodeket
        '
        Me.kodeket.Caption = "kodeket"
        Me.kodeket.Name = "kodeket"
        Me.kodeket.Visible = True
        Me.kodeket.VisibleIndex = 2
        '
        'FormDownloadHasilAdminLabOnline
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1147, 520)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormDownloadHasilAdminLabOnline"
        Me.Text = "FormDownloadHasilAdminLabOnline"
        CType(Me.gridpoli, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.gridtrans, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ClearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents dtakhirbayar As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtawalbayar As System.Windows.Forms.DateTimePicker
    Friend WithEvents chkeditbayar As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Private WithEvents gridpoli As DevExpress.XtraGrid.GridControl
    Private WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Private WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents gridtrans As DevExpress.XtraGrid.GridControl
    Private WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents butfindnotagihan As System.Windows.Forms.Button
    Friend WithEvents txnotagihan As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents butrekappasien As System.Windows.Forms.Button
    Friend WithEvents txtagihanid As System.Windows.Forms.TextBox
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dtawallaporancompany As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents dtakhirlaporancompany As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtakhirtagihanbelumlunas As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtawaltagihanbelumlunas As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dttglpendaftaran As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmbjeniskunjungan As System.Windows.Forms.ComboBox
    Friend WithEvents btnviewriwayatpeserta As System.Windows.Forms.Button
    Friend WithEvents butsave As System.Windows.Forms.Button
    Friend WithEvents cmbfaskes As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents kodecabang As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents kodebarcode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents kodeket As DevExpress.XtraGrid.Columns.GridColumn
End Class
