Public Class Mahasiswa
    Private nama As String
    Private alamat As String
    Private jurusan As String
    Private semester As String
    Private umur As String

    Public Function getNama()
        Return nama
    End Function

    Public Sub setNama(ByRef nm As String)
        nama = nm
    End Sub
End Class
