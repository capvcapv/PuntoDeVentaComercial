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
using CrystalDecisions.CrystalReports.Engine;
using System.Configuration;

namespace TerminalPedidos
{
    public partial class Form1 : Form
    {
        private List<Partida> partidas = new List<Partida>();
        private Cliente clienteActivo;
        private frmLogin acceso = new frmLogin();
        private frmTurnosDeCaja turno;

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            acceso.ShowDialog();

            if (acceso.aceptado)
            {

                turno = new frmTurnosDeCaja(acceso.usuarioActivo);
                turno.ShowDialog();

                if (turno.turnoActivo != null)
                {

                    var caja = Modelos.Negocio.CajasDBContext.obtener(turno.turnoActivo.caja);

                    this.Text = "Turno: " + turno.turnoActivo.id + " Usuario: " + acceso.usuarioActivo.nombre +" Almacen: " + caja.almacen + " Caja: " + caja.nombre;

                    inicializaSDKComercial();
                    textBox1.Focus();
                    cargaAgentes();
                }

            }

        }

        private void cargaAgentes()
        {
            AdminPAQSDK.fPosPrimerAgente();

            while (AdminPAQSDK.fPosEOFAgente() != 1)
            {

                StringBuilder codigo = new StringBuilder().Append('\0', 30);
                StringBuilder nombre = new StringBuilder().Append('\0', 60);
                AdminPAQSDK.fLeeDatoAgente("CCODIGOAGENTE", codigo,30);
                AdminPAQSDK.fLeeDatoAgente("CNOMBREAGENTE", nombre, 60);
                cbAgente.Items.Add(codigo.ToString()+" - " + nombre.ToString());

                AdminPAQSDK.fPosSiguienteAgente();
            }

            cbAgente.SelectedIndex = 0;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            terminaSDKComercial();
        }

        private void inicializaSDKComercial()
        {
            Modelos.Negocio.Configuracion config = Modelos.Negocio.ConfigurationDBContext.obtener();

            Environment.CurrentDirectory = config.rutaBinarios;

            AdminPAQSDK.fInicioSesionSDK("SUPERVISOR", "");
            AdminPAQSDK.fSetNombrePAQ("CONTPAQ I COMERCIAL");
            AdminPAQSDK.muestra_error(AdminPAQSDK.fAbreEmpresa(config.empresa));
        }

        private void terminaSDKComercial()
        {
            if (acceso.aceptado && turno.turnoActivo!=null)
            {
                AdminPAQSDK.fCierraEmpresa();
                AdminPAQSDK.fTerminaSDK();
            }

        }

        private void bF3_Click(object sender, EventArgs e)
        {
            frmCatalogoProductos ventanaCatalogo = new frmCatalogoProductos(this);
            ventanaCatalogo.ShowDialog();
            tCodigo.Focus();
        }

        private void tCodigo_KeyUp(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode.ToString() == "Return")
            {
                if (clienteActivo != null)
                {
                    if (!String.IsNullOrEmpty(tCodigo.Text))
                    {
                        if (AdminPAQSDK.fBuscaProducto(tCodigo.Text) == 0)
                        {
                            StringBuilder codigo = new StringBuilder().Append('\0', 30);
                            StringBuilder producto = new StringBuilder().Append('\0', 60);
                            StringBuilder precio = new StringBuilder().Append('\0', 30);

                            AdminPAQSDK.fLeeDatoProducto("CCODIGOPRODUCTO", codigo, 30);
                            AdminPAQSDK.fLeeDatoProducto("CNOMBREPRODUCTO", producto, 60);
                            AdminPAQSDK.fLeeDatoProducto("CPRECIO1", precio, 30);

                            Partida part = new Partida();
                            part.codigo = codigo.ToString();
                            part.producto = producto.ToString();
                            //part.descuento = clienteActivo.descuento;
                            part.precio = tPrecio.Text;
                            part.cantidad = tCantidad.Value.ToString();
                            part.importe = (Convert.ToDouble(part.precio.Replace("$", "").Replace(",", "")) * Convert.ToDouble(part.cantidad)).ToString("C");

                            partidas.Add(part);

                            dataGridView1.DataSource = null;
                            dataGridView1.DataSource = partidas;
                            actualizaTabla();
                        }
                        else
                        {
                            MessageBox.Show("Producto no existe en catálogo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        
                        tCantidad.Value = 1;

                    }
                    else
                    {
                        MessageBox.Show("Debe capturar un código válido.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Debe seleccionar un cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                                
                tCodigo.Text = "";
                tPrecio.Text = (0.0).ToString("C");
            }
        }

        private void actualizaTabla()
        {

           
            //dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            //dataGridView1.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //dataGridView1.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            //dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            double subtotal = 0;
            double iva = 0;
            double total = 0;

            foreach(var a in partidas)
            {
                AdminPAQSDK.fBuscaProducto(a.codigo);

                StringBuilder impuesto1 = new StringBuilder().Append('\0', 30);
                AdminPAQSDK.fLeeDatoProducto("CIMPUESTO1",impuesto1,30);

                subtotal += Convert.ToDouble(a.importe.Replace("$","")) - ((Convert.ToDouble(impuesto1.ToString())/100)*Convert.ToDouble(a.importe.Replace("$", "")));
                total += Convert.ToDouble(a.importe.Replace("$", ""));
            }

            iva = total - subtotal;

            lSubtotal.Text = subtotal.ToString("C");
            lIVA.Text = iva.ToString("C");
            lTotal.Text = total.ToString("C");

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if(MessageBox.Show("¿Desea eliminar la partida?", "Cancelación de partida", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Partida partidaSeleccionada = dataGridView1.CurrentRow.DataBoundItem as Partida;
                partidas.Remove(partidaSeleccionada);

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = partidas;

                actualizaTabla();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmCatalogoClientes clientes = new frmCatalogoClientes(this);
            clientes.ShowDialog();
            textBox1.Focus();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return")
            {
                if (!String.IsNullOrEmpty(textBox1.Text))
                {
                    AdminPAQSDK.fBuscaCteProv(textBox1.Text);

                    StringBuilder nombre = new StringBuilder().Append('\0', 60);
                    StringBuilder descuento = new StringBuilder().Append('\0', 30);

                    AdminPAQSDK.fLeeDatoCteProv("CRAZONSOCIAL", nombre, 60);
                    AdminPAQSDK.fLeeDatoCteProv("CDESCUENTOMOVTO", descuento, 30);

                    lCliente.Text = nombre.ToString() + " - " + descuento.ToString() + "%";
                    tCodigo.Focus();

                    clienteActivo = new Cliente();
                    clienteActivo.codigo = textBox1.Text;
                    clienteActivo.nombre = nombre.ToString();
                    clienteActivo.descuento = descuento.ToString();

                    partidas.Clear();
                    actualizaTabla();

                }
                else
                {
                    MessageBox.Show("Debe capturar un codigo de cliente válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void bTerminar_Click(object sender, EventArgs e)
        {


            if (clienteActivo != null)
            {

                CalculaCambio cal = new CalculaCambio(Convert.ToDouble(lTotal.Text.Replace("$","").Replace(",","")));
                cal.ShowDialog();

                var caja = Modelos.Negocio.CajasDBContext.obtener(turno.turnoActivo.caja);

                SDKContpaq.SDKContpaq.Factura fac = new SDKContpaq.SDKContpaq.Factura();
                fac.cliente = textBox1.Text;
                fac.concepto = caja.conceptoFactura;
                fac.agente = cbAgente.Text.Split('-')[0];
                fac.referencia = turno.turnoActivo.id.ToString();
                fac.part = new List<SDKContpaq.SDKContpaq.Partidas>();

                foreach(var a in partidas)
                {
                    SDKContpaq.SDKContpaq.Partidas part = new SDKContpaq.SDKContpaq.Partidas();
                    part.Almancen = caja.almacen.ToString();
                    part.Cantidad = a.cantidad;
                    part.Codigo = a.codigo;
                    part.Nombre = a.producto;
                    part.Precio = a.precio;

                    fac.part.Add(part);
                }

                var folio=fac.creaFactura();

                partidas = new List<Partida>();

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = partidas;
                actualizaTabla();

                var reporte = new ReportDocument();

                string execPath = AppDomain.CurrentDomain.BaseDirectory;

                reporte.Load(execPath + "\\rptTicket.rpt");

                var configuracion = Modelos.Negocio.ConfigurationDBContext.obtener();

                var config = Modelos.Utilerias.ObtenerConfig.obtenerDatosSQL(ConfigurationManager.ConnectionStrings["bd"].ConnectionString.Replace("PuntoVentaComercial", configuracion.empresa.Split('\\').Last()));

                reporte.DataSourceConnections[0].SetConnection(config.servidor, config.empresa, config.usuario, config.clave);

                reporte.SetParameterValue("cfolio", folio);
                reporte.SetParameterValue("cconcepto", caja.conceptoFactura);
                reporte.SetParameterValue("cliente", clienteActivo.nombre);
                reporte.SetParameterValue("domicilio", configuracion.direccion);
                reporte.SetParameterValue("empresa", configuracion.nombre);

                reporte.PrintToPrinter(1, true, 0, 0);


                MessageBox.Show("Venta registrada en comercial.");

            }
            else
            {
                MessageBox.Show("Debe tener un cliente activo.");
            }

        }

        private void bLimpiar_Click(object sender, EventArgs e)
        {
            partidas = new List<Partida>();

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = partidas;
            actualizaTabla();
        }

        private void bReimprimir_Click(object sender, EventArgs e)
        {
            frmReimpresion reim = new frmReimpresion(turno.turnoActivo.id.ToString());
            reim.ShowDialog();
        }

        private void tPrecio_Enter(object sender, EventArgs e)
        {
            ChampMonetaire monCode = new ChampMonetaire();
            monCode.ScanCible = (TextBox)sender;
            monCode.Valide_Enter();
        }

        private void tPrecio_Leave(object sender, EventArgs e)
        {
            ChampMonetaire monCode = new ChampMonetaire();
            monCode.ScanCible = (TextBox)sender;
            monCode.Valide_Leave();
        }

        private void tPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            ChampMonetaire monCode = new ChampMonetaire();
            monCode.ScanCible = (TextBox)sender;
            monCode.eKeyPressEvArg = (KeyPressEventArgs)e;
            monCode.Valide_KeyPress();
        }
    }
}
