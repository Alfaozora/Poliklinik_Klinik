<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportLabPendapatanHarianDetail
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
        Me.txketerangan = New System.Windows.Forms.TextBox
        Me.chkadmin = New System.Windows.Forms.CheckBox
        Me.chkgigi = New System.Windows.Forms.CheckBox
        Me.chkpoli = New System.Windows.Forms.CheckBox
        Me.chklab = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtakhir = New System.Windows.Forms.DateTimePicker
        Me.dtawal = New System.Windows.Forms.DateTimePicker
        Me.butdisplay = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txketerangan)
        Me.GroupBox1.Controls.Add(Me.dtakhir)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.dtawal)
        Me.GroupBox1.Controls.Add(Me.chkadmin)
        Me.GroupBox1.Controls.Add(Me.chkgigi)
        Me.GroupBox1.Controls.Add(Me.chkpoli)
        Me.GroupBox1.Controls.Add(Me.butdisplay)
        Me.GroupBox1.Controls.Add(Me.chklab)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 45)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1030, 75)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Jenis Transaksi"
        '
        'txketerangan
        '
        Me.txketerangan.Enabled = False
        Me.txketerangan.Location = New System.Drawing.Point(12, 65)
        Me.txketerangan.Name = "txketerangan"
        Me.txketerangan.Size = New System.Drawing.Size(100, 20)
        Me.txketerangan.TabIndex = 11
        Me.txketerangan.Visible = False
        '
        'chkadmin
        '
        Me.chkadmin.AutoSize = True
        Me.chkadmin.Location = New System.Drawing.Point(12, 19)
        Me.chkadmin.Name = "chkadmin"
        Me.chkadmin.Size = New System.Drawing.Size(104, 17)
        Me.chkadmin.TabIndex = 6
        Me.chkadmin.Text = "Transaksi Admin"
        Me.chkadmin.UseVisualStyleBackColor = True
        '
        'chkgigi
        '
        Me.chkgigi.AutoSize = True
        Me.chkgigi.Location = New System.Drawing.Point(139, 42)
        Me.chkgigi.Name = "chkgigi"
        Me.chkgigi.Size = New System.Drawing.Size(93, 17)
        Me.chkgigi.TabIndex = 5
        Me.chkgigi.Text = "Transaksi Gigi"
        Me.chkgigi.UseVisualStyleBackColor = True
        '
        'chkpoli
        '
        Me.chkpoli.AutoSize = True
        Me.chkpoli.Location = New System.Drawing.Point(12, 42)
        Me.chkpoli.Name = "chkpoli"
        Me.chkpoli.Size = New System.Drawing.Size(92, 17)
        Me.chkpoli.TabIndex = 3
        Me.chkpoli.Text = "Transaksi Poli"
        Me.chkpoli.UseVisualStyleBackColor = True
        '
        'chklab
        '
        Me.chklab.AutoSize = True
        Me.chklab.Location = New System.Drawing.Point(139, 19)
        Me.chklab.Name = "chklab"
        Me.chklab.Size = New System.Drawing.Size(93, 17)
        Me.chklab.TabIndex = 4
        Me.chklab.Text = "Transaksi Lab"
        Me.chklab.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(500, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 13)
        Me.Label1.TabIndex = 65
        Me.Label1.Text = "s/d"
        '
        'dtakhir
        '
        Me.dtakhir.CustomFormat = "dd-MMM-yyyy"
        Me.dtakhir.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtakhir.Location = New System.Drawing.Point(529, 19)
        Me.dtakhir.Name = "dtakhir"
        Me.dtakhir.Size = New System.Drawing.Size(107, 20)
        Me.dtakhir.TabIndex = 64
        '
        'dtawal
        '
        Me.dtawal.CustomFormat = "dd-MMM-yyyy"
        Me.dtawal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtawal.Location = New System.Drawing.Point(387, 19)
        Me.dtawal.Name = "dtawal"
        Me.dtawal.Size = New System.Drawing.Size(107, 20)
        Me.dtawal.TabIndex = 63
        '
        'butdisplay
        '
        Me.butdisplay.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butdisplay.Location = New System.Drawing.Point(664, 18)
        Me.butdisplay.Name = "butdisplay"
        Me.butdisplay.Size = New System.Drawing.Size(75, 23)
        Me.butdisplay.TabIndex = 10
        Me.butdisplay.Text = "Display"
        Me.butdisplay.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1030, 45)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 17)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Label2"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(745, 18)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 12
        Me.Button1.Text = "Export .xls"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(288, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 66
        Me.Label3.Text = "Periode Tanggal :"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.GridControl1)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(0, 120)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1030, 431)
        Me.GroupBox3.TabIndex = 12
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Detail"
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
        Me.GridControl1.Size = New System.Drawing.Size(1024, 412)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        '
        'ReportLabPendapatanHarianDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1030, 551)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "ReportLabPendapatanHarianDetail"
        Me.Text = "ReportLabPendapatanHarianDetail"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkadmin As System.Windows.Forms.CheckBox
    Friend WithEvents chkgigi As System.Windows.Forms.CheckBox
    Friend WithEvents chkpoli As System.Windows.Forms.CheckBox
    Friend WithEvents chklab As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtakhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtawal As System.Windows.Forms.DateTimePicker
    Friend WithEvents butdisplay As System.Windows.Forms.Button
    Friend WithEvents txketerangan As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Private WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Private WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
