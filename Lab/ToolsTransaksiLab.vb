Public Class ToolsTransaksiLab
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

    Private Sub count()
        SetConnection()

        If CekKoneksi("SHOW TABLES FROM " & DB_Poliklinik.Tdb & "", DB_Poliklinik) = False Then
            MsgBox("Sending data ke mesin gagal, cek koneksi ke server DB " & DB_Poliklinik.Tdb & " atau IP " & DB_Poliklinik.Tip & ".", MsgBoxStyle.Exclamation, "Warning!")
        Else
            Dim Ttempat As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName like '%NoPoli%'")
            Dim TtempTranslabid As String = ""
            Dim TDataOnline As String = ""
            Dim procent As Integer = 0

            Me.ControlBox = False
            Me.dtuploadstart.Enabled = False

            'Inisialisasi No Transaksi yang sudah di upload
            Dim Tonline As DataTable = ReadThemysql("SELECT a.translabid FROM transaksilab a WHERE a.idtempatlab='" & Ttempat & "' AND DATE(a.tgllab) = '" & Format(dtuploadstart.Value, "yyyy-MM-dd") & "'", DB_Poliklinik)
            If Tonline.Rows.Count > 0 Then
                For Each TRowDetail As DataRow In Tonline.Rows
                    TtempTranslabid = TtempTranslabid & "" & TRowDetail("translabid").ToString.Trim & ", "
                Next
                TtempTranslabid = Strings.Left(TtempTranslabid, TtempTranslabid.Length - 2)
                TDataOnline = "t.translabid not in (" & TtempTranslabid & ") and "
            End If

            'Cek Online
            Dim persen As Integer = 0
            Dim Ttemp As DataTable = ReadSQL("SELECT t.SendingWhatsapp, t.SendingEmail, t.saran, t.TransLabID,t.IDInternet,t.DokterLab,t.DokterRequest,t.IDPaket,t.TglLab, t.DetailPemeriksaan, t.TotalTagihan,t.TotalDisc,t.Pembulatan,t.NettBayar,t.TotalBayar,t.Pengembalian,t.ClosedBayar,t.ClosedInputHasil,t.UserInputHasil,t.TglInputHasil,t.TglCetakHasil,t.UserCetakHasil,t.LabJenisPembayaran,t.TglTerimahasil,t.ClosedTransaksi,t.CreateDate,t.CreateBy,t.ChangeDate,t.ChangeBy,t.LabJenisPasien,t.NoUrut,t.Status,t.CaraAmbil,t.LabDaftar,t.LabSamplingTime,t.LabStartTime,t.LabSendMail,t.LabEndTime,t.LabCetak,t.Upload,t.UploadDate,t.Kesimpulan,t.UploadHasil,m.NoRekamMedis,m.Nama,m.DomisiliAlamat,m.NoHandphone,m.TglLahir,m.JenisKelamin,m.GolonganDarah,m.NoNIK,m.TempatLahir,m.Agama,m.Kewarganegaraan,m.NoTelepon,m.Email,m.NoNIK,m.NoNIP, m.StatusPerkawinan, m.KtpAlamat " & _
                                             "FROM TransaksiLab t, MasterPasien m " & _
                                             "WHERE t.IDInternet = m.NoRekamMedis and t.UploadMesin is null and t.deleted=0 and t.status<>'OPEN' and t.SendKeu is not null and " & TDataOnline & " CONVERT(date, t.TglLab) = '" & Format(dtuploadstart.Value, "yyyyMMdd") & "'")
            If Ttemp.Rows.Count > 0 Then

                status.Text += "Memulai memproses data sejumlah " + Ttemp.Rows.Count.ToString + vbCrLf
                For i As Integer = 0 To Ttemp.Rows.Count - 1
                    Dim Trow As DataRow = Ttemp.Rows(i)
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
                    If CheckThemysql("SELECT translabid FROM transaksilab WHERE nourut='" & Tnourut & "' and translabid='" & Trow("TransLabID") & "' and idtempatlab='" & Ttempat & "' and idpasien='" & Trow("IDInternet").ToString & "'", DB_Poliklinik) = False Then
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

                        ' Insert TransaksiLab Online
                        WriteThemysql("INSERT INTO transaksilab (idlabinternet,translabid,idpasien,idtempatlab,dokterlab,dokterrequest,idpaket,tgllab,totaltagihan,totaldisc,pembulatan,nettbayar,totalbayar,pengembalian,closedbayar,closedinputhasil,userinputhasil,tglinputhasil,tglcetakhasil,usercetakhasil,labjenispembayaran,tglterimahasil,closedtransaksi,createdate,createby,changedate,changeby,labjenispasien,nourut,status,caraambil,labdaftar,labsamplingtime,labstarttime,labsendmail,labendtime,labcetak,upload,uploaddate,kesimpulan,uploadhasil, nama, tgllahir, saran, DetailPemeriksaan, SendingWhatsapp, SendingEmail) " & _
                                      "VALUES('', '" & Trow("TransLabID") & "', '" & Trow("IDInternet").ToString & "', '" & Ttempat & "', '" & Trow("dokterlab") & "', '" & DokterRequest & "','" & Trow("idpaket") & "', '" & Format(Trow("TglLab"), "yyyy-MM-dd HH:mm:ss") & "', '" & Trow("totaltagihan") & "','" & Trow("totaldisc") & "','" & Trow("pembulatan") & "','" & Trow("nettbayar") & "','" & Trow("totalbayar") & "','" & Trow("pengembalian") & "', '" & closedbayar & "', '" & CInt(Int(Trow("closedinputhasil"))) & "','" & Trow("userinputhasil") & "', '" & TglInputHasil & "', '" & TglCetakHasil & "','" & Trow("usercetakhasil") & "','" & Trow("labjenispembayaran") & "', '" & TglTerimahasil & "', '" & Trow("closedtransaksi") & "', '" & Format(Trow("createdate"), "yyyy-MM-dd HH:mm:ss") & "', '" & Trow("createby") & "', '" & ChangeDate & "', '" & Trow("changeby") & "','" & Trow("labjenispasien") & "','" & Trow("nourut") & "','" & Trow("status") & "','" & Trow("caraambil") & "', '" & LabDaftar & "', '" & LabSamplingTime & "',  '" & LabStartTime & "', '" & LabSendMail & "', '" & LabEndTime & "', '" & LabCetak & "', '" & CInt(Int(Trow("upload"))) & "', '" & UploadDate & "', '" & Trow("kesimpulan") & "', '" & UploadHasil & "', '" & Trow("nama") & "', '" & Format(Trow("tgllahir"), "yyyyMMdd") & "', '" & Trow("saran") & "', '" & Trow("DetailPemeriksaan") & "', '" & Trow("SendingWhatsapp") & "', '" & Trow("SendingEmail") & "')", DB_Poliklinik)

                        ' Get idlabinternet Online
                        Dim Tnum As String = ReadThemysqlNIK("SELECT idlabinternet FROM transaksilab WHERE idtempatlab='" & Ttempat & "' and idpasien='" & Trow("IDInternet").ToString & "' and translabid='" & Trow("TransLabID") & "'", DB_Poliklinik)

                        ' Set data untuk insert TransaksiLabResult
                        Dim Tbls As DataTable = ReadSQL("SELECT a.translabiddetail, a.tindakanid, a.groupid as NamaTindakan, a.nourut, a.detailket, a.pria, a.wanita, a.result, a.satuan, a.keterangan, a.acc1, a.acc2, a.acc3, a.admin, a.transaksitime, a.urutan, a.saran FROM transaksilabresult a " & _
                                                    " inner join transaksilabdetail b on a.translabiddetail=b.translabiddetail " & _
                                                    " inner join transaksilab c on b.translabid=c.translabid WHERE c.translabid='" & Trow("translabid") & "' and c.NoUrut = '" & Trow("nourut") & "' " & _
                                                    " order by a.groupid")
                        Tbls.AcceptChanges()

                        For Each Tnewrow As DataRow In Tbls.Rows
                            If String.IsNullOrEmpty(Tnewrow("transaksitime").ToString()) = True Then
                                Tnewrow("transaksitime") = Convert.ToDateTime("1900-01-01")
                            End If

                            ' Insert TransaksiLabResult Online
                            WriteThemysql("INSERT INTO transaksilabresult(idlabinternet, translabiddetail, tindakanid, groupid, nourut, detailket, pria, wanita, result, satuan, keterangan, acc1, acc2, acc3, admin, transaksitime, urutan, saran) " & _
                                       " VALUES('" & Tnum & "','" & Tnewrow("translabiddetail") & "','" & Tnewrow("tindakanid") & "','" & Tnewrow("NamaTindakan") & "','" & Tnewrow("NoUrut") & "','" & Tnewrow("DetailKet") & "','" & Tnewrow("Pria") & "','" & _
                                       Tnewrow("Wanita") & "','" & Tnewrow("Result") & "','" & Tnewrow("Satuan") & "','" & Tnewrow("Keterangan") & "','" & Tnewrow("Acc1") & "','" & Tnewrow("Acc2") & "', '" & Tnewrow("Acc2") & "', '" & Tnewrow("admin") & "', '" & Format(Tnewrow("transaksitime"), "yyyyMMdd") & "', '" & Tnewrow("urutan") & "', '" & Tnewrow("saran") & "')", DB_Poliklinik)
                        Next

                        'TAMBAH TRANSAKSILABDETAIL
                        Dim TblsDetail As DataTable = ReadSQL("SELECT a.* FROM TransaksiLabDetail a left join TransaksiLab b on a.TransLabID=b.TransLabID WHERE a.translabid='" & Trow("translabid") & "' and b.NoUrut = '" & Trow("nourut") & "'")

                        Tbls.AcceptChanges()
                        For Each Tnewrow As DataRow In TblsDetail.Rows
                            If String.IsNullOrEmpty(Tnewrow("transaksitime").ToString()) = True Then
                                Tnewrow("transaksitime") = Convert.ToDateTime("1900-01-01")
                            End If
                            WriteThemysql("INSERT INTO transaksilabdetail(idlabinternet, translabiddetail, TransLabID,TindakanID,NamaTindakan,JenisTindakan,BiayaTindakan,DiscTindakan,NettBayar,admin,transaksitime,DiscPersenTindakan, Mesin) " & _
                                 "VALUES('" & Tnum & "','" & Tnewrow("translabiddetail") & "','" & Tnewrow("translabid") & "','" & Tnewrow("TindakanID") & "','" & Tnewrow("NamaTindakan") & "','" & Tnewrow("JenisTindakan") & "'," & CDbl(Tnewrow("BiayaTindakan")) & "," & CDbl(Tnewrow("DiscTindakan")) & "," & CDbl(Tnewrow("NettBayar")) & ",'" & UserLabAdmin & "',now()," & CDbl(Tnewrow("DiscPersenTindakan")) & ",'" & Tnewrow("Mesin") & "')", DB_Poliklinik)
                        Next

                        'TAMBAH TRANSAKSILABFISIK
                        'TAMBAH TRANSAKSILABHASILLAIN

                        'TAMBAH TRANSAKSILABBAYAR
                        Dim TblsBayar As DataTable = ReadSQL("SELECT * FROM transaksilabbayar WHERE translabid='" & Trow("translabid") & "'")
                        Dim TrowBayar As DataRow = TblsBayar.Rows(0)

                        WriteThemysql("INSERT INTO transaksilabbayar(idlabinternet, translabidbayar, translabid,jenisbayar,nojenisbayar,jumlahbayar,admin,transaksitime,kembali,mesin,kartu) " & _
                                 "VALUES('" & Tnum & "','" & TrowBayar("TransLabIDBayar") & "','" & TrowBayar("TransLabID") & "','" & TrowBayar("JenisBayar") & "','" & TrowBayar("NoJenisBayar") & "','" & CDbl(TrowBayar("JumlahBayar")) & "','" & TrowBayar("admin") & "','" & TrowBayar("transaksitime") & "'," & CDbl(TrowBayar("Kembali")) & ",'" & TrowBayar("mesin") & "','" & TrowBayar("kartu") & "')", DB_Poliklinik)

                        WriteSQL("update TransaksiLab set UploadMesin=1, UploadMesinDate=getdate() WHERE TransLabID='" & Trow("TransLabID") & "'", 4)

                        procent = persen * 100 / Ttemp.Rows.Count
                        txprocent.Text = procent & " %"
                        ProgressBar1.Value = procent


                    End If
                Next

                status.Text += "Proses Data telah terkirim semua. " + vbCrLf
                MsgBox("Proses Data telah terkirim semua.", MsgBoxStyle.Information, "Success!")

                Me.butupload.Enabled = True
                Me.ControlBox = True
                Me.dtuploadstart.Enabled = True
            Else
                MsgBox("Tidak ada data yang di upload.", MsgBoxStyle.Exclamation, "Warning!")

                Me.butupload.Enabled = True
                Me.ControlBox = True
                Me.dtuploadstart.Enabled = True
            End If
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butupload.Click
        Try
            butupload.Enabled = False

            thread = New System.Threading.Thread(AddressOf count)
            thread.Start()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        'thread = New System.Threading.Thread(AddressOf count)
        'thread.Start()
    End Sub

    Private Sub ToolsTransaksiLab_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        Me.MdiParent = PoliKlinik
        dtuploadstart.Value = DateAndTime.Now
        SetConnection()
    End Sub
End Class