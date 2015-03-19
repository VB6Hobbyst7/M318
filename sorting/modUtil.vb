#Region "Imports"
Imports System.Text
Imports System.Globalization
Imports System.Console
#End Region
Module modUtil
#Region "swap"
    Function swap(strIn As String, pos1 As Integer, pos2 As Integer) As String
        Dim temp As Char
        temp = strIn.Chars(pos1)
        Mid(strIn, pos1 + 1, 1) = strIn.Chars(pos2)
        Mid(strIn, pos2 + 1, 1) = temp
        Return strIn
    End Function
#End Region
#Region "Umlaute"
    Function uml(chrIn As Char) As Char
        If Form1.chkUmlaute.Checked Then
            Dim ns As String = chrIn.ToString.Normalize(NormalizationForm.FormD)
            Dim sb As New StringBuilder
            For i As Integer = 0 To ns.Length - 1 Step 1
                Dim uc As UnicodeCategory = CharUnicodeInfo.GetUnicodeCategory(ns.Chars(i))
                If uc <> UnicodeCategory.NonSpacingMark Then
                    sb.Append(ns.Chars(i))
                End If
            Next
            Return sb.ToString.Normalize(NormalizationForm.FormC).ToCharArray.GetValue(0)
        Else
            Return chrIn
        End If
    End Function
#End Region
End Module