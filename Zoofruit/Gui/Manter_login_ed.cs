
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
    public partial class Manter_login_ed : Form
    {
        List<TipoUsuario> listatipousuario;
        Service1 webservice;
        public Manter_login_ed()
        {
            InitializeComponent();
            listatipousuario = new List<TipoUsuario>();
            webservice = new Service1();
            TipoUsuario tipousuario = new TipoUsuario();
            listatipousuario = webservice.ListarTipoUsuario(tipousuario).ToList();
            foreach (TipoUsuario a in listatipousuario)
            {
                comboBox1.Items.Add(a.Descricao);
            }
        }

        private void Manter_login_ed_Load(object sender, EventArgs e)
        {
            

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))

            {

                e.Handled = true;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.Nome = tb_nome.Text;
            usuario.Cpf = tb_cpf.Text;
            usuario.Crmv = tb_crmv.Text;
            usuario.Login = tb_login.Text;
            usuario.Senha = tb_senha.Text;
            usuario.tipousuario = listatipousuario.ElementAt(comboBox1.SelectedIndex);
            webservice.InserirUsuario(usuario);
            ((Manter_login)Application.OpenForms["manter_login"]).btn_pesquisar_Click(sender, e);
        }
    }
}
