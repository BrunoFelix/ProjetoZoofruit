namespace Gui
{
    partial class Manter_ficha_alimento_ed
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Manter_ficha_alimento_ed));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tb_hora_a_ser_executada = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_qtd_max_cal = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_descricao = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_validade = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lv_alimento = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btn_novo_animal = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_hora_a_ser_executada);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tb_qtd_max_cal);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tb_descricao);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtp_validade);
            this.groupBox1.Location = new System.Drawing.Point(4, -1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(622, 101);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados do animal";
            // 
            // tb_hora_a_ser_executada
            // 
            this.tb_hora_a_ser_executada.Location = new System.Drawing.Point(353, 46);
            this.tb_hora_a_ser_executada.Name = "tb_hora_a_ser_executada";
            this.tb_hora_a_ser_executada.Size = new System.Drawing.Size(33, 20);
            this.tb_hora_a_ser_executada.TabIndex = 39;
            this.tb_hora_a_ser_executada.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_hora_a_ser_executada_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(202, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Hora que deve ser exeutada:";
            // 
            // tb_qtd_max_cal
            // 
            this.tb_qtd_max_cal.Location = new System.Drawing.Point(165, 72);
            this.tb_qtd_max_cal.Name = "tb_qtd_max_cal";
            this.tb_qtd_max_cal.Size = new System.Drawing.Size(136, 20);
            this.tb_qtd_max_cal.TabIndex = 2;
            this.tb_qtd_max_cal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_qtd_max_cal_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Quantidade Máxima Calórias:";
            // 
            // tb_descricao
            // 
            this.tb_descricao.Location = new System.Drawing.Point(101, 20);
            this.tb_descricao.Name = "tb_descricao";
            this.tb_descricao.Size = new System.Drawing.Size(515, 20);
            this.tb_descricao.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 35;
            this.label2.Text = "Descrição:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Data Validade:";
            // 
            // dtp_validade
            // 
            this.dtp_validade.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_validade.Location = new System.Drawing.Point(101, 46);
            this.dtp_validade.Name = "dtp_validade";
            this.dtp_validade.Size = new System.Drawing.Size(93, 20);
            this.dtp_validade.TabIndex = 1;
            this.dtp_validade.Value = new System.DateTime(2016, 11, 12, 0, 0, 0, 0);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.Location = new System.Drawing.Point(315, 463);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 48);
            this.button2.TabIndex = 7;
            this.button2.Text = "Cancelar [F9]";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(219, 463);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 48);
            this.button1.TabIndex = 6;
            this.button1.Text = "Confirmar [F8]";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lv_alimento
            // 
            this.lv_alimento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lv_alimento.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lv_alimento.FullRowSelect = true;
            this.lv_alimento.Location = new System.Drawing.Point(4, 147);
            this.lv_alimento.MultiSelect = false;
            this.lv_alimento.Name = "lv_alimento";
            this.lv_alimento.Size = new System.Drawing.Size(628, 311);
            this.lv_alimento.TabIndex = 5;
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
            this.columnHeader2.Width = 362;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Valor Calórico";
            this.columnHeader3.Width = 179;
            // 
            // btn_novo_animal
            // 
            this.btn_novo_animal.Image = ((System.Drawing.Image)(resources.GetObject("btn_novo_animal.Image")));
            this.btn_novo_animal.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_novo_animal.Location = new System.Drawing.Point(4, 99);
            this.btn_novo_animal.Name = "btn_novo_animal";
            this.btn_novo_animal.Size = new System.Drawing.Size(97, 48);
            this.btn_novo_animal.TabIndex = 3;
            this.btn_novo_animal.Text = "Adicionar";
            this.btn_novo_animal.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_novo_animal.UseVisualStyleBackColor = true;
            this.btn_novo_animal.Click += new System.EventHandler(this.btn_novo_animal_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button4
            // 
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button4.Location = new System.Drawing.Point(101, 99);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(97, 48);
            this.button4.TabIndex = 4;
            this.button4.Text = "Remover";
            this.button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Manter_ficha_alimento_ed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 516);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btn_novo_animal);
            this.Controls.Add(this.lv_alimento);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Manter_ficha_alimento_ed";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ficha";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Manter_ficha_alimento_ed_FormClosing);
            this.Load += new System.EventHandler(this.Manter_ficha_alimento_ed_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tb_descricao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_validade;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tb_qtd_max_cal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lv_alimento;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button btn_novo_animal;
        private System.Windows.Forms.TextBox tb_hora_a_ser_executada;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button4;
    }
}