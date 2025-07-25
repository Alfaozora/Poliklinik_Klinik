Public Class FormCreateRefund
    Dim thread As System.Threading.Thread
    Private UserAdmin As String = PoliKlinik.Lbluser.Text

    Private Sub setEnable()
        txnominalbayar.Enabled = True
        cbnominal.Enabled = True
        txtelp.Enabled = True
        txnoinvoice.Enabled = True
        txnominal.Enabled = True
        txbankrek.Enabled = True
        txnorek.Enabled = True
        txnorek2.Enabled = True
        txbersangkutan.Enabled = True
        txatasnamarek.Enabled = True
        butkalkulasi.Enabled = True
        butsaved.Enabled = True
        butsaved.Enabled = True
        CheckAll.Enabled = True        
        cmbstatus.Enabled = True
        cmbalasan.Enabled = True
        buttambahpasien.Enabled = True
        dtprocessend.Enabled = True
    End Sub

    Private Sub setDisable()
        txnominalbayar.Enabled = False
        cbnominal.Enabled = False
        txtelp.Enabled = False
        txnamakaryawan.Enabled = False
        txnoinvoice.Enabled = False
        txnominal.Enabled = False
        txbankrek.Enabled = False
        txnorek.Enabled = False
        txnorek2.Enabled = False
        txbersangkutan.Enabled = False
        txatasnamarek.Enabled = False
        butkalkulasi.Enabled = False
        butsaved.Enabled = False
        CheckAll.Enabled = False
        cmbstatus.Enabled = False
        buttambahpasien.Enabled = False
    End Sub

    Private Sub ClearHeader()
        cmbalasan.Enabled = True

        InsertNewItemComboSQL("SELECT StatusKesalahan FROM MasterStatusRefund", cmbalasan)
        cmbstatus.SelectedIndex = -1
        cmbalasan.SelectedIndex = -1
        dtprocess.Value = DateAndTime.Now
        dtprocessend.Value = DateAndTime.Now
        txtelp.ResetText()
        txnamakaryawan.ResetText()
        txnominal.ResetText()
        txsendnominal.ResetText()
        txnorek.ResetText()
        txnorek2.ResetText()
        txbersangkutan.ResetText()
        txbankrek.ResetText()
        txatasnamarek.ResetText()
        txnoinvoice.ResetText()
        CheckAll.Checked = False
        txnolab.ResetText()
        txnominalbayar.ResetText()
        cbnominal.Checked = False

        'Set False
        setDisable()
    End Sub

    Private Sub ClearGrid()
        gridrefund.DataSource = Nothing
    End Sub

    Private Sub SetClear()
        ClearHeader()
        ClearGrid()
    End Sub

    Private Sub FormCreateRefund_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        SetFormHeightWeight(Me, 0.95, 0.8)
        SetClear()
    End Sub

    Private Sub NewToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem1.Click
        SetClear()
    End Sub

    Function Checking() As Boolean
        Dim Tbls As DataTable = gridrefund.DataSource

        If cmbalasan.Text.Trim.Contains("Manual") = False Then
            Dim Trow() As DataRow = Tbls.Select("[Checked]=1")
            If Trow.Length = 0 Then
                MsgBox("Pilih Transaksi Terlebih Dahulu", MsgBoxStyle.Exclamation, "Warning!")
                Return False
            End If

            If txnominalbayar.Value > CDbl(txsendnominal.Text) Then
                If MsgBox("Apakah nominal bayar memang lebih besar dari nominal invoice? (Kelebihan Bayar)", MsgBoxStyle.YesNo, "Question.") = MsgBoxResult.No Then
                    Return False
                End If
            End If

            If txnominalbayar.Value < CDbl(txsendnominal.Text) Then
                MsgBox("Nominal Bayar Tidak Boleh Lebih Sedikit dari Nominal Invoice.", MsgBoxStyle.Exclamation, "Warning!")
                Return False
            End If
        End If

        If txnoinvoice.Text.Trim = "" And cmbalasan.Text.Trim.Contains("Manual") = True Then
            MsgBox("Input Detail Alasan Terlebih Dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        ElseIf cmbstatus.Text = "" Then
            MsgBox("Pilih Status Kesalahan Terlebih Dahulu", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        ElseIf cmbalasan.Text.Trim = "" Then
            MsgBox("Isi Kolom Alasan Terlebih Dahulu", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        ElseIf txtelp.Text.Trim = "" Then
            MsgBox("Isi Kolom Nomor Telepon Terlebih Dahulu", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        ElseIf txnamakaryawan.Text.Trim = "" Then
            MsgBox("Isi Kolom Nama Karyawan Terlebih Dahulu", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        ElseIf txnorek.Text.Trim = "" Or txnorek2.Text.Trim = "" Then
            MsgBox("Isi Kolom Nomor Rekening Terlebih Dahulu", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        ElseIf txbankrek.Text.Trim = "" Then
            MsgBox("Isi Kolom Nama Bank Rekening Terlebih Dahulu", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        ElseIf txatasnamarek.Text.Trim = "" Then
            MsgBox("Isi Kolom Atas Nama Rekening Terlebih Dahulu", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        ElseIf txbersangkutan.Text.Trim = "" Then
            MsgBox("Isi Kolom Atas Nama yang Bersangkutan Terlebih Dahulu", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        ElseIf txnominalbayar.Value = "0" Then
            MsgBox("Isi Kolom Nominal yg dibayar Terlebih Dahulu", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        Return True
    End Function

    Private Sub buttambahpasien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttambahpasien.Click
        If dtprocessend.Value < dtprocess.Value Then
            MsgBox("Tanggal Akhir tidak boleh melebihi tanggal mulai.", MsgBoxStyle.Exclamation, "Warning!")
            Exit Sub
        End If

        Dim Tquery As String = ""

        'Query Utama
        Tquery = "SELECT a.NoUrut AS 'No Lab', CONVERT(DATE, a.TglLab) AS 'Tanggal Lab', b.Nama, b.TglLahir AS 'Tgl Lahir', b.DomisiliAlamat, SUM(c.JumlahBayar) - SUM(c.Kembali) AS 'Tagihan' " & _
                 "FROM transaksilab a " & _
                 "LEFT JOIN MasterPasien b ON a.idinternet = b.NoRekamMedis " & _
                 "LEFT JOIN TransaksiLabBayar c ON a.TransLabID = c.TransLabID " & _
                 "WHERE ((NoUrut LIKE '%L%' AND a.Status <> 'OPEN') OR (a.NoUrut LIKE '%M%' AND a.Status <> 'OPEN' AND a.SendKeu IS NOT NULL)) AND a.RekapID IS NULL AND a.deleted <> 1 AND (CONVERT(date, a.tgllab) BETWEEN '" & Format(dtprocess.Value, "yyyyMMdd") & "' AND '" & Format(dtprocessend.Value, "yyyyMMdd") & "') AND a.TransLabID IN (SELECT TransLabID FROM TransaksiLabDetail WHERE RefundID IS NULL) " & _
                 "GROUP BY a.NoUrut, a.TglLab, b.Nama, b.TglLahir, b.DomisiliAlamat"

        Dim Tbls As DataTable = ReadSQL(Tquery)

        If Tbls.Rows.Count > 0 Then
            FindMultiple.Show()
            FindMultiple.Query(Tquery, " ORDER BY a.NoUrut DESC", "SelectPasienRefund", 2)
        Else
            MsgBox("Tidak ada data yang ditampilkan.", MsgBoxStyle.Exclamation, "Warning!")
            Exit Sub
        End If
    End Sub

    Public Sub LoadPasien(ByRef Trow() As DataRow)
        If Trow.Length = 0 Then
            SetClear()
        Else
            Dim Tquery As String = ""
            Dim TgllabStart As Date = "12/31/9998"
            Dim TgllabEnd As Date = "12/31/9998"

            'Query Utama
            Tquery = "SELECT a.TindakanID, a.NamaTindakan, a.NettBayar AS 'Harga Tindakan', COUNT(a.TindakanID) AS 'Jumlah Transaksi', (COUNT(a.TindakanID) * a.NettBayar) AS 'Total Biaya' " & _
            "FROM TransaksiLabDetail a " & _
            "LEFT JOIN MasterLab b ON a.TindakanID = b.TindakanID " & _
            "LEFT JOIN TransaksiLab c ON c.TransLabID = a.TransLabID " & _
            "LEFT JOIN MasterPasien d ON c.IDInternet = d.NoRekamMedis WHERE RefundID IS NULL AND"

            Dim Tstr As String = ""
            Dim Ttemp As String = "("
            Dim TtempNama As String = ""
            For i As Integer = 0 To Trow.Length - 1
                Ttemp = Ttemp & "'" & Trow(i)("No Lab").ToString.Trim & "',"
                TtempNama = TtempNama & "" & Trow(i)("Nama").ToString.Trim & " (" & Trow(i)("No Lab").ToString.Trim & "), "

                'Set Tanggal
                If TgllabStart = "12/31/9998" And TgllabEnd = "12/31/9998" Then
                    TgllabStart = Format(Trow(i)("Tanggal Lab"), "MM-dd-yyyy")
                    TgllabEnd = Format(Trow(i)("Tanggal Lab"), "MM-dd-yyyy")
                Else
                    If Format(Trow(i)("Tanggal Lab"), "MM-dd-yyyy") < TgllabStart Then
                        TgllabStart = Format(Trow(i)("Tanggal Lab"), "MM-dd-yyyy")
                    ElseIf Format(Trow(i)("Tanggal Lab"), "MM-dd-yyyy") > TgllabEnd Then
                        TgllabEnd = Format(Trow(i)("Tanggal Lab"), "MM-dd-yyyy")
                    End If
                End If
            Next
            Tstr = Strings.Left(Ttemp, Ttemp.Length - 1) & ")"
            dttglawal.Value = TgllabStart
            dttglakhir.Value = TgllabEnd
            txnoinvoice.Text = Strings.Left(TtempNama, TtempNama.Length - 2)
            txnolab.Text = Tstr

            Dim Tbls As DataTable = New DataTable

            Tbls = ReadSQL(Tquery + " c.nourut IN " & Tstr & " GROUP BY a.TindakanID, a.NamaTindakan, a.NettBayar ORDER BY a.TindakanID")

            If Tbls.Rows.Count > 0 Then
                insertRowToTbls(Tbls, "typchecked", "Checked")
                For Each Tcol As DataColumn In Tbls.Columns
                    Tcol.ReadOnly = True
                Next
                Tbls.Columns("Checked").ReadOnly = False
                gridrefund.DataSource = Tbls

                'Set True
                setEnable()
                cmbalasan.Enabled = False
            Else
                MsgBox("Tidak ada data yang ditampilkan.", MsgBoxStyle.Exclamation, "Warning!")
                Exit Sub
            End If
        End If
    End Sub

    Private Sub SetHeader()
        Dim Tbls As DataTable = gridrefund.DataSource
        Dim Total As Double = 0
        Dim JumlahTransaksi As Integer = 0
        Dim TgllabStart As Date = "12/31/9998"
        Dim TgllabEnd As Date = "12/31/9998"
        Dim Pemeriksaan As String = ""

        For Each Ttemp As DataRow In Tbls.Rows
            Total = Total + Ttemp("Tagihan")
            JumlahTransaksi = JumlahTransaksi + 1

            'Set Tanggal
            If TgllabStart = "12/31/9998" And TgllabEnd = "12/31/9998" Then
                TgllabStart = Format(Ttemp("Tanggal Lab"), "MM-dd-yyyy")
                TgllabEnd = Format(Ttemp("Tanggal Lab"), "MM-dd-yyyy")
            Else
                If Format(Ttemp("Tanggal Lab"), "MM-dd-yyyy") < TgllabStart Then
                    TgllabStart = Format(Ttemp("Tanggal Lab"), "MM-dd-yyyy")
                ElseIf Format(Ttemp("Tanggal Lab"), "MM-dd-yyyy") > TgllabEnd Then
                    TgllabEnd = Format(Ttemp("Tanggal Lab"), "MM-dd-yyyy")
                End If
            End If

            'Set Pemeriksaan
            If Pemeriksaan = "" Then
                Pemeriksaan = Ttemp("DetailPemeriksaan")
            Else
                Pemeriksaan = SetDetailPemeriksaan(Pemeriksaan, Ttemp("DetailPemeriksaan"))
            End If
        Next

        dttglawal.Value = TgllabStart
        dttglakhir.Value = TgllabEnd
        txsendnominal.Text = Total
        txnominal.Text = Format(Val(Total), "Rp, ###,###.#0")
        txnoinvoice.Text = Pemeriksaan
        'Set False Disini
    End Sub

    Function SetDetailPemeriksaan(ByVal Pemeriksaan As String, ByVal Detail As String) As String
        Dim DetailPemeriksaan As String = Pemeriksaan
        Dim Tdetail() As String = Detail.Split(",")
        For i As Integer = 0 To Tdetail.Count - 1
            If DetailPemeriksaan.Contains("" & Tdetail(i).Trim & "") = False Then
                DetailPemeriksaan = DetailPemeriksaan & ", " & Tdetail(i).Trim
            End If
        Next

        Return DetailPemeriksaan
    End Function

    Private Sub butsaved_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butsaved.Click
        If Checking() = True Then
            Dim NoTransaksi As String = ""
            Dim statusKesalahan As String = ""
            Dim alasan As String = ""
            Dim total As Double = 0
            Dim statustransaksi As Boolean = False
            Dim NoRefund = SetNoRefund()

            If cbtransaksi.Checked = True Then
                statustransaksi = True
            ElseIf cbtransaksi.Checked = False Then
                statustransaksi = False
            End If

            If cmbalasan.Text.Trim.Contains("Manual") = False Then
                Dim Ttable As DataTable = gridrefund.DataSource
                For Each Trownew As DataRow In Ttable.Select("[Checked]=1")
                    total = total + Trownew("Total Biaya")

                    'Update Di Tabel TransaksiLabDetail
                    WriteSQL("update TransaksiLabDetail set RefundStatusTransaksi='" & statustransaksi & "', RefundID='" & NoRefund & "' where TindakanID='" & Trownew("TindakanID").ToString.Trim & "' and TransLabID in (select TransLabID from TransaksiLab where NoUrut in " & txnolab.Text & ")", 4)
                Next

                alasan = cmbalasan.Text.Trim
            Else
                total = txnominalbayar.Value
                alasan = cmbalasan.Text.Trim & " (" & txnoinvoice.Text & ")"
                dttglawal.Value = dtprocess.Value
                dttglakhir.Value = dtprocess.Value
            End If

            If cmbstatus.SelectedIndex = 0 Then
                statusKesalahan = "A"
            ElseIf cmbstatus.SelectedIndex = 1 Then
                statusKesalahan = "B"
            ElseIf cmbstatus.SelectedIndex = 2 Then
                statusKesalahan = "C"
            End If

            'Insert Transaksi Baru
            WriteSQL("INSERT INTO TransaksiRefund (norefund ,jenistransaksi ,alasan ,totalbiaya ,invfromdate ,invtodate ,norek ,namabankrek ,namarek ,notelp ,createdate ,createby, namabersangkutan, statuskesalahan, totalbayar, namakaryawan, statustransaksi) " & _
                          "VALUES ('" & NoRefund & "', 'LAB', '" & alasan & "', '" & CDbl(total) & "', '" & Format(dttglawal.Value, "yyyyMMdd") & "', '" & Format(dttglakhir.Value, "yyyyMMdd") & "', '" & txnorek.Text.Trim & "-" & txnorek2.Text.Trim & "', '" & txbankrek.Text.Trim & "', '" & txatasnamarek.Text.Trim & "', '" & txtelp.Text.Trim & "', getdate(), '" & PoliKlinik.Lbluser.Text & "', '" & txbersangkutan.Text.Trim & "', '" & statusKesalahan & "', '" & CDbl(txnominalbayar.Value) & "', '" & txnamakaryawan.Text & "', '" & statustransaksi & "')", 4)

            MsgBox("Berhasil Menyimpan Data dengan No. Refund: " & NoRefund & "", MsgBoxStyle.Information, "Success!")
            SetClear()
            PrintReportRefund(NoRefund)
        End If
    End Sub

    Private Sub PrintReportRefund(ByVal NoRefund As String)
        Dim Tbls As DataTable = New DataTable
        Dim statusManual As Boolean = False

        If CheckSQL("SELECT * FROM TransaksiRefund WHERE alasan LIKE '%MANUAL%' AND norefund = '" & NoRefund & "'") = True Then
            Tbls = ReadSQL("SELECT 1 AS 'No', UPPER(namabersangkutan) AS 'Nama', GETDATE() AS 'Tgl Lahir', '-' AS 'NoUrut', totalbayar AS 'NettBayar', '-' AS 'NamaCompany' FROM TransaksiRefund WHERE norefund = '" & NoRefund & "'")
            statusManual = True
        Else
            Tbls = ReadSQL("SELECT ROW_NUMBER() OVER (ORDER BY NoRekamMedis ASC) AS 'No', UPPER(Nama) AS 'Nama', TglLahir AS 'Tgl Lahir', NoUrut, SUM(c.NettBayar) AS 'NettBayar', " & _
                           "CASE WHEN d.JenisBayar = 'TAGIHAN' THEN d.NoJenisBayar WHEN d.JenisBayar <> 'TAGIHAN' THEN 'PASIEN UMUM' ELSE 'PASIEN UMUM' END AS 'NamaCompany' " & _
                           "FROM MasterPasien a " & _
                           "LEFT JOIN TransaksiLab b ON a.NoRekamMedis = b.IDInternet " & _
                           "LEFT JOIN TransaksiLabDetail c ON b.TransLabID = c.TransLabID " & _
                           "LEFT JOIN TransaksiLabBayar d ON b.TransLabID = d.TransLabID AND d.JenisBayar = 'TAGIHAN' " & _
                           "WHERE c.RefundID IN (SELECT norefund FROM TransaksiRefund WHERE norefund = '" & NoRefund & "') " & _
                           "GROUP BY Nama, TglLahir, NoUrut, NoRekamMedis, JenisBayar, NoJenisBayar ORDER BY NoRekamMedis ASC")
        End If

        Dim Ttempat As String = ReadSQLNIK("select StrValue from MsConfig where ConfigName='Kota'")

        insertRowToTbls(Tbls, "typstring", "TindakanDetail")
        insertRowToTbls(Tbls, "typstring", "CompanyDetail")
        insertRowToTbls(Tbls, "typstring", "TglTransaksi")
        insertRowToTbls(Tbls, "typstring", "NoSuratRefund")
        insertRowToTbls(Tbls, "typstring", "txnamauser")
        insertRowToTbls(Tbls, "typstring", "txtglttd")
        insertRowToTbls(Tbls, "typstring", "lblprinted")
        insertRowToTbls(Tbls, "typstring", "lblbanktransfer")
        insertRowToTbls(Tbls, "typstring", "lblalasan")
        insertRowToTbls(Tbls, "typstring", "lblnamabersangkutan")
        insertRowToTbls(Tbls, "typstring", "lblnamamengetahui")
        insertRowToTbls(Tbls, "typstring", "lblnotelepon")
        insertRowToTbls(Tbls, "typstring", "lblnorek")
        insertRowToTbls(Tbls, "typstring", "lblnamabankrek")
        insertRowToTbls(Tbls, "typstring", "lblatasnamarek")
        insertRowToTbls(Tbls, "typstring", "lbladmin")
        insertRowToTbls(Tbls, "typstring", "statuskesalahan")
        insertRowToTbls(Tbls, "typstring", "totalbayar")

        Dim TCompany As DataTable = ReadSQL("select * from TransaksiRefund a where a.norefund = '" & NoRefund & "'")
        Dim TrowCompany As DataRow = TCompany.Rows(0)

        For Each Trow As DataRow In Tbls.Rows
            If statusManual = False Then
                Trow("TindakanDetail") = SetTindakanDetailRefund(Trow("NoUrut"), NoRefund)
                If Trow("NamaCompany").ToString.Contains("-") Then
                    Dim NamaCompany As String = Trow("NamaCompany").ToString
                    Dim Tsplit() As String = NamaCompany.Split("-")
                    Trow("CompanyDetail") = Tsplit(0).ToString.Trim.ToUpper
                Else
                    Trow("CompanyDetail") = Trow("NamaCompany").ToString.ToUpper
                End If
            Else
                Trow("TindakanDetail") = "-"
                Trow("CompanyDetail") = "-"
            End If

            If TrowCompany("invfromdate") = TrowCompany("invtodate") Then
                Trow("TglTransaksi") = Format(TrowCompany("invfromdate"), "dd") & " " & BulanIndonesia(Format(TrowCompany("invfromdate"), "MM")) & " " & Format(TrowCompany("invfromdate"), "yyyy")
            Else
                Trow("TglTransaksi") = Format(TrowCompany("invfromdate"), "dd") & " " & BulanIndonesia(Format(TrowCompany("invfromdate"), "MM")) & " " & Format(TrowCompany("invfromdate"), "yyyy") & " s/d " & Format(TrowCompany("invtodate"), "dd") & " " & BulanIndonesia(Format(TrowCompany("invtodate"), "MM")) & " " & Format(TrowCompany("invtodate"), "yyyy")
            End If

            Trow("NoSuratRefund") = NoRefund
            Trow("txtglttd") = Ttempat & ", " & Format(DateAndTime.Now, "dd") & " " & BulanIndonesia(Format(DateAndTime.Now, "MM")) & " " & Format(DateAndTime.Now, "yyyy")

            'New
            If CDbl(TrowCompany("totalbiaya")) < CDbl(TrowCompany("totalbayar")) Then
                If TrowCompany("statustransaksi").ToString.Trim = "True" Then
                    Dim NewTotal As Double = CDbl(TrowCompany("totalbayar")) - CDbl(TrowCompany("totalbiaya"))
                    Trow("lblbanktransfer") = "Dimohon untuk Dana Refund sebesar " & Format(Val(NewTotal), "Rp, ###,###") & " di transfer ke Rekening Berikut :"
                ElseIf TrowCompany("statustransaksi").ToString.Trim = "false" Then
                    Trow("lblbanktransfer") = "Dimohon untuk Dana Refund sebesar " & Format(Val(TrowCompany("totalbayar")), "Rp, ###,###") & " di transfer ke Rekening Berikut :"
                End If
            Else
                Trow("lblbanktransfer") = "Dimohon untuk Dana Refund sebesar " & Format(Val(TrowCompany("totalbiaya")), "Rp, ###,###") & " di transfer ke Rekening Berikut :"
            End If

            Trow("totalbayar") = Format(Val(TrowCompany("totalbayar")), "Rp, ###,###")
            Trow("lblalasan") = TrowCompany("alasan").ToString.Trim
            Trow("lblnamabersangkutan") = "(" & TrowCompany("namabersangkutan").ToString.Trim & ")"
            Trow("lblnamamengetahui") = "(" & ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='Marketing'") & ")"
            Trow("lblnotelepon") = TrowCompany("notelp").ToString.Trim
            Trow("lblnorek") = TrowCompany("norek").ToString.Trim
            Trow("lblnamabankrek") = TrowCompany("namabankrek").ToString.Trim
            Trow("lblatasnamarek") = TrowCompany("namarek").ToString.Trim
            Trow("lbladmin") = "(" & TrowCompany("createby").ToString.Trim & ")"
            Trow("statuskesalahan") = TrowCompany("statuskesalahan").ToString.Trim

            If PoliKlinik.Lbluser.Text = "Admin" Then
                Trow("txnamauser") = "Admin"
            Else
                Trow("txnamauser") = ReadSQLNIK("SELECT UserNama FROM Users where UserID = '" & PoliKlinik.Lbluser.Text & "'")
            End If

            Trow("lblprinted") = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:ss") & " By " & PoliKlinik.Lbluser.Text
        Next

        Report = New XtraReport
        Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\Refund\SuratRefundNonKop.repx", True)
        Report.DataSource = Tbls
        'Report.RunDesigner()
        Report.ShowPreview()
    End Sub

    Function SetNoRefund() As String
        Dim NoTagihan As String = ""
        Dim NoRef1 As String = ""
        Dim NoRef2 As String = ""
        Dim NoRef3 As String = ""
        Dim NoRef4 As String = ""
        Dim angka2 As String = "0001"
        Dim Tawal As Date = Format(DateSerial(DateAndTime.Now.Year, DateAndTime.Now.Month, 1), "MM/dd/yyyy")
        Dim Takhir As Date = Tawal.AddMonths(1).AddDays(-1)

        Dim angka As String = ReadSQLNIK("select TOP 1 REPLACE(STR(LEFT(norefund,4)+1, 4), SPACE(1), '0') from TransaksiRefund WHERE CONVERT(date, createdate) BETWEEN '" & Tawal & "' AND '" & Takhir & "' ORDER BY norefund desc")

        If angka = "" Or angka = "-" Then
            NoRef1 = angka2
        ElseIf angka <> "" Then
            NoRef1 = angka
        End If

        NoRef2 = "REF"
        NoRef3 = ReadSQLNIK("select StrValue from MsConfig where ConfigName='KodeInvoiceLab'")
        NoRef4 = GetRomes(DateAndTime.Now.Month) & "/" & Format(DateAndTime.Now, "yyyy")

        NoTagihan = NoRef1 & "/" & NoRef2 & "/" & NoRef3 & "/" & NoRef4

        Return NoTagihan
    End Function

    Private Sub txtelp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtelp.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub CheckAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckAll.CheckedChanged
        Dim Tbls As DataTable = gridrefund.DataSource

        If Tbls.Rows.Count > 0 Then
            For Each Trow As DataRow In Tbls.Rows
                If CheckAll.CheckState = CheckState.Checked Then
                    Trow("Checked") = True
                    butkalkulasi.PerformClick()
                Else
                    Trow("Checked") = False
                    butkalkulasi.PerformClick()
                End If
            Next
        End If
    End Sub

    Private Sub butkalkulasi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butkalkulasi.Click
        Dim Ttable As DataTable = gridrefund.DataSource
        Dim total As Integer = 0
        For Each Trownew As DataRow In Ttable.Select("[Checked]=1")
            total = total + Trownew("Total Biaya")
        Next

        txsendnominal.Text = total
        If total = 0 Then
            txnominal.Text = "Rp 0"
        Else
            txnominal.Text = Format(Val(total), "Rp, ###,###")
        End If
    End Sub

    Private Sub cmbalasan_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbalasan.SelectedIndexChanged
        If cmbalasan.Text.Trim <> "" Then
            Dim jenistransaksi As String = ReadSQLNIK("SELECT Transaksi FROM MasterStatusRefund WHERE StatusKesalahan = '" & cmbalasan.Text.Trim & "'")

            If cmbalasan.Text.Trim.Contains("Manual") = True Then
                cbtransaksi.Checked = False
                setEnable()
                buttambahpasien.Enabled = False
                txnominal.Enabled = False
                cbnominal.Enabled = False
                CheckAll.Enabled = False
                dtprocessend.Enabled = False
                txnoinvoice.ReadOnly = False
                txnamealasan.Text = "Detil Alasan"
            Else
                If jenistransaksi = "True" Then
                    cbtransaksi.Checked = True
                ElseIf jenistransaksi = "False" Then
                    cbtransaksi.Checked = False
                End If

                setDisable()
                buttambahpasien.Enabled = True
                dtprocessend.Enabled = True
                txnoinvoice.ReadOnly = True
                txnamealasan.Text = "No Invoice"
            End If
        Else
            cbtransaksi.Checked = False
        End If
    End Sub

    Private Sub txnorek_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txnorek.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub cbnominal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbnominal.CheckedChanged
        butkalkulasi.PerformClick()
        If cbnominal.Checked = True And txsendnominal.Text <> "" Then
            txnominalbayar.Value = CDbl(txsendnominal.Text)
        ElseIf cbnominal.Checked = False Then
            txnominalbayar.Value = CDbl(0)
        End If
    End Sub

    Private Sub txnorek2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txnorek2.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub cmbstatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbstatus.SelectedIndexChanged
        If cmbstatus.SelectedIndex = 2 Then
            txnamakaryawan.Enabled = True
            txnamakaryawan.ResetText()
        Else
            txnamakaryawan.Enabled = False
            txnamakaryawan.Text = "-"
        End If
    End Sub
End Class