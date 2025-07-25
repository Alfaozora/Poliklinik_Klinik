<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UploadTindakanLaboratorium
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UploadTindakanLaboratorium))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.gridlab = New DevExpress.XtraGrid.GridControl
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.gridexcel = New DevExpress.XtraGrid.GridControl
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.GroupBoxDL = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbstatustransaksi = New System.Windows.Forms.ComboBox
        Me.butdownloadtransthorax = New System.Windows.Forms.Button
        Me.txkodecabang = New System.Windows.Forms.TextBox
        Me.dtprocessend = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.butfindcompany = New System.Windows.Forms.Button
        Me.txcompanycode = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.dtprocess = New System.Windows.Forms.DateTimePicker
        Me.txidloc = New System.Windows.Forms.TextBox
        Me.txloc = New System.Windows.Forms.TextBox
        Me.butfindloc = New System.Windows.Forms.Button
        Me.NamaLokasi = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.rdOnline = New System.Windows.Forms.RadioButton
        Me.rdOffline = New System.Windows.Forms.RadioButton
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.butsavemultiple = New System.Windows.Forms.Button
        Me.butsavelab = New System.Windows.Forms.Button
        Me.buttambahpasien = New System.Windows.Forms.Button
        Me.PanelKeadaanUmumMenuPemeriksaanAwal = New System.Windows.Forms.Panel
        Me.RadioButtonKesimpulanYa = New System.Windows.Forms.RadioButton
        Me.RadioButtonKesimpulanTidak = New System.Windows.Forms.RadioButton
        Me.Label15 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.GroupBox1.SuspendLayout()
        CType(Me.gridlab, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.gridexcel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxDL.SuspendLayout()
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.gridlab)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 217)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1101, 323)
        Me.GroupBox1.TabIndex = 181
        Me.GroupBox1.TabStop = False
        '
        'gridlab
        '
        Me.gridlab.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gridlab.EmbeddedNavigator.Name = ""
        Me.gridlab.Location = New System.Drawing.Point(3, 16)
        Me.gridlab.MainView = Me.GridView1
        Me.gridlab.Name = "gridlab"
        Me.gridlab.Size = New System.Drawing.Size(1095, 304)
        Me.gridlab.TabIndex = 0
        Me.gridlab.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.GridControl = Me.gridlab
        Me.GridView1.Name = "GridView1"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Panel1)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1101, 217)
        Me.GroupBox2.TabIndex = 183
        Me.GroupBox2.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.PanelKeadaanUmumMenuPemeriksaanAwal)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.gridexcel)
        Me.Panel1.Controls.Add(Me.GroupBoxDL)
        Me.Panel1.Controls.Add(Me.txidloc)
        Me.Panel1.Controls.Add(Me.txloc)
        Me.Panel1.Controls.Add(Me.butfindloc)
        Me.Panel1.Controls.Add(Me.NamaLokasi)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.ProgressBar1)
        Me.Panel1.Controls.Add(Me.butsavemultiple)
        Me.Panel1.Controls.Add(Me.butsavelab)
        Me.Panel1.Controls.Add(Me.buttambahpasien)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 16)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1095, 198)
        Me.Panel1.TabIndex = 236
        '
        'gridexcel
        '
        Me.gridexcel.EmbeddedNavigator.Name = ""
        Me.gridexcel.Location = New System.Drawing.Point(1018, 80)
        Me.gridexcel.MainView = Me.GridView3
        Me.gridexcel.Name = "gridexcel"
        Me.gridexcel.Size = New System.Drawing.Size(100, 50)
        Me.gridexcel.TabIndex = 253
        Me.gridexcel.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
        Me.gridexcel.Visible = False
        '
        'GridView3
        '
        Me.GridView3.GridControl = Me.gridexcel
        Me.GridView3.Name = "GridView3"
        '
        'GroupBoxDL
        '
        Me.GroupBoxDL.Controls.Add(Me.Label4)
        Me.GroupBoxDL.Controls.Add(Me.cmbstatustransaksi)
        Me.GroupBoxDL.Controls.Add(Me.butdownloadtransthorax)
        Me.GroupBoxDL.Controls.Add(Me.txkodecabang)
        Me.GroupBoxDL.Controls.Add(Me.dtprocessend)
        Me.GroupBoxDL.Controls.Add(Me.Label2)
        Me.GroupBoxDL.Controls.Add(Me.Label9)
        Me.GroupBoxDL.Controls.Add(Me.butfindcompany)
        Me.GroupBoxDL.Controls.Add(Me.txcompanycode)
        Me.GroupBoxDL.Controls.Add(Me.Label16)
        Me.GroupBoxDL.Controls.Add(Me.dtprocess)
        Me.GroupBoxDL.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.GroupBoxDL.Location = New System.Drawing.Point(597, 17)
        Me.GroupBoxDL.Name = "GroupBoxDL"
        Me.GroupBoxDL.Size = New System.Drawing.Size(400, 124)
        Me.GroupBoxDL.TabIndex = 251
        Me.GroupBoxDL.TabStop = False
        Me.GroupBoxDL.Text = "Download Data Transaksi Laboratorium"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(50, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 17)
        Me.Label4.TabIndex = 246
        Me.Label4.Text = "Status"
        '
        'cmbstatustransaksi
        '
        Me.cmbstatustransaksi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbstatustransaksi.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbstatustransaksi.FormattingEnabled = True
        Me.cmbstatustransaksi.Items.AddRange(New Object() {"SEMUA", "SUDAH INPUT HASIL", "BELUM INPUT HASIL"})
        Me.cmbstatustransaksi.Location = New System.Drawing.Point(104, 82)
        Me.cmbstatustransaksi.Name = "cmbstatustransaksi"
        Me.cmbstatustransaksi.Size = New System.Drawing.Size(185, 23)
        Me.cmbstatustransaksi.TabIndex = 245
        '
        'butdownloadtransthorax
        '
        Me.butdownloadtransthorax.Cursor = System.Windows.Forms.Cursors.Hand
        Me.butdownloadtransthorax.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butdownloadtransthorax.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butdownloadtransthorax.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_kosong
        Me.butdownloadtransthorax.Location = New System.Drawing.Point(295, 79)
        Me.butdownloadtransthorax.Name = "butdownloadtransthorax"
        Me.butdownloadtransthorax.Size = New System.Drawing.Size(100, 36)
        Me.butdownloadtransthorax.TabIndex = 244
        Me.butdownloadtransthorax.Text = "DOWNLOAD"
        Me.butdownloadtransthorax.UseVisualStyleBackColor = True
        '
        'txkodecabang
        '
        Me.txkodecabang.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txkodecabang.Location = New System.Drawing.Point(104, 55)
        Me.txkodecabang.Name = "txkodecabang"
        Me.txkodecabang.Size = New System.Drawing.Size(100, 21)
        Me.txkodecabang.TabIndex = 236
        Me.txkodecabang.Visible = False
        '
        'dtprocessend
        '
        Me.dtprocessend.CustomFormat = "dd-MMM-yyyy"
        Me.dtprocessend.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtprocessend.Location = New System.Drawing.Point(265, 29)
        Me.dtprocessend.Name = "dtprocessend"
        Me.dtprocessend.Size = New System.Drawing.Size(130, 22)
        Me.dtprocessend.TabIndex = 243
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(237, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 16)
        Me.Label2.TabIndex = 242
        Me.Label2.Text = "s/d"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(7, 34)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 17)
        Me.Label9.TabIndex = 241
        Me.Label9.Text = "Tgl Transaksi"
        '
        'butfindcompany
        '
        Me.butfindcompany.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butfindcompany.Location = New System.Drawing.Point(364, 53)
        Me.butfindcompany.Name = "butfindcompany"
        Me.butfindcompany.Size = New System.Drawing.Size(31, 25)
        Me.butfindcompany.TabIndex = 240
        Me.butfindcompany.Text = "..."
        Me.butfindcompany.UseVisualStyleBackColor = True
        '
        'txcompanycode
        '
        Me.txcompanycode.BackColor = System.Drawing.SystemColors.Window
        Me.txcompanycode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txcompanycode.Location = New System.Drawing.Point(104, 55)
        Me.txcompanycode.Name = "txcompanycode"
        Me.txcompanycode.ReadOnly = True
        Me.txcompanycode.Size = New System.Drawing.Size(260, 21)
        Me.txcompanycode.TabIndex = 239
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label16.Location = New System.Drawing.Point(29, 60)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(66, 17)
        Me.Label16.TabIndex = 238
        Me.Label16.Text = "Company"
        '
        'dtprocess
        '
        Me.dtprocess.CustomFormat = "dd-MMM-yyyy"
        Me.dtprocess.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtprocess.Location = New System.Drawing.Point(104, 29)
        Me.dtprocess.Name = "dtprocess"
        Me.dtprocess.Size = New System.Drawing.Size(130, 22)
        Me.dtprocess.TabIndex = 237
        '
        'txidloc
        '
        Me.txidloc.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txidloc.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txidloc.Location = New System.Drawing.Point(398, 79)
        Me.txidloc.Name = "txidloc"
        Me.txidloc.ReadOnly = True
        Me.txidloc.Size = New System.Drawing.Size(60, 21)
        Me.txidloc.TabIndex = 248
        Me.txidloc.Visible = False
        '
        'txloc
        '
        Me.txloc.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txloc.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txloc.Location = New System.Drawing.Point(187, 79)
        Me.txloc.Name = "txloc"
        Me.txloc.ReadOnly = True
        Me.txloc.Size = New System.Drawing.Size(271, 21)
        Me.txloc.TabIndex = 247
        '
        'butfindloc
        '
        Me.butfindloc.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butfindloc.Location = New System.Drawing.Point(464, 77)
        Me.butfindloc.Name = "butfindloc"
        Me.butfindloc.Size = New System.Drawing.Size(35, 25)
        Me.butfindloc.TabIndex = 246
        Me.butfindloc.Text = "..."
        Me.butfindloc.UseVisualStyleBackColor = True
        '
        'NamaLokasi
        '
        Me.NamaLokasi.AutoSize = True
        Me.NamaLokasi.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.NamaLokasi.ForeColor = System.Drawing.SystemColors.ControlText
        Me.NamaLokasi.Location = New System.Drawing.Point(116, 80)
        Me.NamaLokasi.Name = "NamaLokasi"
        Me.NamaLokasi.Size = New System.Drawing.Size(45, 17)
        Me.NamaLokasi.TabIndex = 245
        Me.NamaLokasi.Text = "Lokasi"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label8.Location = New System.Drawing.Point(65, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 17)
        Me.Label8.TabIndex = 242
        Me.Label8.Text = "Jenis Transaksi"
        '
        'rdOnline
        '
        Me.rdOnline.AutoSize = True
        Me.rdOnline.Checked = True
        Me.rdOnline.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.rdOnline.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.rdOnline.Location = New System.Drawing.Point(5, 3)
        Me.rdOnline.Name = "rdOnline"
        Me.rdOnline.Size = New System.Drawing.Size(63, 21)
        Me.rdOnline.TabIndex = 244
        Me.rdOnline.TabStop = True
        Me.rdOnline.Text = "Online"
        Me.rdOnline.UseVisualStyleBackColor = True
        '
        'rdOffline
        '
        Me.rdOffline.AutoSize = True
        Me.rdOffline.Enabled = False
        Me.rdOffline.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.rdOffline.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.rdOffline.Location = New System.Drawing.Point(74, 3)
        Me.rdOffline.Name = "rdOffline"
        Me.rdOffline.Size = New System.Drawing.Size(64, 21)
        Me.rdOffline.TabIndex = 243
        Me.rdOffline.Text = "Offline"
        Me.rdOffline.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.BackColor = System.Drawing.Color.Lime
        Me.ProgressBar1.Location = New System.Drawing.Point(9, 172)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(574, 5)
        Me.ProgressBar1.TabIndex = 241
        '
        'butsavemultiple
        '
        Me.butsavemultiple.Cursor = System.Windows.Forms.Cursors.Hand
        Me.butsavemultiple.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butsavemultiple.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butsavemultiple.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_kosong
        Me.butsavemultiple.Location = New System.Drawing.Point(399, 106)
        Me.butsavemultiple.Name = "butsavemultiple"
        Me.butsavemultiple.Size = New System.Drawing.Size(100, 36)
        Me.butsavemultiple.TabIndex = 239
        Me.butsavemultiple.Text = "SAVE MULTIPLE"
        Me.butsavemultiple.UseVisualStyleBackColor = True
        '
        'butsavelab
        '
        Me.butsavelab.Cursor = System.Windows.Forms.Cursors.Hand
        Me.butsavelab.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butsavelab.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_save
        Me.butsavelab.Location = New System.Drawing.Point(293, 106)
        Me.butsavelab.Name = "butsavelab"
        Me.butsavelab.Size = New System.Drawing.Size(100, 36)
        Me.butsavelab.TabIndex = 192
        Me.butsavelab.UseVisualStyleBackColor = True
        '
        'buttambahpasien
        '
        Me.buttambahpasien.Cursor = System.Windows.Forms.Cursors.Hand
        Me.buttambahpasien.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.buttambahpasien.Image = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_add
        Me.buttambahpasien.Location = New System.Drawing.Point(187, 106)
        Me.buttambahpasien.Name = "buttambahpasien"
        Me.buttambahpasien.Size = New System.Drawing.Size(100, 36)
        Me.buttambahpasien.TabIndex = 234
        Me.buttambahpasien.UseVisualStyleBackColor = True
        '
        'PanelKeadaanUmumMenuPemeriksaanAwal
        '
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.BackColor = System.Drawing.Color.Transparent
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.Controls.Add(Me.RadioButtonKesimpulanYa)
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.Controls.Add(Me.RadioButtonKesimpulanTidak)
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.Location = New System.Drawing.Point(187, 48)
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.Name = "PanelKeadaanUmumMenuPemeriksaanAwal"
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.Size = New System.Drawing.Size(236, 25)
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.TabIndex = 440
        '
        'RadioButtonKesimpulanYa
        '
        Me.RadioButtonKesimpulanYa.AutoSize = True
        Me.RadioButtonKesimpulanYa.Checked = True
        Me.RadioButtonKesimpulanYa.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonKesimpulanYa.Location = New System.Drawing.Point(5, 3)
        Me.RadioButtonKesimpulanYa.Name = "RadioButtonKesimpulanYa"
        Me.RadioButtonKesimpulanYa.Size = New System.Drawing.Size(39, 21)
        Me.RadioButtonKesimpulanYa.TabIndex = 245
        Me.RadioButtonKesimpulanYa.TabStop = True
        Me.RadioButtonKesimpulanYa.Text = "Ya"
        Me.RadioButtonKesimpulanYa.UseVisualStyleBackColor = True
        '
        'RadioButtonKesimpulanTidak
        '
        Me.RadioButtonKesimpulanTidak.AutoSize = True
        Me.RadioButtonKesimpulanTidak.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonKesimpulanTidak.Location = New System.Drawing.Point(50, 3)
        Me.RadioButtonKesimpulanTidak.Name = "RadioButtonKesimpulanTidak"
        Me.RadioButtonKesimpulanTidak.Size = New System.Drawing.Size(57, 21)
        Me.RadioButtonKesimpulanTidak.TabIndex = 246
        Me.RadioButtonKesimpulanTidak.Text = "Tidak"
        Me.RadioButtonKesimpulanTidak.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label15.Location = New System.Drawing.Point(13, 53)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(148, 17)
        Me.Label15.TabIndex = 439
        Me.Label15.Text = "Set Kesimpulan / Saran"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.rdOnline)
        Me.Panel2.Controls.Add(Me.rdOffline)
        Me.Panel2.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Panel2.Location = New System.Drawing.Point(187, 17)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(236, 25)
        Me.Panel2.TabIndex = 441
        '
        'UploadTindakanLaboratorium
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1101, 540)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1216, 579)
        Me.MinimumSize = New System.Drawing.Size(1098, 558)
        Me.Name = "UploadTindakanLaboratorium"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Upload Tindakan Laboratorium"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.gridlab, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.gridexcel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxDL.ResumeLayout(False)
        Me.GroupBoxDL.PerformLayout()
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.ResumeLayout(False)
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents gridlab As DevExpress.XtraGrid.GridControl
    Private WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents butsavelab As System.Windows.Forms.Button
    Friend WithEvents buttambahpasien As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents butsavemultiple As System.Windows.Forms.Button
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents rdOnline As System.Windows.Forms.RadioButton
    Friend WithEvents rdOffline As System.Windows.Forms.RadioButton
    Friend WithEvents txloc As System.Windows.Forms.TextBox
    Friend WithEvents butfindloc As System.Windows.Forms.Button
    Friend WithEvents NamaLokasi As System.Windows.Forms.Label
    Friend WithEvents txidloc As System.Windows.Forms.TextBox
    Friend WithEvents GroupBoxDL As System.Windows.Forms.GroupBox
    Friend WithEvents txkodecabang As System.Windows.Forms.TextBox
    Friend WithEvents dtprocessend As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents butfindcompany As System.Windows.Forms.Button
    Friend WithEvents txcompanycode As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents dtprocess As System.Windows.Forms.DateTimePicker
    Friend WithEvents butdownloadtransthorax As System.Windows.Forms.Button
    Friend WithEvents gridexcel As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cmbstatustransaksi As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PanelKeadaanUmumMenuPemeriksaanAwal As System.Windows.Forms.Panel
    Friend WithEvents RadioButtonKesimpulanYa As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonKesimpulanTidak As System.Windows.Forms.RadioButton
    Friend WithEvents Label15 As System.Windows.Forms.Label
End Class
