Public Class FormVerifikasiOmsetKapitasi
    Private UserInput As String = PoliKlinik.Lbluser.Text
    Private coaBank As String = ""
    Private locationCode As String = ""
    Private jurnalDB As String = ""

    ' Set Connection
    Private Find_Poliklinik As Find.TLconnect
    Private DB_Keuangan2 As TLcon
    Private DB_Poliklinik As TLcon
    Private DB_Jurnal As TLcon

    Private Sub SetConnectionFromConfig()
        ' Set Parameter Server Online
        Dim serverOnline_IP As String = Utility.GetConfig("ServerOnline_IP")
        Dim serverOnline_UserID As String = Utility.GetConfig("ServerOnline_UserID")
        Dim serverOnline_Password As String = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerOnline_Password"), "albert")

        ' Set Find Poliklinik
        Find_Poliklinik.Tip = serverOnline_IP
        Find_Poliklinik.Tid = serverOnline_UserID
        Find_Poliklinik.Tpass = serverOnline_Password
        Find_Poliklinik.Tdb = Utility.GetConfig("ServerOnlinePoli_DB")

        ' Set DB Poliklinik
        DB_Poliklinik.Tip = serverOnline_IP
        DB_Poliklinik.Tid = serverOnline_UserID
        DB_Poliklinik.Tpass = serverOnline_Password
        DB_Poliklinik.Tdb = Utility.GetConfig("ServerOnlinePoli_DB")

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

    Private Sub SetClear()
        txnominalrekening.ReadOnly = False
        txnominaladmin.ReadOnly = False
        txlocket.ResetText()
        locationCode = ""
        jurnalDB = ""

        cmbbulan.Items.Clear()
        cmbtahun.Items.Clear()
        loadcmbbulan()
        loadcmbyear()
        cmbbulan.SelectedIndex = -1
        cmbtahun.SelectedIndex = -1
        cmbbank.SelectedIndex = -1
        coaBank = ""
        txharga2.ResetText()
        txharga1.ResetText()

        'Set
        txjumlahpasien.ResetText()
        txjumlahpasien.ResetText()
        txbulan.Text = "Bulan"
        rdbpjs.Checked = True
        rdklinik.Checked = True

        rdcob.Enabled = False
        rdnoncob.Enabled = False
        rdcob.Checked = True

        txstatusket.Visible = False
        butsavelab.Enabled = True

        txnominaladmin.ResetText()
        txnominalrekening.ResetText()
        btnview.Enabled = True
    End Sub

    Private Sub loadcmbbulan()
        cmbbulan.Items.Add("Januari")
        cmbbulan.Items.Add("Februari")
        cmbbulan.Items.Add("Maret")
        cmbbulan.Items.Add("April")
        cmbbulan.Items.Add("Mei")
        cmbbulan.Items.Add("Juni")
        cmbbulan.Items.Add("Juli")
        cmbbulan.Items.Add("Agustus")
        cmbbulan.Items.Add("September")
        cmbbulan.Items.Add("Oktober")
        cmbbulan.Items.Add("November")
        cmbbulan.Items.Add("Desember")
        cmbbulan.SelectedIndex = 0
    End Sub

    Private Sub loadcmbyear()
        Dim vartahun As Integer = Date.Today.Year
        cmbtahun.Items.Add(vartahun)
        cmbtahun.Items.Add(vartahun - 1)
        cmbtahun.Items.Add(vartahun - 2)
        cmbtahun.Items.Add(vartahun - 3)
        cmbtahun.Items.Add(vartahun - 4)
        cmbtahun.SelectedIndex = 0
    End Sub

    Private Sub GridRujukan()
        Dim Tbls As DataTable = ReadSQL("select b.NamaTindakan, b.JenisTindakan, b.BiayaTindakan, a.HargaRujukan from MasterHargaTindakanRujukan a left join MasterLab b on a.TindakanID=b.TindakanID")
        Tbls.Rows.Clear()
        gridtindakan.DataSource = Tbls
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        SetClear()

        ' Inisialisasi koneksi ke database MySQL
        SetConnectionFromConfig()

        SetBank()
        cmbbank.Enabled = True
        'GridRujukan()
    End Sub

    Private Sub FormApproveKapitasi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        NewToolStripMenuItem.PerformClick()
    End Sub

    Function Checking() As Boolean
        'Cek Jumlah Pasien
        If txjumlahpasien.Text = "0" Or txjumlahpasien.Text = "" Then
            MsgBox("Jumlah pasien tidak boleh kosong.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        If txnominalrekening.Text = "0" Or txnominalrekening.Text = "" Then
            MsgBox("Masukkan nominal rekening terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        'If CDbl(txnominalrekening.Text) > CDbl(txgrandtotalbulanberjalan.Text) Then
        '    MsgBox("Nominal rekening tidak boleh lebih besar dibandingkan dengan grand total.", MsgBoxStyle.Exclamation, "Warning!")
        '    Return False
        'End If

        If coaBank = "" Then
            MsgBox("Pilih bank transfer terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        Return True
    End Function

    Function CheckingView() As Boolean
        'Cek Bulan & Tahun
        If cmbbulan.Text = "" Or cmbtahun.Text = "" Then
            MsgBox("Bulan & Tahun tidak boleh kosong.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        'Cek Lokasi
        If locationCode = "" Then
            MsgBox("Lokasi cabang tidak boleh kosong.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        Dim bulan As String = Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(cmbbulan.Text, "Januari", "01"), "Februari", "02"), "Maret", "03"), "April", "04"), "Mei", "05"), "Juni", "06"), "Juli", "07"), "Agustus", "08"), "September", "09"), "Oktober", "10"), "November", "11"), "Desember", "12")
        Dim tahun As String = cmbtahun.Text
        Dim datekapitasi As DateTime = New DateTime(tahun, bulan, 1)
        Dim jeniskapitasi As String = ""
        Dim jenislokasi As String = ""

        If rdbpjs.Checked = True Then
            jeniskapitasi = rdbpjs.Text
        ElseIf rdinhealth.Checked = True Then
            jeniskapitasi = rdinhealth.Text
        End If

        If rdklinik.Checked = True Then
            jenislokasi = rdklinik.Text
        ElseIf rdlab.Checked = True Then
            jenislokasi = rdlab.Text
        End If

        '==========================================================

        'Cek Data
        If rdbpjs.Checked = True Then
            If CheckThemysql("SELECT * FROM transaksikapitasi a WHERE a.cabang = '" & locationCode & "' AND a.jenislokasi = '" & jenislokasi & "' AND a.jeniskapitasi = '" & jeniskapitasi & "' AND a.bulan = '" & datekapitasi.Month & "' AND a.tahun = '" & datekapitasi.Year & "'", DB_Poliklinik) = False Then
                MsgBox("Kapitasi di bulan " & cmbbulan.Text & " tahun " & cmbtahun.Text & " belum di input.", MsgBoxStyle.Exclamation, "Warning!")
                Return False
            End If
        ElseIf rdinhealth.Checked = True Then
            If rdcob.Checked = True Then
                If CheckThemysql("SELECT * FROM transaksikapitasi a WHERE a.cabang = '" & locationCode & "' AND a.jenislokasi = '" & jenislokasi & "' AND a.jeniskapitasi = '" & jeniskapitasi & "' AND a.bulan = '" & datekapitasi.Month & "' AND a.tahun = '" & datekapitasi.Year & "' AND a.flagcob1 IS NOT NULL", DB_Poliklinik) = False Then
                    MsgBox("Kapitasi di bulan " & cmbbulan.Text & " tahun " & cmbtahun.Text & " belum di input.", MsgBoxStyle.Exclamation, "Warning!")
                    Return False
                End If
            ElseIf rdnoncob.Checked = True Then
                If CheckThemysql("SELECT * FROM transaksikapitasi a WHERE a.cabang = '" & locationCode & "' AND a.jenislokasi = '" & jenislokasi & "' AND a.jeniskapitasi = '" & jeniskapitasi & "' AND a.bulan = '" & datekapitasi.Month & "' AND a.tahun = '" & datekapitasi.Year & "' AND a.flagnoncob1 IS NOT NULL", DB_Poliklinik) = False Then
                    MsgBox("Kapitasi di bulan " & cmbbulan.Text & " tahun " & cmbtahun.Text & " belum di input.", MsgBoxStyle.Exclamation, "Warning!")
                    Return False
                End If
            End If
        End If

        Return True
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Find.Show()
        Find.QueryTheMysql("SELECT a.kodebarcode AS 'ID', a.kodecabang, a.kodeket, a.db_gl FROM mastercodebarcode a WHERE a.db_gl <> '' ", " ORDER BY ID ASC", "FindCabangAccKapitasi", 1, Find_Poliklinik)
    End Sub

    Private Sub btnview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnview.Click
        If CheckingView() = True Then
            'inisialisasi
            Dim bulan As String = Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(cmbbulan.Text, "Januari", "01"), "Februari", "02"), "Maret", "03"), "April", "04"), "Mei", "05"), "Juni", "06"), "Juli", "07"), "Agustus", "08"), "September", "09"), "Oktober", "10"), "November", "11"), "Desember", "12")
            Dim tahun As String = cmbtahun.Text
            Dim datekapitasi As DateTime = New DateTime(tahun, bulan, 1)

            Dim jeniskapitasi As String = ""
            Dim jenislokasi As String = ""
            Dim textjenis As String = ""

            Dim Tlokasi As DataTable = New DataTable
            If rdklinik.Checked = True Then
                jenislokasi = rdklinik.Text
            ElseIf rdlab.Checked = True Then
                jenislokasi = rdlab.Text
            End If

            'Search Harga
            Dim Tkapitasi As DataTable = New DataTable

            If rdbpjs.Checked = True Then
                jeniskapitasi = rdbpjs.Text

                Tkapitasi = ReadThemysql("SELECT * FROM transaksikapitasi a WHERE a.cabang = '" & locationCode & "' AND a.jenislokasi = '" & jenislokasi & "' AND a.jeniskapitasi = '" & jeniskapitasi & "' AND a.bulan = '" & datekapitasi.Month & "' AND a.tahun = '" & datekapitasi.Year & "'", DB_Poliklinik)
            ElseIf rdinhealth.Checked = True Then
                jeniskapitasi = rdinhealth.Text

                Tkapitasi = ReadThemysql("SELECT * FROM transaksikapitasi a WHERE a.cabang = '" & locationCode & "' AND a.jenislokasi = '" & jenislokasi & "' AND a.jeniskapitasi = '" & jeniskapitasi & "' AND a.bulan = '" & datekapitasi.Month & "' AND a.tahun = '" & datekapitasi.Year & "'", DB_Poliklinik)

                If rdcob.Checked = True Then
                    textjenis = "cob"
                Else
                    textjenis = "noncob"
                End If
            End If

            Dim TrowKapitasi As DataRow = Tkapitasi.Rows(0)

            'Set Bulan Text
            txbulan.Text = BulanIndonesia(Format(datekapitasi, "MM")).ToString & " " & datekapitasi.Year

            'Set Harga Master
            If rdbpjs.Checked = True Then
                txharga1.Text = Splitmoney(CDbl(TrowKapitasi("hargaumum").ToString))
                txharga2.Text = Splitmoney(CDbl(TrowKapitasi("hargagigi").ToString))
                txjumlahpasien.Text = TrowKapitasi("jumlahpasien").ToString
            ElseIf rdinhealth.Checked = True Then
                If rdcob.Checked = True Then
                    txharga1.Text = Splitmoney(CDbl(TrowKapitasi("hargacob").ToString))
                    txjumlahpasien.Text = TrowKapitasi("jumlahpasiencob").ToString
                Else
                    txharga1.Text = Splitmoney(CDbl(TrowKapitasi("harganoncob").ToString))
                    txjumlahpasien.Text = TrowKapitasi("jumlahpasiennoncob").ToString
                End If
            End If

            txstatusket.Visible = True

            If TrowKapitasi("statusupload" & textjenis & "") = 1 Then
                txstatusket.Text = "SUDAH APPROVE"
                txstatusket.BackColor = System.Drawing.Color.Green
                butsavelab.Enabled = False

                dttransfer.Value = TrowKapitasi("transferdate" & textjenis & "").ToString
                txnominalrekening.Text = Splitmoney(CDbl(TrowKapitasi("nominalrekening" & textjenis & "").ToString))
                txnominaladmin.Text = Splitmoney(CDbl(TrowKapitasi("nominaladmin" & textjenis & "").ToString))
                txnominalrekening.ReadOnly = True
                txnominaladmin.ReadOnly = True

                btnview.Enabled = False
            Else
                txstatusket.Text = "BELUM APPROVE"
                txstatusket.BackColor = System.Drawing.Color.Tomato
                btnview.Enabled = False
            End If
        End If
    End Sub

    Private Sub SetTotal()
        Dim GrandTotalUmum As Double = 0
        Dim GrandTotalGigi As Double = 0
        Dim GrandTotalSelisih As Double = 0

        ' Set total harga 1
        If txjumlahpasien.Text <> "" And txharga1.Text <> "" Then
            GrandTotalUmum = Splitmoney(CDbl(txjumlahpasien.Text * txharga1.Text))

            txtotal1.Text = Splitmoney(GrandTotalUmum)
        Else
            txtotal1.ResetText()
        End If

        ' Set total harga 2
        If txjumlahpasien.Text <> "" And txharga2.Text <> "" Then
            GrandTotalGigi = Splitmoney(CDbl(txjumlahpasien.Text * txharga2.Text))

            txtotal2.Text = Splitmoney(GrandTotalGigi)
        Else
            txtotal2.ResetText()
        End If

        ' Set grand total
        If GrandTotalUmum <> 0 Or GrandTotalGigi <> 0 Then
            txgrandtotalbulanberjalan.Text = Splitmoney(CDbl(GrandTotalUmum + GrandTotalGigi))
        Else
            txgrandtotalbulanberjalan.ResetText()
        End If

        ' Set GrandTotalSelisih
        If txnominalrekening.Text <> "" And txnominalrekening.Text <> "0" And txgrandtotalbulanberjalan.Text <> "" Then
            If CDbl(txnominalrekening.Text) > CDbl(txgrandtotalbulanberjalan.Text) Then
                GrandTotalSelisih = Splitmoney(CDbl(txnominalrekening.Text) - CDbl(txgrandtotalbulanberjalan.Text))
            ElseIf CDbl(txgrandtotalbulanberjalan.Text) > CDbl(txnominalrekening.Text) Then
                GrandTotalSelisih = Splitmoney(CDbl(txgrandtotalbulanberjalan.Text) - CDbl(txnominalrekening.Text))
            End If
        Else
            GrandTotalSelisih = 0
        End If

        ' Set GrandTotalSelisih - biaya admin
        If txnominaladmin.Text <> "" And txnominaladmin.Text <> "0" And txgrandtotalbulanberjalan.Text <> "" Then
            If CDbl(txnominalrekening.Text) > CDbl(txgrandtotalbulanberjalan.Text) Then
                GrandTotalSelisih = Splitmoney(CDbl(GrandTotalSelisih) + CDbl(txnominaladmin.Text))
            ElseIf CDbl(txgrandtotalbulanberjalan.Text) > CDbl(txnominalrekening.Text) Then
                GrandTotalSelisih = Splitmoney(CDbl(GrandTotalSelisih) - CDbl(txnominaladmin.Text))
            End If
        Else
            txnominaladmin.Text = "0"
        End If

        txnominalselisih.Text = Splitmoney(GrandTotalSelisih)
    End Sub

    Private Sub txjumlahpasien_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txjumlahpasien.TextChanged
        SetTotal()
    End Sub

    Private Sub txjumlahpasien_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txjumlahpasien.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub butsavelab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butsavelab.Click
        If Checking() = True Then
            Dim bulan As String = Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(cmbbulan.Text, "Januari", "01"), "Februari", "02"), "Maret", "03"), "April", "04"), "Mei", "05"), "Juni", "06"), "Juli", "07"), "Agustus", "08"), "September", "09"), "Oktober", "10"), "November", "11"), "Desember", "12")
            Dim tahun As String = cmbtahun.Text
            Dim datekapitasi As DateTime = New DateTime(tahun, bulan, 1)

            Dim jeniskapitasi As String = ""
            Dim jenislokasi As String = ""
            Dim salesoffice As String = ""


            Dim Tlokasi As DataTable = New DataTable
            If rdklinik.Checked = True Then
                jenislokasi = rdklinik.Text
            ElseIf rdlab.Checked = True Then
                jenislokasi = rdlab.Text
            End If

            If rdbpjs.Checked = True Then
                jeniskapitasi = rdbpjs.Text

                WriteThemysql("update transaksikapitasi a set coabank = '" & coaBank & "', transferdate = '" & Format(dttransfer.Value, "yyyyMMdd") & "', statusupload = TRUE, uploaddate = NOW(), uploadby = '" & UserInput & "', nominalrekening = '" & CDbl(txnominalrekening.Text) & "', nominaladmin = '" & CDbl(txnominaladmin.Text) & "', nominalselisih = '" & CDbl(txnominalselisih.Text) & "' WHERE a.cabang = '" & locationCode & "' AND a.jenislokasi = '" & jenislokasi & "' AND a.jeniskapitasi = '" & jeniskapitasi & "' AND a.bulan = '" & datekapitasi.Month & "' AND a.tahun = '" & datekapitasi.Year & "'", DB_Poliklinik)
            ElseIf rdinhealth.Checked = True Then
                jeniskapitasi = rdinhealth.Text

                If rdcob.Checked = True Then
                    WriteThemysql("update transaksikapitasi a set coabankcob = '" & coaBank & "', transferdatecob = '" & Format(dttransfer.Value, "yyyyMMdd") & "', statusuploadcob = TRUE, uploaddate = NOW(), uploadby = '" & UserInput & "', nominalrekeningcob = '" & CDbl(txnominalrekening.Text) & "', nominaladmincob = '" & CDbl(txnominaladmin.Text) & "', nominalselisihcob = '" & CDbl(txnominalselisih.Text) & "' WHERE a.cabang = '" & locationCode & "' AND a.jenislokasi = '" & jenislokasi & "' AND a.jeniskapitasi = '" & jeniskapitasi & "' AND a.bulan = '" & datekapitasi.Month & "' AND a.tahun = '" & datekapitasi.Year & "'", DB_Poliklinik)
                ElseIf rdnoncob.Checked = True Then
                    WriteThemysql("update transaksikapitasi a set coabanknoncob = '" & coaBank & "', transferdatenoncob = '" & Format(dttransfer.Value, "yyyyMMdd") & "', statusuploadnoncob = TRUE, uploaddate = NOW(), uploadby = '" & UserInput & "', nominalrekeningnoncob = '" & CDbl(txnominalrekening.Text) & "', nominaladminnoncob = '" & CDbl(txnominaladmin.Text) & "', nominalselisihnoncob = '" & CDbl(txnominalselisih.Text) & "' WHERE a.cabang = '" & locationCode & "' AND a.jenislokasi = '" & jenislokasi & "' AND a.jeniskapitasi = '" & jeniskapitasi & "' AND a.bulan = '" & datekapitasi.Month & "' AND a.tahun = '" & datekapitasi.Year & "'", DB_Poliklinik)
                End If
            End If

            sendjurnal()

            MsgBox("Berhasil menyimpan data.", MsgBoxStyle.Information, "Success!")
            butsavelab.Enabled = False
        End If
    End Sub

    Private Sub sendjurnal()
        Dim bulan As String = Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(cmbbulan.Text, "Januari", "01"), "Februari", "02"), "Maret", "03"), "April", "04"), "Mei", "05"), "Juni", "06"), "Juli", "07"), "Agustus", "08"), "September", "09"), "Oktober", "10"), "November", "11"), "Desember", "12")
        Dim tahun As String = cmbtahun.Text
        Dim datekapitasi As DateTime = New DateTime(tahun, bulan, 1)

        'Set Jurnal
        Dim textflag As String = ""
        Dim textket As String = ""
        Dim LogJurnal As String = ""
        Dim bsa As String = ""
        Dim flag As String = ""
        Dim Nourut As String = ""
        Dim KeteranganGL As String = ""
        Dim KeteranganBiayaAdmin As String = ""
        Dim KeteranganSelisih As String = ""
        Dim jeniskapitasi As String = ""
        Dim jenislokasi As String = ""
        Dim CoaKapitasiBPJS As String = "11020200"
        Dim CoaKapitasiInHealth As String = "11020300"
        Dim CoaBiayaAdmin As String = "71010202"
        Dim CoaSelisihBPJS As String = "42010500"
        Dim CoaSelisihInHealth As String = "42011200"
        Dim jenisJurnalSelisih As String = ""
        Dim urutanJurnal As Integer = 0

        If rdbpjs.Checked = True Then
            jeniskapitasi = rdbpjs.Text
        ElseIf rdinhealth.Checked = True Then
            jeniskapitasi = rdinhealth.Text
        End If

        Dim Tlokasi As DataTable = New DataTable
        If rdklinik.Checked = True Then
            jenislokasi = rdklinik.Text
            Tlokasi = ReadThemysql("SELECT * FROM masterlokasigl a WHERE a.loc = '" & locationCode & "' AND a.jenistransaksi = 'POLI'", DB_Keuangan2)
        ElseIf rdlab.Checked = True Then
            jenislokasi = rdlab.Text
            Tlokasi = ReadThemysql("SELECT * FROM masterlokasigl a WHERE a.loc = '" & locationCode & "' AND a.jenistransaksi = 'LAB'", DB_Keuangan2)
        End If

        Dim TrowLokasi As DataRow = Tlokasi.Rows(0)

        'Set no urut flag
        If rdbpjs.Checked = True Then
            textflag = "KPT2"
            Nourut = ReadThemysqlNIK("SELECT concat(lpad(RIGHT(a.flag2,5)+1,5,0)) FROM transaksikapitasi a WHERE a.flag2 LIKE '%" & Format(datekapitasi, "yyyy") & Format(datekapitasi, "MM") & textflag & "%' ORDER BY a.flag2 DESC LIMIT 1", DB_Poliklinik)
        ElseIf rdinhealth.Checked = True Then
            If rdcob.Checked = True Then
                textflag = "KPT5"
                textket = "COB"
                Nourut = ReadThemysqlNIK("SELECT concat(lpad(RIGHT(a.flagcob2,5)+1,5,0)) FROM transaksikapitasi a WHERE a.flagcob2 LIKE '%" & Format(datekapitasi, "yyyy") & Format(datekapitasi, "MM") & textflag & "%' ORDER BY a.flagcob2 DESC LIMIT 1", DB_Poliklinik)
            ElseIf rdnoncob.Checked = True Then
                textflag = "KPT6"
                textket = "NON COB"
                Nourut = ReadThemysqlNIK("SELECT concat(lpad(RIGHT(a.flagnoncob2,5)+1,5,0)) FROM transaksikapitasi a WHERE a.flagnoncob2 LIKE '%" & Format(datekapitasi, "yyyy") & Format(datekapitasi, "MM") & textflag & "%' ORDER BY a.flagnoncob2 DESC LIMIT 1", DB_Poliklinik)
            End If
        End If

        If IsDBNull(Nourut) = False And Nourut <> "" And Nourut <> "-" Then
            flag = Format(datekapitasi, "yyyy") & Format(datekapitasi, "MM") & textflag & Nourut.Trim
        Else
            flag = Format(datekapitasi, "yyyy") & Format(datekapitasi, "MM") & textflag & "00001"
        End If

        'Set bsa
        Dim Tdetaillokasi() As String = TrowLokasi("locket").ToString.Split("(")
        bsa = TrowLokasi("locgl")

        'Set Keterangan
        KeteranganGL = "TERIMA - KAPITASI " & jeniskapitasi.ToString.ToUpper & " " & textket & " " & Tdetaillokasi(0).ToString & " " & cmbbulan.Text.ToUpper & " " & cmbtahun.Text
        KeteranganBiayaAdmin = "BIAYA ADMIN KAPITASI " & jeniskapitasi.ToString.ToUpper & " " & textket & " " & Tdetaillokasi(0).ToString & " " & cmbbulan.Text.ToUpper & " " & cmbtahun.Text
        KeteranganSelisih = "SELISIH KAPITASI " & jeniskapitasi.ToString.ToUpper & " " & textket & " " & Tdetaillokasi(0).ToString & " " & cmbbulan.Text.ToUpper & " " & cmbtahun.Text

        ' Set status D/K selisih biaya
        If CDbl(txnominalrekening.Text) > CDbl(txgrandtotalbulanberjalan.Text) Then
            jenisJurnalSelisih = "K"
        ElseIf CDbl(txgrandtotalbulanberjalan.Text) > CDbl(txnominalrekening.Text) Then
            jenisJurnalSelisih = "D"
        End If

        ' Set database jurnal
        DB_Jurnal.Tdb = jurnalDB

        ' Create jurnal
        If rdbpjs.Checked = True Then
            urutanJurnal += 1 ' Increament jurnal
            WriteThemysql("SELECT F_MakeBKM('" & flag & "', 'out', '', '" & Format(dttransfer.Value, "yyyyMMdd") & "', '" & coaBank & "', '" & CoaKapitasiBPJS & "', 'IDR', 1, " & CDbl(txgrandtotalbulanberjalan.Text) & ", '" & KeteranganGL.ToUpper() & "', '1', " & urutanJurnal & ", '', '" & KeteranganGL.ToUpper() & "', '', '', '" & bsa & "', 4, " & CDbl(txgrandtotalbulanberjalan.Text) & ", 'K')", DB_Jurnal)

            LogJurnal = ReadThemysqlNIK("SELECT a.kas as a FROM kas a WHERE a.oms='" & flag & "'", DB_Jurnal)

            ' Jurnal selisih biaya
            If txnominalselisih.Text <> "" And txnominalselisih.Text <> "0" Then
                urutanJurnal += 1 ' Increament jurnal
                WriteThemysql("SELECT F_MakeBKM('" & flag & "', 'out', '" & LogJurnal & "', '" & Format(dttransfer.Value, "yyyyMMdd") & "', '" & CoaKapitasiBPJS & "', '" & CoaSelisihBPJS & "', 'IDR', 1, " & CDbl(txnominalselisih.Text) & ", '" & KeteranganSelisih.ToUpper() & "', '1', " & urutanJurnal & ", '', '" & KeteranganBiayaAdmin.ToUpper() & "', '', '', '" & bsa & "', 4, " & CDbl(txnominalselisih.Text) & ", '" & jenisJurnalSelisih & "')", DB_Jurnal)
            End If

            ' Jurnal biaya admin
            If txnominaladmin.Text <> "" And txnominaladmin.Text <> "0" Then
                urutanJurnal += 1 ' Increament jurnal
                WriteThemysql("SELECT F_MakeBKM('" & flag & "', 'out', '" & LogJurnal & "', '" & Format(dttransfer.Value, "yyyyMMdd") & "', '" & CoaKapitasiBPJS & "', '" & CoaBiayaAdmin & "', 'IDR', 1, " & CDbl(txnominaladmin.Text) & ", '" & KeteranganBiayaAdmin.ToUpper() & "', '1', " & urutanJurnal & ", '', '" & KeteranganBiayaAdmin.ToUpper() & "', '', '', '" & bsa & "', 4, " & CDbl(txnominaladmin.Text) & ", 'D')", DB_Jurnal)
            End If

            WriteThemysql("update transaksikapitasi a set flag2 = '" & flag & "' WHERE a.cabang = '" & locationCode & "' AND a.jenislokasi = '" & jenislokasi & "' AND a.jeniskapitasi = '" & jeniskapitasi & "' AND a.bulan = '" & datekapitasi.Month & "' AND a.tahun = '" & datekapitasi.Year & "'", DB_Poliklinik)
        Else
            urutanJurnal += 1 ' Increament jurnal
            WriteThemysql("SELECT F_MakeBKM('" & flag & "', 'out', '', '" & Format(dttransfer.Value, "yyyyMMdd") & "', '" & coaBank & "', '" & CoaKapitasiInHealth & "', 'IDR', 1, " & CDbl(txgrandtotalbulanberjalan.Text) & ", '" & KeteranganGL.ToUpper() & "', '1', " & urutanJurnal & ", '', '" & KeteranganGL.ToUpper() & "', '', '', '" & bsa & "', 4, " & CDbl(txgrandtotalbulanberjalan.Text) & ", 'K')", DB_Jurnal)

            LogJurnal = ReadThemysqlNIK("SELECT a.kas as a FROM kas a WHERE a.oms='" & flag & "'", DB_Jurnal)

            ' Jurnal selisih biaya
            If txnominalselisih.Text <> "" And txnominalselisih.Text <> "0" Then
                urutanJurnal += 1 ' Increament jurnal
                WriteThemysql("SELECT F_MakeBKM('" & flag & "', 'out', '" & LogJurnal & "', '" & Format(dttransfer.Value, "yyyyMMdd") & "', '" & CoaKapitasiInHealth & "', '" & CoaSelisihInHealth & "', 'IDR', 1, " & CDbl(txnominalselisih.Text) & ", '" & KeteranganSelisih.ToUpper() & "', '1', " & urutanJurnal & ", '', '" & KeteranganBiayaAdmin.ToUpper() & "', '', '', '" & bsa & "', 4, " & CDbl(txnominalselisih.Text) & ", '" & jenisJurnalSelisih & "')", DB_Jurnal)
            End If

            ' Jurnal biaya admin
            If txnominaladmin.Text <> "" And txnominaladmin.Text <> "0" Then
                urutanJurnal += 1 ' Increament jurnal
                WriteThemysql("SELECT F_MakeBKM('" & flag & "', 'out', '" & LogJurnal & "', '" & Format(dttransfer.Value, "yyyyMMdd") & "', '" & CoaKapitasiBPJS & "', '" & CoaBiayaAdmin & "', 'IDR', 1, " & CDbl(txnominaladmin.Text) & ", '" & KeteranganBiayaAdmin.ToUpper() & "', '1', " & urutanJurnal & ", '', '" & KeteranganBiayaAdmin.ToUpper() & "', '', '', '" & bsa & "', 4, " & CDbl(txnominaladmin.Text) & ", 'D')", DB_Jurnal)
            End If

            If rdcob.Checked = True Then
                WriteThemysql("update transaksikapitasi a set flagcob2 = '" & flag & "' WHERE a.cabang = '" & locationCode & "' AND a.jenislokasi = '" & jenislokasi & "' AND a.jeniskapitasi = '" & jeniskapitasi & "' AND a.bulan = '" & datekapitasi.Month & "' AND a.tahun = '" & datekapitasi.Year & "'", DB_Poliklinik)
            ElseIf rdnoncob.Checked = True Then
                WriteThemysql("update transaksikapitasi a set flagnoncob2 = '" & flag & "' WHERE a.cabang = '" & locationCode & "' AND a.jenislokasi = '" & jenislokasi & "' AND a.jeniskapitasi = '" & jeniskapitasi & "' AND a.bulan = '" & datekapitasi.Month & "' AND a.tahun = '" & datekapitasi.Year & "'", DB_Poliklinik)
            End If
        End If
    End Sub

    Private Sub txnominalrekening_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txnominalrekening.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub txnominaladmin_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txnominaladmin.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub txnominalrekening_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txnominalrekening.TextChanged
        SetTotal()
    End Sub

    Private Sub txnominaladmin_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txnominaladmin.TextChanged
        SetTotal()
    End Sub

    Private Sub CheckBank()
        If cmbbank.Text = "" Then
            cmbbank.Enabled = False
        Else
            If cmbbank.FindStringExact(cmbbank.Text) >= 0 Then
                Dim Tsplit() As String = cmbbank.Text.Split("-")
                Dim Tbls As DataTable = ReadThemysql("SELECT * FROM accmasterbank where namabank='" & Tsplit(0).ToString & "'", DB_Keuangan2)
                If Tbls.Rows.Count > 0 Then
                    Dim Rrow As DataRow = Tbls.Rows(0)
                    coaBank = Rrow("coa")
                End If
            End If
        End If
    End Sub

    Private Sub SetBank()
        Dim Tbls As DataTable = ReadThemysql("SELECT CONCAT(namabank,'-',norekening) AS Bank FROM accmasterbank WHERE bankpembayarantagihan IS TRUE AND coa IS NOT NULL AND (coa <> '' OR coa <> '-')", DB_Keuangan2)
        cmbbank.Items.Clear()
        For Each Trow As DataRow In Tbls.Rows
            cmbbank.Items.Add(Trow("Bank").ToString)
        Next

        cmbbank.SelectedIndex = -1
        CheckBank()
    End Sub

    Private Sub cmbbank_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbbank.SelectedIndexChanged
        If cmbbank.FindStringExact(cmbbank.Text) >= 0 Then
            CheckBank()
        End If
    End Sub

    Private Sub rdbpjs_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdbpjs.CheckedChanged
        If rdbpjs.Checked = True Then
            rdcob.Enabled = False
            rdnoncob.Enabled = False
        ElseIf rdinhealth.Checked = True Then
            rdcob.Enabled = True
            rdnoncob.Enabled = True
        End If
    End Sub

    Private Sub rdinhealth_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdinhealth.CheckedChanged
        If rdbpjs.Checked = True Then
            rdcob.Enabled = False
            rdnoncob.Enabled = False
        ElseIf rdinhealth.Checked = True Then
            rdcob.Enabled = True
            rdnoncob.Enabled = True
        End If
    End Sub

    Public Sub SetLokasi(ByRef txID As String, ByRef txKeterangan As String, ByRef txDatabase As String)
        locationCode = txID
        txlocket.Text = txKeterangan
        jurnalDB = txDatabase
    End Sub
End Class