Imports System.Drawing
Imports System.Text


Public Class ReportSummaryMCU

    Dim Tstr As String = ""
    Dim thread As System.Threading.Thread

    Public Sub LoadLab(ByRef Tid As String)
        If rdmcu.Checked = False And rdlain.Checked = False Then
            MsgBox("Pilih salah satu Report yang akan ditampilkan. Hasil MCU atau Hasil Lain ( ECG,Fisik,dll)")
        End If

    End Sub

    Public Sub LoadPasien(ByRef Trow() As DataRow)
        If Trow.Length = 0 Then
            SetClear()
        Else
            Tstr = ""
            Dim Ttemp As String = "("
            For i As Integer = 0 To Trow.Length - 1
                Ttemp = Ttemp & "'" & Trow(i)("NoUrut").ToString.Trim & "',"
            Next
            Tstr = Strings.Left(Ttemp, Ttemp.Length - 1) & ")"

            ' Set Nama Perusahaan
            Dim namaPerusahaan As String = ""
            If TextBoxNamaPerusahaan.Text <> "" Then namaPerusahaan = " AND (c.NoJenisBayar = '" & TextBoxNamaPerusahaan.Text & "')"

            Dim queryBuilder As New StringBuilder()
            queryBuilder.AppendLine("SELECT a.NoUrut, a.TglLab, b.NoRekamMedis, b.Nama, CONVERT(varchar, b.TglLahir, 106) AS TglLahir, b.DomisiliAlamat, b.JenisKelamin, b.NoNIK")
            queryBuilder.AppendLine("FROM TransaksiLab a")
            queryBuilder.AppendLine("     LEFT JOIN MasterPasien b ON a.IDInternet = b.NoRekamMedis")
            queryBuilder.AppendLine("     LEFT JOIN TransaksiLabBayar c ON a.TransLabID = c.TransLabID")
            queryBuilder.AppendLine("WHERE CONVERT(date, a.TglLab) = '" & TextBoxTglTransaksi.Text & "' " & namaPerusahaan & " AND a.Nourut IN " & Tstr & "")

            Dim Tbls As DataTable = ReadSQL(queryBuilder.ToString())
            gridpasien.DataSource = Tbls

            LoadLab(Tstr)
        End If
    End Sub

    Private Sub SetClear()
        Dim queryBuilder As New StringBuilder()
        queryBuilder.AppendLine("SELECT a.NoUrut, a.TglLab, b.NoRekamMedis, b.Nama, b.TglLahir, b.DomisiliAlamat")
        queryBuilder.AppendLine("FROM TransaksiLab a")
        queryBuilder.AppendLine("     LEFT JOIN MasterPasien b ON a.IDInternet = b.NoRekamMedis")
        queryBuilder.AppendLine("WHERE a.Status = ''")

        Dim Tbls As DataTable = ReadSQL(queryBuilder.ToString())
        gridpasien.DataSource = Tbls

        LoadLab(Tstr)

        rdmcu.Checked = False
        rdlain.Checked = False

        TextBoxTglTransaksi.ResetText()
        TextBoxNamaPerusahaan.ResetText()
        txcompany.Text = ""
        txlbltanggal.Text = ""
    End Sub

    Private Sub CloseToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub ReportSummaryMCU_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        SetFormHeightWeight(Me, 0.95, 0.8)
        NewToolStripMenuItem1.PerformClick()
        Control.CheckForIllegalCrossThreadCalls = False
    End Sub

    Private Sub NewToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem1.Click
        SetClear()
    End Sub

    Private Sub TambahPasienToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TambahPasienToolStripMenuItem.Click
        If TextBoxTglTransaksi.Text = "" Then
            MsgBox("Pilih Tanggal Terlebih Dahulu.")
            Exit Sub
        End If

        ' Set Nama Perusahaan
        Dim namaPerusahaan As String = ""
        If TextBoxNamaPerusahaan.Text <> "" Then namaPerusahaan = " AND (c.NoJenisBayar = '" & TextBoxNamaPerusahaan.Text & "')"

        Dim queryBuilder As New StringBuilder()

        queryBuilder.AppendLine("SELECT a.NoUrut, a.TglLab, b.NoRekamMedis, b.Nama, b.TglLahir, b.DomisiliAlamat")
        queryBuilder.AppendLine("FROM TransaksiLab a")
        queryBuilder.AppendLine("     LEFT JOIN MasterPasien b ON a.idinternet = b.NoRekamMedis")
        queryBuilder.AppendLine("     LEFT JOIN TransaksiLabBayar c ON a.TransLabID = c.TransLabID")
        queryBuilder.AppendLine("WHERE CONVERT(date, a.tgllab) = '" & TextBoxTglTransaksi.Text & "' " & namaPerusahaan & " AND a.Status <> 'OPEN' AND a.SendKeu IS NOT NULL AND a.deleted = 0")
        queryBuilder.AppendLine("ORDER BY a.nourut DESC")

        FindMultiple.Show()
        FindMultiple.Query(queryBuilder.ToString(), "", "ReportMCU", 2)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Tstr = ""
        Dim Ttemp As String = "("
        Dim TtempTindakanID As String = "("
        Dim Ttempnourut As String = "("
        Dim NewTranslabid As String = ""
        Dim TotalTindakan As Integer = 0
        Dim TtempDetailPemeriksaan As String = ""
        Dim ArrayTindakan(5000) As String
        Dim Tnik As DataTable = gridpasien.DataSource

        If Tnik.Rows.Count <= 0 Then
            MsgBox("Pilih dahulu pasien yang akan di rekap summary-nya")
            Exit Sub
        End If

        If rdlain.Checked = False And rdmcu.Checked = False Then
            MsgBox("Pilih salah satu laporan summary yang dikeluarkan")
            Exit Sub
        End If

        Tnik.AcceptChanges()
        For Each Trow As DataRow In Tnik.Rows
            Ttemp = Ttemp & "'" & Trow("NoUrut").ToString.Trim & "',"
        Next
        Tstr = Strings.Left(Ttemp, Ttemp.Length - 1) & ")"

        ' Set Nama Perusahaan
        Dim namaPerusahaan As String = ""
        If TextBoxNamaPerusahaan.Text <> "" Then namaPerusahaan = " AND (c.NoJenisBayar = '" & TextBoxNamaPerusahaan.Text & "')"

        Dim queryBuilder As New StringBuilder()
        queryBuilder.AppendLine("SELECT a.NoUrut, a.TglLab, b.NoRekamMedis, b.Nama, CONVERT(varchar, b.TglLahir, 106) AS TglLahir, b.DomisiliAlamat, b.JenisKelamin, b.NoNIK")
        queryBuilder.AppendLine("FROM transaksilab a")
        queryBuilder.AppendLine("     LEFT JOIN MasterPasien b ON a.idinternet = b.NoRekamMedis")
        queryBuilder.AppendLine("     LEFT JOIN TransaksiLabBayar c ON a.TransLabID = c.TransLabID")
        queryBuilder.AppendLine("WHERE CONVERT(date, a.tgllab) = '" & TextBoxTglTransaksi.Text & "' " & namaPerusahaan & " AND a.Nourut IN " & Tstr & "")

        Dim Tbls As New DataTable
        Tbls = ReadSQL(queryBuilder.ToString())

        Dim Ttindakan As DataTable = gridtest.DataSource
        If Ttindakan.Rows.Count <= 0 Then
            MsgBox("Pilih jenis tindakan yang akan ditampilkan")
            Exit Sub
        End If

        Dim keyTindakan As Boolean = False
        Ttindakan.AcceptChanges()
        Dim Rtindakan() As DataRow = Ttindakan.Select("Checked=True")
        For j As Integer = 0 To Rtindakan.Length - 1 Step 1
            If TtempTindakanID.Contains("'" & Rtindakan(j)("TindakanID").ToString.Trim & "'") = False Then
                TtempTindakanID = TtempTindakanID & "'" & Rtindakan(j)("TindakanID").ToString.Trim & "',"
            End If
            TtempDetailPemeriksaan = TtempDetailPemeriksaan & "" & Rtindakan(j)("NoUrut").ToString.Trim & ", "
            TotalTindakan = TotalTindakan + 1
            keyTindakan = True
            insertRowToTbls(Tbls, "Typstring", Rtindakan(j)("TindakanID").ToString & "/" & Rtindakan(j)("NoUrut").ToString)
        Next
        TtempTindakanID = Strings.Left(TtempTindakanID, TtempTindakanID.Length - 1) & ")"
        TtempDetailPemeriksaan = Strings.Left(TtempDetailPemeriksaan, TtempDetailPemeriksaan.Length - 2)

        For Each Tnourut As DataRow In Tbls.Rows
            If Ttempnourut.Contains("'" & Tnourut("NoUrut").ToString.Trim & "'") = False Then
                Ttempnourut = Ttempnourut & "'" & Tnourut("NoUrut").ToString.Trim & "',"
            End If
        Next
        Ttempnourut = Strings.Left(Ttempnourut, Ttempnourut.Length - 1) & ")"

        If keyTindakan = False Then
            MsgBox("Pilih Tindakan Terlebih Dahulu")
            Exit Sub
        End If

        Dim key As Boolean = False
        Dim Saran As String = ""
        Dim Kesimpulan As String = ""

        'Dim TotalTindakan As Integer = 0
        'Dim TtempDetailPemeriksaan As String = ""
        'Ttindakan.AcceptChanges()
        'Dim Rtindakan() As DataRow = Ttindakan.Select("Checked=True")
        'For j As Integer = 0 To Rtindakan.Length - 1 Step 1
        'insertRowToTbls(Tbls, "Typstring", Rtindakan(j)("TindakanID").ToString & "/" & Rtindakan(j)("NoUrut").ToString)
        'TtempDetailPemeriksaan = TtempDetailPemeriksaan & "" & Rtindakan(j)("NoUrut").ToString.Trim & ", "
        'TotalTindakan = TotalTindakan + 1
        'Next
        'TtempDetailPemeriksaan = Strings.Left(TtempDetailPemeriksaan, TtempDetailPemeriksaan.Length - 2)

        If rdmcu.Checked = True Then
            'start column 6 diisi hasilnya 
            'For Each Thasil As DataRow In Tbls.Rows
            '    For j As Integer = 8 To Tbls.Columns.Count - 1 Step 1
            '        Dim Tidx() As String = Tbls.Columns(j).ColumnName.ToString.Split("/")
            '        If Tidx(0) = "1000" Then
            '            Thasil(j) = ReadSQLNIK("select Kesimpulan from TransaksiLab where NoUrut = '" & Thasil("NoUrut").ToString & "'")
            '        ElseIf Tidx(0) = "1001" Then
            '            Thasil(j) = ReadSQLNIK("select Saran from TransaksiLab where NoUrut = '" & Thasil("NoUrut").ToString & "'")
            '        Else
            '            Thasil(j) = ReadSQLNIK("select isnull(Result,'') from TransaksiLabResult a left join TransaksiLabDetail b on b.TransLabIDDetail=a.TransLabIDDetail and b.TindakanID=a.TindakanID where b.TransLabID in (select TranslabID from TransaksiLab where NoUrut='" & Thasil("NoUrut").ToString & "') and a.TindakanID='" & Tidx(0) & "' and a.NoUrut='" & Tidx(1) & "' ")
            '        End If
            '    Next
            'Next

            'For j As Integer = 8 To Tbls.Columns.Count - 1 Step 1
            '    Dim Tcol As DataColumn = Tbls.Columns(j)
            '    Dim Txid() As String = Tcol.ColumnName.ToString.Split("/")
            '    If Txid(0) = "1000" Then
            '        Tcol.ColumnName = "Hasil"
            '    ElseIf Txid(0) = "1001" Then
            '        Tcol.ColumnName = "Keterangan"
            '    Else
            '        Tcol.ColumnName = ReadSQLNIK("select DetailKet from MasterLabDetail where TindakanID='" & Txid(0) & "' and NoUrut='" & Txid(1) & "'")
            '    End If
            'Next

            'GridView3.Columns.Clear()
            'gridresult.DataSource = Tbls

            'Dim TblsN As DataTable = ReadSQL("SELECT case when a.result <> '' then a.result ELSE '-' END AS 'result', a.nourut, a.tindakanid, b.TransLabID from transaksilabresult a left join transaksilabdetail b on b.TransLabIDDetail=a.TransLabIDDetail and b.TindakanID=a.TindakanID where b.TransLabID IN (SELECT TransLabID FROM transaksilab WHERE a.tindakanid in " & TtempTindakanID & " and NoUrut in " & Ttempnourut & ")")
            Dim TblsN As DataTable = ReadSQL("SELECT case when a.result <> '' then a.result ELSE '-' END AS 'result', a.nourut, a.tindakanid, b.TransLabID, c.NoUrut as 'NoUrutDetail' from transaksilabresult a left join transaksilabdetail b on b.TransLabIDDetail=a.TransLabIDDetail and b.TindakanID=a.TindakanID left join TransaksiLab c on b.TransLabID=c.TransLabID where a.tindakanid in " & TtempTindakanID & " and c.NoUrut in " & Ttempnourut & "")
            Dim tempidlabinternet As String = 0

            For Each TrowN As DataRow In TblsN.Rows
                For Each Thasil As DataRow In Tbls.Rows
                    'NewTranslabid = 
                    If TrowN("NoUrutDetail") = Thasil("NoUrut") Then
                        For j As Integer = 8 To Tbls.Columns.Count - 1 Step 1
                            Dim Tidx() As String = Tbls.Columns(j).ColumnName.ToString.Split("/")

                            If TrowN("tindakanid") = Tidx(0) And TrowN("nourut") = Tidx(1) Then
                                Thasil(j) = TrowN("result")
                            ElseIf (Tidx(0) = "1000" Or Tidx(0) = "1001") Then
                                If (Tidx(0) = "1000" Or Tidx(0) = "1001") And tempidlabinternet <> TrowN("NoUrutDetail") Then
                                    Dim TempSaranKeterangan As DataTable = ReadSQL("select Kesimpulan, Saran from transaksilab where nourut = '" & Thasil("nourut").ToString & "' and NoUrut='" & Thasil("NoUrut").ToString & "'")
                                    For Each Trow As DataRow In TempSaranKeterangan.Rows
                                        If IsDBNull(Trow("Saran")) = True Then Trow("Saran") = "-"
                                        If IsDBNull(Trow("Kesimpulan")) = True Then Trow("Kesimpulan") = "-"
                                        Saran = Trow("Saran")
                                        Kesimpulan = Trow("Kesimpulan")
                                    Next
                                    tempidlabinternet = TrowN("NoUrutDetail")
                                End If

                                If Tidx(0) = "1000" Then
                                    Thasil(j) = Kesimpulan
                                ElseIf Tidx(0) = "1001" Then
                                    Thasil(j) = Saran
                                End If
                            End If
                        Next
                    End If
                Next
            Next

            For j As Integer = 8 To Tbls.Columns.Count - 1 Step 1
                Dim Tcol As DataColumn = Tbls.Columns(j)
                Dim Txid() As String = Tcol.ColumnName.ToString.Split("/")
                If Txid(0) = "1000" Then
                    Tcol.ColumnName = "Hasil"
                ElseIf Txid(0) = "1001" Then
                    Tcol.ColumnName = "Keterangan"
                Else
                    'Dim Tstr As String = ReadThemysqlNIK("select DetailKet from masterlabdetail where TindakanID='" & Txid(0) & "' and NoUrut='" & Txid(1) & "'", Ttcon)
                    Dim Tstr As String = ReadSQLNIK("select DetailKet from MasterLabDetail where TindakanID='" & Txid(0) & "' and NoUrut='" & Txid(1) & "'")
                    For i As Integer = 8 To j - 1 Step 1
                        If Tbls.Columns(i).ColumnName = Tstr Then
                            Tstr = Tstr & " "
                        End If
                    Next
                    Tcol.ColumnName = Tstr
                End If
            Next

            GridView3.Columns.Clear()
            gridresult.DataSource = Tbls
            MsgBox("Done")

        ElseIf rdlain.Checked = True Then
            Dim berat As String = ""
            Dim tinggi As String = ""
            'start column 6 diisi hasilnya 
            For Each Thasil As DataRow In Tbls.Rows
                Dim TblsN As DataTable = ReadSQL("select FisikNoUrut, Result, fisikket from transaksilabfisik where NoUrut='" & Thasil("NoUrut").ToString & "' and FisikNoUrut in (" & TtempDetailPemeriksaan & ")")
                For Each TArrayTindakan As DataRow In TblsN.Rows
                    ArrayTindakan("" & TArrayTindakan("FisikNoUrut") & "") = "" & TArrayTindakan("Result") & ""
                Next

                Dim Tbmi As Boolean = False
                tinggi = 0
                berat = 0
                For j As Integer = 8 To Tbls.Columns.Count - 1 Step 1
                    Dim Tidx() As String = Tbls.Columns(j).ColumnName.ToString.Split("/")
                    If (Tidx(0) = 0 And Tidx(1) = 1) Or CInt(Tidx(0).ToString) > -1 Then
                        If TblsN.Rows.Count > 0 Then
                            If (Tidx(0) = 0 And Tidx(1) = 1) Then
                                Thasil(j) = Math.Round(CDbl(ArrayTindakan(1402) / (ArrayTindakan(1401) * ArrayTindakan(1401)) * 10000), 1)
                            ElseIf CInt(Tidx(0).ToString) > -1 Then
                                Thasil(j) = ArrayTindakan(Tidx(1))
                            Else
                                Thasil(j) = "-"
                            End If
                        End If
                    ElseIf CInt(Tidx(0).ToString) < 0 Then
                        Dim Tjensitindakan As String = ReadSQLNIK("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'transaksilabhasillain' and COLUMN_NAME not like '%By%' and COLUMN_NAME not like '%Date%' and COLUMN_NAME not in ('HasilID','NoUrut') and ORDINAL_POSITION='" & Tidx(1) & "'")
                        Thasil(j) = ReadSQLNIK("select " & Tjensitindakan & " from transaksilabhasillain where NoUrut='" & Thasil("NoUrut").ToString & "'")
                    End If
                Next
            Next

            For j As Integer = 8 To Tbls.Columns.Count - 1 Step 1
                Dim Tcol As DataColumn = Tbls.Columns(j)
                Dim Tstr As String = ""
                Dim Txid() As String = Tcol.ColumnName.ToString.Split("/")
                If Txid(0) = 0 And Txid(1) = 1 Then
                    Tstr = "BMI"
                ElseIf CInt(Txid(0).ToString) > -1 Then
                    Tstr = ReadSQLNIK("select FisikKet as NamaTindakan from masterlabfisik  where FisikDeleted=0 and FisikNoUrut='" & Txid(1) & "'")
                ElseIf CInt(Txid(0).ToString) < 0 Then
                    Tstr = ReadSQLNIK("SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'transaksilabhasillain' and COLUMN_NAME not like '%By%' and COLUMN_NAME not like '%Date%' and COLUMN_NAME not in ('HasilID','NoUrut') and ORDINAL_POSITION='" & Txid(1) & "'")
                End If

                For i As Integer = 8 To j - 1 Step 1
                    If Tbls.Columns(i).ColumnName = Tstr Then
                        Tstr = Tstr & " "
                    End If
                Next
                Tcol.ColumnName = Tstr
            Next

            GridView3.Columns.Clear()
            gridresult.DataSource = Tbls

        End If

    End Sub

    Function QueryData() As DataTable
        Dim Ttemp As New DataTable
        Ttemp = gridpasien.DataSource
        Dim Tdata As DataTable
        Tdata = Ttemp.Clone

        For Each Trow As DataRow In Ttemp.Rows
            Tdata.ImportRow(Trow)
        Next

        Dim Tlab As New DataTable
        Tlab = gridtest.DataSource

        Dim Rlab() As DataRow = Tlab.Select("[Checked]=True")


        If Rlab.Length > 0 Then
            For i As Integer = 0 To Rlab.Length - 1
                Dim Tdetail As DataTable = ReadSQL(" select * from MasterLab a left join MasterLabDetail b on a.TindakanID=b.TindakanID where a.TindakanID='" & Rlab(i)("TindakanID").ToString & "' order by a.TindakanID,b.NoUrut")
                For Each Rdetail As DataRow In Tdetail.Rows
                    insertRowToTbls(Tdata, "Typstring", Rlab(i)("TindakanID").ToString & "~" & Rdetail("DetailKet"))
                Next
            Next
        End If

        For Each Tcol As DataColumn In Tdata.Columns
            Tcol.ReadOnly = False
        Next

        For Each Trow As DataRow In Tdata.Rows
            For i As Integer = 8 To Tdata.Columns.Count - 1 Step 1
                Dim Tsplit() As String = Tdata.Columns(i).ColumnName.ToString.Split("~")
                Trow(i) = ReadSQLNIK("select b.Result from TransaksiLabDetail a left join TransaksiLabResult b on a.TransLabIDDetail =b.TransLabIDDetail and a.TindakanID=b.TindakanID left join TransaksiLab c on c.TransLabID=a.TransLabID " & _
                                     " where c.NoUrut='" & Trow("NoUrut") & "' and CONVERT(date, c.Tgllab)='" & Format(Trow("TglLab"), "MM/dd/yyyy") & "' and c.IDInternet='" & Trow("NoRekamMedis") & "' and a.TindakanID='" & Tsplit(0).ToString & "' and DetailKet='" & Tsplit(1).ToString & "' order by a.TransLabIDDetail,a.TindakanID,b.NoUrut,b.GroupID,b.DetailKet ")
            Next
        Next

        Return Tdata
    End Function

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim Tbls As DataTable = gridresult.DataSource
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
                    gridresult.ExportToExcel(saveFileDialog1.FileName.ToString)
                    MsgBox("File Saved")
                End If
            End If
        End If
    End Sub

    Private Sub rdmcu_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdmcu.CheckedChanged
        If rdmcu.Checked = True And Tstr <> "" Then
            GridView2.Columns.Clear()

            ' Set Nama Perusahaan
            Dim namaPerusahaan As String = ""
            If TextBoxNamaPerusahaan.Text <> "" Then namaPerusahaan = " AND (d.NoJenisBayar = '" & TextBoxNamaPerusahaan.Text & "')"

            Dim queryBuilder As New StringBuilder()
            queryBuilder.AppendLine("SELECT DISTINCT a.TindakanID, b.NoUrut, a.NamaTindakan, b.DetailKet")
            queryBuilder.AppendLine("FROM TransaksiLabDetail a")
            queryBuilder.AppendLine("     LEFT JOIN TransaksiLabResult b ON a.TransLabIDDetail=b.TransLabIDDetail AND a.TindakanID=b.TindakanID")
            queryBuilder.AppendLine("     LEFT JOIN TransaksiLab c ON c.TransLabID=a.TransLabID")
            queryBuilder.AppendLine("     LEFT JOIN TransaksiLabBayar d ON a.TransLabID=d.TransLabID")
            queryBuilder.AppendLine("WHERE CONVERT(date, c.Tgllab) = '" & TextBoxTglTransaksi.Text & "' " & namaPerusahaan & " AND c.NoUrut IN " & Tstr & "")
            queryBuilder.AppendLine("ORDER BY a.TindakanID")

            Dim Tlab As DataTable = ReadSQL(queryBuilder.ToString())

            Dim Tdata As DataTable = ReadSQL(queryBuilder.ToString())
            Tdata.Rows.Clear()

            If Tlab.Rows.Count > 0 Then
                For Each Trow As DataRow In Tlab.Rows
                    Dim Tnew As DataRow = Tdata.NewRow
                    Tnew("TindakanID") = Trow("TindakanID")
                    Tnew("NoUrut") = Trow("NoUrut")
                    Tnew("NamaTindakan") = Trow("NamaTindakan")
                    Tnew("DetailKet") = Trow("DetailKet")
                    Tdata.Rows.Add(Tnew)
                Next
            End If

            'Add Hasil & Keterangan
            Dim Tnew2 As DataRow = Tdata.NewRow
            Tnew2("TindakanID") = "1000"
            Tnew2("NoUrut") = "0"
            Tnew2("NamaTindakan") = "Hasil"
            Tnew2("DetailKet") = "Hasil"
            Tdata.Rows.Add(Tnew2)
            Tnew2 = Tdata.NewRow
            Tnew2("TindakanID") = "1001"
            Tnew2("NoUrut") = "0"
            Tnew2("NamaTindakan") = "Keterangan"
            Tnew2("DetailKet") = "Keterangan"
            Tdata.Rows.Add(Tnew2)

            insertRowToTbls(Tdata, "typchecked", "Checked")

            Tdata.Columns("DetailKet").ReadOnly = True
            Tdata.Columns("NamaTindakan").ReadOnly = True
            Tdata.Columns("Checked").ReadOnly = False

            gridtest.DataSource = Tdata
            GridView2.Columns("TindakanID").Visible = False
            GridView2.Columns("NoUrut").Visible = False
        End If
    End Sub

    Private Sub rdlain_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdlain.CheckedChanged
        If rdlain.Checked = True And Tstr <> "" Then
            GridView2.Columns.Clear()

            Dim queryBuilder As New StringBuilder()

            queryBuilder.AppendLine("SELECT FisikID AS TindakanID, FisikNoUrut AS NoUrut, FisikKet AS NamaTindakan, FisikKet")
            queryBuilder.AppendLine("FROM MasterLabFisik")
            queryBuilder.AppendLine("WHERE FisikDeleted=0 AND Titikdua=':'")

            Dim Tfisik As DataTable = ReadSQL(queryBuilder.ToString())

            Dim Tlain As DataTable = ReadSQL("SELECT '-1' as TindakanID,ORDINAL_POSITION as NoUrut,COLUMN_NAME as NamaTindakan,'' as FisikKet FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'TransaksiLabHasilLain' and COLUMN_NAME not like '%By%' and COLUMN_NAME not like '%Date%' and COLUMN_NAME not in ('HasilID','NoUrut') ")
            For Each Trow As DataRow In Tlain.Rows
                Dim Tadd As DataRow = Tfisik.NewRow
                For i As Integer = 0 To Tfisik.Columns.Count - 1
                    Tadd(i) = Trow(i)
                Next
                Tfisik.Rows.Add(Tadd)
            Next

            Dim Tnewadd As DataRow = Tfisik.NewRow
            Tnewadd("TindakanID") = "0"
            Tnewadd("NoUrut") = 1
            Tnewadd("NamaTindakan") = "BMI"
            Tnewadd("FisikKet") = "BMI"
            Tfisik.Rows.InsertAt(Tnewadd, 0)

            insertRowToTbls(Tfisik, "typchecked", "Checked")

            Tfisik.Columns("NamaTindakan").ReadOnly = True
            Tfisik.Columns("Checked").ReadOnly = False

            gridtest.DataSource = Tfisik
            GridView2.Columns("TindakanID").Visible = False
            GridView2.Columns("NoUrut").Visible = False

        End If
    End Sub

    Private Sub rdheader_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdheader.CheckedChanged
        If rdheader.Checked = True And Tstr <> "" Then
            GridView2.Columns.Clear()

            ' Set Nama Perusahaan
            Dim namaPerusahaan As String = ""
            If TextBoxNamaPerusahaan.Text <> "" Then namaPerusahaan = " AND (d.NoJenisBayar = '" & TextBoxNamaPerusahaan.Text & "')"

            Dim queryBuilder As New StringBuilder()
            queryBuilder.AppendLine("SELECT DISTINCT a.TindakanID, b.NoUrut, a.NamaTindakan, b.DetailKet")
            queryBuilder.AppendLine("FROM TransaksiLabDetail a")
            queryBuilder.AppendLine("     LEFT JOIN TransaksiLabResult b ON a.TransLabIDDetail = b.TransLabIDDetail AND a.TindakanID = b.TindakanID")
            queryBuilder.AppendLine("     LEFT JOIN TransaksiLab c ON c.TransLabID = a.TransLabID")
            queryBuilder.AppendLine("     LEFT JOIN TransaksiLabBayar d ON a.TransLabID = d.TransLabID")
            queryBuilder.AppendLine("WHERE CONVERT(date, c.Tgllab) = '" & TextBoxTglTransaksi.Text & "' " & namaPerusahaan & " AND c.NoUrut IN " & Tstr & "")
            queryBuilder.AppendLine("ORDER BY a.TindakanID")

            Dim Tlab As DataTable = ReadSQL(queryBuilder.ToString())
            insertRowToTbls(Tlab, "typchecked", "Checked")

            Tlab.Columns("DetailKet").ReadOnly = True
            Tlab.Columns("NamaTindakan").ReadOnly = True
            Tlab.Columns("Checked").ReadOnly = False

            gridtest.DataSource = Tlab
            GridView2.Columns("TindakanID").Visible = False
            GridView2.Columns("NoUrut").Visible = False
        End If

    End Sub

    Private Sub PilihCompanyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PilihCompanyToolStripMenuItem.Click
        Find.Show()
        Find.Query("select IDCompany, CompanyCode, CompanyNama, NoCompany from mastercompany a where getdate() between StartDate and EndDate", " ORDER BY a.idcompany desc", "FindCabangSummary", 2)
    End Sub

    Public Sub LoadCompany(ByRef txkode As String, ByRef txlocationket As String)
        txcompany.Text = txlocationket
        TextBoxNamaPerusahaan.Text = txlocationket & "-" & txkode
    End Sub

    Private Sub PilihTanggalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PilihTanggalToolStripMenuItem.Click
        SelectDateTime.LoadOptionDialog("TanggalReportSummaryMCU", "Pilih Tanggal :")
        SelectDateTime.ShowDialog()
    End Sub
End Class


