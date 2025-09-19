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
        Me.TextBoxResponse = New System.Windows.Forms.TextBox
        Me.ButtonGetToken = New System.Windows.Forms.Button
        Me.PostObservasi = New System.Windows.Forms.Button
        Me.PanelProgressBG = New System.Windows.Forms.Panel
        Me.LabelProgress = New System.Windows.Forms.Label
        Me.PanelProgressFill = New PoliKlinik_Net2.GradientPanel
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
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
        Me.SplitContainer1.SplitterDistance = 240
        Me.SplitContainer1.TabIndex = 0
        '
        'TextBoxResponse
        '
        Me.TextBoxResponse.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextBoxResponse.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxResponse.Location = New System.Drawing.Point(0, 0)
        Me.TextBoxResponse.Multiline = True
        Me.TextBoxResponse.Name = "TextBoxResponse"
        Me.TextBoxResponse.Size = New System.Drawing.Size(922, 209)
        Me.TextBoxResponse.TabIndex = 0
        '
        'ButtonGetToken
        '
        Me.ButtonGetToken.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonGetToken.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.ButtonGetToken.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonGetToken.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonGetToken.FlatAppearance.BorderSize = 0
        Me.ButtonGetToken.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonGetToken.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonGetToken.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonGetToken.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonGetToken.ForeColor = System.Drawing.Color.White
        Me.ButtonGetToken.Location = New System.Drawing.Point(12, 157)
        Me.ButtonGetToken.Name = "ButtonGetToken"
        Me.ButtonGetToken.Size = New System.Drawing.Size(138, 35)
        Me.ButtonGetToken.TabIndex = 517
        Me.ButtonGetToken.Text = "Get Token"
        Me.ButtonGetToken.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonGetToken.UseVisualStyleBackColor = False
        '
        'PostObservasi
        '
        Me.PostObservasi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PostObservasi.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(219, Byte), Integer))
        Me.PostObservasi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PostObservasi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PostObservasi.FlatAppearance.BorderSize = 0
        Me.PostObservasi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.PostObservasi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.PostObservasi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PostObservasi.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PostObservasi.ForeColor = System.Drawing.Color.White
        Me.PostObservasi.Location = New System.Drawing.Point(156, 157)
        Me.PostObservasi.Name = "PostObservasi"
        Me.PostObservasi.Size = New System.Drawing.Size(138, 35)
        Me.PostObservasi.TabIndex = 518
        Me.PostObservasi.Text = "Kirim Data"
        Me.PostObservasi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.PostObservasi.UseVisualStyleBackColor = False
        '
        'PanelProgressBG
        '
        Me.PanelProgressBG.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PanelProgressBG.BackColor = System.Drawing.Color.LightGray
        Me.PanelProgressBG.Location = New System.Drawing.Point(12, 201)
        Me.PanelProgressBG.Name = "PanelProgressBG"
        Me.PanelProgressBG.Size = New System.Drawing.Size(300, 20)
        Me.PanelProgressBG.TabIndex = 519
        '
        'LabelProgress
        '
        Me.LabelProgress.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelProgress.AutoSize = True
        Me.LabelProgress.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelProgress.Location = New System.Drawing.Point(319, 203)
        Me.LabelProgress.Name = "LabelProgress"
        Me.LabelProgress.Size = New System.Drawing.Size(26, 17)
        Me.LabelProgress.TabIndex = 521
        Me.LabelProgress.Text = "0%"
        '
        'PanelProgressFill
        '
        Me.PanelProgressFill.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PanelProgressFill.Color1 = System.Drawing.Color.SkyBlue
        Me.PanelProgressFill.Color2 = System.Drawing.Color.MediumPurple
        Me.PanelProgressFill.Location = New System.Drawing.Point(12, 201)
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
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TextBoxResponse As System.Windows.Forms.TextBox
    Friend WithEvents ButtonGetToken As System.Windows.Forms.Button
    Friend WithEvents PostObservasi As System.Windows.Forms.Button
    Friend WithEvents LabelProgress As System.Windows.Forms.Label
    Friend WithEvents PanelProgressBG As System.Windows.Forms.Panel
    Friend WithEvents PanelProgressFill As PoliKlinik_Net2.GradientPanel
End Class
