using Biblioteca.basica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.dados
{
    interface iDAOFichaAlimento
    {
        void adicionar(FichaAlimento fm);
        void alterar(FichaAlimento fm);
        void excluir(FichaAlimento fm);
        List<FichaAlimento> pesquisar(FichaAlimento fm);
    }
}
