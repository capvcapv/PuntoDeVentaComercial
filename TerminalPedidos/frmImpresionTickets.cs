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
    public partial class frmImpresionTickets : AntdUI.Window
    {
        // Controles de la interfaz
        private AntdUI.Input tFolio;
        private AntdUI.Button btnBuscarPedido;
        private DataGridView dgvPedidos;
        private DataGridView dgvDetalle;
        private AntdUI.Select cbPresentacion;
        private AntdUI.Button btnImprimir;
        private AntdUI.Label lblEstado;

        public frmImpresionTickets()
        {
            InitializeComponents();
        }

        #region Inicialización de Componentes

        private void InitializeComponents()
        {
            // Configuración de la ventana
            this.ClientSize = new System.Drawing.Size(1100, 850);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Impresión de Tickets";
            this.Font = new Font("Poppins", 9.75f);

            // ==================== Panel Superior - Búsqueda ====================
            var panelBusqueda = new AntdUI.Panel()
            {
                Location = new Point(10, 10),
                Size = new Size(1080, 70),
                BackColor = Color.White,
                Radius = 8
            };

            // Título
            var lblTitulo = new AntdUI.Label()
            {
                Text = "Búsqueda de Pedido",
                Font = new Font("Poppins", 14, FontStyle.Bold),
                Location = new Point(15, 15),
                AutoSize = true
            };
            panelBusqueda.Controls.Add(lblTitulo);

            // Etiqueta Folio
            var lblFolio = new AntdUI.Label()
            {
                Text = "Folio:",
                Location = new Point(15, 45),
                AutoSize = true
            };
            panelBusqueda.Controls.Add(lblFolio);

            // Input Folio
            tFolio = new AntdUI.Input()
            {
                Location = new Point(80, 40),
                Size = new Size(200, 33),
                //Placeholder = "Escribe el folio del pedido..."
            };
            panelBusqueda.Controls.Add(tFolio);

            // Botón Buscar
            btnBuscarPedido = new AntdUI.Button()
            {
                Text = "Buscar",
                Location = new Point(290, 40),
                Size = new Size(100, 33),
                Radius = 8,
                BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93))))),
                BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93))))),
                DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93))))),
                Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))))
            };
            btnBuscarPedido.Click += BtnBuscarPedido_Click;
            panelBusqueda.Controls.Add(btnBuscarPedido);

            // Botón Abrir Ventana de Búsqueda
            var btnVentanaBusqueda = new AntdUI.Button()
            {
                Text = "...",
                Location = new Point(400, 40),
                Size = new Size(40, 33),
                Radius = 8,
                BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93))))),
                BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93))))),
                DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93))))),
                Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))))
            };
            btnVentanaBusqueda.Click += BtnVentanaBusqueda_Click;
            panelBusqueda.Controls.Add(btnVentanaBusqueda);

            // Etiqueta Estado
            lblEstado = new AntdUI.Label()
            {
                Text = "Estado: Sin seleccionar",
                Location = new Point(500, 48),
                AutoSize = true,
                Font = new Font("Poppins", 10, FontStyle.Regular)
            };
            panelBusqueda.Controls.Add(lblEstado);

            this.Controls.Add(panelBusqueda);

            // ==================== Panel Tabla de Pedidos ====================
            var panelTablaPedidos = new AntdUI.Panel()
            {
                Location = new Point(10, 90),
                Size = new Size(1080, 150),
                BackColor = Color.White,
                Radius = 8
            };

            var lblTablaPedidos = new AntdUI.Label()
            {
                Text = "Pedidos Disponibles",
                Font = new Font("Poppins", 12, FontStyle.Bold),
                Location = new Point(15, 10),
                AutoSize = true
            };
            panelTablaPedidos.Controls.Add(lblTablaPedidos);

            // DataGridView Pedidos
            dgvPedidos = new DataGridView()
            {
                Location = new Point(15, 35),
                Size = new Size(1050, 100),
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                BackgroundColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            // Columnas
            dgvPedidos.Columns.Add("Id", "ID");
            dgvPedidos.Columns.Add("Folio", "Folio");
            dgvPedidos.Columns.Add("Cliente", "Cliente");
            dgvPedidos.Columns.Add("Fecha", "Fecha");
            dgvPedidos.Columns.Add("Total", "Total");
            dgvPedidos.Columns.Add("Estado", "Estado");

            dgvPedidos.Columns["Id"].Width = 40;
            dgvPedidos.Columns["Folio"].Width = 80;
            dgvPedidos.Columns["Cliente"].Width = 350;
            dgvPedidos.Columns["Fecha"].Width = 120;
            dgvPedidos.Columns["Total"].Width = 120;
            dgvPedidos.Columns["Estado"].Width = 120;

            dgvPedidos.CellClick += DgvPedidos_CellClick;

            panelTablaPedidos.Controls.Add(dgvPedidos);
            this.Controls.Add(panelTablaPedidos);

            // ==================== Panel Detalle del Pedido ====================
            var panelDetalle = new AntdUI.Panel()
            {
                Location = new Point(10, 250),
                Size = new Size(1080, 500),
                BackColor = Color.White,
                Radius = 8
            };

            var lblDetalle = new AntdUI.Label()
            {
                Text = "Detalle del Pedido",
                Font = new Font("Poppins", 12, FontStyle.Bold),
                Location = new Point(15, 10),
                AutoSize = true
            };
            panelDetalle.Controls.Add(lblDetalle);

            // Etiqueta Presentación
            var lblPresentacion = new AntdUI.Label()
            {
                Text = "Presentación a Imprimir:",
                Location = new Point(15, 40),
                AutoSize = true
            };
            panelDetalle.Controls.Add(lblPresentacion);

            // Select Presentación
            cbPresentacion = new AntdUI.Select()
            {
                Location = new Point(180, 35),
                Size = new Size(300, 33)
            };
            cbPresentacion.Items.Add(new AntdUI.SelectItem("Presentación 1 - Ticket", 1));
            cbPresentacion.Items.Add(new AntdUI.SelectItem("Presentación 2 - Formato A4", 2));
            cbPresentacion.Items.Add(new AntdUI.SelectItem("Presentación 3 - Etiqueta", 3));
            cbPresentacion.SelectedIndex = 0;

            panelDetalle.Controls.Add(cbPresentacion);

            // DataGridView Detalle
            dgvDetalle = new DataGridView()
            {
                Location = new Point(15, 80),
                Size = new Size(1050, 330),
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                BackgroundColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            // Columnas Detalle
            dgvDetalle.Columns.Add("Codigo", "Código");
            dgvDetalle.Columns.Add("Producto", "Producto");
            dgvDetalle.Columns.Add("Precio", "Precio");
            dgvDetalle.Columns.Add("Cantidad", "Cantidad");
            dgvDetalle.Columns.Add("Subtotal", "Subtotal");

            dgvDetalle.Columns["Codigo"].Width = 100;
            dgvDetalle.Columns["Producto"].Width = 400;
            dgvDetalle.Columns["Precio"].Width = 150;
            dgvDetalle.Columns["Cantidad"].Width = 150;
            dgvDetalle.Columns["Subtotal"].Width = 150;

            panelDetalle.Controls.Add(dgvDetalle);

            // Botón Imprimir
            btnImprimir = new AntdUI.Button()
            {
                Text = "Imprimir",
                Location = new Point(15, 420),
                Size = new Size(120, 45),
                Radius = 8,
                BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69))))),
                BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69))))),
                DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69))))),
                Font = new System.Drawing.Font("Poppins", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))))
            };
            btnImprimir.Click += BtnImprimir_Click;
            panelDetalle.Controls.Add(btnImprimir);

            this.Controls.Add(panelDetalle);
        }

        #endregion

        #region Eventos de Botones

        private void BtnBuscarPedido_Click(object sender, EventArgs e)
        {
            // Lógica para buscar pedido por folio
            // Se implementará según la BD
        }

        private void BtnVentanaBusqueda_Click(object sender, EventArgs e)
        {
            // Abre una nueva ventana con tabla de búsqueda
            var frmBusqueda = new frmBusquedaPedidos();
            if (frmBusqueda.ShowDialog() == DialogResult.OK)
            {
                // Aquí se obtiene el folio seleccionado y se carga en tFolio
                tFolio.Text = frmBusqueda.FolioSeleccionado;
            }
        }

        private void DgvPedidos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvPedidos.Rows.Count)
            {
                // Cargar detalle del pedido seleccionado
                LimpiarDetalle();
                lblEstado.Text = "Estado: Pedido cargado";
            }
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            if (dgvDetalle.Rows.Count == 0)
            {
                AntdUI.Notification.warn(this, "Advertencia", "No hay detalles de pedido para imprimir.");
                return;
            }

            // Lógica de impresión
            AntdUI.Notification.success(this, "Éxito", "Enviando a impresora...");
        }

        #endregion

        #region Métodos Auxiliares

        private void LimpiarDetalle()
        {
            dgvDetalle.Rows.Clear();
            cbPresentacion.SelectedIndex = 0;
        }

        #endregion
    }

    // ==================== Ventana de Búsqueda de Pedidos ====================
    public partial class frmBusquedaPedidos : AntdUI.Window
    {
        public string FolioSeleccionado { get; set; }

        // Controles
        private AntdUI.Input tBusqueda;
        private DataGridView dgvBusqueda;
        private AntdUI.Button btnSeleccionar;
        private AntdUI.Button btnCancelar;

        public frmBusquedaPedidos()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            // Configuración de la ventana
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Búsqueda de Pedidos";
            this.Font = new Font("Poppins", 9.75f);

            // ==================== Panel Búsqueda ====================
            var panelBusqueda = new AntdUI.Panel()
            {
                Location = new Point(10, 10),
                Size = new Size(880, 70),
                BackColor = Color.White,
                Radius = 8
            };

            var lblTitulo = new AntdUI.Label()
            {
                Text = "Buscar Pedidos",
                Font = new Font("Poppins", 14, FontStyle.Bold),
                Location = new Point(15, 15),
                AutoSize = true
            };
            panelBusqueda.Controls.Add(lblTitulo);

            var lblBusqueda = new AntdUI.Label()
            {
                Text = "Folio o Cliente:",
                Location = new Point(15, 45),
                AutoSize = true
            };
            panelBusqueda.Controls.Add(lblBusqueda);

            tBusqueda = new AntdUI.Input()
            {
                Location = new Point(140, 40),
                Size = new Size(350, 33),
                //Placeholder = "Buscar por folio o nombre de cliente..."
            };
            tBusqueda.TextChanged += TBusqueda_TextChanged;
            panelBusqueda.Controls.Add(tBusqueda);

            this.Controls.Add(panelBusqueda);

            // ==================== DataGridView ====================
            dgvBusqueda = new DataGridView()
            {
                Location = new Point(10, 90),
                Size = new Size(880, 380),
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                BackgroundColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            dgvBusqueda.Columns.Add("Id", "ID");
            dgvBusqueda.Columns.Add("Folio", "Folio");
            dgvBusqueda.Columns.Add("Cliente", "Cliente");
            dgvBusqueda.Columns.Add("Fecha", "Fecha");
            dgvBusqueda.Columns.Add("Total", "Total");

            dgvBusqueda.Columns["Id"].Width = 50;
            dgvBusqueda.Columns["Folio"].Width = 100;
            dgvBusqueda.Columns["Cliente"].Width = 400;
            dgvBusqueda.Columns["Fecha"].Width = 150;
            dgvBusqueda.Columns["Total"].Width = 150;

            dgvBusqueda.DoubleClick += DgvBusqueda_DoubleClick;

            this.Controls.Add(dgvBusqueda);

            // ==================== Panel Botones ====================
            var panelBotones = new AntdUI.Panel()
            {
                Location = new Point(10, 480),
                Size = new Size(880, 70),
                BackColor = Color.White,
                Radius = 8
            };

            btnSeleccionar = new AntdUI.Button()
            {
                Text = "Seleccionar",
                Location = new Point(15, 15),
                Size = new Size(120, 40),
                Radius = 8,
                BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93))))),
                BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93))))),
                DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93))))),
                Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))))
            };
            btnSeleccionar.Click += BtnSeleccionar_Click;
            panelBotones.Controls.Add(btnSeleccionar);

            btnCancelar = new AntdUI.Button()
            {
                Text = "Cancelar",
                Location = new Point(145, 15),
                Size = new Size(120, 40),
                Radius = 8,
                BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93))))),
                BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93))))),
                DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93))))),
                Font = new System.Drawing.Font("Poppins", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))),
                ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))))
            };
            btnCancelar.Click += BtnCancelar_Click;
            panelBotones.Controls.Add(btnCancelar);

            this.Controls.Add(panelBotones);
        }

        private void TBusqueda_TextChanged(object sender, EventArgs e)
        {
            // Filtrar tabla según búsqueda
        }

        private void DgvBusqueda_DoubleClick(object sender, EventArgs e)
        {
            BtnSeleccionar_Click(null, null);
        }

        private void BtnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvBusqueda.SelectedRows.Count > 0)
            {
                FolioSeleccionado = dgvBusqueda.SelectedRows[0].Cells["Folio"].Value.ToString();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                AntdUI.Notification.warn(this, "Advertencia", "Selecciona un pedido.");
            }
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}