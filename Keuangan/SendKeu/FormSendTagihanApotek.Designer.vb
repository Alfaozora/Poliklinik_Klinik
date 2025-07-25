<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSendTagihanApotek
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSendTagihanApotek))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.NewToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.groupcustomer = New System.Windows.Forms.GroupBox
        Me.txfaktur = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.dttglbeban = New System.Windows.Forms.DateTimePicker
        Me.Label11 = New System.Windows.Forms.Label
        Me.dttglnota = New System.Windows.Forms.DateTimePicker
        Me.Label10 = New System.Windows.Forms.Label
        Me.txjenispengajuan = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txketreject = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txnominal = New System.Windows.Forms.TextBox
        Me.butreject = New System.Windows.Forms.Button
        Me.txpembayaran = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txloc = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.butselectsupp = New System.Windows.Forms.Button
        Me.txsuppket = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.butsaved = New System.Windows.Forms.Button
        Me.dtprocessend = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.dtprocess = New System.Windows.Forms.DateTimePicker
        Me.buttambahpasien = New System.Windows.Forms.Button
        Me.gridrujukan = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.MenuStrip1.SuspendLayout()
        Me.groupcustomer.SuspendLayout()
        CType(Me.gridrujukan, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.groupcustomer.Controls.Add(Me.txfaktur)
        Me.groupcustomer.Controls.Add(Me.Label12)
        Me.groupcustomer.Controls.Add(Me.dttglbeban)
        Me.groupcustomer.Controls.Add(Me.Label11)
        Me.groupcustomer.Controls.Add(Me.dttglnota)
        Me.groupcustomer.Controls.Add(Me.Label10)
        Me.groupcustomer.Controls.Add(Me.txjenispengajuan)
        Me.groupcustomer.Controls.Add(Me.Label7)
        Me.groupcustomer.Controls.Add(Me.Label6)
        Me.groupcustomer.Controls.Add(Me.Label4)
        Me.groupcustomer.Controls.Add(Me.txketreject)
        Me.groupcustomer.Controls.Add(Me.Label1)
        Me.groupcustomer.Controls.Add(Me.txnominal)
        Me.groupcustomer.Controls.Add(Me.butreject)
        Me.groupcustomer.Controls.Add(Me.txpembayaran)
        Me.groupcustomer.Controls.Add(Me.Label3)
        Me.groupcustomer.Controls.Add(Me.txloc)
        Me.groupcustomer.Controls.Add(Me.Label2)
        Me.groupcustomer.Controls.Add(Me.butselectsupp)
        Me.groupcustomer.Controls.Add(Me.txsuppket)
        Me.groupcustomer.Controls.Add(Me.Label8)
        Me.groupcustomer.Controls.Add(Me.butsaved)
        Me.groupcustomer.Controls.Add(Me.dtprocessend)
        Me.groupcustomer.Controls.Add(Me.Label5)
        Me.groupcustomer.Controls.Add(Me.Label9)
        Me.groupcustomer.Controls.Add(Me.dtprocess)
        Me.groupcustomer.Controls.Add(Me.buttambahpasien)
        Me.groupcustomer.Dock = System.Windows.Forms.DockStyle.Top
        Me.groupcustomer.Location = New System.Drawing.Point(0, 24)
        Me.groupcustomer.Name = "groupcustomer"
        Me.groupcustomer.Size = New System.Drawing.Size(1200, 174)
        Me.groupcustomer.TabIndex = 10
        Me.groupcustomer.TabStop = False
        Me.groupcustomer.Text = "Tambah Data"
        '
        'txfaktur
        '
        Me.txfaktur.BackColor = System.Drawing.SystemColors.Window
        Me.txfaktur.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txfaktur.Location = New System.Drawing.Point(479, 71)
        Me.txfaktur.Name = "txfaktur"
        Me.txfaktur.ReadOnly = True
        Me.txfaktur.Size = New System.Drawing.Size(250, 21)
        Me.txfaktur.TabIndex = 275
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(400, 74)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 16)
        Me.Label12.TabIndex = 274
        Me.Label12.Text = "Ket. Faktur"
        '
        'dttglbeban
        '
        Me.dttglbeban.CustomFormat = "dd-MMM-yyyy"
        Me.dttglbeban.Enabled = False
        Me.dttglbeban.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dttglbeban.Location = New System.Drawing.Point(641, 46)
        Me.dttglbeban.Name = "dttglbeban"
        Me.dttglbeban.Size = New System.Drawing.Size(88, 20)
        Me.dttglbeban.TabIndex = 272
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(569, 49)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(66, 16)
        Me.Label11.TabIndex = 271
        Me.Label11.Text = "Tgl Beban"
        '
        'dttglnota
        '
        Me.dttglnota.CustomFormat = "dd-MMM-yyyy"
        Me.dttglnota.Enabled = False
        Me.dttglnota.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dttglnota.Location = New System.Drawing.Point(479, 46)
        Me.dttglnota.Name = "dttglnota"
        Me.dttglnota.Size = New System.Drawing.Size(88, 20)
        Me.dttglnota.TabIndex = 270
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(417, 49)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 16)
        Me.Label10.TabIndex = 269
        Me.Label10.Text = "Tgl Nota"
        '
        'txjenispengajuan
        '
        Me.txjenispengajuan.BackColor = System.Drawing.SystemColors.Window
        Me.txjenispengajuan.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txjenispengajuan.Location = New System.Drawing.Point(479, 21)
        Me.txjenispengajuan.Name = "txjenispengajuan"
        Me.txjenispengajuan.ReadOnly = True
        Me.txjenispengajuan.Size = New System.Drawing.Size(250, 21)
        Me.txjenispengajuan.TabIndex = 267
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(435, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(38, 16)
        Me.Label7.TabIndex = 266
        Me.Label7.Text = "Jenis"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(435, 146)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(294, 14)
        Me.Label6.TabIndex = 265
        Me.Label6.Text = "*Keterangan Reject Wajib Diisi Jika Melakukan Reject"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(394, 124)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 16)
        Me.Label4.TabIndex = 264
        Me.Label4.Text = "Ket. Reject"
        '
        'txketreject
        '
        Me.txketreject.BackColor = System.Drawing.SystemColors.Window
        Me.txketreject.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txketreject.Location = New System.Drawing.Point(479, 121)
        Me.txketreject.Name = "txketreject"
        Me.txketreject.Size = New System.Drawing.Size(250, 21)
        Me.txketreject.TabIndex = 263
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(418, 98)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 16)
        Me.Label1.TabIndex = 262
        Me.Label1.Text = "Nominal"
        '
        'txnominal
        '
        Me.txnominal.BackColor = System.Drawing.SystemColors.Window
        Me.txnominal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txnominal.Location = New System.Drawing.Point(479, 96)
        Me.txnominal.Name = "txnominal"
        Me.txnominal.ReadOnly = True
        Me.txnominal.Size = New System.Drawing.Size(250, 21)
        Me.txnominal.TabIndex = 261
        '
        'butreject
        '
        Me.butreject.Cursor = System.Windows.Forms.Cursors.Hand
        Me.butreject.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butreject.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butreject.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_kosong
        Me.butreject.Location = New System.Drawing.Point(971, 105)
        Me.butreject.Name = "butreject"
        Me.butreject.Size = New System.Drawing.Size(100, 36)
        Me.butreject.TabIndex = 260
        Me.butreject.Text = "REJECT"
        Me.butreject.UseVisualStyleBackColor = True
        '
        'txpembayaran
        '
        Me.txpembayaran.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txpembayaran.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.txpembayaran.Location = New System.Drawing.Point(109, 95)
        Me.txpembayaran.Multiline = True
        Me.txpembayaran.Name = "txpembayaran"
        Me.txpembayaran.ReadOnly = True
        Me.txpembayaran.Size = New System.Drawing.Size(250, 46)
        Me.txpembayaran.TabIndex = 259
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 16)
        Me.Label3.TabIndex = 258
        Me.Label3.Text = "Pembayaran"
        '
        'txloc
        '
        Me.txloc.BackColor = System.Drawing.SystemColors.Window
        Me.txloc.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txloc.Location = New System.Drawing.Point(109, 70)
        Me.txloc.Name = "txloc"
        Me.txloc.ReadOnly = True
        Me.txloc.Size = New System.Drawing.Size(250, 21)
        Me.txloc.TabIndex = 257
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(51, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 16)
        Me.Label2.TabIndex = 256
        Me.Label2.Text = "Lokasi"
        '
        'butselectsupp
        '
        Me.butselectsupp.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butselectsupp.Location = New System.Drawing.Point(328, 43)
        Me.butselectsupp.Name = "butselectsupp"
        Me.butselectsupp.Size = New System.Drawing.Size(31, 25)
        Me.butselectsupp.TabIndex = 254
        Me.butselectsupp.Text = "..."
        Me.butselectsupp.UseVisualStyleBackColor = True
        '
        'txsuppket
        '
        Me.txsuppket.BackColor = System.Drawing.SystemColors.Window
        Me.txsuppket.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txsuppket.Location = New System.Drawing.Point(109, 45)
        Me.txsuppket.Name = "txsuppket"
        Me.txsuppket.ReadOnly = True
        Me.txsuppket.Size = New System.Drawing.Size(215, 21)
        Me.txsuppket.TabIndex = 253
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(42, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 16)
        Me.Label8.TabIndex = 251
        Me.Label8.Text = "Supplier"
        '
        'butsaved
        '
        Me.butsaved.Cursor = System.Windows.Forms.Cursors.Hand
        Me.butsaved.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butsaved.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_save
        Me.butsaved.Location = New System.Drawing.Point(868, 105)
        Me.butsaved.Name = "butsaved"
        Me.butsaved.Size = New System.Drawing.Size(100, 36)
        Me.butsaved.TabIndex = 246
        Me.butsaved.UseVisualStyleBackColor = True
        '
        'dtprocessend
        '
        Me.dtprocessend.CustomFormat = "dd-MMM-yyyy"
        Me.dtprocessend.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtprocessend.Location = New System.Drawing.Point(249, 20)
        Me.dtprocessend.Name = "dtprocessend"
        Me.dtprocessend.Size = New System.Drawing.Size(110, 20)
        Me.dtprocessend.TabIndex = 243
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(221, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(26, 16)
        Me.Label5.TabIndex = 242
        Me.Label5.Text = "s/d"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 16)
        Me.Label9.TabIndex = 241
        Me.Label9.Text = "Tgl Transaksi"
        '
        'dtprocess
        '
        Me.dtprocess.CustomFormat = "dd-MMM-yyyy"
        Me.dtprocess.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtprocess.Location = New System.Drawing.Point(109, 20)
        Me.dtprocess.Name = "dtprocess"
        Me.dtprocess.Size = New System.Drawing.Size(110, 20)
        Me.dtprocess.TabIndex = 237
        '
        'buttambahpasien
        '
        Me.buttambahpasien.Cursor = System.Windows.Forms.Cursors.Hand
        Me.buttambahpasien.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.buttambahpasien.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_add
        Me.buttambahpasien.Location = New System.Drawing.Point(765, 105)
        Me.buttambahpasien.Name = "buttambahpasien"
        Me.buttambahpasien.Size = New System.Drawing.Size(100, 36)
        Me.buttambahpasien.TabIndex = 234
        Me.buttambahpasien.UseVisualStyleBackColor = True
        '
        'gridrujukan
        '
        Me.gridrujukan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridrujukan.EmbeddedNavigator.Name = ""
        Me.gridrujukan.Location = New System.Drawing.Point(0, 198)
        Me.gridrujukan.MainView = Me.GridView1
        Me.gridrujukan.Name = "gridrujukan"
        Me.gridrujukan.Size = New System.Drawing.Size(1200, 342)
        Me.gridrujukan.TabIndex = 11
        Me.gridrujukan.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.gridrujukan
        Me.GridView1.GroupPanelText = "Data LPB"
        Me.GridView1.Name = "GridView1"
        '
        'FormSendTagihanApotek
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1200, 540)
        Me.Controls.Add(Me.gridrujukan)
        Me.Controls.Add(Me.groupcustomer)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormSendTagihanApotek"
        Me.Text = "Send Tagihan Apotek"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.groupcustomer.ResumeLayout(False)
        Me.groupcustomer.PerformLayout()
        CType(Me.gridrujukan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents NewToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents groupcustomer As System.Windows.Forms.GroupBox
    'Friend WithEvents butlabrujukanid As DevExpress.XtraEditors.ButtonEdit
    'Friend WithEvents butrujukanid As DevExpress.XtraEditors.ButtonEdit
    Private WithEvents gridrujukan As DevExpress.XtraGrid.GridControl
    Private WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents buttambahpasien As System.Windows.Forms.Button
    Friend WithEvents dtprocessend As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtprocess As System.Windows.Forms.DateTimePicker
    Friend WithEvents butsaved As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents butselectsupp As System.Windows.Forms.Button
    Friend WithEvents txsuppket As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txloc As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txpembayaran As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txketreject As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txnominal As System.Windows.Forms.TextBox
    Friend WithEvents butreject As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txjenispengajuan As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dttglbeban As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dttglnota As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txfaktur As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
End Class
