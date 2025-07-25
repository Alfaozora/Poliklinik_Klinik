Public Class FormCetakUlangRujukan
    Private Sub SetClear()
        dtkasirakhir.Value = DateAndTime.Now
        dtkasirawal.Value = Format(DateSerial(DateAndTime.Now.Year, DateAndTime.Now.Month, 1), "MM/dd/yyyy")
    End Sub

    Private Sub FormCetakUlangRujukan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        SetClear()
    End Sub

    Private Sub butdisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butdisplay.Click
        If txnorujukan.Text = "" Then
            MsgBox("Pilih Surat Rujukan Terlebih Dahulu.")
            Exit Sub
        End If

        Dim Tbls As DataTable = ReadSQL("SELECT ROW_NUMBER() OVER (ORDER BY NoRekamMedis ASC) AS 'No', UPPER(Nama) AS 'Nama', b.NoUrut, CONVERT(DATE, TglLahir) AS 'Tgl Lahir', CONVERT(date, TglLab) AS 'Tgl Invoice', DomisiliAlamat, JenisKelamin, NoNIK FROM " & _
                                        "MasterPasien a " & _
                                        "LEFT JOIN TransaksiLab b ON a.NoRekamMedis = b.IDInternet " & _
                                        "LEFT JOIN TransaksiLabDetail c ON b.TransLabID = c.TransLabID " & _
                                        "WHERE c.NoSuratRujukan IN (SELECT IDSuratRujukan FROM TransaksiRujukanLab WHERE NoSuratRujukan = '" & txnorujukan.Text & "') GROUP BY Nama, TglLahir, TglLab, NoUrut, NoRekamMedis, DomisiliAlamat, JenisKelamin, NoNIK ORDER BY NoRekamMedis ASC")
        'Dim TblsTindakan As DataTable = ReadSQL("select TindakanID, NamaTindakan from TransaksiLabDetail where NoSuratRujukan in (select IDSuratRujukan from TransaksiRujukanLab where NoSuratRujukan = '" & txnorujukan.Text & "') group by TindakanID, NamaTindakan")

        insertRowToTbls(Tbls, "typstring", "TindakanDetail")
        insertRowToTbls(Tbls, "typstring", "NamaLabRujukan")
        insertRowToTbls(Tbls, "typstring", "AlamatLabRujukan")
        insertRowToTbls(Tbls, "typstring", "UpLabRujukan")
        insertRowToTbls(Tbls, "typstring", "TglTransaksi")
        insertRowToTbls(Tbls, "typstring", "NoSuratRujukan")
        insertRowToTbls(Tbls, "typstring", "TglSurat")
        insertRowToTbls(Tbls, "typstring", "txnamauser")
        insertRowToTbls(Tbls, "typstring", "txtglttd")
        insertRowToTbls(Tbls, "typstring", "lblprinted")

        'Dim Tstr As String = ""
        'Dim Ttemp As String = ""
        'For Each Trow As DataRow In TblsTindakan.Rows
        '    Ttemp = Ttemp & "" & Trow("NamaTindakan").ToString.Trim & ","
        'Next
        'Tstr = Strings.Left(Ttemp, Ttemp.Length - 1)

        Dim Ttempat As String = ReadSQLNIK("select StrValue from MsConfig where ConfigName='Kota'")
        Dim TCompany As DataTable = ReadSQL("select NamaLabRujukan, AlamatLabRujukan, UpLabRujukan, convert(date, a.TglKirim) as 'TglTransaksi' from TransaksiRujukanLab a left join MasterLaboratoriumRujukan b on a.NoLabRujukan=b.NoLabRujukan where a.NoSuratRujukan = '" & txnorujukan.Text & "'")
        Dim TrowCompany As DataRow = TCompany.Rows(0)

        For Each Trow As DataRow In Tbls.Rows
            Trow("TindakanDetail") = SetTindakanDetailRujukan(Trow("NoUrut"), txnorujukan.Text)
            Trow("NamaLabRujukan") = TrowCompany("NamaLabRujukan")
            Trow("AlamatLabRujukan") = TrowCompany("AlamatLabRujukan")
            Trow("UpLabRujukan") = TrowCompany("UpLabRujukan")
            Trow("TglTransaksi") = Format(TrowCompany("TglTransaksi"), "dd") & " " & BulanIndonesia(Format(TrowCompany("TglTransaksi"), "MM")) & " " & Format(TrowCompany("TglTransaksi"), "yyyy")
            Trow("NoSuratRujukan") = txnorujukan.Text
            Trow("txtglttd") = Ttempat & ", " & Format(DateAndTime.Now, "dd") & " " & BulanIndonesia(Format(DateAndTime.Now, "MM")) & " " & Format(DateAndTime.Now, "yyyy")

            If PoliKlinik.Lbluser.Text = "Admin" Then
                Trow("txnamauser") = "Admin"
            Else
                Trow("txnamauser") = ReadSQLNIK("SELECT UserNama FROM Users where UserID = '" & PoliKlinik.Lbluser.Text & "'")
            End If

            Trow("lblprinted") = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:ss") & " By " & PoliKlinik.Lbluser.Text
            Trow("TglSurat") = Format(DateAndTime.Now, "dd") & " " & BulanIndonesia(Format(DateAndTime.Now, "MM")) & " " & Format(DateAndTime.Now, "yyyy")
        Next

        Report = New XtraReport
        Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\Rujukan\SuratRujukanLabNonKop.repx", True)
        Report.DataSource = Tbls
        'Report.RunDesigner()
        Report.ShowPreview()
    End Sub

    Function SetTindakanDetailRujukan(ByVal NoUrut As String, ByVal NoRujukan As String) As String
        Dim TDetailPemeriksaan As DataTable = New DataTable
        Dim DetailPemeriksaan As String = ""
        Dim TtempDetailPemeriksaan As String = ""

        TDetailPemeriksaan = ReadSQL("SELECT b.NamaTindakan FROM TransaksiLab a LEFT JOIN TransaksiLabDetail b ON a.TransLabID = b.TransLabID WHERE NoSuratRujukan IN (SELECT IDSuratRujukan FROM TransaksiRujukanLab WHERE NoSuratRujukan = '" & NoRujukan & "') AND NoUrut = '" & NoUrut & "' ")
        For Each TRowDetailPemeriksaan As DataRow In TDetailPemeriksaan.Rows
            TtempDetailPemeriksaan = TtempDetailPemeriksaan & "" & TRowDetailPemeriksaan("NamaTindakan").ToString.Trim & ", "
        Next

        DetailPemeriksaan = Strings.Left(TtempDetailPemeriksaan, TtempDetailPemeriksaan.Length - 2)

        Return DetailPemeriksaan
    End Function

    Private Sub butfind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butfind.Click
        Find.Show()
        Find.Query("select a.NoSuratRujukan, convert(date, a.TglKirim) as 'Tgl Rujukan', b.NamaLabRujukan from TransaksiRujukanLab a left join MasterLaboratoriumRujukan b on a.NoLabRujukan=b.NoLabRujukan where a.deleted IS NULL AND CONVERT(date, a.TglKirim) between '" & Format(dtkasirawal.Value, "MM-dd-yyyy") & "' and '" & Format(dtkasirakhir.Value, "MM-dd-yyyy") & "' AND deleted IS NULL ", " order by NoSuratRujukan desc", "FindRujukanID", 0)
    End Sub

    Public Sub LoadRujukan(ByRef txid As String)
        txnorujukan.Text = txid
    End Sub

    Private Sub CheckBoxDelete_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxDelete.CheckedChanged
        If CheckBoxDelete.Checked = True Then
            If txnorujukan.Text.Trim = "" Then
                MsgBox("Pilih No Surat Rujukan yang akan dihapus.", MsgBoxStyle.Exclamation, "Warning!")
                CheckBoxDelete.Checked = False
                Exit Sub
            End If

            If MsgBox("Apakah anda yakin ingin menghapus surat rujukan dengan nomor " & txnorujukan.Text & "?", MsgBoxStyle.YesNoCancel, "Question.") = MsgBoxResult.Yes Then

                'Proses Delete
                WriteSQL("UPDATE TransaksiRujukanLab SET deleted=1, deletedby='" & PoliKlinik.Lbluser.Text & "', deleteddate=getdate() WHERE NoSuratRujukan='" & txnorujukan.Text & "'", 4)
                WriteSQL("UPDATE TransaksiLabDetail SET Rujukan = 0, NoSuratRujukan = 0, LabTujuan = '-', Biaya = 0, TglKirim = NULL WHERE NoSuratRujukan IN (SELECT IDSuratRujukan FROM TransaksiRujukanLab WHERE NoSuratRujukan='" & txnorujukan.Text & "')", 4)
                WriteSQL("UPDATE TransaksiLab SET RujukanID = NULL WHERE RujukanID IN (SELECT IDSuratRujukan FROM TransaksiRujukanLab WHERE NoSuratRujukan='" & txnorujukan.Text & "')", 4)

                MsgBox("Surat Rujukan No. " & txnorujukan.Text & " berhasil dihapus dari program.", MsgBoxStyle.Information, "Success!")
                txnorujukan.ResetText()
                CheckBoxDelete.Checked = False
            End If
        End If
    End Sub
End Class

