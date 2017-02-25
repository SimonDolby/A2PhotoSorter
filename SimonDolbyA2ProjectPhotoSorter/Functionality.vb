Module Functionality
    Public Sub SaveFile(ByVal PicBox As Image, ByVal Destination As String, ByVal Path As String)
        'This routine saves the file to the specified destination
        Dim Destinationpath As String
        Dim FileName As String
        Try
            FileName = Path
            Destinationpath = Destination + "\" + FileName
            PicBox.Save(Destinationpath) ' Tries to initially save the picture


            If IO.File.Exists(Destinationpath) Then
                'Checks if the file exists and if so displays a message box on whether the user would like to overwrite the image.
                MsgBox("File already exists, would you like to overwrite it?", vbOKCancel)
                If vbOK = True Then
                    'Deletes the image and then saves the new image to the same location
                    IO.File.Delete(Destinationpath)
                    PicBox.Save(Destinationpath)
                Else
                    MsgBox("Save successful")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly)
        End Try
    End Sub
    

End Module
