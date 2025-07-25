<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogBoxPaketTindakan
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
        Me.PanelTop = New System.Windows.Forms.Panel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.SplitContainerMainMenu = New System.Windows.Forms.SplitContainer
        Me.SplitContainerPaket = New System.Windows.Forms.SplitContainer
        Me.ButtonFindPaket = New System.Windows.Forms.Button
        Me.TextBoxKodeVoucher = New System.Windows.Forms.TextBox
        Me.Label157 = New System.Windows.Forms.Label
        Me.GridControlPaket = New DevExpress.XtraGrid.GridControl
        Me.GridViewPaket = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ButtonBatal = New System.Windows.Forms.Button
        Me.ButtonSimpan = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.SplitContainerMainMenu.Panel1.SuspendLayout()
        Me.SplitContainerMainMenu.Panel2.SuspendLayout()
        Me.SplitContainerMainMenu.SuspendLayout()
        Me.SplitContainerPaket.Panel1.SuspendLayout()
        Me.SplitContainerPaket.Panel2.SuspendLayout()
        Me.SplitContainerPaket.SuspendLayout()
        CType(Me.GridControlPaket, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewPaket, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(838, 35)
        Me.PanelTop.TabIndex = 5
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.SplitContainerMainMenu)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 35)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(838, 413)
        Me.Panel1.TabIndex = 6
        '
        'SplitContainerMainMenu
        '
        Me.SplitContainerMainMenu.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerMainMenu.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainerMainMenu.IsSplitterFixed = True
        Me.SplitContainerMainMenu.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerMainMenu.Name = "SplitContainerMainMenu"
        Me.SplitContainerMainMenu.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerMainMenu.Panel1
        '
        Me.SplitContainerMainMenu.Panel1.AutoScroll = True
        Me.SplitContainerMainMenu.Panel1.Controls.Add(Me.SplitContainerPaket)
        '
        'SplitContainerMainMenu.Panel2
        '
        Me.SplitContainerMainMenu.Panel2.AutoScroll = True
        Me.SplitContainerMainMenu.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.SplitContainerMainMenu.Panel2.Controls.Add(Me.ButtonBatal)
        Me.SplitContainerMainMenu.Panel2.Controls.Add(Me.ButtonSimpan)
        Me.SplitContainerMainMenu.Size = New System.Drawing.Size(838, 413)
        Me.SplitContainerMainMenu.SplitterDistance = 365
        Me.SplitContainerMainMenu.SplitterWidth = 5
        Me.SplitContainerMainMenu.TabIndex = 500
        '
        'SplitContainerPaket
        '
        Me.SplitContainerPaket.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerPaket.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainerPaket.IsSplitterFixed = True
        Me.SplitContainerPaket.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerPaket.Name = "SplitContainerPaket"
        Me.SplitContainerPaket.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerPaket.Panel1
        '
        Me.SplitContainerPaket.Panel1.Controls.Add(Me.ButtonFindPaket)
        Me.SplitContainerPaket.Panel1.Controls.Add(Me.TextBoxKodeVoucher)
        Me.SplitContainerPaket.Panel1.Controls.Add(Me.Label157)
        '
        'SplitContainerPaket.Panel2
        '
        Me.SplitContainerPaket.Panel2.AutoScroll = True
        Me.SplitContainerPaket.Panel2.Controls.Add(Me.GridControlPaket)
        Me.SplitContainerPaket.Size = New System.Drawing.Size(838, 365)
        Me.SplitContainerPaket.SplitterDistance = 65
        Me.SplitContainerPaket.SplitterWidth = 1
        Me.SplitContainerPaket.TabIndex = 463
        '
        'ButtonFindPaket
        '
        Me.ButtonFindPaket.BackColor = System.Drawing.Color.White
        Me.ButtonFindPaket.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonFindPaket.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonFindPaket.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindPaket.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindPaket.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonFindPaket.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonFindPaket.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ButtonFindPaket.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindPaket.Location = New System.Drawing.Point(515, 19)
        Me.ButtonFindPaket.Name = "ButtonFindPaket"
        Me.ButtonFindPaket.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonFindPaket.Size = New System.Drawing.Size(175, 25)
        Me.ButtonFindPaket.TabIndex = 547
        Me.ButtonFindPaket.Text = " Cari Paket Pasien"
        Me.ButtonFindPaket.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonFindPaket.UseVisualStyleBackColor = False
        '
        'TextBoxKodeVoucher
        '
        Me.TextBoxKodeVoucher.BackColor = System.Drawing.Color.White
        Me.TextBoxKodeVoucher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxKodeVoucher.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBoxKodeVoucher.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TextBoxKodeVoucher.Location = New System.Drawing.Point(234, 20)
        Me.TextBoxKodeVoucher.Name = "TextBoxKodeVoucher"
        Me.TextBoxKodeVoucher.Size = New System.Drawing.Size(275, 23)
        Me.TextBoxKodeVoucher.TabIndex = 532
        '
        'Label157
        '
        Me.Label157.AutoSize = True
        Me.Label157.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label157.Location = New System.Drawing.Point(120, 20)
        Me.Label157.Name = "Label157"
        Me.Label157.Size = New System.Drawing.Size(108, 17)
        Me.Label157.TabIndex = 528
        Me.Label157.Text = "Scan QR Pasien :"
        '
        'GridControlPaket
        '
        Me.GridControlPaket.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControlPaket.EmbeddedNavigator.Name = ""
        Me.GridControlPaket.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.GridControlPaket.Location = New System.Drawing.Point(0, 0)
        Me.GridControlPaket.MainView = Me.GridViewPaket
        Me.GridControlPaket.Name = "GridControlPaket"
        Me.GridControlPaket.Size = New System.Drawing.Size(838, 299)
        Me.GridControlPaket.TabIndex = 186
        Me.GridControlPaket.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewPaket})
        '
        'GridViewPaket
        '
        Me.GridViewPaket.GridControl = Me.GridControlPaket
        Me.GridViewPaket.Name = "GridViewPaket"
        Me.GridViewPaket.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridViewPaket.OptionsView.ShowGroupPanel = False
        Me.GridViewPaket.OptionsView.ShowIndicator = False
        Me.GridViewPaket.PaintStyleName = "Skin"
        '
        'ButtonBatal
        '
        Me.ButtonBatal.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonBatal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonBatal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonBatal.Dock = System.Windows.Forms.DockStyle.Right
        Me.ButtonBatal.FlatAppearance.BorderSize = 0
        Me.ButtonBatal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonBatal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonBatal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonBatal.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonBatal.ForeColor = System.Drawing.Color.White
        Me.ButtonBatal.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_cancel_24
        Me.ButtonBatal.Location = New System.Drawing.Point(488, 0)
        Me.ButtonBatal.Name = "ButtonBatal"
        Me.ButtonBatal.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.ButtonBatal.Size = New System.Drawing.Size(125, 43)
        Me.ButtonBatal.TabIndex = 7
        Me.ButtonBatal.Text = "  Batal"
        Me.ButtonBatal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonBatal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonBatal.UseVisualStyleBackColor = False
        '
        'ButtonSimpan
        '
        Me.ButtonSimpan.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSimpan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonSimpan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonSimpan.Dock = System.Windows.Forms.DockStyle.Right
        Me.ButtonSimpan.FlatAppearance.BorderSize = 0
        Me.ButtonSimpan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSimpan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSimpan.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSimpan.ForeColor = System.Drawing.Color.White
        Me.ButtonSimpan.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_send_24
        Me.ButtonSimpan.Location = New System.Drawing.Point(613, 0)
        Me.ButtonSimpan.Name = "ButtonSimpan"
        Me.ButtonSimpan.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.ButtonSimpan.Size = New System.Drawing.Size(225, 43)
        Me.ButtonSimpan.TabIndex = 5
        Me.ButtonSimpan.Text = "  Simpan Paket Pasien"
        Me.ButtonSimpan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonSimpan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonSimpan.UseVisualStyleBackColor = False
        '
        'DialogBoxPaketTindakan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(838, 448)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PanelTop)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DialogBoxPaketTindakan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Panel1.ResumeLayout(False)
        Me.SplitContainerMainMenu.Panel1.ResumeLayout(False)
        Me.SplitContainerMainMenu.Panel2.ResumeLayout(False)
        Me.SplitContainerMainMenu.ResumeLayout(False)
        Me.SplitContainerPaket.Panel1.ResumeLayout(False)
        Me.SplitContainerPaket.Panel1.PerformLayout()
        Me.SplitContainerPaket.Panel2.ResumeLayout(False)
        Me.SplitContainerPaket.ResumeLayout(False)
        CType(Me.GridControlPaket, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewPaket, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents SplitContainerMainMenu As System.Windows.Forms.SplitContainer
    Friend WithEvents ButtonSimpan As System.Windows.Forms.Button
    Friend WithEvents ButtonBatal As System.Windows.Forms.Button
    Friend WithEvents SplitContainerPaket As System.Windows.Forms.SplitContainer
    Friend WithEvents Label157 As System.Windows.Forms.Label
    Private WithEvents GridControlPaket As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewPaket As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TextBoxKodeVoucher As System.Windows.Forms.TextBox
    Friend WithEvents ButtonFindPaket As System.Windows.Forms.Button
End Class
