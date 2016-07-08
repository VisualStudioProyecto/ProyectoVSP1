Public Class Administrador
    Private _usuarioAdministrador As String
    Public Property UsuarioAdministrador() As String
        Get
            Return _usuarioAdministrador
        End Get
        Set(ByVal value As String)
            _usuarioAdministrador = value
        End Set
    End Property

    Private _passwordAdministrador As String
    Public Property PasswordAdministrador() As String
        Get
            Return _passwordAdministrador
        End Get
        Set(ByVal value As String)
            _passwordAdministrador = value
        End Set
    End Property

    Sub New()

    End Sub

    Sub New(usuario As String, password As String)
        Me._usuarioAdministrador = usuario
        Me._passwordAdministrador = password
    End Sub

    Sub PantallaAdministradorPrincipal()
        Console.WriteLine(vbTab & "ADMINISTRADOR")
        Console.WriteLine("1.- Categorías")
        Console.WriteLine("2.- Artículos")
        Console.WriteLine("3.- Iva por Provincia")
        Console.WriteLine("4.- Tipo de Pago")
        Console.WriteLine("5.- Salir")
    End Sub

    Sub PantallaCategoria()
        Console.WriteLine(vbTab & "CATEGORIAS")
        Console.WriteLine("1.- Añadir Categoría")
        Console.WriteLine("2.- Modificar Categoría")
        Console.WriteLine("3.- Eliminar Categoría")
        Console.WriteLine("4.- Salir")
    End Sub

    Sub PantallaArticulo()
        Console.WriteLine(vbTab & "ARTICULOS")
        Console.WriteLine("1.- Añadir Artículo")
        Console.WriteLine("2.- Modificar Artículo")
        Console.WriteLine("3.- Eliminar Artículo")
        Console.WriteLine("4.- Salir")
    End Sub

    Sub IvaPorProvincia()
        Console.WriteLine("Provincia: Esmeraldas")
        Console.WriteLine("Iva: 12%")
        Console.WriteLine(vbNewLine)
        Console.WriteLine("Provincia: Manabi")
        Console.WriteLine("Iva: 12%")
        Console.WriteLine(vbNewLine)
        Console.WriteLine("Provincia: Resto de provincias del Ecuador")
        Console.WriteLine("Iva: 14%")
    End Sub

    Sub TipoDePago()
        Console.WriteLine("Pago: Tarjeta de Credito")
        Console.WriteLine("Devolución: 1%")
        Console.WriteLine(vbNewLine)
        Console.WriteLine("Pago: Dinero Electrónico")
        Console.WriteLine("Devolución: 4%")
        Console.WriteLine(vbNewLine)
        Console.WriteLine("Pago: Efectivo")
        Console.WriteLine("Devolución: 0%")
    End Sub
End Class
