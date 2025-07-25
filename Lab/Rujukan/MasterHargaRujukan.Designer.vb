<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MasterHargaRujukan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MasterHargaRujukan))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.gridtindakan = New DevExpress.XtraGrid.GridControl
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txbiayarujukan = New System.Windows.Forms.TextBox
        Me.txbiayatindakan = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txlabrujukanid = New System.Windows.Forms.TextBox
        Me.butlabrujukan = New System.Windows.Forms.Button
        Me.txlabrujukanket = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtindakanid = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtindakannama = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.MenuStrip1.SuspendLayout()
        CType(Me.gridtindakan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 156)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(621, 10)
        Me.GroupBox1.TabIndex = 108
        Me.GroupBox1.TabStop = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.SaveToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.CloseToolStripMenuItem, Me.PrintToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(621, 24)
        Me.MenuStrip1.TabIndex = 107
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
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.DeleteToolStripMenuItem.Text = "Delete"
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
        'gridtindakan
        '
        Me.gridtindakan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridtindakan.EmbeddedNavigator.Name = ""
        Me.gridtindakan.Location = New System.Drawing.Point(0, 166)
        Me.gridtindakan.MainView = Me.GridView2
        Me.gridtindakan.Name = "gridtindakan"
        Me.gridtindakan.Size = New System.Drawing.Size(621, 339)
        Me.gridtindakan.TabIndex = 106
        Me.gridtindakan.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.GridControl = Me.gridtindakan
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsView.ShowAutoFilterRow = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txbiayarujukan)
        Me.GroupBox3.Controls.Add(Me.txbiayatindakan)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.txlabrujukanid)
        Me.GroupBox3.Controls.Add(Me.butlabrujukan)
        Me.GroupBox3.Controls.Add(Me.txlabrujukanket)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.txtindakanid)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.txtindakannama)
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Location = New System.Drawing.Point(0, 24)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(621, 132)
        Me.GroupBox3.TabIndex = 109
        Me.GroupBox3.TabStop = False
        '
        'txbiayarujukan
        '
        Me.txbiayarujukan.BackColor = System.Drawing.SystemColors.Window
        Me.txbiayarujukan.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txbiayarujukan.Location = New System.Drawing.Point(134, 100)
        Me.txbiayarujukan.Name = "txbiayarujukan"
        Me.txbiayarujukan.Size = New System.Drawing.Size(107, 21)
        Me.txbiayarujukan.TabIndex = 262
        '
        'txbiayatindakan
        '
        Me.txbiayatindakan.BackColor = System.Drawing.SystemColors.Window
        Me.txbiayatindakan.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txbiayatindakan.Location = New System.Drawing.Point(134, 73)
        Me.txbiayatindakan.Name = "txbiayatindakan"
        Me.txbiayatindakan.ReadOnly = True
        Me.txbiayatindakan.Size = New System.Drawing.Size(107, 21)
        Me.txbiayatindakan.TabIndex = 261
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 100)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(119, 18)
        Me.Label2.TabIndex = 260
        Me.Label2.Text = "Harga Rujukan"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(30, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 16)
        Me.Label1.TabIndex = 259
        Me.Label1.Text = "Nama Tindakan"
        '
        'txlabrujukanid
        '
        Me.txlabrujukanid.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txlabrujukanid.Location = New System.Drawing.Point(134, 14)
        Me.txlabrujukanid.Name = "txlabrujukanid"
        Me.txlabrujukanid.Size = New System.Drawing.Size(101, 21)
        Me.txlabrujukanid.TabIndex = 256
        Me.txlabrujukanid.Visible = False
        '
        'butlabrujukan
        '
        Me.butlabrujukan.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butlabrujukan.Location = New System.Drawing.Point(358, 11)
        Me.butlabrujukan.Name = "butlabrujukan"
        Me.butlabrujukan.Size = New System.Drawing.Size(31, 25)
        Me.butlabrujukan.TabIndex = 258
        Me.butlabrujukan.Text = "..."
        Me.butlabrujukan.UseVisualStyleBackColor = True
        '
        'txlabrujukanket
        '
        Me.txlabrujukanket.BackColor = System.Drawing.SystemColors.Window
        Me.txlabrujukanket.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txlabrujukanket.Location = New System.Drawing.Point(134, 14)
        Me.txlabrujukanket.Name = "txlabrujukanket"
        Me.txlabrujukanket.ReadOnly = True
        Me.txlabrujukanket.Size = New System.Drawing.Size(218, 21)
        Me.txlabrujukanket.TabIndex = 257
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(48, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 16)
        Me.Label8.TabIndex = 255
        Me.Label8.Text = "Lab Rujukan"
        '
        'txtindakanid
        '
        Me.txtindakanid.Enabled = False
        Me.txtindakanid.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtindakanid.Location = New System.Drawing.Point(134, 44)
        Me.txtindakanid.Name = "txtindakanid"
        Me.txtindakanid.Size = New System.Drawing.Size(37, 21)
        Me.txtindakanid.TabIndex = 143
        Me.txtindakanid.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(34, 73)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(94, 18)
        Me.Label12.TabIndex = 118
        Me.Label12.Text = "Harga CDC"
        '
        'txtindakannama
        '
        Me.txtindakannama.BackColor = System.Drawing.SystemColors.Window
        Me.txtindakannama.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtindakannama.Location = New System.Drawing.Point(134, 44)
        Me.txtindakannama.Name = "txtindakannama"
        Me.txtindakannama.ReadOnly = True
        Me.txtindakannama.Size = New System.Drawing.Size(218, 21)
        Me.txtindakannama.TabIndex = 2
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold)
        Me.Button1.Location = New System.Drawing.Point(358, 41)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(31, 25)
        Me.Button1.TabIndex = 140
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'MasterHargaRujukan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(621, 505)
        Me.Controls.Add(Me.gridtindakan)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MasterHargaRujukan"
        Me.Text = "Master Harga Rujukan"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.gridtindakan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    'Friend WithEvents txtindakanbiaya As DevExpress.XtraEditors.TextEdit
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents buttindakanid As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    'Friend WithEvents txhargaprt As DevExpress.XtraEditors.TextEdit
    'Friend WithEvents txhargaprh As DevExpress.XtraEditors.TextEdit
    'Friend WithEvents txhargakd As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents gridtindakan As DevExpress.XtraGrid.GridControl
    Private WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtindakannama As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtindakanid As System.Windows.Forms.TextBox
    Friend WithEvents txlabrujukanid As System.Windows.Forms.TextBox
    Friend WithEvents butlabrujukan As System.Windows.Forms.Button
    Friend WithEvents txlabrujukanket As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txbiayatindakan As System.Windows.Forms.TextBox
    Friend WithEvents txbiayarujukan As System.Windows.Forms.TextBox
End Class
