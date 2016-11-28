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
        FichaAlimento Adicionar(FichaAlimento fa);
        void Alterar(FichaAlimento fa);
        void Excluir(FichaAlimento fa);
        List<FichaAlimento> Pesquisar(FichaAlimento fa, bool alt=false);
    }
}
