Imports System.IO
Imports System.Drawing

Public Class FormHasilUsg

    ' --- PROPERTY BRIDGING DATA (EKSPLISIT VB.NET 2008) ---
    Private _gambarUSG As Image
    Private _pathVideoUSG As String

    Private imgOffsetX As Single = 0
    Private imgOffsetY As Single = 0

    Public Property GambarUSG() As Image
        Get
            Return _gambarUSG
        End Get
        Set(ByVal value As Image)
            _gambarUSG = value
        End Set
    End Property

    Public Property PathVideoUSG() As String
        Get
            Return _pathVideoUSG
        End Get
        Set(ByVal value As String)
            _pathVideoUSG = value
        End Set
    End Property

    ' --- VARIABEL INTERNAL ---
    Private currentImage As Bitmap
    Private masterImage As Bitmap
    Private zoomFactor As Single = 1.0F

    Private isDragging As Boolean = False
    Private startPoint As Point = Point.Empty

    Private Sub FormHasilUsg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Buka pertama kali langsung dalam Mode Foto
        TampilkanFotoMode()
    End Sub

    ' =========================================================================
    ' 1. METODE PERPINDAHAN MODE (FOTO VS VIDEO)
    ' =========================================================================
    Public Sub TampilkanFotoMode()
        ' Matikan video jika sedang berjalan
        Try
            If AxWindowsMediaPlayer1 IsNot Nothing AndAlso AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsPlaying Then
                AxWindowsMediaPlayer1.Ctlcontrols.stop()
            End If
        Catch ex As Exception
        End Try

        ' Sembunyikan Player Video, Tampilkan PictureBox Foto
        AxWindowsMediaPlayer1.Visible = False
        picFullUSG.Visible = True

        ' Aktifkan tombol Zoom & Rotate di Panel Bawah
        btnZoomIn.Enabled = True
        btnZoomOut.Enabled = True
        btnRotateRight.Enabled = True
        btnReset.Enabled = True

        InisialisasiGambarUSG()
    End Sub

    Public Sub TampilkanVideoMode()
        ' Sembunyikan PictureBox Foto, Tampilkan Player Video
        picFullUSG.Visible = False

        AxWindowsMediaPlayer1.Location = New Point(0, 0)
        AxWindowsMediaPlayer1.Size = New Size(PanelViewer.ClientSize.Width, PanelViewer.ClientSize.Height)
        AxWindowsMediaPlayer1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right

        AxWindowsMediaPlayer1.BringToFront()

        AxWindowsMediaPlayer1.Parent = PanelViewer
        AxWindowsMediaPlayer1.Visible = True

        ' Nonaktifkan Zoom & Rotate (karena ini mode video)
        btnZoomIn.Enabled = False
        btnZoomOut.Enabled = False
        btnRotateRight.Enabled = False
        btnReset.Enabled = False

        InisialisasiVideoUSG()
    End Sub

    ' =========================================================================
    ' 2. INSIALISASI GAMBAR & VIDEO (FALLBACK SAMPEL LOKAL)
    ' =========================================================================
    Private Sub InisialisasiGambarUSG()
        If masterImage IsNot Nothing Then masterImage.Dispose()
        If currentImage IsNot Nothing Then currentImage.Dispose()

        If GambarUSG IsNot Nothing Then
            masterImage = New Bitmap(GambarUSG)
        Else
            Dim samplePath As String = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Samples\usg_sample.jpg")

            If System.IO.File.Exists(samplePath) Then
                Using fs As New System.IO.FileStream(samplePath, System.IO.FileMode.Open, System.IO.FileAccess.Read)
                    masterImage = New Bitmap(fs)
                End Using
            Else
                masterImage = BuatPlaceholderGambar("Belum Ada Hasil Gambar USG (Bridging Pending)")
            End If
        End If

        currentImage = New Bitmap(masterImage)
        zoomFactor = 1.0F
        imgOffsetX = 0
        imgOffsetY = 0

        ' Matikan AutoScroll & set properti penunjang render
        PanelViewer.AutoScroll = False
        picFullUSG.Image = Nothing
        picFullUSG.BackgroundImage = Nothing

        RenderGambar()
    End Sub

    Private Sub InisialisasiVideoUSG()
        Dim targetVideoPath As String = PathVideoUSG

        If String.IsNullOrEmpty(targetVideoPath) OrElse Not File.Exists(targetVideoPath) Then
            targetVideoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Samples\usg_video_sample.mp4")
        End If

        If File.Exists(targetVideoPath) Then
            AxWindowsMediaPlayer1.URL = targetVideoPath
            AxWindowsMediaPlayer1.Ctlcontrols.play()
        Else
            MsgBox("File video USG tidak ditemukan!", MsgBoxStyle.Exclamation, "Video Missing")
        End If
    End Sub

    ' =========================================================================
    ' 3. MANIPULASI GAMBAR (ZOOM / PLACEHOLDER)
    ' =========================================================================
    Private Sub RenderGambar()
        If currentImage Is Nothing Then Return

        Try
            If zoomFactor = 1.0F Then
                ' 1. TAMPILAN NORMAL (FIT TO PANEL)
                ' Matikan scroll temporary saat mode fit
                PanelViewer.AutoScroll = False

                picFullUSG.SizeMode = PictureBoxSizeMode.Zoom
                picFullUSG.Size = PanelViewer.ClientSize
                picFullUSG.Location = New Point(0, 0)
                picFullUSG.Image = currentImage
            Else
                ' 2. TAMPILAN ZOOM IN / OUT
                PanelViewer.AutoScroll = True

                ' Hitung aspek rasio asli gambar agar tidak gepeng saat di-zoom
                Dim imgRatio As Double = CDbl(currentImage.Width) / CDbl(currentImage.Height)

                ' Hitung basis ukuran awal mengikuti panel
                Dim baseWidth As Integer = PanelViewer.ClientSize.Width
                Dim baseHeight As Integer = CInt(baseWidth / imgRatio)

                If baseHeight > PanelViewer.ClientSize.Height Then
                    baseHeight = PanelViewer.ClientSize.Height
                    baseWidth = CInt(baseHeight * imgRatio)
                End If

                ' Hitung ukuran baru setelah dikali zoomFactor
                Dim newWidth As Integer = CInt(baseWidth * zoomFactor)
                Dim newHeight As Integer = CInt(baseHeight * zoomFactor)

                picFullUSG.SizeMode = PictureBoxSizeMode.StretchImage
                picFullUSG.Size = New Size(newWidth, newHeight)
                picFullUSG.Image = currentImage
            End If

        Catch ex As Exception
            MsgBox("Gagal merender Gambar: " & ex.Message, MsgBoxStyle.Exclamation, "Render Error")
        End Try

        picFullUSG.Invalidate()
    End Sub

    Private Sub picFullUSG_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles picFullUSG.Paint
        If currentImage Is Nothing Then Return

        Dim g As Graphics = e.Graphics

        ' 1. BERSIHKAN KANVAS DENGAN WARNA HITAM (Mencegah jejak render lama / gambar ganda)
        g.Clear(Color.Black)

        ' 2. Set mode rendering kualitas tinggi
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
        g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality

        ' 3. Gunakan ImageAttributes untuk mengunci mode Tile (WrapMode.Clamp)
        Using wrapMode As New System.Drawing.Imaging.ImageAttributes()
            wrapMode.SetWrapMode(System.Drawing.Drawing2D.WrapMode.Clamp)

            ' Hitung dimensi kanvas viewer
            Dim canvasWidth As Integer = picFullUSG.ClientSize.Width
            Dim canvasHeight As Integer = picFullUSG.ClientSize.Height

            ' Hitung rasio aspek gambar
            Dim imgRatio As Double = CDbl(currentImage.Width) / CDbl(currentImage.Height)
            Dim baseW As Double = canvasWidth
            Dim baseH As Double = baseW / imgRatio

            If baseH > canvasHeight Then
                baseH = canvasHeight
                baseW = baseH * imgRatio
            End If

            ' Hitung ukuran gambar sesuai zoomFactor
            Dim targetW As Single = CSng(baseW * zoomFactor)
            Dim targetH As Single = CSng(baseH * zoomFactor)

            ' Hitung posisi tengah + offset drag mouse
            Dim rectX As Single = ((canvasWidth - targetW) / 2.0F) + imgOffsetX
            Dim rectY As Single = ((canvasHeight - targetH) / 2.0F) + imgOffsetY

            ' Dynamic Destination Rectangle
            Dim destRect As New RectangleF(rectX, rectY, targetW, targetH)

            ' Gambar tunggal (tanpa perulangan/tiling)
            g.DrawImage(currentImage, _
                         New Rectangle(CInt(rectX), CInt(rectY), CInt(targetW), CInt(targetH)), _
                         0, 0, currentImage.Width, currentImage.Height, _
                         GraphicsUnit.Pixel, wrapMode)
        End Using
    End Sub

    Private Function BuatPlaceholderGambar(ByVal teks As String) As Bitmap
        Dim bmp As New Bitmap(800, 600)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.Clear(Color.Black)
            Using pen As New Pen(Color.DimGray, 2)
                g.DrawRectangle(pen, 10, 10, 780, 580)
            End Using
            Using font As New Font("Arial", 14, FontStyle.Bold)
                Using brush As New SolidBrush(Color.LightGray)
                    Dim sf As New StringFormat()
                    sf.Alignment = StringAlignment.Center
                    sf.LineAlignment = StringAlignment.Center
                    g.DrawString(teks, font, brush, New RectangleF(0, 0, 800, 600), sf)
                End Using
            End Using
        End Using
        Return bmp
    End Function

    ' =========================================================================
    ' 4. EVENT TOMBOL-TOMBOL TOOLBAR BARIS BAWAH
    ' =========================================================================
    Private Sub btnZoomIn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnZoomIn.Click
        If zoomFactor < 10.0F Then ' Bebas perbesar hingga 10x lipat
            zoomFactor = CSng(Math.Round(zoomFactor + 0.25F, 2))
            RenderGambar()
        End If
    End Sub

    Private Sub btnZoomOut_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnZoomOut.Click
        If zoomFactor > 0.5F Then ' Bebas perkecil hingga 0.5x
            zoomFactor = CSng(Math.Round(zoomFactor - 0.25F, 2))
            RenderGambar()
        End If
    End Sub

    Private Sub btnRotateRight_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRotateRight.Click
        If currentImage IsNot Nothing Then
            currentImage.RotateFlip(RotateFlipType.Rotate90FlipNone)
            RenderGambar()
        End If
    End Sub

    Private Sub btnReset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReset.Click
        zoomFactor = 1.0F
        imgOffsetX = 0
        imgOffsetY = 0
        InisialisasiGambarUSG()
    End Sub

    ' Pilihan Switch Mode dari Tombol Atas / Menu
    Private Sub btnModeFoto_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnModeFoto.Click
        TampilkanFotoMode()
    End Sub

    Private Sub btnModeVideo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnModeVideo.Click
        TampilkanVideoMode()
    End Sub

    Private Sub FormHasilUsg_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            If AxWindowsMediaPlayer1 IsNot Nothing Then
                AxWindowsMediaPlayer1.Ctlcontrols.stop()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub picFullUSG_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picFullUSG.MouseDown
        If e.Button = MouseButtons.Left Then
            isDragging = True
            startPoint = e.Location
            picFullUSG.Cursor = Cursors.Hand
        End If
    End Sub

    Private Sub picFullUSG_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picFullUSG.MouseMove
        If isDragging Then
            imgOffsetX += (e.X - startPoint.X)
            imgOffsetY += (e.Y - startPoint.Y)
            startPoint = e.Location
            picFullUSG.Invalidate() ' redraw canvas
        End If
    End Sub

    Private Sub picFullUSG_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picFullUSG.MouseUp
        If e.Button = MouseButtons.Left Then
            isDragging = False
            picFullUSG.Cursor = Cursors.Default
        End If
    End Sub
End Class