namespace Gui
{
    partial class Manter_ficha_execucao_ed
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Manter_ficha_execucao_ed));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lb_usuario_ficha = new System.Windows.Forms.Label();
            this.lb_data_validade_ficha = new System.Windows.Forms.Label();
            this.lb_dt_criacao_ficha = new System.Windows.Forms.Label();
            this.lb_qtd_max_cal_ficha = new System.Windows.Forms.Label();
            this.lb_animal_ficha = new System.Windows.Forms.Label();
            this.lb_codigo_ficha = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lb_alimentos_permitidos = new System.Windows.Forms.Label();
            this.lb_montar_cardapio = new System.Windows.Forms.Label();
            this.lv_alimento = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.lv_cardapio = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.lb_total_calorias = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_quantidade = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_usuario_ficha);
            this.groupBox1.Controls.Add(this.lb_data_validade_ficha);
            this.groupBox1.Controls.Add(this.lb_dt_criacao_ficha);
            this.groupBox1.Controls.Add(this.lb_qtd_max_cal_ficha);
            this.groupBox1.Controls.Add(this.lb_animal_ficha);
            this.groupBox1.Controls.Add(this.lb_codigo_ficha);
            this.groupBox1.Location = new System.Drawing.Point(5, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(944, 95);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados da ficha";
            // 
            // lb_usuario_ficha
            // 
            this.lb_usuario_ficha.AutoSize = true;
            this.lb_usuario_ficha.Location = new System.Drawing.Point(438, 38);
            this.lb_usuario_ficha.Name = "lb_usuario_ficha";
            this.lb_usuario_ficha.Size = new System.Drawing.Size(94, 13);
            this.lb_usuario_ficha.TabIndex = 5;
            this.lb_usuario_ficha.Text = "Usuário que inclui:";
            // 
            // lb_data_validade_ficha
            // 
            this.lb_data_validade_ficha.AutoSize = true;
            this.lb_data_validade_ficha.Location = new System.Drawing.Point(438, 74);
            this.lb_data_validade_ficha.Name = "lb_data_validade_ficha";
            this.lb_data_validade_ficha.Size = new System.Drawing.Size(77, 13);
            this.lb_data_validade_ficha.TabIndex = 4;
            this.lb_data_validade_ficha.Text = "Data Validade:";
            // 
            // lb_dt_criacao_ficha
            // 
            this.lb_dt_criacao_ficha.AutoSize = true;
            this.lb_dt_criacao_ficha.Location = new System.Drawing.Point(6, 74);
            this.lb_dt_criacao_ficha.Name = "lb_dt_criacao_ficha";
            this.lb_dt_criacao_ficha.Size = new System.Drawing.Size(72, 13);
            this.lb_dt_criacao_ficha.TabIndex = 3;
            this.lb_dt_criacao_ficha.Text = "Data Criação:";
            // 
            // lb_qtd_max_cal_ficha
            // 
            this.lb_qtd_max_cal_ficha.AutoSize = true;
            this.lb_qtd_max_cal_ficha.Location = new System.Drawing.Point(6, 56);
            this.lb_qtd_max_cal_ficha.Name = "lb_qtd_max_cal_ficha";
            this.lb_qtd_max_cal_ficha.Size = new System.Drawing.Size(77, 13);
            this.lb_qtd_max_cal_ficha.TabIndex = 2;
            this.lb_qtd_max_cal_ficha.Text = "Qtd. Máx. Cal.:";
            // 
            // lb_animal_ficha
            // 
            this.lb_animal_ficha.AutoSize = true;
            this.lb_animal_ficha.Location = new System.Drawing.Point(6, 38);
            this.lb_animal_ficha.Name = "lb_animal_ficha";
            this.lb_animal_ficha.Size = new System.Drawing.Size(41, 13);
            this.lb_animal_ficha.TabIndex = 1;
            this.lb_animal_ficha.Text = "Animal:";
            // 
            // lb_codigo_ficha
            // 
            this.lb_codigo_ficha.AutoSize = true;
            this.lb_codigo_ficha.Location = new System.Drawing.Point(6, 21);
            this.lb_codigo_ficha.Name = "lb_codigo_ficha";
            this.lb_codigo_ficha.Size = new System.Drawing.Size(43, 13);
            this.lb_codigo_ficha.TabIndex = 0;
            this.lb_codigo_ficha.Text = "Código:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.lb_alimentos_permitidos);
            this.panel1.Controls.Add(this.lb_montar_cardapio);
            this.panel1.Location = new System.Drawing.Point(0, 98);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(953, 52);
            this.panel1.TabIndex = 6;
            // 
            // lb_alimentos_permitidos
            // 
            this.lb_alimentos_permitidos.AutoSize = true;
            this.lb_alimentos_permitidos.Location = new System.Drawing.Point(435, 30);
            this.lb_alimentos_permitidos.Name = "lb_alimentos_permitidos";
            this.lb_alimentos_permitidos.Size = new System.Drawing.Size(102, 13);
            this.lb_alimentos_permitidos.TabIndex = 18;
            this.lb_alimentos_permitidos.Text = "Alimentos permitidos";
            // 
            // lb_montar_cardapio
            // 
            this.lb_montar_cardapio.AutoSize = true;
            this.lb_montar_cardapio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold);
            this.lb_montar_cardapio.Location = new System.Drawing.Point(435, 8);
            this.lb_montar_cardapio.Name = "lb_montar_cardapio";
            this.lb_montar_cardapio.Size = new System.Drawing.Size(104, 17);
            this.lb_montar_cardapio.TabIndex = 0;
            this.lb_montar_cardapio.Text = "Montar Cesta";
            this.lb_montar_cardapio.Click += new System.EventHandler(this.label1_Click);
            // 
            // lv_alimento
            // 
            this.lv_alimento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lv_alimento.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lv_alimento.FullRowSelect = true;
            this.lv_alimento.Location = new System.Drawing.Point(-6, 150);
            this.lv_alimento.MultiSelect = false;
            this.lv_alimento.Name = "lv_alimento";
            this.lv_alimento.Size = new System.Drawing.Size(965, 170);
            this.lv_alimento.TabIndex = 7;
            this.lv_alimento.UseCompatibleStateImageBehavior = false;
            this.lv_alimento.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Código";
            this.columnHeader1.Width = 82;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Nome";
            this.columnHeader2.Width = 698;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Valor Calórico";
            this.columnHeader3.Width = 176;
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(-1, 320);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 58);
            this.button1.TabIndex = 12;
            this.button1.Text = "Adicionar no cardápio [F3]";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.Location = new System.Drawing.Point(95, 320);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(97, 58);
            this.button3.TabIndex = 13;
            this.button3.Text = "Excluir do cardápio [F4]";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lv_cardapio
            // 
            this.lv_cardapio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lv_cardapio.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.lv_cardapio.FullRowSelect = true;
            this.lv_cardapio.Location = new System.Drawing.Point(0, 378);
            this.lv_cardapio.MultiSelect = false;
            this.lv_cardapio.Name = "lv_cardapio";
            this.lv_cardapio.Size = new System.Drawing.Size(953, 201);
            this.lv_cardapio.TabIndex = 14;
            this.lv_cardapio.UseCompatibleStateImageBehavior = false;
            this.lv_cardapio.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Código";
            this.columnHeader5.Width = 82;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Nome";
            this.columnHeader6.Width = 575;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Valor Calórico";
            this.columnHeader7.Width = 176;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Quantidade";
            this.columnHeader8.Width = 128;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.Location = new System.Drawing.Point(478, 661);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 48);
            this.button2.TabIndex = 17;
            this.button2.Text = "Cancelar [F9]";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button4.Location = new System.Drawing.Point(382, 661);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(97, 48);
            this.button4.TabIndex = 16;
            this.button4.Text = "Executar [F8]";
            this.button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // lb_total_calorias
            // 
            this.lb_total_calorias.AutoSize = true;
            this.lb_total_calorias.Location = new System.Drawing.Point(654, 604);
            this.lb_total_calorias.Name = "lb_total_calorias";
            this.lb_total_calorias.Size = new System.Drawing.Size(178, 13);
            this.lb_total_calorias.TabIndex = 18;
            this.lb_total_calorias.Text = "Quantidade de calórias do cardápio:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(648, 591);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(301, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "---------------------------------------------------------------------------------" +
    "-----------------";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(781, 343);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Quantidade:";
            // 
            // tb_quantidade
            // 
            this.tb_quantidade.Location = new System.Drawing.Point(852, 340);
            this.tb_quantidade.Name = "tb_quantidade";
            this.tb_quantidade.Size = new System.Drawing.Size(100, 20);
            this.tb_quantidade.TabIndex = 22;
            this.tb_quantidade.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_quantidade_KeyPress);
            // 
            // 
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 581);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Observação:";
            // 
            // Manter_ficha_execucao_ed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 715);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_quantidade);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_total_calorias);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.lv_cardapio);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lv_alimento);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Manter_ficha_execucao_ed";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Executando ficha";
            this.Load += new System.EventHandler(this.Manter_ficha_execucao_ed_Load);
            this.Resize += new System.EventHandler(this.Manter_ficha_execucao_ed_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lb_codigo_ficha;
        private System.Windows.Forms.Label lb_dt_criacao_ficha;
        private System.Windows.Forms.Label lb_qtd_max_cal_ficha;
        private System.Windows.Forms.Label lb_animal_ficha;
        private System.Windows.Forms.Label lb_data_validade_ficha;
        private System.Windows.Forms.Label lb_usuario_ficha;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lb_montar_cardapio;
        private System.Windows.Forms.ListView lv_alimento;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListView lv_cardapio;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lb_alimentos_permitidos;
        private System.Windows.Forms.Label lb_total_calorias;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_quantidade;
        private System.Windows.Forms.Label label1;
    }
}