Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class SettingMetaData

    <TestMethod()>
    <Timeout(50000)>
    Public Sub TestMethod1()
        For Each Image As String In My.Computer.FileSystem.GetFiles("F:\Test Data for project", FileIO.SearchOption.SearchTopLevelOnly, "*.jpg*", "*.gif*", "*.bmp*") ', "*.gif*", "*.jpg*", "*.bmp*", "*.png*")
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
            Dim tags As String = "Test1;Test3;Test2;"
            ''Tags to Add


            ''Encode to Unicode and switch to Bytes
            Dim Data() As Byte = enc2.GetBytes(tags & vbNullChar)

            ''Append the Keywords field with the new tags
            Ex.SetProperty(&H9C9E, Data, ExifWorks.ExifDataTypes.UnsignedByte)


            ''Save the changes
            Ex.GetBitmap.Save("F:\Test Data for project\tagged\" + IO.Path.GetFileName(SaveLoc))
        Next



    End Sub
    Public Sub TestMethod2()


    End Sub



End Class