<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormUploadDataOmset
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormUploadDataOmset))
        Me.PanelTop = New System.Windows.Forms.Panel
        Me.ButtonClose = New System.Windows.Forms.Button
        Me.PanelFormUploadDataOmset = New System.Windows.Forms.Panel
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.DateTimePickerTanggalTransaksiAkhir = New System.Windows.Forms.DateTimePicker
        Me.LabelProgress = New System.Windows.Forms.Label
        Me.ButtonKirimJurnalUlang = New System.Windows.Forms.Button
        Me.ButtonKirimDataOmset = New System.Windows.Forms.Button
        Me.ButtonSearchDataOmset = New System.Windows.Forms.Button
        Me.ProgressBarUpload = New System.Windows.Forms.ProgressBar
        Me.DateTimePickerTanggalTransaksiAwal = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.GridControlTransaksi = New DevExpress.XtraGrid.GridControl
        Me.GridViewTransaksi = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.PanelTop.SuspendLayout()
        Me.PanelFormUploadDataOmset.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.GridControlTransaksi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewTransaksi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.PanelTop.Controls.Add(Me.ButtonClose)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(1000, 35)
        Me.PanelTop.TabIndex = 464
        '
        'ButtonClose
        '
        Me.ButtonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.ButtonClose.FlatAppearance.BorderSize = 0
        Me.ButtonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonClose.Image = CType(resources.GetObject("ButtonClose.Image"), System.Drawing.Image)
        Me.ButtonClose.Location = New System.Drawing.Point(960, 0)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(40, 35)
        Me.ButtonClose.TabIndex = 281
        Me.ButtonClose.UseVisualStyleBackColor = True
        '
        'PanelFormUploadDataOmset
        '
        Me.PanelFormUploadDataOmset.Controls.Add(Me.SplitContainer1)
        Me.PanelFormUploadDataOmset.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelFormUploadDataOmset.Location = New System.Drawing.Point(0, 35)
        Me.PanelFormUploadDataOmset.Name = "PanelFormUploadDataOmset"
        Me.PanelFormUploadDataOmset.Size = New System.Drawing.Size(1000, 665)
        Me.PanelFormUploadDataOmset.TabIndex = 465
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GridControlTransaksi)
        Me.SplitContainer1.Size = New System.Drawing.Size(1000, 665)
        Me.SplitContainer1.SplitterDistance = 125
        Me.SplitContainer1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.DateTimePickerTanggalTransaksiAkhir)
        Me.Panel1.Controls.Add(Me.LabelProgress)
        Me.Panel1.Controls.Add(Me.ButtonKirimJurnalUlang)
        Me.Panel1.Controls.Add(Me.ButtonKirimDataOmset)
        Me.Panel1.Controls.Add(Me.ButtonSearchDataOmset)
        Me.Panel1.Controls.Add(Me.ProgressBarUpload)
        Me.Panel1.Controls.Add(Me.DateTimePickerTanggalTransaksiAwal)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1000, 125)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(287, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 17)
        Me.Label1.TabIndex = 548
        Me.Label1.Text = "s/d"
        '
        'DateTimePickerTanggalTransaksiAkhir
        '
        Me.DateTimePickerTanggalTransaksiAkhir.CalendarFont = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerTanggalTransaksiAkhir.CustomFormat = "dd-MMM-yyyy"
        Me.DateTimePickerTanggalTransaksiAkhir.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerTanggalTransaksiAkhir.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerTanggalTransaksiAkhir.Location = New System.Drawing.Point(320, 14)
        Me.DateTimePickerTanggalTransaksiAkhir.Name = "DateTimePickerTanggalTransaksiAkhir"
        Me.DateTimePickerTanggalTransaksiAkhir.Size = New System.Drawing.Size(150, 25)
        Me.DateTimePickerTanggalTransaksiAkhir.TabIndex = 547
        '
        'LabelProgress
        '
        Me.LabelProgress.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelProgress.ForeColor = System.Drawing.Color.Black
        Me.LabelProgress.Location = New System.Drawing.Point(496, 25)
        Me.LabelProgress.Name = "LabelProgress"
        Me.LabelProgress.Size = New System.Drawing.Size(248, 17)
        Me.LabelProgress.TabIndex = 546
        Me.LabelProgress.Text = "Progress"
        Me.LabelProgress.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ButtonKirimJurnalUlang
        '
        Me.ButtonKirimJurnalUlang.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonKirimJurnalUlang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonKirimJurnalUlang.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonKirimJurnalUlang.FlatAppearance.BorderSize = 0
        Me.ButtonKirimJurnalUlang.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonKirimJurnalUlang.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonKirimJurnalUlang.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonKirimJurnalUlang.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonKirimJurnalUlang.ForeColor = System.Drawing.Color.White
        Me.ButtonKirimJurnalUlang.Image = CType(resources.GetObject("ButtonKirimJurnalUlang.Image"), System.Drawing.Image)
        Me.ButtonKirimJurnalUlang.Location = New System.Drawing.Point(338, 56)
        Me.ButtonKirimJurnalUlang.Name = "ButtonKirimJurnalUlang"
        Me.ButtonKirimJurnalUlang.Size = New System.Drawing.Size(150, 35)
        Me.ButtonKirimJurnalUlang.TabIndex = 545
        Me.ButtonKirimJurnalUlang.Text = " Kirim Jurnal Ulang"
        Me.ButtonKirimJurnalUlang.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonKirimJurnalUlang.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonKirimJurnalUlang.UseVisualStyleBackColor = False
        Me.ButtonKirimJurnalUlang.Visible = False
        '
        'ButtonKirimDataOmset
        '
        Me.ButtonKirimDataOmset.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonKirimDataOmset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonKirimDataOmset.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonKirimDataOmset.FlatAppearance.BorderSize = 0
        Me.ButtonKirimDataOmset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonKirimDataOmset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonKirimDataOmset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonKirimDataOmset.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonKirimDataOmset.ForeColor = System.Drawing.Color.White
        Me.ButtonKirimDataOmset.Image = CType(resources.GetObject("ButtonKirimDataOmset.Image"), System.Drawing.Image)
        Me.ButtonKirimDataOmset.Location = New System.Drawing.Point(182, 56)
        Me.ButtonKirimDataOmset.Name = "ButtonKirimDataOmset"
        Me.ButtonKirimDataOmset.Size = New System.Drawing.Size(150, 35)
        Me.ButtonKirimDataOmset.TabIndex = 544
        Me.ButtonKirimDataOmset.Text = " Kirim Omset"
        Me.ButtonKirimDataOmset.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonKirimDataOmset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonKirimDataOmset.UseVisualStyleBackColor = False
        '
        'ButtonSearchDataOmset
        '
        Me.ButtonSearchDataOmset.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSearchDataOmset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonSearchDataOmset.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonSearchDataOmset.FlatAppearance.BorderSize = 0
        Me.ButtonSearchDataOmset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSearchDataOmset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonSearchDataOmset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSearchDataOmset.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonSearchDataOmset.ForeColor = System.Drawing.Color.White
        Me.ButtonSearchDataOmset.Image = CType(resources.GetObject("ButtonSearchDataOmset.Image"), System.Drawing.Image)
        Me.ButtonSearchDataOmset.Location = New System.Drawing.Point(26, 56)
        Me.ButtonSearchDataOmset.Name = "ButtonSearchDataOmset"
        Me.ButtonSearchDataOmset.Size = New System.Drawing.Size(150, 35)
        Me.ButtonSearchDataOmset.TabIndex = 543
        Me.ButtonSearchDataOmset.Text = " Search Data"
        Me.ButtonSearchDataOmset.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonSearchDataOmset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonSearchDataOmset.UseVisualStyleBackColor = False
        '
        'ProgressBarUpload
        '
        Me.ProgressBarUpload.BackColor = System.Drawing.Color.Lime
        Me.ProgressBarUpload.Location = New System.Drawing.Point(26, 45)
        Me.ProgressBarUpload.Name = "ProgressBarUpload"
        Me.ProgressBarUpload.Size = New System.Drawing.Size(718, 5)
        Me.ProgressBarUpload.TabIndex = 542
        '
        'DateTimePickerTanggalTransaksiAwal
        '
        Me.DateTimePickerTanggalTransaksiAwal.CalendarFont = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerTanggalTransaksiAwal.CustomFormat = "dd-MMM-yyyy"
        Me.DateTimePickerTanggalTransaksiAwal.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerTanggalTransaksiAwal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerTanggalTransaksiAwal.Location = New System.Drawing.Point(131, 14)
        Me.DateTimePickerTanggalTransaksiAwal.Name = "DateTimePickerTanggalTransaksiAwal"
        Me.DateTimePickerTanggalTransaksiAwal.Size = New System.Drawing.Size(150, 25)
        Me.DateTimePickerTanggalTransaksiAwal.TabIndex = 541
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(23, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 17)
        Me.Label4.TabIndex = 540
        Me.Label4.Text = "Tgl Transaksi"
        '
        'GridControlTransaksi
        '
        Me.GridControlTransaksi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControlTransaksi.EmbeddedNavigator.Name = ""
        Me.GridControlTransaksi.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GridControlTransaksi.Location = New System.Drawing.Point(0, 0)
        Me.GridControlTransaksi.MainView = Me.GridViewTransaksi
        Me.GridControlTransaksi.Name = "GridControlTransaksi"
        Me.GridControlTransaksi.Size = New System.Drawing.Size(1000, 536)
        Me.GridControlTransaksi.TabIndex = 187
        Me.GridControlTransaksi.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewTransaksi})
        '
        'GridViewTransaksi
        '
        Me.GridViewTransaksi.GridControl = Me.GridControlTransaksi
        Me.GridViewTransaksi.Name = "GridViewTransaksi"
        Me.GridViewTransaksi.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridViewTransaksi.OptionsView.ShowGroupPanel = False
        Me.GridViewTransaksi.OptionsView.ShowIndicator = False
        Me.GridViewTransaksi.PaintStyleName = "Skin"
        '
        'FormUploadDataOmset
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1000, 700)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelFormUploadDataOmset)
        Me.Controls.Add(Me.PanelTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormUploadDataOmset"
        Me.PanelTop.ResumeLayout(False)
        Me.PanelFormUploadDataOmset.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.GridControlTransaksi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewTransaksi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents ButtonClose As System.Windows.Forms.Button
    Friend WithEvents PanelFormUploadDataOmset As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Private WithEvents GridControlTransaksi As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewTransaksi As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents DateTimePickerTanggalTransaksiAwal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ProgressBarUpload As System.Windows.Forms.ProgressBar
    Friend WithEvents ButtonSearchDataOmset As System.Windows.Forms.Button
    Friend WithEvents ButtonKirimDataOmset As System.Windows.Forms.Button
    Friend WithEvents ButtonKirimJurnalUlang As System.Windows.Forms.Button
    Friend WithEvents LabelProgress As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerTanggalTransaksiAkhir As System.Windows.Forms.DateTimePicker
End Class
