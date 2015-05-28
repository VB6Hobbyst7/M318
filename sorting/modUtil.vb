#Region "Imports"
Imports System.Text
Imports System.Globalization
Imports System.Linq
#End Region
Module modUtil
    Public _umlaut As Boolean
#Region "swap"
    'funktion zum austauschen zweier elemente in einem StringArray
    Sub swap(ByRef strIn As String(), pos1 As Integer, pos2 As Integer)
        Dim temp As String
        temp = strIn(pos1)
        strIn(pos1) = strIn(pos2)
        strIn(pos2) = temp
    End Sub
#End Region
#Region "Umlaute"
    'falls ein non-ascii char vorhanden ist, werden die zeichen entfernt und als ascii char zurückgegeben.
    Function uml(ByVal strIn As String) As String
        'sehe ob chkUmlaute gewählt ist.
        If _umlaut Then
            'Deklariere und Initisalisiere StringBuilder
            Dim sb As New StringBuilder
            'loope durch inputString Char für Char
            For j As Integer = 0 To strIn.Length - 1 Step 1
                'Splitte den inputchar in zeichen und ascii-char
                Dim ns As String = strIn(j).ToString.Normalize(NormalizationForm.FormD)
                'loope durch diese zeichen
                For i As Integer = 0 To ns.Length - 1 Step 1
                    'Hole .NET unicodekategorie des jeweiligen zeichens
                    Dim uc As UnicodeCategory = CharUnicodeInfo.GetUnicodeCategory(ns.Chars(i))
                    'Falls die Unicodekategorie NICHT NonSpacingMark
                    'http://www.fileformat.info/info/unicode/category/Mn/list.htm
                    '^^^ liste der nonspacingmarks ^^^
                    If uc <> UnicodeCategory.NonSpacingMark Then
                        'füge den char am StringBuilder an.
                        sb.Append(ns.Chars(i))
                    End If
                Next
            Next
            'Normalisiere wieder zurück vom unicode spec zum vb.net spec
            Return sb.ToString.Normalize(NormalizationForm.FormC).ToString()
        Else
            'falls umlaute nicht ausgewähl ist, gebe den input wieder zurück
            Return strIn
        End If
    End Function
#End Region
#Region "caller"
    'präpariert inputstring zum sortieren, und ruft den entsprechenden sortieralgorithmus auf.
    Sub callSort(ByVal strInput As String(), ByVal alg As Integer, ByVal words As Boolean)

        'setze parameter für async BackgroundWorker
        Dim args As ArgumentType = New ArgumentType()
        args._algorithm = alg
        args._arrayToSort = strInput
        'rufe den async BackgroundWorker
        Form1.BackgroundWorkerDoSort.RunWorkerAsync(args)
    End Sub
#End Region
#Region "strip punctuation"
    'entfernt sonderzeichen durch verwendung von <IsPunctuation> und gibt diese als string zurück.
    Function stripPunctuation(ByRef strIn As String, ByRef worker As System.ComponentModel.BackgroundWorker, e As System.ComponentModel.DoWorkEventArgs) As String
        'Deklariere & initialisiere StringBuilder
        Dim sb As New StringBuilder
        'loop durch inputstring
        For i As Integer = 0 To strIn.Length - 1 Step 1
            'sehe ob Char ein Zeilenabstand ist
            If strIn(i) = vbCrLf Or strIn(i) = vbNewLine Or strIn(i) = Chr(10) Or strIn(i) = Chr(13) Or strIn(i) = vbTab Then

                'Ersetze sonderzeichen durch " " in inputstring
                Mid(strIn, i + 1, 1) = " "
            ElseIf Char.IsPunctuation(strIn(i)) Then
                'füge sonderzeichen zu Stringbuilder hinzu
                sb.Append(strIn(i))
                'Ersetze sonderzeichen durch " " in inputstring
                Mid(strIn, i + 1, 1) = " "
            End If
            worker.ReportProgress(100 / strIn.Length * i, "Sonderzeichen strippen: ")
            If worker.CancellationPending Then
                e.Cancel = True
                Exit For
            End If
        Next
        Return sb.ToString
    End Function
#End Region
End Module