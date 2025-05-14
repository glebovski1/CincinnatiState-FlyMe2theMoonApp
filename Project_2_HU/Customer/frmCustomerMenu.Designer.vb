<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCustomerMenu
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.lblHello = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(144, 122)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(179, 40)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Update profile"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(144, 187)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(179, 43)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Add Flight"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(144, 255)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(179, 42)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Show Past Flight"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(144, 324)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(179, 38)
        Me.Button4.TabIndex = 3
        Me.Button4.Text = "Show Future Flights"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'lblHello
        '
        Me.lblHello.AutoSize = True
        Me.lblHello.Location = New System.Drawing.Point(140, 64)
        Me.lblHello.MinimumSize = New System.Drawing.Size(200, 25)
        Me.lblHello.Name = "lblHello"
        Me.lblHello.Size = New System.Drawing.Size(200, 25)
        Me.lblHello.TabIndex = 4
        Me.lblHello.Text = "Hello"
        Me.lblHello.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(144, 381)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(179, 42)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'frmCustomerMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(497, 489)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblHello)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "frmCustomerMenu"
        Me.Text = "Customer Main Menu"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents lblHello As Label
    Friend WithEvents btnClose As Button
End Class
