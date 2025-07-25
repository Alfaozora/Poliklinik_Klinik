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

Public Class DialogBoxRiwayatPerawatanICare
    Private formName As String = "RIWAYAT PERAWATAN ICARE"
    Private TForm As String
    Private userInput As String = PoliKlinik.Lbluser.Text
    Private _dataDictionary As Dictionary(Of String, Object)

    ' Variabel Dictionary
    Private _nomorNIK As String = ""
    Private _nomorKartuBPJS As String = ""
    Private _namaPasien As String = ""
    Private _jenisKelamin As String = ""
    Private _tglLahir As Date
    Private _alamat As String = ""
    Private _noHP As String = ""
    Private _kodeDokter As String = ""
    Private _namaDokter As String = ""
    Private _kodePoli As String = ""
    Private _namaPoli As String = ""
    Private _keluhan As String = ""
    Private _kodeFaskes As String = ""
    Private _namaFaskes As String = ""

    ' Variabel PCare
    Private NoUrutBPJS As String = ""

    Private Class varJson
        Public response As v4_BPJS
        Public metaData As MetaData
    End Class

    Public Property DataDictionary() As Dictionary(Of String, Object)
        Get
            Return _dataDictionary
        End Get
        Set(ByVal value As Dictionary(Of String, Object))
            _dataDictionary = value

            ' General
            _nomorNIK = GetValueFromDictionary("Nomor NIK", "")
            _nomorKartuBPJS = GetValueFromDictionary("Nomor Kartu BPJS", "")
            _namaPasien = GetValueFromDictionary("Nama Pasien", "")
            _jenisKelamin = GetValueFromDictionary("Jenis Kelamin", "")
            _tglLahir = GetValueFromDictionary("Tgl Lahir", "")
            _alamat = GetValueFromDictionary("Alamat", "")
            _noHP = GetValueFromDictionary("Nomor HP", "")
            _kodeDokter = GetValueFromDictionary("Kode Dokter", "")
            _namaDokter = GetValueFromDictionary("Nama Dokter", "")
            _kodePoli = GetValueFromDictionary("Kode Poli", "")
            _namaPoli = GetValueFromDictionary("Nama Poli", "")
            _keluhan = GetValueFromDictionary("Keluhan", "")
            _kodeFaskes = GetValueFromDictionary("Kode Faskes", "")
            _namaFaskes = GetValueFromDictionary("Nama Faskes", "")
        End Set
    End Property

    Private Function GetValueFromDictionary(ByVal key As String, ByVal defaultValue As Object) As Object
        If _dataDictionary.ContainsKey(key) Then
            Return _dataDictionary(key)
        Else
            Return defaultValue
        End If
    End Function

    Private Sub PanelTop_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelTop.Paint
        Try
            e.Graphics.DrawString(formName, New Font("Arial", 12, FontStyle.Bold), Brushes.White, New Point(10, 10))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub SetAwal()
        Me.BringToFront()
        Me.CenterToScreen()
    End Sub

    Public Sub SetData(ByVal noKartu As String)
        TextBoxNoIdentitas.Text = noKartu
    End Sub

    Private Sub SearchRiwayat()
        Try
            If ValidasiData() = True Then
                Dim endpointBridging As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'icare_base_url'")
                Dim payloadBridging As String = ""

                payloadBridging = "{" & _
                                        """param"" : """ & TextBoxNoIdentitas.Text & """" & _
                                  "}"

                Dim jsonString As String = ""
                jsonString = GenerateICareUrl(payloadBridging, endpointBridging, "POST")
                MsgBox(jsonString)

                ' Parsing JSON response
                Dim jsonObj As JObject = JObject.Parse(jsonString)

                ' Mengambil nilai metaData.code
                Dim codeStr As Integer = CInt(jsonObj("metaData")("code"))

                If IsNumeric(codeStr) Then
                    Dim code As Integer = CInt(codeStr)

                    If code = 200 Then
                        ' Lanjut: valid dan buka link
                    Else
                        Dim message As String = jsonObj("metaData")("message").ToString()
                        MsgBox("Error: " & message, MsgBoxStyle.Critical, "API Error")
                    End If
                Else
                    MsgBox("Error: Kode response tidak valid: " & codeStr, MsgBoxStyle.Critical, "API Error")
                End If

                ' Jika kode 200, sukses
                'If code = 200 Then
                '    ' Menampilkan alert sukses
                '    MsgBox("User Valid. Klik OK untuk menampilkan informasi pencarian riwayat pelayanan kesehatan." & vbCrLf & "Tutup aplikasi `Google Chrome` terlebih dahulu jika redirect gagal.", MsgBoxStyle.OkOnly Or MsgBoxStyle.Information, "Validasi User")

                '    ' Mengambil nilai dari response.url
                '    Dim url As String = jsonObj("response")("url").ToString()

                '    ' Membuka di chrome
                '    OpenInNewChromeWindow(url)
                'Else
                '    ' Mengambil pesan error
                '    Dim message As String = jsonObj("metaData")("message").ToString()

                '    ' Menampilkan alert jika terjadi error
                '    MsgBox("Error: " & message, MsgBoxStyle.Critical, "API Error")
                'End If

                Me.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Function ValidasiData() As Boolean
        ' Validasi Nomor Identitas Kosong
        If TextBoxNoIdentitas.Text = "" Then
            MessageBox.Show("Nomor Identitas tidak boleh kosong.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        ' Validasi Jumlah Digit Nomor NIK
        If RadioButtonOpsiNIK.Checked = True Then
            Dim nikLength As Integer = TextBoxNoIdentitas.Text.Length

            If nikLength < 16 Then
                MessageBox.Show("Eror: Nomor NIK kurang dari 16 digit.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            ElseIf nikLength > 16 Then
                MessageBox.Show("Eror: Nomor NIK lebih dari 16 digit.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If
        End If

        ' Validasi Jumlah Digit Nomor Kartu
        If RadioButtonOpsiNomorKartu.Checked = True Then
            Dim noKartuLength As Integer = TextBoxNoIdentitas.Text.Length

            If noKartuLength < 13 Then
                MessageBox.Show("Eror: Nomor Kartu kurang dari 13 digit.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            ElseIf noKartuLength > 13 Then
                MessageBox.Show("Eror: Nomor Kartu lebih dari 13 digit.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If
        End If


        Return True
    End Function

    Private Sub ButtonCariRiwayatPasien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCariRiwayatPasien.Click
        SearchRiwayat()
    End Sub

    Private Sub DialogBoxRiwayatPerawatanICare_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetAwal()
    End Sub

    Private Sub ButtonBatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBatal.Click
        Me.Close()
    End Sub
End Class