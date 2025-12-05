Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Drawing

Imports Excel = Microsoft.Office.Interop.Excel
Imports Microsoft.Office
Imports Microsoft.Office.Interop
Imports System.Text
Imports System.IO.StreamReader

Imports Newtonsoft.Json
Imports System.Data.SqlClient

Public Class MasterTindakanKlinik
    Private formName As String = "MASTER TINDAKAN KLINIK"

    Private Find_Poliklinik As Find.TLconnect
    Private DB_Poliklinik As TLcon

    Dim thread As System.Threading.Thread
    Dim conn As OleDbConnection
    Dim dtr As OleDbDataReader
    Dim dta As OleDbDataAdapter
    Dim cmd As OleDbCommand
    Dim dts As DataSet
    Dim excel As String
    Dim opFileDialog As New OpenFileDialog()
    Private userInput As String = PoliKlinik.Lbluser.Text

    ' Deklarasi variabel untuk menyimpan link terakhir yang diklik
    Private lastClickedItem As DevExpress.XtraNavBar.NavBarItem = Nothing

    Private Sub PanelTop_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelTop.Paint
        Try
            e.Graphics.DrawString(formName, New Font("Arial", 12, FontStyle.Bold), Brushes.White, New Point(10, 10))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub SetConn()
        ' Set Parameter Server Online
        Dim serverOnline_IP As String = Utility.GetConfig("ServerOnline_IP")
        Dim serverOnline_UserID As String = Utility.GetConfig("ServerOnline_UserID")
        Dim serverOnline_Password As String = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerOnline_Password"), "albert")

        ' Set DB Poliklinik
        DB_Poliklinik.Tip = serverOnline_IP
        DB_Poliklinik.Tid = serverOnline_UserID
        DB_Poliklinik.Tpass = serverOnline_Password
        DB_Poliklinik.Tdb = Utility.GetConfig("ServerOnlinePoli_DB")

        ' Set Find Poliklinik
        Find_Poliklinik.Tip = serverOnline_IP
        Find_Poliklinik.Tid = serverOnline_UserID
        Find_Poliklinik.Tpass = serverOnline_Password
        Find_Poliklinik.Tdb = Utility.GetConfig("ServerOnlinePoli_DB")
    End Sub

    Private Sub SetDataGrid()
        Dim tblTindakan As DataTable = CreateTableTindakan()

        If TextBoxReffID.Text <> "" Then
            Dim stringQuery As New StringBuilder()

            stringQuery.AppendLine("SELECT b.TindakanID, b.NamaTindakan, b.JenisTindakan, b.BiayaTindakan, b.DiskonTindakan, b.NettBayar, b.Jumlah AS 'KuotaTindakan', b.GrandTotal")
            stringQuery.AppendLine("FROM MasterPaketTindakan a")
            stringQuery.AppendLine("LEFT JOIN MasterPaketTindakanDetail b ON a.PaketID = b.PaketID")
            stringQuery.AppendLine("WHERE a.PaketID = '" & TextBoxReffID.Text & "' AND b.DeletedDate IS NULL")

            tblTindakan = ReadSQL(stringQuery.ToString())
        End If

        ' Set DataTable sebagai sumber data GridControl
        GridControlTindakan.DataSource = tblTindakan
        GridViewTindakan.BestFitColumns()
        GridViewTindakan.Columns("TindakanID").Visible = False

        ' Nonaktifkan edit untuk semua kolom
        For Each col As DevExpress.XtraGrid.Columns.GridColumn In GridViewTindakan.Columns
            col.OptionsColumn.AllowEdit = False
        Next

        ' Aktifkan edit hanya untuk kolom tertentu
        GridViewTindakan.Columns("NettBayar").OptionsColumn.AllowEdit = True

        ' Tambahkan event handler untuk kalkulasi otomatis
        AddHandler GridViewTindakan.CellValueChanged, AddressOf GridViewTindakan_CellValueChanged
    End Sub

    ' Tambahkan variabel global untuk mencegah rekursi
    Private isProcessing As Boolean = False

    Private Sub GridViewTindakan_CellValueChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs)
        ' Cegah rekursi dengan mengecek flag
        If isProcessing Then Exit Sub
        isProcessing = True

        ' Nonaktifkan event handler sementara untuk menghindari rekursi
        RemoveHandler GridViewTindakan.CellValueChanged, AddressOf GridViewTindakan_CellValueChanged

        Try
            ' Pastikan event hanya diproses untuk kolom "NettBayar" atau "KuotaTindakan"
            If e.Column.FieldName = "NettBayar" OrElse e.Column.FieldName = "KuotaTindakan" Then
                ' Nonaktifkan update tampilan sementara
                GridViewTindakan.BeginUpdate()

                ' Ambil nilai dari grid
                Dim biayaTindakan As Decimal = Convert.ToDecimal(GridViewTindakan.GetRowCellValue(e.RowHandle, "BiayaTindakan"))
                Dim nettBayar As Object = GridViewTindakan.GetRowCellValue(e.RowHandle, "NettBayar")
                Dim kuotaTindakan As Object = GridViewTindakan.GetRowCellValue(e.RowHandle, "KuotaTindakan")

                ' Validasi NettBayar
                Dim nettBayarValid As Decimal = 0
                If nettBayar IsNot Nothing AndAlso Not String.IsNullOrEmpty(nettBayar.ToString()) Then
                    If Decimal.TryParse(nettBayar.ToString(), nettBayarValid) Then
                        If nettBayarValid < 0 Then
                            MessageBox.Show("NettBayar tidak boleh kurang dari 0!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            nettBayarValid = 0
                        End If
                    Else
                        MessageBox.Show("NettBayar harus berupa angka!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        nettBayarValid = 0
                    End If
                End If

                ' Set nilai NettBayar yang valid ke grid
                GridViewTindakan.SetRowCellValue(e.RowHandle, "NettBayar", nettBayarValid)

                ' Validasi KuotaTindakan
                Dim kuotaTindakanValid As Decimal = 1
                If kuotaTindakan IsNot Nothing AndAlso Not String.IsNullOrEmpty(kuotaTindakan.ToString()) Then
                    If Decimal.TryParse(kuotaTindakan.ToString(), kuotaTindakanValid) Then
                        If kuotaTindakanValid < 1 Then
                            MessageBox.Show("KuotaTindakan tidak boleh kurang dari 1!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            kuotaTindakanValid = 1
                        End If
                    Else
                        MessageBox.Show("KuotaTindakan harus berupa angka!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        kuotaTindakanValid = 1
                    End If
                End If

                ' Set nilai KuotaTindakan yang valid ke grid
                GridViewTindakan.SetRowCellValue(e.RowHandle, "KuotaTindakan", kuotaTindakanValid)

                ' Validasi NettBayar tidak boleh melebihi BiayaTindakan
                If nettBayarValid > biayaTindakan Then
                    MessageBox.Show("NettBayar tidak boleh melebihi BiayaTindakan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    nettBayarValid = biayaTindakan
                    GridViewTindakan.SetRowCellValue(e.RowHandle, "NettBayar", biayaTindakan)
                End If

                ' Hitung DiskonTindakan
                Dim diskonTindakan As Decimal = Math.Round(biayaTindakan - nettBayarValid, 2)
                GridViewTindakan.SetRowCellValue(e.RowHandle, "DiskonTindakan", diskonTindakan)

                ' Hitung GrandTotal
                Dim grandTotal As Decimal = Math.Round(nettBayarValid * kuotaTindakanValid, 2)
                GridViewTindakan.SetRowCellValue(e.RowHandle, "GrandTotal", grandTotal)

                ' Aktifkan kembali event handler
                GridViewTindakan.EndUpdate()
            End If
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat menghitung nilai: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Aktifkan kembali event handler dan reset flag
            AddHandler GridViewTindakan.CellValueChanged, AddressOf GridViewTindakan_CellValueChanged
            isProcessing = False
        End Try
    End Sub

    Function CreateTableTindakan() As DataTable
        Dim Thasil As New DataTable

        insertRowToTbls(Thasil, "Typstring", "TindakanID")
        insertRowToTbls(Thasil, "Typstring", "NamaTindakan")
        insertRowToTbls(Thasil, "Typstring", "JenisTindakan")
        insertRowToTbls(Thasil, "Double", "BiayaTindakan")
        insertRowToTbls(Thasil, "Double", "DiskonTindakan")
        insertRowToTbls(Thasil, "Double", "NettBayar")
        insertRowToTbls(Thasil, "Double", "KuotaTindakan")
        insertRowToTbls(Thasil, "Double", "GrandTotal")

        Return Thasil
    End Function

    Private Sub MasterTindakanKlinik_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
        Me.MdiParent = PoliKlinik
        Me.Dock = DockStyle.Fill

        ' Hide tab header button TabControl
        TabControlMenu.ItemSize = New Size(0, 1)
        TextBoxHariReminder.ReadOnly = True

        ClearDataMenuPaket()
        ClearDataMenuTindakan()
        LoadPoliData()
        'LoadPoliDataPaket()

        SetConn()
        SetDataGrid()

        ' Panggil metode untuk NavBarItemTindakanPoliUmum
        TriggerNavBarItemClick(NavBarItemTindakanPoliUmum)
    End Sub

    ' Akses event LinkClicked dari NavBarItem secara manual
    Public Sub TriggerNavBarItemClick(ByVal navBarItem As DevExpress.XtraNavBar.NavBarItem)
        ' Buat event args dengan item NavBar yang diinginkan
        Dim link As New DevExpress.XtraNavBar.NavBarItemLink(navBarItem)
        Dim eventArgs As New DevExpress.XtraNavBar.NavBarLinkEventArgs(link)

        ' Panggil event handler NavBarItem_LinkClicked dengan argumen yang sesuai
        NavBarItem_LinkClicked(navBarItem, eventArgs)
    End Sub

    Private Sub ButtonClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClose.Click
        Me.Close()
    End Sub

    Private Sub NavBarItem_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItemTindakanPoliUmum.LinkClicked, NavBarItemMasterPaketTindakan.LinkClicked
        ' Reset gaya dari item sebelumnya jika ada
        If lastClickedItem IsNot Nothing Then lastClickedItem.Appearance.ForeColor = Color.Empty

        ' Simpan item yang baru diklik dan setel warnanya
        lastClickedItem = e.Link.Item
        lastClickedItem.Appearance.ForeColor = Color.Gray

        ' Dapatkan caption dari link yang diklik
        Dim clickedLink As String = e.Link.Item.Caption

        ' Lakukan navigasi berdasarkan link yang diklik
        Select Case clickedLink
            Case "MASTER TINDAKAN"
                TabControlMenu.SelectedTab = TabPageMasterTindakan
            Case "MASTER PAKET TINDAKAN"
                TabControlMenu.SelectedTab = TabPageMasterPaket
            Case Else
                MessageBox.Show("Link tidak dikenali!")
        End Select
    End Sub

    Private Function ValidasiDetailPaket() As Boolean
        Dim namaPaket As String = TextBoxNamaPaket.Text.Trim()
        Dim keteranganPaket As String = TextBoxKeteranganPaket.Text.Trim()
        Dim hargaPaket As String = TextBoxHargaAwal.Text.Trim()
        Dim maksimalBHP As String = TextBoxMaksimalBHP_Paket.Text.Trim()

        ' Validasi Nama Paket
        If namaPaket = "" Then
            MsgBox("Gagal. Silahkan isi nama paket terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        ElseIf namaPaket.Length <= 4 Then
            MsgBox("Gagal. Nama paket harus lebih dari 4 karakter.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        ' Validasi Nama Poli
        'If RadioButtonPaketReguler.Checked = True AndAlso CheckedListBoxPoli2.CheckedItems.Count = 0 Then
        '    MsgBox("Silakan pilih minimal satu poli.", MsgBoxStyle.Exclamation, "Warning")
        '    Exit Function
        'ElseIf RadioButtonPaketPerTindakan.Checked = True AndAlso CheckedListBoxPoli2.CheckedItems.Count = 0 Then
        '    MsgBox("Silakan pilih minimal satu poli.", MsgBoxStyle.Exclamation, "Warning")
        '    Exit Function
        'End If

        ' Validasi Keterangan Paket
        If keteranganPaket = "" Then TextBoxKeteranganPaket.Text = "-"

        ' Validasi Kuota Paket
        If CDbl(TextBoxKuotaPaket.Value) <= 0 And RadioButtonPaketReguler.Checked = True Then
            MsgBox("Gagal. Kuota paket harus lebih dari 0.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        ' Validasi Harga Paket
        If hargaPaket = "" Then
            MessageBox.Show("Harga paket tidak boleh kosong!", "Input Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextBoxHargaAwal.Focus()
            Return False
        ElseIf Not IsNumeric(hargaPaket) Then
            MessageBox.Show("Harga paket harus berupa angka!", "Input Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextBoxHargaAwal.Focus()
            Return False
        ElseIf CDbl(hargaPaket) <= 0 Then
            MessageBox.Show("Harga paket harus lebih dari 0!", "Input Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextBoxHargaAwal.Focus()
            Return False
        End If

        ' Validasi Maksimal BHP
        If maksimalBHP.Trim() = "" Then
            TextBoxMaksimalBHP_Paket.Text = "0"
        ElseIf Not IsNumeric(maksimalBHP) Then
            MessageBox.Show("Maksimal BHP harus berupa angka!", "Input Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextBoxMaksimalBHP_Paket.Focus()
            Return False
        ElseIf CDbl(maksimalBHP) <= 0 Then
            MessageBox.Show("Maksimal BHP harus lebih dari 0!", "Input Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextBoxMaksimalBHP_Paket.Focus()
            Return False
        End If

        ' Validasi Tanggal Paket
        If TglAkhirPaket.Value.Date < TglAwalPaket.Value.Date Then
            MsgBox("Gagal. Tanggal awal tidak boleh melebihi tanggal akhir.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        ' Validasi Durasi Aktif Paket
        If CDbl(TextBoxDurasiAktifPaket.Value) <= 0 Then
            MsgBox("Gagal. Durasi aktif paket harus lebih dari 0.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        ' Kalkulasi Paket
        KalkulasiNominalPaket()

        ' Validasi Akhir
        Dim result As DialogResult = MessageBox.Show("Apakah data yang dimasukkan sudah sesuai?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.No Then
            Return False
        End If

        Return True
    End Function

    Private Sub SimpanDataPaket()
        Dim reffID As String = ""

        ' Get JSON Data Grid
        Dim jsonDataGrid As String = GenerateJsonFromGridControl(GridControlTindakan)

        'Dim poliList As New List(Of String)
        'For Each item As String In CheckedListBoxPoli2.CheckedItems
        '    poliList.Add(item)
        'Next

        'Dim poliGabung As String = String.Join(",", poliList.ToArray())

        ' Get Jenis Paket
        Dim jenisPaket As String = ""
        If RadioButtonPaketReguler.Checked = True Then
            jenisPaket = RadioButtonPaketReguler.Text
        ElseIf RadioButtonPaketPerTindakan.Checked = True Then
            jenisPaket = RadioButtonPaketPerTindakan.Text
        End If

        If TextBoxReffID.Text = "" Then ' Insert Paket
            ' Save ke tabel MasterPaketTindakan
            WriteSQL("INSERT INTO MasterPaketTindakan (NamaPaket, KeteranganPaket, JenisPaket, HargaAwal, DiskonNominal, HargaNett, Kuota, MaksimalBHP, DetailTindakan, TanggalMulai, TanggalBerakhir, DurasiAktif, CreatedBy, CreatedDate) " & _
                     "VALUES('" & TextBoxNamaPaket.Text & "', '" & TextBoxKeteranganPaket.Text & "', '" & jenisPaket & "', " & CDbl(TextBoxHargaAwal.Text) & ", " & CDbl(TextBoxTotalDiskon.Text) & ", " & CDbl(TextBoxHargaNett.Text) & ", " & CDbl(TextBoxKuotaPaket.Text) & ", " & CDbl(TextBoxMaksimalBHP_Paket.Text) & ", '" & jsonDataGrid & "', '" & Format(TglAwalPaket.Value, "MM/dd/yyyy") & "', '" & Format(TglAkhirPaket.Value, "MM/dd/yyyy") & "', " & CDbl(TextBoxDurasiAktifPaket.Text) & ", '" & userInput & "', GETDATE())", 4)

            ' Get Reff ID
            reffID = ReadSQLNIK("SELECT TOP(1) PaketID FROM MasterPaketTindakan WHERE NamaPaket = '" & TextBoxNamaPaket.Text & "' ORDER BY CreatedDate DESC")

            ' Save Detail Grid Paket
            SimpanDetailPaket(reffID)

            MsgBox("Data Paket Berhasil Disimpan.", MsgBoxStyle.Information, "Success")
        Else ' Update Paket
            reffID = TextBoxReffID.Text ' Set UUID

            Dim parameterUpdate As String = ""
            parameterUpdate = "NamaPaket = '" & TextBoxNamaPaket.Text & "'," & _
                              "KeteranganPaket = '" & TextBoxKeteranganPaket.Text & "'," & _
                              "HargaAwal = " & CDbl(TextBoxHargaAwal.Text) & "," & _
                              "DiskonNominal = " & CDbl(TextBoxTotalDiskon.Text) & "," & _
                              "HargaNett = " & CDbl(TextBoxHargaNett.Text) & "," & _
                              "Kuota = " & CDbl(TextBoxKuotaPaket.Text) & "," & _
                              "MaksimalBHP = " & CDbl(TextBoxMaksimalBHP_Paket.Text) & "," & _
                              "DetailTindakan = '" & jsonDataGrid & "'," & _
                              "TanggalMulai = '" & Format(TglAwalPaket.Value, "MM/dd/yyyy") & "'," & _
                              "TanggalBerakhir = '" & Format(TglAkhirPaket.Value, "MM/dd/yyyy") & "'," & _
                              "DurasiAktif = " & CDbl(TextBoxDurasiAktifPaket.Text) & "," & _
                              "UpdatedBy = '" & userInput & "'," & _
                              "UpdatedDate = GETDATE()"

            WriteSQL("UPDATE MasterPaketTindakan SET " & parameterUpdate & " WHERE PaketID = '" & reffID & "'", 4)

            ' Save Detail Grid Paket
            SimpanDetailPaket(reffID)

            MsgBox("Data Paket Berhasil Diperbarui.", MsgBoxStyle.Information, "Success")
        End If
    End Sub

    Private Sub SimpanDetailPaket(ByVal PaketID As String)
        Dim tblsTindakan As DataTable = GridControlTindakan.DataSource
        tblsTindakan.AcceptChanges()

        For Each rowTindakan As DataRow In tblsTindakan.Rows
            If CheckSQL("SELECT * FROM MasterPaketTindakanDetail WHERE PaketID = '" & PaketID & "' AND TindakanID = '" & rowTindakan("TindakanID") & "' AND DeletedDate IS NULL") Then
                Dim parameterUpdate As String = ""
                parameterUpdate = "NamaTindakan = '" & rowTindakan("NamaTindakan") & "'," & _
                                  "JenisTindakan = '" & rowTindakan("JenisTindakan") & "'," & _
                                  "BiayaTindakan = " & CDbl(rowTindakan("BiayaTindakan")) & "," & _
                                  "DiskonTindakan = " & CDbl(rowTindakan("DiskonTindakan")) & "," & _
                                  "NettBayar = " & CDbl(rowTindakan("NettBayar")) & "," & _
                                  "Jumlah = " & CDbl(rowTindakan("KuotaTindakan")) & "," & _
                                  "GrandTotal = " & CDbl(rowTindakan("GrandTotal")) & "," & _
                                  "UpdatedBy = '" & userInput & "'," & _
                                  "UpdatedDate = GETDATE()"

                WriteSQL("UPDATE MasterPaketTindakanDetail SET " & parameterUpdate & " WHERE PaketID = '" & PaketID & "' AND TindakanID = '" & rowTindakan("TindakanID") & "' AND DeletedDate IS NULL", 4)
            Else
                ' Save ke tabel MasterPaketTindakanDetail
                WriteSQL("INSERT INTO MasterPaketTindakanDetail (PaketID, TindakanID, NamaTindakan, JenisTindakan, BiayaTindakan, DiskonTindakan, NettBayar, Jumlah, GrandTotal, CreatedBy, CreatedDate) " & _
                         "VALUES('" & PaketID & "', '" & rowTindakan("TindakanID") & "', '" & rowTindakan("NamaTindakan") & "', '" & rowTindakan("JenisTindakan") & "', " & CDbl(rowTindakan("BiayaTindakan")) & ", " & CDbl(rowTindakan("DiskonTindakan")) & ", " & CDbl(rowTindakan("NettBayar")) & ", " & CDbl(rowTindakan("KuotaTindakan")) & ", " & CDbl(rowTindakan("GrandTotal")) & ", '" & userInput & "', GETDATE())", 4)
            End If
        Next
    End Sub

    Private Sub ClearDataMenuPaket()
        TextBoxReffID.ResetText()
        TextBoxNamaPaket.ResetText()
        TextBoxKeteranganPaket.ResetText()
        TextBoxKuotaPaket.Value = 0
        TextBoxMaksimalBHP_Paket.ResetText()
        TextBoxHargaAwal.ResetText()
        TextBoxTotalDiskon.ResetText()
        TextBoxHargaNett.ResetText()
        TglAwalPaket.Value = Date.Now
        TglAkhirPaket.Value = Date.Now
        TextBoxDurasiAktifPaket.Value = 0

        'For i As Integer = 0 To CheckedListBoxPoli2.Items.Count - 1
        '    CheckedListBoxPoli2.SetItemChecked(i, False)
        'Next
        'CheckedListBoxPoli2.Enabled = True

        RadioButtonPaketReguler.Checked = True
        RadioButtonPaketReguler.Enabled = True
        RadioButtonPaketPerTindakan.Enabled = True

        SetDataGrid()
    End Sub

    Private Sub ButtonDetailTindakanPaket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDetailTindakanPaket.Click
        FindMultiple.Show()
        FindMultiple.Query("SELECT TindakanID, NamaTindakan, JenisTindakan, JenisDokter, BiayaTindakan FROM MasterTindakan WHERE Closed = 0 ", " ORDER BY JenisTindakan, NamaTindakan", "FindPaketKlinikDetail", 1)
    End Sub

    Public Sub AddTindakanDetail(ByRef Trow() As DataRow)
        Dim Tbls As DataTable = GridControlTindakan.DataSource
        If Trow.Count > 0 Then
            For i As Integer = 0 To Trow.Length - 1
                ' Validasi: Cek apakah TindakanID sudah ada di DataTable
                Dim TindakanID As String = Trow(i)("TindakanID").ToString()
                Dim alreadyExists As Boolean = False

                ' Loop untuk cek apakah TindakanID sudah ada di DataTable
                For Each row As DataRow In Tbls.Rows
                    If row("TindakanID").ToString() = TindakanID Then
                        alreadyExists = True
                        Exit For
                    End If
                Next

                ' Jika sudah ada, berikan pesan peringatan, jika tidak, tambahkan
                If alreadyExists Then
                    MessageBox.Show("Tindakan dengan ID " & Trow(i)("NamaTindakan").ToString() & " sudah ada.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    ' Jika TindakanID belum ada, tambahkan row baru
                    Dim Tnew As DataRow = Tbls.NewRow
                    Tnew("TindakanID") = TindakanID
                    Tnew("NamaTindakan") = Trow(i)("NamaTindakan")
                    Tnew("JenisTindakan") = Trow(i)("JenisTindakan")
                    Tnew("BiayaTindakan") = Trow(i)("BiayaTindakan")
                    Tnew("DiskonTindakan") = "0"
                    Tnew("NettBayar") = Trow(i)("BiayaTindakan")
                    Tnew("KuotaTindakan") = "1"
                    Tnew("GrandTotal") = Trow(i)("BiayaTindakan")
                    Tbls.Rows.Add(Tnew)
                End If
            Next
            Tbls.AcceptChanges()
        End If
    End Sub

    Private Sub ButtonFindPaket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFindPaket.Click
        Find.Show()
        Find.Query("SELECT NamaPaket, KeteranganPaket, HargaNett, TanggalMulai, TanggalBerakhir, PaketID FROM MasterPaketTindakan", " ORDER BY CreatedDate DESC", "FindPaketTindakanKlinik", 2)
    End Sub

    Public Sub LoadDetailPaket(ByRef PaketID As String)
        ClearDataMenuPaket()

        Dim Tbls As DataTable = ReadSQL("SELECT * FROM MasterPaketTindakan WHERE PaketID = '" & PaketID & "'")
        Dim rowPaket As DataRow = Tbls.Rows(0)

        TextBoxReffID.Text = PaketID
        TextBoxNamaPaket.Text = rowPaket("NamaPaket")
        TextBoxKeteranganPaket.Text = rowPaket("KeteranganPaket")
        TextBoxKuotaPaket.Text = rowPaket("Kuota")
        TextBoxMaksimalBHP_Paket.Text = String.Format("{0:N}", rowPaket("MaksimalBHP"))
        TextBoxHargaAwal.Text = String.Format("{0:N}", rowPaket("HargaAwal"))
        TextBoxTotalDiskon.Text = String.Format("{0:N}", rowPaket("DiskonNominal"))
        TextBoxHargaNett.Text = String.Format("{0:N}", rowPaket("HargaNett"))
        TglAwalPaket.Value = rowPaket("TanggalMulai")
        TglAkhirPaket.Value = rowPaket("TanggalBerakhir")
        TextBoxDurasiAktifPaket.Text = rowPaket("DurasiAktif")

        'If Not IsDBNull(rowPaket("PoliTujuan")) Then
        '    Dim namaPoliGabungan As String = rowPaket("PoliTujuan").ToString()
        '    Dim daftarPoli() As String = namaPoliGabungan.Split(","c)

        '    For i As Integer = 0 To CheckedListBoxPoli2.Items.Count - 1
        '        Dim itemPoli As String = CheckedListBoxPoli2.Items(i).ToString()

        '        ' Tandai dicentang jika termasuk dalam data poli
        '        If daftarPoli.Contains(itemPoli) Then
        '            CheckedListBoxPoli2.SetItemChecked(i, True)
        '        End If
        '    Next
        'End If

        ' Set Jenis Paket
        If rowPaket("JenisPaket").ToString() = "Paket Reguler" Then
            RadioButtonPaketReguler.Checked = True
            RadioButtonPaketPerTindakan.Enabled = False
            GridViewTindakan.Columns("KuotaTindakan").OptionsColumn.AllowEdit = False
        ElseIf rowPaket("JenisPaket").ToString() = "Paket Per-Tindakan" Then
            RadioButtonPaketPerTindakan.Checked = True
            RadioButtonPaketReguler.Enabled = False
            GridViewTindakan.Columns("KuotaTindakan").OptionsColumn.AllowEdit = True
        End If

        SetDataGrid()
    End Sub

    Private Sub ButtonKalkulasiPaket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonKalkulasiPaket.Click
        KalkulasiNominalPaket()
    End Sub

    Function KalkulasiNominalPaket() As Boolean
        Dim totalHargaAwal As Double = 0
        Dim totalDiskon As Double = 0
        Dim totalHargaNett As Double = 0
        Dim tblTindakan As DataTable = GridControlTindakan.DataSource

        ' Validasi Kuota Paket
        If CDbl(TextBoxKuotaPaket.Value) <= 0 And RadioButtonPaketReguler.Checked = True Then
            MsgBox("Gagal. Kuota paket harus lebih dari 0.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        ' Validasi Inputan Tindakan Detail
        If tblTindakan IsNot Nothing AndAlso tblTindakan.Rows.Count > 0 Then
            tblTindakan.AcceptChanges()
            tblTindakan.Columns("DiskonTindakan").ReadOnly = False
            tblTindakan.Columns("GrandTotal").ReadOnly = False

            For Each rowTindakan As DataRow In tblTindakan.Rows
                If CDbl(rowTindakan("NettBayar")) <= 0 Then
                    MessageBox.Show("Nominal harga tindakan " & rowTindakan("NamaTindakan") & " harus lebih dari Rp. 0!", "Input Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                ElseIf CDbl(rowTindakan("KuotaTindakan")) <= 0 Then
                    MessageBox.Show("KuotaTindakan " & rowTindakan("NamaTindakan") & " harus lebih dari 0!", "Input Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                ElseIf CDbl(rowTindakan("BiayaTindakan")) < CDbl(rowTindakan("NettBayar")) Then
                    MessageBox.Show("nominal bayar tindakan " & rowTindakan("NamaTindakan") & " melebihi biaya tindakan!", "Input Tidak Valid", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return False
                Else
                    ' Update Nominal Diskon di Grid
                    Dim nominalDiskon As Double = CDbl(rowTindakan("BiayaTindakan")) - CDbl(rowTindakan("NettBayar"))
                    rowTindakan("DiskonTindakan") = nominalDiskon

                    ' Update Nominal Grand Total di Grid
                    Dim grandTotal As Double = CDbl(rowTindakan("NettBayar")) * CDbl(rowTindakan("KuotaTindakan"))
                    rowTindakan("GrandTotal") = grandTotal

                    If RadioButtonPaketReguler.Checked = True Then
                        totalHargaAwal = totalHargaAwal + (rowTindakan("BiayaTindakan") * TextBoxKuotaPaket.Value)
                        totalDiskon = totalDiskon + (rowTindakan("DiskonTindakan") * TextBoxKuotaPaket.Value)
                        totalHargaNett = totalHargaNett + (rowTindakan("NettBayar") * TextBoxKuotaPaket.Value)
                    ElseIf RadioButtonPaketPerTindakan.Checked = True Then
                        totalHargaAwal = totalHargaAwal + (rowTindakan("BiayaTindakan") * rowTindakan("KuotaTindakan"))
                        totalDiskon = totalDiskon + (rowTindakan("DiskonTindakan") * rowTindakan("KuotaTindakan"))
                        totalHargaNett = totalHargaNett + (rowTindakan("NettBayar") * rowTindakan("KuotaTindakan"))
                    End If
                End If
            Next
        End If

        TextBoxHargaAwal.Text = String.Format("{0:N}", totalHargaAwal)
        TextBoxTotalDiskon.Text = String.Format("{0:N}", totalDiskon)
        TextBoxHargaNett.Text = String.Format("{0:N}", totalHargaNett)

        Return True
    End Function

    Private Sub ButtonHapusDetailTindakan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonHapusDetailTindakan.Click
        ' Dapatkan baris yang dipilih
        Dim selectedRow As Integer = GridViewTindakan.FocusedRowHandle

        If selectedRow >= 0 Then
            ' Dapatkan nilai ID atau kolom utama dari baris yang dipilih
            Dim tindakanID As String = GridViewTindakan.GetRowCellValue(selectedRow, "TindakanID")

            If MessageBox.Show("Apakah Anda yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If TextBoxReffID.Text <> "" Then
                    Dim parameterUpdate As String = ""

                    ' Hapus Data MasterPaketTindakanDetail
                    parameterUpdate = "DeletedBy = '" & userInput & "'," & _
                                      "DeletedDate = GETDATE()"

                    WriteSQL("UPDATE MasterPaketTindakanDetail SET " & parameterUpdate & " WHERE PaketID = '" & TextBoxReffID.Text & "' AND TindakanID = '" & tindakanID & "' AND DeletedDate IS NULL", 4)
                End If

                GridViewTindakan.DeleteRow(selectedRow)
                MsgBox("Data Tindakan Berhasil Dihapus.", MsgBoxStyle.Information, "Success")
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim jsonData As String = GenerateJsonFromGridControl(GridControlTindakan)

        Dim tblTindakan As DataTable = JsonConvert.DeserializeObject(Of DataTable)(jsonData)

        '' Periksa jika DataTable berisi data
        'If tblTindakan.Rows.Count > 0 Then
        '    DataGridView.DataSource = tblTindakan
        'Else
        '    MessageBox.Show("Tidak ada data JSON yang tersedia.")
        'End If

        MsgBox(jsonData)
    End Sub

    Private Sub RadioButtonAktifFee_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonAktifFee.CheckedChanged
        If RadioButtonAktifFee.Checked = True Then
            SplitContainerFeeTindakan.Panel2Collapsed = False
        ElseIf RadioButtonNonAktifFee.Checked = True Then
            SplitContainerFeeTindakan.Panel2Collapsed = True
        End If
    End Sub

    Private Sub RadioButtonNonAktifFee_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonNonAktifFee.CheckedChanged
        If RadioButtonAktifFee.Checked = True Then
            SplitContainerFeeTindakan.Panel2Collapsed = False
        ElseIf RadioButtonNonAktifFee.Checked = True Then
            SplitContainerFeeTindakan.Panel2Collapsed = True

            ' Clear Field
            TextBoxPersentaseFeePerusahaan.Text = "0"
            TextBoxPersentaseFeeKaryawan.Text = "0"
            TextBoxNominalFee.Text = "0"
            TextBoxFeeDokterTambahan.Text = "0"
            TextBoxFeePerawatTambahan.Text = "0"
        End If
    End Sub

    Private Sub ButtonFindTindakan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFindTindakan.Click
        Dim stringQuery As String = ""
        Dim stringQueryOrder As String = " ORDER BY TindakanID"

        If RadioButtonPoliUmum.Checked = True Then
            stringQuery = "SELECT TindakanID, NamaTindakan, JenisTindakan, BiayaTindakan, JenisDokter AS 'Pelaksana', CASE WHEN Closed = 0 THEN 'Aktif' WHEN Closed = 1 THEN 'Tidak Aktif' END AS StatusTindakan from MasterTindakan"
        ElseIf RadioButtonPoliGigi.Checked = True Then
            stringQuery = "SELECT TindakanID, NamaTindakan, JenisTindakan, BiayaTindakan, JenisDokter AS 'Pelaksana', CASE WHEN Closed = 0 THEN 'Aktif' WHEN Closed = 1 THEN 'Tidak Aktif' END AS StatusTindakan FROM MasterTindakanGigi"
        End If

        Find.Show()
        Find.Query(stringQuery, stringQueryOrder, "FindMasterTindakanKlinik", 2)
    End Sub

    Public Sub LoadTindakanPoli(ByRef TindakanID As String)
        ClearDataMenuTindakan()

        Dim tblTindakan As DataTable = New DataTable

        If RadioButtonPoliUmum.Checked = True Then
            tblTindakan = ReadSQL("SELECT * FROM MasterTindakan WHERE TindakanID = '" & TindakanID & "'")
        ElseIf RadioButtonPoliGigi.Checked = True Then
            tblTindakan = ReadSQL("SELECT * FROM MasterTindakanGigi WHERE TindakanID = '" & TindakanID & "'")
        End If

        Dim rowTindakan As DataRow = tblTindakan.Rows(0)

        If Convert.ToInt32(rowTindakan("Closed")) = 1 Then CheckBoxStatusAktifTindakan.Checked = False
        If Convert.ToInt32(rowTindakan("Closed")) = 0 Then CheckBoxStatusAktifTindakan.Checked = True

        TextBoxTindakanID.Text = rowTindakan("TindakanID").ToString
        TextBoxNamaTindakan.Text = rowTindakan("NamaTindakan").ToString
        ComboBoxGroupJenisTindakan.Text = rowTindakan("JenisTindakan").ToString
        If rowTindakan("JenisDokter").ToString = "Dokter" Then RadioButtonPelaksanaDokter.Checked = True
        If rowTindakan("JenisDokter").ToString = "Perawat" Then RadioButtonPelaksanaPerawat.Checked = True
        TextBoxBiayaTindakan.Text = Splitmoney(rowTindakan("BiayaTindakan"))

        'Set Poli
        'If Not IsDBNull(rowTindakan("PoliTujuan")) Then
        '    Dim namaPoliGabungan As String = rowTindakan("PoliTujuan").ToString()
        '    Dim daftarPoli() As String = namaPoliGabungan.Split(","c)

        '    For i As Integer = 0 To CheckedListBoxPoli.Items.Count - 1
        '        Dim itemPoli As String = CheckedListBoxPoli.Items(i).ToString()

        '        ' Tandai dicentang jika termasuk dalam data poli
        '        If daftarPoli.Contains(itemPoli) Then
        '            CheckedListBoxPoli.SetItemChecked(i, True)
        '        End If
        '    Next
        'End If

        'Set Reminder
        If Convert.ToInt32(rowTindakan("Reminder")) = 1 Then CheckBoxReminder.Checked = True
        If Convert.ToInt32(rowTindakan("Reminder")) = 0 Then CheckBoxReminder.Checked = False
        If IsDBNull(rowTindakan("Hari")) = False Then TextBoxHariReminder.Text = rowTindakan("Hari")

        ' Set Informed Consent
        If Convert.ToInt32(rowTindakan("StatusInformedConsent")) = 1 Then CheckBoxInformedConsent.Checked = True
        If Convert.ToInt32(rowTindakan("StatusInformedConsent")) = 0 Then CheckBoxInformedConsent.Checked = False
        If IsDBNull(rowTindakan("TindakanInformedConsent")) = False Then ComboBoxInformedConsent.Text = rowTindakan("TindakanInformedConsent")

        ' Set Status Aktif Fee Tindakan
        If Convert.ToInt32(rowTindakan("StatusFeeTindakan")) = 1 Then RadioButtonAktifFee.Checked = True
        If Convert.ToInt32(rowTindakan("StatusFeeTindakan")) = 0 Then RadioButtonNonAktifFee.Checked = True

        ' Set Status Persentase / Nominal
        If Convert.ToInt32(rowTindakan("StatusPersentaseFee")) = 1 Then RadioButtonOpsiPersentase.Checked = True
        If Convert.ToInt32(rowTindakan("StatusNominalFee")) = 1 Then RadioButtonOpsiNominal.Checked = True

        ' Set Status BHP
        If Convert.ToInt32(rowTindakan("StatusBHP")) = 1 Then RadioButtonBHP.Checked = True
        If Convert.ToInt32(rowTindakan("StatusBHP")) = 0 Then RadioButtonNonBHP.Checked = True

        ' Set Value
        If IsDBNull(rowTindakan("PersentaseFeePerusahaan")) = False Then TextBoxPersentaseFeePerusahaan.Text = rowTindakan("PersentaseFeePerusahaan")
        If IsDBNull(rowTindakan("PersentaseFeeKaryawan")) = False Then TextBoxPersentaseFeeKaryawan.Text = rowTindakan("PersentaseFeeKaryawan")
        If IsDBNull(rowTindakan("FeePerTindakan")) = False Then TextBoxNominalFee.Text = Splitmoney(rowTindakan("FeePerTindakan"))
        If IsDBNull(rowTindakan("MaksimalBHP")) = False Then TextBoxMaksimalBHP_Tindakan.Text = Splitmoney(rowTindakan("MaksimalBHP"))

        If IsDBNull(rowTindakan("FeeDokter")) = False Then TextBoxFeeDokterTambahan.Text = Splitmoney(rowTindakan("FeeDokter"))
        If IsDBNull(rowTindakan("FeePerawat")) = False Then TextBoxFeePerawatTambahan.Text = Splitmoney(rowTindakan("FeePerawat"))
    End Sub

    Private Sub ClearDataMenuTindakan()
        SplitContainerFeeTindakan.Panel2Collapsed = True

        TextBoxTindakanID.ResetText()
        TextBoxNamaTindakan.ResetText()

        CheckBoxInformedConsent.Checked = False
        RadioButtonPelaksanaDokter.Checked = True
        RadioButtonNonAktifFee.Checked = True
        RadioButtonOpsiPersentase.Checked = True
        RadioButtonNonBHP.Checked = True
        CheckBoxStatusAktifTindakan.Checked = True

        TextBoxBiayaTindakan.Text = "0"
        TextBoxFeeDokterTambahan.Text = "0"
        TextBoxFeePerawatTambahan.Text = "0"
        TextBoxMaksimalBHP_Tindakan.Text = "0"
        TextBoxPersentaseFeePerusahaan.Text = "0"
        TextBoxPersentaseFeeKaryawan.Text = "0"
        TextBoxNominalFee.Text = "0"

        'For i As Integer = 0 To CheckedListBoxPoli.Items.Count - 1
        '    CheckedListBoxPoli.SetItemChecked(i, False)
        'Next
        'CheckedListBoxPoli.Enabled = True

        CheckBoxReminder.Checked = False
        TextBoxHariReminder.ResetText()
        TextBoxHariReminder.ReadOnly = True

        If RadioButtonPoliUmum.Checked = True Then
            InsertNewItemComboSQL("SELECT DISTINCT JenisTindakan FROM MasterTindakan", ComboBoxGroupJenisTindakan)
        ElseIf RadioButtonPoliGigi.Checked = True Then
            InsertNewItemComboSQL("SELECT DISTINCT JenisTindakan FROM MasterTindakanGigi", ComboBoxGroupJenisTindakan)
        End If

        InsertNewItemComboSQL("SELECT DISTINCT NamaTindakan FROM Klinik_MasterTindakanInformedConsent", ComboBoxInformedConsent)

        ComboBoxGroupJenisTindakan.SelectedIndex = -1
        ComboBoxInformedConsent.SelectedIndex = -1
        ComboBoxInformedConsent.Enabled = False
    End Sub

    Private Sub LoadPoliData()
        CheckedListBoxPoli.Items.Clear()
        Dim poli As DataTable = ReadSQL("SELECT * FROM MasterPoliTujuan WHERE PoliSakit = 'True'")
        If poli IsNot Nothing Then
            For Each TrowPoliTujuan As DataRow In poli.Rows
                CheckedListBoxPoli.Items.Add(TrowPoliTujuan("NamaPoli").ToString())
            Next
        End If
    End Sub

    'Private Sub LoadPoliDataPaket()
    '    CheckedListBoxPoli2.Items.Clear()
    '    Dim poli As DataTable = ReadSQL("SELECT * FROM MasterPoliTujuan WHERE PoliSakit = 'True'")
    '    If poli IsNot Nothing Then
    '        For Each TrowPoliTujuan As DataRow In poli.Rows
    '            CheckedListBoxPoli2.Items.Add(TrowPoliTujuan("NamaPoli").ToString())
    '        Next
    '    End If
    'End Sub

    Private Sub SimpanDataTindakan()
        Dim statusFee As Boolean = False
        Dim statusPersentase As Boolean = False
        Dim statusNominal As Boolean = False
        Dim statusBHP As Boolean = False
        Dim statusFeeKonsultasi As Boolean = False
        Dim statusInformedConsent As Boolean = False
        Dim jenisPelaksana As String = ""

        ' Set Jenis Pelaksana
        If RadioButtonPelaksanaDokter.Checked = True Then
            jenisPelaksana = "Dokter"
        ElseIf RadioButtonPelaksanaPerawat.Checked = True Then
            jenisPelaksana = "Perawat"
        End If

        'Reminder
        Dim statusReminder As Integer = If(CheckBoxReminder.Checked, 1, 0)
        Dim hari As String
        If TextBoxHariReminder.Text.Trim() = "" Then
            hari = "NULL" ' tanpa tanda kutip
        Else
            hari = "'" & TextBoxHariReminder.Text.Trim().Replace("'", "''") & "'" ' tetap dalam kutip
        End If

        'Filter Poli
        'If RadioButtonPelaksanaDokter.Checked Then
        '    jenisPelaksana = "Dokter"
        'ElseIf RadioButtonPelaksanaPerawat.Checked Then
        '    jenisPelaksana = "Perawat"
        'Else
        '    MessageBox.Show("Silakan pilih jenis pelaksana (Dokter atau Perawat).", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Exit Sub
        'End If

        'Dim poliList As New List(Of String)
        'For Each item As String In CheckedListBoxPoli.CheckedItems
        '    poliList.Add(item)
        'Next

        'Dim poliGabung As String = String.Join(",", poliList.ToArray())

        ' Set Status BHP
        If RadioButtonBHP.Checked = True Then statusBHP = True

        ' Set Status Informed Consent
        If CheckBoxInformedConsent.Checked = True Then statusInformedConsent = True

        ' Set Status Aktif Fee Tindakan
        If RadioButtonAktifFee.Checked = True Then statusFee = True

        If statusFee = True And ComboBoxGroupJenisTindakan.Text.Contains("Konsultasi") = False Then
            ' Set Status Persentase / Nominal
            If RadioButtonOpsiPersentase.Checked = True Then statusPersentase = True
            If RadioButtonOpsiNominal.Checked = True Then statusNominal = True
        Else
            statusPersentase = False
            statusNominal = False
            statusFeeKonsultasi = True
        End If

        If TextBoxTindakanID.Text = "" Then
            ' Insert Data Baru 
            If RadioButtonPoliUmum.Checked = True Then
                WriteSQL("INSERT INTO MasterTindakan ([NamaTindakan], [JenisTindakan], [BiayaTindakan], [JenisDokter], [CreatedDate], [CreatedBy], [StatusFeeTindakan], [StatusBHP], [StatusPersentaseFee], [StatusNominalFee], [PersentaseFeePerusahaan], [PersentaseFeeKaryawan], [FeePerTindakan], [FeeDokter], [FeePerawat], [StatusFeeKonsultasi], [MaksimalBHP], [StatusInformedConsent], [TindakanInformedConsent], [Hari], [Reminder]) " & _
                         "VALUES('" & TextBoxNamaTindakan.Text.Replace("'", "''") & "','" & ComboBoxGroupJenisTindakan.Text.Replace("'", "''") & "'," & CInt(TextBoxBiayaTindakan.Text) & ", '" & jenisPelaksana & "', GETDATE(), '" & userInput & "', " & _
                         CInt(statusFee) & ", " & CInt(statusBHP) & ", " & CInt(statusPersentase) & ", " & CInt(statusNominal) & ", " & _
                         CDbl(TextBoxPersentaseFeePerusahaan.Text) & ", " & CDbl(TextBoxPersentaseFeeKaryawan.Text) & ", " & CDbl(TextBoxNominalFee.Text) & ", " & _
                         CDbl(TextBoxFeeDokterTambahan.Text) & ", " & CDbl(TextBoxFeePerawatTambahan.Text) & ", " & CInt(statusFeeKonsultasi) & ", " & _
                         CDbl(TextBoxMaksimalBHP_Tindakan.Text) & ", " & CInt(statusInformedConsent) & ", '" & ComboBoxInformedConsent.Text.Replace("'", "''") & "', " & hari & ", " & statusReminder & ")", 4)

            ElseIf RadioButtonPoliGigi.Checked = True Then
                WriteSQL("INSERT INTO MasterTindakanGigi ([NamaTindakan], [JenisTindakan], [BiayaTindakan], [JenisDokter], [CreatedDate], [CreatedBy], [StatusFeeTindakan], [StatusBHP], [StatusPersentaseFee], [StatusNominalFee], [PersentaseFeePerusahaan], [PersentaseFeeKaryawan], [FeePerTindakan], [FeeDokter], [FeePerawat], [StatusFeeKonsultasi], [MaksimalBHP], [StatusInformedConsent], [TindakanInformedConsent], [Hari], [Reminder], [PoliTujuan]) " & _
                         "VALUES('" & TextBoxNamaTindakan.Text.Replace("'", "''") & "', '" & ComboBoxGroupJenisTindakan.Text.Replace("'", "''") & "', " & CInt(TextBoxBiayaTindakan.Text) & ", '" & jenisPelaksana & "', GETDATE(), '" & userInput & "', " & _
                         CInt(statusFee) & ", " & CInt(statusBHP) & ", " & CInt(statusPersentase) & ", " & CInt(statusNominal) & ", " & _
                         CDbl(TextBoxPersentaseFeePerusahaan.Text) & ", " & CDbl(TextBoxPersentaseFeeKaryawan.Text) & ", " & CDbl(TextBoxNominalFee.Text) & ", " & _
                         CDbl(TextBoxFeeDokterTambahan.Text) & ", " & CDbl(TextBoxFeePerawatTambahan.Text) & ", " & CInt(statusFeeKonsultasi) & ", " & _
                         CDbl(TextBoxMaksimalBHP_Tindakan.Text) & ", " & CInt(statusInformedConsent) & ", '" & ComboBoxInformedConsent.Text.Replace("'", "''") & "', " & hari & ", " & statusReminder & ", 'PoliGigi')", 4)
            End If

            ClearDataMenuTindakan()
            MsgBox("Berhasil Menyimpan Data.", MsgBoxStyle.Information, "Success!")
        Else
            Dim parameterUpdate As String = ""
            parameterUpdate = "NamaTindakan = '" & TextBoxNamaTindakan.Text & "'," & _
                              "JenisTindakan = '" & ComboBoxGroupJenisTindakan.Text & "'," & _
                              "BiayaTindakan = " & CInt(TextBoxBiayaTindakan.Text) & "," & _
                              "JenisDokter = '" & jenisPelaksana & "'," & _
                              "StatusInformedConsent = '" & statusInformedConsent & "'," & _
                              "TindakanInformedConsent = '" & ComboBoxInformedConsent.Text & "'," & _
                              "StatusFeeTindakan = '" & statusFee & "'," & _
                              "StatusBHP = '" & statusBHP & "'," & _
                              "StatusPersentaseFee = '" & statusPersentase & "'," & _
                              "StatusNominalFee = '" & statusNominal & "'," & _
                              "PersentaseFeePerusahaan = '" & CDbl(TextBoxPersentaseFeePerusahaan.Text) & "'," & _
                              "PersentaseFeeKaryawan = '" & CDbl(TextBoxPersentaseFeeKaryawan.Text) & "'," & _
                              "FeePerTindakan = '" & CDbl(TextBoxNominalFee.Text) & "'," & _
                              "FeeDokter = '" & CDbl(TextBoxFeeDokterTambahan.Text) & "'," & _
                              "FeePerawat = '" & CDbl(TextBoxFeePerawatTambahan.Text) & "'," & _
                              "StatusFeeKonsultasi = '" & statusFeeKonsultasi & "'," & _
                              "MaksimalBHP = '" & CDbl(TextBoxMaksimalBHP_Tindakan.Text) & "'," & _
                              "Hari = " & hari & "," & _
                              "Reminder = '" & statusReminder & "'," & _
                              "UpdatedBy = '" & userInput & "'," & _
                              "UpdatedDate = GETDATE()"

            ' Insert Data Baru 
            If RadioButtonPoliUmum.Checked = True Then
                WriteSQL("UPDATE MasterTindakan SET " & parameterUpdate & " WHERE TindakanID = '" & TextBoxTindakanID.Text & "'", 4)
            ElseIf RadioButtonPoliGigi.Checked = True Then
                WriteSQL("UPDATE MasterTindakanGigi SET " & parameterUpdate & " WHERE TindakanID = '" & TextBoxTindakanID.Text & "'", 4)
            End If

            ClearDataMenuTindakan()
            MsgBox("Berhasil Menyimpan Data.", MsgBoxStyle.Information, "Success!")
        End If
    End Sub

    Function ValidasiTindakan() As Boolean
        ' Validasi Nama Tindakan
        If TextBoxNamaTindakan.Text.Trim = "" Then MsgBox("Nama tindakan harus diisi.", MsgBoxStyle.Exclamation, "Warning!") : Return False

        ' Validasi jenis tindakan
        If ComboBoxGroupJenisTindakan.FindStringExact(ComboBoxGroupJenisTindakan.Text) < 0 Then
            If MsgBox("Tindakan group menu baru ?", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then
                MsgBox("Pilih tindakan group yang sesuai.", MsgBoxStyle.Exclamation, "Warning!") : Return False
            End If
        End If

        ' Validasi Nama Poli
        'If RadioButtonPoliUmum.Checked = True AndAlso CheckedListBoxPoli.CheckedItems.Count = 0 Then
        '    MsgBox("Silakan pilih minimal satu poli.", MsgBoxStyle.Exclamation, "Warning")
        '    Exit Function
        'End If

        ' Validasi biaya tindakan kurang dari 0
        'If CDbl(TextBoxBiayaTindakan.Text) <= 0 Then MsgBox("Biaya harus lebih besar dari 0.", MsgBoxStyle.Exclamation, "Warning!") : Return False

        ' Validasi informed consent
        If CheckBoxInformedConsent.Checked = True Then
            If ComboBoxInformedConsent.FindStringExact(ComboBoxInformedConsent.Text) < 0 Then
                MsgBox("Pilih kelompok informed consent terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!") : Return False
            End If
        End If

        ' Validasi Maksimal BHP jika memilih BHP
        If RadioButtonBHP.Checked = True And CDbl(TextBoxMaksimalBHP_Tindakan.Text) = 0 And ComboBoxGroupJenisTindakan.Text.Contains("Konsultasi") = False Then
            MsgBox("Isi maksimal BHP terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!") : Return False
        End If

        ' Validasi Fee Tindakan
        If RadioButtonAktifFee.Checked = True And ComboBoxGroupJenisTindakan.Text.Contains("Konsultasi") = False Then
            ' Validasi Persentase & Nominal Tindakan
            If RadioButtonOpsiPersentase.Checked = True And (CDbl(TextBoxPersentaseFeeKaryawan.Text) = 0 Or CDbl(TextBoxPersentaseFeePerusahaan.Text) = 0) Then
                MsgBox("Lengkapi nilai persentase terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!") : Return False
            ElseIf RadioButtonOpsiNominal.Checked = True And CDbl(TextBoxNominalFee.Text) = 0 Then
                MsgBox("Lengkapi nilai fee tindakan terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!") : Return False
            End If
        End If

        ' Validasi nama tindakan sudah ada atau belum
        If TextBoxTindakanID.Text <> "" Then
            Dim jenisPelaksana As String = ""

            ' Set Jenis Pelaksana
            If RadioButtonPelaksanaDokter.Checked = True Then
                jenisPelaksana = "Dokter"
            ElseIf RadioButtonPelaksanaPerawat.Checked = True Then
                jenisPelaksana = "Perawat"
            End If

            If RadioButtonPoliUmum.Checked = True Then
                If CheckSQL("SELECT * FROM MasterTindakan WHERE Closed = 0 AND [NamaTindakan]='" & TextBoxNamaTindakan.Text & "' AND [JenisTindakan]='" & ComboBoxGroupJenisTindakan.Text & "' AND JenisDokter = '" & jenisPelaksana & "' AND TindakanID NOT IN ('" & TextBoxTindakanID.Text & "')") = True Then
                    MsgBox("Sudah ada 'Nama Tindakan' dan 'Jenis Tindakan' yang sama. Mohon check kembali.", MsgBoxStyle.Exclamation, "Warning!")
                    Return False
                End If
            ElseIf RadioButtonPoliGigi.Checked = True Then
                If CheckSQL("SELECT * FROM MasterTindakanGigi WHERE Closed = 0 AND [NamaTindakan]='" & TextBoxNamaTindakan.Text & "' AND [JenisTindakan]='" & ComboBoxGroupJenisTindakan.Text & "' AND JenisDokter = '" & jenisPelaksana & "' AND TindakanID NOT IN ('" & TextBoxTindakanID.Text & "')") = True Then
                    MsgBox("Sudah ada 'Nama Tindakan' dan 'Jenis Tindakan' yang sama. Mohon check kembali.", MsgBoxStyle.Exclamation, "Warning!")
                    Return False
                End If
            End If
        End If

        Return True
    End Function

    Private Sub CheckBoxStatusAktifTindakan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxStatusAktifTindakan.CheckedChanged
        If CheckBoxStatusAktifTindakan.CheckState = CheckState.Unchecked And TextBoxTindakanID.Text <> "" Then
            If RadioButtonPoliUmum.Checked = True Then
                If CheckSQL("SELECT * FROM MasterTindakan WHERE TindakanID = '" & TextBoxTindakanID.Text & "' AND Closed = 0") = True Then
                    If MsgBox("Yakin Tindakan diclosed ? ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        WriteSQL("UPDATE MasterTindakan SET Closed = 1, ClosedBy = '" & userInput & "', ClosedDate = GETDATE() WHERE TindakanID = '" & TextBoxTindakanID.Text & "'", 4)
                        MsgBox("Tindakan berhasil diclosed.", MsgBoxStyle.Information, "Berhasil")

                    Else
                        CheckBoxStatusAktifTindakan.Checked = True
                    End If
                End If
            ElseIf RadioButtonPoliGigi.Checked = True Then
                If CheckSQL("SELECT * FROM MasterTindakanGigi WHERE TindakanID = '" & TextBoxTindakanID.Text & "' AND Closed = 0") = True Then
                    If MsgBox("Yakin Tindakan diclosed ? ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        WriteSQL("UPDATE MasterTindakanGigi SET Closed = 1, ClosedBy = '" & userInput & "', ClosedDate = GETDATE() WHERE TindakanID = '" & TextBoxTindakanID.Text & "'", 4)
                        MsgBox("Tindakan berhasil diclosed.", MsgBoxStyle.Information, "Berhasil")
                    Else
                        CheckBoxStatusAktifTindakan.Checked = True
                    End If
                End If
            End If
        ElseIf CheckBoxStatusAktifTindakan.CheckState = CheckState.Checked And TextBoxTindakanID.Text <> "" Then
            If RadioButtonPoliUmum.Checked = True Then
                If CheckSQL("SELECT * FROM MasterTindakan WHERE TindakanID = '" & TextBoxTindakanID.Text & "' AND Closed = 1") = True Then
                    If MsgBox("Yakin Tindakan diunclosed ? ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        WriteSQL("UPDATE MasterTindakan SET Closed = 0, ClosedBy = NULL, ClosedDate = NULL, UpdatedBy = '" & userInput & "', UpdatedDate = GETDATE() WHERE TindakanID = '" & TextBoxTindakanID.Text & "'", 4)
                        MsgBox("Tindakan berhasil diunclosed.", MsgBoxStyle.Information, "Berhasil")
                    Else
                        CheckBoxStatusAktifTindakan.Checked = False
                    End If
                End If
            ElseIf RadioButtonPoliGigi.Checked = True Then
                If CheckSQL("SELECT * FROM MasterTindakanGigi WHERE TindakanID = '" & TextBoxTindakanID.Text & "' AND Closed = 1") = True Then
                    If MsgBox("Yakin Tindakan diunclosed ? ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        WriteSQL("UPDATE MasterTindakanGigi SET Closed = 0, ClosedBy = NULL, ClosedDate = NULL, UpdatedBy = '" & userInput & "', UpdatedDate = GETDATE() WHERE TindakanID = '" & TextBoxTindakanID.Text & "'", 4)
                        MsgBox("Tindakan berhasil diunclosed.", MsgBoxStyle.Information, "Berhasil")
                    Else
                        CheckBoxStatusAktifTindakan.Checked = False
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub CheckBoxInformedConsent_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxInformedConsent.CheckedChanged
        If CheckBoxInformedConsent.CheckState = CheckState.Checked Then
            ComboBoxInformedConsent.SelectedIndex = -1
            ComboBoxInformedConsent.Enabled = True
        ElseIf CheckBoxInformedConsent.CheckState = CheckState.Unchecked Then
            ComboBoxInformedConsent.SelectedIndex = -1
            ComboBoxInformedConsent.Enabled = False
        End If
    End Sub

    Private Sub RadioButtonOpsiPersentaseOrNominal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonOpsiPersentase.CheckedChanged, RadioButtonOpsiNominal.CheckedChanged
        If RadioButtonOpsiPersentase.Checked = True Then
            TextBoxPersentaseFeePerusahaan.Enabled = True
            TextBoxPersentaseFeeKaryawan.Enabled = True
            TextBoxNominalFee.Enabled = False
            TextBoxNominalFee.Text = "0"
        ElseIf RadioButtonOpsiNominal.Checked = True Then
            TextBoxPersentaseFeePerusahaan.Enabled = False
            TextBoxPersentaseFeeKaryawan.Enabled = False
            TextBoxNominalFee.Enabled = True
            TextBoxPersentaseFeeKaryawan.Text = "0"
            TextBoxPersentaseFeePerusahaan.Text = "0"
        End If
    End Sub

    Private Sub RadioButtonBHP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonBHP.CheckedChanged, RadioButtonNonBHP.CheckedChanged
        If RadioButtonBHP.Checked = True Then
            TextBoxMaksimalBHP_Tindakan.Enabled = True
            TextBoxMaksimalBHP_Tindakan.Text = "0"
        ElseIf RadioButtonNonBHP.Checked = True Then
            TextBoxMaksimalBHP_Tindakan.Enabled = False
            TextBoxMaksimalBHP_Tindakan.Text = "0"
        End If
    End Sub

    Private Sub RadioButtonPaketReguler_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonPaketReguler.CheckedChanged
        ' Tampilkan Label dan TextBox untuk Kuota Paket
        LabelKuotaPaket.Visible = True
        TextBoxKuotaPaket.Visible = True
        TextBoxKuotaPaket.Value = 0

        ' Ambil DataTable dari GridControl
        Dim tblTindakan As DataTable = TryCast(GridControlTindakan.DataSource, DataTable)

        ' Pastikan DataTable tidak kosong
        If tblTindakan IsNot Nothing Then
            ' Nonaktifkan kolom KuotaTindakan di GridView
            GridViewTindakan.Columns("KuotaTindakan").OptionsColumn.AllowEdit = False

            If tblTindakan.Rows.Count > 0 Then
                ' Iterasi semua baris di DataTable
                For Each row As DataRow In tblTindakan.Rows
                    ' Set nilai KuotaTindakan menjadi 1
                    row("KuotaTindakan") = 1
                Next

                ' Refresh GridControl untuk menampilkan perubahan
                GridControlTindakan.RefreshDataSource()
            End If
        End If
    End Sub

    Private Sub RadioButtonPaketPerTindakan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButtonPaketPerTindakan.CheckedChanged
        ' Tampilkan Label dan TextBox untuk Kuota Paket
        LabelKuotaPaket.Visible = False
        TextBoxKuotaPaket.Visible = False
        TextBoxKuotaPaket.Value = 0

        ' Aktifkan Kolom KuotaTindakan
        GridViewTindakan.Columns("KuotaTindakan").OptionsColumn.AllowEdit = True
    End Sub

    Private Sub ButtonExportMasterTindakan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExportMasterTindakan.Click
        Dim queryStringTindakan As String = ""

        If RadioButtonPoliUmum.Checked = True Then
            queryStringTindakan = "SELECT TindakanID, NamaTindakan, JenisTindakan, BiayaTindakan, JenisDokter AS 'Pelaksana', StatusFeeTindakan, FeeDokter, FeePerawat, StatusBHP, MaksimalBHP, PersentaseFeePerusahaan, PersentaseFeeKaryawan, StatusPersentaseFee, StatusNominalFee, FeePerTindakan, StatusFeeKonsultasi, TindakanInformedConsent FROM MasterTindakan WHERE Closed = 0"
        ElseIf RadioButtonPoliGigi.Checked = True Then
            queryStringTindakan = "SELECT TindakanID, NamaTindakan, JenisTindakan, BiayaTindakan, JenisDokter AS 'Pelaksana', StatusFeeTindakan, FeeDokter, FeePerawat, StatusBHP, MaksimalBHP, PersentaseFeePerusahaan, PersentaseFeeKaryawan, StatusPersentaseFee, StatusNominalFee, FeePerTindakan, StatusFeeKonsultasi, TindakanInformedConsent FROM MasterTindakanGigi WHERE Closed = 0"
        End If

        Dim tblTindakan As DataTable = ReadSQL(queryStringTindakan)

        If tblTindakan.Rows.Count > 0 Then
            Dim saveFileDialog1 As New SaveFileDialog
            saveFileDialog1.Filter = "CSV Files|*.csv"
            saveFileDialog1.Title = "Save CSV File"
            If saveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Try
                    Using sw As New System.IO.StreamWriter(saveFileDialog1.FileName, False, System.Text.Encoding.UTF8)
                        ' Tulis header kolom
                        Dim columnNames As List(Of String) = New List(Of String)
                        For Each col As DataColumn In tblTindakan.Columns
                            columnNames.Add("""" & col.ColumnName & """")
                        Next
                        sw.WriteLine(String.Join(",", columnNames.ToArray()))

                        ' Tulis data baris
                        For Each row As DataRow In tblTindakan.Rows
                            Dim fields As New List(Of String)
                            For Each col As DataColumn In tblTindakan.Columns
                                fields.Add("""" & row(col).ToString().Replace("""", """""") & """")
                            Next
                            sw.WriteLine(String.Join(",", fields.ToArray()))
                        Next
                    End Using
                    MsgBox("CSV berhasil disimpan.", MsgBoxStyle.Information)
                Catch ex As Exception
                    MsgBox("Gagal menyimpan file: " & ex.Message, MsgBoxStyle.Critical)
                End Try
            End If
        Else
            MsgBox("Tidak ada data untuk diekspor.", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub ButtonSimpanMasterTindakan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSimpanMasterTindakan.Click
        Try
            If ValidasiTindakan() = True Then
                SimpanDataTindakan()
                ClearDataMenuTindakan()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Warning!")
        End Try
    End Sub

    Private Sub ButtonClearMasterTindakan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClearMasterTindakan.Click
        ClearDataMenuTindakan()
    End Sub

    Private Sub ButtonSimpanMasterPaket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSimpanMasterPaket.Click
        Try
            If ValidasiDetailPaket() = True Then
                SimpanDataPaket()
                ClearDataMenuPaket()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, "Warning!")
        End Try
    End Sub

    Private Sub ButtonClearMasterPaket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClearMasterPaket.Click
        ClearDataMenuPaket()
    End Sub

    Private Sub ButtonExportMasterPaket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExportMasterPaket.Click
        Dim queryStringPaket As String = ""

        queryStringPaket = "SELECT PaketID, NamaPaket, KeteranganPaket, JenisPaket, HargaNett, Kuota, TanggalMulai, TanggalBerakhir FROM MasterPaketTindakan WHERE DeletedDate IS NULL"

        Dim tblPaket As DataTable = ReadSQL(queryStringPaket)

        If tblPaket.Rows.Count > 0 Then
            Dim saveFileDialog1 As New SaveFileDialog
            saveFileDialog1.Filter = "CSV Files|*.csv"
            saveFileDialog1.Title = "Save CSV File"
            If saveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Try
                    Using sw As New System.IO.StreamWriter(saveFileDialog1.FileName, False, System.Text.Encoding.UTF8)
                        ' Tulis header kolom
                        Dim columnNames As List(Of String) = New List(Of String)
                        For Each col As DataColumn In tblPaket.Columns
                            columnNames.Add("""" & col.ColumnName & """")
                        Next
                        sw.WriteLine(String.Join(",", columnNames.ToArray()))

                        ' Tulis data baris
                        For Each row As DataRow In tblPaket.Rows
                            Dim fields As New List(Of String)
                            For Each col As DataColumn In tblPaket.Columns
                                fields.Add("""" & row(col).ToString().Replace("""", """""") & """")
                            Next
                            sw.WriteLine(String.Join(",", fields.ToArray()))
                        Next
                    End Using
                    MsgBox("CSV berhasil disimpan.", MsgBoxStyle.Information)
                Catch ex As Exception
                    MsgBox("Gagal menyimpan file: " & ex.Message, MsgBoxStyle.Critical)
                End Try
            End If
        Else
            MsgBox("Tidak ada data untuk diekspor.", MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub TextBoxHariReminder_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBoxHariReminder.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub CheckBoxReminder_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxReminder.CheckedChanged
        ' Jika dicentang, TextBoxBulan bisa diisi
        If CheckBoxReminder.Checked Then
            TextBoxHariReminder.ReadOnly = False
        Else
            TextBoxHariReminder.ReadOnly = True
            TextBoxHariReminder.Text = ""
        End If
    End Sub

    Private Sub ButtonImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonImport.Click
        Try
            Dim ofd As New OpenFileDialog()
            ofd.Filter = "CSV Files (*.csv)|*.csv"

            If ofd.ShowDialog() = Windows.Forms.DialogResult.OK Then

                Dim filePath As String = ofd.FileName
                Dim sr As StreamReader = New StreamReader(filePath)
                Dim line As String = ""

                ' Lewati header
                line = sr.ReadLine()

                While sr.EndOfStream = False
                    line = sr.ReadLine()
                    If Trim(line) = "" Then Continue While

                    Dim data() As String = line.Split(","c)

                    ' =============================
                    ' MAPPING CSV
                    ' =============================
                    Dim NamaTindakan As String = data(0).Replace("'", "''")
                    Dim JenisTindakan As String = data(1).Replace("'", "''")
                    Dim BiayaTindakan As Double = CDbl(data(2))
                    Dim JenisDokter As String = data(3).Replace("'", "''")

                    ' BOOLEAN KE INTEGER
                    Dim StatusFee As Integer = CInt(data(4))
                    Dim StatusBHP As Integer = CInt(data(5))
                    Dim StatusPersentase As Integer = CInt(data(6))
                    Dim StatusNominal As Integer = CInt(data(7))

                    Dim PersenFeePerusahaan As Double = CDbl(data(8))
                    Dim PersenFeeKaryawan As Double = CDbl(data(9))
                    Dim NominalFee As Double = CDbl(data(10))

                    Dim FeeDokter As Double = CDbl(data(11))
                    Dim FeePerawat As Double = CDbl(data(12))

                    Dim StatusFeeKonsultasi As Integer = CInt(data(13))
                    Dim MaksBHP As Double = CDbl(data(14))

                    Dim StatusIC As Integer = CInt(data(15))

                    Dim NamaIC As String = data(16).Replace("'", "''")

                    Dim Hari As Integer = CInt(data(17))
                    Dim Reminder As Integer = CInt(data(18))

                    If RadioButtonPoliUmum.Checked = True Then

                        Dim q As String = _
                            "INSERT INTO MasterTindakan (" & _
                            "NamaTindakan, JenisTindakan, BiayaTindakan, JenisDokter, CreatedDate, CreatedBy, " & _
                            "StatusFeeTindakan, StatusBHP, StatusPersentaseFee, StatusNominalFee, " & _
                            "PersentaseFeePerusahaan, PersentaseFeeKaryawan, FeePerTindakan, FeeDokter, FeePerawat, " & _
                            "StatusFeeKonsultasi, MaksimalBHP, StatusInformedConsent, TindakanInformedConsent, Hari, Reminder) " & _
                            "VALUES ('" & NamaTindakan & "', '" & JenisTindakan & "', " & BiayaTindakan & ", '" & JenisDokter & "', " & _
                            "GETDATE(), '" & userInput & "', " & StatusFee & ", " & StatusBHP & ", " & StatusPersentase & ", " & StatusNominal & ", " & _
                            PersenFeePerusahaan & ", " & PersenFeeKaryawan & ", " & NominalFee & ", " & FeeDokter & ", " & FeePerawat & ", " & _
                            StatusFeeKonsultasi & ", " & MaksBHP & ", " & StatusIC & ", '" & NamaIC & "', " & Hari & ", " & Reminder & ")"

                        WriteSQL(q, 4)

                    End If


                    If RadioButtonPoliGigi.Checked = True Then

                        Dim q2 As String = _
                            "INSERT INTO MasterTindakanGigi (" & _
                            "NamaTindakan, JenisTindakan, BiayaTindakan, JenisDokter, CreatedDate, CreatedBy, " & _
                            "StatusFeeTindakan, StatusBHP, StatusPersentaseFee, StatusNominalFee, " & _
                            "PersentaseFeePerusahaan, PersentaseFeeKaryawan, FeePerTindakan, FeeDokter, FeePerawat, " & _
                            "StatusFeeKonsultasi, MaksimalBHP, StatusInformedConsent, TindakanInformedConsent, Hari, Reminder, PoliTujuan) " & _
                            "VALUES ('" & NamaTindakan & "', '" & JenisTindakan & "', " & BiayaTindakan & ", '" & JenisDokter & "', " & _
                            "GETDATE(), '" & userInput & "', " & StatusFee & ", " & StatusBHP & ", " & StatusPersentase & ", " & StatusNominal & ", " & _
                            PersenFeePerusahaan & ", " & PersenFeeKaryawan & ", " & NominalFee & ", " & FeeDokter & ", " & FeePerawat & ", " & _
                            StatusFeeKonsultasi & ", " & MaksBHP & ", " & StatusIC & ", '" & NamaIC & "', " & Hari & ", " & Reminder & ", 'PoliGigi')"

                        WriteSQL(q2, 4)

                    End If

                End While

                sr.Close()

                MsgBox("Import CSV Selesai!", MsgBoxStyle.Information)

            End If

        Catch ex As Exception
            MsgBox("Error Import: " & ex.Message)
        End Try
    End Sub

    Private Sub ButtonTemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTemplate.Click
        Try
            Dim sfd As New SaveFileDialog()
            sfd.Filter = "CSV Files (*.csv)|*.csv"
            sfd.FileName = "TemplateMasterTindakan.csv"

            If sfd.ShowDialog() = Windows.Forms.DialogResult.OK Then

                Dim header As String = _
                    "NamaTindakan,JenisTindakan,BiayaTindakan,JenisDokter,StatusFee,StatusBHP,StatusPersentase,StatusNominal," & _
                    "PersenPerusahaan,PersenKaryawan,NominalFee,FeeDokter,FeePerawat,StatusFeeKonsultasi,MaksimalBHP," & _
                    "StatusInformedConsent,TindakanInformedConsent,Hari,Reminder"

                Dim sw As New StreamWriter(sfd.FileName, False)
                sw.WriteLine(header)
                sw.Close()

                MsgBox("Template CSV berhasil dibuat!", MsgBoxStyle.Information)

            End If

        Catch ex As Exception
            MsgBox("Gagal membuat template: " & ex.Message)
        End Try
    End Sub
End Class