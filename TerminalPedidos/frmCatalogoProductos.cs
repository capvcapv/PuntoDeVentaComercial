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
using System.Data.SqlClient;
using System.Configuration;

namespace TerminalPedidos
{
    public partial class frmCatalogoProductos : Form
    {
        private List<Producto> listaProductos = new List<Producto>();
        private int paginaActual = 0;
        private int registrosPorPagina = 50;
        private Form1 formularioPadre;

        private SqlConnection conexionGlobal;

        public frmCatalogoProductos(Form1 pPadre)
        {
            InitializeComponent();
            formularioPadre = pPadre;
            iniciaConexion();
        }

        private void CargarListadoProductos()
        {

            SqlCommand comando = new SqlCommand("select CCODIGOPRODUCTO,CNOMBREPRODUCTO,CPRECIO1,CPRECIO2,CPRECIO3,CPRECIO4,CPRECIO5,CPRECIO6,CPRECIO7,CPRECIO8,CPRECIO9,CPRECIO10 from admProductos where CTIPOPRODUCTO=1 and CSTATUSPRODUCTO= 1", conexionGlobal);

            SqlDataReader lector = comando.ExecuteReader();


            while (lector.Read())
            {
                Producto pro = new Producto();
                pro.codigo = lector["CCODIGOPRODUCTO"].ToString();
                pro.nombre = lector["CNOMBREPRODUCTO"].ToString();
                pro.existencia = 0;
                pro.precio1 = obtienePrecioIvaSiAplica(lector["CPRECIO1"].ToString());
                pro.precio2 = obtienePrecioIvaSiAplica(lector["CPRECIO2"].ToString());
                pro.precio3 = obtienePrecioIvaSiAplica(lector["CPRECIO3"].ToString());
                pro.precio4 = obtienePrecioIvaSiAplica(lector["CPRECIO4"].ToString());
                pro.precio5 = obtienePrecioIvaSiAplica(lector["CPRECIO5"].ToString());
                pro.precio6 = obtienePrecioIvaSiAplica(lector["CPRECIO6"].ToString());
                pro.precio7 = obtienePrecioIvaSiAplica(lector["CPRECIO7"].ToString());
                pro.precio8 = obtienePrecioIvaSiAplica(lector["CPRECIO8"].ToString());
                pro.precio9 = obtienePrecioIvaSiAplica(lector["CPRECIO9"].ToString());
                pro.precio10 = obtienePrecioIvaSiAplica(lector["CPRECIO10"].ToString());

                listaProductos.Add(pro);
            }

            lector.Close();

        }

        private void CargarPagina()
        {
            int inicio = paginaActual * registrosPorPagina;
            var paginaDeDatos = listaProductos.Skip(inicio).Take(registrosPorPagina).ToList();

          

            foreach(var a in listaProductos)
            {
                a.existencia = obtenerExistencia(a.codigo);
            }


            dataGridView1.DataSource = paginaDeDatos;
        }

        private void frmCatalogoProductos_Load(object sender, EventArgs e)
        {

            CargarListadoProductos();
            CargarPagina();
            refrescaTabla();

        }

        private string obtienePrecioIvaSiAplica(string importe)
        {
            string respuesta = "";

            if (ConfigurationManager.AppSettings["ivaIncluido"].Contains("False"))
            {
                
                respuesta = Math.Round((Convert.ToDouble(importe) / 1.16), 2).ToString();
                
            }
            else
            {
                respuesta = importe;
            }

            return respuesta;
        }

        private void iniciaConexion()
        {
            var configuracion = Modelos.Negocio.ConfigurationDBContext.obtener();
            conexionGlobal = new SqlConnection();
            conexionGlobal.ConnectionString = ConfigurationManager.ConnectionStrings["bd"].ConnectionString.Replace("PuntoVentaComercial", configuracion.empresa.Split('\\').Last());
            conexionGlobal.Open();
        }

        private void terminaConexion()
        {
            conexionGlobal.Close();
        }

        private double obtenerExistencia(string codigo)
        {
            double existencia = 0.0;

            string sql = "WITH movimientos AS ((SELECT entradas.cidalmacen, entradas.cidproducto, entradas.cunidades as cunidades FROM  dbo.admMovimientos entradas WHERE entradas.cafectadoinventario = 1 AND entradas.cafectaexistencia = 1) UNION ALL(SELECT salidas.cidalmacen, salidas.cidproducto, -1 * salidas.cunidades AS CUNIDADES FROM dbo.admMovimientos salidas WHERE salidas.cafectadoinventario = 1 AND salidas.cafectaexistencia = 2)) SELECT ROUND(SUM(cunidades), 2, 1) as EXISTENCIA FROM movimientos mov INNER JOIN dbo.admProductos prod ON prod.cidproducto = mov.cidproducto INNER JOIN dbo.admAlmacenes alm ON alm.cidalmacen = mov.cidalmacen WHERE alm.CCODIGOALMACEN = '1' and prod.ccodigoproducto='" + codigo + "';";

            SqlCommand comando = new SqlCommand(sql, conexionGlobal);

            SqlDataReader lector = comando.ExecuteReader();

            while (lector.Read())
            {
                if (lector["EXISTENCIA"] == DBNull.Value)
                {
                    existencia = 0;
                }
                else
                {
                    existencia= Convert.ToDouble(lector["EXISTENCIA"].ToString());
                }
            }

            lector.Close();
           
            return existencia;
        }

        private void refrescaTabla()
        {
            //dataGridView1.DataSource = null;
            //dataGridView1.DataSource = listaProductos;

            //dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 400;
            //dataGridView1.Columns[2].Width = 100;
            //dataGridView1.Columns[3].Width = 100;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            List<Producto> temp = listaProductos.FindAll(i => i.nombre.ToUpper().Contains(textBox1.Text.ToUpper()));

            if (temp.Count > 15)
            {
                temp = temp.Skip(0).Take(20).ToList();
            }

            foreach (var a in temp)
            {
                a.existencia = obtenerExistencia(a.codigo);
            }


            dataGridView1.DataSource = temp;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Producto pro = dataGridView1.CurrentRow.DataBoundItem as Producto;

            //string codigo = pro.codigo;
            //Double existencia = 0;

            //AdminPAQSDK.fRegresaExistencia(codigo,"1",DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Day.ToString(), ref existencia);
            //lAlmacen1.Text = existencia.ToString();

            //AdminPAQSDK.fRegresaExistencia(codigo, "2", DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Day.ToString(), ref existencia);
            //lAlmacen2.Text = existencia.ToString();

            //AdminPAQSDK.fRegresaExistencia(codigo, "3", DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Day.ToString(), ref existencia);
            //lAlmacen3.Text = existencia.ToString();

            //AdminPAQSDK.fRegresaExistencia(codigo, "4", DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Day.ToString(), ref existencia);
            //lAlmacen4.Text = existencia.ToString();

            //AdminPAQSDK.fRegresaExistencia(codigo, "5", DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Day.ToString(), ref existencia);
            //lAlmacen5.Text = existencia.ToString();

            //AdminPAQSDK.fRegresaExistencia(codigo, "6", DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Day.ToString(), ref existencia);
            //lAlmacen6.Text = existencia.ToString();

            //AdminPAQSDK.fRegresaExistencia(codigo, "7", DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Day.ToString(), ref existencia);
            //lAlmacen7.Text = existencia.ToString();

            //AdminPAQSDK.fRegresaExistencia(codigo, "8", DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Day.ToString(), ref existencia);
            //lAlmacen8.Text = existencia.ToString();

            //AdminPAQSDK.fRegresaExistencia(codigo, "9", DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString(), DateTime.Now.Day.ToString(), ref existencia);
            //lAlmacen9.Text = existencia.ToString();
        }

        private void tCodigo_TextChanged(object sender, EventArgs e)
        {
            List<Producto> temp = listaProductos.FindAll(i => i.codigo.ToUpper().Contains(tCodigo.Text.ToUpper()));

            if (temp.Count > 15)
            {
                temp=temp.Skip(0).Take(20).ToList();
            }

            foreach (var a in temp)
            {
                a.existencia = obtenerExistencia(a.codigo);
            }

            dataGridView1.DataSource = temp;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Producto pro = dataGridView1.CurrentRow.DataBoundItem as Producto;

            formularioPadre.tCodigo.Text = pro.codigo;
            //formularioPadre.tPrecio.Text = Convert.ToDouble(pro.precio1).ToString("C");
            formularioPadre.cbPrecio.Items.Clear();
            formularioPadre.cbPrecio.Items.Add(Convert.ToDouble(pro.precio1).ToString("C"));
            formularioPadre.cbPrecio.Items.Add(Convert.ToDouble(pro.precio2).ToString("C"));
            formularioPadre.cbPrecio.Items.Add(Convert.ToDouble(pro.precio3).ToString("C"));
            formularioPadre.cbPrecio.Items.Add(Convert.ToDouble(pro.precio4).ToString("C"));
            formularioPadre.cbPrecio.Items.Add(Convert.ToDouble(pro.precio5).ToString("C"));
            //formularioPadre.cbPrecio.Items.Add(Convert.ToDouble(pro.precio6).ToString("C"));
            //formularioPadre.cbPrecio.Items.Add(Convert.ToDouble(pro.precio7).ToString("C"));
            //formularioPadre.cbPrecio.Items.Add(Convert.ToDouble(pro.precio8).ToString("C"));
            //formularioPadre.cbPrecio.Items.Add(Convert.ToDouble(pro.precio9).ToString("C"));
            //formularioPadre.cbPrecio.Items.Add(Convert.ToDouble(pro.precio10).ToString("C"));

            formularioPadre.cbPrecio.SelectedIndex = 0;

            this.Close();
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter)
            {
                Producto pro = dataGridView1.CurrentRow.DataBoundItem as Producto;

                formularioPadre.tCodigo.Text = pro.codigo;
                formularioPadre.cbPrecio.Items.Clear();
                formularioPadre.cbPrecio.Items.Add(Convert.ToDouble(pro.precio1).ToString("C"));
                formularioPadre.cbPrecio.Items.Add(Convert.ToDouble(pro.precio2).ToString("C"));
                formularioPadre.cbPrecio.Items.Add(Convert.ToDouble(pro.precio3).ToString("C"));
                formularioPadre.cbPrecio.Items.Add(Convert.ToDouble(pro.precio4).ToString("C"));
                formularioPadre.cbPrecio.Items.Add(Convert.ToDouble(pro.precio5).ToString("C"));
                //formularioPadre.cbPrecio.Items.Add(Convert.ToDouble(pro.precio6).ToString("C"));
                //formularioPadre.cbPrecio.Items.Add(Convert.ToDouble(pro.precio7).ToString("C"));
                //formularioPadre.cbPrecio.Items.Add(Convert.ToDouble(pro.precio8).ToString("C"));
                //formularioPadre.cbPrecio.Items.Add(Convert.ToDouble(pro.precio9).ToString("C"));
                //formularioPadre.cbPrecio.Items.Add(Convert.ToDouble(pro.precio10).ToString("C"));

                formularioPadre.cbPrecio.SelectedIndex = 0;

                this.Close();
            }else if (e.KeyValue == (int)Keys.F3)
            {
                Producto pro = dataGridView1.CurrentRow.DataBoundItem as Producto;

                frmExistencias exis = new frmExistencias();            
                exis.codigoProducto = pro.codigo;
                exis.ShowDialog();

            }
        }

        private void tCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter)
            {
                Producto pro = dataGridView1.CurrentRow.DataBoundItem as Producto;

                formularioPadre.tCodigo.Text = pro.codigo;
                formularioPadre.cbPrecio.Items.Clear();
                formularioPadre.cbPrecio.Items.Add(Convert.ToDouble(pro.precio1).ToString("C"));
                formularioPadre.cbPrecio.Items.Add(Convert.ToDouble(pro.precio2).ToString("C"));
                formularioPadre.cbPrecio.Items.Add(Convert.ToDouble(pro.precio3).ToString("C"));
                formularioPadre.cbPrecio.Items.Add(Convert.ToDouble(pro.precio4).ToString("C"));
                formularioPadre.cbPrecio.Items.Add(Convert.ToDouble(pro.precio5).ToString("C"));
                //formularioPadre.cbPrecio.Items.Add(Convert.ToDouble(pro.precio6).ToString("C"));
                //formularioPadre.cbPrecio.Items.Add(Convert.ToDouble(pro.precio7).ToString("C"));
                //formularioPadre.cbPrecio.Items.Add(Convert.ToDouble(pro.precio8).ToString("C"));
                //formularioPadre.cbPrecio.Items.Add(Convert.ToDouble(pro.precio9).ToString("C"));
                //formularioPadre.cbPrecio.Items.Add(Convert.ToDouble(pro.precio10).ToString("C"));

                formularioPadre.cbPrecio.SelectedIndex = 0;

                this.Close();
            }else if (e.KeyValue == (int)Keys.F3)
            {
                Producto pro = dataGridView1.CurrentRow.DataBoundItem as Producto;

                frmExistencias exis = new frmExistencias();
                exis.codigoProducto = pro.codigo;
                exis.ShowDialog();

            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter)
            {
                Producto pro = dataGridView1.CurrentRow.DataBoundItem as Producto;

                formularioPadre.tCodigo.Text = pro.codigo;
                formularioPadre.cbPrecio.Items.Clear();
                formularioPadre.cbPrecio.Items.Add(Convert.ToDouble(pro.precio1).ToString("C"));
                formularioPadre.cbPrecio.Items.Add(Convert.ToDouble(pro.precio2).ToString("C"));
                formularioPadre.cbPrecio.Items.Add(Convert.ToDouble(pro.precio3).ToString("C"));
                formularioPadre.cbPrecio.Items.Add(Convert.ToDouble(pro.precio4).ToString("C"));
                formularioPadre.cbPrecio.Items.Add(Convert.ToDouble(pro.precio5).ToString("C"));
                //formularioPadre.cbPrecio.Items.Add(Convert.ToDouble(pro.precio6).ToString("C"));
                //formularioPadre.cbPrecio.Items.Add(Convert.ToDouble(pro.precio7).ToString("C"));
                //formularioPadre.cbPrecio.Items.Add(Convert.ToDouble(pro.precio8).ToString("C"));
                //formularioPadre.cbPrecio.Items.Add(Convert.ToDouble(pro.precio9).ToString("C"));
                //formularioPadre.cbPrecio.Items.Add(Convert.ToDouble(pro.precio10).ToString("C"));

                formularioPadre.cbPrecio.SelectedIndex = 0;

                this.Close();
            }
            else if (e.KeyValue == (int)Keys.F3)
            {
                Producto pro = dataGridView1.CurrentRow.DataBoundItem as Producto;

                frmExistencias exis = new frmExistencias();
                exis.codigoProducto = pro.codigo;
                exis.ShowDialog();

            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((paginaActual + 1) * registrosPorPagina < listaProductos.Count)
            {
                paginaActual++;
                CargarPagina();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (paginaActual > 0)
            {
                paginaActual--;
                CargarPagina();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            paginaActual = 0;
            CargarPagina();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            paginaActual = (listaProductos.Count - 1) / registrosPorPagina;
            CargarPagina();
        }

        private void frmCatalogoProductos_FormClosing(object sender, FormClosingEventArgs e)
        {
            terminaConexion();
        }
    }
}
