<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AbsenDialog
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.dttime = New System.Windows.Forms.DateTimePicker
        Me.lblfinger = New System.Windows.Forms.Label
        Me.txdokterkode = New System.Windows.Forms.TextBox
        Me.txdokterjenis = New System.Windows.Forms.TextBox
        Me.txjenis = New System.Windows.Forms.TextBox
        Me.txuser = New System.Windows.Forms.TextBox
        Me.lbluser = New System.Windows.Forms.Label
        Me.butok = New System.Windows.Forms.Button
        Me.txpassword = New System.Windows.Forms.TextBox
        Me.lblpassword = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.picfoto = New System.Windows.Forms.PictureBox
        Me.txdokternama = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.picfoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dttime)
        Me.GroupBox1.Controls.Add(Me.lblfinger)
        Me.GroupBox1.Controls.Add(Me.txdokterkode)
        Me.GroupBox1.Controls.Add(Me.txdokterjenis)
        Me.GroupBox1.Controls.Add(Me.txjenis)
        Me.GroupBox1.Controls.Add(Me.txuser)
        Me.GroupBox1.Controls.Add(Me.lbluser)
        Me.GroupBox1.Controls.Add(Me.butok)
        Me.GroupBox1.Controls.Add(Me.txpassword)
        Me.GroupBox1.Controls.Add(Me.lblpassword)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.picfoto)
        Me.GroupBox1.Controls.Add(Me.txdokternama)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(492, 301)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        '
        'dttime
        '
        Me.dttime.CalendarFont = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dttime.CustomFormat = "dd-MMM-yyyy HH : mm : ss"
        Me.dttime.Enabled = False
        Me.dttime.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dttime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dttime.Location = New System.Drawing.Point(109, 22)
        Me.dttime.Name = "dttime"
        Me.dttime.Size = New System.Drawing.Size(275, 27)
        Me.dttime.TabIndex = 121
        '
        'lblfinger
        '
        Me.lblfinger.AutoSize = True
        Me.lblfinger.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblfinger.Location = New System.Drawing.Point(46, 235)
        Me.lblfinger.Name = "lblfinger"
        Me.lblfinger.Size = New System.Drawing.Size(77, 17)
        Me.lblfinger.TabIndex = 120
        Me.lblfinger.Text = "Password"
        Me.lblfinger.Visible = False
        '
        'txdokterkode
        '
        Me.txdokterkode.Enabled = False
        Me.txdokterkode.Location = New System.Drawing.Point(90, 108)
        Me.txdokterkode.MaxLength = 100
        Me.txdokterkode.Name = "txdokterkode"
        Me.txdokterkode.Size = New System.Drawing.Size(100, 20)
        Me.txdokterkode.TabIndex = 119
        '
        'txdokterjenis
        '
        Me.txdokterjenis.Enabled = False
        Me.txdokterjenis.Location = New System.Drawing.Point(90, 134)
        Me.txdokterjenis.MaxLength = 100
        Me.txdokterjenis.Name = "txdokterjenis"
        Me.txdokterjenis.Size = New System.Drawing.Size(194, 20)
        Me.txdokterjenis.TabIndex = 118
        '
        'txjenis
        '
        Me.txjenis.BackColor = System.Drawing.SystemColors.MenuBar
        Me.txjenis.Enabled = False
        Me.txjenis.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txjenis.Location = New System.Drawing.Point(6, 12)
        Me.txjenis.MaxLength = 100
        Me.txjenis.Multiline = True
        Me.txjenis.Name = "txjenis"
        Me.txjenis.Size = New System.Drawing.Size(83, 49)
        Me.txjenis.TabIndex = 117
        '
        'txuser
        '
        Me.txuser.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txuser.Location = New System.Drawing.Point(129, 200)
        Me.txuser.MaxLength = 100
        Me.txuser.Name = "txuser"
        Me.txuser.Size = New System.Drawing.Size(229, 24)
        Me.txuser.TabIndex = 2
        Me.txuser.Visible = False
        '
        'lbluser
        '
        Me.lbluser.AutoSize = True
        Me.lbluser.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbluser.Location = New System.Drawing.Point(46, 205)
        Me.lbluser.Name = "lbluser"
        Me.lbluser.Size = New System.Drawing.Size(57, 17)
        Me.lbluser.TabIndex = 115
        Me.lbluser.Text = "UserID"
        Me.lbluser.Visible = False
        '
        'butok
        '
        Me.butok.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.butok.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butok.Location = New System.Drawing.Point(209, 260)
        Me.butok.Name = "butok"
        Me.butok.Size = New System.Drawing.Size(75, 29)
        Me.butok.TabIndex = 4
        Me.butok.Text = "OK"
        Me.butok.UseVisualStyleBackColor = True
        '
        'txpassword
        '
        Me.txpassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txpassword.Location = New System.Drawing.Point(129, 230)
        Me.txpassword.MaxLength = 100
        Me.txpassword.Name = "txpassword"
        Me.txpassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txpassword.Size = New System.Drawing.Size(229, 24)
        Me.txpassword.TabIndex = 3
        Me.txpassword.UseSystemPasswordChar = True
        Me.txpassword.Visible = False
        '
        'lblpassword
        '
        Me.lblpassword.AutoSize = True
        Me.lblpassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblpassword.Location = New System.Drawing.Point(46, 235)
        Me.lblpassword.Name = "lblpassword"
        Me.lblpassword.Size = New System.Drawing.Size(77, 17)
        Me.lblpassword.TabIndex = 113
        Me.lblpassword.Text = "Password"
        Me.lblpassword.Visible = False
        '
        'Button2
        '
        Me.Button2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(275, 73)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(85, 29)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "Finger"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(133, 73)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(85, 29)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Barcode"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'picfoto
        '
        Me.picfoto.Enabled = False
        Me.picfoto.Location = New System.Drawing.Point(380, 104)
        Me.picfoto.Name = "picfoto"
        Me.picfoto.Size = New System.Drawing.Size(100, 120)
        Me.picfoto.TabIndex = 109
        Me.picfoto.TabStop = False
        '
        'txdokternama
        '
        Me.txdokternama.Enabled = False
        Me.txdokternama.Location = New System.Drawing.Point(90, 160)
        Me.txdokternama.MaxLength = 100
        Me.txdokternama.Name = "txdokternama"
        Me.txdokternama.Size = New System.Drawing.Size(270, 20)
        Me.txdokternama.TabIndex = 94
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Enabled = False
        Me.Label9.Location = New System.Drawing.Point(47, 164)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(35, 13)
        Me.Label9.TabIndex = 38
        Me.Label9.Text = "Nama"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Enabled = False
        Me.Label2.Location = New System.Drawing.Point(47, 137)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Jenis"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Enabled = False
        Me.Label1.Location = New System.Drawing.Point(47, 111)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Kode"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'AbsenDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 301)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "AbsenDialog"
        Me.Text = "AbsenDialog"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.picfoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents picfoto As System.Windows.Forms.PictureBox
    Friend WithEvents txdokternama As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents butok As System.Windows.Forms.Button
    Friend WithEvents txpassword As System.Windows.Forms.TextBox
    Friend WithEvents lblpassword As System.Windows.Forms.Label
    Friend WithEvents txuser As System.Windows.Forms.TextBox
    Friend WithEvents lbluser As System.Windows.Forms.Label
    Friend WithEvents txjenis As System.Windows.Forms.TextBox
    Friend WithEvents txdokterkode As System.Windows.Forms.TextBox
    Friend WithEvents txdokterjenis As System.Windows.Forms.TextBox
    Friend WithEvents lblfinger As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents dttime As System.Windows.Forms.DateTimePicker
End Class
