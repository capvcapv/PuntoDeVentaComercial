using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace AdministradorPV
{
    public partial class frmReporteCorte : Form
    {

        public string referencia { get; set; }
        public frmReporteCorte()
        {
            InitializeComponent();
        }

        private void frmReporteCorte_Load(object sender, EventArgs e)
        {

            ReportDocument reporte = new ReportDocument();

            string execPath = AppDomain.CurrentDomain.BaseDirectory;

            reporte.Load( execPath + "\\rptCorteTurno.rpt");

            var configuracion = Modelos.Negocio.ConfigurationDBContext.obtener();

            var config = Modelos.Utilerias.ObtenerConfig.obtenerDatosSQL(ConfigurationManager.ConnectionStrings["bd"].ConnectionString.Replace("PuntoVentaComercial", configuracion.empresa.Split('\\').Last()));

            reporte.DataSourceConnections[0].SetConnection(config.servidor, config.empresa, config.usuario, config.clave);

            reporte.SetParameterValue("referencia", referencia);

            crystalReportViewer1.ReportSource = reporte;

        }
    }
}
