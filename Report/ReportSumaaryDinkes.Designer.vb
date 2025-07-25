<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportSumaaryDinkes
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
        Me.Button1 = New System.Windows.Forms.Button
        Me.dtakhir = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.dtawal = New System.Windows.Forms.DateTimePicker
        Me.rdsummary = New System.Windows.Forms.RadioButton
        Me.rddetail = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(158, 61)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 121
        Me.Button1.Text = "Display"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'dtakhir
        '
        Me.dtakhir.CustomFormat = "dd-MMM-yyyy"
        Me.dtakhir.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtakhir.Location = New System.Drawing.Point(205, 15)
        Me.dtakhir.Name = "dtakhir"
        Me.dtakhir.Size = New System.Drawing.Size(109, 20)
        Me.dtakhir.TabIndex = 120
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(176, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(23, 13)
        Me.Label6.TabIndex = 119
        Me.Label6.Text = "s/d"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 118
        Me.Label5.Text = "Periode"
        '
        'dtawal
        '
        Me.dtawal.CustomFormat = "dd-MMM-yyyy"
        Me.dtawal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtawal.Location = New System.Drawing.Point(61, 15)
        Me.dtawal.Name = "dtawal"
        Me.dtawal.Size = New System.Drawing.Size(109, 20)
        Me.dtawal.TabIndex = 117
        '
        'rdsummary
        '
        Me.rdsummary.AutoSize = True
        Me.rdsummary.Checked = True
        Me.rdsummary.Location = New System.Drawing.Point(61, 44)
        Me.rdsummary.Name = "rdsummary"
        Me.rdsummary.Size = New System.Drawing.Size(68, 17)
        Me.rdsummary.TabIndex = 122
        Me.rdsummary.TabStop = True
        Me.rdsummary.Text = "Summary"
        Me.rdsummary.UseVisualStyleBackColor = True
        '
        'rddetail
        '
        Me.rddetail.AutoSize = True
        Me.rddetail.Enabled = False
        Me.rddetail.Location = New System.Drawing.Point(61, 67)
        Me.rddetail.Name = "rddetail"
        Me.rddetail.Size = New System.Drawing.Size(52, 17)
        Me.rddetail.TabIndex = 123
        Me.rddetail.TabStop = True
        Me.rddetail.Text = "Detail"
        Me.rddetail.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 13)
        Me.Label1.TabIndex = 124
        Me.Label1.Text = "Jenis"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(239, 61)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 125
        Me.Button2.Text = "Export"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GridControl1)
        Me.GroupBox1.Location = New System.Drawing.Point(286, 61)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(790, 368)
        Me.GroupBox1.TabIndex = 126
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detail"
        Me.GroupBox1.Visible = False
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        '
        '
        '
        Me.GridControl1.EmbeddedNavigator.Name = ""
        Me.GridControl1.Location = New System.Drawing.Point(3, 16)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(784, 349)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'ReportSumaaryDinkes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(319, 93)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.rddetail)
        Me.Controls.Add(Me.rdsummary)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.dtakhir)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dtawal)
        Me.Name = "ReportSumaaryDinkes"
        Me.Text = "ReportSumaaryDinkes"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents dtakhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtawal As System.Windows.Forms.DateTimePicker
    Friend WithEvents rdsummary As System.Windows.Forms.RadioButton
    Friend WithEvents rddetail As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Private WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
