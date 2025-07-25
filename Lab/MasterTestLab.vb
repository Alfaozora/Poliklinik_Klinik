Public Class MasterTestLab

    Private Sub SetClear()
        txtindakanid.ResetText()
        txtindakanid.Enabled = False
        butfindobat.Enabled = True
        txtindakannama.Enabled = True
        butobat.ResetText()
        txtindakannama.ResetText()
        txtindakanbiaya.Text = "0"
        InsertNewItemComboSQL("select distinct JenisTindakan from MasterJenisTindakan", cmbtindakangroup)
        InsertNewItemComboSQL("select ObatKodeID from MasterStockLab", butobat)
        chtindakanclosed.Checked = False
        dttindakannow.Value = DateSerial("9998", "12", "31")
        txhargakd.Text = "0"
        txhargaprh.Text = "0"
        txhargaprt.Text = "0"
        cmbomr.ResetText()
        txalat.ResetText()
        txtabung.ResetText()
        txtabungref.ResetText()
        GridObat()
    End Sub

    Private Sub GridObat()
        WriteSQL("delete from MasterLabStockMinus where tindakanid=0", 4)
        Dim Tbls As DataTable = ReadSQL("select a.ObatID,b.ObatKodeID,b.ObatNama,a.Nilai from MasterLabStockMinus a left join MasterStockLab b on a.ObatID=b.ObatID where a.TindakanID='" & txtindakanid.Text & "'")
        gridtindakan.DataSource = Tbls
        GridView2.Columns("ObatID").Visible = False
    End Sub

    Private Sub SetClearObat()
        butobat.ResetText()
        txobatid.ResetText()
        numjumlahobat.Value = 0
    End Sub

    'Private Sub SetGrid()
    '    dim Tbls as datatable  = ReadSQL("SELECT TindakanID,NamaTindakan,JenisTindakan,Mesin,Tabung,TabungRef,BiayaTindakan,KD,PRT,PRH,Closed,ClosedDate FROM MasterLab order by Closed,JenisTindakan,NamaTindakan")
    '    gridtindakan.DataSource = Tbls
    '    GridView2.Columns("TindakanID").Visible = False
    '    GridView2.Columns("ClosedDate").Visible = False
    'End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        SetClear()
        GridObat()
    End Sub

    Private Sub MasterTestLab_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        NewToolStripMenuItem.PerformClick()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        If butobat.Text <> "" Then
            If MsgBox("Yakin untuk dihapus / tidak digunakan lagi ?", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                WriteSQL("update MasterLab set Closed='1', ClosedDate='" & Format(dttindakannow.Value, "MM/dd/yyyy") & "' where tindakanid='" & txtindakanid.Text & "'", 3)
            End If
        End If
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Function Checking() As Boolean
        If IsNumeric(txtindakanbiaya.Text) = False Then
            MsgBox("Biaya harus angka")
            Return False
        Else
            If txtindakanbiaya.Text <= 0 Then
                MsgBox("Biaya harus lebih besar dari 0 ")
                Return False
            End If
        End If

        If IsNumeric(txhargakd.Text) = False Then
            MsgBox("Biaya harus angka")
            Return False
        Else
            If txhargakd.Text < 0 Then
                MsgBox("Biaya harus lebih besar dari 0 ")
                Return False
            End If
        End If

        If IsNumeric(txhargaprh.Text) = False Then
            MsgBox("Biaya harus angka")
            Return False
        Else
            If txhargaprh.Text < 0 Then
                MsgBox("Biaya harus lebih besar dari 0 ")
                Return False
            End If
        End If

        If IsNumeric(txhargaprt.Text) = False Then
            MsgBox("Biaya harus angka")
            Return False
        Else
            If txhargaprt.Text < 0 Then
                MsgBox("Biaya harus lebih besar dari 0 ")
                Return False
            End If
        End If

        If cmbtindakangroup.FindStringExact(cmbtindakangroup.Text) < 0 Then
            If MsgBox("Tindakan group menu baru ?", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then
                MsgBox("Pilih tindakan group yang sesuai")
                Return False
            End If
        End If

        If txtindakannama.Text = "" Then
            MsgBox("Nama Tindakan harus diisi")
            Return False
        End If

        If cmbomr.FindStringExact(cmbomr.Text) < 0 Then
            MsgBox("Pilih jenis OMR yang sesuai")
            Return False
        End If

        If txalat.Text = "" Then
            If MsgBox("Apakah memang alat tidak disambung dengan alat lainnya yang bisa ditarik otomatis ?", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then
                MsgBox("Masukkan pada kolom ini mesin yang bisa ditarik otomatis ( con. TMS, SYSMEX ).")
                Return False
            End If
        End If

        If txtabung.Text = "" Then
            If MsgBox("Yakin tidak menge-set tabung dan Ref yang akan dipakai ?", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then
                MsgBox("Set Tabung dan Ref yang sesuai kebutuhan.")
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        If Checking() = True Then
            Dim DBobat As DataTable = gridtindakan.DataSource
            DBobat.AcceptChanges()

            If txtindakanid.Text = "" Then
                'new 
                WriteSQL("insert into MasterLab (NamaTindakan,JenisTindakan,BiayaTindakan,Closed,JenisDokter,UpdateDate,UpdateBy,KD,PRT,PRH,OMR,Mesin,tabung,tabungref) values('" & txtindakannama.Text & "','" & cmbtindakangroup.Text & "'," & CInt(txtindakanbiaya.Text) & ",'0','LAB','" & Format(DateAndTime.Now, "MM/dd/yyyy") & "','" & PoliKlinik.Lbluser.Text & "'," & CInt(txhargakd.Text) & "," & CInt(txhargaprt.Text) & "," & CInt(txhargaprh.Text) & ",'" & cmbomr.Text & "','" & txalat.Text & "','" & txtabung.Text & "','" & txtabungref.Text & "')", 1)
                txtindakanid.Text = ReadSQLNIK("select tindakanid from MasterLab where NamaTindakan='" & txtindakannama.Text & "' and JenisTindakan='" & cmbtindakangroup.Text & "' and JenisDokter='LAB' and BiayaTindakan=" & CInt(txtindakanbiaya.Text) & " and UpdateBy='" & PoliKlinik.Lbluser.Text & "'")
                WriteSQL("delete from MasterLabStockMinus where TindakanID='" & txtindakanid.Text & "'", 4)
                For Each Trow As DataRow In DBobat.Rows
                    WriteSQL("insert into MasterLabStockMinus values('" & txtindakanid.Text & "','" & Trow("ObatID") & "','" & Trow("Nilai") & "',getdate(),'" & PoliKlinik.Lbluser.Text & "')", 4)
                Next
                NewToolStripMenuItem.PerformClick()
            Else
                'update
                WriteSQL("update MasterLab set NamaTindakan='" & txtindakannama.Text & "',JenisTindakan='" & cmbtindakangroup.Text & "',BiayaTindakan=" & CInt(txtindakanbiaya.Text) & ",JenisDokter='LAB',UpdateDate='" & Format(DateAndTime.Now, "MM/dd/yyyy") & "',UpdateBy='" & PoliKlinik.Lbluser.Text & "' ,KD=" & CInt(txhargakd.Text) & ",PRT=" & CInt(txhargaprt.Text) & ",PRH=" & CInt(txhargaprh.Text) & " , OMR='" & cmbomr.Text & "' , Mesin='" & txalat.Text & "',tabung='" & txtabung.Text & "',tabungref='" & txtabungref.Text & "' where TindakanID='" & txtindakanid.Text & "'", 2)

                WriteSQL("delete from MasterLabStockMinus where TindakanID='" & txtindakanid.Text & "'", 4)
                For Each Trow As DataRow In DBobat.Rows
                    WriteSQL("insert into MasterLabStockMinus values('" & txtindakanid.Text & "','" & Trow("ObatID") & "','" & Trow("Nilai") & "',getdate(),'" & PoliKlinik.Lbluser.Text & "')", 4)
                Next
            End If
            GridObat()
        End If
    End Sub

    Public Sub LoadTindakan(ByRef Txid As String)
        SetClear()
        txtindakanid.Enabled = False
        txtindakanid.Text = Txid
        Dim Tbls As DataTable = ReadSQL("select * from MasterLab where tindakanid='" & Txid & "'")
        Dim Trow As DataRow = Tbls.Rows(0)
        txtindakannama.Text = Trow("NamaTindakan").ToString
        txtindakannama.Enabled = False
        cmbtindakangroup.Text = Trow("JenisTindakan").ToString
        txtindakanbiaya.Text = Trow("BiayaTindakan")
        txhargakd.Text = Trow("KD")
        txhargaprh.Text = Trow("PRH")
        txhargaprt.Text = Trow("PRT")
        cmbomr.Text = Trow("OMR")
        If IsDBNull(Trow("Mesin")) = False Then txalat.Text = Trow("Mesin") Else txalat.Text = ""
        If IsDBNull(Trow("Tabung")) = False Then txtabung.Text = Trow("Tabung") Else txtabung.Text = ""
        If IsDBNull(Trow("TabungRef")) = False Then txtabungref.Text = Trow("TabungRef") Else txtabungref.Text = ""
        If Trow("Closed") = "1" Then chtindakanclosed.Checked = True
        If IsDBNull(Trow("ClosedDate")) = False Then dttindakannow.Value = Trow("ClosedDate") Else dttindakannow.Value = DateAndTime.Now
        GridObat()
    End Sub


    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        Report = New XtraReport
        Report = XtraReport.FromFile(Application.StartupPath + "\reports\MasterTindakan.repx", True)
        Report.DataSource = ReadSQL("SELECT TindakanID as ID,NamaTindakan,JenisTindakan,PARSENAME(CONVERT(varchar,convert(money,BiayaTindakan),1),2) as BiayaTindakan ,case when Closed=0 then 1 else 0 end as Closed,JenisDokter from MasterLab order by tindakanid")
        Report.Bands.Item(BandKind.ReportHeader).Controls("lbltanggal").Text = "Data per : " & Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm")
        Report.Bands.Item(BandKind.ReportHeader).Controls("lbladmin").Text = ""
        'Report.Bands.Item(BandKind.ReportFooter).Controls("lbltanggalacc").Text = ".............. ," & Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:sss")
        Report.Bands.Item(BandKind.ReportFooter).Controls("lbltanggalacc").Text = ""
        Report.Bands.Item(BandKind.ReportHeader).Controls("lbljenissetoran").Text = "MASTER JENIS TINDAKAN LAB"
        'Report.RunDesigner()
        Report.ShowPreview()
        'Report.Print()
    End Sub

    Public Sub LoadObatID(ByRef Txid As String)
        SetClearObat()
        Dim Tbls As DataTable = ReadSQL("select * from MasterStockLab where ObatID='" & Txid & "'")
        Dim Trow As DataRow = Tbls.Rows(0)
        butobat.Text = Trow("ObatKodeID").ToString
        txobatid.Text = Trow("ObatID").ToString
    End Sub

    Private Sub butfindtindakan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butfindobat.Click
        Find.Show()
        Find.Query("select * from MasterStockLab ", " order by ObatKodeID ", "FindObatTestLab", 2)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Find.Show()
        Find.Query(" SELECT TindakanID,NamaTindakan,JenisTindakan,BiayaTindakan,Closed,JenisDokter,ClosedDate from MasterLab ", " order by TindakanID ", "FindMasterTindakanLab", 1)
    End Sub

    Private Sub butclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butclear.Click
        SetClearObat()
    End Sub

    Function CheckTambahTindakan(ByRef Trow As DataRow)
        Dim Tbls As DataTable = gridtindakan.DataSource
        Tbls.AcceptChanges()
        If Tbls.Rows.Count > 0 Then
            For Each Ttemp As DataRow In Tbls.Rows
                If Ttemp("ObatID") = Trow("ObatID") Then
                    MsgBox("Terdapat tindakan double. Sudah ada pada pilihan. Check kembali.")
                    Return False
                End If
            Next
        End If
        Return True
    End Function

    Private Sub butsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butsave.Click
        Dim Tbls As DataTable = gridtindakan.DataSource
        Tbls.AcceptChanges()

        Dim Tnew As DataRow = Tbls.NewRow
        Tnew("ObatID") = txobatid.Text
        Tnew("ObatKodeID") = butobat.Text
        Tnew("ObatNama") = ReadSQLNIK("select ObatNama from MasterStockLab where ObatID='" & txobatid.Text & "'")
        Tnew("Nilai") = numjumlahobat.Value

        If CheckTambahTindakan(Tnew) = True Then
            Tbls.Rows.Add(Tnew)
        End If
    End Sub

    Private Sub butobat_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles butobat.KeyUp
        If e.KeyCode = Keys.Enter Then
            Dim Tid As String = ReadSQLNIK("select ObatID from MasterStockLab where ObatKodeID='" & butobat.Text & "'")
            LoadObatID(Tid)
        End If
    End Sub

    Private Sub butobat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butobat.SelectedIndexChanged

    End Sub

    Private Sub numjumlahobat_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numjumlahobat.ValueChanged

    End Sub
End Class