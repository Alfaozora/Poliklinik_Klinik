<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MasterGroupTestLab
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
        Me.gridtindakan = New DevExpress.XtraGrid.GridControl
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.butclear = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txpaketharga = New System.Windows.Forms.NumericUpDown
        Me.buttindakanid = New System.Windows.Forms.TextBox
        Me.butfinddokter = New System.Windows.Forms.Button
        Me.butkalkulasi = New System.Windows.Forms.Button
        Me.cmbpaketnama = New System.Windows.Forms.ComboBox
        Me.txpaketketerangan = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtpaketakhir = New System.Windows.Forms.DateTimePicker
        Me.dtpaketawal = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        CType(Me.gridtindakan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.txpaketharga, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gridtindakan
        '
        Me.gridtindakan.Dock = System.Windows.Forms.DockStyle.Fill
        '
        '
        '
        Me.gridtindakan.EmbeddedNavigator.Name = ""
        Me.gridtindakan.Location = New System.Drawing.Point(0, 170)
        Me.gridtindakan.MainView = Me.GridView2
        Me.gridtindakan.Name = "gridtindakan"
        Me.gridtindakan.Size = New System.Drawing.Size(796, 303)
        Me.gridtindakan.TabIndex = 113
        Me.gridtindakan.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.gridtindakan
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsView.ShowAutoFilterRow = True
        Me.GridView2.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowForFocusedRow
        '
        'butclear
        '
        Me.butclear.Location = New System.Drawing.Point(509, 115)
        Me.butclear.Name = "butclear"
        Me.butclear.Size = New System.Drawing.Size(75, 23)
        Me.butclear.TabIndex = 133
        Me.butclear.Text = "Get Detail"
        Me.butclear.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(217, 120)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 13)
        Me.Label7.TabIndex = 129
        Me.Label7.Text = "Tgl End"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 120)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 13)
        Me.Label8.TabIndex = 128
        Me.Label8.Text = "Tgl Start"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 94)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 13)
        Me.Label6.TabIndex = 125
        Me.Label6.Text = "Harga Paket"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "Nama Paket"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txpaketharga)
        Me.GroupBox1.Controls.Add(Me.buttindakanid)
        Me.GroupBox1.Controls.Add(Me.butfinddokter)
        Me.GroupBox1.Controls.Add(Me.butkalkulasi)
        Me.GroupBox1.Controls.Add(Me.cmbpaketnama)
        Me.GroupBox1.Controls.Add(Me.butclear)
        Me.GroupBox1.Controls.Add(Me.txpaketketerangan)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.dtpaketakhir)
        Me.GroupBox1.Controls.Add(Me.dtpaketawal)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(796, 146)
        Me.GroupBox1.TabIndex = 115
        Me.GroupBox1.TabStop = False
        '
        'txpaketharga
        '
        Me.txpaketharga.Location = New System.Drawing.Point(85, 91)
        Me.txpaketharga.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        Me.txpaketharga.Name = "txpaketharga"
        Me.txpaketharga.Size = New System.Drawing.Size(150, 20)
        Me.txpaketharga.TabIndex = 143
        Me.txpaketharga.ThousandsSeparator = True
        '
        'buttindakanid
        '
        Me.buttindakanid.Enabled = False
        Me.buttindakanid.Location = New System.Drawing.Point(85, 13)
        Me.buttindakanid.Name = "buttindakanid"
        Me.buttindakanid.Size = New System.Drawing.Size(96, 20)
        Me.buttindakanid.TabIndex = 128
        '
        'butfinddokter
        '
        Me.butfinddokter.Location = New System.Drawing.Point(187, 11)
        Me.butfinddokter.Name = "butfinddokter"
        Me.butfinddokter.Size = New System.Drawing.Size(27, 23)
        Me.butfinddokter.TabIndex = 127
        Me.butfinddokter.Text = "..."
        Me.butfinddokter.UseVisualStyleBackColor = True
        '
        'butkalkulasi
        '
        Me.butkalkulasi.Location = New System.Drawing.Point(428, 115)
        Me.butkalkulasi.Name = "butkalkulasi"
        Me.butkalkulasi.Size = New System.Drawing.Size(75, 23)
        Me.butkalkulasi.TabIndex = 142
        Me.butkalkulasi.Text = "Kalkulasi"
        Me.butkalkulasi.UseVisualStyleBackColor = True
        '
        'cmbpaketnama
        '
        Me.cmbpaketnama.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbpaketnama.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbpaketnama.FormattingEnabled = True
        Me.cmbpaketnama.Location = New System.Drawing.Point(85, 39)
        Me.cmbpaketnama.Name = "cmbpaketnama"
        Me.cmbpaketnama.Size = New System.Drawing.Size(289, 21)
        Me.cmbpaketnama.TabIndex = 141
        '
        'txpaketketerangan
        '
        Me.txpaketketerangan.Location = New System.Drawing.Point(85, 65)
        Me.txpaketketerangan.Name = "txpaketketerangan"
        Me.txpaketketerangan.Size = New System.Drawing.Size(499, 20)
        Me.txpaketketerangan.TabIndex = 140
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 139
        Me.Label3.Text = "Keterangan"
        '
        'dtpaketakhir
        '
        Me.dtpaketakhir.CustomFormat = "dd-MMM-yyyy"
        Me.dtpaketakhir.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpaketakhir.Location = New System.Drawing.Point(267, 117)
        Me.dtpaketakhir.Name = "dtpaketakhir"
        Me.dtpaketakhir.Size = New System.Drawing.Size(107, 20)
        Me.dtpaketakhir.TabIndex = 136
        '
        'dtpaketawal
        '
        Me.dtpaketawal.CustomFormat = "dd-MMM-yyyy"
        Me.dtpaketawal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpaketawal.Location = New System.Drawing.Point(85, 117)
        Me.dtpaketawal.Name = "dtpaketawal"
        Me.dtpaketawal.Size = New System.Drawing.Size(107, 20)
        Me.dtpaketawal.TabIndex = 135
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 61
        Me.Label2.Text = "PaketID"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.SaveToolStripMenuItem, Me.CloseToolStripMenuItem, Me.PrintToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(796, 24)
        Me.MenuStrip1.TabIndex = 114
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
        'MasterGroupTestLab
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(796, 473)
        Me.Controls.Add(Me.gridtindakan)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "MasterGroupTestLab"
        Me.Text = "MasterGroupTestLab"
        CType(Me.gridtindakan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.txpaketharga, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents butclear As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    'Friend WithEvents buttindakanid As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dtpaketakhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpaketawal As System.Windows.Forms.DateTimePicker
    'Friend WithEvents txpaketharga As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txpaketketerangan As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmbpaketnama As System.Windows.Forms.ComboBox
    Friend WithEvents butkalkulasi As System.Windows.Forms.Button
    Friend WithEvents buttindakanid As System.Windows.Forms.TextBox
    Friend WithEvents butfinddokter As System.Windows.Forms.Button
    Private WithEvents gridtindakan As DevExpress.XtraGrid.GridControl
    Private WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents txpaketharga As System.Windows.Forms.NumericUpDown
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
