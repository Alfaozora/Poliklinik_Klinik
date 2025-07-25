<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FindFaskesRujukan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FindFaskesRujukan))
        Me.GridControlPencarian = New DevExpress.XtraGrid.GridControl
        Me.GridViewPencarian = New DevExpress.XtraGrid.Views.Grid.GridView
        Me.PanelTop = New System.Windows.Forms.Panel
        Me.btnClose = New System.Windows.Forms.Button
        Me.SplitContainerFaskesRujukan = New System.Windows.Forms.SplitContainer
        Me.TabControlRujukan = New System.Windows.Forms.TabControl
        Me.TabPageRujukanVertikal = New System.Windows.Forms.TabPage
        Me.SplitContainerRujukanVertikal = New System.Windows.Forms.SplitContainer
        Me.Panel28 = New System.Windows.Forms.Panel
        Me.RadioButtonRujukanKondisiKhusus = New System.Windows.Forms.RadioButton
        Me.RadioButtonRujukanSpesialis = New System.Windows.Forms.RadioButton
        Me.TabControlRujukanVertikal = New System.Windows.Forms.TabControl
        Me.TabRujukanKondisiKhusus = New System.Windows.Forms.TabPage
        Me.ComboBoxSpesialisKondisiKhusus = New System.Windows.Forms.ComboBox
        Me.LabelSpesialisKondisiKhusus = New System.Windows.Forms.Label
        Me.ButtonCariFaskesRujukanKondisiKhusus = New System.Windows.Forms.Button
        Me.Label165 = New System.Windows.Forms.Label
        Me.DateTimePickerKondisiKhusus = New System.Windows.Forms.DateTimePicker
        Me.TextBoxAlasanKondisiKhusus = New System.Windows.Forms.TextBox
        Me.Label118 = New System.Windows.Forms.Label
        Me.ComboBoxDaftarKondisiKhusus = New System.Windows.Forms.ComboBox
        Me.Label139 = New System.Windows.Forms.Label
        Me.TabRujukanSpesialis = New System.Windows.Forms.TabPage
        Me.ButtonCariFaskesRujukanSpesialis = New System.Windows.Forms.Button
        Me.Label169 = New System.Windows.Forms.Label
        Me.DateTimePickerSpesialis = New System.Windows.Forms.DateTimePicker
        Me.ComboBoxDaftarSarana = New System.Windows.Forms.ComboBox
        Me.CheckBoxStatusSarana = New System.Windows.Forms.CheckBox
        Me.ComboBoxDaftarSubSpesialis = New System.Windows.Forms.ComboBox
        Me.Label168 = New System.Windows.Forms.Label
        Me.ComboBoxDaftarSpesialis = New System.Windows.Forms.ComboBox
        Me.Label167 = New System.Windows.Forms.Label
        Me.TabPageRujukanHorizontal = New System.Windows.Forms.TabPage
        Me.Label166 = New System.Windows.Forms.Label
        CType(Me.GridControlPencarian, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewPencarian, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelTop.SuspendLayout()
        Me.SplitContainerFaskesRujukan.Panel1.SuspendLayout()
        Me.SplitContainerFaskesRujukan.Panel2.SuspendLayout()
        Me.SplitContainerFaskesRujukan.SuspendLayout()
        Me.TabControlRujukan.SuspendLayout()
        Me.TabPageRujukanVertikal.SuspendLayout()
        Me.SplitContainerRujukanVertikal.Panel1.SuspendLayout()
        Me.SplitContainerRujukanVertikal.Panel2.SuspendLayout()
        Me.SplitContainerRujukanVertikal.SuspendLayout()
        Me.Panel28.SuspendLayout()
        Me.TabControlRujukanVertikal.SuspendLayout()
        Me.TabRujukanKondisiKhusus.SuspendLayout()
        Me.TabRujukanSpesialis.SuspendLayout()
        Me.TabPageRujukanHorizontal.SuspendLayout()
        Me.SuspendLayout()
        '
        'GridControlPencarian
        '
        Me.GridControlPencarian.Cursor = System.Windows.Forms.Cursors.Hand
        Me.GridControlPencarian.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControlPencarian.EmbeddedNavigator.Name = ""
        Me.GridControlPencarian.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridControlPencarian.Location = New System.Drawing.Point(0, 0)
        Me.GridControlPencarian.MainView = Me.GridViewPencarian
        Me.GridControlPencarian.Name = "GridControlPencarian"
        Me.GridControlPencarian.Size = New System.Drawing.Size(1000, 235)
        Me.GridControlPencarian.TabIndex = 1
        Me.GridControlPencarian.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewPencarian})
        '
        'GridViewPencarian
        '
        Me.GridViewPencarian.GridControl = Me.GridControlPencarian
        Me.GridViewPencarian.Name = "GridViewPencarian"
        Me.GridViewPencarian.OptionsBehavior.Editable = False
        Me.GridViewPencarian.OptionsCustomization.AllowGroup = False
        Me.GridViewPencarian.OptionsView.ShowAutoFilterRow = True
        Me.GridViewPencarian.OptionsView.ShowGroupPanel = False
        Me.GridViewPencarian.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowForFocusedRow
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
        'SplitContainerFaskesRujukan
        '
        Me.SplitContainerFaskesRujukan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerFaskesRujukan.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainerFaskesRujukan.IsSplitterFixed = True
        Me.SplitContainerFaskesRujukan.Location = New System.Drawing.Point(0, 35)
        Me.SplitContainerFaskesRujukan.Name = "SplitContainerFaskesRujukan"
        Me.SplitContainerFaskesRujukan.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerFaskesRujukan.Panel1
        '
        Me.SplitContainerFaskesRujukan.Panel1.Controls.Add(Me.TabControlRujukan)
        '
        'SplitContainerFaskesRujukan.Panel2
        '
        Me.SplitContainerFaskesRujukan.Panel2.AutoScroll = True
        Me.SplitContainerFaskesRujukan.Panel2.Controls.Add(Me.GridControlPencarian)
        Me.SplitContainerFaskesRujukan.Size = New System.Drawing.Size(1000, 465)
        Me.SplitContainerFaskesRujukan.SplitterDistance = 225
        Me.SplitContainerFaskesRujukan.SplitterWidth = 5
        Me.SplitContainerFaskesRujukan.TabIndex = 460
        '
        'TabControlRujukan
        '
        Me.TabControlRujukan.Controls.Add(Me.TabPageRujukanVertikal)
        Me.TabControlRujukan.Controls.Add(Me.TabPageRujukanHorizontal)
        Me.TabControlRujukan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlRujukan.ItemSize = New System.Drawing.Size(200, 30)
        Me.TabControlRujukan.Location = New System.Drawing.Point(0, 0)
        Me.TabControlRujukan.Name = "TabControlRujukan"
        Me.TabControlRujukan.SelectedIndex = 0
        Me.TabControlRujukan.Size = New System.Drawing.Size(1000, 225)
        Me.TabControlRujukan.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControlRujukan.TabIndex = 466
        '
        'TabPageRujukanVertikal
        '
        Me.TabPageRujukanVertikal.AutoScroll = True
        Me.TabPageRujukanVertikal.Controls.Add(Me.SplitContainerRujukanVertikal)
        Me.TabPageRujukanVertikal.Location = New System.Drawing.Point(4, 34)
        Me.TabPageRujukanVertikal.Name = "TabPageRujukanVertikal"
        Me.TabPageRujukanVertikal.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageRujukanVertikal.Size = New System.Drawing.Size(992, 187)
        Me.TabPageRujukanVertikal.TabIndex = 1
        Me.TabPageRujukanVertikal.Text = "Rujukan Vertikal"
        Me.TabPageRujukanVertikal.UseVisualStyleBackColor = True
        '
        'SplitContainerRujukanVertikal
        '
        Me.SplitContainerRujukanVertikal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerRujukanVertikal.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainerRujukanVertikal.IsSplitterFixed = True
        Me.SplitContainerRujukanVertikal.Location = New System.Drawing.Point(3, 3)
        Me.SplitContainerRujukanVertikal.Name = "SplitContainerRujukanVertikal"
        Me.SplitContainerRujukanVertikal.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerRujukanVertikal.Panel1
        '
        Me.SplitContainerRujukanVertikal.Panel1.Controls.Add(Me.Panel28)
        '
        'SplitContainerRujukanVertikal.Panel2
        '
        Me.SplitContainerRujukanVertikal.Panel2.AutoScroll = True
        Me.SplitContainerRujukanVertikal.Panel2.Controls.Add(Me.TabControlRujukanVertikal)
        Me.SplitContainerRujukanVertikal.Size = New System.Drawing.Size(986, 181)
        Me.SplitContainerRujukanVertikal.SplitterDistance = 30
        Me.SplitContainerRujukanVertikal.SplitterWidth = 5
        Me.SplitContainerRujukanVertikal.TabIndex = 455
        '
        'Panel28
        '
        Me.Panel28.BackColor = System.Drawing.Color.FromArgb(CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(240, Byte), Integer))
        Me.Panel28.Controls.Add(Me.RadioButtonRujukanKondisiKhusus)
        Me.Panel28.Controls.Add(Me.RadioButtonRujukanSpesialis)
        Me.Panel28.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel28.Location = New System.Drawing.Point(0, 0)
        Me.Panel28.Name = "Panel28"
        Me.Panel28.Size = New System.Drawing.Size(986, 30)
        Me.Panel28.TabIndex = 453
        '
        'RadioButtonRujukanKondisiKhusus
        '
        Me.RadioButtonRujukanKondisiKhusus.AutoSize = True
        Me.RadioButtonRujukanKondisiKhusus.Checked = True
        Me.RadioButtonRujukanKondisiKhusus.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonRujukanKondisiKhusus.Location = New System.Drawing.Point(21, 5)
        Me.RadioButtonRujukanKondisiKhusus.Name = "RadioButtonRujukanKondisiKhusus"
        Me.RadioButtonRujukanKondisiKhusus.Size = New System.Drawing.Size(114, 21)
        Me.RadioButtonRujukanKondisiKhusus.TabIndex = 247
        Me.RadioButtonRujukanKondisiKhusus.TabStop = True
        Me.RadioButtonRujukanKondisiKhusus.Text = "Kondisi Khusus"
        Me.RadioButtonRujukanKondisiKhusus.UseVisualStyleBackColor = True
        '
        'RadioButtonRujukanSpesialis
        '
        Me.RadioButtonRujukanSpesialis.AutoSize = True
        Me.RadioButtonRujukanSpesialis.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonRujukanSpesialis.Location = New System.Drawing.Point(150, 5)
        Me.RadioButtonRujukanSpesialis.Name = "RadioButtonRujukanSpesialis"
        Me.RadioButtonRujukanSpesialis.Size = New System.Drawing.Size(76, 21)
        Me.RadioButtonRujukanSpesialis.TabIndex = 248
        Me.RadioButtonRujukanSpesialis.TabStop = True
        Me.RadioButtonRujukanSpesialis.Text = "Spesialis"
        Me.RadioButtonRujukanSpesialis.UseVisualStyleBackColor = True
        '
        'TabControlRujukanVertikal
        '
        Me.TabControlRujukanVertikal.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.TabControlRujukanVertikal.Controls.Add(Me.TabRujukanKondisiKhusus)
        Me.TabControlRujukanVertikal.Controls.Add(Me.TabRujukanSpesialis)
        Me.TabControlRujukanVertikal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlRujukanVertikal.ItemSize = New System.Drawing.Size(125, 25)
        Me.TabControlRujukanVertikal.Location = New System.Drawing.Point(0, 0)
        Me.TabControlRujukanVertikal.Name = "TabControlRujukanVertikal"
        Me.TabControlRujukanVertikal.SelectedIndex = 0
        Me.TabControlRujukanVertikal.Size = New System.Drawing.Size(986, 146)
        Me.TabControlRujukanVertikal.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
        Me.TabControlRujukanVertikal.TabIndex = 0
        '
        'TabRujukanKondisiKhusus
        '
        Me.TabRujukanKondisiKhusus.AutoScroll = True
        Me.TabRujukanKondisiKhusus.BackColor = System.Drawing.Color.White
        Me.TabRujukanKondisiKhusus.Controls.Add(Me.ComboBoxSpesialisKondisiKhusus)
        Me.TabRujukanKondisiKhusus.Controls.Add(Me.LabelSpesialisKondisiKhusus)
        Me.TabRujukanKondisiKhusus.Controls.Add(Me.ButtonCariFaskesRujukanKondisiKhusus)
        Me.TabRujukanKondisiKhusus.Controls.Add(Me.Label165)
        Me.TabRujukanKondisiKhusus.Controls.Add(Me.DateTimePickerKondisiKhusus)
        Me.TabRujukanKondisiKhusus.Controls.Add(Me.TextBoxAlasanKondisiKhusus)
        Me.TabRujukanKondisiKhusus.Controls.Add(Me.Label118)
        Me.TabRujukanKondisiKhusus.Controls.Add(Me.ComboBoxDaftarKondisiKhusus)
        Me.TabRujukanKondisiKhusus.Controls.Add(Me.Label139)
        Me.TabRujukanKondisiKhusus.Location = New System.Drawing.Point(4, 29)
        Me.TabRujukanKondisiKhusus.Name = "TabRujukanKondisiKhusus"
        Me.TabRujukanKondisiKhusus.Padding = New System.Windows.Forms.Padding(3)
        Me.TabRujukanKondisiKhusus.Size = New System.Drawing.Size(978, 113)
        Me.TabRujukanKondisiKhusus.TabIndex = 0
        Me.TabRujukanKondisiKhusus.Text = "Kondisi Khusus"
        Me.TabRujukanKondisiKhusus.UseVisualStyleBackColor = True
        '
        'ComboBoxSpesialisKondisiKhusus
        '
        Me.ComboBoxSpesialisKondisiKhusus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxSpesialisKondisiKhusus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.ComboBoxSpesialisKondisiKhusus.DropDownHeight = 100
        Me.ComboBoxSpesialisKondisiKhusus.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBoxSpesialisKondisiKhusus.FormattingEnabled = True
        Me.ComboBoxSpesialisKondisiKhusus.IntegralHeight = False
        Me.ComboBoxSpesialisKondisiKhusus.Location = New System.Drawing.Point(103, 38)
        Me.ComboBoxSpesialisKondisiKhusus.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxSpesialisKondisiKhusus.Name = "ComboBoxSpesialisKondisiKhusus"
        Me.ComboBoxSpesialisKondisiKhusus.Size = New System.Drawing.Size(200, 25)
        Me.ComboBoxSpesialisKondisiKhusus.TabIndex = 509
        '
        'LabelSpesialisKondisiKhusus
        '
        Me.LabelSpesialisKondisiKhusus.AutoSize = True
        Me.LabelSpesialisKondisiKhusus.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LabelSpesialisKondisiKhusus.Location = New System.Drawing.Point(31, 41)
        Me.LabelSpesialisKondisiKhusus.Name = "LabelSpesialisKondisiKhusus"
        Me.LabelSpesialisKondisiKhusus.Size = New System.Drawing.Size(58, 17)
        Me.LabelSpesialisKondisiKhusus.TabIndex = 508
        Me.LabelSpesialisKondisiKhusus.Text = "Spesialis"
        '
        'ButtonCariFaskesRujukanKondisiKhusus
        '
        Me.ButtonCariFaskesRujukanKondisiKhusus.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCariFaskesRujukanKondisiKhusus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonCariFaskesRujukanKondisiKhusus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonCariFaskesRujukanKondisiKhusus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCariFaskesRujukanKondisiKhusus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonCariFaskesRujukanKondisiKhusus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCariFaskesRujukanKondisiKhusus.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCariFaskesRujukanKondisiKhusus.ForeColor = System.Drawing.Color.White
        Me.ButtonCariFaskesRujukanKondisiKhusus.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_search_16
        Me.ButtonCariFaskesRujukanKondisiKhusus.Location = New System.Drawing.Point(445, 37)
        Me.ButtonCariFaskesRujukanKondisiKhusus.Name = "ButtonCariFaskesRujukanKondisiKhusus"
        Me.ButtonCariFaskesRujukanKondisiKhusus.Size = New System.Drawing.Size(160, 30)
        Me.ButtonCariFaskesRujukanKondisiKhusus.TabIndex = 513
        Me.ButtonCariFaskesRujukanKondisiKhusus.Text = " Cari Faskes Rujukan"
        Me.ButtonCariFaskesRujukanKondisiKhusus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonCariFaskesRujukanKondisiKhusus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonCariFaskesRujukanKondisiKhusus.UseVisualStyleBackColor = False
        '
        'Label165
        '
        Me.Label165.AutoSize = True
        Me.Label165.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label165.Location = New System.Drawing.Point(348, 2)
        Me.Label165.Name = "Label165"
        Me.Label165.Size = New System.Drawing.Size(83, 34)
        Me.Label165.TabIndex = 512
        Me.Label165.Text = "Tgl. Rencana" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Berkunjung"
        Me.Label165.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DateTimePickerKondisiKhusus
        '
        Me.DateTimePickerKondisiKhusus.CustomFormat = "dd-MMM-yyyy"
        Me.DateTimePickerKondisiKhusus.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.DateTimePickerKondisiKhusus.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerKondisiKhusus.Location = New System.Drawing.Point(445, 5)
        Me.DateTimePickerKondisiKhusus.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DateTimePickerKondisiKhusus.Name = "DateTimePickerKondisiKhusus"
        Me.DateTimePickerKondisiKhusus.Size = New System.Drawing.Size(160, 25)
        Me.DateTimePickerKondisiKhusus.TabIndex = 511
        '
        'TextBoxAlasanKondisiKhusus
        '
        Me.TextBoxAlasanKondisiKhusus.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.TextBoxAlasanKondisiKhusus.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBoxAlasanKondisiKhusus.Location = New System.Drawing.Point(103, 70)
        Me.TextBoxAlasanKondisiKhusus.Multiline = True
        Me.TextBoxAlasanKondisiKhusus.Name = "TextBoxAlasanKondisiKhusus"
        Me.TextBoxAlasanKondisiKhusus.Size = New System.Drawing.Size(200, 40)
        Me.TextBoxAlasanKondisiKhusus.TabIndex = 508
        '
        'Label118
        '
        Me.Label118.AutoSize = True
        Me.Label118.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label118.Location = New System.Drawing.Point(41, 73)
        Me.Label118.Name = "Label118"
        Me.Label118.Size = New System.Drawing.Size(48, 17)
        Me.Label118.TabIndex = 506
        Me.Label118.Text = "Alasan"
        '
        'ComboBoxDaftarKondisiKhusus
        '
        Me.ComboBoxDaftarKondisiKhusus.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxDaftarKondisiKhusus.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.ComboBoxDaftarKondisiKhusus.DropDownHeight = 100
        Me.ComboBoxDaftarKondisiKhusus.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBoxDaftarKondisiKhusus.FormattingEnabled = True
        Me.ComboBoxDaftarKondisiKhusus.IntegralHeight = False
        Me.ComboBoxDaftarKondisiKhusus.ItemHeight = 17
        Me.ComboBoxDaftarKondisiKhusus.Location = New System.Drawing.Point(103, 5)
        Me.ComboBoxDaftarKondisiKhusus.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxDaftarKondisiKhusus.Name = "ComboBoxDaftarKondisiKhusus"
        Me.ComboBoxDaftarKondisiKhusus.Size = New System.Drawing.Size(200, 25)
        Me.ComboBoxDaftarKondisiKhusus.TabIndex = 505
        '
        'Label139
        '
        Me.Label139.AutoSize = True
        Me.Label139.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label139.Location = New System.Drawing.Point(30, 8)
        Me.Label139.Name = "Label139"
        Me.Label139.Size = New System.Drawing.Size(59, 17)
        Me.Label139.TabIndex = 504
        Me.Label139.Text = "Kategori"
        '
        'TabRujukanSpesialis
        '
        Me.TabRujukanSpesialis.AutoScroll = True
        Me.TabRujukanSpesialis.BackColor = System.Drawing.Color.White
        Me.TabRujukanSpesialis.Controls.Add(Me.ButtonCariFaskesRujukanSpesialis)
        Me.TabRujukanSpesialis.Controls.Add(Me.Label169)
        Me.TabRujukanSpesialis.Controls.Add(Me.DateTimePickerSpesialis)
        Me.TabRujukanSpesialis.Controls.Add(Me.ComboBoxDaftarSarana)
        Me.TabRujukanSpesialis.Controls.Add(Me.CheckBoxStatusSarana)
        Me.TabRujukanSpesialis.Controls.Add(Me.ComboBoxDaftarSubSpesialis)
        Me.TabRujukanSpesialis.Controls.Add(Me.Label168)
        Me.TabRujukanSpesialis.Controls.Add(Me.ComboBoxDaftarSpesialis)
        Me.TabRujukanSpesialis.Controls.Add(Me.Label167)
        Me.TabRujukanSpesialis.Location = New System.Drawing.Point(4, 29)
        Me.TabRujukanSpesialis.Name = "TabRujukanSpesialis"
        Me.TabRujukanSpesialis.Padding = New System.Windows.Forms.Padding(3)
        Me.TabRujukanSpesialis.Size = New System.Drawing.Size(978, 118)
        Me.TabRujukanSpesialis.TabIndex = 1
        Me.TabRujukanSpesialis.Text = "Spesialis"
        Me.TabRujukanSpesialis.UseVisualStyleBackColor = True
        '
        'ButtonCariFaskesRujukanSpesialis
        '
        Me.ButtonCariFaskesRujukanSpesialis.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCariFaskesRujukanSpesialis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonCariFaskesRujukanSpesialis.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonCariFaskesRujukanSpesialis.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCariFaskesRujukanSpesialis.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonCariFaskesRujukanSpesialis.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCariFaskesRujukanSpesialis.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCariFaskesRujukanSpesialis.ForeColor = System.Drawing.Color.White
        Me.ButtonCariFaskesRujukanSpesialis.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_search_16
        Me.ButtonCariFaskesRujukanSpesialis.Location = New System.Drawing.Point(445, 37)
        Me.ButtonCariFaskesRujukanSpesialis.Name = "ButtonCariFaskesRujukanSpesialis"
        Me.ButtonCariFaskesRujukanSpesialis.Size = New System.Drawing.Size(160, 30)
        Me.ButtonCariFaskesRujukanSpesialis.TabIndex = 516
        Me.ButtonCariFaskesRujukanSpesialis.Text = " Cari Faskes Rujukan"
        Me.ButtonCariFaskesRujukanSpesialis.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonCariFaskesRujukanSpesialis.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonCariFaskesRujukanSpesialis.UseVisualStyleBackColor = False
        '
        'Label169
        '
        Me.Label169.AutoSize = True
        Me.Label169.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label169.Location = New System.Drawing.Point(348, 2)
        Me.Label169.Name = "Label169"
        Me.Label169.Size = New System.Drawing.Size(83, 34)
        Me.Label169.TabIndex = 515
        Me.Label169.Text = "Tgl. Rencana" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Berkunjung"
        Me.Label169.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DateTimePickerSpesialis
        '
        Me.DateTimePickerSpesialis.CustomFormat = "dd-MMM-yyyy"
        Me.DateTimePickerSpesialis.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.DateTimePickerSpesialis.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerSpesialis.Location = New System.Drawing.Point(445, 5)
        Me.DateTimePickerSpesialis.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.DateTimePickerSpesialis.Name = "DateTimePickerSpesialis"
        Me.DateTimePickerSpesialis.Size = New System.Drawing.Size(160, 25)
        Me.DateTimePickerSpesialis.TabIndex = 514
        '
        'ComboBoxDaftarSarana
        '
        Me.ComboBoxDaftarSarana.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxDaftarSarana.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.ComboBoxDaftarSarana.DropDownHeight = 100
        Me.ComboBoxDaftarSarana.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBoxDaftarSarana.FormattingEnabled = True
        Me.ComboBoxDaftarSarana.IntegralHeight = False
        Me.ComboBoxDaftarSarana.Location = New System.Drawing.Point(103, 71)
        Me.ComboBoxDaftarSarana.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxDaftarSarana.Name = "ComboBoxDaftarSarana"
        Me.ComboBoxDaftarSarana.Size = New System.Drawing.Size(200, 25)
        Me.ComboBoxDaftarSarana.TabIndex = 511
        Me.ComboBoxDaftarSarana.Visible = False
        '
        'CheckBoxStatusSarana
        '
        Me.CheckBoxStatusSarana.AutoSize = True
        Me.CheckBoxStatusSarana.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.CheckBoxStatusSarana.Location = New System.Drawing.Point(20, 73)
        Me.CheckBoxStatusSarana.Name = "CheckBoxStatusSarana"
        Me.CheckBoxStatusSarana.Size = New System.Drawing.Size(68, 21)
        Me.CheckBoxStatusSarana.TabIndex = 510
        Me.CheckBoxStatusSarana.Text = "Sarana"
        Me.CheckBoxStatusSarana.UseVisualStyleBackColor = True
        '
        'ComboBoxDaftarSubSpesialis
        '
        Me.ComboBoxDaftarSubSpesialis.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxDaftarSubSpesialis.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.ComboBoxDaftarSubSpesialis.DropDownHeight = 100
        Me.ComboBoxDaftarSubSpesialis.DropDownWidth = 200
        Me.ComboBoxDaftarSubSpesialis.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBoxDaftarSubSpesialis.FormattingEnabled = True
        Me.ComboBoxDaftarSubSpesialis.IntegralHeight = False
        Me.ComboBoxDaftarSubSpesialis.Location = New System.Drawing.Point(103, 38)
        Me.ComboBoxDaftarSubSpesialis.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxDaftarSubSpesialis.Name = "ComboBoxDaftarSubSpesialis"
        Me.ComboBoxDaftarSubSpesialis.Size = New System.Drawing.Size(200, 25)
        Me.ComboBoxDaftarSubSpesialis.TabIndex = 509
        '
        'Label168
        '
        Me.Label168.AutoSize = True
        Me.Label168.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label168.Location = New System.Drawing.Point(3, 41)
        Me.Label168.Name = "Label168"
        Me.Label168.Size = New System.Drawing.Size(85, 17)
        Me.Label168.TabIndex = 508
        Me.Label168.Text = "Sub Spesialis"
        '
        'ComboBoxDaftarSpesialis
        '
        Me.ComboBoxDaftarSpesialis.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboBoxDaftarSpesialis.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.ComboBoxDaftarSpesialis.DropDownHeight = 100
        Me.ComboBoxDaftarSpesialis.DropDownWidth = 200
        Me.ComboBoxDaftarSpesialis.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.ComboBoxDaftarSpesialis.FormattingEnabled = True
        Me.ComboBoxDaftarSpesialis.IntegralHeight = False
        Me.ComboBoxDaftarSpesialis.Location = New System.Drawing.Point(103, 5)
        Me.ComboBoxDaftarSpesialis.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.ComboBoxDaftarSpesialis.Name = "ComboBoxDaftarSpesialis"
        Me.ComboBoxDaftarSpesialis.Size = New System.Drawing.Size(200, 25)
        Me.ComboBoxDaftarSpesialis.TabIndex = 507
        '
        'Label167
        '
        Me.Label167.AutoSize = True
        Me.Label167.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label167.Location = New System.Drawing.Point(30, 8)
        Me.Label167.Name = "Label167"
        Me.Label167.Size = New System.Drawing.Size(58, 17)
        Me.Label167.TabIndex = 506
        Me.Label167.Text = "Spesialis"
        '
        'TabPageRujukanHorizontal
        '
        Me.TabPageRujukanHorizontal.AutoScroll = True
        Me.TabPageRujukanHorizontal.Controls.Add(Me.Label166)
        Me.TabPageRujukanHorizontal.Location = New System.Drawing.Point(4, 34)
        Me.TabPageRujukanHorizontal.Name = "TabPageRujukanHorizontal"
        Me.TabPageRujukanHorizontal.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPageRujukanHorizontal.Size = New System.Drawing.Size(992, 187)
        Me.TabPageRujukanHorizontal.TabIndex = 0
        Me.TabPageRujukanHorizontal.Text = "Rujukan Horizontal"
        Me.TabPageRujukanHorizontal.UseVisualStyleBackColor = True
        '
        'Label166
        '
        Me.Label166.AutoSize = True
        Me.Label166.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label166.Location = New System.Drawing.Point(12, 29)
        Me.Label166.Name = "Label166"
        Me.Label166.Size = New System.Drawing.Size(117, 17)
        Me.Label166.TabIndex = 505
        Me.Label166.Text = "COMING SOON....."
        '
        'FindFaskesRujukan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1000, 500)
        Me.ControlBox = False
        Me.Controls.Add(Me.SplitContainerFaskesRujukan)
        Me.Controls.Add(Me.PanelTop)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FindFaskesRujukan"
        CType(Me.GridControlPencarian, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewPencarian, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelTop.ResumeLayout(False)
        Me.SplitContainerFaskesRujukan.Panel1.ResumeLayout(False)
        Me.SplitContainerFaskesRujukan.Panel2.ResumeLayout(False)
        Me.SplitContainerFaskesRujukan.ResumeLayout(False)
        Me.TabControlRujukan.ResumeLayout(False)
        Me.TabPageRujukanVertikal.ResumeLayout(False)
        Me.SplitContainerRujukanVertikal.Panel1.ResumeLayout(False)
        Me.SplitContainerRujukanVertikal.Panel2.ResumeLayout(False)
        Me.SplitContainerRujukanVertikal.ResumeLayout(False)
        Me.Panel28.ResumeLayout(False)
        Me.Panel28.PerformLayout()
        Me.TabControlRujukanVertikal.ResumeLayout(False)
        Me.TabRujukanKondisiKhusus.ResumeLayout(False)
        Me.TabRujukanKondisiKhusus.PerformLayout()
        Me.TabRujukanSpesialis.ResumeLayout(False)
        Me.TabRujukanSpesialis.PerformLayout()
        Me.TabPageRujukanHorizontal.ResumeLayout(False)
        Me.TabPageRujukanHorizontal.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents GridViewPencarian As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents GridControlPencarian As DevExpress.XtraGrid.GridControl
    Friend WithEvents SplitContainerFaskesRujukan As System.Windows.Forms.SplitContainer
    Friend WithEvents TabControlRujukan As System.Windows.Forms.TabControl
    Friend WithEvents TabPageRujukanVertikal As System.Windows.Forms.TabPage
    Friend WithEvents SplitContainerRujukanVertikal As System.Windows.Forms.SplitContainer
    Friend WithEvents Panel28 As System.Windows.Forms.Panel
    Friend WithEvents RadioButtonRujukanKondisiKhusus As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonRujukanSpesialis As System.Windows.Forms.RadioButton
    Friend WithEvents TabControlRujukanVertikal As System.Windows.Forms.TabControl
    Friend WithEvents TabRujukanKondisiKhusus As System.Windows.Forms.TabPage
    Friend WithEvents ComboBoxSpesialisKondisiKhusus As System.Windows.Forms.ComboBox
    Friend WithEvents LabelSpesialisKondisiKhusus As System.Windows.Forms.Label
    Friend WithEvents ButtonCariFaskesRujukanKondisiKhusus As System.Windows.Forms.Button
    Friend WithEvents Label165 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerKondisiKhusus As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextBoxAlasanKondisiKhusus As System.Windows.Forms.TextBox
    Friend WithEvents Label118 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxDaftarKondisiKhusus As System.Windows.Forms.ComboBox
    Friend WithEvents Label139 As System.Windows.Forms.Label
    Friend WithEvents TabRujukanSpesialis As System.Windows.Forms.TabPage
    Friend WithEvents ButtonCariFaskesRujukanSpesialis As System.Windows.Forms.Button
    Friend WithEvents Label169 As System.Windows.Forms.Label
    Friend WithEvents DateTimePickerSpesialis As System.Windows.Forms.DateTimePicker
    Friend WithEvents ComboBoxDaftarSarana As System.Windows.Forms.ComboBox
    Friend WithEvents CheckBoxStatusSarana As System.Windows.Forms.CheckBox
    Friend WithEvents ComboBoxDaftarSubSpesialis As System.Windows.Forms.ComboBox
    Friend WithEvents Label168 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxDaftarSpesialis As System.Windows.Forms.ComboBox
    Friend WithEvents Label167 As System.Windows.Forms.Label
    Friend WithEvents TabPageRujukanHorizontal As System.Windows.Forms.TabPage
    Friend WithEvents Label166 As System.Windows.Forms.Label
End Class
