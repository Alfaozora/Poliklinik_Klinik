Imports System.Data.SqlClient
Imports KASLibrary
Imports System.Drawing

Public Class Find
    Private formName As String = "FORM PENCARIAN DATA"

    ' Set Connection
    Private DB_Poliklinik As TLcon
    Private DB_Keuangan2 As TLcon

    Private Sub SetConnectionFromConfig()
        ' Set Parameter Server Online
        Dim serverOnline_IP As String = Utility.GetConfig("ServerOnline_IP")
        Dim serverOnline_UserID As String = Utility.GetConfig("ServerOnline_UserID")
        Dim serverOnline_Password As String = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerOnline_Password"), "albert")

        ' Set DB Poliklinik
        DB_Poliklinik.Tip = serverOnline_IP
        DB_Poliklinik.Tid = serverOnline_UserID
        DB_Poliklinik.Tpass = serverOnline_Password
        DB_Poliklinik.Tdb = Utility.GetConfig("ServerOnlinePoli_DB")

        ' Set DB Keuangan 2 (mitramed_keu2019)
        DB_Keuangan2.Tip = serverOnline_IP
        DB_Keuangan2.Tid = serverOnline_UserID
        DB_Keuangan2.Tpass = serverOnline_Password
        DB_Keuangan2.Tdb = Utility.GetConfig("ServerOnlineKeuangan2_DB")
    End Sub

    Public Structure TLconnect
        Dim Tconnect As MySqlConnection
        Dim Tcommand As MySqlCommand
        Dim Tread As MySqlDataReader
        Dim Tid As String
        Dim Tip As String
        Dim Tdb As String
        Dim Tpass As String
    End Structure

    Private DBFind As New DBSQLConn
    Private DBFind2 As New DBSQLConn
    Public TForm As String
    Private QData As String
    Private QDataorder As String
    Private Kriteria(10) As String
    Private Dbasal As DataTable
    Private Indexrow As Integer = -1
    Private Tconn As TLconnect
    'Dim Ttcon As TLcon

    Function ReadThemysqlfind(ByVal txt As String) As DataTable
        Dim Dttable As New DataTable
        Dim lblconnect As String = ""

        With Tconn
            Try
                lblconnect = "Loading Connect to Cahaya Database ..."
                .Tconnect = New MySqlConnection("datasource=" & Tconn.Tip.ToString & ";username=" & Tconn.Tid.ToString & ";password=" & Tconn.Tpass.ToString & ";database=" & Tconn.Tdb.ToString)
                If .Tconnect.State = ConnectionState.Open Then .Tconnect.Close()
                .Tconnect.Open()
                .Tcommand = New MySqlCommand(txt, .Tconnect)
                .Tread = .Tcommand.ExecuteReader
                Dttable.Load(.Tread)
                .Tconnect.Close()
            Catch ex As Exception
                'MsgBox("Failed Connected to Cahaya Database !!!")
                lblconnect = "Failed Connected !!! " & ex.Message
                MsgBox(ex.Message)
            Finally
                .Tconnect.Dispose()
            End Try
        End With

        Return Dttable
    End Function

    Private Sub SetAwal()
        txket.ResetText()
        cmbcols.ResetText()
        cmbkriteria.ResetText()
        cmbkriteria.Text = cmbkriteria.Items(0).ToString
        Me.CenterToScreen()

        Tconn.Tid = "cahayadiagnostic"
        Tconn.Tip = Utility.GetConfig("Server")
        Tconn.Tdb = Utility.GetConfig("Database")
        Tconn.Tpass = Strings.Replace(Utility.GetConfig("Tpass"), "|", "")

    End Sub

    Private Sub FindQuery()

        If txket.Text <> "" And cmbcols.Text <> "" Then
            Dim Kriteria As String = Strings.Replace(Strings.Replace(txket.Text, "'", "''", , ), "*", "**")
            Try
                Dim Tbls As DataTable
                If cmbkriteria.Text.Trim.ToUpper = "LIKE" Then
                    Dim Rws() As DataRow = Dbasal.Select("[" & cmbcols.Text & "] like '*" & Kriteria & "*'")
                    Tbls = Dbasal.Clone
                    For Each rows In Rws
                        Tbls.ImportRow(rows)
                    Next
                ElseIf cmbkriteria.Text.Trim.ToUpper = ">=" Then
                    Tbls = Dbasal.Clone
                    Dim Rws() As DataRow = Dbasal.Select("[" & cmbcols.Text & "] >= " & Kriteria & " and [" & cmbcols.Text & "] <= " & Kriteria + 1000)
                    For Each rows In Rws
                        Tbls.ImportRow(rows)
                    Next
                ElseIf cmbkriteria.Text.Trim.ToUpper = "=" Then
                    Tbls = Dbasal.Clone
                    Dim Rws() As DataRow = Dbasal.Select("[" & cmbcols.Text & "] = " & Kriteria)
                    For Each rows In Rws
                        Tbls.ImportRow(rows)
                    Next
                ElseIf cmbkriteria.Text.Trim.ToUpper = "<=" Then
                    Tbls = Dbasal.Clone
                    Dim Rws() As DataRow = Dbasal.Select("[" & cmbcols.Text & "] <= " & Kriteria & " and [" & cmbcols.Text & "] >= " & Kriteria - 1000)
                    For Each rows In Rws
                        Tbls.ImportRow(rows)
                    Next
                ElseIf cmbkriteria.Text.Trim.ToUpper = "<>" Then
                    Tbls = Dbasal.Clone
                    Dim Rws() As DataRow = Dbasal.Select("[" & cmbcols.Text & "] <> " & Kriteria)
                    For Each rows In Rws
                        Tbls.ImportRow(rows)
                    Next
                Else
                    Dim Rws() As DataRow = Dbasal.Select("[" & cmbcols.Text & "] like '*" & Kriteria & "*'")
                    Tbls = Dbasal.Clone
                    For Each rows In Rws
                        Tbls.ImportRow(rows)
                    Next
                End If

                GridControlListData.DataSource = Tbls
                If GridViewListData.RowCount > 0 Then
                    GridViewListData.SelectRow(0)
                    'Indexrow = 0
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                txket.ResetText()
            End Try

        Else
            GridControlListData.DataSource = Dbasal
            If GridViewListData.RowCount > 0 Then
                GridViewListData.SelectRow(0)
                'Indexrow = 0
            End If
        End If

    End Sub

    Public Sub Query(ByRef Qtext As String, ByRef Qorder As String, ByRef Form As String, ByRef Urutan As Integer)
        Me.BringToFront()
        Dbasal = New DataTable
        TForm = Form
        QData = Qtext
        QDataorder = Qorder

        Dbasal = Test.ReadSQL(QData & QDataorder)
        GridControlListData.DataSource = Dbasal
        'GridViewListData.BestFitColumns()

        Dim Tview As DataTable = GridControlListData.DataSource

        If GridViewListData.RowCount > 0 Then GridViewListData.SelectRow(0)

        cmbcols.Items.Clear()
        For Each column As DataColumn In Dbasal.Columns
            cmbcols.Items.Add(column.ColumnName)
        Next

        cmbcols.Text = cmbcols.Items(Urutan).ToString
        txket.Focus()
        'griddata.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    End Sub

    Public Sub QueryTheAPI(ByRef dt As DataTable, ByRef Form As String, ByRef Urutan As Integer)
        Me.BringToFront()
        Dbasal = dt
        TForm = Form

        GridControlListData.DataSource = Dbasal

        If GridViewListData.RowCount > 0 Then GridViewListData.SelectRow(0)

        cmbcols.Items.Clear()
        For Each column As DataColumn In Dbasal.Columns
            cmbcols.Items.Add(column.ColumnName)
        Next

        If cmbcols.Items.Count > 0 Then
            cmbcols.Text = cmbcols.Items(Urutan).ToString
        End If

        txket.Focus()
    End Sub

    Public Sub QueryTheMysql(ByRef Qtext As String, ByRef Qorder As String, ByRef Form As String, ByRef Urutan As Integer)
        Me.BringToFront()
        Dbasal = New DataTable
        TForm = Form
        QData = Qtext
        QDataorder = Qorder

        Dbasal = ReadThemysqlfind(QData & QDataorder)
        GridControlListData.DataSource = Dbasal

        Dim Tview As DataTable = GridControlListData.DataSource
        If GridViewListData.RowCount > 0 Then GridViewListData.SelectRow(0)

        cmbcols.Items.Clear()
        For Each column As DataColumn In Dbasal.Columns
            cmbcols.Items.Add(column.ColumnName)
        Next

        cmbcols.Text = cmbcols.Items(Urutan).ToString
        txket.Focus()
    End Sub

    Public Sub QueryTheMysql(ByRef Qtext As String, ByRef Qorder As String, ByRef Form As String, ByRef Urutan As Integer, ByRef Ttcmh As TLconnect)
        Me.BringToFront()
        Dbasal = New DataTable
        TForm = Form
        QData = Qtext
        QDataorder = Qorder

        Dim lblconnect As String = ""
        With Tconn
            Try
                lblconnect = "Loading Connect to Cahaya Database ..."
                .Tconnect = New MySqlConnection("datasource=" & Ttcmh.Tip.ToString & ";username=" & Ttcmh.Tid.ToString & ";password=" & Ttcmh.Tpass.ToString & ";database=" & Ttcmh.Tdb.ToString)
                If .Tconnect.State = ConnectionState.Open Then .Tconnect.Close()
                .Tconnect.Open()
                .Tcommand = New MySqlCommand(QData & QDataorder, .Tconnect)
                .Tread = .Tcommand.ExecuteReader
                Dbasal.Load(.Tread)
                .Tconnect.Close()
            Catch ex As Exception
                'MsgBox("Failed Connected to Cahaya Database !!!")
                lblconnect = "Failed Connected !!! " & ex.Message
                MsgBox(ex.Message)
            Finally
                .Tconnect.Dispose()
            End Try
        End With

        GridControlListData.DataSource = Dbasal

        Dim Tview As DataTable = GridControlListData.DataSource
        If GridViewListData.RowCount > 0 Then GridViewListData.SelectRow(0)

        cmbcols.Items.Clear()
        For Each column As DataColumn In Dbasal.Columns
            cmbcols.Items.Add(column.ColumnName)
        Next

        cmbcols.Text = cmbcols.Items(Urutan).ToString
        txket.Focus()
    End Sub

    Public Sub QueryMysql(ByRef Qtext As String, ByRef Qorder As String, ByRef Form As String, ByRef Urutan As Integer)
        Me.BringToFront()
        Dbasal = New DataTable
        TForm = Form
        QData = Qtext
        QDataorder = Qorder

        Dbasal = PoliKlinik.dbsql.Select(QData & QDataorder)
        GridControlListData.DataSource = Dbasal

        Dim Tview As DataTable = GridControlListData.DataSource
        If GridViewListData.RowCount > 0 Then GridViewListData.SelectRow(0)

        cmbcols.Items.Clear()
        For Each column As DataColumn In Dbasal.Columns
            cmbcols.Items.Add(column.ColumnName)
        Next

        cmbcols.Text = cmbcols.Items(Urutan).ToString
        txket.Focus()
    End Sub


    Private Sub Find_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetAwal()
    End Sub

    Private Sub SetConnection(ByRef connection As String)
        Try
            DBFind.Con = New SqlConnection(connection)
            DBFind.Con.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub LoadData(ByRef Baris As Integer)

        If GridViewListData.RowCount > 0 Then
            Dim Grdrow As DataRowView = GridViewListData.GetRow(Baris)

            Select Case TForm
                Case "FindUser"
                    SettingUser.LoadUser(Grdrow(0).ToString)
                Case "FindUserIcare"
                    SettingIcare.LoadUser(Grdrow(0).ToString)
                Case "FindObjektifTindakanGigi"
                    FormRekamMedisDokter.LoadTindakanOdontogram(Grdrow, "Tindakan")
                Case "FindObjektifSimbolGigi"
                    FormRekamMedisDokter.LoadTindakanOdontogram(Grdrow, "Simbol")
                Case "FindCabangSuratRujukan"
                    FormRekamMedisDokter.TextBoxCompany.Text = Grdrow("CompanyNama").ToString
                Case "FindRujukanID"
                    FormCetakUlangRujukan.txnorujukan.Text = Grdrow("NoSuratRujukan").ToString
                Case "FindRefundID"
                    FormCetakUlangRefund.txnorefund.Text = Grdrow("norefund").ToString
                Case "FindMasterTindakanKlinik2"
                    FormMasterTindakanKlinik.LoadTindakanPoli(Grdrow(0).ToString)
                Case "FindMasterTindakanKlinik"
                    MasterTindakanKlinik.LoadTindakanPoli(Grdrow(0).ToString)
                Case "FindDokterFormRekapFeeKaryawan"
                    FormRekapFeeKaryawan.LoadDokterID(Grdrow)
                Case "FindPractitionerRekapFeeKaryawan"
                    RekapFeeKaryawan.LoadPractitioner(Grdrow)
                Case "FindPerawatFormRekapFeeKaryawan"
                    FormRekapFeeKaryawan.LoadPerawatID(Grdrow)
                Case "FindLaporanDokterFormRekapFeeKaryawan"
                    FormRekapFeeKaryawan.LoadLaporanDokterID(Grdrow)
                Case "FindLaporanPerawatFormRekapFeeKaryawan"
                    FormRekapFeeKaryawan.LoadLaporanPerawatID(Grdrow)
                Case "FindMasterTindakanLab"
                    MasterTestLab.LoadTindakan(Grdrow(0).ToString)
                Case "FindMasterHargaRujukan"
                    MasterHargaRujukan.LoadTindakan(Grdrow(0).ToString)
                Case "FindKwitansi"
                    FormCetakInvoice.LoadTindakan(Grdrow)
                Case "FindDetailLabForDetail"
                    MasterTestLabDetail.LoadDetailTindakan(Grdrow(0).ToString)
                Case "FindMasterTindakanForDetail"
                    MasterTestLabDetail.LoadTindakanHeader(Grdrow(0).ToString)
                Case "FindPaketID"
                    MasterGroupTestLab.LoadPaketID(Grdrow(0).ToString)
                Case "FindPaketTindakanKlinik"
                    MasterTindakanKlinik.LoadDetailPaket(Grdrow("PaketID").ToString)
                Case "FindInvoiceLab"
                    FormInvoiceLab.LoadPasien(Grdrow("RekapID").ToString)
                Case "FindRefundLab"
                    FormAccRefund.LoadPasien(Grdrow("RefundID").ToString)
                Case "FindInvoiceKlinik"
                    FormInvoicePoli.LoadPasien(Grdrow("RekapID").ToString)
                Case "FindInvoiceKlinik_ReportPendapatanKlinik"
                    ReportPendapatanKlinik.LoadInvoiceTagihan(Grdrow("No Tagihan").ToString)
                Case "FindPaketIDDaftarPeserta"
                    DaftarPeserta.LoadPaketID(Grdrow(0).ToString)
                Case "FindCustomerLab"
                    TransaksiLab.LoadLabPasien(Grdrow(0).ToString)
                Case "FindPaket"
                    Dim Tbls As DataTable = ReadSQL("select TindakanID,NamaTindakan,JenisTindakan,TindakanNilai as BiayaTindakan,TindakanDiscount as DiscTindakan,TindakanNett as NettBayar from MasterLabPaketDetail where PaketID='" & Grdrow("ID").ToString & "' and TindakanID in (select TindakanID from masterlab where closed=0) order by Urutan")
                    TransaksiLab.LoadTindakanTbls(Tbls)
                Case "FindDoktertindakan"
                    TransaksiLab.TextBoxNamaDokter.Text = Grdrow("DrNama").ToString
                    TransaksiLab.TextBoxDokterID.Text = Grdrow("IdPraktek").ToString
                    ReportFeeDokterPengirim.TextBoxNamaDokter.Text = Grdrow("DrNama").ToString
                    ReportFeeDokterPengirim.TextBoxIdKirim.Text = Grdrow("IdPraktek").ToString
                Case "FindTransLab"
                    TransaksiLab.LoadTransaksiLab(Grdrow("ID").ToString, Grdrow("No. Lab").ToString)
                Case "FindInputLab"
                    LabAdmin.LoadAdminLab(Grdrow("TransLabID").ToString, Grdrow("NoUrut").ToString, "notempty")
                    LabAdmin.txalamat.Text = Grdrow("DomisiliAlamat").ToString
                Case "FindInputResendMesin"
                    SendUlangToMesin.LoadSendUlangToMesin(Grdrow("TransLabID").ToString, Grdrow("NoUrut").ToString)
                Case "FindTindakanResendMesin"
                    SendUlangToMesin.txtindakanket.Text = Grdrow("NamaTindakan").ToString
                    SendUlangToMesin.txtindakanid.Text = Grdrow("TindakanID").ToString
                Case "FindFormTransaksiPoli"
                    FormTransaksiPoli.LoadFormTransaksiPoli(Grdrow("ID").ToString, Grdrow("JenisPoli").ToString)
                Case "DisplayCabang"
                    CetakKartu.buttindakanid.Text = Grdrow(0).ToString
                Case "FindTindakanRiwayatLaboratorium"
                    FormRekamMedisDokter.LoadTindakanRiwayatLaboratorium(Grdrow)
                Case "FindTindakanPoliPerencanaan"
                    FormRekamMedisDokter.LoadTindakanPoli(Grdrow)
                Case "FindPenjaminTindakanRekamMedis"
                    FormRekamMedisDokter.LabelPenjaminAsuransiLain.Text = Grdrow("CompanyNama").ToString
                Case "FindMasterDokter"
                    FormMasterDokter.LoadDataDokter(Grdrow("ID").ToString)
                Case "FindTransaksiBarcode"
                    FormCetakBarcode.LoadTransLab(Grdrow)
                Case "FindDokterkirim"
                    DokterPengirimLab.LoadDokter(Grdrow(0).ToString)
                Case "FindPaketanKartu"
                    MasterPaket.LoadPaket(Grdrow(0).ToString)
                Case "FindConfig"
                    Msconfig.LoadData(Grdrow)
                Case "Findform"
                    FormMenu.LoadForm(Grdrow)
                Case "Findgigi"
                    FormMasterTindakanKlinik.LoadTindakan(Grdrow("TindakanID").ToString)
                Case "FindCompanyTagihanPembayaran"
                    FormPembayaran.LoadCompany(Grdrow(0).ToString)
                Case "CompanyIDFind"
                    MasterCompany.LoadMasterComp(Grdrow("nocompany").ToString)
                Case "FindReferensiPerusahaan"
                    TransaksiLab.LoadReferensiPerusahaan(Grdrow("companynama").ToString, Grdrow("nocompany").ToString)
                Case "LabRujukanIDFind"
                    masterlaboratoriumrujukan.LoadMasterComp(Grdrow)
                Case "FindCompTagihan"
                    FormAwalPembayaranTagihan.txcompanycode.Text = Grdrow("CompJenis").ToString
                    FormAwalPembayaranTagihan.butdisplay.PerformClick()
                Case "FindCompTagihanAwal"
                    FormDetailTagihan.txcompanycode.Text = Grdrow("CompJenis").ToString
                Case "FindCabangTunai"
                    FormVerifikasiOmsetTunai.LoadFormApprovePembayaranTunai(Grdrow("kode_klinik").ToString, Grdrow("nama_klinik").ToString, Grdrow("db_jurnal").ToString, Grdrow("jenis_jurnal").ToString)
                Case "FindBankApproveOmset"
                    FormVerifikasiOmsetTunai.TextBoxCoaBank.Text = Grdrow("CoaBank").ToString
                    FormVerifikasiOmsetTunai.TextBoxNamaBank.Text = Grdrow("NamaBank").ToString & " (" & Grdrow("NomorRekening").ToString & ")"
                Case "FindBankTagihanFormVerifikasiOmsetTagihan"
                    FormVerifikasiOmsetTagihan.TextBoxBankTransferCoa.Text = Grdrow("CoaBank").ToString
                    FormVerifikasiOmsetTagihan.TextBoxBankTransferKeterangan.Text = Grdrow("NamaBank").ToString & " (" & Grdrow("NomorRekening").ToString & ")"
                Case "FindInvoiceTagihanFormVerifikasiOmsetTagihan"
                    FormVerifikasiOmsetTagihan.LoadDetailPelunasan(Grdrow("No Tagihan").ToString)
                Case "FindBankTagihanReportPendapatanKlinik"
                    ReportPendapatanKlinik.TextBoxBankTransferCoa.Text = Grdrow("CoaBank").ToString
                    ReportPendapatanKlinik.TextBoxBankTransferKeterangan.Text = Grdrow("NamaBank").ToString & " (" & Grdrow("NomorRekening").ToString & ")"
                Case "FindCabangSendGaji"
                    FormSendGajiHRD.LoadDataCompany(Grdrow)
                Case "FindCabangMasterKapitasi"
                    FormMasterKapitasi.LoadDataCompany(Grdrow)
                Case "FindSupplierTagihanApotek"
                    FormSendTagihanApotek.LoadSupplier(Grdrow("ID Supplier").ToString, Grdrow("Nama Perusahaan").ToString, Grdrow("Jenis").ToString)
                Case "FindSalesOfficePinjaman"
                    FormSendPinjamanKaryawan.LoadSalesOffice(Grdrow("locationcode").ToString, Grdrow("locationket").ToString)
                Case "FindLocationKasKecilPengajuan"
                    FormSendPengajuanDanKasKecil.LoadLocation(Grdrow("locid").ToString, Grdrow("locationket").ToString)
                Case "FindBankKasKecilPengajuan"
                    FormSendPengajuanDanKasKecil.LoadBank(Grdrow("bankid").ToString, Grdrow("Bank").ToString)
                Case "FindCabangTagihan"
                    FormDetailTagihan.txkodecabang.Text = Grdrow("kodeklinik").ToString
                    FormDetailTagihan.txcabangket.Text = Grdrow("locationket").ToString
                Case "FindCabangMonitorProses"
                    MonitorProcessOnline.txkodecabang.Text = Grdrow("kodecabang").ToString
                    MonitorProcessOnline.txcompanycode.Text = Grdrow("kodeket").ToString
                Case "FindCabangSummary"
                    ReportSummaryMCU.LoadCompany(Grdrow("nocompany").ToString, Grdrow("companynama").ToString)
                Case "FindCabangReportRujukan"
                    FormReportRujukan.txkodecabang.Text = Grdrow("NoLabRujukan").ToString
                    FormReportRujukan.txcompanycode.Text = Grdrow("NamaLabRujukan").ToString
                Case "FindTindakanReportRujukan"
                    FormReportRujukan.txtindakanid.Text = Grdrow("TindakanID").ToString
                    FormReportRujukan.txtindakanket.Text = Grdrow("NamaTindakan").ToString
                Case "FindTindakanCreateRujukan"
                    FormCreateRujukan.txtindakanid.Text = Grdrow("TindakanID").ToString
                    FormCreateRujukan.txtindakanket.Text = Grdrow("NamaTindakan").ToString
                Case "FindCabangRekapTagihanLab"
                    RekapTagihanLab.txkodecabang.Text = Grdrow("nocompany").ToString
                    RekapTagihanLab.txcompanycode.Text = Grdrow("companynama").ToString
                Case "FindCompanyUploadThorax"
                    UploadTindakanThorax.txkodecabang.Text = Grdrow("nocompany").ToString
                    UploadTindakanThorax.txcompanycode.Text = Grdrow("companynama").ToString
                Case "FindCompanyUploadLab"
                    UploadTindakanLaboratorium.txkodecabang.Text = Grdrow("nocompany").ToString
                    UploadTindakanLaboratorium.txcompanycode.Text = Grdrow("companynama").ToString
                Case "FindCompanyMonitoringMCU"
                    MonitoringMCU.txkodecabang.Text = Grdrow("nocompany").ToString
                    MonitoringMCU.txcompanycode.Text = Grdrow("companynama").ToString
                Case "FindCompanyExportReportLaboratorium"
                    ExportReportLaboratorium.txkodecabang.Text = Grdrow("nocompany").ToString
                    ExportReportLaboratorium.txcompanycode.Text = Grdrow("companynama").ToString
                Case "FindCabangCetakBarcode"
                    FormCetakBarcode.txkodecabang.Text = Grdrow("nocompany").ToString
                    FormCetakBarcode.txcompanycode.Text = Grdrow("companynama").ToString
                Case "FindCabangRekapPendapatanPoli"
                    RekapPendapatanPoli.txkodecabang.Text = Grdrow("nocompany").ToString
                    RekapPendapatanPoli.TextBoxKeteranganPerusahaan.Text = Grdrow("companynama").ToString
                Case "FindPerusahaanReportPendapatanKlinik_LaporanPendapatan"
                    ReportPendapatanKlinik.TextBoxNamaPerusahaanLaporanPendapatan.Text = Grdrow("Keterangan").ToString & "-" & Grdrow("ID").ToString
                Case "FindPerusahaanReportPendapatanKlinik_RekapInvoice"
                    ReportPendapatanKlinik.TextBoxNamaPerusahaanRekapInvoice.Text = Grdrow("Keterangan").ToString & "-" & Grdrow("ID").ToString
                Case "FindPerusahaanReportPendapatanKlinik_RekapTagihan"
                    ReportPendapatanKlinik.TextBoxNamaPerusahaanRekapTagihan.Text = Grdrow("Keterangan").ToString & "-" & Grdrow("ID").ToString
                Case "FindCabangReportTagihanLab"
                    ReportTagihanLab.txkodecabang.Text = Grdrow("nocompany").ToString
                    ReportTagihanLab.txcompanycode.Text = Grdrow("companynama").ToString
                Case "FindCabangReportTagihanPoli"
                    ReportTagihanPoli.TextBoxNamaPerusahaan.Text = Grdrow("Keterangan").ToString & "-" & Grdrow("ID").ToString
                Case "FindLabCreateRujukan"
                    FormCreateRujukan.txlabrujukanid.Text = Grdrow("NoLabRujukan").ToString
                    FormCreateRujukan.txlabrujukanket.Text = Grdrow("NamaLabRujukan").ToString

                    If Grdrow("Upload").ToString = "Yes" Then
                        FormCreateRujukan.CheckBoxUpload.Checked = True
                    ElseIf Grdrow("Upload").ToString = "No" Then
                        FormCreateRujukan.CheckBoxUpload.Checked = False
                    End If
                Case "FindLabMasterHargaRujukan"
                    MasterHargaRujukan.txlabrujukanid.Text = Grdrow("NoLabRujukan").ToString
                    MasterHargaRujukan.txlabrujukanket.Text = Grdrow("NamaLabRujukan").ToString
                    MasterHargaRujukan.LoadTindakanRujukan(Grdrow("NoLabRujukan").ToString)
                Case "FindCabangAccKapitasi"
                    FormVerifikasiOmsetKapitasi.SetLokasi(Grdrow("kodecabang").ToString, Grdrow("kodeket").ToString, Grdrow("db_gl").ToString)
                    'FormApproveKapitasi.txlocid.Text = Grdrow("kodecabang").ToString
                    'FormApproveKapitasi.txlocket.Text = Grdrow("kodeket").ToString
                Case "FindCabangPendapatanTagihan"
                    ReportPendapatanTagihan.txlocid.Text = Grdrow("kodecabang").ToString
                    ReportPendapatanTagihan.txlocket.Text = Grdrow("kodeket").ToString
                Case "FindCabangFormInvoiceLab"
                    FormInvoiceLab.txkodecabang.Text = Grdrow("nocompany").ToString
                    FormInvoiceLab.txcompanycode.Text = Grdrow("companynama").ToString
                Case "FindCabangFormInvoiceKlinik"
                    FormInvoicePoli.txkodecabang.Text = Grdrow("nocompany").ToString
                    FormInvoicePoli.txcompanycode.Text = Grdrow("companynama").ToString
                Case "FindCabangSendUlangMesin"
                    SendUlangToMesin.TextBoxKeteranganLokasi.Text = Grdrow("kodeket").ToString
                    SendUlangToMesin.TextBoxKodeLokasi.Text = Grdrow("kodecabang").ToString
                Case "FindCabangSummaryOnline"
                    If ReportSummaryMCUOnline.cmbjenisfilter.SelectedIndex = 0 Then
                        ReportSummaryMCUOnline.LoadCompany(Grdrow("nocompany").ToString, Grdrow("companynama").ToString)
                    ElseIf ReportSummaryMCUOnline.cmbjenisfilter.SelectedIndex = 1 Then
                        ReportSummaryMCUOnline.LoadCompany(Grdrow("kodecabang").ToString, Grdrow("kodeket").ToString)
                    End If
                Case "FindCabangLapTunai"
                    ReportPendapatanTunai.LoadLapPendapatanTunai(Grdrow("kodeklinik").ToString, Grdrow("locationket").ToString)
                Case "FindCabangUploadThorax"
                    UploadTindakanThorax.txloc.Text = Grdrow("Keterangan Lokasi").ToString
                    UploadTindakanThorax.txidloc.Text = Grdrow("Lokasi ID").ToString
                Case "FindCabangUploadMonitoringMCU"
                    MonitoringMCU.txloc.Text = Grdrow("Keterangan Lokasi").ToString
                    MonitoringMCU.txidloc.Text = Grdrow("Lokasi ID").ToString
                Case "FindCabangUploadExportReportLaboratorium"
                    ExportReportLaboratorium.txloc.Text = Grdrow("Keterangan Lokasi").ToString
                    ExportReportLaboratorium.txidloc.Text = Grdrow("Lokasi ID").ToString
                Case "FindCabangUploadLab"
                    UploadTindakanLaboratorium.txloc.Text = Grdrow("Keterangan Lokasi").ToString
                    UploadTindakanLaboratorium.txidloc.Text = Grdrow("Lokasi ID").ToString
                Case "FindCabangLapTagihan"
                    ReportPendapatanTagihan.LoadLapPendapatanTagihan(Grdrow("CompJenis").ToString)
                Case "FindCabangClosingBankTagihan"
                    ReportClosingBankTagihan.LoadLapPendapatanTagihan(Grdrow("CompJenis").ToString)
                Case "FindBankClosingBankTagihan"
                    ReportClosingBankTagihan.LoadBank(Grdrow("COA Bank").ToString, Grdrow("Keterangan Bank").ToString)
                Case "Findrekappelunasan"
                    FormAwalPembayaranTagihan.LoadRekapTagihan(Grdrow("RekapID").ToString)
                Case "useronline"
                    UserONLINE.LoadData(Grdrow)
                Case "useronlinedelete"
                    UserONLINE.DeleteUser(Grdrow)
                Case "MasterJenisTindakan"
                    MasterJenisTindakan.txjenisid.Text = Grdrow("JenisID").ToString
                    MasterJenisTindakan.txjenistindakan.Text = Grdrow("JenisTindakan").ToString
                Case "FindUrutanJenisTindakan"
                    MasterUrutan.txjenisid.Text = Grdrow("JenisID").ToString
                    MasterUrutan.butjenis.Text = Grdrow("JenisTindakan").ToString
                    MasterUrutan.SetDetailJenis()
                Case "FindObatTestLab"
                    MasterTestLab.LoadObatID(Grdrow("ObatID").ToString)
                Case "FindTransaksiIDLab"
                    LabAdminOnline.LoadAdminLab(Grdrow("idlabinternet").ToString, Grdrow("nourut").ToString)
                Case "FindCOAadd"
                    FormVerifikasiOmsetTagihan.LoadCOAdetail(Grdrow)
                Case "FindMasterTindakanKlinikReservasi"
                    FormReservasi.LoadTindakanPoli(Grdrow(0).ToString)
                Case "FindMasterDokterReservasi"
                    FormReservasi.LoadDokter(Grdrow("ID").ToString)
                Case "FindMasterSesi"
                    FormReservasi.LoadReservasi(Grdrow("RuanganID").ToString)
                Case Else : MsgBox("Error...")
            End Select
            Me.Close()
        End If
    End Sub

    Private Sub txket_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txket.TextChanged
        FindQuery()
    End Sub

    Private Sub GridControl1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridControlListData.DoubleClick
        If GridViewListData.FocusedRowHandle >= 0 Then
            Dim Index() As Integer = GridViewListData.GetSelectedRows
            If Index.Length > 0 Then
                LoadData(Index(0))
            End If
        End If
    End Sub

    Private Sub ButtonTambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSave.Click
        Dim Index() As Integer = GridViewListData.GetSelectedRows
        If Index.Length > 0 Then
            LoadData(Index(0))
        End If
    End Sub

    Private Sub ButtonCari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCari.Click
        FindQuery()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub PanelTop_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelTop.Paint
        Try
            e.Graphics.DrawString(formName, New Font("Arial", 12, FontStyle.Bold), Brushes.White, New Point(10, 10))
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub
End Class