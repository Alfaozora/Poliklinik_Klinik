Imports System.Drawing

Public Class FormHasilUsg

    ' Property untuk menampung gambar asli dari Form Utama
    'Public Property GambarUSG() As Image

    ' Variabel penampung internal
    Private currentImage As Bitmap
    Private zoomFactor As Single = 1.0F

    Private Sub FormHasilUsg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'If GambarUSG IsNot Nothing Then
        '    ' Clone gambar agar manipulasi rotate tidak merusak gambar asli di form utama
        '    currentImage = New Bitmap(GambarUSG)
        '    TampilkanGambar()
        'End If
    End Sub

    Private Sub TampilkanGambar()
        If currentImage Is Nothing Then Return

        ' Hitung ukuran baru berdasarkan zoom factor
        Dim newWidth As Integer = CInt(currentImage.Width * zoomFactor)
        Dim newHeight As Integer = CInt(currentImage.Height * zoomFactor)

        ' Jika zoomFactor = 1.0, gunakan mode Zoom bawaan PictureBox agar pas di layar
        If zoomFactor = 1.0F Then
            picFullUSG.SizeMode = PictureBoxSizeMode.Zoom
            picFullUSG.Image = currentImage
        Else
            ' Jika di-zoom in/out, ubah ke mode Normal dan sesuaikan ukuran PictureBox
            picFullUSG.SizeMode = PictureBoxSizeMode.StretchImage
            picFullUSG.Size = New Size(newWidth, newHeight)

            ' Buat Bitmap baru hasil resize
            Dim resizedBmp As New Bitmap(currentImage, newWidth, newHeight)
            If picFullUSG.Image IsNot Nothing Then picFullUSG.Image.Dispose()
            picFullUSG.Image = resizedBmp
        End If
    End Sub

    ' --- 1. FITUR ROTATE KANAN (90 Drajat) ---
    Public Sub RotateKanan()
        If currentImage IsNot Nothing Then
            currentImage.RotateFlip(RotateFlipType.Rotate90FlipNone)
            TampilkanGambar()
        End If
    End Sub

    ' --- 2. FITUR ROTATE KIRI (90 Drajat) ---
    Public Sub RotateKiri()
        If currentImage IsNot Nothing Then
            currentImage.RotateFlip(RotateFlipType.Rotate270FlipNone)
            TampilkanGambar()
        End If
    End Sub

    ' --- 3. FITUR ZOOM IN (+20%) ---
    Public Sub ZoomIn()
        If zoomFactor < 5.0F Then ' Maksimal zoom 5x
            zoomFactor += 0.2F
            TampilkanGambar()
        End If
    End Sub

    ' --- 4. FITUR ZOOM OUT (-20%) ---
    Public Sub ZoomOut()
        If zoomFactor > 0.4F Then ' Minimal zoom 0.4x
            zoomFactor -= 0.2F
            TampilkanGambar()
        End If
    End Sub

    ' --- 5. FITUR RESET ZOOM & ROTATE ---
    Public Sub ResetView()
        'If GambarUSG IsNot Nothing Then
        '    zoomFactor = 1.0F
        '    currentImage = New Bitmap(GambarUSG)
        '    TampilkanGambar()
        'End If
    End Sub

    ' --- EVENT HANDLER TOMBOL DI FORM PREVIEW ---
    Private Sub btnZoomIn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnZoomIn.Click
        ZoomIn()
    End Sub

    Private Sub btnZoomOut_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnZoomOut.Click
        ZoomOut()
    End Sub

    Private Sub btnRotateRight_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRotateRight.Click
        RotateKanan()
    End Sub

    Private Sub btnReset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReset.Click
        ResetView()
    End Sub
End Class