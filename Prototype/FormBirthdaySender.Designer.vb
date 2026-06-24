<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBirthdaySender
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
        Me.LabelNama = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ButtonStop = New System.Windows.Forms.Button
        Me.ButtonKirim = New System.Windows.Forms.Button
        Me.ButtonLoad = New System.Windows.Forms.Button
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.dgView = New System.Windows.Forms.DataGridView
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.dgView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelNama)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ButtonStop)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ButtonKirim)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ButtonLoad)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(704, 415)
        Me.SplitContainer1.SplitterDistance = 234
        Me.SplitContainer1.TabIndex = 0
        '
        'LabelNama
        '
        Me.LabelNama.AutoSize = True
        Me.LabelNama.Location = New System.Drawing.Point(12, 179)
        Me.LabelNama.Name = "LabelNama"
        Me.LabelNama.Size = New System.Drawing.Size(31, 13)
        Me.LabelNama.TabIndex = 4
        Me.LabelNama.Text = "[Null]"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 154)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Mengirim Ke :"
        '
        'ButtonStop
        '
        Me.ButtonStop.BackColor = System.Drawing.Color.Red
        Me.ButtonStop.FlatAppearance.BorderSize = 0
        Me.ButtonStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonStop.ForeColor = System.Drawing.Color.White
        Me.ButtonStop.Location = New System.Drawing.Point(128, 70)
        Me.ButtonStop.Name = "ButtonStop"
        Me.ButtonStop.Size = New System.Drawing.Size(95, 24)
        Me.ButtonStop.TabIndex = 2
        Me.ButtonStop.Text = "Stop"
        Me.ButtonStop.UseVisualStyleBackColor = False
        '
        'ButtonKirim
        '
        Me.ButtonKirim.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ButtonKirim.FlatAppearance.BorderSize = 0
        Me.ButtonKirim.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonKirim.Location = New System.Drawing.Point(12, 70)
        Me.ButtonKirim.Name = "ButtonKirim"
        Me.ButtonKirim.Size = New System.Drawing.Size(100, 24)
        Me.ButtonKirim.TabIndex = 1
        Me.ButtonKirim.Text = "Kirim"
        Me.ButtonKirim.UseVisualStyleBackColor = False
        '
        'ButtonLoad
        '
        Me.ButtonLoad.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ButtonLoad.FlatAppearance.BorderSize = 0
        Me.ButtonLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonLoad.Location = New System.Drawing.Point(12, 24)
        Me.ButtonLoad.Name = "ButtonLoad"
        Me.ButtonLoad.Size = New System.Drawing.Size(211, 24)
        Me.ButtonLoad.TabIndex = 0
        Me.ButtonLoad.Text = "Load Data"
        Me.ButtonLoad.UseVisualStyleBackColor = False
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.dgView)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.ProgressBar1)
        Me.SplitContainer2.Size = New System.Drawing.Size(466, 415)
        Me.SplitContainer2.SplitterDistance = 369
        Me.SplitContainer2.TabIndex = 0
        '
        'dgView
        '
        Me.dgView.BackgroundColor = System.Drawing.Color.White
        Me.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgView.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgView.Location = New System.Drawing.Point(0, 0)
        Me.dgView.Name = "dgView"
        Me.dgView.Size = New System.Drawing.Size(466, 369)
        Me.dgView.TabIndex = 0
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 9)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(441, 23)
        Me.ProgressBar1.TabIndex = 0
        '
        'FormBirthdaySender
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(704, 415)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FormBirthdaySender"
        Me.Text = "FormBirthdaySender"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.dgView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgView As System.Windows.Forms.DataGridView
    Friend WithEvents ButtonStop As System.Windows.Forms.Button
    Friend WithEvents ButtonKirim As System.Windows.Forms.Button
    Friend WithEvents ButtonLoad As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents LabelNama As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
