Public Class MasterPaket

    Private Sub ClearHeader()
        butpaketid.ResetText()
        butpaketid.Enabled = False
        txnamapaket.ResetText()
        txnamapaket.Enabled = True
        dtstart.Enabled = True
        dtend.Enabled = True
        dtstart.Value = DateAndTime.Now
        dtend.Value = DateAndTime.Now
        chkclosed.Checked = False
        txjumlahorang.Text = "0"
        txharga.Text = "0"
    End Sub

    Private Sub ClearKlinik()
        Dim Tbls As DataTable = ReadSQL("declare @nomer bigint set @nomer=0  select @nomer as IDPaket,TindakanID,NamaTindakan,JenisTindakan,PARSENAME(CONVERT(varchar,convert(money,BiayaTindakan),1),2) as BiayaTindakan,PARSENAME(CONVERT(varchar,convert(money,DiscTindakan),1),2) as DiscTindakan,PARSENAME(CONVERT(varchar,convert(money,@nomer),1),2) as DiscNilai,PARSENAME(CONVERT(varchar,convert(money,NettBayar),1),2) as NettBayar from MasterTindakan where Closed=0")
        insertRowToTbls(Tbls, "typchecked", "Checked")

        For Each Tcol As DataColumn In Tbls.Columns
            Tcol.ReadOnly = True
        Next
        Tbls.Columns("BiayaTindakan").ReadOnly = False
        Tbls.Columns("DiscTindakan").ReadOnly = False
        Tbls.Columns("DiscNilai").ReadOnly = False
        Tbls.Columns("Checked").ReadOnly = False

        gridklinik.DataSource = Tbls
        GridView1.Columns("IDPaket").Visible = False
        GridView1.Columns("TindakanID").Visible = False
    End Sub

    Private Sub ClearLab()
        Dim Tbls As DataTable = ReadSQL("declare @nomer bigint set @nomer=0  select @nomer as IDPaket,TindakanID,NamaTindakan,JenisTindakan,PARSENAME(CONVERT(varchar,convert(money,BiayaTindakan),1),2) as BiayaTindakan,PARSENAME(CONVERT(varchar,convert(money,DiscTindakan),1),2) as DiscTindakan,PARSENAME(CONVERT(varchar,convert(money,@nomer),1),2) as DiscNilai,PARSENAME(CONVERT(varchar,convert(money,NettBayar),1),2) as NettBayar from MasterLab where Closed=0")
        insertRowToTbls(Tbls, "typchecked", "Checked")

        For Each Tcol As DataColumn In Tbls.Columns
            Tcol.ReadOnly = True
        Next
        Tbls.Columns("BiayaTindakan").ReadOnly = False
        Tbls.Columns("DiscTindakan").ReadOnly = False
        Tbls.Columns("DiscNilai").ReadOnly = False
        Tbls.Columns("Checked").ReadOnly = False

        gridlab.DataSource = Tbls
        GridView2.Columns("IDPaket").Visible = False
        GridView2.Columns("TindakanID").Visible = False
    End Sub

    Private Sub ClearGigi()
        Dim Tbls As DataTable = ReadSQL("declare @nomer bigint set @nomer=0  select @nomer as IDPaket,TindakanID,NamaTindakan,'' as JenisTindakan,PARSENAME(CONVERT(varchar,convert(money,BiayaTindakan),1),2) as BiayaTindakan,PARSENAME(CONVERT(varchar,convert(money,DiscTindakan),1),2) as DiscTindakan,PARSENAME(CONVERT(varchar,convert(money,@nomer),1),2) as DiscNilai,PARSENAME(CONVERT(varchar,convert(money,NettBayar),1),2) as NettBayar from MasterTindakanGigi where Aktif=1 ")
        insertRowToTbls(Tbls, "typchecked", "Checked")

        For Each Tcol As DataColumn In Tbls.Columns
            Tcol.ReadOnly = True
        Next
        Tbls.Columns("BiayaTindakan").ReadOnly = False
        Tbls.Columns("DiscTindakan").ReadOnly = False
        Tbls.Columns("DiscNilai").ReadOnly = False
        Tbls.Columns("Checked").ReadOnly = False

        gridgigi.DataSource = Tbls
        GridView3.Columns("IDPaket").Visible = False
        GridView3.Columns("TindakanID").Visible = False
    End Sub

    Private Sub LoadKlinik()
        ClearKlinik()
        Dim Tbls As DataTable = gridklinik.DataSource
        Tbls.AcceptChanges()

        Tbls.Columns("BiayaTindakan").ReadOnly = False
        Tbls.Columns("DiscTindakan").ReadOnly = False
        Tbls.Columns("DiscNilai").ReadOnly = False
        Tbls.Columns("Checked").ReadOnly = False
        Tbls.Columns("NettBayar").ReadOnly = False


        For Each Trow As DataRow In Tbls.Rows
            If CheckSQL("select * from MasterPaketKartuDetail where IDPaket='" & butpaketid.Text & "' and Jenis='Klinik' and Aktif=1 and  TindakanID='" & Trow("TindakanID").ToString & "' and NamaTindakan='" & Trow("NamaTindakan").ToString & "'") = True Then
                Dim Ttrs As DataTable = ReadSQL("select * from MasterPaketKartuDetail where IDPaket='" & butpaketid.Text & "' and Jenis='Klinik' and Aktif=1 and  TindakanID='" & Trow("TindakanID").ToString & "' and NamaTindakan='" & Trow("NamaTindakan").ToString & "'")
                Dim Tnewrow As DataRow = Ttrs.Rows(0)
                'Trow("BiayaTindakan") = Splitmoney(CDbl(Tnewrow("BiayaTindakan")))
                Trow("DiscTindakan") = Splitmoney(CDbl(Tnewrow("DiscTindakan")))
                Trow("DiscNilai") = Splitmoney(CDbl(Trow("BiayaTindakan") * Trow("DiscTindakan") / 100))
                Trow("NettBayar") = Splitmoney(Trow("BiayaTindakan") - Trow("DiscNilai"))
                Trow("Checked") = True
            End If
        Next

    End Sub

    Private Sub LoadGigi()
        ClearGigi()
        Dim Tbls As DataTable = gridgigi.DataSource
        Tbls.AcceptChanges()

        Tbls.Columns("BiayaTindakan").ReadOnly = False
        Tbls.Columns("DiscTindakan").ReadOnly = False
        Tbls.Columns("DiscNilai").ReadOnly = False
        Tbls.Columns("Checked").ReadOnly = False
        Tbls.Columns("NettBayar").ReadOnly = False

        For Each Trow As DataRow In Tbls.Rows
            If CheckSQL("select * from MasterPaketKartuDetail where IDPaket='" & butpaketid.Text & "' and Jenis='Gigi' and Aktif=1 and  TindakanID='" & Trow("TindakanID").ToString & "' and NamaTindakan='" & Trow("NamaTindakan").ToString & "'") = True Then
                Dim Ttrs As DataTable = ReadSQL("select * from MasterPaketKartuDetail where IDPaket='" & butpaketid.Text & "' and Jenis='Gigi' and Aktif=1 and  TindakanID='" & Trow("TindakanID").ToString & "' and NamaTindakan='" & Trow("NamaTindakan").ToString & "'")
                Dim Tnewrow As DataRow = Ttrs.Rows(0)
                'Trow("BiayaTindakan") = Splitmoney(CDbl(Tnewrow("BiayaTindakan")))
                Trow("DiscTindakan") = Splitmoney(CDbl(Tnewrow("DiscTindakan")))
                Trow("DiscNilai") = Splitmoney(CDbl(Trow("BiayaTindakan") * Trow("DiscTindakan") / 100))
                Trow("NettBayar") = Splitmoney(Trow("BiayaTindakan") - Trow("DiscNilai"))
                Trow("Checked") = True
            End If
        Next

    End Sub

    Private Sub LoadLab()
        ClearLab()
        Dim Tbls As DataTable = gridlab.DataSource
        Tbls.AcceptChanges()

        Tbls.Columns("BiayaTindakan").ReadOnly = False
        Tbls.Columns("DiscTindakan").ReadOnly = False
        Tbls.Columns("DiscNilai").ReadOnly = False
        Tbls.Columns("Checked").ReadOnly = False
        Tbls.Columns("NettBayar").ReadOnly = False

        For Each Trow As DataRow In Tbls.Rows
            If CheckSQL("select * from MasterPaketKartuDetail where IDPaket='" & butpaketid.Text & "' and Jenis='Lab' and Aktif=1 and  TindakanID='" & Trow("TindakanID").ToString & "' and NamaTindakan='" & Trow("NamaTindakan").ToString & "'") = True Then
                Dim Ttrs As DataTable = ReadSQL("select * from MasterPaketKartuDetail where IDPaket='" & butpaketid.Text & "' and Jenis='Lab' and Aktif=1 and  TindakanID='" & Trow("TindakanID").ToString & "' and NamaTindakan='" & Trow("NamaTindakan").ToString & "'")
                Dim Tnewrow As DataRow = Ttrs.Rows(0)
                'Trow("BiayaTindakan") = Splitmoney(CDbl(Tnewrow("BiayaTindakan")))
                Trow("DiscTindakan") = Splitmoney(CDbl(Tnewrow("DiscTindakan")))
                Trow("DiscNilai") = Splitmoney(CDbl(Trow("BiayaTindakan") * Trow("DiscTindakan") / 100))
                Trow("NettBayar") = Splitmoney(Trow("BiayaTindakan") - Trow("DiscNilai"))
                Trow("Checked") = True
            End If
        Next

    End Sub

    Private Sub SaveKlinik()
        Dim Tbls As DataTable = gridklinik.DataSource
        Tbls.AcceptChanges()
        Dim Trow() As DataRow = Tbls.Select("[DiscTindakan]>0")
        Dim Tbool As String = "1"
        For i As Integer = 0 To Trow.Length - 1
            If CheckSQL("select * from MasterPaketKartuDetail where IDPaket='" & butpaketid.Text & "' and Jenis='Klinik' and TindakanID=" & Trow(i)("TindakanID").ToString & " and NamaTindakan='" & Trow(i)("NamaTindakan").ToString & "'") = True Then
                'update
                WriteSQL("update MasterPaketKartuDetail set  DiscTindakan=" & CDbl(Trow(i)("DiscTindakan")) & " ,NettBayar=" & CDbl(Trow(i)("NettBayar")) & " ,BiayaTindakan=" & CDbl(Trow(i)("BiayaTindakan")) & " , aktif='" & Tbool & "' , [Status]=1  where IDPaket='" & butpaketid.Text & "' and Jenis='Klinik' and TindakanID=" & Trow(i)("TindakanID").ToString & " and NamaTindakan='" & Trow(i)("NamaTindakan").ToString & "'", 4)
            Else
                'save new
                WriteSQL("insert into MasterPaketKartuDetail (IDPaket,Jenis,TindakanID,NamaTindakan,JenisTindakan,BiayaTindakan,DiscTindakan,NettBayar,Aktif,TglNonaktif,[Status]) " & _
                         "values('" & butpaketid.Text & "','Klinik'," & Trow(i)("TindakanID") & ",'" & Trow(i)("NamaTindakan") & "','" & Trow(i)("JenisTindakan") & "'," & CDbl(Trow(i)("BiayaTindakan")) & "," & CDbl(Trow(i)("DiscTindakan")) & "," & CDbl(Trow(i)("NettBayar")) & ",'" & Tbool & "','" & Format(DateAndTime.Now, "MM/dd/yyyy") & "',1)", 4)
            End If
            WriteSQL("delete from MasterPaketKartuDetail where IDPaket='" & butpaketid.Text & "' and Jenis='Klinik' and [Status]=0", 4)
        Next
    End Sub

    Private Sub SaveGigi()
        Dim Tbls As DataTable = gridgigi.DataSource
        Tbls.AcceptChanges()
        Dim Trow() As DataRow = Tbls.Select("[DiscTindakan]>0")
        Dim Tbool As String = "1"
        For i As Integer = 0 To Trow.Length - 1
            If CheckSQL("select * from MasterPaketKartuDetail where IDPaket='" & butpaketid.Text & "' and Jenis='Gigi' and TindakanID=" & Trow(i)("TindakanID").ToString & " and NamaTindakan='" & Trow(i)("NamaTindakan").ToString & "'") = True Then
                'update
                WriteSQL("update MasterPaketKartuDetail set DiscTindakan=" & CDbl(Trow(i)("DiscTindakan")) & " ,NettBayar=" & CDbl(Trow(i)("NettBayar")) & " ,BiayaTindakan=" & CDbl(Trow(i)("BiayaTindakan")) & " , aktif='" & Tbool & "' , [Status]=1  where IDPaket='" & butpaketid.Text & "' and Jenis='Gigi' and TindakanID=" & Trow(i)("TindakanID").ToString & " and NamaTindakan='" & Trow(i)("NamaTindakan").ToString & "'", 4)
            Else
                'save new
                WriteSQL("insert into MasterPaketKartuDetail (IDPaket,Jenis,TindakanID,NamaTindakan,JenisTindakan,BiayaTindakan,DiscTindakan,NettBayar,Aktif,TglNonaktif,[Status]) " & _
                         "values('" & butpaketid.Text & "','Gigi'," & Trow(i)("TindakanID") & ",'" & Trow(i)("NamaTindakan") & "','" & Trow(i)("JenisTindakan") & "'," & CDbl(Trow(i)("BiayaTindakan")) & "," & CDbl(Trow(i)("DiscTindakan")) & "," & CDbl(Trow(i)("NettBayar")) & ",'" & Tbool & "','" & Format(DateAndTime.Now, "MM/dd/yyyy") & "',1)", 4)
            End If
            WriteSQL("delete from MasterPaketKartuDetail where IDPaket='" & butpaketid.Text & "' and Jenis='Gigi' and [Status]=0", 4)
        Next

    End Sub

    Private Sub SaveLab()
        Dim Tbls As DataTable = gridlab.DataSource
        Tbls.AcceptChanges()
        Dim Trow() As DataRow = Tbls.Select("[DiscTindakan]>0")
        Dim Tbool As String = "1"
        For i As Integer = 0 To Trow.Length - 1
            If CheckSQL("select * from MasterPaketKartuDetail where IDPaket='" & butpaketid.Text & "' and Jenis='Lab' and TindakanID=" & Trow(i)("TindakanID").ToString & " and NamaTindakan='" & Trow(i)("NamaTindakan").ToString & "'") = True Then
                'update
                WriteSQL("update MasterPaketKartuDetail set DiscTindakan=" & CDbl(Trow(i)("DiscTindakan")) & " ,NettBayar=" & CDbl(Trow(i)("NettBayar")) & " ,BiayaTindakan=" & CDbl(Trow(i)("BiayaTindakan")) & " , aktif='" & Tbool & "' , [Status]=1  where IDPaket='" & butpaketid.Text & "' and Jenis='Lab' and TindakanID=" & Trow(i)("TindakanID").ToString & " and NamaTindakan='" & Trow(i)("NamaTindakan").ToString & "'", 4)
            Else
                'save new
                WriteSQL("insert into MasterPaketKartuDetail (IDPaket,Jenis,TindakanID,NamaTindakan,JenisTindakan,BiayaTindakan,DiscTindakan,NettBayar,Aktif,TglNonaktif,[Status]) " & _
                         "values('" & butpaketid.Text & "','Lab'," & Trow(i)("TindakanID") & ",'" & Trow(i)("NamaTindakan") & "','" & Trow(i)("JenisTindakan") & "'," & CDbl(Trow(i)("BiayaTindakan")) & "," & CDbl(Trow(i)("DiscTindakan")) & "," & CDbl(Trow(i)("NettBayar")) & ",'" & Tbool & "','" & Format(DateAndTime.Now, "MM/dd/yyyy") & "',1)", 4)
            End If
            WriteSQL("delete from MasterPaketKartuDetail where IDPaket='" & butpaketid.Text & "' and Jenis='Lab' and [Status]=0", 4)
        Next
    End Sub

    Private Sub SetClear()
        ClearHeader()
        ClearKlinik()
        ClearLab()
        ClearGigi()
    End Sub

    Private Sub Kalkulasi()
        Dim Thasil As Double = 0
        Dim Tblk As DataTable = gridklinik.DataSource
        Tblk.AcceptChanges()
        Tblk.Columns("NettBayar").ReadOnly = False
        For Each Trowk As DataRow In Tblk.Rows
            If IsNumeric(Trowk("DiscTindakan")) = True And IsNumeric(Trowk("DiscNilai")) = True Then
                If Trowk("DiscTindakan") > 0 Then
                    Thasil = Trowk("BiayaTindakan") * Trowk("DiscTindakan") / 100
                    Trowk("NettBayar") = Splitmoney(Trowk("BiayaTindakan") - Thasil)
                ElseIf Trowk("DiscNilai") > 0 Then
                    Thasil = Trowk("DiscNilai")
                    Trowk("NettBayar") = Splitmoney(Trowk("BiayaTindakan") - Thasil)
                    Trowk("DiscTindakan") = Splitmoney((Trowk("BiayaTindakan") - Trowk("DiscNilai")) / Trowk("BiayaTindakan") * 100)
                End If

            Else
                If IsNumeric(Trowk("DiscTindakan")) = False Then
                    MsgBox("DiscTindakan harus berbentuk angka. Check kembali : Klinik-" & Trowk("NamaTindakan"))
                    Exit Sub
                ElseIf IsNumeric(Trowk("DiscNilai")) = False Then
                    MsgBox("DiscNilai harus berbentuk angka. Check kembali : Klinik-" & Trowk("NamaTindakan"))
                    Exit Sub
                End If

            End If
        Next
        gridklinik.DataSource = Tblk

        Dim Tblg As DataTable = gridgigi.DataSource
        Tblg.AcceptChanges()
        Tblg.Columns("NettBayar").ReadOnly = False

        For Each Trowg As DataRow In Tblg.Rows
            If IsNumeric(Trowg("DiscTindakan")) = True And IsNumeric(Trowg("DiscNilai")) = True Then
                If Trowg("DiscTindakan") > 0 Then
                    Thasil = Trowg("BiayaTindakan") * Trowg("DiscTindakan") / 100
                    Trowg("NettBayar") = Splitmoney(Trowg("BiayaTindakan") - Thasil)
                ElseIf Trowg("DiscNilai") > 0 Then
                    Thasil = Trowg("DiscNilai")
                    Trowg("NettBayar") = Splitmoney(Trowg("BiayaTindakan") - Thasil)
                    Trowg("DiscTindakan") = Splitmoney((Trowg("BiayaTindakan") - Trowg("DiscNilai")) / Trowg("BiayaTindakan") * 100)
                End If
            Else
                If IsNumeric(Trowg("DiscTindakan")) = False Then
                    MsgBox("DiscTindakan harus berbentuk angka. Check kembali : Klinik-" & Trowg("NamaTindakan"))
                    Exit Sub
                ElseIf IsNumeric(Trowg("DiscNilai")) = False Then
                    MsgBox("DiscNilai harus berbentuk angka. Check kembali : Klinik-" & Trowg("NamaTindakan"))
                    Exit Sub
                End If
            End If
        Next
        gridgigi.DataSource = Tblg

        Dim Tbll As DataTable = gridlab.DataSource
        Tbll.AcceptChanges()
        Tbll.Columns("NettBayar").ReadOnly = False

        For Each Trowl As DataRow In Tbll.Rows
            If IsNumeric(Trowl("DiscTindakan")) = True And IsNumeric(Trowl("DiscNilai")) = True Then
                If Trowl("DiscTindakan") > 0 Then
                    Thasil = Trowl("BiayaTindakan") * Trowl("DiscTindakan") / 100
                    Trowl("NettBayar") = Splitmoney(Trowl("BiayaTindakan") - Thasil)
                ElseIf Trowl("DiscNilai") > 0 Then
                    Thasil = Trowl("DiscNilai")
                    Trowl("NettBayar") = Splitmoney(Trowl("BiayaTindakan") - Thasil)
                    Trowl("DiscTindakan") = Splitmoney((Trowl("BiayaTindakan") - Trowl("DiscNilai")) / Trowl("BiayaTindakan") * 100)
                End If
            Else
                If IsNumeric(Trowl("DiscTindakan")) = False Then
                    MsgBox("DiscTindakan harus berbentuk angka. Check kembali : Klinik-" & Trowl("NamaTindakan"))
                    Exit Sub
                ElseIf IsNumeric(Trowl("DiscNilai")) = False Then
                    MsgBox("DiscNilai harus berbentuk angka. Check kembali : Klinik-" & Trowl("NamaTindakan"))
                    Exit Sub
                End If
            End If
        Next
        gridlab.DataSource = Tbll

    End Sub

    Private Sub MasterPaket_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        SetClear()
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        SetClear()
    End Sub

    Function Checking() As Boolean
        If butpaketid.Text = "" Then
            If txnamapaket.Text = "" Then
                MsgBox("Isi nama paket yang digunakan.")
                Return False
            Else
                If CheckSQL("select * from MasterPaketKartu where NamaPaket='" & txnamapaket.Text & "'") = True Then
                    MsgBox("Nama Paket telah digunakan. Pilih Nama Paket Lainnya.")
                    Return False
                End If
            End If
        ElseIf butpaketid.Text <> "" Then
            If MsgBox("Apakah akan melakukan update paket ?", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then
                MsgBox("Batal Update")
                Return False
            End If
        End If


        If dtend.Value < dtstart.Value Then
            MsgBox("Tanggal akhir harus lebih besar dari tanggal awal")
            Return False
        End If

        If IsNumeric(txjumlahorang.Text) = False Then
            MsgBox("Data Jumlah orang harus angka")
            Return False
        End If

        If IsNumeric(txharga.Text) = False Then
            MsgBox("Harga Paket harus angka")
            Return False
        Else
            If CInt(txharga.Text) <= 0 Then
                MsgBox("Harga Paket tidak boleh dibawah 0")
                Return False
            End If
        End If

        Kalkulasi()

        Return True
    End Function



    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        Button1.PerformClick()
    End Sub

    Public Sub LoadPaket(ByVal Txid As String)
        SetClear()
        Dim Tbls As DataTable = ReadSQL("select * from MasterPaketKartu where IDPaket='" & Txid & "'")
        Dim Trow As DataRow = Tbls.Rows(0)
        butpaketid.Text = Txid
        txnamapaket.Text = Trow("NamaPaket")
        dtstart.Value = Trow("PaketStart")
        dtend.Value = Trow("PaketEnd")
        txjumlahorang.Text = Trow("Jumlah")
        txharga.Text = Trow("HargaPaket")
        If Trow("Aktif") = True Then
            chkclosed.Checked = False
        Else
            chkclosed.Checked = True
            txnamapaket.Enabled = True
            dtstart.Enabled = True
            dtend.Enabled = True
        End If
        LoadGigi()
        LoadKlinik()
        LoadLab()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Checking() = True Then
            If butpaketid.Text = "" Then
                'new
                WriteSQL("insert into MasterPaketKartu (NamaPaket,PaketStart,PaketEnd,Aktif,CreateDate,CreateBy,Jumlah,HargaPaket) values('" & txnamapaket.Text & "','" & Format(dtstart.Value, "MM/dd/yyyy") & "','" & Format(dtend.Value, "MM/dd/yyyy") & "',1,getdate(),'" & PoliKlinik.Lbluser.Text & "'," & txjumlahorang.Text & ",'" & CInt(txharga.Text) & "')", 4)
                butpaketid.Text = ReadSQLNIK("select IDPaket from MasterPaketKartu where NamaPaket='" & txnamapaket.Text & "' and PaketStart='" & Format(dtstart.Value, "MM/dd/yyyy") & "' and PaketEnd='" & Format(dtend.Value, "MM/dd/yyyy") & "' ")
                SaveKlinik()
                SaveGigi()
                SaveLab()
                MsgBox("Data Saved")
            Else
                'update
                If MsgBox("Update data Master Paket ?", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                    Dim Tbool As String = ""
                    If chkclosed.Checked = True Then Tbool = "0" Else Tbool = "1"
                    If chkclosed.Checked = True Then
                        If MsgBox("Apakah yakin paket akan ditutup ?", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                            WriteSQL("update MasterPaketKartu set Aktif=" & Tbool & " , PaketEnd='" & Format(dtend.Value, "MM/dd/yyyy") & "' where IDPaket='" & butpaketid.Text & "'", 4)
                            WriteSQL("update MasterPaketKartuDetail set Aktif=0 , TglNonAktif='" & Format(DateAndTime.Now, "MM/dd/yyyy") & "' where IDPaket='" & butpaketid.Text & "'", 4)
                            MsgBox("Updated. Paket Closed")
                        End If
                    Else
                        WriteSQL("update MasterPaketKartuDetail set [Status]=0 where IDPaket='" & butpaketid.Text & "'", 4)
                        WriteSQL("update MasterPaketKartu set HargaPaket=" & CInt(txharga.Text) & " , Jumlah= " & CInt(txjumlahorang.Text) & " , NamaPaket='" & txnamapaket.Text & "' ,PaketStart='" & Format(dtstart.Value, "MM/dd/yyyy") & "' ,PaketEnd='" & Format(dtend.Value, "MM/dd/yyyy") & "' ,Aktif=" & Tbool & " where IDPaket='" & butpaketid.Text & "'", 4)
                        SaveKlinik()
                        SaveGigi()
                        SaveLab()
                        MsgBox("Data Updated")
                    End If
                Else
                    MsgBox("Abort Saved")
                End If
            End If
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Find.Show()
        Find.Query("select * from MasterPaketKartu", " order by Aktif,NamaPaket", "FindPaketanKartu", 1)
    End Sub

    Private Sub KalkulasiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KalkulasiToolStripMenuItem.Click
        Kalkulasi()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Kalkulasi()
    End Sub
End Class