namespace AdministradorPV
{
    partial class frmCajas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCajas));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbFactura = new System.Windows.Forms.ComboBox();
            this.cbFacturaGlobal = new System.Windows.Forms.ComboBox();
            this.cbAlmacen = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbPedidos = new System.Windows.Forms.ComboBox();
            this.cbRemisionAlterna = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbPedidoAlterna = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbConceptoCotizacion = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbConceptoCotizacion2 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripButton1,
            this.toolStripButton3,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(583, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(62, 22);
            this.toolStripButton2.Text = "Nuevo";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(69, 22);
            this.toolStripButton1.Text = "Guardar";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(70, 22);
            this.toolStripButton3.Text = "Eliminar";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(49, 22);
            this.toolStripButton4.Text = "Salir";
            this.toolStripButton4.Click += new System.EventHandler(this.toolStripButton4_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 32);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(232, 420);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(264, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre";
            // 
            // tNombre
            // 
            this.tNombre.Location = new System.Drawing.Point(267, 48);
            this.tNombre.Name = "tNombre";
            this.tNombre.Size = new System.Drawing.Size(300, 20);
            this.tNombre.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(264, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Almacen";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(264, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Remisión 1";
            // 
            // cbFactura
            // 
            this.cbFactura.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFactura.FormattingEnabled = true;
            this.cbFactura.Location = new System.Drawing.Point(267, 154);
            this.cbFactura.Name = "cbFactura";
            this.cbFactura.Size = new System.Drawing.Size(300, 21);
            this.cbFactura.TabIndex = 10;
            // 
            // cbFacturaGlobal
            // 
            this.cbFacturaGlobal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFacturaGlobal.FormattingEnabled = true;
            this.cbFacturaGlobal.Location = new System.Drawing.Point(521, 74);
            this.cbFacturaGlobal.Name = "cbFacturaGlobal";
            this.cbFacturaGlobal.Size = new System.Drawing.Size(18, 21);
            this.cbFacturaGlobal.TabIndex = 11;
            this.cbFacturaGlobal.Visible = false;
            // 
            // cbAlmacen
            // 
            this.cbAlmacen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAlmacen.FormattingEnabled = true;
            this.cbAlmacen.Location = new System.Drawing.Point(267, 108);
            this.cbAlmacen.Name = "cbAlmacen";
            this.cbAlmacen.Size = new System.Drawing.Size(300, 21);
            this.cbAlmacen.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(264, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Pedido 1";
            // 
            // cbPedidos
            // 
            this.cbPedidos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPedidos.FormattingEnabled = true;
            this.cbPedidos.Location = new System.Drawing.Point(267, 245);
            this.cbPedidos.Name = "cbPedidos";
            this.cbPedidos.Size = new System.Drawing.Size(300, 21);
            this.cbPedidos.TabIndex = 14;
            // 
            // cbRemisionAlterna
            // 
            this.cbRemisionAlterna.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRemisionAlterna.FormattingEnabled = true;
            this.cbRemisionAlterna.Location = new System.Drawing.Point(267, 197);
            this.cbRemisionAlterna.Name = "cbRemisionAlterna";
            this.cbRemisionAlterna.Size = new System.Drawing.Size(300, 21);
            this.cbRemisionAlterna.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(264, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Remisión 2";
            // 
            // cbPedidoAlterna
            // 
            this.cbPedidoAlterna.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPedidoAlterna.FormattingEnabled = true;
            this.cbPedidoAlterna.Location = new System.Drawing.Point(267, 292);
            this.cbPedidoAlterna.Name = "cbPedidoAlterna";
            this.cbPedidoAlterna.Size = new System.Drawing.Size(300, 21);
            this.cbPedidoAlterna.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(264, 276);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Pedido 2";
            // 
            // cbConceptoCotizacion
            // 
            this.cbConceptoCotizacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConceptoCotizacion.FormattingEnabled = true;
            this.cbConceptoCotizacion.Location = new System.Drawing.Point(267, 338);
            this.cbConceptoCotizacion.Name = "cbConceptoCotizacion";
            this.cbConceptoCotizacion.Size = new System.Drawing.Size(300, 21);
            this.cbConceptoCotizacion.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(264, 322);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Cotización 1";
            // 
            // cbConceptoCotizacion2
            // 
            this.cbConceptoCotizacion2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConceptoCotizacion2.FormattingEnabled = true;
            this.cbConceptoCotizacion2.Location = new System.Drawing.Point(267, 377);
            this.cbConceptoCotizacion2.Name = "cbConceptoCotizacion2";
            this.cbConceptoCotizacion2.Size = new System.Drawing.Size(300, 21);
            this.cbConceptoCotizacion2.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(264, 361);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Cotización 2";
            // 
            // frmCajas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(583, 463);
            this.Controls.Add(this.cbConceptoCotizacion2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbConceptoCotizacion);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbPedidoAlterna);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbRemisionAlterna);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbPedidos);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbAlmacen);
            this.Controls.Add(this.cbFacturaGlobal);
            this.Controls.Add(this.cbFactura);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tNombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCajas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cajas";
            this.Load += new System.EventHandler(this.frmCajas_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbFactura;
        private System.Windows.Forms.ComboBox cbFacturaGlobal;
        private System.Windows.Forms.ComboBox cbAlmacen;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbPedidos;
        private System.Windows.Forms.ComboBox cbRemisionAlterna;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbPedidoAlterna;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbConceptoCotizacion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbConceptoCotizacion2;
        private System.Windows.Forms.Label label9;
    }
}