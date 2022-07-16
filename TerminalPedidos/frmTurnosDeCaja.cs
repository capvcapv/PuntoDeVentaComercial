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
    public partial class frmTurnosDeCaja : Form
    {

        private Modelos.Negocio.Usuarios usuarioActivo;
        public Modelos.Negocio.Turnos turnoActivo;
        public frmTurnosDeCaja(Modelos.Negocio.Usuarios pUsuario)
        {
            InitializeComponent();
            usuarioActivo = pUsuario;
        }

        private void frmTurnosDeCaja_Load(object sender, EventArgs e)
        {
            lUsuario.Text = usuarioActivo.nombre;

            var listadoCajas = Modelos.Negocio.CajasDBContext.obtenerListado();

            comboBox1.Items.AddRange(listadoCajas.ToArray());
            comboBox1.SelectedIndex = 0;

            lFechaApertura.Text = DateTime.Now.ToShortDateString();

            var listadoTurnosAbierto = Modelos.Negocio.TurnosDBContext.obtenerListadoAbiertos();

            dataGridView1.DataSource = listadoTurnosAbierto.ToList<Modelos.Negocio.Turnos>();

        }

        private void frmTurnosDeCaja_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (turnoActivo == null)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            turnoActivo = new Modelos.Negocio.Turnos();
            turnoActivo.caja=((Modelos.Negocio.Cajas)comboBox1.SelectedItem).id;
            turnoActivo.empleado = usuarioActivo.id;
            turnoActivo.fechaApertura = DateTime.Now;
            turnoActivo.fechaCierre = DateTime.Now;
            turnoActivo.abierto = 0;

            Modelos.Negocio.TurnosDBContext.guardar(turnoActivo);

            this.Close();

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            turnoActivo = dataGridView1.CurrentRow.DataBoundItem as Modelos.Negocio.Turnos;

            this.Close();
        }

        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.Enter)
            {
                turnoActivo = dataGridView1.CurrentRow.DataBoundItem as Modelos.Negocio.Turnos;

                this.Close();
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = true;
        }
    }
}
