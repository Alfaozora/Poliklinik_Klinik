<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1gpt
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.LabelRp = New System.Windows.Forms.Label
        Me.TextBoxHasil = New System.Windows.Forms.TextBox
        Me.ButtonAmbil = New System.Windows.Forms.Button
        Me.NumericUpDownWithThousands2 = New PoliKlinik_Net2.NumericUpDownWithThousands
        Me.NumericUpDownWithThousands1 = New PoliKlinik_Net2.NumericUpDownWithThousands
        CType(Me.NumericUpDownWithThousands2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownWithThousands1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelRp
        '
        Me.LabelRp.AutoSize = True
        Me.LabelRp.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.LabelRp.Location = New System.Drawing.Point(30, 30)
        Me.LabelRp.Name = "LabelRp"
        Me.LabelRp.Size = New System.Drawing.Size(30, 20)
        Me.LabelRp.TabIndex = 0
        Me.LabelRp.Text = "Rp"
        '
        'TextBoxHasil
        '
        Me.TextBoxHasil.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.TextBoxHasil.Location = New System.Drawing.Point(34, 164)
        Me.TextBoxHasil.Name = "TextBoxHasil"
        Me.TextBoxHasil.ReadOnly = True
        Me.TextBoxHasil.Size = New System.Drawing.Size(196, 26)
        Me.TextBoxHasil.TabIndex = 2
        '
        'ButtonAmbil
        '
        Me.ButtonAmbil.Location = New System.Drawing.Point(34, 204)
        Me.ButtonAmbil.Name = "ButtonAmbil"
        Me.ButtonAmbil.Size = New System.Drawing.Size(196, 30)
        Me.ButtonAmbil.TabIndex = 3
        Me.ButtonAmbil.Text = "Ambil Nilai"
        Me.ButtonAmbil.UseVisualStyleBackColor = True
        '
        'NumericUpDownWithThousands2
        '
        Me.NumericUpDownWithThousands2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.NumericUpDownWithThousands2.Location = New System.Drawing.Point(70, 86)
        Me.NumericUpDownWithThousands2.Maximum = New Decimal(New Integer() {1000000000, 0, 0, 0})
        Me.NumericUpDownWithThousands2.Name = "NumericUpDownWithThousands2"
        Me.NumericUpDownWithThousands2.Size = New System.Drawing.Size(160, 26)
        Me.NumericUpDownWithThousands2.TabIndex = 4
        '
        'NumericUpDownWithThousands1
        '
        Me.NumericUpDownWithThousands1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.NumericUpDownWithThousands1.Location = New System.Drawing.Point(70, 28)
        Me.NumericUpDownWithThousands1.Maximum = New Decimal(New Integer() {1000000000, 0, 0, 0})
        Me.NumericUpDownWithThousands1.Name = "NumericUpDownWithThousands1"
        Me.NumericUpDownWithThousands1.Size = New System.Drawing.Size(160, 26)
        Me.NumericUpDownWithThousands1.TabIndex = 1
        '
        'Form1gpt
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 265)
        Me.Controls.Add(Me.NumericUpDownWithThousands2)
        Me.Controls.Add(Me.ButtonAmbil)
        Me.Controls.Add(Me.TextBoxHasil)
        Me.Controls.Add(Me.NumericUpDownWithThousands1)
        Me.Controls.Add(Me.LabelRp)
        Me.Name = "Form1gpt"
        Me.Text = "Contoh NumericUpDown"
        CType(Me.NumericUpDownWithThousands2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownWithThousands1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabelRp As System.Windows.Forms.Label
    Friend WithEvents NumericUpDownWithThousands1 As NumericUpDownWithThousands
    Friend WithEvents TextBoxHasil As System.Windows.Forms.TextBox
    Friend WithEvents ButtonAmbil As System.Windows.Forms.Button
    Friend WithEvents NumericUpDownWithThousands2 As PoliKlinik_Net2.NumericUpDownWithThousands

End Class
