Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Linq
Imports Newtonsoft.Json
Imports Newtonsoft
Imports System.Security.Cryptography
Imports System.Collections.Generic
Imports Newtonsoft.Json.Linq
Imports System.Drawing.Imaging
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraPrinting.Drawing
Imports PoliKlinik_Net2.ShapeDrawingFunctions
Imports System.Text
Imports System.Globalization
Imports System.Net
Public Class KYC
    Private urlVerifikasi As String = ""

    Private Function ExtractUrlFromResponse(ByVal json As String) As String
        Dim key As String = """url"":"
        Dim startIndex As Integer = json.IndexOf(key)
        If startIndex < 0 Then Return ""

        startIndex += key.Length
        While startIndex < json.Length AndAlso (json(startIndex) = " "c Or json(startIndex) = """"c)
            startIndex += 1
        End While

        Dim endIndex As Integer = json.IndexOf("""", startIndex)
        If endIndex < 0 Then Return ""

        Return json.Substring(startIndex, endIndex - startIndex)
    End Function

    Private Sub LoadComboBoxNama()
        ComboBoxNama.Items.Clear()

        Dim sql As String = "SELECT UserNama FROM Users WHERE GroupID = 'Reception' AND UserNama NOT LIKE '%admin%' ORDER BY UserNama"
        Dim user As DataTable = ReadSQL(sql)

        If user.Rows.Count > 0 Then
            For Each row As DataRow In user.Rows
                ComboBoxNama.Items.Add(row("UserNama").ToString())
            Next

            'ComboBoxNama.SelectedIndex = 0
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        LoadComboBoxNama()
    End Sub

    Private Sub TextBoxNIK_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TextBoxNIK.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub ButtonKirimAPI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonKirimAPI.Click
        ' Validasi Input
        If TextBoxNIK.Text.Trim() = "" Then
            MsgBox("NIK verifikator belum diisi.", MsgBoxStyle.Exclamation, "Validasi")
            Exit Sub
        End If

        Dim nikPattern As String = "^\d{16}$"
        If Not System.Text.RegularExpressions.Regex.IsMatch(TextBoxNIK.Text.Trim(), nikPattern) Then
            MsgBox("NIK harus terdiri dari 16 digit angka.", MsgBoxStyle.Exclamation, "Validasi Format NIK")
            Exit Sub
        End If

        If ComboBoxNama.SelectedItem Is Nothing OrElse ComboBoxNama.Text.Trim() = "" Then
            MsgBox("Silakan pilih nama verifikator.", MsgBoxStyle.Exclamation, "Validasi")
            Exit Sub
        End If

        Dim NIK As String = TextBoxNIK.Text.Trim()
        Dim namaVerifikator As String = ComboBoxNama.Text.Trim()

        Dim dtUrl As DataTable = ReadSQL("SELECT StrValue FROM MsConfig WHERE ConfigName = 'satu_sehat_url_kyc'")
        Dim privateKey As DataTable = ReadSQL("SELECT StrValue FROM MsConfig WHERE ConfigName = 'satu_sehat_key_api'")

        If dtUrl.Rows.Count = 0 Then
            MsgBox("URL API SATUSEHAT belum disetting di MsConfig.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If privateKey.Rows.Count = 0 Then
            MsgBox("Private Key API belum disetting di MsConfig.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim apiUrl As String = dtUrl.Rows(0)("StrValue").ToString()
        Dim keyApi As String = privateKey.Rows(0)("StrValue").ToString()

        Try
            Dim client As New System.Net.WebClient()
            client.Headers(HttpRequestHeader.ContentType) = "application/json"

            Dim jsonBody As String = "{""NoNIKVerifikator"":""" & NIK & """, ""NamaVerifikator"":""" & namaVerifikator & """, ""PrivateKey"":""" & keyApi & """}"
            Dim response As String = client.UploadString(apiUrl, "POST", jsonBody)

            'Ambil url dari hasil response JSON
            Dim jsonResult As Object = Newtonsoft.Json.JsonConvert.DeserializeObject(response)
            urlVerifikasi = jsonResult("response")("data")("url").ToString()

            MsgBox("Data berhasil dikirim. Klik tombol verifikasi untuk membuka halaman." & vbCrLf , MsgBoxStyle.Information)

            'MsgBox("Data berhasil dikirim. Klik tombol verifikasi untuk membuka halaman." & vbCrLf & _
            '"URL Verifikasi:" & vbCrLf & urlVerifikasi, MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox("Gagal mengirim data ke API: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub ButtonVerifikasi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonVerifikasi.Click
        If Not String.IsNullOrEmpty(urlVerifikasi) Then
            Try
                Process.Start(urlVerifikasi)
            Catch ex As Exception
                MsgBox("Gagal membuka browser: " & ex.Message, MsgBoxStyle.Critical)
            End Try
        Else
            MsgBox("URL verifikasi belum tersedia. Kirim data terlebih dahulu.", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub VerifikasiProfil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VerifikasiProfil.Click
        Dim url As String = "https://drive.google.com/uc?export=view&id=1HOb8-b_nD7U01LJuYMklq0YqD5z6CyEL"
        Process.Start(url)
    End Sub

    Private Sub GetKodeAkses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GetKodeAkses.Click
        Dim url As String = "https://drive.google.com/uc?export=view&id=1p3NJuZFnaRGNT6WGTQ-nkpmBdwCirGFY"
        Process.Start(url)
    End Sub
End Class