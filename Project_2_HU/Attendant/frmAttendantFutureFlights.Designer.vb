<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAttendantFutureFlights
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
        Me.btnOK = New System.Windows.Forms.Button()
        Me.lstFutureFlights = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(156, 372)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(144, 66)
        Me.btnOK.TabIndex = 5
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'lstFutureFlights
        '
        Me.lstFutureFlights.FormattingEnabled = True
        Me.lstFutureFlights.ItemHeight = 20
        Me.lstFutureFlights.Location = New System.Drawing.Point(33, 29)
        Me.lstFutureFlights.Name = "lstFutureFlights"
        Me.lstFutureFlights.Size = New System.Drawing.Size(395, 324)
        Me.lstFutureFlights.TabIndex = 4
        '
        'frmAttendantFutureFlights
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(453, 450)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.lstFutureFlights)
        Me.Name = "frmAttendantFutureFlights"
        Me.Text = "Attendant Future Flights"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnOK As Button
    Friend WithEvents lstFutureFlights As ListBox
End Class
