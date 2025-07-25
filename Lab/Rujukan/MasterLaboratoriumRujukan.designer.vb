<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class masterlaboratoriumrujukan
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
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txcompanycode = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtcompanystart = New System.Windows.Forms.DateTimePicker
        Me.dtcompanyend = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.buttransdisplay = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.butfindcomp = New System.Windows.Forms.Button
        Me.txcompid = New System.Windows.Forms.TextBox
        Me.txcompnol = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txuplab = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txalamat = New System.Windows.Forms.TextBox
        Me.CheckBoxUpload = New System.Windows.Forms.CheckBox
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.SaveToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.CloseToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(379, 24)
        Me.MenuStrip1.TabIndex = 87
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Enabled = False
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(7, 117)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 15)
        Me.Label6.TabIndex = 108
        Me.Label6.Text = "Tanggal Mulai"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(45, 65)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 15)
        Me.Label4.TabIndex = 106
        Me.Label4.Text = "Alamat"
        '
        'txcompanycode
        '
        Me.txcompanycode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txcompanycode.Location = New System.Drawing.Point(96, 35)
        Me.txcompanycode.Name = "txcompanycode"
        Me.txcompanycode.Size = New System.Drawing.Size(186, 21)
        Me.txcompanycode.TabIndex = 103
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(25, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 15)
        Me.Label2.TabIndex = 104
        Me.Label2.Text = "Nama Lab"
        '
        'dtcompanystart
        '
        Me.dtcompanystart.CustomFormat = "dd-MMM-yyyy"
        Me.dtcompanystart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtcompanystart.Location = New System.Drawing.Point(96, 115)
        Me.dtcompanystart.Name = "dtcompanystart"
        Me.dtcompanystart.Size = New System.Drawing.Size(107, 20)
        Me.dtcompanystart.TabIndex = 106
        '
        'dtcompanyend
        '
        Me.dtcompanyend.CustomFormat = "dd-MMM-yyyy"
        Me.dtcompanyend.Enabled = False
        Me.dtcompanyend.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtcompanyend.Location = New System.Drawing.Point(239, 115)
        Me.dtcompanyend.Name = "dtcompanyend"
        Me.dtcompanyend.Size = New System.Drawing.Size(107, 20)
        Me.dtcompanyend.TabIndex = 111
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(210, 118)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 13)
        Me.Label1.TabIndex = 110
        Me.Label1.Text = "s/d"
        '
        'buttransdisplay
        '
        Me.buttransdisplay.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.buttransdisplay.Cursor = System.Windows.Forms.Cursors.Hand
        Me.buttransdisplay.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.buttransdisplay.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buttransdisplay.Location = New System.Drawing.Point(96, 173)
        Me.buttransdisplay.Name = "buttransdisplay"
        Me.buttransdisplay.Size = New System.Drawing.Size(75, 23)
        Me.buttransdisplay.TabIndex = 112
        Me.buttransdisplay.Text = "New"
        Me.buttransdisplay.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(177, 173)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 113
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'butfindcomp
        '
        Me.butfindcomp.Location = New System.Drawing.Point(330, 33)
        Me.butfindcomp.Name = "butfindcomp"
        Me.butfindcomp.Size = New System.Drawing.Size(31, 23)
        Me.butfindcomp.TabIndex = 179
        Me.butfindcomp.Text = "..."
        Me.butfindcomp.UseVisualStyleBackColor = True
        '
        'txcompid
        '
        Me.txcompid.Enabled = False
        Me.txcompid.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txcompid.Location = New System.Drawing.Point(288, 35)
        Me.txcompid.Name = "txcompid"
        Me.txcompid.Size = New System.Drawing.Size(36, 21)
        Me.txcompid.TabIndex = 180
        '
        'txcompnol
        '
        Me.txcompnol.Enabled = False
        Me.txcompnol.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txcompnol.Location = New System.Drawing.Point(96, 141)
        Me.txcompnol.Name = "txcompnol"
        Me.txcompnol.Size = New System.Drawing.Size(107, 26)
        Me.txcompnol.TabIndex = 181
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(47, 147)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 15)
        Me.Label3.TabIndex = 182
        Me.Label3.Text = "ID Lab"
        '
        'txuplab
        '
        Me.txuplab.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txuplab.Location = New System.Drawing.Point(96, 88)
        Me.txuplab.Name = "txuplab"
        Me.txuplab.Size = New System.Drawing.Size(268, 21)
        Me.txuplab.TabIndex = 105
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(38, 91)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 15)
        Me.Label5.TabIndex = 184
        Me.Label5.Text = "U.P. Lab"
        '
        'txalamat
        '
        Me.txalamat.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txalamat.Location = New System.Drawing.Point(96, 62)
        Me.txalamat.Name = "txalamat"
        Me.txalamat.Size = New System.Drawing.Size(268, 21)
        Me.txalamat.TabIndex = 104
        '
        'CheckBoxUpload
        '
        Me.CheckBoxUpload.AutoSize = True
        Me.CheckBoxUpload.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxUpload.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxUpload.Location = New System.Drawing.Point(211, 145)
        Me.CheckBoxUpload.Name = "CheckBoxUpload"
        Me.CheckBoxUpload.Size = New System.Drawing.Size(108, 20)
        Me.CheckBoxUpload.TabIndex = 268
        Me.CheckBoxUpload.Text = "Upload Online"
        Me.CheckBoxUpload.UseVisualStyleBackColor = False
        '
        'masterlaboratoriumrujukan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(379, 211)
        Me.Controls.Add(Me.CheckBoxUpload)
        Me.Controls.Add(Me.txalamat)
        Me.Controls.Add(Me.txuplab)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txcompnol)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txcompid)
        Me.Controls.Add(Me.butfindcomp)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.buttransdisplay)
        Me.Controls.Add(Me.dtcompanyend)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtcompanystart)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txcompanycode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(395, 250)
        Me.MinimumSize = New System.Drawing.Size(395, 250)
        Me.Name = "masterlaboratoriumrujukan"
        Me.Text = "Laboratorium Rujukan"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txcompanycode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtcompanystart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtcompanyend As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents buttransdisplay As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents butfindcomp As System.Windows.Forms.Button
    Friend WithEvents txcompid As System.Windows.Forms.TextBox
    Friend WithEvents txcompnol As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txuplab As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txalamat As System.Windows.Forms.TextBox
    Friend WithEvents CheckBoxUpload As System.Windows.Forms.CheckBox
End Class
