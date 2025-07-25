Public Class v4_BPJS_Antrol_Get_Peserta
    Public response As responseDetail
    Public metadata As metadataDetail

    Public Class responseDetail
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
    End Class


    Public Class metadataDetail
        Public message As String = ""
        Public code As String = ""
    End Class
End Class
