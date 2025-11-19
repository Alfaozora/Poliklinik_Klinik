Imports System.Net
Imports System.IO
Imports Newtonsoft.Json.Serialization
Imports System.Drawing.Drawing2D

Public Class WhatsAppSetting
    Private isInitializing As Boolean = False
    Private preventEvent As Boolean = False
    Private waProcess As Process = Nothing

    Public Function Base64ToImage(ByVal base64String As String) As Image
        Dim imageBytes() As Byte = Convert.FromBase64String(base64String)
        Dim ms As New IO.MemoryStream(imageBytes)
        Return Image.FromStream(ms)
    End Function

    Private Sub TextBoxNoHp_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TextBoxNoHp.KeyPress
        ' Hanya angka dan Backspace
        If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> ControlChars.Back Then
            e.Handled = True
        End If
    End Sub

    Private Sub MakeButtonRound(ByVal btn As Button)
        Dim gp As New GraphicsPath()
        gp.AddEllipse(0, 0, btn.Width - 1, btn.Height - 1)
        btn.Region = New Region(gp)
    End Sub

    Private Sub WhatsAppSetting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        isInitializing = True

        Dim instance As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'whatsapp_instance'")
        Dim token As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'whatsapp_token'")
        Dim ipKlinik As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'whatsapp_klinik_ip'")
        Dim ipLab As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'whatsapp_laboratorium_ip'")

        TextBoxID.Text = instance
        TextBoxToken.Text = token
        TextBoxIPKlinik.Text = ipKlinik
        TextBoxIPLab.Text = ipLab

        TextBoxNoHp.MaxLength = 13

        MakeButtonRound(ButtonStart)

        CheckWaStatus()

        isInitializing = False

        CekStatus()
        CekInfo()
    End Sub

    Private Sub WhatsAppSetting_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Shown
        preventEvent = True

        Dim statusWA As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'whatsapp_klinik_status'")
        Dim statusWALab As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'whatsapp_laboratorium_status'")

        ToggleSwitchKlinik.Checked = (statusWA.Trim().ToUpper() = "YES")
        ToggleSwitchLab.Checked = (statusWALab.Trim().ToUpper() = "YES")

        preventEvent = False
    End Sub

    Private Sub LoadQRCode()
        Try
            Dim baseURL As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
            Dim apiUrl As String = baseURL & "api/get-qr-code"

            Dim req As Net.HttpWebRequest = Net.WebRequest.Create(apiUrl)
            req.Method = "GET"

            Dim resp As Net.HttpWebResponse = req.GetResponse()
            Dim reader As New IO.StreamReader(resp.GetResponseStream())
            Dim json As String = reader.ReadToEnd()

            ' Parse JSON
            Dim obj = Newtonsoft.Json.Linq.JObject.Parse(json)

            Dim base64 As String = obj("raw_base64").ToString()

            ' Convert ke gambar
            PictureBox1.Image = Base64ToImage(base64)

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub CekStatus()
        Try
            Dim baseURL As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
            Dim apiUrl As String = baseURL & "api/get-status"

            Dim req As Net.HttpWebRequest = Net.WebRequest.Create(apiUrl)
            req.Method = "GET"

            Dim resp As Net.HttpWebResponse = req.GetResponse()
            Dim reader As New IO.StreamReader(resp.GetResponseStream())
            Dim json As String = reader.ReadToEnd()

            ' Parse JSON
            Dim obj = Newtonsoft.Json.Linq.JObject.Parse(json)

            Dim statusVal As String = ""
            Dim substatusVal As String = ""

            Try
                statusVal = obj("decoded_json")("status")("accountStatus")("status").ToString()
                substatusVal = obj("decoded_json")("status")("accountStatus")("substatus").ToString()
            Catch ex As Exception
                statusVal = ""
                substatusVal = ""
            End Try

            ' ============================
            '     LOGIKA STATUS
            ' ============================
            If substatusVal.ToLower() = "normal" Then
                LabelStatus.Text = "Tidak Terkoneksi"
                LabelStatus.ForeColor = Color.Red
                ButtonGetQR.Enabled = True
                ButtonLogout.Enabled = False
                ButtonRestart.Enabled = False
            Else
                LabelStatus.Text = "Terkoneksi"
                LabelStatus.ForeColor = Color.Green
                ButtonGetQR.Enabled = False
                ButtonLogout.Enabled = True
                ButtonRestart.Enabled = True
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub CekInfo()
        Try
            Dim baseURL As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
            Dim apiUrl As String = baseURL & "api/get-info"

            Dim req As Net.HttpWebRequest = Net.WebRequest.Create(apiUrl)
            req.Method = "GET"

            Dim resp As Net.HttpWebResponse = req.GetResponse()
            Dim reader As New IO.StreamReader(resp.GetResponseStream())
            Dim json As String = reader.ReadToEnd()

            ' Parse JSON
            Dim obj = Newtonsoft.Json.Linq.JObject.Parse(json)

            Dim id As String = ""
            Dim nama As String = ""
            Dim platform As String = ""

            Try
                id = obj("decoded_json")("id").ToString()
                nama = obj("decoded_json")("name").ToString()
                platform = obj("decoded_json")("device")("platform").ToString()
            Catch ex As Exception
                id = ""
                nama = ""
                platform = ""
            End Try

            ' ============================
            '   LOGIKA STATUS HANDPHONE
            ' ============================
            If String.IsNullOrEmpty(id) Then
                ' Tidak terhubung
                LabelNoHp.Text = "-"
                LabelNama.Text = "-"
                LabelPlatform.Text = "-"
            Else
                ' Terhubung
                LabelNoHp.Text = id
                LabelNama.Text = nama
                LabelPlatform.Text = platform
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub LogoutWhatsapp()
        Try
            ' Ambil URL API dari database
            Dim baseURL As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
            Dim apiUrl As String = baseURL & "api/logout"

            ' Buat request POST
            Dim req As Net.HttpWebRequest = CType(Net.WebRequest.Create(apiUrl), Net.HttpWebRequest)
            req.Method = "POST"
            req.ContentType = "application/x-www-form-urlencoded"

            ' Tidak ada data POST
            Dim data As Byte() = System.Text.Encoding.UTF8.GetBytes("")
            req.ContentLength = data.Length

            Dim stream = req.GetRequestStream()
            stream.Write(data, 0, data.Length)
            stream.Close()

            ' Baca respon
            Dim resp As Net.HttpWebResponse = CType(req.GetResponse(), Net.HttpWebResponse)
            Dim reader As New IO.StreamReader(resp.GetResponseStream())
            Dim json As String = reader.ReadToEnd()

            ' Parse JSON
            Dim obj As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(json)

            Dim pesan As String = ""

            ' ===========================
            '   CEK APAKAH ADA FIELD "response" → "message"
            ' ===========================
            If obj("response") IsNot Nothing Then
                If obj("response")("success") IsNot Nothing Then
                    pesan = obj("response")("success").ToString()
                Else
                    pesan = json   ' fallback
                End If
            Else
                pesan = json   ' fallback
            End If

            ' ===========================
            '  TAMPILKAN PESAN KE USER
            ' ===========================
            MessageBox.Show("Logout: " & pesan, "Informasi", _
                            MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", _
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub RestartWhatsapp()
        Try
            ' Ambil URL API dari database
            Dim baseURL As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
            Dim apiUrl As String = baseURL & "api/restart"

            ' Buat request POST
            Dim req As Net.HttpWebRequest = CType(Net.WebRequest.Create(apiUrl), Net.HttpWebRequest)
            req.Method = "POST"
            req.ContentType = "application/x-www-form-urlencoded"

            ' Tidak ada data POST
            Dim data As Byte() = System.Text.Encoding.UTF8.GetBytes("")
            req.ContentLength = data.Length

            Dim stream = req.GetRequestStream()
            stream.Write(data, 0, data.Length)
            stream.Close()

            ' Baca respon
            Dim resp As Net.HttpWebResponse = CType(req.GetResponse(), Net.HttpWebResponse)
            Dim reader As New IO.StreamReader(resp.GetResponseStream())
            Dim json As String = reader.ReadToEnd()

            ' Parse JSON
            Dim obj As Newtonsoft.Json.Linq.JObject = Newtonsoft.Json.Linq.JObject.Parse(json)

            Dim pesan As String = ""

            ' ===========================
            '   CEK APAKAH ADA FIELD "response" → "message"
            ' ===========================
            If obj("response") IsNot Nothing Then
                If obj("response")("success") IsNot Nothing Then
                    pesan = obj("response")("success").ToString()
                Else
                    pesan = json   ' fallback
                End If
            Else
                pesan = json   ' fallback
            End If

            ' ===========================
            '  TAMPILKAN PESAN KE USER
            ' ===========================
            MessageBox.Show("Restart: " & pesan, "Informasi", _
                            MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", _
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonGetQR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGetQR.Click
        Me.Cursor = Cursors.WaitCursor
        ButtonGetQR.Enabled = False

        Try
            LoadQRCode()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            Me.Cursor = Cursors.Hand
            ButtonGetQR.Enabled = True
        End Try
    End Sub

    Private Sub ButtonCekKoneksi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCekKoneksi.Click
        Me.Cursor = Cursors.WaitCursor
        ButtonCekKoneksi.Enabled = False

        Try
            CekStatus()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            Me.Cursor = Cursors.Hand
            ButtonCekKoneksi.Enabled = True
            CekInfo()
        End Try
    End Sub

    Private Sub ButtonLogout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLogout.Click
        Me.Cursor = Cursors.WaitCursor
        ButtonLogout.Enabled = False

        Try
            LogoutWhatsapp()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            Me.Cursor = Cursors.Hand
            ButtonLogout.Enabled = True
            CekStatus()
            CekInfo()
        End Try
    End Sub

    Private Sub ButtonRestart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRestart.Click
        Me.Cursor = Cursors.WaitCursor
        ButtonRestart.Enabled = False

        Try
            RestartWhatsapp()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            Me.Cursor = Cursors.Hand
            ButtonRestart.Enabled = True
            CekStatus()
            CekInfo()
        End Try
    End Sub

    Private Sub ButtonUpdateIP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonUpdateIP.Click
        Try
            WriteSQL("UPDATE MsConfig set StrValue = '" & TextBoxIPKlinik.Text & "' where ConfigName = 'whatsapp_klinik_ip'", 4)
            WriteSQL("UPDATE MsConfig set StrValue = '" & TextBoxIPLab.Text & "' where ConfigName = 'whatsapp_laboratorium_ip'", 4)

            MsgBox("IP WhatsApp berhasil diperbarui.", MsgBoxStyle.Information, "Success")
        Catch ex As Exception
            MsgBox("Gagal memperbarui IP WhatsApp:" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Error!")
        End Try
    End Sub

    Private Sub ToggleSwitchKlinik_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToggleSwitchKlinik.CheckedChanged
        If isInitializing Or preventEvent Then Exit Sub

        Try
            Dim statusWa As String = If(ToggleSwitchKlinik.Checked, "Yes", "No")
            WriteSQL("UPDATE MsConfig SET StrValue = '" & statusWa & "' WHERE ConfigName = 'whatsapp_klinik_status'", 4)

            MsgBox("Status WhatsApp Klinik berhasil diperbarui.", MsgBoxStyle.Information, "Success")
        Catch ex As Exception
            MsgBox("Gagal memperbarui Status WhatsApp Klinik:" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Error!")
        End Try
    End Sub

    Private Sub ToggleSwitchLab_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToggleSwitchLab.CheckedChanged
        If isInitializing Or preventEvent Then Exit Sub

        Try
            Dim statusWa As String = If(ToggleSwitchLab.Checked, "Yes", "No")
            WriteSQL("UPDATE MsConfig SET StrValue = '" & statusWa & "' WHERE ConfigName = 'whatsapp_laboratorium_status'", 4)

            MsgBox("Status WhatsApp Laboratorium berhasil diperbarui.", MsgBoxStyle.Information, "Success")
        Catch ex As Exception
            MsgBox("Gagal memperbarui Status WhatsApp Laboratorium:" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Error!")
        End Try
    End Sub

    Private Sub ButtonKirim_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonKirim.Click
        Try
            Dim nohp As String = TextBoxNoHp.Text.Trim()

            If nohp = "" Then
                MsgBox("Nomor HP tidak boleh kosong.", MsgBoxStyle.Exclamation, "Warning")
                Exit Sub
            End If

            ' Normalisasi nomor HP ke format internasional WhatsApp
            If nohp.StartsWith("0") Then
                nohp = "62" & nohp.Substring(1)
            End If

            If TextBoxNoHp.TextLength < 10 Then
                MsgBox("Nomor HP terlalu pendek.", MsgBoxStyle.Exclamation, "Warning")
                Exit Sub
            End If

            If TextBoxNoHp.TextLength > 13 Then
                MsgBox("Nomor HP terlalu panjang.", MsgBoxStyle.Exclamation, "Warning")
                Exit Sub
            End If

            ' Ambil IP server WhatsApp yang dipakai klinik
            Dim baseIP As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'whatsapp_klinik_ip'")
            Dim baseURL As String = "http://" & baseIP & ":4444/"

            Dim apiUrl As String = ""

            ' =============================
            '   KIRIM DOKUMEN
            ' =============================
            If RadioButtonIya.Checked Then

                Dim filePath As String = Application.StartupPath & "\Uploads\Test_PDF.pdf"

                If Not IO.File.Exists(filePath) Then
                    MsgBox("File dokumen tidak ditemukan: " & filePath, MsgBoxStyle.Critical, "Error")
                    Exit Sub
                End If

                ' Baca file PDF → Base64
                Dim pdfBytes As Byte() = IO.File.ReadAllBytes(filePath)
                Dim base64Pdf As String = Convert.ToBase64String(pdfBytes)

                ' Endpoint yang benar
                apiUrl = baseURL & "send-pdf"

                ' JSON body
                Dim json As String = _
                    "{""number"":""" & nohp & """," & _
                    """caption"":""Tes kirim PDF dari VB.NET""," & _
                    """filename"":""Test_PDF.pdf""," & _
                    """src"":""" & base64Pdf & """}"

                Dim client As New Net.WebClient()
                client.Headers(HttpRequestHeader.ContentType) = "application/json"

                Dim responseJson As String = client.UploadString(apiUrl, "POST", json)

                MsgBox("Dokumen berhasil dikirim." & vbCrLf & responseJson, MsgBoxStyle.Information, "Success")

            Else
                ' =============================
                '   KIRIM TEKS SAJA
                ' =============================

                Dim pesan As String = "Ini adalah pesan tes WhatsApp dari sistem."

                apiUrl = baseURL & "send-msg/" & nohp & "/" & Uri.EscapeDataString(pesan)

                Dim client As New Net.WebClient()
                Dim result As String = client.DownloadString(apiUrl)

                MsgBox("Pesan berhasil dikirim." & vbCrLf, MsgBoxStyle.Information, "Success")
            End If

        Catch ex As Exception
            MsgBox("Gagal mengirim pesan:" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Function CheckWaStatus() As Newtonsoft.Json.Linq.JObject
        Try
            Dim baseIP As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'whatsapp_klinik_ip'")
            Dim url As String = "http://" & baseIP & ":4444/status"

            Dim client As New Net.WebClient()
            Dim result As String = client.DownloadString(url)

            Dim json = Newtonsoft.Json.Linq.JObject.Parse(result)

            If json("connected").ToString() = "True" Then
                UpdateButtonState(True)
            Else
                UpdateButtonState(False)
            End If

            Return json

        Catch ex As Exception
            LabelStatusWA.Text = "Server Off"
            LabelStatusWA.ForeColor = Color.OrangeRed
            LabelStatusWA.TextAlign = ContentAlignment.MiddleCenter
            ButtonStart.BackColor = Color.Red

            Return Nothing
        End Try
    End Function

    Private Function GetWaStatus() As Boolean
        Try
            Dim json = CheckWaStatus()
            If json Is Nothing Then
                UpdateButtonState(False)
                Exit Function
            End If
            Return json("connected").ToString() = "True"
        Catch
            Return False
        End Try
    End Function

    Private Sub UpdateButtonState(ByVal isConnected As Boolean)
        If isConnected Then
            LabelStatusWA.Text = "Terhubung"
            LabelStatusWA.ForeColor = Color.Green
            ButtonStart.BackColor = Color.MediumSeaGreen
        Else
            LabelStatusWA.Text = "Terputus"
            LabelStatusWA.ForeColor = Color.Red
            ButtonStart.BackColor = Color.Red
        End If
    End Sub



    Private Sub ButtonCekKoneksiWA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCekKoneksiWA.Click
        Me.Cursor = Cursors.WaitCursor
        ButtonCekKoneksiWA.Enabled = False

        Try
            CheckWaStatus()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            ButtonCekKoneksiWA.Enabled = True
        End Try
    End Sub

    Private Sub StartWaServer()
        Try
            If waProcess Is Nothing OrElse waProcess.HasExited Then
                Dim psi As New ProcessStartInfo()
                Dim pathServer As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'whatsapp_server_path'")
                Dim pathBash As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'whatsapp_bash_path'")

                psi.FileName = pathBash   ' === PATH GIT BASH ===
                psi.WorkingDirectory = pathServer          ' === Sesuaikan folder ===
                psi.Arguments = "-c ""node index.js"""
                psi.UseShellExecute = False
                'psi.CreateNoWindow = False

                waProcess = Process.Start(psi)
                MsgBox("Server WA berjalan.", MsgBoxStyle.Information)
            Else
                MsgBox("Server sudah berjalan!", MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            MsgBox("Gagal Start: " & ex.Message)
        End Try
    End Sub

    Private Sub StopWaServer()
        Try
            Dim killed As Boolean = False

            ' === 1. Kill proses node ===
            For Each p As Process In Process.GetProcessesByName("node")
                Try
                    p.Kill()
                    killed = True
                Catch
                End Try
            Next

            ' === 2. Kill bash.exe yang kita simpan di waProcess ===
            If waProcess IsNot Nothing AndAlso Not waProcess.HasExited Then
                waProcess.Kill()
                killed = True
                waProcess = Nothing
            End If

            ' === 3. Cek jika masih ada bash sisa tanpa handle ===
            For Each p As Process In Process.GetProcessesByName("bash")
                Try
                    p.Kill()
                Catch
                End Try
            Next

            If killed Then
                MsgBox("Server WA berhasil dihentikan.", MsgBoxStyle.Information)
            Else
                MsgBox("Server tidak sedang berjalan.", MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            MsgBox("Gagal Stop: " & ex.Message)
        End Try
    End Sub

    Private Sub ButtonStart_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles ButtonStart.Paint
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
    End Sub

    Private Sub ButtonStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonStart.Click
        Me.Cursor = Cursors.WaitCursor
        ButtonStart.Enabled = False

        Try
            Dim status As Boolean = GetWaStatus()

            If status = False Then
                StartWaServer()
            Else
                StopWaServer()
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            ButtonStart.Enabled = True
            CheckWaStatus()
        End Try
    End Sub

    Private Sub ButtonQR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonQR.Click
        Try
            Dim baseIP As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'whatsapp_klinik_ip'")
            Dim url As String = "http://" & baseIP & ":4444/qr"

            Dim wc As New Net.WebClient()
            Dim html As String = wc.DownloadString(url)

            ' Jika server belum siap
            If html.Contains("not ready yet") Then
                MsgBox("QR belum siap, tunggu sebentar...", MsgBoxStyle.Information)
                Exit Sub
            End If

            ' Cari URL QR di dalam tag <a href="URL">
            Dim qrUrl As String = ""
            Dim startTag As String = "href="""
            Dim startPos As Integer = html.IndexOf(startTag)

            If startPos > -1 Then
                startPos += startTag.Length
                Dim endPos As Integer = html.IndexOf("""", startPos)
                qrUrl = html.Substring(startPos, endPos - startPos)
            End If

            If qrUrl = "" Then
                MsgBox("Tidak dapat menemukan URL QR dari server.", MsgBoxStyle.Critical)
                Exit Sub
            End If

            ' Tampilkan QR ke PictureBox
            PictureBox1.ImageLocation = qrUrl
            'PictureBox1.SizeMode = PictureBoxSizeMode.Zoom

        Catch ex As Exception
            MsgBox("Gagal memuat QR: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class