Imports System.Xml

Module Module1

    'Dim route As String = "C:\Users\Baque_Leon\Desktop\ProyectoVisual1erParcial\"
    'Dim path As String = route + "libreria.xml"
    'Dim pathCategoria As String = route + "categorias.xml"
    'Dim pathUsuario As String = route + "usuarios.xml"

    ' Ojo, estas rutas yo las puse porque cambian en cada PC que se trabaje.
    ' No olvides volver a poner las tuyas para que puedas probar (las dejé como comentarios arriba).
    ' P.D.: Te las abrevié un poco, pero no te preocupes que sí funcionan.
    Dim route As String = "C:\Users\ESTUDIANTE\Desktop\Sustentacion\mbaque\"
    Dim path As String = route + "libreria.xml"
    Dim pathCategoria As String = route + "categorias.xml"
    Dim pathUsuario As String = route + "usuarios.xml"
    Dim arregloDetalle As ArrayList = New ArrayList
    Dim arregloDetalle2 As ArrayList = New ArrayList


    Dim xmlDoc As XmlDocument = New XmlDocument
    Dim libreria As XmlNodeList
    Dim libra As XmlDocument
    Dim factura As Factura = New Factura
    Dim xmlDocCategorias As XmlDocument
    Dim categorias As XmlNodeList
    'Dim categoria As Categoria
    Dim opcionProvincvia As Integer
    Dim opcionFormaPago As Integer
    Dim nombreLibro As String

    Dim facturaNum As Integer
    Dim razonSocialImp As String
    Dim direcEmpImp As String
    Dim rucEmpImp As String
    Dim provImp As String

    Dim nomLibro As String
    Dim codigoISBN As String
    Dim valor As Double
    Dim pagaIva As Integer


    Dim nombreCilente As String
    Dim rucCliente As String
    Dim fechaCliente As String
    Dim direccionCliente As String
    Dim cantidadCliente As Integer  ' = -1
    Dim x As String
    Dim precioTotalImp As Double
    Dim subtotal As Double
    Dim formaPago As Double
    Dim iva As Double = 0.14
    Dim ivaTotal As Double
    Dim tipoPago As String
    Dim totalPagar As Double
    Dim devolucionImp As Double
    Dim provincia As String
    Dim salirrr As Boolean = True
    Dim nada As String
    Dim opcionPrincipal As Integer
    Dim opcionVendedor As Integer
    Dim fac As Factura

    'Tema 2: Agregar una propiedad a los artículos para saber si paga IVA o no y considerarlo para la factura. Si en el XML no 
    '    tiene ese campo, entonces tome por defecto que si paga IVA. Modificar algunos productos del XML para probar la 
    '    funcionalidad.

    Sub Main()

        xmlDoc.Load(path)
        libreria = xmlDoc.GetElementsByTagName("facturas") 'Dim libreria As

        xmlDocCategorias = New XmlDocument
        xmlDocCategorias.Load(pathCategoria)

        libra = New XmlDocument
        libra.Load(path) '                                                                           LIBRA

        factura = New Factura(libreria.Item(0))

        Vendedor()

        nada = Console.ReadLine

        Console.ReadLine()
    End Sub

    Sub busacarFactNum(numFactura As Integer) 'CASI ULTIMA 
        Console.Clear()
        Dim nodoFactura1 As XmlNodeList = libra.GetElementsByTagName("factura")
        Dim facturaNumB As Integer
        Dim razonSocialB As String
        Dim rucB As String
        Dim direccionB As String
        Dim telefonoB As String
        Dim provinciaB As String
        Dim clienteB As String
        Dim rucClienteB As String
        Dim direccionClienteB As String
        Dim tipoPagoB As String
        Dim fechaB As String
        Dim codigoB As String
        Dim descripcionB As String
        Dim cantidadB As Integer
        Dim precioB As Double
        Dim precioTotalB As Double
        Dim subtotalB As Double
        Dim ivaB As Double
        Dim totalPagarB As Double
        Dim devolucionB As Double
        Dim flag As Boolean = False
        numFactura = CInt(numFactura)
        For Each factura As XmlNode In nodoFactura1
            For Each nodoFactura As XmlNode In factura.ChildNodes
                Select Case nodoFactura.Name
                    Case "facturaNum"
                        facturaNumB = CInt(nodoFactura.InnerText)
                    Case "razonSocial"
                        razonSocialB = nodoFactura.InnerText
                    Case "ruc"
                        rucB = nodoFactura.InnerText
                    Case "direccion"
                        direccionB = nodoFactura.InnerText
                    Case "ruc"
                        telefonoB = nodoFactura.InnerText
                    Case "provincia"
                        provinciaB = nodoFactura.InnerText
                    Case "encabezadoFactura"
                        For Each nodoEncabezadoFactura As XmlNode In nodoFactura.ChildNodes
                            Select Case nodoEncabezadoFactura.Name
                                Case "cliente"
                                    clienteB = nodoEncabezadoFactura.InnerText
                                Case "rucCliente"
                                    rucClienteB = nodoEncabezadoFactura.InnerText
                                Case "direccionCliente"
                                    direccionClienteB = nodoEncabezadoFactura.InnerText
                            End Select
                        Next

                    Case "tipoPago"
                        tipoPagoB = nodoFactura.InnerText
                    Case "fecha"
                        fechaB = nodoFactura.InnerText
                    Case "detalles"
                        For Each detalleFactura As XmlNode In nodoFactura.ChildNodes
                            For Each nodoDetalleFactura As XmlNode In detalleFactura.ChildNodes
                                Select Case nodoDetalleFactura.Name
                                    Case "codigo"
                                        codigoB = nodoDetalleFactura.InnerText
                                    Case "descripcion"
                                        descripcionB = nodoDetalleFactura.InnerText
                                    Case "cantidad"
                                        cantidadB = CInt(nodoDetalleFactura.InnerText)
                                    Case "precio"
                                        precioB = CDbl(nodoDetalleFactura.InnerText)
                                    Case "precioTotal"
                                        precioTotalB = CDbl(nodoDetalleFactura.InnerText)
                                End Select
                            Next

                        Next
                    Case "subtotal"
                        subtotalB = CDbl(nodoFactura.InnerText)
                    Case "iva"
                        ivaB = CDbl(nodoFactura.InnerText)
                    Case "totalPagar"
                        totalPagarB = CDbl(nodoFactura.InnerText)
                    Case "devolucion"
                        devolucionB = CDbl(nodoFactura.InnerText)
                End Select
            Next
            If facturaNumB = numFactura Then
                Console.WriteLine("                                      BUSQUEDA DE FACTURA ")
                Console.WriteLine("Num. Factura: " & facturaNumB)
                Console.WriteLine("Razon socila: " & razonSocialB & vbTab & vbTab & "ruc: " & rucB)
                Console.WriteLine("Direccion: " & direccionB)
                Console.WriteLine("Provincia: " & provinciaB)
                Console.WriteLine("Cliente: " & clienteB & vbTab & vbTab & vbTab & "ruc: " & rucClienteB)
                Console.WriteLine("Tipo de pago: " & tipoPagoB)
                Console.WriteLine("Cant." & vbTab & "Codigo" & vbTab & vbTab & vbTab & "Descripcion") '& vbTab & vbTab & "Precio" & vbTab & "Precio Total"
                Console.WriteLine(cantidadB & vbTab & codigoB & vbTab & descripcionB) ' & vbTab & valor & vbTab & precioTotalImp
                Console.WriteLine("Precio" & vbTab & "Precio Total")
                Console.WriteLine(precioB & vbTab & precioTotalB)
                Console.WriteLine("Subtotal: " & subtotalB)
                Console.WriteLine("iva: " & ivaB)
                Console.WriteLine("Total a pagar: " & totalPagarB)
                Console.WriteLine("Devolucion: " & devolucionB)
                Console.ReadLine()
                flag = True
                Exit For
            End If
        Next

        If flag = False Then
            Console.WriteLine("El numero de la factura no existe. Ingrese nuevamente el numero")
            opcion2BuscarFactNum()
            nada = Console.ReadLine

            'Console.ReadLine()
        End If

    End Sub

    Sub ListarCategoriasTitulo(busquedaLibro As String)

        Dim tituloL As String
        Dim autorL As String
        Dim isbnL As String
        Dim editorialL As String
        Dim generoL As String
        Dim precioL As Double

        Dim listaCategorias As XmlNodeList = xmlDocCategorias.GetElementsByTagName("categoria")
        Dim flag As Boolean = False
        For Each categoria As XmlNode In listaCategorias
            For Each libro As XmlNode In categoria.ChildNodes
                For Each atributo As XmlNode In libro.ChildNodes
                    Select Case atributo.Name
                        Case "titulo"
                            tituloL = atributo.InnerText
                        Case "autor"
                            autorL = atributo.InnerText
                        Case "isbn"
                            isbnL = atributo.InnerText
                        Case "editorial"
                            editorialL = atributo.InnerText
                        Case "genero"
                            generoL = atributo.InnerText
                        Case "precio"
                            precioL = atributo.InnerText
                    End Select
                Next
                If tituloL = busquedaLibro Then
                    Console.WriteLine("                    BUSQUEDA DE CATEGORIAS POR LIBRO ")
                    Console.WriteLine("Ttulo: " & tituloL)
                    Console.WriteLine("Autor: " & autorL)
                    Console.WriteLine("ISBN: " & isbnL)
                    Console.WriteLine("Editorial: " & editorialL)
                    Console.WriteLine("Genero: " & generoL)
                    Console.WriteLine("Precio: " & precioL)
                    flag = True
                    Exit For
                End If
            Next
            If flag = True Then
                Exit For
            End If
        Next
        If flag = False Then
            Console.Clear()

            Console.WriteLine("El libro no existe. Ingrese nuevamente el titulo")
            opcionBuscarTitulo()
            nada = Console.ReadLine

        End If
    End Sub


    Sub ComprovarLibro(nombreLibro As String)
        facturaNum = CInt(factura.NumeroFactura)
        facturaNum = facturaNum + 1
        Dim listaCategorias As XmlNodeList = xmlDocCategorias.GetElementsByTagName("categoria")
        Dim flag As Boolean = False
        For Each categoria As XmlNode In listaCategorias
            For Each libro As XmlNode In categoria.ChildNodes
                For Each atributo As XmlNode In libro.ChildNodes
                    Select Case atributo.Name
                        Case "titulo"
                            nomLibro = atributo.InnerText
                        Case "isbn"
                            codigoISBN = atributo.InnerText
                        Case "precio"
                            valor = atributo.InnerText
                        Case "pagaIva"
                            pagaIva = atributo.InnerText
                    End Select
                Next



                If nomLibro = nombreLibro Then



                    If (provincia = "Esmeraldas" Or provincia = "Manabi" Or provincia = "esmeraldas" Or provincia = "manabi") Then 'en caso de mal ingreso
                        iva = 0.12

                        iva = VerificarSiPagaIva(pagaIva)
                        If opcionPrincipal = "1" Then
                            formaPago = 0.01
                            tipoPago = "Targeta de Credito"
                        ElseIf opcionPrincipal = "2" Then
                            formaPago = 0.00
                            tipoPago = "Dinero Efectivo"
                        ElseIf opcionPrincipal = "3" Then
                            formaPago = 0.04
                            tipoPago = "Dinero Electronico"
                        End If
                        Guardar(iva, formaPago, tipoPago)

                    Else

                        iva = 0.14
                        iva = VerificarSiPagaIva(pagaIva)
                        If opcionPrincipal = "1" Then
                                formaPago = 0.01
                                tipoPago = "Targeta de Credito"
                            ElseIf opcionPrincipal = "2" Then
                                formaPago = 0.00
                                tipoPago = "Dinero Efectivo"
                            ElseIf opcionPrincipal = "3" Then
                                formaPago = 0.04
                                tipoPago = "Dinero Electronico"
                            End If
                            Guardar(iva, formaPago, tipoPago)

                        End If

                        flag = True
                        Exit For
                    End If
            Next
            If flag = True Then
                Exit For
            End If
        Next
        If flag = False Then
            Console.WriteLine("El libro no existe. Ingrese nuevamente el titulo")
            nada = Console.ReadLine

            IngresoDatosCompra()
            Console.ReadLine()
        End If
    End Sub

    Function VerificarSiPagaIva(pagaIva As Integer)
        If (pagaIva = 0) Then

            iva = 0
        End If
        Return iva
    End Function

    Sub IngresoDatosCliente()
        Console.WriteLine("Ingrese el nombre y apellido del cliente: ")
        nombreCilente = Console.ReadLine
        Console.WriteLine("Ingrese el ruc o cedula del cliente: ")
        rucCliente = Console.ReadLine
        Console.WriteLine("Ingrese la fecha del dia (dd/mm/yyyy): ")
        fechaCliente = Console.ReadLine
        Console.WriteLine("Ingrese la direccion del cliente: ")
        direccionCliente = Console.ReadLine
        Console.WriteLine("Ingrese la provincia en que se a realizado la compra: ")
        provincia = Console.ReadLine
        IngresoDatosCompra()

        'Console.WriteLine("Desea seguir comprando? s/n")
        'boo = Console.ReadLine
        'masDatos(boo)
        'Console.Clear()
    End Sub

    Sub IngresoDatosCompra()

        Console.Clear()
        Console.WriteLine("Ingrese el titulo del libro a comprar: ")
        nombreLibro = Console.ReadLine

        Do
            Console.WriteLine("Ingrese la cantidad del tipo de producto a llevar (no mas de 10): ")
            x = Console.ReadLine()

            Try
                cantidadCliente = Integer.Parse(x)

            Catch ex As Exception
            End Try

            ComprovarLibro(nombreLibro)
        Loop Until Not (cantidadCliente <= 1 Or cantidadCliente >= 10) 'And Not numf = " "


    End Sub

    Function FormaPagos() As Double
        Console.Clear()
        Do
            opcionPrincipal = MenuFormaPago()
            Select Case opcionPrincipal
                Case "1" 'TARJETA DE CREDITO
                    Console.Clear()
                    IngresoDatosCliente()
                    'Console.ReadLine()
                    End
                Case "2" 'EFECTIVO
                    Console.Clear()
                    IngresoDatosCliente()
                    End
                Case "3" 'DINERO ELECTRONICO
                    Console.Clear()
                    IngresoDatosCliente()
                    End
                Case "4" 'ATRAS 
                    Console.WriteLine("***GRACIAS POR SU VISITA")
                    Console.ReadLine()
                    End
                Case Else
                    Console.WriteLine("Opción incorrecta. Presione enter para volver a ingresar")
                    Console.ReadLine()
            End Select

        Loop While opcionFormaPago <> 4
        Return formaPago
    End Function

    Function MenuFormaPago()
        Dim opcionElegida As Integer = -1
        Dim entrada As String
        Do
            Console.Clear()
            Console.WriteLine(vbTab & "MENU FORMA DE PAGO")
            Console.WriteLine("Elija su rol")
            Console.WriteLine("1. Tarjeta de credito")
            Console.WriteLine("2. Dindero Efectivo")
            Console.WriteLine("3. Dinero Electronico")
            Console.WriteLine("4. Atras")
            Console.WriteLine("Elija su opcion: ")
            entrada = Console.ReadLine()
            Try
                opcionElegida = Integer.Parse(entrada)
            Catch ex As Exception

            End Try
            If Not (opcionElegida >= 1 And opcionElegida <= 4) Then 'en caso de mal ingreso
                Console.WriteLine("Opción incorrecta. Presione enter para volver a ingresar")
                Console.ReadLine()
            End If
        Loop Until opcionElegida >= 1 And opcionElegida <= 4
        Return opcionElegida
    End Function

    Function MenuVendedor()
        Dim opcionElegida As Integer = -1
        Dim entrada As String
        Do
            Console.Clear()
            Console.WriteLine(vbTab & "MENU FORMA DE PAGO")
            Console.WriteLine("Elija su rol")
            Console.WriteLine("1. Imprimir factura")
            Console.WriteLine("2. Bucar factura por numero")
            Console.WriteLine("3. Buscar libro por titulo")
            Console.WriteLine("4. Crear Factura")

            Console.WriteLine("Elija su opcion: ")
            entrada = Console.ReadLine()
            Try
                opcionElegida = Integer.Parse(entrada)
            Catch ex As Exception

            End Try
            If Not (opcionElegida >= 1 And opcionElegida <= 4) Then 'en caso de mal ingreso
                Console.WriteLine("Opción incorrecta. Presione enter para volver a ingresar")
                Console.ReadLine()
            End If
        Loop Until opcionElegida >= 1 And opcionElegida <= 4
        Return opcionElegida
    End Function

    Sub Vendedor()



        Console.Clear()
        Do
            opcionVendedor = MenuVendedor()
            Select Case opcionVendedor
                Case "1" 'IMPRIMIR FACTURA
                    Console.Clear()
                    salir()
                    nada = Console.ReadLine

                    'Console.ReadLine()
                Case "2" 'BUSCAR FACTURA POR NUMERO
                    Console.Clear()

                    opcion2BuscarFactNum()
                    nada = Console.ReadLine
                    Console.ReadLine()

                Case "3" 'Buscar libro por titulo
                    Console.Clear()

                    opcionBuscarTitulo()

                    nada = Console.ReadLine
                    Console.ReadLine()

                Case "4" 'INICIO

                    Console.Clear()
                    FormaPagos()
                    End
                Case Else
                    Console.WriteLine("Opción incorrecta. Presione enter para volver a ingresar")
                    Console.ReadLine()
            End Select
        Loop While opcionFormaPago <> 4
    End Sub

    Private Sub opcionBuscarTitulo()
         Dim busquedaLibro As String = ""
        Console.WriteLine("Ingrese el titulo del libro a que desea buscar: ")
        busquedaLibro = Console.ReadLine
        ListarCategoriasTitulo(busquedaLibro)
    End Sub

    Private Sub opcion2BuscarFactNum()
        Dim numFactura As String
        Dim numf As Integer
        Do
            Console.WriteLine("Ingrese el numero de la factura que desea buscar: ")
            numFactura = Console.ReadLine
            Try
                numf = Integer.Parse(numFactura)
                'numf = CInt(numFactura)

            Catch ex As Exception
            End Try
            busacarFactNum(numf)
            'If Not (numf >= 1 And numf <= 100) Then 'en caso de mal ingreso
            '    Console.WriteLine("Opción incorrecta. Presione enter para volver a ingresar")
            '    'Console.ReadLine()
            'End If

        Loop Until Not (numf >= 1 And numf <= 100) 'And Not numf = " "
    End Sub

    Sub masDatos(boo)
        Do
            Console.Clear()
            If Not (boo = "n" Or boo = "N" Or boo = "s" Or boo = "S") Then 'en caso de mal ingreso
                Console.WriteLine("Opción incorrecta. Presione enter para volver a ingresar")
                Console.WriteLine("Desea seguir comprando? s/n")
                boo = Console.ReadLine
            End If
            If (boo = "s" Or boo = "S") Then
                IngresoDatosCompra()
                Console.WriteLine("Desea seguir comprando? s/n")
                boo = Console.ReadLine

            End If
            If boo = "n" Or boo = "N" Then
                End
            End If
        Loop While (boo = "s" Or boo = "S") Or (Not (boo = "n" Or boo = "N" Or boo = "s" Or boo = "S"))
    End Sub

    Sub salir()
        Console.Clear()

        Console.WriteLine(vbTab & vbTab & vbTab & "FACTURA")
        factura.ImprimirFactura() '                                              AQUI
        Console.WriteLine("GRACIAS")
        nada = Console.ReadLine
        End

    End Sub

    Private Sub Guardar(iva As Double, formaPago As Double, tipoPago As String)
        Dim facturaG As XmlElement = xmlDoc.CreateElement("factura")
        Dim numFactura As Integer
        numFactura += factura.NumeroFactura 'Me._numeroFactura
        Dim facturaNumG As XmlElement = xmlDoc.CreateElement("facturaNum")
        facturaNumG.InnerText = facturaNum

        facturaG.AppendChild(facturaNumG)
        Dim razonSocialG As XmlElement = xmlDoc.CreateElement("razonSocial")
        razonSocialG.InnerText = "LibriMundi"
        razonSocialImp = "LibriMundi"
        facturaG.AppendChild(razonSocialG)
        Dim rucG As XmlElement = xmlDoc.CreateElement("ruc")
        rucG.InnerText = "1791397339001"
        rucEmpImp = "1791397339001"
        facturaG.AppendChild(rucG)
        Dim direccionG As XmlElement = xmlDoc.CreateElement("direccion")
        direccionG.InnerText = "Av. Francisco de Orellana s/n y Av. Plaza Dañin"
        direcEmpImp = "Av. Francisco de Orellana s/n y Av. Plaza Dañin"
        facturaG.AppendChild(direccionG)
        Dim telefonoG As XmlElement = xmlDoc.CreateElement("telefono")
        telefonoG.InnerText = "2083202"
        facturaG.AppendChild(telefonoG)

        Dim provinciaG As XmlElement = xmlDoc.CreateElement("provincia")
        provinciaG.InnerText = provincia
        provImp = provincia
        facturaG.AppendChild(provinciaG)

        Dim encabezadoFacturaG As XmlElement = xmlDoc.CreateElement("encabezadoFactura")
        Dim clienteG As XmlElement = xmlDoc.CreateElement("cliente")
        clienteG.InnerText = nombreCilente
        encabezadoFacturaG.AppendChild(clienteG)
        Dim rucClienteG As XmlElement = xmlDoc.CreateElement("rucCliente")
        rucClienteG.InnerText = rucCliente
        encabezadoFacturaG.AppendChild(rucClienteG)
        Dim direccionClienteG As XmlElement = xmlDoc.CreateElement("direccionCliente")
        direccionClienteG.InnerText = direccionCliente
        encabezadoFacturaG.AppendChild(direccionClienteG)
        facturaG.AppendChild(encabezadoFacturaG)

        Dim tipoPagoG As XmlElement = xmlDoc.CreateElement("tipoPago")
        'tipoPago = FormaPagos()
        tipoPagoG.InnerText = tipoPago
        facturaG.AppendChild(tipoPagoG)
        Dim fechaG As XmlElement = xmlDoc.CreateElement("fecha")
        fechaG.InnerText = fechaCliente
        facturaG.AppendChild(fechaG)

        Dim detallesG As XmlElement = xmlDoc.CreateElement("detalles")
        Dim detalleFacturaG As XmlElement = xmlDoc.CreateElement("detalleFactura")
        Dim codigoG As XmlElement = xmlDoc.CreateElement("codigo")
        codigoG.InnerText = codigoISBN
        detalleFacturaG.AppendChild(codigoG)
        Dim descripcionG As XmlElement = xmlDoc.CreateElement("descripcion")
        descripcionG.InnerText = nomLibro
        detalleFacturaG.AppendChild(descripcionG)
        Dim cantidadG As XmlElement = xmlDoc.CreateElement("cantidad")
        cantidadG.InnerText = CStr(cantidadCliente)
        detalleFacturaG.AppendChild(cantidadG)
        Dim precioG As XmlElement = xmlDoc.CreateElement("precio")
        precioG.InnerText = CStr(valor)
        detalleFacturaG.AppendChild(precioG)
        Dim precioTotalG As XmlElement = xmlDoc.CreateElement("precioTotal")
        precioTotalImp = valor * cantidadCliente
        precioTotalG.InnerText = CStr(precioTotalImp)
        detalleFacturaG.AppendChild(precioTotalG)
        detallesG.AppendChild(detalleFacturaG)
        facturaG.AppendChild(detallesG)

        Dim subtotalG As XmlElement = xmlDoc.CreateElement("subtotal")
        subtotal = valor * cantidadCliente
        subtotalG.InnerText = CStr(subtotal)
        facturaG.AppendChild(subtotalG)
        Dim ivaG As XmlElement = xmlDoc.CreateElement("iva")
        ivaG.InnerText = CStr(iva)
        ivaTotal = subtotal * iva
        facturaG.AppendChild(ivaG)
        Dim totalPagarG As XmlElement = xmlDoc.CreateElement("totalPagar")
        totalPagar = ivaTotal + subtotal
        totalPagarG.InnerText = CStr(totalPagar)
        facturaG.AppendChild(totalPagarG)
        Dim devolucionG As XmlElement = xmlDoc.CreateElement("devolucion")
        devolucionImp = totalPagar * formaPago
        devolucionG.InnerText = CStr(devolucionImp)
        facturaG.AppendChild(devolucionG)
        'Dim pagaIvaG As XmlElement = xmlDoc.CreateElement("pagaIva")
        'pagaIvaG.InnerText = ""
        'facturaG.AppendChild(pagaIvaG)
        Guardar(facturaG)
    End Sub

    Private Sub Guardar(facturaG As XmlElement)
        Dim nodoRaiz As XmlNode = xmlDoc.DocumentElement
        nodoRaiz.InsertAfter(facturaG, nodoRaiz.LastChild)
        xmlDoc.Save(path)

    End Sub

End Module
