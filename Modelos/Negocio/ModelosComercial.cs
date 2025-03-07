
using Modelos.Utilerias;
using Newtonsoft.Json;
using PetaPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Negocio
{
	[PrimaryKey("CIDVALORCLASIFICACION")]
	public class Admclasificacionesvalores : DBContext<Admclasificacionesvalores>
	{

		public int CIDVALORCLASIFICACION { get; set; }



		public string CVALORCLASIFICACION { get; set; }


		public int CIDCLASIFICACION { get; set; }



		public string CCODIGOVALORCLASIFICACION { get; set; }



		public string CSEGCONT1 { get; set; }



		public string CSEGCONT2 { get; set; }



		public string CSEGCONT3 { get; set; }

		public override string ToString()
		{
			return CVALORCLASIFICACION;
		}

	}

	[PrimaryKey("CIDPROYECTO")]
	public class Admproyectos : DBContext<Admproyectos>
	{

		public int CIDPROYECTO { get; set; }



		public string CCODIGOPROYECTO { get; set; }



		public string CNOMBREPROYECTO { get; set; }


		public DateTime CFECHAALTA { get; set; }


		public DateTime CFECHABAJA { get; set; }


		public int CESTATUS { get; set; }


		public int CIDVALORCLASIFICACION1 { get; set; }


		public int CIDVALORCLASIFICACION2 { get; set; }


		public int CIDVALORCLASIFICACION3 { get; set; }


		public int CIDVALORCLASIFICACION4 { get; set; }


		public int CIDVALORCLASIFICACION5 { get; set; }


		public int CIDVALORCLASIFICACION6 { get; set; }


		public double CIMPORTE1 { get; set; }


		public double CIMPORTE2 { get; set; }



		public string CSEGCONT1 { get; set; }



		public string CSEGCONT2 { get; set; }



		public string CSEGCONT3 { get; set; }



		public string CTEXTOEXTRA1 { get; set; }



		public string CTEXTOEXTRA2 { get; set; }



		public string CTEXTOEXTRA3 { get; set; }


		public DateTime CFECHAEXTRA { get; set; }


		public double CIMPORTEEXTRA1 { get; set; }


		public double CIMPORTEEXTRA2 { get; set; }


		public double CIMPORTEEXTRA3 { get; set; }


		public double CIMPORTEEXTRA4 { get; set; }



		public string CTIMESTAMP { get; set; }


		public int CTIPOCATALOGO { get; set; }


		public int CIDCATALOGO { get; set; }

	}

	[PrimaryKey("CIDMOVIMIENTOPREPOLIZA")]
	public class Admmovimientosprepoliza : DBContext<Admmovimientosprepoliza>
	{

		public int CIDMOVIMIENTOPREPOLIZA { get; set; }


		public int CIDPREPOLIZA { get; set; }


		public int EJE { get; set; }


		public int PERIODO { get; set; }


		public int TIPOPOL { get; set; }


		public int NUMPOL { get; set; }


		public int MOVTO { get; set; }



		public string CUENTA { get; set; }


		public int TIPOMOV { get; set; }



		public string REFERENCIA { get; set; }


		public double IMPORTE { get; set; }



		public string DIARIO { get; set; }


		public double MONEDA { get; set; }



		public string CONCEPTO { get; set; }


		public DateTime FECHA { get; set; }



		public string SEGNEG { get; set; }

	}

	[PrimaryKey("CIDPADRECARACTERISTICA")]
	public class Admcaracteristicas : DBContext<Admcaracteristicas>
	{

		public int CIDPADRECARACTERISTICA { get; set; }



		public string CNOMBRECARACTERISTICA { get; set; }

	}

	[PrimaryKey("CIDCONSULTA")]
	public class Admvistasconsultas : DBContext<Admvistasconsultas>
	{

		public int CIDCONSULTA { get; set; }


		public int CIDSISTEMA { get; set; }


		public int CIDIDIOMA { get; set; }


		public int CIDMODULO { get; set; }


		public int CTIPO { get; set; }


		public int CCOLUMNASOCULTAR { get; set; }



		public string CNOMBRECONSULTA { get; set; }


		public string CSENTENCIASQL { get; set; }


		public int CIDEMPRESA { get; set; }



		public string CINDICE { get; set; }


		public int CESDESIS01 { get; set; }



		public string CFILTROS { get; set; }


		public int CINICIOARG { get; set; }


		public int CLIMITEARG { get; set; }


		public int CORDEN { get; set; }

	}

	[PrimaryKey("CIDVALORCARACTERISTICA")]
	public class Admcaracteristicasvalores : DBContext<Admcaracteristicasvalores>
	{

		public int CIDVALORCARACTERISTICA { get; set; }


		public int CIDPADRECARACTERISTICA { get; set; }



		public string CVALORCARACTERISTICA { get; set; }



		public string CNEMOCARACTERISTICA { get; set; }

	}

	[PrimaryKey("CCUENTA")]
	public class Nubecuentas : DBContext<Nubecuentas>
	{


		public string CCUENTA { get; set; }



		public string CNOMBRE { get; set; }


		public int CESTATUS { get; set; }


		public int CFLUJOEFECTIVO { get; set; }



		public string CTIPO { get; set; }



		public string CMONEDA { get; set; }


		public int CAFECTABLE { get; set; }



		public string CSEGMENTO { get; set; }

	}

	[PrimaryKey("CIDFOLDIG")]
	public class Admfoliosdigitales : DBContext<Admfoliosdigitales>
	{

		public int CIDFOLDIG { get; set; }


		public int CIDDOCTODE { get; set; }


		public int CIDCPTODOC { get; set; }


		public int CIDDOCTO { get; set; }


		public int CIDDOCALDI { get; set; }


		public int CIDFIRMARL { get; set; }


		public int CNOORDEN { get; set; }



		public string CSERIE { get; set; }


		public double CFOLIO { get; set; }


		public int CNOAPROB { get; set; }


		public DateTime CFECAPROB { get; set; }


		public int CESTADO { get; set; }


		public int CENTREGADO { get; set; }


		public DateTime CFECHAEMI { get; set; }



		public string CHORAEMI { get; set; }



		public string CEMAIL { get; set; }



		public string CARCHDIDIS { get; set; }


		public int CIDCPTOORI { get; set; }


		public DateTime CFECHACANC { get; set; }



		public string CHORACANC { get; set; }


		public int CESTRAD { get; set; }


		public string CCADPEDI { get; set; }



		public string CARCHCBB { get; set; }


		public DateTime CINIVIG { get; set; }


		public DateTime CFINVIG { get; set; }



		public string CTIPO { get; set; }



		public string CSERIEREC { get; set; }

		public double CFOLIOREC { get; set; }



		public string CRFC { get; set; }



		public string CRAZON { get; set; }


		public int CSISORIGEN { get; set; }


		public int CEJERPOL { get; set; }


		public int CPERPOL { get; set; }


		public int CTIPOPOL { get; set; }


		public int CNUMPOL { get; set; }



		public string CTIPOLDESC { get; set; }


		public double CTOTAL { get; set; }



		public string CALIASBDCT { get; set; }


		public int CCFDPRUEBA { get; set; }



		public string CDESESTADO { get; set; }


		public int CPAGADOBAN { get; set; }



		public string CDESPAGBAN { get; set; }



		public string CREFEREN01 { get; set; }



		public string COBSERVA01 { get; set; }



		public string CCODCONCBA { get; set; }



		public string CDESCONCBA { get; set; }



		public string CNUMCTABAN { get; set; }



		public string CFOLIOBAN { get; set; }


		public int CIDDOCDEBA { get; set; }



		public string CUSUAUTBAN { get; set; }



		public string CUUID { get; set; }



		public string CUSUBAN01 { get; set; }


		public int CAUTUSBA01 { get; set; }



		public string CUSUBAN02 { get; set; }


		public int CAUTUSBA02 { get; set; }



		public string CUSUBAN03 { get; set; }


		public int CAUTUSBA03 { get; set; }



		public string CDESCAUT01 { get; set; }



		public string CDESCAUT02 { get; set; }



		public string CDESCAUT03 { get; set; }


		public int CERRORVAL { get; set; }



		public string CACUSECAN { get; set; }



		public string CIDDOCTODSL { get; set; }

	}

	[PrimaryKey("CIDASIENTOCONTABLE")]
	public class Admasientoscontables : DBContext<Admasientoscontables>
	{

		public int CIDASIENTOCONTABLE { get; set; }



		public string CNUMEROASIENTOCONTABLE { get; set; }



		public string CNOMBREASIENTOCONTABLE { get; set; }


		public int CFRECUENCIA { get; set; }


		public int CORIGENFECHA { get; set; }


		public int CTIPOPOLIZA { get; set; }


		public int CORIGENNUMERO { get; set; }


		public int CORIGENCONCEPTO { get; set; }



		public string CCONCEPTO { get; set; }



		public string CDIARIO { get; set; }



		public string CTIMESTAMP { get; set; }

	}

	[PrimaryKey("CCODIGO")]
	public class Nubediarios : DBContext<Nubediarios>
	{


		public string CCODIGO { get; set; }



		public string CNOMBRE { get; set; }


		public int CTIPO { get; set; }

	}

	[PrimaryKey("CIDSERIECAPA")]
	public class Admmovtosinvfisicoserieca : DBContext<Admmovtosinvfisicoserieca>
	{

		public int CIDSERIECAPA { get; set; }


		public int CIDMOVTOINVENTARIOFISICO { get; set; }


		public int CIDPRODUCTO { get; set; }



		public string CNUMEROSERIE { get; set; }


		public int CIDALMACEN { get; set; }


		public int CTIPO { get; set; }



		public string CNUMEROLOTE { get; set; }


		public DateTime CFECHACADUCIDAD { get; set; }


		public DateTime CFECHAFABRICACION { get; set; }



		public string CPEDIMENTO { get; set; }



		public string CADUANA { get; set; }


		public DateTime CFECHAPEDIMENTO { get; set; }


		public double CTIPOCAMBIO { get; set; }


		public double CCANTIDAD { get; set; }


		public int CIDCAPA { get; set; }

	}

	[PrimaryKey("CIDDIRECCION")]
	public class Admdomicilios : DBContext<Admdomicilios>
	{

		public int CIDDIRECCION { get; set; }


		public int CIDCATALOGO { get; set; }


		public int CTIPOCATALOGO { get; set; }


		public int CTIPODIRECCION { get; set; }



		public string CNOMBRECALLE { get; set; }



		public string CNUMEROEXTERIOR { get; set; }



		public string CNUMEROINTERIOR { get; set; }



		public string CCOLONIA { get; set; }



		public string CCODIGOPOSTAL { get; set; }



		public string CTELEFONO1 { get; set; }



		public string CTELEFONO2 { get; set; }



		public string CTELEFONO3 { get; set; }



		public string CTELEFONO4 { get; set; }



		public string CEMAIL { get; set; }



		public string CDIRECCIONWEB { get; set; }



		public string CPAIS { get; set; }



		public string CESTADO { get; set; }



		public string CCIUDAD { get; set; }



		public string CTEXTOEXTRA { get; set; }



		public string CTIMESTAMP { get; set; }



		public string CMUNICIPIO { get; set; }



		public string CSUCURSAL { get; set; }

	}

	[PrimaryKey("CIDAUTOINCSQL")]
	public class Admvistastablas : DBContext<Admvistastablas>
	{

		public int CIDAUTOINCSQL { get; set; }


		public int CIDSISTEMA { get; set; }


		public int CIDIDIOMA { get; set; }


		public int CIDMODULO { get; set; }



		public string CNOMBRENATIVOTABLA { get; set; }



		public string CNOMBREAMIGABLETABLA { get; set; }


		public int CORDEN { get; set; }



		public string CINDICES { get; set; }

	}

	[PrimaryKey("CIDMOVIMIENTOCONTABLE")]
	public class Admmovimientoscontables : DBContext<Admmovimientoscontables>
	{

		public int CIDMOVIMIENTOCONTABLE { get; set; }


		public int CIDASIENTOCONTABLE { get; set; }



		public string CCUENTA { get; set; }


		public int CTIPOMOVIMIENTO { get; set; }


		public double CIMPORTEBASE { get; set; }


		public double CPORCENTAJE { get; set; }


		public int CORIGENREFERENCIA { get; set; }



		public string CREFERENCIA { get; set; }


		public int CORIGENDIARIO { get; set; }



		public string CDIARIO { get; set; }


		public int CORIGENCONCEPTO { get; set; }



		public string CCONCEPTO { get; set; }



		public string CTIMESTAMP { get; set; }


		public int CSUMARIZ { get; set; }


		public int CSUPMOVS0 { get; set; }


		public int CORISEGNEG { get; set; }



		public string CSEGNEG { get; set; }


		public int CIMPMONEXT { get; set; }


		public int CIMPMONDOC { get; set; }


		public int CCOMPLEMEN { get; set; }

	}

	[PrimaryKey("CIDCUENTA")]
	public class Admcuentasbancarias : DBContext<Admcuentasbancarias>
	{

		public int CIDCUENTA { get; set; }



		public string CACCOUNTID { get; set; }



		public string CNUMEROCUENTA { get; set; }



		public string CNOMBRECUENTA { get; set; }


		public DateTime CFECHAALTA { get; set; }


		public DateTime CFECHABAJA { get; set; }


		public int CESTATUS { get; set; }



		public string CCLABE { get; set; }



		public string CCLAVE { get; set; }



		public string CSEGCONT01 { get; set; }



		public string CSEGCONT02 { get; set; }



		public string CSEGCONT03 { get; set; }



		public string CTEXTOEXTRA1 { get; set; }



		public string CTEXTOEXTRA2 { get; set; }



		public string CTEXTOEXTRA3 { get; set; }


		public DateTime CFECHAEXTRA { get; set; }


		public double CIMPORTEEXTRA1 { get; set; }


		public double CIMPORTEEXTRA2 { get; set; }


		public double CIMPORTEEXTRA3 { get; set; }


		public double CIMPORTEEXTRA4 { get; set; }



		public string CTIMESTAMP { get; set; }


		public int CIDMONEDA { get; set; }


		public int CIDCATALOGO { get; set; }


		public int CTIPOCATALOGO { get; set; }



		public string CNOMBANEXT { get; set; }



		public string CRFCBANCO { get; set; }

	}

	[PrimaryKey("CIDAUTOINCSQL")]
	public class Admvistascampos : DBContext<Admvistascampos>
	{

		public int CIDAUTOINCSQL { get; set; }


		public int CIDSISTEMA { get; set; }


		public int CIDIDIOMA { get; set; }


		public int CIDMODULO { get; set; }



		public string CNOMBRENATIVOTABLA { get; set; }



		public string CNOMBRENATIVOCAMPO { get; set; }



		public string CNOMBREAMIGABLECAMPO { get; set; }


		public int CANCHOCA01 { get; set; }


		public int CCAMPOOC01 { get; set; }


		public int CCAMPOOR01 { get; set; }


		public int CTIPOCAMPO { get; set; }


		public int CCALCULADO { get; set; }


		public int CDECIMALES { get; set; }


		public int CALINEAR { get; set; }


		public int CFORMATEAR { get; set; }

	}

	[PrimaryKey("CIDAGENTE")]
	public class Admagentes : DBContext<Admagentes>
	{

		public int CIDAGENTE { get; set; }



		public string CCODIGOAGENTE { get; set; }



		public string CNOMBREAGENTE { get; set; }


		public DateTime CFECHAALTAAGENTE { get; set; }


		public int CTIPOAGENTE { get; set; }


		public double CCOMISIONVENTAAGENTE { get; set; }


		public double CCOMISIONCOBROAGENTE { get; set; }


		public int CIDCLIENTE { get; set; }


		public int CIDPROVEEDOR { get; set; }


		public int CIDVALORCLASIFICACION1 { get; set; }


		public int CIDVALORCLASIFICACION2 { get; set; }


		public int CIDVALORCLASIFICACION3 { get; set; }


		public int CIDVALORCLASIFICACION4 { get; set; }


		public int CIDVALORCLASIFICACION5 { get; set; }


		public int CIDVALORCLASIFICACION6 { get; set; }



		public string CSEGCONTAGENTE { get; set; }



		public string CTEXTOEXTRA1 { get; set; }



		public string CTEXTOEXTRA2 { get; set; }



		public string CTEXTOEXTRA3 { get; set; }


		public DateTime CFECHAEXTRA { get; set; }


		public double CIMPORTEEXTRA1 { get; set; }


		public double CIMPORTEEXTRA2 { get; set; }


		public double CIMPORTEEXTRA3 { get; set; }


		public double CIMPORTEEXTRA4 { get; set; }



		public string CTIMESTAMP { get; set; }



		public string CSCAGENTE2 { get; set; }



		public string CSCAGENTE3 { get; set; }

        public override string ToString()
        {
			return CNOMBREAGENTE;
        }

		public override bool Equals(object obj)
		{
			if (obj == null || GetType() != obj.GetType())
				return false;

			Admagentes otroAgente = (Admagentes)obj;
			return (CIDAGENTE == otroAgente.CIDAGENTE);
		}

		// Opcionalmente, también puedes sobrescribir el método GetHashCode para mejorar el rendimiento en colecciones hash.
		public override int GetHashCode()
		{
			return CIDAGENTE.GetHashCode();
		}

	}

	[PrimaryKey("CIDTIPOACUMULADO")]
	public class Admacumuladostipos : DBContext<Admacumuladostipos>
	{

		public int CIDTIPOACUMULADO { get; set; }



		public string CNOMBRE { get; set; }


		public int CTIPOOWNER1 { get; set; }


		public int CTIPOOWNER2 { get; set; }


		public int CTIPOACTUALIZACION { get; set; }


		public int CTIPOMONEDA { get; set; }

	}

	[PrimaryKey("CIDAUTOINCSQL")]
	public class Admvistaspormodulo : DBContext<Admvistaspormodulo>
	{

		public int CIDAUTOINCSQL { get; set; }


		public int CIDMODULO { get; set; }


		public int CIDSISTEMA { get; set; }


		public int CIDIDIOMA { get; set; }



		public string CNOMBREMODULO { get; set; }


		public int CASPECTO { get; set; }


		public int CACTUALIZA { get; set; }

	}

	[PrimaryKey("CIDEJERCICIO")]
	public class Admejercicios : DBContext<Admejercicios>
	{

		public int CIDEJERCICIO { get; set; }


		public int CNUMEROEJERCICIO { get; set; }


		public DateTime CFECINIPERIODO1 { get; set; }


		public DateTime CFECINIPERIODO2 { get; set; }


		public DateTime CFECINIPERIODO3 { get; set; }


		public DateTime CFECINIPERIODO4 { get; set; }


		public DateTime CFECINIPERIODO5 { get; set; }


		public DateTime CFECINIPERIODO6 { get; set; }


		public DateTime CFECINIPERIODO7 { get; set; }


		public DateTime CFECINIPERIODO8 { get; set; }


		public DateTime CFECINIPERIODO9 { get; set; }


		public DateTime CFECINIPERIODO10 { get; set; }


		public DateTime CFECINIPERIODO11 { get; set; }


		public DateTime CFECINIPERIODO12 { get; set; }


		public DateTime CFECHAFINAL { get; set; }


		public int CEJERCICIO { get; set; }

	}

	[PrimaryKey("CIDCAPA")]
	public class Admcapasproducto : DBContext<Admcapasproducto>
	{

		public int CIDCAPA { get; set; }


		public int CIDALMACEN { get; set; }


		public int CIDPRODUCTO { get; set; }


		public DateTime CFECHA { get; set; }


		public int CTIPOCAPA { get; set; }



		public string CNUMEROLOTE { get; set; }


		public DateTime CFECHACADUCIDAD { get; set; }


		public DateTime CFECHAFABRICACION { get; set; }



		public string CPEDIMENTO { get; set; }



		public string CADUANA { get; set; }


		public DateTime CFECHAPEDIMENTO { get; set; }


		public double CTIPOCAMBIO { get; set; }


		public double CEXISTENCIA { get; set; }


		public double CCOSTO { get; set; }


		public int CIDCAPAORIGEN { get; set; }



		public string CTIMESTAMP { get; set; }


		public int CNUMADUANA { get; set; }



		public string CCLAVESAT { get; set; }

	}

	[PrimaryKey("CIDALMACEN")]
	public class Admalmacenes : DBContext<Admalmacenes>
	{

		public int CIDALMACEN { get; set; }



		public string CCODIGOALMACEN { get; set; }



		public string CNOMBREALMACEN { get; set; }


		public DateTime CFECHAALTAALMACEN { get; set; }


		public int CIDVALORCLASIFICACION1 { get; set; }


		public int CIDVALORCLASIFICACION2 { get; set; }


		public int CIDVALORCLASIFICACION3 { get; set; }


		public int CIDVALORCLASIFICACION4 { get; set; }


		public int CIDVALORCLASIFICACION5 { get; set; }


		public int CIDVALORCLASIFICACION6 { get; set; }



		public string CSEGCONTALMACEN { get; set; }



		public string CTEXTOEXTRA1 { get; set; }



		public string CTEXTOEXTRA2 { get; set; }



		public string CTEXTOEXTRA3 { get; set; }


		public DateTime CFECHAEXTRA { get; set; }


		public double CIMPORTEEXTRA1 { get; set; }


		public double CIMPORTEEXTRA2 { get; set; }


		public double CIMPORTEEXTRA3 { get; set; }


		public double CIMPORTEEXTRA4 { get; set; }


		public int CBANDOMICILIO { get; set; }



		public string CTIMESTAMP { get; set; }



		public string CSCALMAC2 { get; set; }



		public string CSCALMAC3 { get; set; }


		public int CSISTORIG { get; set; }

	}

	[PrimaryKey("CIDCONCEPTODOCUMENTO")]
	public class Admconceptosback : DBContext<Admconceptosback>
	{

		public int CIDCONCEPTODOCUMENTO { get; set; }



		public string CCODIGOCONCEPTO { get; set; }



		public string CNOMBRECONCEPTO { get; set; }


		public int CIDDOCUMENTODE { get; set; }


		public int CNATURALEZA { get; set; }


		public int CDOCTOACREDITO { get; set; }


		public int CTIPOFOLIO { get; set; }


		public int CMAXIMOMOVTOS { get; set; }


		public int CCREACLIENTE { get; set; }


		public int CSUMARPROMOCIONES { get; set; }



		public string CFORMAPREIMPRESA { get; set; }


		public int CORDENCALCULO { get; set; }


		public int CUSANOMBRECTEPROV { get; set; }


		public int CUSARFC { get; set; }


		public int CUSAFECHAVENCIMIENTO { get; set; }


		public int CUSAFECHAENTREGARECEPCION { get; set; }


		public int CUSAMONEDA { get; set; }


		public int CUSATIPOCAMBIO { get; set; }


		public int CUSACODIGOAGENTE { get; set; }


		public int CUSANOMBREAGENTE { get; set; }


		public int CUSADIRECCION { get; set; }


		public int CUSAREFERENCIA { get; set; }



		public string CSERIEPOROMISION { get; set; }


		public int CANCHOCODIGOPRODUCTO { get; set; }


		public int CUSANOMBREPRODUCTO { get; set; }


		public int CANCHONOMBREPRODUCTO { get; set; }


		public int CUSAALMACEN { get; set; }


		public int CANCHOCODIGOALMACEN { get; set; }


		public int CANCHOIMPORTES { get; set; }


		public int CANCHOPORCENTAJES { get; set; }


		public int CANCHOUNIDADPESOMEDIDA { get; set; }


		public int CUSAPRECIO { get; set; }


		public int CIDFORMULAPRECIO { get; set; }


		public int CUSACOSTOCAPTURADO { get; set; }


		public int CIDFORMULACOSTOCAPTURADO { get; set; }


		public int CUSAEXISTENCIA { get; set; }


		public int CUSANETO { get; set; }


		public int CIDFORMULANETO { get; set; }


		public int CUSAPORCENTAJEIMPUESTO1 { get; set; }


		public int CIDFORMULAPORCIMPUESTO1 { get; set; }


		public int CUSAIMPUESTO1 { get; set; }


		public int CIDFORMULAIMPUESTO1 { get; set; }


		public int CUSAPORCENTAJEIMPUESTO2 { get; set; }


		public int CIDFORMULAPORCIMPUESTO2 { get; set; }


		public int CUSAIMPUESTO2 { get; set; }


		public int CIDFORMULAIMPUESTO2 { get; set; }


		public int CUSAPORCENTAJEIMPUESTO3 { get; set; }


		public int CIDFORMULAPORCIMPUESTO3 { get; set; }


		public int CUSAIMPUESTO3 { get; set; }


		public int CIDFORMULAIMPUESTO3 { get; set; }


		public int CUSAPORCENTAJERETENCION1 { get; set; }


		public int CIDFORMULAPORCRETENCION1 { get; set; }


		public int CUSARETENCION1 { get; set; }


		public int CIDFORMULARETENCION1 { get; set; }


		public int CUSAPORCENTAJERETENCION2 { get; set; }


		public int CIDFORMULAPORCRETENCION2 { get; set; }


		public int CUSARETENCION2 { get; set; }


		public int CIDFORMULARETENCION2 { get; set; }


		public int CUSAPORCENTAJEDESCUENTO1 { get; set; }


		public int CIDFORMULAPORCDESCUENTO1 { get; set; }


		public int CUSADESCUENTO1 { get; set; }


		public int CIDFORMULADESCUENTO1 { get; set; }


		public int CUSAPORCENTAJEDESCUENTO2 { get; set; }


		public int CIDFORMULAPORCDESCUENTO2 { get; set; }


		public int CUSADESCUENTO2 { get; set; }


		public int CIDFORMULADESCUENTO2 { get; set; }


		public int CUSAPORCENTAJEDESCUENTO3 { get; set; }


		public int CIDFORMULAPORCDESCUENTO3 { get; set; }


		public int CUSADESCUENTO3 { get; set; }


		public int CIDFORMULADESCUENTO3 { get; set; }


		public int CUSAPORCENTAJEDESCUENTO4 { get; set; }


		public int CIDFORMULAPORCDESCUENTO4 { get; set; }


		public int CUSADESCUENTO4 { get; set; }


		public int CIDFORMULADESCUENTO4 { get; set; }


		public int CUSAPORCENTAJEDESCUENTO5 { get; set; }


		public int CIDFORMULAPORCDESCUENTO5 { get; set; }


		public int CUSADESCUENTO5 { get; set; }


		public int CIDFORMULADESCUENTO5 { get; set; }


		public int CUSATOTAL { get; set; }


		public int CANCHOREFERENCIA { get; set; }


		public int CUSACLASIFICACIONMOVTO { get; set; }


		public int CANCHOVALORCLASIFICACION { get; set; }


		public int CIDFORMULATOTAL { get; set; }


		public int CUSADESCUENTODOC1 { get; set; }


		public int CIDFORMULADESDOC1 { get; set; }


		public int CUSADESCUENTODOC2 { get; set; }


		public int CIDFORMULADESDOC2 { get; set; }


		public int CUSAGASTO1 { get; set; }


		public int CIDFORMULAGASTO1 { get; set; }


		public int CUSAGASTO2 { get; set; }


		public int CIDFORMULAGASTO2 { get; set; }


		public int CUSAGASTO3 { get; set; }


		public int CIDFORMULAGASTO3 { get; set; }


		public int CUSATEXTOEXTRA1 { get; set; }


		public int CUSATEXTOEXTRA2 { get; set; }


		public int CUSATEXTOEXTRA3 { get; set; }


		public int CANCHOTEXTOEXTRA { get; set; }


		public int CUSAFECHAEXTRA { get; set; }


		public int CANCHOFECHAEXTRA { get; set; }


		public int CUSAIMPORTEEXTRA1 { get; set; }


		public int CIDFORMULAEXTRA1 { get; set; }


		public int CUSAIMPORTEEXTRA2 { get; set; }


		public int CIDFORMULAEXTRA2 { get; set; }


		public int CUSAIMPORTEEXTRA3 { get; set; }


		public int CIDFORMULAEXTRA3 { get; set; }


		public int CUSAIMPORTEEXTRA4 { get; set; }


		public int CIDFORMULAEXTRA4 { get; set; }


		public int CUSATEXTOEXTRA1DOC { get; set; }


		public int CUSATEXTOEXTRA2DOC { get; set; }


		public int CUSATEXTOEXTRA3DOC { get; set; }


		public int CUSAFECHAEXTRADOC { get; set; }


		public int CUSAIMPORTEEXTRA1DOC { get; set; }


		public int CUSAIMPORTEEXTRA2DOC { get; set; }


		public int CUSAIMPORTEEXTRA3DOC { get; set; }


		public int CUSAIMPORTEEXTRA4DOC { get; set; }


		public int CUSAEXTRACOMOGASTO { get; set; }


		public int CUSAOBSERVACIONES { get; set; }


		public int CPRESENTAFISCAL { get; set; }


		public int CPRESENTAREFERENCIA { get; set; }


		public int CPRESENTACONDICIONES { get; set; }


		public int CPRESENTAENVIO { get; set; }


		public int CPRESENTADETALLE { get; set; }


		public int CPRESENTAIMPRIMIR { get; set; }


		public int CPRESENTAPAGAR { get; set; }


		public int CPRESENTASALDAR { get; set; }


		public int CPRESENTADOCUMENTAR { get; set; }


		public int CPRESENTAGASTOSCOMPRA { get; set; }



		public string CSEGCONTCONCEPTO { get; set; }


		public int CBANENCABEZADO { get; set; }


		public int CBANMOVIMIENTO { get; set; }


		public int CBANDESCUENTO { get; set; }


		public int CBANIMPUESTO { get; set; }


		public int CBANACCIONAUTOMATICA { get; set; }



		public string CTIMESTAMP { get; set; }


		public double CNOFOLIO { get; set; }


		public int CIDPROCESOSEGURIDAD { get; set; }


		public int CUSAGTOMOV { get; set; }


		public int CUSASCMOV { get; set; }


		public int CIDASTOCON { get; set; }



		public string CSCCPTO2 { get; set; }



		public string CSCCPTO3 { get; set; }



		public string CSCMOVTO { get; set; }


		public int CIDCONAUTO { get; set; }


		public int CIDALMASUM { get; set; }


		public int CUSACOMVTA { get; set; }


		public int CIDPRSEG02 { get; set; }


		public int CIDPRSEG03 { get; set; }


		public int CIDPRSEG04 { get; set; }


		public int CIDPRSEG05 { get; set; }


		public int CFORMAAJ01 { get; set; }


		public int CIDPRSEG06 { get; set; }


		public int CAPFORMULA { get; set; }


		public int CESCFD { get; set; }


		public int CIDFIRMARL { get; set; }


		public int CGDAPASSW { get; set; }


		public int CEMITEYENT { get; set; }


		public int CBANCFD { get; set; }



		public string CREPIMPCFD { get; set; }


		public int CIDDIRSUCU { get; set; }


		public int CBANDIRSUC { get; set; }


		public int CVERFACELE { get; set; }


		public int CCALFECHAS { get; set; }


		public int CTIPCAMTR1 { get; set; }


		public int CTIPCAMTR2 { get; set; }


		public int CCONSOLIDA { get; set; }


		public int CENVIODIG { get; set; }


		public int CBANTRANS { get; set; }


		public int CCONFNOAPR { get; set; }


		public int CNOAPROB { get; set; }


		public int CAUTOIMPR { get; set; }


		public int CRECIBECFD { get; set; }


		public int CSISTORIG { get; set; }


		public int CIDCPTODE1 { get; set; }


		public int CIDCPTODE2 { get; set; }


		public int CIDCPTODE3 { get; set; }



		public string CPLAMIGCFD { get; set; }


		public int CIDPRSEG07 { get; set; }


		public int CRESERVADO { get; set; }


		public int CVERREFER { get; set; }


		public int CVERDOCORI { get; set; }


		public int CCBB { get; set; }


		public int CCARTAPOR { get; set; }


		public int CCOMPDONAT { get; set; }


		public int COBSXML { get; set; }



		public string CRUTAENTREGA { get; set; }



		public string CPREFIJOCONCEPTO { get; set; }



		public string CREGIMFISC { get; set; }


		public int CCOMPEDUCA { get; set; }



		public string CMETODOPAG { get; set; }



		public string CVERESQUE { get; set; }



		public string CIDFIRMADSL { get; set; }



		public string CORDENCAPTURA { get; set; }



		public string CCLAVESAT { get; set; }

	}

	[PrimaryKey("CIDCONCEPTOTIPOACUMULADO")]
	public class Admasocacumconceptos : DBContext<Admasocacumconceptos>
	{

		public int CIDCONCEPTOTIPOACUMULADO { get; set; }


		public int CIDCONCEPTODOCUMENTO { get; set; }


		public int CIDTIPOACUMULADO { get; set; }


		public int CIMPORTEMODELO { get; set; }


		public int CSUMARESTA { get; set; }

	}

	[PrimaryKey("CIDRELACION")]
	public class Admvistasrelaciones : DBContext<Admvistasrelaciones>
	{

		public int CIDRELACION { get; set; }


		public int CIDSISTEMA { get; set; }


		public int CIDIDIOMA { get; set; }



		public string CNOMBRENATIVOTABLA1 { get; set; }



		public string CNOMBRENATIVOTABLA2 { get; set; }



		public string CNOMBRERELACION { get; set; }



		public string CSENTENCIAENLACE { get; set; }



		public string CCAMPONA01 { get; set; }



		public string CFILTRO { get; set; }



		public string CTABLAREL1 { get; set; }



		public string CTABLAREL2 { get; set; }



		public string CFILTROAUX { get; set; }

	}

	[PrimaryKey("CIDCONCEPTODOCUMENTO")]
	public class Admconceptos : DBContext<Admconceptos>
	{

		public int CIDCONCEPTODOCUMENTO { get; set; }



		public string CCODIGOCONCEPTO { get; set; }



		public string CNOMBRECONCEPTO { get; set; }


		public int CIDDOCUMENTODE { get; set; }


		public int CNATURALEZA { get; set; }


		public int CDOCTOACREDITO { get; set; }


		public int CTIPOFOLIO { get; set; }


		public int CMAXIMOMOVTOS { get; set; }


		public int CCREACLIENTE { get; set; }


		public int CSUMARPROMOCIONES { get; set; }



		public string CFORMAPREIMPRESA { get; set; }


		public int CORDENCALCULO { get; set; }


		public int CUSANOMBRECTEPROV { get; set; }


		public int CUSARFC { get; set; }


		public int CUSAFECHAVENCIMIENTO { get; set; }


		public int CUSAFECHAENTREGARECEPCION { get; set; }


		public int CUSAMONEDA { get; set; }


		public int CUSATIPOCAMBIO { get; set; }


		public int CUSACODIGOAGENTE { get; set; }


		public int CUSANOMBREAGENTE { get; set; }


		public int CUSADIRECCION { get; set; }


		public int CUSAREFERENCIA { get; set; }



		public string CSERIEPOROMISION { get; set; }


		public int CANCHOCODIGOPRODUCTO { get; set; }


		public int CUSANOMBREPRODUCTO { get; set; }


		public int CANCHONOMBREPRODUCTO { get; set; }


		public int CUSAALMACEN { get; set; }


		public int CANCHOCODIGOALMACEN { get; set; }


		public int CANCHOIMPORTES { get; set; }


		public int CANCHOPORCENTAJES { get; set; }


		public int CANCHOUNIDADPESOMEDIDA { get; set; }


		public int CUSAPRECIO { get; set; }


		public int CIDFORMULAPRECIO { get; set; }


		public int CUSACOSTOCAPTURADO { get; set; }


		public int CIDFORMULACOSTOCAPTURADO { get; set; }


		public int CUSAEXISTENCIA { get; set; }


		public int CUSANETO { get; set; }


		public int CIDFORMULANETO { get; set; }


		public int CUSAPORCENTAJEIMPUESTO1 { get; set; }


		public int CIDFORMULAPORCIMPUESTO1 { get; set; }


		public int CUSAIMPUESTO1 { get; set; }


		public int CIDFORMULAIMPUESTO1 { get; set; }


		public int CUSAPORCENTAJEIMPUESTO2 { get; set; }


		public int CIDFORMULAPORCIMPUESTO2 { get; set; }


		public int CUSAIMPUESTO2 { get; set; }


		public int CIDFORMULAIMPUESTO2 { get; set; }


		public int CUSAPORCENTAJEIMPUESTO3 { get; set; }


		public int CIDFORMULAPORCIMPUESTO3 { get; set; }


		public int CUSAIMPUESTO3 { get; set; }


		public int CIDFORMULAIMPUESTO3 { get; set; }


		public int CUSAPORCENTAJERETENCION1 { get; set; }


		public int CIDFORMULAPORCRETENCION1 { get; set; }


		public int CUSARETENCION1 { get; set; }


		public int CIDFORMULARETENCION1 { get; set; }


		public int CUSAPORCENTAJERETENCION2 { get; set; }


		public int CIDFORMULAPORCRETENCION2 { get; set; }


		public int CUSARETENCION2 { get; set; }


		public int CIDFORMULARETENCION2 { get; set; }


		public int CUSAPORCENTAJEDESCUENTO1 { get; set; }


		public int CIDFORMULAPORCDESCUENTO1 { get; set; }


		public int CUSADESCUENTO1 { get; set; }


		public int CIDFORMULADESCUENTO1 { get; set; }


		public int CUSAPORCENTAJEDESCUENTO2 { get; set; }


		public int CIDFORMULAPORCDESCUENTO2 { get; set; }


		public int CUSADESCUENTO2 { get; set; }


		public int CIDFORMULADESCUENTO2 { get; set; }


		public int CUSAPORCENTAJEDESCUENTO3 { get; set; }


		public int CIDFORMULAPORCDESCUENTO3 { get; set; }


		public int CUSADESCUENTO3 { get; set; }


		public int CIDFORMULADESCUENTO3 { get; set; }


		public int CUSAPORCENTAJEDESCUENTO4 { get; set; }


		public int CIDFORMULAPORCDESCUENTO4 { get; set; }


		public int CUSADESCUENTO4 { get; set; }


		public int CIDFORMULADESCUENTO4 { get; set; }


		public int CUSAPORCENTAJEDESCUENTO5 { get; set; }


		public int CIDFORMULAPORCDESCUENTO5 { get; set; }


		public int CUSADESCUENTO5 { get; set; }


		public int CIDFORMULADESCUENTO5 { get; set; }


		public int CUSATOTAL { get; set; }


		public int CANCHOREFERENCIA { get; set; }


		public int CUSACLASIFICACIONMOVTO { get; set; }


		public int CANCHOVALORCLASIFICACION { get; set; }


		public int CIDFORMULATOTAL { get; set; }


		public int CUSADESCUENTODOC1 { get; set; }


		public int CIDFORMULADESDOC1 { get; set; }


		public int CUSADESCUENTODOC2 { get; set; }


		public int CIDFORMULADESDOC2 { get; set; }


		public int CUSAGASTO1 { get; set; }


		public int CIDFORMULAGASTO1 { get; set; }


		public int CUSAGASTO2 { get; set; }


		public int CIDFORMULAGASTO2 { get; set; }


		public int CUSAGASTO3 { get; set; }


		public int CIDFORMULAGASTO3 { get; set; }


		public int CUSATEXTOEXTRA1 { get; set; }


		public int CUSATEXTOEXTRA2 { get; set; }


		public int CUSATEXTOEXTRA3 { get; set; }


		public int CANCHOTEXTOEXTRA { get; set; }


		public int CUSAFECHAEXTRA { get; set; }


		public int CANCHOFECHAEXTRA { get; set; }


		public int CUSAIMPORTEEXTRA1 { get; set; }


		public int CIDFORMULAEXTRA1 { get; set; }


		public int CUSAIMPORTEEXTRA2 { get; set; }


		public int CIDFORMULAEXTRA2 { get; set; }


		public int CUSAIMPORTEEXTRA3 { get; set; }


		public int CIDFORMULAEXTRA3 { get; set; }


		public int CUSAIMPORTEEXTRA4 { get; set; }


		public int CIDFORMULAEXTRA4 { get; set; }


		public int CUSATEXTOEXTRA1DOC { get; set; }


		public int CUSATEXTOEXTRA2DOC { get; set; }


		public int CUSATEXTOEXTRA3DOC { get; set; }


		public int CUSAFECHAEXTRADOC { get; set; }


		public int CUSAIMPORTEEXTRA1DOC { get; set; }


		public int CUSAIMPORTEEXTRA2DOC { get; set; }


		public int CUSAIMPORTEEXTRA3DOC { get; set; }


		public int CUSAIMPORTEEXTRA4DOC { get; set; }


		public int CUSAEXTRACOMOGASTO { get; set; }


		public int CUSAOBSERVACIONES { get; set; }


		public int CPRESENTAFISCAL { get; set; }


		public int CPRESENTAREFERENCIA { get; set; }


		public int CPRESENTACONDICIONES { get; set; }


		public int CPRESENTAENVIO { get; set; }


		public int CPRESENTADETALLE { get; set; }


		public int CPRESENTAIMPRIMIR { get; set; }


		public int CPRESENTAPAGAR { get; set; }


		public int CPRESENTASALDAR { get; set; }


		public int CPRESENTADOCUMENTAR { get; set; }


		public int CPRESENTAGASTOSCOMPRA { get; set; }



		public string CSEGCONTCONCEPTO { get; set; }


		public int CBANENCABEZADO { get; set; }


		public int CBANMOVIMIENTO { get; set; }


		public int CBANDESCUENTO { get; set; }


		public int CBANIMPUESTO { get; set; }


		public int CBANACCIONAUTOMATICA { get; set; }



		public string CTIMESTAMP { get; set; }


		public double CNOFOLIO { get; set; }


		public int CIDPROCESOSEGURIDAD { get; set; }


		public int CUSAGTOMOV { get; set; }


		public int CUSASCMOV { get; set; }


		public int CIDASTOCON { get; set; }



		public string CSCCPTO2 { get; set; }



		public string CSCCPTO3 { get; set; }



		public string CSCMOVTO { get; set; }


		public int CIDCONAUTO { get; set; }


		public int CIDALMASUM { get; set; }


		public int CUSACOMVTA { get; set; }


		public int CIDPRSEG02 { get; set; }


		public int CIDPRSEG03 { get; set; }


		public int CIDPRSEG04 { get; set; }


		public int CIDPRSEG05 { get; set; }


		public int CFORMAAJ01 { get; set; }


		public int CIDPRSEG06 { get; set; }


		public int CAPFORMULA { get; set; }


		public int CESCFD { get; set; }


		public int CIDFIRMARL { get; set; }


		public int CGDAPASSW { get; set; }


		public int CEMITEYENT { get; set; }


		public int CBANCFD { get; set; }



		public string CREPIMPCFD { get; set; }


		public int CIDDIRSUCU { get; set; }


		public int CBANDIRSUC { get; set; }


		public int CVERFACELE { get; set; }


		public int CCALFECHAS { get; set; }


		public int CTIPCAMTR1 { get; set; }


		public int CTIPCAMTR2 { get; set; }


		public int CCONSOLIDA { get; set; }


		public int CENVIODIG { get; set; }


		public int CBANTRANS { get; set; }


		public int CCONFNOAPR { get; set; }


		public int CNOAPROB { get; set; }


		public int CAUTOIMPR { get; set; }


		public int CRECIBECFD { get; set; }


		public int CSISTORIG { get; set; }


		public int CIDCPTODE1 { get; set; }


		public int CIDCPTODE2 { get; set; }


		public int CIDCPTODE3 { get; set; }



		public string CPLAMIGCFD { get; set; }


		public int CIDPRSEG07 { get; set; }


		public int CRESERVADO { get; set; }


		public int CVERREFER { get; set; }


		public int CVERDOCORI { get; set; }


		public int CCBB { get; set; }


		public int CCARTAPOR { get; set; }


		public int CCOMPDONAT { get; set; }


		public int COBSXML { get; set; }



		public string CRUTAENTREGA { get; set; }



		public string CPREFIJOCONCEPTO { get; set; }



		public string CREGIMFISC { get; set; }


		public int CCOMPEDUCA { get; set; }



		public string CMETODOPAG { get; set; }



		public string CVERESQUE { get; set; }



		public string CIDFIRMADSL { get; set; }



		public string CORDENCAPTURA { get; set; }


		public int CESTATUS { get; set; }


		public int CIDMONEDA { get; set; }


		public int CIDCUENTA { get; set; }



		public string CCLAVESAT { get; set; }


		public int CIDPRSEG08 { get; set; }

	}

	[PrimaryKey("CIDAUTOINCSQL")]
	public class Admprecioscompra : DBContext<Admprecioscompra>
	{

		public int CIDAUTOINCSQL { get; set; }


		public int CIDPRODUCTO { get; set; }


		public int CIDPROVEEDOR { get; set; }


		public double CPRECIOCOMPRA { get; set; }


		public int CIDMONEDA { get; set; }



		public string CCODIGOPRODUCTOPROVEEDOR { get; set; }


		public int CIDUNIDAD { get; set; }



		public string CTIMESTAMP { get; set; }

	}

	[PrimaryKey("CIDCLIENTEPROVEEDOR")]
	public class Admclientes : DBContext<Admclientes>
	{

		public int CIDCLIENTEPROVEEDOR { get; set; }



		public string CCODIGOCLIENTE { get; set; }



		public string CRAZONSOCIAL { get; set; }

		[JsonIgnore]
		public DateTime CFECHAALTA { get; set; }



		public string CRFC { get; set; }


		[JsonIgnore]
		public string CCURP { get; set; }



		public string CDENCOMERCIAL { get; set; }


		[JsonIgnore]
		public string CREPLEGAL { get; set; }

		[JsonIgnore]
		public int CIDMONEDA { get; set; }

		[JsonIgnore]
		public int CLISTAPRECIOCLIENTE { get; set; }

		[JsonIgnore]
		public double CDESCUENTODOCTO { get; set; }

		[JsonIgnore]
		public double CDESCUENTOMOVTO { get; set; }

		[JsonIgnore]
		public int CBANVENTACREDITO { get; set; }

		[JsonIgnore]
		public int CIDVALORCLASIFCLIENTE1 { get; set; }

		[JsonIgnore]
		public int CIDVALORCLASIFCLIENTE2 { get; set; }

		[JsonIgnore]
		public int CIDVALORCLASIFCLIENTE3 { get; set; }

		[JsonIgnore]
		public int CIDVALORCLASIFCLIENTE4 { get; set; }

		[JsonIgnore]
		public int CIDVALORCLASIFCLIENTE5 { get; set; }

		[JsonIgnore]
		public int CIDVALORCLASIFCLIENTE6 { get; set; }

		[JsonIgnore]
		public int CTIPOCLIENTE { get; set; }

		[JsonIgnore]
		public int CESTATUS { get; set; }

		[JsonIgnore]
		public DateTime CFECHABAJA { get; set; }

		[JsonIgnore]
		public DateTime CFECHAULTIMAREVISION { get; set; }

		[JsonIgnore]
		public double CLIMITECREDITOCLIENTE { get; set; }

		[JsonIgnore]
		public int CDIASCREDITOCLIENTE { get; set; }

		[JsonIgnore]
		public int CBANEXCEDERCREDITO { get; set; }

		[JsonIgnore]
		public double CDESCUENTOPRONTOPAGO { get; set; }

		[JsonIgnore]
		public int CDIASPRONTOPAGO { get; set; }

		[JsonIgnore]
		public double CINTERESMORATORIO { get; set; }

		[JsonIgnore]
		public int CDIAPAGO { get; set; }

		[JsonIgnore]
		public int CDIASREVISION { get; set; }


		[JsonIgnore]
		public string CMENSAJERIA { get; set; }


		[JsonIgnore]
		public string CCUENTAMENSAJERIA { get; set; }

		[JsonIgnore]
		public int CDIASEMBARQUECLIENTE { get; set; }

		[JsonIgnore]
		public int CIDALMACEN { get; set; }

		[JsonIgnore]
		public int CIDAGENTEVENTA { get; set; }

		[JsonIgnore]
		public int CIDAGENTECOBRO { get; set; }

		[JsonIgnore]
		public int CRESTRICCIONAGENTE { get; set; }

		[JsonIgnore]
		public double CIMPUESTO1 { get; set; }

		[JsonIgnore]
		public double CIMPUESTO2 { get; set; }

		[JsonIgnore]
		public double CIMPUESTO3 { get; set; }

		[JsonIgnore]
		public double CRETENCIONCLIENTE1 { get; set; }

		[JsonIgnore]
		public double CRETENCIONCLIENTE2 { get; set; }

		[JsonIgnore]
		public int CIDVALORCLASIFPROVEEDOR1 { get; set; }

		[JsonIgnore]
		public int CIDVALORCLASIFPROVEEDOR2 { get; set; }

		[JsonIgnore]
		public int CIDVALORCLASIFPROVEEDOR3 { get; set; }

		[JsonIgnore]
		public int CIDVALORCLASIFPROVEEDOR4 { get; set; }

		[JsonIgnore]
		public int CIDVALORCLASIFPROVEEDOR5 { get; set; }

		[JsonIgnore]
		public int CIDVALORCLASIFPROVEEDOR6 { get; set; }

		[JsonIgnore]
		public double CLIMITECREDITOPROVEEDOR { get; set; }

		[JsonIgnore]
		public int CDIASCREDITOPROVEEDOR { get; set; }

		[JsonIgnore]
		public int CTIEMPOENTREGA { get; set; }

		[JsonIgnore]
		public int CDIASEMBARQUEPROVEEDOR { get; set; }

		[JsonIgnore]
		public double CIMPUESTOPROVEEDOR1 { get; set; }

		[JsonIgnore]
		public double CIMPUESTOPROVEEDOR2 { get; set; }

		[JsonIgnore]
		public double CIMPUESTOPROVEEDOR3 { get; set; }

		[JsonIgnore]
		public double CRETENCIONPROVEEDOR1 { get; set; }

		[JsonIgnore]
		public double CRETENCIONPROVEEDOR2 { get; set; }

		[JsonIgnore]
		public int CBANINTERESMORATORIO { get; set; }

		[JsonIgnore]
		public double CCOMVENTAEXCEPCLIENTE { get; set; }

		[JsonIgnore]
		public double CCOMCOBROEXCEPCLIENTE { get; set; }

		[JsonIgnore]
		public int CBANPRODUCTOCONSIGNACION { get; set; }


		[JsonIgnore]
		public string CSEGCONTCLIENTE1 { get; set; }


		[JsonIgnore]
		public string CSEGCONTCLIENTE2 { get; set; }


		[JsonIgnore]
		public string CSEGCONTCLIENTE3 { get; set; }


		[JsonIgnore]
		public string CSEGCONTCLIENTE4 { get; set; }


		[JsonIgnore]
		public string CSEGCONTCLIENTE5 { get; set; }


		[JsonIgnore]
		public string CSEGCONTCLIENTE6 { get; set; }


		[JsonIgnore]
		public string CSEGCONTCLIENTE7 { get; set; }


		[JsonIgnore]
		public string CSEGCONTPROVEEDOR1 { get; set; }


		[JsonIgnore]
		public string CSEGCONTPROVEEDOR2 { get; set; }


		[JsonIgnore]
		public string CSEGCONTPROVEEDOR3 { get; set; }


		[JsonIgnore]
		public string CSEGCONTPROVEEDOR4 { get; set; }


		[JsonIgnore]
		public string CSEGCONTPROVEEDOR5 { get; set; }


		[JsonIgnore]
		public string CSEGCONTPROVEEDOR6 { get; set; }


		[JsonIgnore]
		public string CSEGCONTPROVEEDOR7 { get; set; }


		[JsonIgnore]
		public string CTEXTOEXTRA1 { get; set; }


		[JsonIgnore]
		public string CTEXTOEXTRA2 { get; set; }


		[JsonIgnore]
		public string CTEXTOEXTRA3 { get; set; }

		[JsonIgnore]
		public DateTime CFECHAEXTRA { get; set; }

		[JsonIgnore]
		public double CIMPORTEEXTRA1 { get; set; }

		[JsonIgnore]
		public double CIMPORTEEXTRA2 { get; set; }

		[JsonIgnore]
		public double CIMPORTEEXTRA3 { get; set; }

		[JsonIgnore]
		public double CIMPORTEEXTRA4 { get; set; }

		[JsonIgnore]
		public int CBANDOMICILIO { get; set; }

		[JsonIgnore]
		public int CBANCREDITOYCOBRANZA { get; set; }

		[JsonIgnore]
		public int CBANENVIO { get; set; }

		[JsonIgnore]
		public int CBANAGENTE { get; set; }

		[JsonIgnore]
		public int CBANIMPUESTO { get; set; }

		[JsonIgnore]
		public int CBANPRECIO { get; set; }


		[JsonIgnore]
		public string CTIMESTAMP { get; set; }

		[JsonIgnore]
		public int CFACTERC01 { get; set; }

		[JsonIgnore]
		public double CCOMVENTA { get; set; }

		[JsonIgnore]
		public double CCOMCOBRO { get; set; }

		[JsonIgnore]
		public int CIDMONEDA2 { get; set; }


		[JsonIgnore]
		public string CEMAIL1 { get; set; }


		[JsonIgnore]
		public string CEMAIL2 { get; set; }


		[JsonIgnore]
		public string CEMAIL3 { get; set; }

		[JsonIgnore]
		public int CTIPOENTRE { get; set; }

		[JsonIgnore]
		public int CCONCTEEMA { get; set; }

		[JsonIgnore]
		public int CFTOADDEND { get; set; }

		[JsonIgnore]
		public int CIDCERTCTE { get; set; }

		[JsonIgnore]
		public int CENCRIPENT { get; set; }

		[JsonIgnore]
		public int CBANCFD { get; set; }


		[JsonIgnore]
		public string CTEXTOEXTRA4 { get; set; }


		[JsonIgnore]
		public string CTEXTOEXTRA5 { get; set; }

		[JsonIgnore]
		public double CIMPORTEEXTRA5 { get; set; }

		[JsonIgnore]
		public int CIDADDENDA { get; set; }


		[JsonIgnore]
		public string CCODPROVCO { get; set; }

		[JsonIgnore]
		public int CENVACUSE { get; set; }


		[JsonIgnore]
		public string CCON1NOM { get; set; }


		[JsonIgnore]
		public string CCON1TEL { get; set; }

		[JsonIgnore]
		public int CQUITABLAN { get; set; }

		[JsonIgnore]
		public int CFMTOENTRE { get; set; }

		[JsonIgnore]
		public int CIDCOMPLEM { get; set; }

		[JsonIgnore]
		public int CDESGLOSAI2 { get; set; }

		[JsonIgnore]
		public int CLIMDOCTOS { get; set; }


		[JsonIgnore]
		public string CSITIOFTP { get; set; }


		[JsonIgnore]
		public string CUSRFTP { get; set; }


		[JsonIgnore]
		public string CMETODOPAG { get; set; }


		[JsonIgnore]
		public string CNUMCTAPAG { get; set; }

		[JsonIgnore]
		public int CIDCUENTA { get; set; }


		[JsonIgnore]
		public string CUSOCFDI { get; set; }


		[JsonIgnore]
		public string CREGIMFISC { get; set; }

	}

	[PrimaryKey("CTRANSACTIONID")]
	public class Admmovtosbancarios : DBContext<Admmovtosbancarios>
	{


		public string CTRANSACTIONID { get; set; }



		public string CACCOUNTID { get; set; }


		public int CIDCUENTA { get; set; }


		public int CIDDOCUMENTO { get; set; }


		public DateTime CFECHA { get; set; }



		public string CDESCRIPCION { get; set; }



		public string CREFERENCIA { get; set; }


		public double CIMPORTE { get; set; }


		public int CESTADO { get; set; }



		public string CTEXTOEXTRA1 { get; set; }



		public string CTEXTOEXTRA2 { get; set; }



		public string CTEXTOEXTRA3 { get; set; }


		public DateTime CFECHAEXTRA { get; set; }


		public double CIMPORTEEXTRA1 { get; set; }


		public double CIMPORTEEXTRA2 { get; set; }


		public double CIMPORTEEXTRA3 { get; set; }


		public double CIMPORTEEXTRA4 { get; set; }



		public string CTIMESTAMP { get; set; }

	}

	[PrimaryKey("CIDSERIE")]
	public class Admnumerosserie : DBContext<Admnumerosserie>
	{

		public int CIDSERIE { get; set; }


		public int CIDPRODUCTO { get; set; }



		public string CNUMEROSERIE { get; set; }


		public int CIDALMACEN { get; set; }


		public int CESTADO { get; set; }


		public int CESTADOANTERIOR { get; set; }



		public string CNUMEROLOTE { get; set; }


		public DateTime CFECHACADUCIDAD { get; set; }


		public DateTime CFECHAFABRICACION { get; set; }



		public string CPEDIMENTO { get; set; }



		public string CADUANA { get; set; }


		public DateTime CFECHAPEDIMENTO { get; set; }


		public double CTIPOCAMBIO { get; set; }


		public double CCOSTO { get; set; }



		public string CTIMESTAMP { get; set; }


		public int CNUMADUANA { get; set; }



		public string CCLAVESAT { get; set; }

	}

	[PrimaryKey("CIDUNIDAD")]
	public class Admunidadesmedidapeso : DBContext<Admunidadesmedidapeso>
	{

		public int CIDUNIDAD { get; set; }



		public string CNOMBREUNIDAD { get; set; }



		public string CABREVIATURA { get; set; }



		public string CDESPLIEGUE { get; set; }



		public string CCLAVEINT { get; set; }



		public string CCLAVESAT { get; set; }

	}

	[PrimaryKey("IDBITACORA")]
	public class Admbitacoras : DBContext<Admbitacoras>
	{

		public int IDBITACORA { get; set; }


		public DateTime FECHA { get; set; }



		public string HORA { get; set; }



		public string USUARIO { get; set; }



		public string NOMBRE { get; set; }



		public string USUARIO2 { get; set; }



		public string NOMBRE2 { get; set; }



		public string PROCESO { get; set; }



		public string DATOS { get; set; }


		public int IDSISTEMA { get; set; }



		public string CTEXTOEX01 { get; set; }



		public string CTEXTOEX02 { get; set; }



		public string CTEXTOEX03 { get; set; }


		public DateTime CFECHAEX01 { get; set; }


		public double CIMPORTE01 { get; set; }


		public double CIMPORTE02 { get; set; }


		public double CIMPORTE03 { get; set; }

	}

	[PrimaryKey("CIDCOMPONENTE")]
	public class Admcomponentespaquete : DBContext<Admcomponentespaquete>
	{

		public int CIDCOMPONENTE { get; set; }


		public int CIDPAQUETE { get; set; }


		public int CIDPRODUCTO { get; set; }


		public double CCANTIDADPRODUCTO { get; set; }


		public int CIDVALORCARACTERISTICA1 { get; set; }


		public int CIDVALORCARACTERISTICA2 { get; set; }


		public int CIDVALORCARACTERISTICA3 { get; set; }


		public int CTIPOPRODUCTO { get; set; }


		public int CIDUNIDADVENTA { get; set; }

	}

	[PrimaryKey("CIDAUTOINCSQL")]
	public class Admconversionesunidad : DBContext<Admconversionesunidad>
	{

		public int CIDAUTOINCSQL { get; set; }


		public int CIDUNIDAD1 { get; set; }


		public int CIDUNIDAD2 { get; set; }


		public double CFACTORCONVERSION { get; set; }

	}

	[PrimaryKey("CIDPREPOLIZA")]
	public class Admprepolizas : DBContext<Admprepolizas>
	{

		public int CIDPREPOLIZA { get; set; }


		public int CESTADOCONTABLE { get; set; }


		public int EJE { get; set; }


		public int PERIODO { get; set; }


		public int TIPOPOL { get; set; }


		public int NUMPOL { get; set; }


		public int CLASE { get; set; }


		public int IMPRESA { get; set; }



		public string CONCEPTO { get; set; }


		public DateTime FECHA { get; set; }


		public double CARGOS { get; set; }


		public double ABONOS { get; set; }



		public string DIARIO { get; set; }


		public int SISTORIG { get; set; }



		public string CHORA { get; set; }



		public string CGUIDPOLIZA { get; set; }



		public string CIDTRANSACCION { get; set; }

	}

	[PrimaryKey("CIDPRODUCTO")]
	public class Admproductosdetalles : DBContext<Admproductosdetalles>
	{

		public int CIDPRODUCTO { get; set; }


		public int CTIPOPRODUCTO { get; set; }


		public int CIDPRODUCTOPADRE { get; set; }


		public int CIDVALORCARACTERISTICA1 { get; set; }


		public int CIDVALORCARACTERISTICA2 { get; set; }


		public int CIDVALORCARACTERISTICA3 { get; set; }



		public string CTIMESTAMP { get; set; }

	}

	[PrimaryKey("CIDAUTOINCSQL")]
	public class Admasoccargosabonos : DBContext<Admasoccargosabonos>
	{

		public int CIDAUTOINCSQL { get; set; }


		public int CIDDOCUMENTOABONO { get; set; }


		public int CIDDOCUMENTOCARGO { get; set; }


		public double CIMPORTEABONO { get; set; }


		public double CIMPORTECARGO { get; set; }


		public DateTime CFECHAABONOCARGO { get; set; }


		public int CIDDESCUENTOPRONTOPAGO { get; set; }


		public int CIDUTILIDADPERDIDACAMB { get; set; }


		public int CIDAJUSIVA { get; set; }

	}

	[PrimaryKey("CIDAUTOINCSQL")]
	public class Admmovimientoscapas : DBContext<Admmovimientoscapas>
	{

		public int CIDAUTOINCSQL { get; set; }


		public int CIDMOVIMIENTO { get; set; }


		public int CIDCAPA { get; set; }


		public DateTime CFECHA { get; set; }


		public double CUNIDADES { get; set; }


		public int CTIPOCAPA { get; set; }


		public int CIDUNIDAD { get; set; }

	}

	[PrimaryKey("CIDAUTOINCSQL")]
	public class Admmaximosminimos : DBContext<Admmaximosminimos>
	{

		public int CIDAUTOINCSQL { get; set; }


		public int CIDALMACEN { get; set; }


		public int CIDPRODUCTO { get; set; }


		public int CIDPRODUCTOPADRE { get; set; }


		public double CEXISTENCIAMINBASE { get; set; }


		public double CEXISTENCIAMAXBASE { get; set; }


		public double CEXISTMINNOCONVERTIBLE { get; set; }


		public double CEXISTMAXNOCONVERTIBLE { get; set; }



		public string CZONA { get; set; }



		public string CPASILLO { get; set; }



		public string CANAQUEL { get; set; }



		public string CREPISA { get; set; }

	}

	[PrimaryKey("CIDMOVTOCEP")]
	public class Admmovtosceps : DBContext<Admmovtosceps>
	{

		public int CIDMOVTOCEP { get; set; }


		public int CIDDOCUMENTO { get; set; }


		public DateTime CFECHA { get; set; }



		public string CHORA { get; set; }



		public string CCLAVE { get; set; }



		public string CSELLO { get; set; }



		public string CCERTIFICADO { get; set; }


		public string CCADENA { get; set; }


		public int CESTADO { get; set; }



		public string CCONCEPTO { get; set; }


		public double CIVA { get; set; }


		public double CIMPORTE { get; set; }



		public string CRBANCO { get; set; }



		public string CRNOMBRE { get; set; }



		public string CRRFC { get; set; }



		public string CRCUENTA { get; set; }



		public string CRTIPOCTA { get; set; }



		public string CEBANCO { get; set; }



		public string CENOMBRE { get; set; }



		public string CERFC { get; set; }



		public string CECUENTA { get; set; }



		public string CETIPOCTA { get; set; }



		public string CTEXTOEXTRA1 { get; set; }



		public string CTEXTOEXTRA2 { get; set; }



		public string CTEXTOEXTRA3 { get; set; }


		public DateTime CFECHAEXTRA { get; set; }


		public double CIMPORTEEXTRA1 { get; set; }


		public double CIMPORTEEXTRA2 { get; set; }


		public double CIMPORTEEXTRA3 { get; set; }


		public double CIMPORTEEXTRA4 { get; set; }



		public string CARCHIVO { get; set; }



		public string CTIMESTAMP { get; set; }

	}

	[PrimaryKey("CIDMOVIMIENTO")]
	public class Admmovtosinvfisico : DBContext<Admmovtosinvfisico>
	{

		public int CIDMOVIMIENTO { get; set; }


		public int CIDPRODUCTO { get; set; }


		public int CIDALMACEN { get; set; }


		public int CIDUNIDAD { get; set; }


		public double CUNIDADES { get; set; }


		public double CUNIDADESNC { get; set; }


		public double CUNIDADESCAPTURADAS { get; set; }


		public int CMOVTOOCULTO { get; set; }


		public int CIDMOVTOOWNER { get; set; }

	}

	[PrimaryKey("CIDPRODUCTO")]
	public class Admproductos : DBContext<Admproductos>
	{

		public int CIDPRODUCTO { get; set; }



		public string CCODIGOPRODUCTO { get; set; }



		public string CNOMBREPRODUCTO { get; set; }

		[JsonIgnore]
		public int CTIPOPRODUCTO { get; set; }

		[JsonIgnore]
		public DateTime CFECHAALTAPRODUCTO { get; set; }

		[JsonIgnore]
		public int CCONTROLEXISTENCIA { get; set; }

		[JsonIgnore]
		public int CIDFOTOPRODUCTO { get; set; }


		public string CDESCRIPCIONPRODUCTO { get; set; }

		[JsonIgnore]
		public int CMETODOCOSTEO { get; set; }

		[JsonIgnore]
		public double CPESOPRODUCTO { get; set; }

		[JsonIgnore]
		public double CCOMVENTAEXCEPPRODUCTO { get; set; }

		[JsonIgnore]
		public double CCOMCOBROEXCEPPRODUCTO { get; set; }

		[JsonIgnore]
		public double CCOSTOESTANDAR { get; set; }

		[JsonIgnore]
		public double CMARGENUTILIDAD { get; set; }

		[JsonIgnore]
		public int CSTATUSPRODUCTO { get; set; }

		[JsonIgnore]
		public int CIDUNIDADBASE { get; set; }

		[JsonIgnore]
		public int CIDUNIDADNOCONVERTIBLE { get; set; }

		[JsonIgnore]
		public DateTime CFECHABAJA { get; set; }

		[JsonIgnore]
		public double CIMPUESTO1 { get; set; }

		[JsonIgnore]
		public double CIMPUESTO2 { get; set; }

		[JsonIgnore]
		public double CIMPUESTO3 { get; set; }

		[JsonIgnore]
		public double CRETENCION1 { get; set; }

		[JsonIgnore]
		public double CRETENCION2 { get; set; }

		[JsonIgnore]
		public int CIDPADRECARACTERISTICA1 { get; set; }

		[JsonIgnore]
		public int CIDPADRECARACTERISTICA2 { get; set; }

		[JsonIgnore]
		public int CIDPADRECARACTERISTICA3 { get; set; }

		[JsonIgnore]
		public int CIDVALORCLASIFICACION1 { get; set; }

		[JsonIgnore]
		public int CIDVALORCLASIFICACION2 { get; set; }

		[JsonIgnore]
		public int CIDVALORCLASIFICACION3 { get; set; }

		[JsonIgnore]
		public int CIDVALORCLASIFICACION4 { get; set; }

		[JsonIgnore]
		public int CIDVALORCLASIFICACION5 { get; set; }

		[JsonIgnore]
		public int CIDVALORCLASIFICACION6 { get; set; }


		[JsonIgnore]
		public string CSEGCONTPRODUCTO1 { get; set; }


		[JsonIgnore]
		public string CSEGCONTPRODUCTO2 { get; set; }


		[JsonIgnore]
		public string CSEGCONTPRODUCTO3 { get; set; }


		[JsonIgnore]
		public string CTEXTOEXTRA1 { get; set; }


		[JsonIgnore]
		public string CTEXTOEXTRA2 { get; set; }


		[JsonIgnore]
		public string CTEXTOEXTRA3 { get; set; }

		[JsonIgnore]
		public DateTime CFECHAEXTRA { get; set; }

		[JsonIgnore]
		public double CIMPORTEEXTRA1 { get; set; }

		[JsonIgnore]
		public double CIMPORTEEXTRA2 { get; set; }

		[JsonIgnore]
		public double CIMPORTEEXTRA3 { get; set; }

		[JsonIgnore]
		public double CIMPORTEEXTRA4 { get; set; }


		public double CPRECIO1 { get; set; }


		public double CPRECIO2 { get; set; }


		public double CPRECIO3 { get; set; }


		public double CPRECIO4 { get; set; }


		public double CPRECIO5 { get; set; }


		public double CPRECIO6 { get; set; }


		public double CPRECIO7 { get; set; }


		public double CPRECIO8 { get; set; }


		public double CPRECIO9 { get; set; }


		public double CPRECIO10 { get; set; }

		[JsonIgnore]
		public int CBANUNIDADES { get; set; }

		[JsonIgnore]
		public int CBANCARACTERISTICAS { get; set; }

		[JsonIgnore]
		public int CBANMETODOCOSTEO { get; set; }

		[JsonIgnore]
		public int CBANMAXMIN { get; set; }

		[JsonIgnore]
		public int CBANPRECIO { get; set; }

		[JsonIgnore]
		public int CBANIMPUESTO { get; set; }

		[JsonIgnore]
		public int CBANCODIGOBARRA { get; set; }

		[JsonIgnore]
		public int CBANCOMPONENTE { get; set; }


		[JsonIgnore]
		public string CTIMESTAMP { get; set; }

		[JsonIgnore]
		public int CERRORCOSTO { get; set; }

		[JsonIgnore]
		public DateTime CFECHAERRORCOSTO { get; set; }

		[JsonIgnore]
		public double CPRECIOCALCULADO { get; set; }

		[JsonIgnore]
		public int CESTADOPRECIO { get; set; }

		[JsonIgnore]
		public int CBANUBICACION { get; set; }

		[JsonIgnore]
		public int CESEXENTO { get; set; }

		[JsonIgnore]
		public int CEXISTENCIANEGATIVA { get; set; }

		[JsonIgnore]
		public double CCOSTOEXT1 { get; set; }

		[JsonIgnore]
		public double CCOSTOEXT2 { get; set; }

		[JsonIgnore]
		public double CCOSTOEXT3 { get; set; }

		[JsonIgnore]
		public double CCOSTOEXT4 { get; set; }

		[JsonIgnore]
		public double CCOSTOEXT5 { get; set; }
		[JsonIgnore]

		public DateTime CFECCOSEX1 { get; set; }

		[JsonIgnore]
		public DateTime CFECCOSEX2 { get; set; }

		[JsonIgnore]
		public DateTime CFECCOSEX3 { get; set; }

		[JsonIgnore]
		public DateTime CFECCOSEX4 { get; set; }

		[JsonIgnore]
		public DateTime CFECCOSEX5 { get; set; }

		[JsonIgnore]
		public int CMONCOSEX1 { get; set; }

		[JsonIgnore]
		public int CMONCOSEX2 { get; set; }

		[JsonIgnore]
		public int CMONCOSEX3 { get; set; }

		[JsonIgnore]
		public int CMONCOSEX4 { get; set; }

		[JsonIgnore]
		public int CMONCOSEX5 { get; set; }

		[JsonIgnore]
		public int CBANCOSEX { get; set; }

		[JsonIgnore]
		public int CESCUOTAI2 { get; set; }

		[JsonIgnore]
		public int CESCUOTAI3 { get; set; }

		[JsonIgnore]
		public int CIDUNIDADCOMPRA { get; set; }

		[JsonIgnore]
		public int CIDUNIDADVENTA { get; set; }

		[JsonIgnore]
		public int CSUBTIPO { get; set; }

		public string CCODALTERN { get; set; }


		[JsonIgnore]
		public string CNOMALTERN { get; set; }


		[JsonIgnore]
		public string CDESCCORTA { get; set; }

		[JsonIgnore]
		public int CIDMONEDA { get; set; }

		[JsonIgnore]
		public int CUSABASCU { get; set; }

		[JsonIgnore]
		public int CTIPOPAQUE { get; set; }

		[JsonIgnore]
		public int CPRECSELEC { get; set; }

		[JsonIgnore]
		public int CDESGLOSAI2 { get; set; }


		[JsonIgnore]
		public string CSEGCONTPRODUCTO4 { get; set; }


		[JsonIgnore]
		public string CSEGCONTPRODUCTO5 { get; set; }


		[JsonIgnore]
		public string CSEGCONTPRODUCTO6 { get; set; }


		[JsonIgnore]
		public string CSEGCONTPRODUCTO7 { get; set; }


		[JsonIgnore]
		public string CCTAPRED { get; set; }

		[JsonIgnore]
		public int CNODESCOMP { get; set; }

		[JsonIgnore]
		public int CIDUNIXML { get; set; }


		[JsonIgnore]
		public string CCLAVESAT { get; set; }

		[JsonIgnore]
		public double CCANTIDADFISCAL { get; set; }

        public override string ToString()
        {
            return CNOMBREPRODUCTO;
        }

    }

	[PrimaryKey("CIDPROMOCION")]
	public class Admpromociones : DBContext<Admpromociones>
	{

		public int CIDPROMOCION { get; set; }



		public string CCODIGOPROMOCION { get; set; }



		public string CNOMBREPROMOCION { get; set; }


		public DateTime CFECHAINICIO { get; set; }


		public DateTime CFECHAFIN { get; set; }


		public double CVOLUMENMINIMO { get; set; }


		public double CVOLUMENMAXIMO { get; set; }


		public double CPORCENTAJEDESCUENTO { get; set; }


		public int CIDVALORCLASIFCLIENTE1 { get; set; }


		public int CIDVALORCLASIFCLIENTE2 { get; set; }


		public int CIDVALORCLASIFCLIENTE3 { get; set; }


		public int CIDVALORCLASIFCLIENTE4 { get; set; }


		public int CIDVALORCLASIFCLIENTE5 { get; set; }


		public int CIDVALORCLASIFCLIENTE6 { get; set; }


		public int CIDVALORCLASIFPRODUCTO1 { get; set; }


		public int CIDVALORCLASIFPRODUCTO2 { get; set; }


		public int CIDVALORCLASIFPRODUCTO3 { get; set; }


		public int CIDVALORCLASIFPRODUCTO4 { get; set; }


		public int CIDVALORCLASIFPRODUCTO5 { get; set; }


		public int CIDVALORCLASIFPRODUCTO6 { get; set; }



		public string CTIMESTAMP { get; set; }


		public int CTIPOPROMO { get; set; }


		public int CIDCPTODOC { get; set; }


		public int CSUBTIPO { get; set; }



		public string CHORAINI { get; set; }



		public string CHORAFIN { get; set; }


		public int CTIPOPRO { get; set; }


		public int CVALA { get; set; }


		public int CVALB { get; set; }


		public int CDIAS { get; set; }


		public DateTime CFECHAALTA { get; set; }


		public int CSTATUS { get; set; }

	}

	[PrimaryKey("CIDMOVIMIENTO")]
	public class Admmovimientos : DBContext<Admmovimientos>
	{

		public int CIDMOVIMIENTO { get; set; }


		public int CIDDOCUMENTO { get; set; }


		public double CNUMEROMOVIMIENTO { get; set; }


		public int CIDDOCUMENTODE { get; set; }


		public int CIDPRODUCTO { get; set; }


		public int CIDALMACEN { get; set; }


		public double CUNIDADES { get; set; }


		public double CUNIDADESNC { get; set; }


		public double CUNIDADESCAPTURADAS { get; set; }


		public int CIDUNIDAD { get; set; }


		public int CIDUNIDADNC { get; set; }


		public double CPRECIO { get; set; }


		public double CPRECIOCAPTURADO { get; set; }


		public double CCOSTOCAPTURADO { get; set; }


		public double CCOSTOESPECIFICO { get; set; }


		public double CNETO { get; set; }


		public double CIMPUESTO1 { get; set; }


		public double CPORCENTAJEIMPUESTO1 { get; set; }


		public double CIMPUESTO2 { get; set; }


		public double CPORCENTAJEIMPUESTO2 { get; set; }


		public double CIMPUESTO3 { get; set; }


		public double CPORCENTAJEIMPUESTO3 { get; set; }


		public double CRETENCION1 { get; set; }


		public double CPORCENTAJERETENCION1 { get; set; }


		public double CRETENCION2 { get; set; }


		public double CPORCENTAJERETENCION2 { get; set; }


		public double CDESCUENTO1 { get; set; }


		public double CPORCENTAJEDESCUENTO1 { get; set; }


		public double CDESCUENTO2 { get; set; }


		public double CPORCENTAJEDESCUENTO2 { get; set; }


		public double CDESCUENTO3 { get; set; }


		public double CPORCENTAJEDESCUENTO3 { get; set; }


		public double CDESCUENTO4 { get; set; }


		public double CPORCENTAJEDESCUENTO4 { get; set; }


		public double CDESCUENTO5 { get; set; }


		public double CPORCENTAJEDESCUENTO5 { get; set; }


		public double CTOTAL { get; set; }


		public double CPORCENTAJECOMISION { get; set; }



		public string CREFERENCIA { get; set; }


		public string COBSERVAMOV { get; set; }


		public int CAFECTAEXISTENCIA { get; set; }


		public int CAFECTADOSALDOS { get; set; }


		public int CAFECTADOINVENTARIO { get; set; }


		public DateTime CFECHA { get; set; }


		public int CMOVTOOCULTO { get; set; }


		public int CIDMOVTOOWNER { get; set; }


		public int CIDMOVTOORIGEN { get; set; }


		public double CUNIDADESPENDIENTES { get; set; }


		public double CUNIDADESNCPENDIENTES { get; set; }


		public double CUNIDADESORIGEN { get; set; }


		public double CUNIDADESNCORIGEN { get; set; }


		public int CTIPOTRASPASO { get; set; }


		public int CIDVALORCLASIFICACION { get; set; }



		public string CTEXTOEXTRA1 { get; set; }



		public string CTEXTOEXTRA2 { get; set; }



		public string CTEXTOEXTRA3 { get; set; }


		public DateTime CFECHAEXTRA { get; set; }


		public double CIMPORTEEXTRA1 { get; set; }


		public double CIMPORTEEXTRA2 { get; set; }


		public double CIMPORTEEXTRA3 { get; set; }


		public double CIMPORTEEXTRA4 { get; set; }



		public string CTIMESTAMP { get; set; }


		public double CGTOMOVTO { get; set; }



		public string CSCMOVTO { get; set; }


		public double CCOMVENTA { get; set; }


		public int CIDMOVTODESTINO { get; set; }


		public int CNUMEROCONSOLIDACIONES { get; set; }

	}

	[PrimaryKey("CIDFOTOPRODUCTO")]
	public class Admproductosfotos : DBContext<Admproductosfotos>
	{

		public int CIDFOTOPRODUCTO { get; set; }



		public string CNOMBREFOTOPRODUCTO { get; set; }


		public string CFOTOPRODUCTO { get; set; }

	}

	[PrimaryKey("CIDBANDERA")]
	public class Admbanderas : DBContext<Admbanderas>
	{

		public int CIDBANDERA { get; set; }



		public string CNOMBREBANDERA { get; set; }


		public string CBANDERA { get; set; }



		public string CCLAVEISO { get; set; }

	}

	[PrimaryKey("CIDCOSTOH")]
	public class Admcostoshistoricos : DBContext<Admcostoshistoricos>
	{

		public int CIDCOSTOH { get; set; }


		public int CIDPRODUCTO { get; set; }


		public int CIDALMACEN { get; set; }


		public DateTime CFECHACOSTOH { get; set; }


		public double CCOSTOH { get; set; }


		public double CULTIMOCOSTOH { get; set; }


		public int CIDMOVIMIENTO { get; set; }



		public string CTIMESTAMP { get; set; }

	}

	[PrimaryKey("CIDMONEDA")]
	public class Admmonedas : DBContext<Admmonedas>
	{

		public int CIDMONEDA { get; set; }



		public string CNOMBREMONEDA { get; set; }



		public string CSIMBOLOMONEDA { get; set; }


		public int CPOSICIONSIMBOLO { get; set; }



		public string CPLURAL { get; set; }



		public string CSINGULAR { get; set; }



		public string CDESCRIPCIONPROTEGIDA { get; set; }


		public int CIDBANDERA { get; set; }


		public int CDECIMALESMONEDA { get; set; }



		public string CTIMESTAMP { get; set; }



		public string CCLAVESAT { get; set; }

	}

	[PrimaryKey("CIDEMPRESA")]
	public class Admparametros : DBContext<Admparametros>
	{

		public int CIDEMPRESA { get; set; }



		public string CNOMBREEMPRESA { get; set; }


		public int CEXISTENCIANEGATIVA { get; set; }


		public int CIDEJERCICIOACTUAL { get; set; }


		public int CPERIODOACTUAL { get; set; }



		public string CRFCEMPRESA { get; set; }



		public string CCURPEMPRESA { get; set; }



		public string CREGISTROCAMARA { get; set; }



		public string CCUENTAESTATAL { get; set; }



		public string CREPRESENTANTELEGAL { get; set; }



		public string CNOMBRECORTO { get; set; }


		public int CIDALMACENASUMIDO { get; set; }


		public DateTime CFECHACIERRE { get; set; }


		public int CDECIMALESUNIDADES { get; set; }


		public int CDECIMALESPRECIOVENTA { get; set; }


		public int CDECIMALESCOSTOS { get; set; }


		public int CDECIMALESTIPOSCAMBIO { get; set; }


		public int CBANMARGENUTILIDAD { get; set; }


		public double CIMPUESTO1 { get; set; }


		public double CIMPUESTO2 { get; set; }


		public double CIMPUESTO3 { get; set; }


		public int CUSOCUOTAIESPS { get; set; }


		public double CRETENCIONCLIENTE1 { get; set; }


		public double CRETENCIONCLIENTE2 { get; set; }


		public double CRETENCIONPROVEEDOR1 { get; set; }


		public double CRETENCIONPROVEEDOR2 { get; set; }


		public double CDESCUENTODOCTO { get; set; }


		public double CDESCUENTOMOVTO { get; set; }


		public double CCOMISIONVENTA { get; set; }


		public double CCOMISIONCOBRO { get; set; }


		public int CLISTAPRECIOGENERAL { get; set; }


		public int CIDALMACENCONSIGNACION { get; set; }


		public int CMANEJOFECHA { get; set; }


		public int CIDMONEDABASE { get; set; }


		public int CIDCLIENTEMOSTRADOR { get; set; }



		public string CRUTACONTPAQ { get; set; }


		public int CUSACARACTERISTICAS { get; set; }


		public int CUSAUNIDADNC { get; set; }



		public string CMASCARILLACLIENTES { get; set; }



		public string CMASCARILLAPRODUCTO { get; set; }



		public string CMASCARILLAALMACEN { get; set; }



		public string CMASCARILLAAGENTE { get; set; }



		public string CMASCARILLARFC { get; set; }



		public string CMASCARILLACURP { get; set; }


		public int CBANDIRECCION { get; set; }



		public string CNOMBRELISTA1 { get; set; }


		public int CIDMONEDALISTA1 { get; set; }



		public string CNOMBRELISTA2 { get; set; }


		public int CIDMONEDALISTA2 { get; set; }



		public string CNOMBRELISTA3 { get; set; }


		public int CIDMONEDALISTA3 { get; set; }



		public string CNOMBRELISTA4 { get; set; }


		public int CIDMONEDALISTA4 { get; set; }



		public string CNOMBRELISTA5 { get; set; }


		public int CIDMONEDALISTA5 { get; set; }



		public string CNOMBRELISTA6 { get; set; }


		public int CIDMONEDALISTA6 { get; set; }



		public string CNOMBRELISTA7 { get; set; }


		public int CIDMONEDALISTA7 { get; set; }



		public string CNOMBRELISTA8 { get; set; }


		public int CIDMONEDALISTA8 { get; set; }



		public string CNOMBRELISTA9 { get; set; }


		public int CIDMONEDALISTA9 { get; set; }



		public string CNOMBRELISTA10 { get; set; }


		public int CIDMONEDALISTA10 { get; set; }



		public string CNOMBREIMPUESTO1 { get; set; }



		public string CNOMBREIMPUESTO2 { get; set; }



		public string CNOMBREIMPUESTO3 { get; set; }



		public string CNOMBRERETENCION1 { get; set; }



		public string CNOMBRERETENCION2 { get; set; }



		public string CNOMBREGASTO1 { get; set; }



		public string CNOMBREGASTO2 { get; set; }



		public string CNOMBREGASTO3 { get; set; }



		public string CNOMBREDESCUENTOMOV1 { get; set; }



		public string CNOMBREDESCUENTOMOV2 { get; set; }



		public string CNOMBREDESCUENTOMOV3 { get; set; }



		public string CNOMBREDESCUENTOMOV4 { get; set; }



		public string CNOMBREDESCUENTOMOV5 { get; set; }



		public string CNOMBREDESCUENTODOC1 { get; set; }



		public string CNOMBREDESCUENTODOC2 { get; set; }



		public string CSEGCONTGENERAL1 { get; set; }



		public string CSEGCONTGENERAL2 { get; set; }



		public string CSEGCONTGENERAL3 { get; set; }



		public string CSEGCONTGENERAL4 { get; set; }



		public string CSEGCONTGENERAL5 { get; set; }



		public string CSEGCONTGENERAL6 { get; set; }



		public string CSEGCONTGENERAL7 { get; set; }



		public string CSEGCONTGENERAL8 { get; set; }



		public string CSEGCONTGENERAL9 { get; set; }



		public string CSEGCONTGENERAL10 { get; set; }



		public string CSEGCONTGENERAL11 { get; set; }


		public double CCONSECUTIVODIARIO { get; set; }


		public double CCONSECUTIVOINGRESOS { get; set; }


		public double CCONSECUTIVOEGRESOS { get; set; }


		public double CCONSECUTIVOORDEN { get; set; }



		public string CTIMESTAMP { get; set; }


		public DateTime CFECHACONGELAMIENTO { get; set; }


		public int CBANCONGELAMIENTO { get; set; }



		public string CRUTAEMPRESAPRED { get; set; }


		public int CBANVISTASVENTAS { get; set; }


		public int CBANVISTASCOMPRAS { get; set; }


		public int CBANVISTASCTEPROVINVEN { get; set; }


		public int CBANVISTASCATALOGOS { get; set; }


		public int CAFECTARINVAUTOMATICO { get; set; }


		public int CMETODOCOSTEO { get; set; }


		public int CBANOBLIGATORIOEXISTENCIA { get; set; }


		public int CNUMIMPUESTOIVA { get; set; }



		public string CVERSIONACTUAL { get; set; }


		public int CPRECIOSCONIVA { get; set; }


		public int CIDPRODU01 { get; set; }


		public int CIDPRODU02 { get; set; }


		public int CIDPRODU03 { get; set; }


		public int CIDPRODU04 { get; set; }


		public int CIDPRODU05 { get; set; }


		public int CIDCONCE01 { get; set; }


		public int CIDCONCE02 { get; set; }


		public int CIDCLIEN02 { get; set; }


		public int CIDCONCE03 { get; set; }


		public int CIDCONCE04 { get; set; }


		public int CPERANTFUT { get; set; }


		public int CVMOSTPEND { get; set; }



		public string CMOVTEXEX1 { get; set; }



		public string CMOVTEXEX2 { get; set; }



		public string CMOVTEXEX3 { get; set; }



		public string CMOVIMPEX1 { get; set; }



		public string CMOVIMPEX2 { get; set; }



		public string CMOVIMPEX3 { get; set; }



		public string CMOVIMPEX4 { get; set; }



		public string CMOVFECEX1 { get; set; }


		public int CVISTAAJ01 { get; set; }


		public int CESCFD { get; set; }


		public int CTIEMPOCFD { get; set; }


		public int CINTENTOS { get; set; }


		public int CINTERFAZ { get; set; }


		public int CCONTSIMUL { get; set; }


		public int CBANACTPLP { get; set; }


		public int CPOSFOLIO { get; set; }


		public int CPOSMODOIM { get; set; }


		public int CCALCOSTO1 { get; set; }


		public int CGENBITACS { get; set; }


		public int CSUGERIRRE { get; set; }


		public int CIDKEYEMP { get; set; }


		public int CALMACENAC { get; set; }



		public string CVERPOSI { get; set; }


		public int CIDSUCURSA { get; set; }


		public int CPERFIL { get; set; }


		public int CAUTORIZAR { get; set; }


		public int CMOSTRARDOCTOS { get; set; }


		public int CBITACORA0 { get; set; }


		public int CBITACORA1 { get; set; }


		public int CBITACORA2 { get; set; }


		public int CBITACORA3 { get; set; }


		public int CBITACORA4 { get; set; }


		public int CBITACORA5 { get; set; }


		public int CBITACORA6 { get; set; }


		public int CBITACORA7 { get; set; }


		public int CCOSTOMEN { get; set; }



		public string CSEGCIVA15 { get; set; }



		public string CSEGCIVA10 { get; set; }



		public string CSEGCIVAOT { get; set; }



		public string CSEGCIVA16 { get; set; }



		public string CSEGCIVA11 { get; set; }



		public string CSEGPIVA15 { get; set; }



		public string CSEGPIVA10 { get; set; }



		public string CSEGPIVAOT { get; set; }



		public string CSEGPIVA16 { get; set; }



		public string CSEGPIVA11 { get; set; }


		public int CGENAJ2010 { get; set; }


		public DateTime CFECAJ2010 { get; set; }


		public int CAJ2010ORI { get; set; }



		public string CHOST { get; set; }


		public int CTIPESTCAL { get; set; }


		public int CCFDIMPU01 { get; set; }


		public int CCFDIMPU02 { get; set; }


		public int CCFDIMPU03 { get; set; }


		public int CCFDIMPU04 { get; set; }


		public int CCFDIMPU05 { get; set; }



		public string CRUTAPLA01 { get; set; }



		public string CRUTAPLA02 { get; set; }


		public DateTime CFECDONAT { get; set; }



		public string CNUMDONAT { get; set; }



		public string CHOSTPROXY { get; set; }


		public int CPTOPROXY { get; set; }



		public string CUSRPROXY { get; set; }



		public string CHOSTSMTP { get; set; }


		public int CPTOPOP { get; set; }


		public int CPTOSMTP { get; set; }


		public int CCNXSEGPOP { get; set; }



		public string CRUTAENTREGA { get; set; }


		public int CPREFIJORFC { get; set; }



		public string CVALIDACFD { get; set; }



		public string CREGIMFISC { get; set; }



		public string CAUTRVOE { get; set; }



		public string CLEYENDON1 { get; set; }



		public string CLEYENDON2 { get; set; }



		public string CASUNTO { get; set; }


		public string CCUERPO { get; set; }



		public string CFIRMA { get; set; }



		public string CADJUNTO1 { get; set; }



		public string CADJUNTO2 { get; set; }



		public string CCORREOPRU { get; set; }



		public string CGUIDDSL { get; set; }



		public string CGUIDEMPRESA { get; set; }


		public double CMARGENUTILIDAD { get; set; }


		public int CPROTEGERCOSTOS { get; set; }


		public int CIDCUENTA { get; set; }



		public string CSEGCIVA8 { get; set; }



		public string CSEGPIVA8 { get; set; }


		public string CTOKENCN { get; set; }


		public string CREFRESHTOKENCN { get; set; }


		public string CURLWSTORE { get; set; }

	}

	[PrimaryKey("CIDAUTOINCSQL")]
	public class Admdatosaddenda : DBContext<Admdatosaddenda>
	{

		public int CIDAUTOINCSQL { get; set; }


		public int IDADDENDA { get; set; }


		public int TIPOCAT { get; set; }


		public int IDCAT { get; set; }


		public int NUMCAMPO { get; set; }



		public string VALOR { get; set; }

	}

	[PrimaryKey("CIDACUMULADO")]
	public class Admacumulados : DBContext<Admacumulados>
	{

		public int CIDACUMULADO { get; set; }


		public int CIDTIPOACUMULADO { get; set; }


		public int CIDOWNER1 { get; set; }


		public int CIDOWNER2 { get; set; }


		public int CIMPORTEMODELO { get; set; }


		public int CIDEJERCICIO { get; set; }


		public double CIMPORTEINICIAL { get; set; }


		public int CIDMONEDA { get; set; }


		public double CIMPORTEPERIODO1 { get; set; }


		public double CIMPORTEPERIODO2 { get; set; }


		public double CIMPORTEPERIODO3 { get; set; }


		public double CIMPORTEPERIODO4 { get; set; }


		public double CIMPORTEPERIODO5 { get; set; }


		public double CIMPORTEPERIODO6 { get; set; }


		public double CIMPORTEPERIODO7 { get; set; }


		public double CIMPORTEPERIODO8 { get; set; }


		public double CIMPORTEPERIODO9 { get; set; }


		public double CIMPORTEPERIODO10 { get; set; }


		public double CIMPORTEPERIODO11 { get; set; }


		public double CIMPORTEPERIODO12 { get; set; }



		public string CTIMESTAMP { get; set; }

	}

	[PrimaryKey("CIDTIPOCAMBIO")]
	public class Admtiposcambio : DBContext<Admtiposcambio>
	{

		public int CIDTIPOCAMBIO { get; set; }


		public int CIDMONEDA { get; set; }


		public DateTime CFECHA { get; set; }


		public double CIMPORTE { get; set; }



		public string CTIMESTAMP { get; set; }

	}

	[PrimaryKey("CIDDOCUMENTODE")]
	public class Admdocumentosmodelosback : DBContext<Admdocumentosmodelosback>
	{

		public int CIDDOCUMENTODE { get; set; }



		public string CDESCRIPCION { get; set; }


		public int CNATURALEZA { get; set; }


		public int CAFECTAEXISTENCIA { get; set; }


		public int CMODULO { get; set; }


		public double CNOFOLIO { get; set; }


		public int CIDCONCEPTODOCTOASUMIDO { get; set; }


		public int CUSACLIENTE { get; set; }


		public int CUSAPROVEEDOR { get; set; }


		public int CIDASIENTOCONTABLE { get; set; }

	}

	[PrimaryKey("CIDAUTOINCSQL")]
	public class Admmovimientosserie : DBContext<Admmovimientosserie>
	{

		public int CIDAUTOINCSQL { get; set; }


		public int CIDMOVIMIENTO { get; set; }


		public int CIDSERIE { get; set; }


		public DateTime CFECHA { get; set; }

	}

	[PrimaryKey("CCLAVE")]
	public class Admsatsegmentos : DBContext<Admsatsegmentos>
	{


		public string CCLAVE { get; set; }



		public string CDESCRIPCION { get; set; }



		public string CSEGCONT1 { get; set; }



		public string CSEGCONT2 { get; set; }



		public string CSEGCONT3 { get; set; }

	}

	[PrimaryKey("CIDDOCUMENTODE")]
	public class Admdocumentosmodelo : DBContext<Admdocumentosmodelo>
	{

		public int CIDDOCUMENTODE { get; set; }



		public string CDESCRIPCION { get; set; }


		public int CNATURALEZA { get; set; }


		public int CAFECTAEXISTENCIA { get; set; }


		public int CMODULO { get; set; }


		public double CNOFOLIO { get; set; }


		public int CIDCONCEPTODOCTOASUMIDO { get; set; }


		public int CUSACLIENTE { get; set; }


		public int CUSAPROVEEDOR { get; set; }


		public int CIDASIENTOCONTABLE { get; set; }

	}

	[PrimaryKey("CIDEXISTENCIA")]
	public class Admexistenciacosto : DBContext<Admexistenciacosto>
	{

		public int CIDEXISTENCIA { get; set; }


		public int CIDALMACEN { get; set; }


		public int CIDPRODUCTO { get; set; }


		public int CIDEJERCICIO { get; set; }


		public int CTIPOEXISTENCIA { get; set; }


		public double CENTRADASINICIALES { get; set; }


		public double CSALIDASINICIALES { get; set; }


		public double CCOSTOINICIALENTRADAS { get; set; }


		public double CCOSTOINICIALSALIDAS { get; set; }


		public double CENTRADASPERIODO1 { get; set; }


		public double CENTRADASPERIODO2 { get; set; }


		public double CENTRADASPERIODO3 { get; set; }


		public double CENTRADASPERIODO4 { get; set; }


		public double CENTRADASPERIODO5 { get; set; }


		public double CENTRADASPERIODO6 { get; set; }


		public double CENTRADASPERIODO7 { get; set; }


		public double CENTRADASPERIODO8 { get; set; }


		public double CENTRADASPERIODO9 { get; set; }


		public double CENTRADASPERIODO10 { get; set; }


		public double CENTRADASPERIODO11 { get; set; }


		public double CENTRADASPERIODO12 { get; set; }


		public double CSALIDASPERIODO1 { get; set; }


		public double CSALIDASPERIODO2 { get; set; }


		public double CSALIDASPERIODO3 { get; set; }


		public double CSALIDASPERIODO4 { get; set; }


		public double CSALIDASPERIODO5 { get; set; }


		public double CSALIDASPERIODO6 { get; set; }


		public double CSALIDASPERIODO7 { get; set; }


		public double CSALIDASPERIODO8 { get; set; }


		public double CSALIDASPERIODO9 { get; set; }


		public double CSALIDASPERIODO10 { get; set; }


		public double CSALIDASPERIODO11 { get; set; }


		public double CSALIDASPERIODO12 { get; set; }


		public double CCOSTOENTRADASPERIODO1 { get; set; }


		public double CCOSTOENTRADASPERIODO2 { get; set; }


		public double CCOSTOENTRADASPERIODO3 { get; set; }


		public double CCOSTOENTRADASPERIODO4 { get; set; }


		public double CCOSTOENTRADASPERIODO5 { get; set; }


		public double CCOSTOENTRADASPERIODO6 { get; set; }


		public double CCOSTOENTRADASPERIODO7 { get; set; }


		public double CCOSTOENTRADASPERIODO8 { get; set; }


		public double CCOSTOENTRADASPERIODO9 { get; set; }


		public double CCOSTOENTRADASPERIODO10 { get; set; }


		public double CCOSTOENTRADASPERIODO11 { get; set; }


		public double CCOSTOENTRADASPERIODO12 { get; set; }


		public double CCOSTOSALIDASPERIODO1 { get; set; }


		public double CCOSTOSALIDASPERIODO2 { get; set; }


		public double CCOSTOSALIDASPERIODO3 { get; set; }


		public double CCOSTOSALIDASPERIODO4 { get; set; }


		public double CCOSTOSALIDASPERIODO5 { get; set; }


		public double CCOSTOSALIDASPERIODO6 { get; set; }


		public double CCOSTOSALIDASPERIODO7 { get; set; }


		public double CCOSTOSALIDASPERIODO8 { get; set; }


		public double CCOSTOSALIDASPERIODO9 { get; set; }


		public double CCOSTOSALIDASPERIODO10 { get; set; }


		public double CCOSTOSALIDASPERIODO11 { get; set; }


		public double CCOSTOSALIDASPERIODO12 { get; set; }


		public int CBANCONGELADO { get; set; }



		public string CTIMESTAMP { get; set; }

	}

	[PrimaryKey("CIDAUTOINCSQL")]
	public class Admvistasrecursos : DBContext<Admvistasrecursos>
	{

		public int CIDAUTOINCSQL { get; set; }


		public int CIDSISTEMA { get; set; }


		public int CIDIDIOMA { get; set; }


		public int CIDMODULO { get; set; }



		public string CTABLABASE { get; set; }



		public string CTABLARELA { get; set; }



		public string CCAMPOBASE { get; set; }



		public string CCAMPOID { get; set; }



		public string CTITULO0 { get; set; }



		public string CCAMPO0 { get; set; }



		public string CINDICE0 { get; set; }


		public int CANCHO0 { get; set; }



		public string CTITULO1 { get; set; }



		public string CCAMPO1 { get; set; }



		public string CINDICE1 { get; set; }


		public int CANCHO1 { get; set; }



		public string CRANGO { get; set; }

	}

	[PrimaryKey("CIDEMPRESA")]
	public class Admparametrosback : DBContext<Admparametrosback>
	{

		public int CIDEMPRESA { get; set; }



		public string CNOMBREEMPRESA { get; set; }


		public int CEXISTENCIANEGATIVA { get; set; }


		public int CIDEJERCICIOACTUAL { get; set; }


		public int CPERIODOACTUAL { get; set; }



		public string CRFCEMPRESA { get; set; }



		public string CCURPEMPRESA { get; set; }



		public string CREGISTROCAMARA { get; set; }



		public string CCUENTAESTATAL { get; set; }



		public string CREPRESENTANTELEGAL { get; set; }



		public string CNOMBRECORTO { get; set; }


		public int CIDALMACENASUMIDO { get; set; }


		public DateTime CFECHACIERRE { get; set; }


		public int CDECIMALESUNIDADES { get; set; }


		public int CDECIMALESPRECIOVENTA { get; set; }


		public int CDECIMALESCOSTOS { get; set; }


		public int CDECIMALESTIPOSCAMBIO { get; set; }


		public int CBANMARGENUTILIDAD { get; set; }


		public double CIMPUESTO1 { get; set; }


		public double CIMPUESTO2 { get; set; }


		public double CIMPUESTO3 { get; set; }


		public int CUSOCUOTAIESPS { get; set; }


		public double CRETENCIONCLIENTE1 { get; set; }


		public double CRETENCIONCLIENTE2 { get; set; }


		public double CRETENCIONPROVEEDOR1 { get; set; }


		public double CRETENCIONPROVEEDOR2 { get; set; }


		public double CDESCUENTODOCTO { get; set; }


		public double CDESCUENTOMOVTO { get; set; }


		public double CCOMISIONVENTA { get; set; }


		public double CCOMISIONCOBRO { get; set; }


		public int CLISTAPRECIOGENERAL { get; set; }


		public int CIDALMACENCONSIGNACION { get; set; }


		public int CMANEJOFECHA { get; set; }


		public int CIDMONEDABASE { get; set; }


		public int CIDCLIENTEMOSTRADOR { get; set; }



		public string CRUTACONTPAQ { get; set; }


		public int CUSACARACTERISTICAS { get; set; }


		public int CUSAUNIDADNC { get; set; }



		public string CMASCARILLACLIENTES { get; set; }



		public string CMASCARILLAPRODUCTO { get; set; }



		public string CMASCARILLAALMACEN { get; set; }



		public string CMASCARILLAAGENTE { get; set; }



		public string CMASCARILLARFC { get; set; }



		public string CMASCARILLACURP { get; set; }


		public int CBANDIRECCION { get; set; }



		public string CNOMBRELISTA1 { get; set; }


		public int CIDMONEDALISTA1 { get; set; }



		public string CNOMBRELISTA2 { get; set; }


		public int CIDMONEDALISTA2 { get; set; }



		public string CNOMBRELISTA3 { get; set; }


		public int CIDMONEDALISTA3 { get; set; }



		public string CNOMBRELISTA4 { get; set; }


		public int CIDMONEDALISTA4 { get; set; }



		public string CNOMBRELISTA5 { get; set; }


		public int CIDMONEDALISTA5 { get; set; }



		public string CNOMBRELISTA6 { get; set; }


		public int CIDMONEDALISTA6 { get; set; }



		public string CNOMBRELISTA7 { get; set; }


		public int CIDMONEDALISTA7 { get; set; }



		public string CNOMBRELISTA8 { get; set; }


		public int CIDMONEDALISTA8 { get; set; }



		public string CNOMBRELISTA9 { get; set; }


		public int CIDMONEDALISTA9 { get; set; }



		public string CNOMBRELISTA10 { get; set; }


		public int CIDMONEDALISTA10 { get; set; }



		public string CNOMBREIMPUESTO1 { get; set; }



		public string CNOMBREIMPUESTO2 { get; set; }



		public string CNOMBREIMPUESTO3 { get; set; }



		public string CNOMBRERETENCION1 { get; set; }



		public string CNOMBRERETENCION2 { get; set; }



		public string CNOMBREGASTO1 { get; set; }



		public string CNOMBREGASTO2 { get; set; }



		public string CNOMBREGASTO3 { get; set; }



		public string CNOMBREDESCUENTOMOV1 { get; set; }



		public string CNOMBREDESCUENTOMOV2 { get; set; }



		public string CNOMBREDESCUENTOMOV3 { get; set; }



		public string CNOMBREDESCUENTOMOV4 { get; set; }



		public string CNOMBREDESCUENTOMOV5 { get; set; }



		public string CNOMBREDESCUENTODOC1 { get; set; }



		public string CNOMBREDESCUENTODOC2 { get; set; }



		public string CSEGCONTGENERAL1 { get; set; }



		public string CSEGCONTGENERAL2 { get; set; }



		public string CSEGCONTGENERAL3 { get; set; }



		public string CSEGCONTGENERAL4 { get; set; }



		public string CSEGCONTGENERAL5 { get; set; }



		public string CSEGCONTGENERAL6 { get; set; }



		public string CSEGCONTGENERAL7 { get; set; }



		public string CSEGCONTGENERAL8 { get; set; }



		public string CSEGCONTGENERAL9 { get; set; }



		public string CSEGCONTGENERAL10 { get; set; }



		public string CSEGCONTGENERAL11 { get; set; }


		public double CCONSECUTIVODIARIO { get; set; }


		public double CCONSECUTIVOINGRESOS { get; set; }


		public double CCONSECUTIVOEGRESOS { get; set; }


		public double CCONSECUTIVOORDEN { get; set; }



		public string CTIMESTAMP { get; set; }


		public DateTime CFECHACONGELAMIENTO { get; set; }


		public int CBANCONGELAMIENTO { get; set; }



		public string CRUTAEMPRESAPRED { get; set; }


		public int CBANVISTASVENTAS { get; set; }


		public int CBANVISTASCOMPRAS { get; set; }


		public int CBANVISTASCTEPROVINVEN { get; set; }


		public int CBANVISTASCATALOGOS { get; set; }


		public int CAFECTARINVAUTOMATICO { get; set; }


		public int CMETODOCOSTEO { get; set; }


		public int CBANOBLIGATORIOEXISTENCIA { get; set; }


		public int CNUMIMPUESTOIVA { get; set; }



		public string CVERSIONACTUAL { get; set; }


		public int CPRECIOSCONIVA { get; set; }


		public int CIDPRODU01 { get; set; }


		public int CIDPRODU02 { get; set; }


		public int CIDPRODU03 { get; set; }


		public int CIDPRODU04 { get; set; }


		public int CIDPRODU05 { get; set; }


		public int CIDCONCE01 { get; set; }


		public int CIDCONCE02 { get; set; }


		public int CIDCLIEN02 { get; set; }


		public int CIDCONCE03 { get; set; }


		public int CIDCONCE04 { get; set; }


		public int CPERANTFUT { get; set; }


		public int CVMOSTPEND { get; set; }



		public string CMOVTEXEX1 { get; set; }



		public string CMOVTEXEX2 { get; set; }



		public string CMOVTEXEX3 { get; set; }



		public string CMOVIMPEX1 { get; set; }



		public string CMOVIMPEX2 { get; set; }



		public string CMOVIMPEX3 { get; set; }



		public string CMOVIMPEX4 { get; set; }



		public string CMOVFECEX1 { get; set; }


		public int CVISTAAJ01 { get; set; }


		public int CESCFD { get; set; }


		public int CTIEMPOCFD { get; set; }


		public int CINTENTOS { get; set; }


		public int CINTERFAZ { get; set; }


		public int CCONTSIMUL { get; set; }


		public int CBANACTPLP { get; set; }


		public int CPOSFOLIO { get; set; }


		public int CPOSMODOIM { get; set; }


		public int CCALCOSTO1 { get; set; }


		public int CGENBITACS { get; set; }


		public int CSUGERIRRE { get; set; }


		public int CIDKEYEMP { get; set; }


		public int CALMACENAC { get; set; }



		public string CVERPOSI { get; set; }


		public int CIDSUCURSA { get; set; }


		public int CPERFIL { get; set; }


		public int CMOSTRAR01 { get; set; }


		public int CBITACORA0 { get; set; }


		public int CBITACORA1 { get; set; }


		public int CBITACORA2 { get; set; }


		public int CBITACORA3 { get; set; }


		public int CBITACORA4 { get; set; }


		public int CBITACORA5 { get; set; }


		public int CBITACORA6 { get; set; }


		public int CBITACORA7 { get; set; }



		public string CSEGCIVA15 { get; set; }



		public string CSEGCIVA10 { get; set; }



		public string CSEGCIVAOT { get; set; }



		public string CSEGCIVA16 { get; set; }



		public string CSEGCIVA11 { get; set; }



		public string CSEGPIVA15 { get; set; }



		public string CSEGPIVA10 { get; set; }



		public string CSEGPIVAOT { get; set; }



		public string CSEGPIVA16 { get; set; }



		public string CSEGPIVA11 { get; set; }


		public int CGENAJ2010 { get; set; }


		public DateTime CFECAJ2010 { get; set; }


		public int CAJ2010ORI { get; set; }



		public string CHOST { get; set; }


		public int CTIPESTCAL { get; set; }



		public string CRUTAPLA01 { get; set; }



		public string CRUTAPLA02 { get; set; }


		public DateTime CFECDONAT { get; set; }



		public string CNUMDONAT { get; set; }



		public string CHOSTPROXY { get; set; }


		public int CPTOPROXY { get; set; }



		public string CUSRPROXY { get; set; }



		public string CHOSTSMTP { get; set; }


		public int CPTOPOP { get; set; }


		public int CPTOSMTP { get; set; }


		public int CCNXSEGPOP { get; set; }



		public string CRUTAENTREGA { get; set; }


		public int CPREFIJORFC { get; set; }



		public string CVALIDACFD { get; set; }



		public string CREGIMFISC { get; set; }



		public string CAUTRVOE { get; set; }



		public string CLEYENDON1 { get; set; }



		public string CLEYENDON2 { get; set; }



		public string CASUNTO { get; set; }


		public string CCUERPO { get; set; }



		public string CFIRMA { get; set; }



		public string CADJUNTO1 { get; set; }



		public string CADJUNTO2 { get; set; }



		public string CCORREOPRU { get; set; }



		public string CGUIDDSL { get; set; }



		public string CGUIDEMPRESA { get; set; }


		public string CTOKENCN { get; set; }


		public string CREFRESHTOKENCN { get; set; }


		public string CURLWSTORE { get; set; }

	}

	[PrimaryKey("CIDCLASIFICACION")]
	public class Admclasificaciones : DBContext<Admclasificaciones>
	{

		public int CIDCLASIFICACION { get; set; }



		public string CNOMBRECLASIFICACION { get; set; }

	}

	[PrimaryKey("CIDDOCUMENTO")]
	public class Admdocumentos : DBContext<Admdocumentos>
	{

		public int CIDDOCUMENTO { get; set; }


		public int CIDDOCUMENTODE { get; set; }


		public int CIDCONCEPTODOCUMENTO { get; set; }



		public string CSERIEDOCUMENTO { get; set; }


		public double CFOLIO { get; set; }


		public DateTime CFECHA { get; set; }


		public int CIDCLIENTEPROVEEDOR { get; set; }



		public string CRAZONSOCIAL { get; set; }



		public string CRFC { get; set; }


		public int CIDAGENTE { get; set; }


		public DateTime CFECHAVENCIMIENTO { get; set; }

		[JsonIgnore]
		public DateTime CFECHAPRONTOPAGO { get; set; }

		[JsonIgnore]
		public DateTime CFECHAENTREGARECEPCION { get; set; }

		[JsonIgnore]
		public DateTime CFECHAULTIMOINTERES { get; set; }


		public int CIDMONEDA { get; set; }


		public double CTIPOCAMBIO { get; set; }



		public string CREFERENCIA { get; set; }


		public string COBSERVACIONES { get; set; }

		[JsonIgnore]
		public int CNATURALEZA { get; set; }

		[JsonIgnore]
		public int CIDDOCUMENTOORIGEN { get; set; }

		[JsonIgnore]
		public int CPLANTILLA { get; set; }

		[JsonIgnore]
		public int CUSACLIENTE { get; set; }

		[JsonIgnore]
		public int CUSAPROVEEDOR { get; set; }

		[JsonIgnore]
		public int CAFECTADO { get; set; }

		[JsonIgnore]
		public int CIMPRESO { get; set; }


		public int CCANCELADO { get; set; }


		public int CDEVUELTO { get; set; }

		[JsonIgnore]
		public int CIDPREPOLIZA { get; set; }

		[JsonIgnore]
		public int CIDPREPOLIZACANCELACION { get; set; }

		[JsonIgnore]
		public int CESTADOCONTABLE { get; set; }


		public double CNETO { get; set; }


		public double CIMPUESTO1 { get; set; }


		public double CIMPUESTO2 { get; set; }


		public double CIMPUESTO3 { get; set; }


		public double CRETENCION1 { get; set; }


		public double CRETENCION2 { get; set; }

		[JsonIgnore]
		public double CDESCUENTOMOV { get; set; }

		[JsonIgnore]
		public double CDESCUENTODOC1 { get; set; }

		[JsonIgnore]
		public double CDESCUENTODOC2 { get; set; }

		[JsonIgnore]
		public double CGASTO1 { get; set; }

		[JsonIgnore]
		public double CGASTO2 { get; set; }

		[JsonIgnore]
		public double CGASTO3 { get; set; }


		public double CTOTAL { get; set; }


		public double CPENDIENTE { get; set; }


		public double CTOTALUNIDADES { get; set; }

		[JsonIgnore]
		public double CDESCUENTOPRONTOPAGO { get; set; }

		[JsonIgnore]
		public double CPORCENTAJEIMPUESTO1 { get; set; }

		[JsonIgnore]
		public double CPORCENTAJEIMPUESTO2 { get; set; }

		[JsonIgnore]
		public double CPORCENTAJEIMPUESTO3 { get; set; }

		[JsonIgnore]
		public double CPORCENTAJERETENCION1 { get; set; }

		[JsonIgnore]
		public double CPORCENTAJERETENCION2 { get; set; }

		[JsonIgnore]
		public double CPORCENTAJEINTERES { get; set; }


		[JsonIgnore]
		public string CTEXTOEXTRA1 { get; set; }


		[JsonIgnore]
		public string CTEXTOEXTRA2 { get; set; }


		[JsonIgnore]
		public string CTEXTOEXTRA3 { get; set; }

		[JsonIgnore]
		public DateTime CFECHAEXTRA { get; set; }

		[JsonIgnore]
		public double CIMPORTEEXTRA1 { get; set; }

		[JsonIgnore]
		public double CIMPORTEEXTRA2 { get; set; }

		[JsonIgnore]
		public double CIMPORTEEXTRA3 { get; set; }

		[JsonIgnore]
		public double CIMPORTEEXTRA4 { get; set; }


		[JsonIgnore]
		public string CDESTINATARIO { get; set; }


		[JsonIgnore]
		public string CNUMEROGUIA { get; set; }


		[JsonIgnore]
		public string CMENSAJERIA { get; set; }


		[JsonIgnore]
		public string CCUENTAMENSAJERIA { get; set; }

		[JsonIgnore]
		public double CNUMEROCAJAS { get; set; }

		[JsonIgnore]
		public double CPESO { get; set; }

		[JsonIgnore]
		public int CBANOBSERVACIONES { get; set; }

		[JsonIgnore]
		public int CBANDATOSENVIO { get; set; }

		[JsonIgnore]
		public int CBANCONDICIONESCREDITO { get; set; }

		[JsonIgnore]
		public int CBANGASTOS { get; set; }

		[JsonIgnore]
		public double CUNIDADESPENDIENTES { get; set; }


		[JsonIgnore]
		public string CTIMESTAMP { get; set; }

		[JsonIgnore]
		public double CIMPCHEQPAQ { get; set; }

		[JsonIgnore]
		public int CSISTORIG { get; set; }

		[JsonIgnore]
		public int CIDMONEDCA { get; set; }

		[JsonIgnore]
		public double CTIPOCAMCA { get; set; }

		[JsonIgnore]
		public int CESCFD { get; set; }

		[JsonIgnore]
		public int CTIENECFD { get; set; }


		[JsonIgnore]
		public string CLUGAREXPE { get; set; }


		[JsonIgnore]
		public string CMETODOPAG { get; set; }

		[JsonIgnore]
		public int CNUMPARCIA { get; set; }

		[JsonIgnore]
		public int CCANTPARCI { get; set; }


		[JsonIgnore]
		public string CCONDIPAGO { get; set; }


		[JsonIgnore]
		public string CNUMCTAPAG { get; set; }


		[JsonIgnore]
		public string CGUIDDOCUMENTO { get; set; }


		[JsonIgnore]
		public string CUSUARIO { get; set; }

		[JsonIgnore]
		public int CIDPROYECTO { get; set; }

		[JsonIgnore]
		public int CIDCUENTA { get; set; }


		[JsonIgnore]
		public string CTRANSACTIONID { get; set; }

		[JsonIgnore]
		public int CIDCOPIADE { get; set; }


		[JsonIgnore]
		public string CVERESQUE { get; set; }

	}

	[PrimaryKey("CIDAUTOINCSQL")]
	public class Admasoccargosabonosimp : DBContext<Admasoccargosabonosimp>
	{

		public int CIDAUTOINCSQL { get; set; }


		public int CIDDOCUMENTOABONO { get; set; }


		public int CIDDOCUMENTOCARGO { get; set; }



		public string CTEXTOTASA { get; set; }


		public double CNETO { get; set; }


		public double CTASA { get; set; }


		public int CESDETALLE { get; set; }


		public int CTIPOIMP01 { get; set; }


		public int CTIPOFAC01 { get; set; }


		public double CTASACUOTA { get; set; }


		public int CESRETEN01 { get; set; }


		public double CPROPORC01 { get; set; }



		public string CMETODOPAG { get; set; }

	}
}
