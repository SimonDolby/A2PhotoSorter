<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGallery
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
        Me.pictImageClicked = New System.Windows.Forms.PictureBox()
        Me.pnlLargeThumbnails = New System.Windows.Forms.Panel()
        Me.pnlBase = New System.Windows.Forms.Panel()
        Me.pnlSmallThumbnails = New System.Windows.Forms.Panel()
        Me.pnlMediumThumbnails = New System.Windows.Forms.Panel()
        Me.rbtnLargeThumbnails = New System.Windows.Forms.RadioButton()
        Me.rbtnMediumThumbnails = New System.Windows.Forms.RadioButton()
        Me.rbtnSmallThumbnails = New System.Windows.Forms.RadioButton()
        CType(Me.pictImageClicked, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBase.SuspendLayout()
        Me.pnlSmallThumbnails.SuspendLayout()
        Me.SuspendLayout()
        '
        'pictImageClicked
        '
        Me.pictImageClicked.Location = New System.Drawing.Point(448, 2)
        Me.pictImageClicked.Name = "pictImageClicked"
        Me.pictImageClicked.Size = New System.Drawing.Size(357, 312)
        Me.pictImageClicked.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pictImageClicked.TabIndex = 1
        Me.pictImageClicked.TabStop = False
        '
        'pnlLargeThumbnails
        '
        Me.pnlLargeThumbnails.AutoScroll = True
        Me.pnlLargeThumbnails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlLargeThumbnails.Location = New System.Drawing.Point(0, 0)
        Me.pnlLargeThumbnails.Name = "pnlLargeThumbnails"
        Me.pnlLargeThumbnails.Size = New System.Drawing.Size(443, 631)
        Me.pnlLargeThumbnails.TabIndex = 9
        '
        'pnlBase
        '
        Me.pnlBase.Controls.Add(Me.pnlSmallThumbnails)
        Me.pnlBase.Controls.Add(Me.pnlLargeThumbnails)
        Me.pnlBase.Location = New System.Drawing.Point(-1, 2)
        Me.pnlBase.Name = "pnlBase"
        Me.pnlBase.Size = New System.Drawing.Size(443, 631)
        Me.pnlBase.TabIndex = 0
        '
        'pnlSmallThumbnails
        '
        Me.pnlSmallThumbnails.Controls.Add(Me.pnlMediumThumbnails)
        Me.pnlSmallThumbnails.Location = New System.Drawing.Point(0, 0)
        Me.pnlSmallThumbnails.Name = "pnlSmallThumbnails"
        Me.pnlSmallThumbnails.Size = New System.Drawing.Size(443, 581)
        Me.pnlSmallThumbnails.TabIndex = 10
        '
        'pnlMediumThumbnails
        '
        Me.pnlMediumThumbnails.AutoScroll = True
        Me.pnlMediumThumbnails.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlMediumThumbnails.Location = New System.Drawing.Point(0, 0)
        Me.pnlMediumThumbnails.Name = "pnlMediumThumbnails"
        Me.pnlMediumThumbnails.Size = New System.Drawing.Size(443, 581)
        Me.pnlMediumThumbnails.TabIndex = 11
        '
        'rbtnLargeThumbnails
        '
        Me.rbtnLargeThumbnails.AutoSize = True
        Me.rbtnLargeThumbnails.Location = New System.Drawing.Point(448, 373)
        Me.rbtnLargeThumbnails.Name = "rbtnLargeThumbnails"
        Me.rbtnLargeThumbnails.Size = New System.Drawing.Size(109, 17)
        Me.rbtnLargeThumbnails.TabIndex = 2
        Me.rbtnLargeThumbnails.TabStop = True
        Me.rbtnLargeThumbnails.Text = "Large Thumbnails"
        Me.rbtnLargeThumbnails.UseVisualStyleBackColor = True
        '
        'rbtnMediumThumbnails
        '
        Me.rbtnMediumThumbnails.AutoSize = True
        Me.rbtnMediumThumbnails.Location = New System.Drawing.Point(556, 373)
        Me.rbtnMediumThumbnails.Name = "rbtnMediumThumbnails"
        Me.rbtnMediumThumbnails.Size = New System.Drawing.Size(119, 17)
        Me.rbtnMediumThumbnails.TabIndex = 3
        Me.rbtnMediumThumbnails.TabStop = True
        Me.rbtnMediumThumbnails.Text = "Medium Thumbnails"
        Me.rbtnMediumThumbnails.UseVisualStyleBackColor = True
        '
        'rbtnSmallThumbnails
        '
        Me.rbtnSmallThumbnails.AutoSize = True
        Me.rbtnSmallThumbnails.Location = New System.Drawing.Point(671, 373)
        Me.rbtnSmallThumbnails.Name = "rbtnSmallThumbnails"
        Me.rbtnSmallThumbnails.Size = New System.Drawing.Size(107, 17)
        Me.rbtnSmallThumbnails.TabIndex = 4
        Me.rbtnSmallThumbnails.TabStop = True
        Me.rbtnSmallThumbnails.Text = "Small Thumbnails"
        Me.rbtnSmallThumbnails.UseVisualStyleBackColor = True
        '
        'frmGallery
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(810, 585)
        Me.Controls.Add(Me.rbtnSmallThumbnails)
        Me.Controls.Add(Me.rbtnMediumThumbnails)
        Me.Controls.Add(Me.rbtnLargeThumbnails)
        Me.Controls.Add(Me.pnlBase)
        Me.Controls.Add(Me.pictImageClicked)
        Me.Name = "frmGallery"
        Me.Text = "Gallery"
        CType(Me.pictImageClicked, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBase.ResumeLayout(False)
        Me.pnlSmallThumbnails.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pictImageClicked As System.Windows.Forms.PictureBox
    Friend WithEvents pnlLargeThumbnails As System.Windows.Forms.Panel
    Friend WithEvents pnlBase As System.Windows.Forms.Panel
    Friend WithEvents pnlSmallThumbnails As System.Windows.Forms.Panel
    Friend WithEvents pnlMediumThumbnails As System.Windows.Forms.Panel
    Friend WithEvents rbtnLargeThumbnails As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnMediumThumbnails As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnSmallThumbnails As System.Windows.Forms.RadioButton

End Class
