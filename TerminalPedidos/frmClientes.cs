using SDKContpaq.SDKContpaq;
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
    public partial class frmClientes : AntdUI.Window
    {
        public frmClientes()
        {
            InitializeComponent();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {

        }

        private void pageHeader1_BackClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cliente clientesdk = new Cliente();
            
            clientesdk.rfc = tRfc.Text.Trim();
            clientesdk.razonSocial = tRazonsocial.Text.Trim();
            clientesdk.cp = tCodigopostal.Text.Trim();
            

        }
    }
}
