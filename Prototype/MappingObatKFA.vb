Imports System.Data.SqlClient
Imports System.ComponentModel
Imports System.Text.RegularExpressions

Public Class MappingObatKFA
    Private Sub MappingKFA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadObatKFA()
    End Sub

    Private Sub ButtonStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonStart.Click
        If Not bgWorkerAutoMapping.IsBusy Then
            ProgressBar1.Value = 0
            LabelStatus.Text = "Proses Auto Mapping..."
            bgWorkerAutoMapping.RunWorkerAsync()  ' mulai proses di background
        End If
    End Sub

    Private Sub TextBoxSearch_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TextBoxSearch.TextChanged
        LoadObatKFA(TextBoxSearch.Text.Trim())
    End Sub

    Private Sub DataGridViewObat_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridViewObat.CellDoubleClick
        If e.RowIndex >= 0 AndAlso e.ColumnIndex = DataGridViewObat.Columns("KodeLokal").Index Then
            Dim frm As New PopupObatLokal()
            ' Show popup ICD9, hasil return disimpan
            If frm.ShowDialog() = DialogResult.OK Then
                Dim selectedCode As String = frm.SelectedKodeLokal
                Dim selectedNamaObat As String = frm.SelectedNamaObat
                Dim selectedSkor As String = frm.SelectedSkor

                ' Update ke DataGridView
                DataGridViewObat.Rows(e.RowIndex).Cells("KodeLokal").Value = selectedCode
                DataGridViewObat.Rows(e.RowIndex).Cells("NamaObatLokal").Value = selectedNamaObat
                DataGridViewObat.Rows(e.RowIndex).Cells("SkorKemiripan").Value = selectedSkor

                ' Update ke database juga
                Dim KFAID As String = DataGridViewObat.Rows(e.RowIndex).Cells("KodeKFA").Value.ToString()
                Dim queryUpdate As String = "UPDATE MasterObatKFA " & _
                        "SET KodeLokal = '" & selectedCode.Replace("'", "''") & "', " & _
                        "    NamaObatLokal = '" & selectedNamaObat.Replace("'", "''") & "', " & _
                        "    SkorKemiripan = " & Val(selectedSkor) & ", " & _
                        "    StatusMapping = 'Manual' " & _
                        "WHERE KodeKFA = '" & KFAID.Replace("'", "''") & "'"

                WriteSQL(queryUpdate, 4)
            End If
        End If
    End Sub

    Private Sub bgWorkerAutoMapping_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgWorkerAutoMapping.DoWork
        Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)

        ' 1. Ambil data unik Obat dari Transaksi
        Dim dtTransaksi As DataTable = ReadSQL("SELECT DISTINCT ObatID, ObatNama FROM TransaksiObat ORDER BY ObatNama")
        'Dim dtKFA As DataTable = ReadSQL("SELECT KodeKFA, POA FROM MasterObatKFA")

        Dim total As Integer = dtTransaksi.Rows.Count
        Dim counter As Integer = 0

        For Each rowTransaksi As DataRow In dtTransaksi.Rows
            Dim obatID As String = rowTransaksi("ObatID").ToString()
            Dim obatNama As String = rowTransaksi("ObatNama").ToString()

            ' === Tambahan: cek apakah ObatID ini sudah pernah dimapping ===
            Dim sqlCek As String = "SELECT TOP 1 StatusMapping FROM MasterObatKFA " & _
                                   "WHERE KodeLokal = '" & obatID.Replace("'", "''") & "'"
            Dim dtCek As DataTable = ReadSQL(sqlCek)

            If dtCek.Rows.Count > 0 Then
                ' Kalau sudah ada mapping manual → skip
                If dtCek.Rows(0)("StatusMapping").ToString().ToLower() = "manual" Then
                    counter += 1
                    worker.ReportProgress(CInt((counter / total) * 100))
                    Continue For
                End If
            End If
            ' ===============================================================

            ' Cari kandidat KFA pakai fuzzy
            Dim skor As Double = 0
            Dim bestRow As DataRow = CariObatKFA(obatNama, skor)

            ' 3. Jika cukup mirip → update mapping otomatis
            If bestRow IsNot Nothing AndAlso skor >= 58 Then
                Dim sqlUpdate As String = "UPDATE MasterObatKFA SET " & _
                                 "KodeLokal = '" & obatID.Replace("'", "''") & "', " & _
                                 "NamaObatLokal = '" & obatNama.Replace("'", "''") & "', " & _
                                 "SkorKemiripan = " & skor & ", " & _
                                 "StatusMapping = 'Auto' " & _
                                 "WHERE KodeKFA = '" & bestRow("KodeKFA").ToString().Replace("'", "''") & "' " & _
                                 "AND (KodeLokal IS NULL OR KodeLokal = '')"
                WriteSQL(sqlUpdate, 4)
            Else
                ' Kalau skor rendah, masukkan ke tabel manual review
                Dim sqlInsert As String = "INSERT INTO MappingObatManual (ObatID, ObatNama, KandidatKFA, Skor) " & _
                                "VALUES ('" & obatID.Replace("'", "''") & "', " & _
                                "'" & obatNama.Replace("'", "''") & "', " & _
                                "'" & If(bestRow IsNot Nothing, bestRow("KodeKFA").ToString(), "") & "', " & skor & ")"
                WriteSQL(sqlInsert, 4)
            End If

            ' Hitung progress
            counter += 1
            Dim percent As Integer = CInt((counter / total) * 100)
            worker.ReportProgress(percent)
        Next
    End Sub

    ' === UPDATE PROGRESS ===
    Private Sub bgWorkerAutoMapping_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs) Handles bgWorkerAutoMapping.ProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
        LabelStatus.Text = "Progress: " & e.ProgressPercentage & "%"
    End Sub

    ' === SELESAI ===
    Private Sub bgWorkerAutoMapping_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles bgWorkerAutoMapping.RunWorkerCompleted
        LabelStatus.Text = "Auto Mapping selesai!"
        MsgBox("Proses Auto Mapping telah selesai!", MsgBoxStyle.Information, "Selesai")
        LoadObatKFA() ' refresh data
    End Sub

    ' fungsi pembanding fuzzy sederhana (Levenshtein Distance → similarity persen)
    Private Function SimilarityNormalized(ByVal s1 As String, ByVal s2 As String) As Double
        Dim n1 As String = NormalizeObat(s1)
        Dim n2 As String = NormalizeObat(s2)
        Return Similarity(n1, n2)
    End Function

    Private Function Similarity(ByVal s1 As String, ByVal s2 As String) As Double
        Dim dist As Integer = LevenshteinDistance(s1.ToLower(), s2.ToLower())
        Dim maxLen As Integer = Math.Max(s1.Length, s2.Length)
        If maxLen = 0 Then Return 100
        Return (1.0 - dist / maxLen) * 100
    End Function

    Private Function LevenshteinDistance(ByVal s As String, ByVal t As String) As Integer
        Dim n As Integer = s.Length
        Dim m As Integer = t.Length
        Dim d(n, m) As Integer

        If n = 0 Then Return m
        If m = 0 Then Return n

        For i As Integer = 0 To n
            d(i, 0) = i
        Next
        For j As Integer = 0 To m
            d(0, j) = j
        Next

        For i As Integer = 1 To n
            For j As Integer = 1 To m
                Dim cost As Integer = If(t(j - 1) = s(i - 1), 0, 1)
                d(i, j) = Math.Min(Math.Min(d(i - 1, j) + 1, d(i, j - 1) + 1), d(i - 1, j - 1) + cost)
            Next
        Next

        Return d(n, m)
    End Function

    Private Function CariObatKFA(ByVal namaObatLokal As String, ByRef bestScore As Double) As DataRow
        Dim bestRow As DataRow = Nothing
        bestScore = 0

        ' 1. Cari pakai fuzzy
        Dim dtKFA As DataTable = ReadSQL("SELECT * FROM MasterObatKFA")
        For Each row As DataRow In dtKFA.Rows
            Dim namaKFA As String = row("POA").ToString()
            Dim skor As Integer = CInt(SimilarityNormalized(namaObatLokal, namaKFA))
            If skor > bestScore Then
                bestScore = skor
                bestRow = row
            End If
        Next

        ' 2. Kalau skor terlalu rendah → fallback ke LIKE query
        If bestScore < 58 Then
            Dim kata() As String = namaObatLokal.Split(" "c)
            Dim filter As String = ""
            For Each k As String In kata
                If k.Trim().Length > 2 Then
                    filter &= " AND POA LIKE '%" & k.Replace("'", "''") & "%'"
                End If
            Next

            Dim sql As String = "SELECT TOP 1 * FROM MasterObatKFA WHERE 1=1 " & filter
            Dim dtLike As DataTable = ReadSQL(sql)
            If dtLike.Rows.Count > 0 Then
                bestRow = dtLike.Rows(0)
                bestScore = 60 ' kasih skor default supaya lolos threshold
            End If
        End If

        Return bestRow
    End Function

    Private Function NormalizeObat(ByVal s As String) As String
        Dim text As String = s.ToLower()

        ' buang karakter non-alfanumerik kecuali spasi
        text = Regex.Replace(text, "[^a-z0-9 ]", " ")

        ' buat dictionary sinonim manual
        Dim dict As New Dictionary(Of String, String)
        dict.Add("tab", "tablet")
        dict.Add("tablet", "tablet")
        dict.Add("hj", "")
        dict.Add("kap", "kapsul")
        dict.Add("kaps", "kapsul")
        dict.Add("kpt", "kaplet")
        dict.Add("capl", "kaplet")
        dict.Add("kapsul", "kapsul")
        dict.Add("inj", "injeksi")
        dict.Add("inj.", "injeksi")
        dict.Add("sir", "sirup")
        dict.Add("syr", "sirup")

        ' ganti sinonim di teks
        For Each kvp As KeyValuePair(Of String, String) In dict
            text = Regex.Replace(text, "(^|\s)" & kvp.Key & "($|\s)", " " & kvp.Value & " ", RegexOptions.IgnoreCase)
        Next

        ' rapikan spasi ganda
        text = Regex.Replace(text, "\s+", " ").Trim()

        Return text
    End Function

    Private Sub LoadObatKFA(Optional ByVal keyword As String = "")
        Dim query As String = "SELECT KodeKFA, POA, KodeLokal, NamaObatLokal, SkorKemiripan, StatusMapping " & _
                              "FROM MasterObatKFA "

        ' Jika ada kata kunci, tambahkan WHERE
        If keyword <> "" Then
            query &= "WHERE POA LIKE '%" & keyword.Replace("'", "''") & "%' " & _
                     "OR NamaObatLokal LIKE '%" & keyword.Replace("'", "''") & "%' "
        End If

        query &= "ORDER BY POA ASC"

        Dim dt As DataTable = ReadSQL(query)

        DataGridViewObat.DataSource = dt
        DataGridViewObat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        If DataGridViewObat.Columns.Contains("KodeKFA") Then
            DataGridViewObat.Columns("KodeKFA").HeaderText = "Kode KFA"
            DataGridViewObat.Columns("POA").HeaderText = "Nama Obat (KFA)"
            DataGridViewObat.Columns("KodeLokal").HeaderText = "Kode Obat Lokal"
            DataGridViewObat.Columns("NamaObatLokal").HeaderText = "Nama Obat Lokal"
            DataGridViewObat.Columns("SkorKemiripan").HeaderText = "Skor Kemiripan"
            DataGridViewObat.Columns("StatusMapping").HeaderText = "Status Mapping"
        End If
    End Sub

    Private Sub ButtonDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDelete.Click
        If DataGridViewObat.CurrentRow Is Nothing Then
            MsgBox("Silakan pilih data yang akan dihapus mappingnya.", MsgBoxStyle.Exclamation, "Peringatan")
            Return
        End If

        ' Ambil KodeKFA dari baris yang dipilih
        Dim kodeKFA As String = DataGridViewObat.CurrentRow.Cells("KodeKFA").Value.ToString()

        ' Konfirmasi
        If MsgBox("Apakah Anda yakin ingin menghapus mapping obat ini?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Konfirmasi") = MsgBoxResult.Yes Then
            ' Update database → set kolom jadi NULL
            Dim sqlUpdate As String = "UPDATE MasterObatKFA SET " & _
                                      "KodeLokal = NULL, " & _
                                      "NamaObatLokal = NULL, " & _
                                      "SkorKemiripan = NULL, " & _
                                      "StatusMapping = NULL " & _
                                      "WHERE KodeKFA = '" & kodeKFA.Replace("'", "''") & "'"
            WriteSQL(sqlUpdate, 4)

            ' Refresh DataGridView
            LoadObatKFA()
            MsgBox("Mapping berhasil dihapus!", MsgBoxStyle.Information, "Selesai")
        End If
    End Sub
End Class