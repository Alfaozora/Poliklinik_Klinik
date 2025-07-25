<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportPendapatanTagihan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportPendapatanTagihan))
        Me.dtkasirakhir = New System.Windows.Forms.DateTimePicker
        Me.dtkasirawal = New System.Windows.Forms.DateTimePicker
        Me.butdisplay = New System.Windows.Forms.Button
        Me.butfind = New System.Windows.Forms.Button
        Me.txnamacompany = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.rdbayar2 = New System.Windows.Forms.RadioButton
        Me.rdbayar1 = New System.Windows.Forms.RadioButton
        Me.rdbayar3 = New System.Windows.Forms.RadioButton
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.rdjenistransaksi1 = New System.Windows.Forms.RadioButton
        Me.rdjenistransaksi3 = New System.Windows.Forms.RadioButton
        Me.rdjenistransaksi2 = New System.Windows.Forms.RadioButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.txlocid = New System.Windows.Forms.TextBox
        Me.txlocket = New System.Windows.Forms.TextBox
        Me.butcabang = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtkasirakhir
        '
        Me.dtkasirakhir.CustomFormat = "dd-MMM-yyyy"
        Me.dtkasirakhir.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtkasirakhir.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtkasirakhir.Location = New System.Drawing.Point(271, 74)
        Me.dtkasirakhir.Name = "dtkasirakhir"
        Me.dtkasirakhir.Size = New System.Drawing.Size(115, 21)
        Me.dtkasirakhir.TabIndex = 113
        '
        'dtkasirawal
        '
        Me.dtkasirawal.CustomFormat = "dd-MMM-yyyy"
        Me.dtkasirawal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtkasirawal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtkasirawal.Location = New System.Drawing.Point(130, 74)
        Me.dtkasirawal.Name = "dtkasirawal"
        Me.dtkasirawal.Size = New System.Drawing.Size(115, 21)
        Me.dtkasirawal.TabIndex = 110
        '
        'butdisplay
        '
        Me.butdisplay.BackgroundImage = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_cetak
        Me.butdisplay.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butdisplay.Location = New System.Drawing.Point(131, 155)
        Me.butdisplay.Name = "butdisplay"
        Me.butdisplay.Size = New System.Drawing.Size(100, 36)
        Me.butdisplay.TabIndex = 106
        Me.butdisplay.UseVisualStyleBackColor = True
        '
        'butfind
        '
        Me.butfind.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butfind.Location = New System.Drawing.Point(355, 17)
        Me.butfind.Name = "butfind"
        Me.butfind.Size = New System.Drawing.Size(31, 25)
        Me.butfind.TabIndex = 201
        Me.butfind.Text = "..."
        Me.butfind.UseVisualStyleBackColor = True
        '
        'txnamacompany
        '
        Me.txnamacompany.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txnamacompany.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txnamacompany.Location = New System.Drawing.Point(130, 20)
        Me.txnamacompany.Name = "txnamacompany"
        Me.txnamacompany.ReadOnly = True
        Me.txnamacompany.Size = New System.Drawing.Size(217, 21)
        Me.txnamacompany.TabIndex = 200
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(52, 23)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(63, 16)
        Me.Label16.TabIndex = 199
        Me.Label16.Text = "Company"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 77)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 16)
        Me.Label1.TabIndex = 206
        Me.Label1.Text = "Tanggal Invoice"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(245, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 16)
        Me.Label3.TabIndex = 207
        Me.Label3.Text = "s/d"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(69, 127)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 16)
        Me.Label2.TabIndex = 208
        Me.Label2.Text = "Status"
        '
        'rdbayar2
        '
        Me.rdbayar2.AutoSize = True
        Me.rdbayar2.BackColor = System.Drawing.Color.Transparent
        Me.rdbayar2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbayar2.Location = New System.Drawing.Point(80, 2)
        Me.rdbayar2.Name = "rdbayar2"
        Me.rdbayar2.Size = New System.Drawing.Size(116, 20)
        Me.rdbayar2.TabIndex = 210
        Me.rdbayar2.TabStop = True
        Me.rdbayar2.Text = "Belum Terbayar"
        Me.rdbayar2.UseVisualStyleBackColor = False
        '
        'rdbayar1
        '
        Me.rdbayar1.AutoSize = True
        Me.rdbayar1.BackColor = System.Drawing.Color.Transparent
        Me.rdbayar1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbayar1.Location = New System.Drawing.Point(1, 2)
        Me.rdbayar1.Name = "rdbayar1"
        Me.rdbayar1.Size = New System.Drawing.Size(75, 20)
        Me.rdbayar1.TabIndex = 209
        Me.rdbayar1.TabStop = True
        Me.rdbayar1.Text = "Terbayar"
        Me.rdbayar1.UseVisualStyleBackColor = False
        '
        'rdbayar3
        '
        Me.rdbayar3.AutoSize = True
        Me.rdbayar3.BackColor = System.Drawing.Color.Transparent
        Me.rdbayar3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdbayar3.Location = New System.Drawing.Point(202, 2)
        Me.rdbayar3.Name = "rdbayar3"
        Me.rdbayar3.Size = New System.Drawing.Size(67, 20)
        Me.rdbayar3.TabIndex = 211
        Me.rdbayar3.TabStop = True
        Me.rdbayar3.Text = "Semua"
        Me.rdbayar3.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel2.Controls.Add(Me.rdbayar1)
        Me.Panel2.Controls.Add(Me.rdbayar3)
        Me.Panel2.Controls.Add(Me.rdbayar2)
        Me.Panel2.Location = New System.Drawing.Point(130, 124)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(294, 25)
        Me.Panel2.TabIndex = 249
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel1.Controls.Add(Me.rdjenistransaksi1)
        Me.Panel1.Controls.Add(Me.rdjenistransaksi3)
        Me.Panel1.Controls.Add(Me.rdjenistransaksi2)
        Me.Panel1.Location = New System.Drawing.Point(130, 99)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(294, 25)
        Me.Panel1.TabIndex = 250
        '
        'rdjenistransaksi1
        '
        Me.rdjenistransaksi1.AutoSize = True
        Me.rdjenistransaksi1.BackColor = System.Drawing.Color.Transparent
        Me.rdjenistransaksi1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdjenistransaksi1.Location = New System.Drawing.Point(1, 2)
        Me.rdjenistransaksi1.Name = "rdjenistransaksi1"
        Me.rdjenistransaksi1.Size = New System.Drawing.Size(58, 20)
        Me.rdjenistransaksi1.TabIndex = 209
        Me.rdjenistransaksi1.TabStop = True
        Me.rdjenistransaksi1.Text = "Klinik"
        Me.rdjenistransaksi1.UseVisualStyleBackColor = False
        '
        'rdjenistransaksi3
        '
        Me.rdjenistransaksi3.AutoSize = True
        Me.rdjenistransaksi3.BackColor = System.Drawing.Color.Transparent
        Me.rdjenistransaksi3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdjenistransaksi3.Location = New System.Drawing.Point(202, 2)
        Me.rdjenistransaksi3.Name = "rdjenistransaksi3"
        Me.rdjenistransaksi3.Size = New System.Drawing.Size(67, 20)
        Me.rdjenistransaksi3.TabIndex = 211
        Me.rdjenistransaksi3.TabStop = True
        Me.rdjenistransaksi3.Text = "Semua"
        Me.rdjenistransaksi3.UseVisualStyleBackColor = False
        '
        'rdjenistransaksi2
        '
        Me.rdjenistransaksi2.AutoSize = True
        Me.rdjenistransaksi2.BackColor = System.Drawing.Color.Transparent
        Me.rdjenistransaksi2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdjenistransaksi2.Location = New System.Drawing.Point(80, 2)
        Me.rdjenistransaksi2.Name = "rdjenistransaksi2"
        Me.rdjenistransaksi2.Size = New System.Drawing.Size(101, 20)
        Me.rdjenistransaksi2.TabIndex = 210
        Me.rdjenistransaksi2.TabStop = True
        Me.rdjenistransaksi2.Text = "Laboratorium"
        Me.rdjenistransaksi2.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(17, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 16)
        Me.Label4.TabIndex = 251
        Me.Label4.Text = "Jenis Transaksi"
        '
        'txlocid
        '
        Me.txlocid.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txlocid.Location = New System.Drawing.Point(130, 47)
        Me.txlocid.Name = "txlocid"
        Me.txlocid.Size = New System.Drawing.Size(101, 21)
        Me.txlocid.TabIndex = 260
        Me.txlocid.Visible = False
        '
        'txlocket
        '
        Me.txlocket.BackColor = System.Drawing.SystemColors.Window
        Me.txlocket.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txlocket.Location = New System.Drawing.Point(130, 47)
        Me.txlocket.Name = "txlocket"
        Me.txlocket.ReadOnly = True
        Me.txlocket.Size = New System.Drawing.Size(218, 21)
        Me.txlocket.TabIndex = 261
        '
        'butcabang
        '
        Me.butcabang.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.butcabang.Location = New System.Drawing.Point(355, 44)
        Me.butcabang.Name = "butcabang"
        Me.butcabang.Size = New System.Drawing.Size(31, 25)
        Me.butcabang.TabIndex = 258
        Me.butcabang.Text = "..."
        Me.butcabang.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(63, 49)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(52, 16)
        Me.Label5.TabIndex = 262
        Me.Label5.Text = "Cabang"
        '
        'ReportPendapatanTagihan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.PoliKlinik_Net2.My.Resources.Resources.wallpaperdialog
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(434, 311)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txlocid)
        Me.Controls.Add(Me.txlocket)
        Me.Controls.Add(Me.butcabang)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtkasirawal)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtkasirakhir)
        Me.Controls.Add(Me.butfind)
        Me.Controls.Add(Me.txnamacompany)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.butdisplay)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(450, 350)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(450, 350)
        Me.Name = "ReportPendapatanTagihan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Report Pendapatan Tagihan"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtkasirakhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtkasirawal As System.Windows.Forms.DateTimePicker
    Friend WithEvents butdisplay As System.Windows.Forms.Button
    Friend WithEvents butfind As System.Windows.Forms.Button
    Friend WithEvents txnamacompany As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rdbayar2 As System.Windows.Forms.RadioButton
    Friend WithEvents rdbayar1 As System.Windows.Forms.RadioButton
    Friend WithEvents rdbayar3 As System.Windows.Forms.RadioButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rdjenistransaksi1 As System.Windows.Forms.RadioButton
    Friend WithEvents rdjenistransaksi3 As System.Windows.Forms.RadioButton
    Friend WithEvents rdjenistransaksi2 As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txlocid As System.Windows.Forms.TextBox
    Friend WithEvents txlocket As System.Windows.Forms.TextBox
    Friend WithEvents butcabang As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
