<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MonitoringMCU
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MonitoringMCU))
        Me.gridlab = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.CheckBoxReverse = New System.Windows.Forms.CheckBox
        Me.cbfisik = New System.Windows.Forms.CheckBox
        Me.cbthorax = New System.Windows.Forms.CheckBox
        Me.cblab = New System.Windows.Forms.CheckBox
        Me.txNoUrut2 = New System.Windows.Forms.TextBox
        Me.cbNoUrut = New System.Windows.Forms.CheckBox
        Me.txNoUrut1 = New System.Windows.Forms.TextBox
        Me.cmbstatustransaksi = New System.Windows.Forms.ComboBox
        Me.txkodecabang = New System.Windows.Forms.TextBox
        Me.dtprocessend = New System.Windows.Forms.DateTimePicker
        Me.txidloc = New System.Windows.Forms.TextBox
        Me.txloc = New System.Windows.Forms.TextBox
        Me.txcompanycode = New System.Windows.Forms.TextBox
        Me.dtprocess = New System.Windows.Forms.DateTimePicker
        Me.rdOnline = New System.Windows.Forms.RadioButton
        Me.rdOffline = New System.Windows.Forms.RadioButton
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.PanelTop = New System.Windows.Forms.Panel
        Me.ButtonClose = New System.Windows.Forms.Button
        Me.PanelMonitoringMCU = New System.Windows.Forms.Panel
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.ButtonTandaTerimaMCU = New System.Windows.Forms.Button
        Me.ButtonTarikRekapMCU = New System.Windows.Forms.Button
        Me.ButtonPrintHasilMCU = New System.Windows.Forms.Button
        Me.ButtonClearData = New System.Windows.Forms.Button
        Me.GroupBoxFilter = New System.Windows.Forms.GroupBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.ButtonFindLokasi = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.ButtonFindCompany = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        CType(Me.gridlab, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelTop.SuspendLayout()
        Me.PanelMonitoringMCU.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBoxFilter.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'gridlab
        '
        Me.gridlab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridlab.EmbeddedNavigator.Name = ""
        Me.gridlab.Location = New System.Drawing.Point(0, 0)
        Me.gridlab.MainView = Me.GridView1
        Me.gridlab.Name = "gridlab"
        Me.gridlab.Size = New System.Drawing.Size(983, 151)
        Me.gridlab.TabIndex = 0
        Me.gridlab.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.gridlab
        Me.GridView1.Name = "GridView1"
        '
        'CheckBoxReverse
        '
        Me.CheckBoxReverse.AutoSize = True
        Me.CheckBoxReverse.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.CheckBoxReverse.Location = New System.Drawing.Point(438, 308)
        Me.CheckBoxReverse.Name = "CheckBoxReverse"
        Me.CheckBoxReverse.Size = New System.Drawing.Size(103, 21)
        Me.CheckBoxReverse.TabIndex = 269
        Me.CheckBoxReverse.Text = "Print Reverse"
        Me.CheckBoxReverse.UseVisualStyleBackColor = True
        '
        'cbfisik
        '
        Me.cbfisik.AutoSize = True
        Me.cbfisik.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.cbfisik.Location = New System.Drawing.Point(358, 210)
        Me.cbfisik.Name = "cbfisik"
        Me.cbfisik.Size = New System.Drawing.Size(51, 21)
        Me.cbfisik.TabIndex = 267
        Me.cbfisik.Text = "Fisik"
        Me.cbfisik.UseVisualStyleBackColor = True
        '
        'cbthorax
        '
        Me.cbthorax.AutoSize = True
        Me.cbthorax.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.cbthorax.Location = New System.Drawing.Point(285, 210)
        Me.cbthorax.Name = "cbthorax"
        Me.cbthorax.Size = New System.Drawing.Size(67, 21)
        Me.cbthorax.TabIndex = 266
        Me.cbthorax.Text = "Thorax"
        Me.cbthorax.UseVisualStyleBackColor = True
        '
        'cblab
        '
        Me.cblab.AutoSize = True
        Me.cblab.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.cblab.Location = New System.Drawing.Point(173, 210)
        Me.cblab.Name = "cblab"
        Me.cblab.Size = New System.Drawing.Size(106, 21)
        Me.cblab.TabIndex = 265
        Me.cblab.Text = "Laboratorium"
        Me.cblab.UseVisualStyleBackColor = True
        '
        'txNoUrut2
        '
        Me.txNoUrut2.BackColor = System.Drawing.SystemColors.Window
        Me.txNoUrut2.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txNoUrut2.Location = New System.Drawing.Point(254, 179)
        Me.txNoUrut2.Name = "txNoUrut2"
        Me.txNoUrut2.Size = New System.Drawing.Size(44, 25)
        Me.txNoUrut2.TabIndex = 261
        '
        'cbNoUrut
        '
        Me.cbNoUrut.AutoSize = True
        Me.cbNoUrut.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.cbNoUrut.Location = New System.Drawing.Point(18, 181)
        Me.cbNoUrut.Name = "cbNoUrut"
        Me.cbNoUrut.Size = New System.Drawing.Size(140, 21)
        Me.cbNoUrut.TabIndex = 262
        Me.cbNoUrut.Text = "Sesuaikan No Urut"
        Me.cbNoUrut.UseVisualStyleBackColor = True
        '
        'txNoUrut1
        '
        Me.txNoUrut1.BackColor = System.Drawing.SystemColors.Window
        Me.txNoUrut1.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txNoUrut1.Location = New System.Drawing.Point(173, 179)
        Me.txNoUrut1.Name = "txNoUrut1"
        Me.txNoUrut1.Size = New System.Drawing.Size(44, 25)
        Me.txNoUrut1.TabIndex = 259
        '
        'cmbstatustransaksi
        '
        Me.cmbstatustransaksi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbstatustransaksi.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.cmbstatustransaksi.FormattingEnabled = True
        Me.cmbstatustransaksi.Items.AddRange(New Object() {"SEMUA", "FIT", "FIT DENGAN CATATAN", "UNFIT SEMENTARA", "UNFIT"})
        Me.cmbstatustransaksi.Location = New System.Drawing.Point(173, 148)
        Me.cmbstatustransaksi.Name = "cmbstatustransaksi"
        Me.cmbstatustransaksi.Size = New System.Drawing.Size(194, 25)
        Me.cmbstatustransaksi.TabIndex = 245
        '
        'txkodecabang
        '
        Me.txkodecabang.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.txkodecabang.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txkodecabang.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txkodecabang.Location = New System.Drawing.Point(173, 86)
        Me.txkodecabang.Name = "txkodecabang"
        Me.txkodecabang.Size = New System.Drawing.Size(70, 25)
        Me.txkodecabang.TabIndex = 236
        Me.txkodecabang.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dtprocessend
        '
        Me.dtprocessend.CalendarFont = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.dtprocessend.CustomFormat = "dd-MMM-yyyy"
        Me.dtprocessend.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.dtprocessend.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtprocessend.Location = New System.Drawing.Point(342, 55)
        Me.dtprocessend.Name = "dtprocessend"
        Me.dtprocessend.Size = New System.Drawing.Size(130, 25)
        Me.dtprocessend.TabIndex = 243
        '
        'txidloc
        '
        Me.txidloc.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.txidloc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txidloc.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.txidloc.Location = New System.Drawing.Point(173, 117)
        Me.txidloc.Name = "txidloc"
        Me.txidloc.ReadOnly = True
        Me.txidloc.Size = New System.Drawing.Size(70, 25)
        Me.txidloc.TabIndex = 248
        Me.txidloc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txloc
        '
        Me.txloc.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txloc.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txloc.Location = New System.Drawing.Point(249, 117)
        Me.txloc.Name = "txloc"
        Me.txloc.ReadOnly = True
        Me.txloc.Size = New System.Drawing.Size(390, 25)
        Me.txloc.TabIndex = 247
        '
        'txcompanycode
        '
        Me.txcompanycode.BackColor = System.Drawing.SystemColors.Window
        Me.txcompanycode.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txcompanycode.Location = New System.Drawing.Point(249, 86)
        Me.txcompanycode.Name = "txcompanycode"
        Me.txcompanycode.ReadOnly = True
        Me.txcompanycode.Size = New System.Drawing.Size(390, 25)
        Me.txcompanycode.TabIndex = 239
        '
        'dtprocess
        '
        Me.dtprocess.CalendarFont = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.dtprocess.CustomFormat = "dd-MMM-yyyy"
        Me.dtprocess.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.dtprocess.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtprocess.Location = New System.Drawing.Point(173, 55)
        Me.dtprocess.Name = "dtprocess"
        Me.dtprocess.Size = New System.Drawing.Size(130, 25)
        Me.dtprocess.TabIndex = 237
        '
        'rdOnline
        '
        Me.rdOnline.AutoSize = True
        Me.rdOnline.Checked = True
        Me.rdOnline.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rdOnline.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.rdOnline.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.rdOnline.Location = New System.Drawing.Point(5, 3)
        Me.rdOnline.Name = "rdOnline"
        Me.rdOnline.Size = New System.Drawing.Size(60, 19)
        Me.rdOnline.TabIndex = 244
        Me.rdOnline.TabStop = True
        Me.rdOnline.Text = "Online"
        Me.rdOnline.UseVisualStyleBackColor = True
        '
        'rdOffline
        '
        Me.rdOffline.AutoSize = True
        Me.rdOffline.Cursor = System.Windows.Forms.Cursors.Hand
        Me.rdOffline.Enabled = False
        Me.rdOffline.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.rdOffline.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.rdOffline.Location = New System.Drawing.Point(79, 3)
        Me.rdOffline.Name = "rdOffline"
        Me.rdOffline.Size = New System.Drawing.Size(61, 19)
        Me.rdOffline.TabIndex = 243
        Me.rdOffline.TabStop = True
        Me.rdOffline.Text = "Offline"
        Me.rdOffline.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.BackColor = System.Drawing.Color.Lime
        Me.ProgressBar1.Location = New System.Drawing.Point(173, 237)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(434, 5)
        Me.ProgressBar1.TabIndex = 241
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.PanelTop.Controls.Add(Me.ButtonClose)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(983, 35)
        Me.PanelTop.TabIndex = 464
        '
        'ButtonClose
        '
        Me.ButtonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.ButtonClose.FlatAppearance.BorderSize = 0
        Me.ButtonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonClose.Image = CType(resources.GetObject("ButtonClose.Image"), System.Drawing.Image)
        Me.ButtonClose.Location = New System.Drawing.Point(943, 0)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(40, 35)
        Me.ButtonClose.TabIndex = 281
        Me.ButtonClose.UseVisualStyleBackColor = True
        '
        'PanelMonitoringMCU
        '
        Me.PanelMonitoringMCU.Controls.Add(Me.SplitContainer1)
        Me.PanelMonitoringMCU.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelMonitoringMCU.Location = New System.Drawing.Point(0, 35)
        Me.PanelMonitoringMCU.Name = "PanelMonitoringMCU"
        Me.PanelMonitoringMCU.Size = New System.Drawing.Size(983, 505)
        Me.PanelMonitoringMCU.TabIndex = 465
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ButtonTandaTerimaMCU)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ButtonTarikRekapMCU)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ButtonPrintHasilMCU)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ButtonClearData)
        Me.SplitContainer1.Panel1.Controls.Add(Me.CheckBoxReverse)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBoxFilter)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.gridlab)
        Me.SplitContainer1.Size = New System.Drawing.Size(983, 505)
        Me.SplitContainer1.SplitterDistance = 350
        Me.SplitContainer1.TabIndex = 0
        '
        'ButtonTandaTerimaMCU
        '
        Me.ButtonTandaTerimaMCU.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonTandaTerimaMCU.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonTandaTerimaMCU.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonTandaTerimaMCU.FlatAppearance.BorderSize = 0
        Me.ButtonTandaTerimaMCU.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonTandaTerimaMCU.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonTandaTerimaMCU.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonTandaTerimaMCU.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonTandaTerimaMCU.ForeColor = System.Drawing.Color.White
        Me.ButtonTandaTerimaMCU.Image = CType(resources.GetObject("ButtonTandaTerimaMCU.Image"), System.Drawing.Image)
        Me.ButtonTandaTerimaMCU.Location = New System.Drawing.Point(547, 262)
        Me.ButtonTandaTerimaMCU.Name = "ButtonTandaTerimaMCU"
        Me.ButtonTandaTerimaMCU.Size = New System.Drawing.Size(175, 35)
        Me.ButtonTandaTerimaMCU.TabIndex = 521
        Me.ButtonTandaTerimaMCU.Text = " Tanda Terima MCU"
        Me.ButtonTandaTerimaMCU.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonTandaTerimaMCU.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonTandaTerimaMCU.UseVisualStyleBackColor = False
        '
        'ButtonTarikRekapMCU
        '
        Me.ButtonTarikRekapMCU.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonTarikRekapMCU.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonTarikRekapMCU.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonTarikRekapMCU.FlatAppearance.BorderSize = 0
        Me.ButtonTarikRekapMCU.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonTarikRekapMCU.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonTarikRekapMCU.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonTarikRekapMCU.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonTarikRekapMCU.ForeColor = System.Drawing.Color.White
        Me.ButtonTarikRekapMCU.Image = CType(resources.GetObject("ButtonTarikRekapMCU.Image"), System.Drawing.Image)
        Me.ButtonTarikRekapMCU.Location = New System.Drawing.Point(366, 262)
        Me.ButtonTarikRekapMCU.Name = "ButtonTarikRekapMCU"
        Me.ButtonTarikRekapMCU.Size = New System.Drawing.Size(175, 35)
        Me.ButtonTarikRekapMCU.TabIndex = 520
        Me.ButtonTarikRekapMCU.Text = " Tarik Rekap MCU"
        Me.ButtonTarikRekapMCU.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonTarikRekapMCU.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonTarikRekapMCU.UseVisualStyleBackColor = False
        '
        'ButtonPrintHasilMCU
        '
        Me.ButtonPrintHasilMCU.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonPrintHasilMCU.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonPrintHasilMCU.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonPrintHasilMCU.FlatAppearance.BorderSize = 0
        Me.ButtonPrintHasilMCU.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonPrintHasilMCU.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonPrintHasilMCU.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonPrintHasilMCU.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonPrintHasilMCU.ForeColor = System.Drawing.Color.White
        Me.ButtonPrintHasilMCU.Image = CType(resources.GetObject("ButtonPrintHasilMCU.Image"), System.Drawing.Image)
        Me.ButtonPrintHasilMCU.Location = New System.Drawing.Point(547, 303)
        Me.ButtonPrintHasilMCU.Name = "ButtonPrintHasilMCU"
        Me.ButtonPrintHasilMCU.Size = New System.Drawing.Size(175, 35)
        Me.ButtonPrintHasilMCU.TabIndex = 519
        Me.ButtonPrintHasilMCU.Text = " Print Hasil MCU"
        Me.ButtonPrintHasilMCU.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonPrintHasilMCU.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonPrintHasilMCU.UseVisualStyleBackColor = False
        '
        'ButtonClearData
        '
        Me.ButtonClearData.BackColor = System.Drawing.Color.White
        Me.ButtonClearData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonClearData.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonClearData.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonClearData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonClearData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonClearData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonClearData.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonClearData.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonClearData.Image = CType(resources.GetObject("ButtonClearData.Image"), System.Drawing.Image)
        Me.ButtonClearData.Location = New System.Drawing.Point(185, 262)
        Me.ButtonClearData.Name = "ButtonClearData"
        Me.ButtonClearData.Size = New System.Drawing.Size(175, 35)
        Me.ButtonClearData.TabIndex = 518
        Me.ButtonClearData.Text = " Clear Data Grid"
        Me.ButtonClearData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonClearData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonClearData.UseVisualStyleBackColor = False
        '
        'GroupBoxFilter
        '
        Me.GroupBoxFilter.Controls.Add(Me.Label17)
        Me.GroupBoxFilter.Controls.Add(Me.Label7)
        Me.GroupBoxFilter.Controls.Add(Me.cbfisik)
        Me.GroupBoxFilter.Controls.Add(Me.cbNoUrut)
        Me.GroupBoxFilter.Controls.Add(Me.cbthorax)
        Me.GroupBoxFilter.Controls.Add(Me.cblab)
        Me.GroupBoxFilter.Controls.Add(Me.txNoUrut2)
        Me.GroupBoxFilter.Controls.Add(Me.Panel2)
        Me.GroupBoxFilter.Controls.Add(Me.txNoUrut1)
        Me.GroupBoxFilter.Controls.Add(Me.dtprocessend)
        Me.GroupBoxFilter.Controls.Add(Me.ButtonFindLokasi)
        Me.GroupBoxFilter.Controls.Add(Me.Label11)
        Me.GroupBoxFilter.Controls.Add(Me.ButtonFindCompany)
        Me.GroupBoxFilter.Controls.Add(Me.Label12)
        Me.GroupBoxFilter.Controls.Add(Me.Label13)
        Me.GroupBoxFilter.Controls.Add(Me.txkodecabang)
        Me.GroupBoxFilter.Controls.Add(Me.ProgressBar1)
        Me.GroupBoxFilter.Controls.Add(Me.txidloc)
        Me.GroupBoxFilter.Controls.Add(Me.cmbstatustransaksi)
        Me.GroupBoxFilter.Controls.Add(Me.Label14)
        Me.GroupBoxFilter.Controls.Add(Me.txloc)
        Me.GroupBoxFilter.Controls.Add(Me.Label15)
        Me.GroupBoxFilter.Controls.Add(Me.dtprocess)
        Me.GroupBoxFilter.Controls.Add(Me.txcompanycode)
        Me.GroupBoxFilter.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold)
        Me.GroupBoxFilter.Location = New System.Drawing.Point(12, 6)
        Me.GroupBoxFilter.Name = "GroupBoxFilter"
        Me.GroupBoxFilter.Size = New System.Drawing.Size(725, 250)
        Me.GroupBoxFilter.TabIndex = 462
        Me.GroupBoxFilter.TabStop = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label17.Location = New System.Drawing.Point(309, 59)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(27, 17)
        Me.Label17.TabIndex = 473
        Me.Label17.Text = "s/d"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label7.Location = New System.Drawing.Point(221, 182)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(27, 17)
        Me.Label7.TabIndex = 472
        Me.Label7.Text = "s/d"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.rdOnline)
        Me.Panel2.Controls.Add(Me.rdOffline)
        Me.Panel2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Panel2.Location = New System.Drawing.Point(173, 24)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(291, 25)
        Me.Panel2.TabIndex = 466
        '
        'ButtonFindLokasi
        '
        Me.ButtonFindLokasi.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindLokasi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonFindLokasi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonFindLokasi.FlatAppearance.BorderSize = 0
        Me.ButtonFindLokasi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindLokasi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonFindLokasi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonFindLokasi.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonFindLokasi.ForeColor = System.Drawing.Color.White
        Me.ButtonFindLokasi.Location = New System.Drawing.Point(645, 117)
        Me.ButtonFindLokasi.Name = "ButtonFindLokasi"
        Me.ButtonFindLokasi.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonFindLokasi.Size = New System.Drawing.Size(65, 25)
        Me.ButtonFindLokasi.TabIndex = 463
        Me.ButtonFindLokasi.Text = "Cari"
        Me.ButtonFindLokasi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonFindLokasi.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(14, 151)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(105, 17)
        Me.Label11.TabIndex = 461
        Me.Label11.Text = "Status Transaksi"
        '
        'ButtonFindCompany
        '
        Me.ButtonFindCompany.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindCompany.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonFindCompany.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonFindCompany.FlatAppearance.BorderSize = 0
        Me.ButtonFindCompany.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindCompany.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonFindCompany.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonFindCompany.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonFindCompany.ForeColor = System.Drawing.Color.White
        Me.ButtonFindCompany.Location = New System.Drawing.Point(645, 86)
        Me.ButtonFindCompany.Name = "ButtonFindCompany"
        Me.ButtonFindCompany.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonFindCompany.Size = New System.Drawing.Size(65, 25)
        Me.ButtonFindCompany.TabIndex = 462
        Me.ButtonFindCompany.Text = "Cari"
        Me.ButtonFindCompany.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonFindCompany.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label12.Location = New System.Drawing.Point(15, 27)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(96, 17)
        Me.Label12.TabIndex = 242
        Me.Label12.Text = "Jenis Transaksi"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label13.Location = New System.Drawing.Point(15, 59)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(84, 17)
        Me.Label13.TabIndex = 241
        Me.Label13.Text = "Tgl Transaksi"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label14.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label14.Location = New System.Drawing.Point(15, 120)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 17)
        Me.Label14.TabIndex = 245
        Me.Label14.Text = "Lokasi Server"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label15.Location = New System.Drawing.Point(15, 89)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(66, 17)
        Me.Label15.TabIndex = 238
        Me.Label15.Text = "Company"
        '
        'MonitoringMCU
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(983, 540)
        Me.ControlBox = False
        Me.Controls.Add(Me.PanelMonitoringMCU)
        Me.Controls.Add(Me.PanelTop)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MonitoringMCU"
        CType(Me.gridlab, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelTop.ResumeLayout(False)
        Me.PanelMonitoringMCU.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBoxFilter.ResumeLayout(False)
        Me.GroupBoxFilter.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents gridlab As DevExpress.XtraGrid.GridControl
    Private WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents rdOnline As System.Windows.Forms.RadioButton
    Friend WithEvents rdOffline As System.Windows.Forms.RadioButton
    Friend WithEvents txloc As System.Windows.Forms.TextBox
    Friend WithEvents txidloc As System.Windows.Forms.TextBox
    Friend WithEvents txkodecabang As System.Windows.Forms.TextBox
    Friend WithEvents dtprocessend As System.Windows.Forms.DateTimePicker
    Friend WithEvents txcompanycode As System.Windows.Forms.TextBox
    Friend WithEvents dtprocess As System.Windows.Forms.DateTimePicker
    Friend WithEvents cmbstatustransaksi As System.Windows.Forms.ComboBox
    Friend WithEvents txNoUrut2 As System.Windows.Forms.TextBox
    Friend WithEvents cbNoUrut As System.Windows.Forms.CheckBox
    Friend WithEvents txNoUrut1 As System.Windows.Forms.TextBox
    Friend WithEvents cblab As System.Windows.Forms.CheckBox
    Friend WithEvents cbfisik As System.Windows.Forms.CheckBox
    Friend WithEvents cbthorax As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBoxReverse As System.Windows.Forms.CheckBox
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents ButtonClose As System.Windows.Forms.Button
    Friend WithEvents PanelMonitoringMCU As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBoxFilter As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ButtonFindLokasi As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents ButtonFindCompany As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents ButtonClearData As System.Windows.Forms.Button
    Friend WithEvents ButtonTandaTerimaMCU As System.Windows.Forms.Button
    Friend WithEvents ButtonTarikRekapMCU As System.Windows.Forms.Button
    Friend WithEvents ButtonPrintHasilMCU As System.Windows.Forms.Button
End Class
