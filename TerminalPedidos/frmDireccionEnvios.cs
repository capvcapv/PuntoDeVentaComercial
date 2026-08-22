using Modelos.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TerminalPedidos
{
    public partial class frmDireccionEnvios : AntdUI.Window
    {
        private List<DireccionEnvios> listaDirecciones = new List<DireccionEnvios>();
        private DireccionEnvios direccionSeleccionada = null;
        private bool modoEdicion = false;

        // Controles de la interfaz
        private DataGridView dgvDirecciones;
        private AntdUI.Input tCodigo;
        private AntdUI.Input tNombre;
        private AntdUI.Input tLocalidad;
        private AntdUI.Input tTelefono;
        private AntdUI.Input tDireccion;
        private AntdUI.Input tBuscador;
        private AntdUI.Button btnGuardar;
        private AntdUI.Button btnEliminar;
        private AntdUI.Button btnLimpiar;
        private AntdUI.Button btnCancelar;
        private AntdUI.Button btnImprimir;

        public frmDireccionEnvios()
        {
            InitializeComponents();
            CargarDatos();
        }

        #region Inicialización de Componentes

        private void InitializeComponents()
        {
            // Configuración de la ventana
            this.ClientSize = new System.Drawing.Size(1000, 750);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Direcciones de Envío";
            this.Font = new Font("Poppins", 9.75f);

            // Panel superior para formulario
            var panelFormulario = new AntdUI.Panel()
            {
                Location = new Point(10, 10),
                Size = new Size(980, 270),
                BackColor = Color.White,
                Radius = 8
            };

            // Título
            var lblTitulo = new AntdUI.Label()
            {
                Text = "Formulario de Direcciones de Envío",
                Font = new Font("Poppins", 14, FontStyle.Bold),
                Location = new Point(15, 15),
                AutoSize = true
            };
            panelFormulario.Controls.Add(lblTitulo);

            // Código
            var lblCodigo = new AntdUI.Label()
            {
                Text = "Código:",
                Location = new Point(15, 50),
                AutoSize = true
            };
            panelFormulario.Controls.Add(lblCodigo);

            tCodigo = new AntdUI.Input()
            {
                Location = new Point(100, 45),
                Size = new Size(150, 33),
                Enabled = false
            };
            panelFormulario.Controls.Add(tCodigo);

            // Nombre
            var lblNombre = new AntdUI.Label()
            {
                Text = "Nombre:",
                Location = new Point(270, 50),
                AutoSize = true
            };
            panelFormulario.Controls.Add(lblNombre);

            tNombre = new AntdUI.Input()
            {
                Location = new Point(350, 45),
                Size = new Size(300, 33)
            };
            panelFormulario.Controls.Add(tNombre);

            // Localidad
            var lblLocalidad = new AntdUI.Label()
            {
                Text = "Localidad:",
                Location = new Point(15, 100),
                AutoSize = true
            };
            panelFormulario.Controls.Add(lblLocalidad);

            tLocalidad = new AntdUI.Input()
            {
                Location = new Point(100, 95),
                Size = new Size(300, 33)
            };
            panelFormulario.Controls.Add(tLocalidad);

            // Teléfono
            var lblTelefono = new AntdUI.Label()
            {
                Text = "Teléfono:",
                Location = new Point(420, 100),
                AutoSize = true
            };
            panelFormulario.Controls.Add(lblTelefono);

            tTelefono = new AntdUI.Input()
            {
                Location = new Point(500, 95),
                Size = new Size(150, 33)
            };
            panelFormulario.Controls.Add(tTelefono);

            // Dirección
            var lblDireccion = new AntdUI.Label()
            {
                Text = "Dirección:",
                Location = new Point(15, 150),
                AutoSize = true
            };
            panelFormulario.Controls.Add(lblDireccion);

            tDireccion = new AntdUI.Input()
            {
                Location = new Point(100, 145),
                Size = new Size(550, 60),
                Multiline = true
            };
            panelFormulario.Controls.Add(tDireccion);

            // Botones
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

            btnCancelar = new AntdUI.Button()
            {
                Text = "Cancelar",
                Location = new Point(345, 215),
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

            btnImprimir = new AntdUI.Button()
            {
                Text = "Imprimir Ticket",
                Location = new Point(455, 215),
                Size = new Size(130, 40),
                Radius = 8,
                Enabled = false,
                BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0))))),
                BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0))))),
                DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0))))),
                Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))))
            };
            btnImprimir.Click += BtnImprimir_Click;
            panelFormulario.Controls.Add(btnImprimir);

            this.Controls.Add(panelFormulario);

            // Panel Buscador
            var panelBuscador = new AntdUI.Panel()
            {
                Location = new Point(10, 290),
                Size = new Size(980, 50),
                BackColor = Color.White,
                Radius = 8
            };

            var lblBuscador = new AntdUI.Label()
            {
                Text = "Buscar por Nombre:",
                Location = new Point(15, 13),
                AutoSize = true,
                Font = new Font("Poppins", 10, FontStyle.Regular)
            };
            panelBuscador.Controls.Add(lblBuscador);

            tBuscador = new AntdUI.Input()
            {
                Location = new Point(150, 10),
                Size = new Size(300, 33)
            };
            tBuscador.TextChanged += TBuscador_TextChanged;
            panelBuscador.Controls.Add(tBuscador);

            this.Controls.Add(panelBuscador);

            // DataGridView
            dgvDirecciones = new DataGridView()
            {
                Location = new Point(10, 350),
                Size = new Size(980, 380),
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                BackgroundColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            dgvDirecciones.Columns.Add("Id", "ID");
            dgvDirecciones.Columns.Add("Codigo", "Código");
            dgvDirecciones.Columns.Add("Nombre", "Nombre");
            dgvDirecciones.Columns.Add("Localidad", "Localidad");
            dgvDirecciones.Columns.Add("Telefono", "Teléfono");
            dgvDirecciones.Columns.Add("Direccion", "Dirección");

            dgvDirecciones.Columns["Id"].Width = 40;
            dgvDirecciones.Columns["Codigo"].Width = 80;
            dgvDirecciones.Columns["Nombre"].Width = 150;
            dgvDirecciones.Columns["Localidad"].Width = 120;
            dgvDirecciones.Columns["Telefono"].Width = 100;
            dgvDirecciones.Columns["Direccion"].Width = 350;

            dgvDirecciones.CellClick += DgvDirecciones_CellClick;

            this.Controls.Add(dgvDirecciones);
        }

        #endregion

        #region Métodos de Datos

        private void CargarDatos()
        {
            try
            {
                var direccion = new DireccionEnvios();
                listaDirecciones = direccion.obtenerTodos();
                MostrarDatos();
            }
            catch (Exception ex)
            {
                AntdUI.Notification.error(this, "Error", $"Error al cargar datos: {ex.Message}");
            }
        }

        private void MostrarDatos()
        {
            dgvDirecciones.Rows.Clear();
            foreach (var direccion in listaDirecciones)
            {
                dgvDirecciones.Rows.Add(
                    direccion.Id,
                    direccion.Codigo,
                    direccion.Nombre,
                    direccion.Localidad,
                    direccion.Telefono,
                    direccion.Direccion
                );
            }
        }

        private void FiltrarDatos(string filtro)
        {
            dgvDirecciones.Rows.Clear();

            if (string.IsNullOrWhiteSpace(filtro))
            {
                MostrarDatos();
                return;
            }

            var direccionesFiltradas = listaDirecciones.Where(d =>
                d.Nombre.ToLower().Contains(filtro.ToLower()) ||
                d.Codigo.ToLower().Contains(filtro.ToLower()) ||
                d.Localidad.ToLower().Contains(filtro.ToLower())
            ).ToList();

            foreach (var direccion in direccionesFiltradas)
            {
                dgvDirecciones.Rows.Add(
                    direccion.Id,
                    direccion.Codigo,
                    direccion.Nombre,
                    direccion.Localidad,
                    direccion.Telefono,
                    direccion.Direccion
                );
            }
        }

        #endregion

        #region Eventos de Botones

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(tNombre.Text))
            {
                AntdUI.Notification.error(this, "Validación", "El campo Nombre es requerido.");
                tNombre.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(tLocalidad.Text))
            {
                AntdUI.Notification.error(this, "Validación", "El campo Localidad es requerido.");
                tLocalidad.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(tDireccion.Text))
            {
                AntdUI.Notification.error(this, "Validación", "El campo Dirección es requerido.");
                tDireccion.Focus();
                return;
            }

            try
            {
                var direccion = new DireccionEnvios
                {
                    Codigo = tCodigo.Text,
                    Nombre = tNombre.Text,
                    Localidad = tLocalidad.Text,
                    Telefono = tTelefono.Text,
                    Direccion = tDireccion.Text
                };

                if (modoEdicion)
                {
                    direccion.Id = direccionSeleccionada.Id;
                    direccion.actualizar();
                    AntdUI.Notification.success(this, "Éxito", "Dirección actualizada correctamente.");
                }
                else
                {
                    direccion.guardar();
                    AntdUI.Notification.success(this, "Éxito", "Dirección guardada correctamente.");
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
            if (direccionSeleccionada == null)
            {
                AntdUI.Notification.warn(this, "Advertencia", "Selecciona una dirección para eliminar.");
                return;
            }

            var result = MessageBox.Show("¿Estás seguro de que deseas eliminar esta dirección?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var direccion = new DireccionEnvios { Id = direccionSeleccionada.Id };
                    direccion.elimina();
                    AntdUI.Notification.success(this, "Éxito", "Dirección eliminada correctamente.");
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

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            if (direccionSeleccionada == null)
            {
                AntdUI.Notification.warn(this, "Advertencia", "Selecciona una dirección para imprimir.");
                return;
            }

            try
            {
                PrintDocument pd = new PrintDocument();

                // Tamaño ticket térmico 58mm aprox
                pd.DefaultPageSettings.PaperSize = new PaperSize("Ticket", 280, 1000);

                pd.DefaultPageSettings.Margins = new Margins(5, 5, 5, 5);

                pd.PrintPage += (s, ev) =>
                {
                    Graphics g = ev.Graphics;

                    Font fontTitulo = new Font("Courier New", 10, FontStyle.Bold);
                    Font fontNormal = new Font("Courier New", 8, FontStyle.Regular);
                    Font fontPeq = new Font("Courier New", 7, FontStyle.Regular);

                    string separador = "--------------------------------";

                    float x = 5;
                    float y = 5;

                    // Ancho REAL imprimible del ticket
                    float ancho = 240;

                    // Función helper
                    void DrawLine(string texto, Font fuente, bool negrita = false)
                    {
                        SizeF size = g.MeasureString(texto, fuente, (int)ancho);

                        g.DrawString(
                            texto,
                            fuente,
                            Brushes.Black,
                            new RectangleF(x, y, ancho, size.Height)
                        );

                        y += size.Height + 2;
                    }

                    // ENCABEZADO
                    DrawLine("DOMICILIO DE ENVIO", fontTitulo);
                    DrawLine(separador, fontPeq);

                    // NOMBRE
                    DrawLine("Nombre:", fontNormal);
                    DrawLine(direccionSeleccionada.Nombre ?? "", fontTitulo);

                    DrawLine(separador, fontPeq);

                    // LOCALIDAD
                    DrawLine("Localidad:", fontNormal);
                    DrawLine(direccionSeleccionada.Localidad ?? "", fontNormal);

                    // TELEFONO
                    DrawLine("Telefono:", fontNormal);
                    DrawLine(direccionSeleccionada.Telefono ?? "", fontNormal);

                    DrawLine(separador, fontPeq);

                    // DIRECCION
                    DrawLine("Direccion:", fontNormal);

                    string direccion = direccionSeleccionada.Direccion ?? "";

                    SizeF dirSize = g.MeasureString(
                        direccion,
                        fontNormal,
                        (int)ancho
                    );

                    g.DrawString(
                        direccion,
                        fontNormal,
                        Brushes.Black,
                        new RectangleF(x, y, ancho, dirSize.Height)
                    );

                    y += dirSize.Height + 5;

                    DrawLine(separador, fontPeq);

                    fontTitulo.Dispose();
                    fontNormal.Dispose();
                    fontPeq.Dispose();
                };

                PrintDialog dialogo = new PrintDialog();
                dialogo.Document = pd;

                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    pd.Print();

                    AntdUI.Notification.success(
                        this,
                        "Éxito",
                        "Ticket enviado a imprimir."
                    );
                }

                dialogo.Dispose();
                pd.Dispose();
            }
            catch (Exception ex)
            {
                AntdUI.Notification.error(
                    this,
                    "Error",
                    $"Error al imprimir: {ex.Message}"
                );
            }
        }

        private void DgvDirecciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvDirecciones.Rows.Count)
            {
                int id = Convert.ToInt32(dgvDirecciones.Rows[e.RowIndex].Cells["Id"].Value);
                direccionSeleccionada = listaDirecciones.FirstOrDefault(d => d.Id == id);

                if (direccionSeleccionada != null)
                {
                    modoEdicion = true;

                    tCodigo.Text = direccionSeleccionada.Codigo;
                    tNombre.Text = direccionSeleccionada.Nombre;
                    tLocalidad.Text = direccionSeleccionada.Localidad;
                    tTelefono.Text = direccionSeleccionada.Telefono;
                    tDireccion.Text = direccionSeleccionada.Direccion;

                    btnEliminar.Enabled = true;
                    btnImprimir.Enabled = true;
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
            tCodigo.Text = "";
            tNombre.Text = "";
            tLocalidad.Text = "";
            tTelefono.Text = "";
            tDireccion.Text = "";

            direccionSeleccionada = null;
            modoEdicion = false;
            btnEliminar.Enabled = false;
            btnImprimir.Enabled = false;
            btnGuardar.Text = "Guardar";
        }

        #endregion
    }
}