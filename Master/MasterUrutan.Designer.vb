<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MasterUrutan
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
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TestDisplayToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.gridtindakan = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.gridjenis = New System.Windows.Forms.DataGridView
        Me.butsavejenis = New System.Windows.Forms.Button
        Me.butjenisdown = New System.Windows.Forms.Button
        Me.butjenisup = New System.Windows.Forms.Button
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.gridurutantindakan = New System.Windows.Forms.DataGridView
        Me.txjenisid = New System.Windows.Forms.TextBox
        Me.butjenis = New System.Windows.Forms.TextBox
        Me.butfindjenis = New System.Windows.Forms.Button
        Me.Label30 = New System.Windows.Forms.Label
        Me.butsave = New System.Windows.Forms.Button
        Me.butdown = New System.Windows.Forms.Button
        Me.butup = New System.Windows.Forms.Button
        Me.MenuStrip1.SuspendLayout()
        Me.gridtindakan.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.gridjenis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.gridurutantindakan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.CloseToolStripMenuItem, Me.TestDisplayToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(509, 24)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'TestDisplayToolStripMenuItem
        '
        Me.TestDisplayToolStripMenuItem.Name = "TestDisplayToolStripMenuItem"
        Me.TestDisplayToolStripMenuItem.Size = New System.Drawing.Size(79, 20)
        Me.TestDisplayToolStripMenuItem.Text = "TestDisplay"
        '
        'gridtindakan
        '
        Me.gridtindakan.Controls.Add(Me.TabPage1)
        Me.gridtindakan.Controls.Add(Me.TabPage2)
        Me.gridtindakan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridtindakan.Location = New System.Drawing.Point(0, 24)
        Me.gridtindakan.Name = "gridtindakan"
        Me.gridtindakan.SelectedIndex = 0
        Me.gridtindakan.Size = New System.Drawing.Size(509, 463)
        Me.gridtindakan.TabIndex = 5
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.gridjenis)
        Me.TabPage1.Controls.Add(Me.butsavejenis)
        Me.TabPage1.Controls.Add(Me.butjenisdown)
        Me.TabPage1.Controls.Add(Me.butjenisup)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(501, 437)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Sort Jenis Tindakan"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'gridjenis
        '
        Me.gridjenis.AllowUserToAddRows = False
        Me.gridjenis.AllowUserToDeleteRows = False
        Me.gridjenis.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridjenis.Location = New System.Drawing.Point(8, 6)
        Me.gridjenis.MultiSelect = False
        Me.gridjenis.Name = "gridjenis"
        Me.gridjenis.ReadOnly = True
        Me.gridjenis.Size = New System.Drawing.Size(404, 423)
        Me.gridjenis.TabIndex = 4
        '
        'butsavejenis
        '
        Me.butsavejenis.Location = New System.Drawing.Point(418, 6)
        Me.butsavejenis.Name = "butsavejenis"
        Me.butsavejenis.Size = New System.Drawing.Size(75, 23)
        Me.butsavejenis.TabIndex = 3
        Me.butsavejenis.Text = "Save"
        Me.butsavejenis.UseVisualStyleBackColor = True
        '
        'butjenisdown
        '
        Me.butjenisdown.Location = New System.Drawing.Point(418, 227)
        Me.butjenisdown.Name = "butjenisdown"
        Me.butjenisdown.Size = New System.Drawing.Size(75, 23)
        Me.butjenisdown.TabIndex = 2
        Me.butjenisdown.Text = "DOWN"
        Me.butjenisdown.UseVisualStyleBackColor = True
        '
        'butjenisup
        '
        Me.butjenisup.Location = New System.Drawing.Point(418, 187)
        Me.butjenisup.Name = "butjenisup"
        Me.butjenisup.Size = New System.Drawing.Size(75, 23)
        Me.butjenisup.TabIndex = 1
        Me.butjenisup.Text = "UP"
        Me.butjenisup.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.gridurutantindakan)
        Me.TabPage2.Controls.Add(Me.txjenisid)
        Me.TabPage2.Controls.Add(Me.butjenis)
        Me.TabPage2.Controls.Add(Me.butfindjenis)
        Me.TabPage2.Controls.Add(Me.Label30)
        Me.TabPage2.Controls.Add(Me.butsave)
        Me.TabPage2.Controls.Add(Me.butdown)
        Me.TabPage2.Controls.Add(Me.butup)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(501, 437)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Sort Tindakan Lab"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'gridurutantindakan
        '
        Me.gridurutantindakan.AllowUserToAddRows = False
        Me.gridurutantindakan.AllowUserToDeleteRows = False
        Me.gridurutantindakan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridurutantindakan.Location = New System.Drawing.Point(8, 35)
        Me.gridurutantindakan.MultiSelect = False
        Me.gridurutantindakan.Name = "gridurutantindakan"
        Me.gridurutantindakan.ReadOnly = True
        Me.gridurutantindakan.Size = New System.Drawing.Size(404, 394)
        Me.gridurutantindakan.TabIndex = 187
        '
        'txjenisid
        '
        Me.txjenisid.Enabled = False
        Me.txjenisid.Location = New System.Drawing.Point(370, 9)
        Me.txjenisid.Name = "txjenisid"
        Me.txjenisid.Size = New System.Drawing.Size(42, 20)
        Me.txjenisid.TabIndex = 186
        '
        'butjenis
        '
        Me.butjenis.Enabled = False
        Me.butjenis.Location = New System.Drawing.Point(93, 9)
        Me.butjenis.Name = "butjenis"
        Me.butjenis.Size = New System.Drawing.Size(231, 20)
        Me.butjenis.TabIndex = 185
        '
        'butfindjenis
        '
        Me.butfindjenis.Location = New System.Drawing.Point(330, 7)
        Me.butfindjenis.Name = "butfindjenis"
        Me.butfindjenis.Size = New System.Drawing.Size(34, 23)
        Me.butfindjenis.TabIndex = 184
        Me.butfindjenis.Text = "..."
        Me.butfindjenis.UseVisualStyleBackColor = True
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Enabled = False
        Me.Label30.Location = New System.Drawing.Point(8, 12)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(79, 13)
        Me.Label30.TabIndex = 183
        Me.Label30.Text = "Jenis Tindakan"
        '
        'butsave
        '
        Me.butsave.Location = New System.Drawing.Point(418, 36)
        Me.butsave.Name = "butsave"
        Me.butsave.Size = New System.Drawing.Size(75, 23)
        Me.butsave.TabIndex = 7
        Me.butsave.Text = "Save"
        Me.butsave.UseVisualStyleBackColor = True
        '
        'butdown
        '
        Me.butdown.Location = New System.Drawing.Point(418, 227)
        Me.butdown.Name = "butdown"
        Me.butdown.Size = New System.Drawing.Size(75, 23)
        Me.butdown.TabIndex = 6
        Me.butdown.Text = "DOWN"
        Me.butdown.UseVisualStyleBackColor = True
        '
        'butup
        '
        Me.butup.Location = New System.Drawing.Point(418, 187)
        Me.butup.Name = "butup"
        Me.butup.Size = New System.Drawing.Size(75, 23)
        Me.butup.TabIndex = 5
        Me.butup.Text = "UP"
        Me.butup.UseVisualStyleBackColor = True
        '
        'MasterUrutan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(509, 487)
        Me.Controls.Add(Me.gridtindakan)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "MasterUrutan"
        Me.Text = "MasterUrutan"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.gridtindakan.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.gridjenis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.gridurutantindakan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gridtindakan As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents butsavejenis As System.Windows.Forms.Button
    Friend WithEvents butjenisdown As System.Windows.Forms.Button
    Friend WithEvents butjenisup As System.Windows.Forms.Button
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents butsave As System.Windows.Forms.Button
    Friend WithEvents butdown As System.Windows.Forms.Button
    Friend WithEvents butup As System.Windows.Forms.Button
    Friend WithEvents butjenis As System.Windows.Forms.TextBox
    Friend WithEvents butfindjenis As System.Windows.Forms.Button
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txjenisid As System.Windows.Forms.TextBox
    Friend WithEvents gridjenis As System.Windows.Forms.DataGridView
    Friend WithEvents gridurutantindakan As System.Windows.Forms.DataGridView
    Friend WithEvents TestDisplayToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
