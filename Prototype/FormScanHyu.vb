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
Imports System.Text.RegularExpressions
Public Class FormScanHyu

    Private Sub ButtonSubmitQR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSubmitQR.Click
        If String.IsNullOrEmpty(TextBoxQrHyu.Text.Trim()) Then
            MessageBox.Show("Silakan scan atau masukkan QR Code terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextBoxQrHyu.Focus()
            Exit Sub
        End If

        Dim urlWebService As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
        Dim url As String = urlWebService & "api/mcu/check-in/decode"

        Dim jsonParameter As String = "{""qr_code"": """ & TextBoxQrHyu.Text.Trim() & """}"

        Try
            Dim jsonResult As String = InsertDataAPIRM(jsonParameter, url)

            Dim jObj As JObject = JObject.Parse(jsonResult)

            If jObj("success") IsNot Nothing AndAlso CBool(jObj("success")) = True Then

                Dim nik As String = jObj("data")("nik").ToString()

                TextBoxDecodeHyu.Text = nik

                FormCetakBarcode.Show()
                FormCetakBarcode.BringToFront()

                'MessageBox.Show("Data NIK berhasil diambil!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Dim message As String = "Gagal memproses data."
                If jObj("message") IsNot Nothing Then
                    message = jObj("message").ToString()
                End If
                MessageBox.Show("Respon Server Gagal: " & message, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan sistem atau format JSON tidak sesuai: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCopy.Click
        If Not String.IsNullOrEmpty(TextBoxDecodeHyu.Text.Trim()) Then
            Clipboard.SetText(TextBoxDecodeHyu.Text.Trim())
            'MessageBox.Show("NIK berhasil disalin ke clipboard!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Tidak ada teks NIK yang bisa disalin.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
        TextBoxQrHyu.Clear()
        TextBoxDecodeHyu.Clear()
        TextBoxQrHyu.Focus()
    End Sub
End Class