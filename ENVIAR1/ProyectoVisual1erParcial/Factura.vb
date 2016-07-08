Imports System.Xml



Public Class Factura
    Dim _detalleAuxiliar As DetalleFactura = New DetalleFactura()
    Public Property DetalleAuxiliar() As DetalleFactura
        Get
            Return _detalleAuxiliar
        End Get
        Set(ByVal value As DetalleFactura)
            _detalleAuxiliar = value
        End Set
    End Property


    Private _numeroFactura As String
    Public Property NumeroFactura() As String
        Get
            Return _numeroFactura
        End Get
        Set(ByVal value As String)
            _numeroFactura = value
        End Set
    End Property

    Private _razonSocial As String
    Public Property RazonSocial() As String
        Get
            Return _razonSocial
        End Get
        Set(ByVal value As String)
            _razonSocial = value
        End Set
    End Property

    Private _rucEmpresa As String
    Public Property RucEmpresa() As String
        Get
            Return _rucEmpresa
        End Get
        Set(ByVal value As String)
            _rucEmpresa = value
        End Set
    End Property

    Private _direccionEmpresa As String
    Public Property DireccionEmpresa() As String
        Get
            Return _direccionEmpresa
        End Get
        Set(ByVal value As String)
            _direccionEmpresa = value
        End Set
    End Property

    Private _telefonoEmpresa As String
    Public Property TelefonoEmpresa() As String
        Get
            Return _telefonoEmpresa
        End Get
        Set(ByVal value As String)
            _telefonoEmpresa = value
        End Set
    End Property

    Private _fecha As String
    Public Property Fecha() As String
        Get
            Return _fecha
        End Get
        Set(ByVal value As String)
            _fecha = value
        End Set
    End Property

    Private _encabezadoFactura As EncabezadoFactura
    Public Property EncabezadoFactura() As EncabezadoFactura
        Get
            Return _encabezadoFactura
        End Get
        Set(ByVal value As EncabezadoFactura)
            _encabezadoFactura = value
        End Set
    End Property

    Private _tipoPago As String 'Tarjeta de Credito, Dinero Electronico, Efectivo
    Public Property TipoPago() As String
        Get
            Return _tipoPago
        End Get
        Set(ByVal value As String)
            _tipoPago = value
        End Set
    End Property

    Public _arrayListDetalleFactura As ArrayList
    Public Property ArrayListDetalleFactura() As ArrayList
        Get
            Return _arrayListDetalleFactura
        End Get
        Set(ByVal value As ArrayList)
            _arrayListDetalleFactura = value
        End Set
    End Property

    Private _subtotal As Double
    Public Property SubTotal() As Double
        Get
            Return _subtotal
        End Get
        Set(ByVal value As Double)
            _subtotal = value
        End Set
    End Property

    Private _provincia As String  'Coger el dato del iva
    Public Property Provincia() As String
        Get
            Return _provincia
        End Get
        Set(ByVal value As String)
            _provincia = value
        End Set
    End Property

    Private _iva As Double   'Coger el dato del iva
    Public Property Iva() As Double
        Get
            Return _iva
        End Get
        Set(ByVal value As Double)
            _iva = value
        End Set
    End Property

    Private _totalPagar As Double
    Public Property TotalPagar() As Double
        Get
            Return _totalPagar
        End Get
        Set(ByVal value As Double)
            _totalPagar = value
        End Set
    End Property

    Private _devolucionDinero As Double
    Public Property DevolucionDinero() As Double
        Get
            Return _devolucionDinero
        End Get
        Set(ByVal value As Double)
            _devolucionDinero = value
        End Set
    End Property

    Private _pagaIva As String
    Public Property PagaIva() As String
        Get
            Return _pagaIva
        End Get
        Set(ByVal value As String)
            _pagaIva = value
        End Set
    End Property
    Sub New(facturaNodo As XmlNode)

        For Each facturas As XmlNode In facturaNodo.ChildNodes
            For Each fact As XmlNode In facturas.ChildNodes
                Select Case fact.Name
                    Case "facturaNum"
                        Me._numeroFactura = fact.InnerText
                    Case "razonSocial"
                        Me._razonSocial = fact.InnerText
                    Case "ruc"
                        Me._rucEmpresa = fact.InnerText
                    Case "direccion"
                        Me._direccionEmpresa = fact.InnerText
                    Case "telefono"
                        Me._telefonoEmpresa = fact.InnerText
                    Case "provincia"
                        Me._provincia = fact.InnerText
                    Case "encabezadoFactura"
                        Me._encabezadoFactura = New EncabezadoFactura(fact.ChildNodes)
                    Case "tipoPago"
                        Me._tipoPago = fact.InnerText
                    Case "fecha"
                        Me._fecha = fact.InnerText
                    Case "detalles"
                        Me.ArrayListDetalleFactura = New ArrayList()
                        For Each detFactura As XmlNode In fact.ChildNodes
                            For Each datosDetalleFactura As XmlNode In detFactura.ChildNodes
                                Select Case datosDetalleFactura.Name
                                    Case "codigo"
                                        detalleAuxiliar.Codigo = datosDetalleFactura.InnerText
                                        'Console.WriteLine(datosDetalleFactura.InnerText)
                                    Case "descripcion"
                                        detalleAuxiliar.Descripcion = datosDetalleFactura.InnerText
                                    Case "cantidad"
                                        detalleAuxiliar.Cantidad = CInt(datosDetalleFactura.InnerText)
                                    Case "precio"
                                        detalleAuxiliar.Precio = CDbl(datosDetalleFactura.InnerText)
                                    Case "precioTotal"
                                        detalleAuxiliar.PrecioTotal = CDbl(datosDetalleFactura.InnerText)
                                End Select
                                Me._arrayListDetalleFactura.Add(detalleAuxiliar)
                            Next
                        Next
                    Case "subtotal"
                        Me._subtotal = CDbl(fact.InnerText)
                    Case "iva"
                        Me._iva = CDbl(fact.InnerText)
                    Case "totalPagar"
                        Me._totalPagar = CDbl(fact.InnerText)
                    Case "devolucion"
                        Me._devolucionDinero = CDbl(fact.InnerText)
                        'Case "pagaIva"
                        '    Me._pagaIva = fact.InnerText
                End Select
            Next
        Next


        'ImprimirFactura()

    End Sub

    Sub New()

    End Sub

    'Sub ImprimirFactura()
    '    Console.WriteLine(Me._devolucionDinero)
    '    'Console.WriteLine("Datos cargados")
    'End Sub

    Sub ImprimirFactura() 'facturaNum As Integer, razonSocialImp As String, direcEmpImp As String, rucEmpImp As String, provImp As String, nomLibro As String, codigo As String, valor As Double, nombreCilente As String, rucCliente As String, tipoPago As String, cantidadCliente As Integer, precioTotalImp As Double, subtotal As Double, iva As Double, totalPagar As Double, devolucionImp As Double, formaPagoAfectada As Double, ivaTotal As Double
        Console.WriteLine("Num. Factura: " & Me._numeroFactura)
        Console.WriteLine("Razon socila: " & Me._razonSocial & vbTab & vbTab & "ruc: " & Me._rucEmpresa)
        Console.WriteLine("Direccion: " & Me._direccionEmpresa)
        Console.WriteLine("Provincia: " & Me._provincia)
        MyClass.EncabezadoFactura.ImprimirFactura()
        Console.WriteLine("Tipo de pago: " & Me._tipoPago)
        MyClass.detalleAuxiliar.ImprimirFactura()
        Console.WriteLine("Subtotal: " & Me._subtotal)
        Console.WriteLine("iva " & Me._iva)
        Console.WriteLine("Total a pagar: " & Me._totalPagar)
        Console.WriteLine("Devolucion " & Me._devolucionDinero)
        Console.ReadLine()
    End Sub



End Class
