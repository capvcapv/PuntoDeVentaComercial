using SDKContpaq;
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
    public partial class frmExistencias : Form
    {
        public string codigoProducto { get; set; }

        public frmExistencias()
        {
            InitializeComponent();
        }

        private void frmExistencias_Load(object sender, EventArgs e)
        {
            List<Modelos.GUI.Existencia> listaExistencias = new List<Modelos.GUI.Existencia>();

            AdminPAQSDK.fPosPrimerAlmacen();

            while (AdminPAQSDK.fPosEOFAlmacen() != 1)
            {
                StringBuilder codigo = new StringBuilder().Append('\0', 30);
                StringBuilder nombre = new StringBuilder().Append('\0', 60);
                AdminPAQSDK.fLeeDatoAlmacen("CCODIGOALMACEN", codigo, 30);
                AdminPAQSDK.fLeeDatoAlmacen("CNOMBREALMACEN", nombre, 60);

                if (codigo.ToString().Trim() == "1" || codigo.ToString().Trim() == "2" || codigo.ToString().Trim() == "3" || codigo.ToString().Trim() == "4")
                {
                    Modelos.GUI.Existencia exis1 = new Modelos.GUI.Existencia();
                    exis1.almacen = nombre.ToString().Trim(); ;
                    exis1.cantidad = "0";

                    double existencia1 = 0;

                    AdminPAQSDK.fRegresaExistencia(codigoProducto, codigo.ToString().Trim(), DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Day.ToString(), ref existencia1); ;

                    exis1.cantidad = existencia1.ToString();
                    listaExistencias.Add(exis1);
                }
               
                AdminPAQSDK.fPosSiguienteAlmacen();
            }

           
            dataGridView1.DataSource = listaExistencias;
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Escape)
            {
                this.Close();
            }
        }

        private void frmExistencias_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
