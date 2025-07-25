Public Class DownloadHasil
    Private DB_Poliklinik As TLcon

    Private Sub SetClear()
        dtchanged.Value = DateAndTime.Now

        ' Set Parameter Server Online
        Dim serverOnline_IP As String = Utility.GetConfig("ServerOnline_IP")
        Dim serverOnline_UserID As String = Utility.GetConfig("ServerOnline_UserID")
        Dim serverOnline_Password As String = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerOnline_Password"), "albert")

        ' Set DB Poliklinik
        DB_Poliklinik.Tip = serverOnline_IP
        DB_Poliklinik.Tid = serverOnline_UserID
        DB_Poliklinik.Tpass = serverOnline_Password
        DB_Poliklinik.Tdb = Utility.GetConfig("ServerOnlinePoli_DB")
    End Sub

    Private Sub SetRefresh()
        Dim Takhir As Date = DateSerial(DateAndTime.Now.Year, DateAndTime.Now.Month, DateAndTime.Now.Day)
        Dim Tawal As Date = DateAdd(DateInterval.Day, -120, Takhir.Date)


        Dim tkode As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='KodePoli'")
        Dim Tok As DataTable = ReadThemysql("SELECT * FROM transaksilab WHERE acc=1 and idtempatlab='" & tkode & "' and tgllab between '" & Format(Tawal.Date, "yyyyMMdd") & "' and '" & Format(Takhir.Date, "yyyyMMdd") & "'", DB_Poliklinik)
        Dim Thasil As String = ""
        For Each Trow As DataRow In Tok.Rows
            Thasil = Thasil + "'" & Trow("translabid") & "',"
        Next

        If Thasil = "" Then
            Thasil = "(0)"
        Else
            Thasil = "(" & Strings.Left(Thasil, Thasil.Length - 1) & ")"
        End If

        Dim Tbls As DataTable = ReadSQL("SELECT a.TransLabID,a.NoUrut,a.IDInternet,b.Nama,a.DokterLab,CONVERT(VARCHAR(11),a.TglLab,106) as TglLab " & _
                                        "FROM TransaksiLab a " & _
                                        "LEFT JOIN MasterPasien b on a.IDInternet = b.NoRekamMedis " & _
                                        "WHERE LTRIM(RTRIM(a.[Status])) = 'SEND' and a.TransLabID in " & Thasil)
        insertRowToTbls(Tbls, "typchecked", "Checked")
        For Each Tcol As DataColumn In Tbls.Columns
            Tcol.ReadOnly = True
        Next
        Tbls.Columns("Checked").ReadOnly = False

        gridlab.DataSource = Tbls
        GridView3.Columns("TransLabID").Visible = False

    End Sub

    Private Sub RefreshToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RefreshToolStripMenuItem.Click
        SetRefresh()
    End Sub

    Private Sub DownloadHasil_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'PoliKlinik.LoadConnection2()
        SetClear()
        RefreshToolStripMenuItem.PerformClick()
    End Sub

    Private Sub cmddownload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmddownload.Click
        If MsgBox("Yakin Download Hasil ini ?", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
            Dim Tbls As DataTable = gridlab.DataSource
            Tbls.AcceptChanges()


            Dim Trow() As DataRow = Tbls.Select("[Checked] = True")
            Dim tkode As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='KodePoli'")

            Try
                For i As Integer = 0 To Trow.Length - 1
                    Dim Ttempdata As DataTable = ReadThemysql("SELECT * FROM transaksilab WHERE idtempatlab='" & tkode & "' and nourut='" & Trow(i)("nourut").ToString & "' and AccClosed<>'' ", DB_Poliklinik)
                    If Ttempdata.Rows.Count > 0 Then
                        Dim Rtempdata As DataRow = Ttempdata.Rows(0)
                        Dim Ttemp As DataTable = ReadThemysql("SELECT * FROM transaksilabresult WHERE idlabinternet in ( SELECT idlabinternet FROM  transaksilab  WHERE idtempatlab='" & tkode & "' and translabid='" & Rtempdata("TransLabID").ToString & "')  and Acc1 is not null and Acc2 is not null and Acc3<>''", DB_Poliklinik)
                        For Each Tdata As DataRow In Ttemp.Rows
                            WriteSQL("update transaksilabresult set Acc3='" & Tdata("Acc3").ToString & "' , result='" & Tdata("result").ToString & "' , Pria='" & Tdata("pria").ToString & "' , Wanita='" & Tdata("wanita").ToString & "'  , Satuan='" & Tdata("satuan").ToString & "'  WHERE TransLabIDDetail='" & Tdata("translabiddetail") & "' and TindakanID='" & Tdata("tindakanid") & "' and GroupID='" & Tdata("groupid") & "' and  NoUrut='" & Tdata("nourut") & "'", 4)
                        Next
                        WriteSQL("update TransaksiLab set [status]='CETAK' , LabEndTime=getdate() WHERE TransLabID='" & Trow(i)("TransLabID").ToString & "'", 4)
                        WriteThemysql("update transaksilab set acc=1 WHERE idtempatlab='" & tkode & "' and translabid='" & Trow(i)("TransLabID").ToString & "'", DB_Poliklinik)
                    End If
                Next
                MsgBox("Done")
                RefreshToolStripMenuItem.PerformClick()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If

    End Sub
End Class