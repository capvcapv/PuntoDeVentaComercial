namespace AdministradorPV
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.administraciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cajasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preciosDeVentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parámetrosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facturacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facturaGlobalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.administraciónToolStripMenuItem,
            this.facturacionToolStripMenuItem,
            this.reportesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(780, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // administraciónToolStripMenuItem
            // 
            this.administraciónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cajasToolStripMenuItem,
            this.preciosDeVentaToolStripMenuItem,
            this.usuariosToolStripMenuItem,
            this.parámetrosToolStripMenuItem});
            this.administraciónToolStripMenuItem.Name = "administraciónToolStripMenuItem";
            this.administraciónToolStripMenuItem.Size = new System.Drawing.Size(100, 20);
            this.administraciónToolStripMenuItem.Text = "Administración";
            // 
            // cajasToolStripMenuItem
            // 
            this.cajasToolStripMenuItem.Name = "cajasToolStripMenuItem";
            this.cajasToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.cajasToolStripMenuItem.Text = "Cajas";
            this.cajasToolStripMenuItem.Click += new System.EventHandler(this.cajasToolStripMenuItem_Click);
            // 
            // preciosDeVentaToolStripMenuItem
            // 
            this.preciosDeVentaToolStripMenuItem.Name = "preciosDeVentaToolStripMenuItem";
            this.preciosDeVentaToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.preciosDeVentaToolStripMenuItem.Text = "Precios de venta";
            this.preciosDeVentaToolStripMenuItem.Visible = false;
            this.preciosDeVentaToolStripMenuItem.Click += new System.EventHandler(this.preciosDeVentaToolStripMenuItem_Click);
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // parámetrosToolStripMenuItem
            // 
            this.parámetrosToolStripMenuItem.Name = "parámetrosToolStripMenuItem";
            this.parámetrosToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.parámetrosToolStripMenuItem.Text = "Parámetros";
            this.parámetrosToolStripMenuItem.Click += new System.EventHandler(this.parámetrosToolStripMenuItem_Click);
            // 
            // facturacionToolStripMenuItem
            // 
            this.facturacionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.facturaGlobalToolStripMenuItem});
            this.facturacionToolStripMenuItem.Name = "facturacionToolStripMenuItem";
            this.facturacionToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.facturacionToolStripMenuItem.Text = "Procesos";
            // 
            // facturaGlobalToolStripMenuItem
            // 
            this.facturaGlobalToolStripMenuItem.Name = "facturaGlobalToolStripMenuItem";
            this.facturaGlobalToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.facturaGlobalToolStripMenuItem.Text = "Corte de caja";
            this.facturaGlobalToolStripMenuItem.Click += new System.EventHandler(this.facturaGlobalToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.reportesToolStripMenuItem.Text = "Reportes";
            this.reportesToolStripMenuItem.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(780, 308);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Administrador Punto de Venta";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem administraciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cajasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preciosDeVentaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parámetrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem facturacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem facturaGlobalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
    }
}

