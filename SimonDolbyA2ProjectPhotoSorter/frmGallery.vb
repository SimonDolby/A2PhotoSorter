Imports System.IO
Public Class frmGallery
    'Assigning variables as global as all routines and methods need to access the value assigned by any calls beforehand.
    'This means that it doesn't conflict with the other values causing unwanted exceptions
    Dim ofd As New OpenFileDialog With {.Filter = "Images|*.jpg;*.bmp;*.png;*.gif;*.wmf"}
    Dim ofc As New FolderBrowserDialog
    Dim pic As PictureBox
    Dim wid As Int32
    Dim i As Integer
    Dim hei As Int32 = 10
    Sub convertPic(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'CONVERT SENDER INTO PICTUREBOX
        pic = CType(sender, PictureBox)
        pictImageClicked.Image = pic.Image
    End Sub

    Private Sub smallthumbnails()

        For Each t In frmMainProgram.lstPhotoList.Items

            pic = New PictureBox
            pic.Image = Image.FromFile(t) 'Sets the size to zoom so can see the full image.
            pic.SizeMode = PictureBoxSizeMode.Zoom 'Sets the size to zoom so can see the full image.
            If i = 3 Then
                hei = hei + 70
                i = 0
                wid = 0
            End If
            pic.SetBounds(wid, hei, 100, 100) 'Sets the thumbnails size
            wid += 105
            AddHandler pic.Click, AddressOf convertPic 'Adds a handler for if the image is clicked. Displays in pictImageClicked.
            pnlSmallThumbnails.Controls.Add(pic) 'Adds the image to the panel.
            i = i + 1

        Next
        hei = 0
        wid = 0

    End Sub

    Private Sub mediumthumbnails()
        For Each t In frmMainProgram.lstPhotoList.Items

            pic = New PictureBox
            pic.Image = Image.FromFile(t) 'Sets the size to zoom so can see the full image.
            pic.SizeMode = PictureBoxSizeMode.Zoom 'Sets the size to zoom so can see the full image.
            If i = 2 Then
                hei = hei + 250
                i = 0
                wid = 0
            End If
            pic.SetBounds(wid, hei, 200, 200) 'Sets the thumbnails size
            wid += 150
            AddHandler pic.Click, AddressOf convertPic  'Adds a handler for if the image is clicked. Displays in pictImageClicked.
            pnlMediumThumbnails.Controls.Add(pic) 'Adds the image to the panel.
            i = i + 1

        Next
        hei = 0
        wid = 0
    End Sub

    Private Sub LargeThumbnails()
        For Each t In frmMainProgram.lstPhotoList.Items

            pic = New PictureBox
            pic.Image = Image.FromFile(t) 'Sets the size to zoom so can see the full image.
            pic.SizeMode = PictureBoxSizeMode.Zoom 'Sets the size to zoom so can see the full image.
            If i = 1 Then
                hei = hei + 300
                i = 0
                wid = 0
            End If
            pic.SetBounds(wid, hei, 300, 300)
            wid += 250
            AddHandler pic.Click, AddressOf convertPic  'Adds a handler for if the image is clicked. Displays in pictImageClicked.
            pnlLargeThumbnails.Controls.Add(pic) 'Adds the image to the panel.
            i = 1

        Next
        hei = 0
        wid = 0
    End Sub





    Private Sub frmGallery_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
  
        smallthumbnails()
        mediumthumbnails()
        LargeThumbnails()
        pnlSmallThumbnails.Visible = True
        pnlLargeThumbnails.Visible = False
        pnlMediumThumbnails.Visible = False
        Control.CheckForIllegalCrossThreadCalls = False
    End Sub

    Private Sub rbtnLThumbnails_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnLargeThumbnails.CheckedChanged
        'Sets the large thumbnails panel to visible and all others invisible.

        pnlSmallThumbnails.Visible = False
        pnlMediumThumbnails.Visible = False
        pnlLargeThumbnails.Visible = True

    End Sub



    Private Sub rbtnMThumbnails_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnMediumThumbnails.CheckedChanged
        'Sets the medium thumbnails panel to visible and all others invisible.
        pnlSmallThumbnails.Visible = False
        pnlMediumThumbnails.Visible = True
        pnlLargeThumbnails.Visible = False
    End Sub

    Private Sub rbtnSThumbnails_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnSmallThumbnails.CheckedChanged
        'Sets the small thumbnails panel to visible and all others invisible.
        pnlSmallThumbnails.Visible = True
        pnlLargeThumbnails.Visible = False
        pnlMediumThumbnails.Visible = False
    End Sub

 
End Class