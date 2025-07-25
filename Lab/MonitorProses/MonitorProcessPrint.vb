Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports System.IO
Imports System.Text
Imports System.Net.Mail
Imports System.Net
Imports System.Net.Sockets
Imports System.Object
Imports Newtonsoft.Json
Imports Newtonsoft
Imports System.Security.Cryptography
Imports System.Collections.Generic
Imports Newtonsoft.Json.Linq

Public Class MonitorProcessPrint
    Dim Ttcmh As New TLcon
    Dim Fcon As New TLcon
    Dim thread As System.Threading.Thread
    Public NoWhatsappCompany As String = ""
    Public NoWhatsappMarketing As String = ""
    Public EmailCompany As String = ""
    Public Tnourut As String = ""
    Public UserLabAdmin As String = PoliKlinik.Lbluser.Text

    Private Sub SetClear()
        dtprocess.Value = DateAndTime.Now
        rd1.Checked = True
        GridProses.Rows.Clear()
        rd1.Enabled = True
        rd2.Enabled = True
        'LoadTable()
    End Sub

    Private Sub LoadTable()
        Dim status As String = ""
        Dim Tquery As String = ""
        Dim Torder As String = ""
        Dim Tjenistransaksi As String = ""
        Dim Thasilawal As Date = dtprocess.Value
        Dim Tawal As Date = DateSerial(Thasilawal.Year, Thasilawal.Month, Thasilawal.Day)

        'Jenis Transaksi
        If rd1.Checked = True Then
            Tjenistransaksi = " StatusHardcopy=1 and "
        ElseIf rd2.Checked = True Then
            Tjenistransaksi = "StatusSoftcopy=1 and "
        End If

        'Penggunaan order by
        Torder = " ORDER BY a.inctgl, a.incjenis, a.jenis ASC"

        'Query Dasar
        Tquery = "SELECT c.NoJenisBayar, c.JenisBayar, a.TransLabID, a.DetailPemeriksaan, a.Status, a.NoUrut, b.Nama, b.TglLahir, b.DomisiliAlamat, a.CaraAmbil, StatusSoftcopy, StatusHardcopy, TglLab, TglInputHasil,  TglCetakHasil, LabSendMail " & _
                 " FROM TransaksiLab a " & _
                 " LEFT JOIN MasterPasien b on a.IDInternet=b.NoRekamMedis " & _
                 " LEFT JOIN TransaksiLabBayar c on  a.TransLabID=c.TransLabID " & _
                 " WHERE " & Tjenistransaksi & " deleted <> 1 and TglInputHasil is not null and [Status] not in ('CLOSED') AND CONVERT(date, Tgllab)  = '" & Tawal & "' order by a.TglLab,a.TransLabID,a.NoUrut"

        Dim Tbls As DataTable = ReadSQL(Tquery)
        GridProses.Rows.Clear()

        If Tbls.Rows.Count > 0 Then
            For Each Trow As DataRow In Tbls.Rows
                Dim company As String = ""
                Dim statushardcopy As String = ""
                Dim statussoftcopy As String = ""

                If Trow("JenisBayar").ToString.Trim = "TAGIHAN" Then
                    Dim Tsplit() As String = Trow("NoJenisBayar").ToString.Split("-")
                    company = Tsplit(0).ToUpper.Trim
                Else
                    company = "PASIEN UMUM"
                End If

                If rd1.Checked = True Then
                    If IsDBNull(Trow("TglCetakHasil")) = False Then
                        statushardcopy = "Done"
                    Else
                        statushardcopy = "-"
                    End If

                    'If IsDBNull(Trow("LabSendMail")) = False Then
                    '    statussoftcopy = "Done"
                    'Else
                    '    statussoftcopy = "-"
                    'End If
                ElseIf rd2.Checked = True Then
                    If CheckSQL("select * FROM LogSendingWhatsappEmail WHERE NoUrut = '" & Trow("NoUrut") & "'") = True Then
                        statushardcopy = "Done"
                    Else
                        statushardcopy = "-"
                    End If
                End If

                GridProses.Rows.Add(New String() {"" & Trow("NoUrut") & "", "" & Trow("TransLabID") & "", "" & Trow("Nama") & "", "" & Trow("DetailPemeriksaan") & "", "" & Trow("CaraAmbil") & "", "" & company & "", "" & statushardcopy & "", "" & statussoftcopy & ""})
            Next

            If rd1.Checked = True Then
                rd2.Enabled = False
            ElseIf rd2.Checked = True Then
                rd1.Enabled = False
            End If
        Else
            MsgBox("Belum ada data transaksi di tanggal tersebut")
        End If
    End Sub

    Private Sub SetConnection()
        Ttcmh.Tid = "root"
        Ttcmh.Tip = ReadSQLNIK("select StrValue from MsConfig where ConfigName='Twebid'")
        Ttcmh.Tdb = "db_tracking"
        Ttcmh.Tpass = Strings.Replace(ReadSQLNIK("select StrValue from MsConfig where ConfigName='Twebpass'"), "|", "")

        Fcon.Tid = "root"
        Fcon.Tip = ReadSQLNIK("select StrValue from MsConfig where ConfigName='Twebid'")
        Fcon.Tdb = "mitramed_keu"
        Fcon.Tpass = Strings.Replace(ReadSQLNIK("select StrValue from MsConfig where ConfigName='Twebpass'"), "|", "")
    End Sub

    Private Sub MonitorProcessPrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        Me.MdiParent = PoliKlinik
        SetConnection()
        SetClear()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        LoadTable()
    End Sub

    Private Sub GridProses_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles GridProses.CellContentClick
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        Dim grid = DirectCast(sender, DataGridView)

        If TypeOf grid.Columns(e.ColumnIndex) Is DataGridViewButtonColumn Then
            If grid.Columns(e.ColumnIndex).Name = "Printed" Then
                Print_Lab(GridProses.Rows(e.RowIndex).Cells("ID").Value, GridProses.Rows(e.RowIndex).Cells("Pemeriksaan").Value)
                'GridTunai.Rows(e.RowIndex).Cells("NilaiUangTunai").Style.BackColor = Color.Blue
            ElseIf grid.Columns(e.ColumnIndex).Name = "Sending" Then
                sending_lab(GridProses.Rows(e.RowIndex).Cells("ID").Value)
            End If
        End If
    End Sub

    Private Sub Print_Lab(ByVal id As String, ByVal pemeriksaan As String)
        Dim keyPT As Boolean = True
        If CheckSQL("select * FROM TransaksiLab WHERE TransLabID='" & id & "' and TglInputHasil is null") = True Then
            MsgBox("Input hasil terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Exit Sub
        End If

        Dim KodeBarcode As String = ReadSQLNIK("select StrValue FROM MsConfig WHERE ConfigName='KodeBarcode'")

        'SetClearGrid()
        Dim Tbls As DataTable = ReadSQL("select a.TransLabID,a.TransLabIDDetail,a.TindakanID,a.NamaTindakan,a.JenisTindakan,b.NoUrut,b.GroupID,b.DetailKet,b.Result,b.Satuan,b.Pria,b.Wanita,b.Keterangan,m.UrutanJenisID,a.Urutan, b.saran as 'Saran'  FROM transaksilabdetail a LEFT JOIN TransaksiLabResult b on a.TransLabIDDetail =b.TransLabIDDetail and a.TindakanID=b.TindakanID LEFT JOIN MasterJenisTindakan m on m.JenisTindakan=a.JenisTindakan WHERE a.TransLabID='" & id & "'  order by  m.UrutanJenisID,a.Urutan,b.TindakanID,b.NoUrut,a.TransLabIDDetail,a.TindakanID,b.GroupID,b.DetailKet")
        insertRowToTbls(Tbls, "typstring", "Registrasi")
        insertRowToTbls(Tbls, "typstring", "Hasil")
        insertRowToTbls(Tbls, "typstring", "Nama")
        insertRowToTbls(Tbls, "typstring", "Umur")
        insertRowToTbls(Tbls, "typstring", "Alamat")
        insertRowToTbls(Tbls, "typstring", "NoTransaksi")
        insertRowToTbls(Tbls, "typstring", "DrPelaksana")
        insertRowToTbls(Tbls, "typstring", "DrRequest")
        insertRowToTbls(Tbls, "typstring", "Standart P/W")
        insertRowToTbls(Tbls, "typstring", "Tanggal")
        insertRowToTbls(Tbls, "typstring", "barcodenotrans")
        insertRowToTbls(Tbls, "typstring", "KesimpulanAll")

        Dim Tlab As DataTable = ReadSQL("SELECT a.DokterRequest, convert(date, a.TglLab) as 'TglLab', convert(date, b.TglLahir) as 'TglLahir', b.DomisiliAlamat, b.JenisKelamin, a.NoUrut, b.Nama, a.Kesimpulan, a.Saran, b.NoNIK, a.caraambil, c.JenisBayar, c.NoJenisBayar " & _
                                        "FROM transaksilab a " & _
                                        "LEFT JOIN MasterPasien b ON a.IDInternet = b.NoRekamMedis " & _
                                        "LEFT JOIN TransaksiLabBayar c on a.TransLabID = c.TransLabID " & _
                                        "WHERE a.TransLabID='" & id & "'")
        Dim TrowLab As DataRow = Tlab.Rows(0)
        Dim Tsimpul As String = TrowLab("Kesimpulan")
        Dim Tsaran As String = TrowLab("Saran")
        Dim ptnik As String = ""
        If IsDBNull(TrowLab("NoNIK")) = False Then ptnik = TrowLab("NoNIK") Else ptnik = "-"
        Dim caraambil As String = TrowLab("caraambil")
        Tnourut = TrowLab("NoUrut")
        Dim Talamat As String = TrowLab("DomisiliAlamat").ToString
        Dim Tgelar As String = Gelar(Year(Now()) - Year(TrowLab("TglLahir")), TrowLab("JenisKelamin").ToString.Trim)

        For Each Trow As DataRow In Tbls.Rows
            Trow("Registrasi") = TrowLab("Nama").ToString.Trim
            Dim Turutan As String = Strings.Replace(Strings.Replace(Tnourut, "L", "8"), "M", "9")
            Trow("barcodenotrans") = id
            If (Tnourut.Contains("M")) Then
                If IsNumeric(Trow("Nama")) = True Then
                    Trow("Nama") = Tgelar & " " & TrowLab("Nama").ToString.Trim & "/(" & TrowLab("JenisKelamin").ToString.Trim & ")" & vbCrLf
                Else
                    Trow("Nama") = Tgelar & " " & TrowLab("Nama").ToString.Trim & " / " & ptnik & " (" & TrowLab("JenisKelamin").ToString.Trim & ")" & vbCrLf
                End If
            Else
                Trow("Nama") = Tgelar & " " & TrowLab("Nama").ToString.Trim & "/(" & TrowLab("JenisKelamin").ToString.Trim & ")" & vbCrLf
            End If

            Dim Tgltemp As Date = TrowLab("TglLahir")
            If Tgltemp.Date.AddYears(120).Year < DateAndTime.Now.Year Then
                Trow("Umur") = ""
            Else
                Trow("Umur") = Format(TrowLab("TglLahir"), "dd MMM yyyy") & " / " & Umur(TrowLab("TglLahir"))
            End If
            Trow("Alamat") = Talamat
            Trow("NoTransaksi") = Tnourut & " (" & id & ")"
            Trow("DrPelaksana") = ReadSQLNIK("select StrValue FROM MsConfig WHERE ConfigName='DokterPK'")
            Trow("Hasil") = caraambil
            If (Tnourut.Contains("M")) Then
                If keyPT = True Then
                    Dim Tsplit() As String = TrowLab("NoJenisBayar").ToString.Split("-")
                    Trow("DrRequest") = Tsplit(0).ToString.Trim
                Else
                    Trow("DrRequest") = "Atas Permintaan Sendiri"
                End If
            Else
                Trow("DrRequest") = ReadSQLNIK("select DrNama FROM MasterDokterKirim WHERE IdKirim in ( select IdKirim FROM MasterDokterTempatPraktek WHERE IdPraktek='" & TrowLab("DokterRequest") & "')")
            End If
            Trow("Tanggal") = Format(TrowLab("tgllab"), "dd-MMM-yyyy")
            Trow("Satuan") = Trow("Satuan").ToString
            Dim Tkriteria As String = ""
            If TrowLab("JenisKelamin").ToString.Trim = "L" Then
                'display hasil pria
                Tkriteria = Trow("Pria").ToString
            ElseIf TrowLab("JenisKelamin").ToString.Trim = "P" Then
                'display hasil wanita
                Tkriteria = Trow("Wanita").ToString
            Else
                MsgBox("Report Tidak bisa di-Display karena Jenis Kelamin tidak terdefinisi. Update Jenis Kelamin terlebih dahulu.")
                Exit Sub
            End If
            Trow("Standart P/W") = Tkriteria

            If Tsimpul <> "" And Tsaran <> "" Then
                Trow("KesimpulanAll") = "Kesimpulan :" + vbCrLf + Tsimpul + vbCrLf + vbCrLf + "Saran :" + vbCrLf + Tsaran
            ElseIf Tsimpul <> "" Then
                Trow("KesimpulanAll") = "Kesimpulan :" + vbCrLf + Tsimpul
            ElseIf Tsaran <> "" Then
                Trow("KesimpulanAll") = "Saran :" + vbCrLf + Tsaran
            End If
        Next

        Report = New XtraReport
        Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\Hasil\HasilLabNonKop.repx", True)
        Report.DataSource = Tbls

        Report.Bands.Item(BandKind.ReportFooter).Controls("ttd").Visible = True
        Report.Bands.Item(BandKind.ReportFooter).Controls("ttd").Height = 134
        Report.Bands.Item(BandKind.ReportFooter).Controls("ttd").Width = 250
        Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MM-yyyy HH:mm:ss") + " by " + UserLabAdmin

        'Report.RunDesigner()
        'Report.ShowPreview()
        Report.Print()

        If CheckSQL("select * FROM TransaksiLab WHERE TransLabID='" & id & "' and TglCetakHasil is null") = True Then
            WriteSQL("update TransaksiLab set TglCetakHasil=getdate(), LabCetak=getdate() , [Status]='TAKEIT' , UserCetakHasil='" & UserLabAdmin & "' ,ClosedInputHasil=1 WHERE TransLabID='" & id & "'", 4)
        End If

        If rd1.Checked = True Then
            sending_tracking_online(id, pemeriksaan)
        End If

        Button1.PerformClick()
    End Sub

    Private Sub sending_tracking_online(ByVal id As String, ByVal pemeriksaan As String)
        Dim Tloc As String = ReadSQLNIK("select StrValue  FROM MsConfig WHERE ConfigName='NoPoli'")
        Dim TglLab As String = "", LabDaftar As String = "", LabSamplingTime As String = "", LabStartTime As String = "", TglInputHasil As String = "", TglCetakHasil As String = ""
        Dim Tcompany As String = ""
        Dim Tlab As DataTable = ReadSQL("select a.TransLabID, a.NoUrut, b.Nama, CONVERT(date, b.TglLahir) as 'TglLahir',  " & _
                                        " b.DomisiliAlamat, c.NoJenisBayar, b.NoRekamMedis, a.CaraAmbil, StatusSoftcopy, StatusHardcopy,  " & _
                                        " deleted, tgllab, labdaftar, labsamplingtime, labstarttime, tglinputhasil, tglcetakhasil,  " & _
                                        " DetailPemeriksaan , CASE WHEN c.JenisBayar = 'TAGIHAN' THEN c.NoJenisBayar WHEN c.JenisBayar <> 'TAGIHAN' THEN 'PASIEN UMUM' ELSE 'NOT FOUND' END AS 'NamaCompany' FROM TransaksiLab a " & _
                                        " LEFT JOIN MasterPasien b on a.IDInternet=b.NoRekamMedis  " & _
                                        " LEFT JOIN TransaksiLabBayar c on c.TransLabID=a.TransLabID  " & _
                                        " WHERE a.TransLabID = " & id & "")
        Dim Trow As DataRow = Tlab.Rows(0)

        If Tlab.Rows.Count > 0 Then
            If Trow("NamaCompany").ToString.Contains("-") Then
                Tcompany = Trow("NamaCompany").ToString
                Dim Tsplit() As String = Tcompany.Split("-")
                Tcompany = Tsplit(0).ToString.Trim.ToUpper
            Else
                Tcompany = Trow("NamaCompany").ToString.ToUpper
            End If

            If IsDBNull(Trow("tgllab")) = False Then TglLab = "" & Format(Trow("tgllab"), "yyyy-MM-dd HH:mm:ss") & "" Else TglLab = ""
            If IsDBNull(Trow("labdaftar")) = False Then LabDaftar = "" & Format(Trow("labdaftar"), "yyyy-MM-dd HH:mm:ss") & "" Else LabDaftar = ""
            If IsDBNull(Trow("labsamplingtime")) = False Then LabSamplingTime = "" & Format(Trow("labsamplingtime"), "yyyy-MM-dd HH:mm:ss") & "" Else LabSamplingTime = ""
            If IsDBNull(Trow("labstarttime")) = False Then LabStartTime = "" & Format(Trow("labstarttime"), "yyyy-MM-dd HH:mm:ss") & "" Else LabStartTime = ""
            If IsDBNull(Trow("tglinputhasil")) = False Then TglInputHasil = "" & Format(Trow("tglinputhasil"), "yyyy-MM-dd HH:mm:ss") & "" Else TglInputHasil = ""
            If IsDBNull(Trow("tglcetakhasil")) = False Then TglCetakHasil = "" & Format(Trow("tglcetakhasil"), "yyyy-MM-dd HH:mm:ss") & "" Else TglCetakHasil = ""

            If Trow("NoUrut").ToString.Contains("M") = True And IsDBNull(Trow("labsamplingtime")) = False Then
                TglLab = LabSamplingTime
                LabDaftar = LabSamplingTime
                LabStartTime = LabSamplingTime
            End If

            WriteThemysql("REPLACE INTO rekammedis (translabid, cabang, nourut, nama, tgllahir, alamat, company, idpasien, caraambil, statussoftcopy, statushardcopy, deleted, tgllab, labdaftar, labsamplingtime, labstarttime, tglinputhasil, tglcetakhasil, updated, tindakan)  " & _
                                      "VALUES('" & Trow("TransLabID") & "', '" & Tloc & "','" & Trow("NoUrut") & "','" & Trow("Nama") & "','" & Format(Trow("TglLahir"), "yyyy-MM-dd") & "','" & Trow("DomisiliAlamat") & "', '" & Tcompany & "','" & Trow("NoRekamMedis") & "','" & Trow("CaraAmbil") & "'," & Trow("StatusSoftcopy") & "," & Trow("StatusHardcopy") & "," & Trow("deleted") & ",  " & _
                                      "'" & TglLab & "','" & LabDaftar & "','" & LabSamplingTime & "','" & LabStartTime & "','" & TglInputHasil & "','" & TglCetakHasil & "',0, '" & pemeriksaan & "') ", Ttcmh)
        End If
    End Sub


    Private Sub sending_lab(ByVal id As String)
        Dim keyPT As Boolean = True
        Dim sending As Boolean = False

        If CheckSQL("select * FROM TransaksiLab WHERE TransLabID='" & id & "' and TglInputHasil is null") = True Then
            MsgBox("Input hasil terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Exit Sub
        End If

        Select Case MsgBox("Apakah anda ingin mengirim hasil ke Email/Whatsapp atas nama perusahaan aslinya atau tidak?", MsgBoxStyle.YesNoCancel, "Question.")
            Case MsgBoxResult.Yes
                keyPT = True
            Case MsgBoxResult.No
                keyPT = False
            Case MsgBoxResult.Cancel
                'GoTo NextStep
                MsgBox("Sending Cancel.", MsgBoxStyle.Exclamation, "Warning!")
                Exit Sub
        End Select

        Dim KodeBarcode As String = ReadSQLNIK("select StrValue FROM MsConfig WHERE ConfigName='KodeBarcode'")

        'SetClearGrid()
        Dim Tbls As DataTable = ReadSQL("select a.TransLabID,a.TransLabIDDetail,a.TindakanID,a.NamaTindakan,a.JenisTindakan,b.NoUrut,b.GroupID,b.DetailKet,b.Result,b.Satuan,b.Pria,b.Wanita,b.Keterangan,m.UrutanJenisID,a.Urutan, b.saran as 'Saran'  FROM transaksilabdetail a LEFT JOIN TransaksiLabResult b on a.TransLabIDDetail =b.TransLabIDDetail and a.TindakanID=b.TindakanID LEFT JOIN MasterJenisTindakan m on m.JenisTindakan=a.JenisTindakan WHERE a.TransLabID='" & id & "'  order by  m.UrutanJenisID,a.Urutan,b.TindakanID,b.NoUrut,a.TransLabIDDetail,a.TindakanID,b.GroupID,b.DetailKet")
        insertRowToTbls(Tbls, "typstring", "Registrasi")
        insertRowToTbls(Tbls, "typstring", "Hasil")
        insertRowToTbls(Tbls, "typstring", "Nama")
        insertRowToTbls(Tbls, "typstring", "Umur")
        insertRowToTbls(Tbls, "typstring", "Alamat")
        insertRowToTbls(Tbls, "typstring", "NoTransaksi")
        insertRowToTbls(Tbls, "typstring", "DrPelaksana")
        insertRowToTbls(Tbls, "typstring", "DrRequest")
        insertRowToTbls(Tbls, "typstring", "Standart P/W")
        insertRowToTbls(Tbls, "typstring", "Tanggal")
        insertRowToTbls(Tbls, "typstring", "barcodenotrans")
        insertRowToTbls(Tbls, "typstring", "KesimpulanAll")

        Dim Tlab As DataTable = ReadSQL("SELECT a.DokterRequest, convert(date, a.TglLab) as 'TglLab' ,convert(date, b.TglLahir) as 'TglLahir', b.DomisiliAlamat, b.JenisKelamin, a.NoUrut, b.Nama, a.Kesimpulan, a.Saran, b.NoNIK, a.caraambil, c.JenisBayar, c.NoJenisBayar FROM transaksilab a LEFT JOIN MasterPasien b ON a.IDInternet=b.NoRekamMedis LEFT JOIN TransaksiLabBayar c on a.TransLabID=c.TransLabID WHERE a.TransLabID='" & id & "'")
        Dim TrowLab As DataRow = Tlab.Rows(0)
        Dim Tsimpul As String = TrowLab("Kesimpulan")
        Dim Tsaran As String = TrowLab("Saran")
        Dim ptnik As String = ""
        If IsDBNull(TrowLab("NoNIK")) = False Then ptnik = TrowLab("NoNIK") Else ptnik = "-"
        Dim caraambil As String = TrowLab("caraambil")
        Tnourut = TrowLab("NoUrut")
        Dim Talamat As String = TrowLab("DomisiliAlamat").ToString
        Dim Tgelar As String = Gelar(Year(Now()) - Year(TrowLab("TglLahir")), TrowLab("JenisKelamin").ToString.Trim)

        For Each Trow As DataRow In Tbls.Rows
            Trow("Registrasi") = TrowLab("Nama").ToString.Trim
            Dim Turutan As String = Strings.Replace(Strings.Replace(Tnourut, "L", "8"), "M", "9")
            'Trow("barcodenotrans") = KodeBarcode & Strings.Right(Turutan, Len(Turutan) - 2)
            Trow("barcodenotrans") = id
            If (Tnourut.Contains("M")) Then
                If IsNumeric(Trow("Nama")) = True Then
                    Trow("Nama") = Tgelar & " " & TrowLab("Nama").ToString.Trim & "/(" & TrowLab("JenisKelamin").ToString.Trim & ")" & vbCrLf
                Else
                    Trow("Nama") = Tgelar & " " & TrowLab("Nama").ToString.Trim & " / " & ptnik & " (" & TrowLab("JenisKelamin").ToString.Trim & ")" & vbCrLf
                End If
            Else
                Trow("Nama") = Tgelar & " " & TrowLab("Nama").ToString.Trim & "/(" & TrowLab("JenisKelamin").ToString.Trim & ")" & vbCrLf
            End If

            Dim Tgltemp As Date = TrowLab("TglLahir")
            If Tgltemp.Date.AddYears(120).Year < DateAndTime.Now.Year Then
                Trow("Umur") = ""
            Else
                Trow("Umur") = Format(TrowLab("TglLahir"), "dd MMM yyyy") & " / " & Umur(TrowLab("TglLahir"))
            End If
            Trow("Alamat") = Talamat
            Trow("NoTransaksi") = Tnourut & " (" & id & ")"
            Trow("DrPelaksana") = ReadSQLNIK("select StrValue FROM MsConfig WHERE ConfigName='DokterPK'")
            Trow("Hasil") = caraambil
            If (Tnourut.Contains("M")) Then
                If keyPT = True Then
                    Dim Tsplit() As String = TrowLab("NoJenisBayar").ToString.Split("-")
                    Trow("DrRequest") = Tsplit(0).ToString.Trim
                Else
                    Trow("DrRequest") = "Atas Permintaan Sendiri"
                End If
            Else
                Trow("DrRequest") = ReadSQLNIK("select DrNama FROM MasterDokterKirim WHERE IdKirim in ( select IdKirim FROM MasterDokterTempatPraktek WHERE IdPraktek='" & TrowLab("DokterRequest") & "')")
            End If
            Trow("Tanggal") = Format(TrowLab("TglLab"), "dd-MMM-yyyy")
            Trow("Satuan") = Trow("Satuan").ToString
            Dim Tkriteria As String = ""
            If TrowLab("JenisKelamin").ToString.Trim = "L" Then
                'display hasil pria
                Tkriteria = Trow("Pria").ToString
            ElseIf TrowLab("JenisKelamin").ToString.Trim = "P" Then
                'display hasil wanita
                Tkriteria = Trow("Wanita").ToString
            Else
                MsgBox("Report Tidak bisa di-Display karena Jenis Kelamin tidak terdefinisi. Update Jenis Kelamin terlebih dahulu.")
                Exit Sub
            End If
            Trow("Standart P/W") = Tkriteria

            If Tsimpul <> "" And Tsaran <> "" Then
                Trow("KesimpulanAll") = "Catatan :" + vbCrLf + Tsimpul + vbCrLf + vbCrLf + "Saran :" + vbCrLf + Tsaran
            ElseIf Tsimpul <> "" Then
                Trow("KesimpulanAll") = "Catatan :" + vbCrLf + Tsimpul
            ElseIf Tsaran <> "" Then
                Trow("KesimpulanAll") = "Saran :" + vbCrLf + Tsaran
            End If
        Next

        Report = New XtraReport
        Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\Hasil\HasilLabKop.repx", True)
        Report.Bands.Item(BandKind.ReportFooter).Controls("ttd").Visible = True
        Report.Bands.Item(BandKind.ReportFooter).Controls("ttd").Height = 134
        Report.Bands.Item(BandKind.ReportFooter).Controls("ttd").Width = 250

        Report.DataSource = Tbls
        Report.Bands.Item(BandKind.PageFooter).Controls("lblsample").Text = ""
        Report.Bands.Item(BandKind.PageFooter).Controls("lblresult").Text = ""
        Report.Bands.Item(BandKind.PageFooter).Controls("lblprinted").Text = Format(DateAndTime.Now, "dd-MM-yyyy HH:mm:ss") + UserLabAdmin

        WriteSQL("update TransaksiLab set TglCetakHasil=getdate(), LabCetak=getdate() , [Status]='TAKEIT' , UserCetakHasil='" & UserLabAdmin & "' ,ClosedInputHasil=1 WHERE TransLabID='" & id & "'", 4)

        Dim NameFile As String = Tnourut & "_Hasil_Laboratorium"
        Dim filepath As String = "FileDownload\Hasil\" & NameFile & ".pdf"
        If File.Exists(filepath) Then
            My.Computer.FileSystem.DeleteFile("FileDownload\Hasil\" & NameFile & ".pdf")
        End If
        Report.CreatePdfDocument("FileDownload\Hasil\" & NameFile & ".pdf")

        Dim TboolEmail As Boolean = True
        Dim TboolWhatsapp As Boolean = True
        If Utility.GetConfig("Email") = "No" Then TboolEmail = False
        If Utility.GetConfig("Whatsapp") = "No" Then TboolWhatsapp = False

        If TboolEmail = True Or TboolWhatsapp = True Then
            If CheckSQL("select CaraAmbil FROM TransaksiLab WHERE NoUrut='" & Tnourut & "' and CaraAmbil like '%email%'") = True And TboolEmail = True Then
                'SENDING EMAIL
                Select Case MsgBox("Apakah data berikut sudah benar? " & vbCr & vbLf & vbCr & vbLf + "" & _
                          "Nama : " & TrowLab("Nama").ToString.Trim & "" & vbCr & vbLf + "" & _
                          "Alamat :  " & Talamat & "" & vbCr & vbLf + "" & _
                          "Tanggal Lahir : " & Format(TrowLab("TglLahir"), "dd MMM yyyy") & "", MsgBoxStyle.YesNo, "Verifikasi.")
                    Case MsgBoxResult.Yes
                        If CheckSQL("select * FROM TransaksiLab WHERE TransLabID = '" & id & "' and LabSendMail is not null") = True Then
                            If MsgBox("Hasil sudah pernah dikirim ke email tersebut, apakah tetap dilanjutkan?", MsgBoxStyle.YesNo, "Question.") = MsgBoxResult.No Then
                                MsgBox("Batal mengirimkan email.", MsgBoxStyle.Exclamation, "Warning!")
                                Exit Sub
                            End If
                        End If

                        thread = New System.Threading.Thread(AddressOf sendingemailcust)
                        thread.Start()

                        sending = True
                    Case MsgBoxResult.No
                        MsgBox("Cek data pasien kembali.", MsgBoxStyle.Exclamation, "Warning!")
                        Exit Sub
                End Select
            ElseIf CheckSQL("select CaraAmbil FROM TransaksiLab WHERE NoUrut='" & Tnourut & "' and CaraAmbil like '%whatsapp%'") = True And TboolWhatsapp = True Then
                'SENDING WHATSAPP
                Select Case MsgBox("Apakah data berikut sudah benar? " & vbCr & vbLf & vbCr & vbLf + "" & _
                          "Nama : " & TrowLab("Nama").ToString.Trim & "" & vbCr & vbLf + "" & _
                          "Alamat :  " & Talamat & "" & vbCr & vbLf + "" & _
                          "Tanggal Lahir : " & Format(TrowLab("TglLahir"), "dd MMM yyyy") & "", MsgBoxStyle.YesNo, "Verifikasi.")
                    Case MsgBoxResult.Yes
                        If CheckSQL("select * FROM TransaksiLab WHERE TransLabID = '" & id & "' and LabSendMail is not null") = True Then
                            If MsgBox("Hasil sudah pernah dikirim ke whatsapp tersebut, apakah tetap dilanjutkan?", MsgBoxStyle.YesNo, "Question.") = MsgBoxResult.No Then
                                MsgBox("Batal mengirimkan email.", MsgBoxStyle.Exclamation, "Warning!")
                                Exit Sub
                            End If
                        End If

                        thread = New System.Threading.Thread(AddressOf sendingwhatsappcust)
                        thread.Start()

                        sending = True
                    Case MsgBoxResult.No
                        MsgBox("Cek data pasien kembali.", MsgBoxStyle.Exclamation, "Warning!")
                        Exit Sub
                End Select
            End If

            'SENDING WHATSAPP KE COMPANY
            'Dim NoUrut As String = Tnourut
            Dim company As String = ReadSQLNIK("select NoJenisBayar FROM transaksilabbayar WHERE translabid in (select translabid FROM TransaksiLab WHERE NoUrut='" & Tnourut & "')")
            Dim Tsplit() As String = company.ToString.Split("-")
            Dim Tcompany As DataTable = ReadSQL("select No_Handphone2, No_Handphone, Email_Perusahaan, TerimaHasilKaryawan, Whatsapp_Auto, Email_Auto FROM MasterCompany WHERE NoCompany='" & Tsplit(1).ToString.Trim & "'")
            If Tcompany.Rows.Count > 0 Then
                Dim TrowCompany As DataRow = Tcompany.Rows(0)
                If (TrowCompany("TerimaHasilKaryawan") = True And TrowCompany("Whatsapp_Auto") = True And Tnourut.Contains("L") = True) Or (TrowCompany("Whatsapp_Auto") = True And Tnourut.Contains("M") = True) Then
                    If MsgBox("Apakah anda ingin mengirim hasil ke Whatsapp perusahaan?", MsgBoxStyle.YesNo, "Question.") = MsgBoxResult.Yes Then
                        NoWhatsappCompany = TrowCompany("No_Handphone")
                        thread = New System.Threading.Thread(AddressOf sendingwhatsappcompany)
                        thread.Start()

                        sending = True
                    End If
                ElseIf (TrowCompany("TerimaHasilKaryawan") = True And TrowCompany("Email_Auto") = True And Tnourut.Contains("L") = True) Or (TrowCompany("Email_Auto") = True And Tnourut.Contains("M") = True) Then
                    If MsgBox("Apakah anda ingin mengirim hasil ke Email perusahaan?", MsgBoxStyle.YesNo, "Question.") = MsgBoxResult.Yes Then
                        EmailCompany = TrowCompany("Email_Perusahaan")
                        thread = New System.Threading.Thread(AddressOf sendingemailcompany)
                        thread.Start()

                        sending = True
                    End If
                End If

                If TrowCompany("No_Handphone2").ToString.Trim <> "" And TrowCompany("No_Handphone2").ToString.Trim <> "0" And TrowCompany("No_Handphone2").ToString.Trim <> "-" Then
                    If MsgBox("Apakah anda ingin mengirim hasil ke Whatsapp Marketing?", MsgBoxStyle.YesNo, "Question.") = MsgBoxResult.Yes Then
                        NoWhatsappMarketing = TrowCompany("No_Handphone2")
                        thread = New System.Threading.Thread(AddressOf sendingwhatsappmarketing)
                        thread.Start()

                        sending = True
                    End If
                End If
            End If

            If sending = False Then
                MsgBox("Tidak ada Email atau Whatsapp yang dikirimkan.", MsgBoxStyle.Exclamation, "Warning!")
            End If
            'NextStep:
        End If
    End Sub

    Public Sub sendingwhatsappcompany()
        Try
            Dim NoWhatsapp As String = NoWhatsappCompany
            If Strings.Left(NoWhatsapp, 2) = "08" Then
                NoWhatsapp = "62" & NoWhatsapp.Substring(1, NoWhatsapp.Length - 1)
            End If
            Dim TIP_Whatsapp = ReadSQLNIK("select StrValue FROM MsConfig WHERE ConfigName='TIP_Whatsapp'")
            Dim TxPDF As String = Convert.ToBase64String(System.IO.File.ReadAllBytes("FileDownload\Hasil\" & Tnourut & "_Hasil_Laboratorium" & ".pdf"))
            Dim filename As String = Tnourut & "_Hasil_Laboratorium.pdf"
            Dim message_whatsapp As String = ""
            Dim parameter As String = "{" & _
              """number"" : """ & NoWhatsapp & """," & _
              """mime"" : ""application/pdf""," & _
              """src"" : """ & TxPDF & """," & _
              """filename"" : """ & filename & """," & _
              """caption"" : """"," & _
              """thumbnail"" : """"," & _
              """message"" : """ & message_whatsapp & """" & _
             "}"

            Dim bytearr() As Byte = Encoding.UTF8.GetBytes(parameter)
            Dim uri As String = "http://" & TIP_Whatsapp & ":4444/send-pdf"
            Dim uri_message As String = "http://" & TIP_Whatsapp & ":4444/send"
            Dim str As String = ""

            Dim webreq As HttpWebRequest = WebRequest.Create(uri)
            webreq.Accept = "application/json"

            webreq.Method = "POST"
            webreq.ContentType = "application/json"
            webreq.ContentLength = bytearr.Length

            Dim dataStream As Stream = webreq.GetRequestStream()
            dataStream.Write(bytearr, 0, bytearr.Length)
            dataStream.Close()

            Dim res As WebResponse = webreq.GetResponse()
            Dim stream As Stream = res.GetResponseStream()
            Dim streamReader As New StreamReader(stream)

            'READ RESPONSE
            str = streamReader.ReadToEnd
            streamReader.Close()

            Dim var As String = SendDataWhatsapp(parameter, uri_message)

            If var = "Success" Then
                MsgBox("Berhasil mengirim Whatsapp ke " & NoWhatsapp.Trim & ".", MsgBoxStyle.Information, "Success!")
                WriteSQL("update transaksilab set LabSendMail=getdate() WHERE nourut='" & Tnourut & "'", 4)
                WriteSQL("insert into LogSendingWhatsappEmail (SendingJenis, SendingTujuan, SendingNamaFile, SendingStatus, SendingDate, SendingBy, NoUrut, JenisSending) values ('Whatsapp', '" & NoWhatsapp & "', '" & Tnourut & "_Hasil_Laboratorium" & "', 1, GETDATE(), '" & UserLabAdmin & "', '" & Tnourut & "', 'COMPANY')", 4)
            Else
                MsgBox("Gagal.", MsgBoxStyle.Critical, "Error!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub sendingwhatsappmarketing()
        Try
            Dim NoWhatsapp As String = NoWhatsappMarketing
            If Strings.Left(NoWhatsapp, 2) = "08" Then
                NoWhatsapp = "62" & NoWhatsapp.Substring(1, NoWhatsapp.Length - 1)
            End If
            Dim TIP_Whatsapp = ReadSQLNIK("select StrValue FROM MsConfig WHERE ConfigName='TIP_Whatsapp'")
            Dim TxPDF As String = Convert.ToBase64String(System.IO.File.ReadAllBytes("FileDownload\Hasil\" & Tnourut & "_Hasil_Laboratorium" & ".pdf"))
            Dim filename As String = Tnourut & "_Hasil_Laboratorium.pdf"
            Dim message_whatsapp As String = ""
            Dim parameter As String = "{" & _
              """number"" : """ & NoWhatsapp & """," & _
              """mime"" : ""application/pdf""," & _
              """src"" : """ & TxPDF & """," & _
              """filename"" : """ & filename & """," & _
              """caption"" : """"," & _
              """thumbnail"" : """"," & _
              """message"" : """ & message_whatsapp & """" & _
             "}"

            Dim bytearr() As Byte = Encoding.UTF8.GetBytes(parameter)
            Dim uri As String = "http://" & TIP_Whatsapp & ":4444/send-pdf"
            Dim uri_message As String = "http://" & TIP_Whatsapp & ":4444/send"
            Dim str As String = ""

            Dim webreq As HttpWebRequest = WebRequest.Create(uri)
            webreq.Accept = "application/json"

            webreq.Method = "POST"
            webreq.ContentType = "application/json"
            webreq.ContentLength = bytearr.Length

            Dim dataStream As Stream = webreq.GetRequestStream()
            dataStream.Write(bytearr, 0, bytearr.Length)
            dataStream.Close()

            Dim res As WebResponse = webreq.GetResponse()
            Dim stream As Stream = res.GetResponseStream()
            Dim streamReader As New StreamReader(stream)

            'READ RESPONSE
            str = streamReader.ReadToEnd
            streamReader.Close()

            Dim var As String = SendDataWhatsapp(parameter, uri_message)

            If var = "Success" Then
                MsgBox("Berhasil mengirim Whatsapp ke " & NoWhatsapp.Trim & ".", MsgBoxStyle.Information, "Success!")
                WriteSQL("update transaksilab set LabSendMail=getdate() WHERE nourut='" & Tnourut & "'", 4)
                WriteSQL("insert into LogSendingWhatsappEmail (SendingJenis, SendingTujuan, SendingNamaFile, SendingStatus, SendingDate, SendingBy, NoUrut, JenisSending) values ('Whatsapp', '" & NoWhatsapp & "', '" & Tnourut & "_Hasil_Laboratorium" & "', 1, GETDATE(), '" & UserLabAdmin & "', '" & Tnourut & "', 'MARKETING')", 4)
            Else
                MsgBox("Gagal.", MsgBoxStyle.Critical, "Error!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub sendingwhatsappcust()
        Try
            Dim NoWhatsapp As String = ReadSQLNIK("select tlp FROM MasterPasien WHERE NoRekamMedis in (select IDInternet FROM TransaksiLab WHERE NoUrut='" & Tnourut & "')")
            If Strings.Left(NoWhatsapp, 2) = "08" Then
                NoWhatsapp = "62" & NoWhatsapp.Substring(1, NoWhatsapp.Length - 1)
            End If
            Dim TIP_Whatsapp = ReadSQLNIK("select StrValue FROM MsConfig WHERE ConfigName='TIP_Whatsapp'")
            Dim TxPDF As String = Convert.ToBase64String(System.IO.File.ReadAllBytes("FileDownload\Hasil\" & Tnourut & "_Hasil_Laboratorium" & ".pdf"))
            Dim filename As String = Tnourut & "_Hasil_Laboratorium.pdf"
            Dim message_whatsapp As String = "Kepada Yth.\n" & _
              "Customer Cahaya Diagnostic Centre\n\n" & _
              "Kami mengucapkan terima kasih atas kepercayaan Bapak/Ibu/Saudara/i sudah melakukan pemeriksaan di Laboratorium Cahaya Diagnostic Centre. Berikut ini kami lampirkan hasil pemeriksaan laboratorium anda.\n\n" & _
              "Silahkan menghubungi kami di nomor 081230885004 (WA/Phone) atau email ke cahayadiagnosticcentre@gmail.com untuk konsultasi lebih lanjut.\n\n" & _
              "Kami menyampaikan beberapa hal yang perlu diperhatikan oleh saudara/i, antara lain:\n" & _
              "1. Tetap menjaga jarak dengan orang lain (Physical Distancing).\n" & _
              "2. Selalu menggunakan masker saat keluar dari rumah.\n" & _
              "3. Rajin mencuci & menjaga kebersihan tangan.\n" & _
              "4. Makan makanan yang bergizi & bila perlu minum suplemen atau vitamin.\n" & _
              "5. Etika batuk yang baik & benar.\n\n" & _
              "Best regards,\n\n" & _
              "Laboratorium Cahaya Diagnostic Centre."
            Dim parameter As String = "{" & _
              """number"" : """ & NoWhatsapp & """," & _
              """mime"" : ""application/pdf""," & _
              """src"" : """ & TxPDF & """," & _
              """filename"" : """ & filename & """," & _
              """caption"" : """"," & _
              """thumbnail"" : """"," & _
              """message"" : """ & message_whatsapp & """" & _
             "}"

            Dim bytearr() As Byte = Encoding.UTF8.GetBytes(parameter)
            Dim uri As String = "http://" & TIP_Whatsapp & ":4444/send-pdf"
            Dim uri_message As String = "http://" & TIP_Whatsapp & ":4444/send"
            Dim str As String = ""

            Dim webreq As HttpWebRequest = WebRequest.Create(uri)
            webreq.Accept = "application/json"

            webreq.Method = "POST"
            webreq.ContentType = "application/json"
            webreq.ContentLength = bytearr.Length

            Dim dataStream As Stream = webreq.GetRequestStream()
            dataStream.Write(bytearr, 0, bytearr.Length)
            dataStream.Close()

            Dim res As WebResponse = webreq.GetResponse()
            Dim stream As Stream = res.GetResponseStream()
            Dim streamReader As New StreamReader(stream)

            'READ RESPONSE
            str = streamReader.ReadToEnd
            streamReader.Close()

            Dim var As String = SendDataWhatsapp(parameter, uri_message)

            If var = "Success" Then
                MsgBox("Berhasil mengirim Whatsapp ke " & NoWhatsapp.Trim & ".", MsgBoxStyle.Information, "Success!")
                WriteSQL("update transaksilab set LabSendMail=getdate() WHERE nourut='" & Tnourut & "'", 4)
                WriteSQL("insert into LogSendingWhatsappEmail (SendingJenis, SendingTujuan, SendingNamaFile, SendingStatus, SendingDate, SendingBy, NoUrut, JenisSending) values ('Whatsapp', '" & NoWhatsapp & "', '" & Tnourut & "_Hasil_Laboratorium" & "', 1, GETDATE(), '" & UserLabAdmin & "', '" & Tnourut & "', 'PASIEN')", 4)
            Else
                MsgBox("Gagal.", MsgBoxStyle.Critical, "Error!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub sendingemailcust()
        Try
            Dim email As String = ReadSQLNIK("select email FROM MasterPasien WHERE NoRekamMedis in (select IDInternet FROM TransaksiLab WHERE NoUrut='" & Tnourut & "')")
            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential("info@cahayamedika.co.id", "cahayamedika2020!")
            Smtp_Server.Port = 587
            Smtp_Server.EnableSsl = True
            Smtp_Server.Host = "smtp.gmail.com"

            e_mail = New MailMessage()
            e_mail.From = New MailAddress("info@cahayamedika.co.id")
            e_mail.To.Add("" & email.Trim & "")
            e_mail.Subject = "Hasil Laboratorium (" & Tnourut & ")"
            e_mail.IsBodyHtml = False
            e_mail.Body = "Kepada Yth." & vbCr & vbLf + "" & _
              "Customer Cahaya Diagnostic Centre" & vbCr & vbLf & vbCr & vbLf + "" & _
              "Kami mengucapkan terima kasih atas kepercayaan Bapak/Ibu/Saudara/i sudah melakukan pemeriksaan di Laboratorium Cahaya Diagnostic Centre. Berikut ini kami lampirkan hasil pemeriksaan laboratorium anda." & vbCr & vbLf & vbCr & vbLf + "" & _
              "Silahkan menghubungi kami di nomor 081230885004 (WA/Phone) atau email ke cahayadiagnosticcentre@gmail.com untuk konsultasi lebih lanjut." & vbCr & vbLf & vbCr & vbLf + "" & _
              "Kami menyampaikan beberapa hal yang perlu diperhatikan oleh saudara/i, antara lain:" & vbCr & vbLf + "" & _
              "1. Tetap menjaga jarak dengan orang lain (Physical Distancing)." & vbCr & vbLf + "" & _
              "2. Selalu menggunakan masker saat keluar dari rumah." & vbCr & vbLf + "" & _
              "3. Rajin mencuci & menjaga kebersihan tangan." & vbCr & vbLf + "" & _
              "4. Makan makanan yang bergizi & bila perlu minum suplemen atau vitamin." & vbCr & vbLf + "" & _
              "5. Etika batuk yang baik & benar." & vbCr & vbLf & vbCr & vbLf + "" & _
              "Best regards," & vbCr & vbLf & vbCr & vbLf + "" & _
              "Laboratorium Cahaya Diagnostic Centre."
            e_mail.Attachments.Add(New Attachment("FileDownload\Hasil\" & Tnourut & "_Hasil_Laboratorium" & ".pdf"))
            Smtp_Server.Send(e_mail)

            MsgBox("Berhasil mengirim email ke " & email.Trim & ".", MsgBoxStyle.Information, "Success!")
            WriteSQL("update transaksilab set LabSendMail=getdate() WHERE nourut='" & Tnourut & "'", 4)
            WriteSQL("insert into LogSendingWhatsappEmail (SendingJenis, SendingTujuan, SendingNamaFile, SendingStatus, SendingDate, SendingBy, NoUrut, JenisSending) values ('Email', '" & email & "', '" & Tnourut & "_Hasil_Laboratorium" & "', 1, GETDATE(), '" & UserLabAdmin & "', '" & Tnourut & "', 'PASIEN')", 4)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub sendingemailcompany()
        Try
            Dim email As String = EmailCompany
            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential("info@cahayamedika.co.id", "cahayamedika2020!")
            Smtp_Server.Port = 587
            Smtp_Server.EnableSsl = True
            Smtp_Server.Host = "smtp.gmail.com"

            e_mail = New MailMessage()
            e_mail.From = New MailAddress("info@cahayamedika.co.id")
            e_mail.To.Add("" & email.Trim & "")
            e_mail.Subject = "Hasil Laboratorium (" & Tnourut & ")"
            e_mail.IsBodyHtml = False
            e_mail.Body = "Kepada Yth." & vbCr & vbLf + "" & _
              "Customer Cahaya Diagnostic Centre" & vbCr & vbLf & vbCr & vbLf + "" & _
              "Kami mengucapkan terima kasih atas kepercayaan Bapak/Ibu/Saudara/i sudah melakukan pemeriksaan di Laboratorium Cahaya Diagnostic Centre. Berikut ini kami lampirkan hasil pemeriksaan laboratorium anda." & vbCr & vbLf & vbCr & vbLf + "" & _
              "Silahkan menghubungi kami di nomor 081230885004 (WA/Phone) atau email ke cahayadiagnosticcentre@gmail.com untuk konsultasi lebih lanjut." & vbCr & vbLf & vbCr & vbLf + "" & _
              "Kami menyampaikan beberapa hal yang perlu diperhatikan oleh saudara/i, antara lain:" & vbCr & vbLf + "" & _
              "1. Tetap menjaga jarak dengan orang lain (Physical Distancing)." & vbCr & vbLf + "" & _
              "2. Selalu menggunakan masker saat keluar dari rumah." & vbCr & vbLf + "" & _
              "3. Rajin mencuci & menjaga kebersihan tangan." & vbCr & vbLf + "" & _
              "4. Makan makanan yang bergizi & bila perlu minum suplemen atau vitamin." & vbCr & vbLf + "" & _
              "5. Etika batuk yang baik & benar." & vbCr & vbLf & vbCr & vbLf + "" & _
              "Best regards," & vbCr & vbLf & vbCr & vbLf + "" & _
              "Laboratorium Cahaya Diagnostic Centre."
            e_mail.Attachments.Add(New Attachment("FileDownload\Hasil\" & Tnourut & "_Hasil_Laboratorium" & ".pdf"))
            Smtp_Server.Send(e_mail)

            MsgBox("Berhasil mengirim email ke " & email.Trim & ".", MsgBoxStyle.Information, "Success!")
            WriteSQL("update transaksilab set LabSendMail=getdate() WHERE nourut='" & Tnourut & "'", 4)
            WriteSQL("insert into LogSendingWhatsappEmail (SendingJenis, SendingTujuan, SendingNamaFile, SendingStatus, SendingDate, SendingBy, NoUrut, JenisSending) values ('Email', '" & email & "', '" & Tnourut & "_Hasil_Laboratorium" & "', 1, GETDATE(), '" & UserLabAdmin & "', '" & Tnourut & "', 'COMPANY')", 4)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ClearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearToolStripMenuItem.Click
        SetClear()
    End Sub
End Class