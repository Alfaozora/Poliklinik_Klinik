<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTrackingPosition
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.SplitContainer4 = New System.Windows.Forms.SplitContainer
        Me.SplitContainer5 = New System.Windows.Forms.SplitContainer
        Me.ButtonCariPasien = New System.Windows.Forms.Button
        Me.TextBoxCariPasien = New System.Windows.Forms.TextBox
        Me.ComboBoxPos = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.LabelNoRm = New System.Windows.Forms.Label
        Me.LabelNoTransaksi = New System.Windows.Forms.Label
        Me.LabelNama = New System.Windows.Forms.Label
        Me.LabelGender = New System.Windows.Forms.Label
        Me.LabelTglLahir = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ButtonLewati = New System.Windows.Forms.Button
        Me.ButtonRefresh = New System.Windows.Forms.Button
        Me.ButtonSelesaiTracking = New System.Windows.Forms.Button
        Me.ButtonMulaiTracking = New System.Windows.Forms.Button
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer
        Me.DgvPasienSelanjutnya = New System.Windows.Forms.DataGridView
        Me.DgvPasienSelesai = New System.Windows.Forms.DataGridView
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer4.Panel1.SuspendLayout()
        Me.SplitContainer4.Panel2.SuspendLayout()
        Me.SplitContainer4.SuspendLayout()
        Me.SplitContainer5.Panel1.SuspendLayout()
        Me.SplitContainer5.Panel2.SuspendLayout()
        Me.SplitContainer5.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.DgvPasienSelanjutnya, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgvPasienSelesai, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer4)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(751, 509)
        Me.SplitContainer1.SplitterDistance = 260
        Me.SplitContainer1.TabIndex = 0
        '
        'SplitContainer4
        '
        Me.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer4.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer4.Name = "SplitContainer4"
        Me.SplitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer4.Panel1
        '
        Me.SplitContainer4.Panel1.Controls.Add(Me.SplitContainer5)
        '
        'SplitContainer4.Panel2
        '
        Me.SplitContainer4.Panel2.Controls.Add(Me.ButtonLewati)
        Me.SplitContainer4.Panel2.Controls.Add(Me.ButtonRefresh)
        Me.SplitContainer4.Panel2.Controls.Add(Me.ButtonSelesaiTracking)
        Me.SplitContainer4.Panel2.Controls.Add(Me.ButtonMulaiTracking)
        Me.SplitContainer4.Size = New System.Drawing.Size(751, 260)
        Me.SplitContainer4.SplitterDistance = 80
        Me.SplitContainer4.TabIndex = 0
        '
        'SplitContainer5
        '
        Me.SplitContainer5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer5.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer5.MaximumSize = New System.Drawing.Size(751, 80)
        Me.SplitContainer5.MinimumSize = New System.Drawing.Size(751, 80)
        Me.SplitContainer5.Name = "SplitContainer5"
        '
        'SplitContainer5.Panel1
        '
        Me.SplitContainer5.Panel1.Controls.Add(Me.ButtonCariPasien)
        Me.SplitContainer5.Panel1.Controls.Add(Me.TextBoxCariPasien)
        Me.SplitContainer5.Panel1.Controls.Add(Me.ComboBoxPos)
        Me.SplitContainer5.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer5.Panel2
        '
        Me.SplitContainer5.Panel2.Controls.Add(Me.LabelNoRm)
        Me.SplitContainer5.Panel2.Controls.Add(Me.LabelNoTransaksi)
        Me.SplitContainer5.Panel2.Controls.Add(Me.LabelNama)
        Me.SplitContainer5.Panel2.Controls.Add(Me.LabelGender)
        Me.SplitContainer5.Panel2.Controls.Add(Me.LabelTglLahir)
        Me.SplitContainer5.Panel2.Controls.Add(Me.Label11)
        Me.SplitContainer5.Panel2.Controls.Add(Me.Label10)
        Me.SplitContainer5.Panel2.Controls.Add(Me.Label9)
        Me.SplitContainer5.Panel2.Controls.Add(Me.Label8)
        Me.SplitContainer5.Panel2.Controls.Add(Me.Label7)
        Me.SplitContainer5.Panel2.Controls.Add(Me.Label6)
        Me.SplitContainer5.Panel2.Controls.Add(Me.Label5)
        Me.SplitContainer5.Panel2.Controls.Add(Me.Label4)
        Me.SplitContainer5.Panel2.Controls.Add(Me.Label3)
        Me.SplitContainer5.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer5.Size = New System.Drawing.Size(751, 80)
        Me.SplitContainer5.SplitterDistance = 371
        Me.SplitContainer5.TabIndex = 0
        '
        'ButtonCariPasien
        '
        Me.ButtonCariPasien.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCariPasien.FlatAppearance.BorderSize = 0
        Me.ButtonCariPasien.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCariPasien.ForeColor = System.Drawing.Color.White
        Me.ButtonCariPasien.Location = New System.Drawing.Point(282, 46)
        Me.ButtonCariPasien.Name = "ButtonCariPasien"
        Me.ButtonCariPasien.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCariPasien.TabIndex = 502
        Me.ButtonCariPasien.Text = "CARI"
        Me.ButtonCariPasien.UseVisualStyleBackColor = False
        '
        'TextBoxCariPasien
        '
        Me.TextBoxCariPasien.Location = New System.Drawing.Point(16, 46)
        Me.TextBoxCariPasien.Name = "TextBoxCariPasien"
        Me.TextBoxCariPasien.Size = New System.Drawing.Size(259, 20)
        Me.TextBoxCariPasien.TabIndex = 501
        '
        'ComboBoxPos
        '
        Me.ComboBoxPos.AutoCompleteCustomSource.AddRange(New String() {"Sebelum Makan", "Sesudah Makan", "Pemakaian Luar", "Jika Diperlukan", "Saat Makan", "OD", "OS", "ODS", "AS", "AD", "ADS", "IV", "IM"})
        Me.ComboBoxPos.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxPos.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.ComboBoxPos.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ComboBoxPos.FormattingEnabled = True
        Me.ComboBoxPos.Location = New System.Drawing.Point(48, 9)
        Me.ComboBoxPos.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxPos.Name = "ComboBoxPos"
        Me.ComboBoxPos.Size = New System.Drawing.Size(227, 23)
        Me.ComboBoxPos.TabIndex = 500
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "POS"
        '
        'LabelNoRm
        '
        Me.LabelNoRm.AutoSize = True
        Me.LabelNoRm.Location = New System.Drawing.Point(278, 34)
        Me.LabelNoRm.Name = "LabelNoRm"
        Me.LabelNoRm.Size = New System.Drawing.Size(10, 13)
        Me.LabelNoRm.TabIndex = 15
        Me.LabelNoRm.Text = "-"
        '
        'LabelNoTransaksi
        '
        Me.LabelNoTransaksi.AutoSize = True
        Me.LabelNoTransaksi.Location = New System.Drawing.Point(278, 10)
        Me.LabelNoTransaksi.Name = "LabelNoTransaksi"
        Me.LabelNoTransaksi.Size = New System.Drawing.Size(10, 13)
        Me.LabelNoTransaksi.TabIndex = 14
        Me.LabelNoTransaksi.Text = "-"
        '
        'LabelNama
        '
        Me.LabelNama.AutoSize = True
        Me.LabelNama.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNama.Location = New System.Drawing.Point(96, 11)
        Me.LabelNama.Name = "LabelNama"
        Me.LabelNama.Size = New System.Drawing.Size(10, 13)
        Me.LabelNama.TabIndex = 13
        Me.LabelNama.Text = "-"
        '
        'LabelGender
        '
        Me.LabelGender.AutoSize = True
        Me.LabelGender.Location = New System.Drawing.Point(96, 57)
        Me.LabelGender.Name = "LabelGender"
        Me.LabelGender.Size = New System.Drawing.Size(10, 13)
        Me.LabelGender.TabIndex = 12
        Me.LabelGender.Text = "-"
        '
        'LabelTglLahir
        '
        Me.LabelTglLahir.AutoSize = True
        Me.LabelTglLahir.Location = New System.Drawing.Point(96, 33)
        Me.LabelTglLahir.Name = "LabelTglLahir"
        Me.LabelTglLahir.Size = New System.Drawing.Size(10, 13)
        Me.LabelTglLahir.TabIndex = 11
        Me.LabelTglLahir.Text = "-"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(271, 34)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(10, 13)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = ":"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(271, 9)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(10, 13)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = ":"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(202, 34)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "No RM"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(202, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "No Transaksi"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(88, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(10, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = ":"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(11, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Jenis Kelamin"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(88, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(10, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = ":"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Tgl Lahir"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(88, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(10, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = ":"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nama Pasien"
        '
        'ButtonLewati
        '
        Me.ButtonLewati.BackColor = System.Drawing.Color.OrangeRed
        Me.ButtonLewati.Enabled = False
        Me.ButtonLewati.FlatAppearance.BorderSize = 0
        Me.ButtonLewati.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonLewati.ForeColor = System.Drawing.Color.White
        Me.ButtonLewati.Location = New System.Drawing.Point(479, 37)
        Me.ButtonLewati.Name = "ButtonLewati"
        Me.ButtonLewati.Size = New System.Drawing.Size(198, 78)
        Me.ButtonLewati.TabIndex = 504
        Me.ButtonLewati.Text = "LEWATI PEMERIKSAAN"
        Me.ButtonLewati.UseVisualStyleBackColor = False
        '
        'ButtonRefresh
        '
        Me.ButtonRefresh.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonRefresh.FlatAppearance.BorderSize = 0
        Me.ButtonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonRefresh.ForeColor = System.Drawing.Color.White
        Me.ButtonRefresh.Location = New System.Drawing.Point(12, 144)
        Me.ButtonRefresh.Name = "ButtonRefresh"
        Me.ButtonRefresh.Size = New System.Drawing.Size(66, 20)
        Me.ButtonRefresh.TabIndex = 503
        Me.ButtonRefresh.Text = "Refresh"
        Me.ButtonRefresh.UseVisualStyleBackColor = False
        '
        'ButtonSelesaiTracking
        '
        Me.ButtonSelesaiTracking.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSelesaiTracking.Enabled = False
        Me.ButtonSelesaiTracking.FlatAppearance.BorderSize = 0
        Me.ButtonSelesaiTracking.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSelesaiTracking.ForeColor = System.Drawing.Color.White
        Me.ButtonSelesaiTracking.Location = New System.Drawing.Point(275, 37)
        Me.ButtonSelesaiTracking.Name = "ButtonSelesaiTracking"
        Me.ButtonSelesaiTracking.Size = New System.Drawing.Size(198, 78)
        Me.ButtonSelesaiTracking.TabIndex = 1
        Me.ButtonSelesaiTracking.Text = "SELESAI PEMERIKSAAN"
        Me.ButtonSelesaiTracking.UseVisualStyleBackColor = False
        '
        'ButtonMulaiTracking
        '
        Me.ButtonMulaiTracking.BackColor = System.Drawing.Color.Green
        Me.ButtonMulaiTracking.Enabled = False
        Me.ButtonMulaiTracking.FlatAppearance.BorderSize = 0
        Me.ButtonMulaiTracking.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonMulaiTracking.ForeColor = System.Drawing.Color.White
        Me.ButtonMulaiTracking.Location = New System.Drawing.Point(71, 37)
        Me.ButtonMulaiTracking.Name = "ButtonMulaiTracking"
        Me.ButtonMulaiTracking.Size = New System.Drawing.Size(198, 78)
        Me.ButtonMulaiTracking.TabIndex = 0
        Me.ButtonMulaiTracking.Text = "MULAI PEMERIKSAAN"
        Me.ButtonMulaiTracking.UseVisualStyleBackColor = False
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label13)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label12)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer2.Size = New System.Drawing.Size(751, 245)
        Me.SplitContainer2.SplitterDistance = 25
        Me.SplitContainer2.TabIndex = 0
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(466, 6)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(190, 13)
        Me.Label13.TabIndex = 1
        Me.Label13.Text = "List Pasien Selesai Pemeriksaan"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(121, 6)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(139, 13)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "List Pasien Selanjutnya"
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.MaximumSize = New System.Drawing.Size(751, 216)
        Me.SplitContainer3.MinimumSize = New System.Drawing.Size(751, 216)
        Me.SplitContainer3.Name = "SplitContainer3"
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.DgvPasienSelanjutnya)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.DgvPasienSelesai)
        Me.SplitContainer3.Size = New System.Drawing.Size(751, 216)
        Me.SplitContainer3.SplitterDistance = 370
        Me.SplitContainer3.TabIndex = 0
        '
        'DgvPasienSelanjutnya
        '
        Me.DgvPasienSelanjutnya.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DgvPasienSelanjutnya.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvPasienSelanjutnya.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvPasienSelanjutnya.Location = New System.Drawing.Point(0, 0)
        Me.DgvPasienSelanjutnya.Name = "DgvPasienSelanjutnya"
        Me.DgvPasienSelanjutnya.Size = New System.Drawing.Size(370, 216)
        Me.DgvPasienSelanjutnya.TabIndex = 0
        '
        'DgvPasienSelesai
        '
        Me.DgvPasienSelesai.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.DgvPasienSelesai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DgvPasienSelesai.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DgvPasienSelesai.Location = New System.Drawing.Point(0, 0)
        Me.DgvPasienSelesai.Name = "DgvPasienSelesai"
        Me.DgvPasienSelesai.Size = New System.Drawing.Size(377, 216)
        Me.DgvPasienSelesai.TabIndex = 0
        '
        'FormTrackingPosition
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(751, 509)
        Me.Controls.Add(Me.SplitContainer1)
        Me.MaximumSize = New System.Drawing.Size(767, 548)
        Me.MinimumSize = New System.Drawing.Size(767, 548)
        Me.Name = "FormTrackingPosition"
        Me.Text = "FormTrackingPosition"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer4.Panel1.ResumeLayout(False)
        Me.SplitContainer4.Panel2.ResumeLayout(False)
        Me.SplitContainer4.ResumeLayout(False)
        Me.SplitContainer5.Panel1.ResumeLayout(False)
        Me.SplitContainer5.Panel1.PerformLayout()
        Me.SplitContainer5.Panel2.ResumeLayout(False)
        Me.SplitContainer5.Panel2.PerformLayout()
        Me.SplitContainer5.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.ResumeLayout(False)
        CType(Me.DgvPasienSelanjutnya, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgvPasienSelesai, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer4 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer5 As System.Windows.Forms.SplitContainer
    Friend WithEvents ButtonSelesaiTracking As System.Windows.Forms.Button
    Friend WithEvents ButtonMulaiTracking As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonCariPasien As System.Windows.Forms.Button
    Friend WithEvents TextBoxCariPasien As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxPos As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LabelTglLahir As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LabelNoRm As System.Windows.Forms.Label
    Friend WithEvents LabelNoTransaksi As System.Windows.Forms.Label
    Friend WithEvents LabelNama As System.Windows.Forms.Label
    Friend WithEvents LabelGender As System.Windows.Forms.Label
    Friend WithEvents ButtonRefresh As System.Windows.Forms.Button
    Friend WithEvents DgvPasienSelanjutnya As System.Windows.Forms.DataGridView
    Friend WithEvents DgvPasienSelesai As System.Windows.Forms.DataGridView
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ButtonLewati As System.Windows.Forms.Button
End Class
