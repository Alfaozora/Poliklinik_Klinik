<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CetakKartu
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
        Me.groupcustomer = New System.Windows.Forms.GroupBox
        Me.butdisplay = New System.Windows.Forms.Button
        Me.rdulang = New System.Windows.Forms.RadioButton
        Me.rdpertama = New System.Windows.Forms.RadioButton
        Me.rdall = New System.Windows.Forms.RadioButton
        Me.dttgl = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.buttindakanid = New DevExpress.XtraEditors.ButtonEdit
        Me.Label1 = New System.Windows.Forms.Label
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.griddata = New DevExpress.XtraGrid.GridControl
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.groupcustomer.SuspendLayout()
        CType(Me.buttindakanid.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.griddata, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'groupcustomer
        '
        Me.groupcustomer.Controls.Add(Me.butdisplay)
        Me.groupcustomer.Controls.Add(Me.rdulang)
        Me.groupcustomer.Controls.Add(Me.rdpertama)
        Me.groupcustomer.Controls.Add(Me.rdall)
        Me.groupcustomer.Controls.Add(Me.dttgl)
        Me.groupcustomer.Controls.Add(Me.Label3)
        Me.groupcustomer.Controls.Add(Me.buttindakanid)
        Me.groupcustomer.Controls.Add(Me.Label1)
        Me.groupcustomer.Dock = System.Windows.Forms.DockStyle.Top
        Me.groupcustomer.Location = New System.Drawing.Point(0, 24)
        Me.groupcustomer.Name = "groupcustomer"
        Me.groupcustomer.Size = New System.Drawing.Size(874, 82)
        Me.groupcustomer.TabIndex = 84
        Me.groupcustomer.TabStop = False
        Me.groupcustomer.Text = "Data Filter"
        '
        'butdisplay
        '
        Me.butdisplay.Location = New System.Drawing.Point(426, 17)
        Me.butdisplay.Name = "butdisplay"
        Me.butdisplay.Size = New System.Drawing.Size(75, 23)
        Me.butdisplay.TabIndex = 64
        Me.butdisplay.Text = "Display"
        Me.butdisplay.UseVisualStyleBackColor = True
        '
        'rdulang
        '
        Me.rdulang.AutoSize = True
        Me.rdulang.Location = New System.Drawing.Point(277, 48)
        Me.rdulang.Name = "rdulang"
        Me.rdulang.Size = New System.Drawing.Size(84, 17)
        Me.rdulang.TabIndex = 63
        Me.rdulang.TabStop = True
        Me.rdulang.Text = "Cetak Ulang"
        Me.rdulang.UseVisualStyleBackColor = True
        '
        'rdpertama
        '
        Me.rdpertama.AutoSize = True
        Me.rdpertama.Location = New System.Drawing.Point(136, 48)
        Me.rdpertama.Name = "rdpertama"
        Me.rdpertama.Size = New System.Drawing.Size(95, 17)
        Me.rdpertama.TabIndex = 62
        Me.rdpertama.TabStop = True
        Me.rdpertama.Text = "Cetak Pertama"
        Me.rdpertama.UseVisualStyleBackColor = True
        '
        'rdall
        '
        Me.rdall.AutoSize = True
        Me.rdall.Location = New System.Drawing.Point(21, 48)
        Me.rdall.Name = "rdall"
        Me.rdall.Size = New System.Drawing.Size(73, 17)
        Me.rdall.TabIndex = 61
        Me.rdall.TabStop = True
        Me.rdall.Text = "Display All"
        Me.rdall.UseVisualStyleBackColor = True
        '
        'dttgl
        '
        Me.dttgl.CustomFormat = "dd-MMM-yyyy"
        Me.dttgl.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dttgl.Location = New System.Drawing.Point(299, 19)
        Me.dttgl.Name = "dttgl"
        Me.dttgl.Size = New System.Drawing.Size(107, 20)
        Me.dttgl.TabIndex = 60
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Enabled = False
        Me.Label3.Location = New System.Drawing.Point(228, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Per Tanggal"
        '
        'buttindakanid
        '
        Me.buttindakanid.EditValue = ""
        Me.buttindakanid.Location = New System.Drawing.Point(74, 19)
        Me.buttindakanid.Name = "buttindakanid"
        Me.buttindakanid.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.buttindakanid.Size = New System.Drawing.Size(126, 20)
        Me.buttindakanid.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(50, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Cabang"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.CloseToolStripMenuItem, Me.PrintToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(874, 24)
        Me.MenuStrip1.TabIndex = 85
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.griddata)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 106)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(874, 398)
        Me.GroupBox1.TabIndex = 86
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detail"
        '
        'griddata
        '
        Me.griddata.Dock = System.Windows.Forms.DockStyle.Fill
        Me.griddata.EmbeddedNavigator.Name = ""
        Me.griddata.Location = New System.Drawing.Point(3, 16)
        Me.griddata.MainView = Me.GridView3
        Me.griddata.Name = "griddata"
        Me.griddata.Size = New System.Drawing.Size(868, 379)
        Me.griddata.TabIndex = 3
        Me.griddata.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.griddata
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsView.ShowFilterPanel = False
        '
        'CetakKartu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(874, 504)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.groupcustomer)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "CetakKartu"
        Me.Text = "CetakKartu"
        Me.groupcustomer.ResumeLayout(False)
        Me.groupcustomer.PerformLayout()
        CType(Me.buttindakanid.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.griddata, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents groupcustomer As System.Windows.Forms.GroupBox
    Friend WithEvents dttgl As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents buttindakanid As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents rdulang As System.Windows.Forms.RadioButton
    Friend WithEvents rdpertama As System.Windows.Forms.RadioButton
    Friend WithEvents rdall As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents griddata As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents butdisplay As System.Windows.Forms.Button
End Class
