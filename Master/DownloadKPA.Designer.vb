<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DownloadKPA
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
        Me.chkkpa = New System.Windows.Forms.CheckBox
        Me.dtnow = New System.Windows.Forms.DateTimePicker
        Me.butdownloadkpa = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'chkkpa
        '
        Me.chkkpa.AutoSize = True
        Me.chkkpa.Checked = True
        Me.chkkpa.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkkpa.Enabled = False
        Me.chkkpa.Location = New System.Drawing.Point(12, 11)
        Me.chkkpa.Name = "chkkpa"
        Me.chkkpa.Size = New System.Drawing.Size(94, 17)
        Me.chkkpa.TabIndex = 0
        Me.chkkpa.Text = "KPA aktif per -"
        Me.chkkpa.UseVisualStyleBackColor = True
        '
        'dtnow
        '
        Me.dtnow.CustomFormat = "dd-MMM-yyyy"
        Me.dtnow.Enabled = False
        Me.dtnow.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtnow.Location = New System.Drawing.Point(112, 8)
        Me.dtnow.Name = "dtnow"
        Me.dtnow.Size = New System.Drawing.Size(107, 20)
        Me.dtnow.TabIndex = 63
        '
        'butdownloadkpa
        '
        Me.butdownloadkpa.Location = New System.Drawing.Point(257, 7)
        Me.butdownloadkpa.Name = "butdownloadkpa"
        Me.butdownloadkpa.Size = New System.Drawing.Size(75, 23)
        Me.butdownloadkpa.TabIndex = 64
        Me.butdownloadkpa.Text = "Download"
        Me.butdownloadkpa.UseVisualStyleBackColor = True
        '
        'DownloadKPA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(340, 41)
        Me.Controls.Add(Me.butdownloadkpa)
        Me.Controls.Add(Me.dtnow)
        Me.Controls.Add(Me.chkkpa)
        Me.Name = "DownloadKPA"
        Me.Text = "DownloadKPA"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkkpa As System.Windows.Forms.CheckBox
    Friend WithEvents dtnow As System.Windows.Forms.DateTimePicker
    Friend WithEvents butdownloadkpa As System.Windows.Forms.Button
End Class
