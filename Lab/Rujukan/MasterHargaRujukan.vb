Public Class MasterHargaRujukan

    Private Sub SetClear()

        txtindakanid.ResetText()
        txtindakannama.ResetText()
        txlabrujukanket.ResetText()
        txlabrujukanid.ResetText()
        txbiayatindakan.ResetText()
        txbiayarujukan.ResetText()
    End Sub

    Private Sub GridRujukan()
        Dim Tbls As DataTable = ReadSQL("select b.NamaTindakan, b.JenisTindakan, b.BiayaTindakan, a.HargaRujukan from MasterHargaTindakanRujukan a left join MasterLab b on a.TindakanID=b.TindakanID")
        Tbls.Rows.Clear()
        gridtindakan.DataSource = Tbls
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        SetClear()
        GridRujukan()
    End Sub

    Private Sub MasterHargaRujukan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        NewToolStripMenuItem.PerformClick()
    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        'If butobat.Text <> "" Then
        '    If MsgBox("Yakin untuk dihapus / tidak digunakan lagi ?", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
        '        WriteSQL("update MasterLab set Closed='1', ClosedDate='" & Format(dttindakannow.Value, "MM/dd/yyyy") & "' where tindakanid='" & txtindakanid.Text & "'", 3)
        '    End If
        'End If
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Function Checking() As Boolean
        If txtindakanid.Text = "" Then
            MsgBox("Plih Tindakan terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        If IsNumeric(txbiayatindakan.Text) = False Then
            MsgBox("Biaya harus angka.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        Else
            If CDbl(txbiayatindakan.Text) <= 0 Then
                MsgBox("Biaya harus lebih besar dari 0.", MsgBoxStyle.Exclamation, "Warning!")
                Return False
            End If
        End If

        If IsNumeric(txbiayarujukan.Text) = False Then
            MsgBox("Biaya harus angka.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        Else
            If CDbl(txbiayarujukan.Text) <= 0 Then
                MsgBox("Biaya harus lebih besar dari 0.", MsgBoxStyle.Exclamation, "Warning!")
                Return False
            End If

            If CDbl(txbiayarujukan.Text) >= CDbl(txbiayatindakan.Text) Then
                MsgBox("Biaya harus lebih kecil dari biaya tindakan.", MsgBoxStyle.Exclamation, "Warning!")
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        If Checking() = True Then
            Dim tupdate As String = ReadSQLNIK("select TindakanID from MasterHargaTindakanRujukan where TindakanID='" & txtindakanid.Text & "' and NoLabRujukan='" & txlabrujukanid.Text & "'")
            If tupdate = "-" Or tupdate = "" Or IsDBNull(tupdate) = True Then
                'INSERT TABEL
                WriteSQL("insert into MasterHargaTindakanRujukan (NoLabRujukan, TindakanID, HargaRujukan,CreateDate,CreateBy) values('" & txlabrujukanid.Text & "', '" & txtindakanid.Text & "', " & CInt(txbiayarujukan.Text) & ", getdate(), '" & PoliKlinik.Lbluser.Text & "')", 1)
                NewToolStripMenuItem.PerformClick()
            Else
                'UPDATE TABEL
                WriteSQL("update MasterHargaTindakanRujukan set HargaRujukan='" & CDbl(txbiayarujukan.Text) & "',ChangeDate=getdate(), ChangeBy='" & PoliKlinik.Lbluser.Text & "' where TindakanID='" & txtindakanid.Text & "' and NoLabRujukan='" & txlabrujukanid.Text & "'", 2)
                NewToolStripMenuItem.PerformClick()
            End If
            'GridRujukan()
        End If
    End Sub

    Public Sub LoadTindakan(ByRef Txid As String)
        'SetClear()
        txtindakanid.Text = Txid
        Dim Tbls As DataTable = ReadSQL("select * from MasterLab where tindakanid='" & Txid & "'")
        'Dim Tbls As DataTable = ReadSQL("select a.*, b.HargaRujukan from MasterLab a left join MasterHargaTindakanRujukan b on a.TindakanID = b.TindakanID where a.TindakanID='" & Txid & "' and b.NoLabRujukan='" & txlabrujukanid.Text & "'")
        Dim Trow As DataRow = Tbls.Rows(0)
        txtindakannama.Text = Trow("NamaTindakan").ToString
        txbiayatindakan.Text = Trow("BiayaTindakan")
        Dim HargaRujuk As String = ReadSQLNIK("select HargaRujukan from MasterHargaTindakanRujukan where TindakanID='" & Txid & "' and NoLabRujukan='" & txlabrujukanid.Text & "'")
        If HargaRujuk = "-" Or HargaRujuk = "" Or IsDBNull(HargaRujuk) = True Then
            txbiayarujukan.Text = 0
        Else
            txbiayarujukan.Text = HargaRujuk
        End If
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

    Public Sub LoadTindakanRujukan(ByRef Txid As String)
        Dim Tbls As DataTable = ReadSQL("select b.NamaTindakan, b.JenisTindakan, b.BiayaTindakan, a.HargaRujukan from MasterHargaTindakanRujukan a left join MasterLab b on a.TindakanID=b.TindakanID where a.NoLabRujukan='" & Txid & "' AND Closed = 0 order by b.JenisTindakan, b.TindakanID")
        gridtindakan.DataSource = Tbls
        For Each Tcol As DataColumn In Tbls.Columns
            Tcol.ReadOnly = True
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txlabrujukanid.Text = "" Then
            MsgBox("Pilih Laboratorium Rujukan Terlebih Dahulu.")
            Exit Sub
        End If

        Find.Show()
        Find.Query(" SELECT TindakanID,NamaTindakan,JenisTindakan,BiayaTindakan,Closed,JenisDokter,ClosedDate from MasterLab ", " order by TindakanID ", "FindMasterHargaRujukan", 1)
    End Sub

    Private Sub butclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'SetClearObat()
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

    Private Sub butsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Tbls As DataTable = gridtindakan.DataSource
        Tbls.AcceptChanges()

        Dim Tnew As DataRow = Tbls.NewRow

        If CheckTambahTindakan(Tnew) = True Then
            Tbls.Rows.Add(Tnew)
        End If
    End Sub

    Private Sub butlabrujukan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butlabrujukan.Click
        Find.Show()
        Find.Query("select NamaLabRujukan, AlamatLabRujukan, UpLabRujukan, NoLabRujukan from masterlaboratoriumrujukan where getdate() between StartDate and EndDate", " ORDER BY IDLabRujukan desc", "FindLabMasterHargaRujukan", 2)
    End Sub
End Class