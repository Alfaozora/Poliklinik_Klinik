<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MasterPaket
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.KalkulasiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txharga = New System.Windows.Forms.TextBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.txjumlahorang = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.chkclosed = New System.Windows.Forms.CheckBox
        Me.dtend = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtstart = New System.Windows.Forms.DateTimePicker
        Me.txnamapaket = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tabklinik = New System.Windows.Forms.TabPage
        Me.gridklinik = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.tablab = New System.Windows.Forms.TabPage
        Me.gridlab = New DevExpress.XtraGrid.GridControl
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.tabgigi = New System.Windows.Forms.TabPage
        Me.gridgigi = New DevExpress.XtraGrid.GridControl
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.butpaketid = New System.Windows.Forms.TextBox
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tabklinik.SuspendLayout()
        CType(Me.gridklinik, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tablab.SuspendLayout()
        CType(Me.gridlab, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabgigi.SuspendLayout()
        CType(Me.gridgigi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.SaveToolStripMenuItem, Me.KalkulasiToolStripMenuItem, Me.CloseToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(865, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'KalkulasiToolStripMenuItem
        '
        Me.KalkulasiToolStripMenuItem.Name = "KalkulasiToolStripMenuItem"
        Me.KalkulasiToolStripMenuItem.Size = New System.Drawing.Size(65, 20)
        Me.KalkulasiToolStripMenuItem.Text = "Kalkulasi"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.butpaketid)
        Me.GroupBox1.Controls.Add(Me.txharga)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txjumlahorang)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.chkclosed)
        Me.GroupBox1.Controls.Add(Me.dtend)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtstart)
        Me.GroupBox1.Controls.Add(Me.txnamapaket)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label30)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(865, 79)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'txharga
        '
        Me.txharga.Location = New System.Drawing.Point(729, 19)
        Me.txharga.Name = "txharga"
        Me.txharga.Size = New System.Drawing.Size(83, 20)
        Me.txharga.TabIndex = 125
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(397, 45)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 121
        Me.Button3.Text = "Kalkulasi"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Enabled = False
        Me.Label5.Location = New System.Drawing.Point(654, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 13)
        Me.Label5.TabIndex = 124
        Me.Label5.Text = "Jumlah Biaya"
        '
        'txjumlahorang
        '
        Me.txjumlahorang.Location = New System.Drawing.Point(596, 19)
        Me.txjumlahorang.Name = "txjumlahorang"
        Me.txjumlahorang.Size = New System.Drawing.Size(42, 20)
        Me.txjumlahorang.TabIndex = 123
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Enabled = False
        Me.Label4.Location = New System.Drawing.Point(518, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 13)
        Me.Label4.TabIndex = 122
        Me.Label4.Text = "Jumlah Orang"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(154, 17)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(31, 23)
        Me.Button2.TabIndex = 121
        Me.Button2.Text = "..."
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(737, 45)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 120
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'chkclosed
        '
        Me.chkclosed.AutoSize = True
        Me.chkclosed.Location = New System.Drawing.Point(333, 45)
        Me.chkclosed.Name = "chkclosed"
        Me.chkclosed.Size = New System.Drawing.Size(58, 17)
        Me.chkclosed.TabIndex = 119
        Me.chkclosed.Text = "Closed"
        Me.chkclosed.UseVisualStyleBackColor = True
        '
        'dtend
        '
        Me.dtend.CustomFormat = "dd-MMM-yyyy"
        Me.dtend.Enabled = False
        Me.dtend.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtend.Location = New System.Drawing.Point(220, 45)
        Me.dtend.Name = "dtend"
        Me.dtend.Size = New System.Drawing.Size(107, 20)
        Me.dtend.TabIndex = 118
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Enabled = False
        Me.Label1.Location = New System.Drawing.Point(191, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 13)
        Me.Label1.TabIndex = 117
        Me.Label1.Text = "s/d"
        '
        'dtstart
        '
        Me.dtstart.CustomFormat = "dd-MMM-yyyy"
        Me.dtstart.Enabled = False
        Me.dtstart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtstart.Location = New System.Drawing.Point(78, 45)
        Me.dtstart.Name = "dtstart"
        Me.dtstart.Size = New System.Drawing.Size(107, 20)
        Me.dtstart.TabIndex = 116
        '
        'txnamapaket
        '
        Me.txnamapaket.Enabled = False
        Me.txnamapaket.Location = New System.Drawing.Point(258, 19)
        Me.txnamapaket.Name = "txnamapaket"
        Me.txnamapaket.Size = New System.Drawing.Size(254, 20)
        Me.txnamapaket.TabIndex = 115
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Enabled = False
        Me.Label3.Location = New System.Drawing.Point(24, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 114
        Me.Label3.Text = "Tgl Awal"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Enabled = False
        Me.Label2.Location = New System.Drawing.Point(186, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 113
        Me.Label2.Text = "Nama Paket"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Enabled = False
        Me.Label30.Location = New System.Drawing.Point(23, 22)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(49, 13)
        Me.Label30.TabIndex = 112
        Me.Label30.Text = "Paket ID"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tabklinik)
        Me.TabControl1.Controls.Add(Me.tablab)
        Me.TabControl1.Controls.Add(Me.tabgigi)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 103)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(865, 409)
        Me.TabControl1.TabIndex = 0
        '
        'tabklinik
        '
        Me.tabklinik.Controls.Add(Me.gridklinik)
        Me.tabklinik.Location = New System.Drawing.Point(4, 22)
        Me.tabklinik.Name = "tabklinik"
        Me.tabklinik.Padding = New System.Windows.Forms.Padding(3)
        Me.tabklinik.Size = New System.Drawing.Size(857, 383)
        Me.tabklinik.TabIndex = 0
        Me.tabklinik.Text = "Klinik"
        Me.tabklinik.UseVisualStyleBackColor = True
        '
        'gridklinik
        '
        Me.gridklinik.Dock = System.Windows.Forms.DockStyle.Fill
        '
        '
        '
        Me.gridklinik.EmbeddedNavigator.Name = ""
        Me.gridklinik.Location = New System.Drawing.Point(3, 3)
        Me.gridklinik.MainView = Me.GridView1
        Me.gridklinik.Name = "gridklinik"
        Me.gridklinik.Size = New System.Drawing.Size(851, 377)
        Me.gridklinik.TabIndex = 0
        Me.gridklinik.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.gridklinik
        Me.GridView1.Name = "GridView1"
        '
        'tablab
        '
        Me.tablab.Controls.Add(Me.gridlab)
        Me.tablab.Location = New System.Drawing.Point(4, 22)
        Me.tablab.Name = "tablab"
        Me.tablab.Padding = New System.Windows.Forms.Padding(3)
        Me.tablab.Size = New System.Drawing.Size(857, 383)
        Me.tablab.TabIndex = 1
        Me.tablab.Text = "Lab"
        Me.tablab.UseVisualStyleBackColor = True
        '
        'gridlab
        '
        Me.gridlab.Dock = System.Windows.Forms.DockStyle.Fill
        '
        '
        '
        Me.gridlab.EmbeddedNavigator.Name = ""
        Me.gridlab.Location = New System.Drawing.Point(3, 3)
        Me.gridlab.MainView = Me.GridView2
        Me.gridlab.Name = "gridlab"
        Me.gridlab.Size = New System.Drawing.Size(851, 377)
        Me.gridlab.TabIndex = 1
        Me.gridlab.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.gridlab
        Me.GridView2.Name = "GridView2"
        '
        'tabgigi
        '
        Me.tabgigi.Controls.Add(Me.gridgigi)
        Me.tabgigi.Location = New System.Drawing.Point(4, 22)
        Me.tabgigi.Name = "tabgigi"
        Me.tabgigi.Size = New System.Drawing.Size(857, 383)
        Me.tabgigi.TabIndex = 2
        Me.tabgigi.Text = "Gigi"
        Me.tabgigi.UseVisualStyleBackColor = True
        '
        'gridgigi
        '
        Me.gridgigi.Dock = System.Windows.Forms.DockStyle.Fill
        '
        '
        '
        Me.gridgigi.EmbeddedNavigator.Name = ""
        Me.gridgigi.Location = New System.Drawing.Point(0, 0)
        Me.gridgigi.MainView = Me.GridView3
        Me.gridgigi.Name = "gridgigi"
        Me.gridgigi.Size = New System.Drawing.Size(857, 383)
        Me.gridgigi.TabIndex = 1
        Me.gridgigi.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.gridgigi
        Me.GridView3.Name = "GridView3"
        '
        'butpaketid
        '
        Me.butpaketid.Location = New System.Drawing.Point(78, 19)
        Me.butpaketid.Name = "butpaketid"
        Me.butpaketid.Size = New System.Drawing.Size(70, 20)
        Me.butpaketid.TabIndex = 126
        '
        'MasterPaket
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(865, 512)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MasterPaket"
        Me.Text = "MasterPaket"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.tabklinik.ResumeLayout(False)
        CType(Me.gridklinik, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tablab.ResumeLayout(False)
        CType(Me.gridlab, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabgigi.ResumeLayout(False)
        CType(Me.gridgigi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabklinik As System.Windows.Forms.TabPage
    Friend WithEvents tablab As System.Windows.Forms.TabPage
    Friend WithEvents tabgigi As System.Windows.Forms.TabPage
    Friend WithEvents dtstart As System.Windows.Forms.DateTimePicker
    Friend WithEvents txnamapaket As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    'Friend WithEvents butpaketid As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents dtend As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkclosed As System.Windows.Forms.CheckBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents txjumlahorang As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents KalkulasiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txharga As System.Windows.Forms.TextBox
    Friend WithEvents butpaketid As System.Windows.Forms.TextBox
    Private WithEvents gridklinik As DevExpress.XtraGrid.GridControl
    Private WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents gridlab As DevExpress.XtraGrid.GridControl
    Private WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents gridgigi As DevExpress.XtraGrid.GridControl
    Private WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
