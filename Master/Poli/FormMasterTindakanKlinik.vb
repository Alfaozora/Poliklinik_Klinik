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
Imports System.Threading

Public Class FormMasterTindakanKlinik
    Private userInput As String = PoliKlinik.Lbluser.Text
    Private DB_Poliklinik As TLcon

    Private Sub PanelTop_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelTop.Paint
        Try
            e.Graphics.DrawString("Master Tindakan Klinik", New Font("Segoe UI Semibold", 15, FontStyle.Bold), Brushes.White, New Point(10, 3))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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

    Private Sub FormMasterTindakanKlinik_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Control.CheckForIllegalCrossThreadCalls = False
            Me.MdiParent = PoliKlinik
            Me.Dock = DockStyle.Fill

            SetClear()
            SetConnection()

            '# Hide tab header button
            TabControl1.Appearance = TabAppearance.FlatButtons
            TabControl1.ItemSize = New Size(0, 1)
            TabControl1.SizeMode = TabSizeMode.Fixed
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMenu1.Click, btnMenu2.Click
        Try
            Dim myButton = DirectCast(sender, Button)

            Select Case myButton.Name
                Case "btnMenu1"
                    TabControl1.SelectedTab = TabPage1
                Case "btnMenu2"
                    TabControl1.SelectedTab = TabPage2
                Case "btnMenu3"
                    TabControl1.SelectedTab = TabPage3
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub SetClear()
        RadioButtonOpsiPersentase.Checked = True
        RadioButtonNonBHP.Checked = True
        TextBoxPersentaseFeeKaryawan.ResetText()
        TextBoxPersentaseFeePerusahaan.ResetText()
        TextBoxNominalFee.ResetText()
        TextBoxMaksimalBHP.ResetText()

        TextBoxTindakanID.ResetText()
        TextBoxNamaTindakan.ResetText()
        InsertNewItemComboSQL("  select distinct JenisTindakan  from MasterTindakan ", ComboBoxGroupJenisTindakan)
        ComboBoxGroupJenisTindakan.ResetText()
        InsertNewItemComboSQL("SELECT DISTINCT StrValue FROM MsConfig WHERE ConfigName = 'jenis_pelaksana'", ComboBoxPelaksanaTindakan)
        ComboBoxPelaksanaTindakan.ResetText()
        TextBoxBiayaTindakan.Text = "0"
        CheckBoxStatusAktifTindakan.Checked = False
        dttindakannow.Value = DateAndTime.Now
        RadioButtonNonAktifFee.Checked = True
        TextBoxFeeDokterTambahan.Text = "0"
        TextBoxFeePerawatTambahan.Text = "0"
        ComboBoxGroupJenisTindakan.SelectedIndex = -1
        ComboBoxPelaksanaTindakan.SelectedIndex = -1
    End Sub

    Public Sub LoadTindakanPoli(ByRef Txid As String)
        SetClear()
        TextBoxTindakanID.Text = Txid
        Dim Tbls As DataTable = ReadSQL("select * from MasterTindakan where tindakanid='" & Txid & "'")
        Dim Trow As DataRow = Tbls.Rows(0)
        TextBoxNamaTindakan.Text = Trow("NamaTindakan").ToString
        ComboBoxGroupJenisTindakan.Text = Trow("JenisTindakan").ToString
        ComboBoxPelaksanaTindakan.Text = Trow("JenisDokter").ToString
        TextBoxBiayaTindakan.Text = Trow("BiayaTindakan")

        '#Set Status Aktif Fee Tindakan
        If Convert.ToInt32(Trow("StatusFeeTindakan")) = 1 Then RadioButtonAktifFee.Checked = True
        If Convert.ToInt32(Trow("StatusFeeTindakan")) = 0 Then RadioButtonNonAktifFee.Checked = True

        '#Set Status Persentase / Nominal
        If Convert.ToInt32(Trow("StatusPersentaseFee")) = 1 Then RadioButtonOpsiPersentase.Checked = True
        If Convert.ToInt32(Trow("StatusNominalFee")) = 1 Then RadioButtonOpsiNominal.Checked = True

        '#Set Status BHP
        If Convert.ToInt32(Trow("StatusBHP")) = 1 Then RadioButtonBHP.Checked = True
        If Convert.ToInt32(Trow("StatusBHP")) = 0 Then RadioButtonNonBHP.Checked = True

        '#Set Value
        If IsDBNull(Trow("PersentaseFeePerusahaan")) = False Then TextBoxPersentaseFeePerusahaan.Text = Trow("PersentaseFeePerusahaan")
        If IsDBNull(Trow("PersentaseFeeKaryawan")) = False Then TextBoxPersentaseFeeKaryawan.Text = Trow("PersentaseFeeKaryawan")
        If IsDBNull(Trow("FeePerTindakan")) = False Then TextBoxNominalFee.Text = Trow("FeePerTindakan")
        If IsDBNull(Trow("MaksimalBHP")) = False Then TextBoxMaksimalBHP.Text = Trow("MaksimalBHP")

        If IsDBNull(Trow("FeeDokter")) = False Then TextBoxFeeDokterTambahan.Text = Trow("FeeDokter")
        If IsDBNull(Trow("FeePerawat")) = False Then TextBoxFeePerawatTambahan.Text = Trow("FeePerawat")

        If Trow("Closed") = True Then CheckBoxStatusAktifTindakan.Checked = True
        If IsDBNull(Trow("ClosedDate")) = False Then dttindakannow.Value = Trow("ClosedDate") Else dttindakannow.Value = DateAndTime.Now
    End Sub

    Function CheckingPoli() As Boolean
        '#Cek angka kurang dari 0
        If Val(TextBoxBiayaTindakan.Text) <= 0 Then MsgBox("Biaya harus lebih besar dari 0.", MsgBoxStyle.Exclamation, "Warning!") : Return False

        '#Cek cmb dokter
        If ComboBoxPelaksanaTindakan.FindStringExact(ComboBoxPelaksanaTindakan.Text) < 0 Then MsgBox("Pilih Jenis Dokter yang menangani.", MsgBoxStyle.Exclamation, "Warning!") : Return False

        '#Cek nama tindakan
        If TextBoxNamaTindakan.Text = "" Then MsgBox("Nama Tindakan Harus diisi.", MsgBoxStyle.Exclamation, "Warning!") : Return False

        '#Cek jenis tindakan
        If ComboBoxGroupJenisTindakan.FindStringExact(ComboBoxGroupJenisTindakan.Text) < 0 Then
            If MsgBox("Tindakan group menu baru ?", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then
                MsgBox("Pilih tindakan group yang sesuai.", MsgBoxStyle.Exclamation, "Warning!") : Return False
            End If
        End If

        '#Cek Persentase & Nominal Tindakan
        If RadioButtonAktifFee.Checked = True And ComboBoxGroupJenisTindakan.Text.Contains("Konsultasi") = False Then
            If RadioButtonOpsiPersentase.Checked = True And (Val(TextBoxPersentaseFeeKaryawan.Text) = 0 Or Val(TextBoxPersentaseFeePerusahaan.Text) = 0) Then
                MsgBox("Isi nilai presentase terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!") : Return False
            ElseIf RadioButtonOpsiNominal.Checked = True And Val(TextBoxNominalFee.Text) = 0 Then
                MsgBox("Isi nilai fee tindakan terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!") : Return False
            End If
        End If

        '# Cek Maksimal BHP jika memilih BHP
        If RadioButtonBHP.Checked = True And Val(TextBoxMaksimalBHP.Text) = 0 And ComboBoxGroupJenisTindakan.Text.Contains("Konsultasi") = False Then
            MsgBox("Isi maksimal BHP terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        End If

        '#Cek status closed
        If CheckBoxStatusAktifTindakan.CheckState = CheckState.Checked And TextBoxTindakanID.Text <> "" Then
            If CheckSQL("select * from MasterTindakan where Tindakanid='" & TextBoxTindakanID.Text & "' and Closed=0") = True Then
                If MsgBox("Yakin Tindakan diclosed ? ", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then
                    MsgBox("Mohon ubah status closed tindakan.", MsgBoxStyle.Exclamation, "Warning!")
                    Return False
                End If
            End If
        End If

        '#Cek nama tindakan sudah ada atau belum
        If TextBoxTindakanID.Text <> "" Then
            If CheckSQL("select * from MasterTindakan where Closed = 0 and [NamaTindakan]='" & TextBoxNamaTindakan.Text & "' and [JenisTindakan]='" & ComboBoxGroupJenisTindakan.Text & "' and TindakanID not in ('" & TextBoxTindakanID.Text & "')") = True Then
                MsgBox("Sudah ada 'Nama Tindakan' dan 'Jenis Tindakan' yang sama. Mohon check kembali.", MsgBoxStyle.Exclamation, "Warning!")
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub rdfeeya_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonAktifFee.CheckedChanged, RadioButtonNonAktifFee.CheckedChanged
        If RadioButtonAktifFee.Checked = True Then
            TextBoxFeeDokterTambahan.Enabled = True
            TextBoxFeePerawatTambahan.Enabled = True
            TextBoxPersentaseFeeKaryawan.Enabled = True
            TextBoxPersentaseFeePerusahaan.Enabled = True
            RadioButtonBHP.Enabled = True
            RadioButtonNonBHP.Enabled = True
            TextBoxFeePerawatTambahan.Enabled = True
            TextBoxFeeDokterTambahan.Enabled = True
            RadioButtonOpsiPersentase.Enabled = True
            RadioButtonOpsiNominal.Enabled = True
            TextBoxNominalFee.Enabled = True
        ElseIf RadioButtonNonAktifFee.Checked = True Then
            TextBoxFeeDokterTambahan.Enabled = False
            TextBoxFeePerawatTambahan.Enabled = False
            TextBoxFeeDokterTambahan.Text = "0"
            TextBoxFeePerawatTambahan.Text = "0"
            TextBoxPersentaseFeeKaryawan.Enabled = False
            TextBoxPersentaseFeePerusahaan.Enabled = False
            RadioButtonBHP.Enabled = False
            RadioButtonNonBHP.Enabled = False
            TextBoxFeePerawatTambahan.Enabled = False
            TextBoxFeeDokterTambahan.Enabled = False
            RadioButtonOpsiPersentase.Enabled = False
            RadioButtonOpsiNominal.Enabled = False
            TextBoxNominalFee.Enabled = False
            TextBoxPersentaseFeeKaryawan.ResetText()
            TextBoxPersentaseFeePerusahaan.ResetText()
            TextBoxNominalFee.ResetText()
            TextBoxFeeDokterTambahan.ResetText()
            TextBoxFeePerawatTambahan.ResetText()
        End If
    End Sub

    Private Sub onlyNumber_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxFeeDokterTambahan.KeyPress, TextBoxFeePerawatTambahan.KeyPress, TextBoxNominalFee.KeyPress, TextBoxPersentaseFeePerusahaan.KeyPress, TextBoxPersentaseFeeKaryawan.KeyPress, TextBoxNominalFee.KeyPress, TextBoxBiayaTindakan.KeyPress, TextBoxMaksimalBHP.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub


    Private Sub rdPresentase_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonOpsiPersentase.CheckedChanged, RadioButtonOpsiNominal.CheckedChanged
        If RadioButtonOpsiPersentase.Checked = True Then
            TextBoxPersentaseFeePerusahaan.Enabled = True
            TextBoxPersentaseFeeKaryawan.Enabled = True
            TextBoxNominalFee.Enabled = False
            TextBoxNominalFee.ResetText()
        ElseIf RadioButtonOpsiNominal.Checked = True Then
            TextBoxPersentaseFeePerusahaan.Enabled = False
            TextBoxPersentaseFeeKaryawan.Enabled = False
            TextBoxNominalFee.Enabled = True
            TextBoxPersentaseFeeKaryawan.ResetText()
            TextBoxPersentaseFeePerusahaan.ResetText()
        End If
    End Sub

    Private Sub rdfeebhp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonBHP.CheckedChanged, RadioButtonNonBHP.CheckedChanged
        If RadioButtonBHP.Checked = True Then
            TextBoxMaksimalBHP.Enabled = True
        ElseIf RadioButtonNonBHP.Checked = True Then
            TextBoxMaksimalBHP.Enabled = False
            TextBoxMaksimalBHP.ResetText()
        End If
    End Sub

    Private Sub ButtonClearMenu1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SetClear()
    End Sub

    Private Sub SetClearGigi()
        txidtindakangigi.ResetText()
        txnamatindakangigi.ResetText()
        InsertNewItemComboSQL("  select distinct JenisTindakan  from MasterTindakanGigi ", cmbjenistindakangigi)
        cmbjenistindakangigi.ResetText()
        chkmulti.Checked = False
        txtindakanbiaya.Text = "0"
        CheckBoxStatusAktifTindakan.Checked = False
        txkettindakangigi.ResetText()
    End Sub

    Public Sub LoadTindakan(ByRef Txid As String)
        SetClear()
        txidtindakangigi.Text = Txid
        Dim Tbls As DataTable = ReadSQL("select * from MasterTindakanGigi where tindakanid='" & Txid & "'")
        Dim Trow As DataRow = Tbls.Rows(0)
        txnamatindakangigi.Text = Trow("NamaTindakan").ToString
        cmbjenistindakangigi.Text = Trow("JenisTindakan").ToString
        chkmulti.Checked = Trow("MultiGigi")
        txtindakanbiaya.Text = Trow("BiayaTindakan")
        txkettindakangigi.Text = Trow("TindakanKet").ToString
        If Trow("Aktif") = False Then CheckBoxStatusAktifTindakan.Checked = True
    End Sub

    Function CheckingGigi() As Boolean
        If IsNumeric(txtindakanbiaya.Text) = False Then
            MsgBox("Biaya harus angka")
            Return False
        Else
            If txtindakanbiaya.Text <= 0 Then
                MsgBox("Biaya harus lebih besar dari 0 ")
                Return False
            End If
        End If

        If cmbjenistindakangigi.FindStringExact(cmbjenistindakangigi.Text) < 0 Then
            If MsgBox("Tindakan group menu baru ?", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then
                MsgBox("Pilih tindakan group yang sesuai")
                Return False
            End If
        End If

        If CheckBoxStatusAktifTindakan.CheckState = CheckState.Checked And txidtindakangigi.Text <> "" Then
            If CheckSQL("select * from MasterTindakanGigi where TindakanID='" & txidtindakangigi.Text & "' and Aktif=0") = True Then
                If MsgBox("Yakin Tindakan diclosed ? ", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then
                    MsgBox("Mohon ubah status closed tindakan.")
                    Return False
                End If
            End If
        End If

        If txnamatindakangigi.Text = "" Then
            MsgBox("Nama Tindakan harus diisi")
            Return False
        End If

        If txidtindakangigi.Text <> "" Then
            If CheckSQL("select * from MasterTindakanGigi where [NamaTindakan]='" & txnamatindakangigi.Text & "' and [JenisTindakan]='" & cmbjenistindakangigi.Text & "' and TindakanID not in ('" & txidtindakangigi.Text & "')") = True Then
                MsgBox("Sudah ada 'Nama Tindakan' dan 'Jenis Tindakan' yang sama. Mohon check kembali")
                Return False
            End If
        End If

        If txkettindakangigi.Text = "" Then txkettindakangigi.Text = "-"

        Return True
    End Function

    Private Sub ButtonFindTindakanPoli_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFindTindakan.Click
        Find.Show()
        Find.Query(" SELECT [TindakanID],[NamaTindakan],[JenisTindakan],[BiayaTindakan],[Closed],[JenisDokter],[ClosedDate] from [MasterTindakan] ", " order by TindakanID ", "FindMasterTindakanKlinik2", 2)
    End Sub

    Private Sub ButtonFindTindakanGigi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFindTindakanGigi.Click
        Find.Show()
        Find.Query(" select TindakanID,NamaTindakan,JenisTindakan,MultiGigi,BiayaTindakan,TindakanKet,Aktif  from MasterTindakanGigi ", " order by JenisTindakan,NamaTindakan", "Findgigi", 2)
    End Sub

    Private Sub ButtonSimpanPoliUmum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSimpanPoliUmum.Click
        If CheckingPoli() = True Then
            Dim statusFee As Boolean = False
            Dim statusPresentase As Boolean = False
            Dim statusNominal As Boolean = False
            Dim statusBHP As Boolean = False
            Dim statusFeeKonsultasi As Boolean = False

            '#Set Status Aktif Fee Tindakan
            If RadioButtonAktifFee.Checked = True Then statusFee = True

            If statusFee = True And ComboBoxGroupJenisTindakan.Text.Contains("Konsultasi") = False Then
                '#Set Status Presentase / Nominal
                If RadioButtonOpsiPersentase.Checked = True Then statusPresentase = True
                If RadioButtonOpsiNominal.Checked = True Then statusNominal = True

                '#Set Status BHP
                If RadioButtonBHP.Checked = True Then statusBHP = True
            Else
                statusPresentase = False
                statusNominal = False
                statusBHP = False
                statusFeeKonsultasi = True
            End If

            If TextBoxTindakanID.Text = "" Then
                '#Insert Data Baru 
                Dim Tcheck As String = "False"
                If CheckBoxStatusAktifTindakan.CheckState = CheckState.Checked Then Tcheck = "True"
                WriteSQL("insert into MasterTindakan ([NamaTindakan],[JenisTindakan],[BiayaTindakan],[Closed],[JenisDokter],[UpdateDate],[UpdateBy],[StatusFeeTindakan],[StatusBHP],[StatusPersentaseFee],[StatusNominalFee],[PersentaseFeePerusahaan],[PersentaseFeeKaryawan],[FeePerTindakan],[FeeDokter],[FeePerawat],[StatusFeeKonsultasi],[MaksimalBHP]) " & _
                         "values('" & TextBoxNamaTindakan.Text & "','" & ComboBoxGroupJenisTindakan.Text & "'," & CInt(TextBoxBiayaTindakan.Text) & ",'" & Tcheck & "','" & ComboBoxPelaksanaTindakan.Text & "','" & Format(DateAndTime.Now, "MM/dd/yyyy") & "','" & PoliKlinik.Lbluser.Text & "', '" & statusFee & "', '" & statusBHP & "', '" & statusPresentase & "', " & _
                         "'" & statusNominal & "', '" & Val(TextBoxPersentaseFeePerusahaan.Text) & "', '" & Val(TextBoxPersentaseFeeKaryawan.Text) & "', '" & Val(TextBoxNominalFee.Text) & "', '" & Val(TextBoxFeeDokterTambahan.Text) & "', '" & Val(TextBoxFeePerawatTambahan.Text) & "', '" & statusFeeKonsultasi & "', '" & Val(TextBoxMaksimalBHP.Text) & "')", 4)
                TextBoxTindakanID.Text = ReadSQLNIK("select tindakanid from MasterTindakan where NamaTindakan='" & TextBoxNamaTindakan.Text & "' and JenisTindakan='" & ComboBoxGroupJenisTindakan.Text & "' and JenisDokter='" & ComboBoxPelaksanaTindakan.Text & "' and BiayaTindakan=" & CInt(TextBoxBiayaTindakan.Text) & " and UpdateBy='" & PoliKlinik.Lbluser.Text & "'")
                If Tcheck = "True" Then WriteSQL("update MasterTindakan set ClosedDate='" & Format(dttindakannow.Value, "MM/dd/yyyy") & "' where tindakanid='" & TextBoxTindakanID.Text & "'", 4)

                MsgBox("Berhasil Menyimpan Data.", MsgBoxStyle.Information, "Success!")
            Else
                '#Update Data
                Dim Tcheck As String = "False"
                If CheckBoxStatusAktifTindakan.CheckState = CheckState.Checked Then Tcheck = "True"
                WriteSQL("update MasterTindakan set [NamaTindakan]='" & TextBoxNamaTindakan.Text & "',[JenisTindakan]='" & ComboBoxGroupJenisTindakan.Text & "',[BiayaTindakan]=" & CInt(TextBoxBiayaTindakan.Text) & ",[Closed]='" & Tcheck & "',[JenisDokter]='" & ComboBoxPelaksanaTindakan.Text & "',[UpdateDate]='" & Format(DateAndTime.Now, "MM/dd/yyyy") & "', " & _
                         "[UpdateBy]='" & PoliKlinik.Lbluser.Text & "',[StatusFeeTindakan]='" & statusFee & "',[StatusBHP]='" & statusBHP & "',[StatusPersentaseFee]='" & statusPresentase & "',[StatusNominalFee]='" & statusNominal & "',[FeeDokter]='" & Val(TextBoxFeeDokterTambahan.Text) & "',[FeePerawat]='" & Val(TextBoxFeePerawatTambahan.Text) & "', " & _
                         "[PersentaseFeePerusahaan]='" & Val(TextBoxPersentaseFeePerusahaan.Text) & "',[PersentaseFeeKaryawan]='" & Val(TextBoxPersentaseFeeKaryawan.Text) & "',[FeePerTindakan]='" & Val(TextBoxNominalFee.Text) & "',[MaksimalBHP]='" & Val(TextBoxMaksimalBHP.Text) & "',[StatusFeeKonsultasi]='" & statusFeeKonsultasi & "' where TindakanID='" & TextBoxTindakanID.Text & "'", 4)
                If Tcheck = "True" Then WriteSQL("update MasterTindakan set ClosedDate='" & Format(dttindakannow.Value, "MM/dd/yyyy") & "' where tindakanid='" & TextBoxTindakanID.Text & "'", 4)

                MsgBox("Berhasil Mengupdate Data.", MsgBoxStyle.Information, "Success!")
                SetClear()
            End If
        End If
    End Sub

    Private Sub ButtonCetakPoliUmum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCetakPoliUmum.Click
        Report = New XtraReport
        Report = XtraReport.FromFile(Application.StartupPath + "\reports\MasterTindakan.repx", True)
        Report.DataSource = ReadSQL("SELECT [TindakanID] as ID,[NamaTindakan],[JenisTindakan],PARSENAME(CONVERT(varchar,convert(money,[BiayaTindakan]),1),2) as [BiayaTindakan] ,case when [Closed]=0 then 1 else 0 end as Closed,[JenisDokter] from [MasterTindakan] order by tindakanid")
        Report.Bands.Item(BandKind.ReportHeader).Controls("lbltanggal").Text = "Data per : " & Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm")
        Report.Bands.Item(BandKind.ReportHeader).Controls("lbladmin").Text = ""
        'Report.Bands.Item(BandKind.ReportFooter).Controls("lbltanggalacc").Text = ".............. ," & Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:sss")
        Report.Bands.Item(BandKind.ReportFooter).Controls("lbltanggalacc").Text = ""
        Report.Bands.Item(BandKind.ReportHeader).Controls("lbljenissetoran").Text = "MASTER JENIS TINDAKAN POLI"
        'Report.RunDesigner()
        Report.ShowPreview()
        'Report.Print()
    End Sub

    Private Sub ButtonDownloadMasterPoliUmum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDownloadMasterPoliUmum.Click
        Try
            ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf DownloadMasterTindakanPoliUmum))
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub DownloadMasterTindakanPoliUmum()
        Try
            Dim NomorPoli As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NoPoli'")
            Dim tblTindakan As DataTable = New DataTable
            Dim procent As Integer = 0
            Dim persen As Integer = 0

            tblTindakan = ReadThemysql("SELECT a.tindakanid, a.kodetindakan, a.namatindakan, a.jenistindakan, b.biayatindakan, a.keterangan, b.pelaksana, b.statusfeetindakan, b.jenisfeetindakan, " & _
                                       "b.persentasefeeperusahaan, b.persentasefeekaryawan, b.feepertindakan, b.statusbhp, b.maksimalbhp, b.feetambahandokter, b.feetambahanperawat, " & _
                                       "a.closed, a.closedby, a.closeddate, b.createdby, b.createddate, b.updatedby, b.updateddate " & _
                                       "FROM mastertindakanpoli a " & _
                                       "INNER JOIN mastertindakanpolidetail b ON a.kodetindakan = b.kodetindakan " & _
                                       "WHERE b.lokasitindakan = '" & NomorPoli & "' AND a.closed = 0 AND a.jenispoli = 'POLI UMUM'", DB_Poliklinik)

            If tblTindakan.Rows.Count > 0 Then
                Dim parameterUpdate As String = ""
                Dim statusFee As Boolean
                Dim statusPersentase As Boolean
                Dim statusNominal As Boolean
                Dim statusBHP As Boolean
                Dim statusFeeKonsultasi As Boolean
                Dim statusClosed As Boolean

                ProgressBar1.Visible = True

                For Each rowTindakan As DataRow In tblTindakan.Rows
                    persen = persen + 1
                    procent = persen * 100 / tblTindakan.Rows.Count
                    ProgressBar1.Value = procent

                    ' Set Status Aktif Fee Tindakan
                    statusFee = rowTindakan("statusfeetindakan")

                    ' Set Status Presentase / Nominal
                    If rowTindakan("jenisfeetindakan").ToString = "Persentase" Then
                        statusPersentase = True
                    ElseIf rowTindakan("jenisfeetindakan").ToString = "Nominal" Then
                        statusNominal = True
                    End If

                    ' Set Status BHP
                    statusBHP = rowTindakan("statusbhp")

                    ' Set Status Closed
                    statusClosed = rowTindakan("closed")

                    ' Set Status Fee Konsultasi (Belum Setting)
                    statusFeeKonsultasi = False

                    If CheckSQL("SELECT * FROM MasterTindakan_ WHERE KodeTindakan = '" & rowTindakan("kodetindakan").ToString & "'") = True Then
                        ' Update Data
                        parameterUpdate = "NamaTindakan = '" & rowTindakan("namatindakan").ToString.Trim & "'," & _
                                          "JenisTindakan = '" & rowTindakan("jenistindakan").ToString.Trim & "'," & _
                                          "BiayaTindakan = '" & CDbl(rowTindakan("biayatindakan").ToString.Trim) & "'," & _
                                          "JenisDokter = '" & rowTindakan("pelaksana").ToString.Trim & "'," & _
                                          "StatusFeeTindakan = '" & statusFee & "'," & _
                                          "StatusBHP = '" & statusBHP & "'," & _
                                          "StatusPersentaseFee = '" & statusPersentase & "'," & _
                                          "StatusNominalFee = '" & statusNominal & "'," & _
                                          "PersentaseFeePerusahaan = '" & rowTindakan("persentasefeeperusahaan").ToString.Trim & "'," & _
                                          "PersentaseFeeKaryawan = '" & rowTindakan("persentasefeekaryawan").ToString.Trim & "'," & _
                                          "FeePerTindakan = '" & rowTindakan("feepertindakan").ToString.Trim & "'," & _
                                          "MaksimalBHP = '" & rowTindakan("maksimalbhp").ToString.Trim & "'," & _
                                          "StatusFeeKonsultasi = '" & statusFeeKonsultasi & "'," & _
                                          "FeeDokter = '" & rowTindakan("feetambahandokter").ToString.Trim & "'," & _
                                          "FeePerawat = '" & rowTindakan("feetambahanperawat").ToString.Trim & "'," & _
                                          "Closed = '" & statusClosed & "'"

                        WriteSQL("UPDATE MasterTindakan_ SET " & parameterUpdate & " WHERE KodeTindakan = '" & rowTindakan("kodetindakan").ToString.Trim & "'", 4)
                    Else
                        ' Insert Data
                        WriteSQL("INSERT INTO MasterTindakan_ ([TindakanID], [KodeTindakan], [NamaTindakan], [JenisTindakan], [BiayaTindakan], [Closed], [JenisDokter], [StatusFeeTindakan], [StatusBHP], [StatusPersentaseFee], [StatusNominalFee], [PersentaseFeePerusahaan], [PersentaseFeeKaryawan], [FeePerTindakan], [FeeDokter], [FeePerawat], [StatusFeeKonsultasi], [MaksimalBHP]) " & _
                                 "VALUES('" & rowTindakan("tindakanid").ToString & "', '" & rowTindakan("kodetindakan").ToString & "', '" & rowTindakan("namatindakan").ToString & "','" & rowTindakan("jenistindakan").ToString & "'," & CInt(rowTindakan("biayatindakan").ToString) & ",'" & statusClosed & "','" & rowTindakan("pelaksana").ToString & "', '" & statusFee & "', '" & statusBHP & "', '" & statusPersentase & "', " & _
                                 "'" & statusNominal & "', '" & Val(rowTindakan("persentasefeeperusahaan").ToString) & "', '" & Val(rowTindakan("persentasefeekaryawan").ToString) & "', '" & Val(rowTindakan("feepertindakan").ToString) & "', '" & Val(rowTindakan("feetambahandokter").ToString) & "', '" & Val(rowTindakan("feetambahanperawat").ToString) & "', '" & statusFeeKonsultasi & "', '" & Val(rowTindakan("maksimalbhp").ToString) & "')", 4)
                    End If
                Next

                MsgBox("Master Tindakan Berhasil Update.", MsgBoxStyle.Information, "Success!")
            Else
                MsgBox("Data Not Found.", MsgBoxStyle.Exclamation, "Warning!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub ButtonSimpanPoliGigi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSimpanPoliGigi.Click
        If CheckingGigi() = True Then
            Dim Tcheck As String = "False"
            Dim Tmulti As String = "0"
            Dim Tjum As String = "1"

            If txidtindakangigi.Text = "" Then
                'new 
                If CheckBoxStatusAktifTindakan.CheckState = CheckState.Checked Then Tcheck = "True"
                If chkmulti.Checked = True Then Tmulti = "1"
                If chkmulti.Checked = True Then Tjum = "99"
                WriteSQL("insert into MasterTindakanGigi ([NamaTindakan],[MultiGigi],[TindakanKet],[BiayaTindakan],[Aktif],[JumlahGigi],[JenisTindakan],[CreateDate],[CreateBy],[Urutan]) " & _
                         " values('" & txnamatindakangigi.Text & "','" & Tmulti & "','" & txkettindakangigi.Text & "','" & CInt(txtindakanbiaya.Text) & "',1,'" & Tjum & "','" & cmbjenistindakangigi.Text & "','" & Format(DateAndTime.Now, "MM/dd/yyyy") & "','" & PoliKlinik.Lbluser.Text & "',0)", 1)
                txidtindakangigi.Text = ReadSQLNIK("select TindakanID from MasterTindakanGigi where NamaTindakan='" & txnamatindakangigi.Text & "' and JenisTindakan='" & cmbjenistindakangigi.Text & "' and BiayaTindakan=" & CInt(txtindakanbiaya.Text))
                If Tcheck = "True" Then WriteSQL("update MasterTindakan set Aktif=0 , Updatedate='" & Format(DateAndTime.Now, "MM/dd/yyyy") & "', UpdateBy='" & PoliKlinik.Lbluser.Text & "' where tindakanid='" & txidtindakangigi.Text & "'", 4)
            Else
                'update
                If CheckBoxStatusAktifTindakan.CheckState = CheckState.Checked Then Tcheck = "True"
                If chkmulti.Checked = True Then Tmulti = "1"
                If chkmulti.Checked = True Then Tjum = "99"
                WriteSQL("update MasterTindakanGigi set  [NamaTindakan]='" & txnamatindakangigi.Text & "' ,[MultiGigi]='" & Tmulti & "',[TindakanKet]='" & txkettindakangigi.Text & "' ,[BiayaTindakan]='" & CInt(txtindakanbiaya.Text) & "' ,[JumlahGigi]='" & Tjum & "', [JenisTindakan]='" & cmbjenistindakangigi.Text & "' ,[UpdateDate]='" & Format(DateAndTime.Now, "MM/dd/yyyy") & "',[UpdateBy]='" & PoliKlinik.Lbluser.Text & "'  where  TindakanID='" & txidtindakangigi.Text & "'", 2)
                If Tcheck = "True" Then WriteSQL("update MasterTindakanGigi set Aktif=0 , Updatedate='" & Format(DateAndTime.Now, "MM/dd/yyyy") & "', UpdateBy='" & PoliKlinik.Lbluser.Text & "' where tindakanid='" & txidtindakangigi.Text & "'", 4) Else WriteSQL("update MasterTindakanGigi set Aktif=1 , Updatedate='" & Format(DateAndTime.Now, "MM/dd/yyyy") & "', UpdateBy='" & PoliKlinik.Lbluser.Text & "' where tindakanid='" & txidtindakangigi.Text & "'", 4)
            End If
        End If
    End Sub

    Private Sub ButtonCetakPoliGigi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCetakPoliGigi.Click
        Report = New XtraReport
        Report = XtraReport.FromFile(Application.StartupPath + "\reports\MasterTindakanGigi.repx", True)
        Report.DataSource = ReadSQL("  SELECT [TindakanID] as ID,[NamaTindakan],[JenisTindakan],PARSENAME(CONVERT(varchar,convert(money,[BiayaTindakan]),1),2) as [BiayaTindakan],[Aktif],'-' as [JenisDokter] from [MasterTindakanGigi] order by tindakanid")
        Report.Bands.Item(BandKind.ReportHeader).Controls("lbltanggal").Text = "Data per : " & Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm")
        Report.Bands.Item(BandKind.ReportHeader).Controls("lbladmin").Text = ""
        'Report.Bands.Item(BandKind.ReportFooter).Controls("lbltanggalacc").Text = ".............. ," & Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:sss")
        Report.Bands.Item(BandKind.ReportFooter).Controls("lbltanggalacc").Text = ""
        Report.Bands.Item(BandKind.ReportHeader).Controls("lbljenissetoran").Text = "MASTER JENIS TINDAKAN GIGI"
        'Report.RunDesigner()
        Report.ShowPreview()
        'Report.Print()
    End Sub

    Private Sub ButtonClearPoliGigi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClearPoliGigi.Click
        SetClearGigi()
    End Sub

    Private Sub ButtonDownloadMasterPoliGigi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDownloadMasterPoliGigi.Click
        Try
            'ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf DownloadMasterTindakanPoliGigi))
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub DownloadMasterTindakanPoliGigi()
        Try
            Dim NomorPoli As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'NoPoli'")
            Dim tblTindakan As DataTable = New DataTable
            Dim procent As Integer = 0
            Dim persen As Integer = 0

            tblTindakan = ReadThemysql("SELECT a.tindakanid, a.kodetindakan, a.namatindakan, a.jenistindakan, b.biayatindakan, a.keterangan, b.pelaksana, b.statusfeetindakan, b.jenisfeetindakan, " & _
                                       "b.persentasefeeperusahaan, b.persentasefeekaryawan, b.feepertindakan, b.statusbhp, b.maksimalbhp, b.feetambahandokter, b.feetambahanperawat, " & _
                                       "a.closed, a.closedby, a.closeddate, b.createdby, b.createddate, b.updatedby, b.updateddate " & _
                                       "FROM mastertindakanpoli a " & _
                                       "INNER JOIN mastertindakanpolidetail b ON a.kodetindakan = b.kodetindakan " & _
                                       "WHERE b.lokasitindakan = '" & NomorPoli & "' AND a.closed = 0 AND a.jenispoli = 'POLI GIGI'", DB_Poliklinik)

            If tblTindakan.Rows.Count > 0 Then
                Dim parameterUpdate As String = ""
                Dim statusFee As Boolean
                Dim statusPersentase As Boolean
                Dim statusNominal As Boolean
                Dim statusBHP As Boolean
                Dim statusFeeKonsultasi As Boolean
                Dim statusClosed As Boolean

                ProgressBar1.Visible = True

                For Each rowTindakan As DataRow In tblTindakan.Rows
                    persen = persen + 1
                    procent = persen * 100 / tblTindakan.Rows.Count
                    ProgressBar1.Value = procent

                    ' Set Status Aktif Fee Tindakan
                    statusFee = rowTindakan("statusfeetindakan")

                    ' Set Status Presentase / Nominal
                    If rowTindakan("jenisfeetindakan").ToString = "Persentase" Then
                        statusPersentase = True
                    ElseIf rowTindakan("jenisfeetindakan").ToString = "Nominal" Then
                        statusNominal = True
                    End If

                    ' Set Status BHP
                    statusBHP = rowTindakan("statusbhp")

                    ' Set Status Closed
                    statusClosed = rowTindakan("closed")

                    ' Set Status Fee Konsultasi (Belum Setting)
                    statusFeeKonsultasi = False

                    If CheckSQL("SELECT * FROM MasterTindakan_ WHERE KodeTindakan = '" & rowTindakan("kodetindakan").ToString & "'") = True Then
                        ' Update Data
                        parameterUpdate = "NamaTindakan = '" & rowTindakan("namatindakan").ToString.Trim & "'," & _
                                          "JenisTindakan = '" & rowTindakan("jenistindakan").ToString.Trim & "'," & _
                                          "BiayaTindakan = '" & CDbl(rowTindakan("biayatindakan").ToString.Trim) & "'," & _
                                          "JenisDokter = '" & rowTindakan("pelaksana").ToString.Trim & "'," & _
                                          "StatusFeeTindakan = '" & statusFee & "'," & _
                                          "StatusBHP = '" & statusBHP & "'," & _
                                          "StatusPersentaseFee = '" & statusPersentase & "'," & _
                                          "StatusNominalFee = '" & statusNominal & "'," & _
                                          "PersentaseFeePerusahaan = '" & rowTindakan("persentasefeeperusahaan").ToString.Trim & "'," & _
                                          "PersentaseFeeKaryawan = '" & rowTindakan("persentasefeekaryawan").ToString.Trim & "'," & _
                                          "FeePerTindakan = '" & rowTindakan("feepertindakan").ToString.Trim & "'," & _
                                          "MaksimalBHP = '" & rowTindakan("maksimalbhp").ToString.Trim & "'," & _
                                          "StatusFeeKonsultasi = '" & statusFeeKonsultasi & "'," & _
                                          "FeeDokter = '" & rowTindakan("feetambahandokter").ToString.Trim & "'," & _
                                          "FeePerawat = '" & rowTindakan("feetambahanperawat").ToString.Trim & "'," & _
                                          "Closed = '" & statusClosed & "'"

                        WriteSQL("UPDATE MasterTindakan_ SET " & parameterUpdate & " WHERE KodeTindakan = '" & rowTindakan("kodetindakan").ToString.Trim & "'", 4)
                    Else
                        ' Insert Data
                        WriteSQL("INSERT INTO MasterTindakan_ ([TindakanID], [KodeTindakan], [NamaTindakan], [JenisTindakan], [BiayaTindakan], [Closed], [JenisDokter], [StatusFeeTindakan], [StatusBHP], [StatusPersentaseFee], [StatusNominalFee], [PersentaseFeePerusahaan], [PersentaseFeeKaryawan], [FeePerTindakan], [FeeDokter], [FeePerawat], [StatusFeeKonsultasi], [MaksimalBHP]) " & _
                                 "VALUES('" & rowTindakan("tindakanid").ToString & "', '" & rowTindakan("kodetindakan").ToString & "', '" & rowTindakan("namatindakan").ToString & "','" & rowTindakan("jenistindakan").ToString & "'," & CInt(rowTindakan("biayatindakan").ToString) & ",'" & statusClosed & "','" & rowTindakan("pelaksana").ToString & "', '" & statusFee & "', '" & statusBHP & "', '" & statusPersentase & "', " & _
                                 "'" & statusNominal & "', '" & Val(rowTindakan("persentasefeeperusahaan").ToString) & "', '" & Val(rowTindakan("persentasefeekaryawan").ToString) & "', '" & Val(rowTindakan("feepertindakan").ToString) & "', '" & Val(rowTindakan("feetambahandokter").ToString) & "', '" & Val(rowTindakan("feetambahanperawat").ToString) & "', '" & statusFeeKonsultasi & "', '" & Val(rowTindakan("maksimalbhp").ToString) & "')", 4)
                    End If
                Next

                MsgBox("Master Tindakan Berhasil Update.", MsgBoxStyle.Information, "Success!")
            Else
                MsgBox("Data Not Found.", MsgBoxStyle.Exclamation, "Warning!")
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub ButtonClearPoliUmum_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClearPoliUmum.Click
        SetClear()
    End Sub
End Class