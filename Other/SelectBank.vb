Imports System.Windows.Forms

Public Class SelectBank
    ' Set Connection
    Private DB_Keuangan As TLcon

    Private Sub SetConnectionFromConfig()
        ' Set Parameter Server Online
        Dim serverOnline_IP As String = Utility.GetConfig("ServerOnline_IP")
        Dim serverOnline_UserID As String = Utility.GetConfig("ServerOnline_UserID")
        Dim serverOnline_Password As String = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerOnline_Password"), "albert")

        ' Set DB Keuangan 1 (mitramed_keu)
        DB_Keuangan.Tip = serverOnline_IP
        DB_Keuangan.Tid = serverOnline_UserID
        DB_Keuangan.Tpass = serverOnline_Password
        DB_Keuangan.Tdb = Utility.GetConfig("ServerOnlineKeuangan_DB")
    End Sub

    Public Sub LoadOptionDialog(ByRef Tjenis As String, ByRef Tjudul As String)
        txjenis.Text = Tjenis
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If cmbbank.Text <> "" Then
            Select Case txjenis.Text
                Case "SetBankReportTagihanLabInvoice"
                    RekapTagihanLab.txnamarek.Text = txbanknama.Text
                    RekapTagihanLab.txnorek.Text = txnomorrek.Text
                    RekapTagihanLab.txnamabank.Text = txnamabank.Text
                    RekapTagihanLab.txbankid.Text = txbankid.Text
                Case "SetBankReportPendapatanPoliInvoice"
                    RekapPendapatanPoli.txnamarek.Text = txbanknama.Text
                    RekapPendapatanPoli.txnorek.Text = txnomorrek.Text
                    RekapPendapatanPoli.txnamabank.Text = txnamabank.Text
                    RekapPendapatanPoli.txbankid.Text = txbankid.Text
                Case Else : MsgBox("Error...")
            End Select
        Else
            MsgBox("Pilih Bank Terlebih Dahulu.")
            Exit Sub
        End If

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Select Case txjenis.Text
            Case "SetBankReportTagihanLabInvoice"
                RekapTagihanLab.txnamarek.ResetText()
                RekapTagihanLab.txnorek.ResetText()
                RekapTagihanLab.txnamabank.ResetText()
                cmbbank.Items.Clear()
            Case "SetBankReportPendapatanPoliInvoice"
                RekapPendapatanPoli.txnamarek.ResetText()
                RekapPendapatanPoli.txnorek.ResetText()
                RekapPendapatanPoli.txnamabank.ResetText()
                cmbbank.Items.Clear()
            Case Else : MsgBox("Error...")
        End Select

        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub SelectBank_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetBank()
    End Sub

    Private Sub SetBank()
        ' Inisialisasi koneksi ke database MySQL
        SetConnectionFromConfig()

        cmbbank.Items.Clear()
        Dim Tbls As DataTable = ReadThemysql("SELECT CONCAT(namabank,'-',norekening) AS Bank FROM accmasterbank WHERE bankpembayarantagihan IS TRUE AND coa IS NOT NULL AND (coa <> '' OR coa <> '-')", DB_Keuangan)
        For Each Trow As DataRow In Tbls.Rows
            cmbbank.Items.Add(Trow("Bank").ToString)
        Next

        cmbbank.SelectedIndex = -1
        CheckBank()
    End Sub

    Private Sub CheckBank()
        If cmbbank.SelectedIndex = -1 Then
            txbankid.ResetText()
            txbanknama.ResetText()
            txnomorrek.ResetText()
            txnamabank.ResetText()
        Else
            If cmbbank.FindStringExact(cmbbank.Text) >= 0 Then
                Dim Tsplit() As String = cmbbank.Text.Split("-")
                Dim jenisbank As String = ""
                Dim Tbls As DataTable = ReadThemysql("SELECT * FROM accmasterbank where namabank='" & Tsplit(0).ToString & "'", DB_Keuangan)
                If Tbls.Rows.Count > 0 Then
                    Dim Rrow As DataRow = Tbls.Rows(0)
                    txbankid.Text = Rrow("bankid")
                    txbanknama.Text = Rrow("namarekening")
                    txnomorrek.Text = Rrow("norekening")

                    jenisbank = Rrow("namabank")
                    If jenisbank.Contains("BCA") = True Then
                        txnamabank.Text = "BCA - " & "CABANG " & Rrow("cabangrekening")
                    ElseIf jenisbank.Contains("BNI") = True Then
                        txnamabank.Text = "BNI - " & "CABANG " & Rrow("cabangrekening")
                    ElseIf jenisbank.Contains("MANDIRI") = True Then
                        txnamabank.Text = "MANDIRI - " & "CABANG " & Rrow("cabangrekening")
                    ElseIf jenisbank.Contains("NIAGA") = True Then
                        txnamabank.Text = "NIAGA - " & "CABANG " & Rrow("cabangrekening")
                    ElseIf jenisbank.Contains("HSBC") = True Then
                        txnamabank.Text = "HSBC - " & "CABANG " & Rrow("cabangrekening")
                    ElseIf jenisbank.Contains("BANK MAS") = True Then
                        txnamabank.Text = "BANK MAS - " & "CABANG " & Rrow("cabangrekening")
                    Else
                        txnamabank.Text = Rrow("cabangrekening")
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub cmbbank_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbbank.SelectedIndexChanged
        CheckBank()
    End Sub
End Class
