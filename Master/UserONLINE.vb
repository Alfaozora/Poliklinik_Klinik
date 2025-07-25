Imports System.Drawing
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports KASLibrary


Public Class UserONLINE
    Private Find_Poliklinik As Find.TLconnect
    Private DB_Poliklinik As TLcon

    Private Sub SetConnection()
        ' Set Parameter Server Online
        Dim serverOnline_IP As String = Utility.GetConfig("ServerOnline_IP")
        Dim serverOnline_UserID As String = Utility.GetConfig("ServerOnline_UserID")
        Dim serverOnline_Password As String = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerOnline_Password"), "albert")

        ' Set Find Poliklinik
        Find_Poliklinik.Tip = serverOnline_IP
        Find_Poliklinik.Tid = serverOnline_UserID
        Find_Poliklinik.Tpass = serverOnline_Password
        Find_Poliklinik.Tdb = Utility.GetConfig("ServerOnlinePoli_DB")

        ' Set DB Poliklinik
        DB_Poliklinik.Tip = serverOnline_IP
        DB_Poliklinik.Tid = serverOnline_UserID
        DB_Poliklinik.Tpass = serverOnline_Password
        DB_Poliklinik.Tdb = Utility.GetConfig("ServerOnlinePoli_DB")
    End Sub

    Private Sub SetClear()
        cmbjenisuser.SelectedIndex = -1
        txid.ResetText()
        txusernama.ResetText()
        txuserpassword.ResetText()
        txbridging.ResetText()
        id.ResetText()
    End Sub

    Private Sub ClearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearToolStripMenuItem.Click
        SetClear()
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Function Checking() As Boolean
        If txusernama.Text = "" Or txid.Text = "" Then
            MsgBox("Nama user atau username tidak boleh kosong.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        If txuserpassword.Text = "" Then
            MsgBox("Password tidak boleh kosong.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        If cmbjenisuser.SelectedIndex = -1 Then
            MsgBox("Pilih jenis user terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        Return True
    End Function

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        If Checking() = True Then
            If id.Text <> "" Then
                'update 
                If MsgBox("User telah ada. Apakah di-update ?", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                    WriteThemysql("update users set password=MD5('" & txuserpassword.Text & "') , username='" & txid.Text & "', name='" & txusernama.Text & "', bridginguser='" & txbridging.Text & "', jenis='" & cmbjenisuser.Text & "' where userid='" & id.Text & "'", DB_Poliklinik)
                    MsgBox("Data Saved.", MsgBoxStyle.Information, "Success")

                    SetClear()
                Else
                    MsgBox("Abort Updated")
                End If
            Else
                'new
                WriteThemysql("insert into users(name,username,password,jenis,bridginguser) values('" & txusernama.Text & "','" & txid.Text & "',MD5('" & txuserpassword.Text & "'),'" & cmbjenisuser.Text & "', '" & txbridging.Text & "')", DB_Poliklinik)
                MsgBox("Data Saved.", MsgBoxStyle.Information, "Success")

                SetClear()
            End If

        End If
    End Sub

    Private Sub UserONLINE_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetConnection()
        SetClear()
    End Sub

    Private Sub butfinduser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butfinduser.Click
        Find.Show()
        Find.QueryTheMysql("SELECT * FROM users ", " order by company,name ", "useronline", 2, Find_Poliklinik)
    End Sub

    Public Sub LoadData(ByVal Trow As DataRowView)
        txid.Text = Trow("username").ToString
        id.Text = Trow("userid").ToString
        'Dim Ttemp As DataTable = ReadThemysql("select * from mastercompany where nocompany='" & Trow("Company").ToString.Trim & "'", Ttcon)
        'Dim Rtemp As DataRow = Ttemp.Rows(0)
        'txcompid.Text = Rtemp("nocompany").ToString.Trim
        'txcomp.Text = Rtemp("companynama").ToString.Trim
        txusernama.Text = Trow("name")
        If IsDBNull(Trow("bridginguser")) = True Then txbridging.Text = "" Else txbridging.Text = Trow("bridginguser")
        'txuserpassword.Text = Trow("password")
        cmbjenisuser.Text = Trow("jenis").ToString
    End Sub

    Public Sub DeleteUser(ByVal Trow As DataRowView)
        If MsgBox("Yakin men-delete user : " & Trow("").ToString & " ? ", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
            WriteThemysql("delete from users where userid='" & Trow("userid").ToString & "' and name='" & Trow("username").ToString & "' and company='" & Trow("company").ToString.Trim & "'", DB_Poliklinik)
            MsgBox("Data Deleted")
        Else
            MsgBox("Canceled Deleted")
        End If
    End Sub
End Class