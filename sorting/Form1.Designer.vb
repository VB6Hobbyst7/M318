<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.btnSort = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.lstAlgo = New System.Windows.Forms.ListBox()
        Me.lblExecTime = New System.Windows.Forms.Label()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.rtfInput = New System.Windows.Forms.RichTextBox()
        Me.rtfOutput = New System.Windows.Forms.RichTextBox()
        Me.chkUmlaute = New System.Windows.Forms.CheckBox()
        Me.chk_words = New System.Windows.Forms.CheckBox()
        Me.BackgroundWorkerDoSort = New System.ComponentModel.BackgroundWorker()
        Me.lbl_donePercent = New System.Windows.Forms.Label()
        Me.prg_done = New System.Windows.Forms.ProgressBar()
        Me.btn_cancelSort = New System.Windows.Forms.Button()
        Me.lbl_countChr = New System.Windows.Forms.Label()
        Me.mnu_strip = New System.Windows.Forms.MenuStrip()
        Me.mnu_datei = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu_datei_neu = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu_datei_open = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnu_datei_save = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnu_datei_close = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu_edit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu_edit_cut = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu_edit_copy = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu_edit_paste = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnu_edit_sort = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu_options = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu_options_uml = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripSeparator()
        Me.mnu_options_color = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu_options_color_form = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu_options_color_txt = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu_info = New System.Windows.Forms.ToolStripMenuItem()
        Me.BackgroundWorkerPrepare = New System.ComponentModel.BackgroundWorker()
        Me.ZumProgrammToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ZumAutorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RechteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnu_strip.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSort
        '
        Me.btnSort.Location = New System.Drawing.Point(858, 540)
        Me.btnSort.Name = "btnSort"
        Me.btnSort.Size = New System.Drawing.Size(109, 23)
        Me.btnSort.TabIndex = 2
        Me.btnSort.Text = "Sortieren"
        Me.btnSort.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(858, 569)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(109, 23)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "Beenden"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'lstAlgo
        '
        Me.lstAlgo.FormattingEnabled = True
        Me.lstAlgo.Items.AddRange(New Object() {"Bubblesort", "Ripplesort", "Internsort", "Quicksort", "Insertionsort", "Selectionsort"})
        Me.lstAlgo.Location = New System.Drawing.Point(858, 42)
        Me.lstAlgo.Name = "lstAlgo"
        Me.lstAlgo.Size = New System.Drawing.Size(109, 277)
        Me.lstAlgo.TabIndex = 4
        '
        'lblExecTime
        '
        Me.lblExecTime.AutoSize = True
        Me.lblExecTime.Location = New System.Drawing.Point(13, 605)
        Me.lblExecTime.Name = "lblExecTime"
        Me.lblExecTime.Size = New System.Drawing.Size(105, 13)
        Me.lblExecTime.TabIndex = 5
        Me.lblExecTime.Text = "Execution Time[ms]: "
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(858, 511)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(109, 23)
        Me.btnReset.TabIndex = 6
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'rtfInput
        '
        Me.rtfInput.Location = New System.Drawing.Point(13, 42)
        Me.rtfInput.Name = "rtfInput"
        Me.rtfInput.Size = New System.Drawing.Size(839, 277)
        Me.rtfInput.TabIndex = 7
        Me.rtfInput.Text = ""
        '
        'rtfOutput
        '
        Me.rtfOutput.Location = New System.Drawing.Point(12, 325)
        Me.rtfOutput.Name = "rtfOutput"
        Me.rtfOutput.ReadOnly = True
        Me.rtfOutput.Size = New System.Drawing.Size(839, 277)
        Me.rtfOutput.TabIndex = 8
        Me.rtfOutput.Text = ""
        '
        'chkUmlaute
        '
        Me.chkUmlaute.AutoSize = True
        Me.chkUmlaute.Location = New System.Drawing.Point(858, 326)
        Me.chkUmlaute.Name = "chkUmlaute"
        Me.chkUmlaute.Size = New System.Drawing.Size(65, 17)
        Me.chkUmlaute.TabIndex = 9
        Me.chkUmlaute.Text = "Umlaute"
        Me.chkUmlaute.UseVisualStyleBackColor = True
        '
        'chk_words
        '
        Me.chk_words.AutoSize = True
        Me.chk_words.Location = New System.Drawing.Point(858, 349)
        Me.chk_words.Name = "chk_words"
        Me.chk_words.Size = New System.Drawing.Size(58, 17)
        Me.chk_words.TabIndex = 10
        Me.chk_words.Text = "Wörter"
        Me.chk_words.UseVisualStyleBackColor = True
        '
        'BackgroundWorkerDoSort
        '
        Me.BackgroundWorkerDoSort.WorkerReportsProgress = True
        Me.BackgroundWorkerDoSort.WorkerSupportsCancellation = True
        '
        'lbl_donePercent
        '
        Me.lbl_donePercent.AutoSize = True
        Me.lbl_donePercent.Location = New System.Drawing.Point(329, 605)
        Me.lbl_donePercent.Name = "lbl_donePercent"
        Me.lbl_donePercent.Size = New System.Drawing.Size(53, 13)
        Me.lbl_donePercent.TabIndex = 11
        Me.lbl_donePercent.Text = "Done [%]:"
        '
        'prg_done
        '
        Me.prg_done.Location = New System.Drawing.Point(597, 608)
        Me.prg_done.Name = "prg_done"
        Me.prg_done.Size = New System.Drawing.Size(254, 13)
        Me.prg_done.TabIndex = 12
        '
        'btn_cancelSort
        '
        Me.btn_cancelSort.Enabled = False
        Me.btn_cancelSort.Location = New System.Drawing.Point(857, 482)
        Me.btn_cancelSort.Name = "btn_cancelSort"
        Me.btn_cancelSort.Size = New System.Drawing.Size(109, 23)
        Me.btn_cancelSort.TabIndex = 13
        Me.btn_cancelSort.Text = "Abbrechen"
        Me.btn_cancelSort.UseVisualStyleBackColor = True
        '
        'lbl_countChr
        '
        Me.lbl_countChr.AutoSize = True
        Me.lbl_countChr.Location = New System.Drawing.Point(858, 373)
        Me.lbl_countChr.Name = "lbl_countChr"
        Me.lbl_countChr.Size = New System.Drawing.Size(91, 13)
        Me.lbl_countChr.TabIndex = 14
        Me.lbl_countChr.Text = "x Zeichen/Wörter"
        '
        'mnu_strip
        '
        Me.mnu_strip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnu_datei, Me.mnu_edit, Me.mnu_options, Me.mnu_info})
        Me.mnu_strip.Location = New System.Drawing.Point(0, 0)
        Me.mnu_strip.Name = "mnu_strip"
        Me.mnu_strip.Size = New System.Drawing.Size(999, 24)
        Me.mnu_strip.TabIndex = 16
        Me.mnu_strip.Text = "MenuStrip1"
        '
        'mnu_datei
        '
        Me.mnu_datei.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnu_datei_neu, Me.mnu_datei_open, Me.ToolStripMenuItem1, Me.mnu_datei_save, Me.ToolStripMenuItem2, Me.mnu_datei_close})
        Me.mnu_datei.Name = "mnu_datei"
        Me.mnu_datei.Size = New System.Drawing.Size(46, 20)
        Me.mnu_datei.Text = "Datei"
        '
        'mnu_datei_neu
        '
        Me.mnu_datei_neu.Name = "mnu_datei_neu"
        Me.mnu_datei_neu.Size = New System.Drawing.Size(173, 22)
        Me.mnu_datei_neu.Text = "Neu [ctrl + n]"
        '
        'mnu_datei_open
        '
        Me.mnu_datei_open.Name = "mnu_datei_open"
        Me.mnu_datei_open.Size = New System.Drawing.Size(173, 22)
        Me.mnu_datei_open.Text = "Öffnen [ctrl + o]"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(170, 6)
        '
        'mnu_datei_save
        '
        Me.mnu_datei_save.Name = "mnu_datei_save"
        Me.mnu_datei_save.Size = New System.Drawing.Size(173, 22)
        Me.mnu_datei_save.Text = "Speichern [ctrl + s]"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(170, 6)
        '
        'mnu_datei_close
        '
        Me.mnu_datei_close.Name = "mnu_datei_close"
        Me.mnu_datei_close.Size = New System.Drawing.Size(173, 22)
        Me.mnu_datei_close.Text = "Beenden [ctrl + q]"
        '
        'mnu_edit
        '
        Me.mnu_edit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnu_edit_cut, Me.mnu_edit_copy, Me.mnu_edit_paste, Me.ToolStripMenuItem3, Me.mnu_edit_sort})
        Me.mnu_edit.Name = "mnu_edit"
        Me.mnu_edit.Size = New System.Drawing.Size(75, 20)
        Me.mnu_edit.Text = "Bearbeiten"
        '
        'mnu_edit_cut
        '
        Me.mnu_edit_cut.Name = "mnu_edit_cut"
        Me.mnu_edit_cut.Size = New System.Drawing.Size(195, 22)
        Me.mnu_edit_cut.Text = "Ausschneiden [ctrl + x]"
        '
        'mnu_edit_copy
        '
        Me.mnu_edit_copy.Name = "mnu_edit_copy"
        Me.mnu_edit_copy.Size = New System.Drawing.Size(195, 22)
        Me.mnu_edit_copy.Text = "Kopieren [ctrl + c]"
        '
        'mnu_edit_paste
        '
        Me.mnu_edit_paste.Name = "mnu_edit_paste"
        Me.mnu_edit_paste.Size = New System.Drawing.Size(195, 22)
        Me.mnu_edit_paste.Text = "Einfügen [ctrl + v]"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(192, 6)
        '
        'mnu_edit_sort
        '
        Me.mnu_edit_sort.Name = "mnu_edit_sort"
        Me.mnu_edit_sort.Size = New System.Drawing.Size(195, 22)
        Me.mnu_edit_sort.Text = "Sortieren [ctrl + r]"
        '
        'mnu_options
        '
        Me.mnu_options.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnu_options_uml, Me.ToolStripMenuItem4, Me.mnu_options_color})
        Me.mnu_options.Name = "mnu_options"
        Me.mnu_options.Size = New System.Drawing.Size(69, 20)
        Me.mnu_options.Text = "Optionen"
        '
        'mnu_options_uml
        '
        Me.mnu_options_uml.Name = "mnu_options_uml"
        Me.mnu_options_uml.Size = New System.Drawing.Size(168, 22)
        Me.mnu_options_uml.Text = "Umlaute [ctrl + u]"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(165, 6)
        '
        'mnu_options_color
        '
        Me.mnu_options_color.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnu_options_color_form, Me.mnu_options_color_txt})
        Me.mnu_options_color.Name = "mnu_options_color"
        Me.mnu_options_color.Size = New System.Drawing.Size(168, 22)
        Me.mnu_options_color.Text = "Farbe"
        '
        'mnu_options_color_form
        '
        Me.mnu_options_color_form.Name = "mnu_options_color_form"
        Me.mnu_options_color_form.Size = New System.Drawing.Size(152, 22)
        Me.mnu_options_color_form.Text = "Formular"
        '
        'mnu_options_color_txt
        '
        Me.mnu_options_color_txt.Name = "mnu_options_color_txt"
        Me.mnu_options_color_txt.Size = New System.Drawing.Size(152, 22)
        Me.mnu_options_color_txt.Text = "Textbox"
        '
        'mnu_info
        '
        Me.mnu_info.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ZumProgrammToolStripMenuItem, Me.ZumAutorToolStripMenuItem, Me.RechteToolStripMenuItem})
        Me.mnu_info.Name = "mnu_info"
        Me.mnu_info.Size = New System.Drawing.Size(45, 20)
        Me.mnu_info.Text = "Infos"
        '
        'BackgroundWorkerPrepare
        '
        Me.BackgroundWorkerPrepare.WorkerReportsProgress = True
        Me.BackgroundWorkerPrepare.WorkerSupportsCancellation = True
        '
        'ZumProgrammToolStripMenuItem
        '
        Me.ZumProgrammToolStripMenuItem.Name = "ZumProgrammToolStripMenuItem"
        Me.ZumProgrammToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.ZumProgrammToolStripMenuItem.Text = "Zum Programm"
        '
        'ZumAutorToolStripMenuItem
        '
        Me.ZumAutorToolStripMenuItem.Name = "ZumAutorToolStripMenuItem"
        Me.ZumAutorToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.ZumAutorToolStripMenuItem.Text = "Zum Autor"
        '
        'RechteToolStripMenuItem
        '
        Me.RechteToolStripMenuItem.Name = "RechteToolStripMenuItem"
        Me.RechteToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.RechteToolStripMenuItem.Text = "Rechte"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(999, 625)
        Me.Controls.Add(Me.mnu_strip)
        Me.Controls.Add(Me.lbl_countChr)
        Me.Controls.Add(Me.btn_cancelSort)
        Me.Controls.Add(Me.prg_done)
        Me.Controls.Add(Me.lbl_donePercent)
        Me.Controls.Add(Me.chk_words)
        Me.Controls.Add(Me.chkUmlaute)
        Me.Controls.Add(Me.rtfOutput)
        Me.Controls.Add(Me.rtfInput)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.lblExecTime)
        Me.Controls.Add(Me.lstAlgo)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnSort)
        Me.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.mnu_strip
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1015, 664)
        Me.MinimumSize = New System.Drawing.Size(995, 664)
        Me.Name = "Form1"
        Me.Text = "Sortieren_M_Schär"
        Me.mnu_strip.ResumeLayout(False)
        Me.mnu_strip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSort As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents lstAlgo As System.Windows.Forms.ListBox
    Friend WithEvents lblExecTime As System.Windows.Forms.Label
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents rtfInput As System.Windows.Forms.RichTextBox
    Friend WithEvents rtfOutput As System.Windows.Forms.RichTextBox
    Friend WithEvents chkUmlaute As System.Windows.Forms.CheckBox
    Friend WithEvents chk_words As System.Windows.Forms.CheckBox
    Friend WithEvents BackgroundWorkerDoSort As System.ComponentModel.BackgroundWorker
    Friend WithEvents lbl_donePercent As System.Windows.Forms.Label
    Friend WithEvents prg_done As System.Windows.Forms.ProgressBar
    Friend WithEvents btn_cancelSort As System.Windows.Forms.Button
    Friend WithEvents lbl_countChr As System.Windows.Forms.Label
    Friend WithEvents mnu_strip As System.Windows.Forms.MenuStrip
    Friend WithEvents mnu_datei As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_datei_neu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_datei_save As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_datei_close As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_edit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_edit_cut As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_edit_copy As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_edit_paste As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_options As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_info As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_datei_open As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnu_edit_sort As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_options_uml As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnu_options_color As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_options_color_form As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnu_options_color_txt As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BackgroundWorkerPrepare As System.ComponentModel.BackgroundWorker
    Friend WithEvents ZumProgrammToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ZumAutorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RechteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
