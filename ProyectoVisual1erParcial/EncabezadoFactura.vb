Imports System.Xml

Public Class EncabezadoFactura
    Private _nombreCliente As String
    Public Property NombreCliente() As String
        Get
            Return _nombreCliente
        End Get
        Set(ByVal value As String)
            _nombreCliente = value
        End Set
    End Property

    Private _rucCliente As String
    Public Property RucCliente() As String
        Get
            Return _rucCliente
        End Get
        Set(ByVal value As String)
            _rucCliente = value
        End Set
    End Property

    Private _direccionCliente As String
    Public Property DireccionCliente() As String
        Get
            Return _direccionCliente
        End Get
        Set(ByVal value As String)
            _direccionCliente = value
        End Set
    End Property

    Sub New(xmlNodeList As XmlNodeList)
        For Each encabFact As XmlNode In xmlNodeList
            Select Case encabFact.Name
                Case "cliente"
                    Me._nombreCliente = encabFact.InnerText
                Case "rucCliente"
                    Me._rucCliente = encabFact.InnerText
                Case "direccionCliente"
                    Me._direccionCliente = encabFact.InnerText
            End Select
        Next
    End Sub

    Overrides Function toString() As String
        Return Me._direccionCliente
    End Function

End Class
