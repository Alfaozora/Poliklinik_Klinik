Public Class Kunjungan
    Public message As String
    Public field As String

    Public count As String
    Public list() As listKunjungan

    Public Class listKunjungan
        Public noKunjungan As String
        Public tglKunjungan As String
        Public providerPelayanan As ClsproviderPelayanan
        Public peserta As ClspesertaKunjungan
        Public poli As ClsPoli
        Public progProlanis As ClsprogProlanis
        Public keluhan As String
        Public diagnosa1 As Clsdiagnosa1
        Public diagnosa2 As Clsdiagnosa2
        Public diagnosa3 As Clsdiagnosa3
        Public kesadaran As Clskesadaran
        Public sistole As String
        Public diastole As String
        Public beratBadan As String
        Public tinggiBadan As String
        Public respRate As String
        Public heartRate As String
        Public catatan As String
        Public rujukBalik As String
        Public providerAsalRujuk As ClsproviderAsalRujuk
        Public providerRujukLanjut As ClsproviderRujukLanjut
        Public pemFisikLain As String
        Public dokter As Clsdokter
        Public statusPulang As ClsstatusPulang
        Public tkp As Clstkp
        Public poliRujukInternal As ClspoliRujukInternal
        Public poliRujukLanjut As ClspoliRujukLanjut
        Public tglPulang As String

        'Kesadaran
        Public kdSadar As String
        Public nmSadar As String
    End Class

    Public Class ClspoliRujukLanjut
        Public kdPoli As String
        Public nmPoli As String
        Public poliSakit As String
    End Class

    Public Class ClspoliRujukInternal
        Public kdPoli As String
        Public nmPoli As String
        Public poliSakit As String
    End Class

    Public Class Clstkp
        Public kdTkp As String
        Public nmTkp As String
    End Class

    Public Class ClsstatusPulang
        Public kdStatusPulang As String
        Public nmStatusPulang As String
    End Class

    Public Class Clsdokter
        Public kdDokter As String
        Public nmDokter As String
    End Class

    Public Class ClsproviderRujukLanjut
        Public kdProvider As String
        Public nmProvider As String
    End Class

    Public Class ClsproviderAsalRujuk
        Public kdProvider As String
        Public nmProvider As String
    End Class

    Public Class Clskesadaran
        Public kdSadar As String
        Public nmSadar As String
    End Class

    Public Class Clsdiagnosa1
        Public kdDiag As String
        Public nmDiag As String
        Public nonSpesialis As String
    End Class

    Public Class Clsdiagnosa2
        Public kdDiag As String
        Public nmDiag As String
        Public nonSpesialis As String
    End Class

    Public Class Clsdiagnosa3
        Public kdDiag As String
        Public nmDiag As String
        Public nonSpesialis As String
    End Class

    Public Class ClsprogProlanis
        Public kdProgram As String
        Public nmProgram As String
    End Class

    Public Class ClsproviderPelayanan
        Public kdProvider As String
        Public nmProvider As String
    End Class

    Public Class ClspesertaKunjungan
        Public noKartu As String = ""
        Public nama As String = ""
        Public hubunganKeluarga As String = ""
        Public sex As String = ""
        Public tglLahir As String
        Public tglMulaiAktif As String = ""
        Public tglAkhirBerlaku As String = ""
        Public kdProviderPst As String = ""
        Public kdProviderGigi As String = ""
        Public jnsKelas As String = ""
        Public jnsPeserta As String = ""
        Public golDarah As String
        Public noHP As String = ""
        Public noKTP As String = ""
        Public asuransi As String = ""
    End Class

    Public Class ClsPoli
        Public kdPoli As String
        Public nmPoli As String
        Public poliSakit As String
    End Class
End Class
