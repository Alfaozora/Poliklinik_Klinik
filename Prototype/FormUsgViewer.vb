Imports System.Net
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Web.Script.Serialization

Public Class FormUsgViewer

    Dim baseURL As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ws_RM'")

    ' --- Endpoint API USG (Laravel) ---
    Private Const ENDPOINT_USG_TGL As String = "/api/lab/usg/tanggal"
    Private Const ENDPOINT_USG_FILE As String = "/api/lab/usg"
    Private Const ENDPOINT_USG_BACAAN As String = "/api/lab/usg/bacaan"

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

    ' --- Daftar Riwayat Berkas USG ---
    Private _listRiwayat As New List(Of UsgItem)()

    ' --- Path File Sementara & BackgroundWorkers ---
    Private _tempFileKiri As String = ""
    Private _tempFileKanan As String = ""
    Private WithEvents bgwKiri As New BackgroundWorker()
    Private WithEvents bgwKanan As New BackgroundWorker()

    ' --- State Zoom & Pan ---
    Private _zoomKiri As Single = 1.0F
    Private _panKiri As PointF = PointF.Empty
    Private _isDraggingKiri As Boolean = False
    Private _lastMouseKiri As Point

    Private _zoomKanan As Single = 1.0F
    Private _panKanan As PointF = PointF.Empty
    Private _isDraggingKanan As Boolean = False
    Private _lastMouseKanan As Point

    ' --- Koleksi Citra USG & Index Aktif ---
    Private _pagesKiri As New List(Of Image)()
    Private _pageIndexKiri As Integer = 0

    Private _pagesKanan As New List(Of Image)()
    Private _pageIndexKanan As Integer = 0

    ' =========================================================================
    ' 1. FORM LOAD & INISIALISASI
    ' =========================================================================
    Private Sub FormUsgViewer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If baseURL Is Nothing Then baseURL = ""
        baseURL = baseURL.Trim().TrimEnd("/"c)
        Me.KeyPreview = True

        TerapkanTemaDark()

        picKiri.SizeMode = PictureBoxSizeMode.Normal
        picKiri.BackColor = Color.Black
        picKiri.Cursor = Cursors.Hand
        picKiri.Visible = True
        picKiri.BringToFront()
        picKiri.ContextMenuStrip = BuatContextMenuGambar(True)

        picKanan.SizeMode = PictureBoxSizeMode.Normal
        picKanan.BackColor = Color.Black
        picKanan.Cursor = Cursors.Hand
        picKanan.Visible = True
        picKanan.BringToFront()
        picKanan.ContextMenuStrip = BuatContextMenuGambar(False)

        btnEksternalKiri.Enabled = False
        btnEksternalKanan.Enabled = False

        If Not String.IsNullOrEmpty(_nikPasien) Then
            txtNik.Text = _nikPasien
        End If
        If Not String.IsNullOrEmpty(_namaPasien) Then
            lblPatientInfo.Text = "PASIEN: " & _namaPasien.ToUpper() & " [CITRA & HASIL USG]"
        End If

        SplitContainer1_Panel1_Resize(Nothing, EventArgs.Empty)
        SplitContainer1_Panel2_Resize(Nothing, EventArgs.Empty)

        If Not String.IsNullOrEmpty(txtNik.Text.Trim()) Then
            LoadDaftarTanggalUsg()
        End If
    End Sub

    Private Sub FormUsgViewer_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        If TypeOf Me.ActiveControl Is TextBox OrElse TypeOf Me.ActiveControl Is ComboBox Then Return

        If e.KeyCode = Keys.PageDown OrElse e.KeyCode = Keys.Right Then
            If picKiri.ClientRectangle.Contains(picKiri.PointToClient(Cursor.Position)) Then
                NextPageKiri_Click(Nothing, EventArgs.Empty)
            Else
                NextPageKanan_Click(Nothing, EventArgs.Empty)
            End If
            e.Handled = True
        ElseIf e.KeyCode = Keys.PageUp OrElse e.KeyCode = Keys.Left Then
            If picKiri.ClientRectangle.Contains(picKiri.PointToClient(Cursor.Position)) Then
                PrevPageKiri_Click(Nothing, EventArgs.Empty)
            Else
                PrevPageKanan_Click(Nothing, EventArgs.Empty)
            End If
            e.Handled = True
        End If
    End Sub

    Private Sub TerapkanTemaDark()
        Me.BackColor = Color.FromArgb(18, 22, 28)
        Me.ForeColor = Color.White

        SplitContainer1.Dock = DockStyle.Fill
        SplitContainer1.Panel1.BackColor = Color.FromArgb(28, 34, 44)
        SplitContainer1.Panel2.BackColor = Color.FromArgb(18, 22, 28)

        txtNik.BackColor = Color.FromArgb(15, 23, 42)
        txtNik.ForeColor = Color.White
        txtNik.BorderStyle = BorderStyle.FixedSingle

        btnCariNik.FlatStyle = FlatStyle.Flat
        btnCariNik.FlatAppearance.BorderSize = 0
        btnCariNik.BackColor = Color.FromArgb(2, 132, 199)
        btnCariNik.ForeColor = Color.White

        grpKiri.ForeColor = Color.FromArgb(251, 191, 36)
        AturStyleComboDark(cmbTglKiri)
        btnLoadKiri.FlatStyle = FlatStyle.Flat
        btnLoadKiri.FlatAppearance.BorderSize = 0
        btnLoadKiri.BackColor = Color.FromArgb(2, 132, 199)
        btnLoadKiri.ForeColor = Color.White
        btnEksternalKiri.FlatStyle = FlatStyle.Flat
        btnEksternalKiri.FlatAppearance.BorderSize = 0
        btnEksternalKiri.BackColor = Color.FromArgb(51, 65, 85)
        btnEksternalKiri.ForeColor = Color.White
        AturStyleHasilTextBox(txtHasilKiri)

        grpKanan.ForeColor = Color.FromArgb(52, 211, 153)
        AturStyleComboDark(cmbTglKanan)
        btnLoadKanan.FlatStyle = FlatStyle.Flat
        btnLoadKanan.FlatAppearance.BorderSize = 0
        btnLoadKanan.BackColor = Color.FromArgb(16, 185, 129)
        btnLoadKanan.ForeColor = Color.White
        btnEksternalKanan.FlatStyle = FlatStyle.Flat
        btnEksternalKanan.FlatAppearance.BorderSize = 0
        btnEksternalKanan.BackColor = Color.FromArgb(51, 65, 85)
        btnEksternalKanan.ForeColor = Color.White
        AturStyleHasilTextBox(txtHasilKanan)
    End Sub

    Private Sub AturStyleComboDark(ByVal cmb As ComboBox)
        cmb.DropDownStyle = ComboBoxStyle.DropDownList
        cmb.FlatStyle = FlatStyle.Flat
        cmb.DrawMode = DrawMode.OwnerDrawFixed
        cmb.ItemHeight = 22
        cmb.BackColor = Color.FromArgb(15, 23, 42)
        cmb.ForeColor = Color.White
    End Sub

    Private Sub AturStyleHasilTextBox(ByVal txt As TextBox)
        txt.Multiline = True
        txt.ReadOnly = True
        txt.ScrollBars = ScrollBars.Vertical
        txt.BackColor = Color.FromArgb(24, 30, 40)
        txt.ForeColor = Color.WhiteSmoke
        txt.BorderStyle = BorderStyle.FixedSingle
        txt.Font = New Font("Consolas", 9.0F, FontStyle.Regular)
    End Sub

    ' =========================================================================
    ' 2. TATA LETAK RESPONSIF
    ' =========================================================================
    Private Sub SplitContainer1_Panel1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles SplitContainer1.Panel1.Resize
        Dim lebarHeader As Integer = SplitContainer1.Panel1.ClientSize.Width
        If lebarHeader <= 0 Then Return

        Dim marginKanan As Integer = 16
        Dim jarakAntarKontrol As Integer = 10

        btnCariNik.Left = lebarHeader - marginKanan - btnCariNik.Width
        txtNik.Left = btnCariNik.Left - 8 - txtNik.Width
        lblNikCaption.Left = txtNik.Left - 6 - lblNikCaption.Width

        rbOffline.Left = lblNikCaption.Left - 18 - rbOffline.Width
        rbOnline.Left = rbOffline.Left - jarakAntarKontrol - rbOnline.Width
    End Sub

    Private Sub SplitContainer1_Panel2_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles SplitContainer1.Panel2.Resize
        Dim jarakTepi As Integer = 8
        Dim jarakTengah As Integer = 8

        Dim totalLebar As Integer = SplitContainer1.Panel2.ClientSize.Width
        Dim totalTinggi As Integer = SplitContainer1.Panel2.ClientSize.Height
        If totalLebar <= 0 OrElse totalTinggi <= 0 Then Return

        Dim lebarPerBox As Integer = (totalLebar - (jarakTepi * 2) - jarakTengah) \ 2
        Dim tinggiBox As Integer = totalTinggi - (jarakTepi * 2)

        grpKiri.Location = New Point(jarakTepi, jarakTepi)
        grpKiri.Size = New Size(lebarPerBox, tinggiBox)

        grpKanan.Location = New Point(jarakTepi + lebarPerBox + jarakTengah, jarakTepi)
        grpKanan.Size = New Size(lebarPerBox, tinggiBox)

        Dim padDalam As Integer = 10
        Dim topPic As Integer = 58
        Dim tinggiPanelHasil As Integer = 115
        Dim jarakPicKeTeks As Integer = 8

        Dim lebarKonten As Integer = grpKiri.ClientSize.Width - (padDalam * 2)
        Dim tinggiPic As Integer = grpKiri.ClientSize.Height - topPic - tinggiPanelHasil - jarakPicKeTeks - padDalam
        If tinggiPic < 150 Then tinggiPic = 150

        If lebarKonten > 0 Then
            picKiri.Location = New Point(padDalam, topPic)
            picKiri.Size = New Size(lebarKonten, tinggiPic)
            txtHasilKiri.Location = New Point(padDalam, picKiri.Bottom + jarakPicKeTeks)
            txtHasilKiri.Size = New Size(lebarKonten, tinggiPanelHasil)

            picKanan.Location = New Point(padDalam, topPic)
            picKanan.Size = New Size(lebarKonten, tinggiPic)
            txtHasilKanan.Location = New Point(padDalam, picKanan.Bottom + jarakPicKeTeks)
            txtHasilKanan.Size = New Size(lebarKonten, tinggiPanelHasil)

            picKiri.Invalidate()
            picKanan.Invalidate()
        End If
    End Sub

    ' =========================================================================
    ' 3. ENGINE NAVIGASI, ZOOM, PAN & ROTATE
    ' =========================================================================
    Private Function BuatContextMenuGambar(ByVal isKiri As Boolean) As ContextMenuStrip
        Dim cms As New ContextMenuStrip()
        Dim mnuPrev As New ToolStripMenuItem("◄ Citra Sebelumnya (PageUp)")
        Dim mnuNext As New ToolStripMenuItem("Citra Berikutnya (PageDown) ►")
        Dim mnuRotCW As New ToolStripMenuItem("Rotate 90° Kanan (CW)")
        Dim mnuRotCCW As New ToolStripMenuItem("Rotate 90° Kiri (CCW)")
        Dim mnuRot180 As New ToolStripMenuItem("Rotate 180°")
        Dim mnuReset As New ToolStripMenuItem("Reset Zoom & Posisi")

        If isKiri Then
            AddHandler mnuPrev.Click, AddressOf PrevPageKiri_Click
            AddHandler mnuNext.Click, AddressOf NextPageKiri_Click
            AddHandler mnuRotCW.Click, AddressOf RotasiKiriCW_Click
            AddHandler mnuRotCCW.Click, AddressOf RotasiKiriCCW_Click
            AddHandler mnuRot180.Click, AddressOf RotasiKiri180_Click
            AddHandler mnuReset.Click, AddressOf ResetKiri_Click
        Else
            AddHandler mnuPrev.Click, AddressOf PrevPageKanan_Click
            AddHandler mnuNext.Click, AddressOf NextPageKanan_Click
            AddHandler mnuRotCW.Click, AddressOf RotasiKananCW_Click
            AddHandler mnuRotCCW.Click, AddressOf RotasiKananCCW_Click
            AddHandler mnuRot180.Click, AddressOf RotasiKanan180_Click
            AddHandler mnuReset.Click, AddressOf ResetKanan_Click
        End If

        cms.Items.AddRange(New ToolStripItem() {mnuPrev, mnuNext, New ToolStripSeparator(), mnuRotCW, mnuRotCCW, mnuRot180, New ToolStripSeparator(), mnuReset})
        Return cms
    End Function

    Private Sub GantiHalaman(ByVal pic As PictureBox, ByVal pages As List(Of Image), ByRef pageIdx As Integer, ByVal delta As Integer, ByRef zoomVal As Single, ByRef panVal As PointF)
        If pages Is Nothing OrElse pages.Count <= 1 Then Return
        Dim newIdx As Integer = pageIdx + delta
        If newIdx < 0 Then newIdx = 0
        If newIdx >= pages.Count Then newIdx = pages.Count - 1

        If newIdx <> pageIdx Then
            pageIdx = newIdx
            pic.Image = pages(pageIdx)
            zoomVal = 1.0F
            panVal = PointF.Empty
            pic.Invalidate()
        End If
    End Sub

    Private Sub PrevPageKiri_Click(ByVal sender As Object, ByVal e As EventArgs)
        GantiHalaman(picKiri, _pagesKiri, _pageIndexKiri, -1, _zoomKiri, _panKiri)
    End Sub
    Private Sub NextPageKiri_Click(ByVal sender As Object, ByVal e As EventArgs)
        GantiHalaman(picKiri, _pagesKiri, _pageIndexKiri, 1, _zoomKiri, _panKiri)
    End Sub
    Private Sub PrevPageKanan_Click(ByVal sender As Object, ByVal e As EventArgs)
        GantiHalaman(picKanan, _pagesKanan, _pageIndexKanan, -1, _zoomKanan, _panKanan)
    End Sub
    Private Sub NextPageKanan_Click(ByVal sender As Object, ByVal e As EventArgs)
        GantiHalaman(picKanan, _pagesKanan, _pageIndexKanan, 1, _zoomKanan, _panKanan)
    End Sub

    Private Sub RotasiGambar(ByVal pic As PictureBox, ByVal rotType As RotateFlipType, ByRef zoomVal As Single, ByRef panVal As PointF)
        If pic.Image Is Nothing Then Return
        pic.Image.RotateFlip(rotType)
        zoomVal = 1.0F
        panVal = PointF.Empty
        pic.Invalidate()
    End Sub

    Private Sub RotasiKiriCW_Click(ByVal sender As Object, ByVal e As EventArgs)
        RotasiGambar(picKiri, RotateFlipType.Rotate90FlipNone, _zoomKiri, _panKiri)
    End Sub
    Private Sub RotasiKiriCCW_Click(ByVal sender As Object, ByVal e As EventArgs)
        RotasiGambar(picKiri, RotateFlipType.Rotate270FlipNone, _zoomKiri, _panKiri)
    End Sub
    Private Sub RotasiKiri180_Click(ByVal sender As Object, ByVal e As EventArgs)
        RotasiGambar(picKiri, RotateFlipType.Rotate180FlipNone, _zoomKiri, _panKiri)
    End Sub
    Private Sub ResetKiri_Click(ByVal sender As Object, ByVal e As EventArgs)
        _zoomKiri = 1.0F
        _panKiri = PointF.Empty
        picKiri.Invalidate()
    End Sub

    Private Sub RotasiKananCW_Click(ByVal sender As Object, ByVal e As EventArgs)
        RotasiGambar(picKanan, RotateFlipType.Rotate90FlipNone, _zoomKanan, _panKanan)
    End Sub
    Private Sub RotasiKananCCW_Click(ByVal sender As Object, ByVal e As EventArgs)
        RotasiGambar(picKanan, RotateFlipType.Rotate270FlipNone, _zoomKanan, _panKanan)
    End Sub
    Private Sub RotasiKanan180_Click(ByVal sender As Object, ByVal e As EventArgs)
        RotasiGambar(picKanan, RotateFlipType.Rotate180FlipNone, _zoomKanan, _panKanan)
    End Sub
    Private Sub ResetKanan_Click(ByVal sender As Object, ByVal e As EventArgs)
        _zoomKanan = 1.0F
        _panKanan = PointF.Empty
        picKanan.Invalidate()
    End Sub

    Private Sub RenderZoomPanImage(ByVal g As Graphics, ByVal pic As PictureBox, ByVal zoom As Single, ByVal pan As PointF)
        g.Clear(Color.Black)
        If pic.Image Is Nothing OrElse pic.ClientSize.Width <= 0 OrElse pic.ClientSize.Height <= 0 Then Return

        g.InterpolationMode = InterpolationMode.HighQualityBicubic
        g.PixelOffsetMode = PixelOffsetMode.HighQuality

        Dim ratioX As Single = CSng(pic.ClientSize.Width) / CSng(pic.Image.Width)
        Dim ratioY As Single = CSng(pic.ClientSize.Height) / CSng(pic.Image.Height)
        Dim baseScale As Single = Math.Min(ratioX, ratioY)
        Dim finalScale As Single = baseScale * zoom

        Dim drawW As Single = pic.Image.Width * finalScale
        Dim drawH As Single = pic.Image.Height * finalScale
        Dim offsetX As Single = ((pic.ClientSize.Width - drawW) / 2.0F) + pan.X
        Dim offsetY As Single = ((pic.ClientSize.Height - drawH) / 2.0F) + pan.Y

        g.DrawImage(pic.Image, offsetX, offsetY, drawW, drawH)

        Dim curPage As Integer = If(pic Is picKiri, _pageIndexKiri + 1, _pageIndexKanan + 1)
        Dim totPage As Integer = If(pic Is picKiri, _pagesKiri.Count, _pagesKanan.Count)

        Dim infoZoom As String = String.Format("Citra {0}/{1} | Zoom: {2}% | Scroll: Zoom • Geser: Drag • Klik Kanan: Menu", curPage, totPage, Math.Round(zoom * 100))
        Using bgTip As New SolidBrush(Color.FromArgb(180, 15, 23, 42))
            g.FillRectangle(bgTip, 6, 6, 480, 22)
        End Using
        TextRenderer.DrawText(g, infoZoom, New Font("Segoe UI", 8.0F, FontStyle.Bold), New Point(10, 9), Color.FromArgb(226, 232, 240))
    End Sub

    Private Sub HitungZoomMouse(ByVal pic As PictureBox, ByVal e As MouseEventArgs, ByRef zoom As Single, ByRef pan As PointF)
        If pic.Image Is Nothing Then Return
        Dim oldZoom As Single = zoom
        If e.Delta > 0 Then
            zoom = Math.Min(8.0F, zoom * 1.2F)
        Else
            zoom = Math.Max(0.5F, zoom / 1.2F)
        End If

        Dim scaleFactor As Single = zoom / oldZoom
        Dim cx As Single = pic.ClientSize.Width / 2.0F
        Dim cy As Single = pic.ClientSize.Height / 2.0F

        pan.X = (e.X - cx) - ((e.X - cx - pan.X) * scaleFactor)
        pan.Y = (e.Y - cy) - ((e.Y - cy - pan.Y) * scaleFactor)
        pic.Invalidate()
    End Sub

    Private Sub picKiri_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles picKiri.Paint
        RenderZoomPanImage(e.Graphics, picKiri, _zoomKiri, _panKiri)
    End Sub
    Private Sub picKiri_MouseEnter(ByVal sender As Object, ByVal e As EventArgs) Handles picKiri.MouseEnter
        picKiri.Focus()
    End Sub
    Private Sub picKiri_MouseWheel(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picKiri.MouseWheel
        HitungZoomMouse(picKiri, e, _zoomKiri, _panKiri)
    End Sub
    Private Sub picKiri_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picKiri.MouseDown
        If e.Button = MouseButtons.Left AndAlso picKiri.Image IsNot Nothing Then
            _isDraggingKiri = True
            _lastMouseKiri = e.Location
            picKiri.Cursor = Cursors.SizeAll
        End If
    End Sub
    Private Sub picKiri_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picKiri.MouseMove
        If _isDraggingKiri Then
            _panKiri.X += (e.X - _lastMouseKiri.X)
            _panKiri.Y += (e.Y - _lastMouseKiri.Y)
            _lastMouseKiri = e.Location
            picKiri.Invalidate()
        End If
    End Sub
    Private Sub picKiri_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picKiri.MouseUp
        If e.Button = MouseButtons.Left Then
            _isDraggingKiri = False
            picKiri.Cursor = Cursors.Hand
        End If
    End Sub
    Private Sub picKiri_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles picKiri.DoubleClick
        ResetKiri_Click(sender, e)
    End Sub

    Private Sub picKanan_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles picKanan.Paint
        RenderZoomPanImage(e.Graphics, picKanan, _zoomKanan, _panKanan)
    End Sub
    Private Sub picKanan_MouseEnter(ByVal sender As Object, ByVal e As EventArgs) Handles picKanan.MouseEnter
        picKanan.Focus()
    End Sub
    Private Sub picKanan_MouseWheel(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picKanan.MouseWheel
        HitungZoomMouse(picKanan, e, _zoomKanan, _panKanan)
    End Sub
    Private Sub picKanan_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picKanan.MouseDown
        If e.Button = MouseButtons.Left AndAlso picKanan.Image IsNot Nothing Then
            _isDraggingKanan = True
            _lastMouseKanan = e.Location
            picKanan.Cursor = Cursors.SizeAll
        End If
    End Sub
    Private Sub picKanan_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picKanan.MouseMove
        If _isDraggingKanan Then
            _panKanan.X += (e.X - _lastMouseKanan.X)
            _panKanan.Y += (e.Y - _lastMouseKanan.Y)
            _lastMouseKanan = e.Location
            picKanan.Invalidate()
        End If
    End Sub
    Private Sub picKanan_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles picKanan.MouseUp
        If e.Button = MouseButtons.Left Then
            _isDraggingKanan = False
            picKanan.Cursor = Cursors.Hand
        End If
    End Sub
    Private Sub picKanan_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles picKanan.DoubleClick
        ResetKanan_Click(sender, e)
    End Sub

    ' =========================================================================
    ' 4. CUSTOM DRAW COMBOBOX DARK-MODE
    ' =========================================================================
    Private Sub cmbTanggal_DrawItem(ByVal sender As Object, ByVal e As DrawItemEventArgs) Handles cmbTglKiri.DrawItem, cmbTglKanan.DrawItem
        Dim cmb As ComboBox = CType(sender, ComboBox)
        Dim bgColor As Color

        If (e.State And DrawItemState.Selected) = DrawItemState.Selected AndAlso (e.State And DrawItemState.ComboBoxEdit) <> DrawItemState.ComboBoxEdit Then
            bgColor = Color.FromArgb(2, 132, 199)
        Else
            bgColor = Color.FromArgb(15, 23, 42)
        End If

        Using bgBrush As New SolidBrush(bgColor)
            e.Graphics.FillRectangle(bgBrush, e.Bounds)
        End Using

        If e.Index >= 0 AndAlso e.Index < cmb.Items.Count Then
            Dim textItem As String = cmb.Items(e.Index).ToString()
            Dim textRect As New Rectangle(e.Bounds.X + 6, e.Bounds.Y, e.Bounds.Width - 6, e.Bounds.Height)
            TextRenderer.DrawText(e.Graphics, textItem, New Font("Segoe UI", 9.5F, FontStyle.Bold), textRect, Color.FromArgb(241, 245, 249), TextFormatFlags.VerticalCenter Or TextFormatFlags.Left)
        End If

        If (e.State And DrawItemState.ComboBoxEdit) = DrawItemState.ComboBoxEdit Then
            Using borderPen As New Pen(Color.FromArgb(51, 65, 85), 1)
                e.Graphics.DrawRectangle(borderPen, 0, 0, cmb.Width - 1, cmb.Height - 1)
            End Using
        End If
    End Sub

    ' =========================================================================
    ' 5. AMBIL DAFTAR TANGGAL & BERKAS USG DARI API
    ' =========================================================================
    Private Sub LoadDaftarTanggalUsg()
        Dim nik As String = txtNik.Text.Trim()
        If String.IsNullOrEmpty(nik) Then Return

        cmbTglKiri.Items.Clear()
        cmbTglKanan.Items.Clear()
        _listRiwayat.Clear()

        Dim url As String = String.Format("{0}{1}?nik={2}", baseURL, ENDPOINT_USG_TGL, nik)
        lblStatusKiri.Text = "Memuat daftar USG..."
        lblStatusKanan.Text = "Memuat daftar USG..."

        Dim jsonRaw As String = GetDataAPIRM(url)

        Try
            Dim serializer As New JavaScriptSerializer()
            Dim res As UsgListResponse = serializer.Deserialize(Of UsgListResponse)(jsonRaw)

            If res IsNot Nothing AndAlso res.status AndAlso res.data IsNot Nothing AndAlso res.data.Count > 0 Then
                If Not String.IsNullOrEmpty(res.data(0).nama) Then
                    _namaPasien = res.data(0).nama.Trim()
                    lblPatientInfo.Text = String.Format("PASIEN: {0} [CITRA & HASIL USG]", _namaPasien.ToUpper())
                End If

                For Each item As UsgItem In res.data
                    _listRiwayat.Add(item)
                    Dim labelTgl As String = If(Not String.IsNullOrEmpty(item.namatindakan), String.Format("{0} • {1}", item.tanggal, item.namatindakan.Trim()), item.tanggal)
                    cmbTglKiri.Items.Add(labelTgl)
                    cmbTglKanan.Items.Add(labelTgl)
                Next

                cmbTglKanan.SelectedIndex = 0
                cmbTglKiri.SelectedIndex = If(cmbTglKiri.Items.Count > 1, 1, 0)

                btnLoadKanan.PerformClick()
                If cmbTglKiri.Items.Count > 1 Then btnLoadKiri.PerformClick()
            Else
                lblStatusKiri.Text = "Tidak ada citra USG"
                lblStatusKanan.Text = "Tidak ada citra USG"
            End If
        Catch
            lblStatusKiri.Text = "Gagal memuat daftar USG"
            lblStatusKanan.Text = "Gagal memuat daftar USG"
        End Try
    End Sub

    Private Sub btnCariNik_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCariNik.Click
        LoadDaftarTanggalUsg()
    End Sub

    Private Sub txtNik_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles txtNik.KeyDown
        If e.KeyCode = Keys.Enter Then
            e.SuppressKeyPress = True
            LoadDaftarTanggalUsg()
        End If
    End Sub

    ' =========================================================================
    ' 6. UNDUH CITRA USG LANGSUNG SEBAGAI IMAGE (GetImageAPIRM)
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

    ' =========================================================================
    ' 7. AMBIL BACAAN USG & BACKGROUND WORKER PANEL KIRI / KANAN
    ' =========================================================================
    Private Function AmbilBacaanUsg(ByVal nik As String, ByVal tanggal As String) As String
        Try
            Dim url As String = String.Format("{0}{1}?nik={2}&tanggal={3}", baseURL, ENDPOINT_USG_BACAAN, Uri.EscapeDataString(nik), Uri.EscapeDataString(tanggal))
            Dim jsonRaw As String = GetDataAPIRM(url)
            Dim serializer As New JavaScriptSerializer()
            Dim res As BacaanUsgResponse = serializer.Deserialize(Of BacaanUsgResponse)(jsonRaw)

            If res IsNot Nothing AndAlso res.status AndAlso res.data IsNot Nothing AndAlso Not String.IsNullOrEmpty(res.data.kesimpulan) Then
                Return res.data.kesimpulan.Trim()
            End If
        Catch
        End Try
        Return "-"
    End Function

    Private Function BuildUrlBerkasUsg(ByVal item As UsgItem, ByVal nik As String) As String
        Return String.Format("{0}{1}?nik={2}&tanggal={3}", baseURL, ENDPOINT_USG_FILE, Uri.EscapeDataString(nik), Uri.EscapeDataString(item.tanggal))
    End Function

    Private Sub btnLoadKiri_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadKiri.Click
        If bgwKiri.IsBusy OrElse cmbTglKiri.SelectedIndex < 0 OrElse cmbTglKiri.SelectedIndex >= _listRiwayat.Count Then Return

        btnLoadKiri.Enabled = False
        btnLoadKiri.Text = "Memuat..."
        lblStatusKiri.Text = "Mengunduh citra USG..."
        lblStatusKiri.ForeColor = Color.DeepSkyBlue

        Dim nik As String = txtNik.Text.Trim()
        Dim item As UsgItem = _listRiwayat(cmbTglKiri.SelectedIndex)
        Dim url As String = BuildUrlBerkasUsg(item, nik)

        bgwKiri.RunWorkerAsync(New String() {url, item.tanggal, item.idlabinternet, item.namatindakan, nik})
    End Sub

    Private Sub bgwKiri_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles bgwKiri.DoWork
        Dim param() As String = CType(e.Argument, String())
        Dim err As String = ""
        Dim pages As New List(Of Image)()
        Dim pathFile As String = ""

        Dim imgUsg As Image = GetImageAPIRM(param(0), err)
        If imgUsg IsNot Nothing Then
            Try
                pathFile = Path.Combine(Path.GetTempPath(), String.Format("USG_KIRI_{0}.jpg", Guid.NewGuid().ToString("N")))
                imgUsg.Save(pathFile, ImageFormat.Jpeg)
            Catch
                pathFile = ""
            End Try
            pages.Add(imgUsg)
        End If

        Dim bacaan As String = AmbilBacaanUsg(param(4), param(1))
        e.Result = New Object() {pathFile, pages, err, param(1), param(2), param(3), bacaan}
    End Sub

    Private Sub bgwKiri_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles bgwKiri.RunWorkerCompleted
        btnLoadKiri.Enabled = True
        btnLoadKiri.Text = "Muat USG"

        Dim res() As Object = CType(e.Result, Object())
        Dim pathFile As String = res(0).ToString()
        Dim pages As List(Of Image) = CType(res(1), List(Of Image))
        Dim err As String = res(2).ToString()
        Dim tgl As String = res(3).ToString()
        Dim idLab As String = res(4).ToString()
        Dim namaTindakan As String = res(5).ToString()
        Dim bacaan As String = res(6).ToString()

        HapusFileTemp(_tempFileKiri)
        _tempFileKiri = pathFile

        For Each oldImg As Image In _pagesKiri
            oldImg.Dispose()
        Next
        _pagesKiri.Clear()
        picKiri.Image = Nothing

        If pages IsNot Nothing AndAlso pages.Count > 0 Then
            _pagesKiri = pages
            _pageIndexKiri = 0
            picKiri.Image = _pagesKiri(0)
            _zoomKiri = 1.0F
            _panKiri = PointF.Empty
            picKiri.Invalidate()

            Dim ukuranFile As Long = If(Not String.IsNullOrEmpty(pathFile) AndAlso File.Exists(pathFile), New FileInfo(pathFile).Length, 0)
            btnEksternalKiri.Enabled = (ukuranFile > 0)
            lblStatusKiri.Text = String.Format("Tampil ({0} Citra)", _pagesKiri.Count)
            lblStatusKiri.ForeColor = Color.MediumSpringGreen
            txtHasilKiri.Text = FormatInfoUsg(tgl, idLab, namaTindakan, ukuranFile, "Berhasil dimuat", bacaan)
        Else
            picKiri.Invalidate()
            btnEksternalKiri.Enabled = False
            lblStatusKiri.Text = err
            lblStatusKiri.ForeColor = Color.Salmon
            txtHasilKiri.Text = FormatInfoUsg(tgl, idLab, namaTindakan, 0, err, bacaan)
        End If
    End Sub

    Private Sub btnLoadKanan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadKanan.Click
        If bgwKanan.IsBusy OrElse cmbTglKanan.SelectedIndex < 0 OrElse cmbTglKanan.SelectedIndex >= _listRiwayat.Count Then Return

        btnLoadKanan.Enabled = False
        btnLoadKanan.Text = "Memuat..."
        lblStatusKanan.Text = "Mengunduh citra USG..."
        lblStatusKanan.ForeColor = Color.DeepSkyBlue

        Dim nik As String = txtNik.Text.Trim()
        Dim item As UsgItem = _listRiwayat(cmbTglKanan.SelectedIndex)
        Dim url As String = BuildUrlBerkasUsg(item, nik)

        bgwKanan.RunWorkerAsync(New String() {url, item.tanggal, item.idlabinternet, item.namatindakan, nik})
    End Sub

    Private Sub bgwKanan_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles bgwKanan.DoWork
        Dim param() As String = CType(e.Argument, String())
        Dim err As String = ""
        Dim pages As New List(Of Image)()
        Dim pathFile As String = ""

        Dim imgUsg As Image = GetImageAPIRM(param(0), err)
        If imgUsg IsNot Nothing Then
            Try
                pathFile = Path.Combine(Path.GetTempPath(), String.Format("USG_KANAN_{0}.jpg", Guid.NewGuid().ToString("N")))
                imgUsg.Save(pathFile, ImageFormat.Jpeg)
            Catch
                pathFile = ""
            End Try
            pages.Add(imgUsg)
        End If

        Dim bacaan As String = AmbilBacaanUsg(param(4), param(1))
        e.Result = New Object() {pathFile, pages, err, param(1), param(2), param(3), bacaan}
    End Sub

    Private Sub bgwKanan_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles bgwKanan.RunWorkerCompleted
        btnLoadKanan.Enabled = True
        btnLoadKanan.Text = "Muat USG"

        Dim res() As Object = CType(e.Result, Object())
        Dim pathFile As String = res(0).ToString()
        Dim pages As List(Of Image) = CType(res(1), List(Of Image))
        Dim err As String = res(2).ToString()
        Dim tgl As String = res(3).ToString()
        Dim idLab As String = res(4).ToString()
        Dim namaTindakan As String = res(5).ToString()
        Dim bacaan As String = res(6).ToString()

        HapusFileTemp(_tempFileKanan)
        _tempFileKanan = pathFile

        For Each oldImg As Image In _pagesKanan
            oldImg.Dispose()
        Next
        _pagesKanan.Clear()
        picKanan.Image = Nothing

        If pages IsNot Nothing AndAlso pages.Count > 0 Then
            _pagesKanan = pages
            _pageIndexKanan = 0
            picKanan.Image = _pagesKanan(0)
            _zoomKanan = 1.0F
            _panKanan = PointF.Empty
            picKanan.Invalidate()

            Dim ukuranFile As Long = If(Not String.IsNullOrEmpty(pathFile) AndAlso File.Exists(pathFile), New FileInfo(pathFile).Length, 0)
            btnEksternalKanan.Enabled = (ukuranFile > 0)
            lblStatusKanan.Text = String.Format("Tampil ({0} Citra)", _pagesKanan.Count)
            lblStatusKanan.ForeColor = Color.MediumSpringGreen
            txtHasilKanan.Text = FormatInfoUsg(tgl, idLab, namaTindakan, ukuranFile, "Berhasil dimuat", bacaan)
        Else
            picKanan.Invalidate()
            btnEksternalKanan.Enabled = False
            lblStatusKanan.Text = err
            lblStatusKanan.ForeColor = Color.Salmon
            txtHasilKanan.Text = FormatInfoUsg(tgl, idLab, namaTindakan, 0, err, bacaan)
        End If
    End Sub

    ' =========================================================================
    ' 8. FORMATTER INFO USG, BUKA EKSTERNAL & CLEANUP
    ' =========================================================================
    Private Function FormatInfoUsg(ByVal tanggal As String, ByVal idLab As String, ByVal namaTindakan As String, ByVal ukuranByte As Long, ByVal status As String, ByVal bacaan As String) As String
        Dim bacaanBersih As String = If(String.IsNullOrEmpty(bacaan), "-", bacaan.Replace(vbCrLf & vbCrLf, vbCrLf).Trim())
        Dim tindakanTampil As String = If(String.IsNullOrEmpty(namaTindakan), "USG", namaTindakan.Trim())

        Dim sb As New System.Text.StringBuilder()
        sb.AppendLine("PEMERIKSAAN USG (" & tanggal & " | ID Lab: " & If(String.IsNullOrEmpty(idLab), "-", idLab) & " | " & tindakanTampil & "):")
        sb.AppendLine("----------------------------------------------------------------------")
        sb.AppendLine(bacaanBersih)
        sb.AppendLine("----------------------------------------------------------------------")
        sb.AppendLine("• Status: " & status & " (" & Math.Round(ukuranByte / 1024.0, 1).ToString() & " KB)")
        Return sb.ToString()
    End Function

    Private Sub btnEksternalKiri_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEksternalKiri.Click
        If Not String.IsNullOrEmpty(_tempFileKiri) AndAlso File.Exists(_tempFileKiri) Then
            Process.Start(_tempFileKiri)
        End If
    End Sub

    Private Sub btnEksternalKanan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEksternalKanan.Click
        If Not String.IsNullOrEmpty(_tempFileKanan) AndAlso File.Exists(_tempFileKanan) Then
            Process.Start(_tempFileKanan)
        End If
    End Sub

    Private Sub HapusFileTemp(ByVal filePath As String)
        Try
            If Not String.IsNullOrEmpty(filePath) AndAlso File.Exists(filePath) Then
                File.Delete(filePath)
            End If
        Catch
        End Try
    End Sub

    Private Sub FormUsgViewer_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles Me.FormClosed
        For Each img As Image In _pagesKiri
            img.Dispose()
        Next
        _pagesKiri.Clear()

        For Each img As Image In _pagesKanan
            img.Dispose()
        Next
        _pagesKanan.Clear()

        HapusFileTemp(_tempFileKiri)
        HapusFileTemp(_tempFileKanan)
    End Sub
End Class

' =============================================================================
' CLASS MODEL JSON DAFTAR & BACAAN USG
' =============================================================================
Public Class UsgListResponse
    Public status As Boolean
    Public message As String
    Public data As List(Of UsgItem)
End Class

Public Class UsgItem
    Public tanggal As String
    Public idlabinternet As String
    Public namatindakan As String
    Public nama As String
End Class

Public Class BacaanUsgResponse
    Public status As Boolean
    Public message As String
    Public data As BacaanUsgData
End Class

Public Class BacaanUsgData
    Public idlabinternet As String
    Public dokter As String
    Public kesimpulan As String
End Class