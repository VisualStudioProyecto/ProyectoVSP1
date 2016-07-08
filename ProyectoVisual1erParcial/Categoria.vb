Imports System.Xml

Public Class Categoria
    Private _nombreCategoria As String
    Public Property NombreCategoria() As String
        Get
            Return _nombreCategoria
        End Get
        Set(ByVal value As String)
            _nombreCategoria = value
        End Set
    End Property

    Private _arrayListLibros As ArrayList
    Public Property ArrayListLibros() As ArrayList
        Get
            Return _arrayListLibros
        End Get
        Set(ByVal value As ArrayList)
            _arrayListLibros = value
        End Set
    End Property

    Sub New()

    End Sub

    Sub New(xmlLibro As XmlNode)

    End Sub

    Sub New(categoriaNombre As String, arrayLibros As ArrayList)
        Me._nombreCategoria = categoriaNombre
        Me._arrayListLibros = arrayLibros
    End Sub

    Sub ImprimirNombreCategoria()
        Console.WriteLine("Categoria:" & Me._nombreCategoria)
    End Sub
End Class
