Imports System.Threading
Imports System.IO
Public Class Form1
    'define applicationwide timer
    Public _timer As Stopwatch = New Stopwatch

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub btnSort_Click(sender As Object, e As EventArgs) Handles btnSort.Click
        _umlaut = chkUmlaute.Checked
        _timer.Start()
        callSort(rtfInput.Text, lstAlgo.SelectedIndex, chk_words.Checked)
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        rtfInput.Text = ""
        rtfOutput.Text = ""
    End Sub

#Region "BackgroundWorker subs"
#Region "DoWork"
    Private Sub BackgroundWorkerDoSort_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorkerDoSort.DoWork
        'start timer
        _timer.Reset()
        _timer.Start()

        Dim args As ArgumentType = e.Argument
        Try
            Dim Val As String() = args._arrayToSort
            Select Case args._algorithm
                Case 0
                    sortBubble(Val, BackgroundWorkerDoSort)
                Case 1
                    sortRipple(Val, BackgroundWorkerDoSort)
                Case 2
                    sortIntern(Val, BackgroundWorkerDoSort)
                Case 3
                    sortQuick(Val, 0, Val.Length - 1)
                Case 4
                    sortInsertion(Val, BackgroundWorkerDoSort)
                Case 5
                    sortSelection(Val, BackgroundWorkerDoSort)
                Case Else
                    MessageBox.Show("Bitte wählen Sie einen Sortieralgorithmus!", "Achtung!", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Select
            'return the sorted array
            e.Result = Val
        Catch ex As Exception
            'output exception message, should one occur
            MessageBox.Show(ex.ToString(), "An exception has occured!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)
        End Try
    End Sub
#End Region
#Region "ProgressChanged"
    Private Sub BackgroundWorkerDoSort_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorkerDoSort.ProgressChanged
        lbl_donePercent.Text = "Done [%]: " & e.ProgressPercentage.ToString()
        lblExecTime.Text = String.Format("Execution Time: {0}:{1}:{2},{3}", _timer.Elapsed.Hours, _timer.Elapsed.Minutes, _timer.Elapsed.Seconds, _timer.Elapsed.Milliseconds)
        prg_done.Value = e.ProgressPercentage
    End Sub
#End Region
#Region "RunWorkerCompleted"
    Private Sub BackgroundWorkerDoSort_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorkerDoSort.RunWorkerCompleted
        Dim timespan As TimeSpan = _timer.Elapsed
        lblExecTime.Text = String.Format("Execution Time: {0}:{1}:{2},{3}", _timer.Elapsed.Hours, _timer.Elapsed.Minutes, _timer.Elapsed.Seconds, _timer.Elapsed.Milliseconds)
        lbl_donePercent.Text = "Done [%]: 100"
        prg_done.Value = 100
        _timer.Stop()
        _timer.Restart()
        Dim words As Boolean = chk_words.Checked
        Dim Val As String() = e.Result
        'output ins textfeld
        If words Then
            rtfOutput.Text = String.Join(" ", Val)
        Else
            rtfOutput.Text = String.Join("", Val)
        End If
        'reset the quicksort counter
        _counter = 0
    End Sub
#End Region
#End Region

    Private Sub btn_cancelSort_Click(sender As Object, e As EventArgs) Handles btn_cancelSort.Click
        If BackgroundWorkerDoSort.IsBusy Then
            BackgroundWorkerDoSort.CancelAsync()
        End If
    End Sub
#Region "Menu"
    Private Sub mnu_datei_close_Click(sender As Object, e As EventArgs) Handles mnu_datei_close.Click
        Me.Close()
    End Sub

    Private Sub mnu_datei_neu_Click(sender As Object, e As EventArgs) Handles mnu_datei_neu.Click
        rtfInput.Text = ""
        rtfOutput.Text = ""
    End Sub

    Private Sub mnu_datei_open_Click(sender As Object, e As EventArgs) Handles mnu_datei_open.Click
        Dim sr As New StreamReader(FileDialog.Open)
    End Sub
#End Region
End Class
#Region "Custom Class for Async args"
'For passing arguments to the async backgroundworker
Public Class ArgumentType
    Public _arrayToSort As String()
    Public _algorithm As Integer
End Class
#End Region