Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Text
Imports System.Globalization
Imports System.Security.Cryptography
Imports System.Diagnostics
Imports System.Net.WebRequestMethods.Http
Imports System.Net
Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.ComponentModel.BackgroundWorker
Imports System.Data.SqlClient

Public Class FormObservation
    Private userInput As String = PoliKlinik.Lbluser.Text
    Private isStopRequested As Boolean = False
    Private lastPercent As Integer = 0

    Private Sub RoundButton(ByVal btn As Button)
        Dim r As New GraphicsPath()
        r.AddArc(0, 0, 20, 20, 180, 90)
        r.AddArc(btn.Width - 20, 0, 20, 20, 270, 90)
        r.AddArc(btn.Width - 20, btn.Height - 20, 20, 20, 0, 90)
        r.AddArc(0, btn.Height - 20, 20, 20, 90, 90)
        r.CloseFigure()
        btn.Region = New Region(r)
    End Sub

    Public Sub RoundPanel(ByVal panel As Panel)
        Dim gp As New GraphicsPath()
        gp.AddArc(0, 0, 20, 20, 180, 90)
        gp.AddArc(panel.Width - 20, 0, 20, 20, 270, 90)
        gp.AddArc(panel.Width - 20, panel.Height - 20, 20, 20, 0, 90)
        gp.AddArc(0, panel.Height - 20, 20, 20, 90, 90)
        gp.CloseFigure()
        panel.Region = New Region(gp)
    End Sub

    Private Sub FormObservation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        Me.Dock = DockStyle.Fill
        Me.WindowState = FormWindowState.Maximized
        RoundButton(ButtonGetToken)
        RoundButton(PostObservasi)
        RoundButton(ButtonStopProses)
        RoundButton(ButtonRefresh)
        RoundPanel(Panel1)
        RoundPanel(Panel2)

        PanelProgressBG.Controls.Add(PanelProgressFill)
        PanelProgressFill.Left = 0
        PanelProgressFill.Top = 0
        PanelProgressFill.Height = PanelProgressBG.Height

        ComboBoxJenisData.Items.Add("Observation")
        ComboBoxJenisData.Items.Add("Procedure")
        ComboBoxJenisData.SelectedIndex = -1
        PostObservasi.Enabled = False

        If ComboBoxJenisData.SelectedItem IsNot Nothing Then
            Dim Pilihan As String = ComboBoxJenisData.SelectedItem.ToString()
            If Pilihan = "Observation" Then
                Dim jumlahData As Integer = GetJumlahData()
                LabelData.Text = jumlahData.ToString() & " Data"

                Dim jumlah As Integer = GetJumlahTransaksi()
                LabelJmlTerkirim.Text = jumlah.ToString() & " Transaksi"
            ElseIf Pilihan = "Procedure" Then
                Dim jumlahData As Integer = GetJumlahData()
                LabelData.Text = jumlahData.ToString() & " Data"

                Dim jumlah As Integer = GetJumlahTransaksiProcedure()
                LabelJmlTerkirim.Text = jumlah.ToString() & " Transaksi"
            End If
        End If

        Dim lastDateSinkron As String = ReadSQLNIK("SELECT TOP(1) CreatedDate FROM SatuSehat_LogObservations ORDER BY CreatedDate DESC")
        If String.IsNullOrEmpty(lastDateSinkron) Then
            LabelSinkronisasi.Text = "Belum ada data terkirim"
        Else
            LabelSinkronisasi.Text = "Kirim Data Terakhir pada " & lastDateSinkron
        End If
    End Sub

    Private Sub ButtonGetToken_MouseEnter(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonGetToken.MouseEnter
        ButtonGetToken.BackColor = Color.FromArgb(30, 144, 255)
    End Sub

    Private Sub ButtonGetToken_MouseLeave(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonGetToken.MouseLeave
        ButtonGetToken.BackColor = Color.FromArgb(0, 100, 200)
    End Sub

    Private Sub PostObservasi_MouseEnter(ByVal sender As Object, ByVal e As EventArgs) Handles PostObservasi.MouseEnter
        PostObservasi.BackColor = Color.FromArgb(30, 144, 255)
    End Sub

    Private Sub ButtonRefresh_MouseEnter(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonRefresh.MouseEnter
        ButtonRefresh.BackColor = Color.FromArgb(30, 144, 255)
    End Sub

    Private Sub ButtonRefresh_MouseLeave(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonRefresh.MouseLeave
        ButtonRefresh.BackColor = Color.FromArgb(0, 100, 200)
    End Sub

    Private Sub PostObservasi_MouseLeave(ByVal sender As Object, ByVal e As EventArgs) Handles PostObservasi.MouseLeave
        PostObservasi.BackColor = Color.FromArgb(0, 100, 200)
    End Sub

    Private Sub ButtonStopProses_MouseEnter(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonStopProses.MouseEnter
        ButtonStopProses.BackColor = Color.FromArgb(228, 12, 43)
        ButtonStopProses.ForeColor = Color.White
    End Sub

    Private Sub ButtonStopProses_MouseLeave(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonStopProses.MouseLeave
        ButtonStopProses.BackColor = Color.FromArgb(244, 73, 97)
    End Sub

    Private Sub ButtonGetToken_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGetToken.Click
        ' === AMBIL TOKEN BARU ===
        Dim tokenValue As String = GetTokenSatuSehat()
        Dim organizationID As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'satu_sehat_organization_id'")

        ' Validasi token
        If String.IsNullOrEmpty(tokenValue) OrElse tokenValue.StartsWith("Error") Then
            MessageBox.Show("Gagal mendapatkan token: " & tokenValue)
            Exit Sub
        End If

        ' Buat JSON untuk dikirim ke webservice Laravel
        Dim json As String = "{" & _
        """organization_id"":""" & organizationID & """," & _
        """access_token"":""" & tokenValue & """," & _
        """expires_in"":14399" & _
        "}"

        ' Ambil base URL webservice Laravel dari config
        Dim baseURL As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
        Dim apiUrl As String = baseURL & "api/store-token"

        ' Kirim data ke Laravel menggunakan fungsi InsertDataAPIRM
        Dim response As String = InsertDataAPIRM(json, apiUrl)

        ' Tampilkan respon dari Laravel
        MessageBox.Show("Respon dari server: " & response)
    End Sub

    Private Sub InsertLogObservation(ByVal noTransaksi As String, ByVal resourceType As String, ByVal resourceId As String, ByVal encounterRef As String, ByVal status As String)
        Dim sql As String = "INSERT INTO SatuSehat_LogObservations " & _
                            "(NoTransaksi, ResourceType, ResourceID, Encounter, Status, CreatedBy, CreatedDate) " & _
                            "VALUES('" & noTransaksi & "', '" & resourceType & "', '" & resourceId & "', '" & encounterRef & "', '" & status & "', '" & userInput & "', GETDATE())"

        WriteSQL(sql, 4)
    End Sub

    Private Sub InsertLogProcedure(ByVal noTransaksi As String, ByVal resourceType As String, ByVal resourceId As String, ByVal encounterRef As String, ByVal procStatus As String)
        Dim sql As String = "INSERT INTO SatuSehat_LogProcedure " & _
                            "(NoTransaksi, ResourceType, ResourceID, Encounter, procStatus, CreatedBy, CreatedDate) " & _
                            "VALUES('" & noTransaksi & "', '" & resourceType & "', '" & resourceId & "', '" & encounterRef & "', '" & procStatus & "', '" & userInput & "', GETDATE())"

        WriteSQL(sql, 4)
    End Sub

    Private Sub UpdateUploadStatus(ByVal noTransaksi As String)
        Dim sql As String = "UPDATE TransaksiDetailFisik SET UploadSatuSehat = 1 WHERE NoTransaksi = '" & noTransaksi & "'"
        WriteSQL(sql, 4)
    End Sub

    Private Sub UpdateUploadStatusProcedure(ByVal noTransaksi As String)
        Dim sql As String = ""

        ' cek apakah mengandung huruf U atau G
        If noTransaksi.Contains("U") Then
            sql = "UPDATE TransaksiPoli SET UploadSatuSehatProcedure = 1 WHERE NoUrut = '" & noTransaksi & "'"
        ElseIf noTransaksi.Contains("G") Then
            sql = "UPDATE TransaksiGigi SET UploadSatuSehatProcedure = 1 WHERE NoUrut = '" & noTransaksi & "'"
        End If

        If sql <> "" Then
            WriteSQL(sql, 4)
        End If
    End Sub

    ' --- Buat fungsi baru untuk ambil data Observasi ---
    Private Function GetDataObservasi() As DataTable
        Dim tbls As DataTable = New DataTable()
        Dim queryDataUpload As New StringBuilder()

        queryDataUpload.AppendLine("SELECT ")
        queryDataUpload.AppendLine("    SLR.NoTransaksi,")
        queryDataUpload.AppendLine("    SLR.ResourceID AS idEncounter,")
        queryDataUpload.AppendLine("    MP.Nama AS NamaPasien,")
        queryDataUpload.AppendLine("    MP.NoIHS AS IHSPasien,")
        queryDataUpload.AppendLine("    TP.DokterPoli AS NamaDokter,")
        queryDataUpload.AppendLine("    MD.NoIHS AS IHSDokter,")
        queryDataUpload.AppendLine("    TDF.Sistole,")
        queryDataUpload.AppendLine("    TDF.Diastole,")
        queryDataUpload.AppendLine("    TDF.HeartRate,")
        queryDataUpload.AppendLine("    TDF.RespiratoryRate,")
        queryDataUpload.AppendLine("    TDF.Berat,")
        queryDataUpload.AppendLine("    TDF.Tinggi,")
        queryDataUpload.AppendLine("    TDF.IMT,")
        queryDataUpload.AppendLine("    TDF.LingkarPerut")
        queryDataUpload.AppendLine("FROM SatuSehat_LogTransaksiResource SLR")
        queryDataUpload.AppendLine("INNER JOIN TransaksiPoli TP ON SLR.NoTransaksi = TP.NoUrut")
        queryDataUpload.AppendLine("INNER JOIN TransaksiDetailFisik TDF ON TP.NoUrut = TDF.NoTransaksi")
        queryDataUpload.AppendLine("INNER JOIN MasterPasien MP ON TP.IDInternet = MP.NoRekamMedis")
        queryDataUpload.AppendLine("INNER JOIN MasterDokter MD ON TP.KodeDokter = MD.ID")
        queryDataUpload.AppendLine("WHERE SLR.ResourceType = 'Encounter'")
        queryDataUpload.AppendLine("  AND SLR.Status = '201 Created'")
        queryDataUpload.AppendLine("  AND TDF.UploadSatuSehat = '0'")
        queryDataUpload.AppendLine("  AND MP.NoIHS IS NOT NULL")
        queryDataUpload.AppendLine("ORDER BY SLR.NoTransaksi ASC")

        tbls = ReadSQL(queryDataUpload.ToString())
        Return tbls
    End Function

    Private Function GetDataProcedure() As DataTable
        Dim tbls As DataTable = New DataTable()
        Dim queryDataUpload As New StringBuilder()

        queryDataUpload.AppendLine("SELECT ")
        queryDataUpload.AppendLine("    SLTR.NoTransaksi,")
        queryDataUpload.AppendLine("    MT.ICD9 AS code,")
        queryDataUpload.AppendLine("    MT.Display AS display,")
        queryDataUpload.AppendLine("    MP.NoIHS AS patientId,")
        queryDataUpload.AppendLine("    MP.Nama AS patientName,")
        queryDataUpload.AppendLine("    SLTR.ResourceID AS encounterId,")
        queryDataUpload.AppendLine("    MD.NoIHS AS practitionerId,")
        queryDataUpload.AppendLine("    MD.Nama AS practitionerName,")
        queryDataUpload.AppendLine("    TP.ArrivedDate AS start,")
        queryDataUpload.AppendLine("    TP.FinishedDate AS [end]")
        queryDataUpload.AppendLine("FROM TransaksiDetail TD")
        queryDataUpload.AppendLine("INNER JOIN MasterPasien MP ON TD.IDInternet = MP.NoRekamMedis")
        queryDataUpload.AppendLine("INNER JOIN TransaksiPoli TP ON TD.NoUrut = TP.NoUrut")
        queryDataUpload.AppendLine("INNER JOIN TransaksiPoliDetail TPD ON TP.TransPoliID = TPD.TransPoliID")
        queryDataUpload.AppendLine("INNER JOIN MasterTindakan MT ON TPD.TindakanID = MT.TindakanID")
        queryDataUpload.AppendLine("INNER JOIN SatuSehat_LogTransaksiResource SLTR ON TD.NoUrut = SLTR.NoTransaksi")
        queryDataUpload.AppendLine("INNER JOIN MasterDokter MD ON TP.KodeDokter = MD.ID")
        queryDataUpload.AppendLine("WHERE SLTR.ResourceType = 'Encounter'")
        queryDataUpload.AppendLine("  AND SLTR.Status = '201 Created'")
        queryDataUpload.AppendLine("  AND TP.UploadSatuSehatProcedure = '0'")
        queryDataUpload.AppendLine("  AND MP.NoIHS IS NOT NULL")
        queryDataUpload.AppendLine("  AND MT.ICD9 IS NOT NULL")
        queryDataUpload.AppendLine("  AND MT.JenisTindakan = 'Tindakan'")
        queryDataUpload.AppendLine("UNION ALL")
        queryDataUpload.AppendLine("SELECT ")
        queryDataUpload.AppendLine("    SLTR.NoTransaksi,")
        queryDataUpload.AppendLine("    MT.ICD9 AS code,")
        queryDataUpload.AppendLine("    MT.Display AS display,")
        queryDataUpload.AppendLine("    MP.NoIHS AS patientId,")
        queryDataUpload.AppendLine("    MP.Nama AS patientName,")
        queryDataUpload.AppendLine("    SLTR.ResourceID AS encounterId,")
        queryDataUpload.AppendLine("    MD.NoIHS AS practitionerId,")
        queryDataUpload.AppendLine("    MD.Nama AS practitionerName,")
        queryDataUpload.AppendLine("    TG.ArrivedDate AS start,")
        queryDataUpload.AppendLine("    TG.FinishedDate AS [end]")
        queryDataUpload.AppendLine("FROM TransaksiDetail TD")
        queryDataUpload.AppendLine("INNER JOIN MasterPasien MP ON TD.IDInternet = MP.NoRekamMedis")
        queryDataUpload.AppendLine("INNER JOIN TransaksiGigi TG ON TD.NoUrut = TG.NoUrut")
        queryDataUpload.AppendLine("INNER JOIN TransaksiGigiDetail TGD ON TG.TransGigiID = TGD.TransGigiID")
        queryDataUpload.AppendLine("INNER JOIN MasterTindakan MT ON TGD.TindakanID = MT.TindakanID")
        queryDataUpload.AppendLine("INNER JOIN SatuSehat_LogTransaksiResource SLTR ON TD.NoUrut = SLTR.NoTransaksi")
        queryDataUpload.AppendLine("INNER JOIN MasterDokter MD ON TG.KodeDokter = MD.ID")
        queryDataUpload.AppendLine("WHERE SLTR.ResourceType = 'Encounter'")
        queryDataUpload.AppendLine("  AND SLTR.Status = '201 Created'")
        queryDataUpload.AppendLine("  AND TG.UploadSatuSehatProcedure = '0'")
        queryDataUpload.AppendLine("  AND MP.NoIHS IS NOT NULL")
        queryDataUpload.AppendLine("  AND MT.ICD9 IS NOT NULL")
        queryDataUpload.AppendLine("  AND MT.JenisTindakan = 'Tindakan'")
        queryDataUpload.AppendLine("ORDER BY NoTransaksi ASC")

        tbls = ReadSQL(queryDataUpload.ToString())
        Return tbls
    End Function

    Private Sub ComboBoxJenisData_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBoxJenisData.SelectedIndexChanged
        If ComboBoxJenisData.SelectedIndex <> -1 Then
            PostObservasi.Enabled = True
        Else
            PostObservasi.Enabled = False
        End If
    End Sub

    Private Sub PostObservasi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PostObservasi.Click
        Dim pilihan As String = ComboBoxJenisData.SelectedItem.ToString()

        If pilihan = "Observation" Then
            If Not bgWorkerObservasi.IsBusy Then
                PostObservasi.Enabled = False
                ButtonGetToken.Enabled = False
                ButtonStopProses.Enabled = True
                ButtonRefresh.Enabled = False
                TextBoxResponse.Clear()

                bgWorkerObservasi.RunWorkerAsync()
            End If

        ElseIf pilihan = "Procedure" Then
            If Not bgWorkerProcedure.IsBusy Then
                PostObservasi.Enabled = False
                ButtonGetToken.Enabled = False
                ButtonStopProses.Enabled = True
                ButtonRefresh.Enabled = False
                TextBoxResponse.Clear()

                bgWorkerProcedure.RunWorkerAsync()
            End If
        End If
    End Sub

    Private Function GetJumlahTransaksi() As Integer
        Dim dtCek As DataTable = ReadSQL("SELECT COUNT(DISTINCT NoTransaksi) AS Jumlah FROM SatuSehat_LogObservations")

        If dtCek.Rows.Count > 0 AndAlso Not IsDBNull(dtCek.Rows(0)("Jumlah")) Then
            Return Convert.ToInt32(dtCek.Rows(0)("Jumlah"))
        End If

        Return 0
    End Function

    Private Function GetJumlahTransaksiProcedure() As Integer
        Dim dtCek As DataTable = ReadSQL("SELECT COUNT(DISTINCT NoTransaksi) AS Jumlah FROM SatuSehat_LogProcedure")

        If dtCek.Rows.Count > 0 AndAlso Not IsDBNull(dtCek.Rows(0)("Jumlah")) Then
            Return Convert.ToInt32(dtCek.Rows(0)("Jumlah"))
        End If

        Return 0
    End Function

    Private Function GetJumlahData() As Integer
        Dim dtCek As DataTable = ReadSQL("SELECT COUNT(*) AS JumlahData FROM SatuSehat_LogTransaksiResource SLR " & _
            "INNER JOIN TransaksiPoli TP ON SLR.NoTransaksi = TP.NoUrut " & _
            "INNER JOIN TransaksiDetailFisik TDF ON TP.NoUrut = TDF.NoTransaksi " & _
            "INNER JOIN MasterPasien MP ON TP.IDInternet = MP.NoRekamMedis " & _
            "INNER JOIN MasterDokter MD ON TP.KodeDokter = MD.ID " & _
            "WHERE SLR.ResourceType = 'Encounter' " & _
            "AND SLR.Status = '201 Created' " & _
            "AND TDF.UploadSatuSehat = '0' " & _
            "AND MP.NoIHS IS NOT NULL")

        If dtCek.Rows.Count > 0 AndAlso Not IsDBNull(dtCek.Rows(0)("JumlahData")) Then
            Return Convert.ToInt32(dtCek.Rows(0)("JumlahData"))
        End If

        Return 0
    End Function

    Private Function GetJumlahDataProcedure() As Integer
        Dim sql As New StringBuilder()

        sql.AppendLine("SELECT COUNT(*) AS JumlahData")
        sql.AppendLine("FROM (")
        sql.AppendLine("    SELECT SLTR.NoTransaksi")
        sql.AppendLine("    FROM TransaksiDetail TD")
        sql.AppendLine("    INNER JOIN MasterPasien MP ON TD.IDInternet = MP.NoRekamMedis")
        sql.AppendLine("    INNER JOIN TransaksiPoli TP ON TD.NoUrut = TP.NoUrut")
        sql.AppendLine("    INNER JOIN TransaksiPoliDetail TPD ON TP.TransPoliID = TPD.TransPoliID")
        sql.AppendLine("    INNER JOIN MasterTindakan MT ON TPD.TindakanID = MT.TindakanID")
        sql.AppendLine("    INNER JOIN SatuSehat_LogTransaksiResource SLTR ON TD.NoUrut = SLTR.NoTransaksi")
        sql.AppendLine("    INNER JOIN MasterDokter MD ON TP.KodeDokter = MD.ID")
        sql.AppendLine("    WHERE SLTR.ResourceType = 'Encounter'")
        sql.AppendLine("      AND SLTR.Status = '201 Created'")
        sql.AppendLine("      AND TP.UploadSatuSehatProcedure = '0'")
        sql.AppendLine("      AND MP.NoIHS IS NOT NULL")
        sql.AppendLine("      AND MT.ICD9 IS NOT NULL")
        sql.AppendLine("      AND MT.JenisTindakan = 'Tindakan'")
        sql.AppendLine("    UNION ALL")
        sql.AppendLine("    SELECT SLTR.NoTransaksi")
        sql.AppendLine("    FROM TransaksiDetail TD")
        sql.AppendLine("    INNER JOIN MasterPasien MP ON TD.IDInternet = MP.NoRekamMedis")
        sql.AppendLine("    INNER JOIN TransaksiGigi TG ON TD.NoUrut = TG.NoUrut")
        sql.AppendLine("    INNER JOIN TransaksiGigiDetail TGD ON TG.TransGigiID = TGD.TransGigiID")
        sql.AppendLine("    INNER JOIN MasterTindakan MT ON TGD.TindakanID = MT.TindakanID")
        sql.AppendLine("    INNER JOIN SatuSehat_LogTransaksiResource SLTR ON TD.NoUrut = SLTR.NoTransaksi")
        sql.AppendLine("    INNER JOIN MasterDokter MD ON TG.KodeDokter = MD.ID")
        sql.AppendLine("    WHERE SLTR.ResourceType = 'Encounter'")
        sql.AppendLine("      AND SLTR.Status = '201 Created'")
        sql.AppendLine("      AND TG.UploadSatuSehatProcedure = '0'")
        sql.AppendLine("      AND MP.NoIHS IS NOT NULL")
        sql.AppendLine("      AND MT.ICD9 IS NOT NULL")
        sql.AppendLine("      AND MT.JenisTindakan = 'Tindakan'")
        sql.AppendLine(") AS DataGabungan")

        Dim dtCek As DataTable = ReadSQL(sql.ToString())

        If dtCek.Rows.Count > 0 AndAlso Not IsDBNull(dtCek.Rows(0)("JumlahData")) Then
            Return Convert.ToInt32(dtCek.Rows(0)("JumlahData"))
        End If

        Return 0
    End Function

    Private Sub bgWorkerProcedure_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles bgWorkerProcedure.DoWork
        Dim tbls As DataTable = GetDataProcedure() ' query ambil data procedure dari DB
        Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
        Dim total As Integer = tbls.Rows.Count
        Dim maxRetry As Integer = 3

        For i As Integer = 0 To tbls.Rows.Count - 1
            If isStopRequested Then
                Exit For
            End If

            Dim row As DataRow = tbls.Rows(i)

            ' ---- Buat payload JSON ----
            Dim data As New Dictionary(Of String, Object)
            data("organization_id") = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'satu_sehat_organization_id'")
            data("patient_id") = row("patientId").ToString()
            data("patient_name") = row("patientName").ToString()
            data("practitioner_id") = row("practitionerId").ToString()
            data("practitioner_name") = row("practitionerName").ToString()
            data("encounter_id") = row("encounterId").ToString()

            ' List procedure yang akan dikirim (bisa lebih dari 1)
            Dim procs As New List(Of Dictionary(Of String, Object))

            Dim proc As New Dictionary(Of String, Object)
            proc("code") = row("code").ToString()
            proc("display") = row("display").ToString()
            proc("start") = If(IsDBNull(row("start")), Nothing, CType(row("start"), DateTime).ToString("yyyy-MM-ddTHH:mm:sszzz"))
            proc("end") = If(IsDBNull(row("end")), Nothing, CType(row("end"), DateTime).ToString("yyyy-MM-ddTHH:mm:sszzz"))
            proc("category_system") = "http://snomed.info/sct"
            proc("category_code") = "103693007"
            proc("category_display") = "Diagnostic procedure"
            procs.Add(proc)

            data("procedures") = procs

            Dim json As String = JsonConvert.SerializeObject(data)

            ' ---- Kirim ke API Laravel ----
            Dim baseURL As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
            Dim apiUrl As String = baseURL & "api/procedures"
            Dim response As String = InsertDataAPIRM(json, apiUrl)
            Dim noTransaksi As String = row("NoTransaksi").ToString()
            Dim encounterId As String = row("encounterId").ToString()

            ' ---- Parsing Response ----
            Try
                Dim rowJson As JObject = JObject.Parse(response)
                Dim status As String = rowJson("status").ToString().Trim().ToLower()

                If status = "success" Then
                    Dim successOrDuplicate As Boolean = True

                    worker.ReportProgress(0, "Data Procedure " & noTransaksi & " Berhasil Terkirim dengan Encounter {" & encounterId & "}")

                    For Each resp In rowJson("responses")
                        Dim procStatus As String = resp("status").ToString()
                        Dim resourceType As String = ""
                        Dim resourceId As String = ""

                        If procStatus = "200" Or procStatus = "201" Then
                            ' sukses normal
                            resourceId = resp("body")("id").ToString()
                            resourceType = resp("body")("resourceType").ToString()

                        ElseIf procStatus = "400" AndAlso resp("body")("issue")(0)("code").ToString().ToLower() = "duplicate" Then
                            ' kalau duplicate → tetap dianggap sukses
                            resourceType = "Procedure"
                            resourceId = "DUPLICATE"
                            worker.ReportProgress(0, "Duplicate ditemukan untuk No Transaksi: " & noTransaksi)

                        Else
                            ' error lain → jangan update status
                            successOrDuplicate = False
                            worker.ReportProgress(0, "Error lain pada No Transaksi: " & noTransaksi & " | Response: " & resp.ToString())
                        End If

                        InsertLogProcedure(noTransaksi, resourceType, resourceId, encounterId, procStatus)
                    Next

                    If successOrDuplicate Then
                        UpdateUploadStatusProcedure(noTransaksi)
                    End If
                Else
                    worker.ReportProgress(0, "Gagal kirim No Transaksi: " & noTransaksi & " | Status: " & status)
                    'worker.ReportProgress(0, "Gagal kirim No Transaksi: " & noTransaksi & _
                    '     " | Status: " & status & _
                    '     " | Response: " & response)
                End If

            Catch ex As Exception
                'worker.ReportProgress(0, "Response tidak valid untuk No Transaksi: " & row("NoTransaksi").ToString() & vbCrLf & "Raw Response: " & response)
                Dim attempt As Integer = 1
                Dim successRetry As Boolean = False

                While attempt <= maxRetry AndAlso Not successRetry
                    Try
                        Threading.Thread.Sleep(1000) ' tunggu 1 detik sebelum retry
                        response = InsertDataAPIRM(json, apiUrl) ' kirim ulang

                        Dim rowJsonRetry As JObject = JObject.Parse(response)
                        Dim statusRetry As String = rowJsonRetry("status").ToString().Trim().ToLower()

                        If statusRetry = "success" Then
                            worker.ReportProgress(0, "Retry ke-" & attempt & " berhasil untuk No Transaksi: " & row("NoTransaksi").ToString())

                            For Each resp In rowJsonRetry("responses")
                                Dim procStatus As String = resp("status").ToString()
                                Dim resourceId As String = resp("body")("id").ToString()
                                Dim resourceType As String = resp("body")("resourceType").ToString()
                                InsertLogProcedure(noTransaksi, resourceType, resourceId, encounterId, procStatus)
                            Next

                            UpdateUploadStatusProcedure(noTransaksi)
                            successRetry = True
                        End If
                    Catch

                    End Try
                    attempt += 1
                End While

                If Not successRetry Then
                    worker.ReportProgress(0, "Response tidak valid untuk No Transaksi: " & _
                                           noTransaksi & vbCrLf & _
                                           "Raw Response: " & response)
                End If
            End Try

            ' Progress bar update
            Dim percent As Integer = CInt(Math.Floor(((i + 1) * 100.0) / total))
            worker.ReportProgress(percent)

            ' Delay kecil untuk jaga API
            Threading.Thread.Sleep(300)

            If (i + 1) Mod 50 = 0 Then
                worker.ReportProgress(0, "Delay 5 detik setelah kirim " & (i + 1).ToString() & " data...")
                Threading.Thread.Sleep(5000) '5 detik
            End If
        Next
    End Sub

    Private Sub bgWorkerObservasi_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles bgWorkerObservasi.DoWork
        Dim tbls As DataTable = GetDataObservasi() ' query ambil data dari DB
        Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
        Dim total As Integer = tbls.Rows.Count
        Dim stepSize As Integer = CInt(Math.Ceiling(total / 100.0))

        For i As Integer = 0 To tbls.Rows.Count - 1
            If isStopRequested Then
                Exit For
            End If

            Dim row As DataRow = tbls.Rows(i)

            ' ---- Buat payload JSON ----
            Dim data As New Dictionary(Of String, Object)
            data("organization_id") = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'satu_sehat_organization_id'")
            data("patient_id") = row("IHSPasien").ToString()
            data("practitioner_id") = row("IHSDokter").ToString()
            data("encounter_id") = row("idEncounter").ToString()
            data("sistole") = If(IsDBNull(row("Sistole")), Nothing, row("Sistole"))
            data("diastole") = If(IsDBNull(row("Diastole")), Nothing, row("Diastole"))
            data("heart_rate") = If(IsDBNull(row("HeartRate")), Nothing, row("HeartRate"))
            data("resp_rate") = If(IsDBNull(row("RespiratoryRate")), Nothing, row("RespiratoryRate"))
            data("berat") = If(IsDBNull(row("Berat")), Nothing, row("Berat"))
            data("tinggi") = If(IsDBNull(row("Tinggi")), Nothing, row("Tinggi"))
            data("imt") = If(IsDBNull(row("IMT")), Nothing, row("IMT"))
            data("lingkar_perut") = If(IsDBNull(row("LingkarPerut")), Nothing, row("LingkarPerut"))

            Dim json As String = JsonConvert.SerializeObject(data)

            ' ---- Kirim ke API ----
            Dim baseURL As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
            Dim apiUrl As String = baseURL & "api/observations"
            Dim response As String = InsertDataAPIRM(json, apiUrl)

            ' ---- Parsing Response ----
            Try
                Dim rowJson As JObject = JObject.Parse(response)
                Dim status As String = rowJson("status").ToString().Trim().ToLower()
                Dim noTransaksi As String = row("NoTransaksi").ToString()
                Dim encounterId As String = row("idEncounter").ToString()

                If status = "success" Then
                    Dim encounter As String = ReadSQLNIK("SELECT ResourceID FROM SatuSehat_LogTransaksiResource WHERE NoTransaksi = '" & noTransaksi & "' AND ResourceType = 'Encounter'")

                    ' kirim ke UI pakai ReportProgress
                    worker.ReportProgress(0, "Data Observasi " & noTransaksi & " Berhasil Terkirim dengan Encounter." & " {" & encounter & "}")

                    For Each obs In rowJson("responses")
                        Dim obsStatus As String = obs("status").ToString()
                        Dim resourceId As String = obs("body")("id").ToString()
                        Dim resourceType As String = obs("body")("code")("text").ToString()
                        InsertLogObservation(noTransaksi, resourceType, resourceId, encounter, obsStatus)
                    Next

                    UpdateUploadStatus(noTransaksi)
                Else
                    worker.ReportProgress(0, "Gagal kirim No Transaksi: " & noTransaksi & " | Status: " & status)
                End If

            Catch ex As Exception
                worker.ReportProgress(0, "Response tidak valid untuk No Transaksi: " & row("NoTransaksi").ToString() & vbCrLf & "Raw Response: " & response)
            End Try

            ' Delay setiap 100 data
            'If (i + 1) Mod 100 = 0 Then
            '    System.Threading.Thread.Sleep(3000)
            'End If

            'Dim jumlah As Integer = GetJumlahTransaksi()
            'worker.ReportProgress(0, jumlah) ' progress = jumlah transaksi

            'Dim jumlahData As Integer = GetJumlahData()
            'worker.ReportProgress(0, jumlahData)

            ' Update ProgressBar
            Dim percent As Integer = CInt(Math.Floor(((i + 1) * 100.0) / total))
            worker.ReportProgress(percent)

            'Tambahkan delay kecil untuk menghindari spam API 
            Threading.Thread.Sleep(150)
        Next
    End Sub

    ' === ProgressChanged → update UI thread ===
    Private Sub bgWorkerObservasi_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs) Handles bgWorkerObservasi.ProgressChanged
        If e.ProgressPercentage > 0 Then
            UpdateProgress(e.ProgressPercentage)' kirim persen langsung
        End If

        Dim jumlah As Integer = GetJumlahTransaksi()
        LabelJmlTerkirim.Text = jumlah.ToString() & " Transaksi"

        Dim jumlahData As Integer = GetJumlahData()
        LabelData.Text = jumlahData.ToString() & " Data"

        If e.UserState IsNot Nothing Then
            TextBoxResponse.AppendText(e.UserState.ToString() & Environment.NewLine)
        End If
    End Sub

    ' === Selesai Proses Observasi ===
    Private Sub bgWorkerObservasi_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles bgWorkerObservasi.RunWorkerCompleted
        MsgBox("Selesai mengirim semua data.")

        isStopRequested = False
        PostObservasi.Enabled = True
        ButtonGetToken.Enabled = True
        ButtonStopProses.Enabled = False
        ButtonRefresh.Enabled = True
    End Sub

    ' === ProgressChanged → update UI thread untuk Procedure ===
    Private Sub bgWorkerProcedure_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs) Handles bgWorkerProcedure.ProgressChanged
        If e.ProgressPercentage > 0 Then
            UpdateProgress(e.ProgressPercentage) ' update progress bar
        End If

        Dim jumlah As Integer = GetJumlahTransaksiProcedure() ' fungsi hitung transaksi Procedure
        LabelJmlTerkirim.Text = jumlah.ToString() & " Transaksi Procedure"

        Dim jumlahData As Integer = GetJumlahDataProcedure() ' fungsi hitung data Procedure
        LabelData.Text = jumlahData.ToString() & " Data Procedure"

        If e.UserState IsNot Nothing Then
            TextBoxResponse.AppendText("[Procedure] " & e.UserState.ToString() & Environment.NewLine)
        End If
    End Sub

    ' === Selesai Proses Procedure ===
    Private Sub bgWorkerProcedure_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles bgWorkerProcedure.RunWorkerCompleted
        MsgBox("Selesai mengirim semua data Procedure.")

        isStopRequested = False
        PostObservasi.Enabled = True
        ButtonGetToken.Enabled = True
        ButtonStopProses.Enabled = False
        ButtonRefresh.Enabled = True
    End Sub

    ' === Update ProgressBar ===
    Private Sub UpdateProgress(ByVal percent As Integer)
        'Dim percent As Integer = CInt((current / total) * 100)

        ' Hitung lebar Panel Progress
        Dim maxWidth As Integer = PanelProgressBG.Width
        Dim newWidth As Integer = CInt((percent / 100.0) * maxWidth)

        PanelProgressFill.Width = newWidth
        LabelProgress.Text = percent.ToString() & "%"

        'Application.DoEvents() ' biar UI tetap responsif
    End Sub

    Private Sub ButtonStopProses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonStopProses.Click
        isStopRequested = True
    End Sub

    Private Sub ButtonRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRefresh.Click
        TextBoxResponse.Clear()
    End Sub
End Class