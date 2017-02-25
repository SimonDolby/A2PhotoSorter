
Public Class ConvMatrix

    Public Property Factor() As Integer
        Get
            Return m_Factor
        End Get
        Set(ByVal value As Integer)
            m_Factor = Value
        End Set
    End Property
    Private m_Factor As Integer
    Public Property Offset() As Integer
        Get
            Return m_Offset
        End Get
        Set(ByVal value As Integer)
            m_Offset = Value
        End Set
    End Property
    Private m_Offset As Integer

    Private _matrix As Integer(,) = {{0, 0, 0, 0, 0}, {0, 0, 0, 0, 0}, {0, 0, 1, 0, 0}, {0, 0, 0, 0, 0}, {0, 0, 0, 0, 0}}

    Public Property Matrix() As Integer(,)
        Get
            Return _matrix
        End Get
        Set(ByVal value As Integer(,))
            _matrix = value

            Factor = 0
            For i As Integer = 0 To Size - 1
                For j As Integer = 0 To Size - 1
                    Factor += _matrix(i, j)
                Next
            Next

            If Factor = 0 Then
                Factor = 1
            End If
        End Set
    End Property




    Private _size As Integer = 5
    Public Property Size() As Integer
        Get
            Return _size
        End Get
        Set(ByVal value As Integer)
            If value <> 1 AndAlso value <> 3 AndAlso value <> 5 AndAlso value <> 7 Then
                _size = 5
            Else
                _size = value
            End If
        End Set
    End Property


    Public Sub New()
        Offset = 0
        Factor = 1
    End Sub


End Class