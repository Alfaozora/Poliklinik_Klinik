Public Class ReportKunjungan

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

        If cmbdasar.SelectedIndex <= 0 Then
            MsgBox("Pilih kriteria Dasar.")
            Return False
        End If

        If rddetail.Checked = False And rdsummary.Checked = False Then
            MsgBox("Pilih Report Detail atau Summary")
            Return False
        End If

        Return True
    End Function

    Private Sub butdisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butdisplay.Click
        If Checking() = True Then
            Dim Tquery As String = ""
            Dim Tquery2 As String = ""
            Dim Torder As String = ""
            Dim Tjudullap As String = ""

            Select Case cmbdasar.SelectedIndex
                Case 1
                    Tjudullap = "LAPORAN KUNJUNGAN PASIEN "
                    Tquery = "select 'TAGIHAN' as JenisBayar,'BPJS' as NoJenisBayar,a.TransPoliID,a.IDInternet,f.Nama,1 as Hitung,NoJenisBayar as Result, replace(convert(NVARCHAR, a.TglPoli, 106), ' ', '/') as TglPoli " & _
                    " from TransaksiPoli a left join MasterCustomer f on a.IDInternet=f.nomitra left join TransaksiPoliBayar d on d.TransPoliID=a.TransPoliID " & _
                    " where CONVERT(date, TglPoli) between '" & Format(dtawal.Value, "MM/dd/yyyy") & "' and '" & Format(dtakhir.Value, "MM/dd/yyyy") & "' and ( PoliAnamnesa like '%BPJS%' or a.TransPoliID in " & _
                    " ( select distinct a.TransPoliID from TransaksiPoliDetail a left join TransaksiPoli b on a.TransPoliID=b.TransPoliID where CONVERT(date, b.TglPoli) between '" & Format(dtawal.Value, "MM/dd/yyyy") & "' and '" & Format(dtakhir.Value, "MM/dd/yyyy") & "' and a.NamaTindakan like '%BPJS%' AND a.DeletedDate IS NULL)) "

                    Tquery2 = "select d.JenisBayar,d.NoJenisBayar,a.TransPoliID,a.IDInternet,f.Nama,1 as Hitung,d.NoJenisBayar as Result, replace(convert(NVARCHAR, a.TglPoli, 106), ' ', '/') as TglPoli  " & _
                    " from TransaksiPoli  a left join TransaksiPoliBayarAwal d on d.TransPoliID=a.TransPoliID left join MasterCustomer f on a.IDInternet=f.nomitra " & _
                    " where CONVERT(date, a.TglPoli) between '" & Format(dtawal.Value, "MM/dd/yyyy") & "' and '" & Format(dtakhir.Value, "MM/dd/yyyy") & "' and a.TransPoliID not in " & _
                    " (select transpoliid from TransaksiPoli  where CONVERT(date, TglPoli) between '" & Format(dtawal.Value, "MM/dd/yyyy") & "' and '" & Format(dtakhir.Value, "MM/dd/yyyy") & "' and PoliAnamnesa like '%BPJS%' " & _
                    " or a.TransPoliID in ( select distinct a.TransPoliID from TransaksiPoliDetail a left join TransaksiPoli b on a.TransPoliID=b.TransPoliID where CONVERT(date, b.TglPoli) between '" & Format(dtawal.Value, "MM/dd/yyyy") & "' and '" & Format(dtakhir.Value, "MM/dd/yyyy") & "' and a.NamaTindakan like '%BPJS%' AND a.DeletedDate IS NULL)) "

                Case 2
                    Tjudullap = "LAPORAN JENIS PENYAKIT "
                    Tquery = "select 'TAGIHAN' as JenisBayar,'BPJS' as NoJenisBayar,a.TransPoliID,a.IDInternet,f.Nama,1 as Hitung,a.PoliDiagnosa as Result, replace(convert(NVARCHAR, a.TglPoli, 106), ' ', '/') as TglPoli  " & _
                        " from TransaksiPoli a left join MasterCustomer f on a.IDInternet=f.nomitra left join TransaksiPoliBayar d on d.TransPoliID=a.TransPoliID " & _
                        " where CONVERT(date, TglPoli) between '" & Format(dtawal.Value, "MM/dd/yyyy") & "' and '" & Format(dtakhir.Value, "MM/dd/yyyy") & "' and ( PoliAnamnesa like '%BPJS%' or a.TransPoliID in " & _
                        " ( select distinct a.TransPoliID from TransaksiPoliDetail a left join TransaksiPoli b on a.TransPoliID=b.TransPoliID where CONVERT(date, b.TglPoli) between '" & Format(dtawal.Value, "MM/dd/yyyy") & "' and '" & Format(dtakhir.Value, "MM/dd/yyyy") & "' and a.NamaTindakan like '%BPJS%' AND a.DeletedDate IS NULL)) "

                    Tquery2 = "select d.JenisBayar,d.NoJenisBayar,a.TransPoliID,a.IDInternet,f.Nama,1 as Hitung,a.PoliDiagnosa as Result, replace(convert(NVARCHAR, a.TglPoli, 106), ' ', '/') as TglPoli  " & _
                    " from TransaksiPoli  a left join TransaksiPoliBayarAwal d on d.TransPoliID=a.TransPoliID left join MasterCustomer f on a.IDInternet=f.nomitra " & _
                    " where CONVERT(date, a.TglPoli) between '" & Format(dtawal.Value, "MM/dd/yyyy") & "' and '" & Format(dtakhir.Value, "MM/dd/yyyy") & "' and a.TransPoliID not in " & _
                    " (select transpoliid from TransaksiPoli  where CONVERT(date, TglPoli) between '" & Format(dtawal.Value, "MM/dd/yyyy") & "' and '" & Format(dtakhir.Value, "MM/dd/yyyy") & "' and PoliAnamnesa like '%BPJS%' " & _
                    " or a.TransPoliID in ( select distinct a.TransPoliID from TransaksiPoliDetail a left join TransaksiPoli b on a.TransPoliID=b.TransPoliID where CONVERT(date, b.TglPoli) between '" & Format(dtawal.Value, "MM/dd/yyyy") & "' and '" & Format(dtakhir.Value, "MM/dd/yyyy") & "' and a.NamaTindakan like '%BPJS%' AND a.DeletedDate IS NULL)) "

                Case 3
                    Tjudullap = "LAPORAN DOKTER PEMERIKSA"
                    Tquery = "select 'TAGIHAN' as JenisBayar,'BPJS' as NoJenisBayar,a.TransPoliID,a.IDInternet,f.Nama,1 as Hitung,a.DokterPoli as Result, replace(convert(NVARCHAR, a.TglPoli, 106), ' ', '/') as TglPoli  " & _
                  " from TransaksiPoli a left join MasterCustomer f on a.IDInternet=f.nomitra left join TransaksiPoliBayar d on d.TransPoliID=a.TransPoliID " & _
                  " where CONVERT(date, TglPoli) between '" & Format(dtawal.Value, "MM/dd/yyyy") & "' and '" & Format(dtakhir.Value, "MM/dd/yyyy") & "' and ( PoliAnamnesa like '%BPJS%' or a.TransPoliID in " & _
                  " ( select distinct a.TransPoliID from TransaksiPoliDetail a left join TransaksiPoli b on a.TransPoliID=b.TransPoliID where CONVERT(date, b.TglPoli) between '" & Format(dtawal.Value, "MM/dd/yyyy") & "' and '" & Format(dtakhir.Value, "MM/dd/yyyy") & "' and a.NamaTindakan like '%BPJS%' AND a.DeletedDate IS NULL)) "

                    Tquery2 = "select d.JenisBayar,d.NoJenisBayar,a.TransPoliID,a.IDInternet,f.Nama,1 as Hitung,a.DokterPoli as Result, replace(convert(NVARCHAR, a.TglPoli, 106), ' ', '/') as TglPoli " & _
                    " from TransaksiPoli  a left join TransaksiPoliBayarAwal d on d.TransPoliID=a.TransPoliID left join MasterCustomer f on a.IDInternet=f.nomitra " & _
                    " where CONVERT(date, a.TglPoli) between '" & Format(dtawal.Value, "MM/dd/yyyy") & "' and '" & Format(dtakhir.Value, "MM/dd/yyyy") & "' and a.TransPoliID not in " & _
                    " (select transpoliid from TransaksiPoli  where CONVERT(date, TglPoli) between '" & Format(dtawal.Value, "MM/dd/yyyy") & "' and '" & Format(dtakhir.Value, "MM/dd/yyyy") & "' and PoliAnamnesa like '%BPJS%' " & _
                    " or a.TransPoliID in ( select distinct a.TransPoliID from TransaksiPoliDetail a left join TransaksiPoli b on a.TransPoliID=b.TransPoliID where CONVERT(date, b.TglPoli) between '" & Format(dtawal.Value, "MM/dd/yyyy") & "' and '" & Format(dtakhir.Value, "MM/dd/yyyy") & "' and a.NamaTindakan like '%BPJS%' AND a.DeletedDate IS NULL)) "

                Case 4
                    Tjudullap = "LAPORAN PERAWAT PEMERIKSA"
                    Tquery = "select 'TAGIHAN' as JenisBayar,'BPJS' as NoJenisBayar,a.TransPoliID,a.IDInternet,f.Nama,1 as Hitung,a.PerawatPoli as Result, replace(convert(NVARCHAR, a.TglPoli, 106), ' ', '/') as TglPoli " & _
                  " from TransaksiPoli a left join MasterCustomer f on a.IDInternet=f.nomitra left join TransaksiPoliBayar d on d.TransPoliID=a.TransPoliID " & _
                  " where CONVERT(date, TglPoli) between '" & Format(dtawal.Value, "MM/dd/yyyy") & "' and '" & Format(dtakhir.Value, "MM/dd/yyyy") & "' and ( PoliAnamnesa like '%BPJS%' or a.TransPoliID in " & _
                  " ( select distinct a.TransPoliID from TransaksiPoliDetail a left join TransaksiPoli b on a.TransPoliID=b.TransPoliID where CONVERT(date, b.TglPoli) between '" & Format(dtawal.Value, "MM/dd/yyyy") & "' and '" & Format(dtakhir.Value, "MM/dd/yyyy") & "' and a.NamaTindakan like '%BPJS%' AND a.DeletedDate IS NULL)) "

                    Tquery2 = "select d.JenisBayar,d.NoJenisBayar,a.TransPoliID,a.IDInternet,f.Nama,1 as Hitung,a.PerawatPoli as Result, replace(convert(NVARCHAR, a.TglPoli, 106), ' ', '/') as TglPoli  " & _
                    " from TransaksiPoli  a left join TransaksiPoliBayarAwal d on d.TransPoliID=a.TransPoliID left join MasterCustomer f on a.IDInternet=f.nomitra " & _
                    " where CONVERT(date, a.TglPoli) between '" & Format(dtawal.Value, "MM/dd/yyyy") & "' and '" & Format(dtakhir.Value, "MM/dd/yyyy") & "' and a.TransPoliID not in " & _
                    " (select transpoliid from TransaksiPoli  where CONVERT(date, TglPoli) between '" & Format(dtawal.Value, "MM/dd/yyyy") & "' and '" & Format(dtakhir.Value, "MM/dd/yyyy") & "' and PoliAnamnesa like '%BPJS%' " & _
                    " or a.TransPoliID in ( select distinct a.TransPoliID from TransaksiPoliDetail a left join TransaksiPoli b on a.TransPoliID=b.TransPoliID where CONVERT(date, b.TglPoli) between '" & Format(dtawal.Value, "MM/dd/yyyy") & "' and '" & Format(dtakhir.Value, "MM/dd/yyyy") & "' and a.NamaTindakan like '%BPJS%' AND a.DeletedDate IS NULL)) "

            End Select

            Torder = ""
            Dim Thasil As New DataTable
            Dim Tbls As New DataTable
            Dim Tbls2 As New DataTable

            If rdpasienall.Checked = True Then
                Thasil = ReadSQL(Tquery2)
                Tbls2 = ReadSQL(Tquery)
                Thasil = Concat(Thasil, Tbls2)

                If cmbdasar.SelectedIndex = 1 Then
                    For Each Trow As DataRow In Thasil.Rows
                        If IsDBNull(Trow("JenisBayar")) = True Then
                            Trow("Result") = "Pasien Umum"
                        Else
                            If Trow("JenisBayar") = "DEBET" Or Trow("JenisBayar") = "TUNAI" Then
                                Trow("Result") = "Pasien Umum"
                            ElseIf Trow("JenisBayar") = "TAGIHAN" Then
                                If Trow("NoJenisBayar").ToString.Contains("-") = True Then
                                    Dim Tsplit() As String = Trow("NoJenisBayar").ToString.Split("-")
                                    Trow("Result") = Tsplit(0).ToString
                                Else
                                    Trow("Result") = Trow("NoJenisBayar")
                                End If
                            Else
                                Trow("Result") = "-"
                            End If
                        End If
                    Next
                End If

            ElseIf rdpasienumum.Checked = True Then
                Thasil = ReadSQL(Tquery2 & " and ( d.JenisBayar='TUNAI' or d.JenisBayar='DEBET' or d.JenisBayar is null )")

                If cmbdasar.SelectedIndex = 1 Then
                    For Each Trow As DataRow In Thasil.Rows
                        If IsDBNull(Trow("JenisBayar")) = True Then
                            Trow("Result") = "Pasien Umum"
                        Else
                            If Trow("JenisBayar") = "DEBET" Or Trow("JenisBayar") = "TUNAI" Then
                                Trow("Result") = "Pasien Umum"
                            ElseIf Trow("JenisBayar") = "TAGIHAN" Then
                                If Trow("NoJenisBayar").ToString.Contains("-") = True Then
                                    Dim Tsplit() As String = Trow("NoJenisBayar").ToString.Split("-")
                                    Trow("Result") = Tsplit(0).ToString
                                Else
                                    Trow("Result") = Trow("NoJenisBayar")
                                End If
                            Else
                                Trow("Result") = "-"
                            End If
                        End If
                    Next
                End If

            ElseIf rdtagihan.Checked = True Then
                Thasil = ReadSQL(Tquery2 & " and d.JenisBayar='TAGIHAN'")

                If cmbdasar.SelectedIndex = 1 Then
                    For Each Trow As DataRow In Thasil.Rows
                        If IsDBNull(Trow("JenisBayar")) = True Then
                            Trow("Result") = "Pasien Umum"
                        Else
                            If Trow("JenisBayar") = "DEBET" Or Trow("JenisBayar") = "TUNAI" Then
                                Trow("Result") = "Pasien Umum"
                            ElseIf Trow("JenisBayar") = "TAGIHAN" Then
                                If Trow("NoJenisBayar").ToString.Contains("-") = True Then
                                    Dim Tsplit() As String = Trow("NoJenisBayar").ToString.Split("-")
                                    Trow("Result") = Tsplit(0).ToString
                                Else
                                    Trow("Result") = Trow("NoJenisBayar")
                                End If
                            Else
                                Trow("Result") = "-"
                            End If
                        End If
                    Next
                End If

            ElseIf rdpasienbpjs.Checked = True Then
                Thasil = ReadSQL(Tquery)
            End If

            If rddetail.Checked = True Then
                Tjudullap = Tjudullap + " DETAIL "
                Report = New XtraReport
                Report = XtraReport.FromFile(Application.StartupPath + "\reports\LapKunjunganDetail.repx", True)
            ElseIf rdsummary.Checked = True Then
                Tjudullap = Tjudullap + " SUMMARY "
                Report = New XtraReport
                Report = XtraReport.FromFile(Application.StartupPath + "\reports\LapKunjungan.repx", True)
            End If

            Report.Bands.Item(BandKind.PageHeader).Controls("txjudul").Text = Tjudullap
            Report.Bands.Item(BandKind.PageHeader).Controls("rangetanggal").Text = "Range Tanggal : " & Format(dtawal.Value, "dd-MMM-yyyy") & "-" & Format(dtakhir.Value, "dd-MMM-yyyy")
            Report.Bands.Item(BandKind.PageHeader).Controls("txket").Text = cmbdasar.Text

            Report.DataSource = Thasil
            'Report.RunDesigner()
            Report.ShowPreview()
            'Report.Print()

            GridControl1.DataSource = Thasil
            DataGridView1.DataSource = Thasil
        End If
    End Sub

    Function Concat(ByVal Temp1 As DataTable, ByVal Temp2 As DataTable) As DataTable
        For Each Trow As DataRow In Temp2.Rows
            Dim Rrow As DataRow = Temp1.NewRow
            For i As Integer = 0 To Temp1.Columns.Count - 1
                Rrow(i) = Trow(i)
            Next
            Temp1.Rows.Add(Rrow)
        Next

        Return Temp1
    End Function

End Class