Public Class FormCreateRujukan
    Dim thread As System.Threading.Thread
    Private DB_Poliklinik As TLcon

    Private UserLabAdmin As String = PoliKlinik.Lbluser.Text

    Private Sub SetConnection()
        ' Set Parameter Server Online
        Dim serverOnline_IP As String = Utility.GetConfig("ServerOnline_IP")
        Dim serverOnline_UserID As String = Utility.GetConfig("ServerOnline_UserID")
        Dim serverOnline_Password As String = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerOnline_Password"), "albert")

        ' Set DB Poliklinik
        DB_Poliklinik.Tip = serverOnline_IP
        DB_Poliklinik.Tid = serverOnline_UserID
        DB_Poliklinik.Tpass = serverOnline_Password
        DB_Poliklinik.Tdb = Utility.GetConfig("ServerOnlinePoli_DB")
    End Sub

    Private Sub SetGrid(ByVal Tstr As String)
        Dim Tbls As DataTable = ReadSQL("SELECT a.TindakanID,a.NamaTindakan, a.NettBayar as 'Harga CDC', e.HargaRujukan as 'Harga Rujukan' " & _
                                        "FROM TransaksiLabDetail a " & _
                                        "LEFT JOIN MasterLab b on a.TindakanID =b.TindakanID " & _
                                        "LEFT JOIN TransaksiLab c on c.TransLabID=a.TransLabID " & _
                                        "LEFT JOIN MasterHargaTindakanRujukan e on b.TindakanID=e.TindakanID " & _
                                        "WHERE e.NoLabRujukan='" & txlabrujukanid.Text & "' and a.Rujukan=0 and c.nourut in " & Tstr & " group by a.TindakanID, a.NamaTindakan, a.NettBayar, e.HargaRujukan order by a.TindakanID ")
        insertRowToTbls(Tbls, "typchecked", "Checked")
        For Each Tcol As DataColumn In Tbls.Columns
            Tcol.ReadOnly = True
        Next
        Tbls.Columns("Checked").ReadOnly = False
        gridrujukan.DataSource = Tbls
        GridView1.Columns("TindakanID").Visible = False
    End Sub

    Private Sub ClearHeader()
        ProgressBarOnline.Value = 0
        CheckBoxUpload.Checked = False
        CetakSuratRujukanToolStripMenuItem.Enabled = True
        butsaved.Enabled = True
        buttambahpasien.Enabled = True
        butlabrujukan.Enabled = True
        txlabrujukanid.ResetText()
        txlabrujukanket.ResetText()
        txtgllab.ResetText()
        txprinted.ResetText()
        txnosurat.ResetText()
        dtnow.Value = DateAndTime.Now
        dtprocess.Value = DateAndTime.Now
        dtprocessend.Value = DateAndTime.Now
        txtindakanid.ResetText()
        txtindakanket.ResetText()
        txharga.ResetText()
    End Sub

    Private Sub ClearGrid()
        gridrujukan.DataSource = Nothing
        gridpasien.DataSource = Nothing
    End Sub

    Private Sub SetClear()
        ClearHeader()
        ClearGrid()
    End Sub

    Private Sub FormCreateRujukan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
        Me.MdiParent = PoliKlinik
        Me.Dock = DockStyle.Left
        SetClear()
    End Sub

    Private Sub NewToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem1.Click
        SetClear()
    End Sub

    Function Checking() As Boolean
        Dim key As Boolean = False
        Dim Tbls As DataTable = gridrujukan.DataSource
        Dim TblsInv As DataTable = gridpasien.DataSource

        If TblsInv Is Nothing Then
            'Jika tidak ada data yang dipilih
            MsgBox("Pilih Invoice yang akan dirujuk terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        Dim Tstr As String = ""
        Dim Ttemp As String = "("
        For Each Trow As DataRow In Tbls.Select("[Checked]=1")
            key = True
            Ttemp = Ttemp & "'" & Trow("TindakanID").ToString.Trim & "',"
        Next
        Tstr = Strings.Left(Ttemp, Ttemp.Length - 1) & ")"

        If key = False Then
            'Jika tidak ada data tindakan yang dipilih
            MsgBox("Pilih Tindakan Lab yang akan dirujuk.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        Else
            'Jika transaksi tidak ada tindakan yang dipilih
            For Each TrowNew As DataRow In TblsInv.Rows
                If CheckSQL("SELECT * FROM transaksilabdetail WHERE translabid in (SELECT translabid FROM transaksilab WHERE nourut='" & TrowNew("No Lab") & "') and tindakanid in " & Tstr & "") = False Then
                    MsgBox("Transaksi atas nama " & TrowNew("Nama") & " (" & TrowNew("No Lab") & ") tidak ditemukan tindakan yang dipilih.", MsgBoxStyle.Exclamation, "Warning!")
                    Return False
                End If
            Next
        End If

        Return True
    End Function

    Private Sub CetakSuratRujukanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CetakSuratRujukanToolStripMenuItem.Click
        PreviewSuratRujukan()
    End Sub

    Function SetTindakanDetailRujukan(ByVal NoUrut As String, ByVal NoRujukan As String) As String
        Dim TDetailPemeriksaan As DataTable = New DataTable
        Dim DetailPemeriksaan As String = ""
        Dim TtempDetailPemeriksaan As String = ""

        TDetailPemeriksaan = ReadSQL("SELECT b.NamaTindakan FROM TransaksiLab a LEFT JOIN TransaksiLabDetail b ON a.TransLabID = b.TransLabID WHERE NoSuratRujukan IN (SELECT IDSuratRujukan FROM TransaksiRujukanLab WHERE NoSuratRujukan = '" & NoRujukan & "') AND NoUrut = '" & NoUrut & "' ")
        For Each TRowDetailPemeriksaan As DataRow In TDetailPemeriksaan.Rows
            TtempDetailPemeriksaan = TtempDetailPemeriksaan & "" & TRowDetailPemeriksaan("NamaTindakan").ToString.Trim & ", "
        Next

        DetailPemeriksaan = Strings.Left(TtempDetailPemeriksaan, TtempDetailPemeriksaan.Length - 2)

        Return DetailPemeriksaan
    End Function

    Public Sub LoadSuratRujukan(ByVal Txid As String)
        Dim Tdata As DataTable = ReadSQL("SELECT * FROM TransaksiLabDetail  WHERE  Rujukan=1 and NoSuratRujukan='" & Txid & "'")
        Dim Trow As DataRow = Tdata.Rows(0)
        'CetakSuratRujukanToolStripMenuItem.Enabled = True
        dtnow.Value = Trow("TglKirim")

        Dim Tbls As DataTable = ReadSQL("SELECT d.NoRekamMedis, d.Nama, c.Nourut, a.TransLabIDDetail, a.TindakanID,a.NamaTindakan,b.OMR " & _
                                        "FROM TransaksiLabDetail a " & _
                                        "LEFT JOIN MasterLab b on a.TindakanID =b.TindakanID " & _
                                        "LEFT JOIN TransaksiLab c on c.TransLabID=a.TransLabID " & _
                                        "LEFT JOIN MasterPasien d on c.IDInternet=d.NoRekamMedis " & _
                                        "WHERE a.Rujukan=1 and NoSuratRujukan='" & Txid & "'")

        insertRowToTbls(Tbls, "typchecked", "Checked")
        For Each Tcol As DataColumn In Tbls.Columns
            Tcol.ReadOnly = True
        Next
        Tbls.Columns("Checked").ReadOnly = False
        For Each Tnewrow As DataRow In Tbls.Rows
            Tnewrow("Checked") = True
        Next
        Tbls.Columns("Checked").ReadOnly = True

        gridrujukan.DataSource = Tbls
        GridView1.Columns("TransLabIDDetail").Visible = False
        GridView1.Columns("TindakanID").Visible = False
    End Sub

    Private Sub buttambahpasien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttambahpasien.Click
        If dtprocessend.Value < dtprocess.Value Then
            MsgBox("Tanggal Akhir tidak boleh melebihi tanggal mulai.", MsgBoxStyle.Exclamation, "Warning!")
            Exit Sub
        ElseIf txlabrujukanid.Text = "" Then
            MsgBox("Masukkan Lab Rujukan yang dituju.", MsgBoxStyle.Exclamation, "Warning!")
            Exit Sub
        End If

        Dim Tquery As String = ""
        Dim Tpaket As String = ""
        Dim Ttindakanid As String = ""
        Dim Tharga As String = ""

        'Set Harga
        If txharga.Text <> "" And txharga.Text <> "0" Then
            Tharga = " AND TotalBayar = '" & txharga.Text & "'"
        End If

        'Set Tindakan
        If txtindakanid.Text <> "" Then
            Ttindakanid = " AND TindakanID IN ('" & txtindakanid.Text & "')"
        End If

        'Query Utama
        Tquery = "SELECT a.NoUrut as 'No Lab', a.TglLab as 'Tanggal Lab', b.Nama, b.TglLahir as 'Tgl Lahir' " & _
        "FROM transaksilab a " & _
        "LEFT JOIN MasterPasien b on a.idinternet = b.NoRekamMedis " & _
        "WHERE a.Status<>'OPEN' and a.SendKeu is not null and a.deleted <> 1 and (CONVERT(date, a.tgllab) between '" & Format(dtprocess.Value, "MM-dd-yyyy") & "' and '" & Format(dtprocessend.Value, "MM-dd-yyyy") & "') AND a.TransLabID IN (SELECT TransLabID FROM TransaksiLabDetail WHERE Rujukan = 0" & Ttindakanid & ") " & Tharga & ""

        Dim Tbls As DataTable = ReadSQL(Tquery)

        If Tbls.Rows.Count > 0 Then
            FindMultiple.Show()
            FindMultiple.Query(Tquery, " order by a.TglLab, a.nourut asc", "CreateRujukan", 2)
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
            Dim Tcompany As String = ""
            Dim Tpaket As String = ""
            Dim Tjenistransaksi As String = ""
            Dim Tpemeriksaan As String = ""
            Dim TgllabStart As Date = "12/31/9998"
            Dim TgllabEnd As Date = "12/31/9998"

            'Query Utama
            Tquery = "SELECT ROW_NUMBER() OVER (ORDER BY a.Nourut)  AS 'No', a.Translabid, a.NoUrut as 'No Lab', a.TglLab as 'Tanggal Lab', b.NoNIP,b.Nama,b.TglLahir as 'Tgl Lahir',b.DomisiliAlamat, '-' as 'pemeriksaan', JenisKelamin, NoNIK " & _
            "FROM transaksilab a " & _
            "LEFT JOIN MasterPasien b on a.idinternet = b.NoRekamMedis " & _
            "WHERE (CONVERT(date, a.tgllab) between '" & Format(dtprocess.Value, "MM-dd-yyyy") & "' and '" & Format(dtprocessend.Value, "MM-dd-yyyy") & "') "

            Dim Tstr As String = ""
            Dim Ttemp As String = "("
            For i As Integer = 0 To Trow.Length - 1
                Ttemp = Ttemp & "'" & Trow(i)("No Lab").ToString.Trim & "',"
            Next
            Tstr = Strings.Left(Ttemp, Ttemp.Length - 1) & ")"

            Dim Tbls As DataTable = New DataTable
            Dim Tdata As DataTable = New DataTable
            Dim TDetailPemeriksaan As DataTable = New DataTable
            Dim DetailPemeriksaan As String = ""
            Dim TtempDetailPemeriksaan As String = ""

            Tbls = ReadSQL(Tquery + Tcompany + Tjenistransaksi + " and a.Nourut in " & Tstr & " order by a.nourut asc")
            Tdata = CreateTable()
            Tdata.Rows.Clear()

            Dim temppt As String = ""
            Dim temppt2 As String = ""
            Dim number As Integer = 0

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

                    Tnew("No") = TrowData("No") & "."
                    Tnew("No Lab") = TrowData("No Lab")
                    Tnew("Tanggal Lab") = TrowData("Tanggal Lab")
                    Tnew("Nama") = TrowData("Nama").ToString.Trim.ToUpper
                    Tnew("Tgl Lahir") = TrowData("Tgl Lahir")
                    Tnew("Translabid") = TrowData("Translabid")
                    Tnew("DomisiliAlamat") = TrowData("DomisiliAlamat")
                    Tnew("JenisKelamin") = TrowData("JenisKelamin")
                    Tnew("NoNIK") = TrowData("NoNIK")

                    Tdata.Rows.Add(Tnew)
                Next

                If TgllabStart = TgllabEnd Then
                    txtgllab.Text = Format(TgllabStart, "dd") & " " & BulanIndonesia(Format(TgllabStart, "MM")) & " " & Format(TgllabStart, "yyyy")
                Else
                    txtgllab.Text = Format(TgllabStart, "dd") & " " & BulanIndonesia(Format(TgllabStart, "MM")) & " " & Format(TgllabStart, "yyyy") & " s/d " & Format(TgllabEnd, "dd") & " " & BulanIndonesia(Format(TgllabEnd, "MM")) & " " & Format(TgllabEnd, "yyyy")
                End If

                gridpasien.DataSource = Tdata
                GridView2.Columns("Translabid").Visible = False
                GridView2.Columns("DomisiliAlamat").Visible = False
                GridView2.Columns("JenisKelamin").Visible = False
                GridView2.Columns("NoNIK").Visible = False

                SetGrid(Tstr)
            End If
        End If
    End Sub

    Function CreateTable() As DataTable
        Dim Thasil As New DataTable

        insertRowToTbls(Thasil, "Typstring", "No")
        insertRowToTbls(Thasil, "Typstring", "No Lab")
        insertRowToTbls(Thasil, "typdate", "Tanggal Lab")
        insertRowToTbls(Thasil, "Typstring", "Nama")
        insertRowToTbls(Thasil, "Typstring", "DomisiliAlamat")
        insertRowToTbls(Thasil, "Typstring", "JenisKelamin")
        insertRowToTbls(Thasil, "Typstring", "NoNIK")
        insertRowToTbls(Thasil, "typdate", "Tgl Lahir")
        insertRowToTbls(Thasil, "tyinterger", "Translabid")

        For Each Tcol As DataColumn In Thasil.Columns
            Tcol.ReadOnly = True
        Next

        Return Thasil
    End Function

    Private Sub butlabrujukan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butlabrujukan.Click
        Find.Show()
        Find.Query("SELECT NamaLabRujukan, AlamatLabRujukan, UpLabRujukan, NoLabRujukan, CASE WHEN UploadOnline = 1 THEN 'Yes' ELSE 'No' END AS Upload FROM masterlaboratoriumrujukan WHERE getdate() between StartDate and EndDate", " ORDER BY IDLabRujukan desc", "FindLabCreateRujukan", 2)
    End Sub

    Private Sub butsaved_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butsaved.Click
        thread = New System.Threading.Thread(AddressOf SendOnline)
        thread.Start()
    End Sub

    Function SetNoSuratRujukan() As String
        Dim NoTagihan As String = ""
        Dim NoRef1 As String = ""
        Dim NoRef2 As String = ""
        Dim NoRef3 As String = ""
        Dim NoRef4 As String = ""
        Dim angka2 As String = "0001"
        Dim Tawal As Date = Format(DateSerial(DateAndTime.Now.Year, DateAndTime.Now.Month, 1), "MM/dd/yyyy")
        Dim Takhir As Date = Tawal.AddMonths(1).AddDays(-1)

        Dim angka As String = ReadSQLNIK("SELECT TOP 1 REPLACE(STR(LEFT(NoSuratRujukan,4)+1, 4), SPACE(1), '0') FROM TransaksiRujukanLab WHERE CONVERT(date, TglKirim) BETWEEN '" & Tawal & "' AND '" & Takhir & "' ORDER BY NoSuratRujukan desc")

        If angka = "" Or angka = "-" Then
            NoRef1 = angka2
        ElseIf angka <> "" Then
            NoRef1 = angka
        End If

        NoRef2 = "SRL"
        NoRef3 = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='KodeInvoiceLab'")
        NoRef4 = GetRomes(DateAndTime.Now.Month) & "/" & Format(DateAndTime.Now, "yyyy")

        NoTagihan = NoRef1 & "/" & NoRef2 & "/" & NoRef3 & "/" & NoRef4

        Return NoTagihan
    End Function

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        MasterHargaRujukan.Show()
        MasterHargaRujukan.Focus()
    End Sub

    Private Sub txharga_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txharga.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub buttindakan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttindakan.Click
        Find.Show()
        Find.Query("SELECT TindakanID, NamaTindakan, JenisTindakan FROM MasterLab WHERE TindakanID in (SELECT TindakanID FROM MasterHargaTindakanRujukan) and Closed <> 1", " ORDER BY TindakanID asc", "FindTindakanCreateRujukan", 2)
    End Sub

    Private Sub SendOnline()
        If Checking() = True Then
            butsaved.Enabled = False
            buttambahpasien.Enabled = False
            butlabrujukan.Enabled = False

            Dim Tbls As DataTable = gridrujukan.DataSource
            Dim TblsInv As DataTable = gridpasien.DataSource
            Dim NoSuratRujuk = SetNoSuratRujukan()

            'Insert Rujukan Baru (TransaksiRujukanLab)
            WriteSQL("insert into TransaksiRujukanLab(NoSuratRujukan,NoLabRujukan,TglKirim,CreateDate,CreateBy) values('" & NoSuratRujuk & "','" & txlabrujukanid.Text & "',getdate(),getdate(),'" & UserLabAdmin & "')", 4)
            Dim RujukanID As String = ReadSQLNIK("SELECT IDSuratRujukan FROM TransaksiRujukanLab WHERE NoSuratRujukan = '" & NoSuratRujuk & "'")

            'Dim RujukanID As String = "248"

            Dim Tstr As String = ""
            Dim Ttemp As String = "("
            For Each Trow As DataRow In TblsInv.Rows
                Ttemp = Ttemp & "'" & Trow("No Lab").ToString.Trim & "',"
            Next
            Tstr = Strings.Left(Ttemp, Ttemp.Length - 1) & ")"

            'Tstr = "('20210826L00002', '20210826L00003')"

            'Update RujukanID (TransaksiLab)
            WriteSQL("update TransaksiLab set RujukanID='" & RujukanID & "' WHERE NoUrut in " & Tstr & "", 4)

            For Each Trow As DataRow In Tbls.Select("[Checked]=1")
                'Update Data (TransaksiLabDetail)
                WriteSQL("update TransaksiLabDetail set Rujukan='1', NoSuratRujukan='" & RujukanID & "', LabTujuan='" & txlabrujukanid.Text & "', Biaya='" & Trow("Harga Rujukan") & "', TglKirim=getdate() WHERE TindakanID='" & Trow("TindakanID").ToString.Trim & "' and TransLabID in (SELECT TransLabID FROM TransaksiLab WHERE NoUrut in " & Tstr & ")", 4)
            Next

            If CheckBoxUpload.Checked = True Then
                SetConnection()

                If CekKoneksi("SHOW TABLES FROM " & DB_Poliklinik.Tdb & "", DB_Poliklinik) = False Then
                    MsgBox("Sending data ke mesin gagal karena masalah jaringan, cek koneksi ke server DB " & DB_Poliklinik.Tdb & " atau IP " & DB_Poliklinik.Tip & ".", MsgBoxStyle.Exclamation, "Warning!")
                Else
                    Dim Ttempat As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName like '%NoPoli%'")
                    Dim TtempTranslabid As String = ""
                    Dim TDataOnline As String = ""
                    Dim procent As Integer = 0

                    Dim Tonline As DataTable = ReadThemysql("SELECT a.translabid FROM transaksilab a WHERE a.idtempatlab='" & Ttempat & "' AND a.nourut in " & Tstr & "", DB_Poliklinik)
                    If Tonline.Rows.Count > 0 Then
                        For Each TRowDetail As DataRow In Tonline.Rows
                            TtempTranslabid = TtempTranslabid & "" & TRowDetail("translabid").ToString.Trim & ", "
                        Next
                        TtempTranslabid = Strings.Left(TtempTranslabid, TtempTranslabid.Length - 2)
                        TDataOnline = " t.translabid not in (" & TtempTranslabid & ") AND "
                    End If

                    'Cek Online
                    Dim persen As Integer = 0
                    Dim TtempUpload As DataTable = ReadSQL("SELECT t.SendingWhatsapp, t.SendingEmail, t.saran, t.TransLabID,t.IDInternet,t.DokterLab,t.DokterRequest,t.IDPaket,t.TglLab, t.DetailPemeriksaan, t.TotalTagihan,t.TotalDisc,t.Pembulatan,t.NettBayar,t.TotalBayar,t.Pengembalian,t.ClosedBayar,t.ClosedInputHasil,t.UserInputHasil,t.TglInputHasil,t.TglCetakHasil,t.UserCetakHasil,t.LabJenisPembayaran,t.TglTerimahasil,t.ClosedTransaksi,t.CreateDate,t.CreateBy,t.ChangeDate,t.ChangeBy,t.LabJenisPasien,t.NoUrut,t.Status,t.CaraAmbil,t.LabDaftar,t.LabSamplingTime,t.LabStartTime,t.LabSendMail,t.LabEndTime,t.LabCetak,t.Upload,t.UploadDate,t.Kesimpulan,t.UploadHasil,m.NoRekamMedis,m.Nama,m.DomisiliAlamat,m.NoHandphone,m.TglLahir,m.JenisKelamin,m.GolonganDarah,m.NoNIK,m.TempatLahir,m.Agama,m.Kewarganegaraan,m.NoTelepon,m.Email,m.NoNIK,m.NoNIP, m.StatusPerkawinan, m.KtpAlamat " & _
                                                           "FROM TransaksiLab t, MasterPasien m " & _
                                                           "WHERE t.IDInternet = m.NoRekamMedis and t.UploadMesin is null and t.deleted=0 and t.status<>'OPEN' and t.SendKeu is not null and " & TDataOnline & " t.nourut in " & Tstr & "")
                    If TtempUpload.Rows.Count > 0 Then

                        For i As Integer = 0 To TtempUpload.Rows.Count - 1
                            Dim Trow As DataRow = TtempUpload.Rows(i)
                            persen = persen + 1

                            'TAMBAH MASTER PASIEN
                            If CheckThemysql("SELECT * FROM masterpasien WHERE nomitra = '" & Trow("NoRekamMedis") & "' and cabang = '" & Ttempat & "' ", DB_Poliklinik) = False Then
                                WriteThemysql("INSERT INTO masterpasien (`cabang`, `nomitra`, `nokartu`, `nama`, `alamat`, `tempatlahir`, `tgllahir`, `statusmarital`, `agama`, `kebangsaan`, `sex`, `goldarah`, `alergi`, `ktp`, `ktpalamat`, `tlprumah`, `tlp`, `email`, `createdate`, `createby`,`PTNIK`,`NIP`) " & _
                                              "VALUES('" & Ttempat & "', '" & Trow("NoRekamMedis") & "', '-', '" & Trow("Nama") & "','" & Trow("DomisiliAlamat") & "', '" & Trow("TempatLahir") & "', '" & Format(Trow("TglLahir"), "yyyyMMdd") & "', '" & Trow("StatusPerkawinan") & "', '" & Trow("Agama") & "', '" & Trow("Kewarganegaraan") & "', '" & Trow("JenisKelamin") & "', '" & Trow("GolonganDarah") & "', '-', '" & Trow("NoNIK") & "', '" & Trow("KtpAlamat") & "', '" & Trow("NoTelepon") & "', '" & Trow("NoHandphone") & "', '" & Trow("Email") & "', '" & Format(DateAndTime.Now, "yyyyMMdd") & "', '" & UserLabAdmin & "','" & Trow("NoNIK") & "','" & Trow("NoNIP") & "')", DB_Poliklinik)
                            Else
                                If Trow("Email").ToString.Trim <> "" And Trow("Email").ToString.Trim <> "-" And IsDBNull(Trow("Email")) = False And Trow("NoHandphone").ToString.Trim <> "" And Trow("NoHandphone").ToString.Trim <> "-" And IsDBNull(Trow("NoHandphone")) = False Then
                                    WriteThemysql("update masterpasien set Tlp='" & Trow("NoHandphone") & "', email='" & Trow("Email") & "',Alamat='" & Trow("DomisiliAlamat") & "' WHERE nomitra = '" & Trow("NoRekamMedis") & "' and cabang = '" & Ttempat & "'", DB_Poliklinik)
                                ElseIf Trow("Email").ToString.Trim <> "" And Trow("Email").ToString.Trim <> "-" And IsDBNull(Trow("Email")) = False Then
                                    WriteThemysql("update masterpasien set email='" & Trow("email") & "', Alamat='" & Trow("DomisiliAlamat") & "' WHERE nomitra = '" & Trow("NoRekamMedis") & "' and cabang = '" & Ttempat & "'", DB_Poliklinik)
                                ElseIf Trow("NoHandphone").ToString.Trim <> "" And Trow("NoHandphone").ToString.Trim <> "-" And IsDBNull(Trow("NoHandphone")) = False Then
                                    WriteThemysql("update masterpasien set Tlp='" & Trow("NoHandphone") & "', Alamat='" & Trow("DomisiliAlamat") & "' WHERE nomitra = '" & Trow("NoRekamMedis") & "' and cabang = '" & Ttempat & "'", DB_Poliklinik)
                                End If
                            End If

                            Dim LabStartTime As String = ""
                            Dim closedbayar As String = ""
                            Dim TglInputHasil As String = ""
                            Dim TglCetakHasil As String = ""
                            Dim TglTerimahasil As String = ""
                            Dim ChangeDate As String = ""
                            Dim LabDaftar As String = ""
                            Dim LabSamplingTime As String = ""
                            Dim LabSendMail As String = ""
                            Dim LabEndTime As String = ""
                            Dim LabCetak As String = ""
                            Dim UploadDate As String = ""
                            Dim UploadHasil As String = ""
                            Dim Tnourut As String = Trow("NoUrut")
                            Dim DokterRequest As String = ReadSQLNIK("SELECT DrNama FROM MasterDokterKirim WHERE IdKirim in (SELECT IdKirim FROM MasterDokterTempatPraktek WHERE IdPraktek in (SELECT DokterRequest FROM TransaksiLab WHERE TransLabID='" & Trow("TransLabID") & "' and Nourut='" & Trow("nourut") & "'))")
                            If CheckThemysql("SELECT translabid FROM transaksilab WHERE nourut='" & Tnourut & "' and translabid='" & Trow("TransLabID") & "' and idtempatlab='" & Ttempat & "' and idpasien='" & Trow("IDInternet").ToString & "' and tgllab='" & Format(Trow("TglLab"), "yyyyMMdd") & "'", DB_Poliklinik) = False Then
                                If IsDBNull(Trow("closedbayar")) = True Then closedbayar = Format(Convert.ToDateTime("1900-01-01"), "yyyyMMdd") Else closedbayar = Format(Trow("closedbayar"), "yyyy-MM-dd HH:mm:ss")
                                If IsDBNull(Trow("TglInputHasil")) = True Then TglInputHasil = Format(Convert.ToDateTime("1900-01-01"), "yyyyMMdd") Else TglInputHasil = Format(Trow("TglInputHasil"), "yyyy-MM-dd HH:mm:ss")
                                If IsDBNull(Trow("TglCetakHasil")) = True Then TglCetakHasil = Format(Convert.ToDateTime("1900-01-01"), "yyyyMMdd") Else TglCetakHasil = Format(Trow("TglCetakHasil"), "yyyy-MM-dd HH:mm:ss")
                                If IsDBNull(Trow("TglTerimahasil")) = True Then TglTerimahasil = Format(Convert.ToDateTime("1900-01-01"), "yyyyMMdd") Else TglTerimahasil = Format(Trow("TglTerimahasil"), "yyyy-MM-dd HH:mm:ss")
                                If IsDBNull(Trow("ChangeDate")) = True Then ChangeDate = Format(Convert.ToDateTime("1900-01-01"), "yyyyMMdd") Else ChangeDate = Format(Trow("ChangeDate"), "yyyy-MM-dd HH:mm:ss")
                                If IsDBNull(Trow("LabDaftar")) = True Then LabDaftar = Format(Convert.ToDateTime("1900-01-01"), "yyyyMMdd") Else LabDaftar = Format(Trow("LabDaftar"), "yyyy-MM-dd HH:mm:ss")
                                If IsDBNull(Trow("LabSamplingTime")) = True Then LabSamplingTime = Format(Convert.ToDateTime("1900-01-01"), "yyyyMMdd") Else LabSamplingTime = Format(Trow("LabSamplingTime"), "yyyy-MM-dd HH:mm:ss")
                                If IsDBNull(Trow("LabStartTime")) = True Then LabStartTime = Format(Convert.ToDateTime("1900-01-01"), "yyyyMMdd") Else LabStartTime = Format(Trow("LabStartTime"), "yyyy-MM-dd HH:mm:ss")
                                If IsDBNull(Trow("LabSendMail")) = True Then LabSendMail = Format(Convert.ToDateTime("1900-01-01"), "yyyyMMdd") Else LabSendMail = Format(Trow("LabSendMail"), "yyyy-MM-dd HH:mm:ss")
                                If IsDBNull(Trow("LabEndTime")) = True Then LabEndTime = Format(Convert.ToDateTime("1900-01-01"), "yyyyMMdd") Else LabEndTime = Format(Trow("LabEndTime"), "yyyy-MM-dd HH:mm:ss")
                                If IsDBNull(Trow("LabCetak")) = True Then LabCetak = Format(Convert.ToDateTime("1900-01-01"), "yyyyMMdd") Else LabCetak = Format(Trow("LabCetak"), "yyyy-MM-dd HH:mm:ss")
                                If IsDBNull(Trow("UploadDate")) = True Then UploadDate = Format(Convert.ToDateTime("1900-01-01"), "yyyyMMdd") Else UploadDate = Format(Trow("UploadDate"), "yyyy-MM-dd HH:mm:ss")
                                If IsDBNull(Trow("UploadHasil")) = True Then UploadHasil = Format(Convert.ToDateTime("1900-01-01"), "yyyyMMdd") Else UploadHasil = Format(Trow("UploadHasil"), "yyyy-MM-dd HH:mm:ss")

                                WriteThemysql("insert into transaksilab (idlabinternet,translabid,idpasien,idtempatlab,dokterlab,dokterrequest,idpaket,tgllab,totaltagihan,totaldisc,pembulatan,nettbayar,totalbayar,pengembalian,closedbayar,closedinputhasil,userinputhasil,tglinputhasil,tglcetakhasil,usercetakhasil,labjenispembayaran,tglterimahasil,closedtransaksi,createdate,createby,changedate,changeby,labjenispasien,nourut,status,caraambil,labdaftar,labsamplingtime,labstarttime,labsendmail,labendtime,labcetak,upload,uploaddate,kesimpulan,uploadhasil, nama, tgllahir, saran, DetailPemeriksaan, SendingWhatsapp, SendingEmail) " & _
                                              "values('', '" & Trow("TransLabID") & "', '" & Trow("IDInternet").ToString & "', '" & Ttempat & "', '" & Trow("dokterlab") & "', '" & DokterRequest & "','" & Trow("idpaket") & "', '" & Format(Trow("TglLab"), "yyyy-MM-dd HH:mm:ss") & "', '" & Trow("totaltagihan") & "','" & Trow("totaldisc") & "','" & Trow("pembulatan") & "','" & Trow("nettbayar") & "','" & Trow("totalbayar") & "','" & Trow("pengembalian") & "', '" & closedbayar & "', '" & CInt(Int(Trow("closedinputhasil"))) & "','" & Trow("userinputhasil") & "', '" & TglInputHasil & "', '" & TglCetakHasil & "','" & Trow("usercetakhasil") & "','" & Trow("labjenispembayaran") & "', '" & TglTerimahasil & "', '" & Trow("closedtransaksi") & "', '" & Format(Trow("createdate"), "yyyy-MM-dd HH:mm:ss") & "', '" & Trow("createby") & "', '" & ChangeDate & "', '" & Trow("changeby") & "','" & Trow("labjenispasien") & "','" & Trow("nourut") & "','" & Trow("status") & "','" & Trow("caraambil") & "', '" & LabDaftar & "', '" & LabSamplingTime & "',  '" & LabStartTime & "', '" & LabSendMail & "', '" & LabEndTime & "', '" & LabCetak & "', '" & CInt(Int(Trow("upload"))) & "', '" & UploadDate & "', '" & Trow("kesimpulan") & "', '" & UploadHasil & "', '" & Trow("nama") & "', '" & Format(Trow("tgllahir"), "yyyyMMdd") & "', '" & Trow("saran") & "', '" & Trow("DetailPemeriksaan") & "', '" & Trow("SendingWhatsapp") & "', '" & Trow("SendingEmail") & "')", DB_Poliklinik)

                                'TAMBAH TRANSAKSILABRESULT
                                Dim Tnum As String = ReadThemysqlNIK("SELECT idlabinternet FROM transaksilab WHERE idtempatlab='" & Ttempat & "' and idpasien='" & Trow("IDInternet").ToString & "' and translabid='" & Trow("TransLabID") & "'", DB_Poliklinik)
                                Dim TblsOnline As DataTable = ReadSQL("SELECT a.translabiddetail, a.tindakanid, a.groupid as NamaTindakan, a.nourut, a.detailket, a.pria, a.wanita, a.result, a.satuan, a.keterangan, a.acc1, a.acc2, a.acc3, a.admin, a.transaksitime, a.urutan, a.saran FROM transaksilabresult a " & _
                                                            " inner join transaksilabdetail b on a.translabiddetail=b.translabiddetail " & _
                                                            " inner join transaksilab c on b.translabid=c.translabid WHERE c.translabid='" & Trow("translabid") & "' and c.NoUrut = '" & Trow("nourut") & "' " & _
                                                            " order by a.groupid")

                                Tbls.AcceptChanges()
                                For Each Tnewrow As DataRow In TblsOnline.Rows
                                    If String.IsNullOrEmpty(Tnewrow("transaksitime").ToString()) = True Then
                                        Tnewrow("transaksitime") = Convert.ToDateTime("1900-01-01")
                                    End If
                                    WriteThemysql("insert into transaksilabresult(idlabinternet, translabiddetail, tindakanid, groupid, nourut, detailket, pria, wanita, result, satuan, keterangan, acc1, acc2, acc3, admin, transaksitime, urutan, saran) " & _
                                               " values('" & Tnum & "','" & Tnewrow("translabiddetail") & "','" & Tnewrow("tindakanid") & "','" & Tnewrow("NamaTindakan") & "','" & Tnewrow("NoUrut") & "','" & Tnewrow("DetailKet") & "','" & Tnewrow("Pria") & "','" & _
                                               Tnewrow("Wanita") & "','" & Tnewrow("Result") & "','" & Tnewrow("Satuan") & "','" & Tnewrow("Keterangan") & "','" & Tnewrow("Acc1") & "','" & Tnewrow("Acc2") & "', '" & Tnewrow("Acc2") & "', '" & Tnewrow("admin") & "', '" & Format(Tnewrow("transaksitime"), "yyyyMMdd") & "', '" & Tnewrow("urutan") & "', '" & Tnewrow("saran") & "')", DB_Poliklinik)
                                Next

                                'TAMBAH TRANSAKSILABDETAIL
                                Dim TblsDetail As DataTable = ReadSQL("SELECT a.* FROM TransaksiLabDetail a LEFT JOIN TransaksiLab b on a.TransLabID=b.TransLabID WHERE a.translabid='" & Trow("translabid") & "' and b.NoUrut = '" & Trow("nourut") & "'")

                                Tbls.AcceptChanges()
                                For Each Tnewrow As DataRow In TblsDetail.Rows
                                    If String.IsNullOrEmpty(Tnewrow("transaksitime").ToString()) = True Then
                                        Tnewrow("transaksitime") = Convert.ToDateTime("1900-01-01")
                                    End If
                                    WriteThemysql("insert into transaksilabdetail(idlabinternet, translabiddetail, TransLabID,TindakanID,NamaTindakan,JenisTindakan,BiayaTindakan,DiscTindakan,NettBayar,admin,transaksitime,DiscPersenTindakan, Mesin) " & _
                                         "values('" & Tnum & "','" & Tnewrow("translabiddetail") & "','" & Tnewrow("translabid") & "','" & Tnewrow("TindakanID") & "','" & Tnewrow("NamaTindakan") & "','" & Tnewrow("JenisTindakan") & "'," & CDbl(Tnewrow("BiayaTindakan")) & "," & CDbl(Tnewrow("DiscTindakan")) & "," & CDbl(Tnewrow("NettBayar")) & ",'" & UserLabAdmin & "',now()," & CDbl(Tnewrow("DiscPersenTindakan")) & ",'" & Tnewrow("Mesin") & "')", DB_Poliklinik)
                                Next

                                'TAMBAH TRANSAKSILABBAYAR
                                Dim TblsBayar As DataTable = ReadSQL("SELECT * FROM transaksilabbayar WHERE translabid='" & Trow("translabid") & "'")
                                Dim TrowBayar As DataRow = TblsBayar.Rows(0)

                                WriteThemysql("insert into transaksilabbayar(idlabinternet, translabidbayar, translabid,jenisbayar,nojenisbayar,jumlahbayar,admin,transaksitime,kembali,mesin,kartu) " & _
                                         "values('" & Tnum & "','" & TrowBayar("TransLabIDBayar") & "','" & TrowBayar("TransLabID") & "','" & TrowBayar("JenisBayar") & "','" & TrowBayar("NoJenisBayar") & "','" & CDbl(TrowBayar("JumlahBayar")) & "','" & TrowBayar("admin") & "','" & TrowBayar("transaksitime") & "'," & CDbl(TrowBayar("Kembali")) & ",'" & TrowBayar("mesin") & "','" & TrowBayar("kartu") & "')", DB_Poliklinik)

                                procent = persen * 100 / TtempUpload.Rows.Count
                                ProgressBarOnline.Value = procent

                                WriteSQL("update TransaksiLab set UploadMesin=1, UploadMesinDate=getdate() WHERE TransLabID='" & Trow("TransLabID") & "'", 4)
                            End If
                        Next
                    End If
                End If
            End If

            MsgBox("Berhasil Menyimpan Data dengan No. Surat Rujukan : " & NoSuratRujuk & ". Silahkan Preview & Cetak Surat Rujukan.", MsgBoxStyle.Information, "Success!")

            txnosurat.Text = NoSuratRujuk
        End If
    End Sub

    Private Sub PreviewSuratRujukan()
        If txnosurat.Text = "" Then
            MsgBox("Buat Surat Rujukan Terlebih Dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Exit Sub
        End If

        Dim Tbls As DataTable = ReadSQL("SELECT ROW_NUMBER() OVER (ORDER BY NoRekamMedis ASC) AS 'No', UPPER(Nama) AS 'Nama', b.NoUrut, CONVERT(DATE, TglLahir) AS 'Tgl Lahir', CONVERT(date, TglLab) AS 'Tgl Invoice', DomisiliAlamat, JenisKelamin, NoNIK " & _
                                        "FROM MasterPasien a LEFT JOIN TransaksiLab b ON a.NoRekamMedis = b.IDInternet " & _
                                        "LEFT JOIN TransaksiLabDetail c ON b.TransLabID = c.TransLabID " & _
                                        "WHERE c.NoSuratRujukan IN (SELECT IDSuratRujukan FROM TransaksiRujukanLab WHERE NoSuratRujukan = '" & txnosurat.Text & "') " & _
                                        "GROUP BY Nama, TglLahir, TglLab, NoUrut, NoRekamMedis, DomisiliAlamat, JenisKelamin, NoNIK ORDER BY NoRekamMedis ASC")

        insertRowToTbls(Tbls, "typstring", "TindakanDetail")
        insertRowToTbls(Tbls, "typstring", "NamaLabRujukan")
        insertRowToTbls(Tbls, "typstring", "AlamatLabRujukan")
        insertRowToTbls(Tbls, "typstring", "UpLabRujukan")
        insertRowToTbls(Tbls, "typstring", "TglTransaksi")
        insertRowToTbls(Tbls, "typstring", "NoSuratRujukan")
        insertRowToTbls(Tbls, "typstring", "TglSurat")
        insertRowToTbls(Tbls, "typstring", "txnamauser")
        insertRowToTbls(Tbls, "typstring", "txtglttd")
        insertRowToTbls(Tbls, "typstring", "lblprinted")

        Dim Ttempat As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='Kota'")
        Dim TCompany As DataTable = ReadSQL("SELECT NamaLabRujukan, AlamatLabRujukan, UpLabRujukan, convert(date, a.TglKirim) as 'TglTransaksi' FROM TransaksiRujukanLab a LEFT JOIN MasterLaboratoriumRujukan b on a.NoLabRujukan=b.NoLabRujukan WHERE a.NoSuratRujukan = '" & txnosurat.Text & "'")
        Dim TrowCompany As DataRow = TCompany.Rows(0)

        For Each Trow As DataRow In Tbls.Rows
            Trow("TindakanDetail") = SetTindakanDetailRujukan(Trow("NoUrut"), txnosurat.Text)
            Trow("NamaLabRujukan") = TrowCompany("NamaLabRujukan")
            Trow("AlamatLabRujukan") = TrowCompany("AlamatLabRujukan")
            Trow("UpLabRujukan") = TrowCompany("UpLabRujukan")
            Trow("TglTransaksi") = Format(TrowCompany("TglTransaksi"), "dd") & " " & BulanIndonesia(Format(TrowCompany("TglTransaksi"), "MM")) & " " & Format(TrowCompany("TglTransaksi"), "yyyy")
            Trow("NoSuratRujukan") = txnosurat.Text
            Trow("txtglttd") = Ttempat & ", " & Format(DateAndTime.Now, "dd") & " " & BulanIndonesia(Format(DateAndTime.Now, "MM")) & " " & Format(DateAndTime.Now, "yyyy")

            If UserLabAdmin = "Admin" Then
                Trow("txnamauser") = "Admin"
            Else
                Trow("txnamauser") = ReadSQLNIK("SELECT UserNama FROM Users WHERE UserID = '" & UserLabAdmin & "'")
            End If

            Trow("lblprinted") = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:ss") & " By " & UserLabAdmin
            Trow("TglSurat") = Format(DateAndTime.Now, "dd") & " " & BulanIndonesia(Format(DateAndTime.Now, "MM")) & " " & Format(DateAndTime.Now, "yyyy")
        Next

        Report = New XtraReport
        Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\Rujukan\SuratRujukanLabNonKop.repx", True)
        Report.DataSource = Tbls
        'Report.RunDesigner()
        Report.ShowPreview()
    End Sub
End Class