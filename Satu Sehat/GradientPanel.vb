Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class GradientPanel
    Inherits Panel

    Private _Color1 As Color = Color.SkyBlue
    Private _Color2 As Color = Color.MediumPurple

    Public Property Color1() As Color
        Get
            Return _Color1
        End Get
        Set(ByVal value As Color)
            _Color1 = value
            Me.Invalidate() ' redraw saat warna berubah
        End Set
    End Property

    Public Property Color2() As Color
        Get
            Return _Color2
        End Get
        Set(ByVal value As Color)
            _Color2 = value
            Me.Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Using brush As New LinearGradientBrush(Me.ClientRectangle, _Color1, _Color2, LinearGradientMode.Horizontal)
            e.Graphics.FillRectangle(brush, Me.ClientRectangle)
        End Using
        MyBase.OnPaint(e)
    End Sub
End Class
