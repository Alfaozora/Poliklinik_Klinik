<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormUsgViewer
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
        Me.rbOnline = New System.Windows.Forms.RadioButton
        Me.rbOffline = New System.Windows.Forms.RadioButton
        Me.btnCariNik = New System.Windows.Forms.Button
        Me.txtNik = New System.Windows.Forms.TextBox
        Me.lblNikCaption = New System.Windows.Forms.Label
        Me.lblPatientInfo = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.grpKanan = New System.Windows.Forms.GroupBox
        Me.picKanan = New System.Windows.Forms.PictureBox
        Me.lblStatusKanan = New System.Windows.Forms.Label
        Me.btnEksternalKanan = New System.Windows.Forms.Button
        Me.cmbTglKanan = New System.Windows.Forms.ComboBox
        Me.txtHasilKanan = New System.Windows.Forms.TextBox
        Me.btnLoadKanan = New System.Windows.Forms.Button
        Me.grpKiri = New System.Windows.Forms.GroupBox
        Me.picKiri = New System.Windows.Forms.PictureBox
        Me.lblStatusKiri = New System.Windows.Forms.Label
        Me.btnEksternalKiri = New System.Windows.Forms.Button
        Me.cmbTglKiri = New System.Windows.Forms.ComboBox
        Me.txtHasilKiri = New System.Windows.Forms.TextBox
        Me.btnLoadKiri = New System.Windows.Forms.Button
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.grpKanan.SuspendLayout()
        CType(Me.picKanan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpKiri.SuspendLayout()
        CType(Me.picKiri, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.rbOnline)
        Me.SplitContainer1.Panel1.Controls.Add(Me.rbOffline)
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnCariNik)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtNik)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblNikCaption)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblPatientInfo)
        Me.SplitContainer1.Panel1.Controls.Add(Me.label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.grpKanan)
        Me.SplitContainer1.Panel2.Controls.Add(Me.grpKiri)
        Me.SplitContainer1.Size = New System.Drawing.Size(1264, 681)
        Me.SplitContainer1.SplitterDistance = 70
        Me.SplitContainer1.TabIndex = 0
        '
        'rbOnline
        '
        Me.rbOnline.AutoSize = True
        Me.rbOnline.Checked = True
        Me.rbOnline.ForeColor = System.Drawing.Color.LightGray
        Me.rbOnline.Location = New System.Drawing.Point(839, 44)
        Me.rbOnline.Name = "rbOnline"
        Me.rbOnline.Size = New System.Drawing.Size(55, 17)
        Me.rbOnline.TabIndex = 475
        Me.rbOnline.TabStop = True
        Me.rbOnline.Text = "Online"
        Me.rbOnline.UseVisualStyleBackColor = True
        '
        'rbOffline
        '
        Me.rbOffline.AutoSize = True
        Me.rbOffline.ForeColor = System.Drawing.Color.LightGray
        Me.rbOffline.Location = New System.Drawing.Point(768, 44)
        Me.rbOffline.Name = "rbOffline"
        Me.rbOffline.Size = New System.Drawing.Size(55, 17)
        Me.rbOffline.TabIndex = 474
        Me.rbOffline.TabStop = True
        Me.rbOffline.Text = "Offline"
        Me.rbOffline.UseVisualStyleBackColor = True
        '
        'btnCariNik
        '
        Me.btnCariNik.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.btnCariNik.FlatAppearance.BorderSize = 0
        Me.btnCariNik.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCariNik.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCariNik.ForeColor = System.Drawing.Color.White
        Me.btnCariNik.Location = New System.Drawing.Point(1173, 39)
        Me.btnCariNik.Name = "btnCariNik"
        Me.btnCariNik.Size = New System.Drawing.Size(84, 25)
        Me.btnCariNik.TabIndex = 473
        Me.btnCariNik.Text = "Cari"
        Me.btnCariNik.UseVisualStyleBackColor = False
        '
        'txtNik
        '
        Me.txtNik.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.txtNik.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNik.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNik.ForeColor = System.Drawing.Color.White
        Me.txtNik.Location = New System.Drawing.Point(993, 39)
        Me.txtNik.Multiline = True
        Me.txtNik.Name = "txtNik"
        Me.txtNik.Size = New System.Drawing.Size(174, 25)
        Me.txtNik.TabIndex = 472
        '
        'lblNikCaption
        '
        Me.lblNikCaption.AutoSize = True
        Me.lblNikCaption.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNikCaption.ForeColor = System.Drawing.Color.LightGray
        Me.lblNikCaption.Location = New System.Drawing.Point(906, 40)
        Me.lblNikCaption.Name = "lblNikCaption"
        Me.lblNikCaption.Size = New System.Drawing.Size(86, 21)
        Me.lblNikCaption.TabIndex = 471
        Me.lblNikCaption.Text = "NIK Pasien:"
        '
        'lblPatientInfo
        '
        Me.lblPatientInfo.AutoSize = True
        Me.lblPatientInfo.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPatientInfo.ForeColor = System.Drawing.Color.LightGray
        Me.lblPatientInfo.Location = New System.Drawing.Point(17, 43)
        Me.lblPatientInfo.Name = "lblPatientInfo"
        Me.lblPatientInfo.Size = New System.Drawing.Size(16, 21)
        Me.lblPatientInfo.TabIndex = 470
        Me.lblPatientInfo.Text = "-"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.label1.Location = New System.Drawing.Point(8, 6)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(377, 37)
        Me.label1.TabIndex = 469
        Me.label1.Text = "USG EXAMINATION VIEWER"
        '
        'grpKanan
        '
        Me.grpKanan.AutoSize = True
        Me.grpKanan.Controls.Add(Me.picKanan)
        Me.grpKanan.Controls.Add(Me.lblStatusKanan)
        Me.grpKanan.Controls.Add(Me.btnEksternalKanan)
        Me.grpKanan.Controls.Add(Me.cmbTglKanan)
        Me.grpKanan.Controls.Add(Me.txtHasilKanan)
        Me.grpKanan.Controls.Add(Me.btnLoadKanan)
        Me.grpKanan.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpKanan.ForeColor = System.Drawing.Color.White
        Me.grpKanan.Location = New System.Drawing.Point(635, 11)
        Me.grpKanan.Name = "grpKanan"
        Me.grpKanan.Size = New System.Drawing.Size(618, 584)
        Me.grpKanan.TabIndex = 9
        Me.grpKanan.TabStop = False
        Me.grpKanan.Text = "PEMERIKSAAN TERBARU"
        '
        'picKanan
        '
        Me.picKanan.BackColor = System.Drawing.Color.Black
        Me.picKanan.Location = New System.Drawing.Point(6, 56)
        Me.picKanan.Name = "picKanan"
        Me.picKanan.Size = New System.Drawing.Size(605, 352)
        Me.picKanan.TabIndex = 466
        Me.picKanan.TabStop = False
        '
        'lblStatusKanan
        '
        Me.lblStatusKanan.AutoSize = True
        Me.lblStatusKanan.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusKanan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.lblStatusKanan.Location = New System.Drawing.Point(385, 24)
        Me.lblStatusKanan.Name = "lblStatusKanan"
        Me.lblStatusKanan.Size = New System.Drawing.Size(102, 21)
        Me.lblStatusKanan.TabIndex = 465
        Me.lblStatusKanan.Text = "Siap memuat"
        '
        'btnEksternalKanan
        '
        Me.btnEksternalKanan.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.btnEksternalKanan.FlatAppearance.BorderSize = 0
        Me.btnEksternalKanan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEksternalKanan.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEksternalKanan.ForeColor = System.Drawing.Color.White
        Me.btnEksternalKanan.Location = New System.Drawing.Point(260, 24)
        Me.btnEksternalKanan.Name = "btnEksternalKanan"
        Me.btnEksternalKanan.Size = New System.Drawing.Size(119, 25)
        Me.btnEksternalKanan.TabIndex = 464
        Me.btnEksternalKanan.Text = "Buka Eksternal"
        Me.btnEksternalKanan.UseVisualStyleBackColor = False
        '
        'cmbTglKanan
        '
        Me.cmbTglKanan.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.cmbTglKanan.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbTglKanan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTglKanan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbTglKanan.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTglKanan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.cmbTglKanan.FormattingEnabled = True
        Me.cmbTglKanan.Location = New System.Drawing.Point(8, 24)
        Me.cmbTglKanan.Name = "cmbTglKanan"
        Me.cmbTglKanan.Size = New System.Drawing.Size(121, 26)
        Me.cmbTglKanan.TabIndex = 460
        '
        'txtHasilKanan
        '
        Me.txtHasilKanan.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.txtHasilKanan.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.txtHasilKanan.Location = New System.Drawing.Point(7, 414)
        Me.txtHasilKanan.Multiline = True
        Me.txtHasilKanan.Name = "txtHasilKanan"
        Me.txtHasilKanan.ReadOnly = True
        Me.txtHasilKanan.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtHasilKanan.Size = New System.Drawing.Size(605, 145)
        Me.txtHasilKanan.TabIndex = 459
        '
        'btnLoadKanan
        '
        Me.btnLoadKanan.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.btnLoadKanan.FlatAppearance.BorderSize = 0
        Me.btnLoadKanan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadKanan.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoadKanan.ForeColor = System.Drawing.Color.White
        Me.btnLoadKanan.Location = New System.Drawing.Point(135, 24)
        Me.btnLoadKanan.Name = "btnLoadKanan"
        Me.btnLoadKanan.Size = New System.Drawing.Size(119, 25)
        Me.btnLoadKanan.TabIndex = 457
        Me.btnLoadKanan.Text = "Muat Hasil"
        Me.btnLoadKanan.UseVisualStyleBackColor = False
        '
        'grpKiri
        '
        Me.grpKiri.AutoSize = True
        Me.grpKiri.Controls.Add(Me.picKiri)
        Me.grpKiri.Controls.Add(Me.lblStatusKiri)
        Me.grpKiri.Controls.Add(Me.btnEksternalKiri)
        Me.grpKiri.Controls.Add(Me.cmbTglKiri)
        Me.grpKiri.Controls.Add(Me.txtHasilKiri)
        Me.grpKiri.Controls.Add(Me.btnLoadKiri)
        Me.grpKiri.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpKiri.ForeColor = System.Drawing.Color.White
        Me.grpKiri.Location = New System.Drawing.Point(11, 11)
        Me.grpKiri.Name = "grpKiri"
        Me.grpKiri.Size = New System.Drawing.Size(618, 583)
        Me.grpKiri.TabIndex = 8
        Me.grpKiri.TabStop = False
        Me.grpKiri.Text = "PEMBANDING (SEBELUMNYA)"
        '
        'picKiri
        '
        Me.picKiri.BackColor = System.Drawing.Color.Black
        Me.picKiri.Location = New System.Drawing.Point(6, 56)
        Me.picKiri.Name = "picKiri"
        Me.picKiri.Size = New System.Drawing.Size(605, 352)
        Me.picKiri.TabIndex = 462
        Me.picKiri.TabStop = False
        '
        'lblStatusKiri
        '
        Me.lblStatusKiri.AutoSize = True
        Me.lblStatusKiri.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusKiri.ForeColor = System.Drawing.Color.FromArgb(CType(CType(148, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(184, Byte), Integer))
        Me.lblStatusKiri.Location = New System.Drawing.Point(385, 24)
        Me.lblStatusKiri.Name = "lblStatusKiri"
        Me.lblStatusKiri.Size = New System.Drawing.Size(102, 21)
        Me.lblStatusKiri.TabIndex = 461
        Me.lblStatusKiri.Text = "Siap memuat"
        '
        'btnEksternalKiri
        '
        Me.btnEksternalKiri.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(65, Byte), Integer), CType(CType(85, Byte), Integer))
        Me.btnEksternalKiri.FlatAppearance.BorderSize = 0
        Me.btnEksternalKiri.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEksternalKiri.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEksternalKiri.ForeColor = System.Drawing.Color.White
        Me.btnEksternalKiri.Location = New System.Drawing.Point(260, 24)
        Me.btnEksternalKiri.Name = "btnEksternalKiri"
        Me.btnEksternalKiri.Size = New System.Drawing.Size(119, 25)
        Me.btnEksternalKiri.TabIndex = 460
        Me.btnEksternalKiri.Text = "Buka Eksternal"
        Me.btnEksternalKiri.UseVisualStyleBackColor = False
        '
        'cmbTglKiri
        '
        Me.cmbTglKiri.BackColor = System.Drawing.Color.FromArgb(CType(CType(15, Byte), Integer), CType(CType(23, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.cmbTglKiri.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.cmbTglKiri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTglKiri.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbTglKiri.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTglKiri.ForeColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(250, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.cmbTglKiri.FormattingEnabled = True
        Me.cmbTglKiri.ItemHeight = 20
        Me.cmbTglKiri.Location = New System.Drawing.Point(8, 24)
        Me.cmbTglKiri.Name = "cmbTglKiri"
        Me.cmbTglKiri.Size = New System.Drawing.Size(121, 26)
        Me.cmbTglKiri.TabIndex = 459
        '
        'txtHasilKiri
        '
        Me.txtHasilKiri.BackColor = System.Drawing.Color.FromArgb(CType(CType(24, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.txtHasilKiri.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.txtHasilKiri.Location = New System.Drawing.Point(6, 414)
        Me.txtHasilKiri.Multiline = True
        Me.txtHasilKiri.Name = "txtHasilKiri"
        Me.txtHasilKiri.ReadOnly = True
        Me.txtHasilKiri.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtHasilKiri.Size = New System.Drawing.Size(605, 145)
        Me.txtHasilKiri.TabIndex = 458
        '
        'btnLoadKiri
        '
        Me.btnLoadKiri.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(132, Byte), Integer), CType(CType(199, Byte), Integer))
        Me.btnLoadKiri.FlatAppearance.BorderSize = 0
        Me.btnLoadKiri.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadKiri.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoadKiri.ForeColor = System.Drawing.Color.White
        Me.btnLoadKiri.Location = New System.Drawing.Point(135, 24)
        Me.btnLoadKiri.Name = "btnLoadKiri"
        Me.btnLoadKiri.Size = New System.Drawing.Size(119, 25)
        Me.btnLoadKiri.TabIndex = 456
        Me.btnLoadKiri.Text = "Muat Hasil"
        Me.btnLoadKiri.UseVisualStyleBackColor = False
        '
        'FormUsgViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1264, 681)
        Me.Controls.Add(Me.SplitContainer1)
        Me.MinimumSize = New System.Drawing.Size(1024, 650)
        Me.Name = "FormUsgViewer"
        Me.Text = "Pemeriksaan USG Viewer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.grpKanan.ResumeLayout(False)
        Me.grpKanan.PerformLayout()
        CType(Me.picKanan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpKiri.ResumeLayout(False)
        Me.grpKiri.PerformLayout()
        CType(Me.picKiri, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents rbOnline As System.Windows.Forms.RadioButton
    Friend WithEvents rbOffline As System.Windows.Forms.RadioButton
    Friend WithEvents btnCariNik As System.Windows.Forms.Button
    Friend WithEvents txtNik As System.Windows.Forms.TextBox
    Friend WithEvents lblNikCaption As System.Windows.Forms.Label
    Friend WithEvents lblPatientInfo As System.Windows.Forms.Label
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents grpKanan As System.Windows.Forms.GroupBox
    Friend WithEvents picKanan As System.Windows.Forms.PictureBox
    Friend WithEvents lblStatusKanan As System.Windows.Forms.Label
    Friend WithEvents btnEksternalKanan As System.Windows.Forms.Button
    Friend WithEvents cmbTglKanan As System.Windows.Forms.ComboBox
    Friend WithEvents txtHasilKanan As System.Windows.Forms.TextBox
    Friend WithEvents btnLoadKanan As System.Windows.Forms.Button
    Friend WithEvents grpKiri As System.Windows.Forms.GroupBox
    Friend WithEvents picKiri As System.Windows.Forms.PictureBox
    Friend WithEvents lblStatusKiri As System.Windows.Forms.Label
    Friend WithEvents btnEksternalKiri As System.Windows.Forms.Button
    Friend WithEvents cmbTglKiri As System.Windows.Forms.ComboBox
    Friend WithEvents txtHasilKiri As System.Windows.Forms.TextBox
    Friend WithEvents btnLoadKiri As System.Windows.Forms.Button
End Class
