<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormUploadJurnal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormUploadJurnal))
        Me.PanelTop = New System.Windows.Forms.Panel
        Me.ButtonClose = New System.Windows.Forms.Button
        Me.ButtonKirimJurnal = New System.Windows.Forms.Button
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.tglAkhir = New System.Windows.Forms.DateTimePicker
        Me.tglAwal = New System.Windows.Forms.DateTimePicker
        Me.Button1 = New System.Windows.Forms.Button
        Me.TextBoxResponse = New System.Windows.Forms.TextBox
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.ProgressBarSinkronisasi = New System.Windows.Forms.ProgressBar
        Me.PanelTop.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.PanelTop.Controls.Add(Me.ButtonClose)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(918, 35)
        Me.PanelTop.TabIndex = 431
        '
        'ButtonClose
        '
        Me.ButtonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.ButtonClose.FlatAppearance.BorderSize = 0
        Me.ButtonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonClose.Image = CType(resources.GetObject("ButtonClose.Image"), System.Drawing.Image)
        Me.ButtonClose.Location = New System.Drawing.Point(878, 0)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(40, 35)
        Me.ButtonClose.TabIndex = 281
        Me.ButtonClose.UseVisualStyleBackColor = True
        '
        'ButtonKirimJurnal
        '
        Me.ButtonKirimJurnal.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonKirimJurnal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonKirimJurnal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonKirimJurnal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonKirimJurnal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonKirimJurnal.ForeColor = System.Drawing.Color.White
        Me.ButtonKirimJurnal.Location = New System.Drawing.Point(272, 192)
        Me.ButtonKirimJurnal.Name = "ButtonKirimJurnal"
        Me.ButtonKirimJurnal.Size = New System.Drawing.Size(109, 30)
        Me.ButtonKirimJurnal.TabIndex = 432
        Me.ButtonKirimJurnal.Text = "Kirim Jurnal"
        Me.ButtonKirimJurnal.UseVisualStyleBackColor = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label18.Location = New System.Drawing.Point(18, 50)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(142, 17)
        Me.Label18.TabIndex = 446
        Me.Label18.Text = "KIRIM ULANG JURNAL"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(269, 147)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 13)
        Me.Label9.TabIndex = 453
        Me.Label9.Text = "Tgl Akhir"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(243, 170)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(23, 13)
        Me.Label8.TabIndex = 452
        Me.Label8.Text = "s/d"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(125, 147)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 13)
        Me.Label7.TabIndex = 451
        Me.Label7.Text = "Tgl Awal"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 167)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 17)
        Me.Label1.TabIndex = 450
        Me.Label1.Text = "Tgl Transaksi"
        '
        'tglAkhir
        '
        Me.tglAkhir.CalendarFont = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tglAkhir.CustomFormat = "dd-MMM-yyyy"
        Me.tglAkhir.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.tglAkhir.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.tglAkhir.Location = New System.Drawing.Point(272, 163)
        Me.tglAkhir.Name = "tglAkhir"
        Me.tglAkhir.Size = New System.Drawing.Size(109, 23)
        Me.tglAkhir.TabIndex = 449
        '
        'tglAwal
        '
        Me.tglAwal.CalendarFont = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tglAwal.CustomFormat = "dd-MMM-yyyy"
        Me.tglAwal.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.tglAwal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.tglAwal.Location = New System.Drawing.Point(128, 163)
        Me.tglAwal.Name = "tglAwal"
        Me.tglAwal.Size = New System.Drawing.Size(109, 23)
        Me.tglAwal.TabIndex = 448
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(157, 192)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(109, 30)
        Me.Button1.TabIndex = 454
        Me.Button1.Text = "Search Data"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'TextBoxResponse
        '
        Me.TextBoxResponse.BackColor = System.Drawing.Color.White
        Me.TextBoxResponse.Location = New System.Drawing.Point(21, 259)
        Me.TextBoxResponse.Multiline = True
        Me.TextBoxResponse.Name = "TextBoxResponse"
        Me.TextBoxResponse.ReadOnly = True
        Me.TextBoxResponse.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxResponse.Size = New System.Drawing.Size(360, 129)
        Me.TextBoxResponse.TabIndex = 462
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(172, Byte), Integer))
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.ProgressBarSinkronisasi)
        Me.Panel6.Location = New System.Drawing.Point(21, 228)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(360, 25)
        Me.Panel6.TabIndex = 523
        '
        'ProgressBarSinkronisasi
        '
        Me.ProgressBarSinkronisasi.ForeColor = System.Drawing.Color.White
        Me.ProgressBarSinkronisasi.Location = New System.Drawing.Point(10, 10)
        Me.ProgressBarSinkronisasi.Name = "ProgressBarSinkronisasi"
        Me.ProgressBarSinkronisasi.Size = New System.Drawing.Size(340, 5)
        Me.ProgressBarSinkronisasi.TabIndex = 520
        '
        'FormUploadJurnal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(918, 452)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.TextBoxResponse)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tglAkhir)
        Me.Controls.Add(Me.tglAwal)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.ButtonKirimJurnal)
        Me.Controls.Add(Me.PanelTop)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormUploadJurnal"
        Me.PanelTop.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents ButtonClose As System.Windows.Forms.Button
    Friend WithEvents ButtonKirimJurnal As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tglAkhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents tglAwal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBoxResponse As System.Windows.Forms.TextBox
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents ProgressBarSinkronisasi As System.Windows.Forms.ProgressBar
End Class
