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
Imports System.Web.UI.WebControls

Public Class FormInputKondisiAwalGigi
    Private formName As String = "FORM INPUT KONDISI AWAL GIGI"
    Private TForm As String
    Private nomorRM As String
    Private userInput As String = PoliKlinik.Lbluser.Text

    Private Class varJson
        Public metaData As MetaData
        Public response As String
        Public count As String
        Public list() As JSON_result

        Public Class JSON_result
            Public kdDiag As String
            Public nmDiag As String
            Public nonSpesialis As String
        End Class
    End Class

    Private Sub PanelTop_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelTop.Paint
        Try
            e.Graphics.DrawString(formName, New Font("Arial", 12, FontStyle.Bold), Brushes.White, New Point(10, 10))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Find_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetAwal()
    End Sub

    Private Sub SetAwal()
        Me.CenterToScreen()

        TextBoxKondisi.Select()
        TextBoxKondisi.ResetText()
        ComboBoxStatus.SelectedIndex = -1
    End Sub

    Function Checking() As Boolean
        '# Cek Inputan kondisi & status
        If TextBoxKondisi.Text.Length = 0 Then
            MsgBox("Cek inputan kondisi/status.", MsgBoxStyle.Exclamation, "Warning!")

            Return False
        End If

        '# Cek Inputan Bulan
        'If ComboBoxBulan.Text <> "" Then
        '    If ComboBoxBulan.FindStringExact(ComboBoxBulan.Text) < 0 Then
        '        MsgBox("Cek inputan bulan lahir.", MsgBoxStyle.Exclamation, "Warning!")

        '        Return False
        '    End If
        'End If

        Return True
    End Function

    Private Sub ButtonSimpanData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSimpanData.Click
        SaveData()
    End Sub

    Public Sub SetForm(ByRef Form As String, ByRef txNomorGigi As String, ByRef txNoRekamMedis As String)
        Me.BringToFront()
        TForm = Form
        nomorRM = txNoRekamMedis
        SetDataGigi(txNomorGigi)
    End Sub

    Private Sub SetDataGigi(ByRef txNomorGigi As String)
        Dim Tbls As DataTable = ReadSQL("SELECT * FROM MasterOdontogram WHERE NomorGigi = '" & txNomorGigi & "'")

        For Each Trow As DataRow In Tbls.Rows
            TextBoxNomorGigi.Text = Trow("NomorGigi").ToString()
            TextBoxNamaGigi.Text = Trow("NamaGigi").ToString()
            TextBoxKeterangan.Text = Trow("KeteranganGigi").ToString()
        Next
    End Sub

    Private Sub SaveData()
        If Checking() = True Then
            ' Save ke tabel PerlakuanGigi
            WriteSQL("INSERT INTO PerlakuanGigi (CustID, GigiID, Kondisi, Status, CreatedBy, CreatedDate) " & _
                     "VALUES('" & nomorRM & "', '" & TextBoxNomorGigi.Text & "', '" & TextBoxKondisi.Text & "', '" & ComboBoxStatus.Text & "', '" & userInput & "', GETDATE())", 4)

            Select Case TForm
                Case "RekamMedisDokterKondisiAwalGigi"
                    'FormRekamMedisDokter.LoadGridKondisiAwalGigi()
            End Select

            Me.Close()
        End If
    End Sub

    Private Sub ComboBoxStatusKeluarga_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ComboBoxStatus.Validating
        If Not IsComboBoxItemValid(DirectCast(sender, System.Windows.Forms.ComboBox)) Then
            MsgBox("Data yang dimasukkan tidak valid. Silakan pilih item dari daftar yang tersedia.", MsgBoxStyle.Exclamation, "Warning!")
            e.Cancel = True
        End If
    End Sub
End Class