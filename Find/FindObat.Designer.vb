<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FindObat
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FindObat))
        Me.PanelTop = New System.Windows.Forms.Panel
        Me.btnClose = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LabelLoading = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBoxKomponenObat = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBoxNamaObat = New System.Windows.Forms.TextBox
        Me.ButtonFindObat = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.GridPencarian = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.Label3 = New System.Windows.Forms.Label
        Me.GridObatDPHO = New System.Windows.Forms.DataGridView
        Me.BGWorkerAutoFill = New System.ComponentModel.BackgroundWorker
        Me.TimerBlink = New System.Windows.Forms.Timer(Me.components)
        Me.PanelTop.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.GridPencarian, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.GridObatDPHO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.PanelTop.Controls.Add(Me.btnClose)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(798, 35)
        Me.PanelTop.TabIndex = 5
        '
        'btnClose
        '
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(758, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(40, 35)
        Me.btnClose.TabIndex = 281
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.LabelLoading)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.TextBoxKomponenObat)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.TextBoxNamaObat)
        Me.Panel1.Controls.Add(Me.ButtonFindObat)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 35)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(798, 132)
        Me.Panel1.TabIndex = 6
        '
        'LabelLoading
        '
        Me.LabelLoading.AutoSize = True
        Me.LabelLoading.BackColor = System.Drawing.Color.Transparent
        Me.LabelLoading.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelLoading.ForeColor = System.Drawing.SystemColors.GrayText
        Me.LabelLoading.Location = New System.Drawing.Point(520, 54)
        Me.LabelLoading.Name = "LabelLoading"
        Me.LabelLoading.Size = New System.Drawing.Size(148, 17)
        Me.LabelLoading.TabIndex = 442
        Me.LabelLoading.Text = "Memuat daftar obat ......"
        Me.LabelLoading.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(30, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 17)
        Me.Label1.TabIndex = 441
        Me.Label1.Text = "Nama Obat"
        '
        'TextBoxKomponenObat
        '
        Me.TextBoxKomponenObat.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TextBoxKomponenObat.Location = New System.Drawing.Point(185, 54)
        Me.TextBoxKomponenObat.Name = "TextBoxKomponenObat"
        Me.TextBoxKomponenObat.Size = New System.Drawing.Size(282, 25)
        Me.TextBoxKomponenObat.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(30, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 17)
        Me.Label2.TabIndex = 432
        Me.Label2.Text = "Komponen Obat"
        '
        'TextBoxNamaObat
        '
        Me.TextBoxNamaObat.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TextBoxNamaObat.Location = New System.Drawing.Point(185, 19)
        Me.TextBoxNamaObat.Name = "TextBoxNamaObat"
        Me.TextBoxNamaObat.Size = New System.Drawing.Size(282, 25)
        Me.TextBoxNamaObat.TabIndex = 1
        '
        'ButtonFindObat
        '
        Me.ButtonFindObat.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindObat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonFindObat.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonFindObat.FlatAppearance.BorderSize = 0
        Me.ButtonFindObat.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindObat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonFindObat.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonFindObat.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonFindObat.ForeColor = System.Drawing.Color.White
        Me.ButtonFindObat.Location = New System.Drawing.Point(185, 85)
        Me.ButtonFindObat.Name = "ButtonFindObat"
        Me.ButtonFindObat.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonFindObat.Size = New System.Drawing.Size(282, 30)
        Me.ButtonFindObat.TabIndex = 429
        Me.ButtonFindObat.Text = "Cari Data"
        Me.ButtonFindObat.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonFindObat.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.Controls.Add(Me.SplitContainer1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 167)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(798, 331)
        Me.Panel2.TabIndex = 7
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GridPencarian)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(798, 331)
        Me.SplitContainer1.SplitterDistance = 170
        Me.SplitContainer1.TabIndex = 0
        '
        'GridPencarian
        '
        Me.GridPencarian.Cursor = System.Windows.Forms.Cursors.Hand
        Me.GridPencarian.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridPencarian.EmbeddedNavigator.Name = ""
        Me.GridPencarian.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridPencarian.Location = New System.Drawing.Point(0, 0)
        Me.GridPencarian.MainView = Me.GridView1
        Me.GridPencarian.Name = "GridPencarian"
        Me.GridPencarian.Size = New System.Drawing.Size(798, 170)
        Me.GridPencarian.TabIndex = 3
        Me.GridPencarian.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridPencarian
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsCustomization.AllowGroup = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowForFocusedRow
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label3)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.GridObatDPHO)
        Me.SplitContainer2.Size = New System.Drawing.Size(798, 157)
        Me.SplitContainer2.SplitterDistance = 25
        Me.SplitContainer2.TabIndex = 0
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(176, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(413, 17)
        Me.Label3.TabIndex = 433
        Me.Label3.Text = "Obat Untuk Keperluan Bridging pasien BPJS, Silahkan Centang Saja"
        '
        'GridObatDPHO
        '
        Me.GridObatDPHO.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.GridObatDPHO.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.GridObatDPHO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.GridObatDPHO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridObatDPHO.Location = New System.Drawing.Point(0, 0)
        Me.GridObatDPHO.Name = "GridObatDPHO"
        Me.GridObatDPHO.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.GridObatDPHO.Size = New System.Drawing.Size(798, 128)
        Me.GridObatDPHO.TabIndex = 0
        '
        'BGWorkerAutoFill
        '
        '
        'TimerBlink
        '
        Me.TimerBlink.Interval = 800
        '
        'FindObat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(798, 498)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PanelTop)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FindObat"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.PanelTop.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.GridPencarian, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.GridObatDPHO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents ButtonFindObat As System.Windows.Forms.Button
    Friend WithEvents TextBoxNamaObat As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxKomponenObat As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents GridPencarian As DevExpress.XtraGrid.GridControl
    Private WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GridObatDPHO As System.Windows.Forms.DataGridView
    Friend WithEvents BGWorkerAutoFill As System.ComponentModel.BackgroundWorker
    Friend WithEvents LabelLoading As System.Windows.Forms.Label
    Friend WithEvents TimerBlink As System.Windows.Forms.Timer
End Class
