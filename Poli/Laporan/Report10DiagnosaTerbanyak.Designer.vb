<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Report10DiagnosaTerbanyak
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Report10DiagnosaTerbanyak))
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.PanelTop = New System.Windows.Forms.Panel
        Me.btnClose = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ButtonCetakDiagnosa = New System.Windows.Forms.Button
        Me.ComboBoxIndikator = New System.Windows.Forms.ComboBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.ComboBoxTahun = New System.Windows.Forms.ComboBox
        Me.ComboBoxBulan = New System.Windows.Forms.ComboBox
        Me.ButtonSearchDiagnosa = New System.Windows.Forms.Button
        Me.ComboBoxTingkatPelayanan = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.ComboBoxPoliTujuan = New System.Windows.Forms.ComboBox
        Me.Label139 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer
        Me.DataGridViewDaftarDiagnosa = New System.Windows.Forms.DataGridView
        Me.PanelTop.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.DataGridViewDaftarDiagnosa, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Controls.Add(Me.ButtonCetakDiagnosa)
        Me.Panel1.Controls.Add(Me.ComboBoxIndikator)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.ComboBoxTahun)
        Me.Panel1.Controls.Add(Me.ComboBoxBulan)
        Me.Panel1.Controls.Add(Me.ButtonSearchDiagnosa)
        Me.Panel1.Controls.Add(Me.ComboBoxTingkatPelayanan)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.ComboBoxPoliTujuan)
        Me.Panel1.Controls.Add(Me.Label139)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1000, 200)
        Me.Panel1.TabIndex = 6
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
        Me.ButtonCetakDiagnosa.Location = New System.Drawing.Point(205, 153)
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
        'ComboBoxIndikator
        '
        Me.ComboBoxIndikator.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.ComboBoxIndikator.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBoxIndikator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxIndikator.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBoxIndikator.FormattingEnabled = True
        Me.ComboBoxIndikator.Items.AddRange(New Object() {"Semua", "Kunjungan", "Rujukan"})
        Me.ComboBoxIndikator.Location = New System.Drawing.Point(205, 88)
        Me.ComboBoxIndikator.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxIndikator.Name = "ComboBoxIndikator"
        Me.ComboBoxIndikator.Size = New System.Drawing.Size(125, 25)
        Me.ComboBoxIndikator.TabIndex = 519
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(104, 91)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 17)
        Me.Label10.TabIndex = 518
        Me.Label10.Text = "Indikator"
        '
        'ComboBoxTahun
        '
        Me.ComboBoxTahun.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.ComboBoxTahun.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBoxTahun.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxTahun.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBoxTahun.FormattingEnabled = True
        Me.ComboBoxTahun.Items.AddRange(New Object() {"Kunjungan Sakit", "Kunjungan Sehat"})
        Me.ComboBoxTahun.Location = New System.Drawing.Point(336, 24)
        Me.ComboBoxTahun.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxTahun.Name = "ComboBoxTahun"
        Me.ComboBoxTahun.Size = New System.Drawing.Size(125, 25)
        Me.ComboBoxTahun.TabIndex = 517
        '
        'ComboBoxBulan
        '
        Me.ComboBoxBulan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.ComboBoxBulan.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBoxBulan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxBulan.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBoxBulan.FormattingEnabled = True
        Me.ComboBoxBulan.Items.AddRange(New Object() {"Kunjungan Sakit", "Kunjungan Sehat"})
        Me.ComboBoxBulan.Location = New System.Drawing.Point(205, 24)
        Me.ComboBoxBulan.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxBulan.Name = "ComboBoxBulan"
        Me.ComboBoxBulan.Size = New System.Drawing.Size(125, 25)
        Me.ComboBoxBulan.TabIndex = 516
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
        Me.ButtonSearchDiagnosa.Location = New System.Drawing.Point(336, 153)
        Me.ButtonSearchDiagnosa.Name = "ButtonSearchDiagnosa"
        Me.ButtonSearchDiagnosa.Size = New System.Drawing.Size(125, 35)
        Me.ButtonSearchDiagnosa.TabIndex = 511
        Me.ButtonSearchDiagnosa.Text = " Cari Data"
        Me.ButtonSearchDiagnosa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonSearchDiagnosa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonSearchDiagnosa.UseVisualStyleBackColor = False
        '
        'ComboBoxTingkatPelayanan
        '
        Me.ComboBoxTingkatPelayanan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.ComboBoxTingkatPelayanan.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBoxTingkatPelayanan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxTingkatPelayanan.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBoxTingkatPelayanan.FormattingEnabled = True
        Me.ComboBoxTingkatPelayanan.Items.AddRange(New Object() {"Semua", "Rawat Jalan", "Rawat Inap", "Promotif Preventif"})
        Me.ComboBoxTingkatPelayanan.Location = New System.Drawing.Point(205, 55)
        Me.ComboBoxTingkatPelayanan.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxTingkatPelayanan.Name = "ComboBoxTingkatPelayanan"
        Me.ComboBoxTingkatPelayanan.Size = New System.Drawing.Size(125, 25)
        Me.ComboBoxTingkatPelayanan.TabIndex = 509
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(48, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 17)
        Me.Label2.TabIndex = 508
        Me.Label2.Text = "Tingkat Pelayanan"
        '
        'ComboBoxPoliTujuan
        '
        Me.ComboBoxPoliTujuan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.ComboBoxPoliTujuan.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBoxPoliTujuan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxPoliTujuan.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBoxPoliTujuan.FormattingEnabled = True
        Me.ComboBoxPoliTujuan.Location = New System.Drawing.Point(205, 121)
        Me.ComboBoxPoliTujuan.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxPoliTujuan.Name = "ComboBoxPoliTujuan"
        Me.ComboBoxPoliTujuan.Size = New System.Drawing.Size(256, 25)
        Me.ComboBoxPoliTujuan.TabIndex = 507
        '
        'Label139
        '
        Me.Label139.AutoSize = True
        Me.Label139.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label139.Location = New System.Drawing.Point(109, 124)
        Me.Label139.Name = "Label139"
        Me.Label139.Size = New System.Drawing.Size(58, 17)
        Me.Label139.TabIndex = 506
        Me.Label139.Text = "Layanan"
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
        Me.Label1.Size = New System.Drawing.Size(125, 17)
        Me.Label1.TabIndex = 450
        Me.Label1.Text = "Tanggal Kunjungan"
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
        'Report10DiagnosaTerbanyak
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
        Me.Name = "Report10DiagnosaTerbanyak"
        Me.PanelTop.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.ResumeLayout(False)
        CType(Me.DataGridViewDaftarDiagnosa, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxPoliTujuan As System.Windows.Forms.ComboBox
    Friend WithEvents Label139 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxTingkatPelayanan As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ButtonSearchDiagnosa As System.Windows.Forms.Button
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents DataGridViewDaftarDiagnosa As System.Windows.Forms.DataGridView
    Friend WithEvents ComboBoxTahun As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxBulan As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxIndikator As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ButtonCetakDiagnosa As System.Windows.Forms.Button
End Class
