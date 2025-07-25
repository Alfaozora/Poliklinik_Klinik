Imports Microsoft.Reporting.WinForms

Public Class Form3

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Inisialisasi ReportViewer
        ReportViewer1.ProcessingMode = ProcessingMode.Local
        ReportViewer1.LocalReport.ReportPath = "D:\Data Danif\Kebutuhan Kerja\Cahaya Medika Healthcare\Program\Poliklinik 2022\PoliKlinik@Net\Form_Trial\Report1.rdlc"

        ' Membuat sebuah DataTable dan mengisi data
        Dim dataTable As New DataTable()
        dataTable.Columns.Add("nama")
        dataTable.Columns.Add("keterangan")
        dataTable.Rows.Add("John Doe", 30)
        dataTable.Rows.Add("Jane Smith", 25)

        ' Mengisi ReportDataSource dengan DataTable
        Dim reportDataSource As New ReportDataSource("DataSet1", dataTable)
        ReportViewer1.LocalReport.DataSources.Clear()
        ReportViewer1.LocalReport.DataSources.Add(reportDataSource)

        ' Refresh dan tampilkan laporan
        ReportViewer1.RefreshReport()
    End Sub
End Class