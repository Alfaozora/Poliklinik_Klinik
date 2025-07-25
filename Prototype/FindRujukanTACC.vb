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

Public Class FindRujukanTACC
    Private formName As String = "FORM TACC"
    Private TForm As String

    Private Sub PanelTop_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelTop.Paint
        Try
            e.Graphics.DrawString(formName, New Font("Arial", 12, FontStyle.Bold), Brushes.White, New Point(10, 10))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub SetForm(ByRef Form As String)
        Me.BringToFront()
        TForm = Form
    End Sub

    Private Sub SetClear()
        RadioButtonTime.Checked = False
        RadioButtonAge.Checked = False
        RadioButtonComplication.Checked = False
        RadioButtonComorbidity.Checked = False

        SplitContainerRujukanTACC.Panel2Collapsed = True
        SplitContainerDetailTACC.Panel2Collapsed = True

        RadioButtonTanpaTACC.Checked = True
    End Sub

    Private Sub SetClearDetailTACC()
        ' Time
        RadioButtonTimeOption1.Checked = False
        RadioButtonTimeOption2.Checked = False
        RadioButtonTimeOption3.Checked = False

        ' Age
        RadioButtonAgeOption1.Checked = False
        RadioButtonAgeOption2.Checked = False
        RadioButtonAgeOption3.Checked = False
        RadioButtonAgeOption4.Checked = False
        RadioButtonAgeOption5.Checked = False
        RadioButtonAgeOption6.Checked = False

        ' Complication
        TextBoxKodeDiagnosaComplication.ResetText()
        TextBoxKeteranganDiagnosaComplication.ResetText()

        ' Comorbidity
        TextBoxKodeDiagnosaComorbidity.ResetText()
        TextBoxKeteranganDiagnosaComorbidity.ResetText()
    End Sub

    Private Sub Find_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()

        TabControlRujukanTACC.ItemSize = New Size(0, 1)

        SetClear()
        SetClearDetailTACC()
    End Sub

    Private Sub SaveData()
        Dim kodeTACC As String = ""
        Dim jenisTACC As String = ""
        Dim alasanTACC As String = ""

        ' Set Kode, Jenis & Keterangan TACC
        If RadioButtonTanpaTACC.Checked Then
            ' Rujuk tanpa TACC
            kodeTACC = RadioButtonTanpaTACC.Tag
            jenisTACC = RadioButtonTanpaTACC.Text
            alasanTACC = "-"
        ElseIf RadioButtonTACC.Checked Then
            ' Rujuk dengan TACC
            If RadioButtonTime.Checked Then
                ' Time (Waktu)
                kodeTACC = RadioButtonTime.Tag
                jenisTACC = RadioButtonTime.Text

                If RadioButtonTimeOption1.Checked Then
                    alasanTACC = RadioButtonTimeOption1.Text
                ElseIf RadioButtonTimeOption2.Checked Then
                    alasanTACC = RadioButtonTimeOption2.Text
                ElseIf RadioButtonTimeOption3.Checked Then
                    alasanTACC = RadioButtonTimeOption3.Text
                End If
            ElseIf RadioButtonAge.Checked Then
                ' Age (Umur)
                kodeTACC = RadioButtonAge.Tag
                jenisTACC = RadioButtonAge.Text

                If RadioButtonAgeOption1.Checked Then
                    alasanTACC = RadioButtonAgeOption1.Text
                ElseIf RadioButtonAgeOption2.Checked Then
                    alasanTACC = RadioButtonAgeOption2.Text
                ElseIf RadioButtonAgeOption3.Checked Then
                    alasanTACC = RadioButtonAgeOption3.Text
                ElseIf RadioButtonAgeOption4.Checked Then
                    alasanTACC = RadioButtonAgeOption4.Text
                ElseIf RadioButtonAgeOption5.Checked Then
                    alasanTACC = RadioButtonAgeOption5.Text
                ElseIf RadioButtonAgeOption6.Checked Then
                    alasanTACC = RadioButtonAgeOption6.Text
                End If
            ElseIf RadioButtonComplication.Checked Then
                ' Complication (Komplikasi)
                kodeTACC = RadioButtonComplication.Tag
                jenisTACC = RadioButtonComplication.Text
                alasanTACC = TextBoxKodeDiagnosaComplication.Text & " - " & TextBoxKeteranganDiagnosaComplication.Text
            ElseIf RadioButtonComorbidity.Checked Then
                ' Comorbidity (Pemberat)
                kodeTACC = RadioButtonComorbidity.Tag
                jenisTACC = RadioButtonComorbidity.Text
                alasanTACC = TextBoxKodeDiagnosaComorbidity.Text & " - " & TextBoxKeteranganDiagnosaComorbidity.Text
            End If
        End If

        Select Case TForm
            Case "RekamMedisDokterRujukanTACC"
                FormRekamMedisDokter.LoadRujukanTACC(kodeTACC, jenisTACC, alasanTACC, TForm)
        End Select

        Me.Close()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub CollapsePanel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonTanpaTACC.CheckedChanged, RadioButtonTACC.CheckedChanged
        If RadioButtonTACC.Checked Then
            SplitContainerRujukanTACC.Panel2Collapsed = False
        ElseIf RadioButtonTanpaTACC.Checked Then
            SplitContainerRujukanTACC.Panel2Collapsed = True
        End If
    End Sub

    Private Sub RadioButtonTACC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonTime.CheckedChanged, RadioButtonAge.CheckedChanged, RadioButtonComplication.CheckedChanged, RadioButtonComorbidity.CheckedChanged
        Try
            Dim radioButton = DirectCast(sender, RadioButton)
            SplitContainerDetailTACC.Panel2Collapsed = False
            SetClearDetailTACC()

            Select Case radioButton.Name
                Case "RadioButtonTime"
                    TabControlRujukanTACC.SelectedTab = TabPageTime
                Case "RadioButtonAge"
                    TabControlRujukanTACC.SelectedTab = TabPageAge
                Case "RadioButtonComplication"
                    TabControlRujukanTACC.SelectedTab = TabPageComplication
                Case "RadioButtonComorbidity"
                    TabControlRujukanTACC.SelectedTab = TabPageComorbidity
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub ButtonSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSave.Click
        Try
            SaveData()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub ButtonFindDiagnosaComplication_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFindDiagnosaComplication.Click
        FindDiagnosa.SetForm("DiagnosaComplicationTACC")
        FindDiagnosa.ShowDialog()
    End Sub

    Private Sub ButtonFindDiagnosaComorbidity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFindDiagnosaComorbidity.Click
        FindDiagnosa.SetForm("DiagnosaComorbidityTACC")
        FindDiagnosa.ShowDialog()
    End Sub

    Public Sub LoadDiagnosa(ByRef Trow As DataRowView, ByRef JenisDiagnosa As String)
        If JenisDiagnosa = "DiagnosaComplicationTACC" Then
            TextBoxKodeDiagnosaComplication.Text = Trow("Kode Diagnosa").ToString
            TextBoxKeteranganDiagnosaComplication.Text = Trow("Nama Diagnosa").ToString
        ElseIf JenisDiagnosa = "DiagnosaComorbidityTACC" Then
            TextBoxKodeDiagnosaComorbidity.Text = Trow("Kode Diagnosa").ToString
            TextBoxKeteranganDiagnosaComorbidity.Text = Trow("Nama Diagnosa").ToString
        End If
    End Sub
End Class