<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCetakUlangRujukan
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCetakUlangRujukan))
        Me.dtkasirakhir = New System.Windows.Forms.DateTimePicker
        Me.dtkasirawal = New System.Windows.Forms.DateTimePicker
        Me.butdisplay = New System.Windows.Forms.Button
        Me.butfind = New System.Windows.Forms.Button
        Me.txnorujukan = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.CheckBoxDelete = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'dtkasirakhir
        '
        Me.dtkasirakhir.CustomFormat = "dd-MMM-yyyy"
        Me.dtkasirakhir.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtkasirakhir.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtkasirakhir.Location = New System.Drawing.Point(277, 27)
        Me.dtkasirakhir.Name = "dtkasirakhir"
        Me.dtkasirakhir.Size = New System.Drawing.Size(110, 21)
        Me.dtkasirakhir.TabIndex = 113
        '
        'dtkasirawal
        '
        Me.dtkasirawal.CustomFormat = "dd-MMM-yyyy"
        Me.dtkasirawal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtkasirawal.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtkasirawal.Location = New System.Drawing.Point(133, 27)
        Me.dtkasirawal.Name = "dtkasirawal"
        Me.dtkasirawal.Size = New System.Drawing.Size(110, 21)
        Me.dtkasirawal.TabIndex = 110
        '
        'butdisplay
        '
        Me.butdisplay.BackgroundImage = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_cetak
        Me.butdisplay.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butdisplay.Location = New System.Drawing.Point(133, 112)
        Me.butdisplay.Name = "butdisplay"
        Me.butdisplay.Size = New System.Drawing.Size(100, 36)
        Me.butdisplay.TabIndex = 106
        Me.butdisplay.UseVisualStyleBackColor = True
        '
        'butfind
        '
        Me.butfind.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.butfind.Location = New System.Drawing.Point(356, 57)
        Me.butfind.Name = "butfind"
        Me.butfind.Size = New System.Drawing.Size(31, 25)
        Me.butfind.TabIndex = 201
        Me.butfind.Text = "..."
        Me.butfind.UseVisualStyleBackColor = True
        '
        'txnorujukan
        '
        Me.txnorujukan.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txnorujukan.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txnorujukan.Location = New System.Drawing.Point(133, 58)
        Me.txnorujukan.Name = "txnorujukan"
        Me.txnorujukan.ReadOnly = True
        Me.txnorujukan.Size = New System.Drawing.Size(217, 22)
        Me.txnorujukan.TabIndex = 200
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(43, 61)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(75, 16)
        Me.Label16.TabIndex = 199
        Me.Label16.Text = "No Rujukan"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(103, 16)
        Me.Label1.TabIndex = 206
        Me.Label1.Text = "Tanggal Rujukan"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(248, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 16)
        Me.Label3.TabIndex = 207
        Me.Label3.Text = "s/d"
        '
        'CheckBoxDelete
        '
        Me.CheckBoxDelete.AutoSize = True
        Me.CheckBoxDelete.BackColor = System.Drawing.Color.Transparent
        Me.CheckBoxDelete.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBoxDelete.Location = New System.Drawing.Point(133, 86)
        Me.CheckBoxDelete.Name = "CheckBoxDelete"
        Me.CheckBoxDelete.Size = New System.Drawing.Size(150, 20)
        Me.CheckBoxDelete.TabIndex = 267
        Me.CheckBoxDelete.Text = "Delete Surat Rujukan"
        Me.CheckBoxDelete.UseVisualStyleBackColor = False
        '
        'FormCetakUlangRujukan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.PoliKlinik_Net2.My.Resources.Resources.wallpaperdialog
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(409, 211)
        Me.Controls.Add(Me.CheckBoxDelete)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dtkasirawal)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtkasirakhir)
        Me.Controls.Add(Me.butfind)
        Me.Controls.Add(Me.txnorujukan)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.butdisplay)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(425, 250)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(425, 250)
        Me.Name = "FormCetakUlangRujukan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Cetak Ulang Rujukan"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtkasirakhir As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtkasirawal As System.Windows.Forms.DateTimePicker
    Friend WithEvents butdisplay As System.Windows.Forms.Button
    Friend WithEvents butfind As System.Windows.Forms.Button
    Friend WithEvents txnorujukan As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CheckBoxDelete As System.Windows.Forms.CheckBox
End Class
