#Region "Imports"
Imports System.Text
Imports System.Globalization
Imports System.Console
Imports System.Linq
#End Region
Module modUtil
#Region "swap"
    Function swap(strIn As String(), pos1 As Integer, pos2 As Integer) As String()
        Dim temp As String

        temp = strIn(pos1)
        strIn(pos1) = strIn(pos2)
        strIn(pos2) = temp
        Return strIn
    End Function
#End Region
#Region "Umlaute"
    Function uml(ByVal strIn As String) As String
        If Form1.chkUmlaute.Checked Then
            Dim sb As New StringBuilder
            For j As Integer = 0 To strIn.Length - 1 Step 1
                Dim ns As String = strIn(j).ToString.Normalize(NormalizationForm.FormD)
                For i As Integer = 0 To ns.Length - 1 Step 1
                    Dim uc As UnicodeCategory = CharUnicodeInfo.GetUnicodeCategory(ns.Chars(i))
                    If uc <> UnicodeCategory.NonSpacingMark Then
                        sb.Append(ns.Chars(i))
                    End If
                Next
            Next
            Return sb.ToString.Normalize(NormalizationForm.FormC).ToString()
        Else
            Return strIn
        End If
    End Function
#End Region
#Region "caller"
    'calls sort functions with parameters
    Sub callSort(ByVal strSort As String, ByVal alg As Integer, ByVal words As Boolean)
        Dim tmps, tmpp As String()
        Dim strPunct As String = stripPunctuation(strSort)
        If words Then
            tmps = strSort.Split(New Char() {" "}, StringSplitOptions.RemoveEmptyEntries)
        Else
            Dim tmplist As New List(Of String)
            For Each c As Char In strSort
                If Not c = " " Then
                    tmplist.Add(c.ToString())
                End If
            Next
            tmps = tmplist.ToArray()
        End If
        tmpp = strPunct.Split(New Char() {""}, StringSplitOptions.RemoveEmptyEntries)
        Dim val(tmps.Length + tmpp.Length - 1) As String
        Array.Copy(tmpp, val, tmpp.Length)
        Array.Copy(tmps, 0, val, tmpp.Length, tmps.Length)
        strSort = String.Join(vbCrLf, val)
        Form1.rtfOutput.Text = strSort
        MessageBox.Show(strPunct)
    End Sub
#End Region
#Region "strip punctuation"
    Function stripPunctuation(ByRef strIn As String) As String
        Dim sb As New StringBuilder
        For i As Integer = 0 To strIn.Length - 1 Step 1
            If Char.IsPunctuation(strIn(i)) Then
                sb.Append(strIn(i))
                Mid(strIn, i + 1, 1) = " "
            End If
        Next
        Return sb.ToString
    End Function
#End Region
End Module