namespace TerminalPedidos
{
    partial class frmClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClientes));
            AntdUI.Tabs.StyleCard styleCard1 = new AntdUI.Tabs.StyleCard();
            this.pageHeader1 = new AntdUI.PageHeader();
            this.button2 = new AntdUI.Button();
            this.tabs1 = new AntdUI.Tabs();
            this.tabPage1 = new AntdUI.TabPage();
            this.cbFormaPago = new AntdUI.Select();
            this.label15 = new AntdUI.Label();
            this.cbUsodecfdi = new AntdUI.Select();
            this.label5 = new AntdUI.Label();
            this.cbRegimenfiscal = new AntdUI.Select();
            this.label4 = new AntdUI.Label();
            this.label2 = new AntdUI.Label();
            this.tRfc = new AntdUI.Input();
            this.label1 = new AntdUI.Label();
            this.tRazonsocial = new AntdUI.Input();
            this.label6 = new AntdUI.Label();
            this.tCodigo = new AntdUI.Input();
            this.tabPage2 = new AntdUI.TabPage();
            this.label3 = new AntdUI.Label();
            this.tCodigopostal = new AntdUI.Input();
            this.tPais = new AntdUI.Input();
            this.label14 = new AntdUI.Label();
            this.tCiudad = new AntdUI.Input();
            this.label13 = new AntdUI.Label();
            this.tMunicipio = new AntdUI.Input();
            this.label12 = new AntdUI.Label();
            this.tNumExt = new AntdUI.Input();
            this.label7 = new AntdUI.Label();
            this.label8 = new AntdUI.Label();
            this.tEstado = new AntdUI.Input();
            this.label9 = new AntdUI.Label();
            this.tColonia = new AntdUI.Input();
            this.label10 = new AntdUI.Label();
            this.tCalle = new AntdUI.Input();
            this.label11 = new AntdUI.Label();
            this.tNumInt = new AntdUI.Input();
            this.divider1 = new AntdUI.Divider();
            this.tabs1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pageHeader1
            // 
            this.pageHeader1.DividerColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.pageHeader1.DividerShow = true;
            this.pageHeader1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pageHeader1.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pageHeader1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.pageHeader1.IconSvg = resources.GetString("pageHeader1.IconSvg");
            this.pageHeader1.Location = new System.Drawing.Point(0, 0);
            this.pageHeader1.Name = "pageHeader1";
            this.pageHeader1.ShowBack = true;
            this.pageHeader1.ShowIcon = true;
            this.pageHeader1.Size = new System.Drawing.Size(810, 49);
            this.pageHeader1.TabIndex = 6;
            this.pageHeader1.Text = "Cliente";
            this.pageHeader1.UseSystemStyleColor = true;
            this.pageHeader1.BackClick += new System.EventHandler(this.pageHeader1_BackClick);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.button2.BackHover = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.button2.DefaultBack = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.button2.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button2.IconSvg = resources.GetString("button2.IconSvg");
            this.button2.Location = new System.Drawing.Point(633, 365);
            this.button2.Name = "button2";
            this.button2.Radius = 15;
            this.button2.Size = new System.Drawing.Size(159, 43);
            this.button2.TabIndex = 19;
            this.button2.Text = "Aceptar";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabs1
            // 
            this.tabs1.Controls.Add(this.tabPage1);
            this.tabs1.Controls.Add(this.tabPage2);
            this.tabs1.Cursor = System.Windows.Forms.Cursors.Default;
            this.tabs1.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabs1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tabs1.Location = new System.Drawing.Point(12, 55);
            this.tabs1.Name = "tabs1";
            this.tabs1.Pages.Add(this.tabPage1);
            this.tabs1.Pages.Add(this.tabPage2);
            this.tabs1.Size = new System.Drawing.Size(786, 274);
            this.tabs1.Style = styleCard1;
            this.tabs1.TabIndex = 24;
            this.tabs1.Text = "tabs1";
            this.tabs1.Type = AntdUI.TabType.Card;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbFormaPago);
            this.tabPage1.Controls.Add(this.label15);
            this.tabPage1.Controls.Add(this.cbUsodecfdi);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.cbRegimenfiscal);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.tRfc);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.tRazonsocial);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.tCodigo);
            this.tabPage1.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tabPage1.Location = new System.Drawing.Point(3, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(780, 243);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            // 
            // cbFormaPago
            // 
            this.cbFormaPago.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.cbFormaPago.BorderActive = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.cbFormaPago.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.cbFormaPago.BorderHover = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.cbFormaPago.CaretColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.cbFormaPago.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFormaPago.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(92)))));
            this.cbFormaPago.Items.AddRange(new object[] {
            "01 - Efectivo",
            "02 - Cheque nominativo",
            "03 - Transferencia electrónica de fondos",
            "04 - Tarjeta de crédito",
            "05 - Monedero electrónico",
            "06 - Dinero electrónico",
            "08 - Vales de despensa",
            "12 - Dación en pago",
            "13 - Pago por subrogación",
            "14 - Pago por consignación",
            "15 - Condonación",
            "17 - Compensación",
            "23 - Novación",
            "24 - Confusión",
            "25 - Remisión de deuda",
            "26 - Prescripción o caducidad",
            "27 - A satisfacción del acreedor",
            "28 - Tarjeta de débito",
            "29 - Tarjeta de servicios",
            "30 - Aplicación de anticipos",
            "31 - Intermediario de pagos",
            "99 - Por definir"});
            this.cbFormaPago.List = true;
            this.cbFormaPago.ListAutoWidth = true;
            this.cbFormaPago.Location = new System.Drawing.Point(452, 123);
            this.cbFormaPago.Name = "cbFormaPago";
            this.cbFormaPago.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(107)))), ((int)(((byte)(104)))));
            this.cbFormaPago.Size = new System.Drawing.Size(325, 35);
            this.cbFormaPago.TabIndex = 35;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.label15.Location = new System.Drawing.Point(452, 87);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(171, 29);
            this.label15.TabIndex = 36;
            this.label15.Text = "Forma de pago*";
            // 
            // cbUsodecfdi
            // 
            this.cbUsodecfdi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.cbUsodecfdi.BorderActive = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.cbUsodecfdi.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.cbUsodecfdi.BorderHover = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.cbUsodecfdi.CaretColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.cbUsodecfdi.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbUsodecfdi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(92)))));
            this.cbUsodecfdi.Items.AddRange(new object[] {
            "G01 - Adquisición de mercancías",
            "G02 - Devoluciones, descuentos o bonificaciones",
            "G03 - Gastos en general",
            "I01 - Construcciones",
            "I02 - Mobiliario y equipo de oficina por inversiones",
            "I03 - Equipo de transporte",
            "I04 - Equipo de cómputo y accesorios",
            "I05 - Dados, troqueles, moldes, matrices y herramental",
            "I06 - Comunicaciones telefónicas",
            "I07 - Comunicaciones satelitales",
            "I08 - Otra maquinaria y equipo",
            "D01 - Honorarios médicos, dentales y gastos hospitalarios",
            "D02 - Gastos médicos por incapacidad o discapacidad",
            "D03 - Gastos funerales",
            "D04 - Donativos",
            "D05 - Intereses reales pagados por créditos hipotecarios",
            "D06 - Aportaciones voluntarias al SAR",
            "D07 - Primas por seguros de gastos médicos",
            "D08 - Gastos de transportación escolar obligatoria",
            "D09 - Depósitos en cuentas para el ahorro, primas que tengan como base planes de " +
                "pensiones",
            "D10 - Pagos por servicios educativos (colegiaturas)",
            "S01 - Sin efectos fiscales",
            "CP01 - Pagos",
            "CN01 - Nómina"});
            this.cbUsodecfdi.List = true;
            this.cbUsodecfdi.ListAutoWidth = true;
            this.cbUsodecfdi.Location = new System.Drawing.Point(452, 205);
            this.cbUsodecfdi.Name = "cbUsodecfdi";
            this.cbUsodecfdi.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(107)))), ((int)(((byte)(104)))));
            this.cbUsodecfdi.Size = new System.Drawing.Size(325, 35);
            this.cbUsodecfdi.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.label5.Location = new System.Drawing.Point(452, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(171, 29);
            this.label5.TabIndex = 34;
            this.label5.Text = "Uso de cfdi*";
            // 
            // cbRegimenfiscal
            // 
            this.cbRegimenfiscal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.cbRegimenfiscal.BorderActive = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.cbRegimenfiscal.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.cbRegimenfiscal.BorderHover = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.cbRegimenfiscal.CaretColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.cbRegimenfiscal.Font = new System.Drawing.Font("Poppins", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRegimenfiscal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(94)))), ((int)(((byte)(92)))));
            this.cbRegimenfiscal.Items.AddRange(new object[] {
            "601 - General de Ley Personas Morales",
            "603 - Personas Morales con Fines no Lucrativos",
            "605 - Sueldos y Salarios e Ingresos Asimilados a Salarios",
            "606 - Arrendamiento",
            "607 - Régimen de Enajenación o Adquisición de Bienes",
            "608 - Demás ingresos",
            "610 - Residentes en el Extranjero sin Establecimiento Permanente en México",
            "611 - Ingresos por Dividendos (socios y accionistas)",
            "612 - Personas Físicas con Actividades Empresariales y Profesionales",
            "614 - Ingresos por intereses",
            "615 - Régimen de los ingresos por obtención de premios",
            "616 - Sin obligaciones fiscales",
            "620 - Sociedades Cooperativas de Producción que optan por diferir sus ingresos",
            "621 - Incorporación Fiscal",
            "622 - Actividades Agrícolas, Ganaderas, Silvícolas y Pesqueras",
            "623 - Opcional para Grupos de Sociedades",
            "624 - Coordinados",
            "625 - Régimen de las Actividades Empresariales con ingresos a través de Plataform" +
                "as Tecnológicas",
            "626 - Régimen Simplificado de Confianza",
            "628 - Hidrocarburos",
            "629 - De los Regímenes Fiscales Preferentes y de las Empresas Multinacionales",
            "630 - Enajenación de acciones en bolsa de valores"});
            this.cbRegimenfiscal.List = true;
            this.cbRegimenfiscal.ListAutoWidth = true;
            this.cbRegimenfiscal.Location = new System.Drawing.Point(9, 205);
            this.cbRegimenfiscal.Name = "cbRegimenfiscal";
            this.cbRegimenfiscal.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(107)))), ((int)(((byte)(104)))));
            this.cbRegimenfiscal.Size = new System.Drawing.Size(437, 35);
            this.cbRegimenfiscal.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.label4.Location = new System.Drawing.Point(9, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 29);
            this.label4.TabIndex = 32;
            this.label4.Text = "Régimen fiscal*";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.label2.Location = new System.Drawing.Point(9, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 29);
            this.label2.TabIndex = 28;
            this.label2.Text = "RFC*";
            // 
            // tRfc
            // 
            this.tRfc.BorderActive = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tRfc.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(233)))), ((int)(((byte)(211)))));
            this.tRfc.BorderHover = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tRfc.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tRfc.Location = new System.Drawing.Point(9, 123);
            this.tRfc.Name = "tRfc";
            this.tRfc.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tRfc.Size = new System.Drawing.Size(203, 35);
            this.tRfc.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.label1.Location = new System.Drawing.Point(218, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 29);
            this.label1.TabIndex = 26;
            this.label1.Text = "Razon social*";
            // 
            // tRazonsocial
            // 
            this.tRazonsocial.BorderActive = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tRazonsocial.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(233)))), ((int)(((byte)(211)))));
            this.tRazonsocial.BorderHover = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tRazonsocial.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tRazonsocial.Location = new System.Drawing.Point(218, 44);
            this.tRazonsocial.Name = "tRazonsocial";
            this.tRazonsocial.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tRazonsocial.Size = new System.Drawing.Size(559, 35);
            this.tRazonsocial.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.label6.Location = new System.Drawing.Point(9, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 29);
            this.label6.TabIndex = 24;
            this.label6.Text = "Codigo*";
            // 
            // tCodigo
            // 
            this.tCodigo.BorderActive = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tCodigo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(233)))), ((int)(((byte)(211)))));
            this.tCodigo.BorderHover = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tCodigo.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tCodigo.Location = new System.Drawing.Point(9, 44);
            this.tCodigo.Name = "tCodigo";
            this.tCodigo.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tCodigo.Size = new System.Drawing.Size(203, 35);
            this.tCodigo.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.tCodigopostal);
            this.tabPage2.Controls.Add(this.tPais);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.tCiudad);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.tMunicipio);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.tNumExt);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.tEstado);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.tColonia);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.tCalle);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.tNumInt);
            this.tabPage2.Font = new System.Drawing.Font("Poppins", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(0, 0);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Domicilio fiscal";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.label3.Location = new System.Drawing.Point(427, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 29);
            this.label3.TabIndex = 51;
            this.label3.Text = "Codigo postal*";
            // 
            // tCodigopostal
            // 
            this.tCodigopostal.BorderActive = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tCodigopostal.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(233)))), ((int)(((byte)(211)))));
            this.tCodigopostal.BorderHover = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tCodigopostal.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tCodigopostal.Location = new System.Drawing.Point(427, 207);
            this.tCodigopostal.Name = "tCodigopostal";
            this.tCodigopostal.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tCodigopostal.Size = new System.Drawing.Size(203, 35);
            this.tCodigopostal.TabIndex = 14;
            // 
            // tPais
            // 
            this.tPais.BorderActive = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tPais.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(233)))), ((int)(((byte)(211)))));
            this.tPais.BorderHover = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tPais.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tPais.Location = new System.Drawing.Point(218, 207);
            this.tPais.Name = "tPais";
            this.tPais.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tPais.Size = new System.Drawing.Size(203, 35);
            this.tPais.TabIndex = 13;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.label14.Location = new System.Drawing.Point(218, 172);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(171, 29);
            this.label14.TabIndex = 49;
            this.label14.Text = "Pais*";
            // 
            // tCiudad
            // 
            this.tCiudad.BorderActive = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tCiudad.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(233)))), ((int)(((byte)(211)))));
            this.tCiudad.BorderHover = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tCiudad.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tCiudad.Location = new System.Drawing.Point(427, 121);
            this.tCiudad.Name = "tCiudad";
            this.tCiudad.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tCiudad.Size = new System.Drawing.Size(203, 35);
            this.tCiudad.TabIndex = 11;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.label13.Location = new System.Drawing.Point(427, 86);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(171, 29);
            this.label13.TabIndex = 47;
            this.label13.Text = "Ciudad*";
            // 
            // tMunicipio
            // 
            this.tMunicipio.BorderActive = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tMunicipio.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(233)))), ((int)(((byte)(211)))));
            this.tMunicipio.BorderHover = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tMunicipio.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tMunicipio.Location = new System.Drawing.Point(218, 121);
            this.tMunicipio.Name = "tMunicipio";
            this.tMunicipio.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tMunicipio.Size = new System.Drawing.Size(203, 35);
            this.tMunicipio.TabIndex = 10;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.label12.Location = new System.Drawing.Point(493, 8);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(105, 29);
            this.label12.TabIndex = 44;
            this.label12.Text = "Num Ext*";
            // 
            // tNumExt
            // 
            this.tNumExt.BorderActive = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tNumExt.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(233)))), ((int)(((byte)(211)))));
            this.tNumExt.BorderHover = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tNumExt.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tNumExt.Location = new System.Drawing.Point(493, 43);
            this.tNumExt.Name = "tNumExt";
            this.tNumExt.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tNumExt.Size = new System.Drawing.Size(109, 35);
            this.tNumExt.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.label7.Location = new System.Drawing.Point(218, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(171, 29);
            this.label7.TabIndex = 42;
            this.label7.Text = "Municipio*";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.label8.Location = new System.Drawing.Point(9, 171);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(171, 29);
            this.label8.TabIndex = 40;
            this.label8.Text = "Estado*";
            // 
            // tEstado
            // 
            this.tEstado.BorderActive = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tEstado.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(233)))), ((int)(((byte)(211)))));
            this.tEstado.BorderHover = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tEstado.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tEstado.Location = new System.Drawing.Point(9, 207);
            this.tEstado.Name = "tEstado";
            this.tEstado.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tEstado.Size = new System.Drawing.Size(203, 35);
            this.tEstado.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.label9.Location = new System.Drawing.Point(9, 86);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(171, 29);
            this.label9.TabIndex = 38;
            this.label9.Text = "Colonia*";
            // 
            // tColonia
            // 
            this.tColonia.BorderActive = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tColonia.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(233)))), ((int)(((byte)(211)))));
            this.tColonia.BorderHover = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tColonia.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tColonia.Location = new System.Drawing.Point(9, 121);
            this.tColonia.Name = "tColonia";
            this.tColonia.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tColonia.Size = new System.Drawing.Size(203, 35);
            this.tColonia.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.label10.Location = new System.Drawing.Point(9, 8);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(171, 29);
            this.label10.TabIndex = 36;
            this.label10.Text = "Calle*";
            // 
            // tCalle
            // 
            this.tCalle.BorderActive = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tCalle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(233)))), ((int)(((byte)(211)))));
            this.tCalle.BorderHover = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tCalle.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tCalle.Location = new System.Drawing.Point(9, 43);
            this.tCalle.Name = "tCalle";
            this.tCalle.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tCalle.Size = new System.Drawing.Size(358, 35);
            this.tCalle.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Poppins SemiBold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.label11.Location = new System.Drawing.Point(378, 8);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 29);
            this.label11.TabIndex = 34;
            this.label11.Text = "Num Int";
            // 
            // tNumInt
            // 
            this.tNumInt.BorderActive = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tNumInt.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(233)))), ((int)(((byte)(211)))));
            this.tNumInt.BorderHover = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tNumInt.Font = new System.Drawing.Font("Poppins", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tNumInt.Location = new System.Drawing.Point(378, 43);
            this.tNumInt.Name = "tNumInt";
            this.tNumInt.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(96)))), ((int)(((byte)(93)))));
            this.tNumInt.Size = new System.Drawing.Size(109, 35);
            this.tNumInt.TabIndex = 7;
            // 
            // divider1
            // 
            this.divider1.Location = new System.Drawing.Point(12, 345);
            this.divider1.Name = "divider1";
            this.divider1.Size = new System.Drawing.Size(783, 23);
            this.divider1.TabIndex = 25;
            this.divider1.Text = "";
            // 
            // frmClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 413);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.divider1);
            this.Controls.Add(this.tabs1);
            this.Controls.Add(this.pageHeader1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmClientes";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clientes";
            this.Load += new System.EventHandler(this.frmClientes_Load);
            this.tabs1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.PageHeader pageHeader1;
        private AntdUI.Button button2;
        private AntdUI.Tabs tabs1;
        private AntdUI.TabPage tabPage1;
        private AntdUI.Select cbUsodecfdi;
        private AntdUI.Label label5;
        private AntdUI.Select cbRegimenfiscal;
        private AntdUI.Label label4;
        private AntdUI.Label label2;
        public AntdUI.Input tRfc;
        private AntdUI.Label label1;
        public AntdUI.Input tRazonsocial;
        private AntdUI.Label label6;
        public AntdUI.Input tCodigo;
        private AntdUI.TabPage tabPage2;
        private AntdUI.Label label7;
        private AntdUI.Label label8;
        public AntdUI.Input tEstado;
        private AntdUI.Label label9;
        public AntdUI.Input tColonia;
        private AntdUI.Label label10;
        public AntdUI.Input tCalle;
        private AntdUI.Label label11;
        public AntdUI.Input tNumInt;
        private AntdUI.Label label12;
        public AntdUI.Input tNumExt;
        public AntdUI.Input tMunicipio;
        public AntdUI.Input tCiudad;
        private AntdUI.Label label13;
        public AntdUI.Input tPais;
        private AntdUI.Label label14;
        private AntdUI.Label label3;
        public AntdUI.Input tCodigopostal;
        private AntdUI.Select cbFormaPago;
        private AntdUI.Label label15;
        private AntdUI.Divider divider1;
    }
}