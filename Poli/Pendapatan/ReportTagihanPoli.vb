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

    Private Sub SetClear()
        GridControlTagihan.DataSource = CreateTable()
        ComboBoxJenisTransaksi.SelectedIndex = 0
        EnableAllButton()
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

    Private Sub ButtonCariPerusahaan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCariPerusahaan.Click
        'Find.Show()
        'Find.Query("SELECT IDCompany, CompanyCode, CompanyNama, NoCompany FROM mastercompany a WHERE getdate() between StartDate and EndDate", " ORDER BY a.idcompany desc", "FindCabangReportTagihanPoli", 2)
        Find.Show()
        Find.Query("SELECT NoCompany AS 'ID', CompanyCode AS 'Kode Perusahaan', CompanyNama AS 'Keterangan' FROM mastercompany WHERE GETDATE() BETWEEN StartDate AND EndDate", " ORDER BY NoCompany ASC", "FindCabangReportTagihanPoli", 2)
    End Sub

    Private Sub butfindpaket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Find.Show()
        Find.Query("SELECT PaketID as ID,PaketNama,PaketKeterangan,PARSENAME(CONVERT(varchar,convert(money,PaketNilaiTotal),1),2) as PaketNilaiTotal,PaketStart,PaketEnd FROM MasterLabPaket WHERE GETDATE() between PaketStart and PaketEnd ", " ORDER BY PaketID DESC ", "FindPaketIDReportTagihanPoli", 2)
    End Sub

    Private Sub buttambahpasien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCariTagihan.Click
        If RadioButtonJenisReportDetail.Checked Then
            ViewLaporanDetail()
        ElseIf RadioButtonJenisReportSummary.Checked Then
            ViewLaporanSummary()
        End If
    End Sub

    Private Sub ViewLaporanSummary()
        If DateTimeTglAkhirTransaksi.Value < DateTimeTglAwalTransaksi.Value Then
            MsgBox("Tanggal Akhir tidak boleh melebihi tanggal mulai.")
            Exit Sub
        End If

        ' Filter NoJenisBayar
        Dim noJenisBayar As String = ""
        If TextBoxNamaPerusahaan.Text <> "" Then
            noJenisBayar = " AND NoJenisBayar='" & TextBoxNamaPerusahaan.Text & "'"
        End If

        ' Tentukan tabel berdasarkan pilihan jenis transaksi
        Dim tblTransaksi As String = ""
        Dim tblBayar As String = ""
        Dim tblBayarAwal As String = ""
        Dim fldTanggal As String = ""
        Dim fldTransaksiID As String = ""

        If ComboBoxJenisTransaksi.Text = "POLI" Then
            tblTransaksi = "TransaksiPoli"
            tblBayar = "TransaksiPoliBayar"
            tblBayarAwal = "TransaksiPoliBayarAwal"
            fldTanggal = "TglPoli"
            fldTransaksiID = "TransPoliID"
        ElseIf ComboBoxJenisTransaksi.Text = "GIGI" Then
            tblTransaksi = "TransaksiGigi"
            tblBayar = "TransaksiGigiBayar"
            tblBayarAwal = "TransaksiGigiBayarAwal"
            fldTanggal = "TglGigi"   ' <-- sesuaikan nama kolom tanggal di TransaksiGigi
            fldTransaksiID = "TransGigiID" ' <-- sesuaikan nama kolom ID di TransaksiGigi
        Else
            MsgBox("Pilih Jenis Transaksi terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Exit Sub
        End If

        Dim queryString As String = _
            "WITH FilteredTransaksi AS ( " & _
            "    SELECT " & fldTransaksiID & ", RekapID " & _
            "    FROM " & tblTransaksi & " " & _
            "    WHERE (CONVERT(DATE, " & fldTanggal & ") BETWEEN '" & Format(DateTimeTglAwalTransaksi.Value, "yyyyMMdd") & "' AND '" & Format(DateTimeTglAkhirTransaksi.Value, "yyyyMMdd") & "') AND Deleted = 0 " & _
            "), " & _
            "DetailBayar AS ( " & _
            "    SELECT " & _
            "        tb.NoJenisBayar AS NoJenisBayar, " & _
            "        tb.JumlahBayar - tb.Kembali AS TotalBayar, " & _
            "        tb.NoInvoicePembayaran " & _
            "    FROM " & tblBayar & " tb " & _
            "    INNER JOIN FilteredTransaksi ft ON tb." & fldTransaksiID & " = ft." & fldTransaksiID & " " & _
            "    WHERE tb.JumlahBayar > 0 AND tb.JenisBayar IN ('Tagihan') " & noJenisBayar & _
            "    UNION ALL " & _
            "    SELECT " & _
            "        tba.NoJenisBayar AS NoJenisBayar, " & _
            "        tba.JumlahBayar - tba.Kembali AS TotalBayar, " & _
            "        tba.NoInvoicePembayaran " & _
            "    FROM " & tblBayarAwal & " tba " & _
            "    INNER JOIN FilteredTransaksi ft ON tba." & fldTransaksiID & " = ft." & fldTransaksiID & " " & _
            "    WHERE tba.JumlahBayar > 0 AND tba.JenisBayar IN ('Tagihan') " & noJenisBayar & _
            "), " & _
            "Summary AS ( " & _
            "    SELECT " & _
            "        NoJenisBayar, " & _
            "        CAST(COUNT(*) AS VARCHAR) + ' Transaksi' AS JumlahOrang, " & _
            "        SUM(CASE WHEN NoInvoicePembayaran IS NOT NULL " & _
            "                 THEN TotalBayar ELSE 0 END) AS Closed, " & _
            "        SUM(CASE WHEN NoInvoicePembayaran IS NULL " & _
            "                 THEN TotalBayar ELSE 0 END) AS Unclosed, " & _
            "        SUM(TotalBayar) AS JumlahTagihan " & _
            "    FROM DetailBayar " & _
            "    GROUP BY NoJenisBayar " & _
            IIf(RadioButtonStatusBayarClosed.Checked, "HAVING SUM(CASE WHEN NoInvoicePembayaran IS NOT NULL THEN TotalBayar ELSE 0 END) > 0 ", "") & _
            IIf(RadioButtonStatusBayarUnClosed.Checked, "HAVING SUM(CASE WHEN NoInvoicePembayaran IS NULL THEN TotalBayar ELSE 0 END) > 0 ", "") & _
            ") " & _
            "SELECT " & _
            "    ROW_NUMBER() OVER (ORDER BY NoJenisBayar) AS No, " & _
            "    NoJenisBayar, " & _
            "    JumlahOrang, " & _
            "    Closed, " & _
            "    Unclosed, " & _
            "    JumlahTagihan " & _
            "FROM Summary " & _
            "ORDER BY No"

        Dim tblTagihan As DataTable = ReadSQL(queryString)
        Dim tblLaporan As DataTable = New DataTable

        tblLaporan = CreateTable()
        tblLaporan.Rows.Clear()

        If tblTagihan.Rows.Count > 0 Then
            For Each rowTagihan As DataRow In tblTagihan.Rows
                Dim rowLaporan As DataRow = tblLaporan.NewRow
                rowLaporan("No") = rowTagihan("No").ToString()
                rowLaporan("NoJenisBayar") = rowTagihan("NoJenisBayar").ToString()
                rowLaporan("Jumlah Orang") = rowTagihan("JumlahOrang").ToString()

                If RadioButtonStatusBayarClosed.Checked Then
                    rowLaporan("Closed") = rowTagihan("Closed").ToString()
                    rowLaporan("Unclosed") = "0"
                    rowLaporan("Jumlah Tagihan") = rowTagihan("Closed").ToString()

                ElseIf RadioButtonStatusBayarUnClosed.Checked Then
                    rowLaporan("Closed") = "0"
                    rowLaporan("Unclosed") = rowTagihan("Unclosed").ToString()
                    rowLaporan("Jumlah Tagihan") = rowTagihan("Unclosed").ToString()

                Else ' All
                    rowLaporan("Closed") = rowTagihan("Closed").ToString()
                    rowLaporan("Unclosed") = rowTagihan("Unclosed").ToString()
                    rowLaporan("Jumlah Tagihan") = rowTagihan("JumlahTagihan").ToString()
                End If

                tblLaporan.Rows.Add(rowLaporan)
            Next

            Dim tglAwal As Date = DateTimeTglAwalTransaksi.Value
            Dim tglAkhir As Date = DateTimeTglAkhirTransaksi.Value

            If tglAwal = tglAkhir Then
                txtgllab.Text = Format(tglAwal, "dd") & " " & BulanIndonesia(Format(tglAwal, "MM")) & " " & Format(tglAwal, "yyyy")
            Else
                txtgllab.Text = Format(tglAwal, "dd") & " " & BulanIndonesia(Format(tglAwal, "MM")) & " " & Format(tglAwal, "yyyy") & _
                                " s/d " & _
                                Format(tglAkhir, "dd") & " " & BulanIndonesia(Format(tglAkhir, "MM")) & " " & Format(tglAkhir, "yyyy")
            End If

            GridControlTagihan.DataSource = tblLaporan

            If RadioButtonJenisReportDetail.Checked = True Then
                GridViewTagihan.Columns("Tanggal Lab").Visible = True
            Else
                GridViewTagihan.Columns("Tanggal Lab").Visible = False
            End If

            GridViewTagihan.Columns("No").Visible = False

            DisableAllButton()
        Else
            MsgBox("Tidak ada data yang ditampilkan.", MsgBoxStyle.Exclamation, "Warning!")
            Exit Sub
        End If
    End Sub

    Private Sub ViewLaporanDetail()
        If DateTimeTglAkhirTransaksi.Value < DateTimeTglAwalTransaksi.Value Then
            MsgBox("Tanggal Akhir tidak boleh melebihi tanggal mulai.")
            Exit Sub
        End If

        ' Filter NoJenisBayar
        Dim noJenisBayar As String = ""
        If TextBoxNamaPerusahaan.Text <> "" Then
            noJenisBayar = " AND NoJenisBayar='" & TextBoxNamaPerusahaan.Text & "'"
        End If

        ' Tentukan tabel berdasarkan pilihan jenis transaksi
        Dim tblTransaksi As String = ""
        Dim tblBayar As String = ""
        Dim tblBayarAwal As String = ""
        Dim fldTanggal As String = ""
        Dim fldTransaksiID As String = ""

        If ComboBoxJenisTransaksi.Text = "POLI" Then
            tblTransaksi = "TransaksiPoli"
            tblBayar = "TransaksiPoliBayar"
            tblBayarAwal = "TransaksiPoliBayarAwal"
            fldTanggal = "TglPoli"
            fldTransaksiID = "TransPoliID"
        ElseIf ComboBoxJenisTransaksi.Text = "GIGI" Then
            tblTransaksi = "TransaksiGigi"
            tblBayar = "TransaksiGigiBayar"
            tblBayarAwal = "TransaksiGigiBayarAwal"
            fldTanggal = "TglGigi"
            fldTransaksiID = "TransGigiID"
        Else
            MsgBox("Pilih Jenis Transaksi terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Exit Sub
        End If

        Dim queryString As String = _
            "WITH FilteredTransaksi AS ( " & _
            "    SELECT " & fldTransaksiID & ", RekapID, CONVERT(DATE, " & fldTanggal & ") AS TglTransaksi " & _
            "    FROM " & tblTransaksi & " " & _
            "    WHERE (CONVERT(DATE, " & fldTanggal & ") BETWEEN '" & Format(DateTimeTglAwalTransaksi.Value, "yyyyMMdd") & "' AND '" & Format(DateTimeTglAkhirTransaksi.Value, "yyyyMMdd") & "') AND Deleted = 0 " & _
            "), " & _
            "DetailBayar AS ( " & _
            "    SELECT " & _
            "        ft.TglTransaksi, " & _
            "        tb.NoJenisBayar AS NoJenisBayar, " & _
            "        tb.JumlahBayar - tb.Kembali AS TotalBayar, " & _
            "        tb.NoInvoicePembayaran " & _
            "    FROM " & tblBayar & " tb " & _
            "    INNER JOIN FilteredTransaksi ft ON tb." & fldTransaksiID & " = ft." & fldTransaksiID & " " & _
            "    WHERE tb.JumlahBayar > 0 AND tb.JenisBayar IN ('Tagihan') " & noJenisBayar & _
            "    UNION ALL " & _
            "    SELECT " & _
            "        ft.TglTransaksi, " & _
            "        tba.NoJenisBayar AS NoJenisBayar, " & _
            "        tba.JumlahBayar - tba.Kembali AS TotalBayar, " & _
            "        tba.NoInvoicePembayaran " & _
            "    FROM " & tblBayarAwal & " tba " & _
            "    INNER JOIN FilteredTransaksi ft ON tba." & fldTransaksiID & " = ft." & fldTransaksiID & " " & _
            "    WHERE tba.JumlahBayar > 0 AND tba.JenisBayar IN ('Tagihan') " & noJenisBayar & _
            "), " & _
            "Summary AS ( " & _
            "    SELECT " & _
            "        NoJenisBayar, " & _
            "        TglTransaksi, " & _
            "        CAST(COUNT(*) AS VARCHAR) + ' Transaksi' AS JumlahOrang, " & _
            "        SUM(CASE WHEN NoInvoicePembayaran IS NOT NULL " & _
            "                 THEN TotalBayar ELSE 0 END) AS Closed, " & _
            "        SUM(CASE WHEN NoInvoicePembayaran IS NULL " & _
            "                 THEN TotalBayar ELSE 0 END) AS Unclosed, " & _
            "        SUM(TotalBayar) AS JumlahTagihan " & _
            "    FROM DetailBayar " & _
            "    GROUP BY NoJenisBayar, TglTransaksi " & _
            IIf(RadioButtonStatusBayarClosed.Checked, "HAVING SUM(CASE WHEN NoInvoicePembayaran IS NOT NULL THEN TotalBayar ELSE 0 END) > 0 ", "") & _
            IIf(RadioButtonStatusBayarUnClosed.Checked, "HAVING SUM(CASE WHEN NoInvoicePembayaran IS NULL THEN TotalBayar ELSE 0 END) > 0 ", "") & _
            "), " & _
            "Numbered AS ( " & _
            "    SELECT " & _
            "        ROW_NUMBER() OVER (PARTITION BY NoJenisBayar ORDER BY TglTransaksi) AS No, " & _
            "        NoJenisBayar, " & _
            "        TglTransaksi, " & _
            "        JumlahOrang, " & _
            "        Closed, " & _
            "        Unclosed, " & _
            "        JumlahTagihan " & _
            "    FROM Summary " & _
            ") " & _
            "SELECT " & _
            "    No, " & _
            "    NoJenisBayar, " & _
            "    CONVERT(VARCHAR, TglTransaksi, 103) AS TglTransaksi, " & _
            "    JumlahOrang, " & _
            "    Closed, " & _
            "    Unclosed, " & _
            "    JumlahTagihan " & _
            "FROM Numbered " & _
            "ORDER BY NoJenisBayar, CONVERT(DATE, TglTransaksi)"  ' <-- FIX: paksa cast DATE

        Dim tblTagihan As DataTable = ReadSQL(queryString)
        Dim tblLaporan As DataTable = New DataTable

        tblLaporan = CreateTable()
        tblLaporan.Rows.Clear()

        If tblTagihan.Rows.Count > 0 Then
            For Each rowTagihan As DataRow In tblTagihan.Rows
                Dim rowLaporan As DataRow = tblLaporan.NewRow
                rowLaporan("No") = rowTagihan("No").ToString()
                rowLaporan("NoJenisBayar") = rowTagihan("NoJenisBayar").ToString()  ' sekarang sudah ada

                Dim tglTransaksi As DateTime = DateTime.ParseExact(rowTagihan("TglTransaksi").ToString(), "dd/MM/yyyy", Nothing)
                rowLaporan("Tanggal Lab") = tglTransaksi.ToString("MM-dd-yyyy")

                rowLaporan("Jumlah Orang") = rowTagihan("JumlahOrang").ToString()

                If RadioButtonStatusBayarClosed.Checked Then
                    rowLaporan("Closed") = rowTagihan("Closed").ToString()
                    rowLaporan("Unclosed") = "0"
                    rowLaporan("Jumlah Tagihan") = rowTagihan("Closed").ToString()
                ElseIf RadioButtonStatusBayarUnClosed.Checked Then
                    rowLaporan("Closed") = "0"
                    rowLaporan("Unclosed") = rowTagihan("Unclosed").ToString()
                    rowLaporan("Jumlah Tagihan") = rowTagihan("Unclosed").ToString()
                Else
                    rowLaporan("Closed") = rowTagihan("Closed").ToString()
                    rowLaporan("Unclosed") = rowTagihan("Unclosed").ToString()
                    rowLaporan("Jumlah Tagihan") = rowTagihan("JumlahTagihan").ToString()
                End If

                tblLaporan.Rows.Add(rowLaporan)
            Next

            Dim tglAwal As Date = DateTimeTglAwalTransaksi.Value
            Dim tglAkhir As Date = DateTimeTglAkhirTransaksi.Value

            If tglAwal = tglAkhir Then
                txtgllab.Text = Format(tglAwal, "dd") & " " & BulanIndonesia(Format(tglAwal, "MM")) & " " & Format(tglAwal, "yyyy")
            Else
                txtgllab.Text = Format(tglAwal, "dd") & " " & BulanIndonesia(Format(tglAwal, "MM")) & " " & Format(tglAwal, "yyyy") & _
                                " s/d " & _
                                Format(tglAkhir, "dd") & " " & BulanIndonesia(Format(tglAkhir, "MM")) & " " & Format(tglAkhir, "yyyy")
            End If

            GridControlTagihan.DataSource = tblLaporan

            GridViewTagihan.Columns("No").Visible = False
            GridViewTagihan.Columns("NoJenisBayar").Visible = False
            GridViewTagihan.Columns("Tanggal Lab").Visible = True

            DisableAllButton()
        Else
            MsgBox("Tidak ada data yang ditampilkan.", MsgBoxStyle.Exclamation, "Warning!")
            Exit Sub
        End If
    End Sub

    Private Sub DisableAllButton()
        ' Status Bayar
        RadioButtonStatusBayarClosed.Enabled = False
        RadioButtonStatusBayarUnClosed.Enabled = False
        RadioButtonStatusBayarAll.Enabled = False

        ' Jenis Report
        RadioButtonJenisReportSummary.Enabled = False
        RadioButtonJenisReportDetail.Enabled = False

        ' Jenis Transaksi
        ComboBoxJenisTransaksi.Enabled = False

        ' Search Company
        ButtonCariPerusahaan.Enabled = False

        ' Search Button
        ButtonCariTagihan.Enabled = False
    End Sub

    Private Sub EnableAllButton()
        ' Status Bayar
        RadioButtonStatusBayarClosed.Enabled = True
        RadioButtonStatusBayarUnClosed.Enabled = True
        RadioButtonStatusBayarAll.Enabled = True

        ' Jenis Report
        RadioButtonJenisReportSummary.Enabled = True
        RadioButtonJenisReportDetail.Enabled = True

        ' Jenis Transaksi
        ComboBoxJenisTransaksi.Enabled = True

        ' Search Company
        ButtonCariPerusahaan.Enabled = True

        ' Search Button
        ButtonCariTagihan.Enabled = True
    End Sub

    Private Sub ButtonCetakLaporan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCetakLaporan.Click

        Dim Tbls As DataTable = GridControlTagihan.DataSource
        Dim Tdata As DataTable = New DataTable
        If Tbls.Rows.Count > 0 Then
            Report = New XtraReport

            If RadioButtonJenisReportSummary.Checked Then
                Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\Laporan\LapRekapSummaryTagihanLab.repx", True)
            ElseIf RadioButtonJenisReportDetail.Checked Then
                Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\Laporan\LapRekapDetailTagihanLab.repx", True)
            End If
            Report.DataSource = Tbls

            If RadioButtonJenisReportSummary.Checked = True Then
                Report.Bands.Item(BandKind.ReportHeader).Controls("lbljenissetoran").Text = "LAPORAN SUMMARY POLI UMUM (" & ComboBoxJenisTransaksi.Text & ")"
            ElseIf RadioButtonJenisReportDetail.Checked = True Then
                Report.Bands.Item(BandKind.ReportHeader).Controls("lbljenissetoran").Text = "LAPORAN DETAIL POLI UMUM (" & ComboBoxJenisTransaksi.Text & ")"
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


