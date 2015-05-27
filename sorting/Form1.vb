Imports System.Threading
Imports System.IO
Public Class Form1
    'define applicationwide timer
    Public _timer As Stopwatch = New Stopwatch

#Region "Buttons auf Form1"
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
#End Region 
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

            'programmsnippet zum abbrechen und terminieren des BackgroundWorkers.
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
                    'gibt den geschätzen fortschritt in % zurück. dazu wird auch die aktuelle aufgabe zurückgegeben
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

    'sub zum updaten des UI für Progressinformationen des Backgroundworkers.
    Private Sub BackgroundWorkerPrepare_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorkerPrepare.ProgressChanged
        lblExecTime.Text = "Preparing input for sorting..."
        lbl_donePercent.Text = e.UserState.ToString() & e.ProgressPercentage.ToString() & "%"
        prg_done.Value = e.ProgressPercentage
    End Sub

    'sub welche ausgeführt wird, nachdem der BackgroundWorker terminiert
    Private Sub BackgroundWorkerPrepare_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorkerPrepare.RunWorkerCompleted
        lblExecTime.Text = "Execution Time: 0:0:0,0"
        prg_done.Value = 100
        'Prüfe ob abgebrochen wurde, oder ob der BackgroundWorker komplett durch ist.
        If Not e.Cancelled Then
            'rufe caller auf (modUtil.vb)
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
#Region "Menu"
    'Sub to capture shortcuts
    Private Sub catchShortCut(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.Control Then
            Select Case e.KeyCode.ToString()
                Case "N"
                    mnu_datei_neu_Click(sender, e)
                Case "O"
                    mnu_datei_open_Click(sender, e)
                Case "Q"
                    mnu_datei_close_Click(sender, e)
                Case "S"
                    mnu_datei_save_Click(sender, e)
                Case "X"
                    'do nothing, is handled by the operating system already, probably better
                Case "C"
                    'do nothing, is handled by the operating system already, probably better
                Case "V"
                    'do Nothing, is handled by the operating system already, probably better
                Case "R"
                    mnu_edit_sort_Click(sender, e)
                Case "U"
                    mnu_options_uml_Click(sender, e)
            End Select
        End If
    End Sub
#Region "Datei"
    Private Sub mnu_datei_close_Click(sender As Object, e As EventArgs) Handles mnu_datei_close.Click
        Me.Close()
    End Sub

    Private Sub mnu_datei_neu_Click(sender As Object, e As EventArgs) Handles mnu_datei_neu.Click
        rtfInput.Text = ""
        rtfOutput.Text = ""
    End Sub

    Private Sub mnu_datei_open_Click(sender As Object, e As EventArgs) Handles mnu_datei_open.Click
        Dim dlg_open As OpenFileDialog = New OpenFileDialog
        dlg_open.Filter = "Text files (*.txt)|*.txt"
        dlg_open.FilterIndex = 1
        dlg_open.Multiselect = False
        If dlg_open.ShowDialog = DialogResult.OK Then
            rtfInput.Text = File.ReadAllText(dlg_open.FileName)
        End If
    End Sub

    Private Sub mnu_datei_save_Click(sender As Object, e As EventArgs) Handles mnu_datei_save.Click
        Dim dlg_save As SaveFileDialog = New SaveFileDialog
        dlg_save.Filter = "Text files (*.txt)|*.txt"
        dlg_save.FilterIndex = 1
        dlg_save.SupportMultiDottedExtensions = False
        If dlg_save.ShowDialog = Windows.Forms.DialogResult.OK Then
            File.WriteAllText(dlg_save.FileName, rtfOutput.Text)
        End If
    End Sub
#End Region
#Region "Bearbeiten"
    Private Sub mnu_edit_cut_Click(sender As Object, e As EventArgs) Handles mnu_edit_cut.Click
        Clipboard.SetText(rtfInput.SelectedText)
        rtfInput.SelectedText.Remove(0)
    End Sub

    Private Sub mnu_edit_copy_Click(sender As Object, e As EventArgs) Handles mnu_edit_copy.Click
        Clipboard.SetText(rtfInput.SelectedText)
    End Sub

    Private Sub mnu_edit_paste_Click(sender As Object, e As EventArgs) Handles mnu_edit_paste.Click
        rtfInput.SelectedText = Clipboard.GetText
    End Sub

    Private Sub mnu_edit_sort_Click(sender As Object, e As EventArgs) Handles mnu_edit_sort.Click
        btnSort_Click(sender, e)
    End Sub
#End Region
#Region "Optionen"
    Private Sub mnu_options_uml_Click(sender As Object, e As EventArgs) Handles mnu_options_uml.Click
        If chkUmlaute.Checked Then
            chkUmlaute.Checked = False
        ElseIf Not chkUmlaute.Checked Then
            chkUmlaute.Checked = True
        End If
    End Sub

    Private Sub mnu_options_color_form_Click(sender As Object, e As EventArgs) Handles mnu_options_color_form.Click
        Dim dlg_color As ColorDialog = New ColorDialog()
        dlg_color.AnyColor = True
        dlg_color.AllowFullOpen = True
        If dlg_color.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.BackColor = dlg_color.Color
        End If
    End Sub

    Private Sub mnu_options_color_txt_Click(sender As Object, e As EventArgs) Handles mnu_options_color_txt.Click
        Dim dlg_color As ColorDialog = New ColorDialog()
        dlg_color.AnyColor = True
        dlg_color.AllowFullOpen = True
        If dlg_color.ShowDialog = Windows.Forms.DialogResult.OK Then
            rtfInput.BackColor = dlg_color.Color
            rtfOutput.BackColor = dlg_color.Color
        End If
    End Sub
#End Region
#Region "Infos"
    Private Sub ZumProgrammToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ZumProgrammToolStripMenuItem.Click
        MessageBox.Show("Entwickelt durch Marius Schär" & vbCrLf & "2015 im Rahmen des IET-Moduls 318" & vbCrLf & "Das Programm kann strings mit verschiedenen Sortieralgorithmen und anderen Parametern sortieren.", "Informationen zum Program", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub ZumAutorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ZumAutorToolStripMenuItem.Click
        MessageBox.Show("Marius Schär, geb. 1997" & vbCrLf & "Informatiklehrling, Jahrgang 2013" & vbCrLf & "Lehrfirma: login Berufsbildung / SBB" & vbCrLf & "github: http://github.com/schaerm", "Informationen zum Autor", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub RechteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RechteToolStripMenuItem.Click
        MessageBox.Show("Sämtliche Haftung ausgeschlossen" & vbCrLf & "Programmcode unter GPLv2 Lizenz auf github verfügbar:" & vbCrLf & "http://github.com/schaerm/sorting", "Rechtliches", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
#End Region
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