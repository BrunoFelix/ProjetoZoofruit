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
        public List<Usuario> listausuario = new List<Usuario>();
        private static Manter_login manter_login;

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
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public void AtualizarGrid()
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
                item.SubItems.Add(u.tipousuario.Descricao);

                lv_usuario.Items.Add(item);
            }  
        }

        private void Manter_login_Load(object sender, EventArgs e)
        {
            comboBoxPesquisar.SelectedIndex = 1;
            DAOUsuario daousuario = new DAOUsuario();
            Usuario usuario = new Usuario();
            listausuario = daousuario.Pesquisar(usuario);
            AtualizarGrid();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_pesquisar_Click(object sender, EventArgs e)
        {
            DAOUsuario daousuario = new DAOUsuario();
            Usuario usuario = new Usuario();
            if (comboBoxPesquisar.SelectedIndex == 0)
            {
                try
                {
                    usuario.Codigo = Int32.Parse(tb_pesquisar.Text);
                }catch(Exception ex)
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
                catch (Exception ex)
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
                catch (Exception ex)
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
                catch (Exception ex)
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
                catch (Exception ex)
                {
                    MessageBox.Show("Pesquisa inválida!");
                }
            }
            else if (comboBoxPesquisar.SelectedIndex == 5)
            {
                try
                {
                    usuario.tipousuario.Descricao = tb_pesquisar.Text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Pesquisa inválida!");
                }
            }

            listausuario = daousuario.Pesquisar(usuario);
            AtualizarGrid();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBoxPesquisar.SelectedIndex = 1;
            tb_pesquisar.Text = "";
            DAOUsuario daousuario = new DAOUsuario();
            Usuario usuario = new Usuario();
            listausuario = daousuario.Pesquisar(usuario);
            AtualizarGrid();
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
            Manter_login_ed manter_login_ed = new Manter_login_ed();
            manter_login_ed.ShowDialog();
        }
    }
}
