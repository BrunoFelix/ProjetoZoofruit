using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.basica;

namespace Biblioteca.dados
{
    interface iDAOAlimento
    {
        void adicionar(Alimento a);
        void alterar(Alimento a);
        void excluir(Alimento a);
        List<Alimento> pesquisar(Alimento a);
    }
}
