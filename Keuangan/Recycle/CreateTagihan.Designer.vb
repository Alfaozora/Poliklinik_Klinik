<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreateTagihan
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
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.grpkwitansi = New System.Windows.Forms.GroupBox
        Me.rdmmc = New System.Windows.Forms.RadioButton
        Me.rdcdc = New System.Windows.Forms.RadioButton
        Me.rdcmh = New System.Windows.Forms.RadioButton
        Me.Button1 = New System.Windows.Forms.Button
        Me.grptagihan = New System.Windows.Forms.GroupBox
        Me.rdsummary = New System.Windows.Forms.RadioButton
        Me.rddetail = New System.Windows.Forms.RadioButton
        Me.butcetaktagihan = New System.Windows.Forms.Button
        Me.txnoref3 = New System.Windows.Forms.TextBox
        Me.txnoref2 = New System.Windows.Forms.TextBox
        Me.txnoref1 = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txcreateby = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.dtcreatedate = New System.Windows.Forms.DateTimePicker
        Me.txtotalorg = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtotaltagihan = New System.Windows.Forms.TextBox
        Me.txterm = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.butfindcomp = New System.Windows.Forms.Button
        Me.dtduedate = New System.Windows.Forms.DateTimePicker
        Me.dttglbuat = New System.Windows.Forms.DateTimePicker
        Me.Label6 = New System.Windows.Forms.Label
        Me.txcompany = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txrekapid = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.butsaved = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.txket = New System.Windows.Forms.TextBox
        Me.GroupBox3.SuspendLayout()
        Me.grpkwitansi.SuspendLayout()
        Me.grptagihan.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txket)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Controls.Add(Me.grpkwitansi)
        Me.GroupBox3.Controls.Add(Me.grptagihan)
        Me.GroupBox3.Controls.Add(Me.txnoref3)
        Me.GroupBox3.Controls.Add(Me.txnoref2)
        Me.GroupBox3.Controls.Add(Me.txnoref1)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.txcreateby)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.dtcreatedate)
        Me.GroupBox3.Controls.Add(Me.txtotalorg)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.txtotaltagihan)
        Me.GroupBox3.Controls.Add(Me.txterm)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.butfindcomp)
        Me.GroupBox3.Controls.Add(Me.dtduedate)
        Me.GroupBox3.Controls.Add(Me.dttglbuat)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.txcompany)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.txrekapid)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.GroupBox1)
        Me.GroupBox3.Controls.Add(Me.butsaved)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(945, 479)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(244, 242)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(12, 13)
        Me.Label12.TabIndex = 215
        Me.Label12.Text = "/"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(142, 242)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(12, 13)
        Me.Label11.TabIndex = 214
        Me.Label11.Text = "/"
        '
        'grpkwitansi
        '
        Me.grpkwitansi.Controls.Add(Me.rdmmc)
        Me.grpkwitansi.Controls.Add(Me.rdcdc)
        Me.grpkwitansi.Controls.Add(Me.rdcmh)
        Me.grpkwitansi.Controls.Add(Me.Button1)
        Me.grpkwitansi.Location = New System.Drawing.Point(6, 366)
        Me.grpkwitansi.Name = "grpkwitansi"
        Me.grpkwitansi.Size = New System.Drawing.Size(326, 71)
        Me.grpkwitansi.TabIndex = 213
        Me.grpkwitansi.TabStop = False
        Me.grpkwitansi.Text = "Cetak Kwitansi"
        '
        'rdmmc
        '
        Me.rdmmc.AutoSize = True
        Me.rdmmc.Location = New System.Drawing.Point(111, 19)
        Me.rdmmc.Name = "rdmmc"
        Me.rdmmc.Size = New System.Drawing.Size(59, 17)
        Me.rdmmc.TabIndex = 213
        Me.rdmmc.TabStop = True
        Me.rdmmc.Text = "tt MMC"
        Me.rdmmc.UseVisualStyleBackColor = True
        '
        'rdcdc
        '
        Me.rdcdc.AutoSize = True
        Me.rdcdc.Location = New System.Drawing.Point(15, 42)
        Me.rdcdc.Name = "rdcdc"
        Me.rdcdc.Size = New System.Drawing.Size(56, 17)
        Me.rdcdc.TabIndex = 212
        Me.rdcdc.TabStop = True
        Me.rdcdc.Text = "tt CDC"
        Me.rdcdc.UseVisualStyleBackColor = True
        '
        'rdcmh
        '
        Me.rdcmh.AutoSize = True
        Me.rdcmh.Location = New System.Drawing.Point(15, 19)
        Me.rdcmh.Name = "rdcmh"
        Me.rdcmh.Size = New System.Drawing.Size(58, 17)
        Me.rdcmh.TabIndex = 211
        Me.rdcmh.TabStop = True
        Me.rdcmh.Text = "tt CMH"
        Me.rdcmh.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(235, 37)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(85, 27)
        Me.Button1.TabIndex = 209
        Me.Button1.Text = "Kwitansi"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'grptagihan
        '
        Me.grptagihan.Controls.Add(Me.rdsummary)
        Me.grptagihan.Controls.Add(Me.rddetail)
        Me.grptagihan.Controls.Add(Me.butcetaktagihan)
        Me.grptagihan.Location = New System.Drawing.Point(6, 309)
        Me.grptagihan.Name = "grptagihan"
        Me.grptagihan.Size = New System.Drawing.Size(326, 51)
        Me.grptagihan.TabIndex = 212
        Me.grptagihan.TabStop = False
        Me.grptagihan.Text = "Cetak Tagihan"
        '
        'rdsummary
        '
        Me.rdsummary.AutoSize = True
        Me.rdsummary.Location = New System.Drawing.Point(15, 19)
        Me.rdsummary.Name = "rdsummary"
        Me.rdsummary.Size = New System.Drawing.Size(68, 17)
        Me.rdsummary.TabIndex = 210
        Me.rdsummary.TabStop = True
        Me.rdsummary.Text = "Summary"
        Me.rdsummary.UseVisualStyleBackColor = True
        '
        'rddetail
        '
        Me.rddetail.AutoSize = True
        Me.rddetail.Location = New System.Drawing.Point(111, 19)
        Me.rddetail.Name = "rddetail"
        Me.rddetail.Size = New System.Drawing.Size(94, 17)
        Me.rddetail.TabIndex = 209
        Me.rddetail.TabStop = True
        Me.rddetail.Text = "Detail Tagihan"
        Me.rddetail.UseVisualStyleBackColor = True
        '
        'butcetaktagihan
        '
        Me.butcetaktagihan.Location = New System.Drawing.Point(235, 19)
        Me.butcetaktagihan.Name = "butcetaktagihan"
        Me.butcetaktagihan.Size = New System.Drawing.Size(85, 27)
        Me.butcetaktagihan.TabIndex = 208
        Me.butcetaktagihan.Text = "Cetak Tagihan"
        Me.butcetaktagihan.UseVisualStyleBackColor = True
        '
        'txnoref3
        '
        Me.txnoref3.Enabled = False
        Me.txnoref3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txnoref3.ForeColor = System.Drawing.SystemColors.ActiveBorder
        Me.txnoref3.Location = New System.Drawing.Point(259, 237)
        Me.txnoref3.Name = "txnoref3"
        Me.txnoref3.Size = New System.Drawing.Size(73, 23)
        Me.txnoref3.TabIndex = 211
        Me.txnoref3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txnoref2
        '
        Me.txnoref2.Enabled = False
        Me.txnoref2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txnoref2.ForeColor = System.Drawing.SystemColors.ActiveBorder
        Me.txnoref2.Location = New System.Drawing.Point(157, 237)
        Me.txnoref2.Name = "txnoref2"
        Me.txnoref2.Size = New System.Drawing.Size(84, 23)
        Me.txnoref2.TabIndex = 210
        Me.txnoref2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txnoref1
        '
        Me.txnoref1.Enabled = False
        Me.txnoref1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txnoref1.ForeColor = System.Drawing.SystemColors.ActiveBorder
        Me.txnoref1.Location = New System.Drawing.Point(94, 237)
        Me.txnoref1.Name = "txnoref1"
        Me.txnoref1.Size = New System.Drawing.Size(46, 23)
        Me.txnoref1.TabIndex = 206
        Me.txnoref1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(7, 242)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(83, 13)
        Me.Label10.TabIndex = 207
        Me.Label10.Text = "No Ref Tagihan"
        '
        'txcreateby
        '
        Me.txcreateby.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txcreateby.Enabled = False
        Me.txcreateby.Location = New System.Drawing.Point(64, 443)
        Me.txcreateby.Name = "txcreateby"
        Me.txcreateby.Size = New System.Drawing.Size(87, 20)
        Me.txcreateby.TabIndex = 205
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Enabled = False
        Me.Label8.Location = New System.Drawing.Point(157, 448)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 13)
        Me.Label8.TabIndex = 204
        Me.Label8.Text = "Create Date"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.Enabled = False
        Me.Label9.Location = New System.Drawing.Point(7, 447)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 13)
        Me.Label9.TabIndex = 203
        Me.Label9.Text = "Create By"
        '
        'dtcreatedate
        '
        Me.dtcreatedate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dtcreatedate.CustomFormat = "dd-MMM-yyyy"
        Me.dtcreatedate.Enabled = False
        Me.dtcreatedate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtcreatedate.Location = New System.Drawing.Point(225, 444)
        Me.dtcreatedate.Name = "dtcreatedate"
        Me.dtcreatedate.Size = New System.Drawing.Size(107, 20)
        Me.dtcreatedate.TabIndex = 202
        '
        'txtotalorg
        '
        Me.txtotalorg.Enabled = False
        Me.txtotalorg.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtotalorg.Location = New System.Drawing.Point(94, 151)
        Me.txtotalorg.Name = "txtotalorg"
        Me.txtotalorg.Size = New System.Drawing.Size(85, 24)
        Me.txtotalorg.TabIndex = 201
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(37, 154)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 18)
        Me.Label7.TabIndex = 200
        Me.Label7.Text = "Ttl Org"
        '
        'txtotaltagihan
        '
        Me.txtotaltagihan.Enabled = False
        Me.txtotaltagihan.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtotaltagihan.Location = New System.Drawing.Point(94, 181)
        Me.txtotaltagihan.Name = "txtotaltagihan"
        Me.txtotaltagihan.Size = New System.Drawing.Size(186, 24)
        Me.txtotaltagihan.TabIndex = 199
        '
        'txterm
        '
        Me.txterm.Location = New System.Drawing.Point(94, 99)
        Me.txterm.Name = "txterm"
        Me.txterm.Size = New System.Drawing.Size(57, 20)
        Me.txterm.TabIndex = 198
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(44, 129)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 197
        Me.Label1.Text = "Tanggal"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 184)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 18)
        Me.Label5.TabIndex = 196
        Me.Label5.Text = "Ttl Tagihan"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 194
        Me.Label3.Text = "Term Tagihan"
        '
        'butfindcomp
        '
        Me.butfindcomp.Enabled = False
        Me.butfindcomp.Location = New System.Drawing.Point(160, 11)
        Me.butfindcomp.Name = "butfindcomp"
        Me.butfindcomp.Size = New System.Drawing.Size(31, 23)
        Me.butfindcomp.TabIndex = 191
        Me.butfindcomp.Text = "..."
        Me.butfindcomp.UseVisualStyleBackColor = True
        '
        'dtduedate
        '
        Me.dtduedate.CustomFormat = "dd-MMM-yyyy"
        Me.dtduedate.Enabled = False
        Me.dtduedate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtduedate.Location = New System.Drawing.Point(94, 125)
        Me.dtduedate.Name = "dtduedate"
        Me.dtduedate.Size = New System.Drawing.Size(107, 20)
        Me.dtduedate.TabIndex = 190
        '
        'dttglbuat
        '
        Me.dttglbuat.CustomFormat = "dd-MMM-yyyy"
        Me.dttglbuat.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dttglbuat.Location = New System.Drawing.Point(94, 69)
        Me.dttglbuat.Name = "dttglbuat"
        Me.dttglbuat.Size = New System.Drawing.Size(107, 20)
        Me.dttglbuat.TabIndex = 188
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(43, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 13)
        Me.Label6.TabIndex = 187
        Me.Label6.Text = "Tgl Buat"
        '
        'txcompany
        '
        Me.txcompany.Location = New System.Drawing.Point(94, 43)
        Me.txcompany.Name = "txcompany"
        Me.txcompany.Size = New System.Drawing.Size(238, 20)
        Me.txcompany.TabIndex = 185
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(39, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 186
        Me.Label4.Text = "Company"
        '
        'txrekapid
        '
        Me.txrekapid.Enabled = False
        Me.txrekapid.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txrekapid.Location = New System.Drawing.Point(94, 12)
        Me.txrekapid.Name = "txrekapid"
        Me.txrekapid.Size = New System.Drawing.Size(57, 23)
        Me.txrekapid.TabIndex = 183
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(18, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 18)
        Me.Label2.TabIndex = 184
        Me.Label2.Text = "RekapID"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GridControl1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.GroupBox1.Location = New System.Drawing.Point(338, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(604, 460)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detail"
        '
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        '
        '
        '
        Me.GridControl1.EmbeddedNavigator.Name = ""
        Me.GridControl1.Location = New System.Drawing.Point(3, 16)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(598, 441)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsCustomization.AllowColumnMoving = False
        Me.GridView1.OptionsCustomization.AllowGroup = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowForFocusedRow
        '
        'butsaved
        '
        Me.butsaved.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_save
        Me.butsaved.Location = New System.Drawing.Point(94, 265)
        Me.butsaved.Name = "butsaved"
        Me.butsaved.Size = New System.Drawing.Size(107, 39)
        Me.butsaved.TabIndex = 1
        Me.butsaved.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(28, 215)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(62, 13)
        Me.Label13.TabIndex = 216
        Me.Label13.Text = "Keterangan"
        '
        'txket
        '
        Me.txket.Location = New System.Drawing.Point(94, 211)
        Me.txket.Name = "txket"
        Me.txket.Size = New System.Drawing.Size(186, 20)
        Me.txket.TabIndex = 217
        '
        'CreateTagihan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(945, 479)
        Me.Controls.Add(Me.GroupBox3)
        Me.Name = "CreateTagihan"
        Me.Text = "CreateTagihan"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.grpkwitansi.ResumeLayout(False)
        Me.grpkwitansi.PerformLayout()
        Me.grptagihan.ResumeLayout(False)
        Me.grptagihan.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Private WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents butsaved As System.Windows.Forms.Button
    Friend WithEvents butfindcomp As System.Windows.Forms.Button
    Friend WithEvents dtduedate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dttglbuat As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txcompany As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txrekapid As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txterm As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txcreateby As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtcreatedate As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtotalorg As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtotaltagihan As System.Windows.Forms.TextBox
    Friend WithEvents txnoref1 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents butcetaktagihan As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txnoref3 As System.Windows.Forms.TextBox
    Friend WithEvents txnoref2 As System.Windows.Forms.TextBox
    Friend WithEvents grptagihan As System.Windows.Forms.GroupBox
    Friend WithEvents grpkwitansi As System.Windows.Forms.GroupBox
    Friend WithEvents rdmmc As System.Windows.Forms.RadioButton
    Friend WithEvents rdcdc As System.Windows.Forms.RadioButton
    Friend WithEvents rdcmh As System.Windows.Forms.RadioButton
    Friend WithEvents rdsummary As System.Windows.Forms.RadioButton
    Friend WithEvents rddetail As System.Windows.Forms.RadioButton
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txket As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
