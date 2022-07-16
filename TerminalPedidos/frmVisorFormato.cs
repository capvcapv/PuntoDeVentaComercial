using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TerminalPedidos
{
    public partial class frmVisorFormato : Form
    {
        public string formato { get; set; }
        public string folio { get; set; }
        public string concepto { get; set; }
        public string nombre { get; set; }
        public string titulo { get; set; }
        public string agente { get; set; }

        public frmVisorFormato()
        {
            InitializeComponent();
        }

        private void frmVisorFormato_Load(object sender, EventArgs e)
        {
            var reporte = new ReportDocument();

            string execPath = AppDomain.CurrentDomain.BaseDirectory;

            reporte.Load(execPath + formato);

            var configuracion = Modelos.Negocio.ConfigurationDBContext.obtener();

            var config = Modelos.Utilerias.ObtenerConfig.obtenerDatosSQL(ConfigurationManager.ConnectionStrings["bd"].ConnectionString.Replace("PuntoVentaComercial", configuracion.empresa.Split('\\').Last()));

            reporte.DataSourceConnections[0].SetConnection(config.servidor, config.empresa, config.usuario, config.clave);

            reporte.SetParameterValue("cfolio", folio);
            reporte.SetParameterValue("cconcepto",concepto);
            reporte.SetParameterValue("cliente",nombre );
            reporte.SetParameterValue("domicilio", configuracion.direccion);
            reporte.SetParameterValue("empresa", configuracion.nombre);
            reporte.SetParameterValue("agente", agente);

            if (!String.IsNullOrEmpty(titulo))
            {
                reporte.SetParameterValue("titulo", titulo);
            }

            crystalReportViewer1.ReportSource = reporte;
        }
    }
}
