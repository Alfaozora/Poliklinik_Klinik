Public Class RepairDetailTindakan

    Private Sub butaddpasien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butaddpasien.Click
        If cmbtindakan.Text <> "" Then
            Dim Thasil As Date = DateAndTime.Now.AddDays(10)
            Dim Takhir As Date = DateSerial(Thasil.Year, Thasil.Month, Thasil.Day)
            Dim Tawal As Date = DateAdd(DateInterval.Day, -200, Takhir.Date)

            FindMultiple.Show()
            Select Case cmbtindakan.Text.ToUpper
                Case "LAB"
                    FindMultiple.Query("SELECT a.NoUrut,a.TransLabID as ID,a.IDInternet as IDPasien,b.Nama,a.TglLab as Tgl " & _
                                       "FROM TransaksiLab a " & _
                                       "LEFT JOIN MasterPasien b on a.IDInternet = b.NoRekamMedis " & _
                                       "WHERE ( a.Status='CHECK' or a.Status='CHECK2' or a.Status='CETAK' or a.Status='CLOSED' or a.Status='TAKEIT') and CONVERT(date, a.Tgllab) between '" & Format(Tawal.Date, "MM/dd/yyyy") & "' and '" & Format(Takhir.Date, "MM/dd/yyyy") & "'  and a.deleted<>1 and LabStartTime is not null", " order by a.TransLabID desc,a.TglLab,b.Nama", "FindInputRepair", 0)

                Case "POLI"

                Case "GIGI"


            End Select
        Else
            MsgBox("Pilih Jenis Tindakan yang mau dicheck ( LAB / POLI / GIGI ).")
            cmbtindakan.Focus()
        End If
    End Sub

    Public Sub AddPasien(ByRef Trow() As DataRow)
        Dim Ttbls As DataTable = GridControl1.DataSource
        Ttbls.AcceptChanges()

        For i As Integer = 0 To Trow.Length - 1
            Dim Tdouble() As DataRow = Ttbls.Select("NoUrut='" & Trow(i)("NoUrut") & "'")
            If Tdouble.Length = 0 Then
                Dim Tnew As DataRow = Ttbls.NewRow
                Tnew("NoUrut") = Trow(i)("NoUrut")
                Tnew("ID") = Trow(i)("ID")
                Tnew("IDPasien") = Trow(i)("IDPasien")
                Tnew("Nama") = Trow(i)("Nama")
                Ttbls.Rows.Add(Tnew)
            End If
        Next

        GridControl1.DataSource = Ttbls

    End Sub

    Private Sub SetGrid()
        Dim Tbls As DataTable = ReadSQL("SELECT a.NoUrut,a.TransLabID as ID,a.IDInternet as IDPasien,b.Nama " & _
                                        "FROM TransaksiLab a " & _
                                        "LEFT JOIN MasterPasien b on a.IDInternet = b.NoRekamMedis " & _
                                        "WHERE NoUrut = ''")
        GridControl1.DataSource = Tbls
    End Sub

    Private Sub SetClear()
        SetGrid()
    End Sub


    Private Sub RepairDetailTindakan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetClear()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If rd1.Checked = True Then
            If cmbtindakan.Text <> "LAB" Then
                MsgBox("Perbaikan ini hanya khusus untuk LAB. Pilih lainnya yang sesuai")
                Exit Sub
            End If

            Dim Tbls As DataTable = GridControl1.DataSource

            For Each Tpasien As DataRow In Tbls.Rows
                Dim Ttemp As DataTable = ReadSQL("SELECT * FROM TransaksiLabDetail WHERE TransLabID='" & Tpasien("ID").ToString & "'")
                For Each Trow As DataRow In Ttemp.Rows
                    Dim Tdetail As DataTable = ReadSQL("SELECT * FROM MasterLabDetail WHERE TindakanID='" & Trow("TindakanID").ToString & "' and deleted=0 ")
                    For Each Rdetail As DataRow In Tdetail.Rows
                        If CheckSQL("SELECT * FROM TransaksiLabResult WHERE TransLabIDDetail='" & Trow("TranslabIDDetail") & "' and TindakanID='" & Rdetail("TindakanID") & "' and GroupID='" & Rdetail("GroupID") & "' and NoUrut='" & Rdetail("NoUrut") & "' and DetailKet='" & Rdetail("DetailKet") & "'") = True Then
                            'edited
                            'menu untuk hanya insert tindakan yang belum. update di yg kedua
                            'WriteSQL("update TransaksiLabResult set Pria='" & Rdetail("Pria") & "' ,Wanita='" & Rdetail("Wanita") & "',Satuan='" & Rdetail("DisplayHasil") & "' WHERE TransLabIDDetail='" & Trow("TranslabIDDetail") & "' and TindakanID='" & Rdetail("TindakanID") & "' and GroupID='" & Rdetail("GroupID") & "' and NoUrut='" & Rdetail("NoUrut") & "' and DetailKet='" & Rdetail("DetailKet") & "' ", 4)
                        Else
                            'add new 
                            WriteSQL("insert into TransaksiLabResult(TransLabIDDetail,TindakanID,GroupID,NoUrut,DetailKet,Pria,Wanita,Result,Keterangan,Satuan) " & _
                                     " values('" & Trow("TranslabIDDetail") & "','" & Rdetail("TindakanID") & "','" & Rdetail("GroupID") & "','" & Rdetail("NoUrut") & "','" & Rdetail("DetailKet") & "','" & Rdetail("Pria") & "','" & Rdetail("Wanita") & "','','" & Rdetail("KeteranganHasil") & "','" & Rdetail("DisplayHasil") & "') ", 4)
                        End If
                    Next
                Next
            Next
            MsgBox("Data Updated")
        End If

        If rd2.Checked = True Then
            Dim Tbls As DataTable = GridControl1.DataSource

            For Each Tpasien As DataRow In Tbls.Rows
                Dim Ttemp As DataTable = ReadSQL("SELECT * FROM TransaksiLabDetail WHERE TransLabID='" & Tpasien("ID").ToString & "'")
                For Each Trow As DataRow In Ttemp.Rows
                    Dim Tdetail As DataTable = ReadSQL("SELECT * FROM MasterLabDetail WHERE TindakanID='" & Trow("TindakanID").ToString & "' and deleted=0 ")
                    For Each Rdetail As DataRow In Tdetail.Rows
                        If CheckSQL("SELECT * FROM TransaksiLabResult WHERE TransLabIDDetail='" & Trow("TranslabIDDetail") & "' and TindakanID='" & Rdetail("TindakanID") & "' and GroupID='" & Rdetail("GroupID") & "' and NoUrut='" & Rdetail("NoUrut") & "' and DetailKet='" & Rdetail("DetailKet") & "'") = True Then
                            'edited
                            WriteSQL("update TransaksiLabResult set Pria='" & Rdetail("Pria") & "' ,Wanita='" & Rdetail("Wanita") & "',Satuan='" & Rdetail("DisplayHasil") & "' WHERE TransLabIDDetail='" & Trow("TranslabIDDetail") & "' and TindakanID='" & Rdetail("TindakanID") & "' and GroupID='" & Rdetail("GroupID") & "' and NoUrut='" & Rdetail("NoUrut") & "' and DetailKet='" & Rdetail("DetailKet") & "' ", 4)
                        End If
                    Next
                Next
            Next
            MsgBox("Data Updated")
        End If

        If rd3.Checked = True Then
            If MsgBox("Yakin mendelete All Transaksi LAB per tanggal : " & Format(dtdelete.Value, "dd-MMM-yyyy") & " ?", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                DeleteTransLab()
            Else
                MsgBox("Cancel Delete.")
            End If
        End If

    End Sub

    Private Sub DeleteTransLab()
        WriteSQL("delete FROM TransaksiLabResult WHERE TransLabIDDetail in (SELECT TransLabIDDetail FROM TransaksiLabDetail WHERE TransLabID in (SELECT TransLabID FROM transaksilab WHERE CONVERT(date, Tgllab)='" & Format(dtdelete.Value, "MM/dd/yyyy") & "'))", 4)
        WriteSQL("delete FROM TransaksiLabFisik WHERE NoUrut in (SELECT NoUrut FROM transaksilab WHERE CONVERT(date, Tgllab)='" & Format(dtdelete.Value, "MM/dd/yyyy") & "')", 4)
        WriteSQL("delete FROM TransaksiLabHasilLain WHERE NoUrut in (SELECT NoUrut FROM transaksilab WHERE CONVERT(date, Tgllab)='" & Format(dtdelete.Value, "MM/dd/yyyy") & "')", 4)
        WriteSQL("delete FROM TransaksiLabDetail WHERE TransLabID in (SELECT TransLabID FROM transaksilab WHERE CONVERT(date, Tgllab)='" & Format(dtdelete.Value, "MM/dd/yyyy") & "')", 4)
        WriteSQL("delete FROM TransaksiLabBayar WHERE TransLabID in (SELECT TransLabID FROM transaksilab WHERE CONVERT(date, Tgllab)='" & Format(dtdelete.Value, "MM/dd/yyyy") & "')", 4)
        WriteSQL("delete FROM transaksilab WHERE CONVERT(date, Tgllab)='" & Format(dtdelete.Value, "MM/dd/yyyy") & "'", 4)
    End Sub

End Class