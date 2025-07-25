Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
Imports System.Drawing
Imports Newtonsoft.Json
Imports Newtonsoft
Imports System.Security.Cryptography
Imports System.Collections.Generic
Imports Newtonsoft.Json.Linq
Imports System.Web.UI.WebControls
Imports DevExpress.XtraGrid.Columns
Imports System.Text

Public Class DialogBoxPaketTindakan
    Private formName As String = "PENCARIAN PAKET"
    Private formInput As String = ""
    Private userInput As String = PoliKlinik.Lbluser.Text

    Private Sub PanelTop_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelTop.Paint
        Try
            e.Graphics.DrawString(formName, New Font("Arial", 12, FontStyle.Bold), Brushes.White, New Point(10, 10))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Function CreateTablePaket() As DataTable
        Dim Thasil As New DataTable

        insertRowToTbls(Thasil, "Typstring", "PaketID")
        insertRowToTbls(Thasil, "Typstring", "TindakanID")
        insertRowToTbls(Thasil, "Typstring", "KodeVoucher")
        insertRowToTbls(Thasil, "Typstring", "Nama Paket")
        insertRowToTbls(Thasil, "Typstring", "Keterangan Paket")
        insertRowToTbls(Thasil, "Typstring", "Keterangan Tindakan")
        insertRowToTbls(Thasil, "Typstring", "Tanggal Mulai")
        insertRowToTbls(Thasil, "Typstring", "Tanggal Berakhir")
        insertRowToTbls(Thasil, "Typstring", "Kuota")
        insertRowToTbls(Thasil, "Typstring", "Penjamin")
        insertRowToTbls(Thasil, "Typstring", "Harga Awal")
        insertRowToTbls(Thasil, "Typstring", "Diskon")
        insertRowToTbls(Thasil, "Typstring", "Harga Nett")
        insertRowToTbls(Thasil, "Typstring", "Jenis Paket")
        insertRowToTbls(Thasil, "typchecked", "Pilihan")

        For Each Tcol As DataColumn In Thasil.Columns
            Tcol.ReadOnly = True
        Next

        Return Thasil
    End Function

    Private Sub ButtonFindPaket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonFindPaket.Click
        PencarianPaket()
    End Sub

    Private Sub PencarianPaket()
        Try
            If ValidasiPencarian() = True Then
                Dim queryBuilder As New StringBuilder()

                ' Query Paket Reguler
                queryBuilder.AppendLine("SELECT tblHeader.NoRekamMedis, tblHeader.NoTransaksi, tblHeader.PaketID, '0' AS TindakanID,")
                queryBuilder.AppendLine("       tblHeader.NamaPaket, tblHeader.KeteranganPaket,")
                queryBuilder.AppendLine("       tblHeader.JenisPaket, tblHeader.TanggalMulaiPaket, tblHeader.TanggalAkhirPaket,")
                queryBuilder.AppendLine("       tblHeader.HargaAwal, tblHeader.DiskonNominal,")
                queryBuilder.AppendLine("       tblHeader.HargaNett, tblHeader.Kuota AS Kuota,") ' Kuota dari tblHeader
                queryBuilder.AppendLine("       tblHeader.Penjamin, tblHeader.KodeVoucher")
                queryBuilder.AppendLine("FROM TransaksiPaketTindakan tblHeader")
                queryBuilder.AppendLine("WHERE tblHeader.KodeVoucher = '" & TextBoxKodeVoucher.Text & "'")
                queryBuilder.AppendLine("      AND (GETDATE() BETWEEN ISNULL(tblHeader.TanggalMulaiPaket, GETDATE())")
                queryBuilder.AppendLine("      AND ISNULL(tblHeader.TanggalAkhirPaket, GETDATE()))")
                queryBuilder.AppendLine("      AND tblHeader.DeletedDate IS NULL")
                queryBuilder.AppendLine("      AND tblHeader.Kuota > 0") ' Kuota dari Header
                queryBuilder.AppendLine("      AND tblHeader.JenisPaket = 'Paket Reguler'")

                queryBuilder.AppendLine("UNION ALL")

                ' Query Paket Per-Tindakan
                queryBuilder.AppendLine("SELECT tblHeader.NoRekamMedis, tblHeader.NoTransaksi, tblHeader.PaketID, tblDetail.TindakanID,")
                queryBuilder.AppendLine("       tblDetail.NamaTindakan AS NamaPaket, tblDetail.JenisTindakan AS KeteranganPaket,")
                queryBuilder.AppendLine("       tblHeader.JenisPaket, tblHeader.TanggalMulaiPaket, tblHeader.TanggalAkhirPaket,")
                queryBuilder.AppendLine("       tblDetail.BiayaTindakan AS HargaAwal, tblDetail.DiskonTindakan AS DiskonNominal,")
                queryBuilder.AppendLine("       tblDetail.NettBayar AS HargaNett, tblDetail.KuotaTindakan AS Kuota,") ' Kuota dari tblDetail
                queryBuilder.AppendLine("       tblHeader.Penjamin, tblHeader.KodeVoucher")
                queryBuilder.AppendLine("FROM TransaksiPaketTindakanDetail AS tblDetail")
                queryBuilder.AppendLine("     INNER JOIN TransaksiPaketTindakan AS tblHeader")
                queryBuilder.AppendLine("     ON tblDetail.PaketID = tblHeader.PaketID AND tblDetail.KodeVoucher = tblHeader.KodeVoucher")
                queryBuilder.AppendLine("WHERE tblHeader.KodeVoucher = '" & TextBoxKodeVoucher.Text & "'")
                queryBuilder.AppendLine("      AND (GETDATE() BETWEEN ISNULL(tblHeader.TanggalMulaiPaket, GETDATE())")
                queryBuilder.AppendLine("      AND ISNULL(tblHeader.TanggalAkhirPaket, GETDATE()))")
                queryBuilder.AppendLine("      AND tblHeader.DeletedDate IS NULL")
                queryBuilder.AppendLine("      AND tblDetail.KuotaTindakan > 0") ' Kuota dari Detail
                queryBuilder.AppendLine("      AND tblHeader.JenisPaket = 'Paket Per-Tindakan'")

                Dim tblPaket As DataTable = ReadSQL(queryBuilder.ToString())

                If tblPaket.Rows.Count > 0 Then
                    Dim gridPaket As DataTable = GridControlPaket.DataSource
                    gridPaket.Clear()

                    For Each rowPaket As DataRow In tblPaket.Rows
                        Dim newRow As DataRow = gridPaket.NewRow
                        newRow("PaketID") = rowPaket("PaketID").ToString()
                        newRow("TindakanID") = rowPaket("TindakanID").ToString()
                        newRow("KodeVoucher") = rowPaket("KodeVoucher").ToString()
                        newRow("Nama Paket") = rowPaket("NamaPaket").ToString()
                        newRow("Keterangan Paket") = rowPaket("KeteranganPaket").ToString()
                        newRow("Keterangan Tindakan") = rowPaket("KeteranganPaket").ToString()
                        newRow("Tanggal Mulai") = Format(rowPaket("TanggalMulaiPaket"), "yyyy-MM-dd")
                        newRow("Tanggal Berakhir") = Format(rowPaket("TanggalAkhirPaket"), "yyyy-MM-dd")
                        newRow("Kuota") = rowPaket("Kuota").ToString()
                        newRow("Penjamin") = rowPaket("Penjamin").ToString()
                        newRow("Harga Awal") = Splitmoney(rowPaket("HargaAwal"))
                        newRow("Diskon") = Splitmoney(rowPaket("DiskonNominal"))
                        newRow("Harga Nett") = Splitmoney(rowPaket("HargaNett"))
                        newRow("Jenis Paket") = Splitmoney(rowPaket("JenisPaket"))
                        gridPaket.Rows.Add(newRow)
                    Next

                    GridViewPaket.ExpandAllGroups()
                Else
                    MsgBox("Data tidak ditemukan.", MsgBoxStyle.Critical, "Warning!")
                End If
            End If
        Catch ex As Exception
            MsgBox("Eror : " & ex.Message, MsgBoxStyle.Exclamation, "Error!")
        End Try
    End Sub

    Function ValidasiPencarian() As Boolean
        If TextBoxKodeVoucher.Text = "" Then
            MsgBox("Kode Voucher Tidak Boleh Kosong.", MsgBoxStyle.Critical, "Warning!")
            Return False
        End If

        Return True
    End Function

    Private Sub DialogBoxPaketTindakan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBoxKodeVoucher.Focus()
        TextBoxKodeVoucher.ResetText()

        SetDataGrid()
    End Sub

    Private Sub SetDataGrid()
        Dim tblPaket As DataTable = CreateTablePaket()

        tblPaket.Columns("Pilihan").ReadOnly = False
        GridControlPaket.DataSource = tblPaket
        GridViewPaket.BestFitColumns()
        GridViewPaket.Columns("PaketID").Visible = False
        GridViewPaket.Columns("TindakanID").Visible = False
        GridViewPaket.Columns("KodeVoucher").Visible = False
        GridViewPaket.Columns("Tanggal Mulai").Visible = False
        GridViewPaket.Columns("Penjamin").Visible = False
        GridViewPaket.Columns("Harga Awal").Visible = False
        GridViewPaket.Columns("Diskon").Visible = False
        GridViewPaket.Columns("Keterangan Tindakan").Visible = False

        GridViewPaket.SortInfo.ClearAndAddRange(New GridColumnSortInfo() _
                                                {New GridColumnSortInfo(GridViewPaket.Columns("Jenis Paket"), DevExpress.Data.ColumnSortOrder.Ascending) _
                                                 }, 1)
    End Sub

    Private Sub TextBoxKodeVoucher_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxKodeVoucher.KeyDown
        If e.KeyCode = Keys.Enter Then PencarianPaket()
    End Sub

    Private Sub ButtonBatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBatal.Click
        Me.Close()
    End Sub

    Private Sub ButtonSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSimpan.Click
        Dim tblPaket As DataTable = GridControlPaket.DataSource
        Dim rowPaket() As DataRow = tblPaket.Select("[Pilihan]=1")

        If rowPaket.Count > 0 Then
            Me.Close()
            Select Case formInput
                Case "Pendaftaran Awal"
                    FormPendaftaranAwal.LoadTindakanPaketQR(rowPaket)
                Case "Perencanaan Tindakan"
                    FormRekamMedisDokter.SubmitPotongPaket(rowPaket)
                Case Else
                    MsgBox("Error...")
            End Select
        Else
            MsgBox("Tidak ada data yang dipilih.", MsgBoxStyle.Critical, "Warning!")
        End If
    End Sub

    Public Sub SetForm(ByVal NamaForm As String)
        formInput = NamaForm
    End Sub
End Class