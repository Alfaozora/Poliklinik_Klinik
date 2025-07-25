Imports System.Drawing

Module ShapeDrawingFunctions
    Public Sub DrawTrapezium(ByRef image As Bitmap, ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer, ByVal x3 As Integer, ByVal y3 As Integer, ByVal x4 As Integer, ByVal y4 As Integer, ByVal fillColor As Color, ByVal outlineColor As Color)
        ' Membuat salinan gambar
        Dim updatedImage As New Bitmap(image)

        ' Menggambar trapesium pada gambar odontogram
        Using g As Graphics = Graphics.FromImage(updatedImage)
            ' Membuat path trapesium
            Dim path As New Drawing2D.GraphicsPath()
            'path.AddPolygon(New Point() {New Point(12, 10), New Point(21, 19), New Point(21, 35), New Point(12, 43)})
            path.AddPolygon(New Point() {New Point(x1, y1), New Point(x2, y2), New Point(x3, y3), New Point(x4, y4)})

            ' Menggambar dan mewarnai trapesium
            Using brush As New SolidBrush(fillColor)
                g.FillPath(brush, path)
            End Using

            ' Menggambar garis luar trapesium
            Using pen As New Pen(outlineColor)
                g.DrawPath(pen, path)
            End Using
        End Using

        ' Mengganti gambar asli dengan gambar yang telah diperbarui
        image = updatedImage
    End Sub

    Public Sub DrawTriangle(ByRef image As Bitmap, ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer, ByVal x3 As Integer, ByVal y3 As Integer, ByVal fillColor As Color, ByVal outlineColor As Color)
        ' Membuat salinan gambar
        Dim updatedImage As New Bitmap(image)

        ' Menggambar segitiga pada gambar
        Using g As Graphics = Graphics.FromImage(updatedImage)
            ' Membuat path segitiga
            Dim path As New Drawing2D.GraphicsPath()
            path.AddPolygon(New Point() {New Point(x1, y1), New Point(x2, y2), New Point(x3, y3)})

            ' Menggambar dan mewarnai segitiga
            Using brush As New SolidBrush(fillColor)
                g.FillPath(brush, path)
            End Using

            ' Menggambar garis luar segitiga
            Using pen As New Pen(outlineColor)
                g.DrawPath(pen, path)
            End Using
        End Using

        ' Mengganti gambar asli dengan gambar yang telah diperbarui
        image = updatedImage
    End Sub

    Public Sub DrawSquare(ByRef image As Bitmap, ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer, ByVal fillColor As Color, ByVal outlineColor As Color)
        ' Membuat salinan gambar
        Dim updatedImage As New Bitmap(image)

        ' Menggambar persegi pada gambar
        Using g As Graphics = Graphics.FromImage(updatedImage)
            ' Menghitung panjang sisi persegi berdasarkan koordinat titik
            Dim sideLength As Integer = Math.Abs(x2 - x1)

            ' Menggambar dan mewarnai persegi
            Using brush As New SolidBrush(fillColor)
                g.FillRectangle(brush, x1, y1, sideLength, sideLength)
            End Using

            ' Menggambar garis luar persegi
            Using pen As New Pen(outlineColor)
                g.DrawRectangle(pen, x1, y1, sideLength, sideLength)
            End Using
        End Using

        ' Mengganti gambar asli dengan gambar yang telah diperbarui
        image = updatedImage
    End Sub

    Public Sub DrawText(ByRef image As Bitmap, ByVal x As Integer, ByVal y As Integer, ByVal text As String, ByVal font As Font, ByVal color As Color)
        ' Membuat salinan gambar
        Dim updatedImage As New Bitmap(image)

        ' Menggambar teks pada gambar
        Using g As Graphics = Graphics.FromImage(updatedImage)
            ' Menentukan format teks
            Dim format As New StringFormat()
            format.Alignment = StringAlignment.Center
            format.LineAlignment = StringAlignment.Center

            ' Menggambar teks pada titik koordinat yang ditentukan
            g.DrawString(text, font, New SolidBrush(color), x, y, format)
        End Using

        ' Mengganti gambar asli dengan gambar yang telah diperbarui
        image = updatedImage
    End Sub

    Public Sub DrawLines(ByRef image As Bitmap, ByVal startPoint1 As Point, ByVal endPoint1 As Point, ByVal startPoint2 As Point, ByVal endPoint2 As Point, ByVal color As Color, ByVal lineWidth As Integer)
        ' Membuat salinan gambar
        Dim updatedImage As New Bitmap(image)

        ' Menggambar garis-garis pada gambar
        Using g As Graphics = Graphics.FromImage(updatedImage)
            Dim pen As New Pen(color, lineWidth) ' Warna dan lebar garis

            ' Menggambar garis pertama
            g.DrawLine(pen, startPoint1, endPoint1)

            ' Menggambar garis kedua
            g.DrawLine(pen, startPoint2, endPoint2)
        End Using

        ' Mengganti gambar asli dengan gambar yang telah diperbarui
        image = updatedImage
    End Sub

    Public Sub DrawColoredRectangle(ByRef image As Bitmap, ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer, ByVal lineThickness As Integer)
        ' Membuat salinan gambar
        Dim updatedImage As New Bitmap(image)

        ' Menggambar bidang warna pada gambar odontogram
        Using g As Graphics = Graphics.FromImage(updatedImage)
            Dim sideLength As Integer = Math.Abs(x2 - x1) ' Menghitung panjang sisi persegi berdasarkan koordinat titik

            Using pen As New Pen(Color.Black, lineThickness)
                g.DrawRectangle(pen, x1, y1, sideLength, sideLength)
            End Using
        End Using

        ' Menampilkan gambar odontogram yang telah diperbarui
        image = updatedImage
    End Sub

    Public Sub DrawColoredRectangleWithVerticalHatch(ByRef image As Bitmap, ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Integer, ByVal y2 As Integer, ByVal hatchColor As Color)
        ' Membuat salinan gambar
        Dim updatedImage As New Bitmap(image)

        ' Menggambar bidang warna pada gambar odontogram
        Using g As Graphics = Graphics.FromImage(updatedImage)
            Dim sideLength As Integer = Math.Abs(x2 - x1) ' Menghitung panjang sisi persegi berdasarkan koordinat titik

            ' Menggambar persegi panjang
            Using pen As New Pen(hatchColor)
                g.DrawRectangle(pen, x1, y1, sideLength, sideLength)
            End Using

            ' Menggambar arsiran vertikal dengan TextureBrush
            Dim hatchImage As New Bitmap(sideLength, sideLength)
            Using hatchGraphics As Graphics = Graphics.FromImage(hatchImage)
                Using hatchPen As New Pen(hatchColor)
                    ' Menggambar garis arsiran vertikal
                    For i As Integer = 0 To sideLength - 1 Step 3
                        hatchGraphics.DrawLine(hatchPen, i, 0, i, sideLength)
                    Next
                End Using
            End Using

            Using hatchBrush As New TextureBrush(hatchImage)
                g.FillRectangle(hatchBrush, x1, y1, sideLength, sideLength)
            End Using
        End Using

        ' Menampilkan gambar odontogram yang telah diperbarui
        image = updatedImage
    End Sub
End Module
