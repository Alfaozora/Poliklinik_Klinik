Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports System.IO
Imports System.Text
Imports Newtonsoft.Json.Linq

Public Class FormCetakBarcode

    Private Sub ClearHeader()
        rdNonMCU.Checked = True
        txTransLabID1.ResetText()
        txtindakanid.ResetText()
        txNoMitra1.ResetText()
        txcustnama.ResetText()
        TextBoxScanHyu.ResetText()
        dtcusttgllhr.Value = DateSerial("9998", "12", "31")
        txcustumur.ResetText()
        TextBoxJenisKelamin.ResetText()
        txtindakan.ResetText()
        CetakBarcodeToolStripMenuItem.Enabled = False
        BarcodeTambahanToolStripMenuItem.Enabled = False

        'MCU
        txNoUrut1.Enabled = False
        txNoUrut2.Enabled = False
        txNoUrut1.ResetText()
        txNoUrut2.ResetText()
        txkodecabang.ResetText()
        txcompanycode.ResetText()
        gridlab.DataSource = Nothing
        cbtabung.Checked = True
        cmbkodetransaksi.SelectedIndex = 0
    End Sub

    Public Sub LoadTransLab(ByVal Trow As DataRowView)
        ClearHeader()
        CetakBarcodeToolStripMenuItem.Enabled = True
        BarcodeTambahanToolStripMenuItem.Enabled = True
        txTransLabID1.Text = Trow("TransLabID").ToString
        txtindakanid.Text = Trow("NoUrut").ToString
        txNoMitra1.Text = Trow("IDInternet").ToString

        Dim Tpasien As DataTable = ReadSQL("SELECT * FROM MasterPasien WHERE NoRekamMedis = '" & txNoMitra1.Text & "'")
        Dim Rpasien As DataRow = Tpasien.Rows(0)
        txcustnama.Text = Rpasien("Nama").ToString
        dtcusttgllhr.Value = Rpasien("TglLahir")
        txcustumur.Text = Umur(dtcusttgllhr.Value)
        TextBoxJenisKelamin.Text = Rpasien("JenisKelamin").ToString
        txtindakan.Text = ReadSQLNIK("SELECT DetailPemeriksaan FROM transaksilab WHERE TransLabID = '" & Trow("TransLabID").ToString & "'")
    End Sub

    Private Sub FormCetakBarcode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        ClearHeader()
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        ClearHeader()
    End Sub

    'After Update
    'Private Sub CetakBarcodeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CetakBarcodeToolStripMenuItem.Click
    '    CetakBarcodeToolStripMenuItem.Enabled = False
    '    BarcodeTambahanToolStripMenuItem.Enabled = False

    '    Dim Tpos As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='PathBarcode'")
    '    Dim KodeBarcode As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='KodeBarcode'")
    '    Dim Tpathprf As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='Pathprf'")
    '    Dim Ttx As String = Tpos & "Output.txt"
    '    Dim barcode As String = ""

    '    Try
    '        Dim NoUrut As String = ""
    '        If rdNonMCU.Checked = True Then
    '            NoUrut = "(" & txTransLabID1.Text & ")"
    '        ElseIf rdMCU.Checked = True Then
    '            Dim TblsMCU As DataTable = gridlab.DataSource
    '            NoUrut = ""
    '            Dim TtempMCU As String = "("
    '            For Each TrowMCU As DataRow In TblsMCU.Rows
    '                TtempMCU = TtempMCU & "'" & TrowMCU("TransLabID").ToString.Trim & "',"
    '            Next
    '            NoUrut = Strings.Left(TtempMCU, TtempMCU.Length - 1) & ")"
    '        End If

    '        Dim Tbls2 As DataTable = ReadSQL("SELECT a.NoUrut, a.TransLabID, c.Nama, CONVERT(varchar(11), c.TglLahir,106) as TglLahir, c.JenisKelamin, a.LabSamplingTime " & _
    '                                         "FROM TransaksiLab a " & _
    '                                         "LEFT JOIN MasterPasien c on c.NoRekamMedis = a.IDInternet " & _
    '                                         "WHERE a.TransLabID in " & NoUrut & "")
    '        If Tbls2.Rows.Count > 0 Then
    '            For Each TrowData As DataRow In Tbls2.Rows

    '                ' Cek Tabung
    '                Dim Tgrouping As DataTable = ReadSQL("SELECT distinct Tabung,TabungRef FROM MasterLab WHERE TindakanID in (SELECT distinct TindakanID FROM TransaksiLabDetail WHERE TransLabID='" & TrowData("TransLabID").ToString.Trim & "') and TabungRef is not null and Tabung like '%tabung%' order by Tabung ")

    '                If Tgrouping.Rows.Count > 0 Then
    '                    Dim Ttemp As String = ""
    '                    If TrowData("NoUrut").ToString.Contains("L") = True Then
    '                        Ttemp = Strings.Replace(TrowData("NoUrut").ToString.Trim, "L", "8")
    '                    ElseIf TrowData("NoUrut").ToString.Contains("M") = True Then
    '                        Ttemp = Strings.Replace(TrowData("NoUrut").ToString.Trim, "M", "9")
    '                    Else
    '                        Ttemp = TrowData("NoUrut").ToString.Trim
    '                    End If

    '                    ' Pengaman agar Len - 2 tidak error
    '                    If Ttemp.Length > 2 Then
    '                        barcode = KodeBarcode & Strings.Right(Ttemp, Len(Ttemp) - 2)
    '                    Else
    '                        barcode = KodeBarcode & Ttemp
    '                    End If

    '                    For Each Treply As DataRow In Tgrouping.Rows
    '                        ' Jangan pakai sleep di sini, hapus file dulu
    '                        If System.IO.File.Exists(Ttx) = True Then System.IO.File.Delete(Ttx)

    '                        Dim objStreamWriter As StreamWriter = New StreamWriter(Ttx)
    '                        objStreamWriter.WriteLine("<xpml><page quantity='0' pitch='29.3 mm'></xpml>I8,A")
    '                        objStreamWriter.WriteLine("ZN")
    '                        objStreamWriter.WriteLine("q275")
    '                        objStreamWriter.WriteLine("S3")
    '                        objStreamWriter.WriteLine("O")
    '                        objStreamWriter.WriteLine("JF")
    '                        objStreamWriter.WriteLine("D9")
    '                        objStreamWriter.WriteLine("ZT")
    '                        objStreamWriter.WriteLine("Q234,B24")
    '                        objStreamWriter.WriteLine("KI80")
    '                        objStreamWriter.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='29.3 mm'></xpml>N")

    '                        If Treply("TabungRef").ToString <> "" Then
    '                            objStreamWriter.WriteLine("B290,177,2,1,2,4,97,N,""" & barcode & Treply("TabungRef").ToString & """")
    '                        Else
    '                            objStreamWriter.WriteLine("B290,177,2,1,2,4,97,N,""" & barcode & """")
    '                        End If

    '                        objStreamWriter.WriteLine("A95,217,2,3,1,1,N,""""""")
    '                        objStreamWriter.WriteLine("A95,30,2,3,1,1,N,""" & Treply("Tabung").ToString & """")
    '                        objStreamWriter.WriteLine("A290,54,2,2,1,1,N,""" & TrowData("Nama").ToString.Trim & """")
    '                        objStreamWriter.WriteLine("A290,30,2,2,1,1,N,""" & TrowData("TglLahir").ToString.Trim & " / " & TrowData("JenisKelamin").ToString.Trim & """")

    '                        If Treply("TabungRef").ToString <> "" Then
    '                            objStreamWriter.WriteLine("A290,217,2,3,1,1,N,""" & barcode & Treply("TabungRef").ToString & """")
    '                        Else
    '                            objStreamWriter.WriteLine("A290,217,2,3,1,1,N,""" & barcode & """")
    '                        End If

    '                        objStreamWriter.WriteLine("P1")
    '                        objStreamWriter.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
    '                        objStreamWriter.Close()

    '                        ' Eksekusi cetak tabung
    '                        Process.Start(Tpathprf & "PrFile32.exe ", Ttx)

    '                        ' JEDA AMAN agar proses tabung masuk memori printer sebelum lanjut (PENTING!)
    '                        System.Threading.Thread.Sleep(1000)
    '                    Next
    '                End If

    '                ' =========================================================
    '                ' Cetak Barcode InBody
    '                ' =========================================================
    '                If CheckBoxInbody.Checked = True Then
    '                    Dim TtxInBody As String = Tpos & "OutputInBody.txt"
    '                    Dim barcodeInBody As String = TrowData("NoUrut").ToString.Trim

    '                    If System.IO.File.Exists(TtxInBody) Then System.IO.File.Delete(TtxInBody)

    '                    Using writer As New StreamWriter(TtxInBody, False)
    '                        writer.WriteLine("<xpml><page quantity='0' pitch='29.3 mm'></xpml>I8,A")
    '                        writer.WriteLine("ZN")
    '                        writer.WriteLine("q275")
    '                        writer.WriteLine("S3")
    '                        writer.WriteLine("O")
    '                        writer.WriteLine("JF")
    '                        writer.WriteLine("D9")
    '                        writer.WriteLine("ZT")
    '                        writer.WriteLine("Q234,B24")
    '                        writer.WriteLine("KI80")
    '                        writer.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='29.3 mm'></xpml>N")
    '                        writer.WriteLine("B290,177,2,1,2,4,97,N,""" & barcodeInBody & """")
    '                        writer.WriteLine("A95,30,2,3,1,1,N,""InBody""")
    '                        writer.WriteLine("A290,54,2,2,1,1,N,""" & TrowData("Nama").ToString.Trim & """")
    '                        writer.WriteLine("A290,30,2,2,1,1,N,""" & TrowData("TglLahir").ToString.Trim & " / " & TrowData("JenisKelamin").ToString.Trim & """")
    '                        writer.WriteLine("A290,217,2,3,1,1,N,""" & barcodeInBody & """")
    '                        writer.WriteLine("P1")
    '                        writer.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
    '                    End Using

    '                    ' Eksekusi cetak Inbody
    '                    Process.Start(Tpathprf & "PrFile32.exe ", TtxInBody)

    '                    ' JEDA AMAN jika loop berlanjut ke pasien lain
    '                    System.Threading.Thread.Sleep(1000)
    '                End If

    '                ' Update Status
    '                If IsDBNull(TrowData("LabSamplingTime")) = True Then
    '                    WriteSQL("update TransaksiLab set SendKeu=1, [Status]='CHECK', LabSamplingTime=getdate() WHERE TransLabID='" & TrowData("TransLabID").ToString.Trim & "' ", 4)
    '                Else
    '                    WriteSQL("update TransaksiLab set SendKeu=1, [Status]='CHECK' WHERE TransLabID='" & TrowData("TransLabID").ToString.Trim & "' ", 4)
    '                End If
    '            Next
    '        End If

    '        CetakBarcodeToolStripMenuItem.Enabled = True
    '        BarcodeTambahanToolStripMenuItem.Enabled = True
    '    Catch ex As Exception
    '        CetakBarcodeToolStripMenuItem.Enabled = True
    '        BarcodeTambahanToolStripMenuItem.Enabled = True
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Private Sub CetakBarcodeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CetakBarcodeToolStripMenuItem.Click
        CetakBarcodeToolStripMenuItem.Enabled = False
        BarcodeTambahanToolStripMenuItem.Enabled = False

        Dim Tpos As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='PathBarcode'")
        Dim KodeBarcode As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='KodeBarcode'")
        Dim Tpathprf As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='Pathprf'")
        Dim Ttx As String = Tpos & "Output.txt"
        Dim barcode As String = ""

        Try
            Dim NoUrut As String = ""
            If rdNonMCU.Checked = True Then
                NoUrut = "(" & txTransLabID1.Text & ")"
            ElseIf rdMCU.Checked = True Then
                Dim TblsMCU As DataTable = gridlab.DataSource
                NoUrut = ""
                Dim TtempMCU As String = "("
                For Each TrowMCU As DataRow In TblsMCU.Rows
                    TtempMCU = TtempMCU & "'" & TrowMCU("TransLabID").ToString.Trim & "',"
                Next
                NoUrut = Strings.Left(TtempMCU, TtempMCU.Length - 1) & ")"
            End If

            Dim Tbls2 As DataTable = ReadSQL("SELECT a.NoUrut, a.TransLabID, c.Nama, c.TglLahir, c.JenisKelamin, a.LabSamplingTime " & _
                                             "FROM TransaksiLab a " & _
                                             "LEFT JOIN MasterPasien c on c.NoRekamMedis = a.IDInternet " & _
                                             "WHERE a.TransLabID in " & NoUrut & "")
            If Tbls2.Rows.Count > 0 Then
                For Each TrowData As DataRow In Tbls2.Rows

                    ' ===================================================================================
                    ' 1. PROSES BERDIRI SENDIRI: CETAK 1 BUAH QR CODE AKTIVO (JIKA DICENTANG)
                    ' ===================================================================================
                    If CheckBoxAktivo.Checked = True Then
                        ' Hitung Usia Pasien
                        Dim usia As Integer = 0
                        If Not IsDBNull(TrowData("TglLahir")) Then
                            Dim tglLahir As Date = CDate(TrowData("TglLahir"))
                            usia = DateTime.Now.Year - tglLahir.Year
                            If DateTime.Now < tglLahir.AddYears(usia) Then usia -= 1
                        End If

                        ' Standarisasi Gender (Male / Female)
                        Dim gender As String = TrowData("JenisKelamin").ToString.Trim.ToUpper()
                        If gender.Contains("L") Or gender.Contains("PRIA") Or gender.Contains("MALE") Then
                            gender = "Male"
                        Else
                            gender = "Female"
                        End If

                        ' Susun data string format Aktivo
                        Dim qrContent As String = TrowData("NoUrut").ToString.Trim & "#" & _
                                                  TrowData("Nama").ToString.Trim & "#" & _
                                                  usia.ToString() & "#" & _
                                                  gender

                        Dim TtxAktivo As String = Tpos & "OutputAktivo.txt"
                        If System.IO.File.Exists(TtxAktivo) = True Then System.IO.File.Delete(TtxAktivo)

                        Dim writerAktivo As New StreamWriter(TtxAktivo)
                        writerAktivo.WriteLine("<xpml><page quantity='0' pitch='29.3 mm'></xpml>I8,A")
                        writerAktivo.WriteLine("ZN")
                        writerAktivo.WriteLine("q275")
                        writerAktivo.WriteLine("S3")
                        writerAktivo.WriteLine("O")
                        writerAktivo.WriteLine("JF")
                        writerAktivo.WriteLine("D9")
                        writerAktivo.WriteLine("ZT")
                        writerAktivo.WriteLine("Q234,B24")
                        writerAktivo.WriteLine("KI80")
                        writerAktivo.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='29.3 mm'></xpml>N")

                        ' ===================================================================================
                        ' ALTERNATIF JALUR PPLA: Sintaks QR Code murni Printer Argox PPLA 
                        ' Format: 1W00[Variabel_Ukuran_Mulai_Dari_1_Sampai_9]000[Y_pos][X_pos][Data]
                        ' ===================================================================================
                        writerAktivo.WriteLine("W1A020030NM03," & qrContent)
                        ' ===================================================================================

                        writerAktivo.WriteLine("A95,217,2,3,1,1,N," & Chr(34) & Chr(34))
                        writerAktivo.WriteLine("A95,30,2,3,1,1,N,""QR P.Fisik""")
                        writerAktivo.WriteLine("A290,54,2,2,1,1,N,""" & TrowData("Nama").ToString.Trim & """")

                        Dim tglTampil As String = If(IsDBNull(TrowData("TglLahir")), "", CDate(TrowData("TglLahir")).ToString("dd MMM yyyy"))
                        writerAktivo.WriteLine("A290,30,2,2,1,1,N,""" & tglTampil & " / " & TrowData("JenisKelamin").ToString.Trim & """")
                        writerAktivo.WriteLine("A290,217,2,3,1,1,N,""" & TrowData("NoUrut").ToString.Trim & """")
                        writerAktivo.WriteLine("P1")
                        writerAktivo.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
                        writerAktivo.Close()

                        ' Tembak ke printer khusus untuk file QR Aktivo (Hanya keluar 1 lembar)
                        Process.Start(Tpathprf & "PrFile32.exe ", TtxAktivo)
                        System.Threading.Thread.Sleep(1000)
                    End If
                    ' ===================================================================================


                    ' 2. PROSES BAWAAN ASLI: CETAK BARCODE GARIS UNTUK SELURUH TABUNG LAB (TETAP JALAN)
                    Dim Tgrouping As DataTable = ReadSQL("SELECT distinct Tabung,TabungRef FROM MasterLab WHERE TindakanID in (SELECT distinct TindakanID FROM TransaksiLabDetail WHERE TransLabID='" & TrowData("TransLabID").ToString.Trim & "') and TabungRef is not null and Tabung like '%tabung%' order by Tabung ")

                    If Tgrouping.Rows.Count > 0 Then
                        Dim Ttemp As String = ""
                        If TrowData("NoUrut").ToString.Contains("L") = True Then
                            Ttemp = Strings.Replace(TrowData("NoUrut").ToString.Trim, "L", "8")
                        ElseIf TrowData("NoUrut").ToString.Contains("M") = True Then
                            Ttemp = Strings.Replace(TrowData("NoUrut").ToString.Trim, "M", "9")
                        Else
                            Ttemp = TrowData("NoUrut").ToString.Trim
                        End If

                        If Ttemp.Length > 2 Then
                            barcode = KodeBarcode & Strings.Right(Ttemp, Len(Ttemp) - 2)
                        Else
                            barcode = KodeBarcode & Ttemp
                        End If

                        For Each Treply As DataRow In Tgrouping.Rows
                            If System.IO.File.Exists(Ttx) = True Then System.IO.File.Delete(Ttx)

                            Dim objStreamWriter As StreamWriter = New StreamWriter(Ttx)
                            objStreamWriter.WriteLine("<xpml><page quantity='0' pitch='29.3 mm'></xpml>I8,A")
                            objStreamWriter.WriteLine("ZN")
                            objStreamWriter.WriteLine("q275")
                            objStreamWriter.WriteLine("S3")
                            objStreamWriter.WriteLine("O")
                            objStreamWriter.WriteLine("JF")
                            objStreamWriter.WriteLine("D9")
                            objStreamWriter.WriteLine("ZT")
                            objStreamWriter.WriteLine("Q234,B24")
                            objStreamWriter.WriteLine("KI80")
                            objStreamWriter.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='29.3 mm'></xpml>N")

                            ' Kembali menggunakan Cetak Barcode Garis Bawaan Anda Semula
                            If Treply("TabungRef").ToString <> "" Then
                                objStreamWriter.WriteLine("B290,177,2,1,2,4,97,N,""" & barcode & Treply("TabungRef").ToString & """")
                            Else
                                objStreamWriter.WriteLine("B290,177,2,1,2,4,97,N,""" & barcode & """")
                            End If

                            objStreamWriter.WriteLine("A95,217,2,3,1,1,N," & Chr(34) & Chr(34))
                            objStreamWriter.WriteLine("A95,30,2,3,1,1,N,""" & Treply("Tabung").ToString & """")
                            objStreamWriter.WriteLine("A290,54,2,2,1,1,N,""" & TrowData("Nama").ToString.Trim & """")

                            Dim tglTampil As String = If(IsDBNull(TrowData("TglLahir")), "", CDate(TrowData("TglLahir")).ToString("dd MMM yyyy"))
                            objStreamWriter.WriteLine("A290,30,2,2,1,1,N,""" & tglTampil & " / " & TrowData("JenisKelamin").ToString.Trim & """")
                            objStreamWriter.WriteLine("A290,217,2,3,1,1,N,""" & TrowData("NoUrut").ToString.Trim & """")

                            objStreamWriter.WriteLine("P1")
                            objStreamWriter.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
                            objStreamWriter.Close()

                            Process.Start(Tpathprf & "PrFile32.exe ", Ttx)
                            System.Threading.Thread.Sleep(1000)
                        Next
                    End If

                    ' --- 3. Cetak Barcode InBody (Jika Dicentang) ---
                    If CheckBoxInbody.Checked = True Then
                        Dim TtxInBody As String = Tpos & "OutputInBody.txt"
                        Dim barcodeInBody As String = TrowData("NoUrut").ToString.Trim

                        If System.IO.File.Exists(TtxInBody) Then System.IO.File.Delete(TtxInBody)

                        Using writer As New StreamWriter(TtxInBody, False)
                            writer.WriteLine("<xpml><page quantity='0' pitch='29.3 mm'></xpml>I8,A")
                            writer.WriteLine("ZN")
                            writer.WriteLine("q275")
                            writer.WriteLine("S3")
                            writer.WriteLine("O")
                            writer.WriteLine("JF")
                            writer.WriteLine("D9")
                            writer.WriteLine("ZT")
                            writer.WriteLine("Q234,B24")
                            writer.WriteLine("KI80")
                            writer.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='29.3 mm'></xpml>N")
                            writer.WriteLine("B290,177,2,1,2,4,97,N,""" & barcodeInBody & """")
                            writer.WriteLine("A95,30,2,3,1,1,N,""" & "InBody" & """")
                            writer.WriteLine("A290,54,2,2,1,1,N,""" & TrowData("Nama").ToString.Trim & """")
                            writer.WriteLine("A290,30,2,2,1,1,N,""" & TrowData("TglLahir").ToString.Trim & " / " & TrowData("JenisKelamin").ToString.Trim & """")
                            writer.WriteLine("A290,217,2,3,1,1,N,""" & barcodeInBody & """")
                            writer.WriteLine("P1")
                            writer.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
                        End Using

                        Process.Start(Tpathprf & "PrFile32.exe ", TtxInBody)
                        System.Threading.Thread.Sleep(1000)
                    End If

                    ' Update Status Database
                    If IsDBNull(TrowData("LabSamplingTime")) = True Then
                        WriteSQL("update TransaksiLab set SendKeu=1, [Status]='CHECK', LabSamplingTime=getdate() WHERE TransLabID='" & TrowData("TransLabID").ToString.Trim & "' ", 4)
                    Else
                        WriteSQL("update TransaksiLab set SendKeu=1, [Status]='CHECK' WHERE TransLabID='" & TrowData("TransLabID").ToString.Trim & "' ", 4)
                    End If
                Next
            End If

            CetakBarcodeToolStripMenuItem.Enabled = True
            BarcodeTambahanToolStripMenuItem.Enabled = True
        Catch ex As Exception
            CetakBarcodeToolStripMenuItem.Enabled = True
            BarcodeTambahanToolStripMenuItem.Enabled = True
            MsgBox(ex.Message)
        End Try
    End Sub

    'Before Update
    'Private Sub CetakBarcodeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CetakBarcodeToolStripMenuItem.Click
    '    CetakBarcodeToolStripMenuItem.Enabled = False
    '    BarcodeTambahanToolStripMenuItem.Enabled = False

    '    Dim Tpos As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='PathBarcode'")
    '    Dim KodeBarcode As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='KodeBarcode'")
    '    Dim Tpathprf As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='Pathprf'")
    '    Dim Ttx As String = Tpos & "Output.txt"
    '    Dim barcode As String = ""

    '    Try
    '        Dim NoUrut As String = ""
    '        If rdNonMCU.Checked = True Then
    '            NoUrut = "(" & txTransLabID1.Text & ")"
    '        ElseIf rdMCU.Checked = True Then
    '            Dim TblsMCU As DataTable = gridlab.DataSource
    '            NoUrut = ""
    '            Dim Ttemp As String = "("
    '            For Each TrowMCU As DataRow In TblsMCU.Rows
    '                Ttemp = Ttemp & "'" & TrowMCU("TransLabID").ToString.Trim & "',"
    '            Next
    '            NoUrut = Strings.Left(Ttemp, Ttemp.Length - 1) & ")"
    '        End If

    '        Dim Tbls2 As DataTable = ReadSQL("SELECT a.NoUrut, a.TransLabID, c.Nama, CONVERT(varchar(11), c.TglLahir,106) as TglLahir, c.JenisKelamin, a.LabSamplingTime " & _
    '                                         "FROM TransaksiLab a " & _
    '                                         "LEFT JOIN MasterPasien c on c.NoRekamMedis = a.IDInternet " & _
    '                                         "WHERE a.TransLabID in " & NoUrut & "")
    '        If Tbls2.Rows.Count > 0 Then
    '            For Each TrowData As DataRow In Tbls2.Rows
    '                Dim Tgrouping As DataTable = ReadSQL("SELECT distinct Tabung,TabungRef FROM MasterLab WHERE TindakanID in (SELECT distinct TindakanID FROM TransaksiLabDetail WHERE TransLabID='" & TrowData("TransLabID").ToString.Trim & "') and TabungRef is not null and Tabung like '%tabung%' order by Tabung ")

    '                If Tgrouping.Rows.Count > 0 Then
    '                    Dim Ttemp As String = ""
    '                    If TrowData("NoUrut").ToString.Contains("L") = True Then
    '                        Ttemp = Strings.Replace(TrowData("NoUrut").ToString.Trim, "L", "8")
    '                    ElseIf TrowData("NoUrut").ToString.Contains("M") = True Then
    '                        Ttemp = Strings.Replace(TrowData("NoUrut").ToString.Trim, "M", "9")
    '                    End If

    '                    barcode = KodeBarcode & Strings.Right(Ttemp.ToString.Trim, Len(Ttemp.ToString.Trim) - 2)

    '                    For Each Treply As DataRow In Tgrouping.Rows

    '                        System.Threading.Thread.Sleep(500)

    '                        If System.IO.File.Exists(Ttx) = True Then System.IO.File.Delete(Ttx)

    '                        Dim objStreamWriter As StreamWriter
    '                        objStreamWriter = New StreamWriter(Ttx)

    '                        objStreamWriter.WriteLine("<xpml><page quantity='0' pitch='29.3 mm'></xpml>I8,A")
    '                        objStreamWriter.WriteLine("ZN")
    '                        objStreamWriter.WriteLine("q275")
    '                        objStreamWriter.WriteLine("S3")
    '                        objStreamWriter.WriteLine("O")
    '                        objStreamWriter.WriteLine("JF")
    '                        objStreamWriter.WriteLine("D9")
    '                        objStreamWriter.WriteLine("ZT")
    '                        objStreamWriter.WriteLine("Q234,B24")
    '                        objStreamWriter.WriteLine("KI80")
    '                        objStreamWriter.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='29.3 mm'></xpml>N")

    '                        If Treply("TabungRef").ToString <> "" Then
    '                            objStreamWriter.WriteLine("B290,177,2,1,2,4,97,N,""" & barcode & Treply("TabungRef").ToString & """")
    '                        Else
    '                            objStreamWriter.WriteLine("B290,177,2,1,2,4,97,N,""" & barcode & """")
    '                        End If

    '                        objStreamWriter.WriteLine("A95,217,2,3,1,1,N,""""""")
    '                        objStreamWriter.WriteLine("A95,30,2,3,1,1,N,""" & Treply("Tabung").ToString & """")
    '                        objStreamWriter.WriteLine("A290,54,2,2,1,1,N,""" & TrowData("Nama").ToString.Trim & """")
    '                        objStreamWriter.WriteLine("A290,30,2,2,1,1,N,""" & TrowData("TglLahir").ToString.Trim & " / " & TrowData("JenisKelamin").ToString.Trim & """")

    '                        If Treply("TabungRef").ToString <> "" Then
    '                            objStreamWriter.WriteLine("A290,217,2,3,1,1,N,""" & barcode & Treply("TabungRef").ToString & """")
    '                        Else
    '                            objStreamWriter.WriteLine("A290,217,2,3,1,1,N,""" & barcode & """")
    '                        End If

    '                        objStreamWriter.WriteLine("P1")
    '                        objStreamWriter.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
    '                        objStreamWriter.Close()
    '                        Process.Start(Tpathprf & "PrFile32.exe ", Ttx)
    '                    Next

    '                    If IsDBNull(TrowData("LabSamplingTime")) = True Then
    '                        WriteSQL("update TransaksiLab set SendKeu=1, [Status]='CHECK', LabSamplingTime=getdate() WHERE TransLabID='" & TrowData("TransLabID").ToString.Trim & "' ", 4)
    '                    Else
    '                        WriteSQL("update TransaksiLab set SendKeu=1, [Status]='CHECK' WHERE TransLabID='" & TrowData("TransLabID").ToString.Trim & "' ", 4)
    '                    End If
    '                End If
    '            Next
    '        End If

    '        CetakBarcodeToolStripMenuItem.Enabled = True
    '        BarcodeTambahanToolStripMenuItem.Enabled = True
    '    Catch ex As Exception
    '        CetakBarcodeToolStripMenuItem.Enabled = True
    '        BarcodeTambahanToolStripMenuItem.Enabled = True
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Private Sub BarcodeTambahanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarcodeTambahanToolStripMenuItem.Click
        CetakBarcodeToolStripMenuItem.Enabled = False
        BarcodeTambahanToolStripMenuItem.Enabled = False

        Dim Tpos As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='PathBarcode'")
        Dim KodeBarcode As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='KodeBarcode'")
        Dim Tpathprf As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='Pathprf'")
        Dim Ttx As String = Tpos & "Output.txt"
        Dim barcode As String = ""
        Dim totalrow As Integer = 0

        Dim Tinput As String = InputBox("Tambahan Cetakan Print Barcode : ", "Print Barcode", 2)
        If IsNumeric(Tinput) = False Then
            MsgBox("Masukkan Jumlah Barcode yang diprint.", MsgBoxStyle.Exclamation, "Warning!")
            ClearHeader()
            Exit Sub
        End If

        If CInt(Tinput) = 0 Then
            ClearHeader()
            Exit Sub
        End If

        If CInt(Tinput) > 15 Then
            MsgBox("Cetakan tidak boleh lebih dari 15.", MsgBoxStyle.Exclamation, "Warning!")
            ClearHeader()
            Exit Sub
        End If

        Try
            If Tinput > 0 Then
                Dim NoUrut As String = ""
                If rdNonMCU.Checked = True Then
                    NoUrut = "(" & txTransLabID1.Text & ")"
                ElseIf rdMCU.Checked = True Then
                    Dim TblsMCU As DataTable = gridlab.DataSource
                    NoUrut = ""
                    Dim Ttemp As String = "("
                    For Each TrowMCU As DataRow In TblsMCU.Rows
                        Ttemp = Ttemp & "'" & TrowMCU("TransLabID").ToString.Trim & "',"
                        totalrow = totalrow + 1
                    Next
                    NoUrut = Strings.Left(Ttemp, Ttemp.Length - 1) & ")"
                End If

                If totalrow * Tinput > 500 Then
                    MsgBox("Total barcode tidak boleh lebih dari 500 cetakan, total barcode anda adalah " & totalrow & " data x " & Tinput & " cetakan = " & totalrow * Tinput & " cetakan barcode.", MsgBoxStyle.Exclamation, "Warning!")
                    Exit Sub
                End If

                Dim Tbls2 As DataTable = ReadSQL("SELECT a.NoUrut,a.TransLabID,c.Nama,CONVERT(varchar(11),c.TglLahir,106) as TglLahir,c.JenisKelamin, a.LabSamplingTime " & _
                                                 "FROM TransaksiLab a " & _
                                                 "LEFT JOIN MasterPasien c on c.NoRekamMedis=a.IDInternet " & _
                                                 "WHERE a.TransLabID in " & NoUrut & "")
                If Tbls2.Rows.Count > 0 Then
                    For Each TrowData As DataRow In Tbls2.Rows
                        Dim tabung As Boolean = False
                        If cbtabung.Checked = True Then
                            'Cek Tabung
                            Dim Tgrouping As DataTable = ReadSQL("SELECT distinct Tabung,TabungRef FROM MasterLab WHERE TindakanID in (SELECT distinct TindakanID FROM TransaksiLabDetail WHERE TransLabID='" & TrowData("TransLabID").ToString.Trim & "') and TabungRef is not null and Tabung like '%tabung%' order by Tabung ")

                            If Tgrouping.Rows.Count > 0 Then tabung = True
                        End If

                        If tabung = True Then CetakTabung(TrowData("NoUrut").ToString.Trim)

                        Dim Tstrtemp As String = ""
                        If TrowData("NoUrut").ToString.Contains("L") = True Then
                            Tstrtemp = Strings.Replace(TrowData("NoUrut").ToString.Trim, "L", "8")
                        ElseIf TrowData("NoUrut").ToString.Contains("M") = True Then
                            Tstrtemp = Strings.Replace(TrowData("NoUrut").ToString.Trim, "M", "9")
                        End If

                        barcode = KodeBarcode & Strings.Right(Tstrtemp.ToString.Trim, Len(Tstrtemp.ToString.Trim) - 2)

                        If tabung = True Then
                            System.Threading.Thread.Sleep(3000)
                        Else
                            System.Threading.Thread.Sleep(500)
                        End If

                        For i As Integer = 0 To CInt(Tinput) - 1
                            If System.IO.File.Exists(Ttx) = True Then System.IO.File.Delete(Ttx)
                            Dim objStreamWriter As StreamWriter
                            objStreamWriter = New StreamWriter(Ttx)
                            objStreamWriter.WriteLine("<xpml><page quantity='0' pitch='29.3 mm'></xpml>I8,A")
                            objStreamWriter.WriteLine("ZN")
                            objStreamWriter.WriteLine("q275")
                            objStreamWriter.WriteLine("S3")
                            objStreamWriter.WriteLine("O")
                            objStreamWriter.WriteLine("JF")
                            objStreamWriter.WriteLine("D9")
                            objStreamWriter.WriteLine("ZT")
                            objStreamWriter.WriteLine("Q234,B24")
                            objStreamWriter.WriteLine("KI80")
                            objStreamWriter.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='29.3 mm'></xpml>N")
                            objStreamWriter.WriteLine("B290,177,2,1,2,4,97,N,""" & barcode & """")
                            objStreamWriter.WriteLine("A95,217,2,3,1,1,N,""""""")
                            objStreamWriter.WriteLine("A290,54,2,2,1,1,N,""" & TrowData("Nama").ToString.Trim & """")
                            objStreamWriter.WriteLine("A290,30,2,2,1,1,N,""" & TrowData("TglLahir").ToString.Trim & " / " & TrowData("JenisKelamin").ToString.Trim & """")
                            objStreamWriter.WriteLine("A290,217,2,3,1,1,N,""" & barcode & """")
                            objStreamWriter.WriteLine("P1")
                            objStreamWriter.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
                            objStreamWriter.Close()

                            'If tabung = True Then System.Threading.Thread.Sleep(1000)
                            If tabung = True Then
                                System.Threading.Thread.Sleep(1000)
                            Else
                                System.Threading.Thread.Sleep(500)
                            End If

                            Process.Start(Tpathprf & "PrFile32.exe ", Ttx)
                        Next

                        'Cetak Barcode InBody
                        If CheckBoxInbody.Checked = True Then
                            Dim TtxInBody As String = Tpos & "OutputInBody.txt"
                            Dim barcodeInBody As String = TrowData("NoUrut").ToString.Trim

                            If System.IO.File.Exists(TtxInBody) Then
                                System.IO.File.Delete(TtxInBody)
                            End If

                            Using writer As New StreamWriter(TtxInBody, False)
                                writer.WriteLine("<xpml><page quantity='0' pitch='29.3 mm'></xpml>I8,A")
                                writer.WriteLine("ZN")
                                writer.WriteLine("q275")
                                writer.WriteLine("S3")
                                writer.WriteLine("O")
                                writer.WriteLine("JF")
                                writer.WriteLine("D9")
                                writer.WriteLine("ZT")
                                writer.WriteLine("Q234,B24")
                                writer.WriteLine("KI80")
                                writer.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='29.3 mm'></xpml>N")

                                'Barcode menggunakan NoUrut asli
                                writer.WriteLine("B290,177,2,1,2,4,97,N,""" & barcodeInBody & """")

                                'Label INBODY
                                writer.WriteLine("A95,30,2,3,1,1,N,""InBody""")

                                'Data Pasien
                                writer.WriteLine("A290,54,2,2,1,1,N,""" & TrowData("Nama").ToString.Trim & """")
                                writer.WriteLine("A290,30,2,2,1,1,N,""" & _
                                                 TrowData("TglLahir").ToString.Trim & " / " & _
                                                 TrowData("JenisKelamin").ToString.Trim & """")

                                'Teks Barcode
                                writer.WriteLine("A290,217,2,3,1,1,N,""" & barcodeInBody & """")

                                writer.WriteLine("P1")
                                writer.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
                            End Using

                            System.Threading.Thread.Sleep(500)
                            Process.Start(Tpathprf & "PrFile32.exe ", TtxInBody)
                        End If

                        'Flag
                        If IsDBNull(TrowData("LabSamplingTime")) = True Then
                            WriteSQL("update TransaksiLab set SendKeu=1, [Status]='CHECK', LabSamplingTime=getdate() WHERE TransLabID='" & TrowData("TransLabID").ToString.Trim & "' ", 4)
                        Else
                            WriteSQL("update TransaksiLab set SendKeu=1, [Status]='CHECK' WHERE TransLabID='" & TrowData("TransLabID").ToString.Trim & "' ", 4)
                        End If

                        If tabung = True Then System.Threading.Thread.Sleep(3000)
                    Next
                Else
                    MsgBox("Tidak ada data yang di barcode.", MsgBoxStyle.Exclamation, "Warning!")
                    Exit Sub
                End If
            End If

            CetakBarcodeToolStripMenuItem.Enabled = True
            BarcodeTambahanToolStripMenuItem.Enabled = True
        Catch ex As Exception
            CetakBarcodeToolStripMenuItem.Enabled = True
            BarcodeTambahanToolStripMenuItem.Enabled = True

            If MsgBox(" Batal untuk Cetak Barcode tambahan ? ", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                Exit Sub
            Else
                MsgBox("Ulangi proses ketika siap")
            End If
        End Try
    End Sub

    Private Sub CetakTabung(ByVal NoUrut As String)
        Dim Tpos As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='PathBarcode'")
        Dim KodeBarcode As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='KodeBarcode'")
        Dim Tpathprf As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='Pathprf'")
        Dim Ttx As String = Tpos & "OutputTabung.txt"
        Dim barcode As String = ""

        Try
            Dim Tbls2 As DataTable = ReadSQL("SELECT a.NoUrut,a.TransLabID,c.Nama,CONVERT(varchar(11),c.TglLahir,106) as TglLahir,c.JenisKelamin, a.LabSamplingTime " & _
                                             "FROM TransaksiLab a " & _
                                             "LEFT JOIN MasterPasien c on c.NoRekamMedis = a.IDInternet " & _
                                             "WHERE nourut = '" & NoUrut & "'")
            If Tbls2.Rows.Count > 0 Then
                For Each TrowData As DataRow In Tbls2.Rows
                    Dim Tgrouping As DataTable = ReadSQL("SELECT distinct Tabung,TabungRef FROM MasterLab WHERE TindakanID in (SELECT distinct TindakanID FROM TransaksiLabDetail WHERE TransLabID='" & TrowData("TransLabID").ToString.Trim & "') and TabungRef is not null and Tabung like '%tabung%' order by Tabung ")

                    If Tgrouping.Rows.Count > 0 Then
                        Dim Ttemp As String = ""
                        If TrowData("NoUrut").ToString.Contains("L") = True Then
                            Ttemp = Strings.Replace(TrowData("NoUrut").ToString.Trim, "L", "8")
                        ElseIf TrowData("NoUrut").ToString.Contains("M") = True Then
                            Ttemp = Strings.Replace(TrowData("NoUrut").ToString.Trim, "M", "9")
                        End If

                        barcode = KodeBarcode & Strings.Right(Ttemp.ToString.Trim, Len(Ttemp.ToString.Trim) - 2)

                        For Each Treply As DataRow In Tgrouping.Rows

                            System.Threading.Thread.Sleep(500)

                            If System.IO.File.Exists(Ttx) = True Then System.IO.File.Delete(Ttx)

                            Dim objStreamWriter As StreamWriter
                            objStreamWriter = New StreamWriter(Ttx)

                            objStreamWriter.WriteLine("<xpml><page quantity='0' pitch='29.3 mm'></xpml>I8,A")
                            objStreamWriter.WriteLine("ZN")
                            objStreamWriter.WriteLine("q275")
                            objStreamWriter.WriteLine("S3")
                            objStreamWriter.WriteLine("O")
                            objStreamWriter.WriteLine("JF")
                            objStreamWriter.WriteLine("D9")
                            objStreamWriter.WriteLine("ZT")
                            objStreamWriter.WriteLine("Q234,B24")
                            objStreamWriter.WriteLine("KI80")
                            objStreamWriter.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='29.3 mm'></xpml>N")

                            If Treply("TabungRef").ToString <> "" Then
                                objStreamWriter.WriteLine("B290,177,2,1,2,4,97,N,""" & barcode & Treply("TabungRef").ToString & """")
                            Else
                                objStreamWriter.WriteLine("B290,177,2,1,2,4,97,N,""" & barcode & """")
                            End If

                            objStreamWriter.WriteLine("A95,217,2,3,1,1,N,""""""")
                            objStreamWriter.WriteLine("A95,30,2,3,1,1,N,""" & Treply("Tabung").ToString & """")
                            objStreamWriter.WriteLine("A290,54,2,2,1,1,N,""" & TrowData("Nama").ToString.Trim & """")
                            objStreamWriter.WriteLine("A290,30,2,2,1,1,N,""" & TrowData("TglLahir").ToString.Trim & " / " & TrowData("JenisKelamin").ToString.Trim & """")

                            If Treply("TabungRef").ToString <> "" Then
                                objStreamWriter.WriteLine("A290,217,2,3,1,1,N,""" & barcode & Treply("TabungRef").ToString & """")
                            Else
                                objStreamWriter.WriteLine("A290,217,2,3,1,1,N,""" & barcode & """")
                            End If

                            objStreamWriter.WriteLine("P1")
                            objStreamWriter.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
                            objStreamWriter.Close()
                            Process.Start(Tpathprf & "PrFile32.exe ", Ttx)
                        Next
                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Private Sub buttambahpasien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttambahpasien.Click
    '    Dim Takhir As Date = DateSerial(DateAndTime.Now.Year, DateAndTime.Now.Month, DateAndTime.Now.Day).AddDays(30)
    '    Dim Tawal As Date = DateAdd(DateInterval.Day, -90, Takhir.Date)
    '    Find.Show()
    '    Find.Query("SELECT a.TransLabID, a.NoUrut, a.IDInternet, b.Nama, b.TglLahir, a.TglLab, a.Status " & _
    '               "FROM TransaksiLab a " & _
    '               "LEFT JOIN MasterPasien  b on a.idinternet = b.NoRekamMedis " & _
    '               "WHERE a.ClosedTransaksi=1 and Status in ('SAMPLE','CHECK') and CONVERT(date, Tgllab) between '" & Format(Tawal.Date, "MM/dd/yyyy") & "' and '" & Format(Takhir.Date, "MM/dd/yyyy") & "'  and a.deleted<>1 ", " order by a.NoUrut desc ", "FindTransaksiBarcode", 0)
    'End Sub

    Private Sub buttambahpasien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttambahpasien.Click
        Dim Takhir As Date = DateSerial(DateAndTime.Now.Year, DateAndTime.Now.Month, DateAndTime.Now.Day).AddDays(30)
        Dim Tawal As Date = DateAdd(DateInterval.Day, -90, Takhir.Date)

        Find.Show()
        Find.Query("SELECT a.TransLabID, a.NoUrut, a.IDInternet, b.Nama, b.TglLahir, b.NoNIK AS nik, a.TglLab, a.Status " & _
                   "FROM TransaksiLab a " & _
                   "LEFT JOIN MasterPasien b on a.idinternet = b.NoRekamMedis " & _
                   "WHERE a.ClosedTransaksi=1 and Status in ('SAMPLE','CHECK') and CONVERT(date, Tgllab) between '" & Format(Tawal.Date, "MM/dd/yyyy") & "' and '" & Format(Takhir.Date, "MM/dd/yyyy") & "' and a.deleted<>1 ", " order by a.NoUrut desc ", "FindTransaksiBarcode", 0)
    End Sub

    Private Sub rdNonMCU_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdNonMCU.CheckedChanged
        If rdMCU.Checked = True Then
            buttambahpasien.Enabled = False
            buttambahpasienmcu.Enabled = True
            txcompanycode.Focus()
        ElseIf rdNonMCU.Checked = True Then
            buttambahpasien.Enabled = True
            buttambahpasienmcu.Enabled = False
            txTransLabID1.Focus()
        End If
    End Sub

    Private Sub rdMCU_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdMCU.CheckedChanged
        If rdMCU.Checked = True Then
            TabControl1.SelectedIndex = 1
            buttambahpasien.Enabled = False
            buttambahpasienmcu.Enabled = True
            txcompanycode.Focus()
        ElseIf rdNonMCU.Checked = True Then
            TabControl1.SelectedIndex = 0
            buttambahpasien.Enabled = True
            buttambahpasienmcu.Enabled = False
            txTransLabID1.Focus()
        End If
    End Sub

    Private Sub buttambahpasienmcu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttambahpasienmcu.Click
        If txcompanycode.Text = "" Then
            MsgBox("Pilih Company Terlebih Dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Exit Sub
        End If

        Dim Tquery As String = ""
        Dim Tcompany As String = ""
        Dim ConcatCompany As String = ""
        Dim Number1 As String = ""
        Dim Number2 As String = ""
        Dim TrangeNumber As String = ""

        'Set No Urut
        If cbNoUrut.Checked = True Then
            If txNoUrut1.Text.Trim = "" Or txNoUrut2.Text.Trim = "" Or txNoUrut1.Text.Trim = "0" Or txNoUrut2.Text.Trim = "0" Then
                MsgBox("No Urut tidak boleh kosong.", MsgBoxStyle.Exclamation, "Warning!")
                Exit Sub
            ElseIf CDbl(txNoUrut1.Text) > CDbl(txNoUrut2.Text) Then
                MsgBox("Pastikan Inputan No Urut sudah benar.", MsgBoxStyle.Exclamation, "Warning!")
                Exit Sub
            Else
                Number1 = txNoUrut1.Text.ToString().PadLeft(5, "0")
                Number2 = txNoUrut2.Text.ToString().PadLeft(5, "0")
                TrangeNumber = " and (RIGHT(NoUrut, 5) between '" & Number1 & "' and '" & Number2 & "')"
            End If
        End If

        'Set Company
        ConcatCompany = txcompanycode.Text + "-" + txkodecabang.Text
        Tcompany = " and (c.NoJenisBayar = '" & txcompanycode.Text & "' or c.NoJenisBayar='" & ConcatCompany & "')"

        'Query Utama
        Tquery = "SELECT a.TransLabID, a.NoUrut, a.IDInternet, b.Nama, b.TglLahir, a.TglLab, a.Status, CASE WHEN c.NoJenisBayar <> '-' THEN c.NoJenisBayar WHEN c.NoJenisBayar = '-' THEN 'PASIEN UMUM' END AS 'Company' " & _
                 "FROM TransaksiLab a " & _
                 "LEFT JOIN MasterPasien  b on a.idinternet = b.NoRekamMedis " & _
                 "LEFT JOIN TransaksiLabBayar c on c.TransLabID = a.TransLabID " & _
                 "WHERE a.NoUrut like '%" & cmbkodetransaksi.Text & "%' AND a.ClosedTransaksi=1 AND Status in ('SAMPLE','CHECK') AND CONVERT(date, Tgllab) = '" & Format(dtprocess.Value, "MM-dd-yyyy") & "'" & Tcompany & " AND a.deleted<>1 AND c.NoJenisBayar <> '' " & TrangeNumber & " order by a.NoUrut desc"

        Dim TblsNew As DataTable = ReadSQL(Tquery)

        If TblsNew.Rows.Count > 0 Then
            FindMultiple.Show()
            FindMultiple.Query(Tquery, "", "CetakBarcodeSELECTedAll", 2)
        Else
            MsgBox("Tidak ada data yang ditampilkan.", MsgBoxStyle.Exclamation, "Warning!")
            Exit Sub
        End If
    End Sub

    Public Sub LoadPasien(ByRef Trow() As DataRow)
        If Trow.Length <> 0 Then
            CetakBarcodeToolStripMenuItem.Enabled = True
            BarcodeTambahanToolStripMenuItem.Enabled = True

            Dim Tquery As String = ""
            Dim Tstr As String = ""

            Dim Ttemp As String = "("
            For i As Integer = 0 To Trow.Length - 1
                Ttemp = Ttemp & "'" & Trow(i)("TransLabID").ToString.Trim & "',"
            Next
            Tstr = Strings.Left(Ttemp, Ttemp.Length - 1) & ")"

            Tquery = "SELECT ROW_NUMBER() OVER (ORDER BY a.Nourut) AS 'No', a.TransLabID,a.NoUrut,a.IDInternet,b.Nama, CONVERT(DATE, b.TglLahir) AS TglLahir, CONVERT(DATE, a.TglLab) AS TglLab " & _
            "FROM TransaksiLab a " & _
            "LEFT JOIN MasterPasien b on a.idinternet = b.NoRekamMedis " & _
            "WHERE TransLabID in " & Tstr & ""
            gridlab.DataSource = ReadSQL(Tquery)
        Else
            MsgBox("Tidak ada data yang ditampilkan.", MsgBoxStyle.Exclamation, "Warning!")
            Exit Sub
        End If
    End Sub

    Private Sub butfindcompany_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butfindcompany.Click
        Find.Show()
        Find.Query("SELECT IDCompany, CompanyCode, CompanyNama, NoCompany FROM mastercompany a WHERE getdate() between StartDate and EndDate", " ORDER BY a.idcompany desc", "FindCabangCetakBarcode", 2)
    End Sub

    Private Sub cbNoUrut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbNoUrut.CheckedChanged
        If cbNoUrut.Checked = True Then
            txNoUrut1.Enabled = True
            txNoUrut2.Enabled = True
            txNoUrut1.ResetText()
            txNoUrut2.ResetText()
        ElseIf cbNoUrut.Checked = False Then
            txNoUrut1.Enabled = False
            txNoUrut2.Enabled = False
            txNoUrut1.ResetText()
            txNoUrut2.ResetText()
        End If
    End Sub

    Private Sub txNoUrut1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txNoUrut1.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub txNoUrut2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txNoUrut2.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub barcode()
        CetakBarcodeToolStripMenuItem.Enabled = False
        BarcodeTambahanToolStripMenuItem.Enabled = False

        Dim Tpos As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='PathBarcode'")
        Dim KodeBarcode As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='KodeBarcode'")
        Dim Tpathprf As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='Pathprf'")
        Dim Ttx As String = Tpos & "Output.txt"
        Dim barcode As String = ""
        Dim totalrow As Integer = 0

        Dim Tinput As String = InputBox("Tambahan Cetakan Print Barcode : ", "Print Barcode", 2)
        If IsNumeric(Tinput) = False Then
            MsgBox("Masukkan Jumlah Barcode yang diprint.", MsgBoxStyle.Exclamation, "Warning!")
            ClearHeader()
            Exit Sub
        End If

        If CInt(Tinput) = 0 Then
            ClearHeader()
            Exit Sub
        End If

        If CInt(Tinput) > 10 Then
            MsgBox("Cetakan tidak boleh lebih dari 10.", MsgBoxStyle.Exclamation, "Warning!")
            ClearHeader()
            Exit Sub
        End If

        Try
            If Tinput > 0 Then
                Dim NoUrut As String = ""
                If rdNonMCU.Checked = True Then
                    NoUrut = "(" & txTransLabID1.Text & ")"
                ElseIf rdMCU.Checked = True Then
                    Dim TblsMCU As DataTable = gridlab.DataSource
                    NoUrut = ""
                    Dim Ttemp As String = "("
                    For Each TrowMCU As DataRow In TblsMCU.Rows
                        Ttemp = Ttemp & "'" & TrowMCU("TransLabID").ToString.Trim & "',"
                        totalrow = totalrow + 1
                    Next
                    NoUrut = Strings.Left(Ttemp, Ttemp.Length - 1) & ")"
                End If

                If totalrow * Tinput > 500 Then
                    MsgBox("Total barcode tidak boleh lebih dari 500 cetakan, total barcode anda adalah " & totalrow & " data x " & Tinput & " cetakan = " & totalrow * Tinput & " cetakan barcode.", MsgBoxStyle.Exclamation, "Warning!")
                    Exit Sub
                End If

                Dim Tbls2 As DataTable = ReadSQL("SELECT a.NoUrut,a.TransLabID,c.Nama,CONVERT(varchar(11),c.TglLahir,106) as TglLahir,c.JenisKelamin, a.LabSamplingTime " & _
                                                 "FROM TransaksiLab a " & _
                                                 "LEFT JOIN MasterPasien c on c.NoRekamMedis = a.IDInternet " & _
                                                 "WHERE a.TransLabID in " & NoUrut & "")
                If Tbls2.Rows.Count > 0 Then
                    For Each TrowData As DataRow In Tbls2.Rows

                        Dim Tstrtemp As String = ""
                        If TrowData("NoUrut").ToString.Contains("L") = True Then
                            Tstrtemp = Strings.Replace(TrowData("NoUrut").ToString.Trim, "L", "8")
                        ElseIf TrowData("NoUrut").ToString.Contains("M") = True Then
                            Tstrtemp = Strings.Replace(TrowData("NoUrut").ToString.Trim, "M", "9")
                        End If

                        barcode = KodeBarcode & Strings.Right(Tstrtemp.ToString.Trim, Len(Tstrtemp.ToString.Trim) - 2)
                        System.Threading.Thread.Sleep(500)

                        For i As Integer = 0 To CInt(Tinput) - 1
                            If System.IO.File.Exists(Ttx) = True Then System.IO.File.Delete(Ttx)
                            Dim objStreamWriter As StreamWriter
                            objStreamWriter = New StreamWriter(Ttx)
                            objStreamWriter.WriteLine("<xpml><page quantity='0' pitch='29.3 mm'></xpml>I8,A")
                            objStreamWriter.WriteLine("ZN")
                            objStreamWriter.WriteLine("q275")
                            objStreamWriter.WriteLine("S3")
                            objStreamWriter.WriteLine("O")
                            objStreamWriter.WriteLine("JF")
                            objStreamWriter.WriteLine("D9")
                            objStreamWriter.WriteLine("ZT")
                            objStreamWriter.WriteLine("Q234,B24")
                            objStreamWriter.WriteLine("KI80")
                            objStreamWriter.WriteLine("<xpml></page></xpml><xpml><page quantity='1' pitch='29.3 mm'></xpml>N")
                            objStreamWriter.WriteLine("B290,177,2,1,2,4,97,N,""" & barcode & """")
                            objStreamWriter.WriteLine("A95,217,2,3,1,1,N,""""""")
                            objStreamWriter.WriteLine("A290,54,2,2,1,1,N,""" & TrowData("Nama").ToString.Trim & """")
                            objStreamWriter.WriteLine("A290,30,2,2,1,1,N,""" & TrowData("TglLahir").ToString.Trim & " / " & TrowData("JenisKelamin").ToString.Trim & """")
                            objStreamWriter.WriteLine("A290,217,2,3,1,1,N,""" & barcode & """")
                            objStreamWriter.WriteLine("P1")
                            objStreamWriter.WriteLine("<xpml></page></xpml><xpml><end/></xpml>")
                            objStreamWriter.Close()
                            Process.Start(Tpathprf & "PrFile32.exe ", Ttx)
                        Next

                        If IsDBNull(TrowData("LabSamplingTime")) = True Then
                            WriteSQL("update TransaksiLab set SendKeu=1, [Status]='CHECK', LabSamplingTime=getdate() WHERE TransLabID='" & TrowData("TransLabID").ToString.Trim & "' ", 4)
                        Else
                            WriteSQL("update TransaksiLab set SendKeu=1, [Status]='CHECK' WHERE TransLabID='" & TrowData("TransLabID").ToString.Trim & "' ", 4)
                        End If
                    Next
                Else
                    MsgBox("Tidak ada data yang di barcode.", MsgBoxStyle.Exclamation, "Warning!")
                    Exit Sub
                End If
            End If

            CetakBarcodeToolStripMenuItem.Enabled = True
            BarcodeTambahanToolStripMenuItem.Enabled = True
        Catch ex As Exception
            CetakBarcodeToolStripMenuItem.Enabled = True
            BarcodeTambahanToolStripMenuItem.Enabled = True

            If MsgBox(" Batal untuk Cetak Barcode tambahan ? ", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                Exit Sub
            Else
                MsgBox("Ulangi proses ketika siap")
            End If
        End Try
    End Sub

    Private Sub ScanHYUToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormScanHyu.Show()
    End Sub

    Private Sub ButtonCariPasien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCariPasien.Click
        If String.IsNullOrEmpty(TextBoxScanHyu.Text.Trim()) Then
            MessageBox.Show("Silakan scan atau masukkan QR Code terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            TextBoxScanHyu.Focus()
            Exit Sub
        End If

        Dim urlWebService As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
        Dim url As String = urlWebService & "api/mcu/check-in/decode"

        Dim jsonParameter As String = "{""qr_code"": """ & TextBoxScanHyu.Text.Trim() & """}"

        Try
            Dim jsonResult As String = InsertDataAPIRM(jsonParameter, url)
            Dim jObj As JObject = JObject.Parse(jsonResult)

            If jObj("success") IsNot Nothing AndAlso CBool(jObj("success")) = True Then
                Dim nik As String = jObj("data")("nik").ToString()

                ' =========================================================
                ' ALUR OTOMATISASI PENCARIAN BERDASARKAN NIK
                ' =========================================================
                Dim Takhir As Date = DateSerial(DateAndTime.Now.Year, DateAndTime.Now.Month, DateAndTime.Now.Day).AddDays(30)
                Dim Tawal As Date = DateAdd(DateInterval.Day, -90, Takhir.Date)

                ' 1. Susun string query SQL dengan tambahan filter NIK hasil decode
                Dim querySQL As String = "SELECT a.TransLabID, a.NoUrut, a.IDInternet, b.Nama, b.TglLahir, b.NoNIK AS nik, a.TglLab, a.Status " & _
                                         "FROM TransaksiLab a " & _
                                         "LEFT JOIN MasterPasien b on a.idinternet = b.NoRekamMedis " & _
                                         "WHERE a.ClosedTransaksi=1 and Status in ('SAMPLE','CHECK') " & _
                                         "and CONVERT(date, Tgllab) between '" & Format(Tawal.Date, "MM/dd/yyyy") & "' and '" & Format(Takhir.Date, "MM/dd/yyyy") & "' " & _
                                         "and a.deleted<>1 and b.NoNIK = '" & nik.Trim() & "' "

                ' 2. Jalankan ReadSQL terlebih dahulu untuk memeriksa apakah transaksi pasien ini ada
                Dim dtCheck As DataTable = ReadSQL(querySQL)

                If dtCheck.Rows.Count > 0 Then
                    ' Jika data ditemukan, buat DefaultView untuk dilempar ke fungsi LoadTransLab
                    Dim rowView As DataRowView = dtCheck.DefaultView(0)

                    ' Langsung load data pasien ke komponen input form utama
                    LoadTransLab(rowView)
                Else
                    ' Jika tidak langsung ketemu otomatis, tetap tampilkan form Find manual dengan filter NIK tersebut
                    Find.Show()
                    Find.Query(querySQL, " order by a.NoUrut desc ", "FindTransaksiBarcode", 0)
                    MessageBox.Show("Transaksi lab untuk NIK " & nik & " tidak ditemukan pada range tanggal ini.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
                ' =========================================================

            Else
                Dim message As String = "Gagal memproses data."
                If jObj("message") IsNot Nothing Then
                    message = jObj("message").ToString()
                End If
                MessageBox.Show("Respon Server Gagal: " & message, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan sistem atau format JSON tidak sesuai: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class