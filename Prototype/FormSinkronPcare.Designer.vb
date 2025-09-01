<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSinkronPcare
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
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.ButtonSendPendaftaran = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtprocess = New System.Windows.Forms.DateTimePicker
        Me.ButtonSinkronisasi = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.ListViewKunjungan = New System.Windows.Forms.ListView
        Me.Label4 = New System.Windows.Forms.Label
        Me.ListViewCompare = New System.Windows.Forms.ListView
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.ListViewLokal = New System.Windows.Forms.ListView
        Me.ListViewPcare = New System.Windows.Forms.ListView
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackgroundImage = Global.PoliKlinik_Net2.My.Resources.Resources.wallpaper
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.White
        Me.SplitContainer1.Panel1.Controls.Add(Me.ButtonSendPendaftaran)
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel1.Controls.Add(Me.dtprocess)
        Me.SplitContainer1.Panel1.Controls.Add(Me.ButtonSinkronisasi)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.AutoScroll = True
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ListViewKunjungan)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ListViewCompare)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ListViewLokal)
        Me.SplitContainer1.Panel2.Controls.Add(Me.ListViewPcare)
        Me.SplitContainer1.Size = New System.Drawing.Size(1015, 498)
        Me.SplitContainer1.SplitterDistance = 169
        Me.SplitContainer1.TabIndex = 0
        '
        'ButtonSendPendaftaran
        '
        Me.ButtonSendPendaftaran.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ButtonSendPendaftaran.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonSendPendaftaran.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonSendPendaftaran.FlatAppearance.BorderSize = 0
        Me.ButtonSendPendaftaran.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSendPendaftaran.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonSendPendaftaran.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSendPendaftaran.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonSendPendaftaran.ForeColor = System.Drawing.Color.White
        Me.ButtonSendPendaftaran.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_sync_24
        Me.ButtonSendPendaftaran.Location = New System.Drawing.Point(207, 103)
        Me.ButtonSendPendaftaran.Name = "ButtonSendPendaftaran"
        Me.ButtonSendPendaftaran.Size = New System.Drawing.Size(186, 35)
        Me.ButtonSendPendaftaran.TabIndex = 520
        Me.ButtonSendPendaftaran.Text = "Send Ulang Pendaftaran"
        Me.ButtonSendPendaftaran.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonSendPendaftaran.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonSendPendaftaran.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(12, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 519
        Me.Label1.Text = "TANGGAL"
        '
        'dtprocess
        '
        Me.dtprocess.CalendarFont = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtprocess.CustomFormat = "dd-MMM-yyyy"
        Me.dtprocess.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtprocess.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtprocess.Location = New System.Drawing.Point(76, 30)
        Me.dtprocess.Name = "dtprocess"
        Me.dtprocess.Size = New System.Drawing.Size(125, 25)
        Me.dtprocess.TabIndex = 518
        '
        'ButtonSinkronisasi
        '
        Me.ButtonSinkronisasi.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSinkronisasi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonSinkronisasi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonSinkronisasi.FlatAppearance.BorderSize = 0
        Me.ButtonSinkronisasi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSinkronisasi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonSinkronisasi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSinkronisasi.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonSinkronisasi.ForeColor = System.Drawing.Color.White
        Me.ButtonSinkronisasi.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_sync_24
        Me.ButtonSinkronisasi.Location = New System.Drawing.Point(15, 103)
        Me.ButtonSinkronisasi.Name = "ButtonSinkronisasi"
        Me.ButtonSinkronisasi.Size = New System.Drawing.Size(186, 35)
        Me.ButtonSinkronisasi.TabIndex = 517
        Me.ButtonSinkronisasi.Text = "Ambil Data"
        Me.ButtonSinkronisasi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonSinkronisasi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonSinkronisasi.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(103, 287)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(192, 17)
        Me.Label5.TabIndex = 525
        Me.Label5.Text = "Data No Kunjungan BPJS"
        '
        'ListViewKunjungan
        '
        Me.ListViewKunjungan.Location = New System.Drawing.Point(4, 307)
        Me.ListViewKunjungan.Name = "ListViewKunjungan"
        Me.ListViewKunjungan.Size = New System.Drawing.Size(430, 241)
        Me.ListViewKunjungan.TabIndex = 524
        Me.ListViewKunjungan.UseCompatibleStateImageBehavior = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(1012, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(115, 17)
        Me.Label4.TabIndex = 523
        Me.Label4.Text = "Hasil Compare"
        '
        'ListViewCompare
        '
        Me.ListViewCompare.Location = New System.Drawing.Point(879, 28)
        Me.ListViewCompare.Name = "ListViewCompare"
        Me.ListViewCompare.Size = New System.Drawing.Size(431, 241)
        Me.ListViewCompare.TabIndex = 522
        Me.ListViewCompare.UseCompatibleStateImageBehavior = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(614, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 17)
        Me.Label3.TabIndex = 521
        Me.Label3.Text = "Data Lokal"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(158, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 17)
        Me.Label2.TabIndex = 520
        Me.Label2.Text = "Data Pcare"
        '
        'ListViewLokal
        '
        Me.ListViewLokal.Location = New System.Drawing.Point(442, 28)
        Me.ListViewLokal.Name = "ListViewLokal"
        Me.ListViewLokal.Size = New System.Drawing.Size(430, 241)
        Me.ListViewLokal.TabIndex = 1
        Me.ListViewLokal.UseCompatibleStateImageBehavior = False
        '
        'ListViewPcare
        '
        Me.ListViewPcare.Location = New System.Drawing.Point(4, 28)
        Me.ListViewPcare.Name = "ListViewPcare"
        Me.ListViewPcare.Size = New System.Drawing.Size(430, 241)
        Me.ListViewPcare.TabIndex = 0
        Me.ListViewPcare.UseCompatibleStateImageBehavior = False
        '
        'FormSinkronPcare
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1015, 498)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "FormSinkronPcare"
        Me.Text = "FormSinkronPcare"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents ButtonSinkronisasi As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtprocess As System.Windows.Forms.DateTimePicker
    Friend WithEvents ListViewPcare As System.Windows.Forms.ListView
    Friend WithEvents ListViewLokal As System.Windows.Forms.ListView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ListViewCompare As System.Windows.Forms.ListView
    Friend WithEvents ButtonSendPendaftaran As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ListViewKunjungan As System.Windows.Forms.ListView
End Class
