Public Class FormDetailTagihan
    ' Set Connection
    Private Find_Keuangan As Find.TLconnect
    Private DB_Keuangan As TLcon

    Private Sub SetConnectionFromConfig()
        ' Set Parameter Server Online
        Dim serverOnline_IP As String = Utility.GetConfig("ServerOnline_IP")
        Dim serverOnline_UserID As String = Utility.GetConfig("ServerOnline_UserID")
        Dim serverOnline_Password As String = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerOnline_Password"), "albert")

        ' Set Find Keuangan 1 (mitramed_keu)
        Find_Keuangan.Tip = serverOnline_IP
        Find_Keuangan.Tid = serverOnline_UserID
        Find_Keuangan.Tpass = serverOnline_Password
        Find_Keuangan.Tdb = Utility.GetConfig("ServerOnlineKeuangan_DB")

        ' Set DB Keuangan 1 (mitramed_keu)
        DB_Keuangan.Tip = serverOnline_IP
        DB_Keuangan.Tid = serverOnline_UserID
        DB_Keuangan.Tpass = serverOnline_Password
        DB_Keuangan.Tdb = Utility.GetConfig("ServerOnlineKeuangan_DB")
    End Sub

    Function CreateTable() As DataTable
        Dim Thasil As New DataTable

        insertRowToTbls(Thasil, "tyinterger", "ID")
        insertRowToTbls(Thasil, "Typstring", "TglTransaksi")
        insertRowToTbls(Thasil, "Typstring", "Lokasi")
        insertRowToTbls(Thasil, "Typstring", "LokasiKet")
        insertRowToTbls(Thasil, "Typstring", "JenisTrans")
        insertRowToTbls(Thasil, "Typstring", "NoTransaksi")
        insertRowToTbls(Thasil, "Typstring", "IDPasien")
        insertRowToTbls(Thasil, "Typstring", "Pasien")
        insertRowToTbls(Thasil, "Typstring", "JenisBayar")
        insertRowToTbls(Thasil, "Typstring", "Company")
        insertRowToTbls(Thasil, "Typstring", "CompanyDetail")
        insertRowToTbls(Thasil, "Typstring", "NilaiUang")
        insertRowToTbls(Thasil, "Typstring", "No Inv")
        insertRowToTbls(Thasil, "Typstring", "TglClosed")
        insertRowToTbls(Thasil, "Typstring", "Status")
        insertRowToTbls(Thasil, "typchecked", "Closed")

        For Each Tcol As DataColumn In Thasil.Columns
            Tcol.ReadOnly = True
        Next

        Thasil.Columns("Closed").ReadOnly = False

        Return Thasil
    End Function

    Function CreateTableForReportExcel() As DataTable
        Dim Thasil As New DataTable

        insertRowToTbls(Thasil, "tyinterger", "ID")
        insertRowToTbls(Thasil, "Typstring", "TglTransaksi")
        insertRowToTbls(Thasil, "Typstring", "LokasiKet")
        insertRowToTbls(Thasil, "Typstring", "JenisTrans")
        insertRowToTbls(Thasil, "Typstring", "NoTransaksi")
        insertRowToTbls(Thasil, "Typstring", "IDPasien")
        insertRowToTbls(Thasil, "Typstring", "Pasien")
        insertRowToTbls(Thasil, "Typstring", "JenisBayar")
        insertRowToTbls(Thasil, "Typstring", "Company")
        insertRowToTbls(Thasil, "Typstring", "CompanyDetail")
        insertRowToTbls(Thasil, "Typstring", "NilaiUang")
        insertRowToTbls(Thasil, "Typstring", "TglClosed")
        insertRowToTbls(Thasil, "Typstring", "Status")

        For Each Tcol As DataColumn In Thasil.Columns
            Tcol.ReadOnly = True
        Next

        Return Thasil
    End Function

    Private Sub SetClear()
        dtprocess.Enabled = True
        butsaved.Enabled = True
        butdisplay.Enabled = True

        lbltotalomset.Text = 0
        cmbjenis.SelectedIndex = 0
        cmbstatus.SelectedIndex = 0
        txcompanycode.ResetText()
        txcabangket.ResetText()
        txkodecabang.ResetText()
        dtprocess.Value = DateAndTime.Now
        lbltotalomset.Text = "Rp 0"
        lbluangcentang.Text = "Rp 0"
        lbljumlahomset.Text = "0"
        CheckBox1.CheckState = CheckState.Unchecked

        SetConnectionFromConfig()

        gridpoli.DataSource = CreateTable()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butdisplay.Click
        lbluangcentang.Text = "Rp 0"
        CheckBox1.CheckState = CheckState.Unchecked

        Dim Tquery As String = ""
        Dim Tcompany As String = ""
        Dim Tcabang As String = ""
        Dim Tstatus As String = ""
        Dim Tjenispembayaran As String = ""
        Dim TqueryTotalOmset As String = ""

        'Company
        If txcompanycode.Text <> "" Then
            Tcompany = " and concat(kartu,'-',mesin)='" & txcompanycode.Text & "'"
        End If

        'Cabang
        If txcabangket.Text <> "" Then
            Tcabang = " and loc='" & txkodecabang.Text & "'"
        End If

        'Jenis Pembayaran
        If cmbjenis.SelectedIndex = 0 Then
            Tjenispembayaran = " AND incjenis IN ('DLL','GIGI','LAB','POLI')"
        ElseIf cmbjenis.SelectedIndex = 1 Then
            Tjenispembayaran = " AND incjenis='DLL'"
        ElseIf cmbjenis.SelectedIndex = 2 Then
            Tjenispembayaran = " AND incjenis='GIGI'"
        ElseIf cmbjenis.SelectedIndex = 3 Then
            Tjenispembayaran = " AND incjenis='LAB'"
        ElseIf cmbjenis.SelectedIndex = 4 Then
            Tjenispembayaran = " AND incjenis='POLI'"
        End If

        'Status Transaksi
        If cmbstatus.SelectedIndex = 0 Then
            Tstatus = " "
        ElseIf cmbstatus.SelectedIndex = 1 Then
            Tstatus = " AND lockeddate<>99981231"
        ElseIf cmbstatus.SelectedIndex = 2 Then
            Tstatus = " AND lockeddate=99981231"
        End If

        Tquery = "SELECT c.notagihancompany, b.locationket, a.* from acctranstagihandetail a LEFT JOIN masterlokasi b ON a.loc=b.kodeklinik LEFT JOIN acctransrekaptagihan c ON a.rekapid=c.RekapID WHERE inctgl='" & Format(dtprocess.Value, "yyyyMMdd") & "'"
        TqueryTotalOmset = "select CASE WHEN COUNT(inctransid) > 0 THEN COUNT(inctransid) ELSE 0 END AS 'jumlahtransaksi', CASE WHEN SUM(incnilai) > 0 THEN SUM(incnilai) ELSE 0 END AS 'totalomset' from acctranstagihandetail where inctgl='" & Format(dtprocess.Value, "yyyyMMdd") & "'"

        Dim Tbls As DataTable = ReadThemysql(Tquery + Tcompany + Tcabang + Tjenispembayaran + Tstatus, DB_Keuangan)
        Dim TblsOmset As DataTable = ReadThemysql(TqueryTotalOmset + Tcompany + Tcabang + Tjenispembayaran + Tstatus, DB_Keuangan)
        Dim Tdata As DataTable = gridpoli.DataSource
        GridView1.Columns("Closed").Width = 50
        Tdata.Rows.Clear()

        If Tbls.Rows.Count > 0 Then
            For Each Trow As DataRow In Tbls.Rows
                Dim Tnew As DataRow = Tdata.NewRow
                Tnew("ID") = Trow("incdetailid")
                Tnew("TglTransaksi") = Format(Trow("inctgl"), "dd-MM-yyyy")
                Tnew("Lokasi") = Trow("loc")
                Tnew("LokasiKet") = Trow("locationket")
                Tnew("JenisTrans") = Trow("incjenis")
                Tnew("NoTransaksi") = Trow("inctransid")
                Tnew("IDPasien") = Trow("idinternet")
                Tnew("Pasien") = Trow("Pasien")
                Tnew("JenisBayar") = Trow("jenis")
                Tnew("Company") = Trow("kartu")
                If IsDBNull(Trow("notagihancompany")) = False Then Tnew("No Inv") = Trow("notagihancompany") Else Tnew("No Inv") = ""
                Tnew("CompanyDetail") = Trow("mesin")
                Tnew("NilaiUang") = Splitmoney(Trow("incnilai"))
                If Trow("lockeddate") <> DateSerial("9998", "12", "31") Then
                    Tnew("Status") = "LOCKED"
                    Tnew("Closed") = True
                    Tnew("TglClosed") = Format(Trow("lockeddate"), "dd-MM-yyyy HH:mm")
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

            'Total Omset
            For Each Trow As DataRow In TblsOmset.Rows
                If Trow("totalomset") > 0 Then
                    lbltotalomset.Text = Format(Val(Trow("totalomset")), "Rp, ###,###.#0")
                    lbljumlahomset.Text = Trow("jumlahtransaksi")
                Else
                    lbltotalomset.Text = "Rp. 0"
                    lbljumlahomset.Text = 0
                End If
            Next

            gridpoli.DataSource = Tdata
            GridView1.Columns("Lokasi").Visible = False
            GridView1.Columns("ID").Visible = False
            GridView1.Columns("IDPasien").Visible = False
            GridView1.Columns("TglClosed").Visible = False
            GridView1.Columns("JenisBayar").Visible = False
        Else
            MsgBox("Detail Penerimaan belum terkirim. Minta dikirim ulang dari lokal")
        End If
    End Sub

    Private Sub AccPenerimaan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        SetFormHeightWeight(Me, 0.95, 0.8)
        SetClear()
        'WindowState = FormWindowState.Maximized
    End Sub

    Private Sub butsaved_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butsaved.Click
        If MsgBox("Yakin menyimpan data tersebut ?", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
            Dim Tbls As DataTable = gridpoli.DataSource
            Tbls.AcceptChanges()

            Dim Temp() As DataRow = Tbls.Select("[Closed]=True AND [Status]<>'LOCKED'")
            For i As Integer = 0 To Temp.Length - 1 Step 1
                If CheckThemysql("select * from acctranstagihandetail where incdetailid='" & Temp(i)("ID").ToString & "' and inctgl='" & Format(dtprocess.Value, "yyyyMMdd") & "' and loc='" & Temp(i)("Lokasi").ToString & "' and incjenis='" & Temp(i)("JenisTrans").ToString & "' and incnilai='" & CInt(Temp(i)("NilaiUang")) & "' and lockeddate=99981231", DB_Keuangan) = True Then
                    WriteThemysql("update acctranstagihandetail set lockeddate=now() , lockedby='" & PoliKlinik.Lbluser.Text & "' where incdetailid='" & Temp(i)("ID").ToString & "'", DB_Keuangan)
                End If
            Next

            MsgBox("Data Saved")
        Else
            MsgBox("Canceled Saved")
        End If
    End Sub

    Private Sub butfindcompany_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butfindcompany.Click
        Find.Show()
        Find.QueryTheMysql("select distinct CONCAT(a.kartu,'-',a.mesin) as CompJenis from acctranstagihandetail a WHERE YEAR(a.inctgl) > 2019 ", " ", "FindCompTagihanAwal", 0, Find_Keuangan)
    End Sub

    Private Sub butfindcabang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butfindcabang.Click
        Find.Show()
        Find.QueryTheMysql("SELECT a.kodeklinik, a.locationket FROM masterlokasi a WHERE a.kodeklinik IS NOT NULL", " ", "FindCabangTagihan", 0, Find_Keuangan)
    End Sub

    Private Sub butkalkulasi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butkalkulasi.Click
        Dim Ttable As DataTable = gridpoli.DataSource
        Dim total As Integer = 0
        Dim jumlah As Integer = 0
        For Each Trownew As DataRow In Ttable.Select("[Closed]=1")
            total = total + Trownew("NilaiUang")
            jumlah = jumlah + 1
            lbluangcentang.Text = "" & Format(Val(total), "Rp, ###,###.#0") & ""
        Next

        If jumlah = 0 Then
            lbluangcentang.Text = "Rp. 0 "
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        Dim Tbls As DataTable = gridpoli.DataSource

        If Tbls.Rows.Count > 0 Then
            For Each Trow As DataRow In Tbls.Rows
                If Trow("Status") = "" Then
                    If CheckBox1.CheckState = CheckState.Checked Then
                        Trow("Closed") = True
                    Else
                        Trow("Closed") = False
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub butreportexcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butreportexcel.Click
        'Dim Tdata As DataTable = CreateTableForReportExcel()
        'Dim Tbls As DataTable = gridpoli.DataSource
        'Tdata.Rows.Clear()

        'If Tbls.Rows.Count > 0 Then
        '    For Each Trow As DataRow In Tbls.Rows
        '        Dim Tnew As DataRow = Tdata.NewRow

        '        Tnew("ID") = Trow("ID")
        '        Tnew("TglTransaksi") = Format(dtprocess.Value, "dd-MMM-yyyy HH:mm")
        '        Tnew("LokasiKet") = Trow("LokasiKet")
        '        Tnew("JenisTrans") = Trow("JenisTrans")
        '        Tnew("NoTransaksi") = Trow("NoTransaksi")
        '        Tnew("IDPasien") = Trow("IDPasien")
        '        Tnew("Pasien") = Trow("Pasien")
        '        Tnew("JenisBayar") = Trow("JenisBayar")
        '        Tnew("Company") = Trow("Company")
        '        Tnew("CompanyDetail") = Trow("CompanyDetail")
        '        Tnew("NilaiUang") = Splitmoney(Trow("NilaiUang"))
        '        Tnew("Status") = Trow("Status")
        '        Tnew("TglClosed") = Format(Trow("TglClosed"), "dd-MMM-yyyy HH:mm")

        '        Tdata.Rows.Add(Tnew)
        '    Next
        'End If

        Dim Tbls As DataTable = gridpoli.DataSource
        If Tbls.Rows.Count > 0 Then
            Dim saveFileDialog1 As New SaveFileDialog
            saveFileDialog1.Filter = "Excel File|*.xls"
            saveFileDialog1.Title = "Save an Excel File"
            saveFileDialog1.ShowDialog()
            If saveFileDialog1.CheckPathExists = False Then
                MsgBox("Path tidak ada. Check kembali")
            Else
                If saveFileDialog1.CheckFileExists = True Then
                    MsgBox("Telah ada data dengan nama tersebut. Rubah nama save")
                Else
                    gridpoli.ExportToExcel(saveFileDialog1.FileName.ToString)
                    MsgBox("File Saved")
                End If
            End If
        End If
    End Sub

    Private Sub butclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butclear.Click
        SetClear()
    End Sub
End Class