Imports System.Security.Cryptography
Imports System.Text
Imports System.IO
Imports System.Configuration

Module SecurityHelper

    Private ReadOnly AES_Key As String = ConfigurationManager.AppSettings("AES_Key")
    Private ReadOnly AES_IV As String = ConfigurationManager.AppSettings("AES_IV")

    ' Fungsi Enkripsi
    Public Function EncryptString(ByVal plainText As String) As String
        If String.IsNullOrEmpty(plainText) Then Return ""

        Using aes As New AesManaged()
            aes.Key = Encoding.UTF8.GetBytes(AES_Key)
            aes.IV = Encoding.UTF8.GetBytes(AES_IV)

            Dim encryptor = aes.CreateEncryptor(aes.Key, aes.IV)
            Using ms As New MemoryStream()
                Using cs As New CryptoStream(ms, encryptor, CryptoStreamMode.Write)
                    Using sw As New StreamWriter(cs)
                        sw.Write(plainText)
                    End Using
                End Using
                Return Convert.ToBase64String(ms.ToArray())
            End Using
        End Using
    End Function

    ' Fungsi Dekripsi
    Public Function DecryptString(ByVal cipherText As String) As String
        If String.IsNullOrEmpty(cipherText) Then Return ""

        Using aes As New AesManaged()
            aes.Key = Encoding.UTF8.GetBytes(AES_Key)
            aes.IV = Encoding.UTF8.GetBytes(AES_IV)

            Dim decryptor = aes.CreateDecryptor(aes.Key, aes.IV)
            Dim buffer = Convert.FromBase64String(cipherText)

            Using ms As New MemoryStream(buffer)
                Using cs As New CryptoStream(ms, decryptor, CryptoStreamMode.Read)
                    Using sr As New StreamReader(cs)
                        Return sr.ReadToEnd()
                    End Using
                End Using
            End Using
        End Using
    End Function
End Module
