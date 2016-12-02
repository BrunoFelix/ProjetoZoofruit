using Biblioteca.basica;
using Biblioteca.dados;
using Biblioteca.util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.negocio
{
    public class RNUsuario : NegocioException
    {
        DAOUsuario daousuario;
        public RNUsuario()
        {
            daousuario = new DAOUsuario();
        }

        public void Adicionar(Usuario u)
        {
            try
            {
                ValidarPreenchimentoDados(u);
                ValidarDados(u);
                VerificarDuplicidade(u);
                daousuario.Adicionar(u);
            }
            catch(Exception ex)
            {
                throw new NegocioException(ex.Message);
            }
        }

        public void Alterar(Usuario u) 
        {
            try
            {
                ValidarPreenchimentoDados(u);
                ValidarDados(u);
                VerificarDuplicidade(u, true);
                daousuario.Alterar(u);
            }
            catch (Exception ex)
            {
                throw new NegocioException(ex.Message);
            }
        }

        public void Excluir(Usuario u)
        {
            try
            {
                if (u.Codigo < 0)
                {
                    throw new NegocioException("O usuário que você está tentando excluir não existe!");
                }
                daousuario.Excluir(u);
            }
            catch (Exception ex)
            {
                throw new NegocioException(ex.Message);
            }
        }

        public List<Usuario> NListarUsuario(Usuario u)
        {
            try
            {
                return daousuario.Pesquisar(u);
            }
            catch (Exception ex)
            {
                throw new NegocioException(ex.Message);
            }
        }



        //######################################### VALIDAÇÕES

        private void ValidarPreenchimentoDados(Usuario u)
        {
            if (u.Nome == null || u.Nome.Equals("") == true)
            {
                throw new NegocioException("O campo \"Nome\" precisa ser preenchido!");
            }
            if (u.Cpf == null || u.Cpf.Equals("") == true)
            {
                throw new NegocioException("O campo \"CPF\" precisa ser preenchido!");
            }
            if (u.Login == null || u.Login.Equals("") == true)
            {
                throw new NegocioException("O campo \"Login\" precisa ser preenchido!");
            }
            if (u.Senha == null || u.Senha.Equals("") == true)
            {
                throw new NegocioException("O campo \"Senha\" precisa ser preenchido!");
            }
            if (u.Tipousuario == null)
            {
                throw new NegocioException("O campo \"Tipo de Usuário\" precisa ser preenchido!");
            }
            if (u.Tipousuario.Codigo == 2 && (u.Crmv == null || u.Crmv.Equals("") == true))
            {
                throw new NegocioException("O campo \"CRMV\" precisa ser preenchido!");
            }
        }

        private void ValidarDados(Usuario u)
        {
            if (u.Nome.Length < 3 || u.Nome.Length > 60)
            {
                throw new NegocioException("O campo \"Nome\" precisa conter entre 3 e 60 caracteres!");
            }
            if (u.Cpf.Length != 11)
            {
                throw new NegocioException("O campo \"CPF\" precisa conter 11 caracteres!");
            }
            if (u.Crmv.Length > 15)
            {
                throw new NegocioException("O campo \"CRMV\" precisa conter menos de 16 caracteres!");
            }
            if (u.Login.Length < 3 || u.Login.Length > 20)
            {
                throw new NegocioException("O campo \"Login\" deve conter entre 3 e 20 caracteres!");
            }
            if (u.Senha.Length < 3 || u.Senha.Length > 8)
            {
                throw new NegocioException("O campo \"Senha\" deve conter entre 3 e 8 caracteres!");
            }
            if (u.Tipousuario.Codigo <= 0)
            {
                throw new NegocioException("O campo \"Tipo\" é inválido!");
            }
        }

        private void VerificarDuplicidade(Usuario u, bool alt=false)
        {
            Usuario u2 = new Usuario();
            u2.Codigo = u.Codigo;
            u2.Cpf = u.Cpf;
            if (daousuario.Pesquisar(u2, alt).Count > 0)
            {
                throw new NegocioException("\"CPF\" do usuário digitado já consta no sistema!");
            }
            u2 = new Usuario();
            u2.Codigo = u.Codigo;
            u2.Login = u.Login;
            u2.Senha = u.Senha;
            if (daousuario.Pesquisar(u2, alt).Count > 0)
            {
                throw new NegocioException("\"Login\" do usuário digitado já consta no sistema!");
            }
        }
    }
}
