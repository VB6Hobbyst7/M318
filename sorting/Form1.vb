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
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        rtfInput.Text = ""
        rtfOutput.Text = ""
    End Sub
End Class
