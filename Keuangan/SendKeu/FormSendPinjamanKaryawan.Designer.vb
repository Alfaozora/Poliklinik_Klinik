<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSendPinjamanKaryawan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSendPinjamanKaryawan))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.NewToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.groupcustomer = New System.Windows.Forms.GroupBox
        Me.cmbjenistemuan = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbjenispinjaman = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txcabangid = New System.Windows.Forms.TextBox
        Me.butselectcabang = New System.Windows.Forms.Button
        Me.txcabangket = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.butsaved = New System.Windows.Forms.Button
        Me.dtprocessend = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.dtprocess = New System.Windows.Forms.DateTimePicker
        Me.butcarikaryawan = New System.Windows.Forms.Button
        Me.gridlab = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.MenuStrip1.SuspendLayout()
        Me.groupcustomer.SuspendLayout()
        CType(Me.gridlab, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.groupcustomer.Controls.Add(Me.cmbjenistemuan)
        Me.groupcustomer.Controls.Add(Me.Label1)
        Me.groupcustomer.Controls.Add(Me.cmbjenispinjaman)
        Me.groupcustomer.Controls.Add(Me.Label4)
        Me.groupcustomer.Controls.Add(Me.txcabangid)
        Me.groupcustomer.Controls.Add(Me.butselectcabang)
        Me.groupcustomer.Controls.Add(Me.txcabangket)
        Me.groupcustomer.Controls.Add(Me.Label8)
        Me.groupcustomer.Controls.Add(Me.butsaved)
        Me.groupcustomer.Controls.Add(Me.dtprocessend)
        Me.groupcustomer.Controls.Add(Me.Label5)
        Me.groupcustomer.Controls.Add(Me.Label9)
        Me.groupcustomer.Controls.Add(Me.dtprocess)
        Me.groupcustomer.Controls.Add(Me.butcarikaryawan)
        Me.groupcustomer.Dock = System.Windows.Forms.DockStyle.Top
        Me.groupcustomer.Location = New System.Drawing.Point(0, 24)
        Me.groupcustomer.Name = "groupcustomer"
        Me.groupcustomer.Size = New System.Drawing.Size(1200, 110)
        Me.groupcustomer.TabIndex = 10
        Me.groupcustomer.TabStop = False
        Me.groupcustomer.Text = "Tambah Data"
        '
        'cmbjenistemuan
        '
        Me.cmbjenistemuan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbjenistemuan.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbjenistemuan.FormattingEnabled = True
        Me.cmbjenistemuan.Items.AddRange(New Object() {"PERSEDIAAN OBAT", "REAGEN", "PERSEDIAAN ALAT KESEHATAN"})
        Me.cmbjenistemuan.Location = New System.Drawing.Point(487, 66)
        Me.cmbjenistemuan.Name = "cmbjenistemuan"
        Me.cmbjenistemuan.Size = New System.Drawing.Size(250, 24)
        Me.cmbjenistemuan.TabIndex = 258
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(388, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 16)
        Me.Label1.TabIndex = 257
        Me.Label1.Text = "Jenis Temuan"
        '
        'cmbjenispinjaman
        '
        Me.cmbjenispinjaman.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbjenispinjaman.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbjenispinjaman.FormattingEnabled = True
        Me.cmbjenispinjaman.Items.AddRange(New Object() {"PINJAMAN KARYAWAN", "TEMUAN AUDIT", "POTONGAN FEE VAKSINATOR"})
        Me.cmbjenispinjaman.Location = New System.Drawing.Point(120, 66)
        Me.cmbjenispinjaman.Name = "cmbjenispinjaman"
        Me.cmbjenispinjaman.Size = New System.Drawing.Size(250, 24)
        Me.cmbjenispinjaman.TabIndex = 256
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 69)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 16)
        Me.Label4.TabIndex = 255
        Me.Label4.Text = "Jenis Pinjaman"
        '
        'txcabangid
        '
        Me.txcabangid.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txcabangid.Location = New System.Drawing.Point(487, 27)
        Me.txcabangid.Name = "txcabangid"
        Me.txcabangid.Size = New System.Drawing.Size(100, 21)
        Me.txcabangid.TabIndex = 252
        Me.txcabangid.Visible = False
        '
        'butselectcabang
        '
        Me.butselectcabang.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butselectcabang.Location = New System.Drawing.Point(706, 25)
        Me.butselectcabang.Name = "butselectcabang"
        Me.butselectcabang.Size = New System.Drawing.Size(31, 25)
        Me.butselectcabang.TabIndex = 254
        Me.butselectcabang.Text = "..."
        Me.butselectcabang.UseVisualStyleBackColor = True
        '
        'txcabangket
        '
        Me.txcabangket.BackColor = System.Drawing.SystemColors.Window
        Me.txcabangket.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txcabangket.Location = New System.Drawing.Point(487, 27)
        Me.txcabangket.Name = "txcabangket"
        Me.txcabangket.ReadOnly = True
        Me.txcabangket.Size = New System.Drawing.Size(215, 21)
        Me.txcabangket.TabIndex = 253
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(397, 29)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 16)
        Me.Label8.TabIndex = 251
        Me.Label8.Text = "Sales Office"
        '
        'butsaved
        '
        Me.butsaved.Cursor = System.Windows.Forms.Cursors.Hand
        Me.butsaved.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butsaved.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_save
        Me.butsaved.Location = New System.Drawing.Point(743, 59)
        Me.butsaved.Name = "butsaved"
        Me.butsaved.Size = New System.Drawing.Size(100, 36)
        Me.butsaved.TabIndex = 246
        Me.butsaved.UseVisualStyleBackColor = True
        '
        'dtprocessend
        '
        Me.dtprocessend.CustomFormat = "dd-MMM-yyyy"
        Me.dtprocessend.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtprocessend.Location = New System.Drawing.Point(260, 27)
        Me.dtprocessend.Name = "dtprocessend"
        Me.dtprocessend.Size = New System.Drawing.Size(110, 20)
        Me.dtprocessend.TabIndex = 243
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(232, 30)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(26, 16)
        Me.Label5.TabIndex = 242
        Me.Label5.Text = "s/d"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(25, 29)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(83, 16)
        Me.Label9.TabIndex = 241
        Me.Label9.Text = "Tgl Pinjaman"
        '
        'dtprocess
        '
        Me.dtprocess.CustomFormat = "dd-MMM-yyyy"
        Me.dtprocess.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtprocess.Location = New System.Drawing.Point(120, 27)
        Me.dtprocess.Name = "dtprocess"
        Me.dtprocess.Size = New System.Drawing.Size(110, 20)
        Me.dtprocess.TabIndex = 237
        '
        'butcarikaryawan
        '
        Me.butcarikaryawan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.butcarikaryawan.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butcarikaryawan.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_cari
        Me.butcarikaryawan.Location = New System.Drawing.Point(743, 19)
        Me.butcarikaryawan.Name = "butcarikaryawan"
        Me.butcarikaryawan.Size = New System.Drawing.Size(100, 36)
        Me.butcarikaryawan.TabIndex = 234
        Me.butcarikaryawan.UseVisualStyleBackColor = True
        '
        'gridlab
        '
        Me.gridlab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridlab.EmbeddedNavigator.Name = ""
        Me.gridlab.Location = New System.Drawing.Point(0, 134)
        Me.gridlab.MainView = Me.GridView1
        Me.gridlab.Name = "gridlab"
        Me.gridlab.Size = New System.Drawing.Size(1200, 406)
        Me.gridlab.TabIndex = 11
        Me.gridlab.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.gridlab
        Me.GridView1.GroupPanelText = "Data Pinjaman Karyawan"
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        '
        'FormSendPinjamanKaryawan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1200, 540)
        Me.Controls.Add(Me.gridlab)
        Me.Controls.Add(Me.groupcustomer)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormSendPinjamanKaryawan"
        Me.Text = "Form Pinjaman Karyawan"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.groupcustomer.ResumeLayout(False)
        Me.groupcustomer.PerformLayout()
        CType(Me.gridlab, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents NewToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents groupcustomer As System.Windows.Forms.GroupBox
    'Friend WithEvents butlabrujukanid As DevExpress.XtraEditors.ButtonEdit
    'Friend WithEvents butrujukanid As DevExpress.XtraEditors.ButtonEdit
    Private WithEvents gridlab As DevExpress.XtraGrid.GridControl
    Private WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents butcarikaryawan As System.Windows.Forms.Button
    Friend WithEvents dtprocessend As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtprocess As System.Windows.Forms.DateTimePicker
    Friend WithEvents butsaved As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txcabangid As System.Windows.Forms.TextBox
    Friend WithEvents butselectcabang As System.Windows.Forms.Button
    Friend WithEvents txcabangket As System.Windows.Forms.TextBox
    Friend WithEvents cmbjenispinjaman As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbjenistemuan As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
