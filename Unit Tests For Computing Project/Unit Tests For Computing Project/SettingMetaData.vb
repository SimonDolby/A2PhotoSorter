Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class SettingMetaData

    <TestMethod()>
    <Timeout(50000)>
    Public Sub SettingMetaData()

        Dim index As Integer
        ''Get SaveLoc from settings
        Dim SaveLoc As String
        SaveLoc = ="C:\Users\Simon\Documents\Test Data for project\Photo 1"

        ''Select photo to edit/view
        Dim Bitmap As String
        Bitmap = SaveLoc

        ''Use ExifWorks library
        Dim Ex As New ExifWorks(Bitmap)

        ''Set Encoding to Unicode
        Dim enc As New System.Text.UnicodeEncoding



        ''Set Encoding to Unicode
        Dim enc2 As Encoding = Encoding.Unicode
        Dim tags As String = "Simon;Concert"
        ''Tags to Add


        ''Encode to Unicode and switch to Bytes
        Dim Data() As Byte = enc2.GetBytes(tags & vbNullChar)

        ''Append the Keywords field with the new tags
        Ex.SetProperty(&H9C9E, Data, ExifWorks.ExifDataTypes.UnsignedByte)


        ''Save the changes
        Ex.GetBitmap.Save("C:\Users\Simon\Documents\Test Data for project\tagged\" + IO.Path.GetFileName(SaveLoc))
        


    End Sub
    Public Sub TestMethod2()


    End Sub



End Class