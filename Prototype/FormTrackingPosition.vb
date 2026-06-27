Imports System.Linq
Imports Newtonsoft.Json
Imports Newtonsoft
Imports Newtonsoft.Json.Linq
Imports System.Text
Public Class FormTrackingPosition
    Public Class ComboItem
        Private _displayText As String
        Private _valueData As String

        Public Sub New(ByVal display As String, ByVal value As String)
            Me._displayText = display
            Me._valueData = value
        End Sub

        Public Property DisplayText() As String
            Get
                Return _displayText
            End Get
            Set(ByVal value As String)
                _displayText = value
            End Set
        End Property

        Public Property ValueData() As String
            Get
                Return _valueData
            End Get
            Set(ByVal value As String)
                _valueData = value
            End Set
        End Property

        Public Overrides Function ToString() As String
            Return Me._displayText
        End Function
    End Class

    Private Sub FormTrackingPosition_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBoxPos.Items.Clear()

        ComboBoxPos.Items.Add(New ComboItem("PENDAFTARAN", "pendaftaran"))
        ComboBoxPos.Items.Add(New ComboItem("PEM. FISIK: TB/BB", "tt_tb"))
        ComboBoxPos.Items.Add(New ComboItem("PEM. FISIK SCREENING", "screening"))
        ComboBoxPos.Items.Add(New ComboItem("PEM. FISIK VISUS MATA", "visus"))
        ComboBoxPos.Items.Add(New ComboItem("PEM. FISIK DOKTER", "dokter"))
        ComboBoxPos.Items.Add(New ComboItem("VISUS MATA", "visus"))
        ComboBoxPos.Items.Add(New ComboItem("PENGAMBILAN DARAH", "darah"))
        ComboBoxPos.Items.Add(New ComboItem("THORAX", "thorax"))
        ComboBoxPos.Items.Add(New ComboItem("SPIROMETRI", "spiro"))
        ComboBoxPos.Items.Add(New ComboItem("AUDIOMETRI", "audio"))
        ComboBoxPos.Items.Add(New ComboItem("ECG", "ecg"))
        ComboBoxPos.Items.Add(New ComboItem("USG", "usg"))
        ComboBoxPos.Items.Add(New ComboItem("TREADMILL", "treadmill"))

        If ComboBoxPos.Items.Count > 0 Then
            ComboBoxPos.SelectedIndex = 0
        End If
    End Sub

    Private Sub ButtonCariPasien_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCariPasien.Click

    End Sub
End Class