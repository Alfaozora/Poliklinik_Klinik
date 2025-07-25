Public Class RekapPasien

    Private QData As String
    Private Kriteria(10) As String
    Private Dbasal As DataTable
    Private Tconn As Find.TLconnect

    Public Sub Clear()
        transawal.ResetText()
        transakhir.ResetText()
        dtawal.Value = DateAndTime.Now
        rdtgltrans.Checked = True
    End Sub

    Public Sub QueryTheMysql(ByRef Qtext As String, ByRef Txid As String, ByRef Ttcmh As Find.TLconnect)
        Me.BringToFront()
        GridControl1.DataSource = Nothing
        GridView1.Columns.Clear()

        Dbasal = New DataTable
        QData = "SELECT a.`incdetailid` as ID, a.`incJenis` as Jenis , a.`inctransid` as TransID, a.`inctgl` as Tgl , a.`idinternet` as IDPasien, a.`pasien` as Nama ,a.`incnilai` as Tagihan FROM acctranstagihandetail a where ( rekapid is null or rekapid='" & Txid & "') and concat(kartu,'-',mesin)='" & Qtext & "' and lockeddate<>99981231"

        Dim lblconnect As String = ""
        With Tconn
            Try
                lblconnect = "Loading Connect to Cahaya Database ..."
                .Tconnect = New MySqlConnection("datasource=" & Ttcmh.Tip.ToString & ";username=" & Ttcmh.Tid.ToString & ";password=" & Ttcmh.Tpass.ToString & ";database=" & Ttcmh.Tdb.ToString)
                If .Tconnect.State = ConnectionState.Open Then .Tconnect.Close()
                .Tconnect.Open()
                .Tcommand = New MySqlCommand(QData, .Tconnect)
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

        Dim Tview As DataTable = GridControl1.DataSource
        If GridView1.RowCount > 0 Then GridView1.SelectRow(0)

    End Sub

    Private Sub butok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butok.Click
        Dim Ttable As DataTable = GridControl1.DataSource
        Dim Trow() As DataRow = Ttable.Select("[Pilihan]=1")
        If Trow.Length > 0 Then
            FormAwalPembayaranTagihan.SetGridBaru(Trow)
        End If

        Me.Close()
    End Sub

    Private Sub RekapPasien_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub butselect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butselect.Click
        Dim Tbls As DataTable
        Tbls = Dbasal.Clone

        For Each Trow As DataRow In Tbls.Rows
            Trow("Pilihan") = False
        Next
        Tbls.AcceptChanges()

        If rdtransid.Checked = True Then
            Dim Rws() As DataRow = Dbasal.Select("[TransID] >= " & transawal.Text & " AND [TransID] <= " & transakhir.Text)
            For Each rows In Rws
                rows("Pilihan") = True
                Tbls.ImportRow(rows)
            Next
            GoTo addall
        ElseIf rdtgltrans.Checked = True Then
            Dim Rws() As DataRow = Dbasal.Select("[Tgl]='" & Format(dtawal.Value, "MM/dd/yyyy") & "'")
            Tbls = Dbasal.Clone
            For Each rows In Rws
                rows("Pilihan") = True
                Tbls.ImportRow(rows)
            Next
            GoTo addall
        ElseIf rdall.Checked = True Then
            GridControl1.DataSource = Dbasal
            If GridView1.RowCount > 0 Then
                GridView1.SelectRow(0)
            End If
            Exit Sub
        End If

AddAll:
        GridControl1.DataSource = Tbls
        If GridView1.RowCount > 0 Then
            GridView1.SelectRow(0)
        End If


    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Ttable As DataTable = GridControl1.DataSource
        'Dim Trow() As DataRow = Ttable.Select("[Pilihan]=1")
        Dim total As Integer = 0
        For Each Trownew As DataRow In Ttable.Select("[Pilihan]=1")
            total = total + Trownew("Tagihan")
            TextBox1.Text = total
        Next
        'If Trow.Length > 0 Then

        'End If
    End Sub

    Private Sub GridControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridControl1.Click

    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        Dim Tbls As DataTable = GridControl1.DataSource

        If Tbls.Rows.Count > 0 Then
            For Each Trow As DataRow In Tbls.Rows
                If CheckBox1.CheckState = CheckState.Checked Then
                    Trow("Pilihan") = True
                Else
                    Trow("Pilihan") = False
                End If
            Next
        End If
    End Sub
End Class