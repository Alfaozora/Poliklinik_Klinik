<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormThoraxViewer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormThoraxViewer))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.btnResetView = New System.Windows.Forms.Button
        Me.chkSyncZoom = New System.Windows.Forms.CheckBox
        Me.txtNik = New System.Windows.Forms.TextBox
        Me.lblNik = New System.Windows.Forms.Label
        Me.lblNamaPasien = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmbTglKanan = New System.Windows.Forms.ComboBox
        Me.txtHasilKanan = New System.Windows.Forms.TextBox
        Me.lblStatusKanan = New System.Windows.Forms.Label
        Me.btnLoadKanan = New System.Windows.Forms.Button
        Me.picBoxKanan = New System.Windows.Forms.PictureBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmbTglKiri = New System.Windows.Forms.ComboBox
        Me.txtHasilKiri = New System.Windows.Forms.TextBox
        Me.lblStatusKiri = New System.Windows.Forms.Label
        Me.btnLoadKiri = New System.Windows.Forms.Button
        Me.picBoxKiri = New System.Windows.Forms.PictureBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.picBoxKanan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.picBoxKiri, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.SplitContainer1.Panel1.Controls.Add(Me.btnResetView)
        Me.SplitContainer1.Panel1.Controls.Add(Me.chkSyncZoom)
        Me.SplitContainer1.Panel1.Controls.Add(Me.txtNik)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblNik)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lblNamaPasien)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.GroupBox1)
        Me.SplitContainer1.Size = New System.Drawing.Size(1264, 681)
        Me.SplitContainer1.SplitterDistance = 70
        Me.SplitContainer1.TabIndex = 0
        '
        'btnResetView
        '
        Me.btnResetView.BackColor = System.Drawing.Color.SlateGray
        Me.btnResetView.FlatAppearance.BorderSize = 0
        Me.btnResetView.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnResetView.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnResetView.ForeColor = System.Drawing.Color.White
        Me.btnResetView.Image = CType(resources.GetObject("btnResetView.Image"), System.Drawing.Image)
        Me.btnResetView.Location = New System.Drawing.Point(1128, 33)
        Me.btnResetView.Name = "btnResetView"
        Me.btnResetView.Size = New System.Drawing.Size(41, 25)
        Me.btnResetView.TabIndex = 458
        Me.ToolTip1.SetToolTip(Me.btnResetView, "Reset")
        Me.btnResetView.UseVisualStyleBackColor = False
        '
        'chkSyncZoom
        '
        Me.chkSyncZoom.AutoSize = True
        Me.chkSyncZoom.Checked = True
        Me.chkSyncZoom.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSyncZoom.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSyncZoom.ForeColor = System.Drawing.Color.White
        Me.chkSyncZoom.Location = New System.Drawing.Point(1009, 37)
        Me.chkSyncZoom.Name = "chkSyncZoom"
        Me.chkSyncZoom.Size = New System.Drawing.Size(113, 19)
        Me.chkSyncZoom.TabIndex = 5
        Me.chkSyncZoom.Text = "Zoom dan Geser"
        Me.chkSyncZoom.UseVisualStyleBackColor = True
        '
        'txtNik
        '
        Me.txtNik.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(34, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.txtNik.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNik.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNik.ForeColor = System.Drawing.Color.White
        Me.txtNik.Location = New System.Drawing.Point(806, 36)
        Me.txtNik.Multiline = True
        Me.txtNik.Name = "txtNik"
        Me.txtNik.Size = New System.Drawing.Size(196, 22)
        Me.txtNik.TabIndex = 4
        '
        'lblNik
        '
        Me.lblNik.AutoSize = True
        Me.lblNik.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNik.ForeColor = System.Drawing.Color.White
        Me.lblNik.Location = New System.Drawing.Point(723, 35)
        Me.lblNik.Name = "lblNik"
        Me.lblNik.Size = New System.Drawing.Size(86, 21)
        Me.lblNik.TabIndex = 3
        Me.lblNik.Text = "NIK Pasien:"
        '
        'lblNamaPasien
        '
        Me.lblNamaPasien.AutoSize = True
        Me.lblNamaPasien.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNamaPasien.ForeColor = System.Drawing.Color.White
        Me.lblNamaPasien.Location = New System.Drawing.Point(65, 37)
        Me.lblNamaPasien.Name = "lblNamaPasien"
        Me.lblNamaPasien.Size = New System.Drawing.Size(16, 21)
        Me.lblNamaPasien.TabIndex = 2
        Me.lblNamaPasien.Text = "-"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(6, 37)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 21)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "PASIEN:"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.ForeColor = System.Drawing.Color.Cyan
        Me.label1.Location = New System.Drawing.Point(3, 0)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(237, 37)
        Me.label1.TabIndex = 0
        Me.label1.Text = "THORAX VIEWER"
        '
        'GroupBox2
        '
        Me.GroupBox2.AutoSize = True
        Me.GroupBox2.Controls.Add(Me.cmbTglKanan)
        Me.GroupBox2.Controls.Add(Me.txtHasilKanan)
        Me.GroupBox2.Controls.Add(Me.lblStatusKanan)
        Me.GroupBox2.Controls.Add(Me.btnLoadKanan)
        Me.GroupBox2.Controls.Add(Me.picBoxKanan)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(635, 17)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(618, 584)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "PEMERIKSAAN TERBARU"
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
        'lblStatusKanan
        '
        Me.lblStatusKanan.AutoSize = True
        Me.lblStatusKanan.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusKanan.ForeColor = System.Drawing.Color.LimeGreen
        Me.lblStatusKanan.Location = New System.Drawing.Point(260, 27)
        Me.lblStatusKanan.Name = "lblStatusKanan"
        Me.lblStatusKanan.Size = New System.Drawing.Size(16, 21)
        Me.lblStatusKanan.TabIndex = 458
        Me.lblStatusKanan.Text = "-"
        '
        'btnLoadKanan
        '
        Me.btnLoadKanan.BackColor = System.Drawing.Color.Green
        Me.btnLoadKanan.FlatAppearance.BorderSize = 0
        Me.btnLoadKanan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadKanan.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoadKanan.ForeColor = System.Drawing.Color.White
        Me.btnLoadKanan.Location = New System.Drawing.Point(135, 24)
        Me.btnLoadKanan.Name = "btnLoadKanan"
        Me.btnLoadKanan.Size = New System.Drawing.Size(119, 25)
        Me.btnLoadKanan.TabIndex = 457
        Me.btnLoadKanan.Text = "Muat Gambar"
        Me.btnLoadKanan.UseVisualStyleBackColor = False
        '
        'picBoxKanan
        '
        Me.picBoxKanan.BackColor = System.Drawing.Color.Black
        Me.picBoxKanan.Location = New System.Drawing.Point(7, 56)
        Me.picBoxKanan.Name = "picBoxKanan"
        Me.picBoxKanan.Size = New System.Drawing.Size(605, 352)
        Me.picBoxKanan.TabIndex = 1
        Me.picBoxKanan.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.AutoSize = True
        Me.GroupBox1.Controls.Add(Me.cmbTglKiri)
        Me.GroupBox1.Controls.Add(Me.txtHasilKiri)
        Me.GroupBox1.Controls.Add(Me.lblStatusKiri)
        Me.GroupBox1.Controls.Add(Me.btnLoadKiri)
        Me.GroupBox1.Controls.Add(Me.picBoxKiri)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(11, 17)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(618, 583)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "PEMBANDING (SEBELUMNYA)"
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
        'lblStatusKiri
        '
        Me.lblStatusKiri.AutoSize = True
        Me.lblStatusKiri.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatusKiri.ForeColor = System.Drawing.Color.LimeGreen
        Me.lblStatusKiri.Location = New System.Drawing.Point(260, 25)
        Me.lblStatusKiri.Name = "lblStatusKiri"
        Me.lblStatusKiri.Size = New System.Drawing.Size(16, 21)
        Me.lblStatusKiri.TabIndex = 457
        Me.lblStatusKiri.Text = "-"
        '
        'btnLoadKiri
        '
        Me.btnLoadKiri.BackColor = System.Drawing.Color.SteelBlue
        Me.btnLoadKiri.FlatAppearance.BorderSize = 0
        Me.btnLoadKiri.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLoadKiri.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoadKiri.ForeColor = System.Drawing.Color.White
        Me.btnLoadKiri.Location = New System.Drawing.Point(135, 24)
        Me.btnLoadKiri.Name = "btnLoadKiri"
        Me.btnLoadKiri.Size = New System.Drawing.Size(119, 25)
        Me.btnLoadKiri.TabIndex = 456
        Me.btnLoadKiri.Text = "Muat Gambar"
        Me.btnLoadKiri.UseVisualStyleBackColor = False
        '
        'picBoxKiri
        '
        Me.picBoxKiri.BackColor = System.Drawing.Color.Black
        Me.picBoxKiri.Location = New System.Drawing.Point(7, 56)
        Me.picBoxKiri.Name = "picBoxKiri"
        Me.picBoxKiri.Size = New System.Drawing.Size(605, 352)
        Me.picBoxKiri.TabIndex = 0
        Me.picBoxKiri.TabStop = False
        '
        'FormThoraxViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(22, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1264, 681)
        Me.Controls.Add(Me.SplitContainer1)
        Me.MinimumSize = New System.Drawing.Size(1024, 650)
        Me.Name = "FormThoraxViewer"
        Me.Text = "FormThoraxViewer"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.picBoxKanan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.picBoxKiri, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents label1 As System.Windows.Forms.Label
    Friend WithEvents lblNamaPasien As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents picBoxKiri As System.Windows.Forms.PictureBox
    Friend WithEvents picBoxKanan As System.Windows.Forms.PictureBox
    Friend WithEvents btnLoadKiri As System.Windows.Forms.Button
    Friend WithEvents btnLoadKanan As System.Windows.Forms.Button
    Friend WithEvents txtNik As System.Windows.Forms.TextBox
    Friend WithEvents lblNik As System.Windows.Forms.Label
    Friend WithEvents lblStatusKanan As System.Windows.Forms.Label
    Friend WithEvents lblStatusKiri As System.Windows.Forms.Label
    Friend WithEvents chkSyncZoom As System.Windows.Forms.CheckBox
    Friend WithEvents btnResetView As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents txtHasilKiri As System.Windows.Forms.TextBox
    Friend WithEvents txtHasilKanan As System.Windows.Forms.TextBox
    Friend WithEvents cmbTglKiri As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTglKanan As System.Windows.Forms.ComboBox
End Class
