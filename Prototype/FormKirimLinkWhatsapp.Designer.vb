<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormKirimLinkWhatsapp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormKirimLinkWhatsapp))
        Me.PanelTop = New System.Windows.Forms.Panel
        Me.btnClose = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label55 = New System.Windows.Forms.Label
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.RadioButtonNoBebas = New System.Windows.Forms.RadioButton
        Me.RadioButtonNoPribadi = New System.Windows.Forms.RadioButton
        Me.RadioButtonNoCUG = New System.Windows.Forms.RadioButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.TextBoxNomorWhatsapp = New System.Windows.Forms.TextBox
        Me.ButtonSave = New System.Windows.Forms.Button
        Me.PanelTop.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.PanelTop.Controls.Add(Me.btnClose)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(394, 40)
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
        Me.btnClose.Location = New System.Drawing.Point(354, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(40, 40)
        Me.btnClose.TabIndex = 281
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Label55)
        Me.Panel1.Controls.Add(Me.Panel7)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.TextBoxNomorWhatsapp)
        Me.Panel1.Controls.Add(Me.ButtonSave)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 40)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(394, 204)
        Me.Panel1.TabIndex = 6
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label55.Location = New System.Drawing.Point(25, 18)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(84, 17)
        Me.Label55.TabIndex = 457
        Me.Label55.Text = "Jenis Nomor"
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Transparent
        Me.Panel7.Controls.Add(Me.RadioButtonNoBebas)
        Me.Panel7.Controls.Add(Me.RadioButtonNoPribadi)
        Me.Panel7.Controls.Add(Me.RadioButtonNoCUG)
        Me.Panel7.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Panel7.Location = New System.Drawing.Point(131, 13)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(200, 55)
        Me.Panel7.TabIndex = 458
        '
        'RadioButtonNoBebas
        '
        Me.RadioButtonNoBebas.AutoSize = True
        Me.RadioButtonNoBebas.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonNoBebas.Location = New System.Drawing.Point(95, 5)
        Me.RadioButtonNoBebas.Name = "RadioButtonNoBebas"
        Me.RadioButtonNoBebas.Size = New System.Drawing.Size(72, 19)
        Me.RadioButtonNoBebas.TabIndex = 247
        Me.RadioButtonNoBebas.TabStop = True
        Me.RadioButtonNoBebas.Text = "Free Text"
        Me.RadioButtonNoBebas.UseVisualStyleBackColor = True
        '
        'RadioButtonNoPribadi
        '
        Me.RadioButtonNoPribadi.AutoSize = True
        Me.RadioButtonNoPribadi.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonNoPribadi.Location = New System.Drawing.Point(3, 5)
        Me.RadioButtonNoPribadi.Name = "RadioButtonNoPribadi"
        Me.RadioButtonNoPribadi.Size = New System.Drawing.Size(84, 19)
        Me.RadioButtonNoPribadi.TabIndex = 245
        Me.RadioButtonNoPribadi.TabStop = True
        Me.RadioButtonNoPribadi.Text = "No. Pribadi"
        Me.RadioButtonNoPribadi.UseVisualStyleBackColor = True
        '
        'RadioButtonNoCUG
        '
        Me.RadioButtonNoCUG.AutoSize = True
        Me.RadioButtonNoCUG.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonNoCUG.Location = New System.Drawing.Point(3, 30)
        Me.RadioButtonNoCUG.Name = "RadioButtonNoCUG"
        Me.RadioButtonNoCUG.Size = New System.Drawing.Size(70, 19)
        Me.RadioButtonNoCUG.TabIndex = 246
        Me.RadioButtonNoCUG.TabStop = True
        Me.RadioButtonNoCUG.Text = "No. CUG"
        Me.RadioButtonNoCUG.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(25, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 17)
        Me.Label4.TabIndex = 456
        Me.Label4.Text = "No. WhatsApp"
        '
        'TextBoxNomorWhatsapp
        '
        Me.TextBoxNomorWhatsapp.BackColor = System.Drawing.Color.White
        Me.TextBoxNomorWhatsapp.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxNomorWhatsapp.Location = New System.Drawing.Point(131, 74)
        Me.TextBoxNomorWhatsapp.Name = "TextBoxNomorWhatsapp"
        Me.TextBoxNomorWhatsapp.Size = New System.Drawing.Size(200, 25)
        Me.TextBoxNomorWhatsapp.TabIndex = 455
        '
        'ButtonSave
        '
        Me.ButtonSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(108, Byte), Integer), CType(CType(148, Byte), Integer))
        Me.ButtonSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonSave.FlatAppearance.BorderSize = 0
        Me.ButtonSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.ButtonSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.ButtonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSave.Font = New System.Drawing.Font("Century Gothic", 8.25!, System.Drawing.FontStyle.Bold)
        Me.ButtonSave.ForeColor = System.Drawing.Color.Transparent
        Me.ButtonSave.Location = New System.Drawing.Point(131, 105)
        Me.ButtonSave.Name = "ButtonSave"
        Me.ButtonSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonSave.Size = New System.Drawing.Size(200, 30)
        Me.ButtonSave.TabIndex = 429
        Me.ButtonSave.Text = "Kirim WhatsApp"
        Me.ButtonSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonSave.UseVisualStyleBackColor = False
        '
        'FormKirimLinkWhatsapp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(394, 244)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PanelTop)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormKirimLinkWhatsapp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.PanelTop.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ButtonSave As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNomorWhatsapp As System.Windows.Forms.TextBox
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents RadioButtonNoPribadi As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonNoCUG As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonNoBebas As System.Windows.Forms.RadioButton
End Class
