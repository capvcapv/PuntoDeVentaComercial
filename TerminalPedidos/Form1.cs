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
using System.Diagnostics;
using Microsoft.Win32;
using System.IO;
using Modelos.Negocio;
using System.Data.SqlClient;
using System.Management;
using System.Threading.Tasks;
using static AntdUI.FloatButton;
using AntdUI;
using Vanara.PInvoke;

namespace TerminalPedidos
{
    public partial class Form1 : AntdUI.Window
    {
        private List<Partida> partidas = new List<Partida>();
        private frmLogin acceso = new frmLogin();
        private frmTurnosDeCaja turno;
        public BindingSource binding;

        private Cliente clienteActivo;
        private bool esEdicion = false;
        private int idDoctoEdicion = 0;
        private string serieFolio = "";
        private string _observaciones = "";

        public Form1()
        {
            InitializeComponent();

        }

        private void CambiarColorPaneles(Control control, string colorHexadecimal)
        {
            //// Convertir el color hexadecimal a Color
            //Color color = ColorTranslator.FromHtml(colorHexadecimal);

            //// Iterar sobre todos los controles del formulario
            //foreach (Control ctrl in control.Controls)
            //{
            //    // Verificar si el control actual es un Panel
            //    if (ctrl is Panel)
            //    {
            //        // Cambiar el color de fondo del Panel al color especificado
            //        ctrl.BackColor = color;
            //    }

            //    // Llamar recursivamente a la función para los controles secundarios
            //    if (ctrl.HasChildren)
            //    {
            //        CambiarColorPaneles(ctrl, colorHexadecimal);
            //    }
            //}
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            VerificaLicencia();

            var config = Modelos.Negocio.ConfigurationDBContext.obtener();

            pictureBox1.Image = ByteArrayToImage(config.logo);
            //CambiarColorPaneles(this, ConfigurationManager.AppSettings["color"]);
            

            acceso.ShowDialog();

            if (acceso.aceptado)
            {

                turno = new frmTurnosDeCaja(acceso.usuarioActivo);
                turno.ShowDialog();

                if (turno.turnoActivo != null)
                {
                    using (var loading = new frmCargando())
                    {
                        loading.Show();
                        loading.TopMost = true;
                        loading.BringToFront();
                        Application.DoEvents();
                        await Task.Delay(3000);

                        var caja = Modelos.Negocio.CajasDBContext.obtener(turno.turnoActivo.caja);

                        pageHeader1.Text = "Turno: " + turno.turnoActivo.id + " Usuario: " + acceso.usuarioActivo.nombre + " Caja: " + caja.nombre;

                        inicializaSDKComercial();
                        textBox1.Focus();
                        cargaAgentes();
                        cargaAlmacenes();



                        binding = new BindingSource();
                        binding.DataSource = partidas;
                        dataGridView1.DataSource = binding;
                        dataGridView1.Refresh();

                        cargarConceptosCaja(caja);

                        cbConcepto.SelectedIndex = 0;

                        if (!Convert.ToBoolean(config.muestraVentanaDescuentos))
                        {
                            bDescuentos.Visible = false;
                        }

                        loading.Close();

                        if (config.limitePrecio1Precio3==0)
                        {
                            cbPrecio.List = true; 
                        }
                    }
                    
                }

            }

        }

        private void VerificaLicencia()
        {
            string rutaLicencia = Path.Combine(Application.StartupPath, "license.lic");

            if (!File.Exists(rutaLicencia))
            {
                MessageBox.Show("Falta activar sistema, NS:" + GetHardwareId());
                File.WriteAllText(GetHardwareId(), GetHardwareId());
                Application.Exit();
                return;
            }

            var publicKey = "MIIBKjCB4wYHKoZIzj0CATCB1wIBATAsBgcqhkjOPQEBAiEA/////wAAAAEAAAAAAAAAAAAAAAD///////////////8wWwQg/////wAAAAEAAAAAAAAAAAAAAAD///////////////wEIFrGNdiqOpPns+u9VXaYhrxlHQawzFOw9jvOPD4n0mBLAxUAxJ02CIbnBJNqZnjhE50mt4GffpAEIQNrF9Hy4SxCR/i85uVjpEDydwN9gS3rM6D0oTlF2JjClgIhAP////8AAAAA//////////+85vqtpxeehPO5ysL8YyVRAgEBA0IABBxUHFk+JNcyiuxPWgUznfT6qilk6Djbc7sKH0prRRF4KjaALTmDnDeXeI7j8jTatuGOkKQ0rSvJfqSJS2SwgB8=\r\n";
            var licenseContent = File.ReadAllText(rutaLicencia);
            var softwareId = "punto_venta";
            var isValid = ValidateLicense(licenseContent, publicKey, softwareId);

            if (!isValid)
            {
                MessageBox.Show("Licencia inválida, NS:" + GetHardwareId());
                File.WriteAllText(GetHardwareId(), GetHardwareId());
                Application.Exit();
                return;
            }
        }

        private bool ValidateLicense(string licenseContent, string publicKey, string softwareId)
        {
            var license = Portable.Licensing.License.Load(licenseContent);

            if (!license.VerifySignature(publicKey))
            {
                return false; // La firma no es válida
            }

            if (license.Expiration < DateTime.Now)
            {
                return false; // La licencia ha expirado
            }

            var systemUUID = GetHardwareId();
            if (license.ProductFeatures.Get("SystemUUID") != systemUUID)
            {
                return false; // La licencia no es para este equipo
            }

            if (license.ProductFeatures.Get("SoftwareId") != softwareId)
            {
                return false; // La licencia no es para este software
            }

            return true;
        }

        private string GetHardwareId()
        {
            string id = "";
            using (var searcher = new ManagementObjectSearcher("SELECT UUID FROM Win32_ComputerSystemProduct"))
            {
                foreach (var obj in searcher.Get())
                {
                    id = obj["UUID"].ToString();
                    break;
                }
            }
            return id;
        }

        private void cargarConceptosCaja(Modelos.Negocio.Cajas pCaja)
        {
            cbConcepto.Items.Add(pCaja.nombre1);
            cbConcepto.Items.Add(pCaja.nombre2);
            cbConcepto.Items.Add(pCaja.nombre3);
            cbConcepto.Items.Add(pCaja.nombre4);
            cbConcepto.Items.Add(pCaja.nombre5);
            cbConcepto.Items.Add(pCaja.nombre6);
        }

        private Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                Image image = Image.FromStream(ms);
                return image;
            }
        }

        private void verificarDescuentos()
        {
            Dictionary<string, double> miDiccionario = new Dictionary<string, double>();

            foreach(var a in partidas)
            {
                a.descuento = "0.00";

                double valor = 0;
                
                if(miDiccionario.TryGetValue(a.codigo,out valor))
                {
                    miDiccionario[a.codigo] = Convert.ToDouble(a.cantidad) + valor;
                }
                else
                {
                    miDiccionario[a.codigo] = Convert.ToDouble(a.cantidad);
                }
            }

            Modelos.Negocio.Configuracion config = Modelos.Negocio.ConfigurationDBContext.obtener();

            foreach (var kvp in miDiccionario)
            {
                var producto_comercial = (new Admproductos()).obtenerSQL("select * from admProductos where CCODIGOPRODUCTO='" + kvp.Key + "'", ConfigurationManager.ConnectionStrings["bd"].ConnectionString.Replace("PuntoVentaComercial", config.empresa.Split('\\')[3]));

                var promocion = (new Promociones()).obtenerSQL("select * from promociones where id_clasificacion1=" + producto_comercial[0].CIDVALORCLASIFICACION1 + " and cantidad<=" + kvp.Value + " and (fecha_inicio <= GETDATE() AND fecha_final >= GETDATE())");

                if (promocion.Count>0)
                {
                    if (promocion[0].tipo == 0)
                    {
                        foreach (var a in partidas)
                        {
                            if (a.codigo == kvp.Key)
                            {
                                a.porcentajeDescuento = promocion[0].descuento.ToString();
                                a.descuento = ((Convert.ToDouble(a.precio.Replace("$", "").Replace(",", ""))) * ((Convert.ToDouble(promocion[0].descuento) / 100))).ToString("C");
                                a.importe = ((Convert.ToDouble(a.precio.Replace("$", "").Replace(",", "")) - Convert.ToDouble(a.descuento.Replace("$", "").Replace(",", ""))) * Convert.ToDouble(a.cantidad)).ToString("C");
                            }
                        }
                    }
                    
                }

                promocion = new Promociones().obtenerSQL("select * from promociones where producto=" + producto_comercial[0].CIDPRODUCTO + " and cantidad<=" + kvp.Value + " and (fecha_inicio <= GETDATE() AND fecha_final >= GETDATE())");

                if (promocion.Count > 0)
                {
                    if (promocion[0].tipo == 1)
                    {
                        foreach (var a in partidas)
                        {
                            if (a.codigo == kvp.Key)
                            {
                                a.porcentajeDescuento = promocion[0].descuento.ToString();
                                a.descuento = ((Convert.ToDouble(a.precio.Replace("$", "").Replace(",", ""))) * ((Convert.ToDouble(promocion[0].descuento) / 100))).ToString("C");
                                a.importe = ((Convert.ToDouble(a.precio.Replace("$", "").Replace(",", "")) - Convert.ToDouble(a.descuento.Replace("$", "").Replace(",", ""))) * Convert.ToDouble(a.cantidad)).ToString("C");
                            }
                        }
                    }
                                        
                }

            }




        }

        private void cargaAlmacenes()
        {
            AdminPAQSDK.fPosPrimerAlmacen();

            while (AdminPAQSDK.fPosEOFAlmacen() != 1)
            {
                StringBuilder codigo = new StringBuilder().Append('\0', 30);
                StringBuilder nombre = new StringBuilder().Append('\0', 60);
                AdminPAQSDK.fLeeDatoAlmacen("CCODIGOALMACEN", codigo, 30);
                AdminPAQSDK.fLeeDatoAlmacen("CNOMBREALMACEN", nombre, 60);
                
                if(codigo.ToString().Trim()== "1" || codigo.ToString().Trim() == "2" || codigo.ToString().Trim() == "3" || codigo.ToString().Trim() == "4")
                {
                    cbAlmacen.Items.Add(codigo.ToString() + " - " + nombre.ToString());
                }

                AdminPAQSDK.fPosSiguienteAlmacen();
            }

            //cbAlmacen.Items.RemoveAt(0);

            cbAlmacen.SelectedIndex = 0;
        }

        private void cargaAgentes()
        {
            var configuracion = Modelos.Negocio.ConfigurationDBContext.obtener();
            string cadena = ConfigurationManager.ConnectionStrings["bd"].ConnectionString.Replace("PuntoVentaComercial", configuracion.empresa.Split('\\').Last());

            var agentes = (new Modelos.Negocio.Admagentes()).obtenerTodos(cadena);

            //cbAgente.DataSource = agentes;
            List<ComboboxItem> agentesCombo = new List<ComboboxItem>();

            foreach(var a in agentes)
            {
                ComboboxItem item = new ComboboxItem();
                item.Text = a.CNOMBREAGENTE;
                item.Value = a.CCODIGOAGENTE;
                agentesCombo.Add(item);
            }

            cbAgente.Items.AddRange(agentesCombo.ToArray());

            var agente_venta_actual = (new Admagentes()).obtenerId(acceso.usuarioActivo.agente,cadena);
            //cbAgente.SelectedItem = agente_venta_actual;

            foreach (var agente in cbAgente.Items)
            {
                if (agente.ToString().Contains(agente_venta_actual.CNOMBREAGENTE))
                {
                    cbAgente.SelectedValue = agente;
                }
            }

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            terminaSDKComercial();
        }

        private void inicializaSDKComercial()
        {
            Modelos.Negocio.Configuracion config = Modelos.Negocio.ConfigurationDBContext.obtener();

            string rutaComercial = "";

            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Computación en Acción, SA CV\CONTPAQ I COMERCIAL");
            if (key != null)
            {
                rutaComercial= key.GetValue("DIRECTORIOBASE").ToString();
                
                key.Close();
            }
            else
            {
                key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Computación en Acción, SA CV\CONTPAQ I COMERCIAL");
                rutaComercial = key.GetValue("DIRECTORIOBASE").ToString();

                key.Close();
            }

            Environment.CurrentDirectory = rutaComercial;

            AdminPAQSDK.fInicioSesionSDK("PUNTOVENTA", "Pdv12345.");
            AdminPAQSDK.muestra_error(AdminPAQSDK.fSetNombrePAQ("CONTPAQ I COMERCIAL"));
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

        private double obtenerExistencia(string codigo)
        {
            double existencia = 0.0;

            var configuracion = Modelos.Negocio.ConfigurationDBContext.obtener();

            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["bd"].ConnectionString.Replace("PuntoVentaComercial", configuracion.empresa.Split('\\').Last());
            con.Open();

            string sql = "WITH movimientos AS ((SELECT entradas.cidalmacen, entradas.cidproducto, entradas.cunidades as cunidades FROM  dbo.admMovimientos entradas WHERE entradas.cafectadoinventario = 1 AND entradas.cafectaexistencia = 1) UNION ALL(SELECT salidas.cidalmacen, salidas.cidproducto, -1 * salidas.cunidades AS CUNIDADES FROM dbo.admMovimientos salidas WHERE salidas.cafectadoinventario = 1 AND salidas.cafectaexistencia = 2)) SELECT prod.ccodigoproducto as CODIGO_PRODUCTO, prod.cnombreproducto as NOMBRE_PRODUCTO, alm.ccodigoalmacen as ALMACEN, ROUND(SUM(cunidades), 2, 1) as EXISTENCIA FROM movimientos mov INNER JOIN dbo.admProductos prod ON prod.cidproducto = mov.cidproducto INNER JOIN dbo.admAlmacenes alm ON alm.cidalmacen = mov.cidalmacen WHERE alm.CCODIGOALMACEN = '1' and prod.ccodigoproducto='" + codigo + "' GROUP BY prod.ccodigoproducto, prod.cnombreproducto, alm.ccodigoalmacen;";

            SqlCommand comando = new SqlCommand(sql, con);

            SqlDataReader lector = comando.ExecuteReader();

            while (lector.Read())
            {
                if (lector["EXISTENCIA"] == DBNull.Value)
                {
                    return 0.0;
                }
                else
                {
                    return lector.GetDouble(3);
                }
            }

            lector.Close();
            con.Close();

            return existencia;
        }

        private void agregarPartida()
        {
            if (clienteActivo != null)
            {
                if (!String.IsNullOrEmpty(tCodigo.Text))
                {
                    if (obtenerExistencia(tCodigo.Text) >= Convert.ToDouble(tCantidad.Value))
                    {
                        if (AdminPAQSDK.fBuscaProducto(tCodigo.Text) == 0)
                        {
                            StringBuilder codigo = new StringBuilder().Append('\0', 30);
                            StringBuilder producto = new StringBuilder().Append('\0', 60);
                            StringBuilder precio = new StringBuilder().Append('\0', 30);
                            StringBuilder puntos = new StringBuilder().Append('\0', 30);

                            AdminPAQSDK.fLeeDatoProducto("CCODIGOPRODUCTO", codigo, 30);
                            AdminPAQSDK.fLeeDatoProducto("CNOMBREPRODUCTO", producto, 60);
                            AdminPAQSDK.fLeeDatoProducto("CPRECIO1", precio, 30);
                            AdminPAQSDK.fLeeDatoProducto("CTEXTOEXTRA1", puntos, 30);

                            Partida part = new Partida();
                            part.codigo = codigo.ToString();
                            part.producto = producto.ToString();
                            //part.descuento = clienteActivo.descuento;
                            part.almacen = cbAlmacen.Text.Split('-')[0].Trim();

                            var configGen = Modelos.Negocio.ConfigurationDBContext.obtener();

                            if (String.IsNullOrEmpty(cbPrecio.Text))
                            {

                                if (!Convert.ToBoolean(configGen.ivaincluido))//ConfigurationManager.AppSettings["ivaIncluido"].Contains("False"))
                                {

                                    part.precio = Math.Round((Convert.ToDouble(precio) / 1.16), 2).ToString();

                                }
                                else
                                {
                                    part.precio = Math.Round(Convert.ToDouble(precio.ToString()), 2).ToString();//tPrecio.Text;
                                }


                            }
                            else
                            {
                                if (!Convert.ToBoolean(configGen.ivaincluido))//ConfigurationManager.AppSettings["ivaIncluido"].Contains("Flase"))
                                {

                                    part.precio = Math.Round((Convert.ToDouble(cbPrecio.Text.Replace("$", "").Replace(",", "")) / 1.16), 2).ToString();

                                }
                                else
                                {
                                    part.precio = Math.Round(Convert.ToDouble(cbPrecio.Text.Replace("$", "").Replace(",", "")), 2).ToString();//cbPrecio.Text;//tPrecio.Text;
                                }
                            }

                            

                            part.porcentajeDescuento = tDescuento.Text;
                            part.cantidad = tCantidad.Value.ToString();

                            if (tDescuento.Value == 0)
                            {
                                part.descuento = "0";
                            }
                            else
                            {
                                part.descuento = ((Convert.ToDouble(part.precio.Replace("$", "").Replace(",", ""))) * ((Convert.ToDouble(tDescuento.Value) / 100))).ToString("C");
                            }
                                                            
                            part.importe = ((Convert.ToDouble(part.precio.Replace("$", "").Replace(",", "")) - Convert.ToDouble(part.descuento.Replace("$", "").Replace(",", ""))) * Convert.ToDouble(part.cantidad)).ToString("C");

                            part.puntos = puntos.ToString();

                            binding.Add(part);

                            var config = Modelos.Negocio.ConfigurationDBContext.obtener();

                            if (config.descuentoPorVolumen == 1)
                            {
                                actualizaTabla();
                            }
                            else
                            {
                                actualizaTablaSinCalculo();
                            }
                                                                
                            cbPrecio.Items.Clear();
                            cbPrecio.Refresh();
                        }
                        else
                        {
                            MessageBox.Show("Producto no existe en catálogo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Producto no tiene existencias suficientes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cbPrecio.Items.Clear();
                        cbPrecio.Refresh();
                        tCodigo.Text = "";
                        tCantidad.Value = 1;
                    }

                    tCantidad.Value = 1;
                    limpiaProductosARX();

                }
                else
                {
                    MessageBox.Show("Debe capturar un código válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            tCodigo.Text = "";
            tPrecio.Text = (0.0).ToString("C");
        }

        private string obtienePrecioIvaSiAplica(string importe)
        {
            string respuesta = "";

            Configuracion config = Modelos.Negocio.ConfigurationDBContext.obtener();

            if (config.ivaincluido==0)
            {

                respuesta = Math.Round((Convert.ToDouble(importe) / 1.16), 2).ToString();

            }
            else
            {
                respuesta = importe;
            }

            return respuesta;
        }

        private void tCodigo_KeyUp(object sender, KeyEventArgs e)
        {

            if (e.KeyCode.ToString() == "Return")
            {
                if (AdminPAQSDK.fBuscaProducto(tCodigo.Text) != 0)
                {
                    AntdUI.Message.error(this, "El producto no existe en el catálogo.", new Font("Poppins", Globales.tamañoFuenteMensajes));

                    tCodigo.Text = "";
                    tCodigo.Focus();
                }
                else
                {

                    cbPrecio.Items.Clear();

                    for (int i = 1; i < 6; i++)
                    {
                        StringBuilder precio = new StringBuilder().Append('\0', 30);
                        AdminPAQSDK.fLeeDatoProducto("CPRECIO" + i.ToString(), precio, 30);
                        cbPrecio.Items.Add(Convert.ToDouble(precio.ToString()).ToString("C"));
                    }

                    cbPrecio.SelectedIndex = 0;
                    cbPrecio.Text = cbPrecio.Items[0].ToString();

                    tCantidad.Focus();
                    tCantidad.SelectAll();
                }

            }
            else if (e.KeyValue == (int)Keys.F3)
            {
                try
                {
                    frmCatalogoProductos ventanaCatalogo = new frmCatalogoProductos(this);
                    ventanaCatalogo.ShowDialog();

                    tCodigo.Focus();
                }
                catch (Exception ex) { }
                
                
            }
        }

        private void actualizaTabla()
        {
            double subtotal = 0;
            double iva = 0;
            double total = 0;

            verificarDescuentos();

            foreach (var a in partidas)
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

            dataGridView1.Refresh();

        }



        public void actualizaTablaSinCalculo()
        {

            double subtotal = 0;
            double iva = 0;
            double total = 0;

            foreach (var a in partidas)
            {
                AdminPAQSDK.fBuscaProducto(a.codigo);

                StringBuilder impuesto1 = new StringBuilder().Append('\0', 30);
                AdminPAQSDK.fLeeDatoProducto("CIMPUESTO1", impuesto1, 30);

                subtotal += Convert.ToDouble(a.importe.Replace("$", "")) - ((Convert.ToDouble(impuesto1.ToString()) / 100) * Convert.ToDouble(a.importe.Replace("$", "")));
                total += Convert.ToDouble(a.importe.Replace("$", ""));
            }

            iva = total - subtotal;

            lSubtotal.Text = subtotal.ToString("C");
            lIVA.Text = iva.ToString("C");
            lTotal.Text = total.ToString("C");

            //verificarDescuentos();

            dataGridView1.Refresh();

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            

        }



        private void limpiaProductosARX()
        {

            //if(cbConcepto.Text!="Remisión ARX" && cbConcepto.Text != "Pedido ARX" && cbConcepto.Text != "Cotización" && cbConcepto.Text != "Cotización ARX")
            //{
            //    foreach (DataGridViewRow a in dataGridView1.Rows)
            //    {
            //        Partida partidaSeleccionada =a.DataBoundItem as Partida;

            //        if (partidaSeleccionada.producto.ToUpper().Contains("ARX"))
            //        {
            //            binding.Remove(partidaSeleccionada);
            //        }
            //    }

            //    dataGridView1.DataSource = null;
            //    dataGridView1.DataSource = binding;
            //    System.Threading.Thread.Sleep(500);
            //    dataGridView1.Refresh();

            //    actualizaTabla();
            //}
            //else if(cbConcepto.Text == "Remisión ARX" || cbConcepto.Text == "Pedido ARX")
            //{
            //    foreach (DataGridViewRow a in dataGridView1.Rows)
            //    {
            //        Partida partidaSeleccionada = a.DataBoundItem as Partida;

            //        if (!partidaSeleccionada.producto.ToUpper().Contains("ARX"))
            //        {
            //            binding.Remove(partidaSeleccionada);
            //        }
            //    }

            //    dataGridView1.DataSource = null;
            //    dataGridView1.DataSource = binding;
            //    System.Threading.Thread.Sleep(500);
            //    dataGridView1.Refresh();

            //    actualizaTabla();
            //}

            
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

                    //partidas.Clear();
                    actualizaTabla();

                }
                else
                {
                    MessageBox.Show("Debe capturar un codigo de cliente válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (e.KeyValue == (int)Keys.F3)
            {
                frmCatalogoClientes clientes = new frmCatalogoClientes(this);
                clientes.ShowDialog();
                textBox1.Focus();
            }
        }

        private void bTerminar_Click(object sender, EventArgs e)
        {

            if (clienteActivo != null)
            {
                var configGen = Modelos.Negocio.ConfigurationDBContext.obtener();
                string referencia = "";
                

                if (Convert.ToBoolean(configGen.imprime_ticket))
                {
                    CalculaCambio cal = new CalculaCambio(Convert.ToDouble(lTotal.Text.Replace("$", "").Replace(",", "")));
                    cal.ShowDialog();

                    referencia = cal.tReferencia.Text;
                    _observaciones = cal.tObservacion.Text;
                }

                var caja = Modelos.Negocio.CajasDBContext.obtener(turno.turnoActivo.caja);

                SDKContpaq.SDKContpaq.Factura fac = new SDKContpaq.SDKContpaq.Factura();
                fac.cliente = textBox1.Text;


                string formato = "";
                string titulo = "";
                bool seImprime = false;

                switch (cbConcepto.SelectedIndex)
                {
                    case 0:
                        fac.concepto = caja.conceptoFactura;
                        formato = caja.formato1;
                        titulo = cbConcepto.Text;
                        seImprime = caja.imprime1;
                        break;
                    case 1:
                        fac.concepto = caja.conceptoRemision;
                        formato = caja.formato2;
                        titulo = cbConcepto.Text;
                        seImprime = caja.imprime2;
                        break;
                    case 2:
                        fac.concepto = caja.conceptoPedido;
                        formato = caja.formato3;
                        titulo = cbConcepto.Text;
                        seImprime = caja.imprime3;
                        break;
                    case 3:
                        fac.concepto = caja.conceptoPedido2;
                        formato = caja.formato4;
                        titulo = cbConcepto.Text;
                        seImprime = caja.imprime4;
                        break;
                    case 4:
                        fac.concepto = caja.conceptoCotizacion;
                        formato = caja.formato5;
                        titulo = cbConcepto.Text;
                        seImprime = caja.imprime5;
                        break;
                    case 5:
                        fac.concepto = caja.conceptoCotizacion2;
                        formato = caja.formato6;
                        titulo = cbConcepto.Text;
                        seImprime = caja.imprime6;
                        break;
                    default:
                        break;
                }

                fac.agente = ((ComboboxItem)cbAgente.SelectedValue).Value.ToString();
                fac.referencia = referencia;
                fac.textoextra1 = turno.turnoActivo.id.ToString();
                fac.observaciones = _observaciones;
                _observaciones = "";
                fac.part = new List<SDKContpaq.SDKContpaq.Partidas>();
                
                int puntos_totales = 0;

                foreach(var a in partidas)
                {
                    SDKContpaq.SDKContpaq.Partidas part = new SDKContpaq.SDKContpaq.Partidas();
                    //part.Almancen = caja.almacen.ToString();
                    part.Cantidad = a.cantidad;
                    part.Codigo = a.codigo;
                    part.Nombre = a.producto;
                    part.Precio = (Convert.ToDouble(a.precio.Replace("$", "").Replace(",", ""))).ToString("C");
                    part.Descuento = Convert.ToDouble(a.descuento.Replace("$", "").Replace(",", "")).ToString("C");
                    part.PorcentajeDescuento = a.porcentajeDescuento;

                    if (!Convert.ToBoolean(configGen.ivaincluido)) //ConfigurationManager.AppSettings["ivaIncluido"].Contains("False"))
                    {
                        part.Precio = Math.Round(Convert.ToDouble(part.Precio) / 1.16, 2).ToString();
                    }

                    part.Almancen = a.almacen;

                    fac.part.Add(part);

                    if (String.IsNullOrEmpty(a.puntos))
                    {
                        puntos_totales += Convert.ToInt32("0");
                    }
                    else
                    {
                        puntos_totales += Convert.ToInt32(a.puntos);
                    }

                    
                }

                if (esEdicion)
                {
                    AdminPAQSDK.fBuscarIdDocumento(idDoctoEdicion);
                    AdminPAQSDK.fEditarDocumento();
                    AdminPAQSDK.fBorraDocumento();

                    fac.serie = serieFolio.Split('-')[0].Trim();
                    fac.sigFolio = Convert.ToDouble(serieFolio.Split('-')[1].Trim());
                }
                else
                {
                    fac.sigFolio = 0;
                }

                var folio = fac.creaFactura();

                binding.DataSource = null;
                partidas = new List<Partida>();
                binding.DataSource = partidas;
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = binding;

                actualizaTabla();

                //frmVisorFormato formatoVisor = new frmVisorFormato();
                //formatoVisor.formato = formato;
                //formatoVisor.folio = folio;
                //formatoVisor.concepto = fac.concepto;
                //formatoVisor.nombre = clienteActivo.nombre;
                //formatoVisor.titulo = titulo;
                //formatoVisor.agente = cbAgente.Text.Split('-')[0];
                //formatoVisor.ShowDialog();



                if (seImprime)
                {
                    var reporte = new ReportDocument();
                    string execPath = AppDomain.CurrentDomain.BaseDirectory;
                    reporte.Load(execPath + formato);

                    var configuracion = Modelos.Negocio.ConfigurationDBContext.obtener();
                    var config = Modelos.Utilerias.ObtenerConfig.obtenerDatosSQL(ConfigurationManager.ConnectionStrings["bd"].ConnectionString.Replace("PuntoVentaComercial", configuracion.empresa.Split('\\').Last()));
                    reporte.DataSourceConnections[0].SetConnection(config.servidor, config.empresa, config.usuario, config.clave);

                    reporte.SetParameterValue("cfolio", folio);
                    reporte.SetParameterValue("cconcepto", fac.concepto);
                    reporte.SetParameterValue("cliente", clienteActivo.nombre);
                    reporte.SetParameterValue("domicilio", configuracion.direccion);
                    reporte.SetParameterValue("empresa", configuracion.nombre);
                    reporte.SetParameterValue("agente", cbAgente.Text.Split('-')[0]);
                    reporte.SetParameterValue("puntos", puntos_totales.ToString());

                    if (!String.IsNullOrEmpty(titulo))
                    {
                        reporte.SetParameterValue("titulo", titulo);
                    }

                    PrintDialog dialog1 = new PrintDialog();
                    dialog1.AllowSomePages = true;
                    dialog1.AllowPrintToFile = false;

                    if (dialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        int copies = 1;// dialog1.PrinterSettings.Copies;
                        int fromPage = dialog1.PrinterSettings.FromPage;
                        int toPage = dialog1.PrinterSettings.ToPage;
                        bool collate = dialog1.PrinterSettings.Collate;

                        reporte.PrintOptions.PrinterName = dialog1.PrinterSettings.PrinterName;

                        if (formato.Contains("rptTicket"))
                        {
                            reporte.SetParameterValue("copia", "ORIGINAL");
                            reporte.PrintToPrinter(copies, collate, fromPage, toPage);
                        }
                        else
                        {
                            reporte.SetParameterValue("copia", "ORIGINAL");
                            reporte.PrintToPrinter(copies, collate, fromPage, toPage);

                            reporte.SetParameterValue("copia", "COPIA");
                            reporte.PrintToPrinter(copies, collate, fromPage, toPage);
                        }


                    }

                    dialog1.Dispose();

                    //if (formato.Contains("rptTicket"))
                    //{
                    //    reporte.SetParameterValue("copia", "ORIGINAL");
                    //    reporte.PrintToPrinter(1, false, 0, 0);
                    //}
                    //else
                    //{
                    //    reporte.SetParameterValue("copia", "ORIGINAL");
                    //    reporte.PrintToPrinter(1, false, 0, 0);

                    //    reporte.SetParameterValue("copia", "COPIA");
                    //    reporte.PrintToPrinter(1, false, 0, 0);
                    //}

                    reporte.Dispose();
                }
                else
                {
                    MessageBox.Show("Creado con folio: " + folio);
                }

                bLimpiar_Click(sender, e);

            }
            else
            {
                MessageBox.Show("Debe tener un cliente activo.");
            }

        }

        private void bLimpiar_Click(object sender, EventArgs e)
        {
            cbConcepto.Enabled = true;
            clienteActivo = null;
            esEdicion = false;
            idDoctoEdicion = 0;
            serieFolio = "";
            lCliente.Text = "-";
            textBox1.Text = "";
            textBox1.Focus();

            partidas = new List<Partida>();

            binding.DataSource = null;
            binding.DataSource = partidas;

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = binding;
            actualizaTabla();
        }

        private void bReimprimir_Click(object sender, EventArgs e)
        {

            var caja = Modelos.Negocio.CajasDBContext.obtener(turno.turnoActivo.caja);
            string concepto = "";
            
            switch (cbConcepto.SelectedIndex)
            {
                case 0:
                    concepto = caja.conceptoFactura;
                    break;
                case 1:
                    concepto = caja.conceptoRemision;
                    break;
                case 2:
                    concepto = caja.conceptoPedido;
                    break;
                case 3:
                    concepto = caja.conceptoPedido2;
                    break;
                case 4:
                    concepto = caja.conceptoCotizacion;
                    break;
                case 5:
                    concepto = caja.conceptoCotizacion2;
                    break;
                default:
                    break;
            }

            frmReimpresion reim = new frmReimpresion(turno.turnoActivo.id.ToString(),this);
            reim.concepto = concepto;
            reim.ShowDialog();

            esEdicion = reim.esEdicion;

            if (esEdicion)
            {
                textBox1_KeyUp(sender, new KeyEventArgs(Keys.Enter));
                idDoctoEdicion = reim.idDocumentoEdicion;
                lCliente.Text = lCliente.Text + " - Documento: " + idDoctoEdicion + " Folio: " + reim.SerieFolio;
                cbConcepto.Enabled = false;
                serieFolio = reim.SerieFolio;
            }
            
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void cbConcepto_TextChanged(object sender, EventArgs e)
        {
            limpiaProductosARX();
        }

        private void cbPrecio_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (int)Keys.F3)
            {
               // MessageBox.Show("prueba");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmAutorizacionPrecio precio = new frmAutorizacionPrecio();
            precio.ShowDialog();

            if (!String.IsNullOrEmpty(precio.precioNuevo))
            {
                cbPrecio.Items.Add(precio.precioNuevo);
                cbPrecio.SelectedIndex = cbPrecio.Items.Count - 1;
            }

            if (!String.IsNullOrEmpty(precio.codigo))
            {
                foreach (var a in partidas)
                {
                    if (a.codigo ==precio.codigo)
                    {
                        a.porcentajeDescuento = precio.porcentaje;
                        a.descuento = ((Convert.ToDouble(a.precio.Replace("$", "").Replace(",", ""))) * ((Convert.ToDouble(precio.porcentaje) / 100))).ToString("C");
                        a.importe = ((Convert.ToDouble(a.precio.Replace("$", "").Replace(",", "")) - Convert.ToDouble(a.descuento.Replace("$", "").Replace(",", ""))) * Convert.ToDouble(a.cantidad)).ToString("C");

                        actualizaTablaSinCalculo();
                    
                    }
                }
            }
        }


        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tCantidad_Enter(object sender, EventArgs e)
        {
            tCantidad.Select(0, tCantidad.Text.Length);
        }

        private void tCantidad_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return")
            {
                tDescuento.Focus();
                tDescuento.SelectAll();
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pageHeader1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellButtonClick(object sender, AntdUI.TableButtonEventArgs e)
        {
            
        }

        private void dataGridView1_CellDoubleClick(object sender, AntdUI.TableClickEventArgs e)
        {
            if (e.RowIndex > 0) 
            {
                var result = MessageBox.Show("¿Desea editar la cantidad de este producto?", "Editar producto", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    frmModificaCantidad frmModificaCantidad = new frmModificaCantidad();
                    frmModificaCantidad.Cantidad =Convert.ToDouble(((Partida)binding.Current).cantidad);
                    frmModificaCantidad.ShowDialog();

                    ((Partida)binding.Current).cantidad = frmModificaCantidad.Cantidad.ToString();
                    ((Partida)binding.Current).importe = ((Convert.ToDouble(((Partida)binding.Current).precio.Replace("$", "").Replace(",", ""))- Convert.ToDouble(((Partida)binding.Current).descuento.Replace("$", "").Replace(",", ""))) * Convert.ToDouble(((Partida)binding.Current).cantidad)).ToString("C");

                    actualizaTablaSinCalculo();

                    //dataGridView1.DataSource = null;
                    //dataGridView1.DataSource = binding;

                    //actualizaTabla();
                }
                else if (result == DialogResult.No)
                {
                    if (MessageBox.Show("¿Desea eliminar la partida?", "Cancelación de partida", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (dataGridView1.SelectedIndex >= 1)
                        {
                            //Partida partidaSeleccionada = ((List<Partida>)dataGridView1.DataSource)[dataGridView1.SelectedIndex];
                            //partidas.Remove(partidaSeleccionada);
                            binding.RemoveAt(dataGridView1.SelectedIndex - 1);

                            dataGridView1.DataSource = null;
                            dataGridView1.DataSource = binding;
                            System.Threading.Thread.Sleep(500);
                            dataGridView1.Refresh();

                            //dataGridView1.DataSource = null;
                            //dataGridView1.DataSource = partidas;

                            actualizaTabla();
                        }

                    }
                }

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tDescuento_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.ToString() == "Return")
            {
                var descuentos = new Descuentos().obtenerTodos();
                double descuento = Convert.ToDouble(tDescuento.Value);
                bool descuentoAplicado = false;

                foreach (var a in descuentos)
                {
                    if (tCodigo.Text.StartsWith(a.prefijo))
                    {
                        if (descuento <= a.descuento)
                        {
                            tDescuento.Text = descuento.ToString();
                            tDescuento.Value = Convert.ToDecimal(descuento);
                            descuentoAplicado = true;
                            break;
                        }
                    }
                }

                if (!descuentoAplicado)
                {
                    if (tDescuento.Value != 0)
                    {
                        tDescuento.Text = "0";
                        tDescuento.Value = 0;

                        AntdUI.Message.error(this, "El descuento no es válido para este producto.", new Font("Poppins", Globales.tamañoFuenteMensajes));
                    }
                    
                }

                if( Convert.ToDouble(cbPrecio.Text.Replace("$","").Replace(",","")) != 0)
                {
                    agregarPartida();
                }
                else
                {
                    AntdUI.Message.error(this, "El precio no puede ser cero pesos.", new Font("Poppins", Globales.tamañoFuenteMensajes));
                }

                    
                tDescuento.Text = "0";
                tCodigo.Focus();
            }
        }

        private void tcantidad_textchange(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, TableClickEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmObservaciones frmObservaciones = new frmObservaciones(_observaciones); 
            frmObservaciones.ShowDialog();
            _observaciones = frmObservaciones.Observaciones;
        }

        private void cbPrecio_Leave(object sender, EventArgs e)
        {
            var config = Modelos.Negocio.ConfigurationDBContext.obtener();

            if (config.limitePrecio1Precio3 == 1)
            {
                // Limpia y valida el valor ingresado
                string input = cbPrecio.Text.Replace("$", "").Replace(",", "").Trim();

                if (!decimal.TryParse(input, out decimal valorIngresado))
                {
                    AntdUI.Message.error(this, "Por favor, ingresa un valor numérico válido.", new Font("Poppins", Globales.tamañoFuenteMensajes));
                    cbPrecio.Focus();
                    cbPrecio.Text = "0";
                    return;
                }

                // Asegúrate de que haya al menos 3 elementos en el ComboBox
                if (cbPrecio.Items.Count < 3)
                {
                    AntdUI.Message.error(this, "No hay suficientes valores en la lista para validar el rango.", new Font("Poppins", Globales.tamañoFuenteMensajes));
                    cbPrecio.Text = "0";
                    return;
                }

                // Extraer y limpiar primer y tercer elemento
                string primerElementoStr = cbPrecio.Items[2].ToString().Replace("$", "").Replace(",", "").Trim();
                string tercerElementoStr = cbPrecio.Items[0].ToString().Replace("$", "").Replace(",", "").Trim();

                if (!decimal.TryParse(primerElementoStr, out decimal valorMinimo) ||
                    !decimal.TryParse(tercerElementoStr, out decimal valorMaximo))
                {
                    AntdUI.Message.error(this, "Error al interpretar los valores mínimo y máximo del ComboBox.", new Font("Poppins", Globales.tamañoFuenteMensajes));
                    return;
                }

                if (valorIngresado < valorMinimo || valorIngresado > valorMaximo)
                {
                    AntdUI.Message.error(this, $"El precio debe estar entre {valorMinimo:C} y {valorMaximo:C}.", new Font("Poppins", Globales.tamañoFuenteMensajes));
                    cbPrecio.Focus();
                    cbPrecio.SelectedIndex = 0;
                    return;
                }

                // Si pasó todas las validaciones, opcionalmente formatearlo
                cbPrecio.Text = valorIngresado.ToString("C");
            }
           
        }
    }
}
