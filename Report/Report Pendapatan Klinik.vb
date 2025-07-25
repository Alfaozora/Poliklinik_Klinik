Public Class Report_Pendapatan_Klinik

    Dim Tjudul As String = ""
    Dim Theader As String = ""
    Dim Thasil As DataTable

    Private Sub CreateTable()
        Thasil = ReadSQL("select a.TransPoliID as ID,a.Nourut,a.TglPoli as Tgl,b.Nomitra,b.Nama as Pasien,a.TotalTagihan,a.TotalDisc,a.Pembulatan,a.NettBayar,a.TotalBayar,a.Pengembalian,a.PoliKeterangan from TransaksiPoli a left join MasterCustomer b on  a.IDInternet=b.nomitra  where CONVERT(date, TglPoli) between '8/15/2016' and GETDATE() and TransPoliID=''")

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

    End Sub

    Public Sub ClearData()
        InsertNewItemComboSQL("select distinct UserNama from Users", cmbkasir)
        txkasirid.Text = PoliKlinik.Lbluser.Text
        cmbkasir.Text = ReadSQLNIK("select UserNama from Users where UserId='" & txkasirid.Text & "'")
        dtkasirawal.Value = Format(DateAndTime.Now, "dd-MMM-yyyy 00:00:00")
        dtkasirakhir.Value = Format(DateAndTime.Now, "dd-MMM-yyyy 23:59:59")

        Select Case txjenis.Text
            Case "KLINIK"
                Tjudul = "LAPORAN SETORAN UANG KLINIK UMUM"
                Theader = "Report Pendapatan Klinik Umum"
            Case "GIGI"
                Tjudul = "LAPORAN SETORAN UANG KLINIK GIGI"
                Theader = "Report Pendapatan Klinik Gigi"
            Case "LAB"
                Tjudul = "LAPORAN SETORAN UANG LABORATORIUM"
                Theader = "Report Pendapatan Laboratorium"
            Case "ADMIN"
                Tjudul = "LAPORAN SETORAN UANG ADMINISTRASI"
                Theader = "Report Pendapatan Administrasi"

        End Select
        Me.Text = Tjudul
        lbllap.Text = Tjudul

        CreateTable()
    End Sub

    Private Sub Report_Pendapatan_Klinik_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        ClearData()
    End Sub

    Private Sub butdisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butdisplay.Click
        Dim Tbls As New DataTable
        CreateTable()
        Select Case txjenis.Text
            Case "KLINIK"
                Tbls = ReadSQL("select a.TransPoliID as ID,a.Nourut,a.TglPoli as Tgl,b.Nomitra,b.Nama as Pasien,a.TotalTagihan,a.TotalDisc,a.Pembulatan,a.NettBayar,a.TotalBayar,a.Pengembalian,a.deleted,a.deletedby,a.deleteddate,a.PoliKeterangan as RecTagihan from TransaksiPoli a left join MasterCustomer b on  a.IDInternet=b.nomitra  where CONVERT(date, a.TglPoli) between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "' order by a.Nourut")

                For Each Trow As DataRow In Tbls.Rows

                    If IsDBNull(Trow("deleted")) = False Then
                        GoTo XX
                    ElseIf Trow("deleted") = True Then
                        Dim Tnew As DataRow = Thasil.NewRow
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
                        Thasil.Rows.Add(Tnew)
                    Else

XX:                     Dim Tdetail As DataTable = ReadSQL("select * from TransaksiPoliBayar where TransPoliID='" & Trow("ID") & "'")
                        If Tdetail.Rows.Count > 0 Then
                            For Each Ttemp As DataRow In Tdetail.Rows
                                Dim Tnew As DataRow = Thasil.NewRow
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
                                Thasil.Rows.Add(Tnew)
                            Next
                        End If


                        Tdetail = ReadSQL("select * from TransaksiPoliBayarAwal where TransPoliID='" & Trow("ID") & "' and TransJenis='POLI'")
                        If Tdetail.Rows.Count > 0 Then
                            For Each Ttemp As DataRow In Tdetail.Rows
                                Dim Tnew As DataRow = Thasil.NewRow
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
                                    'Case "TUNAI"
                                    '    Tnew("JenisPasien") = "Pasien Umum"
                                    '    Tnew("RecTagihan") = ""
                                    '    Tnew("Tunai") = Ttemp("JumlahBayar") - Ttemp("Kembali")
                                    'Tnew("Tunai") = CInt(ReadSQLNIK("select isnull(sum(JumlahBayar)-sum(Kembali),0) as Tunai from TransaksiAdminBayar where TransAdminID in (select TransAdminID  from TransaksiAdmin where TransAdminID='" & Trow("ID").ToString.Trim & "' and TindakanTgl between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "') and JenisBayar='TUNAI'"))
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
                                Thasil.Rows.Add(Tnew)
                            Next
                        End If
                    End If
                Next

            Case "LAB"
                Tbls = ReadSQL("select a.TransLabID as ID,a.Nourut,a.TglLab as Tgl,b.Nomitra,b.Nama as Pasien,a.TotalTagihan,a.TotalDisc,a.Pembulatan,a.NettBayar,a.TotalBayar,a.Pengembalian,a.deleted,a.deletedby,a.deleteddate,a.CaraAmbil as RecTagihan from TransaksiLab a left join MasterCustomer b on  a.IDInternet=b.nomitra  where CONVERT(date, a.TglLab) between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "' order by a.Nourut")

                For Each Trow As DataRow In Tbls.Rows
                    If IsDBNull(Trow("deleted")) = False Then
                        GoTo YY
                    ElseIf Trow("deleted") = True Then
                        Dim Tnew As DataRow = Thasil.NewRow
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
                        Thasil.Rows.Add(Tnew)
                    Else
YY:                     Dim Tdetail As DataTable = ReadSQL("select * from TransaksiLabBayar where TransLabID='" & Trow("ID") & "'")
                        If Tdetail.Rows.Count > 0 Then
                            For Each Ttemp As DataRow In Tdetail.Rows
                                Dim Tnew As DataRow = Thasil.NewRow
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
                                Thasil.Rows.Add(Tnew)
                            Next

                        Else
                            Dim Tnew As DataRow = Thasil.NewRow
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
                            Thasil.Rows.Add(Tnew)
                        End If
                    End If
                Next

            Case "GIGI"
                Tbls = ReadSQL("select a.TransGigiID as ID,a.Nourut,a.TglGigi as Tgl,b.Nomitra,b.Nama as Pasien,a.TotalTagihan,a.TotalDisc,a.Pembulatan,a.NettBayar,a.TotalBayar,a.Pengembalian,a.deleted,a.deletedby,a.deleteddate,a.keluhan as RecTagihan from TransaksiGigi a left join MasterCustomer b on  a.IDInternet=b.nomitra  where CONVERT(date, a.TglGigi) between '" & Format(dtkasirawal.Value, "MM/dd/yyyy") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy") & "' order by a.Nourut")

                For Each Trow As DataRow In Tbls.Rows
                    If IsDBNull(Trow("deleted")) = False Then
                        GoTo ZZ
                    ElseIf Trow("deleted") = True Then
                        Dim Tnew As DataRow = Thasil.NewRow
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
                        Thasil.Rows.Add(Tnew)
                    Else
ZZ:                     Dim Tdetail As DataTable = ReadSQL("select * from TransaksiGigiBayar where TransGigiID='" & Trow("ID") & "'")
                        If Tdetail.Rows.Count > 0 Then
                            For Each Ttemp As DataRow In Tdetail.Rows
                                Dim Tnew As DataRow = Thasil.NewRow
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
                                        Tnew("Tagihan") = Ttemp("JumlahBayar")
                                End Select
                                Thasil.Rows.Add(Tnew)
                            Next
                        Else
                            Dim Tnew As DataRow = Thasil.NewRow
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
                            If CheckSQL("select * from TransaksiGigiDetail where DeletedDate IS NULL AND NamaTindakan like '%bpjs%' and TransGigiID='" & Trow("ID").ToString & "'") = True Then Tnew("JenisPasien") = "BPJS" Else Tnew("JenisPasien") = "Pasien Umum"
                            Tnew("Adm") = ""
                            Tnew("transaksitime") = ""
                            Thasil.Rows.Add(Tnew)
                        End If

                        Tdetail = ReadSQL("select * from TransaksiPoliBayarAwal where TransPoliID='" & Trow("ID") & "' and TransJenis='GIGI'")
                        If Tdetail.Rows.Count > 0 Then
                            For Each Ttemp As DataRow In Tdetail.Rows
                                Dim Tnew As DataRow = Thasil.NewRow
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
                                Thasil.Rows.Add(Tnew)
                            Next
                        End If
                    End If
                Next

            Case "ADMIN"
                Tbls = ReadSQL("select a.TransAdminID as ID,'-' as  Nourut,a.TindakanTgl as Tgl,b.Nomitra,b.Nama as Pasien,a.TotalTagihan,a.TotalDisc,a.Pembulatan,a.NettBayar,a.TotalBayar,a.Pengembalian,a.deleted,a.deletedby,a.deleteddate,a.IDInternet as RecTagihan from TransaksiAdmin  a left join MasterCustomer b on  a.IDInternet=b.nomitra  where a.TindakanTgl between '" & Format(dtkasirawal.Value, "MM/dd/yyyy 00:00:00") & "' and '" & Format(dtkasirakhir.Value, "MM/dd/yyyy 23:59:59") & "' order by a.ChangeDate,a.TransAdminID")

                For Each Trow As DataRow In Tbls.Rows
                    If IsDBNull(Trow("deleted")) = False Then
                        GoTo MM
                    ElseIf Trow("deleted") = True Then
                        Dim Tnew As DataRow = Thasil.NewRow
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
                        Thasil.Rows.Add(Tnew)
                    Else
MM:                     Dim Tdetail As DataTable = ReadSQL("select * from TransaksiAdminBayar where TransAdminID='" & Trow("ID") & "'")
                        If Tdetail.Rows.Count > 0 Then
                            For Each Ttemp As DataRow In Tdetail.Rows
                                Dim Tnew As DataRow = Thasil.NewRow
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
                                Thasil.Rows.Add(Tnew)
                            Next

                        Else
                            Dim Tnew As DataRow = Thasil.NewRow
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
                            Thasil.Rows.Add(Tnew)
                        End If
                    End If
                Next
        End Select

        Report = New XtraReport
        Report = XtraReport.FromFile(Application.StartupPath + "\reports\LapPenerimaanUang.repx", True)
        Report.DataSource = Thasil
        Report.Bands.Item(BandKind.ReportHeader).Controls("lbltanggal").Text = Format(dtkasirawal.Value, "dd-MMM-yyyy HH:mm") & " - " & Format(dtkasirakhir.Value, "dd-MMM-yyyy HH:mm")
        Report.Bands.Item(BandKind.ReportHeader).Controls("lbladmin").Text = txkasirid.Text
        Report.Bands.Item(BandKind.ReportFooter).Controls("lbltanggalacc").Text = ".............. ," & Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:sss")
        Report.Bands.Item(BandKind.ReportHeader).Controls("lbljenissetoran").Text = Tjudul
        'Report.RunDesigner()
        Report.ShowPreview()
        'Report.Print()

    End Sub

    Private Sub cmbkasir_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbkasir.SelectedIndexChanged
        If cmbkasir.FindStringExact(cmbkasir.Text) >= 0 Then
            txkasirid.Text = ReadSQLNIK("select UserId from Users where UserNama='" & cmbkasir.Text & "'")
        End If
    End Sub
End Class