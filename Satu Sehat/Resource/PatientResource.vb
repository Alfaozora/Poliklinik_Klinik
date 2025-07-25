Public Class PatientResource
    Public entry() As entryDetail

    Public Class entryDetail
        Public fullUrl As String
        Public resource As resourceDetail

        Public Class resourceDetail
            Public id As String
        End Class
    End Class
End Class
