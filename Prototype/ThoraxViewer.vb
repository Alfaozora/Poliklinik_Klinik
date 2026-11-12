Imports System.Net
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Web.Script.Serialization

Public Class FormThoraxViewer
    Inherits Form

    Dim baseURL As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")

    ' --- Helper UX Zoom & Pan untuk PictureBox bawaan Designer ---
    Private viewerKiri As PictureBoxZoomPan
    Private viewerKanan As PictureBoxZoomPan
    Private _isSyncing As Boolean = False

    ' --- BackgroundWorker agar UI tidak freeze saat download ---
    Private WithEvents bgwKiri As New BackgroundWorker()
    Private WithEvents bgwKanan As New BackgroundWorker()

    ' Property opsional jika dipanggil dari Form Pemeriksaan/RM
    Private _nikPasien As String = ""
    Public Property NikPasien() As String
        Get
            Return _nikPasien
        End Get
        Set(ByVal value As String)
            _nikPasien = value
        End Set
    End Property

    Private _namaPasien As String = ""
    Public Property NamaPasien() As String
        Get
            Return _namaPasien
        End Get
        Set(ByVal value As String)
            _namaPasien = value
        End Set
    End Property

    Public Class BacaanApiResponse
        Public status As Boolean
        Public message As String
        Public data As ThoraxBacaanDetail
    End Class

    Public Class ThoraxBacaanDetail
        Public cor As String
        Public pulmo As String
        Public sinus As String
        Public skeletal As String
        Public kesimpulan As String
        Public drthorax As String
    End Class

    Public Class TanggalThoraxResponse
        Public status As Boolean
        Public message As String
        Public data As List(Of TanggalThoraxItem)
    End Class

    Public Class TanggalThoraxItem
        Public tanggal As String
        Public idlabinternet As String
        Public namatindakan As String
    End Class

    Private Sub FormThoraxViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' 1. Pastikan baseURL bersih dari trailing slash (/)
        baseURL = baseURL.Trim().TrimEnd("/"c)

        ' 2. Pasang engine Zoom & Pan ke PictureBox yang sudah Anda buat di Designer
        ' GANTI picBoxKiri & picBoxKanan sesuai nama PictureBox di form Anda
        viewerKiri = New PictureBoxZoomPan(picBoxKiri)
        viewerKanan = New PictureBoxZoomPan(picBoxKanan)

        AddHandler viewerKiri.ViewChanged, AddressOf ViewerKiri_ViewChanged
        AddHandler viewerKanan.ViewChanged, AddressOf ViewerKanan_ViewChanged

        ' 3. Isi data pasien jika dikirim dari form sebelumnya
        If Not String.IsNullOrEmpty(NikPasien) Then
            txtNik.Text = NikPasien
        End If
        If Not String.IsNullOrEmpty(NamaPasien) Then
            lblNamaPasien.Text = NamaPasien.ToUpper()
        End If

        ' Set default tanggal
        LoadDaftarTanggalThorax()
    End Sub

    Private Sub txtNik_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtNik.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            LoadDaftarTanggalThorax()
        End If
    End Sub

    Private Sub cmbTanggal_DrawItem(ByVal sender As Object, ByVal e As DrawItemEventArgs) Handles cmbTglKiri.DrawItem, cmbTglKanan.DrawItem
        Dim cmb As ComboBox = CType(sender, ComboBox)

        ' Tentukan warna latar: Biru aksen saat di-hover/dipilih, Dark Slate saat normal
        Dim bgColor As Color
        If (e.State And DrawItemState.Selected) = DrawItemState.Selected AndAlso (e.State And DrawItemState.ComboBoxEdit) <> DrawItemState.ComboBoxEdit Then
            bgColor = Color.FromArgb(2, 132, 199) ' Medical Sky Blue saat hover di list
        Else
            bgColor = Color.FromArgb(15, 23, 42)  ' Dark Slate menyatu dengan header
        End If

        Using bgBrush As New SolidBrush(bgColor)
            e.Graphics.FillRectangle(bgBrush, e.Bounds)
        End Using

        ' Gambar teks tanggal jika item ada
        If e.Index >= 0 AndAlso e.Index < cmb.Items.Count Then
            Dim textItem As String = cmb.Items(e.Index).ToString()
            Dim textRect As New Rectangle(e.Bounds.X + 6, e.Bounds.Y, e.Bounds.Width - 6, e.Bounds.Height)

            TextRenderer.DrawText( _
                e.Graphics, _
                textItem, _
                New Font("Segoe UI", 9.5F, FontStyle.Bold), _
                textRect, _
                Color.FromArgb(241, 245, 249), _
                TextFormatFlags.VerticalCenter Or TextFormatFlags.Left _
            )
        End If

        ' Gambar garis border tipis di sekeliling kotak utama
        If (e.State And DrawItemState.ComboBoxEdit) = DrawItemState.ComboBoxEdit Then
            Using borderPen As New Pen(Color.FromArgb(51, 65, 85), 1)
                e.Graphics.DrawRectangle(borderPen, 0, 0, cmb.Width - 1, cmb.Height - 1)
            End Using
        End If
    End Sub

    ' =========================================================================
    ' FUNGSI GET IMAGE DARI WEBSERVICE LARAVEL
    ' =========================================================================
    Public Function GetImageAPIRM(ByVal uri As String, ByRef errorMessage As String) As Image
        errorMessage = String.Empty
        Try
            Dim webreq As HttpWebRequest = CType(WebRequest.Create(uri), HttpWebRequest)

            webreq.Accept = "image/jpeg"
            webreq.Method = "GET"
            webreq.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64)"
            webreq.Headers.Add("X-API-KEY", "M1tR4M3D1c@rECaH4Y42025")

            webreq.Timeout = 300000
            webreq.ReadWriteTimeout = 300000

            Using res As WebResponse = webreq.GetResponse()
                Using stream As Stream = res.GetResponseStream()
                    Dim ms As New MemoryStream()
                    Dim buffer(4096) As Byte
                    Dim bytesRead As Integer = stream.Read(buffer, 0, buffer.Length)
                    While bytesRead > 0
                        ms.Write(buffer, 0, bytesRead)
                        bytesRead = stream.Read(buffer, 0, buffer.Length)
                    End While
                    ms.Position = 0
                    Return Image.FromStream(ms)
                End Using
            End Using

        Catch ex As WebException
            If ex.Response IsNot Nothing Then
                Using responseStream As Stream = ex.Response.GetResponseStream()
                    Using reader As New StreamReader(responseStream)
                        errorMessage = "Data tidak ditemukan"
                    End Using
                End Using
            Else
                errorMessage = "Koneksi gagal: " & ex.Message
            End If
            Return Nothing
        Catch ex As Exception
            errorMessage = "File bukan gambar valid"
            Return Nothing
        End Try
    End Function

    Private Sub LoadDaftarTanggalThorax()
        If String.IsNullOrEmpty(txtNik.Text.Trim()) Then Return

        cmbTglKiri.Items.Clear()
        cmbTglKanan.Items.Clear()

        Dim url As String = String.Format("{0}/api/lab/thorax/tanggal?nik={1}", baseURL, txtNik.Text.Trim())
        Dim jsonRaw As String = GetDataAPIRM(url)

        Try
            Dim serializer As New JavaScriptSerializer()
            Dim res As TanggalThoraxResponse = serializer.Deserialize(Of TanggalThoraxResponse)(jsonRaw)

            If res IsNot Nothing AndAlso res.status AndAlso res.data IsNot Nothing AndAlso res.data.Count > 0 Then
                For Each item As TanggalThoraxItem In res.data
                    cmbTglKiri.Items.Add(item.tanggal)
                    cmbTglKanan.Items.Add(item.tanggal)
                Next

                ' Pilih otomatis tanggal terbaru di kanan (index 0)
                cmbTglKanan.SelectedIndex = 0

                ' Jika ada >= 2 riwayat, pilih otomatis tanggal sebelumnya di kiri (index 1)
                If cmbTglKiri.Items.Count > 1 Then
                    cmbTglKiri.SelectedIndex = 1
                Else
                    cmbTglKiri.SelectedIndex = 0
                End If

                ' Opsional: Langsung muat gambar kanan & kiri otomatis begitu form terbuka
                btnLoadKanan.PerformClick()
                If cmbTglKiri.Items.Count > 1 Then btnLoadKiri.PerformClick()
            Else
                lblStatusKiri.Text = "Tidak ada riwayat Thorax"
                lblStatusKanan.Text = "Tidak ada riwayat Thorax"
            End If
        Catch ex As Exception
            lblStatusKiri.Text = "Gagal memuat tanggal"
        End Try
    End Sub

    ' =========================================================================
    ' UX DOWNLOAD ASYNCHRONOUS PANEL KIRI (PEMBANDING)
    ' =========================================================================
    Private Sub btnLoadKiri_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadKiri.Click
        If bgwKiri.IsBusy Then Return
        If String.IsNullOrEmpty(txtNik.Text.Trim()) Then
            MessageBox.Show("NIK Pasien belum diisi.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNik.Focus()
            Return
        End If

        btnLoadKiri.Enabled = False
        btnLoadKiri.Text = "Memuat..."
        lblStatusKiri.Text = "Mengambil citra..."
        lblStatusKiri.ForeColor = Color.DeepSkyBlue

        If cmbTglKiri.SelectedItem Is Nothing Then Return
        Dim tglDipilih As String = cmbTglKiri.SelectedItem.ToString()
        Dim param() As String = {txtNik.Text.Trim(), tglDipilih}
        bgwKiri.RunWorkerAsync(param)
    End Sub

    Private Sub bgwKiri_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles bgwKiri.DoWork
        Dim param() As String = CType(e.Argument, String())
        Dim nik As String = param(0)
        Dim tgl As String = param(1)

        ' 1. Ambil Binary Gambar JPG Langsung (Tanpa Base64)
        Dim urlImg As String = String.Format("{0}/api/lab/thorax?nik={1}&tanggal={2}", baseURL, nik, tgl)
        Dim errImg As String = ""
        Dim img As Image = GetImageAPIRM(urlImg, errImg)

        ' 2. Ambil Teks Hasil Bacaan (JSON < 1 KB)
        Dim urlBacaan As String = String.Format("{0}/api/lab/thorax/bacaan?nik={1}&tanggal={2}", baseURL, nik, tgl)
        Dim jsonBacaan As String = GetDataAPIRM(urlBacaan)

        Dim bacaanRes As BacaanApiResponse = Nothing
        Try
            Dim serializer As New JavaScriptSerializer()
            bacaanRes = serializer.Deserialize(Of BacaanApiResponse)(jsonBacaan)
        Catch
        End Try

        e.Result = New Object() {img, errImg, bacaanRes}
    End Sub

    Private Sub bgwKiri_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles bgwKiri.RunWorkerCompleted
        btnLoadKiri.Enabled = True
        btnLoadKiri.Text = "Muat Gambar"

        Dim res() As Object = CType(e.Result, Object())
        Dim img As Image = CType(res(0), Image)
        Dim errImg As String = res(1).ToString()
        Dim bacaanRes As BacaanApiResponse = CType(res(2), BacaanApiResponse)

        ' Update PictureBox
        If img IsNot Nothing Then
            viewerKiri.SetImage(img)
            lblStatusKiri.Text = String.Format("Tampil ({0}x{1} px)", img.Width, img.Height)
            lblStatusKiri.ForeColor = Color.MediumSpringGreen
        Else
            viewerKiri.SetImage(Nothing)
            lblStatusKiri.Text = errImg
            lblStatusKiri.ForeColor = Color.Salmon
        End If

        ' Update TextBox Hasil Bacaan
        If bacaanRes IsNot Nothing AndAlso bacaanRes.status AndAlso bacaanRes.data IsNot Nothing Then
            txtHasilKiri.Text = FormatBacaanThorax(bacaanRes.data.cor, bacaanRes.data.pulmo, bacaanRes.data.sinus, bacaanRes.data.skeletal, bacaanRes.data.kesimpulan, bacaanRes.data.drthorax)
        Else
            Dim msg As String = If(bacaanRes IsNot Nothing, bacaanRes.message, "Hasil bacaan tidak ditemukan")
            txtHasilKiri.Text = "HASIL BACAAN RADIOLOGI THORAX:" & vbCrLf & "--------------------------------------------------" & vbCrLf & msg
        End If
    End Sub

    Private Function FormatBacaanThorax(ByVal cor As String, ByVal pulmo As String, ByVal sinus As String, ByVal skeletal As String, ByVal kesimpulan As String, ByVal drThorax As String) As String
        Dim sb As New System.Text.StringBuilder()
        sb.AppendLine("HASIL BACAAN RADIOLOGI THORAX  |  Dokter: " & If(String.IsNullOrEmpty(drThorax), "-", drThorax.Trim()))
        sb.AppendLine("----------------------------------------------------------------------")
        sb.AppendLine("• COR        : " & If(String.IsNullOrEmpty(cor), "-", cor.Trim()))
        sb.AppendLine("• PULMO      : " & If(String.IsNullOrEmpty(pulmo), "-", pulmo.Trim()))
        sb.AppendLine("• SINUS      : " & If(String.IsNullOrEmpty(sinus), "-", sinus.Trim()))
        sb.AppendLine("• SKELETAL   : " & If(String.IsNullOrEmpty(skeletal), "-", skeletal.Trim()))
        sb.AppendLine("----------------------------------------------------------------------")
        sb.AppendLine("KESIMPULAN   : " & If(String.IsNullOrEmpty(kesimpulan), "-", kesimpulan.Trim()))
        Return sb.ToString()
    End Function

    ' =========================================================================
    ' UX DOWNLOAD ASYNCHRONOUS PANEL KANAN (TERBARU)
    ' =========================================================================
    Private Sub btnLoadKanan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadKanan.Click
        If bgwKanan.IsBusy Then Return
        If String.IsNullOrEmpty(txtNik.Text.Trim()) Then
            MessageBox.Show("NIK Pasien belum diisi.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        btnLoadKanan.Enabled = False
        btnLoadKanan.Text = "Memuat..."
        lblStatusKanan.Text = "Mengambil citra & bacaan..."
        lblStatusKanan.ForeColor = Color.DeepSkyBlue

        If cmbTglKanan.SelectedItem Is Nothing Then Return
        Dim tglDipilih As String = cmbTglKanan.SelectedItem.ToString()
        Dim param() As String = {txtNik.Text.Trim(), tglDipilih}
        bgwKanan.RunWorkerAsync(param)
    End Sub

    Private Sub bgwKanan_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles bgwKanan.DoWork
        Dim param() As String = CType(e.Argument, String())
        Dim nik As String = param(0)
        Dim tgl As String = param(1)

        ' 1. Ambil Binary Gambar JPG Langsung (Tanpa Base64)
        Dim urlImg As String = String.Format("{0}/api/lab/thorax?nik={1}&tanggal={2}", baseURL, nik, tgl)
        Dim errImg As String = ""
        Dim img As Image = GetImageAPIRM(urlImg, errImg)

        ' 2. Ambil Teks Hasil Bacaan (JSON < 1 KB)
        Dim urlBacaan As String = String.Format("{0}/api/lab/thorax/bacaan?nik={1}&tanggal={2}", baseURL, nik, tgl)
        Dim jsonBacaan As String = GetDataAPIRM(urlBacaan)

        Dim bacaanRes As BacaanApiResponse = Nothing
        Try
            Dim serializer As New JavaScriptSerializer()
            bacaanRes = serializer.Deserialize(Of BacaanApiResponse)(jsonBacaan)
        Catch
        End Try

        e.Result = New Object() {img, errImg, bacaanRes}
    End Sub

    Private Sub bgwKanan_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles bgwKanan.RunWorkerCompleted
        btnLoadKanan.Enabled = True
        btnLoadKanan.Text = "Muat Gambar"

        Dim res() As Object = CType(e.Result, Object())
        Dim img As Image = CType(res(0), Image)
        Dim errImg As String = res(1).ToString()
        Dim bacaanRes As BacaanApiResponse = CType(res(2), BacaanApiResponse)

        ' Update PictureBox Kanan
        If img IsNot Nothing Then
            viewerKanan.SetImage(img)
            lblStatusKanan.Text = String.Format("Tampil ({0}x{1} px)", img.Width, img.Height)
            lblStatusKanan.ForeColor = Color.MediumSpringGreen
        Else
            viewerKanan.SetImage(Nothing)
            lblStatusKanan.Text = errImg
            lblStatusKanan.ForeColor = Color.Salmon
        End If

        ' Update TextBox Hasil Bacaan Kanan
        If bacaanRes IsNot Nothing AndAlso bacaanRes.status AndAlso bacaanRes.data IsNot Nothing Then
            txtHasilKanan.Text = FormatBacaanThorax( _
                bacaanRes.data.cor, _
                bacaanRes.data.pulmo, _
                bacaanRes.data.sinus, _
                bacaanRes.data.skeletal, _
                bacaanRes.data.kesimpulan, _
                bacaanRes.data.drthorax _
            )
        Else
            Dim msg As String = If(bacaanRes IsNot Nothing, bacaanRes.message, "Hasil bacaan tidak ditemukan")
            txtHasilKanan.Text = "HASIL BACAAN RADIOLOGI THORAX:" & vbCrLf & "--------------------------------------------------" & vbCrLf & msg
        End If
    End Sub

    ' =========================================================================
    ' UX SINKRONISASI ZOOM & GESER + TOMBOL RESET FIT
    ' =========================================================================
    Private Sub ViewerKiri_ViewChanged(ByVal sender As Object, ByVal e As EventArgs)
        If chkSyncZoom.Checked AndAlso Not _isSyncing Then
            _isSyncing = True
            viewerKanan.SyncFrom(viewerKiri)
            _isSyncing = False
        End If
    End Sub

    Private Sub ViewerKanan_ViewChanged(ByVal sender As Object, ByVal e As EventArgs)
        If chkSyncZoom.Checked AndAlso Not _isSyncing Then
            _isSyncing = True
            viewerKiri.SyncFrom(viewerKanan)
            _isSyncing = False
        End If
    End Sub

    Private Sub btnResetView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetView.Click
        If viewerKiri IsNot Nothing Then viewerKiri.ResetView()
        If viewerKanan IsNot Nothing Then viewerKanan.ResetView()
    End Sub

    Private Sub SplitContainer1_Panel1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles SplitContainer1.Panel1.Resize
        Dim lebarHeader As Integer = SplitContainer1.Panel1.ClientSize.Width
        If lebarHeader <= 0 Then Return

        Dim marginKanan As Integer = 16
        Dim jarakAntarKontrol As Integer = 12

        ' 1. Posisikan Button Reset paling kanan
        btnResetView.Left = lebarHeader - marginKanan - btnResetView.Width

        ' 2. Posisikan CheckBox "Zoom dan Geser" di sebelah kiri Button Reset
        chkSyncZoom.Left = btnResetView.Left - jarakAntarKontrol - chkSyncZoom.Width

        ' 3. Posisikan TextBox NIK Pasien di sebelah kiri CheckBox
        txtNik.Left = chkSyncZoom.Left - jarakAntarKontrol - txtNik.Width

        ' 4. Posisikan Label "NIK Pasien:" tepat di sebelah kiri TextBox NIK
        lblNik.Left = txtNik.Left - 6 - lblNik.Width
    End Sub

    Private Sub SplitContainer1_Panel2_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles SplitContainer1.Panel2.Resize
        Dim jarakTepi As Integer = 8   ' Margin luar kiri, kanan, atas, bawah
        Dim jarakTengah As Integer = 8 ' Jarak pemisah antara GroupBox kiri & kanan

        Dim totalLebar As Integer = SplitContainer1.Panel2.ClientSize.Width
        Dim totalTinggi As Integer = SplitContainer1.Panel2.ClientSize.Height

        If totalLebar <= 0 OrElse totalTinggi <= 0 Then Return

        ' 1. Atur ukuran & posisi GroupBox Kiri dan Kanan (50:50)
        Dim lebarPerBox As Integer = (totalLebar - (jarakTepi * 2) - jarakTengah) \ 2
        Dim tinggiBox As Integer = totalTinggi - (jarakTepi * 2)

        ' Ganti GroupBox1 & GroupBox2 sesuai nama GroupBox di form Anda
        GroupBox1.Location = New Point(jarakTepi, jarakTepi)
        GroupBox1.Size = New Size(lebarPerBox, tinggiBox)

        GroupBox2.Location = New Point(jarakTepi + lebarPerBox + jarakTengah, jarakTepi)
        GroupBox2.Size = New Size(lebarPerBox, tinggiBox)

        ' 2. Pembagian Tinggi PictureBox (Atas) & Panel Hasil Bacaan (Bawah)
        Dim paddingDalam As Integer = 10
        Dim posisiAtasPic As Integer = 58
        Dim tinggiPanelBacaan As Integer = 150 ' Tinggi area teks Cor, Pulmo, Kesan
        Dim jarakPicKeTeks As Integer = 8

        Dim lebarKonten As Integer = GroupBox1.ClientSize.Width - (paddingDalam * 2)
        Dim tinggiPic As Integer = GroupBox1.ClientSize.Height - posisiAtasPic - tinggiPanelBacaan - jarakPicKeTeks - paddingDalam
        If tinggiPic < 150 Then tinggiPic = 150

        ' Atur Panel Kiri
        picBoxKiri.Location = New Point(paddingDalam, posisiAtasPic)
        picBoxKiri.Size = New Size(lebarKonten, tinggiPic)

        txtHasilKiri.Location = New Point(paddingDalam, picBoxKiri.Bottom + jarakPicKeTeks)
        txtHasilKiri.Size = New Size(lebarKonten, tinggiPanelBacaan)

        ' Atur Panel Kanan
        picBoxKanan.Location = New Point(paddingDalam, posisiAtasPic)
        picBoxKanan.Size = New Size(lebarKonten, tinggiPic)

        txtHasilKanan.Location = New Point(paddingDalam, picBoxKanan.Bottom + jarakPicKeTeks)
        txtHasilKanan.Size = New Size(lebarKonten, tinggiPanelBacaan)
    End Sub
End Class

' =============================================================================
' CLASS HELPER: MENAMBAHKAN FITUR ZOOM, PAN & DOUBLE-CLICK FIT KE PICTUREBOX
' =============================================================================
Public Class PictureBoxZoomPan
    Private WithEvents _picBox As PictureBox
    Private _image As Image
    Private _zoom As Single = 1.0F
    Private _panOffset As New PointF(0, 0)
    Private _isDragging As Boolean = False
    Private _lastMousePos As Point

    Public Event ViewChanged As EventHandler

    Public Sub New(ByVal targetPictureBox As PictureBox)
        _picBox = targetPictureBox
        _picBox.Image = Nothing
        _picBox.BackColor = Color.Black
        _picBox.Cursor = Cursors.Hand
    End Sub

    Public Sub SetImage(ByVal img As Image)
        If _image IsNot Nothing Then _image.Dispose()
        _image = img
        ResetView()
    End Sub

    Public Sub ResetView()
        If _image IsNot Nothing AndAlso _picBox.Width > 0 AndAlso _picBox.Height > 0 Then
            Dim ratioX As Single = CSng(_picBox.Width) / CSng(_image.Width)
            Dim ratioY As Single = CSng(_picBox.Height) / CSng(_image.Height)
            _zoom = Math.Min(ratioX, ratioY) * 0.96F
            _panOffset = New PointF((_picBox.Width - (_image.Width * _zoom)) / 2.0F, (_picBox.Height - (_image.Height * _zoom)) / 2.0F)
        Else
            _zoom = 1.0F
            _panOffset = New PointF(0, 0)
        End If
        _picBox.Invalidate()
    End Sub

    Public Sub SyncFrom(ByVal source As PictureBoxZoomPan)
        Me._zoom = source._zoom
        Me._panOffset = source._panOffset
        _picBox.Invalidate()
    End Sub

    Private Sub _picBox_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles _picBox.Paint
        e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality

        If _image IsNot Nothing Then
            Dim drawWidth As Single = _image.Width * _zoom
            Dim drawHeight As Single = _image.Height * _zoom
            e.Graphics.DrawImage(_image, _panOffset.X, _panOffset.Y, drawWidth, drawHeight)

            ' Badge informasi zoom di pojok kiri bawah
            Dim info As String = String.Format("Zoom: {0}% | Scroll: Zoom | Drag: Geser | 2x Klik: Reset", CInt(_zoom * 100))
            Using bg As New SolidBrush(Color.FromArgb(170, 15, 23, 42))
                e.Graphics.FillRectangle(bg, 8, _picBox.Height - 28, 345, 22)
            End Using
            TextRenderer.DrawText(e.Graphics, info, New Font("Segoe UI", 8.0F), New Point(12, _picBox.Height - 24), Color.LightGray)
        End If
    End Sub

    Private Sub _picBox_MouseWheel(ByVal sender As Object, ByVal e As MouseEventArgs) Handles _picBox.MouseWheel
        If _image Is Nothing Then Return
        Dim oldZoom As Single = _zoom
        If e.Delta > 0 Then
            _zoom *= 1.15F
        Else
            _zoom /= 1.15F
        End If
        _zoom = Math.Max(0.1F, Math.Min(_zoom, 10.0F))

        ' Zoom fokus pada posisi kursor mouse
        _panOffset.X = e.X - ((e.X - _panOffset.X) * (_zoom / oldZoom))
        _panOffset.Y = e.Y - ((e.Y - _panOffset.Y) * (_zoom / oldZoom))

        _picBox.Invalidate()
        RaiseEvent ViewChanged(Me, EventArgs.Empty)
    End Sub

    Private Sub _picBox_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles _picBox.MouseDown
        _picBox.Focus() ' Wajib agar event MouseWheel terbaca di PictureBox VB.NET 2008
        If e.Button = MouseButtons.Left AndAlso _image IsNot Nothing Then
            _isDragging = True
            _lastMousePos = e.Location
            _picBox.Cursor = Cursors.SizeAll
        End If
    End Sub

    Private Sub _picBox_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles _picBox.MouseMove
        If _isDragging Then
            _panOffset.X += (e.X - _lastMousePos.X)
            _panOffset.Y += (e.Y - _lastMousePos.Y)
            _lastMousePos = e.Location
            _picBox.Invalidate()
            RaiseEvent ViewChanged(Me, EventArgs.Empty)
        End If
    End Sub

    Private Sub _picBox_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles _picBox.MouseUp
        _isDragging = False
        _picBox.Cursor = Cursors.Hand
    End Sub

    Private Sub _picBox_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles _picBox.DoubleClick
        ResetView()
        RaiseEvent ViewChanged(Me, EventArgs.Empty)
    End Sub

    Private Sub _picBox_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles _picBox.Resize
        If _image IsNot Nothing Then ResetView()
    End Sub
End Class