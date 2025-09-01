Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Drawing
Imports Newtonsoft.Json
Imports Newtonsoft
Imports System.Security.Cryptography
Imports System.Collections.Generic
Imports Newtonsoft.Json.Linq
Imports System.Web.UI.WebControls

Public Class DialogBoxKonfirmasiPendaftaran
    Private formName As String = "KONFIRMASI PENDAFTARAN"
    Private TForm As String
    Private userInput As String = PoliKlinik.Lbluser.Text
    Private _dataDictionary As Dictionary(Of String, Object)

    ' Variabel Dictionary
    Private _nomorNIK As String = ""
    Private _nomorKartuBPJS As String = ""
    Private _namaPasien As String = ""
    Private _jenisKelamin As String = ""
    Private _tglLahir As Date
    Private _alamat As String = ""
    Private _noHP As String = ""
    Private _kodeDokter As String = ""
    Private _namaDokter As String = ""
    Private _kodePoli As String = ""
    Private _namaPoli As String = ""
    Private _keluhan As String = ""
    Private _kodeFaskes As String = ""
    Private _namaFaskes As String = ""

    ' Variabel PCare
    Private NoUrutBPJS As String = ""

    Private Class varJson
        Public response As v4_BPJS
        Public metaData As MetaData
    End Class

    Public Property DataDictionary() As Dictionary(Of String, Object)
        Get
            Return _dataDictionary
        End Get
        Set(ByVal value As Dictionary(Of String, Object))
            _dataDictionary = value

            ' General
            _nomorNIK = GetValueFromDictionary("Nomor NIK", "")
            _nomorKartuBPJS = GetValueFromDictionary("Nomor Kartu BPJS", "")
            _namaPasien = GetValueFromDictionary("Nama Pasien", "")
            _jenisKelamin = GetValueFromDictionary("Jenis Kelamin", "")
            _tglLahir = GetValueFromDictionary("Tgl Lahir", "")
            _alamat = GetValueFromDictionary("Alamat", "")
            _noHP = GetValueFromDictionary("Nomor HP", "")
            _kodeDokter = GetValueFromDictionary("Kode Dokter", "")
            _namaDokter = GetValueFromDictionary("Nama Dokter", "")
            _kodePoli = GetValueFromDictionary("Kode Poli", "")
            _namaPoli = GetValueFromDictionary("Nama Poli", "")
            _keluhan = GetValueFromDictionary("Keluhan", "")
            _kodeFaskes = GetValueFromDictionary("Kode Faskes", "")
            _namaFaskes = GetValueFromDictionary("Nama Faskes", "")
        End Set
    End Property

    Private Function GetValueFromDictionary(ByVal key As String, ByVal defaultValue As Object) As Object
        If _dataDictionary.ContainsKey(key) Then
            Return _dataDictionary(key)
        Else
            Return defaultValue
        End If
    End Function

    Private Sub PanelTop_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelTop.Paint
        Try
            e.Graphics.DrawString(formName, New Font("Arial", 12, FontStyle.Bold), Brushes.White, New Point(10, 10))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ButtonClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClose.Click
        Me.Close()
    End Sub

    Private Sub SetAwal()
        ' Clear Data Pasien
        TextBoxNoRekamMedis.ResetText()
        TextBoxNomorNIK.ResetText()
        TextBoxNomorKIS.ResetText()
        TextBoxNamaFaskes.ResetText()
        TextBoxNamaPasien.ResetText()
        DateTimePickerTglLahir.Value = DateSerial("9998", "12", "31")
        TextBoxJenisKelamin.ResetText()
        TextBoxNoHPIdentitas.ResetText()
        TextBoxAlamatDomisili.ResetText()

        ' Clear Data Transaksi
        TextBoxPoliTujuan.ResetText()
        TextBoxPoliKeluhanUtama.ResetText()
        TextBoxPoliKeluhanTambahan.ResetText()

        ' Set ComboBox Dokter Poli
        SetComboBoxListDokter(_kodeDokter)
        'InsertNewItemComboSQL("SELECT Nama FROM MasterDokter WHERE Jenis LIKE '%Dokter%' AND NoNIP IS NOT NULL AND StatusAktif = 1", ComboBoxPilihanDokter)
        'ComboBoxPilihanDokter.SelectedIndex = -1

        ' Set ComboBox Perawat Poli
        SetComboBoxListPerawat()
        'InsertNewItemComboSQL("SELECT Nama FROM MasterDokter WHERE Jenis like '%Perawat%' AND NoNIP IS NOT NULL AND StatusAktif = 1", ComboBoxPilihanPerawat)
        'ComboBoxPilihanPerawat.SelectedIndex = -1

        ' Set jenis rawat
        RadioButtonStatusRawatJalan.Checked = True
        RadioButtonPromotifPreventif.Checked = False
        RadioButtonStatusRawatInap.Checked = False

        Me.BringToFront()
        Me.CenterToScreen()
    End Sub

    Private Sub SetComboBoxListDokter(ByVal selectedDokterId As String)
        ' Mendeklarasikan List<KeyValuePair(Of Integer, String)>
        Dim dataItems As New List(Of KeyValuePair(Of String, String))

        Dim tbls As DataTable = ReadSQL("SELECT KodeBridgingPCare, Nama FROM MasterDokter WHERE Jenis LIKE '%Dokter%' AND NoNIP IS NOT NULL AND StatusAktif = 1")
        For Each Trow As DataRow In tbls.Rows
            ' Menambahkan pasangan nilai ID dan keterangan ke dalam List
            dataItems.Add(New KeyValuePair(Of String, String)(Trow("KodeBridgingPCare"), Trow("Nama")))
        Next

        ' Menghubungkan dataItems ke ComboBoxPilihanDokter
        ComboBoxPilihanDokter.DataSource = dataItems
        ComboBoxPilihanDokter.DisplayMember = "Value" ' Menampilkan keterangan sebagai teks yang ditampilkan di ComboBox
        ComboBoxPilihanDokter.ValueMember = "Key" ' Menyimpan ID sebagai nilai yang terkait dengan item yang dipilih

        ' Memilih item berdasarkan ID yang diberikan
        If Not String.IsNullOrEmpty(selectedDokterId) Then
            ComboBoxPilihanDokter.SelectedValue = selectedDokterId
        Else
            ComboBoxPilihanDokter.SelectedIndex = -1 ' Tidak memilih apa pun jika ID tidak diberikan
        End If
    End Sub

    Private Sub SetComboBoxListPerawat()
        ' Mendeklarasikan List<KeyValuePair(Of Integer, String)>
        Dim dataItems As New List(Of KeyValuePair(Of String, String))

        Dim tbls As DataTable = ReadSQL("SELECT NoNIP, Nama FROM MasterDokter WHERE Jenis LIKE '%Perawat%' AND NoNIP IS NOT NULL AND StatusAktif = 1")
        For Each Trow As DataRow In tbls.Rows
            ' Menambahkan pasangan nilai ID dan keterangan ke dalam List
            dataItems.Add(New KeyValuePair(Of String, String)(Trow("NoNIP"), Trow("Nama")))
        Next

        ' Menghubungkan dataItems ke ComboBoxPilihanPerawat
        ComboBoxPilihanPerawat.DataSource = dataItems
        ComboBoxPilihanPerawat.DisplayMember = "Value" ' Menampilkan keterangan sebagai teks yang ditampilkan di ComboBox
        ComboBoxPilihanPerawat.ValueMember = "Key" ' Menyimpan ID sebagai nilai yang terkait dengan item yang dipilih

        ComboBoxPilihanPerawat.SelectedIndex = -1
    End Sub

    Private Sub SetData()
        ' Cek No Rekam Medis
        Dim tblPasien As DataTable = ReadSQL("SELECT * FROM MasterPasien WHERE NoNIK = '" & _nomorNIK & "'")

        ' Set Data Pasien
        If tblPasien.Rows.Count > 0 Then
            Dim rowPasien As DataRow = tblPasien.Rows(0)
            TextBoxNoRekamMedis.Text = rowPasien("NoRekamMedis")
            TextBoxAlamatDomisili.Text = rowPasien("DomisiliAlamat")
            TextBoxNoHPIdentitas.Text = rowPasien("NoHandphone")
        Else
            TextBoxAlamatDomisili.Text = _alamat
            TextBoxNoHPIdentitas.Text = _noHP
        End If

        TextBoxNomorNIK.Text = _nomorNIK
        TextBoxNomorKIS.Text = _nomorKartuBPJS
        TextBoxNamaPasien.Text = _namaPasien
        If _jenisKelamin = "L" Then
            TextBoxJenisKelamin.Text = "Laki-laki"
        ElseIf _jenisKelamin = "P" Then
            TextBoxJenisKelamin.Text = "Perempuan"
        End If
        DateTimePickerTglLahir.Value = _tglLahir
        TextBoxNamaFaskes.Text = _namaFaskes

        ' Set Data Transaksi
        TextBoxPoliTujuan.Text = _namaPoli
        TextBoxPoliKeluhanUtama.Text = _keluhan
    End Sub

    Private Sub SubmitDataPendaftaran()
        Try
            If ValidasiTransaksi() = True Then
                ' Create Data Pasien Jika Belum Punya Nomor RM
                If TextBoxNoRekamMedis.Text = "" Then
                    SaveMasterPasien("CREATE")
                Else
                    SaveMasterPasien("UPDATE")
                End If

                ' Sending Data PCare
                Dim versiProgramAntrol As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'versi_program_antrian_online'")

                If CheckBridgingPcareActive() = True Then
                    ' Post Pendaftaran PCare (Antrol v1)
                    If versiProgramAntrol = "v1" AndAlso SendPCareDataV1() = False Then Exit Sub

                    ' Post Pendaftaran PCare & Flag Status Hadir di SINA (Antrol v2)
                    If versiProgramAntrol = "v2" AndAlso SendPCareDataV2() = False Then Exit Sub
                Else
                    ' Flag Status Hadir di SINA (Antrol v2)
                    If versiProgramAntrol = "v2" Then SetStatusHadir()
                End If

                ' Get Nomor Rekam Medis
                Dim nomorRekamMedis As String = TextBoxNoRekamMedis.Text

                ' Get Data Master Poli Tujuan
                Dim tblPoli As DataTable = ReadSQL("SELECT * FROM MasterPoliTujuan WHERE NamaPoli = '" & _namaPoli & "'")
                Dim rowPoli As DataRow = tblPoli.Rows(0)

                ' Get Jenis Transaksi
                Dim jenisTransaksi As String = ""
                If rowPoli("JenisPoli") = "UMUM" Then
                    jenisTransaksi = "POLI"
                ElseIf rowPoli("JenisPoli") = "GIGI" Then
                    jenisTransaksi = "GIGI"
                End If

                ' Get Kode Dokter
                Dim kodeDokter As String = ReadSQLNIK("SELECT ID FROM MasterDokter WHERE KodeBridgingPCare = '" & DirectCast(ComboBoxPilihanDokter.SelectedItem, KeyValuePair(Of String, String)).Key & "'")

                ' Generate No Urut Transaksi
                Dim nomorUrutTransaksi As String = generateNoTransaksi(rowPoli("KodeTransaksi"), rowPoli("JenisPoli"), DateTime.Now.ToString("yyyyMMdd"), False)

                ' Set ID Poli
                Dim idTransaksi As String = ""

                ' Set ID Tindakan
                Dim idTindakan As String = ""

                ' Insert Table TransaksiPoliBayarAwal / TransaksiGigiBayarAwal
                If rowPoli("JenisPoli") = "UMUM" Then
                    ' Insert Table TransaksiPoli
                    WriteSQL("INSERT INTO TransaksiPoli (IDInternet, DokterPoli, PerawatPoli, TglPoli, CreatedDate, CreatedBy, ClosedBayar, KodeDokter, NoUrut, StatusKeterangan, StatusTransaksi, ArrivedDate) " & _
                             "VALUES('" & nomorRekamMedis & "','" & ComboBoxPilihanDokter.Text & "', '" & ComboBoxPilihanPerawat.Text & "', GETDATE(), GETDATE(),'" & userInput & "', '12/31/9998', '" & kodeDokter & "', '" & nomorUrutTransaksi & "', 'Belum Diperiksa', 'arrived', GETDATE())", 4)

                    ' Get ID Transaksi
                    idTransaksi = ReadSQLNIK("SELECT TransPoliID FROM TransaksiPoli WHERE NoUrut = '" & nomorUrutTransaksi & "'")

                    ' Get ID Tindakan
                    idTindakan = ReadSQLNIK("SELECT TindakanID FROM MasterTindakan WHERE NamaTindakan = 'Konsultasi dokter BPJS'")

                    ' Insert Table TransaksiPoliBayarAwal
                    WriteSQL("INSERT INTO TransaksiPoliBayarAwal (TransJenis, TransPoliID, JenisBayar, NoJenisBayar, JumlahBayar, admin, transaksitime, mesin, kartu) " & _
                             "VALUES('" & jenisTransaksi & "', '" & idTransaksi & "', 'TAGIHAN','BPJS-C001', '0', '" & userInput & "', GETDATE(), '', '')", 4)

                    ' Insert Table TransaksiPoliDetail
                    WriteSQL("INSERT INTO TransaksiPoliDetail(Awal, TransPoliID, TindakanID, NamaTindakan, JenisTindakan, BiayaTindakan, DiscTindakan, NettBayar, admin, transaksitime, DiscPersenTindakan, StatusPembayaran) " & _
                             "VALUES('1', '" & idTransaksi & "' ,'" & idTindakan & "', 'Konsultasi dokter BPJS', 'Konsultasi Dokter Jaminan', 1, 1, 0, '" & userInput & "', GETDATE(), 0, 'PAID')", 4)

                    ' Update TransaksiPoli
                    WriteSQL("UPDATE TransaksiPoli SET TotalTagihan = 1, TotalDisc = 1, Pembulatan = 0, NettBayar = 0, TotalBayar = 0, Pengembalian = 0 WHERE TransPoliID='" & idTransaksi & "'", 4)
                ElseIf rowPoli("JenisPoli") = "GIGI" Then
                    ' Insert Table TransaksiGigi
                    WriteSQL("INSERT INTO TransaksiGigi (IDInternet, DokterGigi, PerawatGigi, TglGigi, CreateDate, CreateBy, KodeDokter, NoUrut, StatusKeterangan, StatusTransaksi, ArrivedDate) " & _
                            "VALUES('" & nomorRekamMedis & "','" & ComboBoxPilihanDokter.Text & "','" & ComboBoxPilihanPerawat.Text & "', GETDATE(), GETDATE(),'" & userInput & "', '" & kodeDokter & "', '" & nomorUrutTransaksi & "', 'Belum Diperiksa', 'arrived', GETDATE())", 4)

                    ' Get ID Transaksi
                    idTransaksi = ReadSQLNIK("SELECT TransGigiID FROM TransaksiGigi WHERE NoUrut = '" & nomorUrutTransaksi & "'")

                    ' Get ID Tindakan
                    idTindakan = ReadSQLNIK("SELECT TindakanID FROM MasterTindakanGigi WHERE NamaTindakan = 'Konsultasi Dokter BPJS'")

                    ' Insert Table TransaksiGigiBayarAwal
                    WriteSQL("INSERT INTO TransaksiGigiBayarAwal (TransJenis, TransGigiID, JenisBayar, NoJenisBayar, JumlahBayar, admin, transaksitime, mesin, kartu) " & _
                             "VALUES('" & jenisTransaksi & "','" & idTransaksi & "', 'TAGIHAN', 'BPJS-C001', '0', '" & userInput & "', GETDATE(), '', '')", 4)

                    ' Insert Table TransaksiGigiDetail
                    WriteSQL("INSERT INTO TransaksiGigiDetail(Awal, TransGigiID, TindakanID, NamaTindakan, JenisTindakan, BiayaTindakan, DiscTindakan, NettBayar, admin, transaksitime, DiscPersenTindakan, StatusPembayaran) " & _
                             "VALUES('1', '" & idTransaksi & "', '" & idTindakan & "', 'Konsultasi dokter BPJS', 'Konsultasi Dokter Jaminan', 1, 1, 0, '" & userInput & "', GETDATE(), 0, 'PAID')", 4)

                    ' Update TransaksiGigi
                    WriteSQL("UPDATE TransaksiGigi SET TotalTagihan = 1, TotalDisc = 1, Pembulatan = 0, NettBayar = 0, TotalBayar = 0, Pengembalian = 0 WHERE TransGigiID='" & idTransaksi & "'", 4)
                End If

                ' Set Default Jenis Kunjungan
                Dim jenisKunjungan As String = "Kunjungan Sakit"

                ' Set Jenis Rawat
                Dim jenisRawat As String = ""
                If RadioButtonStatusRawatJalan.Checked Then
                    jenisRawat = "Rawat Jalan"
                ElseIf RadioButtonStatusRawatInap.Checked Then
                    jenisRawat = "Rawat Inap"
                ElseIf RadioButtonPromotifPreventif.Checked Then
                    jenisRawat = "Promotif Preventif"
                End If

                ' Set Jenis Bayar
                Dim jenisBayar As String = GetJenisPembayaran(jenisTransaksi, nomorUrutTransaksi)

                ' Set Status BPJS
                Dim statusBPJS As Boolean = True

                ' Insert Table TransaksiDetail
                WriteSQL("INSERT INTO TransaksiDetail(NoUrutBPJS, NoTransaksi, JenisKunjungan, JenisRawat, JenisTransaksi, JenisPoli, JenisPenagihan, TanggalTransaksi, KeluhanUtama, KeluhanTambahan, IDInternet, StatusBPJS, NoUrut, AntreanOnline, CreatedBy, CreatedDate) " & _
                         "VALUES('" & NoUrutBPJS & "', '" & idTransaksi & "', '" & jenisKunjungan & "', '" & jenisRawat & "', '" & jenisTransaksi & "', '" & TextBoxPoliTujuan.Text & "', '" & jenisBayar & "', GETDATE(),'" & TextBoxPoliKeluhanUtama.Text & "', '" & TextBoxPoliKeluhanTambahan.Text & "', " & _
                         "'" & nomorRekamMedis & "'," & Convert.ToInt32(statusBPJS) & ", '" & nomorUrutTransaksi & "', 1, '" & userInput & "', GETDATE())", 4)

                ' Insert / Update Detail Waktu Transaksi (WaktuSelesaiPendaftaran)
                SetDetailWaktuTransaksi(nomorUrutTransaksi, "WaktuSelesaiPendaftaran", userInput)

                ' Cetak Barcode
                If MsgBox("Apakah anda ingin mencetak barcode pasien atas nama " & TextBoxNamaPasien.Text & "?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    CetakBarcodeKlinik(idTransaksi)
                End If

                ' Alert Success
                If NoUrutBPJS = "" Then
                    ' Non BPJS
                    MsgBox("Berhasil Menyimpan Data Pendaftaran Pasien." & vbCrLf & "No Transaksi : " & nomorUrutTransaksi, MsgBoxStyle.Information, "Success!")
                Else
                    ' BPJS
                    MsgBox("Berhasil Menyimpan Data Pendaftaran Pasien." & vbCrLf & "No Transaksi : " & nomorUrutTransaksi & vbCrLf & "No Urut BPJS : " & NoUrutBPJS, MsgBoxStyle.Information, "Success!")
                End If

                ' Refresh Grid
                FormPendaftaranAwal.GetDataAntreanOnline()

                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    'Private Sub SubmitDataPendaftaran()
    '    Try
    '        If ValidasiTransaksi() = True Then
    '            ' Debug awal
    '            MsgBox("Mulai SubmitDataPendaftaran", MsgBoxStyle.Information, "DEBUG")

    '            ' Create Data Pasien Jika Belum Punya Nomor RM
    '            If TextBoxNoRekamMedis.Text = "" Then
    '                MsgBox("SaveMasterPasien: CREATE", MsgBoxStyle.Information, "DEBUG")
    '                SaveMasterPasien("CREATE")
    '            Else
    '                MsgBox("SaveMasterPasien: UPDATE", MsgBoxStyle.Information, "DEBUG")
    '                SaveMasterPasien("UPDATE")
    '            End If

    '            ' Sending Data PCare
    '            Dim versiProgramAntrol As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'versi_program_antrian_online'")
    '            MsgBox("versiProgramAntrol = " & versiProgramAntrol, MsgBoxStyle.Information, "DEBUG")

    '            If CheckBridgingPcareActive() = True Then
    '                If versiProgramAntrol = "v1" AndAlso SendPCareDataV1() = False Then
    '                    MsgBox("SendPCareDataV1 Gagal", MsgBoxStyle.Critical, "DEBUG")
    '                    Exit Sub
    '                End If

    '                If versiProgramAntrol = "v2" AndAlso SendPCareDataV2() = False Then
    '                    MsgBox("SendPCareDataV2 Gagal", MsgBoxStyle.Critical, "DEBUG")
    '                    Exit Sub
    '                End If
    '            Else
    '                If versiProgramAntrol = "v2" Then
    '                    MsgBox("SetStatusHadir() Dipanggil", MsgBoxStyle.Information, "DEBUG")
    '                    SetStatusHadir()
    '                End If
    '            End If

    '            ' Get Nomor Rekam Medis
    '            Dim nomorRekamMedis As String = TextBoxNoRekamMedis.Text
    '            MsgBox("No Rekam Medis = " & nomorRekamMedis, MsgBoxStyle.Information, "DEBUG")

    '            ' Get Data Master Poli Tujuan
    '            Dim tblPoli As DataTable = ReadSQL("SELECT * FROM MasterPoliTujuan WHERE NamaPoli = '" & _namaPoli & "'")
    '            Dim rowPoli As DataRow = tblPoli.Rows(0)
    '            MsgBox("Poli Tujuan = " & _namaPoli & vbCrLf & "Kode Transaksi = " & rowPoli("KodeTransaksi"), MsgBoxStyle.Information, "DEBUG")

    '            ' Get Jenis Transaksi
    '            Dim jenisTransaksi As String = ""
    '            If rowPoli("JenisPoli") = "UMUM" Then
    '                jenisTransaksi = "POLI"
    '            ElseIf rowPoli("JenisPoli") = "GIGI" Then
    '                jenisTransaksi = "GIGI"
    '            End If
    '            MsgBox("Jenis Transaksi = " & jenisTransaksi, MsgBoxStyle.Information, "DEBUG")

    '            ' Get Kode Dokter
    '            Dim kodeDokter As String = ReadSQLNIK("SELECT ID FROM MasterDokter WHERE KodeBridgingPCare = '" & DirectCast(ComboBoxPilihanDokter.SelectedItem, KeyValuePair(Of String, String)).Key & "'")
    '            MsgBox("Kode Dokter = " & kodeDokter, MsgBoxStyle.Information, "DEBUG")

    '            ' Generate No Urut Transaksi
    '            Dim nomorUrutTransaksi As String = generateNoTransaksi(rowPoli("KodeTransaksi"), rowPoli("JenisPoli"), DateTime.Now.ToString("yyyyMMdd"), False)
    '            MsgBox("No Urut Transaksi = " & nomorUrutTransaksi, MsgBoxStyle.Information, "DEBUG")

    '            ' ... (lanjut proses Insert seperti sebelumnya, bisa juga tambahkan MsgBox untuk setiap query jika mau debug penuh)

    '            ' Alert Success
    '            If NoUrutBPJS = "" Then
    '                MsgBox("Sukses Simpan Non-BPJS" & vbCrLf & "No Transaksi : " & nomorUrutTransaksi, MsgBoxStyle.Information, "DEBUG")
    '            Else
    '                MsgBox("Sukses Simpan BPJS" & vbCrLf & "No Transaksi : " & nomorUrutTransaksi & vbCrLf & "No Urut BPJS : " & NoUrutBPJS, MsgBoxStyle.Information, "DEBUG")
    '            End If

    '        End If
    '    Catch ex As Exception
    '        MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "DEBUG")
    '    End Try
    'End Sub

    Private Sub SaveMasterPasien(ByRef jenisProses As String)
        Dim noRekamMedis As String = ""

        Dim noNIK As String = TextBoxNomorNIK.Text.Trim()
        Dim noKartuBPJS As String = TextBoxNomorKIS.Text.Trim()
        Dim namaPasien As String = TextBoxNamaPasien.Text.Trim()
        Dim tglLahirPasien As String = Format(DateTimePickerTglLahir.Value, "MM/dd/yyyy")
        Dim jenisKelaminPasien As String = ""

        If TextBoxJenisKelamin.Text = "Laki-laki" Then
            jenisKelaminPasien = "L"
        ElseIf TextBoxJenisKelamin.Text = "Perempuan" Then
            jenisKelaminPasien = "P"
        End If

        Dim domisiliAlamat As String = TextBoxAlamatDomisili.Text.Trim()
        Dim noHandphone As String = TextBoxNoHPIdentitas.Text.Trim()
        Dim kewarganegaraan As String = "WNI"

        ' IHS Number
        Dim noIHS As String = GetNumberIHS(TextBoxNomorNIK.Text.Trim())

        Dim queryUpdate As String = ""

        If jenisProses = "CREATE" Then
            noRekamMedis = generateNomorRekamMedis()

            ' Input ke dalam tabel master pasien
            Dim query As String = "INSERT INTO MasterPasien (noRekamMedis, NoIHS, NoNIK, NoKartuBPJS, Nama, TglLahir, JenisKelamin, DomisiliAlamat, NoHandphone, Kewarganegaraan, CreatedBy, CreatedDate) " & _
                                  "VALUES (@noRekamMedis, @noIHS, @noNIK, @noKartuBPJS, @namaPasien, @tglLahirPasien, @jenisKelaminPasien, @domisiliAlamat, @noHandphone, @kewarganegaraan, @userInput, GETDATE())"

            ' Memanggil fungsi WriteParameterizedSQL untuk eksekusi query
            WriteParameterizedLokalSQL(query, 4, _
                 New SqlParameter("@noRekamMedis", noRekamMedis), _
                 New SqlParameter("@noIHS", noIHS), _
                 New SqlParameter("@noNIK", noNIK), _
                 New SqlParameter("@noKartuBPJS", noKartuBPJS), _
                 New SqlParameter("@namaPasien", namaPasien), _
                 New SqlParameter("@tglLahirPasien", tglLahirPasien), _
                 New SqlParameter("@jenisKelaminPasien", jenisKelaminPasien), _
                 New SqlParameter("@domisiliAlamat", domisiliAlamat), _
                 New SqlParameter("@noHandphone", noHandphone), _
                 New SqlParameter("@kewarganegaraan", kewarganegaraan), _
                 New SqlParameter("@userInput", userInput))

            ' Input ke dalam tabel master pasien detail BPJS
            If noKartuBPJS.Length <> 0 AndAlso CheckBridgingPcareActive() = True Then
                InsertDataBPJS(noKartuBPJS, "CREATE")
            End If

            TextBoxNoRekamMedis.Text = noRekamMedis
        ElseIf jenisProses = "UPDATE" Then
            noRekamMedis = TextBoxNoRekamMedis.Text

            queryUpdate = "UPDATE MasterPasien SET " & _
                              "NoNIK = @noNIK, " & _
                              "NoIHS = @noIHS, " & _
                              "NoKartuBPJS = @noKartuBPJS, " & _
                              "Nama = @namaPasien, " & _
                              "TglLahir = @tglLahirPasien, " & _
                              "JenisKelamin = @jenisKelaminPasien, " & _
                              "DomisiliAlamat = @domisiliAlamat, " & _
                              "NoHandphone = @noHandphone, " & _
                              "Kewarganegaraan = @kewarganegaraan, " & _
                              "ChangeBy = @userInput, " & _
                              "ChangeDate = GETDATE() " & _
                              "WHERE NoRekamMedis = @noRekamMedis"

            WriteParameterizedLokalSQL(queryUpdate, 4, _
                 New SqlParameter("@noRekamMedis", noRekamMedis), _
                 New SqlParameter("@noIHS", noIHS), _
                 New SqlParameter("@noNIK", noNIK), _
                 New SqlParameter("@noKartuBPJS", noKartuBPJS), _
                 New SqlParameter("@namaPasien", namaPasien), _
                 New SqlParameter("@tglLahirPasien", tglLahirPasien), _
                 New SqlParameter("@jenisKelaminPasien", jenisKelaminPasien), _
                 New SqlParameter("@domisiliAlamat", domisiliAlamat), _
                 New SqlParameter("@noHandphone", noHandphone), _
                 New SqlParameter("@kewarganegaraan", kewarganegaraan), _
                 New SqlParameter("@userInput", userInput))

            ' Input/Create ke dalam tabel MasterPasienBPJS
            If noKartuBPJS.Length <> 0 AndAlso CheckBridgingPcareActive() = True Then
                If CheckSQL("SELECT * FROM MasterPasienBPJS WHERE NoKartu = '" & noKartuBPJS & "'") = False Then
                    InsertDataBPJS(noKartuBPJS, "CREATE")
                Else
                    InsertDataBPJS(noKartuBPJS, "UPDATE")
                End If
            End If
        End If
    End Sub

    Function ValidasiTransaksi() As Boolean
        ' Validasi Inputan Keluhan
        Dim inputKeluhanUtama As String = TextBoxPoliKeluhanUtama.Text.Trim()
        Dim inputKeluhanTambahan As String = TextBoxPoliKeluhanTambahan.Text.Trim()

        If inputKeluhanUtama = "" Or inputKeluhanTambahan = "" Then
            MsgBox("Gagal. Silahkan isi keluhan utama / keluhan tambahan terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        ElseIf inputKeluhanUtama.Length <= 4 Then
            MsgBox("Gagal. Keluhan utama harus lebih dari 4 karakter.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        ElseIf inputKeluhanTambahan.Length <= 10 Then
            MsgBox("Gagal. Keluhan tambahan harus lebih dari 10 karakter.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        ' Validasi Inputan Dokter
        If ComboBoxPilihanDokter.FindStringExact(ComboBoxPilihanDokter.Text) < 0 Then
            MsgBox("Masukkan nama dokter yang sesuai.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        ' Validasi Inputan Perawat
        If ComboBoxPilihanPerawat.FindStringExact(ComboBoxPilihanPerawat.Text) < 0 Then
            MsgBox("Masukkan nama perawat yang sesuai.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        ' Validasi Pendaftaran Pasien Dengan Poli Yang Sama Dalam 1 Hari
        If CheckSQL("SELECT * FROM TransaksiDetail WHERE StatusBPJS = 'True' AND IDInternet = '" & TextBoxNoRekamMedis.Text & "' AND JenisPoli = '" & TextBoxPoliTujuan.Text & "' AND CONVERT(DATE, TanggalTransaksi) = '" & Format(DateAndTime.Now, "yyyy-MM-dd") & "' AND DeletedDate IS NULL") = True Then
            MsgBox("Pasien tersebut sudah terdaftar dengan poli yang sama dalam satu hari.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        ' Validasi Alamat Domisili Kosong
        If TextBoxAlamatDomisili.Text = "" Then
            MessageBox.Show("Alamat Domisili tidak boleh kosong.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        ' Validasi No. HP Kosong
        If TextBoxNoHPIdentitas.Text.Length = 0 Then
            MessageBox.Show("Nomor HP tidak boleh kosong.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        ' Cek No WhatsApp
        If TextBoxNoHPIdentitas.Text.Length <> 0 Then
            If validateNoWhatsapp(TextBoxNoHPIdentitas.Text) = False Then
                Return False
            End If
        End If

        ' Validasi Akhir
        Select Case MsgBox("Pastikan data yang anda simpan sudah benar. Yakin untuk menyimpan data pendaftaran?", MsgBoxStyle.YesNo, "Question.")
            Case MsgBoxResult.Yes
                Return True
            Case MsgBoxResult.No
                MessageBox.Show("Cek kembali data inputan.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
        End Select
    End Function

    Private Sub ButtonSubmitPendaftaran_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSubmitPendaftaran.Click
        SubmitDataPendaftaran()
    End Sub

    Private Sub DialogBoxKonfirmasiPendaftaran_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetAwal()
        SetData()
    End Sub

    Private Sub InsertDataBPJS(ByRef noKartu As String, ByRef jenisProses As String)
        Try
            Dim parameterUpdate As String = ""
            Dim getResponse As String = ""
            Dim uri As String = ""
            Dim urlPcare As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_base_url'")

            uri = urlPcare & "peserta/noka/" & noKartu
            getResponse = getDataFromPcare(uri)

            Dim varsespoli() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of v4_BPJS_Peserta())(getResponse)

            For Each oneVar As v4_BPJS_Peserta In varsespoli
                If jenisProses = "UPDATE" Then
                    parameterUpdate = "HubunganKeluarga = '" & oneVar.response.hubunganKeluarga & "'," & _
                                      "TglMulaiAktif = '" & oneVar.response.tglMulaiAktif & "'," & _
                                      "TglAkhirBerlaku = '" & oneVar.response.tglAkhirBerlaku & "'," & _
                                      "KdProviderPst = '" & oneVar.response.kdProviderPst.kdProvider & "'," & _
                                      "NmProviderPst = '" & oneVar.response.kdProviderPst.nmProvider & "'," & _
                                      "KdProviderGigi = '" & oneVar.response.kdProviderGigi.kdProvider & "'," & _
                                      "NmProviderGigi = '" & oneVar.response.kdProviderGigi.nmProvider & "'," & _
                                      "JenisKelas = '" & oneVar.response.jnsKelas.nama & "'," & _
                                      "KdJenisKelas = '" & oneVar.response.jnsKelas.kode & "'," & _
                                      "JenisPeserta = '" & oneVar.response.jnsPeserta.nama & "'," & _
                                      "KdJenisPeserta = '" & oneVar.response.jnsPeserta.kode & "'," & _
                                      "PesertaProl = '" & oneVar.response.pstProl & "'," & _
                                      "PesertaPrb = '" & oneVar.response.pstPrb & "'," & _
                                      "Aktif = '" & oneVar.response.aktif & "'," & _
                                      "KetAktif = '" & oneVar.response.ketAktif & "'," & _
                                      "tunggakan = '" & oneVar.response.tunggakan & "'"

                    ' Update Data
                    WriteSQL("UPDATE MasterPasienBPJS SET " & parameterUpdate & " WHERE NoKartu = '" & noKartu & "'", 4)
                ElseIf jenisProses = "CREATE" Then
                    ' Insert Data
                    WriteSQL("INSERT INTO MasterPasienBPJS (NoKartu, HubunganKeluarga, TglMulaiAktif, TglAkhirBerlaku, KdProviderPst, NmProviderPst, KdProviderGigi, NmProviderGigi, JenisKelas, KdJenisKelas, JenisPeserta, KdJenisPeserta, PesertaProl, PesertaPrb, Aktif, KetAktif, tunggakan) " & _
                             "VALUES('" & noKartu & "', '" & oneVar.response.hubunganKeluarga & "', '" & oneVar.response.tglMulaiAktif & "', '" & oneVar.response.tglAkhirBerlaku & "', '" & oneVar.response.kdProviderPst.kdProvider & "', '" & oneVar.response.kdProviderPst.nmProvider & "', '" & oneVar.response.kdProviderGigi.kdProvider & "', '" & oneVar.response.kdProviderGigi.nmProvider & "', '" & oneVar.response.jnsKelas.nama & "','" & oneVar.response.jnsKelas.kode & "','" & oneVar.response.jnsPeserta.nama & "', '" & oneVar.response.jnsPeserta.kode & "','" & oneVar.response.pstProl & "','" & oneVar.response.pstPrb & "','" & oneVar.response.aktif & "','" & oneVar.response.ketAktif & "','" & oneVar.response.tunggakan & "')", 4)
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Function GetNumberIHS(ByVal nomorNIK As String) As String
        Dim nomorIHS As String = ""

        Dim baseURL As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'satu_sehat_base_url'")
        Dim apiEndpoint As String = baseURL & "Patient?identifier=https://fhir.kemkes.go.id/id/nik|" & nomorNIK
        Dim responseString As String = GetDataSatuSehat(apiEndpoint)
        Dim jsonObject() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of PatientResource())(responseString)

        For Each oneVar As PatientResource In jsonObject
            For index As Integer = 0 To oneVar.entry.Length - 1
                nomorIHS = oneVar.entry(index).resource.id
            Next
        Next

        If nomorIHS <> "" Then
            Return nomorIHS
        Else
            Return ""
        End If
    End Function

    Private Sub CetakBarcodeKlinik(ByRef key As String)
        Dim Tpos As String = ReadSQLNIK("select StrValue from MsConfig WHERE ConfigName='PathBarcode'")
        Dim KodeBarcode As String = ReadSQLNIK("select StrValue from MsConfig WHERE ConfigName='KodeBarcode'")
        Dim Tpathprf As String = ReadSQLNIK("select StrValue from MsConfig WHERE ConfigName='Pathprf'")
        Dim Ttx As String = Tpos & "Output.txt"
        Dim barcode As String = ""
        Dim totalrow As Integer = 0

        Dim Tinput As String = InputBox("Tambahan Cetakan Print Barcode : ", "Print Barcode", 3)
        If IsNumeric(Tinput) = False Then
            MsgBox("Masukkan Jumlah Barcode yang diprint.", MsgBoxStyle.Exclamation, "Warning!")
            Exit Sub
        End If

        If CInt(Tinput) = 0 Then
            Exit Sub
        End If

        If CInt(Tinput) > 10 Then
            MsgBox("Cetakan tidak boleh lebih dari 10.", MsgBoxStyle.Exclamation, "Warning!")
            Exit Sub
        End If

        Try
            If Tinput > 0 Then
                Dim Tbls2 As DataTable = ReadSQL("SELECT a.NoUrut, a.TransPoliID, c.Nama, CONVERT(varchar(11), c.TglLahir, 106) AS TglLahir, c.JenisKelamin " & _
                                                 "FROM TransaksiPoli a " & _
                                                 "LEFT JOIN MasterPasien c ON c.NoRekamMedis = a.IDInternet " & _
                                                 "WHERE a.TransPoliID = " & key)
                If Tbls2.Rows.Count > 0 Then
                    For Each TrowData As DataRow In Tbls2.Rows

                        Dim Tstrtemp As String = ""
                        If TrowData("NoUrut").ToString.Contains("U") = True Then
                            Tstrtemp = Strings.Replace(TrowData("NoUrut").ToString.Trim, "U", "7")
                        End If

                        barcode = KodeBarcode & Strings.Right(Tstrtemp.ToString.Trim, Len(Tstrtemp.ToString.Trim) - 2)
                        System.Threading.Thread.Sleep(500)

                        For i As Integer = 0 To CInt(Tinput) - 1
                            If System.IO.File.Exists(Ttx) = True Then System.IO.File.Delete(Ttx)
                            Dim objStreamWriter As StreamWriter
                            objStreamWriter = New StreamWriter(Ttx)
                            objStreamWriter.WriteLine("<xpml><page quantity='0' pitch='29.3 mm'></xpml>I8,A")
                            objStreamWriter.WriteLine("ZN")
                            objStreamWriter.WriteLine("q275")
                            objStreamWriter.WriteLine("S3")
                            objStreamWriter.WriteLine("O")
                            objStreamWriter.WriteLine("JF")
                            objStreamWriter.WriteLine("D9")
                            objStreamWriter.WriteLine("ZT")
                            objStreamWriter.WriteLine("Q234,B24")
                            objStreamWriter.WriteLine("KI80")
                            objStreamWriter.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='29.3 mm'></xpml>N")
                            objStreamWriter.WriteLine("B290,177,2,1,2,4,97,N,""" & barcode & """")
                            objStreamWriter.WriteLine("A95,217,2,3,1,1,N,""""""")
                            objStreamWriter.WriteLine("A290,54,2,2,1,1,N,""" & TrowData("Nama").ToString.Trim & """")
                            objStreamWriter.WriteLine("A290,30,2,2,1,1,N,""" & TrowData("TglLahir").ToString.Trim & " / " & TrowData("JenisKelamin").ToString.Trim & """")
                            objStreamWriter.WriteLine("A290,217,2,3,1,1,N,""" & barcode & """")
                            objStreamWriter.WriteLine("P1")
                            objStreamWriter.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
                            objStreamWriter.Close()
                            Process.Start(Tpathprf & "PrFile32.exe ", Ttx)
                        Next
                    Next
                Else
                    MsgBox("Tidak ada data yang di barcode.", MsgBoxStyle.Exclamation, "Warning!")
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            If MsgBox(" Batal untuk Cetak Barcode tambahan ? ", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                Exit Sub
            Else
                MsgBox("Ulangi proses ketika siap.", MsgBoxStyle.Exclamation, "Warning!")
            End If
        End Try
    End Sub

    Private Sub ButtonPasienTidakHadir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPasienTidakHadir.Click
        Try
            SetStatusTidakHadir()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub ButtonPasienBatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPasienBatal.Click
        Try
            SetStatusBatal()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    ' API PCare - Non Bridging Antrean (v1)
    Function SendPCareDataV1() As Boolean
        '# Variabel BPJS
        Dim tglDaftarBPJS As String = Format(DateAndTime.Now, "dd-MM-yyyy")
        Dim urlBPJS As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'pcare_base_url'")
        Dim uriBPJS As String = urlBPJS + "pendaftaran"
        Dim kdPoli As String = ""
        Dim kdTkp As String = ""
        Dim kunjSakit As String = ""

        ' Get kdprovider
        Dim kdprovider As String = ReadSQLNIK("SELECT KdProviderPst FROM MasterPasienBPJS WHERE NoKartu = '" & _nomorKartuBPJS & "'")

        ' Get Data Master Poli Tujuan
        Dim tblPoli As DataTable = ReadSQL("SELECT * FROM MasterPoliTujuan WHERE NamaPoli = '" & _namaPoli & "'")
        Dim rowPoli As DataRow = tblPoli.Rows(0)

        ' Get kdPoli
        kdPoli = rowPoli("KodeBPJS")

        ' Validasi apakah bridging PCare terpenuhi
        If ValidateBridgingPcare() = False Then Exit Function

        ' Validasi apakah transaksi sudah pelayanan di PCare
        If CheckAntreanBPJS(kdprovider, _nomorKartuBPJS, kdPoli, tglDaftarBPJS) = False Then Exit Function

        ' Get kunjSakit
        If rowPoli("PoliSakit") = True Then
            kunjSakit = "true"
        ElseIf rowPoli("PoliSakit") = False Then
            kunjSakit = "false"
        End If

        ' Get kdTkp
        If RadioButtonStatusRawatJalan.Checked = True Then
            kdTkp = RadioButtonStatusRawatJalan.Tag
        ElseIf RadioButtonStatusRawatInap.Checked = True Then
            kdTkp = RadioButtonStatusRawatInap.Tag
        ElseIf RadioButtonPromotifPreventif.Checked = True Then
            kdTkp = RadioButtonPromotifPreventif.Tag
        End If

        ' Set parameter untuk POST data ke pcare BPJS
        Dim parameterPendaftaran As String = "{" & _
               """kdProviderPeserta"" : """ & kdprovider & """," & _
               """tglDaftar"" : """ & tglDaftarBPJS & """," & _
               """noKartu"" : """ & _nomorKartuBPJS & """," & _
               """kdPoli"" : """ & kdPoli & """," & _
               """keluhan"": """ & TextBoxPoliKeluhanUtama.Text & """," & _
               """kunjSakit"": " & kunjSakit & "," & _
               """sistole"": 0," & _
               """diastole"": 0," & _
               """beratBadan"": 0," & _
               """tinggiBadan"": 0," & _
               """respRate"": 0," & _
               """lingkarPerut"": 0," & _
               """heartRate"": 0," & _
               """rujukBalik"": 0," & _
               """kdTkp"": """ & kdTkp & """" & _
              "}"

        Dim jsonString As String = PostDataFromPcare(parameterPendaftaran, uriBPJS, "POST")
        jsonString = "[" + jsonString + "]"
        Dim jsonObject() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of varJson())(jsonString)

        ' Get data no urut pendaftaran pcare BPJS
        For Each rowData As varJson In jsonObject
            Dim codeMetaData As Integer = Convert.ToInt32(rowData.metaData.code)
            Dim messageMetaData As String = rowData.metaData.message
            Dim messageResponse As String = rowData.response.message

            Select Case codeMetaData
                Case 200, 201, 204
                    NoUrutBPJS = messageResponse ' Set Nomor Urut BPJS
                Case Else
                    If messageMetaData <> "Peserta sudah di-entri di poli yang sama pada hari yang sama." Then
                        Dim messageError As String = ""
                        If messageResponse <> "" And messageMetaData <> "" Then
                            messageError = messageResponse & " (" & messageMetaData & ")"
                        ElseIf messageResponse <> "" Then
                            messageError = messageResponse
                        ElseIf messageMetaData <> "" Then
                            messageError = messageMetaData
                        End If

                        MsgBox("Eror BPJS : " & vbCrLf & messageError, MsgBoxStyle.Exclamation, "Error!")

                        Return False
                    End If
            End Select
        Next

        Return True
    End Function

    Function CheckAntreanBPJS(ByVal kdprovider_ As String, ByVal noKartu_ As String, ByVal kdPoli_ As String, ByVal tgldaftar_ As String) As Boolean
        Dim urlPcare As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_base_url'")
        Dim getResponse As String = ""
        Dim uri As String = ""

        uri = urlPcare & "/kunjungan/peserta/" & noKartu_
        getResponse = getDataFromPcare(uri)

        Dim jsonArray As JArray = JArray.Parse(getResponse)

        For Each item As JObject In jsonArray
            If item("response") IsNot Nothing AndAlso item("response").Type <> JTokenType.Null Then
                Dim jsonObject() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of v4_BPJS_Kunjungan())(getResponse)

                For Each rowData As v4_BPJS_Kunjungan In jsonObject
                    If rowData.metaData.message <> "NO_CONTENT" Then
                        For index As Integer = 0 To rowData.response.count - 1
                            If rowData.response.list(index).providerPelayanan.kdProvider = kdprovider_ And rowData.response.list(index).tglKunjungan = tgldaftar_ And rowData.response.list(index).poli.kdPoli = kdPoli_ Then
                                MsgBox("Peserta sudah di-entri di poli yang sama pada hari yang sama.", MsgBoxStyle.Exclamation, "Warning!")
                                Return False
                            End If
                        Next
                    End If
                Next
            End If
        Next

        Return True
    End Function

    'NEW
    Function SetStatusHadir() As Boolean
        Try
            '# Variabel BPJS
            Dim tglDaftar As String = Format(DateAndTime.Now, "dd-MM-yyyy")

            '# Variabel SINA
            Dim _loc As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NoPoli'")
            Dim _sumber As String = "SINA"

            ' Get Data Master Poli Tujuan
            Dim tblPoli As DataTable = ReadSQL("SELECT * FROM MasterPoliTujuan WHERE NamaPoli = '" & _namaPoli & "'")
            Dim rowPoli As DataRow = tblPoli.Rows(0)

            ' Get kdPoli
            Dim kdPoli As String = rowPoli("KodeBPJS")

            ' Set parameter JSON
            Dim parameterPendaftaran As String = "{" & _
                """tglDaftar"" : """ & tglDaftar & """," & _
                """nik"" : """ & _nomorNIK & """," & _
                """kdPoli"" : """ & kdPoli & """," & _
                """loc"": """ & _loc & """," & _
                """bridgingPcare"": false," & _
                """sumber"": """ & _sumber & """" & _
            "}"

            Dim baseUrl As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'web_service_klinik'")
            Dim urlWebService As String = baseUrl & "api/bridge/add-registrations"
            Dim jsonString As String = InsertDataAPI(parameterPendaftaran, urlWebService)

            ' Bisa ditambahkan parsing response bila perlu:
            'Dim jsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject(Of SomeResponse)(jsonString)

            Return True
        Catch ex As Exception
            MsgBox("Exception SetStatusHadir: " & ex.Message, MsgBoxStyle.Critical, "Error!")
            Return False
        End Try
    End Function

    ' API PCare - Bridging Antrean (v2)
    'NEW
    Function SendPCareDataV2() As Boolean
        Try
            Dim tglDaftarBPJS As String = Format(DateAndTime.Now, "dd-MM-yyyy")
            Dim kdPoli As String = ""
            Dim kdTkp As String = ""
            Dim kunjSakit As String = ""

            Dim _loc As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NoPoli'")
            Dim _sumber As String = "SINA"

            Dim kdprovider As String = ReadSQLNIK("SELECT KdProviderPst FROM MasterPasienBPJS WHERE NoKartu = '" & _nomorKartuBPJS & "'")

            Dim tblPoli As DataTable = ReadSQL("SELECT * FROM MasterPoliTujuan WHERE NamaPoli = '" & _namaPoli & "'")
            Dim rowPoli As DataRow = tblPoli.Rows(0)

            kdPoli = rowPoli("KodeBPJS")

            If ValidateBridgingPcare() = False Then Exit Function
            If CheckAntreanBPJS(kdprovider, _nomorKartuBPJS, kdPoli, tglDaftarBPJS) = False Then Exit Function

            kunjSakit = If(CBool(rowPoli("PoliSakit")), "true", "false")

            If RadioButtonStatusRawatJalan.Checked = True Then
                kdTkp = RadioButtonStatusRawatJalan.Tag
            ElseIf RadioButtonStatusRawatInap.Checked = True Then
                kdTkp = RadioButtonStatusRawatInap.Tag
            ElseIf RadioButtonPromotifPreventif.Checked = True Then
                kdTkp = RadioButtonPromotifPreventif.Tag
            End If

            Dim parameterPendaftaran As String = "{" & _
                """kdProviderPeserta"" : """ & kdprovider & """," & _
                """tglDaftar"" : """ & tglDaftarBPJS & """," & _
                """noKartu"" : """ & _nomorKartuBPJS & """," & _
                """nik"" : """ & _nomorNIK & """," & _
                """kdPoli"" : """ & kdPoli & """," & _
                """keluhan"": """ & TextBoxPoliKeluhanUtama.Text & """," & _
                """kunjSakit"": " & kunjSakit & "," & _
                """sistole"": 0," & _
                """diastole"": 0," & _
                """beratBadan"": 0," & _
                """tinggiBadan"": 0," & _
                """respRate"": 0," & _
                """lingkarPerut"": 0," & _
                """heartRate"": 0," & _
                """rujukBalik"": 0," & _
                """kdTkp"": """ & kdTkp & """," & _
                """loc"": """ & _loc & """," & _
                """bridgingPcare"": true," & _
                """sumber"": """ & _sumber & """" & _
            "}"

            Dim baseUrl As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'web_service_klinik'")
            Dim urlWebService As String = baseUrl & "api/bridge/add-registrations"
            Dim jsonString As String = InsertDataAPI(parameterPendaftaran, urlWebService)

            Dim jsonObject() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of varJson())(jsonString)

            For Each rowData As varJson In jsonObject
                Dim codeMetaData As Integer = Convert.ToInt32(rowData.metaData.code)
                Dim messageMetaData As String = rowData.metaData.message
                Dim messageResponse As String = rowData.response.message

                Select Case codeMetaData
                    Case 200, 201, 204
                        NoUrutBPJS = messageResponse
                        Return True
                    Case Else
                        If messageMetaData <> "Peserta sudah di-entri di poli yang sama pada hari yang sama." Then
                            Dim messageError As String = ""
                            If messageResponse <> "" And messageMetaData <> "" Then
                                messageError = messageResponse & " (" & messageMetaData & ")"
                            ElseIf messageResponse <> "" Then
                                messageError = messageResponse
                            ElseIf messageMetaData <> "" Then
                                messageError = messageMetaData
                            End If
                            MsgBox("Eror BPJS : " & vbCrLf & messageError, MsgBoxStyle.Exclamation, "Error!")
                            Return False
                        End If
                End Select
            Next

            Return True
        Catch ex As Exception
            MsgBox("Exception: " & ex.Message, MsgBoxStyle.Critical, "Error!")
            Return False
        End Try
    End Function

    'OLD
    'Function SetStatusHadir() As Boolean
    '    '# Variabel BPJS
    '    Dim tglDaftar As String = Format(DateAndTime.Now, "dd-MM-yyyy")
    '    Dim uriSINA As String = "http://sina.mitramedicare.com/v3/controller/ws_pcare_add_pendaftaran.php"

    '    '# Variabel SINA
    '    Dim _loc As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NoPoli'")
    '    Dim _sumber As String = "SINA"

    '    ' Get Data Master Poli Tujuan
    '    Dim tblPoli As DataTable = ReadSQL("SELECT * FROM MasterPoliTujuan WHERE NamaPoli = '" & _namaPoli & "'")
    '    Dim rowPoli As DataRow = tblPoli.Rows(0)

    '    ' Get kdPoli
    '    Dim kdPoli As String = rowPoli("KodeBPJS")

    '    ' Set parameter untuk POST data ke pcare BPJS
    '    Dim parameterPendaftaran As String = "{" & _
    '           """tglDaftar"" : """ & tglDaftar & """," & _
    '           """nik"" : """ & _nomorNIK & """," & _
    '           """kdPoli"" : """ & kdPoli & """," & _
    '           """loc"": """ & _loc & """," & _
    '           """bridgingPcare"": false," & _
    '           """sumber"": """ & _sumber & """" & _
    '          "}"

    '    InsertDataAPI(parameterPendaftaran, uriSINA)

    '    Return True
    'End Function

    'OLD
    'Function SendPCareDataV2() As Boolean
    '    '# Variabel BPJS
    '    Dim tglDaftarBPJS As String = Format(DateAndTime.Now, "dd-MM-yyyy")
    '    Dim uriBPJS As String = "https://sina.mitramedicare.com/v3/controller/ws_pcare_add_pendaftaran.php"
    '    Dim kdPoli As String = ""
    '    Dim kdTkp As String = ""
    '    Dim kunjSakit As String = ""

    '    '# Variabel SINA
    '    Dim _loc As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NoPoli'")
    '    Dim _sumber As String = "SINA"

    '    ' Get kdprovider
    '    Dim kdprovider As String = ReadSQLNIK("SELECT KdProviderPst FROM MasterPasienBPJS WHERE NoKartu = '" & _nomorKartuBPJS & "'")

    '    ' Get Data Master Poli Tujuan
    '    Dim tblPoli As DataTable = ReadSQL("SELECT * FROM MasterPoliTujuan WHERE NamaPoli = '" & _namaPoli & "'")
    '    Dim rowPoli As DataRow = tblPoli.Rows(0)

    '    '# Post Data BPJS

    '    ' Get kdPoli
    '    kdPoli = rowPoli("KodeBPJS")

    '    ' Validasi apakah bridging PCare terpenuhi
    '    If ValidateBridgingPcare() = False Then Exit Function

    '    ' Validasi apakah transaksi sudah pelayanan di PCare
    '    If CheckAntreanBPJS(kdprovider, _nomorKartuBPJS, kdPoli, tglDaftarBPJS) = False Then Exit Function

    '    ' Get kunjSakit
    '    If rowPoli("PoliSakit") = True Then
    '        kunjSakit = "true"
    '    ElseIf rowPoli("PoliSakit") = False Then
    '        kunjSakit = "false"
    '    End If

    '    ' Get kdTkp
    '    If RadioButtonStatusRawatJalan.Checked = True Then
    '        kdTkp = RadioButtonStatusRawatJalan.Tag
    '    ElseIf RadioButtonStatusRawatInap.Checked = True Then
    '        kdTkp = RadioButtonStatusRawatInap.Tag
    '    ElseIf RadioButtonPromotifPreventif.Checked = True Then
    '        kdTkp = RadioButtonPromotifPreventif.Tag
    '    End If

    '    ' Set parameter untuk POST data ke pcare BPJS
    '    Dim parameterPendaftaran As String = "{" & _
    '           """kdProviderPeserta"" : """ & kdprovider & """," & _
    '           """tglDaftar"" : """ & tglDaftarBPJS & """," & _
    '           """noKartu"" : """ & _nomorKartuBPJS & """," & _
    '           """nik"" : """ & _nomorNIK & """," & _
    '           """kdPoli"" : """ & kdPoli & """," & _
    '           """keluhan"": """ & TextBoxPoliKeluhanUtama.Text & """," & _
    '           """kunjSakit"": " & kunjSakit & "," & _
    '           """sistole"": 0," & _
    '           """diastole"": 0," & _
    '           """beratBadan"": 0," & _
    '           """tinggiBadan"": 0," & _
    '           """respRate"": 0," & _
    '           """lingkarPerut"": 0," & _
    '           """heartRate"": 0," & _
    '           """rujukBalik"": 0," & _
    '           """kdTkp"": """ & kdTkp & """," & _
    '           """loc"": """ & _loc & """," & _
    '           """bridgingPcare"": true," & _
    '           """sumber"": """ & _sumber & """" & _
    '          "}"

    '    Dim jsonString As String = InsertDataAPI(parameterPendaftaran, uriBPJS)
    '    Dim jsonObject() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of varJson())(jsonString)

    '    ' Get data no urut pendaftaran pcare BPJS
    '    For Each rowData As varJson In jsonObject
    '        Dim codeMetaData As Integer = Convert.ToInt32(rowData.metaData.code)
    '        Dim messageMetaData As String = rowData.metaData.message
    '        Dim messageResponse As String = rowData.response.message

    '        Select Case codeMetaData
    '            Case 200, 201, 204
    '                NoUrutBPJS = messageResponse ' Set Nomor Urut BPJS

    '                Return True
    '            Case Else
    '                If messageMetaData <> "Peserta sudah di-entri di poli yang sama pada hari yang sama." Then
    '                    Dim messageError As String = ""
    '                    If messageResponse <> "" And messageMetaData <> "" Then
    '                        messageError = messageResponse & " (" & messageMetaData & ")"
    '                    ElseIf messageResponse <> "" Then
    '                        messageError = messageResponse
    '                    ElseIf messageMetaData <> "" Then
    '                        messageError = messageMetaData
    '                    End If

    '                    MsgBox("Eror BPJS : " & vbCrLf & messageError, MsgBoxStyle.Exclamation, "Error!")

    '                    Return False
    '                End If
    '        End Select
    '    Next

    '    Return True
    'End Function

    'DEBUG
    'Public Function SendPCareDataV2() As Boolean
    '    '# Variabel BPJS
    '    Dim tglDaftarBPJS As String = Format(DateAndTime.Now, "dd-MM-yyyy")
    '    Dim uriBPJS As String = "https://sina.mitramedicare.com/v3/controller/ws_pcare_add_pendaftaran.php"
    '    Dim kdPoli As String = ""
    '    Dim kdTkp As String = ""
    '    Dim kunjSakit As String = ""

    '    MsgBox("uriBPJS" & vbCrLf & uriBPJS, MsgBoxStyle.Information, "DEBUG")

    '    '# Variabel SINA
    '    Dim _loc As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NoPoli'")
    '    Dim _sumber As String = "SINA"

    '    MsgBox("loc" & vbCrLf & _loc, MsgBoxStyle.Information, "DEBUG")
    '    MsgBox("_sumber" & vbCrLf & _sumber, MsgBoxStyle.Information, "DEBUG")


    '    ' Get kdprovider
    '    Dim kdprovider As String = ReadSQLNIK("SELECT KdProviderPst FROM MasterPasienBPJS WHERE NoKartu = '" & _nomorKartuBPJS & "'")
    '    MsgBox("kdprovider" & vbCrLf & kdprovider, MsgBoxStyle.Information, "DEBUG")


    '    ' Get Data Master Poli Tujuan
    '    Dim tblPoli As DataTable = ReadSQL("SELECT * FROM MasterPoliTujuan WHERE NamaPoli = '" & _namaPoli & "'")
    '    Dim rowPoli As DataRow = tblPoli.Rows(0)

    '    ' --- DEBUG jumlah baris yang ketarik ---
    '    MsgBox("DEBUG tblPoli Rows.Count = " & tblPoli.Rows.Count, MsgBoxStyle.Information, "DEBUG")


    '    '# Post Data BPJS
    '    kdPoli = rowPoli("KodeBPJS")

    '    MsgBox("kdPoli " & kdPoli, MsgBoxStyle.Information, "DEBUG")


    '    ' Validasi
    '    If ValidateBridgingPcare() = False Then Exit Function
    '    If CheckAntreanBPJS(kdprovider, _nomorKartuBPJS, kdPoli, tglDaftarBPJS) = False Then Exit Function

    '    ' Get kunjSakit
    '    If rowPoli("PoliSakit") = True Then
    '        kunjSakit = "true"
    '    Else
    '        kunjSakit = "false"
    '    End If

    '    ' Get kdTkp
    '    If RadioButtonStatusRawatJalan.Checked = True Then
    '        kdTkp = RadioButtonStatusRawatJalan.Tag
    '    ElseIf RadioButtonStatusRawatInap.Checked = True Then
    '        kdTkp = RadioButtonStatusRawatInap.Tag
    '    ElseIf RadioButtonPromotifPreventif.Checked = True Then
    '        kdTkp = RadioButtonPromotifPreventif.Tag
    '    End If

    '    ' Set parameter JSON
    '    Dim parameterPendaftaran As String = "{" & _
    '           """kdProviderPeserta"" : """ & kdprovider & """," & _
    '           """tglDaftar"" : """ & tglDaftarBPJS & """," & _
    '           """noKartu"" : """ & _nomorKartuBPJS & """," & _
    '           """nik"" : """ & _nomorNIK & """," & _
    '           """kdPoli"" : """ & kdPoli & """," & _
    '           """keluhan"": """ & TextBoxPoliKeluhanUtama.Text & """," & _
    '           """kunjSakit"": " & kunjSakit & "," & _
    '           """sistole"": 0," & _
    '           """diastole"": 0," & _
    '           """beratBadan"": 0," & _
    '           """tinggiBadan"": 0," & _
    '           """respRate"": 0," & _
    '           """lingkarPerut"": 0," & _
    '           """heartRate"": 0," & _
    '           """rujukBalik"": 0," & _
    '           """kdTkp"": """ & kdTkp & """," & _
    '           """loc"": """ & _loc & """," & _
    '           """bridgingPcare"": true," & _
    '           """sumber"": """ & _sumber & """" & _
    '          "}"

    '    ' --- DEBUG: tampilkan JSON dan URL ---
    '    MsgBox("DEBUG REQUEST" & vbCrLf & "URL: " & uriBPJS & vbCrLf & vbCrLf & "JSON Body:" & vbCrLf & parameterPendaftaran, MsgBoxStyle.Information, "DEBUG")

    '    ' Kirim request ke API
    '    Dim jsonString As String = InsertDataAPI(parameterPendaftaran, uriBPJS)

    '    ' --- DEBUG: tampilkan response mentah ---
    '    MsgBox("DEBUG RESPONSE" & vbCrLf & jsonString, MsgBoxStyle.Information, "DEBUG")

    '    Dim jsonObject() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of varJson())(jsonString)

    '    ' Baca response
    '    For Each rowData As varJson In jsonObject
    '        Dim codeMetaData As Integer = Convert.ToInt32(rowData.metaData.code)
    '        Dim messageMetaData As String = rowData.metaData.message
    '        Dim messageResponse As String = rowData.response.message

    '        ' --- DEBUG: tampilkan parsed response ---
    '        MsgBox("DEBUG PARSED" & vbCrLf & _
    '               "Code: " & codeMetaData & vbCrLf & _
    '               "MetaData Msg: " & messageMetaData & vbCrLf & _
    '               "Response Msg: " & messageResponse, MsgBoxStyle.Information, "DEBUG")

    '        Select Case codeMetaData
    '            Case 200, 201, 204
    '                NoUrutBPJS = messageResponse ' Set Nomor Urut BPJS
    '                Return True
    '            Case Else
    '                If messageMetaData <> "Peserta sudah di-entri di poli yang sama pada hari yang sama." Then
    '                    Dim messageError As String = ""
    '                    If messageResponse <> "" And messageMetaData <> "" Then
    '                        messageError = messageResponse & " (" & messageMetaData & ")"
    '                    ElseIf messageResponse <> "" Then
    '                        messageError = messageResponse
    '                    ElseIf messageMetaData <> "" Then
    '                        messageError = messageMetaData
    '                    End If

    '                    MsgBox("Eror BPJS : " & vbCrLf & messageError, MsgBoxStyle.Exclamation, "Error!")
    '                    Return False
    '                End If
    '        End Select
    '    Next

    '    Return True
    'End Function

    Private Sub SetStatusTidakHadir()
        '# Variabel BPJS
        Dim tglDaftar As String = Format(DateAndTime.Now, "yyyy-MM-dd")
        Dim baseUrl As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'web_service_klinik'")
        Dim urlWebService As String = baseUrl & "api/bridge/update-absence"

        '# Variabel SINA
        Dim _loc As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NoPoli'")
        Dim _sumber As String = "SINA"

        ' Get Data Master Poli Tujuan
        Dim tblPoli As DataTable = ReadSQL("SELECT * FROM MasterPoliTujuan WHERE NamaPoli = '" & _namaPoli & "'")
        Dim rowPoli As DataRow = tblPoli.Rows(0)

        ' Get kdPoli
        Dim kdPoli As String = rowPoli("KodeBPJS")

        ' Set parameter untuk POST data ke pcare BPJS
        Dim parameterPendaftaran As String = "{" & _
               """tanggalperiksa"" : """ & tglDaftar & """," & _
               """nik"" : """ & _nomorNIK & """," & _
               """kodepoli"" : """ & kdPoli & """," & _
               """kodelokasi"": """ & _loc & """" & _
              "}"

        Dim jsonString As String = InsertDataAPI(parameterPendaftaran, urlWebService)
        Dim jsonObject() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of varJson())(jsonString)

        MsgBox("Berhasil Membatalkan Transaksi.", MsgBoxStyle.Information, "Success!")
        Me.Close()
    End Sub

    Private Sub SetStatusBatal()
        '# Variabel BPJS
        Dim tglDaftar As String = Format(DateAndTime.Now, "yyyy-MM-dd")
        Dim baseUrl As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'web_service_klinik'")
        Dim urlWebService As String = baseUrl & "api/bridge/update-cancelled"

        '# Variabel SINA
        Dim _loc As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NoPoli'")
        Dim _sumber As String = "SINA"

        ' Get Data Master Poli Tujuan
        Dim tblPoli As DataTable = ReadSQL("SELECT * FROM MasterPoliTujuan WHERE NamaPoli = '" & _namaPoli & "'")
        Dim rowPoli As DataRow = tblPoli.Rows(0)

        ' Get kdPoli
        Dim kdPoli As String = rowPoli("KodeBPJS")

        ' Get Alasan
        Dim alasanBatal As String = "Tidak jadi periksa."

        ' Set parameter untuk POST data ke pcare BPJS
        Dim parameterPendaftaran As String = "{" & _
               """tanggalperiksa"" : """ & tglDaftar & """," & _
               """nik"" : """ & _nomorNIK & """," & _
               """kodepoli"" : """ & kdPoli & """," & _
               """kodelokasi"" : """ & _loc & """," & _
               """alasan"": """ & alasanBatal & """" & _
              "}"

        InsertDataAPI(parameterPendaftaran, urlWebService)
        Dim jsonString As String = InsertDataAPI(parameterPendaftaran, urlWebService)

        MsgBox("Berhasil Membatalkan Transaksi.", MsgBoxStyle.Information, "Success!")
        Me.Close()
    End Sub

    Private Sub TextBoxPoliKeluhanUtama_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxPoliKeluhanUtama.KeyPress
        ' Memeriksa apakah tombol yang ditekan adalah Enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            ' Mencegah input Enter
            e.Handled = True
        End If
    End Sub

    Private Sub TextBoxPoliKeluhanTambahan_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxPoliKeluhanTambahan.KeyPress
        ' Memeriksa apakah tombol yang ditekan adalah Enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            ' Mencegah input Enter
            e.Handled = True
        End If
    End Sub

    Private Sub TextBoxAlamatDomisili_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxAlamatDomisili.KeyPress
        ' Memeriksa apakah tombol yang ditekan adalah Enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            ' Mencegah input Enter
            e.Handled = True
        End If
    End Sub
End Class