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

Public Class FormObservation
    Private userInput As String = PoliKlinik.Lbluser.Text

    Private Sub RoundButton(ByVal btn As Button)
        Dim r As New GraphicsPath()
        r.AddArc(0, 0, 20, 20, 180, 90)
        r.AddArc(btn.Width - 20, 0, 20, 20, 270, 90)
        r.AddArc(btn.Width - 20, btn.Height - 20, 20, 20, 0, 90)
        r.AddArc(0, btn.Height - 20, 20, 20, 90, 90)
        r.CloseFigure()
        btn.Region = New Region(r)
    End Sub

    Private Sub FormObservation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        Me.Dock = DockStyle.Fill
        Me.WindowState = FormWindowState.Maximized
        RoundButton(ButtonGetToken)
        RoundButton(PostObservasi)
        'ProgressBar.BackColor = Color.Gainsboro
    End Sub

    Private Sub ButtonGetToken_MouseEnter(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonGetToken.MouseEnter
        ButtonGetToken.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub ButtonGetToken_MouseLeave(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonGetToken.MouseLeave
        ButtonGetToken.BackColor = Color.FromArgb(52, 150, 219)
    End Sub

    Private Sub PostObservasi_MouseEnter(ByVal sender As Object, ByVal e As EventArgs) Handles PostObservasi.MouseEnter
        PostObservasi.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub PostObservasi_MouseLeave(ByVal sender As Object, ByVal e As EventArgs) Handles PostObservasi.MouseLeave
        PostObservasi.BackColor = Color.FromArgb(52, 150, 219)
    End Sub

    Private Sub ButtonGetToken_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGetToken.Click
        ' === AMBIL TOKEN BARU ===
        Dim tokenValue As String = GetTokenSatuSehat()

        ' Validasi token
        If String.IsNullOrEmpty(tokenValue) OrElse tokenValue.StartsWith("Error") Then
            MessageBox.Show("Gagal mendapatkan token: " & tokenValue)
            Exit Sub
        End If

        ' Buat JSON untuk dikirim ke webservice Laravel
        Dim json As String = "{""access_token"":""" & tokenValue & """,""expires_in"":14399}"

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

    Private Sub UpdateUploadStatus(ByVal noTransaksi As String)
        Dim sql As String = "UPDATE TransaksiDetailFisik SET UploadSatuSehat = 1 WHERE NoTransaksi = '" & noTransaksi & "'"
        WriteSQL(sql, 4)
    End Sub

    Private Sub UpdateProgress(ByVal current As Integer, ByVal total As Integer)
        Dim percent As Integer = CInt((current / total) * 100)

        ' Hitung lebar Panel Progress
        Dim maxWidth As Integer = PanelProgressBG.Width
        Dim newWidth As Integer = CInt((percent / 100.0) * maxWidth)

        PanelProgressFill.Width = newWidth
        LabelProgress.Text = percent.ToString() & "%"

        Application.DoEvents() ' biar UI tetap responsif
    End Sub


    Private Sub PostObservasi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PostObservasi.Click
        TextBoxResponse.Clear()

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

        ' --- Atur ProgressBar ---
        'ProgressBar.Minimum = 0
        'ProgressBar.Maximum = tbls.Rows.Count
        'ProgressBar.Value = 0

        For i As Integer = 0 To tbls.Rows.Count - 1
            Dim row As DataRow = tbls.Rows(i)

            ' Siapkan payload JSON untuk dikirim ke Laravel
            Dim data As New Dictionary(Of String, Object)
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

            ' Kirim ke endpoint Laravel pakai fungsi yang sudah kamu punya
            Dim baseURL As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")
            Dim apiUrl As String = baseURL & "api/observations"
            Dim response As String = InsertDataAPIRM(json, apiUrl)

            'MsgBox("Raw Response: " & response)

            ' --- Parsing response ---
            Try
                Dim rowJson As JObject = JObject.Parse(response)
                Dim status As String = rowJson("status").ToString().Trim().ToLower()
                Dim noTransaksi As String = row("NoTransaksi").ToString()
                Dim encounterId As String = row("idEncounter").ToString()

                If status = "success" Then
                    Dim encounter As String = ReadSQLNIK("SELECT ResourceID FROM SatuSehat_LogTransaksiResource where NoTransaksi = '" & noTransaksi & "' and ResourceType = 'Encounter'")
                    TextBoxResponse.AppendText("Data Terkirim No Transaksi: " & noTransaksi & " {" & encounter & "}" & Environment.NewLine)

                    ' Simpan ke DB untuk setiap observation
                    For Each obs In rowJson("responses")
                        Dim obsStatus As String = obs("status").ToString()
                        Dim resourceId As String = obs("body")("id").ToString()
                        Dim resourceType As String = obs("body")("code")("text").ToString()
                        'Dim encounterRef As String = obs("body")("encounter")("reference").ToString()

                        InsertLogObservation(noTransaksi, resourceType, resourceId, encounter, obsStatus)
                    Next

                    ' Update status UploadSatuSehat
                    UpdateUploadStatus(noTransaksi)
                Else
                    TextBoxResponse.AppendText("Gagal kirim No Transaksi: " & noTransaksi & _
                                               " | Status: " & status & Environment.NewLine)
                End If

            Catch ex As Exception
                MsgBox("Response tidak valid untuk No Transaksi: " & row("NoTransaksi").ToString() & vbCrLf & _
                       "Raw Response: " & response, MsgBoxStyle.Critical, "Error Parsing Response")
            End Try

            ' --- Update ProgressBar ---
            UpdateProgress(i + 1, tbls.Rows.Count)
        Next
        MsgBox("Selesai mengirim semua data.")
    End Sub
End Class