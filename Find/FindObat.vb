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

Public Class FindObat
    Private formName As String = "PENCARIAN OBAT"
    Private TForm As String
    Dim Ttcon As New TLcon
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

    Private Sub GridControl1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridPencarian.DoubleClick
        If GridView1.FocusedRowHandle >= 0 Then
            Dim Index() As Integer = GridView1.GetSelectedRows
            If Index.Length > 0 Then
                LoadData(Index(0))
            End If
        End If
    End Sub

    Private Sub Connection()
        Dim Tbls As DataTable = ReadSQL("SELECT ConfigName, StrValue FROM MsConfig WHERE ConfigName IN ('NameDatabaseObat', 'AddressDatabaseObat', 'PasswordDatabaseObat')")

        Ttcon.Tid = "root"

        For Each Trow As DataRow In Tbls.Rows
            If Trow("ConfigName") = "NameDatabaseObat" Then
                Ttcon.Tdb = Trow("StrValue")
            ElseIf Trow("ConfigName") = "AddressDatabaseObat" Then
                Ttcon.Tip = Trow("StrValue")
            ElseIf Trow("ConfigName") = "PasswordDatabaseObat" Then
                Ttcon.Tpass = Trow("StrValue")
            End If
        Next
    End Sub

    Function CreateTable() As DataTable
        Dim Thasil As New DataTable

        insertRowToTbls(Thasil, "Typstring", "Kode Obat")
        insertRowToTbls(Thasil, "Typstring", "Nama Obat")
        insertRowToTbls(Thasil, "Typstring", "Stok")
        'insertRowToTbls(Thasil, "Typstring", "Harga")
        insertRowToTbls(Thasil, "Typstring", "Unit")
        insertRowToTbls(Thasil, "Typstring", "Komponen")

        Return Thasil
    End Function

    Private Sub Find_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Connection()
        SetAwal()
        GridPencarian.DataSource = CreateTable()
    End Sub

    Private Sub SetAwal()
        Me.CenterToScreen()

        TextBoxNamaObat.Select()
        TextBoxNamaObat.ResetText()
        TextBoxKomponenObat.ResetText()
    End Sub

    Private Sub FindQuery()
        If Checking() = True Then
            Dim Tdata As DataTable = New DataTable

            Tdata = CreateTable()
            Tdata.Rows.Clear()

            '# Set Variabel
            Dim namaObat As String = TextBoxNamaObat.Text
            Dim komponenObat As String = TextBoxKomponenObat.Text
            Dim lokasiApotek As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='LokasiApotek'")
            Dim query As String = "CALL Sp_GetStockListKlinik('" & lokasiApotek & "','" & namaObat & "','" & komponenObat & "')"

            Dim TblsObat As DataTable = ReadThemysql(query, Ttcon)

            If TblsObat.Rows.Count > 0 Then
                For Each Trow As DataRow In TblsObat.Rows
                    Dim Tlastnew As DataRow = Tdata.NewRow
                    Tlastnew("Kode Obat") = Trow("inv")
                    Tlastnew("Nama Obat") = Trow("namaobat")
                    Tlastnew("Stok") = Trow("qty")
                    'Tlastnew("Harga") = ReadThemysqlNIK("SELECT F_HargaObatKlinik('" & Trow("inv") & "')", Ttcon)
                    Tlastnew("Unit") = Trow("unit")
                    Tlastnew("Komponen") = Trow("komponen")

                    Tdata.Rows.Add(Tlastnew)
                Next
            Else
                MsgBox("Data tidak ditemukan.", MsgBoxStyle.Exclamation, "Warning!")
            End If

            GridPencarian.DataSource = Tdata
            'GridView1.Columns("PRB").Visible = False
        End If
    End Sub

    Private Sub LoadData(ByRef Baris As Integer)
        If GridView1.RowCount > 0 Then
            Dim Grdrow As DataRowView = GridView1.GetRow(Baris)

            Select Case TForm
                Case "RekamMedisDokterObatNonRacikan"
                    FormRekamMedisDokter.LoadDataObat(Grdrow, TForm)
                Case "RekamMedisDokterObatRacikan"
                    FormRekamMedisDokter.LoadDataObat(Grdrow, TForm)
            End Select

            Me.Close()
        End If
    End Sub

    Function Checking() As Boolean
        ''# Cek Inputan Tahun
        'If ComboBoxTahun.Text <> "" Then
        '    If ComboBoxTahun.FindStringExact(ComboBoxTahun.Text) < 0 Then
        '        MsgBox("Cek inputan tahun lahir.", MsgBoxStyle.Exclamation, "Warning!")

        '        Return False
        '    End If
        'End If

        ''# Cek Inputan Bulan
        'If ComboBoxBulan.Text <> "" Then
        '    If ComboBoxBulan.FindStringExact(ComboBoxBulan.Text) < 0 Then
        '        MsgBox("Cek inputan bulan lahir.", MsgBoxStyle.Exclamation, "Warning!")

        '        Return False
        '    End If
        'End If

        ''# Cek Inputan Tanggal
        'If ComboBoxTanggal.Text <> "" Then
        '    If ComboBoxTanggal.FindStringExact(ComboBoxTanggal.Text) < 0 Then
        '        MsgBox("Cek inputan tanggal lahir.", MsgBoxStyle.Exclamation, "Warning!")

        '        Return False
        '    End If
        'End If

        Return True
    End Function

    Private Sub ButtonFindObat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFindObat.Click
        FindQuery()
    End Sub

    Private Sub TextBoxKomponenObat_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxKomponenObat.KeyDown
        If e.KeyCode = Keys.Enter Then FindQuery()
    End Sub

    Private Sub TextBoxNamaObat_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxNamaObat.KeyDown
        If e.KeyCode = Keys.Enter Then FindQuery()
    End Sub

    Public Sub SetForm(ByRef Form As String)
        Me.BringToFront()
        TForm = Form
    End Sub
End Class