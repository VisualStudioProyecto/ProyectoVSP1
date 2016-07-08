Imports System.Xml

Module Module1
    Dim trabajador As Vendedor = New Vendedor()
    Dim ad As Administrador = New Administrador()

    Dim xmlCategoria As XmlDocument = New XmlDocument
    Dim xmlLibro As XmlDocument = New XmlDocument

    Dim categLibros As Categoria
    Dim arrayListCategoriasLibros As ArrayList 'ArrayList que contendra todas las categorias
    Dim articuloLibreria As Libro 'Objeto usado como una variable auxiliar para guardar los datos en el arrayList quue contendra todos los libros
    Dim arrayAdministrador As ArrayList = New ArrayList() 'ArrayList que guardara todos los administradores
    Dim arrayVendedor As ArrayList = New ArrayList() 'ArrayList que guardara todos los vendedores
    Dim opcion As String
    Dim opcionMenu As String
    Dim usuario As String 'Variable que guardara el usuario
    Dim contrasenia As String 'Variable que guardara la contraseña

    'Rutas de los archivos XML
    Dim path As String = "F:\Programacion Visual\ProyectoVisual1erParcial\libreria.xml"
    Dim pathCategoria As String = "F:\Programacion Visual\ProyectoVisual1erParcial\categorias.xml"
    Dim pathUsuario As String = "F:\Programacion Visual\ProyectoVisual1erParcial\usuarios.xml"

    Sub Main()

        cargarCategorias(pathCategoria, categLibros, articuloLibreria, arrayListCategoriasLibros)
        Sistema()

        Console.ReadLine()
    End Sub

    Sub Sistema()
        Do
            TipoUsuario()
            opcion = Console.ReadLine
            Select Case opcion
                Case "1"
                    Console.Clear()
                    LoginAdministrador(usuario, contrasenia)
                    CargarAministradores(pathUsuario)
                    Do
                        Console.Clear()
                        ad.PantallaAdministradorPrincipal()
                        Console.WriteLine("Elija una opcion(numero): ")
                        opcionMenu = Console.ReadLine()
                        If Not (opcion >= "1" And opcion <= "5") Then
                            Console.WriteLine("Opción Incorrecta!!! Presione enter para elejir de nuevo")
                        End If
                    Loop Until opcion >= "1" And opcion <= "5"
                    Do
                        Console.Clear()
                        ad.PantallaCategoria()
                        Console.WriteLine("Elija una opcion(numero): ")
                        opcionMenu = Console.ReadLine()

                        Select Case opcion
                            Case "1"
                                Console.Clear()
                                ad.PantallaCategoria()
                                Console.WriteLine(vbNewLine)
                                Console.WriteLine("Elija una opcion(numero): ")
                                opcionMenu = Console.ReadLine()
                                Select Case opcion
                                    Case "1"
                                        Console.Clear()
                                        AñadirCategoria(opcion)
                                    Case "2"
                                        Console.Clear()
                                        ModificarCategoria(pathCategoria, opcion)
                                    Case "3"
                                        Console.Clear()
                                        EliminarCategoria(pathCategoria, opcion)
                                    Case "4"
                                        End
                                End Select
                            Case "2"
                                Console.Clear()
                                ad.PantallaArticulo()
                                Console.WriteLine(vbNewLine)
                                Console.WriteLine("Elija una opcion(numero): ")
                                opcionMenu = Console.ReadLine()
                                Select Case opcion
                                    Case "1"
                                        Console.Clear()
                                        AñadirLibro(pathCategoria, opcion)
                                    Case "2"
                                        Console.Clear()
                                        ModificarLibro(pathCategoria)
                                    Case "3"
                                        Console.Clear()
                                        EliminarLibro(pathCategoria, opcion)
                                    Case "4"
                                        End
                                End Select
                            Case "3"
                                Console.Clear()
                                ad.IvaPorProvincia()
                            Case "4"
                                Console.Clear()
                                ad.TipoDePago()
                            Case "5"
                                End
                        End Select

                    Loop Until opcion >= "1" And opcion <= "4"
                    

                Case "2"
                    LoginVendedor(usuario, contrasenia)
                    CargarVendedores(pathUsuario)
                Case "3"
                    End
                Case Else
                    Console.WriteLine("Opcion Incorrecta!!! Presione Enter")
                    Console.ReadLine()
            End Select
        Loop While opcion <> "3"
    End Sub

    Sub TipoUsuario()
        Console.WriteLine(vbTab & "TIPO DE USUARIO")
        Console.WriteLine("1.- Administrador")
        Console.WriteLine("2.- Vendedor")
        Console.WriteLine("3.- Salir")
        Console.WriteLine("Ingrese el tipo de usuario: ")
    End Sub

    Sub LoginVendedor(usuarioVendedor As String, contraseniaVendedor As String)
        Console.Clear()
        Console.WriteLine(vbTab & "LOGIN VENDEDOR")
        Console.WriteLine("Ingrese su usuario: ")
        usuarioVendedor = Console.ReadLine
        Console.WriteLine("Ingrese su contraseña: ")
        contraseniaVendedor = Console.ReadLine

    End Sub

    Sub LoginAdministrador(usuarioAdministrador As String, contraseniaAdministrador As String)
        Console.Clear()
        Console.WriteLine(vbTab & "LOGIN ADMINISTRADOR")
        Console.WriteLine("Ingrese su usuario: ")
        usuarioAdministrador = Console.ReadLine
        Console.WriteLine("Ingrese su contraseña: ")
        contraseniaAdministrador = Console.ReadLine
    End Sub

    Sub cargarCategorias(ruta As String, opcionCategoria As Categoria, opcionLibro As Libro, opcionArrayListCategorias As ArrayList)
        Dim xmlDocCategorias As XmlDocument = New XmlDocument
        xmlDocCategorias.Load(ruta)
        Dim categoriasLibreria As XmlNodeList = xmlDocCategorias.GetElementsByTagName("categorias")
        'Dim categoria As Categoria = New Categoria(categorias.Item(0))
        opcionLibro = New Libro()
        opcionArrayListCategorias = New ArrayList()
        For Each categorias As XmlNode In categoriasLibreria
            opcionCategoria = New Categoria()
            For Each categoriaLibro As XmlNode In categorias.ChildNodes
                opcionCategoria.NombreCategoria = categoriaLibro.Attributes(0).Value()
                For Each conjuntoLibros As XmlNode In categoriaLibro.ChildNodes
                    opcionCategoria.ArrayListLibros = New ArrayList()
                    For Each datosLibro As XmlNode In conjuntoLibros.ChildNodes
                        Select Case datosLibro.Name
                            Case "titulo"
                                opcionLibro.Titulo = datosLibro.InnerText
                            Case "autor"
                                opcionLibro.Autor = datosLibro.InnerText
                            Case "isbn"
                                opcionLibro.Isbn = datosLibro.InnerText
                            Case "editorial"
                                opcionLibro.Editorial = datosLibro.InnerText
                            Case "genero"
                                opcionLibro.Genero = datosLibro.InnerText
                            Case "precio"
                                opcionLibro.PrecioLibro = datosLibro.InnerText
                        End Select
                        opcionCategoria.ArrayListLibros.Add(opcionLibro)
                    Next
                Next
            Next
            opcionArrayListCategorias.Add(opcionCategoria)
        Next
    End Sub

    Sub CargarAministradores(path As String)
        Dim xmlDocUsuario As XmlDocument = New XmlDocument
        xmlDocUsuario.Load(path)
        Dim rol As XmlNodeList = xmlDocUsuario.GetElementsByTagName("administradores")
        Dim admin As Administrador = New Administrador()
        For Each administradores As XmlNode In rol
            For Each trabajo As XmlNode In administradores.ChildNodes
                For Each empleado As XmlNode In trabajo.ChildNodes
                    Select Case empleado.Name
                        Case "usuario"
                            admin.UsuarioAdministrador = empleado.InnerText
                        Case "password"
                            admin.PasswordAdministrador = empleado.InnerText
                    End Select
                    arrayAdministrador.Add(admin)
                Next
            Next
        Next

        For Each ad As Administrador In arrayAdministrador
            If ad.UsuarioAdministrador = usuario Then
                If ad.PasswordAdministrador = contrasenia Then
                    Console.WriteLine("Usuario Correcto")
                Else
                    Console.WriteLine("Usuario Incorrecto")
                End If
            End If
        Next

    End Sub

    Sub CargarVendedores(path As String)
        Dim xmlDocUsuario As XmlDocument = New XmlDocument
        xmlDocUsuario.Load(path)
        Dim rol As XmlNodeList = xmlDocUsuario.GetElementsByTagName("administradores")
        Dim vend As Vendedor = New Vendedor()
        For Each vendedores As XmlNode In rol
            For Each trabajo As XmlNode In vendedores.ChildNodes
                For Each empleado As XmlNode In trabajo.ChildNodes
                    Select Case empleado.Name
                        Case "usuario"
                            vend.UsuarioVendedor = empleado.InnerText
                        Case "password"
                            vend.PasswordVendedor = empleado.InnerText
                    End Select
                    arrayVendedor.Add(vend)
                Next
            Next
        Next

        For Each ad As Administrador In arrayAdministrador
            If ad.UsuarioAdministrador = usuario Then
                If ad.PasswordAdministrador = contrasenia Then
                    Console.WriteLine("Usuario Correcto")
                Else
                    Console.WriteLine("Usuario Incorrecto")
                End If
            End If
        Next

    End Sub

    'La finalidad de esta funcion es de añadir una categoria
    Sub AñadirCategoria(nombreCatg As String)
        Console.Clear()
        Dim addCategoria As XmlElement = xmlCategoria.CreateElement("categoria")
        Console.WriteLine(vbTab & "AÑADIR CATEGORIA")
        Console.WriteLine("Ingrese el nombre de su nueva categoria: ")
        nombreCatg = Console.ReadLine
        Dim nameCat As XmlAttribute = xmlCategoria.CreateAttribute("name")
        nameCat.Value = Console.ReadLine
        addCategoria.SetAttributeNode(nameCat)

        Dim nodo As XmlNode = xmlCategoria.DocumentElement
        nodo.InsertAfter(addCategoria, nodo.LastChild)
        xmlCategoria.Save(path)

    End Sub

    'La finalidad de esta funcion es de modificar una categoria
    Sub ModificarCategoria(ruta As String, nombreCatg As String)
        Console.Clear()
        Console.WriteLine(vbTab & "MODIFICAR CATEGORIA")
        ListarCategorias()
        Console.WriteLine("Elija el nombre de la categoria que desea modificar: ")
        Dim nombreCategoria As String = Console.ReadLine
        Console.WriteLine("Elija el nuevo nombre de la categoria: ")
        Dim nuevoNombreCategoria As String = Console.ReadLine

        Dim xmlDocCat As XmlDocument = New XmlDocument
        xmlDocCat.Load(ruta)
        Dim catModificar As XmlNodeList = xmlDocCat.GetElementsByTagName("categorias")

        For Each nodos As XmlNode In catModificar
            For Each nodoModificar As XmlNode In nodos.ChildNodes
                If nodoModificar.Attributes(0).Value = nombreCategoria Then
                    Dim nodoNuevo As XmlElement
                    nodoNuevo = xmlCategoria.CreateElement("categoria")
                    Dim nombre As XmlAttribute = xmlCategoria.CreateAttribute("Name")
                    nombre.Attributes(0).Value = nuevoNombreCategoria
                    nodoNuevo.SetAttributeNode(nombre)
                    nodoModificar.ReplaceChild(nodoNuevo, nodoModificar)

                End If
            Next
        Next
        xmlCategoria.Save(ruta)
        Console.WriteLine("La categoria ha sido modificada")
        Console.ReadLine()

    End Sub

    'La finalidad de esta funcion es de eliminar una categoria
    Sub EliminarCategoria(ruta As String, nombreCatg As String)
        Console.Clear()
        Dim eliminarcategoria As XmlNodeList = xmlCategoria.GetElementsByTagName("categoria")
        Console.WriteLine(vbTab & "ELIMINAR CATEGORIA")
        ListarCategorias()
        Console.WriteLine("Ingrese la categoria a eliminar: ")
        nombreCatg = Console.ReadLine
        For Each categoria As XmlNode In eliminarcategoria
            If categoria.Value = nombreCatg Then
                categoria.RemoveAll()
            End If
        Next

        xmlCategoria.Save(ruta)
        Console.WriteLine("Se ha eliminado la categoria: " & nombreCatg)
        Console.ReadLine()
    End Sub

    'La finalidad de esta funcion es de añadir un libro
    Sub AñadirLibro(ruta As String, nombreCatg As String)
        Console.Clear()
        Console.WriteLine(vbTab & "AÑADIR LIBRO")
        Console.WriteLine(vbNewLine)
        Console.WriteLine("Ingrese el nombre de la categoria que pertenecera el libro: ")
        Dim categoriaExistente As String = Console.ReadLine

        Dim addLibro As XmlElement = xmlLibro.CreateElement("libro")

        Console.WriteLine("Ingrese el titulo del libro: ")
        Dim tituloLibroNuevo As XmlElement = xmlLibro.CreateElement("titulo")
        tituloLibroNuevo.InnerText = Console.ReadLine
        addLibro.AppendChild(tituloLibroNuevo)

        Console.WriteLine("Ingrese el autor del libro: ")
        Dim autorLibroNuevo As XmlElement = xmlLibro.CreateElement("autor")
        autorLibroNuevo.InnerText = Console.ReadLine
        addLibro.AppendChild(autorLibroNuevo)

        Console.WriteLine("Ingrese el ISBN del libro: ")
        Dim isbnLibroNuevo As XmlElement = xmlLibro.CreateElement("isbn")
        isbnLibroNuevo.InnerText = Console.ReadLine
        addLibro.AppendChild(isbnLibroNuevo)

        Console.WriteLine("Ingrese el editorial del libro: ")
        Dim editorialLibroNuevo As XmlElement = xmlLibro.CreateElement("editorial")
        editorialLibroNuevo.InnerText = Console.ReadLine
        addLibro.AppendChild(tituloLibroNuevo)

        Console.WriteLine("Ingrese el genero del libro: ")
        Dim generoLibroNuevo As XmlElement = xmlLibro.CreateElement("genero")
        generoLibroNuevo.InnerText = Console.ReadLine
        addLibro.AppendChild(generoLibroNuevo)

        Console.WriteLine("Ingrese el precio del libro: ")
        Dim precioLibroNuevo As XmlElement = xmlLibro.CreateElement("precio")
        precioLibroNuevo.InnerText = Console.ReadLine
        addLibro.AppendChild(precioLibroNuevo)

        'Confirmacion de categoria y adicion de libro
        xmlCategoria.Load(ruta)
        Dim categorias As XmlNodeList = xmlCategoria.GetElementsByTagName("categorias")

        For Each catgrs As XmlNode In categorias
            For Each elementoCategoria As XmlNode In catgrs.ChildNodes

                If categoriaExistente = elementoCategoria.Attributes(0).Value Then
                    Dim conjuntoLibro As XmlNode = elementoCategoria.ChildNodes(1)
                    Dim addLibroNodo As XmlNode = xmlLibro.DocumentElement
                    addLibroNodo.InsertAfter(addLibro, addLibroNodo.LastChild)
                    xmlLibro.Save(ruta)
                End If
            Next
        Next

    End Sub

    'La finalidad de esta funcion es de modificar un libro
    Sub ModificarLibro(ruta As String)
        Console.Clear()
        ListarLibros()
        Console.WriteLine("Ingrese el titulo del libro a modificar: ")
        Dim nombLibro As String = Console.ReadLine
        Console.WriteLine(vbNewLine)
        Console.WriteLine(vbTab & "MODIFICAR LIBRO")
        Do
            Console.WriteLine(vbNewLine)
            Console.WriteLine("Opciones a editar del libro")
            Console.WriteLine("1.- Título")
            Console.WriteLine("2.- Autor")
            Console.WriteLine("3.- ISBN")
            Console.WriteLine("4.- Editorial")
            Console.WriteLine("5.- Genero")
            Console.WriteLine("6.- Precio")
            Console.WriteLine("7.- Volver")

            Console.WriteLine(vbNewLine)
            Console.WriteLine("Elija una opcion(numero): ")
            opcion = Console.ReadLine()

            If Not (opcion >= "1" And opcion <= "7") Then
                Console.WriteLine("Opción Incorrecta!!! Presione enter para elejir de nuevo")
            End If
        Loop Until opcion >= "1" And opcion <= "7"

        Console.WriteLine(vbNewLine)
        Console.WriteLine("Ingrese el nuevo contenido de la opcion: ")
        Dim contenido As String = Console.ReadLine()

        Dim xmlDocCat As XmlDocument = New XmlDocument
        xmlDocCat.Load(ruta)
        Dim libroLista As XmlNodeList = xmlDocCat.GetElementsByTagName("libro")
        For Each libroNode As XmlNode In libroLista
            For Each libroDato As XmlNode In libroNode.ChildNodes
                If libroDato.Name = "titulo" Then
                    If libroDato.InnerText = nombLibro Then
                        Select Case opcion
                            Case "1"
                                CambiarNodo(libroNode, "titulo", contenido)
                            Case "2"
                                CambiarNodo(libroNode, "autor", contenido)
                            Case "3"
                                CambiarNodo(libroNode, "isbn", contenido)
                            Case "4"
                                CambiarNodo(libroNode, "editorial", contenido)
                            Case "5"
                                CambiarNodo(libroNode, "genero", contenido)
                            Case "6"
                                CambiarNodo(libroNode, "precio", contenido)
                            Case "7"


                        End Select
                    End If
                End If
            Next
        Next
        xmlCategoria.Save(ruta)
        Console.WriteLine("Se ha editado correctamente")
        Console.ReadLine()
    End Sub

    'La finalidad de esta funcion es de eliminar un libro
    Sub EliminarLibro(ruta As String, nombreCatg As String)
        Console.Clear()
        Dim eliminarLibro As XmlNodeList = xmlCategoria.GetElementsByTagName("libro")
        Console.WriteLine(vbTab & "ELIMINAR LIBRO")
        ListarLibros()
        Console.WriteLine("Ingrese el titulo del libro a eliminar: ")
        nombreCatg = Console.ReadLine
        For Each libroEliminado As XmlNode In eliminarLibro
            If libroEliminado.Value = nombreCatg Then
                libroEliminado.RemoveAll()
            End If
        Next
        xmlCategoria.Save(ruta)
        Console.WriteLine("Se ha eliminado el libro: " & nombreCatg)
        Console.ReadLine()
    End Sub

    'La finalidad de esta funcion es de presentar una lista con todos los libros
    Sub ListarLibros()
        Console.WriteLine(vbNewLine)
        Console.WriteLine(vbTab & "LISTA DE CATEGORIAS")
        Dim xmlDocCategorias As XmlDocument = New XmlDocument
        xmlDocCategorias.Load(pathCategoria)
        Dim categoriasLibreria As XmlNodeList = xmlDocCategorias.GetElementsByTagName("categorias")
        For Each categorias As XmlNode In categoriasLibreria
            For Each categoriaLibro As XmlNode In categorias.ChildNodes
                For Each conjuntoLibros As XmlNode In categoriaLibro.ChildNodes
                    For Each datosLibro As XmlNode In conjuntoLibros.ChildNodes
                        Select Case datosLibro.Name
                            Case "titulo"
                                Console.WriteLine("Titulo:" & datosLibro.InnerText)
                        End Select
                    Next
                Next
            Next
        Next
        Console.WriteLine(vbNewLine)
    End Sub

    'La finalidad de esta funcion es de presentar una lista con todas las categorias
    Sub ListarCategorias()
        Console.WriteLine(vbNewLine)
        Console.WriteLine(vbTab & "LISTAR CATEGORIAS")
        Dim xmlDocCategorias As XmlDocument = New XmlDocument
        xmlDocCategorias.Load(pathCategoria)
        Dim categoriasLibreria As XmlNodeList = xmlDocCategorias.GetElementsByTagName("categorias")
        For Each categorias As XmlNode In categoriasLibreria
            For Each categoriaLibro As XmlNode In categorias.ChildNodes
                Console.WriteLine("Categoria: " & categoriaLibro.Attributes(0).Value())
            Next
        Next
        Console.WriteLine(vbNewLine)
    End Sub

    'Su funcion es cambiar el nodo antiguo por el nuevo nodo
    Sub CambiarNodo(nodo As XmlNode, opcionElejida As String, nuevoNombre As String)
        Dim nodoNew As XmlElement
        For Each videoHijo In nodo.ChildNodes
            If videoHijo.Name = opcionElejida Then
                nodoNew = xmlCategoria.CreateElement(opcionElejida)
                nodoNew.InnerText = nuevoNombre
                nodo.ReplaceChild(nodoNew, videoHijo)
            End If
        Next
    End Sub
End Module
