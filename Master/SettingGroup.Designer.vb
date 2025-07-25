<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingGroup
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
        Me.ClearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.grpdetail = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbgroupid = New System.Windows.Forms.ComboBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.dtupdate = New System.Windows.Forms.DateTimePicker
        Me.Label14 = New System.Windows.Forms.Label
        Me.txupdate = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.dtcreate = New System.Windows.Forms.DateTimePicker
        Me.Label12 = New System.Windows.Forms.Label
        Me.txcreate = New System.Windows.Forms.TextBox
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.MenuStrip1.SuspendLayout()
        Me.grpdetail.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearToolStripMenuItem, Me.SaveToolStripMenuItem, Me.CloseToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(704, 24)
        Me.MenuStrip1.TabIndex = 10
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ClearToolStripMenuItem
        '
        Me.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem"
        Me.ClearToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.ClearToolStripMenuItem.Text = "New"
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
        'grpdetail
        '
        Me.grpdetail.Controls.Add(Me.Label4)
        Me.grpdetail.Controls.Add(Me.cmbgroupid)
        Me.grpdetail.Controls.Add(Me.GroupBox3)
        Me.grpdetail.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpdetail.Location = New System.Drawing.Point(0, 24)
        Me.grpdetail.Name = "grpdetail"
        Me.grpdetail.Size = New System.Drawing.Size(704, 93)
        Me.grpdetail.TabIndex = 27
        Me.grpdetail.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 78
        Me.Label4.Text = "GroupID"
        '
        'cmbgroupid
        '
        Me.cmbgroupid.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbgroupid.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbgroupid.FormattingEnabled = True
        Me.cmbgroupid.Location = New System.Drawing.Point(63, 19)
        Me.cmbgroupid.Name = "cmbgroupid"
        Me.cmbgroupid.Size = New System.Drawing.Size(151, 21)
        Me.cmbgroupid.TabIndex = 77
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.SystemColors.MenuBar
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.dtupdate)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.txupdate)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.dtcreate)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.txcreate)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox3.Enabled = False
        Me.GroupBox3.Location = New System.Drawing.Point(3, 42)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(698, 48)
        Me.GroupBox3.TabIndex = 72
        Me.GroupBox3.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Enabled = False
        Me.Label13.Location = New System.Drawing.Point(354, 23)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(65, 13)
        Me.Label13.TabIndex = 52
        Me.Label13.Text = "UpdateDate"
        '
        'dtupdate
        '
        Me.dtupdate.CustomFormat = "dd-MMM-yyyy"
        Me.dtupdate.Enabled = False
        Me.dtupdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtupdate.Location = New System.Drawing.Point(425, 19)
        Me.dtupdate.Name = "dtupdate"
        Me.dtupdate.Size = New System.Drawing.Size(100, 20)
        Me.dtupdate.TabIndex = 51
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Enabled = False
        Me.Label14.Location = New System.Drawing.Point(531, 22)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(54, 13)
        Me.Label14.TabIndex = 49
        Me.Label14.Text = "UpdateBy"
        '
        'txupdate
        '
        Me.txupdate.Enabled = False
        Me.txupdate.Location = New System.Drawing.Point(591, 19)
        Me.txupdate.MaxLength = 3
        Me.txupdate.Name = "txupdate"
        Me.txupdate.Size = New System.Drawing.Size(93, 20)
        Me.txupdate.TabIndex = 50
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Enabled = False
        Me.Label11.Location = New System.Drawing.Point(9, 23)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(61, 13)
        Me.Label11.TabIndex = 48
        Me.Label11.Text = "CreateDate"
        '
        'dtcreate
        '
        Me.dtcreate.CustomFormat = "dd-MMM-yyyy"
        Me.dtcreate.Enabled = False
        Me.dtcreate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtcreate.Location = New System.Drawing.Point(76, 19)
        Me.dtcreate.Name = "dtcreate"
        Me.dtcreate.Size = New System.Drawing.Size(100, 20)
        Me.dtcreate.TabIndex = 47
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Enabled = False
        Me.Label12.Location = New System.Drawing.Point(182, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(50, 13)
        Me.Label12.TabIndex = 45
        Me.Label12.Text = "CreateBy"
        '
        'txcreate
        '
        Me.txcreate.Enabled = False
        Me.txcreate.Location = New System.Drawing.Point(238, 19)
        Me.txcreate.MaxLength = 3
        Me.txcreate.Name = "txcreate"
        Me.txcreate.Size = New System.Drawing.Size(93, 20)
        Me.txcreate.TabIndex = 46
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        '
        '
        '
        Me.GridControl1.EmbeddedNavigator.Name = ""
        Me.GridControl1.Location = New System.Drawing.Point(0, 117)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(704, 319)
        Me.GridControl1.TabIndex = 28
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.AutoCalcPreviewLineCount = True
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowForFocusedRow
        '
        'SettingGroup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(704, 436)
        Me.Controls.Add(Me.GridControl1)
        Me.Controls.Add(Me.grpdetail)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "SettingGroup"
        Me.Text = "SettingGroup"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.grpdetail.ResumeLayout(False)
        Me.grpdetail.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ClearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents grpdetail As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbgroupid As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents dtupdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txupdate As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtcreate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txcreate As System.Windows.Forms.TextBox
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
