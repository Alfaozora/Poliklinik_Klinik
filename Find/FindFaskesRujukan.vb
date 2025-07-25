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

Public Class FindFaskesRujukan
    Private formName As String = "PENCARIAN FASKES RUJUKAN"
    Private jenisRujukan As String = ""
    Private userInput As String = PoliKlinik.Lbluser.Text

    ' Variabel BPJS
    Private urlPcare As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_base_url'")
    Private noBPJS As String = ""

    Private Class varJson
        Public metaData As MetaData
        Public response As v4_BPJS

        Public Class JSON_result
            Public kdppk As String
            Public nmppk As String
            Public alamatPpk As String
            Public telpPpk As String
            Public kelas As String
            Public nmkc As String
            Public distance As String
            Public jadwal As String
            Public jmlRujuk As String
            Public kapasitas As String
            Public persentase As String
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

    Private Sub GridControl1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridControlPencarian.DoubleClick
        If GridViewPencarian.FocusedRowHandle >= 0 Then
            Dim Index() As Integer = GridViewPencarian.GetSelectedRows
            If Index.Length > 0 Then
                LoadData(Index(0))
            End If
        End If
    End Sub

    Function CreateTable() As DataTable
        Dim Thasil As New DataTable

        'insertRowToTbls(Thasil, "Typstring", "NO")
        insertRowToTbls(Thasil, "Typstring", "FASKES")
        insertRowToTbls(Thasil, "Typstring", "KELAS")
        insertRowToTbls(Thasil, "Typstring", "KANTOR CABANG")
        insertRowToTbls(Thasil, "Typstring", "ALAMAT")
        insertRowToTbls(Thasil, "Typstring", "TELP")
        insertRowToTbls(Thasil, "Typstring", "JARAK")
        insertRowToTbls(Thasil, "Typstring", "TOTAL RUJUKAN")
        insertRowToTbls(Thasil, "Typstring", "KAPASITAS")
        insertRowToTbls(Thasil, "Typstring", "( % )")
        insertRowToTbls(Thasil, "Typstring", "JADWAL")

        For Each Tcol As DataColumn In Thasil.Columns
            Tcol.ReadOnly = True
        Next

        Return Thasil
    End Function

    Private Sub Find_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            SetAwal()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub SetAwal()
        Me.CenterToScreen()
        GridControlPencarian.DataSource = CreateTable()
        TabControlRujukanVertikal.ItemSize = New Size(0, 1)
    End Sub

    Private Sub LoadData(ByRef Baris As Integer)
        If GridViewPencarian.RowCount > 0 Then
            Dim Grdrow As DataRowView = GridViewPencarian.GetRow(Baris)

            ClearTabRujukan() ' Clear dulu sebelum isi data baru

            Dim splitFaskerRujukan() As String = Grdrow("FASKES").ToString.Split("~")
            FormRekamMedisDokter.TextBoxNamaFaskesRujukan.Text = splitFaskerRujukan(0).ToString.Trim
            FormRekamMedisDokter.TextBoxKodeFaskesRujukan.Text = splitFaskerRujukan(1).ToString.Trim
            FormRekamMedisDokter.TextBoxJadwalPraktekRujukan.Text = Grdrow("JADWAL").ToString

            If jenisRujukan = "Kondisi Khusus" Then
                SetRujukanKhusus()
            ElseIf jenisRujukan = "Spesialis" Then
                SetRujukanSpesialis()
            End If

            Me.Close()
        End If
    End Sub

    Public Sub SetForm(ByRef Form As String, ByRef txUri As String)
        Me.BringToFront()
        'TForm = Form
        'uri = txUri

        SetDataComboBox()
        'SetGrid()
    End Sub

    Public Sub SetRujukan(ByRef Form As String, ByRef _noBPJS As String, ByRef _jenisRujukan As String)
        Me.BringToFront()
        noBPJS = _noBPJS

        SetDataComboBox()
        SetTabRujukan(_jenisRujukan)
    End Sub

    Private Sub SetTabRujukan(ByRef jenisRujukan As String)
        If jenisRujukan = "Rujuk Vertikal" Then
            If Not TabControlRujukan.TabPages.Contains(TabPageRujukanVertikal) Then
                ' Tambahkan TabPageSetTindakan ke posisi pertama (indeks 0)
                TabControlRujukan.TabPages.Insert(0, TabPageRujukanVertikal)

                ' Atur TabPageSetTindakan sebagai tab yang aktif
                TabControlRujukan.SelectedTab = TabPageRujukanVertikal
            End If

            ' Hidden TabPageRujukanHorizontal
            TabControlRujukan.TabPages.Remove(TabPageRujukanHorizontal)
            TabPageRujukanHorizontal.Hide()
        ElseIf jenisRujukan = "Rujuk Horizontal" Then
            If Not TabControlRujukan.TabPages.Contains(TabPageRujukanHorizontal) Then
                ' Tambahkan TabPageSetTindakan ke posisi pertama (indeks 0)
                TabControlRujukan.TabPages.Insert(0, TabPageRujukanHorizontal)

                ' Atur TabPageSetTindakan sebagai tab yang aktif
                TabControlRujukan.SelectedTab = TabPageRujukanHorizontal
            End If

            ' Hidden TabPageRujukanVertikal
            TabControlRujukan.TabPages.Remove(TabPageRujukanVertikal)
            TabPageRujukanVertikal.Hide()
        End If
    End Sub

    Private Sub SetDataComboBox()
        LoadSpesialisFromBPJS()
        LoadKondisiKhususFromBPJS()
        LoadSubSpesialisKondisiKhususFromBPJS()
        LoadSaranaFromBPJS()
    End Sub

    Private Sub SetGrid(ByRef uri As String)
        Try
            Dim Tdata As DataTable = New DataTable

            Tdata = CreateTable()
            Tdata.Rows.Clear()

            Dim getResponse As String = ""
            Dim uriPcare As String = urlPcare & uri

            getResponse = getDataFromPcare(uriPcare)

            If getResponse <> "Nothing" Then
                Dim varsespoli() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of varJson())(getResponse)

                For Each oneVar As varJson In varsespoli
                    ' Tambah eror pas isian kosong
                    If oneVar.metaData.message = "OK" Then
                        For index As Integer = 0 To oneVar.response.list.Length - 1
                            Dim Tlastnew As DataRow = Tdata.NewRow

                            'Set Nilai Kilometer
                            Dim distanceInMeter As Double = oneVar.response.list(index).distance ' Nilai jarak dalam meter
                            Dim distanceInKilometer As Double = distanceInMeter / 1000

                            'Tlastnew("NO") = index + 1
                            Tlastnew("FASKES") = oneVar.response.list(index).nmppk & " ~ " & oneVar.response.list(index).kdppk
                            Tlastnew("KELAS") = oneVar.response.list(index).kelas
                            Tlastnew("KANTOR CABANG") = oneVar.response.list(index).nmkc
                            Tlastnew("ALAMAT") = oneVar.response.list(index).alamatPpk
                            Tlastnew("TELP") = oneVar.response.list(index).telpPpk
                            Tlastnew("JARAK") = distanceInKilometer.ToString("0.##") & " KM"
                            Tlastnew("TOTAL RUJUKAN") = oneVar.response.list(index).jmlRujuk
                            Tlastnew("KAPASITAS") = oneVar.response.list(index).kapasitas
                            Tlastnew("( % )") = oneVar.response.list(index).persentase
                            Tlastnew("JADWAL") = oneVar.response.list(index).jadwal
                            Tdata.Rows.Add(Tlastnew)
                        Next
                    End If
                Next
            End If

            GridControlPencarian.DataSource = Tdata
            GridViewPencarian.BestFitColumns()

            If Tdata.Rows.Count = 0 Then
                MsgBox("Data tidak ditemukan.", MsgBoxStyle.Exclamation, "Warning!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub SetRujukanKhusus()
        Dim kdKhusus As String = DirectCast(ComboBoxDaftarKondisiKhusus.SelectedItem, KeyValuePair(Of String, String)).Key
        Dim nmKhusus As String = DirectCast(ComboBoxDaftarKondisiKhusus.SelectedItem, KeyValuePair(Of String, String)).Value
        Dim catatan As String = ""

        FormRekamMedisDokter.TextBoxKodeKhusus.Text = kdKhusus
        FormRekamMedisDokter.TextBoxNamaKhusus.Text = nmKhusus

        If nmKhusus.Contains("THALASEMIA") Or nmKhusus.Contains("HEMOFILI") Then
            Dim kdSubSpesialis As String = DirectCast(ComboBoxSpesialisKondisiKhusus.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim nmSubSpesialis As String = DirectCast(ComboBoxSpesialisKondisiKhusus.SelectedItem, KeyValuePair(Of String, String)).Value

            FormRekamMedisDokter.TextBoxKodeSpesialis.Text = kdSubSpesialis
            FormRekamMedisDokter.TextBoxNamaSpesialis.Text = nmSubSpesialis
        End If

        catatan = "Riwayat " & nmKhusus & " di " & FormRekamMedisDokter.TextBoxNamaFaskesRujukan.Text & ", " & TextBoxAlasanKondisiKhusus.Text

        FormRekamMedisDokter.TextBoxCatatanRujukan.Text = catatan
        FormRekamMedisDokter.DateTimePickerTglRencanaBerkunjung.Value = DateTimePickerKondisiKhusus.Value
        FormRekamMedisDokter.TextBoxJenisRujukan.Text = "Kondisi Khusus"
    End Sub

    Private Sub SetRujukanSpesialis()
        Dim kdSubSpesialis As String = DirectCast(ComboBoxDaftarSubSpesialis.SelectedItem, KeyValuePair(Of String, String)).Key
        Dim nmSubSpesialis As String = DirectCast(ComboBoxDaftarSubSpesialis.SelectedItem, KeyValuePair(Of String, String)).Value
        Dim kdSarana As String = ""
        Dim nmSarana As String = ""

        If CheckBoxStatusSarana.Checked = True Then
            kdSarana = DirectCast(ComboBoxDaftarSarana.SelectedItem, KeyValuePair(Of String, String)).Key
            nmSarana = DirectCast(ComboBoxDaftarSarana.SelectedItem, KeyValuePair(Of String, String)).Value
        End If

        FormRekamMedisDokter.TextBoxKodeSpesialis.Text = kdSubSpesialis
        FormRekamMedisDokter.TextBoxNamaSpesialis.Text = nmSubSpesialis

        FormRekamMedisDokter.TextBoxKodeSarana.Text = kdSarana
        FormRekamMedisDokter.TextBoxNamaSarana.Text = nmSarana

        FormRekamMedisDokter.TextBoxCatatanRujukan.Text = "-"
        FormRekamMedisDokter.DateTimePickerTglRencanaBerkunjung.Value = DateTimePickerSpesialis.Value
        FormRekamMedisDokter.TextBoxJenisRujukan.Text = "Spesialis"
    End Sub

    Private Sub LoadSpesialisFromBPJS()
        Dim getResponse As String = ""
        Dim messageError As String = ""
        Dim uri As String = urlPcare + "spesialis"

        getResponse = getDataFromPcare(uri)

        If getResponse <> "Nothing" Then
            ' Mendeklarasikan List<KeyValuePair(Of Integer, String)>
            Dim dataItems As New List(Of KeyValuePair(Of String, String))

            ' Mendeklarasikan AutoCompleteStringCollection
            Dim autoCompleteData As New AutoCompleteStringCollection()

            Dim jsonObject() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of varJson())(getResponse)

            For Each oneVar As varJson In jsonObject
                For index As Integer = 0 To oneVar.response.count - 1
                    ' Menambahkan keterangan ke dalam AutoCompleteStringCollection
                    autoCompleteData.Add(oneVar.response.list(index).nmSpesialis)

                    ' Menambahkan pasangan nilai ID dan keterangan ke dalam List
                    dataItems.Add(New KeyValuePair(Of String, String)(oneVar.response.list(index).kdSpesialis, oneVar.response.list(index).nmSpesialis))
                Next
            Next

            ' Menghubungkan dataItems ke ComboBox
            ComboBoxDaftarSpesialis.DataSource = dataItems
            ComboBoxDaftarSpesialis.DisplayMember = "Value" ' Menampilkan keterangan sebagai teks yang ditampilkan di ComboBox
            ComboBoxDaftarSpesialis.ValueMember = "Key" ' Menyimpan ID sebagai nilai yang terkait dengan item yang dipilih

            ' Mengatur AutoCompleteCustomSource ke koleksi yang telah diisi
            ComboBoxDaftarSpesialis.AutoCompleteCustomSource = autoCompleteData
        Else
            MsgBox("Data tidak ditemukan.", MsgBoxStyle.Critical, "Warning!")
        End If
    End Sub

    Private Sub LoadKondisiKhususFromBPJS()
        Dim getResponse As String = ""
        Dim messageError As String = ""
        Dim uri As String = urlPcare + "spesialis/khusus"

        getResponse = getDataFromPcare(uri)

        If getResponse <> "Nothing" Then
            ' Mendeklarasikan List<KeyValuePair(Of Integer, String)>
            Dim dataItems As New List(Of KeyValuePair(Of String, String))

            ' Mendeklarasikan AutoCompleteStringCollection
            Dim autoCompleteData As New AutoCompleteStringCollection()

            Dim jsonObject() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of varJson())(getResponse)

            For Each oneVar As varJson In jsonObject
                For index As Integer = 0 To oneVar.response.count - 1
                    ' Menambahkan keterangan ke dalam AutoCompleteStringCollection
                    autoCompleteData.Add(oneVar.response.list(index).nmKhusus)

                    ' Menambahkan pasangan nilai ID dan keterangan ke dalam List
                    dataItems.Add(New KeyValuePair(Of String, String)(oneVar.response.list(index).kdKhusus, oneVar.response.list(index).nmKhusus))
                Next
            Next

            ' Menghubungkan dataItems ke ComboBox
            ComboBoxDaftarKondisiKhusus.DataSource = dataItems
            ComboBoxDaftarKondisiKhusus.DisplayMember = "Value" ' Menampilkan keterangan sebagai teks yang ditampilkan di ComboBox
            ComboBoxDaftarKondisiKhusus.ValueMember = "Key" ' Menyimpan ID sebagai nilai yang terkait dengan item yang dipilih

            ' Mengatur AutoCompleteCustomSource ke koleksi yang telah diisi
            ComboBoxDaftarKondisiKhusus.AutoCompleteCustomSource = autoCompleteData
        Else
            MsgBox("Data tidak ditemukan.", MsgBoxStyle.Critical, "Warning!")
        End If
    End Sub

    Private Sub LoadSubSpesialisKondisiKhususFromBPJS()
        ' Mendeklarasikan List<KeyValuePair(Of Integer, String)>
        Dim dataItems As New List(Of KeyValuePair(Of String, String))

        ' Mendeklarasikan AutoCompleteStringCollection
        Dim autoCompleteData As New AutoCompleteStringCollection()

        ' Menambahkan keterangan ke dalam AutoCompleteStringCollection
        autoCompleteData.Add("PENYAKIT DALAM")
        autoCompleteData.Add("HEMATOLOGI - ONKOLOGI MEDIK")
        autoCompleteData.Add("ANAK")
        autoCompleteData.Add("ANAK HEMATOLOGI ONKOLOGI")

        ' Menambahkan pasangan nilai ID dan keterangan ke dalam List
        dataItems.Add(New KeyValuePair(Of String, String)("3", "PENYAKIT DALAM"))
        dataItems.Add(New KeyValuePair(Of String, String)("8", "HEMATOLOGI - ONKOLOGI MEDIK"))
        dataItems.Add(New KeyValuePair(Of String, String)("26", "ANAK"))
        dataItems.Add(New KeyValuePair(Of String, String)("30", "ANAK HEMATOLOGI ONKOLOGI"))

        ' Menghubungkan dataItems ke ComboBox
        ComboBoxSpesialisKondisiKhusus.DataSource = dataItems
        ComboBoxSpesialisKondisiKhusus.DisplayMember = "Value" ' Menampilkan keterangan sebagai teks yang ditampilkan di ComboBox
        ComboBoxSpesialisKondisiKhusus.ValueMember = "Key" ' Menyimpan ID sebagai nilai yang terkait dengan item yang dipilih

        ' Mengatur AutoCompleteCustomSource ke koleksi yang telah diisi
        ComboBoxSpesialisKondisiKhusus.AutoCompleteCustomSource = autoCompleteData
        ComboBoxSpesialisKondisiKhusus.SelectedIndex = -1
    End Sub

    Private Sub LoadSubSpesialisFromBPJS(ByVal kodeSpesialis As String)
        Dim getResponse As String = ""
        Dim messageError As String = ""
        Dim uri As String = urlPcare + "spesialis/" & kodeSpesialis & "/subspesialis"

        getResponse = getDataFromPcare(uri)

        Dim jsonObject() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of varJson())(getResponse)

        If getResponse <> "Nothing" Then
            ' Mendeklarasikan List<KeyValuePair(Of Integer, String)>
            Dim dataItems As New List(Of KeyValuePair(Of String, String))

            ' Mendeklarasikan AutoCompleteStringCollection
            Dim autoCompleteData As New AutoCompleteStringCollection()

            For Each oneVar As varJson In jsonObject
                If oneVar.metaData.code = "200" Then
                    For index As Integer = 0 To oneVar.response.count - 1
                        ' Menambahkan keterangan ke dalam AutoCompleteStringCollection
                        autoCompleteData.Add(oneVar.response.list(index).nmSubSpesialis)

                        ' Menambahkan pasangan nilai ID dan keterangan ke dalam List
                        dataItems.Add(New KeyValuePair(Of String, String)(oneVar.response.list(index).kdSubSpesialis, oneVar.response.list(index).nmSubSpesialis))
                    Next
                End If
            Next

            ' Menghubungkan dataItems ke ComboBox
            ComboBoxDaftarSubSpesialis.DataSource = dataItems
            ComboBoxDaftarSubSpesialis.DisplayMember = "Value" ' Menampilkan keterangan sebagai teks yang ditampilkan di ComboBox
            ComboBoxDaftarSubSpesialis.ValueMember = "Key" ' Menyimpan ID sebagai nilai yang terkait dengan item yang dipilih

            ' Mengatur AutoCompleteCustomSource ke koleksi yang telah diisi
            ComboBoxDaftarSubSpesialis.AutoCompleteCustomSource = autoCompleteData
        Else
            MsgBox("Data tidak ditemukan.", MsgBoxStyle.Critical, "Warning!")
        End If
    End Sub

    Private Sub LoadSaranaFromBPJS()
        Dim getResponse As String = ""
        Dim messageError As String = ""
        Dim uri As String = urlPcare + "spesialis/sarana"

        getResponse = getDataFromPcare(uri)

        If getResponse <> "Nothing" Then
            ' Mendeklarasikan List<KeyValuePair(Of Integer, String)>
            Dim dataItems As New List(Of KeyValuePair(Of String, String))

            ' Mendeklarasikan AutoCompleteStringCollection
            Dim autoCompleteData As New AutoCompleteStringCollection()

            Dim jsonObject() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of varJson())(getResponse)

            For Each oneVar As varJson In jsonObject
                For index As Integer = 0 To oneVar.response.count - 1
                    ' Menambahkan keterangan ke dalam AutoCompleteStringCollection
                    autoCompleteData.Add(oneVar.response.list(index).nmSarana)

                    ' Menambahkan pasangan nilai ID dan keterangan ke dalam List
                    dataItems.Add(New KeyValuePair(Of String, String)(oneVar.response.list(index).kdSarana, oneVar.response.list(index).nmSarana))
                Next
            Next

            ' Menghubungkan dataItems ke ComboBox
            ComboBoxDaftarSarana.DataSource = dataItems
            ComboBoxDaftarSarana.DisplayMember = "Value" ' Menampilkan keterangan sebagai teks yang ditampilkan di ComboBox
            ComboBoxDaftarSarana.ValueMember = "Key" ' Menyimpan ID sebagai nilai yang terkait dengan item yang dipilih

            ' Mengatur AutoCompleteCustomSource ke koleksi yang telah diisi
            ComboBoxDaftarSarana.AutoCompleteCustomSource = autoCompleteData
            ComboBoxDaftarSarana.SelectedIndex = -1
        Else
            MsgBox("Data tidak ditemukan.", MsgBoxStyle.Critical, "Warning!")
        End If
    End Sub

    Function CheckInputRujukanKondisiKhusus() As Boolean
        ' Cek combo box sesuai atau tidak
        If ComboBoxDaftarKondisiKhusus.SelectedIndex = -1 Then
            MsgBox("Kategori rujukan khusus harus sesuai & tidak boleh kosong.", MsgBoxStyle.Critical, "Warning!")
            Return False
        End If

        ' Cek variabel required
        If TextBoxAlasanKondisiKhusus.Text.Length <= 20 Then
            MsgBox("Harap isi alasan rujukan terlebih dahulu (minimal 20 karakter).", MsgBoxStyle.Critical, "Warning!")
            Return False
        End If

        Return True
    End Function

    Function CheckInputRujukanSpesialis() As Boolean
        ' Cek combo box sesuai atau tidak
        If ComboBoxDaftarSpesialis.SelectedIndex = -1 Then
            MsgBox("Kategori rujukan spesialis harus sesuai & tidak boleh kosong.", MsgBoxStyle.Critical, "Warning!")
            Return False
        End If

        If ComboBoxDaftarSubSpesialis.SelectedIndex = -1 Then
            MsgBox("Sub spesialis harus sesuai & tidak boleh kosong.", MsgBoxStyle.Critical, "Warning!")
            Return False
        End If

        Return True
    End Function

    Private Sub CheckBoxStatusSarana_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxStatusSarana.CheckedChanged
        If CheckBoxStatusSarana.Checked = True Then
            ComboBoxDaftarSarana.Visible = True
        Else
            ComboBoxDaftarSarana.Visible = False
        End If
    End Sub

    Private Sub ComboBoxDaftarKondisiKhusus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxDaftarKondisiKhusus.SelectedIndexChanged
        Try
            If ComboBoxDaftarKondisiKhusus.SelectedIndex <> -1 Then
                Dim kdKategoriKondisiKhusus As String = DirectCast(ComboBoxDaftarKondisiKhusus.SelectedItem, KeyValuePair(Of String, String)).Value

                If kdKategoriKondisiKhusus.Contains("THALASEMIA") Or kdKategoriKondisiKhusus.Contains("HEMOFILI") Then
                    ComboBoxSpesialisKondisiKhusus.Enabled = True
                Else
                    ComboBoxSpesialisKondisiKhusus.SelectedIndex = -1
                    ComboBoxSpesialisKondisiKhusus.Enabled = False
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub ButtonCariFaskesRujukanKondisiKhusus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCariFaskesRujukanKondisiKhusus.Click
        Try
            If CheckInputRujukanKondisiKhusus() = True Then
                jenisRujukan = "Kondisi Khusus"

                Dim kdKhusus As String = DirectCast(ComboBoxDaftarKondisiKhusus.SelectedItem, KeyValuePair(Of String, String)).Key
                Dim nmKhusus As String = DirectCast(ComboBoxDaftarKondisiKhusus.SelectedItem, KeyValuePair(Of String, String)).Value
                Dim tglRencanaBerkunjung As String = DateTimePickerKondisiKhusus.Value.ToString("dd-MM-yyyy")
                Dim kdSpesialis As String = ""
                Dim uri As String = ""

                If nmKhusus.Contains("THALASEMIA") Or nmKhusus.Contains("HEMOFILI") Then
                    kdSpesialis = DirectCast(ComboBoxSpesialisKondisiKhusus.SelectedItem, KeyValuePair(Of String, String)).Key
                    uri = "spesialis/rujuk/khusus/" & kdKhusus & "/subspesialis/" & kdSpesialis & "/noKartu/" & noBPJS & "/tglEstRujuk/" & tglRencanaBerkunjung
                Else
                    uri = "spesialis/rujuk/khusus/" & kdKhusus & "/noKartu/" & noBPJS & "/tglEstRujuk/" & tglRencanaBerkunjung
                End If

                ' Set Grid
                SetGrid(uri)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub ComboBoxDaftarSpesialis_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxDaftarSpesialis.SelectedIndexChanged
        Try
            ComboBoxDaftarSubSpesialis.DataSource = Nothing ' Menghapus sambungan dengan DataSource
            ComboBoxDaftarSubSpesialis.Items.Clear() ' Membersihkan item ComboBox

            If ComboBoxDaftarSpesialis.SelectedIndex <> -1 Then
                Dim kdSpesialis As String = DirectCast(ComboBoxDaftarSpesialis.SelectedItem, KeyValuePair(Of String, String)).Key
                LoadSubSpesialisFromBPJS(kdSpesialis)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub ButtonCariFaskesRujukanSpesialis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCariFaskesRujukanSpesialis.Click
        Try
            If CheckInputRujukanSpesialis() = True Then
                jenisRujukan = "Spesialis"

                Dim kdSubSpesialis As String = DirectCast(ComboBoxDaftarSubSpesialis.SelectedItem, KeyValuePair(Of String, String)).Key
                Dim kdSarana As String = ""

                If CheckBoxStatusSarana.Checked = False Then
                    kdSarana = "0"
                Else
                    kdSarana = DirectCast(ComboBoxDaftarSarana.SelectedItem, KeyValuePair(Of String, String)).Key
                End If

                Dim tglRencanaBerkunjung As String = DateTimePickerSpesialis.Value.ToString("dd-MM-yyyy")

                Dim uri As String = "spesialis/rujuk/subspesialis/" & kdSubSpesialis & "/sarana/" & kdSarana & "/tglEstRujuk/" & tglRencanaBerkunjung

                ' Set Grid
                SetGrid(uri)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub RadioButtonRujukanKondisiKhusus_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonRujukanKondisiKhusus.CheckedChanged, RadioButtonRujukanSpesialis.CheckedChanged
        Try
            Dim radioButton = DirectCast(sender, RadioButton)

            Select Case radioButton.Name
                Case "RadioButtonRujukanKondisiKhusus"
                    TabControlRujukanVertikal.SelectedTab = TabRujukanKondisiKhusus
                Case "RadioButtonRujukanSpesialis"
                    TabControlRujukanVertikal.SelectedTab = TabRujukanSpesialis
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub ClearTabRujukan()
        FormRekamMedisDokter.TextBoxKodeFaskesRujukan.ResetText()
        FormRekamMedisDokter.TextBoxNamaFaskesRujukan.ResetText()
        FormRekamMedisDokter.TextBoxKodeKhusus.ResetText()
        FormRekamMedisDokter.TextBoxNamaKhusus.ResetText()
        FormRekamMedisDokter.TextBoxKodeSpesialis.ResetText()
        FormRekamMedisDokter.TextBoxNamaSpesialis.ResetText()
        FormRekamMedisDokter.TextBoxCatatanRujukan.ResetText()
        FormRekamMedisDokter.TextBoxKodeSarana.ResetText()
        FormRekamMedisDokter.TextBoxNamaSarana.ResetText()
        FormRekamMedisDokter.TextBoxKodeTACC.ResetText()
        FormRekamMedisDokter.TextBoxKeteranganTACC.ResetText()
        FormRekamMedisDokter.TextBoxAlasanTACC.ResetText()
        FormRekamMedisDokter.TextBoxJenisRujukan.ResetText()
        FormRekamMedisDokter.DateTimePickerTglRencanaBerkunjung.Value = DateTime.Now

        FormRekamMedisDokter.LabelNonSpesialistik.Visible = False
    End Sub
End Class