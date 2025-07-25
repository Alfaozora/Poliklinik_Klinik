Public Class ResponseResource
    Public resourceType As String

    ' Success
    Public entry() As entryDetail

    Public Class entryDetail
        Public response As responseDetail

        Public Class responseDetail
            Public resourceType As String
            Public resourceID As String
            Public status As String
        End Class
    End Class

    ' Error
    Public issue() As issueDetail

    Public Class issueDetail
        Public code As String
        Public details As detailVariabel

        Public Class detailVariabel
            Public text As String
        End Class
    End Class
End Class
