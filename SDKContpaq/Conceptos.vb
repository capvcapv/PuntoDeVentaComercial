Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Text

Namespace SDKContpaq
    Public Class Conceptos
        Public codigo As String
        Public nombre As String
        Public unidad As String

        Public Shared Function existeConcepto(ByVal codigo As String) As Boolean
            If AdminPAQSDK.fBuscaProducto(codigo) = 0 Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Function existeUnidad(ByVal nombreUnidad As String) As Boolean
            If AdminPAQSDK.fBuscaUnidad(nombreUnidad) = 0 Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Function idUnidad() As String
            Dim s As New StringBuilder()
            s.Append(ControlChars.NullChar, 11)

            AdminPAQSDK.fBuscaUnidad(Me.unidad)

            AdminPAQSDK.fLeeDatoUnidad("CIDUNIDAD", s, 11)

            Return s.ToString().Trim()
        End Function

        Public Sub guardarUnidad()
            AdminPAQSDK.fInsertaUnidad()

            AdminPAQSDK.fSetDatoUnidad("CABREVIA01", Convert.ToString(Me.unidad).Trim().Substring(0, 2))
            AdminPAQSDK.fSetDatoUnidad("CNOMBREU01", Me.unidad)

            AdminPAQSDK.fGuardaUnidad()

        End Sub

        Public Function guardar() As Boolean
            If Not existeUnidad(Me.unidad) Then
                guardarUnidad()
            End If

            AdminPAQSDK.fInsertaProducto()

            AdminPAQSDK.fSetDatoProducto("CCODIGOP01", Me.codigo)
            AdminPAQSDK.fSetDatoProducto("CNOMBREP01", Me.nombre)
            AdminPAQSDK.fSetDatoProducto("CFECHAAL01", "12/12/2012")
            AdminPAQSDK.fSetDatoProducto("CTIPOPRO01", "3")
            AdminPAQSDK.fSetDatoProducto("CESTATUS", "1")
            AdminPAQSDK.fSetDatoProducto("CMETODOC01", "1")
            AdminPAQSDK.fSetDatoProducto("CSTATUSP01", "1")
            AdminPAQSDK.fSetDatoProducto("CCONTROL01", "1")
            AdminPAQSDK.fSetDatoProducto("CIDUNIDA01", idUnidad())
            AdminPAQSDK.fSetDatoProducto("CIDUNIDA02", idUnidad())
            AdminPAQSDK.fSetDatoProducto("CIDUNICOM", idUnidad())
            AdminPAQSDK.fSetDatoProducto("CIDUNIVEN", idUnidad())
            AdminPAQSDK.fSetDatoProducto("CMETODOC01", "1")

            If AdminPAQSDK.fGuardaProducto() = 0 Then
                Return True
            Else
                Return False
            End If

        End Function

        Private Sub registrarError(ByVal errorId As Integer)

            If errorId <> 0 AndAlso errorId <> 999999 Then
                Dim s As New StringBuilder()
                s.Append(ControlChars.NullChar, 350)
                AdminPAQSDK.fError(errorId, s, 350)
                Throw New Exception(s.ToString())
            End If
        End Sub
    End Class
End Namespace
