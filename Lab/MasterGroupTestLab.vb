Public Class MasterGroupTestLab

    Private Sub SetClear()
        buttindakanid.ResetText()
        buttindakanid.Enabled = False
        cmbpaketnama.ResetText()
        InsertNewItemComboSQL("select distinct PaketNama from MasterLabPaket ", cmbpaketnama)
        txpaketketerangan.ResetText()
        txpaketharga.Text = "0"
        butclear.Enabled = True
        dtpaketawal.Value = DateSerial("9998", "12", "31")
        dtpaketakhir.Value = DateSerial("9998", "12", "31")

        SetGrid()
    End Sub

    Private Sub SetGrid()

        Dim Tbls As DataTable = ReadSQL("select  b.TindakanID,b.Urutan,b.NamaTindakan,b.JenisTindakan,b.TindakanNilai,b.TindakanDiscount as DiscPersen,b.TindakanNett from MasterLabPaket a  left join MasterLabPaketdetail b on a.PaketID=b.PaketID where a.PaketID='" & buttindakanid.Text & "' order by b.Urutan")

        For Each Tcol As DataColumn In Tbls.Columns
            Tcol.ReadOnly = True
        Next

        Tbls.Columns("TindakanNett").ReadOnly = False
        Tbls.Columns("Urutan").ReadOnly = False

        gridtindakan.DataSource = Tbls
        GridView2.Columns("TindakanID").Visible = False

    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        SetClear()
    End Sub

    Private Sub Kalkulasi()
        Dim Ttl As Double = 0
        Dim Tbls As DataTable = gridtindakan.DataSource
        Tbls.AcceptChanges()
        Tbls.Columns("DiscPersen").ReadOnly = False
        For Each Trow As DataRow In Tbls.Rows
            If Trow("TindakanNett") <= 0 Then
                MsgBox("Terdapat Harga Bersih / Netto yang kosong. Harap dicheck")
            Else
                Dim Persen As Double = (CDbl(Trow("TindakanNilai")) - CDbl(Trow("TindakanNett"))) / CDbl(Trow("TindakanNilai")) * 100
                Trow("DiscPersen") = Persen
                Ttl = Ttl + Trow("TindakanNett")
            End If
        Next
        txpaketharga.Text = Ttl
    End Sub

    Function Checking() As Boolean
        If buttindakanid.Text <> "" Then
            If CheckSQL("select * from MasterLabPaket where PaketID='" & buttindakanid.Text & "'") = True Then
                If MsgBox("Apakah yakin data di-updated ?", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then
                    MsgBox("Batal Updated")
                    Return False
                End If
            End If
        End If

        Dim Ttl As Double = 0
        Dim Tbls As DataTable = gridtindakan.DataSource
        Tbls.AcceptChanges()
        Tbls.Columns("DiscPersen").ReadOnly = False
        For Each Trow As DataRow In Tbls.Rows
            If Trow("DiscPersen") < 0 Then
                MsgBox("Discount tidak boleh kurang dari 0 ")
                Return False
                Exit Function
            End If


            If Trow("TindakanNett") <= 0 Then
                MsgBox("Terdapat Harga Bersih / Netto yang kosong. Harap dicheck")
                Return False
            Else
                Dim Persen As Double = (CDbl(Trow("TindakanNilai")) - CDbl(Trow("TindakanNett"))) / CDbl(Trow("TindakanNilai")) * 100
                Trow("DiscPersen") = Persen
                Ttl = Ttl + Trow("TindakanNett")
            End If
        Next

        txpaketharga.Text = Ttl

        If cmbpaketnama.FindStringExact(cmbpaketnama.Text) < 0 Then
            If MsgBox("Nama Paket tidak ada. Buat baru ?", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then
                MsgBox("Pilih paket yang telah ada.")
                Return False
            End If
        End If

        If dtpaketawal.Value = DateSerial("9998", "12", "31") Then
            MsgBox("Set Tanggal awal Paket dijalankan")
            Return False
        End If

        If dtpaketawal.Value > dtpaketakhir.Value Then
            MsgBox("Periode Paket tidak sesuai / salah.")
            Return False
        End If

        If CheckSQL("select * from MasterLabPaket where PaketNama='" & cmbpaketnama.Text & "' and ( PaketStart between '" & Format(dtpaketawal.Value, "MM/dd/yyyy") & "' and '" & Format(dtpaketakhir.Value, "MM/dd/yyyy") & "' or PaketEnd between '" & Format(dtpaketawal.Value, "MM/dd/yyyy") & "' and '" & Format(dtpaketakhir.Value, "MM/dd/yyyy") & "' ) and PaketID<>'" & buttindakanid.Text & "'") = True Then
            MsgBox("Terdapat Nama Paket yang sama pada rentang waktu tersebut.")
            Return False
        End If


        If CheckSQL("select * from MasterLabPaket where PaketNama='" & cmbpaketnama.Text & "' and '" & Format(dtpaketawal.Value, "MM/dd/yyyy") & "' between PaketStart and PaketEnd and PaketID<>'" & buttindakanid.Text & "'") = True Then
            MsgBox("Terdapat Nama Paket yang sama pada rentang waktu tersebut.")
            Return False
        End If

        If CheckSQL("select * from MasterLabPaket where PaketNama='" & cmbpaketnama.Text & "' and '" & Format(dtpaketakhir.Value, "MM/dd/yyyy") & "' between PaketStart and PaketEnd and PaketID<>'" & buttindakanid.Text & "'") = True Then
            MsgBox("Terdapat Nama Paket yang sama pada rentang waktu tersebut.")
            Return False
        End If

        Return True
    End Function

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        If Checking() = True Then
            If buttindakanid.Text <> "" Then
                'update
                WriteSQL("update MasterLabPaket set ChangeDate='" & Format(DateAndTime.Now, "MM/dd/yyyy") & "' ,ChangeBy='" & PoliKlinik.Lbluser.Text & "', PaketNama='" & cmbpaketnama.Text & "' ,PaketKeterangan='" & txpaketketerangan.Text & "' ,PaketNilaiTotal=" & CDbl(txpaketharga.Text) & " , PaketStart='" & Format(dtpaketawal.Value, "MM/dd/yyyy") & "' , PaketEnd='" & Format(dtpaketakhir.Value, "MM/dd/yyyy") & "' where PaketID='" & buttindakanid.Text & "'", 4)

                Dim Tbls As DataTable = gridtindakan.DataSource
                Tbls.AcceptChanges()
                For Each Trow As DataRow In Tbls.Rows
                    If CheckSQL("select * from MasterLabPaketDetail where TindakanID='" & Trow("TindakanID").ToString & "' and PaketID='" & buttindakanid.Text & "'") Then
                        WriteSQL("update MasterLabPaketDetail set Urutan='" & Trow("Urutan").ToString & "', NamaTindakan='" & Trow("NamaTindakan").ToString & "' , TindakanNilai=" & Trow("TindakanNilai") & " , TindakanDiscount=" & Trow("DiscPersen") & " , TindakanNett=" & Trow("TindakanNett") & " , Status=1 where TindakanID='" & Trow("TindakanID").ToString & "' and PaketID='" & buttindakanid.Text & "'", 4)
                    Else
                        WriteSQL("INSERT INTO MasterLabPaketDetail (PaketID, TindakanID, NamaTindakan, JenisTindakan, TindakanNilai, TindakanDiscount, TindakanNett, Status, Urutan) VALUES " & _
                                 "('" & buttindakanid.Text & "','" & Trow("TindakanID").ToString & "','" & Trow("NamaTindakan").ToString & "','" & Trow("JenisTindakan") & "'," & CDbl(Trow("TindakanNilai")) & "," & CDbl(Trow("DiscPersen")) & ", " & CDbl(Trow("TindakanNett")) & ", 1, '" & Trow("Urutan") & "')", 4)
                    End If
                Next
                WriteSQL("delete from MasterLabPaketDetail where PaketID='" & buttindakanid.Text & "' and Status=0", 4)
                WriteSQL("update MasterLabPaketDetail set Status=0 where PaketID='" & buttindakanid.Text & "'", 4)
                MsgBox("Update done")
            Else
                'save new
                WriteSQL("insert into MasterLabPaket (PaketNama,PaketKeterangan,PaketNilaiTotal,ChangeDate,ChangeBy,PaketStart,PaketEnd) values('" & cmbpaketnama.Text & "','" & txpaketketerangan.Text & "'," & CDbl(txpaketharga.Text) & ",'" & Format(DateAndTime.Now, "MM/dd/yyyy") & "','" & PoliKlinik.Lbluser.Text & "','" & Format(dtpaketawal.Value, "MM/dd/yyyy") & "','" & Format(dtpaketakhir.Value, "MM/dd/yyyy") & "')", 4)
                buttindakanid.Text = ReadSQLNIK("select * from MasterLabPaket where PaketNama='" & cmbpaketnama.Text & "' and PaketKeterangan='" & txpaketketerangan.Text & "' and PaketNilaiTotal=" & CDbl(txpaketharga.Text) & " and PaketStart='" & Format(dtpaketawal.Value, "MM/dd/yyyy") & "' and PaketEnd='" & Format(dtpaketakhir.Value, "MM/dd/yyyy") & "'")
                Dim Tbls As DataTable = gridtindakan.DataSource
                Tbls.AcceptChanges()

                For Each Trow As DataRow In Tbls.Rows
                    If CheckSQL("select * from MasterLabPaketDetail where TindakanID='" & Trow("TindakanID").ToString & "' and PaketID='" & buttindakanid.Text & "'") Then
                        WriteSQL("update MasterLabPaketDetail set Urutan='" & Trow("Urutan").ToString & "', NamaTindakan='" & Trow("NamaTindakan").ToString & "' , TindakanNilai=" & Trow("TindakanNilai") & " , TindakanDiscount=" & Trow("DiscPersen") & " , TindakanNett=" & Trow("TindakanNett") & " , Status=1 where TindakanID='" & Trow("TindakanID").ToString & "' and PaketID='" & buttindakanid.Text & "'", 4)
                    Else
                        WriteSQL("INSERT INTO MasterLabPaketDetail (PaketID, TindakanID, NamaTindakan, JenisTindakan, TindakanNilai, TindakanDiscount, TindakanNett, Status, Urutan) VALUES " & _
                                 "('" & buttindakanid.Text & "','" & Trow("TindakanID").ToString & "','" & Trow("NamaTindakan").ToString & "','" & Trow("JenisTindakan") & "'," & CDbl(Trow("TindakanNilai")) & "," & CDbl(Trow("DiscPersen")) & ", " & CDbl(Trow("TindakanNett")) & ", 1, '" & Trow("Urutan") & "')", 4)
                    End If
                Next
                MsgBox("Saved done")
                NewToolStripMenuItem.PerformClick()
            End If
        End If
    End Sub

    Public Sub AddTindakanDetail(ByRef Trow() As DataRow)
        Dim Tbls As DataTable = gridtindakan.DataSource
        If Trow.Count > 0 Then
            For i As Integer = 0 To Trow.Length - 1
                Dim Tnew As DataRow = Tbls.NewRow
                Tnew("Urutan") = "0"
                Tnew("TindakanID") = Trow(i)("TindakanID")
                Tnew("NamaTindakan") = Trow(i)("NamaTindakan")
                Tnew("JenisTindakan") = Trow(i)("JenisTindakan")
                Tnew("TindakanNilai") = Trow(i)("BiayaTindakan")
                Tnew("DiscPersen") = "0"
                Tnew("TindakanNett") = "0"
                Tbls.Rows.Add(Tnew)
            Next
            Tbls.AcceptChanges()
        End If
    End Sub

    Public Sub LoadPaketID(ByRef Txid As String)
        SetClear()

        Dim Tbls As DataTable = ReadSQL("select * from MasterLabPaket where PaketID='" & Txid & "'")
        Dim Trow As DataRow = Tbls.Rows(0)
        buttindakanid.Text = Txid
        buttindakanid.Enabled = False
        cmbpaketnama.Text = Trow("PaketNama")
        txpaketketerangan.Text = Trow("PaketKeterangan")
        txpaketharga.Text = Trow("PaketNilaiTotal")
        dtpaketawal.Value = Trow("PaketStart")
        dtpaketakhir.Value = Trow("PaketEnd")
        SetGrid()

        If CheckSQL("select * from MasterLabPaket where PaketNama='" & cmbpaketnama.Text & "' and PaketEnd>'" & Format(dtpaketakhir.Value, "MM/dd/yyyy") & "'") = True Then
            butclear.Enabled = False
        Else
            butclear.Enabled = True
        End If

    End Sub

    Private Sub butclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butclear.Click
        FindMultiple.Show()
        FindMultiple.Query("SELECT TindakanID,NamaTindakan,JenisTindakan,BiayaTindakan,DiscTindakan,NettBayar FROM MasterLab where Closed=0 ", " order by  JenisTindakan,TindakanID ", "FindPaketDetail", 1)
    End Sub

    Private Sub MasterGroupTestLab_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        NewToolStripMenuItem.PerformClick()
    End Sub

    Private Sub GridView2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridView2.KeyUp
        If e.KeyCode = Keys.Delete And GridView2.SelectedRowsCount > 0 Then
            Dim Trow As DataRow = GridView2.GetDataRow(GridView2.FocusedRowHandle)
            If MsgBox("Yakin menghapus Tindakan : " & Trow("NamaTindakan") & " ? ", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                GridView2.DeleteRow(GridView2.FocusedRowHandle)
                gridtindakan.RefreshDataSource()
            End If
        End If
    End Sub

    Private Sub butkalkulasi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butkalkulasi.Click
        Kalkulasi()
    End Sub

    Private Sub butfinddokter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butfinddokter.Click
        Find.Show()
        Find.Query("select PaketID,PaketNama,PaketKeterangan,PaketNilaiTotal,PaketStart as Start, PaketEnd as [End] from MasterLabPaket", " order by PaketId,PaketEnd desc ", "FindPaketID", 2)
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        Report = New XtraReport
        Report = XtraReport.FromFile(Application.StartupPath + "\reports\MasterTindakanPaketLab.repx", True)
        Report.DataSource = gridtindakan.DataSource
        Report.Bands.Item(BandKind.ReportHeader).Controls("lbltanggal").Text = "Data per : " & Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm")
        Report.Bands.Item(BandKind.ReportHeader).Controls("lbladmin").Text = ""
        Report.Bands.Item(BandKind.ReportFooter).Controls("lbltanggalacc").Text = ".............. ," & Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:sss")
        Report.Bands.Item(BandKind.ReportFooter).Controls("lbltanggalacc").Text = ""
        Report.Bands.Item(BandKind.ReportHeader).Controls("lbljenissetoran").Text = "MASTER JENIS TINDAKAN LAB"
        'Report.RunDesigner()
        Report.ShowPreview()
        'Report.Print()
    End Sub
End Class