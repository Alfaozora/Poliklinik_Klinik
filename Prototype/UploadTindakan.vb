Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Drawing
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Threading

Public Class UploadTindakan
    ' Variabel Umum
    Private formName As String = "Form Upload Tindakan" ' Nama form

    Dim thread As System.Threading.Thread
    Dim conn As OleDbConnection
    Dim dtr As OleDbDataReader
    Dim dta As OleDbDataAdapter
    Dim cmd As OleDbCommand
    Dim dts As DataSet
    Dim excel As String
    Dim opFileDialog As New OpenFileDialog()

    Private userInput As String = PoliKlinik.Lbluser.Text
    Private DB_Poliklinik As TLcon

    Private Class varJSON
        Public result As String
        Public rows() As JSON_result

        Public Class JSON_result
            Public Sales_Office As String
            Public Kode_Admin As String
            Public Komponen As String
            Public Nilai As Double
        End Class
    End Class

    Private Sub PanelTop_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelTop.Paint
        Try
            e.Graphics.DrawString(formName, New Font("Arial", 12, FontStyle.Bold), Brushes.White, New Point(10, 10))
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub SetGrid()
        ProgressBar1.Value = 0
        ProgressBar1.Visible = False
        ButtonSimpanData.Enabled = False
    End Sub

    Private Sub UploadTindakan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        Me.MdiParent = PoliKlinik
        Me.Dock = DockStyle.Fill

        SetGrid()
        SetConnection()

        '# Load Font DataGridView
        DataGridViewTindakan.DefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        DataGridViewTindakan.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI Semibold", 10, FontStyle.Bold)
    End Sub

    Private Sub SetConnection()
        ' Set Parameter Server Online
        Dim serverOnline_IP As String = Utility.GetConfig("ServerOnline_IP")
        Dim serverOnline_UserID As String = Utility.GetConfig("ServerOnline_UserID")
        Dim serverOnline_Password As String = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerOnline_Password"), "albert")

        ' Set DB Poliklinik
        DB_Poliklinik.Tip = serverOnline_IP
        DB_Poliklinik.Tid = serverOnline_UserID
        DB_Poliklinik.Tpass = serverOnline_Password
        DB_Poliklinik.Tdb = Utility.GetConfig("ServerOnlinePoli_DB")
    End Sub

    Private Sub ValidasiGridTindakan()
        Try
            Dim tblsTindakan As DataTable = DataGridViewTindakan.DataSource
            Dim statusValidasi As Boolean = True

            If tblsTindakan IsNot Nothing AndAlso tblsTindakan.Rows.Count > 0 Then
                ButtonSimpanData.Enabled = False
                ProgressBar1.Visible = True
                Dim index As Integer = 0
                Dim jumlah As Integer = 0
                Dim jenisPoli As String = ""

                ' Set Jenis Poli
                If RadioButtonPoliUmum.Checked = True Then jenisPoli = "POLI UMUM"
                If RadioButtonPoliGigi.Checked = True Then jenisPoli = "POLI GIGI"

                ' Validasi
                For Each rowValidasi As DataRow In tblsTindakan.Rows
                    index = index + 1

                    ' Validasi Nama Tindakan
                    If rowValidasi("Nama Tindakan").ToString.Trim = "" Or rowValidasi("Nama Tindakan").ToString.Trim = "-" Then
                        MsgBox("Nama Tindakan tidak boleh kosong. (Row ke-" & index & ")", MsgBoxStyle.Exclamation, "Warning!")
                        statusValidasi = False
                        Exit For
                    End If

                    ' Validasi Jenis Tindakan
                    If rowValidasi("Jenis Tindakan").ToString.Trim = "" Or rowValidasi("Jenis Tindakan").ToString.Trim = "-" Then
                        MsgBox("Jenis Tindakan tidak boleh kosong. (Row ke-" & index & ")", MsgBoxStyle.Exclamation, "Warning!")
                        statusValidasi = False
                        Exit For
                    End If

                    ' Validasi Status Aktif
                    If rowValidasi("Aktif").ToString.Trim <> "Ya" And rowValidasi("Aktif").ToString.Trim <> "Tidak" Then
                        MsgBox("Status Aktif tidak sesuai. (Row ke-" & index & ")", MsgBoxStyle.Exclamation, "Warning!")
                        statusValidasi = False
                        Exit For
                    End If

                    If rowValidasi("Kode Tindakan").ToString.Trim = "" Or rowValidasi("Kode Tindakan").ToString.Trim = "-" Then
                        ' Validasi Nama Tindakan & Jenis Tindakan
                        If CheckThemysql("SELECT * FROM mastertindakanpoli a WHERE a.jenispoli = '" & jenisPoli & "' AND a.namatindakan = '" & rowValidasi("Nama Tindakan") & "' AND a.jenistindakan = '" & rowValidasi("Jenis Tindakan") & "' AND a.closed = 0;", DB_Poliklinik) = True Then
                            MsgBox("Nama / Jenis Tindakan sudah pernah diinput. Mohon cek kembali. (Row ke-" & index & ")", MsgBoxStyle.Exclamation, "Warning!")
                            statusValidasi = False
                            Exit For
                        End If

                        ' Validasi Status Tidak Aktif
                        If rowValidasi("Aktif").ToString.Trim = "Tidak" Then
                            MsgBox("Status Aktif tidak bisa di setting untuk tindakan baru. (Row ke-" & index & ")", MsgBoxStyle.Exclamation, "Warning!")
                            statusValidasi = False
                            Exit For
                        End If
                    Else
                        ' Validasi Kode Tindakan
                        If CheckThemysql("SELECT * FROM mastertindakanpoli a WHERE a.kodetindakan IN ('" & rowValidasi("Kode Tindakan") & "');", DB_Poliklinik) = False Then
                            MsgBox("Kode Tindakan tidak valid. Mohon cek kembali. (Row ke-" & index & ")", MsgBoxStyle.Exclamation, "Warning!")
                            statusValidasi = False
                            Exit For
                        End If

                        ' Validasi Nama Tindakan & Jenis Tindakan
                        If CheckThemysql("SELECT * FROM mastertindakanpoli a WHERE a.jenispoli = '" & jenisPoli & "' AND a.namatindakan = '" & rowValidasi("Nama Tindakan") & "' AND a.jenistindakan = '" & rowValidasi("Jenis Tindakan") & "' AND a.closed = 0 AND a.kodetindakan NOT IN ('" & rowValidasi("Kode Tindakan") & "');", DB_Poliklinik) = True Then
                            MsgBox("Nama / Jenis Tindakan sudah pernah diinput. Mohon cek kembali. (Row ke-" & index & ")", MsgBoxStyle.Exclamation, "Warning!")
                            statusValidasi = False
                            Exit For
                        End If
                    End If

                    ' Validasi Keterangan
                    If rowValidasi("Keterangan").ToString.Trim = "" Then rowValidasi("Keterangan") = "-"

                    Dim procent As Integer = index * 100 / tblsTindakan.Rows.Count
                    ProgressBar1.Value = procent
                Next

                If statusValidasi = False Then
                    ' Failed
                    ButtonSimpanData.Enabled = False
                Else
                    ' Success
                    ButtonSimpanData.Enabled = True

                    ' Set Enable / Disable
                    If RadioButtonTindakan.Checked = True Then RadioButtonTindakanDetail.Enabled = False
                    If RadioButtonTindakanDetail.Checked = True Then RadioButtonTindakan.Enabled = False
                    If RadioButtonPoliUmum.Checked = True Then RadioButtonPoliGigi.Enabled = False
                    If RadioButtonPoliGigi.Checked = True Then RadioButtonPoliUmum.Enabled = False

                    MsgBox(tblsTindakan.Rows.Count & " data berhasil divalidasi, klik tombol simpan untuk melanjutkan.", MsgBoxStyle.Information, "Success!")
                End If

                ProgressBar1.Visible = False
            Else
                MsgBox("Tidak ada data yang di Upload.", MsgBoxStyle.Exclamation, "Warning!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub ValidasiGridTindakanDetail()
        Try
            Dim tblsTindakan As DataTable = DataGridViewTindakan.DataSource
            Dim statusValidasi As Boolean = True

            If tblsTindakan IsNot Nothing AndAlso tblsTindakan.Rows.Count > 0 Then
                ButtonSimpanData.Enabled = False
                ProgressBar1.Visible = True
                Dim index As Integer = 0
                Dim jumlah As Integer = 0

                ' Validasi
                For Each rowValidasi As DataRow In tblsTindakan.Rows
                    index = index + 1

                    ' Validasi Kode Tindakan
                    If rowValidasi("Kode Tindakan").ToString.Trim = "" Or rowValidasi("Kode Tindakan").ToString.Trim = "-" Then
                        MsgBox("Kode Tindakan tidak boleh kosong. (Row ke-" & index & ")", MsgBoxStyle.Exclamation, "Warning!")
                        statusValidasi = False
                        Exit For
                    End If

                    ' Validasi Lokasi
                    If rowValidasi("Lokasi").ToString.Trim = "" Or rowValidasi("Lokasi").ToString.Trim = "-" Then
                        MsgBox("Lokasi tidak boleh kosong. (Row ke-" & index & ")", MsgBoxStyle.Exclamation, "Warning!")
                        statusValidasi = False
                        Exit For
                    End If

                    ' Validasi Biaya Tindakan
                    If rowValidasi("Biaya Tindakan").ToString.Trim = "" Or rowValidasi("Biaya Tindakan").ToString.Trim = "-" Then
                        MsgBox("Biaya Tindakan tidak boleh kosong. (Row ke-" & index & ")", MsgBoxStyle.Exclamation, "Warning!")
                        statusValidasi = False
                        Exit For
                    ElseIf Val(rowValidasi("Biaya Tindakan").ToString.Trim) <= 0 Then
                        MsgBox("Biaya harus lebih besar dari 0. (Row ke-" & index & ")", MsgBoxStyle.Exclamation, "Warning!")
                        statusValidasi = False
                        Exit For
                    End If

                    ' Validasi Pelaksana
                    If rowValidasi("Pelaksana").ToString.Trim = "" Or rowValidasi("Pelaksana").ToString.Trim = "-" Then
                        MsgBox("Pelaksana tidak boleh kosong. (Row ke-" & index & ")", MsgBoxStyle.Exclamation, "Warning!")
                        statusValidasi = False
                        Exit For
                    End If

                    ' Validasi Status Fee Tindakan
                    If rowValidasi("Status Fee Tindakan").ToString.Trim <> "Ya" And rowValidasi("Status Fee Tindakan").ToString.Trim <> "Tidak" Then
                        MsgBox("Status Fee Tindakan tidak sesuai. (Row ke-" & index & ")", MsgBoxStyle.Exclamation, "Warning!")
                        statusValidasi = False
                        Exit For
                    End If

                    If rowValidasi("Status Fee Tindakan").ToString.Trim = "Ya" Then
                        ' Validasi Jenis Fee Tindakan
                        If rowValidasi("Jenis Fee Tindakan").ToString.Trim <> "Persentase" And rowValidasi("Jenis Fee Tindakan").ToString.Trim <> "Nominal" Then
                            MsgBox("Jenis Fee Tindakan tidak sesuai. (Row ke-" & index & ")", MsgBoxStyle.Exclamation, "Warning!")
                            statusValidasi = False
                            Exit For
                        End If

                        If rowValidasi("Jenis Fee Tindakan").ToString.Trim = "Persentase" Then
                            ' Set Nominal Fee Tindakan
                            rowValidasi("Nominal Fee Tindakan") = "0"

                            ' Validasi Persentase Fee Perusahaan
                            If rowValidasi("Persentase Fee Perusahaan").ToString.Trim = "" Or rowValidasi("Persentase Fee Perusahaan").ToString.Trim = "-" Then
                                MsgBox("Persentase Fee Perusahaan tidak boleh kosong. (Row ke-" & index & ")", MsgBoxStyle.Exclamation, "Warning!")
                                statusValidasi = False
                                Exit For
                            ElseIf Val(rowValidasi("Persentase Fee Perusahaan").ToString.Trim) <= 0 Then
                                MsgBox("Persentase Fee Perusahaan harus lebih besar dari 0. (Row ke-" & index & ")", MsgBoxStyle.Exclamation, "Warning!")
                                statusValidasi = False
                                Exit For
                            End If

                            ' Validasi Persentase Fee Karyawan
                            If rowValidasi("Persentase Fee Karyawan").ToString.Trim = "" Or rowValidasi("Persentase Fee Karyawan").ToString.Trim = "-" Then
                                MsgBox("Persentase Fee Karyawan tidak boleh kosong. (Row ke-" & index & ")", MsgBoxStyle.Exclamation, "Warning!")
                                statusValidasi = False
                                Exit For
                            ElseIf Val(rowValidasi("Persentase Fee Karyawan").ToString.Trim) <= 0 Then
                                MsgBox("Persentase Fee Karyawan harus lebih besar dari 0. (Row ke-" & index & ")", MsgBoxStyle.Exclamation, "Warning!")
                                statusValidasi = False
                                Exit For
                            End If

                            ' Validasi Persentase 100%
                            If Val(rowValidasi("Persentase Fee Perusahaan").ToString.Trim) + Val(rowValidasi("Persentase Fee Karyawan").ToString.Trim) <> 100 Then
                                MsgBox("Persentase Fee kurang dari 100%. (Row ke-" & index & ")", MsgBoxStyle.Exclamation, "Warning!")
                                statusValidasi = False
                                Exit For
                            End If
                        ElseIf rowValidasi("Jenis Fee Tindakan").ToString.Trim = "Nominal" Then
                            ' Set Nominal Persentase Fee Perusahaan & Karyawan
                            rowValidasi("Persentase Fee Perusahaan") = "0"
                            rowValidasi("Persentase Fee Karyawan") = "0"

                            ' Validasi Nominal Fee Tindakan
                            If rowValidasi("Nominal Fee Tindakan").ToString.Trim = "" And rowValidasi("Nominal Fee Tindakan").ToString.Trim = "-" Then
                                MsgBox("Nominal Fee Tindakan tidak boleh kosong. (Row ke-" & index & ")", MsgBoxStyle.Exclamation, "Warning!")
                                statusValidasi = False
                                Exit For
                            ElseIf Val(rowValidasi("Nominal Fee Tindakan").ToString.Trim) <= 0 Then
                                MsgBox("Nominal Fee Tindakan harus lebih besar dari 0. (Row ke-" & index & ")", MsgBoxStyle.Exclamation, "Warning!")
                                statusValidasi = False
                                Exit For
                            ElseIf Val(rowValidasi("Nominal Fee Tindakan").ToString.Trim) >= Val(rowValidasi("Biaya Tindakan").ToString.Trim) Then
                                MsgBox("Nominal Fee Tindakan tidak boleh lebih atau sama dengan dari biaya tindakan. (Row ke-" & index & ")", MsgBoxStyle.Exclamation, "Warning!")
                                statusValidasi = False
                                Exit For
                            End If
                        End If

                        ' Validasi Fee Tambahan Dokter
                        If rowValidasi("Fee Tambahan Dokter").ToString.Trim = "" Or rowValidasi("Fee Tambahan Dokter").ToString.Trim = "-" Then
                            rowValidasi("Fee Tambahan Dokter") = "0"
                        ElseIf Val(rowValidasi("Fee Tambahan Dokter").ToString.Trim) <= 0 Then
                            rowValidasi("Fee Tambahan Dokter") = "0"
                        End If

                        ' Validasi Fee Tambahan Perawat
                        If rowValidasi("Fee Tambahan Perawat").ToString.Trim = "" Or rowValidasi("Fee Tambahan Perawat").ToString.Trim = "-" Then
                            rowValidasi("Fee Tambahan Perawat") = "0"
                        ElseIf Val(rowValidasi("Fee Tambahan Perawat").ToString.Trim) <= 0 Then
                            rowValidasi("Fee Tambahan Perawat") = "0"
                        End If

                        ' Validasi Fee Tindakan Tidak Boleh Melebihi Biaya Tindakan
                        If Val(rowValidasi("Nominal Fee Tindakan").ToString.Trim) + Val(rowValidasi("Fee Tambahan Dokter").ToString.Trim) + Val(rowValidasi("Fee Tambahan Perawat").ToString.Trim) >= Val(rowValidasi("Biaya Tindakan").ToString.Trim) Then
                            MsgBox("Fee Melebihi Biaya Tindakan. (Row ke-" & index & ")", MsgBoxStyle.Exclamation, "Warning!")
                            statusValidasi = False
                            Exit For
                        End If
                    ElseIf rowValidasi("Status Fee Tindakan").ToString.Trim = "Tidak" Then
                        ' Set Clear Nominal Fee
                        rowValidasi("Jenis Fee Tindakan") = "-"
                        rowValidasi("Persentase Fee Perusahaan") = "0"
                        rowValidasi("Persentase Fee Karyawan") = "0"
                        rowValidasi("Nominal Fee Tindakan") = "0"
                        rowValidasi("Fee Tambahan Dokter") = "0"
                        rowValidasi("Fee Tambahan Perawat") = "0"
                    End If

                    ' Validasi Status BHP
                    If rowValidasi("Status BHP").ToString.Trim <> "Ya" And rowValidasi("Status BHP").ToString.Trim <> "Tidak" Then
                        MsgBox("Status BHP tidak sesuai. (Row ke-" & index & ")", MsgBoxStyle.Exclamation, "Warning!")
                        statusValidasi = False
                        Exit For
                    End If

                    If rowValidasi("Status BHP").ToString.Trim = "Ya" Then
                        If rowValidasi("Maksimal Nominal BHP").ToString.Trim = "" Or rowValidasi("Maksimal Nominal BHP").ToString.Trim = "-" Then
                            MsgBox("Maksimal Nominal BHP tidak boleh kosong. (Row ke-" & index & ")", MsgBoxStyle.Exclamation, "Warning!")
                            statusValidasi = False
                            Exit For
                        ElseIf rowValidasi("Status BHP").ToString.Trim = "Ya" And Val(rowValidasi("Maksimal Nominal BHP").ToString.Trim) <= 0 Then
                            MsgBox("Status BHP harus lebih besar dari 0. (Row ke-" & index & ")", MsgBoxStyle.Exclamation, "Warning!")
                            statusValidasi = False
                            Exit For
                        ElseIf Val(rowValidasi("Maksimal Nominal BHP").ToString.Trim) >= Val(rowValidasi("Biaya Tindakan").ToString.Trim) Then
                            MsgBox("Maksimal BHP Melebihi Biaya Tindakan. (Row ke-" & index & ")", MsgBoxStyle.Exclamation, "Warning!")
                            statusValidasi = False
                            Exit For
                        End If
                    ElseIf rowValidasi("Status BHP").ToString.Trim = "Tidak" Then
                        rowValidasi("Maksimal Nominal BHP") = "0"
                    End If

                    ' Validasi Kode Tindakan Valid
                    If CheckThemysql("SELECT * FROM mastertindakanpoli WHERE kodetindakan IN ('" & rowValidasi("Kode Tindakan") & "');", DB_Poliklinik) = False Then
                        MsgBox("Kode Tindakan tidak valid. Mohon cek kembali. (Row ke-" & index & ")", MsgBoxStyle.Exclamation, "Warning!")
                        statusValidasi = False
                        Exit For
                    End If

                    ' Validasi Lokasi Valid

                    ' Validasi Pelaksana Valid

                    ' Validasi ID Tindakan Detail
                    If rowValidasi("ID Tindakan Detail").ToString.Trim = "" Or rowValidasi("ID Tindakan Detail").ToString.Trim = "-" Then
                        If CheckThemysql("SELECT * FROM mastertindakanpolidetail a WHERE a.kodetindakan = '" & rowValidasi("Kode Tindakan") & "' AND a.lokasitindakan = '" & rowValidasi("Lokasi") & "';", DB_Poliklinik) = True Then
                            MsgBox("Lokasi & Kode Tindakan sudah pernah diinput. Mohon cek kembali. (Row ke-" & index & ")", MsgBoxStyle.Exclamation, "Warning!")
                            statusValidasi = False
                            Exit For
                        End If
                    Else
                        If CheckThemysql("SELECT * FROM mastertindakanpolidetail a WHERE a.kodetindakan = '" & rowValidasi("Kode Tindakan") & "' AND a.lokasitindakan = '" & rowValidasi("Lokasi") & "' AND a.tindakaniddetail = '" & rowValidasi("ID Tindakan Detail") & "';", DB_Poliklinik) = False Then
                            MsgBox("ID Tindakan Detail Tindakan belum pernah diinput. Mohon cek kembali. (Row ke-" & index & ")", MsgBoxStyle.Exclamation, "Warning!")
                            statusValidasi = False
                            Exit For
                        End If
                    End If

                    Dim procent As Integer = index * 100 / tblsTindakan.Rows.Count
                    ProgressBar1.Value = procent
                Next

                If statusValidasi = False Then
                    ' Failed
                    ButtonSimpanData.Enabled = False
                Else
                    ' Success
                    ButtonSimpanData.Enabled = True

                    ' Set Enable / Disable
                    If RadioButtonTindakan.Checked = True Then RadioButtonTindakanDetail.Enabled = False
                    If RadioButtonTindakanDetail.Checked = True Then RadioButtonTindakan.Enabled = False
                    If RadioButtonPoliUmum.Checked = True Then RadioButtonPoliGigi.Enabled = False
                    If RadioButtonPoliGigi.Checked = True Then RadioButtonPoliUmum.Enabled = False

                    MsgBox(tblsTindakan.Rows.Count & " data berhasil divalidasi, klik tombol simpan untuk melanjutkan.", MsgBoxStyle.Information, "Success!")
                End If

                ProgressBar1.Visible = False
            Else
                MsgBox("Tidak ada data yang di Upload.", MsgBoxStyle.Exclamation, "Warning!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Function GenerateKodeTindakan() As String
        Dim kodeTindakan As String = ""
        Dim nomorUrut As String = ""
        Dim stringKodeTindakan As String = ""
        Dim jenisPoli As String = ""

        ' Set Jenis Poli
        If RadioButtonPoliUmum.Checked = True Then
            jenisPoli = "POLI UMUM"
            stringKodeTindakan = "UMUM"
        ElseIf RadioButtonPoliGigi.Checked = True Then
            jenisPoli = "POLI GIGI"
            stringKodeTindakan = "GIGI"
        End If

        nomorUrut = ReadThemysqlNIK("SELECT CONCAT(LPAD(RIGHT(a.kodetindakan,4),4,0)) " & _
                                    "FROM mastertindakanpoli a " & _
                                    "WHERE a.jenispoli = '" & jenisPoli & "' " & _
                                    "ORDER BY a.kodetindakan DESC " & _
                                    "LIMIT 1", DB_Poliklinik)

        If Not String.IsNullOrEmpty(nomorUrut) AndAlso IsNumeric(nomorUrut) Then
            nomorUrut = (Convert.ToInt32(nomorUrut) + 1).ToString()
        Else
            nomorUrut = "1"
        End If

        kodeTindakan = stringKodeTindakan & nomorUrut.PadLeft(4, "0"c)

        Return kodeTindakan
    End Function

    Private Sub SaveMultiple()
        Dim procent As Integer = 0
        Dim persen As Integer = 0
        Dim NomorPoli As String = ReadSQLNIK("select StrValue from MsConfig where ConfigName='NoPoli'")

        If MsgBox("Yakin proses lanjut ?", MsgBoxStyle.YesNo, "Verifikasi Akhir") = MsgBoxResult.Yes Then
            ButtonUploadData.Enabled = False
            ButtonClearData.Enabled = False
            ButtonDownloadTemplate.Enabled = False
            ButtonValidasiData.Enabled = False
            ButtonSimpanData.Enabled = False

            ProgressBar1.Visible = True

            Dim kodeTindakan As String = ""
            Dim parameterUpdate As String = ""
            Dim parameterStatus As String = ""

            ' Set Jenis Poli
            Dim jenisPoli As String = ""
            If RadioButtonPoliUmum.Checked = True Then jenisPoli = "POLI UMUM"
            If RadioButtonPoliGigi.Checked = True Then jenisPoli = "POLI GIGI"

            Dim Ttemp As DataTable = DataGridViewTindakan.DataSource
            For Each rowTindakan As DataRow In Ttemp.Rows
                persen = persen + 1
                procent = persen * 100 / Ttemp.Rows.Count
                ProgressBar1.Value = procent

                If RadioButtonTindakan.Checked = True Then
                    ' Status Aktif Tindakan
                    Dim statusClosed As Boolean = False
                    If rowTindakan("Aktif").ToString.Trim = "Tidak" Then statusClosed = True

                    If rowTindakan("Kode Tindakan").ToString.Trim = "" Or rowTindakan("Kode Tindakan").ToString.Trim = "-" Then
                        ' Insert Data

                        ' Generate Kode Tindakan
                        kodeTindakan = GenerateKodeTindakan()

                        ' Insert Data ke mastertindakanpoli
                        WriteThemysql("INSERT INTO mastertindakanpoli (jenispoli, kodetindakan, namatindakan, jenistindakan, keterangan, closed, createdby, createddate) " & _
                                      "VALUES('" & jenisPoli & "', '" & kodeTindakan & "', '" & rowTindakan("Nama Tindakan") & "', '" & rowTindakan("Jenis Tindakan") & "', '" & rowTindakan("Keterangan") & "', " & statusClosed & ", '" & userInput & "', NOW())", DB_Poliklinik)
                    Else
                        ' Update Data

                        ' Update Data SuratKeteranganDokter
                        parameterUpdate = "namatindakan = '" & rowTindakan("Nama Tindakan").ToString.Trim & "'," & _
                                          "jenistindakan = '" & rowTindakan("Jenis Tindakan").ToString.Trim & "'," & _
                                          "keterangan = '" & rowTindakan("Keterangan").ToString.Trim & "'," & _
                                          "closed = " & statusClosed & ""

                        ' Set Parameter Status
                        If rowTindakan("Aktif").ToString.Trim = "Ya" Then
                            parameterStatus = "updatedby = '" & userInput & "'," & _
                                              "updateddate = NOW()"
                        Else
                            parameterStatus = "closedby = '" & userInput & "'," & _
                                              "closeddate = NOW()"
                        End If

                        WriteThemysql("UPDATE mastertindakanpoli SET " & parameterUpdate & ", " & parameterStatus & " WHERE jenispoli = '" & jenisPoli & "' AND kodetindakan = '" & rowTindakan("Kode Tindakan").ToString.Trim & "'", DB_Poliklinik)
                    End If
                ElseIf RadioButtonTindakanDetail.Checked = True Then
                    ' Status Fee Tindakan
                    Dim statusFeeTindakan As Boolean = False
                    If rowTindakan("Status Fee Tindakan").ToString.Trim = "Ya" Then statusFeeTindakan = True

                    ' Status BHP
                    Dim statusBHP As Boolean = False
                    If rowTindakan("Status BHP").ToString.Trim = "Ya" Then statusBHP = True

                    If rowTindakan("ID Tindakan Detail").ToString.Trim = "" Or rowTindakan("ID Tindakan Detail").ToString.Trim = "-" Then
                        ' Insert Data

                        ' Insert Data ke mastertindakanpoli
                        WriteThemysql("INSERT INTO mastertindakanpolidetail (kodetindakan, lokasitindakan, biayatindakan, pelaksana, statusfeetindakan, jenisfeetindakan, persentasefeeperusahaan, persentasefeekaryawan, feepertindakan, statusbhp, maksimalbhp, feetambahandokter, feetambahanperawat, createdby, createddate) " & _
                                      "VALUES('" & rowTindakan("Kode Tindakan") & "', '" & rowTindakan("Lokasi") & "', '" & CDbl(rowTindakan("Biaya Tindakan")) & "', '" & rowTindakan("Pelaksana") & "', " & statusFeeTindakan & ", '" & rowTindakan("Jenis Fee Tindakan") & "', '" & CDbl(rowTindakan("Persentase Fee Perusahaan")) & "',  " & _
                                      "'" & CDbl(rowTindakan("Persentase Fee Karyawan")) & "', '" & CDbl(rowTindakan("Nominal Fee Tindakan")) & "', " & statusBHP & ", '" & CDbl(rowTindakan("Maksimal Nominal BHP")) & "', '" & CDbl(rowTindakan("Fee Tambahan Dokter")) & "', '" & CDbl(rowTindakan("Fee Tambahan Perawat")) & "', '" & userInput & "', NOW())", DB_Poliklinik)
                    Else
                        ' Update Data

                        ' Update Data SuratKeteranganDokter
                        parameterUpdate = "biayatindakan = '" & CDbl(rowTindakan("Biaya Tindakan").ToString) & "'," & _
                                          "pelaksana = '" & rowTindakan("Pelaksana").ToString.Trim & "'," & _
                                          "statusfeetindakan = " & statusFeeTindakan & "," & _
                                          "jenisfeetindakan = '" & rowTindakan("Jenis Fee Tindakan").ToString.Trim & "'," & _
                                          "persentasefeeperusahaan = '" & CDbl(rowTindakan("Persentase Fee Perusahaan").ToString) & "'," & _
                                          "persentasefeekaryawan = '" & CDbl(rowTindakan("Persentase Fee Karyawan").ToString) & "'," & _
                                          "feepertindakan = '" & CDbl(rowTindakan("Nominal Fee Tindakan").ToString) & "'," & _
                                          "statusbhp = " & statusBHP & "," & _
                                          "maksimalbhp = '" & CDbl(rowTindakan("Maksimal Nominal BHP")) & "'," & _
                                          "feetambahandokter = '" & CDbl(rowTindakan("Fee Tambahan Dokter")) & "'," & _
                                          "feetambahanperawat = '" & CDbl(rowTindakan("Fee Tambahan Perawat")) & "'," & _
                                          "updatedby = '" & userInput & "'," & _
                                          "updateddate = NOW()"

                        WriteThemysql("UPDATE mastertindakanpolidetail SET " & parameterUpdate & " WHERE tindakaniddetail = '" & rowTindakan("ID Tindakan Detail").ToString.Trim & "' AND kodetindakan = '" & rowTindakan("Kode Tindakan").ToString.Trim & "' AND lokasitindakan = '" & rowTindakan("Lokasi").ToString.Trim & "'", DB_Poliklinik)
                    End If
                End If
            Next

            MsgBox("Data berhasil disimpan.", MsgBoxStyle.Information, "Success!")
        Else
            MsgBox("Canceled.", MsgBoxStyle.Exclamation, "Warning!")
        End If

        SetClear()
        ProgressBar1.Visible = False
    End Sub

    Function CekPasienAktif(ByVal Tdata As DataRow) As String
        If CheckSQL("SELECT * FROM MasterPasien WHERE Nama = '" & Tdata("Nama") & "' AND (TglLahir = '" & Format(Tdata("TglLahir"), "MM/dd/yyyy") & "' OR NoNIK = '" & Tdata("PTNIK") & "')") = True Then
            Return 2
        Else
            Return 1
        End If

        Return False
    End Function

    Private Sub ButtonValidasiData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonValidasiData.Click
        If RadioButtonTindakan.Checked Then
            ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf ValidasiGridTindakan))
        ElseIf RadioButtonTindakanDetail.Checked Then
            ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf ValidasiGridTindakanDetail))
        End If
    End Sub

    Private Sub ButtonSimpanData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSimpanData.Click
        thread = New System.Threading.Thread(AddressOf SaveMultiple)
        thread.Start()
    End Sub

    Private Sub ButtonUploadData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonUploadData.Click
        Try
            opFileDialog.Filter = "Excel Files 2003|*.xls|Excel Files|*.xlsx"
            opFileDialog.Title = "Select a Excel File"

            If opFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Dim fi As New FileInfo(opFileDialog.FileName)
                Dim FileName As String = opFileDialog.FileName

                excel = fi.FullName
                conn = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excel + ";Extended Properties=Excel 12.0;")
                dta = New OleDbDataAdapter("SELECT * FROM [Sheet1$]", conn)
                dts = New DataSet("NewTables")
                dta.Fill(dts)

                Dim formatKolom() As String = {} ' Deklarasi array kosong

                If RadioButtonTindakan.Checked = True Then
                    formatKolom = New String() {"ID Tindakan", "Kode Tindakan", "Nama Tindakan", "Jenis Tindakan", "Keterangan", "Aktif"}
                ElseIf RadioButtonTindakanDetail.Checked = True Then
                    formatKolom = New String() {"ID Tindakan Detail", "Kode Tindakan", "Lokasi", "Biaya Tindakan", "Pelaksana", "Status Fee Tindakan", "Jenis Fee Tindakan", "Persentase Fee Perusahaan", "Persentase Fee Karyawan", "Nominal Fee Tindakan", "Status BHP", "Maksimal Nominal BHP", "Fee Tambahan Dokter", "Fee Tambahan Perawat"}
                End If

                ' Validasi struktur kolom
                If Not ValidasiKolomExcelTindakan(dts.Tables(0), formatKolom) Then
                    MsgBox("File Excel tidak sesuai dengan format yang diharapkan.", MsgBoxStyle.Exclamation, "Warning!")
                    Exit Sub
                End If

                DataGridViewTindakan.DataSource = dts.Tables(0)

                conn.Close()
            End If

            DataGridViewTindakan.CurrentCell = Nothing
            DataGridViewTindakan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            ButtonSimpanData.Enabled = False
        Catch ex As Exception
            conn.Close()
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Function ValidasiKolomExcelTindakan(ByVal dataTable As DataTable, ByVal formatKolom() As String) As Boolean
        Dim excelColumns As List(Of String) = New List(Of String)()

        ' Mengambil nama kolom dari file Excel
        For Each column As DataColumn In dataTable.Columns
            excelColumns.Add(column.ColumnName)
        Next

        ' Memeriksa apakah semua kolom yang diharapkan ada dalam file Excel
        Dim allColumnsExist As Boolean = formatKolom.All(Function(col) excelColumns.Contains(col))

        Return allColumnsExist
    End Function

    Private Sub ButtonDownloadTemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDownloadTemplate.Click
        Dim tblTindakan As DataTable = New DataTable

        ' Set Jenis Poli
        Dim jenisPoli As String = ""
        If RadioButtonPoliUmum.Checked = True Then jenisPoli = "POLI UMUM"
        If RadioButtonPoliGigi.Checked = True Then jenisPoli = "POLI GIGI"

        If RadioButtonTindakan.Checked = True Then
            tblTindakan = ReadThemysql("SELECT a.tindakanid AS 'ID Tindakan', a.kodetindakan AS 'Kode Tindakan', a.namatindakan AS 'Nama Tindakan', a.jenistindakan AS 'Jenis Tindakan', a.keterangan AS 'Keterangan', " & _
                                       "CASE WHEN a.closed = 0 THEN 'Ya' WHEN a.closed = 1 THEN 'Tidak' END AS 'Aktif' " & _
                                       "FROM mastertindakanpoli a " & _
                                       "WHERE a.closed = 0 AND a.jenispoli = '" & jenisPoli & "' " & _
                                       "ORDER BY a.tindakanid;", DB_Poliklinik)
        ElseIf RadioButtonTindakanDetail.Checked = True Then
            tblTindakan = ReadThemysql("SELECT a.tindakaniddetail AS 'ID Tindakan Detail', a.kodetindakan AS 'Kode Tindakan', a.lokasitindakan AS 'Lokasi', b.namatindakan AS 'Nama Tindakan', a.biayatindakan AS 'Biaya Tindakan', a.pelaksana AS 'Pelaksana', " & _
                                       "CASE WHEN a.statusfeetindakan = 1 THEN 'Ya' WHEN a.statusfeetindakan = 0 THEN 'Tidak' END AS 'Status Fee Tindakan', a.jenisfeetindakan AS 'Jenis Fee Tindakan', a.persentasefeeperusahaan AS 'Persentase Fee Perusahaan', " & _
                                       "a.persentasefeekaryawan AS 'Persentase Fee Karyawan', a.feepertindakan AS 'Nominal Fee Tindakan', " & _
                                       "CASE WHEN a.statusbhp = 1 THEN 'Ya' WHEN a.statusbhp = 0 THEN 'Tidak' END AS 'Status BHP', a.maksimalbhp AS 'Maksimal Nominal BHP', a.feetambahandokter AS 'Fee Tambahan Dokter', a.feetambahanperawat AS 'Fee Tambahan Perawat' " & _
                                       "FROM mastertindakanpolidetail a " & _
                                       "LEFT JOIN mastertindakanpoli b ON a.kodetindakan = b.kodetindakan " & _
                                       "WHERE b.closed = 0 AND b.jenispoli = '" & jenisPoli & "' " & _
                                       "ORDER BY b.tindakanid;", DB_Poliklinik)
        End If

        ' Membuka dialog SaveFileDialog untuk membiarkan pengguna memilih path dan nama file
        Dim saveFileDialog As New SaveFileDialog()
        saveFileDialog.Filter = "Excel Files|*.xlsx"
        saveFileDialog.Title = "Simpan File Excel"

        If saveFileDialog.ShowDialog() = DialogResult.OK Then
            ExportToExcelFromTable(tblTindakan, saveFileDialog.FileName)
            MessageBox.Show("File Excel telah berhasil diekspor ke: " & saveFileDialog.FileName, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub ExportToExcelFromTable(ByVal dt As DataTable, ByVal excelFilePath As String)
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value

        xlApp = New Excel.ApplicationClass
        xlWorkBook = xlApp.Workbooks.Add(misValue)
        xlWorkSheet = CType(xlWorkBook.Sheets(1), Excel.Worksheet)

        ' Menambahkan judul kolom dan mewarnai header
        For col As Integer = 0 To dt.Columns.Count - 1
            xlWorkSheet.Cells(1, col + 1) = dt.Columns(col).ColumnName
            xlWorkSheet.Cells(1, col + 1).Interior.Color = RGB(88, 188, 148) ' Ubah warna sesuai kebutuhan
            xlWorkSheet.Cells(1, col + 1).Font.Color = RGB(255, 255, 255) ' Ubah warna teks sesuai kebutuhan
        Next

        ' Mengisi data dari DataTable ke Excel
        For row As Integer = 0 To dt.Rows.Count - 1
            For col As Integer = 0 To dt.Columns.Count - 1
                xlWorkSheet.Cells(row + 2, col + 1) = dt.Rows(row)(col).ToString()
            Next
        Next

        ' Best fit kolom
        For col As Integer = 1 To dt.Columns.Count
            xlWorkSheet.Columns(col).AutoFit()
        Next

        ' Simpan file Excel
        xlWorkBook.SaveAs(excelFilePath)
        xlWorkBook.Close()
        xlApp.Quit()

        ReleaseObject(xlApp)
        ReleaseObject(xlWorkBook)
        ReleaseObject(xlWorkSheet)
    End Sub

    ' Fungsi untuk menghapus objek Excel dari memori
    Private Sub ReleaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Private Sub ButtonClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClose.Click
        Me.Close()
    End Sub

    Private Sub ButtonClearData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClearData.Click
        SetClear()
    End Sub

    Private Sub SetClear()
        ButtonClearData.Enabled = True
        RadioButtonTindakan.Enabled = True
        RadioButtonTindakanDetail.Enabled = True
        RadioButtonPoliUmum.Enabled = True
        RadioButtonPoliGigi.Enabled = True

        ButtonSimpanData.Enabled = False
        ButtonValidasiData.Enabled = True
        ButtonUploadData.Enabled = True
        ButtonDownloadTemplate.Enabled = True

        DataGridViewTindakan.DataSource = Nothing ' Menghapus sumber data DataGridView
        DataGridViewTindakan.Rows.Clear() ' Menghapus semua baris dari DataGridView
    End Sub

    Private Sub BtnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpload.Click
        Dim openFile As New OpenFileDialog()
        openFile.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png"

        If openFile.ShowDialog() = DialogResult.OK Then
            PBGambar.Image = Image.FromFile(openFile.FileName)
            PBGambar.Tag = openFile.FileName ' Simpan path di Tag jika perlu
        End If

        PBGambar.SizeMode = PictureBoxSizeMode.Zoom
    End Sub

    Private Sub MuatKeteranganKeComboBox()
        ComboBoxKeterangan.Items.Clear()

        Dim dt As DataTable = ReadSQL("SELECT Keterangan FROM UploadGambar GROUP BY Keterangan ORDER BY MAX(CreatedDate) DESC")
        For Each row As DataRow In dt.Rows
            ComboBoxKeterangan.Items.Add(row("Keterangan").ToString())
        Next
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        MuatKeteranganKeComboBox()
    End Sub

    Private Sub BtnSimpanGambar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSimpanGambar.Click
        If PBGambar.Tag Is Nothing Then
            MessageBox.Show("Silakan upload gambar terlebih dahulu.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If TextBoxKeterangan.Text = "" Or TextBoxKeterangan.Text.Trim() = "" Then
            MessageBox.Show("Silakan isi keterangan gambar.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim dtCek As DataTable = ReadSQL("SELECT COUNT(*) AS Jumlah FROM UploadGambar WHERE Keterangan = '" & TextBoxKeterangan.Text.Replace("'", "''") & "'")
        If dtCek.Rows(0)("Jumlah") > 0 Then
            MessageBox.Show("Keterangan sudah digunakan. Harap gunakan keterangan lain.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        'Simpan folder 
        Dim folderPath As String = Application.StartupPath & "\Uploads\"
        If Not IO.Directory.Exists(folderPath) Then
            IO.Directory.CreateDirectory(folderPath)
        End If

        ' Buat nama file unik untuk menghindari konflik
        Dim ekstensi As String = IO.Path.GetExtension(PBGambar.Tag.ToString())
        Dim namaFileUnik As String = Guid.NewGuid().ToString() & ekstensi
        Dim targetPath As String = IO.Path.Combine(folderPath, namaFileUnik)

        ' Salin gambar ke folder Uploads
        IO.File.Copy(PBGambar.Tag.ToString(), targetPath, True)

        ' Path relatif yang akan disimpan di database
        Dim namaGambar As String = TextBoxKeterangan.Text
        Dim fotoPath As String = "Uploads\" & namaFileUnik
        Dim keterangan As String = TextBoxKeterangan.Text

        ' Simpan ke database
        WriteSQL("INSERT INTO UploadGambar (FotoPath, Keterangan, CreatedBy, CreatedDate) " & _
             "VALUES ('" & fotoPath & "', '" & keterangan & "','" & userInput & "', GETDATE())", 4)

        ' Refresh ComboBox setelah simpan
        MuatKeteranganKeComboBox()

        ' (Opsional) Set ke keterangan baru otomatis
        ComboBoxKeterangan.SelectedItem = namaGambar

        MessageBox.Show("Gambar berhasil disimpan.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub TampilkanGambar(ByVal keterangan As String)
        Dim dt As DataTable = ReadSQL("SELECT FotoPath FROM UploadGambar WHERE Keterangan = '" & keterangan & "'")

        If dt.Rows.Count > 0 Then
            Dim fotoPath As String = dt.Rows(0)("FotoPath").ToString()
            Dim fullPath As String = System.IO.Path.Combine(Application.StartupPath, fotoPath)

            If IO.File.Exists(fullPath) Then
                PictureBoxPreview.Image = Image.FromFile(fullPath)
                PictureBoxPreview.SizeMode = PictureBoxSizeMode.Zoom
            Else
                PictureBoxPreview.Image = Nothing
                MessageBox.Show("File gambar tidak ditemukan di folder Uploads.")
            End If
        Else
            PictureBoxPreview.Image = Nothing
            MessageBox.Show("Data gambar tidak ditemukan di database.")
        End If
    End Sub

    Private Sub ComboBoxKeterangan_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxKeterangan.SelectedIndexChanged
        If ComboBoxKeterangan.SelectedIndex <> -1 Then
            Dim keteranganDipilih As String = ComboBoxKeterangan.SelectedItem.ToString()
            TampilkanGambar(keteranganDipilih)
        End If
    End Sub
End Class