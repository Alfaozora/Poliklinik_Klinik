Imports System.Linq
Imports Newtonsoft.Json
Imports Newtonsoft
Imports Newtonsoft.Json.Linq
Imports System.Text
Imports System.Data
Public Class FormTrackingPosition
    Private _nikPasienAktif As String = ""

    Public Class ComboItem
        Private _displayText As String
        Private _valueData As String

        Public Sub New(ByVal display As String, ByVal value As String)
            Me._displayText = display
            Me._valueData = value
        End Sub

        Public Property DisplayText() As String
            Get
                Return _displayText
            End Get
            Set(ByVal value As String)
                _displayText = value
            End Set
        End Property

        Public Property ValueData() As String
            Get
                Return _valueData
            End Get
            Set(ByVal value As String)
                _valueData = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return Me._displayText
        End Function
    End Class

    Private Sub FormTrackingPosition_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBoxPos.Items.Clear()

        ComboBoxPos.Items.Add(New ComboItem("PENDAFTARAN", "pendaftaran"))
        ComboBoxPos.Items.Add(New ComboItem("PEM. FISIK: TB/BB", "tt_tb"))
        ComboBoxPos.Items.Add(New ComboItem("PEM. FISIK SCREENING", "screening"))
        ComboBoxPos.Items.Add(New ComboItem("PEM. FISIK VISUS MATA", "visus"))
        ComboBoxPos.Items.Add(New ComboItem("PEM. FISIK DOKTER", "dokter"))
        ComboBoxPos.Items.Add(New ComboItem("VISUS MATA", "visus"))
        ComboBoxPos.Items.Add(New ComboItem("PENGAMBILAN DARAH", "darah"))
        ComboBoxPos.Items.Add(New ComboItem("THORAX", "thorax"))
        ComboBoxPos.Items.Add(New ComboItem("SPIROMETRI", "spiro"))
        ComboBoxPos.Items.Add(New ComboItem("AUDIOMETRI", "audio"))
        ComboBoxPos.Items.Add(New ComboItem("ECG", "ecg"))
        ComboBoxPos.Items.Add(New ComboItem("USG", "usg"))
        ComboBoxPos.Items.Add(New ComboItem("TREADMILL", "treadmill"))

        If ComboBoxPos.Items.Count > 0 Then
            ComboBoxPos.SelectedIndex = 0
        End If
    End Sub

    Private Sub TextBoxCariPasien_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxCariPasien.KeyDown
        If e.KeyCode = Keys.Enter Then
            ButtonCariPasien.PerformClick()
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub ButtonCariPasien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCariPasien.Click
        If String.IsNullOrEmpty(TextBoxCariPasien.Text.Trim()) Then
            MessageBox.Show("Silakan masukkan Nomor Urut terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextBoxCariPasien.Focus()
            Exit Sub
        End If

        Dim inputRaw As String = TextBoxCariPasien.Text.Trim()
        Dim noUrutFinal As String = ""

        If inputRaw.Length = 14 Then
            noUrutFinal = inputRaw
        ElseIf inputRaw.Length >= 15 Then
            Dim bagianTengah As String = inputRaw.Substring(3, 6)
            Dim bagianBelakang As String = inputRaw.Substring(10)

            noUrutFinal = "20" & bagianTengah & "M" & bagianBelakang
        Else
            MessageBox.Show("Format Nomor Urut tidak valid! Terlalu pendek.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim query As String = "SELECT MP.NoNIK, MP.Nama, MP.TglLahir, MP.JenisKelamin, TL.NoUrut, TL.IDInternet " & _
                              "FROM TransaksiLab TL " & _
                              "INNER JOIN MasterPasien MP ON TL.IDInternet = MP.NoRekamMedis " & _
                              "WHERE TL.NoUrut = '" & noUrutFinal & "'"

        Try
            Dim tblPasien As DataTable = ReadSQL(query)

            If tblPasien IsNot Nothing AndAlso tblPasien.Rows.Count > 0 Then
                Dim row As DataRow = tblPasien.Rows(0)

                _nikPasienAktif = row("NoNIK").ToString()

                LabelNama.Text = row("Nama").ToString()
                LabelNoRm.Text = row("IDInternet").ToString()
                LabelNoTransaksi.Text = row("NoUrut").ToString()

                If Not IsDBNull(row("TglLahir")) Then
                    Dim tgl As DateTime = Convert.ToDateTime(row("TglLahir"))
                    LabelTglLahir.Text = tgl.ToString("dd MMMM yyyy")
                Else
                    LabelTglLahir.Text = "-"
                End If

                LabelGender.Text = row("JenisKelamin").ToString()

                ButtonMulaiTracking.Enabled = True
                ButtonLewati.Enabled = True
                ButtonLewati.Focus()
                ButtonMulaiTracking.Focus()

            Else
                _nikPasienAktif = ""
                MessageBox.Show("Pasien dengan No Urut " & noUrutFinal & " tidak ditemukan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ResetUIPasien()
            End If

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat mencari data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ResetUIPasien()
        LabelNoTransaksi.Text = "-"
        LabelNama.Text = "-"
        LabelNoRm.Text = "-"
        LabelTglLahir.Text = "-"
        LabelGender.Text = "-"
        ButtonMulaiTracking.Enabled = False
        ButtonLewati.Enabled = False
    End Sub

    Public Function GetActiveSessionCode(ByVal kodeServer As String) As String
        Dim sessionCode As String = ""

        Dim baseUrl As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")

        If Not baseUrl.EndsWith("/") Then
            baseUrl &= "/"
        End If

        Dim finalUrl As String = String.Format("{0}api/mcu/active-session?kode_server={1}", _
                                 baseUrl, _
                                 Uri.EscapeDataString(kodeServer))

        Try
            Dim jsonResponse As String = GetDataAPIRM(finalUrl)

            Dim jsonObj As JObject = JObject.Parse(jsonResponse)

            If jsonObj("success") IsNot Nothing AndAlso CType(jsonObj("success"), Boolean) = True Then
                sessionCode = jsonObj("session_code").ToString()
            End If

        Catch ex As Exception
            Dim errMsg As String = ex.Message
        End Try

        Return sessionCode
    End Function

    Private Sub ButtonRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRefresh.Click
        If ComboBoxPos.SelectedItem IsNot Nothing Then

            Dim selectedItem As ComboItem = CType(ComboBoxPos.SelectedItem, ComboItem)
            Dim selectedPostKey As String = selectedItem.ValueData

            Dim kodeServerLokal As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NoPoli'")
            Dim sessionCode As String = GetActiveSessionCode(kodeServerLokal)

            If String.IsNullOrEmpty(sessionCode) Then
                MessageBox.Show("Gagal mendapatkan Kode Sesi aktif.", "Sesi Tidak Ditemukan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim baseUrl As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
            If Not baseUrl.EndsWith("/") Then baseUrl &= "/"

            Dim finalUrl As String = String.Format("{0}api/mcu/sessions/{1}/participants?status=checked_in&post_key={2}", _
                                                 baseUrl, sessionCode, Uri.EscapeDataString(selectedPostKey))

            Try
                ButtonRefresh.Enabled = False
                Me.Cursor = Cursors.WaitCursor

                Dim jsonResponse As String = GetDataAPIRM(finalUrl)
                Dim jsonObj As JObject = JObject.Parse(jsonResponse)

                Dim dtBelumSelesai As New DataTable()
                dtBelumSelesai.Columns.Add("nourut", GetType(String))
                dtBelumSelesai.Columns.Add("nama", GetType(String))
                dtBelumSelesai.Columns.Add("jeniskelamin", GetType(String))

                Dim dtSelesai As New DataTable()
                dtSelesai.Columns.Add("nourut", GetType(String))
                dtSelesai.Columns.Add("nama", GetType(String))
                dtSelesai.Columns.Add("jeniskelamin", GetType(String))

                If jsonObj("success") IsNot Nothing AndAlso CType(jsonObj("success"), Boolean) = True Then
                    Dim dataToken As JToken = jsonObj("data")

                    Dim arrayBelum As JArray = CType(dataToken("belum_selesai"), JArray)
                    For Each participant As JObject In arrayBelum
                        Dim nourut As String = If(participant("nourut") IsNot Nothing, participant("nourut").ToString(), "")
                        Dim nama As String = If(participant("nama") IsNot Nothing, participant("nama").ToString(), "")
                        Dim jkel As String = If(participant("jeniskelamin") IsNot Nothing, participant("jeniskelamin").ToString(), "")
                        dtBelumSelesai.Rows.Add(nourut, nama, jkel)
                    Next

                    Dim arraySelesai As JArray = CType(dataToken("sudahSelesai"), JArray)
                    For Each participant As JObject In arraySelesai
                        Dim nourut As String = If(participant("nourut") IsNot Nothing, participant("nourut").ToString(), "")
                        Dim nama As String = If(participant("nama") IsNot Nothing, participant("nama").ToString(), "")
                        Dim jkel As String = If(participant("jeniskelamin") IsNot Nothing, participant("jeniskelamin").ToString(), "")
                        dtSelesai.Rows.Add(nourut, nama, jkel)
                    Next
                End If

                DgvPasienSelanjutnya.DataSource = dtBelumSelesai
                DgvPasienSelesai.DataSource = dtSelesai

                If DgvPasienSelanjutnya.Columns.Count >= 3 Then
                    DgvPasienSelanjutnya.Columns("nourut").HeaderText = "No. Urut"
                    DgvPasienSelanjutnya.Columns("nama").HeaderText = "Nama Pasien"
                    DgvPasienSelanjutnya.Columns("jeniskelamin").HeaderText = "Jenis Kelamin"
                End If

                If DgvPasienSelesai.Columns.Count >= 3 Then
                    DgvPasienSelesai.Columns("nourut").HeaderText = "No. Urut"
                    DgvPasienSelesai.Columns("nama").HeaderText = "Nama Pasien"
                    DgvPasienSelesai.Columns("jeniskelamin").HeaderText = "Jenis Kelamin"
                End If

                DgvPasienSelanjutnya.AutoResizeColumns()
                DgvPasienSelesai.AutoResizeColumns()

            Catch ex As Exception
                MessageBox.Show("Terjadi error saat refresh data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Me.Cursor = Cursors.Default
                ButtonRefresh.Enabled = True
            End Try
        Else
            MessageBox.Show("Silakan pilih POS terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ButtonMulaiTracking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonMulaiTracking.Click
        If String.IsNullOrEmpty(_nikPasienAktif) Then
            MessageBox.Show("Silakan cari pasien menggunakan Nomor Urut terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextBoxCariPasien.Focus()
            Exit Sub
        End If

        If ComboBoxPos.SelectedItem Is Nothing Then
            MessageBox.Show("Silakan pilih POS terlebih dahulu pada ComboBox.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim selectedItem As ComboItem = CType(ComboBoxPos.SelectedItem, ComboItem)
        Dim postKey As String = selectedItem.ValueData

        Dim kodeServerLokal As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NoPoli'")
        Dim sessionCode As String = GetActiveSessionCode(kodeServerLokal)

        If String.IsNullOrEmpty(sessionCode) Then
            MessageBox.Show("Gagal mendapatkan Kode Sesi aktif untuk hari ini.", "Sesi Tidak Ditemukan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim baseUrl As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
        If Not baseUrl.EndsWith("/") Then
            baseUrl &= "/"
        End If

        Dim finalUrl As String = String.Format("{0}api/mcu/check-in/{1}/post/{2}", baseUrl, sessionCode, postKey)

        Dim jsonPayload As String = String.Format("{{""identifier"":""{0}"",""identifier_type"":""nik"",""status"":""processing""}}", _nikPasienAktif)

        Dim isProsesSukses As Boolean = False

        Try
            ButtonMulaiTracking.Enabled = False
            Me.Cursor = Cursors.WaitCursor

            Dim jsonResponse As String = InsertDataAPIRM(jsonPayload, finalUrl)

            Dim jsonObj As JObject = JObject.Parse(jsonResponse)

            If jsonObj("success") IsNot Nothing AndAlso CType(jsonObj("success"), Boolean) = True Then
                isProsesSukses = True
                MessageBox.Show("Berhasil memulai tracking untuk pasien ini!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

                TextBoxCariPasien.Enabled = False
                ButtonCariPasien.Enabled = False
                ComboBoxPos.Enabled = False

                ButtonSelesaiTracking.Enabled = True
                ButtonSelesaiTracking.Focus()

                If ButtonRefresh.Enabled Then
                    ButtonRefresh.PerformClick()
                End If
            Else
                Dim msg As String = If(jsonObj("message") IsNot Nothing, jsonObj("message").ToString(), "")

                If msg.Contains("Duplicate entry") Or msg.Contains("1062") Then
                    MessageBox.Show("Pasien ini sudah terdaftar/sedang berjalan di Pos ini!" & vbCrLf & _
                                    "Silakan cek daftar antrean atau langsung klik tombol Selesai jika pemeriksaan telah usai.", _
                                    "Data Sudah Ada", MessageBoxButtons.OK, MessageBoxIcon.Warning)

                    ButtonMulaiTracking.Enabled = False
                    ButtonSelesaiTracking.Enabled = True
                    ButtonSelesaiTracking.Focus()
                Else
                    MessageBox.Show(If(msg = "", "Gagal memproses tracking.", msg), "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan sistem: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default

            If Not isProsesSukses Then
                ButtonMulaiTracking.Enabled = True
            End If
        End Try
    End Sub

    Private Sub ButtonSelesaiTracking_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSelesaiTracking.Click
        If String.IsNullOrEmpty(_nikPasienAktif) Then
            MessageBox.Show("Silakan cari pasien menggunakan Nomor Urut terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextBoxCariPasien.Focus()
            Exit Sub
        End If

        If ComboBoxPos.SelectedItem Is Nothing Then
            MessageBox.Show("Silakan pilih POS terlebih dahulu pada ComboBox.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim selectedItem As ComboItem = CType(ComboBoxPos.SelectedItem, ComboItem)
        Dim postKey As String = selectedItem.ValueData

        Dim kodeServerLokal As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NoPoli'")
        Dim sessionCode As String = GetActiveSessionCode(kodeServerLokal)

        If String.IsNullOrEmpty(sessionCode) Then
            MessageBox.Show("Gagal mendapatkan Kode Sesi aktif untuk hari ini.", "Sesi Tidak Ditemukan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim baseUrl As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
        If Not baseUrl.EndsWith("/") Then
            baseUrl &= "/"
        End If

        Dim finalUrl As String = String.Format("{0}api/mcu/check-in/{1}/post/{2}", baseUrl, sessionCode, postKey)

        Dim jsonPayload As String = String.Format("{{""identifier"":""{0}"",""identifier_type"":""nik"",""status"":""completed""}}", _nikPasienAktif)

        Dim isProsesSukses As Boolean = False

        Try
            ButtonSelesaiTracking.Enabled = False
            Me.Cursor = Cursors.WaitCursor

            Dim jsonResponse As String = InsertDataAPIRM(jsonPayload, finalUrl)

            Dim jsonObj As JObject = JObject.Parse(jsonResponse)

            If jsonObj("success") IsNot Nothing AndAlso CType(jsonObj("success"), Boolean) = True Then
                isProsesSukses = True
                MessageBox.Show("Pemeriksaan POS ini telah selesai dicatat!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

                _nikPasienAktif = ""
                ResetUIPasien()

                TextBoxCariPasien.Text = ""
                TextBoxCariPasien.Enabled = True
                ButtonCariPasien.Enabled = True
                ComboBoxPos.Enabled = True
                TextBoxCariPasien.Focus()

                ButtonMulaiTracking.Enabled = False
                ButtonSelesaiTracking.Enabled = False
                ButtonLewati.Enabled = False

                If ButtonRefresh.Enabled Then
                    ButtonRefresh.PerformClick()
                End If
            Else
                Dim msg As String = If(jsonObj("message") IsNot Nothing, jsonObj("message").ToString(), "Gagal menyelesaikan tracking.")
                MessageBox.Show(msg, "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan sistem: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default

            If Not isProsesSukses Then
                ButtonSelesaiTracking.Enabled = True
            End If
        End Try
    End Sub

    Private Sub ButtonLewati_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLewati.Click
        If String.IsNullOrEmpty(_nikPasienAktif) Then
            MessageBox.Show("Silakan cari pasien menggunakan Nomor Urut terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextBoxCariPasien.Focus()
            Exit Sub
        End If

        If ComboBoxPos.SelectedItem Is Nothing Then
            MessageBox.Show("Silakan pilih POS terlebih dahulu pada ComboBox.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim selectedItem As ComboItem = CType(ComboBoxPos.SelectedItem, ComboItem)
        Dim postKey As String = selectedItem.ValueData

        Dim alasanLewati As String = InputBox("Masukkan alasan mengapa pasien ini MELEWATI pos pemeriksaan ini:" & vbCrLf & _
                                              "(Misal: Hamil, Pasien Menolak, Rekomendasi Dokter)", "Alasan Lewati Pemeriksaan", "")

        If String.IsNullOrEmpty(alasanLewati.Trim()) Then
            MessageBox.Show("Proses dibatalkan. Alasan melewati pos pemeriksaan wajib diisi!", "Batal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim kodeServerLokal As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NoPoli'")
        Dim sessionCode As String = GetActiveSessionCode(kodeServerLokal)

        Dim baseUrl As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
        If Not baseUrl.EndsWith("/") Then baseUrl &= "/"

        Dim finalUrl As String = String.Format("{0}api/mcu/check-in/{1}/post/{2}", baseUrl, sessionCode, postKey)

        Dim alasanClean As String = alasanLewati.Replace("""", "\""")
        Dim jsonPayload As String = String.Format("{{""identifier"":""{0}"",""identifier_type"":""nik"",""status"":""skipped"",""notes"":""{1}""}}", _
                                                  _nikPasienAktif, alasanClean)

        Dim isProsesSukses As Boolean = False

        Try
            ButtonLewati.Enabled = False
            Me.Cursor = Cursors.WaitCursor

            Dim jsonResponse As String = InsertDataAPIRM(jsonPayload, finalUrl)
            Dim jsonObj As JObject = JObject.Parse(jsonResponse)

            If jsonObj("success") IsNot Nothing AndAlso CType(jsonObj("success"), Boolean) = True Then
                isProsesSukses = True
                MessageBox.Show("Pasien berhasil dicatat LEWATI untuk pos ini.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)

                _nikPasienAktif = ""
                ResetUIPasien()

                TextBoxCariPasien.Text = ""
                TextBoxCariPasien.Enabled = True
                ButtonCariPasien.Enabled = True
                ComboBoxPos.Enabled = True
                TextBoxCariPasien.Focus()

                ButtonMulaiTracking.Enabled = False
                ButtonSelesaiTracking.Enabled = False
                ButtonLewati.Enabled = False

                If ButtonRefresh.Enabled Then
                    ButtonRefresh.PerformClick()
                End If
            Else
                Dim msg As String = If(jsonObj("message") IsNot Nothing, jsonObj("message").ToString(), "Gagal memproses.")
                MessageBox.Show(msg, "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan sistem: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Cursor = Cursors.Default
            If Not isProsesSukses Then
                ButtonLewati.Enabled = True
            End If
        End Try
    End Sub
End Class