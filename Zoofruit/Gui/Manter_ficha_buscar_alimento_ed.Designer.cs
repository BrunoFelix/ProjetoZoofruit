namespace Gui
{
    partial class Manter_ficha_buscar_alimento_ed
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Manter_ficha_buscar_alimento_ed));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_pesquisar_animal = new System.Windows.Forms.Button();
            this.tb_pesquisar = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lv_alimento = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btn_pesquisar_animal);
            this.panel1.Controls.Add(this.tb_pesquisar);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1022, 48);
            this.panel1.TabIndex = 35;
            // 
            // btn_pesquisar_animal
            // 
            this.btn_pesquisar_animal.Image = ((System.Drawing.Image)(resources.GetObject("btn_pesquisar_animal.Image")));
            this.btn_pesquisar_animal.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_pesquisar_animal.Location = new System.Drawing.Point(405, 0);
            this.btn_pesquisar_animal.Name = "btn_pesquisar_animal";
            this.btn_pesquisar_animal.Size = new System.Drawing.Size(34, 48);
            this.btn_pesquisar_animal.TabIndex = 27;
            this.btn_pesquisar_animal.Text = "[F5]";
            this.btn_pesquisar_animal.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_pesquisar_animal.UseVisualStyleBackColor = true;
            this.btn_pesquisar_animal.Click += new System.EventHandler(this.btn_pesquisar_animal_Click);
            // 
            // tb_pesquisar
            // 
            this.tb_pesquisar.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.tb_pesquisar.Location = new System.Drawing.Point(6, 22);
            this.tb_pesquisar.Name = "tb_pesquisar";
            this.tb_pesquisar.Size = new System.Drawing.Size(394, 20);
            this.tb_pesquisar.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Pesquisar:";
            // 
            // lv_alimento
            // 
            this.lv_alimento.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lv_alimento.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lv_alimento.FullRowSelect = true;
            this.lv_alimento.Location = new System.Drawing.Point(0, 47);
            this.lv_alimento.MultiSelect = false;
            this.lv_alimento.Name = "lv_alimento";
            this.lv_alimento.Size = new System.Drawing.Size(1022, 312);
            this.lv_alimento.TabIndex = 36;
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
            this.columnHeader2.Width = 438;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Valor Calórico";
            this.columnHeader3.Width = 179;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Quantidade";
            this.columnHeader4.Width = 230;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.Location = new System.Drawing.Point(523, 365);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 48);
            this.button2.TabIndex = 38;
            this.button2.Text = "Cancelar [F9]";
            this.button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(427, 365);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 48);
            this.button1.TabIndex = 37;
            this.button1.Text = "Confirmar [F8]";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Manter_ficha_buscar_alimento_ed
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 425);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lv_alimento);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Manter_ficha_buscar_alimento_ed";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alimentos da ficha";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_pesquisar_animal;
        private System.Windows.Forms.TextBox tb_pesquisar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView lv_alimento;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}