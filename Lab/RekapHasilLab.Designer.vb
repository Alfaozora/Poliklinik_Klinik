<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RekapHasilLab
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txcustlp = New System.Windows.Forms.TextBox
        Me.dtcusttgllhr = New System.Windows.Forms.DateTimePicker
        Me.Label5 = New System.Windows.Forms.Label
        Me.txcustumur = New System.Windows.Forms.TextBox
        Me.txcustnama = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.butcustid = New DevExpress.XtraEditors.ButtonEdit
        Me.buttindakanid = New DevExpress.XtraEditors.ButtonEdit
        Me.txtindakanid = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.gridpenerimaan = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.butcustid.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.buttindakanid.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridpenerimaan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RefreshToolStripMenuItem, Me.CloseToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(700, 24)
        Me.MenuStrip1.TabIndex = 150
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txcustlp)
        Me.GroupBox1.Controls.Add(Me.dtcusttgllhr)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txcustumur)
        Me.GroupBox1.Controls.Add(Me.txcustnama)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label30)
        Me.GroupBox1.Controls.Add(Me.butcustid)
        Me.GroupBox1.Controls.Add(Me.buttindakanid)
        Me.GroupBox1.Controls.Add(Me.txtindakanid)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(700, 151)
        Me.GroupBox1.TabIndex = 151
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detail"
        '
        'txcustlp
        '
        Me.txcustlp.Enabled = False
        Me.txcustlp.Location = New System.Drawing.Point(478, 69)
        Me.txcustlp.Name = "txcustlp"
        Me.txcustlp.Size = New System.Drawing.Size(43, 20)
        Me.txcustlp.TabIndex = 153
        '
        'dtcusttgllhr
        '
        Me.dtcusttgllhr.CustomFormat = "dd-MMM-yyyy"
        Me.dtcusttgllhr.Enabled = False
        Me.dtcusttgllhr.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtcusttgllhr.Location = New System.Drawing.Point(114, 69)
        Me.dtcusttgllhr.Name = "dtcusttgllhr"
        Me.dtcusttgllhr.Size = New System.Drawing.Size(107, 20)
        Me.dtcusttgllhr.TabIndex = 152
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Enabled = False
        Me.Label5.Location = New System.Drawing.Point(441, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 151
        Me.Label5.Text = "L / P"
        '
        'txcustumur
        '
        Me.txcustumur.Enabled = False
        Me.txcustumur.Location = New System.Drawing.Point(267, 69)
        Me.txcustumur.Name = "txcustumur"
        Me.txcustumur.Size = New System.Drawing.Size(166, 20)
        Me.txcustumur.TabIndex = 150
        '
        'txcustnama
        '
        Me.txcustnama.Enabled = False
        Me.txcustnama.Location = New System.Drawing.Point(267, 43)
        Me.txcustnama.Name = "txcustnama"
        Me.txcustnama.Size = New System.Drawing.Size(254, 20)
        Me.txcustnama.TabIndex = 149
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Enabled = False
        Me.Label4.Location = New System.Drawing.Point(229, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 148
        Me.Label4.Text = "Umur"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Enabled = False
        Me.Label3.Location = New System.Drawing.Point(36, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 13)
        Me.Label3.TabIndex = 147
        Me.Label3.Text = "Tanggal Lahir"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Enabled = False
        Me.Label2.Location = New System.Drawing.Point(226, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 146
        Me.Label2.Text = "Nama"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Enabled = False
        Me.Label30.Location = New System.Drawing.Point(55, 46)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(53, 13)
        Me.Label30.TabIndex = 145
        Me.Label30.Text = "Pasien ID"
        '
        'butcustid
        '
        Me.butcustid.Enabled = False
        Me.butcustid.Location = New System.Drawing.Point(114, 43)
        Me.butcustid.Name = "butcustid"
        Me.butcustid.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.butcustid.Size = New System.Drawing.Size(107, 22)
        Me.butcustid.TabIndex = 144
        '
        'buttindakanid
        '
        Me.buttindakanid.Location = New System.Drawing.Point(114, 17)
        Me.buttindakanid.Name = "buttindakanid"
        Me.buttindakanid.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.buttindakanid.Size = New System.Drawing.Size(145, 22)
        Me.buttindakanid.TabIndex = 139
        '
        'txtindakanid
        '
        Me.txtindakanid.Enabled = False
        Me.txtindakanid.Location = New System.Drawing.Point(267, 17)
        Me.txtindakanid.Name = "txtindakanid"
        Me.txtindakanid.Size = New System.Drawing.Size(94, 20)
        Me.txtindakanid.TabIndex = 143
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Enabled = False
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 13)
        Me.Label1.TabIndex = 138
        Me.Label1.Text = "Pemeriksaan ID"
        '
        'gridpenerimaan
        '
        Me.gridpenerimaan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridpenerimaan.EmbeddedNavigator.Name = ""
        Me.gridpenerimaan.Location = New System.Drawing.Point(0, 175)
        Me.gridpenerimaan.MainView = Me.GridView1
        Me.gridpenerimaan.Name = "gridpenerimaan"
        Me.gridpenerimaan.Size = New System.Drawing.Size(700, 331)
        Me.gridpenerimaan.TabIndex = 152
        Me.gridpenerimaan.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.gridpenerimaan
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        '
        'RekapHasilLab
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(700, 506)
        Me.Controls.Add(Me.gridpenerimaan)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "RekapHasilLab"
        Me.Text = "RekapHasilLab"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.butcustid.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.buttindakanid.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridpenerimaan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txcustlp As System.Windows.Forms.TextBox
    Friend WithEvents dtcusttgllhr As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txcustumur As System.Windows.Forms.TextBox
    Friend WithEvents txcustnama As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents butcustid As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents buttindakanid As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents txtindakanid As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gridpenerimaan As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
