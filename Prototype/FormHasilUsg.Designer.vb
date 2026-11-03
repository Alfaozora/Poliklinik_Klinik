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
        Me.picFullUSG = New System.Windows.Forms.PictureBox
        Me.btnReset = New System.Windows.Forms.Button
        Me.btnRotateRight = New System.Windows.Forms.Button
        Me.btnZoomOut = New System.Windows.Forms.Button
        Me.btnZoomIn = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.picFullUSG, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.picFullUSG)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnReset)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnRotateRight)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnZoomOut)
        Me.SplitContainer1.Panel2.Controls.Add(Me.btnZoomIn)
        Me.SplitContainer1.Size = New System.Drawing.Size(756, 456)
        Me.SplitContainer1.SplitterDistance = 400
        Me.SplitContainer1.TabIndex = 0
        '
        'picFullUSG
        '
        Me.picFullUSG.BackColor = System.Drawing.Color.Black
        Me.picFullUSG.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picFullUSG.Location = New System.Drawing.Point(0, 0)
        Me.picFullUSG.Name = "picFullUSG"
        Me.picFullUSG.Size = New System.Drawing.Size(754, 398)
        Me.picFullUSG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.picFullUSG.TabIndex = 1
        Me.picFullUSG.TabStop = False
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
        'FormHasilUsg
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(756, 456)
        Me.Controls.Add(Me.SplitContainer1)
        Me.MaximumSize = New System.Drawing.Size(772, 495)
        Me.MinimumSize = New System.Drawing.Size(772, 495)
        Me.Name = "FormHasilUsg"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormHasilUsg"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.picFullUSG, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents picFullUSG As System.Windows.Forms.PictureBox
    Friend WithEvents btnZoomIn As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnRotateRight As System.Windows.Forms.Button
    Friend WithEvents btnZoomOut As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
