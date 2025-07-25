Public Class ReportPenerimaan

    Private Sub SetAwal()
        rdpasienall.Checked = True
        rdtransall.Checked = True
        rdtanggal.Checked = True
        dtawal.Value = DateAndTime.Now
        dtakhir.Value = DateAndTime.Now

        dtawal.Enabled = True
        dtakhir.Enabled = True
    End Sub

    Private Sub ReportPenerimaan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        'InitializeComponent()
        SetAwal()
    End Sub

    Private Sub butdisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butdisplay.Click
        Dim Qpasien, Qtgl, Qorder, QTgllab As String
        Dim Qawal As DataTable = ReadSQL("select '      ' as Jenis,a.IDInternet,b.TransPoliID as ID,b.TindakanID,b.NamaTindakan,a.TglPoli as TglTindakan,b.BiayaTindakan,b.DiscTindakan,b.NettBayar,f.IDInternet,f.noid,f.nomitra,f.NoKartu,f.Nama,f.Alamat,f.Sex,f.Alergi,f.Keterangan,f.StatusMarital,f.Statuskesehatan,f.email from TransaksiPoli a left join TransaksiPoliDetail b on a.TransPoliID=b.TransPoliID left join MasterCustomer f on f.IDInternet=a.IDInternet where b.TransPoliID='' AND b.DeletedDate IS NULL")


        Qtgl = " where CONVERT(date, a.TglPoli) between '" & Format(dtawal.Value, "MM/dd/yyyy") & "' and '" & Format(dtakhir.Value, "MM/dd/yyyy") & "' "
        QTgllab = " where CONVERT(date, a.Tgllab) between '" & Format(dtawal.Value, "MM/dd/yyyy") & "' and '" & Format(dtakhir.Value, "MM/dd/yyyy") & "' "
        Qorder = " order by a.TglPoli,a.TglTindakan "


        'rasanya harus set masing-masing jenis tindakan. baru nanti digabung bila memang mau digabung
        Dim Qtindakan As String = "select 'Poli' as Jenis,a.IDInternet,b.TransPoliID as ID,b.TindakanID,b.NamaTindakan,a.TglPoli as TglTindakan,b.BiayaTindakan,b.DiscTindakan,b.NettBayar,f.IDInternet,f.noid,f.nomitra,f.NoKartu,f.Nama,f.Alamat,f.Sex,f.Alergi,f.Keterangan,f.StatusMarital,f.Statuskesehatan,f.email from TransaksiPoli a left join TransaksiPoliDetail b on a.TransPoliID=b.TransPoliID left join MasterCustomer f on f.IDInternet=a.IDInternet "

        Dim Qlab As String = "select 'Lab' as Jenis,a.IDInternet,b.TransLabID as ID,b.TindakanID,b.NamaTindakan,a.TglLab as TglTindakan,b.BiayaTindakan,b.DiscTindakan,b.NettBayar,f.IDInternet,f.noid,f.nomitra,f.NoKartu,f.Nama,f.Alamat,f.Sex,f.Alergi,f.Keterangan,f.StatusMarital,f.Statuskesehatan,f.email from TransaksiLab a left join TransaksiLabDetail b on a.TransLabID=b.TransLabID left join MasterCustomer f on f.IDInternet=a.IDInternet "

        Dim Tobat As String = ""

        Dim QUGD As String = ""

        Qpasien = " "
        If rdpasienall.Checked = True Then
            Qpasien = "  "
        ElseIf rdpasienumum.Checked = True Then
            Qpasien = " and f.StatusKesehatan in ('UMUM') "
        ElseIf rdpasienpoliini.Checked = True Then
            Qpasien = "  and f.StatusKesehatan in ('BPJS') "
        ElseIf rdpasienpolilain.Checked = True Then
            Qpasien = " and f.StatusKesehatan in ('CMH') "
        ElseIf rdpasienf1b.Checked = True Then
            'belum ada....
            'Qpasien = " and StatusKesehatan in ('') "
        End If

        If rdtransall.Checked = True Then
            Qtindakan = Qtindakan & Qtgl & Qpasien
            Dim Ttindakan As DataTable = ReadSQL(Qtindakan)
            For Each Trow As DataRow In Ttindakan.Rows
                Dim Tnew As DataRow = Qawal.NewRow
                For j As Integer = 0 To Qawal.Columns.Count - 1
                    Tnew(j) = Trow(j)
                Next
                Qawal.Rows.Add(Tnew)
            Next

            Qlab = Qlab & QTgllab & Qpasien
            Dim Tlab As DataTable = ReadSQL(Qlab)
            For Each Trow As DataRow In Tlab.Rows
                Dim Tnew As DataRow = Qawal.NewRow
                For j As Integer = 0 To Qawal.Columns.Count - 1
                    Tnew(j) = Trow(j)
                Next
                Qawal.Rows.Add(Tnew)
            Next

        ElseIf rdtransdaftar.Checked = True Then
            Qtindakan = Qtindakan & Qtgl & " and (b.NamaTindakan like '%Konsultasi%' or b.NamaTindakan like '%Pemeriksaan%') " & Qpasien
            Dim Ttindakan As DataTable = ReadSQL(Qtindakan)
            For Each Trow As DataRow In Ttindakan.Rows
                Dim Tnew As DataRow = Qawal.NewRow
                For j As Integer = 0 To Qawal.Columns.Count - 1
                    Tnew(j) = Trow(j)
                Next
                Qawal.Rows.Add(Tnew)
            Next

        ElseIf rdtranstindakan.Checked = True Then
            Qtindakan = Qtindakan & Qtgl & " and (b.NamaTindakan not like '%Konsultasi%' or b.NamaTindakan not like '%Pemeriksaan%') " & Qpasien
            Dim Ttindakan As DataTable = ReadSQL(Qtindakan)
            For Each Trow As DataRow In Ttindakan.Rows
                Dim Tnew As DataRow = Qawal.NewRow
                For j As Integer = 0 To Qawal.Columns.Count - 1
                    Tnew(j) = Trow(j)
                Next
                Qawal.Rows.Add(Tnew)
            Next

        ElseIf rdtranslab.Checked = True Then
            Qlab = Qlab & QTgllab & Qpasien
            Dim Tlab As DataTable = ReadSQL(Qlab)
            For Each Trow As DataRow In Tlab.Rows
                Dim Tnew As DataRow = Qawal.NewRow
                For j As Integer = 0 To Qawal.Columns.Count - 1
                    Tnew(j) = Trow(j)
                Next
                Qawal.Rows.Add(Tnew)
            Next

        ElseIf rdtransugd.Checked = True Then
            'Qtrans = "  "
        End If


        Report = New XtraReport
        Report = XtraReport.FromFile(Application.StartupPath + "\reports\LapPenerimaan.repx", True)
        Report.Bands.Item(BandKind.ReportHeader).Controls("lbltanggal").Text = Format(dtawal.Value, "dd-MMM-yyyy") & " s/d " & Format(dtakhir.Value, "dd-MMM-yyyy")
        Report.DataSource = Qawal
        'Report.RunDesigner()
        Report.ShowPreview()
        'Report.Print()


    End Sub
End Class