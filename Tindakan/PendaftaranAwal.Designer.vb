<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PendaftaranAwal
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
        Me.butumum = New System.Windows.Forms.Button
        Me.butlab = New System.Windows.Forms.Button
        Me.butugd = New System.Windows.Forms.Button
        Me.txumum = New System.Windows.Forms.TextBox
        Me.txspesialis = New System.Windows.Forms.TextBox
        Me.txugd = New System.Windows.Forms.TextBox
        Me.txlab = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'butumum
        '
        Me.butumum.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butumum.Location = New System.Drawing.Point(301, 29)
        Me.butumum.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.butumum.Name = "butumum"
        Me.butumum.Size = New System.Drawing.Size(277, 101)
        Me.butumum.TabIndex = 0
        Me.butumum.Text = "Daftar Dokter Umum"
        Me.butumum.UseVisualStyleBackColor = True
        '
        'butlab
        '
        Me.butlab.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butlab.Location = New System.Drawing.Point(301, 269)
        Me.butlab.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.butlab.Name = "butlab"
        Me.butlab.Size = New System.Drawing.Size(277, 101)
        Me.butlab.TabIndex = 1
        Me.butlab.Text = "Daftar Laboratorium"
        Me.butlab.UseVisualStyleBackColor = True
        '
        'butugd
        '
        Me.butugd.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.butugd.Location = New System.Drawing.Point(301, 498)
        Me.butugd.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.butugd.Name = "butugd"
        Me.butugd.Size = New System.Drawing.Size(277, 101)
        Me.butugd.TabIndex = 2
        Me.butugd.Text = "Daftar UGD"
        Me.butugd.UseVisualStyleBackColor = True
        '
        'txumum
        '
        Me.txumum.Location = New System.Drawing.Point(86, 231)
        Me.txumum.Name = "txumum"
        Me.txumum.Size = New System.Drawing.Size(100, 26)
        Me.txumum.TabIndex = 4
        Me.txumum.Visible = False
        '
        'txspesialis
        '
        Me.txspesialis.Location = New System.Drawing.Point(86, 263)
        Me.txspesialis.Name = "txspesialis"
        Me.txspesialis.Size = New System.Drawing.Size(100, 26)
        Me.txspesialis.TabIndex = 5
        Me.txspesialis.Visible = False
        '
        'txugd
        '
        Me.txugd.Location = New System.Drawing.Point(86, 327)
        Me.txugd.Name = "txugd"
        Me.txugd.Size = New System.Drawing.Size(100, 26)
        Me.txugd.TabIndex = 7
        Me.txugd.Visible = False
        '
        'txlab
        '
        Me.txlab.Location = New System.Drawing.Point(86, 295)
        Me.txlab.Name = "txlab"
        Me.txlab.Size = New System.Drawing.Size(100, 26)
        Me.txlab.TabIndex = 6
        Me.txlab.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 234)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 20)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "umum"
        Me.Label1.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 266)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(69, 20)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "spesialis"
        Me.Label2.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(50, 298)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 20)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "lab"
        Me.Label3.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(44, 330)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 20)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "ugd"
        Me.Label4.Visible = False
        '
        'PendaftaranAwal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(878, 715)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.butumum)
        Me.Controls.Add(Me.butlab)
        Me.Controls.Add(Me.butugd)
        Me.Controls.Add(Me.txugd)
        Me.Controls.Add(Me.txlab)
        Me.Controls.Add(Me.txspesialis)
        Me.Controls.Add(Me.txumum)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MinimizeBox = False
        Me.Name = "PendaftaranAwal"
        Me.Text = "PendaftaranAwal"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents butumum As System.Windows.Forms.Button
    Friend WithEvents butlab As System.Windows.Forms.Button
    Friend WithEvents butugd As System.Windows.Forms.Button
    Friend WithEvents txumum As System.Windows.Forms.TextBox
    Friend WithEvents txspesialis As System.Windows.Forms.TextBox
    Friend WithEvents txugd As System.Windows.Forms.TextBox
    Friend WithEvents txlab As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
