Public Class FormBirthdaySender

    Private Sub ButtonLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLoad.Click
        Try
            ' Ambil data pasien yang ulang tahun hari ini
            Dim sql As String = ""
            sql &= "SELECT Nama, NoHandphone, TglLahir, JenisKelamin "
            sql &= "FROM MasterPasien "
            sql &= "WHERE DAY(TglLahir) = DAY(GETDATE()) "
            sql &= "AND MONTH(TglLahir) = MONTH(GETDATE()) "
            sql &= "AND NoHandphone IS NOT NULL"

            Dim dt As DataTable = ReadSQL(sql)

            ' Tampilkan ke DataGridView
            dt.DefaultView.Sort = "Nama ASC"
            dgView.DataSource = dt

            ' Full width & auto height
            dgView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

            ' Header style
            dgView.EnableHeadersVisualStyles = False
            dgView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 144, 255)
            dgView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            dgView.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
            dgView.ColumnHeadersHeight = 35

            ' Row style
            dgView.DefaultCellStyle.Font = New Font("Segoe UI", 10)
            dgView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(100, 149, 237)
            dgView.DefaultCellStyle.SelectionForeColor = Color.White

            ' Alternating row biar zebra (lebih kebaca)
            dgView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245)

            ' Grid & border
            dgView.BorderStyle = BorderStyle.None
            dgView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal
            dgView.GridColor = Color.LightGray

            ' Behavior
            dgView.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            dgView.MultiSelect = False
            dgView.ReadOnly = True
            dgView.AllowUserToAddRows = False
            dgView.AllowUserToResizeRows = False

            ' Align kolom (opsional, tapi bagus)
            dgView.Columns("Nama").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            dgView.Columns("NoHandphone").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgView.Columns("TglLahir").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgView.Columns("JenisKelamin").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            ' Rename header biar lebih user-friendly
            If dgView.Columns.Contains("Nama") Then
                dgView.Columns("Nama").HeaderText = "Nama Pasien"
            End If

            If dgView.Columns.Contains("NoHandphone") Then
                dgView.Columns("NoHandphone").HeaderText = "Nomor HP"
            End If

            If dgView.Columns.Contains("TglLahir") Then
                dgView.Columns("TglLahir").HeaderText = "Tanggal Lahir"
            End If

            If dgView.Columns.Contains("JenisKelamin") Then
                dgView.Columns("JenisKelamin").HeaderText = "JK"
            End If

            ' Loop untuk insert ke WaBlast
            For Each row As DataRow In dt.Rows

                Dim nama As String = row("Nama").ToString()
                Dim nomor As String = row("NoHandphone").ToString().Trim()

                If nomor = "" Then Continue For

                nomor = nomor.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "")

                If nomor.StartsWith("0") Then
                    nomor = "62" & nomor.Substring(1)
                End If

                Dim cekSql As String = ""
                cekSql &= "SELECT COUNT(*) FROM WaBlast WHERE Nomor = '" & nomor & "' "
                cekSql &= "AND CreatedAt >= DATEADD(YEAR, -1, GETDATE())"

                Dim dtCheck As DataTable = ReadSQL(cekSql)

                If dtCheck.Rows.Count = 0 OrElse Convert.ToInt32(dtCheck.Rows(0)(0)) = 0 Then

                    Dim tglLahir As Date

                    If IsDBNull(row("TglLahir")) OrElse row("TglLahir") Is Nothing Then
                        tglLahir = New Date(1900, 1, 1)
                    Else
                        tglLahir = Convert.ToDateTime(row("TglLahir"))
                    End If

                    Dim jenisKelamin As String = ""

                    If IsDBNull(row("JenisKelamin")) OrElse row("JenisKelamin") Is Nothing Then
                        jenisKelamin = ""
                    Else
                        jenisKelamin = row("JenisKelamin").ToString()
                    End If

                    Dim insertSql As String = ""
                    insertSql &= "INSERT INTO WaBlast (Nama, Nomor, TanggalLahir, JenisKelamin, Status, CreatedAt, UpdatedAt) VALUES ("
                    insertSql &= "'" & nama.Replace("'", "''") & "', "
                    insertSql &= "'" & nomor & "', "
                    insertSql &= "'" & tglLahir & "', "
                    insertSql &= "'" & jenisKelamin & "', "
                    insertSql &= "'Pending', GETDATE(), GETDATE())"

                    WriteSQL(insertSql, 4)

                End If

            Next

            MsgBox("Load data ulang tahun selesai!", MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox("Terjadi kesalahan: " & ex.Message)
        End Try
    End Sub

    Private Function GetNamaKlinik() As String
        Try
            Dim lokasiPoli As String = "SELECT StrValue FROM MsConfig WHERE ConfigName = 'NoPoli'"
            Dim lokasi As DataTable = ReadSQL(lokasiPoli)

            If lokasi IsNot Nothing AndAlso lokasi.Rows.Count > 0 Then
                Dim row As DataRow = lokasi.Rows(0)
                Dim strValue As String = row("StrValue").ToString()

                Select Case strValue
                    Case "W001" : Return "Klinik Mitra Medicare Suci"
                    Case "W002" : Return "Klinik Mitra Medicare Manyar"
                    Case "W003" : Return "Klinik Mitra Medicare Driyorejo"
                    Case "L001" : Return "Klinik Mitra Medicare Dharmahusada"
                    Case "L002" : Return "Cahaya Diagnostic Centre Diponegoro"
                    Case "L003" : Return "Lumiera Luzella"
                    Case "L005" : Return "Inhouse Wings Surya"
                    Case "A002" : Return "Klinik Mitra Medicare Jatiuwuh"
                    Case "AD01" : Return "Klinik Mitra Medicare Boyolali"
                    Case "D002" : Return "Klinik Mitra Medicare Rancaekek"
                    Case "T001" : Return "Klinik Citra Medika Karawang"
                End Select
            End If

        Catch ex As Exception
            ' Optional: log error atau berikan default
            Return "Klinik Mitra Medicare"
        End Try

        Return "Klinik Mitra Medicare"
    End Function

    Private Function GetSapaan(ByVal usia As Integer, ByVal jenisKelamin As String) As String
        If usia < 18 Then
            Return "Kakak"
        Else
            If jenisKelamin.Trim().ToUpper() = "L" Then
                Return "Bapak"
            ElseIf jenisKelamin.Trim().ToUpper() = "P" Then
                Return "Ibu"
            Else
                Return ""
            End If
        End If
    End Function

    Private Sub ButtonKirim_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonKirim.Click
        Try
            Dim waStatus As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'whatsapp_klinik_status'")
            Dim waIP As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'whatsapp_klinik_ip'")

            If waStatus <> "Yes" Then Exit Sub

            ' Ambil data pending + data tambahan
            Dim sql As String = ""
            sql &= "SELECT ID, Nama, Nomor, TanggalLahir, JenisKelamin "
            sql &= "FROM WaBlast "
            sql &= "WHERE Status = 'Pending' "
            sql &= "ORDER BY ID ASC"

            Dim dt As DataTable = ReadSQL(sql)


            If dt.Rows.Count = 0 Then
                MsgBox("Tidak ada data yang perlu dikirim.", MsgBoxStyle.Information)
                Exit Sub
            End If

            Dim total As Integer = dt.Rows.Count
            Dim current As Integer = 0

            ProgressBar1.Minimum = 0
            ProgressBar1.Maximum = total
            ProgressBar1.Value = 0

            LabelNama.Text = "Memulai pengiriman..."
            Application.DoEvents()

            Dim rnd As New Random()
            Dim namaKlinik As String = GetNamaKlinik()

            For Each row As DataRow In dt.Rows
                current += 1

                Dim id As Integer = Convert.ToInt32(row("ID"))
                Dim nama As String = row("Nama").ToString()
                Dim nomor As String = row("Nomor").ToString().Trim()

                LabelNama.Text = nama & " (" & current & "/" & total & ")"
                Application.DoEvents()

                ' Update label
                If nomor = "" Then
                    ProgressBar1.Value = current
                    Continue For
                End If

                nomor = nomor.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "")

                ' Normalisasi nomor
                If nomor.StartsWith("0") Then
                    nomor = "62" & nomor.Substring(1)
                End If

                ' Ambil data tambahan
                Dim tglLahir As Date = If(IsDBNull(row("TanggalLahir")), Now, Convert.ToDateTime(row("TanggalLahir")))
                Dim jenisKelamin As String = row("JenisKelamin").ToString()

                Dim usia As Integer = DateDiff(DateInterval.Year, tglLahir, Now)
                If Now < tglLahir.AddYears(usia) Then usia -= 1

                Dim emojiUsia As String = If(usia < 18, "🎉", "🎂")
                Dim sapaan As String = GetSapaan(usia, jenisKelamin)

                Dim pesan As String = _
                    emojiUsia & " *Selamat Ulang Tahun* " & emojiUsia & vbCrLf & vbCrLf & _
                    sapaan & " *" & nama & "*." & vbCrLf & vbCrLf & _
                    "Di hari yang spesial ini, kami dari *" & namaKlinik & "* ingin mengucapkan selamat ulang tahun." & vbCrLf & _
                    "Semoga selalu diberikan kesehatan, umur yang panjang, serta kebahagiaan dalam setiap aktivitas sehari-hari." & vbCrLf & vbCrLf & _
                    "Terima kasih telah mempercayakan perawatan kesehatan Anda kepada kami." & vbCrLf & _
                    "Merupakan suatu kehormatan bagi kami dapat mendampingi Anda dalam menjaga kesehatan." & vbCrLf & vbCrLf & _
                    "Semoga hari ini " & sapaan & " dipenuhi senyum kebahagiaan dan kebaikan yang berlipat 🤍" & vbCrLf & _
                    "Salam sehat selalu." & vbCrLf & vbCrLf & _
                    "Hormat kami," & vbCrLf & _
                    "*" & namaKlinik & "*"

                Dim json As String = SetParameterWhatsappText(nomor, pesan)
                Dim urlSend As String = "http://" & waIP & ":4444/send"

                Try
                    Dim isSuccess As Boolean = SendDataWhatsappHBD(json, urlSend)

                    Dim status As String = If(isSuccess, "Terkirim", "Gagal")
                    Dim sqlUpdate As String = "UPDATE WaBlast SET Status='" & status & "', UpdatedAt=GETDATE() WHERE ID=" & id
                    WriteSQL(sqlUpdate, 4)

                Catch exLoop As Exception
                    Dim sqlUpdate As String = "UPDATE WaBlast SET Status='Gagal', UpdatedAt=GETDATE() WHERE ID=" & id
                    WriteSQL(sqlUpdate, 4)
                End Try

                ' Update progress bar
                ProgressBar1.Value = current
                Application.DoEvents()

                ' Delay random 15–60 detik
                Dim delay As Integer = rnd.Next(15000, 60000)
                System.Threading.Thread.Sleep(delay)

                If current Mod 10 = 0 Then
                    Dim cooldown As Integer = rnd.Next(180000, 600000) '3-10 menit
                    LabelNama.Text = "Cooldown sementara..."
                    Application.DoEvents()

                    System.Threading.Thread.Sleep(cooldown)
                End If
            Next

            MsgBox("Proses pengiriman selesai!", MsgBoxStyle.Information)

        Catch ex As Exception
            MsgBox("Terjadi kesalahan: " & ex.Message)
        End Try
    End Sub

    Public Function SetParameterWhatsappText(ByVal nomor As String, ByVal pesan As String) As String
        Dim cleanPesan As String = pesan.Replace(vbCrLf, "\n").Replace("""", "\""")

        ' Buat JSON manual
        Dim json As String = "{" & _
            """number"": """ & nomor & """," & _
            """message"": """ & cleanPesan & """" & _
        "}"

        Return json
    End Function
End Class