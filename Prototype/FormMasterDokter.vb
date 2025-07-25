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
Imports DevExpress.XtraReports.UI
Imports System.Data.SqlClient
Imports System.Drawing.Imaging
Imports DevExpress.XtraPrinting

Public Class FormMasterDokter
    Private formName As String = "MASTER DOKTER"
    Private userInput As String = PoliKlinik.Lbluser.Text

    ' Variabel BPJS
    Private urlPcare As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_base_url'")

    Private Class varJson
        Public metaData As MetaData
        Public response As v4_BPJS
    End Class

    Private Sub PanelTop_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelTop.Paint
        Try
            e.Graphics.DrawString(formName, New Font("Century Gothic", 16, FontStyle.Bold), Brushes.White, New Point(10, 3))
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub FormMasterDokter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
            Me.MdiParent = PoliKlinik
            Me.Dock = DockStyle.Fill

            ' Hide tab header button
            'TabControl1.Appearance = TabAppearance.FlatButtons
            TabControlMenu.ItemSize = New Size(0, 1)
            'TabControl1.SizeMode = TabSizeMode.Fixed

            ' Load Connection
            Connection()

            'Load Poli
            LoadPoliData()

            ' Load Bridging Dokter PCare
            If CheckBridgingPcareActive() = True Then
                LoadBridgingDokterPCare()
                ComboBoxBridgingPCare.Enabled = True
            Else
                ComboBoxBridgingPCare.Enabled = False
            End If

            ' Clear Data
            ClearData()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub btnMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMenu4.Click, btnMenu3.Click, btnMenu2.Click, btnMenu1.Click
        Try
            Dim myButton = DirectCast(sender, Button)

            Select Case myButton.Name
                Case "btnMenu1"
                    TabControlMenu.SelectedTab = TabPage1
                Case "btnMenu2"
                    TabControlMenu.SelectedTab = TabPage2
                Case "btnMenu3"
                    TabControlMenu.SelectedTab = TabPage3
                Case "btnMenu4"
                    TabControlMenu.SelectedTab = TabPage4
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Connection()

    End Sub

    Private Sub SetPlaceholder()
        ApplyPlaceholder(TextBoxDokterID, "Cari ")
        ApplyPlaceholder(TextBoxNomorIHS, "Generate IHS Number")
    End Sub

    Private Sub LoadBridgingDokterPCare()
        Dim getResponse As String = ""
        Dim messageError As String = ""
        Dim uri As String = urlPcare + "dokter/0/50"

        getResponse = getDataFromPcare(uri)

        If getResponse <> "Nothing" Then
            ' Mendeklarasikan List<KeyValuePair(Of Integer, String)>
            Dim dataItems As New List(Of KeyValuePair(Of String, String))

            ' Mendeklarasikan AutoCompleteStringCollection
            Dim autoCompleteData As New AutoCompleteStringCollection()

            Dim jsonObject() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of v4_BPJS_Get_Dokter())(getResponse)

            For Each oneVar As v4_BPJS_Get_Dokter In jsonObject
                For index As Integer = 0 To oneVar.response.count - 1
                    ' Menambahkan keterangan ke dalam AutoCompleteStringCollection
                    autoCompleteData.Add(oneVar.response.list(index).nmDokter)

                    ' Menambahkan pasangan nilai ID dan keterangan ke dalam List
                    dataItems.Add(New KeyValuePair(Of String, String)(oneVar.response.list(index).kdDokter, oneVar.response.list(index).nmDokter))
                Next
            Next

            ' Menghubungkan dataItems ke ComboBox
            ComboBoxBridgingPCare.DataSource = dataItems
            ComboBoxBridgingPCare.DisplayMember = "Value" ' Menampilkan keterangan sebagai teks yang ditampilkan di ComboBox
            ComboBoxBridgingPCare.ValueMember = "Key" ' Menyimpan ID sebagai nilai yang terkait dengan item yang dipilih

            ' Mengatur AutoCompleteCustomSource ke koleksi yang telah diisi
            ComboBoxBridgingPCare.AutoCompleteCustomSource = autoCompleteData
        Else
            MsgBox("Data tidak ditemukan.", MsgBoxStyle.Critical, "Warning!")
        End If
    End Sub

    Private Sub SetDataProvinsi(ByVal jenisData As String)
        ' Mendeklarasikan List<KeyValuePair(Of Integer, String)>
        Dim dataItems As New List(Of KeyValuePair(Of String, String))

        ' Mendeklarasikan AutoCompleteStringCollection
        Dim autoCompleteData As New AutoCompleteStringCollection()

        Dim tbls As DataTable = ReadSQL("SELECT * FROM MasterWilayahProvinsi;")
        For Each Trow As DataRow In tbls.Rows
            ' Menambahkan keterangan ke dalam AutoCompleteStringCollection
            autoCompleteData.Add(Trow("NamaProvinsi"))

            ' Menambahkan pasangan nilai ID dan keterangan ke dalam List
            dataItems.Add(New KeyValuePair(Of String, String)(Trow("ID"), Trow("NamaProvinsi")))
        Next

        If jenisData = "Domisili" Then
            ' Menghubungkan dataItems ke ComboBoxProvinsiDomisili
            ComboBoxProvinsiDomisili.DataSource = dataItems
            ComboBoxProvinsiDomisili.DisplayMember = "Value" ' Menampilkan keterangan sebagai teks yang ditampilkan di ComboBox
            ComboBoxProvinsiDomisili.ValueMember = "Key" ' Menyimpan ID sebagai nilai yang terkait dengan item yang dipilih

            ' Mengatur AutoCompleteCustomSource ke koleksi yang telah diisi
            ComboBoxProvinsiDomisili.AutoCompleteCustomSource = autoCompleteData
            ComboBoxProvinsiDomisili.SelectedIndex = -1
        End If
    End Sub

    Private Sub SetDataKabupaten(ByVal kodeProvinsi As String, ByVal jenisData As String)
        ' Mendeklarasikan List<KeyValuePair(Of Integer, String)>
        Dim dataItems As New List(Of KeyValuePair(Of String, String))

        ' Mendeklarasikan AutoCompleteStringCollection
        Dim autoCompleteData As New AutoCompleteStringCollection()

        Dim tbls As DataTable = ReadSQL("SELECT * FROM MasterWilayahKabupaten WHERE KodeProvinsi = '" & kodeProvinsi & "';")
        For Each Trow As DataRow In tbls.Rows
            ' Menambahkan keterangan ke dalam AutoCompleteStringCollection
            autoCompleteData.Add(Trow("NamaKabupaten"))

            ' Menambahkan pasangan nilai ID dan keterangan ke dalam List
            dataItems.Add(New KeyValuePair(Of String, String)(Trow("ID"), Trow("NamaKabupaten")))
        Next

        If jenisData = "Domisili" Then
            ' Menghubungkan dataItems ke ComboBoxKabupatenDomisili
            ComboBoxKabupatenDomisili.DataSource = dataItems
            ComboBoxKabupatenDomisili.DisplayMember = "Value" ' Menampilkan keterangan sebagai teks yang ditampilkan di ComboBox
            ComboBoxKabupatenDomisili.ValueMember = "Key" ' Menyimpan ID sebagai nilai yang terkait dengan item yang dipilih

            ' Mengatur AutoCompleteCustomSource ke koleksi yang telah diisi
            ComboBoxKabupatenDomisili.AutoCompleteCustomSource = autoCompleteData
            ComboBoxKabupatenDomisili.SelectedIndex = -1
        End If
    End Sub

    Private Sub SetDataKecamatan(ByVal kodeKabupaten As String, ByVal jenisData As String)
        ' Mendeklarasikan List<KeyValuePair(Of Integer, String)>
        Dim dataItems As New List(Of KeyValuePair(Of String, String))

        ' Mendeklarasikan AutoCompleteStringCollection
        Dim autoCompleteData As New AutoCompleteStringCollection()

        Dim tbls As DataTable = ReadSQL("SELECT * FROM MasterWilayahKecamatan WHERE KodeKabupaten = '" & kodeKabupaten & "';")
        For Each Trow As DataRow In tbls.Rows
            ' Menambahkan keterangan ke dalam AutoCompleteStringCollection
            autoCompleteData.Add(Trow("NamaKecamatan"))

            ' Menambahkan pasangan nilai ID dan keterangan ke dalam List
            dataItems.Add(New KeyValuePair(Of String, String)(Trow("ID"), Trow("NamaKecamatan")))
        Next

        If jenisData = "Domisili" Then
            ' Menghubungkan dataItems ke ComboBoxKecamatanDomisili
            ComboBoxKecamatanDomisili.DataSource = dataItems
            ComboBoxKecamatanDomisili.DisplayMember = "Value" ' Menampilkan keterangan sebagai teks yang ditampilkan di ComboBox
            ComboBoxKecamatanDomisili.ValueMember = "Key" ' Menyimpan ID sebagai nilai yang terkait dengan item yang dipilih

            ' Mengatur AutoCompleteCustomSource ke koleksi yang telah diisi
            ComboBoxKecamatanDomisili.AutoCompleteCustomSource = autoCompleteData
            ComboBoxKecamatanDomisili.SelectedIndex = -1
        End If
    End Sub

    Private Sub SetDataKelurahan(ByVal kodeKecamatan As String, ByVal jenisData As String)
        ' Mendeklarasikan List<KeyValuePair(Of Integer, String)>
        Dim dataItems As New List(Of KeyValuePair(Of String, String))

        ' Mendeklarasikan AutoCompleteStringCollection
        Dim autoCompleteData As New AutoCompleteStringCollection()

        Dim tbls As DataTable = ReadSQL("SELECT * FROM MasterWilayahKelurahan WHERE KodeKecamatan = '" & kodeKecamatan & "';")
        For Each Trow As DataRow In tbls.Rows
            ' Menambahkan keterangan ke dalam AutoCompleteStringCollection
            autoCompleteData.Add(Trow("NamaKelurahan"))

            ' Menambahkan pasangan nilai ID dan keterangan ke dalam List
            dataItems.Add(New KeyValuePair(Of String, String)(Trow("ID"), Trow("NamaKelurahan")))
        Next

        If jenisData = "Domisili" Then
            ' Menghubungkan dataItems ke ComboBoxKecamatanDomisili
            ComboBoxKelurahanDomisili.DataSource = dataItems
            ComboBoxKelurahanDomisili.DisplayMember = "Value" ' Menampilkan keterangan sebagai teks yang ditampilkan di ComboBox
            ComboBoxKelurahanDomisili.ValueMember = "Key" ' Menyimpan ID sebagai nilai yang terkait dengan item yang dipilih

            ' Mengatur AutoCompleteCustomSource ke koleksi yang telah diisi
            ComboBoxKelurahanDomisili.AutoCompleteCustomSource = autoCompleteData
            ComboBoxKelurahanDomisili.SelectedIndex = -1
        End If
    End Sub

    Function CekInputKartu(ByVal jenisKartu As String) As Boolean
        'If IsConnectedToIPAddress("www.google.com") = False Then
        '    MsgBox("Periksa koneksi internet anda.", MsgBoxStyle.Critical, "Warning!")
        '    Return False
        'End If

        If jenisKartu = "ButtonCekNIK" Then
            Dim nomorNIK As String = TextBoxNomorNIK.Text.Trim()

            If TextBoxNomorNIK.Text = "" Then
                MessageBox.Show("Nomor NIK tidak boleh kosong.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If

            If nomorNIK.Length <> 16 Then
                MessageBox.Show("Nomor NIK harus terdiri dari 16 digit.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If
        End If

        Return True
    End Function

    Function ValidasiInputData(Optional ByVal jenisDokter As String = "") As Boolean
        ' Validasi Nama Poli
        If RadioButtonJenisDokter.Checked = True AndAlso CheckedListBoxPoli.CheckedItems.Count = 0 Then
            MsgBox("Silakan pilih minimal satu poli untuk dokter.", MsgBoxStyle.Exclamation, "Validasi Gagal")
            Exit Function
        End If

        ' Validasi Nomor NIK Kosong
        If TextBoxNomorNIK.Text = "" Then
            MessageBox.Show("Nomor NIK tidak boleh kosong.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        ' Validasi Jumlah Digit Nomor NIK
        If TextBoxNomorNIK.Text.Length <> 16 Then
            MessageBox.Show("Nomor NIK Harus Terdiri dari 16 Digit.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        ' Validasi Nomor NIP Kosong
        If TextBoxNomorNIP.Text = "" Then
            MessageBox.Show("Nomor NIP tidak boleh kosong.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If


        ' Validasi Nomor IHS Kosong
        'If RadioButtonJenisDokter.Checked = True And TextBoxNomorIHS.Text = "" Then
        '    MessageBox.Show("Nomor IHS tidak boleh kosong.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Return False
        'End If
        If jenisDokter = "Dokter" AndAlso TextBoxNomorIHS.Text = "" Then
            MessageBox.Show("Nomor IHS tidak boleh kosong.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        ' Validasi Bridging PCare
        'If RadioButtonJenisDokter.Checked = True And CheckBridgingPcareActive() = True AndAlso ComboBoxBridgingPCare.SelectedIndex = -1 Then
        '    MessageBox.Show("Bridging PCare tidak boleh kosong.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Return False
        'End If
        If jenisDokter = "Dokter" AndAlso CheckBridgingPcareActive() AndAlso ComboBoxBridgingPCare.SelectedIndex = -1 Then
            MessageBox.Show("Bridging PCare tidak boleh kosong.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If


        ' Validasi SIP Dokter
        If RadioButtonJenisDokter.Checked = True And TextBoxNomorSIP.Text.Trim = "" Then
            MessageBox.Show("No SIP Dokter tidak boleh kosong.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If
        'If jenisDokter <> "Marketing" AndAlso TextBoxNomorSIP.Text.Trim = "" Then
        '    MessageBox.Show("No SIP tidak boleh kosong.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '    Return False
        'End If


        ' Validasi Nama Lengkap Kosong
        If TextBoxNamaLengkapIdentitas.Text = "" Then
            MessageBox.Show("Nama Pasien tidak boleh kosong.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        If DateTimePickerTglLahir.Value = DateSerial("9998", "12", "31") Then
            MsgBox("Tanggal lahir tidak boleh kosong.", MsgBoxStyle.Critical, "Warning!")
            Return False
        End If

        ' Cek pemakaian NIK
        'If IsPlaceholder(TextBoxDokterID) = True Then
        '    Dim tblCheckNIK As DataTable = ReadSQL("SELECT Nama, ID FROM MasterDokter WHERE NoNIK = '" & TextBoxNomorNIK.Text & "'")
        '    If tblCheckNIK.Rows.Count > 0 Then
        '        Dim dataNIK As DataRow = tblCheckNIK.Rows(0)

        '        MsgBox("Nomor NIK sudah dipakai atas nama " & dataNIK("Nama") & " dengan nomor NIP " & dataNIK("ID") & ".", MsgBoxStyle.Critical, "Warning!")
        '        Return False
        '    End If
        'End If

        ' Cek pemakaian NIP
        If IsPlaceholder(TextBoxDokterID) = True Then
            Dim tblCheckNIK As DataTable = ReadSQL("SELECT Nama FROM MasterDokter WHERE NoNIP = '" & TextBoxNomorNIP.Text & "'")
            If tblCheckNIK.Rows.Count > 0 Then
                Dim dataNIK As DataRow = tblCheckNIK.Rows(0)

                MsgBox("Nomor NIP sudah dipakai atas nama " & dataNIK("Nama") & ".", MsgBoxStyle.Critical, "Warning!")
                Return False
            End If
        End If

        ' Cek Email
        If TextBoxEmailIdentitas.Text.Length <> 0 Then
            If validateEmail(TextBoxEmailIdentitas.Text) = False Then
                MsgBox("Perhatikan penulisan email dengan benar.", MsgBoxStyle.Exclamation, "Warning!")
                Return False
            End If
        End If

        ' Cek No WhatsApp
        If TextBoxNoHPIdentitas.Text.Length <> 0 Then
            If validateNoWhatsapp(TextBoxNoHPIdentitas.Text) = False Then
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub LoadPoliData()
        CheckedListBoxPoli.Items.Clear()
        Dim poli As DataTable = ReadSQL("SELECT * FROM MasterPoliTujuan WHERE PoliSakit = 'True'")
        If poli IsNot Nothing Then
            For Each TrowPoliTujuan As DataRow In poli.Rows
                CheckedListBoxPoli.Items.Add(TrowPoliTujuan("NamaPoli").ToString())
            Next
        End If
    End Sub

    Private Sub SaveData(ByRef jenisProses As String)
        ' Inisialisasi semua variabel
        Dim idDokter As String = ""
        Dim jenisDokter As String = ""

        If RadioButtonJenisDokter.Checked = True Then
            jenisDokter = "Dokter"
        ElseIf RadioButtonJenisBidan.Checked = True Then
            jenisDokter = "Bidan"
        ElseIf RadioButtonJenisPerawat.Checked = True Then
            jenisDokter = "Perawat"
        ElseIf RadioButtonJenisMarketing.Checked = True Then
            jenisDokter = "Marketing"
        End If

        If ValidasiInputData(jenisDokter) = True Then
            Dim noNIK As String = TextBoxNomorNIK.Text.Trim()
            Dim noNIP As String = TextBoxNomorNIP.Text.Trim()
            Dim noSIP As String = TextBoxNomorSIP.Text.Trim()
            Dim namaDokter As String = TextBoxNamaLengkapIdentitas.Text.Trim()
            Dim tempatLahir As String = TextBoxTempatLahir.Text.Trim()
            Dim tglLahir As String = Format(DateTimePickerTglLahir.Value, "MM/dd/yyyy")
            Dim jenisKelamin As String = ""

            If RadioButtonJenisKelaminLakiIdentitas.Checked = True Then
                jenisKelamin = "L"
            ElseIf RadioButtonJenisKelaminPerempuanIdentitas.Checked = True Then
                jenisKelamin = "P"
            End If

            Dim domisiliAlamat As String = TextBoxAlamatDomisili.Text.Trim()
            Dim domisiliProvinsi As String = ComboBoxProvinsiDomisili.Text.Trim()
            Dim domisiliKabupaten As String = ComboBoxKabupatenDomisili.Text.Trim()
            Dim domisiliKecamatan As String = ComboBoxKecamatanDomisili.Text.Trim()
            Dim domisiliKelurahan As String = ComboBoxKelurahanDomisili.Text.Trim()
            Dim domisiliRT As String = TextBoxRTDomisili.Text.Trim()
            Dim domisiliRW As String = TextBoxRWDomisili.Text.Trim()
            Dim domisiliKodePos As String = TextBoxKodePosDomisili.Text.Trim()

            Dim noHandphone As String = TextBoxNoHPIdentitas.Text.Trim()
            Dim email As String = TextBoxEmailIdentitas.Text.Trim()

            Dim poliGabung As String = ""

            If jenisDokter = "Dokter" Then
                Dim poliList As New List(Of String)
                For Each item As String In CheckedListBoxPoli.CheckedItems
                    poliList.Add(item)
                Next
                poliGabung = String.Join(",", poliList.ToArray())
            End If

            ' IHS Number
            Dim noIHS As String = ""

            If IsPlaceholder(TextBoxNomorIHS) = False Then noIHS = TextBoxNomorIHS.Text

            ' PCare
            Dim kodeBridgingPCare As String = ""
            Dim namaBridgingPCare As String = ""

            If ComboBoxBridgingPCare.SelectedIndex <> -1 Then
                kodeBridgingPCare = DirectCast(ComboBoxBridgingPCare.SelectedItem, KeyValuePair(Of String, String)).Key
                namaBridgingPCare = DirectCast(ComboBoxBridgingPCare.SelectedItem, KeyValuePair(Of String, String)).Value
            End If

            ' Status Aktif
            Dim statusAktif As Boolean = True
            If RadioButtonStatusAktifYa.Checked = True Then
                statusAktif = True
            ElseIf RadioButtonStatusAktifTidak.Checked = True Then
                statusAktif = False
            End If

            Dim parameterUpdate As String = ""

            If jenisProses = "CREATE" Then
                idDokter = TextBoxNomorNIP.Text.Trim()

                ' Input ke dalam tabel master dokter
                WriteSQL("INSERT INTO MasterDokter (ID, Jenis, NoIHS, NoNIK, NoNIP, NoSIP, Nama, TempatLahir, TglLahir, JenisKelamin, DomisiliAlamat, DomisiliRT, DomisiliRW, DomisiliKelurahan, DomisiliKecamatan, DomisiliKabupaten, DomisiliProvinsi, DomisiliKodePos, NoHandphone, Email, KodeBridgingPCare, NamaBridgingPCare, CreatedBy, CreatedDate, Poli) " & _
                  "VALUES('" & idDokter & "', '" & jenisDokter & "', '" & noIHS & "', '" & noNIK & "', '" & noNIP & "', '" & noSIP & "', '" & namaDokter & "', '" & tempatLahir & "', '" & tglLahir & "', '" & jenisKelamin & "', '" & domisiliAlamat & "', '" & domisiliRT & "', '" & domisiliRW & "', '" & domisiliKelurahan & "', '" & domisiliKecamatan & "', '" & domisiliKabupaten & "', '" & domisiliProvinsi & "', '" & domisiliKodePos & "', '" & noHandphone & "', '" & email & "', " & _
                  "'" & kodeBridgingPCare & "', '" & namaBridgingPCare & "', '" & userInput & "', GETDATE(), '" & poliGabung & "')", 4)


                ClearData()
                LoadDataDokter(idDokter)
                MsgBox("Berhasil menyimpan data dokter : " & namaDokter & " (" & noNIP & ").", MsgBoxStyle.Information, "Success!")
            ElseIf jenisProses = "UPDATE" Then
                idDokter = TextBoxDokterID.Text

                parameterUpdate = "Jenis = '" & jenisDokter & "'," & _
                                  "NoIHS = '" & noIHS & "'," & _
                                  "NoNIP = '" & noNIP & "'," & _
                                  "NoSIP = '" & noSIP & "'," & _
                                  "Nama = '" & namaDokter & "'," & _
                                  "TempatLahir = '" & tempatLahir & "'," & _
                                  "TglLahir = '" & tglLahir & "'," & _
                                  "JenisKelamin = '" & jenisKelamin & "'," & _
                                  "DomisiliAlamat = '" & domisiliAlamat & "'," & _
                                  "DomisiliRT = '" & domisiliRT & "'," & _
                                  "DomisiliRW = '" & domisiliRW & "'," & _
                                  "DomisiliKelurahan = '" & domisiliKelurahan & "'," & _
                                  "DomisiliKecamatan = '" & domisiliKecamatan & "'," & _
                                  "DomisiliKabupaten = '" & domisiliKabupaten & "'," & _
                                  "DomisiliProvinsi = '" & domisiliProvinsi & "'," & _
                                  "DomisiliKodePos = '" & domisiliKodePos & "'," & _
                                  "NoHandphone = '" & noHandphone & "'," & _
                                  "Email = '" & email & "'," & _
                                  "KodeBridgingPCare = '" & kodeBridgingPCare & "'," & _
                                  "NamaBridgingPCare = '" & namaBridgingPCare & "'," & _
                                  "StatusAktif = " & Convert.ToInt32(statusAktif) & "," & _
                                  "Poli = '" & poliGabung & "'," & _
                                  "ChangeBy = '" & userInput & "'," & _
                                  "ChangeDate = GETDATE()"


                ' Update tabel MasterPasien
                WriteSQL("UPDATE MasterDokter SET " & parameterUpdate & " WHERE ID = '" & idDokter & "'", 4)

                ClearData()
                LoadDataDokter(idDokter)
                MsgBox("Berhasil mengubah data.", MsgBoxStyle.Information, "Success!")
            End If
        End If
    End Sub

    Private Sub ClearData()
        ' Set Clear
        TextBoxDokterID.ResetText()
        TextBoxNomorIHS.ResetText()
        TextBoxNomorNIK.ResetText()
        TextBoxNamaLengkapIdentitas.ResetText()
        TextBoxTempatLahir.ResetText()
        DateTimePickerTglLahir.Value = DateSerial("9998", "12", "31")
        RadioButtonJenisKelaminLakiIdentitas.Checked = True
        TextBoxNomorNIP.ResetText()
        TextBoxNomorSIP.ResetText()
        TextBoxDokterID.ResetText()
        TextBoxDokterID.ResetText()
        TextBoxDokterID.ResetText()
        TextBoxAlamatDomisili.ResetText()
        TextBoxRTDomisili.ResetText()
        TextBoxRWDomisili.ResetText()
        ComboBoxKelurahanDomisili.ResetText()
        ComboBoxKecamatanDomisili.ResetText()
        ComboBoxKabupatenDomisili.ResetText()
        ComboBoxProvinsiDomisili.ResetText()
        TextBoxKodePosDomisili.ResetText()
        TextBoxNoHPIdentitas.ResetText()
        TextBoxEmailIdentitas.ResetText()
        For i As Integer = 0 To CheckedListBoxPoli.Items.Count - 1
            CheckedListBoxPoli.SetItemChecked(i, False)
        Next

        ' Set Enable / Disable
        TextBoxNomorNIK.Enabled = True
        TextBoxNomorNIK.BackColor = Color.White
        TextBoxNamaLengkapIdentitas.ReadOnly = False
        PanelJenisKelaminPasien.Enabled = True
        DateTimePickerTglLahir.Enabled = True
        CheckedListBoxPoli.Enabled = True

        ' Load Placeholder
        SetPlaceholder()

        ' Set Combo Box
        ComboBoxBridgingPCare.SelectedIndex = -1
    End Sub

    Public Sub LoadDataDokter(ByRef idDokter As String)
        ClearData() ' Clear Data

        ' Load data dari tabel MasterPasien
        Dim Tbls As DataTable = ReadSQL("SELECT * FROM MasterDokter WHERE ID = '" & idDokter & "'")
        Dim Trow As DataRow = Tbls.Rows(0)



        ' Insert data ke textbox
        If IsDBNull(Trow("ID")) = False Then TextBoxDokterID.Text = Trow("ID")

        If Trow("Jenis") = "Dokter" Then
            RadioButtonJenisDokter.Checked = True
        ElseIf Trow("Jenis") = "Perawat" Then
            RadioButtonJenisPerawat.Checked = True
        ElseIf Trow("Jenis") = "Bidan" Then
            RadioButtonJenisBidan.Checked = True
        ElseIf Trow("Jenis") = "Marketing" Then
            RadioButtonJenisMarketing.Checked = True
        End If

        If IsDBNull(Trow("NoNIK")) = False Then TextBoxNomorNIK.Text = Trow("NoNIK")
        If IsDBNull(Trow("NoNIP")) = False Then TextBoxNomorNIP.Text = Trow("NoNIP")
        If IsDBNull(Trow("NoSIP")) = False Then TextBoxNomorSIP.Text = Trow("NoSIP")
        If IsDBNull(Trow("NoIHS")) = False Then TextBoxNomorIHS.Text = Trow("NoIHS")

        If IsDBNull(Trow("NamaBridgingPCare")) = False Then ComboBoxBridgingPCare.Text = Trow("NamaBridgingPCare")

        If IsDBNull(Trow("Nama")) = False Then TextBoxNamaLengkapIdentitas.Text = Trow("Nama")
        If IsDBNull(Trow("TempatLahir")) = False Then TextBoxTempatLahir.Text = Trow("TempatLahir")
        If IsDBNull(Trow("TglLahir")) = False Then DateTimePickerTglLahir.Text = Trow("TglLahir")

        If Trow("JenisKelamin") = "L" Then
            RadioButtonJenisKelaminLakiIdentitas.Checked = True
        ElseIf Trow("JenisKelamin") = "P" Then
            RadioButtonJenisKelaminPerempuanIdentitas.Checked = True
        End If

        If IsDBNull(Trow("DomisiliAlamat")) = False Then TextBoxAlamatDomisili.Text = Trow("DomisiliAlamat")
        If IsDBNull(Trow("DomisiliProvinsi")) = False Then ComboBoxProvinsiDomisili.Text = Trow("DomisiliProvinsi")
        If IsDBNull(Trow("DomisiliKabupaten")) = False Then ComboBoxKabupatenDomisili.Text = Trow("DomisiliKabupaten")
        If IsDBNull(Trow("DomisiliKecamatan")) = False Then ComboBoxKecamatanDomisili.Text = Trow("DomisiliKecamatan")
        If IsDBNull(Trow("DomisiliKelurahan")) = False Then ComboBoxKelurahanDomisili.Text = Trow("DomisiliKelurahan")
        If IsDBNull(Trow("DomisiliRT")) = False Then TextBoxRTDomisili.Text = Trow("DomisiliRT")
        If IsDBNull(Trow("DomisiliRW")) = False Then TextBoxRWDomisili.Text = Trow("DomisiliRW")
        If IsDBNull(Trow("DomisiliKodePos")) = False Then TextBoxKodePosDomisili.Text = Trow("DomisiliKodePos")

        If IsDBNull(Trow("NoHandphone")) = False Then TextBoxNoHPIdentitas.Text = Trow("NoHandphone")
        If IsDBNull(Trow("Email")) = False Then TextBoxEmailIdentitas.Text = Trow("Email")

        If Not IsDBNull(Trow("Poli")) Then
            Dim namaPoliGabungan As String = Trow("Poli").ToString()
            Dim daftarPoli() As String = namaPoliGabungan.Split(","c)

            For i As Integer = 0 To CheckedListBoxPoli.Items.Count - 1
                Dim itemPoli As String = CheckedListBoxPoli.Items(i).ToString()

                ' Tandai dicentang jika termasuk dalam data poli
                If daftarPoli.Contains(itemPoli) Then
                    CheckedListBoxPoli.SetItemChecked(i, True)
                End If
            Next
        End If

        If Trow("StatusAktif") = True Then
            RadioButtonStatusAktifYa.Checked = True
        ElseIf Trow("StatusAktif") = False Then
            RadioButtonStatusAktifTidak.Checked = True
        End If

        ' Set data readonly
        TextBoxNomorNIK.Enabled = False
    End Sub

    Private Sub TextBoxNomorNIK_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxNomorNIK.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub TextBoxRTDomisili_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxRTDomisili.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub TextBoxRWDomisili_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxRWDomisili.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub TextBoxKodePosDomisili_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxKodePosDomisili.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub TextBoxHPIdentitas_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxNoHPIdentitas.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub TextBoxTeleponIdentitas_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub TextBoxNomorNIK_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBoxNomorNIK.MouseDown
        ' Menonaktifkan opsi Paste pada menu konteks
        'If e.Button = MouseButtons.Right Then
        '    TextBoxNomorNIK.ContextMenu = New ContextMenu()
        'End If
    End Sub

    Private Sub ButtonSimpanMenu1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSimpanMenu1.Click
        If IsPlaceholder(TextBoxDokterID) = True Then
            SaveData("CREATE")
        Else
            SaveData("UPDATE")
        End If
    End Sub

    Private Sub ButtonClearMenu1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClearMenu1.Click
        ClearData()
    End Sub

    Private Sub GetNumberIHS(ByVal nomorNIK As String)
        Dim nomorIHS As String = ""
        Dim baseURL As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'satu_sehat_base_url'")
        Dim apiEndpoint As String = baseURL & "Practitioner?identifier=https://fhir.kemkes.go.id/id/nik|" & nomorNIK
        Dim responseString As String = GetDataSatuSehat(apiEndpoint)
        Dim jsonObject() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of PatientResource())(responseString)

        For Each oneVar As PatientResource In jsonObject
            For index As Integer = 0 To oneVar.entry.Length - 1
                nomorIHS = oneVar.entry(index).resource.id
            Next
        Next

        If nomorIHS <> "" Then
            TextBoxNomorIHS.Text = nomorIHS
            MsgBox("Nomor IHS ditemukan.", MsgBoxStyle.Information, "Success!")
        Else
            TextBoxNomorIHS.ResetText()
            MsgBox("Nomor IHS tidak ditemukan.", MsgBoxStyle.Exclamation, "Warning!")
        End If
    End Sub

    Private Sub TextBoxNomorNIK_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxNomorNIK.TextChanged
        TextBoxNomorIHS.ResetText()
        ApplyPlaceholder(TextBoxNomorIHS, "Generate IHS Number")
    End Sub

    Private Sub ButtonGetNomorIHS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGetNomorIHS.Click
        If CekInputKartu("ButtonCekNIK") = True Then
            GetNumberIHS(TextBoxNomorNIK.Text)
        End If
    End Sub

    Private Sub ButtonCariNoRM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCariNoRM.Click
        Find.Show()
        Find.Query("SELECT ID, Nama, Jenis, CASE WHEN StatusAktif = 1 then 'Aktif' else 'Tidak Aktif' end as StatusAktif FROM MasterDokter", " ORDER BY Nama ASC", "FindMasterDokter", 1)
    End Sub

    Private Sub ComboBoxProvinsiDomisili_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ComboBoxProvinsiDomisili.Validating
        Dim inputText As String = ComboBoxProvinsiDomisili.Text
        If Not IsItemInComboBoxList(ComboBoxProvinsiDomisili, inputText) AndAlso inputText <> "" Then
            MsgBox("Data yang dimasukkan tidak valid. Silakan pilih item dari daftar yang tersedia.", MsgBoxStyle.Exclamation, "Warning!")
            e.Cancel = True
        End If
    End Sub

    Private Function IsItemInComboBoxList(ByVal comboBox As System.Windows.Forms.ComboBox, ByVal inputText As String) As Boolean
        ' Mengonversi AutoCompleteCustomSource menjadi koleksi string
        Dim autoCompleteList As AutoCompleteStringCollection = comboBox.AutoCompleteCustomSource
        Dim autoCompleteArray As String() = New String(autoCompleteList.Count - 1) {}
        autoCompleteList.CopyTo(autoCompleteArray, 0)

        ' Memeriksa apakah teks yang dimasukkan sesuai dengan item yang ada di daftar
        Return Array.Exists(autoCompleteArray, Function(item) item.Equals(inputText, StringComparison.OrdinalIgnoreCase))
    End Function

    Private Sub ComboBoxProvinsiDomisili_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxProvinsiDomisili.SelectedIndexChanged
        Try
            ComboBoxKabupatenDomisili.DataSource = Nothing ' Menghapus sambungan dengan DataSource
            ComboBoxKabupatenDomisili.Items.Clear() ' Membersihkan item ComboBox

            If ComboBoxProvinsiDomisili.SelectedIndex <> -1 Then
                Dim kodeProvinsi As String = DirectCast(ComboBoxProvinsiDomisili.SelectedItem, KeyValuePair(Of String, String)).Key
                SetDataKabupaten(kodeProvinsi, "Domisili")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub ComboBoxKabupatenDomisili_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ComboBoxKabupatenDomisili.Validating
        Dim inputText As String = ComboBoxKabupatenDomisili.Text
        If Not IsItemInComboBoxList(ComboBoxKabupatenDomisili, inputText) AndAlso inputText <> "" Then
            MsgBox("Data yang dimasukkan tidak valid. Silakan pilih item dari daftar yang tersedia.", MsgBoxStyle.Exclamation, "Warning!")
            e.Cancel = True
        End If
    End Sub

    Private Sub ComboBoxKabupatenDomisili_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxKabupatenDomisili.SelectedIndexChanged
        Try
            ComboBoxKecamatanDomisili.DataSource = Nothing ' Menghapus sambungan dengan DataSource
            ComboBoxKecamatanDomisili.Items.Clear() ' Membersihkan item ComboBox

            If ComboBoxKabupatenDomisili.SelectedIndex <> -1 Then
                Dim kodeKabupaten As String = DirectCast(ComboBoxKabupatenDomisili.SelectedItem, KeyValuePair(Of String, String)).Key
                SetDataKecamatan(kodeKabupaten, "Domisili")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub ComboBoxKecamatanDomisili_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ComboBoxKecamatanDomisili.Validating
        Dim inputText As String = ComboBoxKecamatanDomisili.Text
        If Not IsItemInComboBoxList(ComboBoxKecamatanDomisili, inputText) AndAlso inputText <> "" Then
            MsgBox("Data yang dimasukkan tidak valid. Silakan pilih item dari daftar yang tersedia.", MsgBoxStyle.Exclamation, "Warning!")
            e.Cancel = True
        End If
    End Sub

    Private Sub ComboBoxKecamatanDomisili_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxKecamatanDomisili.SelectedIndexChanged
        Try
            ComboBoxKelurahanDomisili.DataSource = Nothing ' Menghapus sambungan dengan DataSource
            ComboBoxKelurahanDomisili.Items.Clear() ' Membersihkan item ComboBox

            If ComboBoxKecamatanDomisili.SelectedIndex <> -1 Then
                Dim kodeKecamatan As String = DirectCast(ComboBoxKecamatanDomisili.SelectedItem, KeyValuePair(Of String, String)).Key
                SetDataKelurahan(kodeKecamatan, "Domisili")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub ComboBoxKelurahanDomisili_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ComboBoxKelurahanDomisili.Validating
        Dim inputText As String = ComboBoxKelurahanDomisili.Text
        If Not IsItemInComboBoxList(ComboBoxKelurahanDomisili, inputText) AndAlso inputText <> "" Then
            MsgBox("Data yang dimasukkan tidak valid. Silakan pilih item dari daftar yang tersedia.", MsgBoxStyle.Exclamation, "Warning!")
            e.Cancel = True
        End If
    End Sub

    Private Sub ComboBoxProvinsiDomisili_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxProvinsiDomisili.Click
        SetDataProvinsi("Domisili")
    End Sub

    Private Sub ComboBoxBridgingPCare_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ComboBoxBridgingPCare.Validating
        Dim inputText As String = ComboBoxBridgingPCare.Text
        If Not IsItemInComboBoxList(ComboBoxBridgingPCare, inputText) AndAlso inputText <> "" Then
            MsgBox("Data yang dimasukkan tidak valid. Silakan pilih item dari daftar yang tersedia.", MsgBoxStyle.Exclamation, "Warning!")
            e.Cancel = True
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If ComboBoxBridgingPCare.SelectedIndex <> -1 Then
            Dim kode As String = DirectCast(ComboBoxBridgingPCare.SelectedItem, KeyValuePair(Of String, String)).Key
            Dim nama As String = DirectCast(ComboBoxBridgingPCare.SelectedItem, KeyValuePair(Of String, String)).Value

            MsgBox(kode & " - " & nama)
        End If
    End Sub
End Class