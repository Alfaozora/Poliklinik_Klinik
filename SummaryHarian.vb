Public Class SummaryHarian

    Private THasil As New DataTable

    Private Sub SetClear()
        dtkasirawal.Value = Format(DateAndTime.Now, "dd-MMM-yyyy 00:00:00")
        dtkasirakhir.Value = Format(DateAndTime.Now, "dd-MMM-yyyy 23:59:59")
    End Sub

    Private Sub butdisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butdisplay.Click
        If CheckBox1.Checked = False Then

            'Dim Tbls, Tbls1, Tbls2, Tbls3, Tbls4 As New DataTable
            'Dim Tminus1, Tminus2, Tminus3 As New DataTable

            'insertRowToTbls(Tbls, "", "Jenis")
            'insertRowToTbls(Tbls, "", "TUNAI")
            'insertRowToTbls(Tbls, "", "CARD")
            'insertRowToTbls(Tbls, "", "DEBET")
            'insertRowToTbls(Tbls, "", "Total")


            'Tbls1 = ReadSQL(" select 'AWAL' as Jenis,JenisBayar,SUM(JumlahBayar)-sum(Kembali) AS  Nilai from TransaksiPoliBayarAwal where transaksitime between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "' and TransPoliID  not in ( select TransPoliID  from TransaksiPoli where Deleted<>1)  group by JenisBayar ")
            'Tbls2 = ReadSQL(" select 'POLI' as Jenis,JenisBayar,SUM(JumlahBayar)-sum(Kembali) AS  Nilai from TransaksiPoliBayar where transaksitime between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "'  and TransPoliID  not in ( select TransPoliID  from TransaksiPoli where Deleted<>1)  group by JenisBayar ")
            'Tbls3 = ReadSQL(" select 'GIGI' as Jenis,JenisBayar,SUM(JumlahBayar)-sum(Kembali) AS  Nilai from TransaksiGigiBayar where transaksitime between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "'  and TransGigiID  not in ( select TransGigiID  from TransaksiGigi where Deleted<>1)  group by JenisBayar ")
            'Tbls4 = ReadSQL(" select 'LAB' as Jenis,JenisBayar,SUM(JumlahBayar)-sum(Kembali) AS  Nilai from TransaksiLabBayar where transaksitime between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "'  and TransLabID  not in ( select  TransLabID from TransaksiLab where Deleted<>1)  group by JenisBayar ")


            'Dim Tnew As DataRow = Tbls.NewRow
            'Tnew("Jenis") = "AWAL"
            'For Each Trow As DataRow In Tbls1.Rows
            '    If Trow("JenisBayar").ToString = "TUNAI" Then
            '        Tnew("TUNAI") = Splitmoney(Trow("Nilai"))
            '    End If
            '    If Trow("JenisBayar").ToString = "DEBET" Then
            '        Tnew("DEBET") = Splitmoney(Trow("Nilai"))
            '    End If
            '    If Trow("JenisBayar").ToString = "CARD" Then
            '        Tnew("CARD") = Splitmoney(Trow("Nilai"))
            '    End If
            'Next

            'If IsDBNull(Tnew("CARD")) = True Then Tnew("CARD") = 0
            'If IsDBNull(Tnew("DEBET")) = True Then Tnew("DEBET") = 0
            'If IsDBNull(Tnew("TUNAI")) = True Then Tnew("TUNAI") = 0
            'Tnew("Total") = Splitmoney(CDbl(Tnew("CARD")) + CDbl(Tnew("DEBET")) + CDbl(Tnew("TUNAI")))
            'Tbls.Rows.Add(Tnew)

            'Tnew = Tbls.NewRow
            'Tnew("Jenis") = "POLI"
            'For Each Trow As DataRow In Tbls2.Rows
            '    If Trow("JenisBayar").ToString = "TUNAI" Then
            '        Tnew("TUNAI") = Splitmoney(Trow("Nilai"))
            '    End If
            '    If Trow("JenisBayar").ToString = "DEBET" Then
            '        Tnew("DEBET") = Splitmoney(Trow("Nilai"))
            '    End If
            '    If Trow("JenisBayar").ToString = "CARD" Then
            '        Tnew("CARD") = Splitmoney(Trow("Nilai"))
            '    End If
            'Next

            'If IsDBNull(Tnew("CARD")) = True Then Tnew("CARD") = 0
            'If IsDBNull(Tnew("DEBET")) = True Then Tnew("DEBET") = 0
            'If IsDBNull(Tnew("TUNAI")) = True Then Tnew("TUNAI") = 0
            'Tnew("Total") = Splitmoney(CDbl(Tnew("CARD")) + CDbl(Tnew("DEBET")) + CDbl(Tnew("TUNAI")))
            'Tbls.Rows.Add(Tnew)

            'Tnew = Tbls.NewRow
            'Tnew("Jenis") = "GIGI"
            'For Each Trow As DataRow In Tbls3.Rows
            '    If Trow("JenisBayar").ToString = "TUNAI" Then
            '        Tnew("TUNAI") = Splitmoney(Trow("Nilai"))
            '    End If
            '    If Trow("JenisBayar").ToString = "DEBET" Then
            '        Tnew("DEBET") = Splitmoney(Trow("Nilai"))
            '    End If
            '    If Trow("JenisBayar").ToString = "CARD" Then
            '        Tnew("CARD") = Splitmoney(Trow("Nilai"))
            '    End If
            'Next

            'If IsDBNull(Tnew("CARD")) = True Then Tnew("CARD") = 0
            'If IsDBNull(Tnew("DEBET")) = True Then Tnew("DEBET") = 0
            'If IsDBNull(Tnew("TUNAI")) = True Then Tnew("TUNAI") = 0
            'Tnew("Total") = Splitmoney(CDbl(Tnew("CARD")) + CDbl(Tnew("DEBET")) + CDbl(Tnew("TUNAI")))
            'Tbls.Rows.Add(Tnew)

            'Tnew = Tbls.NewRow
            'Tnew("Jenis") = "LAB"
            'For Each Trow As DataRow In Tbls4.Rows
            '    If Trow("JenisBayar").ToString = "TUNAI" Then
            '        Tnew("TUNAI") = Splitmoney(Trow("Nilai"))
            '    End If
            '    If Trow("JenisBayar").ToString = "DEBET" Then
            '        Tnew("DEBET") = Splitmoney(Trow("Nilai"))
            '    End If
            '    If Trow("JenisBayar").ToString = "CARD" Then
            '        Tnew("CARD") = Splitmoney(Trow("Nilai"))
            '    End If
            'Next

            'If IsDBNull(Tnew("CARD")) = True Then Tnew("CARD") = 0
            'If IsDBNull(Tnew("DEBET")) = True Then Tnew("DEBET") = 0
            'If IsDBNull(Tnew("TUNAI")) = True Then Tnew("TUNAI") = 0
            'Tnew("Total") = Splitmoney(CDbl(Tnew("CARD")) + CDbl(Tnew("DEBET")) + CDbl(Tnew("TUNAI")))
            'Tbls.Rows.Add(Tnew)

            Report = New XtraReport
            Report = XtraReport.FromFile(Application.StartupPath + "\reports\LapSummaryHarian.repx", True)
            Report.DataSource = THasil
            Report.Bands.Item(BandKind.ReportHeader).Controls("lbltanggal").Text = Format(dtkasirawal.Value, "dd-MMM-yyyy HH:mm") & " - " & Format(dtkasirakhir.Value, "dd-MMM-yyyy HH:mm")
            Report.Bands.Item(BandKind.ReportHeader).Controls("lblperiode").Text = " PERIODE TANGGAL : " & Format(DateAndTime.Now, "dd-MMM-yyyy")
            Report.Bands.Item(BandKind.ReportHeader).Controls("lbladmin").Text = PoliKlinik.Lbluser.Text
            Report.Bands.Item(BandKind.ReportFooter).Controls("lbltanggalacc").Text = ".............. ," & Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:sss")
            'Report.RunDesigner()
            Report.ShowPreview()
            'Report.Print()

        Else

            Dim Tbls0 As DataTable = ReadSQL(" select a.TransAdminID,a.Nourut,b.admin,b.NoJenisBayar,case when b.JenisBayar='TUNAI' then b.JumlahBayar-b.Kembali else 0 end as Ttunai , case when b.JenisBayar='CARD' then b.JumlahBayar else 0 end as TCard ,case when b.JenisBayar='DEBET' then b.JumlahBayar else 0 end as TDebet from TransaksiAdmin  a " & _
                                             " left join TransaksiAdminBayar b on a.TransAdminID=b.TransAdminID where a.TindakanTgl between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "' order by a.TransAdminID ")

            Dim Tbls1 As DataTable = ReadSQL(" select A.TransPoliID,a.NoUrut,b.admin,b.NoJenisBayar,case when b.JenisBayar='TUNAI' then b.JumlahBayar-b.Kembali else 0 end as Ttunai, case when b.JenisBayar='CARD' then b.JumlahBayar else 0 end as TCard ,case when b.JenisBayar='DEBET' then b.JumlahBayar else 0 end as TDebet from transaksipoli a left join (select 'Awal' as Jenis, TransPoliID,JenisBayar,NoJenisBayar,JumlahBayar,admin,transaksitime from TransaksiPoliBayarAwal union all " & _
                                             " select 'Trans' as Jenis, TransPoliID,JenisBayar,NoJenisBayar,JumlahBayar,admin,transaksitime from TransaksiPoliBayar) b  on a.TransPoliID=b.TransPoliID " & _
                                             " where CONVERT(date, a.TglPoli) between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "' order by a.TransPoliID,b.Jenis")

            Dim Tbls2 As DataTable = ReadSQL(" select  a.TransGigiID,a.Nourut,b.admin,b.NoJenisBayar,case when b.JenisBayar='TUNAI' then b.JumlahBayar-b.Kembali else 0 end as Ttunai , case when b.JenisBayar='CARD' then b.JumlahBayar else 0 end as TCard ,case when b.JenisBayar='DEBET' then b.JumlahBayar else 0 end as TDebet from TransaksiGigi a " & _
                                             "  left join TransaksiGigiBayar b on a.TransGigiID=b.TransGigiID where CONVERT(date, a.TglGigi) between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "' order by a.TransGigiID ")


            Dim Tbls3 As DataTable = ReadSQL(" select a.TransLabID,a.Nourut,b.admin,b.NoJenisBayar,case when b.JenisBayar='TUNAI' then b.JumlahBayar-b.Kembali else 0 end as Ttunai , case when b.JenisBayar='CARD' then b.JumlahBayar else 0 end as TCard ,case when b.JenisBayar='DEBET' then b.JumlahBayar else 0 end as TDebet from TransaksiLab a " & _
                                             " left join TransaksiLabBayar b on a.TransLabID=b.TransLabID  where CONVERT(date, a.TglLab) between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "' order by a.TransLabID ")

            For Each Trow As DataRow In Tbls0.Rows
                Dim Tnew As DataRow = Tbls1.NewRow
                For i As Integer = 0 To Tbls1.Columns.Count - 1
                    Tnew(i) = Trow(i)
                Next
                Tbls1.Rows.Add(Tnew)
            Next

            For Each Trow As DataRow In Tbls2.Rows
                Dim Tnew As DataRow = Tbls1.NewRow
                For i As Integer = 0 To Tbls1.Columns.Count - 1
                    Tnew(i) = Trow(i)
                Next
                Tbls1.Rows.Add(Tnew)
            Next

            For Each Trow As DataRow In Tbls3.Rows
                Dim Tnew As DataRow = Tbls1.NewRow
                For i As Integer = 0 To Tbls1.Columns.Count - 1
                    Tnew(i) = Trow(i)
                Next
                Tbls1.Rows.Add(Tnew)
            Next

            Report = New XtraReport
            Report = XtraReport.FromFile(Application.StartupPath + "\reports\LapPenerimaanUang.repx", True)
            Report.DataSource = Tbls1
            GridControl1.DataSource = Tbls1
            Report.Bands.Item(BandKind.ReportHeader).Controls("lbltanggal").Text = Format(dtkasirawal.Value, "dd-MMM-yyyy HH:mm") & " - " & Format(dtkasirakhir.Value, "dd-MMM-yyyy HH:mm")
            Report.Bands.Item(BandKind.ReportHeader).Controls("lbladmin").Text = PoliKlinik.Lbluser.Text
            Report.Bands.Item(BandKind.ReportFooter).Controls("lbltanggalacc").Text = ".............. ," & Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:sss")
            Report.Bands.Item(BandKind.ReportHeader).Controls("lbljenissetoran").Text = "TOTAL PENDAPATAN KESELURUHAN ( tanpa pembagian user )"
            'Report.RunDesigner()
            Report.ShowPreview()
            Report.Print()

        End If

    End Sub

    Private Sub SummaryHarian_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        SetClear()
    End Sub


    Private Sub CreateTable()
        THasil = New DataTable

        insertRowToTbls(THasil, "Typstring", "Jenis")
        insertRowToTbls(THasil, "tyinterger", "Tunai")
        insertRowToTbls(THasil, "tyinterger", "Debet")
        insertRowToTbls(THasil, "tyinterger", "Kredit")
        insertRowToTbls(THasil, "tyinterger", "Disc")
        insertRowToTbls(THasil, "tyinterger", "Tagihan")
        insertRowToTbls(THasil, "tyinterger", "TotalafterDisc")

    End Sub

    Private Sub SetTanggal()
        Dim Tdt As Date = dtkasirawal.Value.AddDays(1)
        dtkasirakhir.Value = Tdt.Date.AddSeconds(-1)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SetTanggal()
        'ReportSatu()
        ReportDua()
    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub dtkasirakhir_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtkasirakhir.ValueChanged

    End Sub

    Private Sub ReportSatu()
        Dim Tbls As New DataTable
        CreateTable()

        Dim Tnew As DataRow = THasil.NewRow
        Tnew("Jenis") = "Admin"
        Tnew("Tunai") = CInt(ReadSQLNIK("select isnull(sum(JumlahBayar)-sum(Kembali),0) as Tunai from TransaksiAdminBayar where TransAdminID in (select TransAdminID from TransaksiAdmin where deleted=0 and TindakanTgl between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "') and JenisBayar='TUNAI'"))
        Tnew("Debet") = CInt(ReadSQLNIK("select isnull(sum(JumlahBayar),0) as Debet from TransaksiAdminBayar where TransAdminID in (select TransAdminID  from TransaksiAdmin where deleted=0 and TindakanTgl between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "') and JenisBayar='DEBET'"))
        Tnew("Kredit") = CInt(ReadSQLNIK("select isnull(sum(JumlahBayar),0) as Kredit from TransaksiAdminBayar where TransAdminID in (select TransAdminID  from TransaksiAdmin where deleted=0 and TindakanTgl between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "') and JenisBayar='CARD'"))
        Tnew("Disc") = CInt(ReadSQLNIK("select isnull(sum(JumlahBayar),0) as Discount from TransaksiAdminBayar where TransAdminID in (select TransAdminID  from TransaksiAdmin where deleted=0 and TindakanTgl between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "') and JenisBayar='DISC'"))
        Tnew("Tagihan") = CInt(ReadSQLNIK("select isnull(sum(JumlahBayar),0) as Discount from TransaksiAdminBayar where TransAdminID in ( select TransAdminID from TransaksiAdmin where deleted=0 and TindakanTgl between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "') and JenisBayar='TAGIHAN'"))
        Tnew("TotalafterDisc") = Tnew("Tunai") + Tnew("Debet") + Tnew("Kredit")
        THasil.Rows.Add(Tnew)

        Tnew = THasil.NewRow
        Tnew("Jenis") = "Klinik"
        Tnew("Tunai") = CInt(ReadSQLNIK("select isnull(sum(JumlahBayar)-sum(Kembali),0) as Tunai from TransaksiPoliBayar where TransPoliID in ( select TransPoliID from TransaksiPoli where deleted=0 and  CONVERT(date, TglPoli) between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "') and JenisBayar='TUNAI'")) + CInt(ReadSQLNIK("select isnull(sum(JumlahBayar)-sum(Kembali),0) as Tunai from TransaksiPoliBayarAwal where TransPoliID in ( select TransPoliID from TransaksiPoli where deleted=0 and CONVERT(date, TglPoli) between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "') and TransJenis='POLI' and JenisBayar='TUNAI'"))
        Tnew("Debet") = CInt(ReadSQLNIK("select isnull(sum(JumlahBayar),0) as Debet from TransaksiPoliBayar where TransPoliID in ( select TransPoliID from TransaksiPoli where deleted=0 and CONVERT(date, TglPoli) between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "') and JenisBayar='DEBET'")) + CInt(ReadSQLNIK("select isnull(sum(JumlahBayar),0) as Debet from TransaksiPoliBayarAwal where TransPoliID in ( select TransPoliID from TransaksiPoli where deleted=0 and CONVERT(date, TglPoli) between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "') and TransJenis='POLI' and JenisBayar='DEBET'"))
        Tnew("Kredit") = CInt(ReadSQLNIK("select isnull(sum(JumlahBayar),0) as Kredit from TransaksiPoliBayar where TransPoliID in ( select TransPoliID from TransaksiPoli where deleted=0 and CONVERT(date, TglPoli) between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "') and JenisBayar='CARD'")) + CInt(ReadSQLNIK("select isnull(sum(JumlahBayar),0) as Kredit from TransaksiPoliBayarAwal where TransPoliID in ( select TransPoliID from TransaksiPoli where deleted=0 and CONVERT(date, TglPoli) between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "') and TransJenis='POLI' and JenisBayar='CARD'"))
        Tnew("Disc") = CInt(ReadSQLNIK("select isnull(sum(JumlahBayar),0) as Discount from TransaksiPoliBayar where TransPoliID in ( select TransPoliID from TransaksiPoli where deleted=0 and CONVERT(date, TglPoli) between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "') and JenisBayar='DISC'")) + CInt(ReadSQLNIK("select isnull(sum(JumlahBayar),0) as Discount from TransaksiPoliBayarAwal where TransPoliID in ( select TransPoliID from TransaksiPoli where deleted=0 and CONVERT(date, TglPoli) between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "') and TransJenis='POLI' and JenisBayar='DISC'"))
        Tnew("Tagihan") = CInt(ReadSQLNIK("select isnull(sum(JumlahBayar),0) as Discount from TransaksiPoliBayar where TransPoliID in ( select TransPoliID from TransaksiPoli where deleted=0 and CONVERT(date, TglPoli) between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "') and JenisBayar='TAGIHAN'")) + CInt(ReadSQLNIK("select isnull(sum(JumlahBayar),0) as Discount from TransaksiPoliBayarAwal where TransPoliID in ( select TransPoliID from TransaksiPoli where deleted=0 and CONVERT(date, TglPoli) between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "') and TransJenis='POLI' and JenisBayar='TAGIHAN'"))
        Tnew("TotalafterDisc") = Tnew("Tunai") + Tnew("Debet") + Tnew("Kredit")
        THasil.Rows.Add(Tnew)

        Tnew = THasil.NewRow
        Tnew("Jenis") = "Lab"
        Tnew("Tunai") = CInt(ReadSQLNIK("select isnull(sum(JumlahBayar)-sum(Kembali),0) as Tunai from TransaksiLabBayar where TransLabID in (select TransLabID  from TransaksiLab where deleted=0 and CONVERT(date, Tgllab) between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "') and JenisBayar='TUNAI'"))
        Tnew("Debet") = CInt(ReadSQLNIK("select isnull(sum(JumlahBayar),0) as Debet from TransaksiLabBayar where TransLabID in (select TransLabID  from TransaksiLab where deleted=0 and CONVERT(date, Tgllab) between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "') and JenisBayar='DEBET'"))
        Tnew("Kredit") = CInt(ReadSQLNIK("select isnull(sum(JumlahBayar),0) as Kredit from TransaksiLabBayar where TransLabID in (select TransLabID  from TransaksiLab where deleted=0 and CONVERT(date, Tgllab) between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "') and JenisBayar='CARD'"))
        Tnew("Disc") = CInt(ReadSQLNIK("select isnull(sum(JumlahBayar),0) as Discount from TransaksiLabBayar where TransLabID in (select TransLabID  from TransaksiLab where deleted=0 and CONVERT(date, Tgllab) between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "') and JenisBayar='DISC'"))
        Tnew("Tagihan") = CInt(ReadSQLNIK("select isnull(sum(JumlahBayar),0) as Discount from TransaksiLabBayar where TransLabID in ( select TransLabID from TransaksiLab where deleted=0 and CONVERT(date, Tgllab) between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "') and JenisBayar='TAGIHAN'"))
        Tnew("TotalafterDisc") = Tnew("Tunai") + Tnew("Debet") + Tnew("Kredit")
        THasil.Rows.Add(Tnew)

        Tnew = THasil.NewRow
        Tnew("Jenis") = "Gigi"
        Tnew("Tunai") = CInt(ReadSQLNIK("select isnull(sum(JumlahBayar)-sum(Kembali),0) as Tunai from TransaksiGigiBayar where TransGigiID in (select TransGigiID  from TransaksiGigi where deleted=0 and CONVERT(date, TglGigi) between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "') and JenisBayar='TUNAI'")) + CInt(ReadSQLNIK("select isnull(sum(JumlahBayar)-sum(Kembali),0) as Tunai from TransaksiPoliBayarAwal where TransPoliID in ( select TransGigiID from TransaksiGigi  where deleted=0 and CONVERT(date, TglGigi) between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "') and TransJenis='GIGI' and JenisBayar='TUNAI'"))
        Tnew("Debet") = CInt(ReadSQLNIK("select isnull(sum(JumlahBayar),0) as Debet from TransaksiGigiBayar where TransGigiID in (select TransGigiID  from TransaksiGigi where deleted=0 and CONVERT(date, TglGigi) between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "') and JenisBayar='DEBET'")) + CInt(ReadSQLNIK("select isnull(sum(JumlahBayar),0) as Debet from TransaksiPoliBayarAwal where TransPoliID in ( select TransGigiID from TransaksiGigi  where deleted=0 and CONVERT(date, TglGigi) between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "') and TransJenis='GIGI' and JenisBayar='DEBET'"))
        Tnew("Kredit") = CInt(ReadSQLNIK("select isnull(sum(JumlahBayar),0) as Kredit from TransaksiGigiBayar where TransGigiID in (select TransGigiID  from TransaksiGigi where deleted=0 and CONVERT(date, TglGigi) between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "') and JenisBayar='CARD'")) + CInt(ReadSQLNIK("select isnull(sum(JumlahBayar),0) as Kredit from TransaksiPoliBayarAwal where TransPoliID in ( select TransGigiID from TransaksiGigi  where deleted=0 and CONVERT(date, TglGigi) between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "') and TransJenis='GIGI' and JenisBayar='CARD'"))
        Tnew("Disc") = CInt(ReadSQLNIK("select isnull(sum(JumlahBayar),0) as Discount from TransaksiGigiBayar where TransGigiID in (select TransGigiID  from TransaksiGigi where deleted=0 and CONVERT(date, TglGigi) between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "') and JenisBayar='DISC'")) + CInt(ReadSQLNIK("select isnull(sum(JumlahBayar),0) as Discount from TransaksiPoliBayarAwal where TransPoliID in ( select TransGigiID from TransaksiGigi  where deleted=0 and CONVERT(date, TglGigi) between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "') and TransJenis='GIGI' and JenisBayar='DISC'"))
        Tnew("Tagihan") = CInt(ReadSQLNIK("select isnull(sum(JumlahBayar),0) as Discount from TransaksiGigiBayar where TransGigiID in ( select TransGigiID from TransaksiGigi where deleted=0 and CONVERT(date, TglGigi) between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "') and JenisBayar='TAGIHAN'")) + CInt(ReadSQLNIK("select isnull(sum(JumlahBayar),0) as Discount from TransaksiPoliBayarAwal where TransPoliID in ( select TransGigiID from TransaksiGigi where deleted=0 and CONVERT(date, TglGigi) between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "') and TransJenis='GIGI' and JenisBayar='TAGIHAN'"))
        Tnew("TotalafterDisc") = Tnew("Tunai") + Tnew("Debet") + Tnew("Kredit")
        THasil.Rows.Add(Tnew)

        Report = New XtraReport
        Report = XtraReport.FromFile(Application.StartupPath + "\reports\LapPenerimaanUangHarian.repx", True)
        Report.DataSource = THasil
        Report.Bands.Item(BandKind.ReportHeader).Controls("lbltanggal").Text = Format(dtkasirawal.Value, "dd-MMM-yyyy HH:mm") & " - " & Format(dtkasirakhir.Value, "dd-MMM-yyyy HH:mm")
        Report.Bands.Item(BandKind.ReportHeader).Controls("lbladmin").Text = PoliKlinik.Lbluser.Text
        Report.Bands.Item(BandKind.ReportFooter).Controls("lbltanggalacc").Text = ".............. ," & Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:sss")
        Report.Bands.Item(BandKind.ReportHeader).Controls("lbljenissetoran").Text = "TOTAL PENDAPATAN KESELURUHAN (LAB+KLINIK+GIGI)"
        'Report.RunDesigner()
        Report.ShowPreview()
        Report.Print()
    End Sub

    Private Sub CreateTable2()
        THasil = ReadSQL("declare @Jjenis varchar(20) set @Jjenis=''  select @Jjenis as Jjenis, a.TransPoliID as ID,a.Nourut,a.TglPoli as Tgl,b.Nomitra,b.Nama as Pasien,a.TotalTagihan,a.TotalDisc,a.Pembulatan,a.NettBayar,a.TotalBayar,a.Pengembalian,a.PoliKeterangan from TransaksiPoli a left join MasterCustomer b on  a.IDInternet=b.nomitra  where CONVERT(date, TglPoli) between '8/15/2016' and GETDATE() and TransPoliID=''")

        insertRowToTbls(THasil, "tyinterger", "Tunai")
        insertRowToTbls(THasil, "tyinterger", "Debet")
        insertRowToTbls(THasil, "tyinterger", "Kredit")
        insertRowToTbls(THasil, "tyinterger", "Disc")
        insertRowToTbls(THasil, "tyinterger", "Tagihan")
        insertRowToTbls(THasil, "Typstring", "RecTagihan")
        insertRowToTbls(THasil, "Typstring", "Adm")
        insertRowToTbls(THasil, "Typstring", "transaksitime")
        insertRowToTbls(THasil, "Typstring", "JenisPasien")
        insertRowToTbls(THasil, "Typstring", "Kartu")
        insertRowToTbls(THasil, "Typstring", "Mesin")
        insertRowToTbls(THasil, "Typstring", "Result")
    End Sub

    Private Sub ReportDua()

        CreateTable2()

        'Case "KLINIK"
        Dim Tbls1 As DataTable = ReadSQL("select a.TransPoliID as ID,a.Nourut,a.TglPoli as Tgl,b.Nomitra,b.Nama as Pasien,a.TotalTagihan,a.TotalDisc,a.Pembulatan,a.NettBayar,a.TotalBayar,a.Pengembalian,a.deleted,a.deletedby,a.deleteddate,a.PoliKeterangan as RecTagihan from TransaksiPoli a left join MasterCustomer b on  a.IDInternet=b.nomitra  where CONVERT(date, a.TglPoli) between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "' order by a.Nourut")

        For Each Trow As DataRow In Tbls1.Rows

            If IsDBNull(Trow("deleted")) = False Then
                GoTo XX
            ElseIf Trow("deleted") = True Then
                Dim Tnew As DataRow = THasil.NewRow
                Tnew("Jjenis") = "Klinik"
                Tnew("ID") = Trow("ID")
                Tnew("Nourut") = Trow("Nourut")
                Tnew("Tgl") = Trow("Tgl")
                Tnew("Nomitra") = Trow("Nomitra")
                Tnew("Pasien") = Trow("Pasien")
                Tnew("TotalTagihan") = Trow("TotalTagihan")
                Tnew("TotalDisc") = Trow("TotalDisc")
                Tnew("Pembulatan") = Trow("Pembulatan")
                Tnew("NettBayar") = Trow("NettBayar")
                Tnew("TotalBayar") = Trow("TotalBayar")
                Tnew("Pengembalian") = Trow("Pengembalian")
                Tnew("Tunai") = "0"
                Tnew("Debet") = "0"
                Tnew("Kredit") = "0"
                Tnew("Disc") = "0"
                Tnew("Tagihan") = "0"
                Tnew("Adm") = "--TRANSACTION DELETED--"
                Tnew("transaksitime") = "By :" & Trow("deletedby").ToString & " ;" & Format(Trow("deleteddate"), "dd-MMM-yyyy HH:mm")
                Tnew("RecTagihan") = ""
                Tnew("JenisPasien") = ""
                Tnew("JenisKartu") = ""
                Tnew("JenisMesin") = ""
                THasil.Rows.Add(Tnew)
            Else
XX:             Dim Tdetail As DataTable = ReadSQL("select * from TransaksiPoliBayar where TransPoliID='" & Trow("ID") & "'")
                If Tdetail.Rows.Count > 0 Then
                    For Each Ttemp As DataRow In Tdetail.Rows
                        Dim Tnew As DataRow = THasil.NewRow
                        Tnew("Jjenis") = "Klinik"
                        Tnew("ID") = Trow("ID")
                        Tnew("Nourut") = Trow("Nourut")
                        Tnew("Tgl") = Trow("Tgl")
                        Tnew("Nomitra") = Trow("Nomitra")
                        Tnew("Pasien") = Trow("Pasien")
                        Tnew("TotalTagihan") = Trow("TotalTagihan")
                        Tnew("TotalDisc") = Trow("TotalDisc")
                        Tnew("Pembulatan") = Trow("Pembulatan")
                        Tnew("NettBayar") = Trow("NettBayar")
                        Tnew("TotalBayar") = Trow("TotalBayar")
                        Tnew("Pengembalian") = Trow("Pengembalian")
                        Tnew("RecTagihan") = Ttemp("NoJenisBayar")
                        Tnew("Adm") = ""
                        Tnew("transaksitime") = ""
                        If Strings.LCase(Ttemp("NoJenisBayar").ToString).Contains("bpjs") = True Then
                            Tnew("JenisPasien") = "BPJS"
                        End If

                        Select Case Ttemp("JenisBayar")
                            Case "TUNAI"
                                Tnew("JenisPasien") = "Pasien Umum"
                                Tnew("RecTagihan") = ""
                                Tnew("Tunai") = Ttemp("JumlahBayar") - Ttemp("Kembali")
                            Case "DEBET"
                                Tnew("JenisPasien") = "Pasien Umum"
                                Tnew("RecTagihan") = Ttemp("NoJenisBayar")
                                Tnew("Kartu") = Ttemp("kartu")
                                Tnew("Mesin") = Ttemp("mesin")
                                Tnew("Debet") = Ttemp("JumlahBayar")
                            Case "CARD"
                                Tnew("JenisPasien") = "Pasien Umum"
                                Tnew("RecTagihan") = Ttemp("NoJenisBayar")
                                Tnew("Kartu") = Ttemp("kartu")
                                Tnew("Mesin") = Ttemp("mesin")
                                Tnew("Kredit") = Ttemp("JumlahBayar")
                            Case "DISC"
                                Tnew("Disc") = Ttemp("JumlahBayar")
                            Case "TAGIHAN"
                                Tnew("JenisPasien") = Ttemp("NoJenisBayar")
                                Tnew("RecTagihan") = ""
                                Tnew("Tagihan") = Ttemp("JumlahBayar")
                        End Select
                        THasil.Rows.Add(Tnew)
                    Next
                Else
                    Dim Tnew As DataRow = THasil.NewRow
                    Tnew("Jjenis") = "Klinik"
                    Tnew("ID") = Trow("ID")
                    Tnew("Nourut") = Trow("Nourut")
                    Tnew("Tgl") = Trow("Tgl")
                    Tnew("Nomitra") = Trow("Nomitra")
                    Tnew("Pasien") = Trow("Pasien")
                    Tnew("TotalTagihan") = Trow("TotalTagihan")
                    Tnew("TotalDisc") = Trow("TotalDisc")
                    Tnew("Pembulatan") = Trow("Pembulatan")
                    Tnew("NettBayar") = Trow("NettBayar")
                    Tnew("TotalBayar") = Trow("TotalBayar")
                    Tnew("Pengembalian") = Trow("Pengembalian")
                    Tnew("Adm") = ""
                    Tnew("transaksitime") = ""
                    If CheckSQL("select * from TransaksipoliDetail where DeletedDate IS NULL AND NamaTindakan like '%bpjs%' and TransPoliID='" & Trow("ID").ToString & "'") = True Then Tnew("JenisPasien") = "BPJS" Else Tnew("JenisPasien") = "Pasien Umum"
                    THasil.Rows.Add(Tnew)
                End If

                Tdetail = ReadSQL("select * from TransaksiPoliBayarAwal where TransPoliID='" & Trow("ID") & "' and TransJenis='POLI'")
                If Tdetail.Rows.Count > 0 Then
                    For Each Ttemp As DataRow In Tdetail.Rows
                        Dim Tnew As DataRow = THasil.NewRow
                        Tnew("ID") = Trow("ID")
                        Tnew("Nourut") = Trow("Nourut")
                        Tnew("Tgl") = Trow("Tgl")
                        Tnew("Nomitra") = Trow("Nomitra")
                        Tnew("Pasien") = Trow("Pasien")
                        Tnew("TotalTagihan") = Trow("TotalTagihan")
                        Tnew("TotalDisc") = Trow("TotalDisc")
                        Tnew("Pembulatan") = Trow("Pembulatan")
                        Tnew("NettBayar") = Trow("NettBayar")
                        Tnew("TotalBayar") = Trow("TotalBayar")
                        Tnew("Pengembalian") = Trow("Pengembalian")
                        Tnew("RecTagihan") = Ttemp("NoJenisBayar")
                        Tnew("Adm") = ""
                        Tnew("transaksitime") = ""
                        If Strings.LCase(Ttemp("NoJenisBayar").ToString).Contains("bpjs") = True Then
                            Tnew("JenisPasien") = "BPJS"
                        End If

                        Select Case Ttemp("JenisBayar")
                            Case "TUNAI"
                                Tnew("JenisPasien") = "Pasien Umum"
                                Tnew("RecTagihan") = ""
                                Tnew("Tunai") = Ttemp("JumlahBayar") - Ttemp("Kembali")
                                'Tnew("Tunai") = CInt(ReadSQLNIK("select isnull(sum(JumlahBayar)-sum(Kembali),0) as Tunai from TransaksiAdminBayar where TransAdminID in (select TransAdminID  from TransaksiAdmin where TransAdminID='" & Trow("ID").ToString.Trim & "' and TindakanTgl between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "') and JenisBayar='TUNAI'"))
                            Case "DEBET"
                                Tnew("JenisPasien") = "Pasien Umum"
                                Tnew("RecTagihan") = Ttemp("NoJenisBayar")
                                Tnew("JenisKartu") = Ttemp("kartu")
                                Tnew("JenisMesin") = Ttemp("mesin")
                                Tnew("Debet") = Ttemp("JumlahBayar")
                                'Tnew("Debet") = CInt(ReadSQLNIK("select isnull(sum(JumlahBayar),0) as Debet from TransaksiAdminBayar where TransAdminID in (select TransAdminID  from TransaksiAdmin where TransAdminID='" & Trow("ID").ToString.Trim & "' and TindakanTgl between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "') and JenisBayar='DEBET'"))
                            Case "CARD"
                                Tnew("JenisPasien") = "Pasien Umum"
                                Tnew("RecTagihan") = Ttemp("NoJenisBayar")
                                Tnew("JenisKartu") = Ttemp("kartu")
                                Tnew("JenisMesin") = Ttemp("mesin")
                                Tnew("Kredit") = Ttemp("JumlahBayar")
                                'Tnew("Kredit") = CInt(ReadSQLNIK("select isnull(sum(JumlahBayar),0) as Kredit from TransaksiAdminBayar where TransAdminID in (select TransAdminID  from TransaksiAdmin where TransAdminID='" & Trow("ID").ToString.Trim & "' and TindakanTgl between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "') and JenisBayar='CARD'"))
                            Case "DISC"
                                Tnew("Disc") = Ttemp("JumlahBayar")
                                'Tnew("Disc") = CInt(ReadSQLNIK("select isnull(sum(JumlahBayar),0) as Discount from TransaksiAdminBayar where TransAdminID in (select TransAdminID  from TransaksiAdmin where TransAdminID='" & Trow("ID").ToString.Trim & "' and TindakanTgl between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "') and JenisBayar='DISC'"))
                            Case "TAGIHAN"
                                Tnew("JenisPasien") = Ttemp("NoJenisBayar")
                                Tnew("RecTagihan") = ""
                                Tnew("Tagihan") = Ttemp("JumlahBayar")
                                'Tnew("Tagihan") = CInt(ReadSQLNIK("select isnull(sum(JumlahBayar),0) as Tagihan from TransaksiAdminBayar where TransAdminID in (select TransAdminID  from TransaksiAdmin where TransAdminID='" & Trow("ID").ToString.Trim & "' and TindakanTgl between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "') and JenisBayar='TAGIHAN'"))
                        End Select
                        THasil.Rows.Add(Tnew)
                    Next
                End If

            End If
        Next

        'Case "LAB"
        Dim Tbls2 As DataTable = ReadSQL("select a.TransLabID as ID,a.Nourut,a.TglLab as Tgl,b.Nomitra,b.Nama as Pasien,a.TotalTagihan,a.TotalDisc,a.Pembulatan,a.NettBayar,a.TotalBayar,a.Pengembalian,a.deleted,a.deletedby,a.deleteddate,a.CaraAmbil as RecTagihan from TransaksiLab a left join MasterCustomer b on  a.IDInternet=b.nomitra  where CONVERT(date, a.TglLab) between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "' order by a.Nourut")

        For Each Trow As DataRow In Tbls2.Rows
            If IsDBNull(Trow("deleted")) = False Then
                GoTo YY
            ElseIf Trow("deleted") = True Then
                Dim Tnew As DataRow = THasil.NewRow
                Tnew("Jjenis") = "Lab"
                Tnew("ID") = Trow("ID")
                Tnew("Nourut") = Trow("Nourut")
                Tnew("Tgl") = Trow("Tgl")
                Tnew("Nomitra") = Trow("Nomitra")
                Tnew("Pasien") = Trow("Pasien")
                Tnew("TotalTagihan") = Trow("TotalTagihan")
                Tnew("TotalDisc") = Trow("TotalDisc")
                Tnew("Pembulatan") = Trow("Pembulatan")
                Tnew("NettBayar") = Trow("NettBayar")
                Tnew("TotalBayar") = Trow("TotalBayar")
                Tnew("Pengembalian") = Trow("Pengembalian")
                Tnew("Tunai") = "0"
                Tnew("Debet") = "0"
                Tnew("Kredit") = "0"
                Tnew("Disc") = "0"
                Tnew("Tagihan") = "0"
                Tnew("Adm") = "--TRANSACTION DELETED--"
                Tnew("transaksitime") = "By :" & Trow("deletedby").ToString & " ;" & Format(Trow("deleteddate"), "dd-MMM-yyyy HH:mm")
                Tnew("RecTagihan") = ""
                THasil.Rows.Add(Tnew)
            Else
YY:             Dim Tdetail As DataTable = ReadSQL("select * from TransaksiLabBayar where TransLabID='" & Trow("ID") & "'")
                If Tdetail.Rows.Count > 0 Then
                    For Each Ttemp As DataRow In Tdetail.Rows
                        Dim Tnew As DataRow = THasil.NewRow
                        Tnew("Jjenis") = "Lab"
                        Tnew("ID") = Trow("ID")
                        Tnew("Nourut") = Trow("Nourut")
                        Tnew("Tgl") = Trow("Tgl")
                        Tnew("Nomitra") = Trow("Nomitra")
                        Tnew("Pasien") = Trow("Pasien")
                        Tnew("TotalTagihan") = Trow("TotalTagihan")
                        Tnew("TotalDisc") = Trow("TotalDisc")
                        Tnew("Pembulatan") = Trow("Pembulatan")
                        Tnew("NettBayar") = Trow("NettBayar")
                        Tnew("TotalBayar") = Trow("TotalBayar")
                        Tnew("Pengembalian") = Trow("Pengembalian")
                        Tnew("RecTagihan") = Ttemp("NoJenisBayar")
                        Tnew("Adm") = ""
                        Tnew("transaksitime") = ""
                        If Strings.LCase(Ttemp("NoJenisBayar").ToString).Contains("bpjs") = True Then
                            Tnew("JenisPasien") = "BPJS"
                        End If

                        Select Case Ttemp("JenisBayar")
                            Case "TUNAI"
                                Tnew("JenisPasien") = "Pasien Umum"
                                Tnew("RecTagihan") = ""
                                Tnew("Tunai") = Ttemp("JumlahBayar") - Ttemp("Kembali")
                            Case "DEBET"
                                Tnew("JenisPasien") = "Pasien Umum"
                                Tnew("RecTagihan") = Ttemp("NoJenisBayar")
                                Tnew("Kartu") = Ttemp("kartu")
                                Tnew("Mesin") = Ttemp("mesin")
                                Tnew("Debet") = Ttemp("JumlahBayar")
                            Case "CARD"
                                Tnew("JenisPasien") = "Pasien Umum"
                                Tnew("RecTagihan") = Ttemp("NoJenisBayar")
                                Tnew("Kartu") = Ttemp("kartu")
                                Tnew("Mesin") = Ttemp("mesin")
                                Tnew("Kredit") = Ttemp("JumlahBayar")
                            Case "DISC"
                                Tnew("Disc") = Ttemp("JumlahBayar")
                            Case "TAGIHAN"
                                Tnew("Tagihan") = Ttemp("JumlahBayar")
                                Tnew("JenisPasien") = Ttemp("NoJenisBayar")
                                Tnew("RecTagihan") = ""
                        End Select
                        THasil.Rows.Add(Tnew)
                    Next

                Else
                    Dim Tnew As DataRow = THasil.NewRow
                    Tnew("Jjenis") = "Lab"
                    Tnew("ID") = Trow("ID")
                    Tnew("Nourut") = Trow("Nourut")
                    Tnew("Tgl") = Trow("Tgl")
                    Tnew("Nomitra") = Trow("Nomitra")
                    Tnew("Pasien") = Trow("Pasien")
                    Tnew("TotalTagihan") = Trow("TotalTagihan")
                    Tnew("TotalDisc") = Trow("TotalDisc")
                    Tnew("Pembulatan") = Trow("Pembulatan")
                    Tnew("NettBayar") = Trow("NettBayar")
                    Tnew("TotalBayar") = Trow("TotalBayar")
                    Tnew("Pengembalian") = Trow("Pengembalian")
                    If CheckSQL("select * from TransaksiLabDetail where NamaTindakan like '%bpjs%' and TransLabID='" & Trow("ID").ToString & "'") = True Then Tnew("JenisPasien") = "BPJS" Else Tnew("JenisPasien") = "Pasien Umum"
                    Tnew("Adm") = ""
                    Tnew("transaksitime") = ""
                    THasil.Rows.Add(Tnew)
                End If
            End If
        Next

        'Case "GIGI"
        Dim Tbls3 As DataTable = ReadSQL("select a.TransGigiID as ID,a.Nourut,a.TglGigi as Tgl,b.Nomitra,b.Nama as Pasien,a.TotalTagihan,a.TotalDisc,a.Pembulatan,a.NettBayar,a.TotalBayar,a.Pengembalian,a.deleted,a.deletedby,a.deleteddate,a.keluhan as RecTagihan from TransaksiGigi a left join MasterCustomer b on  a.IDInternet=b.nomitra  where CONVERT(date, a.TglGigi) between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "' order by a.Nourut")

        For Each Trow As DataRow In Tbls3.Rows
            If IsDBNull(Trow("deleted")) = False Then
                GoTo ZZ
            ElseIf Trow("deleted") = True Then
                Dim Tnew As DataRow = THasil.NewRow
                Tnew("Jjenis") = "Gigi"
                Tnew("ID") = Trow("ID")
                Tnew("Nourut") = Trow("Nourut")
                Tnew("Tgl") = Trow("Tgl")
                Tnew("Nomitra") = Trow("Nomitra")
                Tnew("Pasien") = Trow("Pasien")
                Tnew("TotalTagihan") = Trow("TotalTagihan")
                Tnew("TotalDisc") = Trow("TotalDisc")
                Tnew("Pembulatan") = Trow("Pembulatan")
                Tnew("NettBayar") = Trow("NettBayar")
                Tnew("TotalBayar") = Trow("TotalBayar")
                Tnew("Pengembalian") = Trow("Pengembalian")
                Tnew("Tunai") = "0"
                Tnew("Debet") = "0"
                Tnew("Kredit") = "0"
                Tnew("Disc") = "0"
                Tnew("Tagihan") = "0"
                Tnew("Adm") = "--TRANSACTION DELETED--"
                Tnew("transaksitime") = "By :" & Trow("deletedby").ToString & " ;" & Format(Trow("deleteddate"), "dd-MMM-yyyy HH:mm")
                Tnew("RecTagihan") = ""
                THasil.Rows.Add(Tnew)
            Else
ZZ:             Dim Tdetail As DataTable = ReadSQL("select * from TransaksiGigiBayar where TransGigiID='" & Trow("ID") & "'")
                If Tdetail.Rows.Count > 0 Then
                    For Each Ttemp As DataRow In Tdetail.Rows
                        Dim Tnew As DataRow = THasil.NewRow
                        Tnew("Jjenis") = "Gigi"
                        Tnew("ID") = Trow("ID")
                        Tnew("Nourut") = Trow("Nourut")
                        Tnew("Tgl") = Trow("Tgl")
                        Tnew("Nomitra") = Trow("Nomitra")
                        Tnew("Pasien") = Trow("Pasien")
                        Tnew("TotalTagihan") = Trow("TotalTagihan")
                        Tnew("TotalDisc") = Trow("TotalDisc")
                        Tnew("Pembulatan") = Trow("Pembulatan")
                        Tnew("NettBayar") = Trow("NettBayar")
                        Tnew("TotalBayar") = Trow("TotalBayar")
                        Tnew("Pengembalian") = Trow("Pengembalian")
                        Tnew("RecTagihan") = Ttemp("NoJenisBayar")
                        Tnew("Adm") = ""
                        Tnew("transaksitime") = ""
                        If Strings.LCase(Ttemp("NoJenisBayar").ToString).Contains("bpjs") = True Then
                            Tnew("JenisPasien") = "BPJS"
                        End If

                        Select Case Ttemp("JenisBayar")
                            Case "TUNAI"
                                Tnew("JenisPasien") = "Pasien Umum"
                                Tnew("RecTagihan") = ""
                                Tnew("Tunai") = Ttemp("JumlahBayar") - Ttemp("Kembali")
                            Case "DEBET"
                                Tnew("JenisPasien") = "Pasien Umum"
                                Tnew("RecTagihan") = Ttemp("NoJenisBayar")
                                Tnew("Kartu") = Ttemp("kartu")
                                Tnew("Mesin") = Ttemp("mesin")
                                Tnew("Debet") = Ttemp("JumlahBayar")
                            Case "CARD"
                                Tnew("JenisPasien") = "Pasien Umum"
                                Tnew("RecTagihan") = Ttemp("NoJenisBayar")
                                Tnew("Kartu") = Ttemp("kartu")
                                Tnew("Mesin") = Ttemp("mesin")
                                Tnew("Kredit") = Ttemp("JumlahBayar")
                            Case "DISC"
                                Tnew("Disc") = Ttemp("JumlahBayar")
                            Case "TAGIHAN"
                                Tnew("Tagihan") = Ttemp("JumlahBayar")
                                Tnew("JenisPasien") = Ttemp("NoJenisBayar")
                                Tnew("Tagihan") = Ttemp("JumlahBayar")
                        End Select
                        THasil.Rows.Add(Tnew)
                    Next
                Else
                    Dim Tnew As DataRow = THasil.NewRow
                    Tnew("Jjenis") = "Gigi"
                    Tnew("ID") = Trow("ID")
                    Tnew("Nourut") = Trow("Nourut")
                    Tnew("Tgl") = Trow("Tgl")
                    Tnew("Nomitra") = Trow("Nomitra")
                    Tnew("Pasien") = Trow("Pasien")
                    Tnew("TotalTagihan") = Trow("TotalTagihan")
                    Tnew("TotalDisc") = Trow("TotalDisc")
                    Tnew("Pembulatan") = Trow("Pembulatan")
                    Tnew("NettBayar") = Trow("NettBayar")
                    Tnew("TotalBayar") = Trow("TotalBayar")
                    Tnew("Pengembalian") = Trow("Pengembalian")
                    If CheckSQL("select * from TransaksiGigiDetail where NamaTindakan like '%bpjs%' and TransGigiID='" & Trow("ID").ToString & "'") = True Then Tnew("JenisPasien") = "BPJS" Else Tnew("JenisPasien") = "Pasien Umum"
                    Tnew("Adm") = ""
                    Tnew("transaksitime") = ""
                    THasil.Rows.Add(Tnew)
                End If

                Tdetail = ReadSQL("select * from TransaksiPoliBayarAwal where TransPoliID='" & Trow("ID") & "' and TransJenis='GIGI'")
                If Tdetail.Rows.Count > 0 Then
                    For Each Ttemp As DataRow In Tdetail.Rows
                        Dim Tnew As DataRow = THasil.NewRow
                        Tnew("ID") = Trow("ID")
                        Tnew("Nourut") = Trow("Nourut")
                        Tnew("Tgl") = Trow("Tgl")
                        Tnew("Nomitra") = Trow("Nomitra")
                        Tnew("Pasien") = Trow("Pasien")
                        Tnew("TotalTagihan") = Trow("TotalTagihan")
                        Tnew("TotalDisc") = Trow("TotalDisc")
                        Tnew("Pembulatan") = Trow("Pembulatan")
                        Tnew("NettBayar") = Trow("NettBayar")
                        Tnew("TotalBayar") = Trow("TotalBayar")
                        Tnew("Pengembalian") = Trow("Pengembalian")
                        Tnew("RecTagihan") = Ttemp("NoJenisBayar")
                        Tnew("Adm") = ""
                        Tnew("transaksitime") = ""
                        If Strings.LCase(Ttemp("NoJenisBayar").ToString).Contains("bpjs") = True Then
                            Tnew("JenisPasien") = "BPJS"
                        End If

                        Select Case Ttemp("JenisBayar")
                            Case "TUNAI"
                                Tnew("JenisPasien") = "Pasien Umum"
                                Tnew("RecTagihan") = ""
                                Tnew("Tunai") = Ttemp("JumlahBayar") - Ttemp("Kembali")
                                'Tnew("Tunai") = CInt(ReadSQLNIK("select isnull(sum(JumlahBayar)-sum(Kembali),0) as Tunai from TransaksiAdminBayar where TransAdminID in (select TransAdminID  from TransaksiAdmin where TransAdminID='" & Trow("ID").ToString.Trim & "' and TindakanTgl between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "') and JenisBayar='TUNAI'"))
                            Case "DEBET"
                                Tnew("JenisPasien") = "Pasien Umum"
                                Tnew("RecTagihan") = Ttemp("NoJenisBayar")
                                Tnew("JenisKartu") = Ttemp("kartu")
                                Tnew("JenisMesin") = Ttemp("mesin")
                                Tnew("Debet") = Ttemp("JumlahBayar")
                                'Tnew("Debet") = CInt(ReadSQLNIK("select isnull(sum(JumlahBayar),0) as Debet from TransaksiAdminBayar where TransAdminID in (select TransAdminID  from TransaksiAdmin where TransAdminID='" & Trow("ID").ToString.Trim & "' and TindakanTgl between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "') and JenisBayar='DEBET'"))
                            Case "CARD"
                                Tnew("JenisPasien") = "Pasien Umum"
                                Tnew("RecTagihan") = Ttemp("NoJenisBayar")
                                Tnew("JenisKartu") = Ttemp("kartu")
                                Tnew("JenisMesin") = Ttemp("mesin")
                                Tnew("Kredit") = Ttemp("JumlahBayar")
                                'Tnew("Kredit") = CInt(ReadSQLNIK("select isnull(sum(JumlahBayar),0) as Kredit from TransaksiAdminBayar where TransAdminID in (select TransAdminID  from TransaksiAdmin where TransAdminID='" & Trow("ID").ToString.Trim & "' and TindakanTgl between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "') and JenisBayar='CARD'"))
                            Case "DISC"
                                Tnew("Disc") = Ttemp("JumlahBayar")
                                'Tnew("Disc") = CInt(ReadSQLNIK("select isnull(sum(JumlahBayar),0) as Discount from TransaksiAdminBayar where TransAdminID in (select TransAdminID  from TransaksiAdmin where TransAdminID='" & Trow("ID").ToString.Trim & "' and TindakanTgl between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "') and JenisBayar='DISC'"))
                            Case "TAGIHAN"
                                Tnew("JenisPasien") = Ttemp("NoJenisBayar")
                                Tnew("RecTagihan") = ""
                                Tnew("Tagihan") = Ttemp("JumlahBayar")
                                'Tnew("Tagihan") = CInt(ReadSQLNIK("select isnull(sum(JumlahBayar),0) as Tagihan from TransaksiAdminBayar where TransAdminID in (select TransAdminID  from TransaksiAdmin where TransAdminID='" & Trow("ID").ToString.Trim & "' and TindakanTgl between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "') and JenisBayar='TAGIHAN'"))
                        End Select
                        THasil.Rows.Add(Tnew)
                    Next
                End If
            End If
        Next

        'Case "ADMIN"
        Dim Tbls4 As DataTable = ReadSQL("select a.TransAdminID as ID,'-' as  Nourut,a.TindakanTgl as Tgl,b.Nomitra,b.Nama as Pasien,a.TotalTagihan,a.TotalDisc,a.Pembulatan,a.NettBayar,a.TotalBayar,a.Pengembalian,a.deleted,a.deletedby,a.deleteddate,a.IDInternet as RecTagihan from TransaksiAdmin  a left join MasterCustomer b on  a.IDInternet=b.nomitra  where a.TindakanTgl between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "' order by a.ChangeDate,a.TransAdminID")

        For Each Trow As DataRow In Tbls4.Rows
            If IsDBNull(Trow("deleted")) = False Then
                GoTo MM
            ElseIf Trow("deleted") = True Then
                Dim Tnew As DataRow = THasil.NewRow
                Tnew("Jjenis") = "Admin"
                Tnew("ID") = Trow("ID")
                Tnew("Nourut") = Trow("Nourut")
                Tnew("Tgl") = Trow("Tgl")
                Tnew("Nomitra") = Trow("Nomitra")
                Tnew("Pasien") = Trow("Pasien")
                Tnew("TotalTagihan") = Trow("TotalTagihan")
                Tnew("TotalDisc") = Trow("TotalDisc")
                Tnew("Pembulatan") = Trow("Pembulatan")
                Tnew("NettBayar") = Trow("NettBayar")
                Tnew("TotalBayar") = Trow("TotalBayar")
                Tnew("Pengembalian") = Trow("Pengembalian")
                Tnew("Tunai") = "0"
                Tnew("Debet") = "0"
                Tnew("Kredit") = "0"
                Tnew("Disc") = "0"
                Tnew("Tagihan") = "0"
                Tnew("Adm") = "--TRANSACTION DELETED--"
                Tnew("transaksitime") = "By :" & Trow("deletedby").ToString & " ;" & Format(Trow("deleteddate"), "dd-MMM-yyyy HH:mm")
                Tnew("RecTagihan") = ""
                THasil.Rows.Add(Tnew)
            Else
MM:             Dim Tdetail As DataTable = ReadSQL("select * from TransaksiAdminBayar where TransAdminID='" & Trow("ID") & "'")
                If Tdetail.Rows.Count > 0 Then
                    For Each Ttemp As DataRow In Tdetail.Rows
                        Dim Tnew As DataRow = THasil.NewRow
                        Tnew("Jjenis") = "Admin"
                        Tnew("ID") = Trow("ID")
                        Tnew("Nourut") = Trow("Nourut")
                        Tnew("Tgl") = Trow("Tgl")
                        Tnew("Nomitra") = Trow("Nomitra")
                        Tnew("Pasien") = Trow("Pasien")
                        Tnew("TotalTagihan") = Trow("TotalTagihan")
                        Tnew("TotalDisc") = Trow("TotalDisc")
                        Tnew("Pembulatan") = Trow("Pembulatan")
                        Tnew("NettBayar") = Trow("NettBayar")
                        Tnew("TotalBayar") = Trow("TotalBayar")
                        Tnew("Pengembalian") = Trow("Pengembalian")
                        Tnew("RecTagihan") = Ttemp("NoJenisBayar")
                        Tnew("Adm") = ""
                        Tnew("transaksitime") = ""
                        If Strings.LCase(Ttemp("NoJenisBayar").ToString).Contains("bpjs") = True Then
                            Tnew("JenisPasien") = "BPJS"
                        End If

                        Select Case Ttemp("JenisBayar")
                            Case "TUNAI"
                                Tnew("JenisPasien") = "Pasien Umum"
                                Tnew("RecTagihan") = ""
                                Tnew("Tunai") = Ttemp("JumlahBayar") - Ttemp("Kembali")
                            Case "DEBET"
                                Tnew("JenisPasien") = "Pasien Umum"
                                Tnew("RecTagihan") = Ttemp("NoJenisBayar")
                                Tnew("Kartu") = Ttemp("kartu")
                                Tnew("Mesin") = Ttemp("mesin")
                                Tnew("Debet") = Ttemp("JumlahBayar")
                            Case "CARD"
                                Tnew("JenisPasien") = "Pasien Umum"
                                Tnew("RecTagihan") = Ttemp("NoJenisBayar")
                                Tnew("Kartu") = Ttemp("kartu")
                                Tnew("Mesin") = Ttemp("mesin")
                                Tnew("Kredit") = Ttemp("JumlahBayar")
                            Case "DISC"
                                Tnew("Disc") = Ttemp("JumlahBayar")
                            Case "TAGIHAN"
                                Tnew("JenisPasien") = Ttemp("NoJenisBayar")
                                Tnew("RecTagihan") = ""
                                Tnew("Tagihan") = Ttemp("JumlahBayar")
                        End Select
                        THasil.Rows.Add(Tnew)
                    Next
                Else
                    Dim Tnew As DataRow = THasil.NewRow
                    Tnew("Jjenis") = "Admin"
                    Tnew("ID") = Trow("ID")
                    Tnew("Nourut") = Trow("Nourut")
                    Tnew("Tgl") = Trow("Tgl")
                    Tnew("Nomitra") = Trow("Nomitra")
                    Tnew("Pasien") = Trow("Pasien")
                    Tnew("TotalTagihan") = Trow("TotalTagihan")
                    Tnew("TotalDisc") = Trow("TotalDisc")
                    Tnew("Pembulatan") = Trow("Pembulatan")
                    Tnew("NettBayar") = Trow("NettBayar")
                    Tnew("TotalBayar") = Trow("TotalBayar")
                    Tnew("Pengembalian") = Trow("Pengembalian")
                    Tnew("RecTagihan") = ""
                    Tnew("Adm") = ""
                    Tnew("transaksitime") = ""
                    If CheckSQL("select * from TransaksiAdminDetail where NamaTindakan like '%bpjs%' and TransAdminID='" & Trow("ID").ToString & "'") = True Then Tnew("JenisPasien") = "BPJS" Else Tnew("JenisPasien") = "Pasien Umum"
                    THasil.Rows.Add(Tnew)
                End If
            End If
        Next

        'For Each Tnrow As DataRow In THasil.Rows
        '    If Tnrow("") =  Then
        '        Tnrow("Result") = "TRUE"
        '    Else
        '        Tnrow("Result") = "FALSE"
        '    End If
        'Next

        GridControl1.DataSource = THasil

        GridView1.Columns("transaksitime").Visible = False
        GridView1.Columns("Adm").Visible = False
        GridView1.Columns("ID").Visible = False
        GridView1.Columns("TotalTagihan").Visible = False
        GridView1.Columns("TotalDisc").Visible = False
        GridView1.Columns("Pembulatan").Visible = False
        GridView1.Columns("NettBayar").Visible = False
        GridView1.Columns("Pengembalian").Visible = False
        GridView1.Columns("PoliKeterangan").Visible = False

    End Sub

    Private Sub dtkasirawal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtkasirawal.ValueChanged
        SetTanggal()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim Tloc As String = ReadSQLNIK("select StrValue  from MsConfig where ConfigName='NoPoli'")

        'Dim Tnew As DataRow = THasil.NewRow
        'Tnew("Jjenis") = "Admin"
        'Tnew("ID") = Trow("ID")
        'Tnew("Nourut") = Trow("Nourut")
        'Tnew("Tgl") = Trow("Tgl")
        'Tnew("Nomitra") = Trow("Nomitra")
        'Tnew("Pasien") = Trow("Pasien")
        'Tnew("TotalTagihan") = Trow("TotalTagihan")
        'Tnew("TotalDisc") = Trow("TotalDisc")
        'Tnew("Pembulatan") = Trow("Pembulatan")
        'Tnew("NettBayar") = Trow("NettBayar")
        'Tnew("TotalBayar") = Trow("TotalBayar")
        'Tnew("Pengembalian") = Trow("Pengembalian")
        'Tnew("Tunai") = "0"
        'Tnew("Debet") = "0"
        'Tnew("Kredit") = "0"
        'Tnew("Disc") = "0"
        'Tnew("Tagihan") = "0"
        'Tnew("Adm") = "--TRANSACTION DELETED--"
        'Tnew("transaksitime") = "By :" & Trow("deletedby").ToString & " ;" & Format(Trow("deleteddate"), "dd-MMM-yyyy HH:mm")
        'Tnew("RecTagihan") = ""


        Dim Tdata As DataTable = GridControl1.DataSource

        For Each Trow As DataRow In Tdata.Rows


            '  WriteThemysql("insert into acctranspenerimaantagihandetail(loc, inctgl, inctransid, incjenis, jenis, kartu, mesin, incnilai, createdate,idinternet) values(" & _
            '"'" & Tloc & "','" & Format(Trow("Tgl"), "yyyyMMdd") & "','" & Trow("ID") & "','" & Trow("Jenis") & "','" & Trow("JenisBayar") & "','" & Trow("kartu") & "','" & Trow("mesin") & "','" & Trow("TtlBayar") & "',now(),'" & Trow("IDInternet") & "') ", Ttcon)

            '  WriteThemysql("insert into acctranspenerimaandetail(loc, inctgl, inctransid, incjenis, jenis, kartu, mesin, incnilai, createdate,idinternet) values(" & _
            '"'" & Tloc & "','" & Format(Trow("Tgl"), "yyyyMMdd") & "','" & Trow("ID") & "','" & Trow("Jenis") & "','" & Trow("JenisBayar") & "','" & Trow("kartu") & "','" & Trow("mesin") & "','" & Trow("TtlBayar") & "',now(),'" & Trow("IDInternet") & "') ", Ttcon)

        Next


        'For Each Trow As DataRow In Tadmin.Rows
        '    If Trow("JenisBayar") = "TAGIHAN" Then
        '    Else
        '    End If
        'Next


    End Sub
End Class


