<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAwalPembayaranTagihan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAwalPembayaranTagihan))
        Me.gridpoli = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtotalsisa = New System.Windows.Forms.TextBox
        Me.txtotalpembayaran = New System.Windows.Forms.TextBox
        Me.txtotaltagihan = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.rdrekap = New System.Windows.Forms.RadioButton
        Me.butfindcomp = New System.Windows.Forms.Button
        Me.txcompanycode = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.butdisplay = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.ClearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.chkedittagihan = New System.Windows.Forms.CheckBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.dtakhir = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.dtawal = New System.Windows.Forms.DateTimePicker
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.gridtrans = New DevExpress.XtraGrid.GridControl
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txtagihanid = New System.Windows.Forms.TextBox
        Me.rdblmrekap = New System.Windows.Forms.RadioButton
        Me.butrekappasien = New System.Windows.Forms.Button
        Me.butnewtagihan = New System.Windows.Forms.Button
        Me.butfindnotagihan = New System.Windows.Forms.Button
        Me.txnotagihan = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.butcreatetagihan = New System.Windows.Forms.Button
        Me.butdisplaytangga = New System.Windows.Forms.Button
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.chkeditbayar = New System.Windows.Forms.CheckBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
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
        CType(Me.gridpoli, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
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
        Me.gridpoli.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridpoli.EmbeddedNavigator.Name = ""
        Me.gridpoli.Location = New System.Drawing.Point(3, 78)
        Me.gridpoli.MainView = Me.GridView1
        Me.gridpoli.Name = "gridpoli"
        Me.gridpoli.Size = New System.Drawing.Size(937, 312)
        Me.gridpoli.TabIndex = 116
        Me.gridpoli.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.gridpoli
        Me.GridView1.Name = "GridView1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtotalsisa)
        Me.GroupBox1.Controls.Add(Me.txtotalpembayaran)
        Me.GroupBox1.Controls.Add(Me.txtotaltagihan)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.rdrekap)
        Me.GroupBox1.Controls.Add(Me.butfindcomp)
        Me.GroupBox1.Controls.Add(Me.txcompanycode)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.butdisplay)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(951, 77)
        Me.GroupBox1.TabIndex = 117
        Me.GroupBox1.TabStop = False
        '
        'txtotalsisa
        '
        Me.txtotalsisa.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtotalsisa.Location = New System.Drawing.Point(786, 39)
        Me.txtotalsisa.Name = "txtotalsisa"
        Me.txtotalsisa.Size = New System.Drawing.Size(152, 29)
        Me.txtotalsisa.TabIndex = 189
        '
        'txtotalpembayaran
        '
        Me.txtotalpembayaran.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtotalpembayaran.Location = New System.Drawing.Point(625, 39)
        Me.txtotalpembayaran.Name = "txtotalpembayaran"
        Me.txtotalpembayaran.Size = New System.Drawing.Size(152, 29)
        Me.txtotalpembayaran.TabIndex = 188
        '
        'txtotaltagihan
        '
        Me.txtotaltagihan.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtotaltagihan.Location = New System.Drawing.Point(466, 41)
        Me.txtotaltagihan.Name = "txtotaltagihan"
        Me.txtotaltagihan.Size = New System.Drawing.Size(152, 29)
        Me.txtotaltagihan.TabIndex = 187
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(783, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(120, 16)
        Me.Label4.TabIndex = 186
        Me.Label4.Text = "Sisa Pembayaran"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(622, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(124, 16)
        Me.Label3.TabIndex = 185
        Me.Label3.Text = "Total Pembayaran"
        '
        'rdrekap
        '
        Me.rdrekap.AutoSize = True
        Me.rdrekap.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdrekap.Location = New System.Drawing.Point(216, 48)
        Me.rdrekap.Name = "rdrekap"
        Me.rdrekap.Size = New System.Drawing.Size(141, 19)
        Me.rdrekap.TabIndex = 189
        Me.rdrekap.TabStop = True
        Me.rdrekap.Text = "Tagihan sdh di Cetak"
        Me.rdrekap.UseVisualStyleBackColor = True
        Me.rdrekap.Visible = False
        '
        'butfindcomp
        '
        Me.butfindcomp.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butfindcomp.Location = New System.Drawing.Point(399, 14)
        Me.butfindcomp.Name = "butfindcomp"
        Me.butfindcomp.Size = New System.Drawing.Size(31, 23)
        Me.butfindcomp.TabIndex = 183
        Me.butfindcomp.Text = "..."
        Me.butfindcomp.UseVisualStyleBackColor = True
        '
        'txcompanycode
        '
        Me.txcompanycode.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txcompanycode.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txcompanycode.Location = New System.Drawing.Point(134, 15)
        Me.txcompanycode.Name = "txcompanycode"
        Me.txcompanycode.ReadOnly = True
        Me.txcompanycode.Size = New System.Drawing.Size(260, 22)
        Me.txcompanycode.TabIndex = 181
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 15)
        Me.Label2.TabIndex = 182
        Me.Label2.Text = "Nama Perusahaan"
        '
        'butdisplay
        '
        Me.butdisplay.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.butdisplay.Location = New System.Drawing.Point(134, 45)
        Me.butdisplay.Name = "butdisplay"
        Me.butdisplay.Size = New System.Drawing.Size(75, 23)
        Me.butdisplay.TabIndex = 112
        Me.butdisplay.Text = "Display"
        Me.butdisplay.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(463, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 16)
        Me.Label1.TabIndex = 111
        Me.Label1.Text = "Total Tagihan"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearToolStripMenuItem, Me.CloseToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(951, 24)
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
        Me.TabControl1.Location = New System.Drawing.Point(0, 101)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(951, 419)
        Me.TabControl1.TabIndex = 119
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.gridpoli)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(943, 393)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Tagihan"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox2.Controls.Add(Me.chkedittagihan)
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.dtakhir)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.dtawal)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(937, 75)
        Me.GroupBox2.TabIndex = 118
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Display"
        '
        'chkedittagihan
        '
        Me.chkedittagihan.AutoSize = True
        Me.chkedittagihan.Location = New System.Drawing.Point(145, 46)
        Me.chkedittagihan.Name = "chkedittagihan"
        Me.chkedittagihan.Size = New System.Drawing.Size(88, 17)
        Me.chkedittagihan.TabIndex = 119
        Me.chkedittagihan.Text = "Edit Tgl Awal"
        Me.chkedittagihan.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_cari
        Me.Button1.Location = New System.Drawing.Point(404, 13)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 36)
        Me.Button1.TabIndex = 116
        Me.Button1.UseVisualStyleBackColor = True
        '
        'dtakhir
        '
        Me.dtakhir.CustomFormat = "dd-MMM-yyyy"
        Me.dtakhir.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtakhir.Location = New System.Drawing.Point(289, 20)
        Me.dtakhir.Name = "dtakhir"
        Me.dtakhir.Size = New System.Drawing.Size(109, 20)
        Me.dtakhir.TabIndex = 115
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(260, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(23, 13)
        Me.Label6.TabIndex = 114
        Me.Label6.Text = "s/d"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(131, 13)
        Me.Label5.TabIndex = 113
        Me.Label5.Text = "Periode Tampilan Tagihan"
        '
        'dtawal
        '
        Me.dtawal.CustomFormat = "dd-MMM-yyyy"
        Me.dtawal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtawal.Location = New System.Drawing.Point(145, 20)
        Me.dtawal.Name = "dtawal"
        Me.dtawal.Size = New System.Drawing.Size(109, 20)
        Me.dtawal.TabIndex = 112
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.gridtrans)
        Me.TabPage2.Controls.Add(Me.GroupBox4)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(943, 393)
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
        Me.gridtrans.Size = New System.Drawing.Size(937, 325)
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
        Me.GroupBox4.Controls.Add(Me.rdblmrekap)
        Me.GroupBox4.Controls.Add(Me.butrekappasien)
        Me.GroupBox4.Controls.Add(Me.butnewtagihan)
        Me.GroupBox4.Controls.Add(Me.butfindnotagihan)
        Me.GroupBox4.Controls.Add(Me.txnotagihan)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.butcreatetagihan)
        Me.GroupBox4.Controls.Add(Me.butdisplaytangga)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox4.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(937, 62)
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
        'rdblmrekap
        '
        Me.rdblmrekap.AutoSize = True
        Me.rdblmrekap.Location = New System.Drawing.Point(703, 20)
        Me.rdblmrekap.Name = "rdblmrekap"
        Me.rdblmrekap.Size = New System.Drawing.Size(128, 17)
        Me.rdblmrekap.TabIndex = 190
        Me.rdblmrekap.TabStop = True
        Me.rdblmrekap.Text = "Tagihan blm di Create"
        Me.rdblmrekap.UseVisualStyleBackColor = True
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
        'butnewtagihan
        '
        Me.butnewtagihan.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butnewtagihan.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butnewtagihan.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_kosong
        Me.butnewtagihan.Location = New System.Drawing.Point(373, 11)
        Me.butnewtagihan.Name = "butnewtagihan"
        Me.butnewtagihan.Size = New System.Drawing.Size(100, 36)
        Me.butnewtagihan.TabIndex = 187
        Me.butnewtagihan.Text = "CLEAR"
        Me.butnewtagihan.UseVisualStyleBackColor = True
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
        'butcreatetagihan
        '
        Me.butcreatetagihan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.butcreatetagihan.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butcreatetagihan.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_kosong
        Me.butcreatetagihan.Location = New System.Drawing.Point(585, 11)
        Me.butcreatetagihan.Name = "butcreatetagihan"
        Me.butcreatetagihan.Size = New System.Drawing.Size(100, 36)
        Me.butcreatetagihan.TabIndex = 117
        Me.butcreatetagihan.Text = "CREATE TAGIHAN"
        Me.butcreatetagihan.UseVisualStyleBackColor = True
        '
        'butdisplaytangga
        '
        Me.butdisplaytangga.Cursor = System.Windows.Forms.Cursors.Hand
        Me.butdisplaytangga.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butdisplaytangga.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_cari
        Me.butdisplaytangga.Location = New System.Drawing.Point(831, 11)
        Me.butdisplaytangga.Name = "butdisplaytangga"
        Me.butdisplaytangga.Size = New System.Drawing.Size(100, 36)
        Me.butdisplaytangga.TabIndex = 116
        Me.butdisplaytangga.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.GridControl1)
        Me.TabPage3.Controls.Add(Me.GroupBox3)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(943, 393)
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
        Me.GridControl1.Size = New System.Drawing.Size(943, 323)
        Me.GridControl1.TabIndex = 119
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.GridControl1
        Me.GridView2.GroupPanelText = "Daftar Invoice Lunas"
        Me.GridView2.Name = "GridView2"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox3.Controls.Add(Me.chkeditbayar)
        Me.GroupBox3.Controls.Add(Me.Button3)
        Me.GroupBox3.Controls.Add(Me.Button2)
        Me.GroupBox3.Controls.Add(Me.dtakhirbayar)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.dtawalbayar)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(943, 70)
        Me.GroupBox3.TabIndex = 120
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Display"
        '
        'chkeditbayar
        '
        Me.chkeditbayar.AutoSize = True
        Me.chkeditbayar.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.chkeditbayar.Location = New System.Drawing.Point(165, 47)
        Me.chkeditbayar.Name = "chkeditbayar"
        Me.chkeditbayar.Size = New System.Drawing.Size(95, 19)
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
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button2.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_cari
        Me.Button2.Location = New System.Drawing.Point(427, 14)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(100, 36)
        Me.Button2.TabIndex = 116
        Me.Button2.UseVisualStyleBackColor = True
        '
        'dtakhirbayar
        '
        Me.dtakhirbayar.CustomFormat = "dd-MMM-yyyy"
        Me.dtakhirbayar.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.dtakhirbayar.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtakhirbayar.Location = New System.Drawing.Point(309, 21)
        Me.dtakhirbayar.Name = "dtakhirbayar"
        Me.dtakhirbayar.Size = New System.Drawing.Size(109, 21)
        Me.dtakhirbayar.TabIndex = 115
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(280, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(24, 15)
        Me.Label7.TabIndex = 114
        Me.Label7.Text = "s/d"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label8.Location = New System.Drawing.Point(10, 24)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(151, 15)
        Me.Label8.TabIndex = 113
        Me.Label8.Text = "Periode Tampilan Tagihan"
        '
        'dtawalbayar
        '
        Me.dtawalbayar.CustomFormat = "dd-MMM-yyyy"
        Me.dtawalbayar.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.dtawalbayar.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtawalbayar.Location = New System.Drawing.Point(165, 21)
        Me.dtawalbayar.Name = "dtawalbayar"
        Me.dtawalbayar.Size = New System.Drawing.Size(109, 21)
        Me.dtawalbayar.TabIndex = 112
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.GroupBox5)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(943, 393)
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
        Me.GroupBox5.Size = New System.Drawing.Size(937, 387)
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
        'FormAwalPembayaranTagihan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(951, 520)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormAwalPembayaranTagihan"
        Me.Text = "Pelunasan Tagihan"
        CType(Me.gridpoli, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
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
    Friend WithEvents butdisplay As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ClearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents butfindcomp As System.Windows.Forms.Button
    Friend WithEvents txcompanycode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtawal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents dtakhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents dtakhirbayar As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtawalbayar As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtotalsisa As System.Windows.Forms.TextBox
    Friend WithEvents txtotalpembayaran As System.Windows.Forms.TextBox
    Friend WithEvents txtotaltagihan As System.Windows.Forms.TextBox
    Friend WithEvents chkeditbayar As System.Windows.Forms.CheckBox
    Friend WithEvents chkedittagihan As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Private WithEvents gridpoli As DevExpress.XtraGrid.GridControl
    Private WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Private WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents gridtrans As DevExpress.XtraGrid.GridControl
    Private WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents butcreatetagihan As System.Windows.Forms.Button
    Friend WithEvents butdisplaytangga As System.Windows.Forms.Button
    Friend WithEvents butnewtagihan As System.Windows.Forms.Button
    Friend WithEvents butfindnotagihan As System.Windows.Forms.Button
    Friend WithEvents txnotagihan As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents butrekappasien As System.Windows.Forms.Button
    Friend WithEvents rdblmrekap As System.Windows.Forms.RadioButton
    Friend WithEvents rdrekap As System.Windows.Forms.RadioButton
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
End Class
