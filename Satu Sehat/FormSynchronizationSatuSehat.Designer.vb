<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSynchronizationSatuSehat
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSynchronizationSatuSehat))
        Me.PanelTop = New System.Windows.Forms.Panel
        Me.btnClose = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ProgressBarSinkronisasi = New System.Windows.Forms.ProgressBar
        Me.Label1 = New System.Windows.Forms.Label
        Me.LabelProgress = New System.Windows.Forms.Label
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.LabelJumlahPasienTanpaNomorIHS = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.ButtonSinkronisasiIHS = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.LabelJumlahTransaksi = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.LabelPersentaseTransaksiVerifikasi = New System.Windows.Forms.Label
        Me.LabelJumlahTransaksiVerifikasi = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.LabelSinkronisasi = New System.Windows.Forms.Label
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.LabelPersentaseTransaksiNonVerifikasi = New System.Windows.Forms.Label
        Me.LabelJumlahTransaksiNonVerifikasi = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.LabelPersentaseTransaksiSatuSehat = New System.Windows.Forms.Label
        Me.LabelJumlahTransaksiSatuSehat = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.ButtonSinkronisasi = New System.Windows.Forms.Button
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer
        Me.TextBoxResponse = New System.Windows.Forms.TextBox
        Me.ButtonStopProses = New System.Windows.Forms.Button
        Me.PanelTop.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.PanelTop.Controls.Add(Me.btnClose)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(1000, 35)
        Me.PanelTop.TabIndex = 5
        '
        'btnClose
        '
        Me.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.Location = New System.Drawing.Point(953, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(47, 35)
        Me.btnClose.TabIndex = 281
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.ProgressBarSinkronisasi)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.LabelProgress)
        Me.Panel1.Controls.Add(Me.ButtonStopProses)
        Me.Panel1.Controls.Add(Me.Panel7)
        Me.Panel1.Controls.Add(Me.ButtonSinkronisasiIHS)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.LabelSinkronisasi)
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.ButtonSinkronisasi)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1000, 300)
        Me.Panel1.TabIndex = 6
        '
        'ProgressBarSinkronisasi
        '
        Me.ProgressBarSinkronisasi.ForeColor = System.Drawing.Color.White
        Me.ProgressBarSinkronisasi.Location = New System.Drawing.Point(12, 250)
        Me.ProgressBarSinkronisasi.Name = "ProgressBarSinkronisasi"
        Me.ProgressBarSinkronisasi.Size = New System.Drawing.Size(718, 10)
        Me.ProgressBarSinkronisasi.TabIndex = 520
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 263)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 17)
        Me.Label1.TabIndex = 528
        Me.Label1.Text = "Status : "
        '
        'LabelProgress
        '
        Me.LabelProgress.AutoSize = True
        Me.LabelProgress.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelProgress.ForeColor = System.Drawing.Color.Black
        Me.LabelProgress.Location = New System.Drawing.Point(72, 263)
        Me.LabelProgress.Name = "LabelProgress"
        Me.LabelProgress.Size = New System.Drawing.Size(30, 17)
        Me.LabelProgress.TabIndex = 522
        Me.LabelProgress.Text = "0 %"
        '
        'Panel7
        '
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.LabelJumlahPasienTanpaNomorIHS)
        Me.Panel7.Controls.Add(Me.Label4)
        Me.Panel7.Location = New System.Drawing.Point(761, 6)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(200, 150)
        Me.Panel7.TabIndex = 525
        '
        'LabelJumlahPasienTanpaNomorIHS
        '
        Me.LabelJumlahPasienTanpaNomorIHS.AutoSize = True
        Me.LabelJumlahPasienTanpaNomorIHS.BackColor = System.Drawing.Color.Transparent
        Me.LabelJumlahPasienTanpaNomorIHS.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelJumlahPasienTanpaNomorIHS.Location = New System.Drawing.Point(10, 60)
        Me.LabelJumlahPasienTanpaNomorIHS.Name = "LabelJumlahPasienTanpaNomorIHS"
        Me.LabelJumlahPasienTanpaNomorIHS.Size = New System.Drawing.Size(93, 21)
        Me.LabelJumlahPasienTanpaNomorIHS.TabIndex = 514
        Me.LabelJumlahPasienTanpaNomorIHS.Text = "0 Transaksi"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(10, 10)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(166, 42)
        Me.Label4.TabIndex = 513
        Me.Label4.Text = "Transaksi Gagal Tanpa" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Nomor IHS"
        '
        'ButtonSinkronisasiIHS
        '
        Me.ButtonSinkronisasiIHS.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSinkronisasiIHS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonSinkronisasiIHS.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonSinkronisasiIHS.FlatAppearance.BorderSize = 0
        Me.ButtonSinkronisasiIHS.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSinkronisasiIHS.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonSinkronisasiIHS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSinkronisasiIHS.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonSinkronisasiIHS.ForeColor = System.Drawing.Color.White
        Me.ButtonSinkronisasiIHS.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_sync_24
        Me.ButtonSinkronisasiIHS.Location = New System.Drawing.Point(218, 209)
        Me.ButtonSinkronisasiIHS.Name = "ButtonSinkronisasiIHS"
        Me.ButtonSinkronisasiIHS.Size = New System.Drawing.Size(200, 35)
        Me.ButtonSinkronisasiIHS.TabIndex = 524
        Me.ButtonSinkronisasiIHS.Text = " Sinkronisasi IHS"
        Me.ButtonSinkronisasiIHS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonSinkronisasiIHS.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonSinkronisasiIHS.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.LabelJumlahTransaksi)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Location = New System.Drawing.Point(12, 6)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(175, 150)
        Me.Panel2.TabIndex = 512
        '
        'LabelJumlahTransaksi
        '
        Me.LabelJumlahTransaksi.AutoSize = True
        Me.LabelJumlahTransaksi.BackColor = System.Drawing.Color.Transparent
        Me.LabelJumlahTransaksi.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelJumlahTransaksi.Location = New System.Drawing.Point(10, 60)
        Me.LabelJumlahTransaksi.Name = "LabelJumlahTransaksi"
        Me.LabelJumlahTransaksi.Size = New System.Drawing.Size(93, 21)
        Me.LabelJumlahTransaksi.TabIndex = 514
        Me.LabelJumlahTransaksi.Text = "0 Transaksi"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(10, 10)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(136, 21)
        Me.Label5.TabIndex = 513
        Me.Label5.Text = "Data Keseluruhan"
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.LabelPersentaseTransaksiVerifikasi)
        Me.Panel3.Controls.Add(Me.LabelJumlahTransaksiVerifikasi)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Location = New System.Drawing.Point(193, 6)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(175, 150)
        Me.Panel3.TabIndex = 513
        '
        'LabelPersentaseTransaksiVerifikasi
        '
        Me.LabelPersentaseTransaksiVerifikasi.AutoSize = True
        Me.LabelPersentaseTransaksiVerifikasi.BackColor = System.Drawing.Color.Transparent
        Me.LabelPersentaseTransaksiVerifikasi.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPersentaseTransaksiVerifikasi.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(172, Byte), Integer))
        Me.LabelPersentaseTransaksiVerifikasi.Location = New System.Drawing.Point(10, 100)
        Me.LabelPersentaseTransaksiVerifikasi.Name = "LabelPersentaseTransaksiVerifikasi"
        Me.LabelPersentaseTransaksiVerifikasi.Size = New System.Drawing.Size(39, 25)
        Me.LabelPersentaseTransaksiVerifikasi.TabIndex = 515
        Me.LabelPersentaseTransaksiVerifikasi.Text = "0%"
        '
        'LabelJumlahTransaksiVerifikasi
        '
        Me.LabelJumlahTransaksiVerifikasi.AutoSize = True
        Me.LabelJumlahTransaksiVerifikasi.BackColor = System.Drawing.Color.Transparent
        Me.LabelJumlahTransaksiVerifikasi.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelJumlahTransaksiVerifikasi.Location = New System.Drawing.Point(10, 60)
        Me.LabelJumlahTransaksiVerifikasi.Name = "LabelJumlahTransaksiVerifikasi"
        Me.LabelJumlahTransaksiVerifikasi.Size = New System.Drawing.Size(93, 21)
        Me.LabelJumlahTransaksiVerifikasi.TabIndex = 514
        Me.LabelJumlahTransaksiVerifikasi.Text = "0 Transaksi"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(10, 10)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(134, 21)
        Me.Label11.TabIndex = 513
        Me.Label11.Text = "Data Terverifikasi"
        '
        'LabelSinkronisasi
        '
        Me.LabelSinkronisasi.AutoSize = True
        Me.LabelSinkronisasi.BackColor = System.Drawing.Color.Transparent
        Me.LabelSinkronisasi.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSinkronisasi.Location = New System.Drawing.Point(9, 179)
        Me.LabelSinkronisasi.Name = "LabelSinkronisasi"
        Me.LabelSinkronisasi.Size = New System.Drawing.Size(344, 17)
        Me.LabelSinkronisasi.TabIndex = 519
        Me.LabelSinkronisasi.Text = "Sinkronisasi terakhir dilakukan pada 23 November 2023"
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.LabelPersentaseTransaksiNonVerifikasi)
        Me.Panel4.Controls.Add(Me.LabelJumlahTransaksiNonVerifikasi)
        Me.Panel4.Controls.Add(Me.Label13)
        Me.Panel4.Location = New System.Drawing.Point(374, 6)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(175, 150)
        Me.Panel4.TabIndex = 514
        '
        'LabelPersentaseTransaksiNonVerifikasi
        '
        Me.LabelPersentaseTransaksiNonVerifikasi.AutoSize = True
        Me.LabelPersentaseTransaksiNonVerifikasi.BackColor = System.Drawing.Color.Transparent
        Me.LabelPersentaseTransaksiNonVerifikasi.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPersentaseTransaksiNonVerifikasi.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(172, Byte), Integer))
        Me.LabelPersentaseTransaksiNonVerifikasi.Location = New System.Drawing.Point(9, 100)
        Me.LabelPersentaseTransaksiNonVerifikasi.Name = "LabelPersentaseTransaksiNonVerifikasi"
        Me.LabelPersentaseTransaksiNonVerifikasi.Size = New System.Drawing.Size(39, 25)
        Me.LabelPersentaseTransaksiNonVerifikasi.TabIndex = 516
        Me.LabelPersentaseTransaksiNonVerifikasi.Text = "0%"
        '
        'LabelJumlahTransaksiNonVerifikasi
        '
        Me.LabelJumlahTransaksiNonVerifikasi.AutoSize = True
        Me.LabelJumlahTransaksiNonVerifikasi.BackColor = System.Drawing.Color.Transparent
        Me.LabelJumlahTransaksiNonVerifikasi.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelJumlahTransaksiNonVerifikasi.Location = New System.Drawing.Point(10, 60)
        Me.LabelJumlahTransaksiNonVerifikasi.Name = "LabelJumlahTransaksiNonVerifikasi"
        Me.LabelJumlahTransaksiNonVerifikasi.Size = New System.Drawing.Size(93, 21)
        Me.LabelJumlahTransaksiNonVerifikasi.TabIndex = 514
        Me.LabelJumlahTransaksiNonVerifikasi.Text = "0 Transaksi"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(10, 10)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(97, 42)
        Me.Label13.TabIndex = 513
        Me.Label13.Text = "Data Belum" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Terverifikasi"
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.LabelPersentaseTransaksiSatuSehat)
        Me.Panel5.Controls.Add(Me.LabelJumlahTransaksiSatuSehat)
        Me.Panel5.Controls.Add(Me.Label15)
        Me.Panel5.Location = New System.Drawing.Point(555, 6)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(200, 150)
        Me.Panel5.TabIndex = 515
        '
        'LabelPersentaseTransaksiSatuSehat
        '
        Me.LabelPersentaseTransaksiSatuSehat.AutoSize = True
        Me.LabelPersentaseTransaksiSatuSehat.BackColor = System.Drawing.Color.Transparent
        Me.LabelPersentaseTransaksiSatuSehat.Font = New System.Drawing.Font("Segoe UI Semibold", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPersentaseTransaksiSatuSehat.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(172, Byte), Integer))
        Me.LabelPersentaseTransaksiSatuSehat.Location = New System.Drawing.Point(9, 100)
        Me.LabelPersentaseTransaksiSatuSehat.Name = "LabelPersentaseTransaksiSatuSehat"
        Me.LabelPersentaseTransaksiSatuSehat.Size = New System.Drawing.Size(39, 25)
        Me.LabelPersentaseTransaksiSatuSehat.TabIndex = 516
        Me.LabelPersentaseTransaksiSatuSehat.Text = "0%"
        '
        'LabelJumlahTransaksiSatuSehat
        '
        Me.LabelJumlahTransaksiSatuSehat.AutoSize = True
        Me.LabelJumlahTransaksiSatuSehat.BackColor = System.Drawing.Color.Transparent
        Me.LabelJumlahTransaksiSatuSehat.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelJumlahTransaksiSatuSehat.Location = New System.Drawing.Point(10, 60)
        Me.LabelJumlahTransaksiSatuSehat.Name = "LabelJumlahTransaksiSatuSehat"
        Me.LabelJumlahTransaksiSatuSehat.Size = New System.Drawing.Size(93, 21)
        Me.LabelJumlahTransaksiSatuSehat.TabIndex = 514
        Me.LabelJumlahTransaksiSatuSehat.Text = "0 Transaksi"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(10, 10)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(145, 42)
        Me.Label15.TabIndex = 513
        Me.Label15.Text = "Mengirim Data Ke " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "SATUSEHAT"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.Button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Button1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(424, 209)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(150, 35)
        Me.Button1.TabIndex = 517
        Me.Button1.Text = " Refresh"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = False
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
        Me.ButtonSinkronisasi.Location = New System.Drawing.Point(12, 209)
        Me.ButtonSinkronisasi.Name = "ButtonSinkronisasi"
        Me.ButtonSinkronisasi.Size = New System.Drawing.Size(200, 35)
        Me.ButtonSinkronisasi.TabIndex = 516
        Me.ButtonSinkronisasi.Text = " Sinkronisasi Data"
        Me.ButtonSinkronisasi.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonSinkronisasi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonSinkronisasi.UseVisualStyleBackColor = False
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer3.IsSplitterFixed = True
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 35)
        Me.SplitContainer3.Name = "SplitContainer3"
        Me.SplitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.AutoScroll = True
        Me.SplitContainer3.Panel1.Controls.Add(Me.Panel1)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.AutoScroll = True
        Me.SplitContainer3.Panel2.Controls.Add(Me.TextBoxResponse)
        Me.SplitContainer3.Size = New System.Drawing.Size(1000, 540)
        Me.SplitContainer3.SplitterDistance = 300
        Me.SplitContainer3.SplitterWidth = 5
        Me.SplitContainer3.TabIndex = 462
        '
        'TextBoxResponse
        '
        Me.TextBoxResponse.BackColor = System.Drawing.Color.White
        Me.TextBoxResponse.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxResponse.Location = New System.Drawing.Point(0, 0)
        Me.TextBoxResponse.Multiline = True
        Me.TextBoxResponse.Name = "TextBoxResponse"
        Me.TextBoxResponse.ReadOnly = True
        Me.TextBoxResponse.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextBoxResponse.Size = New System.Drawing.Size(1000, 235)
        Me.TextBoxResponse.TabIndex = 461
        '
        'ButtonStopProses
        '
        Me.ButtonStopProses.BackColor = System.Drawing.Color.White
        Me.ButtonStopProses.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonStopProses.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonStopProses.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonStopProses.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonStopProses.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonStopProses.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonStopProses.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonStopProses.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonStopProses.Image = CType(resources.GetObject("ButtonStopProses.Image"), System.Drawing.Image)
        Me.ButtonStopProses.Location = New System.Drawing.Point(580, 209)
        Me.ButtonStopProses.Name = "ButtonStopProses"
        Me.ButtonStopProses.Size = New System.Drawing.Size(150, 35)
        Me.ButtonStopProses.TabIndex = 527
        Me.ButtonStopProses.Text = " Stop Proses"
        Me.ButtonStopProses.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonStopProses.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonStopProses.UseVisualStyleBackColor = False
        '
        'FormSynchronizationSatuSehat
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1000, 575)
        Me.ControlBox = False
        Me.Controls.Add(Me.SplitContainer3)
        Me.Controls.Add(Me.PanelTop)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSynchronizationSatuSehat"
        Me.PanelTop.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.Panel2.PerformLayout()
        Me.SplitContainer3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents LabelJumlahTransaksiNonVerifikasi As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents LabelJumlahTransaksiVerifikasi As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents LabelJumlahTransaksi As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents LabelJumlahTransaksiSatuSehat As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents LabelPersentaseTransaksiVerifikasi As System.Windows.Forms.Label
    Friend WithEvents LabelPersentaseTransaksiSatuSehat As System.Windows.Forms.Label
    Friend WithEvents LabelPersentaseTransaksiNonVerifikasi As System.Windows.Forms.Label
    Friend WithEvents ButtonSinkronisasi As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents LabelSinkronisasi As System.Windows.Forms.Label
    Friend WithEvents ProgressBarSinkronisasi As System.Windows.Forms.ProgressBar
    Friend WithEvents LabelProgress As System.Windows.Forms.Label
    Friend WithEvents TextBoxResponse As System.Windows.Forms.TextBox
    Friend WithEvents ButtonSinkronisasiIHS As System.Windows.Forms.Button
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents LabelJumlahPasienTanpaNomorIHS As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonStopProses As System.Windows.Forms.Button
End Class
