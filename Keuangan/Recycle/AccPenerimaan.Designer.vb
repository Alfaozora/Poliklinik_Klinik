<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AccPenerimaan
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
        Me.butsaved = New System.Windows.Forms.Button
        Me.butclear = New System.Windows.Forms.Button
        Me.butdisplay = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtprocess = New System.Windows.Forms.DateTimePicker
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.gridpoli = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.gridpoli, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.butsaved)
        Me.GroupBox1.Controls.Add(Me.butclear)
        Me.GroupBox1.Controls.Add(Me.butdisplay)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtprocess)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(924, 55)
        Me.GroupBox1.TabIndex = 113
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Display"
        '
        'butsaved
        '
        Me.butsaved.Cursor = System.Windows.Forms.Cursors.Hand
        Me.butsaved.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butsaved.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_save
        Me.butsaved.Location = New System.Drawing.Point(353, 12)
        Me.butsaved.Name = "butsaved"
        Me.butsaved.Size = New System.Drawing.Size(100, 36)
        Me.butsaved.TabIndex = 114
        Me.butsaved.UseVisualStyleBackColor = True
        '
        'butclear
        '
        Me.butclear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.butclear.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butclear.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butclear.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_kosong
        Me.butclear.Location = New System.Drawing.Point(459, 13)
        Me.butclear.Name = "butclear"
        Me.butclear.Size = New System.Drawing.Size(100, 36)
        Me.butclear.TabIndex = 113
        Me.butclear.Text = "CLEAR"
        Me.butclear.UseVisualStyleBackColor = True
        Me.butclear.Visible = False
        '
        'butdisplay
        '
        Me.butdisplay.Cursor = System.Windows.Forms.Cursors.Hand
        Me.butdisplay.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butdisplay.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_cari
        Me.butdisplay.Location = New System.Drawing.Point(247, 12)
        Me.butdisplay.Name = "butdisplay"
        Me.butdisplay.Size = New System.Drawing.Size(100, 36)
        Me.butdisplay.TabIndex = 112
        Me.butdisplay.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 13)
        Me.Label1.TabIndex = 111
        Me.Label1.Text = "Lap. Total Penerimaan"
        '
        'dtprocess
        '
        Me.dtprocess.CustomFormat = "dd-MMM-yyyy"
        Me.dtprocess.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtprocess.Location = New System.Drawing.Point(132, 19)
        Me.dtprocess.Name = "dtprocess"
        Me.dtprocess.Size = New System.Drawing.Size(109, 20)
        Me.dtprocess.TabIndex = 110
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.gridpoli)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 55)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(924, 444)
        Me.GroupBox2.TabIndex = 114
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detail"
        '
        'gridpoli
        '
        Me.gridpoli.Dock = System.Windows.Forms.DockStyle.Fill
        '
        '
        '
        Me.gridpoli.EmbeddedNavigator.Name = ""
        Me.gridpoli.Location = New System.Drawing.Point(3, 16)
        Me.gridpoli.MainView = Me.GridView1
        Me.gridpoli.Name = "gridpoli"
        Me.gridpoli.Size = New System.Drawing.Size(918, 425)
        Me.gridpoli.TabIndex = 1
        Me.gridpoli.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.gridpoli
        Me.GridView1.Name = "GridView1"
        '
        'AccPenerimaan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(924, 499)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "AccPenerimaan"
        Me.Text = "AccPenerimaan"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.gridpoli, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents butclear As System.Windows.Forms.Button
    Friend WithEvents butdisplay As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtprocess As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents butsaved As System.Windows.Forms.Button
    Private WithEvents gridpoli As DevExpress.XtraGrid.GridControl
    Private WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
