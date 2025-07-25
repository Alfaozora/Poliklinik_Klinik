Public Class CheckPlafon

    Private DB_JPK As TLcon
    Dim Tbls As DataTable

    Public Sub SetClear()
        txwingsid.ResetText()
        txnama.ResetText()
    End Sub

    Public Sub ClearDataPlafon()
        txpasien.ResetText()
        txtk.ResetText()
        txpribadi.Text = "0"
        txsisapribadi.Text = "0"
        txkeluarga.Text = "0"
        txsisakeluarga.Text = "0"
        txresult.ResetText()
    End Sub

    Private Sub SetGrid()
        ' Set Parameter Server Online
        Dim serverOnline_IP As String = Utility.GetConfig("ServerOnline_IP")
        Dim serverOnline_UserID As String = Utility.GetConfig("ServerOnline_UserID")
        Dim serverOnline_Password As String = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerOnline_Password"), "albert")

        ' Set DB Poliklinik
        DB_JPK.Tip = serverOnline_IP
        DB_JPK.Tid = serverOnline_UserID
        DB_JPK.Tpass = serverOnline_Password
        DB_JPK.Tdb = Utility.GetConfig("ServerOnlineJPK_DB")

        'Ttcmh.Tid = "mitramed_it"
        'Ttcmh.Tip = "mitramedicare.com"
        'Ttcmh.Tdb = "mitramed_apotek"
        'Ttcmh.Tpass = Strings.Replace("MM6ENU1n3", "|", "")
        Tbls = ReadThemysql("select * from jpkupload where periode in (select max(periode) from jpkupload) order by empid,famid,hub", DB_JPK)
        insertRowToTbls(Tbls, "tyinterger", "Sisa")
        Tbls.Columns("Sisa").ReadOnly = False
        For Each Trow As DataRow In Tbls.Rows
            Trow("Sisa") = Trow("plafon") - Trow("perkiraan") - Trow("pemakaian")
            If Trow("sex") = "1" Then Trow("sex") = "L" Else Trow("sex") = "P"


        Next
        Tbls.Columns("Sisa").ReadOnly = True

        GridControl1.DataSource = Tbls
        GridView1.Columns("periode").Visible = False
        GridView1.Columns("hardid").Visible = False
        GridView1.Columns("empid").Visible = False
        GridView1.Columns("famid").Visible = False
        GridView1.Columns("updatedate").Visible = False
        GridView1.Columns("umum").Visible = False
        GridView1.Columns("gigi").Visible = False


    End Sub

    Private Sub CheckPlafon_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetClear()
        SetGrid()
    End Sub

    Private Sub butclose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butclose.Click
        SetClear()
        Me.Close()
    End Sub

    Private Sub Filtering()
        If txnama.Text <> "" And txwingsid.Text <> "" Then
            MsgBox("Pilih salah satu yang di-filter. Nama atau No-Wings")
            Exit Sub
        End If

        Dim Ttemp As DataTable
        Ttemp = Tbls.Clone

        If txnama.Text <> "" Then
            For Each rows As DataRow In From Tmprow As DataRow In Tbls.Rows Where (Tmprow("nama").contains(txnama.Text))
                Ttemp.ImportRow(rows)
            Next
        ElseIf txwingsid.Text <> "" Then
            For Each rows As DataRow In From Tmprow As DataRow In Tbls.Rows Where (Tmprow("nohardlent").contains(txwingsid.Text))
                Ttemp.ImportRow(rows)
            Next
        End If

        Dim T1 As String = ""
        Dim T2 As String = ""

        GridControl1.DataSource = Ttemp
    End Sub

    Private Sub txnama_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txnama.TextChanged
        If txnama.Text <> "" Then
            ClearDataPlafon()
            Filtering()
        ElseIf txnama.Text = "" And txwingsid.Text = "" Then
            GridControl1.DataSource = Tbls
        End If
    End Sub

    Private Sub txwingsid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txwingsid.TextChanged
        If txwingsid.Text <> "" Then
            ClearDataPlafon()
            Filtering()
        ElseIf txnama.Text = "" And txwingsid.Text = "" Then
            GridControl1.DataSource = Tbls
        End If
    End Sub

    Private Sub LoadData(ByRef Baris As Integer)
        If GridView1.RowCount > 0 Then
            Dim Grdrow As DataRowView = GridView1.GetRow(Baris)
            Dim Ttemp, Ttemp2 As DataTable

            Dim Tempid As String = Grdrow("empid")
            Dim Keluargaplafon As Double = 0
            Dim PakaiKeluargaplafon As Double = 0
            Dim SisaKeluargaplafon As Double = 0
            Dim Tresult As String = ""
            Ttemp = Tbls.Clone
            Ttemp2 = Tbls.Clone
            For Each rows As DataRow In From Tmprow As DataRow In Tbls.Rows Where (Tmprow("empid") = Tempid)
                Ttemp.ImportRow(rows)
                Ttemp2.ImportRow(rows)
                Keluargaplafon = Keluargaplafon + rows("plafon")
                PakaiKeluargaplafon = PakaiKeluargaplafon + rows("perkiraan") + rows("pemakaian")
            Next

            Dim TTrow() As DataRow = Ttemp2.Select("[hub] = 'Karyawan'")

            GridControl1.DataSource = Ttemp
            ClearDataPlafon()
            txpasien.Text = Grdrow("nama")
            txtk.Text = TTrow(0)("nama").ToString
            txwsid.Text = Grdrow("nohardlent")
            txpribadi.Text = Splitmoney(Grdrow("plafon"))
            txsisapribadi.Text = Splitmoney(Grdrow("plafon") - Grdrow("perkiraan") - Grdrow("pemakaian"))
            txkeluarga.Text = Splitmoney(CInt(Keluargaplafon))
            txsisakeluarga.Text = Splitmoney(CInt(Keluargaplafon - PakaiKeluargaplafon))
            If CInt(txsisapribadi.Text) <= 0 Then txsisapribadi.Text = "0"
            If CInt(txsisakeluarga.Text) < 0 Then txsisakeluarga.Text = "0"

            'get in the result plafon
            If CInt(txsisakeluarga.Text) <= 0 Then
                If CInt(txsisapribadi.Text) > 0 Then
                    Tresult = "Check kembali Plafon. Ada yang tidak beres. Confirm Lionita (EMB)"
                ElseIf CInt(txsisapribadi.Text) <= 0 Then
                    Tresult = "Plafon Pribadi & Keluarga HABIS ! Tidak bisa klaim"
                End If
            ElseIf CInt(txsisakeluarga.Text) > 0 Then
                If CInt(txsisapribadi.Text) > 0 Then
                    Tresult = "Plafon Pribadi masih bisa digunakan"
                ElseIf CInt(txsisapribadi.Text) <= 0 Then
                    Tresult = "Plafon Keluarga masih bisa digunakan"
                End If
            Else
                Tresult = "Check ke Lionita (EMB). Plafon ada yang tidak beres"
            End If

            txresult.Text = Tresult

            For i As Integer = 0 To Ttemp.Rows.Count - 1
                If Ttemp(i)("nama") = txpasien.Text Then
                    GridView1.FocusedRowHandle = i
                    GridView1.ShowEditor()
                    Exit Sub
                End If
            Next

        End If
    End Sub

    Private Sub GridControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridControl1.Click
        If GridView1.FocusedRowHandle >= 0 Then
            Dim Index() As Integer = GridView1.GetSelectedRows
            If Index.Length > 0 Then
                LoadData(Index(0))
            End If
        End If
    End Sub

    'Private Sub GridControl1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridControl1.DoubleClick
    '    If GridView1.FocusedRowHandle >= 0 Then
    '        Dim Index() As Integer = GridView1.GetSelectedRows
    '        If Index.Length > 0 Then
    '            LoadData(Index(0))
    '        End If
    '    End If
    'End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        SetGrid()
        MsgBox("Reload Done")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SetClear()
        GridControl1.DataSource = Tbls
    End Sub
End Class