<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Report_Pendapatan_Klinik
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
        Me.butdisplay = New System.Windows.Forms.Button
        Me.butfindkasir = New System.Windows.Forms.Button
        Me.cmbkasir = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtkasirawal = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtkasirakhir = New System.Windows.Forms.DateTimePicker
        Me.txkasirid = New System.Windows.Forms.TextBox
        Me.txjenis = New System.Windows.Forms.TextBox
        Me.lbllap = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'butdisplay
        '
        Me.butdisplay.Location = New System.Drawing.Point(152, 72)
        Me.butdisplay.Name = "butdisplay"
        Me.butdisplay.Size = New System.Drawing.Size(75, 23)
        Me.butdisplay.TabIndex = 0
        Me.butdisplay.Text = "Display"
        Me.butdisplay.UseVisualStyleBackColor = True
        '
        'butfindkasir
        '
        Me.butfindkasir.Enabled = False
        Me.butfindkasir.Location = New System.Drawing.Point(286, 11)
        Me.butfindkasir.Name = "butfindkasir"
        Me.butfindkasir.Size = New System.Drawing.Size(27, 23)
        Me.butfindkasir.TabIndex = 86
        Me.butfindkasir.Text = "..."
        Me.butfindkasir.UseVisualStyleBackColor = True
        Me.butfindkasir.Visible = False
        '
        'cmbkasir
        '
        Me.cmbkasir.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbkasir.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbkasir.Enabled = False
        Me.cmbkasir.FormattingEnabled = True
        Me.cmbkasir.Location = New System.Drawing.Point(79, 12)
        Me.cmbkasir.Name = "cmbkasir"
        Me.cmbkasir.Size = New System.Drawing.Size(201, 21)
        Me.cmbkasir.TabIndex = 87
        Me.cmbkasir.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Enabled = False
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 85
        Me.Label1.Text = "Nama Kasir"
        Me.Label1.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(27, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 100
        Me.Label4.Text = "Tanggal"
        '
        'dtkasirawal
        '
        Me.dtkasirawal.CustomFormat = "dd-MMM-yyyy HH:mm"
        Me.dtkasirawal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtkasirawal.Location = New System.Drawing.Point(79, 39)
        Me.dtkasirawal.Name = "dtkasirawal"
        Me.dtkasirawal.Size = New System.Drawing.Size(130, 20)
        Me.dtkasirawal.TabIndex = 99
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(215, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 13)
        Me.Label2.TabIndex = 101
        Me.Label2.Text = "To"
        '
        'dtkasirakhir
        '
        Me.dtkasirakhir.CustomFormat = "dd-MMM-yyyy HH:mm"
        Me.dtkasirakhir.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtkasirakhir.Location = New System.Drawing.Point(241, 39)
        Me.dtkasirakhir.Name = "dtkasirakhir"
        Me.dtkasirakhir.Size = New System.Drawing.Size(130, 20)
        Me.dtkasirakhir.TabIndex = 102
        '
        'txkasirid
        '
        Me.txkasirid.Enabled = False
        Me.txkasirid.Location = New System.Drawing.Point(319, 14)
        Me.txkasirid.MaxLength = 100
        Me.txkasirid.Name = "txkasirid"
        Me.txkasirid.Size = New System.Drawing.Size(52, 20)
        Me.txkasirid.TabIndex = 103
        Me.txkasirid.Visible = False
        '
        'txjenis
        '
        Me.txjenis.Enabled = False
        Me.txjenis.Location = New System.Drawing.Point(79, 72)
        Me.txjenis.MaxLength = 100
        Me.txjenis.Name = "txjenis"
        Me.txjenis.Size = New System.Drawing.Size(52, 20)
        Me.txjenis.TabIndex = 104
        '
        'lbllap
        '
        Me.lbllap.AutoSize = True
        Me.lbllap.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllap.Location = New System.Drawing.Point(16, 14)
        Me.lbllap.Name = "lbllap"
        Me.lbllap.Size = New System.Drawing.Size(57, 18)
        Me.lbllap.TabIndex = 105
        Me.lbllap.Text = "Label3"
        '
        'Report_Pendapatan_Klinik
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(379, 107)
        Me.Controls.Add(Me.lbllap)
        Me.Controls.Add(Me.txjenis)
        Me.Controls.Add(Me.txkasirid)
        Me.Controls.Add(Me.dtkasirakhir)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtkasirawal)
        Me.Controls.Add(Me.butfindkasir)
        Me.Controls.Add(Me.cmbkasir)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.butdisplay)
        Me.Name = "Report_Pendapatan_Klinik"
        Me.Text = "Report Pendapatan Klinik"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents butdisplay As System.Windows.Forms.Button
    Friend WithEvents butfindkasir As System.Windows.Forms.Button
    Friend WithEvents cmbkasir As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtkasirawal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtkasirakhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents txkasirid As System.Windows.Forms.TextBox
    Friend WithEvents txjenis As System.Windows.Forms.TextBox
    Friend WithEvents lbllap As System.Windows.Forms.Label
End Class
