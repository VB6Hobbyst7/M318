Imports System.Threading
Imports System.IO
Public Class Form1
    'define applicationwide timer
    Public _timer As Stopwatch = New Stopwatch

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub btnSort_Click(sender As Object, e As EventArgs) Handles btnSort.Click
        If rtfInput.Text <> "" Then
            'reset stuff
            rtfOutput.Text = ""
            prg_done.Value = 0
            lbl_donePercent.Text = "Done [%]: 0"
            lblExecTime.Text = "Execution Time: 0:0:0:,0"

            _umlaut = chkUmlaute.Checked
            _timer.Start()
            btn_cancelSort.Enabled = True
            btnSort.Enabled = False
            Dim args As ArgumentType = New ArgumentType()
            args._inputString = rtfInput.Text
            args._words = chk_words.Checked
            BackgroundWorkerPrepare.RunWorkerAsync(args)
        Else
            MessageBox.Show("Enter text to sort!", "No Text!", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)
        End If
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        rtfInput.Text = ""
        rtfOutput.Text = ""
    End Sub
#Region "Backgroundworker for prep"
    Private Sub BackgroundWorkerPrepare_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorkerPrepare.DoWork
        Dim args As ArgumentType = e.Argument
        Try
            Dim strSort As String = args._inputString
            Dim words As Boolean = args._words
            lbl_countChr.Text = strSort.Length.ToString() & " Zeichen"
            'deklariere temp variabeln
            Dim tmpcount As Long = 0 'countervariable
            Dim tmpstr, tmppunc As String()
            Dim tmplist As New List(Of String)
            'strippe sonderzeichen vom inputstring und speichere diese in <strPunct> ab.
            Dim strPunct As String = stripPunctuation(strSort, BackgroundWorkerPrepare, e)

            If BackgroundWorkerPrepare.CancellationPending Then
                e.Cancel = True
                Exit Sub
            End If

            'Wenn Wortsortierung
            If words Then
                'Teile inputstring in array auf, geteilt bei leerzeichen
                tmpstr = strSort.Split({" "}, StringSplitOptions.RemoveEmptyEntries)
                lbl_countChr.Text = tmpstr.Length.ToString() & " Wörter"
            Else
                'Konvertiere String zu String() für jeden Char
                tmpcount = 0
                For Each c As Char In strSort
                    If Not c = " " Then
                        tmplist.Add(c.ToString())
                    End If
                    BackgroundWorkerPrepare.ReportProgress(100 / strSort.Length * tmpcount, "Chararray zu Stringarray konvertieren: ")
                    If BackgroundWorkerPrepare.CancellationPending Then
                        e.Cancel = True
                        Exit Sub
                    End If
                    tmpcount += 1
                Next
                tmpstr = tmplist.ToArray()
                tmplist.Clear()
                lbl_countChr.Text = tmpstr.Length.ToString() & " Zeichen"
            End If

            If BackgroundWorkerPrepare.CancellationPending Then
                e.Cancel = True
                Exit Sub
            End If

            'Konvertiere String zu String() für jeden Char, sonderzeichen
            tmpcount = 0
            For Each c As Char In strPunct
                If Not c = " " Then
                    tmplist.Add(c.ToString())
                End If
                BackgroundWorkerPrepare.ReportProgress(100 / strPunct.Length * tmpcount, "Sonderzeichenstring zu Stringarray: ")
                If BackgroundWorkerPrepare.CancellationPending Then
                    e.Cancel = True
                    Exit Sub
                End If
                tmpcount += 1
            Next
            tmppunc = tmplist.ToArray()
            tmplist.Clear()

            'füge Sonderzeichen zum beginn der "normalen" Strings hinzu
            Dim val(tmpstr.Length + tmppunc.Length - 1) As String
            Array.Copy(tmppunc, val, tmppunc.Length)
            Array.Copy(tmpstr, 0, val, tmppunc.Length, tmpstr.Length)

            e.Result = val
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Private Sub BackgroundWorkerPrepare_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorkerPrepare.ProgressChanged
        lblExecTime.Text = "Preparing input for sorting..."
        lbl_donePercent.Text = e.UserState.ToString() & e.ProgressPercentage.ToString() & "%"
        prg_done.Value = e.ProgressPercentage
    End Sub

    Private Sub BackgroundWorkerPrepare_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorkerPrepare.RunWorkerCompleted
        lblExecTime.Text = "Execution Time: 0:0:0,0"
        prg_done.Value = 100
        If Not e.Cancelled Then
            callSort(e.Result, lstAlgo.SelectedIndex, chk_words.Checked)
        End If
    End Sub
#End Region
#Region "BackgroundWorker subs"
#Region "DoWork"
    Private Sub BackgroundWorkerDoSort_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorkerDoSort.DoWork
        'start timer
        _timer.Reset()
        _timer.Start()

        Dim args As ArgumentType = e.Argument
        Try
            Dim Val As String() = args._arrayToSort
            If Val.Length > 1 Then
                Select Case args._algorithm
                    Case 0
                        sortBubble(Val, BackgroundWorkerDoSort, e)
                    Case 1
                        sortRipple(Val, BackgroundWorkerDoSort, e)
                    Case 2
                        sortIntern(Val, BackgroundWorkerDoSort, e)
                    Case 3
                        sortQuick(Val, 0, Val.Length - 1, BackgroundWorkerDoSort, e)
                    Case 4
                        sortInsertion(Val, BackgroundWorkerDoSort, e)
                    Case 5
                        sortSelection(Val, BackgroundWorkerDoSort, e)
                    Case Else
                        MessageBox.Show("Bitte wählen Sie einen Sortieralgorithmus!", "Achtung!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Select
            End If
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
        lbl_donePercent.Text = "Sortieren: " & e.ProgressPercentage.ToString() & "%"
        lblExecTime.Text = String.Format("Execution Time: {0}:{1}:{2},{3}", _timer.Elapsed.Hours, _timer.Elapsed.Minutes, _timer.Elapsed.Seconds, _timer.Elapsed.Milliseconds)
        prg_done.Value = e.ProgressPercentage
    End Sub
#End Region
#Region "RunWorkerCompleted"
    Private Sub BackgroundWorkerDoSort_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorkerDoSort.RunWorkerCompleted
        If e.Cancelled Then
            lblExecTime.Text = "Sortieren abgebrochen!"
        Else
            Dim timespan As TimeSpan = _timer.Elapsed
            lblExecTime.Text = String.Format("Execution Time: {0}:{1}:{2},{3}", _timer.Elapsed.Hours, _timer.Elapsed.Minutes, _timer.Elapsed.Seconds, _timer.Elapsed.Milliseconds)
            Dim words As Boolean = chk_words.Checked
            Dim Val As String() = e.Result
            'output ins textfeld
            If words Then
                rtfOutput.Text = String.Join(" ", Val)
            Else
                rtfOutput.Text = String.Join("", Val)
            End If
        End If
        lbl_donePercent.Text = "Done [%]: 100"
        prg_done.Value = 100
        _timer.Stop()
        'reset the quicksort counter
        _counter = 0
        btnSort.Enabled = True
    End Sub
#End Region
#End Region

    Private Sub btn_cancelSort_Click(sender As Object, e As EventArgs) Handles btn_cancelSort.Click
        If BackgroundWorkerDoSort.IsBusy Then
            BackgroundWorkerDoSort.CancelAsync()
            btn_cancelSort.Enabled = False
            btnSort.Enabled = True
        End If
        If BackgroundWorkerPrepare.IsBusy Then
            BackgroundWorkerPrepare.CancelAsync()
            btn_cancelSort.Enabled = False
            btnSort.Enabled = True
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

    End Sub
#End Region
End Class
#Region "Custom Class for Async args"
'For passing arguments to the async backgroundworker
Public Class ArgumentType
    Public _arrayToSort As String()
    Public _algorithm As Integer
    Public _inputString As String
    Public _words As Boolean
End Class
#End Region