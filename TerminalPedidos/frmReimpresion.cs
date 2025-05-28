using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Modelos.GUI;
using Modelos.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Services.Description;
using System.Windows.Forms;
using Vanara.PInvoke;
using static AntdUI.FloatButton;

namespace TerminalPedidos
{
    public partial class frmReimpresion : AntdUI.Window
    {
        private string referncia;
        private Form1 padre;        
        public string concepto {get; set; }
        public bool esEdicion { get; set; } = false;
        public int idDocumentoEdicion { get; set; }
        public string SerieFolio { get; set; }

        public frmReimpresion(string pReferencia, Form1 pPadre)
        {
            InitializeComponent();
            referncia = pReferencia;
            padre = pPadre;
        }

        private void frmReimpresion_Load(object sender, EventArgs e)
        {
            var configuracion = Modelos.Negocio.ConfigurationDBContext.obtener();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["bd"].ConnectionString.Replace("PuntoVentaComercial", configuracion.empresa.Split('\\').Last());
            con.Open();

            SqlCommand comando = new SqlCommand("select admDocumentos.CIDDOCUMENTO,admDocumentos.CFECHA,admDocumentos.CFOLIO,admDocumentos.CRAZONSOCIAL,admDocumentos.CTOTAL from admDocumentos inner join admConceptos on admDocumentos.CIDCONCEPTODOCUMENTO = admConceptos.CIDCONCEPTODOCUMENTO  where admConceptos.CCODIGOCONCEPTO ='" + concepto + "' and admDocumentos.CTEXTOEXTRA1='" + referncia + "'", con);

            SqlDataReader lector = comando.ExecuteReader();

            List<Modelos.GUI.Documentos> listaDoctos = new List<Modelos.GUI.Documentos>();
            
            while (lector.Read())
            {
                Modelos.GUI.Documentos docto = new Modelos.GUI.Documentos();
                docto.id = Convert.ToInt32(lector.GetValue(0).ToString());
                docto.fecha = lector.GetValue(1).ToString();
                docto.folio = lector.GetValue(2).ToString();
                docto.razonSocial = lector.GetValue(3).ToString();
                docto.importe= lector.GetValue(4).ToString();

                listaDoctos.Add(docto);
            }

            lector.Close();
            con.Close();

            dataGridView1.DataSource = listaDoctos;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void pageHeader1_BackClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var documento = dataGridView1.CurrentRow.DataBoundItem as Modelos.GUI.Documentos;

            var reporte = new ReportDocument();
            string execPath = AppDomain.CurrentDomain.BaseDirectory;
            reporte.Load(execPath + "\\rptTicketOriginal.rpt");

            var configuracion = Modelos.Negocio.ConfigurationDBContext.obtener();
            var turno = Modelos.Negocio.TurnosDBContext.obtener(Convert.ToInt32(referncia));
            var caja = Modelos.Negocio.CajasDBContext.obtener(turno.caja);

            var config = Modelos.Utilerias.ObtenerConfig.obtenerDatosSQL(ConfigurationManager.ConnectionStrings["bd"].ConnectionString.Replace("PuntoVentaComercial", configuracion.empresa.Split('\\').Last()));

            reporte.DataSourceConnections[0].SetConnection(config.servidor, config.empresa, config.usuario, config.clave);

            reporte.SetParameterValue("cfolio", documento.folio);
            reporte.SetParameterValue("cconcepto", caja.conceptoFactura);
            reporte.SetParameterValue("cliente", documento.razonSocial);
            reporte.SetParameterValue("domicilio", configuracion.direccion);
            reporte.SetParameterValue("empresa", configuracion.nombre);
            reporte.SetParameterValue("agente", "AGENTE");
            reporte.SetParameterValue("puntos", "0");
            reporte.SetParameterValue("titulo", "REIMPRESION");

            PrintDialog dialog1 = new PrintDialog();
            dialog1.AllowSomePages = true;
            dialog1.AllowPrintToFile = false;

            if (dialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int copies = 1;
                int fromPage = dialog1.PrinterSettings.FromPage;
                int toPage = dialog1.PrinterSettings.ToPage;
                bool collate = dialog1.PrinterSettings.Collate;

                reporte.PrintOptions.PrinterName = dialog1.PrinterSettings.PrinterName;
                reporte.SetParameterValue("copia", "REIMPRESION");
                //reporte.PrintToPrinter(copies, collate, fromPage, toPage);

                string rutaPDF = Path.Combine(execPath, "TicketGenerado.pdf");
                reporte.ExportToDisk(ExportFormatType.PortableDocFormat, rutaPDF);

                Process printProcess = new Process();
                printProcess.StartInfo.FileName = rutaPDF;
                printProcess.StartInfo.Verb = "printto";
                printProcess.StartInfo.Arguments = "\"" + dialog1.PrinterSettings.PrinterName + "\"";
                printProcess.StartInfo.CreateNoWindow = true;
                printProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                printProcess.Start();
            }

            dialog1.Dispose();
            reporte.Dispose();

            esEdicion = false;

            MessageBox.Show("Documento reimpreso.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var documento = dataGridView1.CurrentRow.DataBoundItem as Modelos.GUI.Documentos;
            var configuracion = Modelos.Negocio.ConfigurationDBContext.obtener();
            var cadena = ConfigHelper.ClonarConnectionStringConNuevoNombreBD(Path.GetFileName(configuracion.empresa));

            var admdocumento = new Admdocumentos().obtenerId(documento.id,cadena );
            var admcliente = new Admclientes().obtenerId(admdocumento.CIDCLIENTEPROVEEDOR, cadena);

            padre.textBox1.Text = admcliente.CCODIGOCLIENTE;
            esEdicion = true;
            idDocumentoEdicion = documento.id;
            SerieFolio = admdocumento.CSERIEDOCUMENTO + " - " + admdocumento.CFOLIO;

            cargaPartidas(documento.id);


            this.Close();
        }

        private void cargaPartidas(int idDocto)
        {
            var configuracion = Modelos.Negocio.ConfigurationDBContext.obtener();
            var cadena = ConfigHelper.ClonarConnectionStringConNuevoNombreBD(Path.GetFileName(configuracion.empresa));

            var admmovimientos = new Admmovimientos().obtenerSQL("select * from admMovimientos where CIDDOCUMENTO = " + idDocto, cadena);

            padre.binding.Clear();

            foreach (var mov in admmovimientos)
            {
                var admprodcuto = new Admproductos().obtenerId(mov.CIDPRODUCTO, cadena);
                var admalmacen = new Admalmacenes().obtenerId(mov.CIDALMACEN, cadena);

                Partida part = new Partida();
                part.codigo = admprodcuto.CCODIGOPRODUCTO;
                part.producto = admprodcuto.CNOMBREPRODUCTO;
                part.almacen = admalmacen.CCODIGOALMACEN;


                part.precio = mov.CPRECIOCAPTURADO.ToString();
                part.porcentajeDescuento = mov.CPORCENTAJEDESCUENTO1.ToString();
                part.cantidad = mov.CUNIDADES.ToString();


                if (mov.CPORCENTAJEDESCUENTO1 == 0)
                {
                    part.descuento = "0";
                }
                else
                {
                    part.descuento = ((Convert.ToDouble(part.precio.Replace("$", "").Replace(",", ""))) * ((Convert.ToDouble(mov.CPORCENTAJEDESCUENTO1) / 100))).ToString("C");
                }

                part.precio = (Convert.ToDouble(part.precio) - Convert.ToDouble(part.descuento.Replace("$", "").Replace(",", ""))).ToString("C");
                part.importe = (Convert.ToDouble(part.precio.Replace("$", "").Replace(",", ""))  * Convert.ToDouble(part.cantidad)).ToString("C");
                part.puntos = "0";

                padre.binding.Add(part);
                padre.actualizaTablaSinCalculo();
            }
                        
        }

    }
}
