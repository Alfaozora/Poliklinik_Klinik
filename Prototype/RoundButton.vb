Imports System.Drawing.Drawing2D

Public Class RoundButton
    Public Class RoundButton
        Inherits Button

        Protected Overrides Sub OnResize(ByVal e As EventArgs)
            MyBase.OnResize(e)
            Dim gp As New GraphicsPath()
            gp.AddEllipse(0, 0, Me.Width - 1, Me.Height - 1)
            Me.Region = New Region(gp)
        End Sub

        Protected Overrides Sub OnPaint(ByVal pevent As PaintEventArgs)
            MyBase.OnPaint(pevent)

            ' Membuat bentuk lingkaran
            Dim g As Graphics = pevent.Graphics
            g.SmoothingMode = SmoothingMode.AntiAlias

            Dim rect As Rectangle = New Rectangle(0, 0, Me.Width - 1, Me.Height - 1)
            Dim path As New GraphicsPath()
            path.AddEllipse(rect)

            ' Border
            Using p As New Pen(Color.Black, 2)
                g.DrawPath(p, path)
            End Using
        End Sub
    End Class

End Class
