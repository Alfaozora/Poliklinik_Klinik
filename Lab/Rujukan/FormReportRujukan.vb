Imports System.Drawing


Public Class FormReportRujukan
    Dim Tstr As String = ""
    Dim thread As System.Threading.Thread

    Function CreateTable() As DataTable
        Dim Thasil As New DataTable

        insertRowToTbls(Thasil, "tyinterger", "No")
        insertRowToTbls(Thasil, "Typstring", "NoSuratRujukan")
        insertRowToTbls(Thasil, "Typstring", "NamaLabRujukan")
        insertRowToTbls(Thasil, "typdate", "Tanggal Rujukan")
        insertRowToTbls(Thasil, "tyinterger", "TotalBiayaRujukan")
        insertRowToTbls(Thasil, "Typstring", "TindakanLabRujukan")

        For Each Tcol As DataColumn In Thasil.Columns
            Tcol.ReadOnly = True
        Next

        Return Thasil
    End Function

    Function CreateTableDetail() As DataTable
        Dim Thasil As New DataTable

        insertRowToTbls(Thasil, "tyinterger", "No")
        insertRowToTbls(Thasil, "Typstring", "Nama")
        insertRowToTbls(Thasil, "Typstring", "NoInvoice")
        insertRowToTbls(Thasil, "Typstring", "NoSuratRujukan")
        insertRowToTbls(Thasil, "Typstring", "NamaLabRujukan")
        insertRowToTbls(Thasil, "typdate", "Tanggal Rujukan")
        insertRowToTbls(Thasil, "typdate", "Tanggal Transaksi")
        insertRowToTbls(Thasil, "tyinterger", "TotalBiayaRujukan")
        insertRowToTbls(Thasil, "Typstring", "TindakanLabRujukan")

        For Each Tcol As DataColumn In Thasil.Columns
            Tcol.ReadOnly = True
        Next

        Return Thasil
    End Function

    Private Sub SetClear()
        gridpasien.DataSource = Nothing
        exportpdf.Enabled = False
        txcompanycode.ResetText()
        txkodecabang.ResetText()
        rdsummary.Checked = True
        txtindakanid.ResetText()
        txtindakanket.ResetText()
    End Sub

    Private Sub FormReportRujukan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        SetFormHeightWeight(Me, 0.95, 0.8)
        'Me.Dock = DockStyle.Left
        NewToolStripMenuItem1.PerformClick()
        Control.CheckForIllegalCrossThreadCalls = False
    End Sub

    Private Sub NewToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem1.Click
        SetClear()
    End Sub

    Private Sub PilihCompanyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Find.Show()
        Find.Query("select IDCompany, CompanyCode, CompanyNama, NoCompany from mastercompany a", " ORDER BY a.idcompany desc", "FindCabangSummary", 2)
    End Sub

    Public Sub LoadCompany(ByRef txkode As String, ByRef txlocationket As String)
        'txcompany.Text = txlocationket
        txkodecabang.Text = txkode
    End Sub

    Private Sub butfindcompany_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butfindcompany.Click
        Find.Show()
        Find.Query("select NamaLabRujukan, AlamatLabRujukan, UpLabRujukan, NoLabRujukan from MasterLaboratoriumRujukan a where getdate() between StartDate and EndDate", " ORDER BY a.IDLabRujukan desc", "FindCabangReportRujukan", 2)
    End Sub

    'Private Sub butfindpaket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Find.Show()
    '    Find.Query("select PaketID as ID,PaketNama,PaketKeterangan,PARSENAME(CONVERT(varchar,convert(money,PaketNilaiTotal),1),2) as PaketNilaiTotal,PaketStart,PaketEnd from MasterLabPaket where GETDATE() between PaketStart and PaketEnd ", " order by PaketID DESC ", "FindPaketIDFormReportRujukan", 2)
    'End Sub

    Private Sub buttambahpasien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttambahpasien.Click
        Dim Tquery As String = ""
        Dim Tcompany As String = ""
        Dim Ttindakan As String = ""
        Dim Tjenistransaksi As String = ""
        Dim Tpemeriksaan As String = ""
        Dim TDetailPemeriksaan As DataTable = New DataTable
        Dim DetailPemeriksaan As String = ""
        Dim TtempDetailPemeriksaan As String = ""
        Dim TgllabStart As Date = "12/31/9998"
        Dim TgllabEnd As Date = "12/31/9998"
        Dim Tbls As DataTable = New DataTable
        Dim Tdata As DataTable = New DataTable

        'Company
        If txtindakanid.Text <> "" Then
            Ttindakan = " and a.IDSuratRujukan in (select c.NoSuratRujukan from TransaksiLabDetail c where c.TindakanID='" & txtindakanid.Text & "')"
        Else
            Ttindakan = " "
        End If

        'Company
        If txcompanycode.Text <> "" Then
            Tcompany = " and a.NoLabRujukan='" & txkodecabang.Text & "'"
        Else
            Tcompany = " "
        End If

        'Query Utama
        Tquery = "select ROW_NUMBER() OVER (ORDER BY a.NoLabRujukan, a.TglKirim, a.IDSuratRujukan asc)  AS 'No', a.NoLabRujukan, a.IDSuratRujukan, a.NoSuratRujukan, b.NamaLabRujukan, a.TglKirim as 'Tgl Rujukan' from TransaksiRujukanLab a left join MasterLaboratoriumRujukan b on a.NoLabRujukan=b.NoLabRujukan where a.deleted IS NULL AND (CONVERT(date, a.TglKirim) between '" & Format(dtprocess.Value, "MM-dd-yyyy") & "' and '" & Format(dtprocessend.Value, "MM-dd-yyyy") & "') " & Tcompany & Ttindakan & " order by a.NoLabRujukan, a.TglKirim, a.IDSuratRujukan asc"
        Tbls = ReadSQL(Tquery)
        Tdata = CreateTable()
        Tdata.Rows.Clear()

        Dim temppt As String = ""
        Dim temppt2 As String = ""
        Dim number As Integer = 0

        Tstr = ""
        Dim Ttemp As String = "("

        If Tbls.Rows.Count > 0 Then
            For Each TrowData As DataRow In Tbls.Rows
                Dim Tnew As DataRow = Tdata.NewRow

                'Set Row Rujukan
                Ttemp = Ttemp & "'" & TrowData("NoSuratRujukan").ToString.Trim & "',"

                'Periode Tanggal
                If TgllabStart = "12/31/9998" And TgllabEnd = "12/31/9998" Then
                    TgllabStart = Format(TrowData("Tgl Rujukan"), "MM-dd-yyyy")
                    TgllabEnd = Format(TrowData("Tgl Rujukan"), "MM-dd-yyyy")
                Else
                    If Format(TrowData("Tgl Rujukan"), "MM-dd-yyyy") < TgllabStart Then
                        TgllabStart = Format(TrowData("Tgl Rujukan"), "MM-dd-yyyy")
                    ElseIf Format(TrowData("Tgl Rujukan"), "MM-dd-yyyy") > TgllabEnd Then
                        TgllabEnd = Format(TrowData("Tgl Rujukan"), "MM-dd-yyyy")
                    End If
                End If

                'Create Number Start
                temppt2 = TrowData("NoLabRujukan")
                temppt2 = temppt2.ToUpper

                If temppt = "" Then
                    number = number + 1
                ElseIf temppt = temppt2 Then
                    number = number + 1
                Else
                    number = 0
                    number = number + 1
                End If

                temppt = TrowData("NoLabRujukan")
                temppt = temppt.ToUpper
                'Create Number End

                Tnew("NoSuratRujukan") = TrowData("NoSuratRujukan")
                Tnew("No") = number
                Tnew("NamaLabRujukan") = TrowData("NamaLabRujukan")
                Tnew("Tanggal Rujukan") = TrowData("Tgl Rujukan")

                TtempDetailPemeriksaan = ""
                If txtindakanid.Text <> "" Then
                    Tnew("TotalBiayaRujukan") = ReadSQLNIK("select SUM(Biaya) from TransaksiLabDetail where TindakanID in ('" & txtindakanid.Text & "') and NoSuratRujukan='" & TrowData("IDSuratRujukan") & "'")
                    TDetailPemeriksaan = ReadSQL("select NamaTindakan from TransaksiLabDetail where TindakanID in ('" & txtindakanid.Text & "') and NoSuratRujukan='" & TrowData("IDSuratRujukan") & "' group by NamaTindakan")
                Else
                    Tnew("TotalBiayaRujukan") = ReadSQLNIK("select SUM(Biaya) from TransaksiLabDetail where NoSuratRujukan='" & TrowData("IDSuratRujukan") & "'")
                    TDetailPemeriksaan = ReadSQL("select NamaTindakan from TransaksiLabDetail where NoSuratRujukan='" & TrowData("IDSuratRujukan") & "' group by NamaTindakan")
                End If

                For Each TRowDetailPemeriksaan As DataRow In TDetailPemeriksaan.Rows
                    TtempDetailPemeriksaan = TtempDetailPemeriksaan & "" & TRowDetailPemeriksaan("NamaTindakan").ToString.Trim & ", "
                Next
                DetailPemeriksaan = Strings.Left(TtempDetailPemeriksaan, TtempDetailPemeriksaan.Length - 2)

                Tnew("TindakanLabRujukan") = DetailPemeriksaan
                Tdata.Rows.Add(Tnew)
            Next

            If TgllabStart = TgllabEnd Then
                txtgllab.Text = Format(TgllabStart, "dd") & " " & BulanIndonesia(Format(TgllabStart, "MM")) & " " & Format(TgllabStart, "yyyy")
            Else
                txtgllab.Text = Format(TgllabStart, "dd") & " " & BulanIndonesia(Format(TgllabStart, "MM")) & " " & Format(TgllabStart, "yyyy") & " s/d " & Format(TgllabEnd, "dd") & " " & BulanIndonesia(Format(TgllabEnd, "MM")) & " " & Format(TgllabEnd, "yyyy")
            End If

            txrownorujuk.Text = Strings.Left(Ttemp, Ttemp.Length - 1) & ")"

            gridpasien.DataSource = Tdata
            GridView1.Columns("No").Visible = False
            exportpdf.Enabled = True
        Else
            MsgBox("Tidak ada data yang ditampilkan.", MsgBoxStyle.Exclamation, "Warning!")
            exportpdf.Enabled = False
            Exit Sub
        End If
    End Sub

    Private Sub exportpdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exportpdf.Click
        Dim Tbls As DataTable = gridpasien.DataSource
        If Tbls.Rows.Count > 0 Then
            Report = New XtraReport

            If rdsummary.Checked = True Then
                Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\Rujukan\LapReportRujukanSummary.repx", True)
                Report.DataSource = Tbls
            ElseIf rddetail.Checked = True Then
                Dim Tquery As String = ""
                Dim Torderby As String = ""
                Dim Tgroupby As String = ""
                Dim Number As Integer = 0
                Dim TempNoSurat As String = ""
                Dim Tdata As DataTable = New DataTable
                Dim TblsDetail As DataTable = New DataTable

                Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\Rujukan\LapReportRujukanDetail.repx", True)

                'Query
                Tquery = "SELECT '-' AS 'No', a.TransLabID, NoUrut, CONVERT(DATE, TglLab) AS 'Tgl Lab', c.Nama, '-' AS 'DetailPemeriksaan', d.NoSuratRujukan, d.NoLabRujukan, e.NamaLabRujukan, CONVERT(date, d.TglKirim) AS 'TglKirim', SUM(b.Biaya) AS 'Total' FROM TransaksiLab a " & _
                         " LEFT JOIN TransaksiLabDetail b ON a.TransLabID = b.TransLabID" & _
                         " LEFT JOIN MasterPasien c ON a.IDInternet = c.NoRekamMedis" & _
                         " LEFT JOIN TransaksiRujukanLab d ON b.NoSuratRujukan = d.IDSuratRujukan" & _
                         " LEFT JOIN MasterLaboratoriumRujukan e ON d.NoLabRujukan = e.NoLabRujukan" & _
                         " WHERE(d.deleted Is NULL) AND d.NoSuratRujukan IN " & txrownorujuk.Text & ""

                Tgroupby = " GROUP BY a.TransLabID, a.NoUrut, CONVERT(DATE, TglLab), c.Nama, d.NoSuratRujukan, d.NoLabRujukan, e.NamaLabRujukan, CONVERT(date, d.TglKirim)"
                Torderby = " ORDER BY NoLabRujukan, CONVERT(date, d.TglKirim), NoSuratRujukan, NoUrut ASC"

                TblsDetail = ReadSQL(Tquery & Tgroupby & Torderby)
                Tdata = CreateTableDetail()
                Tdata.Rows.Clear()

                If Tbls.Rows.Count > 0 Then
                    For Each TrowData As DataRow In TblsDetail.Rows
                        Dim Tnew As DataRow = Tdata.NewRow

                        If TempNoSurat = "" Then
                            Number = 1
                        ElseIf TempNoSurat = TrowData("NoSuratRujukan") Then
                            Number = Number + 1
                        ElseIf TempNoSurat <> TrowData("NoSuratRujukan") Then
                            Number = 1
                        End If

                        TempNoSurat = TrowData("NoSuratRujukan")

                        Tnew("No") = Number
                        Tnew("Nama") = TrowData("Nama").ToString.ToUpper()
                        Tnew("NoInvoice") = TrowData("NoUrut")
                        Tnew("NoSuratRujukan") = TrowData("NoSuratRujukan")
                        Tnew("NamaLabRujukan") = TrowData("NamaLabRujukan")
                        Tnew("Tanggal Rujukan") = Format(TrowData("TglKirim"), "MM-dd-yyyy")
                        Tnew("Tanggal Transaksi") = Format(TrowData("Tgl Lab"), "MM-dd-yyyy")
                        Tnew("TotalBiayaRujukan") = TrowData("Total")
                        Tnew("TindakanLabRujukan") = SetTindakanDetailRujukan(TrowData("NoUrut"), TrowData("NoSuratRujukan"))

                        Tdata.Rows.Add(Tnew)
                    Next
                End If

                Report.DataSource = Tdata
                End If

            If rdsummary.Checked = True Then
                Report.Bands.Item(BandKind.ReportHeader).Controls("lbljenissetoran").Text = "LAPORAN RUJUKAN LABORATORIUM (SUMMARY)"
            ElseIf rddetail.Checked = True Then
                Report.Bands.Item(BandKind.ReportHeader).Controls("lbljenissetoran").Text = "LAPORAN RUJUKAN LABORATORIUM (DETAIL)"
            End If

            Report.Bands.Item(BandKind.ReportHeader).Controls("lbltanggal").Text = txtgllab.Text
            Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:ss") & " By " & PoliKlinik.Lbluser.Text

            'Report.RunDesigner()
            Report.ShowPreview()
            'Report.Print()
        Else
            MsgBox("Tidak ada data yang ditampilkan.", MsgBoxStyle.Exclamation, "Warning!")
            Exit Sub
        End If
    End Sub

    Private Sub buttindakan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttindakan.Click
        Find.Show()
        Find.Query("select TindakanID, NamaTindakan, JenisTindakan from MasterLab where TindakanID in (select TindakanID from MasterHargaTindakanRujukan) and Closed <> 1", " ORDER BY TindakanID asc", "FindTindakanReportRujukan", 2)
    End Sub

    Function SetTindakanDetailRujukan(ByVal NoUrut As String, ByVal NoRujukan As String) As String
        Dim TDetailPemeriksaan As DataTable = New DataTable
        Dim DetailPemeriksaan As String = ""
        Dim TtempDetailPemeriksaan As String = ""

        TDetailPemeriksaan = ReadSQL("SELECT b.NamaTindakan FROM TransaksiLab a LEFT JOIN TransaksiLabDetail b ON a.TransLabID = b.TransLabID WHERE NoSuratRujukan IN (SELECT IDSuratRujukan FROM TransaksiRujukanLab WHERE NoSuratRujukan = '" & NoRujukan & "') AND NoUrut = '" & NoUrut & "' ")
        For Each TRowDetailPemeriksaan As DataRow In TDetailPemeriksaan.Rows
            TtempDetailPemeriksaan = TtempDetailPemeriksaan & "" & TRowDetailPemeriksaan("NamaTindakan").ToString.Trim & ", "
        Next

        DetailPemeriksaan = Strings.Left(TtempDetailPemeriksaan, TtempDetailPemeriksaan.Length - 2)

        Return DetailPemeriksaan
    End Function
End Class


