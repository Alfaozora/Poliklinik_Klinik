Imports System.Drawing

Public Class ReportTagihanPoli
    Dim Tstr As String = ""
    Dim thread As System.Threading.Thread
    Private DB_Keuangan As TLcon

    Function CreateTableInvoice() As DataTable
        Dim Thasil As New DataTable

        insertRowToTbls(Thasil, "tyinterger", "No")
        insertRowToTbls(Thasil, "Typstring", "Tgl lab")
        insertRowToTbls(Thasil, "Typstring", "Jumlah Peserta")
        insertRowToTbls(Thasil, "Typstring", "Keterangan")
        insertRowToTbls(Thasil, "tyinterger", "Total")

        Return Thasil
    End Function

    Function CreateTable() As DataTable
        Dim Thasil As New DataTable

        insertRowToTbls(Thasil, "tyinterger", "No")
        insertRowToTbls(Thasil, "Typstring", "NoJenisBayar")
        insertRowToTbls(Thasil, "typdate", "Tanggal Lab")
        insertRowToTbls(Thasil, "Typstring", "Jumlah Orang")
        insertRowToTbls(Thasil, "tyinterger", "Closed")
        insertRowToTbls(Thasil, "tyinterger", "Unclosed")
        insertRowToTbls(Thasil, "tyinterger", "Jumlah Tagihan")

        For Each Tcol As DataColumn In Thasil.Columns
            Tcol.ReadOnly = True
        Next

        Return Thasil
    End Function

    Public Sub LoadPasien(ByRef Trow() As DataRow)
        If Trow.Length = 0 Then
            SetClear()
        Else
            Dim Tquery As String = ""
            Dim Tcompany As String = ""
            Dim Tjenistransaksi As String = ""
            Dim Tpemeriksaan As String = ""
            Dim ConcatCompany As String = ""
            Dim TgllabStart As Date = "12/31/9998"
            Dim TgllabEnd As Date = "12/31/9998"

            'Company
            If txkodecabang.Text <> "" And cmbpembayaran.SelectedIndex = 0 Then
                ConcatCompany = txcompanycode.Text + "-" + txkodecabang.Text
                Tcompany = " and (c.NoJenisBayar = '" & txcompanycode.Text & "' or c.NoJenisBayar='" & ConcatCompany & "')"
            End If

            'Jenis Transaksi
            If cmbpembayaran.SelectedIndex = 0 Then
                Tjenistransaksi = " AND c.JenisBayar='TAGIHAN'"
            ElseIf cmbpembayaran.SelectedIndex = 1 Then
                Tjenistransaksi = " AND c.JenisBayar='DEBET'"
            ElseIf cmbpembayaran.SelectedIndex = 2 Then
                Tjenistransaksi = " AND c.JenisBayar='TUNAI'"
            ElseIf cmbpembayaran.SelectedIndex = 3 Then
                Tjenistransaksi = " AND c.JenisBayar='CARD'"
            End If

            'Query Utama
            Tquery = "SELECT ROW_NUMBER() OVER (ORDER BY a.Nourut)  AS 'No', a.Translabid, c.NoJenisBayar, a.NoUrut as 'No Lab', a.TglLab as 'Tanggal Lab', b.NoNIP, b.Nama, b.TglLahir as 'Tgl Lahir', b.DomisiliAlamat, '-' as 'pemeriksaan', c.JumlahBayar as 'Tagihan' " & _
            "FROM transaksilab a " & _
            "LEFT JOIN MasterPasien b on a.idinternet = b.NoRekamMedis " & _
            "LEFT JOIN TransaksiLabBayar c on a.TransLabID = c.TransLabID " & _
            "WHERE (CONVERT(date, a.tgllab) between '" & Format(dtprocess.Value, "MM-dd-yyyy") & "' and '" & Format(dtprocessend.Value, "MM-dd-yyyy") & "') "

            Tstr = ""
            Dim Ttemp As String = "("
            For i As Integer = 0 To Trow.Length - 1
                Ttemp = Ttemp & "'" & Trow(i)("No Lab").ToString.Trim & "',"
            Next
            Tstr = Strings.Left(Ttemp, Ttemp.Length - 1) & ")"

            Dim Tbls As DataTable = New DataTable
            Dim Tdata As DataTable = New DataTable
            Dim TDetailPemeriksaan As DataTable = New DataTable
            Dim DetailPemeriksaan As String = ""
            Dim TtempDetailPemeriksaan As String = ""

            Tbls = ReadSQL(Tquery + Tcompany + Tjenistransaksi + " and a.Nourut in " & Tstr & " ORDER BY c.NoJenisBayar, a.TglLab, a.nourut asc")
            Tdata = CreateTable()
            Tdata.Rows.Clear()

            Dim temppt As String = ""
            Dim temppt2 As String = ""
            Dim number As Integer = 0

            If Tbls.Rows.Count > 0 Then
                For Each TrowData As DataRow In Tbls.Rows
                    Dim Tnew As DataRow = Tdata.NewRow

                    'Periode Tanggal
                    If TgllabStart = "12/31/9998" And TgllabEnd = "12/31/9998" Then
                        TgllabStart = Format(TrowData("Tanggal Lab"), "MM-dd-yyyy")
                        TgllabEnd = Format(TrowData("Tanggal Lab"), "MM-dd-yyyy")
                    Else
                        If Format(TrowData("Tanggal Lab"), "MM-dd-yyyy") < TgllabStart Then
                            TgllabStart = Format(TrowData("Tanggal Lab"), "MM-dd-yyyy")
                        ElseIf Format(TrowData("Tanggal Lab"), "MM-dd-yyyy") > TgllabEnd Then
                            TgllabEnd = Format(TrowData("Tanggal Lab"), "MM-dd-yyyy")
                        End If
                    End If

                    'Create Number Start
                    temppt2 = TrowData("NoJenisBayar")
                    If temppt2.Contains("-") = True Then
                        Dim Tsplit() As String = temppt2.Split("-")
                        temppt2 = Tsplit(0).ToString.Trim.ToUpper
                    Else
                        temppt2 = temppt2.ToUpper
                    End If

                    If temppt = "" Then
                        number = number + 1
                    ElseIf temppt = temppt2 Then
                        number = number + 1
                    Else
                        number = 0
                        number = number + 1
                    End If

                    temppt = TrowData("NoJenisBayar")
                    If temppt.Contains("-") = True Then
                        Dim Tsplit() As String = temppt.Split("-")
                        Tnew("NoJenisBayar") = Tsplit(0).ToString.Trim.ToUpper
                        temppt = Tsplit(0).ToString.Trim.ToUpper
                    Else
                        Tnew("NoJenisBayar") = temppt.ToUpper
                        temppt = temppt.ToUpper
                    End If
                    'Create Number End

                    Tnew("No Lab") = TrowData("No Lab")
                    Tnew("No") = number
                    Tnew("Tanggal Lab") = TrowData("Tanggal Lab")
                    Tnew("NIP") = TrowData("NoNIP")
                    Tnew("Nama") = TrowData("Nama")
                    Tnew("Tgl Lahir") = TrowData("Tgl Lahir")
                    Tnew("Alamat") = TrowData("DomisiliAlamat")

                    TtempDetailPemeriksaan = ""
                    TDetailPemeriksaan = ReadSQL("SELECT b.NamaTindakan FROM TransaksiLab a LEFT JOIN TransaksiLabDetail b on a.TransLabID=b.TransLabID WHERE a.NoUrut = '" & TrowData("No Lab") & "'")
                    For Each TRowDetailPemeriksaan As DataRow In TDetailPemeriksaan.Rows
                        TtempDetailPemeriksaan = TtempDetailPemeriksaan & "" & TRowDetailPemeriksaan("NamaTindakan").ToString.Trim & ", "
                    Next
                    DetailPemeriksaan = Strings.Left(TtempDetailPemeriksaan, TtempDetailPemeriksaan.Length - 2)

                    'Sentence
                    'Tnew("pemeriksaan") = StrConv(DetailPemeriksaan, VbStrConv.ProperCase)
                    Tnew("pemeriksaan") = DetailPemeriksaan
                    Tnew("Tagihan") = TrowData("Tagihan")
                    Tnew("Translabid") = TrowData("Translabid")

                    Tdata.Rows.Add(Tnew)
                Next

                If TgllabStart = TgllabEnd Then
                    txtgllab.Text = Format(TgllabStart, "dd") & " " & BulanIndonesia(Format(TgllabStart, "MM")) & " " & Format(TgllabStart, "yyyy")
                Else
                    txtgllab.Text = Format(TgllabStart, "dd") & " " & BulanIndonesia(Format(TgllabStart, "MM")) & " " & Format(TgllabStart, "yyyy") & " s/d " & Format(TgllabEnd, "dd") & " " & BulanIndonesia(Format(TgllabEnd, "MM")) & " " & Format(TgllabEnd, "yyyy")
                End If

                gridpasien.DataSource = Tdata
                GridView1.Columns("No").Visible = False
                GridView1.Columns("Translabid").Visible = False
            End If
        End If
    End Sub

    Private Sub SetClear()
        gridpasien.DataSource = CreateTable()

        txcompanycode.ResetText()
        txkodecabang.ResetText()
        cmbpembayaran.SelectedIndex = 0
        cmbjenistransaksi.SelectedIndex = 0
        dtprocess.Value = DateTime.Now
        dtprocessend.Value = DateTime.Now
        rdstatus3.Checked = True
        rdjenis1.Checked = True
        butfindcompany.Enabled = True
        cmbjenistransaksi.Enabled = True
        rdstatus1.Enabled = True
        rdstatus2.Enabled = True
        rdstatus3.Enabled = True
        rdjenis1.Enabled = True
        rdjenis2.Enabled = True
    End Sub

    Private Sub CloseToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub SetConnection()
        ' Set Parameter Server Online
        Dim serverOnline_IP As String = Utility.GetConfig("ServerOnline_IP")
        Dim serverOnline_UserID As String = Utility.GetConfig("ServerOnline_UserID")
        Dim serverOnline_Password As String = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerOnline_Password"), "albert")

        ' Set DB Keuangan 1 (mitramed_keu)
        DB_Keuangan.Tip = serverOnline_IP
        DB_Keuangan.Tid = serverOnline_UserID
        DB_Keuangan.Tpass = serverOnline_Password
        DB_Keuangan.Tdb = Utility.GetConfig("ServerOnlineKeuangan_DB")
    End Sub

    Private Sub ReportTagihanPoli_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        SetFormHeightWeight(Me, 0.95, 0.8)
        NewToolStripMenuItem1.PerformClick()
        Control.CheckForIllegalCrossThreadCalls = False
        SetConnection()
    End Sub

    Private Sub NewToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem1.Click
        SetClear()
    End Sub

    Private Sub PilihCompanyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Find.Show()
        Find.Query("SELECT IDCompany, CompanyCode, CompanyNama, NoCompany FROM mastercompany a", " ORDER BY a.idcompany desc", "FindCabangSummary", 2)
    End Sub

    Public Sub LoadCompany(ByRef txkode As String, ByRef txlocationket As String)
        'txcompany.Text = txlocationket
        txkodecabang.Text = txkode
    End Sub

    Private Sub butfindcompany_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butfindcompany.Click
        Find.Show()
        Find.Query("SELECT IDCompany, CompanyCode, CompanyNama, NoCompany FROM mastercompany a WHERE getdate() between StartDate and EndDate", " ORDER BY a.idcompany desc", "FindCabangReportTagihanPoli", 2)
    End Sub

    Private Sub butfindpaket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Find.Show()
        Find.Query("SELECT PaketID as ID,PaketNama,PaketKeterangan,PARSENAME(CONVERT(varchar,convert(money,PaketNilaiTotal),1),2) as PaketNilaiTotal,PaketStart,PaketEnd FROM MasterLabPaket WHERE GETDATE() between PaketStart and PaketEnd ", " ORDER BY PaketID DESC ", "FindPaketIDReportTagihanPoli", 2)
    End Sub

    Private Sub buttambahpasien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttambahpasien.Click
        If dtprocessend.Value < dtprocess.Value Then
            MsgBox("Tanggal Akhir tidak boleh melebihi tanggal mulai.")
            Exit Sub
        End If

        Dim Tquery As String = ""
        Dim Tcompany As String = ""
        Dim Tjenistransaksi As String = ""
        Dim Tstatus As String = ""
        Dim Tpemeriksaan As String = ""
        Dim ConcatCompany As String = ""
        Dim TgllabStart As Date = "12/31/9998"
        Dim TgllabEnd As Date = "12/31/9998"

        'Company
        If txkodecabang.Text <> "" And cmbpembayaran.SelectedIndex = 0 Then
            ConcatCompany = txcompanycode.Text + "-" + txkodecabang.Text
            Tcompany = " and (c.NoJenisBayar = '" & txcompanycode.Text & "' or c.NoJenisBayar='" & ConcatCompany & "')"
        End If

        'Jenis Transaksi
        If cmbpembayaran.SelectedIndex = 0 Then
            Tjenistransaksi = " AND c.JenisBayar='TAGIHAN'"
        ElseIf cmbpembayaran.SelectedIndex = 1 Then
            Tjenistransaksi = " AND c.JenisBayar='DEBET'"
        ElseIf cmbpembayaran.SelectedIndex = 2 Then
            Tjenistransaksi = " AND c.JenisBayar='TUNAI'"
        ElseIf cmbpembayaran.SelectedIndex = 3 Then
            Tjenistransaksi = " AND c.JenisBayar='CARD'"
        End If

        'Status Bayar
        If rdstatus1.Checked = True Then
            Tstatus = " AND a.RekapID is not null"
        ElseIf rdstatus2.Checked = True Then
            Tstatus = " AND a.RekapID is null"
        ElseIf rdstatus3.Checked = True Then
            Tstatus = " "
        End If

        'Query Utama
        If cmbjenistransaksi.SelectedIndex = 0 Then
            Tquery = "SELECT CAST(t1.TglPoli AS DATE) as 'Tanggal Lab', t1.NoJenisBayar, SUM(t1.JumlahBayar)  as 'JumlahBayar', t1.RekapID, COUNT(t1.[Jumlah Transaksi]) as 'Jumlah Transaksi' FROM " & _
                         "(SELECT TglPoli, c.NoJenisBayar, c.JumlahBayar as 'JumlahBayar', a.RekapID, NoUrut as 'Jumlah Transaksi' " & _
                         "FROM TransaksiPoli a " & _
                         "LEFT JOIN MasterPasien b on a.idinternet = b.NoRekamMedis " & _
                         "LEFT JOIN TransaksiPoliBayarAwal c on a.TransPoliID = c.TransPoliID " & _
                         "WHERE a.deleted <> 1" & Tcompany & Tjenistransaksi & Tstatus & " and (CONVERT(date, a.TglPoli) between '" & Format(dtprocess.Value, "MM-dd-yyyy") & "' and '" & Format(dtprocessend.Value, "MM-dd-yyyy") & "') " & _
                     "UNION ALL " & _
                         "SELECT TglPoli, c.NoJenisBayar, c.JumlahBayar as 'JumlahBayar', a.RekapID, NoUrut as 'Jumlah Transaksi' " & _
                         "FROM TransaksiPoli a " & _
                         "LEFT JOIN MasterPasien b on a.idinternet = b.NoRekamMedis " & _
                         "LEFT JOIN TransaksiPoliBayar c on a.TransPoliID = c.TransPoliID " & _
                         "WHERE a.deleted <> 1" & Tcompany & Tjenistransaksi & Tstatus & " and (CONVERT(date, a.TglPoli) between '" & Format(dtprocess.Value, "MM-dd-yyyy") & "' and '" & Format(dtprocessend.Value, "MM-dd-yyyy") & "')) as t1 " & _
                     "GROUP BY NoJenisBayar, t1.TglPoli, RekapID " & _
                     "ORDER BY NoJenisBayar, t1.TglPoli, RekapID"
        ElseIf cmbjenistransaksi.SelectedIndex = 1 Then
            Tquery = "SELECT CAST(t1.TglGigi AS DATE) as 'Tanggal Lab', t1.NoJenisBayar, SUM(t1.JumlahBayar)  as 'JumlahBayar', t1.RekapID, COUNT(t1.[Jumlah Transaksi]) as 'Jumlah Transaksi' FROM " & _
                         "(SELECT TglGigi, c.NoJenisBayar, c.JumlahBayar as 'JumlahBayar', a.RekapID, NoUrut as 'Jumlah Transaksi' " & _
                         "FROM TransaksiGigi a " & _
                         "LEFT JOIN MasterPasien b on a.idinternet = b.NoRekamMedis " & _
                         "LEFT JOIN TransaksiGigiBayarAwal c on a.TransGigiID = c.TransGigiID " & _
                         "WHERE a.deleted <> 1" & Tcompany & Tjenistransaksi & Tstatus & " and (CONVERT(date, a.TglGigi) between '" & Format(dtprocess.Value, "MM-dd-yyyy") & "' and '" & Format(dtprocessend.Value, "MM-dd-yyyy") & "') " & _
                     "UNION ALL " & _
                         "SELECT TglGigi, c.NoJenisBayar, c.JumlahBayar as 'JumlahBayar', a.RekapID, NoUrut as 'Jumlah Transaksi' " & _
                         "FROM TransaksiGigi a " & _
                         "LEFT JOIN MasterPasien b on a.idinternet = b.NoRekamMedis " & _
                         "LEFT JOIN TransaksiGigiBayar c on a.TransGigiID = c.TransGigiID " & _
                         "WHERE a.deleted <> 1" & Tcompany & Tjenistransaksi & Tstatus & " and (CONVERT(date, a.TglGigi) between '" & Format(dtprocess.Value, "MM-dd-yyyy") & "' and '" & Format(dtprocessend.Value, "MM-dd-yyyy") & "')) as t1 " & _
                     "GROUP BY NoJenisBayar, t1.TglGigi, RekapID " & _
                     "ORDER BY NoJenisBayar, t1.TglGigi, RekapID"
        ElseIf cmbjenistransaksi.SelectedIndex = 2 Then
            Tquery = "SELECT CAST(TindakanTgl AS DATE) as 'Tanggal Lab', c.NoJenisBayar, sum(c.JumlahBayar) as 'JumlahBayar', a.RekapID, COUNT(a.TransAdminID) as 'Jumlah Transaksi' " & _
                     "FROM TransaksiAdmin a " & _
                     "LEFT JOIN MasterPasien b on a.idinternet=b.NoRekamMedis " & _
                     "LEFT JOIN TransaksiAdminBayar c on a.TransAdminID=c.TransAdminID " & _
                     "WHERE a.deleted <> 1" & Tcompany & Tjenistransaksi & Tstatus & " and (CONVERT(date, a.TindakanTgl) between '" & Format(dtprocess.Value, "MM-dd-yyyy") & "' and '" & Format(dtprocessend.Value, "MM-dd-yyyy") & "') GROUP BY NoJenisBayar, CAST(TindakanTgl AS DATE), RekapID ORDER BY NoJenisBayar, CAST(TindakanTgl AS DATE), RekapID"
        End If

        Dim Tbls As DataTable = ReadSQL(Tquery)

        If Tbls.Rows.Count > 0 Then
            Dim Tdata As DataTable = New DataTable
            Dim TDetailPemeriksaan As DataTable = New DataTable
            Dim DetailPemeriksaan As String = ""
            Dim TtempDetailPemeriksaan As String = ""

            Tdata = CreateTable()
            Tdata.Rows.Clear()

            Dim temppt As String = ""
            Dim temppt2 As String = ""
            Dim number As Integer = 0
            Dim totalclosed As Integer = 0
            Dim totalunclosed As Integer = 0
            Dim totaltagihan As Integer = 0
            Dim tgltagihan As Date = "12/31/9998"
            Dim nourut As Integer = 0

            If Tbls.Rows.Count > 0 Then
                For Each TrowData As DataRow In Tbls.Rows
                    'Periode Tanggal
                    If TgllabStart = "12/31/9998" And TgllabEnd = "12/31/9998" Then
                        TgllabStart = Format(TrowData("Tanggal Lab"), "MM-dd-yyyy")
                        TgllabEnd = Format(TrowData("Tanggal Lab"), "MM-dd-yyyy")
                    Else
                        If Format(TrowData("Tanggal Lab"), "MM-dd-yyyy") < TgllabStart Then
                            TgllabStart = Format(TrowData("Tanggal Lab"), "MM-dd-yyyy")
                        ElseIf Format(TrowData("Tanggal Lab"), "MM-dd-yyyy") > TgllabEnd Then
                            TgllabEnd = Format(TrowData("Tanggal Lab"), "MM-dd-yyyy")
                        End If
                    End If

                    'Summary Reporting
                    temppt2 = TrowData("NoJenisBayar")
                    If temppt2.Contains("-") = True Then
                        Dim Tsplit() As String = temppt2.Split("-")
                        temppt2 = Tsplit(0).ToString.Trim.ToUpper
                    Else
                        temppt2 = temppt2.ToUpper
                    End If

                    If rdjenis1.Checked = True Then
                        If temppt = "" Then
                            number = number + TrowData("Jumlah Transaksi")
                            nourut = nourut + 1
                        ElseIf temppt = temppt2 Then
                            number = number + TrowData("Jumlah Transaksi")
                        Else
                            Dim Tnew As DataRow = Tdata.NewRow
                            Tnew("No") = nourut
                            Tnew("Tanggal Lab") = TrowData("Tanggal Lab")
                            Tnew("NoJenisBayar") = temppt.ToUpper
                            Tnew("Jumlah Orang") = number & " Transaksi"
                            Tnew("Closed") = totalclosed
                            Tnew("Unclosed") = totalunclosed
                            Tnew("Jumlah Tagihan") = totaltagihan
                            Tdata.Rows.Add(Tnew)

                            number = TrowData("Jumlah Transaksi")
                            nourut = nourut + 1
                            totalclosed = 0
                            totalunclosed = 0
                            totaltagihan = 0
                        End If
                    ElseIf rdjenis2.Checked = True Then
                        If temppt = "" Then
                            tgltagihan = Format(TrowData("Tanggal Lab"), "MM-dd-yyyy")
                            number = number + TrowData("Jumlah Transaksi")
                            nourut = nourut + 1
                        ElseIf temppt = temppt2 And Format(TrowData("Tanggal Lab"), "MM-dd-yyyy") = tgltagihan Then
                            number = number + TrowData("Jumlah Transaksi")
                        Else
                            Dim Tnew As DataRow = Tdata.NewRow
                            Tnew("No") = nourut
                            Tnew("Tanggal Lab") = Format(tgltagihan, "MM-dd-yyyy")
                            Tnew("NoJenisBayar") = temppt.ToUpper
                            Tnew("Jumlah Orang") = number & " Transaksi"
                            Tnew("Closed") = totalclosed
                            Tnew("Unclosed") = totalunclosed
                            Tnew("Jumlah Tagihan") = totaltagihan
                            Tdata.Rows.Add(Tnew)

                            If temppt = temppt2 Then
                                nourut = nourut + 1
                            Else
                                nourut = 1
                            End If

                            number = TrowData("Jumlah Transaksi")
                            totalclosed = 0
                            totalunclosed = 0
                            totaltagihan = 0
                            tgltagihan = Format(TrowData("Tanggal Lab"), "MM-dd-yyyy")
                        End If
                    End If

                    If IsDBNull(TrowData("RekapID")) = True Then
                        totalunclosed = totalunclosed + TrowData("JumlahBayar")
                        totaltagihan = totaltagihan + TrowData("JumlahBayar")
                    ElseIf IsDBNull(TrowData("RekapID")) = False Then
                        totalclosed = totalclosed + TrowData("JumlahBayar")
                        totaltagihan = totaltagihan + TrowData("JumlahBayar")
                    End If

                    temppt = TrowData("NoJenisBayar")
                    If temppt.Contains("-") = True Then
                        Dim Tsplit() As String = temppt.Split("-")
                        temppt = Tsplit(0).ToString.Trim.ToUpper
                    Else
                        temppt = temppt.ToUpper
                    End If
                Next

                Dim Tlastnew As DataRow = Tdata.NewRow
                Tlastnew("No") = nourut
                Tlastnew("Tanggal Lab") = tgltagihan
                Tlastnew("NoJenisBayar") = temppt.ToUpper
                Tlastnew("Jumlah Orang") = number & " Transaksi"
                Tlastnew("Closed") = totalclosed
                Tlastnew("Unclosed") = totalunclosed
                Tlastnew("Jumlah Tagihan") = totaltagihan
                Tdata.Rows.Add(Tlastnew)

                If TgllabStart = TgllabEnd Then
                    txtgllab.Text = Format(TgllabStart, "dd") & " " & BulanIndonesia(Format(TgllabStart, "MM")) & " " & Format(TgllabStart, "yyyy")
                Else
                    txtgllab.Text = Format(TgllabStart, "dd") & " " & BulanIndonesia(Format(TgllabStart, "MM")) & " " & Format(TgllabStart, "yyyy") & " s/d " & Format(TgllabEnd, "dd") & " " & BulanIndonesia(Format(TgllabEnd, "MM")) & " " & Format(TgllabEnd, "yyyy")
                End If

                gridpasien.DataSource = Tdata
                If rdjenis2.Checked = True Then
                    GridView1.Columns("Tanggal Lab").Visible = True
                Else
                    GridView1.Columns("Tanggal Lab").Visible = False
                End If
                GridView1.Columns("No").Visible = False
            End If

            'disable rd status
            If rdstatus1.Checked = True Then
                rdstatus2.Enabled = False
                rdstatus3.Enabled = False
            ElseIf rdstatus2.Checked = True Then
                rdstatus1.Enabled = False
                rdstatus3.Enabled = False
            ElseIf rdstatus3.Checked = True Then
                rdstatus1.Enabled = False
                rdstatus2.Enabled = False
            End If

            'disable rd jenis
            If rdjenis1.Checked = True Then
                rdjenis2.Enabled = False
            ElseIf rdjenis2.Checked = True Then
                rdjenis1.Enabled = False
            End If

            cmbjenistransaksi.Enabled = False
            butfindcompany.Enabled = False
        Else
            MsgBox("Tidak ada data yang ditampilkan.", MsgBoxStyle.Exclamation, "Warning!")
            Exit Sub
        End If
    End Sub

    Private Sub exportexcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exportexcel.Click
        Dim Tbls As DataTable = gridpasien.DataSource
        If Tbls.Rows.Count > 0 Then
            Dim saveFileDialog1 As New SaveFileDialog
            saveFileDialog1.Filter = "Excel File|*.xls"
            saveFileDialog1.Title = "Save an Excel File"
            saveFileDialog1.ShowDialog()
            If saveFileDialog1.CheckPathExists = False Then
                MsgBox("Path tidak ada. Check kembali")
            Else
                If saveFileDialog1.CheckFileExists = True Then
                    MsgBox("Telah ada data dengan nama tersebut. Rubah nama save")
                Else
                    gridpasien.ExportToExcel(saveFileDialog1.FileName.ToString)
                    MsgBox("File Saved")
                End If
            End If
        Else
            MsgBox("Tidak ada data yg ditampilkan.")
        End If
    End Sub

    Private Sub clear_invoice()
        txnorek.ResetText()
        txnamarek.ResetText()
        txtgljatuhtempo.ResetText()
        txbankid.ResetText()
        txnamabank.ResetText()
    End Sub

    Private Sub exportpdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exportpdf.Click

        Dim Tbls As DataTable = gridpasien.DataSource
        Dim Tdata As DataTable = New DataTable
        If Tbls.Rows.Count > 0 Then
            Report = New XtraReport

            If rdjenis1.Checked Then
                Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\Laporan\LapRekapSummaryTagihanLab.repx", True)
            ElseIf rdjenis2.Checked Then
                Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\Laporan\LapRekapDetailTagihanLab.repx", True)
            End If
            Report.DataSource = Tbls

            If rdjenis1.Checked = True Then
                Report.Bands.Item(BandKind.ReportHeader).Controls("lbljenissetoran").Text = "LAPORAN SUMMARY POLI UMUM (" & cmbjenistransaksi.Text & ")"
            ElseIf rdjenis2.Checked = True Then
                Report.Bands.Item(BandKind.ReportHeader).Controls("lbljenissetoran").Text = "LAPORAN DETAIL POLI UMUM (" & cmbjenistransaksi.Text & ")"
            End If

            Report.Bands.Item(BandKind.ReportHeader).Controls("lbltanggal").Text = txtgllab.Text
            Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:ss") & " By " & PoliKlinik.Lbluser.Text

            'Report.RunDesigner()
            Report.ShowPreview()
            'Report.Print()
        Else
            MsgBox("Tidak ada data yg ditampilkan.")
            Exit Sub
        End If
    End Sub

    Function SetNoTagihanCompany() As String
        Dim NoTagihan As String = ""
        Dim NoRef1 As String = ""
        Dim NoRef2 As String = ""
        Dim NoRef3 As String = ""

        Dim angka2 As String = "0001"
        Dim angka As String = ReadThemysqlNIK("SELECT concat(lpad(LEFT(notagihancompany,4)+1,4,0)) FROM acctransrekaptagihan WHERE tgltagihan BETWEEN DATE_FORMAT('" & Format(DateAndTime.Now, "yyyy-MM-dd") & "' ,'%Y-%m-01 %T') AND LAST_DAY('" & Format(DateAndTime.Now, "yyyy-MM-dd") & "') ORDER BY notagihancompany desc limit 1", DB_Keuangan)

        If angka = "" Or angka = "-" Then
            NoRef1 = angka2
        ElseIf angka <> "" Then
            NoRef1 = angka
        End If

        NoRef2 = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='KodeInvoiceLab'")
        NoRef3 = GetRomes(DateAndTime.Now.Month) & "/" & Format(DateAndTime.Now, "yyyy")
        NoTagihan = NoRef1 & "/" & NoRef2 & "/" & NoRef3

        Return NoTagihan
    End Function
End Class


