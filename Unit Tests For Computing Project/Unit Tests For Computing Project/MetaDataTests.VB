Imports System.Text
Imports System.IO

<TestClass()>
Public Class MetaDataTests

    <TestMethod()>
    Public Sub BulkAddTags()
        For Each Image As String In My.Computer.FileSystem.GetFiles("C:\Users\Simon\Documents\Test Data for project", FileIO.SearchOption.SearchTopLevelOnly, "*.jpg*", "*.gif*", "*.bmp*") ', "*.gif*", "*.jpg*", "*.bmp*", "*.png*")
            Dim index As Integer
            ''Get SaveLoc from settings
            Dim SaveLoc As String
            SaveLoc = Image

            ''Select photo to edit/view
            Dim Bitmap As String
            Bitmap = SaveLoc

            ''Use ExifWorks library
            Dim Ex As New ExifWorks(Bitmap)

            ''Set Encoding to Unicode
            Dim enc As New System.Text.UnicodeEncoding



            ''Set Encoding to Unicode
            Dim enc2 As Encoding = Encoding.Unicode
            Dim tags As String = "Simon;Dartmoor"
            ''Tags to Add



            ''Encode to Unicode and switch to Bytes
            Dim Data() As Byte = enc2.GetBytes(tags & vbNullChar)

            ''Append the Keywords field with the new tags
            Ex.SetProperty(&H9C9E, Data, ExifWorks.ExifDataTypes.UnsignedByte)



            ''Save the changes
            IO.Directory.CreateDirectory("C:\Users\Simon\Documents\Test Data for project\tagged\")
            Ex.GetBitmap.Save("C:\Users\Simon\Documents\Test Data for project\tagged\" + IO.Path.GetFileName(SaveLoc))
        Next

    End Sub

    <TestMethod()>
    Public Sub BulkSortByDate()

        Dim Text1 As String
        Dim Text2 As String
        Dim imageloc As String
        Dim Index As Integer
        Dim first10Chars As String

        Try

            For Each Image As String In My.Computer.FileSystem.GetFiles("C:\Users\Simon\Documents\Test Data for project", FileIO.SearchOption.SearchTopLevelOnly, "*.jpg*", "*.gif*", "*.bmp*") ', "*.gif*", "*.jpg*", "*.bmp*", "*.png*")


                imageloc = "C:\Users\Simon\Documents\Test Data for project"
                Dim EW As New ExifWorks(Image)
                Text1 = EW.DateTimeOriginal

                first10Chars = Text1.Substring(0, 10)


                first10Chars = first10Chars.Split(" "c)(0) 'Checks for a space at the end and if there is one, removes it and everything after it.
                first10Chars = first10Chars.Replace("\", ".")
                first10Chars = first10Chars.Replace("/", ".")

                Index += 1
                Text2 = "C:\Users\Simon\Documents\Test Data for project\Test Destination" + "\" + first10Chars + "\"


                Try

                    Directory.CreateDirectory(Text2)
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.OkOnly)
                End Try

                Try



                    Dim file = New FileInfo("C:\Users\Simon\Documents\Test Data for project\Test Destination\")
                    file.CopyTo(Text2 & "\" & file.Name)
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.OkOnly)
                End Try

            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly)

        End Try
    End Sub
End Class
