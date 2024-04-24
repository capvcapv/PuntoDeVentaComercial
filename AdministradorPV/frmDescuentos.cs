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
    public partial class frmDescuentos : Form
    {

        private Descuentos descuentoActivo;

        public frmDescuentos()
        {
            InitializeComponent();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            limpiaFormulario();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (descuentoActivo == null)
            {
                descuentoActivo = new Descuentos();
                descuentoActivo.prefijo = tPrefijo.Text;
                descuentoActivo.descuento = Convert.ToDouble( tDescuento.Value);
                descuentoActivo.guardar();
                
            }
            else
            {
                descuentoActivo.prefijo = tPrefijo.Text;
                descuentoActivo.descuento = Convert.ToDouble(tDescuento.Value);
                descuentoActivo.actualizar();
            }

            limpiaFormulario();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (descuentoActivo != null)
            {
                descuentoActivo.elimina();
                limpiaFormulario();
            }
            else
            {
                MessageBox.Show("Debe seleccionar el descuento previamente");
            }
        }

        private void frmDescuentos_Load(object sender, EventArgs e)
        {
            rellenaTabla();
        }

        private void limpiaFormulario()
        {
            tPrefijo.Text = "";
            tDescuento.Value = 0;
            rellenaTabla();
            descuentoActivo = null;
        }

        private void rellenaTabla()
        {
            var listado = (new Descuentos()).obtenerTodos();
            objectListView1.SetObjects(listado);
        }

        private void objectListView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            descuentoActivo = (Descuentos)objectListView1.SelectedObject;

            if (descuentoActivo!=null)
            {
                tPrefijo.Text = descuentoActivo.prefijo;
                tDescuento.Value = Convert.ToDecimal(descuentoActivo.descuento);
            }
        }
    }
}
