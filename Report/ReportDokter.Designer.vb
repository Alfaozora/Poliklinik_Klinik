<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportDokter
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.rddokter = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtakhir = New System.Windows.Forms.DateTimePicker
        Me.butdisplay = New System.Windows.Forms.Button
        Me.dtawal = New System.Windows.Forms.DateTimePicker
        Me.rdtanggal = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.gridtindakan = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.gridtindakan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rddokter)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.dtakhir)
        Me.GroupBox3.Controls.Add(Me.butdisplay)
        Me.GroupBox3.Controls.Add(Me.dtawal)
        Me.GroupBox3.Controls.Add(Me.rdtanggal)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(515, 92)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Periode Tanggal"
        '
        'rddokter
        '
        Me.rddokter.AutoSize = True
        Me.rddokter.Location = New System.Drawing.Point(6, 65)
        Me.rddokter.Name = "rddokter"
        Me.rddokter.Size = New System.Drawing.Size(105, 17)
        Me.rddokter.TabIndex = 66
        Me.rddokter.Text = "Group per dokter"
        Me.rddokter.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(125, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 13)
        Me.Label1.TabIndex = 65
        Me.Label1.Text = "s/d"
        '
        'dtakhir
        '
        Me.dtakhir.AccessibleDescription = "d"
        Me.dtakhir.CustomFormat = "dd-MMM-yyyy"
        Me.dtakhir.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtakhir.Location = New System.Drawing.Point(154, 17)
        Me.dtakhir.Name = "dtakhir"
        Me.dtakhir.Size = New System.Drawing.Size(107, 20)
        Me.dtakhir.TabIndex = 64
        '
        'butdisplay
        '
        Me.butdisplay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butdisplay.Location = New System.Drawing.Point(434, 17)
        Me.butdisplay.Name = "butdisplay"
        Me.butdisplay.Size = New System.Drawing.Size(75, 23)
        Me.butdisplay.TabIndex = 6
        Me.butdisplay.Text = "Display"
        Me.butdisplay.UseVisualStyleBackColor = True
        '
        'dtawal
        '
        Me.dtawal.CustomFormat = "dd-MMM-yyyy"
        Me.dtawal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtawal.Location = New System.Drawing.Point(12, 17)
        Me.dtawal.Name = "dtawal"
        Me.dtawal.Size = New System.Drawing.Size(107, 20)
        Me.dtawal.TabIndex = 63
        '
        'rdtanggal
        '
        Me.rdtanggal.AutoSize = True
        Me.rdtanggal.Checked = True
        Me.rdtanggal.Location = New System.Drawing.Point(6, 43)
        Me.rdtanggal.Name = "rdtanggal"
        Me.rdtanggal.Size = New System.Drawing.Size(110, 17)
        Me.rdtanggal.TabIndex = 0
        Me.rdtanggal.TabStop = True
        Me.rdtanggal.Text = "Group per tanggal"
        Me.rdtanggal.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.gridtindakan)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 92)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(515, 237)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Data Dokter"
        '
        'gridtindakan
        '
        Me.gridtindakan.Dock = System.Windows.Forms.DockStyle.Fill
        '
        '
        '
        Me.gridtindakan.EmbeddedNavigator.Name = ""
        Me.gridtindakan.Location = New System.Drawing.Point(3, 16)
        Me.gridtindakan.MainView = Me.GridView1
        Me.gridtindakan.Name = "gridtindakan"
        Me.gridtindakan.Size = New System.Drawing.Size(509, 218)
        Me.gridtindakan.TabIndex = 2
        Me.gridtindakan.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.gridtindakan
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        '
        'ReportDokter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(515, 329)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Name = "ReportDokter"
        Me.Text = "Lap Jumlah Pasien Per Dokter"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.gridtindakan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents dtawal As System.Windows.Forms.DateTimePicker
    Friend WithEvents rdtanggal As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents butdisplay As System.Windows.Forms.Button
    Friend WithEvents gridtindakan As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtakhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents rddokter As System.Windows.Forms.RadioButton
End Class
