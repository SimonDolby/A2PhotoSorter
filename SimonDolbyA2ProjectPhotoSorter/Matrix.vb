Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text


Public Class Matrix
    ' This class contains the related matrices that are called by ConvolutionMatrices.vb


    Public Shared ReadOnly Property Laplacian3x3() As Double(,)
        Get
            Return New Double(,) {{-1, -1, -1},
                                  {-1, 8, -1},
                                  {-1, -1, -1}}
        End Get
    End Property


    Public Shared ReadOnly Property Laplacian5x5() As Double(,)
        Get
            Return New Double(,) {{-1, -1, -1, -1, -1},
                                  {-1, -1, -1, -1, -1},
                                  {-1, -1, 24, -1, -1},
                                  {-1, -1, -1, -1, -1},
                                  {-1, -1, -1, -1, -1}}
        End Get
    End Property

    Public Shared ReadOnly Property LaplacianOfGaussian() As Double(,)
        Get
            Return New Double(,) {{0, 0, -1, 0, 0},
                                  {0, -1, -2, -1, 0},
                                  {-1, -2, 16, -2, -1},
                                  {0, -1, -2, -1, 0},
                                  {0, 0, -1, 0, 0}}
        End Get
    End Property

    Public Shared ReadOnly Property Gaussian3x3() As Double(,)
        Get
            Return New Double(,) {{1, 2, 1},
                                  {2, 4, 2},
                                  {1, 2, 1}}
        End Get
    End Property

    Public Shared ReadOnly Property Gaussian5x5Type1() As Double(,)
        Get
            Return New Double(,) {{2, 4, 5, 4, 2},
                                  {4, 9, 12, 9, 4},
                                  {5, 12, 15, 12, 5},
                                  {4, 9, 12, 9, 4},
                                  {2, 4, 5, 4, 2}}
        End Get
    End Property

    Public Shared ReadOnly Property Gaussian5x5Type2() As Double(,)
        Get
            Return New Double(,) {{1, 4, 6, 4, 1},
                                  {4, 16, 24, 16, 4},
                                  {6, 24, 36, 24, 6},
                                  {4, 16, 24, 16, 4},
                                  {1, 4, 6, 4, 1}}
        End Get
    End Property

    Public Shared ReadOnly Property Sobel3x3Horizontal() As Double(,)
        Get
            Return New Double(,) {{-1, 0, 1},
                                  {-2, 0, 2},
                                  {-1, 0, 1}}
        End Get
    End Property

    Public Shared ReadOnly Property Sobel3x3Vertical() As Double(,)
        Get
            Return New Double(,) {{1, 2, 1},
                                 {0, 0, 0},
                                 {-1, -2, -1}}
        End Get
    End Property

    Public Shared ReadOnly Property Prewitt3x3Horizontal() As Double(,)
        Get
            Return New Double(,) {{-1, 0, 1},
                                  {-1, 0, 1},
                                  {-1, 0, 1}}
        End Get
    End Property

    Public Shared ReadOnly Property Prewitt3x3Vertical() As Double(,)
        Get
            Return New Double(,) {{1, 1, 1},
                                  {0, 0, 0},
                                  {-1, -1, -1}}
        End Get
    End Property


    Public Shared ReadOnly Property Kirsch3x3Horizontal() As Double(,)
        Get
            Return New Double(,) {{5, 5, 5},
                                 {-3, 0, -3},
                                 {-3, -3, -3}}
        End Get
    End Property

    Public Shared ReadOnly Property Kirsch3x3Vertical() As Double(,)
        Get
            Return New Double(,) {{5, -3, -3},
                                  {5, 0, -3},
                                  {5, -3, -3}}
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
End Class

