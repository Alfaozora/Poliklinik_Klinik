<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormKirimLaporanOmset
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormKirimLaporanOmset))
        Me.DateTimePickerTanggalTransaksi = New System.Windows.Forms.DateTimePicker
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ButtonKirimJurnalUlang = New System.Windows.Forms.Button
        Me.ButtonKirimDataOmset = New System.Windows.Forms.Button
        Me.ButtonSearchDataOmset = New System.Windows.Forms.Button
        Me.ProgressBar2 = New System.Windows.Forms.ProgressBar
        Me.lblProgressBar = New System.Windows.Forms.Label
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.gridpoli = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.gridlab = New DevExpress.XtraGrid.GridControl
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.gridgigi = New DevExpress.XtraGrid.GridControl
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.griddll = New DevExpress.XtraGrid.GridControl
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.Button1 = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.gridpoli, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.gridlab, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.gridgigi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.griddll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DateTimePickerTanggalTransaksi
        '
        Me.DateTimePickerTanggalTransaksi.CalendarFont = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerTanggalTransaksi.CustomFormat = "dd-MMM-yyyy"
        Me.DateTimePickerTanggalTransaksi.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.DateTimePickerTanggalTransaksi.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerTanggalTransaksi.Location = New System.Drawing.Point(124, 23)
        Me.DateTimePickerTanggalTransaksi.Name = "DateTimePickerTanggalTransaksi"
        Me.DateTimePickerTanggalTransaksi.Size = New System.Drawing.Size(150, 23)
        Me.DateTimePickerTanggalTransaksi.TabIndex = 110
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.ButtonKirimJurnalUlang)
        Me.GroupBox1.Controls.Add(Me.ButtonKirimDataOmset)
        Me.GroupBox1.Controls.Add(Me.ButtonSearchDataOmset)
        Me.GroupBox1.Controls.Add(Me.ProgressBar2)
        Me.GroupBox1.Controls.Add(Me.lblProgressBar)
        Me.GroupBox1.Controls.Add(Me.ProgressBar1)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.DateTimePickerTanggalTransaksi)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(953, 125)
        Me.GroupBox1.TabIndex = 112
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Display"
        '
        'ButtonKirimJurnalUlang
        '
        Me.ButtonKirimJurnalUlang.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonKirimJurnalUlang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonKirimJurnalUlang.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonKirimJurnalUlang.FlatAppearance.BorderSize = 0
        Me.ButtonKirimJurnalUlang.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonKirimJurnalUlang.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonKirimJurnalUlang.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonKirimJurnalUlang.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonKirimJurnalUlang.ForeColor = System.Drawing.Color.White
        Me.ButtonKirimJurnalUlang.Image = CType(resources.GetObject("ButtonKirimJurnalUlang.Image"), System.Drawing.Image)
        Me.ButtonKirimJurnalUlang.Location = New System.Drawing.Point(336, 68)
        Me.ButtonKirimJurnalUlang.Name = "ButtonKirimJurnalUlang"
        Me.ButtonKirimJurnalUlang.Size = New System.Drawing.Size(150, 35)
        Me.ButtonKirimJurnalUlang.TabIndex = 519
        Me.ButtonKirimJurnalUlang.Text = " Kirim Jurnal Ulang"
        Me.ButtonKirimJurnalUlang.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonKirimJurnalUlang.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonKirimJurnalUlang.UseVisualStyleBackColor = False
        '
        'ButtonKirimDataOmset
        '
        Me.ButtonKirimDataOmset.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonKirimDataOmset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonKirimDataOmset.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonKirimDataOmset.FlatAppearance.BorderSize = 0
        Me.ButtonKirimDataOmset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonKirimDataOmset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonKirimDataOmset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonKirimDataOmset.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonKirimDataOmset.ForeColor = System.Drawing.Color.White
        Me.ButtonKirimDataOmset.Image = CType(resources.GetObject("ButtonKirimDataOmset.Image"), System.Drawing.Image)
        Me.ButtonKirimDataOmset.Location = New System.Drawing.Point(180, 67)
        Me.ButtonKirimDataOmset.Name = "ButtonKirimDataOmset"
        Me.ButtonKirimDataOmset.Size = New System.Drawing.Size(150, 35)
        Me.ButtonKirimDataOmset.TabIndex = 518
        Me.ButtonKirimDataOmset.Text = " Kirim Omset"
        Me.ButtonKirimDataOmset.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonKirimDataOmset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonKirimDataOmset.UseVisualStyleBackColor = False
        '
        'ButtonSearchDataOmset
        '
        Me.ButtonSearchDataOmset.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSearchDataOmset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonSearchDataOmset.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonSearchDataOmset.FlatAppearance.BorderSize = 0
        Me.ButtonSearchDataOmset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSearchDataOmset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonSearchDataOmset.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSearchDataOmset.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonSearchDataOmset.ForeColor = System.Drawing.Color.White
        Me.ButtonSearchDataOmset.Image = CType(resources.GetObject("ButtonSearchDataOmset.Image"), System.Drawing.Image)
        Me.ButtonSearchDataOmset.Location = New System.Drawing.Point(24, 68)
        Me.ButtonSearchDataOmset.Name = "ButtonSearchDataOmset"
        Me.ButtonSearchDataOmset.Size = New System.Drawing.Size(150, 35)
        Me.ButtonSearchDataOmset.TabIndex = 517
        Me.ButtonSearchDataOmset.Text = " Search Data"
        Me.ButtonSearchDataOmset.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonSearchDataOmset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonSearchDataOmset.UseVisualStyleBackColor = False
        '
        'ProgressBar2
        '
        Me.ProgressBar2.BackColor = System.Drawing.Color.Lime
        Me.ProgressBar2.Location = New System.Drawing.Point(24, 57)
        Me.ProgressBar2.Name = "ProgressBar2"
        Me.ProgressBar2.Size = New System.Drawing.Size(718, 5)
        Me.ProgressBar2.TabIndex = 235
        '
        'lblProgressBar
        '
        Me.lblProgressBar.AutoSize = True
        Me.lblProgressBar.BackColor = System.Drawing.SystemColors.Control
        Me.lblProgressBar.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProgressBar.Location = New System.Drawing.Point(543, 77)
        Me.lblProgressBar.Name = "lblProgressBar"
        Me.lblProgressBar.Size = New System.Drawing.Size(150, 18)
        Me.lblProgressBar.TabIndex = 233
        Me.lblProgressBar.Text = "Loading Upload Poli"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.BackColor = System.Drawing.SystemColors.ControlText
        Me.ProgressBar1.Location = New System.Drawing.Point(492, 68)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(250, 36)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(21, 27)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 17)
        Me.Label9.TabIndex = 229
        Me.Label9.Text = "Tgl Transaksi"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TabControl1)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 125)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(953, 380)
        Me.GroupBox2.TabIndex = 113
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detail"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.ItemSize = New System.Drawing.Size(150, 25)
        Me.TabControl1.Location = New System.Drawing.Point(3, 16)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(947, 361)
        Me.TabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.gridpoli)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(939, 328)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Poli"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'gridpoli
        '
        Me.gridpoli.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridpoli.EmbeddedNavigator.Name = ""
        Me.gridpoli.Location = New System.Drawing.Point(3, 3)
        Me.gridpoli.MainView = Me.GridView1
        Me.gridpoli.Name = "gridpoli"
        Me.gridpoli.Size = New System.Drawing.Size(933, 322)
        Me.gridpoli.TabIndex = 0
        Me.gridpoli.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.gridpoli
        Me.GridView1.Name = "GridView1"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.gridlab)
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(939, 328)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "LAB"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'gridlab
        '
        Me.gridlab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridlab.EmbeddedNavigator.Name = ""
        Me.gridlab.Location = New System.Drawing.Point(3, 3)
        Me.gridlab.MainView = Me.GridView2
        Me.gridlab.Name = "gridlab"
        Me.gridlab.Size = New System.Drawing.Size(933, 322)
        Me.gridlab.TabIndex = 1
        Me.gridlab.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.gridlab
        Me.GridView2.Name = "GridView2"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.gridgigi)
        Me.TabPage3.Location = New System.Drawing.Point(4, 29)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(939, 328)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Gigi"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'gridgigi
        '
        Me.gridgigi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridgigi.EmbeddedNavigator.Name = ""
        Me.gridgigi.Location = New System.Drawing.Point(3, 3)
        Me.gridgigi.MainView = Me.GridView3
        Me.gridgigi.Name = "gridgigi"
        Me.gridgigi.Size = New System.Drawing.Size(933, 322)
        Me.gridgigi.TabIndex = 1
        Me.gridgigi.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.gridgigi
        Me.GridView3.Name = "GridView3"
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.griddll)
        Me.TabPage4.Location = New System.Drawing.Point(4, 29)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(939, 328)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Dll"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'griddll
        '
        Me.griddll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.griddll.EmbeddedNavigator.Name = ""
        Me.griddll.Location = New System.Drawing.Point(3, 3)
        Me.griddll.MainView = Me.GridView4
        Me.griddll.Name = "griddll"
        Me.griddll.Size = New System.Drawing.Size(933, 322)
        Me.griddll.TabIndex = 1
        Me.griddll.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView4})
        '
        'GridView4
        '
        Me.GridView4.GridControl = Me.griddll
        Me.GridView4.Name = "GridView4"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(748, 67)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(150, 35)
        Me.Button1.TabIndex = 520
        Me.Button1.Text = " Cek Bug"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = False
        '
        'FormKirimLaporanOmset
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(953, 505)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormKirimLaporanOmset"
        Me.Text = "Form Kirim Laporan Omset"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.gridpoli, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        CType(Me.gridlab, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.gridgigi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        CType(Me.griddll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DateTimePickerTanggalTransaksi As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Private WithEvents gridpoli As DevExpress.XtraGrid.GridControl
    Private WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents gridlab As DevExpress.XtraGrid.GridControl
    Private WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents gridgigi As DevExpress.XtraGrid.GridControl
    Private WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents griddll As DevExpress.XtraGrid.GridControl
    Private WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents lblProgressBar As System.Windows.Forms.Label
    Friend WithEvents ProgressBar2 As System.Windows.Forms.ProgressBar
    Friend WithEvents ButtonSearchDataOmset As System.Windows.Forms.Button
    Friend WithEvents ButtonKirimDataOmset As System.Windows.Forms.Button
    Friend WithEvents ButtonKirimJurnalUlang As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
