Imports System.Xml



Public Class Factura
    Private _numeroFactura As Integer
    Public Property NumeroFactura() As Integer
        Get
            Return _numeroFactura
        End Get
        Set(ByVal value As Integer)
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

    Private _provincia As Provincia 'Coger el dato del iva
    Public Property Provincia() As Provincia
        Get
            Return _provincia
        End Get
        Set(ByVal value As Provincia)
            _provincia = value
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
    Sub New(facturaNodo As XmlNode)
        Dim detalleAuxiliar As DetalleFactura = New DetalleFactura()
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
                        Me._provincia = New Provincia(fact.InnerText)
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
                                        Console.WriteLine(datosDetalleFactura.InnerText)
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
                        Me._provincia.Iva = CDbl(fact.InnerText)
                    Case "totalPagar"
                        Me._totalPagar = CDbl(fact.InnerText)
                    Case "devolucion"
                        Me._devolucionDinero = CDbl(fact.InnerText)
                End Select
            Next
        Next

    End Sub

    Sub ImprimirFactura()
        Console.WriteLine(Me._devolucionDinero)
        'Console.WriteLine("Datos cargados")
    End Sub


    'Sub ImprimirArrayListDetalleFactura()
    '    For Each dtllFact As DetalleFactura In Me._arrayListDetalleFactura
    '        dtllFact.Imprimir()
    '    Next
    'End Sub
End Class
