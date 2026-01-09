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
    public partial class frmObservaciones : AntdUI.Window
    {
        public string Observaciones { get;set; }
       
        public frmObservaciones(string observaciones)
        {
            InitializeComponent();
            tObservacion.Text = observaciones;
        }

        private void frmObservaciones_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Observaciones = tObservacion.Text;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmCatalogoEnvios envios = new frmCatalogoEnvios();
            envios.ShowDialog();
        }
    }
}
