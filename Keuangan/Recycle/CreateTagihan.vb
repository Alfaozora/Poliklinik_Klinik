Public Class CreateTagihan
    ' Set Connection
    Private DB_Keuangan As TLcon

    Private Sub SetConnectionFromConfig()
        ' Set Parameter Server Online
        Dim serverOnline_IP As String = Utility.GetConfig("ServerOnline_IP")
        Dim serverOnline_UserID As String = Utility.GetConfig("ServerOnline_UserID")
        Dim serverOnline_Password As String = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerOnline_Password"), "albert")

        ' Set DB Keuangan 1 (mitramed_keu)
        DB_Keuangan.Tip = serverOnline_IP
        DB_Keuangan.Tid = serverOnline_UserID
        DB_Keuangan.Tpass = serverOnline_Password
        DB_Keuangan.Tdb = Utility.GetConfig("ServerOnlineKeuangan_DB")
    End Sub

    Public Sub OnCetakan()
        butsaved.Enabled = False
        grpkwitansi.Enabled = True
        grptagihan.Enabled = True
        rddetail.Checked = True
        rdcdc.Checked = True
    End Sub

    Public Sub OffCetakan()
        butsaved.Enabled = True
        grpkwitansi.Enabled = False
        grptagihan.Enabled = False
        rddetail.Checked = False
        rdsummary.Checked = False
        rdcdc.Checked = False
        rdcmh.Checked = False
        rdcmh.Checked = False
    End Sub

    Public Sub LoadTagihan(ByRef Txid As String, ByRef Txcomp As String, ByRef Tdb As DataTable)
        txrekapid.Text = Txid
        txcompany.Text = Txcomp
        dttglbuat.Value = DateAndTime.Now
        dtduedate.Value = DateAdd(DateInterval.Day, CInt(txterm.Text), dttglbuat.Value)


        If Txid <> "" Then
            Dim Tbls As DataTable = ReadThemysql("select * from acctransrekaptagihan where rekapid='" & Txid & "'", DB_Keuangan)
            Dim Trow As DataRow = Tbls.Rows(0)
            txterm.Text = Trow("periode")
            If IsDBNull(Trow("tglcetak")) = False Then
                OnCetakan()
                Dim Tsplit() As String = Trow("notagihancompany").ToString.Split("/")
                txnoref1.Text = Tsplit(0)
                txnoref2.Text = Tsplit(1)
                txnoref3.Text = Tsplit(Tsplit.Length - 2) & "/" & Tsplit(Tsplit.Length - 1)
            Else
                OffCetakan()
                SetNoTagihanCompany()
            End If
        Else
            txterm.Text = 0
            OffCetakan()
            SetNoTagihanCompany()
        End If

        txtotalorg.Text = Tdb.Rows.Count
        GridControl1.DataSource = Tdb


        Dim Ttl As Integer = 0
        For Each Trow As DataRow In Tdb.Rows
            Ttl = Ttl + CInt(Trow("Tagihan"))
        Next

        txtotaltagihan.Text = Splitmoney(Ttl)
    End Sub

    Public Sub Clear()
        SetConnectionFromConfig()

        txrekapid.ResetText()
        txcompany.ResetText()
        dttglbuat.Value = DateAndTime.Now
        txterm.Text = "0"
        dtduedate.Value = DateAdd(DateInterval.Day, CInt(txterm.Text), dttglbuat.Value)
        txtotalorg.Text = "0"
        txtotaltagihan.Text = "0"

        SetNoTagihanCompany()
    End Sub

    Private Sub SetNoTagihanCompany()
        Dim Tmax As String = "0"

        Dim Tdb As DataTable = ReadThemysql("select ifnull(notagihancompany,0) as No from acctransrekaptagihan where company='" & txcompany.Text & "' and year(tgltagihan)='" & dttglbuat.Value.Year & "' order by notagihancompany desc ", DB_Keuangan)
        If Tdb.Rows.Count > 0 Then
            If Tdb.Rows.Count = 1 Then
                Dim Trow As DataRow = Tdb.Rows(0)
                If Trow("No").ToString = "0" Then
                    Tmax = "1"
                End If
            End If

            For Each Rrow As DataRow In Tdb.Rows
                Dim Tsplit() As String = Rrow("No").ToString.Split("/")
                If CDbl(Tsplit(0)) > Tmax Then Tmax = CDbl(Tsplit(0))
            Next
            Tmax = Tmax + 1
        End If
        Dim angka2 As String = "0001"
        Dim angka As String = ReadThemysqlNIK("select concat(lpad(LEFT(notagihancompany,4)+1,4,0)) from acctransrekaptagihan WHERE tgltagihan BETWEEN DATE_FORMAT('" & Format(dttglbuat.Value, "yyyy-MM-dd") & "' ,'%Y-%m-01 %T') AND LAST_DAY('" & Format(dttglbuat.Value, "yyyy-MM-dd") & "') order BY notagihancompany desc limit 1", DB_Keuangan)

        If angka = "" Or angka = "-" Then
            txnoref1.Text = angka2
        ElseIf angka <> "" Then
            txnoref1.Text = angka
        End If

        txnoref2.Text = "JBM-KEU"
        txnoref3.Text = GetRomes(dttglbuat.Value.Month) & "/" & Format(dttglbuat.Value, "yyyy")
    End Sub

    Private Sub butsaved_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butsaved.Click
        If dtduedate.Value < dttglbuat.Value Then
            MsgBox("Tanggal DueDate ( Tagihan ) lebih kecil dari tanggal buat")
            Exit Sub
        End If

        Dim Tid As String = ""

        If txrekapid.Text = "" Then
            'new
            WriteThemysql("insert into acctransrekaptagihan(company, tgltagihan, periode, duedate, totaltagihan, keterangan, createdate, createby, notagihancompany) values('" & txcompany.Text & "', '" & Format(dttglbuat.Value, "yyyyMMdd") & "', '" & CInt(txterm.Text) & "', '" & Format(dtduedate.Value, "yyyyMMdd") & "', '" & CInt(txtotaltagihan.Text) & "', '" & txket.Text & "',now(), '" & PoliKlinik.Lbluser.Text & "', '" & txnoref1.Text & "/" & txnoref2.Text & "/" & txnoref3.Text & "') ", DB_Keuangan)
            Dim Ttest As DataTable = ReadThemysql("select * from acctransrekaptagihan where company='" & txcompany.Text & "' and tgltagihan='" & Format(dttglbuat.Value, "yyyyMMdd") & "' and duedate='" & Format(dtduedate.Value, "yyyyMMdd") & "' and totaltagihan='" & CInt(txtotaltagihan.Text) & "' and notagihancompany='" & txnoref1.Text & "/" & txnoref2.Text & "/" & txnoref3.Text & "'", DB_Keuangan)
            Dim Rrow As DataRow = Ttest.Rows(0)
            Tid = Rrow("RekapID")
        Else
            'update 
            WriteThemysql("update acctransrekaptagihan set tgltagihan='" & Format(dttglbuat.Value, "yyyyMMdd") & "' , periode= '" & CInt(txterm.Text) & "' , duedate='" & Format(dtduedate.Value, "yyyyMMdd") & "' , totaltagihan='" & CInt(txtotaltagihan.Text) & "' , keterangan='" & txket.Text & "', notagihancompany='" & txnoref1.Text & "/" & txnoref2.Text & "/" & txnoref3.Text & "' where RekapID='" & txrekapid.Text & "'", DB_Keuangan)
            Tid = txrekapid.Text
        End If

        Dim Ttemp As DataTable = GridControl1.DataSource
        Ttemp.AcceptChanges()

        WriteThemysql("update acctranstagihandetail set rekapid=null where RekapID='" & txrekapid.Text & "'", DB_Keuangan)
        For Each Trow As DataRow In Ttemp.Rows
            WriteThemysql("update acctranstagihandetail set rekapid='" & Tid & "' where incdetailid='" & Trow("ID").ToString & "'", DB_Keuangan)
        Next

        'MsgBox("Data Saved dan Updated pada RekapID = '" & Tid & "'")
        MsgBox("Data Saved")
        'butsaved.Enabled = False
        FormAwalPembayaranTagihan.butnewtagihan.PerformClick()
        Me.Close()
    End Sub

    Private Sub butfindcomp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butfindcomp.Click

    End Sub

    Private Sub butcetaktagihan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butcetaktagihan.Click
        If txrekapid.Text <> "" Then
            If rddetail.Checked = True Then

            ElseIf rdsummary.Checked = True Then

            Else
                MsgBox("")
            End If
        End If

        Dim Tbls As DataTable = ReadThemysql("SELECT a.`incdetailid` as ID, a.`incJenis` as Jenis , a.`inctransid` as TransID, a.`inctgl` as Tgl , a.`idinternet` as IDPasien, a.`pasien` as Nama ,a.`incnilai` as Tagihan FROM acctranstagihandetail a where  rekapid='" & txrekapid.Text & "'", DB_Keuangan)
        insertRowToTbls(Tbls, "Typstring", "Tgltrans")
        insertRowToTbls(Tbls, "Typstring", "Jumlah")
        insertRowToTbls(Tbls, "Typstring", "Txnoref")
        insertRowToTbls(Tbls, "Typstring", "Comp")
        insertRowToTbls(Tbls, "Typstring", "DtInv")
        insertRowToTbls(Tbls, "Typstring", "DueDt")

        For Each Trow As DataRow In Tbls.Rows
            Trow("Tgltrans") = Format(Trow("Tgl"), "dd-MMM-yyyy")
            Trow("Jumlah") = Splitmoney(Trow("Tagihan"))
            Trow("Txnoref") = txnoref1.Text
            Trow("Comp") = txcompany.Text
            Trow("DtInv") = Format(dttglbuat.Value, "dd-MMM-yyyy")
            Trow("DueDt") = Format(dtduedate.Value, "dd-MMM-yyyy")
        Next


        If CheckThemysql("select * from acctransrekaptagihan where RekapID='" & txrekapid.Text & "' and tglcetak is null ", DB_Keuangan) = True Then
            If MsgBox(" Yakin untuk cetak dan kemudian close Rekap sehingga tidak bisa diganti-ganti ? ", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                WriteThemysql("update acctransrekaptagihan set tglcetak=now() where RekapID='" & txrekapid.Text & "' ", DB_Keuangan)
                Report = New XtraReport
                Report = XtraReport.FromFile(Application.StartupPath + "\reports\Keuangan\Empty\ReportCetakRekapTagihan.repx", True)
                Report.DataSource = Tbls
                'Report.RunDesigner()
                Report.ShowPreview()
                'Report.Print()
            Else
                MsgBox("Batal cetak dan Close Rekap")
            End If
        Else
            If MsgBox("Rekap telah terkunci. Apakah mau mencetak ulang Rekap ?", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                'cetak ulang rekap - copied
                Report = New XtraReport
                Report = XtraReport.FromFile(Application.StartupPath + "\reports\Keuangan\Empty\ReportCetakRekapTagihanCopied.repx", True)
                Report.DataSource = Tbls
                'Report.RunDesigner()
                Report.ShowPreview()
                'Report.Print()
            Else
                Exit Sub
            End If
        End If
    End Sub

    Private Sub txterm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txterm.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txterm_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txterm.LostFocus
        dtduedate.Value = DateAdd(DateInterval.Day, CDbl(txterm.Text), dttglbuat.Value)
    End Sub

    Private Sub dttglbuat_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txterm.LostFocus
        dtduedate.Value = DateAdd(DateInterval.Day, CDbl(txterm.Text), dttglbuat.Value)
    End Sub

    Private Sub txnoref2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txnoref2.TextChanged, dttglbuat.ValueChanged
        SetNoTagihanCompany()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If rdcdc.Checked = True Then

        ElseIf rdcmh.Checked = True Then

        ElseIf rdmmc.Checked = True Then

        Else
            MsgBox("Report tidak dapat ditemukan. Check kembali no urut dan model cetakan.")
        End If
    End Sub
End Class