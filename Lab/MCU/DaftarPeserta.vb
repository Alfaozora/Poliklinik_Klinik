Public Class DaftarPeserta

    Private DBuse As New DBSQLConn
    Private Dbasal As DataTable

    Private Sub SetClear()
        rd1.Checked = True
        DBuse.Con = New SqlConnection("Data Source='" & Utility.GetConfig("ServerLocal") & "';Initial Catalog='ToHardlent';Integrated Security=SSPI;")
        txpaketnama.ResetText()
        txpaketid.ResetText()
        lbltotalpeserta.ResetText()
        lbltotalpesertahadir.ResetText()
        lbltotalpesertatidakhadir.ResetText()
    End Sub

    Private Sub DaftarPeserta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        SetClear()
        SetGrid()
        dtstart.Value = DateAndTime.Now
        dtend.Value = DateAndTime.Now
        MaximizeBox = False
        FormBorderStyle = Windows.Forms.FormBorderStyle.FixedDialog
        'WindowState = FormWindowState.Maximized
    End Sub

    Public Sub LoadPaketID(ByRef Txid As String)
        Dim Temppaket As DataTable = ReadSQL("select PaketNama, PaketID, PaketKeterangan, PaketNilaiTotal, convert(varchar, PaketStart, 106) as PaketStart, convert(varchar, PaketEnd, 106) as PaketEnd from MasterLabPaket where PaketID=" & Txid & "")
        For Each Trowpaket As DataRow In Temppaket.Rows
            'txhargapaket.Text = Splitmoney(CDbl(Trowpaket("PaketNilaiTotal")))
            'txketerangan.Text = Trowpaket("PaketKeterangan")
            txpaketnama.Text = Trowpaket("PaketNama")
            txpaketid.Text = Trowpaket("PaketID")
        Next

        SetGrid()

        'If CheckSQL("select * from MasterLabPaket where PaketNama='" & cmbpaketnama.Text & "' and PaketEnd>'" & Format(dtpaketakhir.Value, "MM/dd/yyyy") & "'") = True Then
        '    butclear.Enabled = False
        'Else
        '    butclear.Enabled = True
        'End If

    End Sub

    Private Sub SetGrid()
        Dim TqueryCount As String = ""
        Dim Tquery As String = ""
        Dim Tpaket As String = ""
        Dim Thadir As String = ""
        Dim Torder As String = ""

        'Quary Utama
        Tquery = "select ROW_NUMBER() over (order by a.NoUrut asc) as nomor, d.StrValue + CASE WHEN a.NoUrut like '%L%' THEN RIGHT((SELECT REPLACE(a.nourut, 'L', 8)), 12) " & _
                 "WHEN a.NoUrut like '%M%' THEN RIGHT((SELECT REPLACE(a.nourut, 'M', 9)), 12) END AS NoUrut, b.Nama, b.DomisiliAlamat AS Alamat, b.JenisKelamin as JenisKelamin, convert(varchar, a.TglLab, 106) as TglLab, a.IDPaket, b.NoNIK AS PTNIK, convert(varchar, a.LabSamplingTime, 106) as WaktuDatang " & _
                 "from TransaksiLab a " & _
                 "left join MasterPasien b on a.IDInternet=b.NoRekamMedis " & _
                 "left join MsConfig d on d.ConfigName='KodeBarcode' " & _
                 "where CONVERT(date, a.tgllab) between '" & Format(dtstart.Value, "MM/dd/yyyy") & "' and '" & Format(dtend.Value, "MM/dd/yyyy") & "'"

        'Paket
        If txpaketid.Text <> "" Then
            Tpaket = " and a.IDPaket ='" & txpaketid.Text & "'"
        Else
            Tpaket = " "
        End If

        'Hadir / Tidak Hadir
        If rd1.Checked = True Then
            Thadir = " and a.SendKeu is not null"
        ElseIf rd2.Checked = True Then
            Thadir = " and a.SendKeu is null"
        ElseIf rd3.Checked = True Then
            Thadir = " "
        End If

        Torder = " order by a.NoUrut"

        Dim Tbls As DataTable = ReadSQL(Tquery & Tpaket & Thadir & Torder)
        For Each Tcol As DataColumn In Tbls.Columns
            Tcol.ReadOnly = True
        Next
        GridControl1.DataSource = Tbls

        GridView1.Columns("IDPaket").Width = 50
        GridView1.Columns("JenisKelamin").Width = 40
        GridView1.Columns("TglLab").Width = 100
        GridView1.Columns("PTNIK").Width = 70
        GridView1.Columns("nomor").Width = 40
        GridView1.Columns("nomor").Caption = "No."
        GridView1.Columns("JenisKelamin").Caption = "Sex"

        TqueryCount = "select COUNT(TransLabID) as jumlah from TransaksiLab where CONVERT(date, Tgllab) between '" & Format(dtstart.Value, "MM/dd/yyyy") & "' and '" & Format(dtend.Value, "MM/dd/yyyy") & "'"

        lbltotalpeserta.Text = ReadSQLNIK(TqueryCount & Tpaket)
        lbltotalpesertahadir.Text = ReadSQLNIK(TqueryCount & Tpaket & " and SendKeu is not null")
        lbltotalpesertatidakhadir.Text = ReadSQLNIK(TqueryCount & Tpaket & " and SendKeu is null")
    End Sub

    Private Sub butfindpaketid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butfindpaketid.Click
        Find.Show()
        Find.Query("select PaketID,PaketNama,PaketKeterangan,PaketNilaiTotal,PaketStart as Start, PaketEnd as [End] from MasterLabPaket", " order by PaketId desc ", "FindPaketIDDaftarPeserta", 2)
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        SetClear()
        SetGrid()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SetGrid()
    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        Report = New XtraReport
        Report = XtraReport.FromFile(Application.StartupPath + "\reports\LapPesertaMCU.repx", True)
        Report.DataSource = GridControl1.DataSource

        If txpaketid.Text <> "" Then
            Report.Bands.Item(BandKind.ReportHeader).Controls("txpaket").Text = ReadSQLNIK("select PaketNama from MasterLabPaket where PaketID=" & txpaketid.Text & "")
            'Report.Bands.Item(BandKind.ReportHeader).Controls("txketerangan").Text = ReadSQLNIK("select PaketKeterangan from MasterLabPaket where PaketID=" & txpaketid.Text & "")
            'Report.Bands.Item(BandKind.ReportHeader).Controls("txhargapaket").Text = Splitmoney(CDbl(ReadSQLNIK("select PaketNilaiTotal from MasterLabPaket where PaketID=" & txpaketid.Text & "")))
        Else
            Report.Bands.Item(BandKind.ReportHeader).Controls("txpaket").Text = "-"
            'Report.Bands.Item(BandKind.ReportHeader).Controls("txketerangan").Text = "-"
            'Report.Bands.Item(BandKind.ReportHeader).Controls("txhargapaket").Text = Splitmoney(CDbl(0))
        End If
        
        If rd1.Checked = True Then
            Report.Bands.Item(BandKind.ReportHeader).Controls("lbljudul").Text = "DAFTAR HADIR PESERTA MCU (SUDAH DATANG)"
        ElseIf rd2.Checked = True Then
            Report.Bands.Item(BandKind.ReportHeader).Controls("lbljudul").Text = "DAFTAR HADIR PESERTA MCU (BELUM/TIDAK DATANG)"
        ElseIf rd3.Checked = True Then
            Report.Bands.Item(BandKind.ReportHeader).Controls("lbljudul").Text = "DAFTAR SEMUA PESERTA MCU"
        End If

        Report.Bands.Item(BandKind.ReportHeader).Controls("txtanggal").Text = dtstart.Text & " s/d " & dtend.Text
        Report.Bands.Item(BandKind.ReportFooter).Controls("lbltanggalacc").Text = ".............. ," & Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:sss")

        'Report.RunDesigner()
        Report.ShowPreview()
    End Sub

    Private Sub butfindcompany_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butfindcompany.Click

    End Sub
End Class
