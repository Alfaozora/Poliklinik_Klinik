<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Msconfig
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
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.cmbname = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cmbid = New DevExpress.XtraEditors.ButtonEdit
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbtype = New System.Windows.Forms.ComboBox
        Me.chkstr = New DevExpress.XtraEditors.CheckEdit
        Me.chkint = New DevExpress.XtraEditors.CheckEdit
        Me.chkfloat = New DevExpress.XtraEditors.CheckEdit
        Me.chkdate = New DevExpress.XtraEditors.CheckEdit
        Me.chkdelete = New DevExpress.XtraEditors.CheckEdit
        Me.txstr = New DevExpress.XtraEditors.TextEdit
        Me.txint = New DevExpress.XtraEditors.TextEdit
        Me.txfloat = New DevExpress.XtraEditors.TextEdit
        Me.butfind = New System.Windows.Forms.Button
        Me.dtdate = New System.Windows.Forms.DateTimePicker
        Me.MenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.cmbid.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkstr.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkint.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkfloat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkdate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkdelete.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txstr.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txint.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txfloat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.SaveToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.CloseToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(302, 24)
        Me.MenuStrip1.TabIndex = 0
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtdate)
        Me.GroupBox1.Controls.Add(Me.butfind)
        Me.GroupBox1.Controls.Add(Me.txfloat)
        Me.GroupBox1.Controls.Add(Me.txint)
        Me.GroupBox1.Controls.Add(Me.txstr)
        Me.GroupBox1.Controls.Add(Me.chkdelete)
        Me.GroupBox1.Controls.Add(Me.cmbtype)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.cmbname)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbid)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.chkdate)
        Me.GroupBox1.Controls.Add(Me.chkfloat)
        Me.GroupBox1.Controls.Add(Me.chkint)
        Me.GroupBox1.Controls.Add(Me.chkstr)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(302, 231)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detail"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(10, 50)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(75, 13)
        Me.Label12.TabIndex = 125
        Me.Label12.Text = "ConfigName"
        '
        'cmbname
        '
        Me.cmbname.AutoCompleteCustomSource.AddRange(New String() {"TUNAI", "CREDIT", "DEBET"})
        Me.cmbname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbname.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbname.FormattingEnabled = True
        Me.cmbname.Items.AddRange(New Object() {"TUNAI", "CARD", "DEBET"})
        Me.cmbname.Location = New System.Drawing.Point(91, 45)
        Me.cmbname.Name = "cmbname"
        Me.cmbname.Size = New System.Drawing.Size(170, 21)
        Me.cmbname.TabIndex = 124
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 105
        Me.Label2.Text = "ConfigType"
        '
        'cmbid
        '
        Me.cmbid.Location = New System.Drawing.Point(91, 19)
        Me.cmbid.Name = "cmbid"
        Me.cmbid.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton})
        Me.cmbid.Size = New System.Drawing.Size(76, 20)
        Me.cmbid.TabIndex = 104
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(29, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 103
        Me.Label1.Text = "ConfigID"
        '
        'cmbtype
        '
        Me.cmbtype.AutoCompleteCustomSource.AddRange(New String() {"TUNAI", "CREDIT", "DEBET"})
        Me.cmbtype.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbtype.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbtype.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbtype.FormattingEnabled = True
        Me.cmbtype.Items.AddRange(New Object() {"StrValue", "IntValue", "FloatValue", "DateValue"})
        Me.cmbtype.Location = New System.Drawing.Point(91, 72)
        Me.cmbtype.Name = "cmbtype"
        Me.cmbtype.Size = New System.Drawing.Size(76, 21)
        Me.cmbtype.TabIndex = 126
        '
        'chkstr
        '
        Me.chkstr.Location = New System.Drawing.Point(19, 100)
        Me.chkstr.Name = "chkstr"
        Me.chkstr.Properties.Caption = "StrValue"
        Me.chkstr.Size = New System.Drawing.Size(75, 18)
        Me.chkstr.TabIndex = 134
        '
        'chkint
        '
        Me.chkint.Location = New System.Drawing.Point(19, 126)
        Me.chkint.Name = "chkint"
        Me.chkint.Properties.Caption = "IntValue"
        Me.chkint.Size = New System.Drawing.Size(75, 18)
        Me.chkint.TabIndex = 135
        '
        'chkfloat
        '
        Me.chkfloat.Location = New System.Drawing.Point(19, 152)
        Me.chkfloat.Name = "chkfloat"
        Me.chkfloat.Properties.Caption = "FloatValue"
        Me.chkfloat.Size = New System.Drawing.Size(75, 18)
        Me.chkfloat.TabIndex = 136
        '
        'chkdate
        '
        Me.chkdate.Location = New System.Drawing.Point(19, 178)
        Me.chkdate.Name = "chkdate"
        Me.chkdate.Properties.Caption = "DateValue"
        Me.chkdate.Size = New System.Drawing.Size(75, 18)
        Me.chkdate.TabIndex = 137
        '
        'chkdelete
        '
        Me.chkdelete.Location = New System.Drawing.Point(92, 203)
        Me.chkdelete.Name = "chkdelete"
        Me.chkdelete.Properties.Caption = "Deleted"
        Me.chkdelete.Size = New System.Drawing.Size(75, 18)
        Me.chkdelete.TabIndex = 138
        '
        'txstr
        '
        Me.txstr.Location = New System.Drawing.Point(91, 99)
        Me.txstr.Name = "txstr"
        Me.txstr.Size = New System.Drawing.Size(197, 20)
        Me.txstr.TabIndex = 139
        '
        'txint
        '
        Me.txint.Location = New System.Drawing.Point(91, 125)
        Me.txint.Name = "txint"
        Me.txint.Properties.Mask.EditMask = "d"
        Me.txint.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txint.Size = New System.Drawing.Size(99, 20)
        Me.txint.TabIndex = 140
        '
        'txfloat
        '
        Me.txfloat.Location = New System.Drawing.Point(91, 151)
        Me.txfloat.Name = "txfloat"
        Me.txfloat.Properties.Mask.EditMask = "f"
        Me.txfloat.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txfloat.Size = New System.Drawing.Size(99, 20)
        Me.txfloat.TabIndex = 141
        '
        'butfind
        '
        Me.butfind.Location = New System.Drawing.Point(173, 17)
        Me.butfind.Name = "butfind"
        Me.butfind.Size = New System.Drawing.Size(33, 23)
        Me.butfind.TabIndex = 143
        Me.butfind.Text = "..."
        Me.butfind.UseVisualStyleBackColor = True
        '
        'dtdate
        '
        Me.dtdate.CustomFormat = "MMM/dd/yyyy"
        Me.dtdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtdate.Location = New System.Drawing.Point(92, 176)
        Me.dtdate.Name = "dtdate"
        Me.dtdate.Size = New System.Drawing.Size(106, 20)
        Me.dtdate.TabIndex = 144
        '
        'Msconfig
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(302, 255)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Msconfig"
        Me.Text = "Msconfig"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.cmbid.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkstr.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkint.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkfloat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkdate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkdelete.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txstr.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txint.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txfloat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbid As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbname As System.Windows.Forms.ComboBox
    Friend WithEvents cmbtype As System.Windows.Forms.ComboBox
    Friend WithEvents chkdate As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkfloat As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkint As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkstr As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents chkdelete As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents txfloat As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txint As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txstr As DevExpress.XtraEditors.TextEdit
    Friend WithEvents butfind As System.Windows.Forms.Button
    Friend WithEvents dtdate As System.Windows.Forms.DateTimePicker
End Class
