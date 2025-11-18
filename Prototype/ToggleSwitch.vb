Public Class ToggleSwitch
    Private _checked As Boolean = True
    Public Event CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)

    Public Property Checked() As Boolean
        Get
            Return _checked
        End Get
        Set(ByVal value As Boolean)
            _checked = value
            Me.Invalidate()
            RaiseEvent CheckedChanged(Me, EventArgs.Empty)
        End Set
    End Property

    Public Sub New()
        Me.DoubleBuffered = True
        Me.Width = 50
        Me.Height = 25
        _checked = True
    End Sub

    Protected Overrides Sub OnPaint(ByVal pe As PaintEventArgs)
        Dim g As Graphics = pe.Graphics
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        ' Warna background
        Dim backColor As Color = If(_checked, Color.MediumSeaGreen, Color.DarkGray)
        Dim handleColor As Color = Color.White

        ' Background Rounded
        Dim rect As New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)
        Dim path As Drawing2D.GraphicsPath = RoundedRect(rect, Me.Height - 1)

        g.FillPath(New SolidBrush(backColor), path)

        ' Handle bulat
        Dim diameter As Integer = Me.Height - 4
        Dim xPos As Integer = If(_checked, Me.Width - diameter - 2, 2)

        g.FillEllipse(New SolidBrush(handleColor), xPos, 2, diameter, diameter)
    End Sub

    Private Function RoundedRect(ByVal rect As Rectangle, ByVal radius As Integer) As Drawing2D.GraphicsPath
        Dim path As New Drawing2D.GraphicsPath
        Dim d As Integer = radius

        path.AddArc(rect.X, rect.Y, d, d, 180, 90)
        path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90)
        path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90)
        path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90)
        path.CloseFigure()
        Return path
    End Function

    Protected Overrides Sub OnMouseClick(ByVal e As MouseEventArgs)
        Me.Checked = Not Me.Checked
        MyBase.OnMouseClick(e)
    End Sub
End Class
