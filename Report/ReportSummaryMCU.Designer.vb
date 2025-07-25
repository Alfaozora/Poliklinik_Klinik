<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportSummaryMCU
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportSummaryMCU))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.NewToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.gridpasien = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip
        Me.TambahPasienToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PilihCompanyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PilihTanggalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.txcompany = New System.Windows.Forms.ToolStripTextBox
        Me.txlbltanggal = New System.Windows.Forms.ToolStripTextBox
        Me.rdlain = New System.Windows.Forms.RadioButton
        Me.rdmcu = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rdheader = New System.Windows.Forms.RadioButton
        Me.gridtest = New DevExpress.XtraGrid.GridControl
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.gridresult = New DevExpress.XtraGrid.GridControl
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.TextBoxTglTransaksi = New System.Windows.Forms.TextBox
        Me.TextBoxNamaPerusahaan = New System.Windows.Forms.TextBox
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.gridpasien, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.gridtest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.gridresult, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem1, Me.PrintToolStripMenuItem, Me.CloseToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1018, 24)
        Me.MenuStrip1.TabIndex = 9
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'NewToolStripMenuItem1
        '
        Me.NewToolStripMenuItem1.Name = "NewToolStripMenuItem1"
        Me.NewToolStripMenuItem1.Size = New System.Drawing.Size(65, 20)
        Me.NewToolStripMenuItem1.Text = "Set Clear"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'CloseToolStripMenuItem1
        '
        Me.CloseToolStripMenuItem1.Name = "CloseToolStripMenuItem1"
        Me.CloseToolStripMenuItem1.Size = New System.Drawing.Size(48, 20)
        Me.CloseToolStripMenuItem1.Text = "Close"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.gridpasien)
        Me.GroupBox2.Controls.Add(Me.MenuStrip2)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(3, 16)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(698, 327)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Pasien yang ditampilkan"
        '
        'gridpasien
        '
        Me.gridpasien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridpasien.EmbeddedNavigator.Name = ""
        Me.gridpasien.Location = New System.Drawing.Point(3, 43)
        Me.gridpasien.MainView = Me.GridView1
        Me.gridpasien.Name = "gridpasien"
        Me.gridpasien.Size = New System.Drawing.Size(692, 281)
        Me.gridpasien.TabIndex = 3
        Me.gridpasien.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.gridpasien
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        '
        'MenuStrip2
        '
        Me.MenuStrip2.AllowMerge = False
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TambahPasienToolStripMenuItem, Me.PilihCompanyToolStripMenuItem, Me.PilihTanggalToolStripMenuItem, Me.txcompany, Me.txlbltanggal})
        Me.MenuStrip2.Location = New System.Drawing.Point(3, 16)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(692, 27)
        Me.MenuStrip2.TabIndex = 4
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'TambahPasienToolStripMenuItem
        '
        Me.TambahPasienToolStripMenuItem.Name = "TambahPasienToolStripMenuItem"
        Me.TambahPasienToolStripMenuItem.Size = New System.Drawing.Size(98, 23)
        Me.TambahPasienToolStripMenuItem.Text = "Tambah Pasien"
        '
        'PilihCompanyToolStripMenuItem
        '
        Me.PilihCompanyToolStripMenuItem.Name = "PilihCompanyToolStripMenuItem"
        Me.PilihCompanyToolStripMenuItem.Size = New System.Drawing.Size(97, 23)
        Me.PilihCompanyToolStripMenuItem.Text = "Pilih Company"
        '
        'PilihTanggalToolStripMenuItem
        '
        Me.PilihTanggalToolStripMenuItem.Name = "PilihTanggalToolStripMenuItem"
        Me.PilihTanggalToolStripMenuItem.Size = New System.Drawing.Size(86, 23)
        Me.PilihTanggalToolStripMenuItem.Text = "Pilih Tanggal"
        '
        'txcompany
        '
        Me.txcompany.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.txcompany.ForeColor = System.Drawing.SystemColors.Window
        Me.txcompany.Name = "txcompany"
        Me.txcompany.Size = New System.Drawing.Size(300, 23)
        '
        'txlbltanggal
        '
        Me.txlbltanggal.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.txlbltanggal.ForeColor = System.Drawing.SystemColors.Window
        Me.txlbltanggal.Name = "txlbltanggal"
        Me.txlbltanggal.Size = New System.Drawing.Size(100, 23)
        '
        'rdlain
        '
        Me.rdlain.AutoSize = True
        Me.rdlain.Location = New System.Drawing.Point(120, 17)
        Me.rdlain.Name = "rdlain"
        Me.rdlain.Size = New System.Drawing.Size(117, 17)
        Me.rdlain.TabIndex = 6
        Me.rdlain.TabStop = True
        Me.rdlain.Text = "Summary Hasil Lain"
        Me.rdlain.UseVisualStyleBackColor = True
        '
        'rdmcu
        '
        Me.rdmcu.AutoSize = True
        Me.rdmcu.Location = New System.Drawing.Point(6, 17)
        Me.rdmcu.Name = "rdmcu"
        Me.rdmcu.Size = New System.Drawing.Size(95, 17)
        Me.rdmcu.TabIndex = 5
        Me.rdmcu.TabStop = True
        Me.rdmcu.Text = "Summary MCU"
        Me.rdmcu.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rdheader)
        Me.GroupBox1.Controls.Add(Me.rdlain)
        Me.GroupBox1.Controls.Add(Me.gridtest)
        Me.GroupBox1.Controls.Add(Me.rdmcu)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox1.Location = New System.Drawing.Point(701, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(314, 327)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tindakan yang ditampilkan"
        '
        'rdheader
        '
        Me.rdheader.AutoSize = True
        Me.rdheader.Location = New System.Drawing.Point(243, 17)
        Me.rdheader.Name = "rdheader"
        Me.rdheader.Size = New System.Drawing.Size(60, 17)
        Me.rdheader.TabIndex = 7
        Me.rdheader.TabStop = True
        Me.rdheader.Text = "Header"
        Me.rdheader.UseVisualStyleBackColor = True
        '
        'gridtest
        '
        Me.gridtest.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.gridtest.EmbeddedNavigator.Name = ""
        Me.gridtest.Location = New System.Drawing.Point(3, 40)
        Me.gridtest.MainView = Me.GridView2
        Me.gridtest.Name = "gridtest"
        Me.gridtest.Size = New System.Drawing.Size(308, 284)
        Me.gridtest.TabIndex = 3
        Me.gridtest.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.gridtest
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsCustomization.AllowFilter = False
        Me.GridView2.OptionsCustomization.AllowGroup = False
        Me.GridView2.OptionsView.ShowFilterPanel = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button2)
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox3.Location = New System.Drawing.Point(0, 652)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1018, 49)
        Me.GroupBox3.TabIndex = 12
        Me.GroupBox3.TabStop = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(783, 16)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 123
        Me.Button2.Text = "Export .xls"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(445, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 121
        Me.Button1.Text = "Display"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.GroupBox2)
        Me.GroupBox4.Controls.Add(Me.GroupBox1)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox4.Location = New System.Drawing.Point(0, 24)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1018, 346)
        Me.GroupBox4.TabIndex = 13
        Me.GroupBox4.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.gridresult)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox5.Location = New System.Drawing.Point(0, 370)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(1018, 282)
        Me.GroupBox5.TabIndex = 14
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Result Summary"
        '
        'gridresult
        '
        Me.gridresult.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridresult.EmbeddedNavigator.Name = ""
        Me.gridresult.Location = New System.Drawing.Point(3, 16)
        Me.gridresult.MainView = Me.GridView3
        Me.gridresult.Name = "gridresult"
        Me.gridresult.Size = New System.Drawing.Size(1012, 263)
        Me.gridresult.TabIndex = 4
        Me.gridresult.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.gridresult
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsCustomization.AllowFilter = False
        Me.GridView3.OptionsCustomization.AllowGroup = False
        Me.GridView3.OptionsView.ShowFilterPanel = False
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'TextBoxTglTransaksi
        '
        Me.TextBoxTglTransaksi.Location = New System.Drawing.Point(406, 3)
        Me.TextBoxTglTransaksi.Name = "TextBoxTglTransaksi"
        Me.TextBoxTglTransaksi.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxTglTransaksi.TabIndex = 15
        Me.TextBoxTglTransaksi.Visible = False
        '
        'TextBoxNamaPerusahaan
        '
        Me.TextBoxNamaPerusahaan.Location = New System.Drawing.Point(534, 2)
        Me.TextBoxNamaPerusahaan.Name = "TextBoxNamaPerusahaan"
        Me.TextBoxNamaPerusahaan.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxNamaPerusahaan.TabIndex = 16
        Me.TextBoxNamaPerusahaan.Visible = False
        '
        'ReportSummaryMCU
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1018, 701)
        Me.Controls.Add(Me.TextBoxNamaPerusahaan)
        Me.Controls.Add(Me.TextBoxTglTransaksi)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ReportSummaryMCU"
        Me.Text = "Summary Hasil MCU"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.gridpasien, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.gridtest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.gridresult, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents NewToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents TambahPasienToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents rdlain As System.Windows.Forms.RadioButton
    Friend WithEvents rdmcu As System.Windows.Forms.RadioButton
    Friend WithEvents rdheader As System.Windows.Forms.RadioButton
    Private WithEvents gridpasien As DevExpress.XtraGrid.GridControl
    Private WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents gridtest As DevExpress.XtraGrid.GridControl
    Private WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents gridresult As DevExpress.XtraGrid.GridControl
    Private WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PilihCompanyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PilihTanggalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txcompany As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents txlbltanggal As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents TextBoxTglTransaksi As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxNamaPerusahaan As System.Windows.Forms.TextBox
End Class
