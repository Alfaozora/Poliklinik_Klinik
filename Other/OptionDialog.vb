Imports System.Windows.Forms

Public Class OptionDialog

    Dim Ttcon As TLcon
    Dim TtOL As TLcon
    Dim TtconU As TLcon

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public Sub LoadOptionDialog(ByRef TxID As String, ByRef Tdiff As Integer, ByRef Tjenis As String)
        txTranslab.Text = TxID
        txJenis.Text = Tjenis
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txTranslab.Text <> "" Then
        Select txJenis.Text
                Case "ResendToMesin"
                    LabAdmin.ResendMesin(txTranslab.Text, 3)
                    Me.Close()
                Case "DownloadHasil"
                    Dim Tnourut As String = ReadSQLNIK("select NoUrut from TransaksiLab where TranslabID='" & txTranslab.Text & "'")
                    ResultMachine.LoadAdminLab(txTranslab.Text, Tnourut, "Diff3", "Offline", "")
                    ResultMachine.ShowDialog()
                    Me.Close()
                Case Else : MsgBox("Error...")
            End Select
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If txTranslab.Text <> "" Then
            Select Case txJenis.Text
                Case "ResendToMesin"
                    LabAdmin.ResendMesin(txTranslab.Text, 5)
                Case "DownloadHasil"
                    Dim Tnourut As String = ReadSQLNIK("select NoUrut from TransaksiLab where TranslabID='" & txTranslab.Text & "'")
                    ResultMachine.LoadAdminLab(txTranslab.Text, Tnourut, "Diff5", "Offline", "")
                    ResultMachine.ShowDialog()
                    Me.Close()
                Case Else : MsgBox("Error...")
            End Select
        End If
    End Sub
End Class
