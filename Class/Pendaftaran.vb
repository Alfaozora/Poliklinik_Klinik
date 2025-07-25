Public Class Pendaftaran
    Public Var1 As String
    Public Var2 As String
    Public Var3 As String
    Public Var4 As String

    Public result As String
    Public message As String
    Public field As String

    'Get Pendaftaran By Nomor Urut
    Public noUrut As String
    Public tgldaftar As String
    Public providerPelayanan As ClskdProviderPelayanan
    Public peserta As ClspesertaNoUrut
    Public poli As listPoli
    Public keluhan As String
    Public status As String
    Public sistole As String
    Public diastole As String
    Public beratBadan As String
    Public tinggiBadan As String
    Public respRate As String
    Public heartRate As String
    Public tkp As _TKP

    'Get Pendaftaran Provider 
    Public count As String
    Public list() As listPendaftaran

    Public rows() As JSON_result

    Public Class JSON_result
        Public Komponen As String
        Public Nilai As String
    End Class

    Public Class ClskdProviderPelayanan
        Public kdProvider As String = ""
        Public nmProvider As String = ""
    End Class

    Public Class Clsasuransi
        Public kdAsuransi As String = ""
        Public nmAsuransi As String = ""
        Public noAsuransi As String = ""
    End Class

    Public Class ClskdProviderPst
        Public kdProvider As String = ""
        Public nmProvider As String = ""
    End Class

    Public Class ClskdProviderGigi
        Public kdProvider As String = ""
        Public nmProvider As String = ""
    End Class

    Public Class ClsjnsKelas
        Public nama As String = ""
        Public kode As String = ""
    End Class

    Public Class ClsjnsPeserta
        Public nama As String = ""
        Public kode As String = ""
    End Class

    Public Class ClspesertaNoUrut
        Public noKartu As String = ""
        Public nama As String = ""
        Public hubunganKeluarga As String = ""
        Public sex As String = ""
        Public tglLahir As String
        Public tglMulaiAktif As String = ""
        Public tglAkhirBerlaku As String = ""
        Public kdProviderPst As ClskdProviderPst
        Public kdProviderGigi As ClskdProviderGigi
        Public jnsKelas As ClsjnsKelas
        Public jnsPeserta As ClsjnsPeserta
        Public golDarah As String
        Public noHP As String = ""
        Public noKTP As String = ""
        Public aktif As String = ""
        Public ketAktif As String = ""
        Public asuransi As Clsasuransi
    End Class

    Public Class listPendaftaran
        Public noUrut As String
        Public tgldaftar As String
        Public peserta As ClsPeserta
        Public poli As listPoli
        Public keluhan As String
        Public kunjSakit As String
        Public status As String
        Public sistole As String
        Public diastole As String
        Public beratBadan As String
        Public tinggiBadan As String
        Public respRate As String
        Public heartRate As String
        Public tkp As _TKP

        'Poli
        Public kdPoli As String
        Public nmPoli As String
        Public poliSakit As String

        'Kesadaran
        Public kdSadar As String
        Public nmSadar As String

        'Dokter
        Public kdDokter As String
        Public nmDokter As String

        'Status Pulang
        Public kdStatusPulang As String
        Public nmStatusPulang As String

        'Spesialis Khusus
        Public kdKhusus As String
        Public nmKhusus As String

        'Spesialis
        Public kdSpesialis As String
        Public nmSpesialis As String

        'SubSpesialis
        Public kdSubSpesialis As String
        Public nmSubSpesialis As String
        Public kdPoliRujuk As String

        'Spesialis
        Public kdSarana As String
        Public nmSarana As String

        'Spesialis Khusus
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

        'MCU
        Public kdMCU As String
        Public noKunjungan As String
        Public kdProvider As String
        Public tglPelayanan As String
        Public tekananDarahSistole As String
        Public tekananDarahDiastole As String
        Public radiologiFoto As String
        Public darahRutinHemo As String
        Public darahRutinLeu As String
        Public darahRutinErit As String
        Public darahRutinLaju As String
        Public darahRutinHema As String
        Public darahRutinTrom As String
        Public lemakDarahHDL As String
        Public lemakDarahLDL As String
        Public lemakDarahChol As String
        Public lemakDarahTrigli As String
        Public gulaDarahSewaktu As String
        Public gulaDarahPuasa As String
        Public gulaDarahPostPrandial As String
        Public gulaDarahHbA1c As String
        Public fungsiHatiSGOT As String
        Public fungsiHatiSGPT As String
        Public fungsiHatiGamma As String
        Public fungsiHatiProtKual As String
        Public fungsiHatiAlbumin As String
        Public fungsiGinjalCrea As String
        Public fungsiGinjalUreum As String
        Public fungsiGinjalAsam As String
        Public fungsiJantungABI As String
        Public fungsiJantungEKG As String
        Public fungsiJantungEcho As String
        Public funduskopi As String
        Public pemeriksaanLain As String
        Public keterangan As String

        'Kunjungan
        Public tglKunjungan As String
        Public providerPelayanan As ClskdProviderPelayanan
        Public diagnosa1 As listdiagnosa
        Public diagnosa2 As listdiagnosa
        Public diagnosa3 As listdiagnosa
        Public dokter As listdokter
        Public poliRujukLanjut As listpoliRujukLanjut
        Public providerRujukLanjut As listproviderRujukLanjut
        Public catatanRujuk As String
        Public tglEstRujuk As String

        'Gaji HRD
        Public Komponen As String
        Public Nilai As String
    End Class

    Public Class listproviderRujukLanjut
        Public kdProvider As String
        Public nmProvider As String
    End Class

    Public Class listpoliRujukLanjut
        Public kdPoli As String
        Public nmPoli As String
        Public poliSakit As String
    End Class

    Public Class listdokter
        Public kdDokter As String
        Public nmDokter As String
    End Class

    Public Class listdiagnosa
        Public kdDiag As String
        Public nmDiag As String
        Public nonSpesialis As String
    End Class

    Public Class listPoli
        Public kdPoli As String
        Public nmPoli As String
        Public poliSakit As String
    End Class

    Public Class _TKP
        Public kdTkp As String = ""
        Public nmTkp As String = ""
    End Class

    Public Class ClsPeserta
        Public noKartu As String = ""
        Public nama As String = ""
        Public hubunganKeluarga As String = ""
        Public sex As String = ""
        Public tglLahir As String = ""
        Public tglMulaiAktif As String = ""
        Public tglAkhirBerlaku As String = ""
        Public kdProviderPst As String = ""
        Public kdProviderGigi As String = ""
        Public jnsKelas As String = ""
        Public jnsPeserta As String = ""
        Public golDarah As String = ""
        Public noHP As String = ""
        Public noKTP As String = ""
        Public pstProl As String = ""
        Public pstPrb As String = ""
        Public aktif As String = ""
        Public ketAktif As String = ""
        Public asuransi As String = ""
    End Class

    Public Class ClsDataGaji
        Public SalesOffice As String = ""
        Public KodeAdmin As String = ""
        Public Komponen As String = ""
        Public NilaiNominal As String = ""
    End Class
End Class