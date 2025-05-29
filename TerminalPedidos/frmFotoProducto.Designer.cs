namespace TerminalPedidos
{
    partial class frmFotoProducto
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
            this.button5 = new AntdUI.Button();
            this.avatar1 = new AntdUI.Avatar();
            this.SuspendLayout();
            // 
            // button5
            // 
            this.button5.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.button5.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button5.IconPosition = AntdUI.TAlignMini.None;
            this.button5.IconRatio = 0F;
            this.button5.IconSvg = "";
            this.button5.Location = new System.Drawing.Point(12, 449);
            this.button5.Name = "button5";
            this.button5.Radius = 15;
            this.button5.Size = new System.Drawing.Size(476, 39);
            this.button5.TabIndex = 32;
            this.button5.Text = "Cerrar";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // avatar1
            // 
            this.avatar1.Location = new System.Drawing.Point(12, 12);
            this.avatar1.Name = "avatar1";
            this.avatar1.Round = true;
            this.avatar1.Shadow = 5;
            this.avatar1.Size = new System.Drawing.Size(476, 431);
            this.avatar1.TabIndex = 33;
            this.avatar1.Text = "";
            // 
            // frmFotoProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Controls.Add(this.avatar1);
            this.Controls.Add(this.button5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmFotoProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FotoProducto";
            this.Load += new System.EventHandler(this.frmFotoProducto_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.Button button5;
        private AntdUI.Avatar avatar1;
    }
}