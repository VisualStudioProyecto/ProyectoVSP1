Public Class Vendedor
    Private _usuarioVendedor As String
    Public Property UsuarioVendedor() As String
        Get
            Return _usuarioVendedor
        End Get
        Set(ByVal value As String)
            _usuarioVendedor = value
        End Set
    End Property

    Private _passwordVendedor As String
    Public Property PasswordVendedor() As String
        Get
            Return _passwordVendedor
        End Get
        Set(ByVal value As String)
            _passwordVendedor = value
        End Set
    End Property

    Sub New()

    End Sub

    Sub New(usuario As String, password As String)
        Me._usuarioVendedor = usuario
        Me._passwordVendedor = password
    End Sub

    Sub PantallaVendedor()
        Console.WriteLine(vbTab & "VENDEDOR")
        Console.WriteLine("1.- Crear Factura")
        Console.WriteLine("2.- Imprimir Factura")
        Console.WriteLine("3.- Salir")
    End Sub
End Class
