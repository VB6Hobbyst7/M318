#Region "Imports"
Imports System.Text
Imports System.Globalization
Imports System.Linq
#End Region
Module modUtil
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
        If Form1.chkUmlaute.Checked Then
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
    Sub callSort(ByVal strSort As String, ByVal alg As Integer, ByVal words As Boolean)
        'deklariere temp variabeln
        Dim tmpstr, tmppunc As String()
        Dim tmplist As New List(Of String)
        'strippe sonderzeichen vom inputstring und speichere diese in <strPunct> ab.
        Dim strPunct As String = stripPunctuation(strSort)

        'Wenn Wortsortierung
        If words Then
            'Teile inputstring in array auf, geteilt bei leerzeichen
            tmpstr = strSort.Split({" "}, StringSplitOptions.RemoveEmptyEntries)
        Else
            'Konvertiere String zu String() für jeden Char
            For Each c As Char In strSort
                If Not c = " " Then
                    tmplist.Add(c.ToString())
                End If
            Next
            tmpstr = tmplist.ToArray()
            tmplist.Clear()
        End If

        'Konvertiere String zu String() für jeden Char, sonderzeichen
        For Each c As Char In strPunct
            If Not c = " " Then
                tmplist.Add(c.ToString())
            End If
        Next
        tmppunc = tmplist.ToArray()
        tmplist.Clear()

        'füge Sonderzeichen zum beginn der "normalen" Strings hinzu
        Dim val(tmpstr.Length + tmppunc.Length - 1) As String
        Array.Copy(tmppunc, val, tmppunc.Length)
        Array.Copy(tmpstr, 0, val, tmppunc.Length, tmpstr.Length)

        'rufe sortieralgorithmen auf
        Select Case alg
            Case 0
                sortBubble(val)
            Case 1
                sortRipple(val)
            Case 2
                'sortIntern()
            Case 3
                sortQuick(val, 0, val.Length - 1)
            Case 4
                sortInsertion(val)
            Case Else
                MessageBox.Show("Bitte wählen Sie einen Sortieralgorithmus!", "Achtung!", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Select

        'output ins textfeld
        If words Then
            strSort = String.Join(" ", val)
        Else
            strSort = String.Join("", val)
        End If
        Form1.rtfOutput.Text = strSort
    End Sub
#End Region
#Region "strip punctuation"
    'entfernt sonderzeichen durch verwendung von <IsPunctuation> und gibt diese als string zurück.
    Function stripPunctuation(ByRef strIn As String) As String
        'Deklariere & initialisiere StringBuilder
        Dim sb As New StringBuilder
        'loop durch inputstring
        For i As Integer = 0 To strIn.Length - 1 Step 1
            'sehe ob Char ein Zeilenabstand ist
            If strIn(i) = vbCrLf Or strIn(i) = vbNewLine Or strIn(i) = Chr(10) Or strIn(i) = Chr(13) Then
                
                'Ersetze sonderzeichen durch " " in inputstring
                Mid(strIn, i + 1, 1) = " "
            ElseIf Char.IsPunctuation(strIn(i)) Then
                'füge sonderzeichen zu Stringbuilder hinzu
                sb.Append(strIn(i))
                'Ersetze sonderzeichen durch "" in inputstring
                Mid(strIn, i + 1, 1) = ""
            End If
        Next
        Return sb.ToString
    End Function
#End Region
End Module