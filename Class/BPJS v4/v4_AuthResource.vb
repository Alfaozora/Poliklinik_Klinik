Public Class v4_AuthResource
    Public response As responseDetail
    Public metaData As metadataDetail

    Public Class responseDetail
        Public token As String
    End Class

    Public Class metadataDetail
        Public message As String = ""
        Public code As String = ""
    End Class
End Class
