Imports ExifWorks
Imports System.Text

Public Class frmMetaData




    Private Sub frmMetaData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load


        Dim Decode
        Dim TempVar As String
        Dim SaveLoc As String
        Dim ImageLoc = frmMainProgram.txtPath.Text
        SaveLoc = ImageLoc


        'Select photo to edit/view
        Dim Bitmap As String
        Bitmap = SaveLoc

        'Use EWifWorks library
        Dim EW As New ExifWorks.ExifWorks(Bitmap)

        'Set Encoding to Unicode
        Dim enc As New System.Text.UnicodeEncoding


        'Get data from the selected fields

        If IsNothing(EW.GetProperty(&H9C9B)) Then

        Else
            Dim Title = EW.GetProperty(&H9C9B)
            Decode = enc.GetChars(Title)
            txtTitle.Text = Decode

        End If
        TxtDateTime.Text = EW.DateTimeOriginal

        TempVar = System.IO.Path.Combine((EW.ResolutionX.ToString + "dpi"), (EW.ResolutionY.ToString + "dpi"))
        TempVar = TempVar.Replace("\", "/")
        TxtReso.Text = TempVar
        txtHeight.Text = EW.Height
        txtWidth.Text = EW.Width
        Dim Subject = EW.GetProperty(&H9C9F)

        Dim DecodeK
        If IsNothing(EW.GetProperty(&H9C9E)) Then

        Else
            Dim keywords = EW.GetProperty(&H9C9E)

            DecodeK = enc.GetChars(keywords)
            txtKeywords.Text = DecodeK
        End If
        ' Sets all the textboxes to read only. This prevents unintended editing.
        txtTitle.ReadOnly = True
        TxtDateTime.ReadOnly = True
        txtKeywords.ReadOnly = True
        TxtReso.ReadOnly = True
        txtHeight.ReadOnly = True
        txtWidth.ReadOnly = True


    End Sub

    Public Sub btnMetaData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMetaData.Click

        ' Handle your Button clicks here]
        txtTitle.ReadOnly = False
        txtKeywords.ReadOnly = False
        TxtReso.ReadOnly = False
        txtHeight.ReadOnly = False
        txtWidth.ReadOnly = False



    End Sub

    Private Sub btnSaveChanges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveChanges.Click
        Dim index As Integer
        Dim Tags As String
        Dim TempPhotoLoc As String
        ''Get SaveLoc from settings
        Dim SaveLoc As String
        SaveLoc = frmMainProgram.pictPhoto.ImageLocation

        ''Select photo to edit/view
        Dim Bitmap As String
        Bitmap = frmMainProgram.pictPhoto.ImageLocation

        ''Use ExifWorks library
        Dim Ex As New ExifWorks.ExifWorks(Bitmap)

        ''Set Encoding to Unicode
        Dim enc As New System.Text.UnicodeEncoding



        ''Set Encoding to Unicode
        Dim enc2 As Encoding = Encoding.Unicode
        Dim n As Integer


        ''Tags to Add


        ''Encode to Unicode and switch to Bytes
        Dim Data() As Byte = enc2.GetBytes(txtKeywords.Text & vbNullChar)

        ''Append the Keywords field with the new tags

        Ex.SetProperty(&H9C9E, Data, ExifWorks.ExifWorks.ExifDataTypes.UnsignedByte)
        Ex.SetProperty(&H9C9B, enc2.GetBytes(txtTitle.Text & vbNullChar), ExifWorks.ExifWorks.ExifDataTypes.UnsignedByte)

        TempPhotoLoc = SaveLoc
        frmMainProgram.pictPhoto.ImageLocation = Nothing
        System.IO.File.Delete(SaveLoc)

        ''Save the changes
        Ex.GetBitmap.Save(TempPhotoLoc)
        frmMainProgram.pictPhoto.ImageLocation = TempPhotoLoc

    End Sub

    Private Sub txtKeywords_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKeywords.TextChanged
        txtKeywords.Text = txtKeywords.Text.Replace(" ", ";")
        txtKeywords.SelectionStart = txtKeywords.MaxLength
    End Sub
End Class