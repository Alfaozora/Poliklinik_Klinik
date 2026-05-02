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
Imports PoliKlinik_Net2.FormPendaftaranAwal

Public Class FormReservasi
    Private formName As String = "RESERVASI"
    Private userInput As String = PoliKlinik.Lbluser.Text
    'Private kdProviderLokal As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'KodePPK'")
    'Private urlPcare As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_base_url'")

    Private Sub PanelTop_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelTop.Paint
        Try
            e.Graphics.DrawString(formName, New Font("Century Gothic", 16, FontStyle.Bold), Brushes.White, New Point(10, 3))
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Dim lokasiPoli As DataTable = ReadSQL("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NoPoli'")

    Private Function GetNamaKlinik() As String
        If lokasiPoli.Rows.Count > 0 Then
            Dim row As DataRow = lokasiPoli.Rows(0)
            Dim strValue As String = row("StrValue").ToString()

            Select Case strValue
                Case "W001" : Return "KLINIK MITRA MEDICARE SUCI"
                Case "W002" : Return "KLINIK MITRA MEDICARE MANYAR"
                Case "W003" : Return "KLINIK MITRA MEDICARE DRIYOREJO"
                Case "L001" : Return "KLINIK MITRA MEDICARE DHARMAHUSADA"
                Case "L002" : Return "KLINIK MITRA MEDICARE DIPONEGORO"
                Case "L003" : Return "KLINIK LUMIERA LUZELLA"
                Case "A002" : Return "KLINIK MITRA MEDICARE JATIUWUH"
                Case "AD01" : Return "KLINIK MITRA MEDICARE BOYOLALI"
                Case "D002" : Return "KLINIK MITRA MEDICARE RANCAEKEK"
                Case Else : Return "KLINIK CITRA MEDICARE KARAWANG"
            End Select
        End If

        Return "KLINIK TIDAK DIKETAHUI"
    End Function

    Private Sub AturTombolBerdasarkanPoli()
        If lokasiPoli.Rows.Count > 0 Then
            Dim row As DataRow = lokasiPoli.Rows(0)
            Dim strValue As String = row("StrValue").ToString()

            btnMenu1.Visible = (strValue = "L003")
            btnMenu1.BackColor = Color.FromArgb(81, 168, 255)
            btnMenu1.ForeColor = Color.White
            ButtonCari.Visible = (strValue = "L003")
            btnMenu3.Visible = (strValue = "L003")

            ' Set judul form
            If strValue <> "L003" Then
                formName = "REMINDER PASIEN"
                TabControlMenu.SelectedTab = TabPage2
                btnMenu4.Visible = True
            Else
                formName = "RESERVASI"
                btnMenu2.Visible = False
            End If

            ' Tampilkan di judul window form
            Me.Text = formName
        End If
    End Sub

    Private Sub LoadComboBoxPoliTujuan()
        ComboBoxPoliTujuan.Items.Clear()
        Dim tblsPoliTujuan As DataTable = ReadSQL("SELECT * FROM MasterPoliTujuan WHERE PoliSakit = 'True'")
        For Each TrowPoliTujuan As DataRow In tblsPoliTujuan.Rows
            ComboBoxPoliTujuan.Items.Add(TrowPoliTujuan("NamaPoli"))
        Next
        ComboBoxPoliTujuan.SelectedIndex = -1
    End Sub

    Private Sub LoadReservasi()
        Dim query As String = "SELECT JR.JadwalID, R.Hari, R.Sesi, R.Tindakan, JR.NamaRuangan, JR.TglMulai, JR.NamaPasien, JR.NoHP, JR.Catatan, JR.Status " & _
                    "FROM JadwalRuangan JR " & _
                    "INNER JOIN MasterRuangan R ON JR.RuanganID = R.RuanganID " & _
                    "WHERE(JR.TglAkhir > GETDATE()) " & _
                    "ORDER BY JR.TglMulai ASC"

        Dim dt As DataTable = ReadSQL(query)

        ' Tambahkan kolom format Indonesia\
        dt.Columns.Add("Ruangan", GetType(String))
        dt.Columns.Add("Nama Pasien", GetType(String))
        dt.Columns.Add("No HP", GetType(String))
        dt.Columns.Add("Tgl Reservasi", GetType(String))
        dt.Columns.Add("Hari_", GetType(String))
        dt.Columns.Add("Sesi_", GetType(String))
        dt.Columns.Add("Tindakan_", GetType(String))
        dt.Columns.Add("Keterangan", GetType(String))
        dt.Columns.Add("Status Pasien", GetType(String))

        ' Konversi setiap baris ke format Indonesia
        For Each row As DataRow In dt.Rows
            Dim ruangan As String = If(IsDBNull(row("NamaRuangan")), "", row("NamaRuangan").ToString())
            Dim namaPasien As String = If(IsDBNull(row("NamaPasien")), "", row("NamaPasien").ToString())
            Dim noHp As String = If(IsDBNull(row("NoHP")), "", row("NoHP").ToString())
            Dim tgl As DateTime = If(IsDBNull(row("TglMulai")), DateTime.MinValue, CDate(row("TglMulai")))
            Dim hari As String = If(IsDBNull(row("Hari")), "", row("Hari").ToString())
            Dim sesi As String = If(IsDBNull(row("Sesi")), "", row("Sesi").ToString())
            Dim tindakan As String = If(IsDBNull(row("Tindakan")), "", row("Tindakan").ToString())
            Dim catatan As String = If(IsDBNull(row("Catatan")), "", row("Catatan").ToString())
            Dim status As String = If(IsDBNull(row("Status")), "", row("Status").ToString())

            row("Tgl Reservasi") = If(tgl = DateTime.MinValue, "", tgl.ToString("dddd, dd MMMM yyyy HH:mm", New Globalization.CultureInfo("id-ID")))
            'row("Sampai") = If(tglAkhir = DateTime.MinValue, "", tglAkhir.ToString("dddd, dd MMM yyyy HH:mm", New Globalization.CultureInfo("id-ID")))
            row("Nama Pasien") = namaPasien
            row("Ruangan") = ruangan
            row("No HP") = noHp
            row("Hari_") = hari
            row("Sesi_") = sesi
            row("Tindakan_") = tindakan
            row("Keterangan") = catatan
            row("Status Pasien") = status
        Next

        For Each row As DataGridViewRow In DataGridViewReservasi.Rows
            If row.Cells("Status Pasien").Value.ToString().ToUpper() = "CANCEL" Then
                row.Cells("Reminder").Style.ForeColor = Color.Gray
                row.Cells("UbahStatus").Style.ForeColor = Color.Gray
                row.Cells("Reminder").Style.SelectionForeColor = Color.Gray
                row.Cells("UbahStatus").Style.SelectionForeColor = Color.Gray
            End If
        Next

        DataGridViewReservasi.DataSource = dt

        If DataGridViewReservasi.Columns.Contains("JadwalID") Then
            DataGridViewReservasi.Columns("JadwalID").Visible = False
            DataGridViewReservasi.Columns("NamaPasien").Visible = False
            DataGridViewReservasi.Columns("TglMulai").Visible = False
            DataGridViewReservasi.Columns("Hari").Visible = False
            DataGridViewReservasi.Columns("Sesi").Visible = False
            DataGridViewReservasi.Columns("Tindakan").Visible = False
            DataGridViewReservasi.Columns("NamaRuangan").Visible = False
            DataGridViewReservasi.Columns("NoHP").Visible = False
            DataGridViewReservasi.Columns("Catatan").Visible = False
            DataGridViewReservasi.Columns("Status").Visible = False
        End If

        TambahKolomAksi()
    End Sub

    'Private Sub LoadReminder()
    '    Dim query As String = "SELECT ReminderID, NamaPasien, NoHP, Keperluan, Tanggal, Status, CreatedDate, TanggalKirim " & _
    '                  "FROM LogReminderPasien WHERE DeletedBy IS NULL ORDER BY Tanggal ASC"

    '    Dim dt As DataTable = ReadSQL(query)

    '    ' Tambahkan kolom tampilan format Indonesia
    '    dt.Columns.Add("Nama Pasien", GetType(String))
    '    dt.Columns.Add("No HP", GetType(String))
    '    dt.Columns.Add("Keperluan Kunjungan", GetType(String))
    '    dt.Columns.Add("Tanggal Kunjungan", GetType(String))
    '    dt.Columns.Add("Status Pesan", GetType(String))
    '    dt.Columns.Add("Tanggal Terkirim", GetType(String))

    '    For Each row As DataRow In dt.Rows
    '        Dim namaPasien As String = If(IsDBNull(row("NamaPasien")), "", row("NamaPasien").ToString())
    '        Dim noHp As String = If(IsDBNull(row("NoHP")), "", row("NoHP").ToString())
    '        Dim keperluan As String = If(IsDBNull(row("Keperluan")), "", row("Keperluan").ToString())
    '        Dim status As String = If(IsDBNull(row("Status")), "", row("Status").ToString())
    '        Dim tgl As DateTime = If(IsDBNull(row("Tanggal")), DateTime.MinValue, CDate(row("Tanggal")))
    '        Dim tglKirim As DateTime = If(IsDBNull(row("TanggalKirim")), DateTime.MinValue, CDate(row("TanggalKirim")))


    '        row("Nama Pasien") = namaPasien
    '        row("No HP") = noHp
    '        row("Keperluan Kunjungan") = keperluan
    '        row("Status Pesan") = status
    '        row("Tanggal Kunjungan") = If(tgl = DateTime.MinValue, "", tgl.ToString("dddd, dd MMMM yyyy HH:mm", New Globalization.CultureInfo("id-ID")))
    '        row("Tanggal Terkirim") = If(tglKirim = DateTime.MinValue, "", tglKirim.ToString("dddd, dd MMMM yyyy HH:mm", New Globalization.CultureInfo("id-ID")))
    '    Next

    '    DataGridViewReminder.DataSource = dt

    '    If Not DataGridViewReminder.Columns.Contains("Hapus") Then
    '        Dim btnHapus As New DataGridViewButtonColumn()
    '        btnHapus.Name = "Hapus"
    '        btnHapus.HeaderText = ""
    '        btnHapus.Text = "Hapus"
    '        btnHapus.UseColumnTextForButtonValue = True
    '        btnHapus.Width = 50
    '        btnHapus.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        btnHapus.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
    '        DataGridViewReminder.Columns.Add(btnHapus)
    '        DataGridViewReminder.RowTemplate.Height = 35
    '        btnHapus.DisplayIndex = DataGridViewReminder.Columns.Count - 1
    '    End If

    '    ' Sembunyikan kolom data mentah
    '    If DataGridViewReminder.Columns.Contains("ReminderID") Then
    '        DataGridViewReminder.Columns("ReminderID").Visible = False
    '        DataGridViewReminder.Columns("NamaPasien").Visible = False
    '        DataGridViewReminder.Columns("NoHP").Visible = False
    '        DataGridViewReminder.Columns("Keperluan").Visible = False
    '        DataGridViewReminder.Columns("Tanggal").Visible = False
    '        DataGridViewReminder.Columns("Status").Visible = False
    '        DataGridViewReminder.Columns("CreatedDate").Visible = False
    '        DataGridViewReminder.Columns("TanggalKirim").Visible = False
    '    End If

    '    ' Warnai jika status CANCEL
    '    For Each row As DataGridViewRow In DataGridViewReminder.Rows
    '        If row.Cells("Status Pesan").Value.ToString().ToUpper() = "CANCEL" Then
    '            row.DefaultCellStyle.ForeColor = Color.Gray
    '        End If
    '    Next
    'End Sub

    Private Function GetAntreanByTanggal(ByVal tanggal As Date) As Dictionary(Of String, AntreanItem)
        Dim result As New Dictionary(Of String, AntreanItem)

        Dim urlWebService As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'web_service_get_data_antrol'")

        If urlWebService = "" Then Return result
        If Not urlWebService.EndsWith("/") Then urlWebService &= "/"

        Dim fullUrl As String = urlWebService & "0/" & Format(tanggal, "yyyy-MM-dd") & "/0"

        Dim responseString As String = GetDataAntrianOnline(fullUrl)
        If responseString Is Nothing OrElse responseString.Trim() = "" Then Return result

        responseString = responseString.Replace(":NaN", ":null") _
                                       .Replace(": NaN", ": null") _
                                       .Replace("NaN,", "null,") _
                                       .Replace("NaN]", "null]")

        Dim rootList As List(Of RootAntrean) = JsonConvert.DeserializeObject(Of List(Of RootAntrean))(responseString)

        If rootList Is Nothing OrElse rootList.Count = 0 Then Return result

        Dim rootObj As RootAntrean = rootList(0)
        If rootObj Is Nothing OrElse rootObj.response Is Nothing Then Return result

        For Each item As AntreanItem In rootObj.response
            If Not String.IsNullOrEmpty(item.nik) Then
                If Not result.ContainsKey(item.nik) Then
                    result.Add(item.nik, item)
                End If
            End If
        Next

        Return result
    End Function

    Private isLoadingGrid As Boolean = False
    Private filterMenu As New ContextMenuStrip()
    Private filterColumnName As String = ""

    Private Sub DataGridViewReminder_ColumnHeaderMouseClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles DataGridViewReminder.ColumnHeaderMouseClick

        filterMenu.Items.Clear()

        filterColumnName = DataGridViewReminder.Columns(e.ColumnIndex).Name

        ' Hanya kolom tertentu yang boleh difilter
        If filterColumnName <> "Status Booking" Then Exit Sub

        ' Ambil nilai unik dari kolom
        Dim values As New List(Of String)

        For Each row As DataGridViewRow In DataGridViewReminder.Rows
            If row.Cells(filterColumnName).Value IsNot Nothing Then
                Dim val As String = row.Cells(filterColumnName).Value.ToString()
                If Not values.Contains(val) Then values.Add(val)
            End If
        Next

        ' Tambah menu "Semua"
        filterMenu.Items.Add("Semua", Nothing, AddressOf FilterSemua)

        filterMenu.Items.Add(New ToolStripSeparator())

        ' Tambah menu berdasarkan nilai unik
        For Each v As String In values
            filterMenu.Items.Add(v, Nothing, AddressOf FilterByValue)
        Next

        ' Tampilkan menu di posisi mouse
        filterMenu.Show(Cursor.Position)

    End Sub

    Private Sub FilterSemua(ByVal sender As Object, ByVal e As EventArgs)
        CType(DataGridViewReminder.DataSource, DataTable).DefaultView.RowFilter = ""
    End Sub

    Private Sub FilterByValue(ByVal sender As Object, ByVal e As EventArgs)

        Dim selectedValue As String = CType(sender, ToolStripItem).Text
        Dim dt As DataTable = CType(DataGridViewReminder.DataSource, DataTable)

        dt.DefaultView.RowFilter = "[" & filterColumnName & "] = '" & selectedValue & "'"

    End Sub

    Private Sub LoadReminder()
        Dim query As String = _
            "SELECT TOP 100 " & _
            "LRP.ReminderID, LRP.NamaPasien, LRP.NoHP, LRP.Keperluan, " & _
            "LRP.Tanggal, LRP.Status, LRP.CreatedDate, LRP.TanggalKirim, " & _
            "LRP.StatusBooking, LRP.NoAntrean, MP.NoNIK, LRP.NoRekamMedis " & _
            "FROM LogReminderPasien LRP " & _
            "LEFT JOIN MasterPasien MP ON LRP.NoRekamMedis = MP.NoRekamMedis " & _
            "WHERE LRP.DeletedBy IS NULL " & _
            "ORDER BY CASE " & _
            "WHEN CONVERT(date, LRP.Tanggal) = CONVERT(date, GETDATE()) THEN 0 " & _
            "ELSE 1 END, LRP.Tanggal DESC"

        LoadReminderByQuery(query, Date.Now)
    End Sub

    Private Sub ButtonCariReminder_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonCariReminder.Click
        Dim tanggal As Date = TglAwalReminder.Value.Date

        Dim query As String = _
            "SELECT LRP.ReminderID, LRP.NamaPasien, LRP.NoHP, LRP.Keperluan, " & _
            "LRP.Tanggal, LRP.Status, LRP.CreatedDate, LRP.TanggalKirim, " & _
            "LRP.StatusBooking, LRP.NoAntrean, MP.NoNIK, LRP.NoRekamMedis " & _
            "FROM LogReminderPasien LRP " & _
            "LEFT JOIN MasterPasien MP ON LRP.NoRekamMedis = MP.NoRekamMedis " & _
            "WHERE LRP.DeletedBy IS NULL " & _
            "AND CONVERT(date, LRP.Tanggal) = '" & Format(tanggal, "yyyy-MM-dd") & "' " & _
            "ORDER BY LRP.Tanggal DESC"

        LoadReminderByQuery(query, tanggal)
    End Sub

    Private Sub SetupReminderGrid()
        isLoadingGrid = True

        DataGridViewReminder.EditMode = DataGridViewEditMode.EditOnEnter
        DataGridViewReminder.MultiSelect = False
        DataGridViewReminder.SelectionMode = DataGridViewSelectionMode.CellSelect

        For Each col As DataGridViewColumn In DataGridViewReminder.Columns
            col.ReadOnly = True
        Next

        ' Tombol hapus
        If Not DataGridViewReminder.Columns.Contains("Hapus") Then
            Dim btnHapus As New DataGridViewButtonColumn()
            btnHapus.Name = "Hapus"
            btnHapus.HeaderText = "Hapus"
            btnHapus.Text = "Hapus"
            btnHapus.UseColumnTextForButtonValue = True
            btnHapus.Width = 60
            DataGridViewReminder.RowTemplate.Height = 35
            DataGridViewReminder.Columns.Add(btnHapus)
        End If

        If Not DataGridViewReminder.Columns.Contains("AksiStatus") Then
            Dim cmbStatus As New DataGridViewComboBoxColumn()
            cmbStatus.Name = "AksiStatus"
            cmbStatus.HeaderText = "Status"
            cmbStatus.Width = 110
            cmbStatus.Items.Add("")
            cmbStatus.Items.Add("CANCEL")
            cmbStatus.Items.Add("RESCHEDULE")
            cmbStatus.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton
            DataGridViewReminder.RowTemplate.Height = 35
            cmbStatus.FlatStyle = FlatStyle.Flat
            DataGridViewReminder.Columns.Add(cmbStatus)
        End If

        If Not DataGridViewReminder.Columns.Contains("Daftarkan") Then
            Dim btnDaftar As New DataGridViewButtonColumn()
            btnDaftar.Name = "Daftarkan"
            btnDaftar.HeaderText = "Antrean"
            btnDaftar.Text = "Daftarkan"
            btnDaftar.UseColumnTextForButtonValue = True
            btnDaftar.Width = 90
            DataGridViewReminder.RowTemplate.Height = 35
            DataGridViewReminder.Columns.Add(btnDaftar)
        End If

        ' Sembunyikan kolom mentah
        Dim kolomDisembunyikan() As String = New String() { _
             "ReminderID", _
             "NamaPasien", _
             "NoHP", _
             "Keperluan", _
             "Tanggal", _
             "Status", _
             "CreatedDate", _
             "TanggalKirim", _
             "StatusBooking", _
             "NoAntrean", _
             "NoRekamMedis" _
         }

        Dim colName As String

        DataGridViewReminder.Columns("AksiStatus").ReadOnly = False
        DataGridViewReminder.Columns("Hapus").ReadOnly = False
        DataGridViewReminder.Columns("Daftarkan").ReadOnly = False

        For Each colName In kolomDisembunyikan
            If DataGridViewReminder.Columns.Contains(colName) Then
                DataGridViewReminder.Columns(colName).Visible = False
            End If
        Next

        ' Highlight
        For Each row As DataGridViewRow In DataGridViewReminder.Rows

            If row.Cells("Status Booking").Value IsNot Nothing Then
                Dim statusBooking As String = row.Cells("Status Booking").Value.ToString().ToUpper()

                If statusBooking = "CANCEL" Then
                    'row.Cells("Daftarkan").Style.ForeColor = Color.Gray
                    'row.Cells("Daftarkan").Style.BackColor = Color.LightGray
                    'row.Cells("Daftarkan").Style.SelectionBackColor = Color.LightGray
                End If
            End If

        Next

        For Each row As DataGridViewRow In DataGridViewReminder.Rows
            row.Cells("AksiStatus").Value = ""
        Next

        For Each row As DataGridViewRow In DataGridViewReminder.Rows
            If row.Cells("Status Booking").Value IsNot Nothing Then
                Dim statusB As String = row.Cells("Status Booking").Value.ToString().ToUpper()

                If statusB = "BOOKED" Then
                    row.DefaultCellStyle.BackColor = Color.LightGreen
                ElseIf statusB = "BATAL" Or statusB = "CANCEL" Then
                    row.DefaultCellStyle.BackColor = Color.MistyRose
                End If
            End If
        Next

        isLoadingGrid = False
    End Sub

    Private Sub DataGridViewReminder_CellContentClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) _
    Handles DataGridViewReminder.CellContentClick

        If e.RowIndex < 0 Then Exit Sub

        ' Tombol Daftarkan
        If DataGridViewReminder.Columns(e.ColumnIndex).Name = "Daftarkan" Then

            Dim row As DataGridViewRow = DataGridViewReminder.Rows(e.RowIndex)

            Dim statusBooking As String = row.Cells("Status Booking").Value.ToString().ToUpper()

            If statusBooking = "CANCEL" Then
                MsgBox("Booking sudah dibatalkan dan tidak dapat didaftarkan.", _
                       MsgBoxStyle.Information, "Informasi")
                Exit Sub
            End If

            ' Ambil data dari grid
            Dim noRM As String = CStr(row.Cells("NoRekamMedis").Value)
            Dim nik As String = CStr(row.Cells("NoNIK").Value)
            Dim tanggal As Date = CDate(row.Cells("Tanggal").Value)
            Dim kdPoli As String = ReadSQLNIK("SELECT KodePoli FROM LogReminderPasien WHERE NoRekamMedis = '" & noRM & "'")

            ' Ambil config
            Dim kodeFaskes As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'KodePPK'")

            ' Encode Base64
            Dim plainText As String = nik & "*" & kodeFaskes & "*" & _
                                     tanggal.ToString("yyyy-MM-dd") & "*BPJS*" & kdPoli

            Dim bytes As Byte() = System.Text.Encoding.UTF8.GetBytes(plainText)
            Dim encodedBase64 As String = Convert.ToBase64String(bytes)

            Dim bookingUrl As String = "https://hyu.cmhgroup.id/app/antrean/" & encodedBase64

            ' Atau langsung buka browser:
            Process.Start(bookingUrl)

        End If
    End Sub

    Private Sub DataGridViewReminder_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DataGridViewReminder.CurrentCellDirtyStateChanged

        If DataGridViewReminder.IsCurrentCellDirty Then
            DataGridViewReminder.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If

    End Sub

    Private Sub DataGridViewReminder_CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridViewReminder.CellValueChanged
        If isLoadingGrid Then Exit Sub

        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Exit Sub

        If DataGridViewReminder.Columns(e.ColumnIndex).Name <> "AksiStatus" Then Exit Sub

        Dim row = DataGridViewReminder.Rows(e.RowIndex)

        If row.Cells("AksiStatus").Value Is Nothing Then Exit Sub

        Dim statusBaru As String = row.Cells("AksiStatus").Value.ToString()

        ' Abaikan pilihan kosong
        If statusBaru = "" Then Exit Sub

        Dim reminderID As Integer = CInt(row.Cells("ReminderID").Value)
        Dim namaPasien As String = row.Cells("Nama Pasien").Value.ToString()
        Dim statusLama As String = row.Cells("Status Pesan").Value.ToString()

        Dim konfirmasi = MsgBox("Ubah status reminder " & namaPasien & " menjadi " & statusBaru & " ?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Konfirmasi Perubahan Status")

        If konfirmasi = MsgBoxResult.Yes Then
            UpdateStatusReminder(reminderID, statusBaru)

            If statusBaru = "CANCEL" Then
                row.Cells("Daftarkan").ReadOnly = True
            Else
                row.Cells("Daftarkan").ReadOnly = False
            End If

            LoadReminder()
        Else
            isLoadingGrid = True
            row.Cells("AksiStatus").Value = ""
            isLoadingGrid = False
        End If

    End Sub

    'Private Sub DataGridViewReminder_CellBeginEdit(ByVal sender As Object, ByVal e As DataGridViewCellCancelEventArgs) Handles DataGridViewReminder.CellBeginEdit

    '    If DataGridViewReminder.Columns(e.ColumnIndex).Name = "AksiStatus" Then
    '        If DataGridViewReminder.Rows(e.RowIndex).Cells("AksiStatus").Value.ToString() = "" Then
    '            ' OK, boleh edit
    '        End If
    '    End If

    'End Sub


    Private Sub UpdateStatusReminder(ByVal reminderID As Integer, ByVal statusBaru As String)

        Try
            Dim query As String = _
                "UPDATE LogReminderPasien SET " & _
                "StatusBooking = '" & statusBaru & "', " & _
                "UpdatedBy = '" & userInput & "', " & _
                "UpdatedDate = GETDATE() " & _
                "WHERE ReminderID = " & reminderID

            WriteSQL(query, 4)

            MsgBox("Status booking berhasil di " & statusBaru & ".", MsgBoxStyle.Information, "Informasi")
        Catch ex As Exception
            MsgBox("Gagal mengubah status booking." & vbCrLf & ex.Message, _
             MsgBoxStyle.Critical, "Error")
        End Try
        

    End Sub

    Private Sub UpdateBookingToDatabase(ByVal reminderID As String, ByVal noAntrean As String)

        Dim sql As String = _
           "UPDATE LogReminderPasien SET " & _
           "StatusBooking = 'BOOKED', " & _
           "NoAntrean = '" & noAntrean & "', " & _
           "LastSyncAntrean = GETDATE() " & _
           "WHERE ReminderID = '" & reminderID & "' " & _
           "AND (StatusBooking IS NULL OR StatusBooking <> 'BOOKED')"

        WriteSQL(sql, 4)
    End Sub

    Private Sub UpdateCancelBookingToDatabase(ByVal reminderID As String)

        Try
            Dim sql As String = _
                "UPDATE LogReminderPasien SET " & _
                "StatusBooking = 'CANCEL', " & _
                "NoAntrean = NULL, " & _
                "LastSyncAntrean = GETDATE() " & _
                "WHERE ReminderID = '" & reminderID & "' " & _
                "AND StatusBooking = 'BOOKED'"

            WriteSQL(sql, 4)

            MsgBox("Status booking berhasil dicancel.", MsgBoxStyle.Information, "Informasi")
        Catch ex As Exception
            MsgBox("Gagal mengubah status booking." & vbCrLf & ex.Message, _
             MsgBoxStyle.Critical, "Error")
        End Try
        
    End Sub

    Private Sub AutoSyncAntreanH1DanHariH(ByVal bg As System.ComponentModel.BackgroundWorker)

        Dim sql As String = _
            "SELECT LRP.ReminderID, LRP.Tanggal, MP.NoNIK " & _
            "FROM LogReminderPasien LRP " & _
            "LEFT JOIN MasterPasien MP ON LRP.NoRekamMedis = MP.NoRekamMedis " & _
            "WHERE LRP.DeletedBy IS NULL " & _
            "AND (LRP.StatusBooking IS NULL OR LRP.StatusBooking <> 'BOOKED') " & _
            "AND CONVERT(date, LRP.Tanggal) IN (" & _
            "CONVERT(date, DATEADD(day, -1, GETDATE())), " & _
            "CONVERT(date, GETDATE()))"

        Dim dt As DataTable = ReadSQL(sql)
        If dt.Rows.Count = 0 Then Exit Sub

        Dim total As Integer = dt.Rows.Count
        Dim current As Integer = 0

        Dim antreanByTanggal As New Dictionary(Of String, Dictionary(Of String, AntreanItem))

        For Each row As DataRow In dt.Rows

            If bg.CancellationPending Then Exit Sub

            current += 1
            Dim persen As Integer = CInt((current / total) * 100)
            bg.ReportProgress(persen, "Sync " & current & " / " & total)

            Dim tgl As Date = CDate(row("Tanggal")).Date
            Dim keyTanggal As String = tgl.ToString("yyyy-MM-dd")

            If Not antreanByTanggal.ContainsKey(keyTanggal) Then
                antreanByTanggal(keyTanggal) = GetAntreanByTanggal(tgl)
            End If

            Dim nik As String = row("NoNIK").ToString().Trim()

            If antreanByTanggal(keyTanggal).ContainsKey(nik) Then
                Dim antrean As AntreanItem = antreanByTanggal(keyTanggal)(nik)
                UpdateBookingToDatabase(row("ReminderID").ToString(), antrean.nomorantrean)
            End If

        Next

    End Sub

    'Private Sub TimerAutoSync_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerAutoSync.Tick
    '    If Not BgSyncAntrean.IsBusy Then
    '        BgSyncAntrean.RunWorkerAsync()
    '    End If
    'End Sub

    Private Sub BgSyncAntrean_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BgSyncAntrean.DoWork
        Try
            Dim bg As System.ComponentModel.BackgroundWorker = CType(sender, System.ComponentModel.BackgroundWorker)

            AutoSyncAntreanH1DanHariH(bg)

        Catch ex As Exception
            ' log saja, jangan MessageBox
            MsgBox("AutoSyncAntrean error: " & ex.Message)
        End Try
    End Sub

    Private Sub BgSyncAntrean_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) _
    Handles BgSyncAntrean.ProgressChanged

        ProgressBarSync.Visible = True
        LblSyncStatus.Visible = True

        ProgressBarSync.Value = e.ProgressPercentage
        LblSyncStatus.Text = e.UserState.ToString()

    End Sub

    Private Sub BgSyncAntrean_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BgSyncAntrean.RunWorkerCompleted
        ProgressBarSync.Value = 100
        LblSyncStatus.Text = "Sinkronisasi selesai"

        ' kasih delay kecil biar kelihatan selesai
        Threading.Thread.Sleep(500)

        ProgressBarSync.Visible = False
        LblSyncStatus.Visible = False

        LoadReminder()
    End Sub

    Private Sub LoadReminderByQuery(ByVal query As String, ByVal tanggalAntrean As Date)

        ' 1. Ambil antrean API sesuai tanggal
        Dim antreanByNik As Dictionary(Of String, AntreanItem) = GetAntreanByTanggal(tanggalAntrean)

        ' 2. Ambil reminder dari DB
        Dim dt As DataTable = ReadSQL(query)

        ' Kolom tampilan
        If Not dt.Columns.Contains("Nama Pasien") Then
            dt.Columns.Add("Nama Pasien", GetType(String))
            dt.Columns.Add("No HP", GetType(String))
            dt.Columns.Add("Keperluan Kunjungan", GetType(String))
            dt.Columns.Add("Tanggal Kunjungan", GetType(String))
            dt.Columns.Add("Status Pesan", GetType(String))
            dt.Columns.Add("Status Booking", GetType(String))
            dt.Columns.Add("No Antrean", GetType(String))
            dt.Columns.Add("Tanggal Terkirim", GetType(String))
        End If

        Dim apiAvailable As Boolean = Not (antreanByNik Is Nothing OrElse antreanByNik.Count = 0)

        ' 3. Mapping reminder ↔ antrean
        For Each row As DataRow In dt.Rows

            Dim nik As String = row("NoNIK").ToString().Trim()
            Dim reminderID As String = row("ReminderID").ToString()

            Dim statusDb As String = ""
            If Not IsDBNull(row("StatusBooking")) Then
                statusDb = row("StatusBooking").ToString().ToUpper()
            End If

            Dim tgl As DateTime = If(IsDBNull(row("Tanggal")), DateTime.MinValue, CDate(row("Tanggal")))
            Dim tglKirim As DateTime = If(IsDBNull(row("TanggalKirim")), DateTime.MinValue, CDate(row("TanggalKirim")))

            ' ===== DEFAULT DARI DB =====
            row("Status Booking") = If(statusDb = "", "BELUM BOOKING", statusDb)
            row("No Antrean") = If(IsDBNull(row("NoAntrean")), "-", row("NoAntrean").ToString())

            ' ===== CEK API =====
            If apiAvailable Then

                If antreanByNik.ContainsKey(nik) Then

                    Dim antrean As AntreanItem = antreanByNik(nik)

                    If statusDb <> "BOOKED" Then
                        row("Status Booking") = "BOOKED"
                        row("No Antrean") = antrean.nomorantrean
                        UpdateBookingToDatabase(reminderID, antrean.nomorantrean)
                    End If

                ElseIf statusDb = "BOOKED" Then

                    row("Status Booking") = "CANCEL"
                    row("No Antrean") = "-"
                    UpdateCancelBookingToDatabase(reminderID)

                End If

            End If

            ' ===== KOLOM TAMPILAN =====
            row("Nama Pasien") = row("NamaPasien").ToString()
            row("No HP") = row("NoHP").ToString()
            row("Keperluan Kunjungan") = row("Keperluan").ToString()
            row("Tanggal Kunjungan") = If(tgl = DateTime.MinValue, "", _
                tgl.ToString("dddd, dd MMMM yyyy HH:mm", New Globalization.CultureInfo("id-ID")))
            row("Tanggal Terkirim") = If(tglKirim = DateTime.MinValue, "", _
                tglKirim.ToString("dddd, dd MMMM yyyy HH:mm", New Globalization.CultureInfo("id-ID")))
            row("Status Pesan") = row("Status").ToString()

        Next

        DataGridViewReminder.DataSource = dt
        SetupReminderGrid()
    End Sub

    Private Sub LoadSesi()
        Dim query As String = "SELECT RuanganID, NamaRuangan, Tindakan, Sesi, Hari, JamAwal, JamAkhir, Kuota, Praktisi FROM MasterRuangan " & _
                       "ORDER BY CASE Hari " & _
                       "WHEN 'Senin' THEN 1 " & _
                       "WHEN 'Selasa' THEN 2 " & _
                       "WHEN 'Rabu' THEN 3 " & _
                       "WHEN 'Kamis' THEN 4 " & _
                       "WHEN 'Jumat' THEN 5 " & _
                       "WHEN 'Sabtu' THEN 6 " & _
                       "WHEN 'Minggu' THEN 7 " & _
                       "ELSE 8 END, Sesi ASC"
        Dim dtRuangan As DataTable = ReadSQL(query)

        If dtRuangan IsNot Nothing Then
            For Each row As DataRow In dtRuangan.Rows
                If Not IsDBNull(row("JamAwal")) Then
                    Dim tsAwal As TimeSpan = CType(row("JamAwal"), TimeSpan)
                    row("JamAwal") = tsAwal.Hours.ToString("D2") & ":" & tsAwal.Minutes.ToString("D2")
                End If
                If Not IsDBNull(row("JamAkhir")) Then
                    Dim tsAkhir As TimeSpan = CType(row("JamAkhir"), TimeSpan)
                    row("JamAkhir") = tsAkhir.Hours.ToString("D2") & ":" & tsAkhir.Minutes.ToString("D2")
                End If
            Next

            DataGridViewSesi.DataSource = dtRuangan

            With DataGridViewSesi
                .Columns("RuanganID").HeaderText = "ID"
                .Columns("NamaRuangan").HeaderText = "Nama Ruangan"
                .Columns("Tindakan").HeaderText = "Tindakan"
                .Columns("Sesi").HeaderText = "Sesi"
                .Columns("Hari").HeaderText = "Hari"
                .Columns("JamAwal").HeaderText = "Jam Awal"
                .Columns("JamAkhir").HeaderText = "Jam Akhir"
                .Columns("Kuota").HeaderText = "Kuota"
                .Columns("Praktisi").HeaderText = "Praktisi"
            End With

            If DataGridViewSesi.Columns.Contains("RuanganID") Then
                DataGridViewSesi.Columns("RuanganID").Visible = False
            End If

        Else
            DataGridViewSesi.DataSource = Nothing
        End If
    End Sub

    Private Sub DataGridViewReminder_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridViewReminder.CellClick

        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Exit Sub

        Dim dgv As DataGridView = CType(sender, DataGridView)

        If dgv.Columns(e.ColumnIndex).Name <> "Hapus" Then Exit Sub

        Dim namaPasien As String = dgv.Rows(e.RowIndex).Cells("Nama Pasien").Value.ToString()
        Dim reminderID As Integer = CInt(dgv.Rows(e.RowIndex).Cells("ReminderID").Value)

        Dim konfirmasi = MsgBox("Yakin ingin menghapus reminder untuk " & namaPasien & " ?", MsgBoxStyle.Question Or MsgBoxStyle.YesNo, "Konfirmasi Hapus")

        If konfirmasi = MsgBoxResult.Yes Then
            SoftDeleteReminder(reminderID)
            LoadReminder()
        End If

    End Sub

    Private Sub SoftDeleteReminder(ByVal reminderID As Integer)

        Try
            Dim query As String = _
                "UPDATE LogReminderPasien SET " & _
                "Status = 'CANCEL', " & _
                "StatusBooking = 'CANCEL', " & _
                "DeletedBy = '" & userInput & "', " & _
                "DeletedDate = GETDATE() " & _
                "WHERE ReminderID = " & reminderID

            WriteSQL(query, 4)

            MsgBox("Reminder berhasil dibatalkan.", MsgBoxStyle.Information, "Informasi")

        Catch ex As Exception
            MsgBox("Gagal membatalkan reminder." & vbCrLf & ex.Message, _
                   MsgBoxStyle.Critical, "Error")
        End Try

    End Sub

    Private Sub DataGridViewReservasi_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles DataGridViewReservasi.RowPrePaint
        Dim row As DataGridViewRow = DataGridViewReservasi.Rows(e.RowIndex)
        Dim statusCell As DataGridViewCell = row.Cells("Status") ' Ganti "Status" dengan nama kolom yang sesuai

        If statusCell.Value IsNot Nothing AndAlso statusCell.Value.ToString() = "CANCEL" Then
            row.DefaultCellStyle.BackColor = Color.FromArgb(242, 222, 222)
            row.DefaultCellStyle.ForeColor = Color.Black
        ElseIf statusCell.Value IsNot Nothing AndAlso statusCell.Value.ToString() = "RESCHEDULE" Then
            row.DefaultCellStyle.BackColor = Color.FromArgb(184, 232, 252)
            row.DefaultCellStyle.ForeColor = Color.Black
        ElseIf statusCell.Value IsNot Nothing AndAlso statusCell.Value.ToString() = "TERJADWAL" Then
            row.DefaultCellStyle.BackColor = Color.FromArgb(195, 237, 192)
            row.DefaultCellStyle.ForeColor = Color.Black
        End If
    End Sub

    Private Sub DataGridViewReminder_RowPrePaint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowPrePaintEventArgs) Handles DataGridViewReminder.RowPrePaint
        Dim row As DataGridViewRow = DataGridViewReminder.Rows(e.RowIndex)
        Dim statusCell As DataGridViewCell = row.Cells("Status Pesan")

        If statusCell.Value IsNot Nothing AndAlso statusCell.Value.ToString() = "TERJADWAL" Then
            row.DefaultCellStyle.BackColor = Color.White
            row.DefaultCellStyle.ForeColor = Color.Black
        ElseIf statusCell.Value IsNot Nothing AndAlso statusCell.Value.ToString() = "TERKIRIM" Then
            row.DefaultCellStyle.BackColor = Color.FromArgb(195, 237, 192)
            row.DefaultCellStyle.ForeColor = Color.Black
        End If
    End Sub

    Public Function SetParameterWhatsappText(ByVal nomor As String, ByVal pesan As String) As String
        ' Bersihkan format pesan: ganti newline jadi \n, escape kutip dua
        Dim cleanPesan As String = pesan.Replace(vbCrLf, "\n").Replace("""", "\""")

        ' Buat JSON manual
        Dim json As String = "{" & _
            """number"": """ & nomor & """," & _
            """message"": """ & cleanPesan & """" & _
        "}"

        Return json
    End Function

    Public Sub KirimReminderReservasiWhatsApp(ByVal namaPasien As String, ByVal noHP As String, ByVal tglReservasi As DateTime, ByVal ruangan As String, ByVal hari As String, ByVal sesi As String, ByVal tindakan As String)
        Try
            If Strings.Left(noHP, 2) = "08" Then
                noHP = "62" & noHP.Substring(1)
            End If

            Dim waStatus As String = ReadSQLNIK("SELECT StrValue FROM msconfig WHERE ConfigName = 'whatsapp_klinik_status'")
            Dim waIP As String = ReadSQLNIK("SELECT StrValue FROM msconfig WHERE ConfigName = 'whatsapp_klinik_ip'")
            Dim lokasiKlinik As String = ReadSQLNIK("SELECT StrValue FROM msconfig WHERE ConfigName = 'InvoiceTempat_Klinik'")
            Dim namaKlinik As String = GetNamaKlinik()

            If waStatus <> "Yes" Then
                MsgBox("WhatsApp belum disetting. Hubungi IT.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            Dim tanggalIndo As String = tglReservasi.ToString("dddd, dd MMMM yyyy", New Globalization.CultureInfo("id-ID"))

            Dim pesan As String = "Salam Sehat *" & namaPasien & "*" & vbCrLf & vbCrLf & _
                                  "Pengingat reservasi Anda di *" & namaKlinik & "*." & vbCrLf & _
                                  "Untuk tindakan *" & tindakan & "* Pada sesi " & sesi & "" & vbCrLf & _
                                  "Tanggal: " & tanggalIndo & vbCrLf & _
                                  "Jam: " & tglReservasi.ToString("HH:mm") & " WIB" & vbCrLf & _
                                  "Ruangan: " & ruangan & vbCrLf & vbCrLf & _
                                  "Mohon datang tepat waktu." & vbCrLf & _
                                  "Terima kasih" & vbCrLf & vbCrLf & _
                                  "----- Pesan otomatis, mohon tidak dibalas -----"

            Dim parameter As String = SetParameterWhatsappText(noHP, pesan)
            Dim urlSend As String = "http://" & waIP & ":4444/send"
            Dim statusKirim As String = SendDataWhatsapp(parameter, urlSend)

            MsgBox("Respon server: " & statusKirim, MsgBoxStyle.Information)

            If statusKirim = "Success" Then
                MsgBox("Reminder berhasil dikirim ke " & noHP, MsgBoxStyle.Information)
            Else
                MsgBox("Gagal mengirim WhatsApp. Periksa koneksi atau server WhatsApp.", MsgBoxStyle.Exclamation)
            End If
        Catch ex As Exception
            MsgBox("Terjadi kesalahan saat kirim reminder: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private selectedJadwalID As Integer = 0

    Private Sub DataGridViewReservasi_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridViewReservasi.CellClick
        If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then Exit Sub

        Dim statusPasien As String = DataGridViewReservasi.Rows(e.RowIndex).Cells("Status Pasien").Value.ToString().ToUpper()
        Dim columnName As String = DataGridViewReservasi.Columns(e.ColumnIndex).Name

        If statusPasien = "CANCEL" AndAlso (columnName = "Reminder" Or columnName = "UbahStatus") Then Exit Sub

        If columnName = "Reminder" Then
            Dim namaPasien As String = DataGridViewReservasi.Rows(e.RowIndex).Cells("NamaPasien").Value.ToString()
            Dim noHP As String = DataGridViewReservasi.Rows(e.RowIndex).Cells("NoHP").Value.ToString()
            Dim tglMulai As DateTime = CDate(DataGridViewReservasi.Rows(e.RowIndex).Cells("TglMulai").Value)
            Dim hari As String = DataGridViewReservasi.Rows(e.RowIndex).Cells("Hari_").Value.ToString()
            Dim sesi As String = DataGridViewReservasi.Rows(e.RowIndex).Cells("Sesi_").Value.ToString()
            Dim tindakan As String = DataGridViewReservasi.Rows(e.RowIndex).Cells("Tindakan_").Value.ToString()

            ' Ambil JadwalID dari kolom tersembunyi
            Dim idJadwal As Integer = CInt(DataGridViewReservasi.Rows(e.RowIndex).Cells("JadwalID").Value)

            ' Ambil Nama Ruangan dari JadwalID
            Dim namaRuangan As String = ReadSQLNIK("SELECT MR.NamaRuangan FROM JadwalRuangan JR " & _
                                               "INNER JOIN MasterRuangan MR ON JR.RuanganID = MR.RuanganID " & _
                                               "WHERE JR.JadwalID = " & idJadwal)

            ' Kirim WA reminder
            KirimReminderReservasiWhatsApp(namaPasien, noHP, tglMulai, namaRuangan, hari, sesi, tindakan)
        End If

        If columnName = "UbahStatus" Then
            ' Ambil nilai JadwalID dari baris yang diklik
            selectedJadwalID = CInt(DataGridViewReservasi.Rows(e.RowIndex).Cells("JadwalID").Value)

            ' Tampilkan ContextMenu di posisi mouse
            ContextMenuStatus.Show(Cursor.Position)
        End If
    End Sub

    Private Sub CancelToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CancelToolStripMenuItem.Click
        Try
            Dim query As String = "UPDATE JadwalRuangan SET " & _
                              "Status = 'CANCEL', " & _
                              "DeletedBy = '" & userInput & "', " & _
                              "DeletedDate = GETDATE() " & _
                              "WHERE JadwalID = " & selectedJadwalID
            WriteSQL(query, 4)

            MsgBox("Status diubah menjadi CANCEL", MsgBoxStyle.Information)
            LoadReservasi()
        Catch ex As Exception
            MsgBox("Status gagal diubah", MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub RescheduleToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RescheduleToolStripMenuItem.Click
        Try
            Dim dlg As New Dialog1()

            If dlg.ShowDialog() = DialogResult.OK Then
                Dim mulaiBaru As DateTime = dlg.TglMulaiBaru
                Dim akhirBaru As DateTime = dlg.TglAkhirBaru
                Dim hariBaru As String = mulaiBaru.ToString("dddd", New Globalization.CultureInfo("id-ID"))

                ' Ambil data lama dari database
                Dim dt As DataTable = ReadSQL("SELECT JR.RuanganID, R.Sesi, R.Hari, R.NamaRuangan " & _
                                              "FROM JadwalRuangan JR " & _
                                              "INNER JOIN MasterRuangan R ON JR.RuanganID = R.RuanganID " & _
                                              "WHERE JR.JadwalID = " & selectedJadwalID)

                If dt.Rows.Count = 0 Then
                    MsgBox("Data jadwal tidak ditemukan.", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If

                Dim ruanganID As String = dt.Rows(0)("RuanganID").ToString()
                Dim sesiLama As String = dt.Rows(0)("Sesi").ToString()
                Dim namaRuangan As String = dt.Rows(0)("NamaRuangan").ToString()

                ' Validasi kuota baru untuk sesi dan hari baru
                Dim queryCek As String = "SELECT COUNT(*) FROM JadwalRuangan " & _
                                         "WHERE RuanganID = '" & ruanganID & "' " & _
                                         "AND Sesi = '" & sesiLama & "' " & _
                                         "AND DATENAME(WEEKDAY, TglMulai) = '" & hariBaru & "' " & _
                                         "AND Status <> 'CANCEL'"

                Dim jumlahBooking As Integer = CInt(ReadSQLValue(queryCek))

                Dim queryKuota As String = "SELECT Kuota FROM MasterRuangan WHERE RuanganID = '" & ruanganID & "'"
                Dim kuotaRuangan As Integer = CInt(ReadSQLValue(queryKuota))

                If jumlahBooking >= kuotaRuangan Then
                    MsgBox("Kuota untuk sesi '" & sesiLama & "' di hari " & hariBaru & " sudah penuh.", MsgBoxStyle.Critical)
                    Exit Sub
                End If

                ' Update jadwal jika kuota cukup
                Dim queryUpdate As String = "UPDATE JadwalRuangan SET " & _
                                            "Status = 'RESCHEDULE', " & _
                                            "TglMulai = '" & mulaiBaru.ToString("yyyy-MM-dd HH:mm") & "', " & _
                                            "TglAkhir = '" & akhirBaru.ToString("yyyy-MM-dd HH:mm") & "', " & _
                                            "ChangedBy = '" & userInput & "', " & _
                                            "ChangedDate = GETDATE() " & _
                                            "WHERE JadwalID = " & selectedJadwalID

                WriteSQL(queryUpdate, 4)

                MsgBox("Status diubah menjadi RESCHEDULE dan jadwal diperbarui.", MsgBoxStyle.Information)
                LoadReservasi()
            End If
        Catch ex As Exception
            MsgBox("Status gagal diubah: " & ex.Message, MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Private Sub TambahKolomAksi()
        ' Bersihkan kolom button yang sudah ada
        For i As Integer = DataGridViewReservasi.Columns.Count - 1 To 0 Step -1
            If TypeOf DataGridViewReservasi.Columns(i) Is DataGridViewButtonColumn Then
                DataGridViewReservasi.Columns.RemoveAt(i)
            End If
        Next

        ' Tambah tombol Reminder
        Dim btnReminder As New DataGridViewButtonColumn()
        btnReminder.Name = "Reminder"
        btnReminder.HeaderText = "Reminder"
        btnReminder.Text = "Kirim"
        btnReminder.UseColumnTextForButtonValue = True
        btnReminder.Width = 100
        btnReminder.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        btnReminder.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewReservasi.Columns.Add(btnReminder)

        ' Tambah tombol Status
        Dim btnStatus As New DataGridViewButtonColumn()
        btnStatus.Name = "UbahStatus"
        btnStatus.HeaderText = "Status"
        btnStatus.Text = "Ubah"
        btnStatus.UseColumnTextForButtonValue = True
        btnStatus.Width = 100
        btnStatus.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        btnStatus.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DataGridViewReservasi.Columns.Add(btnStatus)

        ' Besarkan tinggi baris agar tombol terlihat lebih besar
        DataGridViewReservasi.RowTemplate.Height = 35
    End Sub

    Private Sub UpdateExpiredJadwal()
        Dim queryUpdate As String = "UPDATE JadwalRuangan " & _
                                    "SET Status = 'EXPIRED' " & _
                                    "WHERE Status = 'TERJADWAL' AND TglMulai < GETDATE()"

        WriteSQL(queryUpdate, 4)
    End Sub

    Private Sub FormReservasi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
            Me.MdiParent = PoliKlinik
            Me.Dock = DockStyle.Fill

            DataGridViewReminder.Columns.Clear()
            DataGridViewReminder.AutoGenerateColumns = True

            btnMenu1.BackColor = Color.FromArgb(81, 168, 255)
            btnMenu1.ForeColor = Color.White

            AturTombolBerdasarkanPoli()

            ' Jalankan auto sync di background


            ' Hide tab header button
            'TabControl1.Appearance = TabAppearance.FlatButtons
            TabControlMenu.ItemSize = New Size(0, 1)
            'TabControl1.SizeMode = TabSizeMode.Fixed

            UpdateExpiredJadwal()
            LoadReservasi()
            'AutoSyncAntreanH1DanHariH(bg)

            LoadReminder()

            If Not BgSyncAntrean.IsBusy Then
                BgSyncAntrean.RunWorkerAsync()
            End If

            TambahKolomAksi()
            LoadComboBoxPoliTujuan()
            LoadSesi()

            Timer1.Interval = 60000
            Timer1.Start()

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub FrmReservasi_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing

        If BgSyncAntrean.IsBusy Then
            BgSyncAntrean.CancelAsync()
        End If

    End Sub

    Private Sub btnMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMenu4.Click, btnMenu3.Click, btnMenu2.Click, btnMenu1.Click
        Try
            Dim myButton = DirectCast(sender, Button)

            For Each ctrl As System.Windows.Forms.Control In PanelSide.Controls ' ganti sesuai nama panel
                If TypeOf ctrl Is Button AndAlso ctrl.Name.StartsWith("btnMenu") Then
                    Dim btn As Button = DirectCast(ctrl, Button)
                    btn.BackColor = Color.FromArgb(0, 100, 200)       ' ← ini kunci: kembali ke warna default
                    btn.ForeColor = System.Drawing.Color.White
                End If
            Next

            ' Set warna aktif untuk tombol yang diklik
            myButton.BackColor = Color.FromArgb(81, 168, 255)
            myButton.ForeColor = Color.White

            Select Case myButton.Name
                Case "btnMenu1"
                    TabControlMenu.SelectedTab = TabPage1
                    ButtonCari.Visible = True
                Case "btnMenu2"
                    TabControlMenu.SelectedTab = TabPage2
                    ButtonSimpan.Visible = True
                Case "btnMenu3"
                    TabControlMenu.SelectedTab = TabPage3
                    ButtonCari.Visible = False
                Case "btnMenu4"
                    TabControlMenu.SelectedTab = TabPage4
                    ButtonCari.Visible = False
                    ButtonSimpan.Visible = False
            End Select
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        'Me.Close()
        Me.Hide()
    End Sub

    Public Function ReadSQLValue(ByVal sql As String) As Object
        Dim dt As DataTable = ReadSQL(sql)
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0)(0)
        Else
            Return Nothing
        End If
    End Function

    Private Function IsJadwalTersedia(ByVal ruanganId As Integer, ByVal mulai As DateTime, ByVal selesai As DateTime) As Boolean
        Dim namaRuangan As Object = ReadSQLNIK("SELECT NamaRuangan FROM MasterRuangan WHERE RuanganID = " & ruanganId)

        ' Cek jika hasil NULL
        If namaRuangan Is Nothing OrElse IsDBNull(namaRuangan) Then
            MsgBox("Nama ruangan tidak ditemukan.", MsgBoxStyle.Exclamation)
            Return False
        End If

        ' Jika HBOT, boleh overlap
        If namaRuangan.ToString().ToUpper().Contains("HBOT") Then
            Return True
        End If

        ' Cek bentrok waktu
        Dim query As String = "SELECT COUNT(*) FROM JadwalRuangan WHERE RuanganID = " & ruanganId & " AND " & _
                              "('" & mulai.ToString("yyyy-MM-dd HH:mm") & "' < TglAkhir AND '" & selesai.ToString("yyyy-MM-dd HH:mm") & "' > TglMulai)"

        ' Gunakan fungsi scalar yang benar
        Dim count As Integer = Val(ReadSQLValue(query))
        Return count = 0
    End Function

    Private Sub ButtonSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSimpan.Click
        If lokasiPoli.Rows.Count = 0 Then
            MsgBox("Data lokasi poli tidak ditemukan.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim strValue As String = lokasiPoli.Rows(0)("StrValue").ToString()

        If TabControlMenu.SelectedTab Is TabPage1 Then
            Dim mulai As DateTime = dtReservasi.Value
            Dim selesai As DateTime = dtSelesai.Value
            Dim namaPasien As String = TextBoxNamaPasien.Text
            Dim keterangan As String = TextBoxCatatan.Text
            Dim NoHp As String = TextBoxNoHP.Text
            Dim sekarang As DateTime = DateTime.Now
            Dim namaRuangan As String = TextBoxRuangan.Text
            Dim Tindakan As String = TextBoxTindakanReservasi.Text
            Dim Sesi As String = TextBoxSesiReservasi.Text
            Dim Praktisi As String = TextBoxPraktisiReservasi.Text
            Dim hari As String = mulai.ToString("dddd", New Globalization.CultureInfo("id-ID"))

            ' Hitung jumlah pasien yang sudah reservasi
            Dim queryCek As String = "SELECT COUNT(*) FROM JadwalRuangan JR " & _
                 "WHERE JR.NamaRuangan = '" & namaRuangan.Replace("'", "''") & "' " & _
                 "AND JR.Sesi = '" & Sesi.Replace("'", "''") & "' " & _
                 "AND (CASE DATENAME(WEEKDAY, JR.TglMulai) " & _
                     "WHEN 'Monday' THEN 'Senin' " & _
                     "WHEN 'Tuesday' THEN 'Selasa' " & _
                     "WHEN 'Wednesday' THEN 'Rabu' " & _
                     "WHEN 'Thursday' THEN 'Kamis' " & _
                     "WHEN 'Friday' THEN 'Jumat' " & _
                     "WHEN 'Saturday' THEN 'Sabtu' " & _
                     "WHEN 'Sunday' THEN 'Minggu' " & _
                 "END) = '" & hari & "'"
            Dim jumlahBooking As Integer = 0
            Dim valueBooking As Object = ReadSQLValue(queryCek)
            If Not IsDBNull(valueBooking) Then jumlahBooking = CInt(valueBooking)

            ' Ambil kuota dari MasterRuangan
            Dim queryKuota As String = "SELECT Kuota FROM MasterRuangan " & _
                                       "WHERE NamaRuangan = '" & namaRuangan.Replace("'", "''") & "' " & _
                                       "AND Sesi = '" & Sesi.Replace("'", "''") & "' " & _
                                       "AND Hari = '" & hari & "'"
            Dim kuotaRuangan As Integer = 0
            Dim valueKuota As Object = ReadSQLValue(queryKuota)
            If Not IsDBNull(valueKuota) Then kuotaRuangan = CInt(valueKuota)

            'Ambil RuanganID
            Dim queryRuanganID As String = "SELECT RuanganID FROM MasterRuangan WHERE " & _
                                "NamaRuangan = '" & namaRuangan.Replace("'", "''") & "' AND " & _
                                "Sesi = '" & Sesi.Replace("'", "''") & "' AND " & _
                                "Hari = '" & hari.Replace("'", "''") & "'"

            Dim ruanganID As String = ReadSQLValue(queryRuanganID)

            ' Validasi apakah sesi tersedia di hari tersebut untuk poli/ruangan yang dipilih
            Dim queryValidasiSesi As String = "SELECT COUNT(*) FROM MasterRuangan WHERE " & _
                                              "NamaRuangan = '" & namaRuangan.Replace("'", "''") & "' AND " & _
                                              "Sesi = '" & Sesi.Replace("'", "''") & "' AND " & _
                                              "Hari = '" & hari & "'"

            Dim cekSesiHari As Integer = CInt(ReadSQLValue(queryValidasiSesi))

            If cekSesiHari = 0 Then
                MsgBox("Sesi '" & Sesi & "' tidak tersedia untuk Poli " & namaRuangan & " di hari " & hari & ".", MsgBoxStyle.Critical, "Jadwal Tidak Tersedia")
                Exit Sub
            End If

            ' Bandingkan
            If jumlahBooking >= kuotaRuangan Then
                MsgBox("Kuota untuk sesi ini sudah penuh. Silakan pilih sesi atau waktu lain.", MsgBoxStyle.Critical, "Kuota Penuh")
                Exit Sub
            End If

            If namaPasien = "" Then
                MsgBox("Nama pasien tidak boleh kosong.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            If NoHp = "" Then
                MsgBox("Nomor HP tidak boleh kosong.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            If mulai.ToString("yyyy-MM-dd HH:mm") = sekarang.ToString("yyyy-MM-dd HH:mm") Then
                MsgBox("Waktu reservasi tidak boleh sama dengan waktu saat ini.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            If selesai.ToString("yyyy-MM-dd HH:mm") = sekarang.ToString("yyyy-MM-dd HH:mm") Then
                MsgBox("Waktu selesai tidak boleh sama dengan waktu saat ini.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            'If Not IsJadwalTersedia(ruanganId, mulai, selesai) Then
            '    MsgBox("Waktu sudah terisi. Silakan pilih waktu lain.", MsgBoxStyle.Exclamation)
            '    Exit Sub
            'End If

            If mulai < DateTime.Now Then
                MsgBox("Waktu reservasi tidak boleh di masa lalu.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            If selesai <= mulai Then
                MsgBox("Waktu selesai harus lebih besar dari waktu mulai.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            If ruanganID = "" Then
                MsgBox("Ruangan tidak ditemukan di MasterRuangan. Cek kembali inputannya.", MsgBoxStyle.Critical)
                Exit Sub
            End If

            namaPasien = namaPasien.Replace("'", "''")
            NoHp = NoHp.Replace("'", "''")
            keterangan = keterangan.Replace("'", "''")

            WriteSQL("INSERT INTO JadwalRuangan (NamaRuangan, Tanggal, TglMulai, TglAkhir, NamaPasien, NoHP, Catatan, Status, CreatedBy, CreatedDate, Tindakan, Sesi, Praktisi, Kuota, RuanganID) " & _
                  "VALUES (" & _
                  "'" & namaRuangan.Replace("'", "''") & "', " & _
                  "GETDATE(), " & _
                  "'" & mulai.ToString("yyyy-MM-dd HH:mm") & "', " & _
                  "'" & selesai.ToString("yyyy-MM-dd HH:mm") & "', " & _
                  "'" & namaPasien.Replace("'", "''") & "', " & _
                  "'" & NoHp.Replace("'", "''") & "', " & _
                  "'" & keterangan.Replace("'", "''") & "', " & _
                  "'TERJADWAL', " & _
                  "'" & userInput.Replace("'", "''") & "', " & _
                  "GETDATE(), " & _
                  "'" & Tindakan.Replace("'", "''") & "', " & _
                  "'" & Sesi.Replace("'", "''") & "', " & _
                  "'" & Praktisi.Replace("'", "''") & "', " & _
                  kuotaRuangan & ", " & _
                  ruanganID & ")", 4)

            MsgBox("Reservasi berhasil disimpan.", MsgBoxStyle.Information)

            ' Reset form
            TextBoxNamaPasien.Clear()
            TextBoxNoHP.Clear()
            TextBoxCatatan.Clear()
            dtReservasi.Value = DateTime.Now
            dtSelesai.Value = DateTime.Now.AddMinutes(30)
            TextBoxSesiReservasi.Clear()
            TextBoxHariReservasi.Clear()
            TextBoxPraktisiReservasi.Clear()
            TextBoxRuangan.Clear()
            LoadReservasi()

        ElseIf TabControlMenu.SelectedTab Is TabPage3 Then
            Dim mulai As DateTime = DateTimePickerMulai.Value
            Dim selesai As DateTime = DateTimePickerAkhir.Value
            Dim sesi As String = ComboBoxSesi.SelectedItem
            Dim hari As String = ComboBoxHari.SelectedItem
            Dim poli As String = ComboBoxPoliTujuan.SelectedItem
            Dim tindakan As String = TextBoxTindakan.Text
            Dim kuota As String = TextBoxKuota.Text
            Dim praktisi As String = TextBoxPraktisi.Text
            Dim sekarang As DateTime = DateTime.Now

            If ComboBoxPoliTujuan.SelectedIndex = -1 Then
                MsgBox("Silakan pilih Poli terlebih dahulu.", MsgBoxStyle.Exclamation, "Validasi")
                ComboBoxPoliTujuan.Focus()
                Exit Sub
            End If

            If ComboBoxSesi.SelectedIndex = -1 Then
                MsgBox("Silakan pilih Sesi terlebih dahulu.", MsgBoxStyle.Exclamation, "Validasi")
                ComboBoxSesi.Focus()
                Exit Sub
            End If

            If ComboBoxHari.SelectedIndex = -1 Then
                MsgBox("Silakan pilih Hari terlebih dahulu.", MsgBoxStyle.Exclamation, "Validasi")
                ComboBoxHari.Focus()
                Exit Sub
            End If

            If DateTimePickerAkhir.Value = DateTimePickerMulai.Value Then
                MsgBox("Waktu selesai tidak boleh sama dengan waktu mulai.", MsgBoxStyle.Exclamation, "Validasi")
                Exit Sub
            End If


            If kuota = "" Then
                MsgBox("Kuota tidak boleh kosong.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            If tindakan = "" Then
                MsgBox("Tindakan tidak boleh kosong.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            If praktisi = "" Then
                MsgBox("Praktisi tidak boleh kosong.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            ' Cek apakah Poli pada sesi dan hari yang sama sudah ada
            Dim queryCek As String = "SELECT COUNT(*) FROM MasterRuangan " & _
                                     "WHERE NamaRuangan = '" & poli.Replace("'", "''") & "' " & _
                                     "AND Sesi = '" & sesi.Replace("'", "''") & "' " & _
                                     "AND Hari = '" & hari.Replace("'", "''") & "'"

            Dim jumlahData As Integer = Val(ReadSQLNIK(queryCek))

            If jumlahData > 0 Then
                MsgBox("Poli '" & poli & "' sudah terdaftar di sesi '" & sesi & "' pada hari '" & hari & "'.", MsgBoxStyle.Exclamation, "Gagal Simpan")
                Exit Sub
            End If

            WriteSQL("INSERT INTO MasterRuangan " & _
                  "(NamaRuangan, Tindakan, Sesi, Hari, JamAwal, JamAkhir, Kuota, Praktisi, CreatedBy, CreatedDate) VALUES (" & _
                  "'" & poli.Replace("'", "''") & "', " & _
                  "'" & tindakan.Replace("'", "''") & "', " & _
                  "'" & sesi.Replace("'", "''") & "', " & _
                  "'" & hari.Replace("'", "''") & "', " & _
                  "'" & mulai.ToString("HH:mm") & "', " & _
                  "'" & selesai.ToString("HH:mm") & "', " & _
                  "'" & kuota.Replace("'", "''") & "', " & _
                  "'" & praktisi.Replace("'", "''") & "', " & _
                  "'" & userInput.Replace("'", "''") & "', " & _
                  "GETDATE())", 4)

            MsgBox("Data berhasil disimpan.", MsgBoxStyle.Information)

            TextBoxTindakan.Clear()
            TextBoxKuota.Clear()
            TextBoxPraktisi.Clear()
            DateTimePickerMulai.Value = DateTime.Now
            DateTimePickerAkhir.Value = DateTime.Now
            ComboBoxPoliTujuan.SelectedIndex = -1
            ComboBoxSesi.SelectedIndex = -1
            ComboBoxHari.SelectedIndex = -1
            LoadSesi()
        Else
            Dim namaPasien As String = TextBoxPasienReminder.Text
            Dim NoHp As String = TextBoxNoHpReminder.Text
            Dim keperluan As String = TextBoxKeperluan.Text
            Dim tanggal As DateTime = DateTimePickerReminder.Value
            Dim sekarang As DateTime = DateTime.Now
            Dim jenisKelamin As String = TextBoxJenisKelamin.Text

            If namaPasien = "" OrElse NoHp = "" Then
                MsgBox("Nama dan nomor HP wajib diisi.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            If keperluan = "" Then
                MsgBox("Keperluan pengirimnan tidak boleh kosong.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            If keperluan.Length > 200 Then
                MsgBox("Keperluan pengiriman tidak boleh lebih dari 200 karakter.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            If tanggal.ToString("yyyy-MM-dd HH:mm") = sekarang.ToString("yyyy-MM-dd HH:mm") Then
                MsgBox("Waktu reminder tidak boleh sama dengan waktu saat ini.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            namaPasien = namaPasien.Replace("'", "''")
            NoHp = NoHp.Replace("'", "''")
            keperluan = keperluan.Replace("'", "''")

            Dim noRM As String = ReadSQLNIK("SELECT NoRekamMedis FROM MasterPasien WHERE Nama = '" & namaPasien & "'")

            WriteSQL("INSERT INTO LogReminderPasien (NamaPasien, NoHP, Keperluan, Tanggal, Status, CreatedBy, CreatedDate, NoRekamMedis, JenisKelamin) " & _
            "VALUES ('" & namaPasien & "', " & _
                   "'" & NoHp & "', " & _
                   "'" & keperluan & "', " & _
                   "'" & tanggal.ToString("yyyy-MM-dd HH:mm") & "', " & _
                   "'TERJADWAL', " & _
                   "'" & userInput & "', " & _
                   "GETDATE(), " & _
                   "'" & noRM & "', " & _
                   "'" & jenisKelamin & "')", 4)

            MsgBox("Pesan Reminder berhasil disimpan.", MsgBoxStyle.Information)

            ' Reset form
            TextBoxPasienReminder.Clear()
            TextBoxNoHpReminder.Clear()
            TextBoxKeperluan.Clear()
            DateTimePickerReminder.Value = DateTime.Now
            LoadReminder()
        End If
    End Sub

    Public Sub LoadReservasi(ByVal ruanganId As String)
        Dim dt As DataTable = ReadSQL("SELECT NamaRuangan, Tindakan, Sesi, Praktisi, Hari FROM MasterRuangan WHERE RuanganID = '" & ruanganId & "'")

        If dt.Rows.Count > 0 Then
            TextBoxRuangan.Text = dt.Rows(0)("NamaRuangan").ToString()
            TextBoxTindakanReservasi.Text = dt.Rows(0)("Tindakan").ToString()
            TextBoxSesiReservasi.Text = dt.Rows(0)("Sesi").ToString()
            TextBoxPraktisiReservasi.Text = dt.Rows(0)("Praktisi").ToString()
            TextBoxHariReservasi.Text = dt.Rows(0)("Hari").ToString()
        Else
            MsgBox("Data ruangan tidak ditemukan.", MsgBoxStyle.Exclamation)
        End If
    End Sub


    Private Sub ButtonCari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCari.Click
        'Dim stringQuery As String = "SELECT RuanganID, NamaRuangan, Tindakan, Sesi, Hari, JamAwal, JamAkhir, Kuota, Praktisi FROM MasterRuangan"
        'Dim stringQueryOrder As String = " ORDER BY CASE Hari " & _
        '                                 "WHEN 'Senin' THEN 1 " & _
        '                                 "WHEN 'Selasa' THEN 2 " & _
        '                                 "WHEN 'Rabu' THEN 3 " & _
        '                                 "WHEN 'Kamis' THEN 4 " & _
        '                                 "WHEN 'Jumat' THEN 5 " & _
        '                                 "WHEN 'Sabtu' THEN 6 " & _
        '                                 "WHEN 'Minggu' THEN 7 " & _
        '                                 "ELSE 8 END, Sesi ASC"

        'Find.Show()
        'Find.Query(stringQuery, stringQueryOrder, "FindMasterSesi", 2)
        Dim queryUpdateExpired As String = "UPDATE JadwalRuangan " & _
            "SET Status = 'EXPIRED' " & _
            "WHERE Status = 'TERJADWAL' AND TglMulai < GETDATE()"

        WriteSQL(queryUpdateExpired, 4)

        Dim stringQuery As String = ""
        Dim stringQueryOrder As String = ""

        stringQuery = "SELECT " & _
            "MR.RuanganID, " & _
            "MR.NamaRuangan AS [Poli], " & _
            "MR.Tindakan, " & _
            "MR.Sesi, " & _
            "MR.Hari, " & _
            "MR.JamAwal AS [Awal Sesi], " & _
            "MR.JamAkhir AS [Akhir Sesi], " & _
            "MR.Kuota, " & _
            "MR.Praktisi, " & _
            "ISNULL(SUM(CASE " & _
            "WHEN JR.Status <> 'CANCEL' AND JR.TglMulai >= CAST(GETDATE() AS DATE) THEN 1 " & _
            "ELSE 0 " & _
            "END), 0) AS [Jumlah Booking], " & _
            "MR.Kuota - ISNULL(SUM(CASE " & _
            "WHEN JR.Status <> 'CANCEL' AND JR.TglMulai >= CAST(GETDATE() AS DATE) THEN 1 " & _
            "ELSE 0 " & _
            "END), 0) AS [Sisa Kuota] " & _
            "FROM MasterRuangan MR " & _
            "LEFT JOIN JadwalRuangan JR ON " & _
            "JR.NamaRuangan = MR.NamaRuangan " & _
            "AND JR.Sesi = MR.Sesi " & _
            "AND (CASE DATENAME(WEEKDAY, JR.TglMulai) " & _
            "WHEN 'Monday' THEN 'Senin' " & _
            "WHEN 'Tuesday' THEN 'Selasa' " & _
            "WHEN 'Wednesday' THEN 'Rabu' " & _
            "WHEN 'Thursday' THEN 'Kamis' " & _
            "WHEN 'Friday' THEN 'Jumat' " & _
            "WHEN 'Saturday' THEN 'Sabtu' " & _
            "WHEN 'Sunday' THEN 'Minggu' " & _
            "END) = MR.Hari " & _
            "GROUP BY MR.RuanganID, MR.NamaRuangan, MR.Tindakan, MR.Sesi, MR.Hari, MR.JamAwal, MR.JamAkhir, MR.Kuota, MR.Praktisi"

        ' Bagian order dipisahkan:
        stringQueryOrder = " ORDER BY CASE MR.Hari " & _
            "WHEN 'Senin' THEN 1 " & _
            "WHEN 'Selasa' THEN 2 " & _
            "WHEN 'Rabu' THEN 3 " & _
            "WHEN 'Kamis' THEN 4 " & _
            "WHEN 'Jumat' THEN 5 " & _
            "WHEN 'Sabtu' THEN 6 " & _
            "WHEN 'Minggu' THEN 7 ELSE 8 END, MR.Sesi ASC"

        Find.Show()
        Find.Query(stringQuery, stringQueryOrder, "FindMasterSesi", 2)
    End Sub

    Public Sub LoadPasien(ByVal Trow As DataRowView)
        TextBoxNamaPasien.Text = Trow("Nama").ToString
        TextBoxNoHP.Text = Trow("No. HP").ToString
        TextBoxPasienReminder.Text = Trow("Nama").ToString
        TextBoxNoHpReminder.Text = Trow("No. HP").ToString
        TextBoxJenisKelamin.Text = Trow("Jenis Kelamin").ToString
    End Sub

    Private Sub ButtonFindPasien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFindPasien.Click
        FindPasien.SetForm("FormReservasi")
        FindPasien.ShowDialog()
    End Sub

    Private Sub CariPasienReminder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CariPasienReminder.Click
        FindPasien.SetForm("FormReminder")
        FindPasien.ShowDialog()
    End Sub

    Private Sub ButtonCariPraktisi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCariPraktisi.Click
        Find.Show()
        Find.Query("SELECT ID, Nama, Jenis, CASE WHEN StatusAktif = 1 then 'Aktif' else 'Tidak Aktif' end as StatusAktif FROM MasterDokter", " ORDER BY Nama ASC", "FindMasterDokterReservasi", 1)
    End Sub

    Private Sub ButtonCariTindakan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCariTindakan.Click
        Dim stringQuery As String = ""
        Dim stringQueryOrder As String = " ORDER BY TindakanID"

        stringQuery = "SELECT TindakanID, NamaTindakan, JenisTindakan, BiayaTindakan, JenisDokter AS 'Pelaksana', CASE WHEN Closed = 0 THEN 'Aktif' WHEN Closed = 1 THEN 'Tidak Aktif' END AS StatusTindakan from MasterTindakan"

        Find.Show()
        Find.Query(stringQuery, stringQueryOrder, "FindMasterTindakanKlinikReservasi", 2)
    End Sub

    Public Sub LoadTindakanPoli(ByRef TindakanID As String)
        Dim sql As String = "SELECT NamaTindakan FROM MasterTindakan WHERE TindakanID = '" & TindakanID & "'"
        Dim tblTindakan As DataTable = ReadSQL(sql)

        If tblTindakan.Rows.Count > 0 Then
            Dim rowTindakan As DataRow = tblTindakan.Rows(0)
            TextBoxTindakan.Text = rowTindakan("NamaTindakan").ToString
        Else
            TextBoxTindakan.Text = ""
            MessageBox.Show("Tindakan tidak ditemukan.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Public Sub LoadDokter(ByVal DokterID As String)
        Dim sql As String = "SELECT Nama FROM MasterDokter WHERE ID = '" & DokterID & "'"
        Dim tblDokter As DataTable = ReadSQL(sql)

        If tblDokter.Rows.Count > 0 Then
            Dim row As DataRow = tblDokter.Rows(0)
            TextBoxPraktisi.Text = row("Nama").ToString()
        Else
            TextBoxPraktisi.Text = ""
            MessageBox.Show("Dokter tidak ditemukan.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub SetupHeaderLogPesan()
        With DataGridViewLogPesan
            ' Header full size
            .ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
            .ColumnHeadersHeight = 40

            ' Warna header
            .EnableHeadersVisualStyles = False
            '.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 100, 200)
            '.ColumnHeadersDefaultCellStyle.ForeColor = Color.White

            ' Font header
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)

            ' Alignment
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            ' Grid tambahan
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .RowTemplate.Height = 32
        End With
    End Sub

    'Private Sub SetupZebraRowLogPesan()
    '    With DataGridViewLogPesan
    '        ' Warna dasar baris
    '        .DefaultCellStyle.BackColor = Color.White
    '        .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(235, 245, 255)

    '        ' Warna saat dipilih
    '        .DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 215, 255)
    '        .DefaultCellStyle.SelectionForeColor = Color.Black

    '        ' Font baris
    '        .DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Regular)
    '    End With
    'End Sub

    Private Sub LoadLogPesan()
        DataGridViewLogPesan.DataSource = Nothing

        Dim tglAwal As Date = dtAwalLog.Value.Date
        Dim tglAkhir As Date = dtAkhirLog.Value.Date.AddDays(1)

        Dim query As String = ""
        query &= "SELECT "
        query &= "SendingJenis, "
        query &= "SendingTujuan, "
        query &= "SendingNamaFile, "
        query &= "SendingBy, "
        query &= "SendingDate "
        query &= "FROM LogSendingWhatsappEmail "
        query &= "WHERE SendingDate >= '" & Format(tglAwal, "yyyy-MM-dd") & "' "
        query &= "AND SendingDate < '" & Format(tglAkhir, "yyyy-MM-dd") & "' "
        query &= "ORDER BY SendingDate DESC"

        Dim dt As DataTable = ReadSQL(query)

        ' === Kolom tampilan ===
        dt.Columns.Add("Jenis Pesan", GetType(String))
        dt.Columns.Add("Tujuan", GetType(String))
        dt.Columns.Add("Keperluan", GetType(String))
        dt.Columns.Add("Dikirim Oleh", GetType(String))
        dt.Columns.Add("Tanggal Kirim", GetType(String))

        For Each row As DataRow In dt.Rows
            Dim jenis As String = If(IsDBNull(row("SendingJenis")), "", row("SendingJenis").ToString())
            Dim tujuan As String = If(IsDBNull(row("SendingTujuan")), "", row("SendingTujuan").ToString())
            Dim namaFile As String = If(IsDBNull(row("SendingNamaFile")), "", row("SendingNamaFile").ToString())
            Dim byUser As String = If(IsDBNull(row("SendingBy")), "", row("SendingBy").ToString())
            Dim tglKirim As DateTime = If(IsDBNull(row("SendingDate")), DateTime.MinValue, CDate(row("SendingDate")))

            row("Jenis Pesan") = jenis
            row("Tujuan") = tujuan
            row("Keperluan") = namaFile
            row("Dikirim Oleh") = byUser
            row("Tanggal Kirim") = If(tglKirim = DateTime.MinValue, "", tglKirim.ToString("dddd, dd MMMM yyyy HH:mm", New Globalization.CultureInfo("id-ID")))
        Next

        DataGridViewLogPesan.DataSource = dt
        SetupHeaderLogPesan()
        'SetupZebraRowLogPesan()

        ' === Sembunyikan kolom mentah ===
        If DataGridViewLogPesan.Columns.Contains("SendingJenis") Then
            DataGridViewLogPesan.Columns("SendingJenis").Visible = False
            DataGridViewLogPesan.Columns("SendingTujuan").Visible = False
            DataGridViewLogPesan.Columns("SendingNamaFile").Visible = False
            DataGridViewLogPesan.Columns("SendingBy").Visible = False
            DataGridViewLogPesan.Columns("SendingDate").Visible = False
        End If

        DataGridViewLogPesan.RowTemplate.Height = 32
    End Sub

    Private Sub ButtonCariLogPesan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCariLogPesan.Click
        Try
            LoadLogPesan()
        Catch ex As Exception
            MsgBox("Gagal memuat log pesan: " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub BtnTampilSemua_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnTampilSemua.Click
        LoadReminder()
    End Sub
End Class