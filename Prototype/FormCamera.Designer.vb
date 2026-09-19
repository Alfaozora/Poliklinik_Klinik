<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCamera
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.chkMirror = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbResolution = New System.Windows.Forms.ComboBox
        Me.ComboBox1 = New System.Windows.Forms.ComboBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btnCapture = New System.Windows.Forms.Button
        Me.btnStop = New System.Windows.Forms.Button
        Me.btnStart = New System.Windows.Forms.Button
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbLandscape = New System.Windows.Forms.RadioButton
        Me.rbPortrait = New System.Windows.Forms.RadioButton
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cmbResolution)
        Me.Panel1.Controls.Add(Me.ComboBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(849, 69)
        Me.Panel1.TabIndex = 0
        '
        'chkMirror
        '
        Me.chkMirror.AutoSize = True
        Me.chkMirror.Checked = True
        Me.chkMirror.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMirror.Location = New System.Drawing.Point(195, 22)
        Me.chkMirror.Name = "chkMirror"
        Me.chkMirror.Size = New System.Drawing.Size(87, 19)
        Me.chkMirror.TabIndex = 4
        Me.chkMirror.Text = "Mirror View"
        Me.chkMirror.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(223, 7)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 15)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Pilih Resolusi"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(41, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(15, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Pilih Kamera"
        '
        'cmbResolution
        '
        Me.cmbResolution.FormattingEnabled = True
        Me.cmbResolution.Location = New System.Drawing.Point(226, 28)
        Me.cmbResolution.Name = "cmbResolution"
        Me.cmbResolution.Size = New System.Drawing.Size(203, 23)
        Me.cmbResolution.TabIndex = 1
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(15, 28)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(203, 23)
        Me.ComboBox1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.btnCapture)
        Me.Panel2.Controls.Add(Me.btnStop)
        Me.Panel2.Controls.Add(Me.btnStart)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 442)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(849, 69)
        Me.Panel2.TabIndex = 1
        '
        'btnCapture
        '
        Me.btnCapture.BackColor = System.Drawing.Color.FromArgb(CType(CType(25, Byte), Integer), CType(CType(135, Byte), Integer), CType(CType(84, Byte), Integer))
        Me.btnCapture.FlatAppearance.BorderSize = 0
        Me.btnCapture.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCapture.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCapture.ForeColor = System.Drawing.Color.White
        Me.btnCapture.Location = New System.Drawing.Point(342, 18)
        Me.btnCapture.Name = "btnCapture"
        Me.btnCapture.Size = New System.Drawing.Size(164, 33)
        Me.btnCapture.TabIndex = 2
        Me.btnCapture.Text = "Capture"
        Me.btnCapture.UseVisualStyleBackColor = False
        '
        'btnStop
        '
        Me.btnStop.BackColor = System.Drawing.Color.FromArgb(CType(CType(220, Byte), Integer), CType(CType(53, Byte), Integer), CType(CType(69, Byte), Integer))
        Me.btnStop.FlatAppearance.BorderSize = 0
        Me.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStop.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStop.ForeColor = System.Drawing.Color.White
        Me.btnStop.Location = New System.Drawing.Point(534, 18)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(164, 33)
        Me.btnStop.TabIndex = 1
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = False
        '
        'btnStart
        '
        Me.btnStart.BackColor = System.Drawing.Color.FromArgb(CType(CType(13, Byte), Integer), CType(CType(110, Byte), Integer), CType(CType(253, Byte), Integer))
        Me.btnStart.FlatAppearance.BorderSize = 0
        Me.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStart.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStart.ForeColor = System.Drawing.Color.White
        Me.btnStart.Location = New System.Drawing.Point(152, 18)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(164, 33)
        Me.btnStart.TabIndex = 0
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.PictureBox1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.PictureBox2, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 69)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(849, 373)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.DarkGray
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(588, 367)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.DarkGray
        Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox2.Location = New System.Drawing.Point(597, 3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(249, 367)
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbPortrait)
        Me.GroupBox1.Controls.Add(Me.rbLandscape)
        Me.GroupBox1.Controls.Add(Me.chkMirror)
        Me.GroupBox1.Location = New System.Drawing.Point(435, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(301, 56)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Atur Gambar"
        '
        'rbLandscape
        '
        Me.rbLandscape.AutoSize = True
        Me.rbLandscape.Checked = True
        Me.rbLandscape.Location = New System.Drawing.Point(18, 22)
        Me.rbLandscape.Name = "rbLandscape"
        Me.rbLandscape.Size = New System.Drawing.Size(81, 19)
        Me.rbLandscape.TabIndex = 5
        Me.rbLandscape.TabStop = True
        Me.rbLandscape.Text = "Landscape"
        Me.rbLandscape.UseVisualStyleBackColor = True
        '
        'rbPortrait
        '
        Me.rbPortrait.AutoSize = True
        Me.rbPortrait.Location = New System.Drawing.Point(105, 22)
        Me.rbPortrait.Name = "rbPortrait"
        Me.rbPortrait.Size = New System.Drawing.Size(60, 19)
        Me.rbPortrait.TabIndex = 6
        Me.rbPortrait.Text = "Potrait"
        Me.rbPortrait.UseVisualStyleBackColor = True
        '
        'FormCamera
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(248, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(250, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(849, 511)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaximumSize = New System.Drawing.Size(865, 550)
        Me.MinimumSize = New System.Drawing.Size(865, 550)
        Me.Name = "FormCamera"
        Me.Text = "FormCamera"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents chkMirror As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbResolution As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents btnCapture As System.Windows.Forms.Button
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbPortrait As System.Windows.Forms.RadioButton
    Friend WithEvents rbLandscape As System.Windows.Forms.RadioButton
End Class
