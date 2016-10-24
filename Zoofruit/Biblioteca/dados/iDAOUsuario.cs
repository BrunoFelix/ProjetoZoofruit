using Biblioteca.basica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.dados
{
    public interface iDAOUsuario
    {
        void adicionar(Usuario u);
        void alterar(Usuario u);
        void excluir(Usuario u);
        List<Usuario> pesquisar(Usuario u);
        



    }
}
