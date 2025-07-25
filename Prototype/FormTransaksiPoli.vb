Imports System.Text

Public Class FormTransaksiPoli
    Private totalRowStruk As Integer = 0
    Private idTransaksi As String ' Berisi No Transaksi
    Private jenisTransaksi As String ' Berisi Jenis Transaksi UMUM / GIGI
    Private userInput As String = PoliKlinik.Lbluser.Text ' User input program

    ' Menyimpan jumlah transaksi pending terakhir
    Private lastPendingCount As Integer = 0

    Private Sub SetClearHeader()
        idTransaksi = ""
        jenisTransaksi = ""
        TextBoxNoUrutTransaksi.ResetText()
        dtnow.Value = DateAndTime.Now
        TextBoxNoRekamMedis.ResetText()
        TextBoxNamaPasien.ResetText()
        TextBoxNamaPoli.ResetText()
        TextBoxUmurPasien.ResetText()
        dtcusttgllhr.Value = DateSerial("9998", "12", "31")
        chkclosed.Checked = False
        ButtonSimpanTransaksi.Enabled = True
        TextBoxNamaDokter.ResetText()
        TextBoxTotalPembulatan.Enabled = True
    End Sub

    Private Sub SetClearGrid()
        Dim Tbls As DataTable = New DataTable

        If jenisTransaksi = "UMUM" Or jenisTransaksi = "" Then
            WriteSQL("DELETE FROM TransaksiPoliDetail WHERE TransPoliID = 0", 4)
            Tbls = ReadSQL("SELECT TransPoliIDDetail, TindakanID, NamaTindakan AS Tindakan, JenisTindakan AS Jenis, PARSENAME(CONVERT(varchar, CONVERT(money, BiayaTindakan), 1), 2) AS [Biaya Tindakan], PARSENAME(CONVERT(varchar, CONVERT(money, DiscTindakan), 1), 2) AS DiscTindakan, PARSENAME(CONVERT(varchar, CONVERT(money, DiscPersenTindakan), 1), 2) AS DiscNilai, PARSENAME(CONVERT(varchar, CONVERT(money, NettBayar), 1), 2) AS NettBayar, Penjamin " & _
                           "FROM TransaksiPoliDetail " & _
                           "WHERE DeletedDate IS NULL AND JenisTindakan NOT LIKE '%Konsultasi%' AND TransPoliID = '" & idTransaksi & "' AND GroupBayar = ''")
        ElseIf jenisTransaksi = "GIGI" Then
            WriteSQL("DELETE FROM TransaksiGigiDetail WHERE TransGigiID = 0", 4)
            Tbls = ReadSQL("SELECT TransGigiIDDetail AS 'TransPoliIDDetail', TindakanID, NamaTindakan AS Tindakan, JenisTindakan AS Jenis, PARSENAME(CONVERT(varchar, CONVERT(money, BiayaTindakan), 1), 2) AS [Biaya Tindakan], PARSENAME(CONVERT(varchar, CONVERT(money, DiscTindakan), 1), 2) AS DiscTindakan, PARSENAME(CONVERT(varchar, CONVERT(money, DiscPersenTindakan), 1), 2) AS DiscNilai, PARSENAME(CONVERT(varchar, CONVERT(money, NettBayar), 1), 2) AS NettBayar, Penjamin " & _
                           "FROM TransaksiGigiDetail  " & _
                           "WHERE DeletedDate IS NULL AND TransGigiID = '" & idTransaksi & "' AND GroupBayar = '' AND Awal = 0")
        End If

        For Each Tcol As DataColumn In Tbls.Columns
            Tcol.ReadOnly = True
        Next

        Tbls.Columns("DiscNilai").ReadOnly = False
        Tbls.Columns("DiscTindakan").ReadOnly = False
        gridtindakan.DataSource = Tbls
        GridView1.Columns("TindakanID").Visible = False
        GridView1.Columns("TransPoliIDDetail").Visible = False
    End Sub

    Private Sub SetClearFooter()
        TextBoxTotalBruto.Text = 0
        TextBoxTotalDiskon.Text = 0
        TextBoxTotalNett.Text = 0
        TextBoxTotalPembulatan.Text = 0
        TextBoxTotalBayar.Text = 0
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
        'FormTunggu.Close()
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        SetClearHeader()
        SetClearGrid()
        SetClearFooter()
        Kalkulasi()
    End Sub

    Private Sub TransaksiLab_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        Me.MdiParent = PoliKlinik
        Me.Dock = DockStyle.Fill
        NewToolStripMenuItem.PerformClick()
    End Sub

    'Private Sub TambahTindakanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TambahTindakanToolStripMenuItem.Click
    '    If idTransaksi <> "" Then
    '        Dim queryString As String = ""
    '        Dim queryOrderString As String = ""

    '        Select Case jenisTransaksi
    '            Case "UMUM"
    '                queryString = "SELECT TindakanID, NamaTindakan AS 'Nama', JenisTindakan AS 'Jenis', JenisDokter, PARSENAME(CONVERT(varchar, CONVERT(money, BiayaTindakan), 1), 2) AS [Biaya Tindakan] " & _
    '                              "FROM MasterTindakan " & _
    '                              "WHERE Closed = 0 AND JenisTindakan NOT LIKE '%Konsultasi%'"
    '                queryOrderString = " ORDER BY JenisTindakan, NamaTindakan"
    '            Case "GIGI"
    '                queryString = "SELECT TindakanID, TindakanNama AS 'Nama', JenisTindakan AS 'Jenis', PARSENAME(CONVERT(varchar, CONVERT(money, TindakanHarga), 1), 2) AS [Biaya Tindakan] " & _
    '                              "FROM MasterTindakanGigi " & _
    '                              "WHERE Aktif = 1 AND JenisTindakan NOT LIKE '%Konsultasi%'"
    '                queryOrderString = " ORDER BY JenisTindakan, TindakanNama"
    '        End Select


    '        FindMultiple.Show()
    '        FindMultiple.Query(queryString, queryOrderString, "FindTindakanFormTransaksiPoli", 1)
    '    Else
    '        MsgBox("Gagal. Pilih transaksi terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
    '    End If
    'End Sub

    Public Sub LoadFormTransaksiPoli(ByRef ID As String, ByRef JenisPoli As String)
        SetClearHeader()
        SetClearFooter()

        ' Set Jenis Transaksi UMUM / GIGI
        Dim tblPoli As DataTable = ReadSQL("SELECT * FROM MasterPoliTujuan WHERE NamaPoli = '" & JenisPoli & "'")
        Dim TrowPoli As DataRow = tblPoli.Rows(0)

        Dim queryString As String = ""

        Select Case TrowPoli("JenisPoli")
            Case "UMUM"
                queryString = "SELECT TransPoliID AS 'ID', nourut, TglPoli AS 'Tgl Transaksi', IDInternet, ClosedTransaksi, DokterPoli AS 'Nama Dokter', TotalTagihan, TotalDisc, NettBayar,Pembulatan " & _
                              "FROM TransaksiPoli WHERE TransPoliID = '" & ID & "'"
            Case "GIGI"
                queryString = "SELECT TransGigiID AS 'ID', nourut, TglGigi AS 'Tgl Transaksi', IDInternet, ClosedTransaksi, DokterGigi AS 'Nama Dokter', TotalTagihan, TotalDisc, NettBayar,Pembulatan " & _
                              "FROM TransaksiGigi WHERE TransGigiID = '" & ID & "'"
        End Select

        Dim Thead As DataTable = ReadSQL(queryString)
        Dim Rhead As DataRow = Thead.Rows(0)

        ' Set Variabel Global
        idTransaksi = Rhead("ID")
        jenisTransaksi = TrowPoli("JenisPoli")

        TextBoxNamaPoli.Text = TrowPoli("NamaPoli")
        TextBoxNoUrutTransaksi.Text = Rhead("nourut")
        dtnow.Value = Rhead("Tgl Transaksi")
        LoadPoliPasien(Rhead("IDInternet"))
        If Rhead("ClosedTransaksi") = True Then chkclosed.Checked = True Else chkclosed.Checked = False
        TextBoxNamaDokter.Text = Rhead("Nama Dokter")

        SetClearGrid()

        If chkclosed.CheckState = CheckState.Checked Then
            MsgBox("Transaksi tidak dapat di-edit.")
            ButtonSimpanTransaksi.Enabled = False
            TextBoxTotalPembulatan.Enabled = False
            TextBoxTotalBruto.Text = Rhead("TotalTagihan")
            TextBoxTotalDiskon.Text = Rhead("TotalDisc")
            TextBoxTotalBayar.Text = Rhead("NettBayar")
            TextBoxTotalPembulatan.Text = Rhead("Pembulatan")

        Else
            Kalkulasi()
            ButtonSimpanTransaksi.Enabled = True
        End If

        TextBoxTotalNett.Text = TextBoxTotalBayar.Text - TextBoxTotalPembulatan.Text
    End Sub

    Function CheckTambahTindakan(ByRef Trow() As DataRow)
        Dim Tbls As DataTable = gridtindakan.DataSource
        Tbls.AcceptChanges()
        If Trow.Count > 0 Then
            For i As Integer = 0 To Trow.Length - 1
                For Each Ttemp As DataRow In Tbls.Rows
                    If Ttemp("TindakanID") = Trow(i)("TindakanID") Then
                        MsgBox("Terdapat tindakan double. Sudah ada pada pilihan. Check kembali.")
                        Return False
                    End If
                Next
            Next
        End If
        Return True
    End Function

    Public Sub LoadTindakan(ByRef Trow() As DataRow)
        If CheckTambahTindakan(Trow) = True Then
            Dim Tbls As DataTable = gridtindakan.DataSource
            Tbls.AcceptChanges()
            If Trow.Count > 0 Then
                For i As Integer = 0 To Trow.Length - 1
                    Dim Tnew As DataRow = Tbls.NewRow
                    Tnew("TransPoliIDDetail") = "0"
                    Tnew("TindakanID") = Trow(i)("TindakanID")
                    Tnew("Nama") = Trow(i)("Nama")
                    Tnew("Jenis") = Trow(i)("Jenis")
                    Tnew("Biaya Tindakan") = Splitmoney(Trow(i)("Biaya Tindakan"))
                    Tnew("DiscTindakan") = 0
                    Tnew("DiscNilai") = 0
                    Tnew("NettBayar") = 0
                    Tbls.Rows.Add(Tnew)
                Next
                Tbls.AcceptChanges()
                Kalkulasi()
            End If
        End If
    End Sub

    Private Sub GridView1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles GridView1.KeyUp
        If e.KeyCode = Keys.Delete And GridView1.SelectedRowsCount > 0 Then
            Dim Trow As DataRow = GridView1.GetDataRow(GridView1.FocusedRowHandle)
            If MsgBox("Yakin menghapus Tindakan : " & Trow("Nama") & " ? ", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                If jenisTransaksi = "UMUM" Then
                    If Trow("TransPoliIDDetail") <> "0" Then WriteSQL("UPDATE TransaksiPoliDetail SET DeletedBy = '" & userInput & "', DeletedDate = GETDATE() WHERE TransPoliIDDetail = '" & Trow("TransPoliIDDetail") & "' AND TransPoliID = '" & idTransaksi & "' AND TindakanID = '" & Trow("TindakanID") & "' AND DeletedDate IS NULL", 4)
                ElseIf jenisTransaksi = "GIGI" Then
                    If Trow("TransPoliIDDetail") <> "0" Then WriteSQL("UPDATE TransaksiGigiDetail SET DeletedBy = '" & userInput & "', DeletedDate = GETDATE() WHERE TransGigiIDDetail = '" & Trow("TransPoliIDDetail") & "' AND TransGigiID = '" & idTransaksi & "' AND TindakanID = '" & Trow("TindakanID") & "' AND DeletedDate IS NULL", 4)
                End If

                GridView1.DeleteRow(GridView1.FocusedRowHandle)
                gridtindakan.RefreshDataSource()
                Kalkulasi()
            End If
        End If
    End Sub

    Public Sub LoadPoliPasien(ByRef txNoRM As String)
        Dim Tbls As DataTable = ReadSQL("SELECT * FROM MasterPasien WHERE NoRekamMedis = '" & txNoRM & "'")
        Dim Trow As DataRow = Tbls.Rows(0)

        TextBoxNoRekamMedis.Text = Trow("NoRekamMedis")
        TextBoxNamaPasien.Text = Trow("Nama")
        dtcusttgllhr.Value = Trow("TglLahir")
        TextBoxUmurPasien.Text = Umur(dtcusttgllhr.Value)
    End Sub

    Function Kalkulasi() As Boolean
        totalRowStruk = 1700

        Dim Tbls As DataTable = gridtindakan.DataSource
        Tbls.AcceptChanges()
        For Each Tcol As DataColumn In Tbls.Columns
            Tcol.ReadOnly = False
        Next

        For Each Trow As DataRow In Tbls.Rows
            totalRowStruk = totalRowStruk + 75
            If Trow("DiscTindakan") = "" Then Trow("DiscTindakan") = "0"
            If Trow("DiscNilai") = "" Then Trow("DiscNilai") = "0"

            If Trow("DiscNilai") <> "0" Then
                Trow("DiscTindakan") = Splitmoney(CDbl(Trow("DiscNilai") / Trow("Biaya Tindakan") * 100))
            ElseIf Trow("DiscTindakan") <> "0" Then
                Trow("DiscNilai") = Splitmoney(CDbl(Trow("Biaya Tindakan") * Trow("DiscTindakan") / 100))
            End If

            Trow("NettBayar") = Splitmoney(Trow("Biaya Tindakan") - Trow("DiscNilai"))


        Next

        For Each Tcol As DataColumn In Tbls.Columns
            Tcol.ReadOnly = True
        Next

        Tbls.Columns("DiscTindakan").ReadOnly = False
        Tbls.Columns("DiscNilai").ReadOnly = False

        Dim Tbruto As Double = 0
        Dim Tdisc As Double = 0
        Dim Tnett As Double = 0
        Dim Tbayar As Double = 0

        For Each Trow As DataRow In Tbls.Rows
            Tbruto = CDbl(Tbruto) + CDbl(Trow("Biaya Tindakan"))
            Tnett = CDbl(Tnett) + CDbl(Trow("NettBayar"))
            Tdisc = CDbl(Tdisc) + CDbl(Trow("DiscNilai"))
        Next

        Dim Tbulat As Double = 100 - (Tnett Mod 100)
        If Tbulat = 100 Then Tbulat = 0

        TextBoxTotalBruto.Text = Splitmoney(Tbruto)
        TextBoxTotalDiskon.Text = Splitmoney(Tdisc)
        TextBoxTotalNett.Text = Splitmoney(Tnett)
        TextBoxTotalPembulatan.Text = Splitmoney(Tbulat)
        TextBoxTotalBayar.Text = Splitmoney(Tbulat + Tnett)

        Return True
    End Function

    Function Checking() As Boolean

        If idTransaksi = "" Then
            MsgBox("ID Transaksi tidak boleh kosong. Pilih Tindakan ID yang ada")
            Return False
        End If

        If TextBoxNoRekamMedis.Text = "" Then
            MsgBox("Pasien tidak boleh kosong. Nama Pasien harus ada")
            Return False
        End If

        Dim Tbls As DataTable = gridtindakan.DataSource
        Tbls.AcceptChanges()

        If Tbls.Rows.Count <= 0 Then
            MsgBox("Tindakan tidak boleh kosong. Check kembali.")
            Return False
        End If

        Return True
    End Function

    Private Sub ButtonSimpanTransaksi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSimpanTransaksi.Click
        If Checking() = True And Kalkulasi() = True Then
            If MsgBox("Process pembayaran Transaksi ini ?", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                '# Set data dictionary yang akan dikirim ke form pembayaran
                Dim dataDictionary As New Dictionary(Of String, Object)()

                Dim Tbls As DataTable = gridtindakan.DataSource
                Tbls.AcceptChanges()

                'Kalkulasi()

                dataDictionary.Add("Jenis Transaksi", jenisTransaksi)
                dataDictionary.Add("ID Transaksi", idTransaksi)
                dataDictionary.Add("Poli Tujuan", TextBoxNamaPoli.Text)
                dataDictionary.Add("No Urut Transaksi", TextBoxNoUrutTransaksi.Text)
                dataDictionary.Add("No Rekam Medis", TextBoxNoRekamMedis.Text)
                dataDictionary.Add("Nama Pasien", TextBoxNamaPasien.Text)
                dataDictionary.Add("Nama Dokter", TextBoxNamaDokter.Text)

                FormPembayaran.DataDictionary = dataDictionary
                FormPembayaran.SetDataFromPendaftaran(TextBoxTotalBayar.Text, Tbls, TextBoxTotalBruto.Text, TextBoxTotalDiskon.Text, TextBoxTotalPembulatan.Text)
                FormPembayaran.ShowDialog()
            Else
                MsgBox("Canceled")
            End If
        End If
    End Sub

    Private Sub chkclosed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkclosed.CheckedChanged
        If chkclosed.CheckState = CheckState.Checked Then
            ButtonSimpanTransaksi.Enabled = False
        ElseIf chkclosed.CheckState = CheckState.Unchecked Then
            ButtonSimpanTransaksi.Enabled = True
        End If
    End Sub

    Private Sub txtotalpembulatan_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxTotalPembulatan.EditValueChanged
        If IsNumeric(TextBoxTotalPembulatan.Text) = True Then
            TextBoxTotalBayar.Text = Splitmoney(CInt(TextBoxTotalNett.Text) + TextBoxTotalPembulatan.Text)
        End If
    End Sub

    Private Sub butkalkulasi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butkalkulasi.Click
        Kalkulasi()
    End Sub

    Private Sub ButtonFindTransaksi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFindTransaksi.Click
        Dim Takhir As Date = DateSerial(DateAndTime.Now.Year, DateAndTime.Now.Month, DateAndTime.Now.Day)
        Dim Tawal As Date = DateAdd(DateInterval.Day, -200, Takhir.Date)

        Dim queryString As String = "SELECT * FROM ( " & _
                                    "SELECT a.TransPoliID as 'ID', c.JenisPoli, a.Nourut, a.IDInternet AS NoMitra, b.Nama, a.DokterPoli AS DokterPoli, CONVERT(VARCHAR, TglPoli, 120) AS TransactionDate " & _
                                    "FROM TransaksiPoli a " & _
                                    "LEFT JOIN TransaksiDetail c ON a.NoUrut=c.NoUrut " & _
                                    "LEFT JOIN MasterPasien b ON a.idinternet=b.NoRekamMedis " & _
                                    "WHERE a.ClosedTransaksi=0 AND CONVERT(date, TglPoli) BETWEEN '" & Tawal & "' AND '" & Takhir & "' AND a.deleted<>1  " & _
                                    "AND a.TransPoliID IN(SELECT TransPoliID FROM TransaksiPoliDetail WHERE StatusPembayaran='PENDING' AND DeletedDate IS NULL) " & _
                                    "UNION ALL " & _
                                    "SELECT a.TransGigiID as 'ID', c.JenisPoli, a.Nourut, a.IDInternet AS NoMitra, b.Nama, a.DokterGigi AS DokterPoli, CONVERT(VARCHAR, TglGigi, 120) AS TransactionDate " & _
                                    "FROM TransaksiGigi a " & _
                                    "LEFT JOIN TransaksiDetail c ON a.NoUrut=c.NoUrut " & _
                                    "LEFT JOIN MasterPasien b ON a.idinternet=b.NoRekamMedis " & _
                                    "WHERE a.ClosedTransaksi=0 AND CONVERT(date, TglGigi) BETWEEN '" & Tawal & "' AND '" & Takhir & "' AND a.deleted<>1  " & _
                                    "AND a.TransGigiID IN(SELECT TransGigiID FROM TransaksiGigiDetail WHERE StatusPembayaran='PENDING' AND DeletedDate IS NULL) " & _
                                    ") AS CombinedResults "
        Dim queryOrderString As String = " ORDER BY TransactionDate DESC"

        Find.Show()
        Find.Query(queryString, queryOrderString, "FindFormTransaksiPoli", 3)
    End Sub

    Private Sub TimerCekTransaksiBaru_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerCekTransaksiBaru.Tick
        CekNotifikasi()
    End Sub

    Private Sub CekNotifikasi()
        Dim queryBuilder As New StringBuilder()

        ' Query Get Count
        queryBuilder.Append("SELECT ")
        queryBuilder.Append("(SELECT COUNT(TransPoliID) FROM TransaksiPoliDetail WHERE StatusPembayaran = 'PENDING' AND DeletedDate IS NULL) + ")
        queryBuilder.Append("(SELECT COUNT(TransGigiID) FROM TransaksiGigiDetail WHERE StatusPembayaran = 'PENDING' AND DeletedDate IS NULL) AS TotalPendingCount;")

        Dim jumlahDataPending As Integer = ReadSQLNIK(queryBuilder.ToString())

        ' Hanya tampilkan notifikasi jika jumlah pending berubah
        If jumlahDataPending <> lastPendingCount Then
            lastPendingCount = jumlahDataPending

            If jumlahDataPending > 0 Then
                MessageBox.Show(jumlahDataPending & " transaksi belum diproses, segera lakukan proses pembayaran.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                ' Menampilkan notifikasi menggunakan NotifyIcon
                'NotifyIconTransaksiBaru.BalloonTipTitle = "Notifikasi"
                'NotifyIconTransaksiBaru.BalloonTipText = jumlahDataPending & " transaksi belum diproses, segera lakukan proses pembayaran."
                'NotifyIconTransaksiBaru.ShowBalloonTip(10000)
                'NotifyIconTransaksiBaru.BalloonTipIcon = ToolTipIcon.Warning
            End If
        End If
    End Sub
End Class