using Biblioteca.basica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.dados
{
    interface iDAOMedicamento
    {
        void adicionar(Medicamento m);
        void alterar(Medicamento a);
        void excluir(Medicamento a);
        List<Medicamento> pesquisar(Medicamento a);
    }
}
