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
    public class RNTipoAnimal : NegocioException
    {
        DAOTipoAnimal daotipoanimal;

        public RNTipoAnimal()
        {
            daotipoanimal = new DAOTipoAnimal();
        }

        public void Adicionar(TipoAnimal ta)
        {
            try
            {
                ValidarPreenchimentoDados(ta);
                ValidarDados(ta);
                VerificarDuplicidade(ta);
                daotipoanimal.Adicionar(ta);
            }
            catch (Exception ex)
            {
                throw new NegocioException(ex.Message);
            }
        }

        public void Alterar(TipoAnimal ta)
        {
            try
            {
                ValidarPreenchimentoDados(ta);
                ValidarDados(ta);
                VerificarDuplicidade(ta, true);
                daotipoanimal.Alterar(ta);
            }
            catch (Exception ex)
            {
                throw new NegocioException(ex.Message);
            }
        }

        public void Excluir(TipoAnimal ta)
        {
            try
            {
                if (ta.Codigo < 0)
                {
                    throw new NegocioException("O tipo de animal que você está tentando excluir não existe!");
                }
                daotipoanimal.Excluir(ta);
            }
            catch (Exception ex)
            {
                throw new NegocioException(ex.Message);
            }
        }

        public List<TipoAnimal> NListarTipoAnimal(TipoAnimal ta)
        {
            try
            {
                return daotipoanimal.Pesquisar(ta);
            }
            catch (Exception ex)
            {
                throw new NegocioException(ex.Message);
            }
        }

        //######################################### VALIDAÇÕES

        private void ValidarPreenchimentoDados(TipoAnimal ta)
        {
            if (ta.Descricao == null || ta.Descricao.Equals("") == true)
            {
                throw new NegocioException("O campo \"Descrição\" precisa ser preenchido!");
            }
        }

        private void ValidarDados(TipoAnimal ta)
        {
            if (ta.Descricao.Length < 3 || ta.Descricao.Length > 20)
            {
                throw new NegocioException("O campo \"Descrição\" precisa conter entre 3 e 20 caracteres!");
            }
        }

        private void VerificarDuplicidade(TipoAnimal ta, bool alt = false)
        {
            TipoAnimal ta2 = new TipoAnimal();
            ta2.Codigo = ta.Codigo;
            ta2.Descricao = ta.Descricao;
            //a2.TipoAnimal = a.TipoAnimal;
            if (daotipoanimal.Pesquisar(ta2, alt).Count > 0)
            {
                throw new NegocioException("\"Descrição\" do tipo de animal digitado já consta no sistema!");
            }
        }
    }
}
