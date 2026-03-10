using iTextSharp.text;
using iTextSharp.text.pdf;
using Modelos.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TerminalPedidos
{
    public partial class frmEnviosProgramados : AntdUI.Window
    {
        private List<EnviosProgramados> listaEnvios = new List<EnviosProgramados>();
        private List<Admdocumentos> listaDocumentos = new List<Admdocumentos>();
        private EnviosProgramados envioSeleccionado = null;
        private bool modoEdicion = false;
        private string folioActual = "";

        // Controles de la interfaz
        private DataGridView dgvEnvios;
        private AntdUI.Select cbDocumentos;
        private AntdUI.Select cbFolios;
        private AntdUI.Input tFolioEnvio;
        private AntdUI.Select cbDireccionEnvio;
        private AntdUI.Select cbChofer;
        private AntdUI.Select cbVehiculo;
        private AntdUI.DatePicker dpFechaProgramada;
        private AntdUI.Input tBuscador;
        private AntdUI.Button btnGenerar;
        private AntdUI.Button btnGuardar;
        private AntdUI.Button btnEliminar;
        private AntdUI.Button btnLimpiar;
        private AntdUI.Button btnCancelar;
        private AntdUI.Button btnReporte;
        private AntdUI.Button btnAbrirDirecciones;
        private AntdUI.Button btnAbrirChoferes;
        private AntdUI.Button btnAbrirVehiculos;
        private AntdUI.Label lblEstado;
        private AntdUI.Label lblTotalKilos;

        // Listas para los combos
        private List<DireccionEnvios> listaDirecciones = new List<DireccionEnvios>();
        private List<Choferes> listaChoferes = new List<Choferes>();
        private List<Vehiculos> listaVehiculos = new List<Vehiculos>();
        private List<string> listaFolios = new List<string>();

        // Agregar esta variable privada al inicio de la clase
        private int documentoSeleccionadoId = 0;

        public frmEnviosProgramados()
        {
            InitializeComponents();
            CargarComboBoxes();
            CargarDatos();
        }

        #region Inicialización de Componentes

        private void InitializeComponents()
        {
            // Configuración de la ventana
            this.ClientSize = new System.Drawing.Size(1100, 850);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Envíos Programados";
            this.Font = new System.Drawing.Font("Poppins", 9.75f);

            // Panel superior para formulario
            var panelFormulario = new AntdUI.Panel()
            {
                Location = new Point(10, 10),
                Size = new Size(1080, 390),  // Aumentado de 330 a 390
                BackColor = Color.White,
                Radius = 8
            };

            // Título
            var lblTitulo = new AntdUI.Label()
            {
                Text = "Formulario de Envíos Programados",
                Font = new System.Drawing.Font("Poppins", 14, FontStyle.Bold),
                Location = new Point(15, 15),
                AutoSize = true
            };
            panelFormulario.Controls.Add(lblTitulo);

            // ==================== SECCIÓN FOLIO EXISTENTE ====================
            var lblSeleccionarFolio = new AntdUI.Label()
            {
                Text = "Seleccionar Folio Existente:",
                Location = new Point(15, 50),
                AutoSize = true
            };
            panelFormulario.Controls.Add(lblSeleccionarFolio);

            cbFolios = new AntdUI.Select()
            {
                Location = new Point(180, 45),
                Size = new Size(250, 33),
                //Placeholder = "Elige un folio existente..."
            };
            cbFolios.SelectedValueChanged += CbFolios_SelectedValueChanged;
            panelFormulario.Controls.Add(cbFolios);

            // Separador visual
            var lblOSeparador1 = new AntdUI.Label()
            {
                Text = "O",
                Location = new Point(455, 52),
                AutoSize = true,
                Font = new System.Drawing.Font("Poppins", 10, FontStyle.Bold)
            };
            panelFormulario.Controls.Add(lblOSeparador1);

            // ==================== GENERAR NUEVO FOLIO ====================
            var lblFolioEnvio = new AntdUI.Label()
            {
                Text = "Generar Nuevo Folio:",
                Location = new Point(500, 50),
                AutoSize = true
            };
            panelFormulario.Controls.Add(lblFolioEnvio);

            tFolioEnvio = new AntdUI.Input()
            {
                Location = new Point(650, 45),
                Size = new Size(150, 33),
                Enabled = false
            };
            panelFormulario.Controls.Add(tFolioEnvio);

            btnGenerar = new AntdUI.Button()
            {
                Text = "Generar",
                Location = new Point(810, 45),
                Size = new Size(100, 33),
                Radius = 8,
                BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69))))),
                BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69))))),
                DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69))))),
                Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))))
            };
            btnGenerar.Click += BtnGenerar_Click;
            panelFormulario.Controls.Add(btnGenerar);

            // Estado
            lblEstado = new AntdUI.Label()
            {
                Text = "Estado: Sin folio",
                Location = new Point(15, 90),
                AutoSize = true,
                Font = new System.Drawing.Font("Poppins", 10, FontStyle.Regular)
            };
            panelFormulario.Controls.Add(lblEstado);

            // ==================== DOCUMENTO ====================
            var lblDocumento = new AntdUI.Label()
            {
                Text = "Documento:",
                Location = new Point(15, 135),
                AutoSize = true
            };
            panelFormulario.Controls.Add(lblDocumento);

            cbDocumentos = new AntdUI.Select()
            {
                Location = new Point(120, 130),
                Size = new Size(350, 33),
                //Placeholder = "Selecciona un documento..."
            };
            cbDocumentos.SelectedValueChanged += CbDocumentos_SelectedValueChanged; // AGREGAR ESTE EVENTO
            panelFormulario.Controls.Add(cbDocumentos);

            // ==================== TOTAL KILOS ====================
            lblTotalKilos = new AntdUI.Label()
            {
                Text = "Total Kilos:",
                Location = new Point(490, 135),
                AutoSize = true
            };
            panelFormulario.Controls.Add(lblTotalKilos);

            var lblValorKilos = new AntdUI.Label()
            {
                Text = "0.00 kg",
                Location = new Point(595, 135),
                AutoSize = true,
                Font = new System.Drawing.Font("Poppins", 10, FontStyle.Bold)
            };
            panelFormulario.Controls.Add(lblValorKilos);

            // ==================== Dirección de Envío ====================
            var lblDireccion = new AntdUI.Label()
            {
                Text = "Dirección:",
                Location = new Point(15, 180),
                AutoSize = true
            };
            panelFormulario.Controls.Add(lblDireccion);

            cbDireccionEnvio = new AntdUI.Select()
            {
                Location = new Point(120, 175),
                Size = new Size(350, 33)
            };
            panelFormulario.Controls.Add(cbDireccionEnvio);

            btnAbrirDirecciones = new AntdUI.Button()
            {
                Text = "+",
                Location = new Point(480, 175),
                Size = new Size(40, 33),
                Radius = 8,
                BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93))))),
                BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93))))),
                DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93))))),
                Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))))
            };
            btnAbrirDirecciones.Click += BtnAbrirDirecciones_Click;
            panelFormulario.Controls.Add(btnAbrirDirecciones);

            // ==================== Chofer (Bloqueado hasta generar/seleccionar folio) ====================
            var lblChofer = new AntdUI.Label()
            {
                Text = "Chofer:",
                Location = new Point(15, 225),
                AutoSize = true
            };
            panelFormulario.Controls.Add(lblChofer);

            cbChofer = new AntdUI.Select()
            {
                Location = new Point(120, 220),
                Size = new Size(200, 33),
                Enabled = false
            };
            panelFormulario.Controls.Add(cbChofer);

            btnAbrirChoferes = new AntdUI.Button()
            {
                Text = "+",
                Location = new Point(330, 220),
                Size = new Size(40, 33),
                Radius = 8,
                BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93))))),
                BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93))))),
                DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93))))),
                Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))))
            };
            btnAbrirChoferes.Click += BtnAbrirChoferes_Click;
            panelFormulario.Controls.Add(btnAbrirChoferes);

            // ==================== Vehículo (Bloqueado hasta generar/seleccionar folio) ====================
            var lblVehiculo = new AntdUI.Label()
            {
                Text = "Vehículo:",
                Location = new Point(390, 225),
                AutoSize = true
            };
            panelFormulario.Controls.Add(lblVehiculo);

            cbVehiculo = new AntdUI.Select()
            {
                Location = new Point(495, 220),
                Size = new Size(300, 33),
                Enabled = false
            };
            panelFormulario.Controls.Add(cbVehiculo);

            btnAbrirVehiculos = new AntdUI.Button()
            {
                Text = "+",
                Location = new Point(805, 220),
                Size = new Size(40, 33),
                Radius = 8,
                BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93))))),
                BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93))))),
                DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93))))),
                Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))))
            };
            btnAbrirVehiculos.Click += BtnAbrirVehiculos_Click;
            panelFormulario.Controls.Add(btnAbrirVehiculos);

            // ==================== Fecha Programada ====================
            var lblFecha = new AntdUI.Label()
            {
                Text = "Fecha:",
                Location = new Point(15, 275),
                AutoSize = true
            };
            panelFormulario.Controls.Add(lblFecha);

            dpFechaProgramada = new AntdUI.DatePicker()
            {
                Location = new Point(120, 270),
                Size = new Size(250, 30),
                Format = "yyyy - MM - dd HH:mm:ss"

            };
            panelFormulario.Controls.Add(dpFechaProgramada);

            // ==================== Botones principales ====================
            btnGuardar = new AntdUI.Button()
            {
                Text = "Guardar",
                Location = new Point(15, 330),
                Size = new Size(100, 40),
                Radius = 8,
                BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93))))),
                BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93))))),
                DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93))))),
                Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))))
            };
            btnGuardar.Click += BtnGuardar_Click;
            panelFormulario.Controls.Add(btnGuardar);

            btnEliminar = new AntdUI.Button()
            {
                Text = "Eliminar",
                Location = new Point(125, 330),
                Size = new Size(100, 40),
                Radius = 8,
                Enabled = false,
                BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93))))),
                BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93))))),
                DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93))))),
                Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))))
            };
            btnEliminar.Click += BtnEliminar_Click;
            panelFormulario.Controls.Add(btnEliminar);

            btnLimpiar = new AntdUI.Button()
            {
                Text = "Limpiar",
                Location = new Point(235, 330),
                Size = new Size(100, 40),
                Radius = 8,
                BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93))))),
                BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93))))),
                DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93))))),
                Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(93)))), ((int)(((byte)(93)))))
            };
            btnLimpiar.Click += BtnLimpiar_Click;
            panelFormulario.Controls.Add(btnLimpiar);

            btnReporte = new AntdUI.Button()
            {
                Text = "Reporte PDF",
                Location = new Point(345, 330),
                Size = new Size(120, 40),
                Radius = 8,
                BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69))))),
                BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69))))),
                DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69))))),
                Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))))
            };
            btnReporte.Click += BtnReporte_Click;
            panelFormulario.Controls.Add(btnReporte);

            btnCancelar = new AntdUI.Button()
            {
                Text = "Cancelar",
                Location = new Point(475, 330),
                Size = new Size(100, 40),
                Radius = 8,
                BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93))))),
                BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93))))),
                DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93))))),
                Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))))
            };
            btnCancelar.Click += BtnCancelar_Click;
            panelFormulario.Controls.Add(btnCancelar);

            this.Controls.Add(panelFormulario);

            // Panel Buscador
            var panelBuscador = new AntdUI.Panel()
            {
                Location = new Point(10, 410),  // Cambió de 350 a 410
                Size = new Size(1080, 50),
                BackColor = Color.White,
                Radius = 8
            };

            var lblBuscador = new AntdUI.Label()
            {
                Text = "Buscar por Folio:",
                Location = new Point(15, 13),
                AutoSize = true,
                Font = new System.Drawing.Font("Poppins", 10, FontStyle.Regular)
            };
            panelBuscador.Controls.Add(lblBuscador);

            tBuscador = new AntdUI.Input()
            {
                Location = new Point(140, 10),
                Size = new Size(300, 33)
            };
            tBuscador.TextChanged += TBuscador_TextChanged;
            panelBuscador.Controls.Add(tBuscador);

            this.Controls.Add(panelBuscador);

            // DataGridView
            dgvEnvios = new DataGridView()
            {
                Location = new Point(10, 470),  // Cambió de 410 a 470
                Size = new Size(1080, 350),     // Ajustado a 350 en altura
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                BackgroundColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            // Columnas del grid
            dgvEnvios.Columns.Add("Id", "ID");
            dgvEnvios.Columns.Add("FolioEnvio", "Folio Envío");
            dgvEnvios.Columns.Add("Documento", "Documento");
            dgvEnvios.Columns.Add("Direccion", "Dirección");
            dgvEnvios.Columns.Add("Chofer", "Chofer");
            dgvEnvios.Columns.Add("Vehiculo", "Vehículo");
            dgvEnvios.Columns.Add("FechaProgramada", "Fecha Programada");
            dgvEnvios.Columns.Add("Estado", "Estado");

            // Ajustar ancho de columnas
            dgvEnvios.Columns["Id"].Width = 40;
            dgvEnvios.Columns["FolioEnvio"].Width = 80;
            dgvEnvios.Columns["Documento"].Width = 80;
            dgvEnvios.Columns["Direccion"].Width = 200;
            dgvEnvios.Columns["Chofer"].Width = 150;
            dgvEnvios.Columns["Vehiculo"].Width = 200;
            dgvEnvios.Columns["FechaProgramada"].Width = 120;
            dgvEnvios.Columns["Estado"].Width = 100;

            dgvEnvios.CellClick += DgvEnvios_CellClick;

            this.Controls.Add(dgvEnvios);
        }

        #endregion

        #region Carga de Datos

        private void CargarComboBoxes()
        {
            try
            {
                var configuracion = Modelos.Negocio.ConfigurationDBContext.obtener();
                string cadena = ConfigurationManager.ConnectionStrings["bd"].ConnectionString.Replace("PuntoVentaComercial", configuracion.empresa.Split('\\').Last());

                // Cargar documentos
                var doc = new Admdocumentos();
                listaDocumentos = doc.obtenerSQL("select * from admDocumentos where CIDDOCUMENTODE = 3", cadena);
                foreach (var d in listaDocumentos)
                {
                    string display = $"{d.CSERIEDOCUMENTO}-{d.CFOLIO} | {d.CRAZONSOCIAL}";
                    cbDocumentos.Items.Add(new AntdUI.SelectItem(display, d.CIDDOCUMENTO));
                }

                // Cargar direcciones
                var direccion = new DireccionEnvios();
                listaDirecciones = direccion.obtenerTodos();
                foreach (var dir in listaDirecciones)
                {
                    cbDireccionEnvio.Items.Add(new AntdUI.SelectItem(dir.Nombre, dir.Id));
                }

                // Cargar choferes
                var chofer = new Choferes();
                listaChoferes = chofer.obtenerTodos();
                foreach (var ch in listaChoferes)
                {
                    cbChofer.Items.Add(new AntdUI.SelectItem(ch.Nombre, ch.Id));
                }

                // Cargar vehículos
                var vehiculo = new Vehiculos();
                listaVehiculos = vehiculo.obtenerTodos();
                foreach (var veh in listaVehiculos)
                {
                    cbVehiculo.Items.Add(new AntdUI.SelectItem($"{veh.Nombre} - {veh.Placa}", veh.Id));
                }
            }
            catch (Exception ex)
            {
                AntdUI.Notification.error(this, "Error", $"Error al cargar combos: {ex.Message}");
            }
        }

        private void CargarFoliosExistentes()
        {
            try
            {
                cbFolios.Items.Clear();
                listaFolios = listaEnvios.Select(e => e.FolioEnvio).Distinct().OrderByDescending(f => f).ToList();

                foreach (var folio in listaFolios
                )
                {
                    cbFolios.Items.Add(new AntdUI.SelectItem(folio, folio));
                }
            }
            catch (Exception ex)
            {
                AntdUI.Notification.error(this, "Error", $"Error al cargar folios: {ex.Message}");
            }
        }

        private void CargarDatos()
        {
            try
            {
                var envio = new EnviosProgramados();
                listaEnvios = envio.obtenerTodos();
                CargarFoliosExistentes();
                MostrarDatos();
            }
            catch (Exception ex)
            {
                AntdUI.Notification.error(this, "Error", $"Error al cargar datos: {ex.Message}");
            }
        }

        private void MostrarDatos()
        {
            dgvEnvios.Rows.Clear();
            foreach (var envio in listaEnvios)
            {
                var direccion = listaDirecciones.FirstOrDefault(d => d.Id == envio.DirreccionEnvio);
                var chofer = listaChoferes.FirstOrDefault(c => c.Id == envio.Chofer);
                var vehiculo = listaVehiculos.FirstOrDefault(v => v.Id == envio.Vehiculo);

                string estado = envio.Estado == 0 ? "Pendiente" : "Entregado";

                dgvEnvios.Rows.Add(
                    envio.Id,
                    envio.FolioEnvio,
                    envio.Documento,
                    direccion?.Nombre ?? "N/A",
                    chofer?.Nombre ?? "N/A",
                    $"{vehiculo?.Nombre ?? "N/A"} - {vehiculo?.Placa ?? "N/A"}",
                    envio.FechaProgramada.ToString("dd/MM/yyyy"),
                    estado
                );
            }
        }

        private void FiltrarDatos(string filtro)
        {
            dgvEnvios.Rows.Clear();

            if (string.IsNullOrWhiteSpace(filtro))
            {
                MostrarDatos();
                return;
            }

            var enviosFiltrados = listaEnvios.Where(e =>
                e.FolioEnvio.Contains(filtro)
            ).ToList();

            foreach (var envio in enviosFiltrados)
            {
                var direccion = listaDirecciones.FirstOrDefault(d => d.Id == envio.DirreccionEnvio);
                var chofer = listaChoferes.FirstOrDefault(c => c.Id == envio.Chofer);
                var vehiculo = listaVehiculos.FirstOrDefault(v => v.Id == envio.Vehiculo);

                string estado = envio.Estado == 0 ? "Pendiente" : "Entregado";

                dgvEnvios.Rows.Add(
                    envio.Id,
                    envio.FolioEnvio,
                    envio.Documento,
                    direccion?.Nombre ?? "N/A",
                    chofer?.Nombre ?? "N/A",
                    $"{vehiculo?.Nombre ?? "N/A"} - {vehiculo?.Placa ?? "N/A"}",
                    envio.FechaProgramada.ToString("dd/MM/yyyy"),
                    estado
                );
            }
        }

        #endregion

        #region Eventos de Combos

        private void CbDocumentos_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbDocumentos.SelectedValue != null)
            {
                documentoSeleccionadoId = (int)cbDocumentos.SelectedValue;

                // AQUÍ PUEDES AGREGAR TU PROCESO CON EL ID DEL DOCUMENTO
                // Ejemplo: Cargar datos adicionales, validar, etc.

                //AntdUI.Notification.info(this, "Documento", $"ID Documento seleccionado: {documentoSeleccionadoId}");
                var configuracion = Modelos.Negocio.ConfigurationDBContext.obtener();
                string cadena = ConfigurationManager.ConnectionStrings["bd"].ConnectionString.Replace("PuntoVentaComercial", configuracion.empresa.Split('\\').Last());

                var movimientos = new Admmovimientos().obtenerSQL("select * from admMovimientos where CIDDOCUMENTO = " + documentoSeleccionadoId,cadena);

                double totalKilos = movimientos.Sum(m =>
                {
                    if (m.CUNIDADES <= 0 || string.IsNullOrWhiteSpace(m.CTEXTOEXTRA1))
                        return 0;

                    return double.TryParse(m.CTEXTOEXTRA1, out double peso) && peso > 0
                        ? m.CUNIDADES * peso
                        : 0;
                });

                lblTotalKilos.Text = $"Total Kilos: {totalKilos:N2} kg";
            }
            else
            {
                documentoSeleccionadoId = 0;
            }
        }

        private void CbFolios_SelectedValueChanged(object sender, EventArgs evt)
        {
            if (cbFolios.SelectedValue != null)
            {
                string folioSeleccionado = cbFolios.SelectedValue.ToString();

                // Obtener el primer registro del folio para cargar chofer, vehículo y fecha
                var primerRegistro = listaEnvios.FirstOrDefault(en => en.FolioEnvio == folioSeleccionado);

                if (primerRegistro != null)
                {
                    tFolioEnvio.Text = folioSeleccionado;
                    folioActual = folioSeleccionado;

                    // Cargar los datos fijos del folio (chofer, vehículo, fecha)
                    cbChofer.SelectedValue = primerRegistro.Chofer;
                    cbVehiculo.SelectedValue = primerRegistro.Vehiculo;
                    dpFechaProgramada.Value = primerRegistro.FechaProgramada;

                    // Chofer y vehículo quedan bloqueados (son iguales para todos los registros del folio)
                    cbChofer.Enabled = false;
                    cbVehiculo.Enabled = false;
                    dpFechaProgramada.Enabled = false;

                    // Limpiar documento y dirección (varían por registro)
                    cbDocumentos.SelectedValue = null;
                    cbDireccionEnvio.SelectedValue = null;

                    lblEstado.Text = $"Estado: Folio seleccionado - {listaEnvios.Count(e => e.FolioEnvio == folioSeleccionado)} registros";
                    AntdUI.Notification.success(this, "Éxito", $"Folio {folioSeleccionado} seleccionado");
                }
            }
        }

        #endregion

        #region Eventos de Botones CRUD

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                string nuevoFolio = "ENV-" + DateTime.Now.ToString("yyyyMMdd") + "-" + GenerarSecuencia();
                tFolioEnvio.Text = nuevoFolio;
                folioActual = nuevoFolio;

                // Habilitar chofer, vehículo y fecha para nuevo folio
                cbChofer.Enabled = true;
                cbVehiculo.Enabled = true;
                dpFechaProgramada.Enabled = true;

                // Limpiar selección de folios previos
                cbFolios.SelectedValue = null;
                cbDocumentos.SelectedValue = null;
                cbDireccionEnvio.SelectedValue = null;

                lblEstado.Text = "Estado: Nuevo folio creado - Chofer, Vehículo y Fecha editables";
                AntdUI.Notification.success(this, "Éxito", $"Folio generado: {nuevoFolio}");
            }
            catch (Exception ex)
            {
                AntdUI.Notification.error(this, "Error", $"Error al generar folio: {ex.Message}");
            }
        }

        private string GenerarSecuencia()
        {
            var db = new PetaPoco.Database("bd");
            var ultimoFolio = db.Query<dynamic>("SELECT TOP 1 FolioEnvio FROM EnviosProgramados ORDER BY Id DESC").FirstOrDefault();

            if (ultimoFolio == null)
                return "0001";

            string folio = ultimoFolio.FolioEnvio;
            int numero = int.Parse(folio.Split('-').Last());
            return (numero + 1).ToString().PadLeft(4, '0');
        }

        private void BtnAbrirDirecciones_Click(object sender, EventArgs e)
        {
            var frmDirecciones = new frmDireccionEnvios();
            frmDirecciones.ShowDialog();
            CargarComboBoxes();
        }

        private void BtnAbrirChoferes_Click(object sender, EventArgs e)
        {
            var frmChoferes = new frmChoferes();
            frmChoferes.ShowDialog();
            CargarComboBoxes();
        }

        private void BtnAbrirVehiculos_Click(object sender, EventArgs e)
        {
            var frmVehiculos = new frmVehiculos();
            frmVehiculos.ShowDialog();
            CargarComboBoxes();
        }

        #endregion

        #region Eventos de Botones Principales

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(tFolioEnvio.Text))
            {
                AntdUI.Notification.error(this, "Validación", "Debe seleccionar o generar un folio.");
                return;
            }

            if (cbDocumentos.SelectedValue == null)
            {
                AntdUI.Notification.error(this, "Validación", "Debe seleccionar un documento.");
                cbDocumentos.Focus();
                return;
            }

            if (cbDireccionEnvio.SelectedValue == null)
            {
                AntdUI.Notification.error(this, "Validación", "Debe seleccionar una dirección.");
                cbDireccionEnvio.Focus();
                return;
            }

            if (cbChofer.SelectedValue == null)
            {
                AntdUI.Notification.error(this, "Validación", "Debe seleccionar un chofer.");
                cbChofer.Focus();
                return;
            }

            if (cbVehiculo.SelectedValue == null)
            {
                AntdUI.Notification.error(this, "Validación", "Debe seleccionar un vehículo.");
                cbVehiculo.Focus();
                return;
            }

            try
            {
                // Obtener datos completos de la dirección seleccionada
                int dirId = (int)cbDireccionEnvio.SelectedValue;
                var direccionCompleta = listaDirecciones.FirstOrDefault(d => d.Id == dirId);

                // Guardar/Actualizar dirección en la tabla
                if (direccionCompleta != null)
                {
                    direccionCompleta.guardar();
                }

                var envio = new EnviosProgramados
                {
                    FolioEnvio = tFolioEnvio.Text,
                    Documento = (int)cbDocumentos.SelectedValue,
                    DirreccionEnvio = dirId,
                    Chofer = (int)cbChofer.SelectedValue,
                    Vehiculo = (int)cbVehiculo.SelectedValue,
                    FechaProgramada = (DateTime)dpFechaProgramada.Value,
                    Estado = 0
                };

                if (modoEdicion)
                {
                    envio.Id = envioSeleccionado.Id;
                    envio.actualizar();
                    AntdUI.Notification.success(this, "Éxito", "Envío actualizado correctamente.");
                }
                else
                {
                    envio.guardar();
                    AntdUI.Notification.success(this, "Éxito", "Envío guardado correctamente.");
                }

                CargarDatos();
                LimpiarFormulario();
                tBuscador.Text = "";
            }
            catch (Exception ex)
            {
                AntdUI.Notification.error(this, "Error", $"Error al guardar: {ex.Message}");
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (envioSeleccionado == null)
            {
                AntdUI.Notification.warn(this, "Advertencia", "Selecciona un envío para eliminar.");
                return;
            }

            var result = MessageBox.Show("¿Estás seguro de que deseas eliminar este envío?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var envio = new EnviosProgramados { Id = envioSeleccionado.Id };
                    envio.elimina();
                    AntdUI.Notification.success(this, "Éxito", "Envío eliminado correctamente.");
                    CargarDatos();
                    LimpiarFormulario();
                    tBuscador.Text = "";
                }
                catch (Exception ex)
                {
                    AntdUI.Notification.error(this, "Error", $"Error al eliminar: {ex.Message}");
                }
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnReporte_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tFolioEnvio.Text))
            {
                AntdUI.Notification.warn(this, "Advertencia", "Selecciona un folio para generar el reporte.");
                return;
            }

            try
            {
                var enviosFolio = listaEnvios.Where(en => en.FolioEnvio == tFolioEnvio.Text).ToList();

                if (enviosFolio.Count == 0)
                {
                    AntdUI.Notification.warn(this, "Advertencia", "No hay envíos para este folio.");
                    return;
                }

                SaveFileDialog saveDialog = new SaveFileDialog()
                {
                    Filter = "Archivos PDF (*.pdf)|*.pdf",
                    FileName = $"Reporte_Envios_{tFolioEnvio.Text}.pdf"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    GenerarReportePDF(saveDialog.FileName, enviosFolio);
                    AntdUI.Notification.success(this, "Éxito", $"Reporte PDF generado: {saveDialog.FileName}");

                    // Abrir el PDF automáticamente
                    System.Diagnostics.Process.Start(saveDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                AntdUI.Notification.error(this, "Error", $"Error al generar reporte: {ex.Message}");
            }
        }

        private void GenerarReportePDF(string ruta, List<EnviosProgramados> envios)
        {
            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(ruta, FileMode.Create));
            doc.Open();

            var titulo = new Paragraph($"Reporte de Envíos - Folio: {tFolioEnvio.Text}");
            titulo.Alignment = Element.ALIGN_CENTER;
            doc.Add(titulo);

            doc.Add(new Paragraph(" "));

            var chofer = listaChoferes.FirstOrDefault(c => c.Id == envios[0].Chofer);
            var vehiculo = listaVehiculos.FirstOrDefault(v => v.Id == envios[0].Vehiculo);

            doc.Add(new Paragraph($"Chofer: {chofer?.Nombre ?? "N/A"}"));
            doc.Add(new Paragraph($"Vehículo: {vehiculo?.Nombre ?? "N/A"} - Placa: {vehiculo?.Placa ?? "N/A"}"));
            doc.Add(new Paragraph($"Fecha: {envios[0].FechaProgramada:yyyy-MM-dd HH:mm:ss}"));

            doc.Add(new Paragraph(" "));

            PdfPTable tabla = new PdfPTable(6);
            tabla.AddCell(new PdfPCell(new Phrase("Documento")));
            tabla.AddCell(new PdfPCell(new Phrase("Dirección")));
            tabla.AddCell(new PdfPCell(new Phrase("Localidad")));
            tabla.AddCell(new PdfPCell(new Phrase("Teléfono")));
            tabla.AddCell(new PdfPCell(new Phrase("Dirección Completa")));
            tabla.AddCell(new PdfPCell(new Phrase("Importe")));

            var configuracion = Modelos.Negocio.ConfigurationDBContext.obtener();
            string cadena = ConfigurationManager.ConnectionStrings["bd"].ConnectionString.Replace("PuntoVentaComercial", configuracion.empresa.Split('\\').Last());

            foreach (var envio in envios)
            {
                var documento = new Admdocumentos().obtenerId(envio.Documento, cadena);

                var direccion = listaDirecciones.FirstOrDefault(d => d.Id == envio.DirreccionEnvio);
                string estado = envio.Estado == 0 ? "Pendiente" : "Entregado";

                tabla.AddCell(envio.Documento.ToString());
                tabla.AddCell(direccion?.Nombre ?? "N/A");
                tabla.AddCell(direccion?.Localidad ?? "N/A");
                tabla.AddCell(direccion?.Telefono ?? "N/A");
                tabla.AddCell(direccion?.Direccion ?? "N/A");
                tabla.AddCell(documento != null ? documento.CTOTAL.ToString("C") : "0.00");
            }

            doc.Add(tabla);

            // Agregar espacios para firmas
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(" "));

            PdfPTable tableFirmas = new PdfPTable(2);
            tableFirmas.WidthPercentage = 100;

            PdfPCell cellElabora = new PdfPCell(new Phrase("____________________________________\nElabora\n"));
            cellElabora.Border = iTextSharp.text.Rectangle.NO_BORDER;
            cellElabora.HorizontalAlignment = Element.ALIGN_CENTER;

            PdfPCell cellChofer = new PdfPCell(new Phrase($"____________________________________\nRecibe\n{chofer?.Nombre ?? "Chofer"}"));
            cellChofer.Border = iTextSharp.text.Rectangle.NO_BORDER;
            cellChofer.HorizontalAlignment = Element.ALIGN_CENTER;

            tableFirmas.AddCell(cellElabora);
            tableFirmas.AddCell(cellChofer);

            doc.Add(tableFirmas);

            doc.Close();
        }

        private void DgvEnvios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvEnvios.Rows.Count)
            {
                int id = Convert.ToInt32(dgvEnvios.Rows[e.RowIndex].Cells["Id"].Value);
                envioSeleccionado = listaEnvios.FirstOrDefault(en => en.Id == id);

                if (envioSeleccionado != null)
                {
                    modoEdicion = true;

                    tFolioEnvio.Text = envioSeleccionado.FolioEnvio;
                    folioActual = envioSeleccionado.FolioEnvio;

                    // Cargar datos del registro seleccionado
                    cbDocumentos.SelectedValue = envioSeleccionado.Documento;
                    cbDireccionEnvio.SelectedValue = envioSeleccionado.DirreccionEnvio;
                    cbChofer.SelectedValue = envioSeleccionado.Chofer;
                    cbVehiculo.SelectedValue = envioSeleccionado.Vehiculo;
                    dpFechaProgramada.Value = envioSeleccionado.FechaProgramada;

                    // Bloquear campos del folio (chofer, vehículo y fecha no se pueden cambiar en edición)
                    cbChofer.Enabled = false;
                    cbVehiculo.Enabled = false;
                    dpFechaProgramada.Enabled = false;

                    btnEliminar.Enabled = true;
                    btnGuardar.Text = "Actualizar";

                    lblEstado.Text = "Estado: Modo edición - Solo puede cambiar Documento y Dirección";
                }
            }
        }

        private void TBuscador_TextChanged(object sender, EventArgs e)
        {
            FiltrarDatos(tBuscador.Text);
        }

        #endregion

        #region Métodos Auxiliares

        private void LimpiarFormulario()
        {
            tFolioEnvio.Text = "";
            cbDocumentos.SelectedValue = null;
            cbDireccionEnvio.SelectedValue = null;
            cbChofer.SelectedValue = null;
            cbVehiculo.SelectedValue = null;
            cbFolios.SelectedValue = null;
            dpFechaProgramada.Value = DateTime.Now;

            // Habilitar todos los campos en modo nuevo registro
            cbChofer.Enabled = false; // Bloqueado hasta generar/seleccionar folio
            cbVehiculo.Enabled = false;
            dpFechaProgramada.Enabled = true;

            envioSeleccionado = null;
            modoEdicion = false;
            btnEliminar.Enabled = false;
            btnGuardar.Text = "Guardar";
            folioActual = "";

            lblEstado.Text = "Estado: Formulario limpio";
        }

        #endregion
    }
}