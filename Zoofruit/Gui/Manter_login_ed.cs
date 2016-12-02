
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
using System.Xml;
using System.Xml.Linq;

namespace Gui
{
    public partial class Manter_login_ed : Form
    {
        private string nomeDoArquivo = "Usuario.xml";
        List<TipoUsuario> listatipousuario;
        private XElement doc;
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
            int index = comboBox1.FindString(usuario.Tipousuario.Descricao);
            comboBox1.SelectedIndex = index;

            //comboBox1.SelectedText = usuario.tipousuario.Descricao;

            //comboBox1.Items.IndexOf(usuario.tipousuario.Descricao);
        }

        public void gravarxml()
        {
            try
            {
                doc = new XElement("Usuario");
                XElement usuario = new XElement("Usuario");
                usuario.Add(new XElement("Nome", tb_nome.Text));
                usuario.Add(new XElement("CPF", tb_cpf.Text));
                usuario.Add(new XElement("CRMV", tb_crmv.Text));
                usuario.Add(new XElement("Login", tb_login.Text));
                usuario.Add(new XElement("Senha", tb_senha.Text));
                doc.Add(usuario);
                doc.Save(nomeDoArquivo);
            }
            catch (Exception e)
            {

            }

        }

        public void exibirxml()
        {
            try
            {
                XmlTextReader x = new XmlTextReader(@".\\Usuario.xml");

                while (x.Read())
                {
                    if (x.NodeType == XmlNodeType.Element && x.Name == "Nome")
                        tb_nome.Text = (x.ReadString());
                    if (x.NodeType == XmlNodeType.Element && x.Name == "CPF")
                        tb_cpf.Text = (x.ReadString());
                    if (x.NodeType == XmlNodeType.Element && x.Name == "CRMV")
                        tb_crmv.Text = (x.ReadString());
                    if (x.NodeType == XmlNodeType.Element && x.Name == "Login")
                        tb_login.Text = (x.ReadString());
                    if (x.NodeType == XmlNodeType.Element && x.Name == "Senha")
                        tb_senha.Text = (x.ReadString());
                }
                x.Close();
                return;
            }
            catch (Exception)
            {
                //
            }
        }

        public void destruirxml()
        {
            try
            {
                if (System.IO.File.Exists(Application.StartupPath + "\\Usuario.xml"))
                {
                    System.IO.File.Delete(Application.StartupPath + "\\Usuario.xml");
                }
            }
            catch (Exception)
            {
                //
            }
        }

        private void Manter_login_ed_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
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
            try
            {
                if (this.usuario == null)
                {
                    Usuario usuario = new Usuario();
                    usuario.Nome = tb_nome.Text;
                    usuario.Cpf = tb_cpf.Text;
                    usuario.Crmv = tb_crmv.Text;
                    usuario.Login = tb_login.Text;
                    usuario.Senha = tb_senha.Text;
                    try
                    {
                        tipousuario = listatipousuario.ElementAt(comboBox1.SelectedIndex);
                    }
                    catch (Exception)
                    {
                        tipousuario = null;
                    }
                    usuario.Tipousuario = tipousuario;
                    webservice.InserirUsuario(usuario);
                    destruirxml();
                    ((Manter_login)Application.OpenForms["manter_login"]).btn_pesquisar_Click_1(sender, e);
                    this.DialogResult = DialogResult.OK;
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
                    try
                    {
                        tipousuario = listatipousuario.ElementAt(comboBox1.SelectedIndex);
                    }
                    catch (Exception)
                    {
                        tipousuario = null;
                    }
                    usuario.Tipousuario = tipousuario;
                    webservice.AlterarUsuario(usuario);
                    destruirxml();
                    ((Manter_login)Application.OpenForms["manter_login"]).btn_pesquisar_Click_1(sender, e);
                    this.DialogResult = DialogResult.OK;
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.DialogResult = DialogResult.None;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Todos os dados serão perdidos e não poderão ser recuperados, deseja realmente cancelar a operação?", "Zoofruit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                destruirxml();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.None;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.gravarxml();
        }

        private void Manter_login_ed_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Enabled = false;
        }
    }
}
