Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Data.DataTable
Imports System.IO
Imports System.Drawing
Imports System.Net
Imports System.Text
Imports System.Object
Imports Newtonsoft.Json
Imports Newtonsoft
Imports System.Security.Cryptography
Imports System.Collections.Generic
Imports Newtonsoft.Json.Linq
Imports KASLibrary
Imports System.Text.RegularExpressions
Imports System.Net.NetworkInformation
Imports Microsoft.Office.Interop
Imports System.Collections.Specialized
Imports System.Globalization
Imports DevExpress.XtraPrinting
Imports System.Threading
Imports System.Web

Module Test
    Private Class varJson
        Public metaData As MetaData
        Public response As String
    End Class

    Private Class varJsonPcare
        Public metaData As MetaData
        Public response As v4_BPJS
    End Class

    Private Class varJsonAntrol
        Public metaData As v4_BPJS_Antrol
        Public response As v4_BPJS_Antrol
    End Class

    Public Structure TLcon
        Dim Tconnect As MySqlConnection
        Dim Tcommand As MySqlCommand
        Dim Tread As MySqlDataReader
        Dim Tid As String
        Dim Tip As String
        Dim Tdb As String
        Dim Tpass As String
    End Structure

    Public Structure DBOLEConn
        Public Con As OleDbConnection
        Public Cmd As OleDbCommand
        Public Red As OleDbDataReader
        Public Adp As OleDbDataAdapter
    End Structure

    Public Structure DBSQLConn
        Public Con As SqlConnection
        Public Cmd As SqlCommand
        Public Red As SqlDataReader
        Public Adp As SqlDataAdapter
    End Structure

    Public PusatSQL As DBSQLConn
    Public PusatOLE As DBOLEConn
    Public Report As XtraReport

    Private DB_Poliklinik As TLcon

    Function CekKoneksi(ByVal txt As String, ByVal Tconn As TLcon) As Boolean
        Dim Dttable As New DataTable
        Dim Tbool As Boolean = False
        Dim lblconnect As String = ""
        With Tconn
            Try
                lblconnect = "Loading Connect to Cahaya Database ..."
                .Tconnect = New MySqlConnection("datasource=" & Tconn.Tip.ToString & ";username=" & Tconn.Tid.ToString & ";password=" & Tconn.Tpass.ToString & ";database=" & Tconn.Tdb.ToString)
                If .Tconnect.State = ConnectionState.Open Then .Tconnect.Close()
                .Tconnect.Open()
                .Tcommand = New MySqlCommand(txt, .Tconnect)
                .Tread = .Tcommand.ExecuteReader
                Dttable.Load(.Tread)
                If Dttable.Rows.Count > 0 Then
                    Tbool = True
                End If
                .Tconnect.Close()
            Catch ex As Exception
                'MsgBox("Proses gagal, periksa kembali koneksi ke server!")
            Finally
                .Tconnect.Dispose()
            End Try
        End With

        Return Tbool
    End Function

    Function CheckThemysql(ByVal txt As String, ByVal Tconn As TLcon) As Boolean
        Dim Dttable As New DataTable
        Dim Tbool As Boolean = False
        Dim lblconnect As String = ""
        With Tconn
            Try
                lblconnect = "Loading Connect to Cahaya Database ..."
                .Tconnect = New MySqlConnection("datasource=" & Tconn.Tip.ToString & ";username=" & Tconn.Tid.ToString & ";password=" & Tconn.Tpass.ToString & ";database=" & Tconn.Tdb.ToString)
                If .Tconnect.State = ConnectionState.Open Then .Tconnect.Close()
                .Tconnect.Open()
                .Tcommand = New MySqlCommand(txt, .Tconnect)
                .Tread = .Tcommand.ExecuteReader
                Dttable.Load(.Tread)
                If Dttable.Rows.Count > 0 Then
                    Tbool = True
                End If
                .Tconnect.Close()
            Catch ex As Exception
                'MsgBox("Failed Connected to Cahaya Database !!!")
                lblconnect = "Failed Connected !!! " & ex.Message
                MsgBox(ex.Message)
            Finally
                .Tconnect.Dispose()
            End Try
        End With

        Return Tbool
    End Function

    Function CheckForDataMySQL(ByVal queryString As String, ByVal connection As TLcon) As Boolean
        Dim resultBoolean As Boolean = False

        'Dim urlWebService As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'web_service_get_token_antrol'")
        Dim urlWebService As String = "http://127.0.0.1:8000/api/get-data-resource-poliklinik"
        Dim jsonResponse As String = ""

        'REQUEST GET METHOD
        Dim webreq As HttpWebRequest = WebRequest.Create(urlWebService)

        webreq.Accept = "application/json"
        webreq.Headers("result-option") = "Boolean"
        webreq.Headers("mysql-host") = connection.Tip.ToString
        webreq.Headers("mysql-port") = "3306"
        webreq.Headers("mysql-database") = connection.Tdb.ToString
        webreq.Headers("mysql-username") = connection.Tid.ToString
        webreq.Headers("mysql-password") = connection.Tpass.ToString
        webreq.Headers("mysql-query") = queryString
        webreq.Method = "GET"

        Dim res As WebResponse = webreq.GetResponse()
        Dim stream As Stream = res.GetResponseStream()
        Dim streamReader As New StreamReader(stream)

        ' READ RESPONSE
        jsonResponse = streamReader.ReadToEnd()
        streamReader.Close()

        ' Mengkonversi respons menjadi tipe data boolean
        If jsonResponse.ToLower() = "true" Then
            resultBoolean = True
        End If

        Return resultBoolean
    End Function

    Function ReadThemysql(ByVal txt As String, ByVal Tconn As TLcon) As DataTable
        Dim Dttable As New DataTable
        Dim lblconnect As String = ""
        With Tconn
            Try
                lblconnect = "Loading Connect to Cahaya Database ..."
                .Tconnect = New MySqlConnection("datasource=" & Tconn.Tip.ToString & ";username=" & Tconn.Tid.ToString & ";password=" & Tconn.Tpass.ToString & ";database=" & Tconn.Tdb.ToString)
                If .Tconnect.State = ConnectionState.Open Then .Tconnect.Close()
                .Tconnect.Open()
                .Tcommand = New MySqlCommand(txt, .Tconnect)
                .Tread = .Tcommand.ExecuteReader
                Dttable.Load(.Tread)
                .Tconnect.Close()
            Catch ex As Exception
                'MsgBox("Failed Connected to Cahaya Database !!!")
                lblconnect = "Failed Connected !!! " & ex.Message
                MsgBox(ex.Message)
            Finally
                .Tconnect.Dispose()
            End Try
        End With

        Return Dttable
    End Function

    Function ExecuteQueryWithResultDataTableMySQL(ByVal queryString As String, ByVal connection As TLcon) As DataTable
        Dim resultTable As New DataTable

        'Dim urlWebService As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'web_service_get_token_antrol'")
        Dim urlWebService As String = "http://127.0.0.1:8000/api/get-data-resource-poliklinik"
        Dim jsonResponse As String = ""

        'REQUEST GET METHOD
        Dim webreq As HttpWebRequest = WebRequest.Create(urlWebService)

        webreq.Accept = "application/json"
        webreq.Headers("result-option") = "DataTable"
        webreq.Headers("mysql-host") = connection.Tip.ToString
        webreq.Headers("mysql-port") = "3306"
        webreq.Headers("mysql-database") = connection.Tdb.ToString
        webreq.Headers("mysql-username") = connection.Tid.ToString
        webreq.Headers("mysql-password") = connection.Tpass.ToString
        webreq.Headers("mysql-query") = queryString
        webreq.Method = "GET"

        Dim res As WebResponse = webreq.GetResponse()
        Dim stream As Stream = res.GetResponseStream()
        Dim streamReader As New StreamReader(stream)

        ' READ RESPONSE
        jsonResponse = streamReader.ReadToEnd()
        streamReader.Close()

        If Not String.IsNullOrEmpty(jsonResponse) Then
            resultTable = JsonConvert.DeserializeObject(Of DataTable)(jsonResponse)
        End If

        Return resultTable
    End Function

    Function ReadThemysqlNIK(ByVal txt As String, ByVal Tconn As TLcon) As String
        Dim Dttable As New DataTable
        Dim lblconnect As String = ""
        With Tconn
            Try
                lblconnect = "Loading Connect to Cahaya Database ..."
                .Tconnect = New MySqlConnection("datasource=" & Tconn.Tip.ToString & ";username=" & Tconn.Tid.ToString & ";password=" & Tconn.Tpass.ToString & ";database=" & Tconn.Tdb.ToString)
                If .Tconnect.State = ConnectionState.Open Then .Tconnect.Close()
                .Tconnect.Open()
                .Tcommand = New MySqlCommand(txt, .Tconnect)
                .Tread = .Tcommand.ExecuteReader
                Dttable.Load(.Tread)
                .Tconnect.Close()
            Catch ex As Exception
                'MsgBox("Failed Connected to Cahaya Database !!!")
                lblconnect = "Failed Connected !!! " & ex.Message
                MsgBox(ex.Message)
            Finally
                .Tconnect.Dispose()
            End Try
        End With
        If Dttable.Rows.Count = 0 Then
            Return "-"
        Else
            Return Dttable.Rows(0)(0).ToString()
        End If
    End Function

    Function ExecuteQueryWithResultDataStringMySQL(ByVal queryString As String, ByVal connection As TLcon) As String
        'Dim urlWebService As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'web_service_get_token_antrol'")
        Dim urlWebService As String = "http://127.0.0.1:8000/api/get-data-resource-poliklinik"
        Dim jsonResponse As String = ""

        'REQUEST GET METHOD
        Dim webreq As HttpWebRequest = WebRequest.Create(urlWebService)

        webreq.Accept = "application/json"
        webreq.Headers("result-option") = "String"
        webreq.Headers("mysql-host") = connection.Tip.ToString
        webreq.Headers("mysql-port") = "3306"
        webreq.Headers("mysql-database") = connection.Tdb.ToString
        webreq.Headers("mysql-username") = connection.Tid.ToString
        webreq.Headers("mysql-password") = connection.Tpass.ToString
        webreq.Headers("mysql-query") = queryString
        webreq.Method = "GET"

        Dim res As WebResponse = webreq.GetResponse()
        Dim stream As Stream = res.GetResponseStream()
        Dim streamReader As New StreamReader(stream)

        ' READ RESPONSE
        jsonResponse = streamReader.ReadToEnd()
        streamReader.Close()

        ' Menghapus tanda kutip ganda dari string
        jsonResponse = jsonResponse.Trim(""""c)

        Return jsonResponse
    End Function

    Public Sub ExecuteQueryWithoutResultMySQL(ByVal queryString As String, ByVal connection As TLcon)
        'Dim urlWebService As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'web_service_get_token_antrol'")
        Dim urlWebService As String = "http://127.0.0.1:8000/api/get-data-resource-poliklinik"
        Dim jsonResponse As String = ""

        'REQUEST GET METHOD
        Dim webreq As HttpWebRequest = WebRequest.Create(urlWebService)

        webreq.Accept = "application/json"
        webreq.Headers("result-option") = "String"
        webreq.Headers("mysql-host") = connection.Tip.ToString
        webreq.Headers("mysql-port") = "3306"
        webreq.Headers("mysql-database") = connection.Tdb.ToString
        webreq.Headers("mysql-username") = connection.Tid.ToString
        webreq.Headers("mysql-password") = connection.Tpass.ToString
        webreq.Headers("mysql-query") = System.Web.HttpUtility.UrlEncode(queryString)
        webreq.Method = "GET"

        Dim res As WebResponse = webreq.GetResponse()
        Dim stream As Stream = res.GetResponseStream()
        Dim streamReader As New StreamReader(stream)
    End Sub

    Public Function generateLZString(ByVal parameter As String, ByVal contentType As String, ByVal method As String) As String
        Dim urlGenerateLz As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_generate_lz_string'")
        Dim uri As New Uri(urlGenerateLz)
        Dim jsonDataBytes() As Byte = Encoding.UTF8.GetBytes(parameter)

        Dim req As WebRequest = WebRequest.Create(uri)
        req.ContentType = contentType
        req.Method = method
        req.ContentLength = jsonDataBytes.Length

        Dim stream = req.GetRequestStream()
        stream.Write(jsonDataBytes, 0, jsonDataBytes.Length)
        stream.Close()

        Dim response = req.GetResponse().GetResponseStream()

        Dim reader As New StreamReader(response)
        Dim res = reader.ReadToEnd()
        reader.Close()
        response.Close()

        Return res
    End Function

    Public Function HashString(ByVal StringToHash As String, ByVal secretKey As String) As String
        Dim hashObject As New System.Security.Cryptography.HMACSHA256(Encoding.UTF8.GetBytes(secretKey))
        Dim signature = hashObject.ComputeHash(Encoding.UTF8.GetBytes(StringToHash))
        Dim encodedSignature = Convert.ToBase64String(signature)
        'encodedSignature = System.Web.HttpUtility.UrlEncode(encodedSignature)
        Return encodedSignature
    End Function

    Public Function SetParameterWhatsapp(ByVal NoWhatsapp As String, ByVal TxPDF As String, ByVal filename As String, ByVal message As String) As String
        Try
            Dim message_whatsapp As String = ""
            Dim parameter As String = ""

            If message = "Yes" Then
                message_whatsapp = "Kepada Yth.\n" & _
                  "Customer Cahaya Diagnostic Centre\n\n" & _
                  "Kami mengucapkan terima kasih atas kepercayaan Bapak/Ibu/Saudara/i sudah melakukan pemeriksaan di Laboratorium Cahaya Diagnostic Centre. Berikut ini kami lampirkan hasil pemeriksaan laboratorium anda.\n\n" & _
                  "Silahkan menghubungi kami di nomor  081332209900 (WA/Phone) untuk info lain.\n\n" & _
                  "Best regards,\n\n" & _
                  "Laboratorium Cahaya Diagnostic Centre.\n\n" & _
                  "----- Pesan ini adalah pesan otomatis, mohon agar tidak membalas -----"
            ElseIf message = "No" Then
                message_whatsapp = ""
            End If

            parameter = "{" & _
              """number"" : """ & NoWhatsapp & """," & _
              """mime"" : ""application/pdf""," & _
              """src"" : """ & TxPDF & """," & _
              """filename"" : """ & filename & """," & _
              """caption"" : """"," & _
              """thumbnail"" : """"," & _
              """message"" : """ & message_whatsapp & """" & _
             "}"

            Return parameter
        Catch ex As Exception
            Return "Nothing"
        End Try
    End Function

    Public Function SetParameterWhatsappKlinik(ByVal NoWhatsapp As String, ByVal TxPDF As String, ByVal filename As String, ByVal pesanWhatsApp As String) As String
        Try
            Dim parameter As String = ""

            parameter = "{" & _
              """number"" : """ & NoWhatsapp & """," & _
              """mime"" : ""application/pdf""," & _
              """src"" : """ & TxPDF & """," & _
              """filename"" : """ & filename & """," & _
              """caption"" : """"," & _
              """thumbnail"" : """"," & _
              """message"" : """ & pesanWhatsApp & """" & _
             "}"

            Return parameter
        Catch ex As Exception
            Return "Nothing"
        End Try
    End Function

    Public Function SendDataWhatsappHBD(ByVal parameter As String, ByVal uri As String) As Boolean
        Try
            Dim bytearr() As Byte = Encoding.UTF8.GetBytes(parameter)

            Dim webreq As HttpWebRequest = WebRequest.Create(uri)
            webreq.Accept = "application/json"
            webreq.Method = "POST"
            webreq.ContentType = "application/json"
            webreq.ContentLength = bytearr.Length

            Dim dataStream As Stream = webreq.GetRequestStream()
            dataStream.Write(bytearr, 0, bytearr.Length)
            dataStream.Close()

            Dim res As WebResponse = webreq.GetResponse()
            Dim stream As Stream = res.GetResponseStream()
            Dim streamReader As New StreamReader(stream)

            Dim str As String = streamReader.ReadToEnd()
            streamReader.Close()

            ' 🔥 DEBUG penting
            'MsgBox("Response API: " & str)

            ' ====== LOGIC SUCCESS ======
            If str.ToLower().Contains("success") OrElse str.ToLower().Contains("true") Then
                Return True
            End If

            Return False

        Catch ex As Exception
            MsgBox("Error WA: " & ex.Message)
            Return False
        End Try
    End Function

    Public Function SendDataWhatsapp(ByVal parameter As String, ByVal uri As String) As String
        Try
            Dim bytearr() As Byte = Encoding.UTF8.GetBytes(parameter)
            Dim str As String = ""

            Dim webreq As HttpWebRequest = WebRequest.Create(uri)
            webreq.Accept = "application/json"

            webreq.Method = "POST"
            webreq.ContentType = "application/json"
            webreq.ContentLength = bytearr.Length

            Dim dataStream As Stream = webreq.GetRequestStream()
            dataStream.Write(bytearr, 0, bytearr.Length)
            dataStream.Close()

            Dim res As WebResponse = webreq.GetResponse()
            Dim stream As Stream = res.GetResponseStream()
            Dim streamReader As New StreamReader(stream)

            'READ RESPONSE
            str = streamReader.ReadToEnd
            streamReader.Close()

            Return "Success"
        Catch ex As Exception
            Return "Nothing"
        End Try
    End Function

    Public Sub WriteThemysql(ByVal txt As String, ByVal Tconn As TLcon)
        Dim lblconnect As String = ""
        With Tconn
            Try
                lblconnect = "Loading Connect to Cahaya Database ..."
                .Tconnect = New MySqlConnection("datasource=" & Tconn.Tip.ToString & ";username=" & Tconn.Tid.ToString & ";password=" & Tconn.Tpass.ToString & ";database=" & Tconn.Tdb.ToString)
                If .Tconnect.State = ConnectionState.Open Then .Tconnect.Close()
                .Tconnect.Open()
                .Tcommand = New MySqlCommand(txt, .Tconnect)
                .Tcommand.ExecuteNonQuery()
                .Tconnect.Close()
            Catch ex As Exception
                'MsgBox("Failed Connected to Cahaya Database !!!")
                lblconnect = "Failed Connected !!! " & ex.Message
                MsgBox(ex.Message)
            Finally

                '.Tconnect.Dispose()
            End Try
        End With
    End Sub

    ' Fungsi untuk menulis data ke MySQL dengan parameter
    Public Sub WriteParameterizedOnlineSQL(ByVal query As String, ByVal Tconn As TLcon, ByVal txType As Integer, ByVal ParamArray parameters As MySqlParameter())
        Dim lblconnect As String = ""
        With Tconn
            Try
                lblconnect = "Loading Connect to Cahaya Database ..."
                .Tconnect = New MySqlConnection("datasource=" & Tconn.Tip.ToString & ";username=" & Tconn.Tid.ToString & ";password=" & Tconn.Tpass.ToString & ";database=" & Tconn.Tdb.ToString)
                If .Tconnect.State = ConnectionState.Open Then .Tconnect.Close()
                .Tconnect.Open()

                Using command As New MySqlCommand(query, .Tconnect)
                    ' Tambahkan parameter ke pernyataan SQL
                    command.Parameters.AddRange(parameters)

                    ' Eksekusi pernyataan SQL
                    command.ExecuteNonQuery()
                End Using

                .Tconnect.Close()
            Catch ex As Exception
                ' MsgBox("Failed Connected to Cahaya Database !!!")
                lblconnect = "Failed Connected !!! " & ex.Message
                MsgBox(ex.Message)
            Finally
                ' .Tconnect.Dispose()
            End Try
        End With
    End Sub

    Function CheckSQL(ByVal txt As String) As Boolean
        Dim Dttable As New DataTable
        Dim Dbsql As New DBSQLConn
        Try
            Dbsql.Con = New SqlConnection(PusatSQL.Con.ConnectionString)
            Dbsql.Con.Open()
            Dbsql.Cmd = New SqlCommand(txt, Dbsql.Con)
            Dbsql.Red = Dbsql.Cmd.ExecuteReader
            If Dbsql.Red.HasRows = True Then
                Dbsql.Con.Close()
                Return True
            Else
                Dbsql.Con.Close()
                Return False
            End If
        Catch ex As Exception
            InputBox("Test", "Test", txt)
            Dbsql.Con.Close()
            MsgBox(ex.Message)
            Return False
        End Try
    End Function

    Function ReadSQL(ByVal Txt As String, ByVal Tdb As DBSQLConn) As DataTable
        Dim Dttable As New DataTable
        Dim Dbsql As New DBSQLConn
        Try
            Dbsql.Con = New SqlConnection(Tdb.Con.ConnectionString)
            Dbsql.Con.Open()
            Dbsql.Cmd = New SqlCommand(Txt, Dbsql.Con)
            Dbsql.Red = Dbsql.Cmd.ExecuteReader
            Dttable.Load(Dbsql.Red)
            Dbsql.Con.Close()
            Return Dttable
        Catch ex As Exception
            InputBox("Test", "Test", Txt)
            MsgBox(ex.Message)
            Dbsql.Con.Close()
            Return Dttable
        End Try
    End Function

    Function ReadSQL(ByVal Txt As String) As DataTable
        Dim Dttable As New DataTable
        Dim Dbsql As New DBSQLConn
        Try
            Dbsql.Con = New SqlConnection(PusatSQL.Con.ConnectionString)
            Dbsql.Con.Open()
            Dbsql.Cmd = New SqlCommand(Txt, Dbsql.Con)
            Dbsql.Red = Dbsql.Cmd.ExecuteReader
            Dttable.Load(Dbsql.Red)
            Dbsql.Con.Close()
            Return Dttable
        Catch ex As Exception
            InputBox("Test", "Test", Txt)
            MsgBox(ex.Message)
            Dbsql.Con.Close()
            Return Dttable
        End Try
    End Function

    Function ReadSQLNIK(ByVal Txt As String) As String
        Dim Dttable As New DataTable
        Dim Dbsql As New DBSQLConn
        Dim Rws As DataRow
        Try
            Dbsql.Con = New SqlConnection(PusatSQL.Con.ConnectionString)
            Dbsql.Con.Open()
            Dbsql.Cmd = New SqlCommand(Txt, Dbsql.Con)
            Dbsql.Red = Dbsql.Cmd.ExecuteReader
            Dttable.Load(Dbsql.Red)
            Dbsql.Con.Close()
            If Dttable.Rows.Count > 0 Then
                Rws = Dttable.Rows(Dttable.Rows.Count - 1)
                Return Rws(0).ToString
            Else
                Return "-"
            End If
        Catch ex As Exception

            InputBox("Test", "Test", Txt)
            MsgBox(ex.Message)
            Dbsql.Con.Close()
            Return "-"
        End Try
    End Function

    Public Sub WriteParameterizedLokalSQL(ByVal query As String, ByVal txType As Integer, ByVal ParamArray parameters As SqlParameter())
        Dim dbSql As New DBSQLConn

        Try
            Using connection As New SqlConnection(PusatSQL.Con.ConnectionString)
                connection.Open()

                Using command As New SqlCommand(query, connection)
                    ' Tambahkan parameter ke pernyataan SQL
                    command.Parameters.AddRange(parameters)

                    ' Eksekusi pernyataan SQL
                    Dim affectedRows As Integer = command.ExecuteNonQuery()

                    If affectedRows > 0 Then
                        If txType = 1 Then
                            MsgBox("Data Saved")
                        ElseIf txType = 2 Then
                            MsgBox("Data Updated")
                        ElseIf txType = 3 Then
                            MsgBox("Data Deleted")
                        ElseIf txType = 4 Then
                            ' Lanjutkan tanpa alasan
                        Else
                            MsgBox("...")
                        End If
                    Else
                        MsgBox("No data affected.")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Function WriteSQLResult(ByVal Txt As String, ByRef Txtype As Integer) As Integer
        Dim Dbsql As New DBSQLConn
        Dim result As Integer = 0
        Try
            Dbsql.Con = New SqlConnection(PusatSQL.Con.ConnectionString)
            Dbsql.Con.Open()
            Dbsql.Cmd = New SqlCommand(Txt, Dbsql.Con)
            result = Dbsql.Cmd.ExecuteNonQuery()
            Dbsql.Con.Close()
        Catch ex As Exception
            MsgBox("Error WriteSQLResult: " & ex.Message)
            result = 0
        End Try
        Return result
    End Function

    Public Sub WriteSQL(ByVal Txt As String, ByRef Txtype As Integer)
        Dim Dbsql As New DBSQLConn
        Dim Dbsql2 As New DBSQLConn
        Try
            Dbsql.Con = New SqlConnection(PusatSQL.Con.ConnectionString)
            Dbsql.Con.Open()
            Dbsql.Cmd = New SqlCommand(Txt, Dbsql.Con)
            Dbsql.Cmd.ExecuteReader()
            Dbsql.Con.Close()

            If Txtype = 1 Then
                MsgBox("Data Saved")
            ElseIf Txtype = 2 Then
                MsgBox("Data Updated")
            ElseIf Txtype = 3 Then
                MsgBox("Data Deleted")
            ElseIf Txtype = 4 Then
                'continue without reason
            Else
                MsgBox("...")
            End If

        Catch ex As Exception
            InputBox("Test", "Test", Txt)
            MsgBox(ex.Message)
            Dbsql.Con.Close()
        End Try

    End Sub

    Function CheckOLE(ByVal txt As String) As Boolean
        Dim Dttable As New DataTable
        Dim Dbsql As New DBOLEConn
        Try
            Dbsql.Con = New OleDbConnection(PusatOLE.Con.ConnectionString)
            Dbsql.Con.Open()
            Dbsql.Cmd = New OleDbCommand(txt, Dbsql.Con)
            Dbsql.Red = Dbsql.Cmd.ExecuteReader
            If Dbsql.Red.HasRows = True Then
                Dbsql.Con.Close()
                Return True
            Else
                Dbsql.Con.Close()
                Return False
            End If
        Catch ex As Exception
            InputBox("Test", "Test", txt)
            MsgBox(ex.Message)
            Dbsql.Con.Close()
            Return False
        End Try

    End Function

    Function ReadSQLOLE(ByVal Txt As String) As DataTable
        Dim Dttable As New DataTable
        Dim Dtset As New DataSet
        Dim Dbsql As New DBOLEConn
        Try
            Dbsql.Con = New OleDbConnection(PusatOLE.Con.ConnectionString)
            Dbsql.Con.Open()
            Dbsql.Cmd = New OleDbCommand(Txt, Dbsql.Con)
            Dbsql.Red = Dbsql.Cmd.ExecuteReader
            Dttable.Load(Dbsql.Red)
            Dbsql.Con.Close()
            Return Dttable
        Catch ex As Exception
            InputBox("Test", "Test", Txt)
            MsgBox(ex.Message)
            Dbsql.Con.Close()
            Return Dttable
        End Try
    End Function

    Function ReadOLENIK(ByVal Txt As String) As String
        Dim Dttable As New DataTable
        Dim Dtset As New DataSet
        Dim Dbsql As New DBOLEConn
        Dim Rws As DataRow
        Try
            Dbsql.Con = New OleDbConnection(PusatOLE.Con.ConnectionString)
            Dbsql.Con.Open()
            Dbsql.Cmd = New OleDbCommand(Txt, Dbsql.Con)
            Dbsql.Red = Dbsql.Cmd.ExecuteReader
            Dttable.Load(Dbsql.Red)
            Dbsql.Con.Close()
            If Dttable.Rows.Count > 0 Then
                Dbsql.Con.Close()
                Rws = Dttable.Rows(Dttable.Rows.Count - 1)
                Return Rws(0).ToString
            Else
                Return "-"
            End If
        Catch ex As Exception
            InputBox("Test", "Test", Txt)
            MsgBox(ex.Message)
            Dbsql.Con.Close()
            Return "-"
        End Try
    End Function

    Public Sub WriteSQLOLE(ByVal Txt As String)
        Dim Dbsql As New DBOLEConn
        Dim Dbsql2 As New DBOLEConn

        Try
            Dbsql.Con = New OleDbConnection(PusatOLE.Con.ConnectionString)
            Dbsql.Con.Open()
            Dbsql.Cmd = New OleDbCommand(Txt, Dbsql.Con)
            Dbsql.Cmd.ExecuteReader()
            Dbsql.Con.Close()
        Catch ex As Exception
            InputBox("Test", "Test", Txt)
            Dbsql.Con.Close()
            MsgBox(ex.Message)
        End Try

        Try
            Dbsql2.Con = New OleDbConnection(PusatOLE.Con.ConnectionString)
            Dbsql2.Con.Open()
            'Dbsql2.Cmd = New OleDbCommand("insert into DBLog values('" & Txt & "','" & Format(DateAndTime.Now, "MM/dd/yyyy") & "','Admin')", Dbsql.Con)
            Dbsql2.Cmd.ExecuteReader()
            Dbsql2.Con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            Dbsql2.Con.Close()
        End Try

    End Sub

    Public Sub InsertNewItemComboSQL(ByVal Str As String, ByVal Cmbdata As System.Windows.Forms.ComboBox)
        Dim Dbsql As New DBSQLConn
        Dim Dttable As New DataTable
        Dim Dtset As New DataSet
        Cmbdata.DataSource = Nothing
        Cmbdata.Items.Clear()
        Try
            Dbsql.Con = New SqlConnection(PusatSQL.Con.ConnectionString)
            Dbsql.Con.Open()
            Dbsql.Cmd = New SqlCommand(Str, Dbsql.Con)
            Dbsql.Red = Dbsql.Cmd.ExecuteReader
            Dttable.Load(Dbsql.Red)
            With Cmbdata
                .DataSource = Dttable
                .DisplayMember = Dttable.Columns(0).ColumnName
                .ResetText()
            End With
            Dbsql.Con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            If Dbsql.Con.State = ConnectionState.Open Then Dbsql.Con.Close()
        End Try

    End Sub 'query ambil data untuk masing-masing combo

    Public Sub InsertNewItemListSQL(ByVal Str As String, ByVal Cmbdata As ListBox, ByVal Alter As Boolean)
        Dim Dbsql As New DBSQLConn
        If Alter = False Then Cmbdata.Items.Clear()

        Try
            Dbsql.Con = New SqlConnection(PusatSQL.Con.ConnectionString)
            Dbsql.Con.Open()
            Dbsql.Cmd = New SqlCommand(Str, Dbsql.Con)
            Dbsql.Red = Dbsql.Cmd.ExecuteReader

            While Dbsql.Red.Read
                Cmbdata.Items.Add(Dbsql.Red(0).ToString)
            End While
            Dbsql.Con.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            Dbsql.Con.Close()
        End Try

    End Sub 'query ambil data untuk masing-masing combo

    Function GetRomes(ByRef bln As Integer) As String
        Dim TX As String = "-"
        Select Case bln
            Case 1 : TX = "I"
            Case 2 : TX = "II"
            Case 3 : TX = "III"
            Case 4 : TX = "IV"
            Case 5 : TX = "V"
            Case 6 : TX = "VI"
            Case 7 : TX = "VII"
            Case 8 : TX = "VIII"
            Case 9 : TX = "IX"
            Case 10 : TX = "X"
            Case 11 : TX = "XI"
            Case 12 : TX = "XII"
            Case Else : TX = "-"
        End Select
        Return TX
    End Function

    Public Sub insertRowToTbls(ByRef xtbls As DataTable, ByVal xsystem As String, ByVal xname As String)
        Dim Xcolumns As DataColumn = New DataColumn
        Xcolumns.ColumnName = xname
        Xcolumns.Caption = xname
        Select Case xsystem.ToString
            Case "Typstring"
                Xcolumns.DataType = System.Type.GetType("System.String")
            Case "tyinterger"
                Xcolumns.DataType = System.Type.GetType("System.Int64")
                Xcolumns.DefaultValue = 0
            Case "typchecked"
                Xcolumns.DataType = System.Type.GetType("System.Boolean")
                Xcolumns.DefaultValue = False
            Case "typdate"
                Xcolumns.DataType = System.Type.GetType("System.DateTime")
            Case "typefloat"
                Xcolumns.DataType = System.Type.GetType("System.Double")
                Xcolumns.DefaultValue = 0
            Case "typmoney"
                Xcolumns.DataType = System.Type.GetType("System.Money")
            Case "typedatetime"
        End Select
        xtbls.Columns.Add(Xcolumns)
    End Sub

    Function RangeNIK(ByRef Dbtemp As DataTable) As String
        Dim AllNik As String = "("
        For Each Trow As DataRow In Dbtemp.Rows
            AllNik = AllNik & "'" & Trow(0).ToString & "',"
        Next

        If AllNik.Length > 1 Then
            AllNik = Strings.Left(AllNik, AllNik.Length - 1)
            AllNik = AllNik & ")"
        Else
            AllNik = "('')"
        End If
        Return AllNik
    End Function

    Function ConvertBulan(ByVal bln As String) As String
        If UCase(bln) = "JAN" Then
            ConvertBulan = "Jan"
        ElseIf UCase(bln) = "FEB" Then
            ConvertBulan = "Feb"
        ElseIf UCase(bln) = "MAR" Then
            ConvertBulan = "Mar"
        ElseIf UCase(bln) = "APR" Then
            ConvertBulan = "Apr"
        ElseIf UCase(bln) = "MAY" Then
            ConvertBulan = "Mei"
        ElseIf UCase(bln) = "JUN" Then
            ConvertBulan = "Jun"
        ElseIf UCase(bln) = "JUL" Then
            ConvertBulan = "Jul"
        ElseIf UCase(bln) = "AUG" Then
            ConvertBulan = "Ags"
        ElseIf UCase(bln) = "SEP" Then
            ConvertBulan = "Sep"
        ElseIf UCase(bln) = "OCT" Then
            ConvertBulan = "Okt"
        ElseIf UCase(bln) = "NOV" Then
            ConvertBulan = "Nov"
        ElseIf UCase(bln) = "DEC" Then
            ConvertBulan = "Des"
        Else
            ConvertBulan = ""
        End If
    End Function

    Function Splitmoney(ByVal Tnilai As String) As String
        Dim TSplit() As String = Tnilai.Split(".")
        Dim Nilai = TSplit(0)
        Dim Str As String = ""
        Dim Mark As String = ""
        If Left(Nilai, 1) = "-" Then
            Mark = "-"
            Nilai = Nilai.Replace("-", "")
        End If
        Dim J As Integer = 0
        For i As Integer = Nilai.Length To 1 Step -1
            If IsNumeric(Mid(Nilai, i, 1)) = True Then
                Str = Mid(Nilai, i, 1) + Str
                J = J + 1
                If J = 3 Then
                    J = 0
                    Str = "," + Str
                End If
            Else
                Str = Mid(Nilai, i, 1) + Str
            End If
        Next
        If Left(Str, 1) = "," Then Str = Mid(Str, 2, Len(Str) - 1)
        If Str = "" Then Str = "0" Else Str = Mark + Str
        If TSplit.Length > 1 Then Str = Str + "." & TSplit(1)
        Return Str
    End Function

    Function DetailUang(ByVal Tuang As Integer) As String
        Dim Tnilai As String = ""
        Dim Tanda As Boolean = False
        Dim Tsplit As Integer = 0
        Dim Tsisa As Integer = 0
        Dim Tbagi As Integer = 1000000000
        Do Until Tanda = True
            Tsplit = (Tuang - (Tuang Mod Tbagi)) / Tbagi
            If Tsplit > 0 Then Tnilai = Tnilai + MoneyChangeToChar(Tsplit, Tbagi)
            Tuang = Tuang Mod Tbagi
            Select Case Tbagi.ToString
                Case "1000000000"
                    If Tsplit > 0 Then Tnilai = Tnilai + "milyar "
                    Tbagi = Tbagi / 1000
                Case "1000000"
                    If Tsplit > 0 Then Tnilai = Tnilai + "juta "
                    Tbagi = Tbagi / 1000
                Case "1000"
                    If Tsplit > 0 Then Tnilai = Tnilai + "ribu "
                    Tbagi = Tbagi / 1000
                Case "1"
                    Tnilai = Tnilai + "rupiah "
                    Tanda = True
            End Select
        Loop

        Return Tnilai
    End Function

    Function MoneyChangeToChar(ByVal Tnilai As Integer, ByVal Pembagi As Integer) As String
        Dim Ttlstring As String = ""
        Dim Thasil As Integer = (Tnilai - (Tnilai Mod 100)) / 100

        If Thasil > 0 Then
            If Thasil.ToString = 1 Then
                Ttlstring = Ttlstring + "seratus "
            Else
                Select Case Thasil.ToString
                    Case "2"
                        Ttlstring = Ttlstring + "dua "
                    Case "3"
                        Ttlstring = Ttlstring + "tiga "
                    Case "4"
                        Ttlstring = Ttlstring + "empat "
                    Case "5"
                        Ttlstring = Ttlstring + "lima "
                    Case "6"
                        Ttlstring = Ttlstring + "enam "
                    Case "7"
                        Ttlstring = Ttlstring + "tujuh "
                    Case "8"
                        Ttlstring = Ttlstring + "delapan "
                    Case "9"
                        Ttlstring = Ttlstring + "sembilan "
                End Select
                Ttlstring = Ttlstring + "ratus "
            End If
        End If

        Thasil = Tnilai Mod 100

        If Thasil > 0 Then
            If Thasil < 20 Then
                Select Case Thasil.ToString
                    Case "1"
                        Ttlstring = Ttlstring + "satu "
                    Case "2"
                        Ttlstring = Ttlstring + "dua "
                    Case "3"
                        Ttlstring = Ttlstring + "tiga "
                    Case "4"
                        Ttlstring = Ttlstring + "empat "
                    Case "5"
                        Ttlstring = Ttlstring + "lima "
                    Case "6"
                        Ttlstring = Ttlstring + "enam "
                    Case "7"
                        Ttlstring = Ttlstring + "tujuh "
                    Case "8"
                        Ttlstring = Ttlstring + "delapan "
                    Case "9"
                        Ttlstring = Ttlstring + "sembilan "
                    Case "10"
                        Ttlstring = Ttlstring + "sepuluh "
                    Case "11"
                        Ttlstring = Ttlstring + "sebelas "
                    Case "12"
                        Ttlstring = Ttlstring + "dua belas "
                    Case "13"
                        Ttlstring = Ttlstring + "tiga belas "
                    Case "14"
                        Ttlstring = Ttlstring + "empat belas "
                    Case "15"
                        Ttlstring = Ttlstring + "lima belas "
                    Case "16"
                        Ttlstring = Ttlstring + "enam belas "
                    Case "17"
                        Ttlstring = Ttlstring + "tujuh belas "
                    Case "18"
                        Ttlstring = Ttlstring + "delapan belas "
                    Case "19"
                        Ttlstring = Ttlstring + "sembilan belas "
                End Select
            Else
                Select Case ((Thasil - (Thasil Mod 10)) / 10).ToString
                    Case "2"
                        Ttlstring = Ttlstring + "dua "
                    Case "3"
                        Ttlstring = Ttlstring + "tiga "
                    Case "4"
                        Ttlstring = Ttlstring + "empat "
                    Case "5"
                        Ttlstring = Ttlstring + "lima "
                    Case "6"
                        Ttlstring = Ttlstring + "enam "
                    Case "7"
                        Ttlstring = Ttlstring + "tujuh "
                    Case "8"
                        Ttlstring = Ttlstring + "delapan "
                    Case "9"
                        Ttlstring = Ttlstring + "sembilan "
                End Select
                Ttlstring = Ttlstring + "puluh "

                Thasil = Thasil Mod 10
                Select Case Thasil
                    Case "1"
                        Ttlstring = Ttlstring + "satu "
                    Case "2"
                        Ttlstring = Ttlstring + "dua "
                    Case "3"
                        Ttlstring = Ttlstring + "tiga "
                    Case "4"
                        Ttlstring = Ttlstring + "empat "
                    Case "5"
                        Ttlstring = Ttlstring + "lima "
                    Case "6"
                        Ttlstring = Ttlstring + "enam "
                    Case "7"
                        Ttlstring = Ttlstring + "tujuh "
                    Case "8"
                        Ttlstring = Ttlstring + "delapan "
                    Case "9"
                        Ttlstring = Ttlstring + "sembilan "
                End Select
            End If
        End If

        Return Ttlstring
    End Function

    Function arraytohex(ByRef arr() As Byte) As String
        Dim templatestr As String
        Dim tempstr As String
        Dim i As Short
        templatestr = ""
        For i = LBound(arr) To UBound(arr)
            tempstr = Hex(arr(i))
            If Len(tempstr) = 1 Then tempstr = "0" & tempstr 'padHex
            templatestr = templatestr & tempstr
        Next i
        arraytohex = templatestr
    End Function

    Public Sub hextoarray(ByRef inphex As String, ByRef outarray() As Byte)
        ReDim outarray(Len(inphex) / 2)
        Dim i As Short
        For i = 1 To Len(inphex) Step 2
            outarray(((i + 1) / 2) - 1) = Val("&H" & Mid(inphex, i, 2))
        Next i
    End Sub

    Public Sub CheckVar(ByVal getData As TextBox)
        Dim var As String = getData.Text
        If IsNumeric(var) = False And var <> "" Then
            MsgBox("Hanya Boleh Berupa angka")
            getData.ResetText()
            getData.Focus()
        ElseIf var.Contains(",") Then
            MsgBox("Untuk koma gunakan tanda baca titik (.)")
            getData.ResetText()
            getData.Focus()
        End If
    End Sub

    Function SetTindakanDetail(ByVal _idTransaksi As String, ByVal _jenisTransaksi As String, ByVal _jenisKasir As String) As String
        Dim TDetailPemeriksaan As DataTable = New DataTable
        Dim DetailPemeriksaan As String = ""
        Dim TtempDetailPemeriksaan As String = ""

        If _jenisTransaksi = "LAB" Then
            TDetailPemeriksaan = ReadSQL("SELECT b.NamaTindakan FROM TransaksiLab a LEFT JOIN TransaksiLabDetail b on a.TransLabID=b.TransLabID WHERE a.translabid = '" & _idTransaksi & "'")
            For Each TRowDetailPemeriksaan As DataRow In TDetailPemeriksaan.Rows
                TtempDetailPemeriksaan = TtempDetailPemeriksaan & "" & TRowDetailPemeriksaan("NamaTindakan").ToString.Trim & ", "
            Next
        ElseIf _jenisTransaksi = "POLI" Then
            TDetailPemeriksaan = ReadSQL("SELECT b.NamaTindakan FROM TransaksiPoli a " & _
                                         "LEFT JOIN TransaksiPoliDetail b on a.TransPoliID=b.TransPoliID " & _
                                         "WHERE a.TransPoliID = '" & _idTransaksi & "' AND b.StatusPembayaran = 'PAID' AND b.Awal = " & _jenisKasir & " AND b.DeletedDate IS NULL")
            For Each TRowDetailPemeriksaan As DataRow In TDetailPemeriksaan.Rows
                TtempDetailPemeriksaan = TtempDetailPemeriksaan & "" & TRowDetailPemeriksaan("NamaTindakan").ToString.Trim & ", "
            Next
        ElseIf _jenisTransaksi = "GIGI" Then
            TDetailPemeriksaan = ReadSQL("SELECT b.NamaTindakan FROM TransaksiGigi a " & _
                                         "LEFT JOIN TransaksiGigiDetail b on a.TransGigiID=b.TransGigiID " & _
                                         "WHERE a.TransGigiID = '" & _idTransaksi & "' AND b.StatusPembayaran = 'PAID' AND b.Awal = " & _jenisKasir & " AND b.DeletedDate IS NULL")
            For Each TRowDetailPemeriksaan As DataRow In TDetailPemeriksaan.Rows
                TtempDetailPemeriksaan = TtempDetailPemeriksaan & "" & TRowDetailPemeriksaan("NamaTindakan").ToString.Trim & ", "
            Next
        ElseIf _jenisTransaksi = "DLL" Or _jenisTransaksi = "ADMIN" Then
            TDetailPemeriksaan = ReadSQL("SELECT b.NamaTindakan FROM TransaksiAdmin a LEFT JOIN TransaksiAdminDetail b on a.TransAdminID=b.TransAdminID WHERE a.TransAdminID = '" & _idTransaksi & "'")
            For Each TRowDetailPemeriksaan As DataRow In TDetailPemeriksaan.Rows
                TtempDetailPemeriksaan = TtempDetailPemeriksaan & "" & TRowDetailPemeriksaan("NamaTindakan").ToString.Trim & ", "
            Next
        End If

        If TtempDetailPemeriksaan <> "" Then DetailPemeriksaan = Strings.Left(TtempDetailPemeriksaan, TtempDetailPemeriksaan.Length - 2)

        Return DetailPemeriksaan
    End Function

    Function SetTindakanDetailRefund(ByVal NoUrut As String, ByVal NoRefund As String) As String
        Dim TDetailPemeriksaan As DataTable = New DataTable
        Dim DetailPemeriksaan As String = ""
        Dim TtempDetailPemeriksaan As String = ""

        TDetailPemeriksaan = ReadSQL("SELECT b.NamaTindakan FROM TransaksiLab a LEFT JOIN TransaksiLabDetail b on a.TransLabID=b.TransLabID WHERE RefundID = '" & NoRefund & "' AND NoUrut = '" & NoUrut & "'")
        For Each TRowDetailPemeriksaan As DataRow In TDetailPemeriksaan.Rows
            TtempDetailPemeriksaan = TtempDetailPemeriksaan & "" & TRowDetailPemeriksaan("NamaTindakan").ToString.Trim & ", "
        Next

        DetailPemeriksaan = Strings.Left(TtempDetailPemeriksaan, TtempDetailPemeriksaan.Length - 2)

        Return DetailPemeriksaan
    End Function

    Public Function ConvertToInteger(ByRef value As String) As Integer
        If String.IsNullOrEmpty(value) Then
            value = "0"
        End If

        Return Convert.ToInt32(value)
    End Function

    Function SetTindakanDetailPoli(ByVal NoUrut As String, ByVal Jenis As String) As String
        Dim TDetailPemeriksaan As DataTable = New DataTable
        Dim DetailPemeriksaan As String = ""
        Dim TtempDetailPemeriksaan As String = ""
        Dim NominalTindakan As Double = 0
        Dim NominalBayar As Double = 0
        Dim NominalTambahan As Double = 0
        Dim NominalBHP As Double = 0
        Dim PresentaseFee As Double = 0
        Dim tempNominalTindakan As Double = 0
        Dim NominalFee As Double = 0
        Dim statusBHP As Boolean = False
        Dim statusPresentase As Boolean = False
        Dim statusNominal As Boolean = False

        TDetailPemeriksaan = ReadSQL("SELECT b.NamaTindakan, b.NettBayar, c.FeeDokter, c.FeePerawat, c.JenisDokter, c.StatusBHP, c.PersentaseFeePerusahaan, c.PersentaseFeeKaryawan, c.StatusPersentaseFee, c.StatusNominalFee, c.FeePerTindakan, b.TotalBayarBHP FROM TransaksiPoli a " & _
                                     "LEFT JOIN TransaksiPoliDetail b on a.TransPoliID=b.TransPoliID " & _
                                     "LEFT JOIN MasterTindakan c on b.TindakanID = c.TindakanID " & _
                                     "LEFT JOIN TransaksiPoliBayarAwal d ON a.transpoliid = d.transpoliid " & _
                                     "LEFT JOIN transaksipolibayar e ON a.transpoliid = e.transpoliid " & _
                                     "WHERE NoUrut = '" & NoUrut & "' AND b.DeletedDate IS NULL AND c.JenisTindakan not like '%Konsul%' and c.StatusFeeTindakan = '1' and b.NettBayar > 0 and (c.JenisDokter like '%" & Jenis & "%' or c.FeePerawat > 0) AND (d.JenisBayar in ( 'TUNAI', 'DEBET', 'CARD' ) or e.JenisBayar in ( 'TUNAI', 'DEBET', 'CARD' ))")

        If TDetailPemeriksaan.Rows.Count > 0 Then
            For Each TRowDetailPemeriksaan As DataRow In TDetailPemeriksaan.Rows
                statusBHP = False
                statusPresentase = False
                statusNominal = False
                PresentaseFee = 0

                If Convert.ToInt32(TRowDetailPemeriksaan("StatusBHP")) = 1 Then statusBHP = True
                If Convert.ToInt32(TRowDetailPemeriksaan("StatusPersentaseFee")) = 1 Then statusPresentase = True
                If Convert.ToInt32(TRowDetailPemeriksaan("StatusNominalFee")) = 1 Then statusNominal = True

                If TRowDetailPemeriksaan("JenisDokter").ToString.Contains(Jenis) = True Then
                    TtempDetailPemeriksaan = TtempDetailPemeriksaan & "" & TRowDetailPemeriksaan("NamaTindakan").ToString.Trim & ", "

                    '#Step 1 - Cek BHP / Non BHP
                    If statusBHP = True Then
                        tempNominalTindakan = CDbl(TRowDetailPemeriksaan("NettBayar").ToString) - CDbl(ConvertToInteger(TRowDetailPemeriksaan("TotalBayarBHP").ToString))
                        NominalBHP = NominalBHP + CDbl(ConvertToInteger(TRowDetailPemeriksaan("TotalBayarBHP").ToString))
                    Else
                        tempNominalTindakan = CDbl(TRowDetailPemeriksaan("NettBayar").ToString)
                    End If

                    '#Step 2 - Cek Presentase
                    If statusPresentase = True Then
                        PresentaseFee = CDbl(TRowDetailPemeriksaan("PersentaseFeeKaryawan").ToString)
                        If Jenis = "Dokter" Then tempNominalTindakan = ((tempNominalTindakan - CDbl(TRowDetailPemeriksaan("FeePerawat"))) * CDbl(PresentaseFee)) / 100
                        If Jenis = "Perawat" Then tempNominalTindakan = (tempNominalTindakan * CDbl(PresentaseFee)) / 100
                    End If

                    '#Step 3 - Cek Nominal
                    If statusNominal = True Then
                        If Jenis = "Dokter" Then tempNominalTindakan = CDbl(TRowDetailPemeriksaan("FeePerTindakan").ToString) - CDbl(TRowDetailPemeriksaan("FeePerawat"))
                        If Jenis = "Perawat" Then tempNominalTindakan = CDbl(TRowDetailPemeriksaan("FeePerTindakan").ToString)
                    End If

                    NominalBayar = NominalBayar + TRowDetailPemeriksaan("NettBayar")
                    NominalTindakan = NominalTindakan + tempNominalTindakan
                End If

                If CDbl(TRowDetailPemeriksaan("FeePerawat")) > 0 And TRowDetailPemeriksaan("JenisDokter").ToString.Trim <> Jenis And Jenis = "Perawat" Then
                    If TtempDetailPemeriksaan.Contains("" & TRowDetailPemeriksaan("NamaTindakan").ToString.Trim & "") = False Then
                        TtempDetailPemeriksaan = TtempDetailPemeriksaan & "" & TRowDetailPemeriksaan("NamaTindakan").ToString.Trim & ", "
                    End If

                    NominalTambahan = NominalTambahan + CDbl(TRowDetailPemeriksaan("FeePerawat"))
                End If
            Next

            If Jenis = "Dokter" Then
                DetailPemeriksaan = Strings.Left(TtempDetailPemeriksaan, TtempDetailPemeriksaan.Length - 2) & "#" & NominalBayar & "#" & NominalTindakan & "#" & NominalBHP
            ElseIf Jenis = "Perawat" Then
                NominalTindakan = NominalTindakan + NominalTambahan
                DetailPemeriksaan = Strings.Left(TtempDetailPemeriksaan, TtempDetailPemeriksaan.Length - 2) & "#" & NominalBayar & "#" & NominalTindakan & "#" & NominalBHP
            End If
        Else
            DetailPemeriksaan = "Nothing"
        End If

        Return DetailPemeriksaan
    End Function

    Function validateEmail(ByVal emailAddress As String) As Boolean
        Dim email As New Regex("([\w-+]+(?:\.[\w-+]+)*@(?:[\w-]+\.)+[a-zA-Z]{2,7})")
        Dim Temail() As String = emailAddress.Split(",")

        If emailAddress.Contains(",") = True Then
            For i As Integer = 0 To Temail.Count - 1
                If email.IsMatch(Temail(i).ToString.Trim) Then
                    'Next
                Else
                    Return False
                End If
            Next
        Else
            If email.IsMatch(Temail(0).ToString.Trim) Then
                Return True
            Else
                Return False
            End If
        End If

        Return True
    End Function

    'Function validateNoWhatsapp(ByVal NoWhatsapp As String) As Boolean
    '    Dim Twhatsapp() As String = NoWhatsapp.Split(",")

    '    If NoWhatsapp.Contains(",") = True Then
    '        For i As Integer = 0 To Twhatsapp.Count - 1
    '            If Twhatsapp(i).ToString.Trim.Length < 9 Then
    '                MsgBox("No Whatsapp yang dimasukkan tidak valid, pastikan jumlah digit no whatsapp yang dimasukkan.", MsgBoxStyle.Critical, "Warning")
    '                Return False
    '            ElseIf Twhatsapp(i).ToString.Trim.Length > 13 Then
    '                MsgBox("No Whatsapp yang dimasukkan tidak valid, pastikan jumlah digit no whatsapp yang dimasukkan.", MsgBoxStyle.Critical, "Warning")
    '                Return False
    '            End If

    '            'Cek Awalan Format No Whatsapp
    '            If Strings.Left(Twhatsapp(i).ToString.Trim, 2) = "08" Or Strings.Left(Twhatsapp(i).ToString.Trim, 3) = "628" Then
    '                Return True
    '            Else
    '                MsgBox("No Whatsapp yang dimasukkan tidak valid, pastikan no whatsapp bukan telepon rumah atau kantor.", MsgBoxStyle.Critical, "Warning")
    '                Return False
    '            End If
    '        Next
    '    Else
    '        If NoWhatsapp.Length < 9 Then
    '            MsgBox("No Whatsapp yang dimasukkan tidak valid, pastikan jumlah digit no whatsapp yang dimasukkan.", MsgBoxStyle.Critical, "Warning")
    '            Return False
    '        ElseIf NoWhatsapp.Length > 13 Then
    '            MsgBox("No Whatsapp yang dimasukkan tidak valid, pastikan jumlah digit no whatsapp yang dimasukkan.", MsgBoxStyle.Critical, "Warning")
    '            Return False
    '        End If

    '        'Cek Awalan Format No Whatsapp
    '        If Strings.Left(NoWhatsapp, 2) = "08" Or Strings.Left(NoWhatsapp, 3) = "628" Then
    '            Return True
    '        Else
    '            MsgBox("No Whatsapp yang dimasukkan tidak valid, pastikan no whatsapp bukan telepon rumah atau kantor.", MsgBoxStyle.Critical, "Warning")
    '            Return False
    '        End If
    '    End If

    '    Return True
    'End Function

    Function validateNoWhatsapp(ByVal NoWhatsapp As String) As Boolean
        Dim Twhatsapp() As String = NoWhatsapp.Split(",")

        For i As Integer = 0 To Twhatsapp.Length - 1
            Dim nomor = Twhatsapp(i).Trim()

            ' Buang semua karakter selain angka dan +
            nomor = System.Text.RegularExpressions.Regex.Replace(nomor, "[^0-9+]", "")

            ' Jika diawali +, hilangkan + untuk validasi digit
            If nomor.StartsWith("+") Then
                nomor = nomor.Substring(1)
            End If

            ' Jika diawali dengan 0 → ubah ke 62 untuk validasi panjang dan format
            If nomor.StartsWith("0") Then
                nomor = "62" & nomor.Substring(1)
            End If

            ' Validasi panjang antara 9 dan 15 digit
            If nomor.Length < 9 OrElse nomor.Length > 15 Then
                MsgBox("No WhatsApp tidak valid. Jumlah digit harus antara 9 sampai 15.", MsgBoxStyle.Critical, "Warning")
                Return False
            End If

            ' Validasi angka semua
            If Not IsNumeric(nomor) Then
                MsgBox("No WhatsApp tidak valid. Harus berisi angka saja.", MsgBoxStyle.Critical, "Warning")
                Return False
            End If
        Next

        Return True
    End Function

    Function Umur(ByVal Tdate As DateTime) As String
        Dim Tumurhari As Integer = Math.Abs(DateDiff(DateInterval.Day, DateAndTime.Now, Tdate.Date))
        Dim Tadd, Tthn, Tbln, Thr As Integer
        Tadd = 0
        Tthn = 0
        Tbln = 0
        Thr = 0

        Do
            If (Tdate.Year + 1) Mod 4 = 0 Then
                Tadd = 366
            Else
                Tadd = 365
            End If
            Tdate = Tdate.AddDays(Tadd)
            Tthn = Tthn + 1
        Loop Until Tdate.Date > DateAndTime.Now.Date

        Tdate = Tdate.AddDays(-Tadd)
        Tthn = Tthn - 1

        Dim Tcheck As Boolean = False
        Do
            If Tdate.Month = 1 Or Tdate.Month = 3 Or Tdate.Month = 5 Or Tdate.Month = 7 Or Tdate.Month = 8 Or Tdate.Month = 10 Or Tdate.Month = 12 Then
                Tadd = 31
            ElseIf Tdate.Month = 4 Or Tdate.Month = 6 Or Tdate.Month = 9 Or Tdate.Month = 11 Then
                Tadd = 30
            ElseIf Tdate.Month = 2 Then
                If Tdate.Year Mod 4 = 0 Then Tadd = 29 Else Tadd = 28
            End If
            Tdate = Tdate.AddDays(Tadd)
            Tbln = Tbln + 1

            If Tdate.Date > DateAndTime.Now.Date Then
                Tdate = Tdate.AddDays(-Tadd)
                Tbln = Tbln - 1
                Tcheck = True
            End If

        Loop Until Tcheck = True

        While Tdate.Date.AddDays(1) < DateAndTime.Now.Date
            Tdate = Tdate.AddDays(1)
            Thr = Thr + 1
        End While

        If Tdate.Month = 1 Or Tdate.Month = 3 Or Tdate.Month = 5 Or Tdate.Month = 7 Or Tdate.Month = 8 Or Tdate.Month = 10 Or Tdate.Month = 12 Then
            Tadd = 31
        ElseIf Tdate.Month = 4 Or Tdate.Month = 6 Or Tdate.Month = 9 Or Tdate.Month = 11 Then
            Tadd = 30
        ElseIf Tdate.Month = 2 Then
            If Tdate.Year Mod 4 = 0 Then
                Tadd = 29
            Else
                Tadd = 28
            End If
        End If

        If Thr >= Tadd Then
            Tbln = Tbln + 1
            Thr = Thr - Tadd
            If Tbln >= 12 Then
                Tthn = Tthn + 1
                Tbln = Tbln - 12
            End If
        End If


        Dim Totalstring As String = Tthn & " thn " & Tbln & " bln " & Thr & " hr."
        Return Totalstring
    End Function

    Function HitungUsia(ByVal tanggalLahir As DateTime) As Integer
        Dim usia As Integer = DateTime.Today.Year - tanggalLahir.Year
        If DateTime.Today < tanggalLahir.AddYears(usia) Then
            usia -= 1
        End If
        Return usia
    End Function

    Function CheckMySQL(ByVal txt As String) As Boolean
        Try
            Dim Dttable As DataTable = PoliKlinik.dbsql.Select(txt)
            If Dttable.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            InputBox("Test", "Test", txt)
            MsgBox(ex.Message)
            Return False
        End Try

    End Function

    Private _Kamus As SortedDictionary(Of Integer, String)
    Private _ArGroup() As String = {"", " Ribu", " Juta", " Milyar", " Triliun"}

    Private Sub InitializeKamus()
        _Kamus = New SortedDictionary(Of Integer, String)
        _Kamus.Clear()
        _Kamus.Add(0, "")
        _Kamus.Add(1, " Satu")
        _Kamus.Add(2, " Dua")
        _Kamus.Add(3, " Tiga")
        _Kamus.Add(4, " Empat")
        _Kamus.Add(5, " Lima")
        _Kamus.Add(6, " Enam")
        _Kamus.Add(7, " Tujuh")
        _Kamus.Add(8, " Delapan")
        _Kamus.Add(9, " Sembilan")
        _Kamus.Add(10, " Sepuluh")
        _Kamus.Add(11, " Sebelas")
        _Kamus.Add(100, " Seratus")
    End Sub

    Public Function Terbilang(ByVal Bilangan As Double) As String
        Dim sRet As String = ""
        Dim sMinus As String = ""
        Dim BilCacah As Double = 0
        Dim BilPecahan As Integer = 0


        InitializeKamus()

        Try
            If Bilangan < 0 Then sMinus = "Minus "

            Dim grp() As String = Split(Math.Abs(Bilangan).ToString(System.Globalization.NumberFormatInfo.CurrentInfo), System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator)
            If grp.Length > 1 Then
                BilCacah = CDbl(grp(0))
                BilPecahan = CInt(grp(1))
            Else
                BilCacah = Bilangan
            End If

            Dim triple() As String = Split(BilCacah.ToString("#,##0", System.Globalization.NumberFormatInfo.CurrentInfo), System.Globalization.NumberFormatInfo.CurrentInfo.NumberGroupSeparator)
            Array.Reverse(triple)

            For i As Integer = triple.Length - 1 To 0 Step -1
                sRet = sRet & BacaGroupAngka(triple(i), False, IIf(i > 5, i - 5 + 1, i))
            Next

            If BilPecahan > 0 Then
                sRet = sRet & " Koma" & BacaGroupAngka(BilPecahan, True)
            End If

            sRet = sMinus & sRet

        Catch ex As Exception
            MsgBox(ex.Message, vbOKOnly, "Parsing Bilangan")

        End Try

        _Kamus.Clear()
        _Kamus = Nothing

        Return sRet.Trim
    End Function

    Private Function BacaGroupAngka(ByVal Angka As Integer, _
                                    Optional ByVal IsPecahan As Boolean = False, _
                                    Optional ByVal iGroup As Byte = 0) As String
        Dim sRet As String = ""
        Dim sAngka As String = Angka.ToString("000")

        Select Case IsPecahan
            Case True
                Try
                    For i As Integer = 0 To sAngka.Length - 1
                        If CInt(sAngka.Substring(i, 1)) = 0 Then
                            sRet = sRet & "Nol"
                        Else
                            sRet = sRet & _Kamus(CInt(sAngka.Substring(i, 1)))
                        End If
                    Next
                Catch ex As Exception
                    MsgBox(ex.Message, vbOKOnly, "Baca Pecahan")
                End Try
            Case Else
                Try
                    If Angka = 1 And iGroup = 1 Then
                        sRet = " Seribu"
                    ElseIf _Kamus.ContainsKey(Angka) Then
                        sRet = _Kamus(Angka) & _ArGroup(iGroup)
                    Else
                        Dim Satuan As String = _Kamus(CInt(sAngka.Substring(2, 1)))
                        Dim puluhan As String = ""
                        Dim ratusan As String = ""

                        If _Kamus.ContainsKey(CInt(sAngka.Substring(1, 2))) Then
                            puluhan = _Kamus(CInt(sAngka.Substring(1, 2)))
                        Else
                            If CInt(sAngka.Substring(1, 1)) = 0 Then
                                puluhan = Satuan
                            ElseIf CInt(sAngka.Substring(1, 1)) = 1 Then
                                puluhan = Satuan & " Belas"
                            Else
                                puluhan = _Kamus(CInt(sAngka.Substring(1, 1))) & " Puluh" & Satuan
                            End If
                        End If

                        If CInt(sAngka.Substring(0, 1)) = 0 Then
                            ratusan = puluhan
                        ElseIf CInt(sAngka.Substring(0, 1)) = 1 Then
                            ratusan = " Seratus" & puluhan
                        Else
                            ratusan = _Kamus(CInt(sAngka.Substring(0, 1))) & " Ratus" & puluhan
                        End If

                        sRet = ratusan & _ArGroup(iGroup)
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message, vbOKOnly, "Baca Bilangan Bulat")
                End Try
        End Select

        Return sRet
    End Function

    Function ReadMySQL(ByVal Txt As String) As DataTable
        Dim Dttable As New DataTable
        Try
            Dttable = PoliKlinik.dbsql.Select(Txt)
            Return Dttable
        Catch ex As Exception
            InputBox("Test", "Test", Txt)
            MsgBox(ex.Message)
            Return Dttable
        End Try
    End Function

    Function ReadMySQLNIK(ByVal Txt As String) As String
        Dim Dttable As New DataTable
        Try
            Dttable = PoliKlinik.dbsql.Select(Txt)
            If Dttable.Rows.Count > 0 Then
                Dim Trow As DataRow = Dttable.Rows(Dttable.Rows.Count - 1)
                Return Trow(0).ToString
            Else
                Return "-"
            End If
        Catch ex As Exception
            InputBox("Test", "Test", Txt)
            MsgBox(ex.Message)
            Return "-"
        End Try
    End Function

    Public Sub WriteMySQL(ByVal Txt As String, ByRef Txtype As Integer)
        Try
            PoliKlinik.dbsql.Execute(Txt)
            If Txtype = 1 Then
                MsgBox("Data Saved")
            ElseIf Txtype = 2 Then
                MsgBox("Data Updated")
            ElseIf Txtype = 3 Then
                MsgBox("Data Deleted")
            ElseIf Txtype = 4 Then
                'continue without reason
            Else
                MsgBox("...")
            End If
        Catch ex As Exception
            InputBox("Test", "Test", Txt)
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub InsertMySqlNewItemComboSQL(ByVal Str As String, ByVal Cmbdata As System.Windows.Forms.ComboBox)
        Dim Dttable As New DataTable
        Cmbdata.Items.Clear()
        Try
            Dttable = PoliKlinik.dbsql.Select(Str)
            For Each Trow As DataRow In Dttable.Rows
                Cmbdata.Items.Add(Trow(0).ToString)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub 'query di mysql ambil data untuk masing-masing combo

    Function CheckMaximum(ByRef Ttable As DataTable) As Boolean
        If Ttable.Rows.Count > 0 Then
            Dim Ttbls As DataTable = Ttable

            For Each Trow As DataRow In Ttable.Rows
                'If Trow("DiscTindakan") > 20 Or Trow("NettBayar") = 0 Then
                '    Return False
                '    Exit Function
                'End If
            Next
        End If

        Return True
    End Function

    '    Public Sub ExportDataToExcel(ByVal Tdata As DevExpress.XtraGrid.GridControl)
    'ToA:
    '        Dim Tsave As New SaveFileDialog

    '        Tsave.Filter = "Excel File|*.xls"
    '        Tsave.Title = "Save an Excel File"
    '        Tsave.ShowDialog()

    '        If Tsave.FileName <> "" Then
    '            If IO.File.Exists(Tsave.FileName) Then
    '                MsgBox("Telah ada file dengan nama tersebut. Ganti dengan nama lain.", MsgBoxStyle.Critical, "Warning")
    '                GoTo ToA
    '            Else
    '                Tdata.ExportToExcel(Tsave.FileName)
    '                MsgBox("Berhasil menyimpan file excel " & Tsave.FileName.ToString, MsgBoxStyle.Information, "Success!")
    '            End If
    '        Else
    '            If MsgBox("Filename harus diisi. Save ulang ?", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
    '                GoTo ToA
    '            End If
    '        End If
    '    End Sub

    Public Sub ExportDataToExcel(ByVal Tdata As DevExpress.XtraGrid.GridControl)
        Dim Tsave As New SaveFileDialog()

        Tsave.Filter = "Excel File|*.xls"
        Tsave.Title = "Save an Excel File"

        If Tsave.ShowDialog() = DialogResult.OK Then
            Try
                If IO.File.Exists(Tsave.FileName) Then
                    MsgBox("Sudah ada file dengan nama tersebut. Ganti dengan nama lain.", MsgBoxStyle.Critical, "Warning")
                Else
                    Tdata.ExportToExcel(Tsave.FileName)
                    MsgBox("Berhasil menyimpan file excel " & Tsave.FileName.ToString(), MsgBoxStyle.Information, "Success!")
                End If
            Catch ex As Exception
                MsgBox("Terjadi kesalahan saat menyimpan file: " & ex.Message, MsgBoxStyle.Critical, "Error")
            End Try
        Else
            MsgBox("Nama file harus diisi. Save ulang ?", MsgBoxStyle.Information, "Warning")
        End If
    End Sub

    Function InsertLabeltoReport(ByVal Tnama As String, ByVal Tjenisfont As String, ByVal Tfontsize As Integer, ByVal Tbool As Boolean, ByVal Posx As Integer, ByVal Posy As Integer, ByVal Tsizex As Integer, ByVal Tsizey As Integer) As XRLabel
        Dim Xlabel As New XRLabel
        Xlabel.Text = Tnama
        Xlabel.Location = New Point(Posx, Posy)
        Xlabel.Size = New Size(Tsizex, Tsizey)
        If Tbool = True Then Xlabel.Font = New Font("Times New Roman", Tfontsize, FontStyle.Bold, GraphicsUnit.Point) Else Xlabel.Font = New Font("Times New Roman", 25, FontStyle.Regular, GraphicsUnit.Point)
        Return Xlabel
    End Function

    Function Gelar(ByVal Tumur As Integer, ByVal Tsex As String) As String
        Dim Tx As String = ""
        If Tumur <= 17 Then
            Tx = "An. "
        Else
            If Tsex.ToString = "L" Then
                Tx = "Bpk. "
            ElseIf Tsex.ToString = "P" Then
                Tx = "Ibu "
            Else
                'MsgBox("Jenis Kelamin blm ter-set. Update sesuai sehingga panggilan bisa terisi")
                Tx = "Sdr. "
            End If

        End If
        Return Tx
    End Function

    Public Function BulanIndonesia(ByVal month As String)
        Dim VarBulan As String = ""

        If IsNumeric(month) = True And month.Contains("0") = True Then
            VarBulan = Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(month, "01", "Januari"), "02", "Februari"), "03", "Maret"), "04", "April"), "05", "Mei"), "06", "Juni"), "07", "Juli"), "08", "Agustus"), "09", "September"), "10", "Oktober"), "11", "November"), "12", "Desember")
        ElseIf IsNumeric(month) = True And month.Contains("0") = False Then
            VarBulan = Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(month, "12", "Desember"), "11", "November"), "10", "Oktober"), "9", "September"), "8", "Agustus"), "7", "Juli"), "6", "Juni"), "5", "Mei"), "4", "April"), "3", "Maret"), "2", "Februari"), "1", "Januari")
        Else
            VarBulan = Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(month, "January", "Januari"), "February", "Februari"), "March", "Maret"), "April", "April"), "May", "Mei"), "June", "Juni"), "July", "Juli"), "August", "Agustus"), "September", "September"), "October", "Oktober"), "November", "November"), "December", "Desember")
        End If

        Return VarBulan
    End Function

    Function HardcopyCompany(ByVal TranslabID As String, ByVal JenisData As String) As Boolean
        Dim Tcompany As String = ""
        If JenisData = "Offline" Then
            Tcompany = ReadSQLNIK("SELECT NoJenisBayar FROM transaksilabbayar WHERE JenisBayar = 'TAGIHAN' and TransLabID in (SELECT TransLabID FROM TransaksiLab WHERE TransLabID = '" & TranslabID & "' and CaraAmbil not like '%Ambil Sendiri%')")
        ElseIf JenisData = "Online" Then
            ' Set Parameter Server Online
            Dim serverOnline_IP As String = Utility.GetConfig("ServerOnline_IP")
            Dim serverOnline_UserID As String = Utility.GetConfig("ServerOnline_UserID")
            Dim serverOnline_Password As String = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerOnline_Password"), "albert")

            ' Set DB Poliklinik
            DB_Poliklinik.Tip = serverOnline_IP
            DB_Poliklinik.Tid = serverOnline_UserID
            DB_Poliklinik.Tpass = serverOnline_Password
            DB_Poliklinik.Tdb = Utility.GetConfig("ServerOnlinePoli_DB")

            Tcompany = ReadThemysqlNIK("SELECT NoJenisBayar FROM transaksilabbayar WHERE JenisBayar = 'TAGIHAN' and idlabinternet in (SELECT idlabinternet FROM transaksilab WHERE idlabinternet = '" & TranslabID & "' and CaraAmbil not like '%Ambil Sendiri%')", DB_Poliklinik)
        End If

        Dim Tsplit() As String = Tcompany.ToString.Split("-")
        Dim Tcheck As DataTable = ReadSQL("SELECT * FROM MasterCompany WHERE NoCompany = '" & Trim(Tsplit(1)) & "'")

        If Tcheck.Rows.Count > 0 Then
            Dim Trowcheck As DataRow = Tcheck.Rows(0)
            If Trowcheck("HardcopyPerusahaan") = False And Trowcheck("TerimaHasilKaryawan") = False Then
                Return False
            End If
        End If

        Return True
    End Function

    Public Sub SetFormHeightWeight(ByVal xForm As Form, ByVal x As Double, ByVal y As Double)
        Dim y_ As Integer = Screen.PrimaryScreen.Bounds.Height * 0.025
        Dim x_ As Integer = Screen.PrimaryScreen.Bounds.Width * 0.025
        xForm.Location = New Point(x_, y_)
        xForm.Width = Screen.PrimaryScreen.Bounds.Width * x
        xForm.Height = Screen.PrimaryScreen.Bounds.Height * y
        xForm.MinimumSize = New System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width * x, Screen.PrimaryScreen.Bounds.Height * y)
        xForm.MaximumSize = New System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width * x, Screen.PrimaryScreen.Bounds.Height * y)
        xForm.Size = New System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width * x, Screen.PrimaryScreen.Bounds.Height * y)
        xForm.MaximizeBox = False
        xForm.StartPosition = FormStartPosition.CenterParent
    End Sub

    Public Function ViewData(ByVal uri As String) As String
        Dim str As String = ""

        Try
            'REQUEST GET METHOD
            Dim webreq As HttpWebRequest = WebRequest.Create(uri)

            webreq.Accept = "application/json"
            webreq.Headers("Authorization") = "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6ImRhbmlmd2FoeXVkaUBnbWFpbC5jb20iLCJpYXQiOjE2NjI1MzEwOTEsImV4cCI6MTY2MjUzNDY5MX0.dnEK-_ylbcJ_akKlulupuKO8jzAWYjJgkiZibFvSeNY"
            webreq.Method = "GET"

            Dim res As WebResponse = webreq.GetResponse()
            Dim stream As Stream = res.GetResponseStream()
            Dim streamReader As New StreamReader(stream)

            'READ RESPONSE
            str = streamReader.ReadToEnd
            streamReader.Close()

            str = "[" + str + "]"

            Return str
        Catch ex As Exception
            Return "Nothing"
        End Try
    End Function

    Public Function viewDataWithParams(ByVal parameter As String, ByVal uri As String) As String

        Try
            Dim bytearr() As Byte = Encoding.UTF8.GetBytes(parameter)
            Dim str As String = ""

            Dim webreq As HttpWebRequest = WebRequest.Create(uri)
            webreq.Accept = "application/json"

            webreq.Method = "POST"
            webreq.ContentType = "application/json"
            webreq.ContentLength = bytearr.Length

            Dim dataStream As Stream = webreq.GetRequestStream()
            dataStream.Write(bytearr, 0, bytearr.Length)
            dataStream.Close()

            Dim res As WebResponse = webreq.GetResponse()
            Dim stream As Stream = res.GetResponseStream()
            Dim streamReader As New StreamReader(stream)

            'READ RESPONSE
            str = streamReader.ReadToEnd
            streamReader.Close()

            str = "[" + str + "]"

            Return str
        Catch ex As Exception
            Return "Nothing"
        End Try
    End Function

    Public Function GetCurrentAge(ByVal dob As Date) As Integer
        Dim age As Integer
        age = Today.Year - dob.Year
        If (dob > Today.AddYears(-age)) Then age -= 1
        Return age
    End Function

    Public Function GetDataBPJSv4(ByVal uri As String) As String
        Dim consID As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_consid'")
        Dim secretKey = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_secret_key'")
        Dim pcareUname = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_username'")
        Dim pcarePWD = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_password'")
        Dim kdAplikasi = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_kode_aplikasi'")
        Dim userKey = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_user_key'")

        Dim keyword = ""
        Dim var As Collection
        var = New Collection

        Dim tgl As Integer = ((DateTime.UtcNow - Convert.ToDateTime("1970-01-01 00:00:00")).TotalSeconds())
        Dim stamp As String = tgl.ToString()

        Dim data As String = consID + "&" + stamp
        Dim data2 As String = pcareUname + ":" + pcarePWD + ":" + kdAplikasi
        Dim encodedSignature As String = HashString(data, secretKey)

        'Authorization
        Dim Authorization = System.Text.Encoding.UTF8.GetBytes(data2)
        Dim encodedAuthorization = Convert.ToBase64String(Authorization)

        Dim str As String = ""

        Try
            ServicePointManager.ServerCertificateValidationCallback = Function(sender, certificate, chain, sslPolicyErrors) True

            'REQUEST GET METHOD
            Dim webreq As HttpWebRequest = WebRequest.Create(uri)

            webreq.Accept = "application/json"
            webreq.Headers("X-cons-id") = consID
            webreq.Headers("X-timestamp") = stamp
            webreq.Headers("X-signature") = encodedSignature
            webreq.Headers("X-authorization") = "Basic " + encodedAuthorization
            webreq.Headers("user_key") = userKey
            webreq.Method = "GET"

            'Keyword untuk compres lz string
            keyword = consID & secretKey & stamp

            Dim res As WebResponse = webreq.GetResponse()
            Dim stream As Stream = res.GetResponseStream()
            Dim streamReader As New StreamReader(stream)

            'READ RESPONSE
            str = streamReader.ReadToEnd
            streamReader.Close()

            str = "[" + str + "]"

            Dim response As String = GetResponse(str, keyword)

            Return response
        Catch ex As Exception
            MsgBox(ex.Message)
            Return "Nothing"
        Finally
            ServicePointManager.ServerCertificateValidationCallback = Nothing
            'Catch ex As WebException
            '    MsgBox("1 - " & ex.Message)
            '    Dim responseStream As Stream = ex.Response.GetResponseStream()

            '    Dim reader As New StreamReader(responseStream)
            '    Dim responseError As String = reader.ReadToEnd()

            '    reader.Close()
            '    responseStream.Close()

            '    'responseError = "[" + responseError + "]"

            '    responseError = generateResponse(responseError, keyword)

            '    MsgBox(responseError)

            '    Return responseError
        End Try
    End Function

    Public Function GetOnlineTime() As DateTime
        Try
            Dim uri As String = "https://worldtimeapi.org/api/timezone/UTC"
            Dim request As WebRequest = WebRequest.Create(uri)
            Dim response As WebResponse = request.GetResponse()

            Using dataStream As Stream = response.GetResponseStream()
                Using reader As New StreamReader(dataStream)
                    Dim jsonResponse As String = reader.ReadToEnd()
                    Dim timestamp As Long = CLng(Json.JsonConvert.DeserializeObject(Of Dictionary(Of String, Object))(jsonResponse)("unixtime"))
                    Dim networkTime As DateTime = (New DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).AddSeconds(timestamp)

                    Return networkTime
                End Using
            End Using
        Catch ex As Exception
            ' Handle exception as needed
            Return DateTime.MinValue
        End Try
    End Function

    Public Function DeleteDataBPJSv4(ByVal uri As String) As String
        Dim consID As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_consid'")
        Dim secretKey = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_secret_key'")
        Dim pcareUname = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_username'")
        Dim pcarePWD = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_password'")
        Dim kdAplikasi = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_kode_aplikasi'")
        Dim userKey = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_user_key'")

        Dim keyword = ""
        Dim var As Collection
        var = New Collection

        Dim tgl As Integer = ((DateTime.UtcNow - Convert.ToDateTime("1970-01-01 00:00:00")).TotalSeconds())
        Dim stamp As String = tgl.ToString()

        Dim data As String = consID + "&" + stamp
        Dim data2 As String = pcareUname + ":" + pcarePWD + ":" + kdAplikasi
        Dim encodedSignature As String = HashString(data, secretKey)

        'Authorization
        Dim Authorization = System.Text.Encoding.UTF8.GetBytes(data2)
        Dim encodedAuthorization = Convert.ToBase64String(Authorization)

        Dim str As String = ""

        Try
            'REQUEST GET METHOD
            Dim webreq As HttpWebRequest = WebRequest.Create(uri)

            webreq.Accept = "application/json"
            webreq.Headers("X-cons-id") = consID
            webreq.Headers("X-timestamp") = stamp
            webreq.Headers("X-signature") = encodedSignature
            webreq.Headers("X-authorization") = "Basic " + encodedAuthorization
            webreq.Headers("user_key") = userKey
            webreq.Method = "DELETE"

            'Keyword untuk compres lz string
            keyword = consID & secretKey & stamp

            Dim res As WebResponse = webreq.GetResponse()
            Dim stream As Stream = res.GetResponseStream()
            Dim streamReader As New StreamReader(stream)

            'READ RESPONSE
            str = streamReader.ReadToEnd
            streamReader.Close()

            str = "[" + str + "]"

            Dim response As String = GetResponse(str, keyword)

            Return response
        Catch ex As Exception
            Return "Nothing"
        End Try
    End Function

    Public Function GetResponse(ByVal str As String, ByVal keyword As String) As String
        Dim resp As String = ""
        Dim metaDataMessage As String = ""
        Dim metaDataCode As String = ""
        Dim varses() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of varJson())(str)

        For Each oneVar As varJson In varses
            If oneVar IsNot Nothing Then
                resp = oneVar.response
                metaDataMessage = oneVar.metaData.message
                metaDataCode = oneVar.metaData.code
            End If
        Next

        Dim parameter As String = "{" & _
                              """nilaiResponse"" : """ & resp & """," & _
                              """nilaiKeywords"" : """ & keyword & """" & _
                             "}"

        Dim response As String = generateLZString(parameter, "application/json", "POST")

        response = "{" & _
                    """response"" : " & response & "," & _
                    """metaData"" : {" & _
                    """message"" : """ & metaDataMessage & """," & _
                    """code"": " & metaDataCode & "" & _
                    "}}"

        Return "[" + response + "]"
    End Function

    Public Function InsertOrUpdateDataBPJSv4(ByVal parameter As String, ByVal uri As String, ByVal method As String) As String
        Dim bytearr() As Byte = Encoding.UTF8.GetBytes(parameter)

        Dim consID As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_consid'")
        Dim secretKey = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_secret_key'")
        Dim pcareUname = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_username'")
        Dim pcarePWD = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_password'")
        Dim kdAplikasi = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_kode_aplikasi'")
        Dim userKey = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_user_key'")

        Dim keyword = ""

        Dim tgl As Integer = ((DateTime.UtcNow - Convert.ToDateTime("1970-01-01 00:00:00")).TotalSeconds())
        Dim stamp As String = tgl.ToString()

        Dim data As String = consID + "&" + stamp
        Dim data2 As String = pcareUname + ":" + pcarePWD + ":" + kdAplikasi
        Dim encodedSignature As String = HashString(data, secretKey)

        'Authorization
        Dim Authorization = System.Text.Encoding.UTF8.GetBytes(data2)
        Dim encodedAuthorization = Convert.ToBase64String(Authorization)

        Dim str As String = ""

        Try
            'REQUEST GET METHOD
            Dim webreq As HttpWebRequest = WebRequest.Create(uri)

            webreq.Accept = "application/json"
            webreq.Headers("X-cons-id") = consID
            webreq.Headers("X-timestamp") = stamp
            webreq.Headers("X-signature") = encodedSignature
            webreq.Headers("X-authorization") = "Basic " + encodedAuthorization
            webreq.Headers("user_key") = userKey

            webreq.Method = method
            webreq.ContentType = "text/plain"
            webreq.ContentLength = bytearr.Length

            Dim dataStream As Stream = webreq.GetRequestStream()
            dataStream.Write(bytearr, 0, bytearr.Length)
            dataStream.Close()

            'Keyword untuk compres lz string
            keyword = consID & secretKey & stamp

            Dim res As WebResponse = webreq.GetResponse()
            Dim stream As Stream = res.GetResponseStream()
            Dim streamReader As New StreamReader(stream)

            'READ RESPONSE
            str = streamReader.ReadToEnd
            streamReader.Close()

            Dim responseSuccess As String = ""

            If method = "POST" Then
                responseSuccess = generateResponse(str, keyword)
            ElseIf method = "PUT" Then
                'responseSuccess = "[" + str + "]"
                responseSuccess = str
            End If

            Return responseSuccess
        Catch ex As WebException
            Dim responseStream As Stream = ex.Response.GetResponseStream()

            Dim reader As New StreamReader(responseStream)
            Dim responseError As String = reader.ReadToEnd()

            reader.Close()
            responseStream.Close()

            'responseError = "[" + responseError + "]"

            responseError = generateResponse(responseError, keyword)

            Return responseError
        End Try
    End Function

    Public Function generateResponse(ByVal str As String, ByVal keyword As String) As String
        Try
            Dim resp As String = ""
            Dim metaDataMessage As String = ""
            Dim metaDataCode As String = ""
            Dim stringJson As String = "[" + str + "]"

            Dim varses() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of varJson())(stringJson)

            For Each oneVar As varJson In varses
                If oneVar IsNot Nothing Then
                    resp = oneVar.response
                    metaDataMessage = oneVar.metaData.message
                    metaDataCode = oneVar.metaData.code
                End If
            Next

            Dim parameter As String = "{" & _
                                  """nilaiResponse"" : """ & resp & """," & _
                                  """nilaiKeywords"" : """ & keyword & """" & _
                                 "}"

            Dim response As String = generateLZString(parameter, "application/json", "POST")



            response = "{" & _
                        """response"" : " & response & "," & _
                        """metaData"" : {" & _
                        """message"" : """ & metaDataMessage & """," & _
                        """code"": " & metaDataCode & "" & _
                        "}}"

            Return response
        Catch ex As Exception
            Return str
        End Try
    End Function

    Public Function IsConnectedToIPAddress(ByVal ipAddress As String) As Boolean
        Try
            'Membuat objek Ping untuk memeriksa koneksi
            Dim pingObj As New Ping()

            'Mengecek host yang akan di ping
            Dim pingReply As PingReply = pingObj.Send(ipAddress)

            'Jika status koneksi sukses, maka nilai return True
            If pingReply.Status = IPStatus.Success Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            'Jika terjadi exception atau error, maka nilai return False
            Return False
        End Try
    End Function

    Public Function IsComboBoxItemValid(ByVal comboBoxName As System.Windows.Forms.ComboBox) As Boolean
        Dim inputText As String = comboBoxName.Text.ToLower()

        ' Cek apakah input teks ada dalam daftar item ComboBox
        For Each item As String In comboBoxName.Items
            If item.ToLower() = inputText Then
                Return True
            End If
        Next

        Return False
    End Function

    Public Function GetDataAPIRM(ByVal uri As String) As String
        Try
            Dim webreq As HttpWebRequest = CType(WebRequest.Create(uri), HttpWebRequest)

            webreq.Accept = "application/json"
            webreq.Method = "GET"
            webreq.ContentType = "application/json"
            webreq.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64)"
            webreq.Headers.Add("X-API-KEY", "M1tR4M3D1c@rECaH4Y42025")

            webreq.Timeout = 300000
            webreq.ReadWriteTimeout = 300000

            Dim res As WebResponse = webreq.GetResponse()

            Using stream As Stream = res.GetResponseStream()
                Using reader As New StreamReader(stream)
                    Return reader.ReadToEnd()
                End Using
            End Using

        Catch ex As WebException

            If ex.Response IsNot Nothing Then
                Using responseStream As Stream = ex.Response.GetResponseStream()
                    Using reader As New StreamReader(responseStream)
                        Return reader.ReadToEnd()
                    End Using
                End Using
            Else
                ' JSON error agar tetap bisa di-parse
                Return "{""status"":""error"",""message"":""" & ex.Message & """}"
            End If

        End Try
    End Function

    Public Function InsertDataAPIRM(ByVal parameter As String, ByVal uri As String) As String
        Dim bytearr() As Byte = Encoding.UTF8.GetBytes(parameter)
        Try
            Dim webreq As HttpWebRequest = WebRequest.Create(uri)
            webreq.Accept = "application/json"
            webreq.Method = "POST"
            webreq.ContentType = "application/json"
            webreq.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64)"
            webreq.Headers.Add("X-API-KEY", "M1tR4M3D1c@rECaH4Y42025")
            webreq.ContentLength = bytearr.Length

            Using dataStream As Stream = webreq.GetRequestStream()
                dataStream.Write(bytearr, 0, bytearr.Length)
            End Using

            Dim res As WebResponse = webreq.GetResponse()
            Using stream As Stream = res.GetResponseStream()
                Using streamReader As New StreamReader(stream)
                    Return streamReader.ReadToEnd()
                End Using
            End Using

        Catch ex As WebException
            If ex.Response IsNot Nothing Then
                Using responseStream As Stream = ex.Response.GetResponseStream()
                    Using reader As New StreamReader(responseStream)
                        Return reader.ReadToEnd() ' <-- jangan bungkus pakai [ ]
                    End Using
                End Using
            Else
                ' Buat JSON error agar tetap bisa di-parse
                Return "{""status"":""error"",""message"":""" & ex.Message & """}"
            End If
        End Try
    End Function

    Private Function GenerateSignature(ByVal data As String, ByVal apiKey As String) As String
        Dim raw As String = data & apiKey
        Dim bytes As Byte() = Encoding.UTF8.GetBytes(raw)

        Using sha As SHA256 = SHA256.Create()
            Dim hash As Byte() = sha.ComputeHash(bytes)
            Return BitConverter.ToString(hash).Replace("-", "").ToLower()
        End Using
    End Function

    Public Function InsertDataAPIRMEncrypt(ByVal json As String, ByVal url As String) As String
        Try
            Dim client As New Net.WebClient()
            client.Encoding = Encoding.UTF8

            Dim API_KEY As String = "M1tR4M3D1c@rECaH4Y42025"
            Dim encrypted As String = Newtonsoft.Json.Linq.JObject.Parse(json)("payload").ToString()

            Dim signature As String = GenerateSignature(encrypted, API_KEY)

            client.Headers.Clear()
            client.Headers.Add("Content-Type", "application/json")
            client.Headers.Add("Accept", "application/json")
            client.Headers.Add("X-API-KEY", API_KEY)
            client.Headers.Add("X-SIGNATURE", signature)
            client.Headers.Add("User-Agent", "PostmanRuntime/7.36.0")

            Dim response As String = client.UploadString(url, "POST", json)

            Return response

        Catch ex As WebException
            If ex.Response IsNot Nothing Then
                Using sr As New StreamReader(ex.Response.GetResponseStream())
                    Return sr.ReadToEnd()
                End Using
            End If

            Return "{""metaData"":{""code"":500},""message"":""" & ex.Message & """}"
        End Try
    End Function

    Public Function SendPOST(ByVal apiUrl As String, ByVal postData As String) As String
        Try
            Dim req As Net.HttpWebRequest = CType(Net.WebRequest.Create(apiUrl), Net.HttpWebRequest)
            req.Method = "POST"
            req.ContentType = "application/x-www-form-urlencoded"

            Dim dataBytes As Byte() = System.Text.Encoding.UTF8.GetBytes(postData)
            req.ContentLength = dataBytes.Length

            Using stream = req.GetRequestStream()
                stream.Write(dataBytes, 0, dataBytes.Length)
            End Using

            Dim resp As Net.HttpWebResponse = CType(req.GetResponse(), Net.HttpWebResponse)
            Dim reader As New IO.StreamReader(resp.GetResponseStream())
            Return reader.ReadToEnd()

        Catch ex As Exception
            Return "Error: " & ex.Message
        End Try
    End Function


    Public Function InsertDataAPI(ByVal parameter As String, ByVal uri As String) As String
        Dim bytearr() As Byte = Encoding.UTF8.GetBytes(parameter)
        Dim str As String = ""
        'MsgBox(parameter)
        Try
            'MsgBox("DEBUG - URL: " & uri & vbCrLf & vbCrLf & "Parameter JSON:" & vbCrLf & parameter, MsgBoxStyle.Information, "DEBUG REQUEST")

            ' FIX: pakai TLS 1.2
            'ServicePointManager.Expect100Continue = True
            'System.Net.ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType) ' TLS 1.2
            'ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType) ' TLS 1.2
            'System.Net.ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType) _
            '                         Or CType(768, SecurityProtocolType) _
            '                         Or CType(192, SecurityProtocolType)


            'REQUEST GET METHOD
            Dim webreq As HttpWebRequest = WebRequest.Create(uri)
            webreq.Accept = "application/json"
            webreq.Method = "POST"
            webreq.ContentType = "application/json"
            webreq.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64)"
            webreq.ContentLength = bytearr.Length

            webreq.Headers.Add("Accept-Language", "en-US,en;q=0.9")
            webreq.Headers.Add("Cache-Control", "no-cache")
            webreq.KeepAlive = True


            Dim dataStream As Stream = webreq.GetRequestStream()
            dataStream.Write(bytearr, 0, bytearr.Length)
            dataStream.Close()

            Dim res As WebResponse = webreq.GetResponse()
            Dim stream As Stream = res.GetResponseStream()
            Dim streamReader As New StreamReader(stream)

            'READ RESPONSE
            str = streamReader.ReadToEnd
            streamReader.Close()

            Dim responseSuccess As String = "[" + str + "]"

            ' --- Debug: tampilkan response sukses ---
            'MsgBox("DEBUG - Response Success:" & vbCrLf & responseSuccess, MsgBoxStyle.Information, "DEBUG RESPONSE")

            Return responseSuccess
            'Catch ex As Exception
            '    Return "Nothing"
            'Catch ex As WebException
            '    Dim responseStream As Stream = ex.Response.GetResponseStream()

            '    Dim reader As New StreamReader(responseStream)
            '    Dim responseError As String = reader.ReadToEnd()

            '    reader.Close()
            '    responseStream.Close()

            '    responseError = "[" + responseError + "]"

            '    Return responseError
            'End Try
        Catch ex As WebException
            If ex.Response IsNot Nothing Then
                Using responseStream As Stream = ex.Response.GetResponseStream()
                    Using reader As New StreamReader(responseStream)
                        Dim responseError As String = reader.ReadToEnd()
                        ' --- Debug: tampilkan response error ---
                        'MsgBox("DEBUG - Response Error:" & vbCrLf & responseError, MsgBoxStyle.Critical, "DEBUG ERROR")
                        Return "[" & responseError & "]"
                    End Using
                End Using
            Else
                ' --- Debug: tampilkan pesan exception ---
                'MsgBox("DEBUG - Exception:" & vbCrLf & ex.Message, MsgBoxStyle.Critical, "DEBUG EXCEPTION")

                Return "[{""error"":""" & ex.Message & """}]"
            End If
        End Try
        'Catch ex As WebException
        '    Dim errorMsg As String = "Message: " & ex.Message & vbCrLf

        '    If ex.Response IsNot Nothing Then
        '        errorMsg &= "Status Code: " & CType(ex.Response, HttpWebResponse).StatusCode & vbCrLf

        '        Using reader As New StreamReader(ex.Response.GetResponseStream())
        '            Dim responseError As String = reader.ReadToEnd()
        '            errorMsg &= "Response Error: " & responseError
        '        End Using
        '    End If

        '    ' tampilkan log supaya tahu errornya apa
        '    MsgBox(errorMsg, MsgBoxStyle.Critical, "DEBUG ERROR")
        '    Return "[{""error"":""" & errorMsg & """}]"
        'End Try
    End Function

    Public Function GetDataAPI(ByVal uri As String) As String
        Try
            Dim responseSuccess As String = ""

            ' REQUEST GET METHOD
            Dim webreq As HttpWebRequest = WebRequest.Create(uri)

            webreq.Accept = "application/json"
            webreq.Method = "GET"

            Dim res As WebResponse = webreq.GetResponse()
            Dim stream As Stream = res.GetResponseStream()
            Dim streamReader As New StreamReader(stream)

            ' READ RESPONSE
            responseSuccess = streamReader.ReadToEnd()
            streamReader.Close()

            Return responseSuccess
        Catch ex As WebException
            Dim responseStream As Stream = ex.Response.GetResponseStream()

            Dim reader As New StreamReader(responseStream)
            Dim responseError As String = reader.ReadToEnd()

            reader.Close()
            responseStream.Close()

            Return responseError
        End Try
        'Catch ex As WebException
        '    Dim errorMsg As String = "Message: " & ex.Message & vbCrLf

        '    If ex.Response IsNot Nothing Then
        '        errorMsg &= "Status Code: " & CType(ex.Response, HttpWebResponse).StatusCode & vbCrLf

        '        Using reader As New StreamReader(ex.Response.GetResponseStream())
        '            Dim responseError As String = reader.ReadToEnd()
        '            errorMsg &= "Response Error: " & responseError
        '        End Using
        '    End If

        '    ' tampilkan log supaya tahu errornya apa
        '    MsgBox(errorMsg, MsgBoxStyle.Critical, "DEBUG ERROR")
        '    Return "[{""error"":""" & errorMsg & """}]"
        'End Try
    End Function

    Public Function generateNoTransaksi(ByRef kodeTransaksi As String, ByRef jenisPoli As String, ByRef tglTransaksi As String, ByRef jenisMCU As Boolean) As String
        Dim tanggal As String = tglTransaksi
        Dim nomorUrut As String = ""
        Dim result As String = ""

        If jenisPoli = "UMUM" Then
            nomorUrut = ReadSQLNIK("SELECT RIGHT(MAX(NoUrut), 5) AS Number FROM TransaksiPoli WHERE NoUrut LIKE '%" & tanggal & "%'")
        ElseIf jenisPoli = "GIGI" Then
            nomorUrut = ReadSQLNIK("SELECT RIGHT(MAX(NoUrut), 5) AS Number FROM TransaksiGigi WHERE NoUrut LIKE '%" & tanggal & "%'")
        ElseIf jenisPoli = "LABORATORIUM" Then
            If jenisMCU = True Then
                nomorUrut = ReadSQLNIK("SELECT RIGHT(MAX(NoUrut), 5) AS Number FROM TransaksiLab WHERE NoUrut LIKE '%" & tanggal & "%' AND NoUrut LIKE '%M%'")
            ElseIf jenisMCU = False Then
                nomorUrut = ReadSQLNIK("SELECT RIGHT(MAX(NoUrut), 5) AS Number FROM TransaksiLab WHERE NoUrut LIKE '%" & tanggal & "%' AND NoUrut LIKE '%L%'")
            End If
        End If

        If Not String.IsNullOrEmpty(nomorUrut) AndAlso IsNumeric(nomorUrut) Then
            nomorUrut = (Convert.ToInt32(nomorUrut) + 1).ToString()
        Else
            nomorUrut = "1"
        End If

        result = tanggal & kodeTransaksi & nomorUrut.PadLeft(5, "0"c)

        Return result
    End Function

    Public Function generateNomorRekamMedis() As String
        Dim KodeLokasi As String = ReadSQLNIK("select StrValue from MsConfig where ConfigName='NoPoli'")
        Dim noUrut As String = ""
        Dim NomorRekamMedis As String = ""

        noUrut = ReadSQLNIK("SELECT TOP (1) " & _
                            "RIGHT(NoRekamMedis, 7) + 1 as 'NoPendaftaran' " & _
                            "FROM MasterPasien " & _
                            "WHERE NoRekamMedis IS NOT NULL " & _
                            "ORDER BY RIGHT(NoRekamMedis, 7) DESC")

        If noUrut = "" Or noUrut = "-" Then noUrut = "0000001"

        NomorRekamMedis = KodeLokasi & "-" & noUrut.ToString().PadLeft(7, "0")

        Return NomorRekamMedis
    End Function

    Public Function generateNomorNIK() As String
        Dim tempNomorNIK As String = "999"
        Dim kodeLokasi As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'KodeBarcode'")
        Dim noUrut As String = ""

        noUrut = ReadSQLNIK("SELECT TOP (1) " & _
                            "RIGHT(NoNIK, 10) + 1 as 'No NIK' " & _
                            "FROM MasterPasien " & _
                            "WHERE NoNIK IS NOT NULL AND PasienTanpaNIK = 1 " & _
                            "ORDER BY RIGHT(NoNIK, 10) DESC")

        If noUrut = "" Or noUrut = "-" Then noUrut = "0000000001"

        tempNomorNIK = tempNomorNIK & kodeLokasi & noUrut.ToString().PadLeft(10, "0")

        Return tempNomorNIK
    End Function

    Public Sub ApplyPlaceholder(ByVal textBox As TextBox, ByVal placeholderText As String)
        AddHandler textBox.GotFocus, AddressOf TextBox_GotFocus
        AddHandler textBox.LostFocus, AddressOf TextBox_LostFocus

        textBox.Tag = placeholderText
        TextBox_LostFocus(textBox, EventArgs.Empty)
    End Sub

    Private Sub TextBox_GotFocus(ByVal sender As Object, ByVal e As EventArgs)
        Dim textBox As TextBox = CType(sender, TextBox)
        If textBox.Text = textBox.Tag.ToString() Then
            textBox.Text = ""
            textBox.ForeColor = Color.Black
        End If
    End Sub

    Private Sub TextBox_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
        Dim textBox As TextBox = CType(sender, TextBox)
        If textBox.Text = "" Then
            textBox.Text = textBox.Tag.ToString()
            textBox.ForeColor = Color.Gray
        End If
    End Sub

    Public Function IsPlaceholder(ByVal textBox As TextBox) As Boolean
        Return textBox.Text = DirectCast(textBox.Tag, String)
    End Function

    Public Function ParseJSON(ByVal jsonString As String) As JArray
        Dim jsonArray As JArray = JArray.Parse(jsonString)
        Return jsonArray
    End Function

    Public Sub TableMerger(ByRef Ttable As DataTable, ByVal Tstr As String)
        Dim Ttemp As DataTable = ReadSQL(Tstr)
        If Ttemp.Rows.Count > 0 Then
            For Each Trow As DataRow In Ttemp.Rows
                Dim Tnew As DataRow = Ttable.NewRow
                For i As Integer = 0 To Ttable.Columns.Count - 1
                    Dim Tcolname As String = Ttable.Columns(i).ColumnName
                    Tnew(Tcolname) = Trow(Tcolname)
                Next
                Ttable.Rows.Add(Tnew)
            Next
        End If
    End Sub

    Public Function CheckBridgingPcareActive() As Boolean
        Dim statusBridgingPcare As String = ReadSQLNIK("select StrValue from MsConfig where ConfigName = 'pcare_status_bridging'")

        ' Cek Status Bridging
        If statusBridgingPcare <> "Yes" Then Return False

        Return True
    End Function

    Public Function CekKoneksiDB(ByVal db As Object) As Boolean
        Dim connStr As String = "Server=" & db.Tip & _
                                ";Database=" & db.Tdb & _
                                ";Uid=" & db.Tid & _
                                ";Pwd=" & db.Tpass & _
                                ";Pooling=false;Connection Timeout=5;"

        Dim conn As MySqlConnection = Nothing

        Try
            conn = New MySqlConnection(connStr)
            conn.Open()
            Return True
        Catch ex As Exception
            Return False
        Finally
            If conn IsNot Nothing Then
                If conn.State = ConnectionState.Open Then conn.Close()
                conn.Dispose()
            End If
        End Try
    End Function

    Public Function ValidasiKoneksi(ByVal namaDb As String, ByVal db As Object) As Boolean
        If Not CekKoneksiDB(db) Then
            MsgBox("Koneksi MySQL gagal: " & namaDb & _
                   vbCrLf & "DB : " & db.Tdb & _
                   vbCrLf & "IP : " & db.Tip, _
                   MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If
        Return True
    End Function

    Public Function ValidateBridgingPcare() As Boolean
        ' Cek sambungan internet
        If CheckInternetConnection() = False Then
            MsgBox("Eror : Tidak ada koneksi internet.", MsgBoxStyle.Exclamation, "Error!")
            Return False
        End If

        ' Cek apakah bridging sukses
        If CheckConnectPcare() = False Then
            MsgBox("Eror : Program tidak tersambung dengan PCare, hubungi IT.", MsgBoxStyle.Exclamation, "Error!")
            Return False
        End If

        Return True
    End Function

    Public Function CheckInternetConnection() As Boolean
        Try
            ' Coba membuat permintaan ping ke situs web yang dapat diakses secara online.
            Dim ping As New Ping()
            Dim result As PingReply = ping.Send("www.google.com")

            ' Jika permintaan ping berhasil, berarti ada koneksi internet.
            If result.Status = IPStatus.Success Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            ' Jika terjadi kesalahan, berarti tidak ada koneksi internet.
            Return False
        End Try
    End Function

    'NEW VER 1
    'Public Function CheckConnectPcare() As Boolean
    '    Try
    '        Dim urlPcare As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'pcare_base_url'")
    '        Dim uri As String = urlPcare & "kesadaran" 'URL bebas untuk testing.

    '        'Dim rawresp As String = GetDataBPJSv4(uri)
    '        Dim rawresp As String = getDataFromPcare(uri)
    '        'InputBox("response", "response", rawresp)
    '        'MsgBox(rawresp)
    '        Dim varses() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of varJsonPcare())(rawresp)

    '        For Each oneVar As varJsonPcare In varses
    '            If oneVar IsNot Nothing Then
    '                If oneVar.metaData.message = "OK" Then
    '                    Return True
    '                Else
    '                    MsgBox(oneVar.metaData.message, MsgBoxStyle.Exclamation, "Failed")
    '                    Return False
    '                End If
    '            End If
    '        Next

    '        Return False
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '        Return False
    '    End Try
    'End Function

    'NEW VER 2
    Public Function CheckConnectPcare() As Boolean
        Try
            Dim urlPcare As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'pcare_base_url'")
            Dim uri As String = urlPcare & "kesadaran"   'endpoint bebas untuk test koneksi

            Dim rawresp As String = getDataFromPcare(uri)

            '===============================================
            ' 1. CEK RESPONS KOSONG (Internet putus / Server down total)
            '===============================================
            If String.IsNullOrEmpty(rawresp) OrElse rawresp.Trim = "" Then
                MsgBox("Tidak ada respons dari server PCare." & vbCrLf & _
                       "Kemungkinan:" & vbCrLf & _
                       "- Internet terputus" & vbCrLf & _
                       "- Server BPJS PCare DOWN" & vbCrLf & _
                       "- Gateway/Proxy tidak merespon", MsgBoxStyle.Critical, "Koneksi PCare Gagal")
                Return False
            End If

            '===============================================
            ' 2. CEK FORMAT JSON VALID
            '===============================================
            Dim trimmed As String = rawresp.Trim()

            'PCare normalnya mengembalikan JSON object {}
            'kadang proxy mengembalikan array []
            If Not (trimmed.StartsWith("{") Or trimmed.StartsWith("[")) Then
                MsgBox("Respons PCare bukan format JSON yang valid." & vbCrLf & _
                       "Raw Response:" & vbCrLf & _
                       rawresp, MsgBoxStyle.Critical, "Format PCare Error")
                Return False
            End If

            '===============================================
            ' 3. PROSES JSON
            '===============================================
            Dim varses() As varJsonPcare = Nothing

            Try
                varses = Newtonsoft.Json.JsonConvert.DeserializeObject(Of varJsonPcare())(rawresp)
            Catch ex As Exception
                MsgBox("Gagal membaca respons PCare." & vbCrLf & _
                       "Kemungkinan:" & vbCrLf & _
                       "- Server BPJS DOWN" & vbCrLf & _
                       "- Respons tidak lengkap / terpotong" & vbCrLf & _
                       "- Internet sangat lambat sehingga data corrupt" & vbCrLf & _
                       vbCrLf & _
                       "Raw Response:" & vbCrLf & rawresp, MsgBoxStyle.Critical, "PCare Tidak Stabil")
                Return False
            End Try

            '===============================================
            ' 4. CEK METADATA
            '===============================================
            If varses IsNot Nothing Then
                For Each oneVar As varJsonPcare In varses
                    If oneVar IsNot Nothing AndAlso oneVar.metaData IsNot Nothing Then

                        If oneVar.metaData.message = "OK" Then
                            Return True
                        Else
                            MsgBox("PCare Error: " & oneVar.metaData.message, MsgBoxStyle.Exclamation, "Koneksi PCare Gagal")
                            Return False
                        End If

                    End If
                Next
            End If

            '===============================================
            ' 5. FALLBACK – METADATA TIDAK ADA
            '===============================================
            MsgBox("Tidak bisa membaca metadata PCare." & vbCrLf & _
               "Kemungkinan server BPJS tidak stabil.", MsgBoxStyle.Exclamation, "PCare Tidak Merespon")

            Return False

        Catch ex As Exception
            '===============================================
            ' 6. EXCEPTION UMUM (timeout, koneksi putus)
            '===============================================
            MsgBox("Koneksi ke PCare gagal:" & vbCrLf & _
               ex.Message & vbCrLf & _
               vbCrLf & _
               "Kemungkinan:" & vbCrLf & _
               "- Internet putus / lambat" & vbCrLf & _
               "- Server BPJS DOWN" & vbCrLf & _
               "- Timeout koneksi", MsgBoxStyle.Critical, "Koneksi Error")
            Return False
        End Try
    End Function

    Public Function GetTokenAntrol() As String
        Try
            ' Set URL Web Service
            Dim baseURL As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'web_service_klinik'")
            Dim urlWebService As String = baseURL & "api/accesstoken-antrian-online"

            ' Set Variabel
            Dim apiEndpoint As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'web_service_get_token_antrol'")
            Dim username As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'username_token_antrol'")
            Dim password As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'password_token_antrol'")

            'REQUEST GET METHOD
            Dim webreq As HttpWebRequest = WebRequest.Create(urlWebService)

            webreq.Accept = "application/json"

            webreq.Headers("username") = username
            webreq.Headers("password") = password

            webreq.Headers("API-Endpoint") = apiEndpoint

            webreq.Method = "GET"

            Dim res As WebResponse = webreq.GetResponse()
            Dim stream As Stream = res.GetResponseStream()
            Dim streamReader As New StreamReader(stream)

            Dim responseSuccess As String = ""

            ' READ RESPONSE
            responseSuccess = streamReader.ReadToEnd()
            streamReader.Close()

            Dim responseObject As v4_AuthResource = Newtonsoft.Json.JsonConvert.DeserializeObject(Of v4_AuthResource)(responseSuccess)
            Dim tokenValue As String = responseObject.response.token

            Return tokenValue
        Catch ex As WebException
            Dim responseStream As Stream = ex.Response.GetResponseStream()

            Dim reader As New StreamReader(responseStream)
            Dim responseError As String = reader.ReadToEnd()

            reader.Close()
            responseStream.Close()

            Return responseError
        End Try
    End Function

    Public Function GetDataAntrianOnline(ByVal apiEndpoint As String) As String
        Try
            ' Set URL Web Service
            Dim baseURL As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'web_service_klinik'")
            Dim urlWebService As String = baseURL & "api/data-antrian-online"

            ' Set Variabel
            Dim username As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'username_token_antrol'")
            Dim token As String = GetTokenAntrol()
            Dim response As String = ""

            'REQUEST GET METHOD
            Dim webreq As HttpWebRequest = WebRequest.Create(urlWebService)

            webreq.Accept = "application/json"
            webreq.Headers("username") = username
            webreq.Headers("token") = token

            webreq.Headers("API-Endpoint") = apiEndpoint

            webreq.Method = "GET"

            Dim res As WebResponse = webreq.GetResponse()
            Dim stream As Stream = res.GetResponseStream()
            Dim streamReader As New StreamReader(stream)

            ' READ RESPONSE
            response = streamReader.ReadToEnd()
            streamReader.Close()

            response = "[" + response + "]"

            Return response
        Catch ex As Exception
            Return "Nothing"
        End Try
    End Function

    'Public Function GetDataAntrianOnline2(ByVal apiEndpoint As String) As String
    '    Try
    '        ' Set URL Web Service
    '        'Dim baseURL As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'web_service_klinik'")
    '        'Dim urlWebService As String = baseURL & "api/data-antrian-online"

    '        ' Set Variabel
    '        Dim username As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'username_token_antrol'")
    '        Dim token As String = GetTokenAntrol()
    '        Dim response As String = ""

    '        'REQUEST GET METHOD
    '        Dim webreq As HttpWebRequest = WebRequest.Create(apiEndpoint)

    '        webreq.Accept = "application/json"
    '        webreq.Headers("x-username") = username
    '        'webreq.Headers("x-token") = token
    '        webreq.Headers("x-token") = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6ImJwanMtdXNlciIsInJvbGUiOiJ1c2VyIiwiaWF0IjoxNzU2NDUwMTYxLCJleHAiOjE3NTY0NTE5NjF9.Pz_EXweINOMCQNoiuttEApMY1MUYz4CFwcifTzI7WHI"

    '        'webreq.Headers("API-Endpoint") = apiEndpoint

    '        webreq.Method = "GET"

    '        Dim res As WebResponse = webreq.GetResponse()
    '        Dim stream As Stream = res.GetResponseStream()
    '        Dim streamReader As New StreamReader(stream)

    '        ' READ RESPONSE
    '        response = streamReader.ReadToEnd()
    '        streamReader.Close()

    '        response = "[" + response + "]"

    '        Return response
    '    Catch ex As Exception
    '        Return "Nothing"
    '    End Try
    'End Function

    Public Function PutCheckinAntrol(ByVal urlWebService As String, ByVal parameterString As String) As String
        Try
            Dim username As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'username_token_antrol'")
            Dim token As String = GetTokenAntrol()
            Dim bytearr() As Byte = Encoding.UTF8.GetBytes(parameterString)
            Dim response As String = ""

            'REQUEST GET METHOD
            Dim webreq As HttpWebRequest = WebRequest.Create(urlWebService)

            webreq.Accept = "application/json"
            webreq.Headers("x-username") = username
            webreq.Headers("x-token") = token
            webreq.Method = "PUT"

            webreq.ContentType = "application/json"
            webreq.ContentLength = bytearr.Length

            Dim dataStream As Stream = webreq.GetRequestStream()
            dataStream.Write(bytearr, 0, bytearr.Length)
            dataStream.Close()

            Dim res As WebResponse = webreq.GetResponse()
            Dim stream As Stream = res.GetResponseStream()
            Dim streamReader As New StreamReader(stream)

            'READ RESPONSE
            response = streamReader.ReadToEnd
            streamReader.Close()

            response = "[" + response + "]"

            Return response
        Catch ex As Exception
            Return "Nothing"
        End Try
    End Function

    Public Function GetTokenSatuSehat() As String
        Try
            Dim baseURL As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'web_service_klinik'")
            Dim urlWebService As String = baseURL & "api/accesstoken"

            Dim clientId As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'satu_sehat_client_key'")
            Dim clientSecret As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'satu_sehat_secret_key'")
            Dim authURL As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'satu_sehat_auth_url'")

            Dim postData As String = "client_id=" & clientId & "&client_secret=" & clientSecret & "&auth_url=" & authURL
            Dim bytearr() As Byte = Encoding.UTF8.GetBytes(postData)

            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls

            ' REQUEST POST METHOD
            Dim webreq As HttpWebRequest = WebRequest.Create(urlWebService)

            webreq.Method = "POST"
            webreq.ContentType = "application/x-www-form-urlencoded"
            webreq.ContentLength = bytearr.Length

            Dim dataStream As Stream = webreq.GetRequestStream()
            dataStream.Write(bytearr, 0, bytearr.Length)
            dataStream.Close()

            Dim res As WebResponse = webreq.GetResponse()
            Dim stream As Stream = res.GetResponseStream()
            Dim streamReader As New StreamReader(stream)

            ' READ RESPONSE
            Dim response As String = streamReader.ReadToEnd()
            streamReader.Close()

            Dim responseObject As AuthResource = Newtonsoft.Json.JsonConvert.DeserializeObject(Of AuthResource)(response)
            Dim tokenValue As String = responseObject.access_token

            Return tokenValue
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function GetDataSatuSehat(ByVal apiEndpoint As String) As String
        Try
            Dim baseURL As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'web_service_klinik'")
            Dim urlWebService As String = baseURL & "api/get-data-resource"
            Dim token As String = GetTokenSatuSehat()
            Dim response As String = ""

            'REQUEST GET METHOD
            Dim webreq As HttpWebRequest = WebRequest.Create(urlWebService)

            webreq.Accept = "application/json"
            webreq.Headers("x-authorization") = token
            webreq.Headers("x-api-endpoint") = apiEndpoint
            webreq.Method = "GET"

            Dim res As WebResponse = webreq.GetResponse()
            Dim stream As Stream = res.GetResponseStream()
            Dim streamReader As New StreamReader(stream)

            ' READ RESPONSE
            response = streamReader.ReadToEnd()
            streamReader.Close()

            response = "[" + response + "]"

            Return response
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function InsertDataAPIRMUrlEncode(ByVal json As String, ByVal url As String) As String
        Try
            Dim client As New Net.WebClient()
            client.Encoding = Encoding.UTF8

            client.Headers.Clear()
            client.Headers.Add("Content-Type", "application/x-www-form-urlencoded")
            client.Headers.Add("Accept", "application/json")
            client.Headers.Add("X-API-KEY", "M1tR4M3D1c@rECaH4Y42025")

            client.Headers.Add("User-Agent", "PostmanRuntime/7.36.0")

            Dim response As String = client.UploadString(url, "POST", json)

            Return response

        Catch ex As WebException
            If ex.Response IsNot Nothing Then
                Using sr As New StreamReader(ex.Response.GetResponseStream())
                    Return sr.ReadToEnd()
                End Using
            End If

            Return "{""metaData"":{""code"":500},""message"":""" & ex.Message & """}"
        End Try
    End Function

    Public Function PostDataSatuSehat(ByVal token As String, ByVal apiEndpoint As String, ByVal parameterString As String) As String
        Try
            Dim baseURL As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'web_service_klinik'")
            Dim urlWebService As String = baseURL & "api/post-data-resource"
            Dim bytearr() As Byte = Encoding.UTF8.GetBytes(parameterString)
            Dim response As String = ""

            'REQUEST GET METHOD
            Dim webreq As HttpWebRequest = WebRequest.Create(urlWebService)

            webreq.Accept = "application/json"
            webreq.Headers("x-authorization") = token
            webreq.Headers("x-api-endpoint") = apiEndpoint
            webreq.Method = "POST"

            webreq.ContentType = "application/json"
            webreq.ContentLength = bytearr.Length

            Dim dataStream As Stream = webreq.GetRequestStream()
            dataStream.Write(bytearr, 0, bytearr.Length)
            dataStream.Close()

            Dim res As WebResponse = webreq.GetResponse()
            Dim stream As Stream = res.GetResponseStream()
            Dim streamReader As New StreamReader(stream)

            'READ RESPONSE
            response = streamReader.ReadToEnd
            streamReader.Close()

            'response = "[" + response + "]"

            Return response
        Catch ex As Exception
            Return ex.Message
        End Try
    End Function

    Public Function GetUUID() As String
        Dim myuuid As Guid = Guid.NewGuid()
        Dim myuuidAsString As String = myuuid.ToString()

        Return myuuidAsString
    End Function

    Public Function GenerateJsonFromGridControl(ByVal gridControl As DevExpress.XtraGrid.GridControl) As String
        Dim dataTable As DataTable = TryCast(gridControl.DataSource, DataTable)
        If dataTable Is Nothing Then
            Return String.Empty
        End If
        Return JsonConvert.SerializeObject(dataTable, Formatting.Indented)
    End Function

    Function ConvertDateStringSatuSehat(ByVal originalDate As String) As String
        ' Konversi tanggal dari string ke objek DateTime
        Dim sqlDateTime As DateTime = DateTime.ParseExact(originalDate, "yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)

        ' Format ulang dan kembalikan sebagai string
        Return sqlDateTime.ToString("yyyy-MM-ddTHH:mm:sszzz")
    End Function

    Function ConvertDateStringAntreanOnline(ByVal dateString As String) As String
        ' Format tanggal awal
        Dim originalFormat As String = "yyyy-MM-ddTHH:mm:ss.fffZ"

        ' Format tanggal yang diinginkan
        Dim desiredFormat As String = "yyyy-MM-dd HH:mm:ss.fff"

        ' Parse string menjadi objek DateTime
        Dim parsedDate As DateTime = DateTime.ParseExact(dateString, originalFormat, CultureInfo.InvariantCulture)

        ' Ubah ke waktu UTC
        parsedDate = parsedDate.ToUniversalTime()

        ' Format objek DateTime sesuai dengan format yang diinginkan
        Dim formattedDate As String = parsedDate.ToString(desiredFormat)

        ' Kembalikan hasil yang diformat
        Return formattedDate
    End Function

    Function CreateXRPictureBoxReport(ByVal pictureName As String, ByVal pictureSource As Image, ByVal LocX As Integer, ByVal LocY As Integer, ByVal SizeX As Integer, ByVal SizeY As Integer) As XRPictureBox
        Dim PictureBox As XRPictureBox = New XRPictureBox()
        PictureBox.Name = pictureName
        PictureBox.Image = pictureSource
        PictureBox.Location = New Point(LocX, LocY)
        PictureBox.Size = New Size(SizeX, SizeY)
        PictureBox.Sizing = ImageSizeMode.StretchImage
        PictureBox.BorderWidth = 0

        Return PictureBox
    End Function

    Function CreateXRPictureBoxReportFromBase64(ByVal stringBase64 As String, ByVal pictureName As String, ByVal LocX As Integer, ByVal LocY As Integer, ByVal SizeX As Integer, ByVal SizeY As Integer) As XRPictureBox
        ' Convert Base64 string to byte array
        Dim stringBytes As Byte() = Convert.FromBase64String(stringBase64)

        ' Create MemoryStream from byte array
        Dim memoryStream As New MemoryStream(stringBytes)

        ' Set Image
        Dim pictureSource As Image = Image.FromStream(memoryStream)

        Dim PictureBox As XRPictureBox = New XRPictureBox()
        PictureBox.Name = pictureName
        PictureBox.Image = pictureSource
        PictureBox.Location = New Point(LocX, LocY)
        PictureBox.Size = New Size(SizeX, SizeY)
        PictureBox.Sizing = ImageSizeMode.StretchImage
        PictureBox.BorderWidth = 0

        Return PictureBox
    End Function

    Function GetKesimpulanBMI(ByVal nilaiBMI As String)
        Dim tblKesimpulanBMI As DataTable = ReadSQL("SELECT * FROM MasterKesimpulanBMI")
        Dim rangeBMI As String = ""
        Dim keteranganBMI As String = ""
        Dim rangeSplit1 As Double = 0
        Dim rangeSplit2 As Double = 0

        For Each rowKesimpulanBMI As DataRow In tblKesimpulanBMI.Rows
            rangeBMI = rowKesimpulanBMI("RangeBMI")
            If rangeBMI.Contains("<") = True Then
                rangeBMI = Trim(Strings.Replace(Strings.Replace(rangeBMI, "<", ""), "=", ""))
                If CDbl(nilaiBMI) < CDbl(rangeBMI) Then
                    keteranganBMI = rowKesimpulanBMI("WeightStatus")
                End If
            ElseIf rangeBMI.Contains(">") = True Then
                rangeBMI = Trim(Strings.Replace(Strings.Replace(rangeBMI, ">", ""), "=", ""))
                If CDbl(nilaiBMI) > CDbl(rangeBMI) Then
                    keteranganBMI = rowKesimpulanBMI("WeightStatus")
                End If
            ElseIf rangeBMI.Contains("-") = True Then
                Dim Tsplit() As String = rangeBMI.ToString.Split("-")
                rangeSplit1 = Trim(Tsplit(0))
                rangeSplit2 = Trim(Tsplit(1))

                If CDbl(nilaiBMI) >= rangeSplit1 And CDbl(nilaiBMI) <= rangeSplit2 Then
                    keteranganBMI = rowKesimpulanBMI("WeightStatus")
                End If
            End If
        Next

        Return keteranganBMI
    End Function

    Function GetJenisPembayaran(ByVal _jenisPoli As String, ByVal noTransaksi As String)
        Dim jenisBayar As String = ""
        Dim tblBayar As DataTable = New DataTable
        Dim queryString As New StringBuilder()

        If _jenisPoli = "LAB" Then
            queryString.AppendLine("SELECT * FROM TransaksiLabBayar")
            queryString.AppendLine("WHERE TransLabID IN (SELECT TransLabID FROM TransaksiLab WHERE NoUrut = '" & noTransaksi & "')")
        ElseIf _jenisPoli = "POLI" Then
            queryString.AppendLine("SELECT * FROM TransaksiPoliBayarAwal")
            queryString.AppendLine("WHERE TransPoliID IN (SELECT TransPoliID FROM TransaksiPoli WHERE NoUrut = '" & noTransaksi & "')")
        ElseIf _jenisPoli = "GIGI" Then
            queryString.AppendLine("SELECT * FROM TransaksiGigiBayarAwal")
            queryString.AppendLine("WHERE TransGigiID IN (SELECT TransGigiID FROM TransaksiGigi WHERE NoUrut = '" & noTransaksi & "')")
        End If

        tblBayar = ReadSQL(queryString.ToString())

        For Each rowBayar As DataRow In tblBayar.Rows
            If rowBayar("JenisBayar") = "TAGIHAN" And rowBayar("NoJenisBayar").ToString.Contains("BPJS") = True Then
                jenisBayar = "BPJS"
            ElseIf rowBayar("JenisBayar") = "TAGIHAN" And rowBayar("NoJenisBayar").ToString.Contains("MANDIRI INHEALTH") = True Then
                jenisBayar = "MANDIRI INHEALTH"
            ElseIf rowBayar("JenisBayar") = "TAGIHAN" And rowBayar("NoJenisBayar").ToString.Contains("TRANSFER") = True Then
                If jenisBayar = "" Then jenisBayar = "UMUM"
            ElseIf rowBayar("JenisBayar") = "TAGIHAN" Then
                jenisBayar = "Asuransi Lain"
            ElseIf rowBayar("JenisBayar") = "TUNAI" Or rowBayar("JenisBayar") = "DEBET" Or rowBayar("JenisBayar") = "CARD" Then
                If jenisBayar = "" Then jenisBayar = "UMUM"
            End If
        Next

        Return jenisBayar
    End Function

    Public Function getDataFromPcare(ByVal apiEndpoint As String) As String
        Try
            Dim baseURL As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'web_service_klinik'")
            Dim urlWebService As String = baseURL & "api/get-data-resource-pcare"

            ' Set Variabel PCare
            Dim consID As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_consid'")
            Dim secretKey = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_secret_key'")
            Dim pcareUname = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_username'")
            Dim pcarePWD = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_password'")
            Dim kdAplikasi = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_kode_aplikasi'")
            Dim userKey = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_user_key'")

            'REQUEST GET METHOD
            Dim webreq As HttpWebRequest = WebRequest.Create(urlWebService)

            webreq.Accept = "application/json"

            webreq.Headers("cons-id") = consID
            webreq.Headers("secret-key") = secretKey
            webreq.Headers("username-pcare") = pcareUname
            webreq.Headers("password-pcare") = pcarePWD
            webreq.Headers("kd-aplikasi") = kdAplikasi
            webreq.Headers("user-key") = userKey

            webreq.Headers("API-Endpoint") = apiEndpoint

            webreq.Method = "GET"

            Dim res As WebResponse = webreq.GetResponse()
            Dim stream As Stream = res.GetResponseStream()
            Dim streamReader As New StreamReader(stream)

            Dim responseSuccess As String = ""

            ' READ RESPONSE
            responseSuccess = streamReader.ReadToEnd()
            streamReader.Close()

            responseSuccess = "[" + responseSuccess + "]"

            Return responseSuccess
            'Catch ex As Exception
            '    Return ex.Message
        Catch ex As WebException
            Dim responseStream As Stream = ex.Response.GetResponseStream()

            Dim reader As New StreamReader(responseStream)
            Dim responseError As String = reader.ReadToEnd()

            reader.Close()
            responseStream.Close()

            Return responseError
        End Try
    End Function

    Public Function PostDataFromPcare(ByVal parameterAPI As String, ByVal apiEndpoint As String, ByVal methodAPI As String) As String
        Try
            Dim bytearr() As Byte = Encoding.UTF8.GetBytes(parameterAPI)

            Dim baseURL As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'web_service_klinik'")
            Dim urlWebService As String = baseURL & "api/post-data-resource-pcare"

            ' Set Variabel PCare
            Dim consID As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_consid'")
            Dim secretKey = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_secret_key'")
            Dim pcareUname = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_username'")
            Dim pcarePWD = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_password'")
            Dim kdAplikasi = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_kode_aplikasi'")
            Dim userKey = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_user_key'")

            'REQUEST GET METHOD
            Dim webreq As HttpWebRequest = WebRequest.Create(urlWebService)

            webreq.Accept = "application/json"

            webreq.Headers("cons-id") = consID
            webreq.Headers("secret-key") = secretKey
            webreq.Headers("username-pcare") = pcareUname
            webreq.Headers("password-pcare") = pcarePWD
            webreq.Headers("kd-aplikasi") = kdAplikasi
            webreq.Headers("user-key") = userKey
            webreq.Headers("API-method") = methodAPI
            webreq.Headers("API-Endpoint") = apiEndpoint
            webreq.Headers("API-Content-Type") = "text/plain"

            webreq.Method = "POST"

            webreq.ContentType = "application/json"
            webreq.ContentLength = bytearr.Length

            Dim dataStream As Stream = webreq.GetRequestStream()
            dataStream.Write(bytearr, 0, bytearr.Length)
            dataStream.Close()

            Dim res As WebResponse = webreq.GetResponse()
            Dim stream As Stream = res.GetResponseStream()
            Dim streamReader As New StreamReader(stream)

            Dim responseSuccess As String = ""

            'READ RESPONSE
            responseSuccess = streamReader.ReadToEnd
            streamReader.Close()

            Return responseSuccess
        Catch ex As WebException
            Dim responseStream As Stream = ex.Response.GetResponseStream()

            Dim reader As New StreamReader(responseStream)
            Dim responseError As String = reader.ReadToEnd()

            reader.Close()
            responseStream.Close()

            Return responseError
        End Try
    End Function

    Public Function DeleteDataFromPcare(ByVal apiEndpoint As String) As String
        Try
            Dim baseURL As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'web_service_klinik'")
            Dim urlWebService As String = baseURL & "api/delete-data-resource-pcare"

            ' Set Variabel PCare
            Dim consID As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_consid'")
            Dim secretKey = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_secret_key'")
            Dim pcareUname = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_username'")
            Dim pcarePWD = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_password'")
            Dim kdAplikasi = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_kode_aplikasi'")
            Dim userKey = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_user_key'")

            'REQUEST GET METHOD
            Dim webreq As HttpWebRequest = WebRequest.Create(urlWebService)

            webreq.Accept = "application/json"

            webreq.Headers("cons-id") = consID
            webreq.Headers("secret-key") = secretKey
            webreq.Headers("username-pcare") = pcareUname
            webreq.Headers("password-pcare") = pcarePWD
            webreq.Headers("kd-aplikasi") = kdAplikasi
            webreq.Headers("user-key") = userKey

            webreq.Headers("API-Endpoint") = apiEndpoint

            webreq.Method = "GET"

            Dim res As WebResponse = webreq.GetResponse()
            Dim stream As Stream = res.GetResponseStream()
            Dim streamReader As New StreamReader(stream)

            Dim responseSuccess As String = ""

            ' READ RESPONSE
            responseSuccess = streamReader.ReadToEnd()
            streamReader.Close()

            responseSuccess = "[" + responseSuccess + "]"

            Return responseSuccess
            'Catch ex As Exception
            '    Return ex.Message
        Catch ex As WebException
            Dim responseStream As Stream = ex.Response.GetResponseStream()

            Dim reader As New StreamReader(responseStream)
            Dim responseError As String = reader.ReadToEnd()

            reader.Close()
            responseStream.Close()

            Return responseError
        End Try
    End Function

    Public Function GenerateICareUrl(ByVal parameterAPI As String, ByVal apiEndpoint As String, ByVal methodAPI As String) As String
        Try
            Dim bytearr() As Byte = Encoding.UTF8.GetBytes(parameterAPI)

            Dim baseURL As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'web_service_klinik'")
            Dim urlWebService As String = baseURL & "api/post-data-resource-pcare"

            ' Get Username & Password I-Care
            Dim userInput As String = PoliKlinik.Lbluser.Text
            Dim pcareUname = ReadSQLNIK("SELECT UsernameIcare FROM Users where UserID = '" & userInput & "'")
            Dim pcarePWD = ReadSQLNIK("SELECT PasswordIcare FROM Users where UserID = '" & userInput & "'")

            ' Set Variabel I-Care
            Dim consID As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'icare_consid'")
            Dim secretKey = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'icare_secret_key'")
            Dim kdAplikasi = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'icare_kode_aplikasi'")
            Dim userKey = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'icare_user_key'")

            'REQUEST GET METHOD
            Dim webreq As HttpWebRequest = WebRequest.Create(urlWebService)

            webreq.Accept = "application/json"

            webreq.Headers("cons-id") = consID
            webreq.Headers("secret-key") = secretKey
            webreq.Headers("username-pcare") = pcareUname
            webreq.Headers("password-pcare") = pcarePWD
            webreq.Headers("kd-aplikasi") = kdAplikasi
            webreq.Headers("user-key") = userKey
            webreq.Headers("API-method") = methodAPI
            webreq.Headers("API-Endpoint") = apiEndpoint
            webreq.Headers("API-Content-Type") = "application/json"

            webreq.Method = "POST"

            webreq.ContentType = "application/json"
            webreq.ContentLength = bytearr.Length

            Dim dataStream As Stream = webreq.GetRequestStream()
            dataStream.Write(bytearr, 0, bytearr.Length)
            dataStream.Close()

            Dim res As WebResponse = webreq.GetResponse()
            Dim stream As Stream = res.GetResponseStream()
            Dim streamReader As New StreamReader(stream)

            Dim responseSuccess As String = ""

            'READ RESPONSE
            responseSuccess = streamReader.ReadToEnd
            streamReader.Close()

            Return responseSuccess
        Catch ex As WebException
            Dim responseStream As Stream = ex.Response.GetResponseStream()

            Dim reader As New StreamReader(responseStream)
            Dim responseError As String = reader.ReadToEnd()

            reader.Close()
            responseStream.Close()

            Return responseError
        End Try
    End Function

    Public Function CheckSQLConnection() As Boolean
        Try
            Using connection As New SqlConnection(PusatSQL.Con.ConnectionString)
                connection.Open()
                ' Koneksi berhasil, tidak perlu melakukan apa pun

                Return True
            End Using
        Catch ex As Exception
            ' Koneksi gagal, keluar dari program
            MessageBox.Show("Koneksi ke server SQL gagal: " & ex.Message)
            Return False
        End Try
    End Function

    Public Function GetCurrentTime() As DateTime
        Dim request As WebRequest = WebRequest.Create("http://worldtimeapi.org/api/ip")
        Dim response As WebResponse = request.GetResponse()
        Dim dataStream As System.IO.Stream = response.GetResponseStream()
        Dim reader As New System.IO.StreamReader(dataStream)
        Dim responseFromServer As String = reader.ReadToEnd()

        ' Parse JSON response using JSON.NET
        Dim jsonResponse As JObject = JObject.Parse(responseFromServer)

        ' Extract datetime string from the response
        Dim timeString As String = jsonResponse("datetime").ToString()

        ' Convert the time string to DateTime
        'Dim currentTime As DateTime = DateTime.ParseExact(timeString, "yyyy-MM-dd'T'HH:mm:ss", Nothing)
        Dim currentTime As DateTime = DateTime.ParseExact(timeString, "M/d/yyyy h:mm:ss tt", Nothing)

        reader.Close()
        dataStream.Close()
        response.Close()

        Return currentTime
    End Function

    Public Sub SetDetailWaktuTransaksi(ByVal noTransaksi As String, ByVal jenisWaktu As String, ByVal namaUser As String)
        Dim tblsWaktuTransaksi As DataTable = ReadSQL("SELECT * FROM TransaksiDetailWaktu WHERE NoTransaksi = '" & noTransaksi & "'")

        If tblsWaktuTransaksi.Rows.Count > 0 Then
            ' Update Detail Waktu Transaksi
            Dim rowWaktuTransaksi As DataRow = tblsWaktuTransaksi.Rows(0)

            If jenisWaktu = "WaktuSelesaiPendaftaran" And IsDBNull(rowWaktuTransaksi("WaktuSelesaiPendaftaran")) = True Then
                WriteSQL("UPDATE TransaksiDetailWaktu SET WaktuSelesaiPendaftaran = GETDATE(), UserSelesaiPendaftaran = '" & namaUser & "' WHERE NoTransaksi = '" & noTransaksi & "'", 4)
            ElseIf jenisWaktu = "WaktuPanggilTTV" And IsDBNull(rowWaktuTransaksi("WaktuPanggilTTV")) = True Then
                WriteSQL("UPDATE TransaksiDetailWaktu SET WaktuPanggilTTV = GETDATE(), UserPanggilTTV = '" & namaUser & "' WHERE NoTransaksi = '" & noTransaksi & "'", 4)
            ElseIf jenisWaktu = "WaktuSelesaiTTV" And IsDBNull(rowWaktuTransaksi("WaktuSelesaiTTV")) = True Then
                WriteSQL("UPDATE TransaksiDetailWaktu SET WaktuSelesaiTTV = GETDATE(), UserSelesaiTTV = '" & namaUser & "' WHERE NoTransaksi = '" & noTransaksi & "'", 4)
            ElseIf jenisWaktu = "WaktuPanggilDokter" And IsDBNull(rowWaktuTransaksi("WaktuPanggilDokter")) = True Then
                WriteSQL("UPDATE TransaksiDetailWaktu SET WaktuPanggilDokter = GETDATE(), UserPanggilDokter = '" & namaUser & "' WHERE NoTransaksi = '" & noTransaksi & "'", 4)
            ElseIf jenisWaktu = "WaktuSelesaiDokter" And IsDBNull(rowWaktuTransaksi("WaktuSelesaiDokter")) = True Then
                WriteSQL("UPDATE TransaksiDetailWaktu SET WaktuSelesaiDokter = GETDATE(), UserSelesaiDokter = '" & namaUser & "' WHERE NoTransaksi = '" & noTransaksi & "'", 4)
            End If
        Else
            ' Insert Detail Waktu Transaksi
            If jenisWaktu = "WaktuSelesaiPendaftaran" Then
                WriteSQL("INSERT INTO TransaksiDetailWaktu (NoTransaksi, WaktuSelesaiPendaftaran, UserSelesaiPendaftaran) " & _
                     "VALUES('" & noTransaksi & "', GETDATE(),'" & namaUser & "')", 4)
            ElseIf jenisWaktu = "WaktuPanggilTTV" Then
                WriteSQL("INSERT INTO TransaksiDetailWaktu (NoTransaksi, WaktuPanggilTTV, UserPanggilTTV) " & _
                     "VALUES('" & noTransaksi & "', GETDATE(),'" & namaUser & "')", 4)
            ElseIf jenisWaktu = "WaktuSelesaiTTV" Then
                WriteSQL("INSERT INTO TransaksiDetailWaktu (NoTransaksi, WaktuSelesaiTTV, UserSelesaiTTV) " & _
                     "VALUES('" & noTransaksi & "', GETDATE(),'" & namaUser & "')", 4)
            ElseIf jenisWaktu = "WaktuPanggilDokter" Then
                WriteSQL("INSERT INTO TransaksiDetailWaktu (NoTransaksi, WaktuPanggilDokter, UserPanggilDokter) " & _
                     "VALUES('" & noTransaksi & "', GETDATE(),'" & namaUser & "')", 4)
            ElseIf jenisWaktu = "WaktuSelesaiDokter" Then
                WriteSQL("INSERT INTO TransaksiDetailWaktu (NoTransaksi, WaktuSelesaiDokter, UserSelesaiDokter) " & _
                     "VALUES('" & noTransaksi & "', GETDATE(),'" & namaUser & "')", 4)
            End If
        End If

        ' Menentukan Status Transaksi
        'Dim statusTransaksi As String = ""
        'If jenisWaktu = "WaktuSelesaiPendaftaran" Then ' Setelah melakukan invoice pertama oleh resepsionis
        '    statusTransaksi = "Belum diperiksa"
        'ElseIf jenisWaktu = "WaktuPanggilTTV" Then ' Saat klik pertama di daftar kunjungan oleh perawat
        '    statusTransaksi = "Sedang dilakukan TTV"
        'ElseIf jenisWaktu = "WaktuSelesaiTTV" Then ' Saat TTV sudah diisi oleh perawat
        '    statusTransaksi = "Sudah dilakukan TTV"
        'ElseIf jenisWaktu = "WaktuPanggilDokter" Then ' Saat klik oleh dokter setelah selesai TTV
        '    statusTransaksi = "Sedang Diperiksa Dokter"
        'ElseIf jenisWaktu = "WaktuSelesaiDokter" Then ' Setelah TTV dan Diagnosa sudah diisi lengkap
        '    statusTransaksi = "Sudah Diperiksa"
        'End If
    End Sub

    Public Function GetStatusTransaksi(ByVal noTransaksi As String, ByVal jenisPoli As String) As String
        Dim statusTransaksi As String = ""

        If jenisPoli = "UMUM" Or jenisPoli = "POLI" Then
            statusTransaksi = ReadSQLNIK("SELECT StatusKeterangan FROM TransaksiPoli WHERE NoUrut = '" & noTransaksi & "'")
        ElseIf jenisPoli = "GIGI" Then
            statusTransaksi = ReadSQLNIK("SELECT StatusKeterangan FROM TransaksiGigi WHERE NoUrut = '" & noTransaksi & "'")
        End If

        Return statusTransaksi
    End Function

    Public Function CekNilaiVitalAntropometri(ByRef NamaPemeriksaan As String, ByRef Value As String) As Boolean
        Dim Tbls As DataTable = ReadSQL("SELECT * FROM MasterPemeriksaanVitalAntropometri WHERE NamaPemeriksaan = '" & NamaPemeriksaan & "'")
        Dim Trow As DataRow = Tbls.Rows(0)

        Dim batasBawah As Double = CDbl(Trow("BatasBawah"))
        Dim batasAtas As Double = CDbl(Trow("BatasAtas"))

        If String.IsNullOrEmpty(Value) Then Value = CDbl("0")

        If Value = 0 Then
            MsgBox(" " & NamaPemeriksaan & " tidak boleh kosong.", MsgBoxStyle.Critical, "Warning!")

            Return False
        ElseIf batasBawah > Value Or Value > batasAtas Then
            MsgBox("Gagal simpan! Terdapat data yang tidak sesuai kriteria. Input Rentang " & NamaPemeriksaan & " adalah " & batasBawah & "-" & batasAtas & ".", MsgBoxStyle.Exclamation, "Warning!")

            Return False
        Else
            Return True
        End If
    End Function

    Public Sub OpenInNewChromeWindow(ByVal url As String)
        Try
            ' Cek path Chrome di Program Files dan Program Files (x86)
            Dim chromePath As String = ""
            If IO.File.Exists("C:\Program Files\Google\Chrome\Application\chrome.exe") Then
                chromePath = "C:\Program Files\Google\Chrome\Application\chrome.exe"
            ElseIf IO.File.Exists("C:\Program Files (x86)\Google\Chrome\Application\chrome.exe") Then
                chromePath = "C:\Program Files (x86)\Google\Chrome\Application\chrome.exe"
            Else
                MessageBox.Show("Google Chrome tidak ditemukan.")
                Exit Sub
            End If

            ' Membuka Chrome dengan URL dalam jendela baru
            Dim psi As New ProcessStartInfo()
            psi.FileName = chromePath
            psi.Arguments = "--new-window """ & url & """"
            psi.UseShellExecute = True
            Process.Start(psi)
        Catch ex As Exception
            MessageBox.Show("Gagal membuka browser. " & ex.Message)
        End Try
    End Sub
End Module