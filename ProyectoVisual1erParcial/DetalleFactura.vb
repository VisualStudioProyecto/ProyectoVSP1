Imports System.Xml

Public Class DetalleFactura
    Private _codigo As String
    Public Property Codigo() As String
        Get
            Return _codigo
        End Get
        Set(ByVal value As String)
            _codigo = value
        End Set
    End Property

    Private _descripcion As String
    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

    Private _cantidad As Integer
    Public Property Cantidad() As Integer
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Integer)
            _cantidad = value
        End Set
    End Property

    Private _precio As Double
    Public Property Precio() As Double
        Get
            Return _precio
        End Get
        Set(ByVal value As Double)
            _precio = value
        End Set
    End Property

    Private _precioTotal As Double
    Public Property PrecioTotal() As Double
        Get
            Return _precioTotal
        End Get
        Set(ByVal value As Double)
            _precioTotal = value
        End Set
    End Property

    Sub New()

    End Sub

    Sub Imprimir()
        Console.WriteLine(Me._precioTotal)
    End Sub
End Class
