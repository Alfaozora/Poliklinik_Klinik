Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Object
Imports Newtonsoft.Json
Imports Newtonsoft
Imports System.Security.Cryptography
Imports System.Collections.Generic
Imports Newtonsoft.Json.Linq
Imports System.Drawing

Public Class FormSettingBPJS
    Private formName As String = "PENGATURAN P-Care"
    Private userInput As String = PoliKlinik.Lbluser.Text

    Private Class varJson
        Public metaData As v4_BPJS_Antrol
        Public response() As v4_BPJS_Antrol.ResponseGetAntrean
    End Class

    Private Class JsonGetPesertaAntrol
        Public metaData As v4_BPJS_Antrol
        Public response As v4_BPJS_Antrol
    End Class

    Private Sub PanelTop_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelTop.Paint
        Try
            e.Graphics.DrawString(formName, New Font("Arial", 12, FontStyle.Bold), Brushes.White, New Point(10, 10))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FormSettingBPJS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        Me.MdiParent = PoliKlinik
        Me.Dock = DockStyle.Fill

        LoadData()
    End Sub

    Private Sub LoadData()
        ' Get Data FKTP
        TextBoxKodePPK.Text = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'KodePPK'")
        TextBoxNamaPPK.Text = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NamaPPK'")

        ' Get Data Bridging
        Dim tblConfig As DataTable = ReadSQL("SELECT ConfigName, StrValue FROM MsConfig WHERE ConfigGroup = 'Bridging P-Care'")
        For Each rowConfig As DataRow In tblConfig.Rows
            If rowConfig("ConfigName") = "pcare_status_bridging" Then
                If rowConfig("StrValue") = "Yes" Then
                    CheckBoxStatusPcare.Checked = True
                Else
                    CheckBoxStatusPcare.Checked = False
                End If
            ElseIf rowConfig("ConfigName") = "pcare_environment" Then
                If rowConfig("StrValue") = "production" Then
                    RadioButtonEnvironmentProduction.Checked = True
                ElseIf rowConfig("StrValue") = "development" Then
                    RadioButtonEnvironmentDevelopment.Checked = True
                End If
            ElseIf rowConfig("ConfigName") = "pcare_username" Then
                TextBoxUsername.Text = rowConfig("StrValue")
            ElseIf rowConfig("ConfigName") = "pcare_password" Then
                TextBoxPassword.Text = rowConfig("StrValue")
            ElseIf rowConfig("ConfigName") = "pcare_consid" Then
                TextBoxConsumerID.Text = rowConfig("StrValue")
            ElseIf rowConfig("ConfigName") = "pcare_secret_key" Then
                TextBoxSecretKey.Text = rowConfig("StrValue")
            ElseIf rowConfig("ConfigName") = "pcare_user_key" Then
                TextBoxUserKey.Text = rowConfig("StrValue")
            ElseIf rowConfig("ConfigName") = "pcare_base_url" Then
                TextBoxBaseURL.Text = rowConfig("StrValue")
            End If
        Next
    End Sub

    Private Sub SaveSetting()
        Try
            ' If TextBoxKodePPK Is Nothing OrElse _
            'TextBoxUsername Is Nothing OrElse _
            'TextBoxPassword Is Nothing OrElse _
            'TextBoxConsumerID Is Nothing OrElse _
            'TextBoxSecretKey Is Nothing OrElse _
            'TextBoxUserKey Is Nothing OrElse _
            'TextBoxBaseURL Is Nothing OrElse _
            'CheckBoxStatusPcare Is Nothing OrElse _
            'RadioButtonEnvironmentProduction Is Nothing OrElse _
            'RadioButtonEnvironmentDevelopment Is Nothing Then

            '     MsgBox("Salah satu kontrol tidak ditemukan atau belum diinisialisasi.", MsgBoxStyle.Critical, "ERROR")
            '     Exit Sub
            ' End If

            ' Update Status Bridging
            If CheckBoxStatusPcare.Checked = True Then
                WriteSQL("UPDATE MsConfig set StrValue = 'Yes' where ConfigName = 'pcare_status_bridging'", 4)
            ElseIf CheckBoxStatusPcare.Checked = False Then
                WriteSQL("UPDATE MsConfig set StrValue = 'No' where ConfigName = 'pcare_status_bridging'", 4)
            End If

            ' Update Status Environment
            If RadioButtonEnvironmentProduction.Checked = True Then
                WriteSQL("UPDATE MsConfig set StrValue = 'production' where ConfigName = 'pcare_environment'", 4)
            ElseIf RadioButtonEnvironmentDevelopment.Checked = True Then
                WriteSQL("UPDATE MsConfig set StrValue = 'development' where ConfigName = 'pcare_environment'", 4)
            End If

            ' Update Profil FKTP
            WriteSQL("UPDATE MsConfig set StrValue = '" & TextBoxKodePPK.Text & "' where ConfigName = 'KodePPK'", 4)
            WriteSQL("UPDATE MsConfig set StrValue = '" & TextBoxKodePPK.Text & "' where ConfigName = 'NamaPPK'", 4)

            ' Update Credentials Bridging BPJS
            WriteSQL("UPDATE MsConfig set StrValue = '" & TextBoxUsername.Text & "' where ConfigName = 'pcare_username'", 4)
            WriteSQL("UPDATE MsConfig set StrValue = '" & TextBoxPassword.Text & "' where ConfigName = 'pcare_password'", 4)
            WriteSQL("UPDATE MsConfig set StrValue = '" & TextBoxConsumerID.Text & "' where ConfigName = 'pcare_consid'", 4)
            WriteSQL("UPDATE MsConfig set StrValue = '" & TextBoxSecretKey.Text & "' where ConfigName = 'pcare_secret_key'", 4)
            WriteSQL("UPDATE MsConfig set StrValue = '" & TextBoxUserKey.Text & "' where ConfigName = 'pcare_user_key'", 4)
            WriteSQL("UPDATE MsConfig set StrValue = '" & TextBoxBaseURL.Text & "' where ConfigName = 'pcare_base_url'", 4)

            If CheckConnectPcare() = True Then
                UpdateCredentialsAntrol()

                MsgBox("Berhasil connect ke BPJS.", MsgBoxStyle.Information, "Success")
            Else
                MsgBox("Gagal tersambung, cek data kembali.", MsgBoxStyle.Exclamation, "Failed")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Function GetNamaKlinik() As String
        Try
            Dim lokasiPoli As String = "SELECT StrValue FROM MsConfig WHERE ConfigName = 'NoPoli'"
            Dim lokasi As DataTable = ReadSQL(lokasiPoli)

            If lokasi IsNot Nothing AndAlso lokasi.Rows.Count > 0 Then
                Dim row As DataRow = lokasi.Rows(0)
                Dim strValue As String = row("StrValue").ToString()

                Select Case strValue
                    Case "W001" : Return "SUCI"
                    Case "W002" : Return "MANYAR"
                    Case "W003" : Return "DRIYOREJO"
                    Case "L001" : Return "DHARMAHUSADA"
                    Case "L002" : Return "CDC DIPENOGORO"
                    Case "L003" : Return "Lumiera Luzella"
                    Case "L005" : Return "Inhouse Wings Surya"
                    Case "A001" : Return "PAKEM"
                    Case "A002" : Return "JATIUWUH"
                    Case "AD01" : Return "BOYOLALI"
                    Case "D002" : Return "RANCAEKEK"
                    Case "T001" : Return "KARAWANG"
                End Select
            End If

        Catch ex As Exception
            ' Optional: log error atau berikan default
            Return "Klinik Mitra Medicare"
        End Try

        Return "Klinik Mitra Medicare"
    End Function

    'NEW
    Private Sub UpdateCredentialsAntrol()
        Try
            '# Variabel SINA
            Dim _loc As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NoPoli'")
            Dim _usernamePcare As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'pcare_username'")
            Dim _passwordPcare As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'pcare_password'")
            Dim _jenisBridging As String = "" ' DEV / PROD
            Dim baseUrlRM As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
            Dim apiKey As String = TextBoxAPIKeyAntrian.Text
            Dim url As String = baseUrlRM & "api/klinik/store"

            Dim parameterKlinik As String = "{" & _
              """kode_klinik"" : """ & _loc & """," & _
              """nama_klinik"" : """ & GetNamaKlinik() & """," & _
              """api_key"": """ & apiKey & """" & _
             "}"

            Dim response As String = InsertDataAPIRM(parameterKlinik, url)

            MsgBox(response)

            If RadioButtonEnvironmentProduction.Checked = True Then
                _jenisBridging = "PROD"
            ElseIf RadioButtonEnvironmentDevelopment.Checked = True Then
                _jenisBridging = "DEV"
            End If

            ' Set parameter JSON
            Dim parameterPendaftaran As String = "{" & _
                """location"" : """ & _loc & """," & _
                """pcare_username"" : """ & _usernamePcare & """," & _
                """pcare_password"" : """ & _passwordPcare & """," & _
                """account_type"": """ & _jenisBridging & """" & _
            "}"

            Dim wsCadangan As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_cadangan'")

            Dim baseUrl As String = ""

            If wsCadangan IsNot Nothing AndAlso wsCadangan.ToUpper() = "YES" Then
                baseUrl = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'web_service_cadangan'")
            Else
                baseUrl = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'web_service_klinik'")
            End If
            Dim webServiceUrl As String = baseUrl & "api/bridge/update-credentials"
            Dim jsonString As String = InsertDataAPI(parameterPendaftaran, webServiceUrl)

            ' Parsing respon
            'If Not String.IsNullOrEmpty(jsonString) Then
            '    Dim jArray As JArray = JArray.Parse(jsonString)

            '    If jArray.Count > 0 Then
            '        Dim firstItem As JObject = jArray(0)

            '        Dim status As String = firstItem("status").ToString()
            '        Dim message As String = firstItem("message").ToString()

            '        MessageBox.Show("Status Kirim: " & status & vbCrLf & "Pesan: " & message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Else
            '        MessageBox.Show("Respon kosong dari server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    End If
            'Else
            '    MessageBox.Show("Tidak ada respon dari server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'End If

            ' Parsing respon
            If Not String.IsNullOrEmpty(jsonString) Then
                Try
                    ' Coba sebagai array dulu
                    Dim jArray As JArray = Nothing

                    Dim isArray As Boolean = False

                    Try
                        jArray = jArray.Parse(jsonString)
                        isArray = True
                    Catch
                        isArray = False
                    End Try

                    If isArray Then
                        ' RESPONS NORMAL (ARRAY)
                        If jArray.Count > 0 Then
                            Dim firstItem As JObject = jArray(0)

                            Dim status As String = firstItem("status").ToString()
                            Dim message As String = firstItem("message").ToString()

                            MessageBox.Show("Status Kirim: " & status & vbCrLf & _
                                            "Pesan: " & message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Else
                            MessageBox.Show("Respon kosong dari server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If

                    Else
                        ' RESPONS ERROR (OBJECT)
                        Dim jobj As JObject = JObject.Parse(jsonString)

                        Dim status As String = If(jobj("status") Is Nothing, "error", jobj("status").ToString())
                        Dim message As String = If(jobj("message") Is Nothing, "Format data tidak dikenali.", jobj("message").ToString())

                        MessageBox.Show("Server mengembalikan error:" & vbCrLf & _
                                        "Status: " & status & vbCrLf & _
                                        "Pesan : " & message & vbCrLf & _
                                        vbCrLf & "Kemungkinan server bridging DOWN atau koneksi internet bermasalah.", "Bridging Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

                    End If

                Catch ex As Exception
                    MessageBox.Show("Gagal parsing respon: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

            Else
                MessageBox.Show("Tidak ada respon dari server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show("Gagal parsing respon: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'OLD
    'Private Sub UpdateCredentialsAntrol()
    '    '# Variabel SINA
    '    Dim uriUpdate As String = "https://sina.mitramedicare.com/v3/controller/update_pcare_credentials.php"
    '    Dim _loc As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NoPoli'")
    '    Dim _usernamePcare As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'pcare_username'")
    '    Dim _passwordPcare As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'pcare_password'")
    '    Dim _jenisBridging As String = "" ' DEV / PROD

    '    If RadioButtonEnvironmentProduction.Checked = True Then
    '        _jenisBridging = "PROD"
    '    ElseIf RadioButtonEnvironmentDevelopment.Checked = True Then
    '        _jenisBridging = "DEV"
    '    End If

    '    ' Set parameter
    '    Dim parameterPendaftaran As String = "{" & _
    '           """location"" : """ & _loc & """," & _
    '           """pcare_username"" : """ & _usernamePcare & """," & _
    '           """pcare_password"" : """ & _passwordPcare & """," & _
    '           """account_type"": """ & _jenisBridging & """" & _
    '          "}"
    '    'MsgBox(parameterPendaftaran)

    '    ' Post Data
    '    Dim jsonString As String = InsertDataAPI(parameterPendaftaran, uriUpdate)
    '    'MsgBox(jsonString)

    '    ' Parsing respon dan tampilkan status
    '    Try
    '        If Not String.IsNullOrEmpty(jsonString) Then
    '            Dim jArray As JArray = jArray.Parse(jsonString)

    '            If jArray.Count > 0 Then
    '                Dim firstItem As JObject = jArray(0)

    '                Dim status As String = firstItem("status").ToString()
    '                Dim message As String = firstItem("message").ToString()

    '                MessageBox.Show("Status Kirim: " & status & vbCrLf & "Pesan: " & message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '            Else
    '                MessageBox.Show("Respon kosong dari server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            End If
    '        Else
    '            MessageBox.Show("Tidak ada respon dari server.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show("Gagal parsing respon: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    End Try
    'End Sub

    Private Sub butGetData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butGetData.Click
        Dim parameter As String = "{" & _
                              """nilaiResponse"" : """ & TextBoxResponse.Text & """," & _
                              """nilaiKeywords"" : """ & TextBoxResponseURL.Text & """" & _
                             "}"

        Dim result_post = generateLZString(parameter, "application/json", "POST")
        MsgBox(result_post)
    End Sub

    Private Sub ButtonSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSimpan.Click
        SaveSetting()
    End Sub

    Private Sub ButtonGetResponse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGetResponse.Click
        Dim getResponse As String = ""
        Dim urlPcare As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_base_url'")
        Dim uri As String = urlPcare & TextBoxResponseURL.Text

        Dim totalKunjungan As Integer = 0

        'getResponse = PostDataFromPcare(uri)
        getResponse = getDataFromPcare(uri)

        TextBoxResponse.Text = getResponse
    End Sub

    Private Sub ButtonGenerateHeader_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGenerateHeader.Click
        Try
            Dim consID As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_consid'")
            Dim secretKey = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_secret_key'")
            Dim pcareUname = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_username'")
            Dim pcarePWD = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_password'")
            Dim kdAplikasi = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_kode_aplikasi'")
            Dim userKey = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_user_key'")

            Dim tgl As Integer = ((DateTime.UtcNow - Convert.ToDateTime("1970-01-01 00:00:00")).TotalSeconds())
            Dim stamp As String = tgl.ToString()

            Dim data As String = consID + "&" + stamp
            Dim data2 As String = pcareUname + ":" + pcarePWD + ":" + kdAplikasi
            Dim encodedSignature As String = HashString(data, secretKey)

            'Authorization
            Dim Authorization = System.Text.Encoding.UTF8.GetBytes(data2)
            Dim encodedAuthorization = Convert.ToBase64String(Authorization)

            TextBoxGenerateConsID.Text = consID
            TextBoxGenerateTimestamp.Text = stamp
            TextBoxGenerateSignature.Text = encodedSignature
            TextBoxGenerateAuthorization.Text = "Basic " + encodedAuthorization
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub ButtonPostResponse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPostResponse.Click
        'Try
        '    'Dim parameter As String = TextBoxResponseBody.Text

        '    'Dim uri As String = TextBoxResponseURL.Text
        '    ' Set parameter untuk POST data ke pcare BPJS
        '    Dim parameter As String = "{" & _
        '           """kdProviderPeserta"" : ""0217B098""," & _
        '           """tglDaftar"" : ""30-08-2023""," & _
        '           """noKartu"" : ""0003050082112""," & _
        '           """kdPoli"" : ""001""," & _
        '           """keluhan"": ""tes""," & _
        '           """kunjSakit"": true," & _
        '           """sistole"": 0," & _
        '           """diastole"": 0," & _
        '           """beratBadan"": 0," & _
        '           """tinggiBadan"": 0," & _
        '           """respRate"": 0," & _
        '           """lingkarPerut"": 0," & _
        '           """heartRate"": 0," & _
        '           """rujukBalik"": 0," & _
        '           """kdTkp"": ""10""" & _
        '          "}"

        '    'Dim parameter As String = "{""kdProviderPeserta"": ""0217B098"",""tglDaftar"": ""30-08-2023"",""noKartu"": ""0003050082112"",""kdPoli"": ""001"",""keluhan"": ""tes"",""kunjSakit"": true,""sistole"": 0,""diastole"": 0,""beratBadan"": 0,""tinggiBadan"": 0,""respRate"": 0,""lingkarPerut"": 0,""heartRate"": 0,""rujukBalik"": 0,""kdTkp"": ""10""}"
        '    Dim uri As String = "https://apijkn.bpjs-kesehatan.go.id/pcare-rest/pendaftaran"

        '    Dim bytearr() As Byte = Encoding.UTF8.GetBytes(parameter)

        '    Dim consID As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_consid'")
        '    Dim secretKey = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_secret_key'")
        '    Dim pcareUname = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_username'")
        '    Dim pcarePWD = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_password'")
        '    Dim kdAplikasi = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_kode_aplikasi'")
        '    Dim userKey = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_user_key'")

        '    Dim keyword = ""

        '    Dim tgl As Integer = ((DateTime.UtcNow - Convert.ToDateTime("1970-01-01 00:00:00")).TotalSeconds())
        '    Dim stamp As String = tgl.ToString()

        '    Dim data As String = consID + "&" + stamp
        '    Dim data2 As String = pcareUname + ":" + pcarePWD + ":" + kdAplikasi
        '    Dim encodedSignature As String = HashString(data, secretKey)

        '    'Authorization
        '    Dim Authorization = System.Text.Encoding.UTF8.GetBytes(data2)
        '    Dim encodedAuthorization = Convert.ToBase64String(Authorization)

        '    Dim str As String = ""

        '    'REQUEST GET METHOD
        '    Dim webreq As HttpWebRequest = WebRequest.Create(uri)

        '    webreq.Accept = "application/json"
        '    webreq.Headers("X-cons-id") = consID
        '    webreq.Headers("X-timestamp") = stamp
        '    webreq.Headers("X-signature") = encodedSignature
        '    webreq.Headers("X-authorization") = "Basic " + encodedAuthorization
        '    webreq.Headers("user_key") = userKey

        '    webreq.Method = "POST"
        '    webreq.ContentType = "text/plain"
        '    webreq.ContentLength = bytearr.Length

        '    Dim dataStream As Stream = webreq.GetRequestStream()
        '    dataStream.Write(bytearr, 0, bytearr.Length)
        '    dataStream.Close()

        '    'Keyword untuk compres lz string
        '    keyword = consID & secretKey & stamp

        '    Dim res As WebResponse = webreq.GetResponse()
        '    Dim stream As Stream = res.GetResponseStream()
        '    Dim streamReader As New StreamReader(stream)

        '    'READ RESPONSE
        '    str = streamReader.ReadToEnd
        '    streamReader.Close()

        '    str = "[" + str + "]"

        '    Dim response As String = GetResponse(str, keyword)

        '    TextBoxResponse.Text = response
        'Catch ex As WebException
        '    Dim responseStream As Stream = ex.Response.GetResponseStream()
        '    If responseStream IsNot Nothing Then
        '        Dim reader As New StreamReader(responseStream)
        '        Dim responseFromServer As String = reader.ReadToEnd()

        '        reader.Close()
        '        responseStream.Close()

        '        ' Parse JSON response to get error message
        '        Dim jsonResponse As JObject = JObject.Parse(responseFromServer)
        '        Dim errorMessage As String = jsonResponse("metaData")("message").ToString()

        '        ' Now you can use the errorMessage
        '        MessageBox.Show(errorMessage)
        '    End If
        'End Try

        'Dim parameter As String = "{" & _
        '                       """kdProviderPeserta"" : ""03140103""," & _
        '                       """tglDaftar"" : ""04-09-2023""," & _
        '                       """noKartu"" : ""0002033378673""," & _
        '                       """kdPoli"" : ""001""," & _
        '                       """keluhan"": ""tes""," & _
        '                       """kunjSakit"": true," & _
        '                       """sistole"": 0," & _
        '                       """diastole"": 0," & _
        '                       """beratBadan"": 0," & _
        '                       """tinggiBadan"": 0," & _
        '                       """respRate"": 0," & _
        '                       """lingkarPerut"": 0," & _
        '                       """heartRate"": 0," & _
        '                       """rujukBalik"": 0," & _
        '                       """kdTkp"": ""10""" & _
        '                      "}"

        Dim parameter As String = TextBoxResponseBody.Text

        Dim urlPcare As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_base_url'")
        Dim uri As String = urlPcare & TextBoxResponseURL.Text

        'Dim uri As String = "https://apijkn.bpjs-kesehatan.go.id/pcare-rest/pendaftaran" ' BPJS Asli
        'Dim uri As String = "https://apijkn-dev.bpjs-kesehatan.go.id/pcare-rest-dev/pendaftaran"

        'Dim jsonString As String = PostDataFromPcare(parameter, uri, "POST")
        Dim jsonString As String = PostDataFromPcare(parameter, uri, "POST")
        'Dim jsonObject() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of varJson())(jsonString)

        ''MsgBox(jsonString)

        'For Each rowData As varJson In jsonObject
        '    Dim codeResponse As Integer = Convert.ToInt32(rowData.metaData.code)
        '    Dim messageResponse As String = rowData.metaData.message

        '    Select Case codeResponse
        '        Case 200, 201, 204
        '            MsgBox("Sukses")
        '        Case 400, 401, 403, 404, 405, 409, 412, 500
        '            MsgBox("Gagal")
        '        Case Else
        '            ' Handle other error response here
        '            ' ...
        '    End Select

        '    MsgBox(messageResponse)
        'Next

        Dim jsonObject As JObject = JObject.Parse(jsonString)
        Dim responseArray As New JArray()

        ' Mengakses nilai "metaData"
        Dim metaDataObj As JObject = jsonObject("metaData")
        Dim codeMetaData As Integer = Convert.ToInt32(metaDataObj("code").ToString)

        ' Mengakses nilai "response"
        Dim messageResponse As String = ""
        If jsonObject("response").Type = JTokenType.Array Then
            responseArray = DirectCast(jsonObject("response"), JArray)
        ElseIf jsonObject("response").Type = JTokenType.String Then
            messageResponse = jsonObject("response").ToString()
        End If

        Select Case codeMetaData
            Case 200, 201, 204
                For Each responseArrayObj As JObject In responseArray
                    MsgBox(responseArrayObj("message").ToString())
                Next
            Case Else
                Dim errorMessage As String = ""

                If jsonObject("response").Type = JTokenType.Array Then
                    For Each responseArrayObj As JObject In responseArray
                        errorMessage = errorMessage & "- " & responseArrayObj("field").ToString() & " : " & responseArrayObj("message").ToString() & vbCrLf
                    Next
                End If

                MsgBox("Eror BPJS : " & vbCrLf & errorMessage, MsgBoxStyle.Exclamation, "Error!")

                Exit Sub
        End Select
    End Sub

    Private Sub tes()
        Dim url As String = "URL_API_ANDA"
        Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)

        ' Tambahkan header yang diperlukan, misalnya:
        ' request.Headers.Add("If-Match", "ETag_Yang_Diharapkan")

        Try
            Using response As HttpWebResponse = CType(request.GetResponse(), HttpWebResponse)
                Using stream As Stream = response.GetResponseStream()
                    Using reader As New StreamReader(stream)
                        Dim responseText As String = reader.ReadToEnd()
                        ' Lakukan apa yang Anda inginkan dengan responseText
                        MessageBox.Show(responseText, "Response")
                    End Using
                End Using
            End Using
        Catch ex As WebException
            If ex.Response IsNot Nothing Then
                Using response As HttpWebResponse = CType(ex.Response, HttpWebResponse)
                    Using stream As Stream = response.GetResponseStream()
                        Using reader As New StreamReader(stream)
                            Dim responseText As String = reader.ReadToEnd()
                            ' Lakukan apa yang Anda inginkan dengan responseText
                            MessageBox.Show(responseText, "Error Response")
                        End Using
                    End Using
                End Using
            End If
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MsgBox(GetTokenAntrol())
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim urlWebService As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'web_service_get_data_antrol'")

        urlWebService = urlWebService & "0/2023-10-17"

        Dim responseString As String = GetDataAntrianOnline(urlWebService)
        Dim jsonObject() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of varJson())(responseString)

        For Each oneVar As varJson In jsonObject
            For index As Integer = 0 To oneVar.response.Length - 1
                MsgBox(oneVar.response(index).nomorantrean)
            Next
        Next
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim urlWebService As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'web_service_get_data_peserta_antrol'")

        urlWebService = urlWebService & "4567890123456"

        Dim responseString As String = GetDataAntrianOnline(urlWebService)
        Dim jsonObject() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of JsonGetPesertaAntrol())(responseString)

        For Each oneVar As JsonGetPesertaAntrol In jsonObject
            MsgBox(oneVar.response.nama)
        Next
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim urlWebService As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'web_service_put_checkin_antrol'")

        Dim nomorantrean As String = "A1"
        Dim tanggalperiksa As String = "2023-10-31"
        Dim dilayanioleh As String = "user_testing"
        Dim parameterCheckin As String = "{" & _
                                         """nomorantrean"" : """ & nomorantrean & """," & _
                                         """tanggalperiksa"" : """ & tanggalperiksa & """," & _
                                         """dilayanioleh"": """ & dilayanioleh & """" & _
                                         "}"

        Dim responseString As String = PutCheckinAntrol(urlWebService, parameterCheckin)
        Dim jsonObject() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of JsonGetPesertaAntrol())(responseString)

        For Each oneVar As JsonGetPesertaAntrol In jsonObject
            MsgBox(oneVar.metaData.message)
        Next
    End Sub

    Private Sub ButtonClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClose.Click
        Me.Close()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub Button5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            Dim consID As String = "30550"
            Dim secretKey = "8dMD8A674E"
            Dim pcareUname = "0221B186_icare"
            Dim pcarePWD = "Jkn2024*"
            Dim kdAplikasi = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_kode_aplikasi'")
            Dim userKey = "f07d1c3eb10fa75401385c31329c9601"

            Dim tgl As Integer = ((DateTime.UtcNow - Convert.ToDateTime("1970-01-01 00:00:00")).TotalSeconds())
            Dim stamp As String = tgl.ToString()

            Dim data As String = consID + "&" + stamp
            Dim data2 As String = pcareUname + ":" + pcarePWD + ":" + kdAplikasi
            Dim encodedSignature As String = HashString(data, secretKey)

            'Authorization
            Dim Authorization = System.Text.Encoding.UTF8.GetBytes(data2)
            Dim encodedAuthorization = Convert.ToBase64String(Authorization)

            TextBoxGenerateConsID.Text = consID
            TextBoxGenerateTimestamp.Text = stamp
            TextBoxGenerateSignature.Text = encodedSignature
            TextBoxGenerateAuthorization.Text = "Basic " + encodedAuthorization



            'Dim data As String = "testtesttest"
            'Dim secretKey As String = "8dMD8A674E"

            '' Initialize the keyed hash object using the secret key as the key
            'Dim hashObject As New HMACSHA256(Encoding.UTF8.GetBytes(secretKey))

            '' Computes the signature by hashing the salt with the secret key as the key
            'Dim signature = hashObject.ComputeHash(Encoding.UTF8.GetBytes(data))

            '' Base 64 Encode
            'Dim encodedSignature = Convert.ToBase64String(signature)

            '' URLEncode
            '' encodedSignature = System.Web.HttpUtility.UrlEncode(encodedSignature)

            'Console.WriteLine("Voila! A signature: " & encodedSignature)

            'Console.ReadKey()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim keyword As String = TextBoxGenerateConsID.Text & TextBoxSecretKey.Text & TextBoxGenerateTimestamp.Text
        Dim str As String = TextBoxResponseBody.Text

        TextBoxResponse.Text = generateResponse(str, keyword)
    End Sub
End Class