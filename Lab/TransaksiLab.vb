Imports System.Text.RegularExpressions

Public Class TransaksiLab
    Private DB_Poliklinik As TLcon
    Dim thread As System.Threading.Thread

    Private totalRowStruk As Integer = 0
    Private idTransaksi As String ' Berisi No Transaksi

    Private Sub SetClearHeader()
        GroupBox3.Enabled = False
        txjenisbayar_.ResetText()
        txkartu_.ResetText()
        CekTransaksiDone.Enabled = True
        idTransaksi = ""
        dtnow.Value = DateAndTime.Now
        TextBoxNoRekamMedis.ResetText()
        TextBoxNamaPasien.ResetText()
        TextBoxUmurPasien.ResetText()
        dtcusttgllhr.Value = DateSerial("9998", "12", "31")
        TextBoxNoUrutTransaksi.ResetText()
        chkclosed.Checked = False
        butsaved.Enabled = True
        TextBoxNamaDokter.ResetText()
        TextBoxDokterID.ResetText()
        TextBoxTotalPembulatan.Enabled = True
        rdreferensiperusahaan2.Checked = True
        txidreferensiperusahaan.ResetText()
        txnamareferensiperusahaan.ResetText()
        txnamareferensiperusahaan.Enabled = False
        txwarningperusahaan.Visible = False
        rdsoftcopy1.Checked = True
        rdhardcopy1.Checked = True
        ProgressBar1.Value = 0
        ProgressBar1.Visible = False
    End Sub

    Private Sub SetClearGrid()
        WriteSQL("DELETE FROM TransaksiLabDetail WHERE TransLabID = 0", 4)
        Dim Tbls As DataTable = New DataTable

        Tbls = ReadSQL("SELECT TindakanID, NamaTindakan AS [Tindakan], JenisTindakan as [Jenis], PARSENAME(CONVERT(varchar,convert(money,BiayaTindakan),1),2) as [Biaya Tindakan], PARSENAME(CONVERT(varchar,convert(money,DiscPersenTindakan),1),2) as DiscTindakan, PARSENAME(CONVERT(varchar,convert(money,DiscTindakan),1),2) as DiscNilai, PARSENAME(CONVERT(varchar,convert(money,NettBayar),1),2) as NettBayar,Mesin,Urutan " & _
                       "FROM TransaksiLabDetail " & _
                       "WHERE TransLabID='" & idTransaksi & "'")

        For Each Tcol As DataColumn In Tbls.Columns
            Tcol.ReadOnly = True
        Next

        Tbls.Columns("DiscTindakan").ReadOnly = False
        Tbls.Columns("DiscNilai").ReadOnly = False
        gridtindakan.DataSource = Tbls
        GridView1.Columns("TindakanID").Visible = False
        GridView1.Columns("Mesin").Visible = False
        GridView1.Columns("Urutan").Visible = False
    End Sub

    Private Sub SetClearFooter()
        TextBoxTotalBruto.Text = 0
        TextBoxTotalDiskon.Text = 0
        TextBoxTotalNett.Text = 0
        TextBoxTotalPembulatan.Text = 0
        TextBoxTotalBayar.Text = 0

        'Cara ambil baru
        rdhardcopy1.Checked = False
        rdhardcopy2.Checked = False
        rdhardcopy3.Checked = False
        rdsoftcopy1.Checked = False
        rdsoftcopy2.Checked = False
        rdsoftcopy3.Checked = False
        txsoftcopywhatsapp.ResetText()
        txsoftcopyemail.ResetText()
        txhardcopykirim.ResetText()
    End Sub

    Private Sub TransaksiLab_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        Me.MdiParent = PoliKlinik
        Me.Dock = DockStyle.Fill

        NewToolStripMenuItem1.PerformClick()
    End Sub

    Public Sub LoadTransaksiLab(ByRef Txid As String, ByRef Txnourut As String)
        SetClearHeader()
        SetClearFooter()

        Dim Thead As DataTable = ReadSQL("SELECT * FROM TransaksiLab WHERE TransLabID = '" & Txid & "' AND Nourut = '" & Txnourut & "'")
        Dim Rhead As DataRow = Thead.Rows(0)

        idTransaksi = Txid
        TextBoxNoUrutTransaksi.Text = Txnourut
        dtnow.Value = Rhead("TglLab")
        LoadLabPasien(Rhead("IDInternet"))
        If Rhead("ClosedTransaksi") = True Then chkclosed.Checked = True Else chkclosed.Checked = False
        If chkclosed.CheckState = CheckState.Checked Then
            MsgBox("Transaksi tidak dapat di-edit.")
            butsaved.Enabled = False
            TextBoxTotalPembulatan.Enabled = False
        Else
            butsaved.Enabled = True
        End If

        SetClearGrid()
        Kalkulasi()

        TextBoxTotalNett.Text = TextBoxTotalBayar.Text - TextBoxTotalPembulatan.Text
    End Sub

    Function CheckTambahTindakan(ByRef Trow() As DataRow)
        Dim Tbls As DataTable = gridtindakan.DataSource
        Tbls.AcceptChanges()
        If Trow.Count > 0 Then
            For i As Integer = 0 To Trow.Length - 1
                For Each Ttemp As DataRow In Tbls.Rows
                    If Ttemp("TindakanID") = Trow(i)("ID") Then
                        MsgBox("Terdapat tindakan double. Sudah ada pada pilihan. Check kembali.")
                        Return False
                    End If
                Next
            Next
        End If
        Return True
    End Function

    Function CheckTambahTindakan(ByRef Ttemp2 As DataTable)
        Dim Tbls As DataTable = gridtindakan.DataSource
        Tbls.AcceptChanges()
        If Ttemp2.Rows.Count > 0 Then
            For Each Trow As DataRow In Ttemp2.Rows
                For Each Ttemp As DataRow In Tbls.Rows
                    If Ttemp("TindakanID") = Trow("TindakanID") Then
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
                    Tnew("TindakanID") = Trow(i)("ID")
                    Tnew("Tindakan") = Trow(i)("Tindakan")
                    Tnew("Jenis") = Trow(i)("Jenis")
                    Tnew("Mesin") = Trow(i)("Mesin")
                    Tnew("Biaya Tindakan") = Trow(i)("Biaya Tindakan")
                    Tnew("DiscNilai") = 0
                    Tnew("NettBayar") = 0
                    Tbls.Rows.Add(Tnew)
                Next
                Tbls.AcceptChanges()
                Kalkulasi()
            End If
        End If
    End Sub

    Public Sub LoadPembayaranFromQR(ByVal jenisbayar As String, ByVal kartu As String)
        GroupBox3.Enabled = True
        txjenisbayar_.Text = jenisbayar
        txkartu_.Text = kartu
    End Sub

    Public Sub LoadTindakanFromQR(ByRef Trow() As DataRow, ByVal Tdisc As Integer, ByVal Tbiaya_tindakan As Integer)
        If CheckTambahTindakan(Trow) = True Then
            Dim Tbls As DataTable = gridtindakan.DataSource
            Tbls.AcceptChanges()
            If Trow.Count > 0 Then
                For i As Integer = 0 To Trow.Length - 1
                    Dim Tnew As DataRow = Tbls.NewRow
                    Tnew("TindakanID") = Trow(i)("ID")
                    Tnew("Tindakan") = Trow(i)("Tindakan")
                    Tnew("Jenis") = Trow(i)("Jenis")
                    Tnew("Mesin") = Trow(i)("Mesin")
                    Tnew("Biaya Tindakan") = Tbiaya_tindakan
                    Tnew("DiscNilai") = Tdisc
                    Tnew("NettBayar") = 0
                    Tbls.Rows.Add(Tnew)
                Next
                Tbls.AcceptChanges()
                Kalkulasi()
            End If
        End If
    End Sub

    Public Sub LoadTindakanTbls(ByRef Ttemp As DataTable)
        If CheckTambahTindakan(Ttemp) = True Then
            Dim Tbls As DataTable = gridtindakan.DataSource
            If Ttemp.Rows.Count > 0 Then
                For Each Trow As DataRow In Ttemp.Rows
                    Dim Tnew As DataRow = Tbls.NewRow
                    Tnew("TindakanID") = Trow("TindakanID")
                    Tnew("Tindakan") = Trow("NamaTindakan")
                    Tnew("Jenis") = Trow("JenisTindakan")
                    Tnew("Biaya Tindakan") = Splitmoney(Trow("BiayaTindakan"))
                    Tnew("DiscTindakan") = Splitmoney(Trow("DiscTindakan"))
                    Tnew("DiscNilai") = Splitmoney(CDbl(Trow("DiscTindakan") * Trow("BiayaTindakan") / 100))
                    Tnew("NettBayar") = Splitmoney(Trow("NettBayar"))
                    Tnew("Mesin") = ReadSQLNIK("select isnull(Mesin,'') from MasterLab where TindakanID='" & Trow("TindakanID") & "'")
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
            If MsgBox("Yakin menghapus Tindakan : " & Trow("Tindakan") & " ? ", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                GridView1.DeleteRow(GridView1.FocusedRowHandle)
                gridtindakan.RefreshDataSource()
                Kalkulasi()
            End If
        End If
    End Sub

    Public Sub LoadLabPasien(ByRef Txid As String)
        Dim Tbls As DataTable = New DataTable

        Tbls = ReadSQL("SELECT NoRekamMedis, Nama, TglLahir, DomisiliAlamat " & _
                       "FROM MasterPasien " & _
                       "WHERE NoRekamMedis = '" & Txid & "'")
        Dim Trow As DataRow = Tbls.Rows(0)

        TextBoxNoRekamMedis.Text = Trow("NoRekamMedis")
        TextBoxNamaPasien.Text = Trow("Nama")
        dtcusttgllhr.Value = Trow("TglLahir")
        TextBoxUmurPasien.Text = Umur(dtcusttgllhr.Value)
    End Sub

    Private Sub Kalkulasi()

        Dim Tbls As DataTable = gridtindakan.DataSource
        Tbls.AcceptChanges()
        For Each Tcol As DataColumn In Tbls.Columns
            Tcol.ReadOnly = False
        Next

        Dim totalrow = 1700

        For Each Trow As DataRow In Tbls.Rows
            totalrow = totalrow + 75
            If IsDBNull(Trow("DiscTindakan")) = True Then Trow("DiscTindakan") = "0"
            If IsDBNull(Trow("DiscNilai")) = True Then Trow("DiscNilai") = "0"

            If Trow("DiscTindakan") = "" Then Trow("DiscTindakan") = "0"
            If Trow("DiscNilai") = "" Then Trow("DiscNilai") = "0"

            If Trow("DiscNilai") <> "0" Then
                Trow("DiscTindakan") = Splitmoney(CDbl(Trow("DiscNilai") / Trow("Biaya Tindakan") * 100))
            ElseIf Trow("DiscTindakan") <> "0" Then
                Trow("DiscNilai") = Splitmoney(CDbl(Trow("Biaya Tindakan") * Trow("DiscTindakan") / 100))
            End If

            Trow("NettBayar") = Splitmoney(Trow("Biaya Tindakan") - Trow("DiscNilai"))
            If (Trow("NettBayar") Mod 1) > 0 Then
                Trow("NettBayar") = Splitmoney(Trow("NettBayar") - (Trow("NettBayar") Mod 1))
                Trow("DiscNilai") = Splitmoney(Trow("Biaya Tindakan") - Trow("NettBayar"))
            End If

            If (Trow("DiscNilai") Mod 1) > 0 Then
                Trow("NettBayar") = Splitmoney(Trow("NettBayar") - (Trow("NettBayar") Mod 1))
                Trow("DiscNilai") = Splitmoney(Trow("Biaya Tindakan") - Trow("NettBayar"))
            End If
        Next

        totalRowStruk = totalrow

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

        Dim Tbulat As Double = 0
        If (Tnett Mod 100) > 0 Then
            Tbulat = 0
        Else
            Tbulat = 100 - (Tnett Mod 100)
            If Tbulat = 100 Then Tbulat = 0
        End If

        TextBoxTotalBruto.Text = Splitmoney(Tbruto)
        TextBoxTotalDiskon.Text = Splitmoney(Tdisc)
        TextBoxTotalNett.Text = Splitmoney(Tnett)
        TextBoxTotalPembulatan.Text = Splitmoney(Tbulat)
        TextBoxTotalBayar.Text = Splitmoney(Tbulat + Tnett)
    End Sub

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

        If TextBoxNamaDokter.Text = "" Then
            MsgBox("Nama Dokter tidak boleh kosong. Masukkan nama dokter Pengirim sesuai data.")
            Return False
        End If

        If CheckSQL("select b.IdPraktek,a.DrNama,b.NamaPraktek,b.AlamatPraktek,b.KotaPraktek,b.TelpPraktek,b.KeteranganPraktek from MasterDokterKirim a left join MasterDokterTempatPraktek b on a.IdKirim=b.IdKirim where  b.IdPraktek ='" & TextBoxDokterID.Text & "'") = False Then
            If MsgBox("Nama Dokter inputan baru ?", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                TambahDokterPengirimToolStripMenuItem.PerformClick()
                DokterPengirimLab.cmbdokternama.Text = TextBoxNamaDokter.Text
            Else
                MsgBox("Pilih dokter sesuai dengan yang ada dalam data.")
                Return False
            End If
        End If

        'Cek Cara Ambil
        If rdsoftcopy1.Checked = False And rdsoftcopy2.Checked = False And rdsoftcopy3.Checked = False Then
            MsgBox("Pilih cara pengambilan hasil (Softcopy).", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        ElseIf rdhardcopy1.Checked = False And rdhardcopy2.Checked = False And rdhardcopy3.Checked = False Then
            MsgBox("Pilih cara pengambilan hasil (Hardcopy).", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        ElseIf rdsoftcopy1.Checked = True And rdhardcopy1.Checked = True Then
            MsgBox("Wajib memilih salah satu antara Hardcopy atau Softcopy.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        ElseIf rdsoftcopy2.Checked = True And txsoftcopywhatsapp.Text = "" Then
            MsgBox("Isi No Whatsapp terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        ElseIf rdsoftcopy3.Checked = True And txsoftcopyemail.Text = "" Then
            MsgBox("Isi alamat email terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        ElseIf rdhardcopy2.Checked = True And txhardcopykirim.Text = "" Then
            MsgBox("Isi detail kirim terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        'Cek Email
        If rdsoftcopy3.Checked = True Then
            If validateEmail(txsoftcopyemail.Text) = False Then
                MsgBox("Perhatikan penulisan email dengan benar.", MsgBoxStyle.Exclamation, "Warning!")
                Return False
            End If
        End If

        'Cek No Whatsapp
        If rdsoftcopy2.Checked = True Then
            If validateNoWhatsapp(txsoftcopywhatsapp.Text) = False Then
                Return False
            End If
        End If
        Return True
    End Function

    Function CaraAmbil() As String
        Dim Tambil As String = ""
        Dim Tsoftcopy As String = ""
        Dim Thardcopy As String = ""

        If rdsoftcopy1.Checked = True Then
            Tsoftcopy = ""
        ElseIf rdsoftcopy2.Checked = True Then
            Tsoftcopy = "Whatsapp ke " & txsoftcopywhatsapp.Text
        ElseIf rdsoftcopy3.Checked = True Then
            Tsoftcopy = "Email ke " & txsoftcopyemail.Text
        End If

        If rdhardcopy1.Checked = True Then
            Thardcopy = ""
        ElseIf rdhardcopy2.Checked = True Then
            Thardcopy = "Kirim ke " & txhardcopykirim.Text
        ElseIf rdhardcopy3.Checked = True Then
            Thardcopy = "Ambil Sendiri"
        End If

        If Thardcopy <> "" And Tsoftcopy <> "" Then
            Tambil = Thardcopy & " & " & Tsoftcopy
        ElseIf Thardcopy <> "" Then
            Tambil = Thardcopy
        ElseIf Tsoftcopy <> "" Then
            Tambil = Tsoftcopy
        End If

        Return Tambil
    End Function

    Private Sub butsaved_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butsaved.Click
        If MsgBox("Process pembayaran Transaksi ini ?", MsgBoxStyle.YesNo, "Verifikasi Pembayaran") = MsgBoxResult.Yes Then
            If Checking() = True Then
                Dim Tbls As DataTable = gridtindakan.DataSource
                Tbls.AcceptChanges()
                Kalkulasi()
                Dim Tambil As String = CaraAmbil()
                Dim StatusSoftcopy As String = ""
                Dim StatusHardcopy As String = ""
                Dim SendingWhatsapp As String = "-"
                Dim SendingEmail As String = "-"

                'Create Cara Ambil.
                If rdsoftcopy1.Checked = True Then
                    StatusSoftcopy = "0"
                ElseIf rdsoftcopy2.Checked = True Then
                    StatusSoftcopy = "1"
                    SendingWhatsapp = txsoftcopywhatsapp.Text.Trim
                ElseIf rdsoftcopy3.Checked = True Then
                    StatusSoftcopy = "1"
                    SendingEmail = txsoftcopyemail.Text.Trim
                End If

                If rdhardcopy1.Checked = True Then
                    StatusHardcopy = "0"
                ElseIf rdhardcopy2.Checked = True Or rdhardcopy3.Checked = True Then
                    StatusHardcopy = "1"
                End If

                WriteSQL("UPDATE TransaksiLab SET SendingWhatsapp = '" & SendingWhatsapp & "', SendingEmail = '" & SendingEmail & "', StatusSoftcopy='" & StatusSoftcopy & "', StatusHardcopy='" & StatusHardcopy & "', CaraAmbil='" & Tambil & "' , DokterRequest='" & TextBoxDokterID.Text & "' WHERE TransLabID = '" & idTransaksi & "'", 4)

                'Set From QR Code
                If txjenisbayar_.Text <> "" Then
                    Dim NoKartu As String = ""
                    Dim NamaBank As String = ""
                    Dim JenisBayar As String = ""
                    Dim JumlahBayar As Double = 0

                    If txjenisbayar_.Text = "TAGIHAN" Then
                        NoKartu = txkartu_.Text
                    ElseIf txjenisbayar_.Text = "TUNAI" Then
                        NoKartu = "-"
                    ElseIf txjenisbayar_.Text = "CARD" Or txjenisbayar_.Text = "DEBET" Then
                        Dim arrKartu As String() = Split(txkartu_.Text, "#")

                        NoKartu = arrKartu(1).ToString.Trim
                        NamaBank = arrKartu(0).ToString.Trim
                    End If

                    JenisBayar = txjenisbayar_.Text
                    JumlahBayar = TextBoxTotalNett.Text

                    FormPembayaran.txbayarfromQRcode.Text = NoKartu & "#" & NamaBank & "#" & JenisBayar & "#" & JumlahBayar
                Else
                    FormPembayaran.txbayarfromQRcode.ResetText()
                End If

                'Pembayaran.loadData("LAB", totalRowStruk, idTransaksi, TextBoxNoRekamMedis.Text, txtotalbayar.Text, Tbls, txtotalbruto.Text, txtotaldisc.Text, txtotalpembulatan.Text)
                'Pembayaran.ShowDialog()
                'Pembayaran.ClearPembayaran()

                ' =============================================================

                '# Set data dictionary yang akan dikirim ke form pembayaran
                Dim dataDictionary As New Dictionary(Of String, Object)()

                'Dim Tbls As DataTable = gridtindakan.DataSource
                'Tbls.AcceptChanges()
                'Kalkulasi()

                dataDictionary.Add("Jenis Transaksi", "LAB")
                dataDictionary.Add("Poli Tujuan", "LABORATORIUM")
                dataDictionary.Add("ID Transaksi", idTransaksi)
                dataDictionary.Add("No Urut Transaksi", TextBoxNoUrutTransaksi.Text)
                dataDictionary.Add("No Rekam Medis", TextBoxNoRekamMedis.Text)
                dataDictionary.Add("Nama Pasien", TextBoxNamaPasien.Text)
                dataDictionary.Add("Nama Dokter", TextBoxNamaDokter.Text)

                FormPembayaran.DataDictionary = dataDictionary
                FormPembayaran.SetDataFromPendaftaran(TextBoxTotalBayar.Text, Tbls, TextBoxTotalBruto.Text, TextBoxTotalDiskon.Text, TextBoxTotalPembulatan.Text)
                FormPembayaran.ShowDialog()
            Else
                MsgBox("Cek lagi transaksi anda.", MsgBoxStyle.Exclamation, "Warning!")
            End If
        Else
            MsgBox("Pembayaran dibatalkan.", MsgBoxStyle.Exclamation, "Warning!")
        End If
    End Sub

    Private Function ValidasiInputTindakan() As Boolean


        Return True
    End Function

    Private Sub chkclosed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkclosed.CheckedChanged
        If chkclosed.CheckState = CheckState.Checked Then
            butsaved.Enabled = False
        ElseIf chkclosed.CheckState = CheckState.Unchecked Then
            butsaved.Enabled = True
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Kalkulasi()
    End Sub

    Private Sub txtotalpembulatan_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBoxTotalPembulatan.EditValueChanged
        If IsNumeric(TextBoxTotalPembulatan.Text) = True Then
            TextBoxTotalBayar.Text = Splitmoney(CInt(TextBoxTotalNett.Text) + TextBoxTotalPembulatan.Text)
        End If
    End Sub

    Private Sub rdemail_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdemail.CheckedChanged
        If rdemail.Checked = True Then
            rdemail.Checked = True
        End If
    End Sub

    Private Sub NewToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem1.Click
        SetClearHeader()
        SetClearGrid()
        SetClearFooter()
        setConn()
    End Sub

    Private Sub setConn()
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

    Private Sub TambahTindakanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TambahTindakanToolStripMenuItem.Click
        FindMultiple.Show()
        FindMultiple.Query("select TindakanID as ID,NamaTindakan as [Tindakan],JenisTindakan as [Jenis],PARSENAME(CONVERT(varchar,convert(money,BiayaTindakan),1),2) as [Biaya Tindakan],[Mesin] from MasterLab where Closed=0 ", " order by JenisTindakan,NamaTindakan", "FindTindakan", 1)
    End Sub

    Private Sub TambahPaketToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TambahPaketToolStripMenuItem.Click
        Find.Show()
        Find.Query("select PaketID as ID,PaketNama,PaketKeterangan,PARSENAME(CONVERT(varchar,convert(money,PaketNilaiTotal),1),2) as PaketNilaiTotal,PaketStart,PaketEnd from MasterLabPaket where GETDATE() between PaketStart AND PaketEnd ", " order by PaketStart,PaketNama ", "FindPaket", 2)
    End Sub

    Private Sub TambahDokterPengirimToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TambahDokterPengirimToolStripMenuItem.Click
        DokterPengirimLab.Show()
        DokterPengirimLab.Focus()
    End Sub

    Private Sub KalkulasiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KalkulasiToolStripMenuItem.Click
        Button3.PerformClick()
    End Sub

    Private Sub rdsoftcopy2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdsoftcopy2.CheckedChanged
        If rdsoftcopy2.Checked = True Then
            txsoftcopyemail.Enabled = False
            txsoftcopyemail.ResetText()
            txsoftcopywhatsapp.Enabled = True
            txsoftcopywhatsapp.Focus()
        End If
    End Sub

    Private Sub rdsoftcopy3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdsoftcopy3.CheckedChanged
        If rdsoftcopy3.Checked = True Then
            txsoftcopywhatsapp.Enabled = False
            txsoftcopywhatsapp.ResetText()
            txsoftcopyemail.Enabled = True
            txsoftcopyemail.Focus()
        End If
    End Sub

    Private Sub rdhardcopy2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdhardcopy2.CheckedChanged
        If rdhardcopy2.Checked = True Then
            txhardcopykirim.Enabled = True
            txhardcopykirim.Focus()
        End If
    End Sub

    Private Sub rdsoftcopy1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdsoftcopy1.CheckedChanged
        If rdsoftcopy1.Checked = True Then
            txsoftcopyemail.Enabled = False
            txsoftcopyemail.ResetText()
            txsoftcopywhatsapp.Enabled = False
            txsoftcopywhatsapp.ResetText()
        End If
    End Sub

    Private Sub rdhardcopy1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdhardcopy1.CheckedChanged
        If rdhardcopy1.Checked = True Then
            txhardcopykirim.Enabled = False
            txhardcopykirim.ResetText()
        End If
    End Sub

    Private Sub rdhardcopy3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdhardcopy3.CheckedChanged
        If rdhardcopy3.Checked = True Then
            txhardcopykirim.Enabled = False
            txhardcopykirim.ResetText()
        End If
    End Sub

    Private Sub txsoftcopywhatsapp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txsoftcopywhatsapp.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack Or e.KeyChar = ",") Then e.Handled = True
    End Sub

    Private Sub rdreferensiperusahaan1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdreferensiperusahaan1.CheckedChanged
        If rdreferensiperusahaan1.Checked = True Then
            Find.Show()
            Find.Query("SELECT a.companycode, a.companynama, ISNULL(a.Alamat_Pengiriman, '-') AS 'Alamat', ISNULL(a.No_Handphone, '-') AS 'No. Handphone', a.nocompany from mastercompany a where getdate() between StartDate AND EndDate", " order by idcompany desc", "FindReferensiPerusahaan", 0) 'FindReferensiPerusahaan
            txnamareferensiperusahaan.Enabled = True
        End If
    End Sub

    Private Sub rdreferensiperusahaan2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdreferensiperusahaan2.CheckedChanged
        txidreferensiperusahaan.ResetText()
        txnamareferensiperusahaan.ResetText()
        txnamareferensiperusahaan.Enabled = False
        txwarningperusahaan.Visible = False
        rdhardcopy1.Enabled = True
        rdhardcopy2.Enabled = True
        rdhardcopy3.Enabled = True
        rdsoftcopy1.Enabled = True
        rdsoftcopy2.Enabled = True
        rdsoftcopy3.Enabled = True

        rdsoftcopy1.Checked = True
        rdhardcopy1.Checked = True
        txhardcopykirim.ReadOnly = False
        txsoftcopyemail.ReadOnly = False
        txsoftcopywhatsapp.ReadOnly = False

        txjenisbayar_.ResetText()
        txkartu_.ResetText()
        GroupBox3.Enabled = False
    End Sub

    Public Sub LoadReferensiPerusahaan(ByRef txNama As String, ByRef TxNoCompany As String)
        txnamareferensiperusahaan.Text = txNama
        txidreferensiperusahaan.Text = TxNoCompany

        GroupBox3.Enabled = True
        txjenisbayar_.Text = "TAGIHAN"
        txkartu_.Text = txNama & "-" & TxNoCompany

        Dim Tbls As DataTable = ReadSQL("select * from mastercompany where nocompany='" & TxNoCompany & "'")
        Dim Trow As DataRow = Tbls.Rows(0)

        If Trow("HardcopyPerusahaan") = True And Trow("TerimaHasilKaryawan") = True Then
            'Softcopy
            If Trow("Whatsapp_Auto") = True Then
                rdsoftcopy2.Checked = True
                rdsoftcopy1.Enabled = False
                rdsoftcopy2.Enabled = True
                rdsoftcopy3.Enabled = False
                txsoftcopywhatsapp.Text = Trow("No_Handphone").ToString.Trim
                'txsoftcopywhatsapp.ReadOnly = True
            ElseIf Trow("Email_Auto") = True Then
                rdsoftcopy3.Checked = True
                rdsoftcopy1.Enabled = False
                rdsoftcopy2.Enabled = False
                rdsoftcopy3.Enabled = True
                txsoftcopyemail.Text = Trow("Email_Perusahaan").ToString.Trim
                'txsoftcopyemail.ReadOnly = True
            Else
                rdsoftcopy1.Checked = True
                rdsoftcopy1.Enabled = True
                rdsoftcopy2.Enabled = False
                rdsoftcopy3.Enabled = False
                'txsoftcopywhatsapp.ReadOnly = True
                'txsoftcopyemail.ReadOnly = True
            End If
            'Hardcopy
            rdhardcopy1.Enabled = True
            rdhardcopy2.Enabled = True
            rdhardcopy3.Enabled = True
            rdhardcopy2.Checked = True
            txhardcopykirim.Text = Trow("Alamat_Pengiriman").ToString.Trim
            'txhardcopykirim.ReadOnly = True
            'warning
            txwarningperusahaan.Visible = False
        ElseIf Trow("HardcopyPerusahaan") = False And Trow("TerimaHasilKaryawan") = True Then
            'Softcopy
            If Trow("Whatsapp_Auto") = True Then
                rdsoftcopy2.Checked = True
                rdsoftcopy1.Enabled = False
                rdsoftcopy2.Enabled = True
                rdsoftcopy3.Enabled = False
                txsoftcopywhatsapp.Text = Trow("No_Handphone").ToString.Trim
                'txsoftcopywhatsapp.ReadOnly = True
            ElseIf Trow("Email_Auto") = True Then
                rdsoftcopy3.Checked = True
                rdsoftcopy1.Enabled = False
                rdsoftcopy2.Enabled = False
                rdsoftcopy3.Enabled = True
                txsoftcopyemail.Text = Trow("Email_Perusahaan").ToString.Trim
                'txsoftcopyemail.ReadOnly = True
            Else
                rdsoftcopy1.Checked = True
                rdsoftcopy1.Enabled = True
                rdsoftcopy2.Enabled = True
                rdsoftcopy3.Enabled = True
                'txsoftcopywhatsapp.ReadOnly = True
                'txsoftcopyemail.ReadOnly = True
            End If
            'Hardcopy
            If Trow("AlamatPerusahaan") = True Then
                rdhardcopy1.Checked = True
                rdhardcopy1.Enabled = True
                rdhardcopy2.Enabled = False
                rdhardcopy3.Enabled = False
            Else
                rdhardcopy1.Checked = True
                rdhardcopy1.Enabled = True
                rdhardcopy2.Enabled = True
                rdhardcopy3.Enabled = True
            End If
            'warning
            txwarningperusahaan.Visible = True
            txwarningperusahaan.Text = "*Note : Perusahaan tidak membutuhkan hardcopy."
        ElseIf Trow("HardcopyPerusahaan") = True And Trow("TerimaHasilKaryawan") = False Then
            'Softcopy
            If Trow("Whatsapp_Auto") = True Then
                rdsoftcopy2.Checked = True
                rdsoftcopy1.Enabled = False
                rdsoftcopy2.Enabled = True
                rdsoftcopy3.Enabled = False
                txsoftcopywhatsapp.Text = Trow("No_Handphone").ToString.Trim
                'txsoftcopywhatsapp.ReadOnly = True
            ElseIf Trow("Email_Auto") = True Then
                rdsoftcopy3.Checked = True
                rdsoftcopy1.Enabled = False
                rdsoftcopy2.Enabled = False
                rdsoftcopy3.Enabled = True
                txsoftcopyemail.Text = Trow("Email_Perusahaan").ToString.Trim
                'txsoftcopyemail.ReadOnly = True
            Else
                rdsoftcopy1.Checked = True
                rdsoftcopy1.Enabled = True
                rdsoftcopy2.Enabled = False
                rdsoftcopy3.Enabled = False
                txsoftcopywhatsapp.ReadOnly = True
                txsoftcopyemail.ReadOnly = True
            End If
            'Hardcopy
            rdhardcopy1.Enabled = False
            rdhardcopy2.Enabled = True
            rdhardcopy3.Enabled = False
            rdhardcopy2.Checked = True
            txhardcopykirim.Text = Trow("CompanyNama").ToString.Trim
            'txhardcopykirim.ReadOnly = True
            'Warning
            txwarningperusahaan.Visible = True
            txwarningperusahaan.Text = "*Note : Perusahaan terserbut tidak memperbolehkan karyawan" & vbCr & vbLf + "" & _
                                       "untuk melihat hasil baik hardcopy maupun softcopy"
        ElseIf Trow("HardcopyPerusahaan") = False And Trow("TerimaHasilKaryawan") = False Then
            'Softcopy
            If Trow("Whatsapp_Auto") = True Then
                rdsoftcopy2.Checked = True
                rdsoftcopy1.Enabled = False
                rdsoftcopy2.Enabled = True
                rdsoftcopy3.Enabled = False
                txsoftcopywhatsapp.Text = Trow("No_Handphone").ToString.Trim
                'txsoftcopywhatsapp.ReadOnly = True
            ElseIf Trow("Email_Auto") = True Then
                rdsoftcopy3.Checked = True
                rdsoftcopy1.Enabled = False
                rdsoftcopy2.Enabled = False
                rdsoftcopy3.Enabled = True
                txsoftcopyemail.Text = Trow("Email_Perusahaan").ToString.Trim
                'txsoftcopyemail.ReadOnly = True
            Else
                rdsoftcopy1.Checked = True
                rdsoftcopy1.Enabled = True
                rdsoftcopy2.Enabled = False
                rdsoftcopy3.Enabled = False
                txsoftcopywhatsapp.ReadOnly = True
                txsoftcopyemail.ReadOnly = True
            End If
            'Hardcopy
            rdhardcopy1.Checked = True
            rdhardcopy1.Enabled = True
            rdhardcopy2.Enabled = False
            rdhardcopy3.Enabled = False
            'txhardcopykirim.ReadOnly = True
            'Warning
            txwarningperusahaan.Visible = True
            txwarningperusahaan.Text = "*Note : Perusahaan terserbut tidak memperbolehkan karyawan" & vbCr & vbLf + "" & _
                                       "untuk melihat hasil baik hardcopy maupun softcopy"
        End If
    End Sub

    Private Sub CekTransaksiDone_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CekTransaksiDone.Tick
        If idTransaksi <> "" Then
            If CheckSQL("select NoUrut from TransaksiLab where TransLabID = " & idTransaksi & " AND Status = 'OPEN'") = False Then
                CekTransaksiDone.Enabled = False
                MsgBox("Transaksi sudah selesai.", MsgBoxStyle.Exclamation, "Warning!")
                FormPembayaran.Close()
                NewToolStripMenuItem1.PerformClick()
            End If
        End If
    End Sub

    Private Sub UpdateMasterPerusahaanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateMasterPerusahaanToolStripMenuItem.Click
        thread = New System.Threading.Thread(AddressOf Download)
        thread.Start()
    End Sub

    Private Sub Download()
        Dim persen As Integer = 0
        Dim jumlah As Integer = 0
        Dim Tbls As DataTable = ReadThemysql("select * from mastercompany", DB_Poliklinik)
        For Each Trow As DataRow In Tbls.Rows
            ProgressBar1.Visible = True

            If IsDBNull(Trow("Whatsapp_Auto")) = True Then Trow("Whatsapp_Auto") = 0
            If IsDBNull(Trow("Email_Auto")) = True Then Trow("Email_Auto") = 0
            If IsDBNull(Trow("TerimaHasilKaryawan")) = True Then Trow("TerimaHasilKaryawan") = 0
            If IsDBNull(Trow("ReportHasilPerusahaan")) = True Then Trow("ReportHasilPerusahaan") = 0
            If IsDBNull(Trow("HardcopyPerusahaan")) = True Then Trow("HardcopyPerusahaan") = 0
            If IsDBNull(Trow("AlamatPerusahaan")) = True Then Trow("AlamatPerusahaan") = 0

            persen = persen + 1
            If CheckSQL("select * from MasterCompany where NoCompany='" & Trow("nocompany").ToString & "'") = True Then
                'update
                WriteSQL("update MasterCompany set AlamatPerusahaan=" & Trow("AlamatPerusahaan") & ",  HardcopyPerusahaan=" & Trow("HardcopyPerusahaan") & ", ReportHasilPerusahaan=" & Trow("ReportHasilPerusahaan") & " , TerimaHasilKaryawan=" & Trow("TerimaHasilKaryawan") & ", Email_Auto=" & Trow("Email_Auto") & ", Whatsapp_Auto=" & Trow("Whatsapp_Auto") & ", No_Handphone2='" & Trow("No_Handphone2") & "', PIC_Perusahaan='" & Trow("PIC_Perusahaan").ToString & "', PIC_Marketing='" & Trow("PIC_Marketing").ToString & "', Email_Perusahaan='" & Trow("Email_Perusahaan").ToString & "', No_Handphone='" & Trow("No_Handphone").ToString & "', Alamat_Pengiriman='" & Trow("Alamat_Pengiriman").ToString & "', CompanyCode='" & Trow("companycode").ToString & "',CompanyNama='" & Trow("companynama").ToString & "', StartDate='" & Format(Trow("startdate"), "MM/dd/yyyy") & "' , Enddate='" & Format(Trow("enddate"), "MM/dd/yyyy") & "' where NoCompany='" & Trow("nocompany").ToString & "'", 4)
            Else
                'new
                WriteSQL("insert into MasterCompany(CompanyCode,CompanyNama,StartDate,EndDate,CreateDate,CreateBy,NoCompany,PIC_Perusahaan,PIC_Marketing,Email_Perusahaan,No_Handphone,Alamat_Pengiriman, Whatsapp_Auto, Email_Auto, No_Handphone2, TerimaHasilKaryawan, HardcopyPerusahaan, AlamatPerusahaan, ReportHasilPerusahaan) values('" & Trow("companycode") & "','" & Trow("companynama") & "','" & Format(Trow("startdate"), "yyyyMMdd") & "','" & Format(Trow("enddate"), "yyyyMMdd") & "',getdate(),'" & Trow("createby") & "','" & Trow("nocompany") & "','" & Trow("PIC_Perusahaan") & "', '" & Trow("PIC_Marketing") & "', '" & Trow("Email_Perusahaan") & "', '" & Trow("No_Handphone") & "', '" & Trow("Alamat_Pengiriman") & "', " & Trow("Whatsapp_Auto") & "," & Trow("Email_Auto") & ",'" & Trow("No_Handphone2") & "'," & Trow("TerimaHasilKaryawan") & "," & Trow("HardcopyPerusahaan") & "," & Trow("AlamatPerusahaan") & ", " & Trow("ReportHasilPerusahaan") & ")", 4)
            End If

            Dim procent As Integer = persen * 100 / Tbls.Rows.Count
            ProgressBar1.Value = procent
        Next
        ProgressBar1.Visible = False
        MsgBox("Master Company Berhasil Update.", MsgBoxStyle.Information, "Success!")
    End Sub

    Private Sub ButtonFindTransaksi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFindTransaksi.Click
        Dim Takhir As Date = DateSerial(DateAndTime.Now.Year, DateAndTime.Now.Month, DateAndTime.Now.Day)
        Dim Tawal As Date = DateAdd(DateInterval.Day, -1, Takhir.Date)
        Dim queryString = "SELECT a.TransLabID AS 'ID', CONVERT(date, a.TglLab) AS 'Tgl Lab', a.NoUrut AS 'No. Lab', a.IDInternet AS 'No. Registrasi', b.Nama, CONVERT(date, b.TglLahir) AS 'Tgl Lahir' " & _
                          "FROM TransaksiLab a " & _
                          "LEFT JOIN MasterPasien b ON a.idinternet = b.NoRekamMedis " & _
                          "WHERE a.ClosedTransaksi = 0 AND Status = 'OPEN' AND (CONVERT(date, Tgllab) BETWEEN '" & Format(Tawal.Date, "MM-dd-yyyy") & "' AND '" & Format(Takhir.Date, "MM-dd-yyyy") & "') AND a.deleted <> 1"
        Dim queryOrderString As String = " ORDER BY a.TglLab DESC"

        Find.Show()
        Find.Query(queryString, queryOrderString, "FindTransLab", 0)
    End Sub

    Private Sub ButtonFindDokter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFindDokter.Click
        Find.Show()
        Find.Query("select b.IdPraktek,a.DrNama,b.NamaPraktek,b.AlamatPraktek,b.KotaPraktek,b.TelpPraktek,b.KeteranganPraktek from MasterDokterKirim a right join MasterDokterTempatPraktek b on a.IdKirim=b.IdKirim ", " order by a.DrNama,b.NamaPraktek", "FindDoktertindakan", 1)
    End Sub
End Class