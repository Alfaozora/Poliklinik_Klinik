Imports System.Net
Imports System.IO
Imports Newtonsoft.Json.Serialization

Public Class WhatsAppSetting
    Public Function Base64ToImage(ByVal base64String As String) As Image
        Dim imageBytes() As Byte = Convert.FromBase64String(base64String)
        Dim ms As New IO.MemoryStream(imageBytes)
        Return Image.FromStream(ms)
    End Function

    Private Sub WhatsAppSetting_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim instance As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'whatsapp_instance'")
        Dim token As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'whatsapp_token'")

        TextBoxID.Text = instance
        TextBoxToken.Text = token

        CekStatus()
        CekInfo()
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
End Class