Imports System.Drawing
Imports System.Reflection

Public Class Form2
    Private g As Graphics
    Private bmp As Bitmap
    Private WithEvents canvas As New Panel
    Private pen As New Pen(Color.Black, 3)

    Private isDrawing As Boolean = False
    Private prevPoint As Point

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set DoubleBuffered option
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.DoubleBuffer, True)

        ' Aktifkan opsi OptimizedDoubleBuffer pada canvas
        canvas.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance Or BindingFlags.NonPublic).SetValue(canvas, True, Nothing)

        ' Initialize canvas
        canvas.Dock = DockStyle.Fill
        Me.Controls.Add(canvas)

        ' Create bitmap and graphics object
        bmp = New Bitmap(canvas.Width, canvas.Height)
        g = Graphics.FromImage(bmp)

        ' Set background color
        g.Clear(Color.White)

        ' Add event handlers to canvas
        AddHandler canvas.MouseDown, AddressOf canvas_MouseDown
        AddHandler canvas.MouseMove, AddressOf canvas_MouseMove
        AddHandler canvas.MouseUp, AddressOf canvas_MouseUp
    End Sub

    Private Sub canvas_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        ' Start drawing
        isDrawing = True
        prevPoint = e.Location
    End Sub

    Private Sub canvas_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If isDrawing Then
            ' Draw line between previous point and current point
            g.DrawLine(pen, prevPoint, e.Location)

            ' Update previous point
            prevPoint = e.Location

            ' Refresh canvas
            canvas.Invalidate()
        End If
    End Sub

    Private Sub canvas_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        ' Stop drawing
        isDrawing = False
    End Sub

    Private Sub canvas_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles canvas.Paint
        ' Draw bitmap on canvas
        e.Graphics.DrawImage(bmp, 0, 0)

        '' Gambar pada canvas
        'Dim g As Graphics = e.Graphics
        'g.DrawLine(Pens.Black, 0, 0, canvas.Width, canvas.Height)

        '' Lakukan pembuatan ulang manual pada canvas
        'canvas.Refresh()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        ' Save image
        bmp.Save("D:\signature.png", System.Drawing.Imaging.ImageFormat.Png)

        'Dim bitmap As New Bitmap(canvas.Width, canvas.Height)

        'canvas.DrawToBitmap(bitmap, canvas.ClientRectangle)

        'bitmap.Save("D:\tanda_tangan.jpg", Imaging.ImageFormat.Jpeg)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' Set background color
        g.Clear(Color.White)

        ' Tambahkan kode tambahan untuk mengatur kembali kondisi awal lainnya (jika ada)

        ' Panggil method Refresh pada canvas untuk menggambar kembali tampilan yang telah direset
        canvas.Refresh()
    End Sub
End Class
