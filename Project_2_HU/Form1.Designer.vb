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
        Dim btnCustomer As System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnPilot = New System.Windows.Forms.Button()
        Me.btnAttendant = New System.Windows.Forms.Button()
        Me.btnAdministration = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        btnCustomer = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnCustomer
        '
        btnCustomer.Location = New System.Drawing.Point(147, 157)
        btnCustomer.Name = "btnCustomer"
        btnCustomer.Size = New System.Drawing.Size(125, 48)
        btnCustomer.TabIndex = 1
        btnCustomer.Text = "Customer"
        btnCustomer.UseVisualStyleBackColor = True
        AddHandler btnCustomer.Click, AddressOf Me.btnCustomer_Click
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(143, 112)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(141, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Select type of user"
        '
        'btnPilot
        '
        Me.btnPilot.Location = New System.Drawing.Point(147, 224)
        Me.btnPilot.Name = "btnPilot"
        Me.btnPilot.Size = New System.Drawing.Size(125, 44)
        Me.btnPilot.TabIndex = 2
        Me.btnPilot.Text = "Pilot"
        Me.btnPilot.UseVisualStyleBackColor = True
        '
        'btnAttendant
        '
        Me.btnAttendant.Location = New System.Drawing.Point(147, 291)
        Me.btnAttendant.Name = "btnAttendant"
        Me.btnAttendant.Size = New System.Drawing.Size(125, 44)
        Me.btnAttendant.TabIndex = 3
        Me.btnAttendant.Text = "Attendant"
        Me.btnAttendant.UseVisualStyleBackColor = True
        '
        'btnAdministration
        '
        Me.btnAdministration.Location = New System.Drawing.Point(147, 358)
        Me.btnAdministration.Name = "btnAdministration"
        Me.btnAdministration.Size = New System.Drawing.Size(125, 44)
        Me.btnAdministration.TabIndex = 4
        Me.btnAdministration.Text = "Administration"
        Me.btnAdministration.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(147, 432)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(125, 41)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(408, 550)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnAdministration)
        Me.Controls.Add(Me.btnAttendant)
        Me.Controls.Add(Me.btnPilot)
        Me.Controls.Add(btnCustomer)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "User Type"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents btnPilot As Button
    Friend WithEvents btnAttendant As Button
    Friend WithEvents btnAdministration As Button
    Friend WithEvents btnClose As Button
End Class
