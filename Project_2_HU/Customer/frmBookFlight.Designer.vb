<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBookFlight
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
        Me.cmbFlights = New System.Windows.Forms.ComboBox()
        Me.btnBookFlight = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.rbReserve = New System.Windows.Forms.RadioButton()
        Me.rbNotReserve = New System.Windows.Forms.RadioButton()
        Me.btnSelectSeat = New System.Windows.Forms.Button()
        Me.lblPriceWithReservation = New System.Windows.Forms.Label()
        Me.lblPriceWithoutReservation = New System.Windows.Forms.Label()
        Me.lblSeat = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(116, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Flight"
        '
        'cmbFlights
        '
        Me.cmbFlights.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFlights.FormattingEnabled = True
        Me.cmbFlights.Location = New System.Drawing.Point(52, 119)
        Me.cmbFlights.Name = "cmbFlights"
        Me.cmbFlights.Size = New System.Drawing.Size(336, 28)
        Me.cmbFlights.TabIndex = 1
        '
        'btnBookFlight
        '
        Me.btnBookFlight.Location = New System.Drawing.Point(55, 422)
        Me.btnBookFlight.Name = "btnBookFlight"
        Me.btnBookFlight.Size = New System.Drawing.Size(123, 45)
        Me.btnBookFlight.TabIndex = 4
        Me.btnBookFlight.Text = "Book"
        Me.btnBookFlight.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(204, 422)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(125, 46)
        Me.btnClose.TabIndex = 5
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'rbReserve
        '
        Me.rbReserve.AutoSize = True
        Me.rbReserve.Enabled = False
        Me.rbReserve.Location = New System.Drawing.Point(63, 281)
        Me.rbReserve.Name = "rbReserve"
        Me.rbReserve.Size = New System.Drawing.Size(93, 24)
        Me.rbReserve.TabIndex = 6
        Me.rbReserve.TabStop = True
        Me.rbReserve.Text = "Reserve"
        Me.rbReserve.UseVisualStyleBackColor = True
        '
        'rbNotReserve
        '
        Me.rbNotReserve.AutoSize = True
        Me.rbNotReserve.Enabled = False
        Me.rbNotReserve.Location = New System.Drawing.Point(63, 334)
        Me.rbNotReserve.Name = "rbNotReserve"
        Me.rbNotReserve.Size = New System.Drawing.Size(115, 24)
        Me.rbNotReserve.TabIndex = 7
        Me.rbNotReserve.TabStop = True
        Me.rbNotReserve.Text = "Not reserve"
        Me.rbNotReserve.UseVisualStyleBackColor = True
        '
        'btnSelectSeat
        '
        Me.btnSelectSeat.Location = New System.Drawing.Point(63, 197)
        Me.btnSelectSeat.Name = "btnSelectSeat"
        Me.btnSelectSeat.Size = New System.Drawing.Size(109, 47)
        Me.btnSelectSeat.TabIndex = 8
        Me.btnSelectSeat.Text = "Sellect Seat"
        Me.btnSelectSeat.UseVisualStyleBackColor = True
        '
        'lblPriceWithReservation
        '
        Me.lblPriceWithReservation.AutoSize = True
        Me.lblPriceWithReservation.Location = New System.Drawing.Point(229, 285)
        Me.lblPriceWithReservation.MinimumSize = New System.Drawing.Size(100, 20)
        Me.lblPriceWithReservation.Name = "lblPriceWithReservation"
        Me.lblPriceWithReservation.Size = New System.Drawing.Size(100, 20)
        Me.lblPriceWithReservation.TabIndex = 9
        '
        'lblPriceWithoutReservation
        '
        Me.lblPriceWithoutReservation.AutoSize = True
        Me.lblPriceWithoutReservation.Location = New System.Drawing.Point(229, 338)
        Me.lblPriceWithoutReservation.MinimumSize = New System.Drawing.Size(100, 20)
        Me.lblPriceWithoutReservation.Name = "lblPriceWithoutReservation"
        Me.lblPriceWithoutReservation.Size = New System.Drawing.Size(100, 20)
        Me.lblPriceWithoutReservation.TabIndex = 10
        '
        'lblSeat
        '
        Me.lblSeat.AutoSize = True
        Me.lblSeat.Location = New System.Drawing.Point(200, 210)
        Me.lblSeat.MinimumSize = New System.Drawing.Size(100, 20)
        Me.lblSeat.Name = "lblSeat"
        Me.lblSeat.Size = New System.Drawing.Size(100, 20)
        Me.lblSeat.TabIndex = 11
        '
        'frmBookFlight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(428, 499)
        Me.Controls.Add(Me.lblSeat)
        Me.Controls.Add(Me.lblPriceWithoutReservation)
        Me.Controls.Add(Me.lblPriceWithReservation)
        Me.Controls.Add(Me.btnSelectSeat)
        Me.Controls.Add(Me.rbNotReserve)
        Me.Controls.Add(Me.rbReserve)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnBookFlight)
        Me.Controls.Add(Me.cmbFlights)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmBookFlight"
        Me.Text = "Book Flight"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents cmbFlights As ComboBox
    Friend WithEvents btnBookFlight As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents rbReserve As RadioButton
    Friend WithEvents rbNotReserve As RadioButton
    Friend WithEvents btnSelectSeat As Button
    Friend WithEvents lblPriceWithReservation As Label
    Friend WithEvents lblPriceWithoutReservation As Label
    Friend WithEvents lblSeat As Label
End Class
