
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
        TipoUsuario tipousuario;
        Service1 webservice;
        Usuario usuario;
        public Manter_login_ed()
        {
            InitializeComponent();
            listatipousuario = new List<TipoUsuario>();
            webservice = new Service1();
            tipousuario = new TipoUsuario();
            listatipousuario = webservice.ListarTipoUsuario(tipousuario).ToList();
            foreach (TipoUsuario a in listatipousuario)
            {
                comboBox1.Items.Add(a.Descricao);
            }
        }

        public Manter_login_ed(Usuario u)
        {
            InitializeComponent();
            listatipousuario = new List<TipoUsuario>();
            webservice = new Service1();
            tipousuario = new TipoUsuario();
            listatipousuario = webservice.ListarTipoUsuario(tipousuario).ToList();
            foreach (TipoUsuario a in listatipousuario)
            {
                comboBox1.Items.Add(a.Descricao);
            }
            usuario = new Usuario();
            usuario = u;

            tb_codigo.Text = usuario.Codigo.ToString();
            tb_nome.Text = usuario.Nome;
            tb_cpf.Text = usuario.Cpf;
            tb_crmv.Text = usuario.Crmv;
            tb_login.Text = usuario.Login;
            tb_senha.Text = usuario.Senha;
            int index = comboBox1.FindString(usuario.tipousuario.Descricao);
            comboBox1.SelectedIndex = index;

            //comboBox1.SelectedText = usuario.tipousuario.Descricao;

            //comboBox1.Items.IndexOf(usuario.tipousuario.Descricao);
        }

        private void Manter_login_ed_Load(object sender, EventArgs e)
        {
            

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.usuario == null)
            {
                Usuario usuario = new Usuario();
                usuario.Nome = tb_nome.Text;
                usuario.Cpf = tb_cpf.Text;
                usuario.Crmv = tb_crmv.Text;
                usuario.Login = tb_login.Text;
                usuario.Senha = tb_senha.Text;
                tipousuario = listatipousuario.ElementAt(comboBox1.SelectedIndex);
                usuario.tipousuario = tipousuario;
                webservice.InserirUsuario(usuario);
                ((Manter_login)Application.OpenForms["manter_login"]).btn_pesquisar_Click(sender, e);
            }
            else
            {
                Usuario usuario = new Usuario();
                usuario.Codigo = this.usuario.Codigo;
                usuario.Nome = tb_nome.Text;
                usuario.Cpf = tb_cpf.Text;
                usuario.Crmv = tb_crmv.Text;
                usuario.Login = tb_login.Text;
                usuario.Senha = tb_senha.Text;
                tipousuario = listatipousuario.ElementAt(comboBox1.SelectedIndex);
                usuario.tipousuario = tipousuario;
                webservice.AlterarUsuario(usuario);
                ((Manter_login)Application.OpenForms["manter_login"]).btn_pesquisar_Click(sender, e);
            }
        }
    }
}
