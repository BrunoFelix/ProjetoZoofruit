using Biblioteca.basica;
using Biblioteca.dados;
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
    public partial class Manter_login : Form
    {
        public Manter_login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Manter_login_Load(object sender, EventArgs e)
        {
            comboBoxPesquisar.SelectedIndex = 1;
            DAOUsuario daousuario = new DAOUsuario();
            List<Usuario> listausuario = new List<Usuario>();
            Usuario usuario = new Usuario();
            listausuario = daousuario.pesquisar(usuario);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
