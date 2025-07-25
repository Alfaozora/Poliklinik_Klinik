<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MonitorProcessPrint
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MonitorProcessPrint))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.dtprocess = New System.Windows.Forms.DateTimePicker
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GridProses = New System.Windows.Forms.DataGridView
        Me.Button1 = New System.Windows.Forms.Button
        Me.rd2 = New System.Windows.Forms.RadioButton
        Me.rd1 = New System.Windows.Forms.RadioButton
        Me.Label1 = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.ClearToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NoLab = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Nama = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Pemeriksaan = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CaraAmbil = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Company = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusHardcopy = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusSoftcopy = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Printed = New System.Windows.Forms.DataGridViewButtonColumn
        Me.Sending = New System.Windows.Forms.DataGridViewButtonColumn
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.GridProses, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.rd2)
        Me.GroupBox1.Controls.Add(Me.rd1)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.dtprocess)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(984, 66)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(91, 16)
        Me.Label9.TabIndex = 229
        Me.Label9.Text = "Tgl Transaksi"
        '
        'dtprocess
        '
        Me.dtprocess.CalendarFont = New System.Drawing.Font("Arial Narrow", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtprocess.CustomFormat = "dd-MMM-yyyy"
        Me.dtprocess.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtprocess.Location = New System.Drawing.Point(109, 19)
        Me.dtprocess.Name = "dtprocess"
        Me.dtprocess.Size = New System.Drawing.Size(109, 20)
        Me.dtprocess.TabIndex = 108
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.GridProses)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 90)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(984, 374)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'GridProses
        '
        Me.GridProses.AllowUserToAddRows = False
        Me.GridProses.AllowUserToDeleteRows = False
        Me.GridProses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridProses.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.NoLab, Me.ID, Me.Nama, Me.Pemeriksaan, Me.CaraAmbil, Me.Company, Me.StatusHardcopy, Me.StatusSoftcopy, Me.Printed, Me.Sending})
        Me.GridProses.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridProses.Location = New System.Drawing.Point(3, 16)
        Me.GridProses.Name = "GridProses"
        Me.GridProses.Size = New System.Drawing.Size(978, 355)
        Me.GridProses.TabIndex = 150
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(515, 18)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(110, 22)
        Me.Button1.TabIndex = 1
        Me.Button1.UseVisualStyleBackColor = True
        '
        'rd2
        '
        Me.rd2.AutoSize = True
        Me.rd2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rd2.Location = New System.Drawing.Point(426, 20)
        Me.rd2.Name = "rd2"
        Me.rd2.Size = New System.Drawing.Size(71, 19)
        Me.rd2.TabIndex = 244
        Me.rd2.TabStop = True
        Me.rd2.Text = "Softcopy"
        Me.rd2.UseVisualStyleBackColor = True
        '
        'rd1
        '
        Me.rd1.AutoSize = True
        Me.rd1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rd1.Location = New System.Drawing.Point(343, 20)
        Me.rd1.Name = "rd1"
        Me.rd1.Size = New System.Drawing.Size(77, 19)
        Me.rd1.TabIndex = 245
        Me.rd1.TabStop = True
        Me.rd1.Text = "Hardcopy"
        Me.rd1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(258, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 16)
        Me.Label1.TabIndex = 246
        Me.Label1.Text = "Jenis Kirim"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ClearToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(984, 24)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ClearToolStripMenuItem
        '
        Me.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem"
        Me.ClearToolStripMenuItem.Size = New System.Drawing.Size(46, 20)
        Me.ClearToolStripMenuItem.Text = "Clear"
        '
        'NoLab
        '
        Me.NoLab.HeaderText = "No Lab"
        Me.NoLab.Name = "NoLab"
        Me.NoLab.ReadOnly = True
        '
        'ID
        '
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        '
        'Nama
        '
        Me.Nama.HeaderText = "Nama"
        Me.Nama.Name = "Nama"
        Me.Nama.ReadOnly = True
        Me.Nama.Width = 150
        '
        'Pemeriksaan
        '
        Me.Pemeriksaan.HeaderText = "Pemeriksaan"
        Me.Pemeriksaan.Name = "Pemeriksaan"
        Me.Pemeriksaan.ReadOnly = True
        Me.Pemeriksaan.Width = 190
        '
        'CaraAmbil
        '
        Me.CaraAmbil.HeaderText = "Cara Ambil"
        Me.CaraAmbil.Name = "CaraAmbil"
        Me.CaraAmbil.ReadOnly = True
        Me.CaraAmbil.Width = 150
        '
        'Company
        '
        Me.Company.HeaderText = "Company"
        Me.Company.Name = "Company"
        Me.Company.ReadOnly = True
        Me.Company.Width = 150
        '
        'StatusHardcopy
        '
        Me.StatusHardcopy.HeaderText = "Status Proses"
        Me.StatusHardcopy.Name = "StatusHardcopy"
        Me.StatusHardcopy.ReadOnly = True
        Me.StatusHardcopy.Width = 95
        '
        'StatusSoftcopy
        '
        Me.StatusSoftcopy.HeaderText = "Status Kirim Softcopy"
        Me.StatusSoftcopy.Name = "StatusSoftcopy"
        Me.StatusSoftcopy.ReadOnly = True
        Me.StatusSoftcopy.Visible = False
        Me.StatusSoftcopy.Width = 70
        '
        'Printed
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.DeepSkyBlue
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Salmon
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        Me.Printed.DefaultCellStyle = DataGridViewCellStyle3
        Me.Printed.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Printed.HeaderText = "Cetak"
        Me.Printed.Name = "Printed"
        Me.Printed.Text = "Print"
        Me.Printed.ToolTipText = "Print"
        Me.Printed.UseColumnTextForButtonValue = True
        '
        'Sending
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Mighty Brush", 8.249999!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Sending.DefaultCellStyle = DataGridViewCellStyle4
        Me.Sending.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Sending.HeaderText = "Sending"
        Me.Sending.Name = "Sending"
        Me.Sending.Text = "Send"
        Me.Sending.ToolTipText = "Send"
        Me.Sending.UseColumnTextForButtonValue = True
        Me.Sending.Visible = False
        Me.Sending.Width = 50
        '
        'MonitorProcessPrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 464)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MonitorProcessPrint"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Transaksi Laboratorium Hardcopy & Softcopy"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.GridProses, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dtprocess As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GridProses As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rd2 As System.Windows.Forms.RadioButton
    Friend WithEvents rd1 As System.Windows.Forms.RadioButton
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ClearToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NoLab As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nama As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Pemeriksaan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CaraAmbil As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Company As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusHardcopy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusSoftcopy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Printed As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents Sending As System.Windows.Forms.DataGridViewButtonColumn
End Class
