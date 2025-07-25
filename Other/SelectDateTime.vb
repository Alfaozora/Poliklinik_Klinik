Imports System.Windows.Forms

Public Class SelectDateTime

    Public Sub LoadOptionDialog(ByRef Tjenis As String, ByRef Tjudul As String)
        txjenis.Text = Tjenis
        lbldatetime.Text = Tjudul
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If txdatetime.Text <> "" Then
            Select Case txjenis.Text
                Case "TanggalReportSummaryMCUOnline"
                    ReportSummaryMCUOnline.txtanggal.Text = txdatetime.Text
                    ReportSummaryMCUOnline.txlbltanggal.Text = txdatetime.Text
                Case "TanggalReportSummaryMCU"
                    ReportSummaryMCU.TextBoxTglTransaksi.Text = txdatetime.Text
                    ReportSummaryMCU.txlbltanggal.Text = txdatetime.Text
                Case "TanggalReportTagihanLabInvoice"
                    RekapTagihanLab.txtgljatuhtempo.Text = txdatetime.Text
                Case "TanggalReportPendapatanPoliInvoice"
                    RekapPendapatanPoli.txtgljatuhtempo.Text = txdatetime.Text
                Case Else : MsgBox("Error...")
            End Select
        Else
            MsgBox("Pilih Tanggal Terlebih Dahulu.")
            Exit Sub
        End If

        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Select Case txjenis.Text
            Case "TanggalReportSummaryMCUOnline"
                ReportSummaryMCUOnline.txtanggal.ResetText()
                ReportSummaryMCUOnline.txlbltanggal.Text = ""
            Case "TanggalReportSummaryMCU"
                ReportSummaryMCU.TextBoxTglTransaksi.ResetText()
                ReportSummaryMCU.txlbltanggal.Text = ""
            Case "SetBankReportTagihanLabInvoice"
                RekapTagihanLab.txtgljatuhtempo.ResetText()
            Case "TanggalReportPendapatanPoliInvoice"
                RekapPendapatanPoli.txtgljatuhtempo.ResetText()
            Case Else : MsgBox("Error...")
        End Select

        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub MonthCalendar1_DateChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DateRangeEventArgs) Handles MonthCalendar1.DateChanged
        'txdatetime.Text = Me.MonthCalendar1.SelectionStart.Date
        txdatetime.Text = Me.MonthCalendar1.SelectionStart.Year & "-" & Me.MonthCalendar1.SelectionStart.Month & "-" & Me.MonthCalendar1.SelectionStart.Day
    End Sub

    Private Sub SelectDateTime_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txdatetime.Text = DateAndTime.Now.Year & "-" & DateAndTime.Now.Month & "-" & DateAndTime.Now.Day
    End Sub
End Class
