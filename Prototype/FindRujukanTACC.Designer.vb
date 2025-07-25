<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FindRujukanTACC
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FindRujukanTACC))
        Me.Label1 = New System.Windows.Forms.Label
        Me.PanelTop = New System.Windows.Forms.Panel
        Me.btnClose = New System.Windows.Forms.Button
        Me.PanelHeader = New System.Windows.Forms.Panel
        Me.PanelKeadaanUmumMenuPemeriksaanAwal = New System.Windows.Forms.Panel
        Me.RadioButtonTanpaTACC = New System.Windows.Forms.RadioButton
        Me.RadioButtonTACC = New System.Windows.Forms.RadioButton
        Me.SplitContainerPencarianData = New System.Windows.Forms.SplitContainer
        Me.SplitContainerRujukanTACC = New System.Windows.Forms.SplitContainer
        Me.SplitContainerDetailTACC = New System.Windows.Forms.SplitContainer
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.RadioButtonComplication = New System.Windows.Forms.RadioButton
        Me.RadioButtonComorbidity = New System.Windows.Forms.RadioButton
        Me.RadioButtonTime = New System.Windows.Forms.RadioButton
        Me.RadioButtonAge = New System.Windows.Forms.RadioButton
        Me.TabControlRujukanTACC = New System.Windows.Forms.TabControl
        Me.TabPageTime = New System.Windows.Forms.TabPage
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.RadioButtonTimeOption3 = New System.Windows.Forms.RadioButton
        Me.RadioButtonTimeOption1 = New System.Windows.Forms.RadioButton
        Me.RadioButtonTimeOption2 = New System.Windows.Forms.RadioButton
        Me.TabPageAge = New System.Windows.Forms.TabPage
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.RadioButtonAgeOption6 = New System.Windows.Forms.RadioButton
        Me.RadioButtonAgeOption4 = New System.Windows.Forms.RadioButton
        Me.RadioButtonAgeOption5 = New System.Windows.Forms.RadioButton
        Me.RadioButtonAgeOption3 = New System.Windows.Forms.RadioButton
        Me.RadioButtonAgeOption1 = New System.Windows.Forms.RadioButton
        Me.RadioButtonAgeOption2 = New System.Windows.Forms.RadioButton
        Me.TabPageComplication = New System.Windows.Forms.TabPage
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.Label203 = New System.Windows.Forms.Label
        Me.ButtonFindDiagnosaComplication = New System.Windows.Forms.Button
        Me.TextBoxKeteranganDiagnosaComplication = New System.Windows.Forms.TextBox
        Me.TextBoxKodeDiagnosaComplication = New System.Windows.Forms.TextBox
        Me.TabPageComorbidity = New System.Windows.Forms.TabPage
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.ButtonFindDiagnosaComorbidity = New System.Windows.Forms.Button
        Me.TextBoxKeteranganDiagnosaComorbidity = New System.Windows.Forms.TextBox
        Me.TextBoxKodeDiagnosaComorbidity = New System.Windows.Forms.TextBox
        Me.ButtonSave = New System.Windows.Forms.Button
        Me.PanelTop.SuspendLayout()
        Me.PanelHeader.SuspendLayout()
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.SuspendLayout()
        Me.SplitContainerPencarianData.Panel1.SuspendLayout()
        Me.SplitContainerPencarianData.Panel2.SuspendLayout()
        Me.SplitContainerPencarianData.SuspendLayout()
        Me.SplitContainerRujukanTACC.Panel1.SuspendLayout()
        Me.SplitContainerRujukanTACC.Panel2.SuspendLayout()
        Me.SplitContainerRujukanTACC.SuspendLayout()
        Me.SplitContainerDetailTACC.Panel1.SuspendLayout()
        Me.SplitContainerDetailTACC.Panel2.SuspendLayout()
        Me.SplitContainerDetailTACC.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TabControlRujukanTACC.SuspendLayout()
        Me.TabPageTime.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.TabPageAge.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.TabPageComplication.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.TabPageComorbidity.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(26, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(634, 17)
        Me.Label1.TabIndex = 193
        Me.Label1.Text = "Diagnosa yang dipilih merupakan diagnosa non-spesialistik apakah pasien tersebut " & _
            "akan tetap dirujuk?"
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.PanelTop.Controls.Add(Me.btnClose)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(694, 35)
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
        Me.btnClose.Location = New System.Drawing.Point(654, 0)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(40, 35)
        Me.btnClose.TabIndex = 281
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'PanelHeader
        '
        Me.PanelHeader.BackColor = System.Drawing.Color.Transparent
        Me.PanelHeader.Controls.Add(Me.PanelKeadaanUmumMenuPemeriksaanAwal)
        Me.PanelHeader.Controls.Add(Me.Label1)
        Me.PanelHeader.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelHeader.Location = New System.Drawing.Point(0, 0)
        Me.PanelHeader.Name = "PanelHeader"
        Me.PanelHeader.Size = New System.Drawing.Size(694, 105)
        Me.PanelHeader.TabIndex = 6
        '
        'PanelKeadaanUmumMenuPemeriksaanAwal
        '
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.BackColor = System.Drawing.Color.Transparent
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.Controls.Add(Me.RadioButtonTanpaTACC)
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.Controls.Add(Me.RadioButtonTACC)
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.Location = New System.Drawing.Point(29, 48)
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.Name = "PanelKeadaanUmumMenuPemeriksaanAwal"
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.Size = New System.Drawing.Size(200, 55)
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.TabIndex = 439
        '
        'RadioButtonTanpaTACC
        '
        Me.RadioButtonTanpaTACC.AutoSize = True
        Me.RadioButtonTanpaTACC.Checked = True
        Me.RadioButtonTanpaTACC.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonTanpaTACC.Location = New System.Drawing.Point(3, 3)
        Me.RadioButtonTanpaTACC.Name = "RadioButtonTanpaTACC"
        Me.RadioButtonTanpaTACC.Size = New System.Drawing.Size(128, 21)
        Me.RadioButtonTanpaTACC.TabIndex = 440
        Me.RadioButtonTanpaTACC.TabStop = True
        Me.RadioButtonTanpaTACC.Tag = "-1"
        Me.RadioButtonTanpaTACC.Text = "Rujuk tanpa TACC"
        Me.RadioButtonTanpaTACC.UseVisualStyleBackColor = True
        '
        'RadioButtonTACC
        '
        Me.RadioButtonTACC.AutoSize = True
        Me.RadioButtonTACC.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonTACC.Location = New System.Drawing.Point(3, 30)
        Me.RadioButtonTACC.Name = "RadioButtonTACC"
        Me.RadioButtonTACC.Size = New System.Drawing.Size(139, 21)
        Me.RadioButtonTACC.TabIndex = 245
        Me.RadioButtonTACC.Text = "Rujuk dengan TACC"
        Me.RadioButtonTACC.UseVisualStyleBackColor = True
        '
        'SplitContainerPencarianData
        '
        Me.SplitContainerPencarianData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerPencarianData.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainerPencarianData.IsSplitterFixed = True
        Me.SplitContainerPencarianData.Location = New System.Drawing.Point(0, 35)
        Me.SplitContainerPencarianData.Name = "SplitContainerPencarianData"
        Me.SplitContainerPencarianData.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerPencarianData.Panel1
        '
        Me.SplitContainerPencarianData.Panel1.AutoScroll = True
        Me.SplitContainerPencarianData.Panel1.Controls.Add(Me.SplitContainerRujukanTACC)
        '
        'SplitContainerPencarianData.Panel2
        '
        Me.SplitContainerPencarianData.Panel2.AutoScroll = True
        Me.SplitContainerPencarianData.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.SplitContainerPencarianData.Panel2.Controls.Add(Me.ButtonSave)
        Me.SplitContainerPencarianData.Size = New System.Drawing.Size(694, 459)
        Me.SplitContainerPencarianData.SplitterDistance = 401
        Me.SplitContainerPencarianData.SplitterWidth = 5
        Me.SplitContainerPencarianData.TabIndex = 502
        '
        'SplitContainerRujukanTACC
        '
        Me.SplitContainerRujukanTACC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerRujukanTACC.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainerRujukanTACC.IsSplitterFixed = True
        Me.SplitContainerRujukanTACC.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerRujukanTACC.Name = "SplitContainerRujukanTACC"
        Me.SplitContainerRujukanTACC.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerRujukanTACC.Panel1
        '
        Me.SplitContainerRujukanTACC.Panel1.AutoScroll = True
        Me.SplitContainerRujukanTACC.Panel1.Controls.Add(Me.PanelHeader)
        '
        'SplitContainerRujukanTACC.Panel2
        '
        Me.SplitContainerRujukanTACC.Panel2.AutoScroll = True
        Me.SplitContainerRujukanTACC.Panel2.Controls.Add(Me.SplitContainerDetailTACC)
        Me.SplitContainerRujukanTACC.Size = New System.Drawing.Size(694, 401)
        Me.SplitContainerRujukanTACC.SplitterDistance = 105
        Me.SplitContainerRujukanTACC.SplitterWidth = 5
        Me.SplitContainerRujukanTACC.TabIndex = 502
        '
        'SplitContainerDetailTACC
        '
        Me.SplitContainerDetailTACC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerDetailTACC.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainerDetailTACC.IsSplitterFixed = True
        Me.SplitContainerDetailTACC.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerDetailTACC.Name = "SplitContainerDetailTACC"
        Me.SplitContainerDetailTACC.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerDetailTACC.Panel1
        '
        Me.SplitContainerDetailTACC.Panel1.AutoScroll = True
        Me.SplitContainerDetailTACC.Panel1.Controls.Add(Me.Panel2)
        '
        'SplitContainerDetailTACC.Panel2
        '
        Me.SplitContainerDetailTACC.Panel2.AutoScroll = True
        Me.SplitContainerDetailTACC.Panel2.Controls.Add(Me.TabControlRujukanTACC)
        Me.SplitContainerDetailTACC.Size = New System.Drawing.Size(694, 291)
        Me.SplitContainerDetailTACC.SplitterDistance = 35
        Me.SplitContainerDetailTACC.SplitterWidth = 5
        Me.SplitContainerDetailTACC.TabIndex = 503
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(694, 35)
        Me.Panel2.TabIndex = 6
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.RadioButtonComplication)
        Me.Panel1.Controls.Add(Me.RadioButtonComorbidity)
        Me.Panel1.Controls.Add(Me.RadioButtonTime)
        Me.Panel1.Controls.Add(Me.RadioButtonAge)
        Me.Panel1.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Panel1.Location = New System.Drawing.Point(45, 5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(575, 25)
        Me.Panel1.TabIndex = 441
        '
        'RadioButtonComplication
        '
        Me.RadioButtonComplication.AutoSize = True
        Me.RadioButtonComplication.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonComplication.Location = New System.Drawing.Point(211, 3)
        Me.RadioButtonComplication.Name = "RadioButtonComplication"
        Me.RadioButtonComplication.Size = New System.Drawing.Size(177, 21)
        Me.RadioButtonComplication.TabIndex = 440
        Me.RadioButtonComplication.Tag = "3"
        Me.RadioButtonComplication.Text = "Complication (Komplikasi)"
        Me.RadioButtonComplication.UseVisualStyleBackColor = True
        '
        'RadioButtonComorbidity
        '
        Me.RadioButtonComorbidity.AutoSize = True
        Me.RadioButtonComorbidity.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonComorbidity.Location = New System.Drawing.Point(394, 3)
        Me.RadioButtonComorbidity.Name = "RadioButtonComorbidity"
        Me.RadioButtonComorbidity.Size = New System.Drawing.Size(166, 21)
        Me.RadioButtonComorbidity.TabIndex = 439
        Me.RadioButtonComorbidity.Tag = "4"
        Me.RadioButtonComorbidity.Text = "Comorbidity (Pemberat)"
        Me.RadioButtonComorbidity.UseVisualStyleBackColor = True
        '
        'RadioButtonTime
        '
        Me.RadioButtonTime.AutoSize = True
        Me.RadioButtonTime.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonTime.Location = New System.Drawing.Point(5, 3)
        Me.RadioButtonTime.Name = "RadioButtonTime"
        Me.RadioButtonTime.Size = New System.Drawing.Size(101, 21)
        Me.RadioButtonTime.TabIndex = 245
        Me.RadioButtonTime.Tag = "1"
        Me.RadioButtonTime.Text = "Time (Waktu)"
        Me.RadioButtonTime.UseVisualStyleBackColor = True
        '
        'RadioButtonAge
        '
        Me.RadioButtonAge.AutoSize = True
        Me.RadioButtonAge.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonAge.Location = New System.Drawing.Point(112, 3)
        Me.RadioButtonAge.Name = "RadioButtonAge"
        Me.RadioButtonAge.Size = New System.Drawing.Size(93, 21)
        Me.RadioButtonAge.TabIndex = 246
        Me.RadioButtonAge.Tag = "2"
        Me.RadioButtonAge.Text = "Age (Umur)"
        Me.RadioButtonAge.UseVisualStyleBackColor = True
        '
        'TabControlRujukanTACC
        '
        Me.TabControlRujukanTACC.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControlRujukanTACC.Controls.Add(Me.TabPageTime)
        Me.TabControlRujukanTACC.Controls.Add(Me.TabPageAge)
        Me.TabControlRujukanTACC.Controls.Add(Me.TabPageComplication)
        Me.TabControlRujukanTACC.Controls.Add(Me.TabPageComorbidity)
        Me.TabControlRujukanTACC.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlRujukanTACC.ItemSize = New System.Drawing.Size(100, 25)
        Me.TabControlRujukanTACC.Location = New System.Drawing.Point(0, 0)
        Me.TabControlRujukanTACC.Name = "TabControlRujukanTACC"
        Me.TabControlRujukanTACC.SelectedIndex = 0
        Me.TabControlRujukanTACC.Size = New System.Drawing.Size(694, 251)
        Me.TabControlRujukanTACC.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControlRujukanTACC.TabIndex = 1
        '
        'TabPageTime
        '
        Me.TabPageTime.AutoScroll = True
        Me.TabPageTime.BackColor = System.Drawing.Color.White
        Me.TabPageTime.Controls.Add(Me.Panel3)
        Me.TabPageTime.Location = New System.Drawing.Point(4, 29)
        Me.TabPageTime.Name = "TabPageTime"
        Me.TabPageTime.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageTime.Size = New System.Drawing.Size(686, 218)
        Me.TabPageTime.TabIndex = 0
        Me.TabPageTime.Text = "Time"
        Me.TabPageTime.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.RadioButtonTimeOption3)
        Me.Panel3.Controls.Add(Me.RadioButtonTimeOption1)
        Me.Panel3.Controls.Add(Me.RadioButtonTimeOption2)
        Me.Panel3.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Panel3.Location = New System.Drawing.Point(65, 5)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(200, 88)
        Me.Panel3.TabIndex = 440
        '
        'RadioButtonTimeOption3
        '
        Me.RadioButtonTimeOption3.AutoSize = True
        Me.RadioButtonTimeOption3.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonTimeOption3.Location = New System.Drawing.Point(3, 57)
        Me.RadioButtonTimeOption3.Name = "RadioButtonTimeOption3"
        Me.RadioButtonTimeOption3.Size = New System.Drawing.Size(83, 21)
        Me.RadioButtonTimeOption3.TabIndex = 441
        Me.RadioButtonTimeOption3.TabStop = True
        Me.RadioButtonTimeOption3.Text = ">= 7 Hari"
        Me.RadioButtonTimeOption3.UseVisualStyleBackColor = True
        '
        'RadioButtonTimeOption1
        '
        Me.RadioButtonTimeOption1.AutoSize = True
        Me.RadioButtonTimeOption1.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonTimeOption1.Location = New System.Drawing.Point(3, 3)
        Me.RadioButtonTimeOption1.Name = "RadioButtonTimeOption1"
        Me.RadioButtonTimeOption1.Size = New System.Drawing.Size(74, 21)
        Me.RadioButtonTimeOption1.TabIndex = 440
        Me.RadioButtonTimeOption1.TabStop = True
        Me.RadioButtonTimeOption1.Text = "< 3 Hari"
        Me.RadioButtonTimeOption1.UseVisualStyleBackColor = True
        '
        'RadioButtonTimeOption2
        '
        Me.RadioButtonTimeOption2.AutoSize = True
        Me.RadioButtonTimeOption2.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonTimeOption2.Location = New System.Drawing.Point(3, 30)
        Me.RadioButtonTimeOption2.Name = "RadioButtonTimeOption2"
        Me.RadioButtonTimeOption2.Size = New System.Drawing.Size(103, 21)
        Me.RadioButtonTimeOption2.TabIndex = 245
        Me.RadioButtonTimeOption2.TabStop = True
        Me.RadioButtonTimeOption2.Text = ">= 3 - 7 Hari"
        Me.RadioButtonTimeOption2.UseVisualStyleBackColor = True
        '
        'TabPageAge
        '
        Me.TabPageAge.AutoScroll = True
        Me.TabPageAge.BackColor = System.Drawing.Color.White
        Me.TabPageAge.Controls.Add(Me.Panel4)
        Me.TabPageAge.Location = New System.Drawing.Point(4, 29)
        Me.TabPageAge.Name = "TabPageAge"
        Me.TabPageAge.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageAge.Size = New System.Drawing.Size(686, 219)
        Me.TabPageAge.TabIndex = 1
        Me.TabPageAge.Text = "Age"
        Me.TabPageAge.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.Controls.Add(Me.RadioButtonAgeOption6)
        Me.Panel4.Controls.Add(Me.RadioButtonAgeOption4)
        Me.Panel4.Controls.Add(Me.RadioButtonAgeOption5)
        Me.Panel4.Controls.Add(Me.RadioButtonAgeOption3)
        Me.Panel4.Controls.Add(Me.RadioButtonAgeOption1)
        Me.Panel4.Controls.Add(Me.RadioButtonAgeOption2)
        Me.Panel4.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Panel4.Location = New System.Drawing.Point(65, 5)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(400, 175)
        Me.Panel4.TabIndex = 441
        '
        'RadioButtonAgeOption6
        '
        Me.RadioButtonAgeOption6.AutoSize = True
        Me.RadioButtonAgeOption6.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonAgeOption6.Location = New System.Drawing.Point(3, 138)
        Me.RadioButtonAgeOption6.Name = "RadioButtonAgeOption6"
        Me.RadioButtonAgeOption6.Size = New System.Drawing.Size(100, 21)
        Me.RadioButtonAgeOption6.TabIndex = 444
        Me.RadioButtonAgeOption6.TabStop = True
        Me.RadioButtonAgeOption6.Text = ">= 55 Tahun"
        Me.RadioButtonAgeOption6.UseVisualStyleBackColor = True
        '
        'RadioButtonAgeOption4
        '
        Me.RadioButtonAgeOption4.AutoSize = True
        Me.RadioButtonAgeOption4.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonAgeOption4.Location = New System.Drawing.Point(3, 84)
        Me.RadioButtonAgeOption4.Name = "RadioButtonAgeOption4"
        Me.RadioButtonAgeOption4.Size = New System.Drawing.Size(185, 21)
        Me.RadioButtonAgeOption4.TabIndex = 443
        Me.RadioButtonAgeOption4.TabStop = True
        Me.RadioButtonAgeOption4.Text = ">= 5 Tahun s/d < 12 Tahun"
        Me.RadioButtonAgeOption4.UseVisualStyleBackColor = True
        '
        'RadioButtonAgeOption5
        '
        Me.RadioButtonAgeOption5.AutoSize = True
        Me.RadioButtonAgeOption5.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonAgeOption5.Location = New System.Drawing.Point(3, 111)
        Me.RadioButtonAgeOption5.Name = "RadioButtonAgeOption5"
        Me.RadioButtonAgeOption5.Size = New System.Drawing.Size(192, 21)
        Me.RadioButtonAgeOption5.TabIndex = 442
        Me.RadioButtonAgeOption5.TabStop = True
        Me.RadioButtonAgeOption5.Text = ">= 12 Tahun s/d < 55 Tahun"
        Me.RadioButtonAgeOption5.UseVisualStyleBackColor = True
        '
        'RadioButtonAgeOption3
        '
        Me.RadioButtonAgeOption3.AutoSize = True
        Me.RadioButtonAgeOption3.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonAgeOption3.Location = New System.Drawing.Point(3, 57)
        Me.RadioButtonAgeOption3.Name = "RadioButtonAgeOption3"
        Me.RadioButtonAgeOption3.Size = New System.Drawing.Size(178, 21)
        Me.RadioButtonAgeOption3.TabIndex = 441
        Me.RadioButtonAgeOption3.TabStop = True
        Me.RadioButtonAgeOption3.Text = ">= 1 Tahun s/d < 5 Tahun"
        Me.RadioButtonAgeOption3.UseVisualStyleBackColor = True
        '
        'RadioButtonAgeOption1
        '
        Me.RadioButtonAgeOption1.AutoSize = True
        Me.RadioButtonAgeOption1.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonAgeOption1.Location = New System.Drawing.Point(3, 3)
        Me.RadioButtonAgeOption1.Name = "RadioButtonAgeOption1"
        Me.RadioButtonAgeOption1.Size = New System.Drawing.Size(81, 21)
        Me.RadioButtonAgeOption1.TabIndex = 440
        Me.RadioButtonAgeOption1.TabStop = True
        Me.RadioButtonAgeOption1.Text = "< 1 Bulan"
        Me.RadioButtonAgeOption1.UseVisualStyleBackColor = True
        '
        'RadioButtonAgeOption2
        '
        Me.RadioButtonAgeOption2.AutoSize = True
        Me.RadioButtonAgeOption2.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonAgeOption2.Location = New System.Drawing.Point(3, 30)
        Me.RadioButtonAgeOption2.Name = "RadioButtonAgeOption2"
        Me.RadioButtonAgeOption2.Size = New System.Drawing.Size(179, 21)
        Me.RadioButtonAgeOption2.TabIndex = 245
        Me.RadioButtonAgeOption2.TabStop = True
        Me.RadioButtonAgeOption2.Text = ">= 1 Bulan s/d < 12 Bulan"
        Me.RadioButtonAgeOption2.UseVisualStyleBackColor = True
        '
        'TabPageComplication
        '
        Me.TabPageComplication.AutoScroll = True
        Me.TabPageComplication.BackColor = System.Drawing.Color.White
        Me.TabPageComplication.Controls.Add(Me.Panel5)
        Me.TabPageComplication.Location = New System.Drawing.Point(4, 29)
        Me.TabPageComplication.Name = "TabPageComplication"
        Me.TabPageComplication.Size = New System.Drawing.Size(686, 219)
        Me.TabPageComplication.TabIndex = 2
        Me.TabPageComplication.Text = "Complication"
        Me.TabPageComplication.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Transparent
        Me.Panel5.Controls.Add(Me.Label203)
        Me.Panel5.Controls.Add(Me.ButtonFindDiagnosaComplication)
        Me.Panel5.Controls.Add(Me.TextBoxKeteranganDiagnosaComplication)
        Me.Panel5.Controls.Add(Me.TextBoxKodeDiagnosaComplication)
        Me.Panel5.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Panel5.Location = New System.Drawing.Point(65, 5)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(510, 40)
        Me.Panel5.TabIndex = 507
        '
        'Label203
        '
        Me.Label203.AutoSize = True
        Me.Label203.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label203.Location = New System.Drawing.Point(3, 10)
        Me.Label203.Name = "Label203"
        Me.Label203.Size = New System.Drawing.Size(67, 17)
        Me.Label203.TabIndex = 503
        Me.Label203.Text = "Diagnosa:"
        '
        'ButtonFindDiagnosaComplication
        '
        Me.ButtonFindDiagnosaComplication.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindDiagnosaComplication.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonFindDiagnosaComplication.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonFindDiagnosaComplication.FlatAppearance.BorderSize = 0
        Me.ButtonFindDiagnosaComplication.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindDiagnosaComplication.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonFindDiagnosaComplication.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonFindDiagnosaComplication.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonFindDiagnosaComplication.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ButtonFindDiagnosaComplication.Location = New System.Drawing.Point(438, 8)
        Me.ButtonFindDiagnosaComplication.Name = "ButtonFindDiagnosaComplication"
        Me.ButtonFindDiagnosaComplication.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonFindDiagnosaComplication.Size = New System.Drawing.Size(60, 25)
        Me.ButtonFindDiagnosaComplication.TabIndex = 505
        Me.ButtonFindDiagnosaComplication.Text = " Cari"
        Me.ButtonFindDiagnosaComplication.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonFindDiagnosaComplication.UseVisualStyleBackColor = False
        '
        'TextBoxKeteranganDiagnosaComplication
        '
        Me.TextBoxKeteranganDiagnosaComplication.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.TextBoxKeteranganDiagnosaComplication.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxKeteranganDiagnosaComplication.Cursor = System.Windows.Forms.Cursors.No
        Me.TextBoxKeteranganDiagnosaComplication.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxKeteranganDiagnosaComplication.Location = New System.Drawing.Point(132, 8)
        Me.TextBoxKeteranganDiagnosaComplication.Name = "TextBoxKeteranganDiagnosaComplication"
        Me.TextBoxKeteranganDiagnosaComplication.ReadOnly = True
        Me.TextBoxKeteranganDiagnosaComplication.Size = New System.Drawing.Size(300, 25)
        Me.TextBoxKeteranganDiagnosaComplication.TabIndex = 506
        '
        'TextBoxKodeDiagnosaComplication
        '
        Me.TextBoxKodeDiagnosaComplication.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.TextBoxKodeDiagnosaComplication.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxKodeDiagnosaComplication.Cursor = System.Windows.Forms.Cursors.No
        Me.TextBoxKodeDiagnosaComplication.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxKodeDiagnosaComplication.Location = New System.Drawing.Point(76, 8)
        Me.TextBoxKodeDiagnosaComplication.Name = "TextBoxKodeDiagnosaComplication"
        Me.TextBoxKodeDiagnosaComplication.ReadOnly = True
        Me.TextBoxKodeDiagnosaComplication.Size = New System.Drawing.Size(50, 25)
        Me.TextBoxKodeDiagnosaComplication.TabIndex = 504
        Me.TextBoxKodeDiagnosaComplication.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TabPageComorbidity
        '
        Me.TabPageComorbidity.AutoScroll = True
        Me.TabPageComorbidity.BackColor = System.Drawing.Color.White
        Me.TabPageComorbidity.Controls.Add(Me.Panel6)
        Me.TabPageComorbidity.Location = New System.Drawing.Point(4, 29)
        Me.TabPageComorbidity.Name = "TabPageComorbidity"
        Me.TabPageComorbidity.Size = New System.Drawing.Size(686, 219)
        Me.TabPageComorbidity.TabIndex = 3
        Me.TabPageComorbidity.Text = "Comorbidity"
        Me.TabPageComorbidity.UseVisualStyleBackColor = True
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Transparent
        Me.Panel6.Controls.Add(Me.Label2)
        Me.Panel6.Controls.Add(Me.ButtonFindDiagnosaComorbidity)
        Me.Panel6.Controls.Add(Me.TextBoxKeteranganDiagnosaComorbidity)
        Me.Panel6.Controls.Add(Me.TextBoxKodeDiagnosaComorbidity)
        Me.Panel6.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Panel6.Location = New System.Drawing.Point(65, 5)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(510, 40)
        Me.Panel6.TabIndex = 508
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.Location = New System.Drawing.Point(3, 10)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 17)
        Me.Label2.TabIndex = 503
        Me.Label2.Text = "Diagnosa:"
        '
        'ButtonFindDiagnosaComorbidity
        '
        Me.ButtonFindDiagnosaComorbidity.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindDiagnosaComorbidity.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonFindDiagnosaComorbidity.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonFindDiagnosaComorbidity.FlatAppearance.BorderSize = 0
        Me.ButtonFindDiagnosaComorbidity.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonFindDiagnosaComorbidity.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonFindDiagnosaComorbidity.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonFindDiagnosaComorbidity.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonFindDiagnosaComorbidity.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.ButtonFindDiagnosaComorbidity.Location = New System.Drawing.Point(438, 8)
        Me.ButtonFindDiagnosaComorbidity.Name = "ButtonFindDiagnosaComorbidity"
        Me.ButtonFindDiagnosaComorbidity.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonFindDiagnosaComorbidity.Size = New System.Drawing.Size(60, 25)
        Me.ButtonFindDiagnosaComorbidity.TabIndex = 505
        Me.ButtonFindDiagnosaComorbidity.Text = " Cari"
        Me.ButtonFindDiagnosaComorbidity.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonFindDiagnosaComorbidity.UseVisualStyleBackColor = False
        '
        'TextBoxKeteranganDiagnosaComorbidity
        '
        Me.TextBoxKeteranganDiagnosaComorbidity.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.TextBoxKeteranganDiagnosaComorbidity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxKeteranganDiagnosaComorbidity.Cursor = System.Windows.Forms.Cursors.No
        Me.TextBoxKeteranganDiagnosaComorbidity.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxKeteranganDiagnosaComorbidity.Location = New System.Drawing.Point(132, 8)
        Me.TextBoxKeteranganDiagnosaComorbidity.Name = "TextBoxKeteranganDiagnosaComorbidity"
        Me.TextBoxKeteranganDiagnosaComorbidity.ReadOnly = True
        Me.TextBoxKeteranganDiagnosaComorbidity.Size = New System.Drawing.Size(300, 25)
        Me.TextBoxKeteranganDiagnosaComorbidity.TabIndex = 506
        '
        'TextBoxKodeDiagnosaComorbidity
        '
        Me.TextBoxKodeDiagnosaComorbidity.BackColor = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.TextBoxKodeDiagnosaComorbidity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBoxKodeDiagnosaComorbidity.Cursor = System.Windows.Forms.Cursors.No
        Me.TextBoxKodeDiagnosaComorbidity.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxKodeDiagnosaComorbidity.Location = New System.Drawing.Point(76, 8)
        Me.TextBoxKodeDiagnosaComorbidity.Name = "TextBoxKodeDiagnosaComorbidity"
        Me.TextBoxKodeDiagnosaComorbidity.ReadOnly = True
        Me.TextBoxKodeDiagnosaComorbidity.Size = New System.Drawing.Size(50, 25)
        Me.TextBoxKodeDiagnosaComorbidity.TabIndex = 504
        Me.TextBoxKodeDiagnosaComorbidity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ButtonSave
        '
        Me.ButtonSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonSave.Dock = System.Windows.Forms.DockStyle.Right
        Me.ButtonSave.FlatAppearance.BorderSize = 0
        Me.ButtonSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSave.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSave.ForeColor = System.Drawing.Color.White
        Me.ButtonSave.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_add_24
        Me.ButtonSave.Location = New System.Drawing.Point(544, 0)
        Me.ButtonSave.Name = "ButtonSave"
        Me.ButtonSave.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.ButtonSave.Size = New System.Drawing.Size(150, 53)
        Me.ButtonSave.TabIndex = 5
        Me.ButtonSave.Text = "  Tambah Data"
        Me.ButtonSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonSave.UseVisualStyleBackColor = False
        '
        'FindRujukanTACC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(694, 494)
        Me.ControlBox = False
        Me.Controls.Add(Me.SplitContainerPencarianData)
        Me.Controls.Add(Me.PanelTop)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FindRujukanTACC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.PanelTop.ResumeLayout(False)
        Me.PanelHeader.ResumeLayout(False)
        Me.PanelHeader.PerformLayout()
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.ResumeLayout(False)
        Me.PanelKeadaanUmumMenuPemeriksaanAwal.PerformLayout()
        Me.SplitContainerPencarianData.Panel1.ResumeLayout(False)
        Me.SplitContainerPencarianData.Panel2.ResumeLayout(False)
        Me.SplitContainerPencarianData.ResumeLayout(False)
        Me.SplitContainerRujukanTACC.Panel1.ResumeLayout(False)
        Me.SplitContainerRujukanTACC.Panel2.ResumeLayout(False)
        Me.SplitContainerRujukanTACC.ResumeLayout(False)
        Me.SplitContainerDetailTACC.Panel1.ResumeLayout(False)
        Me.SplitContainerDetailTACC.Panel2.ResumeLayout(False)
        Me.SplitContainerDetailTACC.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TabControlRujukanTACC.ResumeLayout(False)
        Me.TabPageTime.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.TabPageAge.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.TabPageComplication.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.TabPageComorbidity.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents PanelHeader As System.Windows.Forms.Panel
    Friend WithEvents SplitContainerPencarianData As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainerRujukanTACC As System.Windows.Forms.SplitContainer
    Friend WithEvents ButtonSave As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents RadioButtonComplication As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonComorbidity As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonTime As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonAge As System.Windows.Forms.RadioButton
    Friend WithEvents PanelKeadaanUmumMenuPemeriksaanAwal As System.Windows.Forms.Panel
    Friend WithEvents RadioButtonTanpaTACC As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonTACC As System.Windows.Forms.RadioButton
    Friend WithEvents SplitContainerDetailTACC As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TabControlRujukanTACC As System.Windows.Forms.TabControl
    Friend WithEvents TabPageTime As System.Windows.Forms.TabPage
    Friend WithEvents TabPageAge As System.Windows.Forms.TabPage
    Friend WithEvents TabPageComplication As System.Windows.Forms.TabPage
    Friend WithEvents TabPageComorbidity As System.Windows.Forms.TabPage
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents RadioButtonTimeOption3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonTimeOption1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonTimeOption2 As System.Windows.Forms.RadioButton
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents RadioButtonAgeOption6 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonAgeOption4 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonAgeOption5 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonAgeOption3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonAgeOption1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonAgeOption2 As System.Windows.Forms.RadioButton
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label203 As System.Windows.Forms.Label
    Friend WithEvents TextBoxKodeDiagnosaComplication As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxKeteranganDiagnosaComplication As System.Windows.Forms.TextBox
    Friend WithEvents ButtonFindDiagnosaComplication As System.Windows.Forms.Button
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ButtonFindDiagnosaComorbidity As System.Windows.Forms.Button
    Friend WithEvents TextBoxKeteranganDiagnosaComorbidity As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxKodeDiagnosaComorbidity As System.Windows.Forms.TextBox
End Class
