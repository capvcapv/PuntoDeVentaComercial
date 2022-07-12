using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TerminalPedidos
{
    public partial class frmAutorizacionPrecio : Form
    {

        public string precioNuevo { get; set; }

        public frmAutorizacionPrecio()
        {
            InitializeComponent();
        }

        private void frmAutorizacionPrecio_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Modelos.Negocio.Usuarios user= Modelos.Negocio.UsuariosDBContext.obtenerPorNombre("SUPERVISOR");

            if (user.clave == tClave.Text)
            {
                precioNuevo =Convert.ToDouble(tPrecio.Text.Replace(",","").Replace("$","").Trim()).ToString("C2");

                this.Close();
            }
            else
            {
                MessageBox.Show("Clave incorrecta, intente nuevamente");
            }
        }
    }
}
