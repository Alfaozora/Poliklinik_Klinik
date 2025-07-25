Public Class FindNoInvoice

    Private Sub butdisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butdisplay.Click
        Dim NoInvoice As String = ""
        If CheckSQL("select RekapID from TransaksiLab where RekapID is not null and NoUrut = '" & txnourut.Text & "'") = True Then
            NoInvoice = ReadSQLNIK("select notagihancompany from RekapTagihan where RekapID in (select RekapID from TransaksiLab where NoUrut = '" & txnourut.Text & "')")
            txnoinvoice.Text = NoInvoice
        Else
            If CheckSQL("select * from TransaksiLab where NoUrut = '" & txnourut.Text & "'") = True Then
                txnoinvoice.ResetText()
                MsgBox("Transaksi tersebut belum dibuatkan no invoice.", MsgBoxStyle.Critical, "Warning!")
            Else
                txnoinvoice.ResetText()
                MsgBox("Transaksi tersebut tidak ditemukan di database, cek kembali no urut.", MsgBoxStyle.Critical, "Warning!")
            End If
        End If
    End Sub
End Class

