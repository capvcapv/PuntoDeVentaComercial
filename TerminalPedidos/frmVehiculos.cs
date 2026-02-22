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
    public partial class frmVehiculos : AntdUI.Window
    {
        private List<Vehiculos> listaVehiculos = new List<Vehiculos>();
        private Vehiculos vehiculoSeleccionado = null;
        private bool modoEdicion = false;

        // Controles de la interfaz
        private DataGridView dgvVehiculos;
        private AntdUI.Input tNombre;
        private AntdUI.Input tPlaca;
        private AntdUI.Button btnGuardar;
        private AntdUI.Button btnEliminar;
        private AntdUI.Button btnLimpiar;
        private AntdUI.Button btnCancelar;

        public frmVehiculos()
        {
            InitializeComponents();
            CargarDatos();
        }

        #region Inicialización de Componentes

        private void InitializeComponents()
        {
            // Configuración de la ventana
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Vehículos";
            this.Font = new Font("Poppins", 9.75f);

            // Panel superior para formulario
            var panelFormulario = new AntdUI.Panel()
            {
                Location = new Point(10, 10),
                Size = new Size(780, 150),
                BackColor = Color.White,
                Radius = 8
            };

            // Título
            var lblTitulo = new AntdUI.Label()
            {
                Text = "Formulario de Vehículos",
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
                Size = new Size(300, 33),
                //Placeholder = "Nombre del vehículo"
            };
            //tNombre.SetBorderColor(Color.FromArgb(3, 96, 93), Color.FromArgb(153, 233, 211), Color.FromArgb(3, 96, 93));
            panelFormulario.Controls.Add(tNombre);

            // Placa
            var lblPlaca = new AntdUI.Label()
            {
                Text = "Placa:",
                Location = new Point(420, 50),
                AutoSize = true
            };
            panelFormulario.Controls.Add(lblPlaca);

            tPlaca = new AntdUI.Input()
            {
                Location = new Point(480, 45),
                Size = new Size(280, 33),
                //Placeholder = "ABC-1234"
            };
            //tPlaca.SetBorderColor(Color.FromArgb(3, 96, 93), Color.FromArgb(153, 233, 211), Color.FromArgb(3, 96, 93));
            panelFormulario.Controls.Add(tPlaca);

            // Botones
            btnGuardar = new AntdUI.Button()
            {
                Text = "Guardar",
                Location = new Point(15, 95),
                Size = new Size(100, 40),
                //BackColor = Color.FromArgb(3, 96, 93),
                //ForeColor = Color.White,
                //Font = new Font("Poppins", 10),
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
                Location = new Point(125, 95),
                Size = new Size(100, 40),
                //BackColor = Color.FromArgb(220, 53, 69),
                //ForeColor = Color.White,
                //Font = new Font("Poppins", 10),
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
                Location = new Point(235, 95),
                Size = new Size(100, 40),
                //BackColor = Color.FromArgb(108, 117, 125),
                //ForeColor = Color.White,
                //Font = new Font("Poppins", 10),
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
                Location = new Point(345, 95),
                Size = new Size(100, 40),
                //BackColor = Color.FromArgb(52, 73, 94),
                //ForeColor = Color.White,
                //Font = new Font("Poppins", 10),
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
            dgvVehiculos = new DataGridView()
            {
                Location = new Point(10, 170),
                Size = new Size(780, 410),
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                BackgroundColor = Color.White
            };

            // Columnas del grid
            dgvVehiculos.Columns.Add("Id", "ID");
            dgvVehiculos.Columns.Add("Nombre", "Nombre");
            dgvVehiculos.Columns.Add("Placa", "Placa");

            dgvVehiculos.CellClick += DgvVehiculos_CellClick;

            this.Controls.Add(dgvVehiculos);
        }

        #endregion

        #region Métodos de Datos

        private void CargarDatos()
        {
            try
            {
                var vehiculo = new Vehiculos();
                listaVehiculos = vehiculo.obtenerTodos();
                MostrarDatos();
            }
            catch (Exception ex)
            {
                AntdUI.Notification.error(this, "Error", $"Error al cargar datos: {ex.Message}");
            }
        }

        private void MostrarDatos()
        {
            dgvVehiculos.Rows.Clear();
            foreach (var vehiculo in listaVehiculos)
            {
                dgvVehiculos.Rows.Add(
                    vehiculo.Id,
                    vehiculo.Nombre,
                    vehiculo.Placa
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

            if (string.IsNullOrWhiteSpace(tPlaca.Text))
            {
                AntdUI.Notification.error(this, "Validación", "El campo Placa es requerido.");
                tPlaca.Focus();
                return;
            }

            try
            {
                var vehiculo = new Vehiculos
                {
                    Nombre = tNombre.Text,
                    Placa = tPlaca.Text
                };

                if (modoEdicion)
                {
                    vehiculo.Id = vehiculoSeleccionado.Id;
                    vehiculo.actualizar();
                    AntdUI.Notification.success(this, "Éxito", "Vehículo actualizado correctamente.");
                }
                else
                {
                    vehiculo.guardar();
                    AntdUI.Notification.success(this, "Éxito", "Vehículo guardado correctamente.");
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
            if (vehiculoSeleccionado == null)
            {
                AntdUI.Notification.warn(this, "Advertencia", "Selecciona un vehículo para eliminar.");
                return;
            }

            var result = MessageBox.Show("¿Estás seguro de que deseas eliminar este vehículo?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var vehiculo = new Vehiculos { Id = vehiculoSeleccionado.Id };
                    vehiculo.elimina();
                    AntdUI.Notification.success(this, "Éxito", "Vehículo eliminado correctamente.");
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

        private void DgvVehiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < listaVehiculos.Count)
            {
                vehiculoSeleccionado = listaVehiculos[e.RowIndex];
                modoEdicion = true;

                tNombre.Text = vehiculoSeleccionado.Nombre;
                tPlaca.Text = vehiculoSeleccionado.Placa;

                btnEliminar.Enabled = true;
                btnGuardar.Text = "Actualizar";
            }
        }

        #endregion

        #region Métodos Auxiliares

        private void LimpiarFormulario()
        {
            tNombre.Text = "";
            tPlaca.Text = "";

            vehiculoSeleccionado = null;
            modoEdicion = false;
            btnEliminar.Enabled = false;
            btnGuardar.Text = "Guardar";
        }

        #endregion
    }
}