<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportClosingBankTagihan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ReportClosingBankTagihan))
        Me.dtkasirakhir = New System.Windows.Forms.DateTimePicker
        Me.dtkasirawal = New System.Windows.Forms.DateTimePicker
        Me.butdisplay = New System.Windows.Forms.Button
        Me.butfind = New System.Windows.Forms.Button
        Me.TextBoxNamaPerusahaan = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.RadioButtonJenisTransaksiKlinik = New System.Windows.Forms.RadioButton
        Me.RadioButtonJenisTransaksiAll = New System.Windows.Forms.RadioButton
        Me.RadioButtonJenisTransaksiLaboratorium = New System.Windows.Forms.RadioButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.rdtanggalbayar = New System.Windows.Forms.RadioButton
        Me.rdtanggalclosing = New System.Windows.Forms.RadioButton
        Me.butselectbank = New System.Windows.Forms.Button
        Me.TextBoxBankTransferKeterangan = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBoxBankTransferCoa = New System.Windows.Forms.TextBox
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtkasirakhir
        '
        Me.dtkasirakhir.CustomFormat = "dd-MMM-yyyy"
        Me.dtkasirakhir.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.dtkasirakhir.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtkasirakhir.Location = New System.Drawing.Point(346, 104)
        Me.dtkasirakhir.Name = "dtkasirakhir"
        Me.dtkasirakhir.Size = New System.Drawing.Size(150, 25)
        Me.dtkasirakhir.TabIndex = 113
        '
        'dtkasirawal
        '
        Me.dtkasirawal.CustomFormat = "dd-MMM-yyyy"
        Me.dtkasirawal.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.dtkasirawal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtkasirawal.Location = New System.Drawing.Point(160, 104)
        Me.dtkasirawal.Name = "dtkasirawal"
        Me.dtkasirawal.Size = New System.Drawing.Size(150, 25)
        Me.dtkasirawal.TabIndex = 110
        '
        'butdisplay
        '
        Me.butdisplay.BackgroundImage = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_cetak
        Me.butdisplay.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butdisplay.Location = New System.Drawing.Point(161, 197)
        Me.butdisplay.Name = "butdisplay"
        Me.butdisplay.Size = New System.Drawing.Size(100, 36)
        Me.butdisplay.TabIndex = 106
        Me.butdisplay.UseVisualStyleBackColor = True
        '
        'butfind
        '
        Me.butfind.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butfind.Location = New System.Drawing.Point(502, 47)
        Me.butfind.Name = "butfind"
        Me.butfind.Size = New System.Drawing.Size(31, 25)
        Me.butfind.TabIndex = 201
        Me.butfind.Text = "..."
        Me.butfind.UseVisualStyleBackColor = True
        '
        'TextBoxNamaPerusahaan
        '
        Me.TextBoxNamaPerusahaan.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBoxNamaPerusahaan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TextBoxNamaPerusahaan.Location = New System.Drawing.Point(160, 46)
        Me.TextBoxNamaPerusahaan.Name = "TextBoxNamaPerusahaan"
        Me.TextBoxNamaPerusahaan.ReadOnly = True
        Me.TextBoxNamaPerusahaan.Size = New System.Drawing.Size(336, 23)
        Me.TextBoxNamaPerusahaan.TabIndex = 200
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label16.Location = New System.Drawing.Point(23, 47)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(79, 17)
        Me.Label16.TabIndex = 199
        Me.Label16.Text = "Perusahaan"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(23, 110)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 17)
        Me.Label1.TabIndex = 206
        Me.Label1.Text = "Pilih Tanggal"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.Label3.Location = New System.Drawing.Point(316, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(24, 15)
        Me.Label3.TabIndex = 207
        Me.Label3.Text = "s/d"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel1.Controls.Add(Me.RadioButtonJenisTransaksiKlinik)
        Me.Panel1.Controls.Add(Me.RadioButtonJenisTransaksiAll)
        Me.Panel1.Controls.Add(Me.RadioButtonJenisTransaksiLaboratorium)
        Me.Panel1.Location = New System.Drawing.Point(160, 166)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(336, 25)
        Me.Panel1.TabIndex = 250
        '
        'RadioButtonJenisTransaksiKlinik
        '
        Me.RadioButtonJenisTransaksiKlinik.AutoSize = True
        Me.RadioButtonJenisTransaksiKlinik.BackColor = System.Drawing.Color.Transparent
        Me.RadioButtonJenisTransaksiKlinik.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.RadioButtonJenisTransaksiKlinik.Location = New System.Drawing.Point(1, 2)
        Me.RadioButtonJenisTransaksiKlinik.Name = "RadioButtonJenisTransaksiKlinik"
        Me.RadioButtonJenisTransaksiKlinik.Size = New System.Drawing.Size(54, 19)
        Me.RadioButtonJenisTransaksiKlinik.TabIndex = 209
        Me.RadioButtonJenisTransaksiKlinik.TabStop = True
        Me.RadioButtonJenisTransaksiKlinik.Text = "Klinik"
        Me.RadioButtonJenisTransaksiKlinik.UseVisualStyleBackColor = False
        '
        'RadioButtonJenisTransaksiAll
        '
        Me.RadioButtonJenisTransaksiAll.AutoSize = True
        Me.RadioButtonJenisTransaksiAll.BackColor = System.Drawing.Color.Transparent
        Me.RadioButtonJenisTransaksiAll.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.RadioButtonJenisTransaksiAll.Location = New System.Drawing.Point(164, 2)
        Me.RadioButtonJenisTransaksiAll.Name = "RadioButtonJenisTransaksiAll"
        Me.RadioButtonJenisTransaksiAll.Size = New System.Drawing.Size(61, 19)
        Me.RadioButtonJenisTransaksiAll.TabIndex = 211
        Me.RadioButtonJenisTransaksiAll.TabStop = True
        Me.RadioButtonJenisTransaksiAll.Text = "Semua"
        Me.RadioButtonJenisTransaksiAll.UseVisualStyleBackColor = False
        '
        'RadioButtonJenisTransaksiLaboratorium
        '
        Me.RadioButtonJenisTransaksiLaboratorium.AutoSize = True
        Me.RadioButtonJenisTransaksiLaboratorium.BackColor = System.Drawing.Color.Transparent
        Me.RadioButtonJenisTransaksiLaboratorium.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.RadioButtonJenisTransaksiLaboratorium.Location = New System.Drawing.Point(61, 2)
        Me.RadioButtonJenisTransaksiLaboratorium.Name = "RadioButtonJenisTransaksiLaboratorium"
        Me.RadioButtonJenisTransaksiLaboratorium.Size = New System.Drawing.Size(97, 19)
        Me.RadioButtonJenisTransaksiLaboratorium.TabIndex = 210
        Me.RadioButtonJenisTransaksiLaboratorium.TabStop = True
        Me.RadioButtonJenisTransaksiLaboratorium.Text = "Laboratorium"
        Me.RadioButtonJenisTransaksiLaboratorium.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(23, 168)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 17)
        Me.Label4.TabIndex = 251
        Me.Label4.Text = "Jenis Transaksi"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(23, 137)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 17)
        Me.Label5.TabIndex = 252
        Me.Label5.Text = "Acuan Tanggal"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel3.Controls.Add(Me.rdtanggalbayar)
        Me.Panel3.Controls.Add(Me.rdtanggalclosing)
        Me.Panel3.Location = New System.Drawing.Point(160, 135)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(336, 25)
        Me.Panel3.TabIndex = 253
        '
        'rdtanggalbayar
        '
        Me.rdtanggalbayar.AutoSize = True
        Me.rdtanggalbayar.BackColor = System.Drawing.Color.Transparent
        Me.rdtanggalbayar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdtanggalbayar.Location = New System.Drawing.Point(1, 2)
        Me.rdtanggalbayar.Name = "rdtanggalbayar"
        Me.rdtanggalbayar.Size = New System.Drawing.Size(98, 19)
        Me.rdtanggalbayar.TabIndex = 209
        Me.rdtanggalbayar.TabStop = True
        Me.rdtanggalbayar.Text = "Tanggal Bayar"
        Me.rdtanggalbayar.UseVisualStyleBackColor = False
        '
        'rdtanggalclosing
        '
        Me.rdtanggalclosing.AutoSize = True
        Me.rdtanggalclosing.BackColor = System.Drawing.Color.Transparent
        Me.rdtanggalclosing.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.rdtanggalclosing.Location = New System.Drawing.Point(105, 2)
        Me.rdtanggalclosing.Name = "rdtanggalclosing"
        Me.rdtanggalclosing.Size = New System.Drawing.Size(109, 19)
        Me.rdtanggalclosing.TabIndex = 211
        Me.rdtanggalclosing.TabStop = True
        Me.rdtanggalclosing.Text = "Tanggal Closing"
        Me.rdtanggalclosing.UseVisualStyleBackColor = False
        '
        'butselectbank
        '
        Me.butselectbank.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butselectbank.Location = New System.Drawing.Point(502, 78)
        Me.butselectbank.Name = "butselectbank"
        Me.butselectbank.Size = New System.Drawing.Size(31, 25)
        Me.butselectbank.TabIndex = 256
        Me.butselectbank.Text = "..."
        Me.butselectbank.UseVisualStyleBackColor = True
        '
        'TextBoxBankTransferKeterangan
        '
        Me.TextBoxBankTransferKeterangan.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBoxBankTransferKeterangan.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TextBoxBankTransferKeterangan.Location = New System.Drawing.Point(250, 75)
        Me.TextBoxBankTransferKeterangan.Name = "TextBoxBankTransferKeterangan"
        Me.TextBoxBankTransferKeterangan.ReadOnly = True
        Me.TextBoxBankTransferKeterangan.Size = New System.Drawing.Size(246, 23)
        Me.TextBoxBankTransferKeterangan.TabIndex = 255
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(23, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 17)
        Me.Label2.TabIndex = 254
        Me.Label2.Text = "Bank Transfer"
        '
        'TextBoxBankTransferCoa
        '
        Me.TextBoxBankTransferCoa.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.TextBoxBankTransferCoa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxBankTransferCoa.Cursor = System.Windows.Forms.Cursors.No
        Me.TextBoxBankTransferCoa.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TextBoxBankTransferCoa.Location = New System.Drawing.Point(160, 75)
        Me.TextBoxBankTransferCoa.Name = "TextBoxBankTransferCoa"
        Me.TextBoxBankTransferCoa.ReadOnly = True
        Me.TextBoxBankTransferCoa.Size = New System.Drawing.Size(84, 23)
        Me.TextBoxBankTransferCoa.TabIndex = 582
        Me.TextBoxBankTransferCoa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ReportClosingBankTagihan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.PoliKlinik_Net2.My.Resources.Resources.wallpaperdialog
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(684, 461)
        Me.Controls.Add(Me.TextBoxBankTransferCoa)
        Me.Controls.Add(Me.butselectbank)
        Me.Controls.Add(Me.TextBoxBankTransferKeterangan)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtkasirawal)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtkasirakhir)
        Me.Controls.Add(Me.butfind)
        Me.Controls.Add(Me.TextBoxNamaPerusahaan)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.butdisplay)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(700, 500)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(700, 500)
        Me.Name = "ReportClosingBankTagihan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Report Bank Pembayaran Tagihan"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtkasirakhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtkasirawal As System.Windows.Forms.DateTimePicker
    Friend WithEvents butdisplay As System.Windows.Forms.Button
    Friend WithEvents butfind As System.Windows.Forms.Button
    Friend WithEvents TextBoxNamaPerusahaan As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents RadioButtonJenisTransaksiKlinik As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonJenisTransaksiAll As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonJenisTransaksiLaboratorium As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents rdtanggalbayar As System.Windows.Forms.RadioButton
    Friend WithEvents rdtanggalclosing As System.Windows.Forms.RadioButton
    Friend WithEvents butselectbank As System.Windows.Forms.Button
    Friend WithEvents TextBoxBankTransferKeterangan As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBoxBankTransferCoa As System.Windows.Forms.TextBox
End Class
