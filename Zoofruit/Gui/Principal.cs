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
        public Principal()
        {
            InitializeComponent();
        }

        private void quadroDeTarefasToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void usuárioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Manter_login manterlogin = new Manter_login();
            manterlogin.Show();
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }
    }
}
