<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportLabDokterPengirim
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
        Me.dtkasirakhir = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtkasirawal = New System.Windows.Forms.DateTimePicker
        Me.butdisplay = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'dtkasirakhir
        '
        Me.dtkasirakhir.CustomFormat = "dd-MMM-yyyy"
        Me.dtkasirakhir.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtkasirakhir.Location = New System.Drawing.Point(194, 12)
        Me.dtkasirakhir.Name = "dtkasirakhir"
        Me.dtkasirakhir.Size = New System.Drawing.Size(99, 20)
        Me.dtkasirakhir.TabIndex = 109
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(168, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 13)
        Me.Label2.TabIndex = 108
        Me.Label2.Text = "To"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(11, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 107
        Me.Label4.Text = "Tanggal"
        '
        'dtkasirawal
        '
        Me.dtkasirawal.CustomFormat = "dd-MMM-yyyy"
        Me.dtkasirawal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtkasirawal.Location = New System.Drawing.Point(63, 12)
        Me.dtkasirawal.Name = "dtkasirawal"
        Me.dtkasirawal.Size = New System.Drawing.Size(99, 20)
        Me.dtkasirawal.TabIndex = 106
        '
        'butdisplay
        '
        Me.butdisplay.Location = New System.Drawing.Point(61, 45)
        Me.butdisplay.Name = "butdisplay"
        Me.butdisplay.Size = New System.Drawing.Size(75, 23)
        Me.butdisplay.TabIndex = 105
        Me.butdisplay.Text = "Detail"
        Me.butdisplay.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(170, 45)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 110
        Me.Button1.Text = "Summary"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ReportLabDokterPengirim
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(314, 81)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.dtkasirakhir)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtkasirawal)
        Me.Controls.Add(Me.butdisplay)
        Me.Name = "ReportLabDokterPengirim"
        Me.Text = "ReportLabDokterPengirim"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtkasirakhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtkasirawal As System.Windows.Forms.DateTimePicker
    Friend WithEvents butdisplay As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
