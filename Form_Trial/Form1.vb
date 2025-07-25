Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports System.IO
Imports System.Text
Imports System.Net.Mail
Imports System.Net
Imports System.Net.Sockets
Imports System.Text.RegularExpressions
Imports System.Drawing
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraPrinting.Drawing
Imports System.Drawing.Text
Imports System
Imports System.Diagnostics
Imports Newtonsoft.Json.Linq
Imports Newtonsoft.Json.Serialization
Imports System.Globalization
Imports Newtonsoft.Json

Public Class Form1
    Dim Fcon As New TLcon
    Private FontFile As String = IO.Path.Combine(Application.StartupPath, "code128.ttf")
    Private pfc As New PrivateFontCollection
    Dim Ttmesin As TLcon
    Public mhs As Mahasiswa

    Dim TtOL As TLcon

    Public Class container
        Public status As String
        Public message As String
        Public data As JSON_result

        Public Class JSON_result
            Public id As String
            Public nama As String
            Public email As String

            Public image As String
            Public title As String
            Public content As String
            Public created_at As String
            Public updated_at As String
        End Class

        Public Class detail
            Public id As String
            Public title As String
            Public content As String
        End Class
    End Class

    Public Class setOtentikasi
        Public messagge As String
        Public data As JSON_result
        Public acces_token As String

        Public Class JSON_result
            Public id As String
            Public email As String
            Public password As String
        End Class
    End Class

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        pfc.Dispose()
    End Sub

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    Label1.Text = TextBox1.Text
    '    Using bm As New Bitmap(Label1.Width, Label1.Height)
    '        Label1.DrawToBitmap(bm, New Rectangle(0, 0, Label1.Width, Label1.Height))
    '        If PictureBox1.Image IsNot Nothing Then PictureBox1.Image.Dispose()
    '        PictureBox1.Image = New Bitmap(bm)
    '    End Using
    'End Sub

    Function CreateTable() As DataTable
        Dim Thasil As New DataTable

        insertRowToTbls(Thasil, "Typstring", "grid1")
        insertRowToTbls(Thasil, "Typstring", "grid2")

        For Each Tcol As DataColumn In Thasil.Columns
            Tcol.ReadOnly = True
        Next

        Return Thasil
    End Function

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim Tdata As DataTable = New DataTable
        'Tdata = CreateTable()
        'Dim Tnew As DataRow = Tdata.NewRow
        'Tnew("grid1") = "11"
        'Tdata.Rows.Add(Tnew)

        'gridlab.DataSource = Tdata

        Conn()
        pfc.AddFontFile(FontFile)
        Label1.Text = ""
        Label1.Font = New Font(pfc.Families(0), 36, FontStyle.Regular)
        Label1.Visible = False
        PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize

        'Dim str As String = "SELECT CONVERT(DATE, t2.tglpoli) AS 'Tgl Transaksi', Count(t2.nourut) AS 'Jumlah Transaksi' " & _
        '                    "FROM(SELECT a.nourut, CONVERT(DATE, a.tglpoli) AS TglPoli, a.updateby, c.statusfeetindakan, c.jenisdokter, c.jenistindakan, a.deleted " & _
        '                    "FROM transaksipoli a " & _
        '                    "LEFT JOIN transaksipolidetail b ON a.transpoliid=b.transpoliid " & _
        '                    "LEFT JOIN mastertindakan c ON b.tindakanid=c.tindakanid " & _
        '                    "LEFT JOIN transaksipolibayarawal d ON a.transpoliid=d.transpoliid " & _
        '                    "WHERE((d.jenisbayar<>'TAGIHAN' AND d.jenisbayar IS NOT NULL)OR d.nojenisbayar LIKE '%TRANSFER%')AND(b.groupbayar IS NULL OR b.groupbayar='') " & _
        '                    "UNION " & _
        '                    "SELECT a.nourut, CONVERT(DATE, a.tglpoli) AS TglPoli, a.updateby, c.statusfeetindakan, c.jenisdokter, c.jenistindakan, a.deleted " & _
        '                    "FROM transaksipoli a " & _
        '                    "LEFT JOIN transaksipolidetail b ON a.transpoliid=b.transpoliid " & _
        '                    "LEFT JOIN mastertindakan c ON b.tindakanid=c.tindakanid " & _
        '                    "LEFT JOIN transaksipolibayar d ON a.transpoliid=d.transpoliid AND b.groupbayar=d.groupbayar " & _
        '                    "WHERE d.groupbayar IS NOT NULL AND(d.jenisbayar<>'TAGIHAN' OR d.nojenisbayar LIKE '%TRANSFER%')) AS t2 " & _
        '                    "WHERE t2.updateby LIKE '%DR ANASTASHA%' AND t2.statusfeetindakan='1' AND t2.jenisdokter LIKE '%Dokter%' AND t2.jenistindakan LIKE '%Konsul%' AND t2.deleted=0 AND(t2.tglpoli BETWEEN '6/2/2022' AND '6/2/2022') " & _
        '                    "GROUP BY CONVERT(DATE, t2.tglpoli) "

        'MsgBox(str)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential("_mainaccount@cahayadiagnosticcentre.com", "W?gs?=_x4nS6qd")
            Smtp_Server.Port = 26
            Smtp_Server.EnableSsl = False
            Smtp_Server.Host = "mail.cahayadiagnosticcentre.com"

            e_mail = New MailMessage()
            e_mail.From = New MailAddress("noreply@cahayadiagnosticcentre.com")
            e_mail.To.Add("mitramedicare.it@gmail.com, danifwahyudi@gmail.com")
            e_mail.Subject = "IT Cahaya"
            e_mail.IsBodyHtml = False
            e_mail.Body = "Hi!" & vbCr & vbLf + "Spire.Email for .NET is a professional .NET Email library specially designed for developers to create, read and manipulate emails on any .NET (C#, VB.NET, ASP.NET) platform."

            Smtp_Server.Send(e_mail)

            MsgBox("Success")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



        'Try
        '    Dim Smtp_Server As New SmtpClient
        '    Dim e_mail As New MailMessage()
        '    Smtp_Server.UseDefaultCredentials = False
        '    Smtp_Server.Credentials = New Net.NetworkCredential("mitramedicare.it@gmail.com", "MM6ENU1n3")
        '    Smtp_Server.Port = 587
        '    Smtp_Server.EnableSsl = True
        '    Smtp_Server.Host = "smtp.gmail.com"

        '    e_mail = New MailMessage()
        '    e_mail.From = New MailAddress("mitramedicare.it@gmail.com")
        '    e_mail.To.Add("danifwahyudi@gmail.com")
        '    e_mail.Subject = "IT Cahaya"
        '    e_mail.IsBodyHtml = False
        '    e_mail.Body = "Hi!" & vbCr & vbLf + "Spire.Email for .NET is a professional .NET Email library specially designed for developers to create, read and manipulate emails on any .NET (C#, VB.NET, ASP.NET) platform."

        '    Smtp_Server.Send(e_mail)

        '    MsgBox("Success")
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try


        Try
            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            Smtp_Server.UseDefaultCredentials = False
            Smtp_Server.Credentials = New Net.NetworkCredential("info@cahayamedika.co.id", "cahayamedika2020!")
            Smtp_Server.Port = 587
            Smtp_Server.EnableSsl = True
            Smtp_Server.Host = "smtp.gmail.com"

            e_mail = New MailMessage()
            e_mail.From = New MailAddress("info@cahayamedika.co.id")
            e_mail.To.Add("danifwahyudi@gmail.com")
            e_mail.Subject = "IT Cahaya"
            e_mail.IsBodyHtml = False
            e_mail.Body = "Hi!" & vbCr & vbLf + "Spire.Email for .NET is a professional .NET Email library specially designed for developers to create, read and manipulate emails on any .NET (C#, VB.NET, ASP.NET) platform."

            Smtp_Server.Send(e_mail)

            MsgBox("Success")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim filepath As String = "FileDownload\20201105L00027_HasilLab.pdf"
        If File.Exists(filepath) Then
            MessageBox.Show("File Exist")
        Else
            MessageBox.Show("File Not Exist")
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        My.Computer.FileSystem.DeleteFile("FileDownload\20201105L00027_HasilLab.pdf")
    End Sub

    Function validateEmail(ByVal emailAddress) As Boolean
        Dim email As New Regex("([\w-+]+(?:\.[\w-+]+)*@(?:[\w-]+\.)+[a-zA-Z]{2,7})")
        If email.IsMatch(emailAddress) Then
            Return True
        Else
            Return False
        End If
    End Function

    Function validateNoWhatsapp(ByVal NoWhatsapp) As Boolean
        If NoWhatsapp.Length < 9 Then
            MsgBox("No Whatsapp yang dimasukkan tidak valid, pastikan jumlah digit no whatsapp yang dimasukkan.", MsgBoxStyle.Critical, "Warning")
            Return False
        ElseIf NoWhatsapp.Length > 13 Then
            MsgBox("No Whatsapp yang dimasukkan tidak valid, pastikan jumlah digit no whatsapp yang dimasukkan.", MsgBoxStyle.Critical, "Warning")
            Return False
        End If

        'Cek Awalan Format No Whatsapp
        If Strings.Left(NoWhatsapp, 2) = "08" Or Strings.Left(NoWhatsapp, 3) = "628" Then
            Return True
        Else
            MsgBox("No Whatsapp yang dimasukkan tidak valid, pastikan no whatsapp bukan telepon rumah atau kantor.", MsgBoxStyle.Critical, "Warning")
            Return False
        End If

        Return True
    End Function

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        If validateEmail(txemail.Text) = True Then
            MsgBox("Bener.")
        Else
            MsgBox("Salah.")
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        'If MsgBox("Apakah data berikut sudah benar? " & vbCr & vbLf & vbCr & vbLf + "" & _
        '          "Nama : Muhardanif Tri Wahyudi" & vbCr & vbLf + "" & _
        '          "Alamat : Sidoarjo" & vbCr & vbLf + "" & _
        '          "Tanggal Lahir : 23 Juni 1996" & vbCr & vbLf + "" & _
        '          "Perusahaan : PT CAHAYA MEDIKA HEALTHCARE", MsgBoxStyle.YesNo, "Verifikasi.") = MsgBoxResult.Yes Then
        'End If
        Dim array(2) As String
        array(0) = "Cieh"
        MsgBox(array(0))
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim Tinput As String = InputBox("Jumlah Barcode yang di cetak : ", "Print Barcode", 2)
        If IsNumeric(Tinput) = False Then
            MsgBox("Masukkan Jumlah Barcode yang diprint berupa angka")
        Else
            Report = New XtraReport
            Report = XtraReport.FromFile(Application.StartupPath + "\reports\TestingPrintAlamat.repx", True)
            For i As Integer = 0 To CInt(Tinput) - 1
                Report.Print()
            Next
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        'Dim base64Decoded As String = "base64 encoded string"
        'Dim base64Encoded As String
        'Dim data As Byte()
        'data = System.Text.ASCIIEncoding.ASCII.GetBytes(base64Decoded)
        'base64Encoded = System.Convert.ToBase64String(data)
        'MsgBox(base64Encoded)

        Dim tx As String = Convert.ToBase64String(System.IO.File.ReadAllBytes("FileDownload\cie.pdf"))
        MsgBox(tx)
        'Dim b As Byte() = Convert.FromBase64String(pdfByte)

    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        If validateNoWhatsapp(TextBox1.Text) = True Then
            MsgBox("Bener.")
        Else
            MsgBox("Salah.")
        End If
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox1.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        MsgBox("Cieeeee")
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Button9.PerformClick()
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        SetConnection()

        Dim RangeUmur As String = ""
        Dim T1 As Double = 0
        Dim T2 As Double = 0
        Dim tbls As DataTable = ReadThemysql("SELECT a.plt_grafik, a.rbc_grafik, a.diff_grafik FROM sysmex a WHERE a.rnoreg='001210201800016'", Fcon)
        Dim tbls_grafik As DataTable = ReadThemysql("SELECT * FROM fsysmex2 where seq_no = '20210219100210'", Fcon)
        Dim umur As Integer = ReadSQLNIK("select DATEDIFF(YYYY, TglLahir, GETDATE()) as Umur from MasterPasien where Nama like '%Muhardanif%'")
        Dim sex As String = ReadSQLNIK("select JenisKelamin from MasterPasien where Nama like '%Muhardanif%'")
        Dim Tnilairujukan As New DataTable
        Dim Thasil As New DataTable
        Dim Tdata As New DataTable
        Dim TrowLab As DataRow = tbls.Rows(0)

        For Each TrowData As DataRow In tbls_grafik.Rows
            insertRowToTbls(Thasil, "Typstring", "" & TrowData("rnmjasa") & "")
            insertRowToTbls(Thasil, "Typstring", "NilaiRujukan_" & TrowData("rnmjasa") & "")
        Next

        Dim Tnew As DataRow = Thasil.NewRow
        For Each TrowData As DataRow In tbls_grafik.Rows
            Tnew("" & TrowData("rnmjasa") & "") = TrowData("hasil")

            Tnilairujukan = ReadSQL("select * from MasterNilaiRujukanMesin where KodeMesin = '" & TrowData("rnmjasa").ToString.Trim & "'")
            For Each Tnilairujukanrow As DataRow In Tnilairujukan.Rows
                RangeUmur = Tnilairujukanrow("RangeUmur").ToString.Trim
                If RangeUmur.Contains("<") = True Then
                    RangeUmur = Trim(Strings.Replace(Strings.Replace(RangeUmur, "<", ""), "=", ""))
                    If CDbl(umur) < CDbl(RangeUmur) Then
                        If sex = "L" Then
                            Tnew("NilaiRujukan_" & TrowData("rnmjasa") & "") = Tnilairujukanrow("Pria")
                        ElseIf sex = "P" Then
                            Tnew("NilaiRujukan_" & TrowData("rnmjasa") & "") = Tnilairujukanrow("Wanita")
                        End If
                    End If
                ElseIf RangeUmur.Contains(">") = True Then
                    RangeUmur = Trim(Strings.Replace(Strings.Replace(RangeUmur, ">", ""), "=", ""))
                    If CDbl(umur) > CDbl(RangeUmur) Then
                        If sex = "L" Then
                            Tnew("NilaiRujukan_" & TrowData("rnmjasa") & "") = Tnilairujukanrow("Pria")
                        ElseIf sex = "P" Then
                            Tnew("NilaiRujukan_" & TrowData("rnmjasa") & "") = Tnilairujukanrow("Wanita")
                        End If
                    End If
                ElseIf RangeUmur.Contains("-") = True Then
                    Dim Tsplit() As String = RangeUmur.ToString.Split("-")
                    T1 = Trim(Tsplit(0))
                    T2 = Trim(Tsplit(1))

                    If CDbl(umur) > T1 And CDbl(umur) < T2 Then
                        If sex = "L" Then
                            Tnew("NilaiRujukan_" & TrowData("rnmjasa") & "") = Tnilairujukanrow("Pria")
                        ElseIf sex = "P" Then
                            Tnew("NilaiRujukan_" & TrowData("rnmjasa") & "") = Tnilairujukanrow("Wanita")
                        End If
                    End If
                End If
            Next
        Next
        Thasil.Rows.Add(Tnew)

        Report = New XtraReport
        Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\GrafikHematologiLengkap.repx", True)
        Report.DataSource = Thasil
        Report.Bands(BandKind.Detail).Controls.Add(CreateXRPictureBox(TrowLab("plt_grafik"), 567, 65, 150, 175))
        Report.Bands(BandKind.Detail).Controls.Add(CreateXRPictureBox(TrowLab("rbc_grafik"), 567, 265, 150, 175))
        Report.Bands(BandKind.Detail).Controls.Add(CreateXRPictureBox(TrowLab("diff_grafik"), 567, 465, 150, 175))
        'Report.RunDesigner()
        Report.ShowPreview()
    End Sub

    Function CreateXRPictureBox(ByVal Tid As Array, ByVal LocX As Integer, ByVal LocY As Integer, ByVal SizeX As Integer, ByVal SizeY As Integer) As XRPictureBox
        Dim Byted() As Byte = Tid
        Dim Streamed As New System.IO.MemoryStream(Byted)
        PictureBox1.Image = Image.FromStream(Streamed)

        Dim PictureBox As XRPictureBox = New XRPictureBox()
        PictureBox.Image = Image.FromStream(Streamed)
        PictureBox.Location = New Point(LocX, LocY)
        PictureBox.Size = New Size(SizeX, SizeY)
        PictureBox.Sizing = ImageSizeMode.StretchImage

        Return PictureBox
    End Function

    Private Sub SetConnection()
        Fcon.Tid = "root"
        Fcon.Tip = "localhost"
        Fcon.Tdb = "_db_lis"
        Fcon.Tpass = ""
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        MsgBox(Format(DateTime.Now, "yyyy-MM-dd") & " " & vbLf & Format(DateTime.Now, "HH:mm:ss"))
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        SaveFileDialog1.Filter = "TXT Files (*.txt*)|*.txt"
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK _
      Then
            My.Computer.FileSystem.WriteAllText _
            (SaveFileDialog1.FileName, "Hmmmm", True)
        End If
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        'Dim parameter As String = ""
        'Dim uri_message As String = ""
        'Dim empty As String = ""

        'parameter = "{" & _
        '          """number"" : """ & empty & """," & _
        '          """mime"" : """"," & _
        '          """src"" : """ & empty & """," & _
        '          """filename"" : """ & empty & """," & _
        '          """caption"" : """"," & _
        '          """thumbnail"" : """"," & _
        '          """message"" : """ & empty & """" & _
        '         "}"

        'uri_message = "http://localhost:3000/get-all-users"

        'empty = ViewData(uri_message)

        'MsgBox(empty)

        Dim parameter As String = ""
        Dim uri_message As String = ""
        Dim empty As String = ""

        parameter = "{" & _
                  """email"" : ""danifwahyudi@gmail.com""," & _
                  """password"" : ""danif12345""" & _
                 "}"

        'uri_message = "http://localhost:8080/otentikasi?email=danifwahyudi@gmail.com&password=danif12345"
        'uri_message = "http://localhost:8080/pegawai"
        uri_message = "https://dashboard-klinik.mitramedicare.com/api/posts/2"

        'Dim rawresp As String = viewDataWithParams(parameter, uri_message)
        Dim rawresp As String = ViewData(uri_message)
        Dim varses() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of container())(rawresp)

        For Each oneVar As container In varses
            If oneVar IsNot Nothing Then
                MsgBox(oneVar.message)

                'For index As Integer = 0 To oneVar.data.Count - 1
                '    'MsgBox(oneVar.data(index).email)
                '    'MsgBox(oneVar.data(index).message)
                'Next
            End If
        Next
    End Sub


    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Label1.Text = TextBox2.Text
        Using bm As New Bitmap(Label1.Width, Label1.Height)
            Label1.DrawToBitmap(bm, New Rectangle(0, 0, Label1.Width, Label1.Height))
            If PictureBox1.Image IsNot Nothing Then PictureBox1.Image.Dispose()
            PictureBox1.Image = New Bitmap(bm)
        End Using
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        Dim PathFolder As String = "D:\Invoice_Program_Poliklinik\LAB"
        'Dim PathFolderDetail As String = "D:\Invoice_Program_Poliklinik\LAB"
        If (Not System.IO.Directory.Exists(PathFolder)) Then
            System.IO.Directory.CreateDirectory(PathFolder)
        End If

        'If (Not System.IO.Directory.Exists(PathFolderDetail)) Then
        '    System.IO.Directory.CreateDirectory(PathFolderDetail)
        'End If

        MsgBox("Done.")
    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        'TESTING
        Dim TxPDF As String = ""
        TxPDF = Convert.ToBase64String(System.IO.File.ReadAllBytes("FileDownload\Hasil\20210406L00001_Hasil_Laboratorium.pdf"))

        txbase64_.Text = TxPDF

        'WriteThemysql("INSERT INTO testing (FileGambar) VALUES ('" & TxPDF & "')", Ttmesin)

        MsgBox("Done.")
    End Sub

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        Dim str As String = ReadThemysqlNIK("SELECT a.FileBase64 FROM acctransrekaptagihan a WHERE a.FileBase64 IS NOT NULL LIMIT 1", Ttmesin)
        'Dim str As String = txbase64_.Text

        'Dim cipherText As String = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(str))

        'Dim Base64Byte() As Byte = Convert.FromBase64String(cipherText)
        'Dim obj As FileStream = File.Create("C:\FilePDF\test.pdf")
        'obj.Write(Base64Byte, 0, Base64Byte.Length)

        'obj.Flush()
        'obj.Close()

        'If MsgBox("Ingin Membuka File?", MsgBoxStyle.YesNo, "Question.") = MsgBoxResult.Yes Then
        '    System.Diagnostics.Process.Start("C:\FilePDF\test.pdf")
        'End If

        Dim binaryData() As Byte = Convert.FromBase64String(str)

        ' Assuming it's a jpg :)
        If File.Exists("C:\FilePDF\ahai.pdf") Then
            My.Computer.FileSystem.DeleteFile("C:\FilePDF\ahai.pdf")
        End If

        Dim fs As New FileStream("C:\FilePDF\ahai.pdf", FileMode.CreateNew)

        ' write it out
        fs.Write(binaryData, 0, binaryData.Length)

        ' close it down.
        fs.Close()

        If MsgBox("Ingin Membuka File?", MsgBoxStyle.YesNo, "Question.") = MsgBoxResult.Yes Then
            System.Diagnostics.Process.Start("C:\FilePDF\ahai.pdf")
        End If
    End Sub

    Private Sub Conn()
        Ttmesin.Tid = "root"
        Ttmesin.Tip = ReadSQLNIK("select StrValue from MsConfig where ConfigName='Twebid'")
        Ttmesin.Tdb = "mitramed_keu"
        Ttmesin.Tpass = Strings.Replace(ReadSQLNIK("select StrValue from MsConfig where ConfigName='Twebpass'"), "|", "")
    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        Dim Generator As New MessagingToolkit.Barcode.BarcodeEncoder
        Generator.BackColor = Color.White
        Generator.LabelFont = New Font("Arial", 7, FontStyle.Regular)
        Generator.IncludeLabel = True
        'Generator = TextBox3.Text
        'Dim TxPDF As String = ""
        'TxPDF = Convert.ToBase64String(System.IO.File.ReadAllBytes("FileDownload\Hasil\20210406L00001_Hasil_Laboratorium.pdf"))

        Try
            PictureBox1.Image = New Bitmap(Generator.Encode(MessagingToolkit.Barcode.BarcodeFormat.QRCode, TextBox3.Text))
        Catch ex As Exception
            PictureBox1.Image = Nothing
        End Try
    End Sub

    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        Report = New XtraReport
        Report = XtraReport.FromFile(Application.StartupPath + "\reports\Laboratorium\RekapPendapatanLabPemeriksaanEDC.repx", True)
        'Report.ShowPreview()

        Dim filepath As String = "https://mitramedicare.com/IT_Cahaya/PDF_Laboratorium/Testing.pdf"

        My.Computer.Network.UploadFile("FileDownload\Hasil\20210406L00001_Hasil_Laboratorium.pdf", "https://mitramedicare.com/IT_Cahaya/PDF_Laboratorium/Testing.pdf")

        'Report.CreatePdfDocument(filepath)

        MsgBox("Saved.")
    End Sub

    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click
        Report = New XtraReport
        Report = XtraReport.FromFile(Application.StartupPath + "\reports\FormTesting.repx", True)
        'Report.DataSource = Thasil

        'Report.Bands.Item(BandKind.Detail).Controls("xrPictureBox2"). = Format(DateAndTime.Now, "dd-MM-yyyy HH:mm:ss") + " " + UserLabAdmin
        Report.Bands(BandKind.Detail).Controls.Add(CreateXRPictureBox(567, 65, 175, 100))
        Report.Bands.Item(BandKind.Detail).Controls("xrPictureBox1").BringToFront()
        Report.RunDesigner()
        'Report.ShowPreview()
    End Sub

    Function CreateXRPictureBox(ByVal LocX As Integer, ByVal LocY As Integer, ByVal SizeX As Integer, ByVal SizeY As Integer) As XRPictureBox
        'Dim Byted() As Byte = Tid
        'Dim Streamed As New System.IO.MemoryStream(Byted)

        Dim PictureBox As XRPictureBox = New XRPictureBox()
        PictureBox.Image = PictureBox1.Image
        PictureBox.Location = New Point(LocX, LocY)
        PictureBox.Size = New Size(SizeX, SizeY)
        PictureBox.Sizing = ImageSizeMode.StretchImage

        Return PictureBox
    End Function

    Private Sub Button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button21.Click
        'Report = New XtraReport
        'Report = XtraReport.FromFile(Application.StartupPath + "\reports\FormTesting.repx", True)
        'Report.CreateDocument()

        Dim report1 As New XtraReport()
        report1.CreateDocument()

        Dim report2 As New XtraReport()
        report2.CreateDocument()

        'Report.DataSource = Thasil

        'Report.Bands.Item(BandKind.Detail).Controls("xrPictureBox2"). = Format(DateAndTime.Now, "dd-MM-yyyy HH:mm:ss") + " " + UserLabAdmin
        'Report.Bands(BandKind.Detail).Controls.Add(CreateXRPictureBox(567, 65, 175, 100))
        'Report.Bands.Item(BandKind.Detail).Controls("xrPictureBox1").BringToFront()
        'Report.RunDesigner()
        'Report.ShowPreview()
    End Sub

    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click
        Dim str As String = "asw"

        MsgBox(str.Length)
    End Sub

    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Click
        PatchUpdate.Show()
        'PatchUpdate.Focus()
    End Sub

    Private Sub Button24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button24.Click
        mhs = New Mahasiswa

        mhs.setNama("Muhardanif")
        MsgBox("Haloo " & mhs.getNama())
    End Sub

    Private Sub getAPI()
        Dim origResponse As HttpWebResponse
        Dim objResponse As HttpWebResponse
        Dim origReader As StreamReader
        Dim objReader As StreamReader

        Dim origRequest As HttpWebRequest = DirectCast(HttpWebRequest.Create("https://api.orls.voxeo.net/files/exports/2017/10/31?"), HttpWebRequest)
        origRequest.Headers.Add("Authorization", "Basic c3NhX2RzdDpBc3AzY3RfMTIzNA==")
        origRequest.AllowAutoRedirect = False
        origRequest.Method = "GET"
        Try
            origResponse = DirectCast(origRequest.GetResponse(), HttpWebResponse)
            Dim Stream As Stream = origResponse.GetResponseStream()
            Dim sr As New StreamReader(Stream, Encoding.GetEncoding("utf-8"))
            Dim str As String = sr.ReadToEnd()
            MessageBox.Show(str)
        Catch ex As WebException
            MsgBox(ex.Status)
            Dim myRequest As HttpWebRequest = DirectCast(HttpWebRequest.Create("https://jsonplaceholder.typicode.com/posts"), HttpWebRequest)
            myRequest.Headers.Add("Authorization", "Basic c3NhX2RzdDpBc3AzY3RfMTIzNA==")
            Try
                objResponse = DirectCast(myRequest.GetResponse(), HttpWebResponse)

            Catch ex2 As WebException
                objReader = New StreamReader(objResponse.GetResponseStream())
                MsgBox(objReader.ReadToEnd())
                MsgBox(ex2.Status)
            End Try
        End Try
    End Sub

    Private Sub Button25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button25.Click
        Dim parameter As String = ""
        Dim uri_message As String = ""
        Dim empty As String = ""

        'parameter = "{" & _
        '              """image"" : null," & _
        '              """title"" : ""danifwahyudi@gmail.com""," & _
        '              """content"": ""danif12345""" & _
        '             "}"

        Dim var As String = "-"

        parameter = "{" & _
                      """no_transaksi"" : ""20230607U00017""," & _
                      """no_rekam_medis"" : ""L001-230303-0000001""," & _
                      """no_nik"" : ""123456786543""," & _
                      """nama_pasien"" : ""Muhardanif Tri Wahyudi""," & _
                      """tgl_lahir"" : null," & _
                      """id_dokter"" : null," & _
                      """nama_dokter"" : ""dr. Karlinawati Amala""," & _
                      """id_perawat"" : null," & _
                      """nama_perawat"" : ""Cintya Nigrum""," & _
                      """penerima_informasi"" : ""Muhardanif Tri Wahyudi""," & _
                      """ket_diagnosis"" : ""Acute gastroenteropathy due to Norwalk agent (A08.1)""," & _
                      """dasar_diagnosis"" : ""-""," & _
                      """id_tindakan"" : ""3""," & _
                      """ket_tindakan"" : ""Khitan Elektrocouter""," & _
                      """indikasi_tindakan"" : ""-""," & _
                      """tata_cara"" : ""-""," & _
                      """tujuan_tindakan"" : ""-""," & _
                      """risiko"" : ""-""," & _
                      """komplikasi"" : ""-""," & _
                      """prognosis"" : ""-""," & _
                      """alternatif_tindakan"" : ""-""," & _
                      """biaya_tindakan"": ""6500000""" & _
                     "}"

        uri_message = "https://dashboard-klinik.mitramedicare.com/api/posts"

        Dim insertData As String = InsertDataAPI(parameter, uri_message)

        'Dim rawresp As String = ViewData(uri_message)
        'Dim varses() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of container())(rawresp)

        'For Each oneVar As container In varses
        '    If oneVar IsNot Nothing Then
        '        MsgBox(oneVar.message)
        '    End If
        'Next
    End Sub

    Private Sub Button26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button26.Click
        MsgBox("Kunjungi dashboard web untuk melakukan tanda tangan.", MsgBoxStyle.Information, "Success!")
    End Sub

    Private Sub Button27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button27.Click
        Dim tblsInformedConsent As DataTable = ReadSQL("SELECT * FROM InformedConsent WHERE NoTransaksi = '20240304U00002'")
        Dim rowData As DataRow = tblsInformedConsent.Rows(0)

        Report = New XtraReport
        Report = XtraReport.FromFile(Application.StartupPath + "\Reports\Klinik\RekamMedis\ReportInformedConsent.repx", True)
        Report.DataSource = tblsInformedConsent

        ' Set Jenis Kelamin Penanggung Jawab
        Dim jenisKelaminPenanggungJawab As String = ""
        If rowData("JenisKelaminPenanggungJawab").ToString = "L" Then
            jenisKelaminPenanggungJawab = "Laki-laki"
        ElseIf rowData("JenisKelaminPenanggungJawab").ToString = "P" Then
            jenisKelaminPenanggungJawab = "Perempuan"
        End If

        ' Set Jenis Kelamin Pasien
        Dim jenisKelaminPasien As String = ""
        If rowData("JenisKelaminPasien").ToString = "L" Then
            jenisKelaminPasien = "Laki-laki"
        ElseIf rowData("JenisKelaminPasien").ToString = "P" Then
            jenisKelaminPasien = "Perempuan"
        End If

        ' Set Hubungan Penanggung Jawab
        Dim hubunganPenanggungJawab As String = ""
        If rowData("HubunganPenanggungJawab") = "Pasien Sendiri" Then
            hubunganPenanggungJawab = "saya"
        Else
            hubunganPenanggungJawab = rowData("HubunganPenanggungJawab") & " saya"
        End If

        ' Set Lokasi & Waktu
        Dim waktuDariDatabase As DateTime = rowData("TglTransaksi")

        Dim tanggal As String = waktuDariDatabase.ToString("dd-MM-yyyy")
        Dim jam As String = waktuDariDatabase.ToString("HH:mm:ss")
        Dim waktuInformedConsent As String = rowData("KeteranganLokasi") & ", tanggal " & tanggal & " pukul " & jam

        ' Set Field Penyataan Pasien
        Dim panelPernyataanPasien As XRPanel = CType(Report.Bands(BandKind.Detail).Controls("xrPanelPernyataan"), XRPanel)
        Dim panelPersetujuanPasien As XRPanel = CType(Report.Bands(BandKind.Detail).Controls("xrPanelPersetujuan"), XRPanel)
        Dim panelPenolakanPasien As XRPanel = CType(Report.Bands(BandKind.Detail).Controls("xrPanelPenolakan"), XRPanel)

        Dim stringPenyataanPasien As String = "Yang bertandatangan di bawah ini, saya, nama " & rowData("NamaPenanggungJawab") & ", umur " & rowData("UmurPenanggungJawab") & " tahun, " & jenisKelaminPenanggungJawab & ", alamat " & rowData("AlamatPenanggungJawab") & _
                                              " dengan ini menyatakan persetujuan untuk dilakukannya tindakan " & rowData("KeteranganTindakan") & _
                                              " terhadap " & hubunganPenanggungJawab & " bernama " & rowData("NamaPasien") & ", umur " & rowData("UmurPasien") & " tahun, " & jenisKelaminPasien & ", alamat " & rowData("AlamatPasien")
        panelPernyataanPasien.Controls("xrLabelPernyataanPasien").Text = stringPenyataanPasien
        panelPersetujuanPasien.Controls("xrLabelTanggalPersetujuanPasien").Text = waktuInformedConsent
        panelPenolakanPasien.Controls("xrLabelTanggalPenolakanPasien").Text = waktuInformedConsent

        '# Set Signature Page 1
        Dim xrTablePage1 As XRTable = CType(Report.Bands(BandKind.Detail).Controls("xrTableSignaturePage1"), XRTable)

        Dim rowDokterSignatureTablePage1 As XRTableRow = CType(xrTablePage1.Controls("xrTableRowDokterSignature"), XRTableRow)
        Dim cellDokterSignatureTablePage1 As XRTableCell = CType(rowDokterSignatureTablePage1.Controls("xrTableCellDokterSignature"), XRTableCell)
        Dim panelDokterSignatureTablePage1 As XRPanel = CType(cellDokterSignatureTablePage1.Controls("xrPanelDokterSignature"), XRPanel)

        Dim rowPasienSignatureTablePage1 As XRTableRow = CType(xrTablePage1.Controls("xrTableRowPasienSignature"), XRTableRow)
        Dim cellPasienSignatureTablePage1 As XRTableCell = CType(rowPasienSignatureTablePage1.Controls("xrTableCellPasienSignature"), XRTableCell)
        Dim panelPasienSignatureTablePage1 As XRPanel = CType(cellPasienSignatureTablePage1.Controls("xrPanelPasienSignature"), XRPanel)

        ' Signature Dokter
        Dim pictureBoxDokterSignaturePage1 As XRPictureBox = CreateXRPictureBoxReportFromBase64(rowData("SignatureDokter1"), "DokterSignaturePage1", 5, 20, 125, 50)
        panelDokterSignatureTablePage1.Controls.Add(pictureBoxDokterSignaturePage1)

        ' Signature Pasien
        Dim pictureBoxPasienSignaturePage1 As XRPictureBox = CreateXRPictureBoxReportFromBase64(rowData("SignaturePasien1"), "PasienSignaturePage1", 5, 20, 125, 50)
        panelPasienSignatureTablePage1.Controls.Add(pictureBoxPasienSignaturePage1)

        '# Set Signature Page 2
        Dim panelSignaturePersetujuanDokter As XRPanel = CType(panelPersetujuanPasien.Controls("xrPanelSignaturePersetujuanDokter"), XRPanel)
        Dim panelSignaturePersetujuanPasien As XRPanel = CType(panelPersetujuanPasien.Controls("xrPanelSignaturePersetujuanPasien"), XRPanel)
        Dim panelSignaturePersetujuanPerawat As XRPanel = CType(panelPersetujuanPasien.Controls("xrPanelSignaturePersetujuanPerawat"), XRPanel)
        Dim panelSignaturePersetujuanKeluarga As XRPanel = CType(panelPersetujuanPasien.Controls("xrPanelSignaturePersetujuanKeluarga"), XRPanel)

        ' Signature Dokter
        Dim pictureBoxSignaturePersetujuanDokter As XRPictureBox = CreateXRPictureBoxReportFromBase64(rowData("SignatureDokter2"), "SignaturePersetujuanDokter", 5, 20, 125, 50)
        panelSignaturePersetujuanDokter.Controls.Add(pictureBoxSignaturePersetujuanDokter)
        panelSignaturePersetujuanDokter.Controls("xrLabelSignaturePersetujuanDokter").Text = "( " & rowData("NamaDokter") & " )"

        ' Signature Pasien
        Dim pictureBoxSignaturePersetujuanPasien As XRPictureBox = CreateXRPictureBoxReportFromBase64(rowData("SignaturePasien2"), "SignaturePersetujuanPasien", 5, 20, 125, 50)
        panelSignaturePersetujuanPasien.Controls.Add(pictureBoxSignaturePersetujuanPasien)
        panelSignaturePersetujuanPasien.Controls("xrLabelSignaturePersetujuanPasien").Text = "( " & rowData("NamaPenanggungJawab") & " )"

        ' Signature Perawat
        Dim pictureBoxSignaturePersetujuanPerawat As XRPictureBox = CreateXRPictureBoxReportFromBase64(rowData("SignaturePerawat"), "SignaturePersetujuanPerawat", 5, 20, 125, 50)
        panelSignaturePersetujuanPerawat.Controls.Add(pictureBoxSignaturePersetujuanPerawat)
        panelSignaturePersetujuanPerawat.Controls("xrLabelSignaturePersetujuanPerawat").Text = "( " & rowData("NamaPerawat") & " )"

        ' Signature Keluarga
        If rowData("StatusSaksiPasien") = True Then
            Dim pictureBoxSignaturePersetujuanKeluarga As XRPictureBox = CreateXRPictureBoxReportFromBase64(rowData("SignatureKeluarga"), "SignaturePersetujuanKeluarga", 5, 20, 125, 50)
            panelSignaturePersetujuanKeluarga.Controls.Add(pictureBoxSignaturePersetujuanKeluarga)
            panelSignaturePersetujuanKeluarga.Controls("xrLabelSignaturePersetujuanKeluarga").Text = "( " & rowData("NamaSaksiPasien") & " )"
        End If

        'Report.RunDesigner()
        Report.ShowPreview()
    End Sub

    Private Sub Button28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button28.Click
        Dim htmlContent As String = "<p style=""border: 0px; outline: 0px; vertical-align: baseline; margin: 0px 0px 10px; padding: 0px; -webkit-font-smoothing: antialiased; text-rendering: optimizelegibility; font-style: inherit; line-height: 23px;""><span style=""border: 0px; outline: 0px; vertical-align: baseline; margin: 0px; padding: 0px; -webkit-font-smoothing: antialiased; text-rendering: optimizelegibility; font-style: inherit;"">Aorta dan arteri pulmoner pasien baik.</span></p><p style=""border: 0px; outline: 0px; vertical-align: baseline; margin: 0px 0px 10px; padding: 0px; -webkit-font-smoothing: antialiased; text-rendering: optimizelegibility; font-style: inherit; line-height: 23px;""><span style=""border: 0px; outline: 0px; vertical-align: baseline; margin: 0px; padding: 0px; -webkit-font-smoothing: antialiased; text-rendering: optimizelegibility; font-style: inherit;"">Tidak tampak pneumoperitoneum</span></p><div><span style=""font-style: inherit; font-size: 0.875rem; background-color: var(--bs-modal-bg); font-weight: var(--bs-body-font-weight); text-align: var(--bs-body-text-align); border: 0px; outline: 0px; vertical-align: baseline; margin: 0px; padding: 0px; -webkit-font-smoothing: antialiased; text-rendering: optimizelegibility;"">Tulang pasien seluruhnya terbilang simetris. Tidak tampak garis fraktur, lesi di tulang ataupun&nbsp;</span><i style=""font-size: 0.875rem; background-color: var(--bs-modal-bg); font-weight: var(--bs-body-font-weight); text-align: var(--bs-body-text-align); font-family: Lato;""><span style=""font-family: Lato, sans-serif; border: 0px; outline: 0px; vertical-align: baseline; margin: 0px; padding: 0px; -webkit-font-smoothing: antialiased; text-rendering: optimizelegibility; font-style: inherit;"">subcutaneous air</span></i><br></div><p>test3</p>test2test4"

        WebBrowser1.DocumentText = htmlContent
    End Sub

    Private Sub Button29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button29.Click
        Ttmesin.Tid = "root"
        Ttmesin.Tip = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='TIP'")
        Ttmesin.Tdb = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='TDB'")
        Ttmesin.Tpass = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName='TPass'")

        'Dim text As String = ReadThemysqlNIK("SELECT a.NoUrut FROM paslab a WHERE a.IDMesin = '224989';", Ttmesin)

        'MsgBox(text)

        'Dim jsonResponse As String = GetDataAPI("http://127.0.0.1:8000/api/get-data-resource-poliklinik")

        'If Not String.IsNullOrEmpty(jsonResponse) Then
        '    Dim dt As DataTable = JsonConvert.DeserializeObject(Of DataTable)(jsonResponse)

        '    ' Gunakan DataTable dt seperti yang Anda lakukan sebelumnya
        'End If

        'Dim tbls As DataTable = GetDataTableMySQL("SELECT * FROM paslab a WHERE a.NoUrut LIKE '%009240313%';", Ttmesin)
        'Dim stringVar As String = GetDataStringMySQL("SELECT a.NoUrut FROM paslab a WHERE a.IDMesin = '224982229';", Ttmesin)

        'Dim stringVar As String = ReadThemysqlNIK("SELECT a.NoUrut FROM paslab a WHERE a.IDMesin = '224982229';", Ttmesin)

        'If CheckDataMySQL("SELECT * FROM paslab a WHERE a.NoUrut LIKE '%009240313%';", Ttmesin) = False Then
        '    MsgBox("tidak ada")
        'Else
        '    MsgBox("ada")
        'End If

        ExecuteQueryWithoutResultMySQL("INSERT INTO covid_saran (hasil, saran) VALUES ('tess', 'tes');", Ttmesin)

        'MsgBox(stringVar)
    End Sub

    Private Sub Button30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button30.Click

    End Sub
End Class
