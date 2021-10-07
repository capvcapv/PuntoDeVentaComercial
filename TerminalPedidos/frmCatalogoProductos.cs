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
        private Form1 formularioPadre;

        public frmCatalogoProductos(Form1 pPadre)
        {
            InitializeComponent();
            formularioPadre = pPadre;
        }

        private void frmCatalogoProductos_Load(object sender, EventArgs e)
        {
            //AdminPAQSDK.fPosPrimerProducto();

            //while (AdminPAQSDK.fPosEOFProducto() != 1)
            //{
            //    StringBuilder codigo = new StringBuilder().Append('\0', 30);
            //    StringBuilder nombre = new StringBuilder().Append('\0', 60);
            //    StringBuilder precio1 = new StringBuilder().Append('\0', 30);
            //    StringBuilder precio2 = new StringBuilder().Append('\0', 30);
            //    StringBuilder tipoProducto = new StringBuilder().Append('\0', 30);

            //    AdminPAQSDK.fLeeDatoProducto("CTIPOPRODUCTO", tipoProducto, 30);

            //    if(tipoProducto.ToString().Replace(" ", "") == "1")
            //    {
            //        AdminPAQSDK.fLeeDatoProducto("CCODIGOPRODUCTO", codigo, 30);
            //        AdminPAQSDK.fLeeDatoProducto("CNOMBREPRODUCTO", nombre, 60);
            //        AdminPAQSDK.fLeeDatoProducto("CPRECIO1", precio1, 30);
            //        AdminPAQSDK.fLeeDatoProducto("CPRECIO2", precio2, 30);

            //        Producto pro = new Producto();
            //        pro.codigo = codigo.ToString();
            //        pro.nombre = nombre.ToString();
            //        pro.precio1 = precio1.ToString();
            //        pro.precio2 = precio2.ToString();

            //        listaProductos.Add(pro);

            //    }

            //    AdminPAQSDK.fPosSiguienteProducto();
            //}

            var configuracion = Modelos.Negocio.ConfigurationDBContext.obtener();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["bd"].ConnectionString.Replace("PuntoVentaComercial", configuracion.empresa.Split('\\').Last());
            con.Open();

            SqlCommand comando = new SqlCommand("select * from admProductos where CTIPOPRODUCTO=1 and CSTATUSPRODUCTO= 1", con);

            SqlDataReader lector = comando.ExecuteReader();

            while (lector.Read())
            {
                Producto pro = new Producto();
                pro.codigo = lector.GetValue(1).ToString();
                pro.nombre = lector.GetValue(2).ToString();
                pro.precio1 = lector.GetValue(43).ToString();
                pro.precio2 = lector.GetValue(44).ToString();
                pro.precio3 = lector.GetValue(45).ToString();
                pro.precio4 = lector.GetValue(46).ToString();
                pro.precio5 = lector.GetValue(47).ToString();
                pro.precio6 = lector.GetValue(48).ToString();
                pro.precio7 = lector.GetValue(49).ToString();
                pro.precio8 = lector.GetValue(50).ToString();
                pro.precio9 = lector.GetValue(51).ToString();
                pro.precio10 = lector.GetValue(52).ToString();

                listaProductos.Add(pro);
            }

            lector.Close();
            con.Close();

            refrescaTabla();

        }

        private void refrescaTabla()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listaProductos;

            dataGridView1.Columns[0].Width = 100;
            dataGridView1.Columns[1].Width = 400;
            dataGridView1.Columns[2].Width = 100;
            dataGridView1.Columns[3].Width = 100;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            List<Producto> temp = listaProductos.FindAll(i => i.nombre.ToUpper().Contains(textBox1.Text.ToUpper()));
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
            dataGridView1.DataSource = temp;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Producto pro = dataGridView1.CurrentRow.DataBoundItem as Producto;

            formularioPadre.tCodigo.Text = pro.codigo;
            formularioPadre.tPrecio.Text = Convert.ToDouble(pro.precio1).ToString("C");

            this.Close();
        }
    }
}
