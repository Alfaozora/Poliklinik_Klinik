Public Class Form5

    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tbls As DataTable = ReadSQL("SELECT * FROM Klinik_MasterPrognosa")

        LookUpEdit1.Properties.DataSource = tbls
    End Sub
End Class