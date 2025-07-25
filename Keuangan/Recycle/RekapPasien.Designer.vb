<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RekapPasien
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
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.butok = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.rdall = New System.Windows.Forms.RadioButton
        Me.transakhir = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.transawal = New System.Windows.Forms.TextBox
        Me.dtawal = New System.Windows.Forms.DateTimePicker
        Me.rdtgltrans = New System.Windows.Forms.RadioButton
        Me.rdtransid = New System.Windows.Forms.RadioButton
        Me.butselect = New System.Windows.Forms.Button
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
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
        'GridControl1
        '
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.EmbeddedNavigator.Name = ""
        Me.GridControl1.Location = New System.Drawing.Point(3, 16)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(870, 298)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GridControl1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 145)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(876, 317)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Detail"
        '
        'butok
        '
        Me.butok.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_add
        Me.butok.Location = New System.Drawing.Point(757, 12)
        Me.butok.Name = "butok"
        Me.butok.Size = New System.Drawing.Size(107, 39)
        Me.butok.TabIndex = 0
        Me.butok.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CheckBox1)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.TextBox1)
        Me.GroupBox3.Controls.Add(Me.Button1)
        Me.GroupBox3.Controls.Add(Me.rdall)
        Me.GroupBox3.Controls.Add(Me.transakhir)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.transawal)
        Me.GroupBox3.Controls.Add(Me.dtawal)
        Me.GroupBox3.Controls.Add(Me.rdtgltrans)
        Me.GroupBox3.Controls.Add(Me.rdtransid)
        Me.GroupBox3.Controls.Add(Me.butselect)
        Me.GroupBox3.Controls.Add(Me.butok)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(876, 145)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(125, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 13)
        Me.Label2.TabIndex = 120
        Me.Label2.Text = "Total Tagihan :"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(210, 103)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 119
        '
        'Button1
        '
        Me.Button1.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_kalkulasi
        Me.Button1.Location = New System.Drawing.Point(12, 93)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(107, 39)
        Me.Button1.TabIndex = 118
        Me.Button1.UseVisualStyleBackColor = True
        '
        'rdall
        '
        Me.rdall.AutoSize = True
        Me.rdall.Location = New System.Drawing.Point(12, 70)
        Me.rdall.Name = "rdall"
        Me.rdall.Size = New System.Drawing.Size(73, 17)
        Me.rdall.TabIndex = 117
        Me.rdall.TabStop = True
        Me.rdall.Text = "Display All"
        Me.rdall.UseVisualStyleBackColor = True
        '
        'transakhir
        '
        Me.transakhir.Location = New System.Drawing.Point(337, 15)
        Me.transakhir.Name = "transakhir"
        Me.transakhir.Size = New System.Drawing.Size(100, 20)
        Me.transakhir.TabIndex = 116
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(308, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 13)
        Me.Label1.TabIndex = 115
        Me.Label1.Text = "s/d"
        '
        'transawal
        '
        Me.transawal.Location = New System.Drawing.Point(202, 14)
        Me.transawal.Name = "transawal"
        Me.transawal.Size = New System.Drawing.Size(100, 20)
        Me.transawal.TabIndex = 114
        '
        'dtawal
        '
        Me.dtawal.CustomFormat = "dd-MMM-yyyy"
        Me.dtawal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtawal.Location = New System.Drawing.Point(232, 42)
        Me.dtawal.Name = "dtawal"
        Me.dtawal.Size = New System.Drawing.Size(109, 20)
        Me.dtawal.TabIndex = 113
        '
        'rdtgltrans
        '
        Me.rdtgltrans.AutoSize = True
        Me.rdtgltrans.Location = New System.Drawing.Point(12, 44)
        Me.rdtgltrans.Name = "rdtgltrans"
        Me.rdtgltrans.Size = New System.Drawing.Size(215, 17)
        Me.rdtgltrans.TabIndex = 3
        Me.rdtgltrans.TabStop = True
        Me.rdtgltrans.Text = "Multiple Checked by  Tanggal Transaksi"
        Me.rdtgltrans.UseVisualStyleBackColor = True
        '
        'rdtransid
        '
        Me.rdtransid.AutoSize = True
        Me.rdtransid.Location = New System.Drawing.Point(12, 16)
        Me.rdtransid.Name = "rdtransid"
        Me.rdtransid.Size = New System.Drawing.Size(184, 17)
        Me.rdtransid.TabIndex = 2
        Me.rdtransid.TabStop = True
        Me.rdtransid.Text = "Multiple Checked by  TransaksiID"
        Me.rdtransid.UseVisualStyleBackColor = True
        '
        'butselect
        '
        Me.butselect.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_cari
        Me.butselect.Location = New System.Drawing.Point(443, 12)
        Me.butselect.Name = "butselect"
        Me.butselect.Size = New System.Drawing.Size(107, 39)
        Me.butselect.TabIndex = 1
        Me.butselect.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(328, 105)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(81, 17)
        Me.CheckBox1.TabIndex = 215
        Me.CheckBox1.Text = "Pilih Semua"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'RekapPasien
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(876, 462)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Name = "RekapPasien"
        Me.Text = "RekapPasien"
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents butok As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents butselect As System.Windows.Forms.Button
    Friend WithEvents rdtransid As System.Windows.Forms.RadioButton
    Friend WithEvents rdtgltrans As System.Windows.Forms.RadioButton
    Friend WithEvents dtawal As System.Windows.Forms.DateTimePicker
    Friend WithEvents transakhir As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents transawal As System.Windows.Forms.TextBox
    Friend WithEvents rdall As System.Windows.Forms.RadioButton
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
End Class
