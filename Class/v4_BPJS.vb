Public Class v4_BPJS
    ' Token
    Public token As String

    ' Result
    Public field As String
    Public message As String
    Public count As String

    Public noKTP As String
    Public noKartu As String
    Public nama As String
    Public hubunganKeluarga As String
    Public sex As String
    Public tglLahir As String
    Public pstProl As String
    Public pstPrb As String
    Public aktif As String
    Public ketAktif As String
    Public noHP As String
    Public golDarah As String
    Public tglMulaiAktif As String
    Public tglAkhirBerlaku As String
    Public tunggakan As String

    Public kdProviderPst As kdProviderPstDetail
    Public kdProviderGigi As kdProviderGigiDetail
    Public jnsKelas As jnsKelasDetail
    Public jnsPeserta As jnsPesertaDetail

    ' Rujukan
    Public noRujukan As String
    Public nokaPst As String
    Public nmPst As String
    Public catatanRujuk As String
    Public ppk As ppkDetail
    Public diag1 As diag1Detail
    Public diag2 As diag2Detail
    Public diag3 As diag3Detail
    Public pisa As String
    Public ppkRujuk As ppkRujukDetail
    Public dokter As dokterDetail
    Public tglEstRujuk As String
    Public tglAkhirRujuk As String
    Public tglKunjungan As String
    Public poli As poliDetail
    Public tacc As taccDetail

    Public list() As listDetail

    Public Class taccDetail
        Public nmTacc As String
        Public alasanTacc As String
    End Class

    Public Class dokterDetail
        Public kdDokter As String
        Public nmDokter As String
    End Class

    Public Class ppkRujukDetail
        Public kdPPK As String
        Public nmPPK As String
    End Class

    Public Class diag1Detail
        Public kdDiag As String
        Public nmDiag As String
        Public nonSpesialis As String
    End Class

    Public Class diag2Detail
        Public kdDiag As String
        Public nmDiag As String
        Public nonSpesialis As String
    End Class

    Public Class diag3Detail
        Public kdDiag As String
        Public nmDiag As String
        Public nonSpesialis As String
    End Class

    Public Class ppkDetail
        Public kdPPK As String
        Public nmPPK As String
        Public kc As kcDetail
    End Class

    Public Class kcDetail
        Public kdKC As String
        Public nmKC As String
        Public dati As datiDetail
        Public kdKR As kdKRDetail
    End Class

    Public Class datiDetail
        Public kdDati As String
        Public nmDati As String
    End Class

    Public Class kdKRDetail
        Public kdKR As String
        Public nmKR As String
    End Class

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

    Public Class listDetail
        ' Get Data Diagnosa
        Public kdDiag As String
        Public nmDiag As String
        Public nonSpesialis As String

        ' Get Data Referensi Khusus
        Public kdKhusus As String
        Public nmKhusus As String

        ' Get Data Referensi Spesialis
        Public kdSpesialis As String
        Public nmSpesialis As String

        ' Get Data Referensi Sub Spesialis
        Public kdSubSpesialis As String
        Public nmSubSpesialis As String
        Public kdPoliRujuk As String

        ' Get Data Referensi Sarana Rujukan
        Public kdSarana As String
        Public nmSarana As String

        ' Get Obat DPHO
        Public kdObat As String
        Public nmObat As String

        ' Get Faskes Rujukan
        Public kdppk As String
        Public nmppk As String
        Public alamatPpk As String
        Public telpPpk As String
        Public kelas As String
        Public nmkc As String
        Public distance As String
        Public jadwal As String
        Public jmlRujuk As String
        Public kapasitas As String
        Public persentase As String

        ' Dokter
        Public kdDokter As String
        Public nmDokter As String

        ' Riwayat Kunjungan
        Public noKunjungan As String
        Public providerPelayanan As kdProviderPstDetail
        Public poli As poliDetail
        Public tglKunjungan As String
        Public diagnosa1 As diag1Detail
        Public diagnosa2 As diag2Detail
        Public diagnosa3 As diag3Detail
    End Class

    Public Class poliDetail
        Public kdPoli As String
        Public nmPoli As String
        Public poliSakit As String
    End Class
End Class
