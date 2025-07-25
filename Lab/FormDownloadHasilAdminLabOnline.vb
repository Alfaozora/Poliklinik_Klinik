Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraReports.UI
Imports System.Drawing.Text
Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Object
Imports Newtonsoft.Json
Imports Newtonsoft
Imports System.Security.Cryptography
Imports System.Collections.Generic
Imports Newtonsoft.Json.Linq
Imports KASLibrary

Public Class FormDownloadHasilAdminLabOnline


    Public Class container
        Public response As Pendaftaran
        Public metaData As MetaData
    End Class

    Public Sub LoadFormDownloadHasilAdminLabOnline(ByRef txkode As String, ByRef txlocationket As String)
        'txnamacabang.Text = txlocationket
        'txkodecabang.Text = txkode
    End Sub

    Private Sub SetClear()
        'cmbfaskes
        Dim faskes As String = ReadSQLNIK("select StrValue from MsConfig where ConfigName='NamaPPK'")
        cmbfaskes.Items.Clear()
        cmbfaskes.Items.Add(faskes)

        dttglpendaftaran.Value = DateAndTime.Now
        cmbjeniskunjungan.SelectedIndex = 0
        cmbfaskes.SelectedIndex = 0
        disablebutton()
        gridpoli.DataSource = CreateTable()

    End Sub

    Function CreateTable() As DataTable
        Dim Thasil As New DataTable

        insertRowToTbls(Thasil, "Typstring", "NO")
        insertRowToTbls(Thasil, "Typstring", "NO KARTU")
        insertRowToTbls(Thasil, "Typstring", "NAMA PESERTA")
        insertRowToTbls(Thasil, "Typstring", "KELAMIN")
        insertRowToTbls(Thasil, "Typstring", "USIA")
        insertRowToTbls(Thasil, "Typstring", "POLI_KEGIATAN")
        insertRowToTbls(Thasil, "Typstring", "STATUS")
        insertRowToTbls(Thasil, "Typstring", "tgldaftar")
        insertRowToTbls(Thasil, "Typstring", "kdPoli")
        insertRowToTbls(Thasil, "typchecked", "HAPUS")

        For Each Tcol As DataColumn In Thasil.Columns
            Tcol.ReadOnly = True
        Next

        Thasil.Columns("HAPUS").ReadOnly = False
        'Thasil.Columns("Closed").ReadOnly = False

        Return Thasil
    End Function

    Private Sub Loadtable()
        Dim Tquery As String = ""
        Dim Tjenispembayaran As String = ""
        Dim Tjenistransaksi As String = ""
        Dim Tlokasi As String = ""
        Dim Torder As String = ""
        Dim DefaultURL As String = ReadSQLNIK("select StrValue from MsConfig where ConfigName='URLdefault_BPJS'")

        If GridView1.RowCount > 0 Then GridView1.SelectRow(0)

        Dim uri As String = ""
        Dim tglpendaftaran As String = Format(dttglpendaftaran.Value, "dd-MM-yyyy")
        uri = DefaultURL + "pendaftaran/tglDaftar/" + tglpendaftaran + "/0/3"

        Dim rawresp As String = "[" & GetDataAPI(uri) & "]"
        Dim varses() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of container())(rawresp)

        Dim Tdata As DataTable = gridpoli.DataSource
        Tdata.Rows.Clear()

        Dim Tkondisi As String = ""
        If cmbjeniskunjungan.SelectedIndex = 0 Then
            Tkondisi = ""
        ElseIf cmbjeniskunjungan.SelectedIndex = 1 Then
            Tkondisi = False
        ElseIf cmbjeniskunjungan.SelectedIndex = 2 Then
            Tkondisi = True
        End If

        For Each oneVar As container In varses
            ' Avoid Nothing vars.
            If oneVar IsNot Nothing Then
                If oneVar.metaData.message = "NO_CONTENT" Then
                    MsgBox("Data Tidak Ditemukan!!")
                    Exit Sub
                End If

                For index As Integer = 0 To oneVar.response.count - 1
                    If oneVar.response.list(index).kunjSakit <> Tkondisi Then
                        Dim Tnew As DataRow = Tdata.NewRow
                        Tnew("NO") = oneVar.response.list(index).noUrut
                        Tnew("NO KARTU") = oneVar.response.list(index).peserta.noKartu
                        Tnew("NAMA PESERTA") = oneVar.response.list(index).peserta.nama
                        Tnew("KELAMIN") = oneVar.response.list(index).peserta.sex

                        'Dim tgllahir As String = Format(oneVar.response.list(index).peserta.tglLahir, "dd-MM-yyyy")
                        Dim Tgllahir As Date = DateTime.ParseExact(oneVar.response.list(index).peserta.tglLahir, "dd-MM-yyyy", Nothing).ToString("MM/dd/yyyy")
                        Tnew("USIA") = Umur(Tgllahir)
                        Tnew("POLI_KEGIATAN") = oneVar.response.list(index).poli.nmPoli
                        'Tnew("SUMBER") = "-"
                        Tnew("STATUS") = oneVar.response.list(index).status
                        Tnew("tgldaftar") = oneVar.response.list(index).tgldaftar
                        Tnew("kdPoli") = oneVar.response.list(index).poli.kdPoli
                        Tdata.Rows.Add(Tnew)
                    End If
                Next
            End If
        Next

        For Each Tcol As DataColumn In Tdata.Columns
            Tcol.ReadOnly = True
        Next
        Tdata.Columns("HAPUS").ReadOnly = False
        gridpoli.DataSource = Tdata

        GridView1.Columns("NO").Width = 50
        GridView1.Columns("KELAMIN").Width = 100
        GridView1.Columns("HAPUS").Width = 100
        GridView1.Columns("STATUS").Width = 100
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub FormDownloadHasilAdminLabOnline_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        'SetClear()
        'LoadData()
        'disablebutton()

        TabPage2.Hide()
        TabPage3.Hide()
        TabPage4.Hide()
        TabControl1.TabPages.Remove(TabPage2)
        TabControl1.TabPages.Remove(TabPage3)
        TabControl1.TabPages.Remove(TabPage4)
    End Sub

    Public Sub disablebutton()
        butfindnotagihan.Enabled = False
        butrekappasien.Enabled = False
        Button3.Enabled = False
        dtakhirbayar.Enabled = False
        chkeditbayar.Enabled = False
        Button5.Enabled = False
    End Sub

    Public Sub enablebutton()
        butfindnotagihan.Enabled = True
        butrekappasien.Enabled = True
        Button3.Enabled = True
        dtakhirbayar.Enabled = True
        chkeditbayar.Enabled = True
        Button5.Enabled = True
    End Sub

    Private Sub ClearToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearToolStripMenuItem.Click
        SetClear()
    End Sub

    Private Sub butdisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        enablebutton()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'Pembayaran.SetClear()
        'Pembayaran.cmbbayar.SelectedIndex = -1
        'Pembayaran.ShowDialog()
    End Sub

    Private Sub chkedit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkeditbayar.CheckedChanged
        If chkeditbayar.CheckState = CheckState.Checked Then
            dtawalbayar.Enabled = True
        Else
            dtawalbayar.Enabled = False
            dtawalbayar.Value = DateSerial("2001", "1", "1")
        End If
    End Sub

    Private Sub SetClearTagihan()
        txnotagihan.ResetText()
        txtagihanid.ResetText()
        butrekappasien.Enabled = True
    End Sub

    Public Sub SetGridBaru(ByRef Trow() As DataRow)
        Dim Tstr As String = "("
        For i As Integer = 0 To Trow.Length - 1
            Tstr = Tstr + "'" & Trow(i)("ID").ToString & "',"
        Next

        Dim Ttdataawal As DataTable = gridtrans.DataSource

        Dim Tdata As DataTable = gridtrans.DataSource
        Tdata.AcceptChanges()
        For Each Tgrid As DataRow In Tdata.Rows
            Tstr = Tstr + "'" & Tgrid("ID").ToString & "',"
        Next

    End Sub

    Private Sub btnviewtunai_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnviewriwayatpeserta.Click
        'Dim Tbls As DataTable = ReadThemysql("SELECT a.kodecabang, a.kodebarcode, a.kodeket FROM mastercodebarcode a ORDER BY a.kodeket ASC", TtOL)
        'Dim Tdata As DataTable = gridpoli.DataSource
        'gridpoli.DataSource = Tbls

        'If Tbls.Rows.Count > 0 Then
        '    For Each Trow As DataRow In Tbls.Rows
        '        Dim Tnew As DataRow = Tdata.NewRow
        '        Tnew("kodecabang") = Trow("kodecabang")
        '        Tnew("kodebarcode") = Trow("kodebarcode")
        '        Tnew("kodeket") = Trow("kodeket")
        '        Tdata.Rows.Add(Tnew)
        '        'GridView1.AddNewRow()
        '        'GridView1.SetRowCellValue(GridView1.FocusedRowHandle, GridView1.Columns("kodecabang"), "" & Trow("kodecabang") & "")
        '        'GridView1.SetRowCellValue(GridView1.FocusedRowHandle, GridView1.Columns("kodebarcode"), "" & Trow("kodebarcode") & "")
        '        'GridView1.SetRowCellValue(GridView1.FocusedRowHandle, GridView1.Columns("kodeket"), "" & Trow("kodeket") & "")
        '        'GridView1.UpdateCurrentRow()
        '        'gridpoli.Rows.Add(New String() {"" & Trow("kodecabang") & "", "" & Trow("kodebarcode") & "", "" & Trow("kodeket") & ""})
        '    Next
        '    gridpoli.DataSource = Tdata
        'End If

        'Loadtable()
        'enablebutton()
    End Sub

    Private Sub butsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butsave.Click
        If MsgBox("Yakin Data yang dipilih akan dihapus?", MsgBoxStyle.YesNoCancel) = MsgBoxResult.Yes Then

            Dim Ttable As DataTable = gridpoli.DataSource
            Dim uri As String = ""
            Dim messageDel As String = ""
            Dim tglpoli As String = ""
            Dim nourut As String = ""
            Ttable.AcceptChanges()

            Dim jumlah As Integer = 0
            Dim trfid As Integer = 0

            For Each Trownew As DataRow In Ttable.Select("[HAPUS]=1")
                jumlah = jumlah + 1
                Dim DefaultURL As String = ReadSQLNIK("select StrValue from MsConfig where ConfigName='URLdefault_BPJS'")
                uri = DefaultURL + "pendaftaran/peserta/" + Trownew("NO KARTU") + "/tglDaftar/" + Trownew("tgldaftar") + "/noUrut/" + Trownew("NO") + "/kdPoli/" + Trownew("kdPoli")
                messageDel = "Data Atas Nama " + Trownew("NAMA PESERTA") + " & No Urut " + Trownew("NO") + " Berhasil Dihapus."
                tglpoli = Trownew("tgldaftar")
                nourut = Trownew("NO")
            Next

            If jumlah = 0 Then
                MsgBox("Pilih Data Terlebih Dahulu.")
            ElseIf jumlah = 1 Then
                Dim NewTglPoli As Date = DateTime.ParseExact(tglpoli, "dd-MM-yyyy", Nothing).ToString("MM/dd/yyyy")
                'Dim var As String = deleteDataBPJS(uri) ' Harusnya Aktif
                Dim var As String = ""
                If var = "Nothing" Then
                    MsgBox("Gagal Hapus Data Riwayat Pendaftaran.")
                Else
                    Dim varses() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of container())(var)

                    For Each oneVar2 As container In varses
                        If oneVar2.metaData.message = "OK" Then
                            Dim NoTransaksi As String = ReadSQLNIK("select NoTransaksi from TransaksiDetail where TanggalTransaksi='" + NewTglPoli + "' and NoUrutBPJS='" + nourut + "'")
                            Dim JenisTransaksi As String = ReadSQLNIK("select JenisTransaksi from TransaksiDetail where TanggalTransaksi='" + NewTglPoli + "' and NoUrutBPJS='" + nourut + "'")
                            If JenisTransaksi = "POLI" Then
                                WriteSQL("update TransaksiPoli set deleted=1, deletedby='" & PoliKlinik.Lbluser.Text & "', deleteddate='" & Format(DateAndTime.Now, "MM/dd/yyyy") & "' where Transpoliid='" & NoTransaksi & "'", 4)
                                WriteSQL("update TransaksiDetail set deleted=1, deletedby='" & PoliKlinik.Lbluser.Text & "', deleteddate='" & Format(DateAndTime.Now, "MM/dd/yyyy") & "' where NoTransaksi='" & NoTransaksi & "' and JenisTransaksi='POLI'", 4)
                            ElseIf JenisTransaksi = "GIGI" Then
                                WriteSQL("update TransaksiGigi set deleted=1, deletedby='" & PoliKlinik.Lbluser.Text & "', deleteddate='" & Format(DateAndTime.Now, "MM/dd/yyyy") & "' where Transgigiid='" & NoTransaksi & "'", 4)
                                WriteSQL("update TransaksiDetail set deleted=1, deletedby='" & PoliKlinik.Lbluser.Text & "', deleteddate='" & Format(DateAndTime.Now, "MM/dd/yyyy") & "' where NoTransaksi='" & NoTransaksi & "' and JenisTransaksi='GIGI'", 4)
                            ElseIf JenisTransaksi = "LAB" Then
                                WriteSQL("update TransaksiLab set deleted=1, deletedby='" & PoliKlinik.Lbluser.Text & "', deleteddate='" & Format(DateAndTime.Now, "MM/dd/yyyy") & "' where Translabid='" & NoTransaksi & "'", 4)
                                WriteSQL("update TransaksiDetail set deleted=1, deletedby='" & PoliKlinik.Lbluser.Text & "', deleteddate='" & Format(DateAndTime.Now, "MM/dd/yyyy") & "' where NoTransaksi='" & NoTransaksi & "'  and JenisTransaksi='LAB'", 4)
                            End If
                            MsgBox(messageDel)
                        Else
                            MsgBox(oneVar2.metaData.message)
                        End If
                    Next
                End If
            Else
                MsgBox("Hanya Boleh Memilih 1 Data yang kan Dihapus.")
            End If

            btnviewriwayatpeserta.PerformClick()
        End If
    End Sub
End Class

