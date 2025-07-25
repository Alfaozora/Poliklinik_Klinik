Public Class MonitorProcessOnline
    Private Find_Poliklinik As Find.TLconnect
    Private DB_Poliklinik As TLcon

    Dim thread As System.Threading.Thread

    Private Sub SetClear()
        dtprocess.Value = DateAndTime.Now
        If txkodecabang.Text.Trim <> "" Then
            GridDisplay()
        End If
    End Sub

    Private Sub GridDisplay()
        Dim TDetailPemeriksaan As DataTable = New DataTable
        Dim DetailPemeriksaan As String = ""
        Dim TtempDetailPemeriksaan As String = ""

        Dim Trow As DataTable = ReadThemysql("SELECT CASE WHEN a.Status='OPEN' THEN CASE  " & _
                                        " WHEN a.LabDaftar = NULL THEN 'To Cashier Lab' ELSE 'Go To Sampling' END  " & _
                                        " WHEN a.Status='SAMPLE' THEN CASE  " & _
                                        " WHEN a.LabSamplingTime = NULL THEN 'Go To Sampling' ELSE 'Go To StartProcess' END  " & _
                                        " WHEN a.Status='CHECK' THEN CASE  " & _
                                        " WHEN a.LabStartTime = NULL THEN 'Go To StartProcess' ELSE 'Input Hasil, ACC1' END  " & _
                                        " WHEN a.Status='CETAK' THEN 'Hasil Bisa DiCetak' " & _
                                        " WHEN a.Status='TAKEIT' THEN 'Ke Pengiriman'  " & _
                                        " END AS 'NextProses', a.idlabinternet, a.TransLabID, a.DetailPemeriksaan, a.Status, a.NoUrut, b.Nama, deleted, TglLab, LabDaftar, LabSamplingTime, LabStartTime, TglInputHasil,  TglCetakHasil " & _
                                        " from transaksilab a left join masterpasien b ON a.idpasien=b.nomitra AND a.idtempatlab=b.cabang " & _
                                        " where a.`status` not in ('CLOSED') AND DATE(tgllab) = '" & Format(dtprocess.Value, "yyyy-MM-dd") & "' and cabang = '" & txkodecabang.Text.Trim & "' order by a.TglLab,a.TransLabID,a.NoUrut", DB_Poliklinik)

        Dim Ttemp As New DataTable
        insertRowToTbls(Ttemp, "Typstring", "LabID")
        insertRowToTbls(Ttemp, "Typstring", "NoUrut")
        insertRowToTbls(Ttemp, "Typstring", "Nama")
        insertRowToTbls(Ttemp, "Typstring", "TglLab")
        insertRowToTbls(Ttemp, "Typstring", "Pemeriksaan")
        insertRowToTbls(Ttemp, "Typstring", "Next Process")
        insertRowToTbls(Ttemp, "typchecked", "Daftar")
        insertRowToTbls(Ttemp, "typchecked", "Sampling")
        insertRowToTbls(Ttemp, "typchecked", "On Progress")
        insertRowToTbls(Ttemp, "typchecked", "Hasil Done")
        insertRowToTbls(Ttemp, "typchecked", "Cetak")

        For i As Integer = 0 To Trow.Rows.Count - 1
            Dim Rnew As DataRow = Ttemp.NewRow
            Rnew("LabID") = Trow(i)("TransLabID")
            Rnew("NoUrut") = Trow(i)("NoUrut")
            Rnew("Nama") = Trow(i)("Nama")
            Rnew("TglLab") = Format(Trow(i)("TglLab"), "dd-MMM-yyyy")

            'If Trow(i)("deleted") <> True Then
            If IsDBNull(Trow(i)("DetailPemeriksaan")) = True Then
                Rnew("Pemeriksaan") = SetTindakanDetailOnline(Trow(i)("idlabinternet"))
            ElseIf IsDBNull(Trow(i)("DetailPemeriksaan")) = False Then
                Rnew("Pemeriksaan") = Trow(i)("DetailPemeriksaan")
            End If

            If IsDBNull(Trow(i)("LabDaftar")) = False And Trow(i)("LabDaftar") <> "1900-01-01 00:00:00" Then Rnew("Daftar") = True Else Rnew("Daftar") = False
            If IsDBNull(Trow(i)("LabSamplingTime")) = False And Trow(i)("LabSamplingTime") <> "1900-01-01 00:00:00" Then Rnew("Sampling") = True Else Rnew("Sampling") = False
            If IsDBNull(Trow(i)("LabStartTime")) = False And Trow(i)("LabStartTime") <> "1900-01-01 00:00:00" Then Rnew("On Progress") = True Else Rnew("On Progress") = False
            If IsDBNull(Trow(i)("TglInputHasil")) = False And Trow(i)("TglInputHasil") <> "1900-01-01 00:00:00" Then Rnew("Hasil Done") = True Else Rnew("Hasil Done") = False
            If IsDBNull(Trow(i)("TglCetakHasil")) = False And Trow(i)("TglCetakHasil") <> "1900-01-01 00:00:00" Then Rnew("Cetak") = True Else Rnew("Cetak") = False

            Rnew("Next Process") = Trow(i)("NextProses").ToString.Trim
            'Else
            'Rnew("Next Process") = "Data Cancel."
            'End If
            Ttemp.Rows.Add(Rnew)
        Next

        For Each Tcols As DataColumn In Ttemp.Columns
            Tcols.ReadOnly = True
        Next

        GridControl1.DataSource = Ttemp
        GridView1.Columns("LabID").Visible = False
    End Sub

    Function SetTindakanDetailOnline(ByVal translabid As String) As String
        Dim TDetailPemeriksaan As DataTable = New DataTable
        Dim DetailPemeriksaan As String = ""
        Dim TtempDetailPemeriksaan As String = ""

        TDetailPemeriksaan = ReadThemysql("select b.NamaTindakan from transaksilab a left join transaksilabdetail b ON a.translabid=b.translabid AND a.idlabinternet=b.idlabinternet WHERE a.idlabinternet = '" & translabid & "'", DB_Poliklinik)
        For Each TRowDetailPemeriksaan As DataRow In TDetailPemeriksaan.Rows
            TtempDetailPemeriksaan = TtempDetailPemeriksaan & "" & TRowDetailPemeriksaan("NamaTindakan").ToString.Trim & ", "
        Next
        DetailPemeriksaan = Strings.Left(TtempDetailPemeriksaan, TtempDetailPemeriksaan.Length - 2)

        Return DetailPemeriksaan
    End Function

    Private Sub SetConnection()
        ' Set Parameter Server Online
        Dim serverOnline_IP As String = Utility.GetConfig("ServerOnline_IP")
        Dim serverOnline_UserID As String = Utility.GetConfig("ServerOnline_UserID")
        Dim serverOnline_Password As String = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerOnline_Password"), "albert")

        ' Set DB Poliklinik
        DB_Poliklinik.Tip = serverOnline_IP
        DB_Poliklinik.Tid = serverOnline_UserID
        DB_Poliklinik.Tpass = serverOnline_Password
        DB_Poliklinik.Tdb = Utility.GetConfig("ServerOnlinePoli_DB")

        ' Set Find Poliklinik
        Find_Poliklinik.Tip = serverOnline_IP
        Find_Poliklinik.Tid = serverOnline_UserID
        Find_Poliklinik.Tpass = serverOnline_Password
        Find_Poliklinik.Tdb = Utility.GetConfig("ServerOnlinePoli_DB")
    End Sub

    Private Sub MonitorProcessOnline_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetConnection()
        Control.CheckForIllegalCrossThreadCalls = False
        Me.MdiParent = PoliKlinik
        SetClear()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        GridDisplay()
    End Sub

    Private Sub butfindcompany_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butfindcompany.Click
        Find.Show()
        Find.QueryTheMysql("SELECT a.kodecabang, a.kodeket FROM mastercodebarcode a", " ", "FindCabangMonitorProses", 0, Find_Poliklinik)
    End Sub
End Class