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

    Private Function ValidasiDataUpload() As Boolean
        ' Cek sambungan internet
        If CheckInternetConnection() = False Then
            MessageBox.Show("Eror : Tidak ada koneksi internet.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Return False
        End If

        ' Cek Koneksi Database Online
        If Not ValidasiKoneksi("Database Poliklinik Online", DB_Poliklinik) Then Return False

        Return True
    End Function

    Private Sub UploadData()
        SetConnection()

        If ValidasiDataUpload() = True Then
            ' Disable Control Saat Upload
            Me.ControlBox = False
            Me.DateTimeUpload.Enabled = False

            ' Set Variabel
            Dim kodePoli As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName LIKE '%NoPoli%'")

            ' Query Get Data Offline
            Dim stringQuery As New System.Text.StringBuilder()
            stringQuery.AppendLine("SELECT *")
            stringQuery.AppendLine("FROM TransaksiLab t")
            stringQuery.AppendLine("     INNER JOIN MasterPasien m ON t.IDInternet = m.NoRekamMedis")
            stringQuery.AppendLine("WHERE t.deleted = 0")
            stringQuery.AppendLine("  AND (t.UploadMesin IS NULL OR Status = 'CETAK' OR Status = 'TAKEIT')")
            stringQuery.AppendLine("  AND t.LabSamplingTime IS NOT NULL")
            'stringQuery.AppendLine("  AND t.NoUrut = '20250909L00008'")
            stringQuery.AppendLine("  AND CONVERT(DATE, t.TglLab) = '" & Format(DateTimeUpload.Value, "yyyyMMdd") & "'")

            ' Set Data tblTransaksi
            Dim tblTransaksi As DataTable = ReadSQL(stringQuery.ToString())

            Dim persentaseProgres As Integer = 0
            Dim transaksiSuccess As Integer = 0
            Dim transaksiProcess As Integer = 0

            If tblTransaksi.Rows.Count > 0 Then

                status.Text += "Memulai memproses data sejumlah " + tblTransaksi.Rows.Count.ToString + vbCrLf

                For i As Integer = 0 To tblTransaksi.Rows.Count - 1
                    Dim rowTransaksi As DataRow = tblTransaksi.Rows(i)

                    ' Tambah Jumlah Proses Upload
                    transaksiProcess += 1

                    Dim closedbayar As String = GetDateValue(rowTransaksi, "closedbayar")
                    Dim TglInputHasil As String = GetDateValue(rowTransaksi, "TglInputHasil")
                    Dim TglCetakHasil As String = GetDateValue(rowTransaksi, "TglCetakHasil")
                    Dim TglTerimahasil As String = GetDateValue(rowTransaksi, "TglTerimahasil")
                    Dim ChangeDate As String = GetDateValue(rowTransaksi, "ChangeDate")
                    Dim LabDaftar As String = GetDateValue(rowTransaksi, "LabDaftar")
                    Dim LabSamplingTime As String = GetDateValue(rowTransaksi, "LabSamplingTime")
                    Dim LabStartTime As String = GetDateValue(rowTransaksi, "LabStartTime")
                    Dim LabSendMail As String = GetDateValue(rowTransaksi, "LabSendMail")
                    Dim LabEndTime As String = GetDateValue(rowTransaksi, "LabEndTime")
                    Dim LabCetak As String = GetDateValue(rowTransaksi, "LabCetak")
                    Dim UploadDate As String = GetDateValue(rowTransaksi, "UploadDate")
                    Dim UploadHasil As String = GetDateValue(rowTransaksi, "UploadHasil")

                    Dim dokterPengirim As String = ReadSQLNIK("SELECT DrNama FROM MasterDokterKirim WHERE IdKirim in (SELECT IdKirim FROM MasterDokterTempatPraktek WHERE IdPraktek in (SELECT DokterRequest FROM TransaksiLab WHERE TransLabID='" & rowTransaksi("TransLabID") & "' and Nourut='" & rowTransaksi("nourut") & "'))")

                    ' Query Get Data TransaksiLabResult
                    Dim stringQueryLabResult As New System.Text.StringBuilder()
                    stringQueryLabResult.AppendLine("SELECT a.translabiddetail, a.tindakanid, a.groupid as NamaTindakan, a.nourut, a.detailket, a.pria, a.wanita, a.result, a.satuan, a.keterangan, a.acc1, a.acc2, a.acc3, a.admin, a.transaksitime, a.urutan, a.saran")
                    stringQueryLabResult.AppendLine("FROM transaksilabresult a")
                    stringQueryLabResult.AppendLine("     INNER JOIN transaksilabdetail b ON a.translabiddetail = b.translabiddetail")
                    stringQueryLabResult.AppendLine("     INNER JOIN transaksilab c ON b.translabid = c.translabid")
                    stringQueryLabResult.AppendLine("WHERE c.NoUrut = '" & rowTransaksi("NoUrut") & "'")
                    stringQueryLabResult.AppendLine("ORDER BY a.groupid")

                    ' Set Data tblLabResult
                    Dim tblLabResult As DataTable = ReadSQL(stringQueryLabResult.ToString())
                    tblLabResult.AcceptChanges()

                    ' Query Get Data TransaksiLabDetail
                    Dim stringQueryLabDetail As New System.Text.StringBuilder()
                    stringQueryLabDetail.AppendLine("SELECT a.*")
                    stringQueryLabDetail.AppendLine("FROM TransaksiLabDetail a")
                    stringQueryLabDetail.AppendLine("     LEFT JOIN TransaksiLab b ON a.TransLabID = b.TransLabID")
                    stringQueryLabDetail.AppendLine("WHERE b.NoUrut = '" & rowTransaksi("NoUrut") & "'")

                    ' Set Data tblLabResult
                    Dim tblLabDetail As DataTable = ReadSQL(stringQueryLabDetail.ToString())
                    tblLabDetail.AcceptChanges()

                    ' Query Get Data TransaksiLabBayar
                    Dim stringQueryLabBayar As New System.Text.StringBuilder()
                    stringQueryLabBayar.AppendLine("SELECT a.*")
                    stringQueryLabBayar.AppendLine("FROM TransaksiLabBayar a")
                    stringQueryLabBayar.AppendLine("     LEFT JOIN TransaksiLab b ON a.TransLabID = b.TransLabID")
                    stringQueryLabBayar.AppendLine("WHERE b.NoUrut = '" & rowTransaksi("NoUrut") & "'")

                    ' Set Data tblLabResult
                    Dim tblLabBayar As DataTable = ReadSQL(stringQueryLabBayar.ToString())
                    tblLabBayar.AcceptChanges()

                    ' Insert/Update Tabel Master Pasien
                    If CheckThemysql("SELECT * FROM masterpasien WHERE nomitra = '" & rowTransaksi("NoRekamMedis") & "' AND cabang = '" & kodePoli & "' ", DB_Poliklinik) = False Then
                        WriteThemysql("INSERT INTO masterpasien (`cabang`, `nomitra`, `nokartu`, `nama`, `alamat`, `tempatlahir`, `tgllahir`, `statusmarital`, `agama`, `kebangsaan`, `sex`, `goldarah`, `alergi`, `ktp`, `ktpalamat`, `tlprumah`, `tlp`, `email`, `createdate`, `createby`,`PTNIK`,`NIP`) " & _
                                      "VALUES('" & kodePoli & "', '" & rowTransaksi("NoRekamMedis") & "', '-', '" & rowTransaksi("Nama") & "','" & rowTransaksi("DomisiliAlamat") & "', '" & rowTransaksi("TempatLahir") & "', '" & Format(rowTransaksi("TglLahir"), "yyyyMMdd") & "', '" & rowTransaksi("StatusPerkawinan") & "', '" & rowTransaksi("Agama") & "', '" & rowTransaksi("Kewarganegaraan") & "', '" & rowTransaksi("JenisKelamin") & "', '" & rowTransaksi("GolonganDarah") & "', '-', '" & rowTransaksi("NoNIK") & "', '" & rowTransaksi("KtpAlamat") & "', '" & rowTransaksi("NoTelepon") & "', '" & rowTransaksi("NoHandphone") & "', '" & rowTransaksi("Email") & "', '" & Format(DateAndTime.Now, "yyyyMMdd") & "', '" & UserLabAdmin & "','" & rowTransaksi("NoNIK") & "','" & rowTransaksi("NoNIP") & "')", DB_Poliklinik)
                    Else
                        WriteThemysql("UPDATE masterpasien SET NIP = '" & rowTransaksi("NoNIP").ToString.Trim & "', alamat = '" & rowTransaksi("DomisiliAlamat").ToString.Trim & "', tlp = '" & rowTransaksi("NoHandphone").ToString.Trim & "', email='" & rowTransaksi("Email").ToString.Trim & "' WHERE nomitra = '" & rowTransaksi("NoRekamMedis") & "' and cabang = '" & kodePoli & "'", DB_Poliklinik)
                    End If

                    ' Insert/Update Tabel Transaksi
                    If CheckThemysql("SELECT * FROM transaksilab WHERE nourut = '" & rowTransaksi("NoUrut") & "' AND idtempatlab = '" & kodePoli & "' AND idpasien = '" & rowTransaksi("IDInternet").ToString & "'", DB_Poliklinik) = False Then
                        ' ###### INSERT DATA ONLINE ######

                        ' Insert Tabel TransaksiLab Online
                        WriteThemysql("INSERT INTO transaksilab (idlabinternet, translabid, idpasien, idtempatlab, dokterlab, dokterrequest, idpaket, tgllab, totaltagihan, totaldisc, pembulatan, nettbayar, totalbayar, pengembalian, closedbayar, closedinputhasil, userinputhasil, tglinputhasil, tglcetakhasil, usercetakhasil, labjenispembayaran, tglterimahasil, closedtransaksi, createdate, createby, changedate, changeby, labjenispasien, nourut, status, caraambil, labdaftar, labsamplingtime, labstarttime, labsendmail, labendtime, labcetak, upload, uploaddate, kesimpulan, uploadhasil, nama, tgllahir, saran, DetailPemeriksaan, SendingWhatsapp, SendingEmail) " & _
                                      "VALUES('', '" & rowTransaksi("TransLabID") & "', '" & rowTransaksi("IDInternet").ToString & "', '" & kodePoli & "', '" & rowTransaksi("dokterlab") & "', '" & dokterPengirim & "','" & rowTransaksi("idpaket") & "', '" & Format(rowTransaksi("TglLab"), "yyyy-MM-dd HH:mm:ss") & "', '" & rowTransaksi("totaltagihan") & "','" & rowTransaksi("totaldisc") & "','" & rowTransaksi("pembulatan") & "','" & rowTransaksi("nettbayar") & "','" & rowTransaksi("totalbayar") & "','" & rowTransaksi("pengembalian") & "', '" & closedbayar & "', '" & CInt(Int(rowTransaksi("closedinputhasil"))) & "','" & rowTransaksi("userinputhasil") & "', '" & TglInputHasil & "', '" & TglCetakHasil & "','" & rowTransaksi("usercetakhasil") & "','" & rowTransaksi("labjenispembayaran") & "', '" & TglTerimahasil & "', '" & rowTransaksi("closedtransaksi") & "', '" & Format(rowTransaksi("createdate"), "yyyy-MM-dd HH:mm:ss") & "', '" & rowTransaksi("createby") & "', '" & ChangeDate & "', '" & rowTransaksi("changeby") & "','" & rowTransaksi("labjenispasien") & "','" & rowTransaksi("nourut") & "','" & rowTransaksi("status").ToString.Trim & "','" & rowTransaksi("caraambil") & "', '" & LabDaftar & "', '" & LabSamplingTime & "',  '" & LabStartTime & "', '" & LabSendMail & "', '" & LabEndTime & "', '" & LabCetak & "', '" & CInt(Int(rowTransaksi("upload"))) & "', '" & UploadDate & "', '" & rowTransaksi("kesimpulan") & "', '" & UploadHasil & "', '" & rowTransaksi("nama") & "', '" & Format(rowTransaksi("tgllahir"), "yyyyMMdd") & "', '" & rowTransaksi("saran") & "', '" & rowTransaksi("DetailPemeriksaan") & "', '" & rowTransaksi("SendingWhatsapp") & "', '" & rowTransaksi("SendingEmail") & "')", DB_Poliklinik)

                        ' Get idlabinternet Online
                        Dim idTransaksiOnline As String = ReadThemysqlNIK("SELECT idlabinternet FROM transaksilab WHERE idtempatlab='" & kodePoli & "' and idpasien='" & rowTransaksi("IDInternet").ToString & "' and translabid='" & rowTransaksi("TransLabID") & "'", DB_Poliklinik)

                        ' Insert Tabel TransaksiLabResult Online
                        For Each rowResult As DataRow In tblLabResult.Rows
                            If String.IsNullOrEmpty(rowResult("transaksitime").ToString()) = True Then
                                rowResult("transaksitime") = Convert.ToDateTime("1900-01-01")
                            End If

                            WriteThemysql("INSERT INTO transaksilabresult(idlabinternet, translabiddetail, tindakanid, groupid, nourut, detailket, pria, wanita, result, satuan, keterangan, acc1, acc2, acc3, admin, transaksitime, urutan, saran) " & _
                                          " VALUES('" & idTransaksiOnline & "','" & rowResult("translabiddetail") & "','" & rowResult("tindakanid") & "','" & rowResult("NamaTindakan") & "','" & rowResult("NoUrut") & "','" & rowResult("DetailKet") & "','" & rowResult("Pria") & "','" & _
                                          rowResult("Wanita") & "','" & rowResult("Result") & "','" & rowResult("Satuan") & "','" & rowResult("Keterangan") & "','" & rowResult("Acc1") & "','" & rowResult("Acc2") & "', '" & rowResult("Acc2") & "', '" & rowResult("admin") & "', '" & Format(rowResult("transaksitime"), "yyyyMMdd") & "', '" & rowResult("urutan") & "', '" & rowResult("saran") & "')", DB_Poliklinik)
                        Next

                        ' Insert Tabel TransaksiLabDetail Online
                        For Each rowDetail As DataRow In tblLabDetail.Rows
                            If String.IsNullOrEmpty(rowDetail("transaksitime").ToString()) = True Then
                                rowDetail("transaksitime") = Convert.ToDateTime("1900-01-01")
                            End If

                            WriteThemysql("INSERT INTO transaksilabdetail(idlabinternet, translabiddetail, TransLabID,TindakanID,NamaTindakan,JenisTindakan,BiayaTindakan,DiscTindakan,NettBayar,admin,transaksitime,DiscPersenTindakan, Mesin) " & _
                                          "VALUES('" & idTransaksiOnline & "','" & rowDetail("translabiddetail") & "','" & rowDetail("translabid") & "','" & rowDetail("TindakanID") & "','" & rowDetail("NamaTindakan") & "','" & rowDetail("JenisTindakan") & "'," & CDbl(rowDetail("BiayaTindakan")) & "," & CDbl(rowDetail("DiscTindakan")) & "," & CDbl(rowDetail("NettBayar")) & ",'" & UserLabAdmin & "',now()," & CDbl(rowDetail("DiscPersenTindakan")) & ",'" & rowDetail("Mesin") & "')", DB_Poliklinik)
                        Next

                        ' Insert Tabel TransaksiLabBayar Online
                        For Each rowBayar As DataRow In tblLabBayar.Rows
                            WriteThemysql("INSERT INTO transaksilabbayar(idlabinternet, translabidbayar, translabid,jenisbayar,nojenisbayar,jumlahbayar,admin,transaksitime,kembali,mesin,kartu) " & _
                                          "VALUES('" & idTransaksiOnline & "','" & rowBayar("TransLabIDBayar") & "','" & rowBayar("TransLabID") & "','" & rowBayar("JenisBayar") & "','" & rowBayar("NoJenisBayar") & "','" & CDbl(rowBayar("JumlahBayar")) & "','" & rowBayar("admin") & "','" & rowBayar("transaksitime") & "'," & CDbl(rowBayar("Kembali")) & ",'" & rowBayar("mesin") & "','" & rowBayar("kartu") & "')", DB_Poliklinik)
                        Next

                        WriteSQL("UPDATE TransaksiLab SET UploadMesin = 1, UploadMesinDate = GETDATE() WHERE TransLabID = '" & rowTransaksi("TransLabID") & "'", 4)
                    Else
                        ' ###### UPDATE DATA ONLINE ######

                        ' Hanya Update Jika Status CETAK / TAKEIT
                        If rowTransaksi("Status").ToString.Trim = "CETAK" Or rowTransaksi("Status").ToString.Trim = "TAKEIT" Then
                            ' Get idlabinternet Online
                            Dim idTransaksiOnline As String = ReadThemysqlNIK("SELECT idlabinternet FROM transaksilab WHERE idtempatlab='" & kodePoli & "' and idpasien='" & rowTransaksi("IDInternet").ToString & "' and translabid='" & rowTransaksi("TransLabID") & "'", DB_Poliklinik)

                            ' Update Tabel TransaksiLab Online
                            WriteThemysql("UPDATE transaksilab SET saran = '" & rowTransaksi("Saran") & "', kesimpulan = '" & rowTransaksi("Kesimpulan") & "', status = '" & rowTransaksi("Status").ToString.Trim & "', labstarttime = '" & LabStartTime & "', labendtime = '" & LabEndTime & "', tglinputhasil = '" & TglInputHasil & "' WHERE idlabinternet = '" & idTransaksiOnline & "'", DB_Poliklinik)

                            ' Update Tabel TransaksiLabResult Online
                            For Each rowResult As DataRow In tblLabResult.Rows
                                If Strings.LCase(rowResult("NamaTindakan").ToString).Contains("thorax") Or Strings.LCase(rowResult("NamaTindakan").ToString).Contains("ecg") Or Strings.LCase(rowResult("NamaTindakan").ToString).Contains("audiometri") Or Strings.LCase(rowResult("NamaTindakan").ToString).Contains("fisik") Or Strings.LCase(rowResult("NamaTindakan").ToString).Contains("usg") Or Strings.LCase(rowResult("NamaTindakan").ToString).Contains("treadmill") Or Strings.LCase(rowResult("NamaTindakan").ToString).Contains("spirometri") Then
                                    WriteThemysql("UPDATE transaksilabresult SET Result = '" & rowResult("Result") & "', Keterangan = '-' WHERE idlabinternet = '" & idTransaksiOnline & "' and TransLabIDDetail='" & rowResult("TransLabIDDetail") & "' and TindakanID='" & rowResult("TindakanID") & "' and GroupID='" & rowResult("GroupID") & "' and NoUrut='" & rowResult("NoUrut") & "' and DetailKet='" & rowResult("DetailKet") & "'", DB_Poliklinik)
                                Else
                                    WriteThemysql("UPDATE transaksilabresult SET Result = '" & rowResult("Result") & "', Keterangan = '" & rowResult("Keterangan") & "', Saran = '" & rowResult("Saran") & "', Pria = '" & rowResult("Pria") & "' , Wanita = '" & rowResult("Wanita") & "', Flag = '" & rowResult("Flag") & "', Satuan = '" & rowResult("Satuan") & "', Urutan = '" & rowResult("Urutan") & "', acc1 = '" & rowResult("Acc1") & "', acc2 = '" & rowResult("Acc2") & "' where idlabinternet = '" & idTransaksiOnline & "' and TransLabIDDetail='" & rowResult("TransLabIDDetail") & "' and TindakanID='" & rowResult("TindakanID") & "' and GroupID='" & rowResult("GroupID") & "' and NoUrut='" & rowResult("NoUrut") & "' and DetailKet='" & rowResult("DetailKet") & "'", DB_Poliklinik)
                                End If
                            Next
                        End If
                    End If

                    WriteSQL("UPDATE TransaksiLab SET UploadMesin=1, UploadMesinDate=getdate() WHERE TransLabID='" & rowTransaksi("TransLabID") & "'", 4)

                    ' Update Persentase Upload
                    persentaseProgres = transaksiProcess * 100 / tblTransaksi.Rows.Count
                    TextBoxKeteranganSinkronisasi.Text = persentaseProgres & " %"
                    ProgressBarSinkronisasi.Value = persentaseProgres
                Next

                status.Text += "Proses Data telah terkirim semua. " + vbCrLf
                MsgBox("Proses Data telah terkirim semua.", MsgBoxStyle.Information, "Success!")

                Me.ButtonUpload.Enabled = True
                Me.ControlBox = True
                Me.DateTimeUpload.Enabled = True
            Else
                MsgBox("Tidak ada data yang di upload.", MsgBoxStyle.Exclamation, "Warning!")

                Me.ButtonUpload.Enabled = True
                Me.ControlBox = True
                Me.DateTimeUpload.Enabled = True
            End If
        End If
    End Sub

    Private Function GetDateValue(ByVal row As DataRow, ByVal fieldName As String) As String
        If row.IsNull(fieldName) Then
            Return "19000101"
        Else
            Return CType(row(fieldName), DateTime).ToString("yyyy-MM-dd HH:mm:ss")
        End If
    End Function

    Private Sub ButtonUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonUpload.Click
        Try
            ButtonUpload.Enabled = False

            thread = New System.Threading.Thread(AddressOf UploadData)
            thread.Start()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ToolsTransaksiLab_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        Me.MdiParent = PoliKlinik
        DateTimeUpload.Value = DateAndTime.Now
        SetConnection()
    End Sub
End Class