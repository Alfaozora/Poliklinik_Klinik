<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSendKapitasiBPJS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSendKapitasiBPJS))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.gridtindakan = New DevExpress.XtraGrid.GridControl
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.ButtonFindNoAntrian = New System.Windows.Forms.Button
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.rdcob = New System.Windows.Forms.RadioButton
        Me.rdnoncob = New System.Windows.Forms.RadioButton
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.rdbpjs = New System.Windows.Forms.RadioButton
        Me.rdinhealth = New System.Windows.Forms.RadioButton
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.rdklinik = New System.Windows.Forms.RadioButton
        Me.rdlab = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.butsavelab = New System.Windows.Forms.Button
        Me.txjumlahpasien = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmbtahun = New System.Windows.Forms.ComboBox
        Me.cmbbulan = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txlocid = New System.Windows.Forms.TextBox
        Me.txlocket = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        CType(Me.gridtindakan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 253)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(792, 10)
        Me.GroupBox1.TabIndex = 108
        Me.GroupBox1.TabStop = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(792, 24)
        Me.MenuStrip1.TabIndex = 107
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(88, 20)
        Me.NewToolStripMenuItem.Text = "Tambah Data"
        '
        'gridtindakan
        '
        Me.gridtindakan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridtindakan.EmbeddedNavigator.Name = ""
        Me.gridtindakan.Location = New System.Drawing.Point(0, 263)
        Me.gridtindakan.MainView = Me.GridView2
        Me.gridtindakan.Name = "gridtindakan"
        Me.gridtindakan.Size = New System.Drawing.Size(792, 154)
        Me.gridtindakan.TabIndex = 106
        Me.gridtindakan.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.gridtindakan
        Me.GridView2.GroupPanelText = "Daftar Kapitasi"
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsView.ShowAutoFilterRow = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ButtonFindNoAntrian)
        Me.GroupBox3.Controls.Add(Me.Panel3)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Panel1)
        Me.GroupBox3.Controls.Add(Me.Panel2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.butsavelab)
        Me.GroupBox3.Controls.Add(Me.txjumlahpasien)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.cmbtahun)
        Me.GroupBox3.Controls.Add(Me.cmbbulan)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.txlocid)
        Me.GroupBox3.Controls.Add(Me.txlocket)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Location = New System.Drawing.Point(0, 24)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(792, 229)
        Me.GroupBox3.TabIndex = 109
        Me.GroupBox3.TabStop = False
        '
        'ButtonFindNoAntrian
        '
        Me.ButtonFindNoAntrian.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindNoAntrian.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonFindNoAntrian.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonFindNoAntrian.FlatAppearance.BorderSize = 0
        Me.ButtonFindNoAntrian.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindNoAntrian.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonFindNoAntrian.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonFindNoAntrian.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonFindNoAntrian.ForeColor = System.Drawing.Color.White
        Me.ButtonFindNoAntrian.Location = New System.Drawing.Point(379, 15)
        Me.ButtonFindNoAntrian.Name = "ButtonFindNoAntrian"
        Me.ButtonFindNoAntrian.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonFindNoAntrian.Size = New System.Drawing.Size(128, 25)
        Me.ButtonFindNoAntrian.TabIndex = 512
        Me.ButtonFindNoAntrian.Text = "Kirim Ulang Jurnal"
        Me.ButtonFindNoAntrian.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonFindNoAntrian.UseVisualStyleBackColor = False
        Me.ButtonFindNoAntrian.Visible = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.Control
        Me.Panel3.Controls.Add(Me.rdcob)
        Me.Panel3.Controls.Add(Me.rdnoncob)
        Me.Panel3.Location = New System.Drawing.Point(118, 69)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(255, 25)
        Me.Panel3.TabIndex = 319
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
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(15, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 16)
        Me.Label6.TabIndex = 318
        Me.Label6.Text = "Jenis Inhealth"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(63, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 16)
        Me.Label2.TabIndex = 317
        Me.Label2.Text = "Lokasi"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.rdbpjs)
        Me.Panel1.Controls.Add(Me.rdinhealth)
        Me.Panel1.Location = New System.Drawing.Point(118, 41)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(255, 25)
        Me.Panel1.TabIndex = 316
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
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.Panel2.Controls.Add(Me.rdklinik)
        Me.Panel2.Controls.Add(Me.rdlab)
        Me.Panel2.Location = New System.Drawing.Point(118, 97)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(255, 25)
        Me.Panel2.TabIndex = 315
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 16)
        Me.Label1.TabIndex = 312
        Me.Label1.Text = "Jenis Kapitasi"
        '
        'butsavelab
        '
        Me.butsavelab.Cursor = System.Windows.Forms.Cursors.Hand
        Me.butsavelab.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butsavelab.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_save
        Me.butsavelab.Location = New System.Drawing.Point(118, 182)
        Me.butsavelab.Name = "butsavelab"
        Me.butsavelab.Size = New System.Drawing.Size(100, 36)
        Me.butsavelab.TabIndex = 311
        Me.butsavelab.UseVisualStyleBackColor = True
        '
        'txjumlahpasien
        '
        Me.txjumlahpasien.BackColor = System.Drawing.SystemColors.Window
        Me.txjumlahpasien.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txjumlahpasien.Location = New System.Drawing.Point(118, 155)
        Me.txjumlahpasien.Name = "txjumlahpasien"
        Me.txjumlahpasien.Size = New System.Drawing.Size(100, 21)
        Me.txjumlahpasien.TabIndex = 270
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 157)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 16)
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
        Me.cmbtahun.Location = New System.Drawing.Point(273, 126)
        Me.cmbtahun.Name = "cmbtahun"
        Me.cmbtahun.Size = New System.Drawing.Size(100, 23)
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
        Me.cmbbulan.Location = New System.Drawing.Point(118, 126)
        Me.cmbbulan.Name = "cmbbulan"
        Me.cmbbulan.Size = New System.Drawing.Size(100, 23)
        Me.cmbbulan.TabIndex = 267
        Me.cmbbulan.Tag = "3054"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(225, 128)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 16)
        Me.Label4.TabIndex = 266
        Me.Label4.Text = "Tahun"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(67, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 16)
        Me.Label3.TabIndex = 264
        Me.Label3.Text = "Bulan"
        '
        'txlocid
        '
        Me.txlocid.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txlocid.Location = New System.Drawing.Point(118, 15)
        Me.txlocid.Name = "txlocid"
        Me.txlocid.Size = New System.Drawing.Size(101, 21)
        Me.txlocid.TabIndex = 256
        Me.txlocid.Visible = False
        '
        'txlocket
        '
        Me.txlocket.BackColor = System.Drawing.SystemColors.Window
        Me.txlocket.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txlocket.Location = New System.Drawing.Point(118, 15)
        Me.txlocket.Name = "txlocket"
        Me.txlocket.ReadOnly = True
        Me.txlocket.Size = New System.Drawing.Size(255, 21)
        Me.txlocket.TabIndex = 257
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(68, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 16)
        Me.Label8.TabIndex = 255
        Me.Label8.Text = "Klinik"
        '
        'FormSendKapitasiBPJS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 417)
        Me.Controls.Add(Me.gridtindakan)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormSendKapitasiBPJS"
        Me.Text = "Form Kapitasi Klinik"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.gridtindakan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
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
    Friend WithEvents txlocid As System.Windows.Forms.TextBox
    Friend WithEvents txlocket As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbbulan As System.Windows.Forms.ComboBox
    Friend WithEvents cmbtahun As System.Windows.Forms.ComboBox
    Friend WithEvents txjumlahpasien As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents butsavelab As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rdinhealth As System.Windows.Forms.RadioButton
    Friend WithEvents rdbpjs As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents rdklinik As System.Windows.Forms.RadioButton
    Friend WithEvents rdlab As System.Windows.Forms.RadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents rdcob As System.Windows.Forms.RadioButton
    Friend WithEvents rdnoncob As System.Windows.Forms.RadioButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ButtonFindNoAntrian As System.Windows.Forms.Button
End Class
