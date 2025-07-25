<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogBoxKonfirmasiPendaftaran
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DialogBoxKonfirmasiPendaftaran))
        Me.PanelTop = New System.Windows.Forms.Panel
        Me.ButtonClose = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.SplitContainerInformedConcent = New System.Windows.Forms.SplitContainer
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.ComboBoxPilihanDokter = New System.Windows.Forms.ComboBox
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.RadioButtonStatusRawatJalan = New System.Windows.Forms.RadioButton
        Me.RadioButtonPromotifPreventif = New System.Windows.Forms.RadioButton
        Me.RadioButtonStatusRawatInap = New System.Windows.Forms.RadioButton
        Me.Label9 = New System.Windows.Forms.Label
        Me.TextBoxPoliKeluhanTambahan = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.ComboBoxPilihanPerawat = New System.Windows.Forms.ComboBox
        Me.TextBoxPoliKeluhanUtama = New System.Windows.Forms.TextBox
        Me.TextBoxPoliTujuan = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TextBoxJenisKelamin = New System.Windows.Forms.TextBox
        Me.TextBoxNamaFaskes = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TextBoxNomorNIK = New System.Windows.Forms.TextBox
        Me.Label41 = New System.Windows.Forms.Label
        Me.Label40 = New System.Windows.Forms.Label
        Me.TextBoxNomorKIS = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBoxNoHPIdentitas = New System.Windows.Forms.TextBox
        Me.Label36 = New System.Windows.Forms.Label
        Me.DateTimePickerTglLahir = New System.Windows.Forms.DateTimePicker
        Me.TextBoxNoRekamMedis = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.TextBoxAlamatDomisili = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TextBoxNamaPasien = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ButtonPasienBatal = New System.Windows.Forms.Button
        Me.ButtonPasienTidakHadir = New System.Windows.Forms.Button
        Me.ButtonSubmitPendaftaran = New System.Windows.Forms.Button
        Me.PanelTop.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SplitContainerInformedConcent.Panel1.SuspendLayout()
        Me.SplitContainerInformedConcent.Panel2.SuspendLayout()
        Me.SplitContainerInformedConcent.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.PanelTop.Controls.Add(Me.ButtonClose)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(838, 35)
        Me.PanelTop.TabIndex = 5
        '
        'ButtonClose
        '
        Me.ButtonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.ButtonClose.FlatAppearance.BorderSize = 0
        Me.ButtonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonClose.Image = CType(resources.GetObject("ButtonClose.Image"), System.Drawing.Image)
        Me.ButtonClose.Location = New System.Drawing.Point(798, 0)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(40, 35)
        Me.ButtonClose.TabIndex = 282
        Me.ButtonClose.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.SplitContainerInformedConcent)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 35)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(838, 413)
        Me.Panel1.TabIndex = 6
        '
        'SplitContainerInformedConcent
        '
        Me.SplitContainerInformedConcent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerInformedConcent.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainerInformedConcent.IsSplitterFixed = True
        Me.SplitContainerInformedConcent.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerInformedConcent.Name = "SplitContainerInformedConcent"
        Me.SplitContainerInformedConcent.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerInformedConcent.Panel1
        '
        Me.SplitContainerInformedConcent.Panel1.AutoScroll = True
        Me.SplitContainerInformedConcent.Panel1.Controls.Add(Me.GroupBox3)
        Me.SplitContainerInformedConcent.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainerInformedConcent.Panel2
        '
        Me.SplitContainerInformedConcent.Panel2.AutoScroll = True
        Me.SplitContainerInformedConcent.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.SplitContainerInformedConcent.Panel2.Controls.Add(Me.ButtonPasienBatal)
        Me.SplitContainerInformedConcent.Panel2.Controls.Add(Me.ButtonPasienTidakHadir)
        Me.SplitContainerInformedConcent.Panel2.Controls.Add(Me.ButtonSubmitPendaftaran)
        Me.SplitContainerInformedConcent.Size = New System.Drawing.Size(838, 413)
        Me.SplitContainerInformedConcent.SplitterDistance = 350
        Me.SplitContainerInformedConcent.SplitterWidth = 5
        Me.SplitContainerInformedConcent.TabIndex = 500
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.ComboBoxPilihanDokter)
        Me.GroupBox3.Controls.Add(Me.Panel6)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.TextBoxPoliKeluhanTambahan)
        Me.GroupBox3.Controls.Add(Me.Label26)
        Me.GroupBox3.Controls.Add(Me.Label27)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.ComboBoxPilihanPerawat)
        Me.GroupBox3.Controls.Add(Me.TextBoxPoliKeluhanUtama)
        Me.GroupBox3.Controls.Add(Me.TextBoxPoliTujuan)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox3.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(10, 222)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(800, 160)
        Me.GroupBox3.TabIndex = 451
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Detail Transaksi"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(274, 30)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(75, 17)
        Me.Label10.TabIndex = 533
        Me.Label10.Text = "Dokter Poli"
        '
        'ComboBoxPilihanDokter
        '
        Me.ComboBoxPilihanDokter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxPilihanDokter.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxPilihanDokter.FormattingEnabled = True
        Me.ComboBoxPilihanDokter.Items.AddRange(New Object() {"Poli Umum", "Poli Gigi", "Laboratorium"})
        Me.ComboBoxPilihanDokter.Location = New System.Drawing.Point(277, 50)
        Me.ComboBoxPilihanDokter.Name = "ComboBoxPilihanDokter"
        Me.ComboBoxPilihanDokter.Size = New System.Drawing.Size(250, 25)
        Me.ComboBoxPilihanDokter.TabIndex = 534
        '
        'Panel6
        '
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.RadioButtonStatusRawatJalan)
        Me.Panel6.Controls.Add(Me.RadioButtonPromotifPreventif)
        Me.Panel6.Controls.Add(Me.RadioButtonStatusRawatInap)
        Me.Panel6.Location = New System.Drawing.Point(18, 98)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(253, 50)
        Me.Panel6.TabIndex = 472
        '
        'RadioButtonStatusRawatJalan
        '
        Me.RadioButtonStatusRawatJalan.AutoSize = True
        Me.RadioButtonStatusRawatJalan.Checked = True
        Me.RadioButtonStatusRawatJalan.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonStatusRawatJalan.Location = New System.Drawing.Point(5, 3)
        Me.RadioButtonStatusRawatJalan.Name = "RadioButtonStatusRawatJalan"
        Me.RadioButtonStatusRawatJalan.Size = New System.Drawing.Size(94, 21)
        Me.RadioButtonStatusRawatJalan.TabIndex = 226
        Me.RadioButtonStatusRawatJalan.TabStop = True
        Me.RadioButtonStatusRawatJalan.Tag = "10"
        Me.RadioButtonStatusRawatJalan.Text = "Rawat Jalan"
        Me.RadioButtonStatusRawatJalan.UseVisualStyleBackColor = True
        '
        'RadioButtonPromotifPreventif
        '
        Me.RadioButtonPromotifPreventif.AutoSize = True
        Me.RadioButtonPromotifPreventif.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonPromotifPreventif.Location = New System.Drawing.Point(105, 3)
        Me.RadioButtonPromotifPreventif.Name = "RadioButtonPromotifPreventif"
        Me.RadioButtonPromotifPreventif.Size = New System.Drawing.Size(130, 21)
        Me.RadioButtonPromotifPreventif.TabIndex = 224
        Me.RadioButtonPromotifPreventif.Tag = "50"
        Me.RadioButtonPromotifPreventif.Text = "Promotif Preventif"
        Me.RadioButtonPromotifPreventif.UseVisualStyleBackColor = True
        '
        'RadioButtonStatusRawatInap
        '
        Me.RadioButtonStatusRawatInap.AutoSize = True
        Me.RadioButtonStatusRawatInap.Enabled = False
        Me.RadioButtonStatusRawatInap.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonStatusRawatInap.Location = New System.Drawing.Point(5, 26)
        Me.RadioButtonStatusRawatInap.Name = "RadioButtonStatusRawatInap"
        Me.RadioButtonStatusRawatInap.Size = New System.Drawing.Size(90, 21)
        Me.RadioButtonStatusRawatInap.TabIndex = 225
        Me.RadioButtonStatusRawatInap.Tag = "20"
        Me.RadioButtonStatusRawatInap.Text = "Rawat Inap"
        Me.RadioButtonStatusRawatInap.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(15, 78)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 17)
        Me.Label9.TabIndex = 532
        Me.Label9.Text = "Jenis Rawat"
        '
        'TextBoxPoliKeluhanTambahan
        '
        Me.TextBoxPoliKeluhanTambahan.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxPoliKeluhanTambahan.Location = New System.Drawing.Point(533, 98)
        Me.TextBoxPoliKeluhanTambahan.Multiline = True
        Me.TextBoxPoliKeluhanTambahan.Name = "TextBoxPoliKeluhanTambahan"
        Me.TextBoxPoliKeluhanTambahan.Size = New System.Drawing.Size(250, 50)
        Me.TextBoxPoliKeluhanTambahan.TabIndex = 472
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label26.Location = New System.Drawing.Point(530, 78)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(124, 17)
        Me.Label26.TabIndex = 471
        Me.Label26.Text = "Keluhan Tambahan"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label27.Location = New System.Drawing.Point(274, 78)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(101, 17)
        Me.Label27.TabIndex = 469
        Me.Label27.Text = "Keluhan Utama"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(530, 30)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 17)
        Me.Label8.TabIndex = 530
        Me.Label8.Text = "Perawat Poli"
        '
        'ComboBoxPilihanPerawat
        '
        Me.ComboBoxPilihanPerawat.BackColor = System.Drawing.Color.White
        Me.ComboBoxPilihanPerawat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxPilihanPerawat.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.ComboBoxPilihanPerawat.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBoxPilihanPerawat.IntegralHeight = False
        Me.ComboBoxPilihanPerawat.Items.AddRange(New Object() {"Dokter Umum", "Dokter Gigi", "Laboratorium"})
        Me.ComboBoxPilihanPerawat.Location = New System.Drawing.Point(533, 50)
        Me.ComboBoxPilihanPerawat.Name = "ComboBoxPilihanPerawat"
        Me.ComboBoxPilihanPerawat.Size = New System.Drawing.Size(250, 25)
        Me.ComboBoxPilihanPerawat.TabIndex = 531
        '
        'TextBoxPoliKeluhanUtama
        '
        Me.TextBoxPoliKeluhanUtama.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxPoliKeluhanUtama.Location = New System.Drawing.Point(277, 98)
        Me.TextBoxPoliKeluhanUtama.Multiline = True
        Me.TextBoxPoliKeluhanUtama.Name = "TextBoxPoliKeluhanUtama"
        Me.TextBoxPoliKeluhanUtama.Size = New System.Drawing.Size(250, 50)
        Me.TextBoxPoliKeluhanUtama.TabIndex = 470
        '
        'TextBoxPoliTujuan
        '
        Me.TextBoxPoliTujuan.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.TextBoxPoliTujuan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxPoliTujuan.Cursor = System.Windows.Forms.Cursors.No
        Me.TextBoxPoliTujuan.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxPoliTujuan.Location = New System.Drawing.Point(18, 50)
        Me.TextBoxPoliTujuan.Name = "TextBoxPoliTujuan"
        Me.TextBoxPoliTujuan.ReadOnly = True
        Me.TextBoxPoliTujuan.Size = New System.Drawing.Size(253, 25)
        Me.TextBoxPoliTujuan.TabIndex = 527
        Me.TextBoxPoliTujuan.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(15, 30)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(74, 17)
        Me.Label6.TabIndex = 526
        Me.Label6.Text = "Poli Tujuan"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBoxJenisKelamin)
        Me.GroupBox1.Controls.Add(Me.TextBoxNamaFaskes)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.TextBoxNomorNIK)
        Me.GroupBox1.Controls.Add(Me.Label41)
        Me.GroupBox1.Controls.Add(Me.Label40)
        Me.GroupBox1.Controls.Add(Me.TextBoxNomorKIS)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TextBoxNoHPIdentitas)
        Me.GroupBox1.Controls.Add(Me.Label36)
        Me.GroupBox1.Controls.Add(Me.DateTimePickerTglLahir)
        Me.GroupBox1.Controls.Add(Me.TextBoxNoRekamMedis)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.TextBoxAlamatDomisili)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TextBoxNamaPasien)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(10, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(800, 206)
        Me.GroupBox1.TabIndex = 450
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Data Pasien"
        '
        'TextBoxJenisKelamin
        '
        Me.TextBoxJenisKelamin.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.TextBoxJenisKelamin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxJenisKelamin.Cursor = System.Windows.Forms.Cursors.No
        Me.TextBoxJenisKelamin.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxJenisKelamin.Location = New System.Drawing.Point(530, 98)
        Me.TextBoxJenisKelamin.Name = "TextBoxJenisKelamin"
        Me.TextBoxJenisKelamin.ReadOnly = True
        Me.TextBoxJenisKelamin.Size = New System.Drawing.Size(110, 25)
        Me.TextBoxJenisKelamin.TabIndex = 471
        Me.TextBoxJenisKelamin.TabStop = False
        '
        'TextBoxNamaFaskes
        '
        Me.TextBoxNamaFaskes.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.TextBoxNamaFaskes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxNamaFaskes.Cursor = System.Windows.Forms.Cursors.No
        Me.TextBoxNamaFaskes.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxNamaFaskes.Location = New System.Drawing.Point(530, 49)
        Me.TextBoxNamaFaskes.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxNamaFaskes.Name = "TextBoxNamaFaskes"
        Me.TextBoxNamaFaskes.ReadOnly = True
        Me.TextBoxNamaFaskes.Size = New System.Drawing.Size(253, 25)
        Me.TextBoxNamaFaskes.TabIndex = 468
        Me.TextBoxNamaFaskes.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(527, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 17)
        Me.Label4.TabIndex = 467
        Me.Label4.Text = "Faskes"
        '
        'TextBoxNomorNIK
        '
        Me.TextBoxNomorNIK.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.TextBoxNomorNIK.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxNomorNIK.Cursor = System.Windows.Forms.Cursors.No
        Me.TextBoxNomorNIK.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxNomorNIK.Location = New System.Drawing.Point(199, 50)
        Me.TextBoxNomorNIK.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxNomorNIK.MaxLength = 16
        Me.TextBoxNomorNIK.Name = "TextBoxNomorNIK"
        Me.TextBoxNomorNIK.ReadOnly = True
        Me.TextBoxNomorNIK.Size = New System.Drawing.Size(169, 25)
        Me.TextBoxNomorNIK.TabIndex = 466
        Me.TextBoxNomorNIK.TabStop = False
        Me.TextBoxNomorNIK.Tag = ""
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(196, 29)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(40, 17)
        Me.Label41.TabIndex = 465
        Me.Label41.Text = "NIK *"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(371, 29)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(102, 17)
        Me.Label40.TabIndex = 463
        Me.Label40.Text = "Nomor JKN-KIS"
        '
        'TextBoxNomorKIS
        '
        Me.TextBoxNomorKIS.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.TextBoxNomorKIS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxNomorKIS.Cursor = System.Windows.Forms.Cursors.No
        Me.TextBoxNomorKIS.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxNomorKIS.Location = New System.Drawing.Point(374, 50)
        Me.TextBoxNomorKIS.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxNomorKIS.MaxLength = 13
        Me.TextBoxNomorKIS.Name = "TextBoxNomorKIS"
        Me.TextBoxNomorKIS.ReadOnly = True
        Me.TextBoxNomorKIS.Size = New System.Drawing.Size(150, 25)
        Me.TextBoxNomorKIS.TabIndex = 464
        Me.TextBoxNomorKIS.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(643, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(137, 17)
        Me.Label2.TabIndex = 461
        Me.Label2.Text = "No. HP (WhatsApp) *"
        '
        'TextBoxNoHPIdentitas
        '
        Me.TextBoxNoHPIdentitas.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxNoHPIdentitas.Location = New System.Drawing.Point(646, 98)
        Me.TextBoxNoHPIdentitas.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TextBoxNoHPIdentitas.Name = "TextBoxNoHPIdentitas"
        Me.TextBoxNoHPIdentitas.Size = New System.Drawing.Size(137, 25)
        Me.TextBoxNoHPIdentitas.TabIndex = 462
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(372, 77)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(98, 17)
        Me.Label36.TabIndex = 459
        Me.Label36.Text = "Tanggal Lahir *"
        '
        'DateTimePickerTglLahir
        '
        Me.DateTimePickerTglLahir.CustomFormat = "dd-MMM-yyyy"
        Me.DateTimePickerTglLahir.Enabled = False
        Me.DateTimePickerTglLahir.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.DateTimePickerTglLahir.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerTglLahir.Location = New System.Drawing.Point(374, 98)
        Me.DateTimePickerTglLahir.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DateTimePickerTglLahir.Name = "DateTimePickerTglLahir"
        Me.DateTimePickerTglLahir.Size = New System.Drawing.Size(150, 25)
        Me.DateTimePickerTglLahir.TabIndex = 460
        '
        'TextBoxNoRekamMedis
        '
        Me.TextBoxNoRekamMedis.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.TextBoxNoRekamMedis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxNoRekamMedis.Cursor = System.Windows.Forms.Cursors.No
        Me.TextBoxNoRekamMedis.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxNoRekamMedis.Location = New System.Drawing.Point(18, 50)
        Me.TextBoxNoRekamMedis.Name = "TextBoxNoRekamMedis"
        Me.TextBoxNoRekamMedis.ReadOnly = True
        Me.TextBoxNoRekamMedis.Size = New System.Drawing.Size(175, 25)
        Me.TextBoxNoRekamMedis.TabIndex = 456
        Me.TextBoxNoRekamMedis.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(530, 78)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 17)
        Me.Label3.TabIndex = 449
        Me.Label3.Text = "Jenis Kelamin *"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label17.Location = New System.Drawing.Point(15, 30)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(111, 17)
        Me.Label17.TabIndex = 455
        Me.Label17.Text = "No Rekam Medis"
        '
        'TextBoxAlamatDomisili
        '
        Me.TextBoxAlamatDomisili.BackColor = System.Drawing.Color.White
        Me.TextBoxAlamatDomisili.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxAlamatDomisili.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxAlamatDomisili.Location = New System.Drawing.Point(18, 146)
        Me.TextBoxAlamatDomisili.Multiline = True
        Me.TextBoxAlamatDomisili.Name = "TextBoxAlamatDomisili"
        Me.TextBoxAlamatDomisili.Size = New System.Drawing.Size(350, 50)
        Me.TextBoxAlamatDomisili.TabIndex = 450
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(15, 126)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(102, 17)
        Me.Label5.TabIndex = 453
        Me.Label5.Text = "Alamat Domisili"
        '
        'TextBoxNamaPasien
        '
        Me.TextBoxNamaPasien.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.TextBoxNamaPasien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxNamaPasien.Cursor = System.Windows.Forms.Cursors.No
        Me.TextBoxNamaPasien.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxNamaPasien.Location = New System.Drawing.Point(18, 98)
        Me.TextBoxNamaPasien.Name = "TextBoxNamaPasien"
        Me.TextBoxNamaPasien.ReadOnly = True
        Me.TextBoxNamaPasien.Size = New System.Drawing.Size(350, 25)
        Me.TextBoxNamaPasien.TabIndex = 446
        Me.TextBoxNamaPasien.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(15, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 17)
        Me.Label1.TabIndex = 441
        Me.Label1.Text = "Nama Lengkap *"
        '
        'ButtonPasienBatal
        '
        Me.ButtonPasienBatal.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonPasienBatal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonPasienBatal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonPasienBatal.Dock = System.Windows.Forms.DockStyle.Right
        Me.ButtonPasienBatal.FlatAppearance.BorderSize = 0
        Me.ButtonPasienBatal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonPasienBatal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonPasienBatal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonPasienBatal.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonPasienBatal.ForeColor = System.Drawing.Color.White
        Me.ButtonPasienBatal.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_cancel_24
        Me.ButtonPasienBatal.Location = New System.Drawing.Point(288, 0)
        Me.ButtonPasienBatal.Name = "ButtonPasienBatal"
        Me.ButtonPasienBatal.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.ButtonPasienBatal.Size = New System.Drawing.Size(150, 58)
        Me.ButtonPasienBatal.TabIndex = 7
        Me.ButtonPasienBatal.Text = "  Pasien Batal"
        Me.ButtonPasienBatal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonPasienBatal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonPasienBatal.UseVisualStyleBackColor = False
        '
        'ButtonPasienTidakHadir
        '
        Me.ButtonPasienTidakHadir.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonPasienTidakHadir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonPasienTidakHadir.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonPasienTidakHadir.Dock = System.Windows.Forms.DockStyle.Right
        Me.ButtonPasienTidakHadir.FlatAppearance.BorderSize = 0
        Me.ButtonPasienTidakHadir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonPasienTidakHadir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonPasienTidakHadir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonPasienTidakHadir.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonPasienTidakHadir.ForeColor = System.Drawing.Color.White
        Me.ButtonPasienTidakHadir.Image = CType(resources.GetObject("ButtonPasienTidakHadir.Image"), System.Drawing.Image)
        Me.ButtonPasienTidakHadir.Location = New System.Drawing.Point(438, 0)
        Me.ButtonPasienTidakHadir.Name = "ButtonPasienTidakHadir"
        Me.ButtonPasienTidakHadir.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.ButtonPasienTidakHadir.Size = New System.Drawing.Size(175, 58)
        Me.ButtonPasienTidakHadir.TabIndex = 6
        Me.ButtonPasienTidakHadir.Text = "  Pasien Tidak Hadir"
        Me.ButtonPasienTidakHadir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonPasienTidakHadir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonPasienTidakHadir.UseVisualStyleBackColor = False
        '
        'ButtonSubmitPendaftaran
        '
        Me.ButtonSubmitPendaftaran.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSubmitPendaftaran.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonSubmitPendaftaran.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonSubmitPendaftaran.Dock = System.Windows.Forms.DockStyle.Right
        Me.ButtonSubmitPendaftaran.FlatAppearance.BorderSize = 0
        Me.ButtonSubmitPendaftaran.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSubmitPendaftaran.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonSubmitPendaftaran.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSubmitPendaftaran.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSubmitPendaftaran.ForeColor = System.Drawing.Color.White
        Me.ButtonSubmitPendaftaran.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_send_24
        Me.ButtonSubmitPendaftaran.Location = New System.Drawing.Point(613, 0)
        Me.ButtonSubmitPendaftaran.Name = "ButtonSubmitPendaftaran"
        Me.ButtonSubmitPendaftaran.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.ButtonSubmitPendaftaran.Size = New System.Drawing.Size(225, 58)
        Me.ButtonSubmitPendaftaran.TabIndex = 5
        Me.ButtonSubmitPendaftaran.Text = "  Submit Data Pendaftaran"
        Me.ButtonSubmitPendaftaran.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonSubmitPendaftaran.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonSubmitPendaftaran.UseVisualStyleBackColor = False
        '
        'DialogBoxKonfirmasiPendaftaran
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(838, 448)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PanelTop)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DialogBoxKonfirmasiPendaftaran"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.PanelTop.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.SplitContainerInformedConcent.Panel1.ResumeLayout(False)
        Me.SplitContainerInformedConcent.Panel2.ResumeLayout(False)
        Me.SplitContainerInformedConcent.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents SplitContainerInformedConcent As System.Windows.Forms.SplitContainer
    Friend WithEvents ButtonSubmitPendaftaran As System.Windows.Forms.Button
    Friend WithEvents ButtonPasienTidakHadir As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBoxNamaPasien As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TextBoxAlamatDomisili As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNoRekamMedis As System.Windows.Forms.TextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerTglLahir As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNoHPIdentitas As System.Windows.Forms.TextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNomorKIS As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxNomorNIK As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents TextBoxNamaFaskes As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBoxPoliTujuan As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxPilihanPerawat As System.Windows.Forms.ComboBox
    Friend WithEvents TextBoxPoliKeluhanTambahan As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents TextBoxPoliKeluhanUtama As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxJenisKelamin As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents RadioButtonStatusRawatJalan As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonPromotifPreventif As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonStatusRawatInap As System.Windows.Forms.RadioButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxPilihanDokter As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonPasienBatal As System.Windows.Forms.Button
    Friend WithEvents ButtonClose As System.Windows.Forms.Button
End Class
