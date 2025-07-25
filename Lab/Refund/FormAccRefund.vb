Public Class FormAccRefund
    Dim thread As System.Threading.Thread
    Private UserAdmin As String = PoliKlinik.Lbluser.Text

    ' Set Connection
    Private DB_Keuangan2 As TLcon
    Private DB_Jurnal As TLcon

    Private Sub SetConnectionFromConfig()
        ' Set Parameter Server Online
        Dim serverOnline_IP As String = Utility.GetConfig("ServerOnline_IP")
        Dim serverOnline_UserID As String = Utility.GetConfig("ServerOnline_UserID")
        Dim serverOnline_Password As String = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerOnline_Password"), "albert")

        ' Set DB Keuangan 2 (mitramed_keu2019)
        DB_Keuangan2.Tip = serverOnline_IP
        DB_Keuangan2.Tid = serverOnline_UserID
        DB_Keuangan2.Tpass = serverOnline_Password
        DB_Keuangan2.Tdb = Utility.GetConfig("ServerOnlineKeuangan2_DB")

        ' Set DB Jurnal
        DB_Jurnal.Tip = Utility.GetConfig("ServerJurnal_IP")
        DB_Jurnal.Tid = Utility.GetConfig("ServerJurnal_UserID")
        DB_Jurnal.Tpass = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerJurnal_Password"), "albert")
        DB_Jurnal.Tdb = Utility.GetConfig("ServerJurnal_DB")
    End Sub

    Private Sub ClearHeader()
        InsertNewItemComboSQL("SELECT StatusKesalahan FROM MasterStatusRefund", cmbalasan)

        cmbstatus.SelectedIndex = -1
        cmbalasan.SelectedIndex = -1
        butsaved.Enabled = True
        dtprocess.Value = Format(DateSerial(DateAndTime.Now.Year, DateAndTime.Now.Month, 1), "MM/dd/yyyy")
        dtprocessend.Value = DateAndTime.Now
        txtelp.ResetText()
        txnorefund.ResetText()
        txnominal.ResetText()
        txsendnominal.ResetText()
        txnorek.ResetText()
        txbersangkutan.ResetText()
        txnamakaryawan.ResetText()
        txbankrek.ResetText()
        txatasnamarek.ResetText()
        txnoinvoice.ResetText()
        CheckAll.Checked = False
        txnolab.ResetText()
        cbaccrefund.Checked = False
        cbdeleterefund.Checked = False
        lbllebihbayar.Visible = False
        txnominalbayar.Value = 0

        'Set False
        txnominalbayar.Enabled = False
        cmbalasan.Enabled = False
        cmbstatus.Enabled = False
        cbaccrefund.Enabled = False
        cbdeleterefund.Enabled = False
        txnorefund.Enabled = False
        txtelp.Enabled = False
        txnoinvoice.Enabled = False
        txnominal.Enabled = False
        txbankrek.Enabled = False
        txnorek.Enabled = False
        txbersangkutan.Enabled = False
        txnamakaryawan.Enabled = False
        txatasnamarek.Enabled = False
        butkalkulasi.Enabled = False
        butsaved.Enabled = False
        CheckAll.Enabled = False
        dtrefund.Enabled = False
        cbaccrefund.Enabled = False
        cbdeleterefund.Enabled = False
    End Sub

    Private Sub ClearGrid()
        gridrefund.DataSource = Nothing
    End Sub

    Private Sub SetClear()
        ' Inisialisasi koneksi ke database MySQL
        SetConnectionFromConfig()

        ClearHeader()
        ClearGrid()
    End Sub

    Private Sub FormAccRefund_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        SetFormHeightWeight(Me, 0.95, 0.8)
        SetClear()
    End Sub

    Private Sub NewToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem1.Click
        SetClear()
    End Sub

    Function Checking() As Boolean
        Dim Tbls As DataTable = gridrefund.DataSource

        Dim Trow() As DataRow = Tbls.Select("[Checked]=1")
        If Trow.Length = 0 Then
            MsgBox("Pilih Transaksi Terlebih Dahulu", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        If cmbstatus.Text = "" Then
            MsgBox("Pilih Status Kesalahan Terlebih Dahulu", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        If cmbalasan.Text.Trim = "" Then
            MsgBox("Isi Kolom Alasan Terlebih Dahulu", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        ElseIf txtelp.Text.Trim = "" Then
            MsgBox("Isi Kolom Nomor Telepon Terlebih Dahulu", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        ElseIf txnorek.Text.Trim = "" Then
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
        End If

        Return True
    End Function

    Public Sub LoadPasien(ByRef Txrefund As String)
        Dim Temprefund As DataTable = ReadSQL("SELECT * FROM TransaksiRefund WHERE RefundID = '" & Txrefund & "'")

        For Each Trow As DataRow In Temprefund.Rows
            txnorefund.Text = Trow("norefund")
            txsendnominal.Text = Trow("totalbiaya")
            txnominal.Text = Format(Val(Trow("totalbiaya")), "Rp, ###,###")

            If CDbl(Trow("totalbayar")) > CDbl(Trow("totalbiaya")) Then
                lbllebihbayar.Visible = True
            Else
                lbllebihbayar.Visible = False
            End If

            dtrefund.Text = Format(Trow("createdate"), "yyyy-MM-dd")
            txtelp.Text = Trow("notelp")
            txnorek.Text = Trow("norek")
            txbankrek.Text = Trow("namabankrek")
            txatasnamarek.Text = Trow("namarek")
            txbersangkutan.Text = Trow("namabersangkutan")
            txnamakaryawan.Text = Trow("namakaryawan")
            txnominalbayar.Value = CDbl(Trow("totalbayar"))

            If Trow("statuskesalahan").ToString.Trim = "A" Then
                cmbstatus.SelectedIndex = 0
            ElseIf Trow("statuskesalahan").ToString.Trim = "B" Then
                cmbstatus.SelectedIndex = 1
            ElseIf Trow("statuskesalahan").ToString.Trim = "C" Then
                cmbstatus.SelectedIndex = 2
            End If

            If Trow("alasan").ToString.Trim.Contains("Manual") = False Then
                cmbalasan.Text = Trow("alasan").ToString.Trim
            Else
                cmbalasan.Text = "Manual Tanpa Input Program"
            End If

            Dim jenistransaksi As String = Trow("statustransaksi").ToString.Trim

            If jenistransaksi = "True" Then
                cbtransaksi.Checked = True
            ElseIf jenistransaksi = "False" Then
                cbtransaksi.Checked = False
            End If

            If IsDBNull(Trow("accuserstatus")) = False Then
                cbaccrefund.Checked = True
                cbaccrefund.Enabled = False
                cbdeleterefund.Enabled = False
            ElseIf IsDBNull(Trow("deleted")) = False Then
                cbdeleterefund.Checked = True
                cbaccrefund.Enabled = False
                cbdeleterefund.Enabled = False
            Else
                cbaccrefund.Checked = False
                cbaccrefund.Enabled = True
                cbdeleterefund.Enabled = True
            End If
        Next

        LoadGrid(Txrefund)

        'Set True
        txnominalbayar.Enabled = True
        cmbalasan.Enabled = True
        cmbstatus.Enabled = True
        txnorefund.Enabled = True
        dtrefund.Enabled = True
        txtelp.Enabled = True
        txnoinvoice.Enabled = True
        txnominal.Enabled = True
        txbankrek.Enabled = True
        txnorek.Enabled = True
        txbersangkutan.Enabled = True
        txnamakaryawan.Enabled = True
        txatasnamarek.Enabled = True
        butkalkulasi.Enabled = True
        butsaved.Enabled = True
        CheckAll.Enabled = True
    End Sub

    Private Sub LoadGrid(ByVal NoRefund As String)
        Dim Tbls As DataTable = ReadSQL("SELECT ROW_NUMBER() OVER (ORDER BY NoRekamMedis ASC) AS 'No', UPPER(Nama) AS 'Nama', TglLahir AS 'Tgl Lahir', TglLab AS 'TglLab', NoUrut, SUM(c.NettBayar) AS 'NettBayar', CASE WHEN d.JenisBayar = 'TAGIHAN' THEN d.NoJenisBayar WHEN d.JenisBayar <> 'TAGIHAN' THEN 'PASIEN UMUM' ELSE 'PASIEN UMUM' END AS 'NamaCompany' " & _
                                        "FROM MasterPasien a " & _
                                        "LEFT JOIN TransaksiLab b ON a.NoRekamMedis = b.IDInternet " & _
                                        "LEFT JOIN TransaksiLabDetail c ON b.TransLabID = c.TransLabID " & _
                                        "LEFT JOIN TransaksiLabBayar d ON b.TransLabID = d.TransLabID AND d.JenisBayar = 'TAGIHAN' " & _
                                        "WHERE c.RefundID IN (SELECT norefund FROM TransaksiRefund WHERE RefundID = '" & NoRefund & "') " & _
                                        "GROUP BY Nama, TglLahir, TglLab, NoUrut, NoRekamMedis, JenisBayar, NoJenisBayar " & _
                                        "ORDER BY NoRekamMedis ASC")

        insertRowToTbls(Tbls, "typstring", "TindakanDetail")
        insertRowToTbls(Tbls, "typstring", "CompanyDetail")
        insertRowToTbls(Tbls, "typstring", "Tgl Invoice")

        Dim TxNoSurat As String = ReadSQLNIK("select norefund from TransaksiRefund a where a.RefundID = '" & NoRefund & "'")

        For Each Trow As DataRow In Tbls.Rows
            Trow("TindakanDetail") = SetTindakanDetailRefund(Trow("NoUrut"), TxNoSurat)

            If Trow("NamaCompany").ToString.Contains("-") Then
                Dim NamaCompany As String = Trow("NamaCompany").ToString
                Dim Tsplit() As String = NamaCompany.Split("-")
                Trow("CompanyDetail") = Tsplit(0).ToString.Trim.ToUpper
            Else
                Trow("CompanyDetail") = Trow("NamaCompany").ToString.ToUpper
            End If

            Trow("Tgl Invoice") = Format(Trow("TglLab"), "dd-MMM-yyyy")
        Next

        gridrefund.DataSource = Tbls
        GridView1.Columns("NamaCompany").Visible = False
        GridView1.Columns("Tgl Lahir").Visible = False
        GridView1.Columns("TglLab").Visible = False
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
            Dim NoRefund = SetNoRefund()

            Dim Ttable As DataTable = gridrefund.DataSource
            Dim total As Double = 0
            For Each Trownew As DataRow In Ttable.Select("[Checked]=1")
                total = total + Trownew("Total Biaya")

                'Update Di Tabel TransaksiLabDetail
                WriteSQL("update TransaksiLabDetail set RefundID='" & NoRefund & "' where TindakanID='" & Trownew("TindakanID").ToString.Trim & "' and TransLabID in (select TransLabID from TransaksiLab where NoUrut in " & txnolab.Text & ")", 4)
            Next

            If cmbstatus.SelectedIndex = 0 Then
                statusKesalahan = "A"
            ElseIf cmbstatus.SelectedIndex = 1 Then
                statusKesalahan = "B"
            ElseIf cmbstatus.SelectedIndex = 1 Then
                statusKesalahan = "C"
            End If

            If cmbalasan.Text.Trim <> "" Then
                alasan = cmbalasan.Text.Trim
            End If

            'Insert Transaksi Baru
            WriteSQL("INSERT INTO TransaksiRefund (norefund ,jenistransaksi ,alasan ,totalbiaya ,invfromdate ,invtodate ,norek ,namabankrek ,namarek ,notelp ,createdate ,createby, namabersangkutan, statuskesalahan) " & _
                          "VALUES ('" & NoRefund & "', 'LAB', '" & alasan & "', '" & CDbl(total) & "', '" & Format(dttglawal.Value, "yyyyMMdd") & "', '" & Format(dttglakhir.Value, "yyyyMMdd") & "', '" & txnorek.Text.Trim & "', '" & txbankrek.Text.Trim & "', '" & txatasnamarek.Text.Trim & "', '" & txtelp.Text.Trim & "', getdate(), '" & UserAdmin & "', '" & txbersangkutan.Text.Trim & "', '" & statusKesalahan & "')", 4)

            MsgBox("Berhasil Menyimpan Data dengan No. Refund: " & NoRefund & "", MsgBoxStyle.Information, "Success!")
            SetClear()
            PrintReportRefund(NoRefund)
        End If
    End Sub

    Private Sub PrintReportRefund(ByVal NoRefund As String)
        If NoRefund = "" Then
            MsgBox("Pilih No Refund Terlebih Dahulu.")
            Exit Sub
        End If

        Dim Tbls As DataTable = New DataTable
        Dim statusManual As Boolean = False

        If CheckSQL("SELECT * FROM TransaksiRefund WHERE alasan LIKE '%MANUAL%' AND norefund = '" & NoRefund & "'") = True Then
            Tbls = ReadSQL("SELECT 1 AS 'No', UPPER(namabersangkutan) AS 'Nama', GETDATE() AS 'Tgl Lahir', '-' AS 'NoUrut', totalbayar AS 'NettBayar', '-' AS 'NamaCompany' FROM TransaksiRefund WHERE norefund = '" & NoRefund & "'")
            statusManual = True
        Else
            Tbls = ReadSQL("SELECT ROW_NUMBER() OVER (ORDER BY NoRekamMedis ASC) AS 'No', UPPER(Nama) AS 'Nama', TglLahir AS 'Tgl Lahir', NoUrut, SUM(c.NettBayar) AS 'NettBayar', CASE WHEN d.JenisBayar = 'TAGIHAN' THEN d.NoJenisBayar WHEN d.JenisBayar <> 'TAGIHAN' THEN 'PASIEN UMUM' ELSE 'PASIEN UMUM' END AS 'NamaCompany' " & _
                           "FROM MasterPasien a " & _
                           "LEFT JOIN TransaksiLab b ON a.NoRekamMedis = b.IDInternet " & _
                           "LEFT JOIN TransaksiLabDetail c ON b.TransLabID = c.TransLabID " & _
                           "LEFT JOIN TransaksiLabBayar d ON b.TransLabID = d.TransLabID AND d.JenisBayar = 'TAGIHAN' " & _
                           "WHERE c.RefundID IN (SELECT norefund FROM TransaksiRefund WHERE norefund = '" & NoRefund & "') " & _
                           "GROUP BY Nama, TglLahir, NoUrut, NoRekamMedis, JenisBayar, NoJenisBayar " & _
                           "ORDER BY NoRekamMedis ASC")
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
                Else
                    Trow("Checked") = False
                End If
            Next
        End If
    End Sub

    Private Sub butkalkulasi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butkalkulasi.Click
        Dim Ttable As DataTable = gridrefund.DataSource
        Dim total As Integer = 0
        For Each Trownew As DataRow In Ttable.Select("[Checked]=1")
            total = total + Trownew("Total Biaya")
            txsendnominal.Text = total
            txnominal.Text = Format(Val(total), "Rp, ###,###.#0")
        Next
    End Sub

    Private Sub butsearchrefund_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butsearchrefund.Click
        Dim Tquery As String = ""

        'Query Utama
        Tquery = "SELECT RefundID, norefund, CONVERT(date, createdate) AS 'Tgl Refund', alasan, totalbiaya, CASE WHEN accuserstatus IS NULL THEN 'BELUM ACC' ELSE 'DONE' END AS 'Status Acc' FROM TransaksiRefund WHERE (CONVERT(DATE, createdate) BETWEEN '" & Format(dtprocess.Value, "yyyy-MM-dd") & "' AND '" & Format(dtprocessend.Value, "yyyy-MM-dd") & "') AND deleted IS NULL "

        Find.Show()
        Find.Query(Tquery, " ORDER BY RefundID asc", "FindRefundLab", 2)
    End Sub

    Private Sub CetakSuratRefundToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CetakSuratRefundToolStripMenuItem.Click
        If txnorefund.Text.Trim <> "" Then
            PrintReportRefund(txnorefund.Text)
        Else
            MsgBox("Pilih No Surat Refund Terlebih Dahulu.", MsgBoxStyle.Exclamation, "Warning!")
        End If
    End Sub

    Private Sub cbaccrefund_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbaccrefund.CheckedChanged
        Dim statusKesalahan As String = ""
        Dim alasan As String = ""
        Dim status As String = ReadSQLNIK("select accuserstatus from TransaksiRefund where norefund = '" & txnorefund.Text & "'")

        If cbaccrefund.Checked = True And status = "" Then
            If txnorefund.Text.Trim = "" Then
                MsgBox("Pilih No Surat Rujukan yang akan dihapus.", MsgBoxStyle.Exclamation, "Warning!")
                cbaccrefund.Checked = False
                Exit Sub
            End If

            If MsgBox("Apakah anda yakin ingin acc surat refund dengan nomor " & txnorefund.Text & "?", MsgBoxStyle.YesNo, "Question.") = MsgBoxResult.Yes Then
                If cmbstatus.SelectedIndex = 0 Then
                    statusKesalahan = "A"
                ElseIf cmbstatus.SelectedIndex = 1 Then
                    statusKesalahan = "B"
                ElseIf cmbstatus.SelectedIndex = 2 Then
                    statusKesalahan = "C"
                End If

                If cmbalasan.Text.Trim <> "" Then
                    alasan = cmbalasan.Text.Trim
                End If

                'Proses Delete
                WriteSQL("UPDATE TransaksiRefund SET totalbayar = '" & CDbl(txnominalbayar.Value) & "', statuskesalahan = '" & statusKesalahan & "', alasan = '" & alasan & "', accuserstatus=1, accuserby='" & UserAdmin & "', accuserdate=getdate() WHERE norefund = '" & txnorefund.Text & "'", 4)

                SendingJurnalAndPengajuan(txnorefund.Text)

                MsgBox("Surat Refund No. " & txnorefund.Text & " berhasil di acc.", MsgBoxStyle.Information, "Success!")
                SetClear()
                cbaccrefund.Checked = False
            Else
                cbaccrefund.Checked = False
            End If
        End If
    End Sub

    Private Sub cbdeleterefund_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbdeleterefund.CheckedChanged
        If cbdeleterefund.Checked = True Then
            If txnorefund.Text.Trim = "" Then
                MsgBox("Pilih No Surat Rujukan yang akan dihapus.", MsgBoxStyle.Exclamation, "Warning!")
                cbdeleterefund.Checked = False
                Exit Sub
            End If

            If CheckSQL("SELECT * FROM TransaksiRefund WHERE accuserstatus IS NOT NULL AND norefund = '" & txnorefund.Text & "'") = True Then
                MsgBox("No Surat " & txnorefund.Text & " tidak bisa di delete karena sudah di acc.", MsgBoxStyle.Exclamation, "Warning!")
                cbdeleterefund.Checked = False
                Exit Sub
            End If

            If MsgBox("Apakah anda yakin ingin menghapus surat refund dengan nomor " & txnorefund.Text & "?", MsgBoxStyle.YesNo, "Question.") = MsgBoxResult.Yes Then
                'Proses Delete
                WriteSQL("UPDATE TransaksiRefund SET deleted = 1, deletedby = '" & PoliKlinik.Lbluser.Text & "', deleteddate = GETDATE() WHERE norefund = '" & txnorefund.Text & "'", 4)
                WriteSQL("UPDATE TransaksiLabDetail SET RefundID = NULL WHERE RefundID = '" & txnorefund.Text & "'", 4)

                MsgBox("Surat Refund No. " & txnorefund.Text & " berhasil di hapus dari program.", MsgBoxStyle.Information, "Success!")
                SetClear()
                cbaccrefund.Checked = False
            Else
                cbaccrefund.Checked = False
            End If
        End If
    End Sub

    Private Sub SendingJurnalAndPengajuan(ByVal NoRef As String)
        Dim keterangan As String = ""
        Dim flag As String = ""
        Dim KetLokasi As String = ""
        Dim Nourut As String = ""
        Dim bsa As String = ""
        Dim JenisSupp As String = "REFUND PEMBAYARAN LAB"
        Dim SuppID As String = ""
        Dim Tlokasigl As New DataTable

        'Set Var Setting
        Dim CoaRefundLab As String = ""
        Dim CoaPendapatanLab As String = ""
        Dim CoaKerugianPembatalanTransaksi As String = ""
        Dim CoaPiutangKaryawan As String = ""
        Dim UserAutoWeb As String = ""

        'Set Var Config
        Dim Tloc As String = ""
        Dim TKode As String = ""
        Dim TKodeBarcode As String = ""
        Dim KodeLokasiLab As String = ""

        Dim TempConfigLokal As DataTable = ReadSQL("select ConfigName, StrValue from MsConfig where ConfigName IN ('NoPoli', 'KodeInvoiceLab', 'KodeBarcode', 'KodeLokasiKeuangan_Lab')")
        For Each TrowConfigLokal As DataRow In TempConfigLokal.Rows
            If TrowConfigLokal("ConfigName") = "NoPoli" Then
                Tloc = TrowConfigLokal("StrValue").ToString.Trim
            ElseIf TrowConfigLokal("ConfigName") = "KodeInvoiceLab" Then
                TKode = TrowConfigLokal("StrValue").ToString.Trim
            ElseIf TrowConfigLokal("ConfigName") = "KodeBarcode" Then
                TKodeBarcode = TrowConfigLokal("StrValue").ToString.Trim
            ElseIf TrowConfigLokal("ConfigName") = "KodeLokasiKeuangan_Lab" Then
                KodeLokasiLab = TrowConfigLokal("StrValue").ToString.Trim
            End If
        Next

        Dim TempSetting As DataTable = ReadThemysql("SELECT a.name, a.value FROM mastersetting a WHERE a.name IN ('CoaRefundLab', 'CoaPendapatanLab', 'CoaKerugianPembatalanTransaksi', 'CoaPiutangKaryawan', 'UserAutoWeb')", DB_Keuangan2)
        For Each TrowSetting As DataRow In TempSetting.Rows
            If TrowSetting("name") = "CoaRefundLab" Then
                CoaRefundLab = TrowSetting("value").ToString.Trim
            ElseIf TrowSetting("name") = "CoaPendapatanLab" Then
                CoaPendapatanLab = TrowSetting("value").ToString.Trim
            ElseIf TrowSetting("name") = "CoaKerugianPembatalanTransaksi" Then
                CoaKerugianPembatalanTransaksi = TrowSetting("value").ToString.Trim
            ElseIf TrowSetting("name") = "CoaPiutangKaryawan" Then
                CoaPiutangKaryawan = TrowSetting("value").ToString.Trim
            ElseIf TrowSetting("name") = "UserAutoWeb" Then
                UserAutoWeb = TrowSetting("value").ToString.Trim
            End If
        Next

        Dim OutID As String = ReadThemysqlNIK("SELECT a.outid FROM accmasterpengeluaran a WHERE a.coa = '" & CoaRefundLab & "'", DB_Keuangan2)
        Dim LocID As String = ReadThemysqlNIK("SELECT a.locid FROM masterlokasi a WHERE a.locationcode = '" & KodeLokasiLab & "'", DB_Keuangan2)

        'Cek & Insert Master Customer
        If CheckThemysql("SELECT * FROM accmasterbank WHERE norekening = '" & txnorek.Text.Trim & "'", DB_Keuangan2) = False Then
            'Insert Tabel mastersupplier
            WriteThemysql("INSERT INTO mastersupplier (suppliernama, supplieralamat, suppliertelp, supplierjenis, createdby, createddate)" & _
                             " values('" & txatasnamarek.Text.Trim & "','-','" & txtelp.Text & "','" & JenisSupp & "','" & UserAdmin & "', NOW())", DB_Keuangan2)

            'Cari SuppID
            SuppID = ReadThemysqlNIK("SELECT a.supplierid FROM mastersupplier a ORDER BY a.supplierid DESC LIMIT 1", DB_Keuangan2)

            'Insert Tabel accmasterbank
            WriteThemysql("INSERT INTO accmasterbank (namabank, norekening, namarekening, cabangrekening, supplierid, createdby, createddate)" & _
                             " values('" & txbankrek.Text.Trim & "', '" & txnorek.Text.Trim & "', '" & txatasnamarek.Text.Trim & "', '-', '" & SuppID & "', '" & UserAdmin & "', NOW())", DB_Keuangan2)
        Else
            'Cari SuppID
            SuppID = ReadThemysqlNIK("SELECT a.supplierid FROM mastersupplier a WHERE a.supplierid IN (SELECT supplierid FROM accmasterbank WHERE norekening = '" & txnorek.Text.Trim & "')", DB_Keuangan2)
        End If

        'Set Nominal Pengajuan
        Dim NilaiUang As Double = 0
        'If CDbl(txsendnominal.Text) < CDbl(txnominalbayar.Value) Then
        '    NilaiUang = CDbl(txnominalbayar.Value) - CDbl(txsendnominal.Text)
        'Else
        '    NilaiUang = CDbl(txsendnominal.Text)
        'End If

        If CDbl(txsendnominal.Text) < CDbl(txnominalbayar.Value) Then
            If cbtransaksi.Checked = True Then
                NilaiUang = CDbl(txnominalbayar.Value) - CDbl(txsendnominal.Text)
            ElseIf cbtransaksi.Checked = False Then
                NilaiUang = CDbl(txnominalbayar.Value)
            End If
        Else
            NilaiUang = CDbl(txsendnominal.Text)
        End If

        'Set Tanggal Beban
        Dim Years As Integer = CDbl(Format(dtrefund.Value, "yyyy"))
        Dim Month As Integer = CDbl(Format(dtrefund.Value, "MM"))

        'Set ID Lokasi & Ketrangan Lokasi di GL
        Tlokasigl = ReadThemysql("SELECT a.locgl, a.locket FROM masterlokasigl a WHERE a.loc='" & Tloc & "' AND a.jenistransaksi='LAB'", DB_Keuangan2)
        Dim Trowlokasigl As DataRow = Tlokasigl.Rows(0)
        bsa = Trowlokasigl("locgl")
        KetLokasi = Trowlokasigl("locket")

        'Set Flag & Keterangan
        Dim Tdetail() As String = NoRef.Split("/")
        flag = Tdetail(0) & "RF" & Tdetail(2).Substring(Tdetail(2).Length - 3) & Tdetail(3) & Tdetail(4).Substring(Tdetail(4).Length - 2)
        keterangan = "REFUND - PASIEN UMUM " & KetLokasi & " " & Format(DateAndTime.Now, "dd/MM/yyyy") & " (NO. REFUND : " & NoRef & ")"

        'Insert Ke Tabel acctranskas (Program Keuangan)
        WriteThemysql("INSERT INTO `acctranskas` (`outid`, `pengajuan`, `transtgl`, `createdby`, `createddate`, `accuserby`, `accuserdate`, `accuserstatus`, `keterangan`, `bebantgl`, `nilaiuang`, `nomorfaktur`, `supplierid`, `loc`, `realisasi`, `refundid`) " & _
                          "VALUES ('" & OutID & "', '1', '" & Format(dtrefund.Value, "yyyyMMdd") & "', '" & UserAutoWeb & "', NOW(), '" & UserAutoWeb & "', NOW(), '1', '" & keterangan & "', '" & Format(New DateTime(Years, Month, DateTime.DaysInMonth(Years, Month)), "yyyyMMdd") & "', '" & CDbl(NilaiUang) & "', '" & NoRef & "', '" & SuppID & "', '" & LocID & "', '" & CDbl(NilaiUang) & "', '" & NoRef & "')", DB_Keuangan2)

        'Insert Ke GL (Jurnal Otomatis)
        If cmbstatus.SelectedIndex = 0 Then
            WriteThemysql("SELECT F_MakeUMH('" & flag & "', 'out', '', '" & Format(dtrefund.Value, "yyyyMMdd") & "', '" & CoaRefundLab & "', '" & CoaPendapatanLab & "', 'IDR', 1, " & CDbl(NilaiUang) & ", '" & keterangan.ToUpper() & "', '1', 1, '', '" & keterangan.ToUpper() & "', '', '', '" & bsa & "', 4, " & CDbl(NilaiUang) & ", 'K')", DB_Jurnal)
        ElseIf cmbstatus.SelectedIndex = 1 Then
            WriteThemysql("SELECT F_MakeUMH('" & flag & "', 'out', '', '" & Format(dtrefund.Value, "yyyyMMdd") & "', '" & CoaRefundLab & "', '" & CoaKerugianPembatalanTransaksi & "', 'IDR', 1, " & CDbl(NilaiUang) & ", '" & keterangan.ToUpper() & "', '1', 1, '', '" & keterangan.ToUpper() & "', '', '', '" & bsa & "', 4, " & CDbl(NilaiUang) & ", 'K')", DB_Jurnal)
        ElseIf cmbstatus.SelectedIndex = 2 Then
            WriteThemysql("SELECT F_MakeUMH('" & flag & "', 'out', '', '" & Format(dtrefund.Value, "yyyyMMdd") & "', '" & CoaRefundLab & "', '" & CoaPiutangKaryawan & "', 'IDR', 1, " & CDbl(NilaiUang) & ", '" & keterangan.ToUpper() & "', '1', 1, '', '" & keterangan.ToUpper() & "', '', '', '" & bsa & "', 4, " & CDbl(NilaiUang) & ", 'K')", DB_Jurnal)
        End If

        'Save Log
        WriteSQL("INSERT INTO LogJurnalKeuangan (JurnalFlag,JurnalDate,JurnalBy,Status,JenisTransaksi) VALUES ('" & flag & "', getdate(), '" & UserAdmin & "', 'JURNAL REFUND (" & NoRef & ")', 'LAB')", 4)
    End Sub
End Class