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
        RoundButton(PostSatuSehat)
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
        ComboBoxJenisData.Items.Add("Medication")
        ComboBoxJenisData.SelectedIndex = -1
        PostSatuSehat.Enabled = False

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
            ElseIf Pilihan = "Medication" Then
                Dim jumlahData As Integer = GetJumlahData()
                LabelData.Text = jumlahData.ToString() & " Data"

                Dim jumlah As Integer = GetJumlahTransaksiMedication()
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

    Private Sub PostSatuSehat_MouseEnter(ByVal sender As Object, ByVal e As EventArgs) Handles PostSatuSehat.MouseEnter
        PostSatuSehat.BackColor = Color.FromArgb(30, 144, 255)
    End Sub

    Private Sub ButtonRefresh_MouseEnter(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonRefresh.MouseEnter
        ButtonRefresh.BackColor = Color.FromArgb(30, 144, 255)
    End Sub

    Private Sub ButtonRefresh_MouseLeave(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonRefresh.MouseLeave
        ButtonRefresh.BackColor = Color.FromArgb(0, 100, 200)
    End Sub

    Private Sub PostSatuSehat_MouseLeave(ByVal sender As Object, ByVal e As EventArgs) Handles PostSatuSehat.MouseLeave
        PostSatuSehat.BackColor = Color.FromArgb(0, 100, 200)
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

    Private Sub InsertLogMedication(ByVal ObatID As String, ByVal NamaObat As String, ByVal ResourceID As String)
        Dim sql As String = "INSERT INTO SatuSehat_LogMedication " & _
                            "(ObatID, NamaObat, ResourceID, CreatedBy, CreatedDate) " & _
                            "VALUES('" & ObatID & "', '" & NamaObat & "', '" & ResourceID & "', '" & userInput & "', GETDATE())"
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

    Private Sub UpdateUploadStatusMedication(ByVal ObatID As String)
        Dim sql As String = "UPDATE MasterObatKFA SET UploadSatuSehat = 1 WHERE KodeLokal = '" & ObatID & "'"
        WriteSQL(sql, 4)
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

    Private Function GetDataObatKFA() As DataTable
        Dim tbls As DataTable = New DataTable()
        Dim queryDataUpload As New StringBuilder()

        queryDataUpload.AppendLine("SELECT ")
        queryDataUpload.AppendLine("    KodeLokal,")
        queryDataUpload.AppendLine("    KodeKFA,")
        queryDataUpload.AppendLine("    POA,")
        queryDataUpload.AppendLine("    NamaObatLokal,")
        queryDataUpload.AppendLine("    BentukSediaanCode,")
        queryDataUpload.AppendLine("    BentukSediaanNama,")
        queryDataUpload.AppendLine("    BZACode,")
        queryDataUpload.AppendLine("    BZA,")
        queryDataUpload.AppendLine("    BZANumerator,")
        queryDataUpload.AppendLine("    BZASatuan,")
        queryDataUpload.AppendLine("    BahanBakuSatuan")
        queryDataUpload.AppendLine("FROM MasterObatKFA")
        queryDataUpload.AppendLine("WHERE KodeLokal IS NOT NULL")
        queryDataUpload.AppendLine("  AND UploadSatuSehat = 0")
        queryDataUpload.AppendLine("  ORDER BY POA ASC;")

        tbls = ReadSQL(queryDataUpload.ToString())
        Return tbls
    End Function

    Private Sub ComboBoxJenisData_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBoxJenisData.SelectedIndexChanged
        If ComboBoxJenisData.SelectedIndex <> -1 Then
            PostSatuSehat.Enabled = True
        Else
            PostSatuSehat.Enabled = False
        End If
    End Sub

    Private Sub PostSatuSehat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PostSatuSehat.Click
        Dim pilihan As String = ComboBoxJenisData.SelectedItem.ToString()

        If pilihan = "Observation" Then
            If Not bgWorkerObservasi.IsBusy Then
                PostSatuSehat.Enabled = False
                ButtonGetToken.Enabled = False
                ButtonStopProses.Enabled = True
                ButtonRefresh.Enabled = False
                TextBoxResponse.Clear()

                bgWorkerObservasi.RunWorkerAsync()
            End If

        ElseIf pilihan = "Procedure" Then
            If Not bgWorkerProcedure.IsBusy Then
                PostSatuSehat.Enabled = False
                ButtonGetToken.Enabled = False
                ButtonStopProses.Enabled = True
                ButtonRefresh.Enabled = False
                TextBoxResponse.Clear()

                bgWorkerProcedure.RunWorkerAsync()
            End If
        ElseIf pilihan = "Medication" Then
            If Not bgWorkerMedication.IsBusy Then
                PostSatuSehat.Enabled = False
                ButtonGetToken.Enabled = False
                ButtonStopProses.Enabled = True
                ButtonRefresh.Enabled = False
                TextBoxResponse.Clear()

                bgWorkerMedication.RunWorkerAsync()
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

    Private Function GetJumlahTransaksiMedication() As Integer
        Dim dtCek As DataTable = ReadSQL("SELECT COUNT(DISTINCT ObatID) AS Jumlah FROM SatuSehat_LogMedication")

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

    Private Function GetJumlahDataMedication() As Integer
        Dim dtCek As DataTable = ReadSQL("SELECT COUNT(*) AS JumlahData FROM MasterObatKFA " & _
            "WHERE KodeLokal IS NOT NULL " & _
            "AND UploadSatuSehat = '0'")

        If dtCek.Rows.Count > 0 AndAlso Not IsDBNull(dtCek.Rows(0)("JumlahData")) Then
            Return Convert.ToInt32(dtCek.Rows(0)("JumlahData"))
        End If

        Return 0
    End Function

    Private Function SafeGet(ByVal obj As JObject, ByVal ParamArray path() As String) As String
        Try
            Dim token As JToken = obj
            For Each p In path
                If token Is Nothing OrElse token(p) Is Nothing Then
                    Return ""
                End If
                token = token(p)
            Next
            Return token.ToString()
        Catch
            Return ""
        End Try
    End Function

    Private Sub bgWorkerMedication_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles bgWorkerMedication.DoWork
        Dim tbls As DataTable = GetDataObatKFA() ' ambil data obat dari DB
        Dim worker As BackgroundWorker = CType(sender, BackgroundWorker)
        Dim total As Integer = tbls.Rows.Count
        Dim maxRetry As Integer = 3

        For i As Integer = 0 To tbls.Rows.Count - 1
            If isStopRequested Then Exit For

            Dim row As DataRow = tbls.Rows(i)

            ' ---- Buat payload JSON ----
            Dim data As New Dictionary(Of String, Object)
            data("organization_id") = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'satu_sehat_organization_id'")

            Dim listObat As New List(Of Dictionary(Of String, Object))
            Dim obat As New Dictionary(Of String, Object)

            obat("local_id") = row("KodeLokal").ToString()
            obat("kfa_code") = row("KodeKFA").ToString()
            obat("display") = row("POA").ToString()
            obat("displayLokal") = row("NamaObatLokal").ToString()
            obat("form_code") = row("BentukSediaanCode").ToString()
            obat("form_display") = row("BentukSediaanNama").ToString()
            obat("ingredient_code") = row("BZACode").ToString()
            obat("ingredient_display") = row("BZA").ToString()
            obat("strength_value") = row("BZANumerator").ToString()
            obat("satuan") = row("BZASatuan").ToString()
            obat("satuanDenominator") = row("BahanBakuSatuan").ToString()
            obat("organization_id") = data("organization_id")

            listObat.Add(obat)
            data("obat") = listObat

            Dim json As String = JsonConvert.SerializeObject(data)

            ' ---- Kirim ke API Laravel ----
            Dim baseURL As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
            Dim apiUrl As String = baseURL & "api/medications"
            Dim response As String = InsertDataAPIRM(json, apiUrl)

            ' ---- Parsing Response ----
            Try
                Dim rowJson As JObject = JObject.Parse(response)
                Dim status As String = rowJson("status").ToString().Trim().ToLower()

                If status = "success" Then
                    worker.ReportProgress(0, String.Format("[Medication] {0} status success dari SATUSEHAT.", row("KodeLokal").ToString()))

                    For Each resp As JObject In rowJson("responses")
                        Dim respStatus As String = resp("status").ToString()
                        Dim resourceId As String = ""
                        Dim resourceType As String = "Medication"

                        Select Case respStatus
                            Case "200", "201"
                                ' Cek body dulu
                                If resp("body") IsNot Nothing AndAlso resp("body")("id") IsNot Nothing Then
                                    resourceId = resp("body")("id").ToString()
                                    worker.ReportProgress(0, String.Format("[Medication] {0} berhasil ({1}) dengan ID (body): {2}", row("KodeLokal").ToString(), respStatus, resourceId))
                                ElseIf resp("response") IsNot Nothing AndAlso resp("response")("id") IsNot Nothing Then
                                    resourceId = resp("response")("id").ToString()
                                    worker.ReportProgress(0, String.Format("[Medication] {0} berhasil ({1}) dengan ID (response): {2}", row("KodeLokal").ToString(), respStatus, resourceId))
                                Else
                                    worker.ReportProgress(0, String.Format("[Medication] {0} berhasil ({1}) tapi ID tidak ditemukan. Raw: {2}", row("KodeLokal").ToString(), respStatus, resp.ToString()))
                                End If

                            Case "400"
                                ' cek kalau ada body & issue
                                If resp("body") IsNot Nothing AndAlso resp("body")("issue") IsNot Nothing Then
                                    Dim issueCode As String = resp("body")("issue")(0)("code").ToString().ToLower()
                                    Dim issueText As String = ""

                                    Try
                                        issueText = resp("body")("issue")(0)("details")("text").ToString()
                                    Catch
                                        issueText = "Tanpa issue detail"
                                    End Try

                                    If issueCode = "duplicate" Then
                                        resourceId = "DUPLICATE"
                                        worker.ReportProgress(0, String.Format("[Medication] Duplicate untuk KodeLokal: {0}", row("KodeLokal").ToString()))
                                    Else
                                        worker.ReportProgress(0, String.Format("[Medication] Error {0} | {1}", row("KodeLokal").ToString(), issueText))
                                    End If
                                Else
                                    ' fallback → kalau tidak ada issue, tampilkan JSON ringkas
                                    Dim rawCompact As String = JObject.Parse(resp.ToString()).ToString(Newtonsoft.Json.Formatting.None)
                                    worker.ReportProgress(0, String.Format("[Medication] Error {0} tanpa issue detail. Raw: {1}", row("KodeLokal").ToString(), rawCompact))
                                End If

                            Case Else
                                worker.ReportProgress(0, "[Medication] Response tetap tidak valid setelah " & maxRetry & " retry untuk " & row("KodeLokal").ToString() & " | Raw Response: " & response)

                        End Select

                        InsertLogMedication(row("KodeLokal").ToString(), row("NamaObatLokal").ToString(), resourceId)
                    Next

                    UpdateUploadStatusMedication(row("KodeLokal").ToString())
                Else
                    worker.ReportProgress(0, String.Format("[Medication] Gagal kirim untuk {0} | Status: {1}", row("KodeLokal").ToString(), status))
                End If

            Catch ex As Exception
                ' JSON invalid atau error lain saat parsing
                worker.ReportProgress(0, "[Medication] Exception awal: " & ex.Message & " | Raw: " & response)

                Dim attempt As Integer = 1
                Dim successRetry As Boolean = False

                While attempt <= maxRetry AndAlso Not successRetry
                    Try
                        Threading.Thread.Sleep(1000)
                        response = InsertDataAPIRM(json, apiUrl)

                        Dim rowJsonRetry As JObject = JObject.Parse(response)
                        Dim statusRetry As String = rowJsonRetry("status").ToString().Trim().ToLower()

                        If statusRetry = "success" Then
                            worker.ReportProgress(0, "[Medication] Retry ke-" & attempt & " berhasil untuk KodeLokal: " & row("KodeLokal").ToString())

                            For Each resp In rowJsonRetry("responses")
                                Dim respStatus As String = resp("status").ToString()
                                Dim resourceId As String = ""
                                Dim resourceType As String = "Medication"

                                Select Case respStatus
                                    Case "200", "201"
                                        resourceId = resp("body")("id").ToString()
                                        worker.ReportProgress(0, "[Medication] Retry ID: " & resourceId)

                                    Case "400"
                                        Dim issueText As String = "Tanpa issue detail"
                                        Try
                                            issueText = resp("body")("issue")(0)("details")("text").ToString()
                                        Catch
                                        End Try

                                        Dim issueCode As String = ""
                                        Try
                                            issueCode = resp("body")("issue")(0)("code").ToString().ToLower()
                                        Catch
                                        End Try

                                        If issueCode = "duplicate" Then
                                            resourceId = "DUPLICATE"
                                            worker.ReportProgress(0, "[Medication] Duplicate (retry) untuk KodeLokal: " & row("KodeLokal").ToString())
                                        Else
                                            worker.ReportProgress(0, "[Medication] Error retry: " & issueText)
                                        End If

                                    Case Else
                                        Dim compact As String = JObject.Parse(resp.ToString()).ToString(Newtonsoft.Json.Formatting.None)
                                        worker.ReportProgress(0, "[Medication] Retry status tidak diketahui: " & compact)
                                End Select

                                InsertLogMedication(row("KodeLokal").ToString(), row("NamaObatLokal").ToString(), resourceId)
                            Next

                            'Update walau duplicate
                            UpdateUploadStatusMedication(row("KodeLokal").ToString())
                            successRetry = True
                        Else
                            worker.ReportProgress(0, "[Medication] Retry ke-" & attempt & " gagal, status: " & statusRetry)
                        End If

                    Catch rex As Exception
                        worker.ReportProgress(0, "[Medication] Exception di retry ke-" & attempt & ": " & rex.Message)
                    End Try

                    attempt += 1
                End While

                If Not successRetry Then
                    Dim rawCompact As String = response
                    Try
                        rawCompact = JObject.Parse(response).ToString(Newtonsoft.Json.Formatting.None)
                    Catch
                    End Try

                    worker.ReportProgress(0, "[Medication] Response tetap tidak valid setelah " & maxRetry & " retry untuk KodeLokal: " & row("KodeLokal").ToString() & " | Raw Response: " & rawCompact)
                End If
            End Try


            ' Progress bar update
            Dim percent As Integer = CInt(Math.Floor(((i + 1) * 100.0) / total))
            worker.ReportProgress(percent)

            Threading.Thread.Sleep(300)
            If (i + 1) Mod 50 = 0 Then
                worker.ReportProgress(0, String.Format("Delay 5 detik setelah kirim {0} Medication...", (i + 1).ToString()))
                Threading.Thread.Sleep(5000)
            End If
        Next
    End Sub

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
        Dim maxRetry As Integer = 3

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

            Dim response As String = ""
            Dim attempt As Integer = 1
            Dim successRetry As Boolean = False
            Dim noTransaksi As String = row("NoTransaksi").ToString()

            While attempt <= maxRetry AndAlso Not successRetry
                Try
                    If attempt > 1 Then
                        Threading.Thread.Sleep(1000) ' tunggu 1 detik sebelum retry
                    End If

                    response = InsertDataAPIRM(json, apiUrl)

                    Dim rowJson As JObject = JObject.Parse(response)
                    Dim status As String = rowJson("status").ToString().Trim().ToLower()
                    Dim encounterId As String = row("idEncounter").ToString()

                    If status = "success" Then
                        Dim encounter As String = ReadSQLNIK("SELECT ResourceID FROM SatuSehat_LogTransaksiResource WHERE NoTransaksi = '" & noTransaksi & "' AND ResourceType = 'Encounter'")

                        worker.ReportProgress(0, "Data Observasi " & noTransaksi & " Berhasil Terkirim dengan Encounter {" & encounter & "}")

                        For Each obs In rowJson("responses")
                            Dim obsStatus As String = obs("status").ToString()
                            Dim resourceId As String = obs("body")("id").ToString()
                            Dim resourceType As String = obs("body")("code")("text").ToString()
                            InsertLogObservation(noTransaksi, resourceType, resourceId, encounter, obsStatus)
                        Next

                        UpdateUploadStatus(noTransaksi)
                        successRetry = True
                    Else
                        worker.ReportProgress(0, "Gagal kirim No Transaksi: " & noTransaksi & " | Status: " & status)
                        Exit While ' kalau status bukan success, tidak perlu retry JSON error
                    End If

                Catch ex As Exception
                    ' Kalau parsing gagal, coba ulang sampai maxRetry
                    worker.ReportProgress(0, "Response tidak valid (percobaan " & attempt & ") untuk No Transaksi: " & noTransaksi & vbCrLf & "Raw Response: " & response)
                    attempt += 1
                End Try
            End While

            If Not successRetry Then
                worker.ReportProgress(0, "Gagal kirim setelah " & maxRetry & " kali percobaan untuk No Transaksi: " & noTransaksi)
            End If

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
            UpdateProgress(e.ProgressPercentage) ' kirim persen langsung
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
        PostSatuSehat.Enabled = True
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
        PostSatuSehat.Enabled = True
        ButtonGetToken.Enabled = True
        ButtonStopProses.Enabled = False
        ButtonRefresh.Enabled = True
    End Sub

    ' === ProgressChanged → update UI thread untuk Medication ===
    Private Sub bgWorkerMedication_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs) Handles bgWorkerMedication.ProgressChanged
        If e.ProgressPercentage > 0 Then
            UpdateProgress(e.ProgressPercentage) ' update progress bar
        End If

        Dim jumlah As Integer = GetJumlahTransaksiMedication() ' fungsi hitung transaksi Procedure
        LabelJmlTerkirim.Text = jumlah.ToString() & " Transaksi Medication"

        Dim jumlahData As Integer = GetJumlahDataMedication() ' fungsi hitung data Procedure
        LabelData.Text = jumlahData.ToString() & " Data Medication"

        If e.UserState IsNot Nothing Then
            TextBoxResponse.AppendText("[Medication] " & e.UserState.ToString() & Environment.NewLine)
        End If
    End Sub

    ' === Selesai Proses Procedure ===
    Private Sub bgWorkerMedication_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles bgWorkerMedication.RunWorkerCompleted
        MsgBox("Selesai mengirim semua data Medication.")

        isStopRequested = False
        PostSatuSehat.Enabled = True
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