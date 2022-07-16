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
    public partial class CalculaCambio : Form
    {

        private double total;

        public CalculaCambio(double pTotal)
        {
            InitializeComponent();
            total = pTotal;
            tTotal.Text = total.ToString();
        }

        private void CalculaCambio_Load(object sender, EventArgs e)
        {

        }

        private void tPago_KeyUp(object sender, KeyEventArgs e)
        {

            try
            {

                double pago = Convert.ToDouble(tPago.Text);

                tCambio.Text = (pago-total).ToString();


            } catch(Exception ex)
            {
                tPago.Text = "0";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tReferencia.Text))
            {
                tReferencia.Text = "-";
            }

            if (String.IsNullOrEmpty(tObservacion.Text))
            {
                tObservacion.Text = "-";
            }
            
            this.Close();
        }
    }
}
