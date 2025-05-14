<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddAttendantToFlight
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
        Me.btnAssign = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.cmbFlights = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbAttendant = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnAssign
        '
        Me.btnAssign.Location = New System.Drawing.Point(330, 256)
        Me.btnAssign.Name = "btnAssign"
        Me.btnAssign.Size = New System.Drawing.Size(127, 51)
        Me.btnAssign.TabIndex = 11
        Me.btnAssign.Text = "Assign"
        Me.btnAssign.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(96, 256)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(127, 51)
        Me.btnClose.TabIndex = 10
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'cmbFlights
        '
        Me.cmbFlights.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFlights.FormattingEnabled = True
        Me.cmbFlights.Location = New System.Drawing.Point(309, 126)
        Me.cmbFlights.Name = "cmbFlights"
        Me.cmbFlights.Size = New System.Drawing.Size(183, 28)
        Me.cmbFlights.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(366, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 20)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Flight"
        '
        'cmbAttendant
        '
        Me.cmbAttendant.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAttendant.FormattingEnabled = True
        Me.cmbAttendant.Location = New System.Drawing.Point(68, 126)
        Me.cmbAttendant.Name = "cmbAttendant"
        Me.cmbAttendant.Size = New System.Drawing.Size(183, 28)
        Me.cmbAttendant.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(125, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 20)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Attendant"
        '
        'frmAddAttendantToFlight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(580, 389)
        Me.Controls.Add(Me.btnAssign)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.cmbFlights)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbAttendant)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmAddAttendantToFlight"
        Me.Text = "Add Attendant To Flight"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnAssign As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents cmbFlights As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbAttendant As ComboBox
    Friend WithEvents Label1 As Label
End Class
