namespace AdministradorPV
{
    partial class frmConfiguracion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfiguracion));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tEmpresa = new System.Windows.Forms.TextBox();
            this.tRutaBinarios = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tClaveSello = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tNombreEmpresa = new System.Windows.Forms.TextBox();
            this.tDireccion = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ckImprimeTicket = new System.Windows.Forms.CheckBox();
            this.ckIvaIncluido = new System.Windows.Forms.CheckBox();
            this.ckMuestraVentanaDescuentos = new System.Windows.Forms.CheckBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip1.Size = new System.Drawing.Size(816, 34);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(101, 29);
            this.toolStripButton1.Text = "Aceptar";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ruta de empresa Contpaq i Comercial";
            // 
            // tEmpresa
            // 
            this.tEmpresa.Location = new System.Drawing.Point(22, 89);
            this.tEmpresa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tEmpresa.Name = "tEmpresa";
            this.tEmpresa.Size = new System.Drawing.Size(494, 26);
            this.tEmpresa.TabIndex = 2;
            // 
            // tRutaBinarios
            // 
            this.tRutaBinarios.Location = new System.Drawing.Point(22, 178);
            this.tRutaBinarios.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tRutaBinarios.Name = "tRutaBinarios";
            this.tRutaBinarios.Size = new System.Drawing.Size(494, 26);
            this.tRutaBinarios.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 154);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ruta de binarios";
            // 
            // tClaveSello
            // 
            this.tClaveSello.Location = new System.Drawing.Point(22, 586);
            this.tClaveSello.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tClaveSello.Name = "tClaveSello";
            this.tClaveSello.Size = new System.Drawing.Size(494, 26);
            this.tClaveSello.TabIndex = 6;
            this.tClaveSello.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 562);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Clave de sello digital";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 245);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Nombre empresa:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 343);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Dirección:";
            // 
            // tNombreEmpresa
            // 
            this.tNombreEmpresa.Location = new System.Drawing.Point(22, 285);
            this.tNombreEmpresa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tNombreEmpresa.Name = "tNombreEmpresa";
            this.tNombreEmpresa.Size = new System.Drawing.Size(494, 26);
            this.tNombreEmpresa.TabIndex = 9;
            // 
            // tDireccion
            // 
            this.tDireccion.Location = new System.Drawing.Point(22, 385);
            this.tDireccion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tDireccion.Name = "tDireccion";
            this.tDireccion.Size = new System.Drawing.Size(770, 26);
            this.tDireccion.TabIndex = 10;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(528, 89);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(270, 255);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(524, 65);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "Logo";
            // 
            // ckImprimeTicket
            // 
            this.ckImprimeTicket.AutoSize = true;
            this.ckImprimeTicket.Location = new System.Drawing.Point(27, 443);
            this.ckImprimeTicket.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ckImprimeTicket.Name = "ckImprimeTicket";
            this.ckImprimeTicket.Size = new System.Drawing.Size(134, 24);
            this.ckImprimeTicket.TabIndex = 14;
            this.ckImprimeTicket.Text = "Imprime ticket";
            this.ckImprimeTicket.UseVisualStyleBackColor = true;
            this.ckImprimeTicket.Visible = false;
            // 
            // ckIvaIncluido
            // 
            this.ckIvaIncluido.AutoSize = true;
            this.ckIvaIncluido.Location = new System.Drawing.Point(275, 443);
            this.ckIvaIncluido.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ckIvaIncluido.Name = "ckIvaIncluido";
            this.ckIvaIncluido.Size = new System.Drawing.Size(113, 24);
            this.ckIvaIncluido.TabIndex = 15;
            this.ckIvaIncluido.Text = "Iva incluido";
            this.ckIvaIncluido.UseVisualStyleBackColor = true;
            // 
            // ckMuestraVentanaDescuentos
            // 
            this.ckMuestraVentanaDescuentos.AutoSize = true;
            this.ckMuestraVentanaDescuentos.Location = new System.Drawing.Point(528, 443);
            this.ckMuestraVentanaDescuentos.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ckMuestraVentanaDescuentos.Name = "ckMuestraVentanaDescuentos";
            this.ckMuestraVentanaDescuentos.Size = new System.Drawing.Size(241, 24);
            this.ckMuestraVentanaDescuentos.TabIndex = 16;
            this.ckMuestraVentanaDescuentos.Text = "Muestra ventana descuentos";
            this.ckMuestraVentanaDescuentos.UseVisualStyleBackColor = true;
            // 
            // frmConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(816, 488);
            this.Controls.Add(this.ckMuestraVentanaDescuentos);
            this.Controls.Add(this.ckIvaIncluido);
            this.Controls.Add(this.ckImprimeTicket);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tDireccion);
            this.Controls.Add(this.tNombreEmpresa);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tClaveSello);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tRutaBinarios);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tEmpresa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmConfiguracion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuración";
            this.Load += new System.EventHandler(this.frmConfiguracion_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tEmpresa;
        private System.Windows.Forms.TextBox tRutaBinarios;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tClaveSello;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tNombreEmpresa;
        private System.Windows.Forms.TextBox tDireccion;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox ckImprimeTicket;
        private System.Windows.Forms.CheckBox ckIvaIncluido;
        private System.Windows.Forms.CheckBox ckMuestraVentanaDescuentos;
    }
}