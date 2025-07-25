Public Class ChangePassword

    Private Sub SetData(ByRef Txid As String)
        txusername.Text = Txid
        txpasswordlama.ResetText()
        txpasswordbaru.ResetText()
        txpasswordbaruulang.ResetText()
    End Sub

    Private Sub ChangePassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        SetData(PoliKlinik.Lbluser.Text)
    End Sub

    Function Checking() As Boolean

        If txpasswordlama.Text <> "" Then
            If CheckSQL("select * from users where userid='" & txusername.Text & "' and pwdcompare('" & txpasswordlama.Text & "',[userpassword])=1") = False Then
                MsgBox("Password lama tidak sesuai. Mohon diketik ulang.")
                txpasswordlama.ResetText()
                txpasswordlama.Focus()
                Return False
            End If
        End If

        If txpasswordbaru.Text <> txpasswordbaruulang.Text Then
            MsgBox("Password baru dan Password ulangan tidak sama. Input lagi.")
            txpasswordbaru.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If txusername.Text <> "" Then
            If Checking = True Then
                WriteSQL("update users set [UserPassword]=PWDENCRYPT('" & txpasswordbaru.Text & "') where userid='" & txusername.Text & "'", 2)
                Me.Close()
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim passwd As String = KASLibrary.Utility.EncryptTripleDES(TextBox1.Text, "albert")
        TextBox2.Text = passwd
    End Sub
End Class