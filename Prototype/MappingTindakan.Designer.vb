<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MappingTindakan
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.DataGridViewTindakan = New System.Windows.Forms.DataGridView
        Me.ComboBoxTindakan = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DataGridViewTindakan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ComboBoxTindakan)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridViewTindakan)
        Me.SplitContainer1.Size = New System.Drawing.Size(954, 449)
        Me.SplitContainer1.SplitterDistance = 106
        Me.SplitContainer1.TabIndex = 0
        '
        'DataGridViewTindakan
        '
        Me.DataGridViewTindakan.BackgroundColor = System.Drawing.Color.White
        Me.DataGridViewTindakan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewTindakan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewTindakan.Location = New System.Drawing.Point(0, 0)
        Me.DataGridViewTindakan.Name = "DataGridViewTindakan"
        Me.DataGridViewTindakan.Size = New System.Drawing.Size(954, 339)
        Me.DataGridViewTindakan.TabIndex = 0
        '
        'ComboBoxTindakan
        '
        Me.ComboBoxTindakan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.ComboBoxTindakan.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBoxTindakan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxTindakan.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBoxTindakan.FormattingEnabled = True
        Me.ComboBoxTindakan.Location = New System.Drawing.Point(106, 22)
        Me.ComboBoxTindakan.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxTindakan.Name = "ComboBoxTindakan"
        Me.ComboBoxTindakan.Size = New System.Drawing.Size(198, 25)
        Me.ComboBoxTindakan.TabIndex = 522
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 17)
        Me.Label1.TabIndex = 523
        Me.Label1.Text = "Pilih Tindakan"
        '
        'MappingTindakan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(954, 449)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "MappingTindakan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MappingTindakan"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DataGridViewTindakan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents DataGridViewTindakan As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxTindakan As System.Windows.Forms.ComboBox
End Class
