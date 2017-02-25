<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMainProgram
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMainProgram))
        Me.pictPhoto = New System.Windows.Forms.PictureBox()
        Me.lblPath = New System.Windows.Forms.Label()
        Me.lblDestination = New System.Windows.Forms.Label()
        Me.txtPath = New System.Windows.Forms.TextBox()
        Me.txtDestination = New System.Windows.Forms.TextBox()
        Me.BtnSaturation = New System.Windows.Forms.Button()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.txtValue = New System.Windows.Forms.TextBox()
        Me.tbarSettings = New System.Windows.Forms.TrackBar()
        Me.btnContrast = New System.Windows.Forms.Button()
        Me.btnBandW = New System.Windows.Forms.Button()
        Me.btnGrey = New System.Windows.Forms.Button()
        Me.btnInvert = New System.Windows.Forms.Button()
        Me.btnRGBTOBGR = New System.Windows.Forms.Button()
        Me.btnPolaroid = New System.Windows.Forms.Button()
        Me.btnPath = New System.Windows.Forms.Button()
        Me.btnDestination = New System.Windows.Forms.Button()
        Me.btnMetaData = New System.Windows.Forms.Button()
        Me.btnKeep = New System.Windows.Forms.Button()
        Me.btnSaveLocation = New System.Windows.Forms.Button()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnPrevious = New System.Windows.Forms.Button()
        Me.btnAutoSort = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnConvertToJpg = New System.Windows.Forms.Button()
        Me.btnBulkAdd = New System.Windows.Forms.Button()
        Me.lblTags = New System.Windows.Forms.Label()
        Me.ttHoverOver = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnSepia = New System.Windows.Forms.Button()
        Me.btnSharpen = New System.Windows.Forms.Button()
        Me.lblInformation = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.btnUndo = New System.Windows.Forms.Button()
        Me.btnRedo = New System.Windows.Forms.Button()
        Me.mnuNavigation = New System.Windows.Forms.MenuStrip()
        Me.btnGallery = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnSaveChange = New System.Windows.Forms.ToolStripMenuItem()
        Me.lstPhotoList = New System.Windows.Forms.ListBox()
        Me.btnRemoveTag = New System.Windows.Forms.Button()
        Me.lstChosenTag = New System.Windows.Forms.ListBox()
        Me.txtTags = New System.Windows.Forms.TextBox()
        Me.btnAddTags = New System.Windows.Forms.Button()
        Me.lstDestination = New System.Windows.Forms.ListBox()
        Me.btnDelete = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.pictPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbarSettings, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.mnuNavigation.SuspendLayout()
        Me.SuspendLayout()
        '
        'pictPhoto
        '
        Me.pictPhoto.BackColor = System.Drawing.Color.White
        Me.pictPhoto.Location = New System.Drawing.Point(671, 27)
        Me.pictPhoto.Name = "pictPhoto"
        Me.pictPhoto.Size = New System.Drawing.Size(534, 456)
        Me.pictPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pictPhoto.TabIndex = 1
        Me.pictPhoto.TabStop = False
        '
        'lblPath
        '
        Me.lblPath.AutoSize = True
        Me.lblPath.Location = New System.Drawing.Point(18, 500)
        Me.lblPath.Name = "lblPath"
        Me.lblPath.Size = New System.Drawing.Size(32, 13)
        Me.lblPath.TabIndex = 2
        Me.lblPath.Text = "Path:"
        '
        'lblDestination
        '
        Me.lblDestination.AutoSize = True
        Me.lblDestination.Location = New System.Drawing.Point(12, 526)
        Me.lblDestination.Name = "lblDestination"
        Me.lblDestination.Size = New System.Drawing.Size(63, 13)
        Me.lblDestination.TabIndex = 3
        Me.lblDestination.Text = "Destination:"
        '
        'txtPath
        '
        Me.txtPath.Location = New System.Drawing.Point(72, 496)
        Me.txtPath.Name = "txtPath"
        Me.txtPath.ReadOnly = True
        Me.txtPath.Size = New System.Drawing.Size(290, 20)
        Me.txtPath.TabIndex = 4
        '
        'txtDestination
        '
        Me.txtDestination.Location = New System.Drawing.Point(72, 522)
        Me.txtDestination.Name = "txtDestination"
        Me.txtDestination.ReadOnly = True
        Me.txtDestination.Size = New System.Drawing.Size(290, 20)
        Me.txtDestination.TabIndex = 5
        '
        'BtnSaturation
        '
        Me.BtnSaturation.Location = New System.Drawing.Point(184, 57)
        Me.BtnSaturation.Name = "BtnSaturation"
        Me.BtnSaturation.Size = New System.Drawing.Size(103, 24)
        Me.BtnSaturation.TabIndex = 7
        Me.BtnSaturation.Text = "Saturation"
        Me.BtnSaturation.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(184, 27)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(103, 24)
        Me.btnReset.TabIndex = 14
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'txtValue
        '
        Me.txtValue.Location = New System.Drawing.Point(758, 493)
        Me.txtValue.Name = "txtValue"
        Me.txtValue.ReadOnly = True
        Me.txtValue.Size = New System.Drawing.Size(28, 20)
        Me.txtValue.TabIndex = 32
        Me.txtValue.Text = "1"
        '
        'tbarSettings
        '
        Me.tbarSettings.BackColor = System.Drawing.Color.LightSkyBlue
        Me.tbarSettings.LargeChange = 1
        Me.tbarSettings.Location = New System.Drawing.Point(475, 488)
        Me.tbarSettings.Maximum = 100
        Me.tbarSettings.Name = "tbarSettings"
        Me.tbarSettings.Size = New System.Drawing.Size(277, 45)
        Me.tbarSettings.TabIndex = 31
        Me.tbarSettings.Value = 50
        '
        'btnContrast
        '
        Me.btnContrast.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnContrast.FlatAppearance.BorderSize = 0
        Me.btnContrast.Location = New System.Drawing.Point(184, 86)
        Me.btnContrast.Name = "btnContrast"
        Me.btnContrast.Size = New System.Drawing.Size(103, 24)
        Me.btnContrast.TabIndex = 33
        Me.btnContrast.Text = "Contrast"
        Me.ttHoverOver.SetToolTip(Me.btnContrast, "Contrast")
        Me.btnContrast.UseVisualStyleBackColor = True
        '
        'btnBandW
        '
        Me.btnBandW.Location = New System.Drawing.Point(72, 87)
        Me.btnBandW.Name = "btnBandW"
        Me.btnBandW.Size = New System.Drawing.Size(99, 23)
        Me.btnBandW.TabIndex = 34
        Me.btnBandW.Text = "Black and White"
        Me.btnBandW.UseVisualStyleBackColor = True
        '
        'btnGrey
        '
        Me.btnGrey.Location = New System.Drawing.Point(184, 145)
        Me.btnGrey.Name = "btnGrey"
        Me.btnGrey.Size = New System.Drawing.Size(103, 24)
        Me.btnGrey.TabIndex = 36
        Me.btnGrey.Text = "Greyscale"
        Me.ttHoverOver.SetToolTip(Me.btnGrey, "Greyscale")
        Me.btnGrey.UseVisualStyleBackColor = True
        '
        'btnInvert
        '
        Me.btnInvert.BackColor = System.Drawing.Color.Transparent
        Me.btnInvert.ForeColor = System.Drawing.Color.Black
        Me.btnInvert.Location = New System.Drawing.Point(184, 174)
        Me.btnInvert.Name = "btnInvert"
        Me.btnInvert.Size = New System.Drawing.Size(103, 24)
        Me.btnInvert.TabIndex = 37
        Me.btnInvert.Text = "Invert"
        Me.ttHoverOver.SetToolTip(Me.btnInvert, "Invert")
        Me.btnInvert.UseVisualStyleBackColor = False
        '
        'btnRGBTOBGR
        '
        Me.btnRGBTOBGR.Location = New System.Drawing.Point(184, 204)
        Me.btnRGBTOBGR.Name = "btnRGBTOBGR"
        Me.btnRGBTOBGR.Size = New System.Drawing.Size(103, 24)
        Me.btnRGBTOBGR.TabIndex = 38
        Me.btnRGBTOBGR.Text = " RGB to BGR"
        Me.ttHoverOver.SetToolTip(Me.btnRGBTOBGR, "RGB to BGR")
        Me.btnRGBTOBGR.UseVisualStyleBackColor = True
        '
        'btnPolaroid
        '
        Me.btnPolaroid.Location = New System.Drawing.Point(183, 234)
        Me.btnPolaroid.Name = "btnPolaroid"
        Me.btnPolaroid.Size = New System.Drawing.Size(103, 24)
        Me.btnPolaroid.TabIndex = 39
        Me.btnPolaroid.Text = "Polaroid Colors"
        Me.ttHoverOver.SetToolTip(Me.btnPolaroid, "Polaroid Colors")
        Me.btnPolaroid.UseVisualStyleBackColor = True
        '
        'btnPath
        '
        Me.btnPath.Location = New System.Drawing.Point(368, 496)
        Me.btnPath.Name = "btnPath"
        Me.btnPath.Size = New System.Drawing.Size(49, 20)
        Me.btnPath.TabIndex = 41
        Me.btnPath.Text = "Path"
        Me.btnPath.UseVisualStyleBackColor = True
        '
        'btnDestination
        '
        Me.btnDestination.Location = New System.Drawing.Point(368, 520)
        Me.btnDestination.Name = "btnDestination"
        Me.btnDestination.Size = New System.Drawing.Size(75, 23)
        Me.btnDestination.TabIndex = 42
        Me.btnDestination.Text = "Destination"
        Me.btnDestination.UseVisualStyleBackColor = True
        '
        'btnMetaData
        '
        Me.btnMetaData.AutoSize = True
        Me.btnMetaData.Location = New System.Drawing.Point(15, 19)
        Me.btnMetaData.Name = "btnMetaData"
        Me.btnMetaData.Size = New System.Drawing.Size(89, 23)
        Me.btnMetaData.TabIndex = 43
        Me.btnMetaData.Text = "Get Metadata"
        Me.btnMetaData.UseVisualStyleBackColor = True
        '
        'btnKeep
        '
        Me.btnKeep.Location = New System.Drawing.Point(184, 364)
        Me.btnKeep.Name = "btnKeep"
        Me.btnKeep.Size = New System.Drawing.Size(75, 23)
        Me.btnKeep.TabIndex = 45
        Me.btnKeep.Text = "Keep"
        Me.btnKeep.UseVisualStyleBackColor = True
        '
        'btnSaveLocation
        '
        Me.btnSaveLocation.Location = New System.Drawing.Point(180, 293)
        Me.btnSaveLocation.Name = "btnSaveLocation"
        Me.btnSaveLocation.Size = New System.Drawing.Size(105, 23)
        Me.btnSaveLocation.TabIndex = 46
        Me.btnSaveLocation.Text = "Save Location"
        Me.btnSaveLocation.UseVisualStyleBackColor = True
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(180, 322)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(105, 23)
        Me.btnLoad.TabIndex = 47
        Me.btnLoad.Text = "Load Location"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'btnNext
        '
        Me.btnNext.BackColor = System.Drawing.Color.LightSkyBlue
        Me.btnNext.BackgroundImage = CType(resources.GetObject("btnNext.BackgroundImage"), System.Drawing.Image)
        Me.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNext.FlatAppearance.BorderSize = 0
        Me.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNext.Location = New System.Drawing.Point(854, 489)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(45, 39)
        Me.btnNext.TabIndex = 48
        Me.btnNext.Text = "" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Next"
        Me.btnNext.UseVisualStyleBackColor = False
        '
        'btnPrevious
        '
        Me.btnPrevious.BackgroundImage = CType(resources.GetObject("btnPrevious.BackgroundImage"), System.Drawing.Image)
        Me.btnPrevious.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPrevious.FlatAppearance.BorderSize = 0
        Me.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrevious.Location = New System.Drawing.Point(812, 489)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(45, 39)
        Me.btnPrevious.TabIndex = 49
        Me.btnPrevious.UseVisualStyleBackColor = True
        '
        'btnAutoSort
        '
        Me.btnAutoSort.Location = New System.Drawing.Point(119, 19)
        Me.btnAutoSort.Name = "btnAutoSort"
        Me.btnAutoSort.Size = New System.Drawing.Size(104, 23)
        Me.btnAutoSort.TabIndex = 50
        Me.btnAutoSort.Text = "Auto Sort by Date"
        Me.btnAutoSort.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.btnConvertToJpg)
        Me.GroupBox1.Controls.Add(Me.btnBulkAdd)
        Me.GroupBox1.Controls.Add(Me.btnAutoSort)
        Me.GroupBox1.Controls.Add(Me.btnMetaData)
        Me.GroupBox1.Location = New System.Drawing.Point(504, 539)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(295, 117)
        Me.GroupBox1.TabIndex = 55
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Automated Functions"
        '
        'btnConvertToJpg
        '
        Me.btnConvertToJpg.Location = New System.Drawing.Point(15, 46)
        Me.btnConvertToJpg.Name = "btnConvertToJpg"
        Me.btnConvertToJpg.Size = New System.Drawing.Size(89, 23)
        Me.btnConvertToJpg.TabIndex = 61
        Me.btnConvertToJpg.Text = "Convert to JPG"
        Me.btnConvertToJpg.UseVisualStyleBackColor = True
        '
        'btnBulkAdd
        '
        Me.btnBulkAdd.Location = New System.Drawing.Point(120, 46)
        Me.btnBulkAdd.Name = "btnBulkAdd"
        Me.btnBulkAdd.Size = New System.Drawing.Size(103, 23)
        Me.btnBulkAdd.TabIndex = 51
        Me.btnBulkAdd.Text = "Bulk add tags"
        Me.btnBulkAdd.UseVisualStyleBackColor = True
        '
        'lblTags
        '
        Me.lblTags.AutoSize = True
        Me.lblTags.Location = New System.Drawing.Point(65, 582)
        Me.lblTags.Name = "lblTags"
        Me.lblTags.Size = New System.Drawing.Size(64, 13)
        Me.lblTags.TabIndex = 59
        Me.lblTags.Text = "Tags to add"
        '
        'ttHoverOver
        '
        Me.ttHoverOver.AutoPopDelay = 5000
        Me.ttHoverOver.InitialDelay = 0
        Me.ttHoverOver.ReshowDelay = 100
        Me.ttHoverOver.ShowAlways = True
        Me.ttHoverOver.ToolTipTitle = " "
        '
        'btnSepia
        '
        Me.btnSepia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSepia.FlatAppearance.BorderSize = 0
        Me.btnSepia.Location = New System.Drawing.Point(184, 116)
        Me.btnSepia.Name = "btnSepia"
        Me.btnSepia.Size = New System.Drawing.Size(103, 24)
        Me.btnSepia.TabIndex = 35
        Me.btnSepia.Text = "Sepia"
        Me.ttHoverOver.SetToolTip(Me.btnSepia, "Sepia")
        Me.btnSepia.UseVisualStyleBackColor = True
        '
        'btnSharpen
        '
        Me.btnSharpen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSharpen.FlatAppearance.BorderSize = 0
        Me.btnSharpen.Location = New System.Drawing.Point(182, 263)
        Me.btnSharpen.Name = "btnSharpen"
        Me.btnSharpen.Size = New System.Drawing.Size(103, 24)
        Me.btnSharpen.TabIndex = 40
        Me.btnSharpen.Text = "Sharpen"
        Me.ttHoverOver.SetToolTip(Me.btnSharpen, "Sharpen")
        Me.btnSharpen.UseVisualStyleBackColor = True
        '
        'lblInformation
        '
        Me.lblInformation.Name = "lblInformation"
        Me.lblInformation.Size = New System.Drawing.Size(75, 17)
        Me.lblInformation.Text = "What is what"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.BackColor = System.Drawing.Color.Transparent
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblInformation})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 664)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1264, 22)
        Me.StatusStrip1.TabIndex = 61
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'btnUndo
        '
        Me.btnUndo.Location = New System.Drawing.Point(72, 27)
        Me.btnUndo.Name = "btnUndo"
        Me.btnUndo.Size = New System.Drawing.Size(99, 24)
        Me.btnUndo.TabIndex = 62
        Me.btnUndo.Text = "Undo"
        Me.btnUndo.UseVisualStyleBackColor = True
        '
        'btnRedo
        '
        Me.btnRedo.Location = New System.Drawing.Point(72, 57)
        Me.btnRedo.Name = "btnRedo"
        Me.btnRedo.Size = New System.Drawing.Size(99, 23)
        Me.btnRedo.TabIndex = 63
        Me.btnRedo.Text = "Redo"
        Me.btnRedo.UseVisualStyleBackColor = True
        '
        'mnuNavigation
        '
        Me.mnuNavigation.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnGallery, Me.btnSaveChange})
        Me.mnuNavigation.Location = New System.Drawing.Point(0, 0)
        Me.mnuNavigation.Name = "mnuNavigation"
        Me.mnuNavigation.Size = New System.Drawing.Size(1264, 24)
        Me.mnuNavigation.TabIndex = 64
        Me.mnuNavigation.Text = "MenuStrip1"
        '
        'btnGallery
        '
        Me.btnGallery.Name = "btnGallery"
        Me.btnGallery.Size = New System.Drawing.Size(55, 20)
        Me.btnGallery.Text = "Gallery"
        '
        'btnSaveChange
        '
        Me.btnSaveChange.Name = "btnSaveChange"
        Me.btnSaveChange.Size = New System.Drawing.Size(92, 20)
        Me.btnSaveChange.Text = "Save Changes"
        '
        'lstPhotoList
        '
        Me.lstPhotoList.FormattingEnabled = True
        Me.lstPhotoList.Location = New System.Drawing.Point(313, 27)
        Me.lstPhotoList.Name = "lstPhotoList"
        Me.lstPhotoList.Size = New System.Drawing.Size(328, 459)
        Me.lstPhotoList.TabIndex = 65
        '
        'btnRemoveTag
        '
        Me.btnRemoveTag.Location = New System.Drawing.Point(259, 577)
        Me.btnRemoveTag.Name = "btnRemoveTag"
        Me.btnRemoveTag.Size = New System.Drawing.Size(85, 23)
        Me.btnRemoveTag.TabIndex = 60
        Me.btnRemoveTag.Text = "Remove Tags"
        Me.btnRemoveTag.UseVisualStyleBackColor = True
        '
        'lstChosenTag
        '
        Me.lstChosenTag.FormattingEnabled = True
        Me.lstChosenTag.Location = New System.Drawing.Point(153, 577)
        Me.lstChosenTag.Name = "lstChosenTag"
        Me.lstChosenTag.Size = New System.Drawing.Size(100, 69)
        Me.lstChosenTag.TabIndex = 68
        '
        'txtTags
        '
        Me.txtTags.Location = New System.Drawing.Point(153, 549)
        Me.txtTags.Name = "txtTags"
        Me.txtTags.Size = New System.Drawing.Size(100, 20)
        Me.txtTags.TabIndex = 69
        '
        'btnAddTags
        '
        Me.btnAddTags.Location = New System.Drawing.Point(259, 548)
        Me.btnAddTags.Name = "btnAddTags"
        Me.btnAddTags.Size = New System.Drawing.Size(75, 23)
        Me.btnAddTags.TabIndex = 70
        Me.btnAddTags.Text = "Add Tags"
        Me.btnAddTags.UseVisualStyleBackColor = True
        '
        'lstDestination
        '
        Me.lstDestination.FormattingEnabled = True
        Me.lstDestination.Location = New System.Drawing.Point(919, 510)
        Me.lstDestination.Name = "lstDestination"
        Me.lstDestination.Size = New System.Drawing.Size(286, 173)
        Me.lstDestination.TabIndex = 71
        '
        'btnDelete
        '
        Me.btnDelete.AutoSize = True
        Me.btnDelete.Location = New System.Drawing.Point(21, 473)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(86, 17)
        Me.btnDelete.TabIndex = 53
        Me.btnDelete.TabStop = True
        Me.btnDelete.Text = "Delete photo"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(65, 552)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 72
        Me.Label1.Text = "Enter tags here:"
        '
        'frmMainProgram
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSkyBlue
        Me.ClientSize = New System.Drawing.Size(1264, 686)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lstDestination)
        Me.Controls.Add(Me.btnAddTags)
        Me.Controls.Add(Me.txtTags)
        Me.Controls.Add(Me.lstChosenTag)
        Me.Controls.Add(Me.lstPhotoList)
        Me.Controls.Add(Me.btnRedo)
        Me.Controls.Add(Me.btnUndo)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.mnuNavigation)
        Me.Controls.Add(Me.btnRemoveTag)
        Me.Controls.Add(Me.lblTags)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnPrevious)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.btnSaveLocation)
        Me.Controls.Add(Me.btnKeep)
        Me.Controls.Add(Me.btnDestination)
        Me.Controls.Add(Me.btnPath)
        Me.Controls.Add(Me.btnSharpen)
        Me.Controls.Add(Me.btnPolaroid)
        Me.Controls.Add(Me.btnRGBTOBGR)
        Me.Controls.Add(Me.btnInvert)
        Me.Controls.Add(Me.btnGrey)
        Me.Controls.Add(Me.btnSepia)
        Me.Controls.Add(Me.btnBandW)
        Me.Controls.Add(Me.btnContrast)
        Me.Controls.Add(Me.txtValue)
        Me.Controls.Add(Me.tbarSettings)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.BtnSaturation)
        Me.Controls.Add(Me.txtDestination)
        Me.Controls.Add(Me.txtPath)
        Me.Controls.Add(Me.lblDestination)
        Me.Controls.Add(Me.lblPath)
        Me.Controls.Add(Me.pictPhoto)
        Me.ForeColor = System.Drawing.SystemColors.ControlText
        Me.KeyPreview = True
        Me.Name = "frmMainProgram"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Main Program"
        CType(Me.pictPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbarSettings, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.mnuNavigation.ResumeLayout(False)
        Me.mnuNavigation.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pictPhoto As System.Windows.Forms.PictureBox
    Friend WithEvents lblPath As System.Windows.Forms.Label
    Friend WithEvents lblDestination As System.Windows.Forms.Label
    Friend WithEvents txtPath As System.Windows.Forms.TextBox
    Friend WithEvents txtDestination As System.Windows.Forms.TextBox
    Friend WithEvents BtnSaturation As System.Windows.Forms.Button
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents txtValue As System.Windows.Forms.TextBox
    Friend WithEvents tbarSettings As System.Windows.Forms.TrackBar
    Friend WithEvents btnContrast As System.Windows.Forms.Button
    Friend WithEvents btnBandW As System.Windows.Forms.Button
    Friend WithEvents btnGrey As System.Windows.Forms.Button
    Friend WithEvents btnInvert As System.Windows.Forms.Button
    Friend WithEvents btnRGBTOBGR As System.Windows.Forms.Button
    Friend WithEvents btnPolaroid As System.Windows.Forms.Button
    Friend WithEvents btnPath As System.Windows.Forms.Button
    Friend WithEvents btnDestination As System.Windows.Forms.Button
    Friend WithEvents btnMetaData As System.Windows.Forms.Button
    Friend WithEvents btnKeep As System.Windows.Forms.Button
    Friend WithEvents btnSaveLocation As System.Windows.Forms.Button
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnPrevious As System.Windows.Forms.Button
    Friend WithEvents btnAutoSort As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnBulkAdd As System.Windows.Forms.Button
    Friend WithEvents lblTags As System.Windows.Forms.Label
    Friend WithEvents btnConvertToJpg As System.Windows.Forms.Button
    Friend WithEvents ttHoverOver As System.Windows.Forms.ToolTip
    Friend WithEvents btnSepia As System.Windows.Forms.Button
    Friend WithEvents lblInformation As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents btnUndo As System.Windows.Forms.Button
    Friend WithEvents btnRedo As System.Windows.Forms.Button
    Friend WithEvents mnuNavigation As System.Windows.Forms.MenuStrip
    Friend WithEvents btnGallery As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnSharpen As System.Windows.Forms.Button
    Friend WithEvents lstPhotoList As System.Windows.Forms.ListBox
    Friend WithEvents btnRemoveTag As System.Windows.Forms.Button
    Friend WithEvents lstChosenTag As System.Windows.Forms.ListBox
    Friend WithEvents txtTags As System.Windows.Forms.TextBox
    Friend WithEvents btnAddTags As System.Windows.Forms.Button
    Friend WithEvents btnSaveChange As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lstDestination As System.Windows.Forms.ListBox
    Friend WithEvents btnDelete As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
