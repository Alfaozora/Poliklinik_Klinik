Public Class DownloadKPA

    Dim Ttcon As TLcon
    Dim Ttempat As String
    Dim Tppk As String

    Private Sub SetClearKPA()
        dtnow.Value = DateAndTime.Now
        Ttcon.Tid = "root"
        Ttcon.Tip = ReadSQLNIK("select StrValue from MsConfig where ConfigName='Twebidhardlent'")
        Ttcon.Tdb = ReadSQLNIK("select StrValue from MsConfig where ConfigName='Twebdbhardlent'")
        Ttcon.Tpass = "Csj03iB"
        Ttempat = ReadSQLNIK("select StrValue from MsConfig where ConfigName='Kota'")
        Tppk = ReadSQLNIK("select StrValue from MsConfig where ConfigName='PPKID'")
    End Sub

    Private Sub DownloadKPA()
        Dim Tbls As DataTable = ReadThemysql("select a.NPP as NPPID,b.Nama as NPPNama,a.Nomor,a.Begda,a.Endda,a.Tipe,a.Nama,a.`Status`,a.TglLahir,a.Sex,a.Umum,a.Gigi from KPA a left join NPP b on a.NPP=b.Kode and '" & Format(dtnow.Value, "yyyyMMdd") & "' between b.Begda and b.Endda where a.NPP in (SELECT Kode FROM NPP where kota in ('" & Ttempat & "') AND '" & Format(dtnow.Value, "yyyyMMdd") & "' BETWEEN Begda and Endda) and '" & Format(dtnow.Value, "yyyyMMdd") & "' between a.Begda and a.Endda and b.kode='02200054'", Ttcon)
        If Tbls.Rows.Count <= 0 Then
            MsgBox("Check Master KPA di Pusat Cahaya. Tidak ada data KPA yang aktif.")
        Else
            WriteSQL("update TransKPA set aktif=0,Endda='" & Format(DateAdd(DateInterval.Day, -1, DateAndTime.Now), "MM/dd/yyyy") & "' where aktif=1", 4)
            For Each Trow As DataRow In Tbls.Rows
                If CheckSQL("select * from TransKPA where NPPID='" & Trow("NPPID").ToString & "' and Nomor='" & Trow("Nomor").ToString & "' and Tipe='" & Trow("Tipe").ToString & "' ") = True Then
                    WriteSQL("update TransKPA set Begda='" & Format(Trow("Begda"), "MM/dd/yyyy") & "' , Endda='" & Format(Trow("Endda"), "MM/dd/yyyy") & "' , Nama='" & Trow("Nama").ToString & "' , [Status]='" & Trow("Status").ToString & "' , Tgllhr='" & Format(Trow("Tgllahir"), "MM/dd/yyyy") & "' , Sex='" & Trow("Sex").ToString & "' , Umum='" & Trow("Umum").ToString & "' , Gigi='" & Trow("Gigi").ToString & "' , aktif=1 where NPPID='" & Trow("NPPID").ToString & "' and Nomor='" & Trow("Nomor").ToString & "' and Tipe='" & Trow("Tipe").ToString & "' ", 4)
                Else
                    WriteSQL("insert into TransKPA values('" & Trow("NPPID").ToString & "','" & Trow("NPPNama").ToString & "','" & Trow("Nomor").ToString & "','" & Trow("Tipe").ToString & "','" & Format(Trow("Begda"), "MM/dd/yyyy") & "','" & Format(Trow("Endda"), "MM/dd/yyyy") & "','" & Trow("Nama").ToString & "','" & Trow("Status").ToString & "','" & Format(Trow("TglLahir"), "MM/dd/yyyy") & "','" & Trow("Sex").ToString & "','" & Trow("Umum").ToString & "','" & Trow("Gigi").ToString & "',1)", 4)
                End If
            Next
            MsgBox("Data Saved")
        End If


    End Sub


    Private Sub butdownloadkpa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butdownloadkpa.Click
        If chkkpa.CheckState = CheckState.Checked Then
            SetClearKPA()
            DownloadKPA()
        End If
    End Sub
End Class