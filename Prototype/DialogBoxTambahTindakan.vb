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

Public Class DialogBoxTambahTindakan
    Private formName As String = "Tindakan"
    Private TForm As String
    Private _dataDictionary As Dictionary(Of String, Object)

    '# Variabel FormFindTransaksi
    Private _statusTransaksi As String = ""
    Private _noTransaksi As String = ""
    Private _noRM As String = ""
    Private _jenisPoli As String = ""
    Private _jenisUser As String = ""

    Public Property DataDictionary() As Dictionary(Of String, Object)
        Get
            Return _dataDictionary
        End Get
        Set(ByVal value As Dictionary(Of String, Object))
            _dataDictionary = value

            _statusTransaksi = GetValueFromDictionary("Status Transaksi", "")
            _noTransaksi = GetValueFromDictionary("No Transaksi", "")
            _noRM = GetValueFromDictionary("No RM", "")
            _jenisPoli = GetValueFromDictionary("Jenis Poli", "")
            _jenisUser = GetValueFromDictionary("Jenis User", "")
        End Set
    End Property

    Private Function GetValueFromDictionary(ByVal key As String, ByVal defaultValue As Object) As Object
        If _dataDictionary.ContainsKey(key) Then
            Return _dataDictionary(key)
        Else
            Return defaultValue
        End If
    End Function

    Private Sub PanelTop_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PanelTop.Paint
        Try
            e.Graphics.DrawString(formName, New Font("Arial", 12, FontStyle.Bold), Brushes.White, New Point(10, 10))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub SetAwal()
        Me.CenterToScreen()
    End Sub

    Private Sub Find_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SetAwal()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub ButtonPanggilPasien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        MsgBox("Fitur ini belum tersedia.", MsgBoxStyle.Exclamation, "Warning!")
    End Sub

    Private Sub ButtonMulaiPemeriksaan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonMulaiPemeriksaan.Click
        Me.Close()
        If _statusTransaksi = "Belum Diperiksa" And _jenisUser.Contains("Dokter") = False Then
            ' Update status transaksi menjadi > Sedang Diperiksa
            If _jenisPoli = "UMUM" Or _jenisPoli = "POLI" Then
                WriteSQL("UPDATE TransaksiPoli SET StatusKeterangan = 'Sedang Diperiksa' WHERE NoUrut = '" & _noTransaksi & "'", 4)
            ElseIf _jenisPoli = "GIGI" Then
                WriteSQL("UPDATE TransaksiGigi SET StatusKeterangan = 'Sedang Diperiksa' WHERE NoUrut = '" & _noTransaksi & "'", 4)
            End If
        ElseIf _statusTransaksi = "Sedang Diperiksa" And _jenisUser.Contains("Dokter") = True Then
            ' Update status transaksi menjadi > Sedang Diperiksa Dokter
            If _jenisPoli = "UMUM" Or _jenisPoli = "POLI" Then
                WriteSQL("UPDATE TransaksiPoli SET StatusKeterangan = 'Sedang Diperiksa Dokter' WHERE NoUrut = '" & _noTransaksi & "'", 4)
            ElseIf _jenisPoli = "GIGI" Then
                WriteSQL("UPDATE TransaksiGigi SET StatusKeterangan = 'Sedang Diperiksa Dokter' WHERE NoUrut = '" & _noTransaksi & "'", 4)
            End If
        End If

        FormRekamMedisDokter.SetDataFromPendaftaran(_noRM, _noTransaksi, _jenisPoli)
        FormRekamMedisDokter.Show()
        FormRekamMedisDokter.BringToFront()
    End Sub
End Class