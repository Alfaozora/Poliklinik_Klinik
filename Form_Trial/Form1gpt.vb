Public Class Form1gpt

    Private Sub Form1gpt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        NumericUpDownWithThousands1.Value = 1000000
    End Sub

    Private Sub ButtonAmbil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAmbil.Click
        TextBoxHasil.Text = NumericUpDownWithThousands1.Value.ToString("N0")
    End Sub
End Class
