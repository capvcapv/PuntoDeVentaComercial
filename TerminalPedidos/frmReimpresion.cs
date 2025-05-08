using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TerminalPedidos
{
    public partial class frmReimpresion : Form
    {
        private string referncia;

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

            SqlCommand comando = new SqlCommand("select CFECHA,CFOLIO,CTOTAL from admDocumentos where CTEXTOEXTRA1='" + referncia + "'", con);

            SqlDataReader lector = comando.ExecuteReader();

            List<Modelos.GUI.Documentos> listaDoctos = new List<Modelos.GUI.Documentos>();
            
            //TODO : CORREGIR EL QUE SOLO LEE EL PRIMER REGISTRO

            if (lector.Read())
            {
                Modelos.GUI.Documentos docto = new Modelos.GUI.Documentos();
                docto.fecha = lector.GetValue(0).ToString();
                docto.folio = lector.GetValue(1).ToString();
                docto.importe= lector.GetValue(2).ToString();

                listaDoctos.Add(docto);
            }

            lector.Close();
            con.Close();

            dataGridView1.DataSource = listaDoctos;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var documento = dataGridView1.CurrentRow.DataBoundItem as Modelos.GUI.Documentos;

            var reporte = new ReportDocument();

            string execPath = AppDomain.CurrentDomain.BaseDirectory;

            reporte.Load(execPath + "\\rptTicket.rpt");

            var configuracion = Modelos.Negocio.ConfigurationDBContext.obtener();
            var turno = Modelos.Negocio.TurnosDBContext.obtener(Convert.ToInt32(referncia));
            var caja = Modelos.Negocio.CajasDBContext.obtener(turno.caja);

            var config = Modelos.Utilerias.ObtenerConfig.obtenerDatosSQL(ConfigurationManager.ConnectionStrings["bd"].ConnectionString.Replace("PuntoVentaComercial", configuracion.empresa.Split('\\').Last()));

            reporte.DataSourceConnections[0].SetConnection(config.servidor, config.empresa, config.usuario, config.clave);

            reporte.SetParameterValue("cfolio", documento.folio);
            reporte.SetParameterValue("cconcepto", caja.conceptoFactura);
            reporte.SetParameterValue("cliente", "REIMPRESION");
            reporte.SetParameterValue("domicilio", configuracion.direccion);
            reporte.SetParameterValue("empresa", configuracion.nombre);

            reporte.PrintToPrinter(1, true, 0, 0);

            MessageBox.Show("Documento reimpreso.");
        }
    }
}
