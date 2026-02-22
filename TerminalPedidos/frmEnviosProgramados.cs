using Modelos.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private EnviosProgramados envioSeleccionado = null;
        private bool modoEdicion = false;

        // Controles de la interfaz
        private DataGridView dgvEnvios;
        private AntdUI.Input tDocumento;
        private AntdUI.Select cbDireccionEnvio;
        private AntdUI.Select cbChofer;
        private AntdUI.Select cbVehiculo;
        private AntdUI.DatePicker dpFechaProgramada;
        private AntdUI.Input tBuscador;
        private AntdUI.Button btnGuardar;
        private AntdUI.Button btnEliminar;
        private AntdUI.Button btnLimpiar;
        private AntdUI.Button btnCancelar;
        private AntdUI.Button btnReporte;
        private AntdUI.Button btnAbrirDirecciones;
        private AntdUI.Button btnAbrirChoferes;
        private AntdUI.Button btnAbrirVehiculos;

        // Listas para los combos
        private List<DireccionEnvios> listaDirecciones = new List<DireccionEnvios>();
        private List<Choferes> listaChoferes = new List<Choferes>();
        private List<Vehiculos> listaVehiculos = new List<Vehiculos>();

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
            this.ClientSize = new System.Drawing.Size(1100, 800);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Envíos Programados";
            this.Font = new Font("Poppins", 9.75f);

            // Panel superior para formulario
            var panelFormulario = new AntdUI.Panel()
            {
                Location = new Point(10, 10),
                Size = new Size(1080, 270),
                BackColor = Color.White,
                Radius = 8
            };

            // Título
            var lblTitulo = new AntdUI.Label()
            {
                Text = "Formulario de Envíos Programados",
                Font = new Font("Poppins", 14, FontStyle.Bold),
                Location = new Point(15, 15),
                AutoSize = true
            };
            panelFormulario.Controls.Add(lblTitulo);

            // Documento
            var lblDocumento = new AntdUI.Label()
            {
                Text = "Documento:",
                Location = new Point(15, 50),
                AutoSize = true
            };
            panelFormulario.Controls.Add(lblDocumento);

            tDocumento = new AntdUI.Input()
            {
                Location = new Point(120, 45),
                Size = new Size(150, 33)
            };
            panelFormulario.Controls.Add(tDocumento);

            // Fecha Programada
            var lblFecha = new AntdUI.Label()
            {
                Text = "Fecha:",
                Location = new Point(290, 50),
                AutoSize = true
            };
            panelFormulario.Controls.Add(lblFecha);

            dpFechaProgramada = new AntdUI.DatePicker()
            {
                Location = new Point(370, 45),
                Size = new Size(150, 33)
            };
            panelFormulario.Controls.Add(dpFechaProgramada);

            // Dirección de Envío
            var lblDireccion = new AntdUI.Label()
            {
                Text = "Dirección:",
                Location = new Point(15, 100),
                AutoSize = true
            };
            panelFormulario.Controls.Add(lblDireccion);

            cbDireccionEnvio = new AntdUI.Select()
            {
                Location = new Point(120, 95),
                Size = new Size(200, 33)
            };
            panelFormulario.Controls.Add(cbDireccionEnvio);

            btnAbrirDirecciones = new AntdUI.Button()
            {
                Text = "+",
                Location = new Point(330, 95),
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

            // Chofer
            var lblChofer = new AntdUI.Label()
            {
                Text = "Chofer:",
                Location = new Point(390, 100),
                AutoSize = true
            };
            panelFormulario.Controls.Add(lblChofer);

            cbChofer = new AntdUI.Select()
            {
                Location = new Point(450, 95),
                Size = new Size(150, 33)
            };
            panelFormulario.Controls.Add(cbChofer);

            btnAbrirChoferes = new AntdUI.Button()
            {
                Text = "+",
                Location = new Point(610, 95),
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

            // Vehículo
            var lblVehiculo = new AntdUI.Label()
            {
                Text = "Vehículo:",
                Location = new Point(670, 100),
                AutoSize = true
            };
            panelFormulario.Controls.Add(lblVehiculo);

            cbVehiculo = new AntdUI.Select()
            {
                Location = new Point(750, 95),
                Size = new Size(250, 33)
            };
            panelFormulario.Controls.Add(cbVehiculo);

            btnAbrirVehiculos = new AntdUI.Button()
            {
                Text = "+",
                Location = new Point(1010, 95),
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

            // Botones principales
            btnGuardar = new AntdUI.Button()
            {
                Text = "Guardar",
                Location = new Point(15, 215),
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
                Location = new Point(125, 215),
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
                Location = new Point(235, 215),
                Size = new Size(100, 40),
                Radius = 8,
                BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93))))),
                BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93))))),
                DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93))))),
                Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))))
            };
            btnLimpiar.Click += BtnLimpiar_Click;
            panelFormulario.Controls.Add(btnLimpiar);

            btnReporte = new AntdUI.Button()
            {
                Text = "Reporte CSV",
                Location = new Point(345, 215),
                Size = new Size(120, 40),
                Radius = 8,
                BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69))))),
                BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69))))),
                DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69))))),
                Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))))
            };
            btnReporte.Click += BtnReporte_Click;
            panelFormulario.Controls.Add(btnReporte);

            btnCancelar = new AntdUI.Button()
            {
                Text = "Cancelar",
                Location = new Point(475, 215),
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
                Location = new Point(10, 290),
                Size = new Size(1080, 50),
                BackColor = Color.White,
                Radius = 8
            };

            var lblBuscador = new AntdUI.Label()
            {
                Text = "Buscar por Documento:",
                Location = new Point(15, 13),
                AutoSize = true,
                Font = new Font("Poppins", 10, FontStyle.Regular)
            };
            panelBuscador.Controls.Add(lblBuscador);

            tBuscador = new AntdUI.Input()
            {
                Location = new Point(180, 10),
                Size = new Size(300, 33)
            };
            tBuscador.TextChanged += TBuscador_TextChanged;
            panelBuscador.Controls.Add(tBuscador);

            this.Controls.Add(panelBuscador);

            // DataGridView
            dgvEnvios = new DataGridView()
            {
                Location = new Point(10, 350),
                Size = new Size(1080, 430),
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                BackgroundColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            // Columnas del grid
            dgvEnvios.Columns.Add("Id", "ID");
            dgvEnvios.Columns.Add("Documento", "Documento");
            dgvEnvios.Columns.Add("Direccion", "Dirección");
            dgvEnvios.Columns.Add("Chofer", "Chofer");
            dgvEnvios.Columns.Add("Vehiculo", "Vehículo");
            dgvEnvios.Columns.Add("FechaProgramada", "Fecha Programada");

            // Ajustar ancho de columnas
            dgvEnvios.Columns["Id"].Width = 40;
            dgvEnvios.Columns["Documento"].Width = 80;
            dgvEnvios.Columns["Direccion"].Width = 250;
            dgvEnvios.Columns["Chofer"].Width = 150;
            dgvEnvios.Columns["Vehiculo"].Width = 250;
            dgvEnvios.Columns["FechaProgramada"].Width = 120;

            dgvEnvios.CellClick += DgvEnvios_CellClick;

            this.Controls.Add(dgvEnvios);
        }

        #endregion

        #region Carga de Datos

        private void CargarComboBoxes()
        {
            try
            {
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

        private void CargarDatos()
        {
            try
            {
                var envio = new EnviosProgramados();
                listaEnvios = envio.obtenerTodos();
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

                dgvEnvios.Rows.Add(
                    envio.Id,
                    envio.Documento,
                    direccion?.Nombre ?? "N/A",
                    chofer?.Nombre ?? "N/A",
                    $"{vehiculo?.Nombre ?? "N/A"} - {vehiculo?.Placa ?? "N/A"}",
                    envio.FechaProgramada.ToString("dd/MM/yyyy")
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
                e.Documento.ToString().Contains(filtro)
            ).ToList();

            foreach (var envio in enviosFiltrados)
            {
                var direccion = listaDirecciones.FirstOrDefault(d => d.Id == envio.DirreccionEnvio);
                var chofer = listaChoferes.FirstOrDefault(c => c.Id == envio.Chofer);
                var vehiculo = listaVehiculos.FirstOrDefault(v => v.Id == envio.Vehiculo);

                dgvEnvios.Rows.Add(
                    envio.Id,
                    envio.Documento,
                    direccion?.Nombre ?? "N/A",
                    chofer?.Nombre ?? "N/A",
                    $"{vehiculo?.Nombre ?? "N/A"} - {vehiculo?.Placa ?? "N/A"}",
                    envio.FechaProgramada.ToString("dd/MM/yyyy")
                );
            }
        }

        #endregion

        #region Eventos de Botones CRUD

        private void BtnAbrirDirecciones_Click(object sender, EventArgs e)
        {
            var frmDirecciones = new frmDireccionEnvios();
            frmDirecciones.ShowDialog();
            CargarComboBoxes();
            cbDireccionEnvio.Items.Clear();
            var direccion = new DireccionEnvios();
            listaDirecciones = direccion.obtenerTodos();
            foreach (var dir in listaDirecciones)
            {
                cbDireccionEnvio.Items.Add(new AntdUI.SelectItem(dir.Nombre, dir.Id));
            }
        }

        private void BtnAbrirChoferes_Click(object sender, EventArgs e)
        {
            var frmChoferes = new frmChoferes();
            frmChoferes.ShowDialog();
            CargarComboBoxes();
            cbChofer.Items.Clear();
            var chofer = new Choferes();
            listaChoferes = chofer.obtenerTodos();
            foreach (var ch in listaChoferes)
            {
                cbChofer.Items.Add(new AntdUI.SelectItem(ch.Nombre, ch.Id));
            }
        }

        private void BtnAbrirVehiculos_Click(object sender, EventArgs e)
        {
            var frmVehiculos = new frmVehiculos();
            frmVehiculos.ShowDialog();
            CargarComboBoxes();
            cbVehiculo.Items.Clear();
            var vehiculo = new Vehiculos();
            listaVehiculos = vehiculo.obtenerTodos();
            foreach (var veh in listaVehiculos)
            {
                cbVehiculo.Items.Add(new AntdUI.SelectItem($"{veh.Nombre} - {veh.Placa}", veh.Id));
            }
        }

        #endregion

        #region Eventos de Botones Principales

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(tDocumento.Text))
            {
                AntdUI.Notification.error(this, "Validación", "El campo Documento es requerido.");
                tDocumento.Focus();
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
                var envio = new EnviosProgramados
                {
                    Documento = Convert.ToInt32(tDocumento.Text),
                    DirreccionEnvio = (int)cbDireccionEnvio.SelectedValue,
                    Chofer = (int)cbChofer.SelectedValue,
                    Vehiculo = (int)cbVehiculo.SelectedValue,
                    FechaProgramada  = (DateTime) dpFechaProgramada.Value
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

        private void BtnReporte_Click(object sender, EventArgs eevt)
        {
            try
            {
                var fecha = dpFechaProgramada.Value;
                var enviosDia = listaEnvios.Where(e => e.FechaProgramada.Date == fecha).ToList();

                if (enviosDia.Count == 0)
                {
                    AntdUI.Notification.warn(this, "Advertencia", "No hay envíos programados para esta fecha.");
                    return;
                }

                SaveFileDialog saveDialog = new SaveFileDialog()
                {
                    Filter = "Archivos CSV (*.csv)|*.csv",
                    FileName = $"Envios_{fecha:yyyy-MM-dd}.csv"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter writer = new StreamWriter(saveDialog.FileName, false, Encoding.UTF8))
                    {
                        // Encabezados
                        writer.WriteLine("ID,Documento,Dirección,Chofer,Vehículo,Placa,Fecha Programada");

                        // Datos
                        foreach (var envio in enviosDia)
                        {
                            var direccion = listaDirecciones.FirstOrDefault(d => d.Id == envio.DirreccionEnvio);
                            var chofer = listaChoferes.FirstOrDefault(c => c.Id == envio.Chofer);
                            var vehiculo = listaVehiculos.FirstOrDefault(v => v.Id == envio.Vehiculo);

                            writer.WriteLine($"{envio.Id},{envio.Documento},\"{direccion?.Nombre ?? "N/A"}\",\"{chofer?.Nombre ?? "N/A"}\",\"{vehiculo?.Nombre ?? "N/A"}\",\"{vehiculo?.Placa ?? "N/A"}\",{envio.FechaProgramada:dd/MM/yyyy}");
                        }
                    }

                    AntdUI.Notification.success(this, "Éxito", $"Reporte generado exitosamente: {saveDialog.FileName}");
                }
            }
            catch (Exception ex)
            {
                AntdUI.Notification.error(this, "Error", $"Error al generar reporte: {ex.Message}");
            }
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

                    tDocumento.Text = envioSeleccionado.Documento.ToString();
                    dpFechaProgramada.Value = envioSeleccionado.FechaProgramada;

                    // Seleccionar en Select por Value
                    cbDireccionEnvio.SelectedValue = envioSeleccionado.DirreccionEnvio;
                    cbChofer.SelectedValue = envioSeleccionado.Chofer;
                    cbVehiculo.SelectedValue = envioSeleccionado.Vehiculo;

                    btnEliminar.Enabled = true;
                    btnGuardar.Text = "Actualizar";
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
            tDocumento.Text = "";
            dpFechaProgramada.Value = DateTime.Now;
            cbDireccionEnvio.SelectedValue = null;
            cbChofer.SelectedValue = null;
            cbVehiculo.SelectedValue = null;

            envioSeleccionado = null;
            modoEdicion = false;
            btnEliminar.Enabled = false;
            btnGuardar.Text = "Guardar";
        }

        #endregion
    }
}