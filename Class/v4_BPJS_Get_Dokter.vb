Public Class v4_BPJS_Get_Dokter
    Public response As responseDetail
    Public metaData As metaDataDetail

    Public Class responseDetail
        Public count As String
        Public list() As listDetail

        Public Class listDetail
            Public kdDokter As String
            Public nmDokter As String
        End Class
    End Class

    Public Class metaDataDetail
        Public message As String
        Public code As String
    End Class
End Class
