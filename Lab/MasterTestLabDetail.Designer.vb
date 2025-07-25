<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MasterTestLabDetail
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.buttindakanid = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.cmbtindakangroup = New System.Windows.Forms.ComboBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtindakannama = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txintsatuan = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.txintpria = New System.Windows.Forms.TextBox
        Me.txintwanita = New System.Windows.Forms.TextBox
        Me.butdetailid = New System.Windows.Forms.TextBox
        Me.butfinddokter = New System.Windows.Forms.Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.txsatuan = New System.Windows.Forms.TextBox
        Me.chtindakanclosed = New System.Windows.Forms.CheckBox
        Me.butclear = New System.Windows.Forms.Button
        Me.butdelete = New System.Windows.Forms.Button
        Me.butsave = New System.Windows.Forms.Button
        Me.numdetailurut = New System.Windows.Forms.NumericUpDown
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txdetailresultpria = New System.Windows.Forms.TextBox
        Me.txdetailresultwanita = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmbdetailgroup = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txdetailket = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.GridControlx = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GroupBox1.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.numdetailurut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControlx, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.buttindakanid)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.cmbtindakangroup)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtindakannama)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(649, 70)
        Me.GroupBox1.TabIndex = 111
        Me.GroupBox1.TabStop = False
        '
        'buttindakanid
        '
        Me.buttindakanid.Enabled = False
        Me.buttindakanid.Location = New System.Drawing.Point(83, 13)
        Me.buttindakanid.Name = "buttindakanid"
        Me.buttindakanid.Size = New System.Drawing.Size(47, 20)
        Me.buttindakanid.TabIndex = 128
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(136, 11)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(27, 23)
        Me.Button1.TabIndex = 127
        Me.Button1.Text = "..."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmbtindakangroup
        '
        Me.cmbtindakangroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbtindakangroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbtindakangroup.Enabled = False
        Me.cmbtindakangroup.FormattingEnabled = True
        Me.cmbtindakangroup.Location = New System.Drawing.Point(83, 39)
        Me.cmbtindakangroup.Name = "cmbtindakangroup"
        Me.cmbtindakangroup.Size = New System.Drawing.Size(308, 21)
        Me.cmbtindakangroup.TabIndex = 122
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 71
        Me.Label3.Text = "Group Jenis"
        '
        'txtindakannama
        '
        Me.txtindakannama.Enabled = False
        Me.txtindakannama.Location = New System.Drawing.Point(167, 13)
        Me.txtindakannama.Name = "txtindakannama"
        Me.txtindakannama.Size = New System.Drawing.Size(469, 20)
        Me.txtindakannama.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 61
        Me.Label2.Text = "Tindakan ID"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.CloseToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(649, 24)
        Me.MenuStrip1.TabIndex = 110
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txintsatuan)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.txintpria)
        Me.GroupBox2.Controls.Add(Me.txintwanita)
        Me.GroupBox2.Controls.Add(Me.butdetailid)
        Me.GroupBox2.Controls.Add(Me.butfinddokter)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txsatuan)
        Me.GroupBox2.Controls.Add(Me.chtindakanclosed)
        Me.GroupBox2.Controls.Add(Me.butclear)
        Me.GroupBox2.Controls.Add(Me.butdelete)
        Me.GroupBox2.Controls.Add(Me.butsave)
        Me.GroupBox2.Controls.Add(Me.numdetailurut)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txdetailresultpria)
        Me.GroupBox2.Controls.Add(Me.txdetailresultwanita)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cmbdetailgroup)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txdetailket)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 94)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(649, 256)
        Me.GroupBox2.TabIndex = 112
        Me.GroupBox2.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(352, 147)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(102, 13)
        Me.Label12.TabIndex = 143
        Me.Label12.Text = "Satuan International"
        '
        'txintsatuan
        '
        Me.txintsatuan.Location = New System.Drawing.Point(461, 144)
        Me.txintsatuan.Name = "txintsatuan"
        Me.txintsatuan.Size = New System.Drawing.Size(176, 20)
        Me.txintsatuan.TabIndex = 142
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(10, 199)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(102, 13)
        Me.Label10.TabIndex = 141
        Me.Label10.Text = "International Wanita"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(10, 173)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(86, 13)
        Me.Label11.TabIndex = 140
        Me.Label11.Text = "International Pria"
        '
        'txintpria
        '
        Me.txintpria.Location = New System.Drawing.Point(115, 170)
        Me.txintpria.Name = "txintpria"
        Me.txintpria.Size = New System.Drawing.Size(521, 20)
        Me.txintpria.TabIndex = 139
        '
        'txintwanita
        '
        Me.txintwanita.Location = New System.Drawing.Point(115, 196)
        Me.txintwanita.Name = "txintwanita"
        Me.txintwanita.Size = New System.Drawing.Size(521, 20)
        Me.txintwanita.TabIndex = 138
        '
        'butdetailid
        '
        Me.butdetailid.Enabled = False
        Me.butdetailid.Location = New System.Drawing.Point(83, 11)
        Me.butdetailid.Name = "butdetailid"
        Me.butdetailid.Size = New System.Drawing.Size(78, 20)
        Me.butdetailid.TabIndex = 129
        '
        'butfinddokter
        '
        Me.butfinddokter.Location = New System.Drawing.Point(167, 11)
        Me.butfinddokter.Name = "butfinddokter"
        Me.butfinddokter.Size = New System.Drawing.Size(27, 23)
        Me.butfinddokter.TabIndex = 137
        Me.butfinddokter.Text = "..."
        Me.butfinddokter.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(413, 42)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 13)
        Me.Label9.TabIndex = 136
        Me.Label9.Text = "Satuan"
        '
        'txsatuan
        '
        Me.txsatuan.Location = New System.Drawing.Point(460, 39)
        Me.txsatuan.Name = "txsatuan"
        Me.txsatuan.Size = New System.Drawing.Size(176, 20)
        Me.txsatuan.TabIndex = 135
        '
        'chtindakanclosed
        '
        Me.chtindakanclosed.AutoSize = True
        Me.chtindakanclosed.Location = New System.Drawing.Point(90, 228)
        Me.chtindakanclosed.Name = "chtindakanclosed"
        Me.chtindakanclosed.Size = New System.Drawing.Size(63, 17)
        Me.chtindakanclosed.TabIndex = 134
        Me.chtindakanclosed.Text = "Deleted"
        Me.chtindakanclosed.UseVisualStyleBackColor = True
        '
        'butclear
        '
        Me.butclear.Location = New System.Drawing.Point(393, 222)
        Me.butclear.Name = "butclear"
        Me.butclear.Size = New System.Drawing.Size(75, 23)
        Me.butclear.TabIndex = 133
        Me.butclear.Text = "Clear"
        Me.butclear.UseVisualStyleBackColor = True
        '
        'butdelete
        '
        Me.butdelete.Location = New System.Drawing.Point(491, 222)
        Me.butdelete.Name = "butdelete"
        Me.butdelete.Size = New System.Drawing.Size(75, 23)
        Me.butdelete.TabIndex = 132
        Me.butdelete.Text = "Delete"
        Me.butdelete.UseVisualStyleBackColor = True
        '
        'butsave
        '
        Me.butsave.Location = New System.Drawing.Point(293, 222)
        Me.butsave.Name = "butsave"
        Me.butsave.Size = New System.Drawing.Size(75, 23)
        Me.butsave.TabIndex = 131
        Me.butsave.Text = "Save"
        Me.butsave.UseVisualStyleBackColor = True
        '
        'numdetailurut
        '
        Me.numdetailurut.Location = New System.Drawing.Point(338, 39)
        Me.numdetailurut.Name = "numdetailurut"
        Me.numdetailurut.Size = New System.Drawing.Size(49, 20)
        Me.numdetailurut.TabIndex = 130
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 121)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 13)
        Me.Label7.TabIndex = 129
        Me.Label7.Text = "Result Wanita"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 95)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 13)
        Me.Label8.TabIndex = 128
        Me.Label8.Text = "Result Pria"
        '
        'txdetailresultpria
        '
        Me.txdetailresultpria.Location = New System.Drawing.Point(115, 92)
        Me.txdetailresultpria.Name = "txdetailresultpria"
        Me.txdetailresultpria.Size = New System.Drawing.Size(521, 20)
        Me.txdetailresultpria.TabIndex = 127
        '
        'txdetailresultwanita
        '
        Me.txdetailresultwanita.Location = New System.Drawing.Point(115, 118)
        Me.txdetailresultwanita.Name = "txdetailresultwanita"
        Me.txdetailresultwanita.Size = New System.Drawing.Size(521, 20)
        Me.txdetailresultwanita.TabIndex = 126
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 69)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 125
        Me.Label6.Text = "Detail Ket"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(276, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(56, 13)
        Me.Label5.TabIndex = 124
        Me.Label5.Text = "No Urutan"
        '
        'cmbdetailgroup
        '
        Me.cmbdetailgroup.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbdetailgroup.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbdetailgroup.FormattingEnabled = True
        Me.cmbdetailgroup.Location = New System.Drawing.Point(83, 39)
        Me.cmbdetailgroup.Name = "cmbdetailgroup"
        Me.cmbdetailgroup.Size = New System.Drawing.Size(169, 21)
        Me.cmbdetailgroup.TabIndex = 122
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "GroupDetail"
        '
        'txdetailket
        '
        Me.txdetailket.Location = New System.Drawing.Point(83, 66)
        Me.txdetailket.Name = "txdetailket"
        Me.txdetailket.Size = New System.Drawing.Size(553, 20)
        Me.txdetailket.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 13)
        Me.Label4.TabIndex = 61
        Me.Label4.Text = "Detail ID"
        '
        'GridControlx
        '
        Me.GridControlx.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControlx.EmbeddedNavigator.Name = ""
        Me.GridControlx.Location = New System.Drawing.Point(0, 350)
        Me.GridControlx.MainView = Me.GridView1
        Me.GridControlx.Name = "GridControlx"
        Me.GridControlx.Size = New System.Drawing.Size(649, 120)
        Me.GridControlx.TabIndex = 113
        Me.GridControlx.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControlx
        Me.GridView1.Name = "GridView1"
        '
        'MasterTestLabDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(649, 470)
        Me.Controls.Add(Me.GridControlx)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "MasterTestLabDetail"
        Me.Text = "MasterTestLabDetail"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.numdetailurut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControlx, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    'Friend WithEvents buttindakanid As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents cmbtindakangroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtindakannama As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    'Friend WithEvents butdetailid As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents cmbdetailgroup As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txdetailket As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txdetailresultpria As System.Windows.Forms.TextBox
    Friend WithEvents txdetailresultwanita As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents numdetailurut As System.Windows.Forms.NumericUpDown
    Friend WithEvents butclear As System.Windows.Forms.Button
    Friend WithEvents butdelete As System.Windows.Forms.Button
    Friend WithEvents butsave As System.Windows.Forms.Button
    Friend WithEvents chtindakanclosed As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txsatuan As System.Windows.Forms.TextBox
    Friend WithEvents butfinddokter As System.Windows.Forms.Button
    Friend WithEvents buttindakanid As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents butdetailid As System.Windows.Forms.TextBox
    Private WithEvents GridControlx As DevExpress.XtraGrid.GridControl
    Private WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txintpria As System.Windows.Forms.TextBox
    Friend WithEvents txintwanita As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txintsatuan As System.Windows.Forms.TextBox
End Class
