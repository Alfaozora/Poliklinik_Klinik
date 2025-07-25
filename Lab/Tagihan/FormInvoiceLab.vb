Imports System.Drawing

Public Class FormInvoiceLab
    Dim Tstr As String = ""
    Dim thread As System.Threading.Thread

    ' Set Connection
    Private Find_Keuangan As Find.TLconnect
    Private DB_Keuangan As TLcon
    Private DB_Keuangan2 As TLcon
    Private DB_Jurnal As TLcon

    Private Sub SetConnectionFromConfig()
        ' Set Parameter Server Online
        Dim serverOnline_IP As String = Utility.GetConfig("ServerOnline_IP")
        Dim serverOnline_UserID As String = Utility.GetConfig("ServerOnline_UserID")
        Dim serverOnline_Password As String = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerOnline_Password"), "albert")

        ' Set Find Keuangan 1 (mitramed_keu)
        Find_Keuangan.Tip = serverOnline_IP
        Find_Keuangan.Tid = serverOnline_UserID
        Find_Keuangan.Tpass = serverOnline_Password
        Find_Keuangan.Tdb = Utility.GetConfig("ServerOnlineKeuangan_DB")

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

        For Each Tcol As DataColumn In Thasil.Columns
            Tcol.ReadOnly = True
        Next

        Return Thasil
    End Function

    Public Sub LoadPasien(ByRef RekapID As String)
        If RekapID < 1 Then
            SetClear()
        Else
            Dim Tquery As String = ""
            Dim Tcompany As String = ""
            Dim Tpaket As String = ""
            Dim Tjenistransaksi As String = ""
            Dim Tpemeriksaan As String = ""
            Dim ConcatCompany As String = ""
            Dim TgllabStart As Date = "12/31/9998"
            Dim TgllabEnd As Date = "12/31/9998"

            'Set Header Invoice
            Dim Tempinvoice As DataTable = ReadSQL("SELECT * FROM RekapTagihan WHERE RekapID = '" & RekapID & "'")
            For Each Trow As DataRow In Tempinvoice.Rows
                Dim company As String = Trow("company")
                Dim Tsplit() As String = company.Split("-")
                txheadercompany.Text = Tsplit(0).ToString.Trim.ToUpper
                txheadernotagihan.Text = Trow("notagihancompany")
                txheadernominal.Text = "" & Format(Val(Trow("totaltagihan")), "Rp, ###,###.#0") & ""
                dtheadertglinvoice.Value = Trow("tgltagihan")
                dtheadertgljatuhtempo.Value = Trow("duedate")
                txrekapid.Text = RekapID

                Dim BankInvoice As DataTable = ReadThemysql("SELECT * FROM accmasterbank WHERE bankid = '" & Trow("bankid") & "'", DB_Keuangan)
                For Each TrowBank As DataRow In BankInvoice.Rows
                    txnamarek.Text = TrowBank("namarekening")
                    txnorek.Text = TrowBank("norekening")

                    Dim jenisbank As String = TrowBank("namabank")
                    If jenisbank.Contains("BCA") = True Then
                        txnamabank.Text = "BCA - " & "CABANG " & TrowBank("cabangrekening")
                    ElseIf jenisbank.Contains("BNI") = True Then
                        txnamabank.Text = "BNI - " & "CABANG " & TrowBank("cabangrekening")
                    ElseIf jenisbank.Contains("MANDIRI") = True Then
                        txnamabank.Text = "MANDIRI - " & "CABANG " & TrowBank("cabangrekening")
                    ElseIf jenisbank.Contains("NIAGA") = True Then
                        txnamabank.Text = "NIAGA - " & "CABANG " & TrowBank("cabangrekening")
                    ElseIf jenisbank.Contains("HSBC") = True Then
                        txnamabank.Text = "HSBC - " & "CABANG " & TrowBank("cabangrekening")
                    ElseIf jenisbank.Contains("BANK MAS") = True Then
                        txnamabank.Text = "BANK MAS - " & "CABANG " & TrowBank("cabangrekening")
                    Else
                        txnamabank.Text = TrowBank("cabangrekening")
                    End If
                Next
            Next

            'Company
            If txcompanycode.Text <> "" Then
                ConcatCompany = txcompanycode.Text + "-" + txkodecabang.Text
                Tcompany = " and (c.NoJenisBayar = '" & txcompanycode.Text & "' or c.NoJenisBayar='" & ConcatCompany & "')"
            Else
                Tcompany = ""
            End If

            'Jenis Transaksi
            Tjenistransaksi = " AND c.JenisBayar='TAGIHAN'"

            'Query Utama
            Tquery = "SELECT ROW_NUMBER() OVER (ORDER BY a.Nourut)  AS 'No', c.NoJenisBayar, a.TransLabID, a.DetailPemeriksaan, a.NoUrut as 'No Lab', a.TglLab as 'Tanggal Lab', b.NoNIP as 'NIP',b.Nama,b.TglLahir as 'Tgl Lahir',b.DomisiliAlamat, '-' as 'pemeriksaan', c.JumlahBayar-c.Kembali as 'Tagihan' " & _
            "FROM transaksilab a " & _
            "LEFT JOIN MasterPasien b on a.idinternet = b.NoRekamMedis " & _
            "LEFT JOIN TransaksiLabBayar c on a.TransLabID=c.TransLabID " & _
            "WHERE a.RekapID = '" & RekapID & "' "

            Dim Tbls As DataTable = New DataTable
            Dim Tdata As DataTable = New DataTable
            Dim TDetailPemeriksaan As DataTable = New DataTable
            Dim DetailPemeriksaan As String = ""
            Dim TtempDetailPemeriksaan As String = ""

            Tbls = ReadSQL(Tquery + Tcompany + Tjenistransaksi + " order by c.NoJenisBayar, a.TglLab, a.nourut asc")
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
                    Tnew("NIP") = TrowData("NIP")
                    Tnew("Nama") = TrowData("Nama")
                    Tnew("Tgl Lahir") = TrowData("Tgl Lahir")
                    Tnew("Alamat") = TrowData("DomisiliAlamat")

                    If IsDBNull(TrowData("DetailPemeriksaan")) = True Then
                        DetailPemeriksaan = SetTindakanDetail(TrowData("TransLabID"), "LAB", Nothing)
                    ElseIf IsDBNull(TrowData("DetailPemeriksaan")) = False Then
                        DetailPemeriksaan = TrowData("DetailPemeriksaan")
                    End If

                    Tnew("pemeriksaan") = DetailPemeriksaan
                    Tnew("Tagihan") = TrowData("Tagihan")

                    Tdata.Rows.Add(Tnew)
                Next

                If TgllabStart = TgllabEnd Then
                    txtgllab.Text = Format(TgllabStart, "dd") & " " & BulanIndonesia(Format(TgllabStart, "MM")) & " " & Format(TgllabStart, "yyyy")
                Else
                    txtgllab.Text = Format(TgllabStart, "dd") & " " & BulanIndonesia(Format(TgllabStart, "MM")) & " " & Format(TgllabStart, "yyyy") & " s/d " & Format(TgllabEnd, "dd") & " " & BulanIndonesia(Format(TgllabEnd, "MM")) & " " & Format(TgllabEnd, "yyyy")
                End If

                Dim lunasid As String = ReadThemysqlNIK("SELECT a.lunasid FROM acctransrekaptagihan a WHERE a.RekapID = '" & RekapID & "'", DB_Keuangan)
                If lunasid <> "0" Then
                    txlunas.Visible = True
                    txbelumlunas.Visible = False
                Else
                    txlunas.Visible = False
                    txbelumlunas.Visible = True
                End If

                gridpasien.DataSource = Tdata
                GridView1.Columns("No").Visible = False
                CheckBoxDelete.Enabled = True
                exportpdf.Enabled = True
            End If
        End If

    End Sub

    Private Sub SetClear()
        gridpasien.DataSource = CreateTable()

        txcompanycode.ResetText()
        txkodecabang.ResetText()
        txheadercompany.ResetText()
        txheadernotagihan.ResetText()
        txheadernominal.ResetText()
        txrekapid.ResetText()
        dtheadertglinvoice.Value = DateTime.Now
        dtheadertgljatuhtempo.Value = DateTime.Now
        cmbjeniscetak.SelectedIndex = 0
        CheckBoxDelete.Enabled = False
        CheckBoxDelete.Checked = False
        exportpdf.Enabled = True
        txlunas.Visible = False
        txbelumlunas.Visible = False
    End Sub

    Private Sub CloseToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub FormInvoiceLab_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        SetFormHeightWeight(Me, 0.95, 0.8)
        NewToolStripMenuItem1.PerformClick()
        Control.CheckForIllegalCrossThreadCalls = False

        ' Inisialisasi koneksi ke database MySQL
        SetConnectionFromConfig()
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
        Find.Query("SELECT IDCompany, CompanyCode, CompanyNama, NoCompany FROM mastercompany a WHERE getdate() between StartDate and EndDate", " ORDER BY a.idcompany desc", "FindCabangFormInvoiceLab", 2)
    End Sub

    Private Sub butfindpaket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Find.Show()
        Find.Query("SELECT PaketID as ID,PaketNama,PaketKeterangan,PARSENAME(CONVERT(varchar,convert(money,PaketNilaiTotal),1),2) as PaketNilaiTotal,PaketStart,PaketEnd FROM MasterLabPaket WHERE GETDATE() between PaketStart and PaketEnd ", " order by PaketID DESC ", "FindPaketIDFormInvoiceLab", 2)
    End Sub

    Private Sub buttambahpasien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttambahpasien.Click
        Dim Tquery As String = ""
        Dim Tcompany As String = ""
        Dim ConcatCompany As String = ""
        Dim Tloc As String = ReadSQLNIK("SELECT StrValue  FROM MsConfig WHERE ConfigName='NoPoli'")
        Dim KodeInv As String = ReadSQLNIK("SELECT StrValue  FROM MsConfig WHERE ConfigName='KodeInvoiceLab'")

        'Cek Koneksi
        If CekKoneksi("SHOW TABLES FROM " & DB_Keuangan.Tdb & "", DB_Keuangan) = False Then
            MsgBox("Proses gagal, cek koneksi internet atau server Database " & DB_Keuangan.Tdb & ".", MsgBoxStyle.Exclamation, "Warning!")
            Exit Sub
        End If

        'Company
        If txcompanycode.Text <> "" Then
            ConcatCompany = txcompanycode.Text + "-" + txkodecabang.Text
            Tcompany = " and (company = '" & txcompanycode.Text & "' or company='" & ConcatCompany & "')"
        Else
            Tcompany = " "
        End If

        'Query Utama
        Tquery = "SELECT RekapID, company, notagihancompany AS 'No Tagihan', tgltagihan AS 'Tgl Tagihan', totaltagihan, duedate AS 'Tgl Jatuh Tempo', CASE WHEN lunasid > 0 THEN 'LUNAS' ELSE '-' END AS 'Status' FROM acctransrekaptagihan WHERE notagihancompany like '%" & KodeInv & "%' and cabang = '" & Tloc & "' and (DATE(tgltagihan) BETWEEN '" & Format(dtprocess.Value, "yyyy-MM-dd") & "' and '" & Format(dtprocessend.Value, "yyyy-MM-dd") & "') AND deleted IS NULL "
        'Tquery = "SELECT RekapID, company, notagihancompany as 'No Tagihan', tgltagihan as 'Tgl Tagihan', totaltagihan, duedate as 'Tgl Jatuh Tempo' FROM RekapTagihan WHERE deleted<>1 and (CONVERT(date, tgltagihan) between '" & Format(dtprocess.Value, "MM-dd-yyyy") & "' and '" & Format(dtprocessend.Value, "MM-dd-yyyy") & "') "

        Find.Show()
        Find.QueryTheMysql(Tquery + Tcompany, " order by tgltagihan, RekapID asc", "FindInvoiceLab", 2, Find_Keuangan)
        'Find.Query(Tquery + Tcompany, " order by tgltagihan, RekapID asc", "FindInvoiceLab", 2)
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

    Private Sub exportpdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exportpdf.Click
        Dim Ttempat As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='Kota'")
        Dim Temail As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='InvoiceEmail'")
        Dim Tnamalab As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='InvoiceTempat_Lab'")
        Dim Tbls As DataTable = gridpasien.DataSource
        Dim Tdata As DataTable = New DataTable
        If Tbls.Rows.Count > 0 Then
            Report = New XtraReport

            If cmbjeniscetak.SelectedIndex = 0 Then
                'Rekap Tagihan
                Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\RekapPendapatanLabPemeriksaan.repx", True)
                Report.DataSource = Tbls
            ElseIf cmbjeniscetak.SelectedIndex = 1 Then
                'Tanda Terima
                Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\RekapPendapatanLabTandaTerima.repx", True)
                Report.DataSource = Tbls
            ElseIf cmbjeniscetak.SelectedIndex = 2 Then
                'INVOICE
                Dim tgljatuhtempo As Date = dtheadertgljatuhtempo.Value
                Dim NoTagihan As String = txheadernotagihan.Text
                Dim tglinvoice As Date = dtheadertglinvoice.Value

                Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\RekapPendapatanLabInvoice.repx", True)
                Report.Bands.Item(BandKind.ReportHeader).Controls("lbltanggalsekarang").Text = Format(tglinvoice, "dd") & " " & BulanIndonesia(Format(tglinvoice, "MM")) & " " & Format(tglinvoice, "yyyy")
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

                    'totaltagihan = jumlahtagihan
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
                Dim company As String = txheadercompany.Text
                Report.Bands.Item(BandKind.ReportHeader).Controls("lblcabang").Text = company.ToString.Trim.ToUpper
                Report.Bands.Item(BandKind.ReportHeader).Controls("lblucapan").Text = "Dengan hormat," & vbCrLf & _
                                                                                      "Kami mengucapkan terimakasih atas kepercayaan yang telah diberikan kepada " & Tnamalab & ". Bersama surat ini kami menginformasikan tagihan Pemeriksaan Laboratorium dengan rincian sebagai berikut:"
            ElseIf cmbjeniscetak.SelectedIndex = 3 Then
                'KWITANSI
                Dim tgljatuhtempo As Date = dtheadertgljatuhtempo.Value
                Dim NoTagihan As String = txheadernotagihan.Text
                Dim tglinvoice As Date = dtheadertglinvoice.Value

                Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\RekapPendapatanLabKwitansi.repx", True)
                Tdata = CreateTableInvoice()
                Tdata.Rows.Clear()

                Dim TgllabStart As Date = "12/31/9998"
                Dim number As Integer = 0 'Penomoran
                Dim jumlahpeserta As Integer = 0 'Jumlah Hadir Per Tanggal
                Dim totalpeserta As Integer = 0
                Dim jumlahtagihan As Integer = 0 'Jumlah Tagihan Per Tanggal
                Dim totalrow As Integer = 0 'Jumlah Tanggal yang dijadikan Tagihan
                Dim totaltagihan As Integer = 0 'Total Keseluruhan Tagihan
                Dim Pemeriksaan As String = ""

                If Tbls.Rows.Count > 0 Then
                    For Each TrowData As DataRow In Tbls.Rows
                        If TgllabStart = "12/31/9998" Then
                            TgllabStart = Format(TrowData("Tanggal Lab"), "MM-dd-yyyy")
                            number = 1
                            jumlahpeserta = 1
                            jumlahtagihan = TrowData("Tagihan")
                            'totaltagihan = jumlahtagihan
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
                                Tdata.Rows.Add(Tnew)

                                totalrow = totalrow + 1
                                number = number + 1
                                totaltagihan = totaltagihan + jumlahtagihan
                                totalpeserta = totalpeserta + jumlahpeserta
                                jumlahpeserta = 1
                                jumlahtagihan = TrowData("Tagihan")
                                TgllabStart = Format(TrowData("Tanggal Lab"), "MM-dd-yyyy")
                            End If
                        End If
                    Next

                    'totaltagihan = jumlahtagihan
                    totaltagihan = totaltagihan + jumlahtagihan
                    totalpeserta = totalpeserta + jumlahpeserta
                    Dim Tlastnew As DataRow = Tdata.NewRow
                    Tlastnew("No") = number
                    Tlastnew("Tgl lab") = Format(TgllabStart, "MM-dd-yyyy")
                    Tlastnew("Jumlah Peserta") = jumlahpeserta & " Orang"
                    Tlastnew("Keterangan") = "Sesuai Rekapan"
                    Tlastnew("Total") = jumlahtagihan
                    Tdata.Rows.Add(Tlastnew)
                End If

                'Pemisah Bulan
                Dim VarTglLab As String = txtgllab.Text
                Dim varBulan As String = ""
                If VarTglLab.Contains("s/d") = True Then
                    Dim Tsplit() As String = VarTglLab.Split("s/d")
                    Dim Bulan1() As String = Tsplit(0).Split(" ")
                    Dim Bulan2() As String = Tsplit(1).Split(" ")
                    varBulan = BulanIndonesia(Bulan1(1)).ToString.Trim.ToUpper & " " & Bulan1(2) & " - " & BulanIndonesia(Bulan2(1)).ToString.Trim.ToUpper & " " & Bulan2(2)
                Else
                    Dim Bulan1() As String = VarTglLab.Split(" ")
                    varBulan = BulanIndonesia(Bulan1(1)).ToString.Trim.ToUpper & " " & Bulan1(2)
                End If

                Report.DataSource = Tdata
                Dim company As String = txheadercompany.Text
                Dim AngkaTerbilang As String = Terbilang(totaltagihan)
                Report.Bands.Item(BandKind.ReportHeader).Controls("lblnoinvoice").Text = NoTagihan
                Report.Bands.Item(BandKind.ReportHeader).Controls("lblbanyakuang").Text = "# " & AngkaTerbilang.ToString.Trim.ToUpper & " #"
                Report.Bands.Item(BandKind.ReportHeader).Controls("lblpembayaran").Text = "TAGIHAN PEMERIKSAAN LABORATORIUM BULAN " & varBulan & " SEBANYAK " & totalpeserta & " ORANG"
                Report.Bands.Item(BandKind.ReportHeader).Controls("lblcabang").Text = company.ToString.Trim.ToUpper
                If PoliKlinik.Lbluser.Text = "Admin" Then
                    Report.Bands.Item(BandKind.Detail).Controls("txnamauser").Text = "Admin"
                Else
                    Report.Bands.Item(BandKind.Detail).Controls("txnamauser").Text = ReadSQLNIK("SELECT UserNama FROM Users WHERE UserID = '" & PoliKlinik.Lbluser.Text & "'")
                End If
                Report.Bands.Item(BandKind.Detail).Controls("txtglttd").Text = Ttempat & ", " & Format(DateAndTime.Now, "dd") & " " & BulanIndonesia(Format(DateAndTime.Now, "MM")) & " " & Format(DateAndTime.Now, "yyyy")
            End If

            If cmbjeniscetak.SelectedIndex = 0 Then
                Report.Bands.Item(BandKind.ReportHeader).Controls("lbljenissetoran").Text = "REKAP TAGIHAN PEMERIKSAAN LABORATORIUM"
            ElseIf cmbjeniscetak.SelectedIndex = 1 Then
                Report.Bands.Item(BandKind.ReportHeader).Controls("lbljenissetoran").Text = "TANDA TERIMA HASIL LABORATORIUM"
            ElseIf cmbjeniscetak.SelectedIndex = 2 Then
                Report.Bands.Item(BandKind.ReportHeader).Controls("lbljenissetoran").Text = "INVOICE"
            ElseIf cmbjeniscetak.SelectedIndex = 3 Then
                Report.Bands.Item(BandKind.ReportHeader).Controls("lbljenissetoran").Text = "KWITANSI"
            End If

            If cmbjeniscetak.SelectedIndex <> 3 Then
                Report.Bands.Item(BandKind.ReportHeader).Controls("lbltanggal").Text = txtgllab.Text
            End If

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
        Dim angka As String = ReadThemysqlNIK("SELECT concat(lpad(LEFT(notagihancompany,4)+1,4,0)) FROM acctransrekaptagihan WHERE tgltagihan BETWEEN DATE_FORMAT('" & Format(DateAndTime.Now, "yyyy-MM-dd") & "' ,'%Y-%m-01 %T') AND LAST_DAY('" & Format(DateAndTime.Now, "yyyy-MM-dd") & "') order BY notagihancompany desc limit 1", DB_Keuangan)

        If angka = "" Or angka = "-" Then
            NoRef1 = angka2
        ElseIf angka <> "" Then
            NoRef1 = angka
        End If

        NoRef2 = "CDC"
        NoRef3 = GetRomes(DateAndTime.Now.Month) & "/" & Format(DateAndTime.Now, "yyyy")
        NoTagihan = NoRef1 & "/" & NoRef2 & "/" & NoRef3

        Return NoTagihan
    End Function

    Private Sub CheckBoxDelete_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxDelete.CheckedChanged
        If CheckBoxDelete.Checked = True Then
            If MsgBox("Apakah anda yakin ingin menghapus invoice " & txheadernotagihan.Text & " (" & txheadercompany.Text & ")?", MsgBoxStyle.YesNoCancel, "Question.") = MsgBoxResult.Yes Then
                If CekKoneksi("SHOW TABLES FROM " & DB_Keuangan.Tdb & "", DB_Keuangan) = False Then
                    MsgBox("Proses gagal, cek koneksi internet atau server Database " & DB_Keuangan.Tdb & ".", MsgBoxStyle.Exclamation, "Warning!")
                    CheckBoxDelete.Checked = False
                    exportpdf.Enabled = True
                Else
                    If CheckThemysql("SELECT * FROM acctransrekaptagihan WHERE RekapID='" & txrekapid.Text & "' and lunasid > 0", DB_Keuangan) = True Then
                        MsgBox("Proses gagal, invoice " & txheadernotagihan.Text & " sudah terlunasi di keuangan.", MsgBoxStyle.Exclamation, "Warning!")
                        CheckBoxDelete.Checked = False
                        exportpdf.Enabled = True
                    Else
                        'Update Online
                        WriteThemysql("update acctransrekaptagihan set deleted=1, deletedby='" & PoliKlinik.Lbluser.Text & "', deleteddate=now() WHERE RekapID='" & txrekapid.Text & "'", DB_Keuangan)
                        WriteThemysql("update acctranstagihandetail set lockedby='', lockeddate='9998-12-31 00:00:00', rekapid=NULL WHERE rekapid='" & txrekapid.Text & "'", DB_Keuangan)

                        'Update Lokal
                        WriteSQL("update RekapTagihan set deleted=1, deletedby='" & PoliKlinik.Lbluser.Text & "', deleteddate=getdate() WHERE RekapID='" & txrekapid.Text & "'", 4)
                        WriteSQL("update TransaksiLab set RekapID=NULL WHERE RekapID='" & txrekapid.Text & "'", 4)

                        'Create Jurnal
                        Dim AutoJurnal As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='AutoJurnal'")
                        If AutoJurnal.Trim = "Yes" Then
                            SendingJurnalCancel()
                        End If

                        MsgBox("Invoice " & txheadernotagihan.Text & " berhasil dihapus dari program.", MsgBoxStyle.Information, "Success!")
                        SetClear()
                    End If
                End If
            Else
                CheckBoxDelete.Checked = False
                exportpdf.Enabled = True
            End If
        End If
    End Sub

    Private Sub SendingJurnalCancel()
        Dim keterangan As String = ""
        Dim flag As String = ""
        Dim KetLokasi As String = ""
        Dim Nourut As String = ""
        Dim bsa As String = ""
        Dim JenisTransaksi As String = "LAB"
        Dim TotalTagihan As Integer = 0
        Dim Tlokasigl As New DataTable
        Dim Tloc As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='NoPoli'")
        Dim CoaPendapatan As String = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPiutangPendingLab'", DB_Keuangan2)
        Dim CoaPiutang As String = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPiutangLab'", DB_Keuangan2)

        Tlokasigl = ReadThemysql("SELECT a.locgl, a.locket FROM masterlokasigl a WHERE a.loc='" & Tloc & "' AND a.jenistransaksi='" & JenisTransaksi & "'", DB_Keuangan)
        Dim Trowlokasigl As DataRow = Tlokasigl.Rows(0)
        bsa = Trowlokasigl("locgl")
        KetLokasi = Trowlokasigl("locket")

        'Set DB Berdasarkan Lokasi di GL
        'FGL.Tdb = ReadThemysqlNIK("SELECT a.db_gl FROM mastercodebarcode a WHERE a.kodecabang = '" & Tloc & "';", Fcon)

        Nourut = ReadThemysqlNIK(" SELECT concat(lpad(LEFT(t1.Jurnal,5)+1,5,0)) FROM (" & _
                 " SELECT a.FlagJurnalPembayaran AS 'Jurnal' FROM acctransrekaptagihan a" & _
                 " WHERE a.FlagJurnalPembayaran LIKE '%" & Format(dtheadertglinvoice.Value, "yy/MM") & "/OL%' AND a.FlagJurnalPembayaran IS NOT NULL" & _
                 " UNION" & _
                 " SELECT FlagJurnalCancel AS 'Jurnal' FROM acctransrekaptagihan a" & _
                 " WHERE a.FlagJurnalCancel LIKE '%" & Format(dtheadertglinvoice.Value, "yy/MM") & "/OL%' AND a.FlagJurnalCancel IS NOT NULL) AS t1" & _
                 " ORDER BY LEFT(t1.Jurnal,5) DESC LIMIT 1", DB_Keuangan)

        If IsDBNull(Nourut) = False And Nourut <> "" And Nourut <> "-" Then
            flag = "" & Nourut.Trim & "/" & Format(dtheadertglinvoice.Value, "yy/MM") & "/OL"
        Else
            flag = "00001/" & Format(dtheadertglinvoice.Value, "yy/MM") & "/OL"
        End If

        Dim Tgrid As DataTable = gridpasien.DataSource
        For Each Trow As DataRow In Tgrid.Rows
            TotalTagihan = TotalTagihan + Trow("Tagihan")
        Next

        keterangan = "CANCEL - TAGIHAN " & txheadercompany.Text.Trim & " " & KetLokasi & " " & Format(dtheadertglinvoice.Value, "dd/MM/yyyy") & " (NO. INVOICE : " & txheadernotagihan.Text & ")"

        'Send To GL
        WriteThemysql("SELECT F_MakeUMH('" & flag & "', 'out', '', '" & Format(dtheadertglinvoice.Value, "yyyy-MM-dd") & "', '" & CoaPiutang & "', '" & CoaPendapatan & "', 'IDR', 1, " & CDbl(TotalTagihan) & ", '" & keterangan.ToUpper() & "', '1', 1, '', '" & keterangan.ToUpper() & "', '', '', '" & bsa & "', 4, " & CDbl(TotalTagihan) & ", 'K')", DB_Jurnal)

        'Flag Tabel acctransrekaptagihan
        WriteThemysql("UPDATE acctransrekaptagihan a SET a.FlagJurnalCancel = '" & flag & "' WHERE a.rekapid = '" & txrekapid.Text & "'", DB_Keuangan)

        'Save Log
        WriteThemysql("INSERT INTO logjurnalkeuangan (JurnalFlag,JurnalDate,JurnalBy,Status,JenisTransaksi,Cabang) VALUES ('" & flag & "', NOW(), '" & PoliKlinik.Lbluser.Text & "', 'JURNAL CANCEL TAGIHAN (" & txheadernotagihan.Text & ")', '" & JenisTransaksi & "', '" & Tloc & "')", DB_Keuangan)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        SendingJurnalCancel()
    End Sub
End Class


