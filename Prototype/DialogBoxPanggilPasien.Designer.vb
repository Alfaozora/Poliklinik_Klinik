<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogBoxPanggilPasien
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DialogBoxPanggilPasien))
        Me.Label2 = New System.Windows.Forms.Label
        Me.PanelTop = New System.Windows.Forms.Panel
        Me.btnClose = New System.Windows.Forms.Button
        Me.PanelHeader = New System.Windows.Forms.Panel
        Me.ButtonStatusBatal = New System.Windows.Forms.Button
        Me.ButtonStatusHadir = New System.Windows.Forms.Button
        Me.ButtonStatusTidakHadir = New System.Windows.Forms.Button
        Me.ButtonStartProses = New System.Windows.Forms.Button
        Me.ButtonPanggilPasien = New System.Windows.Forms.Button
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PanelTop.SuspendLayout()
        Me.PanelHeader.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(57, 116)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(380, 25)
        Me.Label2.TabIndex = 206
        Me.Label2.Text = "Silakan Panggil Pasien / Mulai Pemeriksaan"
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.PanelTop.Controls.Add(Me.btnClose)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(494, 35)
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
        Me.btnClose.Location = New System.Drawing.Point(454, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(40, 35)
        Me.btnClose.TabIndex = 281
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'PanelHeader
        '
        Me.PanelHeader.BackColor = System.Drawing.Color.Transparent
        Me.PanelHeader.Controls.Add(Me.ButtonStatusBatal)
        Me.PanelHeader.Controls.Add(Me.ButtonStatusHadir)
        Me.PanelHeader.Controls.Add(Me.ButtonStatusTidakHadir)
        Me.PanelHeader.Controls.Add(Me.ButtonStartProses)
        Me.PanelHeader.Controls.Add(Me.ButtonPanggilPasien)
        Me.PanelHeader.Controls.Add(Me.PictureBox1)
        Me.PanelHeader.Controls.Add(Me.Label2)
        Me.PanelHeader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelHeader.Location = New System.Drawing.Point(0, 35)
        Me.PanelHeader.Name = "PanelHeader"
        Me.PanelHeader.Size = New System.Drawing.Size(494, 259)
        Me.PanelHeader.TabIndex = 6
        '
        'ButtonStatusBatal
        '
        Me.ButtonStatusBatal.BackColor = System.Drawing.Color.White
        Me.ButtonStatusBatal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonStatusBatal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonStatusBatal.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.ButtonStatusBatal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.ButtonStatusBatal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.ButtonStatusBatal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonStatusBatal.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonStatusBatal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.ButtonStatusBatal.Location = New System.Drawing.Point(293, 197)
        Me.ButtonStatusBatal.Name = "ButtonStatusBatal"
        Me.ButtonStatusBatal.Size = New System.Drawing.Size(100, 35)
        Me.ButtonStatusBatal.TabIndex = 451
        Me.ButtonStatusBatal.Text = "BATAL"
        Me.ButtonStatusBatal.UseVisualStyleBackColor = False
        Me.ButtonStatusBatal.Visible = False
        '
        'ButtonStatusHadir
        '
        Me.ButtonStatusHadir.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonStatusHadir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonStatusHadir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonStatusHadir.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.ButtonStatusHadir.FlatAppearance.BorderSize = 0
        Me.ButtonStatusHadir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonStatusHadir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonStatusHadir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonStatusHadir.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonStatusHadir.ForeColor = System.Drawing.Color.White
        Me.ButtonStatusHadir.Location = New System.Drawing.Point(81, 197)
        Me.ButtonStatusHadir.Name = "ButtonStatusHadir"
        Me.ButtonStatusHadir.Size = New System.Drawing.Size(100, 35)
        Me.ButtonStatusHadir.TabIndex = 450
        Me.ButtonStatusHadir.Text = "HADIR"
        Me.ButtonStatusHadir.UseVisualStyleBackColor = False
        Me.ButtonStatusHadir.Visible = False
        '
        'ButtonStatusTidakHadir
        '
        Me.ButtonStatusTidakHadir.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.ButtonStatusTidakHadir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonStatusTidakHadir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonStatusTidakHadir.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.ButtonStatusTidakHadir.FlatAppearance.BorderSize = 0
        Me.ButtonStatusTidakHadir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.ButtonStatusTidakHadir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(180, Byte), Integer), CType(CType(160, Byte), Integer))
        Me.ButtonStatusTidakHadir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonStatusTidakHadir.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonStatusTidakHadir.ForeColor = System.Drawing.Color.White
        Me.ButtonStatusTidakHadir.Location = New System.Drawing.Point(187, 197)
        Me.ButtonStatusTidakHadir.Name = "ButtonStatusTidakHadir"
        Me.ButtonStatusTidakHadir.Size = New System.Drawing.Size(100, 35)
        Me.ButtonStatusTidakHadir.TabIndex = 449
        Me.ButtonStatusTidakHadir.Text = "TIDAK HADIR"
        Me.ButtonStatusTidakHadir.UseVisualStyleBackColor = False
        Me.ButtonStatusTidakHadir.Visible = False
        '
        'ButtonStartProses
        '
        Me.ButtonStartProses.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonStartProses.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonStartProses.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonStartProses.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.ButtonStartProses.FlatAppearance.BorderSize = 0
        Me.ButtonStartProses.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonStartProses.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonStartProses.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonStartProses.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonStartProses.ForeColor = System.Drawing.Color.White
        Me.ButtonStartProses.Location = New System.Drawing.Point(159, 156)
        Me.ButtonStartProses.Name = "ButtonStartProses"
        Me.ButtonStartProses.Size = New System.Drawing.Size(150, 35)
        Me.ButtonStartProses.TabIndex = 448
        Me.ButtonStartProses.Text = "Mulai Pemeriksaan"
        Me.ButtonStartProses.UseVisualStyleBackColor = False
        '
        'ButtonPanggilPasien
        '
        Me.ButtonPanggilPasien.BackColor = System.Drawing.Color.White
        Me.ButtonPanggilPasien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonPanggilPasien.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonPanggilPasien.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonPanggilPasien.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonPanggilPasien.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonPanggilPasien.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonPanggilPasien.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonPanggilPasien.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonPanggilPasien.Location = New System.Drawing.Point(305, 48)
        Me.ButtonPanggilPasien.Name = "ButtonPanggilPasien"
        Me.ButtonPanggilPasien.Size = New System.Drawing.Size(150, 35)
        Me.ButtonPanggilPasien.TabIndex = 447
        Me.ButtonPanggilPasien.Text = "Panggil Pasien"
        Me.ButtonPanggilPasien.UseVisualStyleBackColor = False
        Me.ButtonPanggilPasien.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_treatment_80
        Me.PictureBox1.Location = New System.Drawing.Point(197, 33)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(80, 80)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 430
        Me.PictureBox1.TabStop = False
        '
        'DialogBoxPanggilPasien
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(494, 294)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelHeader)
        Me.Controls.Add(Me.PanelTop)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DialogBoxPanggilPasien"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.PanelTop.ResumeLayout(False)
        Me.PanelHeader.ResumeLayout(False)
        Me.PanelHeader.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents PanelHeader As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ButtonPanggilPasien As System.Windows.Forms.Button
    Friend WithEvents ButtonStartProses As System.Windows.Forms.Button
    Friend WithEvents ButtonStatusHadir As System.Windows.Forms.Button
    Friend WithEvents ButtonStatusTidakHadir As System.Windows.Forms.Button
    Friend WithEvents ButtonStatusBatal As System.Windows.Forms.Button
End Class
