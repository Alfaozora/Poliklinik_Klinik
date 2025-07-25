<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FindNoInvoice
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FindNoInvoice))
        Me.butdisplay = New System.Windows.Forms.Button
        Me.txnourut = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txnoinvoice = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'butdisplay
        '
        Me.butdisplay.BackgroundImage = Global.PoliKlinik_Net2.My.Resources.Resources.tombol_cari
        Me.butdisplay.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.butdisplay.Location = New System.Drawing.Point(140, 48)
        Me.butdisplay.Name = "butdisplay"
        Me.butdisplay.Size = New System.Drawing.Size(100, 36)
        Me.butdisplay.TabIndex = 106
        Me.butdisplay.UseVisualStyleBackColor = True
        '
        'txnourut
        '
        Me.txnourut.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txnourut.Location = New System.Drawing.Point(90, 17)
        Me.txnourut.Name = "txnourut"
        Me.txnourut.Size = New System.Drawing.Size(217, 25)
        Me.txnourut.TabIndex = 200
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(21, 20)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(52, 16)
        Me.Label16.TabIndex = 199
        Me.Label16.Text = "No Urut"
        '
        'txnoinvoice
        '
        Me.txnoinvoice.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txnoinvoice.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txnoinvoice.Location = New System.Drawing.Point(90, 90)
        Me.txnoinvoice.Name = "txnoinvoice"
        Me.txnoinvoice.ReadOnly = True
        Me.txnoinvoice.Size = New System.Drawing.Size(217, 25)
        Me.txnoinvoice.TabIndex = 201
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 93)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 16)
        Me.Label1.TabIndex = 202
        Me.Label1.Text = "No Invoice"
        '
        'FindNoInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.PoliKlinik_Net2.My.Resources.Resources.wallpaperdialog
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(354, 185)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txnoinvoice)
        Me.Controls.Add(Me.txnourut)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.butdisplay)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FindNoInvoice"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Cari Invoice"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents butdisplay As System.Windows.Forms.Button
    Friend WithEvents txnourut As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txnoinvoice As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
