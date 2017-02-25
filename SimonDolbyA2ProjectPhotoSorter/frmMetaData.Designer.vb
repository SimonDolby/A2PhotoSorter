<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMetaData
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
        Me.txtResolution = New System.Windows.Forms.TextBox()
        Me.txtWidth = New System.Windows.Forms.TextBox()
        Me.txtHeight = New System.Windows.Forms.TextBox()
        Me.TxtDateTime = New System.Windows.Forms.TextBox()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.txtKeywords = New System.Windows.Forms.TextBox()
        Me.BtnMetaData = New System.Windows.Forms.Button()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.lblResolution = New System.Windows.Forms.Label()
        Me.lblWidth = New System.Windows.Forms.Label()
        Me.lblHeight = New System.Windows.Forms.Label()
        Me.lblKeywords = New System.Windows.Forms.Label()
        Me.TxtReso = New System.Windows.Forms.TextBox()
        Me.btnSaveChanges = New System.Windows.Forms.Button()
        Me.txtDimensions = New System.Windows.Forms.TextBox()
        Me.lblDimensions = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtResolution
        '
        Me.txtResolution.Location = New System.Drawing.Point(0, 0)
        Me.txtResolution.Name = "txtResolution"
        Me.txtResolution.Size = New System.Drawing.Size(100, 20)
        Me.txtResolution.TabIndex = 0
        '
        'txtWidth
        '
        Me.txtWidth.Location = New System.Drawing.Point(86, 203)
        Me.txtWidth.Name = "txtWidth"
        Me.txtWidth.ReadOnly = True
        Me.txtWidth.Size = New System.Drawing.Size(100, 20)
        Me.txtWidth.TabIndex = 0
        '
        'txtHeight
        '
        Me.txtHeight.Location = New System.Drawing.Point(86, 178)
        Me.txtHeight.Name = "txtHeight"
        Me.txtHeight.ReadOnly = True
        Me.txtHeight.Size = New System.Drawing.Size(100, 20)
        Me.txtHeight.TabIndex = 1
        '
        'TxtDateTime
        '
        Me.TxtDateTime.Location = New System.Drawing.Point(86, 65)
        Me.TxtDateTime.Name = "TxtDateTime"
        Me.TxtDateTime.ReadOnly = True
        Me.TxtDateTime.Size = New System.Drawing.Size(100, 20)
        Me.TxtDateTime.TabIndex = 2
        '
        'txtTitle
        '
        Me.txtTitle.Location = New System.Drawing.Point(86, 127)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.ReadOnly = True
        Me.txtTitle.Size = New System.Drawing.Size(100, 20)
        Me.txtTitle.TabIndex = 3
        '
        'txtKeywords
        '
        Me.txtKeywords.Location = New System.Drawing.Point(86, 153)
        Me.txtKeywords.Name = "txtKeywords"
        Me.txtKeywords.ReadOnly = True
        Me.txtKeywords.Size = New System.Drawing.Size(100, 20)
        Me.txtKeywords.TabIndex = 4
        '
        'BtnMetaData
        '
        Me.BtnMetaData.Location = New System.Drawing.Point(63, 396)
        Me.BtnMetaData.Name = "BtnMetaData"
        Me.BtnMetaData.Size = New System.Drawing.Size(75, 23)
        Me.BtnMetaData.TabIndex = 11
        Me.BtnMetaData.Text = "Edit Meta Data"
        '
        'lblTitle
        '
        Me.lblTitle.Location = New System.Drawing.Point(38, 129)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(100, 23)
        Me.lblTitle.TabIndex = 5
        Me.lblTitle.Text = "Title"
        '
        'lblDate
        '
        Me.lblDate.Location = New System.Drawing.Point(25, 68)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(59, 23)
        Me.lblDate.TabIndex = 6
        Me.lblDate.Text = "Date"
        '
        'lblResolution
        '
        Me.lblResolution.Location = New System.Drawing.Point(12, 101)
        Me.lblResolution.Name = "lblResolution"
        Me.lblResolution.Size = New System.Drawing.Size(68, 23)
        Me.lblResolution.TabIndex = 7
        Me.lblResolution.Text = "Resolution"
        '
        'lblWidth
        '
        Me.lblWidth.Location = New System.Drawing.Point(40, 207)
        Me.lblWidth.Name = "lblWidth"
        Me.lblWidth.Size = New System.Drawing.Size(40, 23)
        Me.lblWidth.TabIndex = 8
        Me.lblWidth.Text = "Width"
        '
        'lblHeight
        '
        Me.lblHeight.Location = New System.Drawing.Point(38, 178)
        Me.lblHeight.Name = "lblHeight"
        Me.lblHeight.Size = New System.Drawing.Size(42, 23)
        Me.lblHeight.TabIndex = 9
        Me.lblHeight.Text = "Height"
        '
        'lblKeywords
        '
        Me.lblKeywords.Location = New System.Drawing.Point(25, 154)
        Me.lblKeywords.Name = "lblKeywords"
        Me.lblKeywords.Size = New System.Drawing.Size(55, 23)
        Me.lblKeywords.TabIndex = 10
        Me.lblKeywords.Text = "Keywords"
        '
        'TxtReso
        '
        Me.TxtReso.Location = New System.Drawing.Point(86, 101)
        Me.TxtReso.Name = "TxtReso"
        Me.TxtReso.ReadOnly = True
        Me.TxtReso.Size = New System.Drawing.Size(100, 20)
        Me.TxtReso.TabIndex = 12
        '
        'btnSaveChanges
        '
        Me.btnSaveChanges.Location = New System.Drawing.Point(145, 396)
        Me.btnSaveChanges.Name = "btnSaveChanges"
        Me.btnSaveChanges.Size = New System.Drawing.Size(86, 23)
        Me.btnSaveChanges.TabIndex = 13
        Me.btnSaveChanges.Text = "Save Changes"
        Me.btnSaveChanges.UseVisualStyleBackColor = True
        '
        'txtDimensions
        '
        Me.txtDimensions.Location = New System.Drawing.Point(86, 230)
        Me.txtDimensions.Name = "txtDimensions"
        Me.txtDimensions.ReadOnly = True
        Me.txtDimensions.Size = New System.Drawing.Size(100, 20)
        Me.txtDimensions.TabIndex = 14
        '
        'lblDimensions
        '
        Me.lblDimensions.AutoSize = True
        Me.lblDimensions.Location = New System.Drawing.Point(12, 233)
        Me.lblDimensions.Name = "lblDimensions"
        Me.lblDimensions.Size = New System.Drawing.Size(61, 13)
        Me.lblDimensions.TabIndex = 15
        Me.lblDimensions.Text = "Dimensions"
        '
        'frmMetaData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(356, 536)
        Me.Controls.Add(Me.lblDimensions)
        Me.Controls.Add(Me.txtDimensions)
        Me.Controls.Add(Me.btnSaveChanges)
        Me.Controls.Add(Me.TxtReso)
        Me.Controls.Add(Me.txtWidth)
        Me.Controls.Add(Me.txtHeight)
        Me.Controls.Add(Me.TxtDateTime)
        Me.Controls.Add(Me.txtTitle)
        Me.Controls.Add(Me.txtKeywords)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.lblResolution)
        Me.Controls.Add(Me.lblWidth)
        Me.Controls.Add(Me.lblHeight)
        Me.Controls.Add(Me.lblKeywords)
        Me.Controls.Add(Me.BtnMetaData)
        Me.Name = "frmMetaData"
        Me.Text = "frmMetaData"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtResolution As System.Windows.Forms.TextBox
    Friend WithEvents txtWidth As System.Windows.Forms.TextBox
    Friend WithEvents txtHeight As System.Windows.Forms.TextBox
    Friend WithEvents TxtDateTime As System.Windows.Forms.TextBox
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents txtKeywords As System.Windows.Forms.TextBox
    Friend WithEvents BtnMetaData As System.Windows.Forms.Button
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblDate As System.Windows.Forms.Label
    Friend WithEvents lblResolution As System.Windows.Forms.Label
    Friend WithEvents lblWidth As System.Windows.Forms.Label
    Friend WithEvents lblHeight As System.Windows.Forms.Label
    Friend WithEvents lblKeywords As System.Windows.Forms.Label
    Friend WithEvents TxtReso As System.Windows.Forms.TextBox
    Friend WithEvents btnSaveChanges As System.Windows.Forms.Button
    Friend WithEvents txtDimensions As System.Windows.Forms.TextBox
    Friend WithEvents lblDimensions As System.Windows.Forms.Label
End Class
