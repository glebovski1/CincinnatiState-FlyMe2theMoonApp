<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddFlight
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
        Me.cmbPlaneType = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbAirportFrom = New System.Windows.Forms.ComboBox()
        Me.cmbAirportTo = New System.Windows.Forms.ComboBox()
        Me.dtpFlightDate = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpDepartureTime = New System.Windows.Forms.DateTimePicker()
        Me.dtpLandingTime = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.nupMilesFlown = New System.Windows.Forms.NumericUpDown()
        Me.txtFlightNumber = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        CType(Me.nupMilesFlown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(493, 87)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Plane:"
        '
        'cmbPlaneType
        '
        Me.cmbPlaneType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPlaneType.FormattingEnabled = True
        Me.cmbPlaneType.Location = New System.Drawing.Point(413, 153)
        Me.cmbPlaneType.Name = "cmbPlaneType"
        Me.cmbPlaneType.Size = New System.Drawing.Size(225, 28)
        Me.cmbPlaneType.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(500, 266)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "From:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(516, 422)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 20)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "To:"
        '
        'cmbAirportFrom
        '
        Me.cmbAirportFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAirportFrom.FormattingEnabled = True
        Me.cmbAirportFrom.Location = New System.Drawing.Point(413, 305)
        Me.cmbAirportFrom.Name = "cmbAirportFrom"
        Me.cmbAirportFrom.Size = New System.Drawing.Size(225, 28)
        Me.cmbAirportFrom.TabIndex = 4
        '
        'cmbAirportTo
        '
        Me.cmbAirportTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAirportTo.FormattingEnabled = True
        Me.cmbAirportTo.Location = New System.Drawing.Point(413, 463)
        Me.cmbAirportTo.Name = "cmbAirportTo"
        Me.cmbAirportTo.Size = New System.Drawing.Size(225, 28)
        Me.cmbAirportTo.TabIndex = 5
        '
        'dtpFlightDate
        '
        Me.dtpFlightDate.Location = New System.Drawing.Point(44, 155)
        Me.dtpFlightDate.Name = "dtpFlightDate"
        Me.dtpFlightDate.Size = New System.Drawing.Size(296, 26)
        Me.dtpFlightDate.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(148, 88)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 20)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Flight Date:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(131, 239)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(123, 20)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Departure Time:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(131, 396)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(108, 20)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Landing Time:"
        '
        'dtpDepartureTime
        '
        Me.dtpDepartureTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpDepartureTime.Location = New System.Drawing.Point(115, 290)
        Me.dtpDepartureTime.Name = "dtpDepartureTime"
        Me.dtpDepartureTime.ShowUpDown = True
        Me.dtpDepartureTime.Size = New System.Drawing.Size(144, 26)
        Me.dtpDepartureTime.TabIndex = 10
        '
        'dtpLandingTime
        '
        Me.dtpLandingTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpLandingTime.Location = New System.Drawing.Point(110, 465)
        Me.dtpLandingTime.Name = "dtpLandingTime"
        Me.dtpLandingTime.ShowUpDown = True
        Me.dtpLandingTime.Size = New System.Drawing.Size(144, 26)
        Me.dtpLandingTime.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(127, 581)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(112, 20)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Flight Number:"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(114, 745)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(134, 59)
        Me.btnAdd.TabIndex = 14
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(412, 745)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(134, 59)
        Me.btnClose.TabIndex = 15
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'nupMilesFlown
        '
        Me.nupMilesFlown.Location = New System.Drawing.Point(413, 650)
        Me.nupMilesFlown.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.nupMilesFlown.Name = "nupMilesFlown"
        Me.nupMilesFlown.Size = New System.Drawing.Size(164, 26)
        Me.nupMilesFlown.TabIndex = 16
        '
        'txtFlightNumber
        '
        Me.txtFlightNumber.Location = New System.Drawing.Point(99, 650)
        Me.txtFlightNumber.Name = "txtFlightNumber"
        Me.txtFlightNumber.Size = New System.Drawing.Size(160, 26)
        Me.txtFlightNumber.TabIndex = 17
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(478, 581)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(95, 20)
        Me.Label8.TabIndex = 18
        Me.Label8.Text = "Miles Flown:"
        '
        'frmAddFlight
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(720, 839)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtFlightNumber)
        Me.Controls.Add(Me.nupMilesFlown)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.dtpLandingTime)
        Me.Controls.Add(Me.dtpDepartureTime)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtpFlightDate)
        Me.Controls.Add(Me.cmbAirportTo)
        Me.Controls.Add(Me.cmbAirportFrom)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbPlaneType)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmAddFlight"
        Me.Text = "Add Flight"
        CType(Me.nupMilesFlown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents cmbPlaneType As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbAirportFrom As ComboBox
    Friend WithEvents cmbAirportTo As ComboBox
    Friend WithEvents dtpFlightDate As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents dtpDepartureTime As DateTimePicker
    Friend WithEvents dtpLandingTime As DateTimePicker
    Friend WithEvents Label7 As Label
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents nupMilesFlown As NumericUpDown
    Friend WithEvents txtFlightNumber As TextBox
    Friend WithEvents Label8 As Label
End Class
