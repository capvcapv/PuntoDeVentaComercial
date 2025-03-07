using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Modelos.Negocio;
using SDKContpaq;

namespace AdministradorPV
{
    public partial class frmPromociones : Form
    {
        private Promociones promocionActiva;
        private List<Promociones> listadoPromociones;

        public frmPromociones()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            limpiarFormulario();
            cargarTabla();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (promocionActiva != null)
            {
                promocionActiva.nombre = tNombre.Text;
                promocionActiva.fecha_inicio = dtInicio.Value; 
                promocionActiva.fecha_final = dtFinal.Value;
                promocionActiva.tipo = Convert.ToInt32(ckTipo.Checked);
                promocionActiva.producto = ((Admproductos)cbProducto.SelectedItem).CIDPRODUCTO;
                promocionActiva.id_clasificacion1 = ((Admclasificacionesvalores)cbClasificacion1.SelectedItem).CIDVALORCLASIFICACION;
                promocionActiva.clasificacion1 = ((Admclasificacionesvalores)cbClasificacion1.SelectedItem).CVALORCLASIFICACION;
                promocionActiva.descuento = Convert.ToDouble( nDescuento.Value);
                promocionActiva.cantidad = Convert.ToDouble(nCantidad.Value);

                promocionActiva.actualizar();
            }
            else
            {
                promocionActiva = new Promociones();
                promocionActiva.nombre = tNombre.Text;
                promocionActiva.fecha_inicio = dtInicio.Value;
                promocionActiva.fecha_final = dtFinal.Value;
                promocionActiva.tipo = Convert.ToInt32(ckTipo.Checked);
                promocionActiva.producto = ((Admproductos)cbProducto.SelectedItem).CIDPRODUCTO;
                promocionActiva.id_clasificacion1 = ((Admclasificacionesvalores)cbClasificacion1.SelectedItem).CIDCLASIFICACION;
                promocionActiva.clasificacion1 = ((Admclasificacionesvalores)cbClasificacion1.SelectedItem).CVALORCLASIFICACION;
                promocionActiva.descuento = Convert.ToDouble(nDescuento.Value);
                promocionActiva.cantidad = Convert.ToDouble(nCantidad.Value);

                promocionActiva.guardar();
            }

            limpiarFormulario();
            cargarTabla();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (promocionActiva != null)
            {
                promocionActiva.elimina();
                limpiarFormulario();
                cargarTabla();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una promoción previamente.");
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPromociones_Load(object sender, EventArgs e)
        {
            cargarClasificaciones1();
            cargarProductos();
            cargarTabla();
            limpiarFormulario();
        }

        private void cargarTabla()
        {
            listadoPromociones = (new Promociones()).obtenerTodos();

            objectListView1.SetObjects(listadoPromociones);
        }

        private void limpiarFormulario()
        {
            tNombre.Text = "";
            dtInicio.Value = DateTime.Now;
            dtFinal.Value = DateTime.Now;
            cbClasificacion1.SelectedIndex = 0;
            cbProducto.SelectedIndex = 0;
            ckTipo.Checked = false;
            nDescuento.Value = 0;
            nCantidad.Value = 0;

            promocionActiva = null;

        }

        private void cargarClasificaciones1()
        {
            Modelos.Negocio.Configuracion config = Modelos.Negocio.ConfigurationDBContext.obtener();

            var clasificaciones = (new Admclasificacionesvalores()).obtenerSQL("select * from admClasificacionesValores where CIDCLASIFICACION=25",ConfigurationManager.ConnectionStrings["bd"].ConnectionString.Replace("PuntoVentaComercial", config.empresa.Split('\\')[3]));

            foreach(var a in clasificaciones)
            {
                cbClasificacion1.Items.Add(a);
            }

        }

        private void cargarProductos()
        {
            Modelos.Negocio.Configuracion config = Modelos.Negocio.ConfigurationDBContext.obtener();
            var productos = new Admproductos().obtenerSQL("select * from admproductos order by CNOMBREPRODUCTO", ConfigurationManager.ConnectionStrings["bd"].ConnectionString.Replace("PuntoVentaComercial", config.empresa.Split('\\')[3]));

            foreach(var a in productos)
            {
                cbProducto.Items.Add(a);
            }
        }

        private void objectListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (objectListView1.SelectedItem != null)
            {
                promocionActiva = (Promociones)objectListView1.SelectedItem.RowObject;
                tNombre.Text = promocionActiva.nombre;
                dtInicio.Value = promocionActiva.fecha_inicio;
                dtFinal.Value = promocionActiva.fecha_final;
                ckTipo.Checked = Convert.ToBoolean(promocionActiva.tipo);

                int index = 0;

                foreach (var a in cbClasificacion1.Items)
                {
                    if (((Admclasificacionesvalores)a).CIDVALORCLASIFICACION == promocionActiva.id_clasificacion1)
                    {
                        cbClasificacion1.SelectedIndex = index;
                    }

                    index++;
                }

                index = 0;

                foreach (var a in cbProducto.Items)
                {
                    if (((Admproductos)a).CIDPRODUCTO == promocionActiva.producto)
                    {
                        cbProducto.SelectedIndex = index;
                    }

                    index++;
                }

                nDescuento.Value = Convert.ToDecimal(promocionActiva.descuento);
                nCantidad.Value = Convert.ToDecimal(promocionActiva.cantidad);
            }

            

        }
    }
}
