using CrystalDecisions.CrystalReports.Engine;
using Modelos.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TerminalPedidos
{
    public partial class frmCatalogoEnvios : AntdUI.Window
    {
        private Form1 formularioPadre;
        private string folio="SIN FOLIO";

        private List<Envios> listaEnvios = new List<Envios>();
        public frmCatalogoEnvios(Form1 formulario,string pFolio)
        {
            InitializeComponent();
            formularioPadre = formulario;
            folio = pFolio;
        }

        private void frmCatalogoEnvios_Load(object sender, EventArgs e)
        {
            obtenerEnvios();
        }

        public void obtenerEnvios()
        {
            var configuracion = Modelos.Negocio.ConfigurationDBContext.obtener();
            listaEnvios = new Envios().obtenerTodos();

            dataGridView1.DataSource = listaEnvios;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmEnvios formularioEnvios = new frmEnvios();
            formularioEnvios.ShowDialog();

            obtenerEnvios();
        }

        private void pageHeader1_BackClick(object sender, EventArgs e)
        {
            this.Close();            
        }

        private void tCodigo_TextChanged(object sender, EventArgs e)
        {
            List<Envios> temp = listaEnvios.FindAll(i => i.Codigo.ToUpper().Contains(tCodigo.Text.ToUpper()));
            dataGridView1.DataSource = temp;
        }

        private void tNombre_TextChanged(object sender, EventArgs e)
        {
            List<Envios> temp = listaEnvios.FindAll(i => i.Nombre.ToUpper().Contains(tNombre.Text.ToUpper()));
            dataGridView1.DataSource = temp;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Envios envios = dataGridView1.CurrentRow.DataBoundItem as Envios;

            formularioPadre.button7.BadgeMode= true;
            formularioPadre.button7.Badge = envios.Id.ToString() + " - " + envios.Nombre;

            this.Close();
        }

        private void bImprimir_Click(object sender, EventArgs e)
        {
            Envios envios = dataGridView1.CurrentRow.DataBoundItem as Envios;

            var reporte = new ReportDocument();
            string formato = "rptTicketEnvio.rpt";
            string execPath = AppDomain.CurrentDomain.BaseDirectory;
            reporte.Load(execPath + formato);

            reporte.SetParameterValue("nombre", envios.Nombre);
            reporte.SetParameterValue("folio", folio);
            reporte.SetParameterValue("domicilio", envios.Direccion);
            reporte.SetParameterValue("localidad", envios.Localidad);
            reporte.SetParameterValue("telefono", envios.Telefono);


            PrintDialog dialog1 = new PrintDialog();
            dialog1.AllowSomePages = true;
            dialog1.AllowPrintToFile = false;

            if (dialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int copies = 1;// dialog1.PrinterSettings.Copies;
                int fromPage = dialog1.PrinterSettings.FromPage;
                int toPage = dialog1.PrinterSettings.ToPage;
                bool collate = dialog1.PrinterSettings.Collate;

                reporte.PrintOptions.PrinterName = dialog1.PrinterSettings.PrinterName;

                reporte.PrintToPrinter(copies, collate, fromPage, toPage);

            }

            dialog1.Dispose();

            reporte.Dispose();
        }
    }

}
