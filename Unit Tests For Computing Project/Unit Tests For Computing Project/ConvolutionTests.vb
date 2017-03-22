Imports System.Text
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Imports System.Threading.Tasks

<TestClass()>
Public Class ConvolutionTests
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
    Public Shared ReadOnly Property Laplacian5x5() As Double(,)
        Get
            Return New Double(,) {{-1, -1, -1, -1, -1},
                                  {-1, -1, -1, -1, -1},
                                  {-1, -1, 24, -1, -1},
                                  {-1, -1, -1, -1, -1},
                                  {-1, -1, -1, -1, -1}}
        End Get
    End Property


    Public Shared ReadOnly Property Sharpen() As Double(,)
        Get

            Return New Double(,) {{0, -1, 0},
                                  {-1, 5, -1},
                                  {0, -1, 0}}



        End Get
    End Property
    Public Shared ReadOnly Property Emboss() As Double(,)
        Get
            Return New Double(,) {{-2, -1, 0},
                                  {-1, 1, 1},
                                  {0, 1, 2}}
        End Get
    End Property
    Public Shared ReadOnly Property SimpleEdgeDetection() As Double(,)
        Get
            Return New Double(,) {{0, 1, 0},
                                  {-1, -4, 1},
                                  {0, 1, 0}}
        End Get
    End Property

    Public Shared Function GetSharpen(ByVal sourceBitmap As Bitmap, Optional ByVal bias As Integer = 0, Optional ByVal grayscale As Boolean = False, Optional ByVal mono As Boolean = False, Optional ByVal medianFilterSize As Integer = 0) As Bitmap
        Dim resultBitmap As Bitmap = ConvolutionFilter(sourceBitmap, Sharpen, 1.0, 0, grayscale)


        Return resultBitmap
    End Function


    Public Shared Function GetEmboss(ByVal sourceBitmap As Bitmap, Optional ByVal bias As Integer = 0, Optional ByVal grayscale As Boolean = False, Optional ByVal mono As Boolean = False, Optional ByVal medianFilterSize As Integer = 0) As Bitmap
        Dim resultBitmap As Bitmap = ConvolutionFilter(sourceBitmap, Emboss, 1.0, 0, grayscale)


        Return resultBitmap
    End Function


    Public Shared Function GetSimpleEdgeDetect(ByVal sourceBitmap As Bitmap, Optional ByVal bias As Integer = 0, Optional ByVal grayscale As Boolean = True, Optional ByVal mono As Boolean = True, Optional ByVal medianFilterSize As Integer = 0) As Bitmap
        Dim resultBitmap As Bitmap = ConvolutionFilter(sourceBitmap, SimpleEdgeDetection, 1.0, 0, grayscale)


        Return resultBitmap
    End Function
    Public Shared Function Laplacian5x5Filter(ByVal sourceBitmap As Bitmap, Optional ByVal grayscale As Boolean = True) As Bitmap
        Dim resultBitmap As Bitmap = ConvolutionFilter(sourceBitmap, Laplacian5x5, 1.0, 0, grayscale)


        Return resultBitmap
    End Function
    Public Shared Function ConvolutionFilter(ByVal sourceBitmap As Bitmap, ByVal filterMatrix As Double(,), Optional ByVal factor As Double = 1, Optional ByVal bias As Integer = 0, Optional ByVal grayscale As Boolean = False) As Bitmap
        'Gets Bitmap data from the image and locks the bits to the system memory, this allows for faster more efficient image processing.
        'Locking the bits to systom memory prevents the bitmap object form being moved to a new memory location.
        'Locking the bits also allows me to access the ARGB values of an image(Alpha, Red, Green, Blue)
        Dim sourceData As BitmapData = sourceBitmap.LockBits(New Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height), ImageLockMode.[ReadOnly], PixelFormat.Format32bppArgb)

        'We need two data buffers.
        Dim pixelBuffer As Byte() = New Byte(sourceData.Stride * sourceData.Height - 1) {}


        Dim resultBuffer As Byte() = New Byte(sourceData.Stride * sourceData.Height - 1) {}




        'Using Marshal.Copy, this specifies the memory point address to start at.

        Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length)

        'Unlocks the original images bits. 
        sourceBitmap.UnlockBits(sourceData)

        'Checks if the image needs to be in grayscale form and if not, puts it into grayscale form

            If grayscale = True Then
                Dim rgb As Single = 0


                Dim k As Integer = 0
                While k < pixelBuffer.Length
                    rgb = pixelBuffer(k) * 0.11F
                    rgb += pixelBuffer(k + 1) * 0.59F
                    rgb += pixelBuffer(k + 2) * 0.3F


                    pixelBuffer(k) = CType(rgb, Byte)
                    pixelBuffer(k + 1) = pixelBuffer(k)
                    pixelBuffer(k + 2) = pixelBuffer(k)
                    pixelBuffer(k + 3) = 255
                    k += 4
                End While
            End If

            'Set the RGB values to 0.0
            Dim blue As Double = 0.0
            Dim green As Double = 0.0
            Dim red As Double = 0.0


            Dim filterWidth As Integer = filterMatrix.GetLength(1)
            Dim filterHeight As Integer = filterMatrix.GetLength(0)


            Dim filterOffset As Integer = (filterWidth - 1) / 2
            Dim calcOffset As Integer = 0


            Dim byteOffset As Integer = 0


            Dim offsetY As Integer = filterOffset
            While offsetY < sourceBitmap.Height - filterOffset
                Dim offsetX As Integer = filterOffset
                While offsetX < sourceBitmap.Width - filterOffset
                    blue = 0
                    green = 0
                    red = 0


                    byteOffset = offsetY * sourceData.Stride + offsetX * 4


                    Dim filterY As Integer = -filterOffset
                    While filterY <= filterOffset
                        Dim filterX As Integer = -filterOffset
                        While filterX <= filterOffset


                            calcOffset = byteOffset + (filterX * 4) + (filterY * sourceData.Stride)


                            blue += CType(pixelBuffer(calcOffset), Double) * filterMatrix(filterY + filterOffset, filterX + filterOffset)


                            green += CType(pixelBuffer(calcOffset + 1), Double) * filterMatrix(filterY + filterOffset, filterX + filterOffset)


                            red += CType(pixelBuffer(calcOffset + 2), Double) * filterMatrix(filterY + filterOffset, filterX + filterOffset)
                            System.Math.Max(System.Threading.Interlocked.Increment(filterX), filterX - 1)
                        End While
                        System.Math.Max(System.Threading.Interlocked.Increment(filterY), filterY - 1)
                    End While


                    blue = factor * blue + bias
                    green = factor * green + bias
                    red = factor * red + bias


                    If blue > 255 Then
                        blue = 255
                    ElseIf blue < 0 Then
                        blue = 0
                    End If


                    If green > 255 Then
                        green = 255
                    ElseIf green < 0 Then
                        green = 0
                    End If


                    If red > 255 Then
                        red = 255
                    ElseIf red < 0 Then
                        red = 0
                    End If


                    resultBuffer(byteOffset) = CType(blue, Byte)
                    resultBuffer(byteOffset + 1) = CType(green, Byte)
                    resultBuffer(byteOffset + 2) = CType(red, Byte)
                    resultBuffer(byteOffset + 3) = 255
                    System.Math.Max(System.Threading.Interlocked.Increment(offsetX), offsetX - 1)
                End While
                System.Math.Max(System.Threading.Interlocked.Increment(offsetY), offsetY - 1)
            End While


            Dim resultBitmap As New Bitmap(sourceBitmap.Width, sourceBitmap.Height)


            Dim resultData As BitmapData = resultBitmap.LockBits(New Rectangle(0, 0, resultBitmap.Width, resultBitmap.Height), ImageLockMode.[WriteOnly], PixelFormat.Format32bppArgb)


            Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length)
            resultBitmap.UnlockBits(resultData)


            Return resultBitmap



    End Function

    <TestMethod()>
    Public Sub SharpenImage()
        Dim im As Image = Image.FromFile("F:\Test Data for project\Photo 1.jpg")
        'im = GetSharpen(im, 500)
        SaveFile(im, "F:\Test Data for project\Edited Photos\Photo 1.png", "F:\Test Data for project\Photo 1.jpg")

    End Sub
    <TestMethod()>
    Public Sub EmbossImage()
        Dim im As Image = Image.FromFile("F:\Test Data for project\Photo 2.jpg")
        'im = GetEmboss(im, 500)
        SaveFile(im, "F:\Test Data for project\Edited Photos\Photo 2.png", "F:\Test Data for project\Photo 2.jpg")

    End Sub
    <TestMethod()>
    Public Sub SimpleEdgeDetectionImage()
        Dim im As Image = Image.FromFile("F:\Test Data for project\Photo 3.jpg")
        'im = Laplacian5x5Filter(im, 500)
        SaveFile(im, "F:\Test Data for project\Edited Photos\Photo 3.png", "F:\Test Data for project\Photo 3.jpg")

    End Sub
End Class
