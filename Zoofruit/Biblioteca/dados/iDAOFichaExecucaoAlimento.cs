using Biblioteca.basica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.dados
{
    interface iDAOFichaExecucaoAlimento
    {
        void Adicionar(FichaExecucaoAlimento fea);
        void Alterar(FichaExecucaoAlimento fea);
        void Excluir(FichaExecucaoAlimento fea);
        List<FichaExecucaoAlimento> Pesquisar(FichaExecucaoAlimento fea, bool alt = false);
    }
}
