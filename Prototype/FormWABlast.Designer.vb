<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormWABlast
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.ButtonRetry = New System.Windows.Forms.Button
        Me.ButtonStop = New System.Windows.Forms.Button
        Me.ButtonKirim = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ButtonDownloadTemplate = New System.Windows.Forms.Button
        Me.ButtonLoadExcel = New System.Windows.Forms.Button
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer
        Me.dgvData = New System.Windows.Forms.DataGridView
        Me.ButtonClearTemplate = New System.Windows.Forms.Button
        Me.ButtonLoadTemplate = New System.Windows.Forms.Button
        Me.txtPesan = New System.Windows.Forms.TextBox
        Me.LabelStatus = New System.Windows.Forms.Label
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.CheckBoxBirthday = New System.Windows.Forms.CheckBox
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(780, 513)
        Me.SplitContainer1.SplitterDistance = 89
        Me.SplitContainer1.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ButtonRetry)
        Me.GroupBox2.Controls.Add(Me.ButtonStop)
        Me.GroupBox2.Controls.Add(Me.ButtonKirim)
        Me.GroupBox2.Location = New System.Drawing.Point(384, 2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(389, 84)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Kontrol Kirim"
        '
        'ButtonRetry
        '
        Me.ButtonRetry.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonRetry.FlatAppearance.BorderSize = 0
        Me.ButtonRetry.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonRetry.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonRetry.ForeColor = System.Drawing.Color.White
        Me.ButtonRetry.Location = New System.Drawing.Point(180, 25)
        Me.ButtonRetry.Name = "ButtonRetry"
        Me.ButtonRetry.Size = New System.Drawing.Size(78, 33)
        Me.ButtonRetry.TabIndex = 8
        Me.ButtonRetry.Text = "Retry"
        Me.ButtonRetry.UseVisualStyleBackColor = False
        '
        'ButtonStop
        '
        Me.ButtonStop.BackColor = System.Drawing.Color.Red
        Me.ButtonStop.FlatAppearance.BorderSize = 0
        Me.ButtonStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonStop.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonStop.ForeColor = System.Drawing.Color.White
        Me.ButtonStop.Location = New System.Drawing.Point(96, 25)
        Me.ButtonStop.Name = "ButtonStop"
        Me.ButtonStop.Size = New System.Drawing.Size(78, 33)
        Me.ButtonStop.TabIndex = 7
        Me.ButtonStop.Text = "Stop"
        Me.ButtonStop.UseVisualStyleBackColor = False
        '
        'ButtonKirim
        '
        Me.ButtonKirim.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonKirim.FlatAppearance.BorderSize = 0
        Me.ButtonKirim.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonKirim.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonKirim.ForeColor = System.Drawing.Color.White
        Me.ButtonKirim.Location = New System.Drawing.Point(12, 25)
        Me.ButtonKirim.Name = "ButtonKirim"
        Me.ButtonKirim.Size = New System.Drawing.Size(78, 33)
        Me.ButtonKirim.TabIndex = 6
        Me.ButtonKirim.Text = "Start"
        Me.ButtonKirim.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CheckBoxBirthday)
        Me.GroupBox1.Controls.Add(Me.ButtonDownloadTemplate)
        Me.GroupBox1.Controls.Add(Me.ButtonLoadExcel)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(370, 83)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Setting Data"
        '
        'ButtonDownloadTemplate
        '
        Me.ButtonDownloadTemplate.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ButtonDownloadTemplate.FlatAppearance.BorderSize = 0
        Me.ButtonDownloadTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonDownloadTemplate.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonDownloadTemplate.Location = New System.Drawing.Point(103, 25)
        Me.ButtonDownloadTemplate.Name = "ButtonDownloadTemplate"
        Me.ButtonDownloadTemplate.Size = New System.Drawing.Size(134, 33)
        Me.ButtonDownloadTemplate.TabIndex = 4
        Me.ButtonDownloadTemplate.Text = "Download Template"
        Me.ButtonDownloadTemplate.UseVisualStyleBackColor = False
        '
        'ButtonLoadExcel
        '
        Me.ButtonLoadExcel.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonLoadExcel.FlatAppearance.BorderSize = 0
        Me.ButtonLoadExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonLoadExcel.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonLoadExcel.ForeColor = System.Drawing.Color.White
        Me.ButtonLoadExcel.Location = New System.Drawing.Point(16, 25)
        Me.ButtonLoadExcel.Name = "ButtonLoadExcel"
        Me.ButtonLoadExcel.Size = New System.Drawing.Size(81, 33)
        Me.ButtonLoadExcel.TabIndex = 3
        Me.ButtonLoadExcel.Text = "Load Excel"
        Me.ButtonLoadExcel.UseVisualStyleBackColor = False
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.SplitContainer3)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.SplitContainer2.Panel2.Controls.Add(Me.LabelStatus)
        Me.SplitContainer2.Panel2.Controls.Add(Me.ProgressBar1)
        Me.SplitContainer2.Size = New System.Drawing.Size(780, 420)
        Me.SplitContainer2.SplitterDistance = 320
        Me.SplitContainer2.TabIndex = 0
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.dgvData)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.ButtonClearTemplate)
        Me.SplitContainer3.Panel2.Controls.Add(Me.ButtonLoadTemplate)
        Me.SplitContainer3.Panel2.Controls.Add(Me.txtPesan)
        Me.SplitContainer3.Size = New System.Drawing.Size(780, 320)
        Me.SplitContainer3.SplitterDistance = 373
        Me.SplitContainer3.TabIndex = 0
        '
        'dgvData
        '
        Me.dgvData.AllowUserToDeleteRows = False
        Me.dgvData.BackgroundColor = System.Drawing.Color.White
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvData.Location = New System.Drawing.Point(0, 0)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.ReadOnly = True
        Me.dgvData.Size = New System.Drawing.Size(373, 320)
        Me.dgvData.TabIndex = 0
        '
        'ButtonClearTemplate
        '
        Me.ButtonClearTemplate.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ButtonClearTemplate.FlatAppearance.BorderSize = 0
        Me.ButtonClearTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonClearTemplate.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonClearTemplate.ForeColor = System.Drawing.Color.Black
        Me.ButtonClearTemplate.Location = New System.Drawing.Point(124, 9)
        Me.ButtonClearTemplate.Name = "ButtonClearTemplate"
        Me.ButtonClearTemplate.Size = New System.Drawing.Size(104, 30)
        Me.ButtonClearTemplate.TabIndex = 6
        Me.ButtonClearTemplate.Text = "Clear"
        Me.ButtonClearTemplate.UseVisualStyleBackColor = False
        '
        'ButtonLoadTemplate
        '
        Me.ButtonLoadTemplate.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.ButtonLoadTemplate.FlatAppearance.BorderSize = 0
        Me.ButtonLoadTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonLoadTemplate.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonLoadTemplate.ForeColor = System.Drawing.Color.White
        Me.ButtonLoadTemplate.Location = New System.Drawing.Point(14, 9)
        Me.ButtonLoadTemplate.Name = "ButtonLoadTemplate"
        Me.ButtonLoadTemplate.Size = New System.Drawing.Size(104, 30)
        Me.ButtonLoadTemplate.TabIndex = 5
        Me.ButtonLoadTemplate.Text = "Load Template"
        Me.ButtonLoadTemplate.UseVisualStyleBackColor = False
        '
        'txtPesan
        '
        Me.txtPesan.Location = New System.Drawing.Point(14, 45)
        Me.txtPesan.Multiline = True
        Me.txtPesan.Name = "txtPesan"
        Me.txtPesan.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPesan.Size = New System.Drawing.Size(377, 260)
        Me.txtPesan.TabIndex = 0
        '
        'LabelStatus
        '
        Me.LabelStatus.AutoSize = True
        Me.LabelStatus.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelStatus.Location = New System.Drawing.Point(15, 24)
        Me.LabelStatus.Name = "LabelStatus"
        Me.LabelStatus.Size = New System.Drawing.Size(11, 17)
        Me.LabelStatus.TabIndex = 1
        Me.LabelStatus.Text = "."
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(13, 44)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(360, 13)
        Me.ProgressBar1.TabIndex = 0
        '
        'CheckBoxBirthday
        '
        Me.CheckBoxBirthday.AutoSize = True
        Me.CheckBoxBirthday.Location = New System.Drawing.Point(253, 25)
        Me.CheckBoxBirthday.Name = "CheckBoxBirthday"
        Me.CheckBoxBirthday.Size = New System.Drawing.Size(101, 17)
        Me.CheckBoxBirthday.TabIndex = 5
        Me.CheckBoxBirthday.Text = "Sender Birthday"
        Me.CheckBoxBirthday.UseVisualStyleBackColor = True
        '
        'FormWABlast
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(780, 513)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FormWABlast"
        Me.Text = "FormWABlast"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel2.PerformLayout()
        Me.SplitContainer2.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.Panel2.PerformLayout()
        Me.SplitContainer3.ResumeLayout(False)
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents dgvData As System.Windows.Forms.DataGridView
    Friend WithEvents ButtonClearTemplate As System.Windows.Forms.Button
    Friend WithEvents ButtonLoadTemplate As System.Windows.Forms.Button
    Friend WithEvents txtPesan As System.Windows.Forms.TextBox
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents LabelStatus As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonRetry As System.Windows.Forms.Button
    Friend WithEvents ButtonStop As System.Windows.Forms.Button
    Friend WithEvents ButtonKirim As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonDownloadTemplate As System.Windows.Forms.Button
    Friend WithEvents ButtonLoadExcel As System.Windows.Forms.Button
    Friend WithEvents CheckBoxBirthday As System.Windows.Forms.CheckBox
End Class
