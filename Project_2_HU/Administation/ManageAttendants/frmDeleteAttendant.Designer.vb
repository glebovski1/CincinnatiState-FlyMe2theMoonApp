<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDeleteAttendant
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
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbAttendants = New System.Windows.Forms.ComboBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.brnClose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(158, 46)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 20)
        Me.Label9.TabIndex = 48
        Me.Label9.Text = "Attendant"
        '
        'cmbAttendants
        '
        Me.cmbAttendants.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAttendants.FormattingEnabled = True
        Me.cmbAttendants.Location = New System.Drawing.Point(60, 98)
        Me.cmbAttendants.Name = "cmbAttendants"
        Me.cmbAttendants.Size = New System.Drawing.Size(293, 28)
        Me.cmbAttendants.TabIndex = 47
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(236, 273)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(117, 54)
        Me.btnDelete.TabIndex = 46
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'brnClose
        '
        Me.brnClose.Location = New System.Drawing.Point(60, 273)
        Me.brnClose.Name = "brnClose"
        Me.brnClose.Size = New System.Drawing.Size(129, 54)
        Me.brnClose.TabIndex = 45
        Me.brnClose.Text = "Close"
        Me.brnClose.UseVisualStyleBackColor = True
        '
        'frmDeleteAttendant
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 450)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cmbAttendants)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.brnClose)
        Me.Name = "frmDeleteAttendant"
        Me.Text = "frmDeleteAttendant"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label9 As Label
    Friend WithEvents cmbAttendants As ComboBox
    Friend WithEvents btnDelete As Button
    Friend WithEvents brnClose As Button
End Class
