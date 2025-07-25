<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Survey
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
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.lbldetail = New System.Windows.Forms.Label
        Me.pic2 = New System.Windows.Forms.PictureBox
        Me.pic3 = New System.Windows.Forms.PictureBox
        Me.lbl1 = New System.Windows.Forms.Label
        Me.lbl2 = New System.Windows.Forms.Label
        Me.lbl3 = New System.Windows.Forms.Label
        Me.pic1 = New System.Windows.Forms.PictureBox
        Me.txjenis = New System.Windows.Forms.TextBox
        Me.txnotransaksi = New System.Windows.Forms.TextBox
        Me.butsave = New System.Windows.Forms.Button
        Me.picgif1 = New System.Windows.Forms.PictureBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        CType(Me.pic2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pic1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picgif1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(12, 12)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(1083, 317)
        Me.TextBox1.TabIndex = 3
        '
        'lbldetail
        '
        Me.lbldetail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbldetail.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lbldetail.Font = New System.Drawing.Font("Arial Rounded MT Bold", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldetail.Location = New System.Drawing.Point(0, 56)
        Me.lbldetail.Name = "lbldetail"
        Me.lbldetail.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lbldetail.Size = New System.Drawing.Size(1105, 24)
        Me.lbldetail.TabIndex = 4
        Me.lbldetail.Text = "Silahkan anda memberikan penilaian terhadap pelayanan kami"
        Me.lbldetail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pic2
        '
        Me.pic2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pic2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.pic2.Location = New System.Drawing.Point(477, 109)
        Me.pic2.Name = "pic2"
        Me.pic2.Size = New System.Drawing.Size(164, 137)
        Me.pic2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pic2.TabIndex = 6
        Me.pic2.TabStop = False
        '
        'pic3
        '
        Me.pic3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pic3.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.pic3.Location = New System.Drawing.Point(856, 109)
        Me.pic3.Name = "pic3"
        Me.pic3.Size = New System.Drawing.Size(164, 137)
        Me.pic3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pic3.TabIndex = 7
        Me.pic3.TabStop = False
        '
        'lbl1
        '
        Me.lbl1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl1.AutoSize = True
        Me.lbl1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lbl1.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1.Location = New System.Drawing.Point(182, 246)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(48, 18)
        Me.lbl1.TabIndex = 8
        Me.lbl1.Text = "Puas"
        '
        'lbl2
        '
        Me.lbl2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl2.AutoSize = True
        Me.lbl2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lbl2.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl2.Location = New System.Drawing.Point(513, 246)
        Me.lbl2.Name = "lbl2"
        Me.lbl2.Size = New System.Drawing.Size(92, 18)
        Me.lbl2.TabIndex = 9
        Me.lbl2.Text = "Biasa Saja"
        Me.lbl2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl3
        '
        Me.lbl3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbl3.AutoSize = True
        Me.lbl3.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lbl3.Font = New System.Drawing.Font("Arial Rounded MT Bold", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl3.Location = New System.Drawing.Point(890, 246)
        Me.lbl3.Name = "lbl3"
        Me.lbl3.Size = New System.Drawing.Size(95, 18)
        Me.lbl3.TabIndex = 10
        Me.lbl3.Text = "Tidak Puas"
        '
        'pic1
        '
        Me.pic1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pic1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.pic1.Location = New System.Drawing.Point(124, 109)
        Me.pic1.Name = "pic1"
        Me.pic1.Size = New System.Drawing.Size(164, 137)
        Me.pic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pic1.TabIndex = 11
        Me.pic1.TabStop = False
        '
        'txjenis
        '
        Me.txjenis.Enabled = False
        Me.txjenis.Location = New System.Drawing.Point(3, 2)
        Me.txjenis.Name = "txjenis"
        Me.txjenis.Size = New System.Drawing.Size(100, 20)
        Me.txjenis.TabIndex = 12
        Me.txjenis.Visible = False
        '
        'txnotransaksi
        '
        Me.txnotransaksi.Enabled = False
        Me.txnotransaksi.Location = New System.Drawing.Point(124, 2)
        Me.txnotransaksi.Name = "txnotransaksi"
        Me.txnotransaksi.Size = New System.Drawing.Size(100, 20)
        Me.txnotransaksi.TabIndex = 13
        Me.txnotransaksi.Visible = False
        '
        'butsave
        '
        Me.butsave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butsave.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butsave.Location = New System.Drawing.Point(939, 401)
        Me.butsave.Name = "butsave"
        Me.butsave.Size = New System.Drawing.Size(154, 33)
        Me.butsave.TabIndex = 14
        Me.butsave.Text = "Save / Simpan"
        Me.butsave.UseVisualStyleBackColor = True
        '
        'picgif1
        '
        Me.picgif1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.picgif1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picgif1.Location = New System.Drawing.Point(0, 0)
        Me.picgif1.Name = "picgif1"
        Me.picgif1.Size = New System.Drawing.Size(1105, 577)
        Me.picgif1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picgif1.TabIndex = 15
        Me.picgif1.TabStop = False
        Me.picgif1.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'Survey
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1105, 577)
        Me.Controls.Add(Me.butsave)
        Me.Controls.Add(Me.txnotransaksi)
        Me.Controls.Add(Me.txjenis)
        Me.Controls.Add(Me.lbl1)
        Me.Controls.Add(Me.pic1)
        Me.Controls.Add(Me.lbl3)
        Me.Controls.Add(Me.lbl2)
        Me.Controls.Add(Me.pic3)
        Me.Controls.Add(Me.pic2)
        Me.Controls.Add(Me.lbldetail)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.picgif1)
        Me.Name = "Survey"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Survey"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.pic2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pic1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picgif1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents lbldetail As System.Windows.Forms.Label
    Friend WithEvents pic2 As System.Windows.Forms.PictureBox
    Friend WithEvents pic3 As System.Windows.Forms.PictureBox
    Friend WithEvents lbl1 As System.Windows.Forms.Label
    Friend WithEvents lbl2 As System.Windows.Forms.Label
    Friend WithEvents lbl3 As System.Windows.Forms.Label
    Friend WithEvents pic1 As System.Windows.Forms.PictureBox
    Friend WithEvents txjenis As System.Windows.Forms.TextBox
    Friend WithEvents txnotransaksi As System.Windows.Forms.TextBox
    Friend WithEvents butsave As System.Windows.Forms.Button
    Friend WithEvents picgif1 As System.Windows.Forms.PictureBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
