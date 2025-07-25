Public Class v4_BPJS_Kunjungan
    Public response As responseDetail
    Public metaData As metadataDetail

    Public Class responseDetail
        Public count As String
        Public list() As listDetail

        Public Class listDetail
            Public noKunjungan As String
            Public tglKunjungan As String
            Public providerPelayanan As kdProviderPstDetail
            Public poli As poliDetail
        End Class

        Public Class kdProviderPstDetail
            Public kdProvider As String
            Public nmProvider As String
        End Class
    End Class

    Public Class poliDetail
        Public kdPoli As String
        Public nmPoli As String
        Public poliSakit As String
    End Class

    Public Class metadataDetail
        Public message As String = ""
        Public code As String = ""
    End Class
End Class
