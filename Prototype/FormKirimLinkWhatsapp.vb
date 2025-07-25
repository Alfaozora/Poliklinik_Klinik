Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Drawing
Imports Newtonsoft.Json
Imports Newtonsoft
Imports System.Security.Cryptography
Imports System.Collections.Generic
Imports Newtonsoft.Json.Linq

Public Class FormKirimLinkWhatsapp
    Dim thread As System.Threading.Thread
    Private TForm As String
    Private NoRekamMedis As String

    Private Class varJson
        Public metaData As MetaData
        Public response As v4_BPJS
    End Class

    Private Sub PanelTop_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelTop.Paint
        Try
            e.Graphics.DrawString("Kirim Whatsapp", New Font("Segoe UI Semibold", 15, FontStyle.Bold), Brushes.White, New Point(0, 0))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub SetForm(ByRef Form As String, ByRef NoRM As String)
        Me.BringToFront()
        TForm = Form
        NoRekamMedis = NoRM
    End Sub

    Private Sub SetAwal()
        Me.CenterToScreen()
        RadioButtonNoBebas.Checked = True
        TextBoxNomorWhatsapp.ResetText()
    End Sub

    Private Sub Find_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
        SetAwal()
    End Sub

    Function Checking() As Boolean
        'If CheckSQL("SELECT * FROM MasterPasienAlergi WHERE NoRekamMedis = '" & NoRekamMedis & "' AND JenisAlergi = '" & ComboBoxJenisAlergi.Text & "' AND NamaAlergen = '" & ComboBoxAlergen.Text & "'") = True Then
        '    MsgBox("Tidak bisa input dengan jenis dan alergen yang sama.", MsgBoxStyle.Exclamation, "Warning!")
        '    Return False
        'End If

        Return True
    End Function

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub ButtonSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSave.Click
        Try
            If Checking() = True Then

                thread = New System.Threading.Thread(AddressOf sendingwhatsappcust)
                thread.Start()

                Select Case TForm
                    Case "KirimWhatsappGeneralConsent"
                        'FormRekamMedisDokter.LoadAlergi(NoRekamMedis)
                End Select

                MsgBox("Berhasil menyimpan data.", MsgBoxStyle.Information, "Success!")
                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub sendingwhatsappcust()
        Try
            Dim Tloc As String = ReadSQLNIK("select StrValue  from MsConfig where ConfigName='NoPoli'")
            Dim NoWhatsapp As String = TextBoxNomorWhatsapp.Text


            If Strings.Left(NoWhatsapp, 2) = "08" Then NoWhatsapp = "62" & NoWhatsapp.Substring(1, NoWhatsapp.Length - 1)

            Dim TIP_Whatsapp As String = ReadSQLNIK("select StrValue from MsConfig where ConfigName='TIP_Whatsapp'")
            Dim TxPDF As String = ""
            Dim filename As String = ""
            Dim parameter As String = ""
            Dim uri As String = ""
            Dim uri_message As String = ""
            Dim StatsSending As String = ""

            If NoWhatsapp.Contains(",") = False Or NoWhatsapp = "-" Then
                parameter = SetParameterWhatsappKlinik(NoWhatsapp, TxPDF, filename, "Yes")

                uri = "http://" & TIP_Whatsapp & ":4444/send-pdf"
                uri_message = "http://" & TIP_Whatsapp & ":4444/send"

                StatsSending = SendDataWhatsapp(parameter, uri_message)
            End If

            If StatsSending = "Success" Then
                MsgBox("Berhasil mengirim Whatsapp ke " & NoWhatsapp.Trim & ".", MsgBoxStyle.Information, "Success!")
            ElseIf StatsSending = "Nothing" Then
                MsgBox("Gagal Mengirim Whatsapp ke " & NoWhatsapp.Trim & ". Cek koneksi jaringan atau hubungi IT untuk restart server Whatsapp.", MsgBoxStyle.Exclamation, "Warning!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class