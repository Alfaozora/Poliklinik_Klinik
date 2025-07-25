<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SendUlangToMesin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SendUlangToMesin))
        Me.dtproses = New System.Windows.Forms.DateTimePicker
        Me.butproses = New System.Windows.Forms.Button
        Me.cmbjenis = New System.Windows.Forms.ComboBox
        Me.rdtanggal = New System.Windows.Forms.RadioButton
        Me.rdnotrans = New System.Windows.Forms.RadioButton
        Me.txnotrans = New System.Windows.Forms.TextBox
        Me.btntrans = New System.Windows.Forms.Button
        Me.lblSend = New System.Windows.Forms.Label
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.lblload = New System.Windows.Forms.Label
        Me.Panelload = New System.Windows.Forms.Panel
        Me.txtip = New System.Windows.Forms.TextBox
        Me.lblip = New System.Windows.Forms.Label
        Me.butcompany = New System.Windows.Forms.Button
        Me.TextBoxKeteranganLokasi = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBoxKodeLokasi = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.buttindakan = New System.Windows.Forms.Button
        Me.txtindakanket = New System.Windows.Forms.TextBox
        Me.txtindakanid = New System.Windows.Forms.TextBox
        Me.Panelload.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtproses
        '
        Me.dtproses.CustomFormat = "dd-MMM-yyyy"
        Me.dtproses.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtproses.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtproses.Location = New System.Drawing.Point(172, 96)
        Me.dtproses.Name = "dtproses"
        Me.dtproses.Size = New System.Drawing.Size(200, 22)
        Me.dtproses.TabIndex = 63
        '
        'butproses
        '
        Me.butproses.Cursor = System.Windows.Forms.Cursors.Hand
        Me.butproses.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butproses.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_unggah
        Me.butproses.Location = New System.Drawing.Point(151, 195)
        Me.butproses.Name = "butproses"
        Me.butproses.Size = New System.Drawing.Size(100, 36)
        Me.butproses.TabIndex = 136
        Me.butproses.UseVisualStyleBackColor = True
        '
        'cmbjenis
        '
        Me.cmbjenis.BackColor = System.Drawing.SystemColors.MenuBar
        Me.cmbjenis.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbjenis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbjenis.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbjenis.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbjenis.FormattingEnabled = True
        Me.cmbjenis.Items.AddRange(New Object() {"Mesin DL 5-Diff", "Mesin DL 3-Diff", "Mesin Urine", "Mesin CL900", "Mesin (Online) 5-Diff/CL900/C0BAS6600", "Mesin (Online) 3-Diff/Urine", "Mesin C0BAS6600"})
        Me.cmbjenis.Location = New System.Drawing.Point(46, 27)
        Me.cmbjenis.Name = "cmbjenis"
        Me.cmbjenis.Size = New System.Drawing.Size(326, 28)
        Me.cmbjenis.TabIndex = 137
        '
        'rdtanggal
        '
        Me.rdtanggal.AutoSize = True
        Me.rdtanggal.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.rdtanggal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rdtanggal.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdtanggal.Location = New System.Drawing.Point(46, 96)
        Me.rdtanggal.Name = "rdtanggal"
        Me.rdtanggal.Size = New System.Drawing.Size(90, 20)
        Me.rdtanggal.TabIndex = 138
        Me.rdtanggal.TabStop = True
        Me.rdtanggal.Text = "By Tanggal"
        Me.rdtanggal.UseVisualStyleBackColor = False
        '
        'rdnotrans
        '
        Me.rdnotrans.AutoSize = True
        Me.rdnotrans.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.rdnotrans.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rdnotrans.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdnotrans.Location = New System.Drawing.Point(46, 126)
        Me.rdnotrans.Name = "rdnotrans"
        Me.rdnotrans.Size = New System.Drawing.Size(126, 20)
        Me.rdnotrans.TabIndex = 139
        Me.rdnotrans.TabStop = True
        Me.rdnotrans.Text = "By No. Transaksi"
        Me.rdnotrans.UseVisualStyleBackColor = False
        '
        'txnotrans
        '
        Me.txnotrans.Enabled = False
        Me.txnotrans.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txnotrans.Location = New System.Drawing.Point(172, 128)
        Me.txnotrans.Name = "txnotrans"
        Me.txnotrans.Size = New System.Drawing.Size(159, 22)
        Me.txnotrans.TabIndex = 140
        '
        'btntrans
        '
        Me.btntrans.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btntrans.Location = New System.Drawing.Point(337, 127)
        Me.btntrans.Name = "btntrans"
        Me.btntrans.Size = New System.Drawing.Size(35, 27)
        Me.btntrans.TabIndex = 141
        Me.btntrans.Text = "..."
        Me.btntrans.UseVisualStyleBackColor = True
        '
        'lblSend
        '
        Me.lblSend.AutoSize = True
        Me.lblSend.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblSend.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSend.ForeColor = System.Drawing.Color.Firebrick
        Me.lblSend.Location = New System.Drawing.Point(43, 6)
        Me.lblSend.Name = "lblSend"
        Me.lblSend.Size = New System.Drawing.Size(334, 15)
        Me.lblSend.TabIndex = 142
        Me.lblSend.Text = "Note : Semakin banyak data, maka proses semakin lama!!"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.BackColor = System.Drawing.Color.Lime
        Me.ProgressBar1.Location = New System.Drawing.Point(67, 8)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(249, 17)
        Me.ProgressBar1.TabIndex = 143
        '
        'lblload
        '
        Me.lblload.AutoSize = True
        Me.lblload.BackColor = System.Drawing.Color.PowderBlue
        Me.lblload.Location = New System.Drawing.Point(7, 8)
        Me.lblload.Name = "lblload"
        Me.lblload.Size = New System.Drawing.Size(54, 13)
        Me.lblload.TabIndex = 144
        Me.lblload.Text = "Loading..."
        '
        'Panelload
        '
        Me.Panelload.BackColor = System.Drawing.Color.PowderBlue
        Me.Panelload.Controls.Add(Me.lblload)
        Me.Panelload.Controls.Add(Me.ProgressBar1)
        Me.Panelload.Location = New System.Drawing.Point(46, 237)
        Me.Panelload.Name = "Panelload"
        Me.Panelload.Size = New System.Drawing.Size(326, 32)
        Me.Panelload.TabIndex = 145
        '
        'txtip
        '
        Me.txtip.Location = New System.Drawing.Point(268, 211)
        Me.txtip.Name = "txtip"
        Me.txtip.Size = New System.Drawing.Size(104, 20)
        Me.txtip.TabIndex = 146
        '
        'lblip
        '
        Me.lblip.AutoSize = True
        Me.lblip.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblip.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblip.Location = New System.Drawing.Point(265, 193)
        Me.lblip.Name = "lblip"
        Me.lblip.Size = New System.Drawing.Size(115, 16)
        Me.lblip.TabIndex = 147
        Me.lblip.Text = "IP Urine / DL 3-Diff"
        '
        'butcompany
        '
        Me.butcompany.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butcompany.Location = New System.Drawing.Point(337, 64)
        Me.butcompany.Name = "butcompany"
        Me.butcompany.Size = New System.Drawing.Size(35, 27)
        Me.butcompany.TabIndex = 149
        Me.butcompany.Text = "..."
        Me.butcompany.UseVisualStyleBackColor = True
        '
        'TextBoxKeteranganLokasi
        '
        Me.TextBoxKeteranganLokasi.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBoxKeteranganLokasi.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxKeteranganLokasi.Location = New System.Drawing.Point(172, 65)
        Me.TextBoxKeteranganLokasi.Name = "TextBoxKeteranganLokasi"
        Me.TextBoxKeteranganLokasi.ReadOnly = True
        Me.TextBoxKeteranganLokasi.Size = New System.Drawing.Size(159, 22)
        Me.TextBoxKeteranganLokasi.TabIndex = 148
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(43, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 16)
        Me.Label2.TabIndex = 151
        Me.Label2.Text = "Cabang"
        '
        'TextBoxKodeLokasi
        '
        Me.TextBoxKodeLokasi.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBoxKodeLokasi.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxKodeLokasi.Location = New System.Drawing.Point(172, 65)
        Me.TextBoxKodeLokasi.Name = "TextBoxKodeLokasi"
        Me.TextBoxKodeLokasi.ReadOnly = True
        Me.TextBoxKodeLokasi.Size = New System.Drawing.Size(100, 22)
        Me.TextBoxKodeLokasi.TabIndex = 152
        Me.TextBoxKodeLokasi.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(43, 163)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 16)
        Me.Label1.TabIndex = 155
        Me.Label1.Text = "Tindakan"
        '
        'buttindakan
        '
        Me.buttindakan.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buttindakan.Location = New System.Drawing.Point(337, 158)
        Me.buttindakan.Name = "buttindakan"
        Me.buttindakan.Size = New System.Drawing.Size(35, 27)
        Me.buttindakan.TabIndex = 154
        Me.buttindakan.Text = "..."
        Me.buttindakan.UseVisualStyleBackColor = True
        '
        'txtindakanket
        '
        Me.txtindakanket.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtindakanket.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtindakanket.Location = New System.Drawing.Point(172, 159)
        Me.txtindakanket.Name = "txtindakanket"
        Me.txtindakanket.ReadOnly = True
        Me.txtindakanket.Size = New System.Drawing.Size(159, 22)
        Me.txtindakanket.TabIndex = 153
        '
        'txtindakanid
        '
        Me.txtindakanid.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtindakanid.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtindakanid.Location = New System.Drawing.Point(172, 159)
        Me.txtindakanid.Name = "txtindakanid"
        Me.txtindakanid.ReadOnly = True
        Me.txtindakanid.Size = New System.Drawing.Size(100, 22)
        Me.txtindakanid.TabIndex = 156
        Me.txtindakanid.Visible = False
        '
        'SendUlangToMesin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.PoliKlinik_Net2.My.Resources.Resources.wallpaperdialog
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(418, 324)
        Me.Controls.Add(Me.txtindakanid)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.buttindakan)
        Me.Controls.Add(Me.txtindakanket)
        Me.Controls.Add(Me.TextBoxKodeLokasi)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.butcompany)
        Me.Controls.Add(Me.TextBoxKeteranganLokasi)
        Me.Controls.Add(Me.lblip)
        Me.Controls.Add(Me.txtip)
        Me.Controls.Add(Me.Panelload)
        Me.Controls.Add(Me.lblSend)
        Me.Controls.Add(Me.btntrans)
        Me.Controls.Add(Me.txnotrans)
        Me.Controls.Add(Me.rdnotrans)
        Me.Controls.Add(Me.rdtanggal)
        Me.Controls.Add(Me.cmbjenis)
        Me.Controls.Add(Me.butproses)
        Me.Controls.Add(Me.dtproses)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SendUlangToMesin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Kirim Ulang Data ke Mesin"
        Me.Panelload.ResumeLayout(False)
        Me.Panelload.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtproses As System.Windows.Forms.DateTimePicker
    Friend WithEvents butproses As System.Windows.Forms.Button
    Friend WithEvents cmbjenis As System.Windows.Forms.ComboBox
    Friend WithEvents rdtanggal As System.Windows.Forms.RadioButton
    Friend WithEvents rdnotrans As System.Windows.Forms.RadioButton
    Friend WithEvents txnotrans As System.Windows.Forms.TextBox
    Friend WithEvents btntrans As System.Windows.Forms.Button
    Friend WithEvents lblSend As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents lblload As System.Windows.Forms.Label
    Friend WithEvents Panelload As System.Windows.Forms.Panel
    Friend WithEvents txtip As System.Windows.Forms.TextBox
    Friend WithEvents lblip As System.Windows.Forms.Label
    Friend WithEvents butcompany As System.Windows.Forms.Button
    Friend WithEvents TextBoxKeteranganLokasi As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBoxKodeLokasi As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents buttindakan As System.Windows.Forms.Button
    Friend WithEvents txtindakanket As System.Windows.Forms.TextBox
    Friend WithEvents txtindakanid As System.Windows.Forms.TextBox
End Class
