<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dashboard
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
        Dim ChartArea25 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea
        Dim Legend25 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend
        Dim Series25 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series
        Dim ChartArea26 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea
        Dim Legend26 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend
        Dim Series26 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dashboard))
        Dim ChartArea27 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea
        Dim Legend27 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend
        Dim Series27 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart
        Me.DateTimePickerAkhir = New System.Windows.Forms.DateTimePicker
        Me.DateTimePickerAwal = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Chart2 = New System.Windows.Forms.DataVisualization.Charting.Chart
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.LabelPoliUmum = New System.Windows.Forms.Label
        Me.Panel8 = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label7 = New System.Windows.Forms.Label
        Me.LabelPoliGigi = New System.Windows.Forms.Label
        Me.Panel10 = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.LabelPoliKia = New System.Windows.Forms.Label
        Me.Panel5 = New System.Windows.Forms.Panel
        Me.LabelPoliKb = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.LabelLab = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.LabelTittlePoli = New System.Windows.Forms.Label
        Me.Chart3 = New System.Windows.Forms.DataVisualization.Charting.Chart
        Me.PanelTop = New System.Windows.Forms.Panel
        Me.ButtonClose = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label1Diagnosa = New System.Windows.Forms.Label
        Me.Panel6 = New System.Windows.Forms.Panel
        Me.LabelPasien = New System.Windows.Forms.Label
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.Label12 = New System.Windows.Forms.Label
        Me.Panel9 = New System.Windows.Forms.Panel
        Me.Panel11 = New System.Windows.Forms.Panel
        Me.Panel12 = New System.Windows.Forms.Panel
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.Chart3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelTop.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'Chart1
        '
        ChartArea25.AxisX.Interval = 1
        ChartArea25.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea25)
        Legend25.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend25)
        Me.Chart1.Location = New System.Drawing.Point(112, 371)
        Me.Chart1.Name = "Chart1"
        Me.Chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent
        Series25.ChartArea = "ChartArea1"
        Series25.CustomProperties = "PointWidth=0.5"
        Series25.Legend = "Legend1"
        Series25.Name = "Series1"
        Me.Chart1.Series.Add(Series25)
        Me.Chart1.Size = New System.Drawing.Size(351, 241)
        Me.Chart1.TabIndex = 14
        Me.Chart1.Text = "Chart1"
        '
        'DateTimePickerAkhir
        '
        Me.DateTimePickerAkhir.CalendarFont = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerAkhir.CustomFormat = "dd-MMM-yyyy"
        Me.DateTimePickerAkhir.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerAkhir.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerAkhir.Location = New System.Drawing.Point(288, 347)
        Me.DateTimePickerAkhir.Name = "DateTimePickerAkhir"
        Me.DateTimePickerAkhir.Size = New System.Drawing.Size(125, 25)
        Me.DateTimePickerAkhir.TabIndex = 528
        '
        'DateTimePickerAwal
        '
        Me.DateTimePickerAwal.CalendarFont = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerAwal.CustomFormat = "dd-MMM-yyyy"
        Me.DateTimePickerAwal.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePickerAwal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePickerAwal.Location = New System.Drawing.Point(157, 347)
        Me.DateTimePickerAwal.Name = "DateTimePickerAwal"
        Me.DateTimePickerAwal.Size = New System.Drawing.Size(125, 25)
        Me.DateTimePickerAwal.TabIndex = 527
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(172, 310)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(193, 21)
        Me.Label1.TabIndex = 529
        Me.Label1.Text = "Status Pemeriksaan Poli"
        '
        'Chart2
        '
        ChartArea26.AxisX.Interval = 1
        ChartArea26.Name = "ChartArea1"
        Me.Chart2.ChartAreas.Add(ChartArea26)
        Legend26.Name = "Legend1"
        Me.Chart2.Legends.Add(Legend26)
        Me.Chart2.Location = New System.Drawing.Point(29, 41)
        Me.Chart2.Name = "Chart2"
        Me.Chart2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent
        Series26.ChartArea = "ChartArea1"
        Series26.CustomProperties = "PointWidth=0.5"
        Series26.Legend = "Legend1"
        Series26.Name = "Series1"
        Me.Chart2.Series.Add(Series26)
        Me.Chart2.Size = New System.Drawing.Size(582, 248)
        Me.Chart2.TabIndex = 530
        Me.Chart2.Text = "Chart2"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.LabelPoliUmum)
        Me.Panel1.Controls.Add(Me.Panel8)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(669, 85)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(284, 121)
        Me.Panel1.TabIndex = 531
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(127, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 21)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Poli Kecantikan"
        Me.Label3.Visible = False
        '
        'LabelPoliUmum
        '
        Me.LabelPoliUmum.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelPoliUmum.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPoliUmum.Location = New System.Drawing.Point(137, 36)
        Me.LabelPoliUmum.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelPoliUmum.Name = "LabelPoliUmum"
        Me.LabelPoliUmum.Size = New System.Drawing.Size(87, 69)
        Me.LabelPoliUmum.TabIndex = 1
        Me.LabelPoliUmum.Text = "11"
        Me.LabelPoliUmum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.PeachPuff
        Me.Panel8.BackgroundImage = CType(resources.GetObject("Panel8.BackgroundImage"), System.Drawing.Image)
        Me.Panel8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Panel8.Location = New System.Drawing.Point(0, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(88, 121)
        Me.Panel8.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(136, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(87, 21)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Poli Umum"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.LabelPoliGigi)
        Me.Panel2.Controls.Add(Me.Panel10)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Location = New System.Drawing.Point(669, 212)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(284, 121)
        Me.Panel2.TabIndex = 532
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(136, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 21)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Poli HBOT"
        Me.Label7.Visible = False
        '
        'LabelPoliGigi
        '
        Me.LabelPoliGigi.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelPoliGigi.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPoliGigi.Location = New System.Drawing.Point(140, 39)
        Me.LabelPoliGigi.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelPoliGigi.Name = "LabelPoliGigi"
        Me.LabelPoliGigi.Size = New System.Drawing.Size(87, 69)
        Me.LabelPoliGigi.TabIndex = 1
        Me.LabelPoliGigi.Text = "11"
        Me.LabelPoliGigi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.PeachPuff
        Me.Panel10.BackgroundImage = CType(resources.GetObject("Panel10.BackgroundImage"), System.Drawing.Image)
        Me.Panel10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Panel10.Location = New System.Drawing.Point(0, 0)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(88, 121)
        Me.Panel10.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(111, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(129, 21)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Poli Gigi && Mulut"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.LabelPoliKia)
        Me.Panel3.Location = New System.Drawing.Point(959, 85)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(284, 121)
        Me.Panel3.TabIndex = 533
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(150, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(62, 21)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Poli KIA"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(130, 15)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(111, 21)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Poli Fisioterapi"
        Me.Label8.Visible = False
        '
        'LabelPoliKia
        '
        Me.LabelPoliKia.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelPoliKia.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPoliKia.Location = New System.Drawing.Point(143, 36)
        Me.LabelPoliKia.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelPoliKia.Name = "LabelPoliKia"
        Me.LabelPoliKia.Size = New System.Drawing.Size(90, 69)
        Me.LabelPoliKia.TabIndex = 1
        Me.LabelPoliKia.Text = "11"
        Me.LabelPoliKia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel5.Controls.Add(Me.LabelPoliKb)
        Me.Panel5.Controls.Add(Me.Panel11)
        Me.Panel5.Controls.Add(Me.Label9)
        Me.Panel5.Location = New System.Drawing.Point(959, 212)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(284, 121)
        Me.Panel5.TabIndex = 534
        '
        'LabelPoliKb
        '
        Me.LabelPoliKb.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelPoliKb.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPoliKb.Location = New System.Drawing.Point(141, 38)
        Me.LabelPoliKb.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelPoliKb.Name = "LabelPoliKb"
        Me.LabelPoliKb.Size = New System.Drawing.Size(87, 69)
        Me.LabelPoliKb.TabIndex = 1
        Me.LabelPoliKb.Text = "11"
        Me.LabelPoliKb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(148, 17)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(57, 21)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Poli KB"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.LabelLab)
        Me.Panel4.Location = New System.Drawing.Point(669, 339)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(284, 121)
        Me.Panel4.TabIndex = 535
        '
        'LabelLab
        '
        Me.LabelLab.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelLab.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelLab.Location = New System.Drawing.Point(131, 38)
        Me.LabelLab.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelLab.Name = "LabelLab"
        Me.LabelLab.Size = New System.Drawing.Size(96, 69)
        Me.LabelLab.TabIndex = 1
        Me.LabelLab.Text = "11"
        Me.LabelLab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(127, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(105, 21)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Laboratorium"
        '
        'LabelTittlePoli
        '
        Me.LabelTittlePoli.AutoSize = True
        Me.LabelTittlePoli.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTittlePoli.Location = New System.Drawing.Point(656, 48)
        Me.LabelTittlePoli.Name = "LabelTittlePoli"
        Me.LabelTittlePoli.Size = New System.Drawing.Size(192, 21)
        Me.LabelTittlePoli.TabIndex = 536
        Me.LabelTittlePoli.Text = "Jumlah Kunjungan Poli "
        '
        'Chart3
        '
        Me.Chart3.BackColor = System.Drawing.Color.Transparent
        Me.Chart3.BackImageTransparentColor = System.Drawing.Color.Transparent
        Me.Chart3.BackSecondaryColor = System.Drawing.Color.Transparent
        Me.Chart3.BorderlineColor = System.Drawing.Color.Transparent
        ChartArea27.AxisX.Interval = 1
        ChartArea27.Name = "ChartArea1"
        Me.Chart3.ChartAreas.Add(ChartArea27)
        Legend27.Name = "Legend1"
        Me.Chart3.Legends.Add(Legend27)
        Me.Chart3.Location = New System.Drawing.Point(646, 520)
        Me.Chart3.Name = "Chart3"
        Me.Chart3.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent
        Series27.ChartArea = "ChartArea1"
        Series27.CustomProperties = "PointWidth=0.5"
        Series27.Legend = "Legend1"
        Series27.Name = "Series1"
        Me.Chart3.Series.Add(Series27)
        Me.Chart3.Size = New System.Drawing.Size(351, 248)
        Me.Chart3.TabIndex = 537
        Me.Chart3.Text = "Chart3"
        '
        'PanelTop
        '
        Me.PanelTop.AutoSize = True
        Me.PanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.PanelTop.Controls.Add(Me.ButtonClose)
        Me.PanelTop.Controls.Add(Me.Label10)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(1243, 38)
        Me.PanelTop.TabIndex = 538
        '
        'ButtonClose
        '
        Me.ButtonClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonClose.BackgroundImage = CType(resources.GetObject("ButtonClose.BackgroundImage"), System.Drawing.Image)
        Me.ButtonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonClose.FlatAppearance.BorderSize = 0
        Me.ButtonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonClose.Location = New System.Drawing.Point(1206, 2)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(33, 33)
        Me.ButtonClose.TabIndex = 539
        Me.ButtonClose.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(5, 6)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(109, 21)
        Me.Label10.TabIndex = 537
        Me.Label10.Text = "DASHBOARD"
        '
        'Label1Diagnosa
        '
        Me.Label1Diagnosa.AutoSize = True
        Me.Label1Diagnosa.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1Diagnosa.Location = New System.Drawing.Point(665, 483)
        Me.Label1Diagnosa.Name = "Label1Diagnosa"
        Me.Label1Diagnosa.Size = New System.Drawing.Size(192, 21)
        Me.Label1Diagnosa.TabIndex = 539
        Me.Label1Diagnosa.Text = "Jumlah Kunjungan Poli "
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel6.Controls.Add(Me.LabelPasien)
        Me.Panel6.Controls.Add(Me.Panel7)
        Me.Panel6.Controls.Add(Me.Label12)
        Me.Panel6.Location = New System.Drawing.Point(959, 339)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(284, 121)
        Me.Panel6.TabIndex = 536
        '
        'LabelPasien
        '
        Me.LabelPasien.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelPasien.Font = New System.Drawing.Font("Segoe UI", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPasien.Location = New System.Drawing.Point(122, 38)
        Me.LabelPasien.Margin = New System.Windows.Forms.Padding(0)
        Me.LabelPasien.Name = "LabelPasien"
        Me.LabelPasien.Size = New System.Drawing.Size(122, 69)
        Me.LabelPasien.TabIndex = 1
        Me.LabelPasien.Text = "11"
        Me.LabelPasien.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.PeachPuff
        Me.Panel7.BackgroundImage = CType(resources.GetObject("Panel7.BackgroundImage"), System.Drawing.Image)
        Me.Panel7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(88, 120)
        Me.Panel7.TabIndex = 0
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(105, 14)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(154, 21)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Pasien Baru Bulan Ini"
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.PeachPuff
        Me.Panel9.BackgroundImage = CType(resources.GetObject("Panel9.BackgroundImage"), System.Drawing.Image)
        Me.Panel9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Panel9.Location = New System.Drawing.Point(959, 85)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(88, 121)
        Me.Panel9.TabIndex = 2
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.PeachPuff
        Me.Panel11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Panel11.Location = New System.Drawing.Point(0, 0)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(88, 121)
        Me.Panel11.TabIndex = 3
        '
        'Panel12
        '
        Me.Panel12.BackColor = System.Drawing.Color.PeachPuff
        Me.Panel12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Panel12.Location = New System.Drawing.Point(669, 339)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(88, 121)
        Me.Panel12.TabIndex = 4
        '
        'Dashboard
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.AutoScroll = True
        Me.AutoSize = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1015, 803)
        Me.Controls.Add(Me.Panel12)
        Me.Controls.Add(Me.Panel9)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Label1Diagnosa)
        Me.Controls.Add(Me.PanelTop)
        Me.Controls.Add(Me.Chart3)
        Me.Controls.Add(Me.LabelTittlePoli)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Chart2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DateTimePickerAkhir)
        Me.Controls.Add(Me.DateTimePickerAwal)
        Me.Controls.Add(Me.Chart1)
        Me.Name = "Dashboard"
        Me.Text = "Dashboard"
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Chart2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.Chart3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelTop.ResumeLayout(False)
        Me.PanelTop.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Chart1 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents DateTimePickerAkhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePickerAwal As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Chart2 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents LabelPoliUmum As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LabelPoliGigi As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents LabelPoliKia As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents LabelPoliKb As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents LabelLab As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents LabelTittlePoli As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Chart3 As System.Windows.Forms.DataVisualization.Charting.Chart
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ButtonClose As System.Windows.Forms.Button
    Friend WithEvents Label1Diagnosa As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents LabelPasien As System.Windows.Forms.Label
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
End Class
