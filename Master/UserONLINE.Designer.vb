<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserONLINE
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserONLINE))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.ClearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txusernama = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.butfinduser = New System.Windows.Forms.Button
        Me.txid = New System.Windows.Forms.TextBox
        Me.grpdetail = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txbridging = New System.Windows.Forms.MaskedTextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.id = New System.Windows.Forms.TextBox
        Me.cmbjenisuser = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txuserpassword = New System.Windows.Forms.MaskedTextBox
        Me.MenuStrip1.SuspendLayout()
        Me.grpdetail.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearToolStripMenuItem, Me.SaveToolStripMenuItem, Me.CloseToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(402, 24)
        Me.MenuStrip1.TabIndex = 27
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(18, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 15)
        Me.Label2.TabIndex = 57
        Me.Label2.Text = "Username"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(13, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 15)
        Me.Label1.TabIndex = 73
        Me.Label1.Text = "Nama User"
        '
        'txusernama
        '
        Me.txusernama.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txusernama.Location = New System.Drawing.Point(90, 76)
        Me.txusernama.MaxLength = 50
        Me.txusernama.Name = "txusernama"
        Me.txusernama.Size = New System.Drawing.Size(264, 21)
        Me.txusernama.TabIndex = 74
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(20, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 15)
        Me.Label3.TabIndex = 75
        Me.Label3.Text = "Password"
        '
        'butfinduser
        '
        Me.butfinduser.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.butfinduser.Location = New System.Drawing.Point(323, 17)
        Me.butfinduser.Name = "butfinduser"
        Me.butfinduser.Size = New System.Drawing.Size(31, 25)
        Me.butfinduser.TabIndex = 183
        Me.butfinduser.Text = "..."
        Me.butfinduser.UseVisualStyleBackColor = True
        '
        'txid
        '
        Me.txid.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txid.Location = New System.Drawing.Point(90, 19)
        Me.txid.Name = "txid"
        Me.txid.Size = New System.Drawing.Size(232, 21)
        Me.txid.TabIndex = 184
        '
        'grpdetail
        '
        Me.grpdetail.Controls.Add(Me.Label6)
        Me.grpdetail.Controls.Add(Me.txbridging)
        Me.grpdetail.Controls.Add(Me.Label4)
        Me.grpdetail.Controls.Add(Me.id)
        Me.grpdetail.Controls.Add(Me.cmbjenisuser)
        Me.grpdetail.Controls.Add(Me.Label5)
        Me.grpdetail.Controls.Add(Me.txuserpassword)
        Me.grpdetail.Controls.Add(Me.txid)
        Me.grpdetail.Controls.Add(Me.butfinduser)
        Me.grpdetail.Controls.Add(Me.Label3)
        Me.grpdetail.Controls.Add(Me.txusernama)
        Me.grpdetail.Controls.Add(Me.Label1)
        Me.grpdetail.Controls.Add(Me.Label2)
        Me.grpdetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grpdetail.Location = New System.Drawing.Point(0, 24)
        Me.grpdetail.Name = "grpdetail"
        Me.grpdetail.Size = New System.Drawing.Size(402, 180)
        Me.grpdetail.TabIndex = 28
        Me.grpdetail.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(196, 134)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(187, 14)
        Me.Label6.TabIndex = 246
        Me.Label6.Text = "*Dengan Program Web Keuangan"
        '
        'txbridging
        '
        Me.txbridging.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txbridging.Location = New System.Drawing.Point(90, 131)
        Me.txbridging.Name = "txbridging"
        Me.txbridging.Size = New System.Drawing.Size(100, 21)
        Me.txbridging.TabIndex = 245
        Me.txbridging.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.txbridging.UseSystemPasswordChar = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(31, 134)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 15)
        Me.Label4.TabIndex = 244
        Me.Label4.Text = "Bridging"
        '
        'id
        '
        Me.id.Enabled = False
        Me.id.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.id.Location = New System.Drawing.Point(90, 19)
        Me.id.Name = "id"
        Me.id.Size = New System.Drawing.Size(42, 21)
        Me.id.TabIndex = 243
        Me.id.Visible = False
        '
        'cmbjenisuser
        '
        Me.cmbjenisuser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbjenisuser.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbjenisuser.FormattingEnabled = True
        Me.cmbjenisuser.Items.AddRange(New Object() {"Keuangan"})
        Me.cmbjenisuser.Location = New System.Drawing.Point(90, 45)
        Me.cmbjenisuser.Name = "cmbjenisuser"
        Me.cmbjenisuser.Size = New System.Drawing.Size(264, 24)
        Me.cmbjenisuser.TabIndex = 242
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(17, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 15)
        Me.Label5.TabIndex = 189
        Me.Label5.Text = "Jenis User"
        '
        'txuserpassword
        '
        Me.txuserpassword.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txuserpassword.Location = New System.Drawing.Point(90, 104)
        Me.txuserpassword.Name = "txuserpassword"
        Me.txuserpassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txuserpassword.Size = New System.Drawing.Size(100, 21)
        Me.txuserpassword.TabIndex = 187
        Me.txuserpassword.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.txuserpassword.UseSystemPasswordChar = True
        '
        'UserONLINE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(402, 204)
        Me.Controls.Add(Me.grpdetail)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "UserONLINE"
        Me.Text = "User Online"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.grpdetail.ResumeLayout(False)
        Me.grpdetail.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ClearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txusernama As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents butfinduser As System.Windows.Forms.Button
    Friend WithEvents txid As System.Windows.Forms.TextBox
    Friend WithEvents grpdetail As System.Windows.Forms.GroupBox
    Friend WithEvents txuserpassword As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbjenisuser As System.Windows.Forms.ComboBox
    Friend WithEvents id As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txbridging As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
