<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RepairDetailTindakan
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmbtindakan = New System.Windows.Forms.ComboBox
        Me.butaddpasien = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.rd1 = New System.Windows.Forms.RadioButton
        Me.rd2 = New System.Windows.Forms.RadioButton
        Me.rd3 = New System.Windows.Forms.RadioButton
        Me.dtdelete = New System.Windows.Forms.DateTimePicker
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GridControl1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(3, 77)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(318, 348)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detail"
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
        Me.GridControl1.Size = New System.Drawing.Size(312, 329)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbtindakan)
        Me.GroupBox2.Controls.Add(Me.butaddpasien)
        Me.GroupBox2.Controls.Add(Me.GroupBox1)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(324, 428)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Add Pasien"
        '
        'cmbtindakan
        '
        Me.cmbtindakan.FormattingEnabled = True
        Me.cmbtindakan.Items.AddRange(New Object() {"LAB", "POLI", "GIGI"})
        Me.cmbtindakan.Location = New System.Drawing.Point(12, 19)
        Me.cmbtindakan.Name = "cmbtindakan"
        Me.cmbtindakan.Size = New System.Drawing.Size(172, 21)
        Me.cmbtindakan.TabIndex = 3
        '
        'butaddpasien
        '
        Me.butaddpasien.Location = New System.Drawing.Point(12, 48)
        Me.butaddpasien.Name = "butaddpasien"
        Me.butaddpasien.Size = New System.Drawing.Size(75, 23)
        Me.butaddpasien.TabIndex = 2
        Me.butaddpasien.Text = "Add Pasien"
        Me.butaddpasien.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(330, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Execute"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'rd1
        '
        Me.rd1.AutoSize = True
        Me.rd1.Location = New System.Drawing.Point(330, 51)
        Me.rd1.Name = "rd1"
        Me.rd1.Size = New System.Drawing.Size(260, 17)
        Me.rd1.TabIndex = 4
        Me.rd1.TabStop = True
        Me.rd1.Text = "Add Tindakan Kosong ( Detail Lab terlambat diisi )"
        Me.rd1.UseVisualStyleBackColor = True
        '
        'rd2
        '
        Me.rd2.AutoSize = True
        Me.rd2.Location = New System.Drawing.Point(330, 77)
        Me.rd2.Name = "rd2"
        Me.rd2.Size = New System.Drawing.Size(283, 17)
        Me.rd2.TabIndex = 5
        Me.rd2.TabStop = True
        Me.rd2.Text = "Update Nilai Normal, Keterangan (jika ada), dan urutan"
        Me.rd2.UseVisualStyleBackColor = True
        '
        'rd3
        '
        Me.rd3.AutoSize = True
        Me.rd3.Location = New System.Drawing.Point(330, 102)
        Me.rd3.Name = "rd3"
        Me.rd3.Size = New System.Drawing.Size(189, 17)
        Me.rd3.TabIndex = 6
        Me.rd3.TabStop = True
        Me.rd3.Text = "Delete TransaksiLab per Tanggal :"
        Me.rd3.UseVisualStyleBackColor = True
        '
        'dtdelete
        '
        Me.dtdelete.CustomFormat = "dd-MMM-yyyy"
        Me.dtdelete.Enabled = False
        Me.dtdelete.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtdelete.Location = New System.Drawing.Point(525, 100)
        Me.dtdelete.Name = "dtdelete"
        Me.dtdelete.Size = New System.Drawing.Size(107, 20)
        Me.dtdelete.TabIndex = 111
        '
        'RepairDetailTindakan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(918, 428)
        Me.Controls.Add(Me.dtdelete)
        Me.Controls.Add(Me.rd3)
        Me.Controls.Add(Me.rd2)
        Me.Controls.Add(Me.rd1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "RepairDetailTindakan"
        Me.Text = "RepairDetailTindakan"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Private WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents butaddpasien As System.Windows.Forms.Button
    Friend WithEvents cmbtindakan As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents rd1 As System.Windows.Forms.RadioButton
    Friend WithEvents rd2 As System.Windows.Forms.RadioButton
    Friend WithEvents rd3 As System.Windows.Forms.RadioButton
    Friend WithEvents dtdelete As System.Windows.Forms.DateTimePicker
End Class
