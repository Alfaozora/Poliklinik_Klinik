Public Class AccPenerimaan
    ' Set Connection
    Private DB_Keuangan As TLcon

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
    End Sub

    Function CreateTable() As DataTable
        Dim Thasil As New DataTable

        insertRowToTbls(Thasil, "tyinterger", "ID")
        insertRowToTbls(Thasil, "Typstring", "Lokasi")
        insertRowToTbls(Thasil, "Typstring", "JenisTrans")
        insertRowToTbls(Thasil, "Typstring", "NoTransaksi")
        insertRowToTbls(Thasil, "Typstring", "IDPasien")
        insertRowToTbls(Thasil, "Typstring", "Pasien")
        insertRowToTbls(Thasil, "Typstring", "JenisBayar")
        insertRowToTbls(Thasil, "Typstring", "Kartu")
        insertRowToTbls(Thasil, "Typstring", "Mesin")
        insertRowToTbls(Thasil, "Typstring", "NilaiUang")
        insertRowToTbls(Thasil, "Typstring", "TglClosed")
        insertRowToTbls(Thasil, "Typstring", "Status")
        insertRowToTbls(Thasil, "typchecked", "Closed")



        For Each Tcol As DataColumn In Thasil.Columns
            Tcol.ReadOnly = True
        Next

        Thasil.Columns("Closed").ReadOnly = False


        Return Thasil
    End Function

    Private Sub SetClear()
        dtprocess.Enabled = True
        butsaved.Enabled = True
        butdisplay.Enabled = True

        ' Inisialisasi koneksi ke database MySQL
        SetConnectionFromConfig()

        gridpoli.DataSource = CreateTable()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butdisplay.Click
        Dim Tbls As DataTable = ReadThemysql("select * from acctranspendapatandetail where inctgl='" & Format(dtprocess.Value, "yyyyMMdd") & "'", DB_Keuangan)
        Dim Tdata As DataTable = gridpoli.DataSource
        GridView1.Columns("Closed").Width = 50

        Tdata.Rows.Clear()

        If Tbls.Rows.Count > 0 Then
            For Each Trow As DataRow In Tbls.Rows
                Dim Tnew As DataRow = Tdata.NewRow
                Tnew("ID") = Trow("incdetailid")
                Tnew("Lokasi") = Trow("loc")
                Tnew("JenisTrans") = Trow("incjenis")
                Tnew("NoTransaksi") = Trow("inctransid")
                Tnew("IDPasien") = Trow("idinternet")
                Tnew("Pasien") = Trow("Pasien")
                Tnew("JenisBayar") = Trow("jenis")
                Tnew("Kartu") = Trow("kartu")
                Tnew("Mesin") = Trow("mesin")
                Tnew("NilaiUang") = Splitmoney(Trow("incnilai"))
                If Trow("lockeddate") <> DateSerial("9998", "12", "31") Then
                    Tnew("Status") = "LOCKED"
                    Tnew("Closed") = True
                    Tnew("TglClosed") = Format(Trow("lockeddate"), "dd-MMM-yyyy HH:mm")
                Else
                    Tnew("Status") = ""
                    Tnew("Closed") = False
                    Tnew("TglClosed") = ""
                End If
                Tdata.Rows.Add(Tnew)
            Next

            For Each Tcol As DataColumn In Tdata.Columns
                Tcol.ReadOnly = True
            Next
            Tdata.Columns("Closed").ReadOnly = False
            gridpoli.DataSource = Tdata
        Else
            MsgBox("Detail Penerimaan belum terkirim. Minta dikirim ulang dari lokal")
        End If
    End Sub

    Private Sub AccPenerimaan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        SetClear()
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub butsaved_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butsaved.Click
        If MsgBox("Yakin menyimpan data tersebut ?", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
            Dim Tbls As DataTable = gridpoli.DataSource
            Tbls.AcceptChanges()

            Dim Temp() As DataRow = Tbls.Select("[Closed]=True AND [Status]<>'LOCKED'")
            For i As Integer = 0 To Temp.Length - 1 Step 1
                If CheckThemysql("select * from acctranspendapatandetail where incdetailid='" & Temp(i)("ID").ToString & "' and inctgl='" & Format(dtprocess.Value, "yyyyMMdd") & "' and loc='" & Temp(i)("Lokasi").ToString & "' and incjenis='" & Temp(i)("JenisTrans").ToString & "' and incnilai='" & CInt(Temp(i)("NilaiUang")) & "' and lockeddate=99981231", DB_Keuangan) = True Then
                    WriteThemysql("update acctranspendapatandetail set lockeddate=now() , lockedby='" & PoliKlinik.Lbluser.Text & "' where incdetailid='" & Temp(i)("ID").ToString & "'", DB_Keuangan)
                End If
            Next
            MsgBox("Data Update")
        Else
            MsgBox("Canceled Saved")
        End If
    End Sub

    Private Sub butclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butclear.Click

    End Sub
End Class