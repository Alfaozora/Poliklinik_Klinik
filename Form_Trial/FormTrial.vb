'Imports System.Drawing.Drawing2D
Imports System.Drawing
'Imports System.Windows.Forms
Imports Microsoft.Reporting.WinForms
Imports System.Diagnostics
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.UI
Imports System.Collections.Generic

Public Class FormTrial
    Private DB_Jurnal As TLcon

    ' Deklarasi variabel global untuk menyimpan keterangan
    Dim keteranganGambar As String = ""
    Dim clickedPoint As Point
    Dim currentLabel As Label

    'Deklarasi objek ToolTip
    Private WithEvents tooltip As New ToolTip()

    'Public Class MyTabControl
    '    Inherits TabControl

    '    Protected Overrides ReadOnly Property CreateParams() As CreateParams
    '        Get
    '            Dim cp As CreateParams = MyBase.CreateParams
    '            cp.ExStyle = cp.ExStyle Or &H200 'WS_EX_COMPOSITED
    '            cp.Style = cp.Style Or &H2 'TCS_OWNERDRAWFIXED
    '            Return cp
    '        End Get
    '    End Property

    '    Protected Overrides Sub OnDrawItem(ByVal e As DrawItemEventArgs)
    '        MyBase.OnDrawItem(e)
    '        Dim g As Graphics = e.Graphics
    '        Dim r As Rectangle = GetTabRect(e.Index)
    '        Dim backBrush As Brush = New SolidBrush(Color.Blue) 'Warna latar belakang TabControl

    '        g.FillRectangle(backBrush, r)
    '        Dim t As String = Me.TabPages(e.Index).Text
    '        Dim textBrush As Brush = New SolidBrush(Color.White) 'Warna teks
    '        Dim textSize As SizeF = g.MeasureString(t, Me.Font)

    '        g.DrawString(t, Me.Font, textBrush, r.X + (r.Width - textSize.Width) / 2, r.Y + (r.Height - textSize.Height) / 2)
    '    End Sub
    'End Class

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Panel3.Visible = True
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Panel3.Visible = False
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As MouseEventArgs) Handles PictureBox1.Click
        'Dim keterangan As String = InputBox("Masukkan keterangan untuk bagian ini:")

        '' Jika pengguna memasukkan keterangan, tambahkan teks pada gambar
        'If keterangan <> "" Then
        '    ' Buat objek graphics
        '    Dim g As Graphics = PictureBox1.CreateGraphics()

        '    ' Buat font untuk teks
        '    Dim font As New Font("Arial", 12, FontStyle.Bold)

        '    ' Tentukan posisi untuk teks
        '    Dim posisi As New Point(50, 50)

        '    ' Gambar teks pada gambar
        '    g.DrawString(keterangan, font, Brushes.Red, posisi)

        '    ' Tambahkan label pada gambar yang menampilkan keterangan
        '    Dim label As New Label
        '    label.Text = keterangan
        '    label.Font = font
        '    label.ForeColor = Color.Red
        '    label.Left = posisi.X
        '    label.Top = posisi.Y
        '    PictureBox1.Controls.Add(label)
        'End If

        ' ==================================================================================

        '' Ambil posisi klik pada gambar
        'Dim posisiKlik As Point = PictureBox1.PointToClient(MousePosition)

        '' Tampilkan kotak dialog untuk memasukkan keterangan
        'Dim keterangan As String = InputBox("Masukkan keterangan pada gambar:", "Keterangan Gambar", "")

        '' Tampilkan keterangan pada bagian gambar yang diklik
        'Dim g As Graphics = PictureBox1.CreateGraphics()
        'Dim f As New Font("Arial", 10)
        'Dim b As New SolidBrush(Color.Black)
        'g.DrawString(keterangan, f, b, posisiKlik.X, posisiKlik.Y)

        ' ==================================================================================

        'FIXXXXXXXXX

        '' Ambil posisi klik pada gambar
        'Dim posisiKlik As Point = PictureBox1.PointToClient(MousePosition)

        '' Tampilkan kotak dialog untuk memasukkan keterangan
        'Dim keterangan As String = InputBox("Masukkan keterangan pada gambar:", "Keterangan Gambar", "")

        '' Tampilkan keterangan pada label di bagian gambar yang diklik
        'Dim labelKeterangan As New Label()
        'labelKeterangan.Text = keterangan
        'labelKeterangan.Font = New Font("Arial", 10)
        'labelKeterangan.ForeColor = Color.Black
        'labelKeterangan.AutoSize = True
        'labelKeterangan.Location = posisiKlik
        'PictureBox1.Controls.Add(labelKeterangan)

        ' ================================

        clickedPoint = e.Location
        Dim keterangan As String = InputBox("Masukkan keterangan pada gambar:", "Keterangan Gambar", "")
        AddLabel(keterangan)
    End Sub

    Private Sub AddLabel(ByVal keterangan As String)
        currentLabel = New Label
        currentLabel.Text = keterangan
        currentLabel.AutoSize = True
        currentLabel.Location = clickedPoint
        currentLabel.BackColor = Color.White
        currentLabel.BorderStyle = BorderStyle.FixedSingle
        currentLabel.Font = New Font("Arial", 10)
        AddHandler currentLabel.Click, AddressOf Label_Click
        PictureBox1.Controls.Add(currentLabel)

        MsgBox(currentLabel.Location.X)
        MsgBox(currentLabel.Location.Y)
        MsgBox(currentLabel.Text)
        MsgBox(currentLabel.Font.Name)
        MsgBox(currentLabel.Font.Size)
        MsgBox(currentLabel.BackColor.ToArgb())
        MsgBox(currentLabel.ForeColor.ToArgb())
    End Sub

    Private Sub Label_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim result As DialogResult = MessageBox.Show("Apakah Anda yakin ingin menghapus keterangan ini?", "Hapus Keterangan", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            PictureBox1.Controls.Remove(sender)
        End If
    End Sub

    Private Sub LoadKeteranganGambar(ByVal posisiX As Integer, ByVal posisiY As Integer, ByVal keterangan As String, ByVal fontName As String, ByVal fontSize As Single, ByVal warnaLatar As Color, ByVal warnaTeks As Color)
        currentLabel = New Label
        currentLabel.Text = keterangan
        currentLabel.AutoSize = True
        currentLabel.Location = New Point(posisiX, posisiY)
        currentLabel.BackColor = warnaLatar
        currentLabel.BorderStyle = BorderStyle.FixedSingle
        currentLabel.Font = New Font("Arial", 10)
        tooltip.SetToolTip(currentLabel, "Ini adalah tooltip untuk label1")

        AddHandler currentLabel.Click, AddressOf Label_Click
        PictureBox1.Controls.Add(currentLabel)
    End Sub

    Private Sub btnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSimpan.Click
        Dim posisiX As Integer = 95
        Dim posisiY As Integer = 70
        Dim keterangan As String = "2"
        Dim fontName As String = "Arial"
        Dim fontSize As Single = 10
        Dim warnaLatar As Color = Color.FromArgb(-1)
        Dim warnaTeks As Color = Color.FromArgb(-16777216)
        LoadKeteranganGambar(posisiX, posisiY, keterangan, fontName, fontSize, warnaLatar, warnaTeks)
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        'Dim myuuid As Guid = Guid.NewGuid()
        'Dim myuuidAsString As String = myuuid.ToString()

        MsgBox(GetUUID())

        'Debug.WriteLine("Your UUID is: " & myuuidAsString)
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        MsgBox(GetOnlineTime())
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim gambarKopSurat As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'image_path_kop_surat_keterangan'")

        Report = New XtraReport
        Report = XtraReport.FromFile(Application.StartupPath + "\Reports\Klinik\SuratKeterangan\SuratKeteranganDokterCitra.repx", True)

        ' Set Image
        ' Ganti path file dengan path yang sesuai dengan struktur direktori proyek Anda
        Dim imagePath As String = System.IO.Path.Combine(Application.StartupPath, gambarKopSurat)

        ' Pastikan kode ini berada di bagian yang sesuai, seperti di dalam method InitializeComponent() atau di tempat lain yang sesuai.
        Dim pictureBox As XRPictureBox = CreateXRPictureBox(Image.FromFile(imagePath), 87, 33, 408, 71)

        Report.Bands.Item(BandKind.PageHeader).Controls.Add(pictureBox)
        Report.RunDesigner()
    End Sub

    Function CreateXRPictureBox(ByVal imageSignature As Image, ByVal LocX As Integer, ByVal LocY As Integer, ByVal SizeX As Integer, ByVal SizeY As Integer) As XRPictureBox
        Dim PictureBox As XRPictureBox = New XRPictureBox()
        PictureBox.Name = "QR_Hasil"
        PictureBox.Image = imageSignature
        PictureBox.Location = New Point(LocX, LocY)
        PictureBox.Size = New Size(SizeX, SizeY)
        PictureBox.Sizing = ImageSizeMode.StretchImage
        PictureBox.BorderWidth = 0

        Return PictureBox
    End Function

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        MsgBox(GetKesimpulanBMI(TextBoxBMI.Text))
    End Sub

    Private Sub ToolStripMenuItem1_MouseEnter(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonMenuAntrianOnline.MouseEnter
        ' Set warna latar belakang saat mouse masuk
        ButtonMenuAntrianOnline.BackColor = Color.Gray
        ' Sesuaikan warna teks jika diperlukan
        ButtonMenuAntrianOnline.ForeColor = Color.Black
    End Sub

    Private Sub ToolStripMenuItem1_MouseLeave(ByVal sender As Object, ByVal e As EventArgs) Handles ButtonMenuAntrianOnline.MouseLeave
        ' Set warna latar belakang saat mouse meninggalkan
        ButtonMenuAntrianOnline.BackColor = Color.FromArgb(101, 129, 229)
        ' Sesuaikan warna teks jika diperlukan
        ButtonMenuAntrianOnline.ForeColor = Color.White
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        MsgBox(GetJenisPembayaran("POLI", TextBoxNoUrut.Text))
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        MsgBox(GetCurrentTime.Date)
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        ' Set DB Jurnal
        DB_Jurnal.Tip = Utility.GetConfig("ServerJurnal_IP")
        DB_Jurnal.Tid = Utility.GetConfig("ServerJurnal_UserID")
        DB_Jurnal.Tpass = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerJurnal_Password"), "albert")
        DB_Jurnal.Tdb = Utility.GetConfig("ServerJurnal_DB")

        If CekKoneksi("SHOW TABLES FROM testapotek", DB_Jurnal) = False Then
            MsgBox("Proses gagal.")
        Else
            MsgBox("Koneksi Berhasil.")
        End If
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        ' Menampilkan notifikasi
        NotifyIcon1.BalloonTipTitle = "Notifikasi"
        NotifyIcon1.BalloonTipText = "Ini adalah contoh notifikasi dari aplikasi Anda."
        NotifyIcon1.ShowBalloonTip(1000) ' Durasi dalam milidetik (misalnya 1000 ms)
        NotifyIcon1.BalloonTipIcon = ToolTipIcon.Error
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Report = New XtraReport
        Report = XtraReport.FromFile(Application.StartupPath + "\reports\Recycle\TesQR.repx", True)

        Dim Generator As New MessagingToolkit.Barcode.BarcodeEncoder
        Dim qrImage As Bitmap = New Bitmap(Generator.Encode(MessagingToolkit.Barcode.BarcodeFormat.QRCode, "18000191"))

        ' Pastikan kode ini berada di bagian yang sesuai, seperti di dalam method InitializeComponent() atau di tempat lain yang sesuai.
        Dim pictureBox As XRPictureBox = CreateXRPictureBox(qrImage, 0, 0, 175, 100)

        ' Akses panel yang sudah ada di dalam band Detail menggunakan index
        Dim panelQR As XRPanel = CType(Report.Bands(BandKind.ReportFooter).Controls("xrPanelQR"), XRPanel)

        ' Tambahkan pictureBox ke dalam panel
        panelQR.Controls.Add(pictureBox)
        panelQR.Visible = True

        Report.Bands.Item(BandKind.ReportFooter).Controls("xrLabelKodeVoucher").Visible = True

        Report.RunDesigner()
    End Sub
End Class