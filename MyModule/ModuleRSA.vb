Imports System
Imports System.Security.Cryptography
Imports System.Text
Imports System.Text.RegularExpressions

Module ModuleRSA
    Sub Main()
        ' Public Key dalam Format PEM
        Dim pemPublicKey As String = "-----BEGIN PUBLIC KEY-----" & vbCrLf & _
            "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAwqoicEXIYWYV3PvLIdvB" & vbCrLf & _
            "qFkHn2IMhPGKTiB2XA56enpPb0UbI9oHoetRF41vfwMqfFsy5Yd5LABxMGyHJBbP" & vbCrLf & _
            "+3fk2/PIfv+7+9/dKK7h1CaRTeT4lzJBiUM81hkCFlZjVFyHUFtaNfvQeO2OYb7U" & vbCrLf & _
            "kK5JrdrB4sgf50gHikeDsyFUZD1o5JspdlfqDjANYAhfz3aam7kCjfYvjgneqkV8" & vbCrLf & _
            "pZDVqJpQA3MHAWBjGEJ+R8y03hs0aafWRfFG9AcyaA5Ct5waUOKHWWV9sv5DQXmb" & vbCrLf & _
            "EAoqcx0ZPzmHJDQYlihPW4FIvb93fMik+eW8eZF3A920DzuuFucpblWU9J9o5w+2" & vbCrLf & _
            "oQIDAQAB" & vbCrLf & _
            "-----END PUBLIC KEY-----"

        ' Konversi PEM ke XML
        Dim xmlPublicKey As String = ConvertPEMToXML(pemPublicKey)

        ' Inisialisasi RSA
        Dim rsa As New RSACryptoServiceProvider()
        rsa.FromXmlString(xmlPublicKey)

        ' Data yang akan dienkripsi
        Dim plainText As String = "Hello, ini data rahasia"
        Dim encryptedData As Byte() = rsa.Encrypt(Encoding.UTF8.GetBytes(plainText), False)

        ' Convert hasil enkripsi ke Base64 agar bisa dikirim
        Dim encryptedBase64 As String = Convert.ToBase64String(encryptedData)

        ' Tampilkan hasil
        Console.WriteLine("Encrypted Data: " & encryptedBase64)
        Console.ReadLine()
    End Sub

    ' Fungsi untuk konversi Public Key dari PEM ke XML
    Function ConvertPEMToXML(ByVal pem As String) As String
        ' Hapus header dan footer dari PEM
        Dim pemBody As String = Regex.Replace(pem, "-----.*?-----", "").Replace(vbCr, "").Replace(vbLf, "")

        ' Konversi Base64 ke Byte Array
        Dim keyBytes As Byte() = Convert.FromBase64String(pemBody)

        ' Ambil Modulus dan Eksponen dari Key ASN.1
        Dim modulus As Byte() = keyBytes.Skip(29).Take(128).ToArray()
        Dim exponent As Byte() = keyBytes.Skip(159).Take(3).ToArray()

        ' Konversi ke Base64 untuk format XML
        Dim modulusBase64 As String = Convert.ToBase64String(modulus)
        Dim exponentBase64 As String = Convert.ToBase64String(exponent)

        ' Format XML Public Key
        Return "<RSAKeyValue><Modulus>" & modulusBase64 & "</Modulus><Exponent>" & exponentBase64 & "</Exponent></RSAKeyValue>"
    End Function
End Module
