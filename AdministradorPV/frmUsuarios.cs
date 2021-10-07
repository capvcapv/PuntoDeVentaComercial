using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdministradorPV
{
    public partial class frmUsuarios : Form
    {

        private Modelos.Negocio.Usuarios usuarioActivo;

        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            var listadoUsuarios = Modelos.Negocio.UsuariosDBContext.obtenerListado();

            listBox1.Items.AddRange(listadoUsuarios.ToArray());
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            usuarioActivo = null;
            tNombre.Text = "";
            tClave.Text = "";
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            usuarioActivo = listBox1.SelectedItem as Modelos.Negocio.Usuarios;

            tNombre.Text = usuarioActivo.nombre;
            tClave.Text = usuarioActivo.clave;

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (usuarioActivo!=null)
            {
                usuarioActivo.nombre = tNombre.Text;
                usuarioActivo.clave = tClave.Text;

                Modelos.Negocio.UsuariosDBContext.actualizar(usuarioActivo);
            }
            else
            {
                usuarioActivo = new Modelos.Negocio.Usuarios();
                usuarioActivo.nombre = tNombre.Text;
                usuarioActivo.clave = tClave.Text;

                Modelos.Negocio.UsuariosDBContext.guardar(usuarioActivo);
            }

            usuarioActivo = null;
            tNombre.Text = "";
            tClave.Text = "";

            listBox1.Items.Clear();

            var listadoUsuarios = Modelos.Negocio.UsuariosDBContext.obtenerListado();

            listBox1.Items.AddRange(listadoUsuarios.ToArray());
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro desea eliminar el registro?", "Pregunta", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (usuarioActivo != null)
                {
                    Modelos.Negocio.UsuariosDBContext.eliminar(usuarioActivo);
                    usuarioActivo = null;
                    tNombre.Text = "";
                    tClave.Text = "";

                    listBox1.Items.Clear();

                    var listadoUsuarios = Modelos.Negocio.UsuariosDBContext.obtenerListado();

                    listBox1.Items.AddRange(listadoUsuarios.ToArray());
                }
                
            }
        }
    }
}
