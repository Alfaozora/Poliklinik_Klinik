<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSendingJurnalPendapatan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSendingJurnalPendapatan))
        Me.PanelTop = New System.Windows.Forms.Panel
        Me.btnClose = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar
        Me.ButtonSendJurnal = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtend = New System.Windows.Forms.DateTimePicker
        Me.dtprocess = New System.Windows.Forms.DateTimePicker
        Me.PanelTop.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(73, Byte), Integer), CType(CType(94, Byte), Integer))
        Me.PanelTop.Controls.Add(Me.btnClose)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(498, 40)
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
        Me.btnClose.Location = New System.Drawing.Point(458, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(40, 40)
        Me.btnClose.TabIndex = 281
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.ProgressBar2)
        Me.Panel1.Controls.Add(Me.ButtonSendJurnal)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.dtend)
        Me.Panel1.Controls.Add(Me.dtprocess)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 40)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(498, 158)
        Me.Panel1.TabIndex = 6
        '
        'ProgressBar2
        '
        Me.ProgressBar2.BackColor = System.Drawing.Color.Lime
        Me.ProgressBar2.Location = New System.Drawing.Point(60, 111)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(363, 5)
        Me.ProgressBar2.TabIndex = 449
        '
        'ButtonSendJurnal
        '
        Me.ButtonSendJurnal.BackColor = System.Drawing.Color.FromArgb(CType(CType(4, Byte), Integer), CType(CType(59, Byte), Integer), CType(CType(92, Byte), Integer))
        Me.ButtonSendJurnal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonSendJurnal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonSendJurnal.FlatAppearance.BorderSize = 0
        Me.ButtonSendJurnal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.ButtonSendJurnal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(77, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.ButtonSendJurnal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSendJurnal.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSendJurnal.ForeColor = System.Drawing.Color.Transparent
        Me.ButtonSendJurnal.Location = New System.Drawing.Point(170, 75)
        Me.ButtonSendJurnal.Name = "ButtonSendJurnal"
        Me.ButtonSendJurnal.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonSendJurnal.Size = New System.Drawing.Size(65, 30)
        Me.ButtonSendJurnal.TabIndex = 448
        Me.ButtonSendJurnal.Text = "Send"
        Me.ButtonSendJurnal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonSendJurnal.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(311, 30)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 13)
        Me.Label9.TabIndex = 447
        Me.Label9.Text = "Tgl Akhir"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(285, 53)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(23, 13)
        Me.Label8.TabIndex = 446
        Me.Label8.Text = "s/d"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(167, 30)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 445
        Me.Label7.Text = "Tgl Awal"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(57, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 17)
        Me.Label1.TabIndex = 444
        Me.Label1.Text = "Tgl Transaksi"
        '
        'dtend
        '
        Me.dtend.CalendarFont = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtend.CustomFormat = "dd-MMM-yyyy"
        Me.dtend.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtend.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtend.Location = New System.Drawing.Point(314, 46)
        Me.dtend.Name = "dtend"
        Me.dtend.Size = New System.Drawing.Size(109, 23)
        Me.dtend.TabIndex = 442
        '
        'dtprocess
        '
        Me.dtprocess.CalendarFont = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtprocess.CustomFormat = "dd-MMM-yyyy"
        Me.dtprocess.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.dtprocess.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtprocess.Location = New System.Drawing.Point(170, 46)
        Me.dtprocess.Name = "dtprocess"
        Me.dtprocess.Size = New System.Drawing.Size(109, 23)
        Me.dtprocess.TabIndex = 441
        '
        'FormSendingJurnalPendapatan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(498, 198)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PanelTop)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSendingJurnalPendapatan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.PanelTop.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtend As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtprocess As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ButtonSendJurnal As System.Windows.Forms.Button
    Friend WithEvents ProgressBar2 As System.Windows.Forms.ProgressBar
End Class
