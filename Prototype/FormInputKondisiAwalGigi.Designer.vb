<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInputKondisiAwalGigi
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormInputKondisiAwalGigi))
        Me.PanelTop = New System.Windows.Forms.Panel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TextBoxKondisi = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.TextBoxKeterangan = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TextBoxNamaGigi = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TextBoxNomorGigi = New System.Windows.Forms.TextBox
        Me.ButtonSimpanData = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.ComboBoxStatus = New System.Windows.Forms.ComboBox
        Me.PanelTop.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.PanelTop.Controls.Add(Me.btnClose)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(498, 35)
        Me.PanelTop.TabIndex = 5
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.ComboBoxStatus)
        Me.Panel1.Controls.Add(Me.TextBoxKondisi)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.TextBoxKeterangan)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.TextBoxNamaGigi)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.TextBoxNomorGigi)
        Me.Panel1.Controls.Add(Me.ButtonSimpanData)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 35)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(498, 263)
        Me.Panel1.TabIndex = 6
        '
        'TextBoxKondisi
        '
        Me.TextBoxKondisi.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TextBoxKondisi.Location = New System.Drawing.Point(195, 130)
        Me.TextBoxKondisi.Name = "TextBoxKondisi"
        Me.TextBoxKondisi.Size = New System.Drawing.Size(250, 25)
        Me.TextBoxKondisi.TabIndex = 450
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(40, 164)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 17)
        Me.Label7.TabIndex = 451
        Me.Label7.Text = "Status"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(40, 102)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(78, 17)
        Me.Label5.TabIndex = 449
        Me.Label5.Text = "Keterangan"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(40, 133)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 17)
        Me.Label6.TabIndex = 448
        Me.Label6.Text = "Kondisi"
        '
        'TextBoxKeterangan
        '
        Me.TextBoxKeterangan.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.TextBoxKeterangan.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TextBoxKeterangan.Location = New System.Drawing.Point(195, 99)
        Me.TextBoxKeterangan.Name = "TextBoxKeterangan"
        Me.TextBoxKeterangan.ReadOnly = True
        Me.TextBoxKeterangan.Size = New System.Drawing.Size(250, 25)
        Me.TextBoxKeterangan.TabIndex = 446
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(40, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 17)
        Me.Label3.TabIndex = 445
        Me.Label3.Text = "Nomor Gigi"
        '
        'TextBoxNamaGigi
        '
        Me.TextBoxNamaGigi.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.TextBoxNamaGigi.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TextBoxNamaGigi.Location = New System.Drawing.Point(195, 68)
        Me.TextBoxNamaGigi.Name = "TextBoxNamaGigi"
        Me.TextBoxNamaGigi.ReadOnly = True
        Me.TextBoxNamaGigi.Size = New System.Drawing.Size(250, 25)
        Me.TextBoxNamaGigi.TabIndex = 443
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(40, 71)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 17)
        Me.Label4.TabIndex = 444
        Me.Label4.Text = "Nama Gigi"
        '
        'TextBoxNomorGigi
        '
        Me.TextBoxNomorGigi.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.TextBoxNomorGigi.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TextBoxNomorGigi.Location = New System.Drawing.Point(195, 37)
        Me.TextBoxNomorGigi.Name = "TextBoxNomorGigi"
        Me.TextBoxNomorGigi.ReadOnly = True
        Me.TextBoxNomorGigi.Size = New System.Drawing.Size(50, 25)
        Me.TextBoxNomorGigi.TabIndex = 442
        '
        'ButtonSimpanData
        '
        Me.ButtonSimpanData.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSimpanData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonSimpanData.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonSimpanData.FlatAppearance.BorderSize = 0
        Me.ButtonSimpanData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSimpanData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonSimpanData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSimpanData.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonSimpanData.ForeColor = System.Drawing.Color.White
        Me.ButtonSimpanData.Location = New System.Drawing.Point(195, 192)
        Me.ButtonSimpanData.Name = "ButtonSimpanData"
        Me.ButtonSimpanData.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonSimpanData.Size = New System.Drawing.Size(250, 30)
        Me.ButtonSimpanData.TabIndex = 429
        Me.ButtonSimpanData.Text = "Simpan Data"
        Me.ButtonSimpanData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonSimpanData.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(458, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(40, 35)
        Me.btnClose.TabIndex = 281
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'ComboBoxStatus
        '
        Me.ComboBoxStatus.AutoCompleteCustomSource.AddRange(New String() {"Abrafaksi", "Abrasi", "Atrisi", "Belum Erupsi", "Caries", "Erupsi Partial", "Goyang", "Impaksi", "Malposisi", "Missing", "Persistensi", "Sisa Akar", "Tambalan Logam", "Tambalan Non logam", "Lain-lain"})
        Me.ComboBoxStatus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxStatus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.ComboBoxStatus.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBoxStatus.FormattingEnabled = True
        Me.ComboBoxStatus.Items.AddRange(New Object() {"Abrafaksi", "Abrasi", "Atrisi", "Belum Erupsi", "Caries", "Erupsi Partial", "Goyang", "Impaksi", "Malposisi", "Missing", "Persistensi", "Sisa Akar", "Tambalan Logam", "Tambalan Non logam", "Lain-lain"})
        Me.ComboBoxStatus.Location = New System.Drawing.Point(195, 161)
        Me.ComboBoxStatus.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxStatus.Name = "ComboBoxStatus"
        Me.ComboBoxStatus.Size = New System.Drawing.Size(250, 25)
        Me.ComboBoxStatus.TabIndex = 499
        '
        'FormInputKondisiAwalGigi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(498, 298)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PanelTop)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormInputKondisiAwalGigi"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.PanelTop.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ButtonSimpanData As System.Windows.Forms.Button
    Friend WithEvents TextBoxKondisi As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBoxKeterangan As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNamaGigi As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNomorGigi As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxStatus As System.Windows.Forms.ComboBox
End Class
