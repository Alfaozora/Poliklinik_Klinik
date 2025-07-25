Imports System.Speech.Recognition
Imports System.Speech.Synthesis
Imports System.Math
Imports System.Media
Imports System.Net
Imports System.IO
Imports Newtonsoft.Json.Linq

Public Class FormTesting2
    Dim synthesizer As New SpeechSynthesizer()
    Dim varSpeech As New SpeechRecognitionEngine
    Dim varKosakata As New Choices

    Private Sub Speech_Event(ByVal sender As Object, ByVal e As SpeechRecognizedEventArgs)
        My.Computer.Keyboard.SendKeys(e.Result.Text & " ")
    End Sub

    Private Sub Psuara()
        Dim gr As New Grammar(New GrammarBuilder("Hello World"))

        Try
            varSpeech.RequestRecognizerUpdate()
            varSpeech.LoadGrammar(gr)
            AddHandler varSpeech.SpeechRecognized, AddressOf Speech_Event
            varSpeech.SetInputToDefaultAudioDevice()
            varSpeech.RecognizeAsync(RecognizeMode.Multiple)
            varSpeech.Recognize()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripLabel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox("Daftar Hadir")
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox("Home")
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox("Home 2")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Dim SAPI
        'SAPI = CreateObject("SAPI.spvoice")

        'SAPI.speak(TextBox1.Text)



        'Dim textToSpeak As String = TextBox1.Text
        'synthesizer.SpeakAsync(textToSpeak)

        Dim patientName As String = "John Doe" ' Ganti dengan nama pasien sebenarnya
        CallPatient(patientName)

        'Dim patientName As String = "John Doe" ' Ganti dengan nama pasien sebenarnya
        'CallPatient(patientName)
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        MsgBox(My.Computer.Info.OSFullName)

        'Select Case MsgBox("Hello?", MsgBoxStyle.YesNo, "Question.")
        '    Case MsgBoxResult.Yes
        '        MsgBox("Data Berhasil Disimpan.", MsgBoxStyle.Information, "Success")
        'End Select

        If MessageBox.Show("Hello?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            MsgBox("Data Berhasil Disimpan.", MsgBoxStyle.Information, "Success")
        End If
    End Sub

    Private Sub CallPatient(ByVal patientName As String)
        Dim textToSpeak As String = "Pasien dengan nama " & patientName & " harap segera ke ruang periksa."
        SpeakText(textToSpeak)
    End Sub

    Private Sub SpeakText(ByVal text As String)
        Dim script As String = "<html><head>" & _
                               "<script src='https://code.responsivevoice.org/responsivevoice.js'></script>" & _
                               "</head><body>" & _
                               "<script type='text/javascript'>" & _
                               "function speak(){" & _
                               "responsiveVoice.speak(""" & text.Replace("""", "\""") & """, 'Indonesian Female');" & _
                               "}" & _
                               "</script>" & _
                               "<button onclick='speak()' id='speakButton'>Speak</button>" & _
                               "<script type='text/javascript'>" & _
                               "document.getElementById('speakButton').click();" & _
                               "</script>" & _
                               "</body></html>"

        'WebBrowser1.DocumentText = script
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim creatinin As Double = txhasilcreat.Text
        Dim umur As Integer = txumur.Text
        Dim nilaiFemale As Double = 0.742
        Dim result As Double = 0

        result = 175 * (creatinin) ^ -1.154 * (umur) ^ -0.203 * nilaiFemale

        txresultegfr.Text = Math.Round(result, 1)

    End Sub

    Function Bulatkan(ByVal nValue As Double, ByVal nDigits As Integer) As Double
        Bulatkan = Int(nValue * (10 ^ nDigits) + 0.5) / (10 ^ nDigits)
    End Function

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Process.Start(txumur.Text)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FormTesting2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Psuara()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim result As Double = TextBoxPembulatan.Text
        'Dim Hasil As Decimal = Math.Round(result)
        Dim Hasil As Decimal = Math.Round(result, 0, MidpointRounding.AwayFromZero)
        MsgBox(Hasil)
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim temp As String = ""

        For tanggal = 1 To 31
            System.Threading.Thread.Sleep(10)
            temp = DateTime.Now.ToString("yyyyMMdd_HHmmss") & " | " & temp
        Next

        MsgBox(temp)
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        MsgBox(Convert.ToInt32(True))
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        If IsConnectedToIPAddress("www.google.com") Then
            MsgBox("Koneksi berhasil")
        Else
            MsgBox("Koneksi gagal")
        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        MsgBox(TrackBar1.Value)
    End Sub
End Class