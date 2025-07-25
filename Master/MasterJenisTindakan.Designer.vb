<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MasterJenisTindakan
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
        Me.txjenisid = New System.Windows.Forms.TextBox
        Me.butfindjenis = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.buttransdisplay = New System.Windows.Forms.Button
        Me.txjenistindakan = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txjenisid
        '
        Me.txjenisid.Enabled = False
        Me.txjenisid.Location = New System.Drawing.Point(288, 34)
        Me.txjenisid.Name = "txjenisid"
        Me.txjenisid.Size = New System.Drawing.Size(36, 20)
        Me.txjenisid.TabIndex = 195
        '
        'butfindjenis
        '
        Me.butfindjenis.Location = New System.Drawing.Point(330, 32)
        Me.butfindjenis.Name = "butfindjenis"
        Me.butfindjenis.Size = New System.Drawing.Size(31, 23)
        Me.butfindjenis.TabIndex = 194
        Me.butfindjenis.Text = "..."
        Me.butfindjenis.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(194, 63)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 193
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'buttransdisplay
        '
        Me.buttransdisplay.Location = New System.Drawing.Point(103, 63)
        Me.buttransdisplay.Name = "buttransdisplay"
        Me.buttransdisplay.Size = New System.Drawing.Size(75, 23)
        Me.buttransdisplay.TabIndex = 192
        Me.buttransdisplay.Text = "New"
        Me.buttransdisplay.UseVisualStyleBackColor = True
        '
        'txjenistindakan
        '
        Me.txjenistindakan.Location = New System.Drawing.Point(96, 34)
        Me.txjenistindakan.Name = "txjenistindakan"
        Me.txjenistindakan.Size = New System.Drawing.Size(186, 20)
        Me.txjenistindakan.TabIndex = 184
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 185
        Me.Label2.Text = "Jenis Tindakan"
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
        Me.DeleteToolStripMenuItem.Enabled = False
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
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.SaveToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.CloseToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(372, 24)
        Me.MenuStrip1.TabIndex = 183
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MasterJenisTindakan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(372, 94)
        Me.Controls.Add(Me.txjenisid)
        Me.Controls.Add(Me.butfindjenis)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.buttransdisplay)
        Me.Controls.Add(Me.txjenistindakan)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "MasterJenisTindakan"
        Me.Text = "MasterJenisTindakan"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txjenisid As System.Windows.Forms.TextBox
    Friend WithEvents butfindjenis As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents buttransdisplay As System.Windows.Forms.Button
    Friend WithEvents txjenistindakan As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
End Class
