<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormScanHyu
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
        Me.TextBoxQrHyu = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ButtonSubmitQR = New System.Windows.Forms.Button
        Me.TextBoxDecodeHyu = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.ButtonCopy = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'TextBoxQrHyu
        '
        Me.TextBoxQrHyu.Location = New System.Drawing.Point(44, 46)
        Me.TextBoxQrHyu.Multiline = True
        Me.TextBoxQrHyu.Name = "TextBoxQrHyu"
        Me.TextBoxQrHyu.Size = New System.Drawing.Size(304, 29)
        Me.TextBoxQrHyu.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(44, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "QR Code HYU"
        '
        'ButtonSubmitQR
        '
        Me.ButtonSubmitQR.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSubmitQR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSubmitQR.ForeColor = System.Drawing.Color.White
        Me.ButtonSubmitQR.Location = New System.Drawing.Point(273, 81)
        Me.ButtonSubmitQR.Name = "ButtonSubmitQR"
        Me.ButtonSubmitQR.Size = New System.Drawing.Size(75, 27)
        Me.ButtonSubmitQR.TabIndex = 2
        Me.ButtonSubmitQR.Text = "Submit"
        Me.ButtonSubmitQR.UseVisualStyleBackColor = False
        '
        'TextBoxDecodeHyu
        '
        Me.TextBoxDecodeHyu.BackColor = System.Drawing.Color.PaleGreen
        Me.TextBoxDecodeHyu.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBoxDecodeHyu.Location = New System.Drawing.Point(44, 127)
        Me.TextBoxDecodeHyu.Multiline = True
        Me.TextBoxDecodeHyu.Name = "TextBoxDecodeHyu"
        Me.TextBoxDecodeHyu.ReadOnly = True
        Me.TextBoxDecodeHyu.Size = New System.Drawing.Size(304, 20)
        Me.TextBoxDecodeHyu.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(44, 111)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Hasil Decode"
        '
        'ButtonCopy
        '
        Me.ButtonCopy.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCopy.ForeColor = System.Drawing.Color.White
        Me.ButtonCopy.Location = New System.Drawing.Point(273, 153)
        Me.ButtonCopy.Name = "ButtonCopy"
        Me.ButtonCopy.Size = New System.Drawing.Size(75, 27)
        Me.ButtonCopy.TabIndex = 5
        Me.ButtonCopy.Text = "Copy Text"
        Me.ButtonCopy.UseVisualStyleBackColor = False
        '
        'FormScanHyu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(384, 211)
        Me.Controls.Add(Me.ButtonCopy)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBoxDecodeHyu)
        Me.Controls.Add(Me.ButtonSubmitQR)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBoxQrHyu)
        Me.Name = "FormScanHyu"
        Me.Text = "FormScanHyu"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBoxQrHyu As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonSubmitQR As System.Windows.Forms.Button
    Friend WithEvents TextBoxDecodeHyu As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ButtonCopy As System.Windows.Forms.Button
End Class
