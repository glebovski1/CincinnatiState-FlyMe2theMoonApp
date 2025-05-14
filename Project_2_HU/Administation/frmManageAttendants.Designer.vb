<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManageAttendants
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
        Me.btnAddToFlight = New System.Windows.Forms.Button()
        Me.btnDeleteAttendant = New System.Windows.Forms.Button()
        Me.btnAddAttendant = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnUpdateAttendant = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnAddToFlight
        '
        Me.btnAddToFlight.Location = New System.Drawing.Point(65, 305)
        Me.btnAddToFlight.Name = "btnAddToFlight"
        Me.btnAddToFlight.Size = New System.Drawing.Size(176, 56)
        Me.btnAddToFlight.TabIndex = 5
        Me.btnAddToFlight.Text = "Add To Flight"
        Me.btnAddToFlight.UseVisualStyleBackColor = True
        '
        'btnDeleteAttendant
        '
        Me.btnDeleteAttendant.Location = New System.Drawing.Point(65, 223)
        Me.btnDeleteAttendant.Name = "btnDeleteAttendant"
        Me.btnDeleteAttendant.Size = New System.Drawing.Size(176, 56)
        Me.btnDeleteAttendant.TabIndex = 4
        Me.btnDeleteAttendant.Text = "Delete Attendant"
        Me.btnDeleteAttendant.UseVisualStyleBackColor = True
        '
        'btnAddAttendant
        '
        Me.btnAddAttendant.Location = New System.Drawing.Point(65, 70)
        Me.btnAddAttendant.Name = "btnAddAttendant"
        Me.btnAddAttendant.Size = New System.Drawing.Size(176, 56)
        Me.btnAddAttendant.TabIndex = 3
        Me.btnAddAttendant.Text = "Add Attendant"
        Me.btnAddAttendant.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(65, 395)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(176, 60)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnUpdateAttendant
        '
        Me.btnUpdateAttendant.Location = New System.Drawing.Point(65, 151)
        Me.btnUpdateAttendant.Name = "btnUpdateAttendant"
        Me.btnUpdateAttendant.Size = New System.Drawing.Size(176, 49)
        Me.btnUpdateAttendant.TabIndex = 7
        Me.btnUpdateAttendant.Text = "Update Attendant"
        Me.btnUpdateAttendant.UseVisualStyleBackColor = True
        '
        'frmManageAttendants
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(319, 550)
        Me.Controls.Add(Me.btnUpdateAttendant)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnAddToFlight)
        Me.Controls.Add(Me.btnDeleteAttendant)
        Me.Controls.Add(Me.btnAddAttendant)
        Me.Name = "frmManageAttendants"
        Me.Text = "Manage Attendants"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnAddToFlight As Button
    Friend WithEvents btnDeleteAttendant As Button
    Friend WithEvents btnAddAttendant As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents btnUpdateAttendant As Button
End Class
