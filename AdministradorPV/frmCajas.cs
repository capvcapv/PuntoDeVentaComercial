using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SDKContpaq;
using Modelos.GUI;
using Modelos.Negocio;

namespace AdministradorPV
{
    public partial class frmCajas : Form
    {
        private Cajas cajaActiva;

        public frmCajas()
        {
            InitializeComponent();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            cajaActiva= listBox1.SelectedItem as Cajas;

            tNombre.Text = cajaActiva.nombre;
            seleccionaCombo(cajaActiva.almacen.ToString(), cbAlmacen);
            seleccionaCombo(cajaActiva.conceptoFactura, cbFactura);
            seleccionaCombo(cajaActiva.conceptoGlobal, cbFacturaGlobal);
            seleccionaCombo(cajaActiva.conceptoPedido, cbPedidos);
            seleccionaCombo(cajaActiva.conceptoRemision, cbRemisionAlterna);
            seleccionaCombo(cajaActiva.conceptoPedido2, cbPedidoAlterna);
            seleccionaCombo(cajaActiva.conceptoCotizacion, cbConceptoCotizacion);
            seleccionaCombo(cajaActiva.conceptoCotizacion2, cbConceptoCotizacion2);
            tNombre1.Text = cajaActiva.nombre1;
            tNombre2.Text = cajaActiva.nombre2;
            tNombre3.Text = cajaActiva.nombre3;
            tNombre4.Text = cajaActiva.nombre4;
            tNombre5.Text = cajaActiva.nombre5;
            tNombre6.Text = cajaActiva.nombre6;
            tFormato1.Text = cajaActiva.formato1;
            tFormato2.Text = cajaActiva.formato2;
            tFormato3.Text = cajaActiva.formato3;
            tFormato4.Text = cajaActiva.formato4;
            tFormato5.Text = cajaActiva.formato5;
            tFormato6.Text = cajaActiva.formato6;

        }

        private void seleccionaCombo(string pKey, ComboBox pCombo)
        {
            int indice = 0;
            int contador = 0;

            foreach(var a in pCombo.Items)
            {
                if (pKey==(a as ComboboxItem).Value.ToString())
                {
                    indice = contador;
                }
                contador++;
            }

            pCombo.SelectedIndex = indice;

        }

        private void frmCajas_Load(object sender, EventArgs e)
        {
            AdminPAQSDK.fPosPrimerConceptoDocto();

            while (AdminPAQSDK.fPosEOFConceptoDocto() == 0)
            {

                StringBuilder id = new StringBuilder().Append('\0', 30);
                StringBuilder nombre = new StringBuilder().Append('\0', 30);

                AdminPAQSDK.fLeeDatoConceptoDocto("CCODIGOCONCEPTO", id,30);
                AdminPAQSDK.fLeeDatoConceptoDocto("CNOMBRECONCEPTO", nombre, 30);

                ComboboxItem item = new ComboboxItem();
                item.Text = nombre.ToString();
                item.Value = id.ToString();

                cbFactura.Items.Add(item);
                cbFacturaGlobal.Items.Add(item);
                cbPedidos.Items.Add(item);
                cbRemisionAlterna.Items.Add(item);
                cbPedidoAlterna.Items.Add(item);
                cbConceptoCotizacion.Items.Add(item);
                cbConceptoCotizacion2.Items.Add(item);

                AdminPAQSDK.fPosSiguienteConceptoDocto();
            }

            AdminPAQSDK.fPosPrimerAlmacen();

            while (AdminPAQSDK.fPosEOFAlmacen() == 0)
            {

                StringBuilder id = new StringBuilder().Append('\0', 30);
                StringBuilder nombre = new StringBuilder().Append('\0', 30);

                AdminPAQSDK.fLeeDatoAlmacen("CIDALMACEN", id, 30);
                AdminPAQSDK.fLeeDatoAlmacen("CNOMBREA01", nombre, 30);

                ComboboxItem item = new ComboboxItem();
                item.Text = nombre.ToString();
                item.Value = id.ToString();

                cbAlmacen.Items.Add(item);

                AdminPAQSDK.fPosSiguienteAlmacen();
            }

            cbAlmacen.SelectedIndex = 1;
            cbFactura.SelectedIndex = 0;
            cbFacturaGlobal.SelectedIndex = 0;
            cbPedidos.SelectedIndex = 0;
            cbRemisionAlterna.SelectedIndex = 0;
            cbPedidoAlterna.SelectedIndex = 0;
            cbConceptoCotizacion.SelectedIndex = 0;
            cbConceptoCotizacion2.SelectedIndex = 0;

            var listadoCajas = CajasDBContext.obtenerListado();

            listBox1.Items.AddRange(listadoCajas.ToArray());
                        
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            cajaActiva = null;
            tNombre.Text = "";
            cbAlmacen.SelectedIndex = 1;
            cbFactura.SelectedIndex = 0;
            cbFacturaGlobal.SelectedIndex = 0;
            cbPedidos.SelectedIndex = 0;
            cbRemisionAlterna.SelectedIndex = 0;
            cbPedidoAlterna.SelectedIndex = 0;
            cbConceptoCotizacion.SelectedIndex = 0;
            cbConceptoCotizacion2.SelectedIndex = 0;
            tNombre1.Text = "";
            tNombre2.Text = "";
            tNombre3.Text = "";
            tNombre4.Text = "";
            tNombre5.Text = "";
            tNombre6.Text = "";
            tFormato1.Text = "";
            tFormato2.Text = "";
            tFormato3.Text = "";
            tFormato4.Text = "";
            tFormato5.Text = "";
            tFormato6.Text = "";
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (cajaActiva!=null)
            {
                cajaActiva.nombre = tNombre.Text;
                cajaActiva.almacen = Convert.ToInt32((cbAlmacen.SelectedItem as ComboboxItem).Value.ToString());
                cajaActiva.conceptoFactura = (cbFactura.SelectedItem as ComboboxItem).Value.ToString();
                cajaActiva.conceptoGlobal = (cbFacturaGlobal.SelectedItem as ComboboxItem).Value.ToString();
                cajaActiva.conceptoPedido = (cbPedidos.SelectedItem as ComboboxItem).Value.ToString();
                cajaActiva.conceptoRemision = (cbRemisionAlterna.SelectedItem as ComboboxItem).Value.ToString();
                cajaActiva.conceptoPedido2= (cbPedidoAlterna.SelectedItem as ComboboxItem).Value.ToString();
                cajaActiva.conceptoCotizacion = (cbConceptoCotizacion.SelectedItem as ComboboxItem).Value.ToString();
                cajaActiva.conceptoCotizacion2 = (cbConceptoCotizacion2.SelectedItem as ComboboxItem).Value.ToString();
                cajaActiva.nombre1 = tNombre1.Text;
                cajaActiva.nombre2 = tNombre2.Text;
                cajaActiva.nombre3 = tNombre3.Text;
                cajaActiva.nombre4 = tNombre4.Text;
                cajaActiva.nombre5 = tNombre5.Text;
                cajaActiva.nombre6 = tNombre6.Text;
                cajaActiva.formato1 = tFormato1.Text;
                cajaActiva.formato2 = tFormato2.Text;
                cajaActiva.formato3 = tFormato3.Text;
                cajaActiva.formato4 = tFormato4.Text;
                cajaActiva.formato5 = tFormato5.Text;
                cajaActiva.formato6 = tFormato6.Text;

                CajasDBContext.actualizar(cajaActiva);
            }
            else
            {
                cajaActiva = new Cajas();
                cajaActiva.nombre = tNombre.Text;
                cajaActiva.almacen = Convert.ToInt32((cbAlmacen.SelectedItem as ComboboxItem).Value.ToString());
                cajaActiva.conceptoFactura = (cbFactura.SelectedItem as ComboboxItem).Value.ToString();
                cajaActiva.conceptoGlobal = (cbFacturaGlobal.SelectedItem as ComboboxItem).Value.ToString();
                cajaActiva.conceptoPedido = (cbPedidos.SelectedItem as ComboboxItem).Value.ToString();
                cajaActiva.conceptoRemision = (cbRemisionAlterna.SelectedItem as ComboboxItem).Value.ToString();
                cajaActiva.conceptoPedido2 = (cbPedidoAlterna.SelectedItem as ComboboxItem).Value.ToString();
                cajaActiva.conceptoCotizacion = (cbConceptoCotizacion.SelectedItem as ComboboxItem).Value.ToString();
                cajaActiva.conceptoCotizacion2 = (cbConceptoCotizacion2.SelectedItem as ComboboxItem).Value.ToString();
                cajaActiva.nombre1 = tNombre1.Text;
                cajaActiva.nombre2 = tNombre2.Text;
                cajaActiva.nombre3 = tNombre3.Text;
                cajaActiva.nombre4 = tNombre4.Text;
                cajaActiva.nombre5 = tNombre5.Text;
                cajaActiva.nombre6 = tNombre6.Text;
                cajaActiva.formato1 = tFormato1.Text;
                cajaActiva.formato2 = tFormato2.Text;
                cajaActiva.formato3 = tFormato3.Text;
                cajaActiva.formato4 = tFormato4.Text;
                cajaActiva.formato5 = tFormato5.Text;
                cajaActiva.formato6 = tFormato6.Text;

                CajasDBContext.guardar(cajaActiva);
            }

            cajaActiva = null;
            tNombre.Text = "";
            cbAlmacen.SelectedIndex = 1;
            cbFactura.SelectedIndex = 0;
            cbFacturaGlobal.SelectedIndex = 0;
            cbRemisionAlterna.SelectedIndex = 0;
            cbPedidoAlterna.SelectedIndex = 0;
            cbConceptoCotizacion.SelectedIndex = 0;
            cbConceptoCotizacion2.SelectedIndex = 0;
            tNombre1.Text = "";
            tNombre2.Text = "";
            tNombre3.Text = "";
            tNombre4.Text = "";
            tNombre5.Text = "";
            tNombre6.Text = "";
            tFormato1.Text = "";
            tFormato2.Text = "";
            tFormato3.Text = "";
            tFormato4.Text = "";
            tFormato5.Text = "";
            tFormato6.Text = "";

            listBox1.Items.Clear();
            var listadoCajas = CajasDBContext.obtenerListado();

            listBox1.Items.AddRange(listadoCajas.ToArray());
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("¿Seguro desea eliminar el registro?", "Pregunta", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (cajaActiva != null)
                {
                    CajasDBContext.eliminar(cajaActiva);

                    cajaActiva = null;
                    tNombre.Text = "";
                    cbAlmacen.SelectedIndex = 1;
                    cbFactura.SelectedIndex = 0;
                    cbFacturaGlobal.SelectedIndex = 0;
                    cbPedidos.SelectedIndex = 0;
                    cbRemisionAlterna.SelectedIndex = 0;
                    cbPedidoAlterna.SelectedIndex = 0;
                    cbConceptoCotizacion.SelectedIndex = 0;
                    cbConceptoCotizacion2.SelectedIndex = 0;
                    tNombre1.Text = "";
                    tNombre2.Text = "";
                    tNombre3.Text = "";
                    tNombre4.Text = "";
                    tNombre5.Text = "";
                    tNombre6.Text = "";
                    tFormato1.Text = "";
                    tFormato2.Text = "";
                    tFormato3.Text = "";
                    tFormato4.Text = "";
                    tFormato5.Text = "";
                    tFormato6.Text = "";
                }

                listBox1.Items.Clear();
                var listadoCajas = CajasDBContext.obtenerListado();

                listBox1.Items.AddRange(listadoCajas.ToArray());
            }

        }
    }
}
