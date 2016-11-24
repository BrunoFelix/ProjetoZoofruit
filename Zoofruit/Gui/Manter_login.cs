
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
    public partial class Manter_login : Form
    {
        public List<Usuario> listausuario;
        private static Manter_login manter_login;
        Service1 webservice;

        public static Manter_login getInstance()
        {
            if (manter_login == null)
            {
                try
                {
                    manter_login = new Manter_login();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return manter_login;
        }
        private Manter_login()
        {
            try
            {
                InitializeComponent();
                webservice = new Service1();
                listausuario = new List<Usuario>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public void AtualizarGrid()
        {
            try
            {
                lv_usuario.Items.Clear();

                ListViewItem item;

                foreach (Usuario u in listausuario)
                {
                    item = new ListViewItem();
                    item.Text = u.Codigo.ToString();
                    item.SubItems.Add(u.Nome);
                    item.SubItems.Add(Convert.ToUInt64(u.Cpf).ToString(@"000\.000\.000\-00"));
                    item.SubItems.Add(u.Crmv);
                    item.SubItems.Add(u.Login);
                    item.SubItems.Add(u.Tipousuario.Descricao);

                    lv_usuario.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Manter_login_Load(object sender, EventArgs e)
        {
            try
            {
                comboBoxPesquisar.SelectedIndex = 1;
                Usuario usuario = new Usuario();
                TipoUsuario tipousuario = new TipoUsuario();
                usuario.Tipousuario = tipousuario;
                listausuario = webservice.ListarUsuario(usuario).ToList();
                AtualizarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        public void btn_pesquisar_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                comboBoxPesquisar.SelectedIndex = 0;
                tb_pesquisar.Text = "";
                Usuario usuario = new Usuario();
                TipoUsuario tipousuario = new TipoUsuario();
                usuario.Tipousuario = tipousuario;
                listausuario = webservice.ListarUsuario(usuario).ToList();
                AtualizarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lv_usuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                Manter_login_ed manter_login_ed = new Manter_login_ed();
                manter_login_ed.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void btn_pesquisar_Click_1(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            TipoUsuario tipousuario = new TipoUsuario();
            usuario.Tipousuario = tipousuario;
            if (comboBoxPesquisar.SelectedIndex == 0)
            {
                try
                {
                    usuario.Codigo = Int32.Parse(tb_pesquisar.Text);
                }
                catch (Exception)
                {
                    MessageBox.Show("Pesquisa inválida!");
                }
            }
            else if (comboBoxPesquisar.SelectedIndex == 1)
            {
                try
                {
                    usuario.Nome = tb_pesquisar.Text;
                }
                catch (Exception)
                {
                    MessageBox.Show("Pesquisa inválida!");
                }
            }
            else if (comboBoxPesquisar.SelectedIndex == 2)
            {
                try
                {
                    usuario.Cpf = tb_pesquisar.Text;
                }
                catch (Exception)
                {
                    MessageBox.Show("Pesquisa inválida!");
                }
            }
            else if (comboBoxPesquisar.SelectedIndex == 3)
            {
                try
                {
                    usuario.Crmv = tb_pesquisar.Text;
                }
                catch (Exception)
                {
                    MessageBox.Show("Pesquisa inválida!");
                }

            }
            else if (comboBoxPesquisar.SelectedIndex == 4)
            {
                try
                {
                    usuario.Login = tb_pesquisar.Text;
                }
                catch (Exception)
                {
                    MessageBox.Show("Pesquisa inválida!");
                }
            }
            else if (comboBoxPesquisar.SelectedIndex == 5)
            {
                try
                {
                    usuario.Tipousuario.Descricao = tb_pesquisar.Text;
                }
                catch (Exception)
                {
                    MessageBox.Show("Pesquisa inválida!");
                }
            }

            try
            {
                listausuario = webservice.ListarUsuario(usuario).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            AtualizarGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (lv_usuario.SelectedIndices.Count > 0)
                {
                    if (MessageBox.Show("Deseja remover o registro selecionado?", "Zoofruit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        webservice.ExcluirUsuario(listausuario.ElementAt(lv_usuario.SelectedIndices[0]));
                        listausuario.Remove(listausuario.ElementAt(lv_usuario.SelectedIndices[0]));
                        MessageBox.Show("Removido com sucesso!");
                        AtualizarGrid();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (lv_usuario.SelectedIndices.Count > 0)
                {
                    Usuario usuario = new Usuario();
                    usuario = listausuario.ElementAt(lv_usuario.SelectedIndices[0]);
                    Manter_login_ed manter_login_ed = new Manter_login_ed(usuario);
                    manter_login_ed.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Manter_login_FormClosed(object sender, FormClosedEventArgs e)
        {
            manter_login = null;
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
