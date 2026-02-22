using Modelos.Negocio;
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
                Size = new Size(300, 33),
                //Placeholder = "Escribe el nombre..."
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

            // Columnas del grid
            dgvDirecciones.Columns.Add("Id", "ID");
            dgvDirecciones.Columns.Add("Codigo", "Código");
            dgvDirecciones.Columns.Add("Nombre", "Nombre");
            dgvDirecciones.Columns.Add("Localidad", "Localidad");
            dgvDirecciones.Columns.Add("Telefono", "Teléfono");
            dgvDirecciones.Columns.Add("Direccion", "Dirección");

            // Ajustar ancho de columnas
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
            btnGuardar.Text = "Guardar";
        }

        #endregion
    }
}