#Region "Imports"
Imports System.Text
Imports System.Globalization
Imports System.Console
#End Region
Module modSort
#Region "Bubblesort"
    '==Bubble Sort==
    Sub sortBubble(ByRef strInput As String())
        Dim i As Integer = strInput.Length - 1
        Dim j As Integer = i
        Do
            i = strInput.Length - 1
            Do
                If uml(strInput(i)) < uml(strInput(i - 1)) Then
                    swap(strInput, i, i - 1)
                End If
                i -= 1
            Loop While i > 0
            j -= 1
        Loop While j > 0
    End Sub
#End Region
#Region "Ripplesort"
    '==Ripple Sort==
    Function sortRipple(strInput As String())
        Dim i As Integer = strInput.Length
        i = strInput.Length - 1
        Dim j As Integer = i
        Dim boolSorted As Boolean = False
        Do
            i = strInput.Length - 1
            boolSorted = False
            Do
                If uml(strInput(i)) < uml(strInput(i - 1)) Then
                    swap(strInput, i, i - 1)
                    boolSorted = True
                End If
                i -= 1
            Loop While i > 0
            j -= 1
        Loop While j > 0 And boolSorted = True
        Return strInput
    End Function
#End Region
    '#Region "Internsort"
    '    '==Intern Sort==
    '    Function sortIntern(strInput As String)
    '        Dim sb As New StringBuilder
    '        Dim comp As Char
    '        Dim compOld As Char = " "(0)
    '        Dim pos As Long
    '        Dim i As Long
    '        For Each c As Char In strInput
    '            comp = c
    '            i = pos = 0
    '            For Each cc As Char In strInput
    '                If uml(cc) < uml(comp) And uml(cc) >= uml(compOld) Then
    '                    comp = cc
    '                    pos = i + 1
    '                End If
    '                i += 1
    '            Next
    '            Mid(strInput, pos, 1) = "ÿ"
    '            compOld = comp
    '            sb.Append(comp)
    '        Next
    '        Return sb.ToString()
    '    End Function
    '#End Region
#Region "Quicksort"
    '    '==Quick Sort==
    Sub sortQuick(ByRef strIn As String(), ByVal lo As Long, ByVal hi As Long)
        If lo < hi Then
            Dim p As Long = quickPart(strIn, lo, hi)
            sortQuick(strIn, lo, p - 1)
            sortQuick(strIn, p + 1, hi)
        End If
    End Sub

    Function quickPart(ByVal A As String(), ByVal lo As Long, ByVal hi As Long)
        Dim pIndex As Long = A.Length \ 2
        Dim pVal As String = A(pIndex)
        swap(A, pIndex, hi)
        Dim storeIndex As Long = lo
        For i As Long = lo To hi - 1 Step 1
            If A(i) <= pVal Then
                swap(A, i, storeIndex)
                storeIndex += 1
            End If
        Next
        swap(A, storeIndex, hi)
        Return storeIndex
    End Function

    'Dim A As String
    'Function sortQuick(strIn As String, lo As Long, hi As Long)
    '    A = strIn
    '    quick(lo, hi)
    '    Return A
    'End Function
    'Sub quick(lo As Long, hi As Long)
    '    Dim i As Long = lo
    '    Dim j As Long = hi
    '    Dim x As Char = uml(A.Chars((lo + hi) \ 2))
    '    Do
    '        While uml(A.Chars(i)) < x
    '            i += 1
    '        End While
    '        While uml(A.Chars(j)) > x
    '            j -= 1
    '        End While
    '        If i <= j Then
    '            A = swap(A, i, j)
    '            i += 1
    '            j -= 1
    '        End If
    '        Console.WriteLine(A)
    '    Loop Until i > j
    '    quick(lo, j)
    '    quick(i, hi)
    'End Sub
    'Function srtQuick(A As String, lo As Long, hi As Long)
    '    If lo < hi Then
    '        Dim pivotIndex As Long = Len(A) \ 2
    '        Dim pivotValue As Char = uml(A.Chars(pivotIndex))
    '        A = swap(A, pivotIndex - 1, hi - 1)
    '        Dim storeIndex As Long = lo
    '        For i As Long = lo To hi - 1 Step 1
    '            If uml(A.Chars(i)) < pivotValue Then
    '                A = swap(A, i - 1, storeIndex - 1)
    '                storeIndex += 1
    '            End If
    '        Next
    '        A = swap(A, storeIndex - 1, hi - 1)
    '        Dim p As Long = storeIndex
    '        sortQuick(A, lo, p - 1)
    '        sortQuick(A, p + 1, hi)
    '    End If
    '    Return A
    'End Function
#End Region
#Region "Insertionsort"
    '==Insertion Sort==
    Function sortInsertion(strInput As String())
        For i As Long = 0 To strInput.Length - 1 Step 1
            Dim j As Long = i
            While j >= 2 And uml(strInput(j - 1)) > uml(strInput(j))
                swap(strInput, j, j - 1)
                j -= 1
            End While
        Next
        Return strInput
    End Function
#End Region
End Module