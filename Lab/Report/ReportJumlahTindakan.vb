Public Class ReportJumlahTindakan
    Function CreateTable() As DataTable
        Dim Thasil As New DataTable

        insertRowToTbls(Thasil, "tyinterger", "No")
        insertRowToTbls(Thasil, "Typstring", "Tgl lab")
        insertRowToTbls(Thasil, "Typstring", "Nama Pemeriksaan")
        insertRowToTbls(Thasil, "Typstring", "Total Keseluruhan")
        insertRowToTbls(Thasil, "Typstring", "Kode M")
        insertRowToTbls(Thasil, "Typstring", "Kode L")
        insertRowToTbls(Thasil, "Typstring", "Pasien Umum")
        insertRowToTbls(Thasil, "typdate", "OrderBy")
        Return Thasil
    End Function

    Private Sub butprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butprint.Click
        Dim tindakan As String = ""
        Dim tbls_summ As New DataTable
        If rd1.Checked = True Then
            tindakan = "b.TindakanID in (520, 513, 521, 523, 524, 525, 504, 515, 518, 527, 581) and "
        ElseIf rd2.Checked = True Then
            tindakan = ""
        End If

        Dim Tbls As DataTable = ReadSQL("select CONVERT(date, a.TglLab) as 'TglLab', b.TindakanID, b.NamaTindakan, SUBSTRING(a.NoUrut, 9, 1) as 'Kode', c.NoJenisBayar, COUNT(a.TransLabID) as 'Total', c.TransLabID from TransaksiLab a inner join TransaksiLabDetail b on a.TransLabID=b.TransLabID inner join TransaksiLabBayar c on a.TransLabID=c.TransLabID where " & tindakan & "(CONVERT(date, a.TglLab) between '" & Format(dtprocess.Value, "yyyy-MM-dd") & "' and '" & Format(dtprocessend.Value, "yyyy-MM-dd") & "') and ((a.NoUrut like '%L%' and a.Status<>'OPEN') or (a.NoUrut like '%M%' and a.Status<>'OPEN' and a.SendKeu is not null)) and a.deleted <> 1 and (b.RefundID IS NULL OR b.RefundStatusTransaksi = 1) group by CONVERT(date, a.TglLab), b.TindakanID, b.NamaTindakan, SUBSTRING(a.NoUrut, 9, 1), c.NoJenisBayar, c.TransLabID order by CONVERT(date, a.TglLab), TindakanID, SUBSTRING(a.NoUrut, 9, 1), c.TransLabID")

        Dim Tdata As DataTable = New DataTable
        Dim TgllabStart As Date = "12/31/9998"
        Dim TindakanIDStart As String = ""
        Dim TempTranslabID As String = ""
        Dim NamaTindakan As String = ""
        Dim TotalKeseluruhan As Integer = 0
        Dim TotalKodeM As Integer = 0
        Dim TotalKodeL As Integer = 0
        Dim TotalPasienUmum As Integer = 0
        Dim number As Integer = 0 'Penomoran
        'Summary
        Dim TotalKeseluruhan_(5000) As Integer
        Dim TotalKodeM_(5000) As Integer
        Dim TotalKodeL_(5000) As Integer
        Dim TotalPasienUmum_(5000) As Integer
        Dim Nama_Pemeriksaan_(5000) As String
        Dim Tgl1 As Date = "12/31/9998"
        Dim Tgl2 As Date = "12/31/9998"

        If Tbls.Rows.Count > 0 Then
            Report = New XtraReport
            If rddetail.Checked = True Then
                Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\Laporan\LapRekapJumlahTransaksiPertindakanDetail.repx", True)
            ElseIf rdsummary.Checked = True Then
                Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\Laporan\LapRekapJumlahTransaksiPertindakanSummary.repx", True)
            End If
            Tdata = CreateTable()
            Tdata.Rows.Clear()

            If rdsummary.Checked = True Then
                tbls_summ = ReadSQL("select b.TindakanID, c.NamaTindakan from TransaksiLab a inner join TransaksiLabDetail b on a.TransLabID=b.TransLabID inner join MasterLab c on b.TindakanID=c.TindakanID where " & tindakan & "(CONVERT(date, a.TglLab) between '" & Format(dtprocess.Value, "yyyy-MM-dd") & "' and '" & Format(dtprocessend.Value, "yyyy-MM-dd") & "') and ((a.NoUrut like '%L%' and a.Status<>'OPEN') or (a.NoUrut like '%M%' and a.Status<>'OPEN' and a.SendKeu is not null)) and a.deleted <> 1 group by b.TindakanID, c.NamaTindakan order by c.NamaTindakan")
                For Each TrowSum As DataRow In tbls_summ.Rows
                    Nama_Pemeriksaan_("" & TrowSum("TindakanID") & "") = TrowSum("NamaTindakan").ToString.Trim
                    TotalKeseluruhan_("" & TrowSum("TindakanID") & "") = 0
                    TotalKodeM_("" & TrowSum("TindakanID") & "") = 0
                    TotalKodeL_("" & TrowSum("TindakanID") & "") = 0
                    TotalPasienUmum_("" & TrowSum("TindakanID") & "") = 0
                Next
            End If

            For Each TrowData As DataRow In Tbls.Rows
                'Periode Tanggal
                If Tgl1 = "12/31/9998" And Tgl2 = "12/31/9998" Then
                    Tgl1 = Format(TrowData("TglLab"), "MM-dd-yyyy")
                    Tgl2 = Format(TrowData("TglLab"), "MM-dd-yyyy")
                Else
                    If Format(TrowData("TglLab"), "MM-dd-yyyy") < Tgl1 Then
                        Tgl1 = Format(TrowData("TglLab"), "MM-dd-yyyy")
                    ElseIf Format(TrowData("TglLab"), "MM-dd-yyyy") > Tgl2 Then
                        Tgl2 = Format(TrowData("TglLab"), "MM-dd-yyyy")
                    End If
                End If

                If TgllabStart = "12/31/9998" Then
                    'INISIALISASI AWALAN (ROW 1)
                    TgllabStart = Format(TrowData("TglLab"), "MM-dd-yyyy")
                    TindakanIDStart = TrowData("TindakanID")
                    TempTranslabID = TrowData("TransLabID")
                    NamaTindakan = TrowData("NamaTindakan")
                    number = 1
                    TotalKeseluruhan = 1
                    If TrowData("Kode") = "L" Then
                        If TrowData("NoJenisBayar").ToString.Trim.Contains("Hallodoc-C190") = True Or TrowData("NoJenisBayar").ToString.Trim.Contains("HALODOC DRIVE THRU-C311") = True Or TrowData("NoJenisBayar").ToString.Trim.Contains("HALODOC HOMECARE-C312") = True Or TrowData("NoJenisBayar").ToString.Trim.Contains("HALLODOC (MCU)-C461") = True Then
                            TotalKodeL = 1
                        Else
                            TotalPasienUmum = 1
                        End If
                    ElseIf TrowData("Kode") = "M" Then
                        If TrowData("NoJenisBayar").ToString.Trim.Contains("Hallodoc-C190") = True Or TrowData("NoJenisBayar").ToString.Trim.Contains("HALODOC DRIVE THRU-C311") = True Or TrowData("NoJenisBayar").ToString.Trim.Contains("HALODOC HOMECARE-C312") = True Or TrowData("NoJenisBayar").ToString.Trim.Contains("HALLODOC (MCU)-C461") = True Then
                            TotalKodeM = 1
                        Else
                            TotalPasienUmum = 1
                        End If
                    End If
                Else
                    'JIKA TRANSAKSI MASIH DALAM 1 TANGGAL YANG SAMA DENGAN TANGGAL ROW SEBELUMNYA
                    If Format(TrowData("TglLab"), "MM-dd-yyyy") = TgllabStart Then
                        'JIKA TRANSAKSI SUDAH BEDA ID TINDAKAN DENGAN ROW SEBELUMNYA
                        If TrowData("TindakanID") <> TindakanIDStart Then
                            If rdsummary.Checked = True Then
                                TotalKeseluruhan_("" & TindakanIDStart & "") = TotalKeseluruhan_("" & TindakanIDStart & "") + TotalKeseluruhan
                                TotalKodeM_("" & TindakanIDStart & "") = TotalKodeM_("" & TindakanIDStart & "") + TotalKodeM
                                TotalKodeL_("" & TindakanIDStart & "") = TotalKodeL_("" & TindakanIDStart & "") + TotalKodeL
                                TotalPasienUmum_("" & TindakanIDStart & "") = TotalPasienUmum_("" & TindakanIDStart & "") + TotalPasienUmum
                            ElseIf rddetail.Checked = True Then
                                Dim Tnew2 As DataRow = Tdata.NewRow
                                Tnew2("No") = number 'OrderBy
                                Tnew2("Tgl lab") = Format(TgllabStart, "dd-MMM-yyyy")
                                Tnew2("OrderBy") = Format(TgllabStart, "MM-dd-yyyy")
                                Tnew2("Nama Pemeriksaan") = NamaTindakan
                                Tnew2("Total Keseluruhan") = TotalKeseluruhan
                                Tnew2("Kode M") = TotalKodeM
                                Tnew2("Kode L") = TotalKodeL
                                Tnew2("Pasien Umum") = TotalPasienUmum
                                Tdata.Rows.Add(Tnew2)
                            End If

                            number = number + 1

                            TotalKeseluruhan = 1
                            If TrowData("Kode") = "L" Then
                                If TrowData("NoJenisBayar").ToString.Trim.Contains("Hallodoc-C190") = True Or TrowData("NoJenisBayar").ToString.Trim.Contains("HALODOC DRIVE THRU-C311") = True Or TrowData("NoJenisBayar").ToString.Trim.Contains("HALODOC HOMECARE-C312") = True Or TrowData("NoJenisBayar").ToString.Trim.Contains("HALLODOC (MCU)-C461") = True Then
                                    TotalKodeL = 1
                                    TotalKodeM = 0
                                    TotalPasienUmum = 0
                                Else
                                    TotalPasienUmum = 1
                                    TotalKodeL = 0
                                    TotalKodeM = 0
                                End If
                            ElseIf TrowData("Kode") = "M" Then
                                If TrowData("NoJenisBayar").ToString.Trim.Contains("Hallodoc-C190") = True Or TrowData("NoJenisBayar").ToString.Trim.Contains("HALODOC DRIVE THRU-C311") = True Or TrowData("NoJenisBayar").ToString.Trim.Contains("HALODOC HOMECARE-C312") = True Or TrowData("NoJenisBayar").ToString.Trim.Contains("HALLODOC (MCU)-C461") = True Then
                                    TotalKodeM = 1
                                    TotalKodeL = 0
                                    TotalPasienUmum = 0
                                Else
                                    TotalPasienUmum = 1
                                    TotalKodeL = 0
                                    TotalKodeM = 0
                                End If
                                'TotalKodeM = 1
                                'TotalKodeL = 0
                            End If
                        Else
                            'REPEAT PER TRANSAKSI JIKA TANGGAL & ID TINDAKAN MASIH SAMA DENGAN ROW SEBELUMNYA
                            If TempTranslabID <> TrowData("TransLabID") Then
                                TotalKeseluruhan = TotalKeseluruhan + 1
                                If TrowData("Kode") = "L" Then
                                    If TrowData("NoJenisBayar").ToString.Trim.Contains("Hallodoc-C190") = True Or TrowData("NoJenisBayar").ToString.Trim.Contains("HALODOC DRIVE THRU-C311") = True Or TrowData("NoJenisBayar").ToString.Trim.Contains("HALODOC HOMECARE-C312") = True Or TrowData("NoJenisBayar").ToString.Trim.Contains("HALLODOC (MCU)-C461") = True Then
                                        TotalKodeL = TotalKodeL + 1
                                    Else
                                        TotalPasienUmum = TotalPasienUmum + 1
                                    End If
                                ElseIf TrowData("Kode") = "M" Then
                                    If TrowData("NoJenisBayar").ToString.Trim.Contains("Hallodoc-C190") = True Or TrowData("NoJenisBayar").ToString.Trim.Contains("HALODOC DRIVE THRU-C311") = True Or TrowData("NoJenisBayar").ToString.Trim.Contains("HALODOC HOMECARE-C312") = True Or TrowData("NoJenisBayar").ToString.Trim.Contains("HALLODOC (MCU)-C461") = True Then
                                        TotalKodeM = TotalKodeM + 1
                                    Else
                                        TotalPasienUmum = TotalPasienUmum + 1
                                    End If
                                End If
                            Else
                                'JIKA ADA DOUBLE PEMBAYARAN DALAM 1 TRANSAKSI
                                If TrowData("Kode") = "L" Then
                                    If TrowData("NoJenisBayar").ToString.Trim.Contains("Hallodoc-C190") = True Or TrowData("NoJenisBayar").ToString.Trim.Contains("HALODOC DRIVE THRU-C311") = True Or TrowData("NoJenisBayar").ToString.Trim.Contains("HALODOC HOMECARE-C312") = True Or TrowData("NoJenisBayar").ToString.Trim.Contains("HALLODOC (MCU)-C461") = True Then
                                        TotalKodeL = TotalKodeL + 1
                                        TotalPasienUmum = TotalPasienUmum - 1
                                    End If
                                ElseIf TrowData("Kode") = "M" Then
                                    If TrowData("NoJenisBayar").ToString.Trim.Contains("Hallodoc-C190") = True Or TrowData("NoJenisBayar").ToString.Trim.Contains("HALODOC DRIVE THRU-C311") = True Or TrowData("NoJenisBayar").ToString.Trim.Contains("HALODOC HOMECARE-C312") = True Or TrowData("NoJenisBayar").ToString.Trim.Contains("HALLODOC (MCU)-C461") = True Then
                                        TotalKodeM = TotalKodeM + 1
                                        TotalPasienUmum = TotalPasienUmum - 1
                                    End If
                                End If
                            End If
                        End If

                        TindakanIDStart = TrowData("TindakanID")
                        NamaTindakan = TrowData("NamaTindakan")
                        TempTranslabID = TrowData("TransLabID")
                        TgllabStart = Format(TrowData("TglLab"), "MM-dd-yyyy")
                    ElseIf Format(TrowData("TglLab"), "MM-dd-yyyy") <> TgllabStart Then
                        'JIKA SUDAH BEDA TANGGAL DENGAN ROW SEBELUMNYA
                        If rdsummary.Checked = True Then
                            TotalKeseluruhan_("" & TindakanIDStart & "") = TotalKeseluruhan_("" & TindakanIDStart & "") + TotalKeseluruhan
                            TotalKodeM_("" & TindakanIDStart & "") = TotalKodeM_("" & TindakanIDStart & "") + TotalKodeM
                            TotalKodeL_("" & TindakanIDStart & "") = TotalKodeL_("" & TindakanIDStart & "") + TotalKodeL
                            TotalPasienUmum_("" & TindakanIDStart & "") = TotalPasienUmum_("" & TindakanIDStart & "") + TotalPasienUmum
                        ElseIf rddetail.Checked = True Then
                            Dim Tnew2 As DataRow = Tdata.NewRow
                            Tnew2("No") = number
                            Tnew2("Tgl lab") = Format(TgllabStart, "dd-MMM-yyyy")
                            Tnew2("OrderBy") = Format(TgllabStart, "MM-dd-yyyy")
                            Tnew2("Nama Pemeriksaan") = NamaTindakan
                            Tnew2("Total Keseluruhan") = TotalKeseluruhan
                            Tnew2("Kode M") = TotalKodeM
                            Tnew2("Kode L") = TotalKodeL
                            Tnew2("Pasien Umum") = TotalPasienUmum
                            Tdata.Rows.Add(Tnew2)
                        End If

                        number = 1

                        TotalKeseluruhan = 1
                        If TrowData("Kode") = "L" Then
                            If TrowData("NoJenisBayar").ToString.Trim.Contains("Hallodoc-C190") = True Or TrowData("NoJenisBayar").ToString.Trim.Contains("HALODOC DRIVE THRU-C311") = True Or TrowData("NoJenisBayar").ToString.Trim.Contains("HALODOC HOMECARE-C312") = True Or TrowData("NoJenisBayar").ToString.Trim.Contains("HALLODOC (MCU)-C461") = True Then
                                TotalKodeL = 1
                                TotalKodeM = 0
                                TotalPasienUmum = 0
                            Else
                                TotalPasienUmum = 1
                                TotalKodeL = 0
                                TotalKodeM = 0
                            End If
                        ElseIf TrowData("Kode") = "M" Then
                            If TrowData("NoJenisBayar").ToString.Trim.Contains("Hallodoc-C190") = True Or TrowData("NoJenisBayar").ToString.Trim.Contains("HALODOC DRIVE THRU-C311") = True Or TrowData("NoJenisBayar").ToString.Trim.Contains("HALODOC HOMECARE-C312") = True Or TrowData("NoJenisBayar").ToString.Trim.Contains("HALLODOC (MCU)-C461") = True Then
                                TotalKodeM = 1
                                TotalKodeL = 0
                                TotalPasienUmum = 0
                            Else
                                TotalPasienUmum = 1
                                TotalKodeL = 0
                                TotalKodeM = 0
                            End If
                            'TotalKodeM = 1
                            'TotalKodeL = 0
                        End If

                        TindakanIDStart = TrowData("TindakanID")
                        NamaTindakan = TrowData("NamaTindakan")
                        TempTranslabID = TrowData("TransLabID")
                        TgllabStart = Format(TrowData("TglLab"), "MM-dd-yyyy")
                    End If
                End If
            Next

            'ROW TERAKHIR
            If rdsummary.Checked = True Then
                TotalKeseluruhan_("" & TindakanIDStart & "") = TotalKeseluruhan_("" & TindakanIDStart & "") + TotalKeseluruhan
                TotalKodeM_("" & TindakanIDStart & "") = TotalKodeM_("" & TindakanIDStart & "") + TotalKodeM
                TotalKodeL_("" & TindakanIDStart & "") = TotalKodeL_("" & TindakanIDStart & "") + TotalKodeL
                TotalPasienUmum_("" & TindakanIDStart & "") = TotalPasienUmum_("" & TindakanIDStart & "") + TotalPasienUmum
            ElseIf rddetail.Checked = True Then
                Dim Tnew As DataRow = Tdata.NewRow
                Tnew("No") = number
                Tnew("Tgl lab") = Format(TgllabStart, "dd-MMM-yyyy")
                Tnew("OrderBy") = Format(TgllabStart, "MM-dd-yyyy")
                Tnew("Nama Pemeriksaan") = NamaTindakan
                Tnew("Total Keseluruhan") = TotalKeseluruhan
                Tnew("Kode M") = TotalKodeM
                Tnew("Kode L") = TotalKodeL
                Tnew("Pasien Umum") = TotalPasienUmum
                Tdata.Rows.Add(Tnew)
            End If

            If rdsummary.Checked = True Then
                number = 1
                For Each TrowSum As DataRow In tbls_summ.Rows
                    Dim Tsum As DataRow = Tdata.NewRow
                    Tsum("No") = number
                    If Tgl1 = Tgl2 Then
                        Tsum("Tgl lab") = Format(Tgl1, "dd") & " " & BulanIndonesia(Format(Tgl1, "MM")) & " " & Format(Tgl1, "yyyy")
                    Else
                        Tsum("Tgl lab") = Format(Tgl1, "dd") & " " & BulanIndonesia(Format(Tgl1, "MM")) & " " & Format(Tgl1, "yyyy") & " s/d " & Format(Tgl2, "dd") & " " & BulanIndonesia(Format(Tgl2, "MM")) & " " & Format(Tgl2, "yyyy")
                    End If
                    'Tsum("Tgl lab") = Format(DateTime.Now, "dd-MMM-yyyy")
                    Tsum("OrderBy") = Format(DateTime.Now, "MM-dd-yyyy")
                    Tsum("Nama Pemeriksaan") = Nama_Pemeriksaan_("" & TrowSum("TindakanID") & "")
                    Tsum("Total Keseluruhan") = TotalKeseluruhan_("" & TrowSum("TindakanID") & "")
                    Tsum("Kode M") = TotalKodeM_("" & TrowSum("TindakanID") & "")
                    Tsum("Kode L") = TotalKodeL_("" & TrowSum("TindakanID") & "")
                    Tsum("Pasien Umum") = TotalPasienUmum_("" & TrowSum("TindakanID") & "")
                    Tdata.Rows.Add(Tsum)

                    number = number + 1
                Next
            End If

            Report.DataSource = Tdata
            Report.Bands.Item(BandKind.ReportHeader).Controls("lbljenissetoran").Text = "LAPORAN JUMLAH TRANSAKSI PER TINDAKAN"
            Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:ss") & " By " & PoliKlinik.Lbluser.Text

            'Report.RunDesigner()
            Report.ShowPreview()
        End If
    End Sub

    Private Sub ReportJumlahTindakan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        rd1.Checked = True
        rddetail.Checked = True
    End Sub
End Class

