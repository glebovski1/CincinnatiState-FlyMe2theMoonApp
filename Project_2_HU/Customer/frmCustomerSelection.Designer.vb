<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCustomerSelection
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
        Me.cmbPassengers = New System.Windows.Forms.ComboBox()
        Me.btnSelect = New System.Windows.Forms.Button()
        Me.btnAddNewCustomer = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(181, 64)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(93, 20)
        Me.Label9.TabIndex = 40
        Me.Label9.Text = "Passengers"
        '
        'cmbPassengers
        '
        Me.cmbPassengers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPassengers.FormattingEnabled = True
        Me.cmbPassengers.Location = New System.Drawing.Point(90, 108)
        Me.cmbPassengers.Name = "cmbPassengers"
        Me.cmbPassengers.Size = New System.Drawing.Size(267, 28)
        Me.cmbPassengers.TabIndex = 39
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(162, 256)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(132, 45)
        Me.btnSelect.TabIndex = 41
        Me.btnSelect.Text = "Select"
        Me.btnSelect.UseVisualStyleBackColor = True
        '
        'btnAddNewCustomer
        '
        Me.btnAddNewCustomer.Location = New System.Drawing.Point(162, 318)
        Me.btnAddNewCustomer.Name = "btnAddNewCustomer"
        Me.btnAddNewCustomer.Size = New System.Drawing.Size(132, 45)
        Me.btnAddNewCustomer.TabIndex = 42
        Me.btnAddNewCustomer.Text = "Add New"
        Me.btnAddNewCustomer.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(162, 382)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(132, 43)
        Me.btnClose.TabIndex = 43
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'frmCustomerSelection
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(458, 462)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnAddNewCustomer)
        Me.Controls.Add(Me.btnSelect)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cmbPassengers)
        Me.Name = "frmCustomerSelection"
        Me.Text = "Select customer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label9 As Label
    Friend WithEvents cmbPassengers As ComboBox
    Friend WithEvents btnSelect As Button
    Friend WithEvents btnAddNewCustomer As Button
    Friend WithEvents btnClose As Button
End Class
