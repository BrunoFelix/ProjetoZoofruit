
using Gui.localhost;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gui
{
    public partial class Principal : Form
    {
        public Usuario usuario;
        public Principal(Usuario u)
        {
            usuario = u;
            InitializeComponent();
            lb_usuario.Text = "Usuario logado: " + usuario.Nome + " (" + usuario.Login + ")";
            lb_data.Text = "Versão: 21/11/2016"; 
        }

        private void quadroDeTarefasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manter_ficha_execucao manter_ficha_execucao = Manter_ficha_execucao.getInstance(usuario);
            manter_ficha_execucao.Show();
            manter_ficha_execucao.BringToFront();
        }

        private void usuárioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Manter_login manter_login = Manter_login.getInstance();
            manter_login.Show();
            manter_login.BringToFront();
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            if (usuario.Tipousuario.Codigo == 1)
            {
                animaisToolStripMenuItem.Enabled = false;
                tipoDeAnimalToolStripMenuItem.Enabled = false;
                alimentoToolStripMenuItem.Enabled = false;
                usuárioToolStripMenuItem1.Enabled = false;
                consultarAnimalToolStripMenuItem.Enabled = false;
                btn_quadro_fichas.Enabled = false;
            } else if (usuario.Tipousuario.Codigo == 2)
            {
                animaisToolStripMenuItem.Enabled = false;
                tipoDeAnimalToolStripMenuItem.Enabled = false;
                alimentoToolStripMenuItem.Enabled = false;
                usuárioToolStripMenuItem1.Enabled = false;
                quadroDeTarefasToolStripMenuItem.Enabled = false;
                btn_quadro_tarefas.Enabled = false;
            }

            panel2.Left = (this.ClientSize.Width - panel2.Width) / 2;
            panel2.Top = (this.ClientSize.Height - panel2.Height) / 2;
        }

        private void animaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manter_animal manter_animal = Manter_animal.getInstance();
            manter_animal.Show();
            manter_animal.BringToFront();
        }

        private void consultarAnimalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manter_ficha_alimento manter_ficha_alimento = Manter_ficha_alimento.getInstance(usuario);
            manter_ficha_alimento.Show();
            manter_ficha_alimento.BringToFront();
        }

        private void alimentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manter_alimento manter_alimento = Manter_alimento.getInstance();
            manter_alimento.Show();
            manter_alimento.BringToFront();
        }

        private void alimentoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void testeToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void tipoDeAnimalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manter_tipo_animal manter_tipo_animal = Manter_tipo_animal.getInstance();
            manter_tipo_animal.Show();
            manter_tipo_animal.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Principal_Resize(object sender, EventArgs e)
        {
            panel2.Left = (this.ClientSize.Width - panel2.Width) / 2;
            panel2.Top = (this.ClientSize.Height - panel2.Height) / 2;
        }
    }
}
