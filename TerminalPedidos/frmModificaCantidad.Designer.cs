namespace TerminalPedidos
{
    partial class frmModificaCantidad
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
            this.tCantidad = new AntdUI.InputNumber();
            this.SuspendLayout();
            // 
            // tCantidad
            // 
            this.tCantidad.BorderActive = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tCantidad.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(233)))), ((int)(((byte)(211)))));
            this.tCantidad.BorderHover = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tCantidad.DecimalPlaces = 2;
            this.tCantidad.Font = new System.Drawing.Font("Poppins", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tCantidad.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.tCantidad.Location = new System.Drawing.Point(12, 12);
            this.tCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.tCantidad.Name = "tCantidad";
            this.tCantidad.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(233)))), ((int)(((byte)(211)))));
            this.tCantidad.Size = new System.Drawing.Size(153, 62);
            this.tCantidad.TabIndex = 16;
            this.tCantidad.Text = "1.00";
            this.tCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tCantidad.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tCantidad_KeyUp);
            // 
            // frmModificaCantidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(176, 86);
            this.Controls.Add(this.tCantidad);
            this.Name = "frmModificaCantidad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmModificaCantidad";
            this.Load += new System.EventHandler(this.frmModificaCantidad_Load);
            this.Shown += new System.EventHandler(this.frmModificaCantidad_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.InputNumber tCantidad;
    }
}