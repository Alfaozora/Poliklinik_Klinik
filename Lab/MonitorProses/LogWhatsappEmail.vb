Public Class LogWhatsappEmail
    Dim Ttcmh As New TLcon
    Dim thread As System.Threading.Thread

    Private Sub SetClear()
        dtprocess.Value = DateAndTime.Now
        cmbjenissending.SelectedIndex = 0
        GridDisplay(True)
    End Sub

    Private Sub GridDisplay(ByVal setwidth As Boolean)
        Dim Thasilawal As Date = dtprocess.Value
        Dim Tawal As Date = DateSerial(Thasilawal.Year, Thasilawal.Month, Thasilawal.Day)

        Dim Tjenissending As String = ""

        If cmbjenissending.SelectedIndex = 1 Then
            Tjenissending = " and a.SendingJenis = 'Whatsapp'"
        ElseIf cmbjenissending.SelectedIndex = 2 Then
            Tjenissending = " and a.SendingJenis = 'Email'"
        End If

        Dim Trow As DataTable = ReadSQL("select a.SendingJenis, a.SendingTujuan, a.SendingDate, a.SendingBy, a.JenisSending, a.NoUrut, b.TglLab, c.Nama " & _
                                        " from LogSendingWhatsappEmail a " & _
                                        " left join TransaksiLab b on a.NoUrut=b.NoUrut " & _
                                        " left join MasterPasien c on b.IDInternet = c.NoRekamMedis " & _
                                        " where CONVERT(date, b.TglLab) = '" & Tawal & "' " & Tjenissending & "")

        Dim Ttemp As New DataTable
        insertRowToTbls(Ttemp, "Typstring", "No Transaksi")
        insertRowToTbls(Ttemp, "Typstring", "Nama")
        insertRowToTbls(Ttemp, "Typstring", "Tgl Lab")
        insertRowToTbls(Ttemp, "Typstring", "Jenis")
        insertRowToTbls(Ttemp, "Typstring", "Tujuan")
        insertRowToTbls(Ttemp, "Typstring", "Tgl Sending")
        insertRowToTbls(Ttemp, "Typstring", "SendingBy")
        insertRowToTbls(Ttemp, "Typstring", "Jenis Tujuan")

        For i As Integer = 0 To Trow.Rows.Count - 1
            Dim Rnew As DataRow = Ttemp.NewRow
            Rnew("No Transaksi") = Trow(i)("NoUrut")
            Rnew("Nama") = Trow(i)("Nama")
            Rnew("Tgl Lab") = Format(Trow(i)("TglLab"), "dd-MMM-yyyy")
            Rnew("Jenis") = Trow(i)("SendingJenis")
            Rnew("Tujuan") = Trow(i)("SendingTujuan")
            Rnew("Tgl Sending") = Format(Trow(i)("SendingDate"), "yyyy-MM-dd HH:mm:ss")
            Rnew("SendingBy") = Trow(i)("SendingBy")
            Rnew("Jenis Tujuan") = Trow(i)("JenisSending")
            Ttemp.Rows.Add(Rnew)
        Next

        For Each Tcols As DataColumn In Ttemp.Columns
            Tcols.ReadOnly = True
        Next

        GridControl1.DataSource = Ttemp

        If setwidth = True Then
            GridView1.Columns("Tujuan").Width = 150
            GridView1.Columns("SendingBy").Width = 75
            GridView1.Columns("Nama").Width = 150
            GridView1.Columns("Tgl Lab").Width = 75
            GridView1.Columns("Jenis").Width = 75
            GridView1.Columns("No Transaksi").Width = 100
        End If
    End Sub

    Private Sub SetConnection()
        Ttcmh.Tid = "root"
        Ttcmh.Tip = ReadSQLNIK("select StrValue from MsConfig where ConfigName='Twebid'")
        Ttcmh.Tdb = "db_tracking"
        Ttcmh.Tpass = Strings.Replace(ReadSQLNIK("select StrValue from MsConfig where ConfigName='Twebpass'"), "|", "")
    End Sub

    Private Sub LogWhatsappEmail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        Me.MdiParent = PoliKlinik
        Me.Size = New System.Drawing.Size(1000, 503)
        SetClear()
        SetConnection()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        GridDisplay(False)
    End Sub
End Class