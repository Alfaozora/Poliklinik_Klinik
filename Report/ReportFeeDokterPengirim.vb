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

Public Class ReportFeeDokterPengirim
    Private formName As String = "LAPORAN FEE DOKTER PENGIRIM LAB"
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

    Private Sub CreateDataGridViewFeeDokterPengirim()
        ' Bersihkan kolom jika sudah pernah dibuat
        DataGridViewDaftarFeeDokterPengirim.Columns.Clear()
        DataGridViewDaftarFeeDokterPengirim.ReadOnly = False

        ' Kolom data
        DataGridViewDaftarFeeDokterPengirim.Columns.Add("ColumnNoLab", "NoLab")
        DataGridViewDaftarFeeDokterPengirim.Columns.Add("ColumnTglLab", "TglLab")
        DataGridViewDaftarFeeDokterPengirim.Columns.Add("ColumnNama", "Nama")
        DataGridViewDaftarFeeDokterPengirim.Columns.Add("ColumnNamaTindakan", "Tindakan")
        DataGridViewDaftarFeeDokterPengirim.Columns.Add("ColumnDetailPemeriksaan", "Pemeriksaan")
        DataGridViewDaftarFeeDokterPengirim.Columns.Add("ColumnBiayaTindakan", "Biaya Tindakan")
        DataGridViewDaftarFeeDokterPengirim.Columns.Add("ColumnDiscTindakan", "Fee Dokter")
        DataGridViewDaftarFeeDokterPengirim.Columns.Add("ColumnNettBayar", "Nett Bayar")
        DataGridViewDaftarFeeDokterPengirim.Columns.Add("ColumnDrNama", "Dokter")


        ' Kolom checkbox di akhir
        Dim chk As New DataGridViewCheckBoxColumn()
        chk.HeaderText = "Pilih"
        chk.Name = "ColumnPilih"
        chk.Width = 50
        chk.ReadOnly = False
        chk.AutoSizeMode = DataGridViewAutoSizeColumnMode.None ' Supaya tidak ikut fill
        chk.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        chk.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewDaftarFeeDokterPengirim.Columns.Add(chk)

        ' Styling
        DataGridViewDaftarFeeDokterPengirim.DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        DataGridViewDaftarFeeDokterPengirim.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI Semibold", 10, FontStyle.Bold)
        DataGridViewDaftarFeeDokterPengirim.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewDaftarFeeDokterPengirim.EditMode = DataGridViewEditMode.EditOnEnter

        ' Atur lebar tetap untuk kolom tertentu
        With DataGridViewDaftarFeeDokterPengirim.Columns("ColumnNoLab")
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            '.Width = 150
            .ReadOnly = True
        End With

        With DataGridViewDaftarFeeDokterPengirim.Columns("ColumnTglLab")
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            .DefaultCellStyle.Format = "dd-MM-yyyy"
            .ReadOnly = True
        End With

        With DataGridViewDaftarFeeDokterPengirim.Columns("ColumnNama")
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            '.Width = 150
            .ReadOnly = True
        End With

        With DataGridViewDaftarFeeDokterPengirim.Columns("ColumnNamaTindakan")
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            '.Width = 150
            .ReadOnly = True
        End With

        With DataGridViewDaftarFeeDokterPengirim.Columns("ColumnDetailPemeriksaan")
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            '.Width = 150
            .ReadOnly = True
        End With


        With DataGridViewDaftarFeeDokterPengirim.Columns("ColumnBiayaTindakan")
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            '.Width = 150
            .ReadOnly = True
        End With


        With DataGridViewDaftarFeeDokterPengirim.Columns("ColumnDiscTindakan")
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            '.Width = 150
            .ReadOnly = False
        End With


        With DataGridViewDaftarFeeDokterPengirim.Columns("ColumnNettBayar")
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            '.Width = 150
            .ReadOnly = True
        End With

        With DataGridViewDaftarFeeDokterPengirim.Columns("ColumnDrNama")
            .AutoSizeMode = DataGridViewAutoSizeColumnMode.None
            '.Width = 150
            .ReadOnly = True
        End With
    End Sub

    Private Sub HeaderCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim headerCheckBox As CheckBox = CType(sender, CheckBox)

        For Each row As DataGridViewRow In DataGridViewDaftarFeeDokterPengirim.Rows
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
        TextBoxNamaDokter.Clear()
        TextBoxIdKirim.Clear()
        TextBoxSearch.Clear()
        ButtonSearchDiagnosa.PerformClick()
    End Sub
    Function LoadDataDokterPengirim() As DataTable
        Dim queryString As String = ""

        ' Ambil tanggal awal dan akhir dari DateTimePicker
        Dim tanggalAwal As String = Format(DateTimePickerAwal.Value, "yyyy-MM-dd")
        Dim tanggalAkhir As String = Format(DateTimePickerAkhir.Value, "yyyy-MM-dd")
        Dim dokterRequest As String = TextBoxIdKirim.Text

        ' Buat query
        queryString = "SELECT TL.NoUrut AS 'NoLab', " & _
              "TL.TglLab, " & _
              "MP.Nama, " & _
              "TLD.NamaTindakan AS 'Tindakan', " & _
              "TL.DetailPemeriksaan AS 'Pemeriksaan', " & _
              "TLD.BiayaTindakan AS 'Biaya Tindakan', " & _
              "TLD.DiscTindakan AS 'Disc Tindakan', " & _
              "MDK.DrNama AS 'Dokter' " & _
              "FROM MasterDokterTempatPraktek MDTP " & _
              "LEFT JOIN MasterDokterKirim MDK ON MDK.IdKirim = MDTP.IdKirim " & _
              "LEFT JOIN TransaksiLab TL ON TL.DokterRequest = MDTP.IdPraktek " & _
              "LEFT JOIN MasterPasien MP ON TL.IDInternet = MP.NoRekamMedis " & _
              "LEFT JOIN TransaksiLabDetail TLD ON TL.TransLabID = TLD.TransLabID " & _
              "LEFT JOIN TransaksiDetail TD ON TL.NoUrut = TD.NoUrut " & _
              "WHERE MDTP.IdPraktek = " & dokterRequest & " " & _
              "AND (TL.TglLab IS NULL OR CAST(TL.TglLab AS DATE) BETWEEN '" & tanggalAwal & "' AND '" & tanggalAkhir & "') " & _
                "ORDER BY MDK.DrNama, MDTP.NamaPraktek"
        ' Eksekusi query
        Dim Tbls As DataTable = ReadSQL(queryString)
        Return Tbls
    End Function

    'Null Default
    Private Function SafeDecimal(ByVal value As Object) As Decimal
        If value Is Nothing OrElse IsDBNull(value) Then Return 0

        Dim str As String = value.ToString().Replace(",", "").Trim()
        If str Is Nothing OrElse str.Trim() = "" Then Return 0

        Dim result As Decimal
        If Decimal.TryParse(str, result) Then
            Return result
        Else
            Return 0
        End If
    End Function

    'Safe untuk mencetak
    Private Function SafeInt(ByVal value As Object) As Integer
        If value Is Nothing OrElse IsDBNull(value) Then Return 0

        Dim str = value.ToString().Replace(",", "").Replace(".", "").Trim()
        If str = "" Then Return 0

        Dim result As Integer
        If Integer.TryParse(str, result) Then
            Return result
        Else
            Return 0
        End If
    End Function



    'Penghitung Diskon
    Private Sub DataGridViewDaftarFeeDokterPengirim_CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridViewDaftarFeeDokterPengirim.CellValueChanged
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = DataGridViewDaftarFeeDokterPengirim.Columns("ColumnDiscTindakan").Index Then
            Dim row As DataGridViewRow = DataGridViewDaftarFeeDokterPengirim.Rows(e.RowIndex)

            Try
                Dim biaya As Decimal = SafeDecimal(row.Cells("ColumnBiayaTindakan").Value)
                Dim diskon As Decimal = SafeDecimal(row.Cells("ColumnDiscTindakan").Value)
                Dim nett As Decimal = biaya

                If CBOmset.Checked Then
                    ' Mode Omset: Hitung Nett sebagai Biaya - Diskon
                    If diskon > 0 Then
                        nett = biaya - (biaya * (diskon / 100))
                    End If
                Else
                    ' Mode Komisi: Hitung Nett sebagai Nilai Diskon (komisi)
                    If diskon > 0 Then
                        nett = biaya * (diskon / 100)
                    End If
                End If

                row.Cells("ColumnNettBayar").Value = nett.ToString("N0")
            Catch ex As Exception
                MessageBox.Show("Error hitung Nett Bayar: " & ex.Message)
            End Try
        End If
    End Sub

    'Real Time Hitung
    Private Sub DataGridViewDaftarFeeDokterPengirim_CellEndEdit(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridViewDaftarFeeDokterPengirim.CellEndEdit
        DataGridViewDaftarFeeDokterPengirim.CommitEdit(DataGridViewDataErrorContexts.Commit)
    End Sub

    'Fungsi Error DBNull
    Private Function SafeNull(ByVal val As Object) As Decimal
        If val Is Nothing OrElse IsDBNull(val) Then Return 0
        Dim str = val.ToString().Replace(",", "").Trim()
        If str = "" Then Return 0
        Return Convert.ToDecimal(str)
    End Function

    Private Sub SearchDataDiagnosa()
        If Checking() = True Then
            DataGridViewDaftarFeeDokterPengirim.Rows.Clear()

            Dim Tbls As DataTable = LoadDataDokterPengirim()

            ' Buat kolom jika belum ada
            If DataGridViewDaftarFeeDokterPengirim.Columns.Count = 0 Then
                CreateDataGridViewFeeDokterPengirim()
            End If

            If Tbls.Rows.Count > 0 Then
                For Each Trow As DataRow In Tbls.Rows
                    ' Ambil data biaya dan diskon
                    Dim biaya As Decimal = SafeNull(Trow("Biaya Tindakan"))
                    Dim disc As Decimal = 0

                    'Fungsi untuk DBNull
                    If Not IsDBNull(Trow("Disc Tindakan")) Then
                        disc = Val(Trow("Disc Tindakan"))
                    End If

                    ' Hitung nett bayar berdasarkan CheckBox Omset
                    Dim nett As Decimal = biaya
                    If disc > 0 Then
                        If CBOmset.Checked Then
                            ' Mode Omset: Nett = Biaya - (Diskon%)
                            nett = biaya - (biaya * (disc / 100))
                        Else
                            ' Mode Komisi: Nett = Biaya * (Diskon%)
                            nett = biaya * (disc / 100)
                        End If
                    End If

                    Dim tglLab As Date = If(IsDBNull(Trow("TglLab")), Date.MinValue, CDate(Trow("TglLab")))
                    ' Tambahkan ke DataGridView
                    DataGridViewDaftarFeeDokterPengirim.Rows.Add(Trow("NoLab").ToString(), tglLab, Trow("Nama").ToString(), Trow("Tindakan").ToString(), Trow("Pemeriksaan").ToString(), biaya.ToString("N0"), disc.ToString() & "%", nett.ToString("N0"), Trow("Dokter").ToString(), False)
                Next

                ' Hapus seleksi awal
                DataGridViewDaftarFeeDokterPengirim.CurrentCell = Nothing
            Else
                MsgBox("Data tidak ditemukan.", MsgBoxStyle.Exclamation, "Warning!")
            End If
        End If
    End Sub

    Function Checking() As Boolean
        If TextBoxNamaDokter.Text.Trim() = "" Then
            MsgBox("Masukkan nama dokter pengirim terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
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
        selectedTable.Columns.Add("NoLab", GetType(String))
        selectedTable.Columns.Add("TglLab", GetType(Date))
        selectedTable.Columns.Add("Nama", GetType(String))
        selectedTable.Columns.Add("Tindakan", GetType(String))
        selectedTable.Columns.Add("Pemeriksaan", GetType(String))
        selectedTable.Columns.Add("Biaya Tindakan", GetType(Integer))
        selectedTable.Columns.Add("Disc Tindakan", GetType(Integer))
        selectedTable.Columns.Add("Nett Bayar", GetType(Integer))
        selectedTable.Columns.Add("NamaDokter", GetType(String))


        Dim noUrut As Integer = 1

        ' Ambil data dari DataGridView yang dicentang
        For Each row As DataGridViewRow In DataGridViewDaftarFeeDokterPengirim.Rows
            If Not row.IsNewRow AndAlso Convert.ToBoolean(row.Cells("ColumnPilih").Value) = True Then
                Dim newRow As DataRow = selectedTable.NewRow()
                newRow("No") = noUrut
                noUrut += 1
                newRow("NoLab") = row.Cells("ColumnNoLab").Value.ToString()
                newRow("TglLab") = row.Cells("ColumnTglLab").Value.ToString()
                newRow("Nama") = row.Cells("ColumnNama").Value.ToString()
                newRow("Tindakan") = row.Cells("ColumnNamaTindakan").Value.ToString()
                newRow("Pemeriksaan") = row.Cells("ColumnDetailPemeriksaan").Value.ToString()
                newRow("Biaya Tindakan") = SafeInt(row.Cells("ColumnBiayaTindakan").Value)
                newRow("Disc Tindakan") = SafeInt(row.Cells("ColumnDiscTindakan").Value)
                newRow("Nett Bayar") = SafeInt(row.Cells("ColumnNettBayar").Value)
                newRow("NamaDokter") = row.Cells("ColumnDrNama").Value.ToString()
                selectedTable.Rows.Add(newRow)
            End If
        Next

        If selectedTable.Rows.Count > 0 Then
            Report = XtraReport.FromFile(Application.StartupPath + "\Reports\LapFeeDokterPengirim.repx", True)
            Report.DataSource = selectedTable

            Dim tglAwal As String = Format(DateTimePickerAwal.Value, "dd MMM yyyy")
            Dim tglAkhir As String = Format(DateTimePickerAkhir.Value, "dd MMM yyyy")
            Report.Bands.Item(BandKind.ReportHeader).Controls("xrLabelBulan").Text = tglAwal & " - " & tglAkhir

            'Report.Bands.Item(BandKind.ReportHeader).Controls("xrLabelPelayanan").Text = ComboBoxTingkatPelayanan.Text
            'Report.Bands.Item(BandKind.ReportHeader).Controls("xrLabelIndikator").Text = ComboBoxIndikator.Text
            'Report.Bands.Item(BandKind.ReportHeader).Controls("xrLabelPoli").Text = ComboBoxPoliTujuan.Text

            If CBOmset.Checked Then
                Report.Bands.Item(BandKind.ReportHeader).Controls("lbljenissetoran").Text = "LAPORAN OMSET DOKTER PENGIRIM"
            End If

            Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:ss") & " By " & PoliKlinik.Lbluser.Text

            'Report.RunDesigner()
            Report.ShowPreview()
        Else
            MsgBox("Tidak ada data yang dipilih untuk dicetak.", MsgBoxStyle.Exclamation, "Peringatan")
        End If
    End Sub

    Private Sub TextBoxSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim searchText As String = TextBoxSearch.Text.Trim().ToLower()

        For Each row As DataGridViewRow In DataGridViewDaftarFeeDokterPengirim.Rows
            If row.IsNewRow Then Continue For ' Lewati baris baru/kosong

            Dim namaPasien As String = row.Cells("ColumnNama").Value.ToString().ToLower()
            Dim noLab As String = row.Cells("ColumnNoLab").Value.ToString().ToLower()

            ' Tampilkan hanya baris yang cocok di salah satu kolom
            row.Visible = namaPasien.Contains(searchText) OrElse noLab.Contains(searchText)
        Next
    End Sub

    Private Sub CBPilihSemua_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBPilihSemua.CheckedChanged
        For Each row As DataGridViewRow In DataGridViewDaftarFeeDokterPengirim.Rows
            If Not row.IsNewRow Then
                row.Cells("ColumnPilih").Value = CBPilihSemua.Checked
            End If
        Next
    End Sub

    Private Sub BtnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExcel.Click
        ' Cek apakah ada baris yang dicentang
        Dim adaYangDipilih As Boolean = False
        For Each row As DataGridViewRow In DataGridViewDaftarFeeDokterPengirim.Rows
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
        saveFileDialog.FileName = "LaporanFeeDokterPengirim_" & Format(Now, "yyyyMMdd_HHmmss") & ".csv"

        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            Using sw As New System.IO.StreamWriter(saveFileDialog.FileName, False, System.Text.Encoding.UTF8)
                ' Tulis header
                For i As Integer = 0 To DataGridViewDaftarFeeDokterPengirim.Columns.Count - 2 ' exclude checkbox
                    sw.Write("""" & DataGridViewDaftarFeeDokterPengirim.Columns(i).HeaderText.Replace("""", """""") & """")
                    If i < DataGridViewDaftarFeeDokterPengirim.Columns.Count - 2 Then sw.Write(",")
                Next
                sw.WriteLine()

                ' Tulis data yang dicentang
                For Each row As DataGridViewRow In DataGridViewDaftarFeeDokterPengirim.Rows
                    If Not row.IsNewRow AndAlso Convert.ToBoolean(row.Cells("ColumnPilih").Value) = True Then
                        For i As Integer = 0 To DataGridViewDaftarFeeDokterPengirim.Columns.Count - 2 ' exclude checkbox
                            Dim cellValue As String = If(row.Cells(i).Value IsNot Nothing, row.Cells(i).Value.ToString(), "")
                            sw.Write("""" & cellValue.Replace("""", """""") & """")
                            If i < DataGridViewDaftarFeeDokterPengirim.Columns.Count - 2 Then sw.Write(",")
                        Next
                        sw.WriteLine()
                    End If
                Next
            End Using

            MsgBox("Data berhasil disimpan sebagai CSV.", MsgBoxStyle.Information, "Berhasil")
        End If
    End Sub

    Private Sub ButtonFindDokter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFindDokter.Click
        Find.Show()
        Find.Query("select b.IdPraktek,a.DrNama,b.NamaPraktek,b.AlamatPraktek,b.KotaPraktek,b.TelpPraktek,b.KeteranganPraktek from MasterDokterKirim a right join MasterDokterTempatPraktek b on a.IdKirim=b.IdKirim ", " order by a.DrNama,b.NamaPraktek", "FindDoktertindakan", 1)
    End Sub

    Private Sub TextBoxSearch_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxSearch.TextChanged
        Dim searchText As String = TextBoxSearch.Text.Trim().ToLower()

        For Each row As DataGridViewRow In DataGridViewDaftarFeeDokterPengirim.Rows
            If row.IsNewRow Then Continue For ' Lewati baris baru/kosong

            Dim namaPasien As String = row.Cells("ColumnNama").Value.ToString().ToLower()
            Dim noLab As String = row.Cells("ColumnNoLab").Value.ToString().ToLower()

            ' Tampilkan hanya baris yang cocok di salah satu kolom
            row.Visible = namaPasien.Contains(searchText) OrElse noLab.Contains(searchText)
        Next
    End Sub

    Private Sub CBOmset_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBOmset.CheckedChanged
        For Each row As DataGridViewRow In DataGridViewDaftarFeeDokterPengirim.Rows
            If Not row.IsNewRow Then
                Dim biaya As Decimal = Val(row.Cells("ColumnBiayaTindakan").Value.ToString().Replace(",", ""))
                Dim disc As Decimal = Val(row.Cells("ColumnDiscTindakan").Value.ToString().Replace("%", "").Trim())

                Dim nett As Decimal = biaya

                If disc > 0 Then
                    If CBOmset.Checked Then
                        nett = biaya - (biaya * (disc / 100))
                    Else
                        nett = biaya * (disc / 100)
                    End If
                End If

                row.Cells("ColumnNettBayar").Value = nett.ToString("N0")
            End If
        Next
    End Sub
End Class