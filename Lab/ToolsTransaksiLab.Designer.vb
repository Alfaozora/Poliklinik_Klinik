<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ToolsTransaksiLab
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ToolsTransaksiLab))
        Me.Label1 = New System.Windows.Forms.Label
        Me.status = New System.Windows.Forms.TextBox
        Me.ProgressBarSinkronisasi = New System.Windows.Forms.ProgressBar
        Me.TextBoxKeteranganSinkronisasi = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.DateTimeUpload = New System.Windows.Forms.DateTimePicker
        Me.Label12 = New System.Windows.Forms.Label
        Me.ButtonUpload = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(478, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Tekan Tombol UPLOAD untuk mengirim data transaksi lab dari lokal ke online"
        '
        'status
        '
        Me.status.Enabled = False
        Me.status.Location = New System.Drawing.Point(12, 175)
        Me.status.Multiline = True
        Me.status.Name = "status"
        Me.status.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.status.Size = New System.Drawing.Size(475, 103)
        Me.status.TabIndex = 4
        '
        'ProgressBarSinkronisasi
        '
        Me.ProgressBarSinkronisasi.Location = New System.Drawing.Point(12, 149)
        Me.ProgressBarSinkronisasi.Name = "ProgressBarSinkronisasi"
        Me.ProgressBarSinkronisasi.Size = New System.Drawing.Size(475, 20)
        Me.ProgressBarSinkronisasi.TabIndex = 5
        '
        'TextBoxKeteranganSinkronisasi
        '
        Me.TextBoxKeteranganSinkronisasi.AutoSize = True
        Me.TextBoxKeteranganSinkronisasi.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TextBoxKeteranganSinkronisasi.Location = New System.Drawing.Point(12, 129)
        Me.TextBoxKeteranganSinkronisasi.Name = "TextBoxKeteranganSinkronisasi"
        Me.TextBoxKeteranganSinkronisasi.Size = New System.Drawing.Size(30, 17)
        Me.TextBoxKeteranganSinkronisasi.TabIndex = 6
        Me.TextBoxKeteranganSinkronisasi.Text = "0 %"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Tomato
        Me.Label3.Location = New System.Drawing.Point(12, 26)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(407, 17)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Note : Pastikan data yang akan di upload sudah di cetak barcode."
        '
        'DateTimeUpload
        '
        Me.DateTimeUpload.CalendarFont = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.DateTimeUpload.CustomFormat = "dd-MMM-yyyy"
        Me.DateTimeUpload.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.DateTimeUpload.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimeUpload.Location = New System.Drawing.Point(120, 77)
        Me.DateTimeUpload.Name = "DateTimeUpload"
        Me.DateTimeUpload.Size = New System.Drawing.Size(130, 25)
        Me.DateTimeUpload.TabIndex = 244
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label12.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label12.Location = New System.Drawing.Point(12, 80)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(102, 17)
        Me.Label12.TabIndex = 245
        Me.Label12.Text = "Tanggal Upload"
        '
        'ButtonUpload
        '
        Me.ButtonUpload.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ButtonUpload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonUpload.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonUpload.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonUpload.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonUpload.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonUpload.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonUpload.Image = CType(resources.GetObject("ButtonUpload.Image"), System.Drawing.Image)
        Me.ButtonUpload.Location = New System.Drawing.Point(266, 65)
        Me.ButtonUpload.Name = "ButtonUpload"
        Me.ButtonUpload.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonUpload.Size = New System.Drawing.Size(150, 65)
        Me.ButtonUpload.TabIndex = 585
        Me.ButtonUpload.Text = " Upload Data"
        Me.ButtonUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonUpload.UseVisualStyleBackColor = False
        '
        'ToolsTransaksiLab
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(503, 290)
        Me.Controls.Add(Me.ButtonUpload)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.DateTimeUpload)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TextBoxKeteranganSinkronisasi)
        Me.Controls.Add(Me.ProgressBarSinkronisasi)
        Me.Controls.Add(Me.status)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "ToolsTransaksiLab"
        Me.Text = "Upload Transaksi"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents status As System.Windows.Forms.TextBox
    Friend WithEvents ProgressBarSinkronisasi As System.Windows.Forms.ProgressBar
    Friend WithEvents TextBoxKeteranganSinkronisasi As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DateTimeUpload As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ButtonUpload As System.Windows.Forms.Button
End Class
