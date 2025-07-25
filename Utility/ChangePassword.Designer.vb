<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChangePassword
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
        Me.PasswordLabel = New System.Windows.Forms.Label
        Me.UsernameLabel = New System.Windows.Forms.Label
        Me.txusername = New System.Windows.Forms.TextBox
        Me.txpasswordlama = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txpasswordbaru = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txpasswordbaruulang = New System.Windows.Forms.TextBox
        Me.Cancel = New System.Windows.Forms.Button
        Me.OK = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'PasswordLabel
        '
        Me.PasswordLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PasswordLabel.Location = New System.Drawing.Point(12, 34)
        Me.PasswordLabel.Name = "PasswordLabel"
        Me.PasswordLabel.Size = New System.Drawing.Size(88, 23)
        Me.PasswordLabel.TabIndex = 11
        Me.PasswordLabel.Text = "Password Lama"
        Me.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UsernameLabel
        '
        Me.UsernameLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UsernameLabel.Location = New System.Drawing.Point(12, 9)
        Me.UsernameLabel.Name = "UsernameLabel"
        Me.UsernameLabel.Size = New System.Drawing.Size(88, 23)
        Me.UsernameLabel.TabIndex = 10
        Me.UsernameLabel.Text = "&User name"
        Me.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txusername
        '
        Me.txusername.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txusername.Enabled = False
        Me.txusername.Location = New System.Drawing.Point(106, 12)
        Me.txusername.Name = "txusername"
        Me.txusername.Size = New System.Drawing.Size(282, 20)
        Me.txusername.TabIndex = 8
        '
        'txpasswordlama
        '
        Me.txpasswordlama.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txpasswordlama.Location = New System.Drawing.Point(106, 38)
        Me.txpasswordlama.Name = "txpasswordlama"
        Me.txpasswordlama.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txpasswordlama.Size = New System.Drawing.Size(282, 20)
        Me.txpasswordlama.TabIndex = 9
        Me.txpasswordlama.UseSystemPasswordChar = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(12, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 23)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Password Baru"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txpasswordbaru
        '
        Me.txpasswordbaru.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txpasswordbaru.Location = New System.Drawing.Point(106, 79)
        Me.txpasswordbaru.Name = "txpasswordbaru"
        Me.txpasswordbaru.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txpasswordbaru.Size = New System.Drawing.Size(282, 20)
        Me.txpasswordbaru.TabIndex = 12
        Me.txpasswordbaru.UseSystemPasswordChar = True
        '
        'Label2
        '
        Me.Label2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.Location = New System.Drawing.Point(12, 101)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 34)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Ulang Password Baru"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txpasswordbaruulang
        '
        Me.txpasswordbaruulang.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txpasswordbaruulang.Location = New System.Drawing.Point(106, 105)
        Me.txpasswordbaruulang.Name = "txpasswordbaruulang"
        Me.txpasswordbaruulang.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txpasswordbaruulang.Size = New System.Drawing.Size(282, 20)
        Me.txpasswordbaruulang.TabIndex = 14
        Me.txpasswordbaruulang.UseSystemPasswordChar = True
        '
        'Cancel
        '
        Me.Cancel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.Location = New System.Drawing.Point(212, 146)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(86, 23)
        Me.Cancel.TabIndex = 17
        Me.Cancel.Text = "&Cancel"
        '
        'OK
        '
        Me.OK.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OK.Location = New System.Drawing.Point(101, 146)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(86, 23)
        Me.OK.TabIndex = 16
        Me.OK.Text = "&Save"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(65, 210)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(197, 20)
        Me.TextBox1.TabIndex = 18
        '
        'Button1
        '
        Me.Button1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(268, 208)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(86, 23)
        Me.Button1.TabIndex = 19
        Me.Button1.Text = "Process"
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.Location = New System.Drawing.Point(12, 208)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 23)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Encrypt"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(15, 237)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(373, 20)
        Me.TextBox2.TabIndex = 21
        '
        'ChangePassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(400, 182)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.OK)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txpasswordbaruulang)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txpasswordbaru)
        Me.Controls.Add(Me.PasswordLabel)
        Me.Controls.Add(Me.UsernameLabel)
        Me.Controls.Add(Me.txusername)
        Me.Controls.Add(Me.txpasswordlama)
        Me.Name = "ChangePassword"
        Me.Text = "ChangePassword"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PasswordLabel As System.Windows.Forms.Label
    Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents txusername As System.Windows.Forms.TextBox
    Friend WithEvents txpasswordlama As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txpasswordbaru As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txpasswordbaruulang As System.Windows.Forms.TextBox
    Friend WithEvents Cancel As System.Windows.Forms.Button
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
End Class
