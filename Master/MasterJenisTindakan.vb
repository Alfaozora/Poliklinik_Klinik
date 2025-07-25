Public Class MasterJenisTindakan

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        txjenisid.ResetText()
        txjenistindakan.ResetText()
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub MasterJenisTindakan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        NewToolStripMenuItem.PerformClick()
    End Sub

    Private Sub buttransdisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttransdisplay.Click
        NewToolStripMenuItem.PerformClick()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SaveToolStripMenuItem.PerformClick()
    End Sub

    Function Checking() As Boolean
        If txjenisid.Text = "" Then
            'new 
            If txjenistindakan.Text = "" Then
                MsgBox("Isi Jenis Tindakan.")
                Return False
            Else
                If CheckSQL("select * from MasterJenisTindakan where JenisTindakan='" & txjenistindakan.Text & "'") = True Then
                    MsgBox("Data sama dengan yang telah ada. Ganti Jenis Tindakan tersebut.")
                    Return False
                End If
            End If
        Else
            'update
            'sementara tanpa update. Supaya g salah2... 
            MsgBox("Data tidak bisa di-update. Untuk sementara")
            Return False
        End If

        Return True
    End Function

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        If Checking = True Then
            If txjenisid.Text = "" Then
                If MsgBox("Yakin untuk menambah Jenis Tersebut ? ", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                    WriteSQL("insert into MasterJenisTindakan(JenisTindakan,UrutanJenisID) values('" & txjenistindakan.Text & "','9999')", 1)
                    If MsgBox("Set Clear New ?", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then
                        NewToolStripMenuItem.PerformClick()
                    Else
                        txjenisid.Text = ReadSQLNIK("select JenisID from MasterJenisTindakan where JenisTindakan='" & txjenistindakan.Text & "'")
                    End If
                Else
                    MsgBox("Abort Save")
                End If
            End If
        End If
    End Sub

    Private Sub butfindjenis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butfindjenis.Click
        Find.Show()
        Find.Query("select * from MasterJenisTindakan ", " order by UrutanJenisID", "MasterJenisTindakan", 2)
    End Sub
End Class