Public Class v4_BPJS_Peserta
    Public response As responseDetail
    Public metaData As metaDataDetail

    Public Class responseDetail
        Public noKartu As String
        Public nama As String
        Public hubunganKeluarga As String
        Public sex As String
        Public tglLahir As String
        Public tglMulaiAktif As String
        Public tglAkhirBerlaku As String

        Public kdProviderPst As kdProviderPstDetail
        Public kdProviderGigi As kdProviderGigiDetail
        Public jnsKelas As jnsKelasDetail
        Public jnsPeserta As jnsPesertaDetail

        Public golDarah As String
        Public noHP As String
        Public noKTP As String
        Public pstProl As String
        Public pstPrb As String
        Public aktif As String
        Public ketAktif As String
        Public tunggakan As String

        Public Class kdProviderPstDetail
            Public kdProvider As String
            Public nmProvider As String
        End Class

        Public Class kdProviderGigiDetail
            Public kdProvider As String
            Public nmProvider As String
        End Class

        Public Class jnsKelasDetail
            Public nama As String
            Public kode As String
        End Class

        Public Class jnsPesertaDetail
            Public nama As String
            Public kode As String
        End Class
    End Class

    Public Class metadataDetail
        Public message As String = ""
        Public code As String = ""
    End Class
End Class
