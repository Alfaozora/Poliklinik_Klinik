<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormObservation
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LabelJmlTerkirim = New System.Windows.Forms.Label
        Me.LabelJudul1 = New System.Windows.Forms.Label
        Me.ButtonStopProses = New System.Windows.Forms.Button
        Me.LabelSinkronisasi = New System.Windows.Forms.Label
        Me.LabelProgress = New System.Windows.Forms.Label
        Me.PanelProgressBG = New System.Windows.Forms.Panel
        Me.PostObservasi = New System.Windows.Forms.Button
        Me.ButtonGetToken = New System.Windows.Forms.Button
        Me.TextBoxResponse = New System.Windows.Forms.TextBox
        Me.bgWorkerObservasi = New System.ComponentModel.BackgroundWorker
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.LabelData = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.PanelProgressFill = New PoliKlinik_Net2.GradientPanel
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.White
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.AutoScroll = True
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.White
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel3)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ButtonStopProses)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelSinkronisasi)
        Me.SplitContainer1.Panel1.Controls.Add(Me.PanelProgressFill)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelProgress)
        Me.SplitContainer1.Panel1.Controls.Add(Me.PanelProgressBG)
        Me.SplitContainer1.Panel1.Controls.Add(Me.PostObservasi)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ButtonGetToken)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TextBoxResponse)
        Me.SplitContainer1.Size = New System.Drawing.Size(922, 453)
        Me.SplitContainer1.SplitterDistance = 210
        Me.SplitContainer1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Panel1.AutoSize = True
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Panel1.Controls.Add(Me.LabelJmlTerkirim)
        Me.Panel1.Controls.Add(Me.LabelJudul1)
        Me.Panel1.Location = New System.Drawing.Point(272, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(250, 100)
        Me.Panel1.TabIndex = 525
        '
        'LabelJmlTerkirim
        '
        Me.LabelJmlTerkirim.AutoSize = True
        Me.LabelJmlTerkirim.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelJmlTerkirim.ForeColor = System.Drawing.Color.FromArgb(CType(CType(67, Byte), Integer), CType(CType(137, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.LabelJmlTerkirim.Location = New System.Drawing.Point(82, 40)
        Me.LabelJmlTerkirim.Name = "LabelJmlTerkirim"
        Me.LabelJmlTerkirim.Size = New System.Drawing.Size(87, 20)
        Me.LabelJmlTerkirim.TabIndex = 1
        Me.LabelJmlTerkirim.Text = "0 Transaksi"
        Me.LabelJmlTerkirim.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelJudul1
        '
        Me.LabelJudul1.AutoSize = True
        Me.LabelJudul1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelJudul1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(29, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.LabelJudul1.Location = New System.Drawing.Point(8, 5)
        Me.LabelJudul1.Name = "LabelJudul1"
        Me.LabelJudul1.Size = New System.Drawing.Size(235, 20)
        Me.LabelJudul1.TabIndex = 0
        Me.LabelJudul1.Text = "Berhasil Terkirim ke SATUSEHAT"
        Me.LabelJudul1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ButtonStopProses
        '
        Me.ButtonStopProses.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonStopProses.BackColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(12, Byte), Integer), CType(CType(43, Byte), Integer))
        Me.ButtonStopProses.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonStopProses.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonStopProses.Enabled = False
        Me.ButtonStopProses.FlatAppearance.BorderSize = 0
        Me.ButtonStopProses.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonStopProses.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonStopProses.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonStopProses.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonStopProses.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.ButtonStopProses.Location = New System.Drawing.Point(300, 127)
        Me.ButtonStopProses.Name = "ButtonStopProses"
        Me.ButtonStopProses.Size = New System.Drawing.Size(138, 35)
        Me.ButtonStopProses.TabIndex = 524
        Me.ButtonStopProses.Text = "STOP Proses"
        Me.ButtonStopProses.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonStopProses.UseVisualStyleBackColor = False
        '
        'LabelSinkronisasi
        '
        Me.LabelSinkronisasi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelSinkronisasi.AutoSize = True
        Me.LabelSinkronisasi.BackColor = System.Drawing.Color.Transparent
        Me.LabelSinkronisasi.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSinkronisasi.Location = New System.Drawing.Point(12, 107)
        Me.LabelSinkronisasi.Name = "LabelSinkronisasi"
        Me.LabelSinkronisasi.Size = New System.Drawing.Size(275, 17)
        Me.LabelSinkronisasi.TabIndex = 523
        Me.LabelSinkronisasi.Text = "Kirim Data Terakhir pada 18 September 2025"
        '
        'LabelProgress
        '
        Me.LabelProgress.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelProgress.AutoSize = True
        Me.LabelProgress.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelProgress.Location = New System.Drawing.Point(441, 173)
        Me.LabelProgress.Name = "LabelProgress"
        Me.LabelProgress.Size = New System.Drawing.Size(26, 17)
        Me.LabelProgress.TabIndex = 521
        Me.LabelProgress.Text = "0%"
        '
        'PanelProgressBG
        '
        Me.PanelProgressBG.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PanelProgressBG.BackColor = System.Drawing.Color.LightGray
        Me.PanelProgressBG.Location = New System.Drawing.Point(12, 171)
        Me.PanelProgressBG.Name = "PanelProgressBG"
        Me.PanelProgressBG.Size = New System.Drawing.Size(426, 20)
        Me.PanelProgressBG.TabIndex = 519
        '
        'PostObservasi
        '
        Me.PostObservasi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PostObservasi.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(195, Byte), Integer))
        Me.PostObservasi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PostObservasi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PostObservasi.FlatAppearance.BorderSize = 0
        Me.PostObservasi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.PostObservasi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.PostObservasi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PostObservasi.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PostObservasi.ForeColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.PostObservasi.Location = New System.Drawing.Point(156, 127)
        Me.PostObservasi.Name = "PostObservasi"
        Me.PostObservasi.Size = New System.Drawing.Size(138, 35)
        Me.PostObservasi.TabIndex = 518
        Me.PostObservasi.Text = "Kirim Data"
        Me.PostObservasi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.PostObservasi.UseVisualStyleBackColor = False
        '
        'ButtonGetToken
        '
        Me.ButtonGetToken.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonGetToken.BackColor = System.Drawing.Color.FromArgb(CType(CType(60, Byte), Integer), CType(CType(188, Byte), Integer), CType(CType(195, Byte), Integer))
        Me.ButtonGetToken.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonGetToken.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonGetToken.FlatAppearance.BorderSize = 0
        Me.ButtonGetToken.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonGetToken.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonGetToken.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonGetToken.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonGetToken.ForeColor = System.Drawing.Color.FromArgb(CType(CType(26, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(173, Byte), Integer))
        Me.ButtonGetToken.Location = New System.Drawing.Point(12, 127)
        Me.ButtonGetToken.Name = "ButtonGetToken"
        Me.ButtonGetToken.Size = New System.Drawing.Size(138, 35)
        Me.ButtonGetToken.TabIndex = 517
        Me.ButtonGetToken.Text = "Get Token"
        Me.ButtonGetToken.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonGetToken.UseVisualStyleBackColor = False
        '
        'TextBoxResponse
        '
        Me.TextBoxResponse.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextBoxResponse.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxResponse.Location = New System.Drawing.Point(0, 0)
        Me.TextBoxResponse.Multiline = True
        Me.TextBoxResponse.Name = "TextBoxResponse"
        Me.TextBoxResponse.Size = New System.Drawing.Size(922, 239)
        Me.TextBoxResponse.TabIndex = 0
        '
        'bgWorkerObservasi
        '
        Me.bgWorkerObservasi.WorkerReportsProgress = True
        Me.bgWorkerObservasi.WorkerSupportsCancellation = True
        '
        'Panel2
        '
        Me.Panel2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Panel2.AutoSize = True
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Panel2.Controls.Add(Me.LabelData)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New System.Drawing.Point(12, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(250, 100)
        Me.Panel2.TabIndex = 526
        '
        'LabelData
        '
        Me.LabelData.AutoSize = True
        Me.LabelData.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelData.ForeColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(166, Byte), Integer), CType(CType(63, Byte), Integer))
        Me.LabelData.Location = New System.Drawing.Point(98, 40)
        Me.LabelData.Name = "LabelData"
        Me.LabelData.Size = New System.Drawing.Size(55, 20)
        Me.LabelData.TabIndex = 1
        Me.LabelData.Text = "0 Data"
        Me.LabelData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(29, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(59, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(133, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Data Keseluruhan"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(233, Byte), Integer))
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(922, 35)
        Me.Panel3.TabIndex = 527
        '
        'Label1
        '
        Me.Label1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(29, Byte), Integer), CType(CType(29, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(3, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(224, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "FORM SATUSEHAT OBSERVASI"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PanelProgressFill
        '
        Me.PanelProgressFill.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PanelProgressFill.Color1 = System.Drawing.Color.SkyBlue
        Me.PanelProgressFill.Color2 = System.Drawing.Color.MediumPurple
        Me.PanelProgressFill.Location = New System.Drawing.Point(12, 171)
        Me.PanelProgressFill.Name = "PanelProgressFill"
        Me.PanelProgressFill.Size = New System.Drawing.Size(0, 20)
        Me.PanelProgressFill.TabIndex = 522
        '
        'FormObservation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(922, 453)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FormObservation"
        Me.Text = "FormObservations"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TextBoxResponse As System.Windows.Forms.TextBox
    Friend WithEvents ButtonGetToken As System.Windows.Forms.Button
    Friend WithEvents PostObservasi As System.Windows.Forms.Button
    Friend WithEvents LabelProgress As System.Windows.Forms.Label
    Friend WithEvents PanelProgressBG As System.Windows.Forms.Panel
    Friend WithEvents PanelProgressFill As PoliKlinik_Net2.GradientPanel
    Friend WithEvents LabelSinkronisasi As System.Windows.Forms.Label
    Friend WithEvents ButtonStopProses As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LabelJudul1 As System.Windows.Forms.Label
    Friend WithEvents LabelJmlTerkirim As System.Windows.Forms.Label
    Friend WithEvents bgWorkerObservasi As System.ComponentModel.BackgroundWorker
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents LabelData As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
