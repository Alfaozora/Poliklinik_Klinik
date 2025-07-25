Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Text
Imports System.Globalization
Imports System.Security.Cryptography

Public Class FormResourceSatuSehat
    Private userInput As String = PoliKlinik.Lbluser.Text

    Private Sub ButtonGetToken_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGetToken.Click
        Dim responseString As String = GetTokenSatuSehat()

        MsgBox(responseString)
    End Sub

    Private Sub ButtonGetPatient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGetPatient.Click
        Dim baseURL As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'satu_sehat_base_url'")
        Dim apiEndpoint As String = baseURL & "Patient?identifier=https://fhir.kemkes.go.id/id/nik|3515112306960003"
        Dim responseString As String = GetDataSatuSehat(apiEndpoint)
        Dim jsonObject() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of PatientResource())(responseString)

        For Each oneVar As PatientResource In jsonObject
            For index As Integer = 0 To oneVar.entry.Length - 1
                MsgBox(oneVar.entry(index).resource.id)
            Next
        Next
    End Sub

    Private Sub ButtonPostBundle1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPostBundle1.Click
        Dim jsonEcounter As String = "{" & _
                                        """fullUrl"" : ""urn:uuid:0a26ca28-0ea3-486d-8fa9-6f9edd37e567""," & _
                                        """resource"": {" & _
                                           """resourceType"" : ""Encounter""," & _
                                           """status"" : ""finished""," & _
                                           """class"": {" & _
                                              """system"": ""http://terminology.hl7.org/CodeSystem/v3-ActCode""," & _
                                              """code"": ""AMB""," & _
                                              """display"": ""ambulatory""" & _
                                           "}," & _
                                           """subject"": {" & _
                                              """reference"": ""Patient/P01836748436""," & _
                                              """display"": ""Patient 7""" & _
                                           "}," & _
                                           """participant"": [" & _
                                              "{" & _
                                                 """type"": [" & _
                                                    "{" & _
                                                       """coding"": [" & _
                                                          "{" & _
                                                             """system"": ""http://terminology.hl7.org/CodeSystem/v3-ParticipationType""," & _
                                                             """code"": ""ATND""," & _
                                                             """display"": ""attender""" & _
                                                          "}" & _
                                                       "]" & _
                                                    "}" & _
                                                 "]," & _
                                                 """individual"": {" & _
                                                    """reference"": ""Practitioner/10009880728""," & _
                                                    """display"": ""Practitioner 1""" & _
                                                 "}" & _
                                              "}" & _
                                           "]," & _
                                           """period"": {" & _
                                              """start"": ""2023-11-11T14:00:00+00:00""," & _
                                              """end"": ""2023-11-11T16:00:00+00:00""" & _
                                           "}," & _
                                           """location"": [" & _
                                              "{" & _
                                                 """location"": {" & _
                                                    """reference"": ""Location/dc01c797-547a-4e4d-97cd-4ece0630e380""," & _
                                                    """display"": ""Ruang 1A, Poliklinik Bedah Rawat Jalan Terpadu, Lantai 2, Gedung G""" & _
                                                 "}" & _
                                              "}" & _
                                           "]," & _
                                           """diagnosis"": [" & _
                                              "{" & _
                                                 """condition"": {" & _
                                                    """reference"": ""urn:uuid:ba5a7dec-023f-45e1-adb9-1b9d71737a5f""," & _
                                                    """display"": ""Acute appendicitis, other and unspecified""" & _
                                                 "}," & _
                                                 """use"": {" & _
                                                    """coding"": [" & _
                                                       "{" & _
                                                          """system"": ""http://terminology.hl7.org/CodeSystem/diagnosis-role""," & _
                                                          """code"": ""DD""," & _
                                                          """display"": ""Discharge diagnosis""" & _
                                                       "}" & _
                                                    "]" & _
                                                 "}," & _
                                                 """rank"": 1" & _
                                              "}" & _
                                           "]," & _
                                           """statusHistory"": [" & _
                                              "{" & _
                                                 """status"": ""arrived""," & _
                                                 """period"": {" & _
                                                    """start"": ""2023-11-11T14:00:00+00:00""," & _
                                                    """end"": ""2023-11-11T15:00:00+00:00""" & _
                                                 "}" & _
                                              "}," & _
                                              "{" & _
                                                 """status"": ""in-progress""," & _
                                                 """period"": {" & _
                                                    """start"": ""2023-11-11T15:00:00+00:00""," & _
                                                    """end"": ""2023-11-11T16:00:00+00:00""" & _
                                                 "}" & _
                                              "}," & _
                                              "{" & _
                                                 """status"": ""finished""," & _
                                                 """period"": {" & _
                                                    """start"": ""2023-11-11T16:00:00+00:00""," & _
                                                    """end"": ""2023-11-11T16:00:00+00:00""" & _
                                                 "}" & _
                                              "}" & _
                                           "]," & _
                                           """serviceProvider"": {" & _
                                              """reference"": ""Organization/bbfe360b-48d1-406f-93a4-4a9db17fb56e""" & _
                                           "}," & _
                                           """identifier"": [" & _
                                              "{" & _
                                                 """system"": ""http://sys-ids.kemkes.go.id/encounter/bbfe360b-48d1-406f-93a4-4a9db17fb56e""," & _
                                                 """value"": ""20231111U00002""" & _
                                              "}" & _
                                           "]" & _
                                        "}," & _
                                        """request"": {" & _
                                           """method"": ""POST""," & _
                                           """url"": ""Encounter""" & _
                                        "}" & _
                                     "}"

        Dim jsonCondition As String = "{" & _
                                         """fullUrl"" : ""urn:uuid:ba5a7dec-023f-45e1-adb9-1b9d71737a5f""," & _
                                         """resource"": {" & _
                                            """resourceType"" : ""Condition""," & _
                                            """clinicalStatus"": {" & _
                                               """coding"": [" & _
                                                  "{" & _
                                                     """system"": ""http://terminology.hl7.org/CodeSystem/condition-clinical""," & _
                                                     """code"": ""active""," & _
                                                     """display"": ""Active""" & _
                                                  "}" & _
                                               "]" & _
                                            "}," & _
                                            """category"": [" & _
                                               "{" & _
                                                  """coding"": [" & _
                                                     "{" & _
                                                        """system"": ""http://terminology.hl7.org/CodeSystem/condition-category""," & _
                                                        """code"": ""encounter-diagnosis""," & _
                                                        """display"": ""Encounter Diagnosis""" & _
                                                     "}" & _
                                                  "]" & _
                                               "}" & _
                                            "]," & _
                                            """code"": {" & _
                                               """coding"": [" & _
                                                  "{" & _
                                                     """system"": ""http://hl7.org/fhir/sid/icd-10""," & _
                                                     """code"": ""K35.8""," & _
                                                     """display"": ""Acute appendicitis, other and unspecified""" & _
                                                  "}" & _
                                               "]" & _
                                            "}," & _
                                            """subject"": {" & _
                                               """reference"": ""Patient/P01836748436""," & _
                                               """display"": ""Patient 7""" & _
                                            "}," & _
                                            """encounter"": {" & _
                                               """reference"": ""urn:uuid:0a26ca28-0ea3-486d-8fa9-6f9edd37e567""," & _
                                               """display"": ""Kunjungan Patient 2 di hari Selasa, 08 November 2023""" & _
                                            "}" & _
                                         "}," & _
                                         """request"": {" & _
                                            """method"": ""POST""," & _
                                            """url"": ""Condition""" & _
                                         "}" & _
                                      "}"

        Dim jsonString As String = "{" & _
                                      """resourceType"" : ""Bundle""," & _
                                      """type"" : ""transaction""," & _
                                      """entry"" : [" & _
                                         jsonEcounter & _
                                         "," & _
                                         jsonCondition & _
                                      "]" & _
                                   "}"

        'InputBox("Test", "Test", jsonString)

        Dim encodedJsonData As String = Convert.ToBase64String(Encoding.UTF8.GetBytes(jsonString))
        Dim parameterString As String = "{" & _
                                           """jsonEncode"" : """ & encodedJsonData & """" & _
                                        "}"

        'Dim parameterString As String = "{" & _
        '                      """status_transaksi"" : ""Pending""," & _
        '                      """alamat_penanggung_jawab"" : ""Ini Alamat""" & _
        '                     "}"

        ' Get Token SATUSEHAT
        Dim token As String = GetTokenSatuSehat()

        Dim apiEndpoint As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'satu_sehat_base_url'")
        Dim responseString As String = PostDataSatuSehat(token, apiEndpoint, parameterString)

        InputBox("Test", "Test", responseString)
    End Sub

    Private Sub ButtonGetPayload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonGetPayload.Click
        Dim responseString As String = SetResource(TextBoxNoTransaksi.Text)

        Dim formattedJson As String = JToken.Parse(responseString).ToString(Formatting.Indented)

        TextBoxPayload.Text = formattedJson

        'InputBox("Test", "Test", responseString)
    End Sub

    Private Function SetResource(ByVal noTransaksi As String) As String
        Dim uuidEncounter As String = GetUUID()
        Dim jsonEncounter As String = SetEncounter(uuidEncounter, noTransaksi)
        Dim jsonCondition As String = SetCondition(uuidEncounter, noTransaksi)

        Dim jsonBuilder As New StringBuilder()

        jsonBuilder.AppendLine("{")
        jsonBuilder.AppendLine("  ""resourceType"" : ""Bundle"",")
        jsonBuilder.AppendLine("  ""type"" : ""transaction"",")
        jsonBuilder.AppendLine("  ""entry"" : [")
        jsonBuilder.AppendLine(jsonEncounter & ",") ' Set Json Encounter
        jsonBuilder.AppendLine(jsonCondition) ' Set Json Condition
        jsonBuilder.AppendLine("  ]")
        jsonBuilder.AppendLine("}")

        Dim jsonString As String = jsonBuilder.ToString()

        Return jsonString
    End Function

    Private Function SetEncounter(ByVal uuidEncounter As String, ByVal noTransaksi As String) As String
        Dim tblsEncounter As DataTable = ReadSQL("SELECT * FROM TransaksiPoli WHERE NoUrut = '" & noTransaksi & "'")
        Dim rowEncounter As DataRow = tblsEncounter.Rows(0)
        Dim noIHS As String = ReadSQLNIK("SELECT NoIHS FROM MasterPasien WHERE NoRekamMedis = '" & rowEncounter("IDInternet") & "'")
        Dim namaPasien As String = ReadSQLNIK("SELECT Nama FROM MasterPasien WHERE NoRekamMedis = '" & rowEncounter("IDInternet") & "'")

        ' Set Data
        Dim jsonDiagnosis As String = SetDiagnosis(TextBoxNoTransaksi.Text)
        Dim jsonBuilder As New StringBuilder()

        jsonBuilder.AppendLine("{")
        jsonBuilder.AppendLine("  ""fullUrl"" : ""urn:uuid:" & uuidEncounter & """,")
        jsonBuilder.AppendLine("  ""resource"": {")
        jsonBuilder.AppendLine("    ""resourceType"" : ""Encounter"",")
        jsonBuilder.AppendLine("    ""status"" : ""finished"",")
        jsonBuilder.AppendLine("    ""class"": {")
        jsonBuilder.AppendLine("       ""system"": ""http://terminology.hl7.org/CodeSystem/v3-ActCode"",")
        jsonBuilder.AppendLine("       ""code"": ""AMB"",")
        jsonBuilder.AppendLine("       ""display"": ""ambulatory""")
        jsonBuilder.AppendLine("    },")
        jsonBuilder.AppendLine("    ""subject"": {")
        jsonBuilder.AppendLine("       ""reference"": ""Patient/" & noIHS & """,")
        jsonBuilder.AppendLine("       ""display"": """ & namaPasien & """")
        jsonBuilder.AppendLine("    },")
        jsonBuilder.AppendLine("    ""participant"": [")
        jsonBuilder.AppendLine("       {")
        jsonBuilder.AppendLine("          ""type"": [")
        jsonBuilder.AppendLine("             {")
        jsonBuilder.AppendLine("                ""coding"": [")
        jsonBuilder.AppendLine("                   {")
        jsonBuilder.AppendLine("                      ""system"": ""http://terminology.hl7.org/CodeSystem/v3-ParticipationType"",")
        jsonBuilder.AppendLine("                      ""code"": ""ATND"",")
        jsonBuilder.AppendLine("                      ""display"": ""attender""")
        jsonBuilder.AppendLine("                   }")
        jsonBuilder.AppendLine("                ]")
        jsonBuilder.AppendLine("             }")
        jsonBuilder.AppendLine("          ],")
        jsonBuilder.AppendLine("          ""individual"": {")
        jsonBuilder.AppendLine("             ""reference"": ""Practitioner/10009880728"",")
        jsonBuilder.AppendLine("             ""display"": ""Practitioner 1""")
        jsonBuilder.AppendLine("          }")
        jsonBuilder.AppendLine("       }")
        jsonBuilder.AppendLine("    ],")
        jsonBuilder.AppendLine("    ""period"": {")
        jsonBuilder.AppendLine("       ""start"": """ & ConvertDateStringSatuSehat(Format(rowEncounter("ArrivedDate"), "yyyy-MM-dd HH:mm:ss.fff")) & """,")
        jsonBuilder.AppendLine("       ""end"": """ & ConvertDateStringSatuSehat(Format(rowEncounter("FinishedDate"), "yyyy-MM-dd HH:mm:ss.fff")) & """")
        jsonBuilder.AppendLine("    },")
        jsonBuilder.AppendLine("    ""location"": [")
        jsonBuilder.AppendLine("       {")
        jsonBuilder.AppendLine("          ""location"": {")
        jsonBuilder.AppendLine("             ""reference"": ""Location/dc01c797-547a-4e4d-97cd-4ece0630e380"",")
        jsonBuilder.AppendLine("             ""display"": ""Ruang 1A, Poliklinik Bedah Rawat Jalan Terpadu, Lantai 2, Gedung G""")
        jsonBuilder.AppendLine("          }")
        jsonBuilder.AppendLine("       }")
        jsonBuilder.AppendLine("    ],")
        jsonBuilder.AppendLine("    ""diagnosis"": [")
        jsonBuilder.AppendLine(jsonDiagnosis) ' Set Json Diagnosis
        jsonBuilder.AppendLine("    ],")
        jsonBuilder.AppendLine("    ""statusHistory"": [")
        jsonBuilder.AppendLine("       {")
        jsonBuilder.AppendLine("          ""status"": ""arrived"",")
        jsonBuilder.AppendLine("          ""period"": {")
        jsonBuilder.AppendLine("             ""start"": """ & ConvertDateStringSatuSehat(Format(rowEncounter("ArrivedDate"), "yyyy-MM-dd HH:mm:ss.fff")) & """,")
        jsonBuilder.AppendLine("             ""end"": """ & ConvertDateStringSatuSehat(Format(rowEncounter("InProgressDate"), "yyyy-MM-dd HH:mm:ss.fff")) & """")
        jsonBuilder.AppendLine("          }")
        jsonBuilder.AppendLine("       },")
        jsonBuilder.AppendLine("       {")
        jsonBuilder.AppendLine("          ""status"": ""in-progress"",")
        jsonBuilder.AppendLine("          ""period"": {")
        jsonBuilder.AppendLine("             ""start"": """ & ConvertDateStringSatuSehat(Format(rowEncounter("InProgressDate"), "yyyy-MM-dd HH:mm:ss.fff")) & """,")
        jsonBuilder.AppendLine("             ""end"": """ & ConvertDateStringSatuSehat(Format(rowEncounter("FinishedDate"), "yyyy-MM-dd HH:mm:ss.fff")) & """")
        jsonBuilder.AppendLine("          }")
        jsonBuilder.AppendLine("       },")
        jsonBuilder.AppendLine("       {")
        jsonBuilder.AppendLine("          ""status"": ""finished"",")
        jsonBuilder.AppendLine("          ""period"": {")
        jsonBuilder.AppendLine("             ""start"": """ & ConvertDateStringSatuSehat(Format(rowEncounter("FinishedDate"), "yyyy-MM-dd HH:mm:ss.fff")) & """,")
        jsonBuilder.AppendLine("             ""end"": """ & ConvertDateStringSatuSehat(Format(rowEncounter("FinishedDate"), "yyyy-MM-dd HH:mm:ss.fff")) & """")
        jsonBuilder.AppendLine("          }")
        jsonBuilder.AppendLine("       }")
        jsonBuilder.AppendLine("    ],")
        jsonBuilder.AppendLine("    ""serviceProvider"": {")
        jsonBuilder.AppendLine("       ""reference"": ""Organization/bbfe360b-48d1-406f-93a4-4a9db17fb56e""")
        jsonBuilder.AppendLine("    },")
        jsonBuilder.AppendLine("    ""identifier"": [")
        jsonBuilder.AppendLine("       {")
        jsonBuilder.AppendLine("          ""system"": ""http://sys-ids.kemkes.go.id/encounter/bbfe360b-48d1-406f-93a4-4a9db17fb56e"",")
        jsonBuilder.AppendLine("          ""value"": """ & rowEncounter("NoUrut") & """")
        jsonBuilder.AppendLine("       }")
        jsonBuilder.AppendLine("    ]")
        jsonBuilder.AppendLine(" },")
        jsonBuilder.AppendLine(" ""request"": {")
        jsonBuilder.AppendLine("    ""method"": ""POST"",")
        jsonBuilder.AppendLine("    ""url"": ""Encounter""")
        jsonBuilder.AppendLine("  }")
        jsonBuilder.AppendLine("}")

        Dim jsonEncounter As String = jsonBuilder.ToString()

        Return jsonEncounter
    End Function

    Private Function SetCondition(ByVal uuidEncounter As String, ByVal noTransaksi As String) As String
        Dim tblsEncounter As DataTable = ReadSQL("SELECT * FROM TransaksiPoli WHERE NoUrut = '" & noTransaksi & "'")
        Dim rowEncounter As DataRow = tblsEncounter.Rows(0)
        Dim noIHS As String = ReadSQLNIK("SELECT NoIHS FROM MasterPasien WHERE NoRekamMedis = '" & rowEncounter("IDInternet") & "'")
        Dim namaPasien As String = ReadSQLNIK("SELECT Nama FROM MasterPasien WHERE NoRekamMedis = '" & rowEncounter("IDInternet") & "'")
        Dim tblsDiagnosa As DataTable = ReadSQL("SELECT * FROM TransaksiDetailDiagnosa WHERE NoTransaksi = '" & noTransaksi & "' AND DeletedDate IS NULL")
        Dim totalData As Integer = tblsDiagnosa.Rows.Count
        Dim index As Integer = 1

        Dim jsonBuilder As New StringBuilder()

        For Each rowDiagnosa As DataRow In tblsDiagnosa.Rows
            jsonBuilder.AppendLine("{")
            jsonBuilder.AppendLine("  ""fullUrl"" : ""urn:uuid:" & rowDiagnosa("UUID") & """,")
            jsonBuilder.AppendLine("  ""resource"": {")
            jsonBuilder.AppendLine("    ""resourceType"" : ""Condition"",")
            jsonBuilder.AppendLine("    ""clinicalStatus"": {")
            jsonBuilder.AppendLine("      ""coding"": [")
            jsonBuilder.AppendLine("        {")
            jsonBuilder.AppendLine("          ""system"": ""http://terminology.hl7.org/CodeSystem/condition-clinical"",")
            jsonBuilder.AppendLine("          ""code"": ""active"",")
            jsonBuilder.AppendLine("          ""display"": ""Active""")
            jsonBuilder.AppendLine("        }")
            jsonBuilder.AppendLine("      ]")
            jsonBuilder.AppendLine("    },")
            jsonBuilder.AppendLine("    ""category"": [")
            jsonBuilder.AppendLine("      {")
            jsonBuilder.AppendLine("        ""coding"": [")
            jsonBuilder.AppendLine("          {")
            jsonBuilder.AppendLine("            ""system"": ""http://terminology.hl7.org/CodeSystem/condition-category"",")
            jsonBuilder.AppendLine("            ""code"": ""encounter-diagnosis"",")
            jsonBuilder.AppendLine("            ""display"": ""Encounter Diagnosis""")
            jsonBuilder.AppendLine("          }")
            jsonBuilder.AppendLine("        ]")
            jsonBuilder.AppendLine("      }")
            jsonBuilder.AppendLine("    ],")
            jsonBuilder.AppendLine("    ""code"": {")
            jsonBuilder.AppendLine("      ""coding"": [")
            jsonBuilder.AppendLine("        {")
            jsonBuilder.AppendLine("          ""system"": ""http://hl7.org/fhir/sid/icd-10"",")
            jsonBuilder.AppendLine("          ""code"": """ & rowDiagnosa("KodeDiagnosa") & """,")
            jsonBuilder.AppendLine("          ""display"": """ & rowDiagnosa("KeteranganDiagnosa") & """")
            jsonBuilder.AppendLine("        }")
            jsonBuilder.AppendLine("      ]")
            jsonBuilder.AppendLine("    },")
            jsonBuilder.AppendLine("    ""subject"": {")
            jsonBuilder.AppendLine("      ""reference"": ""Patient/" & noIHS & """,")
            jsonBuilder.AppendLine("      ""display"": """ & namaPasien & """")
            jsonBuilder.AppendLine("    },")
            jsonBuilder.AppendLine("    ""encounter"": {")
            jsonBuilder.AppendLine("      ""reference"": ""urn:uuid:" & uuidEncounter & """,")
            jsonBuilder.AppendLine("      ""display"": ""Kunjungan " & namaPasien & " " & Format(rowEncounter("ArrivedDate"), "dd") & " " & BulanIndonesia(Format(rowEncounter("ArrivedDate"), "MM")) & " " & Format(rowEncounter("ArrivedDate"), "yyyy") & """")
            jsonBuilder.AppendLine("    }")
            jsonBuilder.AppendLine("  },")
            jsonBuilder.AppendLine("  ""request"": {")
            jsonBuilder.AppendLine("    ""method"": ""POST"",")
            jsonBuilder.AppendLine("    ""url"": ""Condition""")
            jsonBuilder.AppendLine("  }")
            jsonBuilder.AppendLine("}")

            ' Pisahkan data dengan koma jika bukan data terakhir
            If index < totalData Then jsonBuilder.AppendLine(",")

            index += 1
        Next

        Dim jsonCondition As String = jsonBuilder.ToString()

        'For Each rowDiagnosa As DataRow In tblsDiagnosa.Rows

        '    jsonCondition = "{" & _
        '                       """fullUrl"" : ""urn:uuid:" & rowDiagnosa("UUID") & """," & _
        '                       """resource"": {" & _
        '                          """resourceType"" : ""Condition""," & _
        '                          """clinicalStatus"": {" & _
        '                             """coding"": [" & _
        '                                "{" & _
        '                                   """system"": ""http://terminology.hl7.org/CodeSystem/condition-clinical""," & _
        '                                   """code"": ""active""," & _
        '                                   """display"": ""Active""" & _
        '                                "}" & _
        '                             "]" & _
        '                          "}," & _
        '                          """category"": [" & _
        '                             "{" & _
        '                                """coding"": [" & _
        '                                   "{" & _
        '                                      """system"": ""http://terminology.hl7.org/CodeSystem/condition-category""," & _
        '                                      """code"": ""encounter-diagnosis""," & _
        '                                      """display"": ""Encounter Diagnosis""" & _
        '                                   "}" & _
        '                                "]" & _
        '                             "}" & _
        '                          "]," & _
        '                          """code"": {" & _
        '                             """coding"": [" & _
        '                                "{" & _
        '                                   """system"": ""http://hl7.org/fhir/sid/icd-10""," & _
        '                                   """code"": """ & rowDiagnosa("KodeDiagnosa") & """," & _
        '                                   """display"": """ & rowDiagnosa("KeteranganDiagnosa") & """" & _
        '                                "}" & _
        '                             "]" & _
        '                          "}," & _
        '                          """subject"": {" & _
        '                             """reference"": ""Patient/" & noIHS & """," & _
        '                             """display"": """ & namaPasien & """" & _
        '                          "}," & _
        '                          """encounter"": {" & _
        '                             """reference"": ""urn:uuid:" & uuidEncounter & """," & _
        '                             """display"": ""Kunjungan Patient 2 di hari Selasa, 08 November 2023""" & _
        '                          "}" & _
        '                       "}," & _
        '                       """request"": {" & _
        '                          """method"": ""POST""," & _
        '                          """url"": ""Condition""" & _
        '                       "}" & _
        '                    "}"
        'Next

        Return jsonCondition
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        '' Tanggal dan waktu dari SQL Server
        'Dim sqlDateTime As DateTime = DateTime.Parse("2023-11-15 13:50:06.153")

        '' Format tanggal dan waktu ke format ISO 8601
        'Dim formattedDateTime As String = sqlDateTime.ToString("yyyy-MM-ddTHH:mm:sszzz", CultureInfo.InvariantCulture)

        'MsgBox(formattedDateTime)

        Dim sqlServerDateString As Date = "11/16/2023 10:34:18 AM"
        Dim test As String = Format(sqlServerDateString, "yyyy-MM-dd HH:mm:ss.fff")

        Dim sqlServerDate As DateTime = DateTime.ParseExact(sqlServerDateString, "MM/dd/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)

        ' Format ulang tanggal sesuai dengan format yang diinginkan
        Dim formattedDate As String = sqlServerDate.ToString("yyyy-MM-dd HH:mm:ss.fff")

        MsgBox(ConvertDateStringSatuSehat(test))
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        InputBox("Test", "Test", GetUUID())
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        SetDiagnosis(TextBoxNoTransaksi.Text)
    End Sub

    Private Function SetDiagnosis(ByVal noTransaksi As String) As String
        Dim tblsDiagnosa As DataTable = ReadSQL("SELECT * FROM TransaksiDetailDiagnosa WHERE NoTransaksi = '" & noTransaksi & "' AND DeletedDate IS NULL")
        Dim totalData As Integer = tblsDiagnosa.Rows.Count
        Dim index As Integer = 1

        Dim jsonBuilder As New StringBuilder()

        For Each rowDiagnosa As DataRow In tblsDiagnosa.Rows
            jsonBuilder.AppendLine("{")
            jsonBuilder.AppendLine("  ""condition"": {")
            jsonBuilder.AppendLine("    ""reference"": ""urn:uuid:" & rowDiagnosa("UUID") & """,")
            jsonBuilder.AppendLine("    ""display"": """ & rowDiagnosa("KeteranganDiagnosa") & """")
            jsonBuilder.AppendLine("  },")
            jsonBuilder.AppendLine("  ""use"": {")
            jsonBuilder.AppendLine("    ""coding"": [")
            jsonBuilder.AppendLine("      {")
            jsonBuilder.AppendLine("        ""system"": ""http://terminology.hl7.org/CodeSystem/diagnosis-role"",")
            jsonBuilder.AppendLine("        ""code"": ""DD"",")
            jsonBuilder.AppendLine("        ""display"": ""Discharge diagnosis""")
            jsonBuilder.AppendLine("      }")
            jsonBuilder.AppendLine("    ]")
            jsonBuilder.AppendLine("  },")
            jsonBuilder.AppendLine("  ""rank"": " & index)
            jsonBuilder.AppendLine("}")

            ' Pisahkan data dengan koma jika bukan data terakhir
            If index < totalData Then jsonBuilder.AppendLine(",")

            index += 1
        Next

        Dim jsonString As String = jsonBuilder.ToString()

        Return jsonString
    End Function

    Private Sub Form5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = PoliKlinik
        Me.Dock = DockStyle.Fill
    End Sub

    Private Sub ButtonPostBundle2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPostBundle2.Click
        Dim payloadString As String = SetResource(TextBoxNoTransaksi.Text)
        Dim encodedJsonData As String = Convert.ToBase64String(Encoding.UTF8.GetBytes(payloadString))
        Dim parameterString As String = "{" & _
                                           """jsonEncode"" : """ & encodedJsonData & """" & _
                                        "}"

        ' Get Token SATUSEHAT
        Dim token As String = GetTokenSatuSehat()

        Dim apiEndpoint As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'satu_sehat_base_url'")
        Dim responseString As String = PostDataSatuSehat(token, apiEndpoint, parameterString)

        ' View Response
        TextBoxResponse.Text = JToken.Parse(responseString).ToString(Formatting.Indented)
    End Sub

    Private Sub ButtonSaveResponse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSaveResponse.Click
        Dim baseURL As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'satu_sehat_base_url'")
        Dim jsonBuilder As New StringBuilder()

        jsonBuilder.AppendLine("{")
        jsonBuilder.AppendLine("  ""entry"": [")
        jsonBuilder.AppendLine("    {")
        jsonBuilder.AppendLine("      ""response"": {")
        jsonBuilder.AppendLine("        ""etag"": ""W/\""MTcwMDE5MjA5MzYzNzAxMTAwMA\"""",")
        jsonBuilder.AppendLine("        ""lastModified"": ""2023-11-17T10:34:53.637011+07:00"",")
        jsonBuilder.AppendLine("        ""location"": """ & baseURL & "Encounter/9c077a29-7fe4-438a-ae92-74b8a97a6b58/_history/MTcwMDE5MjA5MzYzNzAxMTAwMA"",")
        jsonBuilder.AppendLine("        ""status"": ""201 Created"",")
        jsonBuilder.AppendLine("        ""resourceType"": ""Encounter"",")
        jsonBuilder.AppendLine("        ""resourceID"": ""9c077a29-7fe4-438a-ae92-74b8a97a6b58""")
        jsonBuilder.AppendLine("      }")
        jsonBuilder.AppendLine("    },")
        jsonBuilder.AppendLine("    {")
        jsonBuilder.AppendLine("      ""response"": {")
        jsonBuilder.AppendLine("        ""etag"": ""W/\""MTcwMDE5MjA5MzYzNzAxMTAwMA\"""",")
        jsonBuilder.AppendLine("        ""lastModified"": ""2023-11-17T10:34:53.637011+07:00"",")
        jsonBuilder.AppendLine("        ""location"": """ & baseURL & "Condition/45160f78-a6d5-4acf-862b-fa8d24f965a7/_history/MTcwMDE5MjA5MzYzNzAxMTAwMA"",")
        jsonBuilder.AppendLine("        ""status"": ""201 Created"",")
        jsonBuilder.AppendLine("        ""resourceType"": ""Condition"",")
        jsonBuilder.AppendLine("        ""resourceID"": ""45160f78-a6d5-4acf-862b-fa8d24f965a7""")
        jsonBuilder.AppendLine("      }")
        jsonBuilder.AppendLine("    },")
        jsonBuilder.AppendLine("    {")
        jsonBuilder.AppendLine("      ""response"": {")
        jsonBuilder.AppendLine("        ""etag"": ""W/\""MTcwMDE5MjA5MzYzNzAxMTAwMA\"""",")
        jsonBuilder.AppendLine("        ""lastModified"": ""2023-11-17T10:34:53.637011+07:00"",")
        jsonBuilder.AppendLine("        ""location"": """ & baseURL & "Condition/684e3349-9f45-4cab-b18a-913dfd9dc931/_history/MTcwMDE5MjA5MzYzNzAxMTAwMA"",")
        jsonBuilder.AppendLine("        ""status"": ""201 Created"",")
        jsonBuilder.AppendLine("        ""resourceType"": ""Condition"",")
        jsonBuilder.AppendLine("        ""resourceID"": ""684e3349-9f45-4cab-b18a-913dfd9dc931""")
        jsonBuilder.AppendLine("      }")
        jsonBuilder.AppendLine("    }")
        jsonBuilder.AppendLine("  ],")
        jsonBuilder.AppendLine("  ""resourceType"": ""Bundle"",")
        jsonBuilder.AppendLine("  ""type"": ""transaction-response"",")
        jsonBuilder.AppendLine("  ""total"": 3")
        jsonBuilder.AppendLine("}")

        ' Menampilkan JSON yang diformat di TextBox
        'Dim responseString As String = "[" + TextBoxResponse.Text + "]"
        Dim responseString As String = "[" + jsonBuilder.ToString() + "]"
        Dim jsonObject() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of ResponseResource())(responseString)

        For Each rowJson As ResponseResource In jsonObject
            If rowJson.resourceType <> "OperationOutcome" Then
                ' Success
                For index As Integer = 0 To rowJson.entry.Length - 1
                    ' Save To Database
                    WriteSQL("INSERT INTO SatuSehat_LogTransaksiResource (ResourceType, ResourceID, Status, CreatedBy, CreatedDate) " & _
                             "VALUES('" & rowJson.entry(index).response.resourceType & "','" & rowJson.entry(index).response.resourceID & "', '" & rowJson.entry(index).response.status & "', '" & userInput & "', GETDATE())", 4)

                    'MsgBox(rowJson.entry(index).response.resourceID)
                Next
            Else
                ' Error
                For index As Integer = 0 To rowJson.issue.Length - 1
                    MsgBox(rowJson.issue(index).code & " - " & rowJson.issue(index).details.text)
                Next
            End If
        Next
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim payloadString As String = SetResource(TextBoxNoTransaksi.Text)

        Dim encodedJsonData As String = Convert.ToBase64String(Encoding.UTF8.GetBytes(payloadString))
        Dim parameterString As String = "{" & _
                                           """jsonEncode"" : """ & encodedJsonData & """" & _
                                        "}"

        ' Get Token SATUSEHAT
        Dim token As String = GetTokenSatuSehat()

        Dim apiEndpoint As String = ReadSQLNIK("SELECT StrValue FROM MsConfig WHERE ConfigName = 'satu_sehat_base_url'")
        Dim responseString As String = PostDataSatuSehat(token, apiEndpoint, parameterString)

        responseString = "[" + responseString + "]"

        Dim jsonObject() = Newtonsoft.Json.JsonConvert.DeserializeObject(Of ResponseResource())(responseString)

        For Each rowJson As ResponseResource In jsonObject
            If rowJson.resourceType <> "OperationOutcome" Then
                ' Success
                For index As Integer = 0 To rowJson.entry.Length - 1
                    ' Save To Database
                    WriteSQL("INSERT INTO SatuSehat_LogTransaksiResource (ResourceType, ResourceID, Status, CreatedBy, CreatedDate) " & _
                             "VALUES('" & rowJson.entry(index).response.resourceType & "','" & rowJson.entry(index).response.resourceID & "', '" & rowJson.entry(index).response.status & "', '" & userInput & "', GETDATE())", 4)
                Next
            Else
                ' Error
                For index As Integer = 0 To rowJson.issue.Length - 1
                    MsgBox(rowJson.issue(index).code & " - " & rowJson.issue(index).details.text)
                Next
            End If
        Next

        ' View Response
        TextBoxResponse.Text = JToken.Parse(responseString).ToString(Formatting.Indented)
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim rsa As New RSACryptoServiceProvider(2048)

        ' Ekspor kunci dalam format XML
        Dim publicKey As String = rsa.ToXmlString(False) ' Hanya Public Key
        Dim privateKey As String = rsa.ToXmlString(True)  ' Public + Private Key

        'Get_URL_KYC("dr. Alexander", "7209061211900001", "-----BEGIN PUBLIC KEY-----\nMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAwqoicEXIYWYV3PvLIdvB\nqFkHn2IMhPGKTiB2XA56enpPb0UbI9oHoetRF41vfwMqfFsy5Yd5LABxMGyHJBbP\n+3fk2/PIfv+7+9/dKK7h1CaRTeT4lzJBiUM81hkCFlZjVFyHUFtaNfvQeO2OYb7U\nkK5JrdrB4sgf50gHikeDsyFUZD1o5JspdlfqDjANYAhfz3aam7kCjfYvjgneqkV8\npZDVqJpQA3MHAWBjGEJ+R8y03hs0aafWRfFG9AcyaA5Ct5waUOKHWWV9sv5DQXmb\nEAoqcx0ZPzmHJDQYlihPW4FIvb93fMik+eW8eZF3A920DzuuFucpblWU9J9o5w+2\noQIDAQAB\n-----END PUBLIC KEY-----")


        'Dim pemPublicKey As String = "-----BEGIN PUBLIC KEY-----\nMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAwqoicEXIYWYV3PvLIdvB\nqFkHn2IMhPGKTiB2XA56enpPb0UbI9oHoetRF41vfwMqfFsy5Yd5LABxMGyHJBbP\n+3fk2/PIfv+7+9/dKK7h1CaRTeT4lzJBiUM81hkCFlZjVFyHUFtaNfvQeO2OYb7U\nkK5JrdrB4sgf50gHikeDsyFUZD1o5JspdlfqDjANYAhfz3aam7kCjfYvjgneqkV8\npZDVqJpQA3MHAWBjGEJ+R8y03hs0aafWRfFG9AcyaA5Ct5waUOKHWWV9sv5DQXmb\nEAoqcx0ZPzmHJDQYlihPW4FIvb93fMik+eW8eZF3A920DzuuFucpblWU9J9o5w+2\noQIDAQAB\n-----END PUBLIC KEY-----" ' Masukkan Public Key PEM
        'Dim xmlPublicKey As String = ConvertPEMToXML(pemPublicKey) ' Konversi ke XML

        'Dim encryptedText As String = EncryptMessage("Pesan", xmlPublicKey)
        'MsgBox("Hasil Enkripsi: " & encryptedText)


        '' 1. Generate RSA Key Pair
        'Dim keys As Dictionary(Of String, String) = GenerateRSAKeys()
        'Dim publicKey As String = keys("publicKey")
        'Dim privateKey As String = keys("privateKey")

        '' 2. Data yang akan dienkripsi
        'Dim originalText As String = "Data yang akan dienkripsi"

        '' 3. Enkripsi menggunakan Public Key
        'Dim encryptedText As String = EncryptMessage(originalText, publicKey)
        'MessageBox.Show("Encrypted: " & encryptedText)

        '' 4. Dekripsi menggunakan Private Key
        'Dim decryptedText As String = DecryptMessage(encryptedText, privateKey)
        'MessageBox.Show("Decrypted: " & decryptedText)
    End Sub
End Class