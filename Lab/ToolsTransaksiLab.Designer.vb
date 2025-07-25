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
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.txprocent = New System.Windows.Forms.Label
        Me.dtuploadstart = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.butupload = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(442, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Tekan Tombol UPLOAD untuk mengirim data transaksi lab dari local ke online"
        '
        'status
        '
        Me.status.Enabled = False
        Me.status.Location = New System.Drawing.Point(15, 165)
        Me.status.Multiline = True
        Me.status.Name = "status"
        Me.status.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.status.Size = New System.Drawing.Size(435, 103)
        Me.status.TabIndex = 4
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(15, 130)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(435, 29)
        Me.ProgressBar1.TabIndex = 5
        '
        'txprocent
        '
        Me.txprocent.AutoSize = True
        Me.txprocent.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txprocent.Location = New System.Drawing.Point(12, 111)
        Me.txprocent.Name = "txprocent"
        Me.txprocent.Size = New System.Drawing.Size(33, 16)
        Me.txprocent.TabIndex = 6
        Me.txprocent.Text = "0 %"
        '
        'dtuploadstart
        '
        Me.dtuploadstart.CustomFormat = "dd-MMM-yyyy"
        Me.dtuploadstart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtuploadstart.Location = New System.Drawing.Point(239, 57)
        Me.dtuploadstart.Name = "dtuploadstart"
        Me.dtuploadstart.Size = New System.Drawing.Size(100, 20)
        Me.dtuploadstart.TabIndex = 7
        Me.dtuploadstart.Value = New Date(2019, 9, 25, 10, 24, 57, 0)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(113, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 15)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Pilih Tanggal Upload"
        '
        'butupload
        '
        Me.butupload.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butupload.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_unggah
        Me.butupload.Location = New System.Drawing.Point(180, 83)
        Me.butupload.Name = "butupload"
        Me.butupload.Size = New System.Drawing.Size(100, 36)
        Me.butupload.TabIndex = 10
        Me.butupload.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Tomato
        Me.Label3.Location = New System.Drawing.Point(44, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(374, 15)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Note : Pastikan data yang akan di upload sudah di cetak barcode."
        '
        'ToolsTransaksiLab
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(462, 281)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.butupload)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dtuploadstart)
        Me.Controls.Add(Me.txprocent)
        Me.Controls.Add(Me.ProgressBar1)
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
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents txprocent As System.Windows.Forms.Label
    Friend WithEvents dtuploadstart As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents butupload As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
