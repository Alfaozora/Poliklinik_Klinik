Imports System.Globalization
Imports MySql.Data.MySqlClient
Imports System.Text

Public Class FormKirimLaporanOmset
    Dim thread As System.Threading.Thread

    ' Set Variabel Private
    Private NoPoli As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NoPoli'")
    Private AutoJurnal As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'AutoJurnal'")
    Private userInput As String = PoliKlinik.Lbluser.Text

    ' Set Connection
    Private DB_Keuangan As TLcon
    Private DB_Keuangan2 As TLcon
    Private DB_Jurnal As TLcon

    Private Sub SetConnectionFromConfig()
        ' Set Parameter Server Online
        Dim serverOnline_IP As String = Utility.GetConfig("ServerOnline_IP")
        Dim serverOnline_UserID As String = Utility.GetConfig("ServerOnline_UserID")
        Dim serverOnline_Password As String = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerOnline_Password"), "albert")

        ' Set DB Keuangan 1 (mitramed_keu)
        DB_Keuangan.Tip = serverOnline_IP
        DB_Keuangan.Tid = serverOnline_UserID
        DB_Keuangan.Tpass = serverOnline_Password
        DB_Keuangan.Tdb = Utility.GetConfig("ServerOnlineKeuangan_DB")

        ' Set DB Keuangan 2 (mitramed_keu2019)
        DB_Keuangan2.Tip = serverOnline_IP
        DB_Keuangan2.Tid = serverOnline_UserID
        DB_Keuangan2.Tpass = serverOnline_Password
        DB_Keuangan2.Tdb = Utility.GetConfig("ServerOnlineKeuangan2_DB")

        ' Set DB Jurnal
        DB_Jurnal.Tip = Utility.GetConfig("ServerJurnal_IP")
        DB_Jurnal.Tid = Utility.GetConfig("ServerJurnal_UserID")
        DB_Jurnal.Tpass = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerJurnal_Password"), "albert")
        DB_Jurnal.Tdb = Utility.GetConfig("ServerJurnal_DB")
    End Sub

    Function CreateTable() As DataTable
        Dim Thasil As DataTable = ReadSQL("SELECT a.TransPoliID AS ID, a.NoUrut, a.TglPoli AS Tgl, b.NoRekamMedis, b.Nama AS Pasien, a.TotalTagihan, a.TotalDisc, a.Pembulatan, a.NettBayar, a.TotalBayar, a.Pengembalian " & _
                                          "FROM TransaksiPoli a " & _
                                          "LEFT JOIN MasterPasien b ON a.IDInternet=b.NoRekamMedis " & _
                                          "WHERE CONVERT(date, TglPoli) BETWEEN '8/15/2016' AND GETDATE()AND TransPoliID=''")

        insertRowToTbls(Thasil, "Typstring", "Jenis Poli")
        insertRowToTbls(Thasil, "tyinterger", "Tunai")
        insertRowToTbls(Thasil, "tyinterger", "Debet")
        insertRowToTbls(Thasil, "tyinterger", "Kredit")
        insertRowToTbls(Thasil, "tyinterger", "Disc")
        insertRowToTbls(Thasil, "tyinterger", "Tagihan")
        insertRowToTbls(Thasil, "Typstring", "RecTagihan")
        insertRowToTbls(Thasil, "Typstring", "Adm")
        insertRowToTbls(Thasil, "Typstring", "JenisPasien")
        insertRowToTbls(Thasil, "Typstring", "JenisKartu")
        insertRowToTbls(Thasil, "Typstring", "JenisMesin")

        For Each Tcol As DataColumn In Thasil.Columns
            Tcol.ReadOnly = True
        Next

        Return Thasil
    End Function

    Private Sub KirimOmsetHarian()
        If GridView1.RowCount = 0 And GridView2.RowCount = 0 And GridView3.RowCount = 0 And GridView4.RowCount = 0 Then
            MsgBox("Tidak ada data yang ditampilkan.", MsgBoxStyle.Critical, "Warning!")
        Else
            If CheckThemysql("SELECT * FROM acctranspendapatandetail WHERE DATE(inctgl)='" & Format(DateTimePickerTanggalTransaksi.Value, "yyyyMMdd") & "' AND loc = '" & NoPoli & "'", DB_Keuangan) = False And CheckThemysql("SELECT * FROM acctranstagihandetail WHERE date(inctgl)='" & Format(DateTimePickerTanggalTransaksi.Value, "yyyyMMdd") & "' AND loc = '" & NoPoli & "'", DB_Keuangan) = False Then
                ' Post Data ke Keuangan
                SendData()

                ' Post Data Jurnal
                If AutoJurnal.Trim = "Yes" Then SendingJurnal()

                ButtonKirimDataOmset.Enabled = False
            Else
                If MsgBox("Yakin untuk send ulang data Penerimaan yang belum dikirim ?", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                    ' Post Data ke Keuangan
                    SendData()

                    ' Post Data Jurnal
                    If AutoJurnal.Trim = "Yes" Then SendingJurnal()

                    ButtonKirimDataOmset.Enabled = False
                Else
                    MsgBox("Batal send data")
                End If
            End If
        End If
    End Sub

    Private Sub SendData()
        ProgressBar1.Visible = True
        lblProgressBar.Visible = True

        Dim T As Integer
        Try
            ProgressBar1.Visible = True
            T = 0
            lblProgressBar.Text = "Loading Upload Poli (1/4)"
            If GridView1.RowCount > 0 Then InsertOL(gridpoli.DataSource, "POLI")
            ProgressBar1.Value = 100
            T = 1
            lblProgressBar.Text = "Loading Upload Lab (2/4)"
            If GridView2.RowCount > 0 Then InsertOL(gridlab.DataSource, "LAB")
            ProgressBar1.Value = 100
            T = 2
            lblProgressBar.Text = "Loading Upload Gigi (3/4)"
            If GridView3.RowCount > 0 Then InsertOL(gridgigi.DataSource, "GIGI")
            ProgressBar1.Value = 100
            T = 3
            lblProgressBar.Text = "Loading Upload Dll (4/4)"
            If GridView4.RowCount > 0 Then InsertOL(griddll.DataSource, "DLL")
            ProgressBar1.Value = 100
            MsgBox("Data Saved.", MsgBoxStyle.Information, "Success!")

        Catch ex As Exception
            Dim Terr As String = ""
            If T = 0 Then
                Terr = " Upload berhenti dari awal. Check problem data. Dan ulangi send."
            ElseIf T = 1 Then
                Terr = " Upload Poli berhasil. Berhenti di Lab. Check problem data dan ulangi send."
            ElseIf T = 2 Then
                Terr = " Upload Poli,Lab berhasil. Berhenti di Gigi. Check problem data dan ulangi send."
            ElseIf T = 3 Then
                Terr = " Upload Poli,Lab,Gigi berhasil. Berhenti di Dll. Check problem data dan ulangi send."
            Else
                Terr = " Upload Berhenti. Tidak terdefinisi. Check problem data dan ulangi send."
            End If
            MsgBox(ex.Message & "." & vbCrLf & Terr)
        End Try
        ProgressBar1.Visible = False
        lblProgressBar.Visible = False
    End Sub

    Private Sub InsertOL(ByRef Tdata As DataTable, ByRef Tjenis As String)
        Dim queryStringRekap As String = ""
        Dim persen As Integer = 0
        Dim procent As Integer = 0

        ' Set Data Pasien Umum
        Dim rowPasienUmum As Integer = 0
        Dim queryStringUmum As New StringBuilder()
        queryStringUmum.AppendLine("INSERT INTO acctranspendapatandetail (inctgl, loc, incjenis, jenis, kartu, mesin, incnilai, createdate, inctransid, idinternet, pasien, no_transaksi, jenis_poli) VALUES ")

        ' Set Data Pasien Tagihan
        Dim rowPasienTagihan As Integer = 0
        Dim queryStringTagihan As New StringBuilder()
        queryStringTagihan.AppendLine("INSERT INTO acctranstagihandetail(inctgl, loc, incjenis, jenis, kartu, mesin, incnilai, createdate, inctransid, idinternet, pasien, rekapid, lockeddate, lockedby, no_transaksi, jenis_poli) VALUES ")

        ' Set Data No Transaksi
        Dim noTransaksiPoli As String = ""
        Dim noTransaksiGigi As String = ""
        Dim noTransaksiLab As String = ""
        Dim rowPasienPoli As Integer = 0
        Dim rowPasienGigi As Integer = 0
        Dim rowPasienLab As Integer = 0

        For Each Trow As DataRow In Tdata.Rows
            persen = persen + 1
            procent = persen * 100 / Tdata.Rows.Count
            ProgressBar1.Value = procent

            ' Set Variabel Input Data
            Dim tglSekarang As String = Format(DateAndTime.Now, "yyyy-MM-dd")
            Dim tglPeriksa As String = ""
            Dim jenisKartu As String = ""
            Dim jenisMesin As String = ""
            Dim idTransaksi As String = ""
            Dim noRekamMedis As String = ""
            Dim namaPasien As String = ""
            Dim noTransaksi As String = ""
            Dim jenisPoli As String = ""

            If IsDBNull(Trow("Tgl")) = False Then tglPeriksa = Format(Trow("Tgl"), "yyyy-MM-dd")
            If IsDBNull(Trow("JenisKartu")) = False Then jenisKartu = Trow("JenisKartu")
            If IsDBNull(Trow("JenisMesin")) = False Then jenisMesin = Trow("JenisMesin")
            If IsDBNull(Trow("ID")) = False Then idTransaksi = Trow("ID")
            If IsDBNull(Trow("NoRekamMedis")) = False Then noRekamMedis = Trow("NoRekamMedis")
            If IsDBNull(Trow("Pasien")) = False Then namaPasien = Trow("Pasien").ToString.Replace("'", "''")
            If IsDBNull(Trow("NoUrut")) = False Then noTransaksi = Trow("NoUrut")
            If IsDBNull(Trow("Jenis Poli")) = False Then jenisPoli = Trow("Jenis Poli")

            Dim Tnilai As Integer = 0
            Dim JenisBayar As String = ""
            If Trow("Tunai") > 0 Then
                Tnilai = Trow("Tunai")
                JenisBayar = "Tunai"
            ElseIf Trow("Debet") > 0 Then
                Tnilai = Trow("Debet")
                JenisBayar = "Debet"
            ElseIf Trow("Kredit") > 0 Then
                Tnilai = Trow("Kredit")
                JenisBayar = "Kredit"
            ElseIf Trow("Tagihan") > 0 Or Trow("JenisPasien").ToString.Contains("BPJS") = True Then
                Tnilai = Trow("Tagihan")
                JenisBayar = "Tagihan"
            ElseIf Trow("Disc") > 0 Then
                Tnilai = Trow("Disc")
                JenisBayar = "Disc"
            End If

            If JenisBayar = "Tagihan" Then
                Dim T1, T2 As String
                If Trow("JenisPasien").ToString.Contains("-") = True Then
                    Dim Tspare() As String = Trow("JenisPasien").ToString.Split("-")
                    T1 = Tspare(0)
                    T2 = Tspare(1)
                Else
                    T1 = Trow("JenisPasien")
                    T2 = ""
                End If

                If CheckThemysql("SELECT * FROM acctranstagihandetail WHERE date(inctgl)='" & Format(Trow("Tgl"), "yyyyMMdd") & "' and loc='" & NoPoli & "' and incjenis='" & Tjenis & "' and jenis='" & JenisBayar & "' and kartu='" & T1 & "' and mesin='" & T2 & "' and incnilai='" & Tnilai & "' and no_transaksi='" & Trow("NoUrut") & "' and idinternet='" & Trow("NoRekamMedis") & "'", DB_Keuangan) = False Then
                    Dim TblsRekap As New DataTable
                    If Tjenis = "LAB" Then
                        queryStringRekap = "SELECT a.RekapID, b.CreateDate, b.createby FROM transaksilab a LEFT JOIN RekapTagihan b on a.RekapID=b.RekapID WHERE a.translabid='" & Trow("ID") & "'"
                    ElseIf Tjenis = "POLI" Then
                        queryStringRekap = "SELECT a.RekapID, b.CreateDate, b.createby FROM TransaksiPoli a LEFT JOIN RekapTagihan b on a.RekapID=b.RekapID WHERE a.TransPoliID='" & Trow("ID") & "'"
                    ElseIf Tjenis = "GIGI" Then
                        queryStringRekap = "SELECT a.RekapID, b.CreateDate, b.createby FROM TransaksiGigi a LEFT JOIN RekapTagihan b on a.RekapID=b.RekapID WHERE a.TransGigiID='" & Trow("ID") & "'"
                    ElseIf Tjenis = "DLL" Then
                        queryStringRekap = "SELECT a.RekapID, b.CreateDate, b.createby FROM TransaksiAdmin a LEFT JOIN RekapTagihan b on a.RekapID=b.RekapID WHERE a.TransAdminID='" & Trow("ID") & "'"
                    End If

                    TblsRekap = ReadSQL(queryStringRekap)

                    For Each TrowRekap As DataRow In TblsRekap.Rows
                        Dim idRekap As String = "NULL"
                        Dim tglRekap As String = "9998-12-31 00:00:00"
                        Dim namaUserRekap As String = ""

                        If IsDBNull(TrowRekap("RekapID")) = False Then idRekap = TrowRekap("RekapID")
                        If IsDBNull(TrowRekap("CreateDate")) = False Then tglRekap = Format(TrowRekap("CreateDate"), "yyyy-MM-dd HH:mm:ss")
                        If IsDBNull(TrowRekap("CreateBy")) = False Then namaUserRekap = TrowRekap("CreateBy")

                        queryStringTagihan.AppendLine("('" & tglPeriksa & "','" & NoPoli & "','" & Tjenis & "','" & JenisBayar & "','" & T1 & "','" & T2 & "','" & Tnilai & "','" & tglSekarang & "','" & idTransaksi & "','" & noRekamMedis & "','" & namaPasien & "', " & idRekap & ", '" & tglRekap & "', '" & namaUserRekap & "', '" & noTransaksi & "', '" & jenisPoli & "'),")
                        rowPasienTagihan += 1
                    Next
                End If
            Else
                If CheckThemysql("SELECT * FROM acctranspendapatandetail WHERE date(inctgl)='" & Format(Trow("Tgl"), "yyyyMMdd") & "' and loc='" & NoPoli & "' and incjenis='" & Tjenis & "' and jenis='" & JenisBayar & "' and kartu='" & Trow("JenisKartu") & "' and mesin='" & Trow("JenisMesin") & "' and incnilai='" & Tnilai & "' and no_transaksi='" & Trow("NoUrut") & "' and idinternet='" & Trow("NoRekamMedis") & "'", DB_Keuangan) = False Then
                    queryStringUmum.AppendLine("('" & tglPeriksa & "','" & NoPoli & "','" & Tjenis & "','" & JenisBayar & "','" & jenisKartu & "','" & jenisMesin & "','" & Tnilai & "','" & tglSekarang & "','" & idTransaksi & "','" & noRekamMedis & "','" & namaPasien & "', '" & noTransaksi & "', '" & jenisPoli & "'),")
                    rowPasienUmum += 1
                End If
            End If

            Select Case Tjenis
                Case "POLI"
                    noTransaksiPoli = noTransaksiPoli & "'" & Trow("ID").ToString & "',"
                    rowPasienPoli += 1
                Case "LAB"
                    noTransaksiLab = noTransaksiLab & "'" & Trow("ID").ToString & "',"
                    rowPasienLab += 1
                Case "GIGI"
                    noTransaksiGigi = noTransaksiGigi & "'" & Trow("ID").ToString & "',"
                    rowPasienGigi += 1
            End Select
        Next

        ' Post Pendapatan Umum ke Keuangan
        If rowPasienUmum > 0 Then
            Dim sqlStatementUmum As String = queryStringUmum.ToString()

            sqlStatementUmum = sqlStatementUmum.TrimEnd()
            If sqlStatementUmum.EndsWith(",") Then
                sqlStatementUmum = sqlStatementUmum.Substring(0, sqlStatementUmum.Length - 1)
            End If

            WriteThemysql(sqlStatementUmum, DB_Keuangan)
        End If

        ' Post Pendapatan Tagihan ke Keuangan
        If rowPasienTagihan > 0 Then
            Dim sqlStatementTagihan As String = queryStringTagihan.ToString()

            sqlStatementTagihan = sqlStatementTagihan.TrimEnd()
            If sqlStatementTagihan.EndsWith(",") Then
                sqlStatementTagihan = sqlStatementTagihan.Substring(0, sqlStatementTagihan.Length - 1)
            End If

            WriteThemysql(sqlStatementTagihan, DB_Keuangan)
        End If

        ' Update Flag Upload
        If rowPasienPoli > 0 Then
            noTransaksiPoli = Strings.Left(noTransaksiPoli, noTransaksiPoli.Length - 1)
            WriteSQL("UPDATE TransaksiPoli SET Upload = 1, UploadDate = GETDATE() WHERE TransPoliID IN (" & noTransaksiPoli & ")", 4)
        End If

        If rowPasienLab > 0 Then
            noTransaksiLab = Strings.Left(noTransaksiLab, noTransaksiLab.Length - 1)
            WriteSQL("UPDATE TransaksiLab SET Upload = 1, UploadDate = GETDATE() WHERE TransLabID IN (" & noTransaksiLab & ")", 4)
        End If

        If rowPasienGigi > 0 Then
            noTransaksiGigi = Strings.Left(noTransaksiGigi, noTransaksiGigi.Length - 1)
            WriteSQL("UPDATE TransaksiGigi SET Upload = 1, UploadDate = GETDATE() WHERE TransGigiID IN (" & noTransaksiGigi & ")", 4)
        End If
    End Sub

    Private Sub FormKirimLaporanOmset_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        Me.Dock = DockStyle.Fill
        Control.CheckForIllegalCrossThreadCalls = False
        DateTimePickerTanggalTransaksi.Value = DateAndTime.Now.AddDays(-1)
        ProgressBar1.Visible = False
        lblProgressBar.Visible = False
        ProgressBar2.Value = 0
        ButtonKirimDataOmset.Enabled = False

        ' Inisialisasi koneksi ke database MySQL
        SetConnectionFromConfig()
    End Sub

    Private Sub PoliResult(ByRef Tx As String)
        Dim queryString As String = ""
        Dim Tbls As New DataTable
        Dim Tpoli As DataTable = CreateTable()
        Dim Tnow As Date = DateTimePickerTanggalTransaksi.Value

        'Tbls = ReadSQL("SELECT a.TransPoliID as ID,a.NoUrut,a.TglPoli as Tgl,b.NoRekamMedis,b.Nama as Pasien,a.TotalTagihan,a.TotalDisc,a.Pembulatan,a.NettBayar,a.TotalBayar,a.Pengembalian,a.deleted,a.deletedby,a.deleteddate FROM TransaksiPoli a LEFT JOIN MasterPasien b on  a.IDInternet=b.NoRekamMedis  WHERE a.Upload <> 1 and a.deleted <> 1 and CONVERT(date, a.TglPoli) = '" & Format(Tnow.Date, "MM/dd/yyyy") & "' " & Tx & " order by a.NoUrut")
        queryString = "SELECT a.TransPoliID AS ID, a.NoUrut, a.TglPoli AS Tgl, c.JenisPoli, b.NoRekamMedis, b.Nama AS Pasien, a.TotalTagihan, a.TotalDisc, a.Pembulatan, a.NettBayar, a.TotalBayar, a.Pengembalian, a.deleted, a.deletedby, a.deleteddate " & _
                      "FROM TransaksiPoli a " & _
                      "LEFT JOIN TransaksiDetail c ON c.NoUrut = a.NoUrut " & _
                      "LEFT JOIN MasterPasien b ON a.IDInternet=b.NoRekamMedis " & _
                      "WHERE a.Upload <> 1 AND a.deleted <> 1 AND CONVERT(date, a.TglPoli) = '" & Format(Tnow.Date, "MM/dd/yyyy") & "' " & Tx & _
                      "ORDER BY a.NoUrut"

        Tbls = ReadSQL(queryString)

        For Each Trow As DataRow In Tbls.Rows
            ' Jika TransaksiPoliBayar terisi
            Dim Tdetail As DataTable = ReadSQL("SELECT * FROM TransaksiPoliBayar WHERE TransPoliID='" & Trow("ID") & "'")
            If Tdetail.Rows.Count > 0 Then
                For Each Ttemp As DataRow In Tdetail.Rows
                    Dim Tnew As DataRow = Tpoli.NewRow
                    Tnew("ID") = Trow("ID")
                    Tnew("NoUrut") = Trow("NoUrut")
                    Tnew("Tgl") = Trow("Tgl")
                    Tnew("NoRekamMedis") = Trow("NoRekamMedis")
                    Tnew("Pasien") = Trow("Pasien")
                    Tnew("Jenis Poli") = Trow("JenisPoli")
                    Tnew("TotalTagihan") = Trow("TotalTagihan")
                    Tnew("TotalDisc") = Trow("TotalDisc")
                    Tnew("Pembulatan") = Trow("Pembulatan")
                    Tnew("NettBayar") = Trow("NettBayar")
                    Tnew("TotalBayar") = Trow("TotalBayar")
                    Tnew("Pengembalian") = Trow("Pengembalian")
                    Tnew("RecTagihan") = Ttemp("NoJenisBayar")
                    Tnew("Adm") = ""
                    Select Case Ttemp("JenisBayar")
                        Case "TUNAI"
                            Tnew("JenisPasien") = "Pasien Umum"
                            Tnew("RecTagihan") = ""
                            Tnew("Tunai") = Ttemp("JumlahBayar") - Ttemp("Kembali") + CInt(ReadSQLNIK("SELECT isnull(sum(JumlahBayar)-sum(Kembali),0) as Tunai FROM TransaksiPoliBayarAwal WHERE TransPoliID in ( SELECT TransPoliID FROM TransaksiPoli WHERE TransPoliID='" & Trow("ID").ToString.Trim & "' and CONVERT(date, TglPoli) = '" & Format(Tnow.Date, "MM/dd/yyyy") & "') and TransJenis='POLI' and JenisBayar='TUNAI'"))

                        Case "DEBET"
                            Tnew("JenisPasien") = "Pasien Umum"
                            Tnew("RecTagihan") = Ttemp("NoJenisBayar")
                            Tnew("JenisKartu") = Ttemp("kartu")
                            Tnew("JenisMesin") = Ttemp("mesin")
                            Tnew("Debet") = Ttemp("JumlahBayar")
                        Case "CARD"
                            Tnew("JenisPasien") = "Pasien Umum"
                            Tnew("RecTagihan") = Ttemp("NoJenisBayar")
                            Tnew("JenisKartu") = Ttemp("kartu")
                            Tnew("JenisMesin") = Ttemp("mesin")
                            Tnew("Kredit") = Ttemp("JumlahBayar")
                        Case "TAGIHAN"
                            Tnew("JenisPasien") = Ttemp("NoJenisBayar")
                            Tnew("RecTagihan") = ""
                            Tnew("Tagihan") = Ttemp("JumlahBayar")
                    End Select
                    Tpoli.Rows.Add(Tnew)
                    'End If
                Next
            End If

            ' Jika TransaksiPoliBayarAwal terisi
            Tdetail = ReadSQL("SELECT * FROM TransaksiPoliBayarAwal WHERE TransPoliID='" & Trow("ID") & "' and TransJenis='POLI'")
            If Tdetail.Rows.Count > 0 Then
                For Each Ttemp As DataRow In Tdetail.Rows
                    Dim Tnew As DataRow = Tpoli.NewRow
                    Tnew("ID") = Trow("ID")
                    Tnew("NoUrut") = Trow("NoUrut")
                    Tnew("Tgl") = Trow("Tgl")
                    Tnew("NoRekamMedis") = Trow("NoRekamMedis")
                    Tnew("Pasien") = Trow("Pasien")
                    Tnew("Jenis Poli") = Trow("JenisPoli")
                    Tnew("TotalTagihan") = Trow("TotalTagihan")
                    Tnew("TotalDisc") = Trow("TotalDisc")
                    Tnew("Pembulatan") = Trow("Pembulatan")
                    Tnew("NettBayar") = Trow("NettBayar")
                    Tnew("TotalBayar") = Trow("TotalBayar")
                    Tnew("Pengembalian") = Trow("Pengembalian")
                    Tnew("RecTagihan") = Ttemp("NoJenisBayar")
                    Tnew("Adm") = ""
                    Select Case Ttemp("JenisBayar")
                        Case "TUNAI"
                            If CheckSQL("SELECT * FROM TransaksiPoliBayar WHERE TransPoliID='" & Trow("ID") & "' and JenisBayar='TUNAI'") = False Then
                                Tnew("JenisPasien") = "Pasien Umum"
                                Tnew("RecTagihan") = ""
                                Tnew("Tunai") = Ttemp("JumlahBayar") - Ttemp("Kembali")
                            End If
                        Case "DEBET"
                            Tnew("JenisPasien") = "Pasien Umum"
                            Tnew("RecTagihan") = Ttemp("NoJenisBayar")
                            Tnew("JenisKartu") = Ttemp("kartu")
                            Tnew("JenisMesin") = Ttemp("mesin")
                            Tnew("Debet") = Ttemp("JumlahBayar")
                        Case "CARD"
                            Tnew("JenisPasien") = "Pasien Umum"
                            Tnew("RecTagihan") = Ttemp("NoJenisBayar")
                            Tnew("JenisKartu") = Ttemp("kartu")
                            Tnew("JenisMesin") = Ttemp("mesin")
                            Tnew("Kredit") = Ttemp("JumlahBayar")
                        Case "TAGIHAN"
                            Tnew("JenisPasien") = Ttemp("NoJenisBayar")
                            Tnew("RecTagihan") = ""
                            Tnew("Tagihan") = Ttemp("JumlahBayar")
                    End Select
                    Tpoli.Rows.Add(Tnew)
                    'End If
                Next
            End If
        Next

        gridpoli.DataSource = Tpoli

        GridView1.Columns("ID").Visible = False
        GridView1.Columns("Tgl").Visible = False
        GridView1.Columns("Pembulatan").Visible = False
        GridView1.Columns("NettBayar").Visible = False
        GridView1.Columns("Pengembalian").Visible = False
        GridView1.Columns("Adm").Visible = False
    End Sub

    Private Sub LabResult(ByRef Tx As String)
        Dim queryString As String = ""
        Dim Tbls As New DataTable
        Dim TLab As DataTable = CreateTable()
        Dim Tnow As Date = DateTimePickerTanggalTransaksi.Value

        'Do
        'Tbls = ReadSQL("SELECT a.status, a.SendKeu, a.UploadMesin, a.LabSamplingTime, a.TransLabID as ID,a.NoUrut,a.TglLab as Tgl,b.NoRekamMedis,b.Nama as Pasien,a.TotalTagihan,a.TotalDisc,a.Pembulatan,a.NettBayar,a.TotalBayar,a.Pengembalian,a.deleted,a.deletedby,a.deleteddate,a.CaraAmbil as RecTagihan FROM TransaksiLab a LEFT JOIN MasterPasien b on  a.IDInternet=b.NoRekamMedis  WHERE a.status <> 'OPEN' and a.Upload <> 1 and a.deleted <> 1 and CONVERT(date, a.Tgllab)='" & Format(Tnow.Date, "MM/dd/yyyy") & "' " & Tx & " order by a.NoUrut")
        queryString = "SELECT a.status, a.SendKeu, a.UploadMesin, a.LabSamplingTime, a.TransLabID AS ID, a.NoUrut, a.TglLab AS Tgl, c.JenisPoli, b.NoRekamMedis, b.Nama AS Pasien, a.TotalTagihan, a.TotalDisc, a.Pembulatan, a.NettBayar, a.TotalBayar, a.Pengembalian, a.deleted, a.deletedby, a.deleteddate, a.CaraAmbil AS RecTagihan " & _
                      "FROM TransaksiLab a " & _
                      "LEFT JOIN TransaksiDetail c ON c.NoUrut = a.NoUrut " & _
                      "LEFT JOIN MasterPasien b ON a.IDInternet=b.NoRekamMedis " & _
                      "WHERE a.status<>'OPEN' AND a.Upload<>1 AND a.deleted<>1 AND CONVERT(date, a.Tgllab)='" & Format(Tnow.Date, "MM/dd/yyyy") & "' " & Tx & _
                      "ORDER BY a.NoUrut"

        Tbls = ReadSQL(queryString)

        For Each Trow As DataRow In Tbls.Rows
            Dim NoUrut As String = Trow("NoUrut")
            If Trow("status") = "OPEN" And NoUrut.Contains("L") = True Then
                'Skip, Jika belum dikasir
            ElseIf IsDBNull(Trow("SendKeu")) = True And NoUrut.Contains("M") = True Then
                'Skip, Jika MCU upload mesin tapi tidak di barcode
            ElseIf IsDBNull(Trow("LabSamplingTime")) = False And IsDBNull(Trow("UploadMesin")) = False And IsDBNull(Trow("SendKeu")) = True And NoUrut.Contains("M") = True Then
                'Skip, Jika MCU upload mesin tapi tidak di barcode
            ElseIf IsDBNull(Trow("LabSamplingTime")) = False And IsDBNull(Trow("UploadMesin")) = False And IsDBNull(Trow("SendKeu")) = True And NoUrut.Contains("L") = True Then
                'Skip, Jika Lokal upload mesin tapi tidak di barcode
            Else
                Dim Tdetail As DataTable = ReadSQL("SELECT * FROM TransaksiLabBayar WHERE TransLabID='" & Trow("ID") & "'")
                If Tdetail.Rows.Count > 0 Then
                    For Each Ttemp As DataRow In Tdetail.Rows
                        Dim Tnew As DataRow = TLab.NewRow
                        Tnew("ID") = Trow("ID")
                        Tnew("NoUrut") = Trow("NoUrut")
                        Tnew("Tgl") = Trow("Tgl")
                        Tnew("NoRekamMedis") = Trow("NoRekamMedis")
                        Tnew("Pasien") = Trow("Pasien")
                        Tnew("Jenis Poli") = Trow("JenisPoli")
                        Tnew("TotalTagihan") = Trow("TotalTagihan")
                        Tnew("TotalDisc") = Trow("TotalDisc")
                        Tnew("Pembulatan") = Trow("Pembulatan")
                        Tnew("NettBayar") = Trow("NettBayar")
                        Tnew("TotalBayar") = Trow("TotalBayar")
                        Tnew("Pengembalian") = Trow("Pengembalian")
                        Tnew("RecTagihan") = Ttemp("NoJenisBayar")
                        Tnew("Adm") = ""
                        If Strings.LCase(Ttemp("NoJenisBayar").ToString).Contains("bpjs") = True Then
                            Tnew("JenisPasien") = "BPJS"
                        End If

                        Select Case Ttemp("JenisBayar")
                            Case "TUNAI"
                                Tnew("JenisPasien") = "Pasien Umum"
                                Tnew("RecTagihan") = ""
                                Tnew("Tunai") = Ttemp("JumlahBayar") - Ttemp("Kembali")
                            Case "DEBET"
                                Tnew("JenisPasien") = "Pasien Umum"
                                Tnew("RecTagihan") = Ttemp("NoJenisBayar")
                                Tnew("JenisKartu") = Ttemp("kartu")
                                Tnew("JenisMesin") = Ttemp("mesin")
                                Tnew("Debet") = Ttemp("JumlahBayar")
                            Case "CARD"
                                Tnew("JenisPasien") = "Pasien Umum"
                                Tnew("RecTagihan") = Ttemp("NoJenisBayar")
                                Tnew("JenisKartu") = Ttemp("kartu")
                                Tnew("JenisMesin") = Ttemp("mesin")
                                Tnew("Kredit") = Ttemp("JumlahBayar")
                            Case "TAGIHAN"
                                Tnew("Tagihan") = Ttemp("JumlahBayar")
                                Tnew("JenisPasien") = Ttemp("NoJenisBayar")
                                Tnew("RecTagihan") = ""
                        End Select
                        TLab.Rows.Add(Tnew)
                    Next
                End If
            End If
        Next

        gridlab.DataSource = TLab

        GridView2.Columns("ID").Visible = False
        GridView2.Columns("Tgl").Visible = False
        GridView2.Columns("Pembulatan").Visible = False
        GridView2.Columns("NettBayar").Visible = False
        GridView2.Columns("Pengembalian").Visible = False
        GridView2.Columns("Adm").Visible = False
    End Sub

    Private Sub GigiResult(ByRef Tx As String)
        Dim queryString As String = ""
        Dim Tbls As New DataTable
        Dim Tgigi As DataTable = CreateTable()
        Dim Tnow As Date = DateTimePickerTanggalTransaksi.Value

        'Do
        queryString = "SELECT a.TransGigiID AS ID, a.NoUrut, a.TglGigi AS Tgl, c.JenisPoli, b.NoRekamMedis, b.Nama AS Pasien, a.TotalTagihan, a.TotalDisc, a.Pembulatan, a.NettBayar, a.TotalBayar, a.Pengembalian, a.deleted, a.deletedby, a.deleteddate " & _
                      "FROM TransaksiGigi a " & _
                      "LEFT JOIN TransaksiDetail c ON c.NoUrut = a.NoUrut " & _
                      "LEFT JOIN MasterPasien b ON a.IDInternet=b.NoRekamMedis " & _
                      "WHERE a.Upload<>1 AND a.deleted<>1 AND CONVERT(date, a.TglGigi)='" & Format(Tnow.Date, "MM/dd/yyyy") & "' " & Tx & _
                      "ORDER BY a.NoUrut"

        Tbls = ReadSQL(queryString)

        For Each Trow As DataRow In Tbls.Rows
            ' Jika TransaksiGigiBayar terisi
            Dim Tdetail As DataTable = ReadSQL("SELECT * FROM TransaksiGigiBayar WHERE TransGigiID='" & Trow("ID") & "'")
            If Tdetail.Rows.Count > 0 Then
                For Each Ttemp As DataRow In Tdetail.Rows
                    Dim Tnew As DataRow = Tgigi.NewRow
                    Tnew("ID") = Trow("ID")
                    Tnew("NoUrut") = Trow("NoUrut")
                    Tnew("Tgl") = Trow("Tgl")
                    Tnew("NoRekamMedis") = Trow("NoRekamMedis")
                    Tnew("Pasien") = Trow("Pasien")
                    Tnew("Jenis Poli") = Trow("JenisPoli")
                    Tnew("TotalTagihan") = Trow("TotalTagihan")
                    Tnew("TotalDisc") = Trow("TotalDisc")
                    Tnew("Pembulatan") = Trow("Pembulatan")
                    Tnew("NettBayar") = Trow("NettBayar")
                    Tnew("TotalBayar") = Trow("TotalBayar")
                    Tnew("Pengembalian") = Trow("Pengembalian")
                    Tnew("RecTagihan") = Ttemp("NoJenisBayar")
                    Tnew("Adm") = ""
                    Select Case Ttemp("JenisBayar")
                        Case "TUNAI"
                            Tnew("JenisPasien") = "Pasien Umum"
                            Tnew("RecTagihan") = ""
                            Tnew("Tunai") = Ttemp("JumlahBayar") - Ttemp("Kembali") + CInt(ReadSQLNIK("SELECT isnull(sum(JumlahBayar)-sum(Kembali),0) as Tunai FROM TransaksiGigiBayarAwal WHERE TransGigiID in ( SELECT TransGigiID FROM TransaksiGigi WHERE TransGigiID='" & Trow("ID").ToString.Trim & "' and CONVERT(date, TglGigi)='" & Format(Tnow.Date, "MM/dd/yyyy") & "') and TransJenis='GIGI' and JenisBayar='TUNAI'"))
                        Case "DEBET"
                            Tnew("JenisPasien") = "Pasien Umum"
                            Tnew("RecTagihan") = Ttemp("NoJenisBayar")
                            Tnew("JenisKartu") = Ttemp("kartu")
                            Tnew("JenisMesin") = Ttemp("mesin")
                            Tnew("Debet") = Ttemp("JumlahBayar")
                        Case "CARD"
                            Tnew("JenisPasien") = "Pasien Umum"
                            Tnew("RecTagihan") = Ttemp("NoJenisBayar")
                            Tnew("JenisKartu") = Ttemp("kartu")
                            Tnew("JenisMesin") = Ttemp("mesin")
                            Tnew("Kredit") = Ttemp("JumlahBayar")
                        Case "TAGIHAN"
                            Tnew("JenisPasien") = Ttemp("NoJenisBayar")
                            Tnew("RecTagihan") = ""
                            Tnew("Tagihan") = Ttemp("JumlahBayar")
                    End Select
                    Tgigi.Rows.Add(Tnew)
                    'End If
                Next
            End If

            ' Jika TransaksiGigiBayarAwal terisi
            Tdetail = ReadSQL("SELECT * FROM TransaksiGigiBayarAwal WHERE TransGigiID='" & Trow("ID") & "' and TransJenis='Gigi'")
            If Tdetail.Rows.Count > 0 Then
                For Each Ttemp As DataRow In Tdetail.Rows
                    Dim Tnew As DataRow = Tgigi.NewRow
                    Tnew("ID") = Trow("ID")
                    Tnew("NoUrut") = Trow("NoUrut")
                    Tnew("Tgl") = Trow("Tgl")
                    Tnew("NoRekamMedis") = Trow("NoRekamMedis")
                    Tnew("Pasien") = Trow("Pasien")
                    Tnew("Jenis Poli") = Trow("JenisPoli")
                    Tnew("TotalTagihan") = Trow("TotalTagihan")
                    Tnew("TotalDisc") = Trow("TotalDisc")
                    Tnew("Pembulatan") = Trow("Pembulatan")
                    Tnew("NettBayar") = Trow("NettBayar")
                    Tnew("TotalBayar") = Trow("TotalBayar")
                    Tnew("Pengembalian") = Trow("Pengembalian")
                    Tnew("RecTagihan") = Ttemp("NoJenisBayar")
                    Tnew("Adm") = ""
                    Select Case Ttemp("JenisBayar")
                        Case "TUNAI"
                            If CheckSQL("SELECT * FROM TransaksiGigiBayar WHERE TransGigiID='" & Trow("ID") & "' and JenisBayar='TUNAI'") = False Then
                                Tnew("JenisPasien") = "Pasien Umum"
                                Tnew("RecTagihan") = ""
                                Tnew("Tunai") = Ttemp("JumlahBayar") - Ttemp("Kembali")
                            End If
                        Case "DEBET"
                            Tnew("JenisPasien") = "Pasien Umum"
                            Tnew("RecTagihan") = Ttemp("NoJenisBayar")
                            Tnew("JenisKartu") = Ttemp("kartu")
                            Tnew("JenisMesin") = Ttemp("mesin")
                            Tnew("Debet") = Ttemp("JumlahBayar")
                        Case "CARD"
                            Tnew("JenisPasien") = "Pasien Umum"
                            Tnew("RecTagihan") = Ttemp("NoJenisBayar")
                            Tnew("JenisKartu") = Ttemp("kartu")
                            Tnew("JenisMesin") = Ttemp("mesin")
                            Tnew("Kredit") = Ttemp("JumlahBayar")
                        Case "TAGIHAN"
                            Tnew("JenisPasien") = Ttemp("NoJenisBayar")
                            Tnew("RecTagihan") = ""
                            Tnew("Tagihan") = Ttemp("JumlahBayar")
                    End Select
                    Tgigi.Rows.Add(Tnew)
                Next
            End If
        Next

        gridgigi.DataSource = Tgigi

        GridView3.Columns("ID").Visible = False
        GridView3.Columns("Tgl").Visible = False
        GridView3.Columns("Pembulatan").Visible = False
        GridView3.Columns("NettBayar").Visible = False
        GridView3.Columns("Pengembalian").Visible = False
        GridView3.Columns("Adm").Visible = False
    End Sub

    Private Function ValidasiDataUpload() As Boolean
        ' Cek sambungan internet
        If CheckInternetConnection() = False Then
            MessageBox.Show("Eror : Tidak ada koneksi internet.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Return False
        End If

        ' Validasi Tanggal Transaksi
        'If DateTimePickerTanggalTransaksi.Value.Date > DateTime.Now.AddDays(-1).Date Then
        '    MessageBox.Show("Eror : Tanggal transaksi maksimal H-1.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        '    ' Kembalikan ke tanggal kemarin
        '    DateTimePickerTanggalTransaksi.Value = DateTime.Now.AddDays(-1)

        '    Return False
        'End If

        ' Validasi transaksi pending
        If JumlahTransaksiPending() > 0 Then
            MessageBox.Show("Eror : Terdapat transaksi pending yang belum diselesaikan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)

            Return False
        End If

        Return True
    End Function

    Function JumlahTransaksiPending() As Integer
        Dim query As New StringBuilder()

        query.AppendLine("SELECT COUNT(*) ")
        query.AppendLine("FROM ( ")
        query.AppendLine("    SELECT TransPoliID ")
        query.AppendLine("    FROM TransaksiPoli a ")
        query.AppendLine("    WHERE CONVERT(DATE, TglPoli) = '" & Format(DateTimePickerTanggalTransaksi.Value, "yyyy-MM-dd") & "' ")
        query.AppendLine("      AND Deleted = 0 ")
        query.AppendLine("      AND TransPoliID IN ( ")
        query.AppendLine("          SELECT TransPoliID ")
        query.AppendLine("          FROM TransaksiPoliDetail ")
        query.AppendLine("          WHERE StatusPembayaran = 'PENDING' AND DeletedDate IS NULL")
        query.AppendLine("      ) ")
        query.AppendLine("    UNION ALL ")
        query.AppendLine("    SELECT TransGigiID ")
        query.AppendLine("    FROM TransaksiGigi a ")
        query.AppendLine("    WHERE CONVERT(DATE, TglGigi) = '" & Format(DateTimePickerTanggalTransaksi.Value, "yyyy-MM-dd") & "' ")
        query.AppendLine("      AND Deleted = 0 ")
        query.AppendLine("      AND TransGigiID IN ( ")
        query.AppendLine("          SELECT TransPoliID ")
        query.AppendLine("          FROM TransaksiPoliDetail ")
        query.AppendLine("          WHERE StatusPembayaran = 'PENDING' AND DeletedDate IS NULL")
        query.AppendLine("      ) ")
        query.AppendLine(") AS CombinedResult;")

        Dim jumlahTransaksi As String = ReadSQLNIK(query.ToString())

        Return CDbl(jumlahTransaksi)
    End Function

    Private Sub SendingJurnal()
        ProgressBar1.Value = 0
        Dim procent As Integer = 0
        Dim persen As Integer = 0
        Dim keterangan As String = ""
        Dim flag As String = ""
        Dim KetLokasi As String = ""
        Dim NoUrut As String = ""
        Dim bsa As String = ""
        Dim Tnow As Date = DateTimePickerTanggalTransaksi.Value
        Dim Tquery As String = ""
        Dim Tlokasigl As New DataTable
        Dim CoaPiutangPending As String = ""
        Dim CoaJenisBayar As String = ""

        Dim queryBuilder As New StringBuilder()

        queryBuilder.AppendLine("SELECT t2.JumlahBayar, t2.JenisTransaksi, t2.JenisBayar, t2.[Tanggal Transaksi]")
        queryBuilder.AppendLine("FROM (")
        queryBuilder.AppendLine("    SELECT SUM(b.JumlahBayar) AS 'JumlahBayar', 'LAB' AS 'JenisTransaksi', b.JenisBayar, CONVERT(DATE, TglLab) AS 'Tanggal Transaksi'")
        queryBuilder.AppendLine("    FROM TransaksiLab a")
        queryBuilder.AppendLine("    LEFT JOIN TransaksiLabBayar b ON a.TransLabID = b.TransLabID")
        queryBuilder.AppendLine("    WHERE a.deleted <> 1 AND a.SendKeu IS NOT NULL AND CONVERT(DATE, TglLab) = '" & Format(Tnow.Date, "MM/dd/yyyy") & "' AND b.JenisBayar = 'TAGIHAN' AND b.JumlahBayar > 0 AND a.FlagJurnalHarianTagihan IS NULL")
        queryBuilder.AppendLine("    GROUP BY b.JenisBayar, CONVERT(DATE, TglLab)")
        queryBuilder.AppendLine("    UNION")
        queryBuilder.AppendLine("    SELECT SUM(t1.Tagihan) AS 'JumlahBayar', t1.JenisTransaksi, t1.JenisBayar, t1.[Tanggal Transaksi]")
        queryBuilder.AppendLine("    FROM (")
        queryBuilder.AppendLine("        SELECT t1.TransPoliID AS 'Translabid', t1.NoJenisBayar, t1.[No Lab], CONVERT(DATE, t1.[Tanggal Transaksi]) AS 'Tanggal Transaksi', SUM(t1.Tagihan) AS 'Tagihan', t1.kartu, t1.mesin, t1.JenisTransaksi, t1.JenisBayar")
        queryBuilder.AppendLine("        FROM (")
        queryBuilder.AppendLine("            SELECT c.TransPoliIDBayar AS 'No', a.TransPoliID, c.NoJenisBayar, a.NoUrut AS 'No Lab', CONVERT(DATE, a.TglPoli) AS 'Tanggal Transaksi', c.JumlahBayar - c.Kembali AS 'Tagihan', c.kartu, c.mesin, 'POLI' AS 'JenisTransaksi', c.JenisBayar")
        queryBuilder.AppendLine("            FROM TransaksiPoli a")
        queryBuilder.AppendLine("            LEFT JOIN TransaksiPoliBayar c ON a.TransPoliID = c.TransPoliID")
        queryBuilder.AppendLine("            WHERE a.deleted <> 1 AND c.JenisBayar = 'TAGIHAN' AND c.JumlahBayar > 0 AND FlagJurnalHarianTagihan IS NULL")
        queryBuilder.AppendLine("            UNION")
        queryBuilder.AppendLine("            SELECT c.TransPoliIDBayar AS 'No', a.TransPoliID, c.NoJenisBayar, a.NoUrut AS 'No Lab', CONVERT(DATE, a.TglPoli) AS 'Tanggal Transaksi', c.JumlahBayar - c.Kembali AS 'Tagihan', c.kartu, c.mesin, 'POLI' AS 'JenisTransaksi', c.JenisBayar")
        queryBuilder.AppendLine("            FROM TransaksiPoli a")
        queryBuilder.AppendLine("            LEFT JOIN TransaksiPoliBayarAwal c ON a.TransPoliID = c.TransPoliID")
        queryBuilder.AppendLine("            WHERE a.deleted <> 1 AND c.JenisBayar = 'TAGIHAN' AND c.JumlahBayar > 0 AND FlagJurnalHarianTagihan IS NULL")
        queryBuilder.AppendLine("        ) AS t1")
        queryBuilder.AppendLine("        GROUP BY t1.TransPoliID, t1.NoJenisBayar, t1.[No Lab], CONVERT(DATE, t1.[Tanggal Transaksi]), t1.kartu, t1.mesin, t1.JenisTransaksi, t1.JenisBayar")
        queryBuilder.AppendLine("        UNION")
        queryBuilder.AppendLine("        SELECT t1.TransGigiID AS 'Translabid', t1.NoJenisBayar, t1.[No Lab], CONVERT(DATE, t1.[Tanggal Transaksi]) AS 'Tanggal Transaksi', SUM(t1.Tagihan) AS 'Tagihan', t1.kartu, t1.mesin, t1.JenisTransaksi, t1.JenisBayar")
        queryBuilder.AppendLine("        FROM (")
        queryBuilder.AppendLine("            SELECT c.TransGigiIDBayar AS 'No', a.TransGigiID, c.NoJenisBayar, a.NoUrut AS 'No Lab', CONVERT(DATE, a.TglGigi) AS 'Tanggal Transaksi', c.JumlahBayar - c.Kembali AS 'Tagihan', c.kartu, c.mesin, 'GIGI' AS 'JenisTransaksi', c.JenisBayar")
        queryBuilder.AppendLine("            FROM TransaksiGigi a")
        queryBuilder.AppendLine("            LEFT JOIN TransaksiGigiBayar c ON a.TransGigiID = c.TransGigiID")
        queryBuilder.AppendLine("            WHERE a.deleted <> 1 AND c.JenisBayar = 'TAGIHAN' AND c.JumlahBayar > 0 AND FlagJurnalHarianTagihan IS NULL")
        queryBuilder.AppendLine("            UNION")
        queryBuilder.AppendLine("            SELECT c.TransGigiIDBayar AS 'No', a.TransGigiID, c.NoJenisBayar, a.NoUrut AS 'No Lab', CONVERT(DATE, a.TglGigi) AS 'Tanggal Transaksi', c.JumlahBayar - c.Kembali AS 'Tagihan', c.kartu, c.mesin, 'GIGI' AS 'JenisTransaksi', c.JenisBayar")
        queryBuilder.AppendLine("            FROM TransaksiGigi a")
        queryBuilder.AppendLine("            LEFT JOIN TransaksiGigiBayarAwal c ON a.TransGigiID = c.TransGigiID")
        queryBuilder.AppendLine("            WHERE a.deleted <> 1 AND c.JenisBayar = 'TAGIHAN' AND c.JumlahBayar > 0 AND FlagJurnalHarianTagihan IS NULL")
        queryBuilder.AppendLine("        ) AS t1")
        queryBuilder.AppendLine("        GROUP BY t1.TransGigiID, t1.NoJenisBayar, t1.[No Lab], CONVERT(DATE, t1.[Tanggal Transaksi]), t1.kartu, t1.mesin, t1.JenisTransaksi, t1.JenisBayar")
        queryBuilder.AppendLine("        UNION")
        queryBuilder.AppendLine("        SELECT a.TransAdminID AS 'Translabid', c.NoJenisBayar, CAST(a.TransAdminID AS CHAR(10)) AS 'No Lab', CONVERT(DATE, a.TindakanTgl) AS 'Tanggal Transaksi', c.JumlahBayar - c.Kembali AS 'Tagihan', c.mesin, c.kartu, 'DLL' AS 'JenisTransaksi', c.JenisBayar")
        queryBuilder.AppendLine("        FROM TransaksiAdmin a")
        queryBuilder.AppendLine("        LEFT JOIN TransaksiAdminBayar c ON a.TransAdminID = c.TransAdminID")
        queryBuilder.AppendLine("        WHERE a.deleted <> 1 AND c.JenisBayar = 'TAGIHAN' AND c.JumlahBayar > 0 AND FlagJurnalHarianTagihan IS NULL")
        queryBuilder.AppendLine("    ) AS t1")
        queryBuilder.AppendLine("    WHERE CONVERT(DATE, t1.[Tanggal Transaksi]) = '" & Format(Tnow.Date, "MM/dd/yyyy") & "'")
        queryBuilder.AppendLine("    GROUP BY t1.JenisTransaksi, t1.JenisBayar, t1.[Tanggal Transaksi]")
        queryBuilder.AppendLine(") AS t2")
        queryBuilder.AppendLine("ORDER BY t2.[Tanggal Transaksi], t2.JenisTransaksi")

        Dim Tloc As String = NoPoli
        Dim TKode As String = ReadSQLNIK("SELECT RIGHT(StrValue, 3) FROM MsConfig WHERE ConfigName='KodeInvoiceLab'")
        Dim TKodeBarcode As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='KodeBarcode'")
        Dim TblsGL As DataTable = ReadSQL(queryBuilder.ToString())
        If TblsGL.Rows.Count > 0 Then
            For Each Trow As DataRow In TblsGL.Rows
                persen = persen + 1
                procent = persen * 100 / TblsGL.Rows.Count
                ProgressBar2.Value = procent

                Tlokasigl = ReadThemysql("SELECT a.locgl, a.locket FROM masterlokasigl a WHERE a.loc='" & Tloc & "' AND a.jenistransaksi='" & Trow("JenisTransaksi") & "'", DB_Keuangan)
                Dim Trowlokasigl As DataRow = Tlokasigl.Rows(0)
                bsa = Trowlokasigl("locgl")
                KetLokasi = Trowlokasigl("locket")

                NoUrut = ReadSQLNIK("SELECT myFlag FROM getFlagPendapatan('%" & TKodeBarcode & DateTime.ParseExact(Trow("Tanggal Transaksi"), "M/d/yyyy", Nothing).ToString("yyMM") & "%')")

                If IsDBNull(NoUrut) = False And NoUrut <> "" And NoUrut <> "-" Then
                    flag = "" & TKodeBarcode & DateTime.ParseExact(Trow("Tanggal Transaksi"), "M/d/yyyy", Nothing).ToString("yyMM") & TKode & NoUrut.ToString().PadLeft(4, "0") & ""
                Else
                    flag = "" & TKodeBarcode & DateTime.ParseExact(Trow("Tanggal Transaksi"), "M/d/yyyy", Nothing).ToString("yyMM") & TKode & "0001"
                End If

                keterangan = "TERIMA - TAGIHAN " & KetLokasi & " " & DateTime.ParseExact(Trow("Tanggal Transaksi"), "M/d/yyyy", Nothing).ToString("dd/MM/yyyy") & ""

                'Jenis Transaksi
                If Trow("JenisTransaksi").ToString.Trim = "DLL" Then
                    CoaJenisBayar = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPendapatanAdmin'", DB_Keuangan2)
                    CoaPiutangPending = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPiutangPendingAdmin'", DB_Keuangan2)
                ElseIf Trow("JenisTransaksi").ToString.Trim = "GIGI" Then
                    CoaJenisBayar = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPendapatanGigi'", DB_Keuangan2)
                    CoaPiutangPending = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPiutangPendingGigi'", DB_Keuangan2)
                ElseIf Trow("JenisTransaksi").ToString.Trim = "LAB" Then
                    CoaJenisBayar = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPendapatanLab'", DB_Keuangan2)
                    CoaPiutangPending = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPiutangPendingLab'", DB_Keuangan2)
                ElseIf Trow("JenisTransaksi").ToString.Trim = "POLI" Then
                    CoaJenisBayar = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPendapatanKlinik'", DB_Keuangan2)
                    CoaPiutangPending = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPiutangPendingKlinik'", DB_Keuangan2)
                End If

                WriteThemysql("SELECT F_MakeUMH('" & flag & "', 'out', '', '" & DateTime.ParseExact(Trow("Tanggal Transaksi"), "M/d/yyyy", Nothing).ToString("yyyy-MM-dd") & "', '" & CoaJenisBayar & "', '" & CoaPiutangPending & "', 'IDR', 1, " & CDbl(Trow("JumlahBayar")) & ", '" & keterangan.ToUpper() & "', '1', 1, '', '" & keterangan.ToUpper() & "', '', '', '" & bsa & "', 4, " & CDbl(Trow("JumlahBayar")) & ", 'K')", DB_Jurnal)

                'Flag Ke Transaksi
                If Trow("JenisTransaksi").ToString.Trim = "LAB" Then
                    WriteSQL("UPDATE TransaksiLab SET FlagJurnalHarianTagihan = '" & flag & "' WHERE deleted <> 1 AND SendKeu IS NOT NULL AND (CONVERT(DATE, TglLab) = '" & DateTime.ParseExact(Trow("Tanggal Transaksi"), "M/d/yyyy", Nothing).ToString("yyyy-MM-dd") & "') AND FlagJurnalHarianTagihan IS NULL AND TransLabID in (SELECT TransLabID FROM TransaksiLabBayar WHERE JenisBayar = 'TAGIHAN')", 4)
                ElseIf Trow("JenisTransaksi").ToString.Trim = "GIGI" Then
                    WriteSQL("UPDATE TransaksiGigi SET FlagJurnalHarianTagihan = '" & flag & "' WHERE deleted <> 1 AND FlagJurnalHarianTagihan IS NULL AND (CONVERT(DATE, TglGigi) = '" & DateTime.ParseExact(Trow("Tanggal Transaksi"), "M/d/yyyy", Nothing).ToString("yyyy-MM-dd") & "') AND (TransGigiID in (SELECT TransGigiID FROM TransaksiGigiBayar WHERE JenisBayar = 'TAGIHAN') OR TransGigiID in (SELECT TransGigiID FROM TransaksiGigiBayarAwal WHERE JenisBayar = 'TAGIHAN'))", 4)
                ElseIf Trow("JenisTransaksi").ToString.Trim = "DLL" Then
                    WriteSQL("UPDATE TransaksiAdmin SET FlagJurnalHarianTagihan = '" & flag & "' WHERE deleted <> 1 AND FlagJurnalHarianTagihan IS NULL  AND (CONVERT(DATE, TindakanTgl) = '" & DateTime.ParseExact(Trow("Tanggal Transaksi"), "M/d/yyyy", Nothing).ToString("yyyy-MM-dd") & "') AND TransAdminID in (SELECT TransAdminID FROM TransaksiAdminBayar WHERE JenisBayar = 'TAGIHAN')", 4)
                ElseIf Trow("JenisTransaksi").ToString.Trim = "POLI" Then
                    WriteSQL("UPDATE TransaksiPoli SET FlagJurnalHarianTagihan = '" & flag & "' WHERE deleted <> 1 AND FlagJurnalHarianTagihan IS NULL AND (CONVERT(DATE, TglPoli) = '" & DateTime.ParseExact(Trow("Tanggal Transaksi"), "M/d/yyyy", Nothing).ToString("yyyy-MM-dd") & "') AND (TransPoliID in (SELECT TransPoliID FROM TransaksiPoliBayar WHERE JenisBayar = 'TAGIHAN') OR TransPoliID in (SELECT TransPoliID FROM TransaksiPoliBayarAwal WHERE JenisBayar = 'TAGIHAN'))", 4)
                End If

                'Save Log
                WriteSQL("INSERT INTO LogJurnalKeuangan (JurnalFlag,JurnalDate,JurnalBy,Status,JenisTransaksi) VALUES ('" & flag & "', getdate(), '" & PoliKlinik.Lbluser.Text & "', 'JURNAL TAGIHAN HARIAN', '" & Trow("JenisTransaksi").ToString.Trim & "')", 4)
            Next
        End If
    End Sub

    Private Sub ButtonSearchDataOmset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSearchDataOmset.Click
        Try
            If ValidasiDataUpload() = True Then
                Dim Tawal As DataTable = ReadThemysql("SELECT incjenis, no_transaksi FROM acctranspendapatandetail WHERE date(inctgl) = '" & Format(DateTimePickerTanggalTransaksi.Value, "yyyyMMdd") & "' AND loc = '" & NoPoli & "'", DB_Keuangan)
                Dim Telse As DataTable = ReadThemysql("SELECT incjenis, no_transaksi FROM acctranstagihandetail WHERE date(inctgl) = '" & Format(DateTimePickerTanggalTransaksi.Value, "yyyyMMdd") & "' AND loc = '" & NoPoli & "'", DB_Keuangan)

                For Each Trow As DataRow In Telse.Rows
                    Dim Rnew As DataRow = Tawal.NewRow
                    For i As Integer = 0 To Tawal.Columns.Count - 1
                        Rnew(i) = Trow(i)
                    Next
                    Tawal.Rows.Add(Rnew)
                Next

                Dim Tpoli As String = "("
                Dim Bpoli As Boolean = False
                Dim Tlab As String = "("
                Dim Blab As Boolean = False
                Dim Tgigi As String = "("
                Dim Bgigi As Boolean = False
                Dim Tadmin As String = "("
                Dim Badmin As Boolean = False

                For Each Trow As DataRow In Tawal.Rows
                    If Trow("incjenis") = "POLI" Then
                        Tpoli = Tpoli & "'" & Trow("no_transaksi") & "',"
                        Bpoli = True
                    ElseIf Trow("incjenis") = "LAB" Then
                        Tlab = Tlab & "'" & Trow("no_transaksi") & "',"
                        Blab = True
                    ElseIf Trow("incjenis") = "GIGI" Then
                        Tgigi = Tgigi & "'" & Trow("no_transaksi") & "',"
                        Bgigi = True
                    ElseIf Trow("incjenis") = "DLL" Then
                        Tadmin = Tadmin & "'" & Trow("no_transaksi") & "',"
                        Badmin = True
                    End If
                Next

                If Bpoli = False Then Tpoli = "('')" Else Tpoli = Strings.Left(Tpoli, Tpoli.Length - 1) & ")"
                If Blab = False Then Tlab = "('')" Else Tlab = Strings.Left(Tlab, Tlab.Length - 1) & ")"
                If Bgigi = False Then Tgigi = "('')" Else Tgigi = Strings.Left(Tgigi, Tgigi.Length - 1) & ")"
                If Badmin = False Then Tadmin = "('')" Else Tadmin = Strings.Left(Tadmin, Tadmin.Length - 1) & ")"

                PoliResult(" AND a.NoUrut NOT IN " & Tpoli)
                LabResult(" AND a.NoUrut NOT IN " & Tlab)
                GigiResult(" AND a.NoUrut NOT IN " & Tgigi)

                If GridView1.RowCount = 0 And GridView2.RowCount = 0 And GridView3.RowCount = 0 And GridView4.RowCount = 0 Then
                    MsgBox("Tidak ada data yang ditampilkan.", MsgBoxStyle.Exclamation, "Warning.")
                    ButtonKirimDataOmset.Enabled = False
                Else
                    MsgBox("Langkah Selanjutnya Klik Tombol Send.", MsgBoxStyle.Information, "Success!")
                    ButtonKirimDataOmset.Enabled = True
                    ProgressBar2.Value = 0
                End If
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub ButtonKirimDataOmset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonKirimDataOmset.Click
        thread = New System.Threading.Thread(AddressOf KirimOmsetHarian)
        thread.Start()
    End Sub

    Private Sub ButtonKirimJurnalUlang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonKirimJurnalUlang.Click
        If PoliKlinik.Lbluser.Text = "Admin" Then
            FormSendingJurnalPendapatan.ShowDialog()
        Else
            MessageBox.Show("Eror : Hanya admin yang bisa akses.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'SendingJurnalTest()
    End Sub

    Private Sub SendingJurnalTest()
        ProgressBar1.Value = 0
        Dim procent As Integer = 0
        Dim persen As Integer = 0
        Dim keterangan As String = ""
        Dim flag As String = ""
        Dim KetLokasi As String = ""
        Dim NoUrut As String = ""
        Dim bsa As String = ""
        Dim Tnow As Date = DateTimePickerTanggalTransaksi.Value
        Dim Tquery As String = ""
        Dim Tlokasigl As New DataTable
        Dim CoaPiutangPending As String = ""
        Dim CoaJenisBayar As String = ""

        Dim queryBuilder As New StringBuilder()

        queryBuilder.AppendLine("SELECT t2.JumlahBayar, t2.JenisTransaksi, t2.JenisBayar, t2.[Tanggal Transaksi]")
        queryBuilder.AppendLine("FROM (")
        queryBuilder.AppendLine("    SELECT SUM(b.JumlahBayar) AS 'JumlahBayar', 'LAB' AS 'JenisTransaksi', b.JenisBayar, CONVERT(DATE, TglLab) AS 'Tanggal Transaksi'")
        queryBuilder.AppendLine("    FROM TransaksiLab a")
        queryBuilder.AppendLine("    LEFT JOIN TransaksiLabBayar b ON a.TransLabID = b.TransLabID")
        queryBuilder.AppendLine("    WHERE a.deleted <> 1 AND a.SendKeu IS NOT NULL AND CONVERT(DATE, TglLab) = '" & Format(Tnow.Date, "MM/dd/yyyy") & "' AND b.JenisBayar = 'TAGIHAN' AND b.JumlahBayar > 0 AND a.FlagJurnalHarianTagihan IS NULL")
        queryBuilder.AppendLine("    GROUP BY b.JenisBayar, CONVERT(DATE, TglLab)")
        queryBuilder.AppendLine("    UNION")
        queryBuilder.AppendLine("    SELECT SUM(t1.Tagihan) AS 'JumlahBayar', t1.JenisTransaksi, t1.JenisBayar, t1.[Tanggal Transaksi]")
        queryBuilder.AppendLine("    FROM (")
        queryBuilder.AppendLine("        SELECT t1.TransPoliID AS 'Translabid', t1.NoJenisBayar, t1.[No Lab], CONVERT(DATE, t1.[Tanggal Transaksi]) AS 'Tanggal Transaksi', SUM(t1.Tagihan) AS 'Tagihan', t1.kartu, t1.mesin, t1.JenisTransaksi, t1.JenisBayar")
        queryBuilder.AppendLine("        FROM (")
        queryBuilder.AppendLine("            SELECT c.TransPoliIDBayar AS 'No', a.TransPoliID, c.NoJenisBayar, a.NoUrut AS 'No Lab', CONVERT(DATE, a.TglPoli) AS 'Tanggal Transaksi', c.JumlahBayar - c.Kembali AS 'Tagihan', c.kartu, c.mesin, 'POLI' AS 'JenisTransaksi', c.JenisBayar")
        queryBuilder.AppendLine("            FROM TransaksiPoli a")
        queryBuilder.AppendLine("            LEFT JOIN TransaksiPoliBayar c ON a.TransPoliID = c.TransPoliID")
        queryBuilder.AppendLine("            WHERE a.deleted <> 1 AND c.JenisBayar = 'TAGIHAN' AND c.JumlahBayar > 0")
        queryBuilder.AppendLine("            UNION")
        queryBuilder.AppendLine("            SELECT c.TransPoliIDBayar AS 'No', a.TransPoliID, c.NoJenisBayar, a.NoUrut AS 'No Lab', CONVERT(DATE, a.TglPoli) AS 'Tanggal Transaksi', c.JumlahBayar - c.Kembali AS 'Tagihan', c.kartu, c.mesin, 'POLI' AS 'JenisTransaksi', c.JenisBayar")
        queryBuilder.AppendLine("            FROM TransaksiPoli a")
        queryBuilder.AppendLine("            LEFT JOIN TransaksiPoliBayarAwal c ON a.TransPoliID = c.TransPoliID")
        queryBuilder.AppendLine("            WHERE a.deleted <> 1 AND c.JenisBayar = 'TAGIHAN' AND c.JumlahBayar > 0")
        queryBuilder.AppendLine("        ) AS t1")
        queryBuilder.AppendLine("        GROUP BY t1.TransPoliID, t1.NoJenisBayar, t1.[No Lab], CONVERT(DATE, t1.[Tanggal Transaksi]), t1.kartu, t1.mesin, t1.JenisTransaksi, t1.JenisBayar")
        queryBuilder.AppendLine("        UNION")
        queryBuilder.AppendLine("        SELECT t1.TransGigiID AS 'Translabid', t1.NoJenisBayar, t1.[No Lab], CONVERT(DATE, t1.[Tanggal Transaksi]) AS 'Tanggal Transaksi', SUM(t1.Tagihan) AS 'Tagihan', t1.kartu, t1.mesin, t1.JenisTransaksi, t1.JenisBayar")
        queryBuilder.AppendLine("        FROM (")
        queryBuilder.AppendLine("            SELECT c.TransGigiIDBayar AS 'No', a.TransGigiID, c.NoJenisBayar, a.NoUrut AS 'No Lab', CONVERT(DATE, a.TglGigi) AS 'Tanggal Transaksi', c.JumlahBayar - c.Kembali AS 'Tagihan', c.kartu, c.mesin, 'GIGI' AS 'JenisTransaksi', c.JenisBayar")
        queryBuilder.AppendLine("            FROM TransaksiGigi a")
        queryBuilder.AppendLine("            LEFT JOIN TransaksiGigiBayar c ON a.TransGigiID = c.TransGigiID")
        queryBuilder.AppendLine("            WHERE a.deleted <> 1 AND c.JenisBayar = 'TAGIHAN' AND c.JumlahBayar > 0")
        queryBuilder.AppendLine("            UNION")
        queryBuilder.AppendLine("            SELECT c.TransGigiIDBayar AS 'No', a.TransGigiID, c.NoJenisBayar, a.NoUrut AS 'No Lab', CONVERT(DATE, a.TglGigi) AS 'Tanggal Transaksi', c.JumlahBayar - c.Kembali AS 'Tagihan', c.kartu, c.mesin, 'GIGI' AS 'JenisTransaksi', c.JenisBayar")
        queryBuilder.AppendLine("            FROM TransaksiGigi a")
        queryBuilder.AppendLine("            LEFT JOIN TransaksiGigiBayarAwal c ON a.TransGigiID = c.TransGigiID")
        queryBuilder.AppendLine("            WHERE a.deleted <> 1 AND c.JenisBayar = 'TAGIHAN' AND c.JumlahBayar > 0")
        queryBuilder.AppendLine("        ) AS t1")
        queryBuilder.AppendLine("        GROUP BY t1.TransGigiID, t1.NoJenisBayar, t1.[No Lab], CONVERT(DATE, t1.[Tanggal Transaksi]), t1.kartu, t1.mesin, t1.JenisTransaksi, t1.JenisBayar")
        queryBuilder.AppendLine("        UNION")
        queryBuilder.AppendLine("        SELECT a.TransAdminID AS 'Translabid', c.NoJenisBayar, CAST(a.TransAdminID AS CHAR(10)) AS 'No Lab', CONVERT(DATE, a.TindakanTgl) AS 'Tanggal Transaksi', c.JumlahBayar - c.Kembali AS 'Tagihan', c.mesin, c.kartu, 'DLL' AS 'JenisTransaksi', c.JenisBayar")
        queryBuilder.AppendLine("        FROM TransaksiAdmin a")
        queryBuilder.AppendLine("        LEFT JOIN TransaksiAdminBayar c ON a.TransAdminID = c.TransAdminID")
        queryBuilder.AppendLine("        WHERE a.deleted <> 1 AND c.JenisBayar = 'TAGIHAN' AND c.JumlahBayar > 0")
        queryBuilder.AppendLine("    ) AS t1")
        queryBuilder.AppendLine("    WHERE CONVERT(DATE, t1.[Tanggal Transaksi]) = '" & Format(Tnow.Date, "MM/dd/yyyy") & "'")
        queryBuilder.AppendLine("    GROUP BY t1.JenisTransaksi, t1.JenisBayar, t1.[Tanggal Transaksi]")
        queryBuilder.AppendLine(") AS t2")
        queryBuilder.AppendLine("ORDER BY t2.[Tanggal Transaksi], t2.JenisTransaksi")

        Dim Tloc As String = NoPoli
        Dim TKode As String = ReadSQLNIK("SELECT RIGHT(StrValue, 3) FROM MsConfig WHERE ConfigName='KodeInvoiceLab'")
        Dim TKodeBarcode As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='KodeBarcode'")
        Dim TblsGL As DataTable = ReadSQL(queryBuilder.ToString())
        If TblsGL.Rows.Count > 0 Then
            For Each Trow As DataRow In TblsGL.Rows
                persen = persen + 1
                procent = persen * 100 / TblsGL.Rows.Count
                ProgressBar2.Value = procent

                Tlokasigl = ReadThemysql("SELECT a.locgl, a.locket FROM masterlokasigl a WHERE a.loc='" & Tloc & "' AND a.jenistransaksi='" & Trow("JenisTransaksi") & "'", DB_Keuangan)
                Dim Trowlokasigl As DataRow = Tlokasigl.Rows(0)
                bsa = Trowlokasigl("locgl")
                KetLokasi = Trowlokasigl("locket")

                NoUrut = ReadSQLNIK("SELECT myFlag FROM getFlagPendapatan('%" & TKodeBarcode & DateTime.ParseExact(Trow("Tanggal Transaksi"), "M/d/yyyy", Nothing).ToString("yyMM") & "%')")

                If IsDBNull(NoUrut) = False And NoUrut <> "" And NoUrut <> "-" Then
                    flag = "" & TKodeBarcode & DateTime.ParseExact(Trow("Tanggal Transaksi"), "M/d/yyyy", Nothing).ToString("yyMM") & TKode & NoUrut.ToString().PadLeft(4, "0") & ""
                Else
                    flag = "" & TKodeBarcode & DateTime.ParseExact(Trow("Tanggal Transaksi"), "M/d/yyyy", Nothing).ToString("yyMM") & TKode & "0001"
                End If

                keterangan = "TERIMA - TAGIHAN " & KetLokasi & " " & DateTime.ParseExact(Trow("Tanggal Transaksi"), "M/d/yyyy", Nothing).ToString("dd/MM/yyyy") & ""

                'Jenis Transaksi
                If Trow("JenisTransaksi").ToString.Trim = "DLL" Then
                    CoaJenisBayar = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPendapatanAdmin'", DB_Keuangan2)
                    CoaPiutangPending = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPiutangPendingAdmin'", DB_Keuangan2)
                ElseIf Trow("JenisTransaksi").ToString.Trim = "GIGI" Then
                    CoaJenisBayar = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPendapatanGigi'", DB_Keuangan2)
                    CoaPiutangPending = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPiutangPendingGigi'", DB_Keuangan2)
                ElseIf Trow("JenisTransaksi").ToString.Trim = "LAB" Then
                    CoaJenisBayar = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPendapatanLab'", DB_Keuangan2)
                    CoaPiutangPending = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPiutangPendingLab'", DB_Keuangan2)
                ElseIf Trow("JenisTransaksi").ToString.Trim = "POLI" Then
                    CoaJenisBayar = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPendapatanKlinik'", DB_Keuangan2)
                    CoaPiutangPending = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPiutangPendingKlinik'", DB_Keuangan2)
                End If

                WriteThemysql("SELECT F_MakeUMH('" & flag & "', 'out', '', '" & DateTime.ParseExact(Trow("Tanggal Transaksi"), "M/d/yyyy", Nothing).ToString("yyyy-MM-dd") & "', '" & CoaJenisBayar & "', '" & CoaPiutangPending & "', 'IDR', 1, " & CDbl(Trow("JumlahBayar")) & ", '" & keterangan.ToUpper() & "', '1', 1, '', '" & keterangan.ToUpper() & "', '', '', '" & bsa & "', 4, " & CDbl(Trow("JumlahBayar")) & ", 'K')", DB_Jurnal)

                'Flag Ke Transaksi
                If Trow("JenisTransaksi").ToString.Trim = "LAB" Then
                    WriteSQL("UPDATE TransaksiLab SET FlagJurnalHarianTagihan = '" & flag & "' WHERE deleted <> 1 AND SendKeu IS NOT NULL AND (CONVERT(DATE, TglLab) = '" & DateTime.ParseExact(Trow("Tanggal Transaksi"), "M/d/yyyy", Nothing).ToString("yyyy-MM-dd") & "') AND FlagJurnalHarianTagihan IS NULL AND TransLabID in (SELECT TransLabID FROM TransaksiLabBayar WHERE JenisBayar = 'TAGIHAN')", 4)
                ElseIf Trow("JenisTransaksi").ToString.Trim = "GIGI" Then
                    WriteSQL("UPDATE TransaksiGigi SET FlagJurnalHarianTagihan = '" & flag & "' WHERE deleted <> 1 AND FlagJurnalHarianTagihan IS NULL AND (CONVERT(DATE, TglGigi) = '" & DateTime.ParseExact(Trow("Tanggal Transaksi"), "M/d/yyyy", Nothing).ToString("yyyy-MM-dd") & "') AND (TransGigiID in (SELECT TransGigiID FROM TransaksiGigiBayar WHERE JenisBayar = 'TAGIHAN') OR TransGigiID in (SELECT TransGigiID FROM TransaksiGigiBayarAwal WHERE JenisBayar = 'TAGIHAN'))", 4)
                ElseIf Trow("JenisTransaksi").ToString.Trim = "DLL" Then
                    WriteSQL("UPDATE TransaksiAdmin SET FlagJurnalHarianTagihan = '" & flag & "' WHERE deleted <> 1 AND FlagJurnalHarianTagihan IS NULL  AND (CONVERT(DATE, TindakanTgl) = '" & DateTime.ParseExact(Trow("Tanggal Transaksi"), "M/d/yyyy", Nothing).ToString("yyyy-MM-dd") & "') AND TransAdminID in (SELECT TransAdminID FROM TransaksiAdminBayar WHERE JenisBayar = 'TAGIHAN')", 4)
                ElseIf Trow("JenisTransaksi").ToString.Trim = "POLI" Then
                    WriteSQL("UPDATE TransaksiPoli SET FlagJurnalHarianTagihan = '" & flag & "' WHERE deleted <> 1 AND FlagJurnalHarianTagihan IS NULL AND (CONVERT(DATE, TglPoli) = '" & DateTime.ParseExact(Trow("Tanggal Transaksi"), "M/d/yyyy", Nothing).ToString("yyyy-MM-dd") & "') AND (TransPoliID in (SELECT TransPoliID FROM TransaksiPoliBayar WHERE JenisBayar = 'TAGIHAN') OR TransPoliID in (SELECT TransPoliID FROM TransaksiPoliBayarAwal WHERE JenisBayar = 'TAGIHAN'))", 4)
                End If

                'Save Log
                WriteSQL("INSERT INTO LogJurnalKeuangan (JurnalFlag,JurnalDate,JurnalBy,Status,JenisTransaksi) VALUES ('" & flag & "', getdate(), '" & PoliKlinik.Lbluser.Text & "', 'JURNAL TAGIHAN HARIAN', '" & Trow("JenisTransaksi").ToString.Trim & "')", 4)
            Next
        End If
    End Sub
End Class