Imports System.Data
Imports System.Windows.Forms
Imports Newtonsoft.Json.Linq
Imports System.ComponentModel
Imports System.IO
Imports System.Text

Public Class FormCheckinHYU

    Public Class CheckinInputParam
        Public NoUrut As String
        Public SessionCode As String
        Public UrlWebService As String
    End Class

    Public Class CheckinResultData
        Public IsSuccess As Boolean = False
        Public Message As String = ""
        Public SessionCode As String = ""
        Public Token As String = ""
        Public NoUrutSanitized As String = ""
        Public Nama As String = ""
        Public Nik As String = ""
        Public Nip As String = ""
        Public RawPayload As String = ""
        Public RawResponse As String = ""
        Public UrlTarget As String = ""
        Public NoUrutInput As String = ""
    End Class

    Private _sessionCodeAktif As String = ""

    Private Sub AmbilSesiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AmbilSesiToolStripMenuItem.Click
        Dim tglHariIni As String = DateTime.Today.ToString("yyyy-MM-dd")
        Dim urlWebService As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")

        If String.IsNullOrEmpty(urlWebService) Then
            MessageBox.Show("URL WebService belum dikonfigurasi di MsConfig!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim queryCekLokal As String = String.Format( _
            "SELECT session_id, session_code, session_name, lokasi, kode_poli, status " & _
            "FROM mcu_sessions " & _
            "WHERE CONVERT(VARCHAR(10), tgl_mcu, 120) = '{0}' AND status = 'active' " & _
            "ORDER BY session_id DESC", tglHariIni)

        Dim dtLokal As DataTable = ReadSQL(queryCekLokal)

        If dtLokal IsNot Nothing AndAlso dtLokal.Rows.Count > 0 Then
            Dim sessionCode As String = dtLokal.Rows(0)("session_code").ToString().Trim()
            Dim sessionName As String = dtLokal.Rows(0)("session_name").ToString().Trim()

            _sessionCodeAktif = sessionCode
            lblStatusMCU.Text = "MCU Active | Sesi: " & sessionCode & " - " & sessionName
            lblStatusMCU.ForeColor = Color.Green

            MessageBox.Show("Sesi MCU hari ini ditemukan dari Database Lokal:" & vbCrLf & _
                            "Kode Sesi: " & sessionCode & vbCrLf & _
                            "Nama Sesi: " & sessionName, "Sesi Ditemukan (Lokal)", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
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

                    MessageBox.Show("Sesi MCU berhasil ditarik dari API dan disimpan ke Lokal:" & vbCrLf & _
                                    "Kode Sesi: " & sessionCode & vbCrLf & _
                                    "Nama Sesi: " & sessionName, "Sesi Ditemukan (API)", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    _sessionCodeAktif = ""
                    lblStatusMCU.Text = "MCU Non-Aktif / Sesi Hari Ini Tidak Ada"
                    lblStatusMCU.ForeColor = Color.Red
                    MessageBox.Show("Tidak ada sesi MCU aktif untuk tanggal hari ini (" & tglHariIni & ").", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                _sessionCodeAktif = ""
                lblStatusMCU.Text = "MCU Non-Aktif / Gagal Ambil Sesi API"
                lblStatusMCU.ForeColor = Color.Red
            End If
        End If
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

    Private WithEvents bgwCheckIn As New BackgroundWorker

    Private Sub txtNoUrutInput_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtNoUrutInput.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            btnCheckIn.PerformClick()
        End If
    End Sub

    Private Sub btnCheckIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckIn.Click
        Dim noUrut As String = txtNoUrutInput.Text.Trim()

        If String.IsNullOrEmpty(_sessionCodeAktif) Then
            MessageBox.Show("Sesi MCU aktif belum dipilih!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If String.IsNullOrEmpty(noUrut) Then
            MessageBox.Show("Nomor Urut Peserta wajib diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNoUrutInput.Focus()
            Exit Sub
        End If

        If bgwCheckIn.IsBusy Then
            MessageBox.Show("Proses check-in sebelumnya masih berjalan, mohon tunggu...", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        Dim urlWebService As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
        If String.IsNullOrEmpty(urlWebService) Then
            MessageBox.Show("URL WebService (ws_RM) belum dikonfigurasi di MsConfig!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        btnCheckIn.Enabled = False
        btnCheckIn.Text = "Proses..."
        lblStatusInProgres.Text = "Sedang mengirim data ke API..."
        lblStatusInProgres.Visible = True

        Dim param As New CheckinInputParam()
        param.NoUrut = noUrut
        param.SessionCode = _sessionCodeAktif
        param.UrlWebService = urlWebService

        bgwCheckIn.RunWorkerAsync(param)
    End Sub

    Private Sub bgwCheckIn_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles bgwCheckIn.DoWork
        Dim input As CheckinInputParam = CType(e.Argument, CheckinInputParam)
        Dim result As New CheckinResultData()

        result.NoUrutInput = input.NoUrut
        result.UrlTarget = input.UrlWebService & "api/mcu/check-in/" & input.SessionCode & "/participants/status"
        result.RawPayload = "{""status"":""checked_in"",""nourut_sanitized"":""" & input.NoUrut & """}"

        Try
            Dim responseString As String = PutDataAPIRM(result.RawPayload, result.UrlTarget)
            result.RawResponse = responseString

            If Not String.IsNullOrEmpty(responseString) Then
                Dim jObj As JObject = JObject.Parse(responseString)

                If jObj("success") IsNot Nothing AndAlso CBool(jObj("success")) = True Then
                    result.IsSuccess = True
                    Dim jData As JObject = TryCast(jObj("data"), JObject)
                    If jData IsNot Nothing Then
                        result.SessionCode = ParseJsonString(jData("session_code"))
                        result.Token = ParseJsonString(jData("token"))
                        result.NoUrutSanitized = ParseJsonString(jData("nourut_sanitized"))
                        result.Nama = ParseJsonString(jData("nama"))
                        result.Nik = ParseJsonString(jData("nik"))
                        result.Nip = ParseJsonString(jData("nip"))
                    End If
                Else
                    result.IsSuccess = False
                    result.Message = If(jObj("message") IsNot Nothing, jObj("message").ToString(), "Gagal check-in.")
                End If
            End If
        Catch ex As Exception
            result.IsSuccess = False
            result.Message = ex.Message
        End Try

        e.Result = result
    End Sub

    Private Sub bgwCheckIn_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles bgwCheckIn.RunWorkerCompleted
        btnCheckIn.Enabled = True
        btnCheckIn.Text = "Check-In (Enter)"
        lblStatusInProgres.Visible = False

        If e.Error IsNot Nothing Then
            MessageBox.Show("[ERROR BGW] " & e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim res As CheckinResultData = CType(e.Result, CheckinResultData)
        Dim safePayload As String = res.RawPayload.Replace("'", "''")
        Dim safeResponse As String = res.RawResponse.Replace("'", "''")

        If res.IsSuccess Then
            lblToken.Text = res.Token
            lblNoUrut.Text = res.NoUrutSanitized
            lblNama.Text = res.Nama
            lblNik.Text = res.Nik
            lblNip.Text = res.Nip

            pnlHasilCard.BackColor = Color.FromArgb(235, 247, 238)
            pnlHasilCard.Visible = True

            Dim qLog As String = "INSERT INTO log_api_checkin (no_urut, nik, session_code, url_api, payload, response, status_log, created_date) " & _
                                 "VALUES ('" & res.NoUrutInput & "', '" & res.Nik & "', '" & _sessionCodeAktif & "', '" & res.UrlTarget & "', '" & safePayload & "', '" & safeResponse & "', 'SUCCESS', GETDATE())"
            WriteSQL(qLog, 4)

            ' --- OTOMATIS JALANKAN CETAK SETELAH CHECK-IN SUKSES ---
            ButtonCetak.PerformClick()

            txtNoUrutInput.SelectAll()
            txtNoUrutInput.Focus()
        Else
            pnlHasilCard.BackColor = Color.FromArgb(253, 237, 237)
            lblNama.Text = "CHECK-IN GAGAL"
            lblToken.Text = "-"
            lblNoUrut.Text = "-"
            lblNik.Text = "-"
            lblNip.Text = "-"
            pnlHasilCard.Visible = True

            Dim qLogFail As String = "INSERT INTO log_api_checkin (no_urut, session_code, url_api, payload, response, status_log, created_date) " & _
                                     "VALUES ('" & res.NoUrutInput & "', '" & _sessionCodeAktif & "', '" & res.UrlTarget & "', '" & safePayload & "', '" & safeResponse & "', 'FAILED', GETDATE())"
            WriteSQL(qLogFail, 4)

            MessageBox.Show("Check-In Gagal: " & res.Message, "Peringatan API", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            txtNoUrutInput.SelectAll()
            txtNoUrutInput.Focus()
        End If
    End Sub

    Private Sub ButtonCetak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCetak.Click
        Try
            Dim tokenVal As String = lblToken.Text.Trim()
            Dim namaVal As String = lblNama.Text.Trim()
            Dim noUrutVal As String = txtNoUrutInput.Text.Trim()

            If String.IsNullOrEmpty(noUrutVal) Then
                MessageBox.Show("Nomor Urut tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            If String.IsNullOrEmpty(tokenVal) OrElse tokenVal = "-" Then
                MessageBox.Show("Token peserta belum tersedia / belum berhasil check-in!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim queryPasien As String = _
                "SELECT MP.Nama, MP.TglLahir, MP.JenisKelamin " & _
                "FROM MasterPasien MP " & _
                "INNER JOIN TransaksiLab TL ON MP.NoRekamMedis = TL.IDInternet " & _
                "WHERE TL.NoUrut = '" & noUrutVal.Replace("'", "''") & "'"

            Dim dtPasien As DataTable = ReadSQL(queryPasien)
            Dim tglLahirDT As Nullable(Of DateTime) = Nothing
            Dim genderRaw As String = ""

            If dtPasien IsNot Nothing AndAlso dtPasien.Rows.Count > 0 Then
                Dim rowPasien As DataRow = dtPasien.Rows(0)
                If Not IsDBNull(rowPasien("TglLahir")) AndAlso IsDate(rowPasien("TglLahir")) Then
                    tglLahirDT = Convert.ToDateTime(rowPasien("TglLahir"))
                End If
                genderRaw = rowPasien("JenisKelamin").ToString().Trim()
                If String.IsNullOrEmpty(namaVal) Then namaVal = rowPasien("Nama").ToString().Trim()
            End If

            Dim usia As Integer = 0
            Dim tglTampilQR As String = ""
            Dim cultureInfoIndo As New System.Globalization.CultureInfo("id-ID")

            If tglLahirDT.HasValue Then
                Dim tglLahir As DateTime = tglLahirDT.Value
                usia = DateTime.Now.Year - tglLahir.Year
                If DateTime.Now < tglLahir.AddYears(usia) Then usia -= 1
                tglTampilQR = tglLahir.ToString("dd MMM yyyy", cultureInfoIndo)
            End If

            Dim gender As String = genderRaw.ToUpper()
            If gender.Contains("L") OrElse gender.Contains("PRIA") OrElse gender.Contains("MALE") Then
                gender = "L"
            Else
                gender = "P"
            End If

            Dim qrContent As String = tokenVal

            ' AMBIL PATH DARI CONFIG MSCONFIG LOKAL DB
            Dim Tpos As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='PathBarcode'")
            If String.IsNullOrEmpty(Tpos) Then Tpos = Application.StartupPath & "\"
            If Not Tpos.EndsWith("\") Then Tpos &= "\"

            Dim TtxCheckin As String = Tpos & "OutputCheckinMCU.txt"
            If System.IO.File.Exists(TtxCheckin) Then System.IO.File.Delete(TtxCheckin)

            ' GUNAKAN ASCII ENCODING DENGAN FLUSH STREAM UNTUK CETAK RAW PRINTER
            Using writerCheckin As New System.IO.StreamWriter(TtxCheckin, False, Encoding.ASCII)
                writerCheckin.WriteLine("<xpml><page quantity='0' pitch='29.3 mm'></xpml>I8,A")
                writerCheckin.WriteLine("ZN")
                writerCheckin.WriteLine("q275")
                writerCheckin.WriteLine("S3")
                writerCheckin.WriteLine("O")
                writerCheckin.WriteLine("JF")
                writerCheckin.WriteLine("D9")
                writerCheckin.WriteLine("ZT")
                writerCheckin.WriteLine("Q234,B24")
                writerCheckin.WriteLine("KI80")
                writerCheckin.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='29.3 mm'></xpml>")
                writerCheckin.WriteLine("N")

                writerCheckin.WriteLine("b80,60,Q,m2,g7,s3,""" & qrContent & """")
                writerCheckin.WriteLine("A95,217,2,3,1,1,N,""")
                writerCheckin.WriteLine("A95,30,2,3,1,1,N,""TOKEN MCU""")
                writerCheckin.WriteLine("A290,54,2,2,1,1,N,""" & namaVal & """")
                writerCheckin.WriteLine("A290,217,2,3,1,1,N,""" & noUrutVal & """")
                writerCheckin.WriteLine("P1")
                writerCheckin.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
                writerCheckin.Flush()
            End Using

            KirimKePrinter(TtxCheckin)

        Catch ex As Exception
            MessageBox.Show("[ERROR CETAK] " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TestPrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestPrintToolStripMenuItem.Click
        Try
            Dim tokenDummy As String = "TEST12345X"
            Dim namaDummy As String = "PASIEN DUMMY TEST"
            Dim noUrutDummy As String = "999"
            Dim tglLahirDummy As String = "19 Mei 1998"
            Dim genderDummy As String = "L"

            Dim Tpos As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='PathBarcode'")
            If String.IsNullOrEmpty(Tpos) Then Tpos = Application.StartupPath & "\"
            If Not Tpos.EndsWith("\") Then Tpos &= "\"

            Dim TtxTestPrint As String = Tpos & "OutputTestPrint.txt"
            If System.IO.File.Exists(TtxTestPrint) Then System.IO.File.Delete(TtxTestPrint)

            Using writerCheckin As New System.IO.StreamWriter(TtxTestPrint, False, Encoding.ASCII)
                writerCheckin.WriteLine("<xpml><page quantity='0' pitch='29.3 mm'></xpml>I8,A")
                writerCheckin.WriteLine("ZN")
                writerCheckin.WriteLine("q275")
                writerCheckin.WriteLine("S3")
                writerCheckin.WriteLine("O")
                writerCheckin.WriteLine("JF")
                writerCheckin.WriteLine("D9")
                writerCheckin.WriteLine("ZT")
                writerCheckin.WriteLine("Q234,B24")
                writerCheckin.WriteLine("KI80")
                writerCheckin.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='29.3 mm'></xpml>")
                writerCheckin.WriteLine("N")

                writerCheckin.WriteLine("b80,60,Q,m2,g7,s3,""" & tokenDummy & """")
                writerCheckin.WriteLine("A95,217,2,3,1,1,N,""")
                writerCheckin.WriteLine("A95,30,2,3,1,1,N,""TEST PRINT MCU""")
                writerCheckin.WriteLine("A290,54,2,2,1,1,N,""" & namaDummy & """")
                writerCheckin.WriteLine("A290,30,2,2,1,1,N,""" & tglLahirDummy & " / " & genderDummy & """")
                writerCheckin.WriteLine("A290,217,2,3,1,1,N,""" & noUrutDummy & """")
                writerCheckin.WriteLine("P1")
                writerCheckin.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
                writerCheckin.Flush()
            End Using

            KirimKePrinter(TtxTestPrint)

        Catch ex As Exception
            MessageBox.Show("[ERROR TEST PRINT] " & ex.Message, "Exception Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub KirimKePrinter(ByVal filePathTxt As String)
        ' BACA PATH EXE PRFILE32 DARI CONFIG MSCONFIG
        Dim Tpathprf As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='Pathprf'")
        If String.IsNullOrEmpty(Tpathprf) Then Tpathprf = Application.StartupPath & "\"
        If Not Tpathprf.EndsWith("\") Then Tpathprf &= "\"

        Dim prFileExe As String = Tpathprf & "PrFile32.exe"

        ' BERI JEDA SEDIKIT AGAR FILE STREAM TEKS DIPASTIKAN RELEASE DARI RAM
        System.Threading.Thread.Sleep(300)

        If System.IO.File.Exists(prFileExe) Then
            ' PANGGIL PROCESS.START DENGAN PEMISAH EXECUTE FILE & ARGUMENTS FILE TXT
            Process.Start(prFileExe, """" & filePathTxt & """")
        Else
            Dim namaPrinterDefault As String = "Zebra"
            Try
                Dim cmdArgs As String = String.Format("/c copy /b ""{0}"" ""\\%COMPUTERNAME%\{1}""", filePathTxt, namaPrinterDefault)
                Process.Start("cmd.exe", cmdArgs)
            Catch ex As Exception
                MessageBox.Show("File 'PrFile32.exe' tidak ditemukan di path:" & vbCrLf & Tpathprf & vbCrLf & _
                                "Detail Error: " & ex.Message, "Error Printer", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
End Class