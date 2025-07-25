Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports System.IO
Imports System.Text
Imports System.Net.Mail
Imports System.Net
Imports System.Net.Sockets
Imports System.Object
Imports Newtonsoft.Json
Imports Newtonsoft
Imports System.Security.Cryptography
Imports System.Collections.Generic
Imports Newtonsoft.Json.Linq

Public Class FormAutoSendingWhatsapp

    Dim Fcon As New TLcon
    Private Ttcmh As Find.TLconnect
    Dim thread As System.Threading.Thread
    Private NoWhatsapp As String = ""
    Private Email As String = ""
    Private NameFile As String = ""
    Private SendingID As String = ""

    Private Sub FormAutoSendingWhatsapp_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim Tbls As DataTable = ReadSQL("select top 1 * from LogSendingWhatsappEmail where SendingStatus is null order by SendingID asc")
        If Tbls.Rows.Count > 0 Then
            jumlahsending.Text = ReadSQLNIK("select count(SendingID) from LogSendingWhatsappEmail where SendingStatus is null")
            keterangansending.Text = "Sending data..."
            For Each Rrow As DataRow In Tbls.Rows
                WriteSQL("update LogSendingWhatsappEmail set SendingStatus=1 where SendingID = '" & Rrow("SendingID").ToString.Trim & "'", 4)
                If Rrow("SendingJenis").ToString.Trim = "Email" Then
                    Email = Rrow("SendingTujuan").ToString.Trim
                    NameFile = Rrow("SendingNamaFile").ToString.Trim
                    SendingID = Rrow("SendingID").ToString.Trim
                    thread = New System.Threading.Thread(AddressOf sendingemailcust)
                    thread.Start()
                    'sendingemailcust()
                ElseIf Rrow("SendingJenis").ToString.Trim = "Whatsapp" Then

                End If
            Next
        Else
            jumlahsending.Text = 0
            keterangansending.Text = "Tidak ada data yang disending."
        End If
    End Sub

    Public Sub sendingemailcust()
        Try
            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential("info@cahayamedika.co.id", "cahayamedika2020!")
            Smtp_Server.Port = 587
            Smtp_Server.EnableSsl = True
            Smtp_Server.Host = "smtp.gmail.com"

            e_mail = New MailMessage()
            e_mail.From = New MailAddress("info@cahayamedika.co.id")
            e_mail.To.Add("" & Email & "")
            e_mail.Subject = NameFile
            e_mail.IsBodyHtml = False
            e_mail.Body = "Kepada Yth." & vbCr & vbLf + "" & _
              "Customer Cahaya Diagnostic Centre" & vbCr & vbLf & vbCr & vbLf + "" & _
              "Kami mengucapkan terima kasih atas kepercayaan Bapak/Ibu/Saudara/i sudah melakukan pemeriksaan di Laboratorium Cahaya Diagnostic Centre. Berikut ini kami lampirkan hasil pemeriksaan laboratorium anda." & vbCr & vbLf & vbCr & vbLf + "" & _
              "Silahkan menghubungi kami di nomor 081230885004 (WA/Phone) atau email ke cahayadiagnosticcentre@gmail.com untuk konsultasi lebih lanjut." & vbCr & vbLf & vbCr & vbLf + "" & _
              "Kami menyampaikan beberapa hal yang perlu diperhatikan oleh saudara/i, antara lain:" & vbCr & vbLf + "" & _
              "1. Tetap menjaga jarak dengan orang lain (Physical Distancing)." & vbCr & vbLf + "" & _
              "2. Selalu menggunakan masker saat keluar dari rumah." & vbCr & vbLf + "" & _
              "3. Rajin mencuci & menjaga kebersihan tangan." & vbCr & vbLf + "" & _
              "4. Makan makanan yang bergizi & bila perlu minum suplemen atau vitamin." & vbCr & vbLf + "" & _
              "5. Etika batuk yang baik & benar." & vbCr & vbLf & vbCr & vbLf + "" & _
              "Best regards," & vbCr & vbLf & vbCr & vbLf + "" & _
              "Laboratorium Cahaya Diagnostic Centre."
            e_mail.Attachments.Add(New Attachment("FileDownload\Hasil\" & NameFile & "" & ".pdf"))
            Smtp_Server.Send(e_mail)

            'WriteSQL("update LogSendingWhatsappEmail set SendingStatus=1 where SendingID='" & SendingID & "'", 4)
        Catch ex As Exception
            WriteSQL("update LogSendingWhatsappEmail set SendingStatus=NULL where SendingID='" & SendingID & "'", 4)
            MsgBox(ex.Message)
        End Try
    End Sub
End Class

