<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form4))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Button1 = New System.Windows.Forms.Button
        Me.NavBarControl1 = New DevExpress.XtraNavBar.NavBarControl
        Me.NavBarGroup1 = New DevExpress.XtraNavBar.NavBarGroup
        Me.NavBarItem1 = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarItem3 = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarItem4 = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarGroup2 = New DevExpress.XtraNavBar.NavBarGroup
        Me.NavBarItem2 = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarItem5 = New DevExpress.XtraNavBar.NavBarItem
        Me.NavBarGroup3 = New DevExpress.XtraNavBar.NavBarGroup
        Me.NavBarGroup4 = New DevExpress.XtraNavBar.NavBarGroup
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TextBoxMessage = New System.Windows.Forms.TextBox
        Me.Button8 = New System.Windows.Forms.Button
        Me.TextBoxNoKartu = New System.Windows.Forms.TextBox
        Me.TextBoxResponseBody = New System.Windows.Forms.TextBox
        Me.Button7 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.SplitContainerAlergiPasien = New System.Windows.Forms.SplitContainer
        Me.ButtonKirimResep = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.GridControlAlergi = New DevExpress.XtraGrid.GridControl
        Me.GridViewAlergi = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        CType(Me.NavBarControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SplitContainerAlergiPasien.Panel1.SuspendLayout()
        Me.SplitContainerAlergiPasien.Panel2.SuspendLayout()
        Me.SplitContainerAlergiPasien.SuspendLayout()
        CType(Me.GridControlAlergi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewAlergi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "icons8_home_48.png")
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(0, 130)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'NavBarControl1
        '
        Me.NavBarControl1.ActiveGroup = Me.NavBarGroup1
        Me.NavBarControl1.Appearance.Background.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.NavBarControl1.Appearance.Background.Options.UseBackColor = True
        Me.NavBarControl1.BackColor = System.Drawing.SystemColors.Control
        Me.NavBarControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NavBarControl1.Groups.AddRange(New DevExpress.XtraNavBar.NavBarGroup() {Me.NavBarGroup1, Me.NavBarGroup2, Me.NavBarGroup3, Me.NavBarGroup4})
        Me.NavBarControl1.Items.AddRange(New DevExpress.XtraNavBar.NavBarItem() {Me.NavBarItem1, Me.NavBarItem2, Me.NavBarItem3, Me.NavBarItem4, Me.NavBarItem5})
        Me.NavBarControl1.Location = New System.Drawing.Point(0, 0)
        Me.NavBarControl1.Name = "NavBarControl1"
        Me.NavBarControl1.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane
        Me.NavBarControl1.Size = New System.Drawing.Size(200, 645)
        Me.NavBarControl1.StoreDefaultPaintStyleName = True
        Me.NavBarControl1.TabIndex = 0
        Me.NavBarControl1.Text = "NavBarControl1"
        '
        'NavBarGroup1
        '
        Me.NavBarGroup1.Appearance.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.NavBarGroup1.Appearance.Options.UseFont = True
        Me.NavBarGroup1.Caption = "Pemeriksaan"
        Me.NavBarGroup1.Expanded = True
        Me.NavBarGroup1.ItemLinks.AddRange(New DevExpress.XtraNavBar.NavBarItemLink() {New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem1), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem3), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem4)})
        Me.NavBarGroup1.Name = "NavBarGroup1"
        Me.NavBarGroup1.SmallImage = CType(resources.GetObject("NavBarGroup1.SmallImage"), System.Drawing.Image)
        '
        'NavBarItem1
        '
        Me.NavBarItem1.Caption = "Pemeriksaan Awal"
        Me.NavBarItem1.Name = "NavBarItem1"
        '
        'NavBarItem3
        '
        Me.NavBarItem3.Caption = "Medis"
        Me.NavBarItem3.Name = "NavBarItem3"
        '
        'NavBarItem4
        '
        Me.NavBarItem4.Caption = "Penandaan Gambar"
        Me.NavBarItem4.Name = "NavBarItem4"
        '
        'NavBarGroup2
        '
        Me.NavBarGroup2.Caption = "NavBarGroup2"
        Me.NavBarGroup2.ItemLinks.AddRange(New DevExpress.XtraNavBar.NavBarItemLink() {New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem2), New DevExpress.XtraNavBar.NavBarItemLink(Me.NavBarItem5)})
        Me.NavBarGroup2.Name = "NavBarGroup2"
        '
        'NavBarItem2
        '
        Me.NavBarItem2.Caption = "NavBarItem2"
        Me.NavBarItem2.Name = "NavBarItem2"
        Me.NavBarItem2.SmallImage = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_add_user_group_30
        '
        'NavBarItem5
        '
        Me.NavBarItem5.Caption = "NavBarItem5"
        Me.NavBarItem5.Name = "NavBarItem5"
        '
        'NavBarGroup3
        '
        Me.NavBarGroup3.Caption = "NavBarGroup3"
        Me.NavBarGroup3.Name = "NavBarGroup3"
        '
        'NavBarGroup4
        '
        Me.NavBarGroup4.Caption = "NavBarGroup4"
        Me.NavBarGroup4.Name = "NavBarGroup4"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.TextBoxMessage)
        Me.Panel1.Controls.Add(Me.Button8)
        Me.Panel1.Controls.Add(Me.TextBoxNoKartu)
        Me.Panel1.Controls.Add(Me.TextBoxResponseBody)
        Me.Panel1.Controls.Add(Me.Button7)
        Me.Panel1.Controls.Add(Me.Button5)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(780, 645)
        Me.Panel1.TabIndex = 1
        '
        'TextBoxMessage
        '
        Me.TextBoxMessage.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxMessage.Location = New System.Drawing.Point(352, 81)
        Me.TextBoxMessage.Multiline = True
        Me.TextBoxMessage.Name = "TextBoxMessage"
        Me.TextBoxMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxMessage.Size = New System.Drawing.Size(275, 112)
        Me.TextBoxMessage.TabIndex = 540
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.Button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button8.FlatAppearance.BorderSize = 0
        Me.Button8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.Button8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Button8.ForeColor = System.Drawing.Color.White
        Me.Button8.Location = New System.Drawing.Point(333, 10)
        Me.Button8.Name = "Button8"
        Me.Button8.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Button8.Size = New System.Drawing.Size(247, 25)
        Me.Button8.TabIndex = 539
        Me.Button8.Text = "Sending WhatsApp"
        Me.Button8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button8.UseVisualStyleBackColor = False
        '
        'TextBoxNoKartu
        '
        Me.TextBoxNoKartu.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxNoKartu.Location = New System.Drawing.Point(439, 41)
        Me.TextBoxNoKartu.Name = "TextBoxNoKartu"
        Me.TextBoxNoKartu.Size = New System.Drawing.Size(141, 25)
        Me.TextBoxNoKartu.TabIndex = 538
        Me.TextBoxNoKartu.Text = "0002039737959"
        '
        'TextBoxResponseBody
        '
        Me.TextBoxResponseBody.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxResponseBody.Location = New System.Drawing.Point(352, 211)
        Me.TextBoxResponseBody.Multiline = True
        Me.TextBoxResponseBody.Name = "TextBoxResponseBody"
        Me.TextBoxResponseBody.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxResponseBody.Size = New System.Drawing.Size(275, 164)
        Me.TextBoxResponseBody.TabIndex = 537
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.Button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button7.FlatAppearance.BorderSize = 0
        Me.Button7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.Button7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Button7.ForeColor = System.Drawing.Color.White
        Me.Button7.Location = New System.Drawing.Point(333, 41)
        Me.Button7.Name = "Button7"
        Me.Button7.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Button7.Size = New System.Drawing.Size(100, 25)
        Me.Button7.TabIndex = 536
        Me.Button7.Text = "I-CARE"
        Me.Button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button7.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(3, 41)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(159, 23)
        Me.Button5.TabIndex = 5
        Me.Button5.Text = "Load Alergi"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(168, 12)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(159, 23)
        Me.Button4.TabIndex = 4
        Me.Button4.Text = "Delete Alergi"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.SplitContainerAlergiPasien)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI Semibold", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(16, 70)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(330, 250)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Alergi Pasien"
        '
        'SplitContainerAlergiPasien
        '
        Me.SplitContainerAlergiPasien.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerAlergiPasien.Location = New System.Drawing.Point(3, 23)
        Me.SplitContainerAlergiPasien.Margin = New System.Windows.Forms.Padding(30)
        Me.SplitContainerAlergiPasien.Name = "SplitContainerAlergiPasien"
        Me.SplitContainerAlergiPasien.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerAlergiPasien.Panel1
        '
        Me.SplitContainerAlergiPasien.Panel1.BackColor = System.Drawing.Color.White
        Me.SplitContainerAlergiPasien.Panel1.Controls.Add(Me.ButtonKirimResep)
        Me.SplitContainerAlergiPasien.Panel1.Controls.Add(Me.Button6)
        '
        'SplitContainerAlergiPasien.Panel2
        '
        Me.SplitContainerAlergiPasien.Panel2.Controls.Add(Me.GridControlAlergi)
        Me.SplitContainerAlergiPasien.Size = New System.Drawing.Size(324, 224)
        Me.SplitContainerAlergiPasien.SplitterDistance = 31
        Me.SplitContainerAlergiPasien.TabIndex = 0
        '
        'ButtonKirimResep
        '
        Me.ButtonKirimResep.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonKirimResep.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonKirimResep.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonKirimResep.FlatAppearance.BorderSize = 0
        Me.ButtonKirimResep.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonKirimResep.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonKirimResep.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonKirimResep.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonKirimResep.ForeColor = System.Drawing.Color.White
        Me.ButtonKirimResep.Location = New System.Drawing.Point(3, 3)
        Me.ButtonKirimResep.Name = "ButtonKirimResep"
        Me.ButtonKirimResep.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonKirimResep.Size = New System.Drawing.Size(100, 25)
        Me.ButtonKirimResep.TabIndex = 535
        Me.ButtonKirimResep.Text = "Tambah Alergi"
        Me.ButtonKirimResep.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonKirimResep.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.Button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.FlatAppearance.BorderSize = 0
        Me.Button6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(236, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(75, Byte), Integer))
        Me.Button6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Button6.ForeColor = System.Drawing.Color.White
        Me.Button6.Location = New System.Drawing.Point(109, 3)
        Me.Button6.Name = "Button6"
        Me.Button6.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Button6.Size = New System.Drawing.Size(75, 25)
        Me.Button6.TabIndex = 536
        Me.Button6.Text = "Hapus"
        Me.Button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button6.UseVisualStyleBackColor = False
        '
        'GridControlAlergi
        '
        Me.GridControlAlergi.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControlAlergi.EmbeddedNavigator.Name = ""
        Me.GridControlAlergi.Location = New System.Drawing.Point(0, 0)
        Me.GridControlAlergi.MainView = Me.GridViewAlergi
        Me.GridControlAlergi.Name = "GridControlAlergi"
        Me.GridControlAlergi.Size = New System.Drawing.Size(324, 189)
        Me.GridControlAlergi.TabIndex = 185
        Me.GridControlAlergi.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewAlergi})
        '
        'GridViewAlergi
        '
        Me.GridViewAlergi.GridControl = Me.GridControlAlergi
        Me.GridViewAlergi.Name = "GridViewAlergi"
        Me.GridViewAlergi.OptionsBehavior.Editable = False
        Me.GridViewAlergi.OptionsSelection.EnableAppearanceFocusedCell = False
        Me.GridViewAlergi.OptionsView.ShowGroupPanel = False
        Me.GridViewAlergi.OptionsView.ShowIndicator = False
        Me.GridViewAlergi.PaintStyleName = "Skin"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(168, 41)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(159, 23)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Open Chrome"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(3, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(159, 23)
        Me.Button2.TabIndex = 0
        Me.Button2.Text = "Tambah Alergi"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.NavBarControl1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(984, 645)
        Me.SplitContainer1.SplitterDistance = 200
        Me.SplitContainer1.TabIndex = 2
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 645)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "Form4"
        Me.Text = "Form4"
        CType(Me.NavBarControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.SplitContainerAlergiPasien.Panel1.ResumeLayout(False)
        Me.SplitContainerAlergiPasien.Panel2.ResumeLayout(False)
        Me.SplitContainerAlergiPasien.ResumeLayout(False)
        CType(Me.GridControlAlergi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewAlergi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents NavBarControl1 As DevExpress.XtraNavBar.NavBarControl
    Friend WithEvents NavBarGroup1 As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents NavBarItem1 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarGroup2 As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents NavBarGroup3 As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents NavBarItem2 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem5 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarGroup4 As DevExpress.XtraNavBar.NavBarGroup
    Friend WithEvents NavBarItem3 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents NavBarItem4 As DevExpress.XtraNavBar.NavBarItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Private WithEvents GridControlAlergi As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewAlergi As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SplitContainerAlergiPasien As System.Windows.Forms.SplitContainer
    Friend WithEvents ButtonKirimResep As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents TextBoxResponseBody As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxNoKartu As System.Windows.Forms.TextBox
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents TextBoxMessage As System.Windows.Forms.TextBox
End Class
