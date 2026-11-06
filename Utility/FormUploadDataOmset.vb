Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Drawing

Imports Excel = Microsoft.Office.Interop.Excel
Imports Microsoft.Office
Imports Microsoft.Office.Interop
Imports System.Text

Imports Newtonsoft.Json
Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient

Public Class FormUploadDataOmset
    Dim thread As System.Threading.Thread

    ' Guard re-entrancy: cegah double-click / proses paralel yang membuat data & jurnal dobel
    Private isBusy As Boolean = False

    ' Set Connection
    Private DB_Keuangan As TLcon
    Private DB_Keuangan2 As TLcon
    Private DB_Jurnal As TLcon
    Private DB_Omset As TLcon

    ' Set Variabel Private
    Private formName As String = "UPLOAD OMSET"
    Private tipeJurnal As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'tipe_jurnal'")
    Private kodeLokasiKlinik As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NoPoli'")
    Private autoJurnal As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'AutoJurnal'")
    Private userInput As String = PoliKlinik.Lbluser.Text

    ' Kategori omset. Dipakai di query (literal SQL), grid, keterangan jurnal, dan lookup
    ' MasterLokasiJurnal — disatukan di sini supaya tidak ada literal yang menyimpang.
    Private Const KATEGORI_NON_PAKET As String = "NON PAKET"
    Private Const KATEGORI_BELI_PAKET As String = "PEMBELIAN PAKET"
    Private Const KATEGORI_PAKAI_PAKET As String = "PEMAKAIAN PAKET"

    ' ==========================================================================================
    ' CUT-OFF SKEMA PENDAPATAN DIBAYAR DIMUKA (deferred revenue) UNTUK PAKET
    '
    ' Patokannya TANGGAL PEMBELIAN paket, bukan tanggal pemakaian — dan dipakai oleh KEDUA sisi:
    '   - pembelian sebelum cut-off  : dikredit ke Pendapatan seperti skema lama (tidak ditangguhkan)
    '   - pemakaian dari paket yang dibeli sebelum cut-off : TIDAK dijurnal sama sekali
    ' Alasannya: pendapatan paket lama SUDAH diakui penuh saat pembelian, jadi tidak ada saldo
    ' titipan yang bisa dilepas. Kalau pemakaiannya tetap dijurnal, akun Pendapatan Dibayar Dimuka
    ' akan bersaldo DEBIT (kewajiban negatif) — terbukti di uji 17 Juli 2026: 18 dari 22 pemakaian
    ' berasal dari paket yang dibeli jauh sebelumnya (terjauh 6 Februari), dan akun 21010207
    ' langsung minus 1.107.273.
    '
    ' Memakai tanggal PEMAKAIAN sebagai cut-off TIDAK cukup: paket yang dibeli sebelum cut-off
    ' masih akan dipakai berbulan-bulan sesudahnya (masa aktif paket panjang).
    ' ==========================================================================================
    Private cutOffPaketCache As Date = Date.MinValue

    ' Dibaca dari MsConfig supaya tidak ada tanggal ter-hardcode. Bila key belum ada atau isinya
    ' bukan tanggal sah, fitur dianggap BELUM AKTIF (Date.MaxValue): pembelian paket dijurnal
    ' seperti biasa dan pemakaian tidak dijurnal sama sekali. Fail-safe disengaja — lebih baik
    ' tidak berbuat apa-apa daripada menjurnal separuh jalan lalu meninggalkan saldo menggantung.
    Private Function TglCutOffPaket() As Date
        If cutOffPaketCache = Date.MinValue Then
            Dim nilai As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'TglMulaiJurnalPaket'")
            Dim hasil As Date
            If Date.TryParse(nilai, hasil) Then
                cutOffPaketCache = hasil.Date
            Else
                cutOffPaketCache = Date.MaxValue
            End If
        End If
        Return cutOffPaketCache
    End Function

    Private Sub PanelTop_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelTop.Paint
        Try
            e.Graphics.DrawString(formName, New Font("Arial", 12, FontStyle.Bold), Brushes.White, New Point(10, 10))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

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

        ' Set DB Jurnal
        DB_Jurnal.Tip = Utility.GetConfig("ServerJurnal_IP")
        DB_Jurnal.Tid = Utility.GetConfig("ServerJurnal_UserID")
        DB_Jurnal.Tpass = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerJurnal_Password"), "albert")
        DB_Jurnal.Tdb = Utility.GetConfig("ServerJurnal_DB")

        ' Set DB Omset (mitramedicare_omset_keuangan)
        DB_Omset.Tip = serverOnline_IP
        DB_Omset.Tid = serverOnline_UserID
        DB_Omset.Tpass = serverOnline_Password
        DB_Omset.Tdb = Utility.GetConfig("ServerOnlineOmset_DB")
    End Sub

    ' === Helper koneksi MySQL yang MELAPOR error (tidak ditelan seperti WriteThemysql) ===
    Private Function BuildMySqlConnString(ByVal conn As TLcon) As String
        Return "datasource=" & conn.Tip & ";username=" & conn.Tid & ";password=" & conn.Tpass & ";database=" & conn.Tdb
    End Function

    ' Panggil F_MakeUMH di server jurnal dan PASTIKAN jurnalnya benar-benar terbentuk.
    '
    ' PENTING: F_MakeUMH tidak melempar error saat menolak — ia mengembalikan STRING pesan dan
    ' tidak membuat jurnal apa pun. Yang sudah terbukti di server: bila periode akuntansi sudah
    ' ditutup (ada di tabel `_close`), fungsi langsung `RETURN 'Periode Clossed'` sebelum INSERT
    ' apa pun. Dengan ExecuteNonQuery nilai itu tidak terbaca, MySQL pun tidak error, sehingga
    ' pemanggil mengira jurnal sukses lalu men-set FlagJurnalHarian* -> baris tak akan muncul lagi
    ' di kiriman berikutnya -> jurnal HILANG permanen tanpa satu pun peringatan.
    ' Karena itu nilai kembalian WAJIB dibaca: hanya nomor 'UMH-....' yang berarti jurnal jadi.
    Private Function BuatJurnalUMH(ByVal sql As String, ByVal conn As TLcon) As String
        Dim hasil As String = ""

        Using mysqlConn As New MySqlConnection(BuildMySqlConnString(conn))
            mysqlConn.Open()
            Using cmd As New MySqlCommand(sql, mysqlConn)
                cmd.CommandTimeout = 120
                Dim nilai As Object = cmd.ExecuteScalar()
                If nilai IsNot Nothing AndAlso Not Convert.IsDBNull(nilai) Then hasil = nilai.ToString().Trim()
            End Using
        End Using

        If hasil.StartsWith("UMH-") = False Then
            Throw New Exception("Server jurnal menolak, jurnal TIDAK dibuat. Jawaban server: '" & hasil & "'")
        End If

        Return hasil
    End Function

    ' Eksekusi beberapa perintah dalam SATU transaksi MySQL (all-or-nothing). Rollback + Throw bila gagal.
    Private Sub ExecuteMySqlTransaction(ByVal conn As TLcon, ByVal ParamArray statements As String())
        Using mysqlConn As New MySqlConnection(BuildMySqlConnString(conn))
            mysqlConn.Open()
            Dim tx As MySqlTransaction = mysqlConn.BeginTransaction()
            Try
                For Each sql As String In statements
                    If Not String.IsNullOrEmpty(sql) Then
                        Using cmd As New MySqlCommand(sql, mysqlConn, tx)
                            cmd.CommandTimeout = 120
                            cmd.ExecuteNonQuery()
                        End Using
                    End If
                Next
                tx.Commit()
            Catch
                tx.Rollback()
                Throw
            End Try
        End Using
    End Sub

    ' Baca tabel dari MySQL dan MELEMPAR bila gagal. Pengganti ReadThemysql untuk query yang
    ' hasil kosongnya punya arti bisnis: ReadThemysql menelan error koneksi lalu mengembalikan
    ' tabel kosong, sehingga "server tidak terjangkau" tak bisa dibedakan dari "data tidak ada".
    Private Function BacaTabelMySqlChecked(ByVal sql As String, ByVal conn As TLcon) As DataTable
        Dim hasil As New DataTable

        Using mysqlConn As New MySqlConnection(BuildMySqlConnString(conn) & ";Connection Timeout=15")
            mysqlConn.Open()
            Using cmd As New MySqlCommand(sql, mysqlConn)
                cmd.CommandTimeout = 60
                Using pembaca As MySqlDataReader = cmd.ExecuteReader()
                    hasil.Load(pembaca)
                End Using
            End Using
        End Using

        Return hasil
    End Function

    ' Cari nomor jurnal berdasarkan refferenceID yang kita kirim ke F_MakeUMH (server menyimpannya
    ' di kolom umh.oms). Dipakai SETELAH panggilan pembuatan jurnal gagal di sisi klien, untuk
    ' memastikan apakah server sebenarnya sudah terlanjur memproses.
    ' Mengembalikan "" bila jurnal memang belum ada; MELEMPAR bila pengecekannya sendiri gagal
    ' (status tidak diketahui — pemanggil harus memperingatkan operator, bukan menyuruh kirim ulang).
    Private Function CariNomorJurnal(ByVal refferenceID As String) As String
        Using mysqlConn As New MySqlConnection(BuildMySqlConnString(DB_Jurnal) & ";Connection Timeout=15")
            mysqlConn.Open()
            Using cmd As New MySqlCommand("SELECT umh FROM umh WHERE oms = '" & refferenceID & "' LIMIT 1", mysqlConn)
                cmd.CommandTimeout = 60
                Dim nilai As Object = cmd.ExecuteScalar()
                If nilai Is Nothing OrElse Convert.IsDBNull(nilai) Then Return ""
                Return nilai.ToString().Trim()
            End Using
        End Using
    End Function

    ' Jam server keuangan (BUKAN jam PC klien) — dipakai sebagai batas bawah pembersihan kiriman gagal,
    ' karena kolom createdate diisi NOW() oleh server. Jam PC yang meleset bisa membuat batas ini salah.
    Private Function WaktuServerKeuangan() As String
        Using mysqlConn As New MySqlConnection(BuildMySqlConnString(DB_Keuangan))
            mysqlConn.Open()
            Using cmd As New MySqlCommand("SELECT NOW()", mysqlConn)
                cmd.CommandTimeout = 60
                Return Format(CDate(cmd.ExecuteScalar()), "yyyy-MM-dd HH:mm:ss")
            End Using
        End Using
    End Function

    ' Bersihkan baris omset yang terlanjur masuk saat pengiriman gagal separuh jalan.
    ' Perlu karena tabel tujuan MyISAM -> ROLLBACK tidak berfungsi (lihat komentar di KirimOmsetHarian).
    ' Cakupan dibatasi TIGA lapis supaya tidak mungkin menyentuh kiriman lama atau cabang lain:
    '   1. loc = lokasi klinik ini saja
    '   2. hanya transaksi yang ikut pada batch ini
    '   3. hanya baris dengan createdate >= waktu mulai kirim (jam server)
    ' Melempar exception bila pembersihan sendiri gagal — pemanggil wajib memperingatkan operator.
    Private Function BersihkanOmsetGagal(ByVal daftarIdTransaksi As String, ByVal waktuMulai As String) As Integer
        If String.IsNullOrEmpty(daftarIdTransaksi) OrElse String.IsNullOrEmpty(waktuMulai) Then Return 0

        Dim jumlahDihapus As Integer = 0

        Using mysqlConn As New MySqlConnection(BuildMySqlConnString(DB_Keuangan))
            mysqlConn.Open()
            For Each namaTabel As String In New String() {"acctranspendapatandetail", "acctranstagihandetail"}
                Dim sqlHapus As String = "DELETE FROM " & namaTabel & _
                                         " WHERE loc = '" & kodeLokasiKlinik & "'" & _
                                         " AND createdate >= '" & waktuMulai & "'" & _
                                         " AND inctransid IN (" & daftarIdTransaksi & ")"
                Using cmd As New MySqlCommand(sqlHapus, mysqlConn)
                    cmd.CommandTimeout = 120
                    jumlahDihapus += cmd.ExecuteNonQuery()
                End Using
            Next
        End Using

        Return jumlahDihapus
    End Function

    ' Kunci/buka tombol + set status sibuk. Dipanggil SINKRON di UI thread saat klik, dan di Finally worker.
    Private Sub SetUiBusy(ByVal busy As Boolean)
        isBusy = busy
        ButtonKirimDataOmset.Enabled = Not busy
        ButtonKirimJurnalUlang.Enabled = Not busy
        ButtonSearchDataOmset.Enabled = Not busy
        If busy Then
            ButtonKirimDataOmset.BackColor = Color.FromArgb(225, 225, 225)
        Else
            ButtonKirimDataOmset.BackColor = Color.FromArgb(0, 100, 200)
        End If
    End Sub

    ' Tulis ke SQL Server lokal. MELEMPAR exception bila gagal; kembalikan jumlah baris terpengaruh.
    ' Beda dengan WriteSQLResult (yang menelan error & kembalikan 0 sehingga gagal vs 0-baris tak terbedakan).
    Private Function WriteSqlChecked(ByVal sql As String) As Integer
        Using con As New SqlConnection(PusatSQL.Con.ConnectionString)
            con.Open()
            Using cmd As New SqlCommand(sql, con)
                cmd.CommandTimeout = 120
                Return cmd.ExecuteNonQuery()
            End Using
        End Using
    End Function

    ' Cek apakah SATU server MySQL tujuan benar-benar bisa dihubungi: buka koneksi singkat lalu tutup.
    ' Lebih andal daripada ping ICMP ke Google — membuktikan service MySQL hidup + jaringan ke host tujuan OK
    ' (bukan sekadar "internet nyala"), dan tidak terhalang firewall yang memblokir ICMP.
    ' Timeout dipersingkat agar tidak menggantung lama bila server mati.
    Private Function CekKoneksiServer(ByVal conn As TLcon) As Boolean
        Try
            Using mysqlConn As New MySqlConnection(BuildMySqlConnString(conn) & ";Connection Timeout=8")
                mysqlConn.Open()
            End Using
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    ' Gerbang sebelum kirim: pastikan SEMUA server tujuan (Keuangan/Omset online + Jurnal) terjangkau.
    ' Menampilkan server mana yang bermasalah dan mengembalikan False bila ada yang tak dapat dihubungi.
    Private Function CekKoneksiServerKirim() As Boolean
        Dim serverBermasalah As New StringBuilder()

        If CekKoneksiServer(DB_Keuangan) = False Then
            serverBermasalah.AppendLine("- Server Keuangan/Omset (" & DB_Keuangan.Tip & ")")
        End If

        If CekKoneksiServer(DB_Jurnal) = False Then
            serverBermasalah.AppendLine("- Server Jurnal (" & DB_Jurnal.Tip & ")")
        End If

        If serverBermasalah.Length > 0 Then
            MsgBox("Tidak bisa mengirim: server tujuan berikut tidak dapat dihubungi." & vbCrLf & vbCrLf & _
                   serverBermasalah.ToString() & vbCrLf & _
                   "Periksa koneksi internet/VPN dan pastikan server aktif, lalu coba lagi.", _
                   MsgBoxStyle.Critical, "Koneksi Server Gagal")
            Return False
        End If

        Return True
    End Function

    Private Sub FormUploadDataOmset_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
        Me.MdiParent = PoliKlinik
        Me.Dock = DockStyle.Fill

        ' Set default tanggal transaksi awal & akhir ke H-1 (kemarin), sesuai aturan upload maksimal H-1
        Dim tglH1 As Date = DateTime.Now.AddDays(-1).Date
        DateTimePickerTanggalTransaksiAwal.Value = tglH1
        DateTimePickerTanggalTransaksiAkhir.Value = tglH1

        SetConnectionFromConfig()
        LabelProgress.ResetText()
    End Sub

    Private Sub ButtonClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClose.Click
        Me.Close()
    End Sub

    ' Cegah menutup form saat proses upload/jurnal masih berjalan (thread bisa mengakses kontrol yang sudah dispose -> crash)
    Private Sub FormUploadDataOmset_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If isBusy Then
            MsgBox("Proses upload/jurnal masih berjalan. Mohon tunggu hingga selesai sebelum menutup form.", MsgBoxStyle.Exclamation, "Sedang Proses")
            e.Cancel = True
        End If
    End Sub

    Function JumlahTransaksiPending() As Integer
        Dim query As New StringBuilder()

        query.AppendLine("SELECT COUNT(*) ")
        query.AppendLine("FROM ( ")
        query.AppendLine("    SELECT TransPoliID ")
        query.AppendLine("    FROM TransaksiPoli a ")
        query.AppendLine("    WHERE (CONVERT(DATE, TglPoli) BETWEEN '" & Format(DateTimePickerTanggalTransaksiAwal.Value, "yyyy-MM-dd") & "' AND '" & Format(DateTimePickerTanggalTransaksiAkhir.Value, "yyyy-MM-dd") & "') ")
        query.AppendLine("      AND Deleted = 0 ")
        query.AppendLine("      AND TransPoliID IN ( ")
        query.AppendLine("          SELECT TransPoliID ")
        query.AppendLine("          FROM TransaksiPoliDetail ")
        query.AppendLine("          WHERE StatusPembayaran = 'PENDING' AND DeletedDate IS NULL")
        query.AppendLine("      ) ")
        query.AppendLine("    UNION ALL ")
        query.AppendLine("    SELECT TransGigiID ")
        query.AppendLine("    FROM TransaksiGigi a ")
        query.AppendLine("    WHERE (CONVERT(DATE, TglGigi) BETWEEN '" & Format(DateTimePickerTanggalTransaksiAwal.Value, "yyyy-MM-dd") & "' AND '" & Format(DateTimePickerTanggalTransaksiAkhir.Value, "yyyy-MM-dd") & "') ")
        query.AppendLine("      AND Deleted = 0 ")
        query.AppendLine("      AND TransGigiID IN ( ")
        query.AppendLine("          SELECT TransPoliID ")
        query.AppendLine("          FROM TransaksiPoliDetail ")
        query.AppendLine("          WHERE StatusPembayaran = 'PENDING' AND DeletedDate IS NULL")
        query.AppendLine("      ) ")
        query.AppendLine(") AS CombinedResult;")

        Dim jumlahTransaksi As String = ReadSQLNIK(query.ToString())

        Return CDbl(jumlahTransaksi)
    End Function

    Private Function ValidasiDataUpload() As Boolean
        ' Cek sambungan internet
        If CheckInternetConnection() = False Then
            MessageBox.Show("Eror : Tidak ada koneksi internet.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Return False
        End If

        ' Validasi Tanggal Transaksi
        If DateTimePickerTanggalTransaksiAkhir.Value.Date > DateTime.Now.AddDays(-1).Date Then
            MessageBox.Show("Eror : Tanggal transaksi maksimal H-1.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            ' Kembalikan ke tanggal kemarin
            DateTimePickerTanggalTransaksiAkhir.Value = DateTime.Now.AddDays(-1)

            Return False
        End If

        ' Validasi transaksi pending
        If JumlahTransaksiPending() > 0 Then
            MessageBox.Show("Eror : Terdapat transaksi pending yang belum diselesaikan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Return False
        End If

        Return True
    End Function

    Private Sub ButtonSearchDataOmset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSearchDataOmset.Click
        Try
            If ValidasiDataUpload() = True Then
                ViewDataOmset()
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub ViewDataOmset()
        Dim tblPoliUmum As DataTable = GetDataUploadOmsetPoliUmum()
        Dim tblPoliGigi As DataTable = GetDataUploadOmsetPoliGigi()
        Dim tblLaboratorium As DataTable = GetDataUploadOmsetLaboratorium()

        ' Buat tabel gabungan dengan struktur yang sama
        Dim tblOmset As DataTable = tblPoliUmum.Clone()

        ' Gabungkan data dari kedua tabel
        tblOmset.Merge(tblPoliUmum)
        tblOmset.Merge(tblPoliGigi)
        tblOmset.Merge(tblLaboratorium)

        ' Pemakaian paket HANYA ikut di tampilan — sengaja tidak ada di KirimOmsetHarian,
        ' supaya tidak pernah terkirim/terjurnal (pendapatannya sudah diakui saat pembelian).
        Dim tblPemakaianPaket As DataTable = GetDataPemakaianPaket()
        tblOmset.Merge(tblPemakaianPaket)

        If tblOmset.Rows.Count > 0 Then
            For Each Tcol As DataColumn In tblOmset.Columns
                Tcol.ReadOnly = True
            Next

            GridControlTransaksi.DataSource = tblOmset
            GridViewTransaksi.Columns("JenisTransaksi").Visible = False

            ' Sebelum BestFitColumns: lebar kolom harus dihitung atas teks yang sudah berformat
            ' "Rp 32,750,000", bukan angka mentah — kalau tidak, nominalnya terpotong.
            PasangTotalOmset()

            ' Kelompokkan per kategori supaya tiga bagian itu langsung terbaca beserta subtotalnya
            GridViewTransaksi.Columns("Kategori").GroupIndex = 0
            GridViewTransaksi.ExpandAllGroups()
            GridViewTransaksi.BestFitColumns()

            LabelProgress.Text = RingkasanKategori(tblOmset)
        Else
            MsgBox("Tidak Ada Data.", MsgBoxStyle.Exclamation, "Warning")
        End If
    End Sub

    ' Format rupiah + sub total per kategori + grand total, seragam dengan grid Laporan Pendapatan
    ' di ReportPendapatanKlinik.
    '
    ' Keterangan "SUB TOTAL"/"GRAND TOTAL" ditaruh di kolom TEKS "Nama", angkanya tetap di kolom
    ' "TotalBayar". Kalau keterangan ditempel ke kolom nominal, teksnya lebih panjang daripada lebar
    ' kolom dan yang terpotong justru ANGKANYA.
    '
    ' Grid ini SUDAH dikelompokkan per Kategori (lihat ViewDataOmset), jadi sub totalnya langsung
    ' menjawab komentar "beserta subtotalnya" yang selama ini belum ada isinya.
    '
    ' "termasuk memo" pada grand total BUKAN hiasan: grid ini memuat PEMAKAIAN PAKET yang sengaja
    ' TIDAK ikut terkirim (pendapatannya sudah diakui saat pembelian), sehingga jumlah seluruh baris
    ' LEBIH BESAR daripada omset yang benar-benar diupload. Angka yang dikirim ada di LabelProgress
    ' (lihat RingkasanKategori) — jangan sampai operator merekonsiliasi ke angka yang salah.
    Private Sub PasangTotalOmset()
        GridViewTransaksi.OptionsView.ShowFooter = True
        ' Di XtraGrid 3.2.3 properti ini ada LANGSUNG di GridView, bukan di OptionsView seperti
        ' versi DevExpress yang lebih baru — jangan "dirapikan" ke OptionsView, tidak akan kompilasi.
        GridViewTransaksi.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways

        ' Dibersihkan dulu: sub ini jalan tiap kali tombol Cari ditekan, tanpa Clear item lama
        ' menumpuk sehingga satu kolom menampilkan angka yang sama berkali-kali.
        GridViewTransaksi.GroupSummary.Clear()

        Dim kolomNilai As DevExpress.XtraGrid.Columns.GridColumn = GridViewTransaksi.Columns("TotalBayar")
        kolomNilai.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        kolomNilai.DisplayFormat.FormatString = "Rp #,##0"
        kolomNilai.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        kolomNilai.MinWidth = 130

        With kolomNilai.SummaryItem
            .FieldName = "TotalBayar"
            .SummaryType = DevExpress.Data.SummaryItemType.Sum
            .DisplayFormat = "Rp {0:N0}"
        End With
        GridViewTransaksi.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "TotalBayar", kolomNilai, "Rp {0:N0}")

        Dim kolomLabel As DevExpress.XtraGrid.Columns.GridColumn = GridViewTransaksi.Columns("Nama")
        With kolomLabel.SummaryItem
            .FieldName = "Nama"
            .SummaryType = DevExpress.Data.SummaryItemType.Count
            .DisplayFormat = "GRAND TOTAL ({0} baris) - termasuk memo"
        End With
        GridViewTransaksi.GroupSummary.Add(DevExpress.Data.SummaryItemType.Count, "Nama", kolomLabel, "SUB TOTAL ({0} baris)")
    End Sub

    ' Ringkasan singkat per kategori. "Dikirim" dibedakan tegas dari "memo" supaya operator
    ' tidak salah kira bahwa nilai pemakaian paket ikut menambah omset yang diupload.
    Private Function RingkasanKategori(ByVal tblOmset As DataTable) As String
        Dim totalNonPaket As Double = 0
        Dim totalBeliPaket As Double = 0
        Dim totalPakaiPaket As Double = 0

        For Each rowOmset As DataRow In tblOmset.Rows
            Dim nilai As Double = CDbl(rowOmset("TotalBayar"))
            Select Case rowOmset("Kategori").ToString()
                Case KATEGORI_NON_PAKET : totalNonPaket += nilai
                Case KATEGORI_BELI_PAKET : totalBeliPaket += nilai
                Case KATEGORI_PAKAI_PAKET : totalPakaiPaket += nilai
            End Select
        Next

        Return "Dikirim: " & KATEGORI_NON_PAKET & " " & Format(totalNonPaket, "#,##0") & _
               "  +  " & KATEGORI_BELI_PAKET & " " & Format(totalBeliPaket, "#,##0") & _
               "  =  " & Format(totalNonPaket + totalBeliPaket, "#,##0") & _
               "   |   MEMO (tidak dikirim): " & KATEGORI_PAKAI_PAKET & " " & Format(totalPakaiPaket, "#,##0")
    End Function

    ' ==========================================================================================
    ' PEMISAHAN KATEGORI OMSET: "NON PAKET" vs "PEMBELIAN PAKET"
    '
    ' Kenapa harus dipecah proporsional, bukan sekadar dilabeli per transaksi: satu transaksi
    ' SERING berisi tindakan biasa DAN pembelian paket sekaligus (terukur di Poliklinik_HBOT:
    ' 2.701 dari 9.245 transaksi, ~29%). Sementara itu query omset menjumlahkan di level
    ' PEMBAYARAN (TransaksiPoliBayar), yang tidak tahu isi keranjangnya. Jadi nilai tiap
    ' pembayaran dibagi menurut porsi NettBayar di TransaksiPoliDetail.
    '
    ' Pembeda paket ada DUA tingkat, keduanya wajib:
    '   PaketID    = '0' -> tindakan biasa; GUID -> baris berkaitan paket.
    '   TindakanID = '0' -> baris PEMBELIAN paket (NamaTindakan = nama paket, NettBayar = harga paket);
    '                <>'0' -> baris PEMAKAIAN paket (tindakan yang ditarik dari paket).
    ' Baris PEMAKAIAN ikut NON PAKET di sini karena pendapatannya SUDAH diakui saat paket dibeli
    ' di transaksi lain; kalau dihitung sebagai paket, uang tunai transaksi ini tergeser labelnya.
    ' Terukur di Poliklinik_HBOT: 710 baris pembelian (695 cocok dengan TransaksiPaketTindakan pada
    ' transaksi yang sama) vs 5.366 baris pemakaian (0 cocok) senilai Rp 1,8 M.
    ' CATATAN: baris pemakaian TIDAK ber-NettBayar 0 — harganya terisi penuh, jadi jangan pakai
    ' NettBayar sebagai pembeda. Nilai memo pemakaian dihitung terpisah di GetDataPemakaianPaket
    ' (dari baris bayar VOUCHER), tidak dikirim/dijurnal.
    '
    ' Pembulatan: porsi NON PAKET dibulatkan, porsi PAKET = sisa (total - nonpaket). Dengan
    ' begitu penjumlahan kedua kategori SELALU sama persis dengan nilai pembayaran aslinya —
    ' kalau tidak, omset tidak akan cocok lagi dengan jurnal.
    ' ==========================================================================================
    Private Function SqlCteNilaiKategori() As String
        Dim cte As New StringBuilder()
        cte.AppendLine("NilaiKategori AS (")
        cte.AppendLine("    SELECT d.TransPoliID,")
        cte.AppendLine("           SUM(CASE WHEN ISNULL(d.PaketID, '0') = '0' OR ISNULL(d.TindakanID, '0') <> '0'")
        cte.AppendLine("                    THEN ISNULL(d.NettBayar, 0) ELSE 0 END) AS NilaiNonPaket,")
        cte.AppendLine("           SUM(ISNULL(d.NettBayar, 0)) AS NilaiTotal")
        cte.AppendLine("    FROM TransaksiPoliDetail d")
        cte.AppendLine("    WHERE d.DeletedDate IS NULL")
        cte.AppendLine("    GROUP BY d.TransPoliID")
        cte.AppendLine(")")
        Return cte.ToString()
    End Function

    ' Memecah SATU baris pembayaran menjadi maksimal dua baris kategori.
    ' NilaiTotal = 0 (detail tidak ada / semua nol) -> seluruhnya dianggap NON PAKET, jangan
    ' sampai uangnya hilang hanya karena detailnya tidak bisa dijadikan dasar pembagian.
    Private Function SqlCrossApplyKategori() As String
        Dim nilaiBayar As String = "CAST(tblBayar.JumlahBayar - tblBayar.Kembali AS decimal(18,2))"
        Dim porsiNonPaket As String = "ROUND(" & nilaiBayar & " * nk.NilaiNonPaket / nk.NilaiTotal, 0)"

        Dim apply As New StringBuilder()
        apply.AppendLine("CROSS APPLY (")
        apply.AppendLine("    SELECT '" & KATEGORI_NON_PAKET & "' AS Kategori,")
        apply.AppendLine("           CASE WHEN ISNULL(nk.NilaiTotal, 0) = 0 THEN " & nilaiBayar)
        apply.AppendLine("                ELSE " & porsiNonPaket & " END AS Nilai")
        apply.AppendLine("    UNION ALL")
        apply.AppendLine("    SELECT '" & KATEGORI_BELI_PAKET & "',")
        apply.AppendLine("           CASE WHEN ISNULL(nk.NilaiTotal, 0) = 0 THEN 0")
        apply.AppendLine("                ELSE " & nilaiBayar & " - " & porsiNonPaket & " END")
        apply.AppendLine(") AS kat")
        Return apply.ToString()
    End Function

    Function GetDataUploadOmsetPoliUmum() As DataTable
        Dim tglTransaksiAwal As Date = DateTimePickerTanggalTransaksiAwal.Value
        Dim tglTransaksiAkhir As Date = DateTimePickerTanggalTransaksiAkhir.Value
        Dim tblResult As New DataTable

        Dim query As New StringBuilder()

        query.AppendLine("WITH FilteredTransPoli AS (")
        query.AppendLine("    SELECT TransPoliID")
        query.AppendLine("    FROM TransaksiPoli")
        query.AppendLine("    WHERE (CONVERT(DATE, TglPoli) BETWEEN '" & Format(tglTransaksiAwal.Date, "yyyyMMdd") & "' AND '" & Format(tglTransaksiAkhir.Date, "yyyyMMdd") & "') AND Upload = 0 AND Deleted = 0")
        query.AppendLine("),")
        query.AppendLine(SqlCteNilaiKategori())
        query.AppendLine("SELECT tblBayar.TransPoliID AS 'ID', t.NoUrut, CONVERT(DATE, t.TglPoli) AS 'Tgl Transaksi',")
        query.AppendLine("       d.JenisPoli, p.Nama, p.NoRekamMedis, tblBayar.JenisBayar, tblBayar.NoJenisBayar, tblBayar.kartu AS 'JenisKartu', tblBayar.mesin AS 'JenisMesin', d.JenisTransaksi,")
        query.AppendLine("       kat.Kategori, SUM(kat.Nilai) AS TotalBayar")
        query.AppendLine("FROM (")
        query.AppendLine("    SELECT tb.TransPoliID, tb.JenisBayar, tb.NoJenisBayar, tb.JumlahBayar, tb.Kembali, tb.kartu, tb.mesin")
        query.AppendLine("    FROM TransaksiPoliBayar tb")
        query.AppendLine("    INNER JOIN FilteredTransPoli ft ON tb.TransPoliID = ft.TransPoliID")
        query.AppendLine("    WHERE tb.JumlahBayar > 0 AND tb.JenisBayar IN ('TAGIHAN', 'TUNAI', 'DEBET', 'CARD')")
        query.AppendLine("    UNION ALL")
        query.AppendLine("    SELECT tba.TransPoliID, tba.JenisBayar, tba.NoJenisBayar, tba.JumlahBayar, tba.Kembali, tba.kartu, tba.mesin")
        query.AppendLine("    FROM TransaksiPoliBayarAwal tba")
        query.AppendLine("    INNER JOIN FilteredTransPoli ft ON tba.TransPoliID = ft.TransPoliID")
        query.AppendLine("    WHERE tba.JumlahBayar > 0 AND tba.JenisBayar IN ('TAGIHAN', 'TUNAI', 'DEBET', 'CARD')")
        query.AppendLine(") AS tblBayar")
        query.AppendLine("LEFT JOIN NilaiKategori nk ON nk.TransPoliID = tblBayar.TransPoliID")
        query.AppendLine(SqlCrossApplyKategori())
        query.AppendLine("LEFT JOIN TransaksiPoli t ON tblBayar.TransPoliID = t.TransPoliID")
        query.AppendLine("LEFT JOIN TransaksiDetail d ON t.NoUrut = d.NoUrut")
        query.AppendLine("LEFT JOIN MasterPasien p ON t.IDInternet = p.NoRekamMedis")
        query.AppendLine("WHERE kat.Nilai <> 0")
        query.AppendLine("GROUP BY tblBayar.TransPoliID, t.NoUrut, CONVERT(DATE, t.TglPoli),")
        query.AppendLine("         d.JenisPoli, p.Nama, p.NoRekamMedis, tblBayar.JenisBayar, tblBayar.NoJenisBayar, tblBayar.kartu, tblBayar.mesin, d.JenisTransaksi, kat.Kategori")

        tblResult = ReadSQL(query.ToString())

        Return tblResult
    End Function

    Function GetDataUploadOmsetPoliGigi() As DataTable
        Dim tglTransaksiAwal As Date = DateTimePickerTanggalTransaksiAwal.Value
        Dim tglTransaksiAkhir As Date = DateTimePickerTanggalTransaksiAkhir.Value
        Dim tblResult As New DataTable

        Dim query As New StringBuilder()

        query.AppendLine("WITH FilteredTransGigi AS (")
        query.AppendLine("    SELECT TransGigiID")
        query.AppendLine("    FROM TransaksiGigi")
        query.AppendLine("    WHERE (CONVERT(DATE, TglGigi) BETWEEN '" & Format(tglTransaksiAwal.Date, "yyyyMMdd") & "' AND '" & Format(tglTransaksiAkhir.Date, "yyyyMMdd") & "') AND Upload = 0 AND Deleted = 0")
        query.AppendLine(")")
        query.AppendLine("SELECT tblBayar.TransGigiID AS 'ID', t.NoUrut, CONVERT(DATE, t.TglGigi) AS 'Tgl Transaksi',")
        query.AppendLine("       d.JenisPoli, p.Nama, p.NoRekamMedis, tblBayar.JenisBayar, tblBayar.NoJenisBayar, tblBayar.kartu AS 'JenisKartu', tblBayar.mesin AS 'JenisMesin', d.JenisTransaksi,")
        ' Paket hanya ada di POLI (TransaksiPoliDetail.PaketID). GIGI tidak punya jalur paket,
        ' jadi dikategorikan tetap sebagai NON PAKET agar struktur kolomnya sama saat di-Merge.
        query.AppendLine("       '" & KATEGORI_NON_PAKET & "' AS Kategori, SUM(JumlahBayar - Kembali) AS TotalBayar")
        query.AppendLine("FROM (")
        query.AppendLine("    SELECT tb.TransGigiID, tb.JenisBayar, tb.NoJenisBayar, tb.JumlahBayar, tb.Kembali, tb.kartu, tb.mesin")
        query.AppendLine("    FROM TransaksiGigiBayar tb")
        query.AppendLine("    INNER JOIN FilteredTransGigi ft ON tb.TransGigiID = ft.TransGigiID")
        query.AppendLine("    WHERE tb.JumlahBayar > 0 AND tb.JenisBayar IN ('TAGIHAN', 'TUNAI', 'DEBET', 'CARD')")
        query.AppendLine("    UNION ALL")
        query.AppendLine("    SELECT tba.TransGigiID, tba.JenisBayar, tba.NoJenisBayar, tba.JumlahBayar, tba.Kembali, tba.kartu, tba.mesin")
        query.AppendLine("    FROM TransaksiGigiBayarAwal tba")
        query.AppendLine("    INNER JOIN FilteredTransGigi ft ON tba.TransGigiID = ft.TransGigiID")
        query.AppendLine("    WHERE tba.JumlahBayar > 0 AND tba.JenisBayar IN ('TAGIHAN', 'TUNAI', 'DEBET', 'CARD')")
        query.AppendLine(") AS tblBayar")
        query.AppendLine("LEFT JOIN TransaksiGigi t ON tblBayar.TransGigiID = t.TransGigiID")
        query.AppendLine("LEFT JOIN TransaksiDetail d ON t.NoUrut = d.NoUrut")
        query.AppendLine("LEFT JOIN MasterPasien p ON t.IDInternet = p.NoRekamMedis")
        query.AppendLine("GROUP BY tblBayar.TransGigiID, t.NoUrut, CONVERT(DATE, t.TglGigi),")
        query.AppendLine("         d.JenisPoli, p.Nama, p.NoRekamMedis, tblBayar.JenisBayar, tblBayar.NoJenisBayar, tblBayar.kartu, tblBayar.mesin, d.JenisTransaksi")

        tblResult = ReadSQL(query.ToString())

        Return tblResult
    End Function

    Function GetDataUploadOmsetLaboratorium() As DataTable
        Dim tglTransaksiAwal As Date = DateTimePickerTanggalTransaksiAwal.Value
        Dim tglTransaksiAkhir As Date = DateTimePickerTanggalTransaksiAkhir.Value
        Dim tblResult As New DataTable

        Dim query As New StringBuilder()

        query.AppendLine("WITH FilteredTransLab AS (")
        query.AppendLine("    SELECT TransLabID")
        query.AppendLine("    FROM TransaksiLab")
        query.AppendLine("    WHERE (CONVERT(DATE, TglLab) BETWEEN '" & Format(tglTransaksiAwal.Date, "yyyyMMdd") & "' AND '" & Format(tglTransaksiAkhir.Date, "yyyyMMdd") & "') AND Upload = 0 AND Deleted = 0 AND SendKeu IS NOT NULL")
        query.AppendLine(")")
        query.AppendLine("SELECT tblBayar.TransLabID AS 'ID', t.NoUrut, CONVERT(DATE, t.TglLab) AS 'Tgl Transaksi',")
        query.AppendLine("       d.JenisPoli, p.Nama, p.NoRekamMedis, tblBayar.JenisBayar, tblBayar.NoJenisBayar, tblBayar.kartu AS 'JenisKartu', tblBayar.mesin AS 'JenisMesin', d.JenisTransaksi,")
        ' Sama seperti GIGI: LAB tidak punya jalur paket, tetap NON PAKET.
        query.AppendLine("       '" & KATEGORI_NON_PAKET & "' AS Kategori, SUM(JumlahBayar - Kembali) AS TotalBayar")
        query.AppendLine("FROM (")
        query.AppendLine("    SELECT tb.TransLabID, tb.JenisBayar, tb.NoJenisBayar, tb.JumlahBayar, tb.Kembali, tb.kartu, tb.mesin")
        query.AppendLine("    FROM TransaksiLabBayar tb")
        query.AppendLine("    INNER JOIN FilteredTransLab ft ON tb.TransLabID = ft.TransLabID")
        query.AppendLine("    WHERE tb.JumlahBayar > 0 AND tb.JenisBayar IN ('TAGIHAN', 'TUNAI', 'DEBET', 'CARD')")
        query.AppendLine(") AS tblBayar")
        query.AppendLine("LEFT JOIN TransaksiLab t ON tblBayar.TransLabID = t.TransLabID")
        query.AppendLine("LEFT JOIN TransaksiDetail d ON t.NoUrut = d.NoUrut")
        query.AppendLine("LEFT JOIN MasterPasien p ON t.IDInternet = p.NoRekamMedis")
        query.AppendLine("GROUP BY tblBayar.TransLabID, t.NoUrut, CONVERT(DATE, t.TglLab),")
        query.AppendLine("         d.JenisPoli, p.Nama, p.NoRekamMedis, tblBayar.JenisBayar, tblBayar.NoJenisBayar, tblBayar.kartu, tblBayar.mesin, d.JenisTransaksi")

        tblResult = ReadSQL(query.ToString())

        Return tblResult
    End Function

    ' ==========================================================================================
    ' PEMAKAIAN PAKET — MEMO SAJA, TIDAK PERNAH DIKIRIM DAN TIDAK PERNAH DIJURNAL.
    '
    ' Saat pasien memakai jatah paketnya, FormRekamMedisDokter mencatat pembayaran dengan
    ' JenisBayar = 'VOUCHER' (lihat FormRekamMedisDokter.vb:13599). Jenis itu memang TIDAK ada
    ' di daftar ('TAGIHAN','TUNAI','DEBET','CARD') pada query omset, jadi selama ini pemakaian
    ' paket tidak pernah masuk omset maupun jurnal.
    '
    ' Itu DIPERTAHANKAN dengan sengaja: pendapatannya sudah diakui saat paket DIBELI. Kalau
    ' pemakaian ikut dikirim, pendapatan yang sama terhitung dua kali. Fungsi ini hanya
    ' menampilkannya di grid supaya operator/keuangan bisa melihat berapa nilai jatah paket
    ' yang terpakai pada periode tersebut.
    '
    ' Sengaja TIDAK memfilter Upload: baris ini tidak pernah ikut proses upload sehingga
    ' flag Upload-nya tak pernah berubah — memfilternya justru membuat memo ini menyesatkan.
    ' ==========================================================================================
    Function GetDataPemakaianPaket() As DataTable
        Dim tglTransaksiAwal As Date = DateTimePickerTanggalTransaksiAwal.Value
        Dim tglTransaksiAkhir As Date = DateTimePickerTanggalTransaksiAkhir.Value

        Dim query As New StringBuilder()

        query.AppendLine("SELECT tba.TransPoliID AS 'ID', t.NoUrut, CONVERT(DATE, t.TglPoli) AS 'Tgl Transaksi',")
        query.AppendLine("       d.JenisPoli, p.Nama, p.NoRekamMedis, tba.JenisBayar, tba.NoJenisBayar,")
        query.AppendLine("       tba.kartu AS 'JenisKartu', tba.mesin AS 'JenisMesin', d.JenisTransaksi,")
        query.AppendLine("       '" & KATEGORI_PAKAI_PAKET & "' AS Kategori, SUM(tba.JumlahBayar - tba.Kembali) AS TotalBayar")
        query.AppendLine("FROM TransaksiPoliBayarAwal tba")
        query.AppendLine("INNER JOIN TransaksiPoli t ON tba.TransPoliID = t.TransPoliID")
        query.AppendLine("LEFT JOIN TransaksiDetail d ON t.NoUrut = d.NoUrut")
        query.AppendLine("LEFT JOIN MasterPasien p ON t.IDInternet = p.NoRekamMedis")
        query.AppendLine("WHERE (CONVERT(DATE, t.TglPoli) BETWEEN '" & Format(tglTransaksiAwal.Date, "yyyyMMdd") & "' AND '" & Format(tglTransaksiAkhir.Date, "yyyyMMdd") & "')")
        query.AppendLine("  AND t.Deleted = 0 AND tba.JumlahBayar > 0 AND tba.JenisBayar = 'VOUCHER'")
        query.AppendLine("GROUP BY tba.TransPoliID, t.NoUrut, CONVERT(DATE, t.TglPoli),")
        query.AppendLine("         d.JenisPoli, p.Nama, p.NoRekamMedis, tba.JenisBayar, tba.NoJenisBayar, tba.kartu, tba.mesin, d.JenisTransaksi")

        Return ReadSQL(query.ToString())
    End Function

    Private Sub ButtonKirimDataOmset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonKirimDataOmset.Click
        ' Guard double-click: kunci SINKRON di UI thread sebelum thread mulai (Bug D)
        If isBusy Then
            MsgBox("Proses masih berjalan. Mohon tunggu hingga selesai.", MsgBoxStyle.Exclamation, "Sedang Proses")
            Exit Sub
        End If
        SetUiBusy(True)

        thread = New System.Threading.Thread(AddressOf KirimOmsetHarian)
        thread.IsBackground = True
        thread.Start()
    End Sub

    Private Sub KirimOmsetHarian()
      Try
        ' P1.2: validasi sama seperti tombol Cari (internet, maks H-1, transaksi PENDING) sebelum kirim
        If ValidasiDataUpload() = False Then Exit Sub

        ' Pastikan server tujuan (Keuangan online + Jurnal) benar-benar terjangkau, bukan sekadar internet nyala
        If CekKoneksiServerKirim() = False Then Exit Sub

        Dim tblPoliUmum As DataTable = GetDataUploadOmsetPoliUmum()
        Dim tblPoliGigi As DataTable = GetDataUploadOmsetPoliGigi()
        Dim tblLaboratorium As DataTable = GetDataUploadOmsetLaboratorium()

        ' Buat tabel gabungan dengan struktur yang sama
        Dim tblOmset As DataTable = tblPoliUmum.Clone()

        ' Gabungkan data dari kedua tabel
        tblOmset.Merge(tblPoliUmum)
        tblOmset.Merge(tblPoliGigi)
        tblOmset.Merge(tblLaboratorium)

        If tblOmset.Rows.Count > 0 Then
            Dim queryStringRekap As String = ""
            Dim transaksiProgres As Integer = 0
            Dim persentaseProgres As Integer = 0

            ' Set Data Pasien Umum
            Dim rowPasienUmum As Integer = 0
            Dim queryStringUmum As New StringBuilder()
            queryStringUmum.AppendLine("INSERT INTO acctranspendapatandetail (inctgl, loc, incjenis, jenis, kartu, mesin, incnilai, createdate, inctransid, idinternet, pasien, no_transaksi, jenis_poli, flagdate, flagby, flag, kategori) VALUES ")

            ' Set Data Pasien Tagihan
            Dim rowPasienTagihan As Integer = 0
            Dim queryStringTagihan As New StringBuilder()
            queryStringTagihan.AppendLine("INSERT INTO acctranstagihandetail(inctgl, loc, incjenis, jenis, kartu, mesin, incnilai, createdate, inctransid, idinternet, pasien, rekapid, lockeddate, lockedby, no_transaksi, jenis_poli, kategori) VALUES ")

            ' Set Data No Transaksi
            Dim noTransaksiPoli As String = ""
            Dim noTransaksiGigi As String = ""
            Dim noTransaksiLab As String = ""

            ' Set HashSet untuk setiap jenis transaksi
            Dim tempTransaksiPoli As New HashSet(Of String)()
            Dim tempTransaksiLab As New HashSet(Of String)()
            Dim tempTransaksiGigi As New HashSet(Of String)()

            For Each rowOmset As DataRow In tblOmset.Rows
                ' Cek Jumlah Proses
                transaksiProgres += 1
                persentaseProgres = transaksiProgres * 100 / tblOmset.Rows.Count

                ' Update ProgressBar
                ProgressBarUpload.Value = persentaseProgres
                LabelProgress.Text = "Progress : " & persentaseProgres & " %"

                ' Set Variabel Input Data
                Dim tglSekarang As String = Format(DateAndTime.Now, "yyyy-MM-dd")
                Dim tglPeriksa As String = Format(rowOmset("Tgl Transaksi"), "yyyy-MM-dd")
                Dim jenisKartu As String = rowOmset("JenisKartu")
                Dim jenisMesin As String = rowOmset("JenisMesin")
                Dim idTransaksi As String = rowOmset("ID")
                Dim noRekamMedis As String = rowOmset("NoRekamMedis")
                Dim namaPasien As String = rowOmset("Nama").ToString.Replace("'", "''")
                Dim noTransaksi As String = rowOmset("NoUrut")
                Dim jenisPoli As String = rowOmset("JenisPoli")
                Dim keteranganBayar As String = rowOmset("NoJenisBayar")
                Dim jenisTransaksi As String = rowOmset("JenisTransaksi")
                Dim nominalTransaksi As String = rowOmset("TotalBayar")
                Dim kategoriOmset As String = rowOmset("Kategori").ToString
                Dim jenisBayar As String = ""

                ' Set Keterangan Jenis Bayar
                If rowOmset("JenisBayar").ToString = "TUNAI" Then
                    jenisBayar = "Tunai"
                ElseIf rowOmset("JenisBayar").ToString = "DEBET" Then
                    jenisBayar = "Debet"
                ElseIf rowOmset("JenisBayar").ToString = "CARD" Then
                    jenisBayar = "Kredit"
                ElseIf rowOmset("JenisBayar").ToString = "TAGIHAN" Then
                    jenisBayar = "Tagihan"
                End If

                If jenisBayar = "TAGIHAN" Then ' Get Rekap Tagihan Per Transaksi
                    Dim keteranganPerusahaan, kodePerusahaan As String
                    If keteranganBayar.Contains("-") = True Then
                        Dim splitKeterangan() As String = keteranganBayar.Split("-")
                        keteranganPerusahaan = splitKeterangan(0)
                        kodePerusahaan = splitKeterangan(1)
                    Else
                        keteranganPerusahaan = keteranganBayar
                        kodePerusahaan = ""
                    End If

                    Select Case jenisTransaksi
                        Case "POLI"
                            queryStringRekap = "SELECT a.RekapID, b.CreateDate, b.CreateBy FROM TransaksiPoli a LEFT JOIN RekapTagihan b ON a.RekapID=b.RekapID WHERE a.TransPoliID='" & idTransaksi & "'"
                        Case "GIGI"
                            queryStringRekap = "SELECT a.RekapID, b.CreateDate, b.CreateBy FROM TransaksiGigi a LEFT JOIN RekapTagihan b ON a.RekapID=b.RekapID WHERE a.TransGigiID='" & idTransaksi & "'"
                        Case "LAB"
                            queryStringRekap = "SELECT a.RekapID, b.CreateDate, b.CreateBy FROM TransaksiLab a LEFT JOIN RekapTagihan b ON a.RekapID=b.RekapID WHERE a.translabid='" & idTransaksi & "'"
                    End Select

                    Dim TblsRekap As DataTable = ReadSQL(queryStringRekap)

                    For Each TrowRekap As DataRow In TblsRekap.Rows
                        Dim idRekap As String = "NULL"
                        Dim tglRekap As String = "9998-12-31 00:00:00"
                        Dim namaUserRekap As String = ""

                        If IsDBNull(TrowRekap("RekapID")) = False Then idRekap = TrowRekap("RekapID")
                        If IsDBNull(TrowRekap("CreateDate")) = False Then tglRekap = Format(TrowRekap("CreateDate"), "yyyy-MM-dd HH:mm:ss")
                        If IsDBNull(TrowRekap("CreateBy")) = False Then namaUserRekap = TrowRekap("CreateBy")

                        queryStringTagihan.AppendLine("('" & tglPeriksa & "','" & kodeLokasiKlinik & "','" & jenisTransaksi & "','" & jenisBayar & "','" & keteranganPerusahaan & "','" & kodePerusahaan & "','" & nominalTransaksi & "',NOW(),'" & idTransaksi & "','" & noRekamMedis & "','" & namaPasien & "', " & idRekap & ", '" & tglRekap & "', '" & namaUserRekap & "', '" & noTransaksi & "', '" & jenisPoli & "', '" & kategoriOmset & "'),")
                        rowPasienTagihan += 1
                    Next
                Else
                    ' Kategori ditulis ke kolom 'kategori' (ditambahkan 2026-08-01), sama seperti
                    ' sisi TAGIHAN (kolomnya ditambahkan 2026-07-29). Kolom 'flag' kembali berisi
                    ' teks aslinya — sempat dititipi kategori waktu kolom ini belum ada.
                    queryStringUmum.AppendLine("('" & tglPeriksa & "','" & kodeLokasiKlinik & "','" & jenisTransaksi & "','" & jenisBayar & "','" & jenisKartu & "','" & jenisMesin & "','" & nominalTransaksi & "',NOW(),'" & idTransaksi & "','" & noRekamMedis & "','" & namaPasien & "', '" & noTransaksi & "', '" & jenisPoli & "', NOW(), '" & userInput & "', 'Auto Jurnal Pendapatan', '" & kategoriOmset & "'),")
                    rowPasienUmum += 1
                End If

                Select Case jenisTransaksi
                    Case "POLI"
                        If tempTransaksiPoli.Add(idTransaksi) Then
                            noTransaksiPoli &= "'" & idTransaksi & "',"
                        End If
                    Case "LAB"
                        If tempTransaksiLab.Add(idTransaksi) Then
                            noTransaksiLab &= "'" & idTransaksi & "',"
                        End If
                    Case "GIGI"
                        If tempTransaksiGigi.Add(idTransaksi) Then
                            noTransaksiGigi &= "'" & idTransaksi & "',"
                        End If
                End Select
            Next

            ' Susun statement online (buang koma terakhir)
            Dim sqlStatementUmum As String = ""
            Dim sqlStatementTagihan As String = ""

            If rowPasienUmum > 0 Then
                sqlStatementUmum = queryStringUmum.ToString().TrimEnd()
                If sqlStatementUmum.EndsWith(",") Then sqlStatementUmum = sqlStatementUmum.Substring(0, sqlStatementUmum.Length - 1)
            End If

            If rowPasienTagihan > 0 Then
                sqlStatementTagihan = queryStringTagihan.ToString().TrimEnd()
                If sqlStatementTagihan.EndsWith(",") Then sqlStatementTagihan = sqlStatementTagihan.Substring(0, sqlStatementTagihan.Length - 1)
            End If

            ' === Bug A: Post umum + tagihan ke online, lalu KELUAR tanpa men-set Upload=1 bila gagal. ===
            ' Transaksi MySQL di sini TIDAK bisa diandalkan: kedua tabel tujuan ber-engine MyISAM,
            ' yang menerima BEGIN/ROLLBACK tanpa error tetapi tidak membatalkan apa pun (sudah diuji
            ' langsung ke server). Jadi bila INSERT umum sukses lalu INSERT tagihan gagal, baris umum
            ' TETAP tersimpan -> kirim ulang akan menduplikasi omset. Karena itu sisa kiriman gagal
            ' dibersihkan sendiri di bawah, barulah "aman dikirim ulang" benar-benar berlaku.
            If rowPasienUmum > 0 OrElse rowPasienTagihan > 0 Then
                Dim waktuMulaiKirim As String = WaktuServerKeuangan()
                Try
                    ExecuteMySqlTransaction(DB_Keuangan, sqlStatementUmum, sqlStatementTagihan)
                Catch exUpload As Exception
                    Dim semuaIdTransaksi As String = (noTransaksiPoli & noTransaksiGigi & noTransaksiLab).TrimEnd(","c)
                    Dim pesanBersih As String

                    Try
                        Dim jumlahDihapus As Integer = BersihkanOmsetGagal(semuaIdTransaksi, waktuMulaiKirim)
                        pesanBersih = "Sisa data yang terlanjur masuk sudah dibersihkan (" & jumlahDihapus & " baris). Omset ini AMAN dikirim ulang."
                    Catch exBersih As Exception
                        pesanBersih = "PERINGATAN: pembersihan otomatis GAGAL (" & exBersih.Message & ")." & vbCrLf & "JANGAN kirim ulang sebelum IT memeriksa data online — berisiko dobel."
                    End Try

                    MsgBox("Gagal upload omset ke online. Flag lokal TIDAK diubah." & vbCrLf & vbCrLf & pesanBersih & vbCrLf & vbCrLf & exUpload.Message, MsgBoxStyle.Critical, "Upload Gagal")
                    Exit Sub
                End Try
            End If

            ' Update Flag Upload — P2.4: pakai WriteSqlChecked (melempar error) supaya GAGAL terdeteksi.
            ' Online SUDAH commit di titik ini; bila flag lokal gagal, operator HARUS tahu agar TIDAK kirim ulang (dobel).
            Try
                If tempTransaksiPoli.Count > 0 Then
                    noTransaksiPoli = Strings.Left(noTransaksiPoli, noTransaksiPoli.Length - 1)
                    WriteSqlChecked("UPDATE TransaksiPoli SET Upload = 1, UploadDate = GETDATE() WHERE TransPoliID IN (" & noTransaksiPoli & ")")
                End If

                If tempTransaksiLab.Count > 0 Then
                    noTransaksiLab = Strings.Left(noTransaksiLab, noTransaksiLab.Length - 1)
                    WriteSqlChecked("UPDATE TransaksiLab SET Upload = 1, UploadDate = GETDATE() WHERE TransLabID IN (" & noTransaksiLab & ")")
                End If

                If tempTransaksiGigi.Count > 0 Then
                    noTransaksiGigi = Strings.Left(noTransaksiGigi, noTransaksiGigi.Length - 1)
                    WriteSqlChecked("UPDATE TransaksiGigi SET Upload = 1, UploadDate = GETDATE() WHERE TransGigiID IN (" & noTransaksiGigi & ")")
                End If
            Catch exFlag As Exception
                MsgBox("PENTING: Omset SUDAH terkirim ke online, tetapi update flag 'Upload' di database lokal GAGAL." & vbCrLf & vbCrLf & "JANGAN kirim ulang omset ini (berisiko dobel di online). Hubungi IT untuk set Upload = 1 secara manual." & vbCrLf & vbCrLf & exFlag.Message, MsgBoxStyle.Critical, "Flag Lokal Gagal")
            End Try

            Dim jumlahTransaksi As Integer = tempTransaksiPoli.Count + tempTransaksiLab.Count + tempTransaksiGigi.Count

            ' Send Jurnal
            SendingJurnal()

            MsgBox(jumlahTransaksi & " Data telah berhasil upload.", MsgBoxStyle.Information, "Success!")
        Else
            MsgBox("Tidak Ada Data.", MsgBoxStyle.Exclamation, "Warning")
        End If
      Catch ex As Exception
        MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
      Finally
        SetUiBusy(False)
      End Try
    End Sub

    Private Sub ButtonKirimJurnalUlang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonKirimJurnalUlang.Click
        ' Guard double-click: kunci SINKRON sebelum thread mulai (Bug D)
        If isBusy Then
            MsgBox("Proses masih berjalan. Mohon tunggu hingga selesai.", MsgBoxStyle.Exclamation, "Sedang Proses")
            Exit Sub
        End If
        SetUiBusy(True)

        thread = New System.Threading.Thread(AddressOf SendingJurnalUlang)
        thread.IsBackground = True
        thread.Start()
    End Sub

    ' Pembungkus SendingJurnal untuk jalur "Kirim Jurnal Ulang": pastikan UI selalu dipulihkan walau error.
    Private Sub SendingJurnalUlang()
        Try
            ' Jurnal butuh server online (Jurnal + Omset) — pastikan server tujuan terjangkau, bukan sekadar internet nyala
            If CekKoneksiServerKirim() = False Then Exit Sub

            SendingJurnal()
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            SetUiBusy(False)
        End Try
    End Sub

    ' Meniru urutan lookup COA saat menjurnal: baris master khusus "<poli> - PEMBELIAN PAKET"
    ' lebih dulu, baru baris poli biasa. Mengembalikan "" bila keduanya tidak ada / kosong / "-".
    Private Function AmbilCoaPaket(ByVal peta As Dictionary(Of String, String), ByVal poli As String) As String
        For Each kunci As String In New String() {poli & " - " & KATEGORI_BELI_PAKET, poli}
            If peta.ContainsKey(kunci) Then
                Dim nilai As String = peta(kunci).Trim()
                If nilai <> "" AndAlso nilai <> "-" Then Return nilai
            End If
        Next
        Return ""
    End Function

    ' Notifikasi dini: cabang mulai memakai sistem paket, tapi MasterLokasiJurnal belum diisi COA
    ' paketnya. Hanya L003 yang memakai paket saat ini; kalau kelak cabang lain ikut, di sinilah
    ' pesannya muncul — bukan sebagai satu baris yang tenggelam di daftar detail.
    '
    ' Kenapa MENGHENTIKAN, bukan memberi tahu lalu jalan terus: satu FlagJurnalHarian* dipakai
    ' BERSAMA oleh baris NON PAKET dan PEMBELIAN PAKET pada tanggal+poli+jenisbayar yang sama.
    ' Kalau baris non-paket sukses lalu men-set flag itu sementara baris paketnya gagal karena COA
    ' kosong, baris paket tak akan pernah muncul lagi (query pending menyaring
    ' FlagJurnalHarian... IS NULL) -> jurnalnya HILANG permanen dan harus dibuat manual.
    ' Dengan berhenti sebelum satu jurnal pun dibuat, tidak ada flag yang ter-set: seluruh batch
    ' tetap utuh dan bisa dikirim ulang lewat tombol "Kirim Jurnal Ulang" setelah COA dilengkapi.
    ' Omset (uangnya) tidak terpengaruh — pengirimannya terjadi sebelum ini dan tidak diulang.
    Private Function CekCoaPaketSiap(ByVal tblTransaksi As DataTable) As Boolean
        If tipeJurnal <> "Poli" Then Return True

        ' Poli mana di batch ini yang butuh COA paket. Pembelian butuh akun Ditangguhkan saja;
        ' pemakaian butuh Ditangguhkan (D) dan Pendapatan Paket (K).
        Dim perluCoa As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
        Dim perluPendapatanPaket As New List(Of String)()

        If tblTransaksi.Columns.Contains("Kategori") AndAlso tblTransaksi.Columns.Contains("JenisPoli") Then
            For Each rowTransaksi As DataRow In tblTransaksi.Rows
                ' Pembelian sebelum cut-off memakai skema lama (Pendapatan biasa), tidak butuh COA baru.
                If rowTransaksi("Kategori").ToString = KATEGORI_BELI_PAKET _
                   AndAlso CDate(rowTransaksi("Tgl Transaksi")).Date >= TglCutOffPaket() Then
                    perluCoa(rowTransaksi("JenisPoli").ToString) = KATEGORI_BELI_PAKET
                End If
            Next
        End If

        For Each rowPakai As DataRow In GetDataJurnalPemakaianPaket().Rows
            Dim poli As String = rowPakai("JenisPoli").ToString
            perluCoa(poli) = KATEGORI_PAKAI_PAKET
            perluPendapatanPaket.Add(poli)
        Next

        If perluCoa.Count = 0 Then Return True

        ' Baca seluruh baris master cabang ini sekali. Gagal baca (koneksi) BUKAN alasan menuduh COA
        ' kosong — lanjutkan saja; penjagaan per baris di dalam loop tetap menahan akun tak sah.
        Dim tblMaster As DataTable
        Try
            tblMaster = BacaTabelMySqlChecked("SELECT a.KeteranganPoli, a.KodeCoaPendapatanDitangguhkan, a.KodeCoaPendapatanPaket FROM MasterLokasiJurnal a WHERE a.KodeLokasi = '" & kodeLokasiKlinik & "';", DB_Omset)
        Catch exMaster As Exception
            Return True
        End Try

        Dim coaDitangguhkan As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
        Dim coaPendapatanPaket As New Dictionary(Of String, String)(StringComparer.OrdinalIgnoreCase)
        For Each rowMaster As DataRow In tblMaster.Rows
            Dim poli As String = rowMaster("KeteranganPoli").ToString
            coaDitangguhkan(poli) = rowMaster("KodeCoaPendapatanDitangguhkan").ToString
            coaPendapatanPaket(poli) = rowMaster("KodeCoaPendapatanPaket").ToString
        Next

        Dim kurang As New StringBuilder()
        For Each poli As String In perluCoa.Keys
            Dim hilang As New List(Of String)()

            If AmbilCoaPaket(coaDitangguhkan, poli) = "" Then hilang.Add("KodeCoaPendapatanDitangguhkan")
            If perluPendapatanPaket.Contains(poli) AndAlso AmbilCoaPaket(coaPendapatanPaket, poli) = "" Then hilang.Add("KodeCoaPendapatanPaket")

            If hilang.Count > 0 Then
                kurang.AppendLine("   - " & poli & "  [" & perluCoa(poli) & "]" & vbCrLf & _
                                  "     kolom kosong: " & String.Join(", ", hilang.ToArray()))
            End If
        Next

        If kurang.Length = 0 Then Return True

        MsgBox("JURNAL DIHENTIKAN — COA PAKET BELUM DISIAPKAN UNTUK CABANG INI." & vbCrLf & vbCrLf & _
               "Cabang " & kodeLokasiKlinik & " sudah memakai sistem paket, tetapi MasterLokasiJurnal " & _
               "belum diisi untuk poli berikut:" & vbCrLf & vbCrLf & _
               kurang.ToString() & vbCrLf & _
               "TIDAK ADA satu pun jurnal yang dibuat, jadi tidak ada data yang hilang dan tidak ada " & _
               "yang perlu dibatalkan. Omset (uangnya) tetap terkirim seperti biasa." & vbCrLf & vbCrLf & _
               "Langkah: minta keuangan/IT melengkapi COA paket di MasterLokasiJurnal untuk cabang " & _
               kodeLokasiKlinik & ", lalu tekan tombol ""Kirim Jurnal Ulang"" untuk mengirim jurnalnya.", _
               MsgBoxStyle.Critical, "COA Paket Belum Lengkap")
        Return False
    End Function

    Private Sub SendingJurnal()
        Dim tblPoliUmum As DataTable = GetDataUploadJurnalPoliUmum()
        Dim tblPoliGigi As DataTable = GetDataUploadJurnalPoliGigi()
        Dim tblLaboratorium As DataTable = GetDataUploadJurnalLaboratorium()

        ' Buat tabel gabungan dengan struktur yang sama
        Dim tblTransaksi As DataTable = tblPoliUmum.Clone()

        ' Gabungkan data dari kedua tabel
        tblTransaksi.Merge(tblPoliUmum)
        tblTransaksi.Merge(tblPoliGigi)
        tblTransaksi.Merge(tblLaboratorium)

        ' Notifikasi dini bila cabang ini mulai memakai sistem paket tapi COA-nya belum disiapkan.
        If CekCoaPaketSiap(tblTransaksi) = False Then Exit Sub

        Dim transaksiProgres As Integer = 0
        Dim persentaseProgres As Integer = 0

        Dim tglTransaksiAwal As Date = DateTimePickerTanggalTransaksiAwal.Value
        Dim tglTransaksiAkhir As Date = DateTimePickerTanggalTransaksiAkhir.Value

        ' P1.1: ringkas hasil (hindari MsgBox per baris yang membanjiri layar bila server jurnal bermasalah)
        Dim jmlSukses As Integer = 0
        Dim jmlGagal As Integer = 0
        Dim jmlHilang As Integer = 0
        Dim jmlFlagGagal As Integer = 0
        Dim jmlTakPasti As Integer = 0
        Dim jmlDilewati As Integer = 0
        Dim gagalBeruntun As Integer = 0
        Dim pesanDetail As New StringBuilder()

        ' Kumpulan kunci grup yang flag-nya BERHASIL di-set + daftar baris yang GAGAL buat jurnal.
        ' Dipakai untuk rekonsiliasi di akhir: baris gagal yang grup-nya sudah ke-flag transaksi lain
        ' segrup (kartu/mesin berbeda, jenis bayar sama) TIDAK boleh dilaporkan "aman dikirim ulang" —
        ' kirim ulang akan melewatinya (FlagJurnal... IS NULL tak terpenuhi) sehingga jurnalnya hilang.
        Dim flaggedKeys As New HashSet(Of String)()
        Dim gagalKeys As New List(Of String)()
        Dim gagalInfo As New List(Of String)()

        If tblTransaksi.Rows.Count > 0 Then
            For Each rowTransaksi As DataRow In tblTransaksi.Rows
                ' Cek Jumlah Proses
                transaksiProgres += 1
                persentaseProgres = transaksiProgres * 100 / tblTransaksi.Rows.Count

                ' Update ProgressBar
                ProgressBarUpload.Value = persentaseProgres
                LabelProgress.Text = "Progress : " & persentaseProgres & " %"

                ' Keterangan jenis bayar, jenis poli, dan kunci grup dihitung LEBIH AWAL karena
                ' hanya bergantung pada baris transaksi — dan sudah dibutuhkan bila lookup master gagal.
                Dim keteranganJenisBayar As String = ""
                If rowTransaksi("JenisBayar").ToString = "TUNAI" Then
                    keteranganJenisBayar = "Tunai"
                ElseIf rowTransaksi("JenisBayar").ToString = "DEBET" Then
                    keteranganJenisBayar = "Debet"
                ElseIf rowTransaksi("JenisBayar").ToString = "CARD" Then
                    keteranganJenisBayar = "Kredit"
                ElseIf rowTransaksi("JenisBayar").ToString = "TAGIHAN" Then
                    keteranganJenisBayar = "Tagihan"
                End If

                ' Set Jenis Poli (mode "Transaksi" tidak memilih kolom JenisPoli, jadi biarkan kosong)
                Dim jenisPoli As String = ""
                If tipeJurnal = "Poli" Then
                    jenisPoli = rowTransaksi("JenisPoli").ToString
                End If

                ' Kategori omset baris ini (NON PAKET / PEMBELIAN PAKET). PEMAKAIAN PAKET tidak
                ' pernah sampai ke sini karena query jurnal hanya mengambil JenisBayar uang nyata.
                Dim kategoriBaris As String = rowTransaksi("Kategori").ToString

                ' Kunci lookup MasterLokasiJurnal. Untuk pembelian paket, coba dulu baris master
                ' khusus "<poli> - PEMBELIAN PAKET"; kalau keuangan belum membuatnya, jatuh kembali
                ' ke baris poli biasa (lihat lookup di bawah). Dengan begitu COA terpisah cukup
                ' disiapkan sebagai DATA di MasterLokasiJurnal, tanpa perlu ubah kode lagi.
                Dim poliLookup As String = jenisPoli
                If kategoriBaris = KATEGORI_BELI_PAKET Then poliLookup = jenisPoli & " - " & KATEGORI_BELI_PAKET

                ' Kunci grup untuk deteksi "jurnal hilang": HARUS sama cakupannya dengan set-flag
                ' (tabel transaksi + tanggal + jenis bayar + poli). Flag Lab TIDAK memfilter poli,
                ' begitu pula mode "Transaksi" (jenisPoli = ""), jadi poliKey mengikuti keduanya.
                Dim jenisTransaksiKey As String = rowTransaksi("JenisTransaksi").ToString.Trim.ToUpper()
                Dim poliKey As String = jenisPoli
                If jenisTransaksiKey = "LAB" Then poliKey = ""
                Dim grupKey As String = jenisTransaksiKey & "|" & Format(rowTransaksi("Tgl Transaksi"), "yyyyMMdd") & "|" & keteranganJenisBayar & "|" & poliKey

                Dim keteranganBaris As String = rowTransaksi("JenisTransaksi").ToString & " (" & keteranganJenisBayar & ") " & jenisPoli & " " & Format(rowTransaksi("Tgl Transaksi"), "dd/MM/yyyy")

                ' Set ID Lokasi Jurnal
                Dim tblMasterJurnal As DataTable
                Dim idLokasiJurnal As String = ""
                Dim keteranganLokasiJurnal As String = ""

                ' Sengaja memakai BacaTabelMySqlChecked, BUKAN ReadThemysql: helper bersama itu MENELAN
                ' error koneksi dan mengembalikan DataTable KOSONG, sehingga internet putus terbaca sebagai
                ' "master data tidak ada" lalu dilewati diam-diam — jurnal tidak dibuat dan sebabnya salah
                ' dilaporkan. Helper itu juga memunculkan MsgBox untuk SETIAP baris saat koneksi mati.
                Try
                    If tipeJurnal = "Poli" Then
                        tblMasterJurnal = BacaTabelMySqlChecked("SELECT a.KeteranganLokasi AS 'Lokasi', a.KeteranganPoli AS 'Keterangan', a.KodeLokasiJurnal, a.KodeCoaPendapatan, a.KodeCoaPiutangPending, a.KodeCoaPendapatanTunai, a.KodeCoaPendapatanDitangguhkan, a.KodeCoaPendapatanPaket FROM MasterLokasiJurnal a WHERE a.KodeLokasi = '" & kodeLokasiKlinik & "' AND a.KeteranganPoli = '" & poliLookup & "' LIMIT 1;", DB_Omset)

                        ' Belum ada master khusus kategori -> pakai baris poli biasa. Ini SENGAJA:
                        ' tanpa fallback, seluruh pembelian paket akan "Dilewati" diam-diam dan
                        ' jurnalnya hilang hanya karena master belum disiapkan.
                        If tblMasterJurnal.Rows.Count = 0 AndAlso poliLookup <> jenisPoli Then
                            tblMasterJurnal = BacaTabelMySqlChecked("SELECT a.KeteranganLokasi AS 'Lokasi', a.KeteranganPoli AS 'Keterangan', a.KodeLokasiJurnal, a.KodeCoaPendapatan, a.KodeCoaPiutangPending, a.KodeCoaPendapatanTunai, a.KodeCoaPendapatanDitangguhkan, a.KodeCoaPendapatanPaket FROM MasterLokasiJurnal a WHERE a.KodeLokasi = '" & kodeLokasiKlinik & "' AND a.KeteranganPoli = '" & jenisPoli & "' LIMIT 1;", DB_Omset)
                        End If
                    ElseIf tipeJurnal = "Transaksi" Then
                        tblMasterJurnal = BacaTabelMySqlChecked("SELECT a.KeteranganLokasi AS 'Lokasi', a.JenisTransaksi AS 'Keterangan', a.KodeLokasiJurnal, a.KodeCoaPendapatan, a.KodeCoaPiutangPending, a.KodeCoaPendapatanTunai, a.KodeCoaPendapatanDitangguhkan, a.KodeCoaPendapatanPaket FROM MasterLokasiJurnal a WHERE a.KodeLokasi = '" & kodeLokasiKlinik & "' AND a.JenisTransaksi = '" & rowTransaksi("JenisTransaksi") & "' LIMIT 1;", DB_Omset)
                    Else
                        tblMasterJurnal = New DataTable()
                    End If
                Catch exMaster As Exception
                    ' GAGAL MEMBACA master — bukan berarti masternya tidak ada. Jurnal belum dibuat
                    ' dan flag belum di-set, jadi baris ini aman dikirim ulang.
                    gagalBeruntun += 1
                    gagalKeys.Add(grupKey)
                    gagalInfo.Add(keteranganBaris & " : gagal baca MasterLokasiJurnal (" & exMaster.Message & ")")

                    If gagalBeruntun >= 5 Then
                        pesanDetail.AppendLine("... dihentikan: 5 kegagalan beruntun, kemungkinan koneksi/server bermasalah.")
                        Exit For
                    End If
                    Continue For
                End Try

                ' Bug C: lewati baris bila memang TIDAK ADA MasterLokasiJurnal (beda dari gagal koneksi di atas)
                If tblMasterJurnal.Rows.Count = 0 Then
                    jmlDilewati += 1
                    pesanDetail.AppendLine("- Dilewati (tak ada MasterLokasiJurnal): " & rowTransaksi("JenisTransaksi").ToString & " / " & jenisPoli & " " & Format(rowTransaksi("Tgl Transaksi"), "dd/MM/yyyy"))
                    Continue For
                End If

                Dim rowDataJurnal As DataRow = tblMasterJurnal.Rows(0)
                idLokasiJurnal = rowDataJurnal("KodeLokasiJurnal")
                keteranganLokasiJurnal = rowDataJurnal("Lokasi") & " (" & rowDataJurnal("Keterangan") & ")"

                ' Set Flag / Refference
                Dim refferenceID As String = GetUUID()

                ' Set Mesin EDC
                Dim mesinEDC As String = rowTransaksi("mesin").ToString.Trim
                Dim keteranganMesinEDC As String = " "
                Dim coaMesinEDC As String = ""

                If rowTransaksi("JenisBayar").ToString = "DEBET" Or rowTransaksi("JenisBayar").ToString = "CARD" Then
                    ' Set Keterangan Mesin EDC
                    If rowTransaksi("mesin").ToString.Trim <> "" Then
                        keteranganMesinEDC = " " & rowTransaksi("mesin").ToString.Trim & " "
                    End If

                    ' Set COA Mesin EDC
                    If mesinEDC.Contains("QRIS") = True Then
                        coaMesinEDC = ReadThemysqlNIK("SELECT a.KodeAkun FROM MasterCoaJurnal a WHERE a.NamaAkun = 'Piutang QRIS'", DB_Omset)
                    ElseIf mesinEDC = "BCA" Then
                        coaMesinEDC = ReadThemysqlNIK("SELECT a.KodeAkun FROM MasterCoaJurnal a WHERE a.NamaAkun = 'Piutang BCA'", DB_Omset)
                    ElseIf mesinEDC = "MANDIRI" Then
                        coaMesinEDC = ReadThemysqlNIK("SELECT a.KodeAkun FROM MasterCoaJurnal a WHERE a.NamaAkun = 'Piutang MANDIRI'", DB_Omset)
                    ElseIf mesinEDC = "CIMB" Or mesinEDC = "NIAGA" Then
                        coaMesinEDC = ReadThemysqlNIK("SELECT a.KodeAkun FROM MasterCoaJurnal a WHERE a.NamaAkun = 'Piutang CIMB'", DB_Omset)
                    End If
                End If

                    ' Set Keterangan Jurnal
                    ' Kategori ikut ke keterangan supaya pembelian paket terbaca terpisah di buku besar
                    ' walau COA-nya masih sama (selama master khusus kategori belum dibuat).
                    Dim keteranganJurnal As String = "TERIMA - OMZET " & kategoriBaris & " " & keteranganJenisBayar.ToUpper() & keteranganMesinEDC.ToUpper() & keteranganLokasiJurnal & " " & Format(rowTransaksi("Tgl Transaksi"), "dd/MM/yyyy") & ""

                    ' Tentukan COA lawan sesuai jenis bayar
                    Dim coaLawan As String = ""
                    Dim adaJurnal As Boolean = True
                    If keteranganJenisBayar = "Tagihan" Then
                        coaLawan = rowDataJurnal("KodeCoaPiutangPending").ToString()
                    ElseIf keteranganJenisBayar = "Tunai" Then
                        coaLawan = rowDataJurnal("KodeCoaPendapatanTunai").ToString()
                    ElseIf keteranganJenisBayar = "Debet" Or keteranganJenisBayar = "Kredit" Then
                        coaLawan = coaMesinEDC
                    Else
                        adaJurnal = False
                    End If

                    If Not adaJurnal Then
                        jmlDilewati += 1
                        Continue For
                    End If

                    ' JANGAN buat jurnal dengan akun lawan tidak sah. Dua sumber nilai buruk:
                    '   - "" : mesin EDC di luar daftar yang dikenali (QRIS/BCA/MANDIRI/CIMB/NIAGA)
                    '   - "-": nilai yang dikembalikan ReadThemysqlNIK saat query GAGAL atau kosong
                    ' Tanpa penjagaan ini, jurnal tetap terbentuk dengan akun kosong/"-" — salah akun,
                    ' jauh lebih sulit diperbaiki daripada sekadar gagal. Flag tidak di-set -> aman diulang.
                    If coaLawan.Trim() = "" OrElse coaLawan.Trim() = "-" Then
                        gagalBeruntun += 1
                        gagalKeys.Add(grupKey)
                        gagalInfo.Add(keteranganBaris & " : akun lawan tidak sah ('" & coaLawan & "', mesin '" & mesinEDC & "') — periksa MasterCoaJurnal atau koneksi")

                        If gagalBeruntun >= 5 Then
                            pesanDetail.AppendLine("... dihentikan: 5 kegagalan beruntun, kemungkinan koneksi/server bermasalah.")
                            Exit For
                        End If
                        Continue For
                    End If

                    ' Sisi KREDIT. Pembelian paket TIDAK boleh langsung diakui sebagai pendapatan:
                    ' uangnya sudah diterima tapi jasanya belum diberikan, jadi dikredit ke
                    ' Pendapatan Dibayar Dimuka (deferred revenue). Pengakuan pendapatannya
                    ' menyusul saat paket dipakai — lihat SendingJurnalPemakaianPaket().
                    ' Sisi DEBIT (coaLawan) tidak berubah: kas/piutang tetap sesuai cara bayar.
                    ' Cut-off: hanya pembelian paket SEJAK tanggal mulai yang ditangguhkan. Pembelian
                    ' sebelum itu tetap diakui langsung sebagai pendapatan (skema lama), sehingga
                    ' pemakaiannya yang juga tidak dijurnal tetap konsisten — lihat TglCutOffPaket().
                    Dim coaKredit As String = rowDataJurnal("KodeCoaPendapatan").ToString()
                    If kategoriBaris = KATEGORI_BELI_PAKET AndAlso CDate(rowTransaksi("Tgl Transaksi")).Date >= TglCutOffPaket() Then
                        coaKredit = rowDataJurnal("KodeCoaPendapatanDitangguhkan").ToString()
                    End If

                    ' Penjagaan sama seperti coaLawan: akun kosong/"-" JANGAN dijurnal. Ini juga yang
                    ' menahan proses bila keuangan belum mengisi COA Pendapatan Dibayar Dimuka untuk
                    ' divisi ini — lebih baik gagal terang-terangan (aman diulang) daripada memposting
                    ' ke akun yang tidak ada di bagan akun.
                    If coaKredit.Trim() = "" OrElse coaKredit.Trim() = "-" Then
                        gagalBeruntun += 1
                        gagalKeys.Add(grupKey)
                        gagalInfo.Add(keteranganBaris & " : COA kredit tidak sah ('" & coaKredit & "', kategori " & kategoriBaris & ") — lengkapi MasterLokasiJurnal untuk divisi ini")

                        If gagalBeruntun >= 5 Then
                            pesanDetail.AppendLine("... dihentikan: 5 kegagalan beruntun, kemungkinan koneksi/server bermasalah.")
                            Exit For
                        End If
                        Continue For
                    End If

                    Dim sqlJurnal As String = "SELECT F_MakeUMH('" & refferenceID & "', 'out', '', '" & Format(rowTransaksi("Tgl Transaksi"), "yyyyMMdd") & "', '" & coaKredit & "', '" & coaLawan & "', 'IDR', 1, " & CDbl(rowTransaksi("JumlahBayar")) & ", '" & keteranganJurnal.ToUpper() & "', '1', 1, '', '" & keteranganJurnal.ToUpper() & "', '', '', '" & idLokasiJurnal & "', 4, " & CDbl(rowTransaksi("JumlahBayar")) & ", 'K')"

                    Dim jurnalDibuat As Boolean = False
                    Dim nomorJurnal As String = ""
                    Dim statusTakPasti As Boolean = False
                    Try
                        Try
                            ' 1) Bug B: buat jurnal di server jurnal — Throw bila gagal ATAU bila F_MakeUMH
                            '    menolak diam-diam (mis. periode sudah ditutup). Flag hanya di-set bila nomor UMH terbit.
                            nomorJurnal = BuatJurnalUMH(sqlJurnal, DB_Jurnal)
                        Catch exBuat As Exception
                            ' Error di sisi KLIEN tidak membuktikan server tidak memproses: sudah diuji bahwa
                            ' koneksi yang putus di tengah perintah bisa menghasilkan "Fatal error" di klien
                            ' padahal datanya SUDAH tersimpan. Kalau langsung dianggap gagal, kirim ulang akan
                            ' MENDUPLIKASI jurnal. Karena refferenceID kita sendiri yang tentukan dan server
                            ' menyimpannya di umh.oms, keberadaannya bisa dipastikan.
                            Try
                                nomorJurnal = CariNomorJurnal(refferenceID)
                            Catch exCek As Exception
                                statusTakPasti = True
                                Throw exBuat
                            End Try

                            ' Benar-benar belum terbentuk -> lanjutkan sebagai kegagalan biasa (aman diulang).
                            If nomorJurnal = "" Then Throw exBuat

                            ' Ternyata SUDAH terbentuk -> lanjut ke set flag seperti jalur sukses,
                            ' supaya kiriman berikutnya tidak membuatnya lagi.
                            pesanDetail.AppendLine("- Dipulihkan: koneksi terputus tapi jurnal ternyata SUDAH terbentuk (no. " & nomorJurnal & ") -> " & keteranganBaris)
                        End Try

                        jurnalDibuat = True

                        ' 2) Set flag dengan retry. Flag inilah yang mencegah aggregate muncul lagi -> retry tak menduplikasi.
                        SetFlagJurnalDenganRetry(rowTransaksi, refferenceID, jenisPoli, keteranganJenisBayar)

                        ' Flag grup ini SUDAH ter-set -> catat, agar saudara segrup yang gagal terdeteksi sebagai "hilang".
                        flaggedKeys.Add(grupKey)

                        ' 3) Simpan Log Jurnal Omset (best-effort)
                        WriteSQL("INSERT INTO LogJurnalKeuangan (JurnalFlag, JurnalDate, JurnalBy, Status, JenisPoli, JenisTransaksi) VALUES ('" & refferenceID & "', GETDATE(), '" & userInput & "', '" & keteranganJurnal & "', '" & jenisPoli & "', '" & rowTransaksi("JenisTransaksi").ToString & "')", 4)

                        jmlSukses += 1
                        gagalBeruntun = 0
                    Catch exJurnal As Exception
                        If jurnalDibuat Then
                            ' KRITIS: jurnal SUDAH dibuat tapi flag GAGAL walau sudah retry.
                            ' Kirim ulang massal BISA menduplikasi -> minta operator set flag manual dulu.
                            jmlFlagGagal += 1
                            gagalBeruntun = 0
                            pesanDetail.AppendLine("- KRITIS (set flag manual sebelum kirim ulang): jurnal DIBUAT (no. " & nomorJurnal & ", ref " & refferenceID & ") tapi flag GAGAL -> " & keteranganBaris & " : " & exJurnal.Message)
                        ElseIf statusTakPasti Then
                            ' Pembuatan jurnal gagal DAN pengecekan ke server juga gagal -> kita tidak tahu
                            ' apakah jurnalnya terbentuk. JANGAN sarankan kirim ulang (bisa dobel) dan
                            ' JANGAN diamkan (bisa hilang) — operator harus memeriksa ref-nya di server jurnal.
                            jmlTakPasti += 1
                            gagalBeruntun += 1
                            pesanDetail.AppendLine("- TIDAK PASTI (periksa manual ref " & refferenceID & " di tabel umh.oms sebelum kirim ulang): " & keteranganBaris & " : " & exJurnal.Message)

                            If gagalBeruntun >= 5 Then
                                pesanDetail.AppendLine("... dihentikan: 5 kegagalan beruntun, kemungkinan server jurnal bermasalah.")
                                Exit For
                            End If
                        Else
                            ' Jurnal BELUM dibuat (sudah dipastikan ke server). Klasifikasi aman/hilang DITUNDA
                            ' sampai akhir loop: baru setelah semua baris diproses kita tahu apakah ada saudara
                            ' segrup yang sukses men-set flag (bisa diproses sebelum ATAU sesudah baris ini).
                            gagalBeruntun += 1
                            gagalKeys.Add(grupKey)
                            gagalInfo.Add(keteranganBaris & " : " & exJurnal.Message)

                            ' Stop dini bila gagal-buat beruntun (kemungkinan server jurnal down)
                            If gagalBeruntun >= 5 Then
                                pesanDetail.AppendLine("... dihentikan: 5 kegagalan beruntun, kemungkinan server jurnal bermasalah.")
                                Exit For
                            End If
                        End If
                    End Try
            Next
        End If

        ' Rekonsiliasi akhir baris gagal-buat-jurnal: bila grup-nya ternyata SUDAH ke-flag transaksi lain
        ' segrup (jenis bayar sama, tgl/poli sama, beda kartu/mesin), kirim ulang akan MELEWATI baris ini
        ' (FlagJurnal... IS NULL tak lagi terpenuhi) -> jurnalnya HILANG -> harus dibuat manual, bukan "aman".
        For i As Integer = 0 To gagalKeys.Count - 1
            If flaggedKeys.Contains(gagalKeys(i)) Then
                jmlHilang += 1
                pesanDetail.AppendLine("- HILANG (BUAT JURNAL MANUAL; flag sudah ke-set transaksi lain segrup, kirim ulang TIDAK memprosesnya): " & gagalInfo(i))
            Else
                jmlGagal += 1
                pesanDetail.AppendLine("- GAGAL buat jurnal (aman dikirim ulang): " & gagalInfo(i))
            End If
        Next

        ' Pengakuan pendapatan paket (deferred revenue). Sengaja SESUDAH rekonsiliasi di atas supaya
        ' counter-nya tidak ikut terbaca sebagai "hilang" — flag pemakaian paket per-baris, tidak
        ' pernah dipakai bersama baris lain. Menumpang counter + ringkasan yang sama.
        SendingJurnalPemakaianPaket(jmlSukses, jmlGagal, jmlFlagGagal, jmlTakPasti, jmlDilewati, pesanDetail)

        ' P1.1: tampilkan SATU ringkasan di akhir (bukan MsgBox per baris)
        If jmlGagal > 0 OrElse jmlDilewati > 0 OrElse jmlFlagGagal > 0 OrElse jmlHilang > 0 OrElse jmlTakPasti > 0 Then
            MsgBox("Kirim jurnal selesai." & vbCrLf & _
                   "Sukses      : " & jmlSukses & vbCrLf & _
                   "Gagal       : " & jmlGagal & "  (jurnal dipastikan belum terbentuk — aman dikirim ulang)" & vbCrLf & _
                   "Hilang      : " & jmlHilang & "  (gagal buat jurnal TAPI flag sudah ke-set transaksi lain segrup — BUAT JURNAL MANUAL, jangan kirim ulang)" & vbCrLf & _
                   "Kritis      : " & jmlFlagGagal & "  (jurnal dibuat tapi flag gagal — set flag manual dulu)" & vbCrLf & _
                   "Tidak pasti : " & jmlTakPasti & "  (koneksi putus & pengecekan gagal — periksa ref di server jurnal SEBELUM kirim ulang)" & vbCrLf & _
                   "Dilewati    : " & jmlDilewati & vbCrLf & vbCrLf & _
                   "Detail:" & vbCrLf & pesanDetail.ToString(), _
                   MsgBoxStyle.Exclamation, "Hasil Kirim Jurnal")
        End If
    End Sub

    ' ==========================================================================================
    ' JURNAL PEMAKAIAN PAKET — pengakuan pendapatan (deferred revenue)
    '
    ' Pembelian paket hanya menambah Pendapatan Dibayar Dimuka (lihat coaKredit di SendingJurnal).
    ' Pendapatan baru diakui DI SINI, saat tindakan benar-benar ditarik dari paket:
    '     D  Pendapatan Dibayar Dimuka Divisi  (KodeCoaPendapatanDitangguhkan)
    '     K  Pendapatan Paket Divisi           (KodeCoaPendapatanPaket)
    '
    ' Nilainya SENGAJA TIDAK diambil dari baris bayar VOUCHER di TransaksiPoliBayarAwal. Nilai memo
    ' di sana dihitung FormRekamMedisDokter sebagai HargaNett/Kuota dari HEADER master, padahal untuk
    ' Paket Per-Tindakan kolom Kuota header selalu 0 sehingga pembaginya jatuh ke 1 dan nilainya
    ' membengkak sebesar satu paket penuh per tindakan. Di sini nilainya dihitung ulang dari
    ' LogPenggunaanPaket + snapshot harga saat paket dibeli, jadi jurnalnya benar tanpa menunggu
    ' bug memo itu diperbaiki.
    ' ==========================================================================================
    Private Function SqlNilaiPemakaianPaket() As String
        ' Paket Per-Tindakan : harga per tindakan dari SNAPSHOT saat paket dibeli.
        ' Paket Reguler      : harga paket dibagi kuota ASLI di master = harga per kunjungan
        '                      (bukan kuota sisa — kuota sisa menyusut dan akan menggelembungkan harga).
        Return "CASE WHEN mp.JenisPaket = 'Paket Per-Tindakan' THEN ISNULL(td.NettBayar, 0) " & _
               "     WHEN ISNULL(mp.Kuota, 0) > 0 THEN mp.HargaNett / mp.Kuota " & _
               "     ELSE 0 END"
    End Function

    ' Rangka FROM/WHERE dipakai BERSAMA oleh SELECT agregat dan UPDATE flag, supaya himpunan baris
    ' yang dijurnal dan yang di-flag dijamin sama persis.
    '
    ' APPLY TOP 1, bukan JOIN, sebagai PENGAMAN — bukan karena tabelnya memang banyak baris.
    ' TransaksiDetail justru 1:1 per NoUrut (terukur 10.322 baris / 10.319 NoUrut; yang banyak baris
    ' adalah TransaksiPoliDetail, 2,26 per transaksi). Yang ada cuma baris kembar hasil double-save:
    ' 3 NoUrut, dan 2 di antaranya sudah soft-delete, jadi tersisa satu yang hidup (20250414U00011).
    ' Di sini pengaman itu tetap dipertahankan karena satu baris kembar saja akan membuat pemakaian
    ' paket terhitung dua kali dan pendapatan yang diakui jadi dobel.
    Private Function SqlSumberPemakaianPaket() As String
        Dim tglAwal As Date = DateTimePickerTanggalTransaksiAwal.Value
        Dim tglAkhir As Date = DateTimePickerTanggalTransaksiAkhir.Value

        Dim sql As New StringBuilder()
        sql.AppendLine("FROM LogPenggunaanPaket l")
        sql.AppendLine("CROSS APPLY (SELECT TOP 1 t2.TglPoli FROM TransaksiPoli t2 WHERE t2.NoUrut = l.NoTransaksi AND t2.Deleted = 0) t")
        sql.AppendLine("OUTER APPLY (SELECT TOP 1 d2.JenisPoli, d2.JenisTransaksi FROM TransaksiDetail d2 WHERE d2.NoUrut = l.NoTransaksi) dt")
        sql.AppendLine("LEFT JOIN MasterPaketTindakan mp ON mp.PaketID = l.PaketID")
        sql.AppendLine("LEFT JOIN TransaksiPaketTindakanDetail td ON td.KodeVoucher = l.KodeVoucher AND td.PaketID = l.PaketID AND td.TindakanID = l.TindakanID")
        ' Tanggal transaksi tempat paket ini DIBELI. Dipakai untuk cut-off, dan sengaja mengambil
        ' TglPoli transaksi pembeliannya (bukan CreatedDate paket) supaya patokannya sama persis
        ' dengan tanggal yang dipakai jurnal pembelian di SendingJurnal.
        sql.AppendLine("OUTER APPLY (SELECT TOP 1 tp.TglPoli FROM TransaksiPaketTindakan pk")
        sql.AppendLine("             INNER JOIN TransaksiPoli tp ON tp.NoUrut = pk.NoTransaksi AND tp.Deleted = 0")
        sql.AppendLine("             WHERE pk.KodeVoucher = l.KodeVoucher AND pk.PaketID = l.PaketID AND pk.DeletedDate IS NULL) beli")
        sql.AppendLine("WHERE l.DeletedDate IS NULL AND l.FlagJurnal IS NULL")
        sql.AppendLine("  AND (CONVERT(DATE, t.TglPoli) BETWEEN '" & Format(tglAwal.Date, "yyyyMMdd") & "' AND '" & Format(tglAkhir.Date, "yyyyMMdd") & "')")
        ' Hanya paket yang DIBELI sejak cut-off yang punya saldo Pendapatan Dibayar Dimuka untuk
        ' dilepas. Baris tanpa data pembelian (beli.TglPoli NULL) ikut tersaring keluar — kalau
        ' tidak bisa dibuktikan pernah ditangguhkan, jangan dijurnal.
        sql.AppendLine("  AND CONVERT(DATE, beli.TglPoli) >= '" & Format(TglCutOffPaket(), "yyyyMMdd") & "'")
        ' Nilai 0 = harga paket tak bisa ditentukan (master/snapshot hilang). JANGAN dijurnal dan
        ' JANGAN di-flag: biarkan muncul lagi setelah datanya dilengkapi.
        sql.AppendLine("  AND " & SqlNilaiPemakaianPaket() & " > 0")

        Return sql.ToString()
    End Function

    Function GetDataJurnalPemakaianPaket() As DataTable
        Dim query As New StringBuilder()

        ' ROUND di tingkat agregat: harga paket reguler bisa pecahan (HargaNett/Kuota), dan buku
        ' besar tidak perlu sen. D dan K memakai angka yang SAMA sehingga tetap seimbang.
        query.AppendLine("SELECT CONVERT(DATE, t.TglPoli) AS 'Tgl Transaksi', ISNULL(dt.JenisPoli, '') AS JenisPoli,")
        query.AppendLine("       COUNT(*) AS 'JumlahTindakan', ROUND(SUM(" & SqlNilaiPemakaianPaket() & "), 0) AS 'JumlahBayar'")
        query.AppendLine(SqlSumberPemakaianPaket())
        query.AppendLine("GROUP BY CONVERT(DATE, t.TglPoli), ISNULL(dt.JenisPoli, '')")
        query.AppendLine("HAVING ROUND(SUM(" & SqlNilaiPemakaianPaket() & "), 0) > 0")

        Return ReadSQL(query.ToString())
    End Function

    ' Tandai baris pemakaian yang BARU SAJA dijurnal. WHERE-nya memakai rangka yang sama dengan
    ' agregat, ditambah tanggal + poli grup ini. Melempar bila gagal (pemanggil menandainya KRITIS).
    Private Sub SetFlagPemakaianPaket(ByVal tglTransaksi As Date, ByVal jenisPoli As String, ByVal refferenceID As String)
        Dim query As New StringBuilder()

        query.AppendLine("UPDATE l SET l.FlagJurnal = '" & refferenceID & "', l.FlagJurnalDate = GETDATE()")
        query.AppendLine(SqlSumberPemakaianPaket())
        query.AppendLine("  AND CONVERT(DATE, t.TglPoli) = '" & Format(tglTransaksi, "yyyyMMdd") & "'")
        query.AppendLine("  AND ISNULL(dt.JenisPoli, '') = '" & jenisPoli.Replace("'", "''") & "'")

        WriteSqlChecked(query.ToString())
    End Sub

    ' Loop pengiriman jurnal pemakaian paket. Memakai penjagaan yang sama dengan SendingJurnal
    ' (BuatJurnalUMH yang membaca nilai kembalian, CariNomorJurnal saat koneksi putus, stop dini
    ' setelah 5 kegagalan beruntun) dan menumpang counter + ringkasan yang sama.
    '
    ' Tidak perlu flaggedKeys/"Hilang" seperti di SendingJurnal: di sana satu FlagJurnalHarian*
    ' menaungi beberapa baris jurnal (kartu/mesin/kategori berbeda) sehingga saudara segrup bisa
    ' saling menutupi. Di sini flag melekat PER BARIS LogPenggunaanPaket dan himpunan yang di-flag
    ' persis himpunan yang dijurnal, jadi kegagalan selalu aman dikirim ulang.
    Private Sub SendingJurnalPemakaianPaket(ByRef jmlSukses As Integer, ByRef jmlGagal As Integer, _
                                            ByRef jmlFlagGagal As Integer, ByRef jmlTakPasti As Integer, _
                                            ByRef jmlDilewati As Integer, ByVal pesanDetail As StringBuilder)
        Dim tblPemakaian As DataTable = GetDataJurnalPemakaianPaket()
        If tblPemakaian.Rows.Count = 0 Then Exit Sub

        Dim gagalBeruntun As Integer = 0

        For Each rowPakai As DataRow In tblPemakaian.Rows
            Dim tglTransaksi As Date = CDate(rowPakai("Tgl Transaksi"))
            Dim jenisPoli As String = rowPakai("JenisPoli").ToString()
            Dim nilaiPemakaian As Double = CDbl(rowPakai("JumlahBayar"))
            Dim keteranganBaris As String = "PEMAKAIAN PAKET " & jenisPoli & " " & Format(tglTransaksi, "dd/MM/yyyy") & " (" & rowPakai("JumlahTindakan").ToString() & " tindakan)"

            Dim tblMasterJurnal As DataTable
            Try
                tblMasterJurnal = BacaTabelMySqlChecked("SELECT a.KeteranganLokasi AS 'Lokasi', a.KeteranganPoli AS 'Keterangan', a.KodeLokasiJurnal, a.KodeCoaPendapatanDitangguhkan, a.KodeCoaPendapatanPaket FROM MasterLokasiJurnal a WHERE a.KodeLokasi = '" & kodeLokasiKlinik & "' AND a.KeteranganPoli = '" & jenisPoli.Replace("'", "''") & "' LIMIT 1;", DB_Omset)
            Catch exMaster As Exception
                gagalBeruntun += 1
                jmlGagal += 1
                pesanDetail.AppendLine("- GAGAL buat jurnal (aman dikirim ulang): " & keteranganBaris & " : gagal baca MasterLokasiJurnal (" & exMaster.Message & ")")

                If gagalBeruntun >= 5 Then
                    pesanDetail.AppendLine("... dihentikan: 5 kegagalan beruntun, kemungkinan koneksi/server bermasalah.")
                    Exit For
                End If
                Continue For
            End Try

            If tblMasterJurnal.Rows.Count = 0 Then
                jmlDilewati += 1
                pesanDetail.AppendLine("- Dilewati (tak ada MasterLokasiJurnal): " & keteranganBaris)
                Continue For
            End If

            Dim rowDataJurnal As DataRow = tblMasterJurnal.Rows(0)
            Dim idLokasiJurnal As String = rowDataJurnal("KodeLokasiJurnal").ToString()
            Dim keteranganLokasiJurnal As String = rowDataJurnal("Lokasi").ToString() & " (" & rowDataJurnal("Keterangan").ToString() & ")"

            Dim coaDebit As String = rowDataJurnal("KodeCoaPendapatanDitangguhkan").ToString()
            Dim coaKredit As String = rowDataJurnal("KodeCoaPendapatanPaket").ToString()

            ' Kedua akun WAJIB sah. Selama keuangan belum membuat COA-nya, lebih baik tertahan di sini
            ' (aman dikirim ulang) daripada memposting ke akun yang tidak ada di bagan akun.
            If coaDebit.Trim() = "" OrElse coaDebit.Trim() = "-" OrElse coaKredit.Trim() = "" OrElse coaKredit.Trim() = "-" Then
                gagalBeruntun += 1
                jmlGagal += 1
                pesanDetail.AppendLine("- GAGAL buat jurnal (aman dikirim ulang): " & keteranganBaris & " : COA belum lengkap (D '" & coaDebit & "' / K '" & coaKredit & "') — lengkapi MasterLokasiJurnal untuk divisi ini")

                If gagalBeruntun >= 5 Then
                    pesanDetail.AppendLine("... dihentikan: 5 kegagalan beruntun, kemungkinan koneksi/server bermasalah.")
                    Exit For
                End If
                Continue For
            End If

            Dim refferenceID As String = GetUUID()
            Dim keteranganJurnal As String = "PENGAKUAN - PEMAKAIAN PAKET " & keteranganLokasiJurnal & " " & Format(tglTransaksi, "dd/MM/yyyy")

            ' F_MakeUMH menaruh Accdetil di sisi D dan AccHeader di sisi K (lihat body fungsinya):
            '   Accdetil  = coaDebit  -> D Pendapatan Dibayar Dimuka (saldo titipan berkurang)
            '   AccHeader = coaKredit -> K Pendapatan Paket          (pendapatan diakui)
            Dim sqlJurnal As String = "SELECT F_MakeUMH('" & refferenceID & "', 'out', '', '" & Format(tglTransaksi, "yyyyMMdd") & "', '" & coaKredit & "', '" & coaDebit & "', 'IDR', 1, " & nilaiPemakaian & ", '" & keteranganJurnal.ToUpper() & "', '1', 1, '', '" & keteranganJurnal.ToUpper() & "', '', '', '" & idLokasiJurnal & "', 4, " & nilaiPemakaian & ", 'K')"

            Dim jurnalDibuat As Boolean = False
            Dim nomorJurnal As String = ""
            Dim statusTakPasti As Boolean = False
            Try
                Try
                    nomorJurnal = BuatJurnalUMH(sqlJurnal, DB_Jurnal)
                Catch exBuat As Exception
                    ' Error di klien tidak membuktikan server tidak memproses — pastikan lewat umh.oms.
                    Try
                        nomorJurnal = CariNomorJurnal(refferenceID)
                    Catch exCek As Exception
                        statusTakPasti = True
                        Throw exBuat
                    End Try

                    If nomorJurnal = "" Then Throw exBuat

                    pesanDetail.AppendLine("- Dipulihkan: koneksi terputus tapi jurnal ternyata SUDAH terbentuk (no. " & nomorJurnal & ") -> " & keteranganBaris)
                End Try

                jurnalDibuat = True

                ' Flag inilah yang mencegah pemakaian ini dijurnal dua kali (aturan 9).
                SetFlagPemakaianPaket(tglTransaksi, jenisPoli, refferenceID)

                WriteSQL("INSERT INTO LogJurnalKeuangan (JurnalFlag, JurnalDate, JurnalBy, Status, JenisPoli, JenisTransaksi) VALUES ('" & refferenceID & "', GETDATE(), '" & userInput & "', '" & keteranganJurnal & "', '" & jenisPoli & "', 'POLI')", 4)

                jmlSukses += 1
                gagalBeruntun = 0
            Catch exJurnal As Exception
                If jurnalDibuat Then
                    jmlFlagGagal += 1
                    gagalBeruntun = 0
                    pesanDetail.AppendLine("- KRITIS (set flag manual sebelum kirim ulang): jurnal DIBUAT (no. " & nomorJurnal & ", ref " & refferenceID & ") tapi flag GAGAL -> " & keteranganBaris & " : " & exJurnal.Message)
                ElseIf statusTakPasti Then
                    jmlTakPasti += 1
                    gagalBeruntun += 1
                    pesanDetail.AppendLine("- TIDAK PASTI (periksa manual ref " & refferenceID & " di tabel umh.oms sebelum kirim ulang): " & keteranganBaris & " : " & exJurnal.Message)
                Else
                    jmlGagal += 1
                    gagalBeruntun += 1
                    pesanDetail.AppendLine("- GAGAL buat jurnal (aman dikirim ulang): " & keteranganBaris & " : " & exJurnal.Message)
                End If

                If gagalBeruntun >= 5 Then
                    pesanDetail.AppendLine("... dihentikan: 5 kegagalan beruntun, kemungkinan server jurnal bermasalah.")
                    Exit For
                End If
            End Try
        Next
    End Sub

    ' Set flag jurnal dengan retry. UPDATE-nya idempoten (WHERE FlagJurnalHarian... IS NULL) & ke DB lokal yang andal.
    ' Bila flag berhasil, aggregate ini tak akan muncul lagi di run berikut -> kirim ulang TIDAK menduplikasi jurnal.
    ' Melempar exception bila tetap gagal setelah 3x -> pemanggil menandainya KRITIS (perlu set flag manual).
    Private Sub SetFlagJurnalDenganRetry(ByVal rowTransaksi As DataRow, ByVal refferenceID As String, ByVal jenisPoli As String, ByVal keteranganJenisBayar As String)
        Dim tgl As String = Format(rowTransaksi("Tgl Transaksi"), "yyyyMMdd")
        Dim jenisBayar As String = rowTransaksi("JenisBayar").ToString
        Dim jenisTransaksi As String = rowTransaksi("JenisTransaksi").ToString.Trim
        Dim lastEx As Exception = Nothing

        For attempt As Integer = 1 To 3
            Try
                If jenisTransaksi = "POLI" Then
                    UpdateFlagPoliUmum(tgl, refferenceID, jenisPoli, jenisBayar, keteranganJenisBayar)
                ElseIf jenisTransaksi = "GIGI" Then
                    UpdateFlagPoliGigi(tgl, refferenceID, jenisPoli, jenisBayar, keteranganJenisBayar)
                ElseIf jenisTransaksi = "LAB" Then
                    UpdateFlagLaboratorium(tgl, refferenceID, jenisPoli, jenisBayar, keteranganJenisBayar)
                End If
                Return ' sukses
            Catch ex As Exception
                lastEx = ex
                System.Threading.Thread.Sleep(500)
            End Try
        Next

        Throw New Exception("Gagal set flag jurnal setelah 3x percobaan. " & lastEx.Message)
    End Sub

    Private Sub UpdateFlagPoliUmum(ByVal tglTransaksi As String, ByVal flagJurnal As String, ByVal namaPoli As String, ByVal jenisBayar As String, ByVal stringFlag As String)
        Dim query As New StringBuilder()

        query.AppendLine("UPDATE TransaksiPoli")
        query.AppendLine("SET FlagJurnalHarian" & stringFlag & " = '" & flagJurnal & "'")
        query.AppendLine("WHERE CONVERT(DATE, TglPoli) = '" & tglTransaksi & "'")
        query.AppendLine("  AND Deleted = 0")
        query.AppendLine("  AND FlagJurnalHarian" & stringFlag & " IS NULL")
        query.AppendLine("  AND TransPoliID IN (")
        query.AppendLine("      SELECT tp.TransPoliID")
        query.AppendLine("      FROM TransaksiPoliBayar tb")
        query.AppendLine("      INNER JOIN TransaksiPoli tp ON tp.TransPoliID = tb.TransPoliID")
        query.AppendLine("      WHERE tb.JenisBayar = '" & jenisBayar & "' AND tb.JumlahBayar > 0")
        query.AppendLine("        AND tp.NoUrut IN (")
        query.AppendLine("            SELECT td.NoUrut")
        query.AppendLine("            FROM TransaksiDetail td")
        If tipeJurnal = "Poli" Then
            query.AppendLine("            WHERE td.JenisPoli = '" & namaPoli & "'")
        End If
        query.AppendLine("        )")
        query.AppendLine("      UNION ALL")
        query.AppendLine("      SELECT tp.TransPoliID")
        query.AppendLine("      FROM TransaksiPoliBayarAwal tba")
        query.AppendLine("      INNER JOIN TransaksiPoli tp ON tp.TransPoliID = tba.TransPoliID")
        query.AppendLine("      WHERE tba.JenisBayar = '" & jenisBayar & "' AND tba.JumlahBayar > 0")
        query.AppendLine("        AND tp.NoUrut IN (")
        query.AppendLine("            SELECT td.NoUrut")
        query.AppendLine("            FROM TransaksiDetail td")
        If tipeJurnal = "Poli" Then
            query.AppendLine("            WHERE td.JenisPoli = '" & namaPoli & "'")
        End If
        query.AppendLine("        )")
        query.AppendLine("  )")

        ' Exec Query
        WriteSqlChecked(query.ToString())
    End Sub

    Private Sub UpdateFlagPoliGigi(ByVal tglTransaksi As String, ByVal flagJurnal As String, ByVal namaPoli As String, ByVal jenisBayar As String, ByVal stringFlag As String)
        Dim query As New StringBuilder()

        query.AppendLine("UPDATE TransaksiGigi")
        query.AppendLine("SET FlagJurnalHarian" & stringFlag & " = '" & flagJurnal & "'")
        query.AppendLine("WHERE CONVERT(DATE, TglGigi) = '" & tglTransaksi & "'")
        query.AppendLine("  AND Deleted = 0")
        query.AppendLine("  AND FlagJurnalHarian" & stringFlag & " IS NULL")
        query.AppendLine("  AND TransGigiID IN (")
        query.AppendLine("      SELECT tp.TransGigiID")
        query.AppendLine("      FROM TransaksiGigiBayar tb")
        query.AppendLine("      INNER JOIN TransaksiGigi tp ON tp.TransGigiID = tb.TransGigiID")
        query.AppendLine("      WHERE tb.JenisBayar = '" & jenisBayar & "' AND tb.JumlahBayar > 0")
        query.AppendLine("        AND tp.NoUrut IN (")
        query.AppendLine("            SELECT td.NoUrut")
        query.AppendLine("            FROM TransaksiDetail td")
        If tipeJurnal = "Poli" Then
            query.AppendLine("            WHERE td.JenisPoli = '" & namaPoli & "'")
        End If
        query.AppendLine("        )")
        query.AppendLine("      UNION ALL")
        query.AppendLine("      SELECT tp.TransGigiID")
        query.AppendLine("      FROM TransaksiGigiBayarAwal tba")
        query.AppendLine("      INNER JOIN TransaksiGigi tp ON tp.TransGigiID = tba.TransGigiID")
        query.AppendLine("      WHERE tba.JenisBayar = '" & jenisBayar & "' AND tba.JumlahBayar > 0")
        query.AppendLine("        AND tp.NoUrut IN (")
        query.AppendLine("            SELECT td.NoUrut")
        query.AppendLine("            FROM TransaksiDetail td")
        If tipeJurnal = "Poli" Then
            query.AppendLine("            WHERE td.JenisPoli = '" & namaPoli & "'")
        End If
        query.AppendLine("        )")
        query.AppendLine("  )")

        ' Exec Query
        WriteSqlChecked(query.ToString())
    End Sub

    Private Sub UpdateFlagLaboratorium(ByVal tglTransaksi As String, ByVal flagJurnal As String, ByVal namaPoli As String, ByVal jenisBayar As String, ByVal stringFlag As String)
        Dim query As New StringBuilder()

        query.AppendLine("UPDATE TransaksiLab")
        query.AppendLine("SET FlagJurnalHarian" & stringFlag & " = '" & flagJurnal & "'")
        query.AppendLine("WHERE CONVERT(DATE, TglLab) = '" & tglTransaksi & "'")
        query.AppendLine("  AND Deleted = 0 AND SendKeu IS NOT NULL")
        query.AppendLine("  AND FlagJurnalHarian" & stringFlag & " IS NULL")
        query.AppendLine("  AND TransLabID IN (")
        query.AppendLine("      SELECT tb.TransLabID")
        query.AppendLine("      FROM TransaksiLabBayar tb")
        query.AppendLine("      WHERE tb.JenisBayar = '" & jenisBayar & "' AND tb.JumlahBayar > 0")
        query.AppendLine("  )")

        ' Exec Query
        WriteSqlChecked(query.ToString())
    End Sub

    Function GetDataUploadJurnalPoliUmum() As DataTable
        Dim tglTransaksiAwal As Date = DateTimePickerTanggalTransaksiAwal.Value
        Dim tglTransaksiAkhir As Date = DateTimePickerTanggalTransaksiAkhir.Value
        Dim tblResult As New DataTable

        Dim query As New StringBuilder()

        query.AppendLine("WITH FilteredTransPoli AS (")
        query.AppendLine("    SELECT TransPoliID, FlagJurnalHarianTagihan, FlagJurnalHarianTunai, FlagJurnalHarianDebet, FlagJurnalHarianKredit")
        query.AppendLine("    FROM TransaksiPoli")
        ' Filter per-jenis-bayar: ikutkan transaksi bila MINIMAL satu flag masih NULL (bukan harus keempatnya NULL)
        query.AppendLine("    WHERE (CONVERT(DATE, TglPoli) BETWEEN '" & Format(tglTransaksiAwal.Date, "yyyyMMdd") & "' AND '" & Format(tglTransaksiAkhir.Date, "yyyyMMdd") & "') AND Deleted = 0 AND (FlagJurnalHarianTagihan IS NULL OR FlagJurnalHarianTunai IS NULL OR FlagJurnalHarianDebet IS NULL OR FlagJurnalHarianKredit IS NULL)")
        query.AppendLine("),")
        query.AppendLine(SqlCteNilaiKategori())
        If tipeJurnal = "Poli" Then
            query.AppendLine("SELECT SUM(kat.Nilai) AS 'JumlahBayar', tblBayar.JenisBayar, tblBayar.kartu, tblBayar.mesin, d.JenisPoli, d.JenisTransaksi, CONVERT(DATE, t.TglPoli) AS 'Tgl Transaksi', kat.Kategori")
        ElseIf tipeJurnal = "Transaksi" Then
            query.AppendLine("SELECT SUM(kat.Nilai) AS 'JumlahBayar', tblBayar.JenisBayar, tblBayar.kartu, tblBayar.mesin, d.JenisTransaksi, CONVERT(DATE, t.TglPoli) AS 'Tgl Transaksi', kat.Kategori")
        End If
        query.AppendLine("FROM (")
        query.AppendLine("    SELECT tb.TransPoliID, tb.JenisBayar, tb.JumlahBayar, tb.Kembali, tb.kartu, tb.mesin")
        query.AppendLine("    FROM TransaksiPoliBayar tb")
        query.AppendLine("    INNER JOIN FilteredTransPoli ft ON tb.TransPoliID = ft.TransPoliID")
        query.AppendLine("    WHERE tb.JumlahBayar > 0 AND tb.JenisBayar IN ('TAGIHAN', 'TUNAI', 'DEBET', 'CARD')")
        query.AppendLine("      AND ((tb.JenisBayar = 'TUNAI' AND ft.FlagJurnalHarianTunai IS NULL) OR (tb.JenisBayar = 'DEBET' AND ft.FlagJurnalHarianDebet IS NULL) OR (tb.JenisBayar = 'CARD' AND ft.FlagJurnalHarianKredit IS NULL) OR (tb.JenisBayar = 'TAGIHAN' AND ft.FlagJurnalHarianTagihan IS NULL))")
        query.AppendLine("    UNION ALL")
        query.AppendLine("    SELECT tba.TransPoliID, tba.JenisBayar, tba.JumlahBayar, tba.Kembali, tba.kartu, tba.mesin")
        query.AppendLine("    FROM TransaksiPoliBayarAwal tba")
        query.AppendLine("    INNER JOIN FilteredTransPoli ft ON tba.TransPoliID = ft.TransPoliID")
        query.AppendLine("    WHERE tba.JumlahBayar > 0 AND tba.JenisBayar IN ('TAGIHAN', 'TUNAI', 'DEBET', 'CARD')")
        query.AppendLine("      AND ((tba.JenisBayar = 'TUNAI' AND ft.FlagJurnalHarianTunai IS NULL) OR (tba.JenisBayar = 'DEBET' AND ft.FlagJurnalHarianDebet IS NULL) OR (tba.JenisBayar = 'CARD' AND ft.FlagJurnalHarianKredit IS NULL) OR (tba.JenisBayar = 'TAGIHAN' AND ft.FlagJurnalHarianTagihan IS NULL))")
        query.AppendLine(") AS tblBayar")
        query.AppendLine("LEFT JOIN NilaiKategori nk ON nk.TransPoliID = tblBayar.TransPoliID")
        query.AppendLine(SqlCrossApplyKategori())
        query.AppendLine("LEFT JOIN TransaksiPoli t ON tblBayar.TransPoliID = t.TransPoliID")
        query.AppendLine("LEFT JOIN TransaksiDetail d ON t.NoUrut = d.NoUrut")
        query.AppendLine("WHERE kat.Nilai <> 0")
        If tipeJurnal = "Poli" Then
            query.AppendLine("GROUP BY CONVERT(DATE, t.TglPoli), d.JenisPoli, d.JenisTransaksi, tblBayar.JenisBayar, tblBayar.kartu, tblBayar.mesin, kat.Kategori")
        ElseIf tipeJurnal = "Transaksi" Then
            query.AppendLine("GROUP BY CONVERT(DATE, t.TglPoli), d.JenisTransaksi, tblBayar.JenisBayar, tblBayar.kartu, tblBayar.mesin, kat.Kategori")
        End If

        tblResult = ReadSQL(query.ToString())

        Return tblResult
    End Function

    Function GetDataUploadJurnalPoliGigi() As DataTable
        Dim tglTransaksiAwal As Date = DateTimePickerTanggalTransaksiAwal.Value
        Dim tglTransaksiAkhir As Date = DateTimePickerTanggalTransaksiAkhir.Value
        Dim tblResult As New DataTable

        Dim query As New StringBuilder()

        query.AppendLine("WITH FilteredTransGigi AS (")
        query.AppendLine("    SELECT TransGigiID, FlagJurnalHarianTagihan, FlagJurnalHarianTunai, FlagJurnalHarianDebet, FlagJurnalHarianKredit")
        query.AppendLine("    FROM TransaksiGigi")
        query.AppendLine("    WHERE (CONVERT(DATE, TglGigi) BETWEEN '" & Format(tglTransaksiAwal.Date, "yyyyMMdd") & "' AND '" & Format(tglTransaksiAkhir.Date, "yyyyMMdd") & "')")
        ' Filter per-jenis-bayar: minimal satu flag NULL (bukan harus keempatnya)
        query.AppendLine("      AND Deleted = 0 AND (FlagJurnalHarianTagihan IS NULL OR FlagJurnalHarianTunai IS NULL OR FlagJurnalHarianDebet IS NULL OR FlagJurnalHarianKredit IS NULL)")
        query.AppendLine(")")
        ' GIGI tidak punya jalur paket — kategori dikunci NON PAKET agar kolomnya sama saat di-Merge
        If tipeJurnal = "Poli" Then
            query.AppendLine("SELECT SUM(tblBayar.JumlahBayar - tblBayar.Kembali) AS 'JumlahBayar', tblBayar.JenisBayar, tblBayar.kartu, tblBayar.mesin, d.JenisPoli, d.JenisTransaksi, CONVERT(DATE, t.TglGigi) AS 'Tgl Transaksi', '" & KATEGORI_NON_PAKET & "' AS Kategori")
        ElseIf tipeJurnal = "Transaksi" Then
            query.AppendLine("SELECT SUM(tblBayar.JumlahBayar - tblBayar.Kembali) AS 'JumlahBayar', tblBayar.JenisBayar, tblBayar.kartu, tblBayar.mesin, d.JenisTransaksi, CONVERT(DATE, t.TglGigi) AS 'Tgl Transaksi', '" & KATEGORI_NON_PAKET & "' AS Kategori")
        End If
        query.AppendLine("FROM (")
        query.AppendLine("    SELECT tb.TransGigiID, tb.JenisBayar, tb.JumlahBayar, tb.Kembali, tb.kartu, tb.mesin")
        query.AppendLine("    FROM TransaksiGigiBayar tb")
        query.AppendLine("    INNER JOIN FilteredTransGigi ft ON tb.TransGigiID = ft.TransGigiID")
        query.AppendLine("    WHERE tb.JumlahBayar > 0 AND tb.JenisBayar IN ('TAGIHAN', 'TUNAI', 'DEBET', 'CARD')")
        query.AppendLine("      AND ((tb.JenisBayar = 'TUNAI' AND ft.FlagJurnalHarianTunai IS NULL) OR (tb.JenisBayar = 'DEBET' AND ft.FlagJurnalHarianDebet IS NULL) OR (tb.JenisBayar = 'CARD' AND ft.FlagJurnalHarianKredit IS NULL) OR (tb.JenisBayar = 'TAGIHAN' AND ft.FlagJurnalHarianTagihan IS NULL))")
        query.AppendLine("    UNION ALL")
        query.AppendLine("    SELECT tba.TransGigiID, tba.JenisBayar, tba.JumlahBayar, tba.Kembali, tba.kartu, tba.mesin")
        query.AppendLine("    FROM TransaksiGigiBayarAwal tba")
        query.AppendLine("    INNER JOIN FilteredTransGigi ft ON tba.TransGigiID = ft.TransGigiID")
        query.AppendLine("    WHERE tba.JumlahBayar > 0 AND tba.JenisBayar IN ('TAGIHAN', 'TUNAI', 'DEBET', 'CARD')")
        query.AppendLine("      AND ((tba.JenisBayar = 'TUNAI' AND ft.FlagJurnalHarianTunai IS NULL) OR (tba.JenisBayar = 'DEBET' AND ft.FlagJurnalHarianDebet IS NULL) OR (tba.JenisBayar = 'CARD' AND ft.FlagJurnalHarianKredit IS NULL) OR (tba.JenisBayar = 'TAGIHAN' AND ft.FlagJurnalHarianTagihan IS NULL))")
        query.AppendLine(") AS tblBayar")
        query.AppendLine("LEFT JOIN TransaksiGigi t ON tblBayar.TransGigiID = t.TransGigiID")
        query.AppendLine("LEFT JOIN TransaksiDetail d ON t.NoUrut = d.NoUrut")
        If tipeJurnal = "Poli" Then
            query.AppendLine("GROUP BY CONVERT(DATE, t.TglGigi), d.JenisPoli, d.JenisTransaksi, tblBayar.JenisBayar, tblBayar.kartu, tblBayar.mesin")
        ElseIf tipeJurnal = "Transaksi" Then
            query.AppendLine("GROUP BY CONVERT(DATE, t.TglGigi), d.JenisTransaksi, tblBayar.JenisBayar, tblBayar.kartu, tblBayar.mesin")
        End If

        tblResult = ReadSQL(query.ToString())

        Return tblResult
    End Function

    Function GetDataUploadJurnalLaboratorium() As DataTable
        Dim tglTransaksiAwal As Date = DateTimePickerTanggalTransaksiAwal.Value
        Dim tglTransaksiAkhir As Date = DateTimePickerTanggalTransaksiAkhir.Value
        Dim tblResult As New DataTable

        Dim query As New StringBuilder()

        query.AppendLine("WITH FilteredTransLab AS (")
        query.AppendLine("    SELECT TransLabID, FlagJurnalHarianTagihan, FlagJurnalHarianTunai, FlagJurnalHarianDebet, FlagJurnalHarianKredit")
        query.AppendLine("    FROM TransaksiLab")
        query.AppendLine("    WHERE (CONVERT(DATE, TglLab) BETWEEN '" & Format(tglTransaksiAwal.Date, "yyyyMMdd") & "' AND '" & Format(tglTransaksiAkhir.Date, "yyyyMMdd") & "')")
        ' Filter per-jenis-bayar: minimal satu flag NULL (bukan harus keempatnya)
        query.AppendLine("      AND Deleted = 0 AND (FlagJurnalHarianTagihan IS NULL OR FlagJurnalHarianTunai IS NULL OR FlagJurnalHarianDebet IS NULL OR FlagJurnalHarianKredit IS NULL)")
        query.AppendLine("      AND SendKeu IS NOT NULL")
        query.AppendLine(")")
        ' LAB tidak punya jalur paket — kategori dikunci NON PAKET agar kolomnya sama saat di-Merge
        If tipeJurnal = "Poli" Then
            query.AppendLine("SELECT SUM(tblBayar.JumlahBayar - tblBayar.Kembali) AS 'JumlahBayar', tblBayar.JenisBayar, tblBayar.kartu, tblBayar.mesin, d.JenisPoli, d.JenisTransaksi, CONVERT(DATE, t.TglLab) AS 'Tgl Transaksi', '" & KATEGORI_NON_PAKET & "' AS Kategori")
        ElseIf tipeJurnal = "Transaksi" Then
            query.AppendLine("SELECT SUM(tblBayar.JumlahBayar - tblBayar.Kembali) AS 'JumlahBayar', tblBayar.JenisBayar, tblBayar.kartu, tblBayar.mesin, d.JenisTransaksi, CONVERT(DATE, t.TglLab) AS 'Tgl Transaksi', '" & KATEGORI_NON_PAKET & "' AS Kategori")
        End If
        query.AppendLine("FROM (")
        query.AppendLine("    SELECT tb.TransLabID, tb.JenisBayar, tb.JumlahBayar, tb.Kembali, tb.kartu, tb.mesin")
        query.AppendLine("    FROM TransaksiLabBayar tb")
        query.AppendLine("    INNER JOIN FilteredTransLab ft ON tb.TransLabID = ft.TransLabID")
        query.AppendLine("    WHERE tb.JumlahBayar > 0 AND tb.JenisBayar IN ('TAGIHAN', 'TUNAI', 'DEBET', 'CARD')")
        query.AppendLine("      AND ((tb.JenisBayar = 'TUNAI' AND ft.FlagJurnalHarianTunai IS NULL) OR (tb.JenisBayar = 'DEBET' AND ft.FlagJurnalHarianDebet IS NULL) OR (tb.JenisBayar = 'CARD' AND ft.FlagJurnalHarianKredit IS NULL) OR (tb.JenisBayar = 'TAGIHAN' AND ft.FlagJurnalHarianTagihan IS NULL))")
        query.AppendLine(") AS tblBayar")
        query.AppendLine("LEFT JOIN TransaksiLab t ON tblBayar.TransLabID = t.TransLabID")
        query.AppendLine("LEFT JOIN TransaksiDetail d ON t.NoUrut = d.NoUrut")
        If tipeJurnal = "Poli" Then
            query.AppendLine("GROUP BY CONVERT(DATE, t.TglLab), d.JenisPoli, d.JenisTransaksi, tblBayar.JenisBayar, tblBayar.kartu, tblBayar.mesin")
        ElseIf tipeJurnal = "Transaksi" Then
            query.AppendLine("GROUP BY CONVERT(DATE, t.TglLab), d.JenisTransaksi, tblBayar.JenisBayar, tblBayar.kartu, tblBayar.mesin")
        End If
        tblResult = ReadSQL(query.ToString())

        Return tblResult
    End Function
End Class