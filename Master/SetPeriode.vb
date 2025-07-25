Public Class SetPeriode

    Public Sub Clear()
        dtawal.Value = DateAndTime.Now
        dtakhir.Value = DateSerial("9998", "12", "31")
        dtakhir.Enabled = False
        txkriteria.ResetText()
    End Sub

    Private Sub SetPeriode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub cmbsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbsave.Click
        If cmbstatus.FindStringExact(cmbstatus.Text) < 0 Then
            MsgBox("Status Aktif atau NonAktif harus dipilih")
            Exit Sub
        End If

        If dtawal.Value < dtakhir.Value Then
            Dim Tstatus As String = "0"
            If txkriteria.Text = "AKTIF" Then Tstatus = 1
            WriteMySQL("insert into masteraktifpasien values('" & txkriteria.Text & "'," & Tstatus & ",'" & Format(dtawal.Value, "yyyyMMdd") & "','" & Format(dtakhir.Value, "yyyyMMdd") & "','" & Format(DateAndTime.Now, "yyyyMMdd") & "','" & PoliKlinik.Lbluser.Text & "')", 1)
            Me.Close()
        Else
            MsgBox("Periode awal harus lebih kecil dari periode akhir")
            Exit Sub
        End If
    End Sub
End Class