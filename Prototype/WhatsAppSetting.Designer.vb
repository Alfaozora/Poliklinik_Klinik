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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.ButtonGetQR = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.LabelStatus = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.ButtonCekKoneksi = New System.Windows.Forms.Button
        Me.TextBoxToken = New System.Windows.Forms.TextBox
        Me.TextBoxID = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.LabelNoHp = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.LabelNama = New System.Windows.Forms.Label
        Me.LabelPlatform = New System.Windows.Forms.Label
        Me.ButtonLogout = New System.Windows.Forms.Button
        Me.ButtonRestart = New System.Windows.Forms.Button
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
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
        Me.GroupBox1.Location = New System.Drawing.Point(12, 21)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(393, 181)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Koneksi WhatsApp"
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
        Me.GroupBox2.Location = New System.Drawing.Point(422, 21)
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
        Me.GroupBox3.Location = New System.Drawing.Point(12, 208)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(393, 118)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Status Login"
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
        'WhatsAppSetting
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(710, 471)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "WhatsAppSetting"
        Me.Text = "WhatsAppSetting"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
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
End Class
