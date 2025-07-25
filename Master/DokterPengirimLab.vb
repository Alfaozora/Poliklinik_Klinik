Public Class DokterPengirimLab

    Private Sub ClearHeader()
        cmbdokternama.ResetText()
        txid.ResetText()
        txdoktertempatlahir.ResetText()
        dtdoktertgllhr.Value = DateSerial("9998", "12", "31")
        txdokterhp.ResetText()
        txdoktertlp.ResetText()
        txdokterket.ResetText()
        InsertNewItemComboSQL("select distinct DrNama from MasterDokterKirim", cmbdokternama)
    End Sub

    Private Sub ClearPraktek()
        txpraktekid.ResetText()
        txpraktektempat.ResetText()
        txpraktektlp.ResetText()
        txpraktekalamat.ResetText()
        txpraktekkota.ResetText()
        txpraktekket.ResetText()
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        ClearHeader()
        grouppraktek.Enabled = False
        ClearPraktek()
    End Sub

    Private Sub DokterPengirimLab_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        NewToolStripMenuItem.PerformClick()
    End Sub

    Private Sub butclear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ClearPraktek()
    End Sub

    Function Checking() As Boolean
        If dtdoktertgllhr.Value > DateAndTime.Now Then
            MsgBox("Tgl lahir tidak boleh lebih dari hari sekarang")
            Return False
        End If

        If txid.Text = "" And cmbdokternama.FindStringExact(cmbdokternama.Text) >= 0 Then
            If MsgBox("Dokter telah terdaftar. Apakah memang menambah dengan nama dokter ini ?", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then
                MsgBox("Data batal di saved.")
                Return False
            End If
        End If

        txdoktertempatlahir.Text = Strings.Replace(Strings.Replace(Strings.Replace(txdoktertempatlahir.Text, "'", ""), """", ""), "`", "")
        txdokterhp.Text = Strings.Replace(Strings.Replace(Strings.Replace(txdokterhp.Text, "'", ""), """", ""), "`", "")
        txdokterket.Text = Strings.Replace(Strings.Replace(Strings.Replace(txdokterket.Text, "'", ""), """", ""), "`", "")
        txdoktertlp.Text = Strings.Replace(Strings.Replace(Strings.Replace(txdoktertlp.Text, "'", ""), """", ""), "`", "")

        Return True
    End Function

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Checking() = True Then
            If txid.Text = "" Then
                WriteSQL("insert into MasterDokterKirim (DrNama,DrTgllahir,DrTempatLahir,DrTlp,DrHp,DrKeterangan,CreateDate,CreateBy) " & _
                         " values('" & cmbdokternama.Text & "','" & Format(dtdoktertgllhr.Value, "MM/dd/yyyy") & "','" & txdoktertempatlahir.Text & "','" & txdoktertlp.Text & "','" & txdokterhp.Text & "','" & txdokterket.Text & "',getdate(),'" & PoliKlinik.Lbluser.Text & "')", 1)
                txid.Text = ReadSQLNIK("select IdKirim from MasterDokterKirim where DrNama='" & cmbdokternama.Text & "' and DrTgllahir='" & Format(dtdoktertgllhr.Value, "MM/dd/yyyy") & "'")
            Else
                'update
                If MsgBox("apakah akan melakukan udpate data ?", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                    WriteSQL("update MasterDokterKirim set DrNama='" & cmbdokternama.Text & "',DrTgllahir='" & Format(dtdoktertgllhr.Value, "MM/dd/yyyy") & "',DrTempatLahir='" & txdoktertempatlahir.Text & "',DrTlp='" & txdoktertlp.Text & "',DrHp='" & txdokterhp.Text & "',DrKeterangan='" & txdokterket.Text & "' where IdKirim='" & txid.Text & "'", 2)
                Else
                    MsgBox("Abort Update")
                End If
            End If
        End If
    End Sub

    Private Sub TambahAlamatToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TambahAlamatToolStripMenuItem.Click
        grouppraktek.Enabled = True
        ClearPraktek()
    End Sub

    Function CheckingPraktek() As Boolean
        If txid.Text = "" Then
            MsgBox("Masukkan Dokter terlebih dahulu.")
            Return False
        End If

        If CheckSQL("select * from MasterDokterTempatPraktek where NamaPraktek='" & txpraktektempat.Text & "' and IdKirim='" & txid.Text & "' ") = True Then
            MsgBox("Nama Praktek untuk dokter ini telah ada.")
            Return False
        End If

        txpraktektempat.Text = Strings.Replace(Strings.Replace(Strings.Replace(txpraktektempat.Text, "'", ""), """", ""), "`", "")
        txpraktektlp.Text = Strings.Replace(Strings.Replace(Strings.Replace(txpraktektlp.Text, "'", ""), """", ""), "`", "")
        txpraktekalamat.Text = Strings.Replace(Strings.Replace(Strings.Replace(txpraktekalamat.Text, "'", ""), """", ""), "`", "")
        txpraktekkota.Text = Strings.Replace(Strings.Replace(Strings.Replace(txpraktekkota.Text, "'", ""), """", ""), "`", "")
        txpraktekket.Text = Strings.Replace(Strings.Replace(Strings.Replace(txpraktekket.Text, "'", ""), """", ""), "`", "")

        Return True
    End Function

    Private Sub butsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butsave.Click
        If CheckingPraktek = True Then
            If txpraktekid.Text = "" Then
                WriteSQL("insert into MasterDokterTempatPraktek (IdKirim,NamaPraktek,AlamatPraktek,KotaPraktek,TelpPraktek,KeteranganPraktek,CreateDate,CreateBy) " & _
                         "values('" & txid.Text & "','" & txpraktektempat.Text & "','" & txpraktekalamat.Text & "','" & txpraktekkota.Text & "','" & txpraktektlp.Text & "','" & txpraktekket.Text & "',getdate(),'" & PoliKlinik.Lbluser.Text & "')", 4)
                MsgBox("Berhasil Menyimpan Data Detail Praktek Dokter Pengirim.", MsgBoxStyle.Information, "Success!")
            Else
                WriteSQL("update MasterDokterTempatPraktek set NamaPraktek='" & txpraktektempat.Text & "' ,AlamatPraktek='" & txpraktekalamat.Text & "' ,KotaPraktek='" & txpraktekkota.Text & "' ,TelpPraktek='" & txpraktektlp.Text & "' ,KeteranganPraktek='" & txpraktekket.Text & "' where IdKirim='" & txid.Text & "' and IdPraktek='" & txpraktekid.Text & "'", 4)
                MsgBox("Berhasil Menyimpan Data Detail Praktek Dokter Pengirim.", MsgBoxStyle.Information, "Success!")
            End If
            ClearPraktek()
        End If
    End Sub

    Public Sub LoadDokter(ByVal Tiddata As String)
        NewToolStripMenuItem.PerformClick()
        Dim Tbls As DataTable = ReadSQL("select * from MasterDokterKirim where IdKirim='" & Tiddata & "'")
        Dim Trow As DataRow = Tbls.Rows(0)

        txid.Text = Tiddata
        cmbdokternama.Text = Trow("DrNama")
        txdoktertempatlahir.Text = Trow("DrTempatLahir")
        dtdoktertgllhr.Value = Trow("DrTgllahir")
        txdokterhp.Text = Trow("DrHp")
        txdoktertlp.Text = Trow("DrTlp")
        txdokterket.Text = Trow("DrKeterangan")
    End Sub

    Private Sub butfinddokter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butfinddokter.Click
        Find.Show()
        Find.Query("select IdKirim,DrNama,DrTgllahir,DrTempatLahir,DrTlp,DrHp,DrKeterangan from MasterDokterKirim ", " order by DrNama,DrTgllahir,DrTempatLahir ", "FindDokterkirim", 1)
    End Sub

    Private Sub cmbdokternama_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbdokternama.KeyUp
        If e.KeyCode = Keys.Enter Then
            LoadDokter(ReadSQLNIK("select IdKirim from MasterDokterKirim where DrNama='" & cmbdokternama.Text & "'"))
        End If
    End Sub

    Private Sub butclearalamat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butclearalamat.Click
        ClearPraktek()
    End Sub

    Private Sub butsaved_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butsaved.Click
        If Checking() = True Then
            If txid.Text = "" Then
                WriteSQL("insert into MasterDokterKirim (DrNama,DrTgllahir,DrTempatLahir,DrTlp,DrHp,DrKeterangan,CreateDate,CreateBy) " & _
                         " values('" & cmbdokternama.Text & "','" & Format(dtdoktertgllhr.Value, "MM/dd/yyyy") & "','" & txdoktertempatlahir.Text & "','" & txdoktertlp.Text & "','" & txdokterhp.Text & "','" & txdokterket.Text & "',getdate(),'" & PoliKlinik.Lbluser.Text & "')", 4)
                txid.Text = ReadSQLNIK("select IdKirim from MasterDokterKirim where DrNama='" & cmbdokternama.Text & "' and DrTgllahir='" & Format(dtdoktertgllhr.Value, "MM/dd/yyyy") & "'")
                MsgBox("Berhasil Menyimpan Data Diri Dokter Pengirim.", MsgBoxStyle.Information, "Success!")
            Else
                'update
                If MsgBox("apakah akan melakukan udpate data ?", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                    WriteSQL("update MasterDokterKirim set DrNama='" & cmbdokternama.Text & "',DrTgllahir='" & Format(dtdoktertgllhr.Value, "MM/dd/yyyy") & "',DrTempatLahir='" & txdoktertempatlahir.Text & "',DrTlp='" & txdoktertlp.Text & "',DrHp='" & txdokterhp.Text & "',DrKeterangan='" & txdokterket.Text & "' where IdKirim='" & txid.Text & "'", 2)
                Else
                    MsgBox("Abort Update")
                End If
            End If
        End If
    End Sub
End Class