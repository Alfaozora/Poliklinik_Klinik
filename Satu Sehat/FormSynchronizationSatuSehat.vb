Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Drawing
Imports System.Security.Cryptography
Imports System.Collections.Generic
Imports System.Web.UI.WebControls
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Text
Imports System.Globalization

Public Class FormSynchronizationSatuSehat
    Private thread As System.Threading.Thread
    Private formName As String = "DASHBOARD SATU SEHAT"
    Private userInput As String = PoliKlinik.Lbluser.Text

    ' Status Proses
    Private statusProses As String = ""

    ' Set Oragnization ID
    Private organizationID As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'satu_sehat_organization_id'")

    Private Sub PanelTop_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelTop.Paint
        Try
            e.Graphics.DrawString(formName, New Font("Arial", 12, FontStyle.Bold), Brushes.White, New Point(10, 10))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If statusProses = "Running" Then
            MsgBox("Proses Upload Masih Dalam Proses.", MsgBoxStyle.Exclamation, "Warning!")
        Else
            Me.Close()
        End If
    End Sub

    Private Sub Find_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.MdiParent = PoliKlinik
            Me.Dock = DockStyle.Fill

            Control.CheckForIllegalCrossThreadCalls = False

            ' Clear data
            SetAwal()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub SetAwal()
        RefreshDashboard()

        LabelProgress.Text = "Pending"
        ' Create DataGridView
        'CreateDataGridViewKunjunganPasien()
    End Sub

    Function Checking() As Boolean
        'If ComboBoxPoliTujuan.SelectedIndex = -1 Then
        '    MsgBox("Pilih poli tujuan terlebih dahulu.", MsgBoxStyle.Exclamation, "Warning!")
        '    Return False
        'End If

        Return True
    End Function

    Private Sub ButtonSinkronisasi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSinkronisasi.Click
        thread = New System.Threading.Thread(AddressOf Synchronization)
        thread.Start()
    End Sub

    Private Sub Synchronization()
        Try
            ' Set Status Proses
            statusProses = "Running"

            Dim tbls As DataTable = New DataTable
            Dim queryDataUpload As New StringBuilder()

            queryDataUpload.AppendLine("SELECT a.NoUrut, 'UMUM' AS 'Jenis'")
            queryDataUpload.AppendLine("FROM TransaksiPoli a")
            queryDataUpload.AppendLine("LEFT JOIN MasterPasien b ON a.IDInternet=b.NoRekamMedis")
            queryDataUpload.AppendLine("WHERE a.StatusTransaksi='finished' AND a.UploadSatuSehat=0 AND a.Deleted=0")
            queryDataUpload.AppendLine("AND b.NoIHS<>'' AND CONVERT(DATE, a.TglPoli) <> CONVERT(DATE, GETDATE())")
            queryDataUpload.AppendLine("AND (a.ArrivedDate IS NOT NULL AND a.InProgressDate IS NOT NULL AND a.FinishedDate IS NOT NULL)")
            queryDataUpload.AppendLine("UNION ALL")
            queryDataUpload.AppendLine("SELECT a.NoUrut, 'GIGI' AS 'Jenis'")
            queryDataUpload.AppendLine("FROM TransaksiGigi a")
            queryDataUpload.AppendLine("LEFT JOIN MasterPasien b ON a.IDInternet=b.NoRekamMedis")
            queryDataUpload.AppendLine("WHERE a.StatusTransaksi='finished' AND a.UploadSatuSehat=0 AND a.Deleted=0")
            queryDataUpload.AppendLine("AND b.NoIHS<>'' AND CONVERT(DATE, TglGigi) <> CONVERT(DATE, GETDATE())")
            queryDataUpload.AppendLine("AND (a.ArrivedDate IS NOT NULL AND a.InProgressDate IS NOT NULL AND a.FinishedDate IS NOT NULL)")
            queryDataUpload.AppendLine("ORDER BY NoUrut ASC")

            ' All Data Poli Umum & Gigi
            tbls = ReadSQL(queryDataUpload.ToString())

            ' Production
            'tbls = ReadSQL("SELECT TOP(2000) a.* FROM TransaksiPoli a " & _
            '               "LEFT JOIN MasterPasien b ON a.IDInternet = b.NoRekamMedis " & _
            '               "WHERE StatusTransaksi = 'finished' AND UploadSatuSehat = 0 AND Deleted = 0 AND b.NoIHS <> '' AND (a.ArrivedDate IS NOT NULL AND a.InProgressDate IS NOT NULL AND a.FinishedDate IS NOT NULL) " & _
            '               "ORDER BY a.TransPoliID ASC")

            ' Develop
            'tbls = ReadSQL("SELECT TOP(100) a.* FROM TransaksiPoli a " & _
            '               "LEFT JOIN MasterPasien b ON a.IDInternet = b.NoRekamMedis " & _
            '               "WHERE StatusTransaksi = 'finished' AND UploadSatuSehat = 0 AND Deleted = 0 AND (a.ArrivedDate IS NOT NULL AND a.InProgressDate IS NOT NULL AND a.FinishedDate IS NOT NULL) " & _
            '               "ORDER BY a.TransPoliID ASC")

            If tbls.Rows.Count > 0 Then
                ButtonSinkronisasi.Enabled = False
                ButtonSinkronisasiIHS.Enabled = False

                Dim persentaseProgres As Integer = 0

                Dim apiEndpoint As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'satu_sehat_base_url'")
                Dim payloadString As String = ""
                Dim encodedJsonData As String = ""
                Dim responseString As String = ""

                Dim transaksiSuccess As Integer = 0
                Dim transaksiProcess As Integer = 0

                For Each Trow As DataRow In tbls.Rows
                    ' Jika status proses stop
                    If statusProses = "Stop" Then Exit For

                    ' Cek Jumlah Proses
                    transaksiProcess += 1

                    payloadString = SetResource(Trow("NoUrut"), Trow("Jenis"))

                    encodedJsonData = Convert.ToBase64String(Encoding.UTF8.GetBytes(payloadString))

                    Dim jsonBuilder As New StringBuilder()
                    jsonBuilder.AppendLine("{")
                    jsonBuilder.AppendLine("  ""jsonEncode"" : """ & encodedJsonData & """")
                    jsonBuilder.AppendLine("}")

                    ' Get Token SATUSEHAT
                    Dim token As String = GetTokenSatuSehat()

                    ' Tahan selama 3 detik agar tidak kena limit
                    System.Threading.Thread.Sleep(4000)

                    responseString = PostDataSatuSehat(token, apiEndpoint, jsonBuilder.ToString())
                    responseString = "[" + responseString + "]"

                    Dim jsonObject() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of ResponseResource())(responseString)

                    For Each rowJson As ResponseResource In jsonObject
                        If rowJson.resourceType <> "OperationOutcome" Then
                            ' Success
                            For index As Integer = 0 To rowJson.entry.Length - 1
                                ' Save Log To Database
                                WriteSQL("INSERT INTO SatuSehat_LogTransaksiResource (NoTransaksi, ResourceType, ResourceID, Status, CreatedBy, CreatedDate) " & _
                                         "VALUES('" & Trow("NoUrut") & "', '" & rowJson.entry(index).response.resourceType & "','" & rowJson.entry(index).response.resourceID & "', '" & rowJson.entry(index).response.status & "', '" & userInput & "', GETDATE())", 4)

                                ' Update Status Upload Satu Sehat
                                If Trow("Jenis") = "UMUM" Then
                                    WriteSQL("UPDATE TransaksiPoli SET UploadSatuSehat = 1 WHERE NoUrut = '" & Trow("NoUrut") & "'", 4)
                                ElseIf Trow("Jenis") = "GIGI" Then
                                    WriteSQL("UPDATE TransaksiGigi SET UploadSatuSehat = 1 WHERE NoUrut = '" & Trow("NoUrut") & "'", 4)
                                End If

                                ' Tampilkan di TextBox Response
                                TextBoxResponse.Text = "Data " & rowJson.entry(index).response.resourceType & " (" & Trow("NoUrut") & ") Berhasil dikirim. (" & rowJson.entry(index).response.resourceID & ")" & vbCrLf & TextBoxResponse.Text
                            Next

                            transaksiSuccess += 1
                        Else
                            ' Error
                            For index As Integer = 0 To rowJson.issue.Length - 1
                                ' Tampilkan di TextBox Response
                                TextBoxResponse.Text = "Data Gagal dikirim (" & Trow("NoUrut") & ") " & rowJson.issue(index).code & " - " & rowJson.issue(index).details.text & "" & vbCrLf & TextBoxResponse.Text
                            Next
                        End If
                    Next

                    RefreshDashboard()

                    persentaseProgres = transaksiProcess * 100 / tbls.Rows.Count
                    ProgressBarSinkronisasi.Value = persentaseProgres

                    LabelProgress.Text = "In Progress " & transaksiProcess & " / " & tbls.Rows.Count & " ( " & persentaseProgres & " % ) "
                Next

                If transaksiSuccess > 0 Then
                    MsgBox(transaksiSuccess & " Data telah dikirim ke SATUSEHAT.", MsgBoxStyle.Information, "Success!")
                Else
                    MsgBox("Tidak ada data yang dikirim.", MsgBoxStyle.Exclamation, "Warning!")
                End If

                LabelProgress.Text = "Complete"

                ButtonSinkronisasi.Enabled = True
                ButtonSinkronisasiIHS.Enabled = True
            Else
                MsgBox("Tidak ada data yang dikirim.", MsgBoxStyle.Exclamation, "Warning!")
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        RefreshDashboard()
        TextBoxResponse.ResetText()
    End Sub

    Private Sub RefreshDashboard()
        Dim jumlahTransaksi As String = ""
        Dim jumlahTransaksiVerifikasi As String = ""
        Dim jumlahTransaksiNonVerifikasi As String = ""
        Dim jumlahTransaksiSatuSehat As String = ""
        Dim persentaseTransaksiVerifikasi As Double = 0
        Dim persentaseTransaksiNonVerifikasi As Double = 0
        Dim persentaseTransaksiSatuSehat As Double = 0

        Dim jumlahPasienTanpaNomorIHS As String = ""

        Dim queryJumlahTransaksi As New StringBuilder()
        queryJumlahTransaksi.AppendLine("SELECT COUNT(*) AS 'Jumlah Transaksi'")
        queryJumlahTransaksi.AppendLine("FROM (")
        queryJumlahTransaksi.AppendLine("    SELECT NoUrut")
        queryJumlahTransaksi.AppendLine("    FROM TransaksiPoli")
        queryJumlahTransaksi.AppendLine("    WHERE StatusTransaksi IS NOT NULL AND Deleted = 0 AND CONVERT(DATE, TglPoli) <> CONVERT(DATE, GETDATE())")
        queryJumlahTransaksi.AppendLine("    UNION ALL")
        queryJumlahTransaksi.AppendLine("    SELECT NoUrut")
        queryJumlahTransaksi.AppendLine("    FROM TransaksiGigi")
        queryJumlahTransaksi.AppendLine("    WHERE StatusTransaksi IS NOT NULL AND Deleted = 0 AND CONVERT(DATE, TglGigi) <> CONVERT(DATE, GETDATE())")
        queryJumlahTransaksi.AppendLine(") AS CombinedTransactions")

        Dim queryJumlahTransaksiVerifikasi As New StringBuilder()
        queryJumlahTransaksiVerifikasi.AppendLine("SELECT COUNT(*) AS 'Jumlah Transaksi'")
        queryJumlahTransaksiVerifikasi.AppendLine("FROM (")
        queryJumlahTransaksiVerifikasi.AppendLine("    SELECT NoUrut")
        queryJumlahTransaksiVerifikasi.AppendLine("    FROM TransaksiPoli")
        queryJumlahTransaksiVerifikasi.AppendLine("    WHERE StatusTransaksi = 'finished' AND Deleted = 0 AND CONVERT(DATE, TglPoli) <> CONVERT(DATE, GETDATE())")
        queryJumlahTransaksiVerifikasi.AppendLine("    UNION ALL")
        queryJumlahTransaksiVerifikasi.AppendLine("    SELECT NoUrut")
        queryJumlahTransaksiVerifikasi.AppendLine("    FROM TransaksiGigi")
        queryJumlahTransaksiVerifikasi.AppendLine("    WHERE StatusTransaksi = 'finished' AND Deleted = 0 AND CONVERT(DATE, TglGigi) <> CONVERT(DATE, GETDATE())")
        queryJumlahTransaksiVerifikasi.AppendLine(") AS CombinedTransactions")

        Dim queryJumlahTransaksiNonVerifikasi As New StringBuilder()
        queryJumlahTransaksiNonVerifikasi.AppendLine("SELECT COUNT(*) AS 'Jumlah Transaksi'")
        queryJumlahTransaksiNonVerifikasi.AppendLine("FROM (")
        queryJumlahTransaksiNonVerifikasi.AppendLine("    SELECT NoUrut")
        queryJumlahTransaksiNonVerifikasi.AppendLine("    FROM TransaksiPoli")
        queryJumlahTransaksiNonVerifikasi.AppendLine("    WHERE StatusTransaksi <> 'finished' AND Deleted = 0 AND CONVERT(DATE, TglPoli) <> CONVERT(DATE, GETDATE())")
        queryJumlahTransaksiNonVerifikasi.AppendLine("    UNION ALL")
        queryJumlahTransaksiNonVerifikasi.AppendLine("    SELECT NoUrut")
        queryJumlahTransaksiNonVerifikasi.AppendLine("    FROM TransaksiGigi")
        queryJumlahTransaksiNonVerifikasi.AppendLine("    WHERE StatusTransaksi <> 'finished' AND Deleted = 0 AND CONVERT(DATE, TglGigi) <> CONVERT(DATE, GETDATE())")
        queryJumlahTransaksiNonVerifikasi.AppendLine(") AS CombinedTransactions")

        Dim queryJumlahTransaksiSatuSehat As New StringBuilder()
        queryJumlahTransaksiSatuSehat.AppendLine("SELECT COUNT(*) AS 'Jumlah Transaksi'")
        queryJumlahTransaksiSatuSehat.AppendLine("FROM (")
        queryJumlahTransaksiSatuSehat.AppendLine("    SELECT NoUrut")
        queryJumlahTransaksiSatuSehat.AppendLine("    FROM TransaksiPoli")
        queryJumlahTransaksiSatuSehat.AppendLine("    WHERE StatusTransaksi IS NOT NULL AND UploadSatuSehat = 1 AND Deleted = 0 AND CONVERT(DATE, TglPoli) <> CONVERT(DATE, GETDATE())")
        queryJumlahTransaksiSatuSehat.AppendLine("    UNION ALL")
        queryJumlahTransaksiSatuSehat.AppendLine("    SELECT NoUrut")
        queryJumlahTransaksiSatuSehat.AppendLine("    FROM TransaksiGigi")
        queryJumlahTransaksiSatuSehat.AppendLine("    WHERE StatusTransaksi IS NOT NULL AND UploadSatuSehat = 1 AND Deleted = 0 AND CONVERT(DATE, TglGigi) <> CONVERT(DATE, GETDATE())")
        queryJumlahTransaksiSatuSehat.AppendLine(") AS CombinedTransactions")

        Dim queryJumlahPasienTanpaNomorIHS As New StringBuilder()
        queryJumlahPasienTanpaNomorIHS.AppendLine("SELECT COUNT(*) AS 'Jumlah Transaksi'")
        queryJumlahPasienTanpaNomorIHS.AppendLine("FROM (")
        queryJumlahPasienTanpaNomorIHS.AppendLine("    SELECT b.NoRekamMedis, b.NoNIK")
        queryJumlahPasienTanpaNomorIHS.AppendLine("    FROM TransaksiPoli a")
        queryJumlahPasienTanpaNomorIHS.AppendLine("    LEFT JOIN MasterPasien b ON a.IDInternet = b.NoRekamMedis")
        queryJumlahPasienTanpaNomorIHS.AppendLine("    WHERE a.StatusTransaksi = 'finished'")
        queryJumlahPasienTanpaNomorIHS.AppendLine("      AND a.UploadSatuSehat = 0")
        queryJumlahPasienTanpaNomorIHS.AppendLine("      AND a.Deleted = 0")
        queryJumlahPasienTanpaNomorIHS.AppendLine("      AND b.NoIHS = '' AND CONVERT(DATE, a.TglPoli) <> CONVERT(DATE, GETDATE())")
        queryJumlahPasienTanpaNomorIHS.AppendLine("      AND (a.ArrivedDate IS NOT NULL")
        queryJumlahPasienTanpaNomorIHS.AppendLine("           AND a.InProgressDate IS NOT NULL")
        queryJumlahPasienTanpaNomorIHS.AppendLine("           AND a.FinishedDate IS NOT NULL)")
        queryJumlahPasienTanpaNomorIHS.AppendLine("    UNION ALL")
        queryJumlahPasienTanpaNomorIHS.AppendLine("    SELECT b.NoRekamMedis, b.NoNIK")
        queryJumlahPasienTanpaNomorIHS.AppendLine("    FROM TransaksiGigi a")
        queryJumlahPasienTanpaNomorIHS.AppendLine("    LEFT JOIN MasterPasien b ON a.IDInternet = b.NoRekamMedis")
        queryJumlahPasienTanpaNomorIHS.AppendLine("    WHERE a.StatusTransaksi = 'finished'")
        queryJumlahPasienTanpaNomorIHS.AppendLine("      AND a.UploadSatuSehat = 0")
        queryJumlahPasienTanpaNomorIHS.AppendLine("      AND a.Deleted = 0")
        queryJumlahPasienTanpaNomorIHS.AppendLine("      AND b.NoIHS = '' AND CONVERT(DATE, a.TglGigi) <> CONVERT(DATE, GETDATE())")
        queryJumlahPasienTanpaNomorIHS.AppendLine("      AND (a.ArrivedDate IS NOT NULL")
        queryJumlahPasienTanpaNomorIHS.AppendLine("           AND a.InProgressDate IS NOT NULL")
        queryJumlahPasienTanpaNomorIHS.AppendLine("           AND a.FinishedDate IS NOT NULL)")
        queryJumlahPasienTanpaNomorIHS.AppendLine(") AS CombinedResults")

        ' Set Jumlah Transaksi
        jumlahTransaksi = ReadSQLNIK(queryJumlahTransaksi.ToString())
        jumlahTransaksiVerifikasi = ReadSQLNIK(queryJumlahTransaksiVerifikasi.ToString())
        jumlahTransaksiNonVerifikasi = ReadSQLNIK(queryJumlahTransaksiNonVerifikasi.ToString())
        jumlahTransaksiSatuSehat = ReadSQLNIK(queryJumlahTransaksiSatuSehat.ToString())
        jumlahPasienTanpaNomorIHS = ReadSQLNIK(queryJumlahPasienTanpaNomorIHS.ToString())

        ' Set Persentase Transaksi
        persentaseTransaksiVerifikasi = (jumlahTransaksiVerifikasi / jumlahTransaksi) * 100
        persentaseTransaksiNonVerifikasi = (jumlahTransaksiNonVerifikasi / jumlahTransaksi) * 100
        persentaseTransaksiSatuSehat = (jumlahTransaksiSatuSehat / jumlahTransaksi) * 100

        LabelJumlahTransaksi.Text = jumlahTransaksi & " Transaksi"
        LabelJumlahTransaksiVerifikasi.Text = jumlahTransaksiVerifikasi & " Transaksi"
        LabelJumlahTransaksiNonVerifikasi.Text = jumlahTransaksiNonVerifikasi & " Transaksi"
        LabelJumlahTransaksiSatuSehat.Text = jumlahTransaksiSatuSehat & " Transaksi"
        LabelJumlahPasienTanpaNomorIHS.Text = jumlahPasienTanpaNomorIHS & " Transaksi"

        LabelPersentaseTransaksiVerifikasi.Text = Math.Round(persentaseTransaksiVerifikasi, 1) & "%"
        LabelPersentaseTransaksiNonVerifikasi.Text = Math.Round(persentaseTransaksiNonVerifikasi, 1) & "%"
        LabelPersentaseTransaksiSatuSehat.Text = Math.Round(persentaseTransaksiSatuSehat, 1) & "%"

        Dim lastDateSinkron As String = ReadSQLNIK("SELECT TOP(1) CreatedDate FROM SatuSehat_LogTransaksiResource ORDER BY CreatedDate DESC")
        LabelSinkronisasi.Text = "Sinkronisasi terakhir dilakukan pada " & lastDateSinkron
    End Sub

    Private Function SetResource(ByVal noTransaksi As String, ByVal jenisTransaksi As String) As String
        Dim uuidEncounter As String = GetUUID()
        Dim jsonEncounter As String = SetEncounter(uuidEncounter, noTransaksi, jenisTransaksi)
        Dim jsonCondition As String = SetCondition(uuidEncounter, noTransaksi, jenisTransaksi)
        Dim jsonBuilder As New StringBuilder()

        jsonBuilder.AppendLine("{")
        jsonBuilder.AppendLine("  ""resourceType"" : ""Bundle"",")
        jsonBuilder.AppendLine("  ""type"" : ""transaction"",")
        jsonBuilder.AppendLine("  ""entry"" : [")
        jsonBuilder.AppendLine(jsonEncounter & ",") ' Set Json Encounter
        jsonBuilder.AppendLine(jsonCondition) ' Set Json Condition
        jsonBuilder.AppendLine("  ]")
        jsonBuilder.AppendLine("}")

        Dim jsonString As String = jsonBuilder.ToString()

        Return jsonString
    End Function

    Private Function SetEncounter(ByVal uuidEncounter As String, ByVal noTransaksi As String, ByVal jenisTransaksi As String) As String
        Dim queryEncounter As New StringBuilder()

        If jenisTransaksi = "UMUM" Then
            queryEncounter.AppendLine("SELECT b.Nama AS 'NamaPasien', b.NoIHS AS 'NoIHS_Pasien', c.Nama AS 'NamaDokter', c.NoIHS AS 'NoIHS_Dokter', a.*")
            queryEncounter.AppendLine("FROM TransaksiPoli a")
            queryEncounter.AppendLine("     LEFT JOIN MasterPasien b ON a.IDInternet = b.NoRekamMedis")
            queryEncounter.AppendLine("     LEFT JOIN MasterDokter c ON a.KodeDokter = c.NoNIP")
            queryEncounter.AppendLine("WHERE a.NoUrut = '" & noTransaksi & "'")
        ElseIf jenisTransaksi = "GIGI" Then
            queryEncounter.AppendLine("SELECT b.Nama AS 'NamaPasien', b.NoIHS AS 'NoIHS_Pasien', c.Nama AS 'NamaDokter', c.NoIHS AS 'NoIHS_Dokter', a.*")
            queryEncounter.AppendLine("FROM TransaksiGigi a")
            queryEncounter.AppendLine("     LEFT JOIN MasterPasien b ON a.IDInternet = b.NoRekamMedis")
            queryEncounter.AppendLine("     LEFT JOIN MasterDokter c ON a.KodeDokter = c.NoNIP")
            queryEncounter.AppendLine("WHERE a.NoUrut = '" & noTransaksi & "'")
        End If

        ' Set Data Transaksi Kunjungan
        Dim tblsEncounter As DataTable = ReadSQL(queryEncounter.ToString())
        Dim rowEncounter As DataRow = tblsEncounter.Rows(0)

        ' Set Location
        Dim tblsLocation As DataTable = ReadSQL("SELECT b.ResourceID, b.Deskripsi FROM TransaksiDetail a " & _
                                              "LEFT JOIN SatuSehat_MappingLocation b ON a.JenisPoli = b.NamaPoli " & _
                                              "WHERE NoUrut = '" & noTransaksi & "'")
        Dim rowLocation As DataRow = tblsLocation.Rows(0)

        ' Set Data
        Dim jsonDiagnosis As String = SetDiagnosis(noTransaksi)
        Dim jsonBuilder As New StringBuilder()

        jsonBuilder.AppendLine("{")
        jsonBuilder.AppendLine("  ""fullUrl"" : ""urn:uuid:" & uuidEncounter & """,")
        jsonBuilder.AppendLine("  ""resource"": {")
        jsonBuilder.AppendLine("    ""resourceType"" : ""Encounter"",")
        jsonBuilder.AppendLine("    ""status"" : ""finished"",")
        jsonBuilder.AppendLine("    ""class"": {")
        jsonBuilder.AppendLine("       ""system"": ""http://terminology.hl7.org/CodeSystem/v3-ActCode"",")
        jsonBuilder.AppendLine("       ""code"": ""AMB"",")
        jsonBuilder.AppendLine("       ""display"": ""ambulatory""")
        jsonBuilder.AppendLine("    },")
        jsonBuilder.AppendLine("    ""subject"": {")
        jsonBuilder.AppendLine("       ""reference"": ""Patient/" & rowEncounter("NoIHS_Pasien") & """,")
        jsonBuilder.AppendLine("       ""display"": """ & rowEncounter("NamaPasien") & """")
        jsonBuilder.AppendLine("    },")
        jsonBuilder.AppendLine("    ""participant"": [")
        jsonBuilder.AppendLine("       {")
        jsonBuilder.AppendLine("          ""type"": [")
        jsonBuilder.AppendLine("             {")
        jsonBuilder.AppendLine("                ""coding"": [")
        jsonBuilder.AppendLine("                   {")
        jsonBuilder.AppendLine("                      ""system"": ""http://terminology.hl7.org/CodeSystem/v3-ParticipationType"",")
        jsonBuilder.AppendLine("                      ""code"": ""ATND"",")
        jsonBuilder.AppendLine("                      ""display"": ""attender""")
        jsonBuilder.AppendLine("                   }")
        jsonBuilder.AppendLine("                ]")
        jsonBuilder.AppendLine("             }")
        jsonBuilder.AppendLine("          ],")
        jsonBuilder.AppendLine("          ""individual"": {")
        jsonBuilder.AppendLine("             ""reference"": ""Practitioner/" & rowEncounter("NoIHS_Dokter") & """,")
        jsonBuilder.AppendLine("             ""display"": """ & rowEncounter("NamaDokter") & """")
        jsonBuilder.AppendLine("          }")
        jsonBuilder.AppendLine("       }")
        jsonBuilder.AppendLine("    ],")
        jsonBuilder.AppendLine("    ""period"": {")
        jsonBuilder.AppendLine("       ""start"": """ & ConvertDateStringSatuSehat(Format(rowEncounter("ArrivedDate"), "yyyy-MM-dd HH:mm:ss.fff")) & """,")
        jsonBuilder.AppendLine("       ""end"": """ & ConvertDateStringSatuSehat(Format(rowEncounter("FinishedDate"), "yyyy-MM-dd HH:mm:ss.fff")) & """")
        jsonBuilder.AppendLine("    },")
        jsonBuilder.AppendLine("    ""location"": [")
        jsonBuilder.AppendLine("       {")
        jsonBuilder.AppendLine("          ""location"": {")
        jsonBuilder.AppendLine("             ""reference"": ""Location/" & rowLocation("ResourceID") & """,")
        jsonBuilder.AppendLine("             ""display"": """ & rowLocation("Deskripsi") & """")
        jsonBuilder.AppendLine("          }")
        jsonBuilder.AppendLine("       }")
        jsonBuilder.AppendLine("    ],")
        jsonBuilder.AppendLine("    ""diagnosis"": [")
        jsonBuilder.AppendLine(jsonDiagnosis) ' Set Json Diagnosis
        jsonBuilder.AppendLine("    ],")
        jsonBuilder.AppendLine("    ""statusHistory"": [")
        jsonBuilder.AppendLine("       {")
        jsonBuilder.AppendLine("          ""status"": ""arrived"",")
        jsonBuilder.AppendLine("          ""period"": {")
        jsonBuilder.AppendLine("             ""start"": """ & ConvertDateStringSatuSehat(Format(rowEncounter("ArrivedDate"), "yyyy-MM-dd HH:mm:ss.fff")) & """,")
        jsonBuilder.AppendLine("             ""end"": """ & ConvertDateStringSatuSehat(Format(rowEncounter("InProgressDate"), "yyyy-MM-dd HH:mm:ss.fff")) & """")
        jsonBuilder.AppendLine("          }")
        jsonBuilder.AppendLine("       },")
        jsonBuilder.AppendLine("       {")
        jsonBuilder.AppendLine("          ""status"": ""in-progress"",")
        jsonBuilder.AppendLine("          ""period"": {")
        jsonBuilder.AppendLine("             ""start"": """ & ConvertDateStringSatuSehat(Format(rowEncounter("InProgressDate"), "yyyy-MM-dd HH:mm:ss.fff")) & """,")
        jsonBuilder.AppendLine("             ""end"": """ & ConvertDateStringSatuSehat(Format(rowEncounter("FinishedDate"), "yyyy-MM-dd HH:mm:ss.fff")) & """")
        jsonBuilder.AppendLine("          }")
        jsonBuilder.AppendLine("       },")
        jsonBuilder.AppendLine("       {")
        jsonBuilder.AppendLine("          ""status"": ""finished"",")
        jsonBuilder.AppendLine("          ""period"": {")
        jsonBuilder.AppendLine("             ""start"": """ & ConvertDateStringSatuSehat(Format(rowEncounter("FinishedDate"), "yyyy-MM-dd HH:mm:ss.fff")) & """,")
        jsonBuilder.AppendLine("             ""end"": """ & ConvertDateStringSatuSehat(Format(rowEncounter("FinishedDate"), "yyyy-MM-dd HH:mm:ss.fff")) & """")
        jsonBuilder.AppendLine("          }")
        jsonBuilder.AppendLine("       }")
        jsonBuilder.AppendLine("    ],")
        jsonBuilder.AppendLine("    ""serviceProvider"": {")
        jsonBuilder.AppendLine("       ""reference"": ""Organization/" & organizationID & """")
        jsonBuilder.AppendLine("    },")
        jsonBuilder.AppendLine("    ""identifier"": [")
        jsonBuilder.AppendLine("       {")
        jsonBuilder.AppendLine("          ""system"": ""http://sys-ids.kemkes.go.id/encounter/" & organizationID & """,")
        jsonBuilder.AppendLine("          ""value"": """ & rowEncounter("NoUrut") & """")
        jsonBuilder.AppendLine("       }")
        jsonBuilder.AppendLine("    ]")
        jsonBuilder.AppendLine(" },")
        jsonBuilder.AppendLine(" ""request"": {")
        jsonBuilder.AppendLine("    ""method"": ""POST"",")
        jsonBuilder.AppendLine("    ""url"": ""Encounter""")
        jsonBuilder.AppendLine("  }")
        jsonBuilder.AppendLine("}")

        Dim jsonEncounter As String = jsonBuilder.ToString()

        Return jsonEncounter
    End Function

    Private Function SetCondition(ByVal uuidEncounter As String, ByVal noTransaksi As String, ByVal jenisTransaksi As String) As String
        Dim queryEncounter As New StringBuilder()

        If jenisTransaksi = "UMUM" Then
            queryEncounter.AppendLine("SELECT b.Nama AS 'NamaPasien', b.NoIHS AS 'NoIHS_Pasien', a.*")
            queryEncounter.AppendLine("FROM TransaksiPoli a")
            queryEncounter.AppendLine("     LEFT JOIN MasterPasien b ON a.IDInternet = b.NoRekamMedis")
            queryEncounter.AppendLine("WHERE a.NoUrut = '" & noTransaksi & "'")
        ElseIf jenisTransaksi = "GIGI" Then
            queryEncounter.AppendLine("SELECT b.Nama AS 'NamaPasien', b.NoIHS AS 'NoIHS_Pasien', a.*")
            queryEncounter.AppendLine("FROM TransaksiGigi a")
            queryEncounter.AppendLine("     LEFT JOIN MasterPasien b ON a.IDInternet = b.NoRekamMedis")
            queryEncounter.AppendLine("WHERE a.NoUrut = '" & noTransaksi & "'")
        End If

        ' Set Data Transaksi Kunjungan
        Dim tblsEncounter As DataTable = ReadSQL(queryEncounter.ToString())
        Dim rowEncounter As DataRow = tblsEncounter.Rows(0)

        ' Set Data Diagnosa
        Dim tblsDiagnosa As DataTable = ReadSQL("SELECT * FROM TransaksiDetailDiagnosa WHERE NoTransaksi = '" & noTransaksi & "' AND DeletedDate IS NULL")
        Dim totalData As Integer = tblsDiagnosa.Rows.Count

        ' Set Index Looping Diagnosa
        Dim index As Integer = 1

        ' Set Data
        Dim jsonBuilder As New StringBuilder()

        For Each rowDiagnosa As DataRow In tblsDiagnosa.Rows
            jsonBuilder.AppendLine("{")
            jsonBuilder.AppendLine("  ""fullUrl"" : ""urn:uuid:" & rowDiagnosa("UUID") & """,")
            jsonBuilder.AppendLine("  ""resource"": {")
            jsonBuilder.AppendLine("    ""resourceType"" : ""Condition"",")
            jsonBuilder.AppendLine("    ""clinicalStatus"": {")
            jsonBuilder.AppendLine("      ""coding"": [")
            jsonBuilder.AppendLine("        {")
            jsonBuilder.AppendLine("          ""system"": ""http://terminology.hl7.org/CodeSystem/condition-clinical"",")
            jsonBuilder.AppendLine("          ""code"": ""active"",")
            jsonBuilder.AppendLine("          ""display"": ""Active""")
            jsonBuilder.AppendLine("        }")
            jsonBuilder.AppendLine("      ]")
            jsonBuilder.AppendLine("    },")
            jsonBuilder.AppendLine("    ""category"": [")
            jsonBuilder.AppendLine("      {")
            jsonBuilder.AppendLine("        ""coding"": [")
            jsonBuilder.AppendLine("          {")
            jsonBuilder.AppendLine("            ""system"": ""http://terminology.hl7.org/CodeSystem/condition-category"",")
            jsonBuilder.AppendLine("            ""code"": ""encounter-diagnosis"",")
            jsonBuilder.AppendLine("            ""display"": ""Encounter Diagnosis""")
            jsonBuilder.AppendLine("          }")
            jsonBuilder.AppendLine("        ]")
            jsonBuilder.AppendLine("      }")
            jsonBuilder.AppendLine("    ],")
            jsonBuilder.AppendLine("    ""code"": {")
            jsonBuilder.AppendLine("      ""coding"": [")
            jsonBuilder.AppendLine("        {")
            jsonBuilder.AppendLine("          ""system"": ""http://hl7.org/fhir/sid/icd-10"",")
            jsonBuilder.AppendLine("          ""code"": """ & rowDiagnosa("KodeDiagnosa") & """,")
            jsonBuilder.AppendLine("          ""display"": """ & rowDiagnosa("KeteranganDiagnosa") & """")
            jsonBuilder.AppendLine("        }")
            jsonBuilder.AppendLine("      ]")
            jsonBuilder.AppendLine("    },")
            jsonBuilder.AppendLine("    ""subject"": {")
            jsonBuilder.AppendLine("      ""reference"": ""Patient/" & rowEncounter("NoIHS_Pasien") & """,")
            jsonBuilder.AppendLine("      ""display"": """ & rowEncounter("NamaPasien") & """")
            jsonBuilder.AppendLine("    },")
            jsonBuilder.AppendLine("    ""encounter"": {")
            jsonBuilder.AppendLine("      ""reference"": ""urn:uuid:" & uuidEncounter & """,")
            jsonBuilder.AppendLine("      ""display"": ""Kunjungan " & rowEncounter("NamaPasien") & " " & Format(rowEncounter("ArrivedDate"), "dd") & " " & BulanIndonesia(Format(rowEncounter("ArrivedDate"), "MM")) & " " & Format(rowEncounter("ArrivedDate"), "yyyy") & """")
            jsonBuilder.AppendLine("    }")
            jsonBuilder.AppendLine("  },")
            jsonBuilder.AppendLine("  ""request"": {")
            jsonBuilder.AppendLine("    ""method"": ""POST"",")
            jsonBuilder.AppendLine("    ""url"": ""Condition""")
            jsonBuilder.AppendLine("  }")
            jsonBuilder.AppendLine("}")

            ' Pisahkan data dengan koma jika bukan data terakhir
            If index < totalData Then jsonBuilder.AppendLine(",")

            index += 1
        Next

        Dim jsonCondition As String = jsonBuilder.ToString()

        Return jsonCondition
    End Function

    Private Function SetDiagnosis(ByVal noTransaksi As String) As String
        Dim tblsDiagnosa As DataTable = ReadSQL("SELECT * FROM TransaksiDetailDiagnosa WHERE NoTransaksi = '" & noTransaksi & "' AND DeletedDate IS NULL")
        Dim totalData As Integer = tblsDiagnosa.Rows.Count
        Dim index As Integer = 1

        Dim jsonBuilder As New StringBuilder()

        For Each rowDiagnosa As DataRow In tblsDiagnosa.Rows
            jsonBuilder.AppendLine("{")
            jsonBuilder.AppendLine("  ""condition"": {")
            jsonBuilder.AppendLine("    ""reference"": ""urn:uuid:" & rowDiagnosa("UUID") & """,")
            jsonBuilder.AppendLine("    ""display"": """ & rowDiagnosa("KeteranganDiagnosa") & """")
            jsonBuilder.AppendLine("  },")
            jsonBuilder.AppendLine("  ""use"": {")
            jsonBuilder.AppendLine("    ""coding"": [")
            jsonBuilder.AppendLine("      {")
            jsonBuilder.AppendLine("        ""system"": ""http://terminology.hl7.org/CodeSystem/diagnosis-role"",")
            jsonBuilder.AppendLine("        ""code"": ""DD"",")
            jsonBuilder.AppendLine("        ""display"": ""Discharge diagnosis""")
            jsonBuilder.AppendLine("      }")
            jsonBuilder.AppendLine("    ]")
            jsonBuilder.AppendLine("  },")
            jsonBuilder.AppendLine("  ""rank"": " & index)
            jsonBuilder.AppendLine("}")

            ' Pisahkan data dengan koma jika bukan data terakhir
            If index < totalData Then jsonBuilder.AppendLine(",")

            index += 1
        Next

        Dim jsonString As String = jsonBuilder.ToString()

        Return jsonString
    End Function

    Private Sub ButtonSinkronisasiIHS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSinkronisasiIHS.Click
        thread = New System.Threading.Thread(AddressOf SynchronizationIHS)
        thread.Start()
    End Sub

    Private Sub SynchronizationIHS()
        Try
            ' Set Status Proses
            statusProses = "Running"

            Dim tbls As DataTable = New DataTable
            Dim queryDataUpload As New StringBuilder()

            queryDataUpload.AppendLine("SELECT b.NoRekamMedis, b.NoNIK")
            queryDataUpload.AppendLine("FROM TransaksiPoli a")
            queryDataUpload.AppendLine("LEFT JOIN MasterPasien b ON a.IDInternet=b.NoRekamMedis")
            queryDataUpload.AppendLine("WHERE a.StatusTransaksi='finished' AND a.UploadSatuSehat=0 AND a.Deleted=0")
            queryDataUpload.AppendLine("AND b.NoIHS='' AND b.PasienTanpaNIK = 0 AND b.UpdateIHS = 0")
            queryDataUpload.AppendLine("AND (a.ArrivedDate IS NOT NULL AND a.InProgressDate IS NOT NULL AND a.FinishedDate IS NOT NULL)")
            queryDataUpload.AppendLine("UNION")
            queryDataUpload.AppendLine("SELECT b.NoRekamMedis, b.NoNIK")
            queryDataUpload.AppendLine("FROM TransaksiGigi a")
            queryDataUpload.AppendLine("LEFT JOIN MasterPasien b ON a.IDInternet=b.NoRekamMedis")
            queryDataUpload.AppendLine("WHERE a.StatusTransaksi='finished' AND a.UploadSatuSehat=0 AND a.Deleted=0")
            queryDataUpload.AppendLine("AND b.NoIHS='' AND b.PasienTanpaNIK = 0 AND b.UpdateIHS = 0")
            queryDataUpload.AppendLine("AND (a.ArrivedDate IS NOT NULL AND a.InProgressDate IS NOT NULL AND a.FinishedDate IS NOT NULL)")
            queryDataUpload.AppendLine("ORDER BY b.NoRekamMedis ASC")

            If MsgBox("Proses Ulang Semua Pasien Tanpa IHS Dari Awal?", MsgBoxStyle.YesNo, "Verifikasi Akhir") = MsgBoxResult.Yes Then
                WriteSQL("UPDATE MasterPasien SET UpdateIHS = 0 WHERE UpdateIHS = 1", 4)
            End If

            ' All Data Poli Umum & Gigi
            tbls = ReadSQL(queryDataUpload.ToString())

            If tbls.Rows.Count > 0 Then
                ButtonSinkronisasi.Enabled = False
                ButtonSinkronisasiIHS.Enabled = False

                Dim noIHS As String = ""

                Dim persentaseProgres As Integer = 0

                Dim apiEndpoint As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'satu_sehat_base_url'")
                Dim payloadString As String = ""
                Dim encodedJsonData As String = ""
                Dim responseString As String = ""

                Dim transaksiSuccess As Integer = 0
                Dim transaksiProcess As Integer = 0

                For Each Trow As DataRow In tbls.Rows
                    ' Jika status proses stop
                    If statusProses = "Stop" Then Exit For

                    ' Cek Jumlah Proses
                    transaksiProcess += 1

                    ' Set No IHS
                    noIHS = GetNumberIHS(Trow("NoNIK"))

                    ' Tahan selama 3 detik agar tidak kena limit
                    System.Threading.Thread.Sleep(4000)

                    If noIHS <> "" Then
                        ' Update Master Pasien
                        WriteSQL("UPDATE MasterPasien SET NoIHS = '" & noIHS & "' WHERE NoRekamMedis = '" & Trow("NoRekamMedis") & "'", 4)

                        ' Tampilkan di TextBox Response Success
                        TextBoxResponse.Text = "No Rekam Medis " & Trow("NoRekamMedis") & " Berhasil diset IHS. (" & noIHS & ")" & vbCrLf & TextBoxResponse.Text

                        transaksiSuccess += 1
                    Else
                        ' Tampilkan di TextBox Response Error
                        TextBoxResponse.Text = "Data Gagal diset (" & Trow("NoRekamMedis") & ")" & vbCrLf & TextBoxResponse.Text
                    End If

                    ' Update Status IHS di MasterPasien
                    WriteSQL("UPDATE MasterPasien SET UpdateIHS = 1 WHERE NoRekamMedis = '" & Trow("NoRekamMedis") & "'", 4)

                    RefreshDashboard()

                    persentaseProgres = transaksiProcess * 100 / tbls.Rows.Count
                    ProgressBarSinkronisasi.Value = persentaseProgres

                    LabelProgress.Text = "In Progress " & transaksiProcess & " / " & tbls.Rows.Count & " ( " & persentaseProgres & " % ) "
                Next

                If transaksiSuccess > 0 Then
                    MsgBox(transaksiSuccess & " Data telah diset IHS Number.", MsgBoxStyle.Information, "Success!")
                Else
                    MsgBox("Tidak ada data yang dikirim.", MsgBoxStyle.Exclamation, "Warning!")
                End If

                LabelProgress.Text = "Complete"

                ButtonSinkronisasi.Enabled = True
                ButtonSinkronisasiIHS.Enabled = True
            Else
                MsgBox("Tidak ada data yang dikirim.", MsgBoxStyle.Exclamation, "Warning!")
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Function GetNumberIHS(ByVal nomorNIK As String) As String
        Dim nomorIHS As String = ""

        Dim baseURL As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'satu_sehat_base_url'")
        Dim apiEndpoint As String = baseURL & "Patient?identifier=https://fhir.kemkes.go.id/id/nik|" & nomorNIK
        Dim responseString As String = GetDataSatuSehat(apiEndpoint)
        Dim jsonObject() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of PatientResource())(responseString)

        For Each oneVar As PatientResource In jsonObject
            For index As Integer = 0 To oneVar.entry.Length - 1
                nomorIHS = oneVar.entry(index).resource.id
            Next
        Next

        If nomorIHS <> "" Then
            Return nomorIHS
        Else
            Return ""
        End If
    End Function

    Private Sub ButtonStopProses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonStopProses.Click
        statusProses = "Stop"
    End Sub
End Class