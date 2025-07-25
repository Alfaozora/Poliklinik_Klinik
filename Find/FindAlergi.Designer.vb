<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FindAlergi
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FindAlergi))
        Me.Label1 = New System.Windows.Forms.Label
        Me.PanelTop = New System.Windows.Forms.Panel
        Me.btnClose = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.TextBoxKeterangan = New System.Windows.Forms.TextBox
        Me.ComboBoxJenisAlergi = New System.Windows.Forms.ComboBox
        Me.ButtonSave = New System.Windows.Forms.Button
        Me.PanelTop.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(43, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 17)
        Me.Label1.TabIndex = 193
        Me.Label1.Text = "Jenis Alergi"
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.PanelTop.Controls.Add(Me.btnClose)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(394, 35)
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
        Me.btnClose.Size = New System.Drawing.Size(40, 35)
        Me.btnClose.TabIndex = 281
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.TextBoxKeterangan)
        Me.Panel1.Controls.Add(Me.ComboBoxJenisAlergi)
        Me.Panel1.Controls.Add(Me.ButtonSave)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 35)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(394, 209)
        Me.Panel1.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(41, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 17)
        Me.Label3.TabIndex = 442
        Me.Label3.Text = "Keterangan"
        '
        'TextBoxKeterangan
        '
        Me.TextBoxKeterangan.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBoxKeterangan.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxKeterangan.Location = New System.Drawing.Point(137, 53)
        Me.TextBoxKeterangan.Multiline = True
        Me.TextBoxKeterangan.Name = "TextBoxKeterangan"
        Me.TextBoxKeterangan.Size = New System.Drawing.Size(200, 99)
        Me.TextBoxKeterangan.TabIndex = 441
        '
        'ComboBoxJenisAlergi
        '
        Me.ComboBoxJenisAlergi.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.ComboBoxJenisAlergi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxJenisAlergi.Cursor = System.Windows.Forms.Cursors.Default
        Me.ComboBoxJenisAlergi.DropDownHeight = 100
        Me.ComboBoxJenisAlergi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxJenisAlergi.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxJenisAlergi.FormattingEnabled = True
        Me.ComboBoxJenisAlergi.IntegralHeight = False
        Me.ComboBoxJenisAlergi.ItemHeight = 17
        Me.ComboBoxJenisAlergi.Items.AddRange(New Object() {"OBAT", "MAKANAN", "LAINNYA"})
        Me.ComboBoxJenisAlergi.Location = New System.Drawing.Point(137, 22)
        Me.ComboBoxJenisAlergi.Name = "ComboBoxJenisAlergi"
        Me.ComboBoxJenisAlergi.Size = New System.Drawing.Size(200, 25)
        Me.ComboBoxJenisAlergi.TabIndex = 430
        '
        'ButtonSave
        '
        Me.ButtonSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonSave.FlatAppearance.BorderSize = 0
        Me.ButtonSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.ButtonSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(167, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.ButtonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSave.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonSave.ForeColor = System.Drawing.Color.Transparent
        Me.ButtonSave.Location = New System.Drawing.Point(137, 158)
        Me.ButtonSave.Name = "ButtonSave"
        Me.ButtonSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonSave.Size = New System.Drawing.Size(200, 30)
        Me.ButtonSave.TabIndex = 429
        Me.ButtonSave.Text = "Simpan Data"
        Me.ButtonSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonSave.UseVisualStyleBackColor = False
        '
        'FindAlergi
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
        Me.Name = "FindAlergi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.PanelTop.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ButtonSave As System.Windows.Forms.Button
    Friend WithEvents ComboBoxJenisAlergi As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBoxKeterangan As System.Windows.Forms.TextBox
End Class
