<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class Login
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
    Friend WithEvents UsernameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents Cancel As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.UsernameTextBox = New System.Windows.Forms.TextBox
        Me.PasswordTextBox = New System.Windows.Forms.TextBox
        Me.Cancel = New System.Windows.Forms.Button
        Me.lblalamat = New System.Windows.Forms.Label
        Me.LabelVersiProgram = New System.Windows.Forms.Label
        Me.cmbjenis = New System.Windows.Forms.ComboBox
        Me.OK = New System.Windows.Forms.Button
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Shutdown = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'UsernameTextBox
        '
        Me.UsernameTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.UsernameTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UsernameTextBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.UsernameTextBox.Location = New System.Drawing.Point(202, 118)
        Me.UsernameTextBox.Multiline = True
        Me.UsernameTextBox.Name = "UsernameTextBox"
        Me.UsernameTextBox.Size = New System.Drawing.Size(200, 33)
        Me.UsernameTextBox.TabIndex = 1
        Me.UsernameTextBox.Text = "username"
        '
        'PasswordTextBox
        '
        Me.PasswordTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PasswordTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PasswordTextBox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.PasswordTextBox.Location = New System.Drawing.Point(202, 164)
        Me.PasswordTextBox.Multiline = True
        Me.PasswordTextBox.Name = "PasswordTextBox"
        Me.PasswordTextBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.PasswordTextBox.Size = New System.Drawing.Size(200, 33)
        Me.PasswordTextBox.TabIndex = 3
        Me.PasswordTextBox.Text = "password"
        '
        'Cancel
        '
        Me.Cancel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel.Location = New System.Drawing.Point(39, 311)
        Me.Cancel.Name = "Cancel"
        Me.Cancel.Size = New System.Drawing.Size(89, 23)
        Me.Cancel.TabIndex = 5
        Me.Cancel.Text = "&Cancel"
        Me.Cancel.Visible = False
        '
        'lblalamat
        '
        Me.lblalamat.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblalamat.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblalamat.Location = New System.Drawing.Point(-94, 348)
        Me.lblalamat.Name = "lblalamat"
        Me.lblalamat.Size = New System.Drawing.Size(317, 73)
        Me.lblalamat.TabIndex = 3
        Me.lblalamat.Text = "Label2"
        Me.lblalamat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblalamat.Visible = False
        '
        'LabelVersiProgram
        '
        Me.LabelVersiProgram.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelVersiProgram.BackColor = System.Drawing.SystemColors.Control
        Me.LabelVersiProgram.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LabelVersiProgram.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelVersiProgram.ForeColor = System.Drawing.Color.Black
        Me.LabelVersiProgram.Location = New System.Drawing.Point(171, 298)
        Me.LabelVersiProgram.Name = "LabelVersiProgram"
        Me.LabelVersiProgram.Size = New System.Drawing.Size(231, 31)
        Me.LabelVersiProgram.TabIndex = 2
        Me.LabelVersiProgram.Text = "Versi Program"
        Me.LabelVersiProgram.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.ToolTip1.SetToolTip(Me.LabelVersiProgram, "Check Version Info")
        '
        'cmbjenis
        '
        Me.cmbjenis.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbjenis.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbjenis.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbjenis.FormattingEnabled = True
        Me.cmbjenis.Items.AddRange(New Object() {"POLI"})
        Me.cmbjenis.Location = New System.Drawing.Point(174, 217)
        Me.cmbjenis.Name = "cmbjenis"
        Me.cmbjenis.Size = New System.Drawing.Size(128, 28)
        Me.cmbjenis.TabIndex = 6
        '
        'OK
        '
        Me.OK.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OK.BackColor = System.Drawing.Color.DodgerBlue
        Me.OK.BackgroundImage = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_login
        Me.OK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.OK.FlatAppearance.BorderSize = 0
        Me.OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OK.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OK.ForeColor = System.Drawing.Color.Cornsilk
        Me.OK.Location = New System.Drawing.Point(308, 207)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(94, 48)
        Me.OK.TabIndex = 4
        Me.OK.UseVisualStyleBackColor = False
        '
        'ToolTip1
        '
        Me.ToolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.ToolTip1.ToolTipTitle = "Detail"
        '
        'Shutdown
        '
        '
        'Login
        '
        Me.AcceptButton = Me.OK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CancelButton = Me.Cancel
        Me.ClientSize = New System.Drawing.Size(574, 388)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmbjenis)
        Me.Controls.Add(Me.Cancel)
        Me.Controls.Add(Me.lblalamat)
        Me.Controls.Add(Me.LabelVersiProgram)
        Me.Controls.Add(Me.UsernameTextBox)
        Me.Controls.Add(Me.OK)
        Me.Controls.Add(Me.PasswordTextBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Login"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblalamat As System.Windows.Forms.Label
    Friend WithEvents LabelVersiProgram As System.Windows.Forms.Label
    Friend WithEvents cmbjenis As System.Windows.Forms.ComboBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Shutdown As System.Windows.Forms.Timer

End Class
