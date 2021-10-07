using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Modelos.Negocio;

namespace AdministradorPV
{
    public partial class frmConfiguracion : Form
    {
        public frmConfiguracion()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Configuracion config = new Configuracion();
            config.id = 1;
            config.empresa = tEmpresa.Text;
            config.rutaBinarios = tRutaBinarios.Text;
            config.claveSello = tClaveSello.Text;
            config.nombre = tNombreEmpresa.Text;
            config.direccion = tDireccion.Text;

            ConfigurationDBContext.actualizar(config);

            MessageBox.Show("Modificación guardada.");
        }

        private void frmConfiguracion_Load(object sender, EventArgs e)
        {
            var config= ConfigurationDBContext.obtener();

            tEmpresa.Text = config.empresa;
            tRutaBinarios.Text = config.rutaBinarios;
            tClaveSello.Text = config.claveSello;
            tNombreEmpresa.Text = config.nombre;
            tDireccion.Text = config.direccion;

        }
    }
}
