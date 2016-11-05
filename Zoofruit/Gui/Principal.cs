
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
        public Principal()
        {
            usuario = new Usuario();
            InitializeComponent();
        }

        private void quadroDeTarefasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void usuárioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Manter_login manterlogin = Manter_login.getInstance();
            manterlogin.Show();
            manterlogin.BringToFront();
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void animaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastroAnimais cadastroanimais = new CadastroAnimais();
            cadastroanimais.Show();
        }
    }
}
