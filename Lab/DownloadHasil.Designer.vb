<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DownloadHasil
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
        Me.groupdetail = New System.Windows.Forms.GroupBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabLab = New System.Windows.Forms.TabPage
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.gridlab = New DevExpress.XtraGrid.GridControl
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cmddownload = New System.Windows.Forms.Button
        Me.dtchanged = New System.Windows.Forms.DateTimePicker
        Me.Label15 = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.RefreshToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.groupdetail.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabLab.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.gridlab, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupdetail
        '
        Me.groupdetail.Controls.Add(Me.TabControl1)
        Me.groupdetail.Controls.Add(Me.GroupBox3)
        Me.groupdetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.groupdetail.Location = New System.Drawing.Point(0, 24)
        Me.groupdetail.Name = "groupdetail"
        Me.groupdetail.Size = New System.Drawing.Size(926, 479)
        Me.groupdetail.TabIndex = 9
        Me.groupdetail.TabStop = False
        Me.groupdetail.Text = "Detail"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabLab)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(3, 16)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(920, 413)
        Me.TabControl1.TabIndex = 67
        '
        'TabLab
        '
        Me.TabLab.Controls.Add(Me.GroupBox7)
        Me.TabLab.Location = New System.Drawing.Point(4, 22)
        Me.TabLab.Name = "TabLab"
        Me.TabLab.Padding = New System.Windows.Forms.Padding(3)
        Me.TabLab.Size = New System.Drawing.Size(912, 387)
        Me.TabLab.TabIndex = 3
        Me.TabLab.Text = "Hasil Acc"
        Me.TabLab.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.gridlab)
        Me.GroupBox7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox7.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(906, 381)
        Me.GroupBox7.TabIndex = 2
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Laboratorium"
        '
        'gridlab
        '
        Me.gridlab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridlab.EmbeddedNavigator.Name = ""
        Me.gridlab.Location = New System.Drawing.Point(3, 16)
        Me.gridlab.MainView = Me.GridView3
        Me.gridlab.Name = "gridlab"
        Me.gridlab.Size = New System.Drawing.Size(900, 362)
        Me.gridlab.TabIndex = 2
        Me.gridlab.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.gridlab
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsView.ShowFilterPanel = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmddownload)
        Me.GroupBox3.Controls.Add(Me.dtchanged)
        Me.GroupBox3.Controls.Add(Me.Label15)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox3.Location = New System.Drawing.Point(3, 429)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(920, 47)
        Me.GroupBox3.TabIndex = 81
        Me.GroupBox3.TabStop = False
        '
        'cmddownload
        '
        Me.cmddownload.Location = New System.Drawing.Point(794, 16)
        Me.cmddownload.Name = "cmddownload"
        Me.cmddownload.Size = New System.Drawing.Size(116, 23)
        Me.cmddownload.TabIndex = 67
        Me.cmddownload.Text = "Download"
        Me.cmddownload.UseVisualStyleBackColor = True
        '
        'dtchanged
        '
        Me.dtchanged.CustomFormat = "dd-MMM-yyyy"
        Me.dtchanged.Enabled = False
        Me.dtchanged.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtchanged.Location = New System.Drawing.Point(94, 18)
        Me.dtchanged.Name = "dtchanged"
        Me.dtchanged.Size = New System.Drawing.Size(107, 20)
        Me.dtchanged.TabIndex = 64
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Enabled = False
        Me.Label15.Location = New System.Drawing.Point(9, 21)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(75, 13)
        Me.Label15.TabIndex = 63
        Me.Label15.Text = "Tgl Input Hasil"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.RefreshToolStripMenuItem, Me.PrintToolStripMenuItem, Me.CloseToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(926, 24)
        Me.MenuStrip1.TabIndex = 8
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'RefreshToolStripMenuItem
        '
        Me.RefreshToolStripMenuItem.Name = "RefreshToolStripMenuItem"
        Me.RefreshToolStripMenuItem.Size = New System.Drawing.Size(58, 20)
        Me.RefreshToolStripMenuItem.Text = "Refresh"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'DownloadHasil
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(926, 503)
        Me.Controls.Add(Me.groupdetail)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "DownloadHasil"
        Me.Text = "DownloadHasil"
        Me.groupdetail.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabLab.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        CType(Me.gridlab, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents groupdetail As System.Windows.Forms.GroupBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabLab As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents gridlab As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmddownload As System.Windows.Forms.Button
    Friend WithEvents dtchanged As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RefreshToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
