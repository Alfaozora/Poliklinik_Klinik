<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCreateRujukan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCreateRujukan))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.NewToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.CetakSuratRujukanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.groupcustomer = New System.Windows.Forms.GroupBox
        Me.txharga = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtindakanid = New System.Windows.Forms.TextBox
        Me.buttindakan = New System.Windows.Forms.Button
        Me.txtindakanket = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txprinted = New System.Windows.Forms.TextBox
        Me.txnosurat = New System.Windows.Forms.TextBox
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txlabrujukanid = New System.Windows.Forms.TextBox
        Me.butlabrujukan = New System.Windows.Forms.Button
        Me.txlabrujukanket = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtgllab = New System.Windows.Forms.TextBox
        Me.butsaved = New System.Windows.Forms.Button
        Me.dtprocessend = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.dtprocess = New System.Windows.Forms.DateTimePicker
        Me.buttambahpasien = New System.Windows.Forms.Button
        Me.gridpasien = New DevExpress.XtraGrid.GridControl
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.dtnow = New System.Windows.Forms.DateTimePicker
        Me.gridrujukan = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.CheckBoxUpload = New System.Windows.Forms.CheckBox
        Me.ProgressBarOnline = New System.Windows.Forms.ProgressBar
        Me.MenuStrip1.SuspendLayout()
        Me.groupcustomer.SuspendLayout()
        CType(Me.gridpasien, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridrujukan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem1, Me.CetakSuratRujukanToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(932, 24)
        Me.MenuStrip1.TabIndex = 9
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'NewToolStripMenuItem1
        '
        Me.NewToolStripMenuItem1.Name = "NewToolStripMenuItem1"
        Me.NewToolStripMenuItem1.Size = New System.Drawing.Size(65, 20)
        Me.NewToolStripMenuItem1.Text = "Set Clear"
        '
        'CetakSuratRujukanToolStripMenuItem
        '
        Me.CetakSuratRujukanToolStripMenuItem.Name = "CetakSuratRujukanToolStripMenuItem"
        Me.CetakSuratRujukanToolStripMenuItem.Size = New System.Drawing.Size(136, 20)
        Me.CetakSuratRujukanToolStripMenuItem.Text = "Preview Surat Rujukan"
        '
        'groupcustomer
        '
        Me.groupcustomer.Controls.Add(Me.ProgressBarOnline)
        Me.groupcustomer.Controls.Add(Me.CheckBoxUpload)
        Me.groupcustomer.Controls.Add(Me.txharga)
        Me.groupcustomer.Controls.Add(Me.Label6)
        Me.groupcustomer.Controls.Add(Me.txtindakanid)
        Me.groupcustomer.Controls.Add(Me.buttindakan)
        Me.groupcustomer.Controls.Add(Me.txtindakanket)
        Me.groupcustomer.Controls.Add(Me.Label4)
        Me.groupcustomer.Controls.Add(Me.txprinted)
        Me.groupcustomer.Controls.Add(Me.txnosurat)
        Me.groupcustomer.Controls.Add(Me.LinkLabel1)
        Me.groupcustomer.Controls.Add(Me.Label3)
        Me.groupcustomer.Controls.Add(Me.Label2)
        Me.groupcustomer.Controls.Add(Me.Label1)
        Me.groupcustomer.Controls.Add(Me.txlabrujukanid)
        Me.groupcustomer.Controls.Add(Me.butlabrujukan)
        Me.groupcustomer.Controls.Add(Me.txlabrujukanket)
        Me.groupcustomer.Controls.Add(Me.Label8)
        Me.groupcustomer.Controls.Add(Me.txtgllab)
        Me.groupcustomer.Controls.Add(Me.butsaved)
        Me.groupcustomer.Controls.Add(Me.dtprocessend)
        Me.groupcustomer.Controls.Add(Me.Label5)
        Me.groupcustomer.Controls.Add(Me.Label9)
        Me.groupcustomer.Controls.Add(Me.dtprocess)
        Me.groupcustomer.Controls.Add(Me.buttambahpasien)
        Me.groupcustomer.Controls.Add(Me.gridpasien)
        Me.groupcustomer.Controls.Add(Me.dtnow)
        Me.groupcustomer.Dock = System.Windows.Forms.DockStyle.Top
        Me.groupcustomer.Location = New System.Drawing.Point(0, 24)
        Me.groupcustomer.Name = "groupcustomer"
        Me.groupcustomer.Size = New System.Drawing.Size(932, 227)
        Me.groupcustomer.TabIndex = 10
        Me.groupcustomer.TabStop = False
        Me.groupcustomer.Text = "Tambah Data"
        '
        'txharga
        '
        Me.txharga.BackColor = System.Drawing.SystemColors.Window
        Me.txharga.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txharga.Location = New System.Drawing.Point(109, 105)
        Me.txharga.Name = "txharga"
        Me.txharga.Size = New System.Drawing.Size(109, 21)
        Me.txharga.TabIndex = 266
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(55, 108)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 16)
        Me.Label6.TabIndex = 265
        Me.Label6.Text = "Harga"
        '
        'txtindakanid
        '
        Me.txtindakanid.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtindakanid.Location = New System.Drawing.Point(109, 75)
        Me.txtindakanid.Name = "txtindakanid"
        Me.txtindakanid.Size = New System.Drawing.Size(100, 21)
        Me.txtindakanid.TabIndex = 261
        Me.txtindakanid.Visible = False
        '
        'buttindakan
        '
        Me.buttindakan.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buttindakan.Location = New System.Drawing.Point(367, 73)
        Me.buttindakan.Name = "buttindakan"
        Me.buttindakan.Size = New System.Drawing.Size(31, 25)
        Me.buttindakan.TabIndex = 264
        Me.buttindakan.Text = "..."
        Me.buttindakan.UseVisualStyleBackColor = True
        '
        'txtindakanket
        '
        Me.txtindakanket.BackColor = System.Drawing.SystemColors.Window
        Me.txtindakanket.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtindakanket.Location = New System.Drawing.Point(109, 75)
        Me.txtindakanket.Name = "txtindakanket"
        Me.txtindakanket.ReadOnly = True
        Me.txtindakanket.Size = New System.Drawing.Size(251, 21)
        Me.txtindakanket.TabIndex = 263
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(37, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 16)
        Me.Label4.TabIndex = 262
        Me.Label4.Text = "Tindakan"
        '
        'txprinted
        '
        Me.txprinted.Location = New System.Drawing.Point(409, 39)
        Me.txprinted.Name = "txprinted"
        Me.txprinted.Size = New System.Drawing.Size(30, 20)
        Me.txprinted.TabIndex = 260
        Me.txprinted.Visible = False
        '
        'txnosurat
        '
        Me.txnosurat.Location = New System.Drawing.Point(409, 26)
        Me.txnosurat.Name = "txnosurat"
        Me.txnosurat.Size = New System.Drawing.Size(30, 20)
        Me.txnosurat.TabIndex = 259
        Me.txnosurat.Visible = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.BackColor = System.Drawing.Color.Transparent
        Me.LinkLabel1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.Location = New System.Drawing.Point(323, 192)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(37, 15)
        Me.LinkLabel1.TabIndex = 258
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "disini"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 175)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 16)
        Me.Label3.TabIndex = 257
        Me.Label3.Text = "*Note : "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(61, 175)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(353, 32)
        Me.Label2.TabIndex = 256
        Me.Label2.Text = "Jika tindakan yang diinginkan tidak ada, cek apakah sudah " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "input master harga ru" & _
            "jukan tindakan tersebut"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(223, 108)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 16)
        Me.Label1.TabIndex = 255
        Me.Label1.Text = "Tgl Surat"
        '
        'txlabrujukanid
        '
        Me.txlabrujukanid.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txlabrujukanid.Location = New System.Drawing.Point(109, 45)
        Me.txlabrujukanid.Name = "txlabrujukanid"
        Me.txlabrujukanid.Size = New System.Drawing.Size(100, 21)
        Me.txlabrujukanid.TabIndex = 252
        Me.txlabrujukanid.Visible = False
        '
        'butlabrujukan
        '
        Me.butlabrujukan.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butlabrujukan.Location = New System.Drawing.Point(367, 43)
        Me.butlabrujukan.Name = "butlabrujukan"
        Me.butlabrujukan.Size = New System.Drawing.Size(31, 25)
        Me.butlabrujukan.TabIndex = 254
        Me.butlabrujukan.Text = "..."
        Me.butlabrujukan.UseVisualStyleBackColor = True
        '
        'txlabrujukanket
        '
        Me.txlabrujukanket.BackColor = System.Drawing.SystemColors.Window
        Me.txlabrujukanket.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txlabrujukanket.Location = New System.Drawing.Point(109, 45)
        Me.txlabrujukanket.Name = "txlabrujukanket"
        Me.txlabrujukanket.ReadOnly = True
        Me.txlabrujukanket.Size = New System.Drawing.Size(251, 21)
        Me.txlabrujukanket.TabIndex = 253
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(17, 48)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 16)
        Me.Label8.TabIndex = 251
        Me.Label8.Text = "Lab Rujukan"
        '
        'txtgllab
        '
        Me.txtgllab.Location = New System.Drawing.Point(409, 15)
        Me.txtgllab.Name = "txtgllab"
        Me.txtgllab.Size = New System.Drawing.Size(30, 20)
        Me.txtgllab.TabIndex = 250
        Me.txtgllab.Visible = False
        '
        'butsaved
        '
        Me.butsaved.Cursor = System.Windows.Forms.Cursors.Hand
        Me.butsaved.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butsaved.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_save
        Me.butsaved.Location = New System.Drawing.Point(298, 131)
        Me.butsaved.Name = "butsaved"
        Me.butsaved.Size = New System.Drawing.Size(100, 36)
        Me.butsaved.TabIndex = 246
        Me.butsaved.UseVisualStyleBackColor = True
        '
        'dtprocessend
        '
        Me.dtprocessend.CustomFormat = "dd-MMM-yyyy"
        Me.dtprocessend.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtprocessend.Location = New System.Drawing.Point(251, 15)
        Me.dtprocessend.Name = "dtprocessend"
        Me.dtprocessend.Size = New System.Drawing.Size(109, 20)
        Me.dtprocessend.TabIndex = 243
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(224, 17)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(26, 16)
        Me.Label5.TabIndex = 242
        Me.Label5.Text = "s/d"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 16)
        Me.Label9.TabIndex = 241
        Me.Label9.Text = "Tgl Transaksi"
        '
        'dtprocess
        '
        Me.dtprocess.CustomFormat = "dd-MMM-yyyy"
        Me.dtprocess.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtprocess.Location = New System.Drawing.Point(109, 15)
        Me.dtprocess.Name = "dtprocess"
        Me.dtprocess.Size = New System.Drawing.Size(109, 20)
        Me.dtprocess.TabIndex = 237
        '
        'buttambahpasien
        '
        Me.buttambahpasien.Cursor = System.Windows.Forms.Cursors.Hand
        Me.buttambahpasien.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.buttambahpasien.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_add
        Me.buttambahpasien.Location = New System.Drawing.Point(192, 131)
        Me.buttambahpasien.Name = "buttambahpasien"
        Me.buttambahpasien.Size = New System.Drawing.Size(100, 36)
        Me.buttambahpasien.TabIndex = 234
        Me.buttambahpasien.UseVisualStyleBackColor = True
        '
        'gridpasien
        '
        Me.gridpasien.Dock = System.Windows.Forms.DockStyle.Right
        Me.gridpasien.EmbeddedNavigator.Name = ""
        Me.gridpasien.Location = New System.Drawing.Point(449, 16)
        Me.gridpasien.MainView = Me.GridView2
        Me.gridpasien.Name = "gridpasien"
        Me.gridpasien.Size = New System.Drawing.Size(480, 208)
        Me.gridpasien.TabIndex = 191
        Me.gridpasien.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.gridpasien
        Me.GridView2.GroupPanelText = "Data Invoice"
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsView.ShowFilterPanel = False
        Me.GridView2.ViewCaption = "Tes"
        '
        'dtnow
        '
        Me.dtnow.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.dtnow.CustomFormat = "dd-MMM-yyyy"
        Me.dtnow.Enabled = False
        Me.dtnow.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtnow.Location = New System.Drawing.Point(289, 103)
        Me.dtnow.Name = "dtnow"
        Me.dtnow.Size = New System.Drawing.Size(109, 20)
        Me.dtnow.TabIndex = 62
        '
        'gridrujukan
        '
        Me.gridrujukan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridrujukan.EmbeddedNavigator.Name = ""
        Me.gridrujukan.Location = New System.Drawing.Point(0, 251)
        Me.gridrujukan.MainView = Me.GridView1
        Me.gridrujukan.Name = "gridrujukan"
        Me.gridrujukan.Size = New System.Drawing.Size(932, 450)
        Me.gridrujukan.TabIndex = 11
        Me.gridrujukan.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.gridrujukan
        Me.GridView1.GroupPanelText = "Data Tindakan"
        Me.GridView1.Name = "GridView1"
        '
        'CheckBoxUpload
        '
        Me.CheckBoxUpload.AutoSize = True
        Me.CheckBoxUpload.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxUpload.Enabled = False
        Me.CheckBoxUpload.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxUpload.Location = New System.Drawing.Point(15, 140)
        Me.CheckBoxUpload.Name = "CheckBoxUpload"
        Me.CheckBoxUpload.Size = New System.Drawing.Size(108, 20)
        Me.CheckBoxUpload.TabIndex = 269
        Me.CheckBoxUpload.Text = "Upload Online"
        Me.CheckBoxUpload.UseVisualStyleBackColor = False
        '
        'ProgressBarOnline
        '
        Me.ProgressBarOnline.Location = New System.Drawing.Point(15, 210)
        Me.ProgressBarOnline.Name = "ProgressBarOnline"
        Me.ProgressBarOnline.Size = New System.Drawing.Size(383, 10)
        Me.ProgressBarOnline.TabIndex = 270
        '
        'FormCreateRujukan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(932, 701)
        Me.Controls.Add(Me.gridrujukan)
        Me.Controls.Add(Me.groupcustomer)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormCreateRujukan"
        Me.Text = "Tambah Rujukan"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.groupcustomer.ResumeLayout(False)
        Me.groupcustomer.PerformLayout()
        CType(Me.gridpasien, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridrujukan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents NewToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents groupcustomer As System.Windows.Forms.GroupBox
    'Friend WithEvents butlabrujukanid As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents dtnow As System.Windows.Forms.DateTimePicker
    'Friend WithEvents butrujukanid As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents CetakSuratRujukanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents gridrujukan As DevExpress.XtraGrid.GridControl
    Private WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gridpasien As DevExpress.XtraGrid.GridControl
    Friend WithEvents buttambahpasien As System.Windows.Forms.Button
    Friend WithEvents dtprocessend As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtprocess As System.Windows.Forms.DateTimePicker
    Friend WithEvents butsaved As System.Windows.Forms.Button
    Friend WithEvents txtgllab As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txlabrujukanid As System.Windows.Forms.TextBox
    Friend WithEvents butlabrujukan As System.Windows.Forms.Button
    Friend WithEvents txlabrujukanket As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents txnosurat As System.Windows.Forms.TextBox
    Friend WithEvents txprinted As System.Windows.Forms.TextBox
    Friend WithEvents txtindakanid As System.Windows.Forms.TextBox
    Friend WithEvents buttindakan As System.Windows.Forms.Button
    Friend WithEvents txtindakanket As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txharga As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxUpload As System.Windows.Forms.CheckBox
    Friend WithEvents ProgressBarOnline As System.Windows.Forms.ProgressBar
End Class
