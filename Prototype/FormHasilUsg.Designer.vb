<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormHasilUsg
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormHasilUsg))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.btnModeVideo = New System.Windows.Forms.Button
        Me.btnModeFoto = New System.Windows.Forms.Button
        Me.btnReset = New System.Windows.Forms.Button
        Me.btnRotateRight = New System.Windows.Forms.Button
        Me.btnZoomOut = New System.Windows.Forms.Button
        Me.btnZoomIn = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.LabelStatus = New System.Windows.Forms.Label
        Me.PanelViewer = New System.Windows.Forms.Panel
        Me.picFullUSG = New System.Windows.Forms.PictureBox
        Me.AxWindowsMediaPlayer1 = New AxWMPLib.AxWindowsMediaPlayer
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.PanelViewer.SuspendLayout()
        CType(Me.picFullUSG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnModeVideo)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnModeFoto)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnReset)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnRotateRight)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnZoomOut)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnZoomIn)
        Me.SplitContainer1.Size = New System.Drawing.Size(1024, 681)
        Me.SplitContainer1.SplitterDistance = 620
        Me.SplitContainer1.TabIndex = 0
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer2.IsSplitterFixed = True
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.LabelStatus)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.PanelViewer)
        Me.SplitContainer2.Size = New System.Drawing.Size(1022, 618)
        Me.SplitContainer2.TabIndex = 0
        '
        'btnModeVideo
        '
        Me.btnModeVideo.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btnModeVideo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnModeVideo.ForeColor = System.Drawing.Color.White
        Me.btnModeVideo.Image = CType(resources.GetObject("btnModeVideo.Image"), System.Drawing.Image)
        Me.btnModeVideo.Location = New System.Drawing.Point(344, 10)
        Me.btnModeVideo.Name = "btnModeVideo"
        Me.btnModeVideo.Size = New System.Drawing.Size(52, 34)
        Me.btnModeVideo.TabIndex = 5
        Me.ToolTip1.SetToolTip(Me.btnModeVideo, "Play Vidio")
        Me.btnModeVideo.UseVisualStyleBackColor = False
        '
        'btnModeFoto
        '
        Me.btnModeFoto.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btnModeFoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnModeFoto.ForeColor = System.Drawing.Color.White
        Me.btnModeFoto.Image = CType(resources.GetObject("btnModeFoto.Image"), System.Drawing.Image)
        Me.btnModeFoto.Location = New System.Drawing.Point(286, 10)
        Me.btnModeFoto.Name = "btnModeFoto"
        Me.btnModeFoto.Size = New System.Drawing.Size(52, 34)
        Me.btnModeFoto.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.btnModeFoto, "Lihat Foto USG")
        Me.btnModeFoto.UseVisualStyleBackColor = False
        '
        'btnReset
        '
        Me.btnReset.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReset.ForeColor = System.Drawing.Color.White
        Me.btnReset.Image = CType(resources.GetObject("btnReset.Image"), System.Drawing.Image)
        Me.btnReset.Location = New System.Drawing.Point(212, 9)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(52, 34)
        Me.btnReset.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.btnReset, "Reset")
        Me.btnReset.UseVisualStyleBackColor = False
        '
        'btnRotateRight
        '
        Me.btnRotateRight.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btnRotateRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRotateRight.ForeColor = System.Drawing.Color.White
        Me.btnRotateRight.Image = CType(resources.GetObject("btnRotateRight.Image"), System.Drawing.Image)
        Me.btnRotateRight.Location = New System.Drawing.Point(154, 9)
        Me.btnRotateRight.Name = "btnRotateRight"
        Me.btnRotateRight.Size = New System.Drawing.Size(52, 34)
        Me.btnRotateRight.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.btnRotateRight, "Rotate Right")
        Me.btnRotateRight.UseVisualStyleBackColor = False
        '
        'btnZoomOut
        '
        Me.btnZoomOut.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btnZoomOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnZoomOut.ForeColor = System.Drawing.Color.White
        Me.btnZoomOut.Image = CType(resources.GetObject("btnZoomOut.Image"), System.Drawing.Image)
        Me.btnZoomOut.Location = New System.Drawing.Point(78, 9)
        Me.btnZoomOut.Name = "btnZoomOut"
        Me.btnZoomOut.Size = New System.Drawing.Size(52, 34)
        Me.btnZoomOut.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.btnZoomOut, "Zoom Out")
        Me.btnZoomOut.UseVisualStyleBackColor = False
        '
        'btnZoomIn
        '
        Me.btnZoomIn.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btnZoomIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnZoomIn.ForeColor = System.Drawing.Color.White
        Me.btnZoomIn.Image = CType(resources.GetObject("btnZoomIn.Image"), System.Drawing.Image)
        Me.btnZoomIn.Location = New System.Drawing.Point(20, 9)
        Me.btnZoomIn.Name = "btnZoomIn"
        Me.btnZoomIn.Size = New System.Drawing.Size(52, 34)
        Me.btnZoomIn.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.btnZoomIn, "Zoom In")
        Me.btnZoomIn.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Status :"
        '
        'LabelStatus
        '
        Me.LabelStatus.AutoSize = True
        Me.LabelStatus.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelStatus.Location = New System.Drawing.Point(59, 18)
        Me.LabelStatus.Name = "LabelStatus"
        Me.LabelStatus.Size = New System.Drawing.Size(13, 17)
        Me.LabelStatus.TabIndex = 1
        Me.LabelStatus.Text = "-"
        '
        'PanelViewer
        '
        Me.PanelViewer.BackColor = System.Drawing.Color.Black
        Me.PanelViewer.Controls.Add(Me.AxWindowsMediaPlayer1)
        Me.PanelViewer.Controls.Add(Me.picFullUSG)
        Me.PanelViewer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelViewer.Location = New System.Drawing.Point(0, 0)
        Me.PanelViewer.Name = "PanelViewer"
        Me.PanelViewer.Size = New System.Drawing.Size(1022, 564)
        Me.PanelViewer.TabIndex = 0
        '
        'picFullUSG
        '
        Me.picFullUSG.BackColor = System.Drawing.Color.Transparent
        Me.picFullUSG.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picFullUSG.Location = New System.Drawing.Point(0, 0)
        Me.picFullUSG.Name = "picFullUSG"
        Me.picFullUSG.Size = New System.Drawing.Size(1022, 564)
        Me.picFullUSG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picFullUSG.TabIndex = 0
        Me.picFullUSG.TabStop = False
        '
        'AxWindowsMediaPlayer1
        '
        Me.AxWindowsMediaPlayer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AxWindowsMediaPlayer1.Enabled = True
        Me.AxWindowsMediaPlayer1.Location = New System.Drawing.Point(0, 0)
        Me.AxWindowsMediaPlayer1.Name = "AxWindowsMediaPlayer1"
        Me.AxWindowsMediaPlayer1.OcxState = CType(resources.GetObject("AxWindowsMediaPlayer1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxWindowsMediaPlayer1.Size = New System.Drawing.Size(1022, 564)
        Me.AxWindowsMediaPlayer1.TabIndex = 1
        '
        'FormHasilUsg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1008, 681)
        Me.Controls.Add(Me.SplitContainer1)
        Me.MaximumSize = New System.Drawing.Size(1024, 720)
        Me.MinimumSize = New System.Drawing.Size(900, 600)
        Me.Name = "FormHasilUsg"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FormHasilUsg"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.PanelViewer.ResumeLayout(False)
        CType(Me.picFullUSG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxWindowsMediaPlayer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnZoomIn As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnRotateRight As System.Windows.Forms.Button
    Friend WithEvents btnZoomOut As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnModeVideo As System.Windows.Forms.Button
    Friend WithEvents btnModeFoto As System.Windows.Forms.Button
    Friend WithEvents LabelStatus As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PanelViewer As System.Windows.Forms.Panel
    Friend WithEvents picFullUSG As System.Windows.Forms.PictureBox
    Friend WithEvents AxWindowsMediaPlayer1 As AxWMPLib.AxWindowsMediaPlayer
End Class
