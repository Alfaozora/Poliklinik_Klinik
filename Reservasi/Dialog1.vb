Imports System.Windows.Forms

Public Class Dialog1

    ' Tambahkan properti di dalam class
    Private _tglMulaiBaru As DateTime
    Private _tglAkhirBaru As DateTime

    Public Property TglMulaiBaru() As DateTime
        Get
            Return _tglMulaiBaru
        End Get
        Set(ByVal value As DateTime)
            _tglMulaiBaru = value
        End Set
    End Property

    Public Property TglAkhirBaru() As DateTime
        Get
            Return _tglAkhirBaru
        End Get
        Set(ByVal value As DateTime)
            _tglAkhirBaru = value
        End Set
    End Property

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        ' Ambil nilai dari DateTimePicker saat tombol OK diklik
        TglMulaiBaru = dtReservasiUlang.Value
        TglAkhirBaru = dtSelesaiUlang.Value

        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Dialog1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Inisialisasi jika perlu
        dtReservasiUlang.Value = DateTime.Now
        dtSelesaiUlang.Value = DateTime.Now.AddMinutes(30)
    End Sub
End Class
