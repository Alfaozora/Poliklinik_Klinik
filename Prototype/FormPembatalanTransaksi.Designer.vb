<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPembatalanTransaksi
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPembatalanTransaksi))
        Me.GridControlTransaksi = New DevExpress.XtraGrid.GridControl
        Me.GridViewDataTransaksi = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.groupcustomer = New System.Windows.Forms.GroupBox
        Me.ButtonFindData = New System.Windows.Forms.Button
        Me.ButtonHapusData = New System.Windows.Forms.Button
        Me.TextBoxAlasan = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.DateTimePickerTanggalTransaksiAwal = New System.Windows.Forms.DateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.PanelTop = New System.Windows.Forms.Panel
        Me.ButtonClose = New System.Windows.Forms.Button
        Me.SplitContainer7 = New System.Windows.Forms.SplitContainer
        Me.Label2 = New System.Windows.Forms.Label
        Me.DateTimePickerTanggalTransaksiAkhir = New System.Windows.Forms.DateTimePicker
        Me.Button1 = New System.Windows.Forms.Button
        CType(Me.GridControlTransaksi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewDataTransaksi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.groupcustomer.SuspendLayout()
        Me.PanelTop.SuspendLayout()
        Me.SplitContainer7.Panel1.SuspendLayout()
        Me.SplitContainer7.Panel2.SuspendLayout()
        Me.SplitContainer7.SuspendLayout()
        Me.SuspendLayout()
        '
        'GridControlTransaksi
        '
        Me.GridControlTransaksi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControlTransaksi.EmbeddedNavigator.Name = ""
        Me.GridControlTransaksi.Location = New System.Drawing.Point(0, 0)
        Me.GridControlTransaksi.MainView = Me.GridViewDataTransaksi
        Me.GridControlTransaksi.Name = "GridControlTransaksi"
        Me.GridControlTransaksi.Size = New System.Drawing.Size(1028, 357)
        Me.GridControlTransaksi.TabIndex = 6
        Me.GridControlTransaksi.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewDataTransaksi})
        '
        'GridViewDataTransaksi
        '
        Me.GridViewDataTransaksi.GridControl = Me.GridControlTransaksi
        Me.GridViewDataTransaksi.Name = "GridViewDataTransaksi"
        Me.GridViewDataTransaksi.OptionsView.ShowAutoFilterRow = True
        Me.GridViewDataTransaksi.OptionsView.ShowGroupPanel = False
        Me.GridViewDataTransaksi.PaintStyleName = "Office2003"
        '
        'groupcustomer
        '
        Me.groupcustomer.Controls.Add(Me.Button1)
        Me.groupcustomer.Controls.Add(Me.Label2)
        Me.groupcustomer.Controls.Add(Me.DateTimePickerTanggalTransaksiAkhir)
        Me.groupcustomer.Controls.Add(Me.ButtonFindData)
        Me.groupcustomer.Controls.Add(Me.ButtonHapusData)
        Me.groupcustomer.Controls.Add(Me.TextBoxAlasan)
        Me.groupcustomer.Controls.Add(Me.Label1)
        Me.groupcustomer.Controls.Add(Me.DateTimePickerTanggalTransaksiAwal)
        Me.groupcustomer.Controls.Add(Me.Label7)
        Me.groupcustomer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.groupcustomer.Location = New System.Drawing.Point(0, 0)
        Me.groupcustomer.Name = "groupcustomer"
        Me.groupcustomer.Size = New System.Drawing.Size(1028, 155)
        Me.groupcustomer.TabIndex = 7
        Me.groupcustomer.TabStop = False
        '
        'ButtonFindData
        '
        Me.ButtonFindData.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonFindData.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonFindData.FlatAppearance.BorderSize = 0
        Me.ButtonFindData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonFindData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonFindData.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonFindData.ForeColor = System.Drawing.Color.White
        Me.ButtonFindData.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_search_24
        Me.ButtonFindData.Location = New System.Drawing.Point(479, 109)
        Me.ButtonFindData.Name = "ButtonFindData"
        Me.ButtonFindData.Size = New System.Drawing.Size(120, 35)
        Me.ButtonFindData.TabIndex = 448
        Me.ButtonFindData.Text = " Cari Data"
        Me.ButtonFindData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonFindData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonFindData.UseVisualStyleBackColor = False
        '
        'ButtonHapusData
        '
        Me.ButtonHapusData.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonHapusData.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonHapusData.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonHapusData.FlatAppearance.BorderSize = 0
        Me.ButtonHapusData.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonHapusData.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonHapusData.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonHapusData.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonHapusData.ForeColor = System.Drawing.Color.White
        Me.ButtonHapusData.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_delete_file_24
        Me.ButtonHapusData.Location = New System.Drawing.Point(605, 109)
        Me.ButtonHapusData.Name = "ButtonHapusData"
        Me.ButtonHapusData.Size = New System.Drawing.Size(120, 35)
        Me.ButtonHapusData.TabIndex = 447
        Me.ButtonHapusData.Text = " Hapus Data"
        Me.ButtonHapusData.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonHapusData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonHapusData.UseVisualStyleBackColor = False
        '
        'TextBoxAlasan
        '
        Me.TextBoxAlasan.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxAlasan.Location = New System.Drawing.Point(170, 53)
        Me.TextBoxAlasan.Multiline = True
        Me.TextBoxAlasan.Name = "TextBoxAlasan"
        Me.TextBoxAlasan.Size = New System.Drawing.Size(555, 50)
        Me.TextBoxAlasan.TabIndex = 146
        Me.TextBoxAlasan.Tag = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(35, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 17)
        Me.Label1.TabIndex = 131
        Me.Label1.Text = "Alasan Cancel"
        '
        'DateTimePickerTanggalTransaksiAwal
        '
        Me.DateTimePickerTanggalTransaksiAwal.CustomFormat = "dd-MMM-yyyy"
        Me.DateTimePickerTanggalTransaksiAwal.Enabled = False
        Me.DateTimePickerTanggalTransaksiAwal.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.DateTimePickerTanggalTransaksiAwal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerTanggalTransaksiAwal.Location = New System.Drawing.Point(170, 22)
        Me.DateTimePickerTanggalTransaksiAwal.Name = "DateTimePickerTanggalTransaksiAwal"
        Me.DateTimePickerTanggalTransaksiAwal.Size = New System.Drawing.Size(150, 25)
        Me.DateTimePickerTanggalTransaksiAwal.TabIndex = 62
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(12, 28)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(114, 17)
        Me.Label7.TabIndex = 61
        Me.Label7.Text = "Tanggal Transaksi"
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.PanelTop.Controls.Add(Me.ButtonClose)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(1028, 35)
        Me.PanelTop.TabIndex = 8
        '
        'ButtonClose
        '
        Me.ButtonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.ButtonClose.FlatAppearance.BorderSize = 0
        Me.ButtonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonClose.Image = CType(resources.GetObject("ButtonClose.Image"), System.Drawing.Image)
        Me.ButtonClose.Location = New System.Drawing.Point(988, 0)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(40, 35)
        Me.ButtonClose.TabIndex = 281
        Me.ButtonClose.UseVisualStyleBackColor = True
        '
        'SplitContainer7
        '
        Me.SplitContainer7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer7.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer7.IsSplitterFixed = True
        Me.SplitContainer7.Location = New System.Drawing.Point(0, 35)
        Me.SplitContainer7.Name = "SplitContainer7"
        Me.SplitContainer7.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer7.Panel1
        '
        Me.SplitContainer7.Panel1.AutoScroll = True
        Me.SplitContainer7.Panel1.Controls.Add(Me.groupcustomer)
        '
        'SplitContainer7.Panel2
        '
        Me.SplitContainer7.Panel2.AutoScroll = True
        Me.SplitContainer7.Panel2.Controls.Add(Me.GridControlTransaksi)
        Me.SplitContainer7.Size = New System.Drawing.Size(1028, 517)
        Me.SplitContainer7.SplitterDistance = 155
        Me.SplitContainer7.SplitterWidth = 5
        Me.SplitContainer7.TabIndex = 460
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(326, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 17)
        Me.Label2.TabIndex = 550
        Me.Label2.Text = "s/d"
        '
        'DateTimePickerTanggalTransaksiAkhir
        '
        Me.DateTimePickerTanggalTransaksiAkhir.CalendarFont = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerTanggalTransaksiAkhir.CustomFormat = "dd-MMM-yyyy"
        Me.DateTimePickerTanggalTransaksiAkhir.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerTanggalTransaksiAkhir.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerTanggalTransaksiAkhir.Location = New System.Drawing.Point(359, 22)
        Me.DateTimePickerTanggalTransaksiAkhir.Name = "DateTimePickerTanggalTransaksiAkhir"
        Me.DateTimePickerTanggalTransaksiAkhir.Size = New System.Drawing.Size(150, 25)
        Me.DateTimePickerTanggalTransaksiAkhir.TabIndex = 549
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
        Me.Button1.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_delete_file_24
        Me.Button1.Location = New System.Drawing.Point(731, 109)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(120, 35)
        Me.Button1.TabIndex = 551
        Me.Button1.Text = " Flag Cancel"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = False
        '
        'FormPembatalanTransaksi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1028, 552)
        Me.ControlBox = False
        Me.Controls.Add(Me.SplitContainer7)
        Me.Controls.Add(Me.PanelTop)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPembatalanTransaksi"
        CType(Me.GridControlTransaksi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewDataTransaksi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.groupcustomer.ResumeLayout(False)
        Me.groupcustomer.PerformLayout()
        Me.PanelTop.ResumeLayout(False)
        Me.SplitContainer7.Panel1.ResumeLayout(False)
        Me.SplitContainer7.Panel2.ResumeLayout(False)
        Me.SplitContainer7.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GridControlTransaksi As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewDataTransaksi As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents groupcustomer As System.Windows.Forms.GroupBox
    Friend WithEvents DateTimePickerTanggalTransaksiAwal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxAlasan As System.Windows.Forms.TextBox
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents ButtonClose As System.Windows.Forms.Button
    Friend WithEvents SplitContainer7 As System.Windows.Forms.SplitContainer
    Friend WithEvents ButtonFindData As System.Windows.Forms.Button
    Friend WithEvents ButtonHapusData As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerTanggalTransaksiAkhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
