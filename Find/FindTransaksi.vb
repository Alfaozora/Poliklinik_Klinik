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

Public Class FindTransaksi
    Private formName As String = "DATA KUNJUNGAN PASIEN"
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

    Private Sub CreateDataGridViewKunjunganPasien()
        ' Add columns
        DataGridViewKunjunganPasien.Columns.Add("ColumnNo", "No")
        DataGridViewKunjunganPasien.Columns.Add("ColumnNoTransaksi", "No Transaksi")
        DataGridViewKunjunganPasien.Columns.Add("ColumnNoRM", "NoRM")
        DataGridViewKunjunganPasien.Columns.Add("ColumnTglTransaksi", "Tgl. Transaksi")
        DataGridViewKunjunganPasien.Columns.Add("ColumnNama", "Nama")
        DataGridViewKunjunganPasien.Columns.Add("ColumnNamaPoli", "Layanan")
        DataGridViewKunjunganPasien.Columns.Add("ColumnJenisPoli", "JenisPoli")
        DataGridViewKunjunganPasien.Columns.Add("ColumnDokter", "Dokter")
        DataGridViewKunjunganPasien.Columns.Add("ColumnPenagihan", "Tagihan")
        DataGridViewKunjunganPasien.Columns.Add("ColumnStatus", "Status")
        DataGridViewKunjunganPasien.Columns.Add("ColumnNoBPJS", "Nomor BPJS")
        DataGridViewKunjunganPasien.Columns.Add("ColumnKeluhan", "Keluhan")
        DataGridViewKunjunganPasien.Columns.Add("ColumnNoNIK", "No NIK")
        DataGridViewKunjunganPasien.Columns.Add("ColumnJenisRawat", "JenisRawat")

        ' Hide
        DataGridViewKunjunganPasien.Columns("ColumnJenisPoli").Visible = False
        DataGridViewKunjunganPasien.Columns("ColumnNoBPJS").Visible = False
        DataGridViewKunjunganPasien.Columns("ColumnKeluhan").Visible = False
        DataGridViewKunjunganPasien.Columns("ColumnNoNIK").Visible = False
        DataGridViewKunjunganPasien.Columns("ColumnJenisRawat").Visible = False

        ' Setting
        DataGridViewKunjunganPasien.DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        DataGridViewKunjunganPasien.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI Semibold", 10, FontStyle.Bold)
        DataGridViewKunjunganPasien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        ' Mengatur lebar maksimum untuk kolom kode diagnosa
        Dim increamentDataColumn As DataGridViewColumn = DataGridViewKunjunganPasien.Columns("ColumnNo")
        increamentDataColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.None ' Menonaktifkan penyesuaian otomatis
        increamentDataColumn.Width = 50 ' Mengatur lebar maksimums
    End Sub

    Private Sub Find_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Control.CheckForIllegalCrossThreadCalls = False
            Me.MdiParent = PoliKlinik
            Me.Dock = DockStyle.Fill

            ' Clear data
            SetAwal()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub SetAwal()
        ' Set ComboBox Poli Tujuan
        ComboBoxPoliTujuan.Items.Clear()
        ComboBoxPoliTujuan.Items.Add("SEMUA TRANSAKSI")
        Dim tblsPoliTujuan As DataTable = ReadSQL("SELECT * FROM MasterPoliTujuan WHERE PoliSakit = 'True'")
        For Each TrowPoliTujuan As DataRow In tblsPoliTujuan.Rows
            ComboBoxPoliTujuan.Items.Add(TrowPoliTujuan("NamaPoli"))
        Next
        ComboBoxPoliTujuan.SelectedIndex = 0

        ComboBoxJenisKunjungan.SelectedIndex = 0
        TextBoxAbjadBPJS.ResetText()
        TextBoxAbjadBPJS.Enabled = True
        TextBoxAbjadBPJS.BackColor = Color.White

        ' Create DataGridView
        CreateDataGridViewKunjunganPasien()
        ButtonFindTransaksi.PerformClick()
    End Sub

    Private Sub FindQuery(ByVal getSearch As String)
        If Checking() = True Then
            DataGridViewKunjunganPasien.Rows.Clear()

            ' Next Step
            Dim Tnow As Date = dtprocess.Value
            Dim Tend As Date = dtend.Value
            Dim Tquery As String = ""
            Dim TquerySearch As String = ""

            ' Query Search
            If getSearch = "No. Antrian" Then
                TquerySearch = " AND TransaksiDetail.NoUrutBPJS = '" & TextBoxAbjadBPJS.Text & TextBoxNoAntrian.Text & "'"
            ElseIf getSearch = "No. Kartu" Then
                TquerySearch = " AND MasterPasien.NoKartuBPJS = '" & TextBoxNoAntrian.Text & "'"
            End If

            If ComboBoxPoliTujuan.Text = "SEMUA TRANSAKSI" Then
                Tquery = "SELECT * FROM( " & _
                             "SELECT TransaksiDetail.JenisPenagihan, TransaksiDetail.JenisTransaksi, TransaksiDetail.JenisPoli, TransaksiPoli.NoUrut, MasterPasien.NoRekamMedis, TransaksiPoli.TglPoli AS 'TglTransaksi', MasterPasien.Nama, TransaksiPoli.DokterPoli AS 'NamaDokter', TransaksiPoli.StatusKeterangan AS 'Status', MasterPasien.NoKartuBPJS, MasterPasien.NoNIK, TransaksiDetail.KeluhanUtama, TransaksiDetail.JenisRawat " & _
                             "FROM TransaksiPoli " & _
                             "LEFT JOIN TransaksiDetail ON TransaksiPoli.NoUrut=TransaksiDetail.NoUrut " & _
                             "LEFT JOIN MasterPasien ON TransaksiPoli.IDInternet=MasterPasien.NoRekamMedis " & _
                             "WHERE TransaksiPoli.deleted = 0 AND (CONVERT(date, TransaksiDetail.TanggalTransaksi) BETWEEN '" & Format(Tnow.Date, "MM/dd/yyyy") & "' AND '" & Format(Tend.Date, "MM/dd/yyyy") & "') AND TransaksiDetail.TransaksiPaket = 0 " & TquerySearch & _
                             "UNION ALL " & _
                             "SELECT TransaksiDetail.JenisPenagihan, TransaksiDetail.JenisTransaksi, TransaksiDetail.JenisPoli, TransaksiGigi.NoUrut, MasterPasien.NoRekamMedis, TransaksiGigi.TglGigi AS 'TglTransaksi', MasterPasien.Nama, TransaksiGigi.DokterGigi AS 'NamaDokter', TransaksiGigi.StatusKeterangan AS 'Status', MasterPasien.NoKartuBPJS, MasterPasien.NoNIK, TransaksiDetail.KeluhanUtama, TransaksiDetail.JenisRawat " & _
                             "FROM TransaksiGigi " & _
                             "LEFT JOIN TransaksiDetail ON TransaksiGigi.NoUrut=TransaksiDetail.NoUrut " & _
                             "LEFT JOIN MasterPasien ON TransaksiGigi.IDInternet=MasterPasien.NoRekamMedis " & _
                             "WHERE TransaksiGigi.deleted = 0 AND (CONVERT(date, TransaksiDetail.TanggalTransaksi) BETWEEN '" & Format(Tnow.Date, "MM/dd/yyyy") & "' AND '" & Format(Tend.Date, "MM/dd/yyyy") & "') AND TransaksiDetail.TransaksiPaket = 0 " & TquerySearch & _
                         ") AS CombinedResults " & _
                         "ORDER BY TglTransaksi, NoUrut"
            Else
                ' Get Data Master Poli
                Dim tblPoli As DataTable = ReadSQL("SELECT * FROM MasterPoliTujuan WHERE NamaPoli = '" & ComboBoxPoliTujuan.Text & "'")
                Dim TrowPoli As DataRow = tblPoli.Rows(0)

                Select Case TrowPoli("JenisPoli")
                    Case "UMUM"
                        Tquery = "SELECT TransaksiDetail.JenisPenagihan, TransaksiDetail.JenisTransaksi, TransaksiDetail.JenisPoli, TransaksiPoli.NoUrut, MasterPasien.NoRekamMedis, TransaksiPoli.TglPoli AS 'TglTransaksi', MasterPasien.Nama, TransaksiPoli.DokterPoli AS 'NamaDokter', TransaksiPoli.StatusKeterangan AS 'Status', MasterPasien.NoKartuBPJS, MasterPasien.NoNIK, TransaksiDetail.KeluhanUtama, TransaksiDetail.JenisRawat " & _
                                 "FROM TransaksiPoli " & _
                                 "LEFT JOIN TransaksiDetail ON TransaksiPoli.NoUrut = TransaksiDetail.NoUrut " & _
                                 "LEFT JOIN MasterPasien ON TransaksiPoli.IDInternet = MasterPasien.NoRekamMedis " & _
                                 "WHERE TransaksiPoli.deleted = 0 AND (CONVERT(DATE, TransaksiPoli.TglPoli) BETWEEN '" & Format(Tnow.Date, "MM/dd/yyyy") & "' AND '" & Format(Tend.Date, "MM/dd/yyyy") & "') AND TransaksiDetail.JenisPoli = '" & TrowPoli("NamaPoli") & "' AND TransaksiDetail.TransaksiPaket = 0" & TquerySearch
                    Case "GIGI"
                        Tquery = "SELECT TransaksiDetail.JenisPenagihan, TransaksiDetail.JenisTransaksi, TransaksiDetail.JenisPoli, TransaksiGigi.NoUrut, MasterPasien.NoRekamMedis, TransaksiGigi.TglGigi AS 'TglTransaksi', MasterPasien.Nama, TransaksiGigi.DokterGigi AS 'NamaDokter', TransaksiGigi.StatusKeterangan AS 'Status', MasterPasien.NoKartuBPJS, MasterPasien.NoNIK, TransaksiDetail.KeluhanUtama, TransaksiDetail.JenisRawat " & _
                                 "FROM TransaksiGigi " & _
                                 "LEFT JOIN TransaksiDetail ON TransaksiGigi.NoUrut = TransaksiDetail.NoUrut " & _
                                 "LEFT JOIN MasterPasien ON TransaksiGigi.IDInternet = MasterPasien.NoRekamMedis " & _
                                 "WHERE TransaksiGigi.deleted = 0 AND (CONVERT(DATE, TransaksiGigi.TglGigi) BETWEEN '" & Format(Tnow.Date, "MM/dd/yyyy") & "' AND '" & Format(Tend.Date, "MM/dd/yyyy") & "') AND TransaksiDetail.JenisPoli = '" & TrowPoli("NamaPoli") & "' AND TransaksiDetail.TransaksiPaket = 0" & TquerySearch
                    Case "LABORATORIUM"

                End Select
            End If

            Dim Tbls As DataTable = ReadSQL(Tquery)

            If Tbls.Rows.Count > 0 Then
                Dim jenisPenagihan As String = ""

                For Each Trow As DataRow In Tbls.Rows
                    ' Set Penagihan
                    If IsDBNull(Trow("JenisPenagihan")) = False Then
                        jenisPenagihan = Trow("JenisPenagihan").ToString
                    Else
                        jenisPenagihan = GetJenisPembayaran(Trow("JenisTransaksi"), Trow("NoUrut"))
                    End If

                    DataGridViewKunjunganPasien.Rows.Add(New String() {"-", "" & Trow("NoUrut") & "", "" & Trow("NoRekamMedis") & "", "" & Format(Trow("TglTransaksi"), "yyyy-MM-dd HH:mm:ss") & "", "" & Trow("Nama") & "", "" & Trow("JenisPoli") & "", "" & Trow("JenisTransaksi") & "", "" & Trow("NamaDokter") & "", "" & jenisPenagihan & "", "" & Trow("Status") & "", "" & Trow("NoKartuBPJS") & "", "" & Trow("KeluhanUtama") & "", "" & Trow("NoNIK") & "", "" & Trow("JenisRawat") & ""})
                Next

                DataGridViewKunjunganPasien.CurrentCell = Nothing
            Else
                MsgBox("Data tidak ditemukan. Entry Pendaftaran terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            End If
        End If
    End Sub

    Function Checking() As Boolean
        If ComboBoxPoliTujuan.SelectedIndex = -1 Then
            MsgBox("Pilih poli tujuan terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        Return True
    End Function

    Private Sub ComboBoxJenisKunjungan_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxJenisKunjungan.SelectedIndexChanged
        If ComboBoxJenisKunjungan.SelectedIndex = 0 Then
            SetComboBoxPoliTujuan(True)
        ElseIf ComboBoxJenisKunjungan.SelectedIndex = 1 Then
            SetComboBoxPoliTujuan(False)
        End If
    End Sub

    Private Sub SetComboBoxPoliTujuan(ByVal poliSakit As Boolean)
        ComboBoxPoliTujuan.Items.Clear()
        Dim tblsPoliTujuan As DataTable = ReadSQL("SELECT * FROM MasterPoliTujuan WHERE PoliSakit = '" & poliSakit & "'")
        ComboBoxPoliTujuan.Items.Add("SEMUA TRANSAKSI")
        For Each TrowPoliTujuan As DataRow In tblsPoliTujuan.Rows
            ComboBoxPoliTujuan.Items.Add(TrowPoliTujuan("NamaPoli"))
        Next

        ComboBoxPoliTujuan.SelectedIndex = 0
    End Sub

    Private Sub ButtonFindTransaksi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFindTransaksi.Click
        FindQuery("Nothing")
    End Sub

    Private Sub RadioButtonNoAntrian_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonNoAntrian.CheckedChanged, RadioButtonNoKartu.CheckedChanged
        If RadioButtonNoAntrian.Checked = True Then
            TextBoxAbjadBPJS.Enabled = True
            TextBoxAbjadBPJS.BackColor = Color.White
        ElseIf RadioButtonNoKartu.Checked = True Then
            TextBoxAbjadBPJS.Enabled = False
            TextBoxAbjadBPJS.BackColor = Color.Black
        End If
    End Sub

    Private Sub ButtonFindNoAntrian_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFindNoAntrian.Click
        If RadioButtonNoAntrian.Checked = True Then
            FindQuery("No. Antrian")
        ElseIf RadioButtonNoKartu.Checked = True Then
            FindQuery("No. Kartu")
        End If
    End Sub

    Private Sub ComboBoxPoliTujuan_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxPoliTujuan.SelectedIndexChanged
        If ComboBoxPoliTujuan.Text = "SEMUA TRANSAKSI" Then
            TextBoxAbjadBPJS.ResetText()
        Else
            ' Get Data Master Poli
            Dim tblPoli As DataTable = ReadSQL("SELECT * FROM MasterPoliTujuan WHERE NamaPoli = '" & ComboBoxPoliTujuan.Text & "'")
            Dim TrowPoli As DataRow = tblPoli.Rows(0)

            If IsDBNull(TrowPoli("AbjadBPJS")) = False Then
                TextBoxAbjadBPJS.Text = TrowPoli("AbjadBPJS")
            Else
                TextBoxAbjadBPJS.ResetText()
            End If
        End If
    End Sub

    Private Sub DataGridViewKunjunganPasien_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles DataGridViewKunjunganPasien.RowPrePaint
        Dim row As DataGridViewRow = DataGridViewKunjunganPasien.Rows(e.RowIndex)
        Dim statusCell As DataGridViewCell = row.Cells("ColumnStatus") ' Ganti "Status" dengan nama kolom yang sesuai

        If statusCell.Value IsNot Nothing AndAlso statusCell.Value.ToString() = "Belum Diperiksa" Then
            row.DefaultCellStyle.BackColor = Color.FromArgb(242, 222, 222)
            row.DefaultCellStyle.ForeColor = Color.Black
        ElseIf statusCell.Value IsNot Nothing AndAlso statusCell.Value.ToString() = "Sedang dilakukan TTV" Then
            row.DefaultCellStyle.BackColor = Color.FromArgb(253, 253, 189)
            row.DefaultCellStyle.ForeColor = Color.Black
        ElseIf statusCell.Value IsNot Nothing AndAlso statusCell.Value.ToString() = "Sudah dilakukan TTV" Then
            row.DefaultCellStyle.BackColor = Color.FromArgb(253, 253, 189)
            row.DefaultCellStyle.ForeColor = Color.Black
        ElseIf statusCell.Value IsNot Nothing AndAlso statusCell.Value.ToString() = "Sedang Diperiksa Dokter" Then
            row.DefaultCellStyle.BackColor = Color.FromArgb(184, 232, 252)
            row.DefaultCellStyle.ForeColor = Color.Black
        ElseIf statusCell.Value IsNot Nothing AndAlso statusCell.Value.ToString() = "Sudah Diperiksa" Then
            row.DefaultCellStyle.BackColor = Color.FromArgb(195, 237, 192)
            row.DefaultCellStyle.ForeColor = Color.Black
        End If
    End Sub

    'DEBUG
    'Private Sub DataGridViewKunjunganPasien_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewKunjunganPasien.CellDoubleClick
    '    If e.RowIndex >= 0 Then
    '        MsgBox("▶ Event CellDoubleClick dipanggil. RowIndex=" & e.RowIndex & ", ColumnIndex=" & e.ColumnIndex)

    '        ' Set Data Transaksi
    '        Dim jenisUser As String = ReadSQLNIK("SELECT GroupID FROM Users WHERE UserID = '" & userInput & "'")
    '        Dim noTransaksi As String = DataGridViewKunjunganPasien.Rows(e.RowIndex).Cells("ColumnNoTransaksi").Value.ToString()
    '        Dim jenisPoli As String = DataGridViewKunjunganPasien.Rows(e.RowIndex).Cells("ColumnJenisPoli").Value.ToString()
    '        Dim noRM As String = DataGridViewKunjunganPasien.Rows(e.RowIndex).Cells("ColumnNoRM").Value.ToString()
    '        Dim namaPoli As String = DataGridViewKunjunganPasien.Rows(e.RowIndex).Cells("ColumnNamaPoli").Value.ToString()
    '        Dim noBPJS As String = DataGridViewKunjunganPasien.Rows(e.RowIndex).Cells("ColumnNoBPJS").Value.ToString()
    '        Dim keluhan As String = DataGridViewKunjunganPasien.Rows(e.RowIndex).Cells("ColumnKeluhan").Value.ToString()
    '        Dim noNIK As String = DataGridViewKunjunganPasien.Rows(e.RowIndex).Cells("ColumnNoNIK").Value.ToString()
    '        Dim jenisRawat As String = DataGridViewKunjunganPasien.Rows(e.RowIndex).Cells("ColumnJenisRawat").Value.ToString()

    '        MsgBox("Debug Data:" & vbCrLf & _
    '               "JenisUser=" & jenisUser & vbCrLf & _
    '               "NoTransaksi=" & noTransaksi & vbCrLf & _
    '               "JenisPoli=" & jenisPoli & vbCrLf & _
    '               "NoRM=" & noRM & vbCrLf & _
    '               "NamaPoli=" & namaPoli & vbCrLf & _
    '               "NoBPJS=" & noBPJS & vbCrLf & _
    '               "Keluhan=" & keluhan & vbCrLf & _
    '               "NoNIK=" & noNIK & vbCrLf & _
    '               "JenisRawat=" & jenisRawat)

    '        ' Set Status Transaksi
    '        Dim statusTransaksi As String = GetStatusTransaksi(noTransaksi, jenisPoli)
    '        MsgBox("StatusTransaksi=" & statusTransaksi)

    '        If (statusTransaksi = "Belum Diperiksa" Or statusTransaksi = "Sedang dilakukan TTV") And jenisUser.Contains("Dokter") = True Then
    '            MsgBox("Transaksi belum dilakukan TTV oleh perawat.", MsgBoxStyle.Exclamation, "Warning!")
    '        Else
    '            '# Set data dictionary yang akan dikirim ke form popup
    '            Dim dataDictionary As New Dictionary(Of String, Object)()

    '            If (statusTransaksi = "Belum Diperiksa" And jenisUser.Contains("Dokter") = False) Or (statusTransaksi = "Sudah dilakukan TTV" And jenisUser.Contains("Dokter") = True) Then
    '                MsgBox("▶ Akan buka DialogBoxPanggilPasien")

    '                dataDictionary.Add("No Transaksi", noTransaksi)
    '                dataDictionary.Add("No RM", noRM)
    '                dataDictionary.Add("Jenis Poli", jenisPoli)
    '                dataDictionary.Add("Status Transaksi", statusTransaksi)
    '                dataDictionary.Add("Jenis User", jenisUser)
    '                dataDictionary.Add("Nama Poli", namaPoli)
    '                dataDictionary.Add("Nomor BPJS", noBPJS)
    '                dataDictionary.Add("Keluhan", keluhan)
    '                dataDictionary.Add("Nomor NIK", noNIK)
    '                dataDictionary.Add("Jenis Rawat", jenisRawat)

    '                dataDictionary.Add("Text Button Start Proses", "Mulai Pemeriksaan")
    '                dataDictionary.Add("Jenis Proses", "Pendaftaran - Pemeriksaan")

    '                DialogBoxPanggilPasien.DataDictionary = dataDictionary
    '                DialogBoxPanggilPasien.ShowDialog()
    '            Else
    '                MsgBox("▶ Akan buka FormRekamMedisDokter")

    '                FormRekamMedisDokter.SetDataFromPendaftaran(noRM, noTransaksi, jenisPoli)
    '                FormRekamMedisDokter.Show()
    '                FormRekamMedisDokter.BringToFront()
    '            End If

    '            ' Harusnya refresh grid terbaru
    '            MsgBox("▶ Akan panggil FindQuery untuk refresh grid")
    '            FindQuery("Nothing")
    '        End If
    '    End If
    'End Sub

    Private Sub DataGridViewKunjunganPasien_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewKunjunganPasien.CellDoubleClick
        If e.RowIndex >= 0 Then
            ' Set Data Transaksi
            Dim jenisUser As String = ReadSQLNIK("SELECT GroupID FROM Users WHERE UserID = '" & userInput & "'")
            Dim noTransaksi As String = DataGridViewKunjunganPasien.Rows(e.RowIndex).Cells("ColumnNoTransaksi").Value.ToString()
            Dim jenisPoli As String = DataGridViewKunjunganPasien.Rows(e.RowIndex).Cells("ColumnJenisPoli").Value.ToString()
            Dim noRM As String = DataGridViewKunjunganPasien.Rows(e.RowIndex).Cells("ColumnNoRM").Value.ToString()
            Dim namaPoli As String = DataGridViewKunjunganPasien.Rows(e.RowIndex).Cells("ColumnNamaPoli").Value.ToString()
            Dim noBPJS As String = DataGridViewKunjunganPasien.Rows(e.RowIndex).Cells("ColumnNoBPJS").Value.ToString()
            Dim keluhan As String = DataGridViewKunjunganPasien.Rows(e.RowIndex).Cells("ColumnKeluhan").Value.ToString()
            Dim noNIK As String = DataGridViewKunjunganPasien.Rows(e.RowIndex).Cells("ColumnNoNIK").Value.ToString()
            Dim jenisRawat As String = DataGridViewKunjunganPasien.Rows(e.RowIndex).Cells("ColumnJenisRawat").Value.ToString()

            ' Set Status Transaksi
            Dim statusTransaksi As String = GetStatusTransaksi(noTransaksi, jenisPoli)

            If (statusTransaksi = "Belum Diperiksa" Or statusTransaksi = "Sedang dilakukan TTV") And jenisUser.Contains("Dokter") = True Then
                MsgBox("Transaksi belum dilakukan TTV oleh perawat.", MsgBoxStyle.Exclamation, "Warning!")
            Else
                '# Set data dictionary yang akan dikirim ke form popup
                Dim dataDictionary As New Dictionary(Of String, Object)()

                If (statusTransaksi = "Belum Diperiksa" And jenisUser.Contains("Dokter") = False) Or (statusTransaksi = "Sudah dilakukan TTV" And jenisUser.Contains("Dokter") = True) Then
                    dataDictionary.Add("No Transaksi", noTransaksi)
                    dataDictionary.Add("No RM", noRM)
                    dataDictionary.Add("Jenis Poli", jenisPoli)
                    dataDictionary.Add("Status Transaksi", statusTransaksi)
                    dataDictionary.Add("Jenis User", jenisUser)
                    dataDictionary.Add("Nama Poli", namaPoli)
                    dataDictionary.Add("Nomor BPJS", noBPJS)
                    dataDictionary.Add("Keluhan", keluhan)
                    dataDictionary.Add("Nomor NIK", noNIK)
                    dataDictionary.Add("Jenis Rawat", jenisRawat)

                    dataDictionary.Add("Text Button Start Proses", "Mulai Pemeriksaan")
                    dataDictionary.Add("Jenis Proses", "Pendaftaran - Pemeriksaan")

                    DialogBoxPanggilPasien.DataDictionary = dataDictionary
                    DialogBoxPanggilPasien.ShowDialog()
                Else
                    FormRekamMedisDokter.SetDataFromPendaftaran(noRM, noTransaksi, jenisPoli)
                    FormRekamMedisDokter.Show()
                    FormRekamMedisDokter.BringToFront()
                End If

                ' Harusnya refresh grid terbaru
                FindQuery("Nothing")
            End If
        End If
    End Sub

    Private Sub DataGridViewKunjunganPasien_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridViewKunjunganPasien.CellFormatting
        ' Hanya melakukan perubahan pada kolom nomor urut
        If e.ColumnIndex = 0 AndAlso e.RowIndex >= 0 Then ' Kolom nomor urut adalah kolom indeks 0
            e.Value = e.RowIndex + 1 ' Nomor urut dimulai dari 1
        End If
    End Sub

    Private Sub TextBoxSearchKunjungan_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxSearchKunjungan.TextChanged
        SearchDataGridView(DataGridViewKunjunganPasien, TextBoxSearchKunjungan.Text)
    End Sub

    Private Sub SearchDataGridView(ByVal dataGridView As DataGridView, ByVal keyword As String)
        ' Set ulang Visible untuk semua baris sebelum memulai pencarian baru
        For Each row As DataGridViewRow In dataGridView.Rows
            row.Visible = True
        Next

        ' Sekarang lakukan pencarian seperti biasa
        For Each row As DataGridViewRow In dataGridView.Rows
            Dim matchFound As Boolean = False

            If String.IsNullOrEmpty(keyword) Then
                ' Jika teks pencarian kosong, tampilkan semua baris
                matchFound = True
            Else
                For Each cell As DataGridViewCell In row.Cells
                    If cell.Visible AndAlso cell.Value IsNot Nothing AndAlso cell.Value.ToString().IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 Then
                        matchFound = True
                        Exit For
                    End If
                Next
            End If

            row.Visible = matchFound
        Next
    End Sub
End Class