Public Class InformedConsent
    Public response As responseDetail
    Public metaData As metaDataDetail

    Public Class metaDataDetail
        Public message As String
        Public code As String
    End Class

    Public Class responseDetail
        Public message As String
        Public data As dataDetail

        Public Class dataDetail
            Public id As String
            Public tgl_transaksi As String
            Public kode_lokasi As String
            Public jenis_poli As String
            Public ket_lokasi As String
            Public no_transaksi As String
            Public no_rekam_medis As String
            Public no_nik As String
            Public nama_pasien As String
            Public umur_pasien As Integer
            Public jenis_kelamin_pasien As String
            Public alamat_pasien As String
            Public id_dokter As String
            Public nama_dokter As String
            Public id_perawat As String
            Public nama_perawat As String
            Public ket_diagnosis As String
            Public dasar_diagnosis As String
            Public id_tindakan As Integer
            Public ket_tindakan As String
            Public indikasi_tindakan As String
            Public tata_cara As String
            Public tujuan_tindakan As String
            Public risiko As String
            Public komplikasi As String
            Public prognosis As String
            Public alternatif_tindakan As String
            Public biaya_tindakan As Integer
            Public nama_penanggung_jawab As String
            Public umur_penanggung_jawab As Integer
            Public jenis_kelamin_penanggung_jawab As String
            Public hubungan_penanggung_jawab As String
            Public alamat_penanggung_jawab As String
            Public status_saksi_pasien As Integer
            Public nama_saksi_pasien As String
            Public hubungan_saksi_pasien As String
            Public status_persetujuan As Integer
            Public status_transaksi As String
            Public signed_dokter_1 As String
            Public signed_dokter_2 As String
            Public signed_perawat As String
            Public signed_pasien_1 As String
            Public signed_pasien_2 As String
            Public signed_keluarga As String
        End Class
    End Class
End Class
