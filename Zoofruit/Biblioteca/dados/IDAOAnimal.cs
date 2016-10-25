using Biblioteca.basica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.dados
{
   public interface IDAOAnimal
    {
        void adicionar(Animal a);
        void alterar(Animal a);
        void excluir(Animal a);
        List<Animal> pesquisar(Animal a);
    }
}
