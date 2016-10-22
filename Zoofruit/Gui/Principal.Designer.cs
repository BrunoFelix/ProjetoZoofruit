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
            this.medicaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuárioToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.movimentaçãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarAnimalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quadroDeTarefasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histórioDeTarefasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarToolStripMenuItem,
            this.movimentaçãoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(814, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cadastrarToolStripMenuItem
            // 
            this.cadastrarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.animaisToolStripMenuItem,
            this.tipoDeAnimalToolStripMenuItem,
            this.alimentoToolStripMenuItem,
            this.medicaçãoToolStripMenuItem,
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
            // 
            // tipoDeAnimalToolStripMenuItem
            // 
            this.tipoDeAnimalToolStripMenuItem.Name = "tipoDeAnimalToolStripMenuItem";
            this.tipoDeAnimalToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.tipoDeAnimalToolStripMenuItem.Text = "Tipo de animal";
            // 
            // alimentoToolStripMenuItem
            // 
            this.alimentoToolStripMenuItem.Name = "alimentoToolStripMenuItem";
            this.alimentoToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.alimentoToolStripMenuItem.Text = "Alimento";
            // 
            // medicaçãoToolStripMenuItem
            // 
            this.medicaçãoToolStripMenuItem.Name = "medicaçãoToolStripMenuItem";
            this.medicaçãoToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.medicaçãoToolStripMenuItem.Text = "Medicamento";
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
            this.quadroDeTarefasToolStripMenuItem,
            this.histórioDeTarefasToolStripMenuItem});
            this.movimentaçãoToolStripMenuItem.Name = "movimentaçãoToolStripMenuItem";
            this.movimentaçãoToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
            this.movimentaçãoToolStripMenuItem.Text = "Movimentação";
            // 
            // consultarAnimalToolStripMenuItem
            // 
            this.consultarAnimalToolStripMenuItem.Name = "consultarAnimalToolStripMenuItem";
            this.consultarAnimalToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.consultarAnimalToolStripMenuItem.Text = "Consultar animal";
            // 
            // quadroDeTarefasToolStripMenuItem
            // 
            this.quadroDeTarefasToolStripMenuItem.Name = "quadroDeTarefasToolStripMenuItem";
            this.quadroDeTarefasToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.quadroDeTarefasToolStripMenuItem.Text = "Quadro de tarefas";
            this.quadroDeTarefasToolStripMenuItem.Click += new System.EventHandler(this.quadroDeTarefasToolStripMenuItem_Click);
            // 
            // histórioDeTarefasToolStripMenuItem
            // 
            this.histórioDeTarefasToolStripMenuItem.Name = "histórioDeTarefasToolStripMenuItem";
            this.histórioDeTarefasToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.histórioDeTarefasToolStripMenuItem.Text = "Histório de tarefas";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 430);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Principal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zoofruit - Painel Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Principal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cadastrarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem animaisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alimentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem medicaçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem movimentaçãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tipoDeAnimalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuárioToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem consultarAnimalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quadroDeTarefasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histórioDeTarefasToolStripMenuItem;
    }
}