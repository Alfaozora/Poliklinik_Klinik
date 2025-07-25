Public Class ReportSummaryJenisPenyakit


    Private Sub SetClear()
        rdpasienall.Checked = True
        rdtanggal.Checked = True
        dtawal.Value = DateAndTime.Now
        dtakhir.Value = DateAndTime.Now
    End Sub

    Function Checking() As Boolean
        If dtawal.Value > dtakhir.Value Then
            MsgBox("Tanggal awal tidak boleh lebih dari tanggal akhir")
            Return False
        End If

        Return True
    End Function

    Private Sub butdisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butdisplay.Click
        If Checking() = True Then
            Dim Tquery As String = "select TOP 10 MONTH(tglpoli) as Bln,YEAR(tglpoli) as Thn,LEFT(nokartupembayaran,11) as Company ,NoICD10 as Jenis,COUNT(*) from TransaksiPoli where CONVERT(date, TglPoli) between '" & Format(dtawal.Value, "MM/dd/yyyy") & "' and '" & Format(dtakhir.Value, "MM/dd/yyyy") & "' and deleted=0 "

            Dim Torder As String = " group by MONTH(tglpoli),YEAR(tglpoli),LEFT(nokartupembayaran,11),NoICD10 order by LEFT(nokartupembayaran,11),YEAR(tglpoli),MONTH(tglpoli),NoICD10"
            Dim Tstatus As String = "  "

            If rdpasienall.Checked = True Then
                Tstatus = " "
            ElseIf rdpasienumum.Checked = True Then
                Tstatus = " and PoliJenisPasien='Umum' "
                'ElseIf rdpasienf1b.Checked = True Then
                '    Tstatus = " and PoliJenisPasien='...'"
            ElseIf rdpasienpoliini.Checked = True Then
                Tstatus = " and PoliJenisPasien='CMH' "
            ElseIf rdpasienpolilain.Checked = True Then
                Tstatus = " and PoliJenisPasien='....' "
            ElseIf rdpasienbpjs.Checked = True Then
                Tstatus = " and PoliJenisPasien='BPJS' "
            End If

            Dim Tbls As DataTable = ReadSQL(Tquery + Tstatus + Torder)

            Report = New XtraReport
            Report = XtraReport.FromFile(Application.StartupPath + "\reports\LapJenisPenyakitperPeriode.repx", True)
            Report.DataSource = Tbls
            'Report.RunDesigner()
            Report.ShowPreview()
            'Report.Print()

        End If
    End Sub
End Class