Module frmMetaDataSetup

    Public Sub SetUpProgram()
        Dim txtResolution As New TextBox
        Dim txtWidth As New TextBox
        Dim txtHeight As New TextBox
        Dim TxtDateTime As New TextBox
        Dim txtTitle As New TextBox
        Dim txtKeywords As New TextBox
        'Delcaring all the buttons
        Dim BtnMetaData As New Button

        'Delclaring all the textboxes


        'Delcaring all the labels
        Dim lblTitle As New Label
        Dim lblDate As New Label
        Dim lblResolution As New Label
        Dim lblWidth As New Label
        Dim lblHeight As New Label
        Dim lblKeywords As New Label

        With BtnMetaData ' Assiging to buttons
            .Name = "BtnMetaData" 'Assigning the name
            .Text = "Edit Metadata" 'Assigning Text
            .Width = 108 ' Width
            .Height = 23 ' Height

            .Location = New Point(28, 413) ' Location

            AddHandler .Click, AddressOf frmMetaData.btnMetaData_Click ' What happens when the button is clicked.

        End With

        With txtKeywords
            .Name = "txtKeywords"
            .Width = 150
            .Height = 20
            .Location = New Point(158, 155)
            .ReadOnly = True
        End With

        With txtHeight
            .Name = "txtHeight"
            .Width = 100
            .Height = 20
            .Location = New Point(158, 124)
            .ReadOnly = True
        End With

        With TxtDateTime
            .Name = "txtDateTime"
            .Width = 100
            .Height = 20
            .Location = New Point(158, 45)
            .ReadOnly = True
        End With


        With txtTitle
            .Name = "txtTitle"
            .Width = 100
            .Height = 20
            .Location = New Point(158, 19)
            .ReadOnly = True

        End With

        With txtResolution
            .Name = "txtResolution"
            .Width = 100
            .Height = 20
            .Location = New Point(158, 75)
            .ReadOnly = True
        End With

        With txtWidth
            .Width = 100
            .Height = 20
            .Location = New Point(158, 98)
            .Name = "txtWidth"
            .ReadOnly = True

        End With


        'Adding the textboxes to the form


        'Adding the labels to the form
        'For labels





        With lblTitle
            .Name = "lblTitle"
            .Text = "Title"
            .Width = 64
            .Height = 13
            .Location = New Point(46, 22)
        End With

        With lblDate
            .Name = "lblDate"
            .Text = "Date"
            .Width = 64
            .Height = 13
            .Location = New Point(46, 48)
        End With

        With lblResolution
            .Name = "lblResolution"
            .Text = " Resolution"
            .Width = 64
            .Height = 13
            .Location = New Point(19, 78)
        End With

        With lblWidth
            .Name = "lblWidth"
            .Text = "Width"
            .Width = 64
            .Height = 13
            .Location = New Point(38, 98)
        End With

        With lblHeight
            .Name = "lblHeight"
            .Text = "Height"
            .Width = 64
            .Height = 13
            .Location = New Point(38, 124)
        End With
        With lblKeywords
            .Name = "lblKeywords"
            .Text = "Keywords"
            .Width = 64
            .Height = 23
            .Location = New Point(38, 155)
        End With

        'Adding the buttons to the form
        frmMetaData.Controls.Add(txtResolution)
        frmMetaData.Controls.Add(txtWidth)
        frmMetaData.Controls.Add(txtHeight)
        frmMetaData.Controls.Add(TxtDateTime)
        frmMetaData.Controls.Add(txtTitle)
        frmMetaData.Controls.Add(txtKeywords)
        frmMetaData.Controls.Add(lblTitle)
        frmMetaData.Controls.Add(lblDate)
        frmMetaData.Controls.Add(lblResolution)
        frmMetaData.Controls.Add(lblWidth)
        frmMetaData.Controls.Add(lblHeight)
        frmMetaData.Controls.Add(lblKeywords)
        frmMetaData.Controls.Add(BtnMetaData) 'Adds the button to the actual form.
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
        txtResolution.Text = TempVar
        txtHeight.Text = EW.Height
        txtWidth.Text = EW.Width
        Dim Subject = EW.GetProperty(&H9C9F)
        Dim keywords = EW.GetProperty(&H9C9E)
        Dim DecodeK = enc.GetChars(keywords)
        txtKeywords.Text = DecodeK


    End Sub



End Module
