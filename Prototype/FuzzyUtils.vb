Imports System.Text.RegularExpressions

Module FuzzyUtils

    ' Levenshtein distance
    Public Function LevenshteinDistance(ByVal s As String, ByVal t As String) As Integer
        If s Is Nothing Then s = ""
        If t Is Nothing Then t = ""
        Dim n As Integer = s.Length
        Dim m As Integer = t.Length

        If n = 0 Then Return m
        If m = 0 Then Return n

        Dim d(n + 1, m + 1) As Integer

        For i As Integer = 0 To n
            d(i, 0) = i
        Next
        For j As Integer = 0 To m
            d(0, j) = j
        Next

        For i As Integer = 1 To n
            For j As Integer = 1 To m
                Dim cost As Integer = If(s.Chars(i - 1) = t.Chars(j - 1), 0, 1)
                d(i, j) = Math.Min(Math.Min(d(i - 1, j) + 1, d(i, j - 1) + 1), d(i - 1, j - 1) + cost)
            Next
        Next

        Return d(n, m)
    End Function

    ' Normalize nama obat: lowercase, hapus punctuation, singkat unit umum (mg, tab, tablet, dll)
    Public Function NormalizeName(ByVal input As String) As String
        If input Is Nothing Then Return ""
        Dim s As String = input.ToLower().Trim()

        ' hapus tanda baca selain spasi dan alfanumerik
        s = Regex.Replace(s, "[^\w\s]", " ")

        ' hapus kata-kata unit umum agar fokus pada nama bahan aktif/merk
        Dim tokensToRemove As String() = {"tablet", "tab", "kaplet", "kapsul", "kaps", "sirup", "drops", "injeksi", "ampul", "botol"}
        For Each t As String In tokensToRemove
            s = Regex.Replace(s, "\b" & Regex.Escape(t) & "\b", " ")
        Next

        ' hilangkan multiple spaces
        s = Regex.Replace(s, "[^\w\s]", " ")
        s = Regex.Replace(s, "\s+", " ").Trim()
        Return s
    End Function

    ' Konversi Levenshtein ke similarity % (0..100)
    Public Function Similarity(ByVal s As String, ByVal t As String) As Double
        Dim a As String = NormalizeName(s)
        Dim b As String = NormalizeName(t)

        If a.Length = 0 AndAlso b.Length = 0 Then Return 100.0
        Dim dist As Integer = LevenshteinDistance(a, b)
        Dim maxLen As Integer = Math.Max(a.Length, b.Length)
        If maxLen = 0 Then Return 0.0
        Dim sim As Double = (1.0 - dist / CDbl(maxLen)) * 100.0
        If sim < 0 Then sim = 0
        Return sim
    End Function

    ' Prefilter token overlap; cepat menolak kandidat yang tidak ada kata sama
    Public Function HasTokenOverlap(ByVal s As String, ByVal t As String) As Boolean
        s = NormalizeName(s)
        t = NormalizeName(t)
        If s.Length = 0 OrElse t.Length = 0 Then Return False

        Dim sa As String() = s.Split(" "c)
        Dim ta As String() = t.Split(" "c)
        For Each sx As String In sa
            If sx.Length < 3 Then Continue For ' abaikan token pendek
            For Each tx As String In ta
                If sx = tx Then Return True
            Next
        Next
        Return False
    End Function

End Module
