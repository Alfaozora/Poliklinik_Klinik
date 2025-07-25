<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MasterTestLab
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
        Me.numjumlahobat = New System.Windows.Forms.NumericUpDown
        Me.Label1 = New System.Windows.Forms.Label
        Me.butclear = New System.Windows.Forms.Button
        Me.butsave = New System.Windows.Forms.Button
        Me.txobatid = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txhargakd = New System.Windows.Forms.NumericUpDown
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.txhargaprh = New System.Windows.Forms.NumericUpDown
        Me.Label15 = New System.Windows.Forms.Label
        Me.txhargaprt = New System.Windows.Forms.NumericUpDown
        Me.Label16 = New System.Windows.Forms.Label
        Me.butfindobat = New System.Windows.Forms.Button
        Me.butobat = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.gridtindakan = New DevExpress.XtraGrid.GridControl
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtindakanid = New System.Windows.Forms.TextBox
        Me.cmbtindakangroup = New System.Windows.Forms.ComboBox
        Me.txtindakanbiaya = New System.Windows.Forms.NumericUpDown
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtindakannama = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.txtabungref = New System.Windows.Forms.TextBox
        Me.txtabung = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txalat = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.cmbomr = New System.Windows.Forms.ComboBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.dttindakannow = New System.Windows.Forms.DateTimePicker
        Me.chtindakanclosed = New System.Windows.Forms.CheckBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.numjumlahobat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.txhargakd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txhargaprh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txhargaprt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.gridtindakan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.txtindakanbiaya, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.numjumlahobat)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.butclear)
        Me.GroupBox1.Controls.Add(Me.butsave)
        Me.GroupBox1.Controls.Add(Me.txobatid)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.butfindobat)
        Me.GroupBox1.Controls.Add(Me.butobat)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 387)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(712, 160)
        Me.GroupBox1.TabIndex = 108
        Me.GroupBox1.TabStop = False
        '
        'numjumlahobat
        '
        Me.numjumlahobat.Location = New System.Drawing.Point(111, 47)
        Me.numjumlahobat.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.numjumlahobat.Name = "numjumlahobat"
        Me.numjumlahobat.Size = New System.Drawing.Size(107, 20)
        Me.numjumlahobat.TabIndex = 13
        Me.numjumlahobat.ThousandsSeparator = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 146
        Me.Label1.Text = "Jumlah Potong"
        '
        'butclear
        '
        Me.butclear.Location = New System.Drawing.Point(534, 47)
        Me.butclear.Name = "butclear"
        Me.butclear.Size = New System.Drawing.Size(75, 23)
        Me.butclear.TabIndex = 15
        Me.butclear.Text = "Clear"
        Me.butclear.UseVisualStyleBackColor = True
        '
        'butsave
        '
        Me.butsave.Location = New System.Drawing.Point(453, 47)
        Me.butsave.Name = "butsave"
        Me.butsave.Size = New System.Drawing.Size(75, 23)
        Me.butsave.TabIndex = 14
        Me.butsave.Text = "Add"
        Me.butsave.UseVisualStyleBackColor = True
        '
        'txobatid
        '
        Me.txobatid.Enabled = False
        Me.txobatid.Location = New System.Drawing.Point(458, 20)
        Me.txobatid.Name = "txobatid"
        Me.txobatid.Size = New System.Drawing.Size(37, 20)
        Me.txobatid.TabIndex = 142
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txhargakd)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.txhargaprh)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.txhargaprt)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Location = New System.Drawing.Point(211, 65)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(241, 89)
        Me.GroupBox4.TabIndex = 142
        Me.GroupBox4.TabStop = False
        '
        'txhargakd
        '
        Me.txhargakd.Location = New System.Drawing.Point(133, 10)
        Me.txhargakd.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.txhargakd.Name = "txhargakd"
        Me.txhargakd.Size = New System.Drawing.Size(107, 20)
        Me.txhargakd.TabIndex = 9
        Me.txhargakd.ThousandsSeparator = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(105, 13)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(22, 13)
        Me.Label13.TabIndex = 123
        Me.Label13.Text = "KD"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(97, 67)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(30, 13)
        Me.Label14.TabIndex = 125
        Me.Label14.Text = "PRH"
        '
        'txhargaprh
        '
        Me.txhargaprh.Location = New System.Drawing.Point(133, 62)
        Me.txhargaprh.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.txhargaprh.Name = "txhargaprh"
        Me.txhargaprh.Size = New System.Drawing.Size(107, 20)
        Me.txhargaprh.TabIndex = 11
        Me.txhargaprh.ThousandsSeparator = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(98, 41)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(29, 13)
        Me.Label15.TabIndex = 127
        Me.Label15.Text = "PRT"
        '
        'txhargaprt
        '
        Me.txhargaprt.Location = New System.Drawing.Point(133, 36)
        Me.txhargaprt.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.txhargaprt.Name = "txhargaprt"
        Me.txhargaprt.Size = New System.Drawing.Size(107, 20)
        Me.txhargaprt.TabIndex = 10
        Me.txhargaprt.ThousandsSeparator = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(6, 31)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(92, 20)
        Me.Label16.TabIndex = 136
        Me.Label16.Text = "RUJUKAN"
        '
        'butfindobat
        '
        Me.butfindobat.Location = New System.Drawing.Point(425, 18)
        Me.butfindobat.Name = "butfindobat"
        Me.butfindobat.Size = New System.Drawing.Size(27, 23)
        Me.butfindobat.TabIndex = 140
        Me.butfindobat.Text = "..."
        Me.butfindobat.UseVisualStyleBackColor = True
        '
        'butobat
        '
        Me.butobat.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.butobat.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.butobat.FormattingEnabled = True
        Me.butobat.Location = New System.Drawing.Point(111, 19)
        Me.butobat.Name = "butobat"
        Me.butobat.Size = New System.Drawing.Size(308, 21)
        Me.butobat.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 13)
        Me.Label2.TabIndex = 61
        Me.Label2.Text = "Pemotongan Stock"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.SaveToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.CloseToolStripMenuItem, Me.PrintToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(712, 24)
        Me.MenuStrip1.TabIndex = 107
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.DeleteToolStripMenuItem.Text = "Delete"
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
        'gridtindakan
        '
        Me.gridtindakan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridtindakan.EmbeddedNavigator.Name = ""
        Me.gridtindakan.Location = New System.Drawing.Point(0, 547)
        Me.gridtindakan.MainView = Me.GridView2
        Me.gridtindakan.Name = "gridtindakan"
        Me.gridtindakan.Size = New System.Drawing.Size(712, 0)
        Me.gridtindakan.TabIndex = 106
        Me.gridtindakan.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.gridtindakan
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsView.ShowAutoFilterRow = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.txtindakanid)
        Me.GroupBox3.Controls.Add(Me.cmbtindakangroup)
        Me.GroupBox3.Controls.Add(Me.txtindakanbiaya)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.txtindakannama)
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.txtabungref)
        Me.GroupBox3.Controls.Add(Me.txtabung)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.txalat)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.cmbomr)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.dttindakannow)
        Me.GroupBox3.Controls.Add(Me.chtindakanclosed)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Location = New System.Drawing.Point(0, 24)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(712, 363)
        Me.GroupBox3.TabIndex = 109
        Me.GroupBox3.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(42, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 15)
        Me.Label3.TabIndex = 144
        Me.Label3.Text = "Group Jenis"
        '
        'txtindakanid
        '
        Me.txtindakanid.Enabled = False
        Me.txtindakanid.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtindakanid.Location = New System.Drawing.Point(122, 15)
        Me.txtindakanid.Name = "txtindakanid"
        Me.txtindakanid.Size = New System.Drawing.Size(37, 21)
        Me.txtindakanid.TabIndex = 143
        Me.txtindakanid.Visible = False
        '
        'cmbtindakangroup
        '
        Me.cmbtindakangroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbtindakangroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbtindakangroup.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbtindakangroup.FormattingEnabled = True
        Me.cmbtindakangroup.Location = New System.Drawing.Point(122, 41)
        Me.cmbtindakangroup.Name = "cmbtindakangroup"
        Me.cmbtindakangroup.Size = New System.Drawing.Size(251, 23)
        Me.cmbtindakangroup.TabIndex = 3
        '
        'txtindakanbiaya
        '
        Me.txtindakanbiaya.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtindakanbiaya.Location = New System.Drawing.Point(512, 40)
        Me.txtindakanbiaya.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.txtindakanbiaya.Name = "txtindakanbiaya"
        Me.txtindakanbiaya.Size = New System.Drawing.Size(107, 21)
        Me.txtindakanbiaya.TabIndex = 8
        Me.txtindakanbiaya.ThousandsSeparator = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(412, 41)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(94, 18)
        Me.Label12.TabIndex = 118
        Me.Label12.Text = "Harga CDC"
        '
        'txtindakannama
        '
        Me.txtindakannama.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtindakannama.Location = New System.Drawing.Point(122, 15)
        Me.txtindakannama.Name = "txtindakannama"
        Me.txtindakannama.Size = New System.Drawing.Size(218, 21)
        Me.txtindakannama.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(346, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(27, 23)
        Me.Button1.TabIndex = 140
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtabungref
        '
        Me.txtabungref.Location = New System.Drawing.Point(122, 154)
        Me.txtabungref.Name = "txtabungref"
        Me.txtabungref.Size = New System.Drawing.Size(37, 20)
        Me.txtabungref.TabIndex = 7
        Me.txtabungref.Visible = False
        '
        'txtabung
        '
        Me.txtabung.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtabung.Location = New System.Drawing.Point(122, 154)
        Me.txtabung.Name = "txtabung"
        Me.txtabung.Size = New System.Drawing.Size(139, 21)
        Me.txtabung.TabIndex = 6
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(7, 156)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(109, 15)
        Me.Label17.TabIndex = 134
        Me.Label17.Text = "Jenis Tabung / Ref"
        '
        'txalat
        '
        Me.txalat.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txalat.Location = New System.Drawing.Point(122, 127)
        Me.txalat.Name = "txalat"
        Me.txalat.Size = New System.Drawing.Size(139, 21)
        Me.txalat.TabIndex = 4
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(24, 129)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(92, 15)
        Me.Label18.TabIndex = 132
        Me.Label18.Text = "Koneksi Ke Alat"
        '
        'cmbomr
        '
        Me.cmbomr.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbomr.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbomr.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbomr.FormattingEnabled = True
        Me.cmbomr.Items.AddRange(New Object() {"O", "M", "R", "-"})
        Me.cmbomr.Location = New System.Drawing.Point(307, 127)
        Me.cmbomr.Name = "cmbomr"
        Me.cmbomr.Size = New System.Drawing.Size(66, 23)
        Me.cmbomr.TabIndex = 5
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(267, 129)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(34, 15)
        Me.Label19.TabIndex = 129
        Me.Label19.Text = "OMR"
        '
        'dttindakannow
        '
        Me.dttindakannow.CustomFormat = "dd-MMM-yyyy"
        Me.dttindakannow.Enabled = False
        Me.dttindakannow.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dttindakannow.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dttindakannow.Location = New System.Drawing.Point(507, 14)
        Me.dttindakannow.Name = "dttindakannow"
        Me.dttindakannow.Size = New System.Drawing.Size(107, 21)
        Me.dttindakannow.TabIndex = 121
        '
        'chtindakanclosed
        '
        Me.chtindakanclosed.AutoSize = True
        Me.chtindakanclosed.Enabled = False
        Me.chtindakanclosed.Location = New System.Drawing.Point(422, 17)
        Me.chtindakanclosed.Name = "chtindakanclosed"
        Me.chtindakanclosed.Size = New System.Drawing.Size(79, 17)
        Me.chtindakanclosed.TabIndex = 120
        Me.chtindakanclosed.Text = "Closed, Tgl"
        Me.chtindakanclosed.UseVisualStyleBackColor = True
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(42, 43)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(74, 15)
        Me.Label20.TabIndex = 71
        Me.Label20.Text = "Group Jenis"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(21, 17)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(95, 15)
        Me.Label21.TabIndex = 68
        Me.Label21.Text = "Nama Tindakan"
        '
        'MasterTestLab
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(712, 262)
        Me.Controls.Add(Me.gridtindakan)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "MasterTestLab"
        Me.Text = "Master Tindakan Laboratorium"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.numjumlahobat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.txhargakd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txhargaprh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txhargaprt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.gridtindakan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.txtindakanbiaya, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    'Friend WithEvents txtindakanbiaya As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents buttindakanid As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents txhargaprt As DevExpress.XtraEditors.TextEdit
    'Friend WithEvents txhargaprh As DevExpress.XtraEditors.TextEdit
    'Friend WithEvents txhargakd As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents gridtindakan As DevExpress.XtraGrid.GridControl
    Private WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents butfindobat As System.Windows.Forms.Button
    Friend WithEvents butobat As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbtindakangroup As System.Windows.Forms.ComboBox
    Friend WithEvents txtindakanbiaya As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtindakannama As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents txhargakd As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txhargaprh As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txhargaprt As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtabungref As System.Windows.Forms.TextBox
    Friend WithEvents txtabung As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txalat As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cmbomr As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents dttindakannow As System.Windows.Forms.DateTimePicker
    Friend WithEvents chtindakanclosed As System.Windows.Forms.CheckBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txobatid As System.Windows.Forms.TextBox
    Friend WithEvents butclear As System.Windows.Forms.Button
    Friend WithEvents butsave As System.Windows.Forms.Button
    Friend WithEvents numjumlahobat As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtindakanid As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
