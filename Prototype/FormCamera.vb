Imports AForge.Video
Imports AForge.Video.DirectShow
Imports System.IO

Public Class FormCamera
    Public IsPortrait As Boolean = False
    Private FilterInfoCollection As FilterInfoCollection
    Private FinalVideo As VideoCaptureDevice

    Private Sub FormCamera_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage

        ' Deteksi kamera terpasang
        FilterInfoCollection = New FilterInfoCollection(FilterCategory.VideoInputDevice)

        For Each VideoCaptureDevice As FilterInfo In FilterInfoCollection
            ComboBox1.Items.Add(VideoCaptureDevice.Name)
        Next

        If ComboBox1.Items.Count > 0 Then
            ComboBox1.SelectedIndex = 0
            ' Panggil manual agar ComboBox resolusi terisi saat pertama kali form terbuka
            LoadCameraResolutions(0)
        Else
            MessageBox.Show("Tidak ada kamera terdeteksi.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedIndex >= 0 Then
            LoadCameraResolutions(ComboBox1.SelectedIndex)
        End If
    End Sub

    ' Sub terpisah khusus untuk membaca dan mengisi daftar resolusi
    Private Sub LoadCameraResolutions(ByVal cameraIndex As Integer)
        cmbResolution.Items.Clear()

        Try
            Dim tempVideo As New VideoCaptureDevice(FilterInfoCollection(cameraIndex).MonikerString)

            ' Beberapa driver butuh pengecekan VideoCapabilities langsung
            Dim capabilities() As VideoCapabilities = tempVideo.VideoCapabilities

            ' Jika array resolusi ditemukan, masukkan ke ComboBox
            If capabilities IsNot Nothing AndAlso capabilities.Length > 0 Then
                For Each cap As VideoCapabilities In capabilities
                    Dim resText As String = cap.FrameSize.Width & " x " & cap.FrameSize.Height
                    cmbResolution.Items.Add(resText)
                Next

                ' Pilih resolusi tertinggi secara default
                cmbResolution.SelectedIndex = cmbResolution.Items.Count - 1
            Else
                ' Fallback jika driver kamera tidak melaporkan VideoCapabilities
                cmbResolution.Items.Add("Default Resolution")
                cmbResolution.SelectedIndex = 0
            End If
        Catch ex As Exception
            MessageBox.Show("Gagal membaca resolusi: " & ex.Message)
        End Try
    End Sub

    Private Sub btnStart_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        If ComboBox1.SelectedIndex >= 0 Then
            StopCamera()

            FinalVideo = New VideoCaptureDevice(FilterInfoCollection(ComboBox1.SelectedIndex).MonikerString)

            ' Apply resolusi yang dipilih dari cmbResolution
            If cmbResolution.SelectedIndex >= 0 Then
                FinalVideo.VideoResolution = FinalVideo.VideoCapabilities(cmbResolution.SelectedIndex)
            End If

            AddHandler FinalVideo.NewFrame, New NewFrameEventHandler(AddressOf FinalVideo_NewFrame)
            FinalVideo.Start()
        End If
    End Sub

    Private Sub rbOrientation_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbLandscape.CheckedChanged, rbPortrait.CheckedChanged
        If rbLandscape.Checked Then
            PictureBox1.Visible = True
            PictureBox2.Visible = False
        Else
            PictureBox1.Visible = False
            PictureBox2.Visible = True
        End If
    End Sub

    Private Sub FinalVideo_NewFrame(ByVal sender As Object, ByVal eventArgs As NewFrameEventArgs)
        ' Tentukan PictureBox mana yang sedang aktif
        Dim activePictureBox As PictureBox = If(rbLandscape.Checked, PictureBox1, PictureBox2)

        If activePictureBox.InvokeRequired Then
            activePictureBox.Invoke(New NewFrameEventHandler(AddressOf FinalVideo_NewFrame), New Object() {sender, eventArgs})
        Else
            Dim bitmap As Bitmap = DirectCast(eventArgs.Frame.Clone(), Bitmap)

            ' 1. Fitur Mirroring
            If chkMirror.Checked Then
                bitmap.RotateFlip(RotateFlipType.RotateNoneFlipX)
            End If

            ' 2. Proses pemotongan jika memilih mode Portrait
            Dim finalBitmap As Bitmap
            If rbPortrait.Checked Then
                ' Potong bagian tengah gambar menjadi tegak (rasio 3:4)
                Dim targetWidth As Integer = CInt(bitmap.Height * 3 / 4)
                Dim targetHeight As Integer = bitmap.Height
                Dim startX As Integer = (bitmap.Width - targetWidth) \ 2

                Dim cropArea As New Rectangle(startX, 0, targetWidth, targetHeight)
                finalBitmap = bitmap.Clone(cropArea, bitmap.PixelFormat)
                bitmap.Dispose()
            Else
                finalBitmap = bitmap
            End If

            ' 3. Tampilkan gambar pada PictureBox yang sedang aktif
            If activePictureBox.Image IsNot Nothing Then
                activePictureBox.Image.Dispose()
            End If

            activePictureBox.Image = finalBitmap
        End If
    End Sub

    Private Sub btnCapture_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapture.Click
        ' Ambil PictureBox yang sedang aktif dipajang di layar
        Dim activePictureBox As PictureBox = If(rbLandscape.Checked, PictureBox1, PictureBox2)

        If activePictureBox.Image IsNot Nothing Then
            ' 1. Kloning gambar dari PictureBox aktif
            Dim capturedBitmap As New Bitmap(activePictureBox.Image)

            ' 2. Buat folder temporary
            Dim tempFolder As String = Path.Combine(Application.StartupPath, "Temp")
            If Not Directory.Exists(tempFolder) Then
                Directory.CreateDirectory(tempFolder)
            End If

            ' 3. Simpan file foto temporary
            Dim tempPath As String = Path.Combine(tempFolder, "Cam_" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".jpg")
            capturedBitmap.Save(tempPath, System.Drawing.Imaging.ImageFormat.Jpeg)

            ' 4. Kirim ke FormMasterPasien
            If FormMasterPasien.PictureBoxFotoPasien.Image IsNot Nothing Then
                FormMasterPasien.PictureBoxFotoPasien.Image.Dispose()
            End If

            FormMasterPasien.PictureBoxFotoPasien.Image = Image.FromFile(tempPath)
            FormMasterPasien.PictureBoxFotoPasien.Tag = tempPath
            FormMasterPasien.PictureBoxFotoPasien.SizeMode = PictureBoxSizeMode.Zoom

            ' 5. Hentikan kamera dan tutup Form
            StopCamera()
            Me.Close()
        Else
            MessageBox.Show("Kamera belum aktif!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnStop_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        If FinalVideo IsNot Nothing AndAlso FinalVideo.IsRunning Then
            FinalVideo.SignalToStop()
            PictureBox1.Image = Nothing
            PictureBox2.Image = Nothing
        End If
    End Sub

    Private Sub StopCamera()
        If FinalVideo IsNot Nothing AndAlso FinalVideo.IsRunning Then
            FinalVideo.SignalToStop()
            FinalVideo = Nothing
        End If
    End Sub

    Private Sub FormCamera_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        StopCamera()
    End Sub

    Private Sub rbPortrait_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPortrait.CheckedChanged
        IsPortrait = rbPortrait.Checked
    End Sub
End Class