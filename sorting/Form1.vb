Public Class Form1
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnSort_Click(sender As Object, e As EventArgs) Handles btnSort.Click
        Dim timer As Stopwatch = Stopwatch.StartNew()
        callSort(rtfInput.Text, 0, chk_words.Checked)
        timer.Stop()
        Dim timespan As TimeSpan = timer.Elapsed
        lblExecTime.Text = "Execution Time[ms]: " & timespan.TotalMilliseconds.ToString()
        'Dim timer As Stopwatch = Stopwatch.StartNew()
        'Select Case lstAlgo.SelectedIndex
        '    Case 0 : rtfOutput.Text = sortBubble(rtfInput.Text)
        '    Case 1 : rtfOutput.Text = sortRipple(rtfInput.Text)
        '    Case 2 : rtfOutput.Text = sortIntern(rtfInput.Text)
        '    Case 3 : rtfOutput.Text = sortQuick(rtfInput.Text, 1, Len(rtfInput.Text) - 1)
        '    Case 4 : rtfOutput.Text = sortInsertion(rtfInput.Text)
        '    Case Else : MessageBox.Show("Please Select a sorting algorithm")
        'End Select
        'timer.Stop()
        'Dim timespan As TimeSpan = timer.Elapsed
        'lblExecTime.Text = "Execution Time[ms]: " & timespan.TotalMilliseconds.ToString
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        rtfInput.Text = ""
        rtfOutput.Text = ""
    End Sub
End Class
