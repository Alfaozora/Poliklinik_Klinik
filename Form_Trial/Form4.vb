Imports DevExpress.XtraNavBar
Imports Microsoft.Win32
Imports Newtonsoft.Json.Linq

Public Class Form4
    Private userInput As String = PoliKlinik.Lbluser.Text ' User input program

    Private Sub NavBarItem1_LinkClicked(ByVal sender As System.Object, ByVal e As DevExpress.XtraNavBar.NavBarLinkEventArgs) Handles NavBarItem1.LinkClicked
        ' Hapus kontrol yang ada pada Panel atau Container yang Anda gunakan
        Panel1.Controls.Clear()

        ' Buat instance dari UserControl yang ingin Anda tampilkan
        Dim myUserControl As New UserControl1

        ' Tambahkan UserControl ke Panel atau Container
        myUserControl.Dock = DockStyle.Fill
        Panel1.Controls.Add(myUserControl)
    End Sub

    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        '# Set data dictionary yang akan dikirim ke form popup
        Dim dataDictionary As New Dictionary(Of String, Object)()

        dataDictionary.Add("No Rekam Medis", "Z001-0000011")

        DialogBoxTambahAlergi.DataDictionary = dataDictionary
        DialogBoxTambahAlergi.ShowDialog()

        LoadDataAlergi(GridControlAlergi, GridViewAlergi)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'Process.Start("https://dvlp.bpjs-kesehatan.go.id/ihs/historyfaskes?token=f80896d3-f030-4af4-a441-f547191552ca")
        OpenInNewChromeWindow("https://dvlp.bpjs-kesehatan.go.id/ihs/historyfaskes?token=95c4a047-3675-428a-8a86-e9fca066c5c5")
    End Sub

    'Private Sub OpenInDefaultBrowser(ByVal url As String)
    '    Try
    '        Process.Start(url)
    '    Catch ex As Exception
    '        MessageBox.Show("Gagal membuka browser. " & ex.Message)
    '    End Try
    'End Sub

    'Private Sub OpenInDefaultBrowser(ByVal url As String)
    '    Try
    '        Dim psi As New ProcessStartInfo()
    '        psi.FileName = url
    '        psi.UseShellExecute = True
    '        Process.Start(psi)
    '    Catch ex As Exception
    '        MessageBox.Show("Gagal membuka browser. " & ex.Message)
    '    End Try
    'End Sub

    'Private Sub OpenInNewChromeWindow(ByVal url As String)
    '    Try
    '        Dim chromePath As String = "C:\Program Files\Google\Chrome\Application\chrome.exe"
    '        Dim psi As New ProcessStartInfo()
    '        psi.FileName = chromePath
    '        psi.Arguments = "--new-window """ & url & """"
    '        psi.UseShellExecute = True
    '        Process.Start(psi)
    '    Catch ex As Exception
    '        MessageBox.Show("Gagal membuka browser. " & ex.Message)
    '    End Try
    'End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        LoadDataAlergi(GridControlAlergi, GridViewAlergi)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        HapusDataAlergi("Z001-0000011", GridViewAlergi)
    End Sub

    Private Sub LoadDataAlergi(ByVal dataGridView As DevExpress.XtraGrid.GridControl, ByVal gridView As DevExpress.XtraGrid.Views.Grid.GridView)
        Dim tblAlergi As DataTable = New DataTable

        tblAlergi = ReadSQL("SELECT AlergiJenis, AlergiNama, Keterangan FROM MasterPasienAlergi WHERE NoRekamMedis = 'Z001-0000011' AND DeletedDate IS NULL")

        dataGridView.DataSource = tblAlergi

        ' Tambahkan kolom dengan tombol hapus
        AddDeleteButtonColumn(gridView)
    End Sub

    Private Sub AddDeleteButtonColumn(ByVal gridView As DevExpress.XtraGrid.Views.Grid.GridView)
        ' Buat RepositoryItemButtonEdit untuk tombol hapus
        Dim deleteButton As New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
        deleteButton.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        deleteButton.Buttons(0).Caption = "Hapus"
        deleteButton.Buttons(0).Kind = DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph

        ' Tambahkan RepositoryItemButtonEdit ke GridControl RepositoryItems
        gridView.GridControl.RepositoryItems.Add(deleteButton)

        ' Buat kolom baru
        Dim deleteColumn As New DevExpress.XtraGrid.Columns.GridColumn
        deleteColumn.Caption = "Hapus"
        deleteColumn.FieldName = "Hapus"
        deleteColumn.UnboundType = DevExpress.Data.UnboundColumnType.String ' Kolom tidak terikat
        deleteColumn.Visible = True
        deleteColumn.ColumnEdit = deleteButton

        ' Tambahkan kolom ke gridView
        gridView.Columns.Add(deleteColumn)
    End Sub

    Private Sub HapusDataAlergi(ByVal noRekamMedis As String, ByVal gridView As DevExpress.XtraGrid.Views.Grid.GridView)
        ' Dapatkan baris yang dipilih
        Dim selectedRow As Integer = gridView.FocusedRowHandle

        If selectedRow >= 0 Then
            ' Dapatkan nilai ID atau kolom utama dari baris yang dipilih
            Dim jenisAlergi As String = gridView.GetRowCellValue(selectedRow, "AlergiJenis")
            Dim namaAlergi As String = gridView.GetRowCellValue(selectedRow, "AlergiNama")

            If MessageBox.Show("Apakah Anda yakin ingin menghapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim parameterUpdate As String = ""

                ' Hapus Data MasterPasienAlergi
                parameterUpdate = "DeletedBy = '" & userInput & "'," & _
                                  "DeletedDate = GETDATE()"

                WriteSQL("UPDATE MasterPasienAlergi SET " & parameterUpdate & " WHERE NoRekamMedis = '" & noRekamMedis & "' AND AlergiJenis = '" & jenisAlergi & "' AND AlergiNama = '" & namaAlergi & "' AND DeletedDate IS NULL", 4)

                MsgBox("Data Alergi Berhasil Dihapus.", MsgBoxStyle.Information, "Success")

                LoadDataAlergi(GridControlAlergi, GridViewAlergi)
            End If
        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Try
            SetRekamMedisBridgingIcare(TextBoxNoKartu.Text)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Warning!")
        End Try
    End Sub

    Private Sub SetRekamMedisBridgingIcare(ByVal noKartuPasien As String)
        Dim endpointBridging As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'icare_base_url'")
        Dim payloadBridging As String = ""

        payloadBridging = "{" & _
                                """param"" : """ & noKartuPasien & """" & _
                          "}"

        Dim jsonString As String = ""
        jsonString = GenerateICareUrl(payloadBridging, endpointBridging, "POST")

        ' Parsing JSON response
        Dim jsonObj As JObject = JObject.Parse(jsonString)

        ' Mengambil nilai metaData.code
        Dim code As Integer = CInt(jsonObj("metaData")("code"))

        ' Jika kode 200, sukses
        If code = 200 Then
            ' Mengambil nilai dari response.url
            Dim url As String = jsonObj("response")("url").ToString()

            ' Membuka di chrome
            OpenInNewChromeWindow(url)
        Else
            ' Mengambil pesan error
            Dim message As String = jsonObj("metaData")("message").ToString()

            ' Menampilkan alert jika terjadi error
            MsgBox("Error: " & message, MsgBoxStyle.Critical, "API Error")
        End If
    End Sub

    'Private Sub WhatsappToApotek()
    '    Try
    '        Dim NoWhatsapp As String = "6285655784251"
    '        Dim TIP_Whatsapp As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='TIP_Whatsapp'")
    '        Dim TxPDF As String = ""
    '        Dim filename As String = ""
    '        Dim parameter As String = ""
    '        Dim uri As String = ""
    '        Dim uri_message As String = ""
    '        Dim StatsSending As String = ""

    '        Dim message_whatsapp As String = ""

    '        ' Ganti sesuai kebutuhan
    '        message_whatsapp = "Sending Berhasil."

    '        parameter = "{" & _
    '          """number"" : """ & NoWhatsapp & """," & _
    '          """mime"" : ""application/pdf""," & _
    '          """src"" : """"," & _
    '          """filename"" : """"," & _
    '          """caption"" : """"," & _
    '          """thumbnail"" : """"," & _
    '          """message"" : """ & message_whatsapp & """" & _
    '         "}"

    '        uri_message = "http://" & TIP_Whatsapp & ":4444/send"

    '        SendDataWhatsapp(parameter, uri_message)
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim MessageWhatsapp As String
        MessageWhatsapp = TextBoxMessage.Text.Replace(vbCrLf, "\n").Replace(vbLf, "\n").Replace(vbCr, "\n")

        Dim NoWhatsapp As String = "6282131460306"
        If Strings.Left(NoWhatsapp, 2) = "08" Then NoWhatsapp = "62" & NoWhatsapp.Substring(1, NoWhatsapp.Length - 1)
        Dim TIP_Whatsapp = ReadSQLNIK("select StrValue from MsConfig where ConfigName='TIP_Whatsapp'")
        Dim TxPDF As String = Convert.ToBase64String(System.IO.File.ReadAllBytes("FileDownload\Hasil_Online\02_92d5b347.jpg"))
        Dim filename As String = "Test_Hasil_Laboratorium.jpg"
        Dim parameter As String = KirimWhatsApp(MessageWhatsapp, NoWhatsapp, TxPDF, filename, "Yes")

        Dim uri As String = "http://" & TIP_Whatsapp & ":4444/send-image"
        Dim StatsSending As String = ""

        StatsSending = SendDataWhatsapp(parameter, uri)
        StatsSending = SendDataWhatsapp(parameter, uri)
        StatsSending = SendDataWhatsapp(parameter, uri)
        StatsSending = SendDataWhatsapp(parameter, uri)
        StatsSending = SendDataWhatsapp(parameter, uri)

        If StatsSending = "Success" Then
            MsgBox("Berhasil mengirim Whatsapp ke " & NoWhatsapp.Trim & ".", MsgBoxStyle.Information, "Success!")
        ElseIf StatsSending = "Nothing" Then
            MsgBox("Gagal Mengirim Whatsapp ke " & NoWhatsapp.Trim & ". Cek koneksi jaringan atau hubungi IT untuk restart server Whatsapp.", MsgBoxStyle.Exclamation, "Warning!")
        End If
    End Sub

    Function KirimWhatsApp(ByVal MessageWhatsapp As String, ByVal NoWhatsapp As String, ByVal TxPDF As String, ByVal filename As String, ByVal message As String) As String
        Try
            Dim message_whatsapp As String = ""
            Dim parameter As String = ""

            If message = "Yes" Then
                message_whatsapp = "Kepada Yth.\n" & _
                  "Customer Cahaya Diagnostic Centre\n\n" & _
                  "Kami mengucapkan terima kasih atas kepercayaan Bapak/Ibu/Saudara/i sudah melakukan pemeriksaan di Laboratorium Cahaya Diagnostic Centre. Berikut ini kami lampirkan hasil pemeriksaan laboratorium anda.\n\n" & _
                  "Silahkan menghubungi kami di nomor  081332209900 (WA/Phone) untuk info lain.\n\n" & _
                  "Best regards,\n\n" & _
                  "Laboratorium Cahaya Diagnostic Centre.\n\n" & _
                  "----- Pesan ini adalah pesan otomatis, mohon agar tidak membalas -----"
            ElseIf message = "No" Then
                message_whatsapp = ""
            End If

            parameter = "{" & _
              """number"" : """ & NoWhatsapp & """," & _
              """mime"" : ""application/pdf""," & _
              """src"" : """ & TxPDF & """," & _
              """filename"" : """ & filename & """," & _
              """caption"" : """ & MessageWhatsapp & """," & _
              """thumbnail"" : """"," & _
              """message"" : """ & message_whatsapp & """" & _
             "}"

            Return parameter
        Catch ex As Exception
            Return "Nothing"
        End Try
    End Function
End Class