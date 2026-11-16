Imports System.Net
Imports System.IO
Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Web.Script.Serialization

Public Class FormEcgViewer

    Dim baseURL As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")

    Private _nikPasien As String = ""
    Public Property NikPasien() As String
        Get
            Return _nikPasien
        End Get
        Set(ByVal value As String)
            _nikPasien = value
        End Set
    End Property

    Private _namaPasien As String = ""
    Public Property NamaPasien() As String
        Get
            Return _namaPasien
        End Get
        Set(ByVal value As String)
            _namaPasien = value
        End Set
    End Property

    ' --- Path File PDF Sementara & BackgroundWorkers ---
    Private _tempPdfKiri As String = ""
    Private _tempPdfKanan As String = ""
    Private WithEvents bgwKiri As New BackgroundWorker()
    Private WithEvents bgwKanan As New BackgroundWorker()

    Private Sub FormEcgViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        baseURL = baseURL.Trim().TrimEnd("/"c)

        ' Isi identitas pasien yang dikirim dari form transaksi
        If Not String.IsNullOrEmpty(_nikPasien) Then
            txtNik.Text = _nikPasien
        End If
        If Not String.IsNullOrEmpty(_namaPasien) Then
            lblPatientInfo.Text = "PASIEN: " & _namaPasien.ToUpper()
        End If

        ' Atur tata letak responsif awal
        SplitContainer1_Panel1_Resize(Nothing, EventArgs.Empty)
        SplitContainer1_Panel2_Resize(Nothing, EventArgs.Empty)

        ' Muat daftar tanggal pemeriksaan ECG pasien otomatis
        If Not String.IsNullOrEmpty(txtNik.Text.Trim()) Then
            LoadDaftarTanggalEcg()
        End If
    End Sub

    ' =========================================================================
    ' 2. TATA LETAK RESPONSIF (HEADER & SPLIT 50:50 PANEL)
    ' =========================================================================
    Private Sub SplitContainer1_Panel1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles SplitContainer1.Panel1.Resize
        Dim lebarHeader As Integer = SplitContainer1.Panel1.ClientSize.Width
        If lebarHeader <= 0 Then Return

        Dim marginKanan As Integer = 16
        Dim jarakAntarKontrol As Integer = 8

        btnCariNik.Left = lebarHeader - marginKanan - btnCariNik.Width
        txtNik.Left = btnCariNik.Left - jarakAntarKontrol - txtNik.Width
        ' Aktifkan baris di bawah ini jika ada Label "NIK Pasien:" bernama lblNikCaption:
        lblNikCaption.Left = txtNik.Left - 6 - lblNikCaption.Width
    End Sub

    Private Sub SplitContainer1_Panel2_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles SplitContainer1.Panel2.Resize
        Dim jarakTepi As Integer = 8
        Dim jarakTengah As Integer = 8

        Dim totalLebar As Integer = SplitContainer1.Panel2.ClientSize.Width
        Dim totalTinggi As Integer = SplitContainer1.Panel2.ClientSize.Height

        If totalLebar <= 0 OrElse totalTinggi <= 0 Then Return

        ' 1. Bagi GroupBox Kiri & Kanan tepat 50:50
        Dim lebarPerBox As Integer = (totalLebar - (jarakTepi * 2) - jarakTengah) \ 2
        Dim tinggiBox As Integer = totalTinggi - (jarakTepi * 2)

        grpKiri.Location = New Point(jarakTepi, jarakTepi)
        grpKiri.Size = New Size(lebarPerBox, tinggiBox)

        grpKanan.Location = New Point(jarakTepi + lebarPerBox + jarakTengah, jarakTepi)
        grpKanan.Size = New Size(lebarPerBox, tinggiBox)

        ' 2. Pembagian Tinggi WebBrowser PDF (Atas) & txtHasil (Bawah)
        Dim padDalam As Integer = 10
        Dim topWeb As Integer = 58
        Dim tinggiPanelHasil As Integer = 135 ' Tinggi area keterangan/hasil ECG di bawah PDF
        Dim jarakWebKeTeks As Integer = 8

        Dim lebarKonten As Integer = grpKiri.ClientSize.Width - (padDalam * 2)
        Dim tinggiWeb As Integer = grpKiri.ClientSize.Height - topWeb - tinggiPanelHasil - jarakWebKeTeks - padDalam
        If tinggiWeb < 150 Then tinggiWeb = 150

        If lebarKonten > 0 Then
            ' Panel Kiri
            webKiri.Location = New Point(padDalam, topWeb)
            webKiri.Size = New Size(lebarKonten, tinggiWeb)

            txtHasilKiri.Location = New Point(padDalam, webKiri.Bottom + jarakWebKeTeks)
            txtHasilKiri.Size = New Size(lebarKonten, tinggiPanelHasil)

            ' Panel Kanan
            webKanan.Location = New Point(padDalam, topWeb)
            webKanan.Size = New Size(lebarKonten, tinggiWeb)

            txtHasilKanan.Location = New Point(padDalam, webKanan.Bottom + jarakWebKeTeks)
            txtHasilKanan.Size = New Size(lebarKonten, tinggiPanelHasil)
        End If
    End Sub

    ' =========================================================================
    ' 3. CUSTOM DRAW COMBOBOX DARK-MODE
    ' =========================================================================
    Private Sub cmbTanggal_DrawItem(ByVal sender As Object, ByVal e As DrawItemEventArgs) Handles cmbTglKiri.DrawItem, cmbTglKanan.DrawItem
        Dim cmb As ComboBox = CType(sender, ComboBox)
        Dim bgColor As Color

        If (e.State And DrawItemState.Selected) = DrawItemState.Selected AndAlso (e.State And DrawItemState.ComboBoxEdit) <> DrawItemState.ComboBoxEdit Then
            bgColor = Color.FromArgb(2, 132, 199)
        Else
            bgColor = Color.FromArgb(15, 23, 42)
        End If

        Using bgBrush As New SolidBrush(bgColor)
            e.Graphics.FillRectangle(bgBrush, e.Bounds)
        End Using

        If e.Index >= 0 AndAlso e.Index < cmb.Items.Count Then
            Dim textItem As String = cmb.Items(e.Index).ToString()
            Dim textRect As New Rectangle(e.Bounds.X + 6, e.Bounds.Y, e.Bounds.Width - 6, e.Bounds.Height)
            TextRenderer.DrawText(e.Graphics, textItem, New Font("Segoe UI", 9.5F, FontStyle.Bold), textRect, Color.FromArgb(241, 245, 249), TextFormatFlags.VerticalCenter Or TextFormatFlags.Left)
        End If

        If (e.State And DrawItemState.ComboBoxEdit) = DrawItemState.ComboBoxEdit Then
            Using borderPen As New Pen(Color.FromArgb(51, 65, 85), 1)
                e.Graphics.DrawRectangle(borderPen, 0, 0, cmb.Width - 1, cmb.Height - 1)
            End Using
        End If
    End Sub

    ' =========================================================================
    ' 4. AMBIL DAFTAR TANGGAL RIWAYAT ECG OTOMATIS
    ' =========================================================================
    Private Sub LoadDaftarTanggalEcg()
        Dim nik As String = txtNik.Text.Trim()
        If String.IsNullOrEmpty(nik) Then Return

        cmbTglKiri.Items.Clear()
        cmbTglKanan.Items.Clear()

        Dim url As String = String.Format("{0}/api/lab/ecg/tanggal?nik={1}", baseURL, nik)
        Dim jsonRaw As String = GetDataAPIRM(url)

        Try
            Dim serializer As New JavaScriptSerializer()
            Dim res As TanggalEcgResponse = serializer.Deserialize(Of TanggalEcgResponse)(jsonRaw)

            If res IsNot Nothing AndAlso res.status AndAlso res.data IsNot Nothing AndAlso res.data.Count > 0 Then
                For Each item As TanggalEcgItem In res.data
                    cmbTglKiri.Items.Add(item.tanggal)
                    cmbTglKanan.Items.Add(item.tanggal)
                Next

                ' Pilih tanggal terbaru di panel kanan (index 0)
                cmbTglKanan.SelectedIndex = 0
                ' Pilih tanggal pembanding sebelumnya di panel kiri (index 1 jika ada >= 2 riwayat)
                cmbTglKiri.SelectedIndex = If(cmbTglKiri.Items.Count > 1, 1, 0)

                ' Langsung muat PDF otomatis
                btnLoadKanan.PerformClick()
                If cmbTglKiri.Items.Count > 1 Then btnLoadKiri.PerformClick()
            Else
                lblStatusKiri.Text = "Tidak ada riwayat ECG"
                lblStatusKanan.Text = "Tidak ada riwayat ECG"
            End If
        Catch
            lblStatusKiri.Text = "Gagal memuat tanggal"
            lblStatusKanan.Text = "Gagal memuat tanggal"
        End Try
    End Sub

    Private Sub btnCariNik_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCariNik.Click
        LoadDaftarTanggalEcg()
    End Sub

    Private Sub txtNik_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtNik.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            LoadDaftarTanggalEcg()
        End If
    End Sub

    ' =========================================================================
    ' 5. UNDUH BINARY PDF DARI ENDPOINT LARAVEL KE FOLDER TEMP
    ' =========================================================================
    Public Function DownloadPdfAPIRM(ByVal uri As String, ByVal prefixName As String, ByRef errorMessage As String) As String
        errorMessage = String.Empty
        Try
            Dim webreq As HttpWebRequest = CType(WebRequest.Create(uri), HttpWebRequest)
            webreq.Accept = "application/pdf"
            webreq.Method = "GET"
            webreq.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64)"
            webreq.Headers.Add("X-API-KEY", "M1tR4M3D1c@rECaH4Y42025")
            webreq.Timeout = 300000
            webreq.ReadWriteTimeout = 300000

            Using res As WebResponse = webreq.GetResponse()
                If Not res.ContentType.ToLower().Contains("pdf") Then
                    errorMessage = "Berkas ECG tidak ditemukan"
                    Return ""
                End If

                Dim tempFile As String = Path.Combine(Path.GetTempPath(), String.Format("ECG_{0}_{1}.pdf", prefixName, Guid.NewGuid().ToString("N")))
                Using stream As Stream = res.GetResponseStream()
                    Using fs As New FileStream(tempFile, FileMode.Create, FileAccess.Write)
                        Dim buffer(4096) As Byte
                        Dim bytesRead As Integer = stream.Read(buffer, 0, buffer.Length)
                        While bytesRead > 0
                            fs.Write(buffer, 0, bytesRead)
                            bytesRead = stream.Read(buffer, 0, buffer.Length)
                        End While
                    End Using
                End Using
                Return tempFile
            End Using

        Catch ex As WebException
            errorMessage = "Data ECG tidak ditemukan"
            Return ""
        Catch ex As Exception
            errorMessage = "Gagal memuat PDF: " & ex.Message
            Return ""
        End Try
    End Function

    ' =========================================================================
    ' 6. BACKGROUND WORKER PANEL KIRI & PANEL KANAN
    ' =========================================================================
    Private Sub btnLoadKiri_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadKiri.Click
        If bgwKiri.IsBusy OrElse cmbTglKiri.SelectedItem Is Nothing Then Return
        btnLoadKiri.Enabled = False
        btnLoadKiri.Text = "Memuat..."
        lblStatusKiri.Text = "Mengunduh PDF ECG..."
        lblStatusKiri.ForeColor = Color.DeepSkyBlue

        Dim url As String = String.Format("{0}/api/lab/ecg?nik={1}&tanggal={2}", baseURL, txtNik.Text.Trim(), cmbTglKiri.SelectedItem.ToString())
        bgwKiri.RunWorkerAsync(url)
    End Sub

    Private Sub bgwKiri_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles bgwKiri.DoWork
        Dim err As String = ""
        Dim pathPdf As String = DownloadPdfAPIRM(e.Argument.ToString(), "KIRI", err)
        e.Result = New Object() {pathPdf, err}
    End Sub

    Private Sub bgwKiri_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles bgwKiri.RunWorkerCompleted
        btnLoadKiri.Enabled = True
        btnLoadKiri.Text = "Muat ECG"

        Dim res() As Object = CType(e.Result, Object())
        Dim pathPdf As String = res(0).ToString()
        Dim err As String = res(1).ToString()

        HapusFileTemp(_tempPdfKiri)
        _tempPdfKiri = pathPdf

        If Not String.IsNullOrEmpty(pathPdf) AndAlso File.Exists(pathPdf) Then
            webKiri.Navigate(New Uri(pathPdf).AbsoluteUri)
            btnEksternalKiri.Enabled = True
            lblStatusKiri.Text = "PDF Tampil"
            lblStatusKiri.ForeColor = Color.MediumSpringGreen
        Else
            webKiri.Navigate("about:blank")
            btnEksternalKiri.Enabled = False
            lblStatusKiri.Text = err
            lblStatusKiri.ForeColor = Color.Salmon
        End If
    End Sub

    Private Sub btnLoadKanan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadKanan.Click
        If bgwKanan.IsBusy OrElse cmbTglKanan.SelectedItem Is Nothing Then Return
        btnLoadKanan.Enabled = False
        btnLoadKanan.Text = "Memuat..."
        lblStatusKanan.Text = "Mengunduh PDF ECG..."
        lblStatusKanan.ForeColor = Color.DeepSkyBlue

        Dim url As String = String.Format("{0}/api/lab/ecg?nik={1}&tanggal={2}", baseURL, txtNik.Text.Trim(), cmbTglKanan.SelectedItem.ToString())
        bgwKanan.RunWorkerAsync(url)
    End Sub

    Private Sub bgwKanan_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles bgwKanan.DoWork
        Dim err As String = ""
        Dim pathPdf As String = DownloadPdfAPIRM(e.Argument.ToString(), "KANAN", err)
        e.Result = New Object() {pathPdf, err}
    End Sub

    Private Sub bgwKanan_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles bgwKanan.RunWorkerCompleted
        btnLoadKanan.Enabled = True
        btnLoadKanan.Text = "Muat ECG"

        Dim res() As Object = CType(e.Result, Object())
        Dim pathPdf As String = res(0).ToString()
        Dim err As String = res(1).ToString()

        HapusFileTemp(_tempPdfKanan)
        _tempPdfKanan = pathPdf

        If Not String.IsNullOrEmpty(pathPdf) AndAlso File.Exists(pathPdf) Then
            webKanan.Navigate(New Uri(pathPdf).AbsoluteUri)
            btnEksternalKanan.Enabled = True
            lblStatusKanan.Text = "PDF Tampil"
            lblStatusKanan.ForeColor = Color.MediumSpringGreen
        Else
            webKanan.Navigate("about:blank")
            btnEksternalKanan.Enabled = False
            lblStatusKanan.Text = err
            lblStatusKanan.ForeColor = Color.Salmon
        End If
    End Sub

    ' =========================================================================
    ' 7. BUKA PDF EKSTERNAL & CLEANUP FILE TEMP SAAT FORM DITUTUP
    ' =========================================================================
    Private Sub btnEksternalKiri_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEksternalKiri.Click
        If Not String.IsNullOrEmpty(_tempPdfKiri) AndAlso File.Exists(_tempPdfKiri) Then
            Process.Start(_tempPdfKiri)
        End If
    End Sub

    Private Sub btnEksternalKanan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEksternalKanan.Click
        If Not String.IsNullOrEmpty(_tempPdfKanan) AndAlso File.Exists(_tempPdfKanan) Then
            Process.Start(_tempPdfKanan)
        End If
    End Sub

    Private Sub HapusFileTemp(ByVal filePath As String)
        Try
            If Not String.IsNullOrEmpty(filePath) AndAlso File.Exists(filePath) Then
                File.Delete(filePath)
            End If
        Catch
        End Try
    End Sub

    Private Sub FormEcgViewer_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles Me.FormClosed
        webKiri.Dispose()
        webKanan.Dispose()
        HapusFileTemp(_tempPdfKiri)
        HapusFileTemp(_tempPdfKanan)
    End Sub
End Class

' =============================================================================
' CLASS MODEL JSON TANGGAL ECG
' =============================================================================
Public Class TanggalEcgResponse
    Public status As Boolean
    Public message As String
    Public data As List(Of TanggalEcgItem)
End Class

Public Class TanggalEcgItem
    Public tanggal As String
    Public idlabinternet As String
    Public namatindakan As String
End Class