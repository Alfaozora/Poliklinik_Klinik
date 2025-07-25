Imports System
Imports System.IO
Imports System.Drawing
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports KASLibrary

Public NotInheritable Class PatchUpdate
    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

    Private Sub PatchUpdate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ApplicationTitle As String
        If My.Application.Info.Title <> "" Then
            ApplicationTitle = My.Application.Info.Title
        Else
            ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If
        Me.Text = String.Format("About {0}", "Mitra Medicare")

        setTextUpdateVersion()
    End Sub

    Private Sub setTextUpdateVersion()
        Dim descVersion As String = ""
        Dim version As String = ""

        Using sr As New StreamReader(Application.StartupPath & "\updatelog.txt")
            descVersion = sr.ReadToEnd()
            sr.Dispose()
        End Using

        Using sr As New StreamReader(Application.StartupPath & "\updatelog.txt")
            version = sr.ReadLine()
            sr.Dispose()
        End Using

        LabelVersion.Text = version.ToUpper
        TextBoxDescription.Text = descVersion
    End Sub
End Class
