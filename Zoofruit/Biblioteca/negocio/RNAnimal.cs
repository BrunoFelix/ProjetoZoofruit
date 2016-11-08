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
    public class RNAnimal : NegocioException
    {
        DAOAnimal daoanimal;
        public RNAnimal()
        {
            daoanimal = new DAOAnimal();
        }

        public void Adicionar(Animal a)
        {
            try
            {
                /*ValidarPreenchimentoDados(u);
                ValidarDados(u);
                VerificarDuplicidade(u);*/
                daoanimal.Adicionar(a);
            }
            catch (Exception ex)
            {
                throw new NegocioException(ex.Message);
            }
        }

        public void Alterar(Animal a)
        {
            try
            {
                /*ValidarPreenchimentoDados(u);
                ValidarDados(u);
                VerificarDuplicidade(u, true);*/
                daoanimal.Alterar(a);
            }
            catch (Exception ex)
            {
                throw new NegocioException(ex.Message);
            }
        }

        public void Excluir(Animal a)
        {
            try
            {
                daoanimal.Excluir(a);
            }
            catch (Exception ex)
            {
                throw new NegocioException(ex.Message);
            }
        }

        public List<Animal> NListarAnimal(Animal a)
        {
            try
            {
                return daoanimal.Pesquisar(a);
            }
            catch (Exception ex)
            {
                throw new NegocioException(ex.Message);
            }
        }

        //######################################### VALIDAÇÕES
    }
    {
    }
}
