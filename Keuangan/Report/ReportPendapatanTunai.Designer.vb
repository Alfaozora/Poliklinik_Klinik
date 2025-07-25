<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportPendapatanTunai
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportPendapatanTunai))
        Me.dtkasirakhir = New System.Windows.Forms.DateTimePicker
        Me.dtkasirawal = New System.Windows.Forms.DateTimePicker
        Me.butdisplay = New System.Windows.Forms.Button
        Me.rdsumm = New System.Windows.Forms.RadioButton
        Me.rddetail = New System.Windows.Forms.RadioButton
        Me.cmbjenistrans = New System.Windows.Forms.ComboBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txkodecabang = New System.Windows.Forms.TextBox
        Me.butfind = New System.Windows.Forms.Button
        Me.txnamacabang = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbpembayaran = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'dtkasirakhir
        '
        Me.dtkasirakhir.CustomFormat = "dd-MMM-yyyy"
        Me.dtkasirakhir.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtkasirakhir.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtkasirakhir.Location = New System.Drawing.Point(292, 185)
        Me.dtkasirakhir.Name = "dtkasirakhir"
        Me.dtkasirakhir.Size = New System.Drawing.Size(115, 22)
        Me.dtkasirakhir.TabIndex = 113
        '
        'dtkasirawal
        '
        Me.dtkasirawal.CustomFormat = "dd-MMM-yyyy"
        Me.dtkasirawal.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtkasirawal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtkasirawal.Location = New System.Drawing.Point(152, 185)
        Me.dtkasirawal.Name = "dtkasirawal"
        Me.dtkasirawal.Size = New System.Drawing.Size(115, 22)
        Me.dtkasirawal.TabIndex = 110
        '
        'butdisplay
        '
        Me.butdisplay.BackgroundImage = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_cetak
        Me.butdisplay.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butdisplay.Location = New System.Drawing.Point(180, 222)
        Me.butdisplay.Name = "butdisplay"
        Me.butdisplay.Size = New System.Drawing.Size(100, 36)
        Me.butdisplay.TabIndex = 106
        Me.butdisplay.UseVisualStyleBackColor = True
        '
        'rdsumm
        '
        Me.rdsumm.AutoSize = True
        Me.rdsumm.BackColor = System.Drawing.Color.Transparent
        Me.rdsumm.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdsumm.Location = New System.Drawing.Point(152, 147)
        Me.rdsumm.Name = "rdsumm"
        Me.rdsumm.Size = New System.Drawing.Size(80, 24)
        Me.rdsumm.TabIndex = 117
        Me.rdsumm.TabStop = True
        Me.rdsumm.Text = "Summary"
        Me.rdsumm.UseVisualStyleBackColor = False
        '
        'rddetail
        '
        Me.rddetail.AutoSize = True
        Me.rddetail.BackColor = System.Drawing.Color.Transparent
        Me.rddetail.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rddetail.Location = New System.Drawing.Point(233, 147)
        Me.rddetail.Name = "rddetail"
        Me.rddetail.Size = New System.Drawing.Size(59, 24)
        Me.rddetail.TabIndex = 118
        Me.rddetail.TabStop = True
        Me.rddetail.Text = "Detail"
        Me.rddetail.UseVisualStyleBackColor = False
        '
        'cmbjenistrans
        '
        Me.cmbjenistrans.BackColor = System.Drawing.SystemColors.MenuBar
        Me.cmbjenistrans.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbjenistrans.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbjenistrans.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbjenistrans.FormattingEnabled = True
        Me.cmbjenistrans.Items.AddRange(New Object() {"SEMUA", "DLL", "GIGI", "LAB", "POLI"})
        Me.cmbjenistrans.Location = New System.Drawing.Point(152, 74)
        Me.cmbjenistrans.Name = "cmbjenistrans"
        Me.cmbjenistrans.Size = New System.Drawing.Size(121, 28)
        Me.cmbjenistrans.TabIndex = 205
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(35, 77)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(96, 20)
        Me.Label18.TabIndex = 204
        Me.Label18.Text = "Jenis Transaksi"
        '
        'txkodecabang
        '
        Me.txkodecabang.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txkodecabang.Location = New System.Drawing.Point(335, 37)
        Me.txkodecabang.Name = "txkodecabang"
        Me.txkodecabang.ReadOnly = True
        Me.txkodecabang.Size = New System.Drawing.Size(34, 25)
        Me.txkodecabang.TabIndex = 203
        Me.txkodecabang.Visible = False
        '
        'butfind
        '
        Me.butfind.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butfind.Location = New System.Drawing.Point(375, 38)
        Me.butfind.Name = "butfind"
        Me.butfind.Size = New System.Drawing.Size(31, 25)
        Me.butfind.TabIndex = 201
        Me.butfind.Text = "..."
        Me.butfind.UseVisualStyleBackColor = True
        '
        'txnamacabang
        '
        Me.txnamacabang.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txnamacabang.Location = New System.Drawing.Point(152, 38)
        Me.txnamacabang.Name = "txnamacabang"
        Me.txnamacabang.ReadOnly = True
        Me.txnamacabang.Size = New System.Drawing.Size(217, 25)
        Me.txnamacabang.TabIndex = 200
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(35, 41)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(53, 20)
        Me.Label16.TabIndex = 199
        Me.Label16.Text = "Cabang"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(35, 185)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 20)
        Me.Label1.TabIndex = 206
        Me.Label1.Text = "Tanggal"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(267, 185)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(25, 20)
        Me.Label3.TabIndex = 207
        Me.Label3.Text = "s/d"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(35, 149)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 20)
        Me.Label2.TabIndex = 208
        Me.Label2.Text = "Jenis Report"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(35, 116)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(111, 20)
        Me.Label4.TabIndex = 209
        Me.Label4.Text = "Jenis Pembayaran"
        '
        'cmbpembayaran
        '
        Me.cmbpembayaran.BackColor = System.Drawing.SystemColors.MenuBar
        Me.cmbpembayaran.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbpembayaran.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbpembayaran.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbpembayaran.FormattingEnabled = True
        Me.cmbpembayaran.Items.AddRange(New Object() {"SEMUA", "TUNAI", "DEBET", "KREDIT"})
        Me.cmbpembayaran.Location = New System.Drawing.Point(152, 113)
        Me.cmbpembayaran.Name = "cmbpembayaran"
        Me.cmbpembayaran.Size = New System.Drawing.Size(121, 28)
        Me.cmbpembayaran.TabIndex = 210
        '
        'ReportPendapatanTunai
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.PoliKlinik_Net2.My.Resources.Resources.wallpaperdialog
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(450, 344)
        Me.Controls.Add(Me.cmbpembayaran)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.rddetail)
        Me.Controls.Add(Me.rdsumm)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtkasirawal)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbjenistrans)
        Me.Controls.Add(Me.dtkasirakhir)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txkodecabang)
        Me.Controls.Add(Me.butfind)
        Me.Controls.Add(Me.txnamacabang)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.butdisplay)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ReportPendapatanTunai"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Report Pendapatan Tunai"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtkasirakhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtkasirawal As System.Windows.Forms.DateTimePicker
    Friend WithEvents butdisplay As System.Windows.Forms.Button
    Friend WithEvents rdsumm As System.Windows.Forms.RadioButton
    Friend WithEvents rddetail As System.Windows.Forms.RadioButton
    Friend WithEvents cmbjenistrans As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txkodecabang As System.Windows.Forms.TextBox
    Friend WithEvents butfind As System.Windows.Forms.Button
    Friend WithEvents txnamacabang As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbpembayaran As System.Windows.Forms.ComboBox
End Class
