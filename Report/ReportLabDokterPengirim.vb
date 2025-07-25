Public Class ReportLabDokterPengirim

    Dim Thasil As DataTable

    Private Sub butdisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butdisplay.Click
        Dim Tbls As DataTable = ReadSQL("select c.TransLabID,c.NoUrut,c.IDInternet,d.Nama,case when deleted=1 then 'TRANS DELETED' else c.DokterLab end as DokterLab,c.TglLab,c.TotalTagihan,c.TotalDisc,c.NettBayar,c.ClosedBayar,c.ClosedInputHasil,a.IdKirim,a.DrNama,b.IdPraktek,b.NamaPraktek,b.AlamatPraktek  " & _
                                        " from TransaksiLab c left join MasterCustomer d on d.nomitra=c.IDInternet left join MasterDokterTempatPraktek b on b.IdPraktek=c.DokterRequest left join MasterDokterKirim a on a.IdKirim=b.IdKirim " & _
                                        " where CONVERT(date, c.TglLab) between '" & Format(dtkasirawal.Value, "MM/dd/yyyy") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy") & "' order by b.IdPraktek,b.IdKirim,c.NoUrut,c.TglLab")

        Report = New XtraReport
        Report = XtraReport.FromFile(Application.StartupPath + "\reports\LapDokterPengirim.repx", True)
        Report.DataSource = Tbls
        Report.Bands.Item(BandKind.ReportHeader).Controls("lbltanggal").Text = Format(dtkasirawal.Value, "dd-MMM-yyyy ") & " - " & Format(dtkasirakhir.Value, "dd-MMM-yyyy ")
        Report.Bands.Item(BandKind.ReportFooter).Controls("lbltanggalacc").Text = ".............. ," & Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:sss")
        'Report.RunDesigner()
        Report.ShowPreview()
        'Report.Print()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Tbls As DataTable = ReadSQL(" select a.DrNama,b.IdPraktek,b.NamaPraktek,b.AlamatPraktek , COUNT(*)  " & _
                                        " from TransaksiLab c left join MasterCustomer d on d.nomitra=c.IDInternet left join MasterDokterTempatPraktek b on b.IdPraktek=c.DokterRequest left join MasterDokterKirim a on a.IdKirim=b.IdKirim " & _
                                        " where CONVERT(date, c.TglLab) between '" & Format(dtkasirawal.Value, "MM/dd/yyyy") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy") & "' group by a.DrNama,b.IdPraktek,b.NamaPraktek,b.AlamatPraktek  order by a.DrNama,b.IdPraktek,b.NamaPraktek,b.AlamatPraktek ")

        Report = New XtraReport
        Report = XtraReport.FromFile(Application.StartupPath + "\reports\LapDokterPengirimSummaryJumlah.repx", True)
        Report.DataSource = Tbls
        Report.Bands.Item(BandKind.ReportHeader).Controls("lbltanggal").Text = Format(dtkasirawal.Value, "dd-MMM-yyyy ") & " - " & Format(dtkasirakhir.Value, "dd-MMM-yyyy ")
        Report.Bands.Item(BandKind.ReportFooter).Controls("lbltanggalacc").Text = ".............. ," & Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:sss")
        'Report.RunDesigner()
        Report.ShowPreview()
        'Report.Print()
    End Sub

    Private Sub ReportLabDokterPengirim_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
    End Sub
End Class