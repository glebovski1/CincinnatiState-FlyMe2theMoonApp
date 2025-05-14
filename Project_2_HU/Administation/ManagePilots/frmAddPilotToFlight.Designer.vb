<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddPilotToFlight
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbPilots = New System.Windows.Forms.ComboBox()
        Me.cmbFlights = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnAssign = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(98, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Pilot"
        '
        'cmbPilots
        '
        Me.cmbPilots.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPilots.FormattingEnabled = True
        Me.cmbPilots.Location = New System.Drawing.Point(41, 134)
        Me.cmbPilots.Name = "cmbPilots"
        Me.cmbPilots.Size = New System.Drawing.Size(183, 28)
        Me.cmbPilots.TabIndex = 1
        '
        'cmbFlights
        '
        Me.cmbFlights.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFlights.FormattingEnabled = True
        Me.cmbFlights.Location = New System.Drawing.Point(282, 134)
        Me.cmbFlights.Name = "cmbFlights"
        Me.cmbFlights.Size = New System.Drawing.Size(183, 28)
        Me.cmbFlights.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(339, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Flight"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(69, 264)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(127, 51)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnAssign
        '
        Me.btnAssign.Location = New System.Drawing.Point(303, 264)
        Me.btnAssign.Name = "btnAssign"
        Me.btnAssign.Size = New System.Drawing.Size(127, 51)
        Me.btnAssign.TabIndex = 5
        Me.btnAssign.Text = "Assign"
        Me.btnAssign.UseVisualStyleBackColor = True
        '
        'frmAddPilotToFlight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(531, 402)
        Me.Controls.Add(Me.btnAssign)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.cmbFlights)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbPilots)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmAddPilotToFlight"
        Me.Text = "Assign Pilot to Flight"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents cmbPilots As ComboBox
    Friend WithEvents cmbFlights As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnClose As Button
    Friend WithEvents btnAssign As Button
End Class
