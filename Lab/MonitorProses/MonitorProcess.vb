Public Class MonitorProcess

    Dim Ttcmh As New TLcon
    Dim thread As System.Threading.Thread

    Private Sub SetClear()
        dtprocess.Value = DateAndTime.Now
        GridDisplay(True)
        Panelload.Visible = False
        lblload.Visible = False
        ProgressBar1.Visible = False
        txprocent.Visible = False
    End Sub

    Private Sub GridDisplay(ByVal setwidth As Boolean)
        Dim Thasilawal As Date = dtprocess.Value
        Dim Tawal As Date = DateSerial(Thasilawal.Year, Thasilawal.Month, Thasilawal.Day)

        Dim TDetailPemeriksaan As DataTable = New DataTable
        Dim DetailPemeriksaan As String = ""
        Dim TtempDetailPemeriksaan As String = ""

        Dim Trow As DataTable = ReadSQL("SELECT CASE WHEN a.Status='OPEN' THEN CASE  " & _
                                        " WHEN a.LabDaftar is NULL THEN 'To Cashier Lab' ELSE 'Go To Sampling' END  " & _
                                        " WHEN a.Status='SAMPLE' THEN CASE  " & _
                                        " WHEN a.LabSamplingTime is NULL THEN 'Go To Sampling' ELSE 'Go To StartProcess' END  " & _
                                        " WHEN a.Status='CHECK' THEN CASE  " & _
                                        " WHEN a.LabStartTime is NULL THEN 'Go To StartProcess' ELSE 'Input Hasil, ACC1' END  " & _
                                        " WHEN a.Status='CETAK' THEN 'Hasil Bisa DiCetak' " & _
                                        " WHEN a.Status='TAKEIT' THEN 'Ke Pengiriman'  " & _
                                        " END AS 'NextProses', a.RujukanID, a.CreateBy, a.TransLabID, a.DetailPemeriksaan, a.Status, a.NoUrut, b.Nama, b.TglLahir, b.DomisiliAlamat, a.IDInternet, a.CaraAmbil, a.SendKeu, StatusSoftcopy, StatusHardcopy, deleted, TglLab, LabDaftar, LabSamplingTime, LabStartTime, TglInputHasil,  TglCetakHasil " & _
                                        " FROM TransaksiLab a " & _
                                        " LEFT JOIN MasterPasien b on a.IDInternet = b.NoRekamMedis " & _
                                        " WHERE [Status] not in ('CLOSED') AND CONVERT(date, Tgllab) = '" & Tawal & "' order by a.TglLab,a.TransLabID,a.NoUrut")

        Dim Ttemp As New DataTable
        insertRowToTbls(Ttemp, "Typstring", "LabID")
        insertRowToTbls(Ttemp, "Typstring", "NoUrut")
        insertRowToTbls(Ttemp, "Typstring", "Nama")
        insertRowToTbls(Ttemp, "Typstring", "IDPasien")
        insertRowToTbls(Ttemp, "Typstring", "TglLab")
        insertRowToTbls(Ttemp, "Typstring", "Pemeriksaan")
        insertRowToTbls(Ttemp, "Typstring", "Admin")
        insertRowToTbls(Ttemp, "Typstring", "Next Process")
        insertRowToTbls(Ttemp, "Typstring", "Daftar")
        insertRowToTbls(Ttemp, "Typstring", "Sampling")
        insertRowToTbls(Ttemp, "Typstring", "On Progress")
        insertRowToTbls(Ttemp, "Typstring", "Hasil Done")
        insertRowToTbls(Ttemp, "Typstring", "Cetak")

        'Online
        insertRowToTbls(Ttemp, "Typstring", "CompanyUmum")
        insertRowToTbls(Ttemp, "Typstring", "CompanyPT")
        insertRowToTbls(Ttemp, "Typstring", "CaraAmbil")
        insertRowToTbls(Ttemp, "typdate", "TglLahir")
        insertRowToTbls(Ttemp, "Typstring", "deleted")
        insertRowToTbls(Ttemp, "Typstring", "Alamat")
        insertRowToTbls(Ttemp, "Typstring", "SendKeu")
        insertRowToTbls(Ttemp, "Typstring", "StatusSoftcopy")
        insertRowToTbls(Ttemp, "Typstring", "StatusHardcopy")
        insertRowToTbls(Ttemp, "Typstring", "TglLabOnline")
        insertRowToTbls(Ttemp, "Typstring", "LabDaftar")
        insertRowToTbls(Ttemp, "Typstring", "LabSamplingTime")
        insertRowToTbls(Ttemp, "Typstring", "LabStartTime")
        insertRowToTbls(Ttemp, "Typstring", "TglInputHasil")
        insertRowToTbls(Ttemp, "Typstring", "TglCetakHasil")

        For i As Integer = 0 To Trow.Rows.Count - 1
            Dim Rnew As DataRow = Ttemp.NewRow
            Rnew("LabID") = Trow(i)("TransLabID")
            Rnew("NoUrut") = Trow(i)("NoUrut")
            Rnew("Nama") = Trow(i)("Nama")
            Rnew("Admin") = Trow(i)("CreateBy")
            Rnew("IDPasien") = Trow(i)("IDInternet")
            Rnew("TglLab") = Format(Trow(i)("TglLab"), "dd-MMM-yyyy")
            Rnew("deleted") = Trow(i)("deleted")

            If Trow(i)("deleted") <> True Then
                'Online
                Rnew("CaraAmbil") = Trow(i)("CaraAmbil")
                Rnew("TglLahir") = Trow(i)("TglLahir")
                Rnew("Alamat") = Trow(i)("DomisiliAlamat")
                Rnew("StatusSoftcopy") = Trow(i)("StatusSoftcopy")
                Rnew("StatusHardcopy") = Trow(i)("StatusHardcopy")
                If IsDBNull(Trow(i)("SendKeu")) = False Then Rnew("SendKeu") = "1" Else Rnew("SendKeu") = 0
                Rnew("TglLabOnline") = Format(Trow(i)("TglLab"), "yyyy-MM-dd HH:mm:ss")
                If IsDBNull(Trow(i)("LabDaftar")) = False Then Rnew("LabDaftar") = Format(Trow(i)("LabDaftar"), "yyyy-MM-dd HH:mm:ss") Else Rnew("LabDaftar") = "NULL"
                If IsDBNull(Trow(i)("LabSamplingTime")) = False Then Rnew("LabSamplingTime") = Format(Trow(i)("LabSamplingTime"), "yyyy-MM-dd HH:mm:ss") Else Rnew("LabSamplingTime") = "NULL"
                If IsDBNull(Trow(i)("LabStartTime")) = False Then Rnew("LabStartTime") = Format(Trow(i)("LabStartTime"), "yyyy-MM-dd HH:mm:ss") Else Rnew("LabStartTime") = "NULL"
                If IsDBNull(Trow(i)("TglInputHasil")) = False Then Rnew("TglInputHasil") = Format(Trow(i)("TglInputHasil"), "yyyy-MM-dd HH:mm:ss") Else Rnew("TglInputHasil") = "NULL"
                If IsDBNull(Trow(i)("TglCetakHasil")) = False Then Rnew("TglCetakHasil") = Format(Trow(i)("TglCetakHasil"), "yyyy-MM-dd HH:mm:ss") Else Rnew("TglCetakHasil") = "NULL"

                If IsDBNull(Trow(i)("DetailPemeriksaan")) = True Then
                    Rnew("Pemeriksaan") = SetTindakanDetail(Trow(i)("TransLabID"), "LAB", "1")
                ElseIf IsDBNull(Trow(i)("DetailPemeriksaan")) = False Then
                    Rnew("Pemeriksaan") = Trow(i)("DetailPemeriksaan")
                End If

                'If IsDBNull(Trow(i)("LabDaftar")) = False Then Rnew("Daftar") = Format(Trow(i)("LabDaftar"), "yyyy-MM-dd") & " " & vbCr & vbLf & Format(Trow(i)("LabDaftar"), "HH:mm:ss") Else Rnew("Daftar") = "-"
                If IsDBNull(Trow(i)("LabDaftar")) = False Then Rnew("Daftar") = Format(Trow(i)("LabDaftar"), "yyyy-MM-dd HH:mm:ss") Else Rnew("Daftar") = "-"
                If IsDBNull(Trow(i)("LabSamplingTime")) = False Then Rnew("Sampling") = Format(Trow(i)("LabSamplingTime"), "yyyy-MM-dd HH:mm:ss") Else Rnew("Sampling") = "-"
                If IsDBNull(Trow(i)("LabStartTime")) = False Then Rnew("On Progress") = Format(Trow(i)("LabStartTime"), "yyyy-MM-dd HH:mm:ss") Else Rnew("On Progress") = "-"
                If IsDBNull(Trow(i)("TglInputHasil")) = False Then Rnew("Hasil Done") = Format(Trow(i)("TglInputHasil"), "yyyy-MM-dd HH:mm:ss") Else Rnew("Hasil Done") = "-"
                If IsDBNull(Trow(i)("TglCetakHasil")) = False Then Rnew("Cetak") = Format(Trow(i)("TglCetakHasil"), "yyyy-MM-dd HH:mm:ss") Else Rnew("Cetak") = "-"

                If IsDBNull(Trow(i)("RujukanID")) = False Then
                    Dim LabRujukan As String = ReadSQLNIK("select NamaLabRujukan FROM MasterLaboratoriumRujukan WHERE NoLabRujukan in (select NoLabRujukan FROM TransaksiRujukanLab WHERE IDSuratRujukan=" & Trow(i)("RujukanID") & ")")
                    Rnew("Next Process") = "Rujukan Ke " & LabRujukan
                ElseIf IsDBNull(Trow(i)("RujukanID")) = True Then
                    Rnew("Next Process") = Trow(i)("NextProses").ToString.Trim
                End If
            Else
                Rnew("Next Process") = "Data Cancel."
            End If
            Ttemp.Rows.Add(Rnew)
        Next

        For Each Tcols As DataColumn In Ttemp.Columns
            Tcols.ReadOnly = True
        Next

        Ttemp.Columns("TglLabOnline").ReadOnly = False
        Ttemp.Columns("LabDaftar").ReadOnly = False
        Ttemp.Columns("LabSamplingTime").ReadOnly = False
        Ttemp.Columns("LabStartTime").ReadOnly = False
        Ttemp.Columns("TglInputHasil").ReadOnly = False
        Ttemp.Columns("TglCetakHasil").ReadOnly = False

        GridControl1.DataSource = Ttemp
        GridView1.Columns("LabID").Visible = False

        'Online
        GridView1.Columns("CompanyUmum").Visible = False
        GridView1.Columns("CompanyPT").Visible = False
        GridView1.Columns("CaraAmbil").Visible = False
        GridView1.Columns("TglLahir").Visible = False
        GridView1.Columns("Alamat").Visible = False
        GridView1.Columns("deleted").Visible = False
        GridView1.Columns("StatusSoftcopy").Visible = False
        GridView1.Columns("StatusHardcopy").Visible = False
        GridView1.Columns("SendKeu").Visible = False
        GridView1.Columns("TglLabOnline").Visible = False
        GridView1.Columns("LabDaftar").Visible = False
        GridView1.Columns("LabSamplingTime").Visible = False
        GridView1.Columns("LabStartTime").Visible = False
        GridView1.Columns("TglInputHasil").Visible = False
        GridView1.Columns("TglCetakHasil").Visible = False
        GridView1.Columns("IDPasien").Visible = False
        GridView1.Columns("TglLab").Visible = False

        If setwidth = True Then
            GridView1.Columns("Admin").Width = 50
            GridView1.Columns("Next Process").Width = 60
            GridView1.Columns("Daftar").Width = 75
            GridView1.Columns("Sampling").Width = 75
            GridView1.Columns("On Progress").Width = 75
            GridView1.Columns("Hasil Done").Width = 75
            GridView1.Columns("Cetak").Width = 75
            GridView1.Columns("NoUrut").Width = 100
            'GridView1.RowHeight = 50
            'GridView1.RowSeparatorHeight = 5
            'GridView1.Columns("Daftar").Resize(120)
        End If
    End Sub

    Private Sub SetConnection()
        Ttcmh.Tid = "root"
        Ttcmh.Tip = ReadSQLNIK("select StrValue from MsConfig where ConfigName='Twebid'")
        Ttcmh.Tdb = "db_tracking"
        Ttcmh.Tpass = Strings.Replace(ReadSQLNIK("select StrValue from MsConfig where ConfigName='Twebpass'"), "|", "")
    End Sub

    Private Sub MonitorProcess_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        SetFormHeightWeight(Me, 0.95, 0.8)
        'Control.CheckForIllegalCrossThreadCalls = False
        SetClear()
        SetConnection()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        GridDisplay(False)
    End Sub

    Private Sub butsinkron_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butsinkron.Click
        Panelload.Visible = True
        lblload.Visible = True
        ProgressBar1.Visible = True
        txprocent.Visible = True
        thread = New System.Threading.Thread(AddressOf synchronization)
        thread.Start()
    End Sub

    Private Sub synchronization()
        Try
            Dim persen As Integer = 0
            Dim Tloc As String = ReadSQLNIK("select StrValue  FROM MsConfig WHERE ConfigName='NoPoli'")
            Dim Tcompany As String = ""
            Dim Tbls As DataTable = GridControl1.DataSource
            Dim TTable As DataTable = New DataTable
            Dim TglLab As String = "", LabDaftar As String = "", LabSamplingTime As String = "", LabStartTime As String = "", TglInputHasil As String = "", TglCetakHasil As String = ""
            Dim JumlahTransaksi As Integer = 0
            Dim TempNourut As String = ""

            If Tbls.Rows.Count > 0 Then
                For Each Trow As DataRow In Tbls.Rows
                    If Trow("deleted") <> False Then
                        TempNourut = TempNourut & "'" & Trow("NoUrut").ToString.Trim & "', "
                    Else
                        persen = persen + 1

                        If IsDBNull(Trow("TglLabOnline")) = False Then Trow("TglLabOnline") = "" & Trow("TglLabOnline") & "" Else Trow("TglLabOnline") = DBNull.Value
                        If IsDBNull(Trow("LabDaftar")) = False Then Trow("LabDaftar") = "" & Trow("LabDaftar") & "" Else Trow("LabDaftar") = DBNull.Value
                        If IsDBNull(Trow("LabSamplingTime")) = False Then Trow("LabSamplingTime") = "" & Trow("LabSamplingTime") & "" Else Trow("LabSamplingTime") = DBNull.Value
                        If IsDBNull(Trow("LabStartTime")) = False Then Trow("LabStartTime") = "" & Trow("LabStartTime") & "" Else Trow("LabStartTime") = DBNull.Value
                        If IsDBNull(Trow("TglInputHasil")) = False Then Trow("TglInputHasil") = "" & Trow("TglInputHasil") & "" Else Trow("TglInputHasil") = DBNull.Value
                        If IsDBNull(Trow("TglCetakHasil")) = False Then Trow("TglCetakHasil") = "" & Trow("TglCetakHasil") & "" Else Trow("TglCetakHasil") = DBNull.Value

                        If Trow("NoUrut").ToString.Contains("M") = True And IsDBNull(Trow("LabSamplingTime")) = False Then
                            Trow("TglLabOnline") = Trow("LabSamplingTime")
                            Trow("LabDaftar") = Trow("LabSamplingTime")
                            Trow("LabStartTime") = Trow("LabSamplingTime")
                        End If

                        'SET NULL
                        'If Trow("TglLabOnline") = "'NULL'" Then Trow("TglLabOnline") = Replace(Trow("TglLabOnline"), "'", "")
                        'If Trow("LabDaftar") = "'NULL'" Then Trow("LabDaftar") = Replace(Trow("LabDaftar"), "'", "")
                        'If Trow("LabSamplingTime") = "'NULL'" Then Trow("LabSamplingTime") = Replace(Trow("LabSamplingTime"), "'", "")
                        'If Trow("LabStartTime") = "'NULL'" Then Trow("LabStartTime") = Replace(Trow("LabStartTime"), "'", "")
                        'If Trow("TglInputHasil") = "'NULL'" Then Trow("TglInputHasil") = Replace(Trow("TglInputHasil"), "'", "")
                        'If Trow("TglCetakHasil") = "'NULL'" Then Trow("TglCetakHasil") = Replace(Trow("TglCetakHasil"), "'", "")

                        TTable = ReadSQL("SELECT CASE WHEN d.JenisBayar = 'TAGIHAN' THEN d.NoJenisBayar WHEN d.JenisBayar <> 'TAGIHAN' THEN 'PASIEN UMUM' ELSE 'NOT FOUND' END AS 'NamaCompany' FROM TransaksiLab a LEFT JOIN TransaksiLabBayar d on a.TransLabID=d.TransLabID WHERE a.NoUrut = '" & Trow("NoUrut") & "'")
                        Dim TrowCompany As DataRow = TTable.Rows(0)

                        If TrowCompany("NamaCompany").ToString.Contains("-") Then
                            Tcompany = TrowCompany("NamaCompany").ToString
                            Dim Tsplit() As String = Tcompany.Split("-")
                            Tcompany = Tsplit(0).ToString.Trim.ToUpper
                        Else
                            Tcompany = TrowCompany("NamaCompany").ToString.ToUpper
                        End If

                        WriteThemysql("REPLACE INTO rekammedis (translabid, cabang, nourut, nama, tgllahir, alamat, company, idpasien, caraambil, statussoftcopy, statushardcopy, deleted, tgllab, labdaftar, labsamplingtime, labstarttime, tglinputhasil, tglcetakhasil, updated, tindakan)  " & _
                                      "VALUES('" & Trow("LabID") & "', '" & Tloc & "','" & Trow("NoUrut") & "','" & Trow("Nama") & "','" & Format(Trow("TglLahir"), "yyyy-MM-dd") & "','" & Trow("Alamat") & "', '" & Tcompany & "','" & Trow("IDPasien") & "','" & Trow("CaraAmbil") & "'," & Trow("StatusSoftcopy") & "," & Trow("StatusHardcopy") & "," & Trow("deleted") & ",  " & _
                                      "'" & Trow("TglLabOnline") & "','" & Trow("LabDaftar") & "','" & Trow("LabSamplingTime") & "','" & Trow("LabStartTime") & "','" & Trow("TglInputHasil") & "','" & Trow("TglCetakHasil") & "',0, '" & Trow("Pemeriksaan") & "') ", Ttcmh)

                        JumlahTransaksi = JumlahTransaksi + 1
                        Dim procent As Integer = persen * 100 / Tbls.Rows.Count
                        txprocent.Text = procent & " %"
                        ProgressBar1.Value = procent
                    End If
                Next
                MsgBox("" & JumlahTransaksi & " Transaksi Telah di Sinkronasi.", MsgBoxStyle.Information, "Success!")
            Else
                MsgBox("Tidak Ada Data yang di Sinkronasi.", MsgBoxStyle.Critical, "Nothing!")
            End If

            If TempNourut.Trim <> "" Then
                TempNourut = Strings.Left(TempNourut, TempNourut.Length - 2)
                WriteThemysql("DELETE FROM rekammedis WHERE nourut IN (" & TempNourut & ") AND cabang = '" & Tloc & "'", Ttcmh)
            End If

            Panelload.Visible = False
            lblload.Visible = False
            ProgressBar1.Visible = False
            txprocent.Visible = False
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class