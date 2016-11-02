using Biblioteca.basica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.dados
{
   public interface iDAOAnimal
    {
        void Adicionar(Animal a);
        void Alterar(Animal a);
        void Excluir(Animal a);
        List<Animal> Pesquisar(Animal a);
    }
}
