

Public Class ReportMasterHarga

    Dim Tjudul As String

    Private Sub SetClear()
        cmbtindakan.ResetText()
        SetGrid()
    End Sub

    Private Sub SetGrid()
        Dim Tbls As DataTable = ReadSQL("select TindakanID,NamaTindakan as Nama,JenisTindakan  as Jenis, BiayaTindakan as Harga from MasterTindakan where TindakanID=-1 order by JenisTindakan,NamaTindakan")
        insertRowToTbls(Tbls, "tyinterger", "No")
        GridControl1.DataSource = Tbls
        GridView1.Columns(0).Visible = False
        GridView1.Columns("No").Visible = False
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub butdisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butdisplay.Click
        DisplayToolStripMenuItem.PerformClick()
    End Sub

    Private Sub ReportMasterHarga_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        SetClear()
    End Sub

    Private Sub SetData()
        Dim Tquery As String = ""
        Tjudul = ""
        Select Case cmbtindakan.Text
            Case "Master Tindakan"
                Tquery = "select TindakanID as ID,NamaTindakan as Nama,JenisTindakan as Jenis,PARSENAME(CONVERT(varchar,convert(money,BiayaTindakan),1),2) as Harga from MasterTindakan where closed=0 order by JenisTindakan,NamaTindakan"
                Tjudul = "MASTER TINDAKAN POLI"
            Case "Master Lab"
                Tquery = "select TindakanID as ID,NamaTindakan as Nama,JenisTindakan  as Jenis,PARSENAME(CONVERT(varchar,convert(money,BiayaTindakan),1),2) as Harga from MasterLab where closed=0 order by JenisTindakan,NamaTindakan"
                Tjudul = "MASTER TINDAKAN LAB"
            Case "Master Gigi"
                Tquery = "select TindakanID as ID,NamaTindakan as Nama,JenisTindakan  as Jenis,PARSENAME(CONVERT(varchar,convert(money,BiayaTindakan),1),2) as Harga from MasterTindakanGigi where Aktif=1 order by JenisTindakan,NamaTindakan"
                Tjudul = "MASTER TINDAKAN GIGI"
        End Select

        If Tquery <> "" Then
            Dim Tbls As DataTable = ReadSQL(Tquery)
            insertRowToTbls(Tbls, "tyinterger", "No")
            Dim i As Integer = 1
            For Each Trow As DataRow In Tbls.Rows
                Trow("No") = i
                i = i + 1
            Next
            GridControl1.DataSource = Tbls
            GridView1.Columns(0).Visible = False
            GridView1.Columns("No").Visible = False

        End If

    End Sub

    Private Sub DisplayToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DisplayToolStripMenuItem.Click
        SetData()
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        Dim Tdata As DataTable = GridControl1.DataSource
        If Tdata.Rows.Count > 0 Then
            Report = New XtraReport
            Report = XtraReport.FromFile(Application.StartupPath + "\reports\LapMasterTindakanHarga.repx", True)
            Report.DataSource = Tdata
            Report.Bands.Item(BandKind.ReportHeader).Controls("lbljenissetoran").Text = Tjudul
            Report.Bands.Item(BandKind.ReportHeader).Controls("lbltanggal").Text = "Data per : " & Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm")
            'Report.RunDesigner()
            Report.ShowPreview()
        Else
            MsgBox("Tidak ada data Master yang di-print")
        End If
    End Sub

    Private Sub ExportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExportToolStripMenuItem.Click
        Dim Tdata As DataTable = GridControl1.DataSource
        If Tdata.Rows.Count > 0 Then
            ExportDataToExcel(GridControl1)
        Else
            MsgBox("Tidak ada data Master yang di-export")
        End If
    End Sub
End Class