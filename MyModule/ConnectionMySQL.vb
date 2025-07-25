Module ConnectionMySQL
    Private Find_Poliklinik As Find.TLconnect
    Private Find_Keuangan As Find.TLconnect
    Private Find_Keuangan2 As Find.TLconnect
    Private Find_Jurnal As Find.TLconnect

    Private FindMultiple_Keuangan As FindMultiple.TLconnect
    Private FindMultiple_Keuangan2 As FindMultiple.TLconnect
    Private FindMultiple_Poliklinik As FindMultiple.TLconnect

    Private DB_Poliklinik As TLcon
    Private DB_Keuangan As TLcon
    Private DB_Keuangan2 As TLcon
    Private DB_Jurnal As TLcon
    Private DB_Tracking As TLcon

    Private Sub SetConnectionFromConfig()
        ' Set Parameter Server Online
        Dim serverOnline_IP As String = Utility.GetConfig("ServerOnline_IP")
        Dim serverOnline_UserID As String = Utility.GetConfig("ServerOnline_UserID")
        Dim serverOnline_Password As String = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerOnline_Password"), "albert")

        ' Set Find Poliklinik
        Find_Poliklinik.Tip = serverOnline_IP
        Find_Poliklinik.Tid = serverOnline_UserID
        Find_Poliklinik.Tpass = serverOnline_Password
        Find_Poliklinik.Tdb = Utility.GetConfig("ServerOnlinePoli_DB")

        ' Set Find Keuangan 1 (mitramed_keu)
        Find_Keuangan.Tip = serverOnline_IP
        Find_Keuangan.Tid = serverOnline_UserID
        Find_Keuangan.Tpass = serverOnline_Password
        Find_Keuangan.Tdb = Utility.GetConfig("ServerOnlineKeuangan_DB")

        ' Set Find Keuangan 2 (mitramed_keu2019)
        Find_Keuangan2.Tip = serverOnline_IP
        Find_Keuangan2.Tid = serverOnline_UserID
        Find_Keuangan2.Tpass = serverOnline_Password
        Find_Keuangan2.Tdb = Utility.GetConfig("ServerOnlineKeuangan2_DB")

        ' Set Find Jurnal
        Find_Jurnal.Tip = Utility.GetConfig("ServerJurnal_IP")
        Find_Jurnal.Tid = Utility.GetConfig("ServerJurnal_UserID")
        Find_Jurnal.Tpass = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerJurnal_Password"), "albert")
        Find_Jurnal.Tdb = Utility.GetConfig("ServerJurnal_DB")

        '===========================================================================
        '===========================================================================

        ' Set Find Multiple Keuangan 1 (mitramed_keu)
        FindMultiple_Keuangan.Tip = serverOnline_IP
        FindMultiple_Keuangan.Tid = serverOnline_UserID
        FindMultiple_Keuangan.Tpass = serverOnline_Password
        FindMultiple_Keuangan.Tdb = Utility.GetConfig("ServerOnlineKeuangan_DB")

        ' Set Find Multiple Keuangan 2 (mitramed_keu2019)
        FindMultiple_Keuangan2.Tip = serverOnline_IP
        FindMultiple_Keuangan2.Tid = serverOnline_UserID
        FindMultiple_Keuangan2.Tpass = serverOnline_Password
        FindMultiple_Keuangan2.Tdb = Utility.GetConfig("ServerOnlineKeuangan2_DB")

        ' Set Find Multiple Poliklinik
        FindMultiple_Poliklinik.Tip = serverOnline_IP
        FindMultiple_Poliklinik.Tid = serverOnline_UserID
        FindMultiple_Poliklinik.Tpass = serverOnline_Password
        FindMultiple_Poliklinik.Tdb = Utility.GetConfig("ServerOnlinePoli_DB")

        '===========================================================================
        '===========================================================================

        ' Set DB Poliklinik
        DB_Poliklinik.Tip = serverOnline_IP
        DB_Poliklinik.Tid = serverOnline_UserID
        DB_Poliklinik.Tpass = serverOnline_Password
        DB_Poliklinik.Tdb = Utility.GetConfig("ServerOnlinePoli_DB")

        ' Set DB Keuangan 1 (mitramed_keu)
        DB_Keuangan.Tip = serverOnline_IP
        DB_Keuangan.Tid = serverOnline_UserID
        DB_Keuangan.Tpass = serverOnline_Password
        DB_Keuangan.Tdb = Utility.GetConfig("ServerOnlineKeuangan_DB")

        ' Set DB Keuangan 2 (mitramed_keu2019)
        DB_Keuangan2.Tip = serverOnline_IP
        DB_Keuangan2.Tid = serverOnline_UserID
        DB_Keuangan2.Tpass = serverOnline_Password
        DB_Keuangan2.Tdb = Utility.GetConfig("ServerOnlineKeuangan2_DB")

        ' Set DB Tracking (db_tracking)
        DB_Tracking.Tip = serverOnline_IP
        DB_Tracking.Tid = serverOnline_UserID
        DB_Tracking.Tpass = serverOnline_Password
        DB_Tracking.Tdb = Utility.GetConfig("ServerOnlineTracking_DB")

        ' Set DB Jurnal
        DB_Jurnal.Tip = Utility.GetConfig("ServerJurnal_IP")
        DB_Jurnal.Tid = Utility.GetConfig("ServerJurnal_UserID")
        DB_Jurnal.Tpass = KASLibrary.Utility.DecryptTripleDES(Utility.GetConfig("ServerJurnal_Password"), "albert")
        DB_Jurnal.Tdb = Utility.GetConfig("ServerJurnal_DB")
    End Sub

    'Public Sub SetConnectionFromLocal()
    '    ' Set Parameter Server Online
    '    Dim serverOnline_IP As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ServerOnline_IP'")
    '    Dim serverOnline_UserID As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ServerOnline_UserID'")
    '    Dim serverOnline_Password As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ServerOnline_Password'")

    '    ' Set Find Poliklinik
    '    Find_Poliklinik.Tip = serverOnline_IP
    '    Find_Poliklinik.Tid = serverOnline_UserID
    '    Find_Poliklinik.Tpass = serverOnline_Password
    '    Find_Poliklinik.Tdb = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ServerOnlinePoli_DB'")

    '    ' Set Find Keuangan 1 (mitramed_keu)
    '    Find_Keuangan.Tip = serverOnline_IP
    '    Find_Keuangan.Tid = serverOnline_UserID
    '    Find_Keuangan.Tpass = serverOnline_Password
    '    Find_Keuangan.Tdb = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ServerOnlineKeuangan_DB'")

    '    ' Set Find Keuangan 2 (mitramed_keu2019)
    '    Find_Keuangan2.Tip = serverOnline_IP
    '    Find_Keuangan2.Tid = serverOnline_UserID
    '    Find_Keuangan2.Tpass = serverOnline_Password
    '    Find_Keuangan2.Tdb = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ServerOnlineKeuangan2_DB'")

    '    ' Set Find Jurnal
    '    Find_Jurnal.Tip = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ServerJurnal_IP'")
    '    Find_Jurnal.Tid = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ServerJurnal_UserID'")
    '    Find_Jurnal.Tpass = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ServerJurnal_Password'")
    '    Find_Jurnal.Tdb = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ServerJurnal_DB'")

    '    '===========================================================================
    '    '===========================================================================

    '    ' Set Find Multiple Keuangan 1 (mitramed_keu)
    '    FindMultiple_Keuangan.Tip = serverOnline_IP
    '    FindMultiple_Keuangan.Tid = serverOnline_UserID
    '    FindMultiple_Keuangan.Tpass = serverOnline_Password
    '    FindMultiple_Keuangan.Tdb = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ServerOnlineKeuangan_DB'")

    '    ' Set DB Poliklinik
    '    DB_Poliklinik.Tip = serverOnline_IP
    '    DB_Poliklinik.Tid = serverOnline_UserID
    '    DB_Poliklinik.Tpass = serverOnline_Password
    '    DB_Poliklinik.Tdb = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ServerOnlinePoli_DB'")

    '    ' Set DB Keuangan 1 (mitramed_keu)
    '    DB_Keuangan.Tip = serverOnline_IP
    '    DB_Keuangan.Tid = serverOnline_UserID
    '    DB_Keuangan.Tpass = serverOnline_Password
    '    DB_Keuangan.Tdb = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ServerOnlineKeuangan_DB'")

    '    ' Set DB Keuangan 2 (mitramed_keu2019)
    '    DB_Keuangan2.Tip = serverOnline_IP
    '    DB_Keuangan2.Tid = serverOnline_UserID
    '    DB_Keuangan2.Tpass = serverOnline_Password
    '    DB_Keuangan2.Tdb = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ServerOnlineKeuangan2_DB'")

    '    ' Set DB Jurnal
    '    DB_Jurnal.Tip = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ServerJurnal_IP'")
    '    DB_Jurnal.Tid = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ServerJurnal_UserID'")
    '    DB_Jurnal.Tpass = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ServerJurnal_Password'")
    '    DB_Jurnal.Tdb = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'ServerJurnal_DB'")
    'End Sub
End Module
