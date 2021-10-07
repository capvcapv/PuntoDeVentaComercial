Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Text
Imports System.IO

Namespace SDKContpaq
    Public Class NotaCredito
        Private tdoc As AdminPAQSDK.tDocumento
        Private tMov As AdminPAQSDK.tMovimiento
        Private documentoId As Integer = 0
        Private movimientoId As Integer = 0

        Public xml As String

        Public rutaBD As String
        Public rutaFomato As String
        Public rutaFormatoTicket As String
        Public concepto As String
        Public cliente As String
        Public referencia As String
        Public metodoPago As String
        Public numCuenta As String
        Public total As String
        Public clave As String

        Public serie As String
        Public sigFolio As Double
        Public part As List(Of Partidas)

        Public Sub creaFactura()

            Dim a As Double
            Dim biva As Double

            a = 0
            biva = 0

            For i As Integer = 0 To part.Count - 1
                a = a + (part(i).Precio * part(i).Cantidad)
                'biva = biva + part(i).iva
            Next

            tdoc = New AdminPAQSDK.tDocumento()
            Dim hoy As Date = Date.Today
            Dim fecha As String = hoy.ToString("MM/dd/yyyy")
            Dim enconder As New UTF8Encoding()

            serie = ""

            AdminPAQSDK.fSiguienteFolio(concepto, serie, sigFolio)

            tdoc.aFolio = sigFolio
            tdoc.aNumMoneda = 1
            tdoc.aTipoCambio = 1
            tdoc.aImporte = CDbl(a)
            tdoc.aDescuentoDoc1 = 0
            tdoc.aDescuentoDoc2 = 0
            tdoc.aSistemaOrigen = 202

            tdoc.aCodConcepto = New Byte(AdminPAQSDK.Constantes.kLongCodigo - 1) {}
            tdoc.aCodigoAgente = New Byte(AdminPAQSDK.Constantes.kLongCodigo - 1) {}
            tdoc.aCodigoCteProv = New Byte(AdminPAQSDK.Constantes.kLongCodigo - 1) {}
            tdoc.aReferencia = New Byte(AdminPAQSDK.Constantes.kLongReferencia - 1) {}
            tdoc.aFecha = New Byte(AdminPAQSDK.Constantes.kLongFecha - 1) {}
            tdoc.aSerie = New Byte(AdminPAQSDK.Constantes.kLongNumSerie - 1) {}

            concepto = AdminPAQSDK.PrepararCadena(concepto, AdminPAQSDK.Constantes.kLongCodigo)
            cliente = AdminPAQSDK.PrepararCadena(cliente, AdminPAQSDK.Constantes.kLongCodigo)
            fecha = AdminPAQSDK.PrepararCadena(fecha, AdminPAQSDK.Constantes.kLongFecha)
            referencia = AdminPAQSDK.PrepararCadena(referencia, AdminPAQSDK.Constantes.kLongReferencia)
            serie = AdminPAQSDK.PrepararCadena(serie, AdminPAQSDK.Constantes.kLongNumSerie)

            '' Asigna los valores a la estructura del documento   
            enconder.GetBytes(concepto, 0, AdminPAQSDK.Constantes.kLongCodigo - 1, tdoc.aCodConcepto, 0)
            enconder.GetBytes(serie, 0, AdminPAQSDK.Constantes.kLongNumSerie - 1, tdoc.aSerie, 0)
            enconder.GetBytes(fecha, 0, AdminPAQSDK.Constantes.kLongFecha - 1, tdoc.aFecha, 0)
            enconder.GetBytes(cliente, 0, AdminPAQSDK.Constantes.kLongCodigo - 1, tdoc.aCodigoCteProv, 0)
            enconder.GetBytes(referencia, 0, AdminPAQSDK.Constantes.kLongReferencia - 1, tdoc.aReferencia, 0)


            tdoc.aAfecta = 0
            tdoc.aGasto1 = 0
            tdoc.aGasto2 = 0
            tdoc.aGasto3 = 0

            AdminPAQSDK.fAltaDocumentoCargoAbono(tdoc)

            'AdminPAQSDK.fBuscarIdDocumento(documentoId)
            AdminPAQSDK.fBuscarDocumento(concepto, serie, sigFolio)
            AdminPAQSDK.fEditarDocumento()
            AdminPAQSDK.fSetDatoDocumento("CREFEREN01", referencia)
            AdminPAQSDK.fSetDatoDocumento("CMETODOPAG", metodoPago)
            AdminPAQSDK.fSetDatoDocumento("CNUMCTAPAG", numCuenta)

            Dim obser As String
            obser = ""

            For i As Integer = 0 To part.Count - 1

                obser = obser + part(i).Nombre + vbCrLf

            Next

            AdminPAQSDK.fSetDatoDocumento("CNUMCTAPAG", numCuenta)
            AdminPAQSDK.fSetDatoDocumento("COBSERVACIONES", obser)
            'AdminPAQSDK.fSetDatoDocumento("CIMPUESTO1", biva)
            'AdminPAQSDK.fSetDatoDocumento("CNETO", a)
            'AdminPAQSDK.fSetDatoDocumento("CTOTAL", a + biva)

            AdminPAQSDK.fGuardaDocumento()

            AdminPAQSDK.fAfectaDocto_Param(concepto, serie, sigFolio, True)

            AdminPAQSDK.fEmitirDocumento(concepto.Trim, serie.Trim, sigFolio, clave, "")
            AdminPAQSDK.fEntregEnDiscoXML(concepto.Trim, serie.Trim, sigFolio, 1, rutaFomato)

            Dim nombreXML As New StringBuilder()

            nombreXML.Append(rutaBD)
            nombreXML.Append("\XML_SDK\")
            nombreXML.Append(CInt(Math.Truncate(sigFolio)))
            Me.xml = nombreXML.ToString()

        End Sub

        Public Sub generaPDF(ByVal tipo As Integer)
            If tipo = 1 Then
                AdminPAQSDK.fEntregEnDiscoXML(concepto.Trim, serie.Trim, sigFolio, 1, rutaFomato)
            ElseIf tipo = 0 Then
                AdminPAQSDK.fEntregEnDiscoXML(concepto.Trim, serie.Trim, sigFolio, 1, rutaFormatoTicket)
            End If
        End Sub

    End Class
End Namespace
