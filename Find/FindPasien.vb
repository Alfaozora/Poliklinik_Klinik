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

Public Class FindPasien
    Private formName As String = "FORM PENCARIAN PASIEN"
    Private userInput As String = PoliKlinik.Lbluser.Text
    Private kdProviderLokal As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'KodePPK'")
    Private TForm As String

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

    Private Sub GridControl1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridPencarian.DoubleClick
        If GridView1.FocusedRowHandle >= 0 Then
            Dim Index() As Integer = GridView1.GetSelectedRows
            If Index.Length > 0 Then
                LoadData(Index(0))
            End If
        End If
    End Sub

    Function CreateTable() As DataTable
        Dim Thasil As New DataTable

        insertRowToTbls(Thasil, "Typstring", "Nama")
        insertRowToTbls(Thasil, "Typstring", "RM")
        insertRowToTbls(Thasil, "Typstring", "Jenis Kelamin")
        insertRowToTbls(Thasil, "typdate", "Tgl. Lahir")
        insertRowToTbls(Thasil, "Typstring", "Alamat")
        insertRowToTbls(Thasil, "Typstring", "No NIK")
        insertRowToTbls(Thasil, "Typstring", "No IHS")
        insertRowToTbls(Thasil, "Typstring", "Status NIK")
        insertRowToTbls(Thasil, "Typstring", "No JKN-KIS")
        insertRowToTbls(Thasil, "Typstring", "No. HP")
        insertRowToTbls(Thasil, "Typstring", "Prolanis")
        insertRowToTbls(Thasil, "Typstring", "PRB")
        insertRowToTbls(Thasil, "Typstring", "Status Peserta")
        insertRowToTbls(Thasil, "Typstring", "FKTP")
        insertRowToTbls(Thasil, "Typstring", "FotoPath")

        Return Thasil
    End Function

    Private Sub Find_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetAwal()
        GridPencarian.DataSource = CreateTable()
        GridView1.Columns("No IHS").Visible = False
        GridView1.Columns("Status NIK").Visible = False
        GridView1.Columns("Prolanis").Visible = False
        GridView1.Columns("PRB").Visible = False
        GridView1.Columns("Status Peserta").Visible = False
        GridView1.Columns("FKTP").Visible = False
    End Sub

    Private Sub SetAwal()
        Me.CenterToScreen()

        TextBoxJenisIdentitas.Select()
        ComboBoxJenisIdentitas.SelectedIndex = 2
        ComboBoxTahun.SelectedIndex = -1
        ComboBoxBulan.SelectedIndex = -1
        ComboBoxTanggal.SelectedIndex = -1
        TextBoxJenisIdentitas.ResetText()
        TextBoxNamaIdentitas.ResetText()

        'Set Tanggal, Bulan & Tahun
        LoadTahunKelahiran()
        LoadBulanKelahiran()
        LoadTanggalKelahiran()
    End Sub

    Private Sub LoadTahunKelahiran()
        ComboBoxTahun.Items.Clear()
        Dim tahunBerjalan As Integer = Date.Today.Year

        For tahun = 1900 To tahunBerjalan
            ComboBoxTahun.Items.Add(tahun)
        Next
    End Sub

    Private Sub LoadBulanKelahiran()
        ComboBoxBulan.Items.Clear()
        ComboBoxBulan.Items.Add("Januari")
        ComboBoxBulan.Items.Add("Februari")
        ComboBoxBulan.Items.Add("Maret")
        ComboBoxBulan.Items.Add("April")
        ComboBoxBulan.Items.Add("Mei")
        ComboBoxBulan.Items.Add("Juni")
        ComboBoxBulan.Items.Add("Juli")
        ComboBoxBulan.Items.Add("Agustus")
        ComboBoxBulan.Items.Add("September")
        ComboBoxBulan.Items.Add("Oktober")
        ComboBoxBulan.Items.Add("November")
        ComboBoxBulan.Items.Add("Desember")
    End Sub

    Private Sub LoadTanggalKelahiran()
        ComboBoxTanggal.Items.Clear()
        For tanggal = 1 To 31
            ComboBoxTanggal.Items.Add(tanggal)
        Next
    End Sub

    Private Sub FindQuery()
        If Checking() = True Then
            Dim Tdata As DataTable = New DataTable

            Tdata = CreateTable()
            Tdata.Rows.Clear()

            '# Set Variabel
            Dim jenisIdenditas As String = ComboBoxJenisIdentitas.Text
            Dim noIdenditas As String = TextBoxJenisIdentitas.Text
            Dim namaIdentitas As String = TextBoxNamaIdentitas.Text
            Dim tahunLahir As String = ComboBoxTahun.Text
            Dim bulanLahir As String = Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(Replace(ComboBoxBulan.Text, "Januari", "1"), "Februari", "2"), "Maret", "3"), "April", "4"), "Mei", "5"), "Juni", "6"), "Juli", "7"), "Agustus", "8"), "September", "9"), "Oktober", "10"), "November", "11"), "Desember", "12")
            Dim tanggalLahir As String = ComboBoxTanggal.Text
            Dim queryDasar As String = "SELECT * FROM MasterPasien a LEFT JOIN MasterPasienBPJS b on a.NoKartuBPJS = b.NoKartu WHERE a.Nama LIKE '%" & namaIdentitas & "%'"
            Dim queryTahun As String = ""
            Dim queryBulan As String = ""
            Dim queryTanggal As String = ""
            Dim queryJenisKartu As String = ""
            Dim statusAktif As String = ""
            Dim statusFKTP As Boolean = True

            '# Set search Tahun
            If tahunLahir <> "" Then queryTahun = " AND YEAR(a.TglLahir) = '" & tahunLahir & "'"

            '# Set search Bulan
            If bulanLahir <> "" Then queryBulan = " AND MONTH(a.TglLahir) = '" & bulanLahir & "'"

            '# Set search Tanggal
            If tanggalLahir <> "" Then queryTanggal = " AND DAY(a.TglLahir) = '" & tanggalLahir & "'"

            ' Set Jenis Kartu
            If noIdenditas <> "" Then
                If jenisIdenditas = "No JKN-KIS" Then
                    queryJenisKartu = " AND a.NoKartuBPJS LIKE '%" & noIdenditas & "%'"
                ElseIf jenisIdenditas = "No RM" Then
                    queryJenisKartu = " AND a.NoRekamMedis LIKE '%" & noIdenditas & "%'"
                ElseIf jenisIdenditas = "NIK" Then
                    queryJenisKartu = " AND a.NoNIK LIKE '%" & noIdenditas & "%'"
                ElseIf jenisIdenditas = "No HP" Then
                    queryJenisKartu = " AND a.NoHandphone LIKE '%" & noIdenditas & "%'"
                ElseIf jenisIdenditas = "No Inhealth" Then
                    queryJenisKartu = " AND a.NoKartuInhealth LIKE '%" & noIdenditas & "%'"
                ElseIf jenisIdenditas = "No JPK" Then
                    queryJenisKartu = " AND a.NoKartuJPK LIKE '%" & noIdenditas & "%'"
                ElseIf jenisIdenditas = "No Cahaya" Then
                    queryJenisKartu = " AND a.NoKartuCahaya LIKE '%" & noIdenditas & "%'"
                End If
            End If

            Dim TblsPasien As DataTable = ReadSQL(queryDasar & queryTahun & queryBulan & queryTanggal & queryJenisKartu)

            If TblsPasien.Rows.Count > 0 Then
                For Each Trow As DataRow In TblsPasien.Rows
                    Dim Tlastnew As DataRow = Tdata.NewRow
                    Tlastnew("Nama") = Trow("Nama")
                    Tlastnew("RM") = Trow("NoRekamMedis")
                    Tlastnew("No NIK") = Trow("NoNIK")
                    Tlastnew("No IHS") = Trow("NoIHS")
                    Tlastnew("Status NIK") = Trow("PasienTanpaNIK")
                    Tlastnew("Jenis Kelamin") = Trow("JenisKelamin")
                    Tlastnew("Tgl. Lahir") = Trow("TglLahir")
                    Tlastnew("Alamat") = Trow("DomisiliAlamat")
                    Tlastnew("No. HP") = Trow("NoHandphone")
                    Tlastnew("Prolanis") = Trow("Prolanis")
                    Tlastnew("PRB") = Trow("PRB")
                    Tlastnew("No JKN-KIS") = Trow("NoKartuBPJS")
                    Tlastnew("FotoPath") = Trow("FotoPath")

                    If Trow("NoKartuBPJS").ToString.Length > 0 AndAlso CheckBridgingPcareActive() = True Then
                        If kdProviderLokal <> Trow("KdProviderPst").ToString Then
                            statusFKTP = False
                        Else
                            statusFKTP = True
                        End If

                        If statusFKTP = False Then
                            statusAktif = Trow("KetAktif") & ", tidak terdaftar di FKTP ini dan rekanan."
                        Else
                            statusAktif = Trow("KetAktif")
                        End If

                        Tlastnew("Status Peserta") = statusAktif
                        Tlastnew("FKTP") = Trow("KdProviderPst") & "~" & Trow("NmProviderPst")
                    Else
                        Tlastnew("Status Peserta") = "-"
                        Tlastnew("FKTP") = "-"
                    End If

                    Tdata.Rows.Add(Tlastnew)
                Next
            Else
                MsgBox("Data tidak ditemukan.", MsgBoxStyle.Exclamation, "Warning!")
            End If

            GridPencarian.DataSource = Tdata
            GridView1.Columns("No IHS").Visible = False
            GridView1.Columns("Status NIK").Visible = False
            GridView1.Columns("Prolanis").Visible = False
            GridView1.Columns("PRB").Visible = False
            GridView1.Columns("Status Peserta").Visible = False
            GridView1.Columns("FKTP").Visible = False
        End If
    End Sub

    Private Sub LoadData(ByRef Baris As Integer)
        If GridView1.RowCount > 0 Then
            Dim Grdrow As DataRowView = GridView1.GetRow(Baris)

            Select TForm
                Case "PendaftaranAwal"
                    FormPendaftaranAwal.LoadPasien(Grdrow)
                Case "MasterPasien"
                    FormMasterPasien.LoadPasien(Grdrow)
                Case "ReportDaftarKunjunganPeserta"
                    ReportDaftarKunjunganPesien.LoadPasien(Grdrow)
                Case "ReportLogPaketTindakan"
                    ReportLogPaketTindakan.LoadPasien(Grdrow)
                Case "FormReservasi"
                    FormReservasi.LoadPasien(Grdrow)
                Case "FormReminder"
                    FormReservasi.LoadPasien(Grdrow)
            End Select

            Me.Close()
        End If
    End Sub

    Function Checking() As Boolean
        '# Cek Inputan Tahun
        If ComboBoxTahun.Text <> "" Then
            If ComboBoxTahun.FindStringExact(ComboBoxTahun.Text) < 0 Then
                MsgBox("Cek inputan tahun lahir.", MsgBoxStyle.Exclamation, "Warning!")

                Return False
            End If
        End If

        '# Cek Inputan Bulan
        If ComboBoxBulan.Text <> "" Then
            If ComboBoxBulan.FindStringExact(ComboBoxBulan.Text) < 0 Then
                MsgBox("Cek inputan bulan lahir.", MsgBoxStyle.Exclamation, "Warning!")

                Return False
            End If
        End If

        '# Cek Inputan Tanggal
        If ComboBoxTanggal.Text <> "" Then
            If ComboBoxTanggal.FindStringExact(ComboBoxTanggal.Text) < 0 Then
                MsgBox("Cek inputan tanggal lahir.", MsgBoxStyle.Exclamation, "Warning!")

                Return False
            End If
        End If

        Return True
    End Function

    Private Sub ButtonFindPasien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFindPasien.Click
        FindQuery()
    End Sub

    Private Sub TextBoxJenisIdentitas_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxJenisIdentitas.KeyDown
        If e.KeyCode = Keys.Enter Then FindQuery()
    End Sub

    Private Sub TextBoxNamaIdentitas_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxNamaIdentitas.KeyDown
        If e.KeyCode = Keys.Enter Then FindQuery()
    End Sub

    Private Sub ComboBoxTahun_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBoxTahun.KeyDown
        If e.KeyCode = Keys.Enter Then FindQuery()
    End Sub

    Private Sub ComboBoxBulan_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBoxBulan.KeyDown
        If e.KeyCode = Keys.Enter Then FindQuery()
    End Sub

    Private Sub ComboBoxTanggal_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboBoxTanggal.KeyDown
        If e.KeyCode = Keys.Enter Then FindQuery()
    End Sub

    Public Sub SetForm(ByRef Form As String)
        Me.BringToFront()
        TForm = Form
    End Sub
End Class