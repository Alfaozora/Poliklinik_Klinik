<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SetPeriode
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
        Me.dtakhir = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.dtawal = New System.Windows.Forms.DateTimePicker
        Me.cmbsave = New System.Windows.Forms.Button
        Me.txkriteria = New System.Windows.Forms.TextBox
        Me.cmbstatus = New System.Windows.Forms.ComboBox
        Me.SuspendLayout()
        '
        'dtakhir
        '
        Me.dtakhir.CustomFormat = "dd-MMM-yyyy"
        Me.dtakhir.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtakhir.Location = New System.Drawing.Point(236, 12)
        Me.dtakhir.Name = "dtakhir"
        Me.dtakhir.Size = New System.Drawing.Size(107, 20)
        Me.dtakhir.TabIndex = 107
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(211, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(23, 13)
        Me.Label6.TabIndex = 106
        Me.Label6.Text = "s/d"
        '
        'dtawal
        '
        Me.dtawal.CustomFormat = "dd-MMM-yyyy"
        Me.dtawal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtawal.Location = New System.Drawing.Point(98, 12)
        Me.dtawal.Name = "dtawal"
        Me.dtawal.Size = New System.Drawing.Size(107, 20)
        Me.dtawal.TabIndex = 105
        '
        'cmbsave
        '
        Me.cmbsave.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmbsave.Location = New System.Drawing.Point(148, 41)
        Me.cmbsave.Name = "cmbsave"
        Me.cmbsave.Size = New System.Drawing.Size(75, 23)
        Me.cmbsave.TabIndex = 108
        Me.cmbsave.Text = "Save"
        Me.cmbsave.UseVisualStyleBackColor = True
        '
        'txkriteria
        '
        Me.txkriteria.Enabled = False
        Me.txkriteria.Location = New System.Drawing.Point(7, 43)
        Me.txkriteria.Name = "txkriteria"
        Me.txkriteria.Size = New System.Drawing.Size(100, 20)
        Me.txkriteria.TabIndex = 109
        Me.txkriteria.Visible = False
        '
        'cmbstatus
        '
        Me.cmbstatus.AutoCompleteCustomSource.AddRange(New String() {"AKTIF", "NONAKTIF"})
        Me.cmbstatus.FormattingEnabled = True
        Me.cmbstatus.Items.AddRange(New Object() {"AKTIF", "NONAKTIF"})
        Me.cmbstatus.Location = New System.Drawing.Point(7, 11)
        Me.cmbstatus.Name = "cmbstatus"
        Me.cmbstatus.Size = New System.Drawing.Size(85, 21)
        Me.cmbstatus.TabIndex = 110
        '
        'SetPeriode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(370, 77)
        Me.Controls.Add(Me.cmbstatus)
        Me.Controls.Add(Me.txkriteria)
        Me.Controls.Add(Me.cmbsave)
        Me.Controls.Add(Me.dtakhir)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.dtawal)
        Me.Name = "SetPeriode"
        Me.Text = "SetPeriode"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtakhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtawal As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbsave As System.Windows.Forms.Button
    Friend WithEvents txkriteria As System.Windows.Forms.TextBox
    Friend WithEvents cmbstatus As System.Windows.Forms.ComboBox
End Class
