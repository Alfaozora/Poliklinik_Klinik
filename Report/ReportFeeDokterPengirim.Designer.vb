<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportFeeDokterPengirim
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportFeeDokterPengirim))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.PanelTop = New System.Windows.Forms.Panel
        Me.btnClose = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.CBOmset = New System.Windows.Forms.CheckBox
        Me.TextBoxIdKirim = New System.Windows.Forms.TextBox
        Me.ButtonFindDokter = New System.Windows.Forms.Button
        Me.TextBoxSearch = New System.Windows.Forms.TextBox
        Me.TextBoxNamaDokter = New System.Windows.Forms.TextBox
        Me.DateTimePickerAkhir = New System.Windows.Forms.DateTimePicker
        Me.DateTimePickerAwal = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.CBPilihSemua = New System.Windows.Forms.CheckBox
        Me.BtnExcel = New System.Windows.Forms.Button
        Me.ButtonCetakDiagnosa = New System.Windows.Forms.Button
        Me.ButtonSearchDiagnosa = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer
        Me.DataGridViewDaftarFeeDokterPengirim = New System.Windows.Forms.DataGridView
        Me.PanelTop.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.DataGridViewDaftarFeeDokterPengirim, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.CBOmset)
        Me.Panel1.Controls.Add(Me.TextBoxIdKirim)
        Me.Panel1.Controls.Add(Me.ButtonFindDokter)
        Me.Panel1.Controls.Add(Me.TextBoxSearch)
        Me.Panel1.Controls.Add(Me.TextBoxNamaDokter)
        Me.Panel1.Controls.Add(Me.DateTimePickerAkhir)
        Me.Panel1.Controls.Add(Me.DateTimePickerAwal)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.CBPilihSemua)
        Me.Panel1.Controls.Add(Me.BtnExcel)
        Me.Panel1.Controls.Add(Me.ButtonCetakDiagnosa)
        Me.Panel1.Controls.Add(Me.ButtonSearchDiagnosa)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1000, 200)
        Me.Panel1.TabIndex = 6
        '
        'CBOmset
        '
        Me.CBOmset.AutoSize = True
        Me.CBOmset.Location = New System.Drawing.Point(596, 128)
        Me.CBOmset.Name = "CBOmset"
        Me.CBOmset.Size = New System.Drawing.Size(94, 19)
        Me.CBOmset.TabIndex = 531
        Me.CBOmset.Text = "Cetak Omset"
        Me.CBOmset.UseVisualStyleBackColor = True
        '
        'TextBoxIdKirim
        '
        Me.TextBoxIdKirim.BackColor = System.Drawing.Color.White
        Me.TextBoxIdKirim.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxIdKirim.Location = New System.Drawing.Point(205, 58)
        Me.TextBoxIdKirim.Name = "TextBoxIdKirim"
        Me.TextBoxIdKirim.ReadOnly = True
        Me.TextBoxIdKirim.Size = New System.Drawing.Size(36, 25)
        Me.TextBoxIdKirim.TabIndex = 530
        '
        'ButtonFindDokter
        '
        Me.ButtonFindDokter.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindDokter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonFindDokter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonFindDokter.FlatAppearance.BorderSize = 0
        Me.ButtonFindDokter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindDokter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonFindDokter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonFindDokter.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonFindDokter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ButtonFindDokter.Location = New System.Drawing.Point(395, 58)
        Me.ButtonFindDokter.Name = "ButtonFindDokter"
        Me.ButtonFindDokter.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonFindDokter.Size = New System.Drawing.Size(66, 25)
        Me.ButtonFindDokter.TabIndex = 529
        Me.ButtonFindDokter.Text = " Cari"
        Me.ButtonFindDokter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonFindDokter.UseVisualStyleBackColor = False
        '
        'TextBoxSearch
        '
        Me.TextBoxSearch.BackColor = System.Drawing.Color.White
        Me.TextBoxSearch.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxSearch.Location = New System.Drawing.Point(205, 89)
        Me.TextBoxSearch.Name = "TextBoxSearch"
        Me.TextBoxSearch.Size = New System.Drawing.Size(184, 25)
        Me.TextBoxSearch.TabIndex = 528
        '
        'TextBoxNamaDokter
        '
        Me.TextBoxNamaDokter.BackColor = System.Drawing.Color.White
        Me.TextBoxNamaDokter.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxNamaDokter.Location = New System.Drawing.Point(247, 58)
        Me.TextBoxNamaDokter.Name = "TextBoxNamaDokter"
        Me.TextBoxNamaDokter.ReadOnly = True
        Me.TextBoxNamaDokter.Size = New System.Drawing.Size(142, 25)
        Me.TextBoxNamaDokter.TabIndex = 527
        '
        'DateTimePickerAkhir
        '
        Me.DateTimePickerAkhir.CalendarFont = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerAkhir.CustomFormat = "dd-MMM-yyyy"
        Me.DateTimePickerAkhir.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerAkhir.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerAkhir.Location = New System.Drawing.Point(336, 27)
        Me.DateTimePickerAkhir.Name = "DateTimePickerAkhir"
        Me.DateTimePickerAkhir.Size = New System.Drawing.Size(125, 25)
        Me.DateTimePickerAkhir.TabIndex = 526
        '
        'DateTimePickerAwal
        '
        Me.DateTimePickerAwal.CalendarFont = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerAwal.CustomFormat = "dd-MMM-yyyy"
        Me.DateTimePickerAwal.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerAwal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerAwal.Location = New System.Drawing.Point(205, 27)
        Me.DateTimePickerAwal.Name = "DateTimePickerAwal"
        Me.DateTimePickerAwal.Size = New System.Drawing.Size(125, 25)
        Me.DateTimePickerAwal.TabIndex = 525
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(42, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 17)
        Me.Label3.TabIndex = 524
        Me.Label3.Text = "Cari"
        '
        'CBPilihSemua
        '
        Me.CBPilihSemua.AutoSize = True
        Me.CBPilihSemua.Location = New System.Drawing.Point(596, 153)
        Me.CBPilihSemua.Name = "CBPilihSemua"
        Me.CBPilihSemua.Size = New System.Drawing.Size(88, 19)
        Me.CBPilihSemua.TabIndex = 522
        Me.CBPilihSemua.Text = "Pilih Semua"
        Me.CBPilihSemua.UseVisualStyleBackColor = True
        '
        'BtnExcel
        '
        Me.BtnExcel.BackColor = System.Drawing.Color.LimeGreen
        Me.BtnExcel.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExcel.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.BtnExcel.Location = New System.Drawing.Point(468, 130)
        Me.BtnExcel.Name = "BtnExcel"
        Me.BtnExcel.Size = New System.Drawing.Size(121, 36)
        Me.BtnExcel.TabIndex = 521
        Me.BtnExcel.Text = "Download Excel"
        Me.BtnExcel.UseVisualStyleBackColor = False
        '
        'ButtonCetakDiagnosa
        '
        Me.ButtonCetakDiagnosa.BackColor = System.Drawing.Color.White
        Me.ButtonCetakDiagnosa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonCetakDiagnosa.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonCetakDiagnosa.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCetakDiagnosa.FlatAppearance.BorderSize = 2
        Me.ButtonCetakDiagnosa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonCetakDiagnosa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCetakDiagnosa.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCetakDiagnosa.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCetakDiagnosa.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_print_24_outline_blue
        Me.ButtonCetakDiagnosa.Location = New System.Drawing.Point(206, 129)
        Me.ButtonCetakDiagnosa.Name = "ButtonCetakDiagnosa"
        Me.ButtonCetakDiagnosa.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonCetakDiagnosa.Size = New System.Drawing.Size(125, 35)
        Me.ButtonCetakDiagnosa.TabIndex = 520
        Me.ButtonCetakDiagnosa.TabStop = False
        Me.ButtonCetakDiagnosa.Text = " Cetak"
        Me.ButtonCetakDiagnosa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonCetakDiagnosa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonCetakDiagnosa.UseVisualStyleBackColor = False
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
        Me.ButtonSearchDiagnosa.Location = New System.Drawing.Point(337, 129)
        Me.ButtonSearchDiagnosa.Name = "ButtonSearchDiagnosa"
        Me.ButtonSearchDiagnosa.Size = New System.Drawing.Size(125, 35)
        Me.ButtonSearchDiagnosa.TabIndex = 511
        Me.ButtonSearchDiagnosa.Text = " Cari Data"
        Me.ButtonSearchDiagnosa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonSearchDiagnosa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonSearchDiagnosa.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(42, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(107, 17)
        Me.Label2.TabIndex = 508
        Me.Label2.Text = "Dokter Pengirim"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(333, 7)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 13)
        Me.Label9.TabIndex = 453
        Me.Label9.Text = "Tahun"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(202, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 13)
        Me.Label7.TabIndex = 451
        Me.Label7.Text = "Bulan"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(42, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 17)
        Me.Label1.TabIndex = 450
        Me.Label1.Text = "Tanggal"
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
        Me.SplitContainer3.Panel2.Controls.Add(Me.DataGridViewDaftarFeeDokterPengirim)
        Me.SplitContainer3.Size = New System.Drawing.Size(1000, 540)
        Me.SplitContainer3.SplitterDistance = 200
        Me.SplitContainer3.SplitterWidth = 5
        Me.SplitContainer3.TabIndex = 462
        '
        'DataGridViewDaftarFeeDokterPengirim
        '
        Me.DataGridViewDaftarFeeDokterPengirim.AllowUserToAddRows = False
        Me.DataGridViewDaftarFeeDokterPengirim.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridViewDaftarFeeDokterPengirim.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewDaftarFeeDokterPengirim.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridViewDaftarFeeDokterPengirim.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridViewDaftarFeeDokterPengirim.BackgroundColor = System.Drawing.Color.White
        Me.DataGridViewDaftarFeeDokterPengirim.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridViewDaftarFeeDokterPengirim.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DataGridViewDaftarFeeDokterPengirim.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(160, Byte), Integer), CType(CType(218, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Padding = New System.Windows.Forms.Padding(3)
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewDaftarFeeDokterPengirim.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewDaftarFeeDokterPengirim.ColumnHeadersHeight = 40
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.Padding = New System.Windows.Forms.Padding(3)
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(186, Byte), Integer), CType(CType(191, Byte), Integer), CType(CType(149, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewDaftarFeeDokterPengirim.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewDaftarFeeDokterPengirim.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewDaftarFeeDokterPengirim.EnableHeadersVisualStyles = False
        Me.DataGridViewDaftarFeeDokterPengirim.Location = New System.Drawing.Point(0, 0)
        Me.DataGridViewDaftarFeeDokterPengirim.Name = "DataGridViewDaftarFeeDokterPengirim"
        Me.DataGridViewDaftarFeeDokterPengirim.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        DataGridViewCellStyle4.Padding = New System.Windows.Forms.Padding(3)
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewDaftarFeeDokterPengirim.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewDaftarFeeDokterPengirim.RowHeadersVisible = False
        Me.DataGridViewDaftarFeeDokterPengirim.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.DataGridViewDaftarFeeDokterPengirim.RowTemplate.Height = 35
        Me.DataGridViewDaftarFeeDokterPengirim.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridViewDaftarFeeDokterPengirim.Size = New System.Drawing.Size(1000, 335)
        Me.DataGridViewDaftarFeeDokterPengirim.TabIndex = 517
        '
        'ReportFeeDokterPengirim
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
        Me.Name = "ReportFeeDokterPengirim"
        Me.PanelTop.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.ResumeLayout(False)
        CType(Me.DataGridViewDaftarFeeDokterPengirim, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ButtonSearchDiagnosa As System.Windows.Forms.Button
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents DataGridViewDaftarFeeDokterPengirim As System.Windows.Forms.DataGridView
    Friend WithEvents ButtonCetakDiagnosa As System.Windows.Forms.Button
    Friend WithEvents BtnExcel As System.Windows.Forms.Button
    Friend WithEvents CBPilihSemua As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerAkhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePickerAwal As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextBoxSearch As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxNamaDokter As System.Windows.Forms.TextBox
    Friend WithEvents ButtonFindDokter As System.Windows.Forms.Button
    Friend WithEvents TextBoxIdKirim As System.Windows.Forms.TextBox
    Friend WithEvents CBOmset As System.Windows.Forms.CheckBox
End Class
