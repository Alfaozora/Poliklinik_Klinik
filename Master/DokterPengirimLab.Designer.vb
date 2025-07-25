<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DokterPengirimLab
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DokterPengirimLab))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.butsaved = New System.Windows.Forms.Button
        Me.cmbdokternama = New System.Windows.Forms.ComboBox
        Me.txdokterhp = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txid = New System.Windows.Forms.TextBox
        Me.lblsatuanunit1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.butfinddokter = New System.Windows.Forms.Button
        Me.dtdoktertgllhr = New System.Windows.Forms.DateTimePicker
        Me.Label22 = New System.Windows.Forms.Label
        Me.txdoktertempatlahir = New System.Windows.Forms.TextBox
        Me.txdokterket = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txdoktertlp = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.dtchange = New System.Windows.Forms.DateTimePicker
        Me.Label12 = New System.Windows.Forms.Label
        Me.txchange = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip
        Me.TambahAlamatToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.grouppraktek = New System.Windows.Forms.GroupBox
        Me.butsave = New System.Windows.Forms.Button
        Me.butclearalamat = New System.Windows.Forms.Button
        Me.txpraktektempat = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txpraktektlp = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txpraktekalamat = New System.Windows.Forms.TextBox
        Me.txpraktekid = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txpraktekket = New System.Windows.Forms.TextBox
        Me.txpraktekkota = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Label10 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.MenuStrip2.SuspendLayout()
        Me.grouppraktek.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupBox1.Location = New System.Drawing.Point(0, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(442, 297)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.butsaved)
        Me.GroupBox4.Controls.Add(Me.cmbdokternama)
        Me.GroupBox4.Controls.Add(Me.txdokterhp)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.Label9)
        Me.GroupBox4.Controls.Add(Me.txid)
        Me.GroupBox4.Controls.Add(Me.lblsatuanunit1)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.butfinddokter)
        Me.GroupBox4.Controls.Add(Me.dtdoktertgllhr)
        Me.GroupBox4.Controls.Add(Me.Label22)
        Me.GroupBox4.Controls.Add(Me.txdoktertempatlahir)
        Me.GroupBox4.Controls.Add(Me.txdokterket)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.txdoktertlp)
        Me.GroupBox4.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(439, 245)
        Me.GroupBox4.TabIndex = 111
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Data Dokter"
        '
        'butsaved
        '
        Me.butsaved.Cursor = System.Windows.Forms.Cursors.Hand
        Me.butsaved.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butsaved.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_save
        Me.butsaved.Location = New System.Drawing.Point(320, 155)
        Me.butsaved.Name = "butsaved"
        Me.butsaved.Size = New System.Drawing.Size(100, 36)
        Me.butsaved.TabIndex = 236
        Me.butsaved.UseVisualStyleBackColor = True
        '
        'cmbdokternama
        '
        Me.cmbdokternama.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbdokternama.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbdokternama.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbdokternama.FormattingEnabled = True
        Me.cmbdokternama.Location = New System.Drawing.Point(93, 20)
        Me.cmbdokternama.Name = "cmbdokternama"
        Me.cmbdokternama.Size = New System.Drawing.Size(238, 26)
        Me.cmbdokternama.TabIndex = 84
        '
        'txdokterhp
        '
        Me.txdokterhp.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txdokterhp.Location = New System.Drawing.Point(297, 75)
        Me.txdokterhp.MaxLength = 100
        Me.txdokterhp.Name = "txdokterhp"
        Me.txdokterhp.Size = New System.Drawing.Size(123, 21)
        Me.txdokterhp.TabIndex = 109
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 18)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Nama Dokter"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(245, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 18)
        Me.Label2.TabIndex = 108
        Me.Label2.Text = "No. Hp"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(36, 78)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 18)
        Me.Label9.TabIndex = 38
        Me.Label9.Text = "No. Tlp"
        '
        'txid
        '
        Me.txid.Enabled = False
        Me.txid.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txid.Location = New System.Drawing.Point(376, 20)
        Me.txid.MaxLength = 100
        Me.txid.Name = "txid"
        Me.txid.Size = New System.Drawing.Size(44, 21)
        Me.txid.TabIndex = 107
        '
        'lblsatuanunit1
        '
        Me.lblsatuanunit1.AutoSize = True
        Me.lblsatuanunit1.Location = New System.Drawing.Point(292, 136)
        Me.lblsatuanunit1.Name = "lblsatuanunit1"
        Me.lblsatuanunit1.Size = New System.Drawing.Size(0, 13)
        Me.lblsatuanunit1.TabIndex = 49
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(245, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 18)
        Me.Label4.TabIndex = 98
        Me.Label4.Text = "Tgl Lhr"
        '
        'butfinddokter
        '
        Me.butfinddokter.Font = New System.Drawing.Font("Trebuchet MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butfinddokter.Location = New System.Drawing.Point(337, 20)
        Me.butfinddokter.Name = "butfinddokter"
        Me.butfinddokter.Size = New System.Drawing.Size(31, 23)
        Me.butfinddokter.TabIndex = 58
        Me.butfinddokter.Text = "..."
        Me.butfinddokter.UseVisualStyleBackColor = True
        '
        'dtdoktertgllhr
        '
        Me.dtdoktertgllhr.CustomFormat = "dd-MMM-yyyy"
        Me.dtdoktertgllhr.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtdoktertgllhr.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtdoktertgllhr.Location = New System.Drawing.Point(297, 50)
        Me.dtdoktertgllhr.Name = "dtdoktertgllhr"
        Me.dtdoktertgllhr.Size = New System.Drawing.Size(123, 21)
        Me.dtdoktertgllhr.TabIndex = 97
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(13, 103)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(71, 18)
        Me.Label22.TabIndex = 86
        Me.Label22.Text = "Keterangan"
        '
        'txdoktertempatlahir
        '
        Me.txdoktertempatlahir.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txdoktertempatlahir.Location = New System.Drawing.Point(93, 50)
        Me.txdoktertempatlahir.MaxLength = 100
        Me.txdoktertempatlahir.Name = "txdoktertempatlahir"
        Me.txdoktertempatlahir.Size = New System.Drawing.Size(146, 21)
        Me.txdoktertempatlahir.TabIndex = 96
        '
        'txdokterket
        '
        Me.txdokterket.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txdokterket.Location = New System.Drawing.Point(93, 100)
        Me.txdokterket.MaxLength = 100
        Me.txdokterket.Multiline = True
        Me.txdokterket.Name = "txdokterket"
        Me.txdokterket.Size = New System.Drawing.Size(327, 49)
        Me.txdokterket.TabIndex = 87
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(79, 18)
        Me.Label3.TabIndex = 95
        Me.Label3.Text = "Tempat Lahir"
        '
        'txdoktertlp
        '
        Me.txdoktertlp.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txdoktertlp.Location = New System.Drawing.Point(93, 75)
        Me.txdoktertlp.MaxLength = 100
        Me.txdoktertlp.Name = "txdoktertlp"
        Me.txdoktertlp.Size = New System.Drawing.Size(146, 21)
        Me.txdoktertlp.TabIndex = 94
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.SystemColors.MenuBar
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.dtchange)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.txchange)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox3.Enabled = False
        Me.GroupBox3.Location = New System.Drawing.Point(3, 247)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(436, 47)
        Me.GroupBox3.TabIndex = 53
        Me.GroupBox3.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Enabled = False
        Me.Label11.Location = New System.Drawing.Point(9, 23)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(70, 13)
        Me.Label11.TabIndex = 48
        Me.Label11.Text = "Change Date"
        '
        'dtchange
        '
        Me.dtchange.CustomFormat = "dd-MMM-yyyy"
        Me.dtchange.Enabled = False
        Me.dtchange.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtchange.Location = New System.Drawing.Point(85, 19)
        Me.dtchange.Name = "dtchange"
        Me.dtchange.Size = New System.Drawing.Size(100, 20)
        Me.dtchange.TabIndex = 47
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Enabled = False
        Me.Label12.Location = New System.Drawing.Point(191, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 13)
        Me.Label12.TabIndex = 45
        Me.Label12.Text = "Change By"
        '
        'txchange
        '
        Me.txchange.Enabled = False
        Me.txchange.Location = New System.Drawing.Point(256, 19)
        Me.txchange.MaxLength = 3
        Me.txchange.Name = "txchange"
        Me.txchange.Size = New System.Drawing.Size(93, 20)
        Me.txchange.TabIndex = 46
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.MenuStrip2)
        Me.GroupBox2.Controls.Add(Me.grouppraktek)
        Me.GroupBox2.Location = New System.Drawing.Point(448, 27)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(380, 351)
        Me.GroupBox2.TabIndex = 110
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detail Praktek"
        '
        'MenuStrip2
        '
        Me.MenuStrip2.AllowMerge = False
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TambahAlamatToolStripMenuItem})
        Me.MenuStrip2.Location = New System.Drawing.Point(3, 16)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(374, 24)
        Me.MenuStrip2.TabIndex = 115
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'TambahAlamatToolStripMenuItem
        '
        Me.TambahAlamatToolStripMenuItem.Name = "TambahAlamatToolStripMenuItem"
        Me.TambahAlamatToolStripMenuItem.Size = New System.Drawing.Size(102, 20)
        Me.TambahAlamatToolStripMenuItem.Text = "Tambah Alamat"
        '
        'grouppraktek
        '
        Me.grouppraktek.Controls.Add(Me.butsave)
        Me.grouppraktek.Controls.Add(Me.butclearalamat)
        Me.grouppraktek.Controls.Add(Me.txpraktektempat)
        Me.grouppraktek.Controls.Add(Me.Label7)
        Me.grouppraktek.Controls.Add(Me.txpraktektlp)
        Me.grouppraktek.Controls.Add(Me.Label8)
        Me.grouppraktek.Controls.Add(Me.txpraktekalamat)
        Me.grouppraktek.Controls.Add(Me.txpraktekid)
        Me.grouppraktek.Controls.Add(Me.Label6)
        Me.grouppraktek.Controls.Add(Me.txpraktekket)
        Me.grouppraktek.Controls.Add(Me.txpraktekkota)
        Me.grouppraktek.Controls.Add(Me.Label5)
        Me.grouppraktek.Controls.Add(Me.Label26)
        Me.grouppraktek.Location = New System.Drawing.Point(3, 35)
        Me.grouppraktek.Name = "grouppraktek"
        Me.grouppraktek.Size = New System.Drawing.Size(374, 262)
        Me.grouppraktek.TabIndex = 116
        Me.grouppraktek.TabStop = False
        '
        'butsave
        '
        Me.butsave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.butsave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butsave.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_save
        Me.butsave.Location = New System.Drawing.Point(256, 216)
        Me.butsave.Name = "butsave"
        Me.butsave.Size = New System.Drawing.Size(100, 36)
        Me.butsave.TabIndex = 1
        Me.butsave.UseVisualStyleBackColor = True
        '
        'butclearalamat
        '
        Me.butclearalamat.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butclearalamat.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butclearalamat.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_kosong
        Me.butclearalamat.Location = New System.Drawing.Point(150, 216)
        Me.butclearalamat.Name = "butclearalamat"
        Me.butclearalamat.Size = New System.Drawing.Size(100, 36)
        Me.butclearalamat.TabIndex = 188
        Me.butclearalamat.Text = "CLEAR"
        Me.butclearalamat.UseVisualStyleBackColor = True
        '
        'txpraktektempat
        '
        Me.txpraktektempat.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txpraktektempat.Location = New System.Drawing.Point(105, 15)
        Me.txpraktektempat.MaxLength = 100
        Me.txpraktektempat.Name = "txpraktektempat"
        Me.txpraktektempat.Size = New System.Drawing.Size(201, 21)
        Me.txpraktektempat.TabIndex = 93
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(23, 128)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 18)
        Me.Label7.TabIndex = 103
        Me.Label7.Text = "Kota Praktek"
        '
        'txpraktektlp
        '
        Me.txpraktektlp.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txpraktektlp.Location = New System.Drawing.Point(244, 125)
        Me.txpraktektlp.MaxLength = 100
        Me.txpraktektlp.Name = "txpraktektlp"
        Me.txpraktektlp.Size = New System.Drawing.Size(112, 21)
        Me.txpraktektlp.TabIndex = 104
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(28, 153)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 18)
        Me.Label8.TabIndex = 112
        Me.Label8.Text = "Keterangan"
        '
        'txpraktekalamat
        '
        Me.txpraktekalamat.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txpraktekalamat.Location = New System.Drawing.Point(105, 40)
        Me.txpraktekalamat.MaxLength = 100
        Me.txpraktekalamat.Multiline = True
        Me.txpraktekalamat.Name = "txpraktekalamat"
        Me.txpraktekalamat.Size = New System.Drawing.Size(251, 81)
        Me.txpraktekalamat.TabIndex = 102
        '
        'txpraktekid
        '
        Me.txpraktekid.Enabled = False
        Me.txpraktekid.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txpraktekid.Location = New System.Drawing.Point(312, 15)
        Me.txpraktekid.MaxLength = 100
        Me.txpraktekid.Name = "txpraktekid"
        Me.txpraktekid.Size = New System.Drawing.Size(44, 21)
        Me.txpraktekid.TabIndex = 108
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(220, 128)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(22, 13)
        Me.Label6.TabIndex = 101
        Me.Label6.Text = "Tlp"
        '
        'txpraktekket
        '
        Me.txpraktekket.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txpraktekket.Location = New System.Drawing.Point(105, 150)
        Me.txpraktekket.MaxLength = 100
        Me.txpraktekket.Multiline = True
        Me.txpraktekket.Name = "txpraktekket"
        Me.txpraktekket.Size = New System.Drawing.Size(251, 60)
        Me.txpraktekket.TabIndex = 113
        '
        'txpraktekkota
        '
        Me.txpraktekkota.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txpraktekkota.Location = New System.Drawing.Point(105, 125)
        Me.txpraktekkota.MaxLength = 100
        Me.txpraktekkota.Name = "txpraktekkota"
        Me.txpraktekkota.Size = New System.Drawing.Size(112, 21)
        Me.txpraktekkota.TabIndex = 100
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 18)
        Me.Label5.TabIndex = 99
        Me.Label5.Text = "Alamat Praktek"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Trebuchet MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(6, 18)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(93, 18)
        Me.Label26.TabIndex = 92
        Me.Label26.Text = "Tempat Praktek"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.DeleteToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(829, 24)
        Me.MenuStrip1.TabIndex = 108
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(65, 20)
        Me.NewToolStripMenuItem.Text = "Set Clear"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Enabled = False
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label10.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Firebrick
        Me.Label10.Location = New System.Drawing.Point(5, 155)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(309, 64)
        Me.Label10.TabIndex = 239
        Me.Label10.Text = resources.GetString("Label10.Text")
        '
        'DokterPengirimLab
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(829, 321)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(845, 360)
        Me.MinimumSize = New System.Drawing.Size(845, 360)
        Me.Name = "DokterPengirimLab"
        Me.Text = "Tambah Dokter Pengirim"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.grouppraktek.ResumeLayout(False)
        Me.grouppraktek.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txpraktektlp As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txpraktekalamat As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txpraktekkota As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtdoktertgllhr As System.Windows.Forms.DateTimePicker
    Friend WithEvents txdoktertempatlahir As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txdoktertlp As System.Windows.Forms.TextBox
    Friend WithEvents txpraktektempat As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txdokterket As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents butfinddokter As System.Windows.Forms.Button
    Friend WithEvents cmbdokternama As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtchange As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txchange As System.Windows.Forms.TextBox
    Friend WithEvents lblsatuanunit1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txid As System.Windows.Forms.TextBox
    Friend WithEvents txdokterhp As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txpraktekket As System.Windows.Forms.TextBox
    Friend WithEvents txpraktekid As System.Windows.Forms.TextBox
    Friend WithEvents butsave As System.Windows.Forms.Button
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents TambahAlamatToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents grouppraktek As System.Windows.Forms.GroupBox
    Friend WithEvents butsaved As System.Windows.Forms.Button
    Friend WithEvents butclearalamat As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
End Class
