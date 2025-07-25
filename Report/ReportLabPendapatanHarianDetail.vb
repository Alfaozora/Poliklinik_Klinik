Public Class ReportLabPendapatanHarianDetail

    Dim Tbls As New DataTable

    Public Sub SetClear()
        If txketerangan.Text = "Pembayaran" Then
            Me.Text = "Report Penerimaan berdasar Pendapatan"
        ElseIf txketerangan.Text = "Tindakan" Then
            Me.Text = "Report Penerimaan berdasar Tindakan"
        End If
    End Sub

    Function Checking() As Boolean
        If Format(dtawal.Value, "MM-dd-yyyy") > Format(dtakhir.Value, "MM-dd-yyyy") Then
            MsgBox("Tanggal akhir lebih kecil dari tanggal awal. Set kembali.")
            Return False
        End If

        Return True
    End Function

    Private Sub MasterPendapatan()
        Tbls = ReadSQL("select '              ' as Jenis,b.TransLabID as ID,b.NoUrut,CONVERT(varchar,b.TglLab,106) as Tgl,b.idinternet,c.Nama,b.TotalTagihan as GrossBayar,b.TotalDisc as Disc,b.NettBayar,b.TotalBayar,b.Pengembalian," & _
                       " a.TransLabIDBayar as IDDetail,a.JenisBayar, a.mesin, a.kartu, a.NoJenisBayar, a.JumlahBayar, a.admin, a.transaksitime from transaksilabbayar a " & _
                       " left join TransaksiLab  b on a.TransLabID=b.TransLabID left join MasterPasien c on c.NoRekamMedis=b.IDInternet where a.TransLabID='-1' order by a.transaksitime,a.TransLabID,a.JenisBayar ")
    End Sub


    Private Sub AddAdminPendapatan(ByRef Tbls As DataTable)
        Dim Ttemp As DataTable = ReadSQL("select 'Administrasi' as Jenis,b.TransAdminID as ID,'ADMIN ' as NoUrut,CONVERT(varchar,b.TindakanTgl ,106) as Tgl,b.idinternet,c.Nama,b.TotalTagihan as GrossBayar,b.TotalDisc as Disc,b.NettBayar,b.TotalBayar,b.Pengembalian,a.TransAdminIDBayar as IDDetail,a.JenisBayar,a.mesin,a.kartu,a.NoJenisBayar,(a.JumlahBayar-a.Kembali) as TtlBayar,a.admin,a.transaksitime " & _
                                         " from transaksiadminbayar a left join TransaksiAdmin  b on a.TransAdminID=b.TransAdminID left join MasterPasien c on c.NoRekamMedis=b.IDInternet " & _
                                         " where b.deleted<>1 and b.TindakanTgl between '" & Format(dtawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtakhir.Value, "MM/dd/yyyy 23:59:59") & "' ")

        For Each Trow As DataRow In Ttemp.Rows
            Dim Tnew As DataRow = Tbls.NewRow
            For i As Integer = 0 To Tbls.Columns.Count - 1
                Tnew(i) = Trow(i)
            Next
            Tbls.Rows.Add(Tnew)
        Next

    End Sub

    Private Sub AddPoliPendapatan(ByRef Tbls As DataTable)
        Dim Ttemp As DataTable = ReadSQL("select 'PoliKlinik' as Jenis,b.TransPoliID as ID,b.NoUrut,CONVERT(varchar,b.TglPoli ,106) as Tgl,b.idinternet,c.Nama,b.TotalTagihan as GrossBayar,b.TotalDisc as Disc,b.NettBayar,b.TotalBayar,b.Pengembalian,a.TransPoliIDBayar as IDDetail,a.JenisBayar,a.mesin,a.kartu,a.NoJenisBayar,(a.JumlahBayar-a.Kembali) as TtlBayar,a.admin,a.transaksitime " & _
                                         " from TransaksiPoliBayar a left join TransaksiPoli  b on a.TransPoliID=b.TransPoliID left join MasterPasien c on c.NoRekamMedis=b.IDInternet " & _
                                         " where b.deleted<>1 and CONVERT(date, b.TglPoli) between '" & Format(dtawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtakhir.Value, "MM/dd/yyyy 23:59:59") & "' ")

        For Each Trow As DataRow In Ttemp.Rows
            Dim Tnew As DataRow = Tbls.NewRow
            For i As Integer = 0 To Tbls.Columns.Count - 1
                Tnew(i) = Trow(i)
            Next
            Tbls.Rows.Add(Tnew)
        Next

        Dim Ttemp2 As DataTable = ReadSQL("select 'PoliKlinik' as Jenis,b.TransPoliID as ID,b.NoUrut,CONVERT(varchar,b.TglPoli ,106) as Tgl,b.idinternet,c.Nama,b.TotalTagihan as GrossBayar,b.TotalDisc as Disc,b.NettBayar,b.TotalBayar,b.Pengembalian,a.TransPoliIDBayar as IDDetail,a.JenisBayar,a.mesin,a.kartu,a.NoJenisBayar,(a.JumlahBayar-a.Kembali) as TtlBayar,a.admin,a.transaksitime " & _
                                         " from TransaksiPoliBayarAwal a left join TransaksiPoli  b on a.TransPoliID=b.TransPoliID left join MasterPasien c on c.NoRekamMedis=b.IDInternet " & _
                                         " where a.TransJenis='POLI' and  CONVERT(date, b.TglPoli) between '" & Format(dtawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtakhir.Value, "MM/dd/yyyy 23:59:59") & "' ")

        For Each Trow As DataRow In Ttemp2.Rows
            Dim Tnew As DataRow = Tbls.NewRow
            For i As Integer = 0 To Tbls.Columns.Count - 1
                Tnew(i) = Trow(i)
            Next
            Tbls.Rows.Add(Tnew)
        Next

    End Sub

    Private Sub AddLabPendapatan(ByRef Tbls As DataTable)
        Dim Ttemp As DataTable = ReadSQL("select 'Laboratorium' as Jenis,b.TransLabID as ID,b.NoUrut,CONVERT(varchar,b.TglLab,106) as Tgl,b.idinternet,c.Nama,b.TotalTagihan as GrossBayar,b.TotalDisc as Disc,b.NettBayar,b.TotalBayar,b.Pengembalian,a.TransLabIDBayar as IDDetail,a.JenisBayar,a.mesin,a.kartu,a.NoJenisBayar,(a.JumlahBayar-a.Kembali) as TtlBayar,a.admin,a.transaksitime " & _
                                        " from TransaksiLabBayar a left join TransaksiLab  b on a.TransLabID=b.TransLabID left join MasterPasien c on c.NoRekamMedis=b.IDInternet " & _
                                        " where b.deleted<>1 and CONVERT(date, b.TglLab) between '" & Format(dtawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtakhir.Value, "MM/dd/yyyy 23:59:59") & "' ")

        For Each Trow As DataRow In Ttemp.Rows
            Dim Tnew As DataRow = Tbls.NewRow
            Dim key As Integer = 0

            Dim LabSamplingTime As String = ReadSQLNIK("select LabSamplingTime from TransaksiLab where TransLabID=" & Trow("ID") & "")
            Dim UploadMesin As Boolean = ReadSQLNIK("select case when UploadMesin=1 then '1' else '0' end from TransaksiLab where TransLabID=" & Trow("ID") & "")
            Dim SendKeu As Boolean = ReadSQLNIK("select case when SendKeu=1 then '1' else '0' end from TransaksiLab where TransLabID=" & Trow("ID") & "")
            Dim Nourut As String = ReadSQLNIK("select Nourut from TransaksiLab where TransLabID=" & Trow("ID") & "")
            If IsDBNull(LabSamplingTime) = False And UploadMesin = True And SendKeu = False Then
                'SKIP
            Else
                For i As Integer = 0 To Tbls.Columns.Count - 1
                    'If IsDBNull(samplingtime) = True And Trow("Nourut").ToString.Contains("M") = True Then
                    '    'Jika LabSamplingTime = NULL maka data tidak ditampilkan
                    '    key = 1
                    'Else
                    Tnew(i) = Trow(i)
                    key = 0
                    'End If
                Next
                If key = 1 Then
                    'Jika LabSamplingTime = NULL maka data tidak ditampilkan
                Else
                    Tbls.Rows.Add(Tnew)
                End If
            End If
        Next
        'GridView1.Columns("LabSamplingTime").Visible = False
    End Sub

    Private Sub AddGigiPendapatan(ByRef Tbls As DataTable)
        Dim Ttemp As DataTable = ReadSQL("select 'Gigi' as Jenis,b.TransGigiID as ID,b.NoUrut,CONVERT(varchar,b.TglGigi ,106) as Tgl,b.idinternet,c.Nama,b.TotalTagihan as GrossBayar,b.TotalDisc as Disc,b.NettBayar,b.TotalBayar,b.Pengembalian,a.TransGigiIDBayar as IDDetail,a.JenisBayar,a.mesin,a.kartu,a.NoJenisBayar,(a.JumlahBayar-a.Kembali) as TtlBayar,a.admin,a.transaksitime " & _
                                         " from TransaksiGigiBayar a left join TransaksiGigi b on a.TransGigiID=b.TransGigiID left join MasterPasien c on c.NoRekamMedis=b.IDInternet " & _
                                         " where b.deleted<>1 and CONVERT(date, b.TglGigi) between '" & Format(dtawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtakhir.Value, "MM/dd/yyyy 23:59:59") & "' ")

        For Each Trow As DataRow In Ttemp.Rows
            Dim Tnew As DataRow = Tbls.NewRow
            For i As Integer = 0 To Tbls.Columns.Count - 1
                Tnew(i) = Trow(i)
            Next
            Tbls.Rows.Add(Tnew)
        Next

        Dim Ttemp2 As DataTable = ReadSQL("select 'Gigi' as Jenis,b.TransPoliID as ID,b.NoUrut,CONVERT(varchar,b.TglPoli ,106) as Tgl,b.idinternet,c.Nama,b.TotalTagihan as GrossBayar,b.TotalDisc as Disc,b.NettBayar,b.TotalBayar,b.Pengembalian,a.TransPoliIDBayar as IDDetail,a.JenisBayar,a.mesin,a.kartu,a.NoJenisBayar,(a.JumlahBayar-a.Kembali) as TtlBayar,a.admin,a.transaksitime " & _
                                         " from TransaksiPoliBayarAwal a left join TransaksiPoli  b on a.TransPoliID=b.TransPoliID left join MasterPasien c on c.NoRekamMedis=b.IDInternet " & _
                                         " where a.TransJenis='GIGI' and  CONVERT(date, b.TglPoli) between '" & Format(dtawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtakhir.Value, "MM/dd/yyyy 23:59:59") & "' ")

        For Each Trow As DataRow In Ttemp2.Rows
            Dim Tnew As DataRow = Tbls.NewRow
            For i As Integer = 0 To Tbls.Columns.Count - 1
                Tnew(i) = Trow(i)
            Next
            Tbls.Rows.Add(Tnew)
        Next

    End Sub

    Private Sub butdisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butdisplay.Click
        If Checking() = True Then

            If txketerangan.Text = "Pembayaran" Then
                MasterPendapatan()

                If chkadmin.CheckState = CheckState.Checked Then AddAdminPendapatan(Tbls)
                If chkpoli.CheckState = CheckState.Checked Then AddPoliPendapatan(Tbls)
                If chklab.CheckState = CheckState.Checked Then AddLabPendapatan(Tbls)
                If chkgigi.CheckState = CheckState.Checked Then AddGigiPendapatan(Tbls)

                insertRowToTbls(Tbls, "tyinterger", "dd")
                insertRowToTbls(Tbls, "tyinterger", "mm")
                insertRowToTbls(Tbls, "tyinterger", "yyyy")

                For Each Trow As DataRow In Tbls.Rows
                    Trow("dd") = Format(Trow("transaksitime"), "dd")
                    Trow("mm") = Format(Trow("transaksitime"), "MM")
                    Trow("yyyy") = Format(Trow("transaksitime"), "yyyy")
                Next

                Report = New XtraReport
                Report = XtraReport.FromFile(Application.StartupPath + "\reports\LapPenerimaanDetail.repx", True)
                Report.DataSource = Tbls
                Report.Bands.Item(BandKind.ReportHeader).Controls("lbltanggal").Text = Format(dtawal.Value, "dd-MMM-yyyy HH:mm") & " - " & Format(dtakhir.Value, "dd-MMM-yyyy HH:mm")
                Report.Bands.Item(BandKind.ReportHeader).Controls("lbladmin").Text = PoliKlinik.Lbluser.Text
                Report.Bands.Item(BandKind.ReportFooter).Controls("lbltanggalacc").Text = ".............. ," & Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:sss")
                'Report.RunDesigner()
                Report.ShowPreview()
                'Report.Print()

            ElseIf txketerangan.Text = "Tindakan" Then
                MasterTindakan()

                If chkadmin.CheckState = CheckState.Checked Then AddAdminTindakan(Tbls)
                If chkpoli.CheckState = CheckState.Checked Then AddPoliTindakan(Tbls)
                If chklab.CheckState = CheckState.Checked Then AddLabTindakan(Tbls)
                If chkgigi.CheckState = CheckState.Checked Then AddGigiTindakan(Tbls)

                insertRowToTbls(Tbls, "tyinterger", "dd")
                insertRowToTbls(Tbls, "tyinterger", "mm")
                insertRowToTbls(Tbls, "tyinterger", "yyyy")

                For Each Trow As DataRow In Tbls.Rows
                    Trow("dd") = Format(Trow("transaksitime"), "dd")
                    Trow("mm") = Format(Trow("transaksitime"), "MM")
                    Trow("yyyy") = Format(Trow("transaksitime"), "yyyy")
                Next

                Report = New XtraReport
                Report = XtraReport.FromFile(Application.StartupPath + "\reports\LapPenerimaanDetailperTindakan.repx", True)
                Report.DataSource = Tbls
                Report.Bands.Item(BandKind.ReportHeader).Controls("lbltanggal").Text = Format(dtawal.Value, "dd-MMM-yyyy HH:mm") & " - " & Format(dtakhir.Value, "dd-MMM-yyyy HH:mm")
                Report.Bands.Item(BandKind.ReportHeader).Controls("lbladmin").Text = PoliKlinik.Lbluser.Text
                Report.Bands.Item(BandKind.ReportFooter).Controls("lbltanggalacc").Text = ".............. ," & Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:sss")
                'Report.RunDesigner()
                Report.ShowPreview()
                'Report.Print()
            End If
            GridControl1.DataSource = Tbls
        End If
    End Sub

    Private Sub MasterTindakan()
        Tbls = ReadSQL("select '              ' as Jenis,a.TransPoliID as ID,a.NoUrut,CONVERT(varchar,a.TglPoli,106) as Tgl,a.idinternet,c.Nama,b.NamaTindakan,b.BiayaTindakan as Biaya,b.DiscPersenTindakan as Disc,b.NettBayar as NettBayar,b.admin,b.transaksitime " & _
                       " from TransaksiPoli a left join TransaksiPoliDetail b on a.TransPoliID=b.TransPoliID left join MasterPasien c on c.NoRekamMedis=a.IDInternet where a.TransPoliID='-1' AND b.DeletedDate IS NULL")

    End Sub

    Private Sub AddAdminTindakan(ByRef Tbls As DataTable)
        Dim Ttemp As DataTable = ReadSQL("select 'Administrasi' as Jenis,a.TransAdminID  as ID,'ADMIN' as NoUrut,CONVERT(varchar,a.TindakanTgl ,106) as Tgl,a.idinternet,c.Nama,b.NamaTindakan ,b.BiayaTindakan  as Biaya,b.DiscPersenTindakan as Disc,b.NettBayar as NettBayar,b.admin,b.transaksitime " & _
                                         " from TransaksiAdmin a left join TransaksiAdminDetail  b on a.TransAdminID =b.TransAdminID left join MasterPasien c on c.NoRekamMedis=a.IDInternet where a.deleted<>1 and b.transaksitime is not null and a.TindakanTgl  between '" & Format(dtawal.Value, "MM/dd/yyyy") & "' and '" & Format(dtakhir.Value, "MM/dd/yyyy") & "'")

        For Each Trow As DataRow In Ttemp.Rows
            Dim Tnew As DataRow = Tbls.NewRow
            For i As Integer = 0 To Tbls.Columns.Count - 1
                Tnew(i) = Trow(i)
            Next
            Tbls.Rows.Add(Tnew)
        Next
    End Sub

    Private Sub AddPoliTindakan(ByRef Tbls As DataTable)
        Dim Ttemp As DataTable = ReadSQL("select 'Poli' as Jenis,a.TransPoliID as ID,a.NoUrut,CONVERT(varchar,a.TglPoli,106) as Tgl,a.idinternet,c.Nama,b.NamaTindakan,b.BiayaTindakan as Biaya,b.DiscPersenTindakan as Disc,b.NettBayar as NettBayar,b.admin,b.transaksitime " & _
                                         " from TransaksiPoli a left join TransaksiPoliDetail b on a.TransPoliID=b.TransPoliID left join MasterPasien c on c.NoRekamMedis=a.IDInternet where b.DeletedDate IS NULL AND b.transaksitime is not null and CONVERT(date, a.TglPoli) between '" & Format(dtawal.Value, "MM/dd/yyyy") & "' and '" & Format(dtakhir.Value, "MM/dd/yyyy") & "'")

        For Each Trow As DataRow In Ttemp.Rows
            Dim Tnew As DataRow = Tbls.NewRow
            For i As Integer = 0 To Tbls.Columns.Count - 1
                Tnew(i) = Trow(i)
            Next
            Tbls.Rows.Add(Tnew)
        Next
    End Sub

    Private Sub AddLabTindakan(ByRef Tbls As DataTable)
        Dim Ttemp As DataTable = ReadSQL("select 'Laboratorium' as Jenis,a.TransLabID  as ID,a.NoUrut,CONVERT(varchar,a.TglLab,106) as Tgl,a.idinternet,c.Nama,b.NamaTindakan,b.BiayaTindakan as Biaya,b.DiscPersenTindakan as Disc,b.NettBayar as NettBayar,b.admin,b.transaksitime " & _
                                         " from TransaksiLab a left join TransaksiLabDetail b on a.TransLabID =b.TransLabID left join MasterPasien c on c.NoRekamMedis=a.IDInternet where a.deleted<>1 and b.transaksitime is not null and a.TglLab  between '" & Format(dtawal.Value, "MM/dd/yyyy") & "' and '" & Format(dtakhir.Value, "MM/dd/yyyy") & "'")

        For Each Trow As DataRow In Ttemp.Rows
            Dim key As Integer = 0
            Dim samplingtime As String = ReadSQLNIK("select LabSamplingTime from TransaksiLab where TransLabID=" & Trow("ID") & "")
            Dim Tnew As DataRow = Tbls.NewRow
            For i As Integer = 0 To Tbls.Columns.Count - 1
                If samplingtime = "" And Trow("Nourut").ToString.Contains("M") = True Then
                    'Data tidak ditampilkan
                    key = 1
                Else
                    Tnew(i) = Trow(i)
                    key = 0
                End If
            Next
            If key = 1 Then
                'Data tidak di input
            Else
                Tbls.Rows.Add(Tnew)
            End If
        Next
    End Sub

    Private Sub AddGigiTindakan(ByRef Tbls As DataTable)
        Dim Ttemp As DataTable = ReadSQL("select 'Gigi' as Jenis,a.TransGigiID  as ID,a.NoUrut,CONVERT(varchar,a.TglGigi,106) as Tgl,a.idinternet,c.Nama,b.NamaTindakan,b.BiayaTindakan as Biaya,b.DiscPersenTindakan as Disc,b.NettBayar as NettBayar,b.admin,b.transaksitime " & _
                                         " from TransaksiGigi a left join TransaksiGigiDetail b on a.TransGigiID =b.TransGigiID left join MasterPasien c on c.NoRekamMedis=a.IDInternet where b.transaksitime is not null and CONVERT(date, a.TglGigi) between '" & Format(dtawal.Value, "MM/dd/yyyy") & "' and '" & Format(dtakhir.Value, "MM/dd/yyyy") & "'")

        For Each Trow As DataRow In Ttemp.Rows
            Dim Tnew As DataRow = Tbls.NewRow
            For i As Integer = 0 To Tbls.Columns.Count - 1
                Tnew(i) = Trow(i)
            Next
            Tbls.Rows.Add(Tnew)
        Next
    End Sub



    Private Sub ReportLabPendapatanHarianDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        SetClear()
    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Tbls As DataTable = GridControl1.DataSource
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
                    GridControl1.ExportToExcel(saveFileDialog1.FileName.ToString)
                    MsgBox("File Saved")
                End If
            End If
        End If
    End Sub
End Class