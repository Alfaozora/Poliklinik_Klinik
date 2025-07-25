Public Class v4_BPJS_Antrol
    Public response() As responseDetail
    Public metadata As metadataDetail

    Public Class responseDetail
        Public nomorantrean As String
        Public angkaantrean As Integer
        Public nomorkartu As String
        Public nik As String
        Public namapeserta As String
        Public kodepoli As String
        Public namapoli As String
        Public keluhan As String
        Public tanggalperiksa As String
        Public tanggaldibuat As String
        Public tanggalbatal As String
        Public tanggaldilayani As String
        Public dibatalkan As String
        Public dilayani As String
        Public dipanggil As String
        Public dilayanioleh As String
        Public konter As String
        Public kodelokasi As String
        Public sisapanggilan As String
        Public sumberantrean As String
        Public jenispeserta As String
        Public statusantrean As String
        Public jeniskelamin As String
        Public tanggallahir As String
        Public alamat As String
        Public nohp As String
        Public kodedokter As String
        Public namadokter As String
        Public kodefaskes As String
        Public namafaskes As String
    End Class

    Public Class metadataDetail
        Public message As String = ""
        Public code As String = ""
    End Class

    ' Get Response
    Public token As String
    Public nama As String
    Public nik As String
    Public nomorkartu As String
    Public nomorkk As String
    Public jeniskelamin As String
    Public tanggallahir As String
    Public alamat As String
    Public kodeprop As String
    Public namaprop As String
    Public kodedati2 As String
    Public namadati2 As String
    Public namakec As String
    Public kodekel As String
    Public namakel As String
    Public rw As String
    Public rt As String

    ' Get Metadata
    Public message As String = ""
    Public code As String = ""

    Public Class ResponseGetAntrean
        Public nomorantrean As String
        Public angkaantrean As Integer
        Public nomorkartu As String
        Public nik As String
        Public namapeserta As String
        Public kodepoli As String
        Public namapoli As String
        Public keluhan As String
        Public tanggalperiksa As String
        Public tanggaldibuat As String
        Public tanggalbatal As String
        Public tanggaldilayani As String
        Public dibatalkan As String
        Public dilayani As String
        Public dilayanioleh As String
        Public sumberantrean As String
        Public jenispeserta As String
    End Class
End Class
