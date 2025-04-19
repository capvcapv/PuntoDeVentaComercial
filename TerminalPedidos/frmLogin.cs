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
    public partial class frmLogin : AntdUI.Window
    {
        public Boolean aceptado = false;
        public Modelos.Negocio.Usuarios usuarioActivo;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            tNombre.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var usuario = Modelos.Negocio.UsuariosDBContext.obtenerPorNombre(tNombre.Text);

            if (usuario!=null)
            {
                if (usuario.clave == tClave.Text)
                {
                    aceptado = true;
                    usuarioActivo = usuario;
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

        private void tClave_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                var usuario = Modelos.Negocio.UsuariosDBContext.obtenerPorNombre(tNombre.Text);

                if (usuario != null)
                {
                    if (usuario.clave == tClave.Text)
                    {
                        aceptado = true;
                        usuarioActivo = usuario;
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
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
