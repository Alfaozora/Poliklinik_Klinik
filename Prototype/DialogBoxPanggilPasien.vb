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
Imports System.Text

Public Class DialogBoxPanggilPasien
    ' Variabel PCare
    Private NoUrutBPJS As String = ""

    ' Variabel Lokal
    Private userInput As String = PoliKlinik.Lbluser.Text
    Private kdProviderLokal As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'KodePPK'")
    Private formName As String = ""
    Private TForm As String
    Private _dataDictionary As Dictionary(Of String, Object)

    '# Variabel Dictionary
    Private _statusTransaksi As String = ""
    Private _noTransaksi As String = ""
    Private _noRM As String = ""
    Private _jenisPoli As String = ""
    Private _jenisUser As String = ""
    Private _jenisProses As String = ""
    Private _textButtonStartProses As String = ""
    Private _nomorAntrean As String = ""
    Private _nomorNIK As String = ""
    Private _namaPoli As String = ""
    Private _nomorBPJS As String = ""
    Private _keluhan As String = ""
    Private _jenisRawat As String = ""

    'Private Class JsonGetPesertaAntrol
    '    Public metaData As v4_BPJS_Antrol
    '    Public response As v4_BPJS_Antrol
    'End Class

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
            _textButtonStartProses = GetValueFromDictionary("Text Button Start Proses", "")
            _jenisProses = GetValueFromDictionary("Jenis Proses", "")

            ' Antrean To Pendaftaran
            _nomorAntrean = GetValueFromDictionary("Nomor Antrean", "")
            _nomorNIK = GetValueFromDictionary("Nomor NIK", "")

            ' Pendaftaran To Pemeriksaan
            _statusTransaksi = GetValueFromDictionary("Status Transaksi", "")
            _noTransaksi = GetValueFromDictionary("No Transaksi", "")
            _noRM = GetValueFromDictionary("No RM", "")
            _jenisPoli = GetValueFromDictionary("Jenis Poli", "")
            _jenisUser = GetValueFromDictionary("Jenis User", "")
            _namaPoli = GetValueFromDictionary("Nama Poli", "")
            _nomorBPJS = GetValueFromDictionary("Nomor BPJS", "")
            _keluhan = GetValueFromDictionary("Keluhan", "")
            _jenisRawat = GetValueFromDictionary("Jenis Rawat", "")
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

    Private Sub SetAwal()
        Me.CenterToScreen()

        'If _jenisProses = "Antrean - Pendaftaran" Then
        '    ButtonStartProses.Visible = True
        'ElseIf _jenisProses = "Pendaftaran - Pemeriksaan" Then

        '    If _statusTransaksi = "Belum Diperiksa" And _jenisUser.Contains("Dokter") = False Then
        '        ButtonStartProses.Visible = False
        '        ButtonStatusHadir.Visible = True
        '        ButtonStatusTidakHadir.Visible = True
        '    ElseIf _statusTransaksi = "Sudah dilakukan TTV" And _jenisUser.Contains("Dokter") = True Then
        '        ButtonStartProses.Visible = True
        '        ButtonStatusHadir.Visible = False
        '        ButtonStatusTidakHadir.Visible = False
        '    End If
        'End If

        ButtonStartProses.Text = _textButtonStartProses
    End Sub

    Private Sub Find_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetAwal()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub ButtonPanggilPasien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPanggilPasien.Click
        MsgBox("Fitur ini belum tersedia.", MsgBoxStyle.Exclamation, "Warning!")
    End Sub

    Function CreateTable() As DataTable
        Dim Thasil As New DataTable

        insertRowToTbls(Thasil, "Typstring", "Nama")
        insertRowToTbls(Thasil, "Typstring", "RM")
        insertRowToTbls(Thasil, "Typstring", "Jenis Kelamin")
        insertRowToTbls(Thasil, "typdate", "Tgl. Lahir")
        insertRowToTbls(Thasil, "Typstring", "Alamat")
        insertRowToTbls(Thasil, "Typstring", "No NIK")
        insertRowToTbls(Thasil, "Typstring", "No IHS")
        insertRowToTbls(Thasil, "Typstring", "Status NIK")
        insertRowToTbls(Thasil, "Typstring", "No JKN-KIS")
        insertRowToTbls(Thasil, "Typstring", "No. HP")
        insertRowToTbls(Thasil, "Typstring", "Prolanis")
        insertRowToTbls(Thasil, "Typstring", "PRB")
        insertRowToTbls(Thasil, "Typstring", "Status Peserta")
        insertRowToTbls(Thasil, "Typstring", "FKTP")

        Return Thasil
    End Function

    Private Sub ButtonMulaiPemeriksaan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonStartProses.Click
        If _jenisProses = "Antrean - Pendaftaran" Then
            AntreanToPendaftaran()
        ElseIf _jenisProses = "Pendaftaran - Pemeriksaan" Then
            PendaftaranToPemeriksaan()
        End If
    End Sub

    Private Sub AntreanToPendaftaran()
        ' Tambahkan validasi jika sudah di proses oleh orang lain

        ' To Pendaftaran
        Me.Close()

        ' Create Tabel Pasien
        Dim tblPasien As DataTable = CreateTable()

        ' Set Data Transaksi
        Dim queryBuilder As New StringBuilder()
        queryBuilder.AppendLine("SELECT *")
        queryBuilder.AppendLine("FROM MasterPasien a")
        queryBuilder.AppendLine("     LEFT JOIN MasterPasienBPJS b ON a.NoKartuBPJS=b.NoKartu")
        queryBuilder.AppendLine("WHERE a.NoNIK = '" & _nomorNIK & "'")

        Dim tempPasien As DataTable = New DataTable
        tempPasien = ReadSQL(queryBuilder.ToString())

        ' Set Variabel
        Dim statusAktif As String = ""
        Dim statusFKTP As Boolean = True

        Dim rowPasien As DataRow = tblPasien.NewRow()

        For Each Trow As DataRow In tempPasien.Rows
            rowPasien("Nama") = Trow("Nama")
            rowPasien("RM") = Trow("NoRekamMedis")
            rowPasien("No NIK") = Trow("NoNIK")
            rowPasien("No IHS") = Trow("NoIHS")
            rowPasien("Status NIK") = Trow("PasienTanpaNIK")
            rowPasien("Jenis Kelamin") = Trow("JenisKelamin")
            rowPasien("Tgl. Lahir") = Trow("TglLahir")
            rowPasien("Alamat") = Trow("DomisiliAlamat")
            rowPasien("No. HP") = Trow("NoHandphone")
            rowPasien("Prolanis") = Trow("Prolanis")
            rowPasien("PRB") = Trow("PRB")
            rowPasien("No JKN-KIS") = Trow("NoKartuBPJS")

            If Trow("NoKartuBPJS").ToString.Length > 0 AndAlso CheckBridgingPcareActive() = True Then
                If kdProviderLokal <> Trow("KdProviderPst").ToString Then
                    statusFKTP = False
                Else
                    statusFKTP = True
                End If

                If statusFKTP = False Then
                    statusAktif = Trow("KetAktif") & ", tidak terdaftar di FKTP ini dan rekanan."
                Else
                    statusAktif = Trow("KetAktif")
                End If

                rowPasien("Status Peserta") = statusAktif
                rowPasien("FKTP") = Trow("KdProviderPst") & "~" & Trow("NmProviderPst")
            Else
                rowPasien("Status Peserta") = "-"
                rowPasien("FKTP") = "-"
            End If
        Next

        tblPasien.Rows.Add(rowPasien)

        FormPendaftaranAwal.LoadPasien(tblPasien.DefaultView(0))
        FormPendaftaranAwal.Show()
        FormPendaftaranAwal.BringToFront()
    End Sub

    Private Sub PendaftaranToPemeriksaan()
        ' Tambahkan validasi jika sudah di proses oleh orang lain

        Me.Close()

        If _statusTransaksi = "Belum Diperiksa" And _jenisUser.Contains("Dokter") = False Then
            ' Update status transaksi menjadi > Sedang dilakukan TTV
            If _jenisPoli = "UMUM" Or _jenisPoli = "POLI" Then
                WriteSQL("UPDATE TransaksiPoli SET StatusTransaksi = 'in-progress', InProgressDate = GETDATE(), StatusKeterangan = 'Sedang dilakukan TTV' WHERE NoUrut = '" & _noTransaksi & "'", 4)
            ElseIf _jenisPoli = "GIGI" Then
                WriteSQL("UPDATE TransaksiGigi SET StatusTransaksi = 'in-progress', InProgressDate = GETDATE(), StatusKeterangan = 'Sedang dilakukan TTV' WHERE NoUrut = '" & _noTransaksi & "'", 4)
            End If

            ' Insert / Update Detail Waktu Transaksi (WaktuPanggilTTV)
            SetDetailWaktuTransaksi(_noTransaksi, "WaktuPanggilTTV", userInput)
        ElseIf _statusTransaksi = "Sudah dilakukan TTV" And _jenisUser.Contains("Dokter") = True Then
            ' Update status transaksi menjadi > Sedang Diperiksa Dokter
            If _jenisPoli = "UMUM" Or _jenisPoli = "POLI" Then
                WriteSQL("UPDATE TransaksiPoli SET StatusTransaksi = 'in-progress', InProgressDate = GETDATE(), StatusKeterangan = 'Sedang Diperiksa Dokter' WHERE NoUrut = '" & _noTransaksi & "'", 4)
            ElseIf _jenisPoli = "GIGI" Then
                WriteSQL("UPDATE TransaksiGigi SET StatusTransaksi = 'in-progress', InProgressDate = GETDATE(), StatusKeterangan = 'Sedang Diperiksa Dokter' WHERE NoUrut = '" & _noTransaksi & "'", 4)
            End If

            ' Insert / Update Detail Waktu Transaksi (WaktuPanggilDokter)
            SetDetailWaktuTransaksi(_noTransaksi, "WaktuPanggilDokter", userInput)
        End If

        FormRekamMedisDokter.SetDataFromPendaftaran(_noRM, _noTransaksi, _jenisPoli)
        FormRekamMedisDokter.Show()
        FormRekamMedisDokter.BringToFront()
    End Sub

    Private Sub ButtonStatusHadir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonStatusHadir.Click
        If _jenisProses = "Antrean - Pendaftaran" Then
            AntreanToPendaftaran()
        ElseIf _jenisProses = "Pendaftaran - Pemeriksaan" Then
            PendaftaranToPemeriksaan2()
        End If
    End Sub

    Private Sub PendaftaranToPemeriksaan2()
        ' Tambahkan validasi jika sudah di proses oleh orang lain

        Me.Close()

        If _statusTransaksi = "Belum Diperiksa" And _jenisUser.Contains("Dokter") = False Then
            ' Sending Data BPJS (Khusus Data dari Antrol)
            If CheckSQL("SELECT * FROM TransaksiDetail WHERE NoUrut = '" & _noTransaksi & "' AND AntreanOnline = 1") = True Then
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
            End If

            ' Update status transaksi menjadi > Sedang dilakukan TTV
            If _jenisPoli = "UMUM" Or _jenisPoli = "POLI" Then
                WriteSQL("UPDATE TransaksiPoli SET StatusTransaksi = 'in-progress', InProgressDate = GETDATE(), StatusKeterangan = 'Sedang dilakukan TTV' WHERE NoUrut = '" & _noTransaksi & "'", 4)
            ElseIf _jenisPoli = "GIGI" Then
                WriteSQL("UPDATE TransaksiGigi SET StatusTransaksi = 'in-progress', InProgressDate = GETDATE(), StatusKeterangan = 'Sedang dilakukan TTV' WHERE NoUrut = '" & _noTransaksi & "'", 4)
            End If

            ' Insert / Update Detail Waktu Transaksi (WaktuPanggilTTV)
            SetDetailWaktuTransaksi(_noTransaksi, "WaktuPanggilTTV", userInput)
        ElseIf _statusTransaksi = "Sudah dilakukan TTV" And _jenisUser.Contains("Dokter") = True Then
            ' Update status transaksi menjadi > Sedang Diperiksa Dokter
            If _jenisPoli = "UMUM" Or _jenisPoli = "POLI" Then
                WriteSQL("UPDATE TransaksiPoli SET StatusTransaksi = 'in-progress', InProgressDate = GETDATE(), StatusKeterangan = 'Sedang Diperiksa Dokter' WHERE NoUrut = '" & _noTransaksi & "'", 4)
            ElseIf _jenisPoli = "GIGI" Then
                WriteSQL("UPDATE TransaksiGigi SET StatusTransaksi = 'in-progress', InProgressDate = GETDATE(), StatusKeterangan = 'Sedang Diperiksa Dokter' WHERE NoUrut = '" & _noTransaksi & "'", 4)
            End If

            ' Insert / Update Detail Waktu Transaksi (WaktuPanggilDokter)
            SetDetailWaktuTransaksi(_noTransaksi, "WaktuPanggilDokter", userInput)
        End If

        FormRekamMedisDokter.SetDataFromPendaftaran(_noRM, _noTransaksi, _jenisPoli)
        FormRekamMedisDokter.Show()
        FormRekamMedisDokter.BringToFront()
    End Sub

    ' API PCare - Bridging Antrean (v2)
    Function SendPCareDataV2() As Boolean
        '# Variabel BPJS
        Dim tglDaftarBPJS As String = Format(DateAndTime.Now, "dd-MM-yyyy")
        Dim uriBPJS As String = "http://sina.mitramedicare.com/v3/controller/ws_pcare_add_pendaftaran.php"
        Dim kdPoli As String = ""
        Dim kdTkp As String = ""
        Dim kunjSakit As String = ""

        '# Variabel SINA
        Dim _loc As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NoPoli'")
        Dim _sumber As String = "SINA"

        ' Get kdprovider
        Dim kdprovider As String = ReadSQLNIK("SELECT KdProviderPst FROM MasterPasienBPJS WHERE NoKartu = '" & _nomorBPJS & "'")

        ' Get Data Master Poli Tujuan
        Dim tblPoli As DataTable = ReadSQL("SELECT * FROM MasterPoliTujuan WHERE NamaPoli = '" & _namaPoli & "'")
        Dim rowPoli As DataRow = tblPoli.Rows(0)

        '# Post Data BPJS

        ' Get kdPoli
        kdPoli = rowPoli("KodeBPJS")

        ' Validasi apakah bridging PCare terpenuhi
        If ValidateBridgingPcare() = False Then Exit Function

        ' Validasi apakah transaksi sudah pelayanan di PCare
        If CheckAntreanBPJS(kdprovider, _nomorBPJS, kdPoli, tglDaftarBPJS) = False Then Exit Function

        ' Get kunjSakit
        If rowPoli("PoliSakit") = True Then
            kunjSakit = "true"
        ElseIf rowPoli("PoliSakit") = False Then
            kunjSakit = "false"
        End If

        ' Get kdTkp
        If _jenisRawat = "Rawat Jalan" Then
            kdTkp = "10"
        ElseIf _jenisRawat = "Rawat Inap" Then
            kdTkp = "20"
        ElseIf _jenisRawat = "Promotif Preventif" Then
            kdTkp = "50"
        End If

        ' Set parameter untuk POST data ke pcare BPJS
        Dim parameterPendaftaran As String = "{" & _
               """kdProviderPeserta"" : """ & kdprovider & """," & _
               """tglDaftar"" : """ & tglDaftarBPJS & """," & _
               """noKartu"" : """ & _nomorBPJS & """," & _
               """nik"" : """ & _nomorNIK & """," & _
               """kdPoli"" : """ & kdPoli & """," & _
               """keluhan"": """ & _keluhan & """," & _
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

        Dim jsonString As String = InsertDataAPI(parameterPendaftaran, uriBPJS)

        jsonString = jsonString
        Dim jsonObject() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of varJson())(jsonString)

        ' Get data no urut pendaftaran pcare BPJS
        For Each rowData As varJson In jsonObject
            Dim codeMetaData As Integer = Convert.ToInt32(rowData.metaData.code)
            Dim messageMetaData As String = rowData.metaData.message
            Dim messageResponse As String = rowData.response.message

            Select Case codeMetaData
                Case 200, 201, 204
                    NoUrutBPJS = messageResponse ' Set Nomor Urut BPJS

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

        ' Update TransaksiDetail
        WriteSQL("UPDATE TransaksiDetail SET NoUrutBPJS = '" & NoUrutBPJS & "' WHERE NoUrut = '" & _noTransaksi & "'", 4)

        Return True
    End Function

    Function SetStatusHadir() As Boolean
        '# Variabel BPJS
        Dim tglDaftar As String = Format(DateAndTime.Now, "dd-MM-yyyy")
        Dim uriSINA As String = "http://sina.mitramedicare.com/v3/controller/ws_pcare_add_pendaftaran.php"

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
               """tglDaftar"" : """ & tglDaftar & """," & _
               """nik"" : """ & _nomorNIK & """," & _
               """kdPoli"" : """ & kdPoli & """," & _
               """loc"": """ & _loc & """," & _
               """bridgingPcare"": false," & _
               """sumber"": """ & _sumber & """" & _
              "}"

        InsertDataAPI(parameterPendaftaran, uriSINA)

        Return True
    End Function

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
        Dim kdprovider As String = ReadSQLNIK("SELECT KdProviderPst FROM MasterPasienBPJS WHERE NoKartu = '" & _nomorBPJS & "'")

        ' Get Data Master Poli Tujuan
        Dim tblPoli As DataTable = ReadSQL("SELECT * FROM MasterPoliTujuan WHERE NamaPoli = '" & _namaPoli & "'")
        Dim rowPoli As DataRow = tblPoli.Rows(0)

        ' Get kdPoli
        kdPoli = rowPoli("KodeBPJS")

        ' Validasi apakah bridging PCare terpenuhi
        If ValidateBridgingPcare() = False Then Exit Function

        ' Validasi apakah transaksi sudah pelayanan di PCare
        If CheckAntreanBPJS(kdprovider, _nomorBPJS, kdPoli, tglDaftarBPJS) = False Then Exit Function

        ' Get kunjSakit
        If rowPoli("PoliSakit") = True Then
            kunjSakit = "true"
        ElseIf rowPoli("PoliSakit") = False Then
            kunjSakit = "false"
        End If

        ' Get kdTkp
        If _jenisRawat = "Rawat Jalan" Then
            kdTkp = "10"
        ElseIf _jenisRawat = "Rawat Inap" Then
            kdTkp = "20"
        ElseIf _jenisRawat = "Promotif Preventif" Then
            kdTkp = "50"
        End If

        ' Set parameter untuk POST data ke pcare BPJS
        Dim parameterPendaftaran As String = "{" & _
               """kdProviderPeserta"" : """ & kdprovider & """," & _
               """tglDaftar"" : """ & tglDaftarBPJS & """," & _
               """noKartu"" : """ & _nomorBPJS & """," & _
               """kdPoli"" : """ & kdPoli & """," & _
               """keluhan"": """ & _keluhan & """," & _
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

        ' Update TransaksiDetail
        WriteSQL("UPDATE TransaksiDetail SET NoUrutBPJS = '" & NoUrutBPJS & "' WHERE NoUrut = '" & _noTransaksi & "'", 4)

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

    Private Sub ButtonStatusTidakHadir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonStatusTidakHadir.Click
        Try
            SetStatusTidakHadir()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub SetStatusTidakHadir()
        '# Variabel BPJS
        Dim tglDaftar As String = Format(DateAndTime.Now, "yyyy-MM-dd")
        Dim uriSINA As String = "http://sina.mitramedicare.com/v3/controller/update_tidak_hadir_erm.php"

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

        InsertDataAPI(parameterPendaftaran, uriSINA)

        MsgBox("Berhasil Membatalkan Transaksi.", MsgBoxStyle.Information, "Success!")
        Me.Close()
    End Sub

    Private Sub ButtonStatusBatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonStatusBatal.Click
        Try
            SetStatusBatal()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub SetStatusBatal()
        '# Variabel BPJS
        Dim tglDaftar As String = Format(DateAndTime.Now, "yyyy-MM-dd")
        Dim uriSINA As String = "http://sina.mitramedicare.com/v3/controller/update_dibatalkan_erm.php"

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

        InsertDataAPI(parameterPendaftaran, uriSINA)

        MsgBox("Berhasil Membatalkan Transaksi.", MsgBoxStyle.Information, "Success!")
        Me.Close()
    End Sub
End Class