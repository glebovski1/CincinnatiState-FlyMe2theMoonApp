<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmManagePilots
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
        Me.btnAddPilot = New System.Windows.Forms.Button()
        Me.btnDeletePilot = New System.Windows.Forms.Button()
        Me.btnAddToFlight = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnUpdatePilot = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnAddPilot
        '
        Me.btnAddPilot.Location = New System.Drawing.Point(83, 69)
        Me.btnAddPilot.Name = "btnAddPilot"
        Me.btnAddPilot.Size = New System.Drawing.Size(176, 56)
        Me.btnAddPilot.TabIndex = 0
        Me.btnAddPilot.Text = "Add Pilot"
        Me.btnAddPilot.UseVisualStyleBackColor = True
        '
        'btnDeletePilot
        '
        Me.btnDeletePilot.Location = New System.Drawing.Point(83, 222)
        Me.btnDeletePilot.Name = "btnDeletePilot"
        Me.btnDeletePilot.Size = New System.Drawing.Size(176, 56)
        Me.btnDeletePilot.TabIndex = 1
        Me.btnDeletePilot.Text = "Delete Pilot"
        Me.btnDeletePilot.UseVisualStyleBackColor = True
        '
        'btnAddToFlight
        '
        Me.btnAddToFlight.Location = New System.Drawing.Point(83, 307)
        Me.btnAddToFlight.Name = "btnAddToFlight"
        Me.btnAddToFlight.Size = New System.Drawing.Size(176, 56)
        Me.btnAddToFlight.TabIndex = 2
        Me.btnAddToFlight.Text = "Add To Flight"
        Me.btnAddToFlight.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(83, 395)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(176, 60)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnUpdatePilot
        '
        Me.btnUpdatePilot.Location = New System.Drawing.Point(83, 147)
        Me.btnUpdatePilot.Name = "btnUpdatePilot"
        Me.btnUpdatePilot.Size = New System.Drawing.Size(175, 50)
        Me.btnUpdatePilot.TabIndex = 4
        Me.btnUpdatePilot.Text = "Update Pilot"
        Me.btnUpdatePilot.UseVisualStyleBackColor = True
        '
        'frmManagePilots
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(346, 534)
        Me.Controls.Add(Me.btnUpdatePilot)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnAddToFlight)
        Me.Controls.Add(Me.btnDeletePilot)
        Me.Controls.Add(Me.btnAddPilot)
        Me.Name = "frmManagePilots"
        Me.Text = "Manage Pilots"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnAddPilot As Button
    Friend WithEvents btnDeletePilot As Button
    Friend WithEvents btnAddToFlight As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents btnUpdatePilot As Button
End Class
