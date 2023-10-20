
namespace TerminalPedidos
{
    partial class CalculaCambio
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tTotal = new System.Windows.Forms.TextBox();
            this.tPago = new System.Windows.Forms.TextBox();
            this.tCambio = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tReferencia = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tObservacion = new System.Windows.Forms.TextBox();
            this.cbReferencia = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Total:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(35, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Su pago:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(35, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 29);
            this.label3.TabIndex = 4;
            this.label3.Text = "Cambio:";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(297, 465);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(151, 72);
            this.button1.TabIndex = 5;
            this.button1.Text = "Aceptar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tTotal
            // 
            this.tTotal.Enabled = false;
            this.tTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tTotal.Location = new System.Drawing.Point(194, 56);
            this.tTotal.Name = "tTotal";
            this.tTotal.Size = new System.Drawing.Size(254, 31);
            this.tTotal.TabIndex = 6;
            // 
            // tPago
            // 
            this.tPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tPago.Location = new System.Drawing.Point(194, 143);
            this.tPago.Name = "tPago";
            this.tPago.Size = new System.Drawing.Size(254, 31);
            this.tPago.TabIndex = 7;
            this.tPago.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tPago_KeyUp);
            // 
            // tCambio
            // 
            this.tCambio.Enabled = false;
            this.tCambio.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tCambio.Location = new System.Drawing.Point(194, 231);
            this.tCambio.Name = "tCambio";
            this.tCambio.Size = new System.Drawing.Size(254, 31);
            this.tCambio.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(36, 295);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Referencia:";
            // 
            // tReferencia
            // 
            this.tReferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tReferencia.Location = new System.Drawing.Point(159, 295);
            this.tReferencia.Name = "tReferencia";
            this.tReferencia.Size = new System.Drawing.Size(97, 22);
            this.tReferencia.TabIndex = 10;
            this.tReferencia.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(36, 375);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Observación:";
            // 
            // tObservacion
            // 
            this.tObservacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tObservacion.Location = new System.Drawing.Point(40, 398);
            this.tObservacion.Name = "tObservacion";
            this.tObservacion.Size = new System.Drawing.Size(408, 22);
            this.tObservacion.TabIndex = 12;
            // 
            // cbReferencia
            // 
            this.cbReferencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbReferencia.FormattingEnabled = true;
            this.cbReferencia.Items.AddRange(new object[] {
            "1-Efectivo",
            "2-Cheque nominativo",
            "3-Transferencia electrónica de fondos",
            "4-Tarjeta de crédito",
            "5-Monedero electrónico",
            "6-Dinero electrónico",
            "8-Vales de despensa",
            "12-Dación en pago",
            "13-Pago por subrogación",
            "14-Pago por consignación",
            "15-Condonación",
            "17-Compensación",
            "23-Novación",
            "24-Confusión",
            "25-Remisión de deuda",
            "26-Prescripción o caducidad",
            "27-A satisfacción del acreedor",
            "28-Tarjeta de débito",
            "29-Tarjeta de servicios",
            "30-Aplicación de anticipos",
            "31-Intermediario pagos",
            "99-Por definir"});
            this.cbReferencia.Location = new System.Drawing.Point(40, 327);
            this.cbReferencia.Name = "cbReferencia";
            this.cbReferencia.Size = new System.Drawing.Size(408, 21);
            this.cbReferencia.TabIndex = 13;
            // 
            // CalculaCambio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(480, 560);
            this.Controls.Add(this.cbReferencia);
            this.Controls.Add(this.tObservacion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tReferencia);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tCambio);
            this.Controls.Add(this.tPago);
            this.Controls.Add(this.tTotal);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CalculaCambio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cambio";
            this.Load += new System.EventHandler(this.CalculaCambio_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tTotal;
        private System.Windows.Forms.TextBox tPago;
        private System.Windows.Forms.TextBox tCambio;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox tReferencia;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox tObservacion;
        private System.Windows.Forms.ComboBox cbReferencia;
    }
}