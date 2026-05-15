Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Drawing
Imports Newtonsoft.Json.Linq
Imports System.Threading

Public Class FormWABlast

    Dim thread As System.Threading.Thread
    Dim conn As OleDbConnection
    Dim dtr As OleDbDataReader
    Dim dta As OleDbDataAdapter
    Dim cmd As OleDbCommand
    Dim dts As DataSet
    Dim excel As String
    Dim opFileDialog As New OpenFileDialog()

    Private isStopRequested As Boolean = False

    Private Sub FormWABlast_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtPesan.Text = "Halo {nama}," & vbCrLf & vbCrLf & _
                   "Kami ingin menginformasikan sesuatu kepada Anda." & vbCrLf & _
                   "Terima kasih."

        ButtonRetry.Enabled = False

        LoadDataGrid()
    End Sub

    Private Sub LoadDataGrid()
        Try
            Dim sql As String = "SELECT ID, Nama, Nomor, Status FROM WaBlast " & _
                                "WHERE CreatedAt >= CAST(GETDATE() AS DATE) " & _
                                "AND Status IN ('Pending','Gagal') ORDER BY Nama DESC"

            Dim dt As DataTable = ReadSQL(sql)

            dgvData.DataSource = dt

            If dgvData.Columns.Contains("ID") Then
                dgvData.Columns("ID").Visible = False
            End If

        Catch ex As Exception
            MsgBox("Gagal load data: " & ex.Message)
        End Try
    End Sub

    Private Function EscapeSql(ByVal s As String) As String
        If s Is Nothing Then Return ""
        Return s.Replace("'", "''")
    End Function

    Private Sub InsertWaBlast(ByVal nama As String, ByVal nomor As String)
        Dim namaFix As String = EscapeSql(nama)
        Dim nomorFix As String = EscapeSql(nomor)

        Dim sql As String = "INSERT INTO WaBlast (Nama, Nomor, Status, CreatedAt, UpdatedAt) " & _
                            "VALUES ('" & namaFix & "','" & nomorFix & "','Pending', GETDATE(), GETDATE())"

        WriteSQL(sql, 4)
    End Sub

    Private Sub UpdateStatus(ByVal id As Integer, ByVal status As String)
        Dim statusFix As String = EscapeSql(status)

        Dim sql As String = "UPDATE WaBlast SET Status='" & statusFix & "', UpdatedAt=GETDATE() WHERE ID=" & id
        WriteSQL(sql, 4)
    End Sub

    Private Function LoadDataToday() As DataTable
        Dim sql As String = "SELECT ID, Nama, Nomor, Status FROM WaBlast " & _
                            "WHERE CAST(CreatedAt AS DATE) = CAST(GETDATE() AS DATE) " & _
                            "AND Status='Pending' ORDER BY Nama ASC"

        Return ReadSQL(sql)
    End Function

    Function GeneratePesan(ByVal template As String, ByVal nama As String, ByVal nomor As String) As String
        Dim hasil As String = template
        hasil = hasil.Replace("{nama}", nama)
        hasil = hasil.Replace("{nomor}", nomor)
        Return hasil
    End Function

    Private Sub ButtonLoadTemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLoadTemplate.Click
        Try
            Dim ofd As New OpenFileDialog
            ofd.Filter = "Text File|*.txt"

            If ofd.ShowDialog = DialogResult.OK Then
                txtPesan.Text = System.IO.File.ReadAllText(ofd.FileName)
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub ButtonClearTemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonClearTemplate.Click
        If MessageBox.Show("Yakin ingin menghapus template?", "Konfirmasi", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            txtPesan.Clear()
            txtPesan.Focus()
        End If
    End Sub

    Private Sub ButtonLoadExcel_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLoadExcel.Click
        Try
            opFileDialog.Filter = "Excel Files 2003|*.xls|Excel Files|*.xlsx"
            opFileDialog.Title = "Select a Excel File"

            If opFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Dim fi As New FileInfo(opFileDialog.FileName)
                Dim FileName As String = opFileDialog.FileName

                excel = fi.FullName
                conn = New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excel + ";Extended Properties=Excel 12.0;")
                dta = New OleDbDataAdapter("SELECT * FROM [Sheet1$]", conn)
                dts = New DataSet("NewTables")
                dta.Fill(dts)

                Dim dt As DataTable = dts.Tables(0)

                For Each row As DataRow In dt.Rows

                    If Not IsDBNull(row("Nomor")) AndAlso Not IsDBNull(row("Nama")) Then

                        Dim nomor As String = row("Nomor").ToString().Trim()
                        Dim nama As String = row("Nama").ToString().Trim()

                        ' Bersihkan nomor
                        nomor = nomor.Replace(" ", "").Replace("-", "")

                        If nomor.StartsWith("0") Then
                            nomor = "62" & nomor.Substring(1)
                        End If

                        InsertWaBlast(nama, nomor)

                    End If

                Next

                dgvData.DataSource = LoadDataToday()

                If dgvData.Columns.Contains("ID") Then
                    dgvData.Columns("ID").Visible = False
                End If

                dgvData.EnableHeadersVisualStyles = False
                dgvData.ColumnHeadersDefaultCellStyle.BackColor = Color.LightBlue
                dgvData.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 9, FontStyle.Bold)
                dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                dgvData.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
                dgvData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgvData.DefaultCellStyle.WrapMode = DataGridViewTriState.True

                conn.Close()
            End If
        Catch ex As Exception
            conn.Close()
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub ButtonDownloadTemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDownloadTemplate.Click
        Try
            Dim saveFileDialog1 As New SaveFileDialog
            saveFileDialog1.Filter = "Excel File|*.xlsx"
            saveFileDialog1.Title = "Save an Excel File"
            saveFileDialog1.ShowDialog()
            If saveFileDialog1.CheckPathExists = False Then
                MsgBox("Path tidak ada. Check kembali")
            Else
                If saveFileDialog1.CheckFileExists = True Then
                    MsgBox("Telah ada data dengan nama tersebut. Rubah nama save")
                Else
                    Dim varData As String = saveFileDialog1.FileName.ToString
                    varData = Strings.Replace(varData, "\", "/")
                    Dim appPath As String = Application.StartupPath()

                    My.Computer.Network.DownloadFile("" & appPath & "/FileDownload/Contoh_Format_Data_Wa_Blast.xlsx", "" & varData & "")
                    MsgBox("File Saved in " + "" & varData & "")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ButtonKirim_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonKirim.Click
        Try
            ButtonKirim.Enabled = False
            ButtonRetry.Enabled = False
            ButtonStop.Enabled = True

            If dgvData.Rows.Count = 0 Then
                MsgBox("Data kosong.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            Dim baseIP As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'whatsapp_klinik_ip'")
            Dim baseURL As String = "http://" & baseIP & ":4444/"

            ProgressBar1.Minimum = 0
            Dim total As Integer = 0

            For Each row As DataGridViewRow In dgvData.Rows
                If Not row.IsNewRow Then
                    If Not IsDBNull(row.Cells("Status").Value) Then
                        If row.Cells("Status").Value.ToString() = "Pending" Then
                            total += 1
                        End If
                    End If
                End If
            Next

            ProgressBar1.Maximum = total
            ProgressBar1.Value = 0

            Dim rnd As New Random()

            For i As Integer = 0 To dgvData.Rows.Count - 1

                If isStopRequested Then
                    LabelStatus.Text = "Dihentikan oleh user"
                    Exit For
                End If

                If dgvData.Rows(i).IsNewRow Then Continue For

                Dim status As String = ""
                If Not IsDBNull(dgvData.Rows(i).Cells("Status").Value) Then
                    status = dgvData.Rows(i).Cells("Status").Value.ToString()
                End If

                If status <> "Pending" Then Continue For

                Dim id As Integer = CInt(dgvData.Rows(i).Cells("ID").Value)
                Dim nomor As String = dgvData.Rows(i).Cells("Nomor").Value.ToString()
                Dim nama As String = dgvData.Rows(i).Cells("Nama").Value.ToString()

                If nomor = "" Then Continue For

                If i > 0 Then dgvData.Rows(i - 1).DefaultCellStyle.BackColor = Color.White
                dgvData.Rows(i).DefaultCellStyle.BackColor = Color.LightYellow

                If i < dgvData.Rows.Count Then
                    dgvData.FirstDisplayedScrollingRowIndex = i
                End If

                Dim pesan As String = GeneratePesan(txtPesan.Text, nama, nomor)

                Try
                    Dim apiUrl As String = baseURL & "send-msg/" & nomor & "/" & Uri.EscapeDataString(pesan)
                    Dim client As New Net.WebClient()
                    client.DownloadString(apiUrl)

                    dgvData.Rows(i).Cells("Status").Value = "Terkirim"
                    UpdateStatus(id, "Terkirim")

                Catch ex As Exception
                    dgvData.Rows(i).Cells("Status").Value = "Gagal"
                    UpdateStatus(id, "Gagal")
                End Try

                If ProgressBar1.Value < ProgressBar1.Maximum Then
                    ProgressBar1.Value += 1
                End If

                LabelStatus.Text = "Mengirim ke: " & nama & " " & ProgressBar1.Value & " / " & ProgressBar1.Maximum
                Application.DoEvents()

                Dim delay As Integer = rnd.Next(15000, 60000)
                Threading.Thread.Sleep(delay)

                If ProgressBar1.Value Mod 15 = 0 Then
                    Dim cooldown As Integer = rnd.Next(180000, 300000)
                    Threading.Thread.Sleep(cooldown)
                End If
            Next

            ProgressBar1.Value = ProgressBar1.Maximum
            LabelStatus.Text = "Selesai"
            MsgBox("Blast selesai.", MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox("Error: " & ex.Message)
        Finally
            ButtonKirim.Enabled = True
            ButtonRetry.Enabled = True
        End Try
    End Sub

    Private Sub ButtonStop_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonStop.Click
        isStopRequested = True
        LabelStatus.Text = "Menghentikan proses..."
    End Sub

    Private Sub ButtonRetry_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRetry.Click
        Try
            isStopRequested = False

            Dim baseIP As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'whatsapp_klinik_ip'")
            Dim baseURL As String = "http://" & baseIP & ":4444/"

            ' 🔥 Hitung hanya yang gagal
            Dim total As Integer = 0
            For Each row As DataGridViewRow In dgvData.Rows
                If Not row.IsNewRow Then
                    If Not IsDBNull(row.Cells("Status").Value) Then
                        If row.Cells("Status").Value.ToString() = "Gagal" Then
                            total += 1
                        End If
                    End If
                End If
            Next

            ProgressBar1.Maximum = total
            ProgressBar1.Value = 0

            For i As Integer = 0 To dgvData.Rows.Count - 1

                If isStopRequested Then
                    LabelStatus.Text = "Retry dihentikan"
                    Exit For
                End If

                If dgvData.Rows(i).IsNewRow Then Continue For

                Dim status As String = ""
                If Not IsDBNull(dgvData.Rows(i).Cells("Status").Value) Then
                    status = dgvData.Rows(i).Cells("Status").Value.ToString()
                End If

                ' 🔥 hanya retry yang gagal
                If status <> "Gagal" Then Continue For
                If status <> "Pending" Then Continue For

                Dim id As Integer = CInt(dgvData.Rows(i).Cells("ID").Value)
                Dim nomor As String = dgvData.Rows(i).Cells("Nomor").Value.ToString()
                Dim nama As String = dgvData.Rows(i).Cells("Nama").Value.ToString()

                If nomor = "" Then Continue For

                Dim pesan As String = GeneratePesan(txtPesan.Text, nama, nomor)

                Try
                    Dim apiUrl As String = baseURL & "send-msg/" & nomor & "/" & Uri.EscapeDataString(pesan)
                    Dim client As New Net.WebClient()
                    client.DownloadString(apiUrl)

                    dgvData.Rows(i).Cells("Status").Value = "Terkirim"
                    UpdateStatus(id, "Terkirim")

                Catch ex As Exception
                    dgvData.Rows(i).Cells("Status").Value = "Gagal"
                    UpdateStatus(id, "Gagal")
                End Try

                If ProgressBar1.Value < ProgressBar1.Maximum Then
                    ProgressBar1.Value += 1
                End If

                LabelStatus.Text = "Retry ke: " & nama & " " & ProgressBar1.Value & "/" & ProgressBar1.Maximum
                Application.DoEvents()

                ' delay
                Threading.Thread.Sleep(5000)
            Next

            ProgressBar1.Value = ProgressBar1.Maximum
            LabelStatus.Text = "Retry selesai"
            MsgBox("Retry selesai.", MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox("Error Retry: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadBirthdayToGrid()
        Try
            Dim query As String = "SELECT Nama, " & _
             "CASE " & _
                 "WHEN NoHandphone LIKE '08%' THEN '62' + SUBSTRING(NoHandphone, 2, LEN(NoHandphone)) " & _
                 "ELSE NoHandphone " & _
             "END AS Nomor " & _
             "FROM MasterPasien " & _
             "WHERE DeletedDate IS NULL " & _
             "AND MONTH(TglLahir) = MONTH(GETDATE()) " & _
             "AND DAY(TglLahir) = DAY(GETDATE()) " & _
             "AND NULLIF(LTRIM(RTRIM(NoHandphone)), '') IS NOT NULL"

            Dim dt As DataTable = ReadSQL(query)

            dgvData.DataSource = dt

            dgvData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvData.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CheckBoxBirthday_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBoxBirthday.CheckedChanged
        If CheckBoxBirthday.Checked Then
            LoadBirthdayToGrid()
        Else
            dgvData.DataSource = Nothing
        End If
    End Sub
End Class