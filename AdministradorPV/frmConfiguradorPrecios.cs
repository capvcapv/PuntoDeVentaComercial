using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Modelos.GUI;
using SDKContpaq;

namespace AdministradorPV
{
    public partial class frmConfiguradorPrecios : Form
    {
        private Modelos.Negocio.ListaPrecios listaSeleccionada;

        public frmConfiguradorPrecios()
        {
            InitializeComponent();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmConfiguradorPrecios_Load(object sender, EventArgs e)
        {
            AdminPAQSDK.fPosPrimerProducto();

            while (AdminPAQSDK.fPosEOFProducto()==0)
            {

                StringBuilder id = new StringBuilder().Append('\0', 30);
                StringBuilder nombre = new StringBuilder().Append('\0', 60);
                StringBuilder estado = new StringBuilder().Append('\0', 30);
                StringBuilder tipo = new StringBuilder().Append('\0', 30);

                AdminPAQSDK.fLeeDatoProducto("CIDPRODU01", id, 30);
                AdminPAQSDK.fLeeDatoProducto("CNOMBREP01", nombre, 60);
                AdminPAQSDK.fLeeDatoProducto("CTIPOPRO01", estado, 30);
                AdminPAQSDK.fLeeDatoProducto("CSTATUSP01", tipo, 30);

                if (estado.ToString().Contains("1") && tipo.ToString().Contains("1"))
                {
                    ComboboxItem item = new ComboboxItem();
                    item.Text = nombre.ToString();
                    item.Value = id.ToString();

                    cbProducto.Items.Add(item);
                }
               
                AdminPAQSDK.fPosSiguienteProducto();
            }

            AdminPAQSDK.fPosPrimerUnidad();

            while (AdminPAQSDK.fPosEOFUnidad() == 0)
            {

                StringBuilder id = new StringBuilder().Append('\0', 30);
                StringBuilder nombre = new StringBuilder().Append('\0', 30);

                AdminPAQSDK.fLeeDatoUnidad("CIDUNIDAD", id, 30);
                AdminPAQSDK.fLeeDatoUnidad("CNOMBREU01", nombre, 30);

                ComboboxItem item = new ComboboxItem();
                item.Text = nombre.ToString();
                item.Value = id.ToString();

                cbUnidad1.Items.Add(item);
                cbUnidad2.Items.Add(item);
                cbUnidad3.Items.Add(item);
                cbUnidad4.Items.Add(item);
                cbUnidad5.Items.Add(item);
                cbUnidad6.Items.Add(item);
                cbUnidad7.Items.Add(item);
                cbUnidad8.Items.Add(item);
                cbUnidad9.Items.Add(item);
                cbUnidad10.Items.Add(item);

                AdminPAQSDK.fPosSiguienteUnidad();
            }

            cbListaPrecios.SelectedIndex = 0;

            cbUnidad1.SelectedIndex = 0;
            cbUnidad2.SelectedIndex = 0;
            cbUnidad3.SelectedIndex = 0;
            cbUnidad4.SelectedIndex = 0;
            cbUnidad5.SelectedIndex = 0;
            cbUnidad6.SelectedIndex = 0;
            cbUnidad7.SelectedIndex = 0;
            cbUnidad8.SelectedIndex = 0;
            cbUnidad9.SelectedIndex = 0;
            cbUnidad10.SelectedIndex = 0;
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

            this.Cursor = Cursors.WaitCursor;

            AdminPAQSDK.fPosPrimerProducto();

            var listasPrecios = Modelos.Negocio.ListaPreciosContextDB.obtenerListadoAgrupado();

            AdminPAQSDK.fPosSiguienteProducto();

            while (AdminPAQSDK.fPosEOFProducto()==0)
            {

                StringBuilder idProducto = new StringBuilder().Append('\0', 30);

                AdminPAQSDK.fLeeDatoProducto("CIDPRODU01", idProducto,30);

                var cantidad = listasPrecios.Where(x => x.producto == Convert.ToInt32(idProducto.ToString())).Count();

                if (cantidad != 10)
                {
                    Modelos.Negocio.ListaPreciosContextDB.eliminarListaProducto(Convert.ToInt32(idProducto.ToString()));
                   
                    for(int i = 0; i < 2; i++)
                    {
                        Modelos.Negocio.ListaPrecios lista = new Modelos.Negocio.ListaPrecios();
                        lista.producto = Convert.ToInt32(idProducto.ToString());
                        lista.lista = i + 1;
                        lista.unidad1 = 0;
                        lista.precio1 = 0.0;
                        lista.unidad2 = 0;
                        lista.precio2 = 0.0;
                        lista.unidad3 = 0;
                        lista.precio3 = 0.0;
                        lista.unidad4 = 0;
                        lista.precio4 = 0.0;
                        lista.unidad5 = 0;
                        lista.precio5 = 0.0;
                        lista.unidad6 = 0;
                        lista.precio6 = 0.0;
                        lista.unidad7 = 0;
                        lista.precio7 = 0.0;
                        lista.unidad8 = 0;
                        lista.precio8 = 0.0;
                        lista.unidad9 = 0;
                        lista.precio9 = 0.0;
                        lista.unidad10 = 0;
                        lista.precio10 = 0.0;

                        Modelos.Negocio.ListaPreciosContextDB.guardar(lista);
                    }

                }
                                
                AdminPAQSDK.fPosSiguienteProducto();
            }

            this.Cursor = Cursors.Default;
            MessageBox.Show("Proceso terminado.");
        }

        private void cbListaPrecios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cbProducto.Text))
            {

                int idProducto = Convert.ToInt32((cbProducto.SelectedItem as ComboboxItem).Value.ToString());
                int numLista = cbListaPrecios.SelectedIndex+1;

                listaSeleccionada = Modelos.Negocio.ListaPreciosContextDB.obtener(idProducto, numLista);

                if (listaSeleccionada == null)
                {
                    MessageBox.Show("La lista no está creada en la base de datos, porfavor corra la utileria \"Actualizar base de datos de productos\"");
                }
                else
                {
                    seleccionaCombo(listaSeleccionada.unidad1.ToString(), cbUnidad1);
                    tPrecio1.Text = listaSeleccionada.precio1.ToString();

                    seleccionaCombo(listaSeleccionada.unidad2.ToString(), cbUnidad2);
                    tPrecio2.Text = listaSeleccionada.precio2.ToString();

                    seleccionaCombo(listaSeleccionada.unidad3.ToString(), cbUnidad3);
                    tPrecio3.Text = listaSeleccionada.precio3.ToString();

                    seleccionaCombo(listaSeleccionada.unidad4.ToString(), cbUnidad4);
                    tPrecio4.Text = listaSeleccionada.precio4.ToString();

                    seleccionaCombo(listaSeleccionada.unidad5.ToString(), cbUnidad5);
                    tPrecio5.Text = listaSeleccionada.precio5.ToString();

                    seleccionaCombo(listaSeleccionada.unidad6.ToString(), cbUnidad6);
                    tPrecio6.Text = listaSeleccionada.precio6.ToString();

                    seleccionaCombo(listaSeleccionada.unidad7.ToString(), cbUnidad7);
                    tPrecio7.Text = listaSeleccionada.precio7.ToString();

                    seleccionaCombo(listaSeleccionada.unidad8.ToString(), cbUnidad8);
                    tPrecio8.Text = listaSeleccionada.precio8.ToString();

                    seleccionaCombo(listaSeleccionada.unidad9.ToString(), cbUnidad9);
                    tPrecio9.Text = listaSeleccionada.precio9.ToString();

                    seleccionaCombo(listaSeleccionada.unidad10.ToString(), cbUnidad10);
                    tPrecio10.Text = listaSeleccionada.precio10.ToString();
                }

            }
        }

        private void seleccionaCombo(string pKey, ComboBox pCombo)
        {
            int indice = 0;
            int contador = 0;

            foreach (var a in pCombo.Items)
            {
                if (pKey == (a as ComboboxItem).Value.ToString())
                {
                    indice = contador;
                }
                contador++;
            }

            pCombo.SelectedIndex = indice;

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            listaSeleccionada.unidad1 = Convert.ToInt32((cbUnidad1.SelectedItem as ComboboxItem).Value.ToString());
            listaSeleccionada.precio1 = Convert.ToDouble(tPrecio1.Text.Replace(" ",""));

            listaSeleccionada.unidad2 = Convert.ToInt32((cbUnidad2.SelectedItem as ComboboxItem).Value.ToString());
            listaSeleccionada.precio2 = Convert.ToDouble(tPrecio2.Text.Replace(" ", ""));

            listaSeleccionada.unidad3 = Convert.ToInt32((cbUnidad3.SelectedItem as ComboboxItem).Value.ToString());
            listaSeleccionada.precio3 = Convert.ToDouble(tPrecio3.Text.Replace(" ", ""));

            listaSeleccionada.unidad4 = Convert.ToInt32((cbUnidad4.SelectedItem as ComboboxItem).Value.ToString());
            listaSeleccionada.precio4 = Convert.ToDouble(tPrecio4.Text.Replace(" ", ""));

            listaSeleccionada.unidad5 = Convert.ToInt32((cbUnidad5.SelectedItem as ComboboxItem).Value.ToString());
            listaSeleccionada.precio5 = Convert.ToDouble(tPrecio5.Text.Replace(" ", ""));

            listaSeleccionada.unidad6 = Convert.ToInt32((cbUnidad6.SelectedItem as ComboboxItem).Value.ToString());
            listaSeleccionada.precio6 = Convert.ToDouble(tPrecio6.Text.Replace(" ", ""));

            listaSeleccionada.unidad7 = Convert.ToInt32((cbUnidad7.SelectedItem as ComboboxItem).Value.ToString());
            listaSeleccionada.precio7 = Convert.ToDouble(tPrecio7.Text.Replace(" ", ""));

            listaSeleccionada.unidad8 = Convert.ToInt32((cbUnidad8.SelectedItem as ComboboxItem).Value.ToString());
            listaSeleccionada.precio8 = Convert.ToDouble(tPrecio8.Text.Replace(" ", ""));

            listaSeleccionada.unidad9 = Convert.ToInt32((cbUnidad9.SelectedItem as ComboboxItem).Value.ToString());
            listaSeleccionada.precio9 = Convert.ToDouble(tPrecio9.Text.Replace(" ", ""));

            listaSeleccionada.unidad10 = Convert.ToInt32((cbUnidad10.SelectedItem as ComboboxItem).Value.ToString());
            listaSeleccionada.precio10= Convert.ToDouble(tPrecio10.Text.Replace(" ", ""));

            Modelos.Negocio.ListaPreciosContextDB.actualizar(listaSeleccionada);

            listaSeleccionada = null;
        }
    }
}
