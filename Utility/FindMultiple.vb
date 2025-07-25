Imports System.Data.SqlClient
Imports KASLibrary
Imports System.Drawing

Public Class FindMultiple
    Private formName As String = "PENCARIAN MULTIPLE"

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
    Private TForm As String
    Private QData As String
    Private QDataorder As String
    Private Kriteria(10) As String
    Private Dbasal As DataTable
    Private Indexrow As Integer = -1
    Private Tconn As TLconnect
    'Dim Ttcon As TLcon

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

        insertRowToTbls(Dbasal, "typchecked", "Pilihan")

        For Each Tcol As DataColumn In Dbasal.Columns
            Tcol.ReadOnly = True
        Next
        Dbasal.Columns("Pilihan").ReadOnly = False
        GridControl1.DataSource = Dbasal
    End Sub

    Public Sub Query(ByRef Qtext As String, ByRef Qorder As String, ByRef Form As String, ByRef Urutan As Integer)
        Me.BringToFront()
        Dbasal = New DataTable
        TForm = Form
        QData = Qtext
        QDataorder = Qorder

        Dbasal = Test.ReadSQL(QData & QDataorder)
        insertRowToTbls(Dbasal, "typchecked", "Pilihan")

        For Each Tcol As DataColumn In Dbasal.Columns
            Tcol.ReadOnly = True
        Next
        Dbasal.Columns("Pilihan").ReadOnly = False
        GridControl1.DataSource = Dbasal
    End Sub

    Private Sub Find_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetAwal()
    End Sub

    Private Sub SetAwal()
        ' Inisialisasi koneksi ke database MySQL
        SetConnectionFromConfig()

        ' Set Layar ke Tengah
        Me.CenterToScreen()
    End Sub

    'Public Sub QueryOL(ByRef Qtext As String, ByRef Qorder As String, ByRef Form As String, ByRef Urutan As Integer)
    '    Me.BringToFront()
    '    Dbasal = New DataTable
    '    TForm = Form
    '    QData = Qtext
    '    QDataorder = Qorder

    '    Dbasal = ReadThemysql(QData & QDataorder, DB_Poliklinik)
    '    insertRowToTbls(Dbasal, "typchecked", "Pilihan")

    '    For Each Tcol As DataColumn In Dbasal.Columns
    '        Tcol.ReadOnly = True
    '    Next
    '    Dbasal.Columns("Pilihan").ReadOnly = False
    '    GridControl1.DataSource = Dbasal
    'End Sub

    Private Sub SetConnection(ByRef connection As String)
        Try
            DBFind.Con = New SqlConnection(connection)
            DBFind.Con.Open()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub cbAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbAll.CheckedChanged
        Dim Tbls As DataTable = GridControl1.DataSource

        If Tbls.Rows.Count > 0 Then
            For Each Trow As DataRow In Tbls.Rows
                If cbAll.CheckState = CheckState.Checked Then
                    Trow("Pilihan") = True
                Else
                    Trow("Pilihan") = False
                End If
            Next
        End If
    End Sub

    Private Sub PanelTop_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelTop.Paint
        Try
            e.Graphics.DrawString(formName, New Font("Arial", 12, FontStyle.Bold), Brushes.White, New Point(10, 10))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub ButtonTambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTambah.Click
        Dim Ttable As DataTable = GridControl1.DataSource
        Dim Trow() As DataRow = Ttable.Select("[Pilihan]=1")

        Me.Close()
        Select Case TForm
            Case "SelectPasienRefund"
                FormCreateRefund.LoadPasien(Trow)
            Case "CreateRujukan"
                FormCreateRujukan.LoadPasien(Trow)
            Case "FindPaketDetail"
                MasterGroupTestLab.AddTindakanDetail(Trow)
            Case "FindPaketKlinikDetail"
                MasterTindakanKlinik.AddTindakanDetail(Trow)
            Case "FindTindakan"
                TransaksiLab.LoadTindakan(Trow)
            Case "FindTindakanLabPerencanaan"
                FormRekamMedisDokter.LoadTindakanLab(Trow)
            Case "FindTindakanFormTransaksiPoli"
                FormTransaksiPoli.LoadTindakan(Trow)
            Case "FindPemeriksaanPendaftaran"
                FormPendaftaranAwal.LoadTindakan(Trow)
            Case "FindPemeriksaanPendaftaranPaket"
                FormPendaftaranAwal.LoadTindakanPaket(Trow)
            Case "ReportMCU"
                ReportSummaryMCU.LoadPasien(Trow)
            Case "RekapTagihanLab"
                RekapTagihanLab.LoadPasien(Trow)
            Case "CetakBarcodeSelectedAll"
                FormCetakBarcode.LoadPasien(Trow)
            Case "RekapPendapatanPoli"
                RekapPendapatanPoli.LoadPasien(Trow)
            Case "SelectDetailTagihanApotek"
                FormSendTagihanApotek.LoadPasien(Trow)
            Case "ReportMCUOnline"
                ReportSummaryMCUOnline.LoadPasien(Trow)
            Case "FindInputRepair"
                RepairDetailTindakan.AddPasien(Trow)
            Case "OFFUSER"
                SettingUser.OFFUSER(Trow)
            Case "ONUSER"
                SettingUser.ONUSER(Trow)
            Case Else : MsgBox("Error...")

        End Select
    End Sub
End Class