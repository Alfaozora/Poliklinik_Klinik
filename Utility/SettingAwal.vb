Public Class SettingAwal

    Private Sub LoadData()
        'dikunci. Jika nopoli-nya L001 dikosongkan. tidak ditampilkan...
        If ReadSQLNIK("select StrValue from msconfig where configname='NoPoli'") <> "L001" Then txnopoli.Text = ReadSQLNIK("select StrValue from  msconfig where configname='NoPoli'")
        If CheckSQL("select * from msconfig where configname='NamaCompany'") = True Then txnamapoli.Text = ReadSQLNIK("select StrValue from  msconfig where configname='NamaCompany'")
        If CheckSQL("select * from msconfig where configname='AlamatCompany'") = True Then txalamat.Text = ReadSQLNIK("select StrValue from  msconfig where configname='AlamatCompany'")
        If CheckSQL("select * from msconfig where configname='TelpCompany'") = True Then txtelp.Text = ReadSQLNIK("select StrValue from  msconfig where configname='TelpCompany'")
        If CheckSQL("select * from msconfig where configname='PathBarcode'") = True Then txpathbarcode.Text = ReadSQLNIK("select StrValue from  msconfig where configname='PathBarcode'")
        If CheckSQL("select * from msconfig where configname='Pathprf'") = True Then txpathprintfile.Text = ReadSQLNIK("select StrValue from  msconfig where configname='Pathprf'")
        If CheckSQL("select * from msconfig where configname='TDB'") = True Then txdbname.Text = ReadSQLNIK("select StrValue from  msconfig where configname='TDB'")
        If CheckSQL("select * from msconfig where configname='TIP'") = True Then txdbip.Text = ReadSQLNIK("select StrValue from  msconfig where configname='TIP'")
        If CheckSQL("select * from msconfig where configname='Twebdb'") = True Then txnamadbhasillab.Text = ReadSQLNIK("select StrValue from  msconfig where configname='Twebdb'")
        If CheckSQL("select * from msconfig where configname='Twebid'") = True Then txipdbhasillab.Text = ReadSQLNIK("select StrValue from  msconfig where configname='Twebid'")
        If CheckSQL("select * from msconfig where configname='Twebpass'") = True Then txpassworddbhasillab.Text = ReadSQLNIK("select StrValue from msconfig where configname='Twebpass'")
        If CheckSQL("select * from msconfig where configname='DokterPK'") = True Then txdrpk.Text = ReadSQLNIK("select StrValue from  msconfig where configname='DokterPK'")
        If CheckSQL("select * from msconfig where configname='Password'") = True Then txpasssecure.Text = ReadSQLNIK("select StrValue from  msconfig where configname='Password'")
        If CheckSQL("select * from msconfig where configname='PasswordPromo'") = True Then txpasspromo.Text = ReadSQLNIK("select StrValue from  msconfig where configname='PasswordPromo'")

        If CheckSQL("select * from msconfig where configname='KodePoli'") = True Then
            txkodepoli.Text = ReadSQLNIK("select StrValue from  msconfig where configname='KodePoli'")
            txkodepoliid.Text = ReadSQLNIK("select IntValue from  msconfig where configname='KodePoli'")
        End If

        If CheckSQL("select * from msconfig where configname='GudangAsal'") = True Then
            txgudangasal.Text = ReadSQLNIK("select StrValue from  msconfig where configname='GudangAsal'")
            txgudangasalid.Text = ReadSQLNIK("select IntValue from  msconfig where configname='GudangAsal'")
        End If
    End Sub

    Private Sub SetData()
        For Each Titem In Me.Controls
            If TypeOf Titem Is TextBox Then
                Dim tb As TextBox = CType(Titem, TextBox)
                If tb.Name.Contains("empty") = False Then
                    tb.Enabled = True
                    tb.Text = Titem.Tag
                Else
                    tb.Enabled = False
                    tb.Text = ""
                End If
            End If
        Next

        LoadData()

    End Sub

    Function Checking() As Boolean
        For Each Titem In Me.Controls
            If TypeOf Titem Is TextBox Then
                Dim tb As TextBox = CType(Titem, TextBox)
                If tb.Name.Contains("empty") = False Then
                    If tb.Text = "" Then
                        If MsgBox("Setting " & tb.Name & " kosong. Apa tetap dilanjutkan disimpan ?", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then
                            Return False
                        End If
                    End If
                End If
            End If
        Next

        Return True
    End Function

    Private Sub SettingAwal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetData()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Checking() = True Then
            If CheckSQL("select StrValue from msconfig where configname='NoPoli'") = False Then WriteSQL("insert into MsConfig(ConfigName,ConfigType,StrValue,CreateDate,CreateBy,UnDelete) values('NoPoli','StrValue','" & txnopoli.Text & "',getdate(),'" & PoliKlinik.Lbluser.Text & "',1)", 4)
            If ReadSQLNIK("select StrValue from msconfig where configname='NoPoli'") <> "L001" Then WriteSQL("update msconfig  set StrValue='" & txnopoli.Text & "'  where configname='NoPoli'", 4) Else WriteSQL("delete msconfig  where configname='NoPoli'", 4)
            If CheckSQL("select * from msconfig where configname='NamaCompany'") = True Then WriteSQL("update msconfig  set StrValue='" & txnamapoli.Text & "'  where configname='NamaCompany'", 4) Else WriteSQL("insert into msconfig(ConfigName,ConfigType,StrValue,UnDelete,CreateDate,CreateBy) values('NamaCompany','StrValue','" & txnamapoli.Text & "',1,getdate(),'" & PoliKlinik.Lbluser.Text & "')", 4)
            If CheckSQL("select * from msconfig where configname='AlamatCompany'") = True Then WriteSQL("update msconfig  set StrValue='" & txalamat.Text & "'  where configname='AlamatCompany'", 4) Else WriteSQL("insert into msconfig(ConfigName,ConfigType,StrValue,UnDelete,CreateDate,CreateBy) values('AlamatCompany','StrValue','" & txalamat.Text & "',1,getdate(),'" & PoliKlinik.Lbluser.Text & "')", 4)
            If CheckSQL("select * from msconfig where configname='TelpCompany'") = True Then WriteSQL("update msconfig  set StrValue='" & txtelp.Text & "'  where configname='TelpCompany'", 4) Else WriteSQL("insert into msconfig(ConfigName,ConfigType,StrValue,UnDelete,CreateDate,CreateBy) values('TelpCompany','StrValue','" & txtelp.Text & "',1,getdate(),'" & PoliKlinik.Lbluser.Text & "')", 4)
            If CheckSQL("select * from msconfig where configname='KodePoli'") = True Then WriteSQL("update msconfig  set StrValue='" & txkodepoli.Text & "'  , IntValue='" & txkodepoliid.Text & "'   where configname='KodePoli'", 4) Else WriteSQL("insert into msconfig(ConfigName,ConfigType,StrValue,IntValue,UnDelete,CreateDate,CreateBy) values('KodePoli','StrValue','" & txkodepoli.Text & "','" & txkodepoliid.Text & "',1,getdate(),'" & PoliKlinik.Lbluser.Text & "')", 4)
            If CheckSQL("select * from msconfig where configname='GudangAsal'") = True Then WriteSQL("update msconfig  set StrValue='" & txgudangasal.Text & "' , IntValue='" & txgudangasalid.Text & "' where configname='GudangAsal'", 4) Else WriteSQL("insert into msconfig(ConfigName,ConfigType,StrValue,IntValue,UnDelete,CreateDate,CreateBy) values('GudangAsal','StrValue','" & txgudangasal.Text & "','" & txgudangasalid.Text & "',1,getdate(),'" & PoliKlinik.Lbluser.Text & "')", 4)
            If CheckSQL("select * from msconfig where configname='PathBarcode'") = True Then WriteSQL("update msconfig  set StrValue='" & txpathbarcode.Text & "'  where configname='PathBarcode'", 4) Else WriteSQL("insert into msconfig(ConfigName,ConfigType,StrValue,UnDelete,CreateDate,CreateBy) values('PathBarcode','StrValue','" & txpathbarcode.Text & "',1,getdate(),'" & PoliKlinik.Lbluser.Text & "')", 4)
            If CheckSQL("select * from msconfig where configname='Pathprf'") = True Then WriteSQL("update msconfig  set StrValue='" & txpathprintfile.Text & "'  where configname='Pathprf'", 4) Else WriteSQL("insert into msconfig(ConfigName,ConfigType,StrValue,UnDelete,CreateDate,CreateBy) values('Pathprf','StrValue','" & txpathprintfile.Text & "',1,getdate(),'" & PoliKlinik.Lbluser.Text & "')", 4)
            If CheckSQL("select * from msconfig where configname='TDB'") = True Then WriteSQL("update msconfig  set StrValue='" & txdbname.Text & "'  where configname='TDB'", 4) Else WriteSQL("insert into msconfig(ConfigName,ConfigType,StrValue,UnDelete,CreateDate,CreateBy) values('TDB','StrValue','" & txdbip.Text & "',1,getdate(),'" & PoliKlinik.Lbluser.Text & "')", 4)
            If CheckSQL("select * from msconfig where configname='TIP'") = True Then WriteSQL("update msconfig  set StrValue='" & txdbip.Text & "'  where configname='TIP'", 4) Else WriteSQL("insert into msconfig(ConfigName,ConfigType,StrValue,UnDelete,CreateDate,CreateBy) values('TIP','StrValue','" & txdbip.Text & "',1,getdate(),'" & PoliKlinik.Lbluser.Text & "')", 4)
            If CheckSQL("select * from msconfig where configname='Twebdb'") = True Then WriteSQL("update msconfig  set StrValue='" & txnamadbhasillab.Text & "'  where configname='Twebdb'", 4) Else WriteSQL("insert into msconfig(ConfigName,ConfigType,StrValue,UnDelete,CreateDate,CreateBy) values('Twebdb','StrValue','" & txnamadbhasillab.Text & "',1,getdate(),'" & PoliKlinik.Lbluser.Text & "')", 4)
            If CheckSQL("select * from msconfig where configname='Twebid'") = True Then WriteSQL("update msconfig  set StrValue='" & txipdbhasillab.Text & "'  where configname='Twebid'", 4) Else WriteSQL("insert into msconfig(ConfigName,ConfigType,StrValue,UnDelete,CreateDate,CreateBy) values('Twebid','StrValue','" & txipdbhasillab.Text & "',1,getdate(),'" & PoliKlinik.Lbluser.Text & "')", 4)
            If CheckSQL("select * from msconfig where configname='Twebpass'") = True Then WriteSQL("update msconfig  set StrValue='" & txpassworddbhasillab.Text & "'  where configname='Twebpass'", 4) Else WriteSQL("insert into msconfig(ConfigName,ConfigType,StrValue,UnDelete,CreateDate,CreateBy) values('Twebpass','StrValue','" & txpassworddbhasillab.Text & "',1,getdate(),'" & PoliKlinik.Lbluser.Text & "')", 4)
            If CheckSQL("select * from msconfig where configname='DokterPK'") = True Then WriteSQL("update msconfig  set StrValue='" & txdrpk.Text & "'  where configname='DokterPK'", 4) Else WriteSQL("insert into msconfig(ConfigName,ConfigType,StrValue,UnDelete,CreateDate,CreateBy) values('DokterPK','StrValue','" & txdrpk.Text & "',1,getdate(),'" & PoliKlinik.Lbluser.Text & "')", 4)
            If CheckSQL("select * from msconfig where configname='Password'") = True Then WriteSQL("update msconfig  set StrValue='" & txpasssecure.Text & "'  where configname='Password'", 4) Else WriteSQL("insert into msconfig(ConfigName,ConfigType,StrValue,UnDelete,CreateDate,CreateBy) values('Password','StrValue','" & txpasssecure.Text & "',1,getdate(),'" & PoliKlinik.Lbluser.Text & "')", 4)
            If CheckSQL("select * from msconfig where configname='PasswordPromo'") = True Then WriteSQL("update msconfig  set StrValue='" & txpasspromo.Text & "'  where configname='PasswordPromo'", 4) Else WriteSQL("insert into msconfig(ConfigName,ConfigType,StrValue,UnDelete,CreateDate,CreateBy) values('PasswordPromo','StrValue','" & txpasspromo.Text & "',1,getdate(),'" & PoliKlinik.Lbluser.Text & "')", 4)
            MsgBox("Setting Saved")
        End If
    End Sub

    Private Sub DellAll()
        WriteSQL("delete from PrintLog ", 4)
        WriteSQL("delete from StockLabIn", 4)
        WriteSQL("delete from StockLabOut ", 4)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If MsgBox("Yakin untuk men-delete seluruh transaction sehingga menjadi kosong ? ", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
            Dim Tinput As String = InputBox("Masukkan password :", "Password Reset", "")
            If CheckSQL("select * from msconfig where ConfigName='Password' and StrValue='" & Tinput.ToString & "'") Then
                DellAll()
            Else
                MsgBox("Password yang anda masukkan salah. Silahkan ulangi.")
            End If
        End If
    End Sub
End Class