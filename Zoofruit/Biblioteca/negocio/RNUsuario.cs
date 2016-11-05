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
            if (u.Codigo <= 0)
            {
                throw new NegocioException("O valor do campo código precisa ser maior que zero!");
            }
            if (u.Login != null && u.Login.Equals("") == false)
            {
                throw new NegocioException("O campo Login precisa ser preenchido!");
            }
            if (u.Nome != null && u.Nome.Equals("") == false)
            {
                throw new NegocioException("O campo Nome precisa ser preenchido!");
            }
            if (u.Cpf != null && u.Cpf.Equals("") == false)
            {
                throw new NegocioException("O campo CPF precisa ser preenchido!");
            }
            if (u.Senha != null && u.Senha.Equals("") == false)
            {
                throw new NegocioException("O campo Senha precisa ser preenchido!");
            }
            if (u.tipousuario.Codigo <= 0)
            {
                throw new NegocioException("O campo Tipo de Usuário precisa ser preenchido!");
            }
            if (u.tipousuario.Codigo == 1 && (u.Crmv != null && u.Crmv.Equals("") == false))
            {
                throw new NegocioException("O campo CRMV precisa ser preenchido!");
            }
        }

        private void ValidarDados(Usuario u)
        {
            if (u.Nome != null && u.Nome.Equals("") == false)
            {
                throw new NegocioException("O campo Nome precisa ser preenchido!");
            }
        }
    }
}
