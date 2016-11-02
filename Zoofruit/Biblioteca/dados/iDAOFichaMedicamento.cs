using Biblioteca.basica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.dados
{
    interface iDAOFichaMedicamento
    {
        void Adicionar(FichaMedicamento fm);
        void Alterar(FichaMedicamento fm);
        void Excluir(FichaMedicamento fm);
        List<FichaMedicamento> Pesquisar(FichaMedicamento fm);
    }
}
