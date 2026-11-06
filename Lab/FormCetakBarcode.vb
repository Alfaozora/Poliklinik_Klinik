Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports System.IO
Imports System.Text
Imports Newtonsoft.Json.Linq

Public Class FormCetakBarcode


    Private _nikPasienAktif As String = ""
    Private _sessionCodeAktif As String = ""

    Private Sub ClearHeader()
        _nikPasienAktif = ""
        '_sessionCodeAktif = ""
        'lblStatusMCU.Text = "MCU Non-Aktif"
        'lblStatusMCU.ForeColor = Color.Gray

        rdNonMCU.Checked = True
        txTransLabID1.ResetText()
        txtindakanid.ResetText()
        txtPemeriksaanKhusus.ResetText()
        txNoMitra1.ResetText()
        txcustnama.ResetText()
        TextBoxScanHyu.Clear()
        TextBoxScanHyu.Focus()
        dtcusttgllhr.Value = DateSerial("9998", "12", "31")
        txcustumur.ResetText()
        TextBoxJenisKelamin.ResetText()
        txtindakan.ResetText()
        CetakBarcodeToolStripMenuItem.Enabled = False
        BarcodeTambahanToolStripMenuItem.Enabled = False
        GroupBox4.Visible = False
        RadioButtonFalse.Checked = True
        RadioButtonHaid.Checked = False
        RadioButtonHamil.Checked = False
        rdThoraxSetuju.Checked = True
        PanelThorax.Visible = False


        'MCU
        txNoUrut1.Enabled = False
        txNoUrut2.Enabled = False
        txNoUrut1.ResetText()
        txNoUrut2.ResetText()
        txkodecabang.ResetText()
        txcompanycode.ResetText()
        gridlab.DataSource = Nothing
        cbtabung.Checked = True
        cmbkodetransaksi.SelectedIndex = 0
    End Sub

    Public Sub LoadTransLabHyu(ByVal Trow As DataRowView)
        ClearHeader()
        CetakBarcodeToolStripMenuItem.Enabled = True
        BarcodeTambahanToolStripMenuItem.Enabled = True
        txTransLabID1.Text = Trow("TransLabID").ToString
        txtindakanid.Text = Trow("NoUrut").ToString
        txNoMitra1.Text = Trow("IDInternet").ToString

        Dim Tpasien As DataTable = ReadSQL("SELECT * FROM MasterPasien WHERE NoRekamMedis = '" & txNoMitra1.Text & "'")

        If Tpasien.Rows.Count > 0 Then
            Dim Rpasien As DataRow = Tpasien.Rows(0)
            txcustnama.Text = Rpasien("Nama").ToString
            dtcusttgllhr.Value = Rpasien("TglLahir")
            txcustumur.Text = Umur(dtcusttgllhr.Value)

            Dim jk As String = Rpasien("JenisKelamin").ToString
            TextBoxJenisKelamin.Text = jk

            If String.Equals(jk, "P", StringComparison.OrdinalIgnoreCase) Then
                GroupBox4.Visible = True
            Else
                GroupBox4.Visible = False
            End If
        Else
            TextBoxJenisKelamin.Text = ""
            GroupBox4.Visible = False
        End If

        txtindakan.Text = ReadSQLNIK("SELECT DetailPemeriksaan FROM transaksilab WHERE TransLabID = '" & Trow("TransLabID").ToString & "'")
    End Sub

    Private Structure ExcludeParam
        Public SessionCode As String
        Public NIK As String
        Public TransLabID As String
        Public UrlWebService As String
    End Structure

    Private WithEvents bgwExclude As New System.ComponentModel.BackgroundWorker

    'Public Sub LoadTransLab(ByVal Trow As DataRowView)
    '    ClearHeader()
    '    CetakBarcodeToolStripMenuItem.Enabled = True
    '    BarcodeTambahanToolStripMenuItem.Enabled = True
    '    txTransLabID1.Text = Trow("TransLabID").ToString
    '    txtindakanid.Text = Trow("NoUrut").ToString
    '    txNoMitra1.Text = Trow("IDInternet").ToString

    '    Dim Tpasien As DataTable = ReadSQL("SELECT * FROM MasterPasien WHERE NoRekamMedis = '" & txNoMitra1.Text & "'")

    '    If Tpasien.Rows.Count > 0 Then
    '        Dim Rpasien As DataRow = Tpasien.Rows(0)
    '        txcustnama.Text = Rpasien("Nama").ToString
    '        dtcusttgllhr.Value = Rpasien("TglLahir")
    '        txcustumur.Text = Umur(dtcusttgllhr.Value)

    '        Dim jk As String = Rpasien("JenisKelamin").ToString
    '        TextBoxJenisKelamin.Text = jk

    '        If String.Equals(jk, "P", StringComparison.OrdinalIgnoreCase) Then
    '            GroupBox4.Visible = True
    '        Else
    '            GroupBox4.Visible = False
    '        End If
    '    Else
    '        TextBoxJenisKelamin.Text = ""
    '        GroupBox4.Visible = False
    '    End If

    '    txtindakan.Text = ReadSQLNIK("SELECT DetailPemeriksaan FROM transaksilab WHERE TransLabID = '" & Trow("TransLabID").ToString & "'")

    '    ' =======================================================================
    '    ' ALTERNATIF GET SESSION CODE (PARSING ARRAY JSON "data")
    '    ' =======================================================================
    '    Try
    '        Dim idTrans As String = Trow("TransLabID").ToString().Trim()

    '        ' Query SQL untuk ambil TglLab dan NoNIK
    '        Dim queryGetNIK As String = "SELECT CONVERT(VARCHAR(10), TL.TglLab, 120) AS [TglLab], MP.NoNIK " & _
    '                                    "FROM TransaksiLab TL " & _
    '                                    "INNER JOIN MasterPasien MP ON TL.IDInternet = MP.NoRekamMedis " & _
    '                                    "WHERE TL.TransLabID = '" & idTrans & "'"

    '        Dim dtMcu As DataTable = ReadSQL(queryGetNIK)

    '        If dtMcu.Rows.Count > 0 Then
    '            Dim tglLab As String = dtMcu.Rows(0)("TglLab").ToString()
    '            Dim nik As String = dtMcu.Rows(0)("NoNIK").ToString().Trim()

    '            ' Set NIK Aktif ke variable global
    '            _nikPasienAktif = nik

    '            ' Endpoint Laravel Web Service
    '            Dim urlWebService As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
    '            Dim urlApi As String = urlWebService & "api/mcu/sessions"


    '            ' Body JSON
    '            Dim jsonPayload As String = "{" & _
    '                                        """date"":""" & tglLab & """," & _
    '                                        """nik"":""" & nik & """" & _
    '                                        "}"

    '            ' Hit API via helper
    '            Dim jsonResult As String = InsertDataAPIRM(jsonPayload, urlApi)
    '            Dim jObj As JObject = JObject.Parse(jsonResult)

    '            ' Validasi success dan parsing Array "data"
    '            If jObj("success") IsNot Nothing AndAlso CBool(jObj("success")) = True Then
    '                Dim jDataArray As JArray = CType(jObj("data"), JArray)

    '                ' Cek apakah Array "data" memiliki isi
    '                If jDataArray IsNot Nothing AndAlso jDataArray.Count > 0 Then
    '                    ' Ambil session_code dari index pertama [0]
    '                    _sessionCodeAktif = jDataArray(0)("session_code").ToString().Trim()
    '                Else
    '                    _sessionCodeAktif = ""
    '                    MsgBox("Data Sesi MCU kosong untuk NIK dan Tanggal tersebut.", MsgBoxStyle.Exclamation, "Peringatan API")
    '                End If
    '            Else
    '                _sessionCodeAktif = ""
    '                Dim msgErr As String = "Gagal mengambil Sesi MCU dari server."
    '                If jObj("message") IsNot Nothing Then msgErr = jObj("message").ToString()
    '                MsgBox(msgErr, MsgBoxStyle.Exclamation, "Peringatan API")
    '            End If
    '        End If

    '    Catch ex As Exception
    '        _sessionCodeAktif = ""
    '        MsgBox("Gagal mengambil Session Code via NIK: " & ex.Message, MsgBoxStyle.Critical, "Error API")
    '    End Try

    '    ' =======================================================================
    '    ' 2. EKSSEKUSI CHECK-IN (PENDAFTARAN) DENGAN ANTI-DOUBLE POST CHECK
    '    ' =======================================================================
    '    If Not String.IsNullOrEmpty(_sessionCodeAktif) AndAlso Not String.IsNullOrEmpty(_nikPasienAktif) Then
    '        Dim noUrutLog As String = txtindakanid.Text.Trim()
    '        Dim urlWebService As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
    '        Dim urlCheckIn As String = urlWebService & "api/mcu/check-in/" & _sessionCodeAktif & "/post/pendaftaran"

    '        Dim queryCekLog As String = "SELECT COUNT(*) FROM log_api_checkin " & _
    '                                    "WHERE no_urut = '" & noUrutLog & "' " & _
    '                                    "AND nik = '" & _nikPasienAktif & "' " & _
    '                                    "AND session_code = '" & _sessionCodeAktif & "' " & _
    '                                    "AND status_log = 'SUCCESS' " & _
    '                                    "AND response LIKE '%processing%'"

    '        Dim totalLogSukses As Integer = Val(ReadSQLNIK(queryCekLog))

    '        If totalLogSukses > 0 Then
    '            MsgBox("Pasien sudah berhasil diproses (Status: Processing) sebelumnya!", MsgBoxStyle.Information, "Informasi")
    '        Else
    '            Try
    '                Dim jsonCheckIn As String = "{" & _
    '                                            """identifier"":""" & _nikPasienAktif & """," & _
    '                                            """identifier_type"":""nik""," & _
    '                                            """status"":""processing""," & _
    '                                            """notes"":""-""" & _
    '                                            "}"

    '                Dim resCheckIn As String = InsertDataAPIRM(jsonCheckIn, urlCheckIn)
    '                Dim jObjRes As JObject = JObject.Parse(resCheckIn)
    '                Dim msgTampil As String = "Pendaftaran MCU berhasil diproses dan dikirim ke HYU!"

    '                If jObjRes("message") IsNot Nothing Then
    '                    msgTampil = jObjRes("message").ToString()
    '                End If

    '                MsgBox(msgTampil, MsgBoxStyle.Information, "Sukses API")

    '                Dim safePayload As String = jsonCheckIn.Replace("'", "''")
    '                Dim safeResponse As String = resCheckIn.Replace("'", "''")

    '                WriteSQL("INSERT INTO log_api_checkin (no_urut, nik, session_code, url_api, payload, response, status_log, created_date) " & _
    '                         "VALUES ('" & noUrutLog & "', '" & _nikPasienAktif & "', '" & _sessionCodeAktif & "', '" & urlCheckIn & "', '" & safePayload & "', '" & safeResponse & "', 'SUCCESS', GETDATE())", 4)

    '            Catch exCheckIn As Exception
    '                MsgBox("Gagal kirim pendaftaran ke API: " & exCheckIn.Message, MsgBoxStyle.Critical, "Debug API")

    '                Dim safePayloadErr As String = "{" & """identifier"":""" & _nikPasienAktif & """,""identifier_type"":""nik"",""status"":""processing"",""notes"":""-""" & "}"
    '                Dim safeException As String = exCheckIn.Message.Replace("'", "''")

    '                WriteSQL("INSERT INTO log_api_checkin (no_urut, nik, session_code, url_api, payload, response, status_log, created_date) " & _
    '                         "VALUES ('" & noUrutLog & "', '" & _nikPasienAktif & "', '" & _sessionCodeAktif & "', '" & urlCheckIn & "', '" & safePayloadErr.Replace("'", "''") & "', '" & safeException & "', 'FAILED', GETDATE())", 4)
    '            End Try
    '        End If

    '        ' =======================================================================
    '        ' 3. OTOMATISASI API EXCLUDE
    '        ' =======================================================================
    '        Try
    '            Dim idTransaksi As String = txTransLabID1.Text.Trim()

    '            Dim queryCekThorax As String = "SELECT COUNT(*) " & _
    '                                           "FROM TransaksiLabDetail td " & _
    '                                           "INNER JOIN mapping_pos mp ON td.TindakanID = mp.TindakanID " & _
    '                                           "WHERE td.TransLabID = '" & idTransaksi & "' AND LOWER(mp.KodePOS) = 'thorax'"

    '            Dim adaThorax As Integer = Val(ReadSQLNIK(queryCekThorax))

    '            If adaThorax > 0 Then
    '                PanelThorax.Visible = True
    '                rdThoraxSetuju.Checked = True
    '                txtAlasanThorax.Text = ""
    '                txtAlasanThorax.Enabled = False
    '            Else
    '                PanelThorax.Visible = False
    '                rdThoraxSetuju.Checked = False
    '                rdThoraxTolak.Checked = False
    '                txtAlasanThorax.Text = ""
    '            End If

    '            Dim queryExclude As String = _
    '                "SELECT KodePOS FROM (VALUES " & _
    '                "  ('pendaftaran'), ('tt_tb'), ('screening'), ('visus'), ('dokter'), " & _
    '                "  ('darah'), ('urine'), ('thorax'), ('spiro'), ('audio'), " & _
    '                "  ('ecg'), ('usg'), ('treadmill')" & _
    '                ") AS ALL_POS(KodePOS) " & _
    '                "EXCEPT " & _
    '                "SELECT DISTINCT mp.KodePOS " & _
    '                "FROM TransaksiLabDetail td " & _
    '                "INNER JOIN mapping_pos mp ON td.TindakanID = mp.TindakanID " & _
    '                "WHERE td.TransLabID = '" & idTransaksi & "'"

    '            Dim dtExclude As DataTable = ReadSQL(queryExclude)

    '            For Each rowEx As DataRow In dtExclude.Rows
    '                Dim posExclude As String = rowEx("KodePOS").ToString().Trim()

    '                If posExclude <> "pendaftaran" Then
    '                    Dim urlCheckInEx As String = urlWebService & "api/mcu/check-in/" & _sessionCodeAktif & "/post/" & posExclude

    '                    Dim jsonExclude As String = "{" & _
    '                                                """identifier"":""" & _nikPasienAktif & """," & _
    '                                                """identifier_type"":""nik""," & _
    '                                                """status"":""exclude""," & _
    '                                                """notes"":""Peserta Tidak Memiliki Paket""" & _
    '                                                "}"

    '                    InsertDataAPIRM(jsonExclude, urlCheckInEx)
    '                End If
    '            Next

    '        Catch exExclude As Exception
    '            MsgBox("Gagal otomatisasi API Exclude: " & exExclude.Message)
    '        End Try
    '    End If

    '    If Not String.IsNullOrEmpty(_sessionCodeAktif) Then
    '        lblStatusMCU.Text = "MCU Active | Sesi HYU!: " & _sessionCodeAktif
    '        lblStatusMCU.ForeColor = Color.Green
    '    Else
    '        lblStatusMCU.Text = "MCU Non-Aktif / Sesi HYU! Tidak Ditemukan"
    '        lblStatusMCU.ForeColor = Color.Red
    '    End If
    'End Sub

    Private Function CreateJsonPayload(ByVal dateVal As String, ByVal nikVal As String) As String
        Dim json As String = "{" & _
                             """date"":""" & dateVal.Trim() & """," & _
                             """nik"":""" & nikVal.Trim() & """" & _
                             "}"
        Return json
    End Function

    'Public Sub LoadTransLab(ByVal Trow As DataRowView)
    '    ClearHeader()
    '    CetakBarcodeToolStripMenuItem.Enabled = True
    '    BarcodeTambahanToolStripMenuItem.Enabled = True

    '    Dim idTrans As String = Trow("TransLabID").ToString().Trim()
    '    Dim noUrutLog As String = Trow("NoUrut").ToString().Trim()
    '    Dim idInternet As String = Trow("IDInternet").ToString().Trim()

    '    txTransLabID1.Text = idTrans
    '    txtindakanid.Text = noUrutLog
    '    txNoMitra1.Text = idInternet

    '    ' =======================================================================
    '    ' 1. LOAD DATA PASIEN LOKAL (TIDAK BOLEH TERHALANG ERROR API)
    '    ' =======================================================================
    '    Dim Tpasien As DataTable = ReadSQL("SELECT Nama, TglLahir, JenisKelamin, NoNIK FROM MasterPasien WHERE NoRekamMedis = '" & idInternet & "'")

    '    If Tpasien.Rows.Count > 0 Then
    '        Dim Rpasien As DataRow = Tpasien.Rows(0)
    '        txcustnama.Text = Rpasien("Nama").ToString()
    '        dtcusttgllhr.Value = Rpasien("TglLahir")
    '        txcustumur.Text = Umur(dtcusttgllhr.Value)

    '        Dim jk As String = Rpasien("JenisKelamin").ToString()
    '        TextBoxJenisKelamin.Text = jk
    '        GroupBox4.Visible = String.Equals(jk, "P", StringComparison.OrdinalIgnoreCase)
    '        _nikPasienAktif = Rpasien("NoNIK").ToString().Trim()
    '    Else
    '        TextBoxJenisKelamin.Text = ""
    '        GroupBox4.Visible = False
    '        _nikPasienAktif = ""
    '    End If

    '    txtindakan.Text = ReadSQLNIK("SELECT DetailPemeriksaan FROM TransaksiLab WHERE TransLabID = '" & idTrans & "'")

    '    ' =======================================================================
    '    ' 2. FETCH URL WEBSERVICE
    '    ' =======================================================================
    '    Dim urlWebService As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")

    '    If String.IsNullOrEmpty(urlWebService) Then
    '        lblStatusMCU.Text = "MCU Non-Aktif (URL WS Kosong)"
    '        lblStatusMCU.ForeColor = Color.Red
    '        Exit Sub
    '    End If

    '    ' =======================================================================
    '    ' 3. GET SESSION CODE VIA API
    '    ' =======================================================================
    '    _sessionCodeAktif = ""

    '    Dim tglLab As String = ""
    '    Dim jsonPayload As String = ""
    '    Dim jsonResult As String = ""
    '    Dim urlApiSession As String = ""

    '    Try
    '        Dim tglLabRaw As Object = ReadSQLNIK("SELECT TglLab FROM TransaksiLab WHERE TransLabID = '" & idTrans & "'")
    '        If Not IsDBNull(tglLabRaw) AndAlso IsDate(tglLabRaw) Then
    '            tglLab = Convert.ToDateTime(tglLabRaw).ToString("yyyy-MM-dd")
    '        End If

    '        If Not String.IsNullOrEmpty(_nikPasienAktif) AndAlso Not String.IsNullOrEmpty(tglLab) Then
    '            urlApiSession = urlWebService & "api/mcu/sessions"

    '            ' BUAT PAYLOAD DENGAN HELPER COMPATIBLE VB 2008
    '            jsonPayload = CreateJsonPayload(tglLab, _nikPasienAktif)

    '            ' EXECUTE API HIT
    '            jsonResult = InsertDataAPIRM(jsonPayload, urlApiSession)

    '            If Not String.IsNullOrEmpty(jsonResult) Then
    '                Dim jObj As JObject = JObject.Parse(jsonResult)
    '                Dim jDataArray As JArray = TryCast(jObj("data"), JArray)

    '                If jDataArray IsNot Nothing AndAlso jDataArray.Count > 0 Then
    '                    _sessionCodeAktif = jDataArray(0)("session_code").ToString().Trim()
    '                End If
    '            End If
    '        End If

    '    Catch ex As Exception
    '        _sessionCodeAktif = ""
    '        ' DEBUG ERROR: Tampilkan pesan error jika Try-Catch terpicu
    '        MessageBox.Show("[DEBUG ERROR API] " & ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "Exception Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try

    '    ' Jika Sesi HYU tidak ditemukan, tetap izinkan proses lokal berjalan
    '    If String.IsNullOrEmpty(_sessionCodeAktif) Then
    '        lblStatusMCU.Text = "MCU Non-Aktif / Sesi HYU! Tidak Ditemukan"
    '        lblStatusMCU.ForeColor = Color.Red
    '        Exit Sub
    '    End If

    '    ' =======================================================================
    '    ' 4. CEK STATUS CHECK-IN PESERTA (FAIL-SAFE FLEXIBLE CHECK)
    '    ' =======================================================================
    '    Dim checkInStatusText As String = "pending"
    '    Try
    '        ' Endpoint API
    '        Dim urlCekStatus As String = urlWebService & "api/mcu/check-status?session_code=" & _sessionCodeAktif & "&nik=" & _nikPasienAktif
    '        Dim jsonCekStatus As String = GetDataAPIRM(urlCekStatus)

    '        If Not String.IsNullOrEmpty(jsonCekStatus) Then
    '            Dim jObjStatus As JObject = JObject.Parse(jsonCekStatus)

    '            ' 1. Ambil Object "data" terlebih dahulu
    '            Dim jDataObj As JObject = TryCast(jObjStatus("data"), JObject)

    '            If jDataObj IsNot Nothing Then
    '                ' 2. Ambil Array "participants" dari dalam "data"
    '                Dim participants As JArray = TryCast(jDataObj("participants"), JArray)

    '                If participants IsNot Nothing AndAlso participants.Count > 0 Then
    '                    ' 3. Ambil Object peserta pertama
    '                    Dim participant As JObject = CType(participants(0), JObject)

    '                    If participant("check_in_status") IsNot Nothing Then
    '                        ' Hasil di JSON API: "checked_in"
    '                        checkInStatusText = participant("check_in_status").ToString().ToLower().Trim()
    '                    ElseIf participant("status") IsNot Nothing Then
    '                        checkInStatusText = participant("status").ToString().ToLower().Trim()
    '                    End If
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '        System.Diagnostics.Debug.WriteLine("Error Parse Cek Status: " & ex.Message)
    '    End Try

    '    ' Validasi Fleksibel Status Check-in
    '    ' "checked_in" mengandung kata "check", sehingga isSudahCheckIn akan bernilai TRUE
    '    Dim isSudahCheckIn As Boolean = (checkInStatusText.Contains("check") OrElse _
    '                                     checkInStatusText.Contains("process") OrElse _
    '                                     checkInStatusText = "success")

    '    If Not isSudahCheckIn Then
    '        MessageBox.Show("Peserta belum melakukan CHECK-IN utama (Status: " & checkInStatusText & ")!" & vbCrLf & _
    '                        "Silakan arahkan peserta menuju CHECKIN KIOSK terlebih dahulu.", _
    '                        "Peringatan Check-In", MessageBoxButtons.OK, MessageBoxIcon.Warning)

    '        lblStatusMCU.Text = "MCU Active | Sesi: " & _sessionCodeAktif & " (Belum Check-In Kiosk)"
    '        lblStatusMCU.ForeColor = Color.Orange
    '        Exit Sub
    '    End If

    '    ' =======================================================================
    '    ' 5. POST CHECK-IN PENDAFTARAN (ANTI-DOUBLE POST)
    '    ' =======================================================================
    '    Dim urlCheckIn As String = urlWebService & "api/mcu/check-in/" & _sessionCodeAktif & "/post/pendaftaran"
    '    Dim queryCekLog As String = "SELECT COUNT(1) FROM log_api_checkin " & _
    '                                "WHERE no_urut = '" & noUrutLog & "' " & _
    '                                "AND nik = '" & _nikPasienAktif & "' " & _
    '                                "AND session_code = '" & _sessionCodeAktif & "' " & _
    '                                "AND status_log = 'SUCCESS' AND response LIKE '%processing%'"

    '    Dim totalLogSukses As Integer = Val(ReadSQLNIK(queryCekLog))

    '    If totalLogSukses = 0 Then
    '        Try
    '            Dim jsonCheckIn As String = String.Format("{""identifier"":""{0}"",""identifier_type"":""nik"",""status"":""processing"",""notes"":""-""}", _nikPasienAktif)
    '            Dim resCheckIn As String = InsertDataAPIRM(jsonCheckIn, urlCheckIn)

    '            Dim safePayload As String = jsonCheckIn.Replace("'", "''")
    '            Dim safeResponse As String = resCheckIn.Replace("'", "''")

    '            WriteSQL("INSERT INTO log_api_checkin (no_urut, nik, session_code, url_api, payload, response, status_log, created_date) " & _
    '                     "VALUES ('" & noUrutLog & "', '" & _nikPasienAktif & "', '" & _sessionCodeAktif & "', '" & urlCheckIn & "', '" & safePayload & "', '" & safeResponse & "', 'SUCCESS', GETDATE())", 4)
    '        Catch exCheckIn As Exception
    '            Dim safePayloadErr As String = String.Format("{""identifier"":""{0}"",""identifier_type"":""nik"",""status"":""processing"",""notes"":""-""}", _nikPasienAktif)
    '            Dim safeException As String = exCheckIn.Message.Replace("'", "''")

    '            WriteSQL("INSERT INTO log_api_checkin (no_urut, nik, session_code, url_api, payload, response, status_log, created_date) " & _
    '                     "VALUES ('" & noUrutLog & "', '" & _nikPasienAktif & "', '" & _sessionCodeAktif & "', '" & urlCheckIn & "', '" & safePayloadErr & "', '" & safeException & "', 'FAILED', GETDATE())", 4)
    '        End Try
    '    End If

    '    ' =======================================================================
    '    ' 6. CHECK PANEL THORAX & BACKGROUND EXCLUDE
    '    ' =======================================================================
    '    Try
    '        Dim queryCekThorax As String = "SELECT COUNT(1) FROM TransaksiLabDetail td " & _
    '                                       "INNER JOIN mapping_pos mp ON td.TindakanID = mp.TindakanID " & _
    '                                       "WHERE td.TransLabID = '" & idTrans & "' AND LOWER(mp.KodePOS) = 'thorax'"

    '        Dim adaThorax As Integer = Val(ReadSQLNIK(queryCekThorax))
    '        PanelThorax.Visible = (adaThorax > 0)
    '        rdThoraxSetuju.Checked = (adaThorax > 0)
    '        rdThoraxTolak.Checked = False
    '        txtAlasanThorax.Text = ""
    '        txtAlasanThorax.Enabled = False
    '    Catch exThorax As Exception
    '    End Try

    '    If Not bgwExclude.IsBusy Then
    '        Dim param As New ExcludeParam
    '        param.SessionCode = _sessionCodeAktif
    '        param.NIK = _nikPasienAktif
    '        param.TransLabID = idTrans
    '        param.UrlWebService = urlWebService

    '        bgwExclude.RunWorkerAsync(param)
    '    End If

    '    ' 7. FINALIZE STATUS UI
    '    lblStatusMCU.Text = "MCU Active | Sesi HYU!: " & _sessionCodeAktif
    '    lblStatusMCU.ForeColor = Color.Green
    'End Sub
    Private Delegate Sub UpdateUIResultDelegate(ByVal isSudahCheckIn As Boolean, ByVal checkInStatusText As String, ByVal param As BackgroundCheckState)

    Private Structure BackgroundCheckState
        Public SessionCode As String
        Public Nik As String
        Public UrlWebService As String
        Public NoUrutLog As String
    End Structure

    Public Sub LoadTransLab(ByVal Trow As DataRowView)
        ClearHeader()
        CetakBarcodeToolStripMenuItem.Enabled = True
        BarcodeTambahanToolStripMenuItem.Enabled = True

        Dim idTrans As String = Trow("TransLabID").ToString().Trim()
        Dim noUrutLog As String = Trow("NoUrut").ToString().Trim()
        Dim idInternet As String = Trow("IDInternet").ToString().Trim()

        txTransLabID1.Text = idTrans
        txtindakanid.Text = noUrutLog
        txNoMitra1.Text = idInternet

        ' --- LOAD DATA PASIEN LOKAL (INSTAN) ---
        Dim Tpasien As DataTable = ReadSQL("SELECT Nama, TglLahir, JenisKelamin, NoNIK FROM MasterPasien WHERE NoRekamMedis = '" & idInternet & "'")

        If Tpasien.Rows.Count > 0 Then
            Dim Rpasien As DataRow = Tpasien.Rows(0)
            txcustnama.Text = Rpasien("Nama").ToString()
            dtcusttgllhr.Value = Rpasien("TglLahir")
            txcustumur.Text = Umur(dtcusttgllhr.Value)

            Dim jk As String = Rpasien("JenisKelamin").ToString()
            TextBoxJenisKelamin.Text = jk
            GroupBox4.Visible = String.Equals(jk, "P", StringComparison.OrdinalIgnoreCase)
            _nikPasienAktif = Rpasien("NoNIK").ToString().Trim()
        Else
            TextBoxJenisKelamin.Text = ""
            GroupBox4.Visible = False
            _nikPasienAktif = ""
        End If

        txtindakan.Text = ReadSQLNIK("SELECT DetailPemeriksaan FROM TransaksiLab WHERE TransLabID = '" & idTrans & "'")

        ' --- LOAD PEMERIKSAAN KHUSUS (LOKAL) ---
        Try
            Dim queryKhusus As String = _
                "SELECT DISTINCT ISNULL(mpk.NamaPemeriksaanKhusus, td.NamaTindakan) AS NamaKhusus " & _
                "FROM TransaksiLabDetail td " & _
                "INNER JOIN ms_pemeriksaan_khusus mpk ON td.TindakanID = mpk.TindakanID " & _
                "WHERE td.TransLabID = '" & idTrans & "' AND mpk.IsAktif = 1"

            Dim dtKhusus As DataTable = ReadSQL(queryKhusus)

            If dtKhusus IsNot Nothing AndAlso dtKhusus.Rows.Count > 0 Then
                Dim listKhusus As New List(Of String)
                For Each rowK As DataRow In dtKhusus.Rows
                    Dim nm As String = rowK("NamaKhusus").ToString().Trim()
                    If Not String.IsNullOrEmpty(nm) Then listKhusus.Add(nm)
                Next

                txtPemeriksaanKhusus.Text = String.Join(", ", listKhusus.ToArray())
                txtPemeriksaanKhusus.ForeColor = System.Drawing.Color.DarkRed
            Else
                txtPemeriksaanKhusus.Text = "-"
                txtPemeriksaanKhusus.ForeColor = System.Drawing.Color.Black
            End If
        Catch exKhusus As Exception
            txtPemeriksaanKhusus.Text = "-"
            System.Diagnostics.Debug.WriteLine("Error Load Pemeriksaan Khusus: " & exKhusus.Message)
        End Try

        ' --- CHECK PANEL THORAX (LOKAL) ---
        Try
            Dim queryCekThorax As String = "SELECT COUNT(1) FROM TransaksiLabDetail td " & _
                                           "INNER JOIN mapping_pos mp ON td.TindakanID = mp.TindakanID " & _
                                           "WHERE td.TransLabID = '" & idTrans & "' AND LOWER(mp.KodePOS) = 'thorax'"

            Dim adaThorax As Integer = Val(ReadSQLNIK(queryCekThorax))
            PanelThorax.Visible = (adaThorax > 0)
            rdThoraxSetuju.Checked = (adaThorax > 0)
            rdThoraxTolak.Checked = False
            txtAlasanThorax.Text = ""
            txtAlasanThorax.Enabled = False
        Catch exThorax As Exception
        End Try

        ' --- BYPASS API JIKA CHECKBOX NON-AKTIF DICENTANG / SESI KOSONG ---
        If CheckBoxNonAktif.Checked Then
            lblStatusMCU.Text = "MCU Online Non-Aktif (Mode Lokal)"
            lblStatusMCU.ForeColor = System.Drawing.Color.Red
            Exit Sub
        End If

        If String.IsNullOrEmpty(_sessionCodeAktif) Then
            Dim tglHariIni As String = DateTime.Today.ToString("yyyy-MM-dd")
            Dim queryCekLokal As String = String.Format( _
                "SELECT session_code FROM mcu_sessions " & _
                "WHERE CONVERT(VARCHAR(10), tgl_mcu, 120) = '{0}' AND status = 'active' " & _
                "ORDER BY session_id DESC", tglHariIni)

            _sessionCodeAktif = ReadSQLNIK(queryCekLokal).Trim()
        End If

        If String.IsNullOrEmpty(_sessionCodeAktif) Then
            lblStatusMCU.Text = "MCU Active (Tanpa Sesi) | Mode Lokal Only"
            lblStatusMCU.ForeColor = System.Drawing.Color.Orange
            Exit Sub
        End If

        Dim urlWebService As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")

        If String.IsNullOrEmpty(urlWebService) Then
            lblStatusMCU.Text = "MCU Non-Aktif (URL WS Kosong)"
            lblStatusMCU.ForeColor = System.Drawing.Color.Red
            Exit Sub
        End If

        ' Indikator Visual Sementara
        lblStatusMCU.Text = "Mengirim Pendaftaran MCU ke Server..."
        lblStatusMCU.ForeColor = System.Drawing.Color.Blue

        ' --- EKSEKUSI DIRECT POST PENDAFTARAN DI BACKGROUND THREAD ---
        Dim bgState As BackgroundCheckState
        bgState.SessionCode = _sessionCodeAktif
        bgState.Nik = _nikPasienAktif
        bgState.UrlWebService = urlWebService
        bgState.NoUrutLog = noUrutLog

        System.Threading.ThreadPool.QueueUserWorkItem(AddressOf DirectPostPendaftaranInBackground, bgState)
    End Sub

    Private Sub DirectPostPendaftaranInBackground(ByVal state As Object)
        Dim param As BackgroundCheckState = CType(state, BackgroundCheckState)
        Dim isSuccess As Boolean = False
        Dim msgResult As String = ""

        Try
            ' Siapkan parameter post pendaftaran
            Dim paramCheckIn As New CheckInParam
            paramCheckIn.NoUrutLog = param.NoUrutLog
            paramCheckIn.Nik = param.Nik
            paramCheckIn.SessionCode = param.SessionCode
            paramCheckIn.UrlCheckIn = param.UrlWebService & "api/mcu/check-in/" & param.SessionCode & "/post/pendaftaran"

            ' Panggil fungsi proses post pendaftaran langsung
            ProcessPostPendaftaranInBackground(paramCheckIn)

            isSuccess = True
            msgResult = "MCU Active | Sesi HYU: " & param.SessionCode
        Catch ex As Exception
            isSuccess = False
            msgResult = "MCU Warning: Gagal Sync Pendaftaran (" & ex.Message & ")"
            System.Diagnostics.Debug.WriteLine("Error Direct Post Pendaftaran: " & ex.Message)
        End Try

        ' Safe-Thread Update UI
        Dim del As New UpdateUIResultDelegate(AddressOf UpdateUIResult)
        Me.Invoke(del, New Object() {isSuccess, msgResult, param})
    End Sub

    ' =======================================================================
    ' 4. SUB UNTUK MENGUPDATE UI (DIKESEKUSI DI MAIN THREAD)
    ' =======================================================================
    Private Sub UpdateUIResult(ByVal isSudahCheckIn As Boolean, ByVal checkInStatusText As String, ByVal param As BackgroundCheckState)
        If Not isSudahCheckIn Then
            lblStatusMCU.Text = "MCU Active | Sesi: " & param.SessionCode & " (Gagal Sync)"
            lblStatusMCU.ForeColor = Color.Orange

            'MessageBox.Show("Sync Pendaftaran gagal! Status: " & checkInStatusText, _
            '                "Peringatan Sync", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            ' Cukup perbarui label UI (Jangan antrekan ThreadPool lagi di sini!)
            lblStatusMCU.Text = "MCU Active | Sesi HYU!: " & param.SessionCode
            lblStatusMCU.ForeColor = Color.Green
        End If
    End Sub

    'Private Sub UpdateUIResult(ByVal isSudahCheckIn As Boolean, ByVal checkInStatusText As String, ByVal param As BackgroundCheckState)
    '    If Not isSudahCheckIn Then
    '        lblStatusMCU.Text = "MCU Active | Sesi: " & param.SessionCode & " (Belum Check-In Kiosk)"
    '        lblStatusMCU.ForeColor = Color.Orange

    '        MessageBox.Show("Peserta belum melakukan CHECK-IN utama (Status: " & checkInStatusText & ")!" & vbCrLf & _
    '                        "Silakan arahkan peserta menuju CHECKIN KIOSK terlebih dahulu.", _
    '                        "Peringatan Check-In", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '    Else
    '        ' Jika sudah check-in, kirim posting pendaftaran ke Queue WebService
    '        Dim paramCheckIn As New CheckInParam
    '        paramCheckIn.NoUrutLog = param.NoUrutLog
    '        paramCheckIn.Nik = param.Nik
    '        paramCheckIn.SessionCode = param.SessionCode
    '        paramCheckIn.UrlCheckIn = param.UrlWebService & "api/mcu/check-in/" & param.SessionCode & "/post/pendaftaran"

    '        System.Threading.ThreadPool.QueueUserWorkItem(AddressOf ProcessPostPendaftaranInBackground, paramCheckIn)

    '        lblStatusMCU.Text = "MCU Active | Sesi HYU!: " & param.SessionCode
    '        lblStatusMCU.ForeColor = Color.Green
    '    End If
    'End Sub

    'Public Sub LoadTransLab(ByVal Trow As DataRowView)
    '    ClearHeader()
    '    CetakBarcodeToolStripMenuItem.Enabled = True
    '    BarcodeTambahanToolStripMenuItem.Enabled = True

    '    Dim idTrans As String = Trow("TransLabID").ToString().Trim()
    '    Dim noUrutLog As String = Trow("NoUrut").ToString().Trim()
    '    Dim idInternet As String = Trow("IDInternet").ToString().Trim()

    '    txTransLabID1.Text = idTrans
    '    txtindakanid.Text = noUrutLog
    '    txNoMitra1.Text = idInternet

    '    ' =======================================================================
    '    ' 1. LOAD DATA PASIEN LOKAL (TIDAK BOLEH TERHALANG ERROR API)
    '    ' =======================================================================
    '    Dim Tpasien As DataTable = ReadSQL("SELECT Nama, TglLahir, JenisKelamin, NoNIK FROM MasterPasien WHERE NoRekamMedis = '" & idInternet & "'")

    '    If Tpasien.Rows.Count > 0 Then
    '        Dim Rpasien As DataRow = Tpasien.Rows(0)
    '        txcustnama.Text = Rpasien("Nama").ToString()
    '        dtcusttgllhr.Value = Rpasien("TglLahir")
    '        txcustumur.Text = Umur(dtcusttgllhr.Value)

    '        Dim jk As String = Rpasien("JenisKelamin").ToString()
    '        TextBoxJenisKelamin.Text = jk
    '        GroupBox4.Visible = String.Equals(jk, "P", StringComparison.OrdinalIgnoreCase)
    '        _nikPasienAktif = Rpasien("NoNIK").ToString().Trim()
    '    Else
    '        TextBoxJenisKelamin.Text = ""
    '        GroupBox4.Visible = False
    '        _nikPasienAktif = ""
    '    End If

    '    txtindakan.Text = ReadSQLNIK("SELECT DetailPemeriksaan FROM TransaksiLab WHERE TransLabID = '" & idTrans & "'")

    '    ' =======================================================================
    '    ' LOAD & TAMPILKAN PEMERIKSAAN KHUSUS
    '    ' =======================================================================
    '    Try
    '        Dim queryKhusus As String = _
    '            "SELECT DISTINCT ISNULL(mpk.NamaPemeriksaanKhusus, td.NamaTindakan) AS NamaKhusus " & _
    '            "FROM TransaksiLabDetail td " & _
    '            "INNER JOIN ms_pemeriksaan_khusus mpk ON td.TindakanID = mpk.TindakanID " & _
    '            "WHERE td.TransLabID = '" & idTrans & "' AND mpk.IsAktif = 1"

    '        Dim dtKhusus As DataTable = ReadSQL(queryKhusus)

    '        If dtKhusus IsNot Nothing AndAlso dtKhusus.Rows.Count > 0 Then
    '            Dim listKhusus As New List(Of String)
    '            For Each rowK As DataRow In dtKhusus.Rows
    '                Dim nm As String = rowK("NamaKhusus").ToString().Trim()
    '                If Not String.IsNullOrEmpty(nm) Then listKhusus.Add(nm)
    '            Next

    '            txtPemeriksaanKhusus.Text = String.Join(", ", listKhusus.ToArray())
    '            txtPemeriksaanKhusus.ForeColor = Color.DarkRed
    '        Else
    '            txtPemeriksaanKhusus.Text = "-"
    '            txtPemeriksaanKhusus.ForeColor = Color.Black
    '        End If
    '    Catch exKhusus As Exception
    '        txtPemeriksaanKhusus.Text = "-"
    '        System.Diagnostics.Debug.WriteLine("Error Load Pemeriksaan Khusus: " & exKhusus.Message)
    '    End Try

    '    ' =======================================================================
    '    ' BYPASS API JIKA CHECKBOX NON-AKTIF DICENTANG
    '    ' =======================================================================
    '    If CheckBoxNonAktif.Checked Then
    '        lblStatusMCU.Text = "MCU Online Non-Aktif (Mode Lokal)"
    '        lblStatusMCU.ForeColor = Color.Red
    '        Exit Sub
    '    End If

    '    If String.IsNullOrEmpty(_sessionCodeAktif) Then
    '        Dim tglHariIni As String = DateTime.Today.ToString("yyyy-MM-dd")
    '        Dim queryCekLokal As String = String.Format( _
    '            "SELECT session_code FROM mcu_sessions " & _
    '            "WHERE CONVERT(VARCHAR(10), tgl_mcu, 120) = '{0}' AND status = 'active' " & _
    '            "ORDER BY session_id DESC", tglHariIni)

    '        _sessionCodeAktif = ReadSQLNIK(queryCekLokal).Trim()
    '    End If

    '    ' Jika Sesi MCU lokal tetap tidak ditemukan, izinkan cetak barcode tetap berjalan di lokal
    '    If String.IsNullOrEmpty(_sessionCodeAktif) Then
    '        lblStatusMCU.Text = "MCU Active (Tanpa Sesi) | Mode Lokal Only"
    '        lblStatusMCU.ForeColor = Color.Orange
    '        Exit Sub
    '    End If

    '    ' Fetch WebService URL untuk pengiriman log/post (jika API up)
    '    Dim urlWebService As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")

    '    If String.IsNullOrEmpty(urlWebService) Then
    '        lblStatusMCU.Text = "MCU Non-Aktif (URL WS Kosong)"
    '        lblStatusMCU.ForeColor = Color.Red
    '        Exit Sub
    '    End If

    '    ' =======================================================================
    '    ' 4. CEK STATUS CHECK-IN PESERTA (FAIL-SAFE FLEXIBLE CHECK)
    '    ' =======================================================================
    '    Dim checkInStatusText As String = "pending"
    '    Try
    '        ' Endpoint API
    '        Dim urlCekStatus As String = urlWebService & "api/mcu/check-status?session_code=" & _sessionCodeAktif & "&nik=" & _nikPasienAktif
    '        Dim jsonCekStatus As String = GetDataAPIRM(urlCekStatus)

    '        If Not String.IsNullOrEmpty(jsonCekStatus) Then
    '            Dim jObjStatus As JObject = JObject.Parse(jsonCekStatus)
    '            Dim jDataObj As JObject = TryCast(jObjStatus("data"), JObject)

    '            If jDataObj IsNot Nothing Then
    '                Dim participants As JArray = TryCast(jDataObj("participants"), JArray)

    '                If participants IsNot Nothing AndAlso participants.Count > 0 Then
    '                    Dim participant As JObject = CType(participants(0), JObject)

    '                    If participant("check_in_status") IsNot Nothing Then
    '                        checkInStatusText = participant("check_in_status").ToString().ToLower().Trim()
    '                    ElseIf participant("status") IsNot Nothing Then
    '                        checkInStatusText = participant("status").ToString().ToLower().Trim()
    '                    End If
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '        checkInStatusText = "checked_in_fallback"
    '        System.Diagnostics.Debug.WriteLine("Error Parse Cek Status: " & ex.Message)
    '    End Try

    '    ' Validasi Fleksibel Status Check-in
    '    Dim isSudahCheckIn As Boolean = (checkInStatusText.Contains("check") OrElse _
    '                                     checkInStatusText.Contains("process") OrElse _
    '                                     checkInStatusText = "success")

    '    If Not isSudahCheckIn Then
    '        MessageBox.Show("Peserta belum melakukan CHECK-IN utama (Status: " & checkInStatusText & ")!" & vbCrLf & _
    '                        "Silakan arahkan peserta menuju CHECKIN KIOSK terlebih dahulu.", _
    '                        "Peringatan Check-In", MessageBoxButtons.OK, MessageBoxIcon.Warning)

    '        lblStatusMCU.Text = "MCU Active | Sesi: " & _sessionCodeAktif & " (Belum Check-In Kiosk)"
    '        lblStatusMCU.ForeColor = Color.Orange
    '        Exit Sub
    '    End If

    '    ' =======================================================================
    '    ' 5. CHECK PANEL THORAX & BACKGROUND EXCLUDE
    '    ' =======================================================================
    '    Try
    '        Dim queryCekThorax As String = "SELECT COUNT(1) FROM TransaksiLabDetail td " & _
    '                                       "INNER JOIN mapping_pos mp ON td.TindakanID = mp.TindakanID " & _
    '                                       "WHERE td.TransLabID = '" & idTrans & "' AND LOWER(mp.KodePOS) = 'thorax'"

    '        Dim adaThorax As Integer = Val(ReadSQLNIK(queryCekThorax))
    '        PanelThorax.Visible = (adaThorax > 0)
    '        rdThoraxSetuju.Checked = (adaThorax > 0)
    '        rdThoraxTolak.Checked = False
    '        txtAlasanThorax.Text = ""
    '        txtAlasanThorax.Enabled = False
    '    Catch exThorax As Exception
    '    End Try

    '    Dim paramCheckIn As New CheckInParam With { _
    '            .NoUrutLog = noUrutLog, _
    '            .Nik = _nikPasienAktif, _
    '            .SessionCode = _sessionCodeAktif, _
    '            .UrlCheckIn = urlWebService & "api/mcu/check-in/" & _sessionCodeAktif & "/post/pendaftaran" _
    '        }

    '    ' Kirim request API di background thread agar UI tidak tersendat
    '    System.Threading.ThreadPool.QueueUserWorkItem(AddressOf ProcessPostPendaftaranInBackground, paramCheckIn)

    '    ' 7. FINALIZE STATUS UI
    '    lblStatusMCU.Text = "MCU Active | Sesi HYU!: " & _sessionCodeAktif
    '    lblStatusMCU.ForeColor = Color.Green
    'End Sub

    Private Sub FormCetakBarcode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        ClearHeader()
        LoadSessionCodeLokal()
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        ClearHeader()
    End Sub

    'After Update
    'Private Sub CetakBarcodeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CetakBarcodeToolStripMenuItem.Click
    '    CetakBarcodeToolStripMenuItem.Enabled = False
    '    BarcodeTambahanToolStripMenuItem.Enabled = False

    '    Dim Tpos As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='PathBarcode'")
    '    Dim KodeBarcode As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='KodeBarcode'")
    '    Dim Tpathprf As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='Pathprf'")
    '    Dim Ttx As String = Tpos & "Output.txt"
    '    Dim barcode As String = ""

    '    Try
    '        Dim NoUrut As String = ""
    '        If rdNonMCU.Checked = True Then
    '            NoUrut = "(" & txTransLabID1.Text & ")"
    '        ElseIf rdMCU.Checked = True Then
    '            Dim TblsMCU As DataTable = gridlab.DataSource
    '            NoUrut = ""
    '            Dim TtempMCU As String = "("
    '            For Each TrowMCU As DataRow In TblsMCU.Rows
    '                TtempMCU = TtempMCU & "'" & TrowMCU("TransLabID").ToString.Trim & "',"
    '            Next
    '            NoUrut = Strings.Left(TtempMCU, TtempMCU.Length - 1) & ")"
    '        End If

    '        Dim Tbls2 As DataTable = ReadSQL("SELECT a.NoUrut, a.TransLabID, c.Nama, CONVERT(varchar(11), c.TglLahir,106) as TglLahir, c.JenisKelamin, a.LabSamplingTime " & _
    '                                         "FROM TransaksiLab a " & _
    '                                         "LEFT JOIN MasterPasien c on c.NoRekamMedis = a.IDInternet " & _
    '                                         "WHERE a.TransLabID in " & NoUrut & "")
    '        If Tbls2.Rows.Count > 0 Then
    '            For Each TrowData As DataRow In Tbls2.Rows

    '                ' Cek Tabung
    '                Dim Tgrouping As DataTable = ReadSQL("SELECT distinct Tabung,TabungRef FROM MasterLab WHERE TindakanID in (SELECT distinct TindakanID FROM TransaksiLabDetail WHERE TransLabID='" & TrowData("TransLabID").ToString.Trim & "') and TabungRef is not null and Tabung like '%tabung%' order by Tabung ")

    '                If Tgrouping.Rows.Count > 0 Then
    '                    Dim Ttemp As String = ""
    '                    If TrowData("NoUrut").ToString.Contains("L") = True Then
    '                        Ttemp = Strings.Replace(TrowData("NoUrut").ToString.Trim, "L", "8")
    '                    ElseIf TrowData("NoUrut").ToString.Contains("M") = True Then
    '                        Ttemp = Strings.Replace(TrowData("NoUrut").ToString.Trim, "M", "9")
    '                    Else
    '                        Ttemp = TrowData("NoUrut").ToString.Trim
    '                    End If

    '                    ' Pengaman agar Len - 2 tidak error
    '                    If Ttemp.Length > 2 Then
    '                        barcode = KodeBarcode & Strings.Right(Ttemp, Len(Ttemp) - 2)
    '                    Else
    '                        barcode = KodeBarcode & Ttemp
    '                    End If

    '                    For Each Treply As DataRow In Tgrouping.Rows
    '                        ' Jangan pakai sleep di sini, hapus file dulu
    '                        If System.IO.File.Exists(Ttx) = True Then System.IO.File.Delete(Ttx)

    '                        Dim objStreamWriter As StreamWriter = New StreamWriter(Ttx)
    '                        objStreamWriter.WriteLine("<xpml><page quantity='0' pitch='29.3 mm'></xpml>I8,A")
    '                        objStreamWriter.WriteLine("ZN")
    '                        objStreamWriter.WriteLine("q275")
    '                        objStreamWriter.WriteLine("S3")
    '                        objStreamWriter.WriteLine("O")
    '                        objStreamWriter.WriteLine("JF")
    '                        objStreamWriter.WriteLine("D9")
    '                        objStreamWriter.WriteLine("ZT")
    '                        objStreamWriter.WriteLine("Q234,B24")
    '                        objStreamWriter.WriteLine("KI80")
    '                        objStreamWriter.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='29.3 mm'></xpml>N")

    '                        If Treply("TabungRef").ToString <> "" Then
    '                            objStreamWriter.WriteLine("B290,177,2,1,2,4,97,N,""" & barcode & Treply("TabungRef").ToString & """")
    '                        Else
    '                            objStreamWriter.WriteLine("B290,177,2,1,2,4,97,N,""" & barcode & """")
    '                        End If

    '                        objStreamWriter.WriteLine("A95,217,2,3,1,1,N,""""""")
    '                        objStreamWriter.WriteLine("A95,30,2,3,1,1,N,""" & Treply("Tabung").ToString & """")
    '                        objStreamWriter.WriteLine("A290,54,2,2,1,1,N,""" & TrowData("Nama").ToString.Trim & """")
    '                        objStreamWriter.WriteLine("A290,30,2,2,1,1,N,""" & TrowData("TglLahir").ToString.Trim & " / " & TrowData("JenisKelamin").ToString.Trim & """")

    '                        If Treply("TabungRef").ToString <> "" Then
    '                            objStreamWriter.WriteLine("A290,217,2,3,1,1,N,""" & barcode & Treply("TabungRef").ToString & """")
    '                        Else
    '                            objStreamWriter.WriteLine("A290,217,2,3,1,1,N,""" & barcode & """")
    '                        End If

    '                        objStreamWriter.WriteLine("P1")
    '                        objStreamWriter.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
    '                        objStreamWriter.Close()

    '                        ' Eksekusi cetak tabung
    '                        Process.Start(Tpathprf & "PrFile32.exe ", Ttx)

    '                        ' JEDA AMAN agar proses tabung masuk memori printer sebelum lanjut (PENTING!)
    '                        System.Threading.Thread.Sleep(1000)
    '                    Next
    '                End If

    '                ' =========================================================
    '                ' Cetak Barcode InBody
    '                ' =========================================================
    '                If CheckBoxInbody.Checked = True Then
    '                    Dim TtxInBody As String = Tpos & "OutputInBody.txt"
    '                    Dim barcodeInBody As String = TrowData("NoUrut").ToString.Trim

    '                    If System.IO.File.Exists(TtxInBody) Then System.IO.File.Delete(TtxInBody)

    '                    Using writer As New StreamWriter(TtxInBody, False)
    '                        writer.WriteLine("<xpml><page quantity='0' pitch='29.3 mm'></xpml>I8,A")
    '                        writer.WriteLine("ZN")
    '                        writer.WriteLine("q275")
    '                        writer.WriteLine("S3")
    '                        writer.WriteLine("O")
    '                        writer.WriteLine("JF")
    '                        writer.WriteLine("D9")
    '                        writer.WriteLine("ZT")
    '                        writer.WriteLine("Q234,B24")
    '                        writer.WriteLine("KI80")
    '                        writer.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='29.3 mm'></xpml>N")
    '                        writer.WriteLine("B290,177,2,1,2,4,97,N,""" & barcodeInBody & """")
    '                        writer.WriteLine("A95,30,2,3,1,1,N,""InBody""")
    '                        writer.WriteLine("A290,54,2,2,1,1,N,""" & TrowData("Nama").ToString.Trim & """")
    '                        writer.WriteLine("A290,30,2,2,1,1,N,""" & TrowData("TglLahir").ToString.Trim & " / " & TrowData("JenisKelamin").ToString.Trim & """")
    '                        writer.WriteLine("A290,217,2,3,1,1,N,""" & barcodeInBody & """")
    '                        writer.WriteLine("P1")
    '                        writer.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
    '                    End Using

    '                    ' Eksekusi cetak Inbody
    '                    Process.Start(Tpathprf & "PrFile32.exe ", TtxInBody)

    '                    ' JEDA AMAN jika loop berlanjut ke pasien lain
    '                    System.Threading.Thread.Sleep(1000)
    '                End If

    '                ' Update Status
    '                If IsDBNull(TrowData("LabSamplingTime")) = True Then
    '                    WriteSQL("update TransaksiLab set SendKeu=1, [Status]='CHECK', LabSamplingTime=getdate() WHERE TransLabID='" & TrowData("TransLabID").ToString.Trim & "' ", 4)
    '                Else
    '                    WriteSQL("update TransaksiLab set SendKeu=1, [Status]='CHECK' WHERE TransLabID='" & TrowData("TransLabID").ToString.Trim & "' ", 4)
    '                End If
    '            Next
    '        End If

    '        CetakBarcodeToolStripMenuItem.Enabled = True
    '        BarcodeTambahanToolStripMenuItem.Enabled = True
    '    Catch ex As Exception
    '        CetakBarcodeToolStripMenuItem.Enabled = True
    '        BarcodeTambahanToolStripMenuItem.Enabled = True
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Private Sub CetakBarcodeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CetakBarcodeToolStripMenuItem.Click
        CetakBarcodeToolStripMenuItem.Enabled = False
        BarcodeTambahanToolStripMenuItem.Enabled = False

        Dim Tpos As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='PathBarcode'")
        Dim KodeBarcode As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='KodeBarcode'")
        Dim Tpathprf As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='Pathprf'")
        Dim Ttx As String = Tpos & "Output.txt"
        Dim barcode As String = ""

        Try
            Dim NoUrut As String = ""
            If rdNonMCU.Checked = True Then
                NoUrut = "(" & txTransLabID1.Text & ")"
            ElseIf rdMCU.Checked = True Then
                Dim TblsMCU As DataTable = gridlab.DataSource
                NoUrut = ""
                Dim TtempMCU As String = "("
                For Each TrowMCU As DataRow In TblsMCU.Rows
                    TtempMCU = TtempMCU & "'" & TrowMCU("TransLabID").ToString.Trim & "',"
                Next
                NoUrut = Strings.Left(TtempMCU, TtempMCU.Length - 1) & ")"
            End If

            Dim Tbls2 As DataTable = ReadSQL("SELECT a.NoUrut, a.TransLabID, c.Nama, c.TglLahir, c.JenisKelamin, a.LabSamplingTime " & _
                                             "FROM TransaksiLab a " & _
                                             "LEFT JOIN MasterPasien c on c.NoRekamMedis = a.IDInternet " & _
                                             "WHERE a.TransLabID in " & NoUrut & "")
            If Tbls2.Rows.Count > 0 Then
                For Each TrowData As DataRow In Tbls2.Rows

                    Dim tabung As Boolean = False
                    If cbtabung.Checked = True Then
                        Dim TcheckTabung As DataTable = ReadSQL("SELECT distinct Tabung,TabungRef FROM MasterLab WHERE TindakanID in (SELECT distinct TindakanID FROM TransaksiLabDetail WHERE TransLabID='" & TrowData("TransLabID").ToString.Trim & "') and TabungRef is not null and Tabung like '%tabung%' order by Tabung ")
                        If TcheckTabung.Rows.Count > 0 Then tabung = True
                    End If

                    If tabung = True Then
                        CetakTabung(TrowData("NoUrut").ToString.Trim)
                        System.Threading.Thread.Sleep(2000)
                    End If

                    If CheckBoxAktivo.Checked = True Then
                        Dim usia As Integer = 0
                        If Not IsDBNull(TrowData("TglLahir")) Then
                            Dim tglLahir As Date = CDate(TrowData("TglLahir"))
                            usia = DateTime.Now.Year - tglLahir.Year
                            If DateTime.Now < tglLahir.AddYears(usia) Then usia -= 1
                        End If

                        Dim gender As String = TrowData("JenisKelamin").ToString.Trim.ToUpper()
                        If gender.Contains("L") Or gender.Contains("PRIA") Or gender.Contains("MALE") Then
                            gender = "Male"
                        Else
                            gender = "Female"
                        End If

                        Dim qrContent As String = TrowData("NoUrut").ToString.Trim & "#" & _
                                                  TrowData("Nama").ToString.Trim & "#" & _
                                                  usia.ToString() & "#" & _
                                                  gender

                        Dim TtxAktivo As String = Tpos & "OutputAktivo.txt"
                        If System.IO.File.Exists(TtxAktivo) = True Then System.IO.File.Delete(TtxAktivo)

                        Dim writerAktivo As New StreamWriter(TtxAktivo)
                        writerAktivo.WriteLine("<xpml><page quantity='0' pitch='29.3 mm'></xpml>I8,A")
                        writerAktivo.WriteLine("ZN")
                        writerAktivo.WriteLine("q275")
                        writerAktivo.WriteLine("S3")
                        writerAktivo.WriteLine("O")
                        writerAktivo.WriteLine("JF")
                        writerAktivo.WriteLine("D9")
                        writerAktivo.WriteLine("ZT")
                        writerAktivo.WriteLine("Q234,B24")
                        writerAktivo.WriteLine("KI80")
                        writerAktivo.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='29.3 mm'></xpml>")
                        writerAktivo.WriteLine("N")

                        writerAktivo.WriteLine("b100,80,Q,m2,g5,s3,""" & qrContent & """")

                        writerAktivo.WriteLine("A95,217,2,3,1,1,N," & Chr(34) & Chr(34))
                        writerAktivo.WriteLine("A95,30,2,3,1,1,N,""QR P.Fisik""")
                        writerAktivo.WriteLine("A290,54,2,2,1,1,N,""" & TrowData("Nama").ToString.Trim & """")

                        Dim tglTampil As String = If(IsDBNull(TrowData("TglLahir")), "", CDate(TrowData("TglLahir")).ToString("dd MMM yyyy"))
                        writerAktivo.WriteLine("A290,30,2,2,1,1,N,""" & tglTampil & " / " & TrowData("JenisKelamin").ToString.Trim & """")
                        writerAktivo.WriteLine("A290,217,2,3,1,1,N,""" & TrowData("NoUrut").ToString.Trim & """")

                        writerAktivo.WriteLine("P1")
                        writerAktivo.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
                        writerAktivo.Close()

                        Process.Start(Tpathprf & "PrFile32.exe ", TtxAktivo)
                        System.Threading.Thread.Sleep(1000)
                    End If

                    Dim Tgrouping As DataTable = ReadSQL("SELECT distinct Tabung,TabungRef FROM MasterLab WHERE TindakanID in (SELECT distinct TindakanID FROM TransaksiLabDetail WHERE TransLabID='" & TrowData("TransLabID").ToString.Trim & "') and TabungRef is not null and Tabung like '%tabung%' order by Tabung ")

                    If Tgrouping.Rows.Count > 0 Then
                        Dim Ttemp As String = ""
                        If TrowData("NoUrut").ToString.Contains("L") = True Then
                            Ttemp = Strings.Replace(TrowData("NoUrut").ToString.Trim, "L", "8")
                        ElseIf TrowData("NoUrut").ToString.Contains("M") = True Then
                            Ttemp = Strings.Replace(TrowData("NoUrut").ToString.Trim, "M", "9")
                        Else
                            Ttemp = TrowData("NoUrut").ToString.Trim
                        End If

                        If Ttemp.Length > 2 Then
                            barcode = KodeBarcode & Strings.Right(Ttemp, Len(Ttemp) - 2)
                        Else
                            barcode = KodeBarcode & Ttemp
                        End If

                        For Each Treply As DataRow In Tgrouping.Rows
                            If System.IO.File.Exists(Ttx) = True Then System.IO.File.Delete(Ttx)

                            Dim objStreamWriter As StreamWriter = New StreamWriter(Ttx)
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

                            ' Kembali menggunakan Cetak Barcode Garis Bawaan Anda Semula
                            If Treply("TabungRef").ToString <> "" Then
                                objStreamWriter.WriteLine("B290,177,2,1,2,4,97,N,""" & barcode & Treply("TabungRef").ToString & """")
                            Else
                                objStreamWriter.WriteLine("B290,177,2,1,2,4,97,N,""" & barcode & """")
                            End If

                            objStreamWriter.WriteLine("A95,217,2,3,1,1,N," & Chr(34) & Chr(34))
                            objStreamWriter.WriteLine("A95,30,2,3,1,1,N,""" & Treply("Tabung").ToString & """")
                            objStreamWriter.WriteLine("A290,54,2,2,1,1,N,""" & TrowData("Nama").ToString.Trim & """")

                            Dim tglTampil As String = If(IsDBNull(TrowData("TglLahir")), "", CDate(TrowData("TglLahir")).ToString("dd MMM yyyy"))
                            objStreamWriter.WriteLine("A290,30,2,2,1,1,N,""" & tglTampil & " / " & TrowData("JenisKelamin").ToString.Trim & """")
                            objStreamWriter.WriteLine("A290,217,2,3,1,1,N,""" & TrowData("NoUrut").ToString.Trim & """")

                            objStreamWriter.WriteLine("P1")
                            objStreamWriter.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
                            objStreamWriter.Close()

                            Process.Start(Tpathprf & "PrFile32.exe ", Ttx)
                            System.Threading.Thread.Sleep(1000)
                        Next
                    End If

                    If CheckBoxInbody.Checked = True Then
                        Dim TtxInBody As String = Tpos & "OutputInBody.txt"
                        Dim barcodeInBody As String = TrowData("NoUrut").ToString.Trim

                        If System.IO.File.Exists(TtxInBody) Then System.IO.File.Delete(TtxInBody)

                        Using writer As New StreamWriter(TtxInBody, False)
                            writer.WriteLine("<xpml><page quantity='0' pitch='29.3 mm'></xpml>I8,A")
                            writer.WriteLine("ZN")
                            writer.WriteLine("q275")
                            writer.WriteLine("S3")
                            writer.WriteLine("O")
                            writer.WriteLine("JF")
                            writer.WriteLine("D9")
                            writer.WriteLine("ZT")
                            writer.WriteLine("Q234,B24")
                            writer.WriteLine("KI80")
                            writer.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='29.3 mm'></xpml>N")
                            writer.WriteLine("B290,177,2,1,2,4,97,N,""" & barcodeInBody & """")
                            writer.WriteLine("A95,30,2,3,1,1,N,""" & "InBody" & """")
                            writer.WriteLine("A290,54,2,2,1,1,N,""" & TrowData("Nama").ToString.Trim & """")
                            Dim tglTampil As String = If(IsDBNull(TrowData("TglLahir")), "", CDate(TrowData("TglLahir")).ToString("dd MMM yyyy"))
                            writer.WriteLine("A290,30,2,2,1,1,N,""" & tglTampil & " / " & TrowData("JenisKelamin").ToString.Trim & """")
                            writer.WriteLine("A290,217,2,3,1,1,N,""" & barcodeInBody & """")
                            writer.WriteLine("P1")
                            writer.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
                        End Using

                        Process.Start(Tpathprf & "PrFile32.exe ", TtxInBody)
                        System.Threading.Thread.Sleep(1000)
                    End If

                    If IsDBNull(TrowData("LabSamplingTime")) = True Then
                        WriteSQL("update TransaksiLab set SendKeu=1, [Status]='CHECK', LabSamplingTime=getdate() WHERE TransLabID='" & TrowData("TransLabID").ToString.Trim & "' ", 4)
                    Else
                        WriteSQL("update TransaksiLab set SendKeu=1, [Status]='CHECK' WHERE TransLabID='" & TrowData("TransLabID").ToString.Trim & "' ", 4)
                    End If

                    Dim currentTransLabID As String = txtindakanid.Text
                    Dim urlWebService As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")

                    If rdNonMCU.Checked = True AndAlso Not String.IsNullOrEmpty(_sessionCodeAktif) Then

                        ' 1. API PENDAFTARAN (COMPLETED)
                        Dim urlCheckIn As String = urlWebService & "api/mcu/check-in/" & _sessionCodeAktif & "/post/pendaftaran"
                        Dim jsonCheckIn As String = ""

                        Try
                            jsonCheckIn = "{" & _
                                """identifier"":""" & _nikPasienAktif & """," & _
                                """identifier_type"":""nik""," & _
                                """status"":""completed""," & _
                                """notes"":""-""" & _
                                "}"

                            Dim resCheckIn As String = InsertDataAPIRM(jsonCheckIn, urlCheckIn)
                            Dim jObjRes As JObject = JObject.Parse(resCheckIn)
                            Dim msgTampil As String = "Status Pendaftaran berhasil dikirim ke HYU!"

                            If jObjRes("message") IsNot Nothing Then
                                msgTampil = jObjRes("message").ToString()
                            End If

                            MsgBox(msgTampil, MsgBoxStyle.Information, "Sukses API")

                            WriteSQL("INSERT INTO log_api_checkin (no_urut, nik, session_code, url_api, payload, response, status_log, created_date) " & _
                                "VALUES ('" & currentTransLabID & "', '" & _nikPasienAktif & "', '" & _sessionCodeAktif & "', '" & urlCheckIn & "', '" & jsonCheckIn.Replace("'", "''") & "', '" & resCheckIn.Replace("'", "''") & "', 'SUCCESS', GETDATE())", 4)

                        Catch exAPI As Exception
                            MsgBox("Gagal mengirim data pendaftaran ke API: " & exAPI.Message, MsgBoxStyle.Critical, "Debug API")

                            WriteSQL("INSERT INTO log_api_checkin (no_urut, nik, session_code, url_api, payload, response, status_log, created_date) " & _
                                "VALUES ('" & currentTransLabID & "', '" & _nikPasienAktif & "', '" & _sessionCodeAktif & "', '" & urlCheckIn & "', '" & jsonCheckIn.Replace("'", "''") & "', '" & exAPI.Message.Replace("'", "''") & "', 'FAILED', GETDATE())", 4)
                        End Try

                        ' 2. API URINE (DARI PENOLAKAN / HAID)
                        If RadioButtonHaid.Checked = True Then
                            Dim urlHaid As String = urlWebService & "api/mcu/check-in/" & _sessionCodeAktif & "/post/urine"
                            Dim jsonHaid As String = ""

                            Try
                                jsonHaid = "{" & _
                                    """identifier"":""" & _nikPasienAktif & """," & _
                                    """identifier_type"":""nik""," & _
                                    """status"":""skipped""," & _
                                    """notes"":""Sedang haid""" & _
                                    "}"

                                Dim resHaid As String = InsertDataAPIRM(jsonHaid, urlHaid)

                                MsgBox("Otomatisasi API: Status POS Urine berhasil di-skip karena Haid.", MsgBoxStyle.Information, "Sukses")

                                WriteSQL("INSERT INTO log_api_checkin (no_urut, nik, session_code, url_api, payload, response, status_log, created_date) " & _
                                    "VALUES ('" & currentTransLabID & "', '" & _nikPasienAktif & "', '" & _sessionCodeAktif & "', '" & urlHaid & "', '" & jsonHaid.Replace("'", "''") & "', '" & resHaid.Replace("'", "''") & "', 'SUCCESS_HAID', GETDATE())", 4)
                            Catch exHaid As Exception
                                MsgBox("Gagal otomatisasi skip POS Urine: " & exHaid.Message, MsgBoxStyle.Critical, "Debug API")

                                WriteSQL("INSERT INTO log_api_checkin (no_urut, nik, session_code, url_api, payload, response, status_log, created_date) " & _
                                    "VALUES ('" & currentTransLabID & "', '" & _nikPasienAktif & "', '" & _sessionCodeAktif & "', '" & urlHaid & "', '" & jsonHaid.Replace("'", "''") & "', '" & exHaid.Message.Replace("'", "''") & "', 'FAILED_HAID', GETDATE())", 4)
                            End Try
                        End If

                        ' 3. API THORAX (DARI PENOLAKAN PASIEN ATAU HAMIL)
                        If rdThoraxTolak.Checked = True Then
                            Dim urlThorax As String = urlWebService & "api/mcu/check-in/" & _sessionCodeAktif & "/post/thorax"

                            Dim alasanBatal As String = txtAlasanThorax.Text.Trim()
                            If String.IsNullOrEmpty(alasanBatal) Then alasanBatal = "Pasien Menolak/Tidak Setuju Tindakan Thorax"
                            alasanBatal = alasanBatal.Replace("""", "\""")

                            Dim jsonThorax As String = ""

                            Try
                                jsonThorax = "{" & _
                                    """identifier"":""" & _nikPasienAktif & """," & _
                                    """identifier_type"":""nik""," & _
                                    """status"":""skipped""," & _
                                    """notes"":""" & alasanBatal & """" & _
                                    "}"

                                Dim resThorax As String = InsertDataAPIRM(jsonThorax, urlThorax)
                                MsgBox("Otomatisasi API: Status POS Thorax berhasil di-skip (" & alasanBatal & ").", MsgBoxStyle.Information, "Sukses API")

                                WriteSQL("INSERT INTO log_api_checkin (no_urut, nik, session_code, url_api, payload, response, status_log, created_date) " & _
                                         "VALUES ('" & currentTransLabID & "', '" & _nikPasienAktif & "', '" & _sessionCodeAktif & "', '" & urlThorax & "', '" & jsonThorax.Replace("'", "''") & "', '" & resThorax.Replace("'", "''") & "', 'SUCCESS_THORAX_SKIP', GETDATE())", 4)

                            Catch exThorax As Exception
                                MsgBox("Gagal kirim skip POS Thorax: " & exThorax.Message, MsgBoxStyle.Critical, "Debug API")

                                WriteSQL("INSERT INTO log_api_checkin (no_urut, nik, session_code, url_api, payload, response, status_log, created_date) " & _
                                         "VALUES ('" & currentTransLabID & "', '" & _nikPasienAktif & "', '" & _sessionCodeAktif & "', '" & urlThorax & "', '" & jsonThorax.Replace("'", "''") & "', '" & exThorax.Message.Replace("'", "''") & "', 'FAILED_THORAX_SKIP', GETDATE())", 4)
                            End Try

                        ElseIf RadioButtonHamil.Checked = True Then
                            Try
                                Dim urlHamil As String = urlWebService & "api/mcu/check-in/" & _sessionCodeAktif & "/post/thorax"

                                Dim jsonHamil As String = "{" & _
                                    """identifier"":""" & _nikPasienAktif & """," & _
                                    """identifier_type"":""nik""," & _
                                    """status"":""skipped""," & _
                                    """notes"":""Sedang hamil""" & _
                                    "}"

                                Dim resHamil As String = InsertDataAPIRM(jsonHamil, urlHamil)
                                MsgBox("Otomatisasi API: Status POS Thorax berhasil di-skip karena Hamil.", MsgBoxStyle.Information, "Sukses")

                                WriteSQL("INSERT INTO log_api_checkin (no_urut, nik, session_code, url_api, payload, response, status_log, created_date) " & _
                                         "VALUES ('" & currentTransLabID & "', '" & _nikPasienAktif & "', '" & _sessionCodeAktif & "', '" & urlHamil & "', '" & jsonHamil.Replace("'", "''") & "', '" & resHamil.Replace("'", "''") & "', 'SUCCESS_HAMIL', GETDATE())", 4)
                            Catch exHamil As Exception
                                MsgBox("Gagal otomatisasi skip POS Thorax: " & exHamil.Message, MsgBoxStyle.Critical, "Debug API")
                            End Try
                        End If

                    End If
                Next
            End If

            CetakBarcodeToolStripMenuItem.Enabled = True
            BarcodeTambahanToolStripMenuItem.Enabled = True
        Catch ex As Exception
            CetakBarcodeToolStripMenuItem.Enabled = True
            BarcodeTambahanToolStripMenuItem.Enabled = True
            MsgBox(ex.Message)
        End Try
    End Sub

    'Before Update
    'Private Sub CetakBarcodeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CetakBarcodeToolStripMenuItem.Click
    '    CetakBarcodeToolStripMenuItem.Enabled = False
    '    BarcodeTambahanToolStripMenuItem.Enabled = False

    '    Dim Tpos As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='PathBarcode'")
    '    Dim KodeBarcode As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='KodeBarcode'")
    '    Dim Tpathprf As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='Pathprf'")
    '    Dim Ttx As String = Tpos & "Output.txt"
    '    Dim barcode As String = ""

    '    Try
    '        Dim NoUrut As String = ""
    '        If rdNonMCU.Checked = True Then
    '            NoUrut = "(" & txTransLabID1.Text & ")"
    '        ElseIf rdMCU.Checked = True Then
    '            Dim TblsMCU As DataTable = gridlab.DataSource
    '            NoUrut = ""
    '            Dim Ttemp As String = "("
    '            For Each TrowMCU As DataRow In TblsMCU.Rows
    '                Ttemp = Ttemp & "'" & TrowMCU("TransLabID").ToString.Trim & "',"
    '            Next
    '            NoUrut = Strings.Left(Ttemp, Ttemp.Length - 1) & ")"
    '        End If

    '        Dim Tbls2 As DataTable = ReadSQL("SELECT a.NoUrut, a.TransLabID, c.Nama, CONVERT(varchar(11), c.TglLahir,106) as TglLahir, c.JenisKelamin, a.LabSamplingTime " & _
    '                                         "FROM TransaksiLab a " & _
    '                                         "LEFT JOIN MasterPasien c on c.NoRekamMedis = a.IDInternet " & _
    '                                         "WHERE a.TransLabID in " & NoUrut & "")
    '        If Tbls2.Rows.Count > 0 Then
    '            For Each TrowData As DataRow In Tbls2.Rows
    '                Dim Tgrouping As DataTable = ReadSQL("SELECT distinct Tabung,TabungRef FROM MasterLab WHERE TindakanID in (SELECT distinct TindakanID FROM TransaksiLabDetail WHERE TransLabID='" & TrowData("TransLabID").ToString.Trim & "') and TabungRef is not null and Tabung like '%tabung%' order by Tabung ")

    '                If Tgrouping.Rows.Count > 0 Then
    '                    Dim Ttemp As String = ""
    '                    If TrowData("NoUrut").ToString.Contains("L") = True Then
    '                        Ttemp = Strings.Replace(TrowData("NoUrut").ToString.Trim, "L", "8")
    '                    ElseIf TrowData("NoUrut").ToString.Contains("M") = True Then
    '                        Ttemp = Strings.Replace(TrowData("NoUrut").ToString.Trim, "M", "9")
    '                    End If

    '                    barcode = KodeBarcode & Strings.Right(Ttemp.ToString.Trim, Len(Ttemp.ToString.Trim) - 2)

    '                    For Each Treply As DataRow In Tgrouping.Rows

    '                        System.Threading.Thread.Sleep(500)

    '                        If System.IO.File.Exists(Ttx) = True Then System.IO.File.Delete(Ttx)

    '                        Dim objStreamWriter As StreamWriter
    '                        objStreamWriter = New StreamWriter(Ttx)

    '                        objStreamWriter.WriteLine("<xpml><page quantity='0' pitch='29.3 mm'></xpml>I8,A")
    '                        objStreamWriter.WriteLine("ZN")
    '                        objStreamWriter.WriteLine("q275")
    '                        objStreamWriter.WriteLine("S3")
    '                        objStreamWriter.WriteLine("O")
    '                        objStreamWriter.WriteLine("JF")
    '                        objStreamWriter.WriteLine("D9")
    '                        objStreamWriter.WriteLine("ZT")
    '                        objStreamWriter.WriteLine("Q234,B24")
    '                        objStreamWriter.WriteLine("KI80")
    '                        objStreamWriter.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='29.3 mm'></xpml>N")

    '                        If Treply("TabungRef").ToString <> "" Then
    '                            objStreamWriter.WriteLine("B290,177,2,1,2,4,97,N,""" & barcode & Treply("TabungRef").ToString & """")
    '                        Else
    '                            objStreamWriter.WriteLine("B290,177,2,1,2,4,97,N,""" & barcode & """")
    '                        End If

    '                        objStreamWriter.WriteLine("A95,217,2,3,1,1,N,""""""")
    '                        objStreamWriter.WriteLine("A95,30,2,3,1,1,N,""" & Treply("Tabung").ToString & """")
    '                        objStreamWriter.WriteLine("A290,54,2,2,1,1,N,""" & TrowData("Nama").ToString.Trim & """")
    '                        objStreamWriter.WriteLine("A290,30,2,2,1,1,N,""" & TrowData("TglLahir").ToString.Trim & " / " & TrowData("JenisKelamin").ToString.Trim & """")

    '                        If Treply("TabungRef").ToString <> "" Then
    '                            objStreamWriter.WriteLine("A290,217,2,3,1,1,N,""" & barcode & Treply("TabungRef").ToString & """")
    '                        Else
    '                            objStreamWriter.WriteLine("A290,217,2,3,1,1,N,""" & barcode & """")
    '                        End If

    '                        objStreamWriter.WriteLine("P1")
    '                        objStreamWriter.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
    '                        objStreamWriter.Close()
    '                        Process.Start(Tpathprf & "PrFile32.exe ", Ttx)
    '                    Next

    '                    If IsDBNull(TrowData("LabSamplingTime")) = True Then
    '                        WriteSQL("update TransaksiLab set SendKeu=1, [Status]='CHECK', LabSamplingTime=getdate() WHERE TransLabID='" & TrowData("TransLabID").ToString.Trim & "' ", 4)
    '                    Else
    '                        WriteSQL("update TransaksiLab set SendKeu=1, [Status]='CHECK' WHERE TransLabID='" & TrowData("TransLabID").ToString.Trim & "' ", 4)
    '                    End If
    '                End If
    '            Next
    '        End If

    '        CetakBarcodeToolStripMenuItem.Enabled = True
    '        BarcodeTambahanToolStripMenuItem.Enabled = True
    '    Catch ex As Exception
    '        CetakBarcodeToolStripMenuItem.Enabled = True
    '        BarcodeTambahanToolStripMenuItem.Enabled = True
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    'OLD
    'Private Sub BarcodeTambahanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarcodeTambahanToolStripMenuItem.Click
    '    CetakBarcodeToolStripMenuItem.Enabled = False
    '    BarcodeTambahanToolStripMenuItem.Enabled = False

    '    Dim Tpos As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='PathBarcode'")
    '    Dim KodeBarcode As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='KodeBarcode'")
    '    Dim Tpathprf As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='Pathprf'")
    '    Dim Ttx As String = Tpos & "Output.txt"
    '    Dim barcode As String = ""
    '    Dim totalrow As Integer = 0

    '    Dim Tinput As String = InputBox("Tambahan Cetakan Print Barcode : ", "Print Barcode", 2)
    '    If IsNumeric(Tinput) = False Then
    '        MsgBox("Masukkan Jumlah Barcode yang diprint.", MsgBoxStyle.Exclamation, "Warning!")
    '        ClearHeader()
    '        Exit Sub
    '    End If

    '    If CInt(Tinput) = 0 Then
    '        ClearHeader()
    '        Exit Sub
    '    End If

    '    If CInt(Tinput) > 15 Then
    '        MsgBox("Cetakan tidak boleh lebih dari 15.", MsgBoxStyle.Exclamation, "Warning!")
    '        ClearHeader()
    '        Exit Sub
    '    End If

    '    Try
    '        If Tinput > 0 Then
    '            Dim NoUrut As String = ""
    '            If rdNonMCU.Checked = True Then
    '                NoUrut = "(" & txTransLabID1.Text & ")"
    '            ElseIf rdMCU.Checked = True Then
    '                Dim TblsMCU As DataTable = gridlab.DataSource
    '                NoUrut = ""
    '                Dim Ttemp As String = "("
    '                For Each TrowMCU As DataRow In TblsMCU.Rows
    '                    Ttemp = Ttemp & "'" & TrowMCU("TransLabID").ToString.Trim & "',"
    '                    totalrow = totalrow + 1
    '                Next
    '                NoUrut = Strings.Left(Ttemp, Ttemp.Length - 1) & ")"
    '            End If

    '            If totalrow * Tinput > 500 Then
    '                MsgBox("Total barcode tidak boleh lebih dari 500 cetakan, total barcode anda adalah " & totalrow & " data x " & Tinput & " cetakan = " & totalrow * Tinput & " cetakan barcode.", MsgBoxStyle.Exclamation, "Warning!")
    '                Exit Sub
    '            End If

    '            Dim Tbls2 As DataTable = ReadSQL("SELECT a.NoUrut,a.TransLabID,c.Nama,CONVERT(varchar(11),c.TglLahir,106) as TglLahir,c.JenisKelamin, a.LabSamplingTime " & _
    '                                             "FROM TransaksiLab a " & _
    '                                             "LEFT JOIN MasterPasien c on c.NoRekamMedis=a.IDInternet " & _
    '                                             "WHERE a.TransLabID in " & NoUrut & "")
    '            If Tbls2.Rows.Count > 0 Then
    '                For Each TrowData As DataRow In Tbls2.Rows
    '                    Dim tabung As Boolean = False
    '                    If cbtabung.Checked = True Then
    '                        'Cek Tabung
    '                        Dim Tgrouping As DataTable = ReadSQL("SELECT distinct Tabung,TabungRef FROM MasterLab WHERE TindakanID in (SELECT distinct TindakanID FROM TransaksiLabDetail WHERE TransLabID='" & TrowData("TransLabID").ToString.Trim & "') and TabungRef is not null and Tabung like '%tabung%' order by Tabung ")

    '                        If Tgrouping.Rows.Count > 0 Then tabung = True
    '                    End If

    '                    If tabung = True Then CetakTabung(TrowData("NoUrut").ToString.Trim)

    '                    Dim Tstrtemp As String = ""
    '                    If TrowData("NoUrut").ToString.Contains("L") = True Then
    '                        Tstrtemp = Strings.Replace(TrowData("NoUrut").ToString.Trim, "L", "8")
    '                    ElseIf TrowData("NoUrut").ToString.Contains("M") = True Then
    '                        Tstrtemp = Strings.Replace(TrowData("NoUrut").ToString.Trim, "M", "9")
    '                    End If

    '                    barcode = KodeBarcode & Strings.Right(Tstrtemp.ToString.Trim, Len(Tstrtemp.ToString.Trim) - 2)

    '                    If tabung = True Then
    '                        System.Threading.Thread.Sleep(3000)
    '                    Else
    '                        System.Threading.Thread.Sleep(500)
    '                    End If

    '                    For i As Integer = 0 To CInt(Tinput) - 1
    '                        If System.IO.File.Exists(Ttx) = True Then System.IO.File.Delete(Ttx)
    '                        Dim objStreamWriter As StreamWriter
    '                        objStreamWriter = New StreamWriter(Ttx)
    '                        objStreamWriter.WriteLine("<xpml><page quantity='0' pitch='29.3 mm'></xpml>I8,A")
    '                        objStreamWriter.WriteLine("ZN")
    '                        objStreamWriter.WriteLine("q275")
    '                        objStreamWriter.WriteLine("S3")
    '                        objStreamWriter.WriteLine("O")
    '                        objStreamWriter.WriteLine("JF")
    '                        objStreamWriter.WriteLine("D9")
    '                        objStreamWriter.WriteLine("ZT")
    '                        objStreamWriter.WriteLine("Q234,B24")
    '                        objStreamWriter.WriteLine("KI80")
    '                        objStreamWriter.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='29.3 mm'></xpml>")
    '                        objStreamWriter.WriteLine("N")
    '                        objStreamWriter.WriteLine("B290,177,2,1,2,4,97,N,""" & barcode & """")
    '                        objStreamWriter.WriteLine("A95,217,2,3,1,1,N,""""""")
    '                        objStreamWriter.WriteLine("A290,54,2,2,1,1,N,""" & TrowData("Nama").ToString.Trim & """")

    '                        Dim tglTampil As String = If(IsDBNull(TrowData("TglLahir")), "", CDate(TrowData("TglLahir")).ToString("dd MMM yyyy"))
    '                        objStreamWriter.WriteLine("A290,30,2,2,1,1,N,""" & tglTampil & " / " & TrowData("JenisKelamin").ToString.Trim & """")
    '                        objStreamWriter.WriteLine("A290,217,2,3,1,1,N,""" & barcode & """")
    '                        objStreamWriter.WriteLine("P1")
    '                        objStreamWriter.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
    '                        objStreamWriter.Close()

    '                        'If tabung = True Then System.Threading.Thread.Sleep(1000)
    '                        If tabung = True Then
    '                            System.Threading.Thread.Sleep(1000)
    '                        Else
    '                            System.Threading.Thread.Sleep(500)
    '                        End If

    '                        Process.Start(Tpathprf & "PrFile32.exe ", Ttx)
    '                    Next

    '                    'Cetak Aktivo
    '                    If CheckBoxAktivo.Checked = True Then
    '                        ' Hitung Usia Pasien
    '                        Dim usia As Integer = 0
    '                        If Not IsDBNull(TrowData("TglLahir")) Then
    '                            Dim tglLahir As Date = CDate(TrowData("TglLahir"))
    '                            usia = DateTime.Now.Year - tglLahir.Year
    '                            If DateTime.Now < tglLahir.AddYears(usia) Then usia -= 1
    '                        End If

    '                        ' Standarisasi Gender (Male / Female)
    '                        Dim gender As String = TrowData("JenisKelamin").ToString.Trim.ToUpper()
    '                        If gender.Contains("L") Or gender.Contains("PRIA") Or gender.Contains("MALE") Then
    '                            gender = "Male"
    '                        Else
    '                            gender = "Female"
    '                        End If

    '                        ' Susun data string format Aktivo
    '                        Dim qrContent As String = TrowData("NoUrut").ToString.Trim & "#" & _
    '                                                  TrowData("Nama").ToString.Trim & "#" & _
    '                                                  usia.ToString() & "#" & _
    '                                                  gender

    '                        Dim TtxAktivo As String = Tpos & "OutputAktivo.txt"
    '                        If System.IO.File.Exists(TtxAktivo) = True Then System.IO.File.Delete(TtxAktivo)

    '                        Dim writerAktivo As New StreamWriter(TtxAktivo)
    '                        writerAktivo.WriteLine("<xpml><page quantity='0' pitch='29.3 mm'></xpml>I8,A")
    '                        writerAktivo.WriteLine("ZN")
    '                        writerAktivo.WriteLine("q275")
    '                        writerAktivo.WriteLine("S3")
    '                        writerAktivo.WriteLine("O")
    '                        writerAktivo.WriteLine("JF")
    '                        writerAktivo.WriteLine("D9")
    '                        writerAktivo.WriteLine("ZT")
    '                        writerAktivo.WriteLine("Q234,B24")
    '                        writerAktivo.WriteLine("KI80")
    '                        writerAktivo.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='29.3 mm'></xpml>")
    '                        writerAktivo.WriteLine("N")

    '                        ' Menggunakan settingan koordinat yang sudah sesuai sebelumnya
    '                        writerAktivo.WriteLine("b100,80,Q,m2,g5,s3,""" & qrContent & """")

    '                        writerAktivo.WriteLine("A95,217,2,3,1,1,N," & Chr(34) & Chr(34))
    '                        writerAktivo.WriteLine("A95,30,2,3,1,1,N,""QR P.Fisik""")
    '                        writerAktivo.WriteLine("A290,54,2,2,1,1,N,""" & TrowData("Nama").ToString.Trim & """")

    '                        Dim tglTampilQR As String = If(IsDBNull(TrowData("TglLahir")), "", CDate(TrowData("TglLahir")).ToString("dd MMM yyyy"))
    '                        writerAktivo.WriteLine("A290,30,2,2,1,1,N,""" & tglTampilQR & " / " & TrowData("JenisKelamin").ToString.Trim & """")
    '                        writerAktivo.WriteLine("A290,217,2,3,1,1,N,""" & TrowData("NoUrut").ToString.Trim & """")
    '                        writerAktivo.WriteLine("P1")
    '                        writerAktivo.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
    '                        writerAktivo.Close()

    '                        System.Threading.Thread.Sleep(500)
    '                        Process.Start(Tpathprf & "PrFile32.exe ", TtxAktivo)
    '                    End If

    '                    'Cetak Barcode InBody
    '                    If CheckBoxInbody.Checked = True Then
    '                        Dim TtxInBody As String = Tpos & "OutputInBody.txt"
    '                        Dim barcodeInBody As String = TrowData("NoUrut").ToString.Trim

    '                        If System.IO.File.Exists(TtxInBody) Then
    '                            System.IO.File.Delete(TtxInBody)
    '                        End If

    '                        Using writer As New StreamWriter(TtxInBody, False)
    '                            writer.WriteLine("<xpml><page quantity='0' pitch='29.3 mm'></xpml>I8,A")
    '                            writer.WriteLine("ZN")
    '                            writer.WriteLine("q275")
    '                            writer.WriteLine("S3")
    '                            writer.WriteLine("O")
    '                            writer.WriteLine("JF")
    '                            writer.WriteLine("D9")
    '                            writer.WriteLine("ZT")
    '                            writer.WriteLine("Q234,B24")
    '                            writer.WriteLine("KI80")
    '                            writer.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='29.3 mm'></xpml>N")

    '                            'Barcode menggunakan NoUrut asli
    '                            writer.WriteLine("B290,177,2,1,2,4,97,N,""" & barcodeInBody & """")

    '                            'Label INBODY
    '                            writer.WriteLine("A95,30,2,3,1,1,N,""InBody""")

    '                            'Data Pasien
    '                            writer.WriteLine("A290,54,2,2,1,1,N,""" & TrowData("Nama").ToString.Trim & """")
    '                            writer.WriteLine("A290,30,2,2,1,1,N,""" & _
    '                                             TrowData("TglLahir").ToString.Trim & " / " & _
    '                                             TrowData("JenisKelamin").ToString.Trim & """")

    '                            'Teks Barcode
    '                            writer.WriteLine("A290,217,2,3,1,1,N,""" & barcodeInBody & """")

    '                            writer.WriteLine("P1")
    '                            writer.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
    '                        End Using

    '                        System.Threading.Thread.Sleep(500)
    '                        Process.Start(Tpathprf & "PrFile32.exe ", TtxInBody)
    '                    End If

    '                    'Flag
    '                    If IsDBNull(TrowData("LabSamplingTime")) = True Then
    '                        WriteSQL("update TransaksiLab set SendKeu=1, [Status]='CHECK', LabSamplingTime=getdate() WHERE TransLabID='" & TrowData("TransLabID").ToString.Trim & "' ", 4)
    '                    Else
    '                        WriteSQL("update TransaksiLab set SendKeu=1, [Status]='CHECK' WHERE TransLabID='" & TrowData("TransLabID").ToString.Trim & "' ", 4)
    '                    End If


    '                    If rdNonMCU.Checked = True AndAlso Not String.IsNullOrEmpty(_sessionCodeAktif) Then
    '                        Try
    '                            Dim urlWebService As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
    '                            Dim urlCheckIn As String = urlWebService & "api/mcu/check-in/" & _sessionCodeAktif & "/post/pendaftaran"

    '                            Dim jsonCheckIn As String = "{" & _
    '                                """identifier"":""" & _nikPasienAktif & """," & _
    '                                """identifier_type"":""nik""," & _
    '                                """status"":""completed""," & _
    '                                """notes"":""-""" & _
    '                                "}"

    '                            Dim resCheckIn As String = InsertDataAPIRM(jsonCheckIn, urlCheckIn)

    '                            Dim jObjRes As JObject = JObject.Parse(resCheckIn)
    '                            Dim msgTampil As String = "Pendaftaran MCU berhasil dikirim ke HYU!"

    '                            If jObjRes("message") IsNot Nothing Then
    '                                msgTampil = jObjRes("message").ToString()
    '                            End If

    '                            MsgBox(msgTampil, MsgBoxStyle.Information, "Sukses API")

    '                        Catch exAPI As Exception
    '                            MsgBox("Gagal mengirim data pendaftaran ke API: " & exAPI.Message, MsgBoxStyle.Critical, "Debug API")
    '                        End Try
    '                    End If

    '                    If RadioButtonHaid.Checked = True Then
    '                        Try
    '                            Dim urlWebService As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
    '                            Dim urlHaid As String = urlWebService & "api/mcu/check-in/" & _sessionCodeAktif & "/post/urine"

    '                            Dim jsonHaid As String = "{" & _
    '                                """identifier"":""" & _nikPasienAktif & """," & _
    '                                """identifier_type"":""nik""," & _
    '                                """status"":""skipped""," & _
    '                                """notes"":""Sedang haid""" & _
    '                                "}"

    '                            InsertDataAPIRM(jsonHaid, urlHaid)
    '                            MsgBox("Otomatisasi API: Status POS Darah berhasil di-skip karena Haid.", MsgBoxStyle.Information, "Sukses")

    '                        Catch exHaid As Exception
    '                            MsgBox("Gagal otomatisasi skip POS Darah: " & exHaid.Message, MsgBoxStyle.Critical, "Debug API")
    '                        End Try
    '                    End If

    '                    If RadioButtonHamil.Checked = True Then
    '                        Try
    '                            Dim urlWebService As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
    '                            Dim urlHamil As String = urlWebService & "api/mcu/check-in/" & _sessionCodeAktif & "/post/thorax"

    '                            Dim jsonHamil As String = "{" & _
    '                                """identifier"":""" & _nikPasienAktif & """," & _
    '                                """identifier_type"":""nik""," & _
    '                                """status"":""skipped""," & _
    '                                """notes"":""Sedang hamil""" & _
    '                                "}"

    '                            InsertDataAPIRM(jsonHamil, urlHamil)
    '                            MsgBox("Otomatisasi API: Status POS Thorax berhasil di-skip karena Hamil.", MsgBoxStyle.Information, "Sukses")

    '                        Catch exHamil As Exception
    '                            MsgBox("Gagal otomatisasi skip POS Thorax: " & exHamil.Message, MsgBoxStyle.Critical, "Debug API")
    '                        End Try
    '                    End If

    '                    If tabung = True Then System.Threading.Thread.Sleep(3000)
    '                Next
    '            Else
    '                MsgBox("Tidak ada data yang di barcode.", MsgBoxStyle.Exclamation, "Warning!")
    '                Exit Sub
    '            End If
    '        End If

    '        CetakBarcodeToolStripMenuItem.Enabled = True
    '        BarcodeTambahanToolStripMenuItem.Enabled = True
    '    Catch ex As Exception
    '        CetakBarcodeToolStripMenuItem.Enabled = True
    '        BarcodeTambahanToolStripMenuItem.Enabled = True

    '        If MsgBox(" Batal untuk Cetak Barcode tambahan ? ", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
    '            Exit Sub
    '        Else
    '            MsgBox("Ulangi proses ketika siap")
    '        End If
    '    End Try
    'End Sub

    Private Structure PrintApiParam
        Public CurrentTransLabID As String
        Public Nik As String
        Public SessionCode As String
        Public UrlWebService As String
        Public IsNonMCU As Boolean
        Public IsHaid As Boolean
        Public IsThoraxTolak As Boolean
        Public IsHamil As Boolean
        Public AlasanThorax As String
    End Structure

    'Sesudah Background Worker
    Private Sub BarcodeTambahanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarcodeTambahanToolStripMenuItem.Click
        CetakBarcodeToolStripMenuItem.Enabled = False
        BarcodeTambahanToolStripMenuItem.Enabled = False

        Dim Tpos As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='PathBarcode'")
        Dim KodeBarcode As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='KodeBarcode'")
        Dim Tpathprf As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='Pathprf'")
        Dim Ttx As String = Tpos & "Output.txt"
        Dim barcode As String = ""
        Dim totalrow As Integer = 0

        Dim Tinput As String = InputBox("Tambahan Cetakan Print Barcode : ", "Print Barcode", 2)
        If IsNumeric(Tinput) = False Then
            MsgBox("Masukkan Jumlah Barcode yang diprint.", MsgBoxStyle.Exclamation, "Warning!")
            ClearHeader()
            CetakBarcodeToolStripMenuItem.Enabled = True
            BarcodeTambahanToolStripMenuItem.Enabled = True
            Exit Sub
        End If

        If CInt(Tinput) <= 0 Then
            ClearHeader()
            CetakBarcodeToolStripMenuItem.Enabled = True
            BarcodeTambahanToolStripMenuItem.Enabled = True
            Exit Sub
        End If

        If CInt(Tinput) > 15 Then
            MsgBox("Cetakan tidak boleh lebih dari 15.", MsgBoxStyle.Exclamation, "Warning!")
            ClearHeader()
            CetakBarcodeToolStripMenuItem.Enabled = True
            BarcodeTambahanToolStripMenuItem.Enabled = True
            Exit Sub
        End If

        Try
            Dim NoUrut As String = ""
            If rdNonMCU.Checked = True Then
                NoUrut = "(" & txTransLabID1.Text & ")"
            ElseIf rdMCU.Checked = True Then
                Dim TblsMCU As DataTable = gridlab.DataSource
                NoUrut = ""
                Dim Ttemp As String = "("
                For Each TrowMCU As DataRow In TblsMCU.Rows
                    Ttemp = Ttemp & "'" & TrowMCU("TransLabID").ToString.Trim & "',"
                    totalrow = totalrow + 1
                Next
                NoUrut = Strings.Left(Ttemp, Ttemp.Length - 1) & ")"
            End If

            If rdMCU.Checked = True AndAlso (totalrow * CInt(Tinput) > 500) Then
                MsgBox("Total barcode tidak boleh lebih dari 500 cetakan, total barcode anda adalah " & totalrow & " data x " & Tinput & " cetakan = " & totalrow * CInt(Tinput) & " cetakan barcode.", MsgBoxStyle.Exclamation, "Warning!")
                CetakBarcodeToolStripMenuItem.Enabled = True
                BarcodeTambahanToolStripMenuItem.Enabled = True
                Exit Sub
            End If

            Dim Tbls2 As DataTable = ReadSQL("SELECT a.NoUrut,a.TransLabID,c.Nama,CONVERT(varchar(11),c.TglLahir,106) as TglLahir,c.JenisKelamin, a.LabSamplingTime " & _
                                             "FROM TransaksiLab a " & _
                                             "LEFT JOIN MasterPasien c on c.NoRekamMedis=a.IDInternet " & _
                                             "WHERE a.TransLabID in " & NoUrut & "")

            If Tbls2.Rows.Count > 0 Then
                Dim urlWebService As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")

                For Each TrowData As DataRow In Tbls2.Rows
                    Dim currentTransLabID As String = txtindakanid.Text

                    Dim tabung As Boolean = False
                    If cbtabung.Checked = True Then
                        Dim Tgrouping As DataTable = ReadSQL("SELECT distinct Tabung,TabungRef FROM MasterLab WHERE TindakanID in (SELECT distinct TindakanID FROM TransaksiLabDetail WHERE TransLabID='" & txTransLabID1.Text & "') and TabungRef is not null and Tabung like '%tabung%' order by Tabung ")
                        If Tgrouping.Rows.Count > 0 Then tabung = True
                    End If

                    If tabung = True Then CetakTabung(TrowData("NoUrut").ToString.Trim)

                    Dim Tstrtemp As String = ""
                    If TrowData("NoUrut").ToString.Contains("L") = True Then
                        Tstrtemp = Strings.Replace(TrowData("NoUrut").ToString.Trim, "L", "8")
                    ElseIf TrowData("NoUrut").ToString.Contains("M") = True Then
                        Tstrtemp = Strings.Replace(TrowData("NoUrut").ToString.Trim, "M", "9")
                    Else
                        Tstrtemp = TrowData("NoUrut").ToString.Trim
                    End If

                    If Tstrtemp.Length > 2 Then
                        barcode = KodeBarcode & Strings.Right(Tstrtemp.ToString.Trim, Len(Tstrtemp.ToString.Trim) - 2)
                    Else
                        barcode = KodeBarcode & Tstrtemp.ToString.Trim
                    End If

                    ' --- PROSES PRINT STIKER THERMAL ---
                    For i As Integer = 0 To CInt(Tinput) - 1
                        If System.IO.File.Exists(Ttx) = True Then System.IO.File.Delete(Ttx)
                        Using objStreamWriter As New StreamWriter(Ttx)
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
                            objStreamWriter.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='29.3 mm'></xpml>")
                            objStreamWriter.WriteLine("N")
                            objStreamWriter.WriteLine("B290,177,2,1,2,4,97,N,""" & barcode & """")
                            objStreamWriter.WriteLine("A95,217,2,3,1,1,N,""""""")
                            objStreamWriter.WriteLine("A290,54,2,2,1,1,N,""" & TrowData("Nama").ToString.Trim & """")

                            Dim tglTampil As String = If(IsDBNull(TrowData("TglLahir")), "", CDate(TrowData("TglLahir")).ToString("dd MMM yyyy"))
                            objStreamWriter.WriteLine("A290,30,2,2,1,1,N,""" & tglTampil & " / " & TrowData("JenisKelamin").ToString.Trim & """")
                            objStreamWriter.WriteLine("A290,217,2,3,1,1,N,""" & barcode & """")
                            objStreamWriter.WriteLine("P1")
                            objStreamWriter.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
                        End Using

                        Process.Start(Tpathprf & "PrFile32.exe ", Ttx)
                    Next

                    ' --- CETAK AKTIVO & INBODY ---
                    If CheckBoxAktivo.Checked = True Then CetakAktivoProcess(TrowData, Tpos, Tpathprf)
                    If CheckBoxInbody.Checked = True Then CetakInBodyProcess(TrowData, Tpos, Tpathprf)

                    ' --- UPDATE DATABASE LOKAL ---
                    If IsDBNull(TrowData("LabSamplingTime")) = True Then
                        WriteSQL("UPDATE TransaksiLab SET SendKeu=1, [Status]='CHECK', LabSamplingTime=GETDATE() WHERE TransLabID='" & txTransLabID1.Text & "' ", 4)
                    Else
                        WriteSQL("UPDATE TransaksiLab SET SendKeu=1, [Status]='CHECK' WHERE TransLabID='" & txTransLabID1.Text & "' ", 4)
                    End If

                    ' =======================================================================
                    ' OPTIMASI API HYU VIA BACKGROUNDWORKER / THREADPOOL (NO FREEZE)
                    ' =======================================================================
                    If rdNonMCU.Checked = True AndAlso Not String.IsNullOrEmpty(_sessionCodeAktif) Then
                        Dim paramApi As New PrintApiParam With { _
                            .CurrentTransLabID = currentTransLabID, _
                            .Nik = _nikPasienAktif, _
                            .SessionCode = _sessionCodeAktif, _
                            .UrlWebService = urlWebService, _
                            .IsNonMCU = rdNonMCU.Checked, _
                            .IsHaid = RadioButtonHaid.Checked, _
                            .IsThoraxTolak = rdThoraxTolak.Checked, _
                            .IsHamil = RadioButtonHamil.Checked, _
                            .AlasanThorax = txtAlasanThorax.Text.Trim() _
                        }

                        ' Jalankan pengiriman API secara asinkron
                        System.Threading.ThreadPool.QueueUserWorkItem(AddressOf ProcessPrintApiInBackground, paramApi)
                    End If
                Next
            Else
                MsgBox("Tidak ada data yang di barcode.", MsgBoxStyle.Exclamation, "Warning!")
            End If

        Catch ex As Exception
            MsgBox("Terjadi kesalahan cetak barcode: " & ex.Message, MsgBoxStyle.Critical, "Error")
        Finally
            CetakBarcodeToolStripMenuItem.Enabled = True
            BarcodeTambahanToolStripMenuItem.Enabled = True
        End Try
    End Sub

    Private Sub ProcessPrintApiInBackground(ByVal state As Object)
        Try
            Dim p As PrintApiParam = CType(state, PrintApiParam)

            ' 1. API Check-In Pendaftaran (Completed)
            Dim urlCheckIn As String = p.UrlWebService & "api/mcu/check-in/" & p.SessionCode & "/post/pendaftaran"
            Dim jsonCheckIn As String = "{" & _
                                        """identifier"":""" & p.Nik & """," & _
                                        """identifier_type"":""nik""," & _
                                        """status"":""completed""," & _
                                        """notes"":""-""" & _
                                        "}"

            Try
                Dim resCheckIn As String = InsertDataAPIRM(jsonCheckIn, urlCheckIn)
                WriteSQL("INSERT INTO log_api_checkin (no_urut, nik, session_code, url_api, payload, response, status_log, created_date) " & _
                     "VALUES ('" & p.CurrentTransLabID & "', '" & p.Nik & "', '" & p.SessionCode & "', '" & urlCheckIn & "', '" & jsonCheckIn.Replace("'", "''") & "', '" & resCheckIn.Replace("'", "''") & "', 'SUCCESS', GETDATE())", 4)
            Catch exAPI As Exception
                WriteSQL("INSERT INTO log_api_checkin (no_urut, nik, session_code, url_api, payload, response, status_log, created_date) " & _
                     "VALUES ('" & p.CurrentTransLabID & "', '" & p.Nik & "', '" & p.SessionCode & "', '" & urlCheckIn & "', '" & jsonCheckIn.Replace("'", "''") & "', '" & exAPI.Message.Replace("'", "''") & "', 'FAILED', GETDATE())", 4)
            End Try

            ' 2. API POS URINE (Skip Jika Haid)
            If p.IsHaid Then
                Dim urlHaid As String = p.UrlWebService & "api/mcu/check-in/" & p.SessionCode & "/post/urine"
                Dim jsonHaid As String = "{" & _
                                         """identifier"":""" & p.Nik & """," & _
                                         """identifier_type"":""nik""," & _
                                         """status"":""skipped""," & _
                                         """notes"":""Sedang haid""" & _
                                         "}"

                Try
                    Dim resHaid As String = InsertDataAPIRM(jsonHaid, urlHaid)
                    WriteSQL("INSERT INTO log_api_checkin (no_urut, nik, session_code, url_api, payload, response, status_log, created_date) " & _
                         "VALUES ('" & p.CurrentTransLabID & "', '" & p.Nik & "', '" & p.SessionCode & "', '" & urlHaid & "', '" & jsonHaid.Replace("'", "''") & "', '" & resHaid.Replace("'", "''") & "', 'SUCCESS_HAID', GETDATE())", 4)
                Catch exHaid As Exception
                    WriteSQL("INSERT INTO log_api_checkin (no_urut, nik, session_code, url_api, payload, response, status_log, created_date) " & _
                         "VALUES ('" & p.CurrentTransLabID & "', '" & p.Nik & "', '" & p.SessionCode & "', '" & urlHaid & "', '" & jsonHaid.Replace("'", "''") & "', '" & exHaid.Message.Replace("'", "''") & "', 'FAILED_HAID', GETDATE())", 4)
                End Try
            End If

            ' 3. API POS THORAX (Skip Jika Penolakan Pasien / Hamil)
            If p.IsThoraxTolak OrElse p.IsHamil Then
                Dim urlThorax As String = p.UrlWebService & "api/mcu/check-in/" & p.SessionCode & "/post/thorax"
                Dim alasanBatal As String = If(p.IsHamil, "Sedang hamil", p.AlasanThorax)
                If String.IsNullOrEmpty(alasanBatal) Then alasanBatal = "Pasien Menolak/Tidak Setuju Tindakan Thorax"
                alasanBatal = alasanBatal.Replace("""", "\""")

                Dim jsonThorax As String = "{" & _
                                           """identifier"":""" & p.Nik & """," & _
                                           """identifier_type"":""nik""," & _
                                           """status"":""skipped""," & _
                                           """notes"":""" & alasanBatal & """" & _
                                           "}"

                Try
                    Dim resThorax As String = InsertDataAPIRM(jsonThorax, urlThorax)
                    WriteSQL("INSERT INTO log_api_checkin (no_urut, nik, session_code, url_api, payload, response, status_log, created_date) " & _
                         "VALUES ('" & p.CurrentTransLabID & "', '" & p.Nik & "', '" & p.SessionCode & "', '" & urlThorax & "', '" & jsonThorax.Replace("'", "''") & "', '" & resThorax.Replace("'", "''") & "', 'SUCCESS_THORAX_SKIP', GETDATE())", 4)
                Catch exThorax As Exception
                    WriteSQL("INSERT INTO log_api_checkin (no_urut, nik, session_code, url_api, payload, response, status_log, created_date) " & _
                         "VALUES ('" & p.CurrentTransLabID & "', '" & p.Nik & "', '" & p.SessionCode & "', '" & urlThorax & "', '" & jsonThorax.Replace("'", "''") & "', '" & exThorax.Message.Replace("'", "''") & "', 'FAILED_THORAX_SKIP', GETDATE())", 4)
                End Try
            End If

        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error Background API Barcode: " & ex.Message)
        End Try
    End Sub

    Private Sub CetakAktivoProcess(ByVal TrowData As DataRow, ByVal Tpos As String, ByVal Tpathprf As String)
        Try
            Dim usia As Integer = 0
            If Not IsDBNull(TrowData("TglLahir")) Then
                Dim tglLahir As Date = CDate(TrowData("TglLahir"))
                usia = DateTime.Now.Year - tglLahir.Year
                If DateTime.Now < tglLahir.AddYears(usia) Then usia -= 1
            End If

            Dim gender As String = TrowData("JenisKelamin").ToString.Trim.ToUpper()
            gender = If(gender.Contains("L") OrElse gender.Contains("PRIA") OrElse gender.Contains("MALE"), "Male", "Female")

            Dim qrContent As String = TrowData("NoUrut").ToString.Trim & "#" & TrowData("Nama").ToString.Trim & "#" & usia.ToString() & "#" & gender
            Dim TtxAktivo As String = Tpos & "OutputAktivo.txt"

            If System.IO.File.Exists(TtxAktivo) Then System.IO.File.Delete(TtxAktivo)

            Using writerAktivo As New StreamWriter(TtxAktivo)
                writerAktivo.WriteLine("<xpml><page quantity='0' pitch='29.3 mm'></xpml>I8,A")
                writerAktivo.WriteLine("ZN")
                writerAktivo.WriteLine("q275")
                writerAktivo.WriteLine("S3")
                writerAktivo.WriteLine("O")
                writerAktivo.WriteLine("JF")
                writerAktivo.WriteLine("D9")
                writerAktivo.WriteLine("ZT")
                writerAktivo.WriteLine("Q234,B24")
                writerAktivo.WriteLine("KI80")
                writerAktivo.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='29.3 mm'></xpml>N")
                writerAktivo.WriteLine("b100,80,Q,m2,g5,s3,""" & qrContent & """")
                writerAktivo.WriteLine("A95,217,2,3,1,1,N," & Chr(34) & Chr(34))
                writerAktivo.WriteLine("A95,30,2,3,1,1,N,""QR P.Fisik""")
                writerAktivo.WriteLine("A290,54,2,2,1,1,N,""" & TrowData("Nama").ToString.Trim & """")

                Dim tglTampilQR As String = If(IsDBNull(TrowData("TglLahir")), "", CDate(TrowData("TglLahir")).ToString("dd MMM yyyy"))
                writerAktivo.WriteLine("A290,30,2,2,1,1,N,""" & tglTampilQR & " / " & TrowData("JenisKelamin").ToString.Trim & """")
                writerAktivo.WriteLine("A290,217,2,3,1,1,N,""" & TrowData("NoUrut").ToString.Trim & """")
                writerAktivo.WriteLine("P1")
                writerAktivo.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            End Using

            Process.Start(Tpathprf & "PrFile32.exe ", TtxAktivo)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CetakInBodyProcess(ByVal TrowData As DataRow, ByVal Tpos As String, ByVal Tpathprf As String)
        Try
            Dim TtxInBody As String = Tpos & "OutputInBody.txt"
            Dim barcodeInBody As String = TrowData("NoUrut").ToString.Trim

            If System.IO.File.Exists(TtxInBody) Then System.IO.File.Delete(TtxInBody)

            Using writer As New StreamWriter(TtxInBody, False)
                writer.WriteLine("<xpml><page quantity='0' pitch='29.3 mm'></xpml>I8,A")
                writer.WriteLine("ZN")
                writer.WriteLine("q275")
                writer.WriteLine("S3")
                writer.WriteLine("O")
                writer.WriteLine("JF")
                writer.WriteLine("D9")
                writer.WriteLine("ZT")
                writer.WriteLine("Q234,B24")
                writer.WriteLine("KI80")
                writer.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='29.3 mm'></xpml>N")
                writer.WriteLine("B290,177,2,1,2,4,97,N,""" & barcodeInBody & """")
                writer.WriteLine("A95,30,2,3,1,1,N,""InBody""")
                writer.WriteLine("A290,54,2,2,1,1,N,""" & TrowData("Nama").ToString.Trim & """")
                writer.WriteLine("A290,30,2,2,1,1,N,""" & TrowData("TglLahir").ToString.Trim & " / " & TrowData("JenisKelamin").ToString.Trim & """")
                writer.WriteLine("A290,217,2,3,1,1,N,""" & barcodeInBody & """")
                writer.WriteLine("P1")
                writer.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
            End Using

            Process.Start(Tpathprf & "PrFile32.exe ", TtxInBody)
        Catch ex As Exception
        End Try
    End Sub

    'Sebelum Background Worker
    'Private Sub BarcodeTambahanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarcodeTambahanToolStripMenuItem.Click
    '    CetakBarcodeToolStripMenuItem.Enabled = False
    '    BarcodeTambahanToolStripMenuItem.Enabled = False

    '    Dim Tpos As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='PathBarcode'")
    '    Dim KodeBarcode As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='KodeBarcode'")
    '    Dim Tpathprf As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='Pathprf'")
    '    Dim Ttx As String = Tpos & "Output.txt"
    '    Dim barcode As String = ""
    '    Dim totalrow As Integer = 0

    '    Dim Tinput As String = InputBox("Tambahan Cetakan Print Barcode : ", "Print Barcode", 2)
    '    If IsNumeric(Tinput) = False Then
    '        MsgBox("Masukkan Jumlah Barcode yang diprint.", MsgBoxStyle.Exclamation, "Warning!")
    '        ClearHeader()
    '        CetakBarcodeToolStripMenuItem.Enabled = True
    '        BarcodeTambahanToolStripMenuItem.Enabled = True
    '        Exit Sub
    '    End If

    '    If CInt(Tinput) = 0 Then
    '        ClearHeader()
    '        CetakBarcodeToolStripMenuItem.Enabled = True
    '        BarcodeTambahanToolStripMenuItem.Enabled = True
    '        Exit Sub
    '    End If

    '    If CInt(Tinput) > 15 Then
    '        MsgBox("Cetakan tidak boleh lebih dari 15.", MsgBoxStyle.Exclamation, "Warning!")
    '        ClearHeader()
    '        CetakBarcodeToolStripMenuItem.Enabled = True
    '        BarcodeTambahanToolStripMenuItem.Enabled = True
    '        Exit Sub
    '    End If

    '    Try
    '        If Tinput > 0 Then
    '            Dim NoUrut As String = ""
    '            If rdNonMCU.Checked = True Then
    '                NoUrut = "(" & txTransLabID1.Text & ")"
    '            ElseIf rdMCU.Checked = True Then
    '                Dim TblsMCU As DataTable = gridlab.DataSource
    '                NoUrut = ""
    '                Dim Ttemp As String = "("
    '                For Each TrowMCU As DataRow In TblsMCU.Rows
    '                    Ttemp = Ttemp & "'" & TrowMCU("TransLabID").ToString.Trim & "',"
    '                    totalrow = totalrow + 1
    '                Next
    '                NoUrut = Strings.Left(Ttemp, Ttemp.Length - 1) & ")"
    '            End If

    '            If totalrow * Tinput > 500 Then
    '                MsgBox("Total barcode tidak boleh lebih dari 500 cetakan, total barcode anda adalah " & totalrow & " data x " & Tinput & " cetakan = " & totalrow * Tinput & " cetakan barcode.", MsgBoxStyle.Exclamation, "Warning!")
    '                CetakBarcodeToolStripMenuItem.Enabled = True
    '                BarcodeTambahanToolStripMenuItem.Enabled = True
    '                Exit Sub
    '            End If

    '            Dim Tbls2 As DataTable = ReadSQL("SELECT a.NoUrut,a.TransLabID,c.Nama,CONVERT(varchar(11),c.TglLahir,106) as TglLahir,c.JenisKelamin, a.LabSamplingTime " & _
    '                                             "FROM TransaksiLab a " & _
    '                                             "LEFT JOIN MasterPasien c on c.NoRekamMedis=a.IDInternet " & _
    '                                             "WHERE a.TransLabID in " & NoUrut & "")
    '            If Tbls2.Rows.Count > 0 Then
    '                For Each TrowData As DataRow In Tbls2.Rows
    '                    Dim currentTransLabID As String = txtindakanid.Text

    '                    Dim tabung As Boolean = False
    '                    If cbtabung.Checked = True Then
    '                        'Cek Tabung
    '                        Dim Tgrouping As DataTable = ReadSQL("SELECT distinct Tabung,TabungRef FROM MasterLab WHERE TindakanID in (SELECT distinct TindakanID FROM TransaksiLabDetail WHERE TransLabID='" & txTransLabID1.Text & "') and TabungRef is not null and Tabung like '%tabung%' order by Tabung ")
    '                        If Tgrouping.Rows.Count > 0 Then tabung = True
    '                    End If

    '                    If tabung = True Then CetakTabung(TrowData("NoUrut").ToString.Trim)

    '                    Dim Tstrtemp As String = ""
    '                    If TrowData("NoUrut").ToString.Contains("L") = True Then
    '                        Tstrtemp = Strings.Replace(TrowData("NoUrut").ToString.Trim, "L", "8")
    '                    ElseIf TrowData("NoUrut").ToString.Contains("M") = True Then
    '                        Tstrtemp = Strings.Replace(TrowData("NoUrut").ToString.Trim, "M", "9")
    '                    Else
    '                        Tstrtemp = TrowData("NoUrut").ToString.Trim
    '                    End If

    '                    If Tstrtemp.Length > 2 Then
    '                        barcode = KodeBarcode & Strings.Right(Tstrtemp.ToString.Trim, Len(Tstrtemp.ToString.Trim) - 2)
    '                    Else
    '                        barcode = KodeBarcode & Tstrtemp.ToString.Trim
    '                    End If

    '                    If tabung = True Then
    '                        System.Threading.Thread.Sleep(3000)
    '                    Else
    '                        System.Threading.Thread.Sleep(500)
    '                    End If

    '                    For i As Integer = 0 To CInt(Tinput) - 1
    '                        If System.IO.File.Exists(Ttx) = True Then System.IO.File.Delete(Ttx)
    '                        Dim objStreamWriter As StreamWriter = New StreamWriter(Ttx)
    '                        objStreamWriter.WriteLine("<xpml><page quantity='0' pitch='29.3 mm'></xpml>I8,A")
    '                        objStreamWriter.WriteLine("ZN")
    '                        objStreamWriter.WriteLine("q275")
    '                        objStreamWriter.WriteLine("S3")
    '                        objStreamWriter.WriteLine("O")
    '                        objStreamWriter.WriteLine("JF")
    '                        objStreamWriter.WriteLine("D9")
    '                        objStreamWriter.WriteLine("ZT")
    '                        objStreamWriter.WriteLine("Q234,B24")
    '                        objStreamWriter.WriteLine("KI80")
    '                        objStreamWriter.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='29.3 mm'></xpml>")
    '                        objStreamWriter.WriteLine("N")
    '                        objStreamWriter.WriteLine("B290,177,2,1,2,4,97,N,""" & barcode & """")
    '                        objStreamWriter.WriteLine("A95,217,2,3,1,1,N,""""""")
    '                        objStreamWriter.WriteLine("A290,54,2,2,1,1,N,""" & TrowData("Nama").ToString.Trim & """")

    '                        Dim tglTampil As String = If(IsDBNull(TrowData("TglLahir")), "", CDate(TrowData("TglLahir")).ToString("dd MMM yyyy"))
    '                        objStreamWriter.WriteLine("A290,30,2,2,1,1,N,""" & tglTampil & " / " & TrowData("JenisKelamin").ToString.Trim & """")
    '                        objStreamWriter.WriteLine("A290,217,2,3,1,1,N,""" & barcode & """")
    '                        objStreamWriter.WriteLine("P1")
    '                        objStreamWriter.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
    '                        objStreamWriter.Close()

    '                        If tabung = True Then
    '                            System.Threading.Thread.Sleep(1000)
    '                        Else
    '                            System.Threading.Thread.Sleep(500)
    '                        End If

    '                        Process.Start(Tpathprf & "PrFile32.exe ", Ttx)
    '                    Next

    '                    'Cetak Aktivo
    '                    If CheckBoxAktivo.Checked = True Then
    '                        Dim usia As Integer = 0
    '                        If Not IsDBNull(TrowData("TglLahir")) Then
    '                            Dim tglLahir As Date = CDate(TrowData("TglLahir"))
    '                            usia = DateTime.Now.Year - tglLahir.Year
    '                            If DateTime.Now < tglLahir.AddYears(usia) Then usia -= 1
    '                        End If

    '                        Dim gender As String = TrowData("JenisKelamin").ToString.Trim.ToUpper()
    '                        If gender.Contains("L") Or gender.Contains("PRIA") Or gender.Contains("MALE") Then
    '                            gender = "Male"
    '                        Else
    '                            gender = "Female"
    '                        End If

    '                        Dim qrContent As String = TrowData("NoUrut").ToString.Trim & "#" & _
    '                                                  TrowData("Nama").ToString.Trim & "#" & _
    '                                                  usia.ToString() & "#" & _
    '                                                  gender

    '                        Dim TtxAktivo As String = Tpos & "OutputAktivo.txt"
    '                        If System.IO.File.Exists(TtxAktivo) = True Then System.IO.File.Delete(TtxAktivo)

    '                        Dim writerAktivo As New StreamWriter(TtxAktivo)
    '                        writerAktivo.WriteLine("<xpml><page quantity='0' pitch='29.3 mm'></xpml>I8,A")
    '                        writerAktivo.WriteLine("ZN")
    '                        writerAktivo.WriteLine("q275")
    '                        writerAktivo.WriteLine("S3")
    '                        writerAktivo.WriteLine("O")
    '                        writerAktivo.WriteLine("JF")
    '                        writerAktivo.WriteLine("D9")
    '                        writerAktivo.WriteLine("ZT")
    '                        writerAktivo.WriteLine("Q234,B24")
    '                        writerAktivo.WriteLine("KI80")
    '                        writerAktivo.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='29.3 mm'></xpml>")
    '                        writerAktivo.WriteLine("N")

    '                        writerAktivo.WriteLine("b100,80,Q,m2,g5,s3,""" & qrContent & """")
    '                        writerAktivo.WriteLine("A95,217,2,3,1,1,N," & Chr(34) & Chr(34))
    '                        writerAktivo.WriteLine("A95,30,2,3,1,1,N,""QR P.Fisik""")
    '                        writerAktivo.WriteLine("A290,54,2,2,1,1,N,""" & TrowData("Nama").ToString.Trim & """")

    '                        Dim tglTampilQR As String = If(IsDBNull(TrowData("TglLahir")), "", CDate(TrowData("TglLahir")).ToString("dd MMM yyyy"))
    '                        writerAktivo.WriteLine("A290,30,2,2,1,1,N,""" & tglTampilQR & " / " & TrowData("JenisKelamin").ToString.Trim & """")
    '                        writerAktivo.WriteLine("A290,217,2,3,1,1,N,""" & TrowData("NoUrut").ToString.Trim & """")
    '                        writerAktivo.WriteLine("P1")
    '                        writerAktivo.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
    '                        writerAktivo.Close()

    '                        System.Threading.Thread.Sleep(500)
    '                        Process.Start(Tpathprf & "PrFile32.exe ", TtxAktivo)
    '                    End If

    '                    'Cetak Barcode InBody
    '                    If CheckBoxInbody.Checked = True Then
    '                        Dim TtxInBody As String = Tpos & "OutputInBody.txt"
    '                        Dim barcodeInBody As String = TrowData("NoUrut").ToString.Trim

    '                        If System.IO.File.Exists(TtxInBody) Then System.IO.File.Delete(TtxInBody)

    '                        Using writer As New StreamWriter(TtxInBody, False)
    '                            writer.WriteLine("<xpml><page quantity='0' pitch='29.3 mm'></xpml>I8,A")
    '                            writer.WriteLine("ZN")
    '                            writer.WriteLine("q275")
    '                            writer.WriteLine("S3")
    '                            writer.WriteLine("O")
    '                            writer.WriteLine("JF")
    '                            writer.WriteLine("D9")
    '                            writer.WriteLine("ZT")
    '                            writer.WriteLine("Q234,B24")
    '                            writer.WriteLine("KI80")
    '                            writer.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='29.3 mm'></xpml>N")

    '                            writer.WriteLine("B290,177,2,1,2,4,97,N,""" & barcodeInBody & """")
    '                            writer.WriteLine("A95,30,2,3,1,1,N,""InBody""")
    '                            writer.WriteLine("A290,54,2,2,1,1,N,""" & TrowData("Nama").ToString.Trim & """")
    '                            writer.WriteLine("A290,30,2,2,1,1,N,""" & _
    '                                             TrowData("TglLahir").ToString.Trim & " / " & _
    '                                             TrowData("JenisKelamin").ToString.Trim & """")
    '                            writer.WriteLine("A290,217,2,3,1,1,N,""" & barcodeInBody & """")

    '                            writer.WriteLine("P1")
    '                            writer.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
    '                        End Using

    '                        System.Threading.Thread.Sleep(500)
    '                        Process.Start(Tpathprf & "PrFile32.exe ", TtxInBody)
    '                    End If

    '                    'Flag Local Database
    '                    If IsDBNull(TrowData("LabSamplingTime")) = True Then
    '                        WriteSQL("update TransaksiLab set SendKeu=1, [Status]='CHECK', LabSamplingTime=getdate() WHERE TransLabID='" & txTransLabID1.Text & "' ", 4)
    '                    Else
    '                        WriteSQL("update TransaksiLab set SendKeu=1, [Status]='CHECK' WHERE TransLabID='" & txTransLabID1.Text & "' ", 4)
    '                    End If

    '                    ' =======================================================================
    '                    ' EKSEKUSI API SIKECAP / HYU
    '                    ' =======================================================================
    '                    Dim urlWebService As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")

    '                    If rdNonMCU.Checked = True AndAlso Not String.IsNullOrEmpty(_sessionCodeAktif) Then
    '                        ' 1. API Check-In Pendaftaran
    '                        Dim urlCheckIn As String = urlWebService & "api/mcu/check-in/" & _sessionCodeAktif & "/post/pendaftaran"
    '                        Dim jsonCheckIn As String = ""

    '                        Try
    '                            jsonCheckIn = "{" & _
    '                                """identifier"":""" & _nikPasienAktif & """," & _
    '                                """identifier_type"":""nik""," & _
    '                                """status"":""completed""," & _
    '                                """notes"":""-""" & _
    '                                "}"

    '                            Dim resCheckIn As String = InsertDataAPIRM(jsonCheckIn, urlCheckIn)
    '                            Dim jObjRes As JObject = JObject.Parse(resCheckIn)
    '                            Dim msgTampil As String = "Pendaftaran MCU berhasil dikirim ke HYU!"

    '                            If jObjRes("message") IsNot Nothing Then
    '                                msgTampil = jObjRes("message").ToString()
    '                            End If

    '                            MsgBox(msgTampil, MsgBoxStyle.Information, "Sukses API")

    '                            WriteSQL("INSERT INTO log_api_checkin (no_urut, nik, session_code, url_api, payload, response, status_log, created_date) " & _
    '                                     "VALUES ('" & currentTransLabID & "', '" & _nikPasienAktif & "', '" & _sessionCodeAktif & "', '" & urlCheckIn & "', '" & jsonCheckIn.Replace("'", "''") & "', '" & resCheckIn.Replace("'", "''") & "', 'SUCCESS', GETDATE())", 4)

    '                        Catch exAPI As Exception
    '                            MsgBox("Gagal mengirim data pendaftaran ke API: " & exAPI.Message, MsgBoxStyle.Critical, "Debug API")

    '                            WriteSQL("INSERT INTO log_api_checkin (no_urut, nik, session_code, url_api, payload, response, status_log, created_date) " & _
    '                                     "VALUES ('" & currentTransLabID & "', '" & _nikPasienAktif & "', '" & _sessionCodeAktif & "', '" & urlCheckIn & "', '" & jsonCheckIn.Replace("'", "''") & "', '" & exAPI.Message.Replace("'", "''") & "', 'FAILED', GETDATE())", 4)
    '                        End Try

    '                        ' 2. API URINE (Skip jika Haid)
    '                        If RadioButtonHaid.Checked = True Then
    '                            Dim urlHaid As String = urlWebService & "api/mcu/check-in/" & _sessionCodeAktif & "/post/urine"
    '                            Dim jsonHaid As String = ""

    '                            Try
    '                                jsonHaid = "{" & _
    '                                    """identifier"":""" & _nikPasienAktif & """," & _
    '                                    """identifier_type"":""nik""," & _
    '                                    """status"":""skipped""," & _
    '                                    """notes"":""Sedang haid""" & _
    '                                    "}"

    '                                Dim resHaid As String = InsertDataAPIRM(jsonHaid, urlHaid)
    '                                MsgBox("Otomatisasi API: Status POS Urine berhasil di-skip karena Haid.", MsgBoxStyle.Information, "Sukses")

    '                                WriteSQL("INSERT INTO log_api_checkin (no_urut, nik, session_code, url_api, payload, response, status_log, created_date) " & _
    '                                         "VALUES ('" & currentTransLabID & "', '" & _nikPasienAktif & "', '" & _sessionCodeAktif & "', '" & urlHaid & "', '" & jsonHaid.Replace("'", "''") & "', '" & resHaid.Replace("'", "''") & "', 'SUCCESS_HAID', GETDATE())", 4)

    '                            Catch exHaid As Exception
    '                                MsgBox("Gagal otomatisasi skip POS Urine: " & exHaid.Message, MsgBoxStyle.Critical, "Debug API")

    '                                WriteSQL("INSERT INTO log_api_checkin (no_urut, nik, session_code, url_api, payload, response, status_log, created_date) " & _
    '                                         "VALUES ('" & currentTransLabID & "', '" & _nikPasienAktif & "', '" & _sessionCodeAktif & "', '" & urlHaid & "', '" & jsonHaid.Replace("'", "''") & "', '" & exHaid.Message.Replace("'", "''") & "', 'FAILED_HAID', GETDATE())", 4)
    '                            End Try
    '                        End If

    '                        ' 3. API THORAX (Skip jika Penolakan Pasien / Hamil)
    '                        If rdThoraxTolak.Checked = True Then
    '                            Dim urlThorax As String = urlWebService & "api/mcu/check-in/" & _sessionCodeAktif & "/post/thorax"

    '                            Dim alasanBatal As String = txtAlasanThorax.Text.Trim()
    '                            If String.IsNullOrEmpty(alasanBatal) Then alasanBatal = "Pasien Menolak/Tidak Setuju Tindakan Thorax"
    '                            alasanBatal = alasanBatal.Replace("""", "\""")

    '                            Dim jsonThorax As String = ""

    '                            Try
    '                                jsonThorax = "{" & _
    '                                    """identifier"":""" & _nikPasienAktif & """," & _
    '                                    """identifier_type"":""nik""," & _
    '                                    """status"":""skipped""," & _
    '                                    """notes"":""" & alasanBatal & """" & _
    '                                    "}"

    '                                Dim resThorax As String = InsertDataAPIRM(jsonThorax, urlThorax)
    '                                MsgBox("Otomatisasi API: Status POS Thorax berhasil di-skip (" & alasanBatal & ").", MsgBoxStyle.Information, "Sukses API")

    '                                WriteSQL("INSERT INTO log_api_checkin (no_urut, nik, session_code, url_api, payload, response, status_log, created_date) " & _
    '                                         "VALUES ('" & currentTransLabID & "', '" & _nikPasienAktif & "', '" & _sessionCodeAktif & "', '" & urlThorax & "', '" & jsonThorax.Replace("'", "''") & "', '" & resThorax.Replace("'", "''") & "', 'SUCCESS_THORAX_SKIP', GETDATE())", 4)

    '                            Catch exThorax As Exception
    '                                MsgBox("Gagal kirim skip POS Thorax: " & exThorax.Message, MsgBoxStyle.Critical, "Debug API")

    '                                WriteSQL("INSERT INTO log_api_checkin (no_urut, nik, session_code, url_api, payload, response, status_log, created_date) " & _
    '                                         "VALUES ('" & currentTransLabID & "', '" & _nikPasienAktif & "', '" & _sessionCodeAktif & "', '" & urlThorax & "', '" & jsonThorax.Replace("'", "''") & "', '" & exThorax.Message.Replace("'", "''") & "', 'FAILED_THORAX_SKIP', GETDATE())", 4)
    '                            End Try

    '                        ElseIf RadioButtonHamil.Checked = True Then
    '                            Dim urlHamil As String = urlWebService & "api/mcu/check-in/" & _sessionCodeAktif & "/post/thorax"
    '                            Dim jsonHamil As String = ""

    '                            Try
    '                                jsonHamil = "{" & _
    '                                    """identifier"":""" & _nikPasienAktif & """," & _
    '                                    """identifier_type"":""nik""," & _
    '                                    """status"":""skipped""," & _
    '                                    """notes"":""Sedang hamil""" & _
    '                                    "}"

    '                                Dim resHamil As String = InsertDataAPIRM(jsonHamil, urlHamil)
    '                                MsgBox("Otomatisasi API: Status POS Thorax berhasil di-skip karena Hamil.", MsgBoxStyle.Information, "Sukses")

    '                                WriteSQL("INSERT INTO log_api_checkin (no_urut, nik, session_code, url_api, payload, response, status_log, created_date) " & _
    '                                         "VALUES ('" & currentTransLabID & "', '" & _nikPasienAktif & "', '" & _sessionCodeAktif & "', '" & urlHamil & "', '" & jsonHamil.Replace("'", "''") & "', '" & resHamil.Replace("'", "''") & "', 'SUCCESS_HAMIL', GETDATE())", 4)
    '                            Catch exHamil As Exception
    '                                MsgBox("Gagal otomatisasi skip POS Thorax: " & exHamil.Message, MsgBoxStyle.Critical, "Debug API")

    '                                WriteSQL("INSERT INTO log_api_checkin (no_urut, nik, session_code, url_api, payload, response, status_log, created_date) " & _
    '                                         "VALUES ('" & currentTransLabID & "', '" & _nikPasienAktif & "', '" & _sessionCodeAktif & "', '" & urlHamil & "', '" & jsonHamil.Replace("'", "''") & "', '" & exHamil.Message.Replace("'", "''") & "', 'FAILED_HAMIL', GETDATE())", 4)
    '                            End Try
    '                        End If
    '                    End If

    '                    If tabung = True Then System.Threading.Thread.Sleep(3000)
    '                Next
    '            Else
    '                MsgBox("Tidak ada data yang di barcode.", MsgBoxStyle.Exclamation, "Warning!")
    '                CetakBarcodeToolStripMenuItem.Enabled = True
    '                BarcodeTambahanToolStripMenuItem.Enabled = True
    '                Exit Sub
    '            End If
    '        End If

    '        CetakBarcodeToolStripMenuItem.Enabled = True
    '        BarcodeTambahanToolStripMenuItem.Enabled = True

    '    Catch ex As Exception
    '        CetakBarcodeToolStripMenuItem.Enabled = True
    '        BarcodeTambahanToolStripMenuItem.Enabled = True

    '        If MsgBox(" Batal untuk Cetak Barcode tambahan ? ", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
    '            Exit Sub
    '        Else
    '            MsgBox("Ulangi proses ketika siap")
    '        End If
    '    End Try
    'End Sub

    Private Sub CetakTabung(ByVal NoUrut As String)
        Dim Tpos As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='PathBarcode'")
        Dim KodeBarcode As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='KodeBarcode'")
        Dim Tpathprf As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='Pathprf'")
        Dim Ttx As String = Tpos & "OutputTabung.txt"
        Dim barcode As String = ""

        Try
            Dim Tbls2 As DataTable = ReadSQL("SELECT a.NoUrut,a.TransLabID,c.Nama,CONVERT(varchar(11),c.TglLahir,106) as TglLahir,c.JenisKelamin, a.LabSamplingTime " & _
                                             "FROM TransaksiLab a " & _
                                             "LEFT JOIN MasterPasien c on c.NoRekamMedis = a.IDInternet " & _
                                             "WHERE nourut = '" & NoUrut & "'")
            If Tbls2.Rows.Count > 0 Then
                For Each TrowData As DataRow In Tbls2.Rows
                    Dim Tgrouping As DataTable = ReadSQL("SELECT distinct Tabung,TabungRef FROM MasterLab WHERE TindakanID in (SELECT distinct TindakanID FROM TransaksiLabDetail WHERE TransLabID='" & TrowData("TransLabID").ToString.Trim & "') and TabungRef is not null and Tabung like '%tabung%' order by Tabung ")

                    If Tgrouping.Rows.Count > 0 Then
                        Dim Ttemp As String = ""
                        If TrowData("NoUrut").ToString.Contains("L") = True Then
                            Ttemp = Strings.Replace(TrowData("NoUrut").ToString.Trim, "L", "8")
                        ElseIf TrowData("NoUrut").ToString.Contains("M") = True Then
                            Ttemp = Strings.Replace(TrowData("NoUrut").ToString.Trim, "M", "9")
                        End If

                        barcode = KodeBarcode & Strings.Right(Ttemp.ToString.Trim, Len(Ttemp.ToString.Trim) - 2)

                        For Each Treply As DataRow In Tgrouping.Rows

                            System.Threading.Thread.Sleep(500)

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

                            If Treply("TabungRef").ToString <> "" Then
                                objStreamWriter.WriteLine("B290,177,2,1,2,4,97,N,""" & barcode & Treply("TabungRef").ToString & """")
                            Else
                                objStreamWriter.WriteLine("B290,177,2,1,2,4,97,N,""" & barcode & """")
                            End If

                            objStreamWriter.WriteLine("A95,217,2,3,1,1,N,""""""")
                            objStreamWriter.WriteLine("A95,30,2,3,1,1,N,""" & Treply("Tabung").ToString & """")
                            objStreamWriter.WriteLine("A290,54,2,2,1,1,N,""" & TrowData("Nama").ToString.Trim & """")
                            objStreamWriter.WriteLine("A290,30,2,2,1,1,N,""" & TrowData("TglLahir").ToString.Trim & " / " & TrowData("JenisKelamin").ToString.Trim & """")

                            If Treply("TabungRef").ToString <> "" Then
                                objStreamWriter.WriteLine("A290,217,2,3,1,1,N,""" & barcode & Treply("TabungRef").ToString & """")
                            Else
                                objStreamWriter.WriteLine("A290,217,2,3,1,1,N,""" & barcode & """")
                            End If

                            objStreamWriter.WriteLine("P1")
                            objStreamWriter.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
                            objStreamWriter.Close()
                            Process.Start(Tpathprf & "PrFile32.exe ", Ttx)
                        Next
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Private Sub buttambahpasien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttambahpasien.Click
    '    Dim Takhir As Date = DateSerial(DateAndTime.Now.Year, DateAndTime.Now.Month, DateAndTime.Now.Day).AddDays(30)
    '    Dim Tawal As Date = DateAdd(DateInterval.Day, -90, Takhir.Date)
    '    Find.Show()
    '    Find.Query("SELECT a.TransLabID, a.NoUrut, a.IDInternet, b.Nama, b.TglLahir, a.TglLab, a.Status " & _
    '               "FROM TransaksiLab a " & _
    '               "LEFT JOIN MasterPasien  b on a.idinternet = b.NoRekamMedis " & _
    '               "WHERE a.ClosedTransaksi=1 and Status in ('SAMPLE','CHECK') and CONVERT(date, Tgllab) between '" & Format(Tawal.Date, "MM/dd/yyyy") & "' and '" & Format(Takhir.Date, "MM/dd/yyyy") & "'  and a.deleted<>1 ", " order by a.NoUrut desc ", "FindTransaksiBarcode", 0)
    'End Sub

    Private Sub buttambahpasien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttambahpasien.Click
        Dim Takhir As Date = DateSerial(DateAndTime.Now.Year, DateAndTime.Now.Month, DateAndTime.Now.Day).AddDays(30)
        Dim Tawal As Date = DateAdd(DateInterval.Day, -90, Takhir.Date)

        Find.Show()
        Find.Query("SELECT a.TransLabID, a.NoUrut, a.IDInternet, b.Nama, b.TglLahir, b.NoNIK AS nik, a.TglLab, a.Status " & _
                   "FROM TransaksiLab a " & _
                   "LEFT JOIN MasterPasien b on a.idinternet = b.NoRekamMedis " & _
                   "WHERE a.ClosedTransaksi=1 and Status in ('SAMPLE','CHECK') and CONVERT(date, Tgllab) between '" & Format(Tawal.Date, "MM/dd/yyyy") & "' and '" & Format(Takhir.Date, "MM/dd/yyyy") & "' and a.deleted<>1 ", " order by a.NoUrut desc ", "FindTransaksiBarcode", 0)
    End Sub

    Private Sub rdNonMCU_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdNonMCU.CheckedChanged
        If rdMCU.Checked = True Then
            buttambahpasien.Enabled = False
            buttambahpasienmcu.Enabled = True
            txcompanycode.Focus()
        ElseIf rdNonMCU.Checked = True Then
            buttambahpasien.Enabled = True
            buttambahpasienmcu.Enabled = False
            txTransLabID1.Focus()
        End If
    End Sub

    Private Sub rdMCU_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdMCU.CheckedChanged
        If rdMCU.Checked = True Then
            TabControl1.SelectedIndex = 1
            buttambahpasien.Enabled = False
            buttambahpasienmcu.Enabled = True
            txcompanycode.Focus()
        ElseIf rdNonMCU.Checked = True Then
            TabControl1.SelectedIndex = 0
            buttambahpasien.Enabled = True
            buttambahpasienmcu.Enabled = False
            txTransLabID1.Focus()
        End If
    End Sub

    Private Sub buttambahpasienmcu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttambahpasienmcu.Click
        If txcompanycode.Text = "" Then
            MsgBox("Pilih Company Terlebih Dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Exit Sub
        End If

        Dim Tquery As String = ""
        Dim Tcompany As String = ""
        Dim ConcatCompany As String = ""
        Dim Number1 As String = ""
        Dim Number2 As String = ""
        Dim TrangeNumber As String = ""

        'Set No Urut
        If cbNoUrut.Checked = True Then
            If txNoUrut1.Text.Trim = "" Or txNoUrut2.Text.Trim = "" Or txNoUrut1.Text.Trim = "0" Or txNoUrut2.Text.Trim = "0" Then
                MsgBox("No Urut tidak boleh kosong.", MsgBoxStyle.Exclamation, "Warning!")
                Exit Sub
            ElseIf CDbl(txNoUrut1.Text) > CDbl(txNoUrut2.Text) Then
                MsgBox("Pastikan Inputan No Urut sudah benar.", MsgBoxStyle.Exclamation, "Warning!")
                Exit Sub
            Else
                Number1 = txNoUrut1.Text.ToString().PadLeft(5, "0")
                Number2 = txNoUrut2.Text.ToString().PadLeft(5, "0")
                TrangeNumber = " and (RIGHT(NoUrut, 5) between '" & Number1 & "' and '" & Number2 & "')"
            End If
        End If

        'Set Company
        ConcatCompany = txcompanycode.Text + "-" + txkodecabang.Text
        Tcompany = " and (c.NoJenisBayar = '" & txcompanycode.Text & "' or c.NoJenisBayar='" & ConcatCompany & "')"

        'Query Utama
        Tquery = "SELECT a.TransLabID, a.NoUrut, a.IDInternet, b.Nama, b.TglLahir, a.TglLab, a.Status, CASE WHEN c.NoJenisBayar <> '-' THEN c.NoJenisBayar WHEN c.NoJenisBayar = '-' THEN 'PASIEN UMUM' END AS 'Company' " & _
                 "FROM TransaksiLab a " & _
                 "LEFT JOIN MasterPasien  b on a.idinternet = b.NoRekamMedis " & _
                 "LEFT JOIN TransaksiLabBayar c on c.TransLabID = a.TransLabID " & _
                 "WHERE a.NoUrut like '%" & cmbkodetransaksi.Text & "%' AND a.ClosedTransaksi=1 AND Status in ('SAMPLE','CHECK') AND CONVERT(date, Tgllab) = '" & Format(dtprocess.Value, "MM-dd-yyyy") & "'" & Tcompany & " AND a.deleted<>1 AND c.NoJenisBayar <> '' " & TrangeNumber & " order by a.NoUrut desc"

        Dim TblsNew As DataTable = ReadSQL(Tquery)

        If TblsNew.Rows.Count > 0 Then
            FindMultiple.Show()
            FindMultiple.Query(Tquery, "", "CetakBarcodeSELECTedAll", 2)
        Else
            MsgBox("Tidak ada data yang ditampilkan.", MsgBoxStyle.Exclamation, "Warning!")
            Exit Sub
        End If
    End Sub

    Public Sub LoadPasien(ByRef Trow() As DataRow)
        If Trow.Length <> 0 Then
            CetakBarcodeToolStripMenuItem.Enabled = True
            BarcodeTambahanToolStripMenuItem.Enabled = True

            Dim Tquery As String = ""
            Dim Tstr As String = ""

            Dim Ttemp As String = "("
            For i As Integer = 0 To Trow.Length - 1
                Ttemp = Ttemp & "'" & Trow(i)("TransLabID").ToString.Trim & "',"
            Next
            Tstr = Strings.Left(Ttemp, Ttemp.Length - 1) & ")"

            Tquery = "SELECT ROW_NUMBER() OVER (ORDER BY a.Nourut) AS 'No', a.TransLabID,a.NoUrut,a.IDInternet,b.Nama, CONVERT(DATE, b.TglLahir) AS TglLahir, CONVERT(DATE, a.TglLab) AS TglLab " & _
            "FROM TransaksiLab a " & _
            "LEFT JOIN MasterPasien b on a.idinternet = b.NoRekamMedis " & _
            "WHERE TransLabID in " & Tstr & ""
            gridlab.DataSource = ReadSQL(Tquery)
        Else
            MsgBox("Tidak ada data yang ditampilkan.", MsgBoxStyle.Exclamation, "Warning!")
            Exit Sub
        End If
    End Sub

    Private Sub butfindcompany_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butfindcompany.Click
        Find.Show()
        Find.Query("SELECT IDCompany, CompanyCode, CompanyNama, NoCompany FROM mastercompany a WHERE getdate() between StartDate and EndDate", " ORDER BY a.idcompany desc", "FindCabangCetakBarcode", 2)
    End Sub

    Private Sub cbNoUrut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbNoUrut.CheckedChanged
        If cbNoUrut.Checked = True Then
            txNoUrut1.Enabled = True
            txNoUrut2.Enabled = True
            txNoUrut1.ResetText()
            txNoUrut2.ResetText()
        ElseIf cbNoUrut.Checked = False Then
            txNoUrut1.Enabled = False
            txNoUrut2.Enabled = False
            txNoUrut1.ResetText()
            txNoUrut2.ResetText()
        End If
    End Sub

    Private Sub txNoUrut1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txNoUrut1.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub txNoUrut2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txNoUrut2.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub barcode()
        CetakBarcodeToolStripMenuItem.Enabled = False
        BarcodeTambahanToolStripMenuItem.Enabled = False

        Dim Tpos As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='PathBarcode'")
        Dim KodeBarcode As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='KodeBarcode'")
        Dim Tpathprf As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='Pathprf'")
        Dim Ttx As String = Tpos & "Output.txt"
        Dim barcode As String = ""
        Dim totalrow As Integer = 0

        Dim Tinput As String = InputBox("Tambahan Cetakan Print Barcode : ", "Print Barcode", 2)
        If IsNumeric(Tinput) = False Then
            MsgBox("Masukkan Jumlah Barcode yang diprint.", MsgBoxStyle.Exclamation, "Warning!")
            ClearHeader()
            Exit Sub
        End If

        If CInt(Tinput) = 0 Then
            ClearHeader()
            Exit Sub
        End If

        If CInt(Tinput) > 10 Then
            MsgBox("Cetakan tidak boleh lebih dari 10.", MsgBoxStyle.Exclamation, "Warning!")
            ClearHeader()
            Exit Sub
        End If

        Try
            If Tinput > 0 Then
                Dim NoUrut As String = ""
                If rdNonMCU.Checked = True Then
                    NoUrut = "(" & txTransLabID1.Text & ")"
                ElseIf rdMCU.Checked = True Then
                    Dim TblsMCU As DataTable = gridlab.DataSource
                    NoUrut = ""
                    Dim Ttemp As String = "("
                    For Each TrowMCU As DataRow In TblsMCU.Rows
                        Ttemp = Ttemp & "'" & TrowMCU("TransLabID").ToString.Trim & "',"
                        totalrow = totalrow + 1
                    Next
                    NoUrut = Strings.Left(Ttemp, Ttemp.Length - 1) & ")"
                End If

                If totalrow * Tinput > 500 Then
                    MsgBox("Total barcode tidak boleh lebih dari 500 cetakan, total barcode anda adalah " & totalrow & " data x " & Tinput & " cetakan = " & totalrow * Tinput & " cetakan barcode.", MsgBoxStyle.Exclamation, "Warning!")
                    Exit Sub
                End If

                Dim Tbls2 As DataTable = ReadSQL("SELECT a.NoUrut,a.TransLabID,c.Nama,CONVERT(varchar(11),c.TglLahir,106) as TglLahir,c.JenisKelamin, a.LabSamplingTime " & _
                                                 "FROM TransaksiLab a " & _
                                                 "LEFT JOIN MasterPasien c on c.NoRekamMedis = a.IDInternet " & _
                                                 "WHERE a.TransLabID in " & NoUrut & "")
                If Tbls2.Rows.Count > 0 Then
                    For Each TrowData As DataRow In Tbls2.Rows

                        Dim Tstrtemp As String = ""
                        If TrowData("NoUrut").ToString.Contains("L") = True Then
                            Tstrtemp = Strings.Replace(TrowData("NoUrut").ToString.Trim, "L", "8")
                        ElseIf TrowData("NoUrut").ToString.Contains("M") = True Then
                            Tstrtemp = Strings.Replace(TrowData("NoUrut").ToString.Trim, "M", "9")
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

                        If IsDBNull(TrowData("LabSamplingTime")) = True Then
                            WriteSQL("update TransaksiLab set SendKeu=1, [Status]='CHECK', LabSamplingTime=getdate() WHERE TransLabID='" & TrowData("TransLabID").ToString.Trim & "' ", 4)
                        Else
                            WriteSQL("update TransaksiLab set SendKeu=1, [Status]='CHECK' WHERE TransLabID='" & TrowData("TransLabID").ToString.Trim & "' ", 4)
                        End If
                    Next
                Else
                    MsgBox("Tidak ada data yang di barcode.", MsgBoxStyle.Exclamation, "Warning!")
                    Exit Sub
                End If
            End If

            CetakBarcodeToolStripMenuItem.Enabled = True
            BarcodeTambahanToolStripMenuItem.Enabled = True
        Catch ex As Exception
            CetakBarcodeToolStripMenuItem.Enabled = True
            BarcodeTambahanToolStripMenuItem.Enabled = True

            If MsgBox(" Batal untuk Cetak Barcode tambahan ? ", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                Exit Sub
            Else
                MsgBox("Ulangi proses ketika siap")
            End If
        End Try
    End Sub

    Private Sub ScanHYUToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormScanHyu.Show()
    End Sub

    'Private Sub ButtonCariPasien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCariPasien.Click
    '    If String.IsNullOrEmpty(TextBoxScanHyu.Text.Trim()) Then
    '        MessageBox.Show("Silakan scan atau masukkan QR Code terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        TextBoxScanHyu.Focus()
    '        Exit Sub
    '    End If

    '    Dim urlWebService As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
    '    Dim url As String = urlWebService & "api/mcu/check-in/decode"

    '    Dim jsonParameter As String = "{""qr_code"": """ & TextBoxScanHyu.Text.Trim() & """}"

    '    Try
    '        Dim jsonResult As String = InsertDataAPIRM(jsonParameter, url)
    '        Dim jObj As JObject = JObject.Parse(jsonResult)

    '        If jObj("success") IsNot Nothing AndAlso CBool(jObj("success")) = True Then
    '            Dim nik As String = jObj("data")("nik").ToString()
    '            Dim sessionCode As String = jObj("data")("session_code").ToString()

    '            Dim Takhir As Date = DateSerial(DateAndTime.Now.Year, DateAndTime.Now.Month, DateAndTime.Now.Day).AddDays(30)
    '            Dim Tawal As Date = DateAdd(DateInterval.Day, -90, Takhir.Date)

    '            ' 1. Susun string query SQL dengan tambahan filter NIK hasil decode
    '            Dim querySQL As String = "SELECT a.TransLabID, a.NoUrut, a.IDInternet, b.Nama, b.TglLahir, b.NoNIK AS nik, a.TglLab, a.Status " & _
    '                      "FROM TransaksiLab a " & _
    '                      "LEFT JOIN MasterPasien b on a.idinternet = b.NoRekamMedis " & _
    '                      "WHERE a.ClosedTransaksi=1 and Status in ('SAMPLE','CHECK') " & _
    '                      "and CONVERT(date, a.TglLab) = CONVERT(date, GETDATE()) " & _
    '                      "and a.deleted<>1 and b.NoNIK = '" & nik.Trim() & "' "

    '            ' 2. Jalankan ReadSQL terlebih dahulu untuk memeriksa apakah transaksi pasien ini ada
    '            Dim dtCheck As DataTable = ReadSQL(querySQL)

    '            If dtCheck.Rows.Count > 0 Then
    '                Dim rowView As DataRowView = dtCheck.DefaultView(0)

    '                LoadTransLabHyu(rowView)

    '                _nikPasienAktif = nik.Trim()
    '                _sessionCodeAktif = sessionCode.Trim()

    '                Dim noUrutLog As String = rowView("NoUrut").ToString().Trim()
    '                Dim jsonCheckIn As String = ""
    '                Dim urlCheckIn As String = urlWebService & "api/mcu/check-in/" & _sessionCodeAktif & "/post/pendaftaran"

    '                ' =======================================================================
    '                ' ANTI-DOUBLE POST CHECK
    '                ' =======================================================================
    '                Dim queryCekLog As String = "SELECT COUNT(*) FROM log_api_checkin " & _
    '                                            "WHERE no_urut = '" & noUrutLog & "' " & _
    '                                            "AND nik = '" & _nikPasienAktif & "' " & _
    '                                            "AND session_code = '" & _sessionCodeAktif & "' " & _
    '                                            "AND status_log = 'SUCCESS' " & _
    '                                            "AND response LIKE '%processing%'"

    '                Dim totalLogSukses As Integer = Val(ReadSQLNIK(queryCekLog))

    '                If totalLogSukses > 0 Then
    '                    MsgBox("Pasien sudah berhasil diproses (Status: Processing) sebelumnya!", MsgBoxStyle.Information, "Informasi")
    '                Else
    '                    ' JALANKAN API JIKA BELUM PERNAH SUKSES
    '                    Try
    '                        jsonCheckIn = "{" & _
    '                            """identifier"":""" & _nikPasienAktif & """," & _
    '                            """identifier_type"":""nik""," & _
    '                            """status"":""processing""," & _
    '                            """notes"":""-""" & _
    '                            "}"

    '                        Dim resCheckIn As String = InsertDataAPIRM(jsonCheckIn, urlCheckIn)
    '                        Dim jObjRes As JObject = JObject.Parse(resCheckIn)
    '                        Dim msgTampil As String = "Pendaftaran MCU berhasil diproses dan dikirim ke HYU!"

    '                        If jObjRes("message") IsNot Nothing Then
    '                            msgTampil = jObjRes("message").ToString()
    '                        End If

    '                        MsgBox(msgTampil, MsgBoxStyle.Information, "Sukses API")

    '                        Dim safePayload As String = jsonCheckIn.Replace("'", "''")
    '                        Dim safeResponse As String = resCheckIn.Replace("'", "''")

    '                        WriteSQL("INSERT INTO log_api_checkin (no_urut, nik, session_code, url_api, payload, response, status_log, created_date) " & _
    '                                 "VALUES ('" & noUrutLog & "', '" & _nikPasienAktif & "', '" & _sessionCodeAktif & "', '" & urlCheckIn & "', '" & safePayload & "', '" & safeResponse & "', 'SUCCESS', GETDATE())", 4)

    '                    Catch exCheckIn As Exception
    '                        MsgBox("Gagal kirim pendaftaran ke API: " & exCheckIn.Message, MsgBoxStyle.Critical, "Debug API")

    '                        Dim safePayloadErr As String = jsonCheckIn.Replace("'", "''")
    '                        Dim safeException As String = exCheckIn.Message.Replace("'", "''")

    '                        ' FIX: Menggunakan urlCheckIn agar terhindar dari variable undefined di context ini
    '                        WriteSQL("INSERT INTO log_api_checkin (no_urut, nik, session_code, url_api, payload, response, status_log, created_date) " & _
    '                                 "VALUES ('" & noUrutLog & "', '" & _nikPasienAktif & "', '" & _sessionCodeAktif & "', '" & urlCheckIn & "', '" & safePayloadErr & "', '" & safeException & "', 'FAILED', GETDATE())", 4)
    '                    End Try
    '                End If ' [FIX STRUCT] Penutupan blok anti-double post di sini, tidak membungkus kebawah

    '                ' =======================================================================
    '                ' OTOMATISASI API EXCLUDE
    '                ' =======================================================================
    '                Try
    '                    Dim idTransaksi As String = txTransLabID1.Text.Trim()

    '                    Dim queryCekThorax As String = "SELECT COUNT(*) " & _
    '                           "FROM TransaksiLabDetail td " & _
    '                           "INNER JOIN mapping_pos mp ON td.TindakanID = mp.TindakanID " & _
    '                           "WHERE td.TransLabID = '" & idTransaksi & "' AND LOWER(mp.KodePOS) = 'thorax'"

    '                    Dim adaThorax As Integer = Val(ReadSQLNIK(queryCekThorax))

    '                    If adaThorax > 0 Then
    '                        PanelThorax.Visible = True
    '                        rdThoraxSetuju.Checked = True
    '                        txtAlasanThorax.Text = ""
    '                        txtAlasanThorax.Enabled = False
    '                    Else
    '                        PanelThorax.Visible = False
    '                        rdThoraxSetuju.Checked = False
    '                        rdThoraxTolak.Checked = False
    '                        txtAlasanThorax.Text = ""
    '                    End If

    '                    Dim queryExclude As String = _
    '                        "SELECT KodePOS FROM (VALUES " & _
    '                        "  ('pendaftaran'), ('tt_tb'), ('screening'), ('visus'), ('dokter'), " & _
    '                        "  ('darah'), ('urine'), ('thorax'), ('spiro'), ('audio'), " & _
    '                        "  ('ecg'), ('usg'), ('treadmill')" & _
    '                        ") AS ALL_POS(KodePOS) " & _
    '                        "EXCEPT " & _
    '                        "SELECT DISTINCT mp.KodePOS " & _
    '                        "FROM TransaksiLabDetail td " & _
    '                        "INNER JOIN mapping_pos mp ON td.TindakanID = mp.TindakanID " & _
    '                        "WHERE td.TransLabID = '" & idTransaksi & "'"

    '                    Dim dtExclude As DataTable = ReadSQL(queryExclude)

    '                    For Each rowEx As DataRow In dtExclude.Rows
    '                        Dim posExclude As String = rowEx("KodePOS").ToString().Trim()

    '                        If posExclude <> "pendaftaran" Then
    '                            Dim urlCheckInEx As String = urlWebService & "api/mcu/check-in/" & _sessionCodeAktif & "/post/" & posExclude

    '                            Dim jsonExclude As String = "{" & _
    '                                """identifier"":""" & _nikPasienAktif & """," & _
    '                                """identifier_type"":""nik""," & _
    '                                """status"":""exclude""," & _
    '                                """notes"":""Peserta Tidak Memiliki Paket""" & _
    '                                "}"

    '                            InsertDataAPIRM(jsonExclude, urlCheckInEx)
    '                        End If
    '                    Next

    '                Catch exExclude As Exception
    '                    MsgBox("Gagal otomatisasi API Exclude: " & exExclude.Message)
    '                End Try

    '                ' =======================================================================
    '                ' DETEKSI RUTE POS UNTUK VISUAL / DEBUG
    '                ' =======================================================================
    '                Try
    '                    Dim idTransaksi As String = txTransLabID1.Text

    '                    Dim queryPOS As String = "SELECT DISTINCT mp.KodePOS " & _
    '                                             "FROM TransaksiLabDetail td " & _
    '                                             "INNER JOIN mapping_pos mp ON td.TindakanID = mp.TindakanID " & _
    '                                             "WHERE td.TransLabID = '" & idTransaksi & "'"

    '                    Dim dtPOS As DataTable = ReadSQL(queryPOS)

    '                    If dtPOS.Rows.Count > 0 Then
    '                        Dim ruteTeks As String = ""
    '                        Dim nomor As Integer = 1

    '                        For Each rowPOS As DataRow In dtPOS.Rows
    '                            Dim namaPOS As String = rowPOS("KodePOS").ToString().Trim().ToUpper()
    '                            ruteTeks &= nomor.ToString() & ". POS: " & namaPOS & vbCrLf
    '                            nomor += 1
    '                        Next
    '                    End If

    '                Catch exDebug As Exception
    '                    MsgBox("Gagal mendeteksi rute POS: " & exDebug.Message, MsgBoxStyle.Critical, "Error Debug")
    '                End Try

    '            Else
    '                Find.Show()
    '                Find.Query(querySQL, " order by a.NoUrut desc ", "FindTransaksiBarcode", 0)
    '                MessageBox.Show("Transaksi lab untuk NIK " & nik & " tidak ditemukan pada range tanggal ini.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            End If

    '        Else
    '            ' Pasangan dari: If jObj("success") IsNot Nothing AndAlso CBool(jObj("success")) = True Then
    '            Dim message As String = "Gagal memproses data."
    '            If jObj("message") IsNot Nothing Then
    '                message = jObj("message").ToString()
    '            End If
    '            MessageBox.Show("Respon Server Gagal: " & message, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        End If

    '        If Not String.IsNullOrEmpty(_sessionCodeAktif) Then
    '            lblStatusMCU.Text = "MCU Active | Sesi HYU!: " & _sessionCodeAktif
    '            lblStatusMCU.ForeColor = Color.Green
    '        Else
    '            lblStatusMCU.Text = "MCU Non-Aktif / Sesi HYU! Tidak Ditemukan"
    '            lblStatusMCU.ForeColor = Color.Red
    '        End If

    '    Catch ex As Exception
    '        MessageBox.Show("Terjadi kesalahan sistem atau format JSON tidak sesuai: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    ' Structure data penampung parameter untuk ThreadPool (Kompatibel VB.NET 2008)
    Private Structure CheckInParam
        Public NoUrutLog As String
        Public Nik As String
        Public SessionCode As String
        Public UrlCheckIn As String
    End Structure

    Private Sub ButtonCariPasien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCariPasien.Click
        If String.IsNullOrEmpty(TextBoxScanHyu.Text.Trim()) Then
            MessageBox.Show("Silakan scan atau masukkan QR Code terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextBoxScanHyu.Focus()
            Exit Sub
        End If

        If String.IsNullOrEmpty(_sessionCodeAktif) Then
            MessageBox.Show("Sesi MCU belum aktif! Silakan jalankan 'Ambil Sesi' terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim urlWebService As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
        Dim urlDecode As String = urlWebService & "api/mcu/check-in/decode"
        Dim jsonParameter As String = "{""qr_code"": """ & TextBoxScanHyu.Text.Trim() & """}"

        Try
            ' 1. Decode QR via API
            Dim jsonResult As String = InsertDataAPIRM(jsonParameter, urlDecode)
            Dim jObj As JObject = JObject.Parse(jsonResult)

            If jObj("success") IsNot Nothing AndAlso CBool(jObj("success")) = True Then
                Dim dataObj As JObject = CType(jObj("data"), JObject)

                Dim nik As String = If(dataObj("nik") IsNot Nothing, dataObj("nik").ToString().Trim(), "")
                'Dim sessionCode As String = If(dataObj("session_code") IsNot Nothing, dataObj("session_code").ToString().Trim(), "")
                Dim noUrut As String = If(dataObj("nourut") IsNot Nothing, dataObj("nourut").ToString().Trim(), "")
                Dim checkInStatusText As String = If(dataObj("check_in_status") IsNot Nothing, dataObj("check_in_status").ToString().ToLower().Trim(), "pending")

                ' Jika status masih pending / belum checkin utama, batalkan proses & berikan peringatan
                If checkInStatusText <> "checked_in" Then
                    MessageBox.Show("Peserta belum melakukan CHECK-IN (Status saat ini: " & checkInStatusText & "), Silakan menuju ke CHECKIN KIOSK!", _
                                    "Peringatan Check-In", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                ' OPTIMASI SQL (NET 3.5 Compatible): Menggunakan Range Tanggal agar Index Seek di SQL Server
                Dim querySQL As String = "SELECT a.TransLabID, a.NoUrut, a.IDInternet, b.Nama, b.TglLahir, b.NoNIK AS nik, a.TglLab, a.Status " & _
                                          "FROM TransaksiLab a " & _
                                          "LEFT JOIN MasterPasien b ON a.idinternet = b.NoRekamMedis " & _
                                          "WHERE a.ClosedTransaksi = 1 AND a.Status IN ('SAMPLE','CHECK') " & _
                                          "AND a.TglLab >= CAST(GETDATE() AS DATE) AND a.TglLab < DATEADD(day, 1, CAST(GETDATE() AS DATE)) " & _
                                          "AND a.deleted <> 1 AND b.NoNIK = '" & nik & "' AND a.NoUrut = '" & noUrut & "'"

                Dim dtCheck As DataTable = ReadSQL(querySQL)

                If dtCheck.Rows.Count > 0 Then
                    Dim rowView As DataRowView = dtCheck.DefaultView(0)

                    ' Load data pasien & UI lokal secara instan
                    LoadTransLabHyu(rowView)

                    _nikPasienAktif = nik
                    Dim noUrutLog As String = rowView("NoUrut").ToString().Trim()
                    Dim idTransaksi As String = txTransLabID1.Text.Trim()

                    Dim teksPemeriksaanKhusus As String = GetPemeriksaanKhususPasien(idTransaksi)

                    If Not String.IsNullOrEmpty(teksPemeriksaanKhusus) Then
                        txtPemeriksaanKhusus.Text = teksPemeriksaanKhusus
                        txtPemeriksaanKhusus.ForeColor = Color.DarkRed
                    Else
                        txtPemeriksaanKhusus.Text = "-"
                        txtPemeriksaanKhusus.ForeColor = Color.Black
                    End If

                    ' Cek Tampilan Panel Thorax (Lokal SQL - Cepat)
                    Dim queryCekThorax As String = "SELECT COUNT(1) FROM TransaksiLabDetail td " & _
                                                   "INNER JOIN mapping_pos mp ON td.TindakanID = mp.TindakanID " & _
                                                   "WHERE td.TransLabID = '" & idTransaksi & "' AND LOWER(mp.KodePOS) = 'thorax'"

                    Dim totalThorax As Integer = Val(ReadSQLNIK(queryCekThorax))
                    PanelThorax.Visible = (totalThorax > 0)

                    ' =======================================================================
                    ' OPTIMASI ASINKRON: EKSEKUSI CHECK-IN API DI BACKGROUND THREAD
                    ' =======================================================================
                    Dim paramCheckIn As New CheckInParam With { _
                        .NoUrutLog = noUrutLog, _
                        .Nik = _nikPasienAktif, _
                        .SessionCode = _sessionCodeAktif, _
                        .UrlCheckIn = urlWebService & "api/mcu/check-in/" & _sessionCodeAktif & "/post/pendaftaran" _
                    }

                    ' Kirim ke ThreadPool agar UI tidak terhenti sama sekali
                    System.Threading.ThreadPool.QueueUserWorkItem(AddressOf ProcessPostPendaftaranInBackground, paramCheckIn)

                Else
                    Find.Show()
                    Find.Query(querySQL, " order by a.NoUrut desc ", "FindTransaksiBarcode", 0)
                    MessageBox.Show("Transaksi lab untuk NIK " & nik & " tidak ditemukan pada hari ini.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                Dim message As String = If(jObj("message") IsNot Nothing, jObj("message").ToString(), "Gagal memproses data.")
                MessageBox.Show("Respon Server Gagal: " & message, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            ' Update Status Label
            If Not String.IsNullOrEmpty(_sessionCodeAktif) Then
                lblStatusMCU.Text = "MCU Active | Sesi HYU!: " & _sessionCodeAktif
                lblStatusMCU.ForeColor = Color.Green
            Else
                lblStatusMCU.Text = "MCU Non-Aktif / Sesi HYU! Tidak Ditemukan"
                lblStatusMCU.ForeColor = Color.Red
            End If

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan sistem: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ProcessPostPendaftaranInBackground(ByVal state As Object)
        Try
            Dim param As CheckInParam = CType(state, CheckInParam)

            ' 1. Cek Anti Double Post ke Database Log
            Dim queryCekLog As String = "SELECT COUNT(*) FROM log_api_checkin " & _
                                        "WHERE no_urut = '" & param.NoUrutLog & "' AND nik = '" & param.Nik & "' " & _
                                        "AND session_code = '" & param.SessionCode & "' AND status_log = 'SUCCESS' " & _
                                        "AND response LIKE '%processing%'"

            Dim totalLogSukses As Integer = Val(ReadSQLNIK(queryCekLog))

            ' 2. Jika belum pernah dikirim, lakukan POST HTTP
            If totalLogSukses = 0 Then
                Try
                    Dim jsonCheckIn As String = "{""identifier"":""" & param.Nik & """,""identifier_type"":""nik"",""status"":""processing"",""notes"":""-""}"
                    Dim resCheckIn As String = InsertDataAPIRM(jsonCheckIn, param.UrlCheckIn)

                    ' Log Sukses ke SQL Server
                    Dim safePayload As String = jsonCheckIn.Replace("'", "''")
                    Dim safeResponse As String = resCheckIn.Replace("'", "''")
                    WriteSQL("INSERT INTO log_api_checkin (no_urut, nik, session_code, url_api, payload, response, status_log, created_date) " & _
                             "VALUES ('" & param.NoUrutLog & "', '" & param.Nik & "', '" & param.SessionCode & "', '" & param.UrlCheckIn & "', '" & safePayload & "', '" & safeResponse & "', 'SUCCESS', GETDATE())", 4)
                Catch exCheckIn As Exception
                    ' Log Gagal ke SQL Server jika koneksi terputus/down
                    Dim safePayloadErr As String = "{""identifier"":""" & param.Nik & """}".Replace("'", "''")
                    Dim safeException As String = exCheckIn.Message.Replace("'", "''")
                    WriteSQL("INSERT INTO log_api_checkin (no_urut, nik, session_code, url_api, payload, response, status_log, created_date) " & _
                             "VALUES ('" & param.NoUrutLog & "', '" & param.Nik & "', '" & param.SessionCode & "', '" & param.UrlCheckIn & "', '" & safePayloadErr & "', '" & safeException & "', 'FAILED', GETDATE())", 4)
                End Try
            End If

        Catch ex As Exception
            ' Tangkap exception background agar tidak mengganggu UI utama
            System.Diagnostics.Debug.WriteLine("Error Background Check-In: " & ex.Message)
        End Try
    End Sub

    'sebelum hapus session checkin
    'Private Sub ButtonCariPasien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCariPasien.Click
    '    If String.IsNullOrEmpty(TextBoxScanHyu.Text.Trim()) Then
    '        MessageBox.Show("Silakan scan atau masukkan QR Code terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        TextBoxScanHyu.Focus()
    '        Exit Sub
    '    End If

    '    Dim urlWebService As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
    '    Dim url As String = urlWebService & "api/mcu/check-in/decode"
    '    Dim jsonParameter As String = "{""qr_code"": """ & TextBoxScanHyu.Text.Trim() & """}"

    '    Try
    '        ' 1. Decode QR via API
    '        Dim jsonResult As String = InsertDataAPIRM(jsonParameter, url)
    '        Dim jObj As JObject = JObject.Parse(jsonResult)

    '        If jObj("success") IsNot Nothing AndAlso CBool(jObj("success")) = True Then
    '            Dim nik As String = jObj("data")("nik").ToString().Trim()
    '            Dim sessionCode As String = jObj("data")("session_code").ToString().Trim()

    '            Dim urlCekStatus As String = urlWebService & "api/mcu/check-status?session_code=" & sessionCode & "&nik=" & nik
    '            Dim jsonCekStatus As String = GetDataAPIRM(urlCekStatus)

    '            Dim checkInStatusText As String = "pending"
    '            Dim noUrut As String = ""

    '            If Not String.IsNullOrEmpty(jsonCekStatus) Then
    '                Try
    '                    Dim jObjStatus As JObject = JObject.Parse(jsonCekStatus)

    '                    If jObjStatus("success") IsNot Nothing AndAlso CBool(jObjStatus("success")) = True Then
    '                        ' Gunakan JToken/SelectToken agar aman dari null exception
    '                        Dim participants As JArray = TryCast(jObjStatus("data")("participants"), JArray)

    '                        If participants IsNot Nothing AndAlso participants.Count > 0 Then
    '                            ' Ambil elemen pertama
    '                            Dim participant As JObject = CType(participants(0), JObject)

    '                            If participant("check_in_status") IsNot Nothing Then
    '                                checkInStatusText = participant("check_in_status").ToString().ToLower().Trim()
    '                            End If

    '                            If participant("nourut") IsNot Nothing Then
    '                                noUrut = participant("nourut").ToString().Trim()
    '                            End If
    '                        End If
    '                    End If
    '                Catch ex As Exception
    '                    ' Log error jika JSON gagal di-parse
    '                    System.Diagnostics.Debug.WriteLine("Error Parse Cek Status: " & ex.Message)
    '                End Try
    '            End If

    '            ' Jika status masih pending / belum checkin utama, batalkan proses & berikan peringatan
    '            If checkInStatusText <> "checked_in" Then
    '                MessageBox.Show("Peserta belum melakukan CHECK-IN (Status saat ini: " & checkInStatusText & "), Silakan menuju ke CHECKIN KIOSK!", _
    '                                "Peringatan Check-In", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                Exit Sub
    '            End If

    '            ' OPTIMASI SQL (NET 3.5 Compatible): Menggunakan Range Tanggal agar Index Seek di SQL Server
    '            Dim querySQL As String = "SELECT a.TransLabID, a.NoUrut, a.IDInternet, b.Nama, b.TglLahir, b.NoNIK AS nik, a.TglLab, a.Status " & _
    '                      "FROM TransaksiLab a " & _
    '                      "LEFT JOIN MasterPasien b ON a.idinternet = b.NoRekamMedis " & _
    '                      "WHERE a.ClosedTransaksi = 1 AND a.Status IN ('SAMPLE','CHECK') " & _
    '                      "AND a.TglLab >= CAST(GETDATE() AS DATE) AND a.TglLab < DATEADD(day, 1, CAST(GETDATE() AS DATE)) " & _
    '                      "AND a.deleted <> 1 AND b.NoNIK = '" & nik & "' AND a.NoUrut = '" & noUrut & "'"

    '            Dim dtCheck As DataTable = ReadSQL(querySQL)

    '            If dtCheck.Rows.Count > 0 Then
    '                Dim rowView As DataRowView = dtCheck.DefaultView(0)
    '                LoadTransLabHyu(rowView)

    '                _nikPasienAktif = nik
    '                _sessionCodeAktif = sessionCode
    '                Dim noUrutLog As String = rowView("NoUrut").ToString().Trim()
    '                Dim idTransaksi As String = txTransLabID1.Text.Trim()
    '                Dim urlCheckIn As String = urlWebService & "api/mcu/check-in/" & _sessionCodeAktif & "/post/pendaftaran"

    '                ' 2. Cek Anti Double Post
    '                Dim queryCekLog As String = "SELECT COUNT(*) FROM log_api_checkin " & _
    '                                            "WHERE no_urut = '" & noUrutLog & "' AND nik = '" & _nikPasienAktif & "' " & _
    '                                            "AND session_code = '" & _sessionCodeAktif & "' AND status_log = 'SUCCESS' " & _
    '                                            "AND response LIKE '%processing%'"

    '                Dim totalLogSukses As Integer = Val(ReadSQLNIK(queryCekLog))

    '                If totalLogSukses = 0 Then
    '                    Try
    '                        Dim jsonCheckIn As String = "{""identifier"":""" & _nikPasienAktif & """,""identifier_type"":""nik"",""status"":""processing"",""notes"":""-""}"
    '                        Dim resCheckIn As String = InsertDataAPIRM(jsonCheckIn, urlCheckIn)
    '                        Dim jObjRes As JObject = JObject.Parse(resCheckIn)
    '                        Dim msgTampil As String = If(jObjRes("message") IsNot Nothing, jObjRes("message").ToString(), "Pendaftaran MCU berhasil diproses!")

    '                        ' Log ke DB
    '                        Dim safePayload As String = jsonCheckIn.Replace("'", "''")
    '                        Dim safeResponse As String = resCheckIn.Replace("'", "''")
    '                        WriteSQL("INSERT INTO log_api_checkin (no_urut, nik, session_code, url_api, payload, response, status_log, created_date) " & _
    '                                 "VALUES ('" & noUrutLog & "', '" & _nikPasienAktif & "', '" & _sessionCodeAktif & "', '" & urlCheckIn & "', '" & safePayload & "', '" & safeResponse & "', 'SUCCESS', GETDATE())", 4)
    '                    Catch exCheckIn As Exception
    '                        Dim safePayloadErr As String = "{""identifier"":""" & _nikPasienAktif & """}".Replace("'", "''")
    '                        Dim safeException As String = exCheckIn.Message.Replace("'", "''")
    '                        WriteSQL("INSERT INTO log_api_checkin (no_urut, nik, session_code, url_api, payload, response, status_log, created_date) " & _
    '                                 "VALUES ('" & noUrutLog & "', '" & _nikPasienAktif & "', '" & _sessionCodeAktif & "', '" & urlCheckIn & "', '" & safePayloadErr & "', '" & safeException & "', 'FAILED', GETDATE())", 4)
    '                    End Try
    '                End If

    '                ' 3. Ambil Exclude List dari SQL
    '                Dim queryExclude As String = "SELECT KodePOS FROM (VALUES ('pendaftaran'), ('tt_tb'), ('screening'), ('visus'), ('dokter'), " & _
    '                                            "('darah'), ('urine'), ('thorax'), ('spiro'), ('audio'), ('ecg'), ('usg'), ('treadmill'), ('rectal_swab')) AS ALL_POS(KodePOS) " & _
    '                                            "EXCEPT SELECT DISTINCT mp.KodePOS FROM TransaksiLabDetail td " & _
    '                                            "INNER JOIN mapping_pos mp ON td.TindakanID = mp.TindakanID WHERE td.TransLabID = '" & idTransaksi & "'"

    '                Dim dtExclude As DataTable = ReadSQL(queryExclude)

    '                ' UI Update Thorax Panel (Cek Thorax via DataTable)
    '                Dim adaThorax As Boolean = False
    '                For Each r As DataRow In dtExclude.Rows
    '                    If r("KodePOS").ToString().Trim().ToLower() = "thorax" Then
    '                        adaThorax = True
    '                        Exit For
    '                    End If
    '                Next
    '                PanelThorax.Visible = Not adaThorax

    '                ' =======================================================================
    '                ' OPTIMASI VB.NET 2008: Eksekusi Background via System.Threading.ThreadPool
    '                ' =======================================================================
    '                Dim paramBackground As New BackgroundParam With { _
    '                    .DtExclude = dtExclude, _
    '                    .SessionCode = _sessionCodeAktif, _
    '                    .Nik = _nikPasienAktif, _
    '                    .UrlWebService = urlWebService _
    '                }

    '                ' Kirim loop HTTP Request ke ThreadPool agar UI tidak macet/freeze
    '                System.Threading.ThreadPool.QueueUserWorkItem(AddressOf ProcessExcludeApiInBackground, paramBackground)

    '            Else
    '                Find.Show()
    '                Find.Query(querySQL, " order by a.NoUrut desc ", "FindTransaksiBarcode", 0)
    '                MessageBox.Show("Transaksi lab untuk NIK " & nik & " tidak ditemukan pada hari ini.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            End If
    '        Else
    '            Dim message As String = If(jObj("message") IsNot Nothing, jObj("message").ToString(), "Gagal memproses data.")
    '            MessageBox.Show("Respon Server Gagal: " & message, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        End If

    '        ' Update Status Label
    '        If Not String.IsNullOrEmpty(_sessionCodeAktif) Then
    '            lblStatusMCU.Text = "MCU Active | Sesi HYU!: " & _sessionCodeAktif
    '            lblStatusMCU.ForeColor = Color.Green
    '        Else
    '            lblStatusMCU.Text = "MCU Non-Aktif / Sesi HYU! Tidak Ditemukan"
    '            lblStatusMCU.ForeColor = Color.Red
    '        End If

    '    Catch ex As Exception
    '        MessageBox.Show("Terjadi kesalahan sistem: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    Public Function GetActiveSessionCode(ByVal kodeServer As String) As String
        Dim sessionCode As String = ""

        Dim baseUrl As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")

        If Not baseUrl.EndsWith("/") Then
            baseUrl &= "/"
        End If

        Dim finalUrl As String = String.Format("{0}api/mcu/active-session?kode_server={1}", _
                                 baseUrl, _
                                 Uri.EscapeDataString(kodeServer))

        Try
            Dim jsonResponse As String = GetDataAPIRM(finalUrl)

            Dim jsonObj As JObject = JObject.Parse(jsonResponse)

            If jsonObj("success") IsNot Nothing AndAlso CType(jsonObj("success"), Boolean) = True Then
                sessionCode = jsonObj("session_code").ToString()
            End If

        Catch ex As Exception
            Dim errMsg As String = ex.Message
        End Try

        Return sessionCode
    End Function

    Private Sub TextBoxScanHyu_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxScanHyu.KeyDown
        ' Cek apakah tombol yang ditekan adalah Enter (Alat scan otomatis mengirim karakter Enter di akhir)
        If e.KeyCode = Keys.Enter Then
            ' Mencegah bunyi "beep" default dari Windows saat menekan Enter di TextBox
            e.SuppressKeyPress = True

            ' Jalankan langsung fungsi cari pasien
            ButtonCariPasien_Click(ButtonCariPasien, EventArgs.Empty)
        End If
    End Sub

    'Private Sub txTransLabID1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txTransLabID1.TextChanged
    '    If Not String.IsNullOrEmpty(txTransLabID1.Text.Trim()) Then

    '        ' 1. Pastikan data pasien aktif (_nikPasienAktif) sudah terisi dari pencarian sebelumnya
    '        'If String.IsNullOrEmpty(_nikPasienAktif) Then
    '        '    MessageBox.Show("Silahkan cari pasien menggunakan Nomor Urut terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '        '    TextBoxScanHyu.Focus()
    '        '    Exit Sub
    '        'End If

    '        ' 2. Kunci Post Key secara permanen ke "pendaftaran" sesuai instruksi
    '        Dim postKey As String = "pendaftaran"

    '        ' 3. Ambil Session Code otomatis
    '        Dim kodeServerLokal As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NoPoli'")
    '        Dim sessionCode As String = GetActiveSessionCode(kodeServerLokal)

    '        If String.IsNullOrEmpty(sessionCode) Then
    '            MessageBox.Show("Gagal mendapatkan Kode Sesi aktif untuk hari ini.", "Sesi Tidak Ditemukan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '            Exit Sub
    '        End If

    '        ' 4. Ambil Base URL
    '        Dim baseUrl As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
    '        If Not baseUrl.EndsWith("/") Then
    '            baseUrl &= "/"
    '        End If

    '        Dim finalUrl As String = String.Format("{0}api/mcu/check-in/{1}/post/{2}", baseUrl, sessionCode, postKey)

    '        ' 5. Susun Payload JSON dengan status "processing"
    '        Dim jsonPayload As String = String.Format("{{""identifier"":""{0}"",""identifier_type"":""nik"",""status"":""processing""}}", _nikPasienAktif)

    '        Dim isProsesSukses As Boolean = False

    '        Try
    '            Me.Cursor = Cursors.WaitCursor

    '            ' 6. Kirim data otomatis ke API
    '            Dim jsonResponse As String = InsertDataAPIRM(jsonPayload, finalUrl)
    '            Dim jsonObj As JObject = JObject.Parse(jsonResponse)

    '            If jsonObj("success") IsNot Nothing AndAlso CType(jsonObj("success"), Boolean) = True Then
    '                isProsesSukses = True

    '                ' UX Pilihan: Anda bisa menghilangkan MessageBox ini agar proses terasa mulus/silent bagi petugas
    '                MessageBox.Show("Otomatis memulai tracking untuk Pos Pendaftaran!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

    '            Else
    '                Dim msg As String = If(jsonObj("message") IsNot Nothing, jsonObj("message").ToString(), "")

    '                If msg.Contains("Duplicate entry") Or msg.Contains("1062") Then
    '                Else
    '                    MessageBox.Show(If(msg = "", "Gagal memproses tracking otomatis.", msg), "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    '                End If
    '            End If

    '        Catch ex As Exception
    '            MessageBox.Show("Terjadi kesalahan sistem otomatis: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        Finally
    '            Me.Cursor = Cursors.Default
    '        End Try
    '    End If
    'End Sub

    'Private Sub txTransLabID1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txTransLabID1.KeyDown
    '    If e.KeyCode = Keys.Enter Then
    '        e.SuppressKeyPress = True ' Menghilangkan bunyi beep Windows
    '    End If
    'End Sub

    Private Sub rdThoraxTolak_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdThoraxTolak.CheckedChanged
        txtAlasanThorax.Enabled = rdThoraxTolak.Checked
    End Sub

    Public Function GetPemeriksaanKhususPasien(ByVal idTransLab As String) As String
        Dim hasilTeks As String = ""

        Try
            ' Query Join dari Detail Transaksi Pasien ke Master Pemeriksaan Khusus
            Dim query As String = _
                "SELECT DISTINCT ISNULL(mpk.NamaPemeriksaanKhusus, td.NamaTindakan) AS NamaKhusus " & _
                "FROM TransaksiLabDetail td " & _
                "INNER JOIN ms_pemeriksaan_khusus mpk ON td.TindakanID = mpk.TindakanID " & _
                "WHERE td.TransLabID = '" & idTransLab.Replace("'", "''") & "' " & _
                "AND mpk.IsAktif = 1"

            Dim dtKhusus As DataTable = ReadSQL(query)

            If dtKhusus IsNot Nothing AndAlso dtKhusus.Rows.Count > 0 Then
                Dim listNama As New List(Of String)

                For Each row As DataRow In dtKhusus.Rows
                    Dim nama As String = row("NamaKhusus").ToString().Trim()
                    If Not String.IsNullOrEmpty(nama) Then
                        listNama.Add(nama)
                    End If
                Next

                ' Gabungkan dengan koma dan spasi (misal: "SPIROMETRI, AUDIOMETRI, ECG")
                ' Jika ingin per baris (multiline), ganti ", " dengan vbCrLf
                hasilTeks = String.Join(", ", listNama.ToArray())
            End If

        Catch ex As Exception
            System.Diagnostics.Debug.WriteLine("Error GetPemeriksaanKhususPasien: " & ex.Message)
        End Try

        Return hasilTeks
    End Function

    Private Sub LoadSessionCodeLokal()
        Try
            Dim tglHariIni As String = DateTime.Today.ToString("yyyy-MM-dd")
            Dim urlWebService As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")

            ' 1. Query Cek Database Lokal
            Dim queryCekLokal As String = String.Format( _
                "SELECT session_id, session_code, session_name, lokasi, kode_poli, status " & _
                "FROM mcu_sessions " & _
                "WHERE CONVERT(VARCHAR(10), tgl_mcu, 120) = '{0}' AND status = 'active' " & _
                "ORDER BY session_id DESC", tglHariIni)

            Dim dtLokal As DataTable = ReadSQL(queryCekLokal)

            If dtLokal IsNot Nothing AndAlso dtLokal.Rows.Count > 0 Then
                ' Jika data sesi ada di database lokal
                Dim sessionCode As String = dtLokal.Rows(0)("session_code").ToString().Trim()
                Dim sessionName As String = dtLokal.Rows(0)("session_name").ToString().Trim()

                _sessionCodeAktif = sessionCode

                lblStatusMCU.Text = "MCU Active | Sesi: " & sessionCode & " - " & sessionName
                lblStatusMCU.ForeColor = Color.Green
            Else
                ' 2. Jika di lokal belum ada data, otomatis tarik dari API & simpan ke lokal
                If Not String.IsNullOrEmpty(urlWebService) Then
                    Dim urlApiSession As String = urlWebService & "api/mcu/sessions"
                    Dim suksesTarikAPI As Boolean = FetchAndSaveMcuSessions(tglHariIni, urlApiSession)

                    If suksesTarikAPI Then
                        Dim dtBaru As DataTable = ReadSQL(queryCekLokal)
                        If dtBaru IsNot Nothing AndAlso dtBaru.Rows.Count > 0 Then
                            Dim sessionCode As String = dtBaru.Rows(0)("session_code").ToString().Trim()
                            Dim sessionName As String = dtBaru.Rows(0)("session_name").ToString().Trim()

                            _sessionCodeAktif = sessionCode

                            lblStatusMCU.Text = "MCU Active | Sesi: " & sessionCode & " - " & sessionName
                            lblStatusMCU.ForeColor = Color.Green
                            Exit Sub
                        End If
                    End If
                End If

                ' Jika tetap gagal/tidak ada sesi hari ini
                _sessionCodeAktif = ""
                lblStatusMCU.Text = "MCU Non-Aktif / Sesi Hari Ini Tidak Ditemukan"
                lblStatusMCU.ForeColor = Color.Red
            End If

        Catch ex As Exception
            _sessionCodeAktif = ""
            lblStatusMCU.Text = "Error Load Sesi MCU"
            lblStatusMCU.ForeColor = Color.Red
        End Try
    End Sub

    Private Function FetchAndSaveMcuSessions(ByVal tglMcu As String, ByVal urlEndpoint As String) As Boolean
        Try
            Dim jsonPayload As String = "{""date"":""" & tglMcu & """}"
            Dim responseString As String = InsertDataAPIRM(jsonPayload, urlEndpoint)

            If Not String.IsNullOrEmpty(responseString) Then
                Dim jObj As JObject = JObject.Parse(responseString)

                If jObj("success") IsNot Nothing AndAlso CBool(jObj("success")) = True Then
                    Dim jData As JArray = TryCast(jObj("data"), JArray)

                    If jData IsNot Nothing AndAlso jData.Count > 0 Then
                        For Each item As JObject In jData
                            Dim sessionId As Integer = ParseJsonInt(item("session_id"))
                            Dim sessionCode As String = ParseJsonString(item("session_code"))
                            Dim sessionName As String = ParseJsonString(item("session_name"))
                            Dim tgl As String = ParseJsonString(item("tgl_mcu"))
                            Dim lokasi As String = ParseJsonString(item("lokasi"))
                            Dim kodePoli As String = ParseJsonString(item("kode_poli"))
                            Dim status As String = ParseJsonString(item("status"))
                            Dim totalPart As Integer = ParseJsonInt(item("total_participants"))
                            Dim checkedIn As Integer = ParseJsonInt(item("checked_in_count"))

                            If sessionId <= 0 Then Continue For

                            If String.IsNullOrEmpty(tgl) OrElse Not IsDate(tgl) Then
                                tgl = tglMcu
                            Else
                                tgl = Convert.ToDateTime(tgl).ToString("yyyy-MM-dd")
                            End If

                            sessionCode = sessionCode.Replace("'", "''")
                            sessionName = sessionName.Replace("'", "''")
                            lokasi = lokasi.Replace("'", "''")
                            kodePoli = kodePoli.Replace("'", "''")
                            status = status.Replace("'", "''")

                            Dim query As String = ""
                            query &= "IF EXISTS (SELECT 1 FROM mcu_sessions WHERE session_id = " & sessionId & ") "
                            query &= "BEGIN "
                            query &= "   UPDATE mcu_sessions SET "
                            query &= "   session_code = '" & sessionCode & "', "
                            query &= "   session_name = '" & sessionName & "', "
                            query &= "   tgl_mcu = '" & tgl & "', "
                            query &= "   lokasi = '" & lokasi & "', "
                            query &= "   kode_poli = '" & kodePoli & "', "
                            query &= "   status = '" & status & "', "
                            query &= "   total_participants = " & totalPart & ", "
                            query &= "   checked_in_count = " & checkedIn & ", "
                            query &= "   updated_at = GETDATE() "
                            query &= "   WHERE session_id = " & sessionId & " "
                            query &= "END "
                            query &= "ELSE "
                            query &= "BEGIN "
                            query &= "   INSERT INTO mcu_sessions (session_id, session_code, session_name, tgl_mcu, lokasi, kode_poli, status, total_participants, checked_in_count, created_at, updated_at) "
                            query &= "   VALUES (" & sessionId & ", '" & sessionCode & "', '" & sessionName & "', '" & tgl & "', '" & lokasi & "', '" & kodePoli & "', '" & status & "', " & totalPart & ", " & checkedIn & ", GETDATE(), GETDATE()) "
                            query &= "END"

                            WriteSQL(query, 4)
                        Next
                        Return True
                    End If
                End If
            End If

            Return False
        Catch ex As Exception
            MessageBox.Show("[ERROR FETCH API] " & ex.Message, "Exception Occurred", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Function ParseJsonInt(ByVal token As JToken) As Integer
        If token Is Nothing OrElse token.Type = JTokenType.Null Then Return 0
        Dim res As Integer = 0
        Integer.TryParse(token.ToString().Trim(), res)
        Return res
    End Function

    Private Function ParseJsonString(ByVal token As JToken) As String
        If token Is Nothing OrElse token.Type = JTokenType.Null Then Return ""
        Return token.ToString().Trim()
    End Function
End Class