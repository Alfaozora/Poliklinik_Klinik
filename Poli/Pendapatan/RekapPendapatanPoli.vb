Imports System.Drawing
Imports System.IO
Imports System.Text

Public Class RekapPendapatanPoli
    Dim TstrPoli As String = ""
    Dim TstrGigi As String = ""
    Dim TstrAdmin As String = ""
    Dim thread As System.Threading.Thread

    ' Set Connection
    Private DB_Keuangan As TLcon
    Private DB_Keuangan2 As TLcon
    Private DB_Jurnal As TLcon

    ' Variabel Lokal
    Private tanggalTransaksiReport As String = ""

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
    End Sub

    Function CreateTableInvoice() As DataTable
        Dim Thasil As New DataTable

        insertRowToTbls(Thasil, "tyinterger", "No")
        insertRowToTbls(Thasil, "Typstring", "Tgl lab")
        insertRowToTbls(Thasil, "Typstring", "Jumlah Peserta")
        insertRowToTbls(Thasil, "Typstring", "Keterangan")
        insertRowToTbls(Thasil, "tyinterger", "Total")

        Return Thasil
    End Function

    Function CreateTable() As DataTable
        Dim Thasil As New DataTable

        insertRowToTbls(Thasil, "tyinterger", "No")
        insertRowToTbls(Thasil, "Typstring", "NoJenisBayar")
        insertRowToTbls(Thasil, "Typstring", "No Lab")
        insertRowToTbls(Thasil, "typdate", "Tanggal Lab")
        insertRowToTbls(Thasil, "Typstring", "NIP")
        insertRowToTbls(Thasil, "Typstring", "Nama")
        insertRowToTbls(Thasil, "typdate", "Tgl Lahir")
        insertRowToTbls(Thasil, "Typstring", "Alamat") '
        insertRowToTbls(Thasil, "Typstring", "pemeriksaan")
        insertRowToTbls(Thasil, "tyinterger", "Tagihan")
        insertRowToTbls(Thasil, "tyinterger", "Translabid")
        insertRowToTbls(Thasil, "Typstring", "mesin")
        insertRowToTbls(Thasil, "Typstring", "kartu")
        insertRowToTbls(Thasil, "Typstring", "JenisTransaksi")

        For Each Tcol As DataColumn In Thasil.Columns
            Tcol.ReadOnly = True
        Next

        Return Thasil
    End Function

    Public Sub LoadPasien(ByRef Trow() As DataRow)
        If Trow.Length = 0 Then
            SetClear()
        Else
            Dim Tquery As String = ""
            Dim Tcompany As String = ""
            Dim Tjenistransaksi As String = ""
            Dim Tpemeriksaan As String = ""
            Dim Torderby As String = ""
            Dim ConcatCompany As String = ""
            Dim TgllabStart As Date = "12/31/9998"
            Dim TgllabEnd As Date = "12/31/9998"
            Dim jenisBayar As String = ""

            'Company
            If txkodecabang.Text <> "" And ComboBoxPembayaran.SelectedIndex = 0 Then
                ConcatCompany = TextBoxKeteranganPerusahaan.Text + "-" + txkodecabang.Text
                Tcompany = " and (c.NoJenisBayar = '" & TextBoxKeteranganPerusahaan.Text & "' or c.NoJenisBayar='" & ConcatCompany & "')"
            End If

            'Jenis Transaksi
            If ComboBoxPembayaran.SelectedIndex = 0 Then
                jenisBayar = "TAGIHAN"
            ElseIf ComboBoxPembayaran.SelectedIndex = 1 Then
                jenisBayar = "DEBET"
            ElseIf ComboBoxPembayaran.SelectedIndex = 2 Then
                jenisBayar = "TUNAI"
            ElseIf ComboBoxPembayaran.SelectedIndex = 3 Then
                jenisBayar = "CARD"
            End If

            ' Set Jenis Bayar
            Tjenistransaksi = " AND c.JenisBayar='" & jenisBayar & "' "

            'Set No urut
            TstrPoli = ""
            TstrGigi = ""
            TstrAdmin = ""
            Dim TtempPoli As String = "("
            Dim TtempGigi As String = "("
            Dim TtempAdmin As String = "("
            For i As Integer = 0 To Trow.Length - 1
                If Trow(i)("JenisTransaksi").ToString.Trim = "POLI" Then
                    TtempPoli = TtempPoli & "'" & Trow(i)("No Lab").ToString.Trim & "',"
                ElseIf Trow(i)("JenisTransaksi").ToString.Trim = "GIGI" Then
                    TtempGigi = TtempGigi & "'" & Trow(i)("No Lab").ToString.Trim & "',"
                ElseIf Trow(i)("JenisTransaksi").ToString.Trim = "ADMIN" Then
                    TtempAdmin = TtempAdmin & "'" & Trow(i)("No Lab").ToString.Trim & "',"
                End If
            Next
            TstrPoli = Strings.Left(TtempPoli, TtempPoli.Length - 1) & ")"
            If TstrPoli.Trim = "" Or TstrPoli.Trim = ")" Then TstrPoli = "('-')"
            TstrGigi = Strings.Left(TtempGigi, TtempGigi.Length - 1) & ")"
            If TstrGigi.Trim = "" Or TstrGigi.Trim = ")" Then TstrGigi = "('-')"
            TstrAdmin = Strings.Left(TtempAdmin, TtempAdmin.Length - 1) & ")"
            If TstrAdmin.Trim = "" Or TstrAdmin.Trim = ")" Then TstrAdmin = "('-')"

            ' Set Query Builder
            Dim queryBuilder As New StringBuilder()

            ' Create Query
            If ComboBoxJenisTransaksi.SelectedIndex = 0 Then
                'Tquery = "SELECT t1.TransPoliID as 'Translabid', '-' as 'DetailPemeriksaan', t1.NoJenisBayar, t1.[No Lab], CONVERT(date, t1.[Tanggal Lab]) as 'Tanggal Lab', t1.NoNIP, t1.Nama, t1.[Tgl Lahir], t1.DomisiliAlamat, '-' as 'DetailPemeriksaan', SUM(t1.Tagihan) as 'Tagihan', t1.kartu, t1.mesin, t1.JenisTransaksi FROM " & _
                '             "(SELECT c.TransPoliIDBayar AS 'No', a.TransPoliID, c.NoJenisBayar, a.NoUrut as 'No Lab', CONVERT(date, a.TglPoli) as 'Tanggal Lab', b.NoNIP as 'NoNIP',b.Nama,b.TglLahir as 'Tgl Lahir',b.DomisiliAlamat, '-' as 'DetailPemeriksaan', c.JumlahBayar-c.Kembali as 'Tagihan', c.kartu, c.mesin, 'POLI' as 'JenisTransaksi' " & _
                '             "FROM TransaksiPoli a " & _
                '             "LEFT JOIN MasterPasien b on a.idinternet=b.NoRekamMedis " & _
                '             "LEFT JOIN TransaksiPoliBayar c on a.TransPoliID=c.TransPoliID " & _
                '             "WHERE a.Nourut in " & TstrPoli & " and a.deleted <> 1 " & Tcompany & Tjenistransaksi & _
                '             "UNION " & _
                '             "SELECT c.TransPoliIDBayar AS 'No', a.TransPoliID, c.NoJenisBayar, a.NoUrut as 'No Lab', CONVERT(date, a.TglPoli) as 'Tanggal Lab', b.NoNIP as 'NoNIP',b.Nama,b.TglLahir as 'Tgl Lahir',b.DomisiliAlamat, '-' as 'DetailPemeriksaan', c.JumlahBayar-c.Kembali as 'Tagihan', c.kartu, c.mesin, 'POLI' as 'JenisTransaksi' " & _
                '             "FROM TransaksiPoli a " & _
                '             "LEFT JOIN MasterPasien b on a.idinternet=b.NoRekamMedis " & _
                '             "LEFT JOIN TransaksiPoliBayarAwal c on a.TransPoliID=c.TransPoliID " & _
                '             "WHERE a.Nourut in " & TstrPoli & " and a.deleted <> 1 " & Tcompany & Tjenistransaksi & ") as t1  " & _
                '         "WHERE CONVERT(date, t1.[Tanggal Lab]) BETWEEN '" & Format(dtprocess.Value, "MM-dd-yyyy") & "' and '" & Format(dtprocessend.Value, "MM-dd-yyyy") & "'" & _
                '         "GROUP BY t1.TransPoliID, t1.NoJenisBayar, t1.[No Lab], CONVERT(date, t1.[Tanggal Lab]), t1.NoNIP, t1.Nama, t1.[Tgl Lahir], t1.DomisiliAlamat, t1.kartu, t1.mesin, t1.JenisTransaksi  "

                queryBuilder.AppendLine("SELECT t1.TransPoliID AS 'Translabid', '-' AS 'DetailPemeriksaan', t1.NoJenisBayar, t1.[No Lab], CONVERT(date, t1.[Tanggal Lab]) AS 'Tanggal Lab', t1.NoNIP, t1.Nama, t1.[Tgl Lahir], t1.DomisiliAlamat, '-' AS 'DetailPemeriksaan', SUM(t1.Tagihan) AS 'Tagihan', t1.kartu, t1.mesin, t1.JenisTransaksi, t1.JenisKasir")
                queryBuilder.AppendLine("FROM (")
                queryBuilder.AppendLine("    SELECT c.TransPoliIDBayar AS 'No', a.TransPoliID, c.NoJenisBayar, a.NoUrut AS 'No Lab', CONVERT(date, a.TglPoli) AS 'Tanggal Lab', b.NoNIP AS 'NoNIP', b.Nama, b.TglLahir AS 'Tgl Lahir', b.DomisiliAlamat, '-' AS 'DetailPemeriksaan', c.JumlahBayar - c.Kembali AS 'Tagihan', c.kartu, c.mesin, 'POLI' AS 'JenisTransaksi', '0' AS JenisKasir")
                queryBuilder.AppendLine("    FROM TransaksiPoli a")
                queryBuilder.AppendLine("         LEFT JOIN MasterPasien b ON a.idinternet = b.NoRekamMedis")
                queryBuilder.AppendLine("         LEFT JOIN TransaksiPoliBayar c ON a.TransPoliID = c.TransPoliID")
                queryBuilder.AppendLine("    WHERE a.Nourut IN " & TstrPoli & " AND a.deleted <> 1 " & Tcompany & Tjenistransaksi & "")
                queryBuilder.AppendLine("    UNION")
                queryBuilder.AppendLine("    SELECT c.TransPoliIDBayar AS 'No', a.TransPoliID, c.NoJenisBayar, a.NoUrut AS 'No Lab', CONVERT(date, a.TglPoli) AS 'Tanggal Lab', b.NoNIP AS 'NoNIP', b.Nama, b.TglLahir AS 'Tgl Lahir', b.DomisiliAlamat, '-' AS 'DetailPemeriksaan', c.JumlahBayar - c.Kembali AS 'Tagihan', c.kartu, c.mesin, 'POLI' AS 'JenisTransaksi', '1' AS JenisKasir")
                queryBuilder.AppendLine("    FROM TransaksiPoli a")
                queryBuilder.AppendLine("         LEFT JOIN MasterPasien b ON a.idinternet = b.NoRekamMedis")
                queryBuilder.AppendLine("         LEFT JOIN TransaksiPoliBayarAwal c ON a.TransPoliID = c.TransPoliID")
                queryBuilder.AppendLine("    WHERE a.Nourut IN " & TstrPoli & " AND a.deleted <> 1 " & Tcompany & Tjenistransaksi & "")
                queryBuilder.AppendLine(") AS t1")
                queryBuilder.AppendLine("WHERE CONVERT(date, t1.[Tanggal Lab]) BETWEEN '" & Format(dtprocess.Value, "MM-dd-yyyy") & "' and '" & Format(dtprocessend.Value, "MM-dd-yyyy") & "'")
                queryBuilder.AppendLine("GROUP BY t1.TransPoliID, t1.NoJenisBayar, t1.[No Lab], CONVERT(date, t1.[Tanggal Lab]), t1.NoNIP, t1.Nama, t1.[Tgl Lahir], t1.DomisiliAlamat, t1.kartu, t1.mesin, t1.JenisTransaksi, t1.JenisKasir")
            ElseIf ComboBoxJenisTransaksi.SelectedIndex = 1 Then
                'Tquery = "SELECT t1.TransGigiID as 'Translabid', '-' as 'DetailPemeriksaan', t1.NoJenisBayar, t1.[No Lab], CONVERT(date, t1.[Tanggal Lab]) as 'Tanggal Lab', t1.NoNIP, t1.Nama, t1.[Tgl Lahir], t1.DomisiliAlamat, '-' as 'DetailPemeriksaan', SUM(t1.Tagihan) as 'Tagihan', t1.kartu, t1.mesin, t1.JenisTransaksi FROM " & _
                '             "(SELECT c.TransGigiIDBayar AS 'No', a.TransGigiID, c.NoJenisBayar, a.NoUrut as 'No Lab', CONVERT(date, a.TglGigi) as 'Tanggal Lab', b.NoNIP as 'NoNIP',b.Nama,b.TglLahir as 'Tgl Lahir',b.DomisiliAlamat, '-' as 'DetailPemeriksaan', c.JumlahBayar-c.Kembali as 'Tagihan', c.kartu, c.mesin, 'GIGI' as 'JenisTransaksi' " & _
                '             "FROM TransaksiGigi a " & _
                '             "LEFT JOIN MasterPasien b on a.idinternet=b.NoRekamMedis " & _
                '             "LEFT JOIN TransaksiGigiBayar c on a.TransGigiID=c.TransGigiID " & _
                '             "WHERE a.Nourut in " & TstrGigi & " and a.deleted <> 1 " & Tcompany & Tjenistransaksi & _
                '             "UNION " & _
                '             "SELECT c.TransGigiIDBayar AS 'No', a.TransGigiID, c.NoJenisBayar, a.NoUrut as 'No Lab', CONVERT(date, a.TglGigi) as 'Tanggal Lab', b.NoNIP as 'NoNIP',b.Nama,b.TglLahir as 'Tgl Lahir',b.DomisiliAlamat, '-' as 'DetailPemeriksaan', c.JumlahBayar-c.Kembali as 'Tagihan', c.kartu, c.mesin, 'GIGI' as 'JenisTransaksi' " & _
                '             "FROM TransaksiGigi a " & _
                '             "LEFT JOIN MasterPasien b on a.idinternet=b.NoRekamMedis " & _
                '             "LEFT JOIN TransaksiGigiBayarAwal c on a.TransGigiID=c.TransGigiID " & _
                '             "WHERE a.Nourut in " & TstrGigi & " and a.deleted <> 1 " & Tcompany & Tjenistransaksi & ") as t1  " & _
                '         "WHERE CONVERT(date, t1.[Tanggal Lab]) BETWEEN '" & Format(dtprocess.Value, "MM-dd-yyyy") & "' and '" & Format(dtprocessend.Value, "MM-dd-yyyy") & "'" & _
                '         "GROUP BY t1.TransGigiID, t1.NoJenisBayar, t1.[No Lab], CONVERT(date, t1.[Tanggal Lab]), t1.NoNIP, t1.Nama, t1.[Tgl Lahir], t1.DomisiliAlamat, t1.kartu, t1.mesin, t1.JenisTransaksi  "

                queryBuilder.AppendLine("SELECT t1.TransGigiID AS 'Translabid', '-' AS 'DetailPemeriksaan', t1.NoJenisBayar, t1.[No Lab], CONVERT(date, t1.[Tanggal Lab]) AS 'Tanggal Lab', t1.NoNIP, t1.Nama, t1.[Tgl Lahir], t1.DomisiliAlamat, '-' AS 'DetailPemeriksaan', SUM(t1.Tagihan) AS 'Tagihan', t1.kartu, t1.mesin, t1.JenisTransaksi, t1.JenisKasir")
                queryBuilder.AppendLine("FROM (")
                queryBuilder.AppendLine("    SELECT c.TransGigiIDBayar AS 'No', a.TransGigiID, c.NoJenisBayar, a.NoUrut AS 'No Lab', CONVERT(date, a.TglGigi) AS 'Tanggal Lab', b.NoNIP AS 'NoNIP', b.Nama, b.TglLahir AS 'Tgl Lahir', b.DomisiliAlamat, '-' AS 'DetailPemeriksaan', c.JumlahBayar - c.Kembali AS 'Tagihan', c.kartu, c.mesin, 'GIGI' AS 'JenisTransaksi', '0' AS JenisKasir")
                queryBuilder.AppendLine("    FROM TransaksiGigi a")
                queryBuilder.AppendLine("         LEFT JOIN MasterPasien b ON a.idinternet = b.NoRekamMedis")
                queryBuilder.AppendLine("         LEFT JOIN TransaksiGigiBayar c ON a.TransGigiID = c.TransGigiID")
                queryBuilder.AppendLine("    WHERE a.Nourut IN " & TstrGigi & " AND a.deleted <> 1 " & Tcompany & Tjenistransaksi & "")
                queryBuilder.AppendLine("    UNION")
                queryBuilder.AppendLine("    SELECT c.TransGigiIDBayar AS 'No', a.TransGigiID, c.NoJenisBayar, a.NoUrut AS 'No Lab', CONVERT(date, a.TglGigi) AS 'Tanggal Lab', b.NoNIP AS 'NoNIP', b.Nama, b.TglLahir AS 'Tgl Lahir', b.DomisiliAlamat, '-' AS 'DetailPemeriksaan', c.JumlahBayar - c.Kembali AS 'Tagihan', c.kartu, c.mesin, 'GIGI' AS 'JenisTransaksi', '1' AS JenisKasir")
                queryBuilder.AppendLine("    FROM TransaksiGigi a")
                queryBuilder.AppendLine("         LEFT JOIN MasterPasien b ON a.idinternet = b.NoRekamMedis")
                queryBuilder.AppendLine("         LEFT JOIN TransaksiGigiBayarAwal c ON a.TransGigiID = c.TransGigiID")
                queryBuilder.AppendLine("    WHERE a.Nourut IN " & TstrGigi & " AND a.deleted <> 1 " & Tcompany & Tjenistransaksi & "")
                queryBuilder.AppendLine(") AS t1")
                queryBuilder.AppendLine("WHERE CONVERT(date, t1.[Tanggal Lab]) BETWEEN '" & Format(dtprocess.Value, "MM-dd-yyyy") & "' and '" & Format(dtprocessend.Value, "MM-dd-yyyy") & "'")
                queryBuilder.AppendLine("GROUP BY t1.TransGigiID, t1.NoJenisBayar, t1.[No Lab], CONVERT(date, t1.[Tanggal Lab]), t1.NoNIP, t1.Nama, t1.[Tgl Lahir], t1.DomisiliAlamat, t1.kartu, t1.mesin, t1.JenisTransaksi, t1.JenisKasir")
            ElseIf ComboBoxJenisTransaksi.SelectedIndex = 2 Then
                ' Dinonaktifkan
                'Tquery = "SELECT ROW_NUMBER() OVER (ORDER BY a.TransAdminID)  AS 'No', a.TransAdminID as 'Translabid', '-' as 'DetailPemeriksaan', c.NoJenisBayar, a.TransAdminID as 'No Lab', CONVERT(date, a.TindakanTgl) as 'Tanggal Lab', b.NoNIP as 'NoNIP',b.Nama,b.TglLahir as 'Tgl Lahir',b.DomisiliAlamat, c.JumlahBayar-c.Kembali as 'Tagihan', c.mesin, c.kartu, 'ADMIN' as 'JenisTransaksi' " & _
                '         "FROM TransaksiAdmin a " & _
                '         "LEFT JOIN MasterPasien b on a.idinternet=b.NoRekamMedis " & _
                '         "LEFT JOIN TransaksiAdminBayar c on a.TransAdminID=c.TransAdminID " & _
                '         "WHERE a.TransAdminID in " & TstrAdmin & " and a.deleted <> 1 and (CONVERT(date, a.TindakanTgl) BETWEEN '" & Format(dtprocess.Value, "MM-dd-yyyy") & "' and '" & Format(dtprocessend.Value, "MM-dd-yyyy") & "') " & Tcompany & Tjenistransaksi
            ElseIf ComboBoxJenisTransaksi.SelectedIndex = 3 Then
                'Tquery = "SELECT t1.* FROM (SELECT t1.TransPoliID as 'Translabid', '-' as 'DetailPemeriksaan', t1.NoJenisBayar, t1.[No Lab], CONVERT(date, t1.[Tanggal Lab]) as 'Tanggal Lab', t1.NoNIP, t1.Nama, t1.[Tgl Lahir], t1.DomisiliAlamat, SUM(t1.Tagihan) as 'Tagihan', t1.kartu, t1.mesin, t1.JenisTransaksi FROM  (SELECT c.TransPoliIDBayar AS 'No', a.TransPoliID, c.NoJenisBayar, a.NoUrut as 'No Lab', CONVERT(date, a.TglPoli) as 'Tanggal Lab', b.NoNIP as 'NoNIP',b.Nama,b.TglLahir as 'Tgl Lahir',b.DomisiliAlamat, '-' as 'DetailPemeriksaan', c.JumlahBayar-c.Kembali as 'Tagihan', c.kartu, c.mesin, 'POLI' as 'JenisTransaksi' FROM TransaksiPoli a LEFT JOIN MasterPasien b on a.idinternet=b.NoRekamMedis LEFT JOIN TransaksiPoliBayar c on a.TransPoliID=c.TransPoliID WHERE a.Nourut in " & TstrPoli & " and a.deleted <> 1 " & Tcompany & Tjenistransaksi & " UNION  SELECT c.TransPoliIDBayar AS 'No', a.TransPoliID, c.NoJenisBayar, a.NoUrut as 'No Lab', CONVERT(date, a.TglPoli) as 'Tanggal Lab', b.NoNIP as 'NoNIP',b.Nama,b.TglLahir as 'Tgl Lahir',b.DomisiliAlamat, '-' as 'DetailPemeriksaan', c.JumlahBayar-c.Kembali as 'Tagihan', c.kartu, c.mesin, 'POLI' as 'JenisTransaksi' FROM TransaksiPoli a LEFT JOIN MasterPasien b on a.idinternet=b.NoRekamMedis LEFT JOIN TransaksiPoliBayarAwal c on a.TransPoliID=c.TransPoliID WHERE a.Nourut in " & TstrPoli & " and a.deleted <> 1 " & Tcompany & Tjenistransaksi & ") as t1 GROUP BY t1.TransPoliID, t1.NoJenisBayar, t1.[No Lab], CONVERT(DATE, t1.[Tanggal Lab]), t1.NoNIP, t1.Nama, t1.[Tgl Lahir], t1.DomisiliAlamat, t1.kartu, t1.mesin, t1.JenisTransaksi" & _
                '         " union SELECT a.TransGigiID as 'Translabid', '-' as 'DetailPemeriksaan', c.NoJenisBayar, a.NoUrut as 'No Lab', CONVERT(date, a.TglGigi) as 'Tanggal Lab', b.NoNIP as 'NoNIP',b.Nama,b.TglLahir as 'Tgl Lahir',b.DomisiliAlamat, c.JumlahBayar-c.Kembali as 'Tagihan', c.mesin, c.kartu, 'GIGI' as 'JenisTransaksi' FROM TransaksiGigi a LEFT JOIN MasterPasien b on a.idinternet=b.NoRekamMedis LEFT JOIN TransaksiGigiBayar c on a.TransGigiID=c.TransGigiID WHERE a.Nourut in " & TstrGigi & " and a.deleted <> 1 " & Tcompany & Tjenistransaksi & "" & _
                '         " union SELECT a.TransAdminID as 'Translabid', '-' as 'DetailPemeriksaan', c.NoJenisBayar, CAST(a.TransAdminID as CHAR(10)) as 'No Lab', CONVERT(date, a.TindakanTgl) as 'Tanggal Lab', b.NoNIP as 'NoNIP',b.Nama,b.TglLahir as 'Tgl Lahir',b.DomisiliAlamat, c.JumlahBayar-c.Kembali as 'Tagihan', c.mesin, c.kartu, 'ADMIN' as 'JenisTransaksi' FROM TransaksiAdmin a LEFT JOIN MasterPasien b on a.idinternet=b.NoRekamMedis LEFT JOIN TransaksiAdminBayar c on a.TransAdminID=c.TransAdminID WHERE a.TransAdminID in " & TstrAdmin & " and a.deleted <> 1 " & Tcompany & Tjenistransaksi & ") as t1" & _
                '         " WHERE CONVERT(date, t1.[Tanggal Lab]) BETWEEN '" & Format(dtprocess.Value, "MM-dd-yyyy") & "' and '" & Format(dtprocessend.Value, "MM-dd-yyyy") & "'"

                queryBuilder.AppendLine("SELECT t1.*")
                queryBuilder.AppendLine("FROM (")
                queryBuilder.AppendLine("    SELECT t1.TransPoliID AS 'Translabid', '-' AS 'DetailPemeriksaan', t1.NoJenisBayar, t1.[No Lab], CONVERT(date, t1.[Tanggal Lab]) AS 'Tanggal Lab', t1.NoNIP, t1.Nama, t1.[Tgl Lahir], t1.DomisiliAlamat, SUM(t1.Tagihan) AS 'Tagihan', t1.kartu, t1.mesin, t1.JenisTransaksi, t1.JenisKasir")
                queryBuilder.AppendLine("    FROM (")
                queryBuilder.AppendLine("        SELECT c.TransPoliIDBayar AS 'No', a.TransPoliID, c.NoJenisBayar, a.NoUrut AS 'No Lab', CONVERT(date, a.TglPoli) AS 'Tanggal Lab', b.NoNIP AS 'NoNIP', b.Nama, b.TglLahir AS 'Tgl Lahir', b.DomisiliAlamat, '-' AS 'DetailPemeriksaan', c.JumlahBayar - c.Kembali AS 'Tagihan', c.kartu, c.mesin, 'POLI' AS 'JenisTransaksi', '0' AS JenisKasir")
                queryBuilder.AppendLine("        FROM TransaksiPoli a")
                queryBuilder.AppendLine("             LEFT JOIN MasterPasien b ON a.idinternet = b.NoRekamMedis")
                queryBuilder.AppendLine("             LEFT JOIN TransaksiPoliBayar c ON a.TransPoliID = c.TransPoliID")
                queryBuilder.AppendLine("        WHERE a.Nourut IN " & TstrPoli & " AND a.deleted <> 1 " & Tcompany & Tjenistransaksi & "")
                queryBuilder.AppendLine("        UNION")
                queryBuilder.AppendLine("        SELECT c.TransPoliIDBayar AS 'No', a.TransPoliID, c.NoJenisBayar, a.NoUrut AS 'No Lab', CONVERT(date, a.TglPoli) AS 'Tanggal Lab', b.NoNIP AS 'NoNIP', b.Nama, b.TglLahir AS 'Tgl Lahir', b.DomisiliAlamat, '-' AS 'DetailPemeriksaan', c.JumlahBayar - c.Kembali AS 'Tagihan', c.kartu, c.mesin, 'POLI' AS 'JenisTransaksi', '1' AS JenisKasir")
                queryBuilder.AppendLine("        FROM TransaksiPoli a")
                queryBuilder.AppendLine("             LEFT JOIN MasterPasien b ON a.idinternet = b.NoRekamMedis")
                queryBuilder.AppendLine("             LEFT JOIN TransaksiPoliBayarAwal c ON a.TransPoliID = c.TransPoliID")
                queryBuilder.AppendLine("        WHERE a.Nourut IN " & TstrPoli & " AND a.deleted <> 1 " & Tcompany & Tjenistransaksi & "")
                queryBuilder.AppendLine("    ) AS t1")
                queryBuilder.AppendLine("    GROUP BY t1.TransPoliID, t1.NoJenisBayar, t1.[No Lab], CONVERT(date, t1.[Tanggal Lab]), t1.NoNIP, t1.Nama, t1.[Tgl Lahir], t1.DomisiliAlamat, t1.kartu, t1.mesin, t1.JenisTransaksi, t1.JenisKasir")
                queryBuilder.AppendLine("    UNION")
                queryBuilder.AppendLine("    SELECT t1.TransGigiID AS 'Translabid', '-' AS 'DetailPemeriksaan', t1.NoJenisBayar, t1.[No Lab], CONVERT(date, t1.[Tanggal Lab]) AS 'Tanggal Lab', t1.NoNIP, t1.Nama, t1.[Tgl Lahir], t1.DomisiliAlamat, SUM(t1.Tagihan) AS 'Tagihan', t1.kartu, t1.mesin, t1.JenisTransaksi, t1.JenisKasir")
                queryBuilder.AppendLine("    FROM (")
                queryBuilder.AppendLine("        SELECT c.TransGigiIDBayar AS 'No', a.TransGigiID, c.NoJenisBayar, a.NoUrut AS 'No Lab', CONVERT(date, a.TglGigi) AS 'Tanggal Lab', b.NoNIP AS 'NoNIP', b.Nama, b.TglLahir AS 'Tgl Lahir', b.DomisiliAlamat, '-' AS 'DetailPemeriksaan', c.JumlahBayar - c.Kembali AS 'Tagihan', c.kartu, c.mesin, 'GIGI' AS 'JenisTransaksi', '0' AS JenisKasir")
                queryBuilder.AppendLine("        FROM TransaksiGigi a")
                queryBuilder.AppendLine("             LEFT JOIN MasterPasien b ON a.idinternet = b.NoRekamMedis")
                queryBuilder.AppendLine("             LEFT JOIN TransaksiGigiBayar c ON a.TransGigiID = c.TransGigiID")
                queryBuilder.AppendLine("        WHERE a.Nourut IN " & TstrGigi & " AND a.deleted <> 1 " & Tcompany & Tjenistransaksi & "")
                queryBuilder.AppendLine("        UNION")
                queryBuilder.AppendLine("        SELECT c.TransGigiIDBayar AS 'No', a.TransGigiID, c.NoJenisBayar, a.NoUrut AS 'No Lab', CONVERT(date, a.TglGigi) AS 'Tanggal Lab', b.NoNIP AS 'NoNIP', b.Nama, b.TglLahir AS 'Tgl Lahir', b.DomisiliAlamat, '-' AS 'DetailPemeriksaan', c.JumlahBayar - c.Kembali AS 'Tagihan', c.kartu, c.mesin, 'GIGI' AS 'JenisTransaksi', '1' AS JenisKasir")
                queryBuilder.AppendLine("        FROM TransaksiGigi a")
                queryBuilder.AppendLine("             LEFT JOIN MasterPasien b ON a.idinternet = b.NoRekamMedis")
                queryBuilder.AppendLine("             LEFT JOIN TransaksiGigiBayarAwal c ON a.TransGigiID = c.TransGigiID")
                queryBuilder.AppendLine("        WHERE a.Nourut IN " & TstrGigi & " AND a.deleted <> 1 " & Tcompany & Tjenistransaksi & "")
                queryBuilder.AppendLine("    ) AS t1")
                queryBuilder.AppendLine("    GROUP BY t1.TransGigiID, t1.NoJenisBayar, t1.[No Lab], CONVERT(date, t1.[Tanggal Lab]), t1.NoNIP, t1.Nama, t1.[Tgl Lahir], t1.DomisiliAlamat, t1.kartu, t1.mesin, t1.JenisTransaksi, t1.JenisKasir")
                queryBuilder.AppendLine("    UNION")
                queryBuilder.AppendLine("    SELECT a.TransAdminID AS 'Translabid', '-' AS 'DetailPemeriksaan', c.NoJenisBayar, CAST(a.TransAdminID AS char(10)) AS 'No Lab', CONVERT(date, a.TindakanTgl) AS 'Tanggal Lab', b.NoNIP AS 'NoNIP', b.Nama, b.TglLahir AS 'Tgl Lahir', b.DomisiliAlamat, c.JumlahBayar - c.Kembali AS 'Tagihan', c.mesin, c.kartu, 'ADMIN' AS 'JenisTransaksi', '1' AS JenisKasir")
                queryBuilder.AppendLine("    FROM TransaksiAdmin a")
                queryBuilder.AppendLine("         LEFT JOIN MasterPasien b ON a.idinternet = b.NoRekamMedis")
                queryBuilder.AppendLine("         LEFT JOIN TransaksiAdminBayar c ON a.TransAdminID = c.TransAdminID")
                queryBuilder.AppendLine("    WHERE a.TransAdminID IN " & TstrAdmin & " AND a.deleted <> 1 " & Tcompany & Tjenistransaksi & "")
                queryBuilder.AppendLine(") AS t1")
                queryBuilder.AppendLine("WHERE CONVERT(date, t1.[Tanggal Lab]) BETWEEN '" & Format(dtprocess.Value, "MM-dd-yyyy") & "' and '" & Format(dtprocessend.Value, "MM-dd-yyyy") & "'")
            End If

            Tquery = queryBuilder.ToString()

            'ORDER BY
            If ComboBoxPembayaran.Text.Trim <> "TAGIHAN" Then
                If ComboBoxJenisTransaksi.SelectedIndex = 0 Then
                    Torderby = " ORDER BY t1.mesin, t1.[Tanggal Lab], t1.[No Lab] asc"
                ElseIf ComboBoxJenisTransaksi.SelectedIndex = 1 Then
                    Torderby = " ORDER BY t1.mesin, t1.[Tanggal Lab], t1.[No Lab] asc"
                ElseIf ComboBoxJenisTransaksi.SelectedIndex = 2 Then
                    Torderby = " ORDER BY c.mesin, a.TindakanTgl, a.TransAdminID asc"
                ElseIf ComboBoxJenisTransaksi.SelectedIndex = 3 Then
                    Torderby = " ORDER BY t1.JenisTransaksi, t1.mesin, CONVERT(date, t1.[Tanggal Lab]), t1.[No Lab] ASC"
                End If
            Else
                If ComboBoxJenisTransaksi.SelectedIndex = 0 Then
                    Torderby = " ORDER BY t1.NoJenisBayar, CONVERT(date, t1.[Tanggal Lab]), t1.[No Lab] ASC"
                ElseIf ComboBoxJenisTransaksi.SelectedIndex = 1 Then
                    Torderby = " ORDER BY t1.NoJenisBayar, CONVERT(date, t1.[Tanggal Lab]), t1.[No Lab] ASC"
                ElseIf ComboBoxJenisTransaksi.SelectedIndex = 2 Then
                    Torderby = " ORDER BY c.NoJenisBayar, a.TindakanTgl, a.TransAdminID asc"
                ElseIf ComboBoxJenisTransaksi.SelectedIndex = 3 Then
                    Torderby = " ORDER BY t1.JenisTransaksi, t1.NoJenisBayar, CONVERT(date, t1.[Tanggal Lab]), t1.[No Lab] ASC"
                End If
            End If

            Dim Tbls As DataTable = New DataTable
            Dim Tdata As DataTable = New DataTable
            Dim TDetailPemeriksaan As DataTable = New DataTable
            Dim DetailPemeriksaan As String = ""
            Dim TtempDetailPemeriksaan As String = ""

            Tbls = ReadSQL(Tquery & Torderby)
            Tdata = CreateTable()
            Tdata.Rows.Clear()

            Dim temppt As String = ""
            Dim temppt2 As String = ""
            Dim number As Integer = 0
            Dim NoKartu As String = ""
            Dim tempjenistrans As String = ""
            Dim tempjenistrans2 As String = ""

            If Tbls.Rows.Count > 0 Then
                For Each TrowData As DataRow In Tbls.Rows
                    Dim Tnew As DataRow = Tdata.NewRow

                    'Periode Tanggal
                    If TgllabStart = "12/31/9998" And TgllabEnd = "12/31/9998" Then
                        TgllabStart = Format(TrowData("Tanggal Lab"), "MM-dd-yyyy")
                        TgllabEnd = Format(TrowData("Tanggal Lab"), "MM-dd-yyyy")
                    Else
                        If Format(TrowData("Tanggal Lab"), "MM-dd-yyyy") < TgllabStart Then
                            TgllabStart = Format(TrowData("Tanggal Lab"), "MM-dd-yyyy")
                        ElseIf Format(TrowData("Tanggal Lab"), "MM-dd-yyyy") > TgllabEnd Then
                            TgllabEnd = Format(TrowData("Tanggal Lab"), "MM-dd-yyyy")
                        End If
                    End If

                    'Create Number Start
                    If ComboBoxPembayaran.Text.Trim <> "TAGIHAN" Then
                        temppt2 = TrowData("mesin")
                        NoKartu = TrowData("NoJenisBayar")
                    Else
                        temppt2 = TrowData("NoJenisBayar")
                    End If

                    tempjenistrans2 = TrowData("JenisTransaksi")
                    If tempjenistrans <> tempjenistrans2 And tempjenistrans <> "" Then
                        number = 0
                        temppt = ""
                    End If

                    If ComboBoxPembayaran.Text.Trim = "TUNAI" Then
                        temppt2 = "-"
                    Else
                        If temppt2.Contains("-") = True Then
                            Dim Tsplit() As String = temppt2.Split("-")
                            temppt2 = Tsplit(0).ToString.Trim.ToUpper
                        Else
                            temppt2 = temppt2.ToUpper
                        End If
                    End If

                    If temppt = "" Then
                        number = number + 1
                    ElseIf temppt = temppt2 Then
                        number = number + 1
                    Else
                        number = 0
                        number = number + 1
                    End If

                    tempjenistrans = TrowData("JenisTransaksi")
                    If ComboBoxPembayaran.Text.Trim <> "TAGIHAN" Then
                        temppt = TrowData("mesin")
                    Else
                        temppt = TrowData("NoJenisBayar")
                    End If

                    If ComboBoxPembayaran.Text.Trim = "TUNAI" Then
                        Tnew("NoJenisBayar") = "-"
                        temppt = "-"
                    Else
                        If temppt.Contains("-") = True Then
                            Dim Tsplit() As String = temppt.Split("-")
                            Tnew("NoJenisBayar") = Tsplit(0).ToString.Trim.ToUpper
                            temppt = Tsplit(0).ToString.Trim.ToUpper
                        Else
                            Tnew("NoJenisBayar") = temppt.ToUpper
                            temppt = temppt.ToUpper
                        End If
                    End If
                    'Create Number End

                    Tnew("No Lab") = TrowData("No Lab")
                    Tnew("No") = number
                    Tnew("Tanggal Lab") = TrowData("Tanggal Lab")
                    Tnew("NIP") = TrowData("NoNIP")
                    Tnew("Nama") = TrowData("Nama").ToString.ToUpper
                    Tnew("Tgl Lahir") = TrowData("Tgl Lahir")
                    Tnew("JenisTransaksi") = TrowData("JenisTransaksi")
                    Tnew("Alamat") = TrowData("DomisiliAlamat")
                    If IsDBNull(TrowData("mesin")) = False And TrowData("mesin").ToString.Trim <> "-" Then Tnew("mesin") = TrowData("mesin") Else Tnew("mesin") = "-"
                    If IsDBNull(TrowData("kartu")) = False And TrowData("kartu").ToString.Trim <> "-" And TrowData("kartu").ToString.Trim <> "" Then Tnew("kartu") = NoKartu & " (" & TrowData("kartu") & ")" Else Tnew("kartu") = "-"

                    If IsDBNull(TrowData("DetailPemeriksaan")) = True Or TrowData("DetailPemeriksaan").ToString.Trim = "-" Then
                        DetailPemeriksaan = SetTindakanDetail(TrowData("TransLabID"), "" & tempjenistrans & "", TrowData("JenisKasir"))
                    ElseIf IsDBNull(TrowData("DetailPemeriksaan")) = False Then
                        DetailPemeriksaan = TrowData("DetailPemeriksaan")
                    End If

                    'Sentence
                    Tnew("pemeriksaan") = DetailPemeriksaan.ToUpper()
                    Tnew("Tagihan") = TrowData("Tagihan")
                    Tnew("Translabid") = TrowData("Translabid")

                    Tdata.Rows.Add(Tnew)
                Next

                If TgllabStart = TgllabEnd Then
                    tanggalTransaksiReport = Format(TgllabStart, "dd") & " " & BulanIndonesia(Format(TgllabStart, "MM")) & " " & Format(TgllabStart, "yyyy")
                Else
                    tanggalTransaksiReport = Format(TgllabStart, "dd") & " " & BulanIndonesia(Format(TgllabStart, "MM")) & " " & Format(TgllabStart, "yyyy") & " s/d " & Format(TgllabEnd, "dd") & " " & BulanIndonesia(Format(TgllabEnd, "MM")) & " " & Format(TgllabEnd, "yyyy")
                End If

                gridpasien.DataSource = Tdata
                GridView1.Columns("No").Visible = False
                GridView1.Columns("Translabid").Visible = False
                butfindcompany.Enabled = False
                ComboBoxPembayaran.Enabled = False
                ComboBoxJenisTransaksi.Enabled = False
                CheckBoxSemuaTransaksi.Enabled = False
            End If
        End If
    End Sub

    Private Sub SetClear()
        gridpasien.DataSource = CreateTable()

        TextBoxKeteranganPerusahaan.ResetText()
        txkodecabang.ResetText()
        rdyes.Checked = True
        ComboBoxPembayaran.SelectedIndex = 0
        ComboBoxJenisCetak.SelectedIndex = 0
        ComboBoxJenisTransaksi.SelectedIndex = 3
        dtprocess.Value = DateTime.Now
        dtprocessend.Value = DateTime.Now
        butfindcompany.Enabled = True
        ComboBoxPembayaran.Enabled = True
        ComboBoxJenisTransaksi.Enabled = True
        ComboBoxJenisCetak.Enabled = True
        CheckBoxSemuaTransaksi.Checked = False
        CheckBoxSemuaTransaksi.Enabled = True
    End Sub

    Private Sub CloseToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem1.Click
        Me.Close()
    End Sub

    Private Sub RekapPendapatanPoli_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        SetFormHeightWeight(Me, 0.95, 0.8)
        NewToolStripMenuItem1.PerformClick()

        Control.CheckForIllegalCrossThreadCalls = False

        ' Inisialisasi koneksi ke database MySQL
        SetConnectionFromConfig()
    End Sub

    Private Sub NewToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem1.Click
        SetClear()
    End Sub

    Private Sub PilihCompanyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Find.Show()
        Find.Query("SELECT IDCompany, CompanyCode, CompanyNama, NoCompany FROM mastercompany a", " ORDER BY a.idcompany desc", "FindCabangSummary", 2)
    End Sub

    Public Sub LoadCompany(ByRef txkode As String, ByRef txlocationket As String)
        'txcompany.Text = txlocationket
        txkodecabang.Text = txkode
    End Sub

    Private Sub butfindcompany_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butfindcompany.Click
        Find.Show()
        Find.Query("SELECT IDCompany, CompanyCode, CompanyNama, NoCompany FROM mastercompany a WHERE getdate() BETWEEN StartDate and EndDate", " ORDER BY a.idcompany desc", "FindCabangRekapPendapatanPoli", 2)
    End Sub

    Private Sub butfindpaket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Find.Show()
        Find.Query("SELECT PaketID as ID,PaketNama,PaketKeterangan,PARSENAME(CONVERT(varchar,convert(money,PaketNilaiTotal),1),2) as PaketNilaiTotal,PaketStart,PaketEnd FROM MasterLabPaket WHERE GETDATE() BETWEEN PaketStart and PaketEnd ", " ORDER BY PaketID DESC ", "FindPaketIDRekapPendapatanPoli", 2)
    End Sub

    Private Sub buttambahpasien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttambahpasien.Click
        If dtprocessend.Value < dtprocess.Value Then
            MsgBox("Tanggal Akhir tidak boleh melebihi tanggal mulai.")
            Exit Sub
        End If

        Dim Tquery As String = ""
        Dim Tcompany As String = ""
        Dim Tjenistransaksi As String = ""
        Dim ConcatCompany As String = ""
        Dim Talltransaksi As String = ""

        'Company
        If txkodecabang.Text <> "" And ComboBoxPembayaran.SelectedIndex = 0 Then
            ConcatCompany = TextBoxKeteranganPerusahaan.Text + "-" + txkodecabang.Text
            Tcompany = " and (NoJenisBayar = '" & TextBoxKeteranganPerusahaan.Text & "' or NoJenisBayar='" & ConcatCompany & "')"
        End If

        'Jenis Transaksi
        If ComboBoxPembayaran.SelectedIndex = 0 Then
            Tjenistransaksi = " JenisBayar='TAGIHAN'"
        ElseIf ComboBoxPembayaran.SelectedIndex = 1 Then
            Tjenistransaksi = " JenisBayar='DEBET'"
        ElseIf ComboBoxPembayaran.SelectedIndex = 2 Then
            Tjenistransaksi = " JenisBayar='TUNAI'"
        ElseIf ComboBoxPembayaran.SelectedIndex = 3 Then
            Tjenistransaksi = " JenisBayar='CARD'"
        End If

        'Tampilan Transaksi
        If CheckBoxSemuaTransaksi.Checked = True Then
            Talltransaksi = ""
        ElseIf CheckBoxSemuaTransaksi.Checked = False Then
            If ComboBoxPembayaran.SelectedIndex = 0 Then
                Talltransaksi = " AND a.RekapID is null"
            End If
        End If

        Dim queryBuilder As New StringBuilder()

        'Query Utama
        If ComboBoxJenisTransaksi.SelectedIndex = 0 Then
            'Tquery = "SELECT a.NoUrut as 'No Lab',CONVERT(date, a.TglPoli) as 'Tanggal Lab', b.NoNIP as 'NoNIP' , b.Nama,b.TglLahir as 'Tgl Lahir',b.DomisiliAlamat, 'POLI' as 'JenisTransaksi' " & _
            '         "FROM TransaksiPoli a " & _
            '         "LEFT JOIN MasterPasien b on a.idinternet = b.NoRekamMedis " & _
            '         "WHERE a.deleted <> 1 " & Talltransaksi & " and (CONVERT(date, a.TglPoli) BETWEEN '" & Format(dtprocess.Value, "MM-dd-yyyy") & "' and '" & Format(dtprocessend.Value, "MM-dd-yyyy") & "') and (a.TransPoliID in (SELECT TransPoliID FROM TransaksiPoliBayar WHERE " & Tjenistransaksi & Tcompany & ") or a.TransPoliID in (SELECT TransPoliID FROM TransaksiPoliBayarAwal WHERE " & Tjenistransaksi & Tcompany & ")) " & _
            '         "ORDER BY TglPoli, nourut ASC"

            queryBuilder.AppendLine("SELECT a.NoUrut AS 'No Lab', CONVERT(date, a.TglPoli) AS 'Tanggal Lab', b.NoNIP AS 'NoNIP', b.Nama, b.TglLahir AS 'Tgl Lahir', b.DomisiliAlamat, 'POLI' AS 'JenisTransaksi'")
            queryBuilder.AppendLine("FROM TransaksiPoli a")
            queryBuilder.AppendLine("     LEFT JOIN MasterPasien b ON a.idinternet = b.NoRekamMedis")
            queryBuilder.AppendLine("WHERE a.deleted <> 1 " & Talltransaksi & " AND (CONVERT(date, a.TglPoli) BETWEEN '" & Format(dtprocess.Value, "MM-dd-yyyy") & "' and '" & Format(dtprocessend.Value, "MM-dd-yyyy") & "') AND (a.TransPoliID IN (SELECT TransPoliID FROM TransaksiPoliBayar WHERE " & Tjenistransaksi & Tcompany & ") OR a.TransPoliID IN (SELECT TransPoliID FROM TransaksiPoliBayarAwal WHERE " & Tjenistransaksi & Tcompany & "))")
            queryBuilder.AppendLine("ORDER BY TglPoli, nourut ASC")
        ElseIf ComboBoxJenisTransaksi.SelectedIndex = 1 Then
            'Tquery = "SELECT a.NoUrut as 'No Lab',CONVERT(date, a.TglGigi) as 'Tanggal Lab', b.NoNIP as 'NoNIP', b.Nama, b.TglLahir as 'Tgl Lahir', b.DomisiliAlamat, 'GIGI' as 'JenisTransaksi' " & _
            '         "FROM TransaksiGigi a " & _
            '         "LEFT JOIN MasterPasien b on a.idinternet = b.NoRekamMedis " & _
            '         "WHERE a.deleted <> 1 " & Talltransaksi & " and (CONVERT(date, a.TglGigi) BETWEEN '" & Format(dtprocess.Value, "MM-dd-yyyy") & "' and '" & Format(dtprocessend.Value, "MM-dd-yyyy") & "') and (a.TransGigiID in (SELECT TransGigiID FROM TransaksiGigiBayar WHERE " & Tjenistransaksi & Tcompany & ") or a.TransGigiID in (SELECT TransGigiID FROM TransaksiGigiBayarAwal WHERE " & Tjenistransaksi & Tcompany & ")) " & _
            '         "ORDER BY TglGigi, nourut ASC"

            queryBuilder.AppendLine("SELECT a.NoUrut AS 'No Lab', CONVERT(date, a.TglGigi) AS 'Tanggal Lab', b.NoNIP AS 'NoNIP', b.Nama, b.TglLahir AS 'Tgl Lahir', b.DomisiliAlamat, 'GIGI' AS 'JenisTransaksi'")
            queryBuilder.AppendLine("FROM TransaksiGigi a")
            queryBuilder.AppendLine("     LEFT JOIN MasterPasien b ON a.idinternet = b.NoRekamMedis")
            queryBuilder.AppendLine("WHERE a.deleted <> 1 " & Talltransaksi & " AND (CONVERT(date, a.TglGigi) BETWEEN '" & Format(dtprocess.Value, "MM-dd-yyyy") & "' and '" & Format(dtprocessend.Value, "MM-dd-yyyy") & "') AND (a.TransGigiID IN (SELECT TransGigiID FROM TransaksiGigiBayar WHERE " & Tjenistransaksi & Tcompany & ") OR a.TransGigiID IN (SELECT TransGigiID FROM TransaksiGigiBayarAwal WHERE " & Tjenistransaksi & Tcompany & "))")
            queryBuilder.AppendLine("ORDER BY TglGigi, nourut ASC")
        ElseIf ComboBoxJenisTransaksi.SelectedIndex = 2 Then
            ' Nonaktifkan

            Tquery = "SELECT a.TransAdminID as 'No Lab',CONVERT(date, a.TindakanTgl) as 'Tanggal Lab', b.NoNIP as 'NoNIP' , b.Nama,b.TglLahir as 'Tgl Lahir',b.DomisiliAlamat, 'ADMIN' as 'JenisTransaksi' FROM TransaksiAdmin a LEFT JOIN MasterPasien b on a.idinternet=b.NoRekamMedis WHERE a.deleted <> 1 " & Talltransaksi & " and (CONVERT(date, a.TindakanTgl) BETWEEN '" & Format(dtprocess.Value, "MM-dd-yyyy") & "' and '" & Format(dtprocessend.Value, "MM-dd-yyyy") & "') and a.TransAdminID in (SELECT TransAdminID FROM TransaksiAdminBayar WHERE " & Tjenistransaksi & Tcompany & ") ORDER BY TindakanTgl, TransAdminID ASC"
        ElseIf ComboBoxJenisTransaksi.SelectedIndex = 3 Then
            queryBuilder.AppendLine("SELECT t1.[No Lab], t1.JenisTransaksi, CONVERT(date, t1.[Tanggal Lab]), t1.NoNIP, t1.Nama, t1.[Tgl Lahir], t1.DomisiliAlamat")
            queryBuilder.AppendLine("FROM (")
            queryBuilder.AppendLine("    SELECT a.NoUrut AS 'No Lab', CONVERT(date, a.TglPoli) AS 'Tanggal Lab', b.NoNIP AS 'NoNIP', b.Nama, b.TglLahir AS 'Tgl Lahir', b.DomisiliAlamat, 'POLI' AS 'JenisTransaksi'")
            queryBuilder.AppendLine("    FROM TransaksiPoli a")
            queryBuilder.AppendLine("         LEFT JOIN MasterPasien b ON a.idinternet = b.NoRekamMedis")
            queryBuilder.AppendLine("    WHERE a.deleted <> 1 " & Talltransaksi & " AND (a.TransPoliID IN (SELECT TransPoliID FROM TransaksiPoliBayar WHERE " & Tjenistransaksi & Tcompany & ") OR a.TransPoliID IN (SELECT TransPoliID FROM TransaksiPoliBayarAwal WHERE " & Tjenistransaksi & Tcompany & "))")
            queryBuilder.AppendLine("    UNION")
            queryBuilder.AppendLine("    SELECT a.NoUrut AS 'No Lab', CONVERT(date, a.TglGigi) AS 'Tanggal Lab', b.NoNIP AS 'NoNIP', b.Nama, b.TglLahir AS 'Tgl Lahir', b.DomisiliAlamat, 'GIGI' AS 'JenisTransaksi'")
            queryBuilder.AppendLine("    FROM TransaksiGigi a")
            queryBuilder.AppendLine("         LEFT JOIN MasterPasien b ON a.idinternet = b.NoRekamMedis")
            queryBuilder.AppendLine("    WHERE a.deleted <> 1 " & Talltransaksi & " AND (a.TransGigiID IN (SELECT TransGigiID FROM TransaksiGigiBayar WHERE " & Tjenistransaksi & Tcompany & ") OR a.TransGigiID IN (SELECT TransGigiID FROM TransaksiGigiBayarAwal WHERE " & Tjenistransaksi & Tcompany & "))")
            queryBuilder.AppendLine("    UNION")
            queryBuilder.AppendLine("    SELECT CAST(a.TransAdminID AS char(10)) AS 'No Lab', CONVERT(date, a.TindakanTgl) AS 'Tanggal Lab', b.NoNIP AS 'NoNIP', b.Nama, b.TglLahir AS 'Tgl Lahir', b.DomisiliAlamat, 'ADMIN' AS 'JenisTransaksi'")
            queryBuilder.AppendLine("    FROM TransaksiAdmin a")
            queryBuilder.AppendLine("         LEFT JOIN MasterPasien b ON a.idinternet = b.NoRekamMedis")
            queryBuilder.AppendLine("    WHERE a.deleted <> 1 " & Talltransaksi & " AND a.TransAdminID IN (SELECT TransAdminID FROM TransaksiAdminBayar WHERE " & Tjenistransaksi & Tcompany & ")")
            queryBuilder.AppendLine(") AS t1")
            queryBuilder.AppendLine("WHERE CONVERT(date, t1.[Tanggal Lab]) BETWEEN '" & Format(dtprocess.Value, "MM-dd-yyyy") & "' and '" & Format(dtprocessend.Value, "MM-dd-yyyy") & "'")
        End If

        Tquery = queryBuilder.ToString()

        Dim TblsNew As DataTable = ReadSQL(Tquery)

        If TblsNew.Rows.Count > 0 Then
            FindMultiple.Show()
            FindMultiple.Query(Tquery, "", "RekapPendapatanPoli", 2)
        Else
            MsgBox("Tidak ada data yang ditampilkan.", MsgBoxStyle.Exclamation, "Warning!")
            Exit Sub
        End If
    End Sub

    Private Sub exportexcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles exportexcel.Click
        Dim Tbls As DataTable = gridpasien.DataSource
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
                    gridpasien.ExportToExcel(saveFileDialog1.FileName.ToString)
                    MsgBox("File Saved")
                End If
            End If
        Else
            MsgBox("Tidak ada data yg ditampilkan.")
        End If
    End Sub

    Private Sub clear_invoice()
        txnorek.ResetText()
        txnamarek.ResetText()
        txtgljatuhtempo.ResetText()
        txbankid.ResetText()
        txnamabank.ResetText()
    End Sub

    Private Sub exportpdf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ValidasiCetakLaporan() = True Then
            If ComboBoxJenisCetak.Text = "REKAP PENDAPATAN" Then
                LaporanRekapPendapatan()
                Exit Sub
            ElseIf ComboBoxJenisCetak.Text = "REKAP PENDAPATAN TAGIHAN (DETAIL)" Then
                LaporanRekapPendapatanTagihanDetail()
                Exit Sub
            ElseIf ComboBoxJenisCetak.Text = "TANDA TERIMA" Then
                LaporanRekapTandaTerima()
                Exit Sub
            ElseIf ComboBoxJenisCetak.Text = "INVOICE TAGIHAN" Then
                CreateInvoiceTagihan()
                Exit Sub
            End If
        End If
    End Sub

    Private Function ValidasiCetakLaporan() As Boolean
        Dim Tbls As DataTable = gridpasien.DataSource

        ' Validasi data kosong
        If Tbls.Rows.Count <= 0 Then
            MsgBox("Error: Tidak ada data yang ditampilkan.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        ' Validasi Centangan "Tampilkan Semua Transaksi"
        If CheckBoxSemuaTransaksi.Checked = True Then
            If ComboBoxJenisCetak.Text <> "REKAP PENDAPATAN" And ComboBoxJenisCetak.Text <> "REKAP PENDAPATAN TAGIHAN (DETAIL)" Then
                MsgBox("Error: Jenis cetak tidak bisa menggunakan checkbox pilihan semua transaksi.", MsgBoxStyle.Critical, "Error")
                Return False
            End If
        End If

        ' Validasi pilihan cetak rekap pendapatan tagihan (detail)
        If Tbls.Rows.Count > 0 And ComboBoxJenisCetak.Text = "REKAP PENDAPATAN TAGIHAN (DETAIL)" And ComboBoxPembayaran.Text <> "TAGIHAN" Then
            MsgBox("Error: Jenis laporan hanya untuk tagihan.", MsgBoxStyle.Critical, "Error")
            Return False
        End If

        ' Validasi pilihan cetak invoice tagihan
        If ComboBoxJenisCetak.Text = "INVOICE TAGIHAN" Then
            If TextBoxKeteranganPerusahaan.Text = "" Then
                MsgBox("Error: Pilih perusahaan terlebih dahulu.", MsgBoxStyle.Critical, "Error")
                clear_invoice()
                Return False
            ElseIf ComboBoxPembayaran.Text <> "TAGIHAN" Then
                MsgBox("Error: Invoice hanya untuk pembayaran tagihan.", MsgBoxStyle.Critical, "Error")
                clear_invoice()
                Return False
            ElseIf ComboBoxJenisTransaksi.Text = "SEMUA" Then
                MsgBox("Error: Invoice hanya untuk pembayaran tagihan.", MsgBoxStyle.Critical, "Error")
                clear_invoice()
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub SendingJurnal(ByVal NoInv As String, ByVal TotalTagihan As Integer, ByVal JenisTransaksi As String)
        Dim keterangan As String = ""
        Dim flag As String = ""
        Dim KetLokasi As String = ""
        Dim Nourut As String = ""
        Dim bsa As String = ""
        Dim Tlokasigl As New DataTable
        Dim Tloc As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='NoPoli'")
        Dim TKode As String = ReadSQLNIK("SELECT RIGHT(StrValue, 3) FROM MsConfig WHERE ConfigName='KodeInvoicePoli'")
        Dim TKodeBarcode As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='KodeBarcode'")
        Dim RekapID As String = ReadSQLNIK("SELECT RekapID FROM RekapTagihan WHERE notagihancompany = '" & NoInv & "'")
        Dim CoaPiutangPending As String = ""
        Dim CoaPiutang As String = ""

        If JenisTransaksi = "POLI" Then
            CoaPiutangPending = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPiutangPendingKlinik'", DB_Keuangan2)
            CoaPiutang = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPiutangKlinik'", DB_Keuangan2)
        ElseIf JenisTransaksi = "GIGI" Then
            CoaPiutangPending = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPiutangPendingGigi'", DB_Keuangan2)
            CoaPiutang = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPiutangGigi'", DB_Keuangan2)
        ElseIf JenisTransaksi = "DLL" Then
            CoaPiutangPending = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPiutangPendingAdmin'", DB_Keuangan2)
            CoaPiutang = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPiutangAdmin'", DB_Keuangan2)
        End If

        Tlokasigl = ReadThemysql("SELECT a.locgl, a.locket FROM masterlokasigl a WHERE a.loc='" & Tloc & "' AND a.jenistransaksi='" & JenisTransaksi & "'", DB_Keuangan)
        Dim Trowlokasigl As DataRow = Tlokasigl.Rows(0)
        bsa = Trowlokasigl("locgl")
        KetLokasi = Trowlokasigl("locket")

        Dim Tdetail() As String = NoInv.Split("/")

        flag = Tdetail(0) & Tdetail(1).Substring(Tdetail(1).Length - 3) & Tdetail(2) & Tdetail(3)

        keterangan = "TERIMA - TAGIHAN " & TextBoxKeteranganPerusahaan.Text.Trim & " " & KetLokasi & " " & Format(DateAndTime.Now, "dd/MM/yyyy") & " (NO. INVOICE : " & NoInv & ")"

        'Send To GL
        WriteThemysql("SELECT F_MakeUMH('" & flag & "', 'out', '', '" & Format(DateAndTime.Now, "yyyy-MM-dd") & "', '" & CoaPiutangPending & "', '" & CoaPiutang & "', 'IDR', 1, " & CDbl(TotalTagihan) & ", '" & keterangan.ToUpper() & "', '1', 1, '', '" & keterangan.ToUpper() & "', '', '', '" & bsa & "', 4, " & CDbl(TotalTagihan) & ", 'K')", DB_Jurnal)

        'Update TransaksiLab
        If JenisTransaksi = "POLI" Then
            WriteSQL("UPDATE TransaksiPoli SET FlagJurnalCreateTagihan = '" & flag & "' WHERE RekapID = '" & RekapID & "'", 4)
        ElseIf JenisTransaksi = "GIGI" Then
            WriteSQL("UPDATE TransaksiGigi SET FlagJurnalCreateTagihan = '" & flag & "' WHERE RekapID = '" & RekapID & "'", 4)
        ElseIf JenisTransaksi = "DLL" Then
            WriteSQL("UPDATE TransaksiAdmin SET FlagJurnalCreateTagihan = '" & flag & "' WHERE RekapID = '" & RekapID & "'", 4)
        End If

        'Update acctransrekaptagihan
        WriteThemysql("UPDATE acctransrekaptagihan SET FlagJurnalCreateTagihan = '1' WHERE RekapID = '" & RekapID & "'", DB_Keuangan)

        'Save Log
        WriteSQL("INSERT INTO LogJurnalKeuangan (JurnalFlag,JurnalDate,JurnalBy,Status,JenisTransaksi) VALUES ('" & flag & "', getdate(), '" & PoliKlinik.Lbluser.Text & "', 'JURNAL TAGIHAN (" & NoInv & ")', '" & JenisTransaksi & "')", 4)
    End Sub

    Function SetNoTagihanCompany() As String
        Dim NoTagihan As String = ""
        Dim NoRef1 As String = ""
        Dim NoRef2 As String = ""
        Dim NoRef3 As String = ""

        Dim angka2 As String = "0001"
        Dim angka As String = ReadThemysqlNIK("SELECT concat(lpad(LEFT(notagihancompany,4)+1,4,0)) FROM acctransrekaptagihan WHERE DATE(tgltagihan) BETWEEN DATE_FORMAT('" & Format(DateAndTime.Now, "yyyy-MM-dd") & "' ,'%Y-%m-01 %T') AND LAST_DAY('" & Format(DateAndTime.Now, "yyyy-MM-dd") & "') ORDER BY notagihancompany desc limit 1", DB_Keuangan)

        If angka = "" Or angka = "-" Then
            NoRef1 = angka2
        ElseIf angka <> "" Then
            NoRef1 = angka
        End If

        NoRef2 = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='KodeInvoicePoli'")
        NoRef3 = GetRomes(DateAndTime.Now.Month) & "/" & Format(DateAndTime.Now, "yyyy")
        NoTagihan = NoRef1 & "/" & NoRef2 & "/" & NoRef3

        Return NoTagihan
    End Function

    Private Sub cmbpembayaran_SELECTedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxPembayaran.SelectedIndexChanged
        If ComboBoxPembayaran.Text.Trim <> "TAGIHAN" Then
            TextBoxKeteranganPerusahaan.ResetText()
            txkodecabang.ResetText()
            butfindcompany.Enabled = False
        Else
            butfindcompany.Enabled = True
        End If
    End Sub

    Private Sub LaporanRekapPendapatan()
        Dim Tbls As DataTable = gridpasien.DataSource
        Tbls.AcceptChanges()

        Dim Tdata As DataTable = New DataTable
        Report = New XtraReport

        If rdyes.Checked Then
            If ComboBoxPembayaran.Text.Trim = "CARD" Or ComboBoxPembayaran.Text.Trim = "DEBET" Then
                Report = XtraReport.FromFile(Application.StartupPath + "\reports\Klinik\RekapPendapatanPoliPemeriksaanEDC.repx", True)
            Else
                Report = XtraReport.FromFile(Application.StartupPath + "\reports\Klinik\RekapPendapatanPoliPemeriksaan.repx", True)
            End If
        ElseIf rdno.Checked Then
            If ComboBoxPembayaran.Text.Trim = "CARD" Or ComboBoxPembayaran.Text.Trim = "DEBET" Then
                Report = XtraReport.FromFile(Application.StartupPath + "\reports\Klinik\RekapPendapatanPoliNonPemeriksaanEDC.repx", True)
            Else
                Report = XtraReport.FromFile(Application.StartupPath + "\reports\Klinik\RekapPendapatanPoliNonPemeriksaan.repx", True)
            End If
        End If

        Report.DataSource = Tbls

        If ComboBoxPembayaran.SelectedIndex = 0 Then
            Report.Bands.Item(BandKind.ReportHeader).Controls("lbljenissetoran").Text = "REKAP TAGIHAN PEMERIKSAAN POLI UMUM (" & ComboBoxJenisTransaksi.Text & ")"
        ElseIf ComboBoxPembayaran.SelectedIndex = 1 Then
            Report.Bands.Item(BandKind.ReportHeader).Controls("lbljenissetoran").Text = "REKAP DEBET PEMERIKSAAN POLI UMUM (" & ComboBoxJenisTransaksi.Text & ")"
        ElseIf ComboBoxPembayaran.SelectedIndex = 2 Then
            Report.Bands.Item(BandKind.ReportHeader).Controls("lbljenissetoran").Text = "REKAP TUNAI PEMERIKSAAN POLI UMUM (" & ComboBoxJenisTransaksi.Text & ")"
        ElseIf ComboBoxPembayaran.SelectedIndex = 3 Then
            Report.Bands.Item(BandKind.ReportHeader).Controls("lbljenissetoran").Text = "REKAP CARD PEMERIKSAAN POLI UMUM (" & ComboBoxJenisTransaksi.Text & ")"
        End If

        Report.Bands.Item(BandKind.ReportHeader).Controls("lbltanggal").Text = tanggalTransaksiReport
        Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:ss") & " By " & PoliKlinik.Lbluser.Text

        Report.RunDesigner()
        'Report.ShowPreview()
        'Report.Print()
    End Sub

    Private Sub LaporanRekapPendapatanTagihanDetail()
        Dim Tbls As DataTable = gridpasien.DataSource
        Tbls.AcceptChanges()

        ' Ubah kolom "No" menjadi tidak readonly sementara
        Tbls.Columns("No").ReadOnly = False

        Dim namaPoli As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NamaPoli'")
        Dim rowNumber As Integer = 0
        For Each Trow As DataRow In Tbls.Rows
            rowNumber = rowNumber + 1
            Trow("No") = rowNumber
        Next

        Dim Tdata As DataTable = New DataTable
        Report = New XtraReport

        'Rekap Tagihan
        If rdyes.Checked Then
            Report = XtraReport.FromFile(Application.StartupPath + "\reports\Klinik\RekapPendapatanPoliPemeriksaanDetail.repx", True)
        ElseIf rdno.Checked Then
            Report = XtraReport.FromFile(Application.StartupPath + "\reports\Klinik\RekapPendapatanPoliPemeriksaanDetail.repx", True)
        End If

        Report.DataSource = Tbls

        If ComboBoxPembayaran.SelectedIndex = 0 Then
            Report.Bands.Item(BandKind.ReportHeader).Controls("lbljenissetoran").Text = "REKAP TAGIHAN PEMERIKSAAN POLI UMUM (" & ComboBoxJenisTransaksi.Text & ")"
        ElseIf ComboBoxPembayaran.SelectedIndex = 1 Then
            Report.Bands.Item(BandKind.ReportHeader).Controls("lbljenissetoran").Text = "REKAP DEBET PEMERIKSAAN POLI UMUM (" & ComboBoxJenisTransaksi.Text & ")"
        ElseIf ComboBoxPembayaran.SelectedIndex = 2 Then
            Report.Bands.Item(BandKind.ReportHeader).Controls("lbljenissetoran").Text = "REKAP TUNAI PEMERIKSAAN POLI UMUM (" & ComboBoxJenisTransaksi.Text & ")"
        ElseIf ComboBoxPembayaran.SelectedIndex = 3 Then
            Report.Bands.Item(BandKind.ReportHeader).Controls("lbljenissetoran").Text = "REKAP CARD PEMERIKSAAN POLI UMUM (" & ComboBoxJenisTransaksi.Text & ")"
        End If

        Report.Bands.Item(BandKind.ReportHeader).Controls("xrLabelLokasi").Text = namaPoli
        Report.Bands.Item(BandKind.ReportHeader).Controls("xrLabelTanggal").Text = tanggalTransaksiReport

        Report.Bands.Item(BandKind.PageFooter).Controls("xrLabelPrinted").Text = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:ss") & " By " & PoliKlinik.Lbluser.Text

        'Report.RunDesigner()
        Report.ShowPreview()
        'Report.Print()
    End Sub

    Private Sub LaporanRekapTandaTerima()
        Dim Tbls As DataTable = gridpasien.DataSource
        Tbls.AcceptChanges()

        Dim Tdata As DataTable = New DataTable
        Report = New XtraReport

        Report = XtraReport.FromFile(Application.StartupPath + "\reports\Klinik\RekapPendapatanPoliTandaTerima.repx", True)
        Report.DataSource = Tbls

        Report.Bands.Item(BandKind.ReportHeader).Controls("lbljenissetoran").Text = "TANDA TERIMA HASIL POLI UMUM (" & ComboBoxJenisTransaksi.Text & ")"

        Report.Bands.Item(BandKind.ReportHeader).Controls("lbltanggal").Text = tanggalTransaksiReport
        Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:ss") & " By " & PoliKlinik.Lbluser.Text

        'Report.RunDesigner()
        Report.ShowPreview()
        'Report.Print()
    End Sub

    Private Sub CreateInvoiceTagihan()
        Dim NoTagihan As String = ""
        Dim Ttempat As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='Kota'")
        Dim Temail As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='InvoiceEmail'")
        Dim Tnamaklinik As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='InvoiceTempat_Klinik'")
        Dim Tbls As DataTable = gridpasien.DataSource
        Dim Tdata As DataTable = New DataTable

        Report = New XtraReport

        SelectDateTime.LoadOptionDialog("TanggalReportPendapatanPoliInvoice", "Pilih Tanggal Jatuh Tempo :")
        SelectDateTime.ShowDialog()

        If txtgljatuhtempo.Text = "" Then
            MsgBox("Pilih Tanggal Jatuh Tempo Terlebih Dahulu.")
            clear_invoice()
            Exit Sub
        End If

        SelectBank.LoadOptionDialog("SetBankReportPendapatanPoliInvoice", "Pilih Tanggal Jatuh Tempo :")
        SelectBank.ShowDialog()

        If txnamarek.Text = "" Then
            MsgBox("Pilih Bank Terlebih Dahulu.")
            clear_invoice()
            Exit Sub
        End If

        Dim tgljatuhtempo As Date = txtgljatuhtempo.Text
        NoTagihan = SetNoTagihanCompany()

        'Invoice
        Report = XtraReport.FromFile(Application.StartupPath + "\reports\Klinik\RekapPendapatanPoliInvoice.repx", True)
        Report.Bands.Item(BandKind.ReportHeader).Controls("lbltanggalsekarang").Text = Format(DateAndTime.Now, "dd") & " " & BulanIndonesia(Format(DateAndTime.Now, "MM")) & " " & Format(DateAndTime.Now, "yyyy")
        Report.Bands.Item(BandKind.ReportHeader).Controls("lbltgljatuhtempo").Text = Format(tgljatuhtempo, "dd") & " " & BulanIndonesia(Format(tgljatuhtempo, "MM")) & " " & Format(tgljatuhtempo, "yyyy")
        Report.Bands.Item(BandKind.ReportHeader).Controls("lblnoinvoice").Text = NoTagihan
        Tdata = CreateTableInvoice()
        Tdata.Rows.Clear()
        insertRowToTbls(Tdata, "Typstring", "txtglttd")
        insertRowToTbls(Tdata, "Typstring", "txangkaterbilang")
        insertRowToTbls(Tdata, "Typstring", "lblnamarekening")
        insertRowToTbls(Tdata, "Typstring", "lblnomorrekening")
        insertRowToTbls(Tdata, "Typstring", "lblnamabank")
        insertRowToTbls(Tdata, "Typstring", "namauser")
        insertRowToTbls(Tdata, "Typstring", "lblemailinvoice")

        Dim TgllabStart As Date = "12/31/9998"
        Dim number As Integer = 0 'Penomoran
        Dim jumlahpeserta As Integer = 0 'Jumlah Hadir Per Tanggal
        Dim jumlahtagihan As Integer = 0 'Jumlah Tagihan Per Tanggal
        Dim totalrow As Integer = 0 'Jumlah Tanggal yang dijadikan Tagihan
        Dim totaltagihan As Integer = 0 'Total Keseluruhan Tagihan
        Dim Pemeriksaan As String = ""
        Dim namauser As String = ""

        ' Menggunakan HashSet untuk menyimpan No Lab yang sudah dihitung
        Dim daftarNoTransaksi As New HashSet(Of String)()

        If PoliKlinik.Lbluser.Text = "Admin" Then
            namauser = "Admin"
        Else
            namauser = ReadSQLNIK("SELECT UserNama FROM Users WHERE UserID = '" & PoliKlinik.Lbluser.Text & "'")
        End If

        If Tbls.Rows.Count > 0 Then
            For Each TrowData As DataRow In Tbls.Rows
                If TgllabStart = "12/31/9998" Then
                    ' Menambahkan No Transaksi ke HashSet
                    daftarNoTransaksi.Add(TrowData("No Lab"))

                    TgllabStart = Format(TrowData("Tanggal Lab"), "MM-dd-yyyy")
                    number = 1
                    jumlahpeserta = 1
                    jumlahtagihan = TrowData("Tagihan")
                    totalrow = 1
                Else
                    If Format(TrowData("Tanggal Lab"), "MM-dd-yyyy") = TgllabStart Then
                        TgllabStart = Format(TrowData("Tanggal Lab"), "MM-dd-yyyy")

                        If Not daftarNoTransaksi.Contains(TrowData("No Lab")) Then
                            ' Menambahkan No Transaksi ke HashSet
                            daftarNoTransaksi.Add(TrowData("No Lab"))

                            ' Menambahkan 1 ke jumlah total No Transaksi
                            jumlahpeserta += 1
                        End If

                        jumlahtagihan = jumlahtagihan + TrowData("Tagihan")
                    ElseIf Format(TrowData("Tanggal Lab"), "MM-dd-yyyy") <> TgllabStart Then
                        Dim Tnew As DataRow = Tdata.NewRow
                        Tnew("No") = number
                        Tnew("Tgl lab") = Format(TgllabStart, "MM-dd-yyyy")
                        Tnew("Jumlah Peserta") = jumlahpeserta & " Orang"
                        Tnew("Keterangan") = "Sesuai Rekapan"
                        Tnew("Total") = jumlahtagihan

                        Tnew("txtglttd") = Ttempat & ", " & Format(DateAndTime.Now, "dd") & " " & BulanIndonesia(Format(DateAndTime.Now, "MM")) & " " & Format(DateAndTime.Now, "yyyy")
                        Tnew("txangkaterbilang") = "Terbilang : " & Terbilang(totaltagihan) & " Rupiah"
                        Tnew("lblnamarekening") = txnamarek.Text
                        Tnew("lblnomorrekening") = txnorek.Text
                        Tnew("lblnamabank") = txnamabank.Text
                        Tnew("namauser") = namauser
                        Tdata.Rows.Add(Tnew)

                        ' =================================

                        ' Clear HashSet
                        daftarNoTransaksi.Clear()

                        ' Menambahkan No Transaksi ke HashSet
                        daftarNoTransaksi.Add(TrowData("No Lab"))

                        totalrow = totalrow + 1
                        number = number + 1
                        totaltagihan = totaltagihan + jumlahtagihan
                        jumlahpeserta = 1
                        jumlahtagihan = TrowData("Tagihan")
                        TgllabStart = Format(TrowData("Tanggal Lab"), "MM-dd-yyyy")
                    End If
                End If
            Next

            totaltagihan = totaltagihan + jumlahtagihan
            Dim Tlastnew As DataRow = Tdata.NewRow
            Tlastnew("No") = number
            Tlastnew("Tgl lab") = Format(TgllabStart, "MM-dd-yyyy")
            Tlastnew("Jumlah Peserta") = jumlahpeserta & " Orang"
            Tlastnew("Keterangan") = "Sesuai Rekapan"
            Tlastnew("Total") = jumlahtagihan

            Tlastnew("txtglttd") = Ttempat & ", " & Format(DateAndTime.Now, "dd") & " " & BulanIndonesia(Format(DateAndTime.Now, "MM")) & " " & Format(DateAndTime.Now, "yyyy")
            Tlastnew("txangkaterbilang") = "Terbilang : " & Terbilang(totaltagihan) & " Rupiah"
            Tlastnew("lblnamarekening") = txnamarek.Text
            Tlastnew("lblnomorrekening") = txnorek.Text
            Tlastnew("lblnamabank") = txnamabank.Text
            Tlastnew("namauser") = namauser
            Tdata.Rows.Add(Tlastnew)
        End If

        Report.DataSource = Tdata
        Dim company As String = TextBoxKeteranganPerusahaan.Text
        Report.Bands.Item(BandKind.ReportHeader).Controls("lblcabang").Text = company.ToString.Trim.ToUpper
        Report.Bands.Item(BandKind.ReportHeader).Controls("lblucapan").Text = "Dengan hormat," & vbCrLf & _
                                                                              "Kami mengucapkan terimakasih atas kepercayaan yang telah diberikan kepada " & Tnamaklinik & ". Bersama surat ini kami menginformasikan tagihan Pemeriksaan Klinik dengan rincian sebagai berikut:"

        TstrPoli = ""
        TstrGigi = ""
        TstrAdmin = ""
        Dim TtempPoli As String = "("
        Dim TtempGigi As String = "("
        Dim TtempAdmin As String = "("
        For Each TrowData As DataRow In Tbls.Rows
            If TrowData("JenisTransaksi").ToString.Trim = "POLI" Then
                TtempPoli = TtempPoli & "'" & TrowData("Translabid").ToString.Trim & "',"
            ElseIf TrowData("JenisTransaksi").ToString.Trim = "GIGI" Then
                TtempGigi = TtempGigi & "'" & TrowData("Translabid").ToString.Trim & "',"
            ElseIf TrowData("JenisTransaksi").ToString.Trim = "ADMIN" Then
                TtempAdmin = TtempAdmin & "'" & TrowData("Translabid").ToString.Trim & "',"
            End If
        Next
        TstrPoli = Strings.Left(TtempPoli, TtempPoli.Length - 1) & ")"
        TstrGigi = Strings.Left(TtempGigi, TtempGigi.Length - 1) & ")"
        TstrAdmin = Strings.Left(TtempAdmin, TtempAdmin.Length - 1) & ")"

        Dim date1 As Date = Now
        Dim date2 As Date = Date.Parse(tgljatuhtempo)
        Dim diffdays As Integer = 0
        Dim Tloc As String = ReadSQLNIK("SELECT StrValue  FROM MsConfig WHERE ConfigName='NoPoli'")

        If date2 < date1 Then
            MsgBox("Tanggal jatuh tempo tidak boleh kurang dari hari ini.")
            Exit Sub
        Else
            diffdays = (date2.Date - date1.Date).Days
        End If

        Dim jenistransaksi As String = ""
        If ComboBoxJenisTransaksi.SelectedIndex = 0 Then
            jenistransaksi = "POLI"
        ElseIf ComboBoxJenisTransaksi.SelectedIndex = 1 Then
            jenistransaksi = "GIGI"
        ElseIf ComboBoxJenisTransaksi.SelectedIndex = 2 Then
            jenistransaksi = "DLL"
        End If

        'Insert Rekap Online
        WriteThemysql("insert into acctransrekaptagihan(company, tgltagihan, periode, duedate, totaltagihan, keterangan, createdate, createby, notagihancompany, cabang, JenisTransaksi) values('" & TextBoxKeteranganPerusahaan.Text + "-" + txkodecabang.Text & "', now(), '" & CInt(diffdays) & "', '" & Format(date2, "yyyy/MM/dd") & "', '" & CDbl(totaltagihan) & "', '-',now(), '" & PoliKlinik.Lbluser.Text & "', '" & NoTagihan & "', '" & Tloc & "', '" & jenistransaksi & "') ", DB_Keuangan)

        'Insert Rekap ke Online & Offline
        Dim RekapID As String = ReadThemysqlNIK("SELECT a.RekapID FROM acctransrekaptagihan a ORDER BY a.RekapID DESC LIMIT 1", DB_Keuangan)

        'Update Rekap Online & Update Transaksi Lokal
        If ComboBoxJenisTransaksi.SelectedIndex = 0 Then
            WriteSQL("update TransaksiPoli set RekapID='" & RekapID & "' WHERE TransPoliID in " & TstrPoli & "", 4)
            WriteThemysql("update acctranstagihandetail set lockeddate=now(), lockedby='" & PoliKlinik.Lbluser.Text & "', RekapID='" & RekapID & "' WHERE inctransid in " & TstrPoli & " and loc = '" & Tloc & "' and incjenis='" & jenistransaksi & "'", DB_Keuangan)
        ElseIf ComboBoxJenisTransaksi.SelectedIndex = 1 Then
            WriteSQL("update TransaksiGigi set RekapID='" & RekapID & "' WHERE TransGigiID in " & TstrGigi & "", 4)
            WriteThemysql("update acctranstagihandetail set lockeddate=now(), lockedby='" & PoliKlinik.Lbluser.Text & "', RekapID='" & RekapID & "' WHERE inctransid in " & TstrGigi & " and loc = '" & Tloc & "' and incjenis='" & jenistransaksi & "'", DB_Keuangan)
        ElseIf ComboBoxJenisTransaksi.SelectedIndex = 2 Then
            WriteSQL("update TransaksiAdmin set RekapID='" & RekapID & "' WHERE TransAdminID in " & TstrAdmin & "", 4)
            WriteThemysql("update acctranstagihandetail set lockeddate=now(), lockedby='" & PoliKlinik.Lbluser.Text & "', RekapID='" & RekapID & "' WHERE inctransid in " & TstrAdmin & " and loc = '" & Tloc & "' and incjenis='" & jenistransaksi & "'", DB_Keuangan)
        End If

        'Insert Lokal
        WriteSQL("insert into RekapTagihan (RekapID,company,tgltagihan,periode,duedate,totaltagihan,keterangan,createdate,createby,notagihancompany, bankid, jenistransaksi) values('" & RekapID & "','" & TextBoxKeteranganPerusahaan.Text + "-" + txkodecabang.Text & "',getdate(),'" & diffdays & "','" & date2 & "','" & CDbl(totaltagihan) & "', '-',getdate() , '" & PoliKlinik.Lbluser.Text & "', '" & NoTagihan & "', '" & txbankid.Text & "', '" & jenistransaksi & "')", 4)

        'Create Jurnal
        Dim AutoJurnal As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='AutoJurnal'")
        If AutoJurnal.Trim = "Yes" Then
            SendingJurnal(NoTagihan, totaltagihan, jenistransaksi)
        End If

        MsgBox("Berhasil Menyimpan Data dengan No. Invoice : " & NoTagihan & "", MsgBoxStyle.Information, "Success!")

        Report.Bands.Item(BandKind.ReportHeader).Controls("lbljenissetoran").Text = "INVOICE"

        Report.Bands.Item(BandKind.ReportHeader).Controls("lbltanggal").Text = tanggalTransaksiReport
        Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:ss") & " By " & PoliKlinik.Lbluser.Text

        'Report.RunDesigner()
        Report.ShowPreview()
        'Report.Print()

        ' SavePDF
        Dim NameFile As String = NoTagihan.Replace("/", "-")
        Dim PathFolder As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='PathAutoSaveInvoice'")
        PathFolder = PathFolder & "INVOICE_POLI" & "\" & Format(DateAndTime.Now, "yyyy") & "\" & Format(DateAndTime.Now, "MMMM") & "\" & Format(DateAndTime.Now, "dd") & ""

        If (Not System.IO.Directory.Exists(PathFolder)) Then
            System.IO.Directory.CreateDirectory(PathFolder)
        End If

        Dim filepath As String = PathFolder & "\" & NameFile & ".pdf"
        If File.Exists(filepath) Then
            My.Computer.FileSystem.DeleteFile(filepath)
        End If
        Report.CreatePdfDocument(filepath)

        'CreateBase64
        Dim Base64Inv As String = ""
        Base64Inv = Convert.ToBase64String(System.IO.File.ReadAllBytes(filepath))

        'Update Base64
        WriteThemysql("UPDATE acctransrekaptagihan a SET a.FileBase64 = '" & Base64Inv & "' WHERE a.notagihancompany = '" & NoTagihan & "'", DB_Keuangan)

        MsgBox("Invoice Otomatis Tersimpan di drive : " & PathFolder & "", MsgBoxStyle.Information, "Success!")

        clear_invoice()
        NewToolStripMenuItem1.PerformClick()
    End Sub

    Private Sub ButtonExportData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExportData.Click
        If ValidasiCetakLaporan() = True Then
            If ComboBoxJenisCetak.Text = "REKAP PENDAPATAN" Then
                LaporanRekapPendapatan()
                Exit Sub
            ElseIf ComboBoxJenisCetak.Text = "REKAP PENDAPATAN TAGIHAN (DETAIL)" Then
                LaporanRekapPendapatanTagihanDetail()
                Exit Sub
            ElseIf ComboBoxJenisCetak.Text = "TANDA TERIMA" Then
                LaporanRekapTandaTerima()
                Exit Sub
            ElseIf ComboBoxJenisCetak.Text = "INVOICE TAGIHAN" Then
                CreateInvoiceTagihan()
                Exit Sub
            End If
        End If
    End Sub
End Class