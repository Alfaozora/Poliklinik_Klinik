<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MappingObatKFA
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MappingObatKFA))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.LabelStatus = New System.Windows.Forms.Label
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBoxSearch = New System.Windows.Forms.TextBox
        Me.ButtonStart = New System.Windows.Forms.Button
        Me.DataGridViewObat = New System.Windows.Forms.DataGridView
        Me.bgWorkerAutoMapping = New System.ComponentModel.BackgroundWorker
        Me.ButtonDelete = New System.Windows.Forms.Button
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DataGridViewObat, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ButtonDelete)
        Me.SplitContainer1.Panel1.Controls.Add(Me.LabelStatus)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ProgressBar1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.TextBoxSearch)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ButtonStart)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridViewObat)
        Me.SplitContainer1.Size = New System.Drawing.Size(971, 436)
        Me.SplitContainer1.SplitterDistance = 108
        Me.SplitContainer1.TabIndex = 0
        '
        'LabelStatus
        '
        Me.LabelStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LabelStatus.AutoSize = True
        Me.LabelStatus.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelStatus.Location = New System.Drawing.Point(443, 85)
        Me.LabelStatus.Name = "LabelStatus"
        Me.LabelStatus.Size = New System.Drawing.Size(10, 13)
        Me.LabelStatus.TabIndex = 532
        Me.LabelStatus.Text = "."
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(14, 87)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(422, 10)
        Me.ProgressBar1.TabIndex = 531
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 57)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 17)
        Me.Label1.TabIndex = 530
        Me.Label1.Text = "SEARCH :"
        '
        'TextBoxSearch
        '
        Me.TextBoxSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TextBoxSearch.Location = New System.Drawing.Point(81, 55)
        Me.TextBoxSearch.Multiline = True
        Me.TextBoxSearch.Name = "TextBoxSearch"
        Me.TextBoxSearch.Size = New System.Drawing.Size(257, 23)
        Me.TextBoxSearch.TabIndex = 529
        '
        'ButtonStart
        '
        Me.ButtonStart.BackColor = System.Drawing.Color.White
        Me.ButtonStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonStart.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonStart.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonStart.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonStart.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonStart.Image = CType(resources.GetObject("ButtonStart.Image"), System.Drawing.Image)
        Me.ButtonStart.Location = New System.Drawing.Point(12, 12)
        Me.ButtonStart.Name = "ButtonStart"
        Me.ButtonStart.Size = New System.Drawing.Size(150, 35)
        Me.ButtonStart.TabIndex = 528
        Me.ButtonStart.Text = "Auto Mapping"
        Me.ButtonStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonStart.UseVisualStyleBackColor = False
        '
        'DataGridViewObat
        '
        Me.DataGridViewObat.BackgroundColor = System.Drawing.Color.White
        Me.DataGridViewObat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewObat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewObat.Location = New System.Drawing.Point(0, 0)
        Me.DataGridViewObat.Name = "DataGridViewObat"
        Me.DataGridViewObat.Size = New System.Drawing.Size(971, 324)
        Me.DataGridViewObat.TabIndex = 0
        '
        'bgWorkerAutoMapping
        '
        Me.bgWorkerAutoMapping.WorkerReportsProgress = True
        Me.bgWorkerAutoMapping.WorkerSupportsCancellation = True
        '
        'ButtonDelete
        '
        Me.ButtonDelete.BackColor = System.Drawing.Color.White
        Me.ButtonDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonDelete.FlatAppearance.BorderColor = System.Drawing.Color.Red
        Me.ButtonDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ButtonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonDelete.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonDelete.ForeColor = System.Drawing.Color.Red
        Me.ButtonDelete.Image = CType(resources.GetObject("ButtonDelete.Image"), System.Drawing.Image)
        Me.ButtonDelete.Location = New System.Drawing.Point(168, 12)
        Me.ButtonDelete.Name = "ButtonDelete"
        Me.ButtonDelete.Size = New System.Drawing.Size(150, 35)
        Me.ButtonDelete.TabIndex = 533
        Me.ButtonDelete.Text = "Delete Obat Lokal"
        Me.ButtonDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonDelete.UseVisualStyleBackColor = False
        '
        'MappingObatKFA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(971, 436)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "MappingObatKFA"
        Me.Text = "MappingObatKFA"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DataGridViewObat, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents DataGridViewObat As System.Windows.Forms.DataGridView
    Friend WithEvents ButtonStart As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxSearch As System.Windows.Forms.TextBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents LabelStatus As System.Windows.Forms.Label
    Friend WithEvents bgWorkerAutoMapping As System.ComponentModel.BackgroundWorker
    Friend WithEvents ButtonDelete As System.Windows.Forms.Button
End Class
