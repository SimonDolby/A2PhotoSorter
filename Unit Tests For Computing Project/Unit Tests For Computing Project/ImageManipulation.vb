Imports System.IO
Imports System.IO.Path
Imports System.Drawing
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Drawing.Imaging
Imports System.Text

<TestClass()>
Public Class ImageManipulation
    Public Sub SaveFile(ByVal PicBox As Image, ByVal Destination As String, ByVal Path As String)
        Dim Destinationpath As String
        Dim FileName As String
        Try
            FileName = Path
            Destinationpath = Destination
            PicBox.Save(Destinationpath)
            If IO.File.Exists(Destinationpath) Then

                IO.File.Delete(Destinationpath)
                PicBox.Save(Destinationpath)
            Else
                MsgBox("Save successful")
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly)
        End Try
    End Sub


    Public Function DrawNewImage(ByVal MyImage As Image, ByVal cm1 As ColorMatrix) As Image
        Dim bm As Bitmap
        Try
            Dim image_attr As New ImageAttributes
            Dim rect As Rectangle = Rectangle.Round(MyImage.GetBounds(GraphicsUnit.Pixel))
            Dim width As Integer = MyImage.Width
            Dim height As Integer = MyImage.Height
            Dim gr As Graphics
            bm = New Bitmap(width, height)
            gr = Graphics.FromImage(bm)
            image_attr.SetColorMatrix(cm1)
            gr.DrawImage(MyImage, rect, 0, 0, width, height, GraphicsUnit.Pixel, image_attr)
            Return bm
            gr.Dispose()
            image_attr.Dispose()
            image_attr = Nothing
        Catch ex As Exception

        End Try
        Return bm
    End Function



    <TestMethod()>
    Public Sub SetSepia()
        Dim im As Image = Image.FromFile("F:\Test Data for project\Photo 1.jpg")
        Dim cm1 As ColorMatrix
        cm1 = New ColorMatrix(New Single()() { _
        New Single() {0.293, 0.249, 0.172, 0, 0}, _
        New Single() {0.669, 0.586, 0.434, 0, 0}, _
        New Single() {0.19, 0.17, 0.14, 0, 0}, _
        New Single() {0, 0, 0, 1, 0}, _
        New Single() {0, 0, 0, 0, 1}})

        im = DrawNewImage(im, cm1)
        SaveFile(im, "F:\Test Data for project\Edited Photos\Photo 1.png", "F:\Test Data for project\Photo 1.jpg")
    End Sub
    <TestMethod()>
    Public Sub InvertColors()
        Dim im As Image = Image.FromFile("F:\Test Data for project\Photo 2.jpg")
        Dim cm1 As ColorMatrix
        cm1 = New ColorMatrix(New Single()() _
             {New Single() {-1, 0, 0, 0, 0}, _
         New Single() {0, -1, 0, 0, 0}, _
         New Single() {0, 0, -1, 0, 0}, _
         New Single() {0, 0, 0, 1, 0}, _
         New Single() {1, 1, 1, 0, 1}})

        im = DrawNewImage(im, cm1)
        SaveFile(im, "F:\Test Data for project\Edited Photos\Photo 2.png", "F:\Test Data for project\Photo 2.jpg")
    End Sub
    <TestMethod()>
    Public Sub PolaroidColors()
        Dim im As Image = Image.FromFile("F:\Test Data for project\Photo 3.jpg")
        Dim cm1 As ColorMatrix
        cm1 = New ColorMatrix(New Single()() _
     {New Single() {1.438, -0.062, -0.062, 0, 0}, _
         New Single() {-0.122, 1.378, -0.122, 0, 0}, _
         New Single() {-0.016, -0.016, 1.483, 0, 0}, _
         New Single() {0, 0, 0, 1, 0}, _
         New Single() {-0.03, 0.05, -0.02, 0, 1}})

        im = DrawNewImage(im, cm1)
        SaveFile(im, "F:\Test Data for project\Edited Photos\Photo 3.png", "F:\Test Data for project\Photo 3.png")
    End Sub
    <TestMethod()>
    Public Sub SaturationBy50()
        Dim im As Image = Image.FromFile("F:\Test Data for project\Photo 4.jpg")
        Dim S As Double = 1.5
        Dim rWeight As Double = 0.2125F ' Can also be 0.3086
        Dim gWeight = 0.7154F           ' Can also be 0.6094
        Dim bWeight = 0.0721F           ' Can also be 0.0820
        Dim a As Double = (1.0F - S) * rWeight + S
        Dim b As Double = (1.0F - S) * rWeight
        Dim c As Double = (1.0F - S) * rWeight
        Dim d As Double = (1.0F - S) * gWeight
        Dim j As Double = (1.0F - S) * gWeight + S
        Dim f As Double = (1.0F - S) * gWeight
        Dim g As Double = (1.0F - S) * bWeight
        Dim h As Double = (1.0F - S) * bWeight
        Dim i As Double = (1.0F - S) * bWeight + S

        Dim cm1 As ColorMatrix

        cm1 = New ColorMatrix(New Single()() { _
            New Single() {a, b, c, 0, 0}, _
            New Single() {d, j, f, 0, 0}, _
            New Single() {g, h, i, 0, 0}, _
            New Single() {0, 0, 0, 1, 0}, _
            New Single() {0, 0, 0, 0, 1}})

        im = DrawNewImage(im, cm1)
        SaveFile(im, "F:\Test Data for project\Edited Photos\Photo 4.png", "F:\Test Data for project\Photo 4.png")
    End Sub
    <TestMethod()>
    Public Sub ContrastBy50()
        Dim im As Image = Image.FromFile("F:\Test Data for project\Photo 5.jpg")
        Dim C As Double = 1.5
        Dim t As Double = (1.0 - C) / 2.0
        Dim cm1 As ColorMatrix
        cm1 = New ColorMatrix(New Single()() _
        {New Single() {C, 0, 0, 0, 0}, _
         New Single() {0, C, 0, 0, 0}, _
         New Single() {0, 0, C, 0, 0}, _
         New Single() {0, 0, 0, 1, 0}, _
         New Single() {t, t, t, 0, 1}})

        im = DrawNewImage(im, cm1)
        SaveFile(im, "F:\Test Data for project\Edited Photos\Photo 5.png", "F:\Test Data for project\Photo 5.jpg")
    End Sub
    <TestMethod()>
    Public Sub BlackAndWhite()
        Dim im As Image = Image.FromFile("F:\Test Data for project\Photo 6.jpg")
        Dim cm1 As ColorMatrix
        cm1 = New ColorMatrix(New Single()() _
        {New Single() {1, 1, 1, 0, 0}, _
         New Single() {1, 1, 1, 0, 0}, _
         New Single() {1, 1, 1, 0, 0}, _
         New Single() {0, 0, 0, 1, 0}, _
         New Single() {-1, -1, -1, 0, 1}})

        im = DrawNewImage(im, cm1)
        SaveFile(im, "F:\Test Data for project\Edited Photos\Photo 6.png", "F:\Test Data for project\Photo 6.jpg")
    End Sub
    <TestMethod()>
    Public Sub Grayscale()
        Dim im As Image = Image.FromFile("F:\Test Data for project\Photo 7.jpg")
        Dim cm1 As ColorMatrix
        cm1 = New ColorMatrix(New Single()() _
        {New Single() {0.3, 0.3, 0.3, 0, 0}, _
         New Single() {0.59, 0.59, 0.59, 0, 0}, _
         New Single() {0.11, 0.11, 0.11, 0, 0}, _
         New Single() {0, 0, 0, 1, 0}, _
         New Single() {0, 0, 0, 0, 1}})

        im = DrawNewImage(im, cm1)
        SaveFile(im, "F:\Test Data for project\Edited Photos\Photo 7.png", "F:\Test Data for project\Photo 7.jpg")
    End Sub

    <TestMethod()>
    Public Sub RGBTOBGR()
        Dim im As Image = Image.FromFile("F:\Test Data for project\Photo 8.jpg")
        Dim cm1 As ColorMatrix
        cm1 = New ColorMatrix(New Single()() _
     {New Single() {0, 0, 1, 0, 0}, _
         New Single() {0, 1, 0, 0, 0}, _
         New Single() {1, 0, 0, 0, 0}, _
         New Single() {0, 0, 0, 1, 0}, _
         New Single() {0, 0, 0, 0, 1}})

        im = DrawNewImage(im, cm1)
        SaveFile(im, "F:\Test Data for project\Edited Photos\Photo 8.png", "F:\Test Data for project\Photo 8.jpg")
    End Sub

End Class
