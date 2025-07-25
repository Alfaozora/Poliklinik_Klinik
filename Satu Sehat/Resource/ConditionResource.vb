Public Class ConditionResource
    ' Definisikan kelas untuk mewakili kondisi
    Public Class Condition
        Public reference As String
        Public display As String
    End Class

    ' Definisikan kelas untuk mewakili coding
    Public Class Coding
        Public system As String
        Public code As String
        Public display As String
    End Class

    ' Definisikan kelas untuk mewakili use
    Public Class Use
        Public coding As Coding()
    End Class

    ' Definisikan kelas untuk mewakili diagnosis
    Public Class Diagnosis
        Public condition As Condition
        Public use As Use
        Public rank As Integer
    End Class

    ' Definisikan kelas untuk mewakili period
    Public Class Period
        Public start As String
        Public [end] As String
    End Class

    ' Definisikan kelas untuk mewakili status history
    Public Class StatusHistory
        Public status As String
        Public period As Period
    End Class

    ' Definisikan kelas untuk mewakili service provider
    Public Class ServiceProvider
        Public reference As String
    End Class

    ' Definisikan kelas untuk mewakili seluruh data
    Public Class YourDataStructure
        Public diagnosis As Diagnosis()
        Public statusHistory As StatusHistory()
        Public serviceProvider As ServiceProvider
    End Class
End Class
