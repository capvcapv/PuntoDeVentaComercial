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
    public partial class frmLogin : Form
    {
        public Boolean aceptado = false;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            var usuario = Modelos.Negocio.UsuariosDBContext.obtenerPorNombre(tNombre.Text);

            if (usuario!=null)
            {
                if (usuario.clave == tClave.Text)
                {
                    aceptado = true;
                }
                else
                {
                    aceptado = false;
                }
                
            }
            else
            {
                aceptado = false;
            }

            if (aceptado)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña inválido.");
            }
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!aceptado)
            {
                Application.Exit();
            }
                        
        }
    }
}
