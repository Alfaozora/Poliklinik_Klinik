Imports System.IO

Public Class ResultMachine
    Private DB_Poliklinik As TLcon

    Dim Ttcon As TLcon
    Dim TtconU As TLcon
    Dim Topsi2 As String
    Dim thread As System.Threading.Thread

    Private Sub ResultMachine_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
    End Sub

    Private Sub SetConn(ByRef Tjenis As String)
        If Tjenis <> "Offline" Then
            ' Set Parameter Server Online
            Dim serverOnline_IP As String = Utility.GetConfig("ServerOnline_IP")
            Dim serverOnline_UserID As String = Utility.GetConfig("ServerOnline_UserID")
            Dim serverOnline_Password As String = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerOnline_Password"), "albert")

            ' Set DB Poliklinik
            DB_Poliklinik.Tip = serverOnline_IP
            DB_Poliklinik.Tid = serverOnline_UserID
            DB_Poliklinik.Tpass = serverOnline_Password
            DB_Poliklinik.Tdb = Utility.GetConfig("ServerOnlinePoli_DB")
        End If

        Ttcon.Tid = "root"
        Ttcon.Tip = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='TIP'")
        Ttcon.Tdb = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='TDB'")
        Ttcon.Tpass = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='TPass'")

        TtconU.Tid = "root"
        TtconU.Tip = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='TIP_Urine'")
        TtconU.Tdb = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='TDB_Urine'")
        TtconU.Tpass = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='TPass_Urine'")
    End Sub

    Private Sub SetClearHeader()
        buttindakanid.ResetText()
        txnourutan.ResetText()
        butnama.ResetText()
        txcustnama.ResetText()
        txcustumur.ResetText()
        dtcusttgllhr.Value = DateSerial("9998", "12", "31")
    End Sub

    Private Sub SetGrid(ByRef Tnourut As String, ByRef Tjenis As String, ByRef Tdiff As String)
        Dim KodeBarcodeOnline As String = ""
        Dim status_urine As String = Utility.GetConfig("MesinUrine")
        Dim Tmesindiff As String = Tdiff
        Dim KodeBarcode As String = ""
        Dim Tquery As String = ""

        If Tjenis = "Offline" Then
            KodeBarcode = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='KodeBarcode'")
            Dim barcode As String = ""
            Dim Tdataurutan As String = Tnourut

            Dim Turutan As String = Strings.Replace(Strings.Replace(Tnourut, "L", "8"), "M", "9")
            Try

                Dim Tbls As DataTable = ReadSQL("SELECT a.TransLabIDDetail,a.TindakanID,a.NamaTindakan,a.JenisTindakan,b.NoUrut,b.GroupID as NamaTindakan,b.DetailKet,b.Result,b.Satuan,b.Pria,b.Wanita,b.Keterangan,a.Mesin " & _
                                                " FROM TransaksiLabDetail a left join TransaksiLabResult b on a.TransLabIDDetail =b.TransLabIDDetail and a.TindakanID=b.TindakanID " & _
                                                " WHERE a.TransLabID='" & buttindakanid.Text & "' and a.Mesin in ('TMS','SYSMEX','URINE','CL900','C0BAS6600') " & _
                                                " order by a.TransLabIDDetail,a.TindakanID,b.NoUrut,b.GroupID,b.DetailKet")
                Tbls.Columns("Result").ReadOnly = False

                For Each Trow As DataRow In Tbls.Rows
                    If Trow("Mesin").ToString = "TMS" Then
                        Dim Tfortindakan As String = ""
                        If Trow("NoUrut") > 1 Then Tfortindakan = Trow("TindakanID") & "." & CInt(Trow("NoUrut")) - 1 Else Tfortindakan = Trow("TindakanID")
                        Dim Ttemp As DataTable = ReadThemysql("SELECT f.`no_lab`, f.`rkdjasa`, f.`rnmjasa`, f.`result`, f.`tanda` FROM f_tmspremium f WHERE f.`tanda`<>'' and f.`rkdjasa`='" & Tfortindakan & "' and f.`no_lab`='" & KodeBarcode & Strings.Right(Turutan, Len(Turutan) - 2) & "'", Ttcon)
                        'InputBox("", "", "SELECT f.`no_lab`, f.`rkdjasa`, f.`rnmjasa`, f.`result`, f.`tanda` FROM f_tmspremium f WHERE f.`tanda`<>'' and f.`rkdjasa`='" & Tfortindakan & "' and f.`no_lab`='" & Strings.Right(Turutan, Len(Turutan) - 2) & "'")
                        If Ttemp.Rows.Count > 0 Then
                            Dim Ttrow As DataRow = Ttemp.Rows(0)
                            Trow("Result") = Ttrow("result").ToString
                        Else
                            Trow("Result") = "-"
                        End If
                    ElseIf Trow("Mesin").ToString = "CL900" Then
                        Dim Tfortindakan As String = ""
                        If Trow("NoUrut") > 1 Then Tfortindakan = Trow("TindakanID") & "." & CInt(Trow("NoUrut")) - 1 Else Tfortindakan = Trow("TindakanID")
                        Dim Ttemp As DataTable = ReadThemysql("SELECT f.`no_lab`, f.`rkdjasa`, f.`rnmjasa`, f.`result`, f.`tanda` FROM f_cl900 f WHERE f.`tanda`<>'' and f.`rkdjasa`='" & Tfortindakan & "' and f.`no_lab`='" & KodeBarcode & Strings.Right(Turutan, Len(Turutan) - 2) & "'", Ttcon)
                        If Ttemp.Rows.Count > 0 Then
                            Dim Ttrow As DataRow = Ttemp.Rows(0)
                            Trow("Result") = Ttrow("result").ToString
                        Else
                            Trow("Result") = "-"
                        End If
                    ElseIf Trow("Mesin").ToString = "SYSMEX" Then
                        If Tmesindiff = "Diff5" Then
                            Dim DetailID As Integer = ReadSQLNIK("SELECT DetailID FROM MasterLabDetail " & _
                                                    " WHERE TindakanID = '" & Trow("TindakanID") & "' and GroupID = '" & Trow("NamaTindakan") & "' " & _
                                                    " and NoUrut = '" & Trow("NoUrut") & "' and DetailKet = '" & Trow("DetailKet") & "'")

                            Dim Tfornourut As String = Trow("NoUrut")
                            If CInt(Trow("NoUrut")) < 10 Then Tfornourut = "0" & Tfornourut
                            Dim Tsysmx As DataTable = ReadThemysql("SELECT s.`rnoreg`, s.`tgl_data`, s.`no_id`, s.`seq_no`, f.`rkdjasa`, f.`rnmjasa`, f.`hasil`,j.`satuan`, f.`urut` FROM sysmex s left join fsysmex2 f on s.seq_no=f.seq_no left join mas_sysmex j on j.kd=f.rkdjasa and j.parameter=f.rnmjasa WHERE s.`dok`<>'' and s.`dok`<>0 and trim(s.`rnoreg`)='" & KodeBarcode & Strings.Right(Turutan, Len(Turutan) - 2) & "' and f.`rnmjasa`='" & Strings.UCase(Trow("DetailKet")) & "' order by s.usertime asc", Ttcon)

                            If Tsysmx.Rows.Count > 0 Then
                                Dim Rtsysmx As DataRow = Tsysmx.Rows(0)
                                Trow("Result") = Rtsysmx("hasil").ToString
                            Else
                                Trow("Result") = "-"
                            End If
                        ElseIf Tmesindiff = "Diff3" Then
                            Dim bridgingID As String = ReadSQLNIK("SELECT KodeBridgingMesin FROM MasterLabDetail " & _
                                                     " WHERE TindakanID = '" & Trow("TindakanID") & "' and GroupID = '" & Trow("NamaTindakan") & "' " & _
                                                     " and NoUrut = '" & Trow("NoUrut") & "' and DetailKet = '" & Trow("DetailKet") & "'")

                            Dim Tsysmx As DataTable = ReadThemysql("SELECT b.hasil as hasil FROM maslab a, hasil_lab b WHERE a.rkdjasa = b.kode_test AND a.rkdjasa = '" & bridgingID & "' and b.no_lab = '" & KodeBarcode & Strings.Right(Turutan, Len(Turutan) - 2) & "'", TtconU)
                            If Tsysmx.Rows.Count > 0 Then
                                Dim Rtsysmx As DataRow = Tsysmx.Rows(0)
                                Trow("Result") = Rtsysmx("hasil").ToString
                            Else
                                Trow("Result") = "-"
                            End If
                        End If
                    ElseIf Trow("Mesin").ToString = "URINE" Then
                        If status_urine = "Yes" Then
                            Dim DetailID As Integer = ReadSQLNIK("SELECT DetailID FROM MasterLabDetail " & _
                                                    " WHERE TindakanID = '" & Trow("TindakanID") & "' and GroupID = '" & Trow("NamaTindakan") & "' " & _
                                                    " and NoUrut = '" & Trow("NoUrut") & "' and DetailKet = '" & Trow("DetailKet") & "'")
                            'Dim Tfornourut As String = Trow("NoUrut")
                            'If CInt(Trow("NoUrut")) < 10 Then Tfornourut = "0" & Tfornourut

                            Dim Turine As DataTable = ReadThemysql("SELECT b.hasil as hasil FROM maslab a, hasil_lab b WHERE a.rkdjasa = b.kode_test AND a.his_test = '" & DetailID & "' and b.no_lab = '" & KodeBarcode & Strings.Right(Turutan, Len(Turutan) - 2) & "'", TtconU)
                            If Turine.Rows.Count > 0 Then
                                Dim Rturine As DataRow = Turine.Rows(0)
                                Trow("Result") = Rturine("hasil").ToString
                            Else
                                Trow("Result") = "-"
                            End If
                        End If
                    ElseIf Trow("Mesin").ToString = "C0BAS6600" Then
                        Dim DetailID As Integer = ReadSQLNIK("SELECT DetailID FROM MasterLabDetail " & _
                                                    " WHERE TindakanID = '" & Trow("TindakanID") & "' " & _
                                                    " and NoUrut = '" & Trow("NoUrut") & "' and DetailKet = '" & Trow("DetailKet") & "'")

                        Dim Tfornourut As String = Trow("NoUrut")
                        If CInt(Trow("NoUrut")) < 10 Then Tfornourut = "0" & Tfornourut
                        'Dim Tsysmx As DataTable = ReadThemysql("SELECT s.`rnoreg`, s.`tgl_data`, s.`no_id`, s.`seq_no`, f.`rkdjasa`, f.`rnmjasa`, f.`hasil`,j.`satuan`, f.`urut` FROM sysmex s left join fsysmex2 f on s.seq_no=f.seq_no left join mas_sysmex j on j.kd=f.rkdjasa and j.parameter=f.rnmjasa WHERE s.`dok`<>'' and s.`dok`<>0 and trim(s.`rnoreg`)='" & KodeBarcode & Strings.Right(Turutan, Len(Turutan) - 2) & "' and f.`rnmjasa`='" & Strings.UCase(Trow("DetailKet")) & "' order by s.usertime asc", Ttcon)

                        Dim Tsysmx As DataTable = ReadThemysql("SELECT f.xhasil " & _
                                                               "FROM lis_c6600 s " & _
                                                               "LEFT JOIN lis_fc6600 f on s.seq_no=f.seq_no AND s.rnoreg = f.no_id " & _
                                                               "WHERE s.`dok`<>'' and s.`dok`<>0 and trim(s.`rnoreg`)='" & KodeBarcode & Strings.Right(Turutan, Len(Turutan) - 2) & "' and f.`rnmjasa`='" & Strings.UCase(Trow("DetailKet")) & "'", Ttcon)

                        If Tsysmx.Rows.Count > 0 Then
                            Dim Rtsysmx As DataRow = Tsysmx.Rows(0)
                            Trow("Result") = Rtsysmx("xhasil").ToString
                        Else
                            Trow("Result") = "-"
                        End If
                    End If
                Next

                For Each Tcol As DataColumn In Tbls.Columns
                    Tcol.ReadOnly = True
                Next

                Tbls.Columns("Result").ReadOnly = False
                gridlab.DataSource = Tbls
                GridView1.Columns("Result").Width = 200
            Catch ex As Exception
                MsgBox(ex.Message)
                Me.Close()
            End Try
        ElseIf Tjenis = "Online" Then
            Try
                Dim Tbls As DataTable
                Tquery = ""
                Dim Tdataurutan As String = Tnourut
                Dim Turutan As String = Strings.Replace(Strings.Replace(Tnourut, "L", "8"), "M", "9")

                Turutan = Strings.Right(Turutan, Len(Turutan) - 2)
                Tquery = "SELECT a.idtempatlab, b.TransLabIDDetail,b.TindakanID,b.GroupID as NamaTindakan,b.NoUrut,b.DetailKet, b.Result, b.Satuan ,b.Pria, b.Wanita, b.Keterangan, c.Mesin " & _
                " FROM transaksilab a INNER JOIN transaksilabdetail c ON a.idlabinternet=c.idlabinternet left join transaksilabresult b on c.translabiddetail=b.transLabiddetail " & _
                " WHERE b.idlabinternet=c.idlabinternet AND a.idpasien='" & butnama.Text & "' and a.idlabinternet='" & buttindakanid.Text & "' and  c.mesin in ('TMS','SYSMEX','URINE','CL900','C0BAS6600')  " & _
                " order by b.TransLabIDDetail,b.TindakanID,b.NoUrut,b.GroupID,b.DetailKet "
                Tbls = ReadThemysql(Tquery, DB_Poliklinik)
                Tbls.Columns("Result").ReadOnly = False

                For Each Trow As DataRow In Tbls.Rows
                    KodeBarcodeOnline = ReadThemysqlNIK("SELECT kodebarcode FROM mastercodebarcode WHERE kodecabang='" & Trow("idtempatlab") & "'", DB_Poliklinik)
                    If Trow("Mesin").ToString = "TMS" Then
                        If Tmesindiff = "Diff5" Then
                            Dim Tfortindakan As String = ""
                            If Trow("NoUrut") > 1 Then Tfortindakan = Trow("TindakanID") & "." & CInt(Trow("NoUrut")) - 1 Else Tfortindakan = Trow("TindakanID")
                            Dim Ttemp As DataTable = ReadThemysql("SELECT f.`no_lab`, f.`rkdjasa`, f.`rnmjasa`, f.`result`, f.`tanda` FROM f_tmspremium f WHERE f.`tanda`<>'' and f.`rkdjasa`='" & Tfortindakan & "' and f.`no_lab`='" & KodeBarcodeOnline & Turutan & "'", Ttcon)
                            'InputBox("", "", "SELECT f.`no_lab`, f.`rkdjasa`, f.`rnmjasa`, f.`result`, f.`tanda` FROM f_tmspremium f WHERE f.`tanda`<>'' and f.`rkdjasa`='" & Tfortindakan & "' and f.`no_lab`='" & Strings.Right(Turutan, Len(Turutan) - 2) & "'")
                            If Ttemp.Rows.Count > 0 Then
                                Dim Ttrow As DataRow = Ttemp.Rows(0)
                                Trow("Result") = Ttrow("result").ToString
                            Else
                                Trow("Result") = "-"
                            End If
                        End If
                    ElseIf Trow("Mesin").ToString = "CL900" Then
                        If Tmesindiff = "Diff5" Then
                            Dim Tfortindakan As String = ""
                            If Trow("NoUrut") > 1 Then Tfortindakan = Trow("TindakanID") & "." & CInt(Trow("NoUrut")) - 1 Else Tfortindakan = Trow("TindakanID")
                            Dim Ttemp As DataTable = ReadThemysql("SELECT f.`no_lab`, f.`rkdjasa`, f.`rnmjasa`, f.`result`, f.`tanda` FROM f_cl900 f WHERE f.`tanda`<>'' and f.`rkdjasa`='" & Tfortindakan & "' and f.`no_lab`='" & KodeBarcodeOnline & Turutan & "'", Ttcon)
                            'InputBox("", "", "SELECT f.`no_lab`, f.`rkdjasa`, f.`rnmjasa`, f.`result`, f.`tanda` FROM f_cl900 f WHERE f.`tanda`<>'' and f.`rkdjasa`='" & Tfortindakan & "' and f.`no_lab`='" & Strings.Right(Turutan, Len(Turutan) - 2) & "'")
                            If Ttemp.Rows.Count > 0 Then
                                Dim Ttrow As DataRow = Ttemp.Rows(0)
                                Trow("Result") = Ttrow("result").ToString
                            Else
                                Trow("Result") = "-"
                            End If
                        End If
                    ElseIf Trow("Mesin").ToString = "SYSMEX" Then
                        If Tmesindiff = "Diff5" Then
                            Dim DetailID As Integer = ReadSQLNIK("SELECT DetailID FROM MasterLabDetail " & _
                                                    " WHERE TindakanID = '" & Trow("TindakanID") & "' and GroupID = '" & Trow("NamaTindakan") & "' " & _
                                                    " and NoUrut = '" & Trow("NoUrut") & "' and DetailKet = '" & Trow("DetailKet") & "'")

                            Dim Tfornourut As String = Trow("NoUrut")
                            If CInt(Trow("NoUrut")) < 10 Then Tfornourut = "0" & Tfornourut
                            Dim Tsysmx As DataTable = ReadThemysql("SELECT s.`rnoreg`, s.`tgl_data`, s.`no_id`, s.`seq_no`, f.`rkdjasa`, f.`rnmjasa`, f.`hasil`,j.`satuan`, f.`urut` FROM sysmex s left join fsysmex2 f on s.seq_no=f.seq_no left join mas_sysmex j on j.kd=f.rkdjasa and j.parameter=f.rnmjasa WHERE s.`dok`<>'' and s.`dok`<>0 and trim(s.`rnoreg`)='" & KodeBarcodeOnline & Turutan & "' and f.`rnmjasa`='" & Strings.UCase(Trow("DetailKet")) & "' order by s.usertime asc", Ttcon)
                            If Tsysmx.Rows.Count > 0 Then
                                Dim Rtsysmx As DataRow = Tsysmx.Rows(0)
                                Trow("Result") = Rtsysmx("hasil").ToString
                            Else
                                Trow("Result") = "-"
                            End If
                        ElseIf Tmesindiff = "Diff3" Then
                            Dim bridgingID As String = ReadSQLNIK("SELECT KodeBridgingMesin FROM MasterLabDetail " & _
                                                     " WHERE TindakanID = '" & Trow("TindakanID") & "' and GroupID = '" & Trow("NamaTindakan") & "' " & _
                                                     " and NoUrut = '" & Trow("NoUrut") & "' and DetailKet = '" & Trow("DetailKet") & "'")

                            'DIFF3
                            Dim Tfornourut As String = Trow("NoUrut")
                            If CInt(Trow("NoUrut")) < 10 Then Tfornourut = "0" & Tfornourut

                            Dim Tsysmx As DataTable = ReadThemysql("SELECT b.hasil as hasil FROM maslab a, hasil_lab b WHERE a.rkdjasa = b.kode_test AND a.rkdjasa = '" & bridgingID & "' and b.no_lab = '" & KodeBarcodeOnline & Turutan & "'", TtconU)
                            If Tsysmx.Rows.Count > 0 Then
                                Dim Rtsysmx As DataRow = Tsysmx.Rows(0)
                                Trow("Result") = Rtsysmx("hasil").ToString
                            Else
                                Trow("Result") = "-"
                            End If
                        End If
                    ElseIf Trow("Mesin").ToString = "URINE" Then
                        If status_urine = "Yes" Then
                            Dim DetailID As Integer = ReadSQLNIK("SELECT DetailID FROM MasterLabDetail " & _
                                                    " WHERE TindakanID = '" & Trow("TindakanID") & "' and GroupID = '" & Trow("NamaTindakan") & "' " & _
                                                    " and NoUrut = '" & Trow("NoUrut") & "' and DetailKet = '" & Trow("DetailKet") & "'")
                            Dim Tfornourut As String = Trow("NoUrut")
                            If CInt(Trow("NoUrut")) < 10 Then Tfornourut = "0" & Tfornourut

                            Dim Turine As DataTable = ReadThemysql("SELECT b.hasil as hasil FROM maslab a, hasil_lab b WHERE a.rkdjasa = b.kode_test AND a.his_test = '" & DetailID & "' and b.no_lab = '" & KodeBarcodeOnline & Turutan & "'", TtconU)
                            If Turine.Rows.Count > 0 Then
                                Dim Rturine As DataRow = Turine.Rows(0)
                                Trow("Result") = Rturine("hasil").ToString
                            Else
                                Trow("Result") = "-"
                            End If
                        End If
                    ElseIf Trow("Mesin").ToString = "C0BAS6600" Then
                        Dim DetailID As Integer = ReadSQLNIK("SELECT DetailID FROM MasterLabDetail " & _
                                                    " WHERE TindakanID = '" & Trow("TindakanID") & "' " & _
                                                    " and NoUrut = '" & Trow("NoUrut") & "' and DetailKet = '" & Trow("DetailKet") & "'")

                        Dim Tfornourut As String = Trow("NoUrut")
                        If CInt(Trow("NoUrut")) < 10 Then Tfornourut = "0" & Tfornourut
                        'Dim Tsysmx As DataTable = ReadThemysql("SELECT s.`rnoreg`, s.`tgl_data`, s.`no_id`, s.`seq_no`, f.`rkdjasa`, f.`rnmjasa`, f.`hasil`,j.`satuan`, f.`urut` FROM sysmex s left join fsysmex2 f on s.seq_no=f.seq_no left join mas_sysmex j on j.kd=f.rkdjasa and j.parameter=f.rnmjasa WHERE s.`dok`<>'' and s.`dok`<>0 and trim(s.`rnoreg`)='" & KodeBarcodeOnline & Turutan & "' and f.`rnmjasa`='" & Strings.UCase(Trow("DetailKet")) & "' order by s.usertime asc", Ttcon)
                        Dim Tsysmx As DataTable = ReadThemysql("SELECT f.xhasil " & _
                                                               "FROM lis_c6600 s " & _
                                                               "LEFT JOIN lis_fc6600 f on s.seq_no=f.seq_no AND s.rnoreg = f.no_id " & _
                                                               "WHERE s.`dok`<>'' and s.`dok`<>0 and trim(s.`rnoreg`)='" & KodeBarcodeOnline & Turutan & "' and f.`rnmjasa`='" & Strings.UCase(Trow("DetailKet")) & "'", Ttcon)

                        If Tsysmx.Rows.Count > 0 Then
                            Dim Rtsysmx As DataRow = Tsysmx.Rows(0)
                            Trow("Result") = Rtsysmx("xhasil").ToString
                        Else
                            Trow("Result") = "-"
                        End If

                        '=======================================================
                    End If
                Next

                For Each Tcol As DataColumn In Tbls.Columns
                    Tcol.ReadOnly = True
                Next
                Tbls.Columns("Result").ReadOnly = False
                gridlab.DataSource = Tbls
                Tbls.AcceptChanges()

                GridView1.Columns("TransLabIDDetail").Visible = False
                GridView1.Columns("TindakanID").Visible = False
                GridView1.Columns("idtempatlab").Visible = False
            Catch ex As Exception
                MsgBox(ex.Message)
                Me.Close()
            End Try
        ElseIf Tjenis = "DownloadHasilOnline" Then
            Dim Tloc As String = ReadSQLNIK("SELECT StrValue  FROM MsConfig WHERE ConfigName='NoPoli'")
            Dim OnlineID As String = ReadThemysqlNIK("SELECT a.idlabinternet FROM transaksilab a WHERE a.idtempatlab = '" & Tloc & "' AND a.translabid = '" & buttindakanid.Text & "'", DB_Poliklinik)

            Dim Tbls As DataTable
            'Tquery = " SELECT a.idtempatlab, b.TransLabIDDetail,b.TindakanID,b.groupid AS NamaTindakan,b.NoUrut,b.DetailKet, b.Result, b.Satuan ,b.Pria, b.Wanita, b.Keterangan, c.Mesin " & _
            '         " FROM transaksilab a " & _
            '         " INNER JOIN transaksilabdetail c ON a.idlabinternet=c.idlabinternet " & _
            '         " LEFT JOIN transaksilabresult b on c.translabiddetail=b.transLabiddetail " & _
            '         " WHERE b.idlabinternet=c.idlabinternet AND a.idpasien='" & butnama.Text & "' AND a.idlabinternet='" & OnlineID & "' AND c.mesin in ('TMS','SYSMEX','URINE','CL900') " & _
            '         " ORDER BY b.TransLabIDDetail,b.TindakanID,b.NoUrut,b.GroupID,b.DetailKet"
            Tquery = " SELECT a.idtempatlab, b.TransLabIDDetail,b.TindakanID,b.groupid AS NamaTindakan,b.NoUrut,b.DetailKet, b.Result, b.Satuan ,b.Pria, b.Wanita, b.Keterangan, c.Mesin " & _
                     " FROM transaksilab a " & _
                     " INNER JOIN transaksilabdetail c ON a.idlabinternet=c.idlabinternet " & _
                     " LEFT JOIN transaksilabresult b on c.translabiddetail=b.transLabiddetail " & _
                     " WHERE b.idlabinternet=c.idlabinternet AND a.idpasien='" & butnama.Text & "' AND a.idlabinternet='" & OnlineID & "' " & _
                     " ORDER BY b.TransLabIDDetail,b.TindakanID,b.NoUrut,b.GroupID,b.DetailKet"
            Tbls = ReadThemysql(Tquery, DB_Poliklinik)

            For Each Tcol As DataColumn In Tbls.Columns
                Tcol.ReadOnly = True
            Next
            Tbls.Columns("Result").ReadOnly = False

            gridlab.DataSource = Tbls
            Tbls.AcceptChanges()

            GridView1.Columns("TransLabIDDetail").Visible = False
            GridView1.Columns("TindakanID").Visible = False
            GridView1.Columns("idtempatlab").Visible = False
        End If
    End Sub

    Public Sub LoadAdminLab(ByRef TxID As String, ByRef Txnourut As String, ByRef Tdiff As String, ByRef Tjenis As String, ByRef kodeLokasi As String)
        Dim TransaksiID As String = ""

        If Tjenis = "Offline" Or Tjenis = "DownloadHasilOnline" Then
            SetConn(Tjenis)
            TransaksiID = ReadSQLNIK("SELECT IDInternet FROM TransaksiLab WHERE TransLabID='" & TxID & "' AND NoUrut='" & Txnourut & "'")
        ElseIf Tjenis = "Online" Then
            SetConn(Tjenis)
            TransaksiID = ReadThemysqlNIK("SELECT idpasien FROM transaksilab WHERE idlabinternet='" & TxID & "' AND NoUrut='" & Txnourut & "'", DB_Poliklinik)
        End If

        SetClearHeader()
        buttindakanid.Text = TxID
        txnourutan.Text = Txnourut

        LoadLabPasien(TransaksiID, Tjenis, kodeLokasi)
        SetGrid(Txnourut, Tjenis, Tdiff)
    End Sub

    Public Sub LoadLabPasien(ByRef Txid As String, ByRef Topsi As String, ByRef kodeLokasi As String)
        Dim Tbls As New DataTable
        If Topsi = "Offline" Or Topsi = "DownloadHasilOnline" Then
            Tbls = ReadSQL("SELECT Nama, TglLahir " & _
                           "FROM MasterPasien " & _
                           "WHERE NoRekamMedis='" & Txid & "'")
        ElseIf Topsi = "Online" Then
            Tbls = ReadThemysql("SELECT Nama, TglLahir " & _
                                "FROM masterpasien " & _
                                "WHERE nomitra='" & Txid & "' AND cabang='" & kodeLokasi & "'", DB_Poliklinik)
        End If

        Dim Trow As DataRow = Tbls.Rows(0)
        Topsi2 = Topsi
        butnama.Text = Txid
        txcustnama.Text = Trow("Nama")
        dtcusttgllhr.Value = Trow("TglLahir")
        txcustumur.Text = Umur(Trow("TglLahir"))
    End Sub

    Private Sub cmbsend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbsend.Click
        Dim Tbls As DataTable = gridlab.DataSource
        Tbls.AcceptChanges()
        Dim StatusHema As Boolean = False

        For Each Trownew As DataRow In Tbls.Rows
            'Save Hasil
            If Trownew("Result") <> "-" And Trownew("Result") <> "" Then
                If Topsi2 = "Online" Then
                    WriteThemysql("update transaksilabresult set Result='" & Trownew("Result").ToString.Trim & "'  WHERE idlabinternet='" & buttindakanid.Text & "' AND TransLabIDDetail='" & Trownew("TransLabIDDetail").ToString & "' and TindakanID='" & Trownew("TindakanID").ToString & "' and NoUrut='" & Trownew("NoUrut").ToString & "'", DB_Poliklinik)
                ElseIf Topsi2 = "DownloadHasilOnline" Then
                    WriteSQL("update transaksilabresult set Keterangan = '" & Trownew("Keterangan").ToString.Trim & "', Result='" & Trownew("Result").ToString.Trim & "' WHERE TransLabIDDetail='" & Trownew("TransLabIDDetail").ToString & "' and TindakanID='" & Trownew("TindakanID").ToString & "' and NoUrut='" & Trownew("NoUrut").ToString & "'", 4)
                Else
                    WriteSQL("update transaksilabresult set Result='" & Trownew("Result").ToString.Trim & "'  WHERE TransLabIDDetail='" & Trownew("TransLabIDDetail").ToString & "' and TindakanID='" & Trownew("TindakanID").ToString & "' and NoUrut='" & Trownew("NoUrut").ToString & "'", 4)
                End If
            End If

            'Jika Pemeriksaan Hema
            If Trownew("NamaTindakan").ToString.Contains("Hematologi") = True Then
                StatusHema = True
            End If
        Next

        Dim Tdiff As Integer = Utility.GetConfig("MesinDiff")

        If Topsi2 = "Online" Then
            If Tdiff = "5" And StatusHema = True Then
                LabAdminOnline.SaveHematologiLengkap()
            End If

            LabAdminOnline.LoadAdminLab(buttindakanid.Text, txnourutan.Text)
        Else
            If Topsi2 <> "DownloadHasilOnline" And Tdiff = "5" And StatusHema = True Then
                LabAdmin.SaveHematologiLengkap()
            End If

            If Topsi2 = "DownloadHasilOnline" And CheckSQL("SELECT NamaTindakan FROM TransaksiLabDetail WHERE TransLabID = '" & buttindakanid.Text.Trim & "' AND NamaTindakan LIKE '%HEMATOLOGI%'") = True Then

                Dim Tloc As String = ReadSQLNIK("SELECT StrValue  FROM MsConfig WHERE ConfigName='NoPoli'")
                Dim HemaFileBase64 As String = ReadThemysqlNIK("SELECT HemaFileBase64 FROM transaksilabreportonline a WHERE a.idlabinternet IN (SELECT idlabinternet FROM transaksilab WHERE nourut = '" & txnourutan.Text.Trim & "' AND idtempatlab = '" & Tloc & "')", DB_Poliklinik)

                If HemaFileBase64.Trim <> "-" Then
                    Dim NameFileDL As String = txnourutan.Text & "_Hasil_Hematologi_Lengkap"
                    Dim filepathDL As String = "FileDownload\Hasil\Hematologi_Lengkap\" & NameFileDL & ".pdf"

                    Dim binaryData() As Byte = Convert.FromBase64String(HemaFileBase64)

                    ' Assuming it's a jpg :)
                    If File.Exists(filepathDL) = True Then
                        My.Computer.FileSystem.DeleteFile(filepathDL)
                    End If

                    Dim fs As New FileStream(filepathDL, FileMode.CreateNew)

                    ' write it out
                    fs.Write(binaryData, 0, binaryData.Length)

                    ' close it down.
                    fs.Close()
                End If
            End If

            LabAdmin.LoadAdminLab(buttindakanid.Text, txnourutan.Text, "empty")
        End If

        MsgBox("Data Berhasil Update.", MsgBoxStyle.Information, "Success!")
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Tpos As String = ReadSQLNIK("SELECT nourut FROM TransaksiLab WHERE TranslabID='" & buttindakanid.Text & "'")
        Dim Tnourut As String = Strings.Replace(Strings.Replace(Tpos, "M", ""), "L", "")

        Try
            Dim Tbls As DataTable = ReadSQL("SELECT a.TransLabIDDetail,a.TindakanID,a.NamaTindakan,a.JenisTindakan,b.NoUrut,b.GroupID as NamaTindakan,b.DetailKet,b.Result,b.Satuan,b.Pria,b.Wanita,b.Keterangan,a.Mesin " & _
                                            " FROM TransaksiLabDetail a left join TransaksiLabResult b on a.TransLabIDDetail =b.TransLabIDDetail and a.TindakanID=b.TindakanID " & _
                                            " WHERE a.TransLabID='" & buttindakanid.Text & "' and a.Mesin in ('TMS','SYSMEX') " & _
                                            " order by a.TransLabIDDetail,a.TindakanID,b.NoUrut,b.GroupID,b.DetailKet")
            Tbls.Columns("Result").ReadOnly = False

            For Each Trow As DataRow In Tbls.Rows
                If Trow("Mesin").ToString = "TMS" Then
                    Dim Tfortindakan As String = ""
                    If Trow("NoUrut") > 1 Then Tfortindakan = Trow("TindakanID") & "." & CInt(Trow("NoUrut")) - 1 Else Tfortindakan = Trow("TindakanID")
                    Dim Ttemp As DataTable = ReadThemysql("SELECT f.`no_lab`, f.`rkdjasa`, f.`rnmjasa`, f.`result`, f.`tanda` FROM f_tmspremium f WHERE f.`tanda`<>'' and f.`rkdjasa`='" & Tfortindakan & "' and f.`no_lab`='" & Strings.Right(Tnourut, Len(Tnourut) - 2) & "'", Ttcon)
                    If Ttemp.Rows.Count > 0 Then
                        Dim Ttrow As DataRow = Ttemp.Rows(0)
                        Trow("Result") = Ttrow("result").ToString
                    Else
                        Trow("Result") = "-"
                    End If
                ElseIf Trow("Mesin").ToString = "SYSMEX" Then
                    Dim Tfornourut As String = Trow("NoUrut")
                    If CInt(Trow("NoUrut")) < 10 Then Tfornourut = "0" & Tfornourut
                    Dim Tsysmx As DataTable = ReadThemysql("SELECT s.`rnoreg`, s.`tgl_data`, s.`no_id`, s.`seq_no`, f.`rkdjasa`, f.`rnmjasa`, f.`hasil`,j.`satuan`, f.`urut` FROM sysmex s left join fsysmex2 f on s.seq_no=f.seq_no left join mas_sysmex j on j.kd=f.rkdjasa and j.parameter=f.rnmjasa WHERE trim(s.`rnoreg`)='" & Strings.Right(Tnourut, Len(Tnourut) - 2) & "' and f.`rnmjasa`='" & Strings.UCase(Trow("DetailKet")) & "'", Ttcon)
                    If Tsysmx.Rows.Count > 0 Then
                        Dim Rtsysmx As DataRow = Tsysmx.Rows(0)
                        Trow("Result") = Rtsysmx("hasil").ToString
                    Else
                        Trow("Result") = "-"
                    End If
                End If
            Next

            For Each Tcol As DataColumn In Tbls.Columns
                Tcol.ReadOnly = True
            Next
            Tbls.Columns("Result").ReadOnly = False
            gridlab.DataSource = Tbls
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.Close()
        End Try
    End Sub
End Class