Public Class FormSendKapitasiBPJS
    Private UserInput As String = PoliKlinik.Lbluser.Text

    ' Set Connection
    Private DB_Poliklinik As TLcon
    Private DB_Keuangan2 As TLcon
    Private DB_Jurnal As TLcon

    Private Sub SetConnectionFromConfig()
        ' Set Parameter Server Online
        Dim serverOnline_IP As String = Utility.GetConfig("ServerOnline_IP")
        Dim serverOnline_UserID As String = Utility.GetConfig("ServerOnline_UserID")
        Dim serverOnline_Password As String = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerOnline_Password"), "albert")

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
        txlocket.ResetText()
        txlocid.ResetText()

        cmbbulan.Items.Clear()
        cmbtahun.Items.Clear()
        loadcmbbulan()
        loadcmbyear()
        cmbbulan.SelectedIndex = -1
        cmbtahun.SelectedIndex = -1
        butsavelab.Enabled = True
        rdbpjs.Checked = True
        rdklinik.Checked = True

        rdcob.Enabled = False
        rdnoncob.Enabled = False
        rdcob.Checked = True

        'Set
        txjumlahpasien.ResetText()
        txjumlahpasien.ResetText()

        txlocid.Text = ReadSQLNIK("select StrValue from MsConfig where ConfigName='NoPoli'")
        txlocket.Text = ReadSQLNIK("select StrValue from MsConfig where ConfigName='NamaPoli'")
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
    End Sub

    Private Sub FormSendKapitasiBPJS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        NewToolStripMenuItem.PerformClick()
    End Sub

    Function Checking() As Boolean
        'Cek Bulan & Tahun  
        If cmbbulan.Text = "" Or cmbtahun.Text = "" Then
            MsgBox("Bulan & Tahun tidak boleh kosong.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        'Cek Jumlah Pasien
        If txjumlahpasien.Text = "0" Or txjumlahpasien.Text = "" Then
            MsgBox("Jumlah pasien tidak boleh kosong.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        If CDbl(txjumlahpasien.Text) <= 0 Then
            MsgBox("Jumlah pasien harus lebih dari 0.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        If rdbpjs.Checked = False And rdinhealth.Checked = False Then
            MsgBox("Pilih jenis kapitasi terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        If rdklinik.Checked = False And rdlab.Checked = False Then
            MsgBox("Pilih jenis lokasi terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        'inisialisasi
        Dim bulan As String = Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(cmbbulan.Text, "Januari", "01"), "Februari", "02"), "Maret", "03"), "April", "04"), "Mei", "05"), "Juni", "06"), "Juli", "07"), "Agustus", "08"), "September", "09"), "Oktober", "10"), "November", "11"), "Desember", "12")
        Dim tahun As String = cmbtahun.Text
        Dim datekapitasi As DateTime = New DateTime(tahun, bulan, 1)
        Dim nextdate As DateTime = DateAdd(DateInterval.Month, +1, DateAndTime.Now)
        Dim datenextkapitasi As DateTime = New DateTime(nextdate.Year, nextdate.Month, 1)

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

        Dim Tharga As DataTable = ReadThemysql("SELECT * FROM masterkapitasi a WHERE a.cabang = '" & txlocid.Text & "' AND a.jenislokasi = '" & jenislokasi & "' AND a.jeniskapitasi = '" & jeniskapitasi & "' AND a.bulan = '" & datekapitasi.Month & "' AND a.tahun = '" & datekapitasi.Year & "'", DB_Poliklinik)

        If CheckThemysql("SELECT * FROM masterkapitasi a WHERE a.cabang = '" & txlocid.Text & "' AND a.jenislokasi = '" & jenislokasi & "' AND a.jeniskapitasi = '" & jeniskapitasi & "' AND a.bulan = '" & datekapitasi.Month & "' AND a.tahun = '" & datekapitasi.Year & "'", DB_Poliklinik) = False Then
            MsgBox("Input master kapitasi di bulan " & cmbbulan.Text & " tahun " & cmbtahun.Text & " terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        If rdbpjs.Checked = True Then
            If CheckThemysql("SELECT * FROM transaksikapitasi a WHERE a.cabang = '" & txlocid.Text & "' AND a.jenislokasi = '" & jenislokasi & "' AND a.jeniskapitasi = '" & jeniskapitasi & "' AND a.bulan = '" & datekapitasi.Month & "' AND a.tahun = '" & datekapitasi.Year & "'", DB_Poliklinik) = True Then
                MsgBox("Data bulan " & cmbbulan.Text & " tahun " & cmbtahun.Text & " sudah pernah diinput.", MsgBoxStyle.Exclamation, "Warning!")
                Return False
            End If
        Else
            If rdcob.Checked = True Then
                If CheckThemysql("SELECT * FROM transaksikapitasi a WHERE a.cabang = '" & txlocid.Text & "' AND a.jenislokasi = '" & jenislokasi & "' AND a.jeniskapitasi = '" & jeniskapitasi & "' AND a.bulan = '" & datekapitasi.Month & "' AND a.tahun = '" & datekapitasi.Year & "' AND a.flagcob1 IS NOT NULL", DB_Poliklinik) = True Then
                    MsgBox("Data bulan " & cmbbulan.Text & " tahun " & cmbtahun.Text & " sudah pernah diinput.", MsgBoxStyle.Exclamation, "Warning!")
                    Return False
                End If
            ElseIf rdnoncob.Checked = True Then
                If CheckThemysql("SELECT * FROM transaksikapitasi a WHERE a.cabang = '" & txlocid.Text & "' AND a.jenislokasi = '" & jenislokasi & "' AND a.jeniskapitasi = '" & jeniskapitasi & "' AND a.bulan = '" & datekapitasi.Month & "' AND a.tahun = '" & datekapitasi.Year & "' AND a.flagnoncob1 IS NOT NULL", DB_Poliklinik) = True Then
                    MsgBox("Data bulan " & cmbbulan.Text & " tahun " & cmbtahun.Text & " sudah pernah diinput.", MsgBoxStyle.Exclamation, "Warning!")
                    Return False
                End If
            End If
        End If

        If datekapitasi >= datenextkapitasi Then
            MsgBox("Input tidak boleh melebihi bulan " & cmbbulan.Text & " tahun " & cmbtahun.Text & ".", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        Return True
    End Function

    Private Sub butsavelab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butsavelab.Click
        If Checking() = True Then
            Dim bulan As String = Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(cmbbulan.Text, "Januari", "01"), "Februari", "02"), "Maret", "03"), "April", "04"), "Mei", "05"), "Juni", "06"), "Juli", "07"), "Agustus", "08"), "September", "09"), "Oktober", "10"), "November", "11"), "Desember", "12")
            Dim tahun As String = cmbtahun.Text
            Dim datekapitasi As DateTime = New DateTime(tahun, bulan, 1)

            Dim jeniskapitasi As String = ""
            Dim jenislokasi As String = ""

            Dim Tlokasi As DataTable = New DataTable
            If rdklinik.Checked = True Then
                jenislokasi = rdklinik.Text
                Tlokasi = ReadThemysql("SELECT * FROM masterlokasigl a WHERE a.loc = '" & txlocid.Text & "' AND a.jenistransaksi = 'POLI'", DB_Keuangan2)
            ElseIf rdlab.Checked = True Then
                jenislokasi = rdlab.Text
                Tlokasi = ReadThemysql("SELECT * FROM masterlokasigl a WHERE a.loc = '" & txlocid.Text & "' AND a.jenistransaksi = 'LAB'", DB_Keuangan2)
            End If

            Dim TrowLokasi As DataRow = Tlokasi.Rows(0)

            'Search Harga
            Dim Tharga As DataTable = New DataTable

            If rdbpjs.Checked = True Then
                jeniskapitasi = rdbpjs.Text

                Tharga = ReadThemysql("SELECT a.hargaumum, a.hargagigi FROM masterkapitasi a WHERE a.cabang = '" & txlocid.Text & "' AND a.jenislokasi = '" & jenislokasi & "' AND a.jeniskapitasi = '" & jeniskapitasi & "' AND a.bulan = '" & datekapitasi.Month & "' AND a.tahun = '" & datekapitasi.Year & "'", DB_Poliklinik)
            ElseIf rdinhealth.Checked = True Then
                jeniskapitasi = rdinhealth.Text

                Tharga = ReadThemysql("SELECT a.hargacob, a.harganoncob FROM masterkapitasi a WHERE a.cabang = '" & txlocid.Text & "' AND a.jenislokasi = '" & jenislokasi & "' AND a.jeniskapitasi = '" & jeniskapitasi & "' AND a.bulan = '" & datekapitasi.Month & "' AND a.tahun = '" & datekapitasi.Year & "'", DB_Poliklinik)
            End If

            Dim TrowHarga As DataRow = Tharga.Rows(0)

            Dim nominalkapitasi As Double = 0

            If rdbpjs.Checked = True Then
                nominalkapitasi = (CDbl(TrowHarga("hargaumum")) * CDbl(txjumlahpasien.Text)) + (CDbl(TrowHarga("hargagigi")) * CDbl(txjumlahpasien.Text))
            ElseIf rdinhealth.Checked = True Then
                If rdcob.Checked = True Then
                    nominalkapitasi = CDbl(TrowHarga("hargacob") * CDbl(txjumlahpasien.Text))
                ElseIf rdnoncob.Checked = True Then
                    nominalkapitasi = CDbl(TrowHarga("harganoncob") * CDbl(txjumlahpasien.Text))
                End If
            End If

            'Set Jurnal
            Dim textflag As String = ""
            Dim bsa As String = ""
            Dim flag As String = ""
            Dim Nourut As String = ""
            Dim KeteranganGL As String = ""
            Dim CoaPendapatanKapitasiBPJS As String = "42010500"
            Dim CoaPiutangKapitasiBPJS As String = "11020200"
            Dim CoaPendapatanKapitasiInHealth As String = "42011200"
            Dim CoaPiutangKapitasiInHealth As String = "11020300"

            'Set no urut flag
            If rdbpjs.Checked = True Then
                textflag = "KPT1"
                Nourut = ReadThemysqlNIK("SELECT concat(lpad(RIGHT(a.flag1,5)+1,5,0)) FROM transaksikapitasi a WHERE a.flag1 LIKE '%" & Format(datekapitasi, "yyyy") & Format(datekapitasi, "MM") & textflag & "%' ORDER BY a.flag1 DESC LIMIT 1", DB_Poliklinik)
            ElseIf rdinhealth.Checked = True Then
                If rdcob.Checked = True Then
                    textflag = "KPT3"
                    Nourut = ReadThemysqlNIK("SELECT concat(lpad(RIGHT(a.flagcob1,5)+1,5,0)) FROM transaksikapitasi a WHERE a.flagcob1 LIKE '%" & Format(datekapitasi, "yyyy") & Format(datekapitasi, "MM") & textflag & "%' ORDER BY a.flagcob1 DESC LIMIT 1", DB_Poliklinik)
                ElseIf rdnoncob.Checked = True Then
                    textflag = "KPT4"
                    Nourut = ReadThemysqlNIK("SELECT concat(lpad(RIGHT(a.flagnoncob1,5)+1,5,0)) FROM transaksikapitasi a WHERE a.flagnoncob1 LIKE '%" & Format(datekapitasi, "yyyy") & Format(datekapitasi, "MM") & textflag & "%' ORDER BY a.flagnoncob1 DESC LIMIT 1", DB_Poliklinik)
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

            If rdbpjs.Checked = True Then
                'Set Keterangan
                KeteranganGL = "TERIMA - KAPITASI " & jeniskapitasi.ToString.ToUpper & " " & Tdetaillokasi(0).ToString & " " & cmbbulan.Text.ToUpper & " " & cmbtahun.Text

                'Insert Log
                WriteThemysql("insert into transaksikapitasi (flag1, jenislokasi, jeniskapitasi, cabang, tahun, bulan, jumlahpasien, hargaumum, hargagigi, nominaltotal, createdate, createby, statusupload) " & _
                              "values('" & flag & "', '" & jenislokasi & "', '" & jeniskapitasi & "', '" & txlocid.Text & "', '" & datekapitasi.Year & "', " & datekapitasi.Month & ", '" & CDbl(txjumlahpasien.Text) & "', '" & CDbl(TrowHarga("hargaumum")) & "', '" & CDbl(TrowHarga("hargagigi")) & "', '" & CDbl(nominalkapitasi) & "', NOW(), '" & UserInput & "', False)", DB_Poliklinik)
            ElseIf rdinhealth.Checked = True Then
                'Set Status Inhealth
                If rdcob.Checked = True Then
                    'Set Keterangan
                    KeteranganGL = "TERIMA - KAPITASI " & jeniskapitasi.ToString.ToUpper & " COB " & Tdetaillokasi(0).ToString & " " & cmbbulan.Text.ToUpper & " " & cmbtahun.Text

                    If CheckThemysql("SELECT * FROM transaksikapitasi a WHERE a.cabang = '" & txlocid.Text & "' AND a.jenislokasi = '" & jenislokasi & "' AND a.jeniskapitasi = '" & jeniskapitasi & "' AND a.bulan = '" & datekapitasi.Month & "' AND a.tahun = '" & datekapitasi.Year & "'", DB_Poliklinik) = False Then
                        'Insert Log
                        WriteThemysql("insert into transaksikapitasi (flagcob1, jenislokasi, jeniskapitasi, cabang, tahun, bulan, jumlahpasiencob, hargacob, nominaltotalcob, createdate, createby, statusuploadcob) " & _
                                      "values('" & flag & "', '" & jenislokasi & "', '" & jeniskapitasi & "', '" & txlocid.Text & "', '" & datekapitasi.Year & "', " & datekapitasi.Month & ", '" & CDbl(txjumlahpasien.Text) & "', '" & CDbl(TrowHarga("hargacob")) & "', '" & CDbl(nominalkapitasi) & "', NOW(), '" & UserInput & "', False)", DB_Poliklinik)
                    Else
                        'Update Log
                        WriteThemysql("update transaksikapitasi a set flagcob1 = '" & flag & "', jumlahpasiencob = '" & CDbl(txjumlahpasien.Text) & "', nominaltotalcob = '" & CDbl(nominalkapitasi) & "', hargacob = '" & CDbl(TrowHarga("hargacob")) & "'" & _
                                      "WHERE a.cabang = '" & txlocid.Text & "' AND a.jenislokasi = '" & jenislokasi & "' AND a.jeniskapitasi = '" & jeniskapitasi & "' AND a.bulan = '" & datekapitasi.Month & "' AND a.tahun = '" & datekapitasi.Year & "'", DB_Poliklinik)
                    End If
                ElseIf rdnoncob.Checked = True Then
                    'Set Keterangan
                    KeteranganGL = "TERIMA - KAPITASI " & jeniskapitasi.ToString.ToUpper & " NON COB " & Tdetaillokasi(0).ToString & " " & cmbbulan.Text.ToUpper & " " & cmbtahun.Text

                    If CheckThemysql("SELECT * FROM transaksikapitasi a WHERE a.cabang = '" & txlocid.Text & "' AND a.jenislokasi = '" & jenislokasi & "' AND a.jeniskapitasi = '" & jeniskapitasi & "' AND a.bulan = '" & datekapitasi.Month & "' AND a.tahun = '" & datekapitasi.Year & "'", DB_Poliklinik) = False Then
                        'Insert Log
                        WriteThemysql("insert into transaksikapitasi (flagnoncob1, jenislokasi, jeniskapitasi, cabang, tahun, bulan, jumlahpasiennoncob, harganoncob, nominaltotalnoncob, createdate, createby, statusuploadnoncob) " & _
                                      "values('" & flag & "', '" & jenislokasi & "', '" & jeniskapitasi & "', '" & txlocid.Text & "', '" & datekapitasi.Year & "', " & datekapitasi.Month & ", '" & CDbl(txjumlahpasien.Text) & "', '" & CDbl(TrowHarga("harganoncob")) & "', '" & CDbl(nominalkapitasi) & "', NOW(), '" & UserInput & "', False)", DB_Poliklinik)
                    Else
                        'Update Log
                        WriteThemysql("update transaksikapitasi a set flagnoncob1 = '" & flag & "', jumlahpasiennoncob = '" & CDbl(txjumlahpasien.Text) & "', nominaltotalnoncob = '" & CDbl(nominalkapitasi) & "', harganoncob = '" & CDbl(TrowHarga("harganoncob")) & "'" & _
                                      "WHERE a.cabang = '" & txlocid.Text & "' AND a.jenislokasi = '" & jenislokasi & "' AND a.jeniskapitasi = '" & jeniskapitasi & "' AND a.bulan = '" & datekapitasi.Month & "' AND a.tahun = '" & datekapitasi.Year & "'", DB_Poliklinik)
                    End If
                End If
            End If

            'Jurnal
            If rdbpjs.Checked = True Then
                WriteThemysql("SELECT F_MakeUMH('" & flag & "', 'out', '', '" & Format(datekapitasi, "yyyyMMdd") & "', '" & CoaPendapatanKapitasiBPJS & "', '" & CoaPiutangKapitasiBPJS & "', 'IDR', 1, " & CDbl(nominalkapitasi) & ", '" & KeteranganGL & "', '1', '1', '', '" & KeteranganGL & "', '" & flag & "', '', '" & bsa & "', 1, " & CDbl(nominalkapitasi) & ", 'D')", DB_Jurnal)
            Else
                WriteThemysql("SELECT F_MakeUMH('" & flag & "', 'out', '', '" & Format(datekapitasi, "yyyyMMdd") & "', '" & CoaPendapatanKapitasiInHealth & "', '" & CoaPiutangKapitasiInHealth & "', 'IDR', 1, " & CDbl(nominalkapitasi) & ", '" & KeteranganGL & "', '1', '1', '', '" & KeteranganGL & "', '" & flag & "', '', '" & bsa & "', 1, " & CDbl(nominalkapitasi) & ", 'D')", DB_Jurnal)
            End If

            MsgBox("Berhasil menyimpan data.", MsgBoxStyle.Information, "Success!")
            butsavelab.Enabled = False
        End If
    End Sub

    Private Sub txjumlahpasien_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txjumlahpasien.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
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

    Private Sub ButtonFindNoAntrian_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFindNoAntrian.Click
        Dim bulan As String = Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(cmbbulan.Text, "Januari", "01"), "Februari", "02"), "Maret", "03"), "April", "04"), "Mei", "05"), "Juni", "06"), "Juli", "07"), "Agustus", "08"), "September", "09"), "Oktober", "10"), "November", "11"), "Desember", "12")
        Dim tahun As String = cmbtahun.Text
        Dim datekapitasi As DateTime = New DateTime(tahun, bulan, 1)

        Dim jeniskapitasi As String = ""
        Dim jenislokasi As String = ""

        Dim Tlokasi As DataTable = New DataTable
        If rdklinik.Checked = True Then
            jenislokasi = rdklinik.Text
            Tlokasi = ReadThemysql("SELECT * FROM masterlokasigl a WHERE a.loc = 'D002' AND a.jenistransaksi = 'POLI'", DB_Keuangan2)
        ElseIf rdlab.Checked = True Then
            jenislokasi = rdlab.Text
            Tlokasi = ReadThemysql("SELECT * FROM masterlokasigl a WHERE a.loc = 'D002' AND a.jenistransaksi = 'LAB'", DB_Keuangan2)
        End If

        Dim TrowLokasi As DataRow = Tlokasi.Rows(0)

        'Search Harga
        Dim Tharga As DataTable = New DataTable

        If rdbpjs.Checked = True Then
            jeniskapitasi = rdbpjs.Text

            Tharga = ReadThemysql("SELECT a.hargaumum, a.hargagigi FROM masterkapitasi a WHERE a.cabang = 'D002' AND a.jenislokasi = '" & jenislokasi & "' AND a.jeniskapitasi = '" & jeniskapitasi & "' AND a.bulan = '" & datekapitasi.Month & "' AND a.tahun = '" & datekapitasi.Year & "'", DB_Poliklinik)
        ElseIf rdinhealth.Checked = True Then
            jeniskapitasi = rdinhealth.Text

            Tharga = ReadThemysql("SELECT a.hargacob, a.harganoncob FROM masterkapitasi a WHERE a.cabang = 'D002' AND a.jenislokasi = '" & jenislokasi & "' AND a.jeniskapitasi = '" & jeniskapitasi & "' AND a.bulan = '" & datekapitasi.Month & "' AND a.tahun = '" & datekapitasi.Year & "'", DB_Poliklinik)
        End If

        Dim TrowHarga As DataRow = Tharga.Rows(0)

        Dim nominalkapitasi As Double = 0

        If rdbpjs.Checked = True Then
            nominalkapitasi = (CDbl(TrowHarga("hargaumum")) * CDbl(txjumlahpasien.Text)) + (CDbl(TrowHarga("hargagigi")) * CDbl(txjumlahpasien.Text))
        ElseIf rdinhealth.Checked = True Then
            If rdcob.Checked = True Then
                nominalkapitasi = CDbl(TrowHarga("hargacob") * CDbl(txjumlahpasien.Text))
            ElseIf rdnoncob.Checked = True Then
                nominalkapitasi = CDbl(TrowHarga("harganoncob") * CDbl(txjumlahpasien.Text))
            End If
        End If

        'Set Jurnal
        Dim textflag As String = ""
        Dim bsa As String = ""
        Dim flag As String = ""
        Dim Nourut As String = ""
        Dim KeteranganGL As String = ""
        Dim CoaPendapatanKapitasiBPJS As String = "42010500"
        Dim CoaPiutangKapitasiBPJS As String = "11020200"
        Dim CoaPendapatanKapitasiInHealth As String = "42011200"
        Dim CoaPiutangKapitasiInHealth As String = "11020300"

        'Set no urut flag
        If rdbpjs.Checked = True Then
            textflag = "KPT1"
            Nourut = ReadThemysqlNIK("SELECT concat(lpad(RIGHT(a.flag1,5)+1,5,0)) FROM transaksikapitasi a WHERE a.flag1 LIKE '%" & Format(datekapitasi, "yyyy") & Format(datekapitasi, "MM") & textflag & "%' ORDER BY a.flag1 DESC LIMIT 1", DB_Poliklinik)
        ElseIf rdinhealth.Checked = True Then
            If rdcob.Checked = True Then
                textflag = "KPT3"
                Nourut = ReadThemysqlNIK("SELECT concat(lpad(RIGHT(a.flagcob1,5)+1,5,0)) FROM transaksikapitasi a WHERE a.flagcob1 LIKE '%" & Format(datekapitasi, "yyyy") & Format(datekapitasi, "MM") & textflag & "%' ORDER BY a.flagcob1 DESC LIMIT 1", DB_Poliklinik)
            ElseIf rdnoncob.Checked = True Then
                textflag = "KPT4"
                Nourut = ReadThemysqlNIK("SELECT concat(lpad(RIGHT(a.flagnoncob1,5)+1,5,0)) FROM transaksikapitasi a WHERE a.flagnoncob1 LIKE '%" & Format(datekapitasi, "yyyy") & Format(datekapitasi, "MM") & textflag & "%' ORDER BY a.flagnoncob1 DESC LIMIT 1", DB_Poliklinik)
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

        If rdbpjs.Checked = True Then
            'Set Keterangan
            KeteranganGL = "TERIMA - KAPITASI " & jeniskapitasi.ToString.ToUpper & " " & Tdetaillokasi(0).ToString & " " & cmbbulan.Text.ToUpper & " " & cmbtahun.Text

            'Insert Log
            'WriteThemysql("insert into transaksikapitasi (flag1, jenislokasi, jeniskapitasi, cabang, tahun, bulan, jumlahpasien, hargaumum, hargagigi, nominaltotal, createdate, createby, statusupload) " & _
            '              "values('" & flag & "', '" & jenislokasi & "', '" & jeniskapitasi & "', '" & txlocid.Text & "', '" & datekapitasi.Year & "', " & datekapitasi.Month & ", '" & CDbl(txjumlahpasien.Text) & "', '" & CDbl(TrowHarga("hargaumum")) & "', '" & CDbl(TrowHarga("hargagigi")) & "', '" & CDbl(nominalkapitasi) & "', NOW(), '" & UserInput & "', False)", DB_Poliklinik)
        ElseIf rdinhealth.Checked = True Then
            'Set Status Inhealth
            If rdcob.Checked = True Then
                'Set Keterangan
                KeteranganGL = "TERIMA - KAPITASI " & jeniskapitasi.ToString.ToUpper & " COB " & Tdetaillokasi(0).ToString & " " & cmbbulan.Text.ToUpper & " " & cmbtahun.Text

                'If CheckThemysql("SELECT * FROM transaksikapitasi a WHERE a.cabang = '" & txlocid.Text & "' AND a.jenislokasi = '" & jenislokasi & "' AND a.jeniskapitasi = '" & jeniskapitasi & "' AND a.bulan = '" & datekapitasi.Month & "' AND a.tahun = '" & datekapitasi.Year & "'", DB_Poliklinik) = False Then
                '    'Insert Log
                '    WriteThemysql("insert into transaksikapitasi (flagcob1, jenislokasi, jeniskapitasi, cabang, tahun, bulan, jumlahpasiencob, hargacob, nominaltotalcob, createdate, createby, statusuploadcob) " & _
                '                  "values('" & flag & "', '" & jenislokasi & "', '" & jeniskapitasi & "', '" & txlocid.Text & "', '" & datekapitasi.Year & "', " & datekapitasi.Month & ", '" & CDbl(txjumlahpasien.Text) & "', '" & CDbl(TrowHarga("hargacob")) & "', '" & CDbl(nominalkapitasi) & "', NOW(), '" & UserInput & "', False)", DB_Poliklinik)
                'Else
                '    'Update Log
                '    WriteThemysql("update transaksikapitasi a set flagcob1 = '" & flag & "', jumlahpasiencob = '" & CDbl(txjumlahpasien.Text) & "', nominaltotalcob = '" & CDbl(nominalkapitasi) & "', hargacob = '" & CDbl(TrowHarga("hargacob")) & "'" & _
                '                  "WHERE a.cabang = '" & txlocid.Text & "' AND a.jenislokasi = '" & jenislokasi & "' AND a.jeniskapitasi = '" & jeniskapitasi & "' AND a.bulan = '" & datekapitasi.Month & "' AND a.tahun = '" & datekapitasi.Year & "'", DB_Poliklinik)
                'End If
            ElseIf rdnoncob.Checked = True Then
                'Set Keterangan
                KeteranganGL = "TERIMA - KAPITASI " & jeniskapitasi.ToString.ToUpper & " NON COB " & Tdetaillokasi(0).ToString & " " & cmbbulan.Text.ToUpper & " " & cmbtahun.Text

                'If CheckThemysql("SELECT * FROM transaksikapitasi a WHERE a.cabang = '" & txlocid.Text & "' AND a.jenislokasi = '" & jenislokasi & "' AND a.jeniskapitasi = '" & jeniskapitasi & "' AND a.bulan = '" & datekapitasi.Month & "' AND a.tahun = '" & datekapitasi.Year & "'", DB_Poliklinik) = False Then
                '    'Insert Log
                '    WriteThemysql("insert into transaksikapitasi (flagnoncob1, jenislokasi, jeniskapitasi, cabang, tahun, bulan, jumlahpasiennoncob, harganoncob, nominaltotalnoncob, createdate, createby, statusuploadnoncob) " & _
                '                  "values('" & flag & "', '" & jenislokasi & "', '" & jeniskapitasi & "', '" & txlocid.Text & "', '" & datekapitasi.Year & "', " & datekapitasi.Month & ", '" & CDbl(txjumlahpasien.Text) & "', '" & CDbl(TrowHarga("harganoncob")) & "', '" & CDbl(nominalkapitasi) & "', NOW(), '" & UserInput & "', False)", DB_Poliklinik)
                'Else
                '    'Update Log
                '    WriteThemysql("update transaksikapitasi a set flagnoncob1 = '" & flag & "', jumlahpasiennoncob = '" & CDbl(txjumlahpasien.Text) & "', nominaltotalnoncob = '" & CDbl(nominalkapitasi) & "', harganoncob = '" & CDbl(TrowHarga("harganoncob")) & "'" & _
                '                  "WHERE a.cabang = '" & txlocid.Text & "' AND a.jenislokasi = '" & jenislokasi & "' AND a.jeniskapitasi = '" & jeniskapitasi & "' AND a.bulan = '" & datekapitasi.Month & "' AND a.tahun = '" & datekapitasi.Year & "'", DB_Poliklinik)
                'End If
            End If
        End If

        'Jurnal
        If rdbpjs.Checked = True Then
            WriteThemysql("SELECT F_MakeUMH('" & flag & "', 'out', '', '" & Format(datekapitasi, "yyyyMMdd") & "', '" & CoaPendapatanKapitasiBPJS & "', '" & CoaPiutangKapitasiBPJS & "', 'IDR', 1, " & CDbl(nominalkapitasi) & ", '" & KeteranganGL & "', '1', '1', '', '" & KeteranganGL & "', '" & flag & "', '', '" & bsa & "', 1, " & CDbl(nominalkapitasi) & ", 'D')", DB_Jurnal)
        Else
            WriteThemysql("SELECT F_MakeUMH('" & flag & "', 'out', '', '" & Format(datekapitasi, "yyyyMMdd") & "', '" & CoaPendapatanKapitasiInHealth & "', '" & CoaPiutangKapitasiInHealth & "', 'IDR', 1, " & CDbl(nominalkapitasi) & ", '" & KeteranganGL & "', '1', '1', '', '" & KeteranganGL & "', '" & flag & "', '', '" & bsa & "', 1, " & CDbl(nominalkapitasi) & ", 'D')", DB_Jurnal)
        End If

        MsgBox("Berhasil menyimpan data.", MsgBoxStyle.Information, "Success!")
    End Sub
End Class