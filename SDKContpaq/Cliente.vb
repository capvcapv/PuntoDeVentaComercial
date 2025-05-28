Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Text

Namespace SDKContpaq
    Public Class Cliente

        Public razonSocial As String
        Public rfc As String
        Public calle As String
        Public numExt As String
        Public numInt As String
        Public colonia As String
        Public cp As String
        Public municipio As String
        Public ciudad As String
        Public estado As String
        Public pais As String


        Public Function existeCliente(ByVal codigo As String) As Boolean
            If AdminPAQSDK.fBuscaCteProv(codigo) = 0 Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Function guardar() As Boolean

            If AdminPAQSDK.fInsertaCteProv() = 0 Then
                Dim id As New StringBuilder()
                id.Append(ControlChars.NullChar, 11)

                muestra_error(AdminPAQSDK.fSetDatoCteProv("CCODIGOC01", Me.rfc))
                muestra_error(AdminPAQSDK.fSetDatoCteProv("CRAZONSO01", Me.razonSocial))
                muestra_error(AdminPAQSDK.fSetDatoCteProv("CRFC", Me.rfc))
                muestra_error(AdminPAQSDK.fSetDatoCteProv("CFECHAALTA", "12/12/" & DateTime.Now.Year))
                muestra_error(AdminPAQSDK.fSetDatoCteProv("CIDMONEDA", "1"))
                muestra_error(AdminPAQSDK.fSetDatoCteProv("CLISTAPR01", "1"))
                muestra_error(AdminPAQSDK.fSetDatoCteProv("CTIPOCLI01", "1"))
                muestra_error(AdminPAQSDK.fSetDatoCteProv("CESTATUS", "1"))

                muestra_error(AdminPAQSDK.fGuardaCteProv())

                AdminPAQSDK.fBuscaCteProv(Me.rfc)
                AdminPAQSDK.fLeeDatoCteProv("CIDCLIEN01", id, 11)

                AdminPAQSDK.fInsertaDireccion()

                AdminPAQSDK.fSetDatoDireccion("CIDCATAL01", id.ToString())
                AdminPAQSDK.fSetDatoDireccion("CTIPOCAT01", "1")
                AdminPAQSDK.fSetDatoDireccion("CTIPODIR", "0")
                AdminPAQSDK.fSetDatoDireccion("CNOMBREC01", Me.calle)
                AdminPAQSDK.fSetDatoDireccion("CNUMEROE01", Me.numExt)
                AdminPAQSDK.fSetDatoDireccion("CNUMEROI01", Me.numInt)
                AdminPAQSDK.fSetDatoDireccion("CCOLONIA", Me.colonia)
                AdminPAQSDK.fSetDatoDireccion("CCODIGOP01", Me.cp)
                AdminPAQSDK.fSetDatoDireccion("CPAIS", Me.pais)
                AdminPAQSDK.fSetDatoDireccion("CESTADO", Me.estado)
                AdminPAQSDK.fSetDatoDireccion("CCIUDAD", Me.ciudad)
                AdminPAQSDK.fSetDatoDireccion("CMUNICIPIO", Me.municipio)

                AdminPAQSDK.fGuardaDireccion()

                Return True
            Else
                Return False
            End If

        End Function

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
