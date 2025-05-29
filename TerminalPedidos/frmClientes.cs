using SDKContpaq.SDKContpaq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TerminalPedidos
{
    public partial class frmClientes : AntdUI.Window
    {
        public frmClientes()
        {
            InitializeComponent();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            cbRegimenfiscal.SelectedIndex = 0;
            cbUsodecfdi.SelectedIndex = 0;
            cbFormaPago.SelectedIndex = 0;
        }

        private void pageHeader1_BackClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tCodigo.Text))
            {
                AntdUI.Message.error(this, "El campo Codigo es obligatorio.", new Font("Poppins", Globales.tamañoFuenteMensajes));
                tCodigo.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(tRfc.Text))
            {
                AntdUI.Message.error(this, "El campo RFC es obligatorio.", new Font("Poppins", Globales.tamañoFuenteMensajes));
                tRfc.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(tRazonsocial.Text))
            {
                AntdUI.Message.error(this, "El campo Razón Social es obligatorio.", new Font("Poppins", Globales.tamañoFuenteMensajes));
                tRazonsocial.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(tCodigopostal.Text))
            {
                AntdUI.Message.error(this, "El campo Código Postal es obligatorio.", new Font("Poppins", Globales.tamañoFuenteMensajes));
                tCodigopostal.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(tCalle.Text))
            {
                AntdUI.Message.error(this, "El campo Calle es obligatorio.", new Font("Poppins", Globales.tamañoFuenteMensajes));
                tCalle.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(tNumExt.Text))
            {
                AntdUI.Message.error(this, "El campo Número Exterior es obligatorio.", new Font("Poppins", Globales.tamañoFuenteMensajes));
                tNumExt.Focus();
                return;
            }

            // Número Interior puede ser opcional, pero si quieres validarlo también:
            if (string.IsNullOrWhiteSpace(tColonia.Text))
            {
                AntdUI.Message.error(this, "El campo Colonia es obligatorio.", new Font("Poppins", Globales.tamañoFuenteMensajes));
                tColonia.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(tPais.Text))
            {
                AntdUI.Message.error(this, "El campo País es obligatorio.", new Font("Poppins", Globales.tamañoFuenteMensajes));
                tPais.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(tEstado.Text))
            {
                AntdUI.Message.error(this, "El campo Estado es obligatorio.", new Font("Poppins", Globales.tamañoFuenteMensajes));
                tEstado.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(tCiudad.Text))
            {
                AntdUI.Message.error(this, "El campo Ciudad es obligatorio.", new Font("Poppins", Globales.tamañoFuenteMensajes));
                tCiudad.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(tMunicipio.Text))
            {
                AntdUI.Message.error(this, "El campo Municipio es obligatorio.", new Font("Poppins", Globales.tamañoFuenteMensajes));
                tMunicipio.Focus();
                return;
            }

            Cliente clientesdk = new Cliente();

            if (!clientesdk.existeCliente(tCodigo.Text.Trim()))
            {
                clientesdk.codigo = tCodigo.Text.Trim();
                clientesdk.rfc = tRfc.Text.Trim();
                clientesdk.razonSocial = tRazonsocial.Text.Trim();
                clientesdk.cp = tCodigopostal.Text.Trim();
                clientesdk.formapago = cbFormaPago.Text.Split('-')[0].Trim();
                clientesdk.regimen = cbRegimenfiscal.Text.Split('-')[0].Trim();
                clientesdk.usocfdi = cbUsodecfdi.Text.Split('-')[0].Trim();

                clientesdk.calle = tCalle.Text.Trim();
                clientesdk.numExt = tNumExt.Text.Trim();
                clientesdk.numInt = tNumInt.Text.Trim();
                clientesdk.colonia = tColonia.Text.Trim();
                clientesdk.pais = tPais.Text.Trim();
                clientesdk.estado = tEstado.Text.Trim();
                clientesdk.ciudad = tCiudad.Text.Trim();
                clientesdk.municipio = tMunicipio.Text.Trim();

                

                clientesdk.guardar();
                this.Close();
            }
            else
            {
                AntdUI.Message.error(this, "El cliente ya existe en el catálogo.", new Font("Poppins", Globales.tamañoFuenteMensajes));
            }

        }
    }
}
