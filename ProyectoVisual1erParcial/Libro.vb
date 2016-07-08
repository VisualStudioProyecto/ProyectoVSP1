Imports System.Xml

Public Class Libro
    Private _titulo As String
    Public Property Titulo() As String
        Get
            Return _titulo
        End Get
        Set(ByVal value As String)
            _titulo = value
        End Set
    End Property

    Private _autor As String
    Public Property Autor() As String
        Get
            Return _autor
        End Get
        Set(ByVal value As String)
            _autor = value
        End Set
    End Property

    Private _isbn As String
    Public Property Isbn() As String
        Get
            Return _isbn
        End Get
        Set(ByVal value As String)
            _isbn = value
        End Set
    End Property

    Private _editorial As String
    Public Property Editorial() As String
        Get
            Return _editorial
        End Get
        Set(ByVal value As String)
            _editorial = value
        End Set
    End Property

    Private _genero As String
    Public Property Genero() As String
        Get
            Return _genero
        End Get
        Set(ByVal value As String)
            _genero = value
        End Set
    End Property

    Private _precioLibro As Double
    Public Property PrecioLibro() As Double
        Get
            Return _precioLibro
        End Get
        Set(ByVal value As Double)
            _precioLibro = value
        End Set
    End Property

    Sub New()

    End Sub

    Sub New(xmlLibro As XmlNode)

    End Sub

    Sub New(tituloLibro As String, autorLibro As String, isbnLibro As String, editorialLibro As String, generoLibro As String, valorLibro As Double)
        Me._titulo = tituloLibro
        Me._autor = autorLibro
        Me._isbn = isbnLibro
        Me._editorial = editorialLibro
        Me._genero = generoLibro
        Me._precioLibro = valorLibro
    End Sub
End Class
