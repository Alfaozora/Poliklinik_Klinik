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

Public Class ReportDiagnosa
    Private formName As String = "DAFTAR DIAGNOSA"
    Private userInput As String = PoliKlinik.Lbluser.Text

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
        ' Bersihkan kolom jika sudah pernah dibuat
        DataGridViewDaftarDiagnosa.Columns.Clear()
        DataGridViewDaftarDiagnosa.ReadOnly = False

        ' Kolom data
        DataGridViewDaftarDiagnosa.Columns.Add("ColumnKodeDiagnosa", "Kode Diagnosa")
        DataGridViewDaftarDiagnosa.Columns.Add("ColumnNamaDiagnosa", "Nama Diagnosa")
        DataGridViewDaftarDiagnosa.Columns.Add("ColumnRentangUsia", "Rentang Usia")
        DataGridViewDaftarDiagnosa.Columns.Add("ColumnJumlah", "Jumlah")

        ' Kolom checkbox di akhir
        Dim chk As New DataGridViewCheckBoxColumn()
        chk.HeaderText = "Pilih"
        chk.Name = "ColumnPilih"
        chk.Width = 50
        chk.ReadOnly = False
        chk.AutoSizeMode = DataGridViewAutoSizeColumnMode.None ' Supaya tidak ikut fill
        chk.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        chk.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewDaftarDiagnosa.Columns.Add(chk)

        ' Styling
        DataGridViewDaftarDiagnosa.DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        DataGridViewDaftarDiagnosa.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI Semibold", 10, FontStyle.Bold)
        DataGridViewDaftarDiagnosa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewDaftarDiagnosa.EditMode = DataGridViewEditMode.EditOnEnter

        ' Atur lebar tetap untuk kolom tertentu
        With DataGridViewDaftarDiagnosa.Columns("ColumnKodeDiagnosa")
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Width = 150
            .ReadOnly = True
        End With

        With DataGridViewDaftarDiagnosa.Columns("ColumnNamaDiagnosa")
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .ReadOnly = True
        End With

        With DataGridViewDaftarDiagnosa.Columns("ColumnRentangUsia")
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Width = 150
            .ReadOnly = True
        End With

        With DataGridViewDaftarDiagnosa.Columns("ColumnJumlah")
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            .Width = 150
            .ReadOnly = True
        End With
    End Sub

    Private Sub HeaderCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim headerCheckBox As CheckBox = CType(sender, CheckBox)

        For Each row As DataGridViewRow In DataGridViewDaftarDiagnosa.Rows
            If Not row.IsNewRow Then
                row.Cells("ColumnPilih").Value = headerCheckBox.Checked
            End If
        Next
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
        ComboBoxPoliTujuan.Items.Add("Semua Transaksi")
        Dim tblsPoliTujuan As DataTable = ReadSQL("SELECT * FROM MasterPoliTujuan WHERE PoliSakit = 'True'")
        For Each TrowPoliTujuan As DataRow In tblsPoliTujuan.Rows
            ComboBoxPoliTujuan.Items.Add(TrowPoliTujuan("NamaPoli"))
        Next
        ComboBoxPoliTujuan.SelectedIndex = 0

        ComboBoxTingkatPelayanan.SelectedIndex = 0
        ComboBoxIndikator.SelectedIndex = 0

        ' Create DataGridView
        CreateDataGridViewKunjunganPasien()
        ButtonSearchDiagnosa.PerformClick()
    End Sub

    Private Sub SearchDataDiagnosa()
        If Checking() = True Then
            DataGridViewDaftarDiagnosa.Rows.Clear()

            Dim Tbls As DataTable = LoadDataDiagnosa()

            If Tbls.Rows.Count > 0 Then
                For Each Trow As DataRow In Tbls.Rows
                    DataGridViewDaftarDiagnosa.Rows.Add(Trow("Kode Diagnosa").ToString(), Trow("Nama Diagnosa").ToString(), Trow("Rentang Usia").ToString(), Trow("Jumlah").ToString(), False)
                Next

                DataGridViewDaftarDiagnosa.CurrentCell = Nothing
            Else
                MsgBox("Data tidak ditemukan.", MsgBoxStyle.Exclamation, "Warning!")
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

    Private Sub ButtonButtonSearchDiagnosa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSearchDiagnosa.Click
        SearchDataDiagnosa()
    End Sub

    Private Sub ButtonCetakDiagnosa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCetakDiagnosa.Click
        CetakData()
    End Sub

    Private Sub CetakData()
        ' Buat DataTable kosong untuk data yang dicentang
        Dim selectedTable As New DataTable
        selectedTable.Columns.Add("No", GetType(Integer))
        selectedTable.Columns.Add("Kode Diagnosa", GetType(String))
        selectedTable.Columns.Add("Nama Diagnosa", GetType(String))
        selectedTable.Columns.Add("Rentang Usia", GetType(String))
        selectedTable.Columns.Add("Jumlah", GetType(Integer))

        Dim noUrut As Integer = 1

        ' Ambil data dari DataGridView yang dicentang
        For Each row As DataGridViewRow In DataGridViewDaftarDiagnosa.Rows
            If Not row.IsNewRow AndAlso Convert.ToBoolean(row.Cells("ColumnPilih").Value) = True Then
                Dim newRow As DataRow = selectedTable.NewRow()
                newRow("No") = noUrut
                noUrut += 1
                newRow("Kode Diagnosa") = row.Cells("ColumnKodeDiagnosa").Value.ToString()
                newRow("Nama Diagnosa") = row.Cells("ColumnNamaDiagnosa").Value.ToString()
                newRow("Rentang Usia") = row.Cells("ColumnRentangUsia").Value.ToString()
                newRow("Jumlah") = Convert.ToInt32(row.Cells("ColumnJumlah").Value)
                selectedTable.Rows.Add(newRow)
            End If
        Next

        If selectedTable.Rows.Count > 0 Then
            Dim kodePPK As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'KodePPK'")
            Dim namaPPK As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NamaPPK'")

            Report = XtraReport.FromFile(Application.StartupPath + "\Reports\Klinik\LaporanDiagnosa.repx", True)
            Report.DataSource = selectedTable

            Report.Bands.Item(BandKind.ReportHeader).Controls("xrLabelFKTP").Text = namaPPK & " - " & kodePPK

            Dim tglAwal As String = Format(DateTimePickerAwal.Value, "dd MMM yyyy")
            Dim tglAkhir As String = Format(DateTimePickerAkhir.Value, "dd MMM yyyy")
            Report.Bands.Item(BandKind.ReportHeader).Controls("xrLabelBulan").Text = tglAwal & " - " & tglAkhir

            Report.Bands.Item(BandKind.ReportHeader).Controls("xrLabelPelayanan").Text = ComboBoxTingkatPelayanan.Text
            Report.Bands.Item(BandKind.ReportHeader).Controls("xrLabelIndikator").Text = ComboBoxIndikator.Text
            Report.Bands.Item(BandKind.ReportHeader).Controls("xrLabelPoli").Text = ComboBoxPoliTujuan.Text

            Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:ss") & " By " & PoliKlinik.Lbluser.Text

            'Report.RunDesigner()
            Report.ShowPreview()
        Else
            MsgBox("Tidak ada data yang dipilih untuk dicetak.", MsgBoxStyle.Exclamation, "Peringatan")
        End If
    End Sub

    Function LoadDataDiagnosa() As DataTable
        Dim queryString As String = ""

        ' Ambil tanggal awal dan akhir dari DateTimePicker
        Dim tanggalAwal As String = Format(DateTimePickerAwal.Value, "yyyy-MM-dd")
        Dim tanggalAkhir As String = Format(DateTimePickerAkhir.Value, "yyyy-MM-dd")

        ' Set Tingkat Pelayanan
        Dim tingkatPelayananSearch As String = ""
        If ComboBoxTingkatPelayanan.Text <> "Semua" Then
            tingkatPelayananSearch = " AND JenisRawat = '" & ComboBoxTingkatPelayanan.Text & "'"
        End If

        ' Set Indikator
        Dim indikatorSearch As String = ""
        If ComboBoxIndikator.Text = "Kunjungan" Then
            indikatorSearch = " AND StatusPulang LIKE '%Berobat Jalan%'"
        ElseIf ComboBoxIndikator.Text = "Rujukan" Then
            indikatorSearch = " AND StatusPulang LIKE '%Rujuk%'"
        End If

        ' Set Jenis Poli
        Dim jenisPoliSearch As String = ""
        If ComboBoxPoliTujuan.Text <> "Semua Transaksi" Then
            jenisPoliSearch = " AND JenisPoli = '" & ComboBoxPoliTujuan.Text & "'"
        End If

        ' Buat query
        queryString = "SELECT ROW_NUMBER() OVER (ORDER BY COUNT(tdd.KodeDiagnosa) DESC) AS 'No', " & _
              "tdd.KodeDiagnosa AS 'Kode Diagnosa', tdd.KeteranganDiagnosa AS 'Nama Diagnosa', " & _
              "CASE " & _
              "    WHEN DATEDIFF(YEAR, mp.TglLahir, GETDATE()) < 1 THEN '<1' " & _
              "    WHEN DATEDIFF(YEAR, mp.TglLahir, GETDATE()) BETWEEN 1 AND 4 THEN '1-4' " & _
              "    WHEN DATEDIFF(YEAR, mp.TglLahir, GETDATE()) BETWEEN 5 AND 14 THEN '5-14' " & _
              "    WHEN DATEDIFF(YEAR, mp.TglLahir, GETDATE()) BETWEEN 15 AND 44 THEN '15-44' " & _
              "    WHEN DATEDIFF(YEAR, mp.TglLahir, GETDATE()) BETWEEN 45 AND 55 THEN '45-55' " & _
              "    WHEN DATEDIFF(YEAR, mp.TglLahir, GETDATE()) BETWEEN 55 AND 64 THEN '55-64' " & _
              "    ELSE '>65' " & _
              "END AS 'Rentang Usia', " & _
              "COUNT(tdd.KodeDiagnosa) AS 'Jumlah' " & _
              "FROM TransaksiDetailDiagnosa tdd " & _
              "JOIN TransaksiDetail td ON tdd.NoTransaksi = td.NoUrut " & _
              "JOIN MasterPasien mp ON td.IDInternet = mp.NoRekamMedis " & _
              "WHERE tdd.DeletedDate IS NULL " & _
              "AND CONVERT(date, td.TanggalTransaksi) BETWEEN '" & tanggalAwal & "' AND '" & tanggalAkhir & "'" & _
              tingkatPelayananSearch & indikatorSearch & jenisPoliSearch & " " & _
              "GROUP BY tdd.KodeDiagnosa, tdd.KeteranganDiagnosa, " & _
              "CASE " & _
              "    WHEN DATEDIFF(YEAR, mp.TglLahir, GETDATE()) < 1 THEN '<1' " & _
              "    WHEN DATEDIFF(YEAR, mp.TglLahir, GETDATE()) BETWEEN 1 AND 4 THEN '1-4' " & _
              "    WHEN DATEDIFF(YEAR, mp.TglLahir, GETDATE()) BETWEEN 5 AND 14 THEN '5-14' " & _
              "    WHEN DATEDIFF(YEAR, mp.TglLahir, GETDATE()) BETWEEN 15 AND 44 THEN '15-44' " & _
              "    WHEN DATEDIFF(YEAR, mp.TglLahir, GETDATE()) BETWEEN 45 AND 55 THEN '45-55' " & _
              "    WHEN DATEDIFF(YEAR, mp.TglLahir, GETDATE()) BETWEEN 55 AND 64 THEN '55-64' " & _
              "    ELSE '>65' " & _
              "END " & _
              "ORDER BY COUNT(tdd.KodeDiagnosa) DESC"

        ' Eksekusi query
        Dim Tbls As DataTable = ReadSQL(queryString)
        Return Tbls
    End Function

    Private Sub TextBoxSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxSearch.TextChanged
        Dim searchText As String = TextBoxSearch.Text.Trim().ToLower()

        For Each row As DataGridViewRow In DataGridViewDaftarDiagnosa.Rows
            If row.IsNewRow Then Continue For ' Lewati baris baru/kosong

            Dim kodeDiagnosa As String = row.Cells("ColumnKodeDiagnosa").Value.ToString().ToLower()
            Dim namaDiagnosa As String = row.Cells("ColumnNamaDiagnosa").Value.ToString().ToLower()

            ' Tampilkan hanya baris yang cocok di salah satu kolom
            row.Visible = kodeDiagnosa.Contains(searchText) OrElse namaDiagnosa.Contains(searchText)
        Next
    End Sub

    Private Sub CBPilihSemua_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBPilihSemua.CheckedChanged
        For Each row As DataGridViewRow In DataGridViewDaftarDiagnosa.Rows
            If Not row.IsNewRow Then
                row.Cells("ColumnPilih").Value = CBPilihSemua.Checked
            End If
        Next
    End Sub

    Private Sub BtnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExcel.Click
        ' Cek apakah ada baris yang dicentang
        Dim adaYangDipilih As Boolean = False
        For Each row As DataGridViewRow In DataGridViewDaftarDiagnosa.Rows
            If Not row.IsNewRow AndAlso Convert.ToBoolean(row.Cells("ColumnPilih").Value) = True Then
                adaYangDipilih = True
                Exit For
            End If
        Next

        ' Jika tidak ada yang dipilih, tampilkan pesan dan keluar
        If Not adaYangDipilih Then
            MsgBox("Silakan pilih data terlebih dahulu sebelum mengunduh.", MsgBoxStyle.Exclamation, "Peringatan")
            Exit Sub
        End If

        ' Dialog simpan
        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "CSV files (*.csv)|*.csv"
        saveFileDialog.Title = "Simpan sebagai CSV"
        saveFileDialog.FileName = "LaporanDiagnosa_" & Format(Now, "yyyyMMdd_HHmmss") & ".csv"

        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            Using sw As New System.IO.StreamWriter(saveFileDialog.FileName, False, System.Text.Encoding.UTF8)
                ' Tulis header
                For i As Integer = 0 To DataGridViewDaftarDiagnosa.Columns.Count - 2 ' exclude checkbox
                    sw.Write("""" & DataGridViewDaftarDiagnosa.Columns(i).HeaderText.Replace("""", """""") & """")
                    If i < DataGridViewDaftarDiagnosa.Columns.Count - 2 Then sw.Write(",")
                Next
                sw.WriteLine()

                ' Tulis data yang dicentang
                For Each row As DataGridViewRow In DataGridViewDaftarDiagnosa.Rows
                    If Not row.IsNewRow AndAlso Convert.ToBoolean(row.Cells("ColumnPilih").Value) = True Then
                        For i As Integer = 0 To DataGridViewDaftarDiagnosa.Columns.Count - 2 ' exclude checkbox
                            Dim cellValue As String = If(row.Cells(i).Value IsNot Nothing, row.Cells(i).Value.ToString(), "")
                            sw.Write("""" & cellValue.Replace("""", """""") & """")
                            If i < DataGridViewDaftarDiagnosa.Columns.Count - 2 Then sw.Write(",")
                        Next
                        sw.WriteLine()
                    End If
                Next
            End Using

            MsgBox("Data berhasil disimpan sebagai CSV.", MsgBoxStyle.Information, "Berhasil")
        End If
    End Sub
End Class