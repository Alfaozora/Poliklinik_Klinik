Public Class Report_Monthly

    Dim Tjudul As String = ""
    Dim Theader As String = ""

    Function CreateTable() As DataTable
        Dim Thasil As DataTable = ReadSQL("select a.TransPoliID as ID,a.Nourut,a.TglPoli as Tgl,b.Nomitra,b.Nama as Pasien,a.TotalTagihan,a.TotalDisc,a.Pembulatan,a.NettBayar,a.TotalBayar,a.Pengembalian,a.PoliKeterangan from TransaksiPoli a left join MasterCustomer b on  a.IDInternet=b.nomitra  where CONVERT(date, TglPoli) between '8/15/2016' and GETDATE() and TransPoliID=''")

        insertRowToTbls(Thasil, "tyinterger", "Tunai")
        insertRowToTbls(Thasil, "tyinterger", "Debet")
        insertRowToTbls(Thasil, "tyinterger", "Kredit")
        insertRowToTbls(Thasil, "tyinterger", "Disc")
        insertRowToTbls(Thasil, "tyinterger", "Tagihan")
        insertRowToTbls(Thasil, "Typstring", "RecTagihan")
        insertRowToTbls(Thasil, "Typstring", "Adm")
        insertRowToTbls(Thasil, "Typstring", "transaksitime")
        insertRowToTbls(Thasil, "Typstring", "JenisPasien")
        insertRowToTbls(Thasil, "Typstring", "JenisKartu")
        insertRowToTbls(Thasil, "Typstring", "JenisMesin")

        Return Thasil
    End Function


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        PoliResult()
        LabResult()
        GigiResult()
        DllResult()
    End Sub

    Private Sub PoliResult()
        Dim Tbls As New DataTable
        Dim Tpoli As DataTable = CreateTable()

        Tbls = ReadSQL("select a.TransPoliID as ID,a.Nourut,a.TglPoli as Tgl,b.Nomitra,b.Nama as Pasien,a.TotalTagihan,a.TotalDisc,a.Pembulatan,a.NettBayar,a.TotalBayar,a.Pengembalian,a.deleted,a.deletedby,a.deleteddate,a.PoliKeterangan as RecTagihan from TransaksiPoli a left join MasterCustomer b on  a.IDInternet=b.nomitra  where a.deleted <> 1 and CONVERT(date, a.TglPoli) between '" & Format(dtawal.Value, "MM/dd/yyyy") & "' and '" & Format(dtakhir.Value, "MM/dd/yyyy") & "'  order by a.Nourut")

        For Each Trow As DataRow In Tbls.Rows

            If IsDBNull(Trow("deleted")) = False Then
                GoTo XX
            ElseIf Trow("deleted") = True Then
                Dim Tnew As DataRow = Tpoli.NewRow
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
                Tpoli.Rows.Add(Tnew)
            Else

XX:             Dim Tdetail As DataTable = ReadSQL("select * from TransaksiPoliBayar where TransPoliID='" & Trow("ID") & "'")
                If Tdetail.Rows.Count > 0 Then
                    For Each Ttemp As DataRow In Tdetail.Rows
                        Dim Tnew As DataRow = Tpoli.NewRow
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
                        'If Strings.LCase(Ttemp("NoJenisBayar").ToString).Contains("bpjs") = False Then
                        'Tnew("JenisPasien") = "BPJS"
                        'Thasil.Rows.Add(Tnew)
                        'Else
                        Select Case Ttemp("JenisBayar")
                            Case "TUNAI"
                                Tnew("JenisPasien") = "Pasien Umum"
                                Tnew("RecTagihan") = ""
                                Tnew("Tunai") = Ttemp("JumlahBayar") - Ttemp("Kembali") + CInt(ReadSQLNIK("select isnull(sum(JumlahBayar)-sum(Kembali),0) as Tunai from TransaksiPoliBayarAwal where TransPoliID in ( select TransPoliID from TransaksiPoli where TransPoliID='" & Trow("ID").ToString.Trim & "' and CONVERT(date, TglPoli) = '" & Format(dtawal.Value, "MM/dd/yyyy") & "') and TransJenis='POLI' and JenisBayar='TUNAI'"))

                            Case "DEBET"
                                Tnew("JenisPasien") = "Pasien Umum"
                                Tnew("RecTagihan") = Ttemp("NoJenisBayar")
                                Tnew("JenisKartu") = Ttemp("kartu")
                                Tnew("JenisMesin") = Ttemp("mesin")
                                Tnew("Debet") = Ttemp("JumlahBayar")
                            Case "CARD"
                                Tnew("JenisPasien") = "Pasien Umum"
                                Tnew("RecTagihan") = Ttemp("NoJenisBayar")
                                Tnew("JenisKartu") = Ttemp("kartu")
                                Tnew("JenisMesin") = Ttemp("mesin")
                                Tnew("Kredit") = Ttemp("JumlahBayar")
                            Case "DISC"
                                Tnew("Disc") = Ttemp("JumlahBayar")
                                Tnew("Disc") = CInt(ReadSQLNIK("select isnull(sum(JumlahBayar),0) as Discount from TransaksiPoliBayar where TransPoliID in ( select TransPoliID from TransaksiPoli where TransPoliID='" & Trow("ID").ToString.Trim & "' and CONVERT(date, TglPoli) = '" & Format(dtawal.Value, "MM/dd/yyyy") & "') and JenisBayar='DISC'")) + CInt(ReadSQLNIK("select isnull(sum(JumlahBayar),0) as Discount from TransaksiPoliBayarAwal where TransPoliID in ( select TransPoliID from TransaksiPoli where TransPoliID='" & Trow("ID").ToString.Trim & "' and CONVERT(date, TglPoli) = '" & Format(dtawal.Value, "MM/dd/yyyy") & "') and TransJenis='POLI' and JenisBayar='DISC'"))
                            Case "TAGIHAN"
                                Tnew("JenisPasien") = Ttemp("NoJenisBayar")
                                Tnew("RecTagihan") = ""
                                Tnew("Tagihan") = Ttemp("JumlahBayar")
                        End Select
                        Tpoli.Rows.Add(Tnew)
                        'End If
                    Next
                End If


                Tdetail = ReadSQL("select * from TransaksiPoliBayarAwal where TransPoliID='" & Trow("ID") & "' and TransJenis='POLI'")
                If Tdetail.Rows.Count > 0 Then
                    For Each Ttemp As DataRow In Tdetail.Rows
                        Dim Tnew As DataRow = Tpoli.NewRow
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
                        'If Strings.LCase(Ttemp("NoJenisBayar").ToString).Contains("bpjs") = False Then
                        'Tnew("JenisPasien") = "BPJS"
                        'Thasil.Rows.Add(Tnew)
                        'Else
                        Select Case Ttemp("JenisBayar")
                            Case "TUNAI"
                                If CheckSQL("select * from TransaksiPoliBayar where TransPoliID='" & Trow("ID") & "' and JenisBayar='TUNAI'") = False Then
                                    Tnew("JenisPasien") = "Pasien Umum"
                                    Tnew("RecTagihan") = ""
                                    Tnew("Tunai") = Ttemp("JumlahBayar") - Ttemp("Kembali")
                                End If
                            Case "DEBET"
                                Tnew("JenisPasien") = "Pasien Umum"
                                Tnew("RecTagihan") = Ttemp("NoJenisBayar")
                                Tnew("JenisKartu") = Ttemp("kartu")
                                Tnew("JenisMesin") = Ttemp("mesin")
                                Tnew("Debet") = Ttemp("JumlahBayar")
                            Case "CARD"
                                Tnew("JenisPasien") = "Pasien Umum"
                                Tnew("RecTagihan") = Ttemp("NoJenisBayar")
                                Tnew("JenisKartu") = Ttemp("kartu")
                                Tnew("JenisMesin") = Ttemp("mesin")
                                Tnew("Kredit") = Ttemp("JumlahBayar")
                            Case "DISC"
                                Tnew("Disc") = Ttemp("JumlahBayar")
                            Case "TAGIHAN"
                                Tnew("JenisPasien") = Ttemp("NoJenisBayar")
                                Tnew("RecTagihan") = ""
                                Tnew("Tagihan") = Ttemp("JumlahBayar")
                        End Select
                        Tpoli.Rows.Add(Tnew)
                        'End If
                    Next
                End If
            End If
        Next

        gridpoli.DataSource = Tpoli

        GridView1.Columns("ID").Visible = False
        GridView1.Columns("Tgl").Visible = False
        GridView1.Columns("TotalTagihan").Visible = False
        GridView1.Columns("PoliKeterangan").Visible = False
        GridView1.Columns("TotalDisc").Visible = False
        GridView1.Columns("Pembulatan").Visible = False
        GridView1.Columns("NettBayar").Visible = False
        GridView1.Columns("Pengembalian").Visible = False
        GridView1.Columns("Adm").Visible = False
        GridView1.Columns("transaksitime").Visible = False

    End Sub

    Private Sub LabResult()
        Dim Tbls As New DataTable
        Dim TLab As DataTable = CreateTable()

        Tbls = ReadSQL("select a.LabSamplingTime, a.TransLabID as ID,a.Nourut,a.TglLab as Tgl,b.Nomitra,b.Nama as Pasien,a.TotalTagihan,a.TotalDisc,a.Pembulatan,a.NettBayar,a.TotalBayar,a.Pengembalian,a.deleted,a.deletedby,a.deleteddate,a.CaraAmbil as RecTagihan from TransaksiLab a left join MasterCustomer b on  a.IDInternet=b.nomitra  where a.deleted <> 1 and CONVERT(date, a.TglLab) between '" & Format(dtawal.Value, "MM/dd/yyyy") & "' and '" & Format(dtakhir.Value, "MM/dd/yyyy") & "'  order by a.Nourut")

        For Each Trow As DataRow In Tbls.Rows
            If IsDBNull(Trow("LabSamplingTime")) = True And Trow("Nourut").ToString.Contains("M") = True Then
                'Data tidak dapat
                'MsgBox("Kosong")
            Else
                If IsDBNull(Trow("deleted")) = False Then
                    GoTo ZZ
                ElseIf Trow("deleted") = True Then
                    Dim Tnew As DataRow = TLab.NewRow
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
                    TLab.Rows.Add(Tnew)
                Else

ZZ:                 Dim Tdetail As DataTable = ReadSQL("select * from TransaksiLabBayar where TransLabID='" & Trow("ID") & "'")
                    If Tdetail.Rows.Count > 0 Then
                        For Each Ttemp As DataRow In Tdetail.Rows
                            Dim Tnew As DataRow = TLab.NewRow
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
                                    Tnew("JenisKartu") = Ttemp("kartu")
                                    Tnew("JenisMesin") = Ttemp("mesin")
                                    Tnew("Debet") = Ttemp("JumlahBayar")
                                Case "CARD"
                                    Tnew("JenisPasien") = "Pasien Umum"
                                    Tnew("RecTagihan") = Ttemp("NoJenisBayar")
                                    Tnew("JenisKartu") = Ttemp("kartu")
                                    Tnew("JenisMesin") = Ttemp("mesin")
                                    Tnew("Kredit") = Ttemp("JumlahBayar")
                                Case "DISC"
                                    Tnew("Disc") = Ttemp("JumlahBayar")
                                Case "TAGIHAN"
                                    Tnew("Tagihan") = Ttemp("JumlahBayar")
                                    Tnew("JenisPasien") = Ttemp("NoJenisBayar")
                                    Tnew("RecTagihan") = ""
                            End Select
                            TLab.Rows.Add(Tnew)
                        Next

                    Else
                        Dim Tnew As DataRow = TLab.NewRow
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
                        Tnew("JenisPasien") = "?"
                        If CheckSQL("select * from TransaksiLabDetail where NamaTindakan like '%bpjs%' and TransLabID='" & Trow("ID").ToString & "'") = True Then Tnew("JenisPasien") = "BPJS" Else Tnew("JenisPasien") = "Pasien Umum"
                        Tnew("Adm") = ""
                        Tnew("transaksitime") = ""
                        TLab.Rows.Add(Tnew)
                    End If
                End If
            End If
        Next

        gridlab.DataSource = TLab

        GridView2.Columns("ID").Visible = False
        GridView2.Columns("Tgl").Visible = False
        GridView2.Columns("TotalTagihan").Visible = False
        GridView2.Columns("PoliKeterangan").Visible = False
        GridView2.Columns("TotalDisc").Visible = False
        GridView2.Columns("Pembulatan").Visible = False
        GridView2.Columns("NettBayar").Visible = False
        GridView2.Columns("Pengembalian").Visible = False
        GridView2.Columns("Adm").Visible = False
        GridView2.Columns("transaksitime").Visible = False

    End Sub

    Private Sub GigiResult()
        Dim Tbls As New DataTable
        Dim Tgigi As DataTable = CreateTable()

        Tbls = ReadSQL("select a.TransGigiID as ID,a.Nourut,a.TglGigi as Tgl,b.Nomitra,b.Nama as Pasien,a.TotalTagihan,a.TotalDisc,a.Pembulatan,a.NettBayar,a.TotalBayar,a.Pengembalian,a.deleted,a.deletedby,a.deleteddate,a.keluhan as RecTagihan from TransaksiGigi a left join MasterCustomer b on  a.IDInternet=b.nomitra  where a.deleted <> 1 and CONVERT(date, a.TglGigi) between '" & Format(dtawal.Value, "MM/dd/yyyy") & "' and '" & Format(dtakhir.Value, "MM/dd/yyyy") & "' order by a.Nourut")

        For Each Trow As DataRow In Tbls.Rows

            If IsDBNull(Trow("deleted")) = False Then
                GoTo YY
            ElseIf Trow("deleted") = True Then
                Dim Tnew As DataRow = Tgigi.NewRow
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
                Tgigi.Rows.Add(Tnew)
            Else

YY:             Dim Tdetail As DataTable = ReadSQL("select * from TransaksiGigiBayar where TransGigiID='" & Trow("ID") & "'")
                If Tdetail.Rows.Count > 0 Then
                    For Each Ttemp As DataRow In Tdetail.Rows
                        Dim Tnew As DataRow = Tgigi.NewRow
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
                        'If Strings.LCase(Ttemp("NoJenisBayar").ToString).Contains("bpjs") = False Then
                        'Tnew("JenisPasien") = "BPJS"
                        'Thasil.Rows.Add(Tnew)
                        'Else
                        Select Case Ttemp("JenisBayar")
                            Case "TUNAI"
                                Tnew("JenisPasien") = "Pasien Umum"
                                Tnew("RecTagihan") = ""
                                Tnew("Tunai") = Ttemp("JumlahBayar") - Ttemp("Kembali") + CInt(ReadSQLNIK("select isnull(sum(JumlahBayar)-sum(Kembali),0) as Tunai from TransaksiPoliBayarAwal where TransPoliID in ( select TransGigiID from TransaksiGigi where TransGigiID='" & Trow("ID").ToString.Trim & "' and CONVERT(date, TglGigi)='" & Format(dtawal.Value, "MM/dd/yyyy") & "') and TransJenis='GIGI' and JenisBayar='TUNAI'"))

                            Case "DEBET"
                                Tnew("JenisPasien") = "Pasien Umum"
                                Tnew("RecTagihan") = Ttemp("NoJenisBayar")
                                Tnew("JenisKartu") = Ttemp("kartu")
                                Tnew("JenisMesin") = Ttemp("mesin")
                                Tnew("Debet") = Ttemp("JumlahBayar")
                            Case "CARD"
                                Tnew("JenisPasien") = "Pasien Umum"
                                Tnew("RecTagihan") = Ttemp("NoJenisBayar")
                                Tnew("JenisKartu") = Ttemp("kartu")
                                Tnew("JenisMesin") = Ttemp("mesin")
                                Tnew("Kredit") = Ttemp("JumlahBayar")
                            Case "DISC"
                                Tnew("Disc") = Ttemp("JumlahBayar")
                                Tnew("Disc") = CInt(ReadSQLNIK("select isnull(sum(JumlahBayar),0) as Discount from TransaksiGigiBayar where TransGigiID in ( select TransGigiID from TransaksiGigi where TransGigiID='" & Trow("ID").ToString.Trim & "' and CONVERT(date, TglGigi)='" & Format(dtawal.Value, "MM-dd-yyyy") & "') and JenisBayar='DISC'")) + CInt(ReadSQLNIK("select isnull(sum(JumlahBayar),0) as Discount from TransaksiPoliBayarAwal where TransPoliID in ( select TransGigiID from TransaksiGigi where TransGigiID='" & Trow("ID").ToString.Trim & "' and CONVERT(date, TglGigi)='" & Format(dtawal.Value, "MM-dd-yyyy") & "') and TransJenis='GIGI' and JenisBayar='DISC'"))
                            Case "TAGIHAN"
                                Tnew("JenisPasien") = Ttemp("NoJenisBayar")
                                Tnew("RecTagihan") = ""
                                Tnew("Tagihan") = Ttemp("JumlahBayar")
                        End Select
                        Tgigi.Rows.Add(Tnew)
                        'End If
                    Next
                End If

                Tdetail = ReadSQL("select * from TransaksiPoliBayarAwal where TransPoliID='" & Trow("ID") & "' and TransJenis='Gigi'")
                If Tdetail.Rows.Count > 0 Then
                    For Each Ttemp As DataRow In Tdetail.Rows
                        Dim Tnew As DataRow = Tgigi.NewRow
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
                        'If Strings.LCase(Ttemp("NoJenisBayar").ToString).Contains("bpjs") = False Then
                        'Tnew("JenisPasien") = "BPJS"
                        'Thasil.Rows.Add(Tnew)
                        'Else
                        Select Case Ttemp("JenisBayar")
                            Case "TUNAI"
                                If CheckSQL("select * from TransaksiGigiBayar where TransGigiID='" & Trow("ID") & "' and JenisBayar='TUNAI'") = False Then
                                    Tnew("JenisPasien") = "Pasien Umum"
                                    Tnew("RecTagihan") = ""
                                    Tnew("Tunai") = Ttemp("JumlahBayar") - Ttemp("Kembali")
                                End If
                            Case "DEBET"
                                Tnew("JenisPasien") = "Pasien Umum"
                                Tnew("RecTagihan") = Ttemp("NoJenisBayar")
                                Tnew("JenisKartu") = Ttemp("kartu")
                                Tnew("JenisMesin") = Ttemp("mesin")
                                Tnew("Debet") = Ttemp("JumlahBayar")
                            Case "CARD"
                                Tnew("JenisPasien") = "Pasien Umum"
                                Tnew("RecTagihan") = Ttemp("NoJenisBayar")
                                Tnew("JenisKartu") = Ttemp("kartu")
                                Tnew("JenisMesin") = Ttemp("mesin")
                                Tnew("Kredit") = Ttemp("JumlahBayar")
                            Case "DISC"
                                Tnew("Disc") = Ttemp("JumlahBayar")
                            Case "TAGIHAN"
                                Tnew("JenisPasien") = Ttemp("NoJenisBayar")
                                Tnew("RecTagihan") = ""
                                Tnew("Tagihan") = Ttemp("JumlahBayar")
                        End Select
                        Tgigi.Rows.Add(Tnew)
                        'End If
                    Next
                End If
            End If
        Next

        gridgigi.DataSource = Tgigi

        GridView3.Columns("ID").Visible = False
        GridView3.Columns("Tgl").Visible = False
        GridView3.Columns("TotalTagihan").Visible = False
        GridView3.Columns("PoliKeterangan").Visible = False
        GridView3.Columns("TotalDisc").Visible = False
        GridView3.Columns("Pembulatan").Visible = False
        GridView3.Columns("NettBayar").Visible = False
        GridView3.Columns("Pengembalian").Visible = False
        GridView3.Columns("Adm").Visible = False
        GridView3.Columns("transaksitime").Visible = False

    End Sub

    Private Sub DllResult()
        Dim Tbls As New DataTable
        Dim Tadmin As DataTable = CreateTable()

        Tbls = ReadSQL("select a.TransAdminID as ID,'-' as  Nourut,a.TindakanTgl as Tgl,b.Nomitra,b.Nama as Pasien,a.TotalTagihan,a.TotalDisc,a.Pembulatan,a.NettBayar,a.TotalBayar,a.Pengembalian,a.deleted,a.deletedby,a.deleteddate,a.IDInternet as RecTagihan from TransaksiAdmin  a left join MasterCustomer b on  a.IDInternet=b.nomitra  where a.deleted <> 1 and a.TindakanTgl between '" & Format(dtawal.Value, "MM/dd/yyyy") & "' and '" & Format(dtakhir.Value, "MM/dd/yyyy") & "' order by a.ChangeDate,a.TransAdminID")

        For Each Trow As DataRow In Tbls.Rows
            If IsDBNull(Trow("deleted")) = False Then
                GoTo MM
            ElseIf Trow("deleted") = True Then
                Dim Tnew As DataRow = Tadmin.NewRow
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
                Tadmin.Rows.Add(Tnew)
            Else
MM:             Dim Tdetail As DataTable = ReadSQL("select * from TransaksiAdminBayar where TransAdminID='" & Trow("ID") & "'")
                If Tdetail.Rows.Count > 0 Then
                    For Each Ttemp As DataRow In Tdetail.Rows
                        Dim Tnew As DataRow = Tadmin.NewRow
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
                                Tnew("JenisKartu") = Ttemp("kartu")
                                Tnew("JenisMesin") = Ttemp("mesin")
                                Tnew("Debet") = Ttemp("JumlahBayar")
                            Case "CARD"
                                Tnew("JenisPasien") = "Pasien Umum"
                                Tnew("RecTagihan") = Ttemp("NoJenisBayar")
                                Tnew("JenisKartu") = Ttemp("kartu")
                                Tnew("JenisMesin") = Ttemp("mesin")
                                Tnew("Kredit") = Ttemp("JumlahBayar")
                            Case "DISC"
                                Tnew("Disc") = Ttemp("JumlahBayar")
                            Case "TAGIHAN"
                                Tnew("JenisPasien") = Ttemp("NoJenisBayar")
                                Tnew("RecTagihan") = ""
                                Tnew("Tagihan") = Ttemp("JumlahBayar")
                        End Select
                        Tadmin.Rows.Add(Tnew)
                    Next

                Else
                    Dim Tnew As DataRow = Tadmin.NewRow
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
                    Tadmin.Rows.Add(Tnew)
                End If
            End If
        Next


        griddll.DataSource = Tadmin

        GridView4.Columns("ID").Visible = False
        GridView4.Columns("Tgl").Visible = False
        GridView4.Columns("TotalTagihan").Visible = False
        GridView4.Columns("PoliKeterangan").Visible = False
        GridView4.Columns("TotalDisc").Visible = False
        GridView4.Columns("Pembulatan").Visible = False
        GridView4.Columns("NettBayar").Visible = False
        GridView4.Columns("Pengembalian").Visible = False
        GridView4.Columns("Adm").Visible = False
        GridView4.Columns("transaksitime").Visible = False
    End Sub

    Private Sub butprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butprint.Click
        Dim Tbls1 As DataTable = gridpoli.DataSource
        Dim Tbls2 As DataTable = gridlab.DataSource
        Dim Tbls3 As DataTable = gridgigi.DataSource
        Dim Tbls4 As DataTable = griddll.DataSource
        Dim Tbls As New DataTable
        Tbls = Tbls1.Clone

        insertRowToTbls(Tbls, "typstring", "JenisTrans")

        ConcatAll(Tbls, Tbls1, "POLI")
        ConcatAll(Tbls, Tbls2, "LAB")
        ConcatAll(Tbls, Tbls3, "GIGI")
        ConcatAll(Tbls, Tbls4, "DLL")

        Report = New XtraReport
        Report = XtraReport.FromFile(Application.StartupPath + "\reports\Keuangan\SendOmsetKeuangan.repx", True)
        Report.DataSource = Tbls
        Report.Bands.Item(BandKind.ReportHeader).Controls("lbltanggal").Text = Format(dtawal.Value, "dd-MMM-yyyy")
        Report.Bands.Item(BandKind.ReportHeader).Controls("lbladmin").Text = PoliKlinik.Lbluser.Text
        Report.Bands.Item(BandKind.ReportFooter).Controls("lbltanggalacc").Text = ".............. ," & Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:sss")
        'Report.RunDesigner()
        Report.ShowPreview()
        'Report.Print()
    End Sub

    Function ConcatAll(ByVal Ttbls1 As DataTable, ByVal Ttbls2 As DataTable, ByVal Txid As String)
        For Each Trow As DataRow In Ttbls2.Rows
            Dim Tnew As DataRow = Ttbls1.NewRow
            For i As Integer = 0 To Ttbls1.Columns.Count - 1
                If Ttbls1.Columns(i).ColumnName = "JenisTrans" Then Tnew(i) = Txid Else Tnew(i) = Trow(i)
            Next
            Ttbls1.Rows.Add(Tnew)
        Next

        Return Ttbls1
    End Function

    Private Sub Report_Monthly_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        dtawal.Value = DateSerial(DateAndTime.Now.Year, DateAndTime.Now.Month, "01")
        Dim Takhir As Date = DateAndTime.Now.AddMonths(1)
        Dim Ttemp As Date = DateSerial(Takhir.Year, Takhir.Month, "01")
        Ttemp = Ttemp.AddDays(-1)
        dtakhir.Value = DateSerial(Ttemp.Year, Ttemp.Month, Ttemp.Day)
    End Sub
End Class