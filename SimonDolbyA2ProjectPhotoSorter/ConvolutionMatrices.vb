Imports System.Drawing.Drawing2D
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Threading.Tasks
Imports System.Threading
Imports System.Runtime.InteropServices
Public Class Convolution_Matrices





    Private Sub New()
    End Sub
    'This routine provides support for a single matrix.
    Public Shared Function ConvolutionFilter(ByVal sourceBitmap As Bitmap, ByVal filterMatrix As Double(,), Optional ByVal factor As Double = 1, Optional ByVal bias As Integer = 0, Optional ByVal grayscale As Boolean = False) As Bitmap
        'Gets Bitmap data from the image and locks the bits to the system memory, this allows for faster more efficient image processing.
        'Locking the bits to systom memory prevents the bitmap object form being moved to a new memory location.
        'Locking the bits also allows me to access the ARGB values of an image(Alpha, Red, Green, Blue)
        Dim sourceData As BitmapData = sourceBitmap.LockBits(New Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height), ImageLockMode.[ReadOnly], PixelFormat.Format32bppArgb)

        'We need two data buffers.
        'Both data buffers are dynamic arrays because photos are of various sizes and that needs to be accounted for.
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
        'These two while loops iterate each pixel represeted in the ARGB data bufer.
        'The index of the current pixel can be calculated by multiplying the current
        'row index and the number of ARGB byte values per row of pixels , to which is
        'added the current column/pixel index multiplied by 4
        While offsetY < sourceBitmap.Height - filterOffset

            Dim offsetX As Integer = filterOffset
            While offsetX < sourceBitmap.Width - filterOffset
                blue = 0
                green = 0
                red = 0


                byteOffset = offsetY * sourceData.Stride + offsetX * 4

                'Iterating the Matrix 
                'This is done by implementing two seperate loops, iterating rows and for each row, iterating the columns. 
                'Both loops are declared to be have a starting point which is equal to the negative value of half the matrix length. 
                'Starting with negative values in the loops makes it simpler to implement the idea of neighbouring pixels

                Dim filterY As Integer = -filterOffset
                While filterY <= filterOffset
                    Dim filterX As Integer = -filterOffset
                    While filterX <= filterOffset

                        'Here the index of the neighbouring pixel is calculated in relation to the current pixel. 
                        calcOffset = byteOffset + (filterX * 4) + (filterY * sourceData.Stride)

                        'The matrix is applied to as a factor to the neighbouring pixel's individual color components. 
                        'The results of such an operation are added to the totals variables. Blue, green and then red.
                        'Each iteration iterates in terms of the entire pixel. In order to access the individual color components, the required color component offset is added.
                        blue += CType(pixelBuffer(calcOffset), Double) * filterMatrix(filterY + filterOffset, filterX + filterOffset)


                        green += CType(pixelBuffer(calcOffset + 1), Double) * filterMatrix(filterY + filterOffset, filterX + filterOffset)


                        red += CType(pixelBuffer(calcOffset + 2), Double) * filterMatrix(filterY + filterOffset, filterX + filterOffset)
                        System.Math.Max(System.Threading.Interlocked.Increment(filterX), filterX - 1)
                    End While
                    System.Math.Max(System.Threading.Interlocked.Increment(filterY), filterY - 1)
                End While


                'After iterating the matrix and calculating it's values of each pixels RGB color components,
                ' we apply the factor and add the factor defined by the filters parameter. 

                blue = factor * blue + bias
                green = factor * green + bias
                red = factor * red + bias
                'The color components can only contain a value ranging from 0 to 255. 
                'Before we assign the newly calculated color component value, we ensure that the value falls within the required range.
                'In order to achieve this, any values greater than 255 are set to 255 any values less than 0 are set to 0.


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

                'Returning the Result

                resultBuffer(byteOffset) = CType(blue, Byte)
                resultBuffer(byteOffset + 1) = CType(green, Byte)
                resultBuffer(byteOffset + 2) = CType(red, Byte)
                resultBuffer(byteOffset + 3) = 255
                System.Math.Max(System.Threading.Interlocked.Increment(offsetX), offsetX - 1)
            End While
            System.Math.Max(System.Threading.Interlocked.Increment(offsetY), offsetY - 1)
        End While

        'The final part is creating a new bitmap object and copying the calculated result buffer. 
        Dim resultBitmap As New Bitmap(sourceBitmap.Width, sourceBitmap.Height)


        'Similar to how we read the data we do the same to copy the result buffer to the new object.
        Dim resultData As BitmapData = resultBitmap.LockBits(New Rectangle(0, 0, resultBitmap.Width, resultBitmap.Height), ImageLockMode.[WriteOnly], PixelFormat.Format32bppArgb)


        Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length)
        resultBitmap.UnlockBits(resultData)


        Return resultBitmap



    End Function

    'This routine provides support for two matrices.
    'The difference between this and the first one is that it overloads the function in order to add another parameter. 
    Public Shared Function ConvolutionFilterVH(ByVal sourceBitmap As Bitmap, ByVal xFilterMatrix As Double(,), ByVal yFilterMatrix As Double(,), Optional ByVal factor As Double = 1, Optional ByVal bias As Integer = 0, Optional ByVal grayscale As Boolean = False) As Bitmap
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


        Dim blueX As Double = 0.0
        Dim greenX As Double = 0.0
        Dim redX As Double = 0.0


        Dim blueY As Double = 0.0
        Dim greenY As Double = 0.0
        Dim redY As Double = 0.0


        Dim blueTotal As Double = 0.0
        Dim greenTotal As Double = 0.0
        Dim redTotal As Double = 0.0


        Dim filterOffset As Integer = 1
        Dim calcOffset As Integer = 0


        Dim byteOffset As Integer = 0

        'These two while loops iterate each pixel represeted in the ARGB data bufer.
        'The index of the current pixel can be calculated by multiplying the current
        'row index and the number of ARGB byte values per row of pixels , to which is
        'added the current column/pixel index multiplied by 4
        Dim offsetY As Integer = filterOffset
        While offsetY < sourceBitmap.Height - filterOffset
            Dim offsetX As Integer = filterOffset
            While offsetX < sourceBitmap.Width - filterOffset
                blueX = InlineAssignHelper(greenX, InlineAssignHelper(redX, 0))
                blueY = InlineAssignHelper(greenY, InlineAssignHelper(redY, 0))


                blueTotal = InlineAssignHelper(greenTotal, InlineAssignHelper(redTotal, 0.0))


                byteOffset = offsetY * sourceData.Stride + offsetX * 4

                'Iterating the Matrix 
                'This is done by implementing two seperate loops, iterating rows and for each row, iterating the columns. 
                'Both loops are declared to be have a starting point which is equal to the negative value of half the matrix length. 
                'Starting with negative values in the loops makes it simpler to implement the idea of neighbouring pixels

                Dim filterY As Integer = -filterOffset
                While filterY <= filterOffset
                    Dim filterX As Integer = -filterOffset
                    While filterX <= filterOffset
                        calcOffset = byteOffset + (filterX * 4) + (filterY * sourceData.Stride)


                        'The matrix is applied to as a factor to the neighbouring pixel's individual color components. 
                        'The results of such an operation are added to the totals variables. Blue, green and then red.
                        'Each iteration iterates in terms of the entire pixel. In order to access the individual color components, the required color component offset is added.
                        blueX += CType(pixelBuffer(calcOffset), Double) * xFilterMatrix(filterY + filterOffset, filterX + filterOffset)


                        greenX += CType(pixelBuffer(calcOffset + 1), Double) * xFilterMatrix(filterY + filterOffset, filterX + filterOffset)


                        redX += CType(pixelBuffer(calcOffset + 2), Double) * xFilterMatrix(filterY + filterOffset, filterX + filterOffset)


                        blueY += CType(pixelBuffer(calcOffset), Double) * yFilterMatrix(filterY + filterOffset, filterX + filterOffset)


                        greenY += CType(pixelBuffer(calcOffset + 1), Double) * yFilterMatrix(filterY + filterOffset, filterX + filterOffset)


                        redY += CType(pixelBuffer(calcOffset + 2), Double) * yFilterMatrix(filterY + filterOffset, filterX + filterOffset)
                        System.Math.Max(System.Threading.Interlocked.Increment(filterX), filterX - 1)
                    End While
                    System.Math.Max(System.Threading.Interlocked.Increment(filterY), filterY - 1)
                End While

                'After iterating the matrix and calculating it's values of each pixels RGB color components,
                ' we apply the factor and add the factor defined by the filters parameter. 
                blueTotal = Math.Sqrt((blueX * blueX) + (blueY * blueY))


                greenTotal = Math.Sqrt((greenX * greenX) + (greenY * greenY))


                redTotal = Math.Sqrt((redX * redX) + (redY * redY))
                'The color components can only contain a value ranging from 0 to 255. 
                'Before we assign the newly calculated color component value, we ensure that the value falls within the required range.
                'In order to achieve this, any values greater than 255 are set to 255 any values less than 0 are set to 0.


                If blueTotal > 255 Then
                    blueTotal = 255
                ElseIf blueTotal < 0 Then
                    blueTotal = 0
                End If


                If greenTotal > 255 Then
                    greenTotal = 255
                ElseIf greenTotal < 0 Then
                    greenTotal = 0
                End If


                If redTotal > 255 Then
                    redTotal = 255
                ElseIf redTotal < 0 Then
                    redTotal = 0
                End If

                resultBuffer(byteOffset) = CType(blueTotal, Byte)
                resultBuffer(byteOffset + 1) = CType(greenTotal, Byte)
                resultBuffer(byteOffset + 2) = CType(redTotal, Byte)
                resultBuffer(byteOffset + 3) = 255
                System.Math.Max(System.Threading.Interlocked.Increment(offsetX), offsetX - 1)
            End While
            System.Math.Max(System.Threading.Interlocked.Increment(offsetY), offsetY - 1)
        End While

        'The final part is creating a new bitmap object and copying the calculated result buffer. 
        Dim resultBitmap As New Bitmap(sourceBitmap.Width, sourceBitmap.Height)

        'Similar to how we read the data we do the same to copy the result buffer to the new object.
        Dim resultData As BitmapData = resultBitmap.LockBits(New Rectangle(0, 0, resultBitmap.Width, resultBitmap.Height), ImageLockMode.[WriteOnly], PixelFormat.Format32bppArgb)


        Marshal.Copy(resultBuffer, 0, resultData.Scan0, resultBuffer.Length)
        resultBitmap.UnlockBits(resultData)


        Return resultBitmap
    End Function
    ' The remaining functions just use the above methods combined with the matrices defined in Matrix.vb to apply the convolution to the images


    Public Shared Function Laplacian3x3Filter(ByVal sourceBitmap As Bitmap, Optional ByVal grayscale As Boolean = True) As Bitmap
        Dim resultBitmap As Bitmap = ConvolutionFilter(sourceBitmap, Matrix.Laplacian3x3, 1.0, 0, grayscale)


        Return resultBitmap
    End Function


    Public Shared Function Sharpen(ByVal sourceBitmap As Bitmap, Optional ByVal bias As Integer = 0, Optional ByVal grayscale As Boolean = False, Optional ByVal mono As Boolean = False, Optional ByVal medianFilterSize As Integer = 0) As Bitmap
        Dim resultBitmap As Bitmap = ConvolutionFilter(sourceBitmap, Matrix.Sharpen, 1.0, 0, grayscale)


        Return resultBitmap
    End Function


    Public Shared Function Emboss(ByVal sourceBitmap As Bitmap, Optional ByVal bias As Integer = 0, Optional ByVal grayscale As Boolean = False, Optional ByVal mono As Boolean = False, Optional ByVal medianFilterSize As Integer = 0) As Bitmap
        Dim resultBitmap As Bitmap = ConvolutionFilter(sourceBitmap, Matrix.Emboss, 1.0, 0, grayscale)


        Return resultBitmap
    End Function


    Public Shared Function SimpleEdgeDetect(ByVal sourceBitmap As Bitmap, Optional ByVal bias As Integer = 0, Optional ByVal grayscale As Boolean = True, Optional ByVal mono As Boolean = True, Optional ByVal medianFilterSize As Integer = 0) As Bitmap
        Dim resultBitmap As Bitmap = ConvolutionFilter(sourceBitmap, Matrix.SimpleEdgeDetection, 1.0, 0, grayscale)


        Return resultBitmap
    End Function
    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, ByVal value As T) As T
        target = value
        Return value
    End Function
End Class

