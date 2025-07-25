Public Class Rujukan
    Public message As String
    Public field As String

    Public noRujukan As String
    Public ppk As Clsppk
    Public tglKunjungan As String
    Public poli As Clspoli
    Public nokaPst As String
    Public nmPst As String
    Public tglLahir As String
    Public pisa As String
    Public ketPisa As String
    Public sex As String
    Public diag1 As Clsdiag1
    Public diag2 As String
    Public diag3 As String
    Public catatan As String
    Public dokter As Clsdokter
    Public tacc As Clstacc
    Public infoDenda As String

    Public Class Clsppk
        Public kdPPK As String
        Public nmPPK As String
        Public alamat As String
        Public kc As Clskc
    End Class

    Public Class Clskc
        Public kdKC As String
        Public nmKC As String
        Public alamat As String
        Public telp As String
        Public fax As String
        Public dati As Clsdati
        Public kdKR As String
    End Class

    Public Class Clsdati
        Public kdProp As String
        Public kdDati As String
        Public nmDati As String
    End Class

    Public Class ClskdKR
        Public kdKR As String
        Public nmKR As String
        Public alamat As String
        Public telp As String
        Public fax As String
    End Class

    Public Class Clspoli
        Public kdPoli As String
        Public nmPoli As String
    End Class

    Public Class Clsdiag1
        Public kdDiag As String
        Public nmDiag As String
    End Class

    Public Class Clsdokter
        Public kdDokter As String
        Public nmDokter As String
    End Class

    Public Class Clstacc
        Public nmTacc As String
        Public alasanTacc As String
    End Class
End Class
