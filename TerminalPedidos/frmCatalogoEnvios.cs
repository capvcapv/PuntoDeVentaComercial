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
        private List<Envios> listaEnvios = new List<Envios>();
        public frmCatalogoEnvios()
        {
            InitializeComponent();
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
    }

}
