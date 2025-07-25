<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FindPasien
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FindPasien))
        Me.GridPencarian = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.PanelTop = New System.Windows.Forms.Panel
        Me.btnClose = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label6 = New System.Windows.Forms.Label
        Me.ComboBoxTanggal = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.ComboBoxBulan = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.ComboBoxTahun = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TextBoxNamaIdentitas = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBoxJenisIdentitas = New System.Windows.Forms.TextBox
        Me.ComboBoxJenisIdentitas = New System.Windows.Forms.ComboBox
        Me.ButtonFindPasien = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        CType(Me.GridPencarian, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelTop.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
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
        Me.GridPencarian.Size = New System.Drawing.Size(798, 281)
        Me.GridPencarian.TabIndex = 1
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
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.ComboBoxTanggal)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.ComboBoxBulan)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.ComboBoxTahun)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.TextBoxNamaIdentitas)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.TextBoxJenisIdentitas)
        Me.Panel1.Controls.Add(Me.ComboBoxJenisIdentitas)
        Me.Panel1.Controls.Add(Me.ButtonFindPasien)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 35)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(798, 182)
        Me.Panel1.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(414, 86)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 13)
        Me.Label6.TabIndex = 440
        Me.Label6.Text = "Tanggal"
        '
        'ComboBoxTanggal
        '
        Me.ComboBoxTanggal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.ComboBoxTanggal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxTanggal.Cursor = System.Windows.Forms.Cursors.Default
        Me.ComboBoxTanggal.DropDownHeight = 100
        Me.ComboBoxTanggal.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxTanggal.FormattingEnabled = True
        Me.ComboBoxTanggal.IntegralHeight = False
        Me.ComboBoxTanggal.ItemHeight = 17
        Me.ComboBoxTanggal.Location = New System.Drawing.Point(417, 102)
        Me.ComboBoxTanggal.Name = "ComboBoxTanggal"
        Me.ComboBoxTanggal.Size = New System.Drawing.Size(50, 25)
        Me.ComboBoxTanggal.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(258, 86)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 438
        Me.Label5.Text = "Bulan"
        '
        'ComboBoxBulan
        '
        Me.ComboBoxBulan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.ComboBoxBulan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxBulan.Cursor = System.Windows.Forms.Cursors.Default
        Me.ComboBoxBulan.DropDownHeight = 100
        Me.ComboBoxBulan.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxBulan.FormattingEnabled = True
        Me.ComboBoxBulan.IntegralHeight = False
        Me.ComboBoxBulan.ItemHeight = 17
        Me.ComboBoxBulan.Location = New System.Drawing.Point(261, 102)
        Me.ComboBoxBulan.Name = "ComboBoxBulan"
        Me.ComboBoxBulan.Size = New System.Drawing.Size(150, 25)
        Me.ComboBoxBulan.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(182, 86)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 436
        Me.Label4.Text = "Tahun"
        '
        'ComboBoxTahun
        '
        Me.ComboBoxTahun.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append
        Me.ComboBoxTahun.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBoxTahun.Cursor = System.Windows.Forms.Cursors.Default
        Me.ComboBoxTahun.DropDownHeight = 150
        Me.ComboBoxTahun.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxTahun.FormattingEnabled = True
        Me.ComboBoxTahun.IntegralHeight = False
        Me.ComboBoxTahun.Location = New System.Drawing.Point(185, 102)
        Me.ComboBoxTahun.Name = "ComboBoxTahun"
        Me.ComboBoxTahun.Size = New System.Drawing.Size(70, 25)
        Me.ComboBoxTahun.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(30, 105)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(88, 17)
        Me.Label3.TabIndex = 434
        Me.Label3.Text = "Tanggal Lahir"
        '
        'TextBoxNamaIdentitas
        '
        Me.TextBoxNamaIdentitas.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TextBoxNamaIdentitas.Location = New System.Drawing.Point(185, 56)
        Me.TextBoxNamaIdentitas.Name = "TextBoxNamaIdentitas"
        Me.TextBoxNamaIdentitas.Size = New System.Drawing.Size(282, 25)
        Me.TextBoxNamaIdentitas.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(30, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 17)
        Me.Label2.TabIndex = 432
        Me.Label2.Text = "Nama"
        '
        'TextBoxJenisIdentitas
        '
        Me.TextBoxJenisIdentitas.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TextBoxJenisIdentitas.Location = New System.Drawing.Point(185, 21)
        Me.TextBoxJenisIdentitas.Name = "TextBoxJenisIdentitas"
        Me.TextBoxJenisIdentitas.Size = New System.Drawing.Size(282, 25)
        Me.TextBoxJenisIdentitas.TabIndex = 1
        '
        'ComboBoxJenisIdentitas
        '
        Me.ComboBoxJenisIdentitas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ComboBoxJenisIdentitas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxJenisIdentitas.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxJenisIdentitas.FormattingEnabled = True
        Me.ComboBoxJenisIdentitas.Items.AddRange(New Object() {"No JKN-KIS", "No RM", "NIK", "No HP", "No Inhealth", "No JPK", "No Cahaya"})
        Me.ComboBoxJenisIdentitas.Location = New System.Drawing.Point(33, 21)
        Me.ComboBoxJenisIdentitas.Name = "ComboBoxJenisIdentitas"
        Me.ComboBoxJenisIdentitas.Size = New System.Drawing.Size(121, 25)
        Me.ComboBoxJenisIdentitas.TabIndex = 430
        '
        'ButtonFindPasien
        '
        Me.ButtonFindPasien.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindPasien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonFindPasien.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonFindPasien.FlatAppearance.BorderSize = 0
        Me.ButtonFindPasien.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindPasien.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonFindPasien.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonFindPasien.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonFindPasien.ForeColor = System.Drawing.Color.White
        Me.ButtonFindPasien.Location = New System.Drawing.Point(185, 133)
        Me.ButtonFindPasien.Name = "ButtonFindPasien"
        Me.ButtonFindPasien.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonFindPasien.Size = New System.Drawing.Size(282, 30)
        Me.ButtonFindPasien.TabIndex = 429
        Me.ButtonFindPasien.Text = "Cari Data"
        Me.ButtonFindPasien.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonFindPasien.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.Controls.Add(Me.GridPencarian)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 217)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(798, 281)
        Me.Panel2.TabIndex = 7
        '
        'FindPasien
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
        Me.Name = "FindPasien"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        CType(Me.GridPencarian, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelTop.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ButtonFindPasien As System.Windows.Forms.Button
    Friend WithEvents GridPencarian As DevExpress.XtraGrid.GridControl
    Friend WithEvents ComboBoxJenisIdentitas As System.Windows.Forms.ComboBox
    Friend WithEvents TextBoxJenisIdentitas As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxTahun As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNamaIdentitas As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxTanggal As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxBulan As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
