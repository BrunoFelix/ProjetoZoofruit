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
    public class RNAlimento : NegocioException
    {
        DAOAlimento daoalimento;
        public RNAlimento()
        {
            daoalimento = new DAOAlimento();
        }

        public void Adicionar(Alimento a)
        {
            try
            {
                ValidarPreenchimentoDados(a);
                ValidarDados(a);
                VerificarDuplicidade(a);
                daoalimento.Adicionar(a);
            }
            catch (Exception ex)
            {
                throw new NegocioException(ex.Message);
            }
        }

        public void Alterar(Alimento a)
        {
            try
            {
                ValidarPreenchimentoDados(a);
                ValidarDados(a);
                VerificarDuplicidade(a, true);
                daoalimento.Alterar(a);
            }
            catch (Exception ex)
            {
                throw new NegocioException(ex.Message);
            }
        }

        public void Excluir(Alimento a)
        {
            try
            {
                if (a.Codigo < 0)
                {
                    throw new NegocioException("O alimento que você está tentando excluir não existe!");
                }
                daoalimento.Excluir(a);
            }
            catch (Exception ex)
            {
                throw new NegocioException(ex.Message);
            }
        }

        public List<Alimento> NListarAlimento(Alimento a)
        {
            try
            {
                return daoalimento.Pesquisar(a);
            }
            catch (Exception ex)
            {
                throw new NegocioException(ex.Message);
            }
        }

        //######################################### VALIDAÇÕES

        private void ValidarPreenchimentoDados(Alimento a)
        {
            if (a.Nome == null || a.Nome.Equals("") == true)
            {
                throw new NegocioException("O campo \"Nome\" precisa ser preenchido!");
            }
            if (a.ValorCalorico == null)
            {
                throw new NegocioException("O campo \"Valor Calórico\" precisa ser preenchido!");
            }
            if (a.Quantidade == null)
            {
                throw new NegocioException("O campo \"Quantidade\" precisa ser preenchido!");
            }
        }

        private void ValidarDados(Alimento a)
        {
            if (a.Nome.Length < 3 || a.Nome.Length > 20)
            {
                throw new NegocioException("O campo \"Nome\" precisa conter entre 3 e 20 caracteres!");
            }
            if (a.ValorCalorico <= 0)
            {
                throw new NegocioException("O campo \"Valor Calórico\" deve ser um número maior do que zero!");
            }
            if (a.Quantidade <= 0)
            {
                throw new NegocioException("O campo \"Quantidade\" deve ser um número maior do que zero!");
            }
        }

        private void VerificarDuplicidade(Alimento a, bool alt = false)
        {
            Alimento a2 = new Alimento();
            a2.Codigo = a.Codigo;
            a2.Nome = a.Nome;
            //a2.TipoAnimal = a.TipoAnimal;
            if (daoalimento.Pesquisar(a2, alt).Count > 0)
            {
                throw new NegocioException("\"Nome\" do alimento digitado já consta no sistema!");
            }
        }

    }
}
