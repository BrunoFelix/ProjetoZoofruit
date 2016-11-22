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

        private void ValidarPreenchimentoDados(Animal a)
        {
            if (a.Nome == null || a.Nome.Equals("") == true)
            {
                throw new NegocioException("O campo \"Nome\" precisa ser preenchido!");
            }
            if (a.Cor == null || a.Cor.Equals("") == true)
            {
                throw new NegocioException("O campo \"Cor\" precisa ser preenchido!");
            }
            if (a.Porte == null || a.Porte.Equals("") == true)
            {
                throw new NegocioException("O campo \"CPF\" precisa ser preenchido!");
            }
            if (a.Peso < 0)
            {
                throw new NegocioException("O campo \"Peso\" precisa ser preenchido!");
            }
            if (a.TipoAnimal.Codigo <= 0)
            {
                throw new NegocioException("O campo \"Espécie\" precisa ser preenchido!");
            }
        }

        private void ValidarDados(Animal a)
        {
            if (a.Nome.Length < 3 || a.Nome.Length > 20)
            {
                throw new NegocioException("Nome inválido!");
            }
            if (a.Cor.Length < 3 || a.Cor.Length > 20)
            {
                throw new NegocioException("Cor inválida!");
            }
            if (a.Porte.Length < 1 || a.Cor.Length > 18)
            {
                throw new NegocioException("Porte inválido!");
            }
            if (a.Peso <= 0)
            {
                throw new NegocioException("Peso inválido!");
            }
        }

        private void VerificarDuplicidade(Animal a, bool alt = false)
        {
            Animal a2 = new Animal();
            a2.Codigo = a.Codigo;
            a2.Nome = a.Nome;
            a2.TipoAnimal = a.TipoAnimal;
            if (daoanimal.Pesquisar(a2, alt).Count > 0)
            {
                throw new NegocioException("CPF digitado já consta no sistema!");
            }
        }
}
