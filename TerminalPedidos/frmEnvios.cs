using Modelos.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TerminalPedidos
{
    public partial class frmEnvios : AntdUI.Window
    {
        public frmEnvios()
        {
            InitializeComponent();
        }

        private void frmEnvios_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(tCodigo.Text))
            {
                MessageBox.Show("El campo Código es requerido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(tNombre.Text))
            {
                MessageBox.Show("El campo Nombre es requerido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Envios envios = new Envios();
            envios.Codigo = tCodigo.Text;
            envios.Nombre = tNombre.Text;
            envios.Localidad = tLocalidad.Text;
            envios.Telefono = tTelefono.Text;
            envios.Direccion = tDomicilio.Text;
            envios.guardar();

            this.Close();
        }

        private void tDomicilio_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
