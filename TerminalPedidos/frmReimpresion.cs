using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
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
using System.Windows.Forms;

namespace TerminalPedidos
{
    public partial class frmReimpresion : AntdUI.Window
    {
        private string referncia;
        public string concepto {get; set; }

        public frmReimpresion(string pReferencia)
        {
            InitializeComponent();
            referncia = pReferencia;
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

            MessageBox.Show("Documento reimpreso.");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
