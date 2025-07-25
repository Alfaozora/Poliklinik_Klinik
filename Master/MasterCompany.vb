Public Class MasterCompany
    Private Find_Poliklinik As Find.TLconnect
    Private DB_Poliklinik As TLcon

    Dim thread As System.Threading.Thread

    Private Sub Download()
        Dim persen As Integer = 0
        Dim jumlah As Integer = 0
        Dim Tbls As DataTable = ReadThemysql("select * from mastercompany", DB_Poliklinik)
        For Each Trow As DataRow In Tbls.Rows
            Panelload.Visible = True
            lblload.Visible = True
            ProgressBar1.Visible = True

            If IsDBNull(Trow("Whatsapp_Auto")) = True Then Trow("Whatsapp_Auto") = 0
            If IsDBNull(Trow("Email_Auto")) = True Then Trow("Email_Auto") = 0
            If IsDBNull(Trow("TerimaHasilKaryawan")) = True Then Trow("TerimaHasilKaryawan") = 0
            If IsDBNull(Trow("ReportHasilPerusahaan")) = True Then Trow("ReportHasilPerusahaan") = 0
            If IsDBNull(Trow("HardcopyPerusahaan")) = True Then Trow("HardcopyPerusahaan") = 0
            If IsDBNull(Trow("AlamatPerusahaan")) = True Then Trow("AlamatPerusahaan") = 0

            persen = persen + 1
            If CheckSQL("select * from MasterCompany where NoCompany='" & Trow("nocompany").ToString & "'") = True Then
                'update
                WriteSQL("update MasterCompany set AlamatPerusahaan=" & Trow("AlamatPerusahaan") & ",  HardcopyPerusahaan=" & Trow("HardcopyPerusahaan") & ", ReportHasilPerusahaan=" & Trow("ReportHasilPerusahaan") & " , TerimaHasilKaryawan=" & Trow("TerimaHasilKaryawan") & ", Email_Auto=" & Trow("Email_Auto") & ", Whatsapp_Auto=" & Trow("Whatsapp_Auto") & ", No_Handphone2='" & Trow("No_Handphone2") & "', PIC_Perusahaan='" & Trow("PIC_Perusahaan").ToString & "', PIC_Marketing='" & Trow("PIC_Marketing").ToString & "', Email_Perusahaan='" & Trow("Email_Perusahaan").ToString & "', No_Handphone='" & Trow("No_Handphone").ToString & "', Alamat_Pengiriman='" & Trow("Alamat_Pengiriman").ToString & "', CompanyCode='" & Trow("companycode").ToString & "',CompanyNama='" & Trow("companynama").ToString & "', StartDate='" & Format(Trow("startdate"), "MM/dd/yyyy") & "' , Enddate='" & Format(Trow("enddate"), "MM/dd/yyyy") & "' where NoCompany='" & Trow("nocompany").ToString & "'", 4)
            Else
                'new
                WriteSQL("insert into MasterCompany(CompanyCode,CompanyNama,StartDate,EndDate,CreateDate,CreateBy,NoCompany,PIC_Perusahaan,PIC_Marketing,Email_Perusahaan,No_Handphone,Alamat_Pengiriman, Whatsapp_Auto, Email_Auto, No_Handphone2, TerimaHasilKaryawan, HardcopyPerusahaan, AlamatPerusahaan, ReportHasilPerusahaan) values('" & Trow("companycode") & "','" & Trow("companynama") & "','" & Format(Trow("startdate"), "yyyyMMdd") & "','" & Format(Trow("enddate"), "yyyyMMdd") & "',getdate(),'" & Trow("createby") & "','" & Trow("nocompany") & "','" & Trow("PIC_Perusahaan") & "', '" & Trow("PIC_Marketing") & "', '" & Trow("Email_Perusahaan") & "', '" & Trow("No_Handphone") & "', '" & Trow("Alamat_Pengiriman") & "', " & Trow("Whatsapp_Auto") & "," & Trow("Email_Auto") & ",'" & Trow("No_Handphone2") & "'," & Trow("TerimaHasilKaryawan") & "," & Trow("HardcopyPerusahaan") & "," & Trow("AlamatPerusahaan") & ", " & Trow("ReportHasilPerusahaan") & ")", 4)
            End If

            Dim procent As Integer = persen * 100 / Tbls.Rows.Count
            ProgressBar1.Value = procent
        Next
        Panelload.Visible = False
        lblload.Visible = False
        ProgressBar1.Visible = False
        MsgBox("Master Company Berhasil Update.", MsgBoxStyle.Information, "Success!")
    End Sub

    Private Sub SetConn()
        ' Set Parameter Server Online
        Dim serverOnline_IP As String = Utility.GetConfig("ServerOnline_IP")
        Dim serverOnline_UserID As String = Utility.GetConfig("ServerOnline_UserID")
        Dim serverOnline_Password As String = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerOnline_Password"), "albert")

        ' Set DB Poliklinik
        DB_Poliklinik.Tip = serverOnline_IP
        DB_Poliklinik.Tid = serverOnline_UserID
        DB_Poliklinik.Tpass = serverOnline_Password
        DB_Poliklinik.Tdb = Utility.GetConfig("ServerOnlinePoli_DB")

        ' Set Find Poliklinik
        Find_Poliklinik.Tip = serverOnline_IP
        Find_Poliklinik.Tid = serverOnline_UserID
        Find_Poliklinik.Tpass = serverOnline_Password
        Find_Poliklinik.Tdb = Utility.GetConfig("ServerOnlinePoli_DB")
    End Sub

    Private Sub SetNomorL()
        Dim Tmax As Integer = 0
        'Dim Dbmax As DataTable = ReadThemysql("select max(replace(nocompany,'C','')) from mastercompany", DB_Poliklinik)
        Dim Dbmax As DataTable = ReadThemysql("SELECT max(replace(nocompany,'C','')) from mastercompany WHERE replace(nocompany,'C','') >= 1000 ", DB_Poliklinik)
        If Dbmax.Rows.Count > 0 Then
            Dim Trow As DataRow = Dbmax.Rows(0)
            If Trow(0).ToString <> "" Then Tmax = CInt(Trow(0))
            Tmax = Tmax + 1

            'bisa digunakan jika no trans suda jauh sampai 999
            If Tmax >= 1000 Then
                txcompnol.Text = "C" & Tmax
            ElseIf Tmax >= 100 Then
                txcompnol.Text = "C" & Tmax
            ElseIf Tmax >= 10 Then
                txcompnol.Text = "C0" & Tmax
            ElseIf Tmax > 0 Then
                txcompnol.Text = "C00" & Tmax
                'txcompnol.Text = "C000" & Tmax
            Else
                MsgBox("Setting No Company Error. Confirm IT")
            End If
        Else
            'txcompnol.Text = "C0001"
            txcompnol.Text = "C001"
        End If
    End Sub

    Public Sub SetClear()
        txcompanyket.ReadOnly = False
        txcompid.ResetText()
        txcompnol.ResetText()
        SetNomorL()
        txcompanycode.ResetText()
        txcompanycode.Enabled = True
        txcompanyket.ResetText()
        dtcompanystart.Value = DateSerial(Now.Year, "01", "01")
        dtcompanyend.Value = DateSerial("9998", "12", "31")
        txPIC_Marketing.ResetText()
        txPIC_Perusahaan.ResetText()
        txalamat.ResetText()
        rdemailfalse.Checked = True
        rdwhatsappfalse.Checked = True
        rdterimahasilkaryawan1.Checked = True
        rdhardcopyperusahaan2.Checked = True
        rdalamatperusahaan2.Checked = True
        rdcompanyhasil1.Checked = True
        txnohandphone.ResetText()
        txnohandphone2.ResetText()
        txemail.ResetText()
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        SetClear()
        thread = New System.Threading.Thread(AddressOf Download)
        thread.Start()
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub MasterCompany_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Control.CheckForIllegalCrossThreadCalls = False
        Me.MdiParent = PoliKlinik
        SetConn()
        NewToolStripMenuItem.PerformClick()
    End Sub

    Public Sub LoadMasterComp(ByRef Txid As String)
        Dim Tbls As DataTable = ReadSQL("select * from mastercompany where nocompany='" & Txid & "'")
        Dim Trow As DataRow = Tbls.Rows(0)

        txcompid.Text = Trow("IDCompany")
        txcompanycode.Text = Trow("CompanyCode")
        txcompanycode.Enabled = False
        txcompanyket.Text = Trow("CompanyNama")
        dtcompanystart.Value = Trow("StartDate")
        dtcompanyend.Value = Trow("EndDate")
        txcompnol.Text = Trow("nocompany")

        If IsDBNull(Trow("PIC_Marketing")) = True Then Trow("PIC_Marketing") = "-"
        If IsDBNull(Trow("PIC_Perusahaan")) = True Then Trow("PIC_Perusahaan") = "-"
        If IsDBNull(Trow("Alamat_Pengiriman")) = True Then Trow("Alamat_Pengiriman") = "-"
        If IsDBNull(Trow("No_Handphone")) = True Then Trow("No_Handphone") = "-"
        If IsDBNull(Trow("No_Handphone2")) = True Then Trow("No_Handphone2") = "-"
        If IsDBNull(Trow("Email_Perusahaan")) = True Then Trow("Email_Perusahaan") = "-"
        If IsDBNull(Trow("Whatsapp_Auto")) = True Then Trow("Whatsapp_Auto") = False
        If IsDBNull(Trow("Email_Auto")) = True Then Trow("Email_Auto") = False
        If IsDBNull(Trow("TerimaHasilKaryawan")) = True Then Trow("TerimaHasilKaryawan") = False
        If IsDBNull(Trow("HardcopyPerusahaan")) = True Then Trow("HardcopyPerusahaan") = False
        If IsDBNull(Trow("AlamatPerusahaan")) = True Then Trow("AlamatPerusahaan") = False

        txPIC_Marketing.Text = Trow("PIC_Marketing")
        txPIC_Perusahaan.Text = Trow("PIC_Perusahaan")
        txalamat.Text = Trow("Alamat_Pengiriman")
        txnohandphone.Text = Trow("No_Handphone")
        txnohandphone2.Text = Trow("No_Handphone2")
        txemail.Text = Trow("Email_Perusahaan")

        If Trow("Whatsapp_Auto") = True Or Trow("Whatsapp_Auto") = 1 Then
            rdwhatsapptrue.Checked = True
        Else
            rdwhatsappfalse.Checked = True
        End If

        If Trow("Email_Auto") = True Or Trow("Email_Auto") = 1 Then
            rdemailtrue.Checked = True
        Else
            rdemailfalse.Checked = True
        End If

        If Trow("TerimaHasilKaryawan") = True Or Trow("TerimaHasilKaryawan") = 1 Then
            rdterimahasilkaryawan1.Checked = True
        Else
            rdterimahasilkaryawan2.Checked = True
        End If

        If Trow("ReportHasilPerusahaan") = True Or Trow("ReportHasilPerusahaan") = 1 Then
            rdcompanyhasil1.Checked = True
        Else
            rdcompanyhasil2.Checked = True
        End If

        If Trow("HardcopyPerusahaan") = True Or Trow("HardcopyPerusahaan") = 1 Then
            rdhardcopyperusahaan1.Checked = True
        Else
            rdhardcopyperusahaan2.Checked = True
        End If

        If Trow("AlamatPerusahaan") = True Or Trow("AlamatPerusahaan") = 1 Then
            rdalamatperusahaan1.Checked = True
        Else
            rdalamatperusahaan2.Checked = True
        End If

        txcompanyket.ReadOnly = True
    End Sub

    Function Checking() As Boolean
        txcompanycode.Text = Strings.Replace(Strings.Replace(Strings.Replace(txcompanycode.Text, "'", ""), """", ""), "`", "")
        txcompanyket.Text = Strings.Replace(Strings.Replace(Strings.Replace(txcompanyket.Text, "'", ""), """", ""), "`", "")

        Dim companycode As String = txcompanycode.Text
        Dim companyket As String = txcompanyket.Text

        If companycode.Contains("-").ToString.Trim = True Or companyket.Contains("-").ToString.Trim = True Then
            MsgBox("Kode & Keterangan Perusahaan tidak boleh terkandung simbol -.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        ElseIf companycode = "" Or companyket = "" Then
            MsgBox("Kode & Keterangan Perusahaan tidak boleh kosong.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        If dtcompanystart.Value > dtcompanyend.Value Then
            MsgBox("Tanggal start tidak boleh lebih kecil dari tanggal akhir.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        If txcompid.Text = "" Then
            If CheckThemysql("select * from mastercompany where companycode='" & txcompanycode.Text & "' or companynama='" & txcompanyket.Text & "' or nocompany='" & txcompnol.Text & "'", DB_Poliklinik) = True Then
                MsgBox("Telah ada nama company tersebut. Update yang ada.", MsgBoxStyle.Exclamation, "Warning!")
                Return False
            End If
        End If

        'Cek Email
        If txemail.Text <> "" Then
            If validateEmail(txemail.Text) = False Then
                MsgBox("Perhatikan penulisan email dengan benar.", MsgBoxStyle.Exclamation, "Warning!")
                Return False
            End If
        End If

        'Cek No Whatsapp Perusahaan
        If txnohandphone.Text <> "" Then
            If validateNoWhatsapp(txnohandphone.Text) = False Then
                Return False
            End If
        End If

        'Cek No Whatsapp Perusahaan
        If txnohandphone2.Text <> "" Then
            If validateNoWhatsapp(txnohandphone2.Text) = False Then
                Return False
            End If
        End If

        If rdwhatsapptrue.Checked = True And (txnohandphone.Text.Trim = "" Or txnohandphone.Text.Trim = "0" Or txnohandphone.Text.Trim = "-") Then
            MsgBox("Whatsapp Otomatis Tercentang. Masukkan No Whatsapp Perusahaan Terlebih Dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        If rdemailtrue.Checked = True And (txemail.Text.Trim = "" Or txemail.Text.Trim = "0" Or txemail.Text.Trim = "-") Then
            MsgBox("Email Otomatis Tercentang. Masukkan Email Perusahaan Terlebih Dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        If rdhardcopyperusahaan1.Checked = True And (txalamat.Text.Trim = "" Or txalamat.Text.Trim = "0" Or txalamat.Text.Trim = "-") Then
            MsgBox("Hardcopy Tercentang. Masukkan Alamat Perusahaan Terlebih Dahulu.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        If rdemailfalse.Checked = True And rdwhatsappfalse.Checked = True And rdterimahasilkaryawan2.Checked = True And rdhardcopyperusahaan2.Checked = True Then
            MsgBox("Penerima hasil harus memilih salah satu antara karyawan atau perusahaan.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        If rdemailtrue.Checked = True And rdwhatsapptrue.Checked = True Then
            MsgBox("Softcopy otomatis harus memilih antara whatsapp atau email.", MsgBoxStyle.Exclamation, "Warning!")
            Return False
        End If

        If txcompid.Text = "" Then
            If CheckSQL("select * from MasterCompany where CompanyCode='" & txcompanycode.Text & "' and '" & Format(dtcompanystart.Value, "MM/dd/yyyy") & "' between StartDate and EndDate") = True Then
                MsgBox("Masih ada Paket yang berjalan dengan nama tersebut.", MsgBoxStyle.Exclamation, "Warning!")
                Return False
            End If
            'ElseIf txcompid.Text <> "" Then
            '    If MsgBox("Yakin mengupdate Jenis Tagihan ini ?", MsgBoxStyle.YesNoCancel) <> MsgBoxResult.Yes Then
            '        MsgBox("Batal Updated.", MsgBoxStyle.Exclamation, "Warning!")
            '        Return False
            '    End If
        End If

        Return True
    End Function

    Private Sub SaveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveToolStripMenuItem.Click
        Dim rdemail As Boolean = False
        Dim rdwhatsapp As Boolean = False
        Dim rdterimahasilkaryawan = False
        Dim rdhardcopyperusahaan = False
        Dim rdcompanyhasil = False
        Dim rdalamatperusahaan = False
        Dim alamat As String = ""

        If rdemailtrue.Checked = True Then rdemail = True
        If rdwhatsapptrue.Checked = True Then rdwhatsapp = True
        If rdterimahasilkaryawan1.Checked = True Then rdterimahasilkaryawan = True
        If rdcompanyhasil1.Checked = True Then rdcompanyhasil = True
        If rdhardcopyperusahaan1.Checked = True Then rdhardcopyperusahaan = True
        If rdalamatperusahaan1.Checked = True Then rdalamatperusahaan = True
        If txalamat.Text.Trim = "" Or txalamat.Text.Trim = "0" Or txalamat.Text.Trim = "-" Then
            alamat = txcompanyket.Text
            txalamat.Text = txcompanyket.Text
        Else
            alamat = txalamat.Text
        End If


        If Checking() = True Then
            If txcompid.Text = "" Then
                'new 
                WriteThemysql("insert into mastercompany(companycode,companynama,startdate,enddate,createdate,createby,nocompany,PIC_Perusahaan,PIC_Marketing,Email_Perusahaan,No_Handphone,No_Handphone2,Alamat_Pengiriman,Whatsapp_Auto,Email_Auto, TerimaHasilKaryawan, HardcopyPerusahaan, AlamatPerusahaan, ReportHasilPerusahaan) values(" & _
                         "'" & txcompanycode.Text & "','" & txcompanyket.Text & "','" & Format(dtcompanystart.Value, "yyyyMMdd") & "','" & Format(dtcompanyend.Value, "yyyyMMdd") & "',now(),'" & PoliKlinik.Lbluser.Text & "','" & txcompnol.Text & "','" & txPIC_Perusahaan.Text & "', '" & txPIC_Marketing.Text & "', '" & txemail.Text & "', '" & txnohandphone.Text & "', '" & txnohandphone2.Text & "', '" & alamat & "', " & rdwhatsapp & ", " & rdemail & ", " & rdterimahasilkaryawan & ", " & rdhardcopyperusahaan & ", " & rdalamatperusahaan & ", " & rdcompanyhasil & ")", DB_Poliklinik)
                NewToolStripMenuItem.PerformClick()
            Else
                'update data 
                WriteThemysql("update mastercompany set AlamatPerusahaan=" & rdalamatperusahaan & ", HardcopyPerusahaan=" & rdhardcopyperusahaan & ", TerimaHasilKaryawan=" & rdterimahasilkaryawan & ", ReportHasilPerusahaan=" & rdcompanyhasil & ", Whatsapp_Auto=" & rdwhatsapp & ", Email_Auto=" & rdemail & ", PIC_Perusahaan='" & txPIC_Perusahaan.Text & "', PIC_Marketing='" & txPIC_Marketing.Text & "', Email_Perusahaan='" & txemail.Text & "', No_Handphone='" & txnohandphone.Text & "',No_Handphone2='" & txnohandphone2.Text & "', Alamat_Pengiriman='" & alamat & "', companycode='" & txcompanycode.Text & "' , companynama='" & txcompanyket.Text & "' ,startdate='" & Format(dtcompanystart.Value, "yyyyMMdd") & "',enddate='" & Format(dtcompanyend.Value, "yyyyMMdd") & "' where nocompany='" & txcompnol.Text & "'", DB_Poliklinik)
                thread = New System.Threading.Thread(AddressOf Download)
                thread.Start()
            End If
        End If
    End Sub

    Private Sub buttransdisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttransdisplay.Click
        NewToolStripMenuItem.PerformClick()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SaveToolStripMenuItem.PerformClick()
    End Sub

    Private Sub butfindcomp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butfindcomp.Click
        Find.Show()
        Find.QueryTheMysql("SELECT a.companycode, a.companynama, IFNULL(a.Alamat_Pengiriman, '-') AS 'Alamat', IFNULL(a.No_Handphone, '-') AS 'No. Handphone', case when DATE(NOW()) > DATE(a.enddate) then 'CLOSED' ELSE '-' END AS 'status', a.nocompany from mastercompany a ", " order by idcompany desc", "CompanyIDFind", 2, Find_Poliklinik)
    End Sub

    Private Sub txcompanyket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txcompanyket.Click
        If txcompid.Text <> "" Then
            MsgBox("Hubungi IT Jika Ada Perubahan Keterangan Company.")
        End If
    End Sub

    Private Sub txnohandphone_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txnohandphone.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub txnohandphone2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txnohandphone2.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub
End Class