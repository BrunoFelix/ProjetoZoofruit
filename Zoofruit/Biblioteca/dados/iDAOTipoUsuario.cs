using Biblioteca.basica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.dados
{
    interface iDAOTipoUsuario
    {
        List<TipoUsuario> Pesquisar(TipoUsuario tu);
    }
}
