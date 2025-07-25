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

Public Class FormInputInformedConsent
    Private formName As String = "DETAIL INFORMED CONSENT"
    Private TForm As String
    Private userInput As String = PoliKlinik.Lbluser.Text
    Private tblsRekamMedis As DataTable
    Private tindakanID As String
    Private statusPersetujuan As String
    Private jenisTransaksi As String

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

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub SetAwal()
        ' Clear Data Penanggung Jawab
        CheckBoxPenanggungJawab.Checked = False
        TextBoxPenanggungJawabNama.ResetText()
        TextBoxPenanggungJawabUsia.ResetText()
        ComboBoxPenanggungJawabJenisKelamin.SelectedIndex = 0
        TextBoxPenanggungJawabHubunganPasien.ResetText()
        TextBoxPenanggungJawabAlamat.ResetText()

        ' Clear Data Saksi Pasien
        CheckBoxSaksiPasien.Checked = False
        TextBoxSaksiPasienNama.ResetText()
        TextBoxSaksiPasienHubunganPasien.ResetText()

        Me.CenterToScreen()
    End Sub

    Public Sub SetForm(ByRef Form As String, ByRef tbls As DataTable, ByRef txTindakanID As String, ByRef txStatusPersetujuan As Boolean, ByRef txJenisTransaksi As String)
        Me.BringToFront()
        TForm = Form
        tindakanID = txTindakanID
        tblsRekamMedis = tbls
        jenisTransaksi = txJenisTransaksi

        If txStatusPersetujuan = True Then
            statusPersetujuan = "true"
        ElseIf txStatusPersetujuan = False Then
            statusPersetujuan = "false"
        End If

        SetAwal()
        SetClear()
        SetData()
    End Sub

    Private Sub SetClear()
        TextBoxDiagnosa.ResetText()
        TextBoxDasarDiagnosa.ResetText()
        TextBoxNamaTindakan.ResetText()
        TextBoxBiayaTindakan.ResetText()

        ComboBoxIndikasiTindakan.ResetText()
        ComboBoxTataCara.ResetText()
        ComboBoxTujuanTindakan.ResetText()
        ComboBoxResiko.ResetText()
        ComboBoxKomplikasi.ResetText()
        ComboBoxPrognosa.ResetText()
        ComboBoxAlternatif.ResetText()
    End Sub

    Private Sub SetData()
        Dim idTransaksi As String = ""

        ComboBoxIndikasiTindakan.Items.Clear()
        ComboBoxTataCara.Items.Clear()
        ComboBoxTujuanTindakan.Items.Clear()
        ComboBoxResiko.Items.Clear()
        ComboBoxKomplikasi.Items.Clear()
        ComboBoxPrognosa.Items.Clear()
        ComboBoxAlternatif.Items.Clear()

        Dim tblMasterInformedConsent As DataTable = New DataTable

        If jenisTransaksi = "UMUM" Or jenisTransaksi = "POLI" Then
            tblMasterInformedConsent = ReadSQL("SELECT * FROM Klinik_MasterTindakanInformedConsent " & _
                                               "WHERE NamaTindakan IN (SELECT TindakanInformedConsent FROM MasterTindakan WHERE TindakanID = '" & tindakanID & "')")
        ElseIf jenisTransaksi = "GIGI" Then
            tblMasterInformedConsent = ReadSQL("SELECT * FROM Klinik_MasterTindakanInformedConsent " & _
                                               "WHERE NamaTindakan IN (SELECT TindakanInformedConsent FROM MasterTindakanGigi WHERE TindakanID = '" & tindakanID & "')")
        End If

        For Each Trow As DataRow In tblMasterInformedConsent.Rows
            If Trow("NamaInformasi") = "Indikasi Tindakan" Then
                ComboBoxIndikasiTindakan.Items.Add(Trow("KeteranganInformasi"))
            ElseIf Trow("NamaInformasi") = "Tata Cara" Then
                ComboBoxTataCara.Items.Add(Trow("KeteranganInformasi"))
            ElseIf Trow("NamaInformasi") = "Tujuan Tindakan" Then
                ComboBoxTujuanTindakan.Items.Add(Trow("KeteranganInformasi"))
            ElseIf Trow("NamaInformasi") = "Risiko" Then
                ComboBoxResiko.Items.Add(Trow("KeteranganInformasi"))
            ElseIf Trow("NamaInformasi") = "Komplikasi " Then
                ComboBoxKomplikasi.Items.Add(Trow("KeteranganInformasi"))
            ElseIf Trow("NamaInformasi") = "Prognosis" Then
                ComboBoxPrognosa.Items.Add(Trow("KeteranganInformasi"))
            ElseIf Trow("NamaInformasi") = "Alternatif tindakan dan risiko" Then
                ComboBoxAlternatif.Items.Add(Trow("KeteranganInformasi"))
            ElseIf Trow("NamaInformasi") = "Dasar Diagnosis" Then
                TextBoxDasarDiagnosa.Text = Trow("KeteranganInformasi")
            End If
        Next

        SetComboBoxSelectedIndex(ComboBoxIndikasiTindakan)
        SetComboBoxSelectedIndex(ComboBoxTataCara)
        SetComboBoxSelectedIndex(ComboBoxTujuanTindakan)
        SetComboBoxSelectedIndex(ComboBoxResiko)
        SetComboBoxSelectedIndex(ComboBoxKomplikasi)
        SetComboBoxSelectedIndex(ComboBoxPrognosa)
        SetComboBoxSelectedIndex(ComboBoxAlternatif)

        If tblsRekamMedis.Rows.Count > 0 Then
            For Each Trow2 As DataRow In tblsRekamMedis.Rows
                idTransaksi = Trow2("NoUrut")

                If Trow2("KeluhanTambahan") <> "-" And Trow2("KeluhanTambahan") <> "" Then
                    TextBoxDasarDiagnosa.Text = Trow2("KeluhanUtama") & ", " & Trow2("KeluhanTambahan")
                Else
                    TextBoxDasarDiagnosa.Text = Trow2("KeluhanUtama")
                End If
            Next
        End If

        ' Get Diagnosa
        Dim tblsDiagnosa As DataTable = ReadSQL("SELECT * FROM TransaksiDetailDiagnosa WHERE NoTransaksi = '" & idTransaksi & "' AND DeletedDate IS NULL")

        If tblsDiagnosa.Rows.Count > 0 Then
            For Each trowDiagnosa As DataRow In tblsDiagnosa.Rows
                If trowDiagnosa("JenisDiagnosa") = "Diagnosa Utama" Then
                    TextBoxDiagnosa.Text = trowDiagnosa("KeteranganDiagnosa") & " (" & trowDiagnosa("KodeDiagnosa") & ")"
                End If
            Next
        End If

        If tindakanID.Length > 0 Then
            Dim tblsTindakan As DataTable = New DataTable

            If jenisTransaksi = "UMUM" Or jenisTransaksi = "POLI" Then
                tblsTindakan = ReadSQL("SELECT NamaTindakan, BiayaTindakan FROM MasterTindakan WHERE TindakanID = '" & tindakanID & "'")
            ElseIf jenisTransaksi = "GIGI" Then
                tblsTindakan = ReadSQL("SELECT NamaTindakan, BiayaTindakan FROM MasterTindakanGigi WHERE TindakanID = '" & tindakanID & "'")
            End If

            For Each Trow3 As DataRow In tblsTindakan.Rows
                TextBoxNamaTindakan.Text = Trow3("NamaTindakan")
                TextBoxBiayaTindakan.Text = Trow3("BiayaTindakan")
            Next
        End If
    End Sub

    Private Sub SetComboBoxSelectedIndex(ByRef comboBox As System.Windows.Forms.ComboBox)
        If comboBox.Items.Count = 1 Then
            comboBox.SelectedIndex = 0
        Else
            comboBox.SelectedIndex = -1
        End If
    End Sub

    Private Sub SaveData()
        Try
            If ValidasiPostInformedConsent() = True Then
                Dim Trow As DataRow = tblsRekamMedis.Rows(0)
                Dim baseURL As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'web_service_klinik'")
                Dim urlWebService As String = baseURL & "api/informed_consent"
                Dim parameter As String = ""
                Dim uri_message As String = ""

                Dim kodeLokasi As String = ReadSQLNIK("select StrValue from MsConfig where ConfigName = 'NoPoli'")
                Dim keteranganLokasi As String = ReadSQLNIK("select StrValue from MsConfig where ConfigName = 'Kota'")

                ' Set Jenis Kelamin
                Dim jenisKelamin As String = ""
                If ComboBoxPenanggungJawabJenisKelamin.Text = "Laki-laki" Then
                    jenisKelamin = "L"
                ElseIf ComboBoxPenanggungJawabJenisKelamin.Text = "Perempuan" Then
                    jenisKelamin = "P"
                End If

                ' Parameter Saksi Pasien
                Dim statusSaksiPasien As String = ""
                If CheckBoxSaksiPasien.Checked = True Then
                    statusSaksiPasien = "false"
                ElseIf CheckBoxSaksiPasien.Checked = False Then
                    statusSaksiPasien = "true"
                End If

                parameter = "{" & _
                              """tgl_transaksi"" : """ & Format(Trow("TglTransaksi"), "yyyy-MM-dd HH:mm:ss.fff") & """," & _
                              """kode_lokasi"" : """ & kodeLokasi & """," & _
                              """ket_lokasi"" : """ & keteranganLokasi & """," & _
                              """jenis_poli"" : """ & Trow("JenisPoli") & """," & _
                              """status_transaksi"" : ""Pending""," & _
                              """no_transaksi"" : """ & Trow("NoUrut") & """," & _
                              """no_rekam_medis"" : """ & Trow("IDInternet") & """," & _
                              """no_nik"" : """ & Trow("NoNIK") & """," & _
                              """nama_pasien"" : """ & Trow("Nama") & """," & _
                              """umur_pasien"" : """ & HitungUsia(Trow("TglLahir")) & """," & _
                              """jenis_kelamin_pasien"" : """ & Trow("JenisKelamin") & """," & _
                              """alamat_pasien"" : """ & Trow("DomisiliAlamat") & """," & _
                              """id_dokter"" : """ & Trow("KodeDokter") & """," & _
                              """nama_dokter"" : """ & Trow("NamaDokter") & """," & _
                              """id_perawat"" : null," & _
                              """nama_perawat"" : """ & Trow("NamaPerawat") & """," & _
                              """penerima_informasi"" : """ & Trow("Nama") & """," & _
                              """ket_diagnosis"" : """ & TextBoxDiagnosa.Text & """," & _
                              """dasar_diagnosis"" : """ & TextBoxDasarDiagnosa.Text & """," & _
                              """id_tindakan"" : """ & tindakanID & """," & _
                              """ket_tindakan"" : """ & TextBoxNamaTindakan.Text & """," & _
                              """indikasi_tindakan"" : """ & ComboBoxIndikasiTindakan.Text & """," & _
                              """tata_cara"" : """ & ComboBoxTataCara.Text & """," & _
                              """tujuan_tindakan"" : """ & ComboBoxTujuanTindakan.Text & """," & _
                              """risiko"" : """ & ComboBoxResiko.Text & """," & _
                              """komplikasi"" : """ & ComboBoxKomplikasi.Text & """," & _
                              """prognosis"" : """ & ComboBoxPrognosa.Text & """," & _
                              """alternatif_tindakan"" : """ & ComboBoxAlternatif.Text & """," & _
                              """biaya_tindakan"": " & CDbl(TextBoxBiayaTindakan.Text) & "," & _
                              """status_persetujuan"" : " & statusPersetujuan & "," & _
                              """nama_penanggung_jawab"" : """ & TextBoxPenanggungJawabNama.Text & """," & _
                              """umur_penanggung_jawab"" : """ & TextBoxPenanggungJawabUsia.Text & """," & _
                              """jenis_kelamin_penanggung_jawab"" : """ & jenisKelamin & """," & _
                              """hubungan_penanggung_jawab"" : """ & TextBoxPenanggungJawabHubunganPasien.Text & """," & _
                              """alamat_penanggung_jawab"" : """ & TextBoxPenanggungJawabAlamat.Text & """," & _
                              """status_saksi_pasien"" : " & statusSaksiPasien & "," & _
                              """nama_saksi_pasien"" : """ & TextBoxSaksiPasienNama.Text & """," & _
                              """hubungan_saksi_pasien"" : """ & TextBoxSaksiPasienHubunganPasien.Text & """" & _
                             "}"

                uri_message = urlWebService

                Dim response As String = InsertDataAPI(parameter, uri_message)

                Dim jsonArray As JArray = JArray.Parse(response)

                Dim responseObj As JObject = jsonArray(0)("response")
                Dim responseMessage As String = responseObj("message").ToString()

                Dim metaDataObj As JObject = jsonArray(0)("metaData")
                Dim metaDataMessage As String = metaDataObj("message").ToString()

                If metaDataMessage = "TRANSACTION_COMPLETE" Then
                    MsgBox(responseMessage, MsgBoxStyle.Critical, "Warning!")
                Else
                    MsgBox(responseMessage & vbCr & vbLf & "Kunjungi dashboard web untuk melakukan tanda tangan.", MsgBoxStyle.Information, "Success!")
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Function ValidasiPostInformedConsent() As Boolean
        ' Validasi hubungan keluarga valid / tidak
        If CheckBoxPenanggungJawab.Checked = False And TextBoxPenanggungJawabHubunganPasien.Text = "Pasien Sendiri" Then MsgBox("cek inputan hubungan keluarga.", MsgBoxStyle.Exclamation, "Warning!") : Return False

        ' Validasi Nama Penanggung Jawab
        If TextBoxPenanggungJawabNama.Text.Length = 0 Then MsgBox("Masukkan nama penanggung jawab terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!") : Return False

        ' Validasi Usia Penanggung Jawab
        If TextBoxPenanggungJawabUsia.Text.Length = 0 Then MsgBox("Masukkan usia penanggung jawab terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!") : Return False

        ' Validasi Jenis Kelamin Penanggung Jawab
        If ComboBoxPenanggungJawabJenisKelamin.Text.Length = 0 Then MsgBox("Masukkan jenis kelamin penanggung jawab terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!") : Return False

        ' Validasi Hubungan Penanggung Jawab
        If TextBoxPenanggungJawabHubunganPasien.Text.Length = 0 Then MsgBox("Masukkan hubungan keluarga penanggung jawab terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!") : Return False

        ' Validasi Alamat Penanggung Jawab
        If TextBoxPenanggungJawabAlamat.Text.Length = 0 Then MsgBox("Masukkan alamat penanggung jawab terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!") : Return False

        ' Validasi Nama Saksi Pasien
        If CheckBoxSaksiPasien.Checked = False And TextBoxSaksiPasienNama.Text.Length = 0 Then MsgBox("Masukkan nama saksi pasien terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!") : Return False

        ' Validasi Hubungan Saksi Pasien
        If CheckBoxSaksiPasien.Checked = False And TextBoxSaksiPasienHubunganPasien.Text.Length = 0 Then MsgBox("Masukkan hubungan saksi pasien terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!") : Return False

        ' Diagnosa
        If TextBoxDiagnosa.Text.Length = 0 Then MsgBox("Masukkan diagnosa terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!") : Return False

        ' Dasar diagnosis
        If TextBoxDasarDiagnosa.Text.Length = 0 Or TextBoxDasarDiagnosa.Text = "-" Then MsgBox("Masukkan dasar diagnosa terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!") : Return False

        ' Tindakan Kedokteran
        If TextBoxNamaTindakan.Text.Length = 0 Then MsgBox("Masukkan tindakan kedokteran terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!") : Return False

        ' Indikasi Tindakan
        If ComboBoxIndikasiTindakan.Text.Length = 0 Then MsgBox("Masukkan indikasi tindakan terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!") : Return False

        ' Tata Cara
        If ComboBoxTataCara.Text.Length = 0 Then MsgBox("Masukkan tata cara terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!") : Return False

        ' Tujuan Tindakan
        If ComboBoxTujuanTindakan.Text.Length = 0 Then MsgBox("Masukkan tujuan tindakan terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!") : Return False

        ' Risiko
        If ComboBoxResiko.Text.Length = 0 Then MsgBox("Masukkan risiko terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!") : Return False

        ' Komplikasi
        If ComboBoxKomplikasi.Text.Length = 0 Then MsgBox("Masukkan komplikasi terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!") : Return False

        ' Prognosis
        If ComboBoxPrognosa.Text.Length = 0 Then MsgBox("Masukkan prognosis terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!") : Return False

        ' Alternatif tindakan dan risiko
        If ComboBoxAlternatif.Text.Length = 0 Then MsgBox("Masukkan alternatif tindakan dan risiko terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!") : Return False

        Return True
    End Function

    Private Sub ComboBoxStatusKeluarga_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        If Not IsComboBoxItemValid(DirectCast(sender, System.Windows.Forms.ComboBox)) Then
            MsgBox("Data yang dimasukkan tidak valid. Silakan pilih item dari daftar yang tersedia.", MsgBoxStyle.Exclamation, "Warning!")
            e.Cancel = True
        End If
    End Sub

    Private Sub CheckBoxPenanggungJawab_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxPenanggungJawab.CheckedChanged
        If CheckBoxPenanggungJawab.Checked = True Then
            If tblsRekamMedis.Rows.Count > 0 Then
                For Each Trow As DataRow In tblsRekamMedis.Rows
                    TextBoxPenanggungJawabNama.Text = Trow("Nama")
                    TextBoxPenanggungJawabUsia.Text = HitungUsia(Trow("TglLahir"))
                    TextBoxPenanggungJawabHubunganPasien.Text = "Pasien Sendiri"
                    TextBoxPenanggungJawabAlamat.Text = Trow("DomisiliAlamat")

                    If Trow("JenisKelamin").ToString = "L" Then
                        ComboBoxPenanggungJawabJenisKelamin.Text = "Laki-laki"
                    ElseIf Trow("JenisKelamin").ToString = "P" Then
                        ComboBoxPenanggungJawabJenisKelamin.Text = "Perempuan"
                    End If

                    TextBoxPenanggungJawabNama.Enabled = False
                    TextBoxPenanggungJawabUsia.Enabled = False
                    ComboBoxPenanggungJawabJenisKelamin.Enabled = False
                    TextBoxPenanggungJawabHubunganPasien.Enabled = False
                    TextBoxPenanggungJawabAlamat.Enabled = False
                Next
            End If
        Else
            TextBoxPenanggungJawabNama.ResetText()
            TextBoxPenanggungJawabUsia.ResetText()
            ComboBoxPenanggungJawabJenisKelamin.SelectedIndex = -1
            TextBoxPenanggungJawabHubunganPasien.ResetText()
            TextBoxPenanggungJawabAlamat.ResetText()

            TextBoxPenanggungJawabNama.Enabled = True
            TextBoxPenanggungJawabUsia.Enabled = True
            ComboBoxPenanggungJawabJenisKelamin.Enabled = True
            TextBoxPenanggungJawabHubunganPasien.Enabled = True
            TextBoxPenanggungJawabAlamat.Enabled = True
        End If
    End Sub

    Private Sub ButtonSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSave.Click
        SaveData()
    End Sub

    Private Sub ComboBoxJenisKelamin_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ComboBoxPenanggungJawabJenisKelamin.Validating
        If Not IsComboBoxItemValid(DirectCast(sender, System.Windows.Forms.ComboBox)) Then
            MsgBox("Data yang dimasukkan tidak valid. Silakan pilih item dari daftar yang tersedia.", MsgBoxStyle.Exclamation, "Warning!")
            e.Cancel = True
        End If
    End Sub

    Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
        Me.Close()
    End Sub

    Private Sub CheckBoxSaksiPasien_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxSaksiPasien.CheckedChanged
        ' Set Clear
        TextBoxSaksiPasienNama.ResetText()
        TextBoxSaksiPasienHubunganPasien.ResetText()

        If CheckBoxSaksiPasien.Checked = True Then
            TextBoxSaksiPasienNama.Text = "-"
            TextBoxSaksiPasienHubunganPasien.Text = "-"

            TextBoxSaksiPasienNama.Enabled = False
            TextBoxSaksiPasienHubunganPasien.Enabled = False

            PanelDetailSaksiPasien.Visible = False
        Else
            TextBoxSaksiPasienNama.Enabled = True
            TextBoxSaksiPasienHubunganPasien.Enabled = True

            PanelDetailSaksiPasien.Visible = True
        End If
    End Sub
End Class