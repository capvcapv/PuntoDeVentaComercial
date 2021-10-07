using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace AdministradorPV
{
    public partial class frmCorteDeCaja : Form
    {
        public frmCorteDeCaja()
        {
            InitializeComponent();
        }

        private void frmCorteDeCaja_Load(object sender, EventArgs e)
        {
            var listadoTurnosAbiertos = Modelos.Negocio.TurnosDBContext.obtenerListadoAbiertos();

            listBox1.Items.AddRange(listadoTurnosAbiertos.ToArray());
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            var turno = listBox1.SelectedItem as Modelos.Negocio.Turnos;
            var configuracion = Modelos.Negocio.ConfigurationDBContext.obtener();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["bd"].ConnectionString.Replace("PuntoVentaComercial",configuracion.empresa.Split('\\').Last());
            con.Open();

            SqlCommand comando = new SqlCommand("select count(*),sum(CTOTAL) from admDocumentos where CREFERENCIA=" + turno.id, con);

            SqlDataReader lector = comando.ExecuteReader();

            if (lector.Read())
            {
                lRemisiones.Text = lector.GetValue(0).ToString();
                lVentas.Text = Convert.ToDouble( lector.GetValue(1).ToString()).ToString("C");
            }

            lector.Close();
            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro desea cerrar el turno?", "Pregunta", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var turno = listBox1.SelectedItem as Modelos.Negocio.Turnos;
                turno.abierto = 1;

                Modelos.Negocio.TurnosDBContext.actualizar(turno);

                var listadoTurnosAbiertos = Modelos.Negocio.TurnosDBContext.obtenerListadoAbiertos();
                listBox1.Items.Clear();
                listBox1.Items.AddRange(listadoTurnosAbiertos.ToArray());

                frmReporteCorte corteReporte = new frmReporteCorte();
                corteReporte.referencia = turno.id.ToString();
                corteReporte.ShowDialog();

                MessageBox.Show("Proceso realizado correctamente.");
                
            }
        }
    }
}
