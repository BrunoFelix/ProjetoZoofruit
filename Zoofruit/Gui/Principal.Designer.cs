namespace Gui
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cadastrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.animaisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tipoDeAnimalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alimentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuárioToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.movimentaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarAnimalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quadroDeTarefasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lb_data = new System.Windows.Forms.Label();
            this.lb_usuario = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_quadro_tarefas = new System.Windows.Forms.Button();
            this.btn_quadro_fichas = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarToolStripMenuItem,
            this.movimentaçãoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1274, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cadastrarToolStripMenuItem
            // 
            this.cadastrarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.animaisToolStripMenuItem,
            this.tipoDeAnimalToolStripMenuItem,
            this.alimentoToolStripMenuItem,
            this.usuárioToolStripMenuItem1});
            this.cadastrarToolStripMenuItem.Name = "cadastrarToolStripMenuItem";
            this.cadastrarToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.cadastrarToolStripMenuItem.Text = "Cadastro";
            // 
            // animaisToolStripMenuItem
            // 
            this.animaisToolStripMenuItem.Name = "animaisToolStripMenuItem";
            this.animaisToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.animaisToolStripMenuItem.Text = "Animal";
            this.animaisToolStripMenuItem.Click += new System.EventHandler(this.animaisToolStripMenuItem_Click);
            // 
            // tipoDeAnimalToolStripMenuItem
            // 
            this.tipoDeAnimalToolStripMenuItem.Name = "tipoDeAnimalToolStripMenuItem";
            this.tipoDeAnimalToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.tipoDeAnimalToolStripMenuItem.Text = "Tipo de animal";
            this.tipoDeAnimalToolStripMenuItem.Click += new System.EventHandler(this.tipoDeAnimalToolStripMenuItem_Click);
            // 
            // alimentoToolStripMenuItem
            // 
            this.alimentoToolStripMenuItem.Name = "alimentoToolStripMenuItem";
            this.alimentoToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.alimentoToolStripMenuItem.Text = "Alimento";
            this.alimentoToolStripMenuItem.Click += new System.EventHandler(this.alimentoToolStripMenuItem_Click);
            // 
            // usuárioToolStripMenuItem1
            // 
            this.usuárioToolStripMenuItem1.Name = "usuárioToolStripMenuItem1";
            this.usuárioToolStripMenuItem1.Size = new System.Drawing.Size(153, 22);
            this.usuárioToolStripMenuItem1.Text = "Usuário";
            this.usuárioToolStripMenuItem1.Click += new System.EventHandler(this.usuárioToolStripMenuItem1_Click);
            // 
            // movimentaçãoToolStripMenuItem
            // 
            this.movimentaçãoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consultarAnimalToolStripMenuItem,
            this.quadroDeTarefasToolStripMenuItem});
            this.movimentaçãoToolStripMenuItem.Name = "movimentaçãoToolStripMenuItem";
            this.movimentaçãoToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.movimentaçãoToolStripMenuItem.Text = "Movimentação";
            // 
            // consultarAnimalToolStripMenuItem
            // 
            this.consultarAnimalToolStripMenuItem.Name = "consultarAnimalToolStripMenuItem";
            this.consultarAnimalToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.consultarAnimalToolStripMenuItem.Text = "Gerenciar Fichas";
            this.consultarAnimalToolStripMenuItem.Click += new System.EventHandler(this.consultarAnimalToolStripMenuItem_Click);
            // 
            // quadroDeTarefasToolStripMenuItem
            // 
            this.quadroDeTarefasToolStripMenuItem.Name = "quadroDeTarefasToolStripMenuItem";
            this.quadroDeTarefasToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.quadroDeTarefasToolStripMenuItem.Text = "Quadro de tarefas";
            this.quadroDeTarefasToolStripMenuItem.Click += new System.EventHandler(this.quadroDeTarefasToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.lb_data);
            this.panel1.Controls.Add(this.lb_usuario);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(0, 635);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1274, 42);
            this.panel1.TabIndex = 1;
            // 
            // lb_data
            // 
            this.lb_data.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_data.AutoSize = true;
            this.lb_data.Location = new System.Drawing.Point(1151, 15);
            this.lb_data.Name = "lb_data";
            this.lb_data.Size = new System.Drawing.Size(30, 13);
            this.lb_data.TabIndex = 1;
            this.lb_data.Text = "Data";
            // 
            // lb_usuario
            // 
            this.lb_usuario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_usuario.AutoSize = true;
            this.lb_usuario.Location = new System.Drawing.Point(12, 15);
            this.lb_usuario.Name = "lb_usuario";
            this.lb_usuario.Size = new System.Drawing.Size(43, 13);
            this.lb_usuario.TabIndex = 0;
            this.lb_usuario.Text = "Usuario";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_quadro_tarefas);
            this.panel2.Controls.Add(this.btn_quadro_fichas);
            this.panel2.Location = new System.Drawing.Point(250, 153);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(744, 296);
            this.panel2.TabIndex = 2;
            // 
            // btn_quadro_tarefas
            // 
            this.btn_quadro_tarefas.Image = ((System.Drawing.Image)(resources.GetObject("btn_quadro_tarefas.Image")));
            this.btn_quadro_tarefas.Location = new System.Drawing.Point(375, 3);
            this.btn_quadro_tarefas.Name = "btn_quadro_tarefas";
            this.btn_quadro_tarefas.Size = new System.Drawing.Size(366, 290);
            this.btn_quadro_tarefas.TabIndex = 5;
            this.btn_quadro_tarefas.Text = "Quadro de Tarefas";
            this.btn_quadro_tarefas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_quadro_tarefas.UseVisualStyleBackColor = true;
            // 
            // btn_quadro_fichas
            // 
            this.btn_quadro_fichas.Image = ((System.Drawing.Image)(resources.GetObject("btn_quadro_fichas.Image")));
            this.btn_quadro_fichas.Location = new System.Drawing.Point(3, 3);
            this.btn_quadro_fichas.Name = "btn_quadro_fichas";
            this.btn_quadro_fichas.Size = new System.Drawing.Size(366, 290);
            this.btn_quadro_fichas.TabIndex = 4;
            this.btn_quadro_fichas.Text = "Gerenciar Fichas";
            this.btn_quadro_fichas.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_quadro_fichas.UseVisualStyleBackColor = true;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1274, 677);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zoofruit - Painel Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Principal_Load);
            this.Resize += new System.EventHandler(this.Principal_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cadastrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem animaisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alimentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem movimentaçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipoDeAnimalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuárioToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem consultarAnimalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quadroDeTarefasToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lb_usuario;
        private System.Windows.Forms.Label lb_data;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_quadro_tarefas;
        private System.Windows.Forms.Button btn_quadro_fichas;
    }
}