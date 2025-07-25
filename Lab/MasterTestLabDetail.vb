Public Class MasterTestLabDetail

    Private Sub SetClearHeader()
        buttindakanid.ResetText()
        buttindakanid.Enabled = False
        txtindakannama.ResetText()
        cmbtindakangroup.ResetText()
        GroupBox2.Enabled = False
        SetClearChild()
    End Sub

    Private Sub SetClearChild()
        butdetailid.ResetText()
        txdetailket.ResetText()
        txdetailresultwanita.ResetText()
        txdetailresultpria.ResetText()
        cmbdetailgroup.ResetText()
        'txintpria.ResetText()
        'txintwanita.ResetText()
        'txintsatuan.ResetText()
        txsatuan.ResetText()
        InsertNewItemComboSQL("select distinct GroupID from MasterLabDetail where TindakanID='" & buttindakanid.Text & "'", cmbdetailgroup)
        numdetailurut.Value = 0
        GridControlx.Enabled = False
        chtindakanclosed.Checked = False
        butdetailid.Enabled = False
        SetCLearGrid()
    End Sub

    Private Sub SetCLearGrid()
        GridControlx.DataSource = ReadSQL("SELECT DetailID,GroupID,NoUrut,DetailKet,Pria,Wanita,DisplayHasil,Deleted FROM MasterLabDetail where TindakanID='" & buttindakanid.Text & "' and Status='0' and Deleted='0' order by GroupID,NoUrut,DetailKet")
        GridControlx.Enabled = True
        GridView1.Columns("DetailID").Visible = False
    End Sub

    Public Sub LoadTindakanHeader(ByRef Txid As String)
        SetClearHeader()
        buttindakanid.Text = Txid
        buttindakanid.Enabled = False
        Dim Tbls As DataTable = ReadSQL("select * from MasterLab where tindakanid='" & Txid & "'")
        Dim Trow As DataRow = Tbls.Rows(0)
        txtindakannama.Text = Trow("NamaTindakan").ToString
        cmbtindakangroup.Text = Trow("JenisTindakan").ToString
        InsertNewItemComboSQL("select distinct GroupID from MasterLabDetail where TindakanID='" & buttindakanid.Text & "'", cmbdetailgroup)
        SetCLearGrid()
        GroupBox2.Enabled = True
        GridControlx.Enabled = True
    End Sub

    Public Sub LoadDetailTindakan(ByRef Txid As String)
        SetClearChild()
        Dim Tbls As DataTable = ReadSQL("select * from MasterLabDetail where DetailID='" & Txid & "'")
        Dim Trow As DataRow = Tbls.Rows(0)
        butdetailid.Text = Txid
        InsertNewItemComboSQL("select GroupID from MasterLabDetail where DetailID='" & Txid & "'", cmbdetailgroup)
        cmbdetailgroup.Text = Trow("GroupID")
        txdetailket.Text = Trow("DetailKet")
        txdetailresultpria.Text = Trow("Pria")
        txdetailresultwanita.Text = Trow("Wanita")
        numdetailurut.Value = Trow("NoUrut")
        txsatuan.Text = Trow("DisplayHasil")
        If Trow("Deleted") = "1" Then
            chtindakanclosed.Checked = True
        End If
    End Sub

    Private Sub buttindakanid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles buttindakanid.KeyUp
        If e.KeyCode = Keys.F4 Then
            Find.Show()
            Find.Query(" SELECT [TindakanID],[NamaTindakan],[JenisTindakan],[BiayaTindakan],[Closed],[JenisDokter],[ClosedDate] from [MasterLab] ", " order by TindakanID ", "FindMasterTindakanForDetail", 2)
        End If
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub MasterTestLabDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        NewToolStripMenuItem.PerformClick()
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        SetClearHeader()
    End Sub

    Private Sub butclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butclear.Click
        SetClearChild()
    End Sub

    Function Checking() As Boolean
        If butdetailid.Text <> "" Then
            If CheckSQL("select * from MasterLabDetail where TindakanID='" & buttindakanid.Text & "' and NoUrut='" & numdetailurut.Value & "' and [GroupID]='" & cmbdetailgroup.Text & "'") = True Then
                If MsgBox("", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then
                    MsgBox("No Urut telah ada. Mohon No Urut diganti dengan yang belum digunakan.")
                End If
            End If
        End If

        If cmbdetailgroup.FindStringExact(cmbdetailgroup.Text) < 0 Then
            If MsgBox("Apakah akan meng-create group baru ? ", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then
                MsgBox("Pilih Detail Group yang telah ada.")
                Return False
            End If
        End If

        If txintsatuan.Text = "" Then
            If MsgBox("Hasil International Pria apakah memang tidak diisi ? ", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then
                MsgBox("Isi Hasil International Pria")
                txintsatuan.Focus()
                Return False
            End If
        End If

        If txintpria.Text = "" Then
            If MsgBox("Hasil International Pria apakah memang tidak diisi ? ", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then
                MsgBox("Isi Hasil International Pria")
                txintpria.Focus()
                Return False
            End If
        End If

        If txintwanita.Text = "" Then
            If MsgBox("Hasil International Wanita apakah memang tidak diisi ? ", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then
                MsgBox("Isi Hasil International Wanita")
                txintwanita.Focus()
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub butsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butsave.Click
        If Checking() = True Then
            If butdetailid.Text = "" Then
                'new
                'WriteSQL("insert into MasterLabDetail (TindakanID,GroupID,NoUrut,DetailKet,Pria,Wanita,ChangeDate,ChangeBy,Deleted,Status,DisplayHasil,IntPria,IntWanita,IntDisplayHasil) values('" & buttindakanid.Text & "','" & cmbdetailgroup.Text & "','" & numdetailurut.Value & "','" & txdetailket.Text & "','" & txdetailresultl.Text & "','" & txdetailresultp.Text & "',getdate(),'" & PoliKlinik.Lbluser.Text & "',0,0,'" & txsatuan.Text & "','" & txintpria.Text & "','" & txintwanita.Text & "','" & txintsatuan.Text & "')", 1)
                WriteSQL("insert into MasterLabDetail (TindakanID,GroupID,NoUrut,DetailKet,Pria,Wanita,ChangeDate,ChangeBy,Deleted,Status,DisplayHasil) values('" & buttindakanid.Text & "','" & cmbdetailgroup.Text & "','" & numdetailurut.Value & "','" & txdetailket.Text & "','" & txdetailresultpria.Text & "','" & txdetailresultwanita.Text & "',getdate(),'" & PoliKlinik.Lbluser.Text & "',0,0,'" & txsatuan.Text & "')", 1)
                SetClearChild()
            Else
                'update 
                If butdetailid.Text <> "" Then
                    'WriteSQL("update MasterLabDetail set [GroupID]='" & cmbdetailgroup.Text & "',[Pria]='" & txdetailresultl.Text & "' ,[Wanita]='" & txdetailresultp.Text & "', IntWanita='" & txintwanita.Text & "' , IntPria='" & txintpria.Text & "' ,IntDisplayHasil='" & txintsatuan.Text & "' , DisplayHasil='" & txsatuan.Text & "', ChangeDate=getdate() , ChangeBy='" & PoliKlinik.Lbluser.Text & "' where TindakanID='" & buttindakanid.Text & "' and DetailID='" & butdetailid.Text & "'", 2)
                    WriteSQL("update MasterLabDetail set [GroupID]='" & cmbdetailgroup.Text & "',[Pria]='" & txdetailresultpria.Text & "' ,[Wanita]='" & txdetailresultwanita.Text & "' , DisplayHasil='" & txsatuan.Text & "', ChangeDate=getdate() , ChangeBy='" & PoliKlinik.Lbluser.Text & "' where TindakanID='" & buttindakanid.Text & "' and DetailID='" & butdetailid.Text & "'", 2)
                End If
            End If
        End If
    End Sub

    Private Sub butdelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butdelete.Click
        If CheckSQL("select * from MasterLabDetail where TindakanID='" & buttindakanid.Text & "' and DetailID='" & butdetailid.Text & "' ") = True Then
            If MsgBox("Yakin untuk Detail ini di-nonaktif-kan ?", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                WriteSQL("update MasterLabDetail set deleted=1,Status=1 where TindakanID='" & buttindakanid.Text & "' and Nourut='" & numdetailurut.Value & "'", 4)
                MsgBox("Done")
                SetClearChild()
            Else
                MsgBox("Batal Deleted")
            End If
        End If
    End Sub

    Private Sub butdetailid_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles butdetailid.KeyUp
        If e.KeyCode = Keys.F4 Then
            Find.Show()
            Find.Query("select DetailID,TindakanID,GroupID,NoUrut,DetailKet,Pria,Wanita,DisplayHasil,ChangeDate,ChangeBy,Deleted from MasterLabDetail where TindakanID='" & buttindakanid.Text & "' ", " order by NoUrut,GroupID", "FindDetailLabForDetail", 2)
        End If
    End Sub

    Private Sub butfinddokter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butfinddokter.Click
        Find.Show()
        Find.Query("select DetailID,TindakanID,GroupID,NoUrut,DetailKet,Pria,Wanita,DisplayHasil,ChangeDate,ChangeBy,Deleted from MasterLabDetail where TindakanID='" & buttindakanid.Text & "' ", " order by NoUrut,GroupID", "FindDetailLabForDetail", 2)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Find.Show()
        Find.Query(" SELECT [TindakanID],[NamaTindakan],[JenisTindakan],[BiayaTindakan],[Closed],[JenisDokter],[ClosedDate] from [MasterLab]  ", " order by TindakanID ", "FindMasterTindakanForDetail", 1)
    End Sub
End Class