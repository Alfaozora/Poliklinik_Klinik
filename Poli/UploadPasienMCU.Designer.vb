<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UploadPasienMCU
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UploadPasienMCU))
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.Label2 = New System.Windows.Forms.Label
        Me.SplitContainerLaporanPendapatanMain = New System.Windows.Forms.SplitContainer
        Me.SplitContainerLaporanPendapatanHeader = New System.Windows.Forms.SplitContainer
        Me.ButtonDownloadFile = New System.Windows.Forms.Button
        Me.ButtonSimpanData = New System.Windows.Forms.Button
        Me.ButtonValidasiData = New System.Windows.Forms.Button
        Me.ButtonUploadFile = New System.Windows.Forms.Button
        Me.GridControlDataPasien = New DevExpress.XtraGrid.GridControl
        Me.GridViewDataPasien = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.SplitContainerLaporanPendapatanMain.Panel2.SuspendLayout()
        Me.SplitContainerLaporanPendapatanMain.SuspendLayout()
        Me.SplitContainerLaporanPendapatanHeader.Panel1.SuspendLayout()
        Me.SplitContainerLaporanPendapatanHeader.Panel2.SuspendLayout()
        Me.SplitContainerLaporanPendapatanHeader.SuspendLayout()
        CType(Me.GridControlDataPasien, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewDataPasien, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ProgressBar1
        '
        Me.ProgressBar1.BackColor = System.Drawing.Color.Lime
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 86)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(462, 10)
        Me.ProgressBar1.TabIndex = 241
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Firebrick
        Me.Label2.Location = New System.Drawing.Point(766, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(252, 45)
        Me.Label2.TabIndex = 238
        Me.Label2.Text = "Note : Klik Download untuk mendapatkan" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "format upload excel terbaru && jika ada d" & _
            "ata" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "yang kosong harap diisi -"
        '
        'SplitContainerLaporanPendapatanMain
        '
        Me.SplitContainerLaporanPendapatanMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerLaporanPendapatanMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainerLaporanPendapatanMain.IsSplitterFixed = True
        Me.SplitContainerLaporanPendapatanMain.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerLaporanPendapatanMain.Name = "SplitContainerLaporanPendapatanMain"
        Me.SplitContainerLaporanPendapatanMain.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerLaporanPendapatanMain.Panel2
        '
        Me.SplitContainerLaporanPendapatanMain.Panel2.AutoScroll = True
        Me.SplitContainerLaporanPendapatanMain.Panel2.Controls.Add(Me.SplitContainerLaporanPendapatanHeader)
        Me.SplitContainerLaporanPendapatanMain.Size = New System.Drawing.Size(1200, 540)
        Me.SplitContainerLaporanPendapatanMain.SplitterDistance = 25
        Me.SplitContainerLaporanPendapatanMain.SplitterWidth = 1
        Me.SplitContainerLaporanPendapatanMain.TabIndex = 462
        '
        'SplitContainerLaporanPendapatanHeader
        '
        Me.SplitContainerLaporanPendapatanHeader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerLaporanPendapatanHeader.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainerLaporanPendapatanHeader.IsSplitterFixed = True
        Me.SplitContainerLaporanPendapatanHeader.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerLaporanPendapatanHeader.Name = "SplitContainerLaporanPendapatanHeader"
        Me.SplitContainerLaporanPendapatanHeader.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerLaporanPendapatanHeader.Panel1
        '
        Me.SplitContainerLaporanPendapatanHeader.Panel1.BackColor = System.Drawing.Color.White
        Me.SplitContainerLaporanPendapatanHeader.Panel1.Controls.Add(Me.ButtonDownloadFile)
        Me.SplitContainerLaporanPendapatanHeader.Panel1.Controls.Add(Me.ButtonSimpanData)
        Me.SplitContainerLaporanPendapatanHeader.Panel1.Controls.Add(Me.ButtonValidasiData)
        Me.SplitContainerLaporanPendapatanHeader.Panel1.Controls.Add(Me.ButtonUploadFile)
        Me.SplitContainerLaporanPendapatanHeader.Panel1.Controls.Add(Me.ProgressBar1)
        Me.SplitContainerLaporanPendapatanHeader.Panel1.Controls.Add(Me.Label2)
        '
        'SplitContainerLaporanPendapatanHeader.Panel2
        '
        Me.SplitContainerLaporanPendapatanHeader.Panel2.AutoScroll = True
        Me.SplitContainerLaporanPendapatanHeader.Panel2.Controls.Add(Me.GridControlDataPasien)
        Me.SplitContainerLaporanPendapatanHeader.Size = New System.Drawing.Size(1200, 514)
        Me.SplitContainerLaporanPendapatanHeader.SplitterDistance = 110
        Me.SplitContainerLaporanPendapatanHeader.SplitterWidth = 1
        Me.SplitContainerLaporanPendapatanHeader.TabIndex = 462
        '
        'ButtonDownloadFile
        '
        Me.ButtonDownloadFile.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ButtonDownloadFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonDownloadFile.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonDownloadFile.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonDownloadFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonDownloadFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonDownloadFile.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonDownloadFile.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonDownloadFile.Image = CType(resources.GetObject("ButtonDownloadFile.Image"), System.Drawing.Image)
        Me.ButtonDownloadFile.Location = New System.Drawing.Point(585, 11)
        Me.ButtonDownloadFile.Name = "ButtonDownloadFile"
        Me.ButtonDownloadFile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonDownloadFile.Size = New System.Drawing.Size(175, 69)
        Me.ButtonDownloadFile.TabIndex = 584
        Me.ButtonDownloadFile.Text = "Download Template Excel"
        Me.ButtonDownloadFile.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonDownloadFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ButtonDownloadFile.UseVisualStyleBackColor = False
        '
        'ButtonSimpanData
        '
        Me.ButtonSimpanData.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ButtonSimpanData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonSimpanData.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonSimpanData.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSimpanData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonSimpanData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSimpanData.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSimpanData.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSimpanData.Image = CType(resources.GetObject("ButtonSimpanData.Image"), System.Drawing.Image)
        Me.ButtonSimpanData.Location = New System.Drawing.Point(324, 11)
        Me.ButtonSimpanData.Name = "ButtonSimpanData"
        Me.ButtonSimpanData.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonSimpanData.Size = New System.Drawing.Size(150, 69)
        Me.ButtonSimpanData.TabIndex = 583
        Me.ButtonSimpanData.Text = "Simpan Data"
        Me.ButtonSimpanData.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonSimpanData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ButtonSimpanData.UseVisualStyleBackColor = False
        '
        'ButtonValidasiData
        '
        Me.ButtonValidasiData.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ButtonValidasiData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonValidasiData.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonValidasiData.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonValidasiData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonValidasiData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonValidasiData.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonValidasiData.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonValidasiData.Image = CType(resources.GetObject("ButtonValidasiData.Image"), System.Drawing.Image)
        Me.ButtonValidasiData.Location = New System.Drawing.Point(168, 11)
        Me.ButtonValidasiData.Name = "ButtonValidasiData"
        Me.ButtonValidasiData.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonValidasiData.Size = New System.Drawing.Size(150, 69)
        Me.ButtonValidasiData.TabIndex = 582
        Me.ButtonValidasiData.Text = "Validasi Data"
        Me.ButtonValidasiData.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonValidasiData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ButtonValidasiData.UseVisualStyleBackColor = False
        '
        'ButtonUploadFile
        '
        Me.ButtonUploadFile.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ButtonUploadFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonUploadFile.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonUploadFile.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonUploadFile.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonUploadFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonUploadFile.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonUploadFile.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonUploadFile.Image = CType(resources.GetObject("ButtonUploadFile.Image"), System.Drawing.Image)
        Me.ButtonUploadFile.Location = New System.Drawing.Point(12, 11)
        Me.ButtonUploadFile.Name = "ButtonUploadFile"
        Me.ButtonUploadFile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonUploadFile.Size = New System.Drawing.Size(150, 69)
        Me.ButtonUploadFile.TabIndex = 581
        Me.ButtonUploadFile.Text = "Upload File Excel"
        Me.ButtonUploadFile.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ButtonUploadFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ButtonUploadFile.UseVisualStyleBackColor = False
        '
        'GridControlDataPasien
        '
        Me.GridControlDataPasien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControlDataPasien.EmbeddedNavigator.Name = ""
        Me.GridControlDataPasien.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GridControlDataPasien.Location = New System.Drawing.Point(0, 0)
        Me.GridControlDataPasien.MainView = Me.GridViewDataPasien
        Me.GridControlDataPasien.Name = "GridControlDataPasien"
        Me.GridControlDataPasien.Size = New System.Drawing.Size(1200, 403)
        Me.GridControlDataPasien.TabIndex = 186
        Me.GridControlDataPasien.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewDataPasien})
        '
        'GridViewDataPasien
        '
        Me.GridViewDataPasien.GridControl = Me.GridControlDataPasien
        Me.GridViewDataPasien.Name = "GridViewDataPasien"
        Me.GridViewDataPasien.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridViewDataPasien.OptionsView.ShowGroupPanel = False
        Me.GridViewDataPasien.OptionsView.ShowIndicator = False
        Me.GridViewDataPasien.PaintStyleName = "Skin"
        '
        'UploadPasienMCU
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1200, 540)
        Me.Controls.Add(Me.SplitContainerLaporanPendapatanMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1216, 579)
        Me.MinimumSize = New System.Drawing.Size(1216, 579)
        Me.Name = "UploadPasienMCU"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Form Upload MCU"
        Me.SplitContainerLaporanPendapatanMain.Panel2.ResumeLayout(False)
        Me.SplitContainerLaporanPendapatanMain.ResumeLayout(False)
        Me.SplitContainerLaporanPendapatanHeader.Panel1.ResumeLayout(False)
        Me.SplitContainerLaporanPendapatanHeader.Panel1.PerformLayout()
        Me.SplitContainerLaporanPendapatanHeader.Panel2.ResumeLayout(False)
        Me.SplitContainerLaporanPendapatanHeader.ResumeLayout(False)
        CType(Me.GridControlDataPasien, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewDataPasien, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents SplitContainerLaporanPendapatanMain As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainerLaporanPendapatanHeader As System.Windows.Forms.SplitContainer
    Private WithEvents GridControlDataPasien As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewDataPasien As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ButtonUploadFile As System.Windows.Forms.Button
    Friend WithEvents ButtonValidasiData As System.Windows.Forms.Button
    Friend WithEvents ButtonSimpanData As System.Windows.Forms.Button
    Friend WithEvents ButtonDownloadFile As System.Windows.Forms.Button
End Class
