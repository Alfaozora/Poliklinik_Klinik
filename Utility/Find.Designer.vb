<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Find
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Find))
        Me.txket = New System.Windows.Forms.TextBox
        Me.cmbkriteria = New System.Windows.Forms.ComboBox
        Me.cmbcols = New System.Windows.Forms.ComboBox
        Me.PanelTop = New System.Windows.Forms.Panel
        Me.btnClose = New System.Windows.Forms.Button
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.ButtonCari = New System.Windows.Forms.Button
        Me.SplitContainerPencarianData = New System.Windows.Forms.SplitContainer
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.GridControlListData = New DevExpress.XtraGrid.GridControl
        Me.GridViewListData = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.ButtonSave = New System.Windows.Forms.Button
        Me.PanelTop.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SplitContainerPencarianData.Panel1.SuspendLayout()
        Me.SplitContainerPencarianData.Panel2.SuspendLayout()
        Me.SplitContainerPencarianData.SuspendLayout()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.GridControlListData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewListData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txket
        '
        Me.txket.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txket.Location = New System.Drawing.Point(209, 11)
        Me.txket.Name = "txket"
        Me.txket.Size = New System.Drawing.Size(447, 25)
        Me.txket.TabIndex = 0
        '
        'cmbkriteria
        '
        Me.cmbkriteria.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbkriteria.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbkriteria.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.cmbkriteria.FormattingEnabled = True
        Me.cmbkriteria.Items.AddRange(New Object() {"Like", "=", ">=", "<=", "<>"})
        Me.cmbkriteria.Location = New System.Drawing.Point(137, 11)
        Me.cmbkriteria.Name = "cmbkriteria"
        Me.cmbkriteria.Size = New System.Drawing.Size(66, 25)
        Me.cmbkriteria.TabIndex = 1
        '
        'cmbcols
        '
        Me.cmbcols.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbcols.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbcols.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.cmbcols.FormattingEnabled = True
        Me.cmbcols.Location = New System.Drawing.Point(10, 11)
        Me.cmbcols.Name = "cmbcols"
        Me.cmbcols.Size = New System.Drawing.Size(121, 25)
        Me.cmbcols.TabIndex = 2
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.PanelTop.Controls.Add(Me.btnClose)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(794, 35)
        Me.PanelTop.TabIndex = 8
        '
        'btnClose
        '
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(754, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(40, 35)
        Me.btnClose.TabIndex = 281
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(246, Byte), Integer), CType(CType(241, Byte), Integer), CType(CType(241, Byte), Integer))
        Me.Panel3.Controls.Add(Me.ButtonCari)
        Me.Panel3.Controls.Add(Me.cmbcols)
        Me.Panel3.Controls.Add(Me.cmbkriteria)
        Me.Panel3.Controls.Add(Me.txket)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(794, 45)
        Me.Panel3.TabIndex = 1
        '
        'ButtonCari
        '
        Me.ButtonCari.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCari.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonCari.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonCari.FlatAppearance.BorderSize = 0
        Me.ButtonCari.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCari.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonCari.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCari.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonCari.ForeColor = System.Drawing.Color.White
        Me.ButtonCari.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_search_24
        Me.ButtonCari.Location = New System.Drawing.Point(662, 6)
        Me.ButtonCari.Name = "ButtonCari"
        Me.ButtonCari.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonCari.Size = New System.Drawing.Size(120, 35)
        Me.ButtonCari.TabIndex = 279
        Me.ButtonCari.Text = " Cari Data"
        Me.ButtonCari.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonCari.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonCari.UseVisualStyleBackColor = False
        '
        'SplitContainerPencarianData
        '
        Me.SplitContainerPencarianData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerPencarianData.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainerPencarianData.IsSplitterFixed = True
        Me.SplitContainerPencarianData.Location = New System.Drawing.Point(0, 35)
        Me.SplitContainerPencarianData.Name = "SplitContainerPencarianData"
        Me.SplitContainerPencarianData.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerPencarianData.Panel1
        '
        Me.SplitContainerPencarianData.Panel1.AutoScroll = True
        Me.SplitContainerPencarianData.Panel1.Controls.Add(Me.SplitContainer1)
        '
        'SplitContainerPencarianData.Panel2
        '
        Me.SplitContainerPencarianData.Panel2.AutoScroll = True
        Me.SplitContainerPencarianData.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.SplitContainerPencarianData.Panel2.Controls.Add(Me.ButtonSave)
        Me.SplitContainerPencarianData.Size = New System.Drawing.Size(794, 434)
        Me.SplitContainerPencarianData.SplitterDistance = 384
        Me.SplitContainerPencarianData.SplitterWidth = 5
        Me.SplitContainerPencarianData.TabIndex = 501
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.AutoScroll = True
        Me.SplitContainer1.Panel1.Controls.Add(Me.Panel3)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.AutoScroll = True
        Me.SplitContainer1.Panel2.Controls.Add(Me.GridControlListData)
        Me.SplitContainer1.Size = New System.Drawing.Size(794, 384)
        Me.SplitContainer1.SplitterDistance = 45
        Me.SplitContainer1.SplitterWidth = 5
        Me.SplitContainer1.TabIndex = 502
        '
        'GridControlListData
        '
        Me.GridControlListData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControlListData.EmbeddedNavigator.Name = ""
        Me.GridControlListData.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.GridControlListData.Location = New System.Drawing.Point(0, 0)
        Me.GridControlListData.MainView = Me.GridViewListData
        Me.GridControlListData.Name = "GridControlListData"
        Me.GridControlListData.Size = New System.Drawing.Size(794, 334)
        Me.GridControlListData.TabIndex = 1
        Me.GridControlListData.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewListData})
        '
        'GridViewListData
        '
        Me.GridViewListData.GridControl = Me.GridControlListData
        Me.GridViewListData.Name = "GridViewListData"
        Me.GridViewListData.OptionsBehavior.Editable = False
        Me.GridViewListData.OptionsCustomization.AllowGroup = False
        Me.GridViewListData.OptionsView.ShowAutoFilterRow = True
        Me.GridViewListData.OptionsView.ShowGroupPanel = False
        Me.GridViewListData.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowForFocusedRow
        '
        'ButtonSave
        '
        Me.ButtonSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.ButtonSave.FlatAppearance.BorderSize = 0
        Me.ButtonSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSave.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSave.ForeColor = System.Drawing.Color.White
        Me.ButtonSave.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_add_24
        Me.ButtonSave.Location = New System.Drawing.Point(644, 0)
        Me.ButtonSave.Name = "ButtonSave"
        Me.ButtonSave.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.ButtonSave.Size = New System.Drawing.Size(150, 45)
        Me.ButtonSave.TabIndex = 5
        Me.ButtonSave.Text = "  Tambah Data"
        Me.ButtonSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonSave.UseVisualStyleBackColor = False
        '
        'Find
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(794, 469)
        Me.ControlBox = False
        Me.Controls.Add(Me.SplitContainerPencarianData)
        Me.Controls.Add(Me.PanelTop)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Find"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.PanelTop.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.SplitContainerPencarianData.Panel1.ResumeLayout(False)
        Me.SplitContainerPencarianData.Panel2.ResumeLayout(False)
        Me.SplitContainerPencarianData.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.GridControlListData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewListData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txket As System.Windows.Forms.TextBox
    Friend WithEvents cmbkriteria As System.Windows.Forms.ComboBox
    Friend WithEvents cmbcols As System.Windows.Forms.ComboBox
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents ButtonCari As System.Windows.Forms.Button
    Friend WithEvents SplitContainerPencarianData As System.Windows.Forms.SplitContainer
    Friend WithEvents ButtonSave As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents GridControlListData As DevExpress.XtraGrid.GridControl
    Private WithEvents GridViewListData As DevExpress.XtraGrid.Views.Grid.GridView
End Class
