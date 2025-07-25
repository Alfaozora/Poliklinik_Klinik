<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBandingGambar
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
        Me.ComboBoxKetBanding = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.PictureBoxBanding = New System.Windows.Forms.PictureBox
        Me.PictureBoxAsli = New System.Windows.Forms.PictureBox
        CType(Me.PictureBoxBanding, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxAsli, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ComboBoxKetBanding
        '
        Me.ComboBoxKetBanding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxKetBanding.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxKetBanding.FormattingEnabled = True
        Me.ComboBoxKetBanding.Location = New System.Drawing.Point(556, 59)
        Me.ComboBoxKetBanding.Name = "ComboBoxKetBanding"
        Me.ComboBoxKetBanding.Size = New System.Drawing.Size(200, 25)
        Me.ComboBoxKetBanding.TabIndex = 529
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(298, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(235, 20)
        Me.Label1.TabIndex = 530
        Me.Label1.Text = "Form Perbandingan Gambar"
        '
        'PictureBoxBanding
        '
        Me.PictureBoxBanding.BackColor = System.Drawing.Color.White
        Me.PictureBoxBanding.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBoxBanding.Location = New System.Drawing.Point(302, 59)
        Me.PictureBoxBanding.Name = "PictureBoxBanding"
        Me.PictureBoxBanding.Size = New System.Drawing.Size(227, 265)
        Me.PictureBoxBanding.TabIndex = 527
        Me.PictureBoxBanding.TabStop = False
        '
        'PictureBoxAsli
        '
        Me.PictureBoxAsli.BackColor = System.Drawing.Color.White
        Me.PictureBoxAsli.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBoxAsli.Location = New System.Drawing.Point(36, 59)
        Me.PictureBoxAsli.Name = "PictureBoxAsli"
        Me.PictureBoxAsli.Size = New System.Drawing.Size(230, 265)
        Me.PictureBoxAsli.TabIndex = 526
        Me.PictureBoxAsli.TabStop = False
        '
        'FormBandingGambar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(783, 369)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBoxKetBanding)
        Me.Controls.Add(Me.PictureBoxBanding)
        Me.Controls.Add(Me.PictureBoxAsli)
        Me.Name = "FormBandingGambar"
        Me.Text = "FormBandingGambar"
        CType(Me.PictureBoxBanding, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxAsli, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBoxAsli As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBoxBanding As System.Windows.Forms.PictureBox
    Friend WithEvents ComboBoxKetBanding As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
