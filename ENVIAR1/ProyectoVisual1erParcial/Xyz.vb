Public Class Xyz

    'Sub facturar(nombrePeli As String)
    '    facturaNum = CInt(Factura.NumeroFactura)
    '    'Dim facturas As XmlElement = xmlDoc.CreateElement("facturas")
    '    facturaNum = facturaNum + 1
    '    Dim listaCategorias As XmlNodeList = xmlDocCategorias.GetElementsByTagName("categoria")

    '    Dim flag As Boolean = False
    '    For Each categoria As XmlNode In listaCategorias
    '        For Each libro As XmlNode In categoria.ChildNodes
    '            For Each atributo As XmlNode In libro.ChildNodes
    '                Select Case atributo.Name
    '                    Case "titulo"
    '                        nomLibro = atributo.InnerText
    '                        'Case "autor"
    '                    Case "isbn"
    '                        codigo = atributo.InnerText
    '                        'Case "editorial"
    '                        'Case "genero"
    '                    Case "precio"
    '                        valor = atributo.InnerText
    '                        'Case Else
    '                End Select
    '            Next
    '            If nomLibro = nombrePeli Then
    '                Console.WriteLine("El libro sí existe. Sus datos a continuación:")
    '                Console.WriteLine("Título: " & nomLibro)
    '                Console.WriteLine("ISBN: " & codigo)
    '                Console.WriteLine("Precio: " & valor)
    '                flag = True
    '                Exit For
    '            End If
    '        Next
    '        If flag = True Then
    '            Exit For
    '        End If
    '    Next

    '    If flag = False Then
    '        Console.WriteLine("El libro no existe.")
    '    End If

    '    'ProvinciaHabitada(codigo, nomLibro, valor)
    'End Sub

    'Sub ProvinciaHabitada(codigo As String, nomLibro As String, valor As Double)
    '    Console.Clear()
    '    Do
    '        opcionProvincvia = MenuProvincia()
    '        Select Case opcionProvincvia
    '            Case "1" 'ESMERALDA Y MANABI 
    '                Provincia = "Provincia afectada"
    '                iva = 0.12
    '                FormaPago(iva, codigo, nomLibro, valor, Provincia)
    '            Case "2" 'PROVINCIAS RESTANTES
    '                Provincia = "Provincia no afectada"
    '                iva = 0.14
    '                FormaPago(iva, codigo, nomLibro, valor, Provincia)
    '            Case "3" 'ATRAS
    '                Console.WriteLine("GRACIAS POR SU VISITA")
    '                Console.ReadLine()
    '                End
    '            Case Else
    '                Console.WriteLine("Opción incorrecta. Presione enter para volver a ingresar")
    '                Console.ReadLine()
    '                'Console.WriteLine("En construccion del menu provincia en que se realizo la compra")
    '        End Select
    '    Loop While opcionProvincvia <> 3
    'End Sub

    'Function MenuProvincia() As Integer
    '    Dim opcionElegida As Integer = -1
    '    Dim entrada As String
    '    Do
    '        Console.Clear()
    '        Console.WriteLine(vbTab & "MENU PROVINCIA")
    '        Console.WriteLine("Elija su rol")
    '        Console.WriteLine("1. Provincia afectadas: Esmeralda, Manabi")
    '        Console.WriteLine("2. Provincias no afectadas: restantes")
    '        Console.WriteLine("3. Atras")
    '        Console.WriteLine("Elija su opcion: ")
    '        entrada = Console.ReadLine()
    '        Try
    '            opcionElegida = Integer.Parse(entrada)
    '        Catch ex As Exception

    '        End Try
    '        If Not (opcionElegida >= 1 And opcionElegida <= 3) Then 'en caso de mal ingreso
    '            Console.WriteLine("Opción incorrecta. Presione enter para volver a ingresar")
    '            Console.ReadLine()
    '        End If
    '    Loop Until opcionElegida >= 1 And opcionElegida <= 3
    '    Return opcionElegida
    'End Function

    'Sub FormaPago(iva As Double, codigo As String, nomLibro As String, valor As Double, provincia As String)
    '    Console.Clear()
    '    Dim opcionPrincipal As Integer
    '    Do
    '        opcionPrincipal = MenuFormaPago()
    '        Select Case opcionPrincipal
    '            Case "1" 'TARJETA DE CREDITO
    '                Console.Clear()
    '                IngresosDatos()
    '                formaPagoAfectada = 0.01
    '                tipoPago = "Targeta de Credito"
    '                GuardarEsmeraldaManabi(xmlDoc, formaPagoAfectada, iva, tipoPago, codigo, nomLibro, valor, provincia)
    '            Case "2" 'EFECTIVO
    '                Console.Clear()
    '                IngresosDatos()
    '                formaPagoAfectada = 0.00
    '                tipoPago = "Dinero Efectivo"
    '                GuardarEsmeraldaManabi(xmlDoc, formaPagoAfectada, iva, tipoPago, codigo, nomLibro, valor, provincia)
    '            Case "3" 'DINERO ELECTRONICO
    '                Console.Clear()
    '                IngresosDatos()
    '                formaPagoAfectada = 0.04
    '                tipoPago = "Dinero Electronico"
    '                GuardarEsmeraldaManabi(xmlDoc, formaPagoAfectada, iva, tipoPago, codigo, nomLibro, valor, provincia)
    '            Case "4" 'ATRAS 
    '                Console.WriteLine("***GRACIAS POR SU VISITA")
    '                Console.ReadLine()
    '                End
    '            Case Else
    '                Console.WriteLine("Opción incorrecta. Presione enter para volver a ingresar")
    '                Console.ReadLine()
    '        End Select

    '    Loop While opcionFormaPago <> 4
    'End Sub

    'Function MenuFormaPago()
    '    Dim opcionElegida As Integer = -1
    '    Dim entrada As String
    '    Do
    '        Console.Clear()
    '        Console.WriteLine(vbTab & "MENU FORMA DE PAGO")
    '        Console.WriteLine("Elija su rol")
    '        Console.WriteLine("1. Tarjeta de credito")
    '        Console.WriteLine("2. Efectivo")
    '        Console.WriteLine("3. Dinero Electronico")
    '        Console.WriteLine("4. Atras")
    '        Console.WriteLine("Elija su opcion: ")
    '        entrada = Console.ReadLine()
    '        Try
    '            opcionElegida = Integer.Parse(entrada)
    '        Catch ex As Exception

    '        End Try
    '        If Not (opcionElegida >= 1 And opcionElegida <= 4) Then 'en caso de mal ingreso
    '            Console.WriteLine("Opción incorrecta. Presione enter para volver a ingresar")
    '            Console.ReadLine()
    '        End If
    '    Loop Until opcionElegida >= 1 And opcionElegida <= 4
    '    Return opcionElegida
    'End Function

    'Sub IngresosDatos()
    '    Dim x As String
    '    Console.WriteLine("Ingrese el nombre y apellido del cliente: ")
    '    nombreCilente = Console.ReadLine
    '    Console.WriteLine("Ingrese el ruc o cedula: ")
    '    rucCliente = Console.ReadLine
    '    Console.WriteLine("Ingrese la fecha del dia (dd/mm/yyyy): ")
    '    fechaCliente = Console.ReadLine
    '    Console.WriteLine("Ingrese la direccion del cliente: ")
    '    direccionCliente = Console.ReadLine
    '    Console.WriteLine("Ingrese la cantidad de libros: ")
    '    cantidadCliente = Console.ReadLine()
    '    'x = Console.ReadLine
    '    'Try
    '    '    cantidadCliente = Integer.Parse(x)
    '    'Catch ex As Exception
    '    'End Try
    '    'If Not (cantidadCliente >= 1 And cantidadCliente <= 300) Then 'en caso de mal ingreso
    '    '    Console.WriteLine("Opción incorrecta. ") 'Presione enter para volver a ingresar
    '    '    'Console.ReadLine()
    '    'End If
    'End Sub

    '    Private Sub GuardarEsmeraldaManabi(xmlDoc As XmlDocument, formaPagoAfectada As Double, iva As Double, tipoPago As String, codigo As String, nomLibro As String, valor As Double, provincia As String)
    '        Dim facturaG As XmlElement = xmlDoc.CreateElement("factura")
    '        Dim numFactura As Integer
    '        numFactura += Factura.NumeroFactura 'Me._numeroFactura
    '        Dim facturaNumG As XmlElement = xmlDoc.CreateElement("facturaNum")
    '        facturaNumG.InnerText = facturaNum

    '        facturaG.AppendChild(facturaNumG)
    '        Dim razonSocialG As XmlElement = xmlDoc.CreateElement("razonSocial")
    '        razonSocialG.InnerText = "LibriMundi"
    '        razonSocialImp = "LibriMundi"
    '        facturaG.AppendChild(razonSocialG)
    '        Dim rucG As XmlElement = xmlDoc.CreateElement("ruc")
    '        rucG.InnerText = "1791397339001"
    '        rucEmpImp = "1791397339001"
    '        facturaG.AppendChild(rucG)
    '        Dim direccionG As XmlElement = xmlDoc.CreateElement("direccion")
    '        direccionG.InnerText = "Av. Francisco de Orellana s/n y Av. Plaza Dañin"
    '        direcEmpImp = "Av. Francisco de Orellana s/n y Av. Plaza Dañin"
    '        facturaG.AppendChild(direccionG)
    '        Dim telefonoG As XmlElement = xmlDoc.CreateElement("telefono")
    '        telefonoG.InnerText = "2083202"
    '        facturaG.AppendChild(telefonoG)

    '        Dim provinciaG As XmlElement = xmlDoc.CreateElement("provincia")
    '        provinciaG.InnerText = provincia
    '        provImp = provincia
    '        facturaG.AppendChild(provinciaG)

    '        Dim encabezadoFacturaG As XmlElement = xmlDoc.CreateElement("encabezadoFactura")
    '        Dim clienteG As XmlElement = xmlDoc.CreateElement("cliente")
    '        clienteG.InnerText = nombreCilente
    '        encabezadoFacturaG.AppendChild(clienteG)
    '        Dim rucClienteG As XmlElement = xmlDoc.CreateElement("rucCliente")
    '        rucClienteG.InnerText = rucCliente
    '        encabezadoFacturaG.AppendChild(rucClienteG)
    '        Dim direccionClienteG As XmlElement = xmlDoc.CreateElement("direccionCliente")
    '        direccionClienteG.InnerText = direccionCliente
    '        encabezadoFacturaG.AppendChild(direccionClienteG)
    '        facturaG.AppendChild(encabezadoFacturaG)

    '        Dim tipoPagoG As XmlElement = xmlDoc.CreateElement("tipoPago")
    '        tipoPagoG.InnerText = tipoPago
    '        facturaG.AppendChild(tipoPagoG)
    '        Dim fechaG As XmlElement = xmlDoc.CreateElement("fecha")
    '        fechaG.InnerText = fechaCliente
    '        facturaG.AppendChild(fechaG)

    '        Dim detallesG As XmlElement = xmlDoc.CreateElement("detalles")
    '        Dim detalleFacturaG As XmlElement = xmlDoc.CreateElement("detalleFactura")
    '        Dim codigoG As XmlElement = xmlDoc.CreateElement("codigo")
    '        codigoG.InnerText = codigo
    '        detalleFacturaG.AppendChild(codigoG)
    '        Dim descripcionG As XmlElement = xmlDoc.CreateElement("descripcion")
    '        descripcionG.InnerText = nomLibro
    '        detalleFacturaG.AppendChild(descripcionG)
    '        Dim cantidadG As XmlElement = xmlDoc.CreateElement("cantidad")
    '        cantidadG.InnerText = CStr(cantidadCliente)
    '        detalleFacturaG.AppendChild(cantidadG)
    '        Dim precioG As XmlElement = xmlDoc.CreateElement("precio")
    '        precioG.InnerText = CStr(valor)
    '        detalleFacturaG.AppendChild(precioG)
    '        Dim precioTotalG As XmlElement = xmlDoc.CreateElement("precioTotal")
    '        precioTotalImp = valor * cantidadCliente
    '        precioTotalG.InnerText = CStr(precioTotalImp)
    '        detalleFacturaG.AppendChild(precioTotalG)
    '        detallesG.AppendChild(detalleFacturaG)
    '        facturaG.AppendChild(detallesG)

    '        Dim subtotalG As XmlElement = xmlDoc.CreateElement("subtotal")
    '        subtotal = valor * cantidadCliente
    '        subtotalG.InnerText = CStr(subtotal)
    '        facturaG.AppendChild(subtotalG)
    '        Dim ivaG As XmlElement = xmlDoc.CreateElement("iva")
    '        ivaG.InnerText = CStr(iva)
    '        ivaTotal = subtotal * iva
    '        facturaG.AppendChild(ivaG)
    '        Dim totalPagarG As XmlElement = xmlDoc.CreateElement("totalPagar")
    '        totalPagar = ivaTotal + subtotal
    '        totalPagarG.InnerText = CStr(totalPagar)
    '        facturaG.AppendChild(totalPagarG)
    '        Dim devolucionG As XmlElement = xmlDoc.CreateElement("devolucion")
    '        devolucionImp = totalPagar * formaPagoAfectada
    '        devolucionG.InnerText = CStr(devolucionImp)
    '        facturaG.AppendChild(devolucionG)
    '        Guardar(facturaG)

    '        'ImprimirFactura(facturaNum, razonSocialImp, direcEmpImp, rucEmpImp, provImp, nomLibro, codigo, valor, nombreCilente, rucCliente, tipoPago, cantidadCliente, precioTotalImp, subtotal, iva, totalPagar, devolucionImp, formaPagoAfectada, ivaTotal)

    '    End Sub

    '    Private Sub Guardar(facturaG As XmlElement)
    '        Dim nodoRaiz As XmlNode = xmlDoc.DocumentElement
    '        nodoRaiz.InsertAfter(facturaG, nodoRaiz.LastChild)
    '        xmlDoc.Save(path)
    '    End Sub

    '    Sub ImprimirFactura(facturaNum As Integer, razonSocialImp As String, direcEmpImp As String, rucEmpImp As String, provImp As String, nomLibro As String, codigo As String, valor As Double, nombreCilente As String, rucCliente As String, tipoPago As String, cantidadCliente As Integer, precioTotalImp As Double, subtotal As Double, iva As Double, totalPagar As Double, devolucionImp As Double, formaPagoAfectada As Double, ivaTotal As Double)
    '        Console.WriteLine("Num. Factura: " & facturaNum)
    '        Console.WriteLine("Razon socila: " & razonSocialImp & vbTab & vbTab & "ruc: " & rucEmpImp)
    '        Console.WriteLine("Direccion: " & direcEmpImp)
    '        Console.WriteLine("Provincia: " & provImp)
    '        Console.WriteLine("Cliente: " & nombreCilente & vbTab & vbTab & vbTab & "ruc: " & rucCliente)
    '        Console.WriteLine("Tipo de pago: " & tipoPago)
    '        Console.WriteLine("Cant." & vbTab & "Codigo" & vbTab & vbTab & vbTab & "Descripcion") '& vbTab & vbTab & "Precio" & vbTab & "Precio Total"
    '        Console.WriteLine(cantidadCliente & vbTab & codigo & vbTab & nomLibro) ' & vbTab & valor & vbTab & precioTotalImp
    '        Console.WriteLine("Precio" & vbTab & "Precio Total")
    '        Console.WriteLine(valor & vbTab & precioTotalImp)
    '        Console.WriteLine("Subtotal: " & subtotal)
    '        Console.WriteLine("iva " & iva & ": " & ivaTotal)
    '        Console.WriteLine("Total a pagar: " & totalPagar)
    '        Console.WriteLine("Devolucion " & formaPagoAfectada & ": " & devolucionImp)
    '    End Sub

End Class
