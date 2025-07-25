Public Class masterlaboratoriumrujukan
    Private Find_Poliklinik As Find.TLconnect
    Private DB_Poliklinik As TLcon

    Private Sub Download()
        Dim Tbls As DataTable = ReadThemysql("select * from masterlaboratoriumrujukan", DB_Poliklinik)
        For Each Trow As DataRow In Tbls.Rows
            If CheckSQL("select * from masterlaboratoriumrujukan where nolabrujukan='" & Trow("nolabrujukan").ToString & "'") = True Then
                'update
                WriteSQL("update masterlaboratoriumrujukan set UploadOnline=" & Trow("uploadonline") & ", namalabrujukan='" & Trow("namalabrujukan").ToString & "',alamatlabrujukan='" & Trow("alamatlabrujukan").ToString & "',uplabrujukan='" & Trow("uplabrujukan").ToString & "', StartDate='" & Format(Trow("startdate"), "MM/dd/yyyy") & "' , Enddate='" & Format(Trow("enddate"), "MM/dd/yyyy") & "' where nolabrujukan='" & Trow("nolabrujukan").ToString & "'", 4)
            Else
                'new
                WriteSQL("insert into masterlaboratoriumrujukan(namalabrujukan,alamatlabrujukan,uplabrujukan,StartDate,EndDate,CreateDate,CreateBy,nolabrujukan,UploadOnline) values('" & Trow("namalabrujukan") & "','" & Trow("alamatlabrujukan") & "','" & Trow("uplabrujukan") & "','" & Format(Trow("startdate"), "yyyyMMdd") & "','" & Format(Trow("enddate"), "yyyyMMdd") & "',getdate(),'" & PoliKlinik.Lbluser.Text & "','" & Trow("nolabrujukan") & "', " & Trow("uploadonline") & ")", 4)
            End If
        Next
        MsgBox("Master Lab Rujukan Updated.", MsgBoxStyle.Information, "Information")
    End Sub

    Private Sub SetConn()
        ' Set Parameter Server Online
        Dim serverOnline_IP As String = Utility.GetConfig("ServerOnline_IP")
        Dim serverOnline_UserID As String = Utility.GetConfig("ServerOnline_UserID")
        Dim serverOnline_Password As String = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerOnline_Password"), "albert")

        ' Set Find Poliklinik
        Find_Poliklinik.Tip = serverOnline_IP
        Find_Poliklinik.Tid = serverOnline_UserID
        Find_Poliklinik.Tpass = serverOnline_Password
        Find_Poliklinik.Tdb = Utility.GetConfig("ServerOnlinePoli_DB")

        ' Set DB Poliklinik
        DB_Poliklinik.Tip = serverOnline_IP
        DB_Poliklinik.Tid = serverOnline_UserID
        DB_Poliklinik.Tpass = serverOnline_Password
        DB_Poliklinik.Tdb = Utility.GetConfig("ServerOnlinePoli_DB")
    End Sub

    Private Sub SetNomorL()
        Dim Tmax As Integer = 0
        Dim Dbmax As DataTable = ReadThemysql("select max(replace(nolabrujukan,'LR','')) from masterlaboratoriumrujukan", DB_Poliklinik)
        If Dbmax.Rows.Count > 0 Then
            Dim Trow As DataRow = Dbmax.Rows(0)
            If Trow(0).ToString <> "" Then Tmax = CInt(Trow(0))
            Tmax = Tmax + 1

            'bisa digunakan jika no trans suda jauh sampai 999
            'If Tmax >= 1000 Then
            'txcompnol.Text = "C" & Tmax
            If Tmax >= 100 Then
                txcompnol.Text = "LR" & Tmax
            ElseIf Tmax >= 10 Then
                txcompnol.Text = "LR0" & Tmax
            ElseIf Tmax > 0 Then
                txcompnol.Text = "LR00" & Tmax
                'txcompnol.Text = "C000" & Tmax
            Else
                MsgBox("Setting No Company Error. Confirm IT")
            End If
        Else
            'txcompnol.Text = "C0001"
            txcompnol.Text = "LR001"
        End If
    End Sub

    Public Sub SetClear()
        CheckBoxUpload.Checked = False
        txcompid.ResetText()
        txalamat.ResetText()
        txuplab.ResetText()
        txcompnol.ResetText()
        SetNomorL()
        txcompanycode.ResetText()
        txcompanycode.Enabled = True
        dtcompanystart.Value = DateSerial(Now.Year, "01", "01")
        dtcompanyend.Value = DateSerial("9998", "12", "31")
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        SetClear()
        Download()
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub masterlaboratoriumrujukan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        SetConn()
        NewToolStripMenuItem.PerformClick()
    End Sub

    Public Sub LoadMasterComp(ByRef Trow As DataRowView)
        txcompid.Text = Trow("idlabrujukan")
        txcompanycode.Text = Trow("namalabrujukan")
        txcompanycode.Enabled = False
        txalamat.Text = Trow("alamatlabrujukan")
        txuplab.Text = Trow("uplabrujukan")
        dtcompanystart.Value = Trow("StartDate")
        dtcompanyend.Value = Trow("EndDate")
        txcompnol.Text = Trow("nolabrujukan")
    End Sub

    Function Checking() As Boolean
        txcompanycode.Text = Strings.Replace(Strings.Replace(Strings.Replace(txcompanycode.Text, "'", ""), """", ""), "`", "")
        txalamat.Text = Strings.Replace(Strings.Replace(Strings.Replace(txalamat.Text, "'", ""), """", ""), "`", "")
        txuplab.Text = Strings.Replace(Strings.Replace(Strings.Replace(txuplab.Text, "'", ""), """", ""), "`", "")

        Dim companycode As String = txcompanycode.Text

        If companycode.Contains("-") = True Then
            MsgBox("Kode & Keterangan Perusahaan tidak boleh terkandung simbol -", MsgBoxStyle.Information, "Information")
            Return False
        ElseIf companycode = "" Then
            MsgBox("Kode & Keterangan Perusahaan tidak boleh kosong.", MsgBoxStyle.Information, "Information")
            Return False
        End If

        If txcompid.Text = "" Then
            If CheckSQL("select * from masterlaboratoriumrujukan where namalabrujukan='" & txcompanycode.Text & "' and '" & Format(dtcompanystart.Value, "MM/dd/yyyy") & "' between StartDate and EndDate") = True Then
                MsgBox("Masih ada Paket yang berjalan dengan nama tersebut.")
                Return False
            End If
        ElseIf txcompid.Text <> "" Then
            If MsgBox("Yakin mengupdate Lab Rujukan ini ?", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then
                MsgBox("Batal Updated")
                Return False
            End If
        End If

        If dtcompanystart.Value > dtcompanyend.Value Then
            MsgBox("Tanggal start tidak boleh lebih kecil dari tanggal akhir")
            Return False
        End If

        If txcompid.Text = "" Then
            If CheckThemysql("select * from masterlaboratoriumrujukan where namalabrujukan='" & txcompanycode.Text & "' or nolabrujukan='" & txcompnol.Text & "'", DB_Poliklinik) = True Then
                MsgBox("Telah ada nama Lab tersebut. Update yang ada.", MsgBoxStyle.Exclamation, "Warning!")
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        If Checking() = True Then
            Dim rduploadonline As Boolean = False
            If CheckBoxUpload.Checked = True Then rduploadonline = True

            If txcompid.Text = "" Then
                'new 
                WriteThemysql("insert into masterlaboratoriumrujukan(namalabrujukan,alamatlabrujukan,uplabrujukan,startdate,enddate,createdate,createby,nolabrujukan,uploadonline) values(" & _
                         "'" & txcompanycode.Text & "','" & txalamat.Text & "','" & txuplab.Text & "','" & Format(dtcompanystart.Value, "yyyyMMdd") & "','" & Format(dtcompanyend.Value, "yyyyMMdd") & "',now(),'" & PoliKlinik.Lbluser.Text & "','" & txcompnol.Text & "', " & rduploadonline & ")", DB_Poliklinik)
                NewToolStripMenuItem.PerformClick()
            Else
                'update data 
                WriteThemysql("update masterlaboratoriumrujukan set namalabrujukan='" & txcompanycode.Text & "' , alamatlabrujukan='" & txalamat.Text & "' , uplabrujukan='" & txuplab.Text & "' ,startdate='" & Format(dtcompanystart.Value, "yyyyMMdd") & "',enddate='" & Format(dtcompanyend.Value, "yyyyMMdd") & "', uploadonline=" & rduploadonline & " where nolabrujukan='" & txcompnol.Text & "'", DB_Poliklinik)
                Download()
            End If
        End If
    End Sub

    Private Sub buttransdisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttransdisplay.Click
        NewToolStripMenuItem.PerformClick()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SaveToolStripMenuItem.PerformClick()
    End Sub

    Private Sub butfindcomp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butfindcomp.Click
        Find.Show()
        Find.QueryTheMysql("select * from masterlaboratoriumrujukan ", " order by startdate,idlabrujukan ", "LabRujukanIDFind", 2, Find_Poliklinik)
    End Sub

    Private Sub txcompanyket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If txcompid.Text <> "" Then
            MsgBox("Hubungi IT Jika Ada Perubahan Keterangan Company.")
        End If
    End Sub
End Class