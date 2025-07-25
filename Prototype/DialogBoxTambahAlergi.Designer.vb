<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogBoxTambahAlergi
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DialogBoxTambahAlergi))
        Me.PanelTop = New System.Windows.Forms.Panel
        Me.btnClose = New System.Windows.Forms.Button
        Me.PanelHeader = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.ButtonSimpanDataAlergi = New System.Windows.Forms.Button
        Me.TextBoxKeteranganAlergi = New System.Windows.Forms.TextBox
        Me.ComboBoxNamaAlergi = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ComboBoxJenisAlergi = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.PanelTop.SuspendLayout()
        Me.PanelHeader.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.PanelTop.Controls.Add(Me.btnClose)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(494, 35)
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
        Me.btnClose.Location = New System.Drawing.Point(454, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(40, 35)
        Me.btnClose.TabIndex = 281
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'PanelHeader
        '
        Me.PanelHeader.BackColor = System.Drawing.Color.Transparent
        Me.PanelHeader.Controls.Add(Me.Label3)
        Me.PanelHeader.Controls.Add(Me.ButtonSimpanDataAlergi)
        Me.PanelHeader.Controls.Add(Me.TextBoxKeteranganAlergi)
        Me.PanelHeader.Controls.Add(Me.ComboBoxNamaAlergi)
        Me.PanelHeader.Controls.Add(Me.Label1)
        Me.PanelHeader.Controls.Add(Me.ComboBoxJenisAlergi)
        Me.PanelHeader.Controls.Add(Me.Label2)
        Me.PanelHeader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelHeader.Location = New System.Drawing.Point(0, 35)
        Me.PanelHeader.Name = "PanelHeader"
        Me.PanelHeader.Size = New System.Drawing.Size(494, 259)
        Me.PanelHeader.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(45, 121)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 17)
        Me.Label3.TabIndex = 525
        Me.Label3.Text = "Keterangan"
        '
        'ButtonSimpanDataAlergi
        '
        Me.ButtonSimpanDataAlergi.BackColor = System.Drawing.Color.White
        Me.ButtonSimpanDataAlergi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonSimpanDataAlergi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonSimpanDataAlergi.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSimpanDataAlergi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonSimpanDataAlergi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSimpanDataAlergi.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonSimpanDataAlergi.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSimpanDataAlergi.Location = New System.Drawing.Point(185, 164)
        Me.ButtonSimpanDataAlergi.Name = "ButtonSimpanDataAlergi"
        Me.ButtonSimpanDataAlergi.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonSimpanDataAlergi.Size = New System.Drawing.Size(250, 25)
        Me.ButtonSimpanDataAlergi.TabIndex = 524
        Me.ButtonSimpanDataAlergi.Text = "Simpan Alergi"
        Me.ButtonSimpanDataAlergi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonSimpanDataAlergi.UseVisualStyleBackColor = False
        '
        'TextBoxKeteranganAlergi
        '
        Me.TextBoxKeteranganAlergi.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBoxKeteranganAlergi.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxKeteranganAlergi.Location = New System.Drawing.Point(185, 118)
        Me.TextBoxKeteranganAlergi.Multiline = True
        Me.TextBoxKeteranganAlergi.Name = "TextBoxKeteranganAlergi"
        Me.TextBoxKeteranganAlergi.Size = New System.Drawing.Size(250, 40)
        Me.TextBoxKeteranganAlergi.TabIndex = 514
        '
        'ComboBoxNamaAlergi
        '
        Me.ComboBoxNamaAlergi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.ComboBoxNamaAlergi.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBoxNamaAlergi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxNamaAlergi.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBoxNamaAlergi.FormattingEnabled = True
        Me.ComboBoxNamaAlergi.Location = New System.Drawing.Point(185, 86)
        Me.ComboBoxNamaAlergi.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxNamaAlergi.Name = "ComboBoxNamaAlergi"
        Me.ComboBoxNamaAlergi.Size = New System.Drawing.Size(250, 25)
        Me.ComboBoxNamaAlergi.TabIndex = 513
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(45, 89)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 17)
        Me.Label1.TabIndex = 512
        Me.Label1.Text = "Nama Alergi"
        '
        'ComboBoxJenisAlergi
        '
        Me.ComboBoxJenisAlergi.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.ComboBoxJenisAlergi.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBoxJenisAlergi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxJenisAlergi.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBoxJenisAlergi.FormattingEnabled = True
        Me.ComboBoxJenisAlergi.Location = New System.Drawing.Point(185, 53)
        Me.ComboBoxJenisAlergi.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxJenisAlergi.Name = "ComboBoxJenisAlergi"
        Me.ComboBoxJenisAlergi.Size = New System.Drawing.Size(125, 25)
        Me.ComboBoxJenisAlergi.TabIndex = 511
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(45, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 17)
        Me.Label2.TabIndex = 510
        Me.Label2.Text = "Jenis Alergi"
        '
        'DialogBoxTambahAlergi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(494, 294)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelHeader)
        Me.Controls.Add(Me.PanelTop)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DialogBoxTambahAlergi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.PanelTop.ResumeLayout(False)
        Me.PanelHeader.ResumeLayout(False)
        Me.PanelHeader.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents PanelHeader As System.Windows.Forms.Panel
    Friend WithEvents ComboBoxNamaAlergi As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxJenisAlergi As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBoxKeteranganAlergi As System.Windows.Forms.TextBox
    Friend WithEvents ButtonSimpanDataAlergi As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
