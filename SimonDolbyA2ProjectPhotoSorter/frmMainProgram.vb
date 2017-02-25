
Imports System.IO
Imports System.IO.Path
Imports System.Drawing
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Drawing.Imaging
Imports System.Text
Imports ExifWorks
Imports SimonDolbyA2ProjectPhotoSorter.Convolution_Matrices


Public Class frmMainProgram

    'These are declared as global variables because the entire program needs to have access to them.
    'And they depend on previously called functions to get the true most accurate value
    Dim i As Integer
    Dim UndoSteps As New Stack
    Dim RedoSteps As New Stack
    Dim Images() As Image
  

    Private Sub GetScreenshot(ByVal Control As Control)

        Dim graph As Graphics = Nothing

        Dim frmleft As System.Drawing.Point = Me.Location

        Dim bmp As New Bitmap(Me.Width, Me.Height)

        graph = Graphics.FromImage(bmp)


        graph.CopyFromScreen(Control.PointToScreen(New Point(0, 0)), New Point(0, 0), New Size(Control.Width - 15, Control.Height - 40))

        bmp.Save(i.ToString + ".png")

        Application.DoEvents()
        System.Threading.Thread.Sleep(2000)

        bmp.Dispose()
        graph.Dispose()
        i = i + 1

    End Sub

    Sub SetTags()
        For Each Image As String In My.Computer.FileSystem.GetFiles(GetDirectoryName(txtPath.Text), FileIO.SearchOption.SearchTopLevelOnly, "*.jpg*", "*.gif*", "*.bmp*") ', "*.gif*", "*.jpg*", "*.bmp*", "*.png*")
            Dim index As Integer
            Dim Tags As String
            ''Get SaveLoc from settings
            Dim SaveLoc As String
            SaveLoc = Image

            ''Select photo to edit/view
            Dim Bitmap As String
            Bitmap = SaveLoc

            ''Use ExifWorks library
            Dim Ex As New ExifWorks.ExifWorks(Bitmap)

            ''Set Encoding to Unicode
            Dim enc As New System.Text.UnicodeEncoding



            ''Set Encoding to Unicode
            Dim enc2 As Encoding = Encoding.Unicode
            Dim n As Integer
            Do While n < lstChosenTag.Items.Count
                Tags = Tags + lstChosenTag.Items.Item(n) + ";"


                n = n + 1

            Loop

            ''Tags to Add


            ''Encode to Unicode and switch to Bytes
            Dim Data() As Byte = enc2.GetBytes(Tags & vbNullChar)

            ''Append the Keywords field with the new tags
            Ex.SetProperty(&H9C9E, Data, ExifWorks.ExifWorks.ExifDataTypes.UnsignedByte)


            ''Save the changes
            Ex.GetBitmap.Save(txtDestination.Text + "\tagged\" + IO.Path.GetFileName(SaveLoc))


        Next
    End Sub
    Sub convertPic(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'CONVERT SENDER INTO PICTUREBOX
        Dim pic As PictureBox
        pic = CType(sender, PictureBox)
        pictPhoto.Image = pic.Image
    End Sub



    Public Sub ConvertImage(ByVal Filename As String,ByVal DesiredFormat As System.Drawing.Imaging.ImageFormat,ByVal NewFilename As String)
        ' Takes a filename and saves the file in a new format
        Try
            Dim imgFile As System.Drawing.Image =
      System.Drawing.Image.FromFile(Filename)
            imgFile.Save(NewFilename, DesiredFormat)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    '

    Private Sub GetCount()
        'This sub routine controls the redo and undo buttons.

        Select Case RedoSteps.Count

            Case Is = 0
                ' If there are no images in the RedoSteps stack then sets all the buttons to being unseen by the user.
                btnReset.Visible = False
                btnRedo.Visible = False
                btnUndo.Visible = False

            Case Is > 0
                ' If there are more than 0 images in the redosteps stack, the routine allows the user to see the reset button and redo button.
                btnReset.Visible = True
                btnRedo.Visible = True

            Case Is > 1
                'If there are more than 1 image in the stack, then allows the routine to see the undo button.
                btnUndo.Visible = True

        End Select

        Select Case UndoSteps.Count
            Case Is = 0
                ' If there are no images in the undoSteps stack then sets all the buttons to being unseen by the user.
                btnReset.Visible = False
                btnRedo.Visible = True
                btnUndo.Visible = False

            Case Is > 0
                ' If there are more than 0 images in the undosteps stack, the routine allows the user to see the reset button and undo button.
                btnUndo.Visible = True
                btnReset.Visible = True
            Case Is > 1
                'If there are more than 1 image in the stack, then allows the routine to see the redo button.
                btnRedo.Visible = True
        End Select



    End Sub


    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
		
        pictPhoto.ImageLocation = txtPath.Text 'Reloads the photo 

        'Clear the stacks
        UndoSteps.Clear()
        RedoSteps.Clear()

        'Make the buttons invisible to prevent exceptions from being shown
        btnUndo.Visible = False
        btnRedo.Visible = False

    End Sub

    Private Sub BtnSaturation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaturation.Click

        UndoSteps.Push(pictPhoto.Image)

        pictPhoto.Image = Saturation(pictPhoto.Image, txtValue.Text)
        GetCount()
    End Sub

    Private Sub frmMainProgram_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        'This routine checks whether a key has been pressed. If so, checks which one and performs a certain operation.
        Select Case e.KeyCode
            Case Keys.Q
          
                GetScreenshot(Me)
            Case Keys.K
                btnKeep_Click(sender, e) ' By calling the buton handler, it means I don't have to write the code twice every time I want to do a certain operation
                'It also means I only have to modify one piece of code as opposed to multiple
                MsgBox("You clicked the keep button and the file got copied to the destination directory.")
            Case Keys.Right
                btnNext_Click(sender, e)
            Case Keys.Left
                btnPrevious_Click(sender, e)
            Case Keys.D1
                BtnSaturation_Click(sender, e)
            Case Keys.D2
                btnBandW_Click(sender, e)
            Case Keys.D3
                btnSepia_Click(sender, e)
            Case Keys.D4
                btnGrey_Click(sender, e)
            Case Keys.D5
                btnInvert_Click(sender, e)
            Case Keys.D6
                btnRGBTOBGR_Click(sender, e)
            Case Keys.D7
                btnPolaroid_Click(sender, e)
            Case Keys.D8
                btnSharpen_Click(sender, e)
            Case Keys.D9

                btnContrast_Click(sender, e)
            Case Keys.S
                btnSaveChanges_Click(sender, e)
            Case Keys.R
                btnReset_Click(sender, e)
        End Select

        Select Case (e.Control And e.KeyCode)

            Case Keys.P
                btnPath_Click(sender, e)
            Case Keys.D
                btnDestination_Click(sender, e)
            Case Keys.C
                btnConvertToJpg_Click(sender, e)
            Case Keys.B
                btnBulkAdd_Click(sender, e)
            Case Keys.A
                btnAutoSort_Click(sender, e)

        End Select
    End Sub



    Private Sub frmMainProgram_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Setting all the default settings
        btnGallery.Visible = True
        Dim value As Double = tbarSettings.Value / 10

        btnReset.Visible = True
        btnUndo.Visible = True
        btnRedo.Visible = True


    End Sub


    Private Sub tbarSettings_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbarSettings.Scroll
        Dim value As Double = tbarSettings.Value / 50 'Assigns the amount to modify the contrast or saturation of an image by
        txtValue.Text = value

    End Sub

    Private Sub btnContrast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContrast.Click

        UndoSteps.Push(pictPhoto.Image) ' Pushes the current image to the undosteps stack. This happens before the image is modified

        pictPhoto.Image = Contrast(pictPhoto.Image, txtValue.Text)  'Parses by value an image to the GetContrast Function in the Module ColorMatrices.vb

        GetCount() 'Calls the get count method 
    End Sub

    Private Sub btnSepia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSepia.Click
        UndoSteps.Push(pictPhoto.Image) ' Pushes the current image to the undosteps stack. This happens before the image is modified
        pictPhoto.Image = Sepia(pictPhoto.Image) 'Parses by value an image to the GetSepia Function in the Module ColorMatrices.vb
        GetCount()
    End Sub

    Private Sub btnGrey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrey.Click
        UndoSteps.Push(pictPhoto.Image) ' Pushes the current image to the undosteps stack. This happens before the image is modified
        pictPhoto.Image = Grayscale(pictPhoto.Image) 'Parses by value an image to the GetGrey Function in the Module ColorMatrices.vb
        GetCount()
    End Sub

    Private Sub btnBandW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBandW.Click
        UndoSteps.Push(pictPhoto.Image) ' Pushes the current image to the undosteps stack. This happens before the image is modified
        pictPhoto.Image = BlackAndWhite(pictPhoto.Image) 'Parses by value an image to the GetBlackAndWhite Function in the Module ColorMatrices.vb
        GetCount()
    End Sub

    Private Sub btnInvert_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInvert.Click
        UndoSteps.Push(pictPhoto.Image) ' Pushes the current image to the undosteps stack. This happens before the image is modified
        pictPhoto.Image = InvertColors(pictPhoto.Image)
        GetCount()
    End Sub

    Private Sub btnRGBTOBGR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRGBTOBGR.Click
        UndoSteps.Push(pictPhoto.Image) ' Pushes the current image to the undosteps stack. This happens before the image is modified
        pictPhoto.Image = RGBTOBGR(pictPhoto.Image)
        GetCount()
    End Sub

    Private Sub btnPolaroid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPolaroid.Click
        UndoSteps.Push(pictPhoto.Image) ' Pushes the current image to the undosteps stack. This happens before the image is modified
        pictPhoto.Image = GetPolaroidColors(pictPhoto.Image)
        GetCount()

    End Sub

    Private Sub btnSharpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSharpen.Click


        UndoSteps.Push(pictPhoto.Image) ' Pushes the current image to the undosteps stack. This happens before the image is modified
        Sharpen(pictPhoto.Image, 15)

        GetCount()


    End Sub


    Private Sub btnPath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPath.Click

        Dim index As Integer = 0
        Dim folderDlg As New FolderBrowserDialog

        folderDlg.ShowNewFolderButton = True

        'Opens up a dialog box enabling the user to select the folder they'd like to list photos from.
        If (folderDlg.ShowDialog() = DialogResult.OK) Then
            txtPath.Text = folderDlg.SelectedPath
            Dim root As Environment.SpecialFolder = folderDlg.RootFolder
        End If

        lstPhotoList.Items.Clear() ' Clears listbox of any items already listed.

        Try

            For Each Image As String In My.Computer.FileSystem.GetFiles(txtPath.Text, FileIO.SearchOption.SearchTopLevelOnly, "*.jpg*", "*.gif*", "*.bmp*") ', "*.gif*", "*.jpg*", "*.bmp*", "*.png*")
                'For each image in the directory chosen by the above dialog box add the image name to the listbox
                Me.lstPhotoList.Items.Add(Image)
                index += 1 ' Increment index
            Next

            Me.pictPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom ' Lets picturebox size mode so the image will fit.

            If index > 0 Then 'Checks if the index is greater than 0.

                lstPhotoList.SelectedIndex = 0

            Else ' If it isn't then puts "folder is empty" in the listbox.

                Me.lstPhotoList.Items.Add("folder is empty")

            End If

            Me.pictPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom

            Try
                'Sets the image to the photolist selected item
                pictPhoto.ImageLocation = lstPhotoList.SelectedItem



            Catch ex As Exception
                'If that doesn't work, displays a msgbox saying preview not available.
                MsgBox("preview not available", MsgBoxStyle.OkOnly)

            End Try

            pictPhoto.Tag = pictPhoto.Image

            btnGallery.Visible = True


        Catch ex As Exception


        End Try



    End Sub

    Private Sub lstPhotoList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstPhotoList.SelectedIndexChanged

        pictPhoto.ImageLocation = lstPhotoList.SelectedItem 'PictPhoto.Image location now equals 
        txtPath.Text = pictPhoto.ImageLocation 'Assigns txtPath to the image location in pictPhoto.
        UndoSteps.Clear() 'Clears the UndoSteps stack
        RedoSteps.Clear() 'Clears the RedoSteps stack
    End Sub

    Private Sub btnMetaData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMetaData.Click
        'Checks the if textdestination is empty
        If txtDestination.Text = "" Then
            MsgBox("Please enter a destination for the photo", vbOKOnly)

        Else
            'Displays the form that reads and displays the metadata.
            frmMetaData.Show()
        End If

    End Sub

    Private Sub btnKeep_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKeep.Click
        If txtDestination.Text = "" Then ' Checks if the destination textbox is empty if so displays the below messagebox. 
            MsgBox("Please enter a destination folder", MsgBoxStyle.OkOnly)
        End If
         
        Try
            My.Computer.FileSystem.CopyFile(txtPath.Text, IO.Path.Combine(txtDestination.Text, IO.Path.GetFileName(txtPath.Text))) ' Copies the file to the dstination textbox.


        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly)
        End Try


        lstDestination.Items.Add(pictPhoto.ImageLocation)
        lstDestination.Refresh()

        'Once all the processes within this routine are finished, clear both stacks.
        UndoSteps.Clear()
        RedoSteps.Clear()
    End Sub

    Private Sub btnDestination_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDestination.Click
        'Opens dialog box and allows the user to choose the destination for the image
        Dim folderDlg As New FolderBrowserDialog
        folderDlg.ShowNewFolderButton = True

        If (folderDlg.ShowDialog() = DialogResult.OK) Then

            txtDestination.Text = folderDlg.SelectedPath

            Dim root As Environment.SpecialFolder = folderDlg.RootFolder

        End If
        Try
            'Creates the directory "\tagged" 
            Directory.CreateDirectory(txtDestination.Text + "\Tagged")

        Catch ex As Exception

            MsgBox(ex.Message, MsgBoxStyle.OkOnly)

        End Try
    End Sub

    Private Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveLocation.Click
        'This saves the location of where the user is currently if they need to pause
        Dim PhotoLoc As String
        PhotoLoc = pictPhoto.ImageLocation.ToString 'Gets the photo location


        Dim path As String = "savedlocation.txt" 'The textfile where the imagelocation is stored/

        ' Create or overwrite the file.
        Dim fs As FileStream = File.Create(path)

        ' Add text to the file.
        Dim info As Byte() = New UTF8Encoding(True).GetBytes(pictPhoto.ImageLocation)
        fs.Write(info, 0, info.Length)
        fs.Close() 'Close the files

        'Clear the stacks
        UndoSteps.Clear()
        RedoSteps.Clear()
    End Sub

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        'This routine loads the file location.
        Dim fileReader As String
        Dim index As Integer = 0


        fileReader = My.Computer.FileSystem.ReadAllText("savedlocation.txt") 'Reads the text of the text  and gets the location.

        pictPhoto.ImageLocation = fileReader ' Assigns the photo to the pictPhoto location

        For Each Image As String In My.Computer.FileSystem.GetFiles(Path.GetDirectoryName(fileReader), FileIO.SearchOption.SearchTopLevelOnly, "*.jpg*", "*.gif*", "*.bmp*") ', "*.gif*", "*.jpg*", "*.bmp*", "*.png*")
            'Loads the photos into the listbox

            Me.lstPhotoList.Items.Add(Image)
            index += 1
        Next
        lstPhotoList.SelectedItem = pictPhoto.ImageLocation

    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        'Moves to the next photo in the list. Also checks if btnDelete is checked, if so deletes the phoro after it has moved.
        Dim TempPhoto As String

        If btnDelete.Checked = True Then

            TempPhoto = pictPhoto.ImageLocation

            Me.pictPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom

            If lstPhotoList.SelectedIndex > 0 Or lstPhotoList.SelectedIndex = 0 Then

                Try
                    'Increments the selected index.
                    lstPhotoList.SelectedIndex += 1 '
                    'Loads the image from the selected indeces item
                    pictPhoto.Load(lstPhotoList.SelectedItem)
                    'Sets the photos directory to the photos location
                    txtPath.Text = IO.Path.Combine(txtPath.Text, lstPhotoList.SelectedItem)

                Catch ex As Exception

                    MsgBox("file cannot be diplayed", MsgBoxStyle.OkOnly)
                End Try


                'DeleteFile(TempPhoto, txtDestination.Text)

                lstPhotoList.Refresh()
            End If


        ElseIf btnDelete.Checked = False Then

            Me.pictPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom

            If lstPhotoList.SelectedIndex > 0 Or lstPhotoList.SelectedIndex = 0 Then

                Try

                    lstPhotoList.SelectedIndex += 1

                    pictPhoto.Load(lstPhotoList.SelectedItem)

                    txtPath.Text = IO.Path.Combine(txtPath.Text, lstPhotoList.SelectedItem)

                Catch ex As Exception

                    MsgBox("file cannot be diplayed", MsgBoxStyle.OkOnly)

                End Try

            End If

        End If

        'Clears the stacks
        UndoSteps.Clear()
        RedoSteps.Clear()
    End Sub

    Private Sub btnPrevious_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevious.Click
        'Goes to the last image.
        Me.pictPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        If lstPhotoList.SelectedIndex > 0 Then

            Try
                lstPhotoList.SelectedIndex -= 1
                pictPhoto.Load(lstPhotoList.SelectedItem)

                txtPath.Text = IO.Path.Combine(txtPath.Text, lstPhotoList.SelectedItem)

            Catch ex As Exception

                MsgBox("file cannot be diplayed", MsgBoxStyle.OkOnly)

            End Try

        Else
            'Checks if there are no images before and if there aren't, outputs a message box 
            MsgBox("this is the first image", MsgBoxStyle.OkOnly)

        End If
        ' Clears the stacks
        UndoSteps.Clear()
        RedoSteps.Clear()
    End Sub

    Private Sub btnAutoSort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutoSort.Click

        Dim Text1 As String
        Dim Text2 As String
        Dim imageloc As String
        Dim Index As Integer
        Dim first10Chars As String

        Try

            For Each Image As String In My.Computer.FileSystem.GetFiles(Path.GetDirectoryName(txtPath.Text), FileIO.SearchOption.SearchTopLevelOnly, "*.jpg*", "*.gif*", "*.bmp*") ', "*.gif*", "*.jpg*", "*.bmp*", "*.png*")


                lstPhotoList.SelectedIndex = Index ' Assigns the selected index to the value of index
                lstPhotoList.SelectedItem = lstPhotoList.SelectedIndex 'The selected item is assigned to the selected index. So the Selected item matches the value of index.
                pictPhoto.Load(lstPhotoList.SelectedItem)
                imageloc = pictPhoto.ImageLocation
                Dim EW As New ExifWorks.ExifWorks(pictPhoto.Image)
                Text1 = EW.DateTimeOriginal

                first10Chars = Text1.Substring(0, 10)


                first10Chars = first10Chars.Split(" "c)(0) 'Checks for a space at the end and if there is one, removes it and everything after it.
                first10Chars = first10Chars.Replace("\", ".")
                first10Chars = first10Chars.Replace("/", ".")

                Index += 1
                Text2 = txtDestination.Text + "\" + first10Chars + "\"


                Try

                    Directory.CreateDirectory(Text2)
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.OkOnly)
                End Try

                Try



                    Dim file = New FileInfo(pictPhoto.ImageLocation.ToString)
                    file.CopyTo(Text2 & "\" & file.Name)
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.OkOnly)
                End Try

            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly)

        End Try

    End Sub

    Private Sub pictPhoto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pictPhoto.Click

    End Sub

    Private Sub btnSaveChanges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveChange.Click
        UndoSteps.Clear()
        RedoSteps.Clear()

        SaveFile(pictPhoto.Image, txtDestination.Text, IO.Path.GetFileName(pictPhoto.ImageLocation))

    End Sub
    Private Sub btnAdTags_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lstChosenTag.Items.Add(txtTags.Text)

    End Sub

    Private Sub btnRemoveTag_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveTag.Click
        lstChosenTag.Items.Remove(lstChosenTag.SelectedItem)
    End Sub

    'Calls The Process to add a select number of tags to all images in a directory
    Private Sub btnBulkAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBulkAdd.Click
        Dim process1 As Thread
        process1 = New System.Threading.Thread(AddressOf SetTags)
        process1.Start()

    End Sub

    'This routine converts an images format to JPg to enable to add/alter the metadata of the image.s
    Private Sub btnConvertToJpg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConvertToJpg.Click
        For Each Image As String In My.Computer.FileSystem.GetFiles(GetDirectoryName(txtPath.Text), FileIO.SearchOption.SearchTopLevelOnly, "*.png*", "*.gif*", "*.bmp*") ', "*.gif*", "*.jpg*", "*.bmp*", "*.png*")
            ConvertImage(Image, System.Drawing.Imaging.ImageFormat.Bmp, GetFileNameWithoutExtension(Image) + ".jpg")
            Dim extension As String = Path.GetExtension(Image)
            Dim bm As Bitmap
            Select Case (extension.ToLower())


                Case ".png", ".gif ", ".jpeg", ".jpg"
                    bm.Save(Image, ImageFormat.Jpeg)

                Case Else
                    Throw New NotSupportedException( _
                        "Unknown file extension " & extension)
            End Select

        Next
    End Sub


    Private Sub btnContrast_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnContrast.MouseHover
     
    End Sub
    Private Sub btnSepia_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSepia.MouseHover
        lblInformation.Text = "Sepia"
    End Sub
    Private Sub BtnSaturation_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSaturation.MouseHover
        lblInformation.Text = "Saturation"
    End Sub
    Private Sub btnBandW_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBandW.MouseHover
        lblInformation.Text = "Black and White"
    End Sub
    Private Sub btnGrey_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrey.MouseHover
        lblInformation.Text = "Greyscale"
    End Sub
    Private Sub btnInvert_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInvert.MouseHover
        lblInformation.Text = "Invert Colors"
    End Sub
    Private Sub btnNext_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.MouseHover
        lblInformation.Text = "Next Image"
    End Sub
    Private Sub btnPrevious_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrevious.MouseHover
        lblInformation.Text = "Previous Image"
    End Sub
    Private Sub btnPolaroid_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPolaroid.MouseHover
        lblInformation.Text = "Polaroid Colors"
    End Sub
    Private Sub btnSharpen_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSharpen.MouseHover
        lblInformation.Text = "Sharpen"
    End Sub
    Private Sub btnRGBTOBGR_MouseHover(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRGBTOBGR.MouseHover
        lblInformation.Text = "RGB to BGR colors"
    End Sub

    Private Sub BtnUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUndo.Click
        RedoSteps.Push(pictPhoto.Image) ' Pushes(Adds) the current image to RedoSteps stack
        pictPhoto.Image = UndoSteps.Peek() ' Sets the image as the last value of the undosteps stack.
        UndoSteps.Pop() 'Pops(Removes) the item from the stack.
        GetCount()
    End Sub

    Private Sub btnRedo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRedo.Click
        UndoSteps.Push(pictPhoto.Image) 'Pushes the current image to the undo stack.
        pictPhoto.Image = RedoSteps.Peek ' Sets the current image to the top image of the stack
        RedoSteps.Pop() ' Pops the the top item form the top of the stack.
        GetCount() ' Activates the getCount routine to check if the undo or redo button needs to be set to be un seen
    End Sub

    Private Sub pictPhoto_ClientSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles pictPhoto.ClientSizeChanged

    End Sub

    Private Sub btnGallery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGallery.Click
        frmGallery.Show()
    End Sub

    Private Sub btnAddTags_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddTags.Click
        lstChosenTag.Items.Add(txtTags.Text)
    End Sub
    
    
    Private Sub ttHoverOver_Popup(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PopupEventArgs) Handles ttHoverOver.Popup
       
    End Sub


    Private Sub btnDelete_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.CheckedChanged

    End Sub
End Class
