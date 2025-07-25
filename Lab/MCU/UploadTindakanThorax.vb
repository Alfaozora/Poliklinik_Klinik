Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Drawing

Public Class UploadTindakanThorax
    Private Find_Poliklinik As Find.TLconnect
    Private DB_Poliklinik As TLcon

    Dim thread As System.Threading.Thread
    Dim conn As OleDbConnection
    Dim dtr As OleDbDataReader
    Dim dta As OleDbDataAdapter
    Dim cmd As OleDbCommand
    Dim dts As DataSet
    Dim excel As String
    Dim opFileDialog As New OpenFileDialog()
    Private userUploadMCU As String = PoliKlinik.Lbluser.Text

    Private Sub SetConn()
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

    Private Sub updateevent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttambahpasien.Click
        Try
            If txidloc.Text = "" Then
                MsgBox("Pilih Lokasi Terlebih Dahulu.", MsgBoxStyle.Exclamation, "Warning!")
                Exit Sub
            End If

            opFileDialog.Filter = "Excel Files 2003|*.xls|Excel Files|*.xlsx"
            opFileDialog.Title = "Select a Excel File"

            If opFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Dim fi As New FileInfo(opFileDialog.FileName)
                Dim FileName As String = opFileDialog.FileName

                excel = fi.FullName
                conn = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excel + ";Extended Properties=Excel 12.0;")
                dta = New OleDbDataAdapter("Select * From [Sheet1$]", conn)
                dts = New DataSet("NewTables")
                dta.Fill(dts)
                gridthorax.DataSource = dts.Tables(0)
                conn.Close()
            End If

            butsavemultiple.Enabled = False
            butsavelab.Enabled = True
        Catch ex As Exception
            conn.Close()
            MsgBox(ex.ToString)
        End Try
    End Sub

    Function CheckTransaksiOffline(ByRef Temp As DataTable) As Boolean
        Dim DetailNourut As String = ""
        Dim TtempNourut As String = ""
        For Each Trow As DataRow In Temp.Rows
            TtempNourut = TtempNourut & "'" & Trow("NoUrut").ToString.Trim & "', "
        Next
        DetailNourut = Strings.Left(TtempNourut, TtempNourut.Length - 2)

        Dim Tempthorax As DataTable = ReadSQL("SELECT * FROM TransaksiLab WHERE NoUrut IN (" & DetailNourut & ") AND DetailPemeriksaan NOT LIKE '%THORAX%'")

        'Cek Pemeriksaan Thorax Setiap Transaksi
        If Tempthorax.Rows.Count > 0 Then
            MsgBox("Terdapat Transaksi yang tidak ada pemeriksaan Thorax.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        'Cek Transaksi yang tidak ada dalam database
        Dim CountTransaksi As String = ReadSQLNIK("SELECT COUNT(NoUrut) as JumlahTransaksi FROM TransaksiLab WHERE NoUrut IN (" & DetailNourut & ")")
        If CountTransaksi <> Temp.Rows.Count Then
            MsgBox("Terdapat Transaksi yang tidak ada didalam Database, cek kembali nourut transaksi.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        Return True
    End Function

    Function CheckTransaksiOnline(ByRef Temp As DataTable) As Boolean
        Dim DetailNourut As String = ""
        Dim TtempNourut As String = ""
        For Each Trow As DataRow In Temp.Rows
            TtempNourut = TtempNourut & "'" & Trow("NoUrut").ToString.Trim & "', "
        Next
        DetailNourut = Strings.Left(TtempNourut, TtempNourut.Length - 2)

        Dim Tempthorax As DataTable = ReadThemysql("SELECT * FROM transaksilab a WHERE a.nourut IN (" & DetailNourut & ") AND a.DetailPemeriksaan NOT LIKE '%THORAX%' AND a.idtempatlab = '" & txidloc.Text.Trim & "'", DB_Poliklinik)

        'Cek Pemeriksaan Thorax Setiap Transaksi
        If Tempthorax.Rows.Count > 0 Then
            MsgBox("Terdapat Transaksi yang tidak ada pemeriksaan Thorax.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        'Cek Transaksi yang tidak ada dalam database
        Dim CountTransaksi As String = ReadThemysqlNIK("SELECT COUNT(a.nourut) as JumlahTransaksi FROM transaksilab a WHERE a.nourut IN (" & DetailNourut & ") AND a.idtempatlab = '" & txidloc.Text.Trim & "'", DB_Poliklinik)
        If CountTransaksi <> Temp.Rows.Count Then
            MsgBox("Terdapat Transaksi yang tidak ada didalam Database, cek kembali nourut transaksi.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        Return True
    End Function

    Private Sub SetGrid()
        gridthorax.DataSource = Nothing

        ProgressBar1.Value = 0
        ProgressBar1.Visible = False
        butsavemultiple.Enabled = False
        rdOnline.Checked = True
        InsertNewItemComboSQL("select StrValue from MsConfig where ConfigName like '%thorax%'", drthorax)
        drthorax.ResetText()
        cmbstatustransaksi.SelectedIndex = 0
    End Sub

    Private Sub UploadTindakanThorax_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Windows.Forms.Control.CheckForIllegalCrossThreadCalls = False
        Me.MdiParent = PoliKlinik
        Me.BringToFront()
        SetConn()
        SetGrid()
        Dim y As Integer = Screen.PrimaryScreen.Bounds.Height * 0.025
        Dim x As Integer = Screen.PrimaryScreen.Bounds.Width * 0.025
        Me.Location = New Point(x, y)
        Me.Height = Screen.PrimaryScreen.Bounds.Height * 0.8
        Me.Width = Screen.PrimaryScreen.Bounds.Width * 0.95
    End Sub

    Private Sub butsavelab_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butsavelab.Click
        If drthorax.FindStringExact(drthorax.Text) < 0 Then
            MsgBox("Pilih dokter yang memeriksa")
            drthorax.Focus()
        Else
            thread = New System.Threading.Thread(AddressOf SaveUpload)
            thread.Start()
        End If
    End Sub

    Private Sub SaveUpload()
        Dim Tbls As DataTable = gridthorax.DataSource
        Dim saved As Integer = 1

        Try
            If Tbls.Rows.Count > 0 Then
                butsavelab.Enabled = False
                ProgressBar1.Visible = True
                Dim persen As Integer = 0
                Dim jumlah As Integer = 0
                Dim CompareJenis As Boolean = False

                'Set Thorax
                Dim Tempthorax As DataTable = ReadSQL("SELECT ValueThorax, Cor, Pulmo, Sinus, Skeletal, StatusKesehatanThorax FROM MasterNilaiHasilThorax ORDER BY ID DESC")

                For Each Trow As DataRow In Tbls.Rows
                    persen = persen + 1

                    If IsDBNull(Trow("NoUrut")) = True Or Trow("NoUrut").ToString.Trim = "-" Then
                        MsgBox("No Urut tidak boleh ada yang kosong.", MsgBoxStyle.Exclamation, "Warning!")
                        saved = 0
                        Exit For
                    End If

                    If IsDBNull(Trow("Hasil")) = True Or Trow("Hasil").ToString.Trim = "-" Then
                        MsgBox("Hasil tidak boleh ada yang kosong.", MsgBoxStyle.Exclamation, "Warning!")
                        saved = 0
                        Exit For
                    End If

                    CompareJenis = False
                    For Each TrowThorax As DataRow In Tempthorax.Rows
                        If TrowThorax("ValueThorax") = Trow("Hasil") Then
                            CompareJenis = True

                            'Set tabel
                            Trow("Cor") = TrowThorax("Cor")
                            Trow("Pulmo") = TrowThorax("Pulmo")
                            Trow("Sinus") = TrowThorax("Sinus")
                            Trow("Skeletal") = TrowThorax("Skeletal")
                            Trow("StatusKesehatan") = TrowThorax("StatusKesehatanThorax")
                        End If
                    Next

                    If CompareJenis = False Then
                        MsgBox("Hasil " & Trow("Hasil") & " tidak ada dalam master.", MsgBoxStyle.Exclamation, "Warning!")
                        saved = 0
                        Exit For
                    End If

                    Dim procent As Integer = persen * 100 / Tbls.Rows.Count
                    ProgressBar1.Value = procent
                Next

                If saved <> 0 Then
                    If rdOffline.Checked = True Then
                        If CheckTransaksiOffline(Tbls) = False Then saved = 0
                    ElseIf rdOnline.Checked = True Then
                        If CheckTransaksiOnline(Tbls) = False Then saved = 0
                    End If
                End If
            Else
                MsgBox("Tidak ada data yang di Upload.", MsgBoxStyle.Exclamation, "Warning!")
                saved = 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try

        If saved = 0 Then
            butsavemultiple.Enabled = False
            MsgBox("Data Gagal Upload.", MsgBoxStyle.Critical, "Failed")
        Else
            butsavemultiple.Enabled = True
            MsgBox(Tbls.Rows.Count & " data berhasil disimpan, klik tombol save multiple untuk melanjutkan.", MsgBoxStyle.Information, "Success!")
        End If

        ProgressBar1.Visible = False
    End Sub

    Private Sub butsavemultiple_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butsavemultiple.Click
        thread = New System.Threading.Thread(AddressOf SaveMultiple)
        thread.Start()
    End Sub

    Private Sub SaveMultiple()
        butsavemultiple.Enabled = False
        buttambahpasien.Enabled = False

        Dim procent As Integer = 0
        Dim persen As Integer = 0

        If MsgBox("Yakin proses lanjut ?", MsgBoxStyle.YesNo, "Verifikasi Akhir") = MsgBoxResult.Yes Then
            ProgressBar1.Visible = True

            Dim Ttemp As DataTable = gridthorax.DataSource
            Ttemp.AcceptChanges()

            For Each Tdata As DataRow In Ttemp.Rows
                persen = persen + 1
                procent = persen * 100 / Ttemp.Rows.Count
                ProgressBar1.Value = procent

                If rdOffline.Checked = True Then
                    If CheckSQL("select * from TransaksiLabHasilLain where [NoUrut]='" & Tdata("NoUrut") & "'") = True Then
                        WriteSQL("update TransaksiLabHasilLain set [StatusKesehatanThorax]='" & Tdata("StatusKesehatan") & "', [Cor]='" & Tdata("Cor") & "',[Pulmo]='" & Tdata("Pulmo") & "',[Sinus]='" & Tdata("Sinus") & "',[Skeletal]='" & Tdata("Skeletal") & "',[Kesimpulan]='" & Tdata("Hasil") & "',[ThoraxDate]='" & Format(DateAndTime.Now, "MM/dd/yyyy") & "',[ThoraxBy]='" & userUploadMCU & "',  drThorax='" & drthorax.Text & "' where NoUrut='" & Tdata("NoUrut") & "'", 4)
                    Else
                        WriteSQL("insert TransaksiLabHasilLain([NoUrut],[Cor],[Pulmo],[Sinus],[Skeletal],[Kesimpulan],[ThoraxDate],[ThoraxBy],[drThorax],[StatusKesehatanThorax]) values('" & Tdata("NoUrut") & "','" & Tdata("Cor") & "','" & Tdata("Pulmo") & "','" & Tdata("Sinus") & "','" & Tdata("Skeletal") & "','" & Tdata("Hasil") & "','" & Format(DateAndTime.Now, "MM/dd/yyyy") & "','" & userUploadMCU & "','" & drthorax.Text & "','" & Tdata("StatusKesehatan") & "')", 4)
                    End If
                ElseIf rdOnline.Checked = True Then
                    If CheckThemysql("SELECT * FROM transaksilabhasillain WHERE idlabinternet IN (SELECT idlabinternet FROM transaksilab WHERE NoUrut='" & Tdata("NoUrut") & "' AND idtempatlab = '" & txidloc.Text & "')", DB_Poliklinik) = True Then
                        WriteThemysql("update transaksilabhasillain set Cor='" & Tdata("Cor") & "',Pulmo='" & Tdata("Pulmo") & "',Sinus='" & Tdata("Sinus") & "',Skeletal='" & Tdata("Skeletal") & "',Kesimpulan='" & Tdata("Hasil") & "', statuskesehatanthorax='" & Tdata("StatusKesehatan") & "', ThoraxDate=NOW(),ThoraxBy='" & userUploadMCU & "' , drThorax='" & drthorax.Text & "' WHERE idlabinternet IN (SELECT idlabinternet FROM transaksilab WHERE NoUrut='" & Tdata("NoUrut") & "' AND idtempatlab = '" & txidloc.Text & "')", DB_Poliklinik)
                    Else
                        Dim idOnline As String = ReadThemysqlNIK("SELECT idlabinternet FROM transaksilab WHERE NoUrut='" & Tdata("NoUrut") & "' AND idtempatlab = '" & txidloc.Text & "'", DB_Poliklinik)
                        WriteThemysql("insert transaksilabhasillain(NoUrut,Cor,Pulmo,Sinus,Skeletal,Kesimpulan,ThoraxDate,ThoraxBy,idlabinternet,drThorax, statuskesehatanthorax) values('" & Tdata("NoUrut") & "','" & Tdata("Cor") & "','" & Tdata("Pulmo") & "','" & Tdata("Sinus") & "','" & Tdata("Skeletal") & "','" & Tdata("Hasil") & "',NOW(),'" & userUploadMCU & "','" & idOnline & "','" & drthorax.Text & "', '" & Tdata("StatusKesehatan") & "')", DB_Poliklinik)
                    End If

                    'Save StatusKesehatanThorax
                    WriteThemysql("Update transaksilab set StatusKesehatanThorax = '" & Tdata("StatusKesehatan") & "' WHERE NoUrut='" & Tdata("NoUrut") & "' AND idtempatlab = '" & txidloc.Text & "'", DB_Poliklinik)
                End If
            Next

            MsgBox("Data berhasil disimpan.", MsgBoxStyle.Information, "Success!")
        Else
            MsgBox("Canceled.", MsgBoxStyle.Exclamation, "Warning!")
        End If

        buttambahpasien.Enabled = True
        ProgressBar1.Visible = False
    End Sub

    Private Sub butfindloc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butfindloc.Click
        If rdOnline.Checked = True Then
            Find.Show()
            Find.QueryTheMysql("SELECT a.kodecabang AS 'Lokasi ID', a.kodeket AS 'Keterangan Lokasi', a.kodebarcode AS 'Kode Barcode' FROM mastercodebarcode a ORDER BY a.kodeket ASC", " ", "FindCabangUploadThorax", 0, Find_Poliklinik)
        End If
    End Sub

    Private Sub SetClearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SetConn()
        SetGrid()
    End Sub

    Private Sub rdOnline_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdOnline.CheckedChanged
        txloc.ResetText()
        txidloc.ResetText()
        butfindloc.Enabled = True
        gridthorax.DataSource = Nothing
    End Sub

    Private Sub rdOffline_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdOffline.CheckedChanged
        txidloc.Text = ReadSQLNIK("select StrValue from MsConfig where ConfigName='NoPoli'")
        txloc.Text = ReadSQLNIK("select StrValue from MsConfig where ConfigName='NamaPoli'")
        butfindloc.Enabled = False
        gridthorax.DataSource = Nothing
    End Sub

    Private Sub butdownloadformat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butdownloadformat.Click
        gridexcel.DataSource = Nothing

        Dim Tbls As DataTable = ReadSQL("select '-' as 'NoUrut', '-' as 'Nama', '-' as 'tgllahir', ValueThorax as 'Hasil', '-' as 'Cor', '-' as 'Pulmo', '-' as 'Sinus', '-' as 'Skeletal', '-' as 'StatusKesehatan' from MasterNilaiHasilThorax")
        gridexcel.DataSource = Tbls
        ExportDataToExcel(gridexcel)
    End Sub

    Private Sub butfindcompany_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butfindcompany.Click
        Find.Show()
        Find.Query("select IDCompany, CompanyCode, CompanyNama, NoCompany from mastercompany a where getdate() between StartDate and EndDate", " ORDER BY a.idcompany desc", "FindCompanyUploadThorax", 2)
    End Sub

    Private Sub butdownloadtransthorax_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butdownloadtransthorax.Click
        Try
            gridexcel.DataSource = Nothing

            If txcompanycode.Text = "" Then
                MsgBox("Pilih Company Terlebih Dahulu.", MsgBoxStyle.Exclamation, "Warning!")
                Exit Sub
            ElseIf txidloc.Text = "" Then
                MsgBox("Pilih Lokasi Terlebih Dahulu.", MsgBoxStyle.Exclamation, "Warning!")
                Exit Sub
            End If

            Dim statuscetak As String = ""
            Dim statuscetak2 As String = ""

            If cmbstatustransaksi.SelectedIndex = 1 Then
                statuscetak = " AND StatusKesehatanThorax IS NOT NULL "
                statuscetak2 = " AND a.StatusKesehatanThorax IS NOT NULL "
            ElseIf cmbstatustransaksi.SelectedIndex = 2 Then
                statuscetak = " AND StatusKesehatanThorax IS NULL "
                statuscetak2 = " AND a.StatusKesehatanThorax IS NULL "
            End If

            Dim Tbls As DataTable = New DataTable
            If rdOffline.Checked = True Then
                Tbls = ReadSQL("SELECT NoUrut, 'Foto thorax tak tampak kelainan' AS 'Hasil', '-' AS 'Cor', '-' AS 'Pulmo', '-' AS 'Sinus', '-' AS 'Skeletal', '-' AS 'StatusKesehatan' FROM TransaksiLab WHERE DetailPemeriksaan LIKE '%THORAX%' " & statuscetak & " AND TransLabID IN (SELECT TransLabID FROM TransaksiLabBayar WHERE NoJenisBayar = '" & txcompanycode.Text & "-" & txkodecabang.Text & "' AND JenisBayar = 'TAGIHAN') AND (CONVERT(date, TglLab) BETWEEN '" & Format(dtprocess.Value, "MM-dd-yyyy") & "' AND '" & Format(dtprocessend.Value, "MM-dd-yyyy") & "')")
            ElseIf rdOnline.Checked = True Then
                Tbls = ReadThemysql("SELECT a.NoUrut, b.Nama, DATE(b.tgllahir) AS 'tgllahir', 'Foto thorax tak tampak kelainan' AS 'Hasil', '-' AS 'Cor', '-' AS 'Pulmo', '-' AS 'Sinus', '-' AS 'Skeletal', '-' AS 'StatusKesehatan' FROM transaksilab a LEFT JOIN masterpasien b ON a.idpasien=b.nomitra AND a.idtempatlab=b.cabang WHERE a.DetailPemeriksaan LIKE '%THORAX%' AND a.idlabinternet IN (SELECT idlabinternet FROM transaksilabbayar WHERE NoJenisBayar = '" & txcompanycode.Text & "-" & txkodecabang.Text & "' AND JenisBayar = 'TAGIHAN') AND (DATE(a.tgllab) BETWEEN '" & Format(dtprocess.Value, "yyyy-MM-dd") & "' AND '" & Format(dtprocessend.Value, "yyyy-MM-dd") & "') AND a.idtempatlab = '" & txidloc.Text & "' " & statuscetak2 & "", DB_Poliklinik)
            End If

            gridexcel.DataSource = Tbls

            ExportDataToExcel(gridexcel)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class