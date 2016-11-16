
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
    public partial class tela_login : Form
    {
        public Usuario usuario;
        public tela_login()
        {
            usuario = new Usuario();
            InitializeComponent();
        }

        private void bt_acessar_Click(object sender, EventArgs e)
        {

            try
            {
                if ((tb_usuario.Text != "") && (tb_senha.Text != ""))
                {
                   
                    List<Usuario> listausuario = new List<Usuario>();
                    Service1 webservice = new Service1();
                    usuario.Login = tb_usuario.Text;
                    usuario.Senha = tb_senha.Text;
                    usuario.Tipousuario = new TipoUsuario();
                    listausuario = webservice.ListarUsuario(usuario).ToList();

                    if (listausuario.Count == 1)
                    {

                        /*Principal principal = new Principal();

                       principal.ShowDialog();*/
                       foreach(Usuario u in listausuario)
                        {
                            usuario = u;
                        }
                        
                        this.DialogResult = DialogResult.OK;
                           

                    }
                    else
                    {
                        MessageBox.Show("Usuário e senha não pertencem a nenhuma conta cadastrada no sistema!");
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
