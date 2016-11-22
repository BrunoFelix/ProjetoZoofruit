using Biblioteca.basica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.dados
{
    interface iDAOFichaExecucaoMedicamento
    {
        void Adicionar(FichaExecucaoMedicamento fem);
        void Alterar(FichaExecucaoMedicamento fem);
        void Excluir(FichaExecucaoMedicamento fem);
        List<FichaExecucaoMedicamento> Pesquisar(FichaExecucaoMedicamento fem, bool alt = false);
    }
}
