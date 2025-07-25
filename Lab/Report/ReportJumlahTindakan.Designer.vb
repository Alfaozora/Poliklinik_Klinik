<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportJumlahTindakan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportJumlahTindakan))
        Me.dtprocessend = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.dtprocess = New System.Windows.Forms.DateTimePicker
        Me.butprint = New System.Windows.Forms.Button
        Me.rd2 = New System.Windows.Forms.RadioButton
        Me.rd1 = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.rddetail = New System.Windows.Forms.RadioButton
        Me.rdsummary = New System.Windows.Forms.RadioButton
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtprocessend
        '
        Me.dtprocessend.CustomFormat = "dd-MMM-yyyy"
        Me.dtprocessend.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtprocessend.Location = New System.Drawing.Point(266, 23)
        Me.dtprocessend.Name = "dtprocessend"
        Me.dtprocessend.Size = New System.Drawing.Size(109, 20)
        Me.dtprocessend.TabIndex = 239
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(236, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 16)
        Me.Label2.TabIndex = 238
        Me.Label2.Text = "s/d"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(20, 25)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(91, 16)
        Me.Label9.TabIndex = 237
        Me.Label9.Text = "Tgl Transaksi"
        '
        'dtprocess
        '
        Me.dtprocess.CustomFormat = "dd-MMM-yyyy"
        Me.dtprocess.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtprocess.Location = New System.Drawing.Point(121, 23)
        Me.dtprocess.Name = "dtprocess"
        Me.dtprocess.Size = New System.Drawing.Size(109, 20)
        Me.dtprocess.TabIndex = 236
        '
        'butprint
        '
        Me.butprint.Cursor = System.Windows.Forms.Cursors.Hand
        Me.butprint.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butprint.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_cetak
        Me.butprint.Location = New System.Drawing.Point(150, 120)
        Me.butprint.Name = "butprint"
        Me.butprint.Size = New System.Drawing.Size(100, 36)
        Me.butprint.TabIndex = 240
        Me.butprint.UseVisualStyleBackColor = True
        '
        'rd2
        '
        Me.rd2.AutoSize = True
        Me.rd2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rd2.Location = New System.Drawing.Point(86, 3)
        Me.rd2.Name = "rd2"
        Me.rd2.Size = New System.Drawing.Size(119, 19)
        Me.rd2.TabIndex = 242
        Me.rd2.TabStop = True
        Me.rd2.Text = "Semua Tindakan"
        Me.rd2.UseVisualStyleBackColor = True
        '
        'rd1
        '
        Me.rd1.AutoSize = True
        Me.rd1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rd1.Location = New System.Drawing.Point(5, 3)
        Me.rd1.Name = "rd1"
        Me.rd1.Size = New System.Drawing.Size(56, 19)
        Me.rd1.TabIndex = 243
        Me.rd1.TabStop = True
        Me.rd1.Text = "Covid"
        Me.rd1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 16)
        Me.Label1.TabIndex = 244
        Me.Label1.Text = "Pemeriksaan"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(20, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 16)
        Me.Label3.TabIndex = 247
        Me.Label3.Text = "Jenis Report"
        '
        'rddetail
        '
        Me.rddetail.AutoSize = True
        Me.rddetail.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rddetail.Location = New System.Drawing.Point(5, 3)
        Me.rddetail.Name = "rddetail"
        Me.rddetail.Size = New System.Drawing.Size(57, 19)
        Me.rddetail.TabIndex = 245
        Me.rddetail.TabStop = True
        Me.rddetail.Text = "Detail"
        Me.rddetail.UseVisualStyleBackColor = True
        '
        'rdsummary
        '
        Me.rdsummary.AutoSize = True
        Me.rdsummary.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdsummary.Location = New System.Drawing.Point(86, 3)
        Me.rdsummary.Name = "rdsummary"
        Me.rdsummary.Size = New System.Drawing.Size(78, 19)
        Me.rdsummary.TabIndex = 246
        Me.rdsummary.TabStop = True
        Me.rdsummary.Text = "Summary"
        Me.rdsummary.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.Panel2.Controls.Add(Me.rddetail)
        Me.Panel2.Controls.Add(Me.rdsummary)
        Me.Panel2.Location = New System.Drawing.Point(116, 90)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(250, 25)
        Me.Panel2.TabIndex = 248
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.rd1)
        Me.Panel1.Controls.Add(Me.rd2)
        Me.Panel1.Location = New System.Drawing.Point(116, 55)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(250, 25)
        Me.Panel1.TabIndex = 249
        '
        'ReportJumlahTindakan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(390, 217)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.butprint)
        Me.Controls.Add(Me.dtprocessend)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.dtprocess)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(400, 250)
        Me.MinimumSize = New System.Drawing.Size(400, 250)
        Me.Name = "ReportJumlahTindakan"
        Me.Text = "Report Jumlah Tindakan"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtprocessend As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtprocess As System.Windows.Forms.DateTimePicker
    Friend WithEvents butprint As System.Windows.Forms.Button
    Friend WithEvents rd2 As System.Windows.Forms.RadioButton
    Friend WithEvents rd1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents rddetail As System.Windows.Forms.RadioButton
    Friend WithEvents rdsummary As System.Windows.Forms.RadioButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
