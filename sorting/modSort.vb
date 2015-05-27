#Region "Imports"
Imports System.Text
Imports System.Globalization
Imports System.Console
#End Region
Module modSort
    'iteration counter for quicksort
    Public _counter As Long = 0
#Region "Bubblesort"
    '==Bubble Sort==
    Sub sortBubble(ByRef strInput As String(), worker As System.ComponentModel.BackgroundWorker, ByRef e As System.ComponentModel.DoWorkEventArgs)
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
            worker.ReportProgress(100 / strInput.Length * (strInput.Length - j))
            If worker.CancellationPending Then
                e.Cancel = True
                Exit Do
            End If
        Loop While j > 0
    End Sub
#End Region
#Region "Ripplesort"
    '==Ripple Sort==
    Sub sortRipple(ByRef strInput As String(), worker As System.ComponentModel.BackgroundWorker, ByRef e As System.ComponentModel.DoWorkEventArgs)
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
            worker.ReportProgress(100 / strInput.Length * (strInput.Length - j))
            If worker.CancellationPending Then
                e.Cancel = True
                Exit Do
            End If
        Loop While j > 0 And boolSorted = True
    End Sub
#End Region
#Region "Internsort"
    '==Intern Sort==
    Sub sortIntern(ByRef strInput As String(), worker As System.ComponentModel.BackgroundWorker, ByRef e As System.ComponentModel.DoWorkEventArgs)
        Dim winIndex As Long = 0
        Dim maxValue As String = "ÿÿÿÿÿÿÿÿ"
        Dim winValue As String
        Dim output As New List(Of String)

        For j As Long = 0 To strInput.Length - 1 Step 1
            winValue = maxValue
            For i As Long = 0 To strInput.Length - 1 Step 1
                If uml(strInput(i)) < uml(winValue) Then
                    winValue = strInput(i)
                    winIndex = i
                End If
            Next
            output.Add(winValue)
            strInput(winIndex) = maxValue
            worker.ReportProgress(100 / strInput.Length * output.Count)
            If worker.CancellationPending Then
                e.Cancel = True
                Exit For
            End If
        Next
        strInput = output.ToArray
    End Sub
#End Region
#Region "Quicksort"
    '==Quick Sort==

    Sub sortQuick(ByRef strIn As String(), ByVal lo As Long, ByVal hi As Long, worker As System.ComponentModel.BackgroundWorker, ByRef e As System.ComponentModel.DoWorkEventArgs)
        Dim i As Long = lo
        Dim j As Long = hi
        Dim pVal As String = strIn((lo + hi) \ 2)
        Do
            While uml(strIn(i)) < uml(pVal)
                i += 1
            End While
            While uml(pVal) < uml(strIn(j))
                j -= 1
            End While
            If i <= j Then
                swap(strIn, i, j)
                i += 1
                j -= 1
            End If
        Loop Until i > j
        If worker.CancellationPending Then
            e.Cancel = True
            Exit Sub
        End If
        If lo < j Then
            sortQuick(strIn, lo, j, worker, e)
        End If
        If i < hi Then
            sortQuick(strIn, i, hi, worker, e)
        End If
    End Sub
#End Region
#Region "Insertionsort"
    '==Insertion Sort==
    Sub sortInsertion(ByRef strIn As String(), worker As System.ComponentModel.BackgroundWorker, ByRef e As System.ComponentModel.DoWorkEventArgs)
        For i As Long = 1 To strIn.Length - 1
            Dim j As Long = i
            While j > 1 And uml(strIn(j - 1)) > uml(strIn(j))
                swap(strIn, j, j - 1)
                j -= 1
            End While
            worker.ReportProgress(100 / strIn.Length * i)
            If worker.CancellationPending Then
                e.Cancel = True
                Exit For
            End If
        Next
    End Sub
#End Region
#Region "Selectionsort"
    Sub sortSelection(ByRef strIn As String(), worker As System.ComponentModel.BackgroundWorker, ByRef e As System.ComponentModel.DoWorkEventArgs)
        Dim min As Integer = 0
        For j As Integer = 0 To strIn.Length - 2 Step 1
            min = j
            For i As Integer = j + 1 To strIn.Length - 1
                If uml(strIn(i)) < uml(strIn(min)) Then
                    min = i
                End If
            Next
            If Not min = j Then
                swap(strIn, j, min)
            End If
            worker.ReportProgress(100 / strIn.Length * j)
            If worker.CancellationPending Then
                e.Cancel = True
                Exit For
            End If
        Next
    End Sub
#End Region
End Module