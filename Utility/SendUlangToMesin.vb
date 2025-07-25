Imports System.Text

Public Class SendUlangToMesin
    Dim Ttmesin As TLcon
    Dim TtconU As TLcon

    Private DB_Poliklinik As TLcon
    Private Find_Poliklinik As Find.TLconnect

    Dim thread As System.Threading.Thread

    Private Sub SendUlangToMesin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        Control.CheckForIllegalCrossThreadCalls = False
        dtproses.Value = DateAndTime.Now
        dtproses.Visible = False
        txnotrans.Visible = False
        btntrans.Visible = False
        Panelload.Visible = False
        lblload.Visible = False
        ProgressBar1.Visible = False
        txtip.Text = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='TIP_Urine'")
        txtip.Visible = False
        lblip.Visible = False
        butcompany.Enabled = False
        TextBoxKeteranganLokasi.Enabled = False
        Me.WindowState = FormWindowState.Normal

        ' Set Parameter Server Online
        Dim serverOnline_IP As String = Utility.GetConfig("ServerOnline_IP")
        Dim serverOnline_UserID As String = Utility.GetConfig("ServerOnline_UserID")
        Dim serverOnline_Password As String = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerOnline_Password"), "albert")

        ' Set DB Poliklinik
        DB_Poliklinik.Tip = serverOnline_IP
        DB_Poliklinik.Tid = serverOnline_UserID
        DB_Poliklinik.Tpass = serverOnline_Password
        DB_Poliklinik.Tdb = Utility.GetConfig("ServerOnlinePoli_DB")

        ' Set Find Poliklinik
        Find_Poliklinik.Tip = serverOnline_IP
        Find_Poliklinik.Tid = serverOnline_UserID
        Find_Poliklinik.Tpass = serverOnline_Password
        Find_Poliklinik.Tdb = Utility.GetConfig("ServerOnlinePoli_DB")
    End Sub

    Public Sub LoadSendUlangToMesin(ByRef TxID As String, ByRef Txnourut As String)
        txnotrans.Text = Txnourut
    End Sub

    Private Sub butproses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butproses.Click
        If (rdnotrans.Checked = False And rdtanggal.Checked = False) Then
            MsgBox("Pilih Mengirim Data Berdasarkan No. Transaksi atau Tanggal.")
            Exit Sub
        ElseIf (cmbjenis.SelectedIndex < 0) Then
            MsgBox("Pilih Jenis Mesin yang Mau Dikirim Ulang.")
            Exit Sub
        ElseIf (rdnotrans.Checked = True And txnotrans.Text = "") Then
            MsgBox("Pilih No. Transaksi Terlebih Dahulu.")
            Exit Sub
        ElseIf TextBoxKeteranganLokasi.Text = "" And (cmbjenis.SelectedIndex = 4 Or cmbjenis.SelectedIndex = 5) Then
            MsgBox("Pilih Cabang Terlebih Dahulu.")
            Exit Sub
        End If

        butproses.Enabled = False
        rdtanggal.Enabled = False
        rdnotrans.Enabled = False
        dtproses.Enabled = False
        txnotrans.Enabled = False
        btntrans.Enabled = False
        txtip.Enabled = False
        lblip.Enabled = False
        thread = New System.Threading.Thread(AddressOf count)
        thread.Start()
    End Sub

    Private Sub count()
        Dim Tquery1 As String = ""
        Dim Tall As String = ""
        Dim Ttindakan As String = ""
        Dim persen As Integer = 0
        Dim jumlah As Integer = 0
        Dim KodeBarcode As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='KodeBarcode'")
        Dim KodeBarcodeOnline As String = ""

        If cmbjenis.SelectedIndex = 0 Or cmbjenis.SelectedIndex = 3 Or cmbjenis.SelectedIndex = 6 Then
            Ttmesin.Tid = "root"
            Ttmesin.Tip = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='TIP'")
            Ttmesin.Tdb = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='TDB'")
            Ttmesin.Tpass = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='TPass'")

            If CekKoneksi("SHOW TABLES FROM " & Ttmesin.Tdb & "", Ttmesin) = False Then
                MsgBox("Proses gagal, cek koneksi ke server DB " & Ttmesin.Tdb & " atau IP " & Ttmesin.Tip & "")
                butproses.Enabled = True
                rdtanggal.Enabled = True
                rdnotrans.Enabled = True
                dtproses.Enabled = True
                txnotrans.Enabled = True
                btntrans.Enabled = True
                txtip.Enabled = True
                lblip.Enabled = True
                Exit Sub
            End If
        ElseIf cmbjenis.SelectedIndex = 1 Or cmbjenis.SelectedIndex = 2 Then
            TtconU.Tid = "root"
            TtconU.Tip = txtip.Text
            TtconU.Tdb = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='TDB_Urine'")
            TtconU.Tpass = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='TPass_Urine'")

            If CekKoneksi("SHOW TABLES FROM " & TtconU.Tdb & "", TtconU) = False Then
                MsgBox("Proses gagal, cek koneksi ke server DB " & TtconU.Tdb & " atau IP " & TtconU.Tip & "")
                butproses.Enabled = True
                rdtanggal.Enabled = True
                rdnotrans.Enabled = True
                dtproses.Enabled = True
                txnotrans.Enabled = True
                btntrans.Enabled = True
                txtip.Enabled = True
                lblip.Enabled = True
                Exit Sub
            End If
        ElseIf cmbjenis.SelectedIndex = 4 Or cmbjenis.SelectedIndex = 5 Then
            If cmbjenis.SelectedIndex = 5 Then
                TtconU.Tid = "root"
                TtconU.Tip = txtip.Text
                TtconU.Tdb = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='TDB_Urine'")
                TtconU.Tpass = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='TPass_Urine'")
            End If

            Ttmesin.Tid = "root"
            Ttmesin.Tip = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='TIP'")
            Ttmesin.Tdb = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='TDB'")
            Ttmesin.Tpass = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='TPass'")

            If CekKoneksi("SHOW TABLES FROM " & DB_Poliklinik.Tdb & "", DB_Poliklinik) = False Then
                MsgBox("Proses gagal, cek koneksi ke server DB " & DB_Poliklinik.Tdb & " atau IP " & DB_Poliklinik.Tip & "")
                butproses.Enabled = True
                rdtanggal.Enabled = True
                rdnotrans.Enabled = True
                dtproses.Enabled = True
                txnotrans.Enabled = True
                btntrans.Enabled = True
                txtip.Enabled = True
                lblip.Enabled = True
                Exit Sub
            End If
        End If

        'Tall = "SELECT * FROM TransaksiLab WHERE Status not in ('CLOSED','NEW','TAKEIT') "
        If cmbjenis.SelectedIndex = 4 Or cmbjenis.SelectedIndex = 5 Then
            Tall = "SELECT * FROM transaksilab WHERE status IS NOT NULL AND idtempatlab = '" & TextBoxKodeLokasi.Text & "'"
        ElseIf cmbjenis.SelectedIndex = 2 Or cmbjenis.SelectedIndex = 2 Then
            Tall = "SELECT * FROM transaksilab WHERE deleted<>1"
        Else
            Tall = "SELECT * FROM transaksilab WHERE deleted<>1 and LabStartTime is not null and( Status='CHECK' or Status='CETAK' or Status='CLOSED' or Status='TAKEIT')"
        End If

        If rdtanggal.Checked = True Then
            If cmbjenis.SelectedIndex = 4 Or cmbjenis.SelectedIndex = 5 Then
                Tquery1 = " and date(tgllab)='" & Format(dtproses.Value, "yyyy-MM-dd") & "' order by idlabinternet "
            Else
                Tquery1 = " and CONVERT(date, Tgllab) = '" & Format(dtproses.Value, "MM/dd/yyyy") & "' order by TransLabID "
            End If
        ElseIf rdnotrans.Checked = True Then
            If cmbjenis.SelectedIndex = 4 Then
                Tquery1 = " and nourut='" & txnotrans.Text & "' order by idlabinternet "
            Else
                Tquery1 = " and nourut='" & txnotrans.Text & "' order by TransLabID "
            End If
        End If

        If txtindakanid.Text <> "" Then
            If cmbjenis.SelectedIndex = 4 Or cmbjenis.SelectedIndex = 5 Then
                Ttindakan = " AND idlabinternet IN (SELECT idlabinternet FROM transaksilabdetail WHERE tindakanid = " & txtindakanid.Text & ") "
            Else
                Ttindakan = " AND TransLabID in (SELECT TransLabID FROM TransaksiLabDetail WHERE TindakanID = '" & txtindakanid.Text & "') "
            End If
        End If

        Dim Tcheck As DataTable
        If cmbjenis.SelectedIndex = 4 Or cmbjenis.SelectedIndex = 5 Then
            KodeBarcodeOnline = ReadThemysqlNIK("SELECT kodebarcode FROM mastercodebarcode WHERE kodecabang = '" & TextBoxKodeLokasi.Text & "'", DB_Poliklinik)

            Tcheck = ReadThemysql(Tall + Ttindakan + Tquery1, DB_Poliklinik)
        Else
            Tcheck = ReadSQL(Tall + Ttindakan + Tquery1)
        End If

        For Each Trow As DataRow In Tcheck.Rows
            Panelload.Visible = True
            lblload.Visible = True
            ProgressBar1.Visible = True

            persen = persen + 1

            Dim Tmesin As DataTable
            If cmbjenis.SelectedIndex = 4 Or cmbjenis.SelectedIndex = 5 Then
                Tmesin = ReadThemysql("SELECT b.NoUrut,b.TglLab,c.Nama,a.Mesin,a.TindakanID,a.NamaTindakan,c.Sex,LEFT(c.Alamat,100) as Alamat,c.nomitra,c.TglLahir FROM transaksilabdetail a LEFT JOIN transaksilab b on a.idlabinternet=b.idlabinternet LEFT JOIN masterpasien c ON b.idpasien=c.nomitra WHERE b.idlabinternet='" & Trow("idlabinternet").ToString & "' AND b.idtempatlab=c.cabang", DB_Poliklinik)
            Else
                Tmesin = ReadSQL("SELECT b.NoUrut,b.TglLab,c.Nama,a.Mesin,a.TindakanID,a.NamaTindakan,f.DrNama,c.JenisKelamin,LEFT(c.DomisiliAlamat,100) as DomisiliAlamat,c.NoRekamMedis,c.TglLahir " & _
                                 "FROM transaksilabdetail a " & _
                                 "LEFT JOIN TransaksiLab b on a.TransLabID = b.TransLabID " & _
                                 "LEFT JOIN MasterPasien c on b.IDInternet = c.NoRekamMedis " & _
                                 "LEFT JOIN MasterDokterTempatPraktek g on g.IdPraktek = b.DokterRequest " & _
                                 "LEFT JOIN MasterDokterKirim f on f.IdKirim = g.IdKirim " & _
                                 "WHERE  b.TransLabID='" & Trow("TransLabID").ToString & "'")
            End If

            For Each Rrow As DataRow In Tmesin.Rows
                If cmbjenis.SelectedIndex = 0 Or cmbjenis.SelectedIndex = 1 Or cmbjenis.SelectedIndex = 3 Or cmbjenis.SelectedIndex = 6 Then
                    If CheckSQL("SELECT * FROM masterlab WHERE TindakanID='" & Rrow("TindakanID") & "' and Mesin='TMS'") = True Then
                        WriteSQL("Update transaksilabdetail set Mesin='TMS' WHERE TransLabID='" & Trow("TransLabID").ToString & "' and TindakanID='" & Rrow("TindakanID") & "'", 4)
                    ElseIf CheckSQL("SELECT * FROM masterlab WHERE TindakanID='" & Rrow("TindakanID") & "' and Mesin='SYSMEX'") = True Then
                        WriteSQL("Update transaksilabdetail set Mesin='SYSMEX' WHERE TransLabID='" & Trow("TransLabID").ToString & "' and TindakanID='" & Rrow("TindakanID") & "'", 4)
                    ElseIf CheckSQL("SELECT * FROM masterlab WHERE TindakanID='" & Rrow("TindakanID") & "' and Mesin='CL900'") = True Then
                        WriteSQL("Update transaksilabdetail set Mesin='CL900' WHERE TransLabID='" & Trow("TransLabID").ToString & "' and TindakanID='" & Rrow("TindakanID") & "'", 4)
                    ElseIf CheckSQL("SELECT * FROM masterlab WHERE TindakanID='" & Rrow("TindakanID") & "' and Mesin='C0BAS6600'") = True Then
                        WriteSQL("Update transaksilabdetail set Mesin='C0BAS6600' WHERE TransLabID='" & Trow("TransLabID").ToString & "' and TindakanID='" & Rrow("TindakanID") & "'", 4)
                    Else
                        WriteSQL("Update transaksilabdetail set Mesin='' WHERE TransLabID='" & Trow("TransLabID").ToString & "' and TindakanID='" & Rrow("TindakanID") & "'", 4)
                    End If
                ElseIf cmbjenis.SelectedIndex = 2 Then
                    If CheckSQL("SELECT * FROM masterlab WHERE TindakanID='" & Rrow("TindakanID") & "' and Mesin='URINE'") = True Then
                        WriteSQL("Update transaksilabdetail set Mesin='URINE' WHERE TransLabID='" & Trow("TransLabID").ToString & "' and TindakanID='" & Rrow("TindakanID") & "'", 4)
                    Else
                        WriteSQL("Update transaksilabdetail set Mesin='' WHERE TransLabID='" & Trow("TransLabID").ToString & "' and TindakanID='" & Rrow("TindakanID") & "'", 4)
                    End If
                ElseIf cmbjenis.SelectedIndex = 4 Or cmbjenis.SelectedIndex = 5 Then 'BELUM DI EDIT
                    If CheckSQL("SELECT * FROM masterlab WHERE TindakanID='" & Rrow("TindakanID") & "' and Mesin='CL900'") = True Then
                        WriteThemysql("Update transaksilabdetail set Mesin='CL900' WHERE TransLabID='" & Trow("TransLabID").ToString & "' and TindakanID='" & Rrow("TindakanID") & "'", DB_Poliklinik)
                    ElseIf CheckSQL("SELECT * FROM masterlab WHERE TindakanID='" & Rrow("TindakanID") & "' and Mesin='SYSMEX'") = True Then
                        WriteThemysql("Update transaksilabdetail set Mesin='SYSMEX' WHERE TransLabID='" & Trow("TransLabID").ToString & "' and TindakanID='" & Rrow("TindakanID") & "'", DB_Poliklinik)
                    ElseIf CheckSQL("SELECT * FROM masterlab WHERE TindakanID='" & Rrow("TindakanID") & "' and Mesin='TMS'") = True Then
                        WriteThemysql("Update transaksilabdetail set Mesin='TMS' WHERE TransLabID='" & Trow("TransLabID").ToString & "' and TindakanID='" & Rrow("TindakanID") & "'", DB_Poliklinik)
                    ElseIf CheckSQL("SELECT * FROM masterlab WHERE TindakanID='" & Rrow("TindakanID") & "' and Mesin='URINE'") = True Then
                        WriteThemysql("Update transaksilabdetail set Mesin='URINE' WHERE TransLabID='" & Trow("TransLabID").ToString & "' and TindakanID='" & Rrow("TindakanID") & "'", DB_Poliklinik)
                    ElseIf CheckSQL("SELECT * FROM masterlab WHERE TindakanID='" & Rrow("TindakanID") & "' and Mesin='C0BAS6600'") = True Then
                        WriteThemysql("Update transaksilabdetail set Mesin='C0BAS6600' WHERE TransLabID='" & Trow("TransLabID").ToString & "' and TindakanID='" & Rrow("TindakanID") & "'", DB_Poliklinik)
                    Else
                        WriteThemysql("Update transaksilabdetail set Mesin='' WHERE TransLabID='" & Trow("TransLabID").ToString & "' and TindakanID='" & Rrow("TindakanID") & "'", DB_Poliklinik)
                    End If
                End If
            Next

            If cmbjenis.SelectedIndex = 0 Or cmbjenis.SelectedIndex = 3 Or cmbjenis.SelectedIndex = 6 Then
                Tmesin = ReadSQL("SELECT b.NoUrut, b.TglLab, c.Nama, a.Mesin, a.TindakanID, a.NamaTindakan, f.DrNama, c.JenisKelamin, LEFT(c.DomisiliAlamat,100) as DomisiliAlamat, c.NoRekamMedis, c.TglLahir " & _
                                 "FROM transaksilabdetail a " & _
                                 "LEFT JOIN TransaksiLab b on a.TransLabID=b.TransLabID " & _
                                 "LEFT JOIN MasterPasien c on b.IDInternet=c.NoRekamMedis " & _
                                 "LEFT JOIN MasterDokterTempatPraktek g on g.IdPraktek=b.DokterRequest " & _
                                 "LEFT JOIN MasterDokterKirim f on f.IdKirim=g.IdKirim " & _
                                 "WHERE  b.TransLabID='" & Trow("TransLabID").ToString & "' and mesin<>'URINE' and Mesin is not null and LTRIM(RTRIM(Mesin))<>''")
                If Tmesin.Rows.Count > 0 Then
                    For Each Mrow As DataRow In Tmesin.Rows
                        If CheckThemysql("SELECT * FROM paslab WHERE NoUrut='" & KodeBarcode & Strings.Replace(Strings.Replace(Strings.Right(Mrow("NoUrut"), Len(Mrow("NoUrut")) - 2), "L", "8"), "M", "9") & "' and TglLab='" & Format(Mrow("TglLab"), "yyyyMMdd") & "' and Instrument='" & Mrow("Mesin") & "' and kode_jasa='" & Mrow("TindakanID") & "' and nama_jasa='" & Mrow("NamaTindakan") & "'", Ttmesin) = False Then
                            WriteThemysql("insert into paslab(`NoUrut`, `TglLab`, `Nama`, `Instrument`, `kode_jasa`, `nama_jasa`,`nama_dok`,`sex`,`alamat`,`no_rm`,`tgl_lahir`,`usertime`) " & _
                                     " values('" & KodeBarcode & Strings.Replace(Strings.Replace(Strings.Right(Mrow("NoUrut"), Len(Mrow("NoUrut")) - 2), "L", "8"), "M", "9") & "','" & Format(Mrow("TglLab"), "yyyyMMdd") & "','" & Mrow("Nama") & "','" & Mrow("Mesin") & "','" & Mrow("TindakanID") & "','" & Mrow("NamaTindakan") & "','" & Mrow("DrNama") & "','" & Mrow("JenisKelamin") & "','" & Mrow("DomisiliAlamat") & "','" & Mrow("NoRekamMedis") & "','" & Format(Mrow("TglLahir"), "yyyyMMdd") & "', NOW())", Ttmesin)
                            jumlah = jumlah + 1
                        End If
                    Next
                End If
                Dim procent As Integer = persen * 100 / Tcheck.Rows.Count
                ProgressBar1.Value = procent
            ElseIf cmbjenis.SelectedIndex = 1 Then
                Dim Tmesin3 As DataTable = ReadSQL("SELECT b.NoUrut,b.TglLab,c.Nama,a.Mesin,a.TindakanID,a.NamaTindakan,f.DrNama,c.JenisKelamin,LEFT(c.DomisiliAlamat,100) as DomisiliAlamat,c.NoRekamMedis,c.TglLahir,DATEDIFF(YYYY, c.TglLahir, GETDATE()) as Umur " & _
                                                   "FROM transaksilabdetail a " & _
                                                   "LEFT JOIN TransaksiLab b on a.TransLabID=b.TransLabID " & _
                                                   "LEFT JOIN MasterPasien c on b.IDInternet=c.NoRekamMedis " & _
                                                   "LEFT JOIN MasterDokterTempatPraktek g on g.IdPraktek=b.DokterRequest " & _
                                                   "LEFT JOIN MasterDokterKirim f on f.IdKirim=g.IdKirim " & _
                                                   "WHERE  b.TransLabID='" & Trow("TransLabID").ToString & "' and mesin<>'URINE' and Mesin is not null and LTRIM(RTRIM(Mesin))<>''")
                If Tmesin3.Rows.Count > 0 Then
                    For Each Mrow As DataRow In Tmesin3.Rows
                        If CheckThemysql("SELECT * FROM order_lab WHERE no_lab='" & KodeBarcode & Strings.Replace(Strings.Replace(Strings.Right(Mrow("NoUrut"), Len(Mrow("NoUrut")) - 2), "L", "8"), "M", "9") & "' and tgl_order='" & Format(Mrow("TglLab"), "yyyyMMdd") & "'", TtconU) = False Then
                            WriteThemysql("insert into order_lab(`no_lab`, `tgl_order`, `nama_pas`, `jenis_kel`, `tgl_lahir`, `usia`,`alamat`,`nama_dok`,`usertime`, `no_rm`) " & _
                                     " values('" & KodeBarcode & Strings.Replace(Strings.Replace(Strings.Right(Mrow("NoUrut"), Len(Mrow("NoUrut")) - 2), "L", "8"), "M", "9") & "','" & Format(Mrow("TglLab"), "yyyyMMdd") & "','" & Mrow("Nama") & "','" & Mrow("JenisKelamin") & "','" & Format(Mrow("TglLahir"), "yyyyMMdd") & "','" & Mrow("Umur") & " Tahun','" & Mrow("DomisiliAlamat") & "','" & Mrow("DrNama") & "',NOW(),'" & Mrow("NoRekamMedis") & "')", TtconU)
                            jumlah = jumlah + 1
                        End If
                    Next
                End If
                Dim procent As Integer = persen * 100 / Tcheck.Rows.Count
                ProgressBar1.Value = procent
            ElseIf cmbjenis.SelectedIndex = 2 Then
                Dim TmesinUrine As DataTable = ReadSQL("SELECT b.NoUrut,b.TglLab,c.Nama,a.Mesin,a.TindakanID,a.NamaTindakan,f.DrNama,c.JenisKelamin,LEFT(c.DomisiliAlamat,100) as DomisiliAlamat,c.NoRekamMedis,c.TglLahir,DATEDIFF(YYYY, c.TglLahir, GETDATE()) as Umur " & _
                                                       "FROM transaksilabdetail a " & _
                                                       "LEFT JOIN TransaksiLab b on a.TransLabID=b.TransLabID " & _
                                                       "LEFT JOIN MasterPasien c on b.IDInternet=c.NoRekamMedis " & _
                                                       "LEFT JOIN MasterDokterTempatPraktek g on g.IdPraktek=b.DokterRequest " & _
                                                       "LEFT JOIN MasterDokterKirim f on f.IdKirim=g.IdKirim " & _
                                                       "WHERE  b.TransLabID='" & Trow("TransLabID").ToString & "' and mesin = 'URINE' and Mesin is not null and LTRIM(RTRIM(Mesin))<>''")
                If TmesinUrine.Rows.Count > 0 Then
                    For Each Troww As DataRow In TmesinUrine.Rows
                        If CheckThemysql("SELECT * FROM order_lab WHERE no_lab='" & KodeBarcode & Strings.Replace(Strings.Replace(Strings.Right(Troww("NoUrut"), Len(Trow("NoUrut")) - 2), "L", "8"), "M", "9") & "' and tgl_order='" & Format(Trow("TglLab"), "yyyyMMdd") & "'", TtconU) = False Then
                            WriteThemysql("insert into order_lab(`no_lab`, `tgl_order`, `nama_pas`, `jenis_kel`, `tgl_lahir`, `usia`,`alamat`,`nama_dok`,`usertime`, `no_rm`) " & _
                                     " values('" & KodeBarcode & Strings.Replace(Strings.Replace(Strings.Right(Troww("NoUrut"), Len(Troww("NoUrut")) - 2), "L", "8"), "M", "9") & "','" & Format(Troww("TglLab"), "yyyyMMdd") & "','" & Troww("Nama") & "','" & Troww("JenisKelamin") & "','" & Format(Troww("TglLahir"), "yyyyMMdd") & "','" & Troww("Umur") & " Tahun','" & Troww("DomisiliAlamat") & "','" & Troww("DrNama") & "',NOW(),'" & Troww("NoRekamMedis") & "')", TtconU)
                            jumlah = jumlah + 1
                        End If
                    Next
                End If
                Dim procent As Integer = persen * 100 / Tcheck.Rows.Count
                ProgressBar1.Value = procent
            ElseIf cmbjenis.SelectedIndex = 4 Then
                Tmesin = ReadThemysql("SELECT b.idtempatlab, b.NoUrut,b.TglLab,c.Nama,a.Mesin,a.TindakanID,a.NamaTindakan,c.Sex,LEFT(c.Alamat,100) as Alamat,c.nomitra,c.TglLahir FROM transaksilabdetail a LEFT JOIN transaksilab b on a.idlabinternet=b.idlabinternet LEFT JOIN masterpasien c on b.idpasien=c.nomitra WHERE  b.TransLabID='" & Trow("TransLabID").ToString & "' and Mesin is not null and LTRIM(RTRIM(Mesin))<>'' AND c.cabang=b.idtempatlab AND b.idtempatlab = '" & TextBoxKodeLokasi.Text & "'", DB_Poliklinik)
                If Tmesin.Rows.Count > 0 Then
                    Dim dataEmpty As Boolean = True
                    Dim queryString As New StringBuilder()

                    queryString.AppendLine("INSERT INTO paslab(`NoUrut`, `TglLab`, `Nama`, `Instrument`, `kode_jasa`, `nama_jasa`,`nama_dok`,`sex`,`alamat`,`no_rm`,`tgl_lahir`,`usertime`) VALUES ")

                    For Each Mrow As DataRow In Tmesin.Rows
                        If CheckThemysql("SELECT * FROM paslab WHERE NoUrut='" & KodeBarcodeOnline & Strings.Replace(Strings.Replace(Strings.Right(Mrow("NoUrut"), Len(Mrow("NoUrut")) - 2), "L", "8"), "M", "9") & "' and TglLab='" & Format(Mrow("TglLab"), "yyyyMMdd") & "' and Instrument='" & Mrow("Mesin") & "' and kode_jasa='" & Mrow("TindakanID") & "' and nama_jasa='" & Mrow("NamaTindakan") & "'", Ttmesin) = False Then
                            'KodeBarcodeOnline = ReadThemysqlNIK("SELECT kodebarcode FROM mastercodebarcode WHERE kodecabang = '" & TextBoxKodeLokasi.Text & "'", DB_Poliklinik)
                            queryString.AppendLine("('" & KodeBarcodeOnline & Strings.Replace(Strings.Replace(Strings.Right(Mrow("NoUrut"), Len(Mrow("NoUrut")) - 2), "L", "8"), "M", "9") & "','" & Format(Mrow("TglLab"), "yyyyMMdd") & "','" & Mrow("Nama") & "','" & Mrow("Mesin") & "','" & Mrow("TindakanID") & "','" & Mrow("NamaTindakan") & "','-','" & Mrow("Sex") & "','" & Mrow("Alamat") & "','" & Mrow("nomitra") & "','" & Format(Mrow("TglLahir"), "yyyyMMdd") & "', NOW()),")
                            'WriteThemysql("insert into paslab(`NoUrut`, `TglLab`, `Nama`, `Instrument`, `kode_jasa`, `nama_jasa`,`nama_dok`,`sex`,`alamat`,`no_rm`,`tgl_lahir`,`usertime`) " & _
                            '         " values('" & KodeBarcodeOnline & Strings.Replace(Strings.Replace(Strings.Right(Mrow("NoUrut"), Len(Mrow("NoUrut")) - 2), "L", "8"), "M", "9") & "','" & Format(Mrow("TglLab"), "yyyyMMdd") & "','" & Mrow("Nama") & "','" & Mrow("Mesin") & "','" & Mrow("TindakanID") & "','" & Mrow("NamaTindakan") & "','-','" & Mrow("Sex") & "','" & Mrow("Alamat") & "','" & Mrow("nomitra") & "','" & Format(Mrow("TglLahir"), "yyyyMMdd") & "', NOW())", Ttmesin)

                            dataEmpty = False
                        End If
                    Next

                    ' Sending to SQL
                    If dataEmpty = False Then
                        Dim sqlStatement As String = queryString.ToString()
                        sqlStatement = sqlStatement.TrimEnd()
                        If sqlStatement.EndsWith(",") Then sqlStatement = sqlStatement.Substring(0, sqlStatement.Length - 1)
                        WriteThemysql(sqlStatement, Ttmesin)

                        ' Set Jumlah Data Terkirim
                        jumlah = jumlah + 1
                    End If
                End If
                Dim procent As Integer = persen * 100 / Tcheck.Rows.Count
                ProgressBar1.Value = procent
            ElseIf cmbjenis.SelectedIndex = 5 Then
                Tmesin = ReadThemysql("SELECT b.dokterrequest AS DrNama, b.idtempatlab, b.NoUrut,b.TglLab, YEAR(CURDATE()) - YEAR(b.tgllahir) AS Umur, c.Nama,a.Mesin,a.TindakanID,a.NamaTindakan,c.Sex,LEFT(c.Alamat,100) as Alamat,c.nomitra,c.TglLahir FROM transaksilabdetail a LEFT JOIN transaksilab b on a.idlabinternet=b.idlabinternet LEFT JOIN masterpasien c on b.idpasien=c.nomitra WHERE  b.TransLabID='" & Trow("TransLabID").ToString & "' and Mesin is not null and LTRIM(RTRIM(Mesin))<>'' AND c.cabang=b.idtempatlab AND b.idtempatlab = '" & TextBoxKodeLokasi.Text & "'", DB_Poliklinik)
                If Tmesin.Rows.Count > 0 Then
                    For Each Mrow As DataRow In Tmesin.Rows
                        'BARU
                        If CheckThemysql("SELECT * FROM order_lab WHERE no_lab='" & KodeBarcode & Strings.Replace(Strings.Replace(Strings.Right(Mrow("NoUrut"), Len(Trow("NoUrut")) - 2), "L", "8"), "M", "9") & "' and tgl_order='" & Format(Trow("TglLab"), "yyyyMMdd") & "'", TtconU) = False Then
                            WriteThemysql("insert into order_lab(`no_lab`, `tgl_order`, `nama_pas`, `jenis_kel`, `tgl_lahir`, `usia`,`alamat`,`nama_dok`,`usertime`, `no_rm`) " & _
                                     " values('" & KodeBarcodeOnline & Strings.Replace(Strings.Replace(Strings.Right(Mrow("NoUrut"), Len(Mrow("NoUrut")) - 2), "L", "8"), "M", "9") & "','" & Format(Mrow("TglLab"), "yyyyMMdd") & "','" & Mrow("Nama") & "','" & Mrow("Sex") & "','" & Format(Mrow("TglLahir"), "yyyyMMdd") & "','" & Mrow("Umur") & " Tahun','" & Mrow("Alamat") & "','" & Mrow("DrNama") & "',NOW(),'" & Mrow("nomitra") & "')", TtconU)
                            jumlah = jumlah + 1
                        End If
                    Next
                End If
                Dim procent As Integer = persen * 100 / Tcheck.Rows.Count
                ProgressBar1.Value = procent
            End If
Past:
        Next

        If jumlah = 0 Then
            MsgBox("No Data Found.")
        Else
            MsgBox("Done. " & jumlah & " Data Send to Mesin")
        End If

        butproses.Enabled = True
        rdtanggal.Enabled = True
        rdnotrans.Enabled = True
        dtproses.Enabled = True
        txnotrans.Enabled = True
        btntrans.Enabled = True
        txtip.Enabled = True
        lblip.Enabled = True
        txnotrans.ResetText()

        Panelload.Visible = False
        lblload.Visible = False
        ProgressBar1.Visible = False
    End Sub

    Private Sub rdnotrans_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdnotrans.CheckedChanged
        If rdnotrans.Checked = True Then
            dtproses.Visible = False
            txnotrans.Visible = True
            btntrans.Visible = True
        End If
    End Sub

    Private Sub rdtanggal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdtanggal.CheckedChanged
        If rdtanggal.Checked = True Then
            dtproses.Visible = True
            txnotrans.Visible = False
            btntrans.Visible = False
        End If
    End Sub


    Private Sub btntrans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btntrans.Click
        Dim Thasil As Date = DateAndTime.Now.AddDays(10)
        Dim Takhir As Date = DateSerial(Thasil.Year, Thasil.Month, Thasil.Day)
        Dim Tawal As Date = DateSerial(DateAndTime.Now.Year, 1, 1)
        Dim DTlong As DataTable = ReadSQL("SELECT StrValue FROM msconfig WHERE ConfigName='LongDate'")
        If DTlong.Rows.Count > 0 Then
            Dim Rdata As DataRow = DTlong.Rows(0)
            Tawal = FormatDateTime(Rdata("StrValue"), DateFormat.ShortDate)
        Else
            MsgBox("Range Tanggal belum ada di config. Set Terlebih dahulu (Default Tahun berjalan).")
        End If

        Find.Show()
        Find.Query("SELECT a.NoUrut,a.TransLabID,a.IDInternet,b.Nama,a.TglLab FROM TransaksiLab a LEFT JOIN MasterPasien b on a.IDInternet=b.NoRekamMedis WHERE ( a.Status='CHECK' or a.Status='CHECK2' or a.Status='CETAK' or a.Status='CLOSED' or a.Status='TAKEIT') and CONVERT(date, a.Tgllab) between '" & Format(Tawal.Date, "MM/dd/yyyy") & "' and '" & Format(Takhir.Date, "MM/dd/yyyy") & "'  and a.deleted<>1 and LabStartTime is not null", " order by a.TransLabID desc,a.TglLab,b.Nama desc", "FindInputResendMesin", 0)
    End Sub

    Private Sub cmbjenis_SELECTedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbjenis.SelectedIndexChanged
        If cmbjenis.SelectedIndex = 0 Then
            txtip.Visible = False
            lblip.Visible = False
            butcompany.Enabled = False
            TextBoxKeteranganLokasi.Enabled = False
        ElseIf cmbjenis.SelectedIndex = 1 Then
            txtip.Visible = True
            lblip.Visible = True
            butcompany.Enabled = False
            TextBoxKeteranganLokasi.Enabled = False
        ElseIf cmbjenis.SelectedIndex = 2 Then
            txtip.Visible = True
            lblip.Visible = True
            butcompany.Enabled = False
            TextBoxKeteranganLokasi.Enabled = False
        ElseIf cmbjenis.SelectedIndex = 3 Then
            txtip.Visible = False
            lblip.Visible = False
            butcompany.Enabled = False
            TextBoxKeteranganLokasi.Enabled = False
        ElseIf cmbjenis.SelectedIndex = 4 Or cmbjenis.SelectedIndex = 5 Then
            txtip.Visible = True
            lblip.Visible = True
            butcompany.Enabled = True
            TextBoxKeteranganLokasi.Enabled = True
        End If

    End Sub

    Private Sub butcompany_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butcompany.Click
        Find.Show()
        Find.QueryTheMysql("SELECT a.kodecabang, a.kodebarcode, a.kodeket FROM mastercodebarcode a", " ORDER BY a.kodeket ASC", "FindCabangSendUlangMesin", 2, Find_Poliklinik)
    End Sub

    Private Sub buttindakan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttindakan.Click
        Find.Show()
        Find.Query("SELECT TindakanID, NamaTindakan, JenisTindakan, Mesin FROM MasterLab WHERE Closed = 0 and Mesin is not null and Mesin <> '' and Mesin <> '-'", " order by TindakanID asc", "FindTindakanResendMesin", 0)
    End Sub
End Class