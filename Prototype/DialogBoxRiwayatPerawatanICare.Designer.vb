<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogBoxRiwayatPerawatanICare
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
        Me.PanelTop = New System.Windows.Forms.Panel
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.SplitContainerInformedConcent = New System.Windows.Forms.SplitContainer
        Me.TextBoxNoIdentitas = New System.Windows.Forms.TextBox
        Me.ButtonBatal = New System.Windows.Forms.Button
        Me.ButtonCariRiwayatPasien = New System.Windows.Forms.Button
        Me.PanelKesadaranMenuPemeriksaanAwal = New System.Windows.Forms.Panel
        Me.RadioButtonOpsiNIK = New System.Windows.Forms.RadioButton
        Me.RadioButtonOpsiNomorKartu = New System.Windows.Forms.RadioButton
        Me.Panel1.SuspendLayout()
        Me.SplitContainerInformedConcent.Panel1.SuspendLayout()
        Me.SplitContainerInformedConcent.Panel2.SuspendLayout()
        Me.SplitContainerInformedConcent.SuspendLayout()
        Me.PanelKesadaranMenuPemeriksaanAwal.SuspendLayout()
        Me.SuspendLayout()
        '
        'PanelTop
        '
        Me.PanelTop.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.PanelTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelTop.Location = New System.Drawing.Point(0, 0)
        Me.PanelTop.Name = "PanelTop"
        Me.PanelTop.Size = New System.Drawing.Size(348, 35)
        Me.PanelTop.TabIndex = 5
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.SplitContainerInformedConcent)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 35)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(348, 128)
        Me.Panel1.TabIndex = 6
        '
        'SplitContainerInformedConcent
        '
        Me.SplitContainerInformedConcent.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerInformedConcent.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainerInformedConcent.IsSplitterFixed = True
        Me.SplitContainerInformedConcent.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerInformedConcent.Name = "SplitContainerInformedConcent"
        Me.SplitContainerInformedConcent.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainerInformedConcent.Panel1
        '
        Me.SplitContainerInformedConcent.Panel1.AutoScroll = True
        Me.SplitContainerInformedConcent.Panel1.Controls.Add(Me.PanelKesadaranMenuPemeriksaanAwal)
        Me.SplitContainerInformedConcent.Panel1.Controls.Add(Me.TextBoxNoIdentitas)
        '
        'SplitContainerInformedConcent.Panel2
        '
        Me.SplitContainerInformedConcent.Panel2.AutoScroll = True
        Me.SplitContainerInformedConcent.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.SplitContainerInformedConcent.Panel2.Controls.Add(Me.ButtonBatal)
        Me.SplitContainerInformedConcent.Panel2.Controls.Add(Me.ButtonCariRiwayatPasien)
        Me.SplitContainerInformedConcent.Size = New System.Drawing.Size(348, 128)
        Me.SplitContainerInformedConcent.SplitterDistance = 82
        Me.SplitContainerInformedConcent.SplitterWidth = 5
        Me.SplitContainerInformedConcent.TabIndex = 500
        '
        'TextBoxNoIdentitas
        '
        Me.TextBoxNoIdentitas.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.TextBoxNoIdentitas.Location = New System.Drawing.Point(50, 46)
        Me.TextBoxNoIdentitas.Name = "TextBoxNoIdentitas"
        Me.TextBoxNoIdentitas.Size = New System.Drawing.Size(250, 25)
        Me.TextBoxNoIdentitas.TabIndex = 473
        '
        'ButtonBatal
        '
        Me.ButtonBatal.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonBatal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonBatal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonBatal.Dock = System.Windows.Forms.DockStyle.Right
        Me.ButtonBatal.FlatAppearance.BorderSize = 0
        Me.ButtonBatal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonBatal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonBatal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonBatal.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonBatal.ForeColor = System.Drawing.Color.White
        Me.ButtonBatal.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_cancel_24
        Me.ButtonBatal.Location = New System.Drawing.Point(48, 0)
        Me.ButtonBatal.Name = "ButtonBatal"
        Me.ButtonBatal.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.ButtonBatal.Size = New System.Drawing.Size(100, 41)
        Me.ButtonBatal.TabIndex = 7
        Me.ButtonBatal.Text = "  Batal"
        Me.ButtonBatal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonBatal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonBatal.UseVisualStyleBackColor = False
        '
        'ButtonCariRiwayatPasien
        '
        Me.ButtonCariRiwayatPasien.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCariRiwayatPasien.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonCariRiwayatPasien.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonCariRiwayatPasien.Dock = System.Windows.Forms.DockStyle.Right
        Me.ButtonCariRiwayatPasien.FlatAppearance.BorderSize = 0
        Me.ButtonCariRiwayatPasien.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(200, Byte), Integer))
        Me.ButtonCariRiwayatPasien.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(81, Byte), Integer), CType(CType(168, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonCariRiwayatPasien.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCariRiwayatPasien.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonCariRiwayatPasien.ForeColor = System.Drawing.Color.White
        Me.ButtonCariRiwayatPasien.Image = Global.PoliKlinik_Net2.My.Resources.Resources.icons8_send_24
        Me.ButtonCariRiwayatPasien.Location = New System.Drawing.Point(148, 0)
        Me.ButtonCariRiwayatPasien.Name = "ButtonCariRiwayatPasien"
        Me.ButtonCariRiwayatPasien.Padding = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.ButtonCariRiwayatPasien.Size = New System.Drawing.Size(200, 41)
        Me.ButtonCariRiwayatPasien.TabIndex = 5
        Me.ButtonCariRiwayatPasien.Text = "  Cari Riwayat Pasien"
        Me.ButtonCariRiwayatPasien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonCariRiwayatPasien.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ButtonCariRiwayatPasien.UseVisualStyleBackColor = False
        '
        'PanelKesadaranMenuPemeriksaanAwal
        '
        Me.PanelKesadaranMenuPemeriksaanAwal.BackColor = System.Drawing.Color.Transparent
        Me.PanelKesadaranMenuPemeriksaanAwal.Controls.Add(Me.RadioButtonOpsiNIK)
        Me.PanelKesadaranMenuPemeriksaanAwal.Controls.Add(Me.RadioButtonOpsiNomorKartu)
        Me.PanelKesadaranMenuPemeriksaanAwal.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.PanelKesadaranMenuPemeriksaanAwal.Location = New System.Drawing.Point(50, 15)
        Me.PanelKesadaranMenuPemeriksaanAwal.Name = "PanelKesadaranMenuPemeriksaanAwal"
        Me.PanelKesadaranMenuPemeriksaanAwal.Size = New System.Drawing.Size(200, 25)
        Me.PanelKesadaranMenuPemeriksaanAwal.TabIndex = 475
        '
        'RadioButtonOpsiNIK
        '
        Me.RadioButtonOpsiNIK.AutoSize = True
        Me.RadioButtonOpsiNIK.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonOpsiNIK.Location = New System.Drawing.Point(111, 3)
        Me.RadioButtonOpsiNIK.Name = "RadioButtonOpsiNIK"
        Me.RadioButtonOpsiNIK.Size = New System.Drawing.Size(47, 21)
        Me.RadioButtonOpsiNIK.TabIndex = 441
        Me.RadioButtonOpsiNIK.Text = "NIK"
        Me.RadioButtonOpsiNIK.UseVisualStyleBackColor = True
        '
        'RadioButtonOpsiNomorKartu
        '
        Me.RadioButtonOpsiNomorKartu.AutoSize = True
        Me.RadioButtonOpsiNomorKartu.Checked = True
        Me.RadioButtonOpsiNomorKartu.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.RadioButtonOpsiNomorKartu.Location = New System.Drawing.Point(5, 3)
        Me.RadioButtonOpsiNomorKartu.Name = "RadioButtonOpsiNomorKartu"
        Me.RadioButtonOpsiNomorKartu.Size = New System.Drawing.Size(103, 21)
        Me.RadioButtonOpsiNomorKartu.TabIndex = 245
        Me.RadioButtonOpsiNomorKartu.TabStop = True
        Me.RadioButtonOpsiNomorKartu.Text = "Nomor Kartu"
        Me.RadioButtonOpsiNomorKartu.UseVisualStyleBackColor = True
        '
        'DialogBoxRiwayatPerawatanICare
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(348, 163)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PanelTop)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "DialogBoxRiwayatPerawatanICare"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Panel1.ResumeLayout(False)
        Me.SplitContainerInformedConcent.Panel1.ResumeLayout(False)
        Me.SplitContainerInformedConcent.Panel1.PerformLayout()
        Me.SplitContainerInformedConcent.Panel2.ResumeLayout(False)
        Me.SplitContainerInformedConcent.ResumeLayout(False)
        Me.PanelKesadaranMenuPemeriksaanAwal.ResumeLayout(False)
        Me.PanelKesadaranMenuPemeriksaanAwal.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelTop As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents SplitContainerInformedConcent As System.Windows.Forms.SplitContainer
    Friend WithEvents ButtonCariRiwayatPasien As System.Windows.Forms.Button
    Friend WithEvents ButtonBatal As System.Windows.Forms.Button
    Friend WithEvents TextBoxNoIdentitas As System.Windows.Forms.TextBox
    Friend WithEvents PanelKesadaranMenuPemeriksaanAwal As System.Windows.Forms.Panel
    Friend WithEvents RadioButtonOpsiNIK As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButtonOpsiNomorKartu As System.Windows.Forms.RadioButton
End Class
