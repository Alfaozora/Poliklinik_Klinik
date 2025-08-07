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

Public Class RepairNoKunjunganBPJS
    Private formName As String = "Repair No Kunjungan BPJS"
    'Private userInput As String = PoliKlinik.Lbluser.Text
    Private kdProviderLokal As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'KodePPK'")
    Private urlPcare As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_base_url'")

    Private Sub RepairNoKunjunganBPJS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
            'Me.MdiParent = PoliKlinik
            'Me.Dock = DockStyle.Fill

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Public Sub GetNoKunjunganBPJS(ByVal noKartu As String, ByRef TextBoxNoKunjunganBPJS As TextBox)
        Try
            Dim uri As String = urlPcare & "kunjungan/peserta/" & noKartu
            Dim getResponse As String = getDataFromPcare(uri)

            ' Tampilkan untuk debug isi respon mentah
            'MsgBox("Respon JSON Mentah: " & getResponse)

            ' Deserialize ke List karena response adalah array
            Dim daftarKunjungan As List(Of v4_BPJS_Kunjungan) = JsonConvert.DeserializeObject(Of List(Of v4_BPJS_Kunjungan))(getResponse)

            ' Cek data dan ambil noKunjungan pertama
            If daftarKunjungan.Count > 0 Then
                Dim firstItem = daftarKunjungan(0)

                If firstItem.metaData IsNot Nothing AndAlso firstItem.metaData.message <> "NO_CONTENT" Then
                    If firstItem.response IsNot Nothing AndAlso firstItem.response.list IsNot Nothing Then
                        If firstItem.response.list.Length > 0 Then
                            ' Ambil noKunjungan pertama dari halaman pertama
                            Dim noKunjungan As String = firstItem.response.list(0).noKunjungan

                            ' Tampilkan ke TextBox
                            TextBoxNoKunjunganBPJS.Text = noKunjungan
                            Dim noUrut As String = TextBoxNoUrut.Text.Trim()

                            If noUrut <> "" Then
                                Dim queryCheck As String = "SELECT NoKunjunganBPJS FROM TransaksiDetail WHERE NoUrut = '" & noUrut & "'"
                                Dim tblCheck As DataTable = ReadSQL(queryCheck)

                                If tblCheck.Rows.Count > 0 Then
                                    Dim noKunjunganDB As String = tblCheck.Rows(0)("NoKunjunganBPJS").ToString()
                                    If noKunjunganDB = noKunjungan Then
                                        MsgBox("No. Kunjungan sudah ada di database.")
                                    ElseIf String.IsNullOrEmpty(noKunjunganDB) Then
                                        Dim konfirmasi As DialogResult = MessageBox.Show("No. Kunjungan belum ada di database. Apakah ingin mengupdate dengan data dari BPJS?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                                        If konfirmasi = DialogResult.Yes Then
                                            ' Update ke database
                                            WriteSQL("UPDATE TransaksiDetail SET NoKunjunganBPJS = '" & noKunjungan & "' WHERE NoUrut = '" & noUrut & "'", 4)
                                            MsgBox("No. Kunjungan berhasil diupdate ke database.")
                                        End If
                                    Else
                                        MsgBox("No. Kunjungan berbeda dengan database.")
                                    End If
                                Else
                                    MsgBox("Data dengan NoUrut tersebut tidak ditemukan di database.")
                                End If
                            Else
                                MsgBox("NoUrut kosong. Tidak bisa cek ke database.")
                            End If
                        End If
                    End If
                End If
            Else
                MsgBox("Data kunjungan tidak ditemukan.")
            End If
        Catch ex As Exception
            MsgBox("Terjadi kesalahan: " & ex.Message)
        End Try
    End Sub

    Private Sub ButtonCekKIS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCekKIS.Click
        Dim noUrut As String = TextBoxNoUrut.Text.Trim()

        If noUrut <> "" Then
            ' Ambil NoKartuBPJS berdasarkan NoUrut
            Dim query As String = "SELECT MP.NoKartuBPJS " & _
                                  "FROM TransaksiDetail TD " & _
                                  "JOIN MasterPasien MP ON TD.IDInternet = MP.NoRekamMedis " & _
                                  "WHERE TD.NoUrut = '" & noUrut & "'"

            Dim tblCheckNoBPJS As DataTable = ReadSQL(query)

            If tblCheckNoBPJS.Rows.Count > 0 Then
                Dim noKartuBPJS As String = tblCheckNoBPJS.Rows(0)("NoKartuBPJS").ToString()

                ' Tampilkan dulu untuk debug (opsional)
                ' MsgBox("NoKartuBPJS: " & noKartuBPJS)

                ' Ambil NoKunjunganBPJS dan isi ke TextBox
                GetNoKunjunganBPJS(noKartuBPJS, TextBoxNoKunjunganBPJS)
            Else
                MsgBox("No Kartu BPJS tidak ditemukan untuk NoUrut tersebut.")
            End If
        Else
            MsgBox("Silakan isi NoUrut terlebih dahulu.")
        End If
    End Sub

    Private Sub CLearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CLearToolStripMenuItem.Click
        TextBoxNoUrut.ResetText()
        TextBoxNoKunjunganBPJS.ResetText()
    End Sub
End Class