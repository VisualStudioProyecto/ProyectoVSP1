Public Class Provincia
    Private _nombreProvincia As String

    Sub New(nombreProvincia As String)
        _nombreProvincia = nombreProvincia
        'calcularIva(nombreProvincia)
    End Sub

    Public Property NombreProvincia() As String
        Get
            Return _nombreProvincia
        End Get
        Set(ByVal value As String)
            _nombreProvincia = value
        End Set
    End Property

    Private _iva As Double
    Public Property Iva() As Double
        Get
            Return _iva
        End Get
        Set(ByVal value As Double)
            _iva = value
        End Set
    End Property

    'Sub calcularIva(nombreProv As String)
    '    Select Case nombreProv
    '        Case "Esmeraldas", "Manabi"
    '            Me._iva = 0.12
    '        Case Else
    '            Me._iva = 0.14
    '    End Select
    'End Sub

End Class
