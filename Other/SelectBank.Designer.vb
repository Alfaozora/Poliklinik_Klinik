<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectBank
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.txdatetime = New System.Windows.Forms.TextBox
        Me.txjenis = New System.Windows.Forms.TextBox
        Me.txbanknama = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.cmbbank = New System.Windows.Forms.ComboBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txnomorrek = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txnamabank = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txbankid = New System.Windows.Forms.TextBox
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(268, 138)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'txdatetime
        '
        Me.txdatetime.Location = New System.Drawing.Point(16, 147)
        Me.txdatetime.Name = "txdatetime"
        Me.txdatetime.Size = New System.Drawing.Size(74, 20)
        Me.txdatetime.TabIndex = 2
        Me.txdatetime.Visible = False
        '
        'txjenis
        '
        Me.txjenis.Location = New System.Drawing.Point(16, 146)
        Me.txjenis.Name = "txjenis"
        Me.txjenis.Size = New System.Drawing.Size(32, 20)
        Me.txjenis.TabIndex = 3
        Me.txjenis.Visible = False
        '
        'txbanknama
        '
        Me.txbanknama.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txbanknama.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txbanknama.Location = New System.Drawing.Point(107, 40)
        Me.txbanknama.Name = "txbanknama"
        Me.txbanknama.ReadOnly = True
        Me.txbanknama.Size = New System.Drawing.Size(288, 25)
        Me.txbanknama.TabIndex = 211
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(12, 43)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(68, 20)
        Me.Label22.TabIndex = 210
        Me.Label22.Text = "Nama Rek"
        '
        'cmbbank
        '
        Me.cmbbank.BackColor = System.Drawing.SystemColors.Control
        Me.cmbbank.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbbank.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbbank.FormattingEnabled = True
        Me.cmbbank.Location = New System.Drawing.Point(107, 6)
        Me.cmbbank.Name = "cmbbank"
        Me.cmbbank.Size = New System.Drawing.Size(288, 28)
        Me.cmbbank.TabIndex = 208
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(14, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 20)
        Me.Label6.TabIndex = 209
        Me.Label6.Text = "Bank Transfer"
        '
        'txnomorrek
        '
        Me.txnomorrek.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txnomorrek.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txnomorrek.Location = New System.Drawing.Point(107, 72)
        Me.txnomorrek.Name = "txnomorrek"
        Me.txnomorrek.ReadOnly = True
        Me.txnomorrek.Size = New System.Drawing.Size(288, 25)
        Me.txnomorrek.TabIndex = 213
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 20)
        Me.Label1.TabIndex = 212
        Me.Label1.Text = "Nomor Rek"
        '
        'txnamabank
        '
        Me.txnamabank.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txnamabank.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txnamabank.Location = New System.Drawing.Point(107, 105)
        Me.txnamabank.Name = "txnamabank"
        Me.txnamabank.ReadOnly = True
        Me.txnamabank.Size = New System.Drawing.Size(288, 25)
        Me.txnamabank.TabIndex = 215
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 108)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 20)
        Me.Label3.TabIndex = 214
        Me.Label3.Text = "Nama Bank"
        '
        'txbankid
        '
        Me.txbankid.Font = New System.Drawing.Font("Arial Narrow", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txbankid.Location = New System.Drawing.Point(107, 6)
        Me.txbankid.Name = "txbankid"
        Me.txbankid.ReadOnly = True
        Me.txbankid.Size = New System.Drawing.Size(56, 25)
        Me.txbankid.TabIndex = 216
        Me.txbankid.Visible = False
        '
        'SelectBank
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(426, 188)
        Me.ControlBox = False
        Me.Controls.Add(Me.txbankid)
        Me.Controls.Add(Me.txnamabank)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txnomorrek)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txbanknama)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.cmbbank)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txjenis)
        Me.Controls.Add(Me.txdatetime)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SelectBank"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents txdatetime As System.Windows.Forms.TextBox
    Friend WithEvents txjenis As System.Windows.Forms.TextBox
    Friend WithEvents txbanknama As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents cmbbank As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txnomorrek As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txnamabank As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txbankid As System.Windows.Forms.TextBox

End Class
