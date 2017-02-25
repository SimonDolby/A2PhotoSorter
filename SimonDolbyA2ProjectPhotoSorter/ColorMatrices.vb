Imports System.Drawing.Imaging
Imports System.Drawing

Module ColorMatrices ' Module for all the color matrices that enable me to change certain attributes
    Public Function Saturation(ByVal im As Image, ByVal GetSat As Double) As Image
        'Gets the level of saturation the user wants through the parameter GetSat which is parsed by Value. This value should come from a textbox or a slider.
        Dim S As Double = GetSat
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

        Return DrawNewImage(im, cm1)

    End Function
    Public Function Contrast(ByVal Im As Image, ByVal GetCon As Double) As Image
        'Gets the level of Contrast the user wants through the parameter GetSat which is parsed by Value. This value should come from a textbox or a slider.
        Dim C As Double = GetCon
        Dim t As Double = (1.0 - C) / 2.0
        Dim cm1 As ColorMatrix

        cm1 = New ColorMatrix(New Single()() _
        {New Single() {C, 0, 0, 0, 0}, _
         New Single() {0, C, 0, 0, 0}, _
         New Single() {0, 0, C, 0, 0}, _
         New Single() {0, 0, 0, 1, 0}, _
         New Single() {t, t, t, 0, 1}})

        Return DrawNewImage(Im, cm1)

    End Function
    Public Function RGBTOBGR(ByVal Im As Image) As Image

        Dim cm1 As ColorMatrix
        cm1 = New ColorMatrix(New Single()() _
        {New Single() {0, 0, 1, 0, 0}, _
         New Single() {0, 1, 0, 0, 0}, _
         New Single() {1, 0, 0, 0, 0}, _
         New Single() {0, 0, 0, 1, 0}, _
         New Single() {0, 0, 0, 0, 1}})

        Return DrawNewImage(Im, cm1)

    End Function
    Public Function RGBTOGBR(ByVal Im As Image) As Image

        Dim cm1 As ColorMatrix
        cm1 = New ColorMatrix(New Single()() _
     {New Single() {1, 0, 0, 0, 0}, _
         New Single() {0, 1, 0, 0, 0}, _
         New Single() {0, 0, 1, 0, 0}, _
         New Single() {0, 0, 0, 1, 0}, _
         New Single() {0, 0, 0, 0, 1}})

        Return DrawNewImage(Im, cm1)

    End Function

    Public Function GetPolaroidColors(ByVal Im As Image) As Image

        Dim cm1 As ColorMatrix
        cm1 = New ColorMatrix(New Single()() _
     {New Single() {1.438, -0.062, -0.062, 0, 0}, _
         New Single() {-0.122, 1.378, -0.122, 0, 0}, _
         New Single() {-0.016, -0.016, 1.483, 0, 0}, _
         New Single() {0, 0, 0, 1, 0}, _
         New Single() {-0.03, 0.05, -0.02, 0, 1}})

        Return DrawNewImage(Im, cm1)

    End Function
    Public Function BlackAndWhite(ByVal Im As Image) As Image


        Dim cm1 As ColorMatrix
        cm1 = New ColorMatrix(New Single()() _
        {New Single() {1, 1, 1, 0, 0}, _
         New Single() {1, 1, 1, 0, 0}, _
         New Single() {1, 1, 1, 0, 0}, _
         New Single() {0, 0, 0, 1, 0}, _
         New Single() {-1, -1, -1, 0, 1}})

        Return DrawNewImage(Im, cm1)

    End Function
    Public Function InvertColors(ByVal Im As Image) As Image


        Dim cm1 As ColorMatrix
        cm1 = New ColorMatrix(New Single()() _
             {New Single() {-1, 0, 0, 0, 0}, _
         New Single() {0, -1, 0, 0, 0}, _
         New Single() {0, 0, -1, 0, 0}, _
         New Single() {0, 0, 0, 1, 0}, _
         New Single() {1, 1, 1, 0, 1}})

        Return DrawNewImage(Im, cm1)

    End Function
    Public Function Grayscale(ByVal im As Image) As Image
        Dim cm1 As ColorMatrix
        cm1 = New ColorMatrix(New Single()() _
        {New Single() {0.3, 0.3, 0.3, 0, 0}, _
         New Single() {0.59, 0.59, 0.59, 0, 0}, _
         New Single() {0.11, 0.11, 0.11, 0, 0}, _
         New Single() {0, 0, 0, 1, 0}, _
         New Single() {0, 0, 0, 0, 1}})

        Return DrawNewImage(im, cm1)


    End Function
    Public Function Sepia(ByVal im As Image) As Image
        Dim cm1 As ColorMatrix
        cm1 = New ColorMatrix(New Single()() { _
        New Single() {0.293, 0.249, 0.172, 0, 0}, _
        New Single() {0.669, 0.586, 0.434, 0, 0}, _
        New Single() {0.19, 0.17, 0.14, 0, 0}, _
        New Single() {0, 0, 0, 1, 0}, _
        New Single() {0, 0, 0, 0, 1}})

        Return DrawNewImage(im, cm1)

    End Function
    Private Function DrawNewImage(ByVal MyImage As Image, ByVal cm1 As ColorMatrix) As Image
        'Applys the color matrix that's been called by passing the image and color matrix by Value to the DrawNewImage Function
        Dim bm As Bitmap

        Try
            Dim image_attr As New ImageAttributes 'Creates new Image Attributes
            Dim rect As Rectangle = Rectangle.Round(MyImage.GetBounds(GraphicsUnit.Pixel)) ' Gets the size of the image and sets the the size of the image to the size of the rectangle
            Dim width As Integer = MyImage.Width '
            Dim height As Integer = MyImage.Height
            Dim gr As Graphics
            bm = New Bitmap(width, height) 'Creates a new bitmap from the images width and height.
            gr = Graphics.FromImage(bm) 'Gets the graphics from the image.
            image_attr.SetColorMatrix(cm1) ' Sets the image Attributes to the specified color matrix.
            gr.DrawImage(MyImage, rect, 0, 0, width, height, GraphicsUnit.Pixel, image_attr) 'Draws the new image with all the attributes. and assigns it to MyImage.
            Return bm
            gr.Dispose() 'Removes gr from memory
            image_attr.Dispose() ' Removes image_attr from memory
            image_attr = Nothing
        Catch ex As Exception

        End Try
        Return bm
    End Function

End Module
