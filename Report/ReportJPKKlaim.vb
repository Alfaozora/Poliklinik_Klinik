Public Class ReportJPKKlaim

    Private DBuse As New DBSQLConn
    Private Dbasal As DataTable

    Private Sub SetClear()
        DBuse.Con = New SqlConnection("Data Source='" & Utility.GetConfig("ServerLocal") & "';Initial Catalog='ToHardlent';Integrated Security=SSPI;")
        Dim Ttahun As DataTable = ReadSQL("select distinct periode from HardlentTransaction order by Periode", DBuse)
        cmbtahun.Items.Clear()
        For Each Trow As DataRow In Ttahun.Rows
            cmbtahun.Items.Add(Trow(0))
        Next
        cmbtahun.ResetText()
    End Sub

    Private Sub butok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butok.Click
        If cmbtahun.Text <> "" Then
            If cmbtahun.SelectedIndex < 0 Then
                MsgBox("Pilih tahun yang sesuai.")
            Else

                Dim Thasil As DataTable = ReadSQL("select a.TransId as ID,a.Company as Comp,a.Periode,a.EmpID,a.HardIdEmp,c.ENama as TK,a.HardIdUntuk,d.ENama as Pasien,b.Tgl,b.TindakanId,g.Keterangan,g.[Grouping],b.Klaim,b.Refund " & _
                                                  " from HardlentTransaction a left join HardlentTransactionDetail b on a.TransId=b.TransId left join [EmpMst-Hardlent] c on a.HardIdEmp=c.HardId and a.EmpId=c.EmpID " & _
                                                  " left join [EmpMst-Hardlent] d on a.HardIdUntuk=d.HardId and a.EmpId=d.EmpID left join [MST-TindakanHardlent] g on g.TindakanId=b.TindakanId and b.Tgl between g.Begda and g.Endda " & _
                                                  " where a.Periode='" & cmbtahun.Text & "' order by a.EmpId,a.HardIdEmp,a.HardIdUntuk,a.TransId ", DBuse)

                GridControl1.DataSource = Thasil
                GridView1.Columns("Comp").Visible = False
                GridView1.Columns("HardIdEmp").Visible = False
                GridView1.Columns("HardIdUntuk").Visible = False
                GridView1.Columns("TindakanId").Visible = False
                GridView1.Columns("Periode").Visible = False
            End If
        End If
    End Sub

    Private Sub ReportJPKKlaim_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        SetClear()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ExportDataToExcel(GridControl1)
    End Sub
End Class