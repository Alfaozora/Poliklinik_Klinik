<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FindDiagnosa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FindDiagnosa))
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBoxKriteria = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.PanelTop = New System.Windows.Forms.Panel
        Me.ToggleSwitch1 = New PoliKlinik_Net2.ToggleSwitch
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnClose = New System.Windows.Forms.Button
        Me.PanelHeader = New System.Windows.Forms.Panel
        Me.ButtonFindDiagnosa = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.GridControlPencarian = New DevExpress.XtraGrid.GridControl
        Me.GridViewPencarian = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.PanelTop.SuspendLayout()
        Me.PanelHeader.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.GridControlPencarian, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewPencarian, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(108, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(438, 25)
        Me.Label2.TabIndex = 206
        Me.Label2.Text = "Pencarian Referensi Berdasarkan Kode atau Nama"
        '
        'TextBoxKriteria
        '
        Me.TextBoxKriteria.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TextBoxKriteria.Location = New System.Drawing.Point(240, 67)
        Me.TextBoxKriteria.Name = "TextBoxKriteria"
        Me.TextBoxKriteria.Size = New System.Drawing.Size(275, 25)
        Me.TextBoxKriteria.TabIndex = 205
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(110, 70)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 17)
        Me.Label1.TabIndex = 193
        Me.Label1.Text = "Kriteria Pencarian"
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.PanelTop.Controls.Add(Me.ToggleSwitch1)
        Me.PanelTop.Controls.Add(Me.Label4)
        Me.PanelTop.Controls.Add(Me.Label3)
        Me.PanelTop.Controls.Add(Me.btnClose)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(694, 35)
        Me.PanelTop.TabIndex = 5
        '
        'ToggleSwitch1
        '
        Me.ToggleSwitch1.Checked = True
        Me.ToggleSwitch1.Location = New System.Drawing.Point(509, 5)
        Me.ToggleSwitch1.Name = "ToggleSwitch1"
        Me.ToggleSwitch1.Size = New System.Drawing.Size(50, 25)
        Me.ToggleSwitch1.TabIndex = 433
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(565, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 17)
        Me.Label4.TabIndex = 432
        Me.Label4.Text = "PCare"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(466, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 17)
        Me.Label3.TabIndex = 431
        Me.Label3.Text = "Lokal"
        '
        'btnClose
        '
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(654, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(40, 35)
        Me.btnClose.TabIndex = 281
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'PanelHeader
        '
        Me.PanelHeader.BackColor = System.Drawing.Color.Transparent
        Me.PanelHeader.Controls.Add(Me.ButtonFindDiagnosa)
        Me.PanelHeader.Controls.Add(Me.Label2)
        Me.PanelHeader.Controls.Add(Me.TextBoxKriteria)
        Me.PanelHeader.Controls.Add(Me.Label1)
        Me.PanelHeader.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelHeader.Location = New System.Drawing.Point(0, 35)
        Me.PanelHeader.Name = "PanelHeader"
        Me.PanelHeader.Size = New System.Drawing.Size(694, 116)
        Me.PanelHeader.TabIndex = 6
        '
        'ButtonFindDiagnosa
        '
        Me.ButtonFindDiagnosa.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindDiagnosa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonFindDiagnosa.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonFindDiagnosa.FlatAppearance.BorderSize = 0
        Me.ButtonFindDiagnosa.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(237, Byte), Integer), CType(CType(231, Byte), Integer), CType(CType(225, Byte), Integer))
        Me.ButtonFindDiagnosa.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(77, Byte), Integer), CType(CType(175, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.ButtonFindDiagnosa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonFindDiagnosa.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonFindDiagnosa.ForeColor = System.Drawing.Color.Transparent
        Me.ButtonFindDiagnosa.Location = New System.Drawing.Point(521, 64)
        Me.ButtonFindDiagnosa.Name = "ButtonFindDiagnosa"
        Me.ButtonFindDiagnosa.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonFindDiagnosa.Size = New System.Drawing.Size(65, 30)
        Me.ButtonFindDiagnosa.TabIndex = 429
        Me.ButtonFindDiagnosa.Text = "Cari"
        Me.ButtonFindDiagnosa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonFindDiagnosa.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.GridControlPencarian)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 151)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(694, 343)
        Me.Panel2.TabIndex = 7
        '
        'GridControlPencarian
        '
        Me.GridControlPencarian.BackgroundImage = Global.PoliKlinik_Net2.My.Resources.Resources.wallpaperdialog
        Me.GridControlPencarian.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GridControlPencarian.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControlPencarian.EmbeddedNavigator.Name = ""
        Me.GridControlPencarian.Location = New System.Drawing.Point(0, 0)
        Me.GridControlPencarian.MainView = Me.GridViewPencarian
        Me.GridControlPencarian.Name = "GridControlPencarian"
        Me.GridControlPencarian.Size = New System.Drawing.Size(694, 343)
        Me.GridControlPencarian.TabIndex = 2
        Me.GridControlPencarian.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewPencarian})
        '
        'GridViewPencarian
        '
        Me.GridViewPencarian.GridControl = Me.GridControlPencarian
        Me.GridViewPencarian.Name = "GridViewPencarian"
        Me.GridViewPencarian.OptionsBehavior.Editable = False
        Me.GridViewPencarian.OptionsCustomization.AllowGroup = False
        Me.GridViewPencarian.OptionsView.ShowAutoFilterRow = True
        Me.GridViewPencarian.OptionsView.ShowGroupPanel = False
        Me.GridViewPencarian.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowForFocusedRow
        '
        'FindDiagnosa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(694, 494)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.PanelHeader)
        Me.Controls.Add(Me.PanelTop)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FindDiagnosa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.PanelTop.ResumeLayout(False)
        Me.PanelTop.PerformLayout()
        Me.PanelHeader.ResumeLayout(False)
        Me.PanelHeader.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.GridControlPencarian, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewPencarian, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBoxKriteria As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents PanelHeader As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ButtonFindDiagnosa As System.Windows.Forms.Button
    Private WithEvents GridControlPencarian As DevExpress.XtraGrid.GridControl
    Private WithEvents GridViewPencarian As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ToggleSwitch1 As PoliKlinik_Net2.ToggleSwitch
End Class
