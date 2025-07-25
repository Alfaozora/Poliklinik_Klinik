<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DaftarPeserta
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txkodecabang = New System.Windows.Forms.TextBox
        Me.butfindcompany = New System.Windows.Forms.Button
        Me.txcompanycode = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.dtend = New System.Windows.Forms.DateTimePicker
        Me.dtstart = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lbltotalpesertatidakhadir = New System.Windows.Forms.Label
        Me.lbltotalpesertahadir = New System.Windows.Forms.Label
        Me.lbltotalpeserta = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.rd3 = New System.Windows.Forms.RadioButton
        Me.rd2 = New System.Windows.Forms.RadioButton
        Me.rd1 = New System.Windows.Forms.RadioButton
        Me.txpaketid = New System.Windows.Forms.TextBox
        Me.butfindpaketid = New System.Windows.Forms.Button
        Me.txpaketnama = New System.Windows.Forms.TextBox
        Me.lblpaketnama = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.cmbpembayaran = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbpembayaran)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txkodecabang)
        Me.GroupBox1.Controls.Add(Me.butfindcompany)
        Me.GroupBox1.Controls.Add(Me.txcompanycode)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.dtend)
        Me.GroupBox1.Controls.Add(Me.dtstart)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.rd3)
        Me.GroupBox1.Controls.Add(Me.rd2)
        Me.GroupBox1.Controls.Add(Me.rd1)
        Me.GroupBox1.Controls.Add(Me.txpaketid)
        Me.GroupBox1.Controls.Add(Me.butfindpaketid)
        Me.GroupBox1.Controls.Add(Me.txpaketnama)
        Me.GroupBox1.Controls.Add(Me.lblpaketnama)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 27)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(932, 199)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detail Paket"
        '
        'txkodecabang
        '
        Me.txkodecabang.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txkodecabang.Location = New System.Drawing.Point(113, 54)
        Me.txkodecabang.Name = "txkodecabang"
        Me.txkodecabang.Size = New System.Drawing.Size(100, 21)
        Me.txkodecabang.TabIndex = 228
        Me.txkodecabang.Visible = False
        '
        'butfindcompany
        '
        Me.butfindcompany.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butfindcompany.Location = New System.Drawing.Point(356, 51)
        Me.butfindcompany.Name = "butfindcompany"
        Me.butfindcompany.Size = New System.Drawing.Size(31, 25)
        Me.butfindcompany.TabIndex = 231
        Me.butfindcompany.Text = "..."
        Me.butfindcompany.UseVisualStyleBackColor = True
        '
        'txcompanycode
        '
        Me.txcompanycode.BackColor = System.Drawing.SystemColors.Window
        Me.txcompanycode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txcompanycode.Location = New System.Drawing.Point(113, 54)
        Me.txcompanycode.Name = "txcompanycode"
        Me.txcompanycode.ReadOnly = True
        Me.txcompanycode.Size = New System.Drawing.Size(237, 21)
        Me.txcompanycode.TabIndex = 230
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(24, 56)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(63, 16)
        Me.Label16.TabIndex = 229
        Me.Label16.Text = "Company"
        '
        'dtend
        '
        Me.dtend.CustomFormat = "dd-MMM-yyyy"
        Me.dtend.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtend.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtend.Location = New System.Drawing.Point(312, 112)
        Me.dtend.Name = "dtend"
        Me.dtend.Size = New System.Drawing.Size(144, 25)
        Me.dtend.TabIndex = 65
        '
        'dtstart
        '
        Me.dtstart.CustomFormat = "dd-MMM-yyyy"
        Me.dtstart.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtstart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtstart.Location = New System.Drawing.Point(113, 112)
        Me.dtstart.Name = "dtstart"
        Me.dtstart.Size = New System.Drawing.Size(138, 25)
        Me.dtstart.TabIndex = 64
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(257, 119)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 15)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Tgl End"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(35, 119)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 15)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Tgl Start"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Panel1.Controls.Add(Me.lbltotalpesertatidakhadir)
        Me.Panel1.Controls.Add(Me.lbltotalpesertahadir)
        Me.Panel1.Controls.Add(Me.lbltotalpeserta)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(504, 25)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(295, 115)
        Me.Panel1.TabIndex = 10
        '
        'lbltotalpesertatidakhadir
        '
        Me.lbltotalpesertatidakhadir.AutoSize = True
        Me.lbltotalpesertatidakhadir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalpesertatidakhadir.Location = New System.Drawing.Point(192, 73)
        Me.lbltotalpesertatidakhadir.Name = "lbltotalpesertatidakhadir"
        Me.lbltotalpesertatidakhadir.Size = New System.Drawing.Size(14, 15)
        Me.lbltotalpesertatidakhadir.TabIndex = 5
        Me.lbltotalpesertatidakhadir.Text = "0"
        '
        'lbltotalpesertahadir
        '
        Me.lbltotalpesertahadir.AutoSize = True
        Me.lbltotalpesertahadir.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalpesertahadir.Location = New System.Drawing.Point(192, 47)
        Me.lbltotalpesertahadir.Name = "lbltotalpesertahadir"
        Me.lbltotalpesertahadir.Size = New System.Drawing.Size(14, 15)
        Me.lbltotalpesertahadir.TabIndex = 4
        Me.lbltotalpesertahadir.Text = "0"
        '
        'lbltotalpeserta
        '
        Me.lbltotalpeserta.AutoSize = True
        Me.lbltotalpeserta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalpeserta.Location = New System.Drawing.Point(192, 22)
        Me.lbltotalpeserta.Name = "lbltotalpeserta"
        Me.lbltotalpeserta.Size = New System.Drawing.Size(14, 15)
        Me.lbltotalpeserta.TabIndex = 3
        Me.lbltotalpeserta.Text = "0"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(31, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(160, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Peserta Tidak/Belum Hadir :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(103, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Peserta Hadir :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(106, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(85, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Total Peserta :"
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_cari
        Me.Button1.Location = New System.Drawing.Point(410, 152)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 36)
        Me.Button1.TabIndex = 7
        Me.Button1.UseVisualStyleBackColor = True
        '
        'rd3
        '
        Me.rd3.AutoSize = True
        Me.rd3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rd3.Location = New System.Drawing.Point(294, 161)
        Me.rd3.Name = "rd3"
        Me.rd3.Size = New System.Drawing.Size(110, 19)
        Me.rd3.TabIndex = 6
        Me.rd3.TabStop = True
        Me.rd3.Text = "Semua Peserta"
        Me.rd3.UseVisualStyleBackColor = True
        '
        'rd2
        '
        Me.rd2.AutoSize = True
        Me.rd2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rd2.Location = New System.Drawing.Point(116, 161)
        Me.rd2.Name = "rd2"
        Me.rd2.Size = New System.Drawing.Size(172, 19)
        Me.rd2.TabIndex = 5
        Me.rd2.TabStop = True
        Me.rd2.Text = "Peserta Tidak/Belum Hadir"
        Me.rd2.UseVisualStyleBackColor = True
        '
        'rd1
        '
        Me.rd1.AutoSize = True
        Me.rd1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rd1.Location = New System.Drawing.Point(10, 161)
        Me.rd1.Name = "rd1"
        Me.rd1.Size = New System.Drawing.Size(100, 19)
        Me.rd1.TabIndex = 4
        Me.rd1.TabStop = True
        Me.rd1.Text = "Peserta Hadir"
        Me.rd1.UseVisualStyleBackColor = True
        '
        'txpaketid
        '
        Me.txpaketid.Enabled = False
        Me.txpaketid.Location = New System.Drawing.Point(392, 25)
        Me.txpaketid.Name = "txpaketid"
        Me.txpaketid.Size = New System.Drawing.Size(46, 20)
        Me.txpaketid.TabIndex = 3
        '
        'butfindpaketid
        '
        Me.butfindpaketid.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold)
        Me.butfindpaketid.Location = New System.Drawing.Point(356, 22)
        Me.butfindpaketid.Name = "butfindpaketid"
        Me.butfindpaketid.Size = New System.Drawing.Size(31, 25)
        Me.butfindpaketid.TabIndex = 2
        Me.butfindpaketid.Text = "..."
        Me.butfindpaketid.UseVisualStyleBackColor = True
        '
        'txpaketnama
        '
        Me.txpaketnama.Enabled = False
        Me.txpaketnama.Location = New System.Drawing.Point(113, 24)
        Me.txpaketnama.Name = "txpaketnama"
        Me.txpaketnama.Size = New System.Drawing.Size(237, 20)
        Me.txpaketnama.TabIndex = 1
        '
        'lblpaketnama
        '
        Me.lblpaketnama.AutoSize = True
        Me.lblpaketnama.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblpaketnama.Location = New System.Drawing.Point(13, 25)
        Me.lblpaketnama.Name = "lblpaketnama"
        Me.lblpaketnama.Size = New System.Drawing.Size(75, 15)
        Me.lblpaketnama.TabIndex = 0
        Me.lblpaketnama.Text = "Nama Paket"
        Me.lblpaketnama.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 224)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(932, 283)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.GridControl1)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(3, 16)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(926, 264)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Detail Peserta"
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.EmbeddedNavigator.Name = ""
        Me.GridControl1.Location = New System.Drawing.Point(3, 16)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(920, 245)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.CloseToolStripMenuItem, Me.PrintToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(932, 24)
        Me.MenuStrip1.TabIndex = 5
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'cmbpembayaran
        '
        Me.cmbpembayaran.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbpembayaran.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbpembayaran.FormattingEnabled = True
        Me.cmbpembayaran.Items.AddRange(New Object() {"TAGIHAN", "DEBET", "TUNAI", "CARD"})
        Me.cmbpembayaran.Location = New System.Drawing.Point(113, 81)
        Me.cmbpembayaran.Name = "cmbpembayaran"
        Me.cmbpembayaran.Size = New System.Drawing.Size(237, 24)
        Me.cmbpembayaran.TabIndex = 243
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 16)
        Me.Label4.TabIndex = 242
        Me.Label4.Text = "Pembayaran"
        '
        'DaftarPeserta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(932, 519)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "DaftarPeserta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Daftar Peserta MCU"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Private WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Private WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents butfindpaketid As System.Windows.Forms.Button
    Friend WithEvents txpaketnama As System.Windows.Forms.TextBox
    Friend WithEvents lblpaketnama As System.Windows.Forms.Label
    Friend WithEvents txpaketid As System.Windows.Forms.TextBox
    Friend WithEvents rd3 As System.Windows.Forms.RadioButton
    Friend WithEvents rd2 As System.Windows.Forms.RadioButton
    Friend WithEvents rd1 As System.Windows.Forms.RadioButton
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbltotalpesertatidakhadir As System.Windows.Forms.Label
    Friend WithEvents lbltotalpesertahadir As System.Windows.Forms.Label
    Friend WithEvents lbltotalpeserta As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtend As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtstart As System.Windows.Forms.DateTimePicker
    Friend WithEvents txkodecabang As System.Windows.Forms.TextBox
    Friend WithEvents butfindcompany As System.Windows.Forms.Button
    Friend WithEvents txcompanycode As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cmbpembayaran As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
