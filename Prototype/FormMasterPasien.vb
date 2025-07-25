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

Public Class FormMasterPasien
    Private formName As String = "MASTER PASIEN"
    Private userInput As String = PoliKlinik.Lbluser.Text
    Private kdProviderLokal As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'KodePPK'")
    Private urlPcare As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_base_url'")

    Private Sub PanelTop_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelTop.Paint
        Try
            e.Graphics.DrawString(formName, New Font("Century Gothic", 16, FontStyle.Bold), Brushes.White, New Point(10, 3))
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub FormMasterPasien_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        ApplyPlaceholder(TextBoxNoRM, "Cari eRM")
        ApplyPlaceholder(TextBoxNomorIHS, "Generate IHS Number")

        'ApplyPlaceholder(TextBoxNomorNIK, "Masukkan Nomor NIK")
        'ApplyPlaceholder(TextBoxNomorKIS, "Masukkan Nomor BPJS")
        'ApplyPlaceholder(TextBoxNamaLengkapIdentitas, "Masukkan Nama Lengkap")
        'ApplyPlaceholder(TextBoxAlamatDomisili, "Masukkan Alamat Domisili")
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
        ElseIf jenisData = "KTP" Then
            ' Menghubungkan dataItems ke ComboBoxProvinsiKTP
            ComboBoxProvinsiKTP.DataSource = dataItems
            ComboBoxProvinsiKTP.DisplayMember = "Value" ' Menampilkan keterangan sebagai teks yang ditampilkan di ComboBox
            ComboBoxProvinsiKTP.ValueMember = "Key" ' Menyimpan ID sebagai nilai yang terkait dengan item yang dipilih

            ' Mengatur AutoCompleteCustomSource ke koleksi yang telah diisi
            ComboBoxProvinsiKTP.AutoCompleteCustomSource = autoCompleteData
            ComboBoxProvinsiKTP.SelectedIndex = -1
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
        ElseIf jenisData = "KTP" Then
            ' Menghubungkan dataItems ke ComboBoxKabupatenKTP
            ComboBoxKabupatenKTP.DataSource = dataItems
            ComboBoxKabupatenKTP.DisplayMember = "Value" ' Menampilkan keterangan sebagai teks yang ditampilkan di ComboBox
            ComboBoxKabupatenKTP.ValueMember = "Key" ' Menyimpan ID sebagai nilai yang terkait dengan item yang dipilih

            ' Mengatur AutoCompleteCustomSource ke koleksi yang telah diisi
            ComboBoxKabupatenKTP.AutoCompleteCustomSource = autoCompleteData
            ComboBoxKabupatenKTP.SelectedIndex = -1
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
        ElseIf jenisData = "KTP" Then
            ' Menghubungkan dataItems ke ComboBoxKabupatenKTP
            ComboBoxKecamatanKTP.DataSource = dataItems
            ComboBoxKecamatanKTP.DisplayMember = "Value" ' Menampilkan keterangan sebagai teks yang ditampilkan di ComboBox
            ComboBoxKecamatanKTP.ValueMember = "Key" ' Menyimpan ID sebagai nilai yang terkait dengan item yang dipilih

            ' Mengatur AutoCompleteCustomSource ke koleksi yang telah diisi
            ComboBoxKecamatanKTP.AutoCompleteCustomSource = autoCompleteData
            ComboBoxKecamatanKTP.SelectedIndex = -1
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
        ElseIf jenisData = "KTP" Then
            ' Menghubungkan dataItems ke ComboBoxKabupatenKTP
            ComboBoxKelurahanKTP.DataSource = dataItems
            ComboBoxKelurahanKTP.DisplayMember = "Value" ' Menampilkan keterangan sebagai teks yang ditampilkan di ComboBox
            ComboBoxKelurahanKTP.ValueMember = "Key" ' Menyimpan ID sebagai nilai yang terkait dengan item yang dipilih

            ' Mengatur AutoCompleteCustomSource ke koleksi yang telah diisi
            ComboBoxKelurahanKTP.AutoCompleteCustomSource = autoCompleteData
            ComboBoxKelurahanKTP.SelectedIndex = -1
        End If
    End Sub

    Public Function GetDataKunjungan(ByVal noKartu As String) As String
        Dim getResponse As String = ""
        Dim uri As String = urlPcare & "kunjungan/peserta/" & noKartu
        Dim totalKunjungan As Integer = 0

        getResponse = getDataFromPcare(uri)

        Dim jsonArray As JArray = JArray.Parse(getResponse)

        For Each item As JObject In jsonArray
            If item("response") IsNot Nothing AndAlso item("response").Type <> JTokenType.Null Then
                Dim varsespoli() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of v4_BPJS_Kunjungan())(getResponse)

                For Each oneVar As v4_BPJS_Kunjungan In varsespoli
                    If oneVar.metaData.message <> "NO_CONTENT" Then
                        For index As Integer = 0 To oneVar.response.list.Length - 1
                            If kdProviderLokal = oneVar.response.list(index).providerPelayanan.kdProvider Then
                                totalKunjungan = totalKunjungan + 1
                            End If
                        Next
                    End If
                Next
            End If
        Next

        Return totalKunjungan
    End Function

    Private Sub GetDataPesertaBPJS(ByRef noKartu As String, ByRef jenisKartu As String)
        Try
            If noKartu <> "" Then
                Dim kdProvider As String = ""
                Dim noKartuBPJS As String = ""
                Dim getResponse As String = ""
                Dim uri As String = ""
                Dim totalKunjungan As String = ""
                Dim statusAktif As String = ""
                Dim statusFKTP As Boolean = True
                Dim messageError As String = ""

                If jenisKartu = "NoKartuNIK" Then
                    uri = urlPcare & "peserta/nik/" & noKartu
                ElseIf jenisKartu = "NoKartuBPJS" Then
                    uri = urlPcare & "peserta/noka/" & noKartu
                End If

                getResponse = getDataFromPcare(uri)
                Dim jsonArray As JArray = JArray.Parse(getResponse)

                For Each item As JObject In jsonArray
                    If item("response") IsNot Nothing AndAlso item("response").Type <> JTokenType.Null Then
                        Dim varsespoli() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of v4_BPJS_Peserta())(getResponse)

                        For Each oneVar As v4_BPJS_Peserta In varsespoli
                            If oneVar.metaData.message <> "NO_CONTENT" Then
                                totalKunjungan = GetDataKunjungan(oneVar.response.noKartu)
                                kdProvider = oneVar.response.kdProviderPst.kdProvider

                                TextBoxNamaLengkapIdentitas.Text = oneVar.response.nama
                                TextBoxStatusPeserta.Text = oneVar.response.hubunganKeluarga
                                TextBoxNomorKIS.Text = oneVar.response.noKartu
                                TextBoxNomorNIK.Text = oneVar.response.noKTP

                                If oneVar.response.sex = "P" Then
                                    RadioButtonJenisKelaminPerempuanIdentitas.Checked = True
                                ElseIf oneVar.response.sex = "L" Then
                                    RadioButtonJenisKelaminLakiIdentitas.Checked = True
                                End If

                                DateTimePickerTglLahir.Value = DateTime.ParseExact(oneVar.response.tglLahir, "dd-MM-yyyy", Nothing)
                                TextBoxFKTP.Text = oneVar.response.kdProviderPst.kdProvider & " ~ " & oneVar.response.kdProviderPst.nmProvider
                                TextBoxPRB.Text = oneVar.response.pstPrb
                                TextBoxProlanis.Text = oneVar.response.pstProl

                                If kdProviderLokal <> oneVar.response.kdProviderPst.kdProvider Then
                                    statusFKTP = False
                                End If

                                If statusFKTP = False Then
                                    statusAktif = oneVar.response.ketAktif & ", tidak terdaftar di FKTP ini dan rekanan."
                                    TextBoxFaskesAktif.Text = "Tidak"
                                Else
                                    statusAktif = oneVar.response.ketAktif
                                    TextBoxFaskesAktif.Text = "Ya"
                                End If

                                TextBoxStatusAktif.Text = statusAktif
                                TextBoxNoHPIdentitas.Text = oneVar.response.noHP
                                TextBoxPekerjaan.Text = oneVar.response.jnsPeserta.nama

                                ' Disable No BPJS agar tidak di edit
                                TextBoxNomorKIS.ReadOnly = True
                                TextBoxNamaLengkapIdentitas.ReadOnly = True
                                PanelJenisKelaminPasien.Enabled = False
                                DateTimePickerTglLahir.Enabled = False

                                ' Disable No KTP jika ada isinya
                                If oneVar.response.noKTP <> "" Then TextBoxNomorNIK.ReadOnly = True

                                ' Disable No KIS jika ada isinya
                                If oneVar.response.noKartu <> "" Then TextBoxNomorKIS.ReadOnly = True
                            Else
                                messageError = oneVar.metaData.message
                                Exit For
                            End If
                        Next

                        If messageError <> "" Then
                            MsgBox("Data tidak ditemukan.", MsgBoxStyle.Critical, "Warning!")
                        Else
                            If kdProvider <> kdProviderLokal Then
                                MsgBox("Peserta tidak terdaftar sebagai Peserta Anda. Peserta telah berkunjung ke FKTP Anda sebanyak " & totalKunjungan & " kali kunjungan.", MsgBoxStyle.Critical, "Warning!")
                            Else
                                MsgBox("Berhasil menemukan data. Peserta telah berkunjung ke FKTP Anda sebanyak " & totalKunjungan & " kali kunjungan.", MsgBoxStyle.Information, "Success!")
                            End If
                        End If
                    Else
                        MsgBox("Data tidak ditemukan.", MsgBoxStyle.Critical, "Warning!")
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub ButtonCekKartu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCekNIK.Click, ButtonCekKIS.Click
        Try
            If CheckBridgingPcareActive() = True Then
                Dim myButton = DirectCast(sender, Button)

                If CekInputKartu(myButton.Name) = True Then
                    Select Case myButton.Name
                        Case "ButtonCekNIK"
                            GetDataPesertaBPJS(TextBoxNomorNIK.Text, "NoKartuNIK")
                        Case "ButtonCekKIS"
                            GetDataPesertaBPJS(TextBoxNomorKIS.Text, "NoKartuBPJS")
                    End Select
                End If
            Else
                MsgBox("FKTP belum bridging PCare.", MsgBoxStyle.Critical, "Warning!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Function CekInputKartu(ByVal jenisKartu As String) As Boolean
        ' Validasi Koneksi Internet
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
        ElseIf jenisKartu = "ButtonCekKIS" Then
            Dim nomorKIS As String = TextBoxNomorKIS.Text.Trim()
            If nomorKIS.Length <> 13 Then
                MessageBox.Show("Nomor BPJS harus terdiri dari 13 digit.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub InsertDataBPJS(ByRef noKartu As String, ByRef jenisProses As String)
        Try
            Dim parameterUpdate As String = ""
            Dim getResponse As String = ""
            Dim uri As String = urlPcare & "peserta/noka/" & noKartu
            getResponse = getDataFromPcare(uri)

            Dim varsespoli() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of v4_BPJS_Peserta())(getResponse)

            For Each oneVar As v4_BPJS_Peserta In varsespoli
                If jenisProses = "UPDATE" Then
                    parameterUpdate = "HubunganKeluarga = '" & oneVar.response.hubunganKeluarga & "'," & _
                                      "TglMulaiAktif = '" & oneVar.response.tglMulaiAktif & "'," & _
                                      "TglAkhirBerlaku = '" & oneVar.response.tglAkhirBerlaku & "'," & _
                                      "KdProviderPst = '" & oneVar.response.kdProviderPst.kdProvider & "'," & _
                                      "NmProviderPst = '" & oneVar.response.kdProviderPst.nmProvider & "'," & _
                                      "KdProviderGigi = '" & oneVar.response.kdProviderGigi.kdProvider & "'," & _
                                      "NmProviderGigi = '" & oneVar.response.kdProviderGigi.nmProvider & "'," & _
                                      "JenisKelas = '" & oneVar.response.jnsKelas.nama & "'," & _
                                      "KdJenisKelas = '" & oneVar.response.jnsKelas.kode & "'," & _
                                      "JenisPeserta = '" & oneVar.response.jnsPeserta.nama & "'," & _
                                      "KdJenisPeserta = '" & oneVar.response.jnsPeserta.kode & "'," & _
                                      "PesertaProl = '" & oneVar.response.pstProl & "'," & _
                                      "PesertaPrb = '" & oneVar.response.pstPrb & "'," & _
                                      "Aktif = '" & oneVar.response.aktif & "'," & _
                                      "KetAktif = '" & oneVar.response.ketAktif & "'," & _
                                      "tunggakan = '" & oneVar.response.tunggakan & "'"

                    ' Update Data
                    WriteSQL("UPDATE MasterPasienBPJS SET " & parameterUpdate & " WHERE NoKartu = '" & noKartu & "'", 4)
                ElseIf jenisProses = "CREATE" Then
                    ' Insert Data
                    WriteSQL("INSERT INTO MasterPasienBPJS (NoKartu, HubunganKeluarga, TglMulaiAktif, TglAkhirBerlaku, KdProviderPst, NmProviderPst, KdProviderGigi, NmProviderGigi, JenisKelas, KdJenisKelas, JenisPeserta, KdJenisPeserta, PesertaProl, PesertaPrb, Aktif, KetAktif, tunggakan) " & _
                             "VALUES('" & noKartu & "', '" & oneVar.response.hubunganKeluarga & "', '" & oneVar.response.tglMulaiAktif & "', '" & oneVar.response.tglAkhirBerlaku & "', '" & oneVar.response.kdProviderPst.kdProvider & "', '" & oneVar.response.kdProviderPst.nmProvider & "', '" & oneVar.response.kdProviderGigi.kdProvider & "', '" & oneVar.response.kdProviderGigi.nmProvider & "', '" & oneVar.response.jnsKelas.nama & "','" & oneVar.response.jnsKelas.kode & "','" & oneVar.response.jnsPeserta.nama & "', '" & oneVar.response.jnsPeserta.kode & "','" & oneVar.response.pstProl & "','" & oneVar.response.pstPrb & "','" & oneVar.response.aktif & "','" & oneVar.response.ketAktif & "','" & oneVar.response.tunggakan & "')", 4)
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Function CheckInput() As Boolean
        ' Validasi Inputan IHS Number
        If IsPlaceholder(TextBoxNomorIHS) = True Then
            Dim validateIHS As DialogResult = MessageBox.Show("IHS Number belum terisi, lanjutkan?", "Validasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If validateIHS = DialogResult.No Then
                Return False
            End If
        End If

        ' Validasi Inputan NIK
        If CheckBoxStatusNIK.Checked = False Then
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

            ' Cek pemakaian NIK
            Dim tblCheckNIK As DataTable = ReadSQL("SELECT Nama, NoRekamMedis, NoID FROM MasterPasien WHERE NoNIK = '" & TextBoxNomorNIK.Text & "' AND NoRekamMedis <> '" & TextBoxNoRM.Text & "'")
            If tblCheckNIK.Rows.Count > 0 Then
                Dim dataNIK As DataRow = tblCheckNIK.Rows(0)

                MsgBox("Nomor NIK sudah dipakai atas nama " & dataNIK("Nama") & " dengan nomor rekam medis " & dataNIK("NoRekamMedis") & ".", MsgBoxStyle.Critical, "Warning!")
                Return False
            End If
        End If

        ' Validasi Inputan BPJS
        If TextBoxNomorKIS.Text <> "" Then
            ' Validasi Klik Tombol Cek BPJS
            If TextBoxStatusAktif.Text.Length = 0 AndAlso CheckBridgingPcareActive() = True Then
                MessageBox.Show("Klik tombol cek BPJS terlebih dahulu.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If

            ' Validasi Jumlah Digit Nomor BPJS
            If TextBoxNomorKIS.Text.Length <> 13 Then
                MessageBox.Show("Nomor BPJS Harus Terdiri dari 13 Digit.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If

            ' Cek pemakaian BPJS
            Dim tblCheckBPJS As DataTable = ReadSQL("SELECT Nama, NoRekamMedis, NoID FROM MasterPasien WHERE NoKartuBPJS = '" & TextBoxNomorKIS.Text & "' AND NoRekamMedis <> '" & TextBoxNoRM.Text & "'")
            If tblCheckBPJS.Rows.Count > 0 Then
                Dim dataBPJS As DataRow = tblCheckBPJS.Rows(0)

                MsgBox("Nomor BPJS sudah dipakai atas nama " & dataBPJS("Nama") & " dengan nomor rekam medis " & dataBPJS("NoRekamMedis") & ".", MsgBoxStyle.Critical, "Warning!")
                Return False
            End If
        End If

        ' Validasi Nama Lengkap Kosong
        If TextBoxNamaLengkapIdentitas.Text = "" Then
            MessageBox.Show("Nama Pasien tidak boleh kosong.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        ' Validasi Alamat Domisili Kosong
        If TextBoxAlamatDomisili.Text = "" Then
            MessageBox.Show("Alamat Domisili tidak boleh kosong.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        ' Validasi No. HP Kosong
        If TextBoxNoHPIdentitas.Text.Length = 0 Then
            MsgBox("Nomor HP tidak boleh kosong.", MsgBoxStyle.Critical, "Warning!")
            Return False
        End If

        ' Validasi Tanggal Lahir Kosong
        If DateTimePickerTglLahir.Value = DateSerial("9998", "12", "31") Then
            MsgBox("Tanggal lahir tidak boleh kosong.", MsgBoxStyle.Critical, "Warning!")
            Return False
        End If

        ' Cek Email
        If TextBoxEmailIdentitas.Text.Length <> 0 Then
            If validateEmail(TextBoxEmailIdentitas.Text) = False Then
                MsgBox("Perhatikan penulisan email dengan benar.", MsgBoxStyle.Exclamation, "Warning!")
                Return False
            End If
        End If

        ' Cek Foto Pasien
        'If PictureBoxFotoPasien.Tag Is Nothing Then
        '    MessageBox.Show("Silakan upload gambar terlebih dahulu.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Exit Function
        'End If

        ' Cek No WhatsApp
        If TextBoxNoHPIdentitas.Text.Length <> 0 Then
            If validateNoWhatsapp(TextBoxNoHPIdentitas.Text) = False Then
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub CheckBoxCopyAlamatDomisili_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxCopyAlamatDomisili.CheckedChanged
        If CheckBoxCopyAlamatDomisili.Checked = True Then
            If TextBoxAlamatDomisili.Text <> "" Then TextBoxAlamatKTP.Text = TextBoxAlamatDomisili.Text
            ComboBoxProvinsiKTP.Text = ComboBoxProvinsiDomisili.Text
            ComboBoxKabupatenKTP.Text = ComboBoxKabupatenDomisili.Text
            ComboBoxKecamatanKTP.Text = ComboBoxKecamatanDomisili.Text
            ComboBoxKelurahanKTP.Text = ComboBoxKelurahanDomisili.Text
            TextBoxRTKTP.Text = TextBoxRTDomisili.Text
            TextBoxRWKTP.Text = TextBoxRWDomisili.Text
            TextBoxKodePosKTP.Text = TextBoxKodePosDomisili.Text
        ElseIf CheckBoxCopyAlamatDomisili.Checked = False Then
            TextBoxAlamatKTP.ResetText()
            TextBoxRTKTP.ResetText()
            TextBoxRWKTP.ResetText()
            ComboBoxKelurahanKTP.ResetText()
            ComboBoxKecamatanKTP.ResetText()
            ComboBoxKabupatenKTP.ResetText()
            ComboBoxProvinsiKTP.ResetText()
            TextBoxKodePosKTP.ResetText()
        End If
    End Sub

    Private Sub SaveData(ByRef jenisProses As String)
        If CheckInput() = True Then
            ' Inisialisasi semua variabel
            Dim noRekamMedis As String = ""
            Dim noDokumenRekamMedis As String = TextBoxNoDokumenRM.Text.Trim()

            ' Generate NIK
            Dim noNIK As String = ""
            If CheckBoxStatusNIK.Checked = False Or TextBoxNomorNIK.Text <> "" Then
                noNIK = TextBoxNomorNIK.Text.Trim()
            Else
                noNIK = generateNomorNIK()
            End If

            ' Status NIK Sementara
            Dim statusNIK As Boolean = False

            Dim noNIP As String = TextBoxNomorNIP.Text.Trim()
            Dim noKartuBPJS As String = TextBoxNomorKIS.Text.Trim()
            Dim noInhealth As String = TextBoxNomorInhealth.Text.Trim()
            Dim noJPK As String = TextBoxNomorJPK.Text.Trim()
            Dim noCahaya As String = TextBoxNomorCahaya.Text.Trim()
            Dim namaPasien As String = TextBoxNamaLengkapIdentitas.Text.Trim()
            Dim tempatLahirPasien As String = TextBoxTempatLahir.Text.Trim()
            Dim tglLahirPasien As String = Format(DateTimePickerTglLahir.Value, "MM/dd/yyyy")
            Dim jenisKelaminPasien As String = ""

            If RadioButtonJenisKelaminLakiIdentitas.Checked = True Then
                jenisKelaminPasien = "L"
            ElseIf RadioButtonJenisKelaminPerempuanIdentitas.Checked = True Then
                jenisKelaminPasien = "P"
            End If

            Dim golDarahPasien As String = ComboBoxGolDarahIdentitas.Text.Trim()

            Dim domisiliAlamat As String = TextBoxAlamatDomisili.Text.Trim()
            Dim domisiliProvinsi As String = ComboBoxProvinsiDomisili.Text.Trim()
            Dim domisiliKabupaten As String = ComboBoxKabupatenDomisili.Text.Trim()
            Dim domisiliKecamatan As String = ComboBoxKecamatanDomisili.Text.Trim()
            Dim domisiliKelurahan As String = ComboBoxKelurahanDomisili.Text.Trim()
            Dim domisiliRT As String = TextBoxRTDomisili.Text.Trim()
            Dim domisiliRW As String = TextBoxRWDomisili.Text.Trim()
            Dim domisiliKodePos As String = TextBoxKodePosDomisili.Text.Trim()

            Dim ktpAlamat As String = TextBoxAlamatKTP.Text.Trim()
            Dim ktpProvinsi As String = ComboBoxProvinsiKTP.Text.Trim()
            Dim ktpKabupaten As String = ComboBoxKabupatenKTP.Text.Trim()
            Dim ktpKecamatan As String = ComboBoxKecamatanKTP.Text.Trim()
            Dim ktpKelurahan As String = ComboBoxKelurahanKTP.Text.Trim()
            Dim ktpRT As String = TextBoxRTKTP.Text.Trim()
            Dim ktpRW As String = TextBoxRWKTP.Text.Trim()
            Dim ktpKodePos As String = TextBoxKodePosKTP.Text.Trim()

            Dim noTelepon As String = TextBoxNoTeleponIdentitas.Text.Trim()
            Dim noHandphone As String = TextBoxNoHPIdentitas.Text.Trim()
            Dim email As String = TextBoxEmailIdentitas.Text.Trim()
            Dim pendidikanTerakhir As String = ComboBoxPendidikanTerakhir.Text.Trim()
            Dim statusPerkawinan As String = ComboBoxStatusPerkawinan.Text.Trim()
            Dim agama As String = ComboBoxAgama.Text.Trim()
            Dim kewarganegaraan As String = ""
            Dim kewarganegaraanKeterangan As String = ""

            If RadioButtonWNI.Checked = True Then
                kewarganegaraan = "WNI"
            ElseIf RadioButtonWNA.Checked = True Then
                kewarganegaraan = "WNA"
                kewarganegaraanKeterangan = TextBoxKetWNA.Text.Trim()
            End If

            Dim statusKeluarga As String = ComboBoxStatusKeluarga.Text.Trim()
            Dim pekerjaan As String = TextBoxPekerjaan.Text.Trim()

            Dim kontakDaruratNama As String = TextBoxNamaLengkapKontakDarurat.Text.Trim()
            Dim kontakDaruratAlamat As String = TextBoxAlamatKontakDarurat.Text.Trim()
            Dim kontakDaruratNoTelepon As String = TextBoxHPKontakDarurat.Text.Trim()

            'Dim alergiObat As String = TextBoxAlergiObat.Text.Trim()
            'Dim alergiMakanan As String = TextBoxAlergiMakanan.Text.Trim()
            'Dim alergiLainnya As String = TextBoxAlergiLainnya.Text.Trim()

            Dim riwayatPenyakitDahulu As String = TextBoxRiwayatPenyakitDahulu.Text.Trim()
            Dim riwayatPenyakitKeluarga As String = TextBoxRiwayatPenyakitKeluarga.Text.Trim()
            Dim riwayatKebiasaan As String = TextBoxRiwayatKebiasaan.Text.Trim()

            ' IHS Number
            Dim noIHS As String = ""
            If IsPlaceholder(TextBoxNomorIHS) = False Then noIHS = TextBoxNomorIHS.Text

            Dim queryUpdate As String = ""

            Dim fotoPath As String = ""
            Dim folderPath As String = Application.StartupPath & "\Uploads\FotoPasien"

            If PictureBoxFotoPasien.Tag IsNot Nothing AndAlso PictureBoxFotoPasien.Tag.ToString().Trim() <> "" Then
                If Not IO.Directory.Exists(folderPath) Then
                    IO.Directory.CreateDirectory(folderPath)
                End If

                ' Simpan gambar ke folder dan buat nama unik
                Dim ekstensi As String = IO.Path.GetExtension(PictureBoxFotoPasien.Tag.ToString())
                Dim namaFileUnik As String = Guid.NewGuid().ToString() & ekstensi
                Dim targetPath As String = IO.Path.Combine(folderPath, namaFileUnik)

                IO.File.Copy(PictureBoxFotoPasien.Tag.ToString(), targetPath, True)

                fotoPath = "Uploads\FotoPasien\" & namaFileUnik
            End If

            If jenisProses = "CREATE" Then
                noRekamMedis = generateNomorRekamMedis()

                ' Input ke dalam tabel master pasien
                Dim query As String = "INSERT INTO MasterPasien (noRekamMedis, NoDokumenRekamMedis, NoIHS, NoNIK, NoNIP, NoKartuBPJS, NoKartuInhealth, NoKartuJPK, NoKartuCahaya, Nama, TempatLahir, TglLahir, JenisKelamin, GolonganDarah, DomisiliAlamat, DomisiliRT, DomisiliRW, DomisiliKelurahan, DomisiliKecamatan, DomisiliKabupaten, DomisiliProvinsi, DomisiliKodePos, KtpAlamat, KtpRT, KtpRW, KtpKelurahan, KtpKecamatan, KtpKabupaten, KtpProvinsi, KtpKodePos, NoTelepon, NoHandphone, Email, PendidikanTerakhir, StatusPerkawinan, Agama, Kewarganegaraan, KeteranganKewarganegaraanAsing, StatusKeluarga, Pekerjaan, KontakDaruratNama, KontakDaruratAlamat, KontakDaruratNoTelepon, RiwayatPenyakitDahulu, RiwayatPenyakitKeluarga, RiwayatKebiasaan, PasienTanpaNIK, CreatedBy, CreatedDate, FotoPath) " & _
                                      "VALUES (@noRekamMedis, @noDokumenRekamMedis, @noIHS, @noNIK, @noNIP, @noKartuBPJS, @noInhealth, @noJPK, @noCahaya, @namaPasien, @tempatLahirPasien, @tglLahirPasien, @jenisKelaminPasien, @golDarahPasien, @domisiliAlamat, @domisiliRT, @domisiliRW, @domisiliKelurahan, @domisiliKecamatan, @domisiliKabupaten, @domisiliProvinsi, @domisiliKodePos, @ktpAlamat, @ktpRT, @ktpRW, @ktpKelurahan, @ktpKecamatan, @ktpKabupaten, @ktpProvinsi, @ktpKodePos, @noTelepon, @noHandphone, @email, @pendidikanTerakhir, @statusPerkawinan, @agama, @kewarganegaraan, @kewarganegaraanKeterangan, @statusKeluarga, @pekerjaan, @kontakDaruratNama, @kontakDaruratAlamat, @kontakDaruratNoTelepon, @riwayatPenyakitDahulu, @riwayatPenyakitKeluarga, @riwayatKebiasaan, " & Convert.ToInt32(CheckBoxStatusNIK.Checked) & ", @userInput, GETDATE(), @fotoPath)"

                ' Memanggil fungsi WriteParameterizedSQL untuk eksekusi query
                WriteParameterizedLokalSQL(query, 4, _
                     New SqlParameter("@noRekamMedis", noRekamMedis), _
                     New SqlParameter("@noDokumenRekamMedis", noDokumenRekamMedis), _
                     New SqlParameter("@noIHS", noIHS), _
                     New SqlParameter("@noNIK", noNIK), _
                     New SqlParameter("@noNIP", noNIP), _
                     New SqlParameter("@noKartuBPJS", noKartuBPJS), _
                     New SqlParameter("@noInhealth", noInhealth), _
                     New SqlParameter("@noJPK", noJPK), _
                     New SqlParameter("@noCahaya", noCahaya), _
                     New SqlParameter("@namaPasien", namaPasien), _
                     New SqlParameter("@tempatLahirPasien", tempatLahirPasien), _
                     New SqlParameter("@tglLahirPasien", tglLahirPasien), _
                     New SqlParameter("@jenisKelaminPasien", jenisKelaminPasien), _
                     New SqlParameter("@golDarahPasien", golDarahPasien), _
                     New SqlParameter("@domisiliAlamat", domisiliAlamat), _
                     New SqlParameter("@domisiliRT", domisiliRT), _
                     New SqlParameter("@domisiliRW", domisiliRW), _
                     New SqlParameter("@domisiliKelurahan", domisiliKelurahan), _
                     New SqlParameter("@domisiliKecamatan", domisiliKecamatan), _
                     New SqlParameter("@domisiliKabupaten", domisiliKabupaten), _
                     New SqlParameter("@domisiliProvinsi", domisiliProvinsi), _
                     New SqlParameter("@domisiliKodePos", domisiliKodePos), _
                     New SqlParameter("@ktpAlamat", ktpAlamat), _
                     New SqlParameter("@ktpRT", ktpRT), _
                     New SqlParameter("@ktpRW", ktpRW), _
                     New SqlParameter("@ktpKelurahan", ktpKelurahan), _
                     New SqlParameter("@ktpKecamatan", ktpKecamatan), _
                     New SqlParameter("@ktpKabupaten", ktpKabupaten), _
                     New SqlParameter("@ktpProvinsi", ktpProvinsi), _
                     New SqlParameter("@ktpKodePos", ktpKodePos), _
                     New SqlParameter("@noTelepon", noTelepon), _
                     New SqlParameter("@noHandphone", noHandphone), _
                     New SqlParameter("@email", email), _
                     New SqlParameter("@pendidikanTerakhir", pendidikanTerakhir), _
                     New SqlParameter("@statusPerkawinan", statusPerkawinan), _
                     New SqlParameter("@agama", agama), _
                     New SqlParameter("@kewarganegaraan", kewarganegaraan), _
                     New SqlParameter("@kewarganegaraanKeterangan", kewarganegaraanKeterangan), _
                     New SqlParameter("@statusKeluarga", statusKeluarga), _
                     New SqlParameter("@pekerjaan", pekerjaan), _
                     New SqlParameter("@kontakDaruratNama", kontakDaruratNama), _
                     New SqlParameter("@kontakDaruratAlamat", kontakDaruratAlamat), _
                     New SqlParameter("@kontakDaruratNoTelepon", kontakDaruratNoTelepon), _
                     New SqlParameter("@riwayatPenyakitDahulu", riwayatPenyakitDahulu), _
                     New SqlParameter("@riwayatPenyakitKeluarga", riwayatPenyakitKeluarga), _
                     New SqlParameter("@riwayatKebiasaan", riwayatKebiasaan), _
                     New SqlParameter("@userInput", userInput), _
                     New SqlParameter("@fotoPath", fotoPath))

                ' Insert ke dalam tabel general consent jika ada
                If LabelSignatureDate.Text <> "-" Then
                    ' Set Jenis Kelamin
                    Dim jenisKelaminGC As String = ""
                    If RadioButtonJenisKelaminLakiGC.Checked = True Then
                        jenisKelaminGC = "L"
                    ElseIf RadioButtonJenisKelaminPerempuanGC.Checked = True Then
                        jenisKelaminGC = "P"
                    End If

                    ' Set Signature
                    Dim sigantureDate As DateTime = DateTime.Parse(LabelSignatureDate.Text)
                    Dim image As Image = PictureBoxSignatureGC.Image
                    Dim imageData As Byte()
                    Using ms As New MemoryStream()
                        image.Save(ms, ImageFormat.Jpeg) ' Ganti ImageFormat dengan format gambar yang sesuai
                        imageData = ms.ToArray()
                    End Using
                    Dim signatureBase64 As String = Convert.ToBase64String(imageData)

                    WriteSQL("INSERT INTO GeneralConsent (noRekamMedis, NoNIK, HubunganKeluarga, Nama, TglLahir, JenisKelamin, TempatLahir, Alamat, NoTelepon, SignaturePasien, SignatureDate, CreatedBy, CreatedDate) " & _
                         "VALUES('" & noRekamMedis & "', '" & noNIK & "', '" & TextBoxHubunganKeluargaGC.Text & "', '" & TextBoxNamaGC.Text & "', '" & Format(DateTimePickerTglLahirGC.Value, "MM/dd/yyyy") & "', '" & jenisKelaminGC & "', " & _
                         "'" & TextBoxTempatLahirGC.Text & "', '" & TextBoxAlamatGC.Text & "', '" & TextBoxNoTeleponGC.Text & "', '" & signatureBase64 & "','" & sigantureDate & "','" & userInput & "', GETDATE())", 4)
                End If

                ' Input ke dalam tabel master pasien detail BPJS
                If noKartuBPJS.Length <> 0 AndAlso CheckBridgingPcareActive() = True Then
                    InsertDataBPJS(noKartuBPJS, "CREATE")
                End If

                ClearData()

                MsgBox("Berhasil menyimpan data dengan no rekam medis : " & noRekamMedis & ".", MsgBoxStyle.Information, "Success!")
            ElseIf jenisProses = "UPDATE" Then
                noRekamMedis = TextBoxNoRM.Text

                queryUpdate = "UPDATE MasterPasien SET " & _
                                  "NoDokumenRekamMedis = @noDokumenRekamMedis, " & _
                                  "NoNIK = @noNIK, " & _
                                  "NoIHS = @noIHS, " & _
                                  "NoNIP = @noNIP, " & _
                                  "NoKartuBPJS = @noKartuBPJS, " & _
                                  "NoKartuInhealth = @noInhealth, " & _
                                  "NoKartuJPK = @noJPK, " & _
                                  "NoKartuCahaya = @noCahaya, " & _
                                  "Nama = @namaPasien, " & _
                                  "TempatLahir = @tempatLahirPasien, " & _
                                  "TglLahir = @tglLahirPasien, " & _
                                  "JenisKelamin = @jenisKelaminPasien, " & _
                                  "GolonganDarah = @golDarahPasien, " & _
                                  "DomisiliAlamat = @domisiliAlamat, " & _
                                  "DomisiliRT = @domisiliRT, " & _
                                  "DomisiliRW = @domisiliRW, " & _
                                  "DomisiliKelurahan = @domisiliKelurahan, " & _
                                  "DomisiliKecamatan = @domisiliKecamatan, " & _
                                  "DomisiliKabupaten = @domisiliKabupaten, " & _
                                  "DomisiliProvinsi = @domisiliProvinsi, " & _
                                  "DomisiliKodePos = @domisiliKodePos, " & _
                                  "KtpAlamat = @ktpAlamat, " & _
                                  "KtpRT = @ktpRT, " & _
                                  "KtpRW = @ktpRW, " & _
                                  "KtpKelurahan = @ktpKelurahan, " & _
                                  "KtpKecamatan = @ktpKecamatan, " & _
                                  "KtpKabupaten = @ktpKabupaten, " & _
                                  "KtpProvinsi = @ktpProvinsi, " & _
                                  "KtpKodePos = @ktpKodePos, " & _
                                  "NoTelepon = @noTelepon, " & _
                                  "NoHandphone = @noHandphone, " & _
                                  "Email = @email, " & _
                                  "PendidikanTerakhir = @pendidikanTerakhir, " & _
                                  "StatusPerkawinan = @statusPerkawinan, " & _
                                  "Agama = @agama, " & _
                                  "Kewarganegaraan = @kewarganegaraan, " & _
                                  "KeteranganKewarganegaraanAsing = @kewarganegaraanKeterangan, " & _
                                  "StatusKeluarga = @statusKeluarga, " & _
                                  "Pekerjaan = @pekerjaan, " & _
                                  "KontakDaruratNama = @kontakDaruratNama, " & _
                                  "KontakDaruratAlamat = @kontakDaruratAlamat, " & _
                                  "KontakDaruratNoTelepon = @kontakDaruratNoTelepon, " & _
                                  "RiwayatPenyakitDahulu = @riwayatPenyakitDahulu, " & _
                                  "RiwayatPenyakitKeluarga = @riwayatPenyakitKeluarga, " & _
                                  "RiwayatKebiasaan = @riwayatKebiasaan, " & _
                                  "PasienTanpaNIK = " & Convert.ToInt32(CheckBoxStatusNIK.Checked) & ", " & _
                                  "ChangeBy = @userInput, " & _
                                  "ChangeDate = GETDATE(), " & _
                                  "FotoPath = @fotoPath " & _
                                  "WHERE NoRekamMedis = @noRekamMedis"

                WriteParameterizedLokalSQL(queryUpdate, 4, _
                     New SqlParameter("@noRekamMedis", noRekamMedis), _
                     New SqlParameter("@noDokumenRekamMedis", noDokumenRekamMedis), _
                     New SqlParameter("@noIHS", noIHS), _
                     New SqlParameter("@noNIK", noNIK), _
                     New SqlParameter("@noNIP", noNIP), _
                     New SqlParameter("@noKartuBPJS", noKartuBPJS), _
                     New SqlParameter("@noInhealth", noInhealth), _
                     New SqlParameter("@noJPK", noJPK), _
                     New SqlParameter("@noCahaya", noCahaya), _
                     New SqlParameter("@namaPasien", namaPasien), _
                     New SqlParameter("@tempatLahirPasien", tempatLahirPasien), _
                     New SqlParameter("@tglLahirPasien", tglLahirPasien), _
                     New SqlParameter("@jenisKelaminPasien", jenisKelaminPasien), _
                     New SqlParameter("@golDarahPasien", golDarahPasien), _
                     New SqlParameter("@domisiliAlamat", domisiliAlamat), _
                     New SqlParameter("@domisiliRT", domisiliRT), _
                     New SqlParameter("@domisiliRW", domisiliRW), _
                     New SqlParameter("@domisiliKelurahan", domisiliKelurahan), _
                     New SqlParameter("@domisiliKecamatan", domisiliKecamatan), _
                     New SqlParameter("@domisiliKabupaten", domisiliKabupaten), _
                     New SqlParameter("@domisiliProvinsi", domisiliProvinsi), _
                     New SqlParameter("@domisiliKodePos", domisiliKodePos), _
                     New SqlParameter("@ktpAlamat", ktpAlamat), _
                     New SqlParameter("@ktpRT", ktpRT), _
                     New SqlParameter("@ktpRW", ktpRW), _
                     New SqlParameter("@ktpKelurahan", ktpKelurahan), _
                     New SqlParameter("@ktpKecamatan", ktpKecamatan), _
                     New SqlParameter("@ktpKabupaten", ktpKabupaten), _
                     New SqlParameter("@ktpProvinsi", ktpProvinsi), _
                     New SqlParameter("@ktpKodePos", ktpKodePos), _
                     New SqlParameter("@noTelepon", noTelepon), _
                     New SqlParameter("@noHandphone", noHandphone), _
                     New SqlParameter("@email", email), _
                     New SqlParameter("@pendidikanTerakhir", pendidikanTerakhir), _
                     New SqlParameter("@statusPerkawinan", statusPerkawinan), _
                     New SqlParameter("@agama", agama), _
                     New SqlParameter("@kewarganegaraan", kewarganegaraan), _
                     New SqlParameter("@kewarganegaraanKeterangan", kewarganegaraanKeterangan), _
                     New SqlParameter("@statusKeluarga", statusKeluarga), _
                     New SqlParameter("@pekerjaan", pekerjaan), _
                     New SqlParameter("@kontakDaruratNama", kontakDaruratNama), _
                     New SqlParameter("@kontakDaruratAlamat", kontakDaruratAlamat), _
                     New SqlParameter("@kontakDaruratNoTelepon", kontakDaruratNoTelepon), _
                     New SqlParameter("@riwayatPenyakitDahulu", riwayatPenyakitDahulu), _
                     New SqlParameter("@riwayatPenyakitKeluarga", riwayatPenyakitKeluarga), _
                     New SqlParameter("@riwayatKebiasaan", riwayatKebiasaan), _
                     New SqlParameter("@userInput", userInput), _
                     New SqlParameter("@fotoPath", fotoPath))

                ' Input/Create ke dalam tabel MasterPasienBPJS
                If noKartuBPJS.Length <> 0 AndAlso CheckBridgingPcareActive() = True Then
                    If CheckSQL("SELECT * FROM MasterPasienBPJS WHERE NoKartu = '" & noKartuBPJS & "'") = False Then
                        InsertDataBPJS(noKartuBPJS, "CREATE")
                    Else
                        InsertDataBPJS(noKartuBPJS, "UPDATE")
                    End If
                End If

                ClearData()

                MsgBox("Berhasil mengubah data.", MsgBoxStyle.Information, "Success!")
            End If
        End If
    End Sub

    Private Sub GetDataFromOnline()
        ClearData()

        Dim TdataQR As String = InputBox("Masukkan QR Code", "Scan Barcode QR")

        Dim baseURL As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'web_service_klinik'")
        Dim urlWebService As String = baseURL & "api/informed_consent/" & TdataQR

        'Dim response As String = GetDataAPI("http://localhost:8000/api/informed_consent/3515112306960003")
        Dim response As String = GetDataAPI(urlWebService)

        ' Deserialize JSON response
        Dim dataJson As JObject = JObject.Parse(response)

        ' Akses nilai di dalam kunci 'data'
        'Dim dataPasien As JObject = dataJson("data")
        'Dim generalConsent As JObject = dataPasien("generalconsent")

        'Dim Tbls As DataTable = ReadThemysql("SELECT * FROM masterpasien a WHERE a.qr_code = '" & TdataQR & "'", DB_PendaftaranOnline)
        'Dim Tbls As DataTable = ReadThemysql("SELECT a.*, b.nama_penanggung_jawab, b.tgl_lahir_penanggung_jawab, b.jenis_kelamin_penanggung_jawab, b.tempat_lahir_penanggung_jawab, b.alamat_penanggung_jawab, b.no_telepon_penanggung_jawab, b.hubungan_penanggung_jawab, b.signed_penanggung_jawab " & _
        '                                     "FROM masterpasien a " & _
        '                                     "LEFT JOIN general_consents b ON a.no_nik = b.no_nik " & _
        '                                     "WHERE a.qr_code = '" & TdataQR & "'", DB_PendaftaranOnline)

        If dataJson("data").ToString <> "" Then
            Dim dataPasien As JObject = dataJson("data")
            Dim generalConsent As JObject = dataPasien("generalconsent")

            ' Load Biodata Diri
            ' Cek BPJS / Non BPJS
            If dataPasien("no_bpjs").ToString <> "" Then
                GetDataPesertaBPJS(dataPasien("no_bpjs").ToString, "NoKartuBPJS")
            Else
                ' Non BPJS
                TextBoxNamaLengkapIdentitas.Text = dataPasien("nama").ToString

                If dataPasien("jenis_kelamin") = "L" Then RadioButtonJenisKelaminLakiIdentitas.Checked = True
                If dataPasien("jenis_kelamin") = "P" Then RadioButtonJenisKelaminPerempuanIdentitas.Checked = True

                DateTimePickerTglLahir.Value = DateTime.ParseExact(dataPasien("tgl_lahir"), "yyyy-MM-dd", Nothing)
                TextBoxNoHPIdentitas.Text = dataPasien("no_telepon").ToString
                TextBoxPekerjaan.Text = dataPasien("pekerjaan").ToString
            End If

            TextBoxNomorNIK.Text = dataPasien("no_nik").ToString
            TextBoxTempatLahir.Text = dataPasien("tempat_lahir").ToString
            TextBoxAlamatKTP.Text = dataPasien("alamat_ktp").ToString
            TextBoxAlamatDomisili.Text = dataPasien("alamat_domisili").ToString
            TextBoxEmailIdentitas.Text = dataPasien("email").ToString
            ComboBoxStatusKeluarga.Text = dataPasien("status").ToString
            ComboBoxAgama.Text = dataPasien("agama").ToString
            ComboBoxGolDarahIdentitas.Text = dataPasien("golongan_darah").ToString

            ' Load Alergi
            'TextBoxAlergiObat.Text = dataPasien("alergi_obat").ToString
            'TextBoxAlergiMakanan.Text = dataPasien("alergi_makanan").ToString
            'TextBoxAlergiLainnya.Text = dataPasien("alergi_lainnya").ToString

            ' Load Riwayat Penyakit
            TextBoxRiwayatPenyakitDahulu.Text = dataPasien("riwayat_penyakit_dahulu").ToString
            TextBoxRiwayatPenyakitKeluarga.Text = dataPasien("riwayat_penyakit_keluarga").ToString
            TextBoxRiwayatKebiasaan.Text = dataPasien("riwayat_kebiasaan").ToString

            ' Load General Consent
            TextBoxHubunganKeluargaGC.Text = generalConsent("hubungan_penanggung_jawab").ToString
            TextBoxNamaGC.Text = generalConsent("nama_penanggung_jawab").ToString
            DateTimePickerTglLahirGC.Value = DateTime.ParseExact(generalConsent("tgl_lahir_penanggung_jawab"), "yyyy-MM-dd", Nothing)
            If generalConsent("jenis_kelamin_penanggung_jawab") = "L" Then RadioButtonJenisKelaminLakiGC.Checked = True
            If generalConsent("jenis_kelamin_penanggung_jawab") = "P" Then RadioButtonJenisKelaminPerempuanGC.Checked = True
            TextBoxTempatLahirGC.Text = generalConsent("tempat_lahir_penanggung_jawab").ToString
            TextBoxAlamatGC.Text = generalConsent("alamat_penanggung_jawab").ToString
            TextBoxNoTeleponGC.Text = generalConsent("no_telepon_penanggung_jawab").ToString
            LabelSignatureDate.Text = generalConsent("created_at").ToString

            ' Load TTD General Consent
            Dim signedPenanggungJawabBytes As Byte() = Convert.FromBase64String(generalConsent("signed_penanggung_jawab").ToString)
            Dim memoryStream As New MemoryStream(signedPenanggungJawabBytes)
            PictureBoxSignatureGC.Image = image.FromStream(memoryStream)

            ' Load Data Wali Pasien
            If generalConsent("hubungan_penanggung_jawab").ToString <> "diri saya sendiri" Then
                CheckBoxStatusWaliPasien.Checked = True

                TextBoxNamaLengkapWali.Text = generalConsent("nama_penanggung_jawab").ToString
                DateTimePickerTglLahirWali.Value = DateTime.ParseExact(generalConsent("tgl_lahir_penanggung_jawab"), "yyyy-MM-dd", Nothing)
                If generalConsent("jenis_kelamin_penanggung_jawab") = "L" Then RadioButtonJenisKelaminLakiWali.Checked = True
                If generalConsent("jenis_kelamin_penanggung_jawab") = "P" Then RadioButtonJenisKelaminPerempuanWali.Checked = True
                TextBoxTempatLahirWali.Text = generalConsent("tempat_lahir_penanggung_jawab").ToString
                TextBoxAlamatDomisiliWali.Text = generalConsent("alamat_penanggung_jawab").ToString
                TextBoxNoHPWali.Text = generalConsent("no_telepon_penanggung_jawab").ToString
                TextBoxHubunganKeluargaWali.Text = generalConsent("hubungan_penanggung_jawab").ToString
            End If
        Else
            MsgBox("Data tidak ditemukan.", MsgBoxStyle.Exclamation, "Warning!")
        End If
    End Sub

    Private Sub ClearData()
        ' Set Clear NIK
        TextBoxNomorNIK.ResetText()
        TextBoxNomorNIK.Enabled = True
        TextBoxNomorNIK.ReadOnly = False
        TextBoxNomorNIK.BackColor = Color.White
        CheckBoxStatusNIK.Checked = False

        ' Set Clear KIS
        TextBoxNomorKIS.ResetText()
        TextBoxNomorKIS.Enabled = True
        TextBoxNomorKIS.ReadOnly = False
        TextBoxNomorKIS.BackColor = Color.White

        ' Set Clear
        TextBoxNoRM.ResetText()
        TextBoxNoDokumenRM.ResetText()
        TextBoxNomorIHS.ResetText()
        TextBoxFaskesAktif.ResetText()
        TextBoxStatusAktif.ResetText()
        TextBoxProlanis.ResetText()
        TextBoxPRB.ResetText()
        TextBoxStatusPeserta.ResetText()
        TextBoxFKTP.ResetText()
        TextBoxNamaLengkapIdentitas.ResetText()
        TextBoxTempatLahir.ResetText()
        DateTimePickerTglLahir.Value = DateSerial("9998", "12", "31")
        RadioButtonJenisKelaminLakiIdentitas.Checked = True
        ComboBoxGolDarahIdentitas.Text = "-"
        ComboBoxStatusKeluarga.Text = "-"
        TextBoxPekerjaan.ResetText()
        TextBoxNomorNIP.ResetText()
        TextBoxNomorInhealth.ResetText()
        TextBoxNomorJPK.ResetText()
        TextBoxNomorCahaya.ResetText()
        TextBoxAlamatKTP.ResetText()
        TextBoxRTKTP.ResetText()
        TextBoxRWKTP.ResetText()
        ComboBoxKelurahanKTP.ResetText()
        ComboBoxKecamatanKTP.ResetText()
        ComboBoxKabupatenKTP.ResetText()
        ComboBoxProvinsiKTP.ResetText()
        TextBoxKodePosKTP.ResetText()
        TextBoxNoRM.ResetText()
        TextBoxNoRM.ResetText()
        TextBoxNoRM.ResetText()
        CheckBoxCopyAlamatDomisili.Checked = False
        TextBoxAlamatDomisili.ResetText()
        TextBoxRTDomisili.ResetText()
        TextBoxRWDomisili.ResetText()
        ComboBoxKelurahanDomisili.ResetText()
        ComboBoxKecamatanDomisili.ResetText()
        ComboBoxKabupatenDomisili.ResetText()
        ComboBoxProvinsiDomisili.ResetText()
        TextBoxKodePosDomisili.ResetText()
        TextBoxNoHPIdentitas.ResetText()
        TextBoxNoTeleponIdentitas.ResetText()
        TextBoxEmailIdentitas.ResetText()
        ComboBoxStatusPerkawinan.Text = "-"
        ComboBoxPendidikanTerakhir.Text = "-"
        ComboBoxAgama.Text = "-"
        RadioButtonWNI.Checked = True
        TextBoxKetWNA.ResetText()

        ' Kontak Darurat
        TextBoxNamaLengkapKontakDarurat.ResetText()
        TextBoxAlamatKontakDarurat.ResetText()
        TextBoxHPKontakDarurat.ResetText()

        ' Riwayat Alergi & Penyakit
        GridViewAlergi.Columns.Clear()
        TextBoxRiwayatPenyakitDahulu.ResetText()
        TextBoxRiwayatPenyakitKeluarga.ResetText()
        TextBoxRiwayatKebiasaan.ResetText()

        ' Informasi Wali
        CheckBoxStatusWaliPasien.Checked = False
        TextBoxNamaLengkapWali.ResetText()
        TextBoxTempatLahirWali.ResetText()
        TextBoxAlamatDomisiliWali.ResetText()
        TextBoxNoHPWali.ResetText()
        TextBoxHubunganKeluargaWali.ResetText()

        ' Set Enable / Disable
        TextBoxNamaLengkapIdentitas.ReadOnly = False
        PanelJenisKelaminPasien.Enabled = True
        DateTimePickerTglLahir.Enabled = True

        ' Set Disable Informasi Wali
        DateTimePickerTglLahirWali.Enabled = False
        TextBoxNamaLengkapWali.Enabled = False
        PanelJenisKelaminWali.Enabled = False
        TextBoxTempatLahirWali.Enabled = False
        TextBoxAlamatDomisiliWali.Enabled = False
        TextBoxNoHPWali.Enabled = False
        TextBoxHubunganKeluargaWali.Enabled = False

        ' Set Disable General Consent
        TextBoxHubunganKeluargaGC.ReadOnly = True
        TextBoxNamaGC.ReadOnly = True
        DateTimePickerTglLahirGC.Enabled = False
        PanelJenisKelaminGC.Enabled = False
        TextBoxTempatLahirGC.ReadOnly = True
        TextBoxAlamatGC.ReadOnly = True
        TextBoxNoTeleponGC.ReadOnly = True

        ' Clear General Consent
        TextBoxHubunganKeluargaGC.ResetText()
        TextBoxNamaGC.ResetText()
        TextBoxTempatLahirGC.ResetText()
        TextBoxAlamatGC.ResetText()
        TextBoxNoTeleponGC.ResetText()
        PictureBoxSignatureGC.Image = Nothing
        LabelSignatureDate.Text = "-"

        'Foto Pasien
        Dim defaultFotoPath As String = Application.StartupPath & "\Uploads\BlankProfile.png"
        PictureBoxFotoPasien.Image = Image.FromFile(defaultFotoPath)
        PictureBoxFotoPasien.SizeMode = PictureBoxSizeMode.Zoom

        ' Load Placeholder
        SetPlaceholder()
    End Sub

    Public Sub LoadPasien(ByRef rowPasien As DataRowView)
        ClearData() ' Clear Data

        ' Load data dari tabel MasterPasien
        Dim Tbls As DataTable = ReadSQL("SELECT * FROM MasterPasien a LEFT JOIN MasterPasienBPJS b ON a.NoKartuBPJS = b.NoKartu WHERE NoRekamMedis = '" & rowPasien("RM").ToString & "'")
        Dim Trow As DataRow = Tbls.Rows(0)

        ' Set Status NIK Sementara
        If Trow("PasienTanpaNIK") = True Then
            CheckBoxStatusNIK.Checked = True
        Else
            CheckBoxStatusNIK.Checked = False
        End If

        ' Insert data ke textbox
        If IsDBNull(Trow("NoRekamMedis")) = False Then TextBoxNoRM.Text = Trow("NoRekamMedis")
        If IsDBNull(Trow("NoNIK")) = False Then TextBoxNomorNIK.Text = Trow("NoNIK")
        If IsDBNull(Trow("NoNIP")) = False Then TextBoxNomorNIP.Text = Trow("NoNIP")
        If IsDBNull(Trow("NoDokumenRekamMedis")) = False Then TextBoxNoDokumenRM.Text = Trow("NoDokumenRekamMedis")
        If IsDBNull(Trow("NoIHS")) = False Then TextBoxNomorIHS.Text = Trow("NoIHS")
        If IsDBNull(Trow("NoKartuInhealth")) = False Then TextBoxNomorInhealth.Text = Trow("NoKartuInhealth")
        If IsDBNull(Trow("NoKartuJPK")) = False Then TextBoxNomorJPK.Text = Trow("NoKartuJPK")
        If IsDBNull(Trow("NoKartuCahaya")) = False Then TextBoxNomorCahaya.Text = Trow("NoKartuCahaya")
        If IsDBNull(Trow("Nama")) = False Then TextBoxNamaLengkapIdentitas.Text = Trow("Nama")
        If IsDBNull(Trow("Prolanis")) = False Then TextBoxProlanis.Text = Trow("Prolanis")
        If IsDBNull(Trow("PRB")) = False Then TextBoxPRB.Text = Trow("PRB")
        If IsDBNull(Trow("TempatLahir")) = False Then TextBoxTempatLahir.Text = Trow("TempatLahir")
        If IsDBNull(Trow("TglLahir")) = False Then DateTimePickerTglLahir.Text = Trow("TglLahir")

        If Trow("JenisKelamin") = "L" Then
            RadioButtonJenisKelaminLakiIdentitas.Checked = True
        ElseIf Trow("JenisKelamin") = "P" Then
            RadioButtonJenisKelaminPerempuanIdentitas.Checked = True
        End If

        If IsDBNull(Trow("GolonganDarah")) = False Then ComboBoxGolDarahIdentitas.Text = Trow("GolonganDarah")

        If IsDBNull(Trow("DomisiliAlamat")) = False Then TextBoxAlamatDomisili.Text = Trow("DomisiliAlamat")
        If IsDBNull(Trow("DomisiliProvinsi")) = False Then ComboBoxProvinsiDomisili.Text = Trow("DomisiliProvinsi")
        If IsDBNull(Trow("DomisiliKabupaten")) = False Then ComboBoxKabupatenDomisili.Text = Trow("DomisiliKabupaten")
        If IsDBNull(Trow("DomisiliKecamatan")) = False Then ComboBoxKecamatanDomisili.Text = Trow("DomisiliKecamatan")
        If IsDBNull(Trow("DomisiliKelurahan")) = False Then ComboBoxKelurahanDomisili.Text = Trow("DomisiliKelurahan")
        If IsDBNull(Trow("DomisiliRT")) = False Then TextBoxRTDomisili.Text = Trow("DomisiliRT")
        If IsDBNull(Trow("DomisiliRW")) = False Then TextBoxRWDomisili.Text = Trow("DomisiliRW")
        If IsDBNull(Trow("DomisiliKodePos")) = False Then TextBoxKodePosDomisili.Text = Trow("DomisiliKodePos")

        If IsDBNull(Trow("KtpAlamat")) = False Then TextBoxAlamatKTP.Text = Trow("KtpAlamat")
        If IsDBNull(Trow("KtpProvinsi")) = False Then ComboBoxProvinsiKTP.Text = Trow("KtpProvinsi")
        If IsDBNull(Trow("KtpKabupaten")) = False Then ComboBoxKabupatenKTP.Text = Trow("KtpKabupaten")
        If IsDBNull(Trow("KtpKecamatan")) = False Then ComboBoxKecamatanKTP.Text = Trow("KtpKecamatan")
        If IsDBNull(Trow("KtpKelurahan")) = False Then ComboBoxKelurahanKTP.Text = Trow("KtpKelurahan")
        If IsDBNull(Trow("KtpRT")) = False Then TextBoxRTKTP.Text = Trow("KtpRT")
        If IsDBNull(Trow("KtpRW")) = False Then TextBoxRWKTP.Text = Trow("KtpRW")

        If IsDBNull(Trow("KtpKodePos")) = False Then TextBoxKodePosKTP.Text = Trow("KtpKodePos")
        If IsDBNull(Trow("NoHandphone")) = False Then TextBoxNoHPIdentitas.Text = Trow("NoHandphone")
        If IsDBNull(Trow("NoTelepon")) = False Then TextBoxNoTeleponIdentitas.Text = Trow("NoTelepon")
        If IsDBNull(Trow("Email")) = False Then TextBoxEmailIdentitas.Text = Trow("Email")
        If IsDBNull(Trow("PendidikanTerakhir")) = False Then ComboBoxPendidikanTerakhir.Text = Trow("PendidikanTerakhir")
        If IsDBNull(Trow("StatusPerkawinan")) = False Then ComboBoxStatusPerkawinan.Text = Trow("StatusPerkawinan")
        If IsDBNull(Trow("Agama")) = False Then ComboBoxAgama.Text = Trow("Agama")

        If IsDBNull(Trow("Kewarganegaraan")) Then
            RadioButtonWNI.Checked = True
        ElseIf Trow("Kewarganegaraan") = "WNI" Then
            RadioButtonWNI.Checked = True
        ElseIf Trow("Kewarganegaraan") = "WNA" Then
            RadioButtonWNA.Checked = True
            If IsDBNull(Trow("KeteranganKewarganegaraanAsing")) = False Then TextBoxKetWNA.Text = Trow("KeteranganKewarganegaraanAsing")
        End If

        If IsDBNull(Trow("StatusKeluarga")) = False Then ComboBoxStatusKeluarga.Text = Trow("StatusKeluarga")
        If IsDBNull(Trow("Pekerjaan")) = False Then TextBoxPekerjaan.Text = Trow("Pekerjaan")

        ' Kontak darurat
        If IsDBNull(Trow("KontakDaruratNama")) = False Then TextBoxNamaLengkapKontakDarurat.Text = Trow("KontakDaruratNama")
        If IsDBNull(Trow("KontakDaruratAlamat")) = False Then TextBoxAlamatKontakDarurat.Text = Trow("KontakDaruratAlamat")
        If IsDBNull(Trow("KontakDaruratNoTelepon")) = False Then TextBoxHPKontakDarurat.Text = Trow("KontakDaruratNoTelepon")

        ' Alergi
        LoadDataAlergi(Trow("NoRekamMedis"), GridControlAlergi)

        ' Riwayat Penyakit
        If IsDBNull(Trow("RiwayatPenyakitDahulu")) = False Then TextBoxRiwayatPenyakitDahulu.Text = Trow("RiwayatPenyakitDahulu")
        If IsDBNull(Trow("RiwayatPenyakitKeluarga")) = False Then TextBoxRiwayatPenyakitKeluarga.Text = Trow("RiwayatPenyakitKeluarga")
        If IsDBNull(Trow("RiwayatKebiasaan")) = False Then TextBoxRiwayatKebiasaan.Text = Trow("RiwayatKebiasaan")

        ' No BPJS
        If IsDBNull(Trow("NoKartuBPJS")) = False Then TextBoxNomorKIS.Text = Trow("NoKartuBPJS")

        ' Load data BPJS jika ada
        If IsDBNull(Trow("NoKartu")) = False Then
            Dim statusAktif As String = ""
            Dim statusFKTP As Boolean = True

            'TextBoxNomorKIS.Text = Trow("NoKartu")

            If kdProviderLokal <> Trow("KdProviderPst") Then
                statusFKTP = False
            End If

            If statusFKTP = False Then
                statusAktif = Trow("KetAktif") & ", tidak terdaftar di FKTP ini dan rekanan."
                TextBoxFaskesAktif.Text = "Tidak"
            Else
                statusAktif = Trow("KetAktif")
                TextBoxFaskesAktif.Text = "Ya"
            End If

            TextBoxStatusAktif.Text = statusAktif
            TextBoxFKTP.Text = Trow("KdProviderPst") & " ~ " & Trow("NmProviderPst")
            If IsDBNull(Trow("HubunganKeluarga")) = False Then TextBoxStatusPeserta.Text = Trow("HubunganKeluarga")
        Else
            TextBoxFaskesAktif.ResetText()
            TextBoxStatusAktif.ResetText()
            TextBoxFKTP.ResetText()
            TextBoxStatusPeserta.ResetText()
        End If

        ' Set Data Readonly NIK
        If IsDBNull(Trow("NoNIK")) = False AndAlso Trow("NoNIK") <> "" And Trow("NoNIK") <> "-" And Trow("PasienTanpaNIK") = False Then
            TextBoxNomorNIK.Enabled = False
        Else
            TextBoxNomorNIK.Enabled = True
        End If

        ' Set Data Readonly KIS
        If IsDBNull(Trow("NoKartuBPJS")) = False Then
            TextBoxNomorKIS.Enabled = False
        Else
            TextBoxNomorKIS.Enabled = True
        End If

        ' Tampilkan Foto Pasien di PictureBoxFotoPasien
        If IsDBNull(Trow("FotoPath")) = False AndAlso Trow("FotoPath").ToString <> "" Then
            Dim fotoPath As String = Trow("FotoPath").ToString

            If System.IO.File.Exists(fotoPath) Then
                ' Hapus gambar lama dulu kalau ada, untuk menghindari memory lock
                If PictureBoxFotoPasien.Image IsNot Nothing Then
                    PictureBoxFotoPasien.Image.Dispose()
                    PictureBoxFotoPasien.Image = Nothing
                End If

                PictureBoxFotoPasien.Image = Image.FromFile(fotoPath)
                PictureBoxFotoPasien.SizeMode = PictureBoxSizeMode.StretchImage
            Else
                PictureBoxFotoPasien.Image = Nothing
            End If
        Else
            PictureBoxFotoPasien.Image = Nothing
        End If
    End Sub

    Private Sub LoadDataAlergi(ByVal noRekamMedis As String, ByVal dataGridView As DevExpress.XtraGrid.GridControl)
        Dim tblAlergi As DataTable = New DataTable

        tblAlergi = ReadSQL("SELECT AlergiJenis, AlergiNama, Keterangan FROM MasterPasienAlergi WHERE NoRekamMedis = '" & noRekamMedis & "' AND DeletedDate IS NULL ORDER BY AlergiJenis")

        dataGridView.DataSource = tblAlergi
    End Sub

    Private Sub ComboBoxAgama_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ComboBoxAgama.Validating
        If Not IsComboBoxItemValid(DirectCast(sender, System.Windows.Forms.ComboBox)) Then
            MsgBox("Data yang dimasukkan tidak valid. Silakan pilih item dari daftar yang tersedia.", MsgBoxStyle.Exclamation, "Warning!")
            e.Cancel = True
        End If
    End Sub

    Private Sub ComboBoxPendidikanTerakhir_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ComboBoxPendidikanTerakhir.Validating
        If Not IsComboBoxItemValid(DirectCast(sender, System.Windows.Forms.ComboBox)) Then
            MsgBox("Data yang dimasukkan tidak valid. Silakan pilih item dari daftar yang tersedia.", MsgBoxStyle.Exclamation, "Warning!")
            e.Cancel = True
        End If
    End Sub

    Private Sub ComboBoxStatusPerkawinan_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ComboBoxStatusPerkawinan.Validating
        If Not IsComboBoxItemValid(DirectCast(sender, System.Windows.Forms.ComboBox)) Then
            MsgBox("Data yang dimasukkan tidak valid. Silakan pilih item dari daftar yang tersedia.", MsgBoxStyle.Exclamation, "Warning!")
            e.Cancel = True
        End If
    End Sub

    Private Sub ComboBoxStatusKeluarga_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ComboBoxStatusKeluarga.Validating
        If Not IsComboBoxItemValid(DirectCast(sender, System.Windows.Forms.ComboBox)) Then
            MsgBox("Data yang dimasukkan tidak valid. Silakan pilih item dari daftar yang tersedia.", MsgBoxStyle.Exclamation, "Warning!")
            e.Cancel = True
        End If
    End Sub

    Private Sub ComboBoxGolDarahIdentitas_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ComboBoxGolDarahIdentitas.Validating
        If Not IsComboBoxItemValid(DirectCast(sender, System.Windows.Forms.ComboBox)) Then
            MsgBox("Data yang dimasukkan tidak valid. Silakan pilih item dari daftar yang tersedia.", MsgBoxStyle.Exclamation, "Warning!")
            e.Cancel = True
        End If
    End Sub

    Private Sub TextBoxNomorNIK_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxNomorNIK.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub TextBoxNomorKIS_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxNomorKIS.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub TextBoxRTKTP_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxRTKTP.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub TextBoxRWKTP_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxRWKTP.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub TextBoxKodePosKTP_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxKodePosKTP.KeyPress
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

    Private Sub TextBoxTeleponIdentitas_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxNoTeleponIdentitas.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub TextBoxNomorKIS_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBoxNomorKIS.MouseDown
        ' Menonaktifkan opsi Paste pada menu konteks
        'If e.Button = MouseButtons.Right Then
        '    TextBoxNomorKIS.ContextMenu = New ContextMenu()
        'End If
    End Sub

    Private Sub TextBoxNomorNIK_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TextBoxNomorNIK.MouseDown
        ' Menonaktifkan opsi Paste pada menu konteks
        'If e.Button = MouseButtons.Right Then
        '    TextBoxNomorNIK.ContextMenu = New ContextMenu()
        'End If
    End Sub

    Private Sub ButtonSimpanMenu1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSimpanMenu1.Click
        If IsPlaceholder(TextBoxNoRM) = True Then
            SaveData("CREATE")
        Else
            SaveData("UPDATE")
        End If
    End Sub

    Private Sub ButtonClearMenu1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClearMenu1.Click
        ClearData()
    End Sub

    Private Sub ButtonScanQR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonScanQR.Click
        Try
            If IsConnectedToIPAddress("www.google.com") = True Then
                GetDataFromOnline()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim response As String = GetDataAPI("http://localhost:8000/api/informed_consent/3515112306960003")

        ' Deserialize JSON response
        Dim json As JObject = JObject.Parse(response)

        ' Akses nilai di dalam kunci 'data'
        Dim data As JObject = json("data")

        Dim tempatLahir As String = data("tempat_lahir")
        MsgBox(tempatLahir)

        ' Access signed_penanggung_jawab value
        Dim signedPenanggungJawab As String = json.SelectToken("data.generalconsent.signed_penanggung_jawab").ToString()

        ' Convert Base64 string to byte array
        Dim signedPenanggungJawabBytes As Byte() = Convert.FromBase64String(signedPenanggungJawab)

        ' Create MemoryStream from byte array
        Dim memoryStream As New MemoryStream(signedPenanggungJawabBytes)

        ' Display image in PictureBox
        PictureBoxSignatureGC.Image = Image.FromStream(memoryStream)
    End Sub

    Private Sub CheckBoxStatusWaliPasien_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxStatusWaliPasien.CheckedChanged
        ' Clear Data
        TextBoxNamaLengkapWali.ResetText()
        TextBoxTempatLahirWali.ResetText()
        TextBoxAlamatDomisiliWali.ResetText()
        TextBoxNoHPWali.ResetText()
        TextBoxHubunganKeluargaWali.ResetText()

        If CheckBoxStatusWaliPasien.Checked = True Then
            ' Set Enable
            DateTimePickerTglLahirWali.Enabled = True
            TextBoxNamaLengkapWali.Enabled = True
            PanelJenisKelaminWali.Enabled = True
            TextBoxTempatLahirWali.Enabled = True
            TextBoxAlamatDomisiliWali.Enabled = True
            TextBoxNoHPWali.Enabled = True
            TextBoxHubunganKeluargaWali.Enabled = True
        ElseIf CheckBoxStatusWaliPasien.Checked = False Then
            ' Set Disable
            DateTimePickerTglLahirWali.Enabled = False
            TextBoxNamaLengkapWali.Enabled = False
            PanelJenisKelaminWali.Enabled = False
            TextBoxTempatLahirWali.Enabled = False
            TextBoxAlamatDomisiliWali.Enabled = False
            TextBoxNoHPWali.Enabled = False
            TextBoxHubunganKeluargaWali.Enabled = False
        End If
    End Sub

    Private Sub ButtonCetakGeneralConsent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCetakGeneralConsent.Click
        Try
            If IsPlaceholder(TextBoxNoRM) = False Then
                Dim NoRekamMedis As String = TextBoxNoRM.Text

                If NoRekamMedis <> "" Then
                    CetakGeneralConsent(NoRekamMedis)
                Else
                    MsgBox("Pilih No Rekam Medis terlebih dahulu.", MsgBoxStyle.Critical, "Warning!")
                End If
            End If
        Catch ex As Exception
            MsgBox("Data tidak ditemukan.", MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub CetakGeneralConsent(ByVal NoRM As String)
        Try
            Dim tblsGeneralConsent As DataTable = ReadSQL("SELECT MasterPasien.Nama AS 'Nama Pasien', GeneralConsent.* FROM GeneralConsent " & _
                                                          "LEFT JOIN MasterPasien ON GeneralConsent.NoRekamMedis = MasterPasien.NoRekamMedis " & _
                                                          "WHERE GeneralConsent.NoRekamMedis = '" & NoRM & "'")

            If tblsGeneralConsent.Rows.Count > 0 Then
                Dim namaKota As String = ReadSQLNIK("SELECT StrValue FROM  msconfig WHERE configname = 'Kota'")
                Dim generateTglSignature As String = ""
                Dim stringSignature As String = ""

                Dim tblsReport As DataTable = CreateTableGeneralConsent()
                tblsReport.Rows.Clear()

                For Each trow As DataRow In tblsGeneralConsent.Rows
                    Dim rowReport As DataRow = tblsReport.NewRow
                    rowReport("Nama Pasien") = trow("Nama Pasien")
                    rowReport("Nama Penanggung Jawab") = trow("Nama") & " / " & trow("JenisKelamin")

                    Dim generateTglLahir As String = Date.ParseExact(trow("TglLahir").ToString, "M/d/yyyy h:mm:ss tt", Nothing).ToString("dd-MM-yyyy")

                    rowReport("Tempat/tgl lahir") = trow("TempatLahir") & ", " & generateTglLahir
                    rowReport("Alamat") = trow("Alamat")
                    rowReport("No Telepon") = trow("NoTelepon")

                    If trow("HubunganKeluarga") <> "diri saya sendiri" Then
                        rowReport("Bertindak atas") = trow("HubunganKeluarga") & " saya bernama " & trow("Nama Pasien")
                    Else
                        rowReport("Bertindak atas") = "diri saya sendiri"
                    End If

                    generateTglSignature = Date.ParseExact(trow("SignatureDate").ToString, "M/d/yyyy h:mm:ss tt", Nothing).ToString("dd-MM-yyyy")
                    stringSignature = trow("SignaturePasien")

                    rowReport("Tanggal TTD") = namaKota & ", " & generateTglSignature

                    rowReport("Nama Petugas") = trow("Nama")
                    tblsReport.Rows.Add(rowReport)
                Next

                Report = New XtraReport
                Report = XtraReport.FromFile(Application.StartupPath + "\reports\Klinik\RekamMedis\RM_01.repx", True)
                Report.DataSource = tblsReport

                ' Set Image
                ' Convert Base64 string to byte array
                Dim signedPenanggungJawabBytes As Byte() = Convert.FromBase64String(stringSignature)

                ' Create MemoryStream from byte array
                Dim memoryStream As New MemoryStream(signedPenanggungJawabBytes)

                ' Pastikan kode ini berada di bagian yang sesuai, seperti di dalam method InitializeComponent() atau di tempat lain yang sesuai.
                Dim pictureBox As XRPictureBox = CreateXRPictureBox(Image.FromStream(memoryStream), 75, 45, 125, 50)

                ' Akses panel yang sudah ada di dalam band Detail menggunakan index
                Dim panel As XRPanel = CType(Report.Bands(BandKind.Detail).Controls(1), XRPanel)

                ' Cari panel berdasarkan nama di dalam band Detail
                Dim PanelSignaturePasien As XRPanel = TryCast(Report.Bands(BandKind.Detail).Controls("xrPanelSignaturePasien"), XRPanel)

                ' Tambahkan pictureBox ke dalam panel
                PanelSignaturePasien.Controls.Add(pictureBox)

                'Report.RunDesigner()
                Report.ShowPreview()
                'Report.Print()
            Else
                MsgBox("Data tidak ditemukan.", MsgBoxStyle.Critical, "Warning!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Function CreateXRPictureBox(ByVal imageSignature As Image, ByVal LocX As Integer, ByVal LocY As Integer, ByVal SizeX As Integer, ByVal SizeY As Integer) As XRPictureBox
        Dim PictureBox As XRPictureBox = New XRPictureBox()
        PictureBox.Name = "QR_Hasil"
        PictureBox.Image = imageSignature
        PictureBox.Location = New Point(LocX, LocY)
        PictureBox.Size = New Size(SizeX, SizeY)
        PictureBox.Sizing = ImageSizeMode.StretchImage
        PictureBox.BorderWidth = 0

        Return PictureBox
    End Function

    Function CreateTableGeneralConsent() As DataTable
        Dim Thasil As New DataTable
        insertRowToTbls(Thasil, "Typstring", "Nama Pasien")
        insertRowToTbls(Thasil, "Typstring", "Nama Penanggung Jawab")
        insertRowToTbls(Thasil, "Typstring", "Tempat/tgl lahir")
        insertRowToTbls(Thasil, "Typstring", "Alamat")
        insertRowToTbls(Thasil, "Typstring", "No Telepon")
        insertRowToTbls(Thasil, "Typstring", "Bertindak atas")
        insertRowToTbls(Thasil, "Typstring", "Tanggal TTD")
        insertRowToTbls(Thasil, "Typstring", "Nama Petugas")

        Return Thasil
    End Function

    Private Sub GetNumberIHS(ByVal nomorNIK As String)
        Dim nomorIHS As String = ""

        Dim baseURL As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'satu_sehat_base_url'")
        Dim apiEndpoint As String = baseURL & "Patient?identifier=https://fhir.kemkes.go.id/id/nik|" & nomorNIK
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
        Try
            If CekInputKartu("ButtonCekNIK") = True Then
                GetNumberIHS(TextBoxNomorNIK.Text)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub ButtonCariNoRM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCariNoRM.Click
        FindPasien.SetForm("MasterPasien")
        FindPasien.ShowDialog()
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

    Private Sub ComboBoxProvinsiKTP_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxProvinsiKTP.SelectedIndexChanged
        Try
            ComboBoxKabupatenKTP.DataSource = Nothing ' Menghapus sambungan dengan DataSource
            ComboBoxKabupatenKTP.Items.Clear() ' Membersihkan item ComboBox

            If ComboBoxProvinsiKTP.SelectedIndex <> -1 Then
                Dim kodeProvinsi As String = DirectCast(ComboBoxProvinsiKTP.SelectedItem, KeyValuePair(Of String, String)).Key
                SetDataKabupaten(kodeProvinsi, "KTP")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub ComboBoxProvinsiKTP_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ComboBoxProvinsiKTP.Validating
        Dim inputText As String = ComboBoxProvinsiKTP.Text
        If Not IsItemInComboBoxList(ComboBoxProvinsiKTP, inputText) AndAlso inputText <> "" Then
            MsgBox("Data yang dimasukkan tidak valid. Silakan pilih item dari daftar yang tersedia.", MsgBoxStyle.Exclamation, "Warning!")
            e.Cancel = True
        End If
    End Sub

    Private Sub ComboBoxKabupatenKTP_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxKabupatenKTP.SelectedIndexChanged
        Try
            ComboBoxKecamatanKTP.DataSource = Nothing ' Menghapus sambungan dengan DataSource
            ComboBoxKecamatanKTP.Items.Clear() ' Membersihkan item ComboBox

            If ComboBoxKabupatenKTP.SelectedIndex <> -1 Then
                Dim kodeKabupaten As String = DirectCast(ComboBoxKabupatenKTP.SelectedItem, KeyValuePair(Of String, String)).Key
                SetDataKecamatan(kodeKabupaten, "KTP")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub ComboBoxKabupatenKTP_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ComboBoxKabupatenKTP.Validating
        Dim inputText As String = ComboBoxKabupatenKTP.Text
        If Not IsItemInComboBoxList(ComboBoxKabupatenKTP, inputText) AndAlso inputText <> "" Then
            MsgBox("Data yang dimasukkan tidak valid. Silakan pilih item dari daftar yang tersedia.", MsgBoxStyle.Exclamation, "Warning!")
            e.Cancel = True
        End If
    End Sub

    Private Sub ComboBoxKecamatanKTP_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxKecamatanKTP.SelectedIndexChanged
        Try
            ComboBoxKelurahanKTP.DataSource = Nothing ' Menghapus sambungan dengan DataSource
            ComboBoxKelurahanKTP.Items.Clear() ' Membersihkan item ComboBox

            If ComboBoxKecamatanKTP.SelectedIndex <> -1 Then
                Dim kodeKecamatan As String = DirectCast(ComboBoxKecamatanKTP.SelectedItem, KeyValuePair(Of String, String)).Key
                SetDataKelurahan(kodeKecamatan, "KTP")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub ComboBoxKecamatanKTP_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ComboBoxKecamatanKTP.Validating
        Dim inputText As String = ComboBoxKecamatanKTP.Text
        If Not IsItemInComboBoxList(ComboBoxKecamatanKTP, inputText) AndAlso inputText <> "" Then
            MsgBox("Data yang dimasukkan tidak valid. Silakan pilih item dari daftar yang tersedia.", MsgBoxStyle.Exclamation, "Warning!")
            e.Cancel = True
        End If
    End Sub

    Private Sub ComboBoxKelurahanKTP_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ComboBoxKelurahanKTP.Validating
        Dim inputText As String = ComboBoxKelurahanKTP.Text
        If Not IsItemInComboBoxList(ComboBoxKelurahanKTP, inputText) AndAlso inputText <> "" Then
            MsgBox("Data yang dimasukkan tidak valid. Silakan pilih item dari daftar yang tersedia.", MsgBoxStyle.Exclamation, "Warning!")
            e.Cancel = True
        End If
    End Sub

    Private Sub ComboBoxProvinsiDomisili_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxProvinsiDomisili.Click
        SetDataProvinsi("Domisili")
    End Sub

    Private Sub ComboBoxProvinsiKTP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxProvinsiKTP.Click
        SetDataProvinsi("KTP")
    End Sub

    Private Sub CheckBoxStatusNIK_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxStatusNIK.CheckedChanged
        If CheckBoxStatusNIK.Checked = True Then
            If IsPlaceholder(TextBoxNoRM) = False And TextBoxNomorNIK.Text <> "" And TextBoxNomorNIK.Text <> "-" Then
                MsgBox("Nomor NIK tidak bisa diubah karena sudah terinput.", MsgBoxStyle.Critical, "Warning!")
                CheckBoxStatusNIK.Checked = False
            Else
                TextBoxNomorNIK.ResetText()
                TextBoxNomorNIK.Enabled = False
            End If
        Else
            If TextBoxNomorNIK.Text = "" Then TextBoxNomorNIK.Enabled = True
        End If
    End Sub

    Public Sub SetPasienFromPendaftaran(ByVal dataRow As DataRow)
        ' Set Clear
        ClearData()

        TextBoxNomorNIK.Text = dataRow("Nomor NIK")

        If IsDBNull(dataRow("Nama")) = False Then TextBoxNamaLengkapIdentitas.Text = dataRow("Nama")
        If IsDBNull(dataRow("Nomor BPJS")) = False Then TextBoxNomorKIS.Text = dataRow("Nomor BPJS")
        If IsDBNull(dataRow("Jenis Kelamin")) = False Then
            If dataRow("Jenis Kelamin") = "L" Then
                RadioButtonJenisKelaminLakiIdentitas.Checked = True
            ElseIf dataRow("Jenis Kelamin") = "P" Then
                RadioButtonJenisKelaminPerempuanIdentitas.Checked = True
            End If
        End If

        ' Set Tanggal Lahir
        If IsDBNull(dataRow("Tanggal Lahir")) = False Then
            Dim tglLahir As Date = dataRow("Tanggal Lahir")
            DateTimePickerTglLahir.Text = tglLahir
        End If

        If IsDBNull(dataRow("Alamat")) = False Then TextBoxAlamatDomisili.Text = dataRow("Alamat")
    End Sub

    Private Sub ButtonTambahAlergi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTambahAlergi.Click
        
        TambahDataAlergi(TextBoxNoRM.Text)
    End Sub

    Private Function ValidasiAlergi() As Boolean
        If TextBoxNoRM.Text = "" Then
            MsgBox("Eror : Data pasien harus disimpan terlebih dahulu.", MsgBoxStyle.Exclamation, "Error!")
            Return False
        End If

        Return True
    End Function

    Private Sub TambahDataAlergi(ByVal noRekamMedis As String)
        '# Set data dictionary yang akan dikirim ke form popup
        Dim dataDictionary As New Dictionary(Of String, Object)()

        dataDictionary.Add("No Rekam Medis", noRekamMedis)

        DialogBoxTambahAlergi.DataDictionary = dataDictionary
        DialogBoxTambahAlergi.ShowDialog()

        'LoadDataAlergi(idPasien, GridControlAlergi)
    End Sub

    Private Sub TextBoxAlamatDomisili_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxAlamatDomisili.KeyPress
        ' Memeriksa apakah tombol yang ditekan adalah Enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            ' Mencegah input Enter
            e.Handled = True
        End If
    End Sub

    Private Sub TextBoxAlamatKTP_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxAlamatKTP.KeyPress
        ' Memeriksa apakah tombol yang ditekan adalah Enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            ' Mencegah input Enter
            e.Handled = True
        End If
    End Sub

    Private Sub TextBoxAlamatDomisiliWali_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxAlamatDomisiliWali.KeyPress
        ' Memeriksa apakah tombol yang ditekan adalah Enter
        If e.KeyChar = ChrW(Keys.Enter) Then
            ' Mencegah input Enter
            e.Handled = True
        End If
    End Sub

    Private Sub ButtonUploadFoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonUploadFoto.Click
        Dim openFile As New OpenFileDialog()
        openFile.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png"

        If openFile.ShowDialog() = DialogResult.OK Then
            Dim originalFilePath As String = openFile.FileName

            ' Cek ukuran file (dalam byte)
            Dim fileInfo As New IO.FileInfo(originalFilePath)
            Dim maxFileSize As Long = 1048576 ' 1 MB

            If fileInfo.Length > maxFileSize Then
                MessageBox.Show("Ukuran file terlalu besar. Maksimal 1 MB.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' Jika lolos ukuran, tampilkan gambar
            PictureBoxFotoPasien.Image = Image.FromFile(originalFilePath)
            PictureBoxFotoPasien.Tag = originalFilePath
            PictureBoxFotoPasien.SizeMode = PictureBoxSizeMode.Zoom
        End If
    End Sub
End Class