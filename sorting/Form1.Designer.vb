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
        Me.btnSort = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.lstAlgo = New System.Windows.Forms.ListBox()
        Me.lblExecTime = New System.Windows.Forms.Label()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.rtfInput = New System.Windows.Forms.RichTextBox()
        Me.rtfOutput = New System.Windows.Forms.RichTextBox()
        Me.chkUmlaute = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'btnSort
        '
        Me.btnSort.Location = New System.Drawing.Point(858, 510)
        Me.btnSort.Name = "btnSort"
        Me.btnSort.Size = New System.Drawing.Size(109, 23)
        Me.btnSort.TabIndex = 2
        Me.btnSort.Text = "Sortieren"
        Me.btnSort.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(858, 539)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(109, 23)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "Beenden"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'lstAlgo
        '
        Me.lstAlgo.FormattingEnabled = True
        Me.lstAlgo.Items.AddRange(New Object() {"Bubble()", "Ripple()", "Intern()", "Quick()", "Insertion()"})
        Me.lstAlgo.Location = New System.Drawing.Point(858, 12)
        Me.lstAlgo.Name = "lstAlgo"
        Me.lstAlgo.Size = New System.Drawing.Size(109, 277)
        Me.lstAlgo.TabIndex = 4
        '
        'lblExecTime
        '
        Me.lblExecTime.AutoSize = True
        Me.lblExecTime.Location = New System.Drawing.Point(13, 575)
        Me.lblExecTime.Name = "lblExecTime"
        Me.lblExecTime.Size = New System.Drawing.Size(105, 13)
        Me.lblExecTime.TabIndex = 5
        Me.lblExecTime.Text = "Execution Time[ms]: "
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(858, 481)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(109, 23)
        Me.btnReset.TabIndex = 6
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'rtfInput
        '
        Me.rtfInput.Location = New System.Drawing.Point(13, 12)
        Me.rtfInput.Name = "rtfInput"
        Me.rtfInput.Size = New System.Drawing.Size(839, 277)
        Me.rtfInput.TabIndex = 7
        Me.rtfInput.Text = ""
        '
        'rtfOutput
        '
        Me.rtfOutput.Location = New System.Drawing.Point(12, 295)
        Me.rtfOutput.Name = "rtfOutput"
        Me.rtfOutput.ReadOnly = True
        Me.rtfOutput.Size = New System.Drawing.Size(839, 277)
        Me.rtfOutput.TabIndex = 8
        Me.rtfOutput.Text = ""
        '
        'chkUmlaute
        '
        Me.chkUmlaute.AutoSize = True
        Me.chkUmlaute.Location = New System.Drawing.Point(858, 296)
        Me.chkUmlaute.Name = "chkUmlaute"
        Me.chkUmlaute.Size = New System.Drawing.Size(65, 17)
        Me.chkUmlaute.TabIndex = 9
        Me.chkUmlaute.Text = "Umlaute"
        Me.chkUmlaute.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(979, 595)
        Me.Controls.Add(Me.chkUmlaute)
        Me.Controls.Add(Me.rtfOutput)
        Me.Controls.Add(Me.rtfInput)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.lblExecTime)
        Me.Controls.Add(Me.lstAlgo)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnSort)
        Me.Name = "Form1"
        Me.Text = "Form1"
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

End Class
