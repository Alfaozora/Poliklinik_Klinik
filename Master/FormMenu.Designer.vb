<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMenu
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
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txformidpast = New System.Windows.Forms.TextBox
        Me.txformket = New System.Windows.Forms.TextBox
        Me.txformid = New System.Windows.Forms.TextBox
        Me.butfindform = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.txformnama = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.gridtindakan = New DevExpress.XtraGrid.GridControl
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.gridtindakan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.SaveToolStripMenuItem, Me.CloseToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(636, 24)
        Me.MenuStrip1.TabIndex = 105
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
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txformidpast)
        Me.GroupBox1.Controls.Add(Me.txformket)
        Me.GroupBox1.Controls.Add(Me.txformid)
        Me.GroupBox1.Controls.Add(Me.butfindform)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txformnama)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(636, 136)
        Me.GroupBox1.TabIndex = 106
        Me.GroupBox1.TabStop = False
        '
        'txformidpast
        '
        Me.txformidpast.Enabled = False
        Me.txformidpast.Location = New System.Drawing.Point(233, 13)
        Me.txformidpast.Name = "txformidpast"
        Me.txformidpast.Size = New System.Drawing.Size(96, 20)
        Me.txformidpast.TabIndex = 130
        Me.txformidpast.Visible = False
        '
        'txformket
        '
        Me.txformket.Location = New System.Drawing.Point(98, 65)
        Me.txformket.Multiline = True
        Me.txformket.Name = "txformket"
        Me.txformket.Size = New System.Drawing.Size(284, 58)
        Me.txformket.TabIndex = 129
        '
        'txformid
        '
        Me.txformid.Location = New System.Drawing.Point(98, 13)
        Me.txformid.Name = "txformid"
        Me.txformid.Size = New System.Drawing.Size(96, 20)
        Me.txformid.TabIndex = 126
        '
        'butfindform
        '
        Me.butfindform.Location = New System.Drawing.Point(200, 11)
        Me.butfindform.Name = "butfindform"
        Me.butfindform.Size = New System.Drawing.Size(27, 23)
        Me.butfindform.TabIndex = 106
        Me.butfindform.Text = "..."
        Me.butfindform.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(30, 68)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(62, 13)
        Me.Label11.TabIndex = 118
        Me.Label11.Text = "Keterangan"
        '
        'txformnama
        '
        Me.txformnama.Location = New System.Drawing.Point(98, 39)
        Me.txformnama.Name = "txformnama"
        Me.txformnama.Size = New System.Drawing.Size(284, 20)
        Me.txformnama.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 68
        Me.Label1.Text = "Nama Menu"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 61
        Me.Label2.Text = "No Urut Menu"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.gridtindakan)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox5.Location = New System.Drawing.Point(0, 160)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(636, 351)
        Me.GroupBox5.TabIndex = 107
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Tindakan"
        '
        'gridtindakan
        '
        Me.gridtindakan.Dock = System.Windows.Forms.DockStyle.Fill
        '
        '
        '
        Me.gridtindakan.EmbeddedNavigator.Name = ""
        Me.gridtindakan.Location = New System.Drawing.Point(3, 16)
        Me.gridtindakan.MainView = Me.GridView2
        Me.gridtindakan.Name = "gridtindakan"
        Me.gridtindakan.Size = New System.Drawing.Size(630, 332)
        Me.gridtindakan.TabIndex = 1
        Me.gridtindakan.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.gridtindakan
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsView.ShowAutoFilterRow = True
        '
        'FormMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(636, 511)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "FormMenu"
        Me.Text = "FormMenu"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.gridtindakan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txformid As System.Windows.Forms.TextBox
    Friend WithEvents butfindform As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txformnama As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents gridtindakan As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents txformket As System.Windows.Forms.TextBox
    Friend WithEvents txformidpast As System.Windows.Forms.TextBox
End Class
