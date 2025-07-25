<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRiwayatKunjungan
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormRiwayatKunjungan))
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.PanelTop = New System.Windows.Forms.Panel
        Me.btnClose = New System.Windows.Forms.Button
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBoxNoBPJS = New System.Windows.Forms.TextBox
        Me.TextBoxNoRM = New System.Windows.Forms.TextBox
        Me.ButtonFindPasien = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.TextBoxSearch = New System.Windows.Forms.TextBox
        Me.ButtonSearchDiagnosa = New System.Windows.Forms.Button
        Me.DataGridViewDaftarDiagnosa = New System.Windows.Forms.DataGridView
        Me.TextBoxNIK = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TextBoxNama = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.DateTimePickerTglLahir = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.PanelJenisKelamin = New System.Windows.Forms.Panel
        Me.RadioButtonJenisKelaminLaki = New System.Windows.Forms.RadioButton
        Me.RadioButtonJenisKelaminPerempuan = New System.Windows.Forms.RadioButton
        Me.Label7 = New System.Windows.Forms.Label
        Me.TextBoxNoIHS = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TextBoxUmur = New System.Windows.Forms.TextBox
        Me.PanelTop.SuspendLayout()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridViewDaftarDiagnosa, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelJenisKelamin.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.PanelTop.Controls.Add(Me.btnClose)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(1000, 35)
        Me.PanelTop.TabIndex = 5
        '
        'btnClose
        '
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(953, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(47, 35)
        Me.btnClose.TabIndex = 281
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer3.IsSplitterFixed = True
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 35)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.AutoScroll = True
        Me.SplitContainer3.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.AutoScroll = True
        Me.SplitContainer3.Panel2.Controls.Add(Me.DataGridViewDaftarDiagnosa)
        Me.SplitContainer3.Size = New System.Drawing.Size(1000, 540)
        Me.SplitContainer3.SplitterDistance = 200
        Me.SplitContainer3.SplitterWidth = 5
        Me.SplitContainer3.TabIndex = 462
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.TextBoxUmur)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.TextBoxNoIHS)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.PanelJenisKelamin)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.DateTimePickerTglLahir)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.TextBoxNama)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.TextBoxNIK)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.TextBoxNoBPJS)
        Me.Panel1.Controls.Add(Me.TextBoxNoRM)
        Me.Panel1.Controls.Add(Me.ButtonFindPasien)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.TextBoxSearch)
        Me.Panel1.Controls.Add(Me.ButtonSearchDiagnosa)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1000, 200)
        Me.Panel1.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(12, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 17)
        Me.Label2.TabIndex = 529
        Me.Label2.Text = "No. RM"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(12, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 17)
        Me.Label1.TabIndex = 528
        Me.Label1.Text = "NIK"
        '
        'TextBoxNoBPJS
        '
        Me.TextBoxNoBPJS.Location = New System.Drawing.Point(75, 41)
        Me.TextBoxNoBPJS.Name = "TextBoxNoBPJS"
        Me.TextBoxNoBPJS.Size = New System.Drawing.Size(193, 23)
        Me.TextBoxNoBPJS.TabIndex = 527
        '
        'TextBoxNoRM
        '
        Me.TextBoxNoRM.Location = New System.Drawing.Point(75, 12)
        Me.TextBoxNoRM.Name = "TextBoxNoRM"
        Me.TextBoxNoRM.Size = New System.Drawing.Size(193, 23)
        Me.TextBoxNoRM.TabIndex = 526
        '
        'ButtonFindPasien
        '
        Me.ButtonFindPasien.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindPasien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonFindPasien.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonFindPasien.FlatAppearance.BorderSize = 0
        Me.ButtonFindPasien.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindPasien.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonFindPasien.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonFindPasien.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonFindPasien.ForeColor = System.Drawing.Color.White
        Me.ButtonFindPasien.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_find_user_male_24
        Me.ButtonFindPasien.Location = New System.Drawing.Point(610, 10)
        Me.ButtonFindPasien.Name = "ButtonFindPasien"
        Me.ButtonFindPasien.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonFindPasien.Size = New System.Drawing.Size(120, 35)
        Me.ButtonFindPasien.TabIndex = 525
        Me.ButtonFindPasien.Text = " Cari Pasien"
        Me.ButtonFindPasien.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonFindPasien.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonFindPasien.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(14, 163)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 17)
        Me.Label3.TabIndex = 524
        Me.Label3.Text = "Cari"
        '
        'TextBoxSearch
        '
        Me.TextBoxSearch.Location = New System.Drawing.Point(45, 160)
        Me.TextBoxSearch.Name = "TextBoxSearch"
        Me.TextBoxSearch.Size = New System.Drawing.Size(158, 23)
        Me.TextBoxSearch.TabIndex = 523
        '
        'ButtonSearchDiagnosa
        '
        Me.ButtonSearchDiagnosa.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSearchDiagnosa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonSearchDiagnosa.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonSearchDiagnosa.FlatAppearance.BorderSize = 0
        Me.ButtonSearchDiagnosa.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSearchDiagnosa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonSearchDiagnosa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSearchDiagnosa.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonSearchDiagnosa.ForeColor = System.Drawing.Color.White
        Me.ButtonSearchDiagnosa.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_view_24
        Me.ButtonSearchDiagnosa.Location = New System.Drawing.Point(209, 155)
        Me.ButtonSearchDiagnosa.Name = "ButtonSearchDiagnosa"
        Me.ButtonSearchDiagnosa.Size = New System.Drawing.Size(144, 35)
        Me.ButtonSearchDiagnosa.TabIndex = 511
        Me.ButtonSearchDiagnosa.Text = " Cari Data"
        Me.ButtonSearchDiagnosa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonSearchDiagnosa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonSearchDiagnosa.UseVisualStyleBackColor = False
        '
        'DataGridViewDaftarDiagnosa
        '
        Me.DataGridViewDaftarDiagnosa.AllowUserToAddRows = False
        Me.DataGridViewDaftarDiagnosa.AllowUserToDeleteRows = False
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewDaftarDiagnosa.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridViewDaftarDiagnosa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridViewDaftarDiagnosa.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridViewDaftarDiagnosa.BackgroundColor = System.Drawing.Color.White
        Me.DataGridViewDaftarDiagnosa.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridViewDaftarDiagnosa.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DataGridViewDaftarDiagnosa.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(218, Byte), Integer))
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle10.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle10.Padding = New System.Windows.Forms.Padding(3)
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewDaftarDiagnosa.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewDaftarDiagnosa.ColumnHeadersHeight = 40
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.Padding = New System.Windows.Forms.Padding(3)
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(186, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(149, Byte), Integer))
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewDaftarDiagnosa.DefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridViewDaftarDiagnosa.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewDaftarDiagnosa.EnableHeadersVisualStyles = False
        Me.DataGridViewDaftarDiagnosa.Location = New System.Drawing.Point(0, 0)
        Me.DataGridViewDaftarDiagnosa.Name = "DataGridViewDaftarDiagnosa"
        Me.DataGridViewDaftarDiagnosa.ReadOnly = True
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle12.Padding = New System.Windows.Forms.Padding(3)
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewDaftarDiagnosa.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridViewDaftarDiagnosa.RowHeadersVisible = False
        Me.DataGridViewDaftarDiagnosa.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.DataGridViewDaftarDiagnosa.RowTemplate.Height = 35
        Me.DataGridViewDaftarDiagnosa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridViewDaftarDiagnosa.Size = New System.Drawing.Size(1000, 335)
        Me.DataGridViewDaftarDiagnosa.TabIndex = 517
        '
        'TextBoxNIK
        '
        Me.TextBoxNIK.Location = New System.Drawing.Point(75, 70)
        Me.TextBoxNIK.Name = "TextBoxNIK"
        Me.TextBoxNIK.Size = New System.Drawing.Size(193, 23)
        Me.TextBoxNIK.TabIndex = 530
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(12, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 17)
        Me.Label4.TabIndex = 531
        Me.Label4.Text = "No. BPJS"
        '
        'TextBoxNama
        '
        Me.TextBoxNama.Location = New System.Drawing.Point(75, 99)
        Me.TextBoxNama.Name = "TextBoxNama"
        Me.TextBoxNama.Size = New System.Drawing.Size(193, 23)
        Me.TextBoxNama.TabIndex = 532
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(13, 105)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 17)
        Me.Label5.TabIndex = 533
        Me.Label5.Text = "Nama"
        '
        'DateTimePickerTglLahir
        '
        Me.DateTimePickerTglLahir.CustomFormat = "dd-MMM-yyyy"
        Me.DateTimePickerTglLahir.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.DateTimePickerTglLahir.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerTglLahir.Location = New System.Drawing.Point(75, 128)
        Me.DateTimePickerTglLahir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DateTimePickerTglLahir.Name = "DateTimePickerTglLahir"
        Me.DateTimePickerTglLahir.Size = New System.Drawing.Size(93, 25)
        Me.DateTimePickerTglLahir.TabIndex = 534
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(12, 134)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 17)
        Me.Label6.TabIndex = 535
        Me.Label6.Text = "Tgl Lahir"
        '
        'PanelJenisKelamin
        '
        Me.PanelJenisKelamin.BackColor = System.Drawing.Color.Transparent
        Me.PanelJenisKelamin.Controls.Add(Me.RadioButtonJenisKelaminLaki)
        Me.PanelJenisKelamin.Controls.Add(Me.RadioButtonJenisKelaminPerempuan)
        Me.PanelJenisKelamin.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.PanelJenisKelamin.Location = New System.Drawing.Point(368, 10)
        Me.PanelJenisKelamin.Name = "PanelJenisKelamin"
        Me.PanelJenisKelamin.Size = New System.Drawing.Size(220, 25)
        Me.PanelJenisKelamin.TabIndex = 536
        '
        'RadioButtonJenisKelaminLaki
        '
        Me.RadioButtonJenisKelaminLaki.AutoSize = True
        Me.RadioButtonJenisKelaminLaki.Checked = True
        Me.RadioButtonJenisKelaminLaki.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonJenisKelaminLaki.Location = New System.Drawing.Point(5, 3)
        Me.RadioButtonJenisKelaminLaki.Name = "RadioButtonJenisKelaminLaki"
        Me.RadioButtonJenisKelaminLaki.Size = New System.Drawing.Size(72, 21)
        Me.RadioButtonJenisKelaminLaki.TabIndex = 245
        Me.RadioButtonJenisKelaminLaki.TabStop = True
        Me.RadioButtonJenisKelaminLaki.Text = "Laki-laki"
        Me.RadioButtonJenisKelaminLaki.UseVisualStyleBackColor = True
        '
        'RadioButtonJenisKelaminPerempuan
        '
        Me.RadioButtonJenisKelaminPerempuan.AutoSize = True
        Me.RadioButtonJenisKelaminPerempuan.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonJenisKelaminPerempuan.Location = New System.Drawing.Point(93, 3)
        Me.RadioButtonJenisKelaminPerempuan.Name = "RadioButtonJenisKelaminPerempuan"
        Me.RadioButtonJenisKelaminPerempuan.Size = New System.Drawing.Size(92, 21)
        Me.RadioButtonJenisKelaminPerempuan.TabIndex = 246
        Me.RadioButtonJenisKelaminPerempuan.Text = "Perempuan"
        Me.RadioButtonJenisKelaminPerempuan.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(274, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 17)
        Me.Label7.TabIndex = 537
        Me.Label7.Text = "Jenis Kelamin"
        '
        'TextBoxNoIHS
        '
        Me.TextBoxNoIHS.Location = New System.Drawing.Point(368, 40)
        Me.TextBoxNoIHS.Name = "TextBoxNoIHS"
        Me.TextBoxNoIHS.Size = New System.Drawing.Size(220, 23)
        Me.TextBoxNoIHS.TabIndex = 538
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(274, 42)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 17)
        Me.Label8.TabIndex = 539
        Me.Label8.Text = "No. IHS"
        '
        'TextBoxUmur
        '
        Me.TextBoxUmur.BackColor = System.Drawing.Color.White
        Me.TextBoxUmur.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxUmur.Location = New System.Drawing.Point(174, 128)
        Me.TextBoxUmur.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxUmur.Name = "TextBoxUmur"
        Me.TextBoxUmur.ReadOnly = True
        Me.TextBoxUmur.Size = New System.Drawing.Size(94, 25)
        Me.TextBoxUmur.TabIndex = 540
        '
        'FormRiwayatKunjungan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1000, 575)
        Me.ControlBox = False
        Me.Controls.Add(Me.SplitContainer3)
        Me.Controls.Add(Me.PanelTop)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormRiwayatKunjungan"
        Me.PanelTop.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataGridViewDaftarDiagnosa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelJenisKelamin.ResumeLayout(False)
        Me.PanelJenisKelamin.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents DataGridViewDaftarDiagnosa As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBoxSearch As System.Windows.Forms.TextBox
    Friend WithEvents ButtonSearchDiagnosa As System.Windows.Forms.Button
    Friend WithEvents ButtonFindPasien As System.Windows.Forms.Button
    Friend WithEvents TextBoxNoRM As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNoBPJS As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNIK As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNama As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerTglLahir As System.Windows.Forms.DateTimePicker
    Friend WithEvents PanelJenisKelamin As System.Windows.Forms.Panel
    Friend WithEvents RadioButtonJenisKelaminLaki As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonJenisKelaminPerempuan As System.Windows.Forms.RadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNoIHS As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxUmur As System.Windows.Forms.TextBox
End Class
