Imports KASLibrary
Imports System.Drawing
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraReports.UI
Imports System.Drawing.Text
Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Object
Imports Newtonsoft.Json
Imports Newtonsoft
Imports System.Security.Cryptography
Imports System.Collections.Generic
Imports Newtonsoft.Json.Linq
Imports DevExpress.XtraPrinting

Public Class FormPembayaran
    Private formName As String = "FORM PEMBAYARAN"
    Dim thread As System.Threading.Thread
    Dim tblTindakan As New DataTable
    Dim txtotalbruto, txtotaldisc, txtotalpembulatan, txtotalrow As Double
    Dim statusBPJS As Boolean = False

    ' Set QR Code
    Dim statusQR As Boolean = False
    Dim keteranganQR As String = ""

    ' Variabel PCare
    Private NoUrutBPJS As String = ""

    ' Variabel Lokal
    Private userInput As String = PoliKlinik.Lbluser.Text

    Private _dataDictionary As Dictionary(Of String, Object)

    Private Class varJson
        Public response As v4_BPJS
        'Public response As Object
        Public metaData As MetaData
    End Class

    '# Variabel FormPendaftaranAwal
    Private _idTransaksi As String = ""
    Private _nomorUrutTransaksi As String = ""
    Private _jenisTransaksi As String = ""
    Private _namaPoli As String = ""
    Private _noRekamMedis As String = ""
    Private _noBPJS As String = ""
    Private _noNIK As String = ""
    Private _namaPasien As String = ""
    Private _namaDokter As String = ""
    Private _namaPerawat As String = ""
    Private _namaMarketing As String = ""
    Private _keluhanUtama As String = ""
    Private _keluhanTambahan As String = ""
    Private _jenisKunjungan As String = ""
    Private _jenisRawat As String = ""
    Private _jenisTindakan As String = ""

    Private _statusHandaya As String = ""
    Private _statusDifabel As String = ""
    Private _statusLansia As String = ""
    Private _statusGawatDarurat As String = ""

    Public Property DataDictionary() As Dictionary(Of String, Object)
        Get
            Return _dataDictionary
        End Get
        Set(ByVal value As Dictionary(Of String, Object))
            _dataDictionary = value

            _idTransaksi = GetValueFromDictionary("ID Transaksi", "")
            _nomorUrutTransaksi = GetValueFromDictionary("No Urut Transaksi", "")
            _jenisTransaksi = GetValueFromDictionary("Jenis Transaksi", "")
            _noRekamMedis = GetValueFromDictionary("No Rekam Medis", "")
            _noBPJS = GetValueFromDictionary("No BPJS", "")
            _noNIK = GetValueFromDictionary("No NIK", "")
            _namaPasien = GetValueFromDictionary("Nama Pasien", "")
            _namaDokter = GetValueFromDictionary("Nama Dokter", "")
            _namaPerawat = GetValueFromDictionary("Nama Perawat", "")
            _namaMarketing = GetValueFromDictionary("Nama Marketing", "")
            _keluhanUtama = GetValueFromDictionary("Keluhan Utama", "")
            _keluhanTambahan = GetValueFromDictionary("Keluhan Tambahan", "")
            _jenisKunjungan = GetValueFromDictionary("Jenis Kunjungan", "")
            _jenisRawat = GetValueFromDictionary("Jenis Rawat", "")
            _jenisTindakan = GetValueFromDictionary("Jenis Tindakan", "")

            _statusHandaya = GetValueFromDictionary("Status Handaya", "")
            _statusDifabel = GetValueFromDictionary("Status Difabel", "")
            _statusLansia = GetValueFromDictionary("Status Lansia", "")
            _statusGawatDarurat = GetValueFromDictionary("Status Gawat Darurat", "")

            _namaPoli = GetValueFromDictionary("Poli Tujuan", "")
        End Set
    End Property

    Private Function GetValueFromDictionary(ByVal key As String, ByVal defaultValue As Object) As Object
        If _dataDictionary.ContainsKey(key) Then
            Return _dataDictionary(key)
        Else
            Return defaultValue
        End If
    End Function

    Private Sub PanelTop_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelTop.Paint
        Try
            e.Graphics.DrawString(formName, New Font("Arial", 12, FontStyle.Bold), Brushes.White, New Point(10, 10))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub ClearPembayaran()
        ComboBoxJenisBayar.Text = ""
        ComboBoxJenisEDC.Text = ""
        ComboBoxJenisBank.Text = ""
        TextBoxJumlahBayar.Value = 0
        TextBoxNoKartu.ResetText()
        'txnokartu.Enabled = False
        txnokartupembayaran.Text = "No Kartu"
        butcompany.Enabled = False
        ButtonClear.Enabled = True
        ButtonTambah.Enabled = True

        InsertNewItemComboSQL("select StrValue from MsConfig WHERE ConfigName='NamaBank'", ComboBoxJenisBank)
        ComboBoxJenisBank.ResetText()
        ComboBoxJenisBank.Enabled = False

        InsertNewItemComboSQL("select StrValue from MsConfig WHERE ConfigName='MesinBank'", ComboBoxJenisEDC)
        ComboBoxJenisEDC.ResetText()
        ComboBoxJenisEDC.Enabled = False

        ComboBoxJenisBayar.SelectedIndex = -1
        ComboBoxJenisEDC.SelectedIndex = -1
        ComboBoxJenisBank.SelectedIndex = -1
        ComboBoxJenisBayar.Focus()

    End Sub

    Private Sub ClearTotal()
        TextBoxTotalTagihan.Value = 0
        TextBoxTotalBayar.Value = 0
        TextBoxTotalKembali.Value = 0
    End Sub

    Private Sub SetGrid()
        Dim Tdata As DataTable = ReadSQL("SELECT [JenisBayar] AS Jenis, [NoJenisBayar] AS NoKartu, [NoJenisBayar] AS KartuData, kartu AS JenisKartu, mesin AS MesinData, PARSENAME(CONVERT(VARCHAR, CONVERT(MONEY, JumlahBayar), 1), 2) AS Jumlah FROM TransaksiAdminBayar WHERE TransAdminIDBayar = 0")
        GridControlPembayaran.DataSource = Tdata
        GridView1.Columns("KartuData").Visible = False
    End Sub

    Private Sub SetClear()
        TextBoxNomorRM.ResetText()
        TextBoxNama.ResetText()

        SetGrid()
        ClearPembayaran()
        ClearTotal()
        ButtonClear.PerformClick()
        ComboBoxJenisBank.ResetText()
        ComboBoxJenisEDC.ResetText()
    End Sub

    Private Sub Pembayaran_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
        CheckBoxNominalTagihan.Checked = False
        CheckBoxLunasBayar.Checked = False
        statusBPJS = False

        SetDataFromQRCode()
    End Sub

    Private Sub SetDataFromQRCode()
        If txbayarfromQRcode.Text <> "" Then
            Dim arrData As String() = Split(txbayarfromQRcode.Text, "#")

            ComboBoxJenisBayar.Text = arrData(2).ToString.Trim
            TextBoxJumlahBayar.Value = CDbl(arrData(3))

            If arrData(2).ToString.Trim = "TAGIHAN" Then
                If arrData(0).ToString.Contains("PASIEN UMUM") = False Then
                    TextBoxNoKartu.Text = arrData(0).ToString.Trim
                End If
            ElseIf arrData(2).ToString.Trim = "TUNAI" Then
                TextBoxNoKartu.Text = "-"
            ElseIf arrData(2).ToString.Trim = "CARD" Or arrData(2).ToString.Trim = "DEBET" Then
                TextBoxNoKartu.Text = arrData(0).ToString.Trim
                ComboBoxJenisBank.Text = arrData(1).ToString.Trim
            End If
        End If
    End Sub

    Private Sub Kalkulasi()
        Dim totalTagihan As Double = TextBoxTotalTagihan.Value
        Dim tblBayar As DataTable = GridControlPembayaran.DataSource
        Dim totalBayar As Double = 0

        If tblBayar IsNot Nothing Then
            tblBayar.AcceptChanges()
            For Each rowBayar As DataRow In tblBayar.Rows
                totalBayar += rowBayar("Jumlah")
            Next
        End If

        Dim kembalian As Double = totalBayar - totalTagihan

        TextBoxTotalBayar.Value = totalBayar
        TextBoxTotalKembali.Value = IIf(kembalian >= 0, kembalian, 0)
    End Sub


    Function CheckAntreanBPJS(ByVal kdprovider_ As String, ByVal noKartu_ As String, ByVal kdPoli_ As String, ByVal tgldaftar_ As String) As Boolean
        Dim urlPcare As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='pcare_base_url'")
        Dim getResponse As String = ""
        Dim uri As String = ""

        uri = urlPcare & "/kunjungan/peserta/" & noKartu_
        getResponse = getDataFromPcare(uri)

        Dim jsonArray As JArray = JArray.Parse(getResponse)

        For Each item As JObject In jsonArray
            If item("response") IsNot Nothing AndAlso item("response").Type <> JTokenType.Null Then
                Dim jsonObject() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of v4_BPJS_Kunjungan())(getResponse)

                For Each rowData As v4_BPJS_Kunjungan In jsonObject
                    If rowData.metaData.message <> "NO_CONTENT" Then
                        For index As Integer = 0 To rowData.response.count - 1
                            If rowData.response.list(index).providerPelayanan.kdProvider = kdprovider_ And rowData.response.list(index).tglKunjungan = tgldaftar_ And rowData.response.list(index).poli.kdPoli = kdPoli_ Then
                                MsgBox("Peserta sudah di-entri di poli yang sama pada hari yang sama.", MsgBoxStyle.Exclamation, "Warning!")
                                Return False
                            End If
                        Next
                    End If
                Next
            End If
        Next

        'If getResponse <> "Nothing" Then


        'For Each rowData As varJson In jsonObject
        '    'If TypeOf rowData.response Is Object Then
        '    '    ' response adalah objek v4_BPJS
        '    '    'Dim responseObj As v4_BPJS = DirectCast(rowData.response, v4_BPJS)
        '    '    Dim responseObj As JObject = DirectCast(rowData.response, JObject)

        '    '    ' Lakukan sesuatu dengan responseObj
        '    '    ' Misalnya, mengakses properti dalam v4_BPJS
        '    '    'Dim propertiA As String = responseObj.propertiA
        '    '    'Dim propertiB As Integer = responseObj.propertiB
        '    '    '' Lakukan sesuatu dengan propertiA dan propertiB (contoh: mencetaknya)
        '    '    'Console.WriteLine("Properti A: " & propertiA)
        '    '    'Console.WriteLine("Properti B: " & propertiB)

        '    '    For index As Integer = 0 To responseObj.Count - 1
        '    '        If responseObj.list(index).providerPelayanan.kdProvider = kdprovider_ And responseObj.list(index).tglKunjungan = tgldaftar_ And responseObj.list(index).poli.kdPoli = kdPoli_ Then
        '    '            MsgBox("Peserta sudah di-entri di poli yang sama pada hari yang sama.", MsgBoxStyle.Exclamation, "Warning!")
        '    '            Return False
        '    '        End If
        '    '    Next
        '    'End If
        '    For index As Integer = 0 To rowData.response.count - 1
        '        If rowData.response.list(index).providerPelayanan.kdProvider = kdprovider_ And rowData.response.list(index).tglKunjungan = tgldaftar_ And rowData.response.list(index).poli.kdPoli = kdPoli_ Then
        '            MsgBox("Peserta sudah di-entri di poli yang sama pada hari yang sama.", MsgBoxStyle.Exclamation, "Warning!")
        '            Return False
        '        End If
        '    Next
        'Next
        'End If

        Return True
    End Function

    Function CheckPayment() As Boolean
        statusBPJS = False ' Set False BPJS
        Kalkulasi()

        If CheckBoxLunasBayar.Checked = True Then
            MessageBox.Show("Gagal!. Transaksi sudah dilakukan pembayaran.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        If TextBoxTotalTagihan.Value > TextBoxTotalBayar.Value Then
            MessageBox.Show("Gagal! Total bayar belum lunas.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        Dim Tbool As Boolean = True
        Dim Tbls As DataTable = GridControlPembayaran.DataSource
        Tbls.AcceptChanges()

        ' Validasi sudah tambah pembayaran atau belum
        If Tbls.Rows.Count = 0 Then
            MessageBox.Show("Gagal! Masukkan jenis pembayaran terlebih dahulu.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        For Each Trow As DataRow In Tbls.Rows
            If Trow("Jenis") = "TUNAI" Then
                Tbool = False
            End If

            If (Trow("NoKartu").ToString = "BPJS-C001" Or Trow("NoKartu").ToString = "BPJS (KLAIM)-C1360") AndAlso CheckBridgingPcareActive() = True Then
                statusBPJS = True ' Set True BPJS
            End If
        Next

        ' Validasi apakah transaksi sudah melakukan pembayaran sebelumnya
        If _jenisTransaksi = "UMUM" Then
            If CheckSQL("SELECT * FROM TransaksiPoli WHERE NoUrut = '" & _nomorUrutTransaksi & "' AND ClosedBayar <> '12/31/9998'") = True Then
                MsgBox("Gagal. Transaksi sudah dilakukan pembayaran tindakan.", MsgBoxStyle.Exclamation, "Warning!")
                Return False
            End If
        ElseIf _jenisTransaksi = "GIGI" Then
            If CheckSQL("SELECT * FROM TransaksiGigi WHERE NoUrut = '" & _nomorUrutTransaksi & "' AND ClosedBayar <> '12/31/9998'") = True Then
                MsgBox("Gagal. Transaksi sudah dilakukan pembayaran tindakan.", MsgBoxStyle.Exclamation, "Warning!")
                Return False
            End If
        End If

        Return True
    End Function

    Function CreateTable() As DataTable
        Dim Thasil As New DataTable

        insertRowToTbls(Thasil, "Typstring", "TindakanID")
        insertRowToTbls(Thasil, "Typstring", "Tindakan")
        insertRowToTbls(Thasil, "Typstring", "Jenis")
        insertRowToTbls(Thasil, "typefloat", "Biaya Tindakan")
        insertRowToTbls(Thasil, "typefloat", "DiscTindakan")
        insertRowToTbls(Thasil, "typefloat", "DiscNilai")
        insertRowToTbls(Thasil, "typefloat", "NettBayar")
        insertRowToTbls(Thasil, "typstring", "Registrasi")
        insertRowToTbls(Thasil, "typstring", "Nama")
        insertRowToTbls(Thasil, "typstring", "Umur")
        insertRowToTbls(Thasil, "typstring", "Alamat")
        insertRowToTbls(Thasil, "typstring", "Tanggal")
        insertRowToTbls(Thasil, "typstring", "NoTransaksi")
        insertRowToTbls(Thasil, "typstring", "DrPengirim")
        insertRowToTbls(Thasil, "typstring", "StatusAmbil")
        insertRowToTbls(Thasil, "typstring", "lblDokter")
        insertRowToTbls(Thasil, "typstring", "lbltitikDokter")
        insertRowToTbls(Thasil, "typstring", "lblStatusAmbil")
        insertRowToTbls(Thasil, "typstring", "lbltitikStatusAmbil")

        For Each Tcol As DataColumn In Thasil.Columns
            Tcol.ReadOnly = True
        Next

        Return Thasil
    End Function

    Private Sub CetakBarcodeKlinik(ByRef key As String)
        Dim Tpos As String = ReadSQLNIK("select StrValue from MsConfig WHERE ConfigName='PathBarcode'")
        Dim KodeBarcode As String = ReadSQLNIK("select StrValue from MsConfig WHERE ConfigName='KodeBarcode'")
        Dim Tpathprf As String = ReadSQLNIK("select StrValue from MsConfig WHERE ConfigName='Pathprf'")
        Dim Ttx As String = Tpos & "Output.txt"
        Dim barcode As String = ""
        Dim totalrow As Integer = 0

        Dim Tinput As String = InputBox("Tambahan Cetakan Print Barcode : ", "Print Barcode", 3)
        If IsNumeric(Tinput) = False Then
            MsgBox("Masukkan Jumlah Barcode yang diprint.", MsgBoxStyle.Exclamation, "Warning!")
            Exit Sub
        End If

        If CInt(Tinput) = 0 Then
            Exit Sub
        End If

        If CInt(Tinput) > 10 Then
            MsgBox("Cetakan tidak boleh lebih dari 10.", MsgBoxStyle.Exclamation, "Warning!")
            Exit Sub
        End If

        Try
            If Tinput > 0 Then
                Dim Tbls2 As DataTable = ReadSQL("SELECT a.NoUrut, a.TransPoliID, c.Nama, CONVERT(varchar(11), c.TglLahir, 106) AS TglLahir, c.JenisKelamin " & _
                                                 "FROM TransaksiPoli a " & _
                                                 "LEFT JOIN MasterPasien c ON c.NoRekamMedis = a.IDInternet " & _
                                                 "WHERE a.TransPoliID = " & key)
                If Tbls2.Rows.Count > 0 Then
                    For Each TrowData As DataRow In Tbls2.Rows

                        Dim Tstrtemp As String = ""
                        If TrowData("NoUrut").ToString.Contains("U") = True Then
                            Tstrtemp = Strings.Replace(TrowData("NoUrut").ToString.Trim, "U", "7")
                        End If

                        barcode = KodeBarcode & Strings.Right(Tstrtemp.ToString.Trim, Len(Tstrtemp.ToString.Trim) - 2)
                        System.Threading.Thread.Sleep(500)

                        For i As Integer = 0 To CInt(Tinput) - 1
                            If System.IO.File.Exists(Ttx) = True Then System.IO.File.Delete(Ttx)
                            Dim objStreamWriter As StreamWriter
                            objStreamWriter = New StreamWriter(Ttx)
                            objStreamWriter.WriteLine("<xpml><page quantity='0' pitch='29.3 mm'></xpml>I8,A")
                            objStreamWriter.WriteLine("ZN")
                            objStreamWriter.WriteLine("q275")
                            objStreamWriter.WriteLine("S3")
                            objStreamWriter.WriteLine("O")
                            objStreamWriter.WriteLine("JF")
                            objStreamWriter.WriteLine("D9")
                            objStreamWriter.WriteLine("ZT")
                            objStreamWriter.WriteLine("Q234,B24")
                            objStreamWriter.WriteLine("KI80")
                            objStreamWriter.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='29.3 mm'></xpml>N")
                            objStreamWriter.WriteLine("B290,177,2,1,2,4,97,N,""" & barcode & """")
                            objStreamWriter.WriteLine("A95,217,2,3,1,1,N,""""""")
                            objStreamWriter.WriteLine("A290,54,2,2,1,1,N,""" & TrowData("Nama").ToString.Trim & """")
                            objStreamWriter.WriteLine("A290,30,2,2,1,1,N,""" & TrowData("TglLahir").ToString.Trim & " / " & TrowData("JenisKelamin").ToString.Trim & """")
                            objStreamWriter.WriteLine("A290,217,2,3,1,1,N,""" & barcode & """")
                            objStreamWriter.WriteLine("P1")
                            objStreamWriter.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
                            objStreamWriter.Close()
                            Process.Start(Tpathprf & "PrFile32.exe ", Ttx)
                        Next
                    Next
                Else
                    MsgBox("Tidak ada data yang di barcode.", MsgBoxStyle.Exclamation, "Warning!")
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            If MsgBox(" Batal untuk Cetak Barcode tambahan ? ", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                Exit Sub
            Else
                MsgBox("Ulangi proses ketika siap.", MsgBoxStyle.Exclamation, "Warning!")
            End If
        End Try
    End Sub

    Private Sub CetakBarcode()
        Dim Tpos As String = ReadSQLNIK("select StrValue from MsConfig WHERE ConfigName='PathBarcode'")
        Dim KodeBarcode As String = ReadSQLNIK("select StrValue from MsConfig WHERE ConfigName='KodeBarcode'")
        Dim Tpathprf As String = ReadSQLNIK("select StrValue from MsConfig WHERE ConfigName='Pathprf'")
        Dim Ttx As String = Tpos & "Output.txt"
        Dim barcode As String = ""
        Dim totalrow As Integer = 0

        Dim Tinput As String = InputBox("Tambahan Cetakan Print Barcode : ", "Print Barcode", 3)
        If IsNumeric(Tinput) = False Then
            MsgBox("Masukkan Jumlah Barcode yang diprint.", MsgBoxStyle.Exclamation, "Warning!")
            Exit Sub
        End If

        If CInt(Tinput) = 0 Then
            Exit Sub
        End If

        If CInt(Tinput) > 10 Then
            MsgBox("Cetakan tidak boleh lebih dari 10.", MsgBoxStyle.Exclamation, "Warning!")
            Exit Sub
        End If

        Try
            If Tinput > 0 Then
                Dim Tbls2 As DataTable = ReadSQL("SELECT a.NoUrut, a.TransLabID, c.Nama, CONVERT(varchar(11), c.TglLahir, 106) AS TglLahir, c.JenisKelamin, a.LabSamplingTime " & _
                                                 "FROM TransaksiLab a " & _
                                                 "LEFT JOIN MasterPasien c ON c.NoRekamMedis = a.IDInternet " & _
                                                 "WHERE a.TransLabID = " & _idTransaksi)
                If Tbls2.Rows.Count > 0 Then
                    For Each TrowData As DataRow In Tbls2.Rows

                        Dim Tstrtemp As String = ""
                        If TrowData("NoUrut").ToString.Contains("L") = True Then
                            Tstrtemp = Strings.Replace(TrowData("NoUrut").ToString.Trim, "L", "8")
                        ElseIf TrowData("NoUrut").ToString.Contains("M") = True Then
                            Tstrtemp = Strings.Replace(TrowData("NoUrut").ToString.Trim, "M", "9")
                        End If

                        barcode = KodeBarcode & Strings.Right(Tstrtemp.ToString.Trim, Len(Tstrtemp.ToString.Trim) - 2)
                        System.Threading.Thread.Sleep(500)

                        For i As Integer = 0 To CInt(Tinput) - 1
                            If System.IO.File.Exists(Ttx) = True Then System.IO.File.Delete(Ttx)
                            Dim objStreamWriter As StreamWriter
                            objStreamWriter = New StreamWriter(Ttx)
                            objStreamWriter.WriteLine("<xpml><page quantity='0' pitch='29.3 mm'></xpml>I8,A")
                            objStreamWriter.WriteLine("ZN")
                            objStreamWriter.WriteLine("q275")
                            objStreamWriter.WriteLine("S3")
                            objStreamWriter.WriteLine("O")
                            objStreamWriter.WriteLine("JF")
                            objStreamWriter.WriteLine("D9")
                            objStreamWriter.WriteLine("ZT")
                            objStreamWriter.WriteLine("Q234,B24")
                            objStreamWriter.WriteLine("KI80")
                            objStreamWriter.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='29.3 mm'></xpml>N")
                            objStreamWriter.WriteLine("B290,177,2,1,2,4,97,N,""" & barcode & """")
                            objStreamWriter.WriteLine("A95,217,2,3,1,1,N,""""""")
                            objStreamWriter.WriteLine("A290,54,2,2,1,1,N,""" & TrowData("Nama").ToString.Trim & """")
                            objStreamWriter.WriteLine("A290,30,2,2,1,1,N,""" & TrowData("TglLahir").ToString.Trim & " / " & TrowData("JenisKelamin").ToString.Trim & """")
                            objStreamWriter.WriteLine("A290,217,2,3,1,1,N,""" & barcode & """")
                            objStreamWriter.WriteLine("P1")
                            objStreamWriter.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
                            objStreamWriter.Close()
                            Process.Start(Tpathprf & "PrFile32.exe ", Ttx)
                        Next

                        If IsDBNull(TrowData("LabSamplingTime")) = True Then
                            WriteSQL("update TransaksiLab set SendKeu=1, [Status]='CHECK', LabSamplingTime=GETDATE() WHERE TransLabID='" & TrowData("TransLabID").ToString.Trim & "' ", 4)
                        Else
                            WriteSQL("update TransaksiLab set SendKeu=1, [Status]='CHECK' WHERE TransLabID='" & TrowData("TransLabID").ToString.Trim & "' ", 4)
                        End If
                    Next
                Else
                    MsgBox("Tidak ada data yang di barcode.", MsgBoxStyle.Exclamation, "Warning!")
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            If MsgBox("Batal untuk Cetak Barcode tambahan ? ", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                Exit Sub
            Else
                MsgBox("Ulangi proses ketika siap.", MsgBoxStyle.Exclamation, "Warning!")
            End If
        End Try
    End Sub

    Private Sub butclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClear.Click
        ClearPembayaran()
        ComboBoxJenisBayar.Focus()
    End Sub

    Function CheckingAdd() As Boolean
        Dim Ttmp As DataTable = GridControlPembayaran.DataSource
        Ttmp.AcceptChanges()

        Dim txCompany As String = TextBoxNoKartu.Text

        ' Validasi apakah nominal diatas 0 (Kecuali BPJS & Tagihan)
        If TextBoxTotalTagihan.Value <= 0 And ComboBoxJenisBayar.Text <> "TAGIHAN" Then
            MsgBox("Total Tagihan tidak boleh Rp. 0 jika ingin menambahkan metode pembayaran.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        ' Validasi Pendaftaran Pasien Dengan Poli Yang Sama Dalam 1 Hari
        If _jenisTransaksi = "AWAL" Or _jenisTransaksi = "AWALGIGI" Then
            If txCompany.Contains("BPJS") AndAlso CheckBridgingPcareActive() = True Then
                If CheckSQL("SELECT * FROM TransaksiDetail WHERE StatusBPJS = 'True' AND IDInternet = '" & _noRekamMedis & "' AND JenisPoli = '" & _namaPoli & "' AND CONVERT(DATE, TanggalTransaksi) = '" & Format(DateAndTime.Now, "yyyy-MM-dd") & "' AND DeletedDate IS NULL") = True Then
                    MessageBox.Show("Pasien tersebut sudah pernah input BPJS di hari & poli yang sama.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return False
                End If
            End If
        End If

        ' Validasi Max. Jumlah Jenis Pembayaran
        If Ttmp.Rows.Count > 10 Then
            MsgBox("Maksimal jenis pembayaran hanya 10 jenis.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        If ComboBoxJenisBayar.FindStringExact(ComboBoxJenisBayar.Text) < 0 Then
            MsgBox("Pilih Jenis Pembayaran yang sesuai.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        If ComboBoxJenisBayar.Text = "TUNAI" Or ComboBoxJenisBayar.Text = "DISC" Then
            If ComboBoxJenisBayar.Text = "TUNAI" Then
                Dim Tbls As DataTable = GridControlPembayaran.DataSource
                Tbls.AcceptChanges()
                For Each Tcol As DataColumn In Tbls.Columns
                    Tcol.ReadOnly = False
                Next

                Dim Tbool As Boolean = False
                For Each Trow As DataRow In Tbls.Rows
                    If Trow("Jenis") = "TUNAI" Then
                        If MsgBox("Ada nilai pembayaran tunai. Apakah ditambahkan ?", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                            Trow("Jumlah") = CInt(Trow("Jumlah")) + CInt(TextBoxJumlahBayar.Value)
                            Tbool = True
                        End If
                    End If
                Next
                If Tbool = True Then
                    GridControlPembayaran.DataSource = Tbls
                    Kalkulasi()
                    Return False
                End If
            ElseIf ComboBoxJenisBayar.Text = "DISC" Then
                If CheckSQL("select * from DiscountNumber WHERE DiscNo='" & TextBoxNoKartu.Text & "' AND Used=0") = False Then
                    MsgBox("Kode promo Voucher tidak dikenali. Check kembali")
                    Return False
                End If
                Dim Tbls As DataTable = GridControlPembayaran.DataSource
                Tbls.AcceptChanges()
                For Each Tcol As DataColumn In Tbls.Columns
                    Tcol.ReadOnly = False
                Next

                Dim Tbool As Boolean = False
                For Each Trow As DataRow In Tbls.Rows
                    If Trow("Jenis") = "DISC" Then
                        If MsgBox("Ada nilai pembayaran dengan Disc. Apakah ditambahkan ?", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                            Trow("Jumlah") = CInt(Trow("Jumlah")) + CInt(TextBoxJumlahBayar.Value)
                            Trow("NoKartu") = TextBoxNoKartu.Text
                            Tbool = True
                        End If
                    End If
                Next
                If Tbool = True Then
                    GridControlPembayaran.DataSource = Tbls
                    Kalkulasi()
                    Return False
                End If
            End If
        ElseIf ComboBoxJenisBayar.Text = "TAGIHAN" Then
            Dim Tcomp() As String = TextBoxNoKartu.Text.Split("-")
            If Tcomp.Length <> 2 Then
                MsgBox("Check kembali company yang dituju sebagai tagihan")
            ElseIf Tcomp.Length = 2 Then
                If Tcomp(1).ToString = "" Then
                    MsgBox("Nama Company tidak boleh kosong")
                    Return False
                Else
                    Dim Tbool As String = False
                    If CheckSQL("select * from MasterCompany WHERE CompanyCode='" & Tcomp(1).ToString & "'") = True Then
                        Tbool = True
                    End If

                    If CheckSQL("select * from MasterCompany WHERE NoCompany='" & Tcomp(1).ToString & "'") = True Then
                        Tbool = True
                    End If

                    If Tbool = False Then
                        MsgBox("Company tidak dikenali. Check kembali")
                        Return False
                    End If

                End If
            End If

            Dim tblTagihan As DataTable = GridControlPembayaran.DataSource

            For Each Trow As DataRow In tblTagihan.Rows
                If Trow("Jenis") = "TAGIHAN" And Trow("NoKartu") = TextBoxNoKartu.Text Then
                    MsgBox("Company Tagihan sudah pernah di input.", MsgBoxStyle.Exclamation, "Warning!")
                    Return False
                End If
            Next
        ElseIf ComboBoxJenisBayar.Text = "DEBET" Or ComboBoxJenisBayar.Text = "CARD" Then
            If ComboBoxJenisBank.FindStringExact(ComboBoxJenisBank.Text) < 0 Then
                MsgBox("Pilih jenis bank yang digunakan")
                Return False
            End If

            If ComboBoxJenisEDC.FindStringExact(ComboBoxJenisEDC.Text) < 0 Then
                MsgBox("Pilih jenis Mesin EDC yang digunakan")
                Return False
            End If

            If TextBoxNoKartu.Text = "" Then
                MsgBox("Isi no kartu sesuai ketentuan")
                Return False
            End If
        Else
            If TextBoxNoKartu.Text = "" Then
                MsgBox("Isi no kartu sesuai ketentuan")
                Return False
            End If
        End If

        If txCompany.Contains("BPJS") Then
            ' Validasi apakah sudah input nomor BPJS
            Dim noBPJS As String = ReadSQLNIK("SELECT NoKartuBPJS FROM MasterPasien WHERE NoRekamMedis = '" & TextBoxNomorRM.Text & "';")

            If CheckBridgingPcareActive() = True Then
                ' Validasi apakah sudah klik button BPJS
                If CheckSQL("SELECT * FROM MasterPasienBPJS WHERE NoKartu = '" & noBPJS & "'") = False Then
                    MsgBox("Klik tombol cek BPJS terlebih dahulu di master pasien agar mendapat kode provider.", MsgBoxStyle.Exclamation, "Warning!")
                    Return False
                End If
            End If

            If noBPJS.Length = 0 Then
                MsgBox("Masukkan No BPJS terlebih dahulu di master pasien.", MsgBoxStyle.Exclamation, "Warning!")
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub ButtonTambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTambah.Click
        ' Nanti diaktifkan
        If CheckingAdd() = True Then

            Dim Ttemp As DataTable = GridControlPembayaran.DataSource
            Dim Trow As DataRow = Ttemp.NewRow
            Trow("Jenis") = ComboBoxJenisBayar.Text
            Dim Txx As String = ""

            For i As Integer = 0 To TextBoxNoKartu.Text.Length - 1
                Txx = Txx + "*"
            Next

            If ComboBoxJenisBayar.Text = "DEBET" Or ComboBoxJenisBayar.Text = "CARD" Then
                Trow("NoKartu") = Txx
                Trow("KartuData") = TextBoxNoKartu.Text
                Trow("MesinData") = ComboBoxJenisEDC.Text
                Trow("JenisKartu") = ComboBoxJenisBank.Text
            Else
                Trow("NoKartu") = TextBoxNoKartu.Text
                Trow("KartuData") = TextBoxNoKartu.Text
                Trow("MesinData") = ""
                Trow("JenisKartu") = ComboBoxJenisBank.Text
            End If

            Trow("Jumlah") = Splitmoney(TextBoxJumlahBayar.Value)
            CheckBoxNominalTagihan.Checked = False
            Ttemp.Rows.Add(Trow)
            Ttemp.AcceptChanges()
            Kalkulasi()
            ClearPembayaran()
        End If
    End Sub

    Private Sub GridView1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridView1.KeyUp
        If e.KeyCode = Keys.Delete And GridView1.SelectedRowsCount > 0 Then
            Dim Trow As DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
            If MsgBox("Yakin menghapus Pembayaran tersebut ? ", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                If Trow("Jenis").ToString = "TAGIHAN" Then
                    ButtonClear.Enabled = True
                    ButtonTambah.Enabled = True
                End If
                GridView1.DeleteRow(GridView1.FocusedRowHandle)
                GridControlPembayaran.RefreshDataSource()
                Kalkulasi()
            End If
        End If
    End Sub

    Private Sub cmbjenisbayar_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxJenisBayar.SelectedIndexChanged
        ComboBoxJenisBank.Enabled = False
        ComboBoxJenisEDC.Enabled = False

        If ComboBoxJenisBayar.Text = "" Then
            TextBoxNoKartu.ReadOnly = True
            ComboBoxJenisBank.SelectedIndex = -1
            ComboBoxJenisEDC.SelectedIndex = -1
            txnokartupembayaran.Text = "No Kartu"
            butcompany.Enabled = False
            TextBoxNoKartu.ResetText()
        ElseIf ComboBoxJenisBayar.Text = "TUNAI" Or ComboBoxJenisBayar.Text = "TAGIHAN" Then
            TextBoxNoKartu.ReadOnly = True
            txnokartupembayaran.Text = "No Kartu"
            TextBoxNoKartu.Text = "-"
            butcompany.Enabled = False
            If ComboBoxJenisBayar.Text = "TAGIHAN" Then
                txnokartupembayaran.Text = "Company"
                butcompany.Enabled = True
            End If
            ComboBoxJenisBank.SelectedIndex = -1
            ComboBoxJenisEDC.SelectedIndex = -1
            TextBoxJumlahBayar.Focus()
        Else
            TextBoxNoKartu.ReadOnly = False
            txnokartupembayaran.Text = "No Kartu"
            butcompany.Enabled = False
            TextBoxNoKartu.ResetText()
            If ComboBoxJenisBayar.Text = "CARD" Or ComboBoxJenisBayar.Text = "DEBET" Then
                ComboBoxJenisBank.Enabled = True
                ComboBoxJenisEDC.Enabled = True
                ComboBoxJenisBank.SelectedIndex = -1
                ComboBoxJenisEDC.SelectedIndex = -1
            End If

            If txbayarfromQRcode.Text.Trim = "" Then
                Dim Tnokartu = InputBox("Input Kartu", "Check Kartu", "")
                If Tnokartu <> "" Then
                    Dim Ttemp As String = Strings.Replace(Tnokartu.ToString, "%B", "")
                    Dim Tkartu() As String = Ttemp.Split("^")
                    If Tkartu(0) <> "" Then
                        TextBoxNoKartu.Text = Tkartu(0).ToString
                        ComboBoxJenisBank.Focus()
                    Else
                        MsgBox("Kartu tidak dikenali. Check kembali.")
                    End If
                End If
            End If
        End If
    End Sub

    Public Sub LoadCompany(ByRef Txid As String)
        Dim Temp As DataTable = ReadSQL("select * from MasterCompany WHERE NoCompany='" & Txid & "'")
        Dim Tnrow As DataRow = Temp.Rows(0)
        TextBoxNoKartu.Text = Tnrow("CompanyNama").ToString & "-" & Tnrow("NoCompany").ToString
        ComboBoxJenisEDC.Enabled = False
        ComboBoxJenisBank.Enabled = False
        TextBoxJumlahBayar.Focus()
        txnokartupembayaran.Text = "Company"
    End Sub

    Private Sub butcompany_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butcompany.Click
        Try
            Find.Query("SELECT NoCompany, CompanyCode, CompanyNama FROM MasterCompany WHERE GETDATE() BETWEEN StartDate AND EndDate", " ORDER BY NoCompany DESC", "FindCompanyTagihanPembayaran", 2)
            Find.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CheckBoxNominalTagihan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxNominalTagihan.CheckedChanged
        If CheckBoxNominalTagihan.Checked = True Then
            TextBoxJumlahBayar.Value = TextBoxTotalTagihan.Value
        ElseIf CheckBoxNominalTagihan.Checked = False Then
            TextBoxJumlahBayar.Value = 0
        End If
    End Sub

    Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
        'If TboolClick = True Then
        '    If Utility.GetConfig("DualLayar") = "Yes" Then
        '        Dim OpenCMD
        '        OpenCMD = CreateObject("wscript.shell")
        '        OpenCMD.run("DisplaySwitch.exe /external")
        '        Survey.SetNama(TextBoxNama.Text, _jenisTransaksi, "-", _noRekamMedis, "PAY") ' Simbol - ganti dengan no transaksi
        '        Survey.Show()
        '        Survey.SetNama(TextBoxNama.Text, _jenisTransaksi, "-", _noRekamMedis, "PAY") ' Simbol - ganti dengan no transaksi
        '        Survey.WindowState = FormWindowState.Maximized
        '    Else
        '        'Dual Layar No
        '        Me.Close()
        '    End If
        'Else
        '    MsgBox("Pembayaran Harus Dilunasi Sebelum Survey")
        'End If

        If CheckBoxLunasBayar.Checked = True Then
            Me.Close()
        Else
            Dim questionResult As DialogResult

            questionResult = MessageBox.Show("Yakin batal transaksi dan kembali ke perhitungan awal?", "Validasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If questionResult = DialogResult.Yes Then
                Me.Close()
            End If
        End If
    End Sub

    Public Sub SetDataFromPendaftaran(ByVal Ttotal As String, ByVal TTbls As DataTable, ByVal Tbruto As String, ByVal Tdisc As String, ByVal Tbulat As String)
        SetClear()
        tblTindakan = TTbls
        TextBoxNomorRM.Text = _noRekamMedis
        TextBoxNama.Text = _namaPasien
        TextBoxTotalTagihan.Value = CDbl(Ttotal)
        txtotalbruto = CDbl(Tbruto)
        txtotaldisc = CDbl(Tdisc)
        txtotalpembulatan = CDbl(Tbulat)

        ' Set nilai default
        NoUrutBPJS = ""

        ComboBoxJenisBank.SelectedIndex = -1
        ComboBoxJenisEDC.SelectedIndex = -1
    End Sub

    Private Sub SaveDataPembayaran()
        '# Variabel Umum
        Dim NewHeader As DataTable = CreateTable()
        Dim Jeniscetak As String = Utility.GetConfig("Jeniscetak")
        Dim JenisBayarSaved As String = ""
        Dim JenisBayarSavedKet As String = ""
        Dim kodeDokter As String = ""
        Dim statusPaket As Boolean = False
        Dim penjaminTindakan As String = ""

        ' Generate Kode Voucher (Jika Pembelian Baru)
        Dim voucherID As String = GetUUID()

        ' Get Data Master Poli Tujuan
        Dim tblPoli As DataTable = ReadSQL("SELECT * FROM MasterPoliTujuan WHERE NamaPoli = '" & _namaPoli & "'")
        Dim rowPoli As DataRow = tblPoli.Rows(0)

        If CheckPayment() = True Then
            If _jenisTransaksi = "AWAL" Or _jenisTransaksi = "AWALGIGI" Then
                Dim versiProgramAntrol As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'versi_program_antrian_online'")

                If statusBPJS = True AndAlso CheckBridgingPcareActive() = True Then
                    ' Post Pendaftaran PCare (Antrol v1)
                    If versiProgramAntrol = "v1" AndAlso SendPCareDataV1() = False Then Exit Sub

                    ' Post Pendaftaran PCare & Flag Status Hadir di SINA (Antrol v2)
                    If versiProgramAntrol = "v2" AndAlso SendPCareDataV2() = False Then Exit Sub
                Else
                    ' Flag Status Hadir di SINA (Antrol v2)
                    If versiProgramAntrol = "v2" Then SetStatusHadir()
                End If
            End If

            ' Get Kode Dokter
            kodeDokter = ReadSQLNIK("SELECT ID FROM MasterDokter WHERE Nama = '" & _namaDokter & "'")

            ' Generate No Urut Transaksi Jika Masih Kosong
            If _nomorUrutTransaksi = "" Then _nomorUrutTransaksi = generateNoTransaksi(rowPoli("KodeTransaksi"), rowPoli("JenisPoli"), DateTime.Now.ToString("yyyyMMdd"), False)

            If _jenisTransaksi = "AWAL" Then
                ' Insert TransaksiPoli
                WriteSQL("INSERT INTO TransaksiPoli (IDInternet, DokterPoli, PerawatPoli, TglPoli, CreatedDate, CreatedBy, ClosedBayar, KodeDokter, NoUrut, StatusKeterangan, StatusTransaksi, ArrivedDate, MarketingPoli) " & _
                     "VALUES('" & _noRekamMedis & "','" & _namaDokter & "', '" & _namaPerawat & "', GETDATE(), GETDATE(),'" & userInput & "', '12/31/9998', '" & kodeDokter & "', '" & _nomorUrutTransaksi & "', 'Belum Diperiksa', 'arrived', GETDATE(), '" & _namaMarketing & "')", 4)

                ' Set ID Poli
                _idTransaksi = ReadSQLNIK("SELECT TransPoliID FROM TransaksiPoli WHERE NoUrut = '" & _nomorUrutTransaksi & "'")

                Dim Tuang As DataTable = GridControlPembayaran.DataSource
                Tuang.AcceptChanges()

                For Each rowBayar As DataRow In Tuang.Rows
                    ' Insert ke tabel TransaksiPoliBayarAwal
                    WriteSQL("INSERT INTO TransaksiPoliBayarAwal (TransJenis, TransPoliID, JenisBayar, NoJenisBayar, JumlahBayar, admin, transaksitime, mesin, kartu) " & _
                             "VALUES('POLI','" & _idTransaksi & "','" & rowBayar("Jenis") & "','" & rowBayar("KartuData") & "','" & CDbl(rowBayar("Jumlah")) & "','" & userInput & "',GETDATE(),'" & rowBayar("MesinData") & "','" & rowBayar("JenisKartu") & "')", 4)

                    If penjaminTindakan <> "Tanpa Asuransi / Umum" Then
                        If rowBayar("Jenis") = "TUNAI" Or rowBayar("Jenis") = "DEBET" Or rowBayar("Jenis") = "CARD" Then
                            penjaminTindakan = "Tanpa Asuransi / Umum"
                        Else
                            Dim splitKeteranganBayar() As String = rowBayar("KartuData").ToString.Split("-")
                            penjaminTindakan = splitKeteranganBayar(0)
                        End If
                    End If
                Next

                ' Insert ke tabel TransaksiPoliDetail (Cek Inputan Paket / Tindakan)
                If _jenisTindakan = "Tindakan" Then
                    For Each Trow As DataRow In tblTindakan.Rows
                        ' Cek apakah KodeVoucher kosong atau null
                        Dim voucherIDValue As String = If(String.IsNullOrEmpty(Trow("KodeVoucher").ToString()), "NULL", "'" & Trow("KodeVoucher").ToString() & "'")

                        WriteSQL("INSERT INTO TransaksiPoliDetail(Awal, TransPoliID, PaketID, TindakanID, NamaTindakan, JenisTindakan, BiayaTindakan, DiscTindakan, NettBayar, admin, transaksitime, DiscPersenTindakan, StatusPembayaran, KodeVoucher, Penjamin) " & _
                                 "VALUES('1', '" & _idTransaksi & "' ,'" & Trow("PaketID") & "', '" & Trow("TindakanID") & "', '" & Trow("Tindakan") & "', '" & Trow("Jenis") & "', " & CDbl(Trow("Biaya Tindakan")) & ", " & CDbl(Trow("DiscNilai")) & ", " & CDbl(Trow("NettBayar")) & ", '" & userInput & "', GETDATE(), 0, 'PAID', " & voucherIDValue & ", '" & penjaminTindakan & "')", 4)
                    Next
                ElseIf _jenisTindakan = "Paket" Then
                    For Each rowTindakan As DataRow In tblTindakan.Rows
                        WriteSQL("INSERT INTO TransaksiPoliDetail(Awal, TransPoliID, PaketID, NamaTindakan, JenisTindakan, BiayaTindakan, DiscTindakan, NettBayar, admin, transaksitime, DiscPersenTindakan, StatusPembayaran, KodeVoucher, Penjamin) " & _
                                         "VALUES('1', '" & _idTransaksi & "' ,'" & rowTindakan("PaketID") & "', '" & rowTindakan("Nama Paket") & "', '-', " & CDbl(rowTindakan("Harga Awal")) & ", " & CDbl(rowTindakan("Diskon")) & ", " & CDbl(rowTindakan("Harga Nett")) & ", '" & userInput & "', GETDATE(), 0, 'PAID', '" & voucherID & "', '" & penjaminTindakan & "')", 4)
                    Next

                    statusPaket = True ' Set Status Paket
                End If

                ' Set Jenis Bayar
                Dim jenisBayar As String = GetJenisPembayaran("POLI", _nomorUrutTransaksi)

                ' Insert TransaksiDetail
                WriteSQL("INSERT INTO TransaksiDetail(NoUrutBPJS, NoTransaksi, JenisKunjungan, JenisRawat, JenisTransaksi, JenisPoli, JenisPenagihan, TanggalTransaksi, KeluhanUtama, KeluhanTambahan, IDInternet, StatusBPJS, NoUrut, StatusHandaya, StatusLansia, StatusDifabel, StatusGawatDarurat, CreatedBy, CreatedDate, TransaksiPaket) " & _
                         "VALUES('" & NoUrutBPJS & "', '" & _idTransaksi & "', '" & _jenisKunjungan & "', '" & _jenisRawat & "', 'POLI', '" & _namaPoli & "', '" & jenisBayar & "', GETDATE(),'" & _keluhanUtama & "', '" & _keluhanTambahan & "', " & _
                         "'" & _noRekamMedis & "'," & Convert.ToInt32(statusBPJS) & ", '" & _nomorUrutTransaksi & "', '" & _statusHandaya & "', '" & _statusLansia & "', '" & _statusDifabel & "', '" & _statusGawatDarurat & "', '" & userInput & "', GETDATE(), " & Convert.ToInt32(statusPaket) & ")", 4)

                '' Set Data Pasien
                'Dim tblsPasien As DataTable = ReadSQL("SELECT Nama + ' / (' + JenisKelamin + ')' AS 'Nama', YEAR(TglLahir) AS 'TahunLahir', MONTH(TglLahir) AS 'BulanLahir', DAY(TglLahir) AS 'TanggalLahir', " & _
                '                                      "CONVERT(VARCHAR(11),TglLahir,106) AS 'TanggalLengkap', DomisiliAlamat AS 'Alamat' " & _
                '                                      "FROM MasterPasien WHERE NoRekamMedis = '" & _noRekamMedis & "'")
                'Dim TrowPasien As DataRow = tblsPasien.Rows(0)
                'Dim Tdate As Date = DateSerial(TrowPasien("TahunLahir"), TrowPasien("BulanLahir"), TrowPasien("TanggalLahir"))

                'NewHeader.Rows.Clear()
                'For Each rowTindakan As DataRow In tblTindakan.Rows
                '    If _jenisTindakan = "Tindakan" Then
                '        Dim Tnew As DataRow = NewHeader.NewRow
                '        Tnew("TindakanID") = rowTindakan("TindakanID")
                '        Tnew("Tindakan") = rowTindakan("Tindakan")
                '        Tnew("Jenis") = rowTindakan("Jenis")
                '        Tnew("Biaya Tindakan") = rowTindakan("Biaya Tindakan")
                '        Tnew("DiscTindakan") = rowTindakan("DiscTindakan")
                '        Tnew("DiscNilai") = rowTindakan("DiscNilai")
                '        Tnew("NettBayar") = rowTindakan("NettBayar")

                '        Tnew("Registrasi") = _noRekamMedis
                '        Tnew("Nama") = TrowPasien("Nama")
                '        Tnew("Umur") = TrowPasien("TanggalLengkap") & " / " & Umur(Tdate.Date)
                '        Tnew("Alamat") = TrowPasien("Alamat")
                '        Tnew("Tanggal") = Format(DateAndTime.Now, "dd-MMM-yyyy")
                '        Tnew("NoTransaksi") = _nomorUrutTransaksi + " (" + _idTransaksi + ")"
                '        Tnew("DrPengirim") = _namaDokter
                '        Tnew("StatusAmbil") = ""
                '        Tnew("lblDokter") = "Dr. Pelaksana"
                '        Tnew("lblStatusAmbil") = ""
                '        Tnew("lbltitikDokter") = ":"
                '        Tnew("lbltitikStatusAmbil") = ""
                '        NewHeader.Rows.Add(Tnew)
                '    ElseIf _jenisTindakan = "Paket" And rowTindakan("KodeVoucher").ToString() = "" Then
                '        Dim Tnew As DataRow = NewHeader.NewRow
                '        Dim hargaAwal As Decimal = Convert.ToDecimal(rowTindakan("Harga Awal"))
                '        Dim diskon As Decimal = Convert.ToDecimal(rowTindakan("Diskon"))

                '        ' Menghitung persentase diskon berdasarkan harga awal dan diskon
                '        Dim discTindakan As Decimal
                '        If hargaAwal > 0 Then
                '            discTindakan = (diskon / hargaAwal) * 100
                '        Else
                '            discTindakan = 0 ' Menghindari pembagian dengan nol
                '        End If

                '        Tnew("TindakanID") = rowTindakan("PaketID").ToString()
                '        Tnew("Tindakan") = rowTindakan("Nama Paket")
                '        Tnew("Jenis") = rowTindakan("Keterangan Paket")
                '        Tnew("Biaya Tindakan") = rowTindakan("Harga Awal")
                '        Tnew("DiscTindakan") = discTindakan
                '        Tnew("DiscNilai") = rowTindakan("Diskon")
                '        Tnew("NettBayar") = rowTindakan("Harga Nett")

                '        Tnew("Registrasi") = _noRekamMedis
                '        Tnew("Nama") = TrowPasien("Nama")
                '        Tnew("Umur") = TrowPasien("TanggalLengkap") & " / " & Umur(Tdate.Date)
                '        Tnew("Alamat") = TrowPasien("Alamat")
                '        Tnew("Tanggal") = Format(DateAndTime.Now, "dd-MMM-yyyy")
                '        Tnew("NoTransaksi") = _nomorUrutTransaksi + " (" + _idTransaksi + ")"
                '        Tnew("DrPengirim") = _namaDokter
                '        Tnew("StatusAmbil") = ""
                '        Tnew("lblDokter") = "Dr. Pelaksana"
                '        Tnew("lblStatusAmbil") = ""
                '        Tnew("lbltitikDokter") = ":"
                '        Tnew("lbltitikStatusAmbil") = ""
                '        NewHeader.Rows.Add(Tnew)
                '    End If
                'Next

                ' DELETE
                WriteSQL("UPDATE TransaksiPoli SET TotalTagihan = " & CDbl(txtotalbruto) & ", TotalDisc = " & CDbl(txtotaldisc) & ", Pembulatan = " & CDbl(txtotalpembulatan) & ", NettBayar = " & CDbl(TextBoxTotalTagihan.Value) & ", TotalBayar = " & CDbl(TextBoxTotalBayar.Value) & ", Pengembalian = " & CDbl(TextBoxTotalKembali.Value) & " WHERE TransPoliID = '" & _idTransaksi & "'", 4)

                If TextBoxTotalKembali.Value > 0 Then
                    WriteSQL("UPDATE TransaksiPoliBayarAwal SET Kembali='" & CDbl(TextBoxTotalKembali.Value) & "' WHERE TransPoliID='" & _idTransaksi & "' AND JenisBayar='TUNAI' AND TransJenis='POLI'", 4)
                End If

                'Report = New XtraReport

                'If Jeniscetak = "Struk" Then
                '    Report = XtraReport.FromFile(Application.StartupPath + "\reports\PrintTindakanStruk.repx", True)
                'Else
                '    Report = XtraReport.FromFile(Application.StartupPath + "\reports\Resource\PrintInvoiceTransaksi.repx", True)
                'End If

                'Report.DataSource = NewHeader

                'If Jeniscetak = "Struk" Then
                '    Report.Bands.Item(BandKind.TopMargin).Controls("txalamat").Text = Utility.GetConfig("CompanyAddr")
                '    Report.Bands.Item(BandKind.TopMargin).Controls("txtelfon").Text = Utility.GetConfig("CompanyContact")
                '    Report.Bands.Item(BandKind.TopMargin).Controls("txfaskes").Text = Utility.GetConfig("CompanyFaskes")
                'End If

                'Report.Bands.Item(BandKind.ReportFooter).Controls("lblBayar").Text = Splitmoney(TextBoxTotalBayar.Value)
                'Report.Bands.Item(BandKind.ReportFooter).Controls("lblKembalian").Text = Splitmoney(TextBoxTotalKembali.Value)
                'Report.Bands.Item(BandKind.BottomMargin).Controls("lbladmin").Text = userInput
                'Report.Bands.Item(BandKind.BottomMargin).Controls("lbltanggalcetak").Text = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mmm:ss")

                'Dim Ttemp As DataTable = ReadSQL("SELECT * FROM TransaksiPoliBayarAwal WHERE TransPoliID = '" & _idTransaksi & "' AND TransJenis='POLI'")
                'If Ttemp.Rows.Count > 1 Then
                '    For i As Integer = 1 To Ttemp.Rows.Count
                '        Dim Trow As DataRow = Ttemp.Rows(i - 1)
                '        Dim Tket As String = "bayar" & i
                '        Report.Bands.Item(BandKind.ReportFooter).Controls(Tket).Visible = True
                '        If Trow("JenisBayar") = "TAGIHAN" Or Trow("JenisBayar") = "TUNAI" Then
                '            Report.Bands.Item(BandKind.ReportFooter).Controls(Tket).Text = Trow("JenisBayar") & " - Jumlah : " & Splitmoney(Trow("JumlahBayar"))
                '        Else
                '            Report.Bands.Item(BandKind.ReportFooter).Controls(Tket).Text = Trow("JenisBayar") & " - No Kartu : " & "*".PadRight(Len(Trow("NoJenisBayar")) - 3) & Strings.Right(Trow("NoJenisBayar"), 3) & Trow("kartu") & " - Jumlah : " & Splitmoney(Trow("JumlahBayar"))
                '        End If
                '    Next
                'Else
                '    Report.Bands.Item(BandKind.ReportFooter).Controls("bayar1").Text = "-"
                'End If

                'If Jeniscetak = "Struk" Then
                '    Report.PageHeight = txtotalrow
                'End If

                ' Insert Transaksi Paket (Jika ada)
                For Each rowTindakan As DataRow In tblTindakan.Rows
                    If rowTindakan("KodeVoucher").ToString() = "" And _jenisTindakan = "Paket" Then
                        ' Insert Tabel TransaksiPaketTindakan
                        WriteSQL("INSERT INTO TransaksiPaketTindakan(NoRekamMedis, NoTransaksi, PaketID, NamaPaket, KeteranganPaket, JenisPaket, TanggalMulaiPaket, TanggalAkhirPaket, HargaAwal, DiskonNominal, HargaNett, Kuota, DetailTindakan, StatusPembayaran, KodeVoucher, Penjamin, CreatedBy, CreatedDate) " & _
                                 "VALUES('" & _noRekamMedis & "', '" & _nomorUrutTransaksi & "', '" & rowTindakan("PaketID") & "', '" & rowTindakan("Nama Paket") & "', '" & rowTindakan("Keterangan Paket") & "', '" & rowTindakan("Jenis Paket") & "', GETDATE(), DATEADD(DAY, " & rowTindakan("DurasiAktif") & ", GETDATE()), " & CDbl(rowTindakan("Harga Awal")) & ", " & _
                                 "" & CDbl(rowTindakan("Diskon")) & ", " & CDbl(rowTindakan("Harga Nett")) & ", '" & rowTindakan("Kuota") & "', '" & rowTindakan("DetailTindakan") & "', 'PAID', '" & voucherID & "', '" & penjaminTindakan & "', '" & userInput & "', GETDATE())", 4)

                        ' Insert Tabel TransaksiPaketTindakanDetail
                        Dim tblPaketDetail As DataTable = ReadSQL("SELECT * FROM MasterPaketTindakanDetail WHERE PaketID = '" & rowTindakan("PaketID") & "'")
                        For Each rowPaketDetail As DataRow In tblPaketDetail.Rows
                            WriteSQL("INSERT INTO TransaksiPaketTindakanDetail(PaketID, KodeVoucher, TindakanID, NamaTindakan, JenisTindakan, BiayaTindakan, DiskonTindakan, NettBayar, Jumlah, GrandTotal, KuotaTindakan, CreatedBy, CreatedDate) " & _
                                     "VALUES('" & rowPaketDetail("PaketID").ToString() & "', '" & voucherID & "', '" & rowPaketDetail("TindakanID") & "', '" & rowPaketDetail("NamaTindakan") & "', '" & rowPaketDetail("JenisTindakan") & "', " & _
                                     CDbl(rowPaketDetail("BiayaTindakan")) & ", " & CDbl(rowPaketDetail("DiskonTindakan")) & ", " & CDbl(rowPaketDetail("NettBayar")) & ", '" & rowPaketDetail("Jumlah") & "', " & _
                                     CDbl(rowPaketDetail("GrandTotal")) & ", '" & rowPaketDetail("Jumlah") & "', '" & userInput & "', GETDATE())", 4)
                        Next

                        ' Set Status QR
                        statusQR = True
                        keteranganQR = voucherID
                    ElseIf rowTindakan("KodeVoucher").ToString() <> "" And rowTindakan("Klasifikasi") = "Paket" Then
                        ' Insert Tabel LogPenggunaanPaket
                        WriteSQL("INSERT INTO LogPenggunaanPaket(NoRekamMedis, NoTransaksi, PaketID, TanggalTransaksi, KodeVoucher, CreatedBy, CreatedDate) " & _
                                 "VALUES('" & _noRekamMedis & "', '" & _nomorUrutTransaksi & "', '" & rowTindakan("PaketID") & "', GETDATE(), '" & rowTindakan("KodeVoucher").ToString() & "', '" & userInput & "', GETDATE())", 4)

                        ' Update Sisa Kuota Paket
                        WriteSQL("UPDATE TransaksiPaketTindakan SET Kuota = Kuota - 1 WHERE PaketID = '" & rowTindakan("PaketID") & "' AND KodeVoucher = '" & rowTindakan("KodeVoucher").ToString() & "' AND DeletedDate IS NULL", 4)
                    End If
                Next

                ' Set QR (Report)
                'If statusQR = True Then
                '    Dim Generator As New MessagingToolkit.Barcode.BarcodeEncoder
                '    Dim qrImage As Bitmap = New Bitmap(Generator.Encode(MessagingToolkit.Barcode.BarcodeFormat.QRCode, keteranganQR))

                '    Dim pictureBox As XRPictureBox = CreateXRPictureBox(qrImage, 0, 0, 175, 100)
                '    Dim panelQR As XRPanel = CType(Report.Bands(BandKind.ReportFooter).Controls("xrPanelQR"), XRPanel)

                '    ' Add pictureBox
                '    panelQR.Controls.Add(pictureBox)

                '    ' Set Visible
                '    panelQR.Visible = True
                '    Report.Bands.Item(BandKind.ReportFooter).Controls("xrLabelKodeVoucher").Visible = True
                'End If

                ' Insert / Update Detail Waktu Transaksi (WaktuSelesaiPendaftaran)
                SetDetailWaktuTransaksi(_nomorUrutTransaksi, "WaktuSelesaiPendaftaran", userInput)

                ' Pesan Success
                If NoUrutBPJS = "" Then
                    ' Non BPJS
                    MsgBox("Berhasil Menyimpan Data Pendaftaran Pasien." & vbCrLf & "No Transaksi : " & _nomorUrutTransaksi, MsgBoxStyle.Information, "Success!")
                Else
                    ' BPJS
                    MsgBox("Berhasil Menyimpan Data Pendaftaran Pasien." & vbCrLf & "No Transaksi : " & _nomorUrutTransaksi & vbCrLf & "No Urut BPJS : " & NoUrutBPJS, MsgBoxStyle.Information, "Success!")
                End If

                ' Cetak Barcode
                If MsgBox("Apakah anda ingin mencetak barcode pasien atas nama " & _namaPasien & "?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    CetakBarcodeKlinik(_idTransaksi)
                End If

                'Report.RunDesigner()
                'Report.ShowPreview()
                'Report.Print()

                '# Close Form
                'Me.Close()

                '# Set Clear FormPendaftaranAwal
                FormPendaftaranAwal.ClearDataPendaftaranAwal()

                ' Checklist Lunas
                CheckBoxLunasBayar.Checked = True
            ElseIf _jenisTransaksi = "UMUM" Then
                Dim Tuang As DataTable = GridControlPembayaran.DataSource
                Tuang.AcceptChanges()

                Dim Tno As Integer = 1
                Dim Turut As Boolean = False
                Dim NoPembayaran As String = ""

                Do
                    If CheckSQL("SELECT * FROM TransaksiPoliBayar WHERE TransPoliID = '" & _idTransaksi & "' AND GroupBayar='" & _nomorUrutTransaksi & "-" & Tno & "'") = True Then
                        Tno = Tno + 1
                    Else
                        Turut = True
                    End If
                Loop While Turut = False

                NoPembayaran = _nomorUrutTransaksi & "-" & Tno

                ' Insert ke tabel TransaksiPoliBayar
                For Each Trow As DataRow In Tuang.Rows
                    WriteSQL("INSERT INTO TransaksiPoliBayar (TransPoliID,JenisBayar,NoJenisBayar,JumlahBayar,admin,transaksitime,mesin,kartu,GroupBayar) " & _
                             "VALUES('" & _idTransaksi & "','" & Trow("Jenis") & "','" & Trow("KartuData") & "','" & CDbl(Trow("Jumlah")) & "','" & userInput & "',GETDATE(),'" & Trow("MesinData") & "','" & Trow("JenisKartu") & "','" & NoPembayaran & "')", 4)
                Next

                For Each Trow As DataRow In tblTindakan.Rows
                    If Trow("TransPoliIDDetail") = "0" Then
                        WriteSQL("INSERT INTO TransaksiPoliDetail(TransPoliID,TindakanID,NamaTindakan,JenisTindakan,BiayaTindakan,DiscTindakan,NettBayar,admin,transaksitime,DiscPersenTindakan,GroupBayar,StatusPembayaran,CreatedBy, CreatedDate) " & _
                                 "VALUES('" & _idTransaksi & "','" & Trow("TindakanID") & "','" & Trow("Tindakan") & "','" & Trow("Jenis") & "'," & CDbl(Trow("Biaya Tindakan")) & "," & CDbl(Trow("DiscNilai")) & "," & CDbl(Trow("NettBayar")) & ",'" & userInput & "',GETDATE()," & CDbl(Trow("DiscTindakan")) & ",'" & NoPembayaran & "', 'PAID', '" & userInput & "', GETDATE())", 4)
                    Else
                        WriteSQL("UPDATE TransaksiPoliDetail SET  BiayaTindakan = " & CDbl(Trow("Biaya Tindakan")) & ", DiscTindakan = " & CDbl(Trow("DiscNilai")) & ", NettBayar = " & CDbl(Trow("NettBayar")) & ", admin = '" & userInput & "', transaksitime = GETDATE(), DiscPersenTindakan = " & CDbl(Trow("DiscTindakan")) & ", GroupBayar = '" & NoPembayaran & "', StatusPembayaran = 'PAID' " & _
                                 "WHERE TransPoliIDDetail = '" & Trow("TransPoliIDDetail") & "' AND TransPoliID = '" & _idTransaksi & "' AND TindakanID = '" & Trow("TindakanID") & "' AND NamaTindakan = '" & Trow("Tindakan") & "' AND JenisTindakan = '" & Trow("Jenis") & "'", 4)
                    End If

                    'NewHeader.Rows.Clear()

                    'For Each TrowNewHeader As DataRow In tblTindakan.Rows
                    '    Dim Tnew As DataRow = NewHeader.NewRow
                    '    Tnew("TindakanID") = TrowNewHeader("TindakanID")
                    '    Tnew("Tindakan") = TrowNewHeader("Nama")
                    '    Tnew("Jenis") = TrowNewHeader("Jenis")
                    '    Tnew("Biaya Tindakan") = TrowNewHeader("Biaya Tindakan")
                    '    Tnew("DiscTindakan") = TrowNewHeader("DiscTindakan")
                    '    Tnew("DiscNilai") = TrowNewHeader("DiscNilai")
                    '    Tnew("NettBayar") = TrowNewHeader("NettBayar")
                    '    Tnew("Registrasi") = _noRekamMedis

                    '    Dim tblsPasien As DataTable = ReadSQL("SELECT Nama + ' / (' + JenisKelamin + ')' AS 'Nama', YEAR(TglLahir) AS 'TahunLahir', MONTH(TglLahir) AS 'BulanLahir', DAY(TglLahir) AS 'TanggalLahir', " & _
                    '                                      "CONVERT(VARCHAR(11),TglLahir,106) AS 'TanggalLengkap', DomisiliAlamat AS 'Alamat' " & _
                    '                                      "FROM MasterPasien WHERE NoRekamMedis = '" & _noRekamMedis & "'")
                    '    Dim TrowPasien As DataRow = tblsPasien.Rows(0)

                    '    Tnew("Nama") = TrowPasien("Nama")
                    '    Dim Tdate As Date = DateSerial(TrowPasien("TahunLahir"), TrowPasien("BulanLahir"), TrowPasien("TanggalLahir"))
                    '    Tnew("Umur") = TrowPasien("TanggalLengkap") & " / " & Umur(Tdate.Date)
                    '    Tnew("Alamat") = TrowPasien("Alamat")
                    '    Tnew("Tanggal") = Format(DateAndTime.Now, "dd-MMM-yyyy")
                    '    Tnew("NoTransaksi") = _nomorUrutTransaksi + " (" + _idTransaksi + ")"
                    '    Tnew("DrPengirim") = _namaDokter
                    '    Tnew("StatusAmbil") = ""
                    '    Tnew("lblDokter") = "Dr. Pelaksana"
                    '    Tnew("lblStatusAmbil") = ""
                    '    Tnew("lbltitikDokter") = ":"
                    '    Tnew("lbltitikStatusAmbil") = ""
                    '    NewHeader.Rows.Add(Tnew)
                    'Next
                Next

                WriteSQL("UPDATE TransaksiPoli SET TotalTagihan = TotalTagihan + " & CDbl(txtotalbruto) & ", TotalDisc = TotalDisc + " & CDbl(txtotaldisc) & ", Pembulatan = Pembulatan + " & CDbl(txtotalpembulatan) & ", NettBayar = NettBayar + " & CDbl(TextBoxTotalTagihan.Value) & ", TotalBayar = TotalBayar + " & CDbl(TextBoxTotalBayar.Value) & ", Pengembalian = Pengembalian + " & CDbl(TextBoxTotalKembali.Value) & ", ClosedBayar = '" & Format(DateAndTime.Now, "MM/dd/yyyy") & "', Status = 'CLOSED' WHERE TransPoliID = '" & _idTransaksi & "'", 4)

                If TextBoxTotalKembali.Value > 0 Then
                    WriteSQL("UPDATE TransaksiPoliBayar SET Kembali = '" & CDbl(TextBoxTotalKembali.Value) & "' WHERE TransPoliID = '" & _idTransaksi & "' AND JenisBayar = 'TUNAI' ", 4)
                End If

                'Report = New XtraReport

                'If Jeniscetak = "Struk" Then
                '    Report = XtraReport.FromFile(Application.StartupPath + "\reports\PrintTindakanStruk.repx", True)
                'Else
                '    Report = XtraReport.FromFile(Application.StartupPath + "\reports\Resource\PrintInvoiceTransaksi.repx", True)
                'End If

                'Report.DataSource = NewHeader
                'If Jeniscetak = "Struk" Then
                '    Report.Bands.Item(BandKind.TopMargin).Controls("txalamat").Text = Utility.GetConfig("CompanyAddr")
                '    Report.Bands.Item(BandKind.TopMargin).Controls("txtelfon").Text = Utility.GetConfig("CompanyContact")
                '    Report.Bands.Item(BandKind.TopMargin).Controls("txfaskes").Text = Utility.GetConfig("CompanyFaskes")
                'End If

                'Report.Bands.Item(BandKind.ReportFooter).Controls("lblBayar").Text = Splitmoney(TextBoxTotalBayar.Value)
                'Report.Bands.Item(BandKind.ReportFooter).Controls("lblKembalian").Text = Splitmoney(TextBoxTotalKembali.Value)
                'Report.Bands.Item(BandKind.BottomMargin).Controls("lbladmin").Text = userInput
                'Report.Bands.Item(BandKind.BottomMargin).Controls("lbltanggalcetak").Text = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mmm:ss")

                'Dim Ttemp As DataTable = ReadSQL("SELECT * FROM TransaksiPoliBayar WHERE TransPoliID = '" & _idTransaksi & "'")
                'If Ttemp.Rows.Count > 0 Then
                '    For i As Integer = 1 To Ttemp.Rows.Count
                '        Dim Trow As DataRow = Ttemp.Rows(i - 1)
                '        Dim Tket As String = "bayar" & i
                '        Report.Bands.Item(BandKind.ReportFooter).Controls(Tket).Visible = True
                '        If Trow("JenisBayar") = "TAGIHAN" Or Trow("JenisBayar") = "TUNAI" Then
                '            Report.Bands.Item(BandKind.ReportFooter).Controls(Tket).Text = Trow("JenisBayar") & " - Jumlah : " & Splitmoney(Trow("JumlahBayar"))
                '        Else
                '            Report.Bands.Item(BandKind.ReportFooter).Controls(Tket).Text = Trow("JenisBayar") & " - No Kartu : " & "*".PadRight(Len(Trow("NoJenisBayar")) - 3) & Strings.Right(Trow("NoJenisBayar"), 3) & Trow("kartu") & " - Jumlah : " & Splitmoney(Trow("JumlahBayar"))
                '        End If
                '    Next
                'Else
                '    Report.Bands.Item(BandKind.ReportFooter).Controls("bayar1").Text = "-"
                'End If

                'If Jeniscetak = "Struk" Then
                '    Report.PageHeight = txtotalrow
                'End If

                ' Pesan Success
                MsgBox("Berhasil Menyimpan Data Transaksi." & vbCrLf & "No Transaksi : " & _nomorUrutTransaksi, MsgBoxStyle.Information, "Success!")

                ' Cetak Barcode
                If MsgBox("Apakah anda ingin mencetak barcode pasien atas nama " & _namaPasien & "?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    CetakBarcodeKlinik(_idTransaksi)
                End If

                FormTransaksiPoli.NewToolStripMenuItem.PerformClick()

                'Report.RunDesigner()
                'Report.ShowPreview()
                'Report.PrintDialog()

                ' Checklist Lunas
                CheckBoxLunasBayar.Checked = True

                '# Close Form
                'Me.Close()
            ElseIf _jenisTransaksi = "AWALGIGI" Then
                ' Insert TransaksiGigi
                WriteSQL("INSERT INTO TransaksiGigi (IDInternet, DokterGigi, PerawatGigi, TglGigi, CreateDate, CreateBy, KodeDokter, NoUrut, StatusKeterangan, StatusTransaksi, ArrivedDate) " & _
                         "VALUES('" & _noRekamMedis & "','" & _namaDokter & "','" & _namaPerawat & "', GETDATE(), GETDATE(),'" & userInput & "', '" & kodeDokter & "', '" & _nomorUrutTransaksi & "', 'Belum Diperiksa', 'arrived', GETDATE())", 4)

                ' Set ID Poli
                _idTransaksi = ReadSQLNIK("SELECT TransGigiID FROM TransaksiGigi WHERE NoUrut = '" & _nomorUrutTransaksi & "'")

                Dim Tuang As DataTable = GridControlPembayaran.DataSource
                Tuang.AcceptChanges()

                ' Insert ke tabel TransaksiGigiBayarAwal
                For Each Trow As DataRow In Tuang.Rows
                    WriteSQL("INSERT INTO TransaksiGigiBayarAwal (TransJenis, TransGigiID, JenisBayar, NoJenisBayar, JumlahBayar, admin, transaksitime, mesin, kartu) " & _
                             "VALUES('GIGI','" & _idTransaksi & "','" & Trow("Jenis") & "','" & Trow("KartuData") & "','" & CDbl(Trow("Jumlah")) & "','" & userInput & "',GETDATE(),'" & Trow("MesinData") & "','" & Trow("JenisKartu") & "')", 4)
                Next

                ' Insert ke tabel TransaksiGigiDetail
                For Each Trow As DataRow In tblTindakan.Rows
                    WriteSQL("INSERT INTO TransaksiGigiDetail(Awal, TransGigiID, TindakanID, NamaTindakan, JenisTindakan, BiayaTindakan, DiscTindakan, NettBayar, admin, transaksitime, DiscPersenTindakan, StatusPembayaran) " & _
                             "VALUES('1', '" & _idTransaksi & "', '" & Trow("TindakanID") & "', '" & Trow("Tindakan") & "', '" & Trow("Jenis") & "', " & CDbl(Trow("Biaya Tindakan")) & ", " & CDbl(Trow("DiscNilai")) & ", " & CDbl(Trow("NettBayar")) & ", '" & userInput & "', GETDATE(), 0, 'PAID')", 4)
                Next

                ' Set Jenis Bayar
                Dim jenisBayar As String = GetJenisPembayaran("GIGI", _nomorUrutTransaksi)

                ' Insert TransaksiDetail
                WriteSQL("INSERT INTO TransaksiDetail(NoUrutBPJS, NoTransaksi, JenisKunjungan, JenisRawat, JenisTransaksi, JenisPoli, JenisPenagihan, TanggalTransaksi, KeluhanUtama, KeluhanTambahan, IDInternet, StatusBPJS, NoUrut, StatusHandaya, StatusLansia, StatusDifabel, StatusGawatDarurat, CreatedBy, CreatedDate) " & _
                         "VALUES('" & NoUrutBPJS & "', '" & _idTransaksi & "', '" & _jenisKunjungan & "', '" & _jenisRawat & "', 'GIGI', '" & _namaPoli & "', '" & jenisBayar & "', GETDATE(), '" & _keluhanUtama & "', '" & _keluhanTambahan & "', " & _
                         "'" & _noRekamMedis & "'," & Convert.ToInt32(statusBPJS) & ", '" & _nomorUrutTransaksi & "', '" & _statusHandaya & "', '" & _statusLansia & "', '" & _statusDifabel & "', '" & _statusGawatDarurat & "', '" & userInput & "', GETDATE())", 4)

                'NewHeader.Rows.Clear()

                'For Each TrowNewHeader As DataRow In tblTindakan.Rows
                '    Dim Tnew As DataRow = NewHeader.NewRow
                '    Tnew("TindakanID") = TrowNewHeader("TindakanID")
                '    Tnew("Tindakan") = TrowNewHeader("Tindakan")
                '    Tnew("Jenis") = TrowNewHeader("Jenis")
                '    Tnew("Biaya Tindakan") = TrowNewHeader("Biaya Tindakan")
                '    Tnew("DiscTindakan") = TrowNewHeader("DiscTindakan")
                '    Tnew("DiscNilai") = TrowNewHeader("DiscNilai")
                '    Tnew("NettBayar") = TrowNewHeader("NettBayar")
                '    Tnew("Registrasi") = _noRekamMedis

                '    Dim tblsPasien As DataTable = ReadSQL("SELECT Nama + ' / (' + JenisKelamin + ')' AS 'Nama', YEAR(TglLahir) AS 'TahunLahir', MONTH(TglLahir) AS 'BulanLahir', DAY(TglLahir) AS 'TanggalLahir', " & _
                '                                          "CONVERT(VARCHAR(11),TglLahir,106) AS 'TanggalLengkap', DomisiliAlamat AS 'Alamat' " & _
                '                                          "FROM MasterPasien WHERE NoRekamMedis = '" & _noRekamMedis & "'")
                '    Dim TrowPasien As DataRow = tblsPasien.Rows(0)

                '    Tnew("Nama") = TrowPasien("Nama")
                '    Dim Tdate As Date = DateSerial(TrowPasien("TahunLahir"), TrowPasien("BulanLahir"), TrowPasien("TanggalLahir"))
                '    Tnew("Umur") = TrowPasien("TanggalLengkap") & " / " & Umur(Tdate.Date)
                '    Tnew("Alamat") = TrowPasien("Alamat")
                '    Tnew("Tanggal") = Format(DateAndTime.Now, "dd-MMM-yyyy")
                '    Tnew("NoTransaksi") = _nomorUrutTransaksi + " (" + _idTransaksi + ")"
                '    Tnew("DrPengirim") = _namaDokter
                '    Tnew("StatusAmbil") = ""
                '    Tnew("lblDokter") = "Dr. Pelaksana"
                '    Tnew("lblStatusAmbil") = ""
                '    Tnew("lbltitikDokter") = ":"
                '    Tnew("lbltitikStatusAmbil") = ""
                '    NewHeader.Rows.Add(Tnew)
                'Next

                ' DELETE
                WriteSQL("UPDATE TransaksiGigi SET TotalTagihan = " & CDbl(txtotalbruto) & ", TotalDisc = " & CDbl(txtotaldisc) & ", Pembulatan = " & CDbl(txtotalpembulatan) & ", NettBayar = " & CDbl(TextBoxTotalTagihan.Value) & ", TotalBayar = " & CDbl(TextBoxTotalBayar.Value) & ", Pengembalian = " & CDbl(TextBoxTotalKembali.Value) & " WHERE TransGigiID='" & _idTransaksi & "'", 4)

                If TextBoxTotalKembali.Value > 0 Then
                    WriteSQL("UPDATE TransaksiGigiBayarAwal SET Kembali='" & CDbl(TextBoxTotalKembali.Value) & "' WHERE TransGigiID='" & _idTransaksi & "' AND JenisBayar='TUNAI' AND TransJenis='GIGI'", 4)
                End If

                'Report = New XtraReport

                'If Jeniscetak = "Struk" Then
                '    Report = XtraReport.FromFile(Application.StartupPath + "\reports\PrintTindakanStruk.repx", True)
                'Else
                '    Report = XtraReport.FromFile(Application.StartupPath + "\reports\Resource\PrintInvoiceTransaksi.repx", True)
                'End If

                'Report.DataSource = NewHeader

                'If Jeniscetak = "Struk" Then
                '    Report.Bands.Item(BandKind.TopMargin).Controls("txalamat").Text = Utility.GetConfig("CompanyAddr")
                '    Report.Bands.Item(BandKind.TopMargin).Controls("txtelfon").Text = Utility.GetConfig("CompanyContact")
                '    Report.Bands.Item(BandKind.TopMargin).Controls("txfaskes").Text = Utility.GetConfig("CompanyFaskes")
                'End If

                'Report.Bands.Item(BandKind.ReportFooter).Controls("lblBayar").Text = Splitmoney(TextBoxTotalBayar.Value)
                'Report.Bands.Item(BandKind.ReportFooter).Controls("lblKembalian").Text = Splitmoney(TextBoxTotalKembali.Value)
                'Report.Bands.Item(BandKind.BottomMargin).Controls("lbladmin").Text = userInput
                'Report.Bands.Item(BandKind.BottomMargin).Controls("lbltanggalcetak").Text = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mmm:ss")

                'Dim Ttemp As DataTable = ReadSQL("SELECT * FROM TransaksiGigiBayarAwal WHERE TransGigiID = '" & _idTransaksi & "' AND TransJenis='GIGI'")
                'If Ttemp.Rows.Count > 1 Then
                '    For i As Integer = 1 To Ttemp.Rows.Count
                '        Dim Trow As DataRow = Ttemp.Rows(i - 1)
                '        Dim Tket As String = "bayar" & i
                '        Report.Bands.Item(BandKind.ReportFooter).Controls(Tket).Visible = True
                '        If Trow("JenisBayar") = "TAGIHAN" Or Trow("JenisBayar") = "TUNAI" Then
                '            Report.Bands.Item(BandKind.ReportFooter).Controls(Tket).Text = Trow("JenisBayar") & " - Jumlah : " & Splitmoney(Trow("JumlahBayar"))
                '        Else
                '            Report.Bands.Item(BandKind.ReportFooter).Controls(Tket).Text = Trow("JenisBayar") & " - No Kartu : " & "*".PadRight(Len(Trow("NoJenisBayar")) - 3) & Strings.Right(Trow("NoJenisBayar"), 3) & Trow("kartu") & " - Jumlah : " & Splitmoney(Trow("JumlahBayar"))
                '        End If
                '    Next
                'Else
                '    Report.Bands.Item(BandKind.ReportFooter).Controls("bayar1").Text = "-"
                'End If

                'If Jeniscetak = "Struk" Then
                '    Report.PageHeight = txtotalrow
                'End If

                ' Insert / Update Detail Waktu Transaksi (WaktuSelesaiPendaftaran)
                SetDetailWaktuTransaksi(_nomorUrutTransaksi, "WaktuSelesaiPendaftaran", userInput)

                ' Pesan Success
                If NoUrutBPJS = "" Then
                    ' Non BPJS
                    MsgBox("Berhasil Menyimpan Data Pendaftaran Pasien." & vbCrLf & "No Transaksi : " & _nomorUrutTransaksi, MsgBoxStyle.Information, "Success!")
                Else
                    ' BPJS
                    MsgBox("Berhasil Menyimpan Data Pendaftaran Pasien." & vbCrLf & "No Transaksi : " & _nomorUrutTransaksi & vbCrLf & "No Urut BPJS : " & NoUrutBPJS, MsgBoxStyle.Information, "Success!")
                End If

                FormPendaftaranAwal.ClearDataPendaftaranAwal()

                ' Checklist Lunas
                CheckBoxLunasBayar.Checked = True

                'Report.RunDesigner()
                'Report.ShowPreview()
                'Report.Print()

                '# Close Form
                'Me.Close()
            ElseIf _jenisTransaksi = "GIGI" Then
                Dim Tuang As DataTable = GridControlPembayaran.DataSource
                Tuang.AcceptChanges()

                Dim Tno As Integer = 1
                Dim Turut As Boolean = False
                Dim NoPembayaran As String = ""

                Do
                    If CheckSQL("SELECT * FROM TransaksiGigiBayar WHERE TransGigiID = '" & _idTransaksi & "' AND GroupBayar='" & _nomorUrutTransaksi & "-" & Tno & "'") = True Then
                        Tno = Tno + 1
                    Else
                        Turut = True
                    End If
                Loop While Turut = False

                NoPembayaran = _nomorUrutTransaksi & "-" & Tno

                ' Insert ke tabel TransaksiGigiBayar
                For Each Trow As DataRow In Tuang.Rows
                    WriteSQL("INSERT INTO TransaksiGigiBayar (TransGigiID,JenisBayar,NoJenisBayar,JumlahBayar,admin,transaksitime,mesin,kartu,GroupBayar) " & _
                             "VALUES('" & _idTransaksi & "','" & Trow("Jenis") & "','" & Trow("KartuData") & "','" & CDbl(Trow("Jumlah")) & "','" & userInput & "',GETDATE(),'" & Trow("MesinData") & "','" & Trow("JenisKartu") & "','" & NoPembayaran & "')", 4)
                Next

                For Each Trow As DataRow In tblTindakan.Rows
                    If Trow("TransPoliIDDetail") = "0" Then
                        WriteSQL("INSERT INTO TransaksiGigiDetail(TransGigiID,TindakanID,NamaTindakan,JenisTindakan,BiayaTindakan,DiscTindakan,NettBayar,admin,transaksitime,DiscPersenTindakan,GroupBayar,StatusPembayaran,CreatedBy, CreatedDate) " & _
                                 "VALUES('" & _idTransaksi & "','" & Trow("TindakanID") & "','" & Trow("Tindakan") & "','" & Trow("Jenis") & "'," & CDbl(Trow("Biaya Tindakan")) & "," & CDbl(Trow("DiscNilai")) & "," & CDbl(Trow("NettBayar")) & ",'" & userInput & "',GETDATE()," & CDbl(Trow("DiscTindakan")) & ",'" & NoPembayaran & "', 'PAID', '" & userInput & "', GETDATE())", 4)
                    Else
                        WriteSQL("UPDATE TransaksiGigiDetail SET  BiayaTindakan = " & CDbl(Trow("Biaya Tindakan")) & ", DiscTindakan = " & CDbl(Trow("DiscNilai")) & ", NettBayar = " & CDbl(Trow("NettBayar")) & ", admin = '" & userInput & "', transaksitime = GETDATE(), DiscPersenTindakan = " & CDbl(Trow("DiscTindakan")) & ", GroupBayar = '" & NoPembayaran & "', StatusPembayaran = 'PAID' " & _
                                 "WHERE TransGigiIDDetail = '" & Trow("TransPoliIDDetail") & "' AND TransGigiID = '" & _idTransaksi & "' AND TindakanID = '" & Trow("TindakanID") & "' AND NamaTindakan = '" & Trow("Tindakan") & "' AND JenisTindakan = '" & Trow("Jenis") & "'", 4)
                    End If

                    'NewHeader.Rows.Clear()

                    'For Each TrowNewHeader As DataRow In tblTindakan.Rows
                    '    Dim Tnew As DataRow = NewHeader.NewRow
                    '    Tnew("TindakanID") = TrowNewHeader("TindakanID")
                    '    Tnew("Tindakan") = TrowNewHeader("Nama")
                    '    Tnew("Jenis") = TrowNewHeader("Jenis")
                    '    Tnew("Biaya Tindakan") = TrowNewHeader("Biaya Tindakan")
                    '    Tnew("DiscTindakan") = TrowNewHeader("DiscTindakan")
                    '    Tnew("DiscNilai") = TrowNewHeader("DiscNilai")
                    '    Tnew("NettBayar") = TrowNewHeader("NettBayar")
                    '    Tnew("Registrasi") = _noRekamMedis

                    '    Dim tblsPasien As DataTable = ReadSQL("SELECT Nama + ' / (' + JenisKelamin + ')' AS 'Nama', YEAR(TglLahir) AS 'TahunLahir', MONTH(TglLahir) AS 'BulanLahir', DAY(TglLahir) AS 'TanggalLahir', " & _
                    '                                      "CONVERT(VARCHAR(11),TglLahir,106) AS 'TanggalLengkap', DomisiliAlamat AS 'Alamat' " & _
                    '                                      "FROM MasterPasien WHERE NoRekamMedis = '" & _noRekamMedis & "'")
                    '    Dim TrowPasien As DataRow = tblsPasien.Rows(0)

                    '    Tnew("Nama") = TrowPasien("Nama")
                    '    Dim Tdate As Date = DateSerial(TrowPasien("TahunLahir"), TrowPasien("BulanLahir"), TrowPasien("TanggalLahir"))
                    '    Tnew("Umur") = TrowPasien("TanggalLengkap") & " / " & Umur(Tdate.Date)
                    '    Tnew("Alamat") = TrowPasien("Alamat")
                    '    Tnew("Tanggal") = Format(DateAndTime.Now, "dd-MMM-yyyy")
                    '    Tnew("NoTransaksi") = _nomorUrutTransaksi + " (" + _idTransaksi + ")"
                    '    Tnew("DrPengirim") = _namaDokter
                    '    Tnew("StatusAmbil") = ""
                    '    Tnew("lblDokter") = "Dr. Pelaksana"
                    '    Tnew("lblStatusAmbil") = ""
                    '    Tnew("lbltitikDokter") = ":"
                    '    Tnew("lbltitikStatusAmbil") = ""
                    '    NewHeader.Rows.Add(Tnew)
                    'Next
                Next

                WriteSQL("UPDATE TransaksiGigi SET TotalTagihan = TotalTagihan + " & CDbl(txtotalbruto) & ", TotalDisc = TotalDisc + " & CDbl(txtotaldisc) & ", Pembulatan = Pembulatan + " & CDbl(txtotalpembulatan) & ", NettBayar = NettBayar + " & CDbl(TextBoxTotalTagihan.Value) & ", TotalBayar = TotalBayar + " & CDbl(TextBoxTotalBayar.Value) & ", Pengembalian = Pengembalian + " & CDbl(TextBoxTotalKembali.Value) & ", ClosedBayar = '" & Format(DateAndTime.Now, "MM/dd/yyyy") & "', Status = 'CLOSED', ChangeDate = GETDATE(), ChangeBy = '" & userInput & "' WHERE TransGigiID = '" & _idTransaksi & "'", 4)

                If TextBoxTotalKembali.Value > 0 Then
                    WriteSQL("UPDATE TransaksiGigiBayar SET Kembali = '" & CDbl(TextBoxTotalKembali.Value) & "' WHERE TransGigiID = '" & _idTransaksi & "' AND JenisBayar = 'TUNAI' ", 4)
                End If

                'Report = New XtraReport

                'If Jeniscetak = "Struk" Then
                '    Report = XtraReport.FromFile(Application.StartupPath + "\reports\PrintTindakanStruk.repx", True)
                'Else
                '    Report = XtraReport.FromFile(Application.StartupPath + "\reports\Resource\PrintInvoiceTransaksi.repx", True)
                'End If

                'Report.DataSource = NewHeader
                'If Jeniscetak = "Struk" Then
                '    Report.Bands.Item(BandKind.TopMargin).Controls("txalamat").Text = Utility.GetConfig("CompanyAddr")
                '    Report.Bands.Item(BandKind.TopMargin).Controls("txtelfon").Text = Utility.GetConfig("CompanyContact")
                '    Report.Bands.Item(BandKind.TopMargin).Controls("txfaskes").Text = Utility.GetConfig("CompanyFaskes")
                'End If

                'Report.Bands.Item(BandKind.ReportFooter).Controls("lblBayar").Text = Splitmoney(TextBoxTotalBayar.Value)
                'Report.Bands.Item(BandKind.ReportFooter).Controls("lblKembalian").Text = Splitmoney(TextBoxTotalKembali.Value)
                'Report.Bands.Item(BandKind.BottomMargin).Controls("lbladmin").Text = userInput
                'Report.Bands.Item(BandKind.BottomMargin).Controls("lbltanggalcetak").Text = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mmm:ss")

                'Dim Ttemp As DataTable = ReadSQL("SELECT * FROM TransaksiGigiBayar WHERE TransGigiID = '" & _idTransaksi & "'")
                'If Ttemp.Rows.Count > 0 Then
                '    For i As Integer = 1 To Ttemp.Rows.Count
                '        Dim Trow As DataRow = Ttemp.Rows(i - 1)
                '        Dim Tket As String = "bayar" & i
                '        Report.Bands.Item(BandKind.ReportFooter).Controls(Tket).Visible = True
                '        If Trow("JenisBayar") = "TAGIHAN" Or Trow("JenisBayar") = "TUNAI" Then
                '            Report.Bands.Item(BandKind.ReportFooter).Controls(Tket).Text = Trow("JenisBayar") & " - Jumlah : " & Splitmoney(Trow("JumlahBayar"))
                '        Else
                '            Report.Bands.Item(BandKind.ReportFooter).Controls(Tket).Text = Trow("JenisBayar") & " - No Kartu : " & "*".PadRight(Len(Trow("NoJenisBayar")) - 3) & Strings.Right(Trow("NoJenisBayar"), 3) & Trow("kartu") & " - Jumlah : " & Splitmoney(Trow("JumlahBayar"))
                '        End If
                '    Next
                'Else
                '    Report.Bands.Item(BandKind.ReportFooter).Controls("bayar1").Text = "-"
                'End If

                'If Jeniscetak = "Struk" Then
                '    Report.PageHeight = txtotalrow
                'End If

                ' Pesan Success
                MsgBox("Berhasil Menyimpan Data Transaksi." & vbCrLf & "No Transaksi : " & _nomorUrutTransaksi, MsgBoxStyle.Information, "Success!")

                FormTransaksiPoli.NewToolStripMenuItem.PerformClick()

                ' Checklist Lunas
                CheckBoxLunasBayar.Checked = True

                'Report.RunDesigner()
                'Report.ShowPreview()
                'Report.PrintDialog()

                '# Close Form
                'Me.Close()
            ElseIf _jenisTransaksi = "LAB" Then
                Dim KodeBarcode As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'KodeBarcode'")

                Dim DetailPemeriksaan As String = ""
                Dim TtempDetailPemeriksaan As String = ""

                For Each Trow As DataRow In tblTindakan.Rows
                    TtempDetailPemeriksaan = TtempDetailPemeriksaan & "" & Trow("Tindakan").ToString.Trim & ", "

                    If CheckSQL("SELECT * FROM TransaksiLabDetail WHERE TransLabID = '" & _idTransaksi & "' AND TindakanID = '" & Trow("TindakanID") & "'") = False Then
                        ' Insert TransaksiLabDetail
                        WriteSQL("INSERT INTO TransaksiLabDetail(TransLabID,TindakanID,NamaTindakan,JenisTindakan,BiayaTindakan,DiscTindakan,NettBayar,admin,transaksitime,DiscPersenTindakan,Mesin,Urutan) " & _
                             "VALUES('" & _idTransaksi & "','" & Trow("TindakanID") & "','" & Trow("Tindakan") & "','" & Trow("Jenis") & "'," & CDbl(Trow("Biaya Tindakan")) & "," & CDbl(Trow("DiscNilai")) & "," & CDbl(Trow("NettBayar")) & ",'" & userInput & "',GETDATE()," & CDbl(Trow("DiscTindakan")) & ",'" & Trow("Mesin") & "','" & Trow("Urutan") & "')", 4)
                    Else
                        ' Update TransaksiLabDetail
                        WriteSQL("UPDATE TransaksiLabDetail SET  BiayaTindakan = " & CDbl(Trow("Biaya Tindakan")) & ", DiscTindakan = " & CDbl(Trow("DiscNilai")) & ", NettBayar = " & CDbl(Trow("NettBayar")) & ", admin = '" & userInput & "', transaksitime = GETDATE(), DiscPersenTindakan = " & CDbl(Trow("DiscTindakan")) & ", StatusPembayaran = 'PAID' " & _
                                 "WHERE TransLabID = '" & _idTransaksi & "' AND TindakanID = '" & Trow("TindakanID") & "' AND NamaTindakan = '" & Trow("Tindakan") & "' AND JenisTindakan = '" & Trow("Jenis") & "'", 4)
                    End If

                    Dim TransLabIDDetail As String = ReadSQLNIK("SELECT TransLabIDDetail FROM TransaksiLabDetail WHERE TransLabID='" & _idTransaksi & "' AND TindakanID='" & Trow("TindakanID") & "' AND NamaTindakan='" & Trow("Tindakan") & "' AND JenisTindakan='" & Trow("Jenis") & "'")
                    Dim Tbls2 As DataTable = ReadSQL("SELECT * FROM MasterLabDetail WHERE TindakanID = '" & Trow("TindakanID") & "' AND deleted = 0 ORDER BY groupid, nourut")
                    For Each Trow2 As DataRow In Tbls2.Rows
                        WriteSQL("INSERT INTO TransaksiLabResult(TransLabIDDetail,TindakanID,GroupID,NoUrut,DetailKet,Pria,Wanita,Result,Keterangan,Satuan) " & _
                                 "VALUES('" & TransLabIDDetail & "','" & Trow("TindakanID") & "','" & Trow2("GroupID") & "','" & Trow2("NoUrut") & "','" & Trow2("DetailKet") & "','" & Trow2("Pria") & "','" & Trow2("Wanita") & "','','" & Trow2("KeteranganHasil") & "','" & Trow2("DisplayHasil") & "') ", 4)
                    Next

                    Dim TblsCopy As DataTable = tblTindakan
                    NewHeader.Rows.Clear()

                    For Each TrowNewHeader As DataRow In tblTindakan.Rows
                        Dim Tnew As DataRow = NewHeader.NewRow
                        Tnew("TindakanID") = TrowNewHeader("TindakanID")
                        Tnew("Tindakan") = TrowNewHeader("Tindakan")
                        Tnew("Jenis") = TrowNewHeader("Jenis")
                        Tnew("Biaya Tindakan") = TrowNewHeader("Biaya Tindakan")
                        Tnew("DiscTindakan") = TrowNewHeader("DiscTindakan")
                        Tnew("DiscNilai") = TrowNewHeader("DiscNilai")
                        Tnew("NettBayar") = TrowNewHeader("NettBayar")
                        Tnew("Registrasi") = _noRekamMedis

                        Dim tblsPasien As DataTable = ReadSQL("SELECT Nama + ' / (' + JenisKelamin + ')' AS 'Nama', YEAR(TglLahir) AS 'TahunLahir', MONTH(TglLahir) AS 'BulanLahir', DAY(TglLahir) AS 'TanggalLahir', " & _
                                                          "CONVERT(VARCHAR(11),TglLahir,106) AS 'TanggalLengkap', DomisiliAlamat AS 'Alamat' " & _
                                                          "FROM MasterPasien WHERE NoRekamMedis = '" & _noRekamMedis & "'")

                        Dim TblsTrans As DataTable = ReadSQL("SELECT NoUrut, CaraAmbil FROM TransaksiLab WHERE TransLabID = '" & _idTransaksi & "'")
                        If tblsPasien.Rows.Count > 0 And TblsTrans.Rows.Count > 0 Then
                            Dim TrowPasien As DataRow = tblsPasien.Rows(0)
                            Dim TTrans As DataRow = TblsTrans.Rows(0)
                            Tnew("Nama") = TrowPasien("nama")
                            Dim Tdate As Date = DateSerial(TrowPasien("TahunLahir"), TrowPasien("BulanLahir"), TrowPasien("TanggalLahir"))
                            Tnew("Umur") = TrowPasien("TanggalLengkap") & " / " & Umur(Tdate.Date)
                            Tnew("Alamat") = TrowPasien("Alamat")
                            Tnew("Tanggal") = Format(DateAndTime.Now, "dd-MMM-yyyy")
                            Tnew("NoTransaksi") = TTrans("NoUrut") + " (" + _idTransaksi + ")"
                            Tnew("StatusAmbil") = TTrans("CaraAmbil")
                        End If

                        Tnew("Tanggal") = Format(DateAndTime.Now, "dd-MMM-yyyy")
                        Tnew("DrPengirim") = ReadSQLNIK("select a.DrNama  from MasterDokterKirim a left join  MasterDokterTempatPraktek b on a.IdKirim=b.IdKirim WHERE b.IdPraktek in ( select DokterRequest from transaksilab WHERE TransLabID='" & _idTransaksi & "')")
                        Tnew("lblDokter") = "Dr. Pengirim"
                        Tnew("lblStatusAmbil") = "Status Ambil"
                        Tnew("lbltitikDokter") = ":"
                        Tnew("lbltitikStatusAmbil") = ":"
                        NewHeader.Rows.Add(Tnew)
                    Next
                Next

                DetailPemeriksaan = Strings.Left(TtempDetailPemeriksaan, TtempDetailPemeriksaan.Length - 2)
                Dim Tuang As DataTable = GridControlPembayaran.DataSource
                Tuang.AcceptChanges()
                WriteSQL("DELETE FROM TransaksiLabBayar WHERE TransLabID='" & _idTransaksi & "'", 4)
                For Each Trow As DataRow In Tuang.Rows
                    If CheckSQL("select * from TransaksiLabBayar WHERE TransLabID = '" & _idTransaksi & "' AND JenisBayar = '" & Trow("Jenis") & "'") = False Then
                        WriteSQL("insert into TransaksiLabBayar (TransLabID,JenisBayar,NoJenisBayar,JumlahBayar,admin,transaksitime,mesin,kartu) values('" & _idTransaksi & "','" & Trow("Jenis") & "','" & Trow("KartuData") & "','" & CDbl(Trow("Jumlah")) & "','" & userInput & "',GETDATE(),'" & Trow("MesinData") & "','" & Trow("JenisKartu") & "')", 4)
                        JenisBayarSaved = Trow("Jenis").ToString.Trim
                        JenisBayarSavedKet = Trow("KartuData").ToString.Trim
                    End If

                    'set pemakaian discount
                    If Trow("Jenis").ToString = "DISC" Then
                        WriteSQL("update DiscountNumber set Used=1, UsedDate=GETDATE(), TransJenis='" & _jenisTransaksi & "', TransID='" & _idTransaksi & "'  WHERE DiscNo='" & Trow("KartuData") & "'", 4)
                    End If
                Next

                WriteSQL("update TransaksiLab set DetailPemeriksaan='" & DetailPemeriksaan & "', LabDaftar=GETDATE(), TotalTagihan=TotalTagihan+" & CDbl(txtotalbruto) & ",TotalDisc=TotalDisc+" & CDbl(txtotaldisc) & ",Pembulatan=Pembulatan+" & CDbl(txtotalpembulatan) & ",NettBayar=NettBayar+" & CDbl(TextBoxTotalTagihan.Value) & ",TotalBayar=TotalBayar+" & CDbl(TextBoxTotalBayar.Value) & ",Pengembalian=Pengembalian+" & CDbl(TextBoxTotalKembali.Value) & ",ClosedBayar='" & Format(DateAndTime.Now, "MM/dd/yyyy") & "',LabJenisPembayaran='" & ComboBoxJenisBayar.Text & "', Status='SAMPLE' ,ClosedTransaksi='1',ChangeDate=GETDATE(),ChangeBy='" & userInput & "'  WHERE TransLabID='" & _idTransaksi & "'", 4)

                If TextBoxTotalKembali.Value > 0 Then
                    WriteSQL("update TransaksiLabBayar set Kembali='" & CDbl(TextBoxTotalKembali.Value) & "' WHERE TransLabID='" & _idTransaksi & "' AND JenisBayar='TUNAI' ", 4)
                End If

                Report = New XtraReport
                If Jeniscetak = "Struk" Then
                    Report = XtraReport.FromFile(Application.StartupPath + "\reports\PrintTindakanStruk.repx", True)
                Else
                    Report = XtraReport.FromFile(Application.StartupPath + "\reports\Resource\PrintInvoiceTransaksi.repx", True)
                End If

                Report.DataSource = NewHeader
                If Jeniscetak = "Struk" Then
                    Report.Bands.Item(BandKind.TopMargin).Controls("txalamat").Text = Utility.GetConfig("CompanyAddr")
                    Report.Bands.Item(BandKind.TopMargin).Controls("txtelfon").Text = Utility.GetConfig("CompanyContact")
                    Report.Bands.Item(BandKind.TopMargin).Controls("txfaskes").Text = Utility.GetConfig("CompanyFaskes")
                End If

                Report.Bands.Item(BandKind.ReportFooter).Controls("lblBayar").Text = Splitmoney(TextBoxTotalBayar.Value)
                Report.Bands.Item(BandKind.ReportFooter).Controls("lblKembalian").Text = Splitmoney(TextBoxTotalKembali.Value)
                Report.Bands.Item(BandKind.BottomMargin).Controls("lbladmin").Text = userInput
                Report.Bands.Item(BandKind.BottomMargin).Controls("lbltanggalcetak").Text = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mmm:ss")

                Dim Ttemp As DataTable = ReadSQL("select * from TransaksiLabBayar WHERE  TransLabID='" & _idTransaksi & "'")
                If Ttemp.Rows.Count > 0 Then
                    For i As Integer = 1 To Ttemp.Rows.Count
                        Dim Trow As DataRow = Ttemp.Rows(i - 1)
                        Dim Tket As String = "bayar" & i
                        Report.Bands.Item(BandKind.ReportFooter).Controls(Tket).Visible = True
                        If Trow("JenisBayar") = "TAGIHAN" Or Trow("JenisBayar") = "TUNAI" Then
                            Report.Bands.Item(BandKind.ReportFooter).Controls(Tket).Text = Trow("JenisBayar") & " - Jumlah : " & Splitmoney(Trow("JumlahBayar"))
                        Else
                            Report.Bands.Item(BandKind.ReportFooter).Controls(Tket).Text = Trow("JenisBayar") & " - No Kartu : " & "*".PadRight(Len(Trow("NoJenisBayar")) - 3) & Strings.Right(Trow("NoJenisBayar"), 3) & Trow("kartu") & " - Jumlah : " & Splitmoney(Trow("JumlahBayar"))
                        End If
                    Next
                Else
                    Report.Bands.Item(BandKind.ReportFooter).Controls("bayar1").Text = "-"
                End If

                'If Jeniscetak = "Struk" Then
                '    Report.PageHeight = txtotalrow
                'End If

                'Report.RunDesigner()
                'Report.ShowPreview()
                'Report.Print()

                ' Save Report
                Dim PathFolder As String = ReadSQLNIK("select StrValue from MsConfig WHERE ConfigName='PathAutoSaveInvoice'")
                PathFolder = PathFolder & _jenisTransaksi & "\" & Format(DateAndTime.Now, "yyyy") & "\" & Format(DateAndTime.Now, "MMMM") & "\" & Format(DateAndTime.Now, "dd") & ""
                If (Not System.IO.Directory.Exists(PathFolder)) Then
                    System.IO.Directory.CreateDirectory(PathFolder)
                End If

                Dim NameFile As String = ""
                If JenisBayarSaved = "TAGIHAN" Then
                    NameFile = TextBoxNama.Text.ToUpper() & "_" & _idTransaksi.Trim & "_" & JenisBayarSaved & "_" & JenisBayarSavedKet.Replace("/", "") & "_INVOICE"
                Else
                    NameFile = TextBoxNama.Text.ToUpper() & "_" & _idTransaksi.Trim & "_" & JenisBayarSaved & "_INVOICE"
                End If

                Dim filepath As String = PathFolder & "\" & NameFile.Replace("/", "") & ".pdf"
                If File.Exists(filepath) Then
                    My.Computer.FileSystem.DeleteFile(filepath)
                End If
                Report.CreatePdfDocument(filepath)
                'End Save Report

                TransaksiLab.NewToolStripMenuItem1.PerformClick()

                MsgBox("Data berhasil disimpan di " & PathFolder & ", jangan lupa untuk cetak barcode untuk melanjutkan proses.", MsgBoxStyle.Information, "Success!")

                If MsgBox("Apakah anda ingin mencetak barcode pasien atas nama " & TextBoxNama.Text & "?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    CetakBarcode()
                End If

                ' Checklist Lunas
                CheckBoxLunasBayar.Checked = True
            End If
        End If
    End Sub

    ' API PCare - Bridging Antrean (v2)
    Function SendPCareDataV2() As Boolean
        '# Variabel BPJS
        Dim tglDaftarBPJS As String = Format(DateAndTime.Now, "dd-MM-yyyy")
        Dim uriBPJS As String = "http://sina.mitramedicare.com/v3/controller/ws_pcare_add_pendaftaran.php"
        Dim kdPoli As String = ""
        Dim kdTkp As String = ""
        Dim kunjSakit As String = ""

        '# Variabel SINA
        Dim _loc As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NoPoli'")
        Dim _sumber As String = "SINA"

        ' Get kdprovider
        Dim kdprovider As String = ReadSQLNIK("SELECT KdProviderPst FROM MasterPasienBPJS WHERE NoKartu = '" & _noBPJS & "'")

        ' Get Data Master Poli Tujuan
        Dim tblPoli As DataTable = ReadSQL("SELECT * FROM MasterPoliTujuan WHERE NamaPoli = '" & _namaPoli & "'")
        Dim rowPoli As DataRow = tblPoli.Rows(0)

        '# Post Data BPJS

        ' Get kdPoli
        kdPoli = rowPoli("KodeBPJS")

        ' Validasi apakah bridging PCare terpenuhi
        If ValidateBridgingPcare() = False Then Exit Function

        ' Validasi apakah transaksi sudah pelayanan di PCare
        If CheckAntreanBPJS(kdprovider, _noBPJS, kdPoli, tglDaftarBPJS) = False Then Exit Function

        ' Get kunjSakit
        If rowPoli("PoliSakit") = True Then
            kunjSakit = "true"
        ElseIf rowPoli("PoliSakit") = False Then
            kunjSakit = "false"
        End If

        ' Get kdTkp
        If FormPendaftaranAwal.RadioButtonStatusRawatJalan.Checked = True Then
            kdTkp = FormPendaftaranAwal.RadioButtonStatusRawatJalan.Tag
        ElseIf FormPendaftaranAwal.RadioButtonStatusRawatInap.Checked = True Then
            kdTkp = FormPendaftaranAwal.RadioButtonStatusRawatInap.Tag
        ElseIf FormPendaftaranAwal.RadioButtonPromotifPreventif.Checked = True Then
            kdTkp = FormPendaftaranAwal.RadioButtonPromotifPreventif.Tag
        End If

        ' Set parameter untuk POST data ke pcare BPJS
        Dim parameterPendaftaran As String = "{" & _
               """kdProviderPeserta"" : """ & kdprovider & """," & _
               """tglDaftar"" : """ & tglDaftarBPJS & """," & _
               """noKartu"" : """ & _noBPJS & """," & _
               """nik"" : """ & _noNIK & """," & _
               """kdPoli"" : """ & kdPoli & """," & _
               """keluhan"": """ & _keluhanUtama & """," & _
               """kunjSakit"": " & kunjSakit & "," & _
               """sistole"": 0," & _
               """diastole"": 0," & _
               """beratBadan"": 0," & _
               """tinggiBadan"": 0," & _
               """respRate"": 0," & _
               """lingkarPerut"": 0," & _
               """heartRate"": 0," & _
               """rujukBalik"": 0," & _
               """kdTkp"": """ & kdTkp & """," & _
               """loc"": """ & _loc & """," & _
               """bridgingPcare"": true," & _
               """sumber"": """ & _sumber & """" & _
              "}"

        Dim jsonString As String = InsertDataAPI(parameterPendaftaran, uriBPJS)

        jsonString = jsonString
        Dim jsonObject() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of varJson())(jsonString)

        ' Get data no urut pendaftaran pcare BPJS
        For Each rowData As varJson In jsonObject
            Dim codeMetaData As Integer = Convert.ToInt32(rowData.metaData.code)
            Dim messageMetaData As String = rowData.metaData.message
            Dim messageResponse As String = rowData.response.message

            Select Case codeMetaData
                Case 200, 201, 204
                    NoUrutBPJS = messageResponse ' Set Nomor Urut BPJS

                    Return True
                Case Else
                    If messageMetaData <> "Peserta sudah di-entri di poli yang sama pada hari yang sama." Then
                        Dim messageError As String = ""
                        If messageResponse <> "" And messageMetaData <> "" Then
                            messageError = messageResponse & " (" & messageMetaData & ")"
                        ElseIf messageResponse <> "" Then
                            messageError = messageResponse
                        ElseIf messageMetaData <> "" Then
                            messageError = messageMetaData
                        End If

                        MsgBox("Eror BPJS : " & vbCrLf & messageError, MsgBoxStyle.Exclamation, "Error!")

                        Return False
                    End If
            End Select
        Next

        Return True
    End Function

    Function SetStatusHadir() As Boolean
        '# Variabel BPJS
        Dim tglDaftar As String = Format(DateAndTime.Now, "dd-MM-yyyy")
        Dim uriSINA As String = "http://sina.mitramedicare.com/v3/controller/ws_pcare_add_pendaftaran.php"

        '# Variabel SINA
        Dim _loc As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NoPoli'")
        Dim _sumber As String = "SINA"

        ' Get Data Master Poli Tujuan
        Dim tblPoli As DataTable = ReadSQL("SELECT * FROM MasterPoliTujuan WHERE NamaPoli = '" & _namaPoli & "'")
        Dim rowPoli As DataRow = tblPoli.Rows(0)

        ' Get kdPoli
        Dim kdPoli As String = rowPoli("KodeBPJS")

        ' Set parameter untuk POST data ke pcare BPJS
        Dim parameterPendaftaran As String = "{" & _
               """tglDaftar"" : """ & tglDaftar & """," & _
               """nik"" : """ & _noNIK & """," & _
               """kdPoli"" : """ & kdPoli & """," & _
               """loc"": """ & _loc & """," & _
               """bridgingPcare"": false," & _
               """sumber"": """ & _sumber & """" & _
              "}"

        InsertDataAPI(parameterPendaftaran, uriSINA)

        Return True
    End Function

    ' API PCare - Non Bridging Antrean (v1)
    Function SendPCareDataV1() As Boolean
        '# Variabel BPJS
        Dim tglDaftarBPJS As String = Format(DateAndTime.Now, "dd-MM-yyyy")
        Dim urlBPJS As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'pcare_base_url'")
        Dim uriBPJS As String = urlBPJS + "pendaftaran"
        Dim kdPoli As String = ""
        Dim kdTkp As String = ""
        Dim kunjSakit As String = ""

        ' Get kdprovider
        Dim kdprovider As String = ReadSQLNIK("SELECT KdProviderPst FROM MasterPasienBPJS WHERE NoKartu = '" & _noBPJS & "'")

        ' Get Data Master Poli Tujuan
        Dim tblPoli As DataTable = ReadSQL("SELECT * FROM MasterPoliTujuan WHERE NamaPoli = '" & _namaPoli & "'")
        Dim rowPoli As DataRow = tblPoli.Rows(0)

        ' Get kdPoli
        kdPoli = rowPoli("KodeBPJS")

        ' Validasi apakah bridging PCare terpenuhi
        If ValidateBridgingPcare() = False Then Exit Function

        ' Validasi apakah transaksi sudah pelayanan di PCare
        If CheckAntreanBPJS(kdprovider, _noBPJS, kdPoli, tglDaftarBPJS) = False Then Exit Function

        ' Get kunjSakit
        If rowPoli("PoliSakit") = True Then
            kunjSakit = "true"
        ElseIf rowPoli("PoliSakit") = False Then
            kunjSakit = "false"
        End If

        ' Get kdTkp
        If FormPendaftaranAwal.RadioButtonStatusRawatJalan.Checked = True Then
            kdTkp = FormPendaftaranAwal.RadioButtonStatusRawatJalan.Tag
        ElseIf FormPendaftaranAwal.RadioButtonStatusRawatInap.Checked = True Then
            kdTkp = FormPendaftaranAwal.RadioButtonStatusRawatInap.Tag
        ElseIf FormPendaftaranAwal.RadioButtonPromotifPreventif.Checked = True Then
            kdTkp = FormPendaftaranAwal.RadioButtonPromotifPreventif.Tag
        End If

        ' Set parameter untuk POST data ke pcare BPJS
        Dim parameterPendaftaran As String = "{" & _
               """kdProviderPeserta"" : """ & kdprovider & """," & _
               """tglDaftar"" : """ & tglDaftarBPJS & """," & _
               """noKartu"" : """ & _noBPJS & """," & _
               """kdPoli"" : """ & kdPoli & """," & _
               """keluhan"": """ & _keluhanUtama & """," & _
               """kunjSakit"": " & kunjSakit & "," & _
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

        Dim jsonString As String = PostDataFromPcare(parameterPendaftaran, uriBPJS, "POST")
        jsonString = "[" + jsonString + "]"
        Dim jsonObject() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of varJson())(jsonString)

        ' Get data no urut pendaftaran pcare BPJS
        For Each rowData As varJson In jsonObject
            Dim codeMetaData As Integer = Convert.ToInt32(rowData.metaData.code)
            Dim messageMetaData As String = rowData.metaData.message
            Dim messageResponse As String = rowData.response.message

            Select Case codeMetaData
                Case 200, 201, 204
                    NoUrutBPJS = messageResponse ' Set Nomor Urut BPJS
                Case Else
                    If messageMetaData <> "Peserta sudah di-entri di poli yang sama pada hari yang sama." Then
                        Dim messageError As String = ""
                        If messageResponse <> "" And messageMetaData <> "" Then
                            messageError = messageResponse & " (" & messageMetaData & ")"
                        ElseIf messageResponse <> "" Then
                            messageError = messageResponse
                        ElseIf messageMetaData <> "" Then
                            messageError = messageMetaData
                        End If

                        MsgBox("Eror BPJS : " & vbCrLf & messageError, MsgBoxStyle.Exclamation, "Error!")

                        Return False
                    End If
            End Select
        Next

        Return True
    End Function

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

    Private Sub ButtonSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSimpan.Click
        Try
            ' Simpan Pembayaran
            SaveDataPembayaran()
        Catch ex As Exception
            ' Tangani pengecualian di sini
            MessageBox.Show("Terjadi kesalahan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub GenerateInvoice(ByVal JenisTransaksi As String, ByVal JenisProses As String, ByVal NomorTransaksi As String)
        ' Validasi Pembayaran
        If CheckBoxLunasBayar.Checked = False Then
            MessageBox.Show("Gagal!. Transaksi belum dilakukan pembayaran.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        ' Set Data Pasien
        Dim tblsPasien As DataTable = ReadSQL("SELECT NoHandphone, Email, NoRekamMedis, Nama + ' / (' + JenisKelamin + ')' AS 'Nama', YEAR(TglLahir) AS 'TahunLahir', MONTH(TglLahir) AS 'BulanLahir', DAY(TglLahir) AS 'TanggalLahir', " & _
                                              "CONVERT(VARCHAR(11),TglLahir,106) AS 'TanggalLengkap', DomisiliAlamat AS 'Alamat' " & _
                                              "FROM MasterPasien WHERE NoRekamMedis = '" & TextBoxNomorRM.Text & "'")
        Dim rowPasien As DataRow = tblsPasien.Rows(0)
        Dim Tdate As Date = DateSerial(rowPasien("TahunLahir"), rowPasien("BulanLahir"), rowPasien("TanggalLahir"))

        ' Set Nama Dokter
        Dim namaDokter As String = ""
        If JenisTransaksi = "LAB" Then
            namaDokter = ReadSQLNIK("SELECT a.DrNama FROM MasterDokterKirim a LEFT JOIN MasterDokterTempatPraktek b ON a.IdKirim = b.IdKirim WHERE b.IdPraktek IN (SELECT DokterRequest FROM transaksilab WHERE NoUrut = '" & NomorTransaksi & "')")
        ElseIf JenisTransaksi = "AWAL" Or JenisTransaksi = "UMUM" Then
            namaDokter = ReadSQLNIK("SELECT DokterPoli FROM TransaksiPoli WHERE NoUrut = '" & NomorTransaksi & "'")
        ElseIf JenisTransaksi = "AWALGIGI" Or JenisTransaksi = "GIGI" Then
            namaDokter = ReadSQLNIK("SELECT DokterGigi FROM TransaksiGigi WHERE NoUrut = '" & NomorTransaksi & "'")
        End If

        Dim NewHeader As DataTable = CreateTable()
        NewHeader.Rows.Clear()
        For Each rowTindakan As DataRow In tblTindakan.Rows
            Dim Tnew As DataRow = NewHeader.NewRow

            ' Set Header
            Tnew("Registrasi") = rowPasien("NoRekamMedis")
            Tnew("Nama") = rowPasien("Nama")
            Tnew("Umur") = rowPasien("TanggalLengkap") & " / " & Umur(Tdate.Date)
            Tnew("Alamat") = rowPasien("Alamat")
            Tnew("Tanggal") = Format(DateAndTime.Now, "dd-MMM-yyyy")
            Tnew("NoTransaksi") = NomorTransaksi

            If JenisTransaksi = "LAB" Then
                Tnew("DrPengirim") = namaDokter
                Tnew("StatusAmbil") = ReadSQLNIK("SELECT CaraAmbil FROM TransaksiLab WHERE NoUrut = '" & NomorTransaksi & "'")
                Tnew("lblDokter") = "Dr. Pengirim"
                Tnew("lblStatusAmbil") = "Status Ambil"
                Tnew("lbltitikDokter") = ":"
                Tnew("lbltitikStatusAmbil") = ":"
            Else
                Tnew("DrPengirim") = namaDokter
                Tnew("StatusAmbil") = ""
                Tnew("lblDokter") = "Dr. Pelaksana"
                Tnew("lblStatusAmbil") = ""
                Tnew("lbltitikDokter") = ":"
                Tnew("lbltitikStatusAmbil") = ""
            End If

            'MsgBox("Debug Info:" & vbCrLf & _
            '           "harga awal: " & rowTindakan("Harga Awal") & _
            '           "biaya:" & rowTindakan("Biaya Tindakan"))

            If statusQR = True Then
                Dim hargaAwal As Decimal = Convert.ToDecimal(rowTindakan("Harga Awal"))
                Dim diskon As Decimal = Convert.ToDecimal(rowTindakan("Diskon"))

                ' Menghitung persentase diskon berdasarkan harga awal dan diskon
                Dim discTindakan As Decimal
                If hargaAwal > 0 Then
                    discTindakan = (diskon / hargaAwal) * 100
                Else
                    discTindakan = 0 ' Menghindari pembagian dengan nol
                End If

                Tnew("TindakanID") = rowTindakan("PaketID").ToString()
                Tnew("Tindakan") = rowTindakan("Nama Paket")
                Tnew("Jenis") = rowTindakan("Keterangan Paket")
                Tnew("Biaya Tindakan") = rowTindakan("Harga Awal")
                Tnew("DiscTindakan") = discTindakan
                Tnew("DiscNilai") = rowTindakan("Diskon")
                Tnew("NettBayar") = rowTindakan("Harga Nett")
            Else
                Tnew("TindakanID") = rowTindakan("TindakanID")
                Tnew("Tindakan") = rowTindakan("Tindakan")
                Tnew("Jenis") = rowTindakan("Jenis")
                Tnew("Biaya Tindakan") = rowTindakan("Biaya Tindakan")
                Tnew("DiscTindakan") = rowTindakan("DiscTindakan")
                Tnew("DiscNilai") = rowTindakan("DiscNilai")
                Tnew("NettBayar") = rowTindakan("NettBayar")
            End If

            NewHeader.Rows.Add(Tnew)
        Next

        Report = New XtraReport

        ' Set report berdasarkan jenis proses
        Select Case JenisProses
            Case "Preview"
                Report = XtraReport.FromFile(Application.StartupPath + "\reports\Resource\PrintInvoiceTransaksiKop.repx", True)
            Case "Cetak"
                Report = XtraReport.FromFile(Application.StartupPath + "\reports\Resource\PrintInvoiceTransaksi.repx", True)
            Case "Export PDF"
                Report = XtraReport.FromFile(Application.StartupPath + "\reports\Resource\PrintInvoiceTransaksiKop.repx", True)
            Case "WhatsApp"
                Report = XtraReport.FromFile(Application.StartupPath + "\reports\Resource\PrintInvoiceTransaksiKop.repx", True)
            Case "Email"
                Report = XtraReport.FromFile(Application.StartupPath + "\reports\Resource\PrintInvoiceTransaksiKop.repx", True)
        End Select

        Report.DataSource = NewHeader

        Dim tblPembayaran As New DataTable
        Dim nominalTotalInvoice As Double
        Dim nominalKembaliInvoice As Double

        ' Set data pembayaran transaksi
        Select Case JenisTransaksi
            Case "UMUM"
                tblPembayaran = ReadSQL("SELECT * FROM TransaksiPoliBayar WHERE TransPoliID IN (SELECT TransPoliID FROM TransaksiPoli WHERE NoUrut = '" & NomorTransaksi & "')")
            Case "GIGI"
                tblPembayaran = ReadSQL("SELECT * FROM TransaksiGigiBayar WHERE TransGigiID IN (SELECT TransGigiID FROM TransaksiGigi WHERE NoUrut = '" & NomorTransaksi & "')")
            Case "LAB"
                tblPembayaran = ReadSQL("SELECT * FROM TransaksiLabBayar WHERE TransLabID IN (SELECT TransLabID FROM TransaksiLab WHERE NoUrut = '" & NomorTransaksi & "')")
            Case "AWAL"
                tblPembayaran = ReadSQL("SELECT * FROM TransaksiPoliBayarAwal WHERE TransPoliID IN (SELECT TransPoliID FROM TransaksiPoli WHERE NoUrut = '" & NomorTransaksi & "')")
            Case "AWALGIGI"
                tblPembayaran = ReadSQL("SELECT * FROM TransaksiGigiBayarAwal WHERE TransGigiID IN (SELECT TransGigiID FROM TransaksiGigi WHERE NoUrut = '" & NomorTransaksi & "')")
        End Select

        For i As Integer = 1 To tblPembayaran.Rows.Count
            Dim rowPembayaran As DataRow = tblPembayaran.Rows(i - 1)
            Dim Tket As String = "bayar" & i
            Report.Bands.Item(BandKind.ReportFooter).Controls(Tket).Visible = True
            If rowPembayaran("JenisBayar") = "TAGIHAN" Or rowPembayaran("JenisBayar") = "TUNAI" Then
                Report.Bands.Item(BandKind.ReportFooter).Controls(Tket).Text = rowPembayaran("JenisBayar") & " - Jumlah : " & Splitmoney(rowPembayaran("JumlahBayar")) & " (" & rowPembayaran("NoJenisBayar").ToString & ")"
            Else
                Report.Bands.Item(BandKind.ReportFooter).Controls(Tket).Text = rowPembayaran("JenisBayar") & " - No Kartu : " & "*".PadRight(Len(rowPembayaran("NoJenisBayar")) - 3) & Strings.Right(rowPembayaran("NoJenisBayar"), 3) & rowPembayaran("kartu") & " - Jumlah : " & Splitmoney(rowPembayaran("JumlahBayar"))
            End If

            nominalTotalInvoice = nominalTotalInvoice + rowPembayaran("JumlahBayar")
            nominalKembaliInvoice = nominalKembaliInvoice + rowPembayaran("Kembali")
        Next

        Report.Bands.Item(BandKind.ReportFooter).Controls("lblBayar").Text = Splitmoney(nominalTotalInvoice)
        Report.Bands.Item(BandKind.ReportFooter).Controls("lblKembalian").Text = Splitmoney(nominalKembaliInvoice)
        Report.Bands.Item(BandKind.BottomMargin).Controls("lbladmin").Text = userInput
        Report.Bands.Item(BandKind.BottomMargin).Controls("lbltanggalcetak").Text = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mmm:ss")

        ' Set QR (Report)
        If statusQR = True Then
            Dim Generator As New MessagingToolkit.Barcode.BarcodeEncoder
            Dim qrImage As Bitmap = New Bitmap(Generator.Encode(MessagingToolkit.Barcode.BarcodeFormat.QRCode, keteranganQR))

            Dim pictureBox As XRPictureBox = CreateXRPictureBox(qrImage, 0, 0, 175, 100)
            Dim panelQR As XRPanel = CType(Report.Bands(BandKind.ReportFooter).Controls("xrPanelQR"), XRPanel)

            ' Add pictureBox
            panelQR.Controls.Add(pictureBox)

            ' Set Visible
            panelQR.Visible = True
            Report.Bands.Item(BandKind.ReportFooter).Controls("xrLabelKodeVoucher").Visible = True
        End If

        ' Simpan Softfile PDF jika memilih WhatsApp & Email
        If JenisProses = "WhatsApp" Or JenisProses = "Email" Then
            ' Save PDF
            Dim NameFile As String = NomorTransaksi & "_" & JenisTransaksi
            Dim folderPath As String = "FileDownload\Invoice\" & JenisTransaksi
            Dim filepath As String = folderPath & "\" & NameFile & ".pdf"

            ' Cek dan buat folder jika belum ada
            If Not System.IO.Directory.Exists(folderPath) Then
                System.IO.Directory.CreateDirectory(folderPath)
            End If

            ' Hapus file lama jika ada
            If System.IO.File.Exists(filepath) Then
                System.IO.File.Delete(filepath)
            End If

            ' Simpan PDF
            Report.CreatePdfDocument(filepath)
        End If

        ' Set report berdasarkan jenis proses
        Select Case JenisProses
            Case "Preview"
                Report.ShowPreview()
            Case "Cetak"
                Report.Print()
            Case "Export PDF"
                Dim sfd As New SaveFileDialog()
                sfd.Title = "Simpan PDF"
                sfd.Filter = "PDF Files (*.pdf)|*.pdf"
                sfd.FileName = NomorTransaksi & "_" & JenisTransaksi & ".pdf"

                If sfd.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Dim filepath As String = sfd.FileName

                    ' Hapus file lama jika ada
                    If System.IO.File.Exists(filepath) Then
                        System.IO.File.Delete(filepath)
                    End If

                    ' Simpan PDF ke lokasi yang dipilih user
                    Report.CreatePdfDocument(filepath)
                End If
            Case "WhatsApp"
                thread = New System.Threading.Thread(AddressOf KirimInvoiceWhatsApp)
                thread.Start()
            Case "Email"

        End Select
    End Sub

    Public Sub KirimInvoiceWhatsApp()
        Try
            Dim JenisTransaksi As String = _jenisTransaksi
            Dim NomorTransaksi As String = _nomorUrutTransaksi
            Dim namaPasien As String = TextBoxNama.Text
            Dim NoWhatsappCustomer As String = ReadSQLNIK("SELECT NoHandphone FROM MasterPasien WHERE NoRekamMedis = '" & _noRekamMedis & "'")

            ' Ganti format nomor WhatsApp
            If NoWhatsappCustomer.StartsWith("08") Then
                ' Format lokal Indonesia, ubah ke format internasional
                NoWhatsappCustomer = "62" & NoWhatsappCustomer.Substring(1)
            ElseIf NoWhatsappCustomer.StartsWith("+") Then
                ' Sudah format internasional dengan tanda +, hapus + saja
                NoWhatsappCustomer = NoWhatsappCustomer.Substring(1)
            End If

            ' Set Variabel WhatsApp
            Dim whatsAppStatus As String = ""
            Dim whatsAppIP As String = ""
            Dim keteranganLokasi As String = ""

            If _jenisTransaksi = "LAB" Then ' Set Nomor WhatsApp Lab
                whatsAppStatus = ReadSQLNIK("SELECT StrValue FROM msconfig WHERE ConfigName = 'whatsapp_laboratorium_status'")
                whatsAppIP = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'whatsapp_laboratorium_ip'")
                keteranganLokasi = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'InvoiceTempat_Lab'")
            Else ' Set Nomor WhatsApp Klinik
                whatsAppStatus = ReadSQLNIK("SELECT StrValue FROM msconfig WHERE ConfigName = 'whatsapp_klinik_status'")
                whatsAppIP = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'whatsapp_klinik_ip'")
                keteranganLokasi = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'InvoiceTempat_Klinik'")
            End If

            ' Validasi Setting WhatsApp
            If whatsAppStatus <> "Yes" Then
                MessageBox.Show("Gagal!. WhatsApp belum di setting, hubungi tim IT.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            ' Set Variabel API
            Dim fileBase64 As String = ""
            Dim parameter As String = ""
            Dim urlSendPDF As String = ""
            Dim urlSendMessage As String = ""
            Dim statusKirim As String = ""

            ' Set PDF
            Dim fileName As String = NomorTransaksi & "_" & JenisTransaksi
            Dim folderPath As String = "FileDownload\Invoice\" & JenisTransaksi
            Dim filePath As String = folderPath & "\" & fileName & ".pdf"

            ' Set File Base64
            fileBase64 = Convert.ToBase64String(System.IO.File.ReadAllBytes(filePath))

            ' Set Pesan WhatsApp
            Dim pesanWhatsApp As String = "Halo " & namaPasien & ".\n\n" & _
                                          "Kami mengucapkan terima kasih atas kepercayaan Bapak/Ibu/Saudara/i sudah melakukan pemeriksaan di " & keteranganLokasi & ".\n" & _
                                          "Berikut nomor nota transaksi Anda:\n" & _
                                          "" & NomorTransaksi & "\n" & _
                                          "Harap simpan nomor nota ini untuk referensi dan keperluan selanjutnya.\n\n" & _
                                          "Best regards,\n\n" & _
                                          "" & keteranganLokasi & ".\n\n" & _
                                          "----- Pesan ini adalah pesan otomatis, mohon agar tidak membalas -----"

            ' Set Parameter WhatsApp
            parameter = SetParameterWhatsappKlinik(NoWhatsappCustomer, fileBase64, fileName, pesanWhatsApp)

            ' Set URL WhatsApp
            'urlSendMessage = "http://" & whatsAppIP & ":4444/send"
            urlSendMessage = "http://" & whatsAppIP & ":4444/send"
            urlSendPDF = "http://" & whatsAppIP & ":4444/send-pdf"

            ' Validasi Kirim WhatsApp
            If CheckSQL("SELECT * FROM LogSendingWhatsappEmail WHERE NoUrut = '" & NomorTransaksi & "' AND SendingNamaFile = '" & fileName & "' AND SendingStatus = 1 AND CONVERT(DATE, SendingDate) = '" & Format(DateTime.Now, "yyyy-MM-dd") & "'") = True Then
                ' Validasi Kirim Ulang
                If MessageBox.Show("WhatsApp sudah pernah dikirim, yakin tetap kirim invoice transaksi ke nomor " & NoWhatsappCustomer & "?", "Validasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

                ' Kirim PDF
                statusKirim = SendDataWhatsapp(parameter, urlSendPDF)
            Else
                If MessageBox.Show("Yakin kirim invoice transaksi ke nomor " & NoWhatsappCustomer & "?", "Validasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then Exit Sub

                ' Kirim Text & PDF
                SendDataWhatsapp(parameter, urlSendMessage)
                statusKirim = SendDataWhatsapp(parameter, urlSendPDF)
            End If

            If statusKirim = "Success" Then
                ' Insert Log
                WriteSQL("INSERT INTO LogSendingWhatsappEmail (SendingJenis, SendingTujuan, SendingNamaFile, SendingStatus, SendingDate, SendingBy, NoUrut, JenisSending) VALUES ('Whatsapp', '" & NoWhatsappCustomer & "', '" & fileName & "', 1, GETDATE(), '" & userInput & "', '" & NomorTransaksi & "', 'PASIEN')", 4)

                MsgBox("Berhasil mengirim Whatsapp ke " & NoWhatsappCustomer.Trim & ".", MsgBoxStyle.Information, "Success!")
            ElseIf statusKirim = "Nothing" Then
                MsgBox("Gagal Mengirim Whatsapp ke " & NoWhatsappCustomer.Trim & ". Cek koneksi jaringan atau hubungi IT untuk restart server Whatsapp.", MsgBoxStyle.Exclamation, "Warning!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ButtonCetakInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCetakInvoice.Click
        GenerateInvoice(_jenisTransaksi, "Cetak", _nomorUrutTransaksi)
    End Sub

    Private Sub ButtonExportInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExportInvoice.Click
        GenerateInvoice(_jenisTransaksi, "Export PDF", _nomorUrutTransaksi)
    End Sub

    Private Sub ButtonWhatsAppInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonWhatsAppInvoice.Click
        GenerateInvoice(_jenisTransaksi, "WhatsApp", _nomorUrutTransaksi)
    End Sub

    Function ValidasiGenerateInvoice() As Boolean
        ' Validasi Pembayaran
        If CheckBoxLunasBayar.Checked = False Then
            MessageBox.Show("Gagal!. Transaksi belum dilakukan pembayaran.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If

        Return True
    End Function
End Class