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
        void adicionar(FichaMedicamento fm);
        void alterar(FichaMedicamento fm);
        void excluir(FichaMedicamento fm);
        List<FichaMedicamento> pesquisar(FichaMedicamento fm);
    }
}
