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
    Private fadeIn As Boolean = True
    Private fadeLevel As Integer = 100 ' nilai 0–255, 100 = abu-abu muda
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

    Private Sub GridView1_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles GridView1.DoubleClick
        If GridView1.FocusedRowHandle >= 0 Then
            Dim Index() As Integer = GridView1.GetSelectedRows()
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
        GridObatDPHO.DataSource = Nothing

        If CachedAutoList IsNot Nothing AndAlso CachedAutoList.Count > 0 Then
            TextBoxNamaObat.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            TextBoxNamaObat.AutoCompleteSource = AutoCompleteSource.CustomSource
            TextBoxNamaObat.AutoCompleteCustomSource = CachedAutoList
            LabelLoading.Visible = False
            TimerBlink.Enabled = False
        Else
            LabelLoading.Visible = True
            fadeLevel = 100
            fadeIn = True
            LabelLoading.ForeColor = Color.FromArgb(fadeLevel, Color.Black)
            TimerBlink.Enabled = True
            If Not BGWorkerAutoFill.IsBusy Then
                BGWorkerAutoFill.RunWorkerAsync()
            End If
        End If
        'LoadAutoCompleteNamaObat()
    End Sub

    'Private Sub LoadAutoCompleteNamaObat()
    '    Try
    '        If String.IsNullOrEmpty(Ttcon.Tdb) Then
    '            Connection()
    '        End If

    '        Dim lokasiApotek As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='LokasiApotek'")
    '        Dim namaObat As String = ""
    '        Dim komponenObat As String = ""

    '        Dim query As String = "CALL Sp_GetStockListKlinik('" & lokasiApotek & "','" & namaObat & "','" & komponenObat & "')"
    '        Dim TblsObat As DataTable = ReadThemysql(query, Ttcon)

    '        Dim autoList As New AutoCompleteStringCollection()
    '        For Each row As DataRow In TblsObat.Rows
    '            Dim nama As String = row("namaobat").ToString().Trim()
    '            If nama <> "" AndAlso Not autoList.Contains(nama) Then
    '                autoList.Add(nama)
    '            End If
    '        Next

    '        TextBoxNamaObat.AutoCompleteMode = AutoCompleteMode.SuggestAppend
    '        TextBoxNamaObat.AutoCompleteSource = AutoCompleteSource.CustomSource
    '        TextBoxNamaObat.AutoCompleteCustomSource = autoList

    '    Catch ex As Exception
    '        MsgBox("Gagal memuat autofill obat: " & ex.Message, MsgBoxStyle.Exclamation, "Error")
    '    End Try
    'End Sub

    Private Sub BGWorkerAutoFill_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BGWorkerAutoFill.DoWork
        Try
            If String.IsNullOrEmpty(Ttcon.Tdb) Then
                Connection()
            End If

            Dim lokasiApotek As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='LokasiApotek'")
            Dim query As String = "CALL Sp_GetStockListKlinik('" & lokasiApotek & "','','')"
            Dim TblsObat As DataTable = ReadThemysql(query, Ttcon)

            Dim autoList As New AutoCompleteStringCollection()
            Dim setNama As New Hashtable()

            For Each row As DataRow In TblsObat.Rows
                Dim nama As String = row("namaobat").ToString().Trim()
                If nama <> "" AndAlso Not setNama.ContainsKey(nama) Then
                    setNama.Add(nama, True)
                    autoList.Add(nama)
                End If
            Next

            e.Result = autoList

        Catch ex As Exception
            MessageBox.Show("Gagal memuat autofill obat: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub BGWorkerAutoFill_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BGWorkerAutoFill.RunWorkerCompleted
        Try
            LabelLoading.Visible = False
            TimerBlink.Enabled = False
            LabelLoading.ForeColor = Color.Gray

            If e.Result IsNot Nothing Then
                Dim autoList As AutoCompleteStringCollection = CType(e.Result, AutoCompleteStringCollection)

                ' Simpan ke cache global
                CachedAutoList = autoList

                TextBoxNamaObat.AutoCompleteMode = AutoCompleteMode.SuggestAppend
                TextBoxNamaObat.AutoCompleteSource = AutoCompleteSource.CustomSource
                TextBoxNamaObat.AutoCompleteCustomSource = CachedAutoList
            End If
        Catch ex As Exception
            MessageBox.Show("Gagal mengatur AutoComplete: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
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
                MsgBox("Data tidak ditemukan di data Apotek.", MsgBoxStyle.Exclamation, "Warning!")
            End If

            GridPencarian.DataSource = Tdata
            'GridView1.Columns("PRB").Visible = False


            '========================================
            ' Ambil data obat dari MasterObatBPJS
            '========================================

            Dim keywordSet As New HashSet(Of String)(StringComparer.OrdinalIgnoreCase)

            ' Tambahkan namaObat dari TextBox
            If namaObat <> "" Then
                keywordSet.Add(namaObat)
            End If

            ' Tambahkan komponen dari hasil apotek
            If TblsObat.Rows.Count > 0 Then
                For Each Trow As DataRow In TblsObat.Rows
                    Dim komponen As String = Trow("komponen").ToString().Trim()
                    If komponen <> "" Then
                        keywordSet.Add(komponen)
                    End If
                Next
            End If

            ' Susun WHERE clause
            Dim whereClause As String = ""
            For Each keyword As String In keywordSet
                If whereClause <> "" Then whereClause &= " OR "
                whereClause &= "NamaObat LIKE '%" & keyword.Replace("'", "''") & "%'"
            Next

            ' Buat tabel kosong default untuk reset
            ' Buat tabel kosong default untuk reset
            Dim emptyTable As New DataTable()
            emptyTable.Columns.Add("KodeObat")
            emptyTable.Columns.Add("NamaObat")
            emptyTable.Columns.Add("PilihObat", GetType(Boolean))

            Dim TblsObatBPJS As DataTable = emptyTable

            If whereClause <> "" Then
                Dim queryBPJS As String = "SELECT KodeObat, NamaObat FROM MasterObatBPJS WHERE " & whereClause
                TblsObatBPJS = ReadSQL(queryBPJS)

                ' Tambahkan kolom PilihObat kalau belum ada
                If Not TblsObatBPJS.Columns.Contains("PilihObat") Then
                    TblsObatBPJS.Columns.Add("PilihObat", GetType(Boolean))
                End If

                If TblsObatBPJS.Rows.Count > 0 Then
                    GridObatDPHO.DataSource = TblsObatBPJS
                Else
                    GridObatDPHO.DataSource = emptyTable
                    MsgBox("Obat BPJS tidak ditemukan.", MsgBoxStyle.Information, "Info")
                End If
            Else
                ' kalau keyword kosong, langsung reset
                GridObatDPHO.DataSource = emptyTable
            End If

            '========================================
            ' Jika dua-duanya kosong, kasih info
            '========================================
            If TblsObat.Rows.Count = 0 AndAlso TblsObatBPJS.Rows.Count = 0 Then
                MsgBox("Data tidak ditemukan di Apotek maupun BPJS.", MsgBoxStyle.Exclamation, "Warning!")
            End If
        End If
    End Sub

    Private Sub LoadData(ByRef Baris As Integer)
        If GridView1.RowCount > 0 Then
            Dim Grdrow As DataRowView = GridView1.GetRow(Baris)

            '===== Panggil load data obat apotek seperti biasa =====
            Select Case TForm
                Case "RekamMedisDokterObatNonRacikan"
                    FormRekamMedisDokter.LoadDataObat(Grdrow, TForm)
                Case "RekamMedisDokterObatRacikan"
                    FormRekamMedisDokter.LoadDataObat(Grdrow, TForm)
            End Select

            '===== Tambahan: Ambil obat BPJS yang dicentang di GridObatDPHO =====
            Dim kodeObatBPJS As String = ""
            Dim namaObatBPJS As String = ""

            For Each r As DataGridViewRow In GridObatDPHO.Rows
                If Not r.IsNewRow Then
                    Dim isChecked As Boolean = False
                    Dim cellVal = r.Cells("PilihObat").Value
                    If cellVal IsNot Nothing AndAlso cellVal IsNot DBNull.Value Then
                        isChecked = Convert.ToBoolean(cellVal)
                    End If

                    If isChecked Then
                        kodeObatBPJS = Convert.ToString(r.Cells("KodeObat").Value)
                        namaObatBPJS = Convert.ToString(r.Cells("NamaObat").Value)
                        Exit For ' ambil satu yang dicentang
                    End If
                End If
            Next

            ' Isi textbox BPJS kalau ada yang dicentang
            If kodeObatBPJS <> "" Then
                FormRekamMedisDokter.TextBoxKodeObatDPHO.Text = kodeObatBPJS
                FormRekamMedisDokter.TextBoxObatDPHO.Text = namaObatBPJS
            End If

            '===== Tutup form =====
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

    Private Sub TimerBlink_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerBlink.Tick
        If LabelLoading.ForeColor = Color.Gray Then
            LabelLoading.ForeColor = Color.Black
        Else
            LabelLoading.ForeColor = Color.Gray
        End If
    End Sub
End Class