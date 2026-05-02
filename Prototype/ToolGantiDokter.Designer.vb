<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ToolGantiDokter
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
        Me.ComboBoxNoTransaksi = New System.Windows.Forms.ComboBox
        Me.ComboBoxDokter = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.ButtonGanti = New System.Windows.Forms.Button
        Me.TglTransaksi = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'ComboBoxNoTransaksi
        '
        Me.ComboBoxNoTransaksi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxNoTransaksi.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxNoTransaksi.FormattingEnabled = True
        Me.ComboBoxNoTransaksi.Location = New System.Drawing.Point(133, 97)
        Me.ComboBoxNoTransaksi.Name = "ComboBoxNoTransaksi"
        Me.ComboBoxNoTransaksi.Size = New System.Drawing.Size(271, 25)
        Me.ComboBoxNoTransaksi.TabIndex = 457
        '
        'ComboBoxDokter
        '
        Me.ComboBoxDokter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxDokter.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxDokter.FormattingEnabled = True
        Me.ComboBoxDokter.Location = New System.Drawing.Point(133, 150)
        Me.ComboBoxDokter.Name = "ComboBoxDokter"
        Me.ComboBoxDokter.Size = New System.Drawing.Size(271, 25)
        Me.ComboBoxDokter.TabIndex = 458
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(12, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 16)
        Me.Label2.TabIndex = 459
        Me.Label2.Text = "No Transaksi"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(12, 150)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 16)
        Me.Label1.TabIndex = 460
        Me.Label1.Text = "Dokter"
        '
        'ButtonGanti
        '
        Me.ButtonGanti.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonGanti.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonGanti.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonGanti.FlatAppearance.BorderSize = 0
        Me.ButtonGanti.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonGanti.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonGanti.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonGanti.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonGanti.ForeColor = System.Drawing.Color.White
        Me.ButtonGanti.Location = New System.Drawing.Point(303, 198)
        Me.ButtonGanti.Name = "ButtonGanti"
        Me.ButtonGanti.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonGanti.Size = New System.Drawing.Size(101, 26)
        Me.ButtonGanti.TabIndex = 461
        Me.ButtonGanti.Text = "Ganti"
        Me.ButtonGanti.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonGanti.UseVisualStyleBackColor = False
        '
        'TglTransaksi
        '
        Me.TglTransaksi.CalendarFont = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TglTransaksi.CustomFormat = "dd-MMM-yyyy"
        Me.TglTransaksi.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TglTransaksi.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.TglTransaksi.Location = New System.Drawing.Point(133, 47)
        Me.TglTransaksi.Name = "TglTransaksi"
        Me.TglTransaksi.Size = New System.Drawing.Size(125, 25)
        Me.TglTransaksi.TabIndex = 516
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(12, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 16)
        Me.Label3.TabIndex = 517
        Me.Label3.Text = "Tgl Transaksi"
        '
        'ToolGantiDokter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.PoliKlinik_Net2.My.Resources.Resources.wallpaperdialog
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(448, 292)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TglTransaksi)
        Me.Controls.Add(Me.ButtonGanti)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ComboBoxDokter)
        Me.Controls.Add(Me.ComboBoxNoTransaksi)
        Me.Name = "ToolGantiDokter"
        Me.Text = "ToolGantiDokter"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboBoxNoTransaksi As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBoxDokter As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonGanti As System.Windows.Forms.Button
    Friend WithEvents TglTransaksi As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
