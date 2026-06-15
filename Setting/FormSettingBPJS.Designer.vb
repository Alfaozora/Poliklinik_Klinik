<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSettingBPJS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSettingBPJS))
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.CheckBoxStatusPcare = New System.Windows.Forms.CheckBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.TextBoxKodePPK = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBoxUsername = New System.Windows.Forms.TextBox
        Me.TextBoxPassword = New System.Windows.Forms.TextBox
        Me.TextBoxBaseURL = New System.Windows.Forms.TextBox
        Me.TextBoxUserKey = New System.Windows.Forms.TextBox
        Me.TextBoxSecretKey = New System.Windows.Forms.TextBox
        Me.TextBoxConsumerID = New System.Windows.Forms.TextBox
        Me.butGetData = New System.Windows.Forms.Button
        Me.TextBoxResponse = New System.Windows.Forms.TextBox
        Me.TextBoxResponseURL = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.PanelTop = New System.Windows.Forms.Panel
        Me.ButtonClose = New System.Windows.Forms.Button
        Me.ButtonSimpan = New System.Windows.Forms.Button
        Me.ButtonGetResponse = New System.Windows.Forms.Button
        Me.TextBoxGenerateConsID = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.TextBoxGenerateTimestamp = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.TextBoxGenerateSignature = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.TextBoxGenerateAuthorization = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.ButtonGenerateHeader = New System.Windows.Forms.Button
        Me.Label18 = New System.Windows.Forms.Label
        Me.TextBoxResponseBody = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.ButtonPostResponse = New System.Windows.Forms.Button
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.TextBoxNamaPPK = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Panel7 = New System.Windows.Forms.Panel
        Me.RadioButtonEnvironmentProduction = New System.Windows.Forms.RadioButton
        Me.RadioButtonEnvironmentDevelopment = New System.Windows.Forms.RadioButton
        Me.Label22 = New System.Windows.Forms.Label
        Me.TextBoxAPIKeyAntrian = New System.Windows.Forms.TextBox
        Me.PanelTop.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label10.Location = New System.Drawing.Point(18, 277)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 17)
        Me.Label10.TabIndex = 195
        Me.Label10.Text = "Cons ID"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label9.Location = New System.Drawing.Point(18, 248)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(66, 17)
        Me.Label9.TabIndex = 194
        Me.Label9.Text = "Password"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label6.Location = New System.Drawing.Point(18, 217)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 17)
        Me.Label6.TabIndex = 193
        Me.Label6.Text = "Username"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(18, 138)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 17)
        Me.Label1.TabIndex = 192
        Me.Label1.Text = "Kode PPK"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label5.Location = New System.Drawing.Point(18, 78)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 17)
        Me.Label5.TabIndex = 191
        Me.Label5.Text = "P-Care?"
        '
        'CheckBoxStatusPcare
        '
        Me.CheckBoxStatusPcare.AutoSize = True
        Me.CheckBoxStatusPcare.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.CheckBoxStatusPcare.Location = New System.Drawing.Point(127, 77)
        Me.CheckBoxStatusPcare.Name = "CheckBoxStatusPcare"
        Me.CheckBoxStatusPcare.Size = New System.Drawing.Size(43, 21)
        Me.CheckBoxStatusPcare.TabIndex = 196
        Me.CheckBoxStatusPcare.Text = "Iya"
        Me.CheckBoxStatusPcare.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label7.Location = New System.Drawing.Point(18, 370)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 17)
        Me.Label7.TabIndex = 199
        Me.Label7.Text = "Base URL"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label8.Location = New System.Drawing.Point(18, 339)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(61, 17)
        Me.Label8.TabIndex = 198
        Me.Label8.Text = "User Key"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label11.Location = New System.Drawing.Point(18, 308)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 17)
        Me.Label11.TabIndex = 197
        Me.Label11.Text = "Secret Key"
        '
        'TextBoxKodePPK
        '
        Me.TextBoxKodePPK.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxKodePPK.Location = New System.Drawing.Point(127, 135)
        Me.TextBoxKodePPK.Name = "TextBoxKodePPK"
        Me.TextBoxKodePPK.Size = New System.Drawing.Size(275, 25)
        Me.TextBoxKodePPK.TabIndex = 204
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(124, 194)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(271, 17)
        Me.Label2.TabIndex = 205
        Me.Label2.Text = "*Username && Password untuk login ke pcare."
        '
        'TextBoxUsername
        '
        Me.TextBoxUsername.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxUsername.Location = New System.Drawing.Point(127, 214)
        Me.TextBoxUsername.Name = "TextBoxUsername"
        Me.TextBoxUsername.Size = New System.Drawing.Size(275, 25)
        Me.TextBoxUsername.TabIndex = 206
        '
        'TextBoxPassword
        '
        Me.TextBoxPassword.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxPassword.Location = New System.Drawing.Point(127, 245)
        Me.TextBoxPassword.Multiline = True
        Me.TextBoxPassword.Name = "TextBoxPassword"
        Me.TextBoxPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBoxPassword.Size = New System.Drawing.Size(275, 23)
        Me.TextBoxPassword.TabIndex = 207
        '
        'TextBoxBaseURL
        '
        Me.TextBoxBaseURL.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxBaseURL.Location = New System.Drawing.Point(127, 367)
        Me.TextBoxBaseURL.Multiline = True
        Me.TextBoxBaseURL.Name = "TextBoxBaseURL"
        Me.TextBoxBaseURL.Size = New System.Drawing.Size(275, 43)
        Me.TextBoxBaseURL.TabIndex = 208
        '
        'TextBoxUserKey
        '
        Me.TextBoxUserKey.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxUserKey.Location = New System.Drawing.Point(127, 336)
        Me.TextBoxUserKey.Name = "TextBoxUserKey"
        Me.TextBoxUserKey.Size = New System.Drawing.Size(275, 25)
        Me.TextBoxUserKey.TabIndex = 209
        '
        'TextBoxSecretKey
        '
        Me.TextBoxSecretKey.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxSecretKey.Location = New System.Drawing.Point(127, 305)
        Me.TextBoxSecretKey.Name = "TextBoxSecretKey"
        Me.TextBoxSecretKey.Size = New System.Drawing.Size(275, 25)
        Me.TextBoxSecretKey.TabIndex = 210
        '
        'TextBoxConsumerID
        '
        Me.TextBoxConsumerID.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxConsumerID.Location = New System.Drawing.Point(127, 274)
        Me.TextBoxConsumerID.Name = "TextBoxConsumerID"
        Me.TextBoxConsumerID.Size = New System.Drawing.Size(275, 25)
        Me.TextBoxConsumerID.TabIndex = 211
        '
        'butGetData
        '
        Me.butGetData.Location = New System.Drawing.Point(831, 246)
        Me.butGetData.Name = "butGetData"
        Me.butGetData.Size = New System.Drawing.Size(75, 25)
        Me.butGetData.TabIndex = 213
        Me.butGetData.Text = "Get API"
        Me.butGetData.UseVisualStyleBackColor = True
        '
        'TextBoxResponse
        '
        Me.TextBoxResponse.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxResponse.Location = New System.Drawing.Point(620, 158)
        Me.TextBoxResponse.Multiline = True
        Me.TextBoxResponse.Name = "TextBoxResponse"
        Me.TextBoxResponse.Size = New System.Drawing.Size(286, 43)
        Me.TextBoxResponse.TabIndex = 214
        '
        'TextBoxResponseURL
        '
        Me.TextBoxResponseURL.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxResponseURL.Location = New System.Drawing.Point(620, 78)
        Me.TextBoxResponseURL.Name = "TextBoxResponseURL"
        Me.TextBoxResponseURL.Size = New System.Drawing.Size(286, 25)
        Me.TextBoxResponseURL.TabIndex = 215
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label3.Location = New System.Drawing.Point(489, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 17)
        Me.Label3.TabIndex = 430
        Me.Label3.Text = "URL"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label4.Location = New System.Drawing.Point(489, 161)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 17)
        Me.Label4.TabIndex = 429
        Me.Label4.Text = "Response"
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.PanelTop.Controls.Add(Me.ButtonClose)
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(918, 35)
        Me.PanelTop.TabIndex = 431
        '
        'ButtonClose
        '
        Me.ButtonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonClose.Dock = System.Windows.Forms.DockStyle.Right
        Me.ButtonClose.FlatAppearance.BorderSize = 0
        Me.ButtonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonClose.Image = CType(resources.GetObject("ButtonClose.Image"), System.Drawing.Image)
        Me.ButtonClose.Location = New System.Drawing.Point(878, 0)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(40, 35)
        Me.ButtonClose.TabIndex = 281
        Me.ButtonClose.UseVisualStyleBackColor = True
        '
        'ButtonSimpan
        '
        Me.ButtonSimpan.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonSimpan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonSimpan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonSimpan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSimpan.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonSimpan.ForeColor = System.Drawing.Color.White
        Me.ButtonSimpan.Location = New System.Drawing.Point(127, 447)
        Me.ButtonSimpan.Name = "ButtonSimpan"
        Me.ButtonSimpan.Size = New System.Drawing.Size(275, 30)
        Me.ButtonSimpan.TabIndex = 432
        Me.ButtonSimpan.Text = "Simpan"
        Me.ButtonSimpan.UseVisualStyleBackColor = False
        '
        'ButtonGetResponse
        '
        Me.ButtonGetResponse.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonGetResponse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonGetResponse.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonGetResponse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonGetResponse.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonGetResponse.ForeColor = System.Drawing.Color.White
        Me.ButtonGetResponse.Location = New System.Drawing.Point(620, 207)
        Me.ButtonGetResponse.Name = "ButtonGetResponse"
        Me.ButtonGetResponse.Size = New System.Drawing.Size(50, 30)
        Me.ButtonGetResponse.TabIndex = 433
        Me.ButtonGetResponse.Text = "Get"
        Me.ButtonGetResponse.UseVisualStyleBackColor = False
        '
        'TextBoxGenerateConsID
        '
        Me.TextBoxGenerateConsID.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxGenerateConsID.Location = New System.Drawing.Point(620, 315)
        Me.TextBoxGenerateConsID.Name = "TextBoxGenerateConsID"
        Me.TextBoxGenerateConsID.Size = New System.Drawing.Size(286, 25)
        Me.TextBoxGenerateConsID.TabIndex = 435
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label12.Location = New System.Drawing.Point(489, 318)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(65, 17)
        Me.Label12.TabIndex = 434
        Me.Label12.Text = "X-cons-id"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label14.Location = New System.Drawing.Point(489, 50)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(158, 17)
        Me.Label14.TabIndex = 437
        Me.Label14.Text = "GET RESPONSE METHOD"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label15.Location = New System.Drawing.Point(489, 251)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(225, 17)
        Me.Label15.TabIndex = 438
        Me.Label15.Text = "GENERATE HEADER CONS ID PCARE"
        '
        'TextBoxGenerateTimestamp
        '
        Me.TextBoxGenerateTimestamp.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxGenerateTimestamp.Location = New System.Drawing.Point(620, 346)
        Me.TextBoxGenerateTimestamp.Name = "TextBoxGenerateTimestamp"
        Me.TextBoxGenerateTimestamp.Size = New System.Drawing.Size(286, 25)
        Me.TextBoxGenerateTimestamp.TabIndex = 440
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label13.Location = New System.Drawing.Point(489, 349)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(88, 17)
        Me.Label13.TabIndex = 439
        Me.Label13.Text = "X-Timestamp"
        '
        'TextBoxGenerateSignature
        '
        Me.TextBoxGenerateSignature.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxGenerateSignature.Location = New System.Drawing.Point(620, 377)
        Me.TextBoxGenerateSignature.Name = "TextBoxGenerateSignature"
        Me.TextBoxGenerateSignature.Size = New System.Drawing.Size(286, 25)
        Me.TextBoxGenerateSignature.TabIndex = 442
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label16.Location = New System.Drawing.Point(489, 380)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(79, 17)
        Me.Label16.TabIndex = 441
        Me.Label16.Text = "X-Signature"
        '
        'TextBoxGenerateAuthorization
        '
        Me.TextBoxGenerateAuthorization.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxGenerateAuthorization.Location = New System.Drawing.Point(620, 408)
        Me.TextBoxGenerateAuthorization.Name = "TextBoxGenerateAuthorization"
        Me.TextBoxGenerateAuthorization.Size = New System.Drawing.Size(286, 25)
        Me.TextBoxGenerateAuthorization.TabIndex = 444
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label17.Location = New System.Drawing.Point(489, 411)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(104, 17)
        Me.Label17.TabIndex = 443
        Me.Label17.Text = "X-Authorization"
        '
        'ButtonGenerateHeader
        '
        Me.ButtonGenerateHeader.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonGenerateHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonGenerateHeader.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonGenerateHeader.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonGenerateHeader.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonGenerateHeader.ForeColor = System.Drawing.Color.White
        Me.ButtonGenerateHeader.Location = New System.Drawing.Point(620, 279)
        Me.ButtonGenerateHeader.Name = "ButtonGenerateHeader"
        Me.ButtonGenerateHeader.Size = New System.Drawing.Size(120, 30)
        Me.ButtonGenerateHeader.TabIndex = 445
        Me.ButtonGenerateHeader.Text = "Generate Header"
        Me.ButtonGenerateHeader.UseVisualStyleBackColor = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label18.Location = New System.Drawing.Point(18, 50)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(159, 17)
        Me.Label18.TabIndex = 446
        Me.Label18.Text = "SETTING CONS ID PCARE"
        '
        'TextBoxResponseBody
        '
        Me.TextBoxResponseBody.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxResponseBody.Location = New System.Drawing.Point(620, 109)
        Me.TextBoxResponseBody.Multiline = True
        Me.TextBoxResponseBody.Name = "TextBoxResponseBody"
        Me.TextBoxResponseBody.Size = New System.Drawing.Size(286, 43)
        Me.TextBoxResponseBody.TabIndex = 447
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label19.Location = New System.Drawing.Point(489, 112)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(39, 17)
        Me.Label19.TabIndex = 448
        Me.Label19.Text = "Body"
        '
        'ButtonPostResponse
        '
        Me.ButtonPostResponse.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonPostResponse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ButtonPostResponse.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonPostResponse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonPostResponse.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ButtonPostResponse.ForeColor = System.Drawing.Color.White
        Me.ButtonPostResponse.Location = New System.Drawing.Point(676, 207)
        Me.ButtonPostResponse.Name = "ButtonPostResponse"
        Me.ButtonPostResponse.Size = New System.Drawing.Size(50, 30)
        Me.ButtonPostResponse.TabIndex = 449
        Me.ButtonPostResponse.Text = "Post"
        Me.ButtonPostResponse.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(620, 439)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(140, 30)
        Me.Button1.TabIndex = 450
        Me.Button1.Text = "Get Token Antrean"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(766, 439)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(140, 30)
        Me.Button2.TabIndex = 451
        Me.Button2.Text = "Get Data Antrean"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(620, 475)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(140, 30)
        Me.Button3.TabIndex = 452
        Me.Button3.Text = "Get Data Peserta"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.Location = New System.Drawing.Point(766, 475)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(140, 30)
        Me.Button4.TabIndex = 453
        Me.Button4.Text = "Checkin Antrean"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.Button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Button5.ForeColor = System.Drawing.Color.White
        Me.Button5.Location = New System.Drawing.Point(746, 279)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(160, 30)
        Me.Button5.TabIndex = 454
        Me.Button5.Text = "Generate Header I-Care"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.Button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Button6.ForeColor = System.Drawing.Color.White
        Me.Button6.Location = New System.Drawing.Point(732, 207)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(174, 30)
        Me.Button6.TabIndex = 455
        Me.Button6.Text = "Extract Lz String"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'TextBoxNamaPPK
        '
        Me.TextBoxNamaPPK.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxNamaPPK.Location = New System.Drawing.Point(127, 166)
        Me.TextBoxNamaPPK.Name = "TextBoxNamaPPK"
        Me.TextBoxNamaPPK.Size = New System.Drawing.Size(275, 25)
        Me.TextBoxNamaPPK.TabIndex = 457
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label20.Location = New System.Drawing.Point(18, 169)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(72, 17)
        Me.Label20.TabIndex = 456
        Me.Label20.Text = "Nama PPK"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label21.Location = New System.Drawing.Point(18, 109)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(86, 17)
        Me.Label21.TabIndex = 458
        Me.Label21.Text = "Environment"
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Transparent
        Me.Panel7.Controls.Add(Me.RadioButtonEnvironmentProduction)
        Me.Panel7.Controls.Add(Me.RadioButtonEnvironmentDevelopment)
        Me.Panel7.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold)
        Me.Panel7.Location = New System.Drawing.Point(127, 104)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(275, 25)
        Me.Panel7.TabIndex = 470
        '
        'RadioButtonEnvironmentProduction
        '
        Me.RadioButtonEnvironmentProduction.AutoSize = True
        Me.RadioButtonEnvironmentProduction.Checked = True
        Me.RadioButtonEnvironmentProduction.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonEnvironmentProduction.Location = New System.Drawing.Point(5, 3)
        Me.RadioButtonEnvironmentProduction.Name = "RadioButtonEnvironmentProduction"
        Me.RadioButtonEnvironmentProduction.Size = New System.Drawing.Size(89, 21)
        Me.RadioButtonEnvironmentProduction.TabIndex = 464
        Me.RadioButtonEnvironmentProduction.TabStop = True
        Me.RadioButtonEnvironmentProduction.Tag = "production"
        Me.RadioButtonEnvironmentProduction.Text = "Production"
        Me.RadioButtonEnvironmentProduction.UseVisualStyleBackColor = True
        '
        'RadioButtonEnvironmentDevelopment
        '
        Me.RadioButtonEnvironmentDevelopment.AutoSize = True
        Me.RadioButtonEnvironmentDevelopment.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonEnvironmentDevelopment.Location = New System.Drawing.Point(100, 3)
        Me.RadioButtonEnvironmentDevelopment.Name = "RadioButtonEnvironmentDevelopment"
        Me.RadioButtonEnvironmentDevelopment.Size = New System.Drawing.Size(103, 21)
        Me.RadioButtonEnvironmentDevelopment.TabIndex = 466
        Me.RadioButtonEnvironmentDevelopment.Tag = "development"
        Me.RadioButtonEnvironmentDevelopment.Text = "Development"
        Me.RadioButtonEnvironmentDevelopment.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label22.Location = New System.Drawing.Point(18, 419)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(104, 17)
        Me.Label22.TabIndex = 474
        Me.Label22.Text = "API Key Antrian"
        '
        'TextBoxAPIKeyAntrian
        '
        Me.TextBoxAPIKeyAntrian.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxAPIKeyAntrian.Location = New System.Drawing.Point(127, 416)
        Me.TextBoxAPIKeyAntrian.Name = "TextBoxAPIKeyAntrian"
        Me.TextBoxAPIKeyAntrian.Size = New System.Drawing.Size(275, 25)
        Me.TextBoxAPIKeyAntrian.TabIndex = 473
        '
        'FormSettingBPJS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(918, 550)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.TextBoxAPIKeyAntrian)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.TextBoxNamaPPK)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ButtonPostResponse)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.TextBoxResponseBody)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.ButtonGenerateHeader)
        Me.Controls.Add(Me.TextBoxGenerateAuthorization)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.TextBoxGenerateSignature)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.TextBoxGenerateTimestamp)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TextBoxGenerateConsID)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.ButtonGetResponse)
        Me.Controls.Add(Me.ButtonSimpan)
        Me.Controls.Add(Me.PanelTop)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TextBoxResponseURL)
        Me.Controls.Add(Me.TextBoxResponse)
        Me.Controls.Add(Me.butGetData)
        Me.Controls.Add(Me.TextBoxConsumerID)
        Me.Controls.Add(Me.TextBoxSecretKey)
        Me.Controls.Add(Me.TextBoxUserKey)
        Me.Controls.Add(Me.TextBoxBaseURL)
        Me.Controls.Add(Me.TextBoxPassword)
        Me.Controls.Add(Me.TextBoxUsername)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBoxKodePPK)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.CheckBoxStatusPcare)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSettingBPJS"
        Me.Text = "PENGATURAN P-Care"
        Me.PanelTop.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxStatusPcare As System.Windows.Forms.CheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextBoxKodePPK As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBoxUsername As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxPassword As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxBaseURL As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxUserKey As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxSecretKey As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxConsumerID As System.Windows.Forms.TextBox
    Friend WithEvents butGetData As System.Windows.Forms.Button
    Friend WithEvents TextBoxResponse As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxResponseURL As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents ButtonClose As System.Windows.Forms.Button
    Friend WithEvents ButtonSimpan As System.Windows.Forms.Button
    Friend WithEvents ButtonGetResponse As System.Windows.Forms.Button
    Friend WithEvents TextBoxGenerateConsID As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TextBoxGenerateTimestamp As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TextBoxGenerateSignature As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TextBoxGenerateAuthorization As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents ButtonGenerateHeader As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents TextBoxResponseBody As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents ButtonPostResponse As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents TextBoxNamaPPK As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents RadioButtonEnvironmentProduction As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonEnvironmentDevelopment As System.Windows.Forms.RadioButton
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TextBoxAPIKeyAntrian As System.Windows.Forms.TextBox
End Class
