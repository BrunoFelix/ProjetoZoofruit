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
        void Alterar(Medicamento m);
        void Excluir(Medicamento m);
        List<Medicamento> Pesquisar(Medicamento m);
    }
}
