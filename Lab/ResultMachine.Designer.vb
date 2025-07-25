<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ResultMachine
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ResultMachine))
        Me.groupcustomer = New System.Windows.Forms.GroupBox
        Me.butnama = New System.Windows.Forms.TextBox
        Me.buttindakanid = New System.Windows.Forms.TextBox
        Me.txnourutan = New System.Windows.Forms.TextBox
        Me.txcustnama = New System.Windows.Forms.TextBox
        Me.dtcusttgllhr = New System.Windows.Forms.DateTimePicker
        Me.txcustumur = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabLab = New System.Windows.Forms.TabPage
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.gridlab = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.cmbsend = New System.Windows.Forms.Button
        Me.groupcustomer.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabLab.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.gridlab, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupcustomer
        '
        Me.groupcustomer.Controls.Add(Me.butnama)
        Me.groupcustomer.Controls.Add(Me.buttindakanid)
        Me.groupcustomer.Controls.Add(Me.txnourutan)
        Me.groupcustomer.Controls.Add(Me.txcustnama)
        Me.groupcustomer.Controls.Add(Me.dtcusttgllhr)
        Me.groupcustomer.Controls.Add(Me.txcustumur)
        Me.groupcustomer.Controls.Add(Me.Label4)
        Me.groupcustomer.Controls.Add(Me.Label3)
        Me.groupcustomer.Controls.Add(Me.Label2)
        Me.groupcustomer.Controls.Add(Me.Label1)
        Me.groupcustomer.Dock = System.Windows.Forms.DockStyle.Top
        Me.groupcustomer.Location = New System.Drawing.Point(0, 0)
        Me.groupcustomer.Name = "groupcustomer"
        Me.groupcustomer.Size = New System.Drawing.Size(881, 85)
        Me.groupcustomer.TabIndex = 87
        Me.groupcustomer.TabStop = False
        Me.groupcustomer.Text = "Customer Detail"
        '
        'butnama
        '
        Me.butnama.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.butnama.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butnama.Location = New System.Drawing.Point(102, 50)
        Me.butnama.Name = "butnama"
        Me.butnama.ReadOnly = True
        Me.butnama.Size = New System.Drawing.Size(100, 21)
        Me.butnama.TabIndex = 188
        '
        'buttindakanid
        '
        Me.buttindakanid.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.buttindakanid.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.buttindakanid.Location = New System.Drawing.Point(102, 20)
        Me.buttindakanid.Name = "buttindakanid"
        Me.buttindakanid.ReadOnly = True
        Me.buttindakanid.Size = New System.Drawing.Size(100, 21)
        Me.buttindakanid.TabIndex = 186
        '
        'txnourutan
        '
        Me.txnourutan.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txnourutan.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txnourutan.Location = New System.Drawing.Point(205, 20)
        Me.txnourutan.Name = "txnourutan"
        Me.txnourutan.ReadOnly = True
        Me.txnourutan.Size = New System.Drawing.Size(223, 21)
        Me.txnourutan.TabIndex = 102
        '
        'txcustnama
        '
        Me.txcustnama.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txcustnama.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txcustnama.Location = New System.Drawing.Point(205, 50)
        Me.txcustnama.Name = "txcustnama"
        Me.txcustnama.ReadOnly = True
        Me.txcustnama.Size = New System.Drawing.Size(223, 21)
        Me.txcustnama.TabIndex = 61
        '
        'dtcusttgllhr
        '
        Me.dtcusttgllhr.CustomFormat = "dd-MMM-yyyy"
        Me.dtcusttgllhr.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtcusttgllhr.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtcusttgllhr.Location = New System.Drawing.Point(527, 22)
        Me.dtcusttgllhr.Name = "dtcusttgllhr"
        Me.dtcusttgllhr.Size = New System.Drawing.Size(133, 21)
        Me.dtcusttgllhr.TabIndex = 60
        '
        'txcustumur
        '
        Me.txcustumur.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txcustumur.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txcustumur.Location = New System.Drawing.Point(527, 50)
        Me.txcustumur.Name = "txcustumur"
        Me.txcustumur.ReadOnly = True
        Me.txcustumur.Size = New System.Drawing.Size(133, 21)
        Me.txcustumur.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(479, 53)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 16)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Umur"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(456, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Tgl Lahir"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(51, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 16)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nama"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Transaksi ID"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabLab)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 85)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(881, 356)
        Me.TabControl1.TabIndex = 105
        '
        'TabLab
        '
        Me.TabLab.Controls.Add(Me.GroupBox7)
        Me.TabLab.Location = New System.Drawing.Point(4, 22)
        Me.TabLab.Name = "TabLab"
        Me.TabLab.Padding = New System.Windows.Forms.Padding(3)
        Me.TabLab.Size = New System.Drawing.Size(873, 330)
        Me.TabLab.TabIndex = 3
        Me.TabLab.Text = "Data Mesin"
        Me.TabLab.UseVisualStyleBackColor = True
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.gridlab)
        Me.GroupBox7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox7.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(867, 324)
        Me.GroupBox7.TabIndex = 2
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Mesin"
        '
        'gridlab
        '
        Me.gridlab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridlab.EmbeddedNavigator.Name = ""
        Me.gridlab.Location = New System.Drawing.Point(3, 16)
        Me.gridlab.MainView = Me.GridView1
        Me.gridlab.Name = "gridlab"
        Me.gridlab.Size = New System.Drawing.Size(861, 305)
        Me.gridlab.TabIndex = 2
        Me.gridlab.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.gridlab
        Me.GridView1.Name = "GridView1"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.cmbsend)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox3.Location = New System.Drawing.Point(0, 441)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(881, 49)
        Me.GroupBox3.TabIndex = 106
        Me.GroupBox3.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(771, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(98, 23)
        Me.Button1.TabIndex = 189
        Me.Button1.Text = "Updt vrs Lama"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmbsend
        '
        Me.cmbsend.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.cmbsend.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmbsend.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbsend.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_download
        Me.cmbsend.Location = New System.Drawing.Point(386, 8)
        Me.cmbsend.Name = "cmbsend"
        Me.cmbsend.Size = New System.Drawing.Size(100, 36)
        Me.cmbsend.TabIndex = 67
        Me.cmbsend.UseVisualStyleBackColor = True
        '
        'ResultMachine
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(881, 490)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.groupcustomer)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ResultMachine"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Download Hasil"
        Me.groupcustomer.ResumeLayout(False)
        Me.groupcustomer.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabLab.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        CType(Me.gridlab, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents groupcustomer As System.Windows.Forms.GroupBox
    'Friend WithEvents butnama As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents txcustnama As System.Windows.Forms.TextBox
    Friend WithEvents dtcusttgllhr As System.Windows.Forms.DateTimePicker
    Friend WithEvents txcustumur As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    'Friend WithEvents buttindakanid As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabLab As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbsend As System.Windows.Forms.Button
    Friend WithEvents txnourutan As System.Windows.Forms.TextBox
    Friend WithEvents buttindakanid As System.Windows.Forms.TextBox
    Private WithEvents gridlab As DevExpress.XtraGrid.GridControl
    Friend WithEvents butnama As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Private WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
End Class
