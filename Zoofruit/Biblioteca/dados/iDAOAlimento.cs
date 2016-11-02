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
        void Adicionar(Alimento a);
        void Alterar(Alimento a);
        void Excluir(Alimento a);
        List<Alimento> Pesquisar(Alimento a);
    }
}
