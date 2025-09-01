<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBase64
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
        Me.TextBoxInput = New System.Windows.Forms.TextBox
        Me.TextBoxOutput = New System.Windows.Forms.TextBox
        Me.RdEncode = New System.Windows.Forms.RadioButton
        Me.RdDecode = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ButtonGo = New System.Windows.Forms.Button
        Me.ButtonClr = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'TextBoxInput
        '
        Me.TextBoxInput.Location = New System.Drawing.Point(104, 64)
        Me.TextBoxInput.Multiline = True
        Me.TextBoxInput.Name = "TextBoxInput"
        Me.TextBoxInput.Size = New System.Drawing.Size(385, 29)
        Me.TextBoxInput.TabIndex = 0
        '
        'TextBoxOutput
        '
        Me.TextBoxOutput.Location = New System.Drawing.Point(104, 124)
        Me.TextBoxOutput.Multiline = True
        Me.TextBoxOutput.Name = "TextBoxOutput"
        Me.TextBoxOutput.Size = New System.Drawing.Size(385, 111)
        Me.TextBoxOutput.TabIndex = 1
        '
        'RdEncode
        '
        Me.RdEncode.AutoSize = True
        Me.RdEncode.Location = New System.Drawing.Point(104, 41)
        Me.RdEncode.Name = "RdEncode"
        Me.RdEncode.Size = New System.Drawing.Size(62, 17)
        Me.RdEncode.TabIndex = 2
        Me.RdEncode.TabStop = True
        Me.RdEncode.Text = "Encode"
        Me.RdEncode.UseVisualStyleBackColor = True
        '
        'RdDecode
        '
        Me.RdDecode.AutoSize = True
        Me.RdDecode.Location = New System.Drawing.Point(172, 41)
        Me.RdDecode.Name = "RdDecode"
        Me.RdDecode.Size = New System.Drawing.Size(63, 17)
        Me.RdDecode.TabIndex = 3
        Me.RdDecode.TabStop = True
        Me.RdDecode.Text = "Decode"
        Me.RdDecode.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(57, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 20)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "IN"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(39, 165)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "OUT"
        '
        'ButtonGo
        '
        Me.ButtonGo.BackColor = System.Drawing.Color.Transparent
        Me.ButtonGo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonGo.Location = New System.Drawing.Point(414, 250)
        Me.ButtonGo.Name = "ButtonGo"
        Me.ButtonGo.Size = New System.Drawing.Size(75, 23)
        Me.ButtonGo.TabIndex = 6
        Me.ButtonGo.Text = "GO"
        Me.ButtonGo.UseVisualStyleBackColor = False
        '
        'ButtonClr
        '
        Me.ButtonClr.BackColor = System.Drawing.Color.Transparent
        Me.ButtonClr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonClr.Location = New System.Drawing.Point(333, 250)
        Me.ButtonClr.Name = "ButtonClr"
        Me.ButtonClr.Size = New System.Drawing.Size(75, 23)
        Me.ButtonClr.TabIndex = 7
        Me.ButtonClr.Text = "CLR"
        Me.ButtonClr.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 250)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 8
        Me.Button1.Text = "Tes TLS"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FormBase64
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(540, 298)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ButtonClr)
        Me.Controls.Add(Me.ButtonGo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RdDecode)
        Me.Controls.Add(Me.RdEncode)
        Me.Controls.Add(Me.TextBoxOutput)
        Me.Controls.Add(Me.TextBoxInput)
        Me.Name = "FormBase64"
        Me.Text = "FormBase64"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBoxInput As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxOutput As System.Windows.Forms.TextBox
    Friend WithEvents RdEncode As System.Windows.Forms.RadioButton
    Friend WithEvents RdDecode As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ButtonGo As System.Windows.Forms.Button
    Friend WithEvents ButtonClr As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
