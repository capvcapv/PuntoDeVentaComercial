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
    public partial class frmModificaCantidad : AntdUI.Window
    {
        public double Cantidad { get; set; }

        public frmModificaCantidad()
        {
            InitializeComponent();
        }

        private void frmModificaCantidad_Load(object sender, EventArgs e)
        {
            tCantidad.Value = (decimal)Cantidad;
        }

        private void tCantidad_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (double.TryParse(tCantidad.Text, out double cantidad))
                {
                    Cantidad = cantidad;
                    Close();
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese un número válido.");
                }
            }
        }

        private void frmModificaCantidad_Shown(object sender, EventArgs e)
        {
            tCantidad.Focus();
            tCantidad.SelectAll();
        }
    }
}
