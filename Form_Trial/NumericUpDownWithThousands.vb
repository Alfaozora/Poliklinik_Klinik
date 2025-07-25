Public Class NumericUpDownWithThousands
    Inherits NumericUpDown

    Protected Overrides Sub UpdateEditText()
        Me.Text = Me.Value.ToString("N0")
    End Sub
End Class
