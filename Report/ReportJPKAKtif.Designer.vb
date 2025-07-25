<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportJPKAktif
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txaktif = New System.Windows.Forms.Label
        Me.rd2 = New System.Windows.Forms.RadioButton
        Me.rd1 = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtaktif = New System.Windows.Forms.DateTimePicker
        Me.butok = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GridControl1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 103)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(865, 397)
        Me.GroupBox1.TabIndex = 5
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
        Me.GridControl1.Size = New System.Drawing.Size(859, 378)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsCustomization.AllowColumnMoving = False
        Me.GridView1.OptionsCustomization.AllowGroup = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowForFocusedRow
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txaktif)
        Me.GroupBox3.Controls.Add(Me.rd2)
        Me.GroupBox3.Controls.Add(Me.rd1)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.dtaktif)
        Me.GroupBox3.Controls.Add(Me.butok)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(865, 103)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        '
        'txaktif
        '
        Me.txaktif.AutoSize = True
        Me.txaktif.Location = New System.Drawing.Point(686, 78)
        Me.txaktif.Name = "txaktif"
        Me.txaktif.Size = New System.Drawing.Size(39, 13)
        Me.txaktif.TabIndex = 5
        Me.txaktif.Text = "Label2"
        '
        'rd2
        '
        Me.rd2.AutoSize = True
        Me.rd2.Location = New System.Drawing.Point(101, 46)
        Me.rd2.Name = "rd2"
        Me.rd2.Size = New System.Drawing.Size(91, 17)
        Me.rd2.TabIndex = 4
        Me.rd2.TabStop = True
        Me.rd2.Text = "JPK Non Aktif"
        Me.rd2.UseVisualStyleBackColor = True
        '
        'rd1
        '
        Me.rd1.AutoSize = True
        Me.rd1.Location = New System.Drawing.Point(18, 46)
        Me.rd1.Name = "rd1"
        Me.rd1.Size = New System.Drawing.Size(68, 17)
        Me.rd1.TabIndex = 3
        Me.rd1.TabStop = True
        Me.rd1.Text = "JPK Aktif"
        Me.rd1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Periode"
        '
        'dtaktif
        '
        Me.dtaktif.CustomFormat = "MMM-yyyy"
        Me.dtaktif.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtaktif.Location = New System.Drawing.Point(91, 19)
        Me.dtaktif.Name = "dtaktif"
        Me.dtaktif.Size = New System.Drawing.Size(100, 20)
        Me.dtaktif.TabIndex = 1
        '
        'butok
        '
        Me.butok.Location = New System.Drawing.Point(18, 73)
        Me.butok.Name = "butok"
        Me.butok.Size = New System.Drawing.Size(75, 23)
        Me.butok.TabIndex = 0
        Me.butok.Text = "Display"
        Me.butok.UseVisualStyleBackColor = True
        '
        'ReportJPKAktif
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(865, 500)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Name = "ReportJPKAktif"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Report JPKAktif"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents butok As System.Windows.Forms.Button
    Private WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Private WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents rd2 As System.Windows.Forms.RadioButton
    Friend WithEvents rd1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtaktif As System.Windows.Forms.DateTimePicker
    Friend WithEvents txaktif As System.Windows.Forms.Label
End Class
