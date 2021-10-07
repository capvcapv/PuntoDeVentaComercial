Imports System.Collections.Generic
Imports System.Text
Imports System.Runtime.InteropServices

Public NotInheritable Class AdminPAQSDK

    Public Class Constantes
        Public Const kLongCodigo As Integer = 31
        Public Const kLongNombre As Integer = 61
        Public Const kLongNombreProducto As Integer = 256
        Public Const kLongFecha As Integer = 24
        Public Const kLongAbreviatura As Integer = 4
        Public Const kLongCodValorClasif As Integer = 4
        Public Const kLongTextoExtra As Integer = 51
        Public Const kLongNumSerie As Integer = 12
        Public Const kLongReferencia As Integer = 21
        Public Const kLongSeries As Integer = 31
        Public Const kLongDescripcion As Integer = 61
        Public Const kLongNumeroExtInt As Integer = 7
        Public Const kLongCodigoPostal As Integer = 7
        Public Const kLongTelefono As Integer = 16
        Public Const kLongEmailWeb As Integer = 51
        Public Const kLongRFC As Integer = 21
        Public Const kLongCURP As Integer = 21
        Public Const kLongDesCorta As Integer = 21
        Public Const kLongDenComercial As Integer = 51
        Public Const kLongRepLegal As Integer = 51
    End Class
    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi, Pack:=4)>
    Public Structure tDocumento
        Public aFolio As Double
        Public aNumMoneda As Int32
        Public aTipoCambio As Double
        Public aImporte As Double
        Public aDescuentoDoc1 As Double
        Public aDescuentoDoc2 As Double
        Public aSistemaOrigen As Integer
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=Constantes.kLongCodigo)>
        Public aCodConcepto As Byte()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=Constantes.kLongNumSerie)>
        Public aSerie As Byte()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=Constantes.kLongFecha)>
        Public aFecha As Byte()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=Constantes.kLongCodigo)>
        Public aCodigoCteProv As Byte()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=Constantes.kLongCodigo)>
        Public aCodigoAgente As Byte()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=Constantes.kLongReferencia)>
        Public aReferencia As Byte()
        Public aAfecta As Int32
        Public aGasto1 As Double
        Public aGasto2 As Double
        Public aGasto3 As Double
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi, Pack:=4)>
    Public Structure tLlaveDocto
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=Constantes.kLongCodigo)>
        Public aCodConcepto As Byte()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=Constantes.kLongNumSerie)>
        Public aSerie As Byte()
        Public aFolio As Double
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi, Pack:=4)>
    Public Structure tMovimiento
        Public aConsecutivo As Int32
        Public aUnidades As Double
        Public aPrecio As Double
        Public aCosto As Double
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=Constantes.kLongCodigo)>
        Public aCodProdSer As Byte()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=Constantes.kLongCodigo)>
        Public aCodAlmacen As Byte()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=Constantes.kLongReferencia)>
        Public aReferencia As Byte()
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=Constantes.kLongCodigo)>
        Public aCodClasificacion As Byte()
    End Structure



    Public Declare Function fPosPrimerAgente Lib "MGWSERVICIOS.DLL" () As Integer
    Public Declare Function fPosSiguienteAgente Lib "MGWSERVICIOS.DLL" () As Integer
    Public Declare Function fPosEOFProducto Lib "MGWSERVICIOS.DLL" () As Integer
    Public Declare Function fPosEOFAgente Lib "MGWSERVICIOS.DLL" () As Integer
    'Public Declare Function fLeeDatoAgente Lib "MGWSERVICIOS.DLL" (ByVal Campo As String, ByVal Valor As StringBuilder, ByVal Longitud As Integer) As Integer



    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fInicializaSDK() As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fRegresaExistencia(ByVal aCodigoProducto As String, ByVal aCodigoAlmacen As String, ByVal aAnio As String, ByVal aMes As String, ByVal aDia As String, ByRef aExistencia As Double) As Long
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fInicioSesionSDK(usuario As String, clave As String) As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Sub fTerminaSDK()
    End Sub

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Sub fError(ByVal NumeroError As Integer, ByVal Mensaje As StringBuilder, ByVal Longitud As Integer)
    End Sub

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fAbreEmpresa(ByVal Directorio As String) As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Sub fCierraEmpresa()
    End Sub

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fPosPrimerEmpresa(ByRef EmpresaId As Integer, ByVal NombreEmpresa As StringBuilder, ByVal DirectorioEmpresa As StringBuilder) As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fPosSiguienteEmpresa(ByRef EmpresaId As Integer, ByVal NombreEmpresa As StringBuilder, ByVal DirectorioEmpresa As StringBuilder) As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL", CharSet:=CharSet.Ansi, EntryPoint:="fAltaDocumentoCargoAbono")>
    Public Shared Function fAltaDocumentoCargoAbono(ByRef aDocto As tDocumento) As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL", CharSet:=CharSet.Ansi, EntryPoint:="fAltaDocumento")>
    Public Shared Function fAltaDocumento(ByRef aIdDocto As Int32, ByRef aDocto As tDocumento) As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL", CharSet:=CharSet.Ansi, EntryPoint:="fAltaMovimiento")>
    Public Shared Function fAltaMovimiento(ByVal aIdDocto As Int32, ByRef aMovtoId As Int32, ByRef aMovto As tMovimiento) As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fAfectaDocto(ByRef aLlaveDocto As tLlaveDocto, ByVal aAfecta As Integer) As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fBuscarIdDocumento(ByVal aLlaveDocto As Integer) As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fLeeDatoAgente(ByVal Campo As String, ByVal Valor As StringBuilder, ByVal Longitud As Integer) As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fBuscaDocumento(ByVal aLlaveDocto As tLlaveDocto) As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL", CharSet:=CharSet.Ansi, EntryPoint:="fBuscarDocumento")>
    Public Shared Function fBuscarDocumento(<MarshalAs(UnmanagedType.LPStr)> ByVal CodigoConcepto As String, <MarshalAs(UnmanagedType.LPStr)> ByVal Serie As String, <MarshalAs(UnmanagedType.LPStr)> ByVal Folio As String) As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fSiguienteFolio(ByVal aCodigoConcepto As String, ByVal aNumSerie As String, ByRef aFolio As Double) As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fInsertarDocumento() As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fEditarDocumento() As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fGuardaDocumento() As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fCancelarModificacionDocumento() As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fBorraDocumento() As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fCancelaDocumento() As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fSetDatoDocumento(ByVal Campo As String, ByVal Valor As String) As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fLeeDatoDocumento(ByVal Campo As String, ByVal Valor As StringBuilder, ByVal Longitud As Integer) As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fInsertarMovimiento() As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fEditarMovimiento() As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fGuardaMovimiento() As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fCancelaCambiosMovimiento() As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fBorraMovimiento() As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fCancelaMovimiento() As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fBuscarIdMovimiento(ByVal Campo As Integer) As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fSetDatoMovimiento(ByVal Campo As String, ByVal Valor As String) As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fLeeDatoMovimiento(ByVal Campo As String, ByRef Valor As String, ByVal Longitud As Integer) As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fAfectaDocto_Param(ByVal codigo As String, ByVal serie As String, ByVal folio As Double, ByVal afecta As Boolean) As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fSetNombrePAQ(ByVal Campo As String) As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fInicializaLicenseInfo(ByVal Campo As Short) As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fEmitirDocumento(ByVal concepto As String, ByVal serie As String, ByVal folio As Double, ByVal clave As String, ByVal archivo As String) As Integer
    End Function

    <DllImport("kernel32.dll")>
    Public Shared Function SetCurrentDirectory(ByVal Campo As String) As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fBuscaDireccionCteProv(ByVal cte As String, ByVal tipo As String) As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fBuscaCteProv(ByVal codigo As String) As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fInsertaCteProv() As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fSetDatoCteProv(ByVal campo As String, ByVal value As String) As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fGuardaCteProv() As Integer
    End Function

    '<DllImport("MGWSERVICIOS.DLL")> _
    'Public Shared Function fLeeDatoCteProv(ByVal Campo As String, ByVal Valor As StringBuilder, ByVal Longitud As Integer) As Integer
    'End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fInsertaDireccion() As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fSetDatoDireccion(ByVal campo As String, ByVal value As String) As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fGuardaDireccion() As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fEditaProducto() As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fBuscaProducto(ByVal codigo As String) As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fBuscaUnidad(ByVal nombre As String) As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fInsertaUnidad() As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fSetDatoUnidad(ByVal campo As String, ByVal value As String) As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fGuardaUnidad() As Integer
    End Function

    '<DllImport("MGWSERVICIOS.DLL")>
    'Public Shared Function fLeeDatoUnidad(ByVal Campo As String, ByVal Valor As StringBuilder, ByVal Longitud As Integer) As Integer
    'End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fInsertaProducto() As Integer
    End Function

    '<DllImport("MGWSERVICIOS.DLL")> _
    'Public Shared Function fSetDatoProducto(ByVal campo As String, ByVal value As String) As Integer
    'End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fGuardaProducto() As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fEntregEnDiscoXML(ByVal concepto As String, ByVal serie As String, ByVal folio As Double, ByVal formato As Integer, ByVal plantilla As String) As Integer
    End Function


    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fPosPrimerUnidad() As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fPosSiguienteUnidad() As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fPosEOFUnidad() As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fLeeDatoUnidad(ByVal campo As String, ByVal cadena As StringBuilder, ByVal longitud As Integer) As Integer
    End Function


    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fPosPrimerConceptoDocto() As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fPosSiguienteConceptoDocto() As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fPosEOFConceptoDocto() As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fLeeDatoConceptoDocto(ByVal campo As String, ByVal cadena As StringBuilder, ByVal longitud As Integer) As Integer
    End Function


    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fPosEOFAlmacen() As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fPosPrimerCteProv() As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fPosSiguienteCteProv() As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fPosEOFCteProv() As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fLeeDatoCteProv(ByVal campo As String, ByVal cadena As StringBuilder, ByVal longitud As Integer) As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fPosPrimerProducto() As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fPosSiguienteProducto() As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fLeeDatoProducto(ByVal campo As String, ByVal cadena As StringBuilder, ByVal longitud As Integer) As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fSetDatoProducto(ByVal campo As String, ByVal cadena As String) As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fPosPrimerAlmacen() As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fPosSiguienteAlmacen() As Integer
    End Function

    <DllImport("MGWSERVICIOS.DLL")>
    Public Shared Function fLeeDatoAlmacen(ByVal campo As String, ByVal cadena As StringBuilder, ByVal longitud As Integer) As Integer
    End Function



    Public Shared Function PrepararCadena(ByVal cadena As String, ByVal longitud As Integer) As String
        Return cadena.PadRight(longitud - 1) & ControlChars.NullChar
    End Function

    Public Shared Function PrepararCadena(ByVal fecha As DateTime, ByVal longitud As Integer) As String
        Return PrepararCadena(fecha.ToString("MM/dd/yyyy"), longitud)
    End Function

    Public Shared Sub muestra_error(err As Integer)

        Dim ldescerr As New StringBuilder
        ldescerr.Append(ControlChars.NullChar, 300)

        If Not err = 0 Then
            AdminPAQSDK.fError(err, ldescerr, 300)
            MsgBox(ldescerr.ToString)
        End If

    End Sub

End Class

