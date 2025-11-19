<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class WhatsAppSetting
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(WhatsAppSetting))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.ButtonGetQR = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ButtonRestart = New System.Windows.Forms.Button
        Me.ButtonLogout = New System.Windows.Forms.Button
        Me.LabelStatus = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.ButtonCekKoneksi = New System.Windows.Forms.Button
        Me.TextBoxToken = New System.Windows.Forms.TextBox
        Me.TextBoxID = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.LabelPlatform = New System.Windows.Forms.Label
        Me.LabelNama = New System.Windows.Forms.Label
        Me.LabelNoHp = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.ButtonUpdateIP = New System.Windows.Forms.Button
        Me.TextBoxIPLab = New System.Windows.Forms.TextBox
        Me.TextBoxIPKlinik = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.ButtonKirim = New System.Windows.Forms.Button
        Me.GroupBox9 = New System.Windows.Forms.GroupBox
        Me.RadioButtonTidak = New System.Windows.Forms.RadioButton
        Me.RadioButtonIya = New System.Windows.Forms.RadioButton
        Me.TextBoxNoHp = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.LabelStatusWA = New System.Windows.Forms.Label
        Me.ButtonCekKoneksiWA = New System.Windows.Forms.Button
        Me.GroupBox10 = New System.Windows.Forms.GroupBox
        Me.ButtonStart = New System.Windows.Forms.Button
        Me.ToggleSwitchLab = New PoliKlinik_Net2.ToggleSwitch
        Me.ToggleSwitchKlinik = New PoliKlinik_Net2.ToggleSwitch
        Me.Label14 = New System.Windows.Forms.Label
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(19, 21)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(233, 241)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'ButtonGetQR
        '
        Me.ButtonGetQR.BackColor = System.Drawing.Color.Bisque
        Me.ButtonGetQR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonGetQR.FlatAppearance.BorderSize = 0
        Me.ButtonGetQR.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonGetQR.ForeColor = System.Drawing.Color.Black
        Me.ButtonGetQR.Location = New System.Drawing.Point(19, 268)
        Me.ButtonGetQR.Name = "ButtonGetQR"
        Me.ButtonGetQR.Size = New System.Drawing.Size(107, 23)
        Me.ButtonGetQR.TabIndex = 1
        Me.ButtonGetQR.Text = "GET QR CODE"
        Me.ButtonGetQR.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ButtonRestart)
        Me.GroupBox1.Controls.Add(Me.ButtonLogout)
        Me.GroupBox1.Controls.Add(Me.LabelStatus)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.ButtonCekKoneksi)
        Me.GroupBox1.Controls.Add(Me.TextBoxToken)
        Me.GroupBox1.Controls.Add(Me.TextBoxID)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(10, 19)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(393, 181)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Koneksi WhatsApp"
        '
        'ButtonRestart
        '
        Me.ButtonRestart.BackColor = System.Drawing.Color.OrangeRed
        Me.ButtonRestart.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonRestart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonRestart.ForeColor = System.Drawing.Color.White
        Me.ButtonRestart.Location = New System.Drawing.Point(241, 141)
        Me.ButtonRestart.Name = "ButtonRestart"
        Me.ButtonRestart.Size = New System.Drawing.Size(107, 25)
        Me.ButtonRestart.TabIndex = 8
        Me.ButtonRestart.Text = "Restart"
        Me.ButtonRestart.UseVisualStyleBackColor = False
        '
        'ButtonLogout
        '
        Me.ButtonLogout.BackColor = System.Drawing.Color.Crimson
        Me.ButtonLogout.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonLogout.ForeColor = System.Drawing.Color.White
        Me.ButtonLogout.Location = New System.Drawing.Point(128, 141)
        Me.ButtonLogout.Name = "ButtonLogout"
        Me.ButtonLogout.Size = New System.Drawing.Size(107, 25)
        Me.ButtonLogout.TabIndex = 7
        Me.ButtonLogout.Text = "Logout"
        Me.ButtonLogout.UseVisualStyleBackColor = False
        '
        'LabelStatus
        '
        Me.LabelStatus.AutoSize = True
        Me.LabelStatus.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelStatus.Location = New System.Drawing.Point(87, 107)
        Me.LabelStatus.Name = "LabelStatus"
        Me.LabelStatus.Size = New System.Drawing.Size(13, 17)
        Me.LabelStatus.TabIndex = 6
        Me.LabelStatus.Text = "-"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 109)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Status :"
        '
        'ButtonCekKoneksi
        '
        Me.ButtonCekKoneksi.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.ButtonCekKoneksi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonCekKoneksi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCekKoneksi.ForeColor = System.Drawing.Color.White
        Me.ButtonCekKoneksi.Location = New System.Drawing.Point(15, 141)
        Me.ButtonCekKoneksi.Name = "ButtonCekKoneksi"
        Me.ButtonCekKoneksi.Size = New System.Drawing.Size(107, 25)
        Me.ButtonCekKoneksi.TabIndex = 4
        Me.ButtonCekKoneksi.Text = "Cek Koneksi"
        Me.ButtonCekKoneksi.UseVisualStyleBackColor = False
        '
        'TextBoxToken
        '
        Me.TextBoxToken.Enabled = False
        Me.TextBoxToken.Location = New System.Drawing.Point(90, 69)
        Me.TextBoxToken.Name = "TextBoxToken"
        Me.TextBoxToken.Size = New System.Drawing.Size(249, 22)
        Me.TextBoxToken.TabIndex = 3
        '
        'TextBoxID
        '
        Me.TextBoxID.Enabled = False
        Me.TextBoxID.Location = New System.Drawing.Point(90, 30)
        Me.TextBoxID.Name = "TextBoxID"
        Me.TextBoxID.Size = New System.Drawing.Size(249, 22)
        Me.TextBoxID.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Token :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Instance ID :"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.PictureBox1)
        Me.GroupBox2.Controls.Add(Me.ButtonGetQR)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(417, 19)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(270, 305)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "QR Login Whatsapp"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.LabelPlatform)
        Me.GroupBox3.Controls.Add(Me.LabelNama)
        Me.GroupBox3.Controls.Add(Me.LabelNoHp)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(10, 206)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(393, 118)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Status Login"
        '
        'LabelPlatform
        '
        Me.LabelPlatform.AutoSize = True
        Me.LabelPlatform.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPlatform.Location = New System.Drawing.Point(69, 88)
        Me.LabelPlatform.Name = "LabelPlatform"
        Me.LabelPlatform.Size = New System.Drawing.Size(13, 17)
        Me.LabelPlatform.TabIndex = 8
        Me.LabelPlatform.Text = "-"
        '
        'LabelNama
        '
        Me.LabelNama.AutoSize = True
        Me.LabelNama.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNama.Location = New System.Drawing.Point(69, 60)
        Me.LabelNama.Name = "LabelNama"
        Me.LabelNama.Size = New System.Drawing.Size(13, 17)
        Me.LabelNama.TabIndex = 7
        Me.LabelNama.Text = "-"
        '
        'LabelNoHp
        '
        Me.LabelNoHp.AutoSize = True
        Me.LabelNoHp.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNoHp.Location = New System.Drawing.Point(69, 31)
        Me.LabelNoHp.Name = "LabelNoHp"
        Me.LabelNoHp.Size = New System.Drawing.Size(13, 17)
        Me.LabelNoHp.TabIndex = 6
        Me.LabelNoHp.Text = "-"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 91)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Platform :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 62)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Nama :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 33)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "No HP :"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.GroupBox1)
        Me.GroupBox4.Controls.Add(Me.GroupBox2)
        Me.GroupBox4.Controls.Add(Me.GroupBox3)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(696, 339)
        Me.GroupBox4.TabIndex = 5
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "WhatsApp API urlMsg"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label14)
        Me.GroupBox5.Controls.Add(Me.ButtonStart)
        Me.GroupBox5.Controls.Add(Me.GroupBox10)
        Me.GroupBox5.Controls.Add(Me.ButtonCekKoneksiWA)
        Me.GroupBox5.Controls.Add(Me.GroupBox7)
        Me.GroupBox5.Controls.Add(Me.GroupBox6)
        Me.GroupBox5.Controls.Add(Me.ButtonUpdateIP)
        Me.GroupBox5.Controls.Add(Me.TextBoxIPLab)
        Me.GroupBox5.Controls.Add(Me.TextBoxIPKlinik)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Controls.Add(Me.Label4)
        Me.GroupBox5.Location = New System.Drawing.Point(12, 358)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(696, 145)
        Me.GroupBox5.TabIndex = 6
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "WhatsApp Lokal Baileys"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.Label11)
        Me.GroupBox7.Controls.Add(Me.Label12)
        Me.GroupBox7.Controls.Add(Me.ToggleSwitchLab)
        Me.GroupBox7.Location = New System.Drawing.Point(550, 21)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(127, 53)
        Me.GroupBox7.TabIndex = 4
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Status LAB"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 26)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(27, 13)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "OFF"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(95, 26)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(23, 13)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "ON"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Label10)
        Me.GroupBox6.Controls.Add(Me.Label9)
        Me.GroupBox6.Controls.Add(Me.ToggleSwitchKlinik)
        Me.GroupBox6.Location = New System.Drawing.Point(417, 21)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(127, 53)
        Me.GroupBox6.TabIndex = 0
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Status Klinik"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 26)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(27, 13)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "OFF"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(95, 26)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(23, 13)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "ON"
        '
        'ButtonUpdateIP
        '
        Me.ButtonUpdateIP.BackColor = System.Drawing.Color.Moccasin
        Me.ButtonUpdateIP.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonUpdateIP.FlatAppearance.BorderSize = 0
        Me.ButtonUpdateIP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonUpdateIP.ForeColor = System.Drawing.Color.Black
        Me.ButtonUpdateIP.Location = New System.Drawing.Point(25, 92)
        Me.ButtonUpdateIP.Name = "ButtonUpdateIP"
        Me.ButtonUpdateIP.Size = New System.Drawing.Size(107, 25)
        Me.ButtonUpdateIP.TabIndex = 5
        Me.ButtonUpdateIP.Text = "Update"
        Me.ButtonUpdateIP.UseVisualStyleBackColor = False
        '
        'TextBoxIPLab
        '
        Me.TextBoxIPLab.Location = New System.Drawing.Point(79, 54)
        Me.TextBoxIPLab.Name = "TextBoxIPLab"
        Me.TextBoxIPLab.Size = New System.Drawing.Size(249, 20)
        Me.TextBoxIPLab.TabIndex = 4
        '
        'TextBoxIPKlinik
        '
        Me.TextBoxIPKlinik.Location = New System.Drawing.Point(79, 28)
        Me.TextBoxIPKlinik.Name = "TextBoxIPKlinik"
        Me.TextBoxIPKlinik.Size = New System.Drawing.Size(249, 20)
        Me.TextBoxIPKlinik.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(22, 57)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "IP LAB :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(22, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "IP Klinik :"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.ButtonKirim)
        Me.GroupBox8.Controls.Add(Me.GroupBox9)
        Me.GroupBox8.Controls.Add(Me.TextBoxNoHp)
        Me.GroupBox8.Controls.Add(Me.Label13)
        Me.GroupBox8.Location = New System.Drawing.Point(12, 513)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(403, 120)
        Me.GroupBox8.TabIndex = 7
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Test Kirim Pesan"
        '
        'ButtonKirim
        '
        Me.ButtonKirim.BackColor = System.Drawing.Color.MediumSeaGreen
        Me.ButtonKirim.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonKirim.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonKirim.ForeColor = System.Drawing.Color.White
        Me.ButtonKirim.Location = New System.Drawing.Point(272, 79)
        Me.ButtonKirim.Name = "ButtonKirim"
        Me.ButtonKirim.Size = New System.Drawing.Size(107, 25)
        Me.ButtonKirim.TabIndex = 7
        Me.ButtonKirim.Text = "Kirim"
        Me.ButtonKirim.UseVisualStyleBackColor = False
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.RadioButtonTidak)
        Me.GroupBox9.Controls.Add(Me.RadioButtonIya)
        Me.GroupBox9.Location = New System.Drawing.Point(25, 51)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(107, 53)
        Me.GroupBox9.TabIndex = 6
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Kirim Dokumen?"
        '
        'RadioButtonTidak
        '
        Me.RadioButtonTidak.AutoSize = True
        Me.RadioButtonTidak.Checked = True
        Me.RadioButtonTidak.Location = New System.Drawing.Point(52, 20)
        Me.RadioButtonTidak.Name = "RadioButtonTidak"
        Me.RadioButtonTidak.Size = New System.Drawing.Size(52, 17)
        Me.RadioButtonTidak.TabIndex = 1
        Me.RadioButtonTidak.TabStop = True
        Me.RadioButtonTidak.Text = "Tidak"
        Me.RadioButtonTidak.UseVisualStyleBackColor = True
        '
        'RadioButtonIya
        '
        Me.RadioButtonIya.AutoSize = True
        Me.RadioButtonIya.Location = New System.Drawing.Point(7, 20)
        Me.RadioButtonIya.Name = "RadioButtonIya"
        Me.RadioButtonIya.Size = New System.Drawing.Size(39, 17)
        Me.RadioButtonIya.TabIndex = 0
        Me.RadioButtonIya.Text = "Iya"
        Me.RadioButtonIya.UseVisualStyleBackColor = True
        '
        'TextBoxNoHp
        '
        Me.TextBoxNoHp.Location = New System.Drawing.Point(79, 25)
        Me.TextBoxNoHp.Name = "TextBoxNoHp"
        Me.TextBoxNoHp.Size = New System.Drawing.Size(249, 20)
        Me.TextBoxNoHp.TabIndex = 5
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(22, 27)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(45, 13)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "No HP :"
        '
        'LabelStatusWA
        '
        Me.LabelStatusWA.AutoSize = True
        Me.LabelStatusWA.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelStatusWA.Location = New System.Drawing.Point(32, 20)
        Me.LabelStatusWA.Name = "LabelStatusWA"
        Me.LabelStatusWA.Size = New System.Drawing.Size(13, 17)
        Me.LabelStatusWA.TabIndex = 6
        Me.LabelStatusWA.Text = "-"
        '
        'ButtonCekKoneksiWA
        '
        Me.ButtonCekKoneksiWA.BackColor = System.Drawing.Color.DodgerBlue
        Me.ButtonCekKoneksiWA.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonCekKoneksiWA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCekKoneksiWA.ForeColor = System.Drawing.Color.White
        Me.ButtonCekKoneksiWA.Location = New System.Drawing.Point(138, 92)
        Me.ButtonCekKoneksiWA.Name = "ButtonCekKoneksiWA"
        Me.ButtonCekKoneksiWA.Size = New System.Drawing.Size(107, 25)
        Me.ButtonCekKoneksiWA.TabIndex = 7
        Me.ButtonCekKoneksiWA.Text = "Cek Koneksi"
        Me.ButtonCekKoneksiWA.UseVisualStyleBackColor = False
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.LabelStatusWA)
        Me.GroupBox10.Location = New System.Drawing.Point(417, 80)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(127, 53)
        Me.GroupBox10.TabIndex = 8
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Koneksi"
        '
        'ButtonStart
        '
        Me.ButtonStart.BackColor = System.Drawing.Color.Red
        Me.ButtonStart.BackgroundImage = CType(resources.GetObject("ButtonStart.BackgroundImage"), System.Drawing.Image)
        Me.ButtonStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonStart.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonStart.ForeColor = System.Drawing.Color.White
        Me.ButtonStart.Image = CType(resources.GetObject("ButtonStart.Image"), System.Drawing.Image)
        Me.ButtonStart.Location = New System.Drawing.Point(348, 32)
        Me.ButtonStart.Name = "ButtonStart"
        Me.ButtonStart.Size = New System.Drawing.Size(45, 42)
        Me.ButtonStart.TabIndex = 9
        Me.ButtonStart.UseVisualStyleBackColor = False
        '
        'ToggleSwitchLab
        '
        Me.ToggleSwitchLab.Location = New System.Drawing.Point(39, 18)
        Me.ToggleSwitchLab.Name = "ToggleSwitchLab"
        Me.ToggleSwitchLab.Size = New System.Drawing.Size(50, 25)
        Me.ToggleSwitchLab.TabIndex = 0
        '
        'ToggleSwitchKlinik
        '
        Me.ToggleSwitchKlinik.Location = New System.Drawing.Point(39, 18)
        Me.ToggleSwitchKlinik.Name = "ToggleSwitchKlinik"
        Me.ToggleSwitchKlinik.Size = New System.Drawing.Size(50, 25)
        Me.ToggleSwitchKlinik.TabIndex = 0
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(340, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(63, 13)
        Me.Label14.TabIndex = 10
        Me.Label14.Text = "Start Server"
        '
        'WhatsAppSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(720, 659)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Name = "WhatsAppSetting"
        Me.Text = "WhatsAppSetting"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox9.PerformLayout()
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ButtonGetQR As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBoxToken As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonCekKoneksi As System.Windows.Forms.Button
    Friend WithEvents LabelStatus As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents LabelNoHp As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LabelNama As System.Windows.Forms.Label
    Friend WithEvents LabelPlatform As System.Windows.Forms.Label
    Friend WithEvents ButtonLogout As System.Windows.Forms.Button
    Friend WithEvents ButtonRestart As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBoxIPLab As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxIPKlinik As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ToggleSwitchKlinik As PoliKlinik_Net2.ToggleSwitch
    Friend WithEvents ButtonUpdateIP As System.Windows.Forms.Button
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ToggleSwitchLab As PoliKlinik_Net2.ToggleSwitch
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonKirim As System.Windows.Forms.Button
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButtonTidak As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonIya As System.Windows.Forms.RadioButton
    Friend WithEvents TextBoxNoHp As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents LabelStatusWA As System.Windows.Forms.Label
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents ButtonCekKoneksiWA As System.Windows.Forms.Button
    Friend WithEvents ButtonStart As System.Windows.Forms.Button
    Friend WithEvents Label14 As System.Windows.Forms.Label
End Class
