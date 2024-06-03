Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace SDKContpaq
    Public Class Partidas

        Private _cantidad As Double
        Private _precio As Double
        Private _codigo As String
        Private _iva As String
        Private _observacion As String
        Private _nombre As String
        Private _unidad As String

        Public Sub New()

        End Sub
        Public Sub New(ByVal cantidad, ByVal precio, ByVal codigo, ByVal iva, ByVal observa)
            Me._cantidad = cantidad
            Me._precio = precio
            Me._codigo = codigo
            Me._iva = iva
            Me._observacion = observa
        End Sub

        Public Sub New(ByVal cantidad, ByVal precio, ByVal codigo, ByVal iva, ByVal observa, ByVal nombre, ByVal unidad)
            Me._cantidad = cantidad
            Me._precio = precio
            Me._codigo = codigo
            Me._iva = iva
            Me._observacion = observa
            Me._nombre = nombre
            Me._unidad = unidad
        End Sub

        Public Property Cantidad() As String
            Get
                Return Me._cantidad
            End Get
            Set(ByVal value As String)
                Me._cantidad = value
            End Set
        End Property

        Public Property Codigo As String
            Get
                Return Me._codigo
            End Get
            Set(ByVal value As String)
                Me._codigo = value
            End Set
        End Property

        Public Property Nombre As String
            Get
                Return Me._nombre
            End Get
            Set(ByVal value As String)
                Me._nombre = value
            End Set
        End Property

        Public Property Unidad As String
            Get
                Return Me._unidad
            End Get
            Set(ByVal value As String)
                Me._unidad = value
            End Set
        End Property

        Public Property Precio() As String
            Get
                Return Me._precio
            End Get
            Set(ByVal value As String)
                Me._precio = value
            End Set
        End Property

        Public Property Iva As String
            Get
                Return Me._iva
            End Get
            Set(ByVal value As String)
                Me._iva = value
            End Set
        End Property

        Public Property Observacion As String
            Get
                Return Me._observacion
            End Get
            Set(ByVal value As String)
                Me._observacion = value
            End Set
        End Property

        Public Property Almancen As String
        Public Property Descuento As String
        Public Property PorcentajeDescuento As String

    End Class
End Namespace