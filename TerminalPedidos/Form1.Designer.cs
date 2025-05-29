namespace TerminalPedidos
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label6 = new AntdUI.Label();
            this.textBox1 = new AntdUI.Input();
            this.button6 = new AntdUI.Button();
            this.lCliente = new AntdUI.Label();
            this.button1 = new AntdUI.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.lSubtotal = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lIVA = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lTotal = new System.Windows.Forms.Label();
            this.bTerminar = new AntdUI.Button();
            this.cbConcepto = new AntdUI.Select();
            this.dataGridView1 = new AntdUI.Table();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new AntdUI.Label();
            this.tCodigo = new AntdUI.Input();
            this.button2 = new AntdUI.Button();
            this.tCantidad = new AntdUI.InputNumber();
            this.cbPrecio = new AntdUI.Select();
            this.tDescuento = new AntdUI.InputNumber();
            this.bDescuentos = new AntdUI.Button();
            this.tPrecio = new System.Windows.Forms.TextBox();
            this.cbAlmacen = new AntdUI.Select();
            this.label1 = new AntdUI.Label();
            this.cbAgente = new AntdUI.Select();
            this.button3 = new AntdUI.Button();
            this.pageHeader1 = new AntdUI.PageHeader();
            this.button5 = new AntdUI.Button();
            this.button4 = new AntdUI.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.pageHeader1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbConcepto, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 40);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1138, 543);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoSize = true;
            this.flowLayoutPanel2.Controls.Add(this.label6);
            this.flowLayoutPanel2.Controls.Add(this.textBox1);
            this.flowLayoutPanel2.Controls.Add(this.button6);
            this.flowLayoutPanel2.Controls.Add(this.lCliente);
            this.flowLayoutPanel2.Controls.Add(this.button1);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(904, 34);
            this.flowLayoutPanel2.TabIndex = 1;
            this.flowLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel2_Paint);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.label6.Location = new System.Drawing.Point(3, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 29);
            this.label6.TabIndex = 5;
            this.label6.Text = "Cliente:";
            // 
            // textBox1
            // 
            this.textBox1.BorderActive = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.textBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(233)))), ((int)(((byte)(211)))));
            this.textBox1.BorderHover = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.textBox1.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(86, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.textBox1.Size = new System.Drawing.Size(161, 29);
            this.textBox1.TabIndex = 6;
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // button6
            // 
            this.button6.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.button6.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button6.IconSvg = resources.GetString("button6.IconSvg");
            this.button6.Location = new System.Drawing.Point(253, 3);
            this.button6.Name = "button6";
            this.button6.Radius = 15;
            this.button6.Size = new System.Drawing.Size(75, 31);
            this.button6.TabIndex = 7;
            this.button6.Text = "F3";
            this.button6.Click += new System.EventHandler(this.button2_Click);
            // 
            // lCliente
            // 
            this.lCliente.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCliente.Location = new System.Drawing.Point(334, 3);
            this.lCliente.Name = "lCliente";
            this.lCliente.Size = new System.Drawing.Size(534, 37);
            this.lCliente.TabIndex = 8;
            this.lCliente.Text = "-";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.button1.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.button1.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(209)))), ((int)(((byte)(152)))));
            this.button1.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button1.IconSvg = resources.GetString("button1.IconSvg");
            this.button1.Location = new System.Drawing.Point(3, 46);
            this.button1.Name = "button1";
            this.button1.Radius = 15;
            this.button1.Size = new System.Drawing.Size(48, 29);
            this.button1.TabIndex = 23;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel3, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(913, 43);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(222, 497);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(216, 242);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.label3);
            this.flowLayoutPanel3.Controls.Add(this.lSubtotal);
            this.flowLayoutPanel3.Controls.Add(this.label5);
            this.flowLayoutPanel3.Controls.Add(this.lIVA);
            this.flowLayoutPanel3.Controls.Add(this.label7);
            this.flowLayoutPanel3.Controls.Add(this.lTotal);
            this.flowLayoutPanel3.Controls.Add(this.bTerminar);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 251);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(216, 243);
            this.flowLayoutPanel3.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 33);
            this.label3.TabIndex = 0;
            this.label3.Text = "Subtotal";
            this.label3.Visible = false;
            // 
            // lSubtotal
            // 
            this.lSubtotal.AutoSize = true;
            this.lSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lSubtotal.Location = new System.Drawing.Point(3, 33);
            this.lSubtotal.Name = "lSubtotal";
            this.lSubtotal.Size = new System.Drawing.Size(87, 33);
            this.lSubtotal.TabIndex = 1;
            this.lSubtotal.Text = "$0.00";
            this.lSubtotal.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 33);
            this.label5.TabIndex = 2;
            this.label5.Text = "I.V.A.";
            this.label5.Visible = false;
            // 
            // lIVA
            // 
            this.lIVA.AutoSize = true;
            this.lIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lIVA.Location = new System.Drawing.Point(3, 99);
            this.lIVA.Name = "lIVA";
            this.lIVA.Size = new System.Drawing.Size(87, 33);
            this.lIVA.TabIndex = 3;
            this.lIVA.Text = "$0.00";
            this.lIVA.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Poppins", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(92)))));
            this.label7.Location = new System.Drawing.Point(3, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 65);
            this.label7.TabIndex = 4;
            this.label7.Text = "Total";
            // 
            // lTotal
            // 
            this.lTotal.AutoSize = true;
            this.lTotal.Font = new System.Drawing.Font("Poppins", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(92)))));
            this.lTotal.Location = new System.Drawing.Point(138, 0);
            this.lTotal.Name = "lTotal";
            this.lTotal.Size = new System.Drawing.Size(128, 65);
            this.lTotal.TabIndex = 5;
            this.lTotal.Text = "$0.00";
            // 
            // bTerminar
            // 
            this.bTerminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.bTerminar.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.bTerminar.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.bTerminar.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bTerminar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bTerminar.IconSvg = resources.GetString("bTerminar.IconSvg");
            this.bTerminar.Location = new System.Drawing.Point(138, 68);
            this.bTerminar.Name = "bTerminar";
            this.bTerminar.Radius = 15;
            this.bTerminar.Size = new System.Drawing.Size(142, 29);
            this.bTerminar.TabIndex = 22;
            this.bTerminar.Text = "Terminar";
            this.bTerminar.Click += new System.EventHandler(this.bTerminar_Click);
            // 
            // cbConcepto
            // 
            this.cbConcepto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.cbConcepto.BorderActive = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.cbConcepto.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.cbConcepto.BorderHover = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.cbConcepto.CaretColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.cbConcepto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbConcepto.Font = new System.Drawing.Font("Poppins", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbConcepto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(92)))));
            this.cbConcepto.List = true;
            this.cbConcepto.ListAutoWidth = true;
            this.cbConcepto.Location = new System.Drawing.Point(913, 3);
            this.cbConcepto.Name = "cbConcepto";
            this.cbConcepto.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(107)))), ((int)(((byte)(104)))));
            this.cbConcepto.Size = new System.Drawing.Size(222, 34);
            this.cbConcepto.TabIndex = 9;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnBack = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(209)))), ((int)(((byte)(152)))));
            this.dataGridView1.ColumnFont = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.EmptyText = "Sin venta activa";
            this.dataGridView1.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridView1.Location = new System.Drawing.Point(3, 43);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Radius = 15;
            this.dataGridView1.RowHoverBg = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.dataGridView1.RowSelectedBg = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.dataGridView1.RowSelectedFore = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.dataGridView1.Size = new System.Drawing.Size(904, 497);
            this.dataGridView1.TabIndex = 10;
            this.dataGridView1.Text = "table1";
            this.dataGridView1.CellClick += new AntdUI.Table.ClickEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellButtonClick += new AntdUI.Table.ClickButtonEventHandler(this.dataGridView1_CellButtonClick);
            this.dataGridView1.CellDoubleClick += new AntdUI.Table.ClickEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.tCodigo);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Controls.Add(this.tCantidad);
            this.flowLayoutPanel1.Controls.Add(this.cbPrecio);
            this.flowLayoutPanel1.Controls.Add(this.tDescuento);
            this.flowLayoutPanel1.Controls.Add(this.bDescuentos);
            this.flowLayoutPanel1.Controls.Add(this.tPrecio);
            this.flowLayoutPanel1.Controls.Add(this.cbAlmacen);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.cbAgente);
            this.flowLayoutPanel1.Controls.Add(this.button3);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 583);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1138, 42);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 27);
            this.label2.TabIndex = 13;
            this.label2.Text = "Código:";
            // 
            // tCodigo
            // 
            this.tCodigo.BorderActive = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tCodigo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(233)))), ((int)(((byte)(211)))));
            this.tCodigo.BorderHover = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tCodigo.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tCodigo.Location = new System.Drawing.Point(89, 3);
            this.tCodigo.Name = "tCodigo";
            this.tCodigo.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tCodigo.Size = new System.Drawing.Size(130, 29);
            this.tCodigo.TabIndex = 14;
            this.tCodigo.TextChanged += new System.EventHandler(this.tcantidad_textchange);
            this.tCodigo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tCodigo_KeyUp);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.button2.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.button2.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.button2.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button2.IconSvg = resources.GetString("button2.IconSvg");
            this.button2.Location = new System.Drawing.Point(225, 3);
            this.button2.Name = "button2";
            this.button2.Radius = 15;
            this.button2.Size = new System.Drawing.Size(59, 29);
            this.button2.TabIndex = 17;
            this.button2.Text = "F3";
            this.button2.Click += new System.EventHandler(this.bF3_Click);
            // 
            // tCantidad
            // 
            this.tCantidad.BorderActive = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tCantidad.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(233)))), ((int)(((byte)(211)))));
            this.tCantidad.BorderHover = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tCantidad.DecimalPlaces = 2;
            this.tCantidad.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tCantidad.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.tCantidad.Location = new System.Drawing.Point(290, 3);
            this.tCantidad.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.tCantidad.Name = "tCantidad";
            this.tCantidad.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(233)))), ((int)(((byte)(211)))));
            this.tCantidad.Size = new System.Drawing.Size(75, 29);
            this.tCantidad.TabIndex = 15;
            this.tCantidad.Text = "1.00";
            this.tCantidad.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tCantidad.Enter += new System.EventHandler(this.tCantidad_Enter);
            this.tCantidad.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tCantidad_KeyUp);
            // 
            // cbPrecio
            // 
            this.cbPrecio.BorderActive = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.cbPrecio.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(233)))), ((int)(((byte)(211)))));
            this.cbPrecio.BorderHover = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.cbPrecio.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPrecio.ListAutoWidth = true;
            this.cbPrecio.Location = new System.Drawing.Point(371, 3);
            this.cbPrecio.Name = "cbPrecio";
            this.cbPrecio.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.cbPrecio.Size = new System.Drawing.Size(78, 29);
            this.cbPrecio.TabIndex = 16;
            this.cbPrecio.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbPrecio_KeyUp);
            this.cbPrecio.Leave += new System.EventHandler(this.cbPrecio_Leave);
            // 
            // tDescuento
            // 
            this.tDescuento.BorderActive = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tDescuento.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(233)))), ((int)(((byte)(211)))));
            this.tDescuento.BorderHover = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tDescuento.DecimalPlaces = 2;
            this.tDescuento.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tDescuento.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.tDescuento.Location = new System.Drawing.Point(455, 3);
            this.tDescuento.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.tDescuento.Minimum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tDescuento.Name = "tDescuento";
            this.tDescuento.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(233)))), ((int)(((byte)(211)))));
            this.tDescuento.Size = new System.Drawing.Size(75, 29);
            this.tDescuento.TabIndex = 22;
            this.tDescuento.Text = "0.00";
            this.tDescuento.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tDescuento_KeyUp);
            // 
            // bDescuentos
            // 
            this.bDescuentos.BackActive = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.bDescuentos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.bDescuentos.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.bDescuentos.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.bDescuentos.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bDescuentos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.bDescuentos.IconSvg = resources.GetString("bDescuentos.IconSvg");
            this.bDescuentos.Location = new System.Drawing.Point(536, 3);
            this.bDescuentos.Name = "bDescuentos";
            this.bDescuentos.Radius = 15;
            this.bDescuentos.Size = new System.Drawing.Size(36, 29);
            this.bDescuentos.TabIndex = 18;
            this.bDescuentos.Click += new System.EventHandler(this.button4_Click);
            // 
            // tPrecio
            // 
            this.tPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tPrecio.Location = new System.Drawing.Point(578, 3);
            this.tPrecio.Name = "tPrecio";
            this.tPrecio.Size = new System.Drawing.Size(27, 29);
            this.tPrecio.TabIndex = 2;
            this.tPrecio.Visible = false;
            this.tPrecio.Enter += new System.EventHandler(this.tPrecio_Enter);
            this.tPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tPrecio_KeyPress);
            this.tPrecio.Leave += new System.EventHandler(this.tPrecio_Leave);
            // 
            // cbAlmacen
            // 
            this.cbAlmacen.BorderActive = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.cbAlmacen.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(233)))), ((int)(((byte)(211)))));
            this.cbAlmacen.BorderHover = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.cbAlmacen.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAlmacen.List = true;
            this.cbAlmacen.ListAutoWidth = true;
            this.cbAlmacen.Location = new System.Drawing.Point(611, 3);
            this.cbAlmacen.Name = "cbAlmacen";
            this.cbAlmacen.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.cbAlmacen.Size = new System.Drawing.Size(130, 29);
            this.cbAlmacen.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.label1.Location = new System.Drawing.Point(747, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 29);
            this.label1.TabIndex = 20;
            this.label1.Text = "Agente:";
            // 
            // cbAgente
            // 
            this.cbAgente.BorderActive = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.cbAgente.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(233)))), ((int)(((byte)(211)))));
            this.cbAgente.BorderHover = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.cbAgente.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAgente.List = true;
            this.cbAgente.ListAutoWidth = true;
            this.cbAgente.Location = new System.Drawing.Point(828, 3);
            this.cbAgente.Name = "cbAgente";
            this.cbAgente.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.cbAgente.Size = new System.Drawing.Size(144, 29);
            this.cbAgente.TabIndex = 21;
            // 
            // button3
            // 
            this.button3.BackActive = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.button3.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.button3.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.button3.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button3.IconSvg = resources.GetString("button3.IconSvg");
            this.button3.Location = new System.Drawing.Point(978, 3);
            this.button3.Name = "button3";
            this.button3.Radius = 15;
            this.button3.Size = new System.Drawing.Size(36, 29);
            this.button3.TabIndex = 23;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pageHeader1
            // 
            this.pageHeader1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.pageHeader1.Controls.Add(this.button5);
            this.pageHeader1.Controls.Add(this.button4);
            this.pageHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pageHeader1.Font = new System.Drawing.Font("Poppins Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pageHeader1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.pageHeader1.Icon = ((System.Drawing.Image)(resources.GetObject("pageHeader1.Icon")));
            this.pageHeader1.Location = new System.Drawing.Point(0, 0);
            this.pageHeader1.Name = "pageHeader1";
            this.pageHeader1.ShowButton = true;
            this.pageHeader1.ShowIcon = true;
            this.pageHeader1.Size = new System.Drawing.Size(1138, 40);
            this.pageHeader1.TabIndex = 13;
            this.pageHeader1.Text = "PRISA Desktop";
            this.pageHeader1.UseSystemStyleColor = true;
            this.pageHeader1.Click += new System.EventHandler(this.pageHeader1_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(209)))), ((int)(((byte)(152)))));
            this.button5.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.button5.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button5.IconSvg = resources.GetString("button5.IconSvg");
            this.button5.Location = new System.Drawing.Point(448, 3);
            this.button5.Name = "button5";
            this.button5.Radius = 15;
            this.button5.Size = new System.Drawing.Size(134, 29);
            this.button5.TabIndex = 1;
            this.button5.Text = "Limpiar venta";
            this.button5.Click += new System.EventHandler(this.bLimpiar_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(209)))), ((int)(((byte)(152)))));
            this.button4.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(209)))), ((int)(((byte)(152)))));
            this.button4.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button4.IconSvg = resources.GetString("button4.IconSvg");
            this.button4.Location = new System.Drawing.Point(588, 3);
            this.button4.Name = "button4";
            this.button4.Radius = 15;
            this.button4.Size = new System.Drawing.Size(109, 29);
            this.button4.TabIndex = 0;
            this.button4.Text = "Historicos";
            this.button4.Click += new System.EventHandler(this.bReimprimir_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1138, 625);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pageHeader1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Terminal PDV";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.pageHeader1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lSubtotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lIVA;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lTotal;
        public System.Windows.Forms.TextBox tPrecio;
        private AntdUI.PageHeader pageHeader1;
        private AntdUI.Button button4;
        private AntdUI.Button button5;
        private AntdUI.Select cbConcepto;
        private AntdUI.Label label6;
        public AntdUI.Input textBox1;
        private AntdUI.Button button6;
        private AntdUI.Label lCliente;
        private AntdUI.Label label2;
        public AntdUI.Input tCodigo;
        private AntdUI.InputNumber tCantidad;
        public AntdUI.Select cbPrecio;
        private AntdUI.Button button2;
        private AntdUI.Button bDescuentos;
        private AntdUI.Select cbAlmacen;
        private AntdUI.Select cbAgente;
        private AntdUI.Button bTerminar;
        private AntdUI.Table dataGridView1;
        private AntdUI.Label label1;
        private AntdUI.Button button1;
        private AntdUI.InputNumber tDescuento;
        private AntdUI.Button button3;
    }
}

