<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportLogPaketTindakan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportLogPaketTindakan))
        Me.PanelTop = New System.Windows.Forms.Panel
        Me.btnClose = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ButtonClearData = New System.Windows.Forms.Button
        Me.TextBoxNamaRekamMedis = New System.Windows.Forms.TextBox
        Me.Panel9 = New System.Windows.Forms.Panel
        Me.RadioButtonOptionPaketPerTindakan = New System.Windows.Forms.RadioButton
        Me.RadioButtonOptionPaketReguler = New System.Windows.Forms.RadioButton
        Me.Label54 = New System.Windows.Forms.Label
        Me.TglAkhirTransaksi = New System.Windows.Forms.DateTimePicker
        Me.TglAwalTransaksi = New System.Windows.Forms.DateTimePicker
        Me.ButtonCariPasien = New System.Windows.Forms.Button
        Me.TextBoxNomorRekamMedis = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.ButtonSearchRiwayatPaket = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.SplitContainerRiwayatPaket = New System.Windows.Forms.SplitContainer
        Me.GridControlRiwayatPaket = New DevExpress.XtraGrid.GridControl
        Me.GridViewRiwayatPaket = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.PanelTop.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel9.SuspendLayout()
        Me.SplitContainerRiwayatPaket.Panel1.SuspendLayout()
        Me.SplitContainerRiwayatPaket.Panel2.SuspendLayout()
        Me.SplitContainerRiwayatPaket.SuspendLayout()
        CType(Me.GridControlRiwayatPaket, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewRiwayatPaket, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Panel1.Controls.Add(Me.ButtonClearData)
        Me.Panel1.Controls.Add(Me.TextBoxNamaRekamMedis)
        Me.Panel1.Controls.Add(Me.Panel9)
        Me.Panel1.Controls.Add(Me.Label54)
        Me.Panel1.Controls.Add(Me.TglAkhirTransaksi)
        Me.Panel1.Controls.Add(Me.TglAwalTransaksi)
        Me.Panel1.Controls.Add(Me.ButtonCariPasien)
        Me.Panel1.Controls.Add(Me.TextBoxNomorRekamMedis)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.ButtonSearchRiwayatPaket)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1000, 200)
        Me.Panel1.TabIndex = 6
        '
        'ButtonClearData
        '
        Me.ButtonClearData.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonClearData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonClearData.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonClearData.FlatAppearance.BorderSize = 0
        Me.ButtonClearData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonClearData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonClearData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonClearData.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonClearData.ForeColor = System.Drawing.Color.White
        Me.ButtonClearData.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_clear_24
        Me.ButtonClearData.Location = New System.Drawing.Point(205, 147)
        Me.ButtonClearData.Name = "ButtonClearData"
        Me.ButtonClearData.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonClearData.Size = New System.Drawing.Size(125, 35)
        Me.ButtonClearData.TabIndex = 570
        Me.ButtonClearData.Text = " Clear Data"
        Me.ButtonClearData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonClearData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonClearData.UseVisualStyleBackColor = False
        '
        'TextBoxNamaRekamMedis
        '
        Me.TextBoxNamaRekamMedis.BackColor = System.Drawing.Color.White
        Me.TextBoxNamaRekamMedis.Cursor = System.Windows.Forms.Cursors.No
        Me.TextBoxNamaRekamMedis.Enabled = False
        Me.TextBoxNamaRekamMedis.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxNamaRekamMedis.Location = New System.Drawing.Point(205, 116)
        Me.TextBoxNamaRekamMedis.Name = "TextBoxNamaRekamMedis"
        Me.TextBoxNamaRekamMedis.Size = New System.Drawing.Size(327, 25)
        Me.TextBoxNamaRekamMedis.TabIndex = 567
        Me.TextBoxNamaRekamMedis.TabStop = False
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.Transparent
        Me.Panel9.Controls.Add(Me.RadioButtonOptionPaketPerTindakan)
        Me.Panel9.Controls.Add(Me.RadioButtonOptionPaketReguler)
        Me.Panel9.Location = New System.Drawing.Point(205, 54)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(327, 25)
        Me.Panel9.TabIndex = 565
        '
        'RadioButtonOptionPaketPerTindakan
        '
        Me.RadioButtonOptionPaketPerTindakan.AutoSize = True
        Me.RadioButtonOptionPaketPerTindakan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.RadioButtonOptionPaketPerTindakan.Location = New System.Drawing.Point(108, 3)
        Me.RadioButtonOptionPaketPerTindakan.Name = "RadioButtonOptionPaketPerTindakan"
        Me.RadioButtonOptionPaketPerTindakan.Size = New System.Drawing.Size(128, 19)
        Me.RadioButtonOptionPaketPerTindakan.TabIndex = 248
        Me.RadioButtonOptionPaketPerTindakan.Text = "Paket Per-Tindakan"
        Me.RadioButtonOptionPaketPerTindakan.UseVisualStyleBackColor = True
        '
        'RadioButtonOptionPaketReguler
        '
        Me.RadioButtonOptionPaketReguler.AutoSize = True
        Me.RadioButtonOptionPaketReguler.Checked = True
        Me.RadioButtonOptionPaketReguler.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.RadioButtonOptionPaketReguler.Location = New System.Drawing.Point(5, 3)
        Me.RadioButtonOptionPaketReguler.Name = "RadioButtonOptionPaketReguler"
        Me.RadioButtonOptionPaketReguler.Size = New System.Drawing.Size(97, 19)
        Me.RadioButtonOptionPaketReguler.TabIndex = 245
        Me.RadioButtonOptionPaketReguler.TabStop = True
        Me.RadioButtonOptionPaketReguler.Text = "Paket Reguler"
        Me.RadioButtonOptionPaketReguler.UseVisualStyleBackColor = True
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.BackColor = System.Drawing.Color.Transparent
        Me.Label54.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label54.Location = New System.Drawing.Point(357, 29)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(24, 15)
        Me.Label54.TabIndex = 547
        Me.Label54.Text = "s/d"
        '
        'TglAkhirTransaksi
        '
        Me.TglAkhirTransaksi.CalendarFont = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TglAkhirTransaksi.CustomFormat = "dd-MMM-yyyy"
        Me.TglAkhirTransaksi.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TglAkhirTransaksi.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TglAkhirTransaksi.Location = New System.Drawing.Point(382, 23)
        Me.TglAkhirTransaksi.Name = "TglAkhirTransaksi"
        Me.TglAkhirTransaksi.Size = New System.Drawing.Size(150, 25)
        Me.TglAkhirTransaksi.TabIndex = 546
        '
        'TglAwalTransaksi
        '
        Me.TglAwalTransaksi.CalendarFont = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TglAwalTransaksi.CustomFormat = "dd-MMM-yyyy"
        Me.TglAwalTransaksi.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TglAwalTransaksi.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TglAwalTransaksi.Location = New System.Drawing.Point(205, 23)
        Me.TglAwalTransaksi.Name = "TglAwalTransaksi"
        Me.TglAwalTransaksi.Size = New System.Drawing.Size(150, 25)
        Me.TglAwalTransaksi.TabIndex = 545
        '
        'ButtonCariPasien
        '
        Me.ButtonCariPasien.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCariPasien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonCariPasien.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonCariPasien.FlatAppearance.BorderSize = 0
        Me.ButtonCariPasien.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCariPasien.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonCariPasien.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCariPasien.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonCariPasien.ForeColor = System.Drawing.Color.White
        Me.ButtonCariPasien.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_search_16
        Me.ButtonCariPasien.Location = New System.Drawing.Point(336, 85)
        Me.ButtonCariPasien.Name = "ButtonCariPasien"
        Me.ButtonCariPasien.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonCariPasien.Size = New System.Drawing.Size(34, 25)
        Me.ButtonCariPasien.TabIndex = 529
        Me.ButtonCariPasien.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonCariPasien.UseVisualStyleBackColor = False
        '
        'TextBoxNomorRekamMedis
        '
        Me.TextBoxNomorRekamMedis.BackColor = System.Drawing.Color.White
        Me.TextBoxNomorRekamMedis.Cursor = System.Windows.Forms.Cursors.No
        Me.TextBoxNomorRekamMedis.Enabled = False
        Me.TextBoxNomorRekamMedis.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxNomorRekamMedis.Location = New System.Drawing.Point(205, 85)
        Me.TextBoxNomorRekamMedis.Name = "TextBoxNomorRekamMedis"
        Me.TextBoxNomorRekamMedis.Size = New System.Drawing.Size(125, 25)
        Me.TextBoxNomorRekamMedis.TabIndex = 528
        Me.TextBoxNomorRekamMedis.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(80, 88)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(87, 17)
        Me.Label10.TabIndex = 518
        Me.Label10.Text = "Nama Pasien"
        '
        'ButtonSearchRiwayatPaket
        '
        Me.ButtonSearchRiwayatPaket.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSearchRiwayatPaket.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonSearchRiwayatPaket.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonSearchRiwayatPaket.FlatAppearance.BorderSize = 0
        Me.ButtonSearchRiwayatPaket.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSearchRiwayatPaket.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonSearchRiwayatPaket.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSearchRiwayatPaket.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonSearchRiwayatPaket.ForeColor = System.Drawing.Color.White
        Me.ButtonSearchRiwayatPaket.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_view_24
        Me.ButtonSearchRiwayatPaket.Location = New System.Drawing.Point(336, 147)
        Me.ButtonSearchRiwayatPaket.Name = "ButtonSearchRiwayatPaket"
        Me.ButtonSearchRiwayatPaket.Size = New System.Drawing.Size(196, 35)
        Me.ButtonSearchRiwayatPaket.TabIndex = 511
        Me.ButtonSearchRiwayatPaket.Text = " Cari Data"
        Me.ButtonSearchRiwayatPaket.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonSearchRiwayatPaket.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonSearchRiwayatPaket.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(77, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 17)
        Me.Label2.TabIndex = 508
        Me.Label2.Text = "Jenis Laporan"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(83, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 17)
        Me.Label1.TabIndex = 450
        Me.Label1.Text = "Tgl Transaksi"
        '
        'SplitContainerRiwayatPaket
        '
        Me.SplitContainerRiwayatPaket.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerRiwayatPaket.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainerRiwayatPaket.IsSplitterFixed = True
        Me.SplitContainerRiwayatPaket.Location = New System.Drawing.Point(0, 35)
        Me.SplitContainerRiwayatPaket.Name = "SplitContainerRiwayatPaket"
        Me.SplitContainerRiwayatPaket.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerRiwayatPaket.Panel1
        '
        Me.SplitContainerRiwayatPaket.Panel1.AutoScroll = True
        Me.SplitContainerRiwayatPaket.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainerRiwayatPaket.Panel2
        '
        Me.SplitContainerRiwayatPaket.Panel2.AutoScroll = True
        Me.SplitContainerRiwayatPaket.Panel2.Controls.Add(Me.GridControlRiwayatPaket)
        Me.SplitContainerRiwayatPaket.Size = New System.Drawing.Size(1000, 540)
        Me.SplitContainerRiwayatPaket.SplitterDistance = 200
        Me.SplitContainerRiwayatPaket.SplitterWidth = 5
        Me.SplitContainerRiwayatPaket.TabIndex = 462
        '
        'GridControlRiwayatPaket
        '
        Me.GridControlRiwayatPaket.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControlRiwayatPaket.EmbeddedNavigator.Name = ""
        Me.GridControlRiwayatPaket.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GridControlRiwayatPaket.Location = New System.Drawing.Point(0, 0)
        Me.GridControlRiwayatPaket.MainView = Me.GridViewRiwayatPaket
        Me.GridControlRiwayatPaket.Name = "GridControlRiwayatPaket"
        Me.GridControlRiwayatPaket.Size = New System.Drawing.Size(1000, 335)
        Me.GridControlRiwayatPaket.TabIndex = 187
        Me.GridControlRiwayatPaket.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewRiwayatPaket})
        '
        'GridViewRiwayatPaket
        '
        Me.GridViewRiwayatPaket.GridControl = Me.GridControlRiwayatPaket
        Me.GridViewRiwayatPaket.Name = "GridViewRiwayatPaket"
        Me.GridViewRiwayatPaket.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridViewRiwayatPaket.OptionsView.ShowGroupPanel = False
        Me.GridViewRiwayatPaket.PaintStyleName = "Office2003"
        '
        'ReportLogPaketTindakan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1000, 575)
        Me.ControlBox = False
        Me.Controls.Add(Me.SplitContainerRiwayatPaket)
        Me.Controls.Add(Me.PanelTop)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ReportLogPaketTindakan"
        Me.PanelTop.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.SplitContainerRiwayatPaket.Panel1.ResumeLayout(False)
        Me.SplitContainerRiwayatPaket.Panel2.ResumeLayout(False)
        Me.SplitContainerRiwayatPaket.ResumeLayout(False)
        CType(Me.GridControlRiwayatPaket, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewRiwayatPaket, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ButtonSearchRiwayatPaket As System.Windows.Forms.Button
    Friend WithEvents SplitContainerRiwayatPaket As System.Windows.Forms.SplitContainer
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ButtonCariPasien As System.Windows.Forms.Button
    Friend WithEvents TextBoxNomorRekamMedis As System.Windows.Forms.TextBox
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents TglAkhirTransaksi As System.Windows.Forms.DateTimePicker
    Friend WithEvents TglAwalTransaksi As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents RadioButtonOptionPaketPerTindakan As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonOptionPaketReguler As System.Windows.Forms.RadioButton
    Private WithEvents GridControlRiwayatPaket As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewRiwayatPaket As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TextBoxNamaRekamMedis As System.Windows.Forms.TextBox
    Friend WithEvents ButtonClearData As System.Windows.Forms.Button
End Class
