Public Class ReportLabFisik

    Private Sub butdisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butdisplay.Click
        If dtakhir.Value < dtawal.Value Then
            MsgBox("Tanggal akhir tidak blh lebh kecil dari tanggal awal")
            Exit Sub
        Else
            PerhitunganFisik()
        End If
    End Sub

    Private Sub PerhitunganFisik()
        Report = New XtraReport
        'Report = XtraReport.FromFile(Application.StartupPath + "\reports\PrintHasilLabThorax.repx", True)
        Report = XtraReport.FromFile(Application.StartupPath + "\reports\PrintSummaryFisik.repx", True)
        Report.DataSource = ReadSQL("select YEAR(b.TglLab) as YY,MONTH(b.TglLab) as MM,DAY(b.TglLab) as DD,Result,COUNT(*) as Jumlah " & _
                                    " from TransaksiLabFisik a left join TransaksiLab b on a.NoUrut=b.NoUrut left join MasterCustomer c on c.nomitra=b.IDInternet " & _
                                    " where a.NoUrut<>'' and FisikKet='dokterpelaksana' and CONVERT(date, b.TglLab) between '" & Format(dtawal.Value, "MM/dd/yyyy") & "' and '" & Format(dtakhir.Value, "MM/dd/yyyy") & "' group by a.Result,YEAR(b.TglLab),MONTH(b.TglLab),DAY(b.TglLab),Result order by Result,YEAR(b.TglLab),MONTH(b.TglLab),DAY(b.TglLab)")
        Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:ss") + PoliKlinik.Lbluser.Text

        'Report.RunDesigner()
        Report.ShowPreview()
    End Sub

End Class