<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportPenerimaan
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
        Me.rdtransall = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rdtranstindakan = New System.Windows.Forms.RadioButton
        Me.rdtransugd = New System.Windows.Forms.RadioButton
        Me.rdtranslab = New System.Windows.Forms.RadioButton
        Me.rdtransdaftar = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rdpasienpoliini = New System.Windows.Forms.RadioButton
        Me.rdpasienf1b = New System.Windows.Forms.RadioButton
        Me.rdpasienpolilain = New System.Windows.Forms.RadioButton
        Me.rdpasienumum = New System.Windows.Forms.RadioButton
        Me.rdpasienall = New System.Windows.Forms.RadioButton
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtakhir = New System.Windows.Forms.DateTimePicker
        Me.dtawal = New System.Windows.Forms.DateTimePicker
        Me.rdtanggal = New System.Windows.Forms.RadioButton
        Me.butdisplay = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'rdtransall
        '
        Me.rdtransall.AutoSize = True
        Me.rdtransall.Location = New System.Drawing.Point(6, 19)
        Me.rdtransall.Name = "rdtransall"
        Me.rdtransall.Size = New System.Drawing.Size(258, 17)
        Me.rdtransall.TabIndex = 0
        Me.rdtransall.TabStop = True
        Me.rdtransall.Text = "Semua Transaksi ( Pemeriksaan, Tindakan, Lab )"
        Me.rdtransall.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdtranstindakan)
        Me.GroupBox1.Controls.Add(Me.rdtransugd)
        Me.GroupBox1.Controls.Add(Me.rdtranslab)
        Me.GroupBox1.Controls.Add(Me.rdtransdaftar)
        Me.GroupBox1.Controls.Add(Me.rdtransall)
        Me.GroupBox1.Location = New System.Drawing.Point(4, 133)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(336, 135)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Jenis Transaksi"
        '
        'rdtranstindakan
        '
        Me.rdtranstindakan.AutoSize = True
        Me.rdtranstindakan.Location = New System.Drawing.Point(6, 65)
        Me.rdtranstindakan.Name = "rdtranstindakan"
        Me.rdtranstindakan.Size = New System.Drawing.Size(119, 17)
        Me.rdtranstindakan.TabIndex = 4
        Me.rdtranstindakan.TabStop = True
        Me.rdtranstindakan.Text = "Transaksi Tindakan"
        Me.rdtranstindakan.UseVisualStyleBackColor = True
        '
        'rdtransugd
        '
        Me.rdtransugd.AutoSize = True
        Me.rdtransugd.Location = New System.Drawing.Point(6, 111)
        Me.rdtransugd.Name = "rdtransugd"
        Me.rdtransugd.Size = New System.Drawing.Size(98, 17)
        Me.rdtransugd.TabIndex = 3
        Me.rdtransugd.TabStop = True
        Me.rdtransugd.Text = "Transaksi UGD"
        Me.rdtransugd.UseVisualStyleBackColor = True
        Me.rdtransugd.Visible = False
        '
        'rdtranslab
        '
        Me.rdtranslab.AutoSize = True
        Me.rdtranslab.Location = New System.Drawing.Point(6, 88)
        Me.rdtranslab.Name = "rdtranslab"
        Me.rdtranslab.Size = New System.Drawing.Size(135, 17)
        Me.rdtranslab.TabIndex = 2
        Me.rdtranslab.TabStop = True
        Me.rdtranslab.Text = "Transaksi Laboratorium"
        Me.rdtranslab.UseVisualStyleBackColor = True
        '
        'rdtransdaftar
        '
        Me.rdtransdaftar.AutoSize = True
        Me.rdtransdaftar.Location = New System.Drawing.Point(6, 42)
        Me.rdtransdaftar.Name = "rdtransdaftar"
        Me.rdtransdaftar.Size = New System.Drawing.Size(109, 17)
        Me.rdtransdaftar.TabIndex = 1
        Me.rdtransdaftar.TabStop = True
        Me.rdtransdaftar.Text = "Transaksi Periksa"
        Me.rdtransdaftar.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rdpasienpoliini)
        Me.GroupBox2.Controls.Add(Me.rdpasienf1b)
        Me.GroupBox2.Controls.Add(Me.rdpasienpolilain)
        Me.GroupBox2.Controls.Add(Me.rdpasienumum)
        Me.GroupBox2.Controls.Add(Me.rdpasienall)
        Me.GroupBox2.Location = New System.Drawing.Point(3, -1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(336, 135)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Jenis Pasien"
        '
        'rdpasienpoliini
        '
        Me.rdpasienpoliini.AutoSize = True
        Me.rdpasienpoliini.Location = New System.Drawing.Point(6, 65)
        Me.rdpasienpoliini.Name = "rdpasienpoliini"
        Me.rdpasienpoliini.Size = New System.Drawing.Size(86, 17)
        Me.rdpasienpoliini.TabIndex = 4
        Me.rdpasienpoliini.TabStop = True
        Me.rdpasienpoliini.Text = "Pasien BPJS"
        Me.rdpasienpoliini.UseVisualStyleBackColor = True
        '
        'rdpasienf1b
        '
        Me.rdpasienf1b.AutoSize = True
        Me.rdpasienf1b.Location = New System.Drawing.Point(6, 111)
        Me.rdpasienf1b.Name = "rdpasienf1b"
        Me.rdpasienf1b.Size = New System.Drawing.Size(118, 17)
        Me.rdpasienf1b.TabIndex = 3
        Me.rdpasienf1b.TabStop = True
        Me.rdpasienf1b.Text = "Pasien Cahaya F1B"
        Me.rdpasienf1b.UseVisualStyleBackColor = True
        Me.rdpasienf1b.Visible = False
        '
        'rdpasienpolilain
        '
        Me.rdpasienpolilain.AutoSize = True
        Me.rdpasienpolilain.Location = New System.Drawing.Point(6, 88)
        Me.rdpasienpolilain.Name = "rdpasienpolilain"
        Me.rdpasienpolilain.Size = New System.Drawing.Size(84, 17)
        Me.rdpasienpolilain.TabIndex = 2
        Me.rdpasienpolilain.TabStop = True
        Me.rdpasienpolilain.Text = "Pasien CMH"
        Me.rdpasienpolilain.UseVisualStyleBackColor = True
        '
        'rdpasienumum
        '
        Me.rdpasienumum.AutoSize = True
        Me.rdpasienumum.Location = New System.Drawing.Point(6, 42)
        Me.rdpasienumum.Name = "rdpasienumum"
        Me.rdpasienumum.Size = New System.Drawing.Size(90, 17)
        Me.rdpasienumum.TabIndex = 1
        Me.rdpasienumum.TabStop = True
        Me.rdpasienumum.Text = "Pasien Umum"
        Me.rdpasienumum.UseVisualStyleBackColor = True
        '
        'rdpasienall
        '
        Me.rdpasienall.AutoSize = True
        Me.rdpasienall.Location = New System.Drawing.Point(6, 19)
        Me.rdpasienall.Name = "rdpasienall"
        Me.rdpasienall.Size = New System.Drawing.Size(120, 17)
        Me.rdpasienall.TabIndex = 0
        Me.rdpasienall.TabStop = True
        Me.rdpasienall.Text = "Semua Jenis Pasien"
        Me.rdpasienall.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.dtakhir)
        Me.GroupBox3.Controls.Add(Me.dtawal)
        Me.GroupBox3.Controls.Add(Me.rdtanggal)
        Me.GroupBox3.Location = New System.Drawing.Point(3, 267)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(336, 51)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Periode Tanggal"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(189, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 13)
        Me.Label1.TabIndex = 65
        Me.Label1.Text = "s/d"
        '
        'dtakhir
        '
        Me.dtakhir.CustomFormat = "dd-MMM-yyyy"
        Me.dtakhir.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtakhir.Location = New System.Drawing.Point(218, 17)
        Me.dtakhir.Name = "dtakhir"
        Me.dtakhir.Size = New System.Drawing.Size(107, 20)
        Me.dtakhir.TabIndex = 64
        '
        'dtawal
        '
        Me.dtawal.CustomFormat = "dd-MMM-yyyy"
        Me.dtawal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtawal.Location = New System.Drawing.Point(76, 17)
        Me.dtawal.Name = "dtawal"
        Me.dtawal.Size = New System.Drawing.Size(107, 20)
        Me.dtawal.TabIndex = 63
        '
        'rdtanggal
        '
        Me.rdtanggal.AutoSize = True
        Me.rdtanggal.Location = New System.Drawing.Point(6, 19)
        Me.rdtanggal.Name = "rdtanggal"
        Me.rdtanggal.Size = New System.Drawing.Size(64, 17)
        Me.rdtanggal.TabIndex = 0
        Me.rdtanggal.TabStop = True
        Me.rdtanggal.Text = "Tanggal"
        Me.rdtanggal.UseVisualStyleBackColor = True
        '
        'butdisplay
        '
        Me.butdisplay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butdisplay.Location = New System.Drawing.Point(249, 324)
        Me.butdisplay.Name = "butdisplay"
        Me.butdisplay.Size = New System.Drawing.Size(75, 23)
        Me.butdisplay.TabIndex = 4
        Me.butdisplay.Text = "Display"
        Me.butdisplay.UseVisualStyleBackColor = True
        '
        'ReportPenerimaan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(336, 356)
        Me.Controls.Add(Me.butdisplay)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ReportPenerimaan"
        Me.Text = "ReportPenerimaan"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents rdtransall As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdtranstindakan As System.Windows.Forms.RadioButton
    Friend WithEvents rdtransugd As System.Windows.Forms.RadioButton
    Friend WithEvents rdtranslab As System.Windows.Forms.RadioButton
    Friend WithEvents rdtransdaftar As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rdpasienpoliini As System.Windows.Forms.RadioButton
    Friend WithEvents rdpasienf1b As System.Windows.Forms.RadioButton
    Friend WithEvents rdpasienpolilain As System.Windows.Forms.RadioButton
    Friend WithEvents rdpasienumum As System.Windows.Forms.RadioButton
    Friend WithEvents rdpasienall As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rdtanggal As System.Windows.Forms.RadioButton
    Friend WithEvents dtawal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtakhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents butdisplay As System.Windows.Forms.Button
End Class
