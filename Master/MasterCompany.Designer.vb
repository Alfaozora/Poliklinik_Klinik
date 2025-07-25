<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MasterCompany
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MasterCompany))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Label6 = New System.Windows.Forms.Label
        Me.txcompanyket = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txcompanycode = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtcompanystart = New System.Windows.Forms.DateTimePicker
        Me.dtcompanyend = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.buttransdisplay = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.butfindcomp = New System.Windows.Forms.Button
        Me.txcompid = New System.Windows.Forms.TextBox
        Me.txcompnol = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblload = New System.Windows.Forms.Label
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.Panelload = New System.Windows.Forms.Panel
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txPIC_Perusahaan = New System.Windows.Forms.TextBox
        Me.txalamat = New System.Windows.Forms.TextBox
        Me.txnohandphone = New System.Windows.Forms.TextBox
        Me.txemail = New System.Windows.Forms.TextBox
        Me.txPIC_Marketing = New System.Windows.Forms.TextBox
        Me.txnohandphone2 = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.rdwhatsapptrue = New System.Windows.Forms.RadioButton
        Me.rdwhatsappfalse = New System.Windows.Forms.RadioButton
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.rdemailtrue = New System.Windows.Forms.RadioButton
        Me.rdemailfalse = New System.Windows.Forms.RadioButton
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.rdterimahasilkaryawan1 = New System.Windows.Forms.RadioButton
        Me.rdterimahasilkaryawan2 = New System.Windows.Forms.RadioButton
        Me.Label14 = New System.Windows.Forms.Label
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.rdhardcopyperusahaan1 = New System.Windows.Forms.RadioButton
        Me.rdhardcopyperusahaan2 = New System.Windows.Forms.RadioButton
        Me.Label15 = New System.Windows.Forms.Label
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.rdalamatperusahaan1 = New System.Windows.Forms.RadioButton
        Me.rdalamatperusahaan2 = New System.Windows.Forms.RadioButton
        Me.Label16 = New System.Windows.Forms.Label
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.rdcompanyhasil1 = New System.Windows.Forms.RadioButton
        Me.rdcompanyhasil2 = New System.Windows.Forms.RadioButton
        Me.Label17 = New System.Windows.Forms.Label
        Me.PrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MenuStrip1.SuspendLayout()
        Me.Panelload.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AllowMerge = False
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.SaveToolStripMenuItem, Me.DeleteToolStripMenuItem, Me.CloseToolStripMenuItem, Me.PrintToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(800, 24)
        Me.MenuStrip1.TabIndex = 87
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.NewToolStripMenuItem.Text = "New"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(43, 20)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.Enabled = False
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.DeleteToolStripMenuItem.Text = "Delete"
        '
        'CloseToolStripMenuItem
        '
        Me.CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        Me.CloseToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.CloseToolStripMenuItem.Text = "Close"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(7, 83)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(105, 16)
        Me.Label6.TabIndex = 108
        Me.Label6.Text = "Kerjasama Mulai"
        '
        'txcompanyket
        '
        Me.txcompanyket.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txcompanyket.Location = New System.Drawing.Point(126, 55)
        Me.txcompanyket.Name = "txcompanyket"
        Me.txcompanyket.Size = New System.Drawing.Size(250, 22)
        Me.txcompanyket.TabIndex = 201
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(7, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(105, 16)
        Me.Label4.TabIndex = 106
        Me.Label4.Text = "Ket. Perusahaan"
        '
        'txcompanycode
        '
        Me.txcompanycode.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txcompanycode.Location = New System.Drawing.Point(126, 30)
        Me.txcompanycode.Name = "txcompanycode"
        Me.txcompanycode.Size = New System.Drawing.Size(186, 22)
        Me.txcompanycode.TabIndex = 200
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(19, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 16)
        Me.Label2.TabIndex = 104
        Me.Label2.Text = "ID Perusahaan"
        '
        'dtcompanystart
        '
        Me.dtcompanystart.CustomFormat = "dd-MMM-yyyy"
        Me.dtcompanystart.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtcompanystart.Location = New System.Drawing.Point(126, 80)
        Me.dtcompanystart.Name = "dtcompanystart"
        Me.dtcompanystart.Size = New System.Drawing.Size(107, 20)
        Me.dtcompanystart.TabIndex = 202
        '
        'dtcompanyend
        '
        Me.dtcompanyend.CustomFormat = "dd-MMM-yyyy"
        Me.dtcompanyend.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtcompanyend.Location = New System.Drawing.Point(269, 80)
        Me.dtcompanyend.Name = "dtcompanyend"
        Me.dtcompanyend.Size = New System.Drawing.Size(107, 20)
        Me.dtcompanyend.TabIndex = 111
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(240, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(23, 13)
        Me.Label1.TabIndex = 110
        Me.Label1.Text = "s/d"
        '
        'buttransdisplay
        '
        Me.buttransdisplay.Location = New System.Drawing.Point(0, 311)
        Me.buttransdisplay.Name = "buttransdisplay"
        Me.buttransdisplay.Size = New System.Drawing.Size(75, 23)
        Me.buttransdisplay.TabIndex = 112
        Me.buttransdisplay.Text = "New"
        Me.buttransdisplay.UseVisualStyleBackColor = True
        Me.buttransdisplay.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(0, 325)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 113
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'butfindcomp
        '
        Me.butfindcomp.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butfindcomp.Location = New System.Drawing.Point(318, 30)
        Me.butfindcomp.Name = "butfindcomp"
        Me.butfindcomp.Size = New System.Drawing.Size(31, 23)
        Me.butfindcomp.TabIndex = 179
        Me.butfindcomp.Text = "..."
        Me.butfindcomp.UseVisualStyleBackColor = True
        '
        'txcompid
        '
        Me.txcompid.Enabled = False
        Me.txcompid.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txcompid.Location = New System.Drawing.Point(126, 30)
        Me.txcompid.Name = "txcompid"
        Me.txcompid.Size = New System.Drawing.Size(36, 22)
        Me.txcompid.TabIndex = 180
        Me.txcompid.Visible = False
        '
        'txcompnol
        '
        Me.txcompnol.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txcompnol.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txcompnol.Location = New System.Drawing.Point(126, 155)
        Me.txcompnol.Name = "txcompnol"
        Me.txcompnol.ReadOnly = True
        Me.txcompnol.Size = New System.Drawing.Size(107, 29)
        Me.txcompnol.TabIndex = 181
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(71, 158)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 16)
        Me.Label3.TabIndex = 182
        Me.Label3.Text = "Kode"
        '
        'lblload
        '
        Me.lblload.AutoSize = True
        Me.lblload.BackColor = System.Drawing.Color.PowderBlue
        Me.lblload.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblload.Location = New System.Drawing.Point(6, 16)
        Me.lblload.Name = "lblload"
        Me.lblload.Size = New System.Drawing.Size(89, 15)
        Me.lblload.TabIndex = 184
        Me.lblload.Text = "Downloading..."
        '
        'ProgressBar1
        '
        Me.ProgressBar1.BackColor = System.Drawing.Color.Lime
        Me.ProgressBar1.Location = New System.Drawing.Point(103, 7)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(394, 33)
        Me.ProgressBar1.TabIndex = 183
        '
        'Panelload
        '
        Me.Panelload.BackColor = System.Drawing.Color.PowderBlue
        Me.Panelload.Controls.Add(Me.lblload)
        Me.Panelload.Controls.Add(Me.ProgressBar1)
        Me.Panelload.Location = New System.Drawing.Point(159, 299)
        Me.Panelload.Name = "Panelload"
        Me.Panelload.Size = New System.Drawing.Size(503, 49)
        Me.Panelload.TabIndex = 185
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(409, 108)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(118, 16)
        Me.Label5.TabIndex = 189
        Me.Label5.Text = "Alamat Pengiriman"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(387, 33)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(140, 16)
        Me.Label7.TabIndex = 188
        Me.Label7.Text = "Whatsapp Perusahaan"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(486, 83)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(41, 16)
        Me.Label8.TabIndex = 187
        Me.Label8.Text = "Email"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(7, 108)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(102, 16)
        Me.Label9.TabIndex = 186
        Me.Label9.Text = "PIC Perusahaan"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(19, 133)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(90, 16)
        Me.Label10.TabIndex = 190
        Me.Label10.Text = "PIC Marketing"
        '
        'txPIC_Perusahaan
        '
        Me.txPIC_Perusahaan.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txPIC_Perusahaan.Location = New System.Drawing.Point(126, 105)
        Me.txPIC_Perusahaan.Name = "txPIC_Perusahaan"
        Me.txPIC_Perusahaan.Size = New System.Drawing.Size(250, 22)
        Me.txPIC_Perusahaan.TabIndex = 203
        '
        'txalamat
        '
        Me.txalamat.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txalamat.Location = New System.Drawing.Point(533, 105)
        Me.txalamat.Name = "txalamat"
        Me.txalamat.Size = New System.Drawing.Size(250, 22)
        Me.txalamat.TabIndex = 207
        '
        'txnohandphone
        '
        Me.txnohandphone.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txnohandphone.Location = New System.Drawing.Point(533, 30)
        Me.txnohandphone.Name = "txnohandphone"
        Me.txnohandphone.Size = New System.Drawing.Size(250, 22)
        Me.txnohandphone.TabIndex = 206
        '
        'txemail
        '
        Me.txemail.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txemail.Location = New System.Drawing.Point(533, 80)
        Me.txemail.Name = "txemail"
        Me.txemail.Size = New System.Drawing.Size(250, 22)
        Me.txemail.TabIndex = 205
        '
        'txPIC_Marketing
        '
        Me.txPIC_Marketing.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txPIC_Marketing.Location = New System.Drawing.Point(126, 130)
        Me.txPIC_Marketing.Name = "txPIC_Marketing"
        Me.txPIC_Marketing.Size = New System.Drawing.Size(250, 22)
        Me.txPIC_Marketing.TabIndex = 204
        '
        'txnohandphone2
        '
        Me.txnohandphone2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txnohandphone2.Location = New System.Drawing.Point(533, 55)
        Me.txnohandphone2.Name = "txnohandphone2"
        Me.txnohandphone2.Size = New System.Drawing.Size(250, 22)
        Me.txnohandphone2.TabIndex = 209
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(399, 58)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(128, 16)
        Me.Label11.TabIndex = 208
        Me.Label11.Text = "Whatsapp Marketing"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel1.Controls.Add(Me.rdwhatsapptrue)
        Me.Panel1.Controls.Add(Me.rdwhatsappfalse)
        Me.Panel1.Location = New System.Drawing.Point(533, 130)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(250, 23)
        Me.Panel1.TabIndex = 228
        '
        'rdwhatsapptrue
        '
        Me.rdwhatsapptrue.AutoSize = True
        Me.rdwhatsapptrue.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdwhatsapptrue.Location = New System.Drawing.Point(3, 2)
        Me.rdwhatsapptrue.Name = "rdwhatsapptrue"
        Me.rdwhatsapptrue.Size = New System.Drawing.Size(38, 19)
        Me.rdwhatsapptrue.TabIndex = 226
        Me.rdwhatsapptrue.Text = "Ya"
        Me.rdwhatsapptrue.UseVisualStyleBackColor = True
        '
        'rdwhatsappfalse
        '
        Me.rdwhatsappfalse.AutoSize = True
        Me.rdwhatsappfalse.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdwhatsappfalse.Location = New System.Drawing.Point(47, 2)
        Me.rdwhatsappfalse.Name = "rdwhatsappfalse"
        Me.rdwhatsappfalse.Size = New System.Drawing.Size(55, 19)
        Me.rdwhatsappfalse.TabIndex = 225
        Me.rdwhatsappfalse.Text = "Tidak"
        Me.rdwhatsappfalse.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(403, 133)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(124, 16)
        Me.Label12.TabIndex = 229
        Me.Label12.Text = "Whatsapp Otomatis"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(429, 158)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(98, 16)
        Me.Label13.TabIndex = 230
        Me.Label13.Text = "Email Otomatis"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel2.Controls.Add(Me.rdemailtrue)
        Me.Panel2.Controls.Add(Me.rdemailfalse)
        Me.Panel2.Location = New System.Drawing.Point(533, 155)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(250, 23)
        Me.Panel2.TabIndex = 231
        '
        'rdemailtrue
        '
        Me.rdemailtrue.AutoSize = True
        Me.rdemailtrue.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdemailtrue.Location = New System.Drawing.Point(3, 2)
        Me.rdemailtrue.Name = "rdemailtrue"
        Me.rdemailtrue.Size = New System.Drawing.Size(38, 19)
        Me.rdemailtrue.TabIndex = 226
        Me.rdemailtrue.Text = "Ya"
        Me.rdemailtrue.UseVisualStyleBackColor = True
        '
        'rdemailfalse
        '
        Me.rdemailfalse.AutoSize = True
        Me.rdemailfalse.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdemailfalse.Location = New System.Drawing.Point(47, 2)
        Me.rdemailfalse.Name = "rdemailfalse"
        Me.rdemailfalse.Size = New System.Drawing.Size(55, 19)
        Me.rdemailfalse.TabIndex = 225
        Me.rdemailfalse.Text = "Tidak"
        Me.rdemailfalse.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel3.Controls.Add(Me.rdterimahasilkaryawan1)
        Me.Panel3.Controls.Add(Me.rdterimahasilkaryawan2)
        Me.Panel3.Location = New System.Drawing.Point(533, 205)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(250, 23)
        Me.Panel3.TabIndex = 233
        '
        'rdterimahasilkaryawan1
        '
        Me.rdterimahasilkaryawan1.AutoSize = True
        Me.rdterimahasilkaryawan1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdterimahasilkaryawan1.Location = New System.Drawing.Point(3, 2)
        Me.rdterimahasilkaryawan1.Name = "rdterimahasilkaryawan1"
        Me.rdterimahasilkaryawan1.Size = New System.Drawing.Size(38, 19)
        Me.rdterimahasilkaryawan1.TabIndex = 226
        Me.rdterimahasilkaryawan1.Text = "Ya"
        Me.rdterimahasilkaryawan1.UseVisualStyleBackColor = True
        '
        'rdterimahasilkaryawan2
        '
        Me.rdterimahasilkaryawan2.AutoSize = True
        Me.rdterimahasilkaryawan2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdterimahasilkaryawan2.Location = New System.Drawing.Point(47, 2)
        Me.rdterimahasilkaryawan2.Name = "rdterimahasilkaryawan2"
        Me.rdterimahasilkaryawan2.Size = New System.Drawing.Size(55, 19)
        Me.rdterimahasilkaryawan2.TabIndex = 225
        Me.rdterimahasilkaryawan2.Text = "Tidak"
        Me.rdterimahasilkaryawan2.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(222, 208)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(305, 16)
        Me.Label14.TabIndex = 232
        Me.Label14.Text = "Bolehkah Karyawan Menerima Softcopy/Hardcopy?"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel4.Controls.Add(Me.rdhardcopyperusahaan1)
        Me.Panel4.Controls.Add(Me.rdhardcopyperusahaan2)
        Me.Panel4.Location = New System.Drawing.Point(533, 180)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(250, 23)
        Me.Panel4.TabIndex = 235
        '
        'rdhardcopyperusahaan1
        '
        Me.rdhardcopyperusahaan1.AutoSize = True
        Me.rdhardcopyperusahaan1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdhardcopyperusahaan1.Location = New System.Drawing.Point(3, 2)
        Me.rdhardcopyperusahaan1.Name = "rdhardcopyperusahaan1"
        Me.rdhardcopyperusahaan1.Size = New System.Drawing.Size(38, 19)
        Me.rdhardcopyperusahaan1.TabIndex = 226
        Me.rdhardcopyperusahaan1.Text = "Ya"
        Me.rdhardcopyperusahaan1.UseVisualStyleBackColor = True
        '
        'rdhardcopyperusahaan2
        '
        Me.rdhardcopyperusahaan2.AutoSize = True
        Me.rdhardcopyperusahaan2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdhardcopyperusahaan2.Location = New System.Drawing.Point(47, 2)
        Me.rdhardcopyperusahaan2.Name = "rdhardcopyperusahaan2"
        Me.rdhardcopyperusahaan2.Size = New System.Drawing.Size(55, 19)
        Me.rdhardcopyperusahaan2.TabIndex = 225
        Me.rdhardcopyperusahaan2.Text = "Tidak"
        Me.rdhardcopyperusahaan2.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(302, 183)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(225, 16)
        Me.Label15.TabIndex = 234
        Me.Label15.Text = "Apakah Perusahaan Perlu Hardcopy?"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel5.Controls.Add(Me.rdalamatperusahaan1)
        Me.Panel5.Controls.Add(Me.rdalamatperusahaan2)
        Me.Panel5.Location = New System.Drawing.Point(533, 230)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(250, 23)
        Me.Panel5.TabIndex = 237
        '
        'rdalamatperusahaan1
        '
        Me.rdalamatperusahaan1.AutoSize = True
        Me.rdalamatperusahaan1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdalamatperusahaan1.Location = New System.Drawing.Point(3, 2)
        Me.rdalamatperusahaan1.Name = "rdalamatperusahaan1"
        Me.rdalamatperusahaan1.Size = New System.Drawing.Size(38, 19)
        Me.rdalamatperusahaan1.TabIndex = 226
        Me.rdalamatperusahaan1.Text = "Ya"
        Me.rdalamatperusahaan1.UseVisualStyleBackColor = True
        '
        'rdalamatperusahaan2
        '
        Me.rdalamatperusahaan2.AutoSize = True
        Me.rdalamatperusahaan2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdalamatperusahaan2.Location = New System.Drawing.Point(47, 2)
        Me.rdalamatperusahaan2.Name = "rdalamatperusahaan2"
        Me.rdalamatperusahaan2.Size = New System.Drawing.Size(55, 19)
        Me.rdalamatperusahaan2.TabIndex = 225
        Me.rdalamatperusahaan2.Text = "Tidak"
        Me.rdalamatperusahaan2.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(304, 233)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(223, 16)
        Me.Label16.TabIndex = 236
        Me.Label16.Text = "Alamat Kirim Mengikuti Perusahaan?"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel6.Controls.Add(Me.rdcompanyhasil1)
        Me.Panel6.Controls.Add(Me.rdcompanyhasil2)
        Me.Panel6.Location = New System.Drawing.Point(533, 255)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(250, 23)
        Me.Panel6.TabIndex = 239
        '
        'rdcompanyhasil1
        '
        Me.rdcompanyhasil1.AutoSize = True
        Me.rdcompanyhasil1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdcompanyhasil1.Location = New System.Drawing.Point(3, 2)
        Me.rdcompanyhasil1.Name = "rdcompanyhasil1"
        Me.rdcompanyhasil1.Size = New System.Drawing.Size(38, 19)
        Me.rdcompanyhasil1.TabIndex = 226
        Me.rdcompanyhasil1.Text = "Ya"
        Me.rdcompanyhasil1.UseVisualStyleBackColor = True
        '
        'rdcompanyhasil2
        '
        Me.rdcompanyhasil2.AutoSize = True
        Me.rdcompanyhasil2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdcompanyhasil2.Location = New System.Drawing.Point(47, 2)
        Me.rdcompanyhasil2.Name = "rdcompanyhasil2"
        Me.rdcompanyhasil2.Size = New System.Drawing.Size(55, 19)
        Me.rdcompanyhasil2.TabIndex = 225
        Me.rdcompanyhasil2.Text = "Tidak"
        Me.rdcompanyhasil2.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(227, 258)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(300, 16)
        Me.Label17.TabIndex = 238
        Me.Label17.Text = "Apakah Nama Perusahaan Boleh Muncul di Hasil?"
        '
        'PrintToolStripMenuItem
        '
        Me.PrintToolStripMenuItem.Name = "PrintToolStripMenuItem"
        Me.PrintToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.PrintToolStripMenuItem.Text = "Print"
        '
        'MasterCompany
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.PoliKlinik_Net2.My.Resources.Resources.wallpaperdialog
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(800, 427)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txnohandphone2)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txPIC_Marketing)
        Me.Controls.Add(Me.txemail)
        Me.Controls.Add(Me.txnohandphone)
        Me.Controls.Add(Me.txalamat)
        Me.Controls.Add(Me.txPIC_Perusahaan)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Panelload)
        Me.Controls.Add(Me.txcompnol)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txcompid)
        Me.Controls.Add(Me.butfindcomp)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.buttransdisplay)
        Me.Controls.Add(Me.dtcompanyend)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtcompanystart)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txcompanyket)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txcompanycode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MasterCompany"
        Me.Text = "Company Kerjasama ( Tagihan )"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panelload.ResumeLayout(False)
        Me.Panelload.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txcompanyket As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txcompanycode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtcompanystart As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtcompanyend As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents buttransdisplay As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents butfindcomp As System.Windows.Forms.Button
    Friend WithEvents txcompid As System.Windows.Forms.TextBox
    Friend WithEvents txcompnol As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblload As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Panelload As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txPIC_Perusahaan As System.Windows.Forms.TextBox
    Friend WithEvents txalamat As System.Windows.Forms.TextBox
    Friend WithEvents txnohandphone As System.Windows.Forms.TextBox
    Friend WithEvents txemail As System.Windows.Forms.TextBox
    Friend WithEvents txPIC_Marketing As System.Windows.Forms.TextBox
    Friend WithEvents txnohandphone2 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents rdwhatsapptrue As System.Windows.Forms.RadioButton
    Friend WithEvents rdwhatsappfalse As System.Windows.Forms.RadioButton
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents rdemailtrue As System.Windows.Forms.RadioButton
    Friend WithEvents rdemailfalse As System.Windows.Forms.RadioButton
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents rdterimahasilkaryawan1 As System.Windows.Forms.RadioButton
    Friend WithEvents rdterimahasilkaryawan2 As System.Windows.Forms.RadioButton
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents rdhardcopyperusahaan1 As System.Windows.Forms.RadioButton
    Friend WithEvents rdhardcopyperusahaan2 As System.Windows.Forms.RadioButton
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents rdalamatperusahaan1 As System.Windows.Forms.RadioButton
    Friend WithEvents rdalamatperusahaan2 As System.Windows.Forms.RadioButton
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents rdcompanyhasil1 As System.Windows.Forms.RadioButton
    Friend WithEvents rdcompanyhasil2 As System.Windows.Forms.RadioButton
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents PrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
End Class
