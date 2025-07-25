Public Class LogTransaksiCancel

    Dim Ttcmh As New TLcon
    Dim thread As System.Threading.Thread

    Private Sub SetClear()
        dtprocess.Value = DateAndTime.Now
        cmbjenistransaksi.SelectedIndex = 0
        GridDisplay(True)
    End Sub

    Private Sub GridDisplay(ByVal setwidth As Boolean)
        Dim Thasilawal As Date = dtprocess.Value
        Dim Tawal As Date = DateSerial(Thasilawal.Year, Thasilawal.Month, Thasilawal.Day)

        Dim Tquery As String = ""
        Dim Trow As New DataTable

        If cmbjenistransaksi.SelectedIndex = 0 Then
            Tquery = "select a.NoUrut, c.Nama, b.TglLab as 'TglTransaksi', a.Alasan, a.CanceledBy, a.CanceledDate " & _
                     " from TransaksiCancel a " & _
                     " left join TransaksiLab b on a.NoUrut=b.NoUrut " & _
                     " left join MasterPasien c on b.IDInternet=c.NoRekamMedis " & _
                     " where CONVERT(date, b.TglLab) = '" & Tawal & "' and a.JenisTransaksi = 'LAB'"
        ElseIf cmbjenistransaksi.SelectedIndex = 1 Then
            Tquery = "select a.NoUrut, c.Nama, b.TglPoli as 'TglTransaksi', a.Alasan, a.CanceledBy, a.CanceledDate " & _
                     " from TransaksiCancel a " & _
                     " left join TransaksiPoli b on a.NoUrut=b.NoUrut " & _
                     " left join MasterPasien c on b.IDInternet=c.NoRekamMedis " & _
                     " where CONVERT(date, b.TglPoli) = '" & Tawal & "' and a.JenisTransaksi = 'POLI'"
        ElseIf cmbjenistransaksi.SelectedIndex = 2 Then
            Tquery = "select a.NoUrut, c.Nama, b.TglGigi as 'TglTransaksi', a.Alasan, a.CanceledBy, a.CanceledDate " & _
                     " from TransaksiCancel a " & _
                     " left join TransaksiGigi b on a.NoUrut=b.NoUrut " & _
                     " left join MasterPasien c on b.IDInternet=c.NoRekamMedis " & _
                     " where CONVERT(date, b.TglGigi) = '" & Tawal & "' and a.JenisTransaksi = 'GIGI'"
        End If

        Trow = ReadSQL(Tquery)

        Dim Ttemp As New DataTable
        insertRowToTbls(Ttemp, "Typstring", "No Transaksi")
        insertRowToTbls(Ttemp, "Typstring", "Nama")
        insertRowToTbls(Ttemp, "Typstring", "Tgl Transaksi")
        insertRowToTbls(Ttemp, "Typstring", "Alasan")
        insertRowToTbls(Ttemp, "Typstring", "CanceledBy")
        insertRowToTbls(Ttemp, "Typstring", "Tgl Cancel")

        For i As Integer = 0 To Trow.Rows.Count - 1
            Dim Rnew As DataRow = Ttemp.NewRow
            Rnew("No Transaksi") = Trow(i)("NoUrut")
            Rnew("Nama") = Trow(i)("Nama")
            Rnew("Tgl Transaksi") = Format(Trow(i)("TglTransaksi"), "dd-MMM-yyyy")
            Rnew("Alasan") = Trow(i)("Alasan")
            Rnew("Tgl Cancel") = Format(Trow(i)("CanceledDate"), "yyyy-MM-dd HH:mm:ss")
            Rnew("CanceledBy") = Trow(i)("CanceledBy")
            Ttemp.Rows.Add(Rnew)
        Next

        For Each Tcols As DataColumn In Ttemp.Columns
            Tcols.ReadOnly = True
        Next

        GridControl1.DataSource = Ttemp

        If setwidth = True Then
            GridView1.Columns("Nama").Width = 200
            GridView1.Columns("Tgl Transaksi").Width = 75
            GridView1.Columns("No Transaksi").Width = 100
        End If
    End Sub

    Private Sub SetConnection()
        
    End Sub

    Private Sub LogTransaksiCancel_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        Me.MdiParent = PoliKlinik
        Me.Size = New System.Drawing.Size(1000, 503)
        SetClear()
        SetConnection()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        GridDisplay(False)
    End Sub
End Class