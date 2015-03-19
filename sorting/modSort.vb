Module modSort
#Region "Bubblesort"
    '==Bubble Sort==
    Function sortBubble(strInput As String)
        Dim i As Integer = Len(strInput) - 1
        Dim j As Integer = i
        Do
            i = Len(strInput) - 1
            Do
                If uml(strInput.Chars(i)) < uml(strInput.Chars(i - 1)) Then
                    strInput = swap(strInput, i, i - 1)
                End If
                i -= 1
            Loop While i > 0
            j -= 1
        Loop While j > 0
        Return strInput
    End Function
#End Region
#Region "Ripplesort"
    '==Ripple Sort==
    Function sortRipple(strInput As String)
        Dim i As Integer = Len(strInput)
        i = Len(strInput) - 1
        Dim j As Integer = i
        Dim boolSorted As Boolean = False
        Do
            i = Len(strInput) - 1
            boolSorted = False
            Do
                If uml(strInput.Chars(i)) < uml(strInput.Chars(i - 1)) Then
                    strInput = swap(strInput, i, i - 1)
                    boolSorted = True
                End If
                i -= 1
            Loop While i > 0
            j -= 1
        Loop While j > 0 And boolSorted = True
        Return strInput
    End Function
#End Region
#Region "Internsort"
    '==Intern Sort==
    Function sortIntern(strInput As String)
        Dim strSorted As String = ""
        For Each c As Char In strInput
            For Each x As Char In strSorted

            Next
        Next
        Return strSorted
    End Function
#End Region
#Region "Quicksort"
    '==Quick Sort==
    Dim A As String
    Function sortQuick(strIn As String, lo As Long, hi As Long)
        A = strIn
        quick(lo, hi)
        Return A
    End Function
    Sub quick(lo As Long, hi As Long)
        Dim i As Long = lo
        Dim j As Long = hi
        Dim x As Char = uml(A.Chars((lo + hi) \ 2))
        Do
            While uml(A.Chars(i)) < x
                i += 1
            End While
            While uml(A.Chars(j)) > x
                j -= 1
            End While
            If i <= j Then
                A = swap(A, i, j)
                i += 1
                j -= 1
            End If
            Console.WriteLine(A)
        Loop Until i > j
        quick(lo, j)
        quick(i, hi)
    End Sub
    Function srtQuick(A As String, lo As Long, hi As Long)
        If lo < hi Then
            Dim pivotIndex As Long = Len(A) \ 2
            Dim pivotValue As Char = uml(A.Chars(pivotIndex))
            A = swap(A, pivotIndex - 1, hi - 1)
            Dim storeIndex As Long = lo
            For i As Long = lo To hi - 1 Step 1
                If uml(A.Chars(i)) < pivotValue Then
                    A = swap(A, i - 1, storeIndex - 1)
                    storeIndex += 1
                End If
            Next
            A = swap(A, storeIndex - 1, hi - 1)
            Dim p As Long = storeIndex
            sortQuick(A, lo, p - 1)
            sortQuick(A, p + 1, hi)
        End If
        Return A
    End Function
#End Region
#Region "Insertionsort"
    '==Insertion Sort==
    Function sortInsertion(strInput As String)
        For i As Long = 0 To strInput.Length - 1 Step 1
            Dim j As Long = i
            While j >= 2 And uml(strInput.Chars(j - 1)) > uml(strInput.Chars(j))
                strInput = swap(strInput, j, j - 1)
                j -= 1
            End While
        Next
        Return strInput
    End Function
#End Region
End Module