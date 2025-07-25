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

Public Class Implementasi
    Private urlToPost As String = ""
    Private apikey_favoriot As String = "YOUR API KEY HERE"

    Public Class container
        Public response As Pendaftaran
        Public metaData As MetaData
    End Class

    'Public Class listPoli
    '    Public kdPoli() As String
    '    Public nmPoli() As String
    '    Public poliSakit() As Boolean
    'End Class

    'Public Class Poli
    '    Public [property]() As Integer
    '    Public count As Integer
    '    Public list() As listPoli
    'End Class

    Public Sub FungsiGet()
        'Dim uri As String = "https://dvlp.bpjs-kesehatan.go.id:9081/pcare-rest-v3.0/peserta/0000039043765"
        'Dim uri As String = txdefaulturl.Text + txvalueapi.Text
        'Dim consID As String = "12206"
        'Dim secretKey = "5dJ5DB26E5"
        'Dim pcareUname = "0217B090"
        'Dim pcarePWD = "Qweasdzxc!4"
        'Dim kdAplikasi = "095"

        'Dim uri As String = "https://new-api.bpjs-kesehatan.go.id/pcare-rest-v3.0/peserta/" + txvalueapi.Text
        'Dim uri As String = "https://new-api.bpjs-kesehatan.go.id/pcare-rest-v3.0/" + txvalueapi.Text
        'Dim consID As String = "20839"
        'Dim secretKey = "2pH6146451"
        'Dim pcareUname = "Mitra_medicare"
        'Dim pcarePWD = "@Mitra_medicare02"
        'Dim kdAplikasi = "095"



        'Dim uri As String = "https://dvlp.bpjs-kesehatan.go.id/pcare-rest-v3.0/" + txvalueapi.Text
        'Dim uri As String = "http://103.115.164.86/api/gaji.php?tglAwal='20210501'&tglAkhir='20210531'&password=GAJICMH"
        Dim uri As String = "https://new-api.bpjs-kesehatan.go.id/pcare-rest-v3.0/" + txvalueapi.Text
        Dim consID As String = "20839"
        Dim secretKey = "9oXE1B351B"
        'Dim pcareUname = "Mitra_medicare"
        'Dim pcarePWD = "@Mitra_medicare25"
        Dim pcareUname = "0217b098eza"
        Dim pcarePWD = "0217b098ezaA."
        Dim kdAplikasi = "095"

        Dim tgl As Integer = ((DateTime.UtcNow - Convert.ToDateTime("1970-01-01 00:00:00")).TotalSeconds())
        Dim stamp As String = tgl.ToString()

        Dim data As String = consID + "&" + stamp
        Dim data2 As String = pcareUname + ":" + pcarePWD + ":" + kdAplikasi
        Dim encodedSignature As String = HashString(data, secretKey)

        'Authorization
        Dim Authorization = System.Text.Encoding.UTF8.GetBytes(data2)
        Dim encodedAuthorization = Convert.ToBase64String(Authorization)
        encodedAuthorization = System.Web.HttpUtility.UrlEncode(encodedAuthorization)

        Dim str As String = ""
        TextBox2.Text = ""
        Try
            'REQUEST GET METHOD
            Dim webreq As HttpWebRequest = WebRequest.Create(uri)

            webreq.Accept = "application/json"
            webreq.Headers("X-cons-id") = consID
            webreq.Headers("X-timestamp") = stamp
            webreq.Headers("X-signature") = encodedSignature
            webreq.Headers("X-authorization") = "Basic " + encodedAuthorization
            webreq.Method = "GET"

            Dim res As WebResponse = webreq.GetResponse()
            Dim stream As Stream = res.GetResponseStream()
            Dim streamReader As New StreamReader(stream)

            'READ RESPONSE
            str = streamReader.ReadToEnd
            streamReader.Close()

            str = "[" + str + "]"

            TextBox2.Text = str

            'CONVERT RESPONSE FROM JSON TO TEXT THAT WE CAN USE
            'Dim varses() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of ClassJSON())(str)
            'Dim json As String = str
            'Dim list As List(Of Poli) = JsonConvert.DeserializeObject(Of List(Of Poli))(str)
            'Dim varses() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of ClassJSON())(str)
            'Dim varses() = Newtonsoft.Json.JsonConvert.DeserializeObject < List < RootObject >> (Json)
            'RootObject datalist = JsonConvert.DeserializeObject<RootObject>(jsonstring);
            'SHOW RESULT
            'Dim Items = Newtonsoft.Json.JsonConvert.DeserializeObject(Of Poli())(str)
            'Dim MyList = Poli.ToDictionary(Function(x) x.property)
            'Dim Stuff = MyList(96).listofstuff(0)

            'Dim list As List(Of Poli) = JsonConvert.DeserializeObject(Of List(Of Poli))(str)

            'For Each oneVar As ClassJSON In varses
            '    ' Avoid Nothing vars.
            '    If oneVar IsNot Nothing Then
            '        'TextBox2.Text += "User ID = " + oneVar.userId + vbCrLf
            '        'TextBox2.Text += "ID = " + oneVar.id + vbCrLf
            '        'TextBox2.Text += "Title= " + oneVar.title + vbCrLf
            '        'TextBox2.Text += "Completed = " + oneVar.completed + vbCrLf
            '    End If
            'Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Sub fungsiDelete()
        'Dim parameter As String = "{" & _
        '   """kdTindakanSK"" : 0," & _
        '   """noKunjungan"" : ""1301U0070815Y000004""," & _
        '   """kdTindakan"" : ""01007""," & _
        '   """biaya"" : 0," & _
        '   """keterangan"": """"," & _
        '   """hasil"": 0" & _
        '  "}"

        'Dim parameter2 As String = "{" & _
        '   """kdProviderPeserta"" : ""0117U029""," & _
        '   """tglDaftar"" : ""16-03-2020""," & _
        '   """noKartu"" : ""0001648381432""," & _
        '   """kdPoli"" : ""001""," & _
        '   """keluhan"": ""-""," & _
        '   """kunjSakit"": true," & _
        '   """sistole"": 0," & _
        '   """diastole"": 0," & _
        '   """beratBadan"": 0," & _
        '   """tinggiBadan"": 0," & _
        '   """respRate"": 0," & _
        '   """heartRate"": 0," & _
        '   """rujukBalik"": 0," & _
        '   """kdTkp"": ""10""" & _
        '  "}"

        '        Dim param2 As String = "{"kdProviderPeserta" : "0117U029","tglDaftar" : "16-03-2020","noKartu" : "0001648381432",
        '"kdPoli" : "001","keluhan": "-","kunjSakit": true,"sistole": 0,"diastole": 0,"beratBadan": 0,"tinggiBadan": 0,"respRate": 0,"heartRate": 0,"rujukBalik": 0,"kdTkp": "10"}"

        'Dim poststring As String = [String].Format("kdTindakanSK={0}&noKunjungan={1}&kdTindakan={2}&biaya={3}&keterangan={4}&hasil={5}", 0, "1301U0070815Y000004", "01007", 0, Nothing, 0)

        'Dim bytearr() As Byte = Encoding.UTF8.GetBytes(parameter)
        'Dim uri As String = "https://dvlp.bpjs-kesehatan.go.id:9081/pcare-rest-v3.0/tindakan"
        Dim uri As String = "https://dvlp.bpjs-kesehatan.go.id:9081/pcare-rest-v3.0/pendaftaran/peserta/0001261832477/tglDaftar/19-03-2020/noUrut/A1/kdPoli/001"
        Dim consID As String = "12206"
        Dim secretKey = "5dJ5DB26E5"
        Dim pcareUname = "0217B090"
        Dim pcarePWD = "Qweasdzxc!4"
        Dim kdAplikasi = "095"

        Dim tgl As Integer = ((DateTime.UtcNow - Convert.ToDateTime("1970-01-01 00:00:00")).TotalSeconds())
        Dim stamp As String = tgl.ToString()

        Dim data As String = consID + "&" + stamp
        Dim data2 As String = pcareUname + ":" + pcarePWD + ":" + kdAplikasi
        Dim encodedSignature As String = HashString(data, secretKey)

        'Authorization
        Dim Authorization = System.Text.Encoding.UTF8.GetBytes(data2)
        Dim encodedAuthorization = Convert.ToBase64String(Authorization)
        encodedAuthorization = System.Web.HttpUtility.UrlEncode(encodedAuthorization)

        Dim str As String = ""
        TextBox4.Text = ""
        Try
            Dim webreq As HttpWebRequest = WebRequest.Create(uri)

            webreq.Accept = "application/json"
            webreq.Headers("X-cons-id") = consID
            webreq.Headers("X-timestamp") = stamp
            webreq.Headers("X-signature") = encodedSignature
            webreq.Headers("X-authorization") = "Basic " + encodedAuthorization
            webreq.Method = "DELETE"
            'webreq.ContentType = "application/json"
            'webreq.ContentLength = bytearr.Length


            Dim dataStream As Stream = webreq.GetRequestStream()
            'dataStream.Write(bytearr, 0, bytearr.Length)
            dataStream.Close()

            Dim res As WebResponse = webreq.GetResponse()
            Dim stream As Stream = res.GetResponseStream()
            Dim streamReader As New StreamReader(stream)

            'READ RESPONSE
            str = streamReader.ReadToEnd
            streamReader.Close()

            TextBox2.Text = str

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Function ConvertFileToBase64(ByVal fileName As String) As String

        Dim ReturnValue As String = ""

        If My.Computer.FileSystem.FileExists(fileName) Then
            Using BinaryFile As FileStream = New FileStream(fileName, FileMode.Open)
                Dim BinRead As BinaryReader = New BinaryReader(BinaryFile)
                Dim BinBytes As Byte() = BinRead.ReadBytes(CInt(BinaryFile.Length))
                ReturnValue = Convert.ToBase64String(BinBytes)
                BinaryFile.Close()
            End Using
        End If
        Return ReturnValue
    End Function

    Public Function ConvertFileToBase64Part2(ByVal fileName As String) As String
        Return Convert.ToBase64String(System.IO.File.ReadAllBytes(fileName))
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FungsiGetBaru()
        cmbjenis.SelectedIndex = 1
    End Sub

    Public Function HashString2(ByVal StringToHash As String, ByVal HachKey As String) As String
        Dim myEncoder As New System.Text.UTF8Encoding
        Dim Key() As Byte = myEncoder.GetBytes(HachKey)
        Dim Text() As Byte = myEncoder.GetBytes(StringToHash)
        Dim myHMACSHA256 As New System.Security.Cryptography.HMACSHA256(Key)
        Dim HashCode As Byte() = myHMACSHA256.ComputeHash(Text)
        Dim hash As String = Replace(BitConverter.ToString(HashCode), "-", "")
        Return hash.ToLower
    End Function

    Public Shared Function HashString(ByVal StringToHash As String, ByVal secretKey As String) As String
        'Dim hashObject As New System.Security.Cryptography.HMACSHA256(Encoding.UTF8.GetBytes(secretKey))
        'Dim signature = hashObject.ComputeHash(Encoding.UTF8.GetBytes(StringToHash))
        'Dim encodedSignature = Convert.ToBase64String(signature)

        ' Initialize the keyed hash object using the secret key as the key
        Dim hashObject As New HMACSHA256(Encoding.UTF8.GetBytes(secretKey))

        ' Computes the signature by hashing the salt with the secret key as the key
        Dim signature = hashObject.ComputeHash(Encoding.UTF8.GetBytes(StringToHash))

        ' Base 64 Encode
        Dim encodedSignature = Convert.ToBase64String(signature)
        'encodedSignature = System.Web.HttpUtility.UrlEncode(encodedSignature)
        Return encodedSignature
    End Function

    Public Sub GetMethod()
        Dim str As String = ""
        TextBox2.Text = ""
        Try
            'REQUEST GET METHOD
            Dim webreq As HttpWebRequest = WebRequest.Create(txvalueapi.Text)
            Dim res As WebResponse = webreq.GetResponse()
            Dim stream As Stream = res.GetResponseStream()
            Dim streamReader As New StreamReader(stream)

            'READ RESPONSE
            str = streamReader.ReadToEnd
            streamReader.Close()

            'Add [] To Become JSON
            If str.Contains("[") = False And str.Contains("]") = False Then
                str = "[" + str + "]"
            End If


            'CONVERT RESPONSE FROM JSON TO TEXT THAT WE CAN USE
            Dim varses() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of ClassJSON())(str)

            'SHOW RESULT
            For Each oneVar As ClassJSON In varses
                ' Avoid Nothing vars.
                If oneVar IsNot Nothing Then
                    TextBox2.Text += "User ID = " + oneVar.userId + vbCrLf
                    TextBox2.Text += "ID = " + oneVar.id + vbCrLf
                    TextBox2.Text += "Title= " + oneVar.title + vbCrLf
                    TextBox2.Text += "Completed = " + oneVar.completed + vbCrLf
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub



    Public Sub Post2()
        Dim str As String = ""
        TextBox4.Text = ""
        Try
            'REQUEST GET METHOD
            Dim webreq As HttpWebRequest = WebRequest.Create(TextBox3.Text + TextBox5.Text)
            'Dim postData As String = TextBox5.Text
            'Dim data As Byte() = Encoding.UTF8.GetBytes(postData)
            'webreq.Method = "POST"
            'webreq.ContentType = "application/x-www-form-urlencoded"
            'webreq.ContentLength = data.Length

            Dim res As WebResponse = webreq.GetResponse()
            Dim stream As Stream = res.GetResponseStream()
            Dim streamReader As New StreamReader(stream)

            'READ RESPONSE
            str = streamReader.ReadToEnd
            streamReader.Close()

            'Add [] To Become JSON
            If str.Contains("[") = False And str.Contains("]") = False Then
                str = "[" + str + "]"
            End If


            'CONVERT RESPONSE FROM JSON TO TEXT THAT WE CAN USE
            Dim varses() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of ClassJSON())(str)

            'SHOW RESULT
            For Each oneVar As ClassJSON In varses
                ' Avoid Nothing vars.
                If oneVar IsNot Nothing Then
                    TextBox4.Text += "User ID = " + oneVar.userId + vbCrLf
                    TextBox4.Text += "ID = " + oneVar.id + vbCrLf
                    TextBox4.Text += "Title= " + oneVar.title + vbCrLf
                    TextBox4.Text += "Completed = " + oneVar.completed + vbCrLf
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Sub Post()
        '///PENDAFTARAN
        'Dim parameter2 As String = "{" & _
        '   """kdProviderPeserta"" : ""09020107""," & _
        '   """tglDaftar"" : ""22-03-2020""," & _
        '   """noKartu"" : ""0001261832477""," & _
        '   """kdPoli"" : ""001""," & _
        '   """keluhan"": """"," & _
        '   """kunjSakit"": true," & _
        '   """sistole"": 0," & _
        '   """diastole"": 0," & _
        '   """beratBadan"": 0," & _
        '   """tinggiBadan"": 0," & _
        '   """respRate"": 0," & _
        '   """heartRate"": 0," & _
        '   """rujukBalik"": 0," & _
        '   """kdTkp"": ""10""" & _
        '  "}"

        '///PELAYANAN PESERTA
        'Dim parameter2 As String = "{" & _
        '  """noKunjungan"" : ""0217B0900420Y000001""," & _
        '  """noKartu"" : ""0001261832477""," & _
        '  """tglDaftar"" : ""03-04-2020""," & _
        '  """kdPoli"" : null," & _
        '  """keluhan"": ""keluhan""," & _
        '  """kdSadar"": ""01""," & _
        '  """sistole"": 160," & _
        '  """diastole"": 80," & _
        '  """beratBadan"": 89," & _
        '  """tinggiBadan"": 190," & _
        '  """respRate"": 1.3," & _
        '  """heartRate"": 1.4," & _
        '  """terapi"": ""catatan""," & _
        '  """kdStatusPulang"": ""4""," & _
        '  """tglPulang"": ""03-04-2020""," & _
        '  """kdDokter"": ""167273""," & _
        '  """kdDiag1"": ""A01.0""," & _
        '  """kdDiag2"": ""A01.0""," & _
        '  """kdDiag3"": ""A01.0""," & _
        '  """kdPoliRujukInternal"": null," & _
        '  """rujukLanjut"": { " & _
        '        """tglEstRujuk"": ""04-04-2020""," & _
        '        """kdppk"": ""1301R016""," & _
        '        """subSpesialis"": null," & _
        '        """khusus"": { " & _
        '            """kdKhusus"": ""HDL""," & _
        '            """kdSubSpesialis"": null," & _
        '            """catatan"": ""peserta sudah biasa hemodialisa"" } }," & _
        '  """kdTacc"": 0," & _
        '  """alasanTacc"": null" & _
        ' "}"

        '///MCU 
        Dim parameter2 As String = "{" & _
          """kdMCU"" : 0," & _
          """noKunjungan"" : ""0217B0900420Y000004""," & _
          """kdProvider"" : ""0217B090""," & _
          """tglPelayanan"" : ""05-04-2020""," & _
          """tekananDarahSistole"": 120," & _
          """tekananDarahDiastole"": 80," & _
          """radiologiFoto"": null," & _
          """darahRutinHemo"": 0," & _
          """darahRutinLeu"": 0," & _
          """darahRutinErit"": 0," & _
          """darahRutinLaju"": 0," & _
          """darahRutinHema"": 0," & _
          """darahRutinTrom"": 0," & _
          """lemakDarahHDL"": 0," & _
          """lemakDarahLDL"": 0," & _
          """lemakDarahChol"": 0," & _
          """lemakDarahTrigli"": 0," & _
          """gulaDarahSewaktu"": 0," & _
          """gulaDarahPuasa"": 0," & _
          """gulaDarahPostPrandial"": 0," & _
          """gulaDarahHbA1c"": 0," & _
          """fungsiHatiSGOT"": 0," & _
          """fungsiHatiSGPT"": 0," & _
          """fungsiHatiGamma"": 0," & _
          """fungsiHatiProtKual"": 0," & _
          """fungsiHatiAlbumin"": 0," & _
          """fungsiGinjalCrea"": 0," & _
          """fungsiGinjalUreum"": 0," & _
          """fungsiGinjalAsam"": 0," & _
          """fungsiJantungABI"": 0," & _
          """fungsiJantungEKG"": null," & _
          """fungsiJantungEcho"": null," & _
          """funduskopi"": null," & _
          """pemeriksaanLain"": null," & _
          """keterangan"": null" & _
         "}"

        'Dim poststring As String = [String].Format("kdTindakanSK={0}&noKunjungan={1}&kdTindakan={2}&biaya={3}&keterangan={4}&hasil={5}", 0, "1301U0070815Y000004", "01007", 0, Nothing, 0)

        Dim bytearr() As Byte = Encoding.UTF8.GetBytes(parameter2)
        Dim uri As String = "https://dvlp.bpjs-kesehatan.go.id:9081/pcare-rest-v3.0/mcu"
        Dim consID As String = "12206"
        Dim secretKey = "5dJ5DB26E5"
        Dim pcareUname = "0217B090"
        Dim pcarePWD = "Qweasdzxc!4"
        Dim kdAplikasi = "095"

        Dim tgl As Integer = ((DateTime.UtcNow - Convert.ToDateTime("1970-01-01 00:00:00")).TotalSeconds())
        Dim stamp As String = tgl.ToString()

        Dim data As String = consID + "&" + stamp
        Dim data2 As String = pcareUname + ":" + pcarePWD + ":" + kdAplikasi
        Dim encodedSignature As String = HashString(data, secretKey)

        'Authorization
        Dim Authorization = System.Text.Encoding.UTF8.GetBytes(data2)
        Dim encodedAuthorization = Convert.ToBase64String(Authorization)
        encodedAuthorization = System.Web.HttpUtility.UrlEncode(encodedAuthorization)

        Dim str As String = ""
        TextBox4.Text = ""
        Try
            Dim webreq As HttpWebRequest = WebRequest.Create(uri)

            webreq.Accept = "application/json"
            webreq.Headers("X-cons-id") = consID
            webreq.Headers("X-timestamp") = stamp
            webreq.Headers("X-signature") = encodedSignature
            webreq.Headers("X-authorization") = "Basic " + encodedAuthorization

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

            TextBox2.Text = str

            ''Add [] To Become JSON
            'If str.Contains("[") = False And str.Contains("]") = False Then
            '    str = "[" + str + "]"
            'End If


            ''CONVERT RESPONSE FROM JSON TO TEXT THAT WE CAN USE
            'Dim varses() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of container())(str)

            ''SHOW RESULT
            'For Each oneVar As container In varses
            '    ' Avoid Nothing vars.
            '    If oneVar IsNot Nothing Then
            '        TextBox4.Text += "noKartu = " + oneVar.response.noKartu + vbCrLf
            '        TextBox4.Text += "nama = " + oneVar.response.nama + vbCrLf
            '        TextBox4.Text += "hubunganKeluarga = " + oneVar.response.hubunganKeluarga + vbCrLf
            '        TextBox4.Text += "sex = " + oneVar.response.sex + vbCrLf
            '        TextBox4.Text += "tglLahir = " + oneVar.response.tglLahir + vbCrLf
            '        TextBox4.Text += "tglMulaiAktif = " + oneVar.response.tglMulaiAktif + vbCrLf
            '        TextBox4.Text += "tglAkhirBerlaku = " + oneVar.response.tglAkhirBerlaku + vbCrLf

            '        TextBox4.Text += "kdProviderPst (kdProvider) = " + oneVar.response.kdProviderPst.kdProvider + vbCrLf
            '        TextBox4.Text += "kdProviderPst (nmProvider) = " + oneVar.response.kdProviderPst.nmProvider + vbCrLf
            '        TextBox4.Text += "kdProviderGigi (kdProvider) = " + oneVar.response.kdProviderGigi.kdProvider + vbCrLf
            '        TextBox4.Text += "kdProviderGigi (nmProvider) = " + oneVar.response.kdProviderGigi.nmProvider + vbCrLf

            '        TextBox4.Text += "tglLahir (nama)= " + oneVar.response.jnsKelas.nama + vbCrLf
            '        TextBox4.Text += "tglLahir (kode)= " + oneVar.response.jnsKelas.kode + vbCrLf
            '        TextBox4.Text += "jnsPeserta (nama) = " + oneVar.response.jnsPeserta.nama + vbCrLf
            '        TextBox4.Text += "jnsPeserta (kode) = " + oneVar.response.jnsPeserta.kode + vbCrLf
            '        TextBox4.Text += "tglLahir = " + oneVar.response.sex + vbCrLf
            '        TextBox4.Text += "tglLahir = " + oneVar.response.sex + vbCrLf
            '        TextBox4.Text += "tglLahir = " + oneVar.response.sex + vbCrLf
            '        TextBox4.Text += "tglLahir = " + oneVar.response.sex + vbCrLf
            '        TextBox4.Text += "tglLahir = " + oneVar.response.sex + vbCrLf
            '        TextBox4.Text += "tglLahir = " + oneVar.response.sex + vbCrLf
            '        TextBox4.Text += "tglLahir = " + oneVar.response.sex + vbCrLf

            '        'TextBox4.Text += "Title= " + oneVar.title + vbCrLf
            '        'TextBox4.Text += "Completed = " + oneVar.completed + vbCrLf
            '    End If
            'Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Sub PostTextWhatsapp()
        Dim parameter2 As String = "{" & _
          """number"" : ""6289676481272""," & _
          """message"" : """"" & _
         "}"
        Dim bytearr() As Byte = Encoding.UTF8.GetBytes(parameter2)
        Dim uri As String = "http://localhost:4444/send"
        Dim str As String = ""
        TextBox4.Text = ""
        Try
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

            TextBox2.Text = str
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Sub PostPDFWhatsapp()
        Dim TxPDF As String = Convert.ToBase64String(System.IO.File.ReadAllBytes("FileDownload\cie.pdf"))
        Dim NoWhatsapp As String = "6283832400345"
        Dim parameter2 As String = "{" & _
          """number"" : """ & NoWhatsapp & """," & _
          """mime"" : ""application/pdf""," & _
          """src"" : """ & TxPDF & """," & _
          """filename"" : ""20201104L00070_Hasil_Laboratorium.pdf""," & _
          """caption"" : """"," & _
          """thumbnail"" : """"," & _
          """message"" : """"" & _
         "}"
        Dim bytearr() As Byte = Encoding.UTF8.GetBytes(parameter2)
        Dim uri As String = "http://localhost:4444/send-pdf"
        Dim str As String = ""
        TextBox4.Text = ""
        Try
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

            TextBox2.Text = str
            MsgBox("Hasil telah di Whatsapp ke nomor " & NoWhatsapp & ".", MsgBoxStyle.Information, "Success!")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Post()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If cmbjenis.Text = "" Then
            MsgBox("Pilih Jenis yang akan ditampilkan.")
        End If

        If TextBox2.Text = "" Then
            MsgBox("GET data terlebih dahulu.")
        End If

        If cmbjenis.SelectedIndex = 0 Then
            ShowPoli()
        ElseIf cmbjenis.SelectedIndex = 1 Then
            ShowPendaftaran()
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        fungsiDelete()
    End Sub

    Public Sub ShowPoli()
        Try
            'CONVERT RESPONSE FROM JSON TO TEXT THAT WE CAN USE
            Dim varses() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of container())(TextBox2.Text)

            'SHOW RESULT
            'For Each oneVar As container In varses
            '    ' Avoid Nothing vars.
            '    If oneVar IsNot Nothing Then

            '        TextBox4.Text += "Jumlah : " + oneVar.response.count + vbCrLf

            '        TextBox4.Text += "List : " + vbCrLf
            '        For index As Integer = 0 To oneVar.response.count - 1
            '            TextBox4.Text += "KdPoli = " + oneVar.response.list(index).kdPoli + ", NamaPoli " + oneVar.response.list(index).nmPoli + ", PoliSakit = " + oneVar.response.list(index).poliSakit + vbCrLf
            '        Next
            '    End If
            'Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Sub ShowPendaftaran()
        'Dim response As Pendaftaran

        Try
            'CONVERT RESPONSE FROM JSON TO TEXT THAT WE CAN USE
            Dim varses() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of container())(TextBox2.Text)

            'SHOW RESULT
            For Each oneVar As container In varses
                ' Avoid Nothing vars.
                If oneVar IsNot Nothing Then
                    'TextBox4.Text += "Count = " + oneVar.response.count + vbCrLf
                    'TextBox4.Text += "List : " + vbCrLf
                    'For index As Integer = 0 To oneVar.response.count - 1
                    '    TextBox4.Text += "NoUrut = " + oneVar.response.list(index).noUrut + vbCrLf
                    '    TextBox4.Text += "tgldaftar = " + oneVar.response.list(index).tgldaftar + vbCrLf
                    '    TextBox4.Text += "providerPelayanan = " + oneVar.response.list(index).providerPelayanan + vbCrLf
                    '    TextBox4.Text += "noKartu = " + oneVar.response.list(index).peserta.noKartu + vbCrLf
                    '    TextBox4.Text += "nama = " + oneVar.response.list(index).peserta.nama + vbCrLf
                    '    TextBox4.Text += "hubunganKeluarga = " + oneVar.response.list(index).peserta.hubunganKeluarga + vbCrLf
                    '    TextBox4.Text += "sex = " + oneVar.response.list(index).peserta.sex + vbCrLf
                    '    TextBox4.Text += "tglLahir = " + oneVar.response.list(index).peserta.tglLahir + vbCrLf
                    '    TextBox4.Text += "tglMulaiAktif = " + oneVar.response.list(index).peserta.tglMulaiAktif + vbCrLf
                    '    TextBox4.Text += "tglAkhirBerlaku = " + oneVar.response.list(index).peserta.tglAkhirBerlaku + vbCrLf
                    '    TextBox4.Text += "kdProviderPst = " + oneVar.response.list(index).peserta.kdProviderPst + vbCrLf
                    '    TextBox4.Text += "kdProviderGigi = " + oneVar.response.list(index).peserta.kdProviderGigi + vbCrLf
                    '    TextBox4.Text += "jnsKelas = " + oneVar.response.list(index).peserta.jnsKelas + vbCrLf
                    '    TextBox4.Text += "jnsPeserta = " + oneVar.response.list(index).peserta.jnsPeserta + vbCrLf
                    '    TextBox4.Text += "golDarah = " + oneVar.response.list(index).peserta.golDarah + vbCrLf
                    '    TextBox4.Text += "noHP = " + oneVar.response.list(index).peserta.noHP + vbCrLf
                    '    TextBox4.Text += "noKTP = " + oneVar.response.list(index).peserta.noKTP + vbCrLf
                    '    TextBox4.Text += "aktif = " + oneVar.response.list(index).peserta.aktif + vbCrLf
                    '    TextBox4.Text += "ketAktif = " + oneVar.response.list(index).peserta.ketAktif + vbCrLf
                    '    TextBox4.Text += "asuransi = " + oneVar.response.list(index).peserta.asuransi + vbCrLf
                    '    TextBox4.Text += "kdPoli = " + oneVar.response.list(index).poli.kdPoli + vbCrLf
                    '    TextBox4.Text += "nmPoli = " + oneVar.response.list(index).poli.nmPoli + vbCrLf
                    '    TextBox4.Text += "poliSakit = " + oneVar.response.list(index).poli.poliSakit + vbCrLf
                    '    TextBox4.Text += "keluhan = " + oneVar.response.list(index).keluhan + vbCrLf
                    '    TextBox4.Text += "kunjSakit = " + oneVar.response.list(index).kunjSakit + vbCrLf
                    '    TextBox4.Text += "status = " + oneVar.response.list(index).status + vbCrLf
                    '    TextBox4.Text += "sistole = " + oneVar.response.list(index).sistole + vbCrLf
                    '    TextBox4.Text += "diastole = " + oneVar.response.list(index).diastole + vbCrLf
                    '    TextBox4.Text += "beratBadan = " + oneVar.response.list(index).beratBadan + vbCrLf
                    '    TextBox4.Text += "tinggiBadan = " + oneVar.response.list(index).tinggiBadan + vbCrLf
                    '    TextBox4.Text += "respRate = " + oneVar.response.list(index).respRate + vbCrLf
                    '    TextBox4.Text += "heartRate = " + oneVar.response.list(index).heartRate + vbCrLf
                    '    TextBox4.Text += "kdTkp = " + oneVar.response.list(index).tkp.kdTkp + vbCrLf
                    '    TextBox4.Text += "nmTkp = " + oneVar.response.list(index).tkp.nmTkp + vbCrLf
                    'Next
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub tnobpjs_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txnobpjs.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim uri As String = txdefaulturl.Text + "peserta/" + txnobpjs.Text
            Dim consID As String = "12206"
            Dim secretKey = "5dJ5DB26E5"
            Dim pcareUname = "0217B090"
            Dim pcarePWD = "Qweasdzxc!4"
            Dim kdAplikasi = "095"

            Dim tgl As Integer = ((DateTime.UtcNow - Convert.ToDateTime("1970-01-01 00:00:00")).TotalSeconds())
            Dim stamp As String = tgl.ToString()

            Dim data As String = consID + "&" + stamp
            Dim data2 As String = pcareUname + ":" + pcarePWD + ":" + kdAplikasi
            Dim encodedSignature As String = HashString(data, secretKey)

            'Authorization
            Dim Authorization = System.Text.Encoding.UTF8.GetBytes(data2)
            Dim encodedAuthorization = Convert.ToBase64String(Authorization)
            encodedAuthorization = System.Web.HttpUtility.UrlEncode(encodedAuthorization)

            Dim str As String = ""
            TextBox2.Text = ""
            Try
                'REQUEST GET METHOD
                Dim webreq As HttpWebRequest = WebRequest.Create(uri)

                webreq.Accept = "application/json"
                webreq.Headers("X-cons-id") = consID
                webreq.Headers("X-timestamp") = stamp
                webreq.Headers("X-signature") = encodedSignature
                webreq.Headers("X-authorization") = "Basic " + encodedAuthorization
                webreq.Method = "GET"

                Dim res As WebResponse = webreq.GetResponse()
                Dim stream As Stream = res.GetResponseStream()
                Dim streamReader As New StreamReader(stream)

                'READ RESPONSE
                str = streamReader.ReadToEnd
                streamReader.Close()

                str = "[" + str + "]"

                TextBox2.Text = str

                Dim varses() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of container())(str)

                'SHOW RESULT
                For Each oneVar As container In varses
                    ' Avoid Nothing vars.
                    If oneVar IsNot Nothing Then

                        'TextBox4.Text += "tglLahir (nama)= " + oneVar.response.jnsKelas.nama + vbCrLf
                        'txnamapeserta.Text = oneVar.response.nama
                    End If
                Next

            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        'Dim Implementasi As New Implementasi("http://localhost:4444/send")
        'Dim dictData As New Dictionary(Of String, Object)
        'dictData.Add("number", "6289676481272")
        'dictData.Add("message", "TestingCuy")
        'Implementasi.postData(dictData)

        'PostTextWhatsapp()
        PostPDFWhatsapp()

    End Sub

    'Public Function postData(ByVal dictData As Dictionary(Of String, Object)) As Boolean
    '    Dim webClient As New WebClient()
    '    Dim resByte As Byte()
    '    Dim resString As String
    '    Dim reqString() As Byte

    '    Try
    '        webClient.Headers("content-type") = "application/json"
    '        webClient.Headers.Add("apikey", apikey_favoriot)
    '        reqString = Encoding.Default.GetBytes(JsonConvert.SerializeObject(dictData, Formatting.Indented))
    '        resByte = webClient.UploadData(Me.urlToPost, "post", reqString)
    '        resString = Encoding.Default.GetString(resByte)
    '        Console.WriteLine(resString)
    '        webClient.Dispose()
    '        Return True
    '    Catch ex As Exception
    '        Console.WriteLine(ex.Message)
    '    End Try
    '    Return False
    'End Function

    'Public Sub New(ByVal urlToPost As String)
    '    Me.urlToPost = urlToPost
    'End Sub

    Public Sub FungsiGetBaru()
        'Dim uri As String = "https://dvlp.bpjs-kesehatan.go.id:9081/pcare-rest-v3.0/peserta/0000039043765"
        'Dim uri As String = txdefaulturl.Text + txvalueapi.Text
        'Dim consID As String = "12206"
        'Dim secretKey = "5dJ5DB26E5"
        'Dim pcareUname = "0217B090"
        'Dim pcarePWD = "Qweasdzxc!4"
        'Dim kdAplikasi = "095"

        'Dim uri As String = "https://new-api.bpjs-kesehatan.go.id/pcare-rest-v3.0/peserta/" + txvalueapi.Text
        'Dim uri As String = "https://new-api.bpjs-kesehatan.go.id/pcare-rest-v3.0/" + txvalueapi.Text
        'Dim consID As String = "20839"
        'Dim secretKey = "2pH6146451"
        'Dim pcareUname = "Mitra_medicare"
        'Dim pcarePWD = "@Mitra_medicare02"
        'Dim kdAplikasi = "095"



        'Dim uri As String = "https://dvlp.bpjs-kesehatan.go.id/pcare-rest-v3.0/" + txvalueapi.Text
        'Dim uri As String = "http://103.115.164.86/api/gaji.php?tglAwal='20210501'&tglAkhir='20210531'&password=GAJICMH"
        Dim urlPcare As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_base_url'")
        Dim uri As String = urlPcare & "kesadaran"
        Dim consID As String = "14620"
        Dim secretKey = "9oXE1B351B"
        'Dim pcareUname = "Mitra_medicare"
        'Dim pcarePWD = "@Mitra_medicare25"
        Dim pcareUname = "a0217B098"
        Dim pcarePWD = "Gb77505#"
        Dim kdAplikasi = "095"
        Dim userKey = "d6c1110f6cdafd0a24836f56493b53bd"

        Dim tgl As Integer = ((DateTime.UtcNow - Convert.ToDateTime("1970-01-01 00:00:00")).TotalSeconds())
        Dim stamp As String = tgl.ToString()

        Dim data As String = consID + "&" + stamp
        Dim data2 As String = pcareUname + ":" + pcarePWD + ":" + kdAplikasi
        Dim encodedSignature As String = HashString(data, secretKey)

        'Authorization
        Dim Authorization = System.Text.Encoding.UTF8.GetBytes(data2)
        Dim encodedAuthorization = Convert.ToBase64String(Authorization)
        'encodedAuthorization = System.Web.HttpUtility.UrlEncode(encodedAuthorization)

        Dim str As String = ""
        TextBox2.Text = ""
        Try
            'REQUEST GET METHOD
            Dim webreq As HttpWebRequest = WebRequest.Create(uri)

            webreq.Accept = "application/json"
            webreq.Headers("X-cons-id") = consID
            webreq.Headers("X-timestamp") = stamp
            webreq.Headers("X-signature") = encodedSignature
            'webreq.Headers("X-authorization") = encodedAuthorization
            webreq.Headers("X-authorization") = "Basic " + encodedAuthorization
            webreq.Headers("user_key") = userKey
            webreq.Method = "GET"

            'MsgBox(webreq.GetResponse())

            Dim res As WebResponse = webreq.GetResponse()
            Dim stream As Stream = res.GetResponseStream()
            Dim streamReader As New StreamReader(stream)

            'READ RESPONSE
            str = streamReader.ReadToEnd
            streamReader.Close()

            str = "[" + str + "]"

            TextBox2.Text = str

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class
