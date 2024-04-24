Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Text
Imports System.IO

Namespace SDKContpaq
    Public Class Factura
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
        Public clave As String
        Public lugarExp As String
        Public observaciones As String
        Public moneda As Integer
        Public iva As Double
        Public agente As String

        Public textoextra1 As String

        Public serie As String
        Public sigFolio As Double
        Public part As List(Of Partidas)

        Public Function creaFactura() As String

            tdoc = New AdminPAQSDK.tDocumento()
            Dim hoy As Date = Date.Today
            Dim fecha As String = hoy.ToString("MM/dd/yyyy")
            Dim enconder As New UTF8Encoding()

            serie = ""
            'referencia = "SDK"

            muestra_error(AdminPAQSDK.fSiguienteFolio(concepto, serie, sigFolio))

            tdoc.aFolio = sigFolio
            tdoc.aNumMoneda = moneda
            tdoc.aTipoCambio = 1
            tdoc.aImporte = 0
            tdoc.aDescuentoDoc1 = 0
            tdoc.aDescuentoDoc2 = 0
            tdoc.aSistemaOrigen = 0

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
            agente = AdminPAQSDK.PrepararCadena(agente, AdminPAQSDK.Constantes.kLongCodigo)

            '' Asigna los valores a la estructura del documento   
            enconder.GetBytes(concepto, 0, AdminPAQSDK.Constantes.kLongCodigo - 1, tdoc.aCodConcepto, 0)
            enconder.GetBytes(serie, 0, AdminPAQSDK.Constantes.kLongNumSerie - 1, tdoc.aSerie, 0)
            enconder.GetBytes(fecha, 0, AdminPAQSDK.Constantes.kLongFecha - 1, tdoc.aFecha, 0)
            enconder.GetBytes(cliente, 0, AdminPAQSDK.Constantes.kLongCodigo - 1, tdoc.aCodigoCteProv, 0)
            enconder.GetBytes(referencia, 0, AdminPAQSDK.Constantes.kLongReferencia - 1, tdoc.aReferencia, 0)
            enconder.GetBytes(agente, 0, AdminPAQSDK.Constantes.kLongCodigo - 1, tdoc.aCodigoAgente, 0)

            tdoc.aAfecta = 0
            tdoc.aGasto1 = 0
            tdoc.aGasto2 = 0
            tdoc.aGasto3 = 0

            muestra_error(AdminPAQSDK.fAltaDocumento(documentoId, tdoc))

            AdminPAQSDK.fBuscarIdDocumento(documentoId)
            AdminPAQSDK.fEditarDocumento()

            AdminPAQSDK.fSetDatoDocumento("CTEXTOEXTRA1", textoextra1)
            'AdminPAQSDK.fSetDatoDocumento("CMETODOPAG", metodoPago)
            'AdminPAQSDK.fSetDatoDocumento("CNUMCTAPAG", numCuenta)
            AdminPAQSDK.fSetDatoDocumento("COBSERVACIONES", observaciones)

            AdminPAQSDK.fGuardaDocumento()

            Dim consecutivo As Integer = 100

            For i As Integer = 0 To part.Count - 1

                Dim strProducto As String
                Dim strAlmacen As String
                Dim strReferencia As String
                Dim strClasificacion As String

                tMov = New AdminPAQSDK.tMovimiento()
                tMov.aConsecutivo = consecutivo
                tMov.aUnidades = part(i).Cantidad
                tMov.aPrecio = part(i).Precio
                tMov.aCosto = 0
                tMov.aCodProdSer = New Byte(AdminPAQSDK.Constantes.kLongCodigo) {}
                tMov.aCodAlmacen = New Byte(AdminPAQSDK.Constantes.kLongCodigo) {}
                tMov.aReferencia = New Byte(AdminPAQSDK.Constantes.kLongReferencia) {}
                tMov.aCodClasificacion = New Byte(AdminPAQSDK.Constantes.kLongCodigo) {}
                strProducto = part(i).Codigo
                strAlmacen = part(i).Almancen
                strReferencia = Me.referencia
                strClasificacion = ""

                strProducto = AdminPAQSDK.PrepararCadena(strProducto, AdminPAQSDK.Constantes.kLongCodigo)
                strAlmacen = AdminPAQSDK.PrepararCadena(strAlmacen, AdminPAQSDK.Constantes.kLongCodigo)
                strReferencia = AdminPAQSDK.PrepararCadena(strReferencia, AdminPAQSDK.Constantes.kLongReferencia)
                strClasificacion = AdminPAQSDK.PrepararCadena(strClasificacion, AdminPAQSDK.Constantes.kLongCodigo)


                '' Asigna los valores a la estructura del documento   
                enconder.GetBytes(strProducto, 0, AdminPAQSDK.Constantes.kLongCodigo - 1, tMov.aCodProdSer, 0)
                enconder.GetBytes(strAlmacen, 0, AdminPAQSDK.Constantes.kLongCodigo - 1, tMov.aCodAlmacen, 0)
                enconder.GetBytes(strReferencia, 0, AdminPAQSDK.Constantes.kLongReferencia - 1, tMov.aReferencia, 0)
                enconder.GetBytes(strClasificacion, 0, AdminPAQSDK.Constantes.kLongCodigo - 1, tMov.aCodClasificacion, 0)

                Dim err As Integer
                Dim ldescerr As New StringBuilder
                ldescerr.Append(ControlChars.NullChar, 300)

                muestra_error(AdminPAQSDK.fAltaMovimiento(documentoId, movimientoId, tMov))


                err = AdminPAQSDK.fBuscarIdMovimiento(movimientoId)
                AdminPAQSDK.fEditarMovimiento()

                If Not String.IsNullOrEmpty(part(i).Observacion) Then

                    err = AdminPAQSDK.fSetDatoMovimiento("COBSERVAMOV", part(i).Observacion)

                End If

                If Not String.IsNullOrEmpty(part(i).Descuento) Then

                    err = AdminPAQSDK.fSetDatoMovimiento("CDESCUENTO1", part(i).Descuento.Replace("$", ""))

                End If

                If Not String.IsNullOrEmpty(part(i).Iva) Then

                    err = AdminPAQSDK.fSetDatoMovimiento("CIMPUESTO1", part(i).Iva)

                End If

                If Not err = 0 Then
                    AdminPAQSDK.fError(err, ldescerr, 300)
                    MsgBox(ldescerr.ToString)
                End If
                err = AdminPAQSDK.fGuardaMovimiento()


                err = AdminPAQSDK.fAfectaDocto_Param(concepto.Trim, serie.Trim, sigFolio, True)

                consecutivo += 1
            Next

            AdminPAQSDK.fDesbloqueaDocumento()

            'If AdminPAQSDK.fEmitirDocumento(concepto.Trim, serie.Trim, sigFolio, clave, "") = 0 Then

            '    AdminPAQSDK.fEntregEnDiscoXML(concepto.Trim, serie.Trim, sigFolio, 1, rutaFomato)

            'End If

            'Dim nombreXML As New StringBuilder()

            'nombreXML.Append(rutaBD)
            'nombreXML.Append("\XML_SDK\")
            'nombreXML.Append(CInt(Math.Truncate(sigFolio)))
            'Me.xml = nombreXML.ToString()

            Return sigFolio

        End Function

        Public Sub generaPDF(ByVal tipo As Integer)
            If tipo = 1 Then
                AdminPAQSDK.fEntregEnDiscoXML(concepto.Trim, serie.Trim, sigFolio, 1, rutaFomato)
            ElseIf tipo = 0 Then
                AdminPAQSDK.fEntregEnDiscoXML(concepto.Trim, serie.Trim, sigFolio, 1, rutaFormatoTicket)
            End If
        End Sub

        Private Sub muestra_error(err As Integer)

            Dim ldescerr As New StringBuilder
            ldescerr.Append(ControlChars.NullChar, 300)

            If Not err = 0 Then
                AdminPAQSDK.fError(err, ldescerr, 300)
                MsgBox(ldescerr.ToString)
            End If

        End Sub

    End Class
End Namespace
