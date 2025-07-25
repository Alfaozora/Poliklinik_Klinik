<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SettingUser
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.ClearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.grpdetail = New System.Windows.Forms.GroupBox
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.butuser = New System.Windows.Forms.TextBox
        Me.butfinduser = New System.Windows.Forms.Button
        Me.Picture1 = New System.Windows.Forms.PictureBox
        Me.Sta = New System.Windows.Forms.TextBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmbgudang = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbgroupid = New System.Windows.Forms.ComboBox
        Me.txuserpassword = New System.Windows.Forms.MaskedTextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txusernama = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.dtupdate = New System.Windows.Forms.DateTimePicker
        Me.Label14 = New System.Windows.Forms.Label
        Me.txupdate = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.dtcreate = New System.Windows.Forms.DateTimePicker
        Me.Label12 = New System.Windows.Forms.Label
        Me.txcreate = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        Me.grpdetail.SuspendLayout()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearToolStripMenuItem, Me.SaveToolStripMenuItem, Me.CloseToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(350, 24)
        Me.MenuStrip1.TabIndex = 9
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ClearToolStripMenuItem
        '
        Me.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem"
        Me.ClearToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.ClearToolStripMenuItem.Text = "New"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'grpdetail
        '
        Me.grpdetail.Controls.Add(Me.Button5)
        Me.grpdetail.Controls.Add(Me.Button4)
        Me.grpdetail.Controls.Add(Me.butuser)
        Me.grpdetail.Controls.Add(Me.butfinduser)
        Me.grpdetail.Controls.Add(Me.Picture1)
        Me.grpdetail.Controls.Add(Me.Sta)
        Me.grpdetail.Controls.Add(Me.Button3)
        Me.grpdetail.Controls.Add(Me.Button2)
        Me.grpdetail.Controls.Add(Me.Button1)
        Me.grpdetail.Controls.Add(Me.Label5)
        Me.grpdetail.Controls.Add(Me.cmbgudang)
        Me.grpdetail.Controls.Add(Me.Label4)
        Me.grpdetail.Controls.Add(Me.cmbgroupid)
        Me.grpdetail.Controls.Add(Me.txuserpassword)
        Me.grpdetail.Controls.Add(Me.Label3)
        Me.grpdetail.Controls.Add(Me.txusernama)
        Me.grpdetail.Controls.Add(Me.Label1)
        Me.grpdetail.Controls.Add(Me.GroupBox3)
        Me.grpdetail.Controls.Add(Me.Label2)
        Me.grpdetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpdetail.Location = New System.Drawing.Point(0, 24)
        Me.grpdetail.Name = "grpdetail"
        Me.grpdetail.Size = New System.Drawing.Size(350, 244)
        Me.grpdetail.TabIndex = 26
        Me.grpdetail.TabStop = False
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(195, 165)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 186
        Me.Button5.Text = "ON USER"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(81, 165)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 185
        Me.Button4.Text = "OFF USER"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'butuser
        '
        Me.butuser.Enabled = False
        Me.butuser.Location = New System.Drawing.Point(79, 15)
        Me.butuser.Name = "butuser"
        Me.butuser.Size = New System.Drawing.Size(107, 20)
        Me.butuser.TabIndex = 184
        '
        'butfinduser
        '
        Me.butfinduser.Location = New System.Drawing.Point(191, 13)
        Me.butfinduser.Name = "butfinduser"
        Me.butfinduser.Size = New System.Drawing.Size(31, 23)
        Me.butfinduser.TabIndex = 183
        Me.butfinduser.Text = "..."
        Me.butfinduser.UseVisualStyleBackColor = True
        '
        'Picture1
        '
        Me.Picture1.BackColor = System.Drawing.SystemColors.Control
        Me.Picture1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Picture1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Picture1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Picture1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.Picture1.Location = New System.Drawing.Point(594, 14)
        Me.Picture1.Name = "Picture1"
        Me.Picture1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Picture1.Size = New System.Drawing.Size(97, 113)
        Me.Picture1.TabIndex = 85
        Me.Picture1.TabStop = False
        '
        'Sta
        '
        Me.Sta.Enabled = False
        Me.Sta.Location = New System.Drawing.Point(437, 118)
        Me.Sta.MaxLength = 3
        Me.Sta.Name = "Sta"
        Me.Sta.Size = New System.Drawing.Size(144, 20)
        Me.Sta.TabIndex = 84
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(506, 44)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 83
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(506, 14)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 27
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(268, 97)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 28
        Me.Button1.Text = "Unlock User"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(276, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 81
        Me.Label5.Text = "Gudang"
        Me.Label5.Visible = False
        '
        'cmbgudang
        '
        Me.cmbgudang.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbgudang.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbgudang.FormattingEnabled = True
        Me.cmbgudang.Items.AddRange(New Object() {"-"})
        Me.cmbgudang.Location = New System.Drawing.Point(327, 44)
        Me.cmbgudang.MaxLength = 10
        Me.cmbgudang.Name = "cmbgudang"
        Me.cmbgudang.Size = New System.Drawing.Size(151, 21)
        Me.cmbgudang.TabIndex = 80
        Me.cmbgudang.Text = "-"
        Me.cmbgudang.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(28, 47)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 78
        Me.Label4.Text = "GroupID"
        '
        'cmbgroupid
        '
        Me.cmbgroupid.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbgroupid.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbgroupid.FormattingEnabled = True
        Me.cmbgroupid.Location = New System.Drawing.Point(79, 44)
        Me.cmbgroupid.MaxLength = 10
        Me.cmbgroupid.Name = "cmbgroupid"
        Me.cmbgroupid.Size = New System.Drawing.Size(151, 21)
        Me.cmbgroupid.TabIndex = 77
        '
        'txuserpassword
        '
        Me.txuserpassword.Location = New System.Drawing.Point(79, 97)
        Me.txuserpassword.Name = "txuserpassword"
        Me.txuserpassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txuserpassword.Size = New System.Drawing.Size(100, 20)
        Me.txuserpassword.TabIndex = 76
        Me.txuserpassword.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.txuserpassword.UseSystemPasswordChar = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 75
        Me.Label3.Text = "Password"
        '
        'txusernama
        '
        Me.txusernama.Location = New System.Drawing.Point(79, 71)
        Me.txusernama.MaxLength = 50
        Me.txusernama.Name = "txusernama"
        Me.txusernama.Size = New System.Drawing.Size(264, 20)
        Me.txusernama.TabIndex = 74
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 73
        Me.Label1.Text = "Nama User"
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.SystemColors.MenuBar
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.dtupdate)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.txupdate)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.dtcreate)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.txcreate)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox3.Enabled = False
        Me.GroupBox3.Location = New System.Drawing.Point(3, 194)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(344, 47)
        Me.GroupBox3.TabIndex = 72
        Me.GroupBox3.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Enabled = False
        Me.Label13.Location = New System.Drawing.Point(354, 23)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(65, 13)
        Me.Label13.TabIndex = 52
        Me.Label13.Text = "UpdateDate"
        '
        'dtupdate
        '
        Me.dtupdate.CustomFormat = "dd-MMM-yyyy"
        Me.dtupdate.Enabled = False
        Me.dtupdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtupdate.Location = New System.Drawing.Point(425, 19)
        Me.dtupdate.Name = "dtupdate"
        Me.dtupdate.Size = New System.Drawing.Size(100, 20)
        Me.dtupdate.TabIndex = 51
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Enabled = False
        Me.Label14.Location = New System.Drawing.Point(531, 22)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(54, 13)
        Me.Label14.TabIndex = 49
        Me.Label14.Text = "UpdateBy"
        '
        'txupdate
        '
        Me.txupdate.Enabled = False
        Me.txupdate.Location = New System.Drawing.Point(591, 19)
        Me.txupdate.MaxLength = 3
        Me.txupdate.Name = "txupdate"
        Me.txupdate.Size = New System.Drawing.Size(93, 20)
        Me.txupdate.TabIndex = 50
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Enabled = False
        Me.Label11.Location = New System.Drawing.Point(9, 23)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(61, 13)
        Me.Label11.TabIndex = 48
        Me.Label11.Text = "CreateDate"
        '
        'dtcreate
        '
        Me.dtcreate.CustomFormat = "dd-MMM-yyyy"
        Me.dtcreate.Enabled = False
        Me.dtcreate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtcreate.Location = New System.Drawing.Point(76, 19)
        Me.dtcreate.Name = "dtcreate"
        Me.dtcreate.Size = New System.Drawing.Size(100, 20)
        Me.dtcreate.TabIndex = 47
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Enabled = False
        Me.Label12.Location = New System.Drawing.Point(182, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(50, 13)
        Me.Label12.TabIndex = 45
        Me.Label12.Text = "CreateBy"
        '
        'txcreate
        '
        Me.txcreate.Enabled = False
        Me.txcreate.Location = New System.Drawing.Point(238, 19)
        Me.txcreate.MaxLength = 3
        Me.txcreate.Name = "txcreate"
        Me.txcreate.Size = New System.Drawing.Size(93, 20)
        Me.txcreate.TabIndex = 46
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 57
        Me.Label2.Text = "User ID"
        '
        'SettingUser
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(350, 268)
        Me.Controls.Add(Me.grpdetail)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SettingUser"
        Me.Text = "SettingUser"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.grpdetail.ResumeLayout(False)
        Me.grpdetail.PerformLayout()
        CType(Me.Picture1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ClearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents grpdetail As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents dtupdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txupdate As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtcreate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txcreate As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txusernama As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txuserpassword As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbgroupid As System.Windows.Forms.ComboBox
    'Friend WithEvents butuser As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbgudang As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Sta As System.Windows.Forms.TextBox
    Public WithEvents Picture1 As System.Windows.Forms.PictureBox
    Friend WithEvents butuser As System.Windows.Forms.TextBox
    Friend WithEvents butfinduser As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
End Class
