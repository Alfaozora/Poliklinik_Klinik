
Public Class ReportSumaaryDinkes

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If dtawal.Value > dtakhir.Value Then
            MsgBox("Tanggal awal tidak boleh lebih kecil dari tanggal akhir")
        Else
            Dim Tbls As New DataTable

            If rdsummary.Checked = True Then
                Tbls = ReadSQL("select year(getdate())-YEAR(b.TglLahir) as Usia,b.Sex,PoliDiagnosa,COUNT(*) from TransaksiPoli a " & _
                               " left join MasterCustomer b on a.IDInternet=b.nomitra where CONVERT(date, a.TglPoli) between '" & Format(dtawal.Value, "MM/dd/yyyy") & "' and '" & Format(dtakhir.Value, "MM/dd/yyyy") & "' " & _
                               " group by YEAR(b.TglLahir),b.Sex,PoliDiagnosa order by YEAR(b.TglLahir),b.Sex,PoliDiagnosa ")

                Report = New XtraReport
                Report = XtraReport.FromFile(Application.StartupPath + "\reports\Klinik\DinkesSummary.repx", True)
                Report.DataSource = Tbls
                'Report.RunDesigner()
                Report.ShowPreview()
                Report.Print()

            ElseIf rddetail.Checked = True Then
                Tbls = ReadSQL("select a.TransPoliID,a.IDInternet as ID,b.Nama,b.Sex,b.TglLahir,year(getdate())-YEAR(b.TglLahir) as Usia,a.DokterPoli,a.TglPoli, a.PoliDiagnosa as Diagnosa from TransaksiPoli a " & _
                               " left join MasterCustomer b on a.IDInternet=b.nomitra where CONVERT(date, a.TglPoli) between '" & Format(dtawal.Value, "MM/dd/yyyy") & "' and '" & Format(dtakhir.Value, "MM/dd/yyyy") & "' order by YEAR(b.TglLahir),b.Sex,PoliDiagnosa ")

                Report = New XtraReport
                Report = XtraReport.FromFile(Application.StartupPath + "\reports\PrintTindakancopied.repx", True)
                'Report = XtraReport.FromFile(Application.StartupPath + "\reports\DinkesDetail.repx", True)
                Report.DataSource = Tbls
                'Report.RunDesigner()
                Report.ShowPreview()
                'Report.Print()

            End If

        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If dtawal.Value > dtakhir.Value Then
            MsgBox("Tanggal awal tidak boleh lebih kecil dari tanggal akhir")
        Else
            Dim Tbls As New DataTable

            If rdsummary.Checked = True Then
                Tbls = ReadSQL("select year(getdate())-YEAR(b.TglLahir) as Usia,b.Sex,PoliDiagnosa,COUNT(*) from TransaksiPoli a " & _
                               " left join MasterCustomer b on a.IDInternet=b.nomitra where CONVERT(date, a.TglPoli) between '" & Format(dtawal.Value, "MM/dd/yyyy") & "' and '" & Format(dtakhir.Value, "MM/dd/yyyy") & "' " & _
                               " group by YEAR(b.TglLahir),b.Sex,PoliDiagnosa order by YEAR(b.TglLahir),b.Sex,PoliDiagnosa ")

                GridControl1.DataSource = Tbls
                ExportDataToExcel(GridControl1)

            ElseIf rddetail.Checked = True Then
                Tbls = ReadSQL("select a.TransPoliID,a.IDInternet as ID,b.Nama,b.Sex,b.TglLahir,year(getdate())-YEAR(b.TglLahir) as Usia,a.DokterPoli,a.TglPoli, a.PoliDiagnosa as Diagnosa from TransaksiPoli a " & _
                               " left join MasterCustomer b on a.IDInternet=b.nomitra where CONVERT(date, a.TglPoli) between '" & Format(dtawal.Value, "MM/dd/yyyy") & "' and '" & Format(dtakhir.Value, "MM/dd/yyyy") & "' order by YEAR(b.TglLahir),b.Sex,PoliDiagnosa ")

                GridControl1.DataSource = Tbls
                ExportDataToExcel(GridControl1)

            End If

        End If
    End Sub

    Private Sub ReportSumaaryDinkes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik

    End Sub
End Class