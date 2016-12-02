using Biblioteca.basica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.dados
{
    interface iDAOTipoAnimal
    {
        void Adicionar(TipoAnimal ta);

        void Alterar(TipoAnimal ta);

        void Excluir(TipoAnimal ta);
        List<TipoAnimal> Pesquisar(TipoAnimal ta, bool alt = false);
    }
}
