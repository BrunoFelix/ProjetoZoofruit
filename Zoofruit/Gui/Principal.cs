
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
            lb_data.Text = "Versão: 15/11/2016"; 
        }

        private void quadroDeTarefasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manter_ficha_execucao manter_ficha_execucao = Manter_ficha_execucao.getInstance();
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

        }

        private void animaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manter_animal manter_animal = Manter_animal.getInstance();
            manter_animal.Show();
            manter_animal.BringToFront();
        }

        private void consultarAnimalToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void alimentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Manter_alimento manter_alimento = Manter_alimento.getInstance();
            manter_alimento.Show();
            manter_alimento.BringToFront();
        }

        private void alimentoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Manter_ficha_alimento manter_ficha_alimento = Manter_ficha_alimento.getInstance(usuario);
            manter_ficha_alimento.Show();
            manter_ficha_alimento.BringToFront();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
    }
}
