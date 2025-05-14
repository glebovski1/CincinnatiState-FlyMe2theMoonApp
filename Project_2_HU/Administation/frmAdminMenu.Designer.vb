<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAdminMenu
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
        Me.btnPilots = New System.Windows.Forms.Button()
        Me.btnAttendance = New System.Windows.Forms.Button()
        Me.btnStatistic = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnAddFlight = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnPilots
        '
        Me.btnPilots.Location = New System.Drawing.Point(71, 58)
        Me.btnPilots.Name = "btnPilots"
        Me.btnPilots.Size = New System.Drawing.Size(218, 48)
        Me.btnPilots.TabIndex = 0
        Me.btnPilots.Text = "Manage Pilots"
        Me.btnPilots.UseVisualStyleBackColor = True
        '
        'btnAttendance
        '
        Me.btnAttendance.Location = New System.Drawing.Point(71, 130)
        Me.btnAttendance.Name = "btnAttendance"
        Me.btnAttendance.Size = New System.Drawing.Size(218, 49)
        Me.btnAttendance.TabIndex = 1
        Me.btnAttendance.Text = "Manage Attendants"
        Me.btnAttendance.UseVisualStyleBackColor = True
        '
        'btnStatistic
        '
        Me.btnStatistic.Location = New System.Drawing.Point(71, 267)
        Me.btnStatistic.Name = "btnStatistic"
        Me.btnStatistic.Size = New System.Drawing.Size(218, 48)
        Me.btnStatistic.TabIndex = 2
        Me.btnStatistic.Text = "Statistic"
        Me.btnStatistic.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(71, 337)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(218, 51)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnAddFlight
        '
        Me.btnAddFlight.Location = New System.Drawing.Point(71, 201)
        Me.btnAddFlight.Name = "btnAddFlight"
        Me.btnAddFlight.Size = New System.Drawing.Size(217, 48)
        Me.btnAddFlight.TabIndex = 5
        Me.btnAddFlight.Text = "Add Flight"
        Me.btnAddFlight.UseVisualStyleBackColor = True
        '
        'frmAdminMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(364, 435)
        Me.Controls.Add(Me.btnAddFlight)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnStatistic)
        Me.Controls.Add(Me.btnAttendance)
        Me.Controls.Add(Me.btnPilots)
        Me.Name = "frmAdminMenu"
        Me.Text = "Admin Menu"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnPilots As Button
    Friend WithEvents btnAttendance As Button
    Friend WithEvents btnStatistic As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents btnAddFlight As Button
End Class
