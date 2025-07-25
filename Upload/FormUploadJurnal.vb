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
Imports System.Drawing

Public Class FormUploadJurnal
    Private thread As System.Threading.Thread
    Private formName As String = "FORM UPLOAD JURNAL"
    Private userInput As String = PoliKlinik.Lbluser.Text

    ' Variabel Connection
    Private DB_Jurnal As TLcon
    Private DB_Keuangan As TLcon
    Private DB_Keuangan2 As TLcon
    Private DB_Poliklinik As TLcon

    Private Sub PanelTop_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelTop.Paint
        Try
            e.Graphics.DrawString(formName, New Font("Arial", 12, FontStyle.Bold), Brushes.White, New Point(10, 10))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FormUploadJurnal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.MdiParent = PoliKlinik
            Me.Dock = DockStyle.Fill

            Control.CheckForIllegalCrossThreadCalls = False

            ' Set Connection
            SetConnectionFromConfig()
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub ButtonClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClose.Click
        Me.Close()
    End Sub

    Private Sub SetConnectionFromConfig()
        ' Set DB Jurnal
        DB_Jurnal.Tip = Utility.GetConfig("ServerJurnal_IP")
        DB_Jurnal.Tid = Utility.GetConfig("ServerJurnal_UserID")
        DB_Jurnal.Tpass = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerJurnal_Password"), "albert")
        DB_Jurnal.Tdb = Utility.GetConfig("ServerJurnal_DB")

        ' Set Parameter Server Online
        Dim serverOnline_IP As String = Utility.GetConfig("ServerOnline_IP")
        Dim serverOnline_UserID As String = Utility.GetConfig("ServerOnline_UserID")
        Dim serverOnline_Password As String = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerOnline_Password"), "albert")

        ' Set DB Keuangan (mitramed_keu)
        DB_Keuangan.Tip = serverOnline_IP
        DB_Keuangan.Tid = serverOnline_UserID
        DB_Keuangan.Tpass = serverOnline_Password
        DB_Keuangan.Tdb = Utility.GetConfig("ServerOnlineKeuangan_DB")


        ' Set DB Keuangan 2 (mitramed_keu2019)
        DB_Keuangan2.Tip = serverOnline_IP
        DB_Keuangan2.Tid = serverOnline_UserID
        DB_Keuangan2.Tpass = serverOnline_Password
        DB_Keuangan2.Tdb = Utility.GetConfig("ServerOnlineKeuangan2_DB")

        ' Set DB Poliklinik
        DB_Poliklinik.Tip = serverOnline_IP
        DB_Poliklinik.Tid = serverOnline_UserID
        DB_Poliklinik.Tpass = serverOnline_Password
        DB_Poliklinik.Tdb = Utility.GetConfig("ServerOnlinePoli_DB")
    End Sub

    Private Sub ButtonKirimJurnal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonKirimJurnal.Click
        'SendingJurnal("0254/MMC-BUL/X/2023")
        thread = New System.Threading.Thread(AddressOf KirimData)
        thread.Start()
    End Sub

    Private Sub SendingJurnal(ByRef noTagihan As String)
        Dim keterangan As String = ""
        Dim keteranganUMH As String = ""
        Dim flag As String = ""
        Dim KetLokasi As String = ""
        Dim Nourut As String = ""
        Dim bsa As String = ""
        Dim JenisTransaksi As String = ""
        Dim Tlokasigl As New DataTable
        Dim Tloc As String = ""
        Dim CoaPiutangPending As String = ""
        Dim CoaPiutang As String = ""

        Dim queryString As New StringBuilder()
        queryString.AppendLine("SELECT * FROM acctransrekaptagihan a")
        queryString.AppendLine("LEFT JOIN acctranspelunasantagihan b ON a.lunasid = b.lunasid")
        queryString.AppendLine("WHERE a.lunasid <> 0 AND a.notagihancompany = '" & noTagihan & "';")

        Dim tblTagihan As DataTable = ReadThemysql(queryString.ToString(), DB_Keuangan)

        'Dim Tbls As DataTable = GridControl1.DataSource
        Dim TrowInv As DataRow = tblTagihan.Rows(0)

        Dim CoaBank As String = TrowInv("coa")
        'Dim Tsplit() As String = txcompnama.Text.Split("-")

        'Dim Tbls As DataTable = GridControl1.DataSource
        'Dim TrowInv As DataRow = Tbls.Rows(0)
        JenisTransaksi = TrowInv("JenisTransaksi")
        Tloc = TrowInv("cabang")

        Tlokasigl = ReadThemysql("SELECT a.locgl, a.locket FROM masterlokasigl a WHERE a.loc='" & Tloc & "' AND a.jenistransaksi='" & JenisTransaksi & "'", DB_Keuangan)
        Dim Trowlokasigl As DataRow = Tlokasigl.Rows(0)
        bsa = Trowlokasigl("locgl")
        KetLokasi = Trowlokasigl("locket")

        'Set DB Berdasarkan Lokasi di GL
        DB_Jurnal.Tdb = ReadThemysqlNIK("SELECT a.db_gl FROM mastercodebarcode a WHERE a.kodecabang = '" & Tloc & "';", DB_Poliklinik)

        Nourut = ReadThemysqlNIK(" SELECT concat(lpad(LEFT(t1.Jurnal,5)+1,5,0)) FROM (" & _
                 " SELECT a.FlagJurnalPembayaran AS 'Jurnal' FROM acctransrekaptagihan a" & _
                 " WHERE a.FlagJurnalPembayaran LIKE '%" & Format(TrowInv("lunastgl"), "yy/MM") & "/OL%' AND a.FlagJurnalPembayaran IS NOT NULL" & _
                 " UNION" & _
                 " SELECT FlagJurnalCancel AS 'Jurnal' FROM acctransrekaptagihan a" & _
                 " WHERE a.FlagJurnalCancel LIKE '%" & Format(TrowInv("lunastgl"), "yy/MM") & "/OL%' AND a.FlagJurnalCancel IS NOT NULL) AS t1" & _
                 " ORDER BY LEFT(t1.Jurnal,5) DESC LIMIT 1", DB_Keuangan)

        If IsDBNull(Nourut) = False And Nourut <> "" And Nourut <> "-" Then
            flag = "" & Nourut.Trim & "/" & Format(TrowInv("lunastgl"), "yy/MM") & "/OL"
        Else
            flag = "00001/" & Format(TrowInv("lunastgl"), "yy/MM") & "/OL"
        End If

        keterangan = "TERIMA - PEMBAYARAN TAGIHAN " & TrowInv("kartu") & " " & KetLokasi & " " & Format(TrowInv("tgltagihan"), "dd/MM/yyyy") & " (NO. INVOICE : " & TrowInv("notagihancompany") & ")"
        keteranganUMH = "TERIMA - TAGIHAN " & TrowInv("kartu") & " " & KetLokasi & " " & Format(TrowInv("tgltagihan"), "dd/MM/yyyy") & " (NO. INVOICE : " & TrowInv("notagihancompany") & ")"

        If JenisTransaksi = "POLI" Then
            CoaPiutang = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPiutangKlinik'", DB_Keuangan2)
            CoaPiutangPending = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPiutangPendingKlinik'", DB_Keuangan2)
        ElseIf JenisTransaksi = "GIGI" Then
            CoaPiutang = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPiutangGigi'", DB_Keuangan2)
            CoaPiutangPending = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPiutangPendingGigi'", DB_Keuangan2)
        ElseIf JenisTransaksi = "DLL" Then
            CoaPiutang = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPiutangAdmin'", DB_Keuangan2)
            CoaPiutangPending = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPiutangPendingAdmin'", DB_Keuangan2)
        ElseIf JenisTransaksi = "LAB" Then
            CoaPiutang = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPiutangLab'", DB_Keuangan2)
            CoaPiutangPending = ReadThemysqlNIK("SELECT a.value FROM mastersetting a WHERE a.name='CoaPiutangPendingLab'", DB_Keuangan2)
        End If

        'Search Detail COA
        Dim CoaDetail As String = ""
        Dim CoaDetailNilai As Integer = 0
        Dim JurnalKAS As String = ""
        Dim CoaDetailKeterangan As String = ""
        Dim TblsCoa As DataTable = ReadThemysql("SELECT * FROM acctranspelunasantagihandetail a WHERE a.lunasid = '" & TrowInv("lunasid") & "'", DB_Keuangan)
        TblsCoa.AcceptChanges()
        If TblsCoa.Rows.Count > 0 Then
            For Each TrowCoa As DataRow In TblsCoa.Rows
                CoaDetail = TrowCoa("coaid")
                CoaDetailNilai = TrowCoa("nilai")
                CoaDetailKeterangan = TrowCoa("coadetail")
            Next
        End If

        'Send To GL
        If CheckThemysql("SELECT * FROM acctransrekaptagihan WHERE FlagJurnalCreateTagihan <> 1 AND RekapID = '" & TrowInv("RekapID") & "'", DB_Keuangan) = True Then
            WriteThemysql("SELECT F_MakeUMH('" & flag & "', 'out', '', '" & Format(TrowInv("tgltagihan"), "yyyy-MM-dd") & "', '" & CoaPiutangPending & "', '" & CoaPiutang & "', 'IDR', 1, " & CDbl(TrowInv("lunasnilai")) & ", '" & keteranganUMH.ToUpper() & "', '1', 1, '', '" & keteranganUMH.ToUpper() & "', '', '', '" & bsa & "', 4, " & CDbl(TrowInv("lunasnilai")) & ", 'K')", DB_Jurnal)

            'Flag Tabel acctransrekaptagihan field FlagJurnalCreateTagihan
            WriteThemysql("UPDATE acctransrekaptagihan a SET a.FlagJurnalCreateTagihan = '" & flag & "' WHERE a.rekapid = '" & TrowInv("RekapID") & "'", DB_Keuangan)
        End If

        WriteThemysql("SELECT F_MakeBKM('" & flag & "', 'out', '', '" & Format(TrowInv("lunastgl"), "yyyy-MM-dd") & "', '" & CoaBank & "', '" & CoaPiutang & "', 'IDR', 1, " & CDbl(TrowInv("lunasnilai")) & ", '" & keterangan.ToUpper() & "', '1', 1, '', '" & keterangan.ToUpper() & "', '', '', '" & bsa & "', 4, " & CDbl(TrowInv("lunasnilai")) & ", 'K')", DB_Jurnal)

        If TblsCoa.Rows.Count > 0 Then
            JurnalKAS = ReadThemysqlNIK("SELECT a.kas as a FROM kas a WHERE a.oms='" & flag & "'", DB_Jurnal)
            WriteThemysql("SELECT F_MakeBKM('" & flag & "', 'out', '" & JurnalKAS & "', '" & Format(TrowInv("lunastgl"), "yyyy-MM-dd") & "', '" & CoaPiutang & "', '" & CoaDetail & "', 'IDR', 1, " & CDbl(CoaDetailNilai) & ", '" & CoaDetailKeterangan.ToUpper() & "', '1', 2, '', '" & CoaDetailKeterangan.ToUpper() & "', '', '', '" & bsa & "', 4, " & CDbl(CoaDetailNilai) & ", 'D')", DB_Jurnal)
        End If

        'Flag Tabel acctransrekaptagihan field FlagJurnalPembayaran
        WriteThemysql("UPDATE acctransrekaptagihan a SET a.FlagJurnalPembayaran = '" & flag & "' WHERE a.rekapid = '" & TrowInv("RekapID") & "'", DB_Keuangan)

        'Save Log
        WriteThemysql("INSERT INTO logjurnalkeuangan (JurnalFlag,JurnalDate,JurnalBy,Status,JenisTransaksi,Cabang) VALUES ('" & flag & "', NOW(), '" & PoliKlinik.Lbluser.Text & "', 'JURNAL PEMBAYARAN TAGIHAN (" & TrowInv("notagihancompany") & ")', '" & JenisTransaksi & "', '" & Tloc & "')", DB_Keuangan)

        'MsgBox("Success.")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        thread = New System.Threading.Thread(AddressOf SearchData)
        thread.Start()
    End Sub

    Private Sub SearchData()
        Try
            Dim procent As Integer = 0
            Dim persen As Integer = 0

            TextBoxResponse.ResetText()
            Dim jumlahTransaksi As Integer = 0

            Dim queryString As New StringBuilder()
            queryString.AppendLine("SELECT a.* FROM acctransrekaptagihan a")
            queryString.AppendLine("LEFT JOIN acctranspelunasantagihan b ON a.lunasid = b.lunasid")
            queryString.AppendLine("WHERE a.lunasid <> 0 AND (DATE(b.createdate) BETWEEN '" & Format(tglAwal.Value, "yyyyMMdd") & "' AND '" & Format(tglAkhir.Value, "yyyyMMdd") & "');")

            Dim tblTagihan As DataTable = ReadThemysql(queryString.ToString(), DB_Keuangan)

            For Each rowTagihan As DataRow In tblTagihan.Rows
                persen = persen + 1

                'Set DB Berdasarkan Lokasi di GL
                DB_Jurnal.Tdb = ReadThemysqlNIK("SELECT a.db_gl FROM mastercodebarcode a WHERE a.kodecabang = '" & rowTagihan("cabang") & "';", DB_Poliklinik)

                If CheckThemysql("SELECT * FROM kas a WHERE a.oms = '" & rowTagihan("FlagJurnalPembayaran") & "' AND a.remark LIKE '%" & rowTagihan("notagihancompany") & "%';", DB_Jurnal) = False Then
                    'If rowTagihan("FlagJurnalCreateTagihan") <> "1" Then
                    '    If CheckThemysql("SELECT * FROM umh a WHERE a.oms = '" & rowTagihan("FlagJurnalCreateTagihan") & "' AND a.remark LIKE '%" & rowTagihan("notagihancompany") & "%';", DB_Jurnal) = False Then
                    '        TextBoxResponse.Text += "Data " & rowTagihan("notagihancompany") & " (" & rowTagihan("FlagJurnalPembayaran") & ") gagal." + vbCrLf
                    '    End If
                    'End If

                    TextBoxResponse.Text += "Data " & rowTagihan("notagihancompany") & " (" & rowTagihan("FlagJurnalPembayaran") & ") gagal." + vbCrLf
                    jumlahTransaksi = jumlahTransaksi + 1
                End If

                procent = persen * 100 / tblTagihan.Rows.Count
                ProgressBarSinkronisasi.Value = procent
            Next

            If jumlahTransaksi > 0 Then
                MsgBox(jumlahTransaksi & " data ditemukan.", MsgBoxStyle.Critical, "Error")
            Else
                MsgBox("Tidak ada data yang ditemukan.", MsgBoxStyle.Critical, "Error")
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub KirimData()
        Try
            Dim procent As Integer = 0
            Dim persen As Integer = 0

            TextBoxResponse.ResetText()
            Dim jumlahTransaksi As Integer = 0

            Dim queryString As New StringBuilder()
            queryString.AppendLine("SELECT a.* FROM acctransrekaptagihan a")
            queryString.AppendLine("LEFT JOIN acctranspelunasantagihan b ON a.lunasid = b.lunasid")
            queryString.AppendLine("WHERE a.lunasid <> 0 AND (DATE(b.createdate) BETWEEN '" & Format(tglAwal.Value, "yyyyMMdd") & "' AND '" & Format(tglAkhir.Value, "yyyyMMdd") & "');")

            Dim tblTagihan As DataTable = ReadThemysql(queryString.ToString(), DB_Keuangan)

            For Each rowTagihan As DataRow In tblTagihan.Rows
                persen = persen + 1

                'Set DB Berdasarkan Lokasi di GL
                DB_Jurnal.Tdb = ReadThemysqlNIK("SELECT a.db_gl FROM mastercodebarcode a WHERE a.kodecabang = '" & rowTagihan("cabang") & "';", DB_Poliklinik)

                If CheckThemysql("SELECT * FROM kas a WHERE a.oms = '" & rowTagihan("FlagJurnalPembayaran") & "' AND a.remark LIKE '%" & rowTagihan("notagihancompany") & "%';", DB_Jurnal) = False Then
                    'If rowTagihan("FlagJurnalCreateTagihan") <> "1" Then
                    '    If CheckThemysql("SELECT * FROM umh a WHERE a.oms = '" & rowTagihan("FlagJurnalCreateTagihan") & "' AND a.remark LIKE '%" & rowTagihan("notagihancompany") & "%';", DB_Jurnal) = False Then
                    '        TextBoxResponse.Text += "Data " & rowTagihan("notagihancompany") & " (" & rowTagihan("FlagJurnalPembayaran") & ") gagal." + vbCrLf
                    '    End If
                    'End If

                    SendingJurnal(rowTagihan("notagihancompany"))

                    TextBoxResponse.Text += "Data " & rowTagihan("notagihancompany") & " (" & rowTagihan("FlagJurnalPembayaran") & ") berhasil dikirim." + vbCrLf
                    jumlahTransaksi = jumlahTransaksi + 1
                End If

                procent = persen * 100 / tblTagihan.Rows.Count
                ProgressBarSinkronisasi.Value = procent
            Next

            If jumlahTransaksi > 0 Then
                MsgBox(jumlahTransaksi & " data berhasil dikirim.", MsgBoxStyle.Information, "Error")
            Else
                MsgBox("Tidak ada data yang ditemukan.", MsgBoxStyle.Critical, "Error")
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class