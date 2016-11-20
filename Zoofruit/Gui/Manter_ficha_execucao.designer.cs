using System;

namespace Gui
{
    partial class Manter_ficha_execucao
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
            this.panelExibirDataHora = new System.Windows.Forms.Panel();
            this.lb_hora = new System.Windows.Forms.Label();
            this.lb_data = new System.Windows.Forms.Label();
            this.panelExibirDataHora.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelExibirDataHora
            // 
            this.panelExibirDataHora.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelExibirDataHora.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelExibirDataHora.Controls.Add(this.lb_hora);
            this.panelExibirDataHora.Controls.Add(this.lb_data);
            this.panelExibirDataHora.Location = new System.Drawing.Point(0, 0);
            this.panelExibirDataHora.Name = "panelExibirDataHora";
            this.panelExibirDataHora.Size = new System.Drawing.Size(1035, 75);
            this.panelExibirDataHora.TabIndex = 0;
            this.panelExibirDataHora.Tag = "1";
            // 
            // lb_hora
            // 
            this.lb_hora.AutoSize = true;
            this.lb_hora.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_hora.Location = new System.Drawing.Point(388, 25);
            this.lb_hora.Name = "lb_hora";
            this.lb_hora.Size = new System.Drawing.Size(81, 24);
            this.lb_hora.TabIndex = 1;
            this.lb_hora.Text = "Hora: 19";
            // 
            // lb_data
            // 
            this.lb_data.AutoSize = true;
            this.lb_data.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_data.Location = new System.Drawing.Point(12, 25);
            this.lb_data.Name = "lb_data";
            this.lb_data.Size = new System.Drawing.Size(147, 24);
            this.lb_data.TabIndex = 0;
            this.lb_data.Text = "Data: 19/11/2016";
            // 
            // Manter_ficha_execucao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 504);
            this.Controls.Add(this.panelExibirDataHora);
            this.Name = "Manter_ficha_execucao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quadro de tarefas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Manter_ficha_execucao_FormClosed);
            this.Load += new System.EventHandler(this.Manter_ficha_execucao_Load);
            this.Resize += new System.EventHandler(this.Manter_ficha_execucao_Resize);
            this.panelExibirDataHora.ResumeLayout(false);
            this.panelExibirDataHora.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelExibirDataHora;
        private System.Windows.Forms.Label lb_hora;
        private System.Windows.Forms.Label lb_data;
    }
}