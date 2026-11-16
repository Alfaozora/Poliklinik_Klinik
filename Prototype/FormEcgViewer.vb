Imports System.Net
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Web.Script.Serialization
Imports PdfiumViewer

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

    ' --- State Zoom & Pan untuk Gambar Kiri & Kanan ---
    Private _zoomKiri As Single = 1.0F
    Private _panKiri As PointF = PointF.Empty
    Private _isDraggingKiri As Boolean = False
    Private _lastMouseKiri As Point

    Private _zoomKanan As Single = 1.0F
    Private _panKanan As PointF = PointF.Empty
    Private _isDraggingKanan As Boolean = False
    Private _lastMouseKanan As Point

    ' =========================================================================
    ' 1. FORM LOAD & INISIALISASI
    ' =========================================================================
    Private Sub FormEcgViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        baseURL = baseURL.Trim().TrimEnd("/"c)

        ' Nonaktifkan SizeMode bawaan karena kita menggambar manual dengan dukungan Zoom, Pan & Rotate
        picKiri.SizeMode = PictureBoxSizeMode.Normal
        picKiri.BackColor = Color.Black
        picKiri.Cursor = Cursors.Hand
        picKiri.Visible = True
        picKiri.BringToFront()
        picKiri.ContextMenuStrip = BuatContextMenuGambar(True)

        picKanan.SizeMode = PictureBoxSizeMode.Normal
        picKanan.BackColor = Color.Black
        picKanan.Cursor = Cursors.Hand
        picKanan.Visible = True
        picKanan.BringToFront()
        picKanan.ContextMenuStrip = BuatContextMenuGambar(False)

        ' Nonaktifkan tombol Buka PDF sampai file selesai diunduh
        btnEksternalKiri.Enabled = False
        btnEksternalKanan.Enabled = False

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
        lblNikCaption.Left = txtNik.Left - 6 - lblNikCaption.Width
    End Sub

    Private Sub SplitContainer1_Panel2_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles SplitContainer1.Panel2.Resize
        Dim jarakTepi As Integer = 8
        Dim jarakTengah As Integer = 8

        Dim totalLebar As Integer = SplitContainer1.Panel2.ClientSize.Width
        Dim totalTinggi As Integer = SplitContainer1.Panel2.ClientSize.Height

        If totalLebar <= 0 OrElse totalTinggi <= 0 Then Return

        Dim lebarPerBox As Integer = (totalLebar - (jarakTepi * 2) - jarakTengah) \ 2
        Dim tinggiBox As Integer = totalTinggi - (jarakTepi * 2)

        grpKiri.Location = New Point(jarakTepi, jarakTepi)
        grpKiri.Size = New Size(lebarPerBox, tinggiBox)

        grpKanan.Location = New Point(jarakTepi + lebarPerBox + jarakTengah, jarakTepi)
        grpKanan.Size = New Size(lebarPerBox, tinggiBox)

        Dim padDalam As Integer = 10
        Dim topPic As Integer = 58
        Dim tinggiPanelHasil As Integer = 135
        Dim jarakPicKeTeks As Integer = 8

        Dim lebarKonten As Integer = grpKiri.ClientSize.Width - (padDalam * 2)
        Dim tinggiPic As Integer = grpKiri.ClientSize.Height - topPic - tinggiPanelHasil - jarakPicKeTeks - padDalam
        If tinggiPic < 150 Then tinggiPic = 150

        If lebarKonten > 0 Then
            picKiri.Location = New Point(padDalam, topPic)
            picKiri.Size = New Size(lebarKonten, tinggiPic)
            txtHasilKiri.Location = New Point(padDalam, picKiri.Bottom + jarakPicKeTeks)
            txtHasilKiri.Size = New Size(lebarKonten, tinggiPanelHasil)

            picKanan.Location = New Point(padDalam, topPic)
            picKanan.Size = New Size(lebarKonten, tinggiPic)
            txtHasilKanan.Location = New Point(padDalam, picKanan.Bottom + jarakPicKeTeks)
            txtHasilKanan.Size = New Size(lebarKonten, tinggiPanelHasil)

            picKiri.Invalidate()
            picKanan.Invalidate()
        End If
    End Sub

    ' =========================================================================
    ' 3. ENGINE ZOOM, PAN & ROTATE UNTUK PICTUREBOX KIRI & KANAN
    ' =========================================================================
    Private Function BuatContextMenuGambar(ByVal isKiri As Boolean) As ContextMenuStrip
        Dim cms As New ContextMenuStrip()
        Dim mnuRotCW As New ToolStripMenuItem("Rotate 90° Kanan (CW)")
        Dim mnuRotCCW As New ToolStripMenuItem("Rotate 90° Kiri (CCW)")
        Dim mnuRot180 As New ToolStripMenuItem("Rotate 180°")
        Dim mnuReset As New ToolStripMenuItem("Reset Zoom & Posisi")

        If isKiri Then
            AddHandler mnuRotCW.Click, AddressOf RotasiKiriCW_Click
            AddHandler mnuRotCCW.Click, AddressOf RotasiKiriCCW_Click
            AddHandler mnuRot180.Click, AddressOf RotasiKiri180_Click
            AddHandler mnuReset.Click, AddressOf ResetKiri_Click
        Else
            AddHandler mnuRotCW.Click, AddressOf RotasiKananCW_Click
            AddHandler mnuRotCCW.Click, AddressOf RotasiKananCCW_Click
            AddHandler mnuRot180.Click, AddressOf RotasiKanan180_Click
            AddHandler mnuReset.Click, AddressOf ResetKanan_Click
        End If

        cms.Items.AddRange(New ToolStripItem() {mnuRotCW, mnuRotCCW, mnuRot180, New ToolStripSeparator(), mnuReset})
        Return cms
    End Function

    Private Sub RotasiGambar(ByVal pic As PictureBox, ByVal rotType As RotateFlipType, ByRef zoomVal As Single, ByRef panVal As PointF)
        If pic.Image Is Nothing Then Return
        pic.Image.RotateFlip(rotType)
        zoomVal = 1.0F
        panVal = PointF.Empty
        pic.Invalidate()
    End Sub

    Private Sub RotasiKiriCW_Click(ByVal sender As Object, ByVal e As EventArgs)
        RotasiGambar(picKiri, RotateFlipType.Rotate90FlipNone, _zoomKiri, _panKiri)
    End Sub
    Private Sub RotasiKiriCCW_Click(ByVal sender As Object, ByVal e As EventArgs)
        RotasiGambar(picKiri, RotateFlipType.Rotate270FlipNone, _zoomKiri, _panKiri)
    End Sub
    Private Sub RotasiKiri180_Click(ByVal sender As Object, ByVal e As EventArgs)
        RotasiGambar(picKiri, RotateFlipType.Rotate180FlipNone, _zoomKiri, _panKiri)
    End Sub
    Private Sub ResetKiri_Click(ByVal sender As Object, ByVal e As EventArgs)
        _zoomKiri = 1.0F
        _panKiri = PointF.Empty
        picKiri.Invalidate()
    End Sub

    Private Sub RotasiKananCW_Click(ByVal sender As Object, ByVal e As EventArgs)
        RotasiGambar(picKanan, RotateFlipType.Rotate90FlipNone, _zoomKanan, _panKanan)
    End Sub
    Private Sub RotasiKananCCW_Click(ByVal sender As Object, ByVal e As EventArgs)
        RotasiGambar(picKanan, RotateFlipType.Rotate270FlipNone, _zoomKanan, _panKanan)
    End Sub
    Private Sub RotasiKanan180_Click(ByVal sender As Object, ByVal e As EventArgs)
        RotasiGambar(picKanan, RotateFlipType.Rotate180FlipNone, _zoomKanan, _panKanan)
    End Sub
    Private Sub ResetKanan_Click(ByVal sender As Object, ByVal e As EventArgs)
        _zoomKanan = 1.0F
        _panKanan = PointF.Empty
        picKanan.Invalidate()
    End Sub

    Private Sub RenderZoomPanImage(ByVal g As Graphics, ByVal pic As PictureBox, ByVal zoom As Single, ByVal pan As PointF)
        g.Clear(Color.Black)
        If pic.Image Is Nothing OrElse pic.ClientSize.Width <= 0 OrElse pic.ClientSize.Height <= 0 Then Return

        g.InterpolationMode = InterpolationMode.HighQualityBicubic
        g.PixelOffsetMode = PixelOffsetMode.HighQuality

        Dim ratioX As Single = CSng(pic.ClientSize.Width) / CSng(pic.Image.Width)
        Dim ratioY As Single = CSng(pic.ClientSize.Height) / CSng(pic.Image.Height)
        Dim baseScale As Single = Math.Min(ratioX, ratioY)
        Dim finalScale As Single = baseScale * zoom

        Dim drawW As Single = pic.Image.Width * finalScale
        Dim drawH As Single = pic.Image.Height * finalScale
        Dim offsetX As Single = ((pic.ClientSize.Width - drawW) / 2.0F) + pan.X
        Dim offsetY As Single = ((pic.ClientSize.Height - drawH) / 2.0F) + pan.Y

        g.DrawImage(pic.Image, offsetX, offsetY, drawW, drawH)

        ' Petunjuk singkat & level zoom di pojok kiri atas gambar
        Dim infoZoom As String = String.Format("Zoom: {0}% | Scroll: Zoom • Drag: Geser • Klik Kanan: Rotate • 2x Klik: Reset", Math.Round(zoom * 100))
        Using bgTip As New SolidBrush(Color.FromArgb(165, 15, 23, 42))
            g.FillRectangle(bgTip, 6, 6, 445, 22)
        End Using
        TextRenderer.DrawText(g, infoZoom, New Font("Segoe UI", 8.0F, FontStyle.Regular), New Point(10, 9), Color.FromArgb(226, 232, 240))
    End Sub

    Private Sub HitungZoomMouse(ByVal pic As PictureBox, ByVal e As MouseEventArgs, ByRef zoom As Single, ByRef pan As PointF)
        If pic.Image Is Nothing Then Return
        Dim oldZoom As Single = zoom
        If e.Delta > 0 Then
            zoom = Math.Min(8.0F, zoom * 1.2F)
        Else
            zoom = Math.Max(0.5F, zoom / 1.2F)
        End If

        Dim scaleFactor As Single = zoom / oldZoom
        Dim cx As Single = pic.ClientSize.Width / 2.0F
        Dim cy As Single = pic.ClientSize.Height / 2.0F

        pan.X = (e.X - cx) - ((e.X - cx - pan.X) * scaleFactor)
        pan.Y = (e.Y - cy) - ((e.Y - cy - pan.Y) * scaleFactor)
        pic.Invalidate()
    End Sub

    ' --- Event Mouse & Paint picKiri ---
    Private Sub picKiri_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles picKiri.Paint
        RenderZoomPanImage(e.Graphics, picKiri, _zoomKiri, _panKiri)
    End Sub

    Private Sub picKiri_MouseEnter(ByVal sender As Object, ByVal e As EventArgs) Handles picKiri.MouseEnter
        picKiri.Focus()
    End Sub

    Private Sub picKiri_MouseWheel(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picKiri.MouseWheel
        HitungZoomMouse(picKiri, e, _zoomKiri, _panKiri)
    End Sub

    Private Sub picKiri_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picKiri.MouseDown
        If e.Button = MouseButtons.Left AndAlso picKiri.Image IsNot Nothing Then
            _isDraggingKiri = True
            _lastMouseKiri = e.Location
            picKiri.Cursor = Cursors.SizeAll
        End If
    End Sub

    Private Sub picKiri_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picKiri.MouseMove
        If _isDraggingKiri Then
            _panKiri.X += (e.X - _lastMouseKiri.X)
            _panKiri.Y += (e.Y - _lastMouseKiri.Y)
            _lastMouseKiri = e.Location
            picKiri.Invalidate()
        End If
    End Sub

    Private Sub picKiri_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picKiri.MouseUp
        If e.Button = MouseButtons.Left Then
            _isDraggingKiri = False
            picKiri.Cursor = Cursors.Hand
        End If
    End Sub

    Private Sub picKiri_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles picKiri.DoubleClick
        ResetKiri_Click(sender, e)
    End Sub

    ' --- Event Mouse & Paint picKanan ---
    Private Sub picKanan_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles picKanan.Paint
        RenderZoomPanImage(e.Graphics, picKanan, _zoomKanan, _panKanan)
    End Sub

    Private Sub picKanan_MouseEnter(ByVal sender As Object, ByVal e As EventArgs) Handles picKanan.MouseEnter
        picKanan.Focus()
    End Sub

    Private Sub picKanan_MouseWheel(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picKanan.MouseWheel
        HitungZoomMouse(picKanan, e, _zoomKanan, _panKanan)
    End Sub

    Private Sub picKanan_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picKanan.MouseDown
        If e.Button = MouseButtons.Left AndAlso picKanan.Image IsNot Nothing Then
            _isDraggingKanan = True
            _lastMouseKanan = e.Location
            picKanan.Cursor = Cursors.SizeAll
        End If
    End Sub

    Private Sub picKanan_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picKanan.MouseMove
        If _isDraggingKanan Then
            _panKanan.X += (e.X - _lastMouseKanan.X)
            _panKanan.Y += (e.Y - _lastMouseKanan.Y)
            _lastMouseKanan = e.Location
            picKanan.Invalidate()
        End If
    End Sub

    Private Sub picKanan_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picKanan.MouseUp
        If e.Button = MouseButtons.Left Then
            _isDraggingKanan = False
            picKanan.Cursor = Cursors.Hand
        End If
    End Sub

    Private Sub picKanan_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles picKanan.DoubleClick
        ResetKanan_Click(sender, e)
    End Sub

    ' =========================================================================
    ' 4. KONVERSI PDF KE GAMBAR VIA PDFIUMVIEWER
    ' =========================================================================
    Private Function RenderPdfToImage(ByVal pdfPath As String) As Image
        If String.IsNullOrEmpty(pdfPath) OrElse Not File.Exists(pdfPath) Then Return Nothing

        Try
            Using doc As PdfDocument = PdfDocument.Load(pdfPath)
                Return doc.Render(0, 200, 200, True)
            End Using
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    ' =========================================================================
    ' 5. CUSTOM DRAW COMBOBOX DARK-MODE
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
    ' 6. AMBIL DAFTAR TANGGAL RIWAYAT ECG OTOMATIS
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

                cmbTglKanan.SelectedIndex = 0
                cmbTglKiri.SelectedIndex = If(cmbTglKiri.Items.Count > 1, 1, 0)

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
    ' 7. UNDUH BINARY PDF DARI ENDPOINT LARAVEL KE FOLDER TEMP
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
    ' 8. BACKGROUND WORKER PANEL KIRI & PANEL KANAN
    ' =========================================================================
    Private Sub btnLoadKiri_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadKiri.Click
        If bgwKiri.IsBusy OrElse cmbTglKiri.SelectedItem Is Nothing Then Return
        btnLoadKiri.Enabled = False
        btnLoadKiri.Text = "Memuat..."
        lblStatusKiri.Text = "Mengunduh & merender ECG..."
        lblStatusKiri.ForeColor = Color.DeepSkyBlue

        Dim nik As String = txtNik.Text.Trim()
        Dim tgl As String = cmbTglKiri.SelectedItem.ToString()
        Dim url As String = String.Format("{0}/api/lab/ecg?nik={1}&tanggal={2}", baseURL, nik, tgl)
        bgwKiri.RunWorkerAsync(New String() {url, tgl, nik})
    End Sub

    Private Sub bgwKiri_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles bgwKiri.DoWork
        Dim param() As String = CType(e.Argument, String())
        Dim err As String = ""
        Dim pathPdf As String = DownloadPdfAPIRM(param(0), "KIRI", err)
        Dim imgEcg As Image = Nothing

        If Not String.IsNullOrEmpty(pathPdf) AndAlso File.Exists(pathPdf) Then
            imgEcg = RenderPdfToImage(pathPdf)
            If imgEcg Is Nothing Then err = "Gagal merender gambar dari PDF"
        End If

        Dim bacaan As BacaanEcgData = AmbilBacaanEcg(param(2), param(1))
        e.Result = New Object() {pathPdf, imgEcg, err, param(1), bacaan}
    End Sub

    Private Sub bgwKiri_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles bgwKiri.RunWorkerCompleted
        btnLoadKiri.Enabled = True
        btnLoadKiri.Text = "Muat ECG"

        Dim res() As Object = CType(e.Result, Object())
        Dim pathPdf As String = res(0).ToString()
        Dim imgEcg As Image = CType(res(1), Image)
        Dim err As String = res(2).ToString()
        Dim tgl As String = res(3).ToString()
        Dim bacaan As BacaanEcgData = CType(res(4), BacaanEcgData)

        HapusFileTemp(_tempPdfKiri)
        _tempPdfKiri = pathPdf

        If imgEcg IsNot Nothing Then
            If picKiri.Image IsNot Nothing Then picKiri.Image.Dispose()
            picKiri.Image = imgEcg
            _zoomKiri = 1.0F
            _panKiri = PointF.Empty
            picKiri.Invalidate()

            btnEksternalKiri.Enabled = True
            lblStatusKiri.Text = String.Format("Tampil ({0}x{1} px)", imgEcg.Width, imgEcg.Height)
            lblStatusKiri.ForeColor = Color.MediumSpringGreen
            txtHasilKiri.Text = FormatInfoEcg(tgl, New FileInfo(pathPdf).Length, "Berhasil dimuat", bacaan)
        Else
            If picKiri.Image IsNot Nothing Then
                picKiri.Image.Dispose()
                picKiri.Image = Nothing
            End If
            picKiri.Invalidate()
            btnEksternalKiri.Enabled = (Not String.IsNullOrEmpty(pathPdf) AndAlso File.Exists(pathPdf))
            lblStatusKiri.Text = err
            lblStatusKiri.ForeColor = Color.Salmon
            txtHasilKiri.Text = FormatInfoEcg(tgl, 0, err, bacaan)
        End If
    End Sub

    Private Sub btnLoadKanan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadKanan.Click
        If bgwKanan.IsBusy OrElse cmbTglKanan.SelectedItem Is Nothing Then Return
        btnLoadKanan.Enabled = False
        btnLoadKanan.Text = "Memuat..."
        lblStatusKanan.Text = "Mengunduh & merender ECG..."
        lblStatusKanan.ForeColor = Color.DeepSkyBlue

        Dim nik As String = txtNik.Text.Trim()
        Dim tgl As String = cmbTglKanan.SelectedItem.ToString()
        Dim url As String = String.Format("{0}/api/lab/ecg?nik={1}&tanggal={2}", baseURL, nik, tgl)
        bgwKanan.RunWorkerAsync(New String() {url, tgl, nik})
    End Sub

    Private Sub bgwKanan_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles bgwKanan.DoWork
        Dim param() As String = CType(e.Argument, String())
        Dim err As String = ""
        Dim pathPdf As String = DownloadPdfAPIRM(param(0), "KANAN", err)
        Dim imgEcg As Image = Nothing

        If Not String.IsNullOrEmpty(pathPdf) AndAlso File.Exists(pathPdf) Then
            imgEcg = RenderPdfToImage(pathPdf)
            If imgEcg Is Nothing Then err = "Gagal merender gambar dari PDF"
        End If

        Dim bacaan As BacaanEcgData = AmbilBacaanEcg(param(2), param(1))
        e.Result = New Object() {pathPdf, imgEcg, err, param(1), bacaan}
    End Sub

    Private Sub bgwKanan_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles bgwKanan.RunWorkerCompleted
        btnLoadKanan.Enabled = True
        btnLoadKanan.Text = "Muat ECG"

        Dim res() As Object = CType(e.Result, Object())
        Dim pathPdf As String = res(0).ToString()
        Dim imgEcg As Image = CType(res(1), Image)
        Dim err As String = res(2).ToString()
        Dim tgl As String = res(3).ToString()
        Dim bacaan As BacaanEcgData = CType(res(4), BacaanEcgData)

        HapusFileTemp(_tempPdfKanan)
        _tempPdfKanan = pathPdf

        If imgEcg IsNot Nothing Then
            If picKanan.Image IsNot Nothing Then picKanan.Image.Dispose()
            picKanan.Image = imgEcg
            _zoomKanan = 1.0F
            _panKanan = PointF.Empty
            picKanan.Invalidate()

            btnEksternalKanan.Enabled = True
            lblStatusKanan.Text = String.Format("Tampil ({0}x{1} px)", imgEcg.Width, imgEcg.Height)
            lblStatusKanan.ForeColor = Color.MediumSpringGreen
            txtHasilKanan.Text = FormatInfoEcg(tgl, New FileInfo(pathPdf).Length, "Berhasil dimuat", bacaan)
        Else
            If picKanan.Image IsNot Nothing Then
                picKanan.Image.Dispose()
                picKanan.Image = Nothing
            End If
            picKanan.Invalidate()
            btnEksternalKanan.Enabled = (Not String.IsNullOrEmpty(pathPdf) AndAlso File.Exists(pathPdf))
            lblStatusKanan.Text = err
            lblStatusKanan.ForeColor = Color.Salmon
            txtHasilKanan.Text = FormatInfoEcg(tgl, 0, err, bacaan)
        End If
    End Sub

    ' =========================================================================
    ' 9. FORMATTER RINGKASAN ECG, BUKA PDF EKSTERNAL & CLEANUP
    ' =========================================================================
    Private Function FormatInfoEcg(ByVal tanggal As String, ByVal ukuranByte As Long, ByVal status As String, ByVal bacaan As BacaanEcgData) As String
        Dim diagnosis As String = "-"
        Dim tekanan As String = "-"
        Dim dokter As String = "-"

        If bacaan IsNot Nothing Then
            If Not String.IsNullOrEmpty(bacaan.diagnosisecg) Then diagnosis = bacaan.diagnosisecg.Trim()
            If Not String.IsNullOrEmpty(bacaan.tekanan) Then tekanan = bacaan.tekanan.Trim()
            If Not String.IsNullOrEmpty(bacaan.drecg) Then dokter = bacaan.drecg.Trim()
        End If

        Dim sb As New System.Text.StringBuilder()
        sb.AppendLine("RINGKASAN & HASIL BACAAN ECG (" & tanggal & "):")
        sb.AppendLine("----------------------------------------------------------------------")
        sb.AppendLine("• DIAGNOSIS ECG   : " & diagnosis)
        sb.AppendLine("• TEKANAN         : " & tekanan)
        sb.AppendLine("• DOKTER ECG      : " & dokter)
        sb.AppendLine("• STATUS BERKAS   : " & status & " (" & Math.Round(ukuranByte / 1024.0, 1).ToString() & " KB)")
        Return sb.ToString()
    End Function

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
        If picKiri.Image IsNot Nothing Then picKiri.Image.Dispose()
        If picKanan.Image IsNot Nothing Then picKanan.Image.Dispose()
        HapusFileTemp(_tempPdfKiri)
        HapusFileTemp(_tempPdfKanan)
    End Sub

    Private Function AmbilBacaanEcg(ByVal nik As String, ByVal tanggal As String) As BacaanEcgData
        Try
            Dim url As String = String.Format("{0}/api/lab/ecg/bacaan?nik={1}&tanggal={2}", baseURL, nik, tanggal)
            Dim jsonRaw As String = GetDataAPIRM(url)
            Dim serializer As New JavaScriptSerializer()
            Dim res As BacaanEcgResponse = serializer.Deserialize(Of BacaanEcgResponse)(jsonRaw)

            If res IsNot Nothing AndAlso res.status AndAlso res.data IsNot Nothing Then
                Return res.data
            End If
        Catch
        End Try
        Return Nothing
    End Function
End Class

' =============================================================================
' CLASS MODEL JSON TANGGAL & BACAAN ECG
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

Public Class BacaanEcgResponse
    Public status As Boolean
    Public message As String
    Public data As BacaanEcgData
End Class

Public Class BacaanEcgData
    Public diagnosisecg As String
    Public tekanan As String
    Public drecg As String
End Class