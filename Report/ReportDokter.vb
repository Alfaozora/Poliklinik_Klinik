Public Class ReportDokter

    Private Sub SetClear()
        dtawal.Value = DateAndTime.Now
        dtakhir.Value = dtawal.Value
        rdtanggal.Checked = True
    End Sub

    Private Sub SetGrid(ByRef Tgl As Date)
        Dim Tbls As New DataTable
        Tbls = ReadSQL("select DrCode,DrNama  from MasterDokter a left join Users b on a.DrCode=b.UserID where DrJenis<>'Perawat' ")
        insertRowToTbls(Tbls, "typchecked", "Checked")

        For Each Tcol As DataColumn In Tbls.Columns
            Tcol.ReadOnly = True
        Next
        Tbls.Columns("Checked").ReadOnly = False
        gridtindakan.DataSource = Tbls
    End Sub

    Private Sub dtawal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtawal.ValueChanged
        SetGrid(dtawal.Value)
    End Sub

    Private Sub ReportDokter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        SetClear()
    End Sub

    Function Checking() As Boolean
        Dim Tbls As DataTable = gridtindakan.DataSource
        Tbls.AcceptChanges()
        Dim Tnew() As DataRow = Tbls.Select("[Checked]=True")

        If Tnew.Length <= 0 Then
            MsgBox("Pilih salah satu dokter untuk di-display")
            Return False
        End If

        If dtakhir.Value < dtawal.Value Then
            MsgBox("Tanggal akhir tidak boleh lebih kecil dari tanggal awal")
            Return False
        End If

            Return True
    End Function

    Private Sub butdisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butdisplay.Click
        If Checking() = True Then
            Dim Tstr As String = ""
            Dim Tdokter As DataTable = gridtindakan.DataSource
            Tdokter.AcceptChanges()
            For i As Integer = 0 To Tdokter.Rows.Count - 1
                If Tdokter.Rows(i)("Checked") = True Then Tstr = Tstr + "'" + Tdokter.Rows(i)("DrCode").ToString + "',"
            Next
            Tstr = Strings.Left(Tstr, Len(Tstr) - 1)

            Dim Tquer As DataTable = ReadSQL("select c.DrCode,c.DrNama,a.PoliCustID,b.Nama,b.NoFiling,a.StatusCustNow,a.PoliJenisBiaya,a.PoliTanggal " & _
                                             "from Poli a left join MasterCustomer b on a.PoliCustID=b.NoID left join MasterDokter c on a.PoliDokterID=c.DrCode and c.DrJenis<>'Perawat'" & _
                                             "where a.PoliTanggal between '" & Format(dtawal.Value, "MM/dd/yyyy") & "' and '" & Format(dtakhir.Value, "MM/dd/yyyy") & "' and c.DrCode  in (" & Tstr & ") " & _
                                             "order by a.PoliTanggal,c.DrCode,a.StatusCustNow,a.PoliJenisBiaya")
            
            Report = New XtraReport
            If rddokter.Checked = True Then
                Report = XtraReport.FromFile(Application.StartupPath + "\reports\LapDokterperdokter.repx", True)
            ElseIf rdtanggal.Checked = True Then
                Report = XtraReport.FromFile(Application.StartupPath + "\reports\LapDokterpertanggal.repx", True)
            End If
            Report.Bands.Item("ReportHeader").Controls("lbltanggal").Text = "Periode Tanggal :" & Format(dtawal.Value, "dd-MMM-yyyy") & " s/d " & Format(dtakhir.Value, "dd-MMM-yyyy")
            Report.Bands.Item("PageFooter").Controls("lblcreate").Text = "Create By : " & PoliKlinik.Lbluser.Text & ". " & Format(DateAndTime.Now, "dd-MMM-yyyy HH:ss:mmmm")

            Report.DataSource = Tquer
            'Report.RunDesigner()
            Report.ShowPreview()
            'Report.Print()
        End If
    End Sub
End Class