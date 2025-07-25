Imports System.Drawing
Imports System.Text

Public Class FormPembatalanTransaksi
    Private formName As String = "FORM PEMBATALAN TRANSAKSI"
    Private userInput As String = PoliKlinik.Lbluser.Text
    Private kodeLokasiKlinik As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NoPoli'")

    ' Set Connection
    Private DB_Keuangan As TLcon
    Private DB_Keuangan2 As TLcon
    Private DB_Omset As TLcon
    Private DB_Jurnal As TLcon

    Private Sub SetConnectionFromConfig()
        ' Set Parameter Server Online
        Dim serverOnline_IP As String = Utility.GetConfig("ServerOnline_IP")
        Dim serverOnline_UserID As String = Utility.GetConfig("ServerOnline_UserID")
        Dim serverOnline_Password As String = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerOnline_Password"), "albert")

        ' Set DB Keuangan 1 (mitramed_keu)
        DB_Keuangan.Tip = serverOnline_IP
        DB_Keuangan.Tid = serverOnline_UserID
        DB_Keuangan.Tpass = serverOnline_Password
        DB_Keuangan.Tdb = Utility.GetConfig("ServerOnlineKeuangan_DB")

        ' Set DB Keuangan 2 (mitramed_keu2019)
        DB_Keuangan2.Tip = serverOnline_IP
        DB_Keuangan2.Tid = serverOnline_UserID
        DB_Keuangan2.Tpass = serverOnline_Password
        DB_Keuangan2.Tdb = Utility.GetConfig("ServerOnlineKeuangan2_DB")

        ' Set DB Omset (mitramedicare_omset_keuangan)
        DB_Omset.Tip = serverOnline_IP
        DB_Omset.Tid = serverOnline_UserID
        DB_Omset.Tpass = serverOnline_Password
        DB_Omset.Tdb = Utility.GetConfig("ServerOnlineOmset_DB")

        ' Set DB Jurnal
        DB_Jurnal.Tip = Utility.GetConfig("ServerJurnal_IP")
        DB_Jurnal.Tid = Utility.GetConfig("ServerJurnal_UserID")
        DB_Jurnal.Tpass = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerJurnal_Password"), "albert")
        DB_Jurnal.Tdb = Utility.GetConfig("ServerJurnal_DB")
    End Sub

    Private Sub PanelTop_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelTop.Paint
        Try
            e.Graphics.DrawString(formName, New Font("Arial", 12, FontStyle.Bold), Brushes.White, New Point(10, 10))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub SetData()
        GridControlTransaksi.DataSource = Nothing
        DateTimePickerTanggalTransaksiAwal.Value = DateAndTime.Now
        DateTimePickerTanggalTransaksiAwal.Enabled = True
    End Sub

    Private Sub FormPembatalanTransaksi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        Me.MdiParent = PoliKlinik
        Me.Dock = DockStyle.Fill

        '# Load Placeholder
        ApplyPlaceholder(TextBoxAlasan, " Masukkan alasan...")

        ' Inisialisasi koneksi ke database MySQL
        SetConnectionFromConfig()

        SetData()
    End Sub

    Function ValidasiDataTransaksi() As Boolean
        Dim tblTransaksi As DataTable = GridControlTransaksi.DataSource
        Dim jumlahData As Integer = 0
        Dim listNomorTransaksi As String = ""
        Dim tempNomorTransaksi As String = "("

        ' Validasi Data Kosong
        If tblTransaksi Is Nothing = True Then
            MessageBox.Show("Tidak ada data yang ditampilkan.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        ' Validasi Koneksi Internet
        If CheckInternetConnection() = False Then
            MsgBox("Eror : Tidak ada koneksi internet.", MsgBoxStyle.Exclamation, "Error!")
            Return False
        End If

        ' Validasi Bridging Pcare Jika Aktif
        If CheckBridgingPcareActive() = True AndAlso ValidateBridgingPcare() = False Then
            Return False
        End If

        ' Validasi Inputan Alasan Batal
        If TextBoxAlasan.Text.Trim() = "" OrElse TextBoxAlasan.Text = TextBoxAlasan.Tag.ToString() Then
            MessageBox.Show("Masukkan Alasan Terlebih Dahulu.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        ' Get Nomor Urut & Jumlah Data
        For Each rowTransaksi As DataRow In tblTransaksi.Select("[Checked]=True")
            If rowTransaksi("StatusDelete").ToString = "0" Then
                tempNomorTransaksi = tempNomorTransaksi & "'" & rowTransaksi("No Transaksi").ToString.Trim & "',"
                jumlahData = jumlahData + 1
            End If
        Next
        listNomorTransaksi = Strings.Left(tempNomorTransaksi, tempNomorTransaksi.Length - 1) & ")"

        ' Validasi Checklist Data Transaksi
        If jumlahData <= 0 Then
            MsgBox("Pilih Transaksi Terlebih Dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        ' Validasi Transaksi Sudah di Close Keuangan
        If CheckThemysql("SELECT * FROM acctranstagihandetail WHERE loc = '" & kodeLokasiKlinik & "' AND date(inctgl) = '" & Format(DateTimePickerTanggalTransaksiAwal.Value, "yyyyMMdd") & "' AND no_transaksi IN " & listNomorTransaksi & " and lockeddate <> '99981231'", DB_Keuangan) = True Then
            MsgBox("Terdapat transaksi yang sudah di kunci oleh keuangan.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        ElseIf CheckThemysql("SELECT * FROM acctranspendapatandetail WHERE loc = '" & kodeLokasiKlinik & "' AND date(inctgl) = '" & Format(DateTimePickerTanggalTransaksiAwal.Value, "yyyyMMdd") & "' AND no_transaksi IN " & listNomorTransaksi & " and lockeddate <> '99981231'", DB_Keuangan) = True Then
            MsgBox("Terdapat transaksi yang sudah di kunci oleh keuangan.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        For Each rowTransaksi As DataRow In tblTransaksi.Select("[Checked]=True")
            If rowTransaksi("StatusDelete") = False Then
                ' Validasi Transaksi Paket Tindakan
                If CheckSQL("SELECT * FROM TransaksiPaketTindakan WHERE NoTransaksi = '" & rowTransaksi("No Transaksi") & "'") = True Then
                    If CheckSQL("SELECT * FROM LogPenggunaanPaket WHERE DeletedDate IS NULL AND KodeVoucher IN (SELECT KodeVoucher FROM TransaksiPaketTindakan WHERE NoTransaksi IN ('" & rowTransaksi("No Transaksi") & "'))") = True Then
                        MsgBox("Nomor Transaksi " & rowTransaksi("No Transaksi") & " tidak bisa cancel karena terdapat transaksi paket yang masih aktif.", MsgBoxStyle.Exclamation, "Warning!")
                        Return False
                    End If
                End If

                ' Validasi Berdasarkan Poli Tujuan
                Select Case rowTransaksi("JenisTransaksi")
                    Case "POLI"
                        'If CheckSQL("SELECT * FROM TransaksiPoli WHERE [Status] = 'CLOSED' AND TransPoliID = " & rowTransaksi("ID") & "") = True Then
                        '    MsgBox("Nomor Transaksi " & rowTransaksi("No Transaksi") & " sudah dilakukan transaksi pembayaran kasir poli.", MsgBoxStyle.Exclamation, "Warning!")
                        '    Return False
                        If CheckSQL("SELECT * FROM TransaksiPoli WHERE ResepStatus <> 0 AND TransPoliID = " & rowTransaksi("ID") & "") = True Then
                            MsgBox("Nomor Transaksi " & rowTransaksi("No Transaksi") & " sudah dilakukan transaksi pembayaran kasir apotek.", MsgBoxStyle.Exclamation, "Warning!")
                            Return False
                        ElseIf CheckSQL("SELECT * FROM TransaksiPoli WHERE TransPoliID IN (SELECT TransPoliID FROM TransaksiPoliDetail WHERE NoInvoiceBHP IS NOT NULL) AND TransPoliID = " & rowTransaksi("ID") & "") = True Then
                            MsgBox("Nomor Transaksi " & rowTransaksi("No Transaksi") & " sudah dilakukan transaksi BHP.", MsgBoxStyle.Exclamation, "Warning!")
                            Return False
                        ElseIf CheckSQL("SELECT * FROM TransaksiPoli WHERE RekapID > 0 AND TransPoliID = " & rowTransaksi("ID") & "") = True Then
                            MsgBox("Nomor Transaksi " & rowTransaksi("No Transaksi") & " sudah dilakukan transaksi invoice tagihan.", MsgBoxStyle.Exclamation, "Warning!")
                            Return False
                        End If
                    Case "GIGI"
                        'If CheckSQL("SELECT * FROM TransaksiGigi WHERE [Status] = 'CLOSED' AND TransGigiID = " & rowTransaksi("ID") & "") = True Then
                        '    MsgBox("Nomor Transaksi " & rowTransaksi("No Transaksi") & " sudah dilakukan transaksi pembayaran kasir poli.", MsgBoxStyle.Exclamation, "Warning!")
                        '    Return False
                        If CheckSQL("SELECT * FROM TransaksiGigi WHERE ResepStatus <> 0 AND TransGigiID = " & rowTransaksi("ID") & "") = True Then
                            MsgBox("Nomor Transaksi " & rowTransaksi("No Transaksi") & " sudah dilakukan transaksi pembayaran kasir apotek.", MsgBoxStyle.Exclamation, "Warning!")
                            Return False
                        ElseIf CheckSQL("SELECT * FROM TransaksiGigi WHERE TransGigiID IN (SELECT TransGigiID FROM TransaksiGigiDetail WHERE NoInvoiceBHP IS NOT NULL) AND TransGigiID = " & rowTransaksi("ID") & "") = True Then
                            MsgBox("Nomor Transaksi " & rowTransaksi("No Transaksi") & " sudah dilakukan transaksi BHP.", MsgBoxStyle.Exclamation, "Warning!")
                            Return False
                        ElseIf CheckSQL("SELECT * FROM TransaksiGigi WHERE RekapID > 0 AND TransGigiID = " & rowTransaksi("ID") & "") = True Then
                            MsgBox("Nomor Transaksi " & rowTransaksi("No Transaksi") & " sudah dilakukan transaksi invoice tagihan.", MsgBoxStyle.Exclamation, "Warning!")
                            Return False
                        End If
                    Case "LAB"
                        If CheckSQL("SELECT * FROM TransaksiLabDetail WHERE RefundID IS NOT NULL AND TransLabID = " & rowTransaksi("ID") & "") = True Then
                            MsgBox("Nomor Transaksi " & rowTransaksi("No Transaksi") & " sudah dibuat sebagai refund.", MsgBoxStyle.Exclamation, "Warning!")
                            Return False
                        ElseIf CheckSQL("SELECT * FROM TransaksiLab WHERE [Status] IN ('CETAK', 'TAKEIT') AND TransLabID = " & rowTransaksi("ID") & "") = True Then
                            MsgBox("Nomor Transaksi " & rowTransaksi("No Transaksi") & " sudah diisi / cetak hasil.", MsgBoxStyle.Exclamation, "Warning!")
                            Return False
                        ElseIf CheckSQL("SELECT * FROM TransaksiLab WHERE RujukanID IS NOT NULL AND TransLabID = " & rowTransaksi("ID") & "") = True Then
                            MsgBox("Nomor Transaksi " & rowTransaksi("No Transaksi") & " sudah dibuat sebagai rujukan.", MsgBoxStyle.Exclamation, "Warning!")
                            Return False
                        ElseIf CheckSQL("SELECT * FROM TransaksiLab WHERE RekapID > 0 AND TransLabID = " & rowTransaksi("ID") & "") = True Then
                            MsgBox("Nomor Transaksi " & rowTransaksi("No Transaksi") & " sudah dilakukan transaksi invoice tagihan.", MsgBoxStyle.Exclamation, "Warning!")
                            Return False
                        End If
                End Select
            End If
        Next

        If MsgBox("Yakin menghapus " & jumlahData & " transaksi ini ?", MsgBoxStyle.YesNo, "Question.") = MsgBoxResult.No Then
            Return False
        End If

        Return True
    End Function

    Private Sub SendingJurnalCancel()
        ' Set DataTable
        Dim tblDetailTransaksi As DataTable = New DataTable
        Dim tblTransaksi As DataTable = GridControlTransaksi.DataSource
        tblTransaksi.AcceptChanges()

        ' Get Nomor Urut & Jumlah Data
        For Each rowTransaksi As DataRow In tblTransaksi.Select("[Checked]=True")
            Select Case rowTransaksi("JenisTransaksi")
                Case "POLI"
                    tblDetailTransaksi = GetDataPoliUmum(rowTransaksi("No Transaksi"))

                    'tblDetailTagihan = ReadSQL(" SELECT t1.JenisBayar, SUM(t1.JumlahTagihan) AS 'JumlahTagihan' FROM (" & _
                    '                           " SELECT b.JenisBayar, b.JumlahBayar - b.Kembali AS 'JumlahTagihan' FROM TransaksiPoli a LEFT JOIN TransaksiPoliBayar b ON a.TransPoliID = b.TransPoliID WHERE a.Upload = 0 AND b.JumlahBayar > 0 AND NoUrut = '" & rowTransaksi("No Transaksi") & "' AND JenisBayar = 'TAGIHAN'" & _
                    '                           " UNION" & _
                    '                           " SELECT b.JenisBayar, b.JumlahBayar - b.Kembali AS 'JumlahTagihan' FROM TransaksiPoli a LEFT JOIN TransaksiPoliBayarAwal b ON a.TransPoliID = b.TransPoliID WHERE a.Upload = 0 AND b.JumlahBayar > 0 AND NoUrut = '" & rowTransaksi("No Transaksi") & "' AND JenisBayar = 'TAGIHAN' ) AS t1" & _
                    '                           " GROUP BY t1.JenisBayar")
                Case "GIGI"
                    tblDetailTransaksi = GetDataPoliGigi(rowTransaksi("No Transaksi"))

                    'tblDetailTransaksi = ReadSQL(" SELECT t1.JenisBayar, SUM(t1.JumlahTagihan) AS 'JumlahTagihan' FROM (" & _
                    '                           " SELECT b.JenisBayar, b.JumlahBayar - b.Kembali AS 'JumlahTagihan' FROM TransaksiGigi a LEFT JOIN TransaksiGigiBayar b ON a.TransGigiID = b.TransGigiID WHERE a.Upload = 0 AND b.JumlahBayar > 0 AND NoUrut = '" & rowTransaksi("No Transaksi") & "' AND JenisBayar = 'TAGIHAN'" & _
                    '                           " UNION" & _
                    '                           " SELECT b.JenisBayar, b.JumlahBayar - b.Kembali AS 'JumlahTagihan' FROM TransaksiGigi a LEFT JOIN TransaksiGigiBayarAwal b ON a.TransGigiID = b.TransGigiID WHERE a.Upload = 0 AND b.JumlahBayar > 0 AND NoUrut = '" & rowTransaksi("No Transaksi") & "' AND JenisBayar = 'TAGIHAN' ) AS t1" & _
                    '                           " GROUP BY t1.JenisBayar")
                Case "LAB"
                    tblDetailTransaksi = GetDataLaboratorium(rowTransaksi("No Transaksi"))

                    'tblDetailTransaksi = ReadSQL("SELECT b.JenisBayar, b.JumlahBayar - b.Kembali AS 'JumlahTagihan' FROM TransaksiLab a LEFT JOIN TransaksiLabBayar b ON a.TransLabID = b.TransLabID WHERE a.Upload = 0 AND b.JumlahBayar > 0 AND NoUrut = '" & rowTransaksi("No Transaksi") & "' AND JenisBayar = 'TAGIHAN'")
            End Select

            If tblDetailTransaksi.Rows.Count > 0 Then
                Dim listRefferenceID As New List(Of String)

                For Each rowDetailTransaksi As DataRow In tblDetailTransaksi.Rows
                    ' Set ID Lokasi GL
                    Dim tblMasterJurnal As New DataTable
                    tblMasterJurnal = ReadThemysql("SELECT * FROM MasterLokasiJurnal a WHERE a.KodeLokasi = '" & kodeLokasiKlinik & "' AND a.KeteranganPoli = '" & rowDetailTransaksi("JenisPoli") & "'", DB_Omset)
                    Dim rowDataJurnal As DataRow = tblMasterJurnal.Rows(0)
                    Dim idLokasiJurnal As String = rowDataJurnal("KodeLokasiJurnal")
                    Dim keteranganLokasiJurnal As String = rowDataJurnal("KeteranganLokasi") & " (" & rowDataJurnal("KeteranganPoli") & ") "

                    ' Set Flag / Refference
                    Dim refferenceID As String = GetUUID()

                    ' Set Mesin EDC
                    Dim mesinEDC As String = rowDetailTransaksi("mesin").ToString.Trim
                    Dim keteranganMesinEDC As String = " "
                    Dim coaMesinEDC As String = ""
                    If rowDetailTransaksi("JenisBayar").ToString = "DEBET" Or rowDetailTransaksi("JenisBayar").ToString = "CARD" Then
                        ' Set Keterangan Mesin EDC
                        If rowDetailTransaksi("mesin").ToString.Trim <> "" Then
                            keteranganMesinEDC = " " & rowDetailTransaksi("mesin").ToString.Trim & " "
                        End If

                        ' Set COA Mesin EDC
                        If mesinEDC = "BCA" Then
                            coaMesinEDC = ReadThemysqlNIK("SELECT a.KodeAkun FROM MasterCoaJurnal a WHERE a.NamaAkun = 'Piutang BCA'", DB_Omset)
                        ElseIf mesinEDC = "MANDIRI" Then
                            coaMesinEDC = ReadThemysqlNIK("SELECT a.KodeAkun FROM MasterCoaJurnal a WHERE a.NamaAkun = 'Piutang MANDIRI'", DB_Omset)
                        ElseIf mesinEDC = "CIMB" Or mesinEDC = "NIAGA" Then
                            coaMesinEDC = ReadThemysqlNIK("SELECT a.KodeAkun FROM MasterCoaJurnal a WHERE a.NamaAkun = 'Piutang CIMB'", DB_Omset)
                        ElseIf mesinEDC.Contains("QRIS") = True Then
                            coaMesinEDC = ReadThemysqlNIK("SELECT a.KodeAkun FROM MasterCoaJurnal a WHERE a.NamaAkun = 'Piutang QRIS'", DB_Omset)
                        End If
                    End If

                    ' Set Keterangan Jenis Bayar
                    Dim keteranganJenisBayar As String = ""
                    If rowDetailTransaksi("JenisBayar").ToString = "TUNAI" Then
                        keteranganJenisBayar = "Tunai"
                    ElseIf rowDetailTransaksi("JenisBayar").ToString = "DEBET" Then
                        keteranganJenisBayar = "Debet"
                    ElseIf rowDetailTransaksi("JenisBayar").ToString = "CARD" Then
                        keteranganJenisBayar = "Kredit"
                    ElseIf rowDetailTransaksi("JenisBayar").ToString = "TAGIHAN" Then
                        keteranganJenisBayar = "Tagihan"
                    End If

                    ' Set Keterangan Jurnal
                    Dim keteranganJurnal As String = "CANCEL - TRANSAKSI " & keteranganJenisBayar.ToUpper() & keteranganMesinEDC.ToUpper() & keteranganLokasiJurnal & " " & Format(rowDetailTransaksi("Tgl Transaksi"), "dd/MM/yyyy") & " (NO. TRANSAKSI : " & rowTransaksi("No Transaksi") & ")"

                    ' Kirim Jurnal Cancel
                    If keteranganJenisBayar = "Tagihan" Then
                        WriteThemysql("SELECT F_MakeUMH('" & refferenceID & "', 'out', '', '" & Format(rowDetailTransaksi("Tgl Transaksi"), "yyyyMMdd") & "', '" & rowDataJurnal("KodeCoaPiutangPending").ToString() & "', '" & rowDataJurnal("KodeCoaPendapatan").ToString() & "', 'IDR', 1, " & CDbl(rowDetailTransaksi("JumlahBayar")) & ", '" & keteranganJurnal.ToUpper() & "', '1', 1, '', '" & keteranganJurnal.ToUpper() & "', '', '', '" & idLokasiJurnal & "', 4, " & CDbl(rowDetailTransaksi("JumlahBayar")) & ", 'K')", DB_Jurnal)
                    ElseIf keteranganJenisBayar = "Tunai" Then
                        WriteThemysql("SELECT F_MakeUMH('" & refferenceID & "', 'out', '', '" & Format(rowDetailTransaksi("Tgl Transaksi"), "yyyyMMdd") & "', '" & rowDataJurnal("KodeCoaPendapatanTunai").ToString() & "', '" & rowDataJurnal("KodeCoaPendapatan").ToString() & "', 'IDR', 1, " & CDbl(rowDetailTransaksi("JumlahBayar")) & ", '" & keteranganJurnal.ToUpper() & "', '1', 1, '', '" & keteranganJurnal.ToUpper() & "', '', '', '" & idLokasiJurnal & "', 4, " & CDbl(rowDetailTransaksi("JumlahBayar")) & ", 'K')", DB_Jurnal)
                    ElseIf keteranganJenisBayar = "Debet" Or keteranganJenisBayar = "Kredit" Then
                        WriteThemysql("SELECT F_MakeUMH('" & refferenceID & "', 'out', '', '" & Format(rowDetailTransaksi("Tgl Transaksi"), "yyyyMMdd") & "', '" & coaMesinEDC & "', '" & rowDataJurnal("KodeCoaPendapatan").ToString() & "', 'IDR', 1, " & CDbl(rowDetailTransaksi("JumlahBayar")) & ", '" & keteranganJurnal.ToUpper() & "', '1', 1, '', '" & keteranganJurnal.ToUpper() & "', '', '', '" & idLokasiJurnal & "', 4, " & CDbl(rowDetailTransaksi("JumlahBayar")) & ", 'K')", DB_Jurnal)
                    End If

                    ' Insert Log Cancel
                    WriteSQL("INSERT INTO LogJurnalKeuangan (JurnalFlag, JurnalDate, JurnalBy, Status, JenisPoli, JenisTransaksi) VALUES ('" & refferenceID & "', GETDATE(), '" & userInput & "', '" & keteranganJurnal & "', '" & rowDetailTransaksi("JenisPoli").ToString & "', '" & rowDetailTransaksi("JenisTransaksi").ToString & "')", 4)

                    ' Set TransaksiID Array
                    listRefferenceID.Add(refferenceID)
                Next

                ' Set Flag Jurnal
                Select Case rowTransaksi("JenisTransaksi")
                    Case "POLI"
                        WriteSQL("UPDATE TransaksiPoli SET FlagJurnalCancel = '" & String.Join(",", listRefferenceID.ToArray()) & "' WHERE NoUrut = '" & rowTransaksi("No Transaksi") & "'", 4)
                    Case "GIGI"
                        WriteSQL("UPDATE TransaksiGigi SET FlagJurnalCancel = '" & String.Join(",", listRefferenceID.ToArray()) & "' WHERE NoUrut = '" & rowTransaksi("No Transaksi") & "'", 4)
                    Case "LAB"
                        WriteSQL("UPDATE TransaksiLab SET FlagJurnalCancel = '" & String.Join(",", listRefferenceID.ToArray()) & "' WHERE NoUrut = '" & rowTransaksi("No Transaksi") & "'", 4)
                End Select
            End If
        Next
    End Sub

    Function GetDataPoliUmum(ByVal noTransaksi As String) As DataTable
        Dim tglTransaksiAwal As Date = DateTimePickerTanggalTransaksiAwal.Value
        Dim tglTransaksiAkhir As Date = DateTimePickerTanggalTransaksiAkhir.Value
        Dim tblResult As New DataTable

        Dim query As New StringBuilder()

        query.AppendLine("WITH FilteredTransPoli AS (")
        query.AppendLine("    SELECT TransPoliID")
        query.AppendLine("    FROM TransaksiPoli")
        query.AppendLine("    WHERE FlagJurnalCancel IS NULL AND Upload = 1 AND Deleted = 1 AND NoUrut = '" & noTransaksi & "'")
        query.AppendLine(")")
        query.AppendLine("SELECT SUM(tblBayar.JumlahBayar - tblBayar.Kembali) AS 'JumlahBayar', tblBayar.JenisBayar, tblBayar.kartu, tblBayar.mesin, d.JenisPoli, d.JenisTransaksi,")
        query.AppendLine("       CONVERT(DATE, t.TglPoli) AS 'Tgl Transaksi'")
        query.AppendLine("FROM (")
        query.AppendLine("    SELECT tb.TransPoliID, tb.JenisBayar, tb.JumlahBayar, tb.Kembali, tb.kartu, tb.mesin")
        query.AppendLine("    FROM TransaksiPoliBayar tb")
        query.AppendLine("    INNER JOIN FilteredTransPoli ft ON tb.TransPoliID = ft.TransPoliID")
        query.AppendLine("    WHERE tb.JumlahBayar > 0 AND tb.JenisBayar IN ('TAGIHAN', 'TUNAI', 'DEBET', 'CARD')")
        query.AppendLine("    UNION ALL")
        query.AppendLine("    SELECT tba.TransPoliID, tba.JenisBayar, tba.JumlahBayar, tba.Kembali, tba.kartu, tba.mesin")
        query.AppendLine("    FROM TransaksiPoliBayarAwal tba")
        query.AppendLine("    INNER JOIN FilteredTransPoli ft ON tba.TransPoliID = ft.TransPoliID")
        query.AppendLine("    WHERE tba.JumlahBayar > 0 AND tba.JenisBayar IN ('TAGIHAN', 'TUNAI', 'DEBET', 'CARD')")
        query.AppendLine(") AS tblBayar")
        query.AppendLine("LEFT JOIN TransaksiPoli t ON tblBayar.TransPoliID = t.TransPoliID")
        query.AppendLine("LEFT JOIN TransaksiDetail d ON t.NoUrut = d.NoUrut")
        query.AppendLine("GROUP BY CONVERT(DATE, t.TglPoli), d.JenisPoli, d.JenisTransaksi, tblBayar.JenisBayar, tblBayar.kartu, tblBayar.mesin")

        tblResult = ReadSQL(query.ToString())

        Return tblResult
    End Function

    Function GetDataPoliGigi(ByVal noTransaksi As String) As DataTable
        Dim tglTransaksiAwal As Date = DateTimePickerTanggalTransaksiAwal.Value
        Dim tglTransaksiAkhir As Date = DateTimePickerTanggalTransaksiAkhir.Value
        Dim tblResult As New DataTable

        Dim query As New StringBuilder()

        query.AppendLine("WITH FilteredTransGigi AS (")
        query.AppendLine("    SELECT TransGigiID")
        query.AppendLine("    FROM TransaksiGigi")
        query.AppendLine("    WHERE FlagJurnalCancel IS NULL AND Upload = 1 AND Deleted = 1 AND NoUrut = '" & noTransaksi & "'")
        query.AppendLine(")")
        query.AppendLine("SELECT")
        query.AppendLine("    SUM(tblBayar.JumlahBayar - tblBayar.Kembali) AS 'JumlahBayar',")
        query.AppendLine("    tblBayar.JenisBayar, tblBayar.kartu, tblBayar.mesin,")
        query.AppendLine("    d.JenisPoli, d.JenisTransaksi,")
        query.AppendLine("    CONVERT(DATE, t.TglGigi) AS 'Tgl Transaksi'")
        query.AppendLine("FROM (")
        query.AppendLine("    SELECT tb.TransGigiID, tb.JenisBayar, tb.JumlahBayar, tb.Kembali, tb.kartu, tb.mesin")
        query.AppendLine("    FROM TransaksiGigiBayar tb")
        query.AppendLine("    INNER JOIN FilteredTransGigi ft ON tb.TransGigiID = ft.TransGigiID")
        query.AppendLine("    WHERE tb.JumlahBayar > 0 AND tb.JenisBayar IN ('TAGIHAN', 'TUNAI', 'DEBET', 'CARD')")
        query.AppendLine("    UNION ALL")
        query.AppendLine("    SELECT tba.TransGigiID, tba.JenisBayar, tba.JumlahBayar, tba.Kembali, tba.kartu, tba.mesin")
        query.AppendLine("    FROM TransaksiGigiBayarAwal tba")
        query.AppendLine("    INNER JOIN FilteredTransGigi ft ON tba.TransGigiID = ft.TransGigiID")
        query.AppendLine("    WHERE tba.JumlahBayar > 0 AND tba.JenisBayar IN ('TAGIHAN', 'TUNAI', 'DEBET', 'CARD')")
        query.AppendLine(") AS tblBayar")
        query.AppendLine("LEFT JOIN TransaksiGigi t ON tblBayar.TransGigiID = t.TransGigiID")
        query.AppendLine("LEFT JOIN TransaksiDetail d ON t.NoUrut = d.NoUrut")
        query.AppendLine("GROUP BY CONVERT(DATE, t.TglGigi), d.JenisPoli, d.JenisTransaksi, tblBayar.JenisBayar, tblBayar.kartu, tblBayar.mesin")

        tblResult = ReadSQL(query.ToString())

        Return tblResult
    End Function

    Function GetDataLaboratorium(ByVal noTransaksi As String) As DataTable
        Dim tglTransaksiAwal As Date = DateTimePickerTanggalTransaksiAwal.Value
        Dim tglTransaksiAkhir As Date = DateTimePickerTanggalTransaksiAkhir.Value
        Dim tblResult As New DataTable

        Dim query As New StringBuilder()

        query.AppendLine("WITH FilteredTransLab AS (")
        query.AppendLine("    SELECT TransLabID")
        query.AppendLine("    FROM TransaksiLab")
        query.AppendLine("    WHERE FlagJurnalCancel IS NULL AND Upload = 1 AND Deleted = 1 AND NoUrut = '" & noTransaksi & "'")
        query.AppendLine(")")
        query.AppendLine("SELECT")
        query.AppendLine("    SUM(tblBayar.JumlahBayar - tblBayar.Kembali) AS 'JumlahBayar',")
        query.AppendLine("    tblBayar.JenisBayar, tblBayar.kartu, tblBayar.mesin,")
        query.AppendLine("    d.JenisPoli, d.JenisTransaksi,")
        query.AppendLine("    CONVERT(DATE, t.TglLab) AS 'Tgl Transaksi'")
        query.AppendLine("FROM (")
        query.AppendLine("    SELECT tb.TransLabID, tb.JenisBayar, tb.JumlahBayar, tb.Kembali, tb.kartu, tb.mesin")
        query.AppendLine("    FROM TransaksiLabBayar tb")
        query.AppendLine("    INNER JOIN FilteredTransLab ft ON tb.TransLabID = ft.TransLabID")
        query.AppendLine("    WHERE tb.JumlahBayar > 0 AND tb.JenisBayar IN ('TAGIHAN', 'TUNAI', 'DEBET', 'CARD')")
        query.AppendLine(") AS tblBayar")
        query.AppendLine("LEFT JOIN TransaksiLab t ON tblBayar.TransLabID = t.TransLabID")
        query.AppendLine("LEFT JOIN TransaksiDetail d ON t.NoUrut = d.NoUrut")
        query.AppendLine("GROUP BY CONVERT(DATE, t.TglLab), d.JenisPoli, d.JenisTransaksi, tblBayar.JenisBayar, tblBayar.kartu, tblBayar.mesin")

        tblResult = ReadSQL(query.ToString())

        Return tblResult
    End Function

    Private Sub ButtonFindData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFindData.Click
        Try
            CariDataTransaksi()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub CariDataTransaksi()
        GridControlTransaksi.DataSource = Nothing
        Dim tblTransaksi As New DataTable

        Dim query As New StringBuilder()

        query.AppendLine("SELECT a.JenisTransaksi, c.KodeBPJS, a.TanggalTransaksi, b.NoKartuBPJS, a.NoUrutBPJS, a.NoKunjunganBPJS, ")
        query.AppendLine("       a.NoTransaksi AS 'ID', a.NoUrut AS 'No Transaksi', ")
        query.AppendLine("       b.NoRekamMedis AS 'No. RM', b.Nama, a.JenisPoli AS 'PoliTujuan',")
        query.AppendLine("       CASE WHEN a.DeletedDate IS NULL THEN 0 ELSE 1 END AS StatusDelete,")
        query.AppendLine("       CASE WHEN a.DeletedDate IS NULL THEN '' ELSE 'DELETED' END AS 'Status'")
        query.AppendLine("FROM TransaksiDetail a")
        query.AppendLine("LEFT JOIN MasterPasien b ON a.IDInternet = b.NoRekamMedis")
        query.AppendLine("LEFT JOIN MasterPoliTujuan c ON c.NamaPoli = a.JenisPoli")
        query.AppendLine("WHERE CONVERT(DATE, a.TanggalTransaksi) = '" & Format(DateTimePickerTanggalTransaksiAwal.Value, "yyyy-MM-dd") & "'")
        query.AppendLine("ORDER BY TransaksiID DESC")

        tblTransaksi = ReadSQL(query.ToString())

        For Each Tcol As DataColumn In tblTransaksi.Columns
            Tcol.ReadOnly = True
        Next

        insertRowToTbls(tblTransaksi, "typchecked", "Checked")
        tblTransaksi.Columns("Checked").ReadOnly = False
        tblTransaksi.Columns("Checked").ReadOnly = False

        For Each rowTransaksi As DataRow In tblTransaksi.Rows
            If rowTransaksi("StatusDelete").ToString = "1" Then
                rowTransaksi("Checked") = True
            End If
        Next
        tblTransaksi.AcceptChanges()

        GridControlTransaksi.DataSource = tblTransaksi
        GridViewDataTransaksi.BestFitColumns()
        GridViewDataTransaksi.Columns("ID").Visible = False
        GridViewDataTransaksi.Columns("StatusDelete").Visible = False
        GridViewDataTransaksi.Columns("NoUrutBPJS").Visible = False
        GridViewDataTransaksi.Columns("NoKunjunganBPJS").Visible = False
        GridViewDataTransaksi.Columns("NoKartuBPJS").Visible = False
        GridViewDataTransaksi.Columns("TanggalTransaksi").Visible = False
        GridViewDataTransaksi.Columns("KodeBPJS").Visible = False

        If tblTransaksi.Rows.Count = 0 Then MsgBox("Data tidak ditemukan.", MsgBoxStyle.Exclamation, "Warning!")
    End Sub

    Private Sub ButtonHapusData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonHapusData.Click
        Try
            HapusDataTransaksi()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub HapusDataTransaksi()
        If ValidasiDataTransaksi() = True Then
            Dim urlPcare As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'pcare_base_url'")
            Dim uriBPJS As String = ""

            Dim jumlahData As Integer = 0

            Dim tblTransaksi As DataTable = GridControlTransaksi.DataSource
            tblTransaksi.AcceptChanges()

            For Each rowTransaksi As DataRow In tblTransaksi.Select("[Checked]=True")
                If rowTransaksi("StatusDelete").ToString = "0" Then
                    ' Delete Data PCare BPJS
                    If Not String.IsNullOrEmpty(rowTransaksi("NoKunjunganBPJS").ToString()) Then
                        uriBPJS = urlPcare + "kunjungan/" & rowTransaksi("NoKunjunganBPJS").ToString()
                        Dim responseDelete As String = DeleteDataBPJSv4(uriBPJS)
                    ElseIf Not String.IsNullOrEmpty(rowTransaksi("NoUrutBPJS").ToString()) Then
                        uriBPJS = urlPcare + "pendaftaran/peserta/" & rowTransaksi("NoKartuBPJS").ToString() & "/tglDaftar/" & Format(rowTransaksi("TanggalTransaksi"), "dd-MM-yyyy") & "/noUrut/" & rowTransaksi("NoUrutBPJS").ToString() & "/kdPoli/" & rowTransaksi("KodeBPJS").ToString()
                        Dim responseDelete As String = DeleteDataBPJSv4(uriBPJS)
                    End If

                    ' Penyesuaian Kuota Paket Tindakan (Jika Ada)
                    If CheckSQL("SELECT * FROM TransaksiPaketTindakan WHERE NoTransaksi = '" & rowTransaksi("No Transaksi") & "'") = True Then
                        ' Hapus Paket Tindakan (Jika Transaksi Pembelian Paket)
                        WriteSQL("UPDATE TransaksiPaketTindakan SET DeletedBy = '" & userInput & "', DeletedDate = GETDATE() WHERE NoTransaksi = '" & rowTransaksi("No Transaksi") & "'", 4)
                    ElseIf CheckSQL("SELECT * FROM LogPenggunaanPaket WHERE NoTransaksi = '" & rowTransaksi("No Transaksi") & "' AND DeletedDate IS NULL") = True Then
                        ' Tambah Kuota Paket Tindakan
                        WriteSQL("UPDATE TransaksiPaketTindakan SET Kuota = Kuota + 1 WHERE KodeVoucher IN (SELECT KodeVoucher FROM LogPenggunaanPaket WHERE NoTransaksi IN ('" & rowTransaksi("No Transaksi") & "'))", 4)
                        WriteSQL("UPDATE LogPenggunaanPaket SET DeletedBy = '" & userInput & "', DeletedDate = GETDATE() WHERE NoTransaksi = '" & rowTransaksi("No Transaksi") & "' AND DeletedDate IS NULL", 4)
                    End If

                    ' Insert Data TransaksiCancel
                    WriteSQL("INSERT INTO TransaksiCancel (JenisTransaksi,NoUrut,Alasan,CanceledBy,CanceledDate) " & _
                             "VALUES('" & rowTransaksi("JenisTransaksi").ToString() & "','" & rowTransaksi("No Transaksi").ToString() & "','" & TextBoxAlasan.Text & "','" & userInput & "', GETDATE())", 4)

                    ' Set Status Delete TransaksiPoli
                    Select Case rowTransaksi("JenisTransaksi").ToString()
                        Case "POLI"
                            WriteSQL("UPDATE TransaksiPoli SET Deleted = 1, DeletedBy = '" & userInput & "', DeletedDate = GETDATE() WHERE TransPoliID = " & rowTransaksi("ID").ToString() & " AND CONVERT(DATE, TglPoli) = '" & Format(rowTransaksi("TanggalTransaksi"), "MM/dd/yyy") & "'", 4)
                        Case "LAB"
                            WriteSQL("UPDATE TransaksiLab SET Deleted = 1 , DeletedBy = '" & userInput & "', DeletedDate = GETDATE() WHERE TransLabID = " & rowTransaksi("ID").ToString() & " AND CONVERT(DATE, Tgllab)='" & Format(rowTransaksi("TanggalTransaksi"), "MM/dd/yyy") & "'", 4)
                        Case "GIGI"
                            WriteSQL("UPDATE TransaksiGigi SET Deleted = 1 , DeletedBy = '" & userInput & "', DeletedDate = GETDATE() WHERE TransGigiID = " & rowTransaksi("ID").ToString() & "  AND CONVERT(DATE, TglGigi)='" & Format(rowTransaksi("TanggalTransaksi"), "MM/dd/yyy") & "'", 4)
                    End Select

                    ' Delete Data Database Online (Jika Sudah Upload)
                    WriteThemysql("DELETE FROM acctranstagihandetail WHERE loc = '" & kodeLokasiKlinik & "' AND incjenis = '" & rowTransaksi("JenisTransaksi").ToString() & "' AND DATE(inctgl) = '" & Format(rowTransaksi("TanggalTransaksi"), "yyyyMMdd") & "' AND inctransid = " & rowTransaksi("ID").ToString() & "", DB_Keuangan)
                    WriteThemysql("DELETE FROM acctranspendapatandetail WHERE loc = '" & kodeLokasiKlinik & "' AND incjenis = '" & rowTransaksi("JenisTransaksi").ToString() & "' AND DATE(inctgl) = '" & Format(rowTransaksi("TanggalTransaksi"), "yyyyMMdd") & "' AND inctransid = " & rowTransaksi("ID").ToString() & "", DB_Keuangan)

                    ' Set Status Delete TransaksiDetail
                    WriteSQL("UPDATE TransaksiDetail SET DeletedBy = '" & userInput & "', DeletedDate = GETDATE() WHERE NoTransaksi = " & rowTransaksi("ID").ToString() & " AND JenisTransaksi = '" & rowTransaksi("JenisTransaksi").ToString() & "'", 4)

                    jumlahData = jumlahData + 1
                End If
            Next

            If jumlahData > 0 Then
                ' Create Jurnal Cancel
                Dim AutoJurnal As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='AutoJurnal'")
                If AutoJurnal.Trim = "Yes" Then SendingJurnalCancel()

                MsgBox("" & jumlahData & " Transaksi Telah Berhasil Dihapus.", MsgBoxStyle.Information, "Success!")
            Else
                MsgBox("Tidak ada data yang dihapus.", MsgBoxStyle.Exclamation, "Nothing!")
            End If

        CariDataTransaksi()
        End If
    End Sub

    Private Sub ButtonClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClose.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SendingJurnalCancel()
    End Sub
End Class