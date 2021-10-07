using SDKContpaq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AdministradorPV
{
    //TODO -ASIGNACION DE CLIENTE EN TERMINAL, CAMBIO EN CAJA Y RECALCULO DE DESCUENTOS*
    //TODO -TURNOS POR SUCURSAL 
    //TODO -CORTE DE CAJA DENOMINACIONES E IMPRIMIR A MINIPRINTER DEL CONTADOR

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            inicializaSDKComercial();
            frmLogin acceso = new frmLogin();
            acceso.ShowDialog();
        }

        private void inicializaSDKComercial()
        {
            Environment.CurrentDirectory = Modelos.Negocio.ConfigurationDBContext.obtener().rutaBinarios;

            AdminPAQSDK.fInicioSesionSDK("SUPERVISOR", "");
            AdminPAQSDK.fSetNombrePAQ("CONTPAQ I COMERCIAL");
            AdminPAQSDK.muestra_error(AdminPAQSDK.fAbreEmpresa(Modelos.Negocio.ConfigurationDBContext.obtener().empresa));
        }

        private void terminaSDKComercial()
        {
            AdminPAQSDK.fCierraEmpresa();
            AdminPAQSDK.fTerminaSDK();
        }

        private void parámetrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConfiguracion confing = new frmConfiguracion();
            confing.ShowDialog();
        }

        private void cajasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCajas caja = new frmCajas();
            caja.ShowDialog();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            terminaSDKComercial();
        }

        private void preciosDeVentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConfiguradorPrecios precios = new frmConfiguradorPrecios();
            precios.ShowDialog();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsuarios usua = new frmUsuarios();
            usua.ShowDialog();
        }

        private void facturaGlobalToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmCorteDeCaja corte = new frmCorteDeCaja();
            corte.ShowDialog();

        }
    }
}
