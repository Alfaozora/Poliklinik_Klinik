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
Imports System.Text

Public Class DialogBoxTambahAlergi
    Private userInput As String = PoliKlinik.Lbluser.Text ' User input program
    Private formName As String = "ALERGI PASIEN"
    Private _dataDictionary As Dictionary(Of String, Object)

    '# Variabel Private
    Private _noRM As String = ""

    Public Property DataDictionary() As Dictionary(Of String, Object)
        Get
            Return _dataDictionary
        End Get
        Set(ByVal value As Dictionary(Of String, Object))
            _dataDictionary = value

            ' Nomor Rekam Medis
            _noRM = GetValueFromDictionary("No Rekam Medis", "")
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
        Me.CenterToScreen()
        TextBoxKeteranganAlergi.ResetText()
    End Sub

    Private Sub SetComboBoxJenisAlergi()
        ' Mendeklarasikan List<KeyValuePair(Of Integer, String)>
        Dim dataItems As New List(Of KeyValuePair(Of String, String))

        ' Mendeklarasikan AutoCompleteStringCollection
        Dim autoCompleteData As New AutoCompleteStringCollection()

        Dim tbls As DataTable = ReadSQL("SELECT AlergiJenis FROM MasterAlergi GROUP BY AlergiJenis")
        For Each Trow As DataRow In tbls.Rows
            ' Menambahkan keterangan ke dalam AutoCompleteStringCollection
            autoCompleteData.Add(Trow("AlergiJenis"))

            ' Menambahkan pasangan nilai ID dan keterangan ke dalam List
            dataItems.Add(New KeyValuePair(Of String, String)(Trow("AlergiJenis"), Trow("AlergiJenis")))
        Next

        ' Menghubungkan dataItems ke ComboBoxProvinsiDomisili
        ComboBoxJenisAlergi.DataSource = dataItems
        ComboBoxJenisAlergi.DisplayMember = "Value" ' Menampilkan keterangan sebagai teks yang ditampilkan di ComboBox
        ComboBoxJenisAlergi.ValueMember = "Key" ' Menyimpan ID sebagai nilai yang terkait dengan item yang dipilih

        ComboBoxJenisAlergi.SelectedIndex = -1
    End Sub

    Private Sub SetComboBoxNamaAlergi(ByVal jenisAlergi As String)
        ' Mendeklarasikan List<KeyValuePair(Of Integer, String)>
        Dim dataItems As New List(Of KeyValuePair(Of String, String))

        ' Mendeklarasikan AutoCompleteStringCollection
        Dim autoCompleteData As New AutoCompleteStringCollection()

        Dim tbls As DataTable = ReadSQL("SELECT ID, AlergiNama FROM MasterAlergi WHERE AlergiJenis = '" & jenisAlergi & "'")
        For Each Trow As DataRow In tbls.Rows
            ' Menambahkan keterangan ke dalam AutoCompleteStringCollection
            autoCompleteData.Add(Trow("AlergiNama"))

            ' Menambahkan pasangan nilai ID dan keterangan ke dalam List
            dataItems.Add(New KeyValuePair(Of String, String)(Trow("ID"), Trow("AlergiNama")))
        Next

        ' Menghubungkan dataItems ke ComboBoxProvinsiDomisili
        ComboBoxNamaAlergi.DataSource = dataItems
        ComboBoxNamaAlergi.DisplayMember = "Value" ' Menampilkan keterangan sebagai teks yang ditampilkan di ComboBox
        ComboBoxNamaAlergi.ValueMember = "Key" ' Menyimpan ID sebagai nilai yang terkait dengan item yang dipilih

        ComboBoxNamaAlergi.SelectedIndex = -1
    End Sub

    Private Sub Find_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetAwal()
        SetComboBoxJenisAlergi()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub ComboBoxJenisAlergi_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxJenisAlergi.SelectedIndexChanged
        Try
            ComboBoxNamaAlergi.DataSource = Nothing ' Menghapus sambungan dengan DataSource
            ComboBoxNamaAlergi.Items.Clear() ' Membersihkan item ComboBox

            If ComboBoxJenisAlergi.SelectedIndex <> -1 Then
                Dim jenisAlergi As String = DirectCast(ComboBoxJenisAlergi.SelectedItem, KeyValuePair(Of String, String)).Key
                SetComboBoxNamaAlergi(jenisAlergi)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub ButtonSimpanDataAlergi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSimpanDataAlergi.Click
        Try
            If ValidasiDataAlergi() = True Then SimpanDataAlergi()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub SimpanDataAlergi()
        Dim alergiID As String = DirectCast(ComboBoxNamaAlergi.SelectedItem, KeyValuePair(Of String, String)).Key
        Dim alergiNama As String = DirectCast(ComboBoxNamaAlergi.SelectedItem, KeyValuePair(Of String, String)).Value
        Dim alergiJenis As String = DirectCast(ComboBoxJenisAlergi.SelectedItem, KeyValuePair(Of String, String)).Value

        If CheckSQL("SELECT * FROM MasterPasienAlergi WHERE NoRekamMedis = '" & _noRM & "' AND AlergiID = '" & alergiID & "' AND DeletedDate IS NULL") = False Then
            ' Insert Data MasterPasienAlergi
            WriteSQL("INSERT INTO MasterPasienAlergi (NoRekamMedis, AlergiID, AlergiJenis, AlergiNama, Keterangan, CreatedBy, CreatedDate) " & _
                    "VALUES ('" & _noRM & "', '" & alergiID & "', '" & alergiJenis & "', '" & alergiNama & "', '" & TextBoxKeteranganAlergi.Text & "', '" & userInput & "', GETDATE())", 4)

            MsgBox("Data Alergi Berhasil Disimpan.", MsgBoxStyle.Information, "Success")
        Else
            ' Update Data MasterPasienAlergi
            Select Case MsgBox("Data alergi sudah pernah diinput. Update?", MsgBoxStyle.YesNo, "Question.")
                Case MsgBoxResult.Yes
                    Dim parameterUpdate As String = ""

                    ' Update Data MasterPasienAlergi
                    parameterUpdate = "AlergiID = '" & alergiID & "'," & _
                                      "AlergiJenis = '" & alergiJenis & "'," & _
                                      "Keterangan = '" & TextBoxKeteranganAlergi.Text & "'," & _
                                      "UpdatedBy = '" & userInput & "'," & _
                                      "UpdatedDate = GETDATE()"

                    WriteSQL("UPDATE MasterPasienAlergi SET " & parameterUpdate & " WHERE NoRekamMedis = '" & _noRM & "' AND AlergiID = '" & alergiID & "' AND DeletedDate IS NULL", 4)

                    MsgBox("Data Alergi Berhasil Disimpan.", MsgBoxStyle.Information, "Success")
            End Select
        End If

        Me.Close()
    End Sub

    Private Function ValidasiDataAlergi() As Boolean
        ' Validasi Jenis Alergi
        If ComboBoxJenisAlergi.SelectedIndex = -1 Then
            MsgBox("Masukkan data jenis alergi terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        ' Validasi Nama Alergi
        If ComboBoxNamaAlergi.SelectedIndex = -1 Then
            MsgBox("Masukkan data nama alergi terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        Return True
    End Function
End Class