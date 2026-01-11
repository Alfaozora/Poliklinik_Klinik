Imports System.Net
Imports System.IO
Imports System.Text
Imports System.Web.Script.Serialization

Module ICDAsistenHelper

    Public Function CallLocalICDML(ByVal keluhan As String) As String
        Try
            Dim req As HttpWebRequest
            req = DirectCast(WebRequest.Create("http://127.0.0.1:5000/predict"), HttpWebRequest)

            req.Method = "POST"
            req.ContentType = "application/json"
            req.Timeout = 5000

            Dim json As String = "{""keluhan"":""" & keluhan.Replace("""", "'") & """}"
            Dim data() As Byte = Encoding.UTF8.GetBytes(json)

            req.ContentLength = data.Length

            Using stream As Stream = req.GetRequestStream()
                stream.Write(data, 0, data.Length)
            End Using

            Dim resp As HttpWebResponse = DirectCast(req.GetResponse(), HttpWebResponse)

            Using reader As New StreamReader(resp.GetResponseStream())
                Return reader.ReadToEnd()
            End Using

        Catch ex As WebException
            Return "ERROR WEB: " & ex.Message

        Catch ex As Exception
            Return "ERROR: " & ex.Message
        End Try
    End Function

    Public Function GetNamaICD(ByVal kodeICD As String) As String
        Try
            Dim nama As String = ReadSQLNIK( _
                "SELECT TOP 1 name_id " & _
                "FROM MasterICDX " & _
                "WHERE code = '" & kodeICD & "'")

            If nama.Trim() = "" Then
                Return ""
            End If

            Return nama

        Catch
            Return ""
        End Try
    End Function

    Public Function FormatICDResult(ByVal json As String) As String
        Try
            Dim serializer As New JavaScriptSerializer()
            Dim obj = serializer.Deserialize(Of Object)(json)

            Dim hasil As String = "Saran Diagnosa (ML):" & vbCrLf & vbCrLf

            ' ======================
            ' PRIMARY
            ' ======================
            Dim primary = obj("primary")
            Dim codeUtama As String = primary("code").ToString()
            Dim namaUtama As String = GetNamaICD(codeUtama)
            Dim confUtama As Double = CDbl(primary("confidence")) * 100

            hasil &= "✔ " & codeUtama

            If namaUtama <> "" Then
                hasil &= " – " & namaUtama
            End If

            hasil &= " (" & Math.Round(confUtama) & "%)" & vbCrLf & vbCrLf

            ' ======================
            ' ALTERNATIVES
            ' ======================
            hasil &= "Alternatif:" & vbCrLf
            Dim alts = obj("alternatives")

            If alts IsNot Nothing Then
                For Each alt In alts
                    Dim c As String = alt("code").ToString()
                    Dim nama As String = GetNamaICD(c)
                    Dim conf As Double = CDbl(alt("confidence")) * 100

                    hasil &= "• " & c

                    If nama <> "" Then
                        hasil &= " – " & nama
                    End If

                    hasil &= " (" & Math.Round(conf) & "%)" & vbCrLf
                Next
            End If

            ' ======================
            ' CONFIDENCE RULE
            ' ======================
            If confUtama < 20 Then
                hasil &= vbCrLf & "(Confidence rendah, saran kurang kuat)"
            ElseIf confUtama < 40 Then
                hasil &= vbCrLf & "(Perlu konfirmasi lebih lanjut)"
            End If

            Return hasil.Trim()

        Catch
            Return "-"
        End Try
    End Function
End Module
