<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KYC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(KYC))
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ComboBoxNama = New System.Windows.Forms.ComboBox
        Me.TextBoxNIK = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.PanduanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.VerifikasiProfil = New System.Windows.Forms.ToolStripMenuItem
        Me.GetKodeAkses = New System.Windows.Forms.ToolStripMenuItem
        Me.ButtonKirimAPI = New System.Windows.Forms.Button
        Me.ButtonVerifikasi = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Sans Serif Collection", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(112, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(297, 64)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "KNOW YOUR COSTUMER (KYC)"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ComboBoxNama)
        Me.GroupBox1.Controls.Add(Me.TextBoxNIK)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 97)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(504, 142)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Data Verifikator"
        '
        'ComboBoxNama
        '
        Me.ComboBoxNama.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.ComboBoxNama.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBoxNama.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxNama.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBoxNama.FormattingEnabled = True
        Me.ComboBoxNama.Location = New System.Drawing.Point(84, 39)
        Me.ComboBoxNama.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxNama.Name = "ComboBoxNama"
        Me.ComboBoxNama.Size = New System.Drawing.Size(285, 25)
        Me.ComboBoxNama.TabIndex = 509
        '
        'TextBoxNIK
        '
        Me.TextBoxNIK.Location = New System.Drawing.Point(84, 85)
        Me.TextBoxNIK.Multiline = True
        Me.TextBoxNIK.Name = "TextBoxNIK"
        Me.TextBoxNIK.Size = New System.Drawing.Size(285, 26)
        Me.TextBoxNIK.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(15, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "NIK"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(15, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 16)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Nama"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PanduanToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(539, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'PanduanToolStripMenuItem
        '
        Me.PanduanToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.VerifikasiProfil, Me.GetKodeAkses})
        Me.PanduanToolStripMenuItem.Name = "PanduanToolStripMenuItem"
        Me.PanduanToolStripMenuItem.Size = New System.Drawing.Size(66, 20)
        Me.PanduanToolStripMenuItem.Text = "Panduan"
        '
        'VerifikasiProfil
        '
        Me.VerifikasiProfil.Name = "VerifikasiProfil"
        Me.VerifikasiProfil.Size = New System.Drawing.Size(210, 22)
        Me.VerifikasiProfil.Text = "Verifikasi Profil KYC"
        '
        'GetKodeAkses
        '
        Me.GetKodeAkses.Name = "GetKodeAkses"
        Me.GetKodeAkses.Size = New System.Drawing.Size(210, 22)
        Me.GetKodeAkses.Text = "Mendapatkan Kode Akses"
        '
        'ButtonKirimAPI
        '
        Me.ButtonKirimAPI.BackColor = System.Drawing.Color.White
        Me.ButtonKirimAPI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonKirimAPI.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonKirimAPI.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonKirimAPI.FlatAppearance.BorderSize = 2
        Me.ButtonKirimAPI.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonKirimAPI.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonKirimAPI.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonKirimAPI.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonKirimAPI.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonKirimAPI.Image = CType(resources.GetObject("ButtonKirimAPI.Image"), System.Drawing.Image)
        Me.ButtonKirimAPI.Location = New System.Drawing.Point(246, 245)
        Me.ButtonKirimAPI.Name = "ButtonKirimAPI"
        Me.ButtonKirimAPI.Size = New System.Drawing.Size(132, 35)
        Me.ButtonKirimAPI.TabIndex = 525
        Me.ButtonKirimAPI.Text = "Kirim Data"
        Me.ButtonKirimAPI.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonKirimAPI.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonKirimAPI.UseVisualStyleBackColor = False
        '
        'ButtonVerifikasi
        '
        Me.ButtonVerifikasi.BackColor = System.Drawing.Color.White
        Me.ButtonVerifikasi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonVerifikasi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonVerifikasi.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonVerifikasi.FlatAppearance.BorderSize = 2
        Me.ButtonVerifikasi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonVerifikasi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonVerifikasi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonVerifikasi.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonVerifikasi.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonVerifikasi.Image = CType(resources.GetObject("ButtonVerifikasi.Image"), System.Drawing.Image)
        Me.ButtonVerifikasi.Location = New System.Drawing.Point(384, 245)
        Me.ButtonVerifikasi.Name = "ButtonVerifikasi"
        Me.ButtonVerifikasi.Size = New System.Drawing.Size(132, 35)
        Me.ButtonVerifikasi.TabIndex = 526
        Me.ButtonVerifikasi.Text = "Verifikasi KYC"
        Me.ButtonVerifikasi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonVerifikasi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonVerifikasi.UseVisualStyleBackColor = False
        '
        'KYC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.PoliKlinik_Net2.My.Resources.Resources.wallpaperdialog
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(539, 358)
        Me.Controls.Add(Me.ButtonVerifikasi)
        Me.Controls.Add(Me.ButtonKirimAPI)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "KYC"
        Me.Text = "KYC"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNIK As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxNama As System.Windows.Forms.ComboBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents PanduanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ButtonKirimAPI As System.Windows.Forms.Button
    Friend WithEvents ButtonVerifikasi As System.Windows.Forms.Button
    Friend WithEvents VerifikasiProfil As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GetKodeAkses As System.Windows.Forms.ToolStripMenuItem
End Class
