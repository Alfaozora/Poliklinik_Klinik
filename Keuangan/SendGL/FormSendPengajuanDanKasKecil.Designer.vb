<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSendPengajuanDanKasKecil
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSendPengajuanDanKasKecil))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.NewToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.groupcustomer = New System.Windows.Forms.GroupBox
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.butsearch = New System.Windows.Forms.Button
        Me.CheckAll = New System.Windows.Forms.CheckBox
        Me.butkalkulasi = New System.Windows.Forms.Button
        Me.rdkaskecil = New System.Windows.Forms.RadioButton
        Me.rdpengajuan = New System.Windows.Forms.RadioButton
        Me.Label15 = New System.Windows.Forms.Label
        Me.txbankid = New System.Windows.Forms.TextBox
        Me.butselectbank = New System.Windows.Forms.Button
        Me.txsendnominal = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txnominal = New System.Windows.Forms.TextBox
        Me.txbankket = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txlocationid = New System.Windows.Forms.TextBox
        Me.butselectlocation = New System.Windows.Forms.Button
        Me.txlocationket = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.butsaved = New System.Windows.Forms.Button
        Me.dtprocessend = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.dtprocess = New System.Windows.Forms.DateTimePicker
        Me.gridtransaksi = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.txDatabase = New System.Windows.Forms.TextBox
        Me.MenuStrip1.SuspendLayout()
        Me.groupcustomer.SuspendLayout()
        CType(Me.gridtransaksi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1200, 24)
        Me.MenuStrip1.TabIndex = 9
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'NewToolStripMenuItem1
        '
        Me.NewToolStripMenuItem1.Name = "NewToolStripMenuItem1"
        Me.NewToolStripMenuItem1.Size = New System.Drawing.Size(65, 20)
        Me.NewToolStripMenuItem1.Text = "Set Clear"
        '
        'groupcustomer
        '
        Me.groupcustomer.Controls.Add(Me.txDatabase)
        Me.groupcustomer.Controls.Add(Me.ProgressBar1)
        Me.groupcustomer.Controls.Add(Me.butsearch)
        Me.groupcustomer.Controls.Add(Me.CheckAll)
        Me.groupcustomer.Controls.Add(Me.butkalkulasi)
        Me.groupcustomer.Controls.Add(Me.rdkaskecil)
        Me.groupcustomer.Controls.Add(Me.rdpengajuan)
        Me.groupcustomer.Controls.Add(Me.Label15)
        Me.groupcustomer.Controls.Add(Me.txbankid)
        Me.groupcustomer.Controls.Add(Me.butselectbank)
        Me.groupcustomer.Controls.Add(Me.txsendnominal)
        Me.groupcustomer.Controls.Add(Me.Label1)
        Me.groupcustomer.Controls.Add(Me.txnominal)
        Me.groupcustomer.Controls.Add(Me.txbankket)
        Me.groupcustomer.Controls.Add(Me.Label3)
        Me.groupcustomer.Controls.Add(Me.txlocationid)
        Me.groupcustomer.Controls.Add(Me.butselectlocation)
        Me.groupcustomer.Controls.Add(Me.txlocationket)
        Me.groupcustomer.Controls.Add(Me.Label8)
        Me.groupcustomer.Controls.Add(Me.butsaved)
        Me.groupcustomer.Controls.Add(Me.dtprocessend)
        Me.groupcustomer.Controls.Add(Me.Label5)
        Me.groupcustomer.Controls.Add(Me.Label9)
        Me.groupcustomer.Controls.Add(Me.dtprocess)
        Me.groupcustomer.Dock = System.Windows.Forms.DockStyle.Top
        Me.groupcustomer.Location = New System.Drawing.Point(0, 24)
        Me.groupcustomer.Name = "groupcustomer"
        Me.groupcustomer.Size = New System.Drawing.Size(1200, 140)
        Me.groupcustomer.TabIndex = 10
        Me.groupcustomer.TabStop = False
        Me.groupcustomer.Text = "Tambah Data"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.BackColor = System.Drawing.Color.Lime
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 125)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(783, 5)
        Me.ProgressBar1.TabIndex = 293
        '
        'butsearch
        '
        Me.butsearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.butsearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butsearch.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_cari
        Me.butsearch.Location = New System.Drawing.Point(590, 84)
        Me.butsearch.Name = "butsearch"
        Me.butsearch.Size = New System.Drawing.Size(100, 36)
        Me.butsearch.TabIndex = 292
        Me.butsearch.UseVisualStyleBackColor = True
        '
        'CheckAll
        '
        Me.CheckAll.AutoSize = True
        Me.CheckAll.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckAll.Location = New System.Drawing.Point(380, 93)
        Me.CheckAll.Name = "CheckAll"
        Me.CheckAll.Size = New System.Drawing.Size(97, 20)
        Me.CheckAll.TabIndex = 291
        Me.CheckAll.Text = "Pilih Semua"
        Me.CheckAll.UseVisualStyleBackColor = True
        '
        'butkalkulasi
        '
        Me.butkalkulasi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.butkalkulasi.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butkalkulasi.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_kalkulasi
        Me.butkalkulasi.Location = New System.Drawing.Point(485, 84)
        Me.butkalkulasi.Name = "butkalkulasi"
        Me.butkalkulasi.Size = New System.Drawing.Size(100, 36)
        Me.butkalkulasi.TabIndex = 290
        Me.butkalkulasi.UseVisualStyleBackColor = True
        '
        'rdkaskecil
        '
        Me.rdkaskecil.AutoSize = True
        Me.rdkaskecil.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdkaskecil.Location = New System.Drawing.Point(635, 20)
        Me.rdkaskecil.Name = "rdkaskecil"
        Me.rdkaskecil.Size = New System.Drawing.Size(77, 19)
        Me.rdkaskecil.TabIndex = 283
        Me.rdkaskecil.TabStop = True
        Me.rdkaskecil.Text = "Kas Kecil"
        Me.rdkaskecil.UseVisualStyleBackColor = True
        '
        'rdpengajuan
        '
        Me.rdpengajuan.AutoSize = True
        Me.rdpengajuan.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdpengajuan.Location = New System.Drawing.Point(545, 20)
        Me.rdpengajuan.Name = "rdpengajuan"
        Me.rdpengajuan.Size = New System.Drawing.Size(85, 19)
        Me.rdpengajuan.TabIndex = 284
        Me.rdpengajuan.TabStop = True
        Me.rdpengajuan.Text = "Pengajuan"
        Me.rdpengajuan.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(435, 23)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(98, 16)
        Me.Label15.TabIndex = 285
        Me.Label15.Text = "Jenis Transaksi"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txbankid
        '
        Me.txbankid.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txbankid.Location = New System.Drawing.Point(106, 80)
        Me.txbankid.Name = "txbankid"
        Me.txbankid.Size = New System.Drawing.Size(100, 21)
        Me.txbankid.TabIndex = 280
        Me.txbankid.Visible = False
        '
        'butselectbank
        '
        Me.butselectbank.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butselectbank.Location = New System.Drawing.Point(325, 80)
        Me.butselectbank.Name = "butselectbank"
        Me.butselectbank.Size = New System.Drawing.Size(31, 25)
        Me.butselectbank.TabIndex = 282
        Me.butselectbank.Text = "..."
        Me.butselectbank.UseVisualStyleBackColor = True
        '
        'txsendnominal
        '
        Me.txsendnominal.BackColor = System.Drawing.SystemColors.Window
        Me.txsendnominal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txsendnominal.Location = New System.Drawing.Point(545, 50)
        Me.txsendnominal.Name = "txsendnominal"
        Me.txsendnominal.ReadOnly = True
        Me.txsendnominal.Size = New System.Drawing.Size(48, 21)
        Me.txsendnominal.TabIndex = 276
        Me.txsendnominal.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(478, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 16)
        Me.Label1.TabIndex = 262
        Me.Label1.Text = "Nominal"
        '
        'txnominal
        '
        Me.txnominal.BackColor = System.Drawing.SystemColors.Window
        Me.txnominal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txnominal.Location = New System.Drawing.Point(545, 50)
        Me.txnominal.Name = "txnominal"
        Me.txnominal.ReadOnly = True
        Me.txnominal.Size = New System.Drawing.Size(250, 21)
        Me.txnominal.TabIndex = 261
        '
        'txbankket
        '
        Me.txbankket.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txbankket.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.txbankket.Location = New System.Drawing.Point(106, 80)
        Me.txbankket.Multiline = True
        Me.txbankket.Name = "txbankket"
        Me.txbankket.ReadOnly = True
        Me.txbankket.Size = New System.Drawing.Size(215, 40)
        Me.txbankket.TabIndex = 259
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(53, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 16)
        Me.Label3.TabIndex = 258
        Me.Label3.Text = "Bank"
        '
        'txlocationid
        '
        Me.txlocationid.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txlocationid.Location = New System.Drawing.Point(106, 50)
        Me.txlocationid.Name = "txlocationid"
        Me.txlocationid.Size = New System.Drawing.Size(100, 21)
        Me.txlocationid.TabIndex = 252
        Me.txlocationid.Visible = False
        '
        'butselectlocation
        '
        Me.butselectlocation.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butselectlocation.Location = New System.Drawing.Point(325, 50)
        Me.butselectlocation.Name = "butselectlocation"
        Me.butselectlocation.Size = New System.Drawing.Size(31, 25)
        Me.butselectlocation.TabIndex = 254
        Me.butselectlocation.Text = "..."
        Me.butselectlocation.UseVisualStyleBackColor = True
        '
        'txlocationket
        '
        Me.txlocationket.BackColor = System.Drawing.SystemColors.Window
        Me.txlocationket.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txlocationket.Location = New System.Drawing.Point(106, 50)
        Me.txlocationket.Name = "txlocationket"
        Me.txlocationket.ReadOnly = True
        Me.txlocationket.Size = New System.Drawing.Size(215, 21)
        Me.txlocationket.TabIndex = 253
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(45, 53)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 16)
        Me.Label8.TabIndex = 251
        Me.Label8.Text = "Lokasi"
        '
        'butsaved
        '
        Me.butsaved.Cursor = System.Windows.Forms.Cursors.Hand
        Me.butsaved.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butsaved.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_save
        Me.butsaved.Location = New System.Drawing.Point(695, 84)
        Me.butsaved.Name = "butsaved"
        Me.butsaved.Size = New System.Drawing.Size(100, 36)
        Me.butsaved.TabIndex = 246
        Me.butsaved.UseVisualStyleBackColor = True
        '
        'dtprocessend
        '
        Me.dtprocessend.CustomFormat = "dd-MMM-yyyy"
        Me.dtprocessend.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtprocessend.Location = New System.Drawing.Point(246, 20)
        Me.dtprocessend.Name = "dtprocessend"
        Me.dtprocessend.Size = New System.Drawing.Size(110, 20)
        Me.dtprocessend.TabIndex = 243
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(218, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(26, 16)
        Me.Label5.TabIndex = 242
        Me.Label5.Text = "s/d"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(9, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(82, 16)
        Me.Label9.TabIndex = 241
        Me.Label9.Text = "Tgl Realisasi"
        '
        'dtprocess
        '
        Me.dtprocess.CustomFormat = "dd-MMM-yyyy"
        Me.dtprocess.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtprocess.Location = New System.Drawing.Point(106, 20)
        Me.dtprocess.Name = "dtprocess"
        Me.dtprocess.Size = New System.Drawing.Size(110, 20)
        Me.dtprocess.TabIndex = 237
        '
        'gridtransaksi
        '
        Me.gridtransaksi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridtransaksi.EmbeddedNavigator.Name = ""
        Me.gridtransaksi.Location = New System.Drawing.Point(0, 164)
        Me.gridtransaksi.MainView = Me.GridView1
        Me.gridtransaksi.Name = "gridtransaksi"
        Me.gridtransaksi.Size = New System.Drawing.Size(1200, 376)
        Me.gridtransaksi.TabIndex = 11
        Me.gridtransaksi.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.gridtransaksi
        Me.GridView1.GroupPanelText = "Data Transaksi"
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        '
        'txDatabase
        '
        Me.txDatabase.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txDatabase.Location = New System.Drawing.Point(236, 50)
        Me.txDatabase.Name = "txDatabase"
        Me.txDatabase.Size = New System.Drawing.Size(85, 21)
        Me.txDatabase.TabIndex = 253
        '
        'FormSendPengajuanDanKasKecil
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1200, 540)
        Me.Controls.Add(Me.gridtransaksi)
        Me.Controls.Add(Me.groupcustomer)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormSendPengajuanDanKasKecil"
        Me.Text = "Send Pengajuan & Kas Kecil (GL)"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.groupcustomer.ResumeLayout(False)
        Me.groupcustomer.PerformLayout()
        CType(Me.gridtransaksi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents NewToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents groupcustomer As System.Windows.Forms.GroupBox
    'Friend WithEvents butlabrujukanid As DevExpress.XtraEditors.ButtonEdit
    'Friend WithEvents butrujukanid As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents dtprocessend As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtprocess As System.Windows.Forms.DateTimePicker
    Friend WithEvents butsaved As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txlocationid As System.Windows.Forms.TextBox
    Friend WithEvents butselectlocation As System.Windows.Forms.Button
    Friend WithEvents txlocationket As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txbankket As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txnominal As System.Windows.Forms.TextBox
    Friend WithEvents txsendnominal As System.Windows.Forms.TextBox
    Friend WithEvents txbankid As System.Windows.Forms.TextBox
    Friend WithEvents butselectbank As System.Windows.Forms.Button
    Friend WithEvents rdkaskecil As System.Windows.Forms.RadioButton
    Friend WithEvents rdpengajuan As System.Windows.Forms.RadioButton
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents CheckAll As System.Windows.Forms.CheckBox
    Friend WithEvents butkalkulasi As System.Windows.Forms.Button
    Friend WithEvents butsearch As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gridtransaksi As DevExpress.XtraGrid.GridControl
    Friend WithEvents txDatabase As System.Windows.Forms.TextBox
End Class
