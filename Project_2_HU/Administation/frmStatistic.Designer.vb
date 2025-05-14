<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStatistic
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
        Me.lblTotalNumberOFCustomers = New System.Windows.Forms.Label()
        Me.lblTotalFlights = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblAverageMiles = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lisPilotsStatisitic = New System.Windows.Forms.ListBox()
        Me.lisAttendantStatistic = New System.Windows.Forms.ListBox()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(198, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Total number of customers"
        '
        'lblTotalNumberOFCustomers
        '
        Me.lblTotalNumberOFCustomers.AutoSize = True
        Me.lblTotalNumberOFCustomers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalNumberOFCustomers.Location = New System.Drawing.Point(59, 82)
        Me.lblTotalNumberOFCustomers.MinimumSize = New System.Drawing.Size(100, 25)
        Me.lblTotalNumberOFCustomers.Name = "lblTotalNumberOFCustomers"
        Me.lblTotalNumberOFCustomers.Size = New System.Drawing.Size(100, 25)
        Me.lblTotalNumberOFCustomers.TabIndex = 1
        '
        'lblTotalFlights
        '
        Me.lblTotalFlights.AutoSize = True
        Me.lblTotalFlights.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalFlights.Location = New System.Drawing.Point(297, 82)
        Me.lblTotalFlights.MinimumSize = New System.Drawing.Size(100, 25)
        Me.lblTotalFlights.Name = "lblTotalFlights"
        Me.lblTotalFlights.Size = New System.Drawing.Size(100, 25)
        Me.lblTotalFlights.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(238, 36)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(251, 20)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Total flights taken by all customers"
        '
        'lblAverageMiles
        '
        Me.lblAverageMiles.AutoSize = True
        Me.lblAverageMiles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAverageMiles.Location = New System.Drawing.Point(576, 82)
        Me.lblAverageMiles.MinimumSize = New System.Drawing.Size(100, 25)
        Me.lblAverageMiles.Name = "lblAverageMiles"
        Me.lblAverageMiles.Size = New System.Drawing.Size(100, 25)
        Me.lblAverageMiles.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(495, 36)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(261, 20)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Average miles flown for all customer"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblAverageMiles)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.lblTotalFlights)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.lblTotalNumberOFCustomers)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(41, 44)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(775, 153)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Passengers"
        '
        'lisPilotsStatisitic
        '
        Me.lisPilotsStatisitic.FormattingEnabled = True
        Me.lisPilotsStatisitic.ItemHeight = 20
        Me.lisPilotsStatisitic.Location = New System.Drawing.Point(41, 237)
        Me.lisPilotsStatisitic.Name = "lisPilotsStatisitic"
        Me.lisPilotsStatisitic.Size = New System.Drawing.Size(363, 524)
        Me.lisPilotsStatisitic.TabIndex = 7
        '
        'lisAttendantStatistic
        '
        Me.lisAttendantStatistic.FormattingEnabled = True
        Me.lisAttendantStatistic.ItemHeight = 20
        Me.lisAttendantStatistic.Location = New System.Drawing.Point(434, 237)
        Me.lisAttendantStatistic.Name = "lisAttendantStatistic"
        Me.lisAttendantStatistic.Size = New System.Drawing.Size(382, 524)
        Me.lisAttendantStatistic.TabIndex = 8
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(338, 801)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(149, 50)
        Me.btnOk.TabIndex = 9
        Me.btnOk.Text = "Ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'frmStatistic
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(845, 874)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.lisAttendantStatistic)
        Me.Controls.Add(Me.lisPilotsStatisitic)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "frmStatistic"
        Me.Text = "Statistic"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents lblTotalNumberOFCustomers As Label
    Friend WithEvents lblTotalFlights As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblAverageMiles As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lisPilotsStatisitic As ListBox
    Friend WithEvents lisAttendantStatistic As ListBox
    Friend WithEvents btnOk As Button
End Class
