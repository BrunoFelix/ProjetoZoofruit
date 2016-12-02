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
                ValidarPreenchimentoDados(a);
                ValidarDados(a);
                VerificarDuplicidade(a);
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
                ValidarPreenchimentoDados(a);
                ValidarDados(a);
                VerificarDuplicidade(a, true);
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
                if (a.Codigo < 0)
                {
                    throw new NegocioException("O animal que você está tentando excluir não existe!");
                }
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
                throw new NegocioException("O campo \"Porte\" precisa ser preenchido!");
            }
            if (a.Peso == null)
            {
                throw new NegocioException("O campo \"Peso\" precisa ser preenchido!");
            }
            if (a.TipoAnimal == null)
            {
                throw new NegocioException("O campo \"Tipo\" precisa ser preenchido!");
            }
        }

        private void ValidarDados(Animal a)
        {
            if (a.Nome.Length < 3 || a.Nome.Length > 20)
            {
                throw new NegocioException("O campo \"Nome\" precisa conter entre 3 e 20 caracteres!");
            }
            if (a.Cor.Length < 3 || a.Cor.Length > 20)
            {
                throw new NegocioException("O campo \"Cor\" precisa conter entre 3 e 20 caracteres!");
            }
            if (a.Porte.Length < 3 || a.Cor.Length > 18)
            {
                throw new NegocioException("O campo \"Porte\" precisa conter entre 3 e 18 caracteres!");
            }
            if (a.Peso <= 0)
            {
                throw new NegocioException("O campo \"Peso\" deve ser um número maior do que zero!");
            }
            if (a.TipoAnimal.Codigo <= 0)
            {
                throw new NegocioException("O campo \"Tipo\" é inválido!");
            }
        }

        private void VerificarDuplicidade(Animal a, bool alt = false)
        {
            Animal a2 = new Animal();
            a2.Codigo = a.Codigo;
            a2.Nome = a.Nome;
            //a2.TipoAnimal = a.TipoAnimal;
            if (daoanimal.Pesquisar(a2, alt).Count > 0)
            {
                throw new NegocioException("\"Nome\" do animal digitado já consta no sistema!");
            }
        }
    }
}
