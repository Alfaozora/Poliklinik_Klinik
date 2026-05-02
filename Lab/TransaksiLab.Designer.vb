<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TransaksiLab
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
        Me.components = New System.ComponentModel.Container
        Dim GridLevelNode1 As DevExpress.XtraGrid.GridLevelNode = New DevExpress.XtraGrid.GridLevelNode
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TransaksiLab))
        Me.GroupBoxDetailPasien = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ButtonFindDokter = New System.Windows.Forms.Button
        Me.ButtonFindTransaksi = New System.Windows.Forms.Button
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.TextBoxNoRekamMedis = New System.Windows.Forms.TextBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txkartu_ = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txjenisbayar_ = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.TextBoxNoUrutTransaksi = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.TextBoxNamaDokter = New System.Windows.Forms.TextBox
        Me.TextBoxDokterID = New System.Windows.Forms.TextBox
        Me.chkclosed = New System.Windows.Forms.CheckBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TextBoxNamaPasien = New System.Windows.Forms.TextBox
        Me.dtcusttgllhr = New System.Windows.Forms.DateTimePicker
        Me.TextBoxUmurPasien = New System.Windows.Forms.TextBox
        Me.dtnow = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.rdhardcopy1 = New System.Windows.Forms.RadioButton
        Me.rdhardcopy2 = New System.Windows.Forms.RadioButton
        Me.txhardcopykirim = New System.Windows.Forms.TextBox
        Me.rdhardcopy3 = New System.Windows.Forms.RadioButton
        Me.txwarningperusahaan = New System.Windows.Forms.Label
        Me.txidreferensiperusahaan = New System.Windows.Forms.TextBox
        Me.txnamareferensiperusahaan = New System.Windows.Forms.TextBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.rdreferensiperusahaan1 = New System.Windows.Forms.RadioButton
        Me.rdreferensiperusahaan2 = New System.Windows.Forms.RadioButton
        Me.Label9 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.CheckBoxNomorWhatsapp = New System.Windows.Forms.CheckBox
        Me.rdsoftcopy1 = New System.Windows.Forms.RadioButton
        Me.RadioButtonSoftCopyWhatsapp = New System.Windows.Forms.RadioButton
        Me.TextBoxSoftCopyWhatsapp = New System.Windows.Forms.TextBox
        Me.rdsoftcopy3 = New System.Windows.Forms.RadioButton
        Me.txsoftcopyemail = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.butsaved = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.TextBoxTotalBayar = New DevExpress.XtraEditors.TextEdit
        Me.TextBoxTotalPembulatan = New DevExpress.XtraEditors.TextEdit
        Me.TextBoxTotalBruto = New DevExpress.XtraEditors.TextEdit
        Me.TextBoxTotalDiskon = New DevExpress.XtraEditors.TextEdit
        Me.TextBoxTotalNett = New DevExpress.XtraEditors.TextEdit
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.gridtindakan = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.MenuStrip2 = New System.Windows.Forms.MenuStrip
        Me.TambahTindakanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TambahPaketToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.KalkulasiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.NewToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.TambahDokterPengirimToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UpdateMasterPerusahaanToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CekTransaksiDone = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBoxDetailPasien.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.TextBoxTotalBayar.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxTotalPembulatan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxTotalBruto.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxTotalDiskon.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBoxTotalNett.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.gridtindakan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip2.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBoxDetailPasien
        '
        Me.GroupBoxDetailPasien.BackColor = System.Drawing.Color.White
        Me.GroupBoxDetailPasien.Controls.Add(Me.Label1)
        Me.GroupBoxDetailPasien.Controls.Add(Me.ButtonFindDokter)
        Me.GroupBoxDetailPasien.Controls.Add(Me.ButtonFindTransaksi)
        Me.GroupBoxDetailPasien.Controls.Add(Me.Label14)
        Me.GroupBoxDetailPasien.Controls.Add(Me.Label12)
        Me.GroupBoxDetailPasien.Controls.Add(Me.TextBoxNoRekamMedis)
        Me.GroupBoxDetailPasien.Controls.Add(Me.GroupBox3)
        Me.GroupBoxDetailPasien.Controls.Add(Me.ProgressBar1)
        Me.GroupBoxDetailPasien.Controls.Add(Me.TextBoxNoUrutTransaksi)
        Me.GroupBoxDetailPasien.Controls.Add(Me.Label22)
        Me.GroupBoxDetailPasien.Controls.Add(Me.Label21)
        Me.GroupBoxDetailPasien.Controls.Add(Me.TextBoxNamaDokter)
        Me.GroupBoxDetailPasien.Controls.Add(Me.TextBoxDokterID)
        Me.GroupBoxDetailPasien.Controls.Add(Me.chkclosed)
        Me.GroupBoxDetailPasien.Controls.Add(Me.Label10)
        Me.GroupBoxDetailPasien.Controls.Add(Me.TextBoxNamaPasien)
        Me.GroupBoxDetailPasien.Controls.Add(Me.dtcusttgllhr)
        Me.GroupBoxDetailPasien.Controls.Add(Me.TextBoxUmurPasien)
        Me.GroupBoxDetailPasien.Controls.Add(Me.dtnow)
        Me.GroupBoxDetailPasien.Controls.Add(Me.Label2)
        Me.GroupBoxDetailPasien.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBoxDetailPasien.Location = New System.Drawing.Point(0, 24)
        Me.GroupBoxDetailPasien.Name = "GroupBoxDetailPasien"
        Me.GroupBoxDetailPasien.Size = New System.Drawing.Size(957, 155)
        Me.GroupBoxDetailPasien.TabIndex = 5
        Me.GroupBoxDetailPasien.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(455, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(42, 17)
        Me.Label1.TabIndex = 446
        Me.Label1.Text = "Umur"
        '
        'ButtonFindDokter
        '
        Me.ButtonFindDokter.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindDokter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonFindDokter.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonFindDokter.FlatAppearance.BorderSize = 0
        Me.ButtonFindDokter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindDokter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonFindDokter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonFindDokter.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonFindDokter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ButtonFindDokter.Location = New System.Drawing.Point(317, 113)
        Me.ButtonFindDokter.Name = "ButtonFindDokter"
        Me.ButtonFindDokter.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonFindDokter.Size = New System.Drawing.Size(60, 25)
        Me.ButtonFindDokter.TabIndex = 445
        Me.ButtonFindDokter.Text = " Cari"
        Me.ButtonFindDokter.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonFindDokter.UseVisualStyleBackColor = False
        '
        'ButtonFindTransaksi
        '
        Me.ButtonFindTransaksi.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindTransaksi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonFindTransaksi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonFindTransaksi.FlatAppearance.BorderSize = 0
        Me.ButtonFindTransaksi.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindTransaksi.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonFindTransaksi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonFindTransaksi.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonFindTransaksi.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ButtonFindTransaksi.Location = New System.Drawing.Point(317, 20)
        Me.ButtonFindTransaksi.Name = "ButtonFindTransaksi"
        Me.ButtonFindTransaksi.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonFindTransaksi.Size = New System.Drawing.Size(60, 25)
        Me.ButtonFindTransaksi.TabIndex = 444
        Me.ButtonFindTransaksi.Text = " Cari"
        Me.ButtonFindTransaksi.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonFindTransaksi.UseVisualStyleBackColor = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label14.Location = New System.Drawing.Point(12, 23)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(80, 17)
        Me.Label14.TabIndex = 194
        Me.Label14.Text = "Transaksi ID"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(42, 85)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(50, 17)
        Me.Label12.TabIndex = 193
        Me.Label12.Text = "No RM"
        '
        'TextBoxNoRekamMedis
        '
        Me.TextBoxNoRekamMedis.BackColor = System.Drawing.Color.White
        Me.TextBoxNoRekamMedis.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxNoRekamMedis.Location = New System.Drawing.Point(127, 82)
        Me.TextBoxNoRekamMedis.Name = "TextBoxNoRekamMedis"
        Me.TextBoxNoRekamMedis.ReadOnly = True
        Me.TextBoxNoRekamMedis.Size = New System.Drawing.Size(250, 25)
        Me.TextBoxNoRekamMedis.TabIndex = 192
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txkartu_)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.txjenisbayar_)
        Me.GroupBox3.Controls.Add(Me.Label11)
        Me.GroupBox3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(736, 19)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(215, 88)
        Me.GroupBox3.TabIndex = 191
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Pembayaran Via QR Code"
        '
        'txkartu_
        '
        Me.txkartu_.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txkartu_.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txkartu_.Location = New System.Drawing.Point(88, 51)
        Me.txkartu_.Name = "txkartu_"
        Me.txkartu_.ReadOnly = True
        Me.txkartu_.Size = New System.Drawing.Size(118, 25)
        Me.txkartu_.TabIndex = 195
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label13.Location = New System.Drawing.Point(40, 54)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(41, 17)
        Me.Label13.TabIndex = 194
        Me.Label13.Text = "Kartu"
        '
        'txjenisbayar_
        '
        Me.txjenisbayar_.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txjenisbayar_.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.txjenisbayar_.Location = New System.Drawing.Point(88, 20)
        Me.txjenisbayar_.Name = "txjenisbayar_"
        Me.txjenisbayar_.ReadOnly = True
        Me.txjenisbayar_.Size = New System.Drawing.Size(118, 25)
        Me.txjenisbayar_.TabIndex = 191
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(6, 23)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(75, 17)
        Me.Label11.TabIndex = 190
        Me.Label11.Text = "Jenis Bayar"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.BackColor = System.Drawing.Color.Lime
        Me.ProgressBar1.Location = New System.Drawing.Point(21, 144)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(693, 5)
        Me.ProgressBar1.TabIndex = 190
        '
        'TextBoxNoUrutTransaksi
        '
        Me.TextBoxNoUrutTransaksi.BackColor = System.Drawing.Color.White
        Me.TextBoxNoUrutTransaksi.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxNoUrutTransaksi.Location = New System.Drawing.Point(127, 20)
        Me.TextBoxNoUrutTransaksi.Name = "TextBoxNoUrutTransaksi"
        Me.TextBoxNoUrutTransaksi.ReadOnly = True
        Me.TextBoxNoUrutTransaksi.Size = New System.Drawing.Size(184, 25)
        Me.TextBoxNoUrutTransaksi.TabIndex = 189
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label22.Location = New System.Drawing.Point(439, 88)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(58, 17)
        Me.Label22.TabIndex = 187
        Me.Label22.Text = "Tgl Lahir"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label21.Location = New System.Drawing.Point(413, 54)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(84, 17)
        Me.Label21.TabIndex = 186
        Me.Label21.Text = "Tgl Transaksi"
        '
        'TextBoxNamaDokter
        '
        Me.TextBoxNamaDokter.BackColor = System.Drawing.Color.White
        Me.TextBoxNamaDokter.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxNamaDokter.Location = New System.Drawing.Point(127, 113)
        Me.TextBoxNamaDokter.Name = "TextBoxNamaDokter"
        Me.TextBoxNamaDokter.ReadOnly = True
        Me.TextBoxNamaDokter.Size = New System.Drawing.Size(184, 25)
        Me.TextBoxNamaDokter.TabIndex = 183
        '
        'TextBoxDokterID
        '
        Me.TextBoxDokterID.BackColor = System.Drawing.Color.White
        Me.TextBoxDokterID.Enabled = False
        Me.TextBoxDokterID.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxDokterID.Location = New System.Drawing.Point(127, 113)
        Me.TextBoxDokterID.Name = "TextBoxDokterID"
        Me.TextBoxDokterID.Size = New System.Drawing.Size(41, 25)
        Me.TextBoxDokterID.TabIndex = 126
        Me.TextBoxDokterID.Visible = False
        '
        'chkclosed
        '
        Me.chkclosed.AutoSize = True
        Me.chkclosed.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.chkclosed.Location = New System.Drawing.Point(530, 113)
        Me.chkclosed.Name = "chkclosed"
        Me.chkclosed.Size = New System.Drawing.Size(67, 21)
        Me.chkclosed.TabIndex = 5
        Me.chkclosed.Text = "Closed"
        Me.chkclosed.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(10, 116)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 17)
        Me.Label10.TabIndex = 100
        Me.Label10.Text = "Dr. Pengirim"
        '
        'TextBoxNamaPasien
        '
        Me.TextBoxNamaPasien.BackColor = System.Drawing.Color.White
        Me.TextBoxNamaPasien.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxNamaPasien.Location = New System.Drawing.Point(127, 51)
        Me.TextBoxNamaPasien.Name = "TextBoxNamaPasien"
        Me.TextBoxNamaPasien.ReadOnly = True
        Me.TextBoxNamaPasien.Size = New System.Drawing.Size(250, 25)
        Me.TextBoxNamaPasien.TabIndex = 61
        '
        'dtcusttgllhr
        '
        Me.dtcusttgllhr.CustomFormat = "dd-MMM-yyyy"
        Me.dtcusttgllhr.Enabled = False
        Me.dtcusttgllhr.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.dtcusttgllhr.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtcusttgllhr.Location = New System.Drawing.Point(530, 82)
        Me.dtcusttgllhr.Name = "dtcusttgllhr"
        Me.dtcusttgllhr.Size = New System.Drawing.Size(125, 25)
        Me.dtcusttgllhr.TabIndex = 60
        '
        'TextBoxUmurPasien
        '
        Me.TextBoxUmurPasien.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBoxUmurPasien.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxUmurPasien.Location = New System.Drawing.Point(530, 20)
        Me.TextBoxUmurPasien.Name = "TextBoxUmurPasien"
        Me.TextBoxUmurPasien.ReadOnly = True
        Me.TextBoxUmurPasien.Size = New System.Drawing.Size(184, 25)
        Me.TextBoxUmurPasien.TabIndex = 6
        '
        'dtnow
        '
        Me.dtnow.CustomFormat = "dd-MMM-yyyy"
        Me.dtnow.Enabled = False
        Me.dtnow.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.dtnow.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtnow.Location = New System.Drawing.Point(530, 51)
        Me.dtnow.Name = "dtnow"
        Me.dtnow.Size = New System.Drawing.Size(125, 25)
        Me.dtnow.TabIndex = 62
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(48, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Nama"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel3)
        Me.GroupBox1.Controls.Add(Me.txwarningperusahaan)
        Me.GroupBox1.Controls.Add(Me.txidreferensiperusahaan)
        Me.GroupBox1.Controls.Add(Me.txnamareferensiperusahaan)
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.butsaved)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.TextBoxTotalBayar)
        Me.GroupBox1.Controls.Add(Me.TextBoxTotalPembulatan)
        Me.GroupBox1.Controls.Add(Me.TextBoxTotalBruto)
        Me.GroupBox1.Controls.Add(Me.TextBoxTotalDiskon)
        Me.GroupBox1.Controls.Add(Me.TextBoxTotalNett)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(0, 366)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(957, 215)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Summary Total"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.rdhardcopy1)
        Me.Panel3.Controls.Add(Me.rdhardcopy2)
        Me.Panel3.Controls.Add(Me.txhardcopykirim)
        Me.Panel3.Controls.Add(Me.rdhardcopy3)
        Me.Panel3.Location = New System.Drawing.Point(580, 50)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(281, 88)
        Me.Panel3.TabIndex = 258
        '
        'rdhardcopy1
        '
        Me.rdhardcopy1.AutoSize = True
        Me.rdhardcopy1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdhardcopy1.Location = New System.Drawing.Point(8, 3)
        Me.rdhardcopy1.Name = "rdhardcopy1"
        Me.rdhardcopy1.Size = New System.Drawing.Size(90, 19)
        Me.rdhardcopy1.TabIndex = 248
        Me.rdhardcopy1.TabStop = True
        Me.rdhardcopy1.Text = "Tidak Perlu."
        Me.rdhardcopy1.UseVisualStyleBackColor = True
        '
        'rdhardcopy2
        '
        Me.rdhardcopy2.AutoSize = True
        Me.rdhardcopy2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdhardcopy2.Location = New System.Drawing.Point(8, 28)
        Me.rdhardcopy2.Name = "rdhardcopy2"
        Me.rdhardcopy2.Size = New System.Drawing.Size(86, 19)
        Me.rdhardcopy2.TabIndex = 250
        Me.rdhardcopy2.TabStop = True
        Me.rdhardcopy2.Text = "Dikirim ke :"
        Me.rdhardcopy2.UseVisualStyleBackColor = True
        '
        'txhardcopykirim
        '
        Me.txhardcopykirim.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txhardcopykirim.Enabled = False
        Me.txhardcopykirim.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txhardcopykirim.Location = New System.Drawing.Point(116, 28)
        Me.txhardcopykirim.Name = "txhardcopykirim"
        Me.txhardcopykirim.Size = New System.Drawing.Size(150, 20)
        Me.txhardcopykirim.TabIndex = 251
        '
        'rdhardcopy3
        '
        Me.rdhardcopy3.AutoSize = True
        Me.rdhardcopy3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdhardcopy3.Location = New System.Drawing.Point(8, 54)
        Me.rdhardcopy3.Name = "rdhardcopy3"
        Me.rdhardcopy3.Size = New System.Drawing.Size(100, 19)
        Me.rdhardcopy3.TabIndex = 249
        Me.rdhardcopy3.TabStop = True
        Me.rdhardcopy3.Text = "Ambil sendiri."
        Me.rdhardcopy3.UseVisualStyleBackColor = True
        '
        'txwarningperusahaan
        '
        Me.txwarningperusahaan.AutoSize = True
        Me.txwarningperusahaan.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txwarningperusahaan.ForeColor = System.Drawing.Color.OrangeRed
        Me.txwarningperusahaan.Location = New System.Drawing.Point(555, 20)
        Me.txwarningperusahaan.Name = "txwarningperusahaan"
        Me.txwarningperusahaan.Size = New System.Drawing.Size(44, 15)
        Me.txwarningperusahaan.TabIndex = 257
        Me.txwarningperusahaan.Text = "*Note :"
        '
        'txidreferensiperusahaan
        '
        Me.txidreferensiperusahaan.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txidreferensiperusahaan.Enabled = False
        Me.txidreferensiperusahaan.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txidreferensiperusahaan.Location = New System.Drawing.Point(351, 26)
        Me.txidreferensiperusahaan.Name = "txidreferensiperusahaan"
        Me.txidreferensiperusahaan.ReadOnly = True
        Me.txidreferensiperusahaan.Size = New System.Drawing.Size(112, 20)
        Me.txidreferensiperusahaan.TabIndex = 256
        Me.txidreferensiperusahaan.Visible = False
        '
        'txnamareferensiperusahaan
        '
        Me.txnamareferensiperusahaan.BackColor = System.Drawing.SystemColors.Window
        Me.txnamareferensiperusahaan.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txnamareferensiperusahaan.Location = New System.Drawing.Point(351, 26)
        Me.txnamareferensiperusahaan.Name = "txnamareferensiperusahaan"
        Me.txnamareferensiperusahaan.ReadOnly = True
        Me.txnamareferensiperusahaan.Size = New System.Drawing.Size(199, 20)
        Me.txnamareferensiperusahaan.TabIndex = 255
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rdreferensiperusahaan1)
        Me.Panel2.Controls.Add(Me.rdreferensiperusahaan2)
        Me.Panel2.Location = New System.Drawing.Point(222, 23)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(123, 25)
        Me.Panel2.TabIndex = 254
        '
        'rdreferensiperusahaan1
        '
        Me.rdreferensiperusahaan1.AutoSize = True
        Me.rdreferensiperusahaan1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdreferensiperusahaan1.Location = New System.Drawing.Point(8, 3)
        Me.rdreferensiperusahaan1.Name = "rdreferensiperusahaan1"
        Me.rdreferensiperusahaan1.Size = New System.Drawing.Size(38, 19)
        Me.rdreferensiperusahaan1.TabIndex = 242
        Me.rdreferensiperusahaan1.TabStop = True
        Me.rdreferensiperusahaan1.Text = "Ya"
        Me.rdreferensiperusahaan1.UseVisualStyleBackColor = True
        '
        'rdreferensiperusahaan2
        '
        Me.rdreferensiperusahaan2.AutoSize = True
        Me.rdreferensiperusahaan2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdreferensiperusahaan2.Location = New System.Drawing.Point(65, 3)
        Me.rdreferensiperusahaan2.Name = "rdreferensiperusahaan2"
        Me.rdreferensiperusahaan2.Size = New System.Drawing.Size(55, 19)
        Me.rdreferensiperusahaan2.TabIndex = 243
        Me.rdreferensiperusahaan2.TabStop = True
        Me.rdreferensiperusahaan2.Text = "Tidak"
        Me.rdreferensiperusahaan2.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(12, 29)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(207, 15)
        Me.Label9.TabIndex = 253
        Me.Label9.Text = "Apakah ada referensi perusahaan?"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.CheckBoxNomorWhatsapp)
        Me.Panel1.Controls.Add(Me.rdsoftcopy1)
        Me.Panel1.Controls.Add(Me.RadioButtonSoftCopyWhatsapp)
        Me.Panel1.Controls.Add(Me.TextBoxSoftCopyWhatsapp)
        Me.Panel1.Controls.Add(Me.rdsoftcopy3)
        Me.Panel1.Controls.Add(Me.txsoftcopyemail)
        Me.Panel1.Location = New System.Drawing.Point(222, 50)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(265, 103)
        Me.Panel1.TabIndex = 252
        '
        'CheckBoxNomorWhatsapp
        '
        Me.CheckBoxNomorWhatsapp.AutoSize = True
        Me.CheckBoxNomorWhatsapp.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxNomorWhatsapp.Location = New System.Drawing.Point(108, 79)
        Me.CheckBoxNomorWhatsapp.Name = "CheckBoxNomorWhatsapp"
        Me.CheckBoxNomorWhatsapp.Size = New System.Drawing.Size(147, 19)
        Me.CheckBoxNomorWhatsapp.TabIndex = 247
        Me.CheckBoxNomorWhatsapp.Text = "Sesuai Master Pasien"
        Me.CheckBoxNomorWhatsapp.UseVisualStyleBackColor = True
        '
        'rdsoftcopy1
        '
        Me.rdsoftcopy1.AutoSize = True
        Me.rdsoftcopy1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdsoftcopy1.Location = New System.Drawing.Point(8, 3)
        Me.rdsoftcopy1.Name = "rdsoftcopy1"
        Me.rdsoftcopy1.Size = New System.Drawing.Size(90, 19)
        Me.rdsoftcopy1.TabIndex = 242
        Me.rdsoftcopy1.TabStop = True
        Me.rdsoftcopy1.Text = "Tidak Perlu."
        Me.rdsoftcopy1.UseVisualStyleBackColor = True
        '
        'RadioButtonSoftCopyWhatsapp
        '
        Me.RadioButtonSoftCopyWhatsapp.AutoSize = True
        Me.RadioButtonSoftCopyWhatsapp.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButtonSoftCopyWhatsapp.Location = New System.Drawing.Point(8, 54)
        Me.RadioButtonSoftCopyWhatsapp.Name = "RadioButtonSoftCopyWhatsapp"
        Me.RadioButtonSoftCopyWhatsapp.Size = New System.Drawing.Size(87, 19)
        Me.RadioButtonSoftCopyWhatsapp.TabIndex = 243
        Me.RadioButtonSoftCopyWhatsapp.TabStop = True
        Me.RadioButtonSoftCopyWhatsapp.Text = "Whatsapp :"
        Me.RadioButtonSoftCopyWhatsapp.UseVisualStyleBackColor = True
        '
        'TextBoxSoftCopyWhatsapp
        '
        Me.TextBoxSoftCopyWhatsapp.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBoxSoftCopyWhatsapp.Enabled = False
        Me.TextBoxSoftCopyWhatsapp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxSoftCopyWhatsapp.Location = New System.Drawing.Point(108, 54)
        Me.TextBoxSoftCopyWhatsapp.Name = "TextBoxSoftCopyWhatsapp"
        Me.TextBoxSoftCopyWhatsapp.Size = New System.Drawing.Size(150, 20)
        Me.TextBoxSoftCopyWhatsapp.TabIndex = 244
        '
        'rdsoftcopy3
        '
        Me.rdsoftcopy3.AutoSize = True
        Me.rdsoftcopy3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdsoftcopy3.Location = New System.Drawing.Point(8, 28)
        Me.rdsoftcopy3.Name = "rdsoftcopy3"
        Me.rdsoftcopy3.Size = New System.Drawing.Size(63, 19)
        Me.rdsoftcopy3.TabIndex = 245
        Me.rdsoftcopy3.TabStop = True
        Me.rdsoftcopy3.Text = "Email :"
        Me.rdsoftcopy3.UseVisualStyleBackColor = True
        '
        'txsoftcopyemail
        '
        Me.txsoftcopyemail.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txsoftcopyemail.Enabled = False
        Me.txsoftcopyemail.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txsoftcopyemail.Location = New System.Drawing.Point(108, 28)
        Me.txsoftcopyemail.Name = "txsoftcopyemail"
        Me.txsoftcopyemail.Size = New System.Drawing.Size(150, 20)
        Me.txsoftcopyemail.TabIndex = 246
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(503, 55)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 16)
        Me.Label8.TabIndex = 247
        Me.Label8.Text = "Hardcopy"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(147, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 16)
        Me.Label6.TabIndex = 241
        Me.Label6.Text = "Softcopy"
        '
        'butsaved
        '
        Me.butsaved.Cursor = System.Windows.Forms.Cursors.Hand
        Me.butsaved.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butsaved.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_save
        Me.butsaved.Location = New System.Drawing.Point(549, 167)
        Me.butsaved.Name = "butsaved"
        Me.butsaved.Size = New System.Drawing.Size(100, 36)
        Me.butsaved.TabIndex = 238
        Me.butsaved.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button3.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_kalkulasi
        Me.Button3.Location = New System.Drawing.Point(655, 167)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(100, 36)
        Me.Button3.TabIndex = 237
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(222, 156)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 16)
        Me.Label5.TabIndex = 236
        Me.Label5.Text = "Total Bayar"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(432, 156)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 16)
        Me.Label3.TabIndex = 235
        Me.Label3.Text = "Pembulatan"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(327, 156)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 16)
        Me.Label4.TabIndex = 234
        Me.Label4.Text = "Total Nett"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(117, 156)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(79, 16)
        Me.Label24.TabIndex = 233
        Me.Label24.Text = "Total Diskon"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 156)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 16)
        Me.Label7.TabIndex = 230
        Me.Label7.Text = "Total Biaya"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(12, 53)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(129, 15)
        Me.Label17.TabIndex = 132
        Me.Label17.Text = "Hasil diambil melalui :"
        '
        'TextBoxTotalBayar
        '
        Me.TextBoxTotalBayar.Enabled = False
        Me.TextBoxTotalBayar.Location = New System.Drawing.Point(225, 175)
        Me.TextBoxTotalBayar.Name = "TextBoxTotalBayar"
        Me.TextBoxTotalBayar.Properties.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxTotalBayar.Properties.Appearance.Options.UseFont = True
        Me.TextBoxTotalBayar.Size = New System.Drawing.Size(100, 21)
        Me.TextBoxTotalBayar.TabIndex = 120
        '
        'TextBoxTotalPembulatan
        '
        Me.TextBoxTotalPembulatan.Enabled = False
        Me.TextBoxTotalPembulatan.Location = New System.Drawing.Point(435, 175)
        Me.TextBoxTotalPembulatan.Name = "TextBoxTotalPembulatan"
        Me.TextBoxTotalPembulatan.Properties.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxTotalPembulatan.Properties.Appearance.Options.UseFont = True
        Me.TextBoxTotalPembulatan.Size = New System.Drawing.Size(100, 21)
        Me.TextBoxTotalPembulatan.TabIndex = 118
        '
        'TextBoxTotalBruto
        '
        Me.TextBoxTotalBruto.Enabled = False
        Me.TextBoxTotalBruto.Location = New System.Drawing.Point(15, 175)
        Me.TextBoxTotalBruto.Name = "TextBoxTotalBruto"
        Me.TextBoxTotalBruto.Properties.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxTotalBruto.Properties.Appearance.Options.UseFont = True
        Me.TextBoxTotalBruto.Size = New System.Drawing.Size(100, 21)
        Me.TextBoxTotalBruto.TabIndex = 116
        '
        'TextBoxTotalDiskon
        '
        Me.TextBoxTotalDiskon.Enabled = False
        Me.TextBoxTotalDiskon.Location = New System.Drawing.Point(120, 175)
        Me.TextBoxTotalDiskon.Name = "TextBoxTotalDiskon"
        Me.TextBoxTotalDiskon.Properties.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxTotalDiskon.Properties.Appearance.Options.UseFont = True
        Me.TextBoxTotalDiskon.Size = New System.Drawing.Size(100, 21)
        Me.TextBoxTotalDiskon.TabIndex = 114
        '
        'TextBoxTotalNett
        '
        Me.TextBoxTotalNett.Enabled = False
        Me.TextBoxTotalNett.Location = New System.Drawing.Point(330, 175)
        Me.TextBoxTotalNett.Name = "TextBoxTotalNett"
        Me.TextBoxTotalNett.Properties.Appearance.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxTotalNett.Properties.Appearance.Options.UseFont = True
        Me.TextBoxTotalNett.Size = New System.Drawing.Size(100, 21)
        Me.TextBoxTotalNett.TabIndex = 111
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.gridtindakan)
        Me.GroupBox2.Controls.Add(Me.MenuStrip2)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 179)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(957, 187)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Detail"
        '
        'gridtindakan
        '
        Me.gridtindakan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridtindakan.EmbeddedNavigator.Name = ""
        GridLevelNode1.RelationName = "Level1"
        Me.gridtindakan.LevelTree.Nodes.AddRange(New DevExpress.XtraGrid.GridLevelNode() {GridLevelNode1})
        Me.gridtindakan.Location = New System.Drawing.Point(3, 40)
        Me.gridtindakan.MainView = Me.GridView1
        Me.gridtindakan.Name = "gridtindakan"
        Me.gridtindakan.Size = New System.Drawing.Size(951, 144)
        Me.gridtindakan.TabIndex = 3
        Me.gridtindakan.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.gridtindakan
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        Me.GridView1.OptionsView.ShowIndicator = False
        Me.GridView1.PaintStyleName = "Skin"
        '
        'MenuStrip2
        '
        Me.MenuStrip2.AllowMerge = False
        Me.MenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TambahTindakanToolStripMenuItem, Me.TambahPaketToolStripMenuItem, Me.KalkulasiToolStripMenuItem})
        Me.MenuStrip2.Location = New System.Drawing.Point(3, 16)
        Me.MenuStrip2.Name = "MenuStrip2"
        Me.MenuStrip2.Size = New System.Drawing.Size(951, 24)
        Me.MenuStrip2.TabIndex = 4
        Me.MenuStrip2.Text = "MenuStrip2"
        '
        'TambahTindakanToolStripMenuItem
        '
        Me.TambahTindakanToolStripMenuItem.Name = "TambahTindakanToolStripMenuItem"
        Me.TambahTindakanToolStripMenuItem.Size = New System.Drawing.Size(112, 20)
        Me.TambahTindakanToolStripMenuItem.Text = "Tambah Tindakan"
        '
        'TambahPaketToolStripMenuItem
        '
        Me.TambahPaketToolStripMenuItem.Name = "TambahPaketToolStripMenuItem"
        Me.TambahPaketToolStripMenuItem.Size = New System.Drawing.Size(93, 20)
        Me.TambahPaketToolStripMenuItem.Text = "Tambah Paket"
        '
        'KalkulasiToolStripMenuItem
        '
        Me.KalkulasiToolStripMenuItem.Name = "KalkulasiToolStripMenuItem"
        Me.KalkulasiToolStripMenuItem.Size = New System.Drawing.Size(65, 20)
        Me.KalkulasiToolStripMenuItem.Text = "Kalkulasi"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem1, Me.TambahDokterPengirimToolStripMenuItem, Me.UpdateMasterPerusahaanToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(957, 24)
        Me.MenuStrip1.TabIndex = 8
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'NewToolStripMenuItem1
        '
        Me.NewToolStripMenuItem1.Name = "NewToolStripMenuItem1"
        Me.NewToolStripMenuItem1.Size = New System.Drawing.Size(138, 20)
        Me.NewToolStripMenuItem1.Text = "Tambah Transaksi Baru"
        '
        'TambahDokterPengirimToolStripMenuItem
        '
        Me.TambahDokterPengirimToolStripMenuItem.Name = "TambahDokterPengirimToolStripMenuItem"
        Me.TambahDokterPengirimToolStripMenuItem.Size = New System.Drawing.Size(150, 20)
        Me.TambahDokterPengirimToolStripMenuItem.Text = "Tambah Dokter Pengirim"
        '
        'UpdateMasterPerusahaanToolStripMenuItem
        '
        Me.UpdateMasterPerusahaanToolStripMenuItem.Name = "UpdateMasterPerusahaanToolStripMenuItem"
        Me.UpdateMasterPerusahaanToolStripMenuItem.Size = New System.Drawing.Size(160, 20)
        Me.UpdateMasterPerusahaanToolStripMenuItem.Text = "Update Master Perusahaan"
        '
        'CekTransaksiDone
        '
        Me.CekTransaksiDone.Enabled = True
        Me.CekTransaksiDone.Interval = 1000
        '
        'TransaksiLab
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(957, 581)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBoxDetailPasien)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "TransaksiLab"
        Me.Text = "Kasir Laboratorium"
        Me.GroupBoxDetailPasien.ResumeLayout(False)
        Me.GroupBoxDetailPasien.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.TextBoxTotalBayar.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxTotalPembulatan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxTotalBruto.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxTotalDiskon.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBoxTotalNett.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.gridtindakan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip2.ResumeLayout(False)
        Me.MenuStrip2.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBoxDetailPasien As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNamaPasien As System.Windows.Forms.TextBox
    Friend WithEvents dtcusttgllhr As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextBoxUmurPasien As System.Windows.Forms.TextBox
    Friend WithEvents dtnow As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents chkclosed As System.Windows.Forms.CheckBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TextBoxDokterID As System.Windows.Forms.TextBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents NewToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip2 As System.Windows.Forms.MenuStrip
    Friend WithEvents TambahTindakanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TambahPaketToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TambahDokterPengirimToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents KalkulasiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents TextBoxTotalNett As DevExpress.XtraEditors.TextEdit
    Private WithEvents TextBoxTotalDiskon As DevExpress.XtraEditors.TextEdit
    Private WithEvents TextBoxTotalBruto As DevExpress.XtraEditors.TextEdit
    Private WithEvents TextBoxTotalPembulatan As DevExpress.XtraEditors.TextEdit
    Private WithEvents gridtindakan As DevExpress.XtraGrid.GridControl
    Private WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Private WithEvents TextBoxTotalBayar As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextBoxNamaDokter As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents butsaved As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Public WithEvents rdsoftcopy1 As System.Windows.Forms.RadioButton
    Public WithEvents txhardcopykirim As System.Windows.Forms.TextBox
    Public WithEvents rdhardcopy2 As System.Windows.Forms.RadioButton
    Public WithEvents rdhardcopy3 As System.Windows.Forms.RadioButton
    Public WithEvents rdhardcopy1 As System.Windows.Forms.RadioButton
    Public WithEvents txsoftcopyemail As System.Windows.Forms.TextBox
    Public WithEvents rdsoftcopy3 As System.Windows.Forms.RadioButton
    Public WithEvents TextBoxSoftCopyWhatsapp As System.Windows.Forms.TextBox
    Public WithEvents RadioButtonSoftCopyWhatsapp As System.Windows.Forms.RadioButton
    Public WithEvents TextBoxNoUrutTransaksi As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Public WithEvents rdreferensiperusahaan1 As System.Windows.Forms.RadioButton
    Public WithEvents rdreferensiperusahaan2 As System.Windows.Forms.RadioButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents txnamareferensiperusahaan As System.Windows.Forms.TextBox
    Public WithEvents txidreferensiperusahaan As System.Windows.Forms.TextBox
    Friend WithEvents txwarningperusahaan As System.Windows.Forms.Label
    Friend WithEvents CekTransaksiDone As System.Windows.Forms.Timer
    Friend WithEvents UpdateMasterPerusahaanToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Public WithEvents txjenisbayar_ As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Public WithEvents txkartu_ As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNoRekamMedis As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ButtonFindTransaksi As System.Windows.Forms.Button
    Friend WithEvents ButtonFindDokter As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents CheckBoxNomorWhatsapp As System.Windows.Forms.CheckBox
End Class
