<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCheckinHYU
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.AmbilSesiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TestPrintToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.lblStatusMCU = New System.Windows.Forms.Label
        Me.txtNoUrutInput = New System.Windows.Forms.TextBox
        Me.btnCheckIn = New System.Windows.Forms.Button
        Me.ButtonCetak = New System.Windows.Forms.Button
        Me.pnlHasilCard = New System.Windows.Forms.Panel
        Me.lblNip = New System.Windows.Forms.Label
        Me.lblNik = New System.Windows.Forms.Label
        Me.lblNama = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblNoUrut = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblToken = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblStatusInProgres = New System.Windows.Forms.Label
        Me.MenuStrip1.SuspendLayout()
        Me.pnlHasilCard.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AmbilSesiToolStripMenuItem, Me.TestPrintToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(429, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'AmbilSesiToolStripMenuItem
        '
        Me.AmbilSesiToolStripMenuItem.Name = "AmbilSesiToolStripMenuItem"
        Me.AmbilSesiToolStripMenuItem.Size = New System.Drawing.Size(74, 20)
        Me.AmbilSesiToolStripMenuItem.Text = "Ambil Sesi"
        '
        'TestPrintToolStripMenuItem
        '
        Me.TestPrintToolStripMenuItem.Name = "TestPrintToolStripMenuItem"
        Me.TestPrintToolStripMenuItem.Size = New System.Drawing.Size(68, 20)
        Me.TestPrintToolStripMenuItem.Text = "Test Print"
        '
        'lblStatusMCU
        '
        Me.lblStatusMCU.AutoSize = True
        Me.lblStatusMCU.Location = New System.Drawing.Point(14, 35)
        Me.lblStatusMCU.Name = "lblStatusMCU"
        Me.lblStatusMCU.Size = New System.Drawing.Size(10, 13)
        Me.lblStatusMCU.TabIndex = 1
        Me.lblStatusMCU.Text = "-"
        '
        'txtNoUrutInput
        '
        Me.txtNoUrutInput.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNoUrutInput.Location = New System.Drawing.Point(16, 71)
        Me.txtNoUrutInput.Name = "txtNoUrutInput"
        Me.txtNoUrutInput.Size = New System.Drawing.Size(145, 26)
        Me.txtNoUrutInput.TabIndex = 2
        '
        'btnCheckIn
        '
        Me.btnCheckIn.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.btnCheckIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCheckIn.ForeColor = System.Drawing.Color.White
        Me.btnCheckIn.Location = New System.Drawing.Point(167, 71)
        Me.btnCheckIn.Name = "btnCheckIn"
        Me.btnCheckIn.Size = New System.Drawing.Size(75, 26)
        Me.btnCheckIn.TabIndex = 3
        Me.btnCheckIn.Text = "Check-In"
        Me.btnCheckIn.UseVisualStyleBackColor = False
        '
        'ButtonCetak
        '
        Me.ButtonCetak.BackColor = System.Drawing.Color.Goldenrod
        Me.ButtonCetak.FlatAppearance.BorderSize = 0
        Me.ButtonCetak.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCetak.ForeColor = System.Drawing.Color.Black
        Me.ButtonCetak.Location = New System.Drawing.Point(248, 72)
        Me.ButtonCetak.Name = "ButtonCetak"
        Me.ButtonCetak.Size = New System.Drawing.Size(75, 26)
        Me.ButtonCetak.TabIndex = 4
        Me.ButtonCetak.Text = "Cetak"
        Me.ButtonCetak.UseVisualStyleBackColor = False
        '
        'pnlHasilCard
        '
        Me.pnlHasilCard.BackColor = System.Drawing.Color.White
        Me.pnlHasilCard.Controls.Add(Me.lblNip)
        Me.pnlHasilCard.Controls.Add(Me.lblNik)
        Me.pnlHasilCard.Controls.Add(Me.lblNama)
        Me.pnlHasilCard.Controls.Add(Me.Label12)
        Me.pnlHasilCard.Controls.Add(Me.Label11)
        Me.pnlHasilCard.Controls.Add(Me.Label10)
        Me.pnlHasilCard.Controls.Add(Me.Label9)
        Me.pnlHasilCard.Controls.Add(Me.Label8)
        Me.pnlHasilCard.Controls.Add(Me.Label7)
        Me.pnlHasilCard.Controls.Add(Me.lblNoUrut)
        Me.pnlHasilCard.Controls.Add(Me.Label5)
        Me.pnlHasilCard.Controls.Add(Me.Label4)
        Me.pnlHasilCard.Controls.Add(Me.lblToken)
        Me.pnlHasilCard.Controls.Add(Me.Label2)
        Me.pnlHasilCard.Controls.Add(Me.Label1)
        Me.pnlHasilCard.Location = New System.Drawing.Point(16, 116)
        Me.pnlHasilCard.Name = "pnlHasilCard"
        Me.pnlHasilCard.Size = New System.Drawing.Size(397, 87)
        Me.pnlHasilCard.TabIndex = 5
        '
        'lblNip
        '
        Me.lblNip.AutoSize = True
        Me.lblNip.Location = New System.Drawing.Point(222, 60)
        Me.lblNip.Name = "lblNip"
        Me.lblNip.Size = New System.Drawing.Size(10, 13)
        Me.lblNip.TabIndex = 14
        Me.lblNip.Text = "-"
        '
        'lblNik
        '
        Me.lblNik.AutoSize = True
        Me.lblNik.Location = New System.Drawing.Point(222, 34)
        Me.lblNik.Name = "lblNik"
        Me.lblNik.Size = New System.Drawing.Size(10, 13)
        Me.lblNik.TabIndex = 13
        Me.lblNik.Text = "-"
        '
        'lblNama
        '
        Me.lblNama.AutoSize = True
        Me.lblNama.Location = New System.Drawing.Point(222, 10)
        Me.lblNama.Name = "lblNama"
        Me.lblNama.Size = New System.Drawing.Size(10, 13)
        Me.lblNama.TabIndex = 12
        Me.lblNama.Text = "-"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(206, 60)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(10, 13)
        Me.Label12.TabIndex = 11
        Me.Label12.Text = ":"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(165, 60)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(25, 13)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "NIP"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(206, 34)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(10, 13)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = ":"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(165, 34)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(25, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "NIK"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(206, 10)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(10, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = ":"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(165, 10)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Nama"
        '
        'lblNoUrut
        '
        Me.lblNoUrut.AutoSize = True
        Me.lblNoUrut.Location = New System.Drawing.Point(60, 34)
        Me.lblNoUrut.Name = "lblNoUrut"
        Me.lblNoUrut.Size = New System.Drawing.Size(10, 13)
        Me.lblNoUrut.TabIndex = 5
        Me.lblNoUrut.Text = "-"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(50, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(10, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = ":"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "No Trans"
        '
        'lblToken
        '
        Me.lblToken.AutoSize = True
        Me.lblToken.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblToken.Location = New System.Drawing.Point(58, 10)
        Me.lblToken.Name = "lblToken"
        Me.lblToken.Size = New System.Drawing.Size(11, 13)
        Me.lblToken.TabIndex = 2
        Me.lblToken.Text = "-"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(50, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = ":"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Token"
        '
        'lblStatusInProgres
        '
        Me.lblStatusInProgres.AutoSize = True
        Me.lblStatusInProgres.Location = New System.Drawing.Point(14, 55)
        Me.lblStatusInProgres.Name = "lblStatusInProgres"
        Me.lblStatusInProgres.Size = New System.Drawing.Size(10, 13)
        Me.lblStatusInProgres.TabIndex = 6
        Me.lblStatusInProgres.Text = "-"
        '
        'FormCheckinHYU
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(429, 227)
        Me.Controls.Add(Me.lblStatusInProgres)
        Me.Controls.Add(Me.pnlHasilCard)
        Me.Controls.Add(Me.ButtonCetak)
        Me.Controls.Add(Me.btnCheckIn)
        Me.Controls.Add(Me.txtNoUrutInput)
        Me.Controls.Add(Me.lblStatusMCU)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximumSize = New System.Drawing.Size(445, 266)
        Me.MinimumSize = New System.Drawing.Size(445, 266)
        Me.Name = "FormCheckinHYU"
        Me.Text = "FormCheckinHYU"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.pnlHasilCard.ResumeLayout(False)
        Me.pnlHasilCard.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents AmbilSesiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblStatusMCU As System.Windows.Forms.Label
    Friend WithEvents txtNoUrutInput As System.Windows.Forms.TextBox
    Friend WithEvents btnCheckIn As System.Windows.Forms.Button
    Friend WithEvents TestPrintToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ButtonCetak As System.Windows.Forms.Button
    Friend WithEvents pnlHasilCard As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblNoUrut As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblToken As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblNip As System.Windows.Forms.Label
    Friend WithEvents lblNik As System.Windows.Forms.Label
    Friend WithEvents lblNama As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblStatusInProgres As System.Windows.Forms.Label
End Class
