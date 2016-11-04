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
        void Adicionar(Medicamento m);
        void Alterar(Medicamento a);
        void Excluir(Medicamento a);
        List<Medicamento> Pesquisar(Medicamento a);
    }
}
