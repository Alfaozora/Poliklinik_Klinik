Imports System.Drawing
Imports System.IO

Public Class RekapTagihanLab
    Dim Tstr As String = ""
    Dim thread As System.Threading.Thread
    
    Private DB_Keuangan As TLcon
    Private DB_Keuangan2 As TLcon
    Private DB_Jurnal As TLcon

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

        ' Set DB Keuangan 2 (mitramed_keu2019)
        DB_Keuangan2.Tip = serverOnline_IP
        DB_Keuangan2.Tid = serverOnline_UserID
        DB_Keuangan2.Tpass = serverOnline_Password
        DB_Keuangan2.Tdb = Utility.GetConfig("ServerOnlineKeuangan2_DB")

        ' Set DB Jurnal
        DB_Jurnal.Tip = Utility.GetConfig("ServerJurnal_IP")
        DB_Jurnal.Tid = Utility.GetConfig("ServerJurnal_UserID")
        DB_Jurnal.Tpass = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerJurnal_Password"), "albert")
        DB_Jurnal.Tdb = Utility.GetConfig("ServerJurnal_DB")
    End Sub

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
        insertRowToTbls(Thasil, "Typstring", "No Lab")
        insertRowToTbls(Thasil, "typdate", "Tanggal Lab")
        insertRowToTbls(Thasil, "Typstring", "NIP")
        insertRowToTbls(Thasil, "Typstring", "Nama")
        insertRowToTbls(Thasil, "typdate", "Tgl Lahir")
        insertRowToTbls(Thasil, "Typstring", "Alamat") '
        insertRowToTbls(Thasil, "Typstring", "pemeriksaan")
        insertRowToTbls(Thasil, "tyinterger", "Tagihan")
        insertRowToTbls(Thasil, "tyinterger", "Translabid")
        insertRowToTbls(Thasil, "Typstring", "mesin")
        insertRowToTbls(Thasil, "Typstring", "kartu")

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
            Dim Torderby As String = ""
            Dim ConcatCompany As String = ""
            Dim TgllabStart As Date = "12/31/9998"
            Dim TgllabEnd As Date = "12/31/9998"

            'Company
            If txkodecabang.Text <> "" And cmbpembayaran.SelectedIndex = 0 Then
                ConcatCompany = txcompanycode.Text + "-" + txkodecabang.Text
                Tcompany = " and (c.NoJenisBayar = '" & txcompanycode.Text & "' or c.NoJenisBayar='" & ConcatCompany & "')"
            ElseIf txkodecabang.Text <> "" Then
                ConcatCompany = txcompanycode.Text + "-" + txkodecabang.Text
                Tcompany = " and b.PTID = '" & txkodecabang.Text & "'"
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
            Tquery = "SELECT ROW_NUMBER() OVER (ORDER BY a.Nourut)  AS 'No', a.Translabid, a.DetailPemeriksaan, c.NoJenisBayar, a.NoUrut as 'No Lab', a.TglLab as 'Tanggal Lab', b.NoNIP as 'NIP',b.Nama,b.TglLahir as 'Tgl Lahir',b.DomisiliAlamat, '-' as 'pemeriksaan', c.JumlahBayar-c.Kembali as 'Tagihan', c.mesin, c.kartu " & _
            "FROM transaksilab a " & _
            "LEFT JOIN MasterPasien b on a.idinternet = b.NoRekamMedis " & _
            "LEFT JOIN TransaksiLabBayar c on a.TransLabID=c.TransLabID " & _
            "WHERE (CONVERT(date, a.tgllab) between '" & Format(dtprocess.Value, "MM-dd-yyyy") & "' and '" & Format(dtprocessend.Value, "MM-dd-yyyy") & "') "

            'Order By
            If cmbpembayaran.Text.Trim <> "TAGIHAN" Then
                Torderby = " order by c.mesin, a.TglLab, a.nourut asc"
            Else
                Torderby = " order by c.NoJenisBayar, a.TglLab, a.nourut asc"
            End If

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

            Tbls = ReadSQL(Tquery + Tcompany + Tjenistransaksi + " and a.Nourut in " & Tstr & Torderby)
            Tdata = CreateTable()
            Tdata.Rows.Clear()

            Dim temppt As String = ""
            Dim temppt2 As String = ""
            Dim number As Integer = 0
            Dim NoKartu As String = ""

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
                    If cmbpembayaran.Text.Trim <> "TAGIHAN" Then
                        temppt2 = TrowData("mesin")
                        NoKartu = TrowData("NoJenisBayar")
                    Else
                        temppt2 = TrowData("NoJenisBayar")
                    End If

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

                    If cmbpembayaran.Text.Trim <> "TAGIHAN" Then
                        temppt = TrowData("mesin")
                    Else
                        temppt = TrowData("NoJenisBayar")
                    End If

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
                    Tnew("NIP") = TrowData("NIP")
                    Tnew("Nama") = TrowData("Nama").ToString.ToUpper
                    Tnew("Tgl Lahir") = TrowData("Tgl Lahir")
                    Tnew("Alamat") = TrowData("DomisiliAlamat")
                    If IsDBNull(TrowData("mesin")) = False Then Tnew("mesin") = TrowData("mesin") Else Tnew("mesin") = "-"
                    If IsDBNull(TrowData("kartu")) = False Then Tnew("kartu") = NoKartu & " (" & TrowData("kartu") & ")" Else Tnew("kartu") = "-"

                    If IsDBNull(TrowData("DetailPemeriksaan")) = True Then
                        DetailPemeriksaan = SetTindakanDetail(TrowData("TransLabID"), "LAB", Nothing)
                    ElseIf IsDBNull(TrowData("DetailPemeriksaan")) = False Then
                        DetailPemeriksaan = TrowData("DetailPemeriksaan")
                    End If

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
                butfindcompany.Enabled = False
                cmbpembayaran.Enabled = False
                cball.Enabled = False
            End If
        End If
    End Sub

    Private Sub SetClear()
        gridpasien.DataSource = CreateTable()

        txcompanycode.ResetText()
        txkodecabang.ResetText()
        rdyes.Checked = True
        cmbpembayaran.SelectedIndex = 0
        cmbjeniscetak.SelectedIndex = 0
        dtprocess.Value = DateAndTime.Now
        dtprocessend.Value = DateAndTime.Now
        butfindcompany.Enabled = True
        cmbpembayaran.Enabled = True
        cmbjeniscetak.Enabled = True
        cball.Checked = False
        cball.Enabled = True
    End Sub

    Private Sub CloseToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub RekapTagihanLab_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Find.Query("SELECT IDCompany, CompanyCode, CompanyNama, NoCompany FROM mastercompany a WHERE getdate() between StartDate and EndDate", " ORDER BY a.idcompany desc", "FindCabangRekapTagihanLab", 2)
    End Sub

    Private Sub butfindpaket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Find.Show()
        Find.Query("SELECT PaketID as ID,PaketNama,PaketKeterangan,PARSENAME(CONVERT(varchar,convert(money,PaketNilaiTotal),1),2) as PaketNilaiTotal,PaketStart,PaketEnd FROM MasterLabPaket WHERE GETDATE() between PaketStart and PaketEnd ", " order by PaketID DESC ", "FindPaketIDRekapTagihanLab", 2)
    End Sub

    Private Sub buttambahpasien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttambahpasien.Click
        If dtprocessend.Value < dtprocess.Value Then
            MsgBox("Tanggal Akhir tidak boleh melebihi tanggal mulai.", MsgBoxStyle.Exclamation, "Warning!")
            Exit Sub
        End If

        Dim Tquery As String = ""
        Dim Tcompany As String = ""
        Dim Tjenistransaksi As String = ""
        Dim ConcatCompany As String = ""
        Dim Talltransaksi As String = ""

        'Company
        If txkodecabang.Text <> "" And cmbpembayaran.SelectedIndex = 0 Then
            ConcatCompany = txcompanycode.Text + "-" + txkodecabang.Text
            Tcompany = " and (c.NoJenisBayar = '" & txcompanycode.Text & "' or c.NoJenisBayar='" & ConcatCompany & "')"
        ElseIf txkodecabang.Text <> "" Then
            ConcatCompany = txcompanycode.Text + "-" + txkodecabang.Text
            Tcompany = " and b.PTID = '" & txkodecabang.Text & "'"
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

        'Tampilan Transaksi
        If cball.Checked = True Then
            Talltransaksi = ""
        ElseIf cball.Checked = False Then
            If cmbpembayaran.SelectedIndex = 0 Then
                Talltransaksi = " AND a.RekapID is null"
            End If
        End If

        'Query Utama
        Tquery = "SELECT a.NoUrut as 'No Lab',a.TglLab as 'Tanggal Lab', b.NoNIP as 'NIP', b.Nama, b.TglLahir as 'Tgl Lahir', b.DomisiliAlamat, c.JumlahBayar-c.Kembali as 'Tagihan' " & _
                 "FROM transaksilab a " & _
                 "LEFT JOIN MasterPasien b ON a.idinternet = b.NoRekamMedis " & _
                 "LEFT JOIN TransaksiLabBayar c ON a.TransLabID=c.TransLabID " & _
                 "WHERE ((NoUrut like '%L%' and a.Status<>'OPEN'" & Tcompany & Tjenistransaksi & ") or (a.NoUrut like '%M%' and a.Status<>'OPEN' and a.SendKeu is not null" & Tcompany & Tjenistransaksi & ")) " & Talltransaksi & " and a.deleted <> 1 and (CONVERT(date, a.tgllab) between '" & Format(dtprocess.Value, "MM-dd-yyyy") & "' and '" & Format(dtprocessend.Value, "MM-dd-yyyy") & "') "

        Dim TblsNew As DataTable = ReadSQL(Tquery)

        If TblsNew.Rows.Count > 0 Then
            FindMultiple.Show()
            FindMultiple.Query(Tquery, " order by a.TglLab, a.nourut asc", "RekapTagihanLab", 2)
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
        Dim NoTagihan As String = ""

        Dim Tdata As DataTable = New DataTable
        If Tbls.Rows.Count > 0 Then
            Report = New XtraReport

            If cmbjeniscetak.SelectedIndex = 0 Then
                'Rekap Tagihan
                If rdyes.Checked Then
                    If cmbpembayaran.Text.Trim = "CARD" Or cmbpembayaran.Text.Trim = "DEBET" Then
                        Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\RekapPendapatanLabPemeriksaanEDC.repx", True)
                    Else
                        Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\RekapPendapatanLabPemeriksaan.repx", True)
                    End If
                ElseIf rdno.Checked Then
                    If cmbpembayaran.Text.Trim = "CARD" Or cmbpembayaran.Text.Trim = "DEBET" Then
                        Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\RekapPendapatanLabNonPemeriksaanEDC.repx", True)
                    Else
                        Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\RekapPendapatanLabNonPemeriksaan.repx", True)
                    End If
                End If
                Report.DataSource = Tbls
            ElseIf cmbjeniscetak.SelectedIndex = 1 Then
                'Tanda Terima
                Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\RekapPendapatanLabTandaTerima.repx", True)
                Report.DataSource = Tbls
            ElseIf cmbjeniscetak.SelectedIndex = 2 Then
                If txcompanycode.Text = "" Then
                    MsgBox("Pilih Company Terlebih Dahulu.")
                    clear_invoice()
                    Exit Sub
                ElseIf cmbpembayaran.SelectedIndex <> 0 Then
                    MsgBox("Invoice Hanya Untuk Jenis Pembayaran Tagihan.")
                    clear_invoice()
                    Exit Sub
                End If

                SelectDateTime.LoadOptionDialog("TanggalReportTagihanLabInvoice", "Pilih Tanggal Jatuh Tempo :")
                SelectDateTime.ShowDialog()

                If txtgljatuhtempo.Text = "" Then
                    MsgBox("Pilih Tanggal Jatuh Tempo Terlebih Dahulu.")
                    clear_invoice()
                    Exit Sub
                End If

                SelectBank.LoadOptionDialog("SetBankReportTagihanLabInvoice", "Pilih Tanggal Jatuh Tempo :")
                SelectBank.ShowDialog()

                If txnamarek.Text = "" Then
                    MsgBox("Pilih Bank Terlebih Dahulu.")
                    clear_invoice()
                    Exit Sub
                End If

                Dim tgljatuhtempo As Date = txtgljatuhtempo.Text
                NoTagihan = SetNoTagihanCompany()

                'Invoice
                Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\RekapPendapatanLabInvoice.repx", True)
                Report.Bands.Item(BandKind.ReportHeader).Controls("lbltanggalsekarang").Text = Format(DateAndTime.Now, "dd") & " " & BulanIndonesia(Format(DateAndTime.Now, "MM")) & " " & Format(DateAndTime.Now, "yyyy")
                Report.Bands.Item(BandKind.ReportHeader).Controls("lbltgljatuhtempo").Text = Format(tgljatuhtempo, "dd") & " " & BulanIndonesia(Format(tgljatuhtempo, "MM")) & " " & Format(tgljatuhtempo, "yyyy")
                Report.Bands.Item(BandKind.ReportHeader).Controls("lblnoinvoice").Text = NoTagihan
                Tdata = CreateTableInvoice()
                Tdata.Rows.Clear()
                insertRowToTbls(Tdata, "Typstring", "txtglttd")
                insertRowToTbls(Tdata, "Typstring", "txangkaterbilang")
                insertRowToTbls(Tdata, "Typstring", "lblnamarekening")
                insertRowToTbls(Tdata, "Typstring", "lblnomorrekening")
                insertRowToTbls(Tdata, "Typstring", "lblnamabank")
                insertRowToTbls(Tdata, "Typstring", "namauser")
                insertRowToTbls(Tdata, "Typstring", "lblemailinvoice")

                Dim TgllabStart As Date = "12/31/9998"
                Dim number As Integer = 0 'Penomoran
                Dim jumlahpeserta As Integer = 0 'Jumlah Hadir Per Tanggal
                Dim jumlahtagihan As Integer = 0 'Jumlah Tagihan Per Tanggal
                Dim totalrow As Integer = 0 'Jumlah Tanggal yang dijadikan Tagihan
                Dim totaltagihan As Integer = 0 'Total Keseluruhan Tagihan
                Dim Pemeriksaan As String = ""
                Dim namauser As String = ""
                Dim Ttempat As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='Kota'")
                Dim Temail As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='InvoiceEmail'")
                Dim Tnamalab As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='InvoiceTempat_Lab'")

                If PoliKlinik.Lbluser.Text = "Admin" Then
                    namauser = "Admin"
                Else
                    namauser = ReadSQLNIK("SELECT UserNama FROM Users WHERE UserID = '" & PoliKlinik.Lbluser.Text & "'")
                End If

                If Tbls.Rows.Count > 0 Then
                    For Each TrowData As DataRow In Tbls.Rows
                        If TgllabStart = "12/31/9998" Then
                            TgllabStart = Format(TrowData("Tanggal Lab"), "MM-dd-yyyy")
                            number = 1
                            jumlahpeserta = 1
                            jumlahtagihan = TrowData("Tagihan")
                            totalrow = 1
                        Else
                            If Format(TrowData("Tanggal Lab"), "MM-dd-yyyy") = TgllabStart Then
                                TgllabStart = Format(TrowData("Tanggal Lab"), "MM-dd-yyyy")
                                jumlahpeserta = jumlahpeserta + 1
                                jumlahtagihan = jumlahtagihan + TrowData("Tagihan")
                            ElseIf Format(TrowData("Tanggal Lab"), "MM-dd-yyyy") <> TgllabStart Then
                                Dim Tnew As DataRow = Tdata.NewRow
                                Tnew("No") = number
                                Tnew("Tgl lab") = Format(TgllabStart, "MM-dd-yyyy")
                                Tnew("Jumlah Peserta") = jumlahpeserta & " Orang"
                                Tnew("Keterangan") = "Sesuai Rekapan"
                                Tnew("Total") = jumlahtagihan

                                Tnew("txtglttd") = Ttempat & ", " & Format(DateAndTime.Now, "dd") & " " & BulanIndonesia(Format(DateAndTime.Now, "MM")) & " " & Format(DateAndTime.Now, "yyyy")
                                Tnew("txangkaterbilang") = "Terbilang : " & Terbilang(totaltagihan) & " Rupiah"
                                Tnew("lblnamarekening") = txnamarek.Text
                                Tnew("lblnomorrekening") = txnorek.Text
                                Tnew("lblnamabank") = txnamabank.Text
                                Tnew("namauser") = namauser
                                Tnew("lblemailinvoice") = "3. Bukti Pembayaran dapat dikirim melalui email " & Temail
                                Tdata.Rows.Add(Tnew)

                                totalrow = totalrow + 1
                                number = number + 1
                                totaltagihan = totaltagihan + jumlahtagihan
                                jumlahpeserta = 1
                                jumlahtagihan = TrowData("Tagihan")
                                TgllabStart = Format(TrowData("Tanggal Lab"), "MM-dd-yyyy")
                            End If
                        End If
                    Next

                    totaltagihan = totaltagihan + jumlahtagihan
                    Dim Tlastnew As DataRow = Tdata.NewRow
                    Tlastnew("No") = number
                    Tlastnew("Tgl lab") = Format(TgllabStart, "MM-dd-yyyy")
                    Tlastnew("Jumlah Peserta") = jumlahpeserta & " Orang"
                    Tlastnew("Keterangan") = "Sesuai Rekapan"
                    Tlastnew("Total") = jumlahtagihan

                    Tlastnew("txtglttd") = Ttempat & ", " & Format(DateAndTime.Now, "dd") & " " & BulanIndonesia(Format(DateAndTime.Now, "MM")) & " " & Format(DateAndTime.Now, "yyyy")
                    Tlastnew("txangkaterbilang") = "Terbilang : " & Terbilang(totaltagihan) & " Rupiah"
                    Tlastnew("lblnamarekening") = txnamarek.Text
                    Tlastnew("lblnomorrekening") = txnorek.Text
                    Tlastnew("lblnamabank") = txnamabank.Text
                    Tlastnew("namauser") = namauser
                    Tlastnew("lblemailinvoice") = "3. Bukti Pembayaran dapat dikirim melalui email " & Temail
                    Tdata.Rows.Add(Tlastnew)
                End If

                Report.DataSource = Tdata
                Dim company As String = txcompanycode.Text
                Report.Bands.Item(BandKind.ReportHeader).Controls("lblcabang").Text = company.ToString.Trim.ToUpper
                Report.Bands.Item(BandKind.ReportHeader).Controls("lblucapan").Text = "Dengan hormat," & vbCrLf & _
                                                                                      "Kami mengucapkan terimakasih atas kepercayaan yang telah diberikan kepada " & Tnamalab & ". Bersama surat ini kami menginformasikan tagihan Pemeriksaan Laboratorium dengan rincian sebagai berikut:"
                Tstr = ""
                Dim Ttemp As String = "("
                For Each TrowData As DataRow In Tbls.Rows
                    Ttemp = Ttemp & "'" & TrowData("Translabid").ToString.Trim & "',"
                Next
                Tstr = Strings.Left(Ttemp, Ttemp.Length - 1) & ")"

                Dim date1 As Date = Now
                Dim date2 As Date = Date.Parse(tgljatuhtempo)
                Dim diffdays As Integer = 0
                Dim Tloc As String = ReadSQLNIK("SELECT StrValue  FROM MsConfig WHERE ConfigName='NoPoli'")

                If date2 < date1 Then
                    MsgBox("Tanggal jatuh tempo tidak boleh kurang dari hari ini.")
                    Exit Sub
                Else
                    diffdays = (date2.Date - date1.Date).Days
                End If

                'Insert Rekap Online
                WriteThemysql("insert into acctransrekaptagihan(company, tgltagihan, periode, duedate, totaltagihan, keterangan, createdate, createby, notagihancompany, cabang, JenisTransaksi) values('" & txcompanycode.Text + "-" + txkodecabang.Text & "', now(), '" & CInt(diffdays) & "', '" & Format(date2, "yyyy/MM/dd") & "', '" & CDbl(totaltagihan) & "', '-',now(), '" & PoliKlinik.Lbluser.Text & "', '" & NoTagihan & "', '" & Tloc & "', 'LAB') ", DB_Keuangan)

                'Insert Rekap ke Online & Offline
                Dim RekapID As String = ReadThemysqlNIK("SELECT a.RekapID FROM acctransrekaptagihan a ORDER BY a.RekapID DESC LIMIT 1", DB_Keuangan)

                'Update Rekap Online
                WriteThemysql("update acctranstagihandetail set lockeddate=now(), lockedby='" & PoliKlinik.Lbluser.Text & "', RekapID='" & RekapID & "' WHERE inctransid in " & Tstr & " and loc = '" & Tloc & "' and incjenis='LAB'", DB_Keuangan)

                'Insert & Update Lokal
                WriteSQL("insert into RekapTagihan (RekapID,company,tgltagihan,periode,duedate,totaltagihan,keterangan,createdate,createby,notagihancompany, bankid, jenistransaksi) values('" & RekapID & "','" & txcompanycode.Text + "-" + txkodecabang.Text & "',getdate(),'" & diffdays & "','" & date2 & "','" & CDbl(totaltagihan) & "', '-',getdate() , '" & PoliKlinik.Lbluser.Text & "', '" & NoTagihan & "', '" & txbankid.Text & "', 'LAB')", 4)
                WriteSQL("update TransaksiLab set RekapID='" & RekapID & "' WHERE TransLabID in " & Tstr & "", 4)

                'Create Jurnal
                Dim AutoJurnal As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='AutoJurnal'")
                If AutoJurnal.Trim = "Yes" Then
                    SendingJurnal(NoTagihan, totaltagihan)
                End If

                MsgBox("Berhasil Menyimpan Data dengan No. Invoice : " & NoTagihan & "", MsgBoxStyle.Information, "Success!")
            End If

            If cmbjeniscetak.SelectedIndex = 0 Then
                If cmbpembayaran.SelectedIndex = 0 Then
                    Report.Bands.Item(BandKind.ReportHeader).Controls("lbljenissetoran").Text = "REKAP TAGIHAN PEMERIKSAAN LABORATORIUM"
                ElseIf cmbpembayaran.SelectedIndex = 1 Then
                    Report.Bands.Item(BandKind.ReportHeader).Controls("lbljenissetoran").Text = "REKAP DEBET PEMERIKSAAN LABORATORIUM"
                ElseIf cmbpembayaran.SelectedIndex = 2 Then
                    Report.Bands.Item(BandKind.ReportHeader).Controls("lbljenissetoran").Text = "REKAP TUNAI PEMERIKSAAN LABORATORIUM"
                ElseIf cmbpembayaran.SelectedIndex = 3 Then
                    Report.Bands.Item(BandKind.ReportHeader).Controls("lbljenissetoran").Text = "REKAP CARD PEMERIKSAAN LABORATORIUM"
                End If
            ElseIf cmbjeniscetak.SelectedIndex = 1 Then
                Report.Bands.Item(BandKind.ReportHeader).Controls("lbljenissetoran").Text = "TANDA TERIMA HASIL LABORATORIUM"
            ElseIf cmbjeniscetak.SelectedIndex = 2 Then
                Report.Bands.Item(BandKind.ReportHeader).Controls("lbljenissetoran").Text = "INVOICE"
            End If

            Report.Bands.Item(BandKind.ReportHeader).Controls("lbltanggal").Text = txtgllab.Text
            Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:ss") & " By " & PoliKlinik.Lbluser.Text

            'Report.RunDesigner()
            Report.ShowPreview()
            'Report.Print()

            If cmbjeniscetak.SelectedIndex = 2 Then
                'SavePDF
                Dim NameFile As String = NoTagihan.Replace("/", "-")
                Dim PathFolder As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='PathAutoSaveInvoice'")
                PathFolder = PathFolder & "INVOICE_LAB" & "\" & Format(DateAndTime.Now, "yyyy") & "\" & Format(DateAndTime.Now, "MMMM") & "\" & Format(DateAndTime.Now, "dd") & ""

                If (Not System.IO.Directory.Exists(PathFolder)) Then
                    System.IO.Directory.CreateDirectory(PathFolder)
                End If

                Dim filepath As String = PathFolder & "\" & NameFile & ".pdf"
                If File.Exists(filepath) Then
                    My.Computer.FileSystem.DeleteFile(filepath)
                End If
                Report.CreatePdfDocument(filepath)

                'CreateBase64
                Dim Base64Inv As String = ""
                Base64Inv = Convert.ToBase64String(System.IO.File.ReadAllBytes(filepath))

                'Update Base64
                WriteThemysql("UPDATE acctransrekaptagihan a SET a.FileBase64 = '" & Base64Inv & "' WHERE a.notagihancompany = '" & NoTagihan & "'", DB_Keuangan)

                MsgBox("Invoice Otomatis Tersimpan di drive : " & PathFolder & "", MsgBoxStyle.Information, "Success!")

                clear_invoice()
                NewToolStripMenuItem1.PerformClick()
            End If
        Else
            MsgBox("Tidak ada data yg ditampilkan.", MsgBoxStyle.Exclamation, "Warning!")
            Exit Sub
        End If
    End Sub

    Private Sub SendingJurnal(ByVal NoInv As String, ByVal TotalTagihan As Integer)
        Dim keterangan As String = ""
        Dim flag As String = ""
        Dim KetLokasi As String = ""
        Dim Nourut As String = ""
        Dim bsa As String = ""
        Dim Tlokasigl As New DataTable
        Dim Tloc As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='NoPoli'")
        Dim TKode As String = ReadSQLNIK("SELECT RIGHT(StrValue, 3) FROM MsConfig WHERE ConfigName='KodeInvoiceLab'")
        Dim TKodeBarcode As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='KodeBarcode'")
        Dim CoaPiutangPending As String = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPiutangPendingLab'", DB_Keuangan2)
        Dim CoaPiutang As String = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPiutangLab'", DB_Keuangan2)
        Dim RekapID As String = ReadSQLNIK("SELECT RekapID FROM RekapTagihan WHERE notagihancompany = '" & NoInv & "'")

        Tlokasigl = ReadThemysql("SELECT a.locgl, a.locket FROM masterlokasigl a WHERE a.loc='" & Tloc & "' AND a.jenistransaksi='LAB'", DB_Keuangan)
        Dim Trowlokasigl As DataRow = Tlokasigl.Rows(0)
        bsa = Trowlokasigl("locgl")
        KetLokasi = Trowlokasigl("locket")

        Dim Tdetail() As String = NoInv.Split("/")

        flag = Tdetail(0) & Tdetail(1).Substring(Tdetail(1).Length - 3) & Tdetail(2) & Tdetail(3)

        keterangan = "TERIMA - TAGIHAN " & txcompanycode.Text.Trim & " " & KetLokasi & " " & Format(DateAndTime.Now, "dd/MM/yyyy") & " (NO. INVOICE : " & NoInv & ")"

        'Send To GL
        WriteThemysql("SELECT F_MakeUMH('" & flag & "', 'out', '', '" & Format(DateAndTime.Now, "yyyy-MM-dd") & "', '" & CoaPiutangPending & "', '" & CoaPiutang & "', 'IDR', 1, " & CDbl(TotalTagihan) & ", '" & keterangan.ToUpper() & "', '1', 1, '', '" & keterangan.ToUpper() & "', '', '', '" & bsa & "', 4, " & CDbl(TotalTagihan) & ", 'K')", DB_Jurnal)

        'Update TransaksiLab
        WriteSQL("UPDATE TransaksiLab SET FlagJurnalCreateTagihan = '" & flag & "' WHERE RekapID = '" & RekapID & "'", 4)

        'Update acctransrekaptagihan
        WriteThemysql("UPDATE acctransrekaptagihan SET FlagJurnalCreateTagihan = '1' WHERE RekapID = '" & RekapID & "'", DB_Keuangan)

        'Save Log
        WriteSQL("INSERT INTO LogJurnalKeuangan (JurnalFlag,JurnalDate,JurnalBy,Status,JenisTransaksi) VALUES ('" & flag & "', getdate(), '" & PoliKlinik.Lbluser.Text & "', 'JURNAL TAGIHAN (" & NoInv & ")', 'LAB')", 4)
    End Sub

    Function SetNoTagihanCompany() As String
        Dim NoTagihan As String = ""
        Dim NoRef1 As String = ""
        Dim NoRef2 As String = ""
        Dim NoRef3 As String = ""

        Dim angka2 As String = "0001"
        Dim angka As String = ReadThemysqlNIK("SELECT concat(lpad(LEFT(notagihancompany,4)+1,4,0)) FROM acctransrekaptagihan WHERE DATE(tgltagihan) BETWEEN DATE_FORMAT('" & Format(DateAndTime.Now, "yyyy-MM-dd") & "' ,'%Y-%m-01 %T') AND LAST_DAY('" & Format(DateAndTime.Now, "yyyy-MM-dd") & "') order BY notagihancompany desc limit 1", DB_Keuangan)

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

    Private Sub cball_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cball.CheckedChanged
        If cball.Checked = False Then
            cmbjeniscetak.Enabled = True
        ElseIf cball.Checked = True Then
            cmbjeniscetak.SelectedIndex = 0
            cmbjeniscetak.Enabled = False
        End If
    End Sub

    Private Sub cmbpembayaran_SELECTedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbpembayaran.SelectedIndexChanged
        If cmbpembayaran.Text.Trim <> "TAGIHAN" Then
            txcompanycode.ResetText()
            txkodecabang.ResetText()
            butfindcompany.Enabled = False
        Else
            butfindcompany.Enabled = True
        End If
    End Sub
End Class


