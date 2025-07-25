Public Class FormSendPinjamanKaryawan
    Dim thread As System.Threading.Thread
    Private UserAdmin As String = PoliKlinik.Lbluser.Text

    ' Set Connection
    Private Find_Keuangan2 As Find.TLconnect
    Private DB_Keuangan2 As TLcon
    Private DB_Poliklinik As TLcon
    Private DB_Jurnal As TLcon

    Private Sub SetConnectionFromConfig()
        ' Set Parameter Server Online
        Dim serverOnline_IP As String = Utility.GetConfig("ServerOnline_IP")
        Dim serverOnline_UserID As String = Utility.GetConfig("ServerOnline_UserID")
        Dim serverOnline_Password As String = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerOnline_Password"), "albert")

        ' Set Find Keuangan 2 (mitramed_keu2019)
        Find_Keuangan2.Tip = serverOnline_IP
        Find_Keuangan2.Tid = serverOnline_UserID
        Find_Keuangan2.Tpass = serverOnline_Password
        Find_Keuangan2.Tdb = Utility.GetConfig("ServerOnlineKeuangan2_DB")

        ' Set DB Keuangan 2 (mitramed_keu2019)
        DB_Keuangan2.Tip = serverOnline_IP
        DB_Keuangan2.Tid = serverOnline_UserID
        DB_Keuangan2.Tpass = serverOnline_Password
        DB_Keuangan2.Tdb = Utility.GetConfig("ServerOnlineKeuangan2_DB")

        ' Set DB Poliklinik
        DB_Poliklinik.Tip = serverOnline_IP
        DB_Poliklinik.Tid = serverOnline_UserID
        DB_Poliklinik.Tpass = serverOnline_Password
        DB_Poliklinik.Tdb = Utility.GetConfig("ServerOnlinePoli_DB")

        ' Set DB Jurnal
        DB_Jurnal.Tip = Utility.GetConfig("ServerJurnal_IP")
        DB_Jurnal.Tid = Utility.GetConfig("ServerJurnal_UserID")
        DB_Jurnal.Tpass = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerJurnal_Password"), "albert")
        DB_Jurnal.Tdb = Utility.GetConfig("ServerJurnal_DB")
    End Sub

    Public Class container
        Public response As Pendaftaran
        Public metaData As MetaData

        Public Var1 As String
        Public Var2 As String
        Public Var3 As String
        Public Var4 As String

        Public result As String
        Public rows() As JSON_result

        Public Class JSON_result
            Public Keterangan As String
            Public Nama As String
            Public Nilai As Double
            Public NIP As String
            Public Sales_Office As String
            Public No_Bukti As String
            Public Tgl_Pinjam As Date
        End Class
    End Class

    Function CreateTable() As DataTable
        Dim Thasil As New DataTable

        insertRowToTbls(Thasil, "Typstring", "No Bukti")
        insertRowToTbls(Thasil, "Typstring", "NIP")
        insertRowToTbls(Thasil, "Typstring", "Nama")
        insertRowToTbls(Thasil, "Typstring", "Keterangan")
        insertRowToTbls(Thasil, "tyinterger", "Nilai")
        insertRowToTbls(Thasil, "Typstring", "Nominal")
        insertRowToTbls(Thasil, "Typstring", "Sales Office")
        insertRowToTbls(Thasil, "typdate", "Tanggal Pinjam")
        insertRowToTbls(Thasil, "typdate", "Tanggal Beban")

        For Each Tcol As DataColumn In Thasil.Columns
            Tcol.ReadOnly = True
        Next

        Return Thasil
    End Function

    Private Sub ClearHeader()
        butsaved.Enabled = True
        butcarikaryawan.Enabled = True
        butselectcabang.Enabled = True
        txcabangid.ResetText()
        txcabangket.ResetText()
        dtprocess.Value = DateAndTime.Now
        dtprocessend.Value = DateAndTime.Now

        cmbjenispinjaman.Enabled = False
        cmbjenispinjaman.SelectedIndex = -1
        butsaved.Enabled = False
        cmbjenistemuan.Enabled = False
        cmbjenistemuan.SelectedIndex = -1
    End Sub

    Private Sub ClearGrid()
        gridlab.DataSource = Nothing
    End Sub

    Private Sub SetClear()
        ' Inisialisasi koneksi ke database MySQL
        SetConnectionFromConfig()

        ClearHeader()
        ClearGrid()
    End Sub

    Private Sub FormSendPinjamanKaryawan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        SetFormHeightWeight(Me, 0.95, 0.8)
        SetClear()
    End Sub

    Private Sub NewToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem1.Click
        SetClear()
    End Sub

    Function Checking() As Boolean
        Dim Tbls As DataTable = gridlab.DataSource
        Dim SelectRow As Boolean = False

        For Each Trow As DataRow In Tbls.Select("[Pilihan]=1")
            SelectRow = True
        Next

        If SelectRow = True Then
            'Next Step
        Else
            'Jika tidak ada data yang dipilih
            MsgBox("Pilih Data Terlebih Dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        If cmbjenispinjaman.Text = "" Then
            MsgBox("Pilih Jenis Pinjaman Terlebih Dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        If cmbjenistemuan.Text = "" And cmbjenispinjaman.SelectedIndex = 1 Then
            MsgBox("Pilih Jenis Temuan Terlebih Dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        Return True
    End Function

    Private Sub buttambahpasien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butcarikaryawan.Click
        If dtprocessend.Value < dtprocess.Value Then
            MsgBox("Tanggal Akhir tidak boleh melebihi tanggal mulai.", MsgBoxStyle.Exclamation, "Warning!")
            Exit Sub
            'ElseIf txsuppid.Text = "" Then
            '    MsgBox("Masukkan Supplier.", MsgBoxStyle.Exclamation, "Warning!")
            '    Exit Sub
        End If

        Dim txsalesoffice As String = txcabangid.Text

        'Dim uri As String = "http://103.115.164.86/api/pinjaman.php?password=GAJICMH&tglAwal=20210101&tglAkhir=20211231"
        Dim uri As String = "http://103.115.164.86/api/pinjaman.php?password=GAJICMH&tglAwal=" & Format(dtprocess.Value, "yyyyMMdd") & "&tglAkhir=" & Format(dtprocessend.Value, "yyyyMMdd") & ""

        Dim rawresp As String = "[" & GetDataAPI(uri) & "]"
        Dim varses() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of container())(rawresp.Replace("Sales Office", "Sales_Office").Replace("No Bukti", "No_Bukti").Replace("Tgl Pinjam", "Tgl_Pinjam"))

        Dim Tdata As DataTable = New DataTable
        Tdata = CreateTable()
        Tdata.Rows.Clear()
        insertRowToTbls(Tdata, "typchecked", "Pilihan")

        'Search data yg sudah pernah dilempar
        Dim Thistory As DataTable = ReadThemysql("SELECT a.nobukti FROM historyuploadpinjaman a WHERE DATE(a.tglpinjam) BETWEEN '" & Format(dtprocess.Value, "yyyyMMdd") & "' AND '" & Format(dtprocessend.Value, "yyyyMMdd") & "'", DB_Keuangan2)

        For Each oneVar As container In varses
            ' Avoid Nothing vars.
            If oneVar IsNot Nothing Then
                For index As Integer = 0 To oneVar.rows.Count - 1
                    Dim Years As Integer = 0
                    Dim Month As Integer = 0
                    Dim VarKeyHistory As Boolean = True

                    For Each TrowHistory As DataRow In Thistory.Rows
                        If oneVar.rows(index).No_Bukti = TrowHistory("nobukti") Then
                            VarKeyHistory = False
                        End If
                    Next

                    If (txsalesoffice = "" Or txsalesoffice = oneVar.rows(index).Sales_Office) And (Format(oneVar.rows(index).Tgl_Pinjam, "yyyyMMdd") >= Format(dtprocess.Value, "yyyyMMdd") And Format(oneVar.rows(index).Tgl_Pinjam, "yyyyMMdd") <= Format(dtprocessend.Value, "yyyyMMdd")) And (VarKeyHistory = True) Then
                        Dim Tlastnew As DataRow = Tdata.NewRow
                        Tlastnew("Nama") = Replace(oneVar.rows(index).Nama, "'", "")
                        Tlastnew("Keterangan") = oneVar.rows(index).Keterangan
                        Tlastnew("Nilai") = oneVar.rows(index).Nilai
                        Tlastnew("Nominal") = Format(Val(oneVar.rows(index).Nilai), "Rp, ###,###.#0")
                        Tlastnew("NIP") = oneVar.rows(index).NIP
                        Tlastnew("No Bukti") = oneVar.rows(index).No_Bukti
                        Tlastnew("Sales Office") = oneVar.rows(index).Sales_Office
                        Tlastnew("Tanggal Pinjam") = oneVar.rows(index).Tgl_Pinjam

                        Years = CDbl(Format(oneVar.rows(index).Tgl_Pinjam, "yyyy"))
                        Month = CDbl(Format(oneVar.rows(index).Tgl_Pinjam, "MM"))
                        Tlastnew("Tanggal Beban") = New DateTime(Years, Month, DateTime.DaysInMonth(Years, Month))
                        Tdata.Rows.Add(Tlastnew)
                    End If
                Next
            End If
        Next

        gridlab.DataSource = Tdata
        GridView1.Columns("Nilai").Visible = False

        If Tdata.Rows.Count > 0 Then
            butsaved.Enabled = True
            cmbjenispinjaman.Enabled = True
        End If

        'Dim Tquery As String = ""

        ''Query Utama
        'Tquery = "SELECT a.rfp, a.nodoc, FORMAT(a.val,0) as 'val', date(a.tglnota) as 'Tgl Nota', a.remarkkas AS 'Supplier', a.remarkkad AS 'No. Faktur' FROM acctranspelunasanapotek a LEFT JOIN masterlokasi b ON a.cct=b.locationcode where (date(a.tglnota) BETWEEN '" & Format(dtprocess.Value, "yyyyMMdd") & "' AND '" & Format(dtprocessend.Value, "yyyyMMdd") & "') AND a.uploadstatus <> 1 AND a.rejectedstatus <> 1 AND a.remarkkas='" & txsuppket.Text & "'"

        'Dim Tbls As DataTable = ReadThemysql(Tquery, DB_Keuangan2)

        'If Tbls.Rows.Count > 0 Then
        '    FindMultiple.Show()
        '    FindMultiple.QueryOLKeu(Tquery, " ORDER BY a.tglnota ASC", "SelectDetailTagihanApotek", 2)
        'Else
        '    MsgBox("Tidak ada data yang ditampilkan.", MsgBoxStyle.Exclamation, "Warning!")
        '    Exit Sub
        'End If
    End Sub

    'Public Sub LoadPasien(ByRef Trow() As DataRow)
    '    If Trow.Length = 0 Then
    '        SetClear()
    '    Else
    '        Dim Tquery As String = ""

    '        'Query Utama
    '        Tquery = "SELECT a.rfp AS 'Jurnal', FORMAT(a.val,0) as 'val', a.nodoc AS 'LPB', a.remarkkad AS 'No Faktur', DATE(a.tgljatuhtempo) AS 'Jatuh Tempo', DATE(a.tglnota) AS 'Tanggal Nota' FROM acctranspelunasanapotek a LEFT JOIN masterlokasi b ON a.cct=b.locationcode where a.uploadstatus <> 1 AND a.rejectedstatus <> 1 AND a.remarkkas='" & txcabangket.Text & "'"

    '        Dim Tstr As String = ""
    '        Dim Ttemp As String = "("
    '        For i As Integer = 0 To Trow.Length - 1
    '            Ttemp = Ttemp & "'" & Trow(i)("nodoc").ToString.Trim & "',"
    '        Next
    '        Tstr = Strings.Left(Ttemp, Ttemp.Length - 1) & ")"
    '        txlpb.Text = Tstr.Replace(")", "").Replace("(", "")

    '        Dim Tbls As DataTable = New DataTable

    '        Tbls = ReadThemysql(Tquery + " and a.nodoc in " & Tstr & " ORDER BY a.tglnota ASC", DB_Keuangan2)

    '        If Tbls.Rows.Count > 0 Then
    '            gridlab.DataSource = Tbls
    '            SetHeader()
    '        Else
    '            MsgBox("Tidak ada data yang ditampilkan.", MsgBoxStyle.Exclamation, "Warning!")
    '            Exit Sub
    '        End If
    '    End If
    'End Sub

    Private Sub SetHeader()
        Dim Tbls As DataTable = gridlab.DataSource
        Dim Total As Double = 0
        Dim Years As Integer = 0
        Dim Month As Integer = 0
        Dim JumlahTransaksi As Integer = 0
        Dim NoFaktur As String = ""

        'For Each Ttemp As DataRow In Tbls.Rows
        '    Total = Total + Ttemp("val")
        '    JumlahTransaksi = JumlahTransaksi + 1
        '    NoFaktur = Ttemp("No Faktur")

        '    'Set Tanggal
        '    dttglnota.Value = Ttemp("Tanggal Nota")
        '    Years = CDbl(Format(Ttemp("Tanggal Nota"), "yyyy"))
        '    Month = CDbl(Format(Ttemp("Tanggal Nota"), "MM"))
        '    dttglbeban.Value = New DateTime(Years, Month, DateTime.DaysInMonth(Years, Month))
        'Next

        'If JumlahTransaksi = 1 Then
        '    txfaktur.Text = NoFaktur
        'Else
        '    txfaktur.Text = JumlahTransaksi & " FAKTUR"
        'End If

        'txsendnominal.Text = Total
        'txnominal.Text = Format(Val(Total), "Rp, ###,###.#0")
        butselectcabang.Enabled = False
    End Sub

    Private Sub butlabrujukan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butselectcabang.Click
        Find.Show()
        Find.QueryTheMysql("SELECT a.locid, a.locationcode, a.locationket, a.locgroup FROM masterlokasi a", " ", "FindSalesOfficePinjaman", 0, Find_Keuangan2)
    End Sub

    Private Sub butsaved_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butsaved.Click
        If Checking() = True Then
            Dim Tbls As DataTable = gridlab.DataSource
            Dim UserID As String = ReadThemysqlNIK("SELECT a.bridginguser FROM users a WHERE a.username = '" & UserAdmin & "'", DB_Poliklinik)
            Dim OutID As String = ReadThemysqlNIK("SELECT b.outid FROM mastersetting a LEFT JOIN accmasterpengeluaran b ON a.value = b.coa WHERE a.name IN ('CoaPiutangKaryawan')", DB_Keuangan2)
            Dim KeteranganPiutang As String = ""
            Dim NomorFakturPiutang As String = ""
            Dim SupplierID As String = ""
            Dim LocID As String = ""

            'Set Jurnal
            Dim bsa As String = ""
            Dim flag As String = ""
            Dim Nourut As String = ""
            'Dim CoaPrepaidExpense As String = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPrepaidExpense'", DB_Keuangan2)
            Dim CoaPotonganLain As String = "42011705"
            Dim CoaJenisDetail As String = ""

            For Each Trow As DataRow In Tbls.Select("[Pilihan]=1")
                KeteranganPiutang = "PIUTANG KARYAWAN a/n " & Trow("Nama") & " BULAN " & BulanIndonesia(Format(Trow("Tanggal Pinjam"), "MM")).ToString.ToUpper & " " & Format(Trow("Tanggal Pinjam"), "yyyy") & " (" & Trow("Keterangan") & ")"
                NomorFakturPiutang = "PIUTANG " & BulanIndonesia(Format(Trow("Tanggal Pinjam"), "MM")).ToString.ToUpper & " " & Format(Trow("Tanggal Pinjam"), "yyyy")

                Dim TLoc As DataTable = ReadThemysql("SELECT a.locid, a.supplierid FROM masterlokasi a WHERE a.locationcode IN ('" & Trow("Sales Office") & "')", DB_Keuangan2)
                Dim TrowLoc As DataRow = TLoc.Rows(0)
                SupplierID = TrowLoc("supplierid")
                LocID = TrowLoc("locid")

                'Set no urut flag
                Nourut = ReadThemysqlNIK("SELECT concat(lpad(RIGHT(a.flag,5)+1,5,0)) FROM historyuploadpinjaman a WHERE a.flag LIKE '%" & Format(Trow("Tanggal Pinjam"), "yyyy") & Format(Trow("Tanggal Pinjam"), "MM") & "PNJ" & "%' ORDER BY a.flag DESC LIMIT 1", DB_Keuangan2)

                If IsDBNull(Nourut) = False And Nourut <> "" And Nourut <> "-" Then
                    flag = Format(Trow("Tanggal Pinjam"), "yyyy") & Format(Trow("Tanggal Pinjam"), "MM") & "PNJ" & Nourut.Trim
                Else
                    flag = Format(Trow("Tanggal Pinjam"), "yyyy") & Format(Trow("Tanggal Pinjam"), "MM") & "PNJ" & "00001"
                End If

                If cmbjenispinjaman.SelectedIndex = 0 Then
                    'Insert Transaksi Baru
                    WriteThemysql("INSERT INTO `acctranskas` (`outid`, `pengajuan`, `transtgl`, `createdby`, `createddate`, `keterangan`, `bebantgl`, `nilaiuang`, `nomorfaktur`, `supplierid`, `loc`, `rfp`, `realisasi`) " & _
                               "VALUES ('" & OutID & "', '1', '" & Format(Trow("Tanggal Pinjam"), "yyyyMMdd") & "', '" & UserID & "', NOW(), '" & KeteranganPiutang & "', '" & Format(Trow("Tanggal Beban"), "yyyyMMdd") & "', '" & CDbl(Trow("Nilai")) & "', '" & NomorFakturPiutang & "', '" & SupplierID & "', '" & LocID & "', 0, '" & CDbl(Trow("Nilai")) & "')", DB_Keuangan2)
                End If

                'Insert Log
                WriteThemysql("INSERT INTO `historyuploadpinjaman` (`nobukti`, `nip`, `nama`, `keterangan`, `nominal`, `salesoffice`, `tglpinjam`, `tglbeban`, `createdby`, `createddate`, `flag`, `jenispinjam`) " & _
                          "VALUES ('" & Trow("No Bukti") & "', '" & Trow("NIP") & "', '" & Trow("Nama") & "', '" & Trow("Keterangan") & "', '" & CDbl(Trow("Nilai")) & "', '" & Trow("Sales Office") & "', '" & Format(Trow("Tanggal Pinjam"), "yyyyMMdd") & "', '" & Format(Trow("Tanggal Beban"), "yyyyMMdd") & "', '" & UserAdmin & "', NOW(), '" & flag & "', '" & cmbjenispinjaman.Text & "')", DB_Keuangan2)

                'Insert Jurnal
                'Set bsa
                bsa = ReadThemysqlNIK("SELECT a.bsa as a FROM bsa a WHERE a.bsaname='" & Trow("Sales Office") & "'", DB_Jurnal)

                If cmbjenispinjaman.SelectedIndex = 1 Then
                    If cmbjenistemuan.SelectedIndex = 0 Then
                        CoaJenisDetail = "11030001"
                    ElseIf cmbjenistemuan.SelectedIndex = 1 Then
                        CoaJenisDetail = "11030002"
                    ElseIf cmbjenistemuan.SelectedIndex = 2 Then
                        CoaJenisDetail = "11030003"
                    End If

                    WriteThemysql("SELECT F_MakeUMH('" & flag & "', 'out', '', '" & Format(Trow("Tanggal Pinjam"), "yyyyMMdd") & "', '" & CoaJenisDetail & "', '" & CoaPotonganLain & "', 'IDR', 1, " & CDbl(Trow("Nilai")) & ", '" & Trow("Keterangan") & "', '1', '1', '', '" & Trow("Keterangan") & "', '" & flag & "', '', '" & bsa & "', 1, " & CDbl(Trow("Nilai")) & ", 'D')", DB_Jurnal)
                ElseIf cmbjenispinjaman.SelectedIndex = 2 Then
                    CoaJenisDetail = "61010100"

                    WriteThemysql("SELECT F_MakeUMH('" & flag & "', 'out', '', '" & Format(Trow("Tanggal Pinjam"), "yyyyMMdd") & "', '" & CoaJenisDetail & "', '" & CoaPotonganLain & "', 'IDR', 1, " & CDbl(Trow("Nilai")) & ", '" & Trow("Keterangan") & "', '1', '1', '', '" & Trow("Keterangan") & "', '" & flag & "', '', '" & bsa & "', 1, " & CDbl(Trow("Nilai")) & ", 'D')", DB_Jurnal)
                End If

                'MsgBox(flag)
            Next

            'Dim NoTransaksi As String = ""

            'NoTransaksi = ReadThemysqlNIK("SELECT a.notrans AS a FROM acctranskas a WHERE a.outid='" & txoutid.Text & "' and a.pengajuan=1 and date(a.transtgl)='" & Format(dttglnota.Value, "yyyyMMdd") & "' and date(a.bebantgl)='" & Format(dttglbeban.Value, "yyyyMMdd") & "' and  a.supplierid='" & txcabangid.Text & "' and a.rfp=1 and a.keterangan='" & txcabangket.Text & "' ORDER BY a.transoutid DESC LIMIT 1", DB_Keuangan2)

            'WriteThemysql("update acctranspelunasanapotek a set a.uploadstatus=1, uploadby='" & UserAdmin & "', uploaddate=NOW(), notrans='" & NoTransaksi & "' WHERE a.nodoc IN (" & txlpb.Text & ") and rejectedstatus <> 1", DB_Keuangan2)

            'MsgBox("Berhasil Menyimpan Data dengan No. Transaksi: " & NoTransaksi & "", MsgBoxStyle.Information, "Success!")
            MsgBox("Berhasil Menyimpan Data.", MsgBoxStyle.Information, "Success!")
            butsaved.Enabled = False
            butcarikaryawan.Enabled = False
            butselectcabang.Enabled = False
        End If
    End Sub

    Public Sub LoadSalesOffice(ByRef txid As String, ByRef txket As String)
        txcabangket.Text = txket
        txcabangid.Text = txid

        'txsuppket.Text = txket
        'txsuppid.Text = txid

        ''Set Lokasi
        'Dim Tloc As DataTable = ReadThemysql("SELECT a.locid, a.locationket FROM masterlokasi a WHERE a.locationcode = '" & txjenis & "'", DB_Keuangan2)
        'Dim Trowloc As DataRow = Tloc.Rows(0)
        'txloc.Text = Trowloc("locationket")
        'txlocid.Text = Trowloc("locid")

        'txpembayaran.Text = ReadThemysqlNIK(" SELECT if(a.supplierid=1,'TUNAI', concat(a.suppliernama, ' - ', b.norekening, ' (', b.namabank ,') a/n ' , b.namarekening)) AS supplier" & _
        '                                    " FROM mastersupplier a" & _
        '                                    " LEFT JOIN accmasterbank b on a.supplierid=b.supplierid" & _
        '                                    " WHERE a.supplierid='" & txid & "'", DB_Keuangan2)

        ''Set OutID
        'Dim Toutid As DataTable = ReadThemysql("SELECT b.jenis, b.outid as outid FROM mastersetting a LEFT JOIN accmasterpengeluaran b ON a.value=b.coa WHERE a.name='CoaUtangPembelianObat'", DB_Keuangan2)
        'Dim Trow As DataRow = Toutid.Rows(0)
        'txoutid.Text = Trow("outid")
        'txjenispengajuan.Text = Trow("jenis").ToString.ToUpper
    End Sub

    Private Sub cmbjenispinjaman_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbjenispinjaman.SelectedIndexChanged
        If cmbjenispinjaman.SelectedIndex = 1 Then
            cmbjenistemuan.Enabled = True
        Else
            cmbjenistemuan.SelectedIndex = -1
            cmbjenistemuan.Enabled = False
        End If
    End Sub
End Class