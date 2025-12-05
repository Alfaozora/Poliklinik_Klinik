Imports System.Text
Imports System.Net
Imports System.IO



Public Class FormBase64
    Private Sub ButtonGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGo.Click
        Dim inputText As String = TextBoxInput.Text.Trim()

        Try
            If RdEncode.Checked Then
                ' Encode ke Base64
                Dim plainBytes As Byte() = Encoding.UTF8.GetBytes(inputText)
                Dim base64String As String = Convert.ToBase64String(plainBytes)
                TextBoxOutput.Text = base64String

            ElseIf RdDecode.Checked Then
                ' Decode dari Base64
                Dim decodedBytes As Byte() = Convert.FromBase64String(inputText)
                Dim decodedString As String = Encoding.UTF8.GetString(decodedBytes)
                TextBoxOutput.Text = decodedString

            Else
                MessageBox.Show("Pilih dulu Encode atau Decode.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

        Catch ex As Exception
            MessageBox.Show("Terjadi error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonClr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClr.Click
        TextBoxInput.ResetText()
        TextBoxOutput.ResetText()
    End Sub


    Private Sub CekTLS()
        Dim url As String = "http://platform.mitramedicare.com/"
        Dim hasil As String = ""

        ' Daftar protokol yang akan dites
        Dim protokol() As SecurityProtocolType = {CType(192, SecurityProtocolType), CType(768, SecurityProtocolType), CType(3072, SecurityProtocolType)}

        Dim namaProtokol() As String = {"SSL 3.0", "TLS 1.0", "TLS 1.2"}

        For i As Integer = 0 To protokol.Length - 1
            Try
                ServicePointManager.SecurityProtocol = protokol(i)

                Dim req As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
                req.Method = "GET"
                req.Timeout = 5000
                Dim res As HttpWebResponse = CType(req.GetResponse(), HttpWebResponse)

                hasil &= namaProtokol(i) & " : SUKSES (HTTP " & res.StatusCode & ")" & vbCrLf
                res.Close()
            Catch ex As Exception
                hasil &= namaProtokol(i) & " : GAGAL (" & ex.Message & ")" & vbCrLf
            End Try
        Next

        MsgBox(hasil, MsgBoxStyle.Information, "Hasil Cek TLS")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        CekTLS()
    End Sub

    Private Sub ButtonAPI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAPI.Click
        Dim client As New WebClient()
        client.Headers.Add("Content-Type", "application/json")
        Dim json = "{""angka"": 5}"
        Dim result = client.UploadString("http://localhost:5000/prediksi", json)
        MsgBox(result)
    End Sub
End Class