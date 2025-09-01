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
Imports System.Globalization
Imports System.Text.RegularExpressions

Public Class FormSinkronPcare
    Private Class varJson
        Public response As v4_BPJS
        'Public response As Object
        Public metaData As MetaData
    End Class

    Private kdProviderLokal As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'KodePPK'")
    Private urlPcare As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_base_url'")

    Private Sub Find_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Control.CheckForIllegalCrossThreadCalls = False
            Me.MdiParent = PoliKlinik
            Me.Dock = DockStyle.Fill
            Me.WindowState = FormWindowState.Maximized

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub LoadDataLokal(ByVal tglDaftar As String)
        Try
            Dim tglStr As String = tglDaftar

            Dim sql As String = "" & _
        "SELECT * " & _
        "FROM ( " & _
            "SELECT " & _
                "td.JenisPoli, " & _
                "tp.NoUrut, " & _
                "tp.TglPoli AS TglTransaksi, " & _
                "mp.NoKartuBPJS, " & _
                "mp.Nama " & _
            "FROM TransaksiPoli tp " & _
            "LEFT JOIN TransaksiDetail td ON tp.NoUrut = td.NoUrut " & _
            "LEFT JOIN MasterPasien mp ON tp.IDInternet = mp.NoRekamMedis " & _
            "WHERE(tp.deleted = 0) " & _
              "AND CONVERT(date, td.TanggalTransaksi) = '" & tglStr & "' " & _
              "AND td.TransaksiPaket = 0 " & _
              "AND td.JenisPenagihan = 'BPJS' " & _
            "UNION ALL " & _
            "SELECT " & _
                "td.JenisPoli, " & _
                "tg.NoUrut, " & _
                "tg.TglGigi AS TglTransaksi, " & _
                "mp.NoKartuBPJS, " & _
                "mp.Nama " & _
            "FROM TransaksiGigi tg " & _
            "LEFT JOIN TransaksiDetail td ON tg.NoUrut = td.NoUrut " & _
            "LEFT JOIN MasterPasien mp ON tg.IDInternet = mp.NoRekamMedis " & _
            "WHERE tg.deleted = 0 " & _
              "AND CONVERT(date, td.TanggalTransaksi) = '" & tglStr & "' " & _
              "AND td.TransaksiPaket = 0 " & _
              "AND td.JenisPenagihan = 'BPJS' " & _
        ") AS CombinedResults " & _
        "ORDER BY TglTransaksi, NoUrut; "

            Dim dt As DataTable = ReadSQL(sql)

            ' Atur ListViewLokal
            ListViewLokal.Items.Clear()
            ListViewLokal.Columns.Clear()
            ListViewLokal.View = View.Details

            ListViewLokal.Columns.Add("Jenis Poli", 100)
            ListViewLokal.Columns.Add("No Urut", 80)
            ListViewLokal.Columns.Add("Tgl Transaksi", 100)
            ListViewLokal.Columns.Add("No Kartu BPJS", 120)
            ListViewLokal.Columns.Add("Nama", 200)

            For Each row As DataRow In dt.Rows
                Dim lvItem As New ListViewItem(row("JenisPoli").ToString())
                lvItem.SubItems.Add(row("NoUrut").ToString())
                lvItem.SubItems.Add(Convert.ToDateTime(row("TglTransaksi")).ToString("dd-MM-yyyy"))
                lvItem.SubItems.Add(row("NoKartuBPJS").ToString())
                lvItem.SubItems.Add(row("Nama").ToString())
                ListViewLokal.Items.Add(lvItem)
            Next

            ' Auto resize
            ListViewLokal.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)

        Catch ex As Exception
            MessageBox.Show("Error load data lokal: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadDataPcare(ByVal tglDaftar As String)
        'Dim tglDaftar As String = dtprocess.Value.ToString("dd-MM-yyyy")

        Dim offset As Integer = 0
        Dim limit As Integer = 15
        Dim totalCount As Integer = -1

        'MsgBox("Tanggal daftar: " & tglDaftar)

        ListViewPcare.Items.Clear()
        ListViewPcare.Columns.Clear()
        ListViewPcare.View = View.Details
        ListViewPcare.Columns.Add("No Urut", 35)
        ListViewPcare.Columns.Add("Poli", 80)
        ListViewPcare.Columns.Add("Tgl Daftar", 80)
        ListViewPcare.Columns.Add("No Kartu", 100)
        ListViewPcare.Columns.Add("Nama", 200)

        Do
            Dim endpoint As String = urlPcare & "pendaftaran/tglDaftar/" & tglDaftar & "/" & offset & "/" & limit
            'MsgBox("Endpoint: " & endpoint)
            Dim jsonResponse As String = getDataFromPcare(endpoint)
            'MsgBox("Json Response: " & jsonResponse)
            If String.IsNullOrEmpty(jsonResponse) Then Exit Do

            Try
                ' Normalize: jika server mengembalikan array [ {...} ] maka ambil elemen pertama
                Dim rootObj As JObject = Nothing
                Dim s As String = jsonResponse.Trim()
                If s.StartsWith("[") Then
                    Dim arrRoot As JArray = JArray.Parse(s)
                    If arrRoot.Count = 0 Then Exit Do
                    If TypeOf arrRoot(0) Is JObject Then
                        rootObj = CType(arrRoot(0), JObject)
                    Else
                        Exit Do
                    End If
                Else
                    rootObj = JObject.Parse(s)
                End If

                If rootObj Is Nothing Then Exit Do

                ' Dapatkan token "response" jika ada, atau gunakan rootObj langsung jika sudah berisi count/list
                Dim responseToken As JToken = Nothing
                If rootObj("response") IsNot Nothing Then
                    responseToken = rootObj("response")
                ElseIf rootObj("list") IsNot Nothing OrElse rootObj("count") IsNot Nothing Then
                    responseToken = rootObj
                Else
                    ' tidak ada data yang diharapkan
                    Exit Do
                End If

                ' Jika responseToken adalah string (mis. masih terenkripsi/decompressed menjadi string JSON),
                ' coba parse string tersebut menjadi JSON
                If responseToken.Type = JTokenType.String Then
                    Dim inner As String = responseToken.ToString().Trim()
                    If inner.StartsWith("{") Or inner.StartsWith("[") Then
                        Dim parsedInner As JToken = JToken.Parse(inner)
                        If TypeOf parsedInner Is JObject Then
                            responseToken = CType(parsedInner, JObject)
                        ElseIf TypeOf parsedInner Is JArray Then
                            Dim tmp As New JObject()
                            tmp("list") = parsedInner
                            responseToken = tmp
                        End If
                    Else
                        ' tidak bisa parse -> abaikan
                        Exit Do
                    End If
                End If

                ' Pastikan responseToken sekarang adalah JObject berisi count/list
                Dim respObj As JObject = TryCast(responseToken, JObject)
                If respObj Is Nothing Then Exit Do

                ' Ambil totalCount sekali saja (jika ada)
                If totalCount = -1 AndAlso respObj("count") IsNot Nothing Then
                    Integer.TryParse(respObj("count").ToString(), totalCount)
                End If

                ' Ambil list (jika ada)
                Dim list As JArray = Nothing
                If respObj("list") IsNot Nothing AndAlso TypeOf respObj("list") Is JArray Then
                    list = CType(respObj("list"), JArray)
                Else
                    list = New JArray()
                End If

                If list.Count = 0 Then Exit Do

                For Each item As JToken In list
                    Dim noUrut As String = If(item("noUrut") IsNot Nothing, item("noUrut").ToString(), "")
                    Dim tglDaftarPcare As String = If(item("tglDaftar") IsNot Nothing, item("tglDaftar").ToString(), "")
                    Dim noKartu As String = If(item("peserta") IsNot Nothing AndAlso item("peserta")("noKartu") IsNot Nothing, item("peserta")("noKartu").ToString(), "")
                    Dim nama As String = If(item("peserta") IsNot Nothing AndAlso item("peserta")("nama") IsNot Nothing, item("peserta")("nama").ToString(), "")

                    ' ambil kode poli
                    Dim kdPoli As String = If(item("poli") IsNot Nothing AndAlso item("poli")("kdPoli") IsNot Nothing, item("poli")("kdPoli").ToString(), "")

                    ' mapping kdPoli ke nama poli
                    Dim namaPoli As String = ""
                    Select Case kdPoli
                        Case "001" : namaPoli = "POLI UMUM"
                        Case "002" : namaPoli = "POLI GIGI & MULUT"
                        Case "003" : namaPoli = "POLI KIA"
                        Case "004" : namaPoli = "LABORATORIUM"
                        Case "998" : namaPoli = "KUNJUNGAN ONLINE"
                        Case "021" : namaPoli = "KONSELING"
                        Case "008" : namaPoli = "POLI KB"
                        Case Else : namaPoli = kdPoli  ' fallback: tampilkan kode kalau belum ada mapping
                    End Select

                    ' tambahkan ke ListView
                    Dim lvItem As New ListViewItem(noUrut)
                    lvItem.SubItems.Add(namaPoli)
                    lvItem.SubItems.Add(tglDaftarPcare)
                    lvItem.SubItems.Add(noKartu)
                    lvItem.SubItems.Add(nama)
                    ListViewPcare.Items.Add(lvItem)
                Next

                offset += limit

                If totalCount > -1 AndAlso ListViewPcare.Items.Count >= totalCount Then Exit Do

            Catch ex As Exception
                ' Jika ada exception parsing/JSON, hentikan loop atau tampilkan pesan debug
                MessageBox.Show("Error parsing response: " & ex.Message)
                Exit Do
            End Try

        Loop

        'MessageBox.Show("Get data selesai. Total data: " & ListViewPcare.Items.Count)
    End Sub

    Private kunjDict As New Dictionary(Of String, String)

    Private Sub InitListViewKunjungan()
        ListViewKunjungan.Clear()
        ListViewKunjungan.View = View.Details
        ListViewKunjungan.FullRowSelect = True
        ListViewKunjungan.GridLines = True

        ' Tambahkan kolom
        ListViewKunjungan.Columns.Add("No Kartu", 120)
        ListViewKunjungan.Columns.Add("Nama Pasien", 200)
        ListViewKunjungan.Columns.Add("No Kunjungan BPJS", 160)
        ListViewKunjungan.Columns.Add("Tgl Kunjungan", 100)
    End Sub

    ' Fungsi bantu ambil nama pasien dari DB lokal by noKartu
    Private Function GetNamaPasienLokal(ByVal noKartu As String) As String
        Dim sql As DataTable = ReadSQL("SELECT * FROM MasterPasien WHERE NoKartuBPJS = '" & noKartu & "'")
        If sql.Rows.Count > 0 Then
            Return sql.Rows(0)("Nama").ToString()
        Else
            Return ""
        End If
    End Function

    Private Sub LoadDataKunjunganBPJS(ByVal noKartu As String, ByVal tglDaftar As String)
        Dim endpoint As String = urlPcare & "kunjungan/peserta/" & noKartu
        Dim jsonResponse As String = getDataFromPcare(endpoint)

        If String.IsNullOrEmpty(jsonResponse) Then Exit Sub

        Try
            Dim resp As JObject = Nothing
            Dim s As String = jsonResponse.Trim()

            If s.StartsWith("[") Then
                Dim arr As JArray = JArray.Parse(s)
                If arr.Count > 0 AndAlso arr(0)("response") IsNot Nothing Then
                    resp = arr(0)("response")
                End If
            Else
                Dim rootObj As JObject = JObject.Parse(s)
                If rootObj("response") IsNot Nothing Then
                    resp = rootObj("response")
                End If
            End If

            If resp Is Nothing OrElse resp("list") Is Nothing Then Exit Sub

            Dim list As JArray = CType(resp("list"), JArray)
            Dim found As Boolean = False

            For Each kunj As JObject In list
                Dim bpjsTanggal As String = If(kunj("tglKunjungan") IsNot Nothing, kunj("tglKunjungan").ToString(), "")
                If bpjsTanggal = tglDaftar Then
                    Dim bpjsKunjungan As String = If(kunj("noKunjungan") IsNot Nothing, kunj("noKunjungan").ToString(), "")

                    ' coba ambil nama dari response BPJS
                    Dim namaPasien As String = If(kunj("peserta") IsNot Nothing AndAlso kunj("peserta")("nama") IsNot Nothing, kunj("peserta")("nama").ToString(), "")

                    ' kalau null/empty → fallback ambil dari DB lokal
                    If String.IsNullOrEmpty(namaPasien) OrElse namaPasien.Trim() = "" Then
                        namaPasien = GetNamaPasienLokal(noKartu)
                    End If

                    ' simpan ke dictionary global
                    kunjDict(noKartu) = bpjsKunjungan

                    ' Tambahkan baris ke ListView
                    Dim lvItem As New ListViewItem(noKartu)
                    lvItem.SubItems.Add(namaPasien)
                    lvItem.SubItems.Add(bpjsKunjungan)
                    lvItem.SubItems.Add(bpjsTanggal)
                    ListViewKunjungan.Items.Add(lvItem)

                    found = True
                    Exit For
                End If
            Next

            If Not found Then
                Dim lvItem As New ListViewItem(noKartu)
                lvItem.SubItems.Add("") ' nama kosong
                lvItem.SubItems.Add("") ' noKunjungan kosong
                lvItem.SubItems.Add("") ' tgl kosong
                ListViewKunjungan.Items.Add(lvItem)
            End If

        Catch ex As Exception
            MessageBox.Show("Error LoadDataKunjunganBPJS: " & ex.Message)
        End Try
    End Sub

    'Private Sub CompareData()
    '    ListViewCompare.Items.Clear()
    '    ListViewCompare.Columns.Clear()

    '    ' pastikan tampilan pakai Details biar header muncul
    '    ListViewCompare.View = View.Details
    '    ListViewCompare.FullRowSelect = True
    '    ListViewCompare.GridLines = True

    '    ListViewCompare.Columns.Add("No Kartu")
    '    ListViewCompare.Columns.Add("Nama")
    '    ListViewCompare.Columns.Add("Poli")
    '    ListViewCompare.Columns.Add("Hasil")

    '    ' ====== BACA DATA PCare ke Dictionary ======
    '    ' PCare: key = NoKartu, value = {Nama, Poli}
    '    Dim pcareDict As New Dictionary(Of String, String())
    '    For Each item As ListViewItem In ListViewPcare.Items
    '        Dim noKartu As String = item.SubItems(3).Text  ' kolom NoKartu (Pcare)
    '        Dim nama As String = item.SubItems(4).Text     ' kolom Nama (Pcare)
    '        Dim poli As String = item.SubItems(1).Text     ' kolom Poli (Pcare)
    '        If Not String.IsNullOrEmpty(noKartu) AndAlso Not pcareDict.ContainsKey(noKartu) Then
    '            pcareDict.Add(noKartu, New String() {nama, poli})
    '        End If
    '    Next

    '    ' Lokal: key = NoKartu, value = {Nama, Poli}
    '    Dim lokalDict As New Dictionary(Of String, String())
    '    For Each item As ListViewItem In ListViewLokal.Items
    '        Dim noKartu As String = item.SubItems(3).Text  ' kolom NoKartuBPJS (Lokal)
    '        Dim nama As String = item.SubItems(4).Text     ' kolom Nama (Lokal)
    '        Dim poli As String = item.SubItems(0).Text     ' kolom JenisPoli (Lokal)
    '        If Not String.IsNullOrEmpty(noKartu) AndAlso Not lokalDict.ContainsKey(noKartu) Then
    '            lokalDict.Add(noKartu, New String() {nama, poli})
    '        End If
    '    Next

    '    ' Bandingkan
    '    For Each kvp As KeyValuePair(Of String, String()) In pcareDict
    '        Dim noKartu As String = kvp.Key
    '        Dim namaPcare As String = kvp.Value(0)
    '        Dim poliPcare As String = kvp.Value(1)

    '        Dim lvCompare As New ListViewItem(noKartu)
    '        lvCompare.SubItems.Add(namaPcare)
    '        lvCompare.SubItems.Add(poliPcare)

    '        If lokalDict.ContainsKey(noKartu) Then
    '            Dim namaLokal As String = lokalDict(noKartu)(0)
    '            Dim poliLokal As String = lokalDict(noKartu)(1)

    '            If namaPcare = namaLokal AndAlso poliPcare = poliLokal Then
    '                lvCompare.SubItems.Add("Match")
    '                lvCompare.BackColor = Color.LightGreen
    '            Else
    '                lvCompare.SubItems.Add("Data berbeda (Nama/Poli)")
    '                lvCompare.BackColor = Color.Orange
    '            End If

    '            lokalDict.Remove(noKartu)
    '        Else
    '            lvCompare.SubItems.Add("Hanya di Pcare")
    '            lvCompare.BackColor = Color.LightYellow
    '        End If

    '        ListViewCompare.Items.Add(lvCompare)
    '    Next

    '    ' Tambahkan yang hanya ada di lokal
    '    For Each kvp As KeyValuePair(Of String, String()) In lokalDict
    '        Dim noKartu As String = kvp.Key
    '        Dim namaLokal As String = kvp.Value(0)
    '        Dim poliLokal As String = kvp.Value(1)

    '        Dim lvCompare As New ListViewItem(noKartu)
    '        lvCompare.SubItems.Add(namaLokal)
    '        lvCompare.SubItems.Add(poliLokal)
    '        lvCompare.SubItems.Add("Hanya di Lokal")
    '        lvCompare.BackColor = Color.LightCoral
    '        ListViewCompare.Items.Add(lvCompare)
    '    Next

    '    ' auto-resize kolom
    '    For i As Integer = 0 To ListViewCompare.Columns.Count - 1
    '        ListViewCompare.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.ColumnContent)
    '        Dim headerWidth = TextRenderer.MeasureText(ListViewCompare.Columns(i).Text, ListViewCompare.Font).Width + 10
    '        If ListViewCompare.Columns(i).Width < headerWidth Then
    '            ListViewCompare.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.HeaderSize)
    '        End If
    '    Next
    'End Sub

    Private Sub CompareData()
        ListViewCompare.Items.Clear()
        ListViewCompare.Columns.Clear()

        ListViewCompare.View = View.Details
        ListViewCompare.FullRowSelect = True
        ListViewCompare.GridLines = True

        ListViewCompare.Columns.Add("No Kartu")
        ListViewCompare.Columns.Add("Nama")
        ListViewCompare.Columns.Add("Poli")
        ListViewCompare.Columns.Add("Hasil")
        ListViewCompare.Columns.Add("No Kunjungan BPJS") ' kolom tambahan

        ' ====== BACA DATA PCare ke Dictionary ======
        Dim pcareDict As New Dictionary(Of String, String())
        For Each item As ListViewItem In ListViewPcare.Items
            Dim noKartu As String = item.SubItems(3).Text
            Dim nama As String = item.SubItems(4).Text
            Dim poli As String = item.SubItems(1).Text
            If Not String.IsNullOrEmpty(noKartu) AndAlso Not pcareDict.ContainsKey(noKartu) Then
                pcareDict.Add(noKartu, New String() {nama, poli})
            End If
        Next

        ' ====== BACA DATA Lokal ke Dictionary ======
        Dim lokalDict As New Dictionary(Of String, String())
        For Each item As ListViewItem In ListViewLokal.Items
            Dim noKartu As String = item.SubItems(3).Text
            Dim nama As String = item.SubItems(4).Text
            Dim poli As String = item.SubItems(0).Text
            If Not String.IsNullOrEmpty(noKartu) AndAlso Not lokalDict.ContainsKey(noKartu) Then
                lokalDict.Add(noKartu, New String() {nama, poli})
            End If
        Next

        ' ====== BACA DATA Kunjungan BPJS ke Dictionary ======
        Dim kunjDict As New Dictionary(Of String, String)
        For Each item As ListViewItem In ListViewKunjungan.Items
            Dim noKartu As String = item.SubItems(0).Text
            Dim noKunjungan As String = If(item.SubItems.Count > 2, item.SubItems(2).Text, "")
            If Not kunjDict.ContainsKey(noKartu) Then
                kunjDict.Add(noKartu, noKunjungan)
            End If
        Next

        ' ====== BANDINKAN PCare vs Lokal ======
        For Each kvp As KeyValuePair(Of String, String()) In pcareDict
            Dim noKartu As String = kvp.Key
            Dim namaPcare As String = kvp.Value(0)
            Dim poliPcare As String = kvp.Value(1)

            Dim lvCompare As New ListViewItem(noKartu)
            lvCompare.SubItems.Add(namaPcare)
            lvCompare.SubItems.Add(poliPcare)

            If lokalDict.ContainsKey(noKartu) Then
                Dim namaLokal As String = lokalDict(noKartu)(0)
                Dim poliLokal As String = lokalDict(noKartu)(1)

                If namaPcare = namaLokal AndAlso poliPcare = poliLokal Then
                    lvCompare.SubItems.Add("Match")
                    lvCompare.BackColor = Color.LightGreen
                Else
                    lvCompare.SubItems.Add("Data berbeda (Nama/Poli)")
                    lvCompare.BackColor = Color.Orange
                End If

                lokalDict.Remove(noKartu)
            Else
                lvCompare.SubItems.Add("Hanya di Pcare")
                lvCompare.BackColor = Color.LightYellow
            End If

            ' === Tambahkan No Kunjungan ===
            If kunjDict.ContainsKey(noKartu) Then
                lvCompare.SubItems.Add(kunjDict(noKartu))
            Else
                lvCompare.SubItems.Add("-")
            End If

            ListViewCompare.Items.Add(lvCompare)
        Next

        ' ====== YANG HANYA DI LOKAL ======
        For Each kvp As KeyValuePair(Of String, String()) In lokalDict
            Dim noKartu As String = kvp.Key
            Dim namaLokal As String = kvp.Value(0)
            Dim poliLokal As String = kvp.Value(1)

            Dim lvCompare As New ListViewItem(noKartu)
            lvCompare.SubItems.Add(namaLokal)
            lvCompare.SubItems.Add(poliLokal)
            lvCompare.SubItems.Add("Hanya di Lokal")
            lvCompare.SubItems.Add("-") ' tidak ada kunjungan
            lvCompare.BackColor = Color.LightCoral
            ListViewCompare.Items.Add(lvCompare)
        Next

        ' Auto-resize kolom
        For i As Integer = 0 To ListViewCompare.Columns.Count - 1
            ListViewCompare.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.ColumnContent)
            Dim headerWidth = TextRenderer.MeasureText(ListViewCompare.Columns(i).Text, ListViewCompare.Font).Width + 10
            If ListViewCompare.Columns(i).Width < headerWidth Then
                ListViewCompare.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.HeaderSize)
            End If
        Next
    End Sub

    Private Sub ButtonSinkronisasi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSinkronisasi.Click
        Dim tglDaftar As String = dtprocess.Value.ToString("dd-MM-yyyy")

        ' --- 1. Load dari Pcare ---
        LoadDataPcare(tglDaftar)

        ' --- 2. Load dari Database Lokal ---
        LoadDataLokal(dtprocess.Value)

        ' --- 3. Init ListViewKunjungan (biar bersih dulu) ---
        InitListViewKunjungan()

        ' --- 4. Ambil kunjungan dari BPJS untuk semua noKartu hasil Compare ---
        ' sementara kita isi Compare dulu (tanpa kolom kunjungan)
        CompareData()

        ' loop setiap kartu hasil compare untuk ambil data kunjungan BPJS
        For Each item As ListViewItem In ListViewCompare.Items
            Dim noKartu As String = item.SubItems(0).Text
            LoadDataKunjunganBPJS(noKartu, tglDaftar)
        Next

        ' --- 5. Panggil CompareData lagi supaya NoKunjungan dari kunjDict masuk ---
        CompareData()

        ' --- 6. Info summary ---
        MessageBox.Show("Sinkronisasi selesai." & vbCrLf & _
                        "Total data Pcare: " & ListViewPcare.Items.Count & vbCrLf & _
                        "Total data Lokal: " & ListViewLokal.Items.Count & vbCrLf & _
                        "Total Kunjungan: " & ListViewKunjungan.Items.Count)
    End Sub


    Private Sub ButtonSendPendaftaran_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSendPendaftaran.Click
        Dim tglDaftarBPJS As String = dtprocess.Value.ToString("dd-MM-yyyy")

        For Each item As ListViewItem In ListViewCompare.Items
            Dim hasil As String = item.SubItems(3).Text ' kolom Hasil
            If hasil = "Hanya di Lokal" Then
                Dim noKartu As String = item.SubItems(0).Text
                Dim nama As String = item.SubItems(1).Text
                Dim poli As String = item.SubItems(2).Text

                ' --- Cari NoTransaksi (NoUrut) dari ListViewLokal ---
                Dim noTransaksi As String = ""
                For Each lokal As ListViewItem In ListViewLokal.Items
                    If lokal.SubItems(3).Text = noKartu Then ' kolom 3 = NoKartuBPJS
                        noTransaksi = lokal.SubItems(1).Text ' kolom 0 = NoUrut / NoTransaksi
                        Exit For
                    End If
                Next

                'MsgBox("DEBUG: noTransaksi untuk " & nama & " (" & noKartu & ") = " & noTransaksi)

                ' --- Ambil KeluhanUtama dari DB ---
                Dim keluhanUtama As String = "Keluhan tidak ditemukan"
                If noTransaksi <> "" Then
                    Dim sql As String = "SELECT TOP 1 KeluhanUtama FROM TransaksiDetail WHERE NoUrut = '" & noTransaksi & "'"
                    Dim dt As DataTable = ReadSQL(sql)
                    If dt.Rows.Count > 0 Then
                        keluhanUtama = dt.Rows(0)("KeluhanUtama").ToString()
                    End If
                End If

                'MsgBox("DEBUG: Keluhan = " & keluhanUtama)

                ' --- Mapping kdPoli dari Nama Poli ---
                Dim kdPoli As String = ""
                Select Case poli.ToUpper()
                    Case "POLI UMUM" : kdPoli = "001"
                    Case "POLI GIGI & MULUT" : kdPoli = "002"
                    Case "POLI KIA" : kdPoli = "003"
                    Case "POLI KB" : kdPoli = "008"
                    Case Else : kdPoli = "001"
                End Select

                'MsgBox("DEBUG: kdPoli = " & kdPoli)

                ' --- Get kdProvider dari MasterPasienBPJS ---
                Dim kdprovider As String = ReadSQLNIK("SELECT KdProviderPst FROM MasterPasienBPJS WHERE NoKartu = '" & noKartu & "'")
                'MsgBox("DEBUG: kdProvider = " & kdprovider)

                ' --- Get kdTkp dari form status rawat ---
                Dim kdTkp As String = "10"

                ' --- Validasi bridging dan antrean ---
                'If ValidateBridgingPcare() = False Then Exit Sub
                'If CheckAntreanBPJS(kdprovider, noKartu, kdPoli, tglDaftarBPJS) = False Then Exit Sub

                ' --- Set parameter JSON ---
                Dim parameterPendaftaran As String = "{" & _
                    """kdProviderPeserta"": """ & kdprovider & """," & _
                    """tglDaftar"": """ & tglDaftarBPJS & """," & _
                    """noKartu"": """ & noKartu & """," & _
                    """kdPoli"": """ & kdPoli & """," & _
                    """keluhan"": """ & keluhanUtama & """," & _
                    """kunjSakit"": true," & _
                    """sistole"": 0," & _
                    """diastole"": 0," & _
                    """beratBadan"": 0," & _
                    """tinggiBadan"": 0," & _
                    """respRate"": 0," & _
                    """lingkarPerut"": 0," & _
                    """heartRate"": 0," & _
                    """rujukBalik"": 0," & _
                    """kdTkp"": """ & kdTkp & """" & _
                    "}"

                'MsgBox("DEBUG: JSON Body = " & vbCrLf & parameterPendaftaran)

                ' --- URL pcare dari config ---
                Dim urlBPJS As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'pcare_base_url'")
                Dim uriBPJS As String = urlBPJS & "pendaftaran"

                'MsgBox("DEBUG: URL = " & uriBPJS)

                ' --- Kirim ke BPJS ---
                Dim jsonString As String = PostDataFromPcare(parameterPendaftaran, uriBPJS, "POST")
                ' MsgBox("DEBUG: Raw Response = " & jsonString)
                jsonString = "[" & jsonString & "]"
                Dim jsonObject() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of varJson())(jsonString)

                ' --- Handle response ---
                For Each rowData As varJson In jsonObject
                    Dim codeMetaData As Integer = Convert.ToInt32(rowData.metaData.code)
                    Dim messageMetaData As String = rowData.metaData.message
                    Dim messageResponse As String = rowData.response.message

                    'MsgBox("DEBUG: code=" & codeMetaData & ", metaMsg=" & messageMetaData & ", respMsg=" & messageResponse)

                    Select Case codeMetaData
                        Case 200, 201, 204
                            MsgBox("Pendaftaran BPJS sukses untuk " & nama & " - " & noKartu, MsgBoxStyle.Information)
                            ' Update status di ListViewCompare
                            item.SubItems(3).Text = "Terkirim ke BPJS"
                            item.BackColor = Color.LightGreen
                        Case Else
                            If messageMetaData <> "Peserta sudah di-entri di poli yang sama pada hari yang sama." Then
                                MsgBox("Error BPJS (" & noKartu & "): " & vbCrLf & messageResponse & " (" & messageMetaData & ")", MsgBoxStyle.Exclamation)
                            End If
                    End Select
                Next
            End If
        Next
    End Sub
End Class