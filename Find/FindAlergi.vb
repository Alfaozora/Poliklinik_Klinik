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

Public Class FindAlergi
    Private formName As String = "PENCARIAN ALERGI"
    Private TForm As String
    Private NoRekamMedis As String

    Private Class varJson
        Public metaData As MetaData
        Public response As v4_BPJS
    End Class

    Private Sub PanelTop_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelTop.Paint
        Try
            e.Graphics.DrawString(formName, New Font("Arial", 12, FontStyle.Bold), Brushes.White, New Point(10, 10))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub SetForm(ByRef Form As String, ByRef NoRM As String)
        Me.BringToFront()
        TForm = Form
        NoRekamMedis = NoRM
    End Sub

    Private Sub SetComboBox()
        'Dim tblsJenisAlergi As DataTable = New DataTable

        'tblsJenisAlergi = ReadSQL("SELECT JenisAlergi FROM MasterAlergiPasien GROUP BY JenisAlergi")

        'ComboBoxJenisAlergi.DataSource = tblsJenisAlergi
        'ComboBoxJenisAlergi.DisplayMember = "JenisAlergi"

        ' Set the default selected item
        ComboBoxJenisAlergi.SelectedIndex = -1
    End Sub

    Private Sub SetAwal()
        Me.CenterToScreen()
        SetComboBox()
        TextBoxKeterangan.ResetText()
    End Sub

    Private Sub Find_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetAwal()
    End Sub

    Function Checking() As Boolean
        If ComboBoxJenisAlergi.Text = "" Then
            MsgBox("Pilih jenis alergi terlebih dahulu.", MsgBoxStyle.Critical, "Warning!")
            Return False
        End If

        If TextBoxKeterangan.Text = "" Then
            MsgBox("Masukkan keterangan alergi terlebih dahulu.", MsgBoxStyle.Critical, "Warning!")
            Return False
        End If

        'If CheckSQL("SELECT * FROM MasterPasienAlergi WHERE NoRekamMedis = '" & NoRekamMedis & "' AND JenisAlergi = '" & ComboBoxJenisAlergi.Text & "' AND NamaAlergen = '" & ComboBoxAlergen.Text & "'") = True Then
        '    MsgBox("Tidak bisa input dengan jenis dan alergen yang sama.", MsgBoxStyle.Exclamation, "Warning!")
        '    Return False
        'End If

        Return True
    End Function

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    'Private Sub ComboBoxJenisAlergi_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxJenisAlergi.SelectedIndexChanged
    '    Dim tblsAlergen As DataTable = New DataTable

    '    tblsAlergen = ReadSQL("SELECT NamaAlergen FROM MasterAlergiPasien WHERE JenisAlergi = '" & ComboBoxJenisAlergi.Text & "'")

    '    ComboBoxAlergen.DataSource = tblsAlergen
    '    ComboBoxAlergen.DisplayMember = "NamaAlergen"
    'End Sub

    Private Sub ButtonSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSave.Click
        Try
            If Checking() = True Then
                'Dim jenisAlergi As String = ComboBoxJenisAlergi.Text
                'Dim alergen As String = ComboBoxAlergen.Text
                'Dim keteranganAlergi As String = TextBoxKeterangan.Text

                'WriteSQL("INSERT INTO MasterPasienAlergi (NoRekamMedis, JenisAlergi, Keterangan) values ('" & NoRekamMedis & "', '" & jenisAlergi & "', '" & keteranganAlergi & "')", 4)

                'Select Case TForm
                '    Case "RekamMedisAlergi"
                '        FormRekamMedisDokter.LoadGridAlergiPasien()
                'End Select

                'MsgBox("Berhasil menyimpan data.", MsgBoxStyle.Information, "Success!")
                'Me.Close()

                Dim jenisAlergi As String = ComboBoxJenisAlergi.Text
                Dim keteranganAlergi As String = TextBoxKeterangan.Text

                If CheckSQL("SELECT * FROM MasterPasienAlergi WHERE NoRekamMedis = '" & NoRekamMedis & "' AND JenisAlergi = '" & ComboBoxJenisAlergi.Text & "'") = True Then
                    WriteSQL("UPDATE MasterPasienAlergi SET Keterangan = '" & keteranganAlergi & "' WHERE NoRekamMedis = '" & NoRekamMedis & "' AND JenisAlergi = '" & ComboBoxJenisAlergi.Text & "'", 4)
                Else
                    WriteSQL("INSERT INTO MasterPasienAlergi (NoRekamMedis, JenisAlergi, Keterangan) values ('" & NoRekamMedis & "', '" & jenisAlergi & "', '" & keteranganAlergi & "')", 4)
                End If

                Select Case TForm
                    Case "RekamMedisAlergi"
                        FormRekamMedisDokter.LoadGridAlergiPasien()
                End Select

                Me.Close()
                MsgBox("Berhasil menyimpan data.", MsgBoxStyle.Information, "Success!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ComboBoxJenisAlergi_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxJenisAlergi.SelectedIndexChanged
        Dim keteranganAlergi As String = ReadSQLNIK("SELECT Keterangan FROM MasterPasienAlergi WHERE NoRekamMedis = '" & NoRekamMedis & "' AND JenisAlergi = '" & ComboBoxJenisAlergi.Text & "'")

        TextBoxKeterangan.Text = keteranganAlergi
    End Sub
End Class