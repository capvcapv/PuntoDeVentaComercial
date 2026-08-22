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
    public partial class frmChoferes : AntdUI.Window
    {
        private List<Choferes> listaChoferes = new List<Choferes>();
        private Choferes choferSeleccionado = null;
        private bool modoEdicion = false;

        // Controles de la interfaz
        private DataGridView dgvChoferes;
        private AntdUI.Input tNombre;
        private AntdUI.Input tClave;
        private AntdUI.Button btnGuardar;
        private AntdUI.Button btnEliminar;
        private AntdUI.Button btnLimpiar;
        private AntdUI.Button btnCancelar;

        public frmChoferes()
        {
            InitializeComponents();
            CargarDatos();
        }

        #region Inicialización de Componentes

        private void InitializeComponents()
        {
            // Configuración de la ventana
            this.ClientSize = new System.Drawing.Size(700, 550);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Choferes";
            this.Font = new Font("Poppins", 9.75f);

            // Panel superior para formulario
            var panelFormulario = new AntdUI.Panel()
            {
                Location = new Point(10, 10),
                Size = new Size(680, 190),
                BackColor = Color.White,
                Radius = 8
            };

            // Título
            var lblTitulo = new AntdUI.Label()
            {
                Text = "Formulario de Choferes",
                Font = new Font("Poppins", 14, FontStyle.Bold),
                Location = new Point(15, 15),
                AutoSize = true
            };
            panelFormulario.Controls.Add(lblTitulo);

            // Nombre
            var lblNombre = new AntdUI.Label()
            {
                Text = "Nombre:",
                Location = new Point(15, 50),
                AutoSize = true
            };
            panelFormulario.Controls.Add(lblNombre);

            tNombre = new AntdUI.Input()
            {
                Location = new Point(100, 45),
                Size = new Size(580, 33)
            };
            panelFormulario.Controls.Add(tNombre);

            // Clave
            var lblClave = new AntdUI.Label()
            {
                Text = "Clave:",
                Location = new Point(15, 95),
                AutoSize = true
            };
            panelFormulario.Controls.Add(lblClave);

            tClave = new AntdUI.Input()
            {
                Location = new Point(100, 90),
                Size = new Size(580, 33),
                //Type = AntdUI.InputType.Password
            };
            panelFormulario.Controls.Add(tClave);

            // Botones
            btnGuardar = new AntdUI.Button()
            {
                Text = "Guardar",
                Location = new Point(15, 135),
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
                Location = new Point(125, 135),
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
                Location = new Point(235, 135),
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
                Location = new Point(345, 135),
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

            // DataGridView
            dgvChoferes = new DataGridView()
            {
                Location = new Point(10, 210),
                Size = new Size(680, 300),
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                BackgroundColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            // Columnas del grid
            dgvChoferes.Columns.Add("Id", "ID");
            dgvChoferes.Columns.Add("Nombre", "Nombre");
            dgvChoferes.Columns.Add("Clave", "Clave");

            dgvChoferes.Columns["Id"].Width = 50;
            dgvChoferes.Columns["Nombre"].Width = 300;
            dgvChoferes.Columns["Clave"].Width = 330;

            dgvChoferes.CellClick += DgvChoferes_CellClick;

            this.Controls.Add(dgvChoferes);
        }

        #endregion

        #region Métodos de Datos

        private void CargarDatos()
        {
            try
            {
                var chofer = new Choferes();
                listaChoferes = chofer.obtenerTodos();
                MostrarDatos();
            }
            catch (Exception ex)
            {
                AntdUI.Notification.error(this, "Error", $"Error al cargar datos: {ex.Message}");
            }
        }

        private void MostrarDatos()
        {
            dgvChoferes.Rows.Clear();
            foreach (var chofer in listaChoferes)
            {
                dgvChoferes.Rows.Add(
                    chofer.Id,
                    chofer.Nombre,
                    chofer.Clave
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

            if (string.IsNullOrWhiteSpace(tClave.Text))
            {
                AntdUI.Notification.error(this, "Validación", "El campo Clave es requerido.");
                tClave.Focus();
                return;
            }

            try
            {
                var chofer = new Choferes
                {
                    Nombre = tNombre.Text,
                    Clave = tClave.Text
                };

                if (modoEdicion)
                {
                    chofer.Id = choferSeleccionado.Id;
                    chofer.actualizar();
                    AntdUI.Notification.success(this, "Éxito", "Chofer actualizado correctamente.");
                }
                else
                {
                    chofer.guardar();
                    AntdUI.Notification.success(this, "Éxito", "Chofer guardado correctamente.");
                }

                CargarDatos();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                AntdUI.Notification.error(this, "Error", $"Error al guardar: {ex.Message}");
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (choferSeleccionado == null)
            {
                AntdUI.Notification.warn(this, "Advertencia", "Selecciona un chofer para eliminar.");
                return;
            }

            var result = MessageBox.Show("¿Estás seguro de que deseas eliminar este chofer?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var chofer = new Choferes { Id = choferSeleccionado.Id };
                    chofer.elimina();
                    AntdUI.Notification.success(this, "Éxito", "Chofer eliminado correctamente.");
                    CargarDatos();
                    LimpiarFormulario();
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

        private void DgvChoferes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < listaChoferes.Count)
            {
                choferSeleccionado = listaChoferes[e.RowIndex];
                modoEdicion = true;

                tNombre.Text = choferSeleccionado.Nombre;
                tClave.Text = choferSeleccionado.Clave;

                btnEliminar.Enabled = true;
                btnGuardar.Text = "Actualizar";
            }
        }

        #endregion

        #region Métodos Auxiliares

        private void LimpiarFormulario()
        {
            tNombre.Text = "";
            tClave.Text = "";

            choferSeleccionado = null;
            modoEdicion = false;
            btnEliminar.Enabled = false;
            btnGuardar.Text = "Guardar";
        }

        #endregion
    }
}