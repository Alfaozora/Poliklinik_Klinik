Public Class FormCetakUlangRefund
    Private Sub SetClear()
        dtkasirakhir.Value = DateAndTime.Now
        dtkasirawal.Value = Format(DateSerial(DateAndTime.Now.Year, DateAndTime.Now.Month, 1), "MM/dd/yyyy")
    End Sub

    Private Sub FormCetakUlangRefund_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        SetClear()
    End Sub

    Private Sub butdisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butdisplay.Click
        If txnorefund.Text = "" Then
            MsgBox("Pilih No Refund Terlebih Dahulu.")
            Exit Sub
        End If

        Dim Tbls As DataTable = New DataTable
        Dim statusManual As Boolean = False

        If CheckSQL("SELECT * FROM TransaksiRefund WHERE alasan LIKE '%MANUAL%' AND norefund = '" & txnorefund.Text & "'") = True Then
            Tbls = ReadSQL("SELECT 1 AS 'No', UPPER(namabersangkutan) AS 'Nama', GETDATE() AS 'Tgl Lahir', '-' AS 'NoUrut', totalbayar AS 'NettBayar', '-' AS 'NamaCompany' FROM TransaksiRefund WHERE norefund = '" & txnorefund.Text & "'")
            statusManual = True
        Else
            Tbls = ReadSQL("SELECT ROW_NUMBER() OVER (ORDER BY NoRekamMedis ASC) AS 'No', UPPER(Nama) AS 'Nama', TglLahir AS 'Tgl Lahir', NoUrut, SUM(c.NettBayar) AS 'NettBayar', CASE WHEN d.JenisBayar = 'TAGIHAN' THEN d.NoJenisBayar WHEN d.JenisBayar <> 'TAGIHAN' THEN 'PASIEN UMUM' ELSE 'PASIEN UMUM' END AS 'NamaCompany' " & _
                           "FROM MasterPasien a " & _
                           "LEFT JOIN TransaksiLab b ON a.NoRekamMedis = b.IDInternet " & _
                           "LEFT JOIN TransaksiLabDetail c ON b.TransLabID = c.TransLabID " & _
                           "LEFT JOIN TransaksiLabBayar d ON b.TransLabID = d.TransLabID AND d.JenisBayar = 'TAGIHAN' " & _
                           "WHERE c.RefundID IN (SELECT norefund FROM TransaksiRefund WHERE norefund = '" & txnorefund.Text & "') " & _
                           "GROUP BY Nama, TglLahir, NoUrut, NoRekamMedis, JenisBayar, NoJenisBayar " & _
                           "ORDER BY NoRekamMedis ASC")
        End If

        Dim Ttempat As String = ReadSQLNIK("select StrValue from MsConfig where ConfigName='Kota'")

        insertRowToTbls(Tbls, "typstring", "TindakanDetail")
        insertRowToTbls(Tbls, "typstring", "CompanyDetail")
        insertRowToTbls(Tbls, "typstring", "TglTransaksi")
        insertRowToTbls(Tbls, "typstring", "NoSuratRefund")
        insertRowToTbls(Tbls, "typstring", "txnamauser")
        insertRowToTbls(Tbls, "typstring", "txtglttd")
        insertRowToTbls(Tbls, "typstring", "lblprinted")
        insertRowToTbls(Tbls, "typstring", "lblbanktransfer")
        insertRowToTbls(Tbls, "typstring", "lblalasan")
        insertRowToTbls(Tbls, "typstring", "lblnamabersangkutan")
        insertRowToTbls(Tbls, "typstring", "lblnamamengetahui")
        insertRowToTbls(Tbls, "typstring", "lblnotelepon")
        insertRowToTbls(Tbls, "typstring", "lblnorek")
        insertRowToTbls(Tbls, "typstring", "lblnamabankrek")
        insertRowToTbls(Tbls, "typstring", "lblatasnamarek")
        insertRowToTbls(Tbls, "typstring", "lbladmin")
        insertRowToTbls(Tbls, "typstring", "statuskesalahan")
        insertRowToTbls(Tbls, "typstring", "totalbayar")

        Dim TCompany As DataTable = ReadSQL("select * from TransaksiRefund a where a.norefund = '" & txnorefund.Text & "'")
        Dim TrowCompany As DataRow = TCompany.Rows(0)

        For Each Trow As DataRow In Tbls.Rows
            If statusManual = False Then
                Trow("TindakanDetail") = SetTindakanDetailRefund(Trow("NoUrut"), txnorefund.Text)
                If Trow("NamaCompany").ToString.Contains("-") Then
                    Dim NamaCompany As String = Trow("NamaCompany").ToString
                    Dim Tsplit() As String = NamaCompany.Split("-")
                    Trow("CompanyDetail") = Tsplit(0).ToString.Trim.ToUpper
                Else
                    Trow("CompanyDetail") = Trow("NamaCompany").ToString.ToUpper
                End If
            Else
                Trow("TindakanDetail") = "-"
                Trow("CompanyDetail") = "-"
            End If

            If TrowCompany("invfromdate") = TrowCompany("invtodate") Then
                Trow("TglTransaksi") = Format(TrowCompany("invfromdate"), "dd") & " " & BulanIndonesia(Format(TrowCompany("invfromdate"), "MM")) & " " & Format(TrowCompany("invfromdate"), "yyyy")
            Else
                Trow("TglTransaksi") = Format(TrowCompany("invfromdate"), "dd") & " " & BulanIndonesia(Format(TrowCompany("invfromdate"), "MM")) & " " & Format(TrowCompany("invfromdate"), "yyyy") & " s/d " & Format(TrowCompany("invtodate"), "dd") & " " & BulanIndonesia(Format(TrowCompany("invtodate"), "MM")) & " " & Format(TrowCompany("invtodate"), "yyyy")
            End If

            Trow("NoSuratRefund") = txnorefund.Text
            Trow("txtglttd") = Ttempat & ", " & Format(DateAndTime.Now, "dd") & " " & BulanIndonesia(Format(DateAndTime.Now, "MM")) & " " & Format(DateAndTime.Now, "yyyy")

            'New
            If CDbl(TrowCompany("totalbiaya")) < CDbl(TrowCompany("totalbayar")) Then
                If TrowCompany("statustransaksi").ToString.Trim = "True" Then
                    Dim NewTotal As Double = CDbl(TrowCompany("totalbayar")) - CDbl(TrowCompany("totalbiaya"))
                    Trow("lblbanktransfer") = "Dimohon untuk Dana Refund sebesar " & Format(Val(NewTotal), "Rp, ###,###") & " di transfer ke Rekening Berikut :"
                ElseIf TrowCompany("statustransaksi").ToString.Trim = "false" Then
                    Trow("lblbanktransfer") = "Dimohon untuk Dana Refund sebesar " & Format(Val(TrowCompany("totalbayar")), "Rp, ###,###") & " di transfer ke Rekening Berikut :"
                End If
            Else
                Trow("lblbanktransfer") = "Dimohon untuk Dana Refund sebesar " & Format(Val(TrowCompany("totalbiaya")), "Rp, ###,###") & " di transfer ke Rekening Berikut :"
            End If

            Trow("totalbayar") = Format(Val(TrowCompany("totalbayar")), "Rp, ###,###")
            Trow("lblalasan") = TrowCompany("alasan").ToString.Trim
            Trow("lblnamabersangkutan") = "(" & TrowCompany("namabersangkutan").ToString.Trim & ")"
            Trow("lblnamamengetahui") = "(" & ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='Marketing'") & ")"
            Trow("lblnotelepon") = TrowCompany("notelp").ToString.Trim
            Trow("lblnorek") = TrowCompany("norek").ToString.Trim
            Trow("lblnamabankrek") = TrowCompany("namabankrek").ToString.Trim
            Trow("lblatasnamarek") = TrowCompany("namarek").ToString.Trim
            Trow("lbladmin") = "(" & TrowCompany("createby").ToString.Trim & ")"
            Trow("statuskesalahan") = TrowCompany("statuskesalahan").ToString.Trim

            If PoliKlinik.Lbluser.Text = "Admin" Then
                Trow("txnamauser") = "Admin"
            Else
                Trow("txnamauser") = ReadSQLNIK("SELECT UserNama FROM Users where UserID = '" & PoliKlinik.Lbluser.Text & "'")
            End If

            Trow("lblprinted") = Format(DateAndTime.Now, "dd-MMM-yyyy HH:mm:ss") & " By " & PoliKlinik.Lbluser.Text
        Next

        Report = New XtraReport
        Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\Refund\SuratRefundNonKop.repx", True)
        Report.DataSource = Tbls
        'Report.RunDesigner()
        Report.ShowPreview()
    End Sub

    Private Sub butfind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butfind.Click
        Find.Show()
        Find.Query("SELECT norefund, jenistransaksi, totalbiaya, CONVERT(DATE, createdate) AS 'tglcreate', createby FROM TransaksiRefund WHERE CONVERT(date, createdate) BETWEEN '" & Format(dtkasirawal.Value, "MM-dd-yyyy") & "' AND '" & Format(dtkasirakhir.Value, "MM-dd-yyyy") & "' AND deleted IS NULL", " ORDER BY norefund DESC", "FindRefundID", 0)
    End Sub

    Public Sub LoadRujukan(ByRef txid As String)
        txnorefund.Text = txid
    End Sub
End Class

