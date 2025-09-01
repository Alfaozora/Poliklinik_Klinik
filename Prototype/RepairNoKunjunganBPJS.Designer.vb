<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RepairNoKunjunganBPJS
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
        Me.CLearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBoxNoUrut = New System.Windows.Forms.TextBox
        Me.TextBoxNoKunjunganBPJS = New System.Windows.Forms.TextBox
        Me.ButtonCekKIS = New System.Windows.Forms.Button
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'CLearToolStripMenuItem
        '
        Me.CLearToolStripMenuItem.Name = "CLearToolStripMenuItem"
        Me.CLearToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.CLearToolStripMenuItem.Text = "Clear"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CLearToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(549, 24)
        Me.MenuStrip1.TabIndex = 424
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(37, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 16)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "No Transaksi"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(37, 142)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "No Kunjungan BPJS"
        '
        'TextBoxNoUrut
        '
        Me.TextBoxNoUrut.Location = New System.Drawing.Point(191, 74)
        Me.TextBoxNoUrut.Multiline = True
        Me.TextBoxNoUrut.Name = "TextBoxNoUrut"
        Me.TextBoxNoUrut.Size = New System.Drawing.Size(164, 26)
        Me.TextBoxNoUrut.TabIndex = 4
        '
        'TextBoxNoKunjunganBPJS
        '
        Me.TextBoxNoKunjunganBPJS.Location = New System.Drawing.Point(191, 132)
        Me.TextBoxNoKunjunganBPJS.Multiline = True
        Me.TextBoxNoKunjunganBPJS.Name = "TextBoxNoKunjunganBPJS"
        Me.TextBoxNoKunjunganBPJS.Size = New System.Drawing.Size(164, 26)
        Me.TextBoxNoKunjunganBPJS.TabIndex = 5
        '
        'ButtonCekKIS
        '
        Me.ButtonCekKIS.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCekKIS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonCekKIS.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonCekKIS.FlatAppearance.BorderSize = 0
        Me.ButtonCekKIS.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCekKIS.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonCekKIS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCekKIS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonCekKIS.ForeColor = System.Drawing.Color.White
        Me.ButtonCekKIS.Location = New System.Drawing.Point(361, 75)
        Me.ButtonCekKIS.Name = "ButtonCekKIS"
        Me.ButtonCekKIS.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonCekKIS.Size = New System.Drawing.Size(150, 26)
        Me.ButtonCekKIS.TabIndex = 423
        Me.ButtonCekKIS.Text = "Cek BPJS - No. Kartu"
        Me.ButtonCekKIS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonCekKIS.UseVisualStyleBackColor = False
        '
        'RepairNoKunjunganBPJS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.PoliKlinik_Net2.My.Resources.Resources.wallpaperdialog
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(549, 301)
        Me.Controls.Add(Me.ButtonCekKIS)
        Me.Controls.Add(Me.TextBoxNoKunjunganBPJS)
        Me.Controls.Add(Me.TextBoxNoUrut)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "RepairNoKunjunganBPJS"
        Me.Text = "Repair No Kunjungan BPJS"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CLearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNoUrut As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxNoKunjunganBPJS As System.Windows.Forms.TextBox
    Friend WithEvents ButtonCekKIS As System.Windows.Forms.Button
End Class
