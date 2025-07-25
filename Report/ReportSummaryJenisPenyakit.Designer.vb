<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportSummaryJenisPenyakit
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rdpasienpoliini = New System.Windows.Forms.RadioButton
        Me.rdpasienbpjs = New System.Windows.Forms.RadioButton
        Me.rdpasienpolilain = New System.Windows.Forms.RadioButton
        Me.rdpasienumum = New System.Windows.Forms.RadioButton
        Me.rdpasienall = New System.Windows.Forms.RadioButton
        Me.dtakhir = New System.Windows.Forms.DateTimePicker
        Me.dtawal = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.butdisplay = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.rdtanggal = New System.Windows.Forms.RadioButton
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rdpasienpoliini)
        Me.GroupBox2.Controls.Add(Me.rdpasienbpjs)
        Me.GroupBox2.Controls.Add(Me.rdpasienpolilain)
        Me.GroupBox2.Controls.Add(Me.rdpasienumum)
        Me.GroupBox2.Controls.Add(Me.rdpasienall)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(343, 135)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Summary per Jenis Penyakit"
        '
        'rdpasienpoliini
        '
        Me.rdpasienpoliini.AutoSize = True
        Me.rdpasienpoliini.Location = New System.Drawing.Point(6, 65)
        Me.rdpasienpoliini.Name = "rdpasienpoliini"
        Me.rdpasienpoliini.Size = New System.Drawing.Size(130, 17)
        Me.rdpasienpoliini.TabIndex = 4
        Me.rdpasienpoliini.TabStop = True
        Me.rdpasienpoliini.Text = "Pasien Cahaya Poli Ini"
        Me.rdpasienpoliini.UseVisualStyleBackColor = True
        '
        'rdpasienbpjs
        '
        Me.rdpasienbpjs.AutoSize = True
        Me.rdpasienbpjs.Location = New System.Drawing.Point(6, 111)
        Me.rdpasienbpjs.Name = "rdpasienbpjs"
        Me.rdpasienbpjs.Size = New System.Drawing.Size(86, 17)
        Me.rdpasienbpjs.TabIndex = 3
        Me.rdpasienbpjs.TabStop = True
        Me.rdpasienbpjs.Text = "Pasien BPJS"
        Me.rdpasienbpjs.UseVisualStyleBackColor = True
        '
        'rdpasienpolilain
        '
        Me.rdpasienpolilain.AutoSize = True
        Me.rdpasienpolilain.Location = New System.Drawing.Point(6, 88)
        Me.rdpasienpolilain.Name = "rdpasienpolilain"
        Me.rdpasienpolilain.Size = New System.Drawing.Size(139, 17)
        Me.rdpasienpolilain.TabIndex = 2
        Me.rdpasienpolilain.TabStop = True
        Me.rdpasienpolilain.Text = "Pasien Cahaya Poli Lain"
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
        'dtakhir
        '
        Me.dtakhir.CustomFormat = "dd-MMM-yyyy"
        Me.dtakhir.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtakhir.Location = New System.Drawing.Point(218, 18)
        Me.dtakhir.Name = "dtakhir"
        Me.dtakhir.Size = New System.Drawing.Size(107, 20)
        Me.dtakhir.TabIndex = 64
        '
        'dtawal
        '
        Me.dtawal.CustomFormat = "dd-MMM-yyyy"
        Me.dtawal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtawal.Location = New System.Drawing.Point(76, 18)
        Me.dtawal.Name = "dtawal"
        Me.dtawal.Size = New System.Drawing.Size(107, 20)
        Me.dtawal.TabIndex = 63
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(189, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 13)
        Me.Label1.TabIndex = 65
        Me.Label1.Text = "s/d"
        '
        'butdisplay
        '
        Me.butdisplay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butdisplay.Location = New System.Drawing.Point(256, 196)
        Me.butdisplay.Name = "butdisplay"
        Me.butdisplay.Size = New System.Drawing.Size(75, 23)
        Me.butdisplay.TabIndex = 9
        Me.butdisplay.Text = "Display"
        Me.butdisplay.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.dtakhir)
        Me.GroupBox3.Controls.Add(Me.dtawal)
        Me.GroupBox3.Controls.Add(Me.rdtanggal)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Location = New System.Drawing.Point(0, 135)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(343, 51)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Periode Tanggal"
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
        'ReportSummaryJenisPenyakit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(343, 231)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.butdisplay)
        Me.Name = "ReportSummaryJenisPenyakit"
        Me.Text = "ReportSummaryJenisPenyakit"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rdpasienpoliini As System.Windows.Forms.RadioButton
    Friend WithEvents rdpasienbpjs As System.Windows.Forms.RadioButton
    Friend WithEvents rdpasienpolilain As System.Windows.Forms.RadioButton
    Friend WithEvents rdpasienumum As System.Windows.Forms.RadioButton
    Friend WithEvents rdpasienall As System.Windows.Forms.RadioButton
    Friend WithEvents dtakhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtawal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents butdisplay As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rdtanggal As System.Windows.Forms.RadioButton
End Class
