Public Class CetakKartu

    Private Sub SetClear()
        buttindakanid.ResetText()
        dttgl.Value = DateAndTime.Now
        rdall.Checked = True
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        SetClear()
    End Sub

    Private Sub CetakKartu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        NewToolStripMenuItem.PerformClick()
    End Sub

    Function Checking() As Boolean
        If rdall.Checked = False And rdulang.Checked = False And rdpertama.Checked = False Then
            MsgBox("Pilih salah satu antara 3 pilihan display")
            Return False
        End If

        If buttindakanid.Text = "" Then
            MsgBox("Pilih cabang yang sesuai.")
            Return False
        End If

        Return True
    End Function

    Private Sub butdisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butdisplay.Click
        If Checking() = True Then
            GridView3.Columns.Clear()
            Dim Tquery As String = ""
            If rdall.Checked = True Then
                Tquery = "select a.idpasien,a.cabang,right(a.nokartu,4) as nokartu,a.nomitra as no,concat(concat(a.cabang,right(a.nokartu,4)),a.nomitra) as nomitra,a.nokartu,a.nama,year(b.`start`) as Tahun, month(b.`start`)as Bulan, day(b.`start`) as Hari,b.`start`,b.`end` from masterpasien a left join masteraktifpasien b on a.idpasien=b.idpasien where b.aktif=1 and b.end>='" & Format(dttgl.Value, "yyyyMMdd") & "' and a.cabang='" & buttindakanid.Text & "'"
            ElseIf rdpertama.Checked = True Then
                Tquery = "select a.idpasien,a.cabang,right(a.nokartu,4) as nokartu,a.nomitra as no,concat(concat(a.cabang,right(a.nokartu,4)),a.nomitra) as nomitra,a.nokartu,a.nama,year(b.`start`) as Tahun, month(b.`start`)as Bulan, day(b.`start`) as Hari,b.`start`,b.`end` from masterpasien a left join masteraktifpasien b on a.idpasien=b.idpasien where b.aktif=1 and b.end>='" & Format(dttgl.Value, "yyyyMMdd") & "' and a.cabang='" & buttindakanid.Text & "' and a.tglcetak is null"
            ElseIf rdulang.Checked = True Then
                Tquery = "select a.idpasien,a.cabang,right(a.nokartu,4) as nokartu,a.nomitra as no,concat(concat(a.cabang,right(a.nokartu,4)),a.nomitra) as nomitra,a.nokartu,a.nama,year(b.`start`) as Tahun, month(b.`start`)as Bulan, day(b.`start`) as Hari,b.`start`,b.`end` from masterpasien a left join masteraktifpasien b on a.idpasien=b.idpasien where b.aktif=1 and b.end>='" & Format(dttgl.Value, "yyyyMMdd") & "' and a.cabang='" & buttindakanid.Text & "' and a.tglcetak is not null"
            End If

            Dim Tbls As DataTable = ReadMySQL(Tquery)
            insertRowToTbls(Tbls, "typchecked", "Checked")
            For Each Tcol As DataColumn In Tbls.Columns
                Tcol.ReadOnly = True
            Next
            Tbls.Columns("Checked").ReadOnly = False
            griddata.DataSource = Tbls
            GridView3.Columns("cabang").Visible = False
            GridView3.Columns("nokartu").Visible = False
            GridView3.Columns("no").Visible = False
            GridView3.Columns("Tahun").Visible = False
            GridView3.Columns("Hari").Visible = False
            GridView3.Columns("Bulan").Visible = False

        End If
    End Sub

    Private Sub buttindakanid_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles buttindakanid.ButtonClick
        Find.Show()
        Find.QueryMysql(" select distinct cabang from masterpasien ", " order by cabang ", "DisplayCabang", 0)
    End Sub

    Private Sub buttindakanid_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttindakanid.EditValueChanged

    End Sub

    Private Sub PrintToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrintToolStripMenuItem.Click
        Dim Tbls As DataTable = griddata.DataSource
        Tbls.AcceptChanges()

        Dim Trow() As DataRow = Tbls.Select("[Checked]=True")

        If Trow.Length > 0 Then
            Dim Tblsnew As DataTable = Tbls.Clone

            For i As Integer = 0 To Trow.Length - 1
                Dim Tnewrow As DataRow = Tblsnew.NewRow
                For j As Integer = 0 To Tbls.Columns.Count - 1
                    Tnewrow(j) = Trow(i)(j)
                Next
                Tblsnew.Rows.Add(Tnewrow)
            Next

            Report = New XtraReport
            Report = XtraReport.FromFile(Application.StartupPath + "\reports\LapKartu.repx", True)
            Report.DataSource = Tblsnew
            'Report.RunDesigner()
            Report.ShowPreview()
            'Report.Print()
        End If


    End Sub
End Class