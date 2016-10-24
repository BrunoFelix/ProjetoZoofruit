using Biblioteca.basica;
using Biblioteca.dados;
using Biblioteca.util;
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
    public partial class tela_login : Form
    {
        public tela_login()
        {
            InitializeComponent();
        }

        private void bt_acessar_Click(object sender, EventArgs e)
        {

            try
            {
                Conexao connection = new Conexao();
                connection.openConnection();

                if ((tb_usuario.Text != "") && (tb_senha.Text != ""))
                {
                   
                    List<Usuario> listausuario = new List<Usuario>();
                    DAOUsuario daousuario = new DAOUsuario();
                    Usuario usuario = new Usuario();
                    usuario.Login = tb_usuario.Text;
                    usuario.Senha = tb_senha.Text;
                    listausuario = daousuario.pesquisar(usuario);

                    if (listausuario.Count == 1)
                    {
                       
                            /*Principal principal = new Principal();
                          
                           principal.ShowDialog();*/
                        this.DialogResult = DialogResult.OK;
                           

                    }
                    else
                    {
                        MessageBox.Show("Usuário e senha inválidos!");
                    }

                }
                else
                {
                    MessageBox.Show("Preencha login e senha!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
