<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormDetailTagihan
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
        Me.butclear = New System.Windows.Forms.Button
        Me.cmbstatus = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.lbltotalomset = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.butreportexcel = New System.Windows.Forms.Button
        Me.lbluangcentang = New System.Windows.Forms.Label
        Me.lbljumlahomset = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.butkalkulasi = New System.Windows.Forms.Button
        Me.cmbjenis = New System.Windows.Forms.ComboBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txkodecabang = New System.Windows.Forms.TextBox
        Me.butfindcabang = New System.Windows.Forms.Button
        Me.txcabangket = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.butfindcompany = New System.Windows.Forms.Button
        Me.txcompanycode = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.butsaved = New System.Windows.Forms.Button
        Me.butdisplay = New System.Windows.Forms.Button
        Me.dtprocess = New System.Windows.Forms.DateTimePicker
        Me.gridpoli = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.gridpoli, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.butclear)
        Me.GroupBox1.Controls.Add(Me.cmbstatus)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lbltotalomset)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.butreportexcel)
        Me.GroupBox1.Controls.Add(Me.lbluangcentang)
        Me.GroupBox1.Controls.Add(Me.lbljumlahomset)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.CheckBox1)
        Me.GroupBox1.Controls.Add(Me.butkalkulasi)
        Me.GroupBox1.Controls.Add(Me.cmbjenis)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.txkodecabang)
        Me.GroupBox1.Controls.Add(Me.butfindcabang)
        Me.GroupBox1.Controls.Add(Me.txcabangket)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.butfindcompany)
        Me.GroupBox1.Controls.Add(Me.txcompanycode)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.butsaved)
        Me.GroupBox1.Controls.Add(Me.butdisplay)
        Me.GroupBox1.Controls.Add(Me.dtprocess)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1013, 118)
        Me.GroupBox1.TabIndex = 115
        Me.GroupBox1.TabStop = False
        '
        'butclear
        '
        Me.butclear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butclear.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butclear.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_kosong
        Me.butclear.Location = New System.Drawing.Point(710, 76)
        Me.butclear.Name = "butclear"
        Me.butclear.Size = New System.Drawing.Size(100, 36)
        Me.butclear.TabIndex = 188
        Me.butclear.Text = "CLEAR"
        Me.butclear.UseVisualStyleBackColor = True
        '
        'cmbstatus
        '
        Me.cmbstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbstatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbstatus.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbstatus.FormattingEnabled = True
        Me.cmbstatus.Items.AddRange(New Object() {"SEMUA", "LOCKED", "UNLOCKED"})
        Me.cmbstatus.Location = New System.Drawing.Point(500, 18)
        Me.cmbstatus.Name = "cmbstatus"
        Me.cmbstatus.Size = New System.Drawing.Size(148, 23)
        Me.cmbstatus.TabIndex = 226
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(380, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 16)
        Me.Label3.TabIndex = 225
        Me.Label3.Text = "Status Transaksi"
        '
        'lbltotalomset
        '
        Me.lbltotalomset.AutoSize = True
        Me.lbltotalomset.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotalomset.Location = New System.Drawing.Point(736, 21)
        Me.lbltotalomset.Name = "lbltotalomset"
        Me.lbltotalomset.Size = New System.Drawing.Size(35, 16)
        Me.lbltotalomset.TabIndex = 224
        Me.lbltotalomset.Text = "Rp 0"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Image = Global.PoliKlinik_Net2.My.Resources.Resources.PDF
        Me.Button1.Location = New System.Drawing.Point(226, 15)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 26)
        Me.Button1.TabIndex = 223
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'butreportexcel
        '
        Me.butreportexcel.Cursor = System.Windows.Forms.Cursors.Hand
        Me.butreportexcel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butreportexcel.Image = Global.PoliKlinik_Net2.My.Resources.Resources.Excell
        Me.butreportexcel.Location = New System.Drawing.Point(918, 45)
        Me.butreportexcel.Name = "butreportexcel"
        Me.butreportexcel.Size = New System.Drawing.Size(100, 26)
        Me.butreportexcel.TabIndex = 222
        Me.butreportexcel.UseVisualStyleBackColor = True
        '
        'lbluangcentang
        '
        Me.lbluangcentang.AutoSize = True
        Me.lbluangcentang.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbluangcentang.Location = New System.Drawing.Point(575, 85)
        Me.lbluangcentang.Name = "lbluangcentang"
        Me.lbluangcentang.Size = New System.Drawing.Size(33, 15)
        Me.lbluangcentang.TabIndex = 221
        Me.lbluangcentang.Text = "Rp 0"
        '
        'lbljumlahomset
        '
        Me.lbljumlahomset.AutoSize = True
        Me.lbljumlahomset.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbljumlahomset.Location = New System.Drawing.Point(770, 50)
        Me.lbljumlahomset.Name = "lbljumlahomset"
        Me.lbljumlahomset.Size = New System.Drawing.Size(15, 16)
        Me.lbljumlahomset.TabIndex = 220
        Me.lbljumlahomset.Text = "0"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(654, 51)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(121, 16)
        Me.Label19.TabIndex = 219
        Me.Label19.Text = "Jumlah Transaksi : "
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(654, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 16)
        Me.Label2.TabIndex = 217
        Me.Label2.Text = "Total Omset :"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.Location = New System.Drawing.Point(383, 85)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(80, 18)
        Me.CheckBox1.TabIndex = 216
        Me.CheckBox1.Text = "Pilih Semua"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'butkalkulasi
        '
        Me.butkalkulasi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.butkalkulasi.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butkalkulasi.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_kalkulasi
        Me.butkalkulasi.Location = New System.Drawing.Point(469, 76)
        Me.butkalkulasi.Name = "butkalkulasi"
        Me.butkalkulasi.Size = New System.Drawing.Size(100, 36)
        Me.butkalkulasi.TabIndex = 215
        Me.butkalkulasi.UseVisualStyleBackColor = True
        '
        'cmbjenis
        '
        Me.cmbjenis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbjenis.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbjenis.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbjenis.FormattingEnabled = True
        Me.cmbjenis.Items.AddRange(New Object() {"SEMUA", "DLL", "GIGI", "LAB", "POLI"})
        Me.cmbjenis.Location = New System.Drawing.Point(500, 48)
        Me.cmbjenis.Name = "cmbjenis"
        Me.cmbjenis.Size = New System.Drawing.Size(148, 23)
        Me.cmbjenis.TabIndex = 206
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(380, 50)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(98, 16)
        Me.Label18.TabIndex = 205
        Me.Label18.Text = "Jenis Transaksi"
        '
        'txkodecabang
        '
        Me.txkodecabang.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txkodecabang.Location = New System.Drawing.Point(109, 82)
        Me.txkodecabang.Name = "txkodecabang"
        Me.txkodecabang.ReadOnly = True
        Me.txkodecabang.Size = New System.Drawing.Size(84, 21)
        Me.txkodecabang.TabIndex = 197
        Me.txkodecabang.Visible = False
        '
        'butfindcabang
        '
        Me.butfindcabang.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butfindcabang.Location = New System.Drawing.Point(332, 79)
        Me.butfindcabang.Name = "butfindcabang"
        Me.butfindcabang.Size = New System.Drawing.Size(31, 25)
        Me.butfindcabang.TabIndex = 201
        Me.butfindcabang.Text = "..."
        Me.butfindcabang.UseVisualStyleBackColor = True
        '
        'txcabangket
        '
        Me.txcabangket.BackColor = System.Drawing.SystemColors.Window
        Me.txcabangket.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txcabangket.Location = New System.Drawing.Point(109, 82)
        Me.txcabangket.Name = "txcabangket"
        Me.txcabangket.ReadOnly = True
        Me.txcabangket.Size = New System.Drawing.Size(217, 21)
        Me.txcabangket.TabIndex = 200
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 84)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 16)
        Me.Label1.TabIndex = 199
        Me.Label1.Text = "Cabang"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 16)
        Me.Label9.TabIndex = 198
        Me.Label9.Text = "Tgl Transaksi"
        '
        'butfindcompany
        '
        Me.butfindcompany.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butfindcompany.Location = New System.Drawing.Point(332, 45)
        Me.butfindcompany.Name = "butfindcompany"
        Me.butfindcompany.Size = New System.Drawing.Size(31, 25)
        Me.butfindcompany.TabIndex = 197
        Me.butfindcompany.Text = "..."
        Me.butfindcompany.UseVisualStyleBackColor = True
        '
        'txcompanycode
        '
        Me.txcompanycode.BackColor = System.Drawing.SystemColors.Window
        Me.txcompanycode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txcompanycode.Location = New System.Drawing.Point(109, 48)
        Me.txcompanycode.Name = "txcompanycode"
        Me.txcompanycode.ReadOnly = True
        Me.txcompanycode.Size = New System.Drawing.Size(217, 21)
        Me.txcompanycode.TabIndex = 196
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(12, 50)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(63, 16)
        Me.Label16.TabIndex = 195
        Me.Label16.Text = "Company"
        '
        'butsaved
        '
        Me.butsaved.Cursor = System.Windows.Forms.Cursors.Hand
        Me.butsaved.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butsaved.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_save
        Me.butsaved.Location = New System.Drawing.Point(918, 76)
        Me.butsaved.Name = "butsaved"
        Me.butsaved.Size = New System.Drawing.Size(100, 36)
        Me.butsaved.TabIndex = 114
        Me.butsaved.UseVisualStyleBackColor = True
        '
        'butdisplay
        '
        Me.butdisplay.Cursor = System.Windows.Forms.Cursors.Hand
        Me.butdisplay.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butdisplay.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_cari
        Me.butdisplay.Location = New System.Drawing.Point(814, 76)
        Me.butdisplay.Name = "butdisplay"
        Me.butdisplay.Size = New System.Drawing.Size(100, 36)
        Me.butdisplay.TabIndex = 112
        Me.butdisplay.UseVisualStyleBackColor = True
        '
        'dtprocess
        '
        Me.dtprocess.CustomFormat = "dd-MMM-yyyy"
        Me.dtprocess.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtprocess.Location = New System.Drawing.Point(109, 18)
        Me.dtprocess.Name = "dtprocess"
        Me.dtprocess.Size = New System.Drawing.Size(109, 20)
        Me.dtprocess.TabIndex = 110
        '
        'gridpoli
        '
        Me.gridpoli.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridpoli.EmbeddedNavigator.Name = ""
        Me.gridpoli.Location = New System.Drawing.Point(3, 16)
        Me.gridpoli.MainView = Me.GridView1
        Me.gridpoli.Name = "gridpoli"
        Me.gridpoli.Size = New System.Drawing.Size(1007, 345)
        Me.gridpoli.TabIndex = 1
        Me.gridpoli.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.gridpoli
        Me.GridView1.Name = "GridView1"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.gridpoli)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 118)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1013, 364)
        Me.GroupBox2.TabIndex = 116
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detail"
        '
        'FormDetailTagihan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1013, 482)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FormDetailTagihan"
        Me.Text = "FormDetailTagihan"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.gridpoli, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents butsaved As System.Windows.Forms.Button
    Friend WithEvents butdisplay As System.Windows.Forms.Button
    Friend WithEvents dtprocess As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents gridpoli As DevExpress.XtraGrid.GridControl
    Private WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents butfindcompany As System.Windows.Forms.Button
    Friend WithEvents txcompanycode As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents butfindcabang As System.Windows.Forms.Button
    Friend WithEvents txcabangket As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txkodecabang As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents butkalkulasi As System.Windows.Forms.Button
    Friend WithEvents lbljumlahomset As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbluangcentang As System.Windows.Forms.Label
    Friend WithEvents cmbjenis As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents butreportexcel As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lbltotalomset As System.Windows.Forms.Label
    Friend WithEvents cmbstatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents butclear As System.Windows.Forms.Button
End Class
