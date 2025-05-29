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
    public partial class frmCatalogoClientes : AntdUI.Window
    {
        private List<Cliente> listaClientes = new List<Cliente>();
        private Form1 formularioPadre;

        public frmCatalogoClientes(Form1 pPadre)
        {
            InitializeComponent();
            formularioPadre = pPadre;            
        }

        private void frmCatalogoClientes_Load(object sender, EventArgs e)
        {

            obtenerClientes();
        }

        private void obtenerClientes()
        {
            var configuracion = Modelos.Negocio.ConfigurationDBContext.obtener();

            listaClientes.Clear();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["bd"].ConnectionString.Replace("PuntoVentaComercial", configuracion.empresa.Split('\\').Last());
            con.Open();

            SqlCommand comando = new SqlCommand("select * from admClientes where CTIPOCLIENTE<>3 and CESTATUS<>0", con);

            SqlDataReader lector = comando.ExecuteReader();

            while (lector.Read())
            {
                Cliente cli = new Cliente();
                cli.codigo = lector.GetValue(1).ToString();
                cli.nombre = lector.GetValue(2).ToString();
                cli.descuento = lector.GetValue(10).ToString();

                SqlConnection con2 = new SqlConnection();
                con2.ConnectionString = ConfigurationManager.ConnectionStrings["bd"].ConnectionString.Replace("PuntoVentaComercial", configuracion.empresa.Split('\\').Last());
                con2.Open();

                SqlCommand comando2 = new SqlCommand("select * from admDomicilios where CIDCATALOGO=" + lector.GetValue(0).ToString() + " and CTIPOCATALOGO=1 and CTIPODIRECCION=0", con2);

                SqlDataReader lector2 = comando2.ExecuteReader();

                if (lector2.Read())
                {
                    cli.domicilio = lector2.GetValue(4).ToString() + " " + lector2.GetValue(5).ToString() + " " + lector2.GetValue(6).ToString() + " " + lector2.GetValue(7).ToString() + " " + lector2.GetValue(8).ToString() + " " + lector2.GetValue(17).ToString() + " " + lector2.GetValue(16).ToString() + " " + lector2.GetValue(15).ToString();
                }

                lector2.Close();
                con2.Close();

                listaClientes.Add(cli);
            }

            lector.Close();
            con.Close();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = listaClientes;

            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            List<Cliente> temp = listaClientes.FindAll(i => i.codigo.ToUpper().Contains(tCodigo.Text.ToUpper()));
            dataGridView1.DataSource = temp;
        }

        private void tNombre_TextChanged(object sender, EventArgs e)
        {
            List<Cliente> temp = listaClientes.FindAll(i => i.nombre.ToUpper().Contains(tNombre.Text.ToUpper()));
            dataGridView1.DataSource = temp;
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Cliente clie = dataGridView1.CurrentRow.DataBoundItem as Cliente;

            formularioPadre.textBox1.Text = clie.codigo;

            this.Close();
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter)
            {
                Cliente clie = dataGridView1.CurrentRow.DataBoundItem as Cliente;

                formularioPadre.textBox1.Text = clie.codigo;

                this.Close();
            }
        }

        private void tCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter)
            {
                Cliente clie = dataGridView1.CurrentRow.DataBoundItem as Cliente;

                formularioPadre.textBox1.Text = clie.codigo;

                this.Close();
            }
        }

        private void tNombre_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter)
            {
                Cliente clie = dataGridView1.CurrentRow.DataBoundItem as Cliente;

                formularioPadre.textBox1.Text = clie.codigo;

                this.Close();
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter)
            {
                e.SuppressKeyPress = true;
            }

            
        }

        private void pageHeader1_BackClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCatalogoClientes_Shown(object sender, EventArgs e)
        {
            tCodigo.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmClientes frmclientes = new frmClientes();
            frmclientes.ShowDialog();

            obtenerClientes();
        }
    }
}
