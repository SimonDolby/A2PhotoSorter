Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class UnitTest1

    <TestMethod()> Public Sub TestMethod1()

        Dim SaveLoc As String
        Dim ImageLoc = ("C:\Users\Simon\Music\Pictures\100PHOTO\DSC_3607.jpg")
        SaveLoc = ImageLoc


        'Select photo to edit/view
        Dim Bitmap As String
        Bitmap = SaveLoc

        'Use EWifWorks library
        Dim EW As New ExifWorks(Bitmap)

        'Set Encoding to Unicode
        Dim enc As New System.Text.UnicodeEncoding


        'Get data from the selected fields

        If IsNothing(EW.GetProperty(&H9C9B)) Then
            MsgBox("The title is empty")
        Else
            Dim Simon = EW.GetProperty(&H9C9B)
            Dim Decode = enc.GetChars(Simon)
            MsgBox(Decode)

        End If
        Dim Subject = EW.GetProperty(&H9C9F)
        Dim keywords = EW.GetProperty(&H829A)

        'Use Unicode encoding to get the contents currently within Keywords



        'View the current tags, decoded from Unicode
    End Sub

End Class