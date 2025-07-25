Public Class ReportJPKAktif

    Private DBuse As New DBSQLConn
    Private Dbasal As DataTable

    Private Sub SetClear()
        dtaktif.Value = DateAndTime.Now
        rd1.Checked = True
        DBuse.Con = New SqlConnection("Data Source='" & Utility.GetConfig("ServerLocal") & "';Initial Catalog='ToHardlent';Integrated Security=SSPI;")
        txaktif.Text = "Jumlah : 0 org."
    End Sub

    Private Sub ReportJPKAktif_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        SetClear()
    End Sub

    Private Sub butok_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butok.Click
        Dim Tawal As Date = DateSerial(dtaktif.Value.Year, dtaktif.Value.Month, "01")
        Dim Ttemp As Date = DateSerial(dtaktif.Value.Year, dtaktif.Value.Month, "01").AddMonths(1)
        Dim Takhir As Date = Ttemp.AddDays(-1)
        Dim Tquery As String = ""

        If rd1.Checked = True Then
            Tquery = "select HardId,EmpID,FamID,Hub,ENama as Nama,TglLhr,case when ESex=1 then 'L' else 'P' end as LP,KriteriaUtama as Utama,NoHardlent,Aktif,TglAktif,TglNonAktif,Umum,b.DokterNama as DrUmum,Gigi,c.DokterNama as DrGigi " & _
            " from [EmpMst-Hardlent] a left join [MST-Dokter] b on a.Umum=b.DokterID left join [MST-Dokter] c on a.Gigi=c.DokterID where Aktif=1 or ( Aktif=0 and TglNonAktif between '" & Format(Ttemp, "MM/dd/yyyy") & "' and '12/31/9998' )"
        ElseIf rd2.Checked = True Then

            Tquery = "select HardId,EmpID,FamID,Hub,ENama as Nama,TglLhr,case when ESex=1 then 'L' else 'P' end as LP,KriteriaUtama as Utama,NoHardlent,Aktif,TglAktif,TglNonAktif,Umum,b.DokterNama as DrUmum,Gigi,c.DokterNama as DrGigi " & _
            " from [EmpMst-Hardlent] a left join [MST-Dokter] b on a.Umum=b.DokterID left join [MST-Dokter] c on a.Gigi=c.DokterID where  Aktif=0 and TglNonAktif between '" & Format(Tawal, "MM/dd/yyyy") & "' and '" & Format(Takhir, "MM/dd/yyyy") & "'"
        End If

        GridControl1.DataSource = ReadSQL(Tquery, DBuse)
        GridView1.Columns("Umum").Visible = False
        GridView1.Columns("Gigi").Visible = False
        txaktif.Text = "Jumlah : " & GridView1.RowCount & " org."

    End Sub

End Class