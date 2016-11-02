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
        void Adicionar(FichaAlimento fm);
        void Alterar(FichaAlimento fm);
        void Excluir(FichaAlimento fm);
        List<FichaAlimento> Pesquisar(FichaAlimento fm);
    }
}
