namespace Gui
{
    partial class Manter_ficha
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Manter_ficha));
            this.lv_animal = new System.Windows.Forms.ListView();
            this.listView2 = new System.Windows.Forms.ListView();
            this.listView3 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btn_alterar_animal = new System.Windows.Forms.Button();
            this.btn_novo_animal = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button10 = new System.Windows.Forms.Button();
            this.btn_pesquisar_animal = new System.Windows.Forms.Button();
            this.tb_pesquisar = new System.Windows.Forms.TextBox();
            this.comboBox_pesquisar_animal = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Código = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Nome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cor = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Porte = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Peso = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tipo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lv_animal
            // 
            this.lv_animal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lv_animal.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Código,
            this.Nome,
            this.Cor,
            this.Porte,
            this.Peso,
            this.Tipo});
            this.lv_animal.FullRowSelect = true;
            this.lv_animal.Location = new System.Drawing.Point(-1, 47);
            this.lv_animal.MultiSelect = false;
            this.lv_animal.Name = "lv_animal";
            this.lv_animal.Size = new System.Drawing.Size(1245, 328);
            this.lv_animal.TabIndex = 0;
            this.lv_animal.UseCompatibleStateImageBehavior = false;
            this.lv_animal.View = System.Windows.Forms.View.Details;
            // 
            // listView2
            // 
            this.listView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView2.Location = new System.Drawing.Point(0, 421);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(1247, 203);
            this.listView2.TabIndex = 1;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // listView3
            // 
            this.listView3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView3.Location = new System.Drawing.Point(0, 670);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(1245, 174);
            this.listView3.TabIndex = 2;
            this.listView3.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(605, 389);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ficha(s)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(597, 639);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Alimento(s)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(605, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Animal";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button3
            // 
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.Location = new System.Drawing.Point(192, 374);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(97, 48);
            this.button3.TabIndex = 12;
            this.button3.Text = "Excluir [F4]";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.Location = new System.Drawing.Point(96, 374);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 48);
            this.button2.TabIndex = 11;
            this.button2.Text = "Alterar [F4]";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(0, 374);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 48);
            this.button1.TabIndex = 10;
            this.button1.Text = "Novo [F3]";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button4.Location = new System.Drawing.Point(192, 0);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(97, 48);
            this.button4.TabIndex = 15;
            this.button4.Text = "Excluir [F4]";
            this.button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // btn_alterar_animal
            // 
            this.btn_alterar_animal.Image = ((System.Drawing.Image)(resources.GetObject("btn_alterar_animal.Image")));
            this.btn_alterar_animal.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_alterar_animal.Location = new System.Drawing.Point(96, 0);
            this.btn_alterar_animal.Name = "btn_alterar_animal";
            this.btn_alterar_animal.Size = new System.Drawing.Size(97, 48);
            this.btn_alterar_animal.TabIndex = 14;
            this.btn_alterar_animal.Text = "Alterar [F4]";
            this.btn_alterar_animal.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_alterar_animal.UseVisualStyleBackColor = true;
            this.btn_alterar_animal.Click += new System.EventHandler(this.button5_Click);
            // 
            // btn_novo_animal
            // 
            this.btn_novo_animal.Image = ((System.Drawing.Image)(resources.GetObject("btn_novo_animal.Image")));
            this.btn_novo_animal.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_novo_animal.Location = new System.Drawing.Point(0, 0);
            this.btn_novo_animal.Name = "btn_novo_animal";
            this.btn_novo_animal.Size = new System.Drawing.Size(97, 48);
            this.btn_novo_animal.TabIndex = 13;
            this.btn_novo_animal.Text = "Novo [cF3]";
            this.btn_novo_animal.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_novo_animal.UseVisualStyleBackColor = true;
            this.btn_novo_animal.Click += new System.EventHandler(this.btn_novo_animal_Click);
            // 
            // button9
            // 
            this.button9.Image = ((System.Drawing.Image)(resources.GetObject("button9.Image")));
            this.button9.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button9.Location = new System.Drawing.Point(0, 623);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(97, 48);
            this.button9.TabIndex = 16;
            this.button9.Text = "Adicionar [F3]";
            this.button9.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
            this.button7.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button7.Location = new System.Drawing.Point(96, 623);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(97, 48);
            this.button7.TabIndex = 18;
            this.button7.Text = "Remover [F4]";
            this.button7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button7.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.button10);
            this.panel1.Controls.Add(this.btn_pesquisar_animal);
            this.panel1.Controls.Add(this.tb_pesquisar);
            this.panel1.Controls.Add(this.comboBox_pesquisar_animal);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(773, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(471, 48);
            this.panel1.TabIndex = 34;
            // 
            // button10
            // 
            this.button10.Image = ((System.Drawing.Image)(resources.GetObject("button10.Image")));
            this.button10.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button10.Location = new System.Drawing.Point(437, 0);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(34, 48);
            this.button10.TabIndex = 28;
            this.button10.Text = "[F6]";
            this.button10.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button10.UseVisualStyleBackColor = true;
            // 
            // btn_pesquisar_animal
            // 
            this.btn_pesquisar_animal.Image = ((System.Drawing.Image)(resources.GetObject("btn_pesquisar_animal.Image")));
            this.btn_pesquisar_animal.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_pesquisar_animal.Location = new System.Drawing.Point(405, 0);
            this.btn_pesquisar_animal.Name = "btn_pesquisar_animal";
            this.btn_pesquisar_animal.Size = new System.Drawing.Size(33, 48);
            this.btn_pesquisar_animal.TabIndex = 27;
            this.btn_pesquisar_animal.Text = "[F5]";
            this.btn_pesquisar_animal.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_pesquisar_animal.UseVisualStyleBackColor = true;
            this.btn_pesquisar_animal.Click += new System.EventHandler(this.btn_pesquisar_animal_Click);
            // 
            // tb_pesquisar
            // 
            this.tb_pesquisar.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tb_pesquisar.Location = new System.Drawing.Point(157, 22);
            this.tb_pesquisar.Name = "tb_pesquisar";
            this.tb_pesquisar.Size = new System.Drawing.Size(243, 20);
            this.tb_pesquisar.TabIndex = 26;
            // 
            // comboBox_pesquisar_animal
            // 
            this.comboBox_pesquisar_animal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_pesquisar_animal.FormattingEnabled = true;
            this.comboBox_pesquisar_animal.Items.AddRange(new object[] {
            "Código",
            "Nome",
            "CPF",
            "CRMV",
            "Login",
            "Tipo de Usuário"});
            this.comboBox_pesquisar_animal.Location = new System.Drawing.Point(30, 21);
            this.comboBox_pesquisar_animal.Name = "comboBox_pesquisar_animal";
            this.comboBox_pesquisar_animal.Size = new System.Drawing.Size(121, 21);
            this.comboBox_pesquisar_animal.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Pesquisar:";
            // 
            // Código
            // 
            this.Código.Text = "Código";
            this.Código.Width = 71;
            // 
            // Nome
            // 
            this.Nome.Text = "Nome";
            this.Nome.Width = 330;
            // 
            // Cor
            // 
            this.Cor.Text = "Cor";
            this.Cor.Width = 256;
            // 
            // Porte
            // 
            this.Porte.Text = "Porte";
            this.Porte.Width = 214;
            // 
            // Peso
            // 
            this.Peso.Text = "Peso";
            this.Peso.Width = 126;
            // 
            // Tipo
            // 
            this.Tipo.Text = "Tipo";
            this.Tipo.Width = 348;
            // 
            // Manter_ficha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1246, 836);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btn_alterar_animal);
            this.Controls.Add(this.btn_novo_animal);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView3);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.lv_animal);
            this.Name = "Manter_ficha";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Deactivate += new System.EventHandler(this.Manter_ficha_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Manter_ficha_FormClosed);
            this.Load += new System.EventHandler(this.Manter_ficha_Load);
            this.Resize += new System.EventHandler(this.Manter_ficha_Resize);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lv_animal;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btn_alterar_animal;
        private System.Windows.Forms.Button btn_novo_animal;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button btn_pesquisar_animal;
        private System.Windows.Forms.TextBox tb_pesquisar;
        private System.Windows.Forms.ComboBox comboBox_pesquisar_animal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader Código;
        private System.Windows.Forms.ColumnHeader Nome;
        private System.Windows.Forms.ColumnHeader Cor;
        private System.Windows.Forms.ColumnHeader Porte;
        private System.Windows.Forms.ColumnHeader Peso;
        private System.Windows.Forms.ColumnHeader Tipo;
    }
}