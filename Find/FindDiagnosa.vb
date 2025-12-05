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
Public Class FindDiagnosa
    Private formName As String = "PENCARIAN DIAGNOSA"
    Private TForm As String

    'Private Class varJson
    '    Public metaData As MetaData
    '    Public response As v4_BPJS
    'End Class

    Private Class varJson
        Private _metaData As MetaData
        Private _response As v4_BPJS

        Public Property metaData() As MetaData
            Get
                Return _metaData
            End Get
            Set(ByVal value As MetaData)
                _metaData = value
            End Set
        End Property

        Public Property response() As v4_BPJS
            Get
                Return _response
            End Get
            Set(ByVal value As v4_BPJS)
                _response = value
            End Set
        End Property
    End Class

    Private Class MetaData
        Private _message As String
        Private _code As Integer

        Public Property message() As String
            Get
                Return _message
            End Get
            Set(ByVal value As String)
                _message = value
            End Set
        End Property

        Public Property code() As Integer
            Get
                Return _code
            End Get
            Set(ByVal value As Integer)
                _code = value
            End Set
        End Property
    End Class

    Private Class v4_BPJS
        Private _list As Diagnosa()

        Public Property list() As Diagnosa()
            Get
                Return _list
            End Get
            Set(ByVal value As Diagnosa())
                _list = value
            End Set
        End Property
    End Class

    Private Class Diagnosa
        Private _kdDiag As String
        Private _nmDiag As String
        Private _nonSpesialis As Boolean

        Public Property kdDiag() As String
            Get
                Return _kdDiag
            End Get
            Set(ByVal value As String)
                _kdDiag = value
            End Set
        End Property

        Public Property nmDiag() As String
            Get
                Return _nmDiag
            End Get
            Set(ByVal value As String)
                _nmDiag = value
            End Set
        End Property

        Public Property nonSpesialis() As Boolean
            Get
                Return _nonSpesialis
            End Get
            Set(ByVal value As Boolean)
                _nonSpesialis = value
            End Set
        End Property
    End Class

    Private Class ErrorMeta
        Private _metaData As MetaData

        Public Property metaData() As MetaData
            Get
                Return _metaData
            End Get
            Set(ByVal value As MetaData)
                _metaData = value
            End Set
        End Property
    End Class


    Function CreateTableICD() As DataTable
        Dim Thasil As New DataTable

        insertRowToTbls(Thasil, "Typstring", "Kode Diagnosa")
        insertRowToTbls(Thasil, "Typstring", "Nama Diagnosa")
        insertRowToTbls(Thasil, "typchecked", "Non Spesialis")

        For Each Tcol As DataColumn In Thasil.Columns
            Tcol.ReadOnly = True
        Next

        Return Thasil
    End Function

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

    Private Sub SetAwal()
        Me.CenterToScreen()
        TextBoxKriteria.Focus()
        TextBoxKriteria.ResetText()
        ToggleSwitch1.Checked = True
    End Sub

    'NEW VER 1
    'Private Sub FindQuery()
    '    Try
    '        If Checking() = True Then
    '            Dim kriteria As String = TextBoxKriteria.Text
    '            'Dim Tdata As DataTable = New DataTable
    '            Dim Tdata As DataTable = CreateTableICD()

    '            'Tdata = CreateTableICD()
    '            Tdata.Rows.Clear()

    '            Dim getResponse As String = ""
    '            Dim urlPcare As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_base_url'")
    '            Dim uri As String = urlPcare & "diagnosa/" & kriteria & "/1/100"

    '            getResponse = getDataFromPcare(uri)

    '            If getResponse = "Nothing" OrElse getResponse Is Nothing OrElse getResponse.Trim() = "" Then
    '                MsgBox("Tidak ada respon dari server.", MsgBoxStyle.Critical, "Warning!")
    '                Exit Sub
    '            End If

    '            Dim isArray As Boolean = getResponse.Trim().StartsWith("[")
    '            Dim isObject As Boolean = getResponse.Trim().StartsWith("{")

    '            If isArray Then
    '                Dim varsespoli() As varJson = JsonConvert.DeserializeObject(Of varJson())(getResponse)

    '                For Each oneVar As varJson In varsespoli
    '                    If oneVar.metaData.message = "OK" Then
    '                        If oneVar.response IsNot Nothing AndAlso oneVar.response.list IsNot Nothing Then
    '                            For Each diag In oneVar.response.list
    '                                Dim Tlastnew As DataRow = Tdata.NewRow
    '                                Tlastnew("Kode Diagnosa") = diag.kdDiag
    '                                Tlastnew("Nama Diagnosa") = diag.nmDiag
    '                                Tlastnew("Non Spesialis") = diag.nonSpesialis
    '                                Tdata.Rows.Add(Tlastnew)
    '                            Next
    '                        End If
    '                    Else
    '                        MsgBox("BPJS: " & oneVar.metaData.message, MsgBoxStyle.Critical, "Peringatan!")
    '                    End If
    '                Next

    '            ElseIf isObject Then
    '                Dim errResponse As ErrorMeta = JsonConvert.DeserializeObject(Of ErrorMeta)(getResponse)
    '                MsgBox("BPJS Error: " & errResponse.metaData.message, MsgBoxStyle.Exclamation, "Peringatan!")
    '            Else
    '                MsgBox("Format respon tidak dikenali!", MsgBoxStyle.Critical, "Kesalahan Format")
    '            End If

    '            'If getResponse <> "Nothing" Then
    '            '    'Dim varsespoli() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of varJson())(getResponse)
    '            '    Dim varsespoli() As varJson = JsonConvert.DeserializeObject(Of varJson())(getResponse)

    '            '    For Each oneVar As varJson In varsespoli
    '            '        If oneVar.metaData.message = "OK" Then
    '            '            For index As Integer = 0 To oneVar.response.list.Length - 1
    '            '                Dim Tlastnew As DataRow = Tdata.NewRow
    '            '                Tlastnew("Kode Diagnosa") = oneVar.response.list(index).kdDiag
    '            '                Tlastnew("Nama Diagnosa") = oneVar.response.list(index).nmDiag
    '            '                Tlastnew("Non Spesialis") = oneVar.response.list(index).nonSpesialis
    '            '                Tdata.Rows.Add(Tlastnew)
    '            '            Next
    '            '        Else
    '            '            MsgBox("Data tidak ditemukan.", MsgBoxStyle.Critical, "Warning!")
    '            '        End If
    '            '    Next
    '            'Else
    '            '    MsgBox("Data tidak ditemukan.", MsgBoxStyle.Critical, "Warning!")
    '            'End If

    '            GridControlPencarian.DataSource = Tdata
    '            GridViewPencarian.BestFitColumns()
    '            'GridViewPencarian.Columns("NonSpesialis ").Visible = False
    '        End If
    '    Catch ex As Exception
    '        MsgBox("Eror saat memproses data: " & ex.Message, MsgBoxStyle.Exclamation, "Error!")
    '    End Try
    'End Sub

    Private Sub FindQuery()
        Try
            '===========================
            ' MODE LOKAL (Switch OFF)
            '===========================
            If ToggleSwitch1.Checked = False Then
                LoadDiagnosaLokal()
                Exit Sub
            End If

            '===========================
            ' MODE PCARE (Switch ON)
            '===========================
            If Not CekKoneksiPCare() Then
                MsgBox("PCare tidak dapat diakses." & vbCrLf & _
                       "Berpindah ke Diagnosa Lokal.", MsgBoxStyle.Exclamation)

                ToggleSwitch1.Checked = False
                LoadDiagnosaLokal()
                Exit Sub
            End If

            If Checking() = True Then

                Dim kriteria As String = TextBoxKriteria.Text
                Dim Tdata As DataTable = CreateTableICD()
                Tdata.Rows.Clear()

                Dim urlPcare As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_base_url'")
                Dim uri As String = urlPcare & "diagnosa/" & kriteria & "/1/100"

                Dim getResponse As String = getDataFromPcare(uri)

                '===========================================================
                ' 1. CEK RESPONS KOSONG (server down / koneksi putus)
                '===========================================================
                If String.IsNullOrEmpty(getResponse) OrElse getResponse.Trim() = "" Then
                    MsgBox("Tidak ada respons dari PCare." & vbCrLf & _
                           "Kemungkinan:" & vbCrLf & _
                           "- Server BPJS DOWN" & vbCrLf & _
                           "- Internet terputus / lambat" & vbCrLf & _
                           "- Gateway API tidak merespon", MsgBoxStyle.Critical, "PCare Tidak Merespon")
                    Exit Sub
                End If

                Dim trimmed As String = getResponse.Trim()

                '===========================================================
                ' 2. CEK APAKAH FORMAT JSON VALID
                '===========================================================
                If Not (trimmed.StartsWith("[") Or trimmed.StartsWith("{")) Then
                    MsgBox("Format respons PCare tidak valid." & vbCrLf & _
                           "Raw Response:" & vbCrLf & _
                           getResponse, MsgBoxStyle.Critical, "Format Error")
                    Exit Sub
                End If

                Dim isArray As Boolean = trimmed.StartsWith("[")
                Dim isObject As Boolean = trimmed.StartsWith("{")

                '===========================================================
                ' 3. JIKA RESPONS BERBENTUK ARRAY
                '===========================================================
                If isArray Then
                    Dim varsespoli() As varJson = Nothing

                    Try
                        varsespoli = JsonConvert.DeserializeObject(Of varJson())(getResponse)
                    Catch ex As Exception
                        MsgBox("Gagal membaca data diagnostik dari PCare." & vbCrLf & _
                               "Kemungkinan:" & vbCrLf & _
                               "- Server BPJS sedang tidak stabil" & vbCrLf & _
                               "- Data JSON tidak lengkap (internet lambat)" & vbCrLf & _
                               vbCrLf & _
                               getResponse, MsgBoxStyle.Critical, "Error JSON")
                        Exit Sub
                    End Try

                    For Each oneVar As varJson In varsespoli

                        'Metadata tidak OK
                        If oneVar.metaData Is Nothing Then
                            MsgBox("PCare: metadata tidak ditemukan. Server kemungkinan tidak stabil.", MsgBoxStyle.Exclamation, "PCare Error")
                            Exit Sub
                        End If

                        If oneVar.metaData.message = "OK" Then

                            If oneVar.response IsNot Nothing AndAlso oneVar.response.list IsNot Nothing Then
                                For Each diag In oneVar.response.list
                                    Dim Tlastnew As DataRow = Tdata.NewRow
                                    Tlastnew("Kode Diagnosa") = diag.kdDiag
                                    Tlastnew("Nama Diagnosa") = diag.nmDiag
                                    Tlastnew("Non Spesialis") = diag.nonSpesialis
                                    Tdata.Rows.Add(Tlastnew)
                                Next
                            End If

                        Else
                            MsgBox("BPJS Error: " & oneVar.metaData.message, MsgBoxStyle.Exclamation, "Peringatan!")
                            Exit Sub
                        End If

                    Next

                    '===========================================================
                    ' 4. JIKA RESPONS BERBENTUK OBJECT → Biasanya error BPJS
                    '===========================================================
                ElseIf isObject Then
                    Try
                        Dim errResponse As ErrorMeta = JsonConvert.DeserializeObject(Of ErrorMeta)(getResponse)
                        MsgBox("BPJS Error: " & errResponse.metaData.message, MsgBoxStyle.Exclamation, "Peringatan!")
                    Catch ex As Exception
                        MsgBox("Tidak dapat membaca respons PCare." & vbCrLf & _
                               getResponse, MsgBoxStyle.Critical, "Kesalahan PCare")
                    End Try
                    Exit Sub

                    '===========================================================
                    ' 5. FORMAT TIDAK DIKENALI
                    '===========================================================
                Else
                    MsgBox("Format respons PCare tidak dikenali!", MsgBoxStyle.Critical, "Kesalahan Format")
                    Exit Sub
                End If

                '===========================================================
                ' 6. TAMPILKAN KE GRID
                '===========================================================
                GridControlPencarian.DataSource = Tdata
                GridViewPencarian.BestFitColumns()

            End If

        Catch ex As Exception
            MsgBox("Eror saat memproses data: " & ex.Message, MsgBoxStyle.Exclamation, "Error!")
        End Try
    End Sub

    Public Function CheckBridgingPcareActive() As Boolean
        Dim statusBridgingPcare As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'pcare_status_bridging'")

        Return (statusBridgingPcare = "Yes")
    End Function


    Private Function CekKoneksiPCare() As Boolean
        Try
            If Not CheckBridgingPcareActive() Then
                MsgBox("Bridging PCare FKTP dalam keadaan OFF.", MsgBoxStyle.Critical, "Warning!")
                Return False
            End If

            Dim urlPcare As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_base_url'")
            Dim testUrl As String = urlPcare & "diagnosa/Z00/1/1"

            Dim result As String = getDataFromPcare(testUrl)

            ' Response kosong
            If String.IsNullOrEmpty(result) Then Return False

            Dim r As String = result.Trim()
            If Not (r.StartsWith("{") Or r.StartsWith("[")) Then Return False

            ' Parse JSON menggunakan JObject agar fleksibel
            Dim obj = JsonConvert.DeserializeObject(Of varJson())(result)

            ' MetaData wajib ada
            If obj(0).metaData.message = "OK" Then
                Return True
            End If

            Return False

        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub LoadDiagnosaLokal()
        Try
            Dim Tdata As DataTable = New DataTable
            Tdata.Columns.Add("Kode Diagnosa")
            Tdata.Columns.Add("Nama Diagnosa")
            Tdata.Columns.Add("Non Spesialis")

            Dim sql As String = "SELECT code AS [Kode Diagnosa], name_en AS [Nama Diagnosa], 0 AS [Non Spesialis] FROM MasterICDX WHERE name_en LIKE '%" & TextBoxKriteria.Text & "%' OR code LIKE '%" & TextBoxKriteria.Text & "%'"

            Dim dt As DataTable = ReadSQL(sql)

            GridControlPencarian.DataSource = dt
            GridViewPencarian.BestFitColumns()

        Catch ex As Exception
            MsgBox("Error memuat diagnosa lokal: " & ex.Message)
        End Try
    End Sub

    Private Sub Find_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GridControlPencarian.DataSource = CreateTableICD()
        SetAwal()
    End Sub

    Private Sub LoadData(ByRef Baris As Integer)
        If GridViewPencarian.RowCount > 0 Then
            Dim Grdrow As DataRowView = GridViewPencarian.GetRow(Baris)

            Select Case TForm
                Case "RekamMedisDokterDiagnosa"
                    FormRekamMedisDokter.LoadDiagnosa(Grdrow, TForm)
                Case "DiagnosaComplicationTACC", "DiagnosaComorbidityTACC"
                    FindRujukanTACC.LoadDiagnosa(Grdrow, TForm)
            End Select

            Me.Close()
        End If
    End Sub

    Private Sub GridControl1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridControlPencarian.DoubleClick
        If GridViewPencarian.FocusedRowHandle >= 0 Then
            Dim Index() As Integer = GridViewPencarian.GetSelectedRows
            If Index.Length > 0 Then
                LoadData(Index(0))
            End If
        End If
    End Sub

    Private Sub txKriteria_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxKriteria.KeyDown
        If e.KeyCode = Keys.Enter Then FindQuery()
    End Sub

    Function Checking() As Boolean
        If TextBoxKriteria.Text = "" Then
            MsgBox("Kriteria pencarian tidak boleh kosong.", MsgBoxStyle.Critical, "Warning!")
            Return False
        End If

        Return True
    End Function

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub ButtonFindDiagnosa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFindDiagnosa.Click
        Try
            If ToggleSwitch1.Checked = False Then
                LoadDiagnosaLokal()
                Exit Sub
            Else
                FindQuery()
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub ToggleSwitch1_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ToggleSwitch1.CheckedChanged
        Try
            If ToggleSwitch1.Checked = True Then

            Else
                MsgBox("Mode: Diagnosa Lokal", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
        End Try
    End Sub

End Class